#!/usr/bin/env python3
"""Wait for combat and verify Board.allDots without writing target memory."""

from __future__ import annotations

import argparse
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
    ACTIVE_SINGLETON,
    BOARD_SINGLETON,
    ExternalReadError,
    is_canonical_user_pointer,
)
from pokiguard_v2.il2cpp_layout import (  # noqa: E402
    LayoutValidationError,
    observe_rectangular_reference_array,
)
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.runtime_common import (  # noqa: E402
    attach_target,
    default_log_path,
    hex_pointer,
    utc_timestamp,
)


def pointer_interpretation(memory: Any, value: int) -> str | None:
    if value == 0:
        return "NULL"
    if is_canonical_user_pointer(value) and memory.is_readable(value, 8):
        return "readable_pointer"
    if is_canonical_user_pointer(value):
        return "canonical_unreadable"
    return None


def array_dict(memory: Any, observation: Any) -> dict[str, Any]:
    bounds = observation.bounds
    return {
        "address": hex_pointer(observation.address),
        "class": hex_pointer(observation.class_pointer),
        "monitor": hex_pointer(observation.monitor_pointer),
        "bounds": hex_pointer(observation.bounds_pointer),
        "max_length": observation.max_length,
        "header_dump": [
            {
                "offset": f"0x{offset:02X}",
                "raw_qword": f"0x{value:016X}",
                "interpretation": pointer_interpretation(memory, value),
            }
            for offset, value in enumerate(
                observation.raw_qwords_00_through_80, start=0
            )
            for offset in [offset * 8]
        ],
        "bounds_dump": (
            {
                "raw_qwords": [f"0x{value:016X}" for value in bounds.raw_qwords],
                "dimension_lengths": list(bounds.dimension_lengths),
                "lower_bounds": list(bounds.lower_bounds),
                "padding_words": list(bounds.padding_words),
            }
            if bounds is not None
            else None
        ),
        "layout_verified": observation.layout_verified,
        "rejection_reason": observation.rejection_reason,
        "elements": (
            [
                {
                    "index": index,
                    "gameObject": hex_pointer(pointer) if pointer else None,
                    "null": pointer == 0,
                    "readable": bool(pointer and memory.is_readable(pointer, 0x18)),
                }
                for index, pointer in enumerate(observation.elements)
            ]
            if observation.elements is not None
            else None
        ),
    }


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(
        description="Wait in the background and verify the 8x8 Board.allDots layout"
    )
    parser.add_argument("--log", type=Path, help="JSONL output path")
    parser.add_argument("--hz", type=float, default=8.0, help="poll rate (default: 8)")
    parser.add_argument(
        "--timeout",
        type=float,
        default=0.0,
        help="seconds to wait; zero waits until capture/process exit",
    )
    return parser


def run(args: argparse.Namespace) -> int:
    if not 1.0 <= args.hz <= 10.0:
        raise ValueError("--hz must be between 1 and 10")
    if args.timeout < 0:
        raise ValueError("--timeout cannot be negative")
    log_path = (args.log or default_log_path("all_dots_probe")).resolve()
    log_path.parent.mkdir(parents=True, exist_ok=True)

    with attach_target() as target, log_path.open(
        "a", encoding="utf-8", buffering=1
    ) as log_file:
        start = time.monotonic()
        start_event = {
            "timestamp": utc_timestamp(),
            "event": "watch_started",
            "pid": target.pid,
            "architecture": target.architecture,
            "gameassembly_base": hex_pointer(target.game_assembly.base),
            "gameassembly_size": target.game_assembly.size,
        }
        log_file.write(json.dumps(start_event, ensure_ascii=False) + "\n")
        print(f"Attached read-only to PID {target.pid}; log: {log_path}", flush=True)
        print("Waiting for an accepted, ready combat Board...", flush=True)
        seen_board: int | None = None

        while target.is_running():
            board_resolution = target.resolver.resolve_singleton(BOARD_SINGLETON)
            active_resolution = target.resolver.resolve_singleton(ACTIVE_SINGLETON)
            if board_resolution.resolved and board_resolution.instance is not None:
                active = active_resolution.instance if active_resolution.resolved else None
                board = target.resolver.read_board(board_resolution.instance, active)
                if board.accepted:
                    if seen_board != board.board_instance:
                        seen_board = board.board_instance
                        event = {
                            "timestamp": utc_timestamp(),
                            "event": "board_found",
                            "board": hex_pointer(board.board_instance),
                            "allDots": hex_pointer(board.all_dots),
                            "ready": board.is_board_ready,
                            "cascade": board.is_cascade_running,
                        }
                        log_file.write(json.dumps(event) + "\n")
                        print(
                            f"Board found: {event['board']}; waiting until ready...",
                            flush=True,
                        )
                    if board.is_board_ready and board.all_dots is not None:
                        observation = observe_rectangular_reference_array(
                            target.memory, board.all_dots, (8, 8)
                        )
                        event = {
                            "timestamp": utc_timestamp(),
                            "event": "array_snapshot",
                            "board": hex_pointer(board.board_instance),
                            "ready": board.is_board_ready,
                            "cascade": board.is_cascade_running,
                            "array": array_dict(target.memory, observation),
                        }
                        log_file.write(json.dumps(event, ensure_ascii=False) + "\n")
                        non_null = sum(
                            pointer != 0 for pointer in (observation.elements or ())
                        )
                        print(
                            f"allDots captured: layout_verified={observation.layout_verified}, "
                            f"max_length={observation.max_length}, non_null={non_null}/64",
                            flush=True,
                        )
                        return 0 if observation.layout_verified else 2
            if args.timeout and time.monotonic() - start >= args.timeout:
                raise TimeoutError("timed out waiting for a ready combat Board")
            time.sleep(1.0 / args.hz)
        raise ProcessProbeError("Pokiguard.exe exited before allDots was captured")


def main(argv: Sequence[str] | None = None) -> int:
    args = build_parser().parse_args(argv)
    try:
        return run(args)
    except KeyboardInterrupt:
        print("Probe stopped by user.")
        return 130
    except (
        ExternalReadError,
        LayoutValidationError,
        OSError,
        ProcessProbeError,
        TimeoutError,
        ValueError,
    ) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
