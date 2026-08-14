#!/usr/bin/env python3
"""Watch verified Pokiguard IL2CPP singleton slots using read-only Win32 APIs.

Start this once while the game is in the lobby, then leave it running while you
enter combat.  It emits JSONL and console output only when observed state changes.
"""

from __future__ import annotations

import argparse
import ctypes
from ctypes import wintypes
from datetime import datetime, timezone
import json
from pathlib import Path
import sys
import time
from typing import Any, Sequence


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.il2cpp_external import (  # noqa: E402
    BoardRuntimeState,
    ExternalReadError,
    Il2CppExternalResolver,
    SingletonResolution,
    Win32RemoteMemory,
)
from tools.process_probe import (  # noqa: E402
    PROCESS_QUERY_INFORMATION,
    PROCESS_VM_READ,
    ProcessProbeError,
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


def resolution_dict(value: SingletonResolution) -> dict[str, Any]:
    return {
        "status": value.status,
        "type_info_slot": hex_pointer(value.type_info_slot),
        "class": hex_pointer(value.class_pointer),
        "static_fields": hex_pointer(value.static_fields),
        "instance": hex_pointer(value.instance),
        "detail": value.detail,
    }


def board_dict(value: BoardRuntimeState | None) -> dict[str, Any] | None:
    if value is None:
        return None
    return {
        "board_instance": hex_pointer(value.board_instance),
        "width": value.width,
        "height": value.height,
        "allDots": hex_pointer(value.all_dots),
        "active": hex_pointer(value.active),
        "isCascadeRunning": value.is_cascade_running,
        "isBoardReady": value.is_board_ready,
        "active_singleton": hex_pointer(value.active_singleton),
        "active_board": hex_pointer(value.active_board),
        "activeBackReference": value.active_back_reference,
        "boardActiveMatchesSingleton": value.board_active_matches_singleton,
        "accepted": value.accepted,
        "rejection_reason": value.rejection_reason,
    }


def take_sample(resolver: Il2CppExternalResolver) -> dict[str, Any]:
    singletons = resolver.resolve_known_singletons()
    board: BoardRuntimeState | None = None
    board_error: str | None = None
    board_resolution = singletons["Board"]
    active_resolution = singletons["Active"]
    if board_resolution.resolved and board_resolution.instance is not None:
        try:
            active_instance = (
                active_resolution.instance if active_resolution.resolved else None
            )
            board = resolver.read_board(board_resolution.instance, active_instance)
        except (ExternalReadError, OSError) as exc:
            board_error = str(exc)
    return {
        "singletons": {
            name: resolution_dict(value) for name, value in singletons.items()
        },
        "board": board_dict(board),
        "board_error": board_error,
    }


class TransitionTracker:
    """Classify samples while suppressing identical polling results."""

    def __init__(self) -> None:
        self._last_signature: str | None = None
        self._accepted_board: str | None = None

    def classify(self, sample: dict[str, Any]) -> str | None:
        signature = json.dumps(sample, sort_keys=True, separators=(",", ":"))
        if signature == self._last_signature:
            return None
        self._last_signature = signature

        board = sample.get("board")
        current = (
            board.get("board_instance")
            if isinstance(board, dict) and board.get("accepted") is True
            else None
        )
        previous = self._accepted_board
        self._accepted_board = current

        if current is not None and current != previous:
            return "board_found"
        if previous is not None and current is None:
            return "board_lost"
        if current is not None:
            return "board_state"
        if isinstance(board, dict):
            return "board_candidate_rejected"
        if sample.get("board_error"):
            return "board_read_error"
        return "board_absent" if previous is None else "resolver_state"


def make_event(
    event_type: str,
    pid: int,
    architecture: str,
    module_base: int,
    module_size: int,
    sample: dict[str, Any] | None = None,
) -> dict[str, Any]:
    event: dict[str, Any] = {
        "timestamp": utc_timestamp(),
        "event": event_type,
        "pid": pid,
        "architecture": architecture,
        "gameassembly_base": hex_pointer(module_base),
        "gameassembly_size": module_size,
    }
    if sample is not None:
        event.update(sample)
    return event


def event_summary(event: dict[str, Any]) -> str:
    board = event.get("board") or {}
    instance = board.get("board_instance")
    if instance:
        return (
            f"{event['timestamp']} {event['event']}: Board={instance} "
            f"{board.get('width')}x{board.get('height')} ready={board.get('isBoardReady')} "
            f"cascade={board.get('isCascadeRunning')}"
        )
    status = ((event.get("singletons") or {}).get("Board") or {}).get("status")
    suffix = f" Board={status}" if status else ""
    return f"{event['timestamp']} {event['event']}{suffix}"


def process_is_running(handle: int) -> bool:
    exit_code = wintypes.DWORD()
    kernel32.GetExitCodeProcess.argtypes = [
        wintypes.HANDLE,
        ctypes.POINTER(wintypes.DWORD),
    ]
    kernel32.GetExitCodeProcess.restype = wintypes.BOOL
    if not kernel32.GetExitCodeProcess(handle, ctypes.byref(exit_code)):
        return False
    return exit_code.value == STILL_ACTIVE


def default_log_path() -> Path:
    stamp = datetime.now().strftime("%Y%m%d_%H%M%S")
    return PROJECT_ROOT / "logs" / f"runtime_board_watch_{stamp}.jsonl"


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(
        description="Read-only watcher for verified Board/Active/ManagerMatch singletons"
    )
    parser.add_argument(
        "--watch",
        action="store_true",
        help="poll continuously; without this option one sample is taken",
    )
    parser.add_argument(
        "--log",
        type=Path,
        help="JSONL path (default: logs/runtime_board_watch_<timestamp>.jsonl)",
    )
    parser.add_argument(
        "--hz", type=float, default=8.0, help="poll rate from 5 through 10 Hz (default: 8)"
    )
    return parser


def run(args: argparse.Namespace) -> int:
    if not 5.0 <= args.hz <= 10.0:
        raise ValueError("--hz must be between 5 and 10")
    assert_python_x64()

    pid = find_process_id("Pokiguard.exe")
    if pid is None:
        raise ProcessProbeError("Pokiguard.exe is not running")
    modules = enumerate_modules(pid)
    game_assembly = find_named_module(modules, "GameAssembly.dll")
    if game_assembly is None:
        raise ProcessProbeError("GameAssembly.dll not found in target module list")

    access = PROCESS_QUERY_INFORMATION | PROCESS_VM_READ
    process = kernel32.OpenProcess(access, False, pid)
    if not process:
        raise ctypes.WinError(ctypes.get_last_error())

    log_path = (args.log or default_log_path()).resolve()
    log_path.parent.mkdir(parents=True, exist_ok=True)
    try:
        architecture = target_architecture(process)
        if architecture != "x64":
            raise ProcessProbeError(f"expected x64 target, got {architecture}")
        memory = Win32RemoteMemory(process)
        resolver = Il2CppExternalResolver(
            memory, game_assembly.base, game_assembly.size
        )
        tracker = TransitionTracker()

        print(f"Watcher attached: PID {pid}, {architecture}")
        print(f"GameAssembly: {hex_pointer(game_assembly.base)}, size 0x{game_assembly.size:X}")
        print(f"JSONL: {log_path}")
        print("Board.Instance may be NULL in the lobby; no terminal input is needed.")

        with log_path.open("a", encoding="utf-8", buffering=1) as log_file:
            start_event = make_event(
                "watch_started",
                pid,
                architecture,
                game_assembly.base,
                game_assembly.size,
            )
            log_file.write(json.dumps(start_event, ensure_ascii=False) + "\n")
            print(event_summary(start_event), flush=True)

            while True:
                if not process_is_running(process):
                    exit_event = make_event(
                        "process_exited",
                        pid,
                        architecture,
                        game_assembly.base,
                        game_assembly.size,
                    )
                    log_file.write(json.dumps(exit_event, ensure_ascii=False) + "\n")
                    print(event_summary(exit_event), flush=True)
                    break

                sample = take_sample(resolver)
                event_type = tracker.classify(sample)
                if event_type is not None:
                    event = make_event(
                        event_type,
                        pid,
                        architecture,
                        game_assembly.base,
                        game_assembly.size,
                        sample,
                    )
                    log_file.write(json.dumps(event, ensure_ascii=False) + "\n")
                    print(event_summary(event), flush=True)

                if not args.watch:
                    break
                time.sleep(1.0 / args.hz)
        return 0
    finally:
        _close_handle(process)


def main(argv: Sequence[str] | None = None) -> int:
    parser = build_parser()
    args = parser.parse_args(argv)
    try:
        return run(args)
    except KeyboardInterrupt:
        print("Watcher stopped by user.")
        return 130
    except (OSError, ProcessProbeError, ExternalReadError, ValueError) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
