"""Shared read-only target attachment helpers for Phase 2A command-line probes."""

from __future__ import annotations

import ctypes
from ctypes import wintypes
from dataclasses import dataclass
from datetime import datetime, timezone
from pathlib import Path
import sys
import threading


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.il2cpp_external import (  # noqa: E402
    Il2CppExternalResolver,
    Win32RemoteMemory,
)
from tools.process_probe import (  # noqa: E402
    PROCESS_QUERY_INFORMATION,
    PROCESS_VM_READ,
    ProcessProbeError,
    ModuleInfo,
    _close_handle,
    assert_python_x64,
    enumerate_modules,
    enumerate_processes,
    find_named_module,
    find_process_ids,
    kernel32,
    target_architecture,
)
from pokiguard_v2.app_paths import current_app_paths  # noqa: E402
from pokiguard_v2.game_location import (  # noqa: E402
    GameExecutableSelection,
    GameLocationError,
    is_supported_game_executable_name,
    resolve_game_executable,
    validate_supported_game_assembly,
)


STILL_ACTIVE = 259
_GAME_LOCATION_LOCK = threading.RLock()
_GAME_EXECUTABLE_SELECTION: GameExecutableSelection | None = None


class IncompatibleGameBuildError(ProcessProbeError):
    """The exact process exists but its read-only layout is not verified."""

    def __init__(self, message: str, *, pid: int, architecture: str) -> None:
        super().__init__(message)
        self.game_detected = True
        self.pid = pid
        self.architecture = architecture


def utc_timestamp() -> str:
    return datetime.now(timezone.utc).isoformat(timespec="milliseconds").replace(
        "+00:00", "Z"
    )


def hex_pointer(value: int | None) -> str | None:
    return f"0x{value:016X}" if value is not None else None


@dataclass
class RuntimeTarget:
    pid: int
    architecture: str
    game_assembly: ModuleInfo
    process_handle: int
    memory: Win32RemoteMemory
    resolver: Il2CppExternalResolver

    def close(self) -> None:
        if self.process_handle:
            _close_handle(self.process_handle)
            self.process_handle = 0

    def is_running(self) -> bool:
        exit_code = wintypes.DWORD()
        kernel32.GetExitCodeProcess.argtypes = [
            wintypes.HANDLE,
            ctypes.POINTER(wintypes.DWORD),
        ]
        kernel32.GetExitCodeProcess.restype = wintypes.BOOL
        return bool(
            kernel32.GetExitCodeProcess(self.process_handle, ctypes.byref(exit_code))
            and exit_code.value == STILL_ACTIVE
        )

    def __enter__(self) -> "RuntimeTarget":
        return self

    def __exit__(self, *_args: object) -> None:
        self.close()


def configure_game_location(location: str | Path) -> GameExecutableSelection:
    """Validate and atomically select the executable used by every attach path."""

    selection = resolve_game_executable(location)
    global _GAME_EXECUTABLE_SELECTION
    with _GAME_LOCATION_LOCK:
        _GAME_EXECUTABLE_SELECTION = selection
    return selection


def configured_game_executable() -> GameExecutableSelection | None:
    with _GAME_LOCATION_LOCK:
        return _GAME_EXECUTABLE_SELECTION


def _same_windows_path(first: str | Path, second: str | Path) -> bool:
    return str(Path(first).resolve()).casefold() == str(Path(second).resolve()).casefold()


def _find_configured_process(selection: GameExecutableSelection) -> int | None:
    """Match both image name and full module path; never attach another install."""

    for pid in find_process_ids(selection.executable.name):
        try:
            modules = enumerate_modules(pid)
        except OSError:
            continue
        executable_module = find_named_module(modules, selection.executable.name)
        if executable_module is not None and _same_windows_path(
            executable_module.path, selection.executable
        ):
            return pid
    return None


def _discover_running_game() -> tuple[GameExecutableSelection, int] | None:
    """Compatibility fallback for CLI tools before an operator saves Settings."""

    matches: list[tuple[GameExecutableSelection, int]] = []
    for process in enumerate_processes():
        if not is_supported_game_executable_name(process.executable_name):
            continue
        try:
            modules = enumerate_modules(process.pid)
            executable_module = find_named_module(
                modules, process.executable_name
            )
            if executable_module is None:
                continue
            selection = resolve_game_executable(executable_module.path)
        except (OSError, ValueError):
            continue
        matches.append((selection, process.pid))
    if not matches:
        return None
    unique = {
        (str(selection.executable).casefold(), pid): (selection, pid)
        for selection, pid in matches
    }
    if len(unique) != 1:
        raise ProcessProbeError(
            "multiple Pokiguard game processes are running; select the exact "
            "game folder in Settings"
        )
    return next(iter(unique.values()))


def attach_target() -> RuntimeTarget:
    """Attach with only PROCESS_QUERY_INFORMATION | PROCESS_VM_READ."""

    assert_python_x64()
    selection = configured_game_executable()
    if selection is None:
        discovered = _discover_running_game()
        if discovered is None:
            raise ProcessProbeError(
                "Pokiguard-<version>.exe is not running; select the game folder "
                "in Settings"
            )
        selection, pid = discovered
    else:
        pid = _find_configured_process(selection)
    if pid is None:
        raise ProcessProbeError(f"{selection.executable.name} is not running")
    game_assembly = find_named_module(enumerate_modules(pid), "GameAssembly.dll")
    if game_assembly is None:
        raise ProcessProbeError("GameAssembly.dll not found in target module list")
    access = PROCESS_QUERY_INFORMATION | PROCESS_VM_READ
    process = kernel32.OpenProcess(access, False, pid)
    if not process:
        raise ctypes.WinError(ctypes.get_last_error())
    try:
        architecture = target_architecture(process)
        if architecture != "x64":
            raise ProcessProbeError(f"expected x64 target, got {architecture}")
        try:
            validate_supported_game_assembly(game_assembly.path)
        except GameLocationError as exc:
            if exc.reason != "GAME_BUILD_INCOMPATIBLE":
                raise
            raise IncompatibleGameBuildError(
                str(exc), pid=pid, architecture=architecture
            ) from exc
        memory = Win32RemoteMemory(process)
        resolver = Il2CppExternalResolver(
            memory,
            game_assembly.base,
            game_assembly.size,
        )
        return RuntimeTarget(
            pid,
            architecture,
            game_assembly,
            process,
            memory,
            resolver,
        )
    except Exception:
        _close_handle(process)
        raise


def default_log_path(prefix: str) -> Path:
    stamp = datetime.now().strftime("%Y%m%d_%H%M%S")
    return current_app_paths().logs_root / f"{prefix}_{stamp}.jsonl"
