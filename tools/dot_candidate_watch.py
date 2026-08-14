#!/usr/bin/env python3
"""One-shot read-only heap fingerprint scan for live Dot components."""

from __future__ import annotations

import argparse
import json
from pathlib import Path
import sys
import time
from typing import Sequence


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.il2cpp_external import (  # noqa: E402
    ACTIVE_SINGLETON,
    BOARD_SINGLETON,
    DOT_TYPE_INFO_RVA,
    ExternalReadError,
)
from pokiguard_v2.il2cpp_layout import (  # noqa: E402
    LayoutValidationError,
    all_dots_index,
    observe_rectangular_reference_array,
)
from pokiguard_v2.memory_scan import (  # noqa: E402
    scan_aligned_qwords,
    validate_dot_pointer_hits,
)
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.runtime_common import (  # noqa: E402
    attach_target,
    default_log_path,
    hex_pointer,
    utc_timestamp,
)


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(
        description="Wait for a stable Board, then scan readable memory once for Dot._board"
    )
    parser.add_argument("--log", type=Path, help="JSONL output path")
    parser.add_argument("--hz", type=float, default=8.0, help="poll rate (default: 8)")
    parser.add_argument(
        "--chunk-mib", type=int, default=4, help="scan chunk size in MiB (default: 4)"
    )
    parser.add_argument(
        "--timeout",
        type=float,
        default=0.0,
        help="seconds to wait for combat; zero waits indefinitely",
    )
    return parser


def run(args: argparse.Namespace) -> int:
    if not 1.0 <= args.hz <= 10.0:
        raise ValueError("--hz must be between 1 and 10")
    if not 1 <= args.chunk_mib <= 64:
        raise ValueError("--chunk-mib must be between 1 and 64")
    if args.timeout < 0:
        raise ValueError("--timeout cannot be negative")
    log_path = (args.log or default_log_path("dot_candidate_watch")).resolve()
    log_path.parent.mkdir(parents=True, exist_ok=True)

    with attach_target() as target, log_path.open(
        "a", encoding="utf-8", buffering=1
    ) as log_file:
        started_at = time.monotonic()
        start_event = {
            "timestamp": utc_timestamp(),
            "event": "watch_started",
            "pid": target.pid,
            "gameassembly_base": hex_pointer(target.game_assembly.base),
            "gameassembly_size": target.game_assembly.size,
        }
        log_file.write(json.dumps(start_event) + "\n")
        print(f"Attached read-only to PID {target.pid}; log: {log_path}", flush=True)
        print("Waiting for Board ready=true and cascade=false...", flush=True)

        while target.is_running():
            board_resolution = target.resolver.resolve_singleton(BOARD_SINGLETON)
            active_resolution = target.resolver.resolve_singleton(ACTIVE_SINGLETON)
            if board_resolution.resolved and board_resolution.instance is not None:
                active = active_resolution.instance if active_resolution.resolved else None
                board = target.resolver.read_board(board_resolution.instance, active)
                if (
                    board.accepted
                    and board.is_board_ready
                    and not board.is_cascade_running
                    and board.all_dots is not None
                ):
                    dot_class = target.resolver.resolve_type_info_class(DOT_TYPE_INFO_RVA)
                    if dot_class is None:
                        raise LayoutValidationError("Dot type-info slot is not initialized")
                    array = observe_rectangular_reference_array(
                        target.memory, board.all_dots, (8, 8)
                    )
                    if not array.layout_verified or array.elements is None:
                        raise LayoutValidationError(
                            array.rejection_reason or "allDots layout is not verified"
                        )

                    event = {
                        "timestamp": utc_timestamp(),
                        "event": "scan_started",
                        "board": hex_pointer(board.board_instance),
                        "allDots": hex_pointer(board.all_dots),
                        "dot_class": hex_pointer(dot_class),
                    }
                    log_file.write(json.dumps(event) + "\n")
                    print(
                        f"Stable Board {event['board']} found; starting one memory scan...",
                        flush=True,
                    )

                    regions = list(target.memory.iter_readable_regions())

                    def progress(visited: int, byte_count: int) -> None:
                        if visited % 128 == 0:
                            print(
                                f"Scan progress: {visited}/{len(regions)} regions, "
                                f"{byte_count / (1024 * 1024):.1f} MiB read",
                                flush=True,
                            )

                    scan = scan_aligned_qwords(
                        target.memory,
                        regions,
                        {"board": board.board_instance},
                        chunk_size=args.chunk_mib * 1024 * 1024,
                        progress=progress,
                    )
                    result = validate_dot_pointer_hits(
                        target.memory,
                        scan.matches["board"],
                        board_pointer=board.board_instance,
                        dot_class=dot_class,
                    )
                    candidates = []
                    for dot in result.candidates:
                        index = all_dots_index(dot.column, dot.row)
                        game_object = array.elements[index]
                        candidates.append(
                            {
                                "dot": hex_pointer(dot.address),
                                "row": dot.row,
                                "col": dot.column,
                                "multiplier": dot.multiplier,
                                "originalPrefab": hex_pointer(dot.original_prefab),
                                "cachedNative": hex_pointer(dot.cached_native_pointer),
                                "allDots_index": index,
                                "gameObject": hex_pointer(game_object) if game_object else None,
                            }
                        )
                    output = {
                        "timestamp": utc_timestamp(),
                        "event": "dot_set_found",
                        "board": hex_pointer(board.board_instance),
                        "scan": {
                            "regions": scan.regions_visited,
                            "bytes_read": scan.bytes_read,
                            "failed_chunks": scan.failed_chunks,
                            "board_pointer_hits": result.pointer_hits,
                        },
                        "validated_candidates": len(result.candidates),
                        "unique_coordinates": len(result.by_coordinate),
                        "missing": [list(item) for item in result.missing_coordinates],
                        "duplicates": {
                            f"{row},{col}": [hex_pointer(value) for value in values]
                            for (row, col), values in result.duplicate_coordinates.items()
                        },
                        "candidates": candidates,
                    }
                    log_file.write(json.dumps(output, ensure_ascii=False) + "\n")
                    print(
                        f"Dot scan complete: {len(result.candidates)} candidates, "
                        f"{len(result.by_coordinate)}/64 unique coordinates, "
                        f"{len(result.missing_coordinates)} missing, "
                        f"{len(result.duplicate_coordinates)} duplicate coordinates.",
                        flush=True,
                    )
                    return 0 if len(result.by_coordinate) == 64 else 2
            if args.timeout and time.monotonic() - started_at >= args.timeout:
                raise TimeoutError("timed out waiting for a stable combat Board")
            time.sleep(1.0 / args.hz)
        raise ProcessProbeError("Pokiguard.exe exited before the Dot scan")


def main(argv: Sequence[str] | None = None) -> int:
    args = build_parser().parse_args(argv)
    try:
        return run(args)
    except KeyboardInterrupt:
        print("Watcher stopped by user.")
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
