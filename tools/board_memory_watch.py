#!/usr/bin/env python3
"""Automatic Phase 2A observer: Board lifecycle, allDots, Dot set, and DTO tags.

The observer requests only query/read process rights.  It performs one committed
readable-memory scan per Board instance and never invokes a target method.
"""

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
    DOT_TYPE_INFO_RVA,
    WS_COMBAT_BATCH_TYPE_INFO_RVA,
    ExternalReadError,
)
from pokiguard_v2.il2cpp_layout import (  # noqa: E402
    CombatBatchSnapshot,
    LayoutValidationError,
    RectangularArrayObservation,
    all_dots_index,
    observe_rectangular_reference_array,
)
from pokiguard_v2.memory_scan import (  # noqa: E402
    DotCandidateResult,
    scan_aligned_qwords,
    validate_combat_batch_hits,
    validate_dot_pointer_hits,
)
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.runtime_common import (  # noqa: E402
    attach_target,
    default_log_path,
    hex_pointer,
    utc_timestamp,
)


# These are literal Vietnamese color tags named by BoardWsApplier's native
# warning plus V1's independently evidenced HSV color semantics.  Unknown tags
# remain null; there is no fuzzy or positional inference.
TAG_TO_GEM = {
    "vang": "SWORD",
    "xanhduong": "MANA",
    "do": "RAGE",
    "tim": "SHIELD",
    "xanh": "HEALTH",
    "trang": "DRAIN",
}


def normalize_tag(tag: str) -> str:
    normalized = "".join(
        character for character in tag.casefold() if character.isalnum()
    )
    # Runtime DTO evidence uses values such as "xanhduong Dot".  Strip only
    # this exact normalized suffix; do not use fuzzy color/name matching.
    return normalized[:-3] if normalized.endswith("dot") else normalized


def gem_for_tag(tag: str | None) -> str | None:
    return TAG_TO_GEM.get(normalize_tag(tag)) if tag is not None else None


def write_event(log_file: Any, event: str, **payload: Any) -> dict[str, Any]:
    value = {"timestamp": utc_timestamp(), "event": event, **payload}
    log_file.write(json.dumps(value, ensure_ascii=False) + "\n")
    return value


def select_latest_batch(
    batches: tuple[CombatBatchSnapshot, ...],
) -> CombatBatchSnapshot | None:
    """Select the greatest server sequence; caller still records stale-risk caveat."""

    return max(batches, key=lambda item: (item.sequence, item.address), default=None)


def snapshot_cells(
    array: RectangularArrayObservation,
    dots: DotCandidateResult | None,
    batch: CombatBatchSnapshot | None,
) -> list[dict[str, Any]]:
    tags = (
        {(cell.row, cell.col): cell for cell in batch.cells}
        if batch is not None
        else {}
    )
    cells: list[dict[str, Any]] = []
    elements = array.elements or ()
    for row in range(8):
        for col in range(8):
            index = all_dots_index(col, row)
            game_object = elements[index] if index < len(elements) else 0
            dot_values = dots.by_coordinate.get((row, col), ()) if dots else ()
            # Duplicates are ambiguity, not an invitation to select arbitrarily.
            dot = dot_values[0] if len(dot_values) == 1 else None
            dto = tags.get((row, col))
            tag = dto.tag if dto is not None else None
            cells.append(
                {
                    "row": row,
                    "col": col,
                    "allDots_index": index,
                    "gameObject": hex_pointer(game_object) if game_object else None,
                    "dot": hex_pointer(dot.address) if dot else None,
                    "originalPrefab": hex_pointer(dot.original_prefab) if dot else None,
                    "multiplier": (
                        dot.multiplier if dot is not None else dto.multiplier if dto else None
                    ),
                    "tag": tag,
                    "gem": gem_for_tag(tag),
                }
            )
    return cells


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(
        description="Read-only automatic Board/allDots/Dot/DTO observer"
    )
    parser.add_argument("--log", type=Path, help="JSONL output path")
    parser.add_argument("--hz", type=float, default=8.0, help="poll rate (default: 8)")
    parser.add_argument(
        "--chunk-mib", type=int, default=4, help="one-pass scan chunk size (default: 4)"
    )
    parser.add_argument(
        "--timeout",
        type=float,
        default=0.0,
        help="total seconds to observe; zero waits through one Board lifecycle",
    )
    return parser


