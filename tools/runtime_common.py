"""Shared read-only target attachment helpers for Phase 2A command-line probes."""

from __future__ import annotations

import ctypes
from ctypes import wintypes
from dataclasses import dataclass
from datetime import datetime, timezone
from pathlib import Path
import sys


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
    find_named_module,
    find_process_id,
    kernel32,
    target_architecture,
)


STILL_ACTIVE = 259


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


def attach_target() -> RuntimeTarget:
    """Attach with only PROCESS_QUERY_INFORMATION | PROCESS_VM_READ."""

    assert_python_x64()
    pid = find_process_id("Pokiguard.exe")
    if pid is None:
        raise ProcessProbeError("Pokiguard.exe is not running")
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
    return PROJECT_ROOT / "logs" / f"{prefix}_{stamp}.jsonl"