def run(args: argparse.Namespace) -> int:
    if not 1.0 <= args.hz <= 10.0:
        raise ValueError("--hz must be between 1 and 10")
    if not 1 <= args.chunk_mib <= 64:
        raise ValueError("--chunk-mib must be between 1 and 64")
    if args.timeout < 0:
        raise ValueError("--timeout cannot be negative")
    log_path = (args.log or default_log_path("board_memory_watch")).resolve()
    log_path.parent.mkdir(parents=True, exist_ok=True)

    with attach_target() as target, log_path.open(
        "a", encoding="utf-8", buffering=1
    ) as log_file:
        started_at = time.monotonic()
        write_event(
            log_file,
            "watch_started",
            pid=target.pid,
            architecture=target.architecture,
            gameassembly_base=hex_pointer(target.game_assembly.base),
            gameassembly_size=target.game_assembly.size,
            access=["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"],
        )
        print(f"Observer attached read-only to PID {target.pid}; log: {log_path}")
        print("Leave this window running; return to the game and enter combat.", flush=True)

        current_board: int | None = None
        ready_reported = False
        scan_completed = False
        saw_board = False
        last_elements: tuple[int, ...] | None = None

        while target.is_running():
            board_resolution = target.resolver.resolve_singleton(BOARD_SINGLETON)
            active_resolution = target.resolver.resolve_singleton(ACTIVE_SINGLETON)
            accepted_board = None
            if board_resolution.resolved and board_resolution.instance is not None:
                try:
                    active = active_resolution.instance if active_resolution.resolved else None
                    candidate = target.resolver.read_board(board_resolution.instance, active)
                    if candidate.accepted:
                        accepted_board = candidate
                except (ExternalReadError, OSError) as exc:
                    write_event(log_file, "board_read_error", detail=str(exc))

            if accepted_board is None:
                if current_board is not None:
                    write_event(log_file, "board_lost", board=hex_pointer(current_board))
                    print(f"Board lost: {hex_pointer(current_board)}", flush=True)
                    return 0 if scan_completed else 2
                if args.timeout and time.monotonic() - started_at >= args.timeout:
                    raise TimeoutError("observer timeout expired before Board lifecycle completed")
                time.sleep(1.0 / args.hz)
                continue

            board = accepted_board
            if current_board != board.board_instance:
                current_board = board.board_instance
                saw_board = True
                ready_reported = False
                scan_completed = False
                last_elements = None
                write_event(
                    log_file,
                    "board_found",
                    board=hex_pointer(board.board_instance),
                    allDots=hex_pointer(board.all_dots),
                    ready=board.is_board_ready,
                    cascade=board.is_cascade_running,
                )
                print(f"Board found: {hex_pointer(board.board_instance)}", flush=True)

            if board.is_board_ready and not ready_reported:
                ready_reported = True
                write_event(
                    log_file,
                    "board_ready",
                    board=hex_pointer(board.board_instance),
                    cascade=board.is_cascade_running,
                )
                print("Board is ready; waiting for a non-cascade sample.", flush=True)

            if board.all_dots is not None:
                try:
                    array = observe_rectangular_reference_array(
                        target.memory, board.all_dots, (8, 8)
                    )
                except (ExternalReadError, LayoutValidationError, OSError) as exc:
                    write_event(log_file, "array_read_error", detail=str(exc))
                    array = None
                if array is not None and array.layout_verified and array.elements is not None:
                    if last_elements is not None and array.elements != last_elements:
                        changed = [
                            index
                            for index, (before, after) in enumerate(
                                zip(last_elements, array.elements)
                            )
                            if before != after
                        ]
                        write_event(
                            log_file,
                            "board_changed",
                            board=hex_pointer(board.board_instance),
                            changed_indices=changed,
                            # No rescan: new Dot/tag identity is intentionally unknown.
                            cells=snapshot_cells(array, None, None),
                        )
                    last_elements = array.elements

                    if (
                        board.is_board_ready
                        and not board.is_cascade_running
                        and not scan_completed
                    ):
                        dot_class = target.resolver.resolve_type_info_class(
                            DOT_TYPE_INFO_RVA
                        )
                        batch_class = target.resolver.resolve_type_info_class(
                            WS_COMBAT_BATCH_TYPE_INFO_RVA
                        )
                        if dot_class is None:
                            raise LayoutValidationError(
                                "Dot type-info slot is not initialized"
                            )
                        needles = {"board": board.board_instance}
                        if batch_class is not None:
                            needles["batch_class"] = batch_class
                        regions = list(target.memory.iter_readable_regions())
                        write_event(
                            log_file,
                            "memory_scan_started",
                            board=hex_pointer(board.board_instance),
                            dot_class=hex_pointer(dot_class),
                            batch_class=hex_pointer(batch_class),
                            readable_regions=len(regions),
                        )
                        print(
                            f"Starting one read-only scan over {len(regions)} readable regions...",
                            flush=True,
                        )

                        def progress(visited: int, byte_count: int) -> None:
                            if visited % 128 == 0:
                                print(
                                    f"Scan: {visited}/{len(regions)} regions, "
                                    f"{byte_count / (1024 * 1024):.1f} MiB",
                                    flush=True,
                                )

                        scan = scan_aligned_qwords(
                            target.memory,
                            regions,
                            needles,
                            chunk_size=args.chunk_mib * 1024 * 1024,
                            progress=progress,
                        )
                        dots = validate_dot_pointer_hits(
                            target.memory,
                            scan.matches["board"],
                            board_pointer=board.board_instance,
                            dot_class=dot_class,
                        )
                        batches = (
                            validate_combat_batch_hits(
                                target.memory,
                                scan.matches.get("batch_class", ()),
                                batch_class=batch_class,
                            )
                            if batch_class is not None
                            else ()
                        )
                        batch = select_latest_batch(batches)
                        write_event(
                            log_file,
                            "dot_set_found",
                            board=hex_pointer(board.board_instance),
                            pointer_hits=dots.pointer_hits,
                            validated_candidates=len(dots.candidates),
                            unique_coordinates=len(dots.by_coordinate),
                            missing=[list(value) for value in dots.missing_coordinates],
                            duplicates={
                                f"{row},{col}": [hex_pointer(value) for value in values]
                                for (row, col), values in dots.duplicate_coordinates.items()
                            },
                        )
                        cells = snapshot_cells(array, dots, batch)
                        write_event(
                            log_file,
                            "board_snapshot",
                            board=hex_pointer(board.board_instance),
                            allDots=hex_pointer(board.all_dots),
                            ready=board.is_board_ready,
                            cascade=board.is_cascade_running,
                            array_layout_verified=array.layout_verified,
                            dot_candidates=len(dots.candidates),
                            unique_dot_coordinates=len(dots.by_coordinate),
                            combat_batch_candidates=len(batches),
                            selected_batch=(
                                {
                                    "object": hex_pointer(batch.address),
                                    "srvSeq": batch.sequence,
                                    "board_array": hex_pointer(batch.board_array),
                                    "currentness": "temporary source; newest validated sequence, not independently linked to Board.Instance",
                                }
                                if batch is not None
                                else None
                            ),
                            tag_source=(
                                "WsCombatBatch.board -> BoardCellDTO.tag"
                                if batch is not None
                                else None
                            ),
                            gem_mapping=(
                                "exact six Vietnamese color tags -> V1 HSV Token semantics"
                                if batch is not None
                                else None
                            ),
                            scan={
                                "regions": scan.regions_visited,
                                "bytes_read": scan.bytes_read,
                                "failed_chunks": scan.failed_chunks,
                            },
                            cells=cells,
                        )
                        scan_completed = True
                        known_tags = sum(cell["tag"] is not None for cell in cells)
                        known_gems = sum(cell["gem"] is not None for cell in cells)
                        print(
                            f"Snapshot: dots={len(dots.by_coordinate)}/64, "
                            f"tags={known_tags}/64, gems={known_gems}/64. "
                            "Observer will stay up until combat ends.",
                            flush=True,
                        )

            if args.timeout and time.monotonic() - started_at >= args.timeout:
                write_event(
                    log_file,
                    "watch_timeout",
                    board=hex_pointer(current_board),
                    scan_completed=scan_completed,
                )
                return 0 if scan_completed else 2
            time.sleep(1.0 / args.hz)

        if saw_board:
            write_event(log_file, "process_exited", board=hex_pointer(current_board))
            return 0 if scan_completed else 2
        raise ProcessProbeError("Pokiguard.exe exited before combat")


def main(argv: Sequence[str] | None = None) -> int:
    args = build_parser().parse_args(argv)
    try:
        return run(args)
    except KeyboardInterrupt:
        print("Observer stopped by user.")
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
