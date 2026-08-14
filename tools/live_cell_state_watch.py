#!/usr/bin/env python3
"""Read-only Phase 2A.5 watcher for current DTO and rendered Dot state.

Start this observer in the lobby.  It inventories already-retained combat
batches first, then treats only objects first observed after the live Board
appears as current-match candidates.  No target methods are invoked.
"""

from __future__ import annotations

import argparse
import json
from pathlib import Path
import struct
import sys
import time
from typing import Any, Iterable, Sequence


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.il2cpp_external import (  # noqa: E402
    ACTIVE_SINGLETON,
    BOARD_SINGLETON,
    BOARD_WS_APPLIER_TYPE_INFO_RVA,
    CARD_UI_TYPE_INFO_RVA,
    DOT_TYPE_INFO_RVA,
    MATCH_SERVICE_PENDING_COMBAT_OFFSET,
    MATCH_SERVICE_SINGLETON,
    MATCH_SERVICE_TURN_NUMBER_OFFSET,
    WS_COMBAT_BATCH_TYPE_INFO_RVA,
    ExternalReadError,
    is_canonical_user_pointer,
)
from pokiguard_v2.combat_cards import (  # noqa: E402
    CombatCardState,
    FusionState,
    read_fusion_state,
    validate_combat_card_hits,
)
from pokiguard_v2.il2cpp_layout import (  # noqa: E402
    CombatBatchSnapshot,
    LayoutValidationError,
    all_dots_index,
    observe_rectangular_reference_array,
    read_combat_batch,
)
from pokiguard_v2.live_state import (  # noqa: E402
    EVIDENCED_MULTIPLIERS,
    StableSnapshotGate,
    board_state_hash,
    gem_for_tag,
    multiplier_distribution,
    to_board_state,
)
from pokiguard_v2.memory_scan import (  # noqa: E402
    DotCandidateResult,
    bounded_private_writable_regions,
    scan_aligned_qwords,
    validate_combat_batch_hits,
    validate_dot_pointer_hits,
)
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    BoardWsObservation,
    batch_identity,
    batch_semantics_valid,
    dot_crosscheck as production_dot_crosscheck,
    read_board_ws_candidate,
    read_pending_queue,
)
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.runtime_common import (  # noqa: E402
    attach_target,
    default_log_path,
    hex_pointer,
    utc_timestamp,
)


def write_event(log_file: Any, event: str, **payload: Any) -> dict[str, Any]:
    value = {"timestamp": utc_timestamp(), "event": event, **payload}
    log_file.write(json.dumps(value, ensure_ascii=False, separators=(",", ":")) + "\n")
    return value


def cell_payload(
    batch: CombatBatchSnapshot,
    dots: DotCandidateResult | None = None,
) -> list[dict[str, Any]]:
    values: list[dict[str, Any]] = []
    for cell in batch.cells:
        candidates = dots.by_coordinate.get((cell.row, cell.col), ()) if dots else ()
        dot = candidates[0] if len(candidates) == 1 else None
        gem = gem_for_tag(cell.tag)
        values.append(
            {
                "row": cell.row,
                "col": cell.col,
                "tag": cell.tag,
                "gem": gem.name,
                "multiplierRaw": cell.multiplier,
                "multiplier": (
                    cell.multiplier
                    if cell.multiplier in EVIDENCED_MULTIPLIERS
                    else None
                ),
                "dto": hex_pointer(cell.address),
                "dot": hex_pointer(dot.address) if dot else None,
                "dotMultiplier": dot.multiplier if dot else None,
            }
        )
    return values


def dot_crosscheck(
    batch: CombatBatchSnapshot,
    dots: DotCandidateResult,
) -> dict[str, Any]:
    check = production_dot_crosscheck(batch, dots)
    mismatches = [
        {"row": row, "col": col, "dto": dto, "dot": dot}
        for row, col, dto, dot in check.mismatches
    ]
    missing = [list(value) for value in check.missing]
    ambiguous = [list(value) for value in check.ambiguous]
    return {
        "matches": check.matches,
        "mismatches": mismatches,
        "mismatchCount": len(mismatches),
        "missing": missing,
        "missingCount": len(missing),
        "ambiguous": ambiguous,
        "ambiguousCount": len(ambiguous),
    }


def resolve_board(target: Any) -> Any | None:
    board_resolution = target.resolver.resolve_singleton(BOARD_SINGLETON)
    if not board_resolution.resolved or board_resolution.instance is None:
        return None
    active_resolution = target.resolver.resolve_singleton(ACTIVE_SINGLETON)
    active = active_resolution.instance if active_resolution.resolved else None
    board = target.resolver.read_board(board_resolution.instance, active)
    return board if board.accepted else None


def resolve_match_service(target: Any) -> int | None:
    value = target.resolver.resolve_singleton(MATCH_SERVICE_SINGLETON)
    return value.instance if value.resolved else None


def read_turn_and_pending(target: Any, match_service: int | None) -> tuple[int | None, int | None]:
    if match_service is None:
        return None, None
    raw = target.memory.read(match_service + MATCH_SERVICE_TURN_NUMBER_OFFSET, 4)
    turn = struct.unpack("<i", raw)[0]
    pending = struct.unpack(
        "<Q",
        target.memory.read(match_service + MATCH_SERVICE_PENDING_COMBAT_OFFSET, 8),
    )[0]
    return turn, pending if is_canonical_user_pointer(pending) else None


def fusion_payload(state: FusionState) -> dict[str, Any]:
    return {
        "matchService": hex_pointer(state.match_service),
        "turnNumber": state.turn_number,
        "enabled": state.enabled,
        "manaCost": state.mana_cost,
        "statPercent": state.stat_percent,
        "usedSuccessfully": state.used_successfully,
        "lastAttemptTurn": state.last_attempt_turn,
        "lockedThisTurn": state.locked_this_turn,
        "candidateAvailable": state.candidate_available,
        "selectedUserPetId": state.selected_user_pet_id,
        "selectedPetId": state.selected_pet_id,
        "skillCard": hex_pointer(state.skill_card),
    }


def combat_card_payload(state: CombatCardState) -> dict[str, Any]:
    return {
        "object": hex_pointer(state.address),
        "cardData": hex_pointer(state.card_data),
        "cardId": state.card_id,
        "dataId": state.data_id,
        "name": state.name,
        "elementTypeCard": state.element_type,
        "skillType": state.skill_type,
        "isAttackCard": state.is_attack_card,
        "manaCost": state.mana_cost,
        "powerCost": state.power_cost,
        "cooldownTurns": state.cooldown_turns,
        "needPerfection": state.need_perfection,
        "uiInteractable": state.ui_interactable,
        "hasUsedThisMatch": state.has_used_this_match,
        "hasUsedThisTurn": state.has_used_this_turn,
        "lastTurnUsed": state.last_turn_used,
        "actionPending": state.action_pending,
        "isPlaceholder": state.is_placeholder,
    }


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(
        description="Watch current 8x8 BoardCellDTO + multiplier state read-only"
    )
    parser.add_argument(
        "--watch", action="store_true", help="wait through a complete Board lifecycle"
    )
    parser.add_argument("--log", type=Path, help="JSONL output path")
    parser.add_argument("--scan-interval", type=float, default=0.35)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument("--timeout", type=float, default=0.0)
    return parser


def run(args: argparse.Namespace) -> int:
    if not 0.1 <= args.scan_interval <= 5.0:
        raise ValueError("--scan-interval must be between 0.1 and 5 seconds")
    if not 1 <= args.max_region_mib <= 32 or not 1 <= args.chunk_mib <= 16:
        raise ValueError("scan size arguments are outside their safe bounds")
    if args.timeout < 0:
        raise ValueError("--timeout cannot be negative")
    log_path = (args.log or default_log_path("live_cell_state")).resolve()
    log_path.parent.mkdir(parents=True, exist_ok=True)

    with attach_target() as target, log_path.open(
        "a", encoding="utf-8", buffering=1
    ) as log_file:
        started = time.monotonic()
        batch_class = target.resolver.resolve_type_info_class(
            WS_COMBAT_BATCH_TYPE_INFO_RVA
        )
        dot_class = target.resolver.resolve_type_info_class(DOT_TYPE_INFO_RVA)
        board_ws_class = target.resolver.resolve_type_info_class(
            BOARD_WS_APPLIER_TYPE_INFO_RVA
        )
        card_ui_class = target.resolver.resolve_type_info_class(CARD_UI_TYPE_INFO_RVA)
        if batch_class is None or dot_class is None or board_ws_class is None:
            raise LayoutValidationError(
                "required type-info is uninitialized; run once after reaching the lobby"
            )

        def scan_regions() -> tuple[Any, ...]:
            return bounded_private_writable_regions(
                target.memory.iter_readable_regions(),
                max_region_size=args.max_region_mib * 1024 * 1024,
            )

        baseline_regions = scan_regions()
        baseline_scan = scan_aligned_qwords(
            target.memory,
            baseline_regions,
            {"batch": batch_class},
            chunk_size=args.chunk_mib * 1024 * 1024,
        )
        baseline_batches = validate_combat_batch_hits(
            target.memory,
            baseline_scan.matches["batch"],
            batch_class=batch_class,
        )
        baseline = {batch_identity(batch) for batch in baseline_batches}
        write_event(
            log_file,
            "watch_started",
            pid=target.pid,
            architecture=target.architecture,
            gameassemblyBase=hex_pointer(target.game_assembly.base),
            gameassemblySize=target.game_assembly.size,
            access=["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"],
            scanEnvelope={
                "memoryType": "MEM_PRIVATE",
                "writableOnly": True,
                "maxRegionMiB": args.max_region_mib,
                "regions": len(baseline_regions),
                "bytes": sum(region.size for region in baseline_regions),
            },
            combatCardDetection={
                "cardUITypeInitialized": card_ui_class is not None,
                "fusionDirectMatchServiceFields": True,
            },
        )
        write_event(
            log_file,
            "lobby_baseline",
            candidates=len(baseline_batches),
            batches=[
                {
                    "object": hex_pointer(batch.address),
                    "srvSeq": batch.sequence,
                    "hash": board_state_hash(batch.cells),
                }
                for batch in baseline_batches
            ],
        )
        print(f"Watcher ready (read-only), PID {target.pid}; log: {log_path}")
        print("Lobby baseline complete. Enter combat and start V1 now.", flush=True)

        scan_number = 0
        current_board: int | None = None
        board_started_scan = 0
        latest_identity: tuple[int, int, str] | None = None
        tracked: dict[tuple[int, int, str], CombatBatchSnapshot] = {}
        first_seen: dict[tuple[int, int, str], int] = {}
        sources: dict[tuple[int, int, str], set[str]] = {}
        gate = StableSnapshotGate(2)
        published_hashes: set[str] = set()
        transition_hashes: list[str] = []
        best_checks: dict[str, dict[str, Any]] = {}
        board_ws_owner: BoardWsObservation | None = None
        last_fusion: FusionState | None = None
        previous_cards: dict[int, CombatCardState] = {}
        saw_board = False
        lost_at: float | None = None

        def register(batch: CombatBatchSnapshot, source: str) -> tuple[int, int, str]:
            identity = batch_identity(batch)
            tracked[identity] = batch
            first_seen.setdefault(identity, scan_number)
            sources.setdefault(identity, set()).add(source)
            return identity

        while target.is_running():
            if args.timeout and time.monotonic() - started >= args.timeout:
                write_event(log_file, "watch_timeout", board=hex_pointer(current_board))
                break
            try:
                board = resolve_board(target)
            except (ExternalReadError, OSError, LayoutValidationError) as exc:
                write_event(log_file, "board_read_error", detail=str(exc))
                board = None

            if board is None:
                if current_board is not None:
                    if lost_at is None:
                        lost_at = time.monotonic()
                        write_event(log_file, "board_lost", board=hex_pointer(current_board))
                    elif time.monotonic() - lost_at >= 1.5:
                        break
                time.sleep(0.1)
                continue

            lost_at = None
            saw_board = True
            if current_board != board.board_instance:
                current_board = board.board_instance
                board_started_scan = scan_number + 1
                latest_identity = None
                board_ws_owner = None
                last_fusion = None
                previous_cards = {}
                gate = StableSnapshotGate(2)
                write_event(
                    log_file,
                    "board_found",
                    board=hex_pointer(current_board),
                    allDots=hex_pointer(board.all_dots),
                    ready=board.is_board_ready,
                    cascade=board.is_cascade_running,
                    currentnessBoundary="first Board.Instance after lobby baseline",
                )
                print(f"Live Board found: {hex_pointer(current_board)}", flush=True)

            scan_number += 1
            if card_ui_class is None:
                card_ui_class = target.resolver.resolve_type_info_class(
                    CARD_UI_TYPE_INFO_RVA
                )
                if card_ui_class is not None:
                    write_event(
                        log_file,
                        "combat_card_detection_ready",
                        cardUIClass=hex_pointer(card_ui_class),
                        typeInfoRva=f"0x{CARD_UI_TYPE_INFO_RVA:X}",
                    )
            match_service = resolve_match_service(target)
            try:
                turn_number, pending = read_turn_and_pending(target, match_service)
            except (ExternalReadError, OSError):
                turn_number, pending = None, None
            if match_service is not None:
                try:
                    fusion = read_fusion_state(target.memory, match_service)
                    if fusion != last_fusion:
                        write_event(
                            log_file,
                            "fusion_state",
                            board=hex_pointer(current_board),
                            **fusion_payload(fusion),
                        )
                        if (
                            last_fusion is not None
                            and not last_fusion.used_successfully
                            and fusion.used_successfully
                        ):
                            write_event(
                                log_file,
                                "fusion_success",
                                board=hex_pointer(current_board),
                                evidence="MatchService.LocalFusionUsed",
                                **fusion_payload(fusion),
                            )
                        last_fusion = fusion
                except (ExternalReadError, OSError, LayoutValidationError):
                    pass
            if pending is not None:
                try:
                    pending_batch = read_combat_batch(
                        target.memory, pending, expected_class=batch_class
                    )
                    identity = register(pending_batch, "MatchService.PendingCombat")
                    write_event(
                        log_file,
                        "pending_combat_observed",
                        object=hex_pointer(pending),
                        srvSeq=pending_batch.sequence,
                        hash=identity[2],
                    )
                except (ExternalReadError, OSError, LayoutValidationError):
                    pass

            try:
                array_before = observe_rectangular_reference_array(
                    target.memory, board.all_dots, (8, 8)
                )
            except (ExternalReadError, OSError, LayoutValidationError):
                array_before = None

            regions = scan_regions()
            scan_needles = {
                "batch": batch_class,
                "board": current_board,
                "board_ws": board_ws_class,
            }
            if card_ui_class is not None:
                scan_needles["card_ui"] = card_ui_class
            scan = scan_aligned_qwords(
                target.memory,
                regions,
                scan_needles,
                chunk_size=args.chunk_mib * 1024 * 1024,
            )
            batches = validate_combat_batch_hits(
                target.memory, scan.matches["batch"], batch_class=batch_class
            )
            current_scan_identities: set[tuple[int, int, str]] = set()
            for candidate in batches:
                identity = register(candidate, "bounded_candidate_scan")
                current_scan_identities.add(identity)

            dots = validate_dot_pointer_hits(
                target.memory,
                scan.matches["board"],
                board_pointer=current_board,
                dot_class=dot_class,
            )

            if card_ui_class is not None and board.active is not None:
                cards = validate_combat_card_hits(
                    target.memory,
                    scan.matches["card_ui"],
                    expected_class=card_ui_class,
                    expected_board=current_board,
                    expected_active=board.active,
                )
                cards_by_id = {card.card_id: card for card in cards}
                if cards_by_id != previous_cards:
                    write_event(
                        log_file,
                        "combat_card_state",
                        board=hex_pointer(current_board),
                        turnNumber=turn_number,
                        cards=[combat_card_payload(card) for card in cards],
                    )
                    for card_id, card in cards_by_id.items():
                        prior = previous_cards.get(card_id)
                        if prior is None:
                            continue
                        use_changed = (
                            card.last_turn_used != prior.last_turn_used
                            or (
                                not prior.has_used_this_turn
                                and card.has_used_this_turn
                            )
                            or (
                                not prior.has_used_this_match
                                and card.has_used_this_match
                            )
                        )
                        if use_changed:
                            write_event(
                                log_file,
                                "combat_card_use_observed",
                                board=hex_pointer(current_board),
                                turnNumber=turn_number,
                                evidence=(
                                    "CardUI optimistic state; server reject calls "
                                    "RevertOptimisticUse"
                                ),
                                card=combat_card_payload(card),
                            )
                    previous_cards = cards_by_id

            for address in scan.matches["board_ws"]:
                try:
                    candidate = read_board_ws_candidate(
                        target.memory,
                        address,
                        expected_class=board_ws_class,
                        expected_board=current_board,
                    )
                    board_ws_owner = candidate
                    queue = read_pending_queue(target.memory, candidate.queue)
                    for batch_address in queue.batch_addresses:
                        queued = read_combat_batch(
                            target.memory,
                            batch_address,
                            expected_class=batch_class,
                        )
                        identity = register(queued, "BoardWsApplier._pendingBatches")
                        current_scan_identities.add(identity)
                    write_event(
                        log_file,
                        "board_ws_owner",
                        object=hex_pointer(candidate.address),
                        board=hex_pointer(current_board),
                        queue=hex_pointer(candidate.queue),
                        queueSize=queue.size,
                        queueVersion=queue.version,
                        renderRunning=candidate.render_running,
                    )
                    break
                except (ExternalReadError, OSError, LayoutValidationError):
                    continue

            eligible = [
                identity
                for identity in current_scan_identities
                if identity not in baseline
                and first_seen.get(identity, 0) >= board_started_scan
                and batch_semantics_valid(tracked[identity])
            ]
            newly_seen = [
                identity for identity in eligible if first_seen[identity] == scan_number
            ]
            if newly_seen:
                selected = max(newly_seen, key=lambda value: (value[1], value[0]))
                if latest_identity != selected:
                    latest_identity = selected
                    batch = tracked[selected]
                    if selected[2] not in transition_hashes:
                        transition_hashes.append(selected[2])
                    write_event(
                        log_file,
                        "server_snapshot",
                        board=hex_pointer(current_board),
                        object=hex_pointer(batch.address),
                        srvSeq=batch.sequence,
                        turnNumber=turn_number,
                        hash=selected[2],
                        source=sorted(sources[selected]),
                        currentness={
                            "notInLobbyBaseline": True,
                            "firstSeenScan": first_seen[selected],
                            "boardStartScan": board_started_scan,
                            "transitionIndex": len(transition_hashes) - 1,
                        },
                        multiplierRawDistribution={
                            str(key): value
                            for key, value in multiplier_distribution(batch.cells).items()
                        },
                        cells=cell_payload(batch),
                    )
                    print(
                        f"Server snapshot seq={batch.sequence} hash={selected[2][:12]} "
                        f"transition={len(transition_hashes)}",
                        flush=True,
                    )

            try:
                board_after = resolve_board(target)
                array_after = (
                    observe_rectangular_reference_array(
                        target.memory, board_after.all_dots, (8, 8)
                    )
                    if board_after is not None
                    and board_after.board_instance == current_board
                    else None
                )
            except (ExternalReadError, OSError, LayoutValidationError):
                board_after = None
                array_after = None

            if latest_identity is not None:
                batch = tracked[latest_identity]
                check = dot_crosscheck(batch, dots)
                array_stable = bool(
                    array_before is not None
                    and array_after is not None
                    and array_before.layout_verified
                    and array_after.layout_verified
                    and array_before.elements == array_after.elements
                )
                flags_stable = bool(
                    board_after is not None
                    and board.is_board_ready
                    and board_after.is_board_ready
                    and not board.is_cascade_running
                    and not board_after.is_cascade_running
                )
                model_valid = True
                try:
                    model = to_board_state(batch.cells)
                except ValueError:
                    model_valid = False
                    model = None
                signals_valid = bool(
                    flags_stable
                    and array_stable
                    and model_valid
                    and len(dots.by_coordinate) == 64
                    and not dots.duplicate_coordinates
                    and check["matches"] == 64
                    and check["mismatchCount"] == 0
                    and check["missingCount"] == 0
                    and check["ambiguousCount"] == 0
                )
                stable, confirmations = gate.observe(
                    (latest_identity[2], latest_identity[1]), signals_valid
                )
                write_event(
                    log_file,
                    "render_crosscheck",
                    board=hex_pointer(current_board),
                    srvSeq=batch.sequence,
                    turnNumber=turn_number,
                    hash=latest_identity[2],
                    readyBefore=board.is_board_ready,
                    readyAfter=board_after.is_board_ready if board_after else None,
                    cascadeBefore=board.is_cascade_running,
                    cascadeAfter=(
                        board_after.is_cascade_running if board_after else None
                    ),
                    arrayStableAcrossScan=array_stable,
                    dotCandidates=len(dots.candidates),
                    uniqueDotCoordinates=len(dots.by_coordinate),
                    **check,
                    stableSignals=signals_valid,
                    consecutiveConfirmations=confirmations,
                    published=stable,
                )
                previous = best_checks.get(latest_identity[2])
                if previous is None or check["matches"] > previous["matches"]:
                    best_checks[latest_identity[2]] = dict(check)
                if stable and latest_identity[2] not in published_hashes and model is not None:
                    published_hashes.add(latest_identity[2])
                    elements = array_after.elements if array_after else ()
                    write_event(
                        log_file,
                        "board_snapshot",
                        board=hex_pointer(current_board),
                        srvSeq=batch.sequence,
                        turnNumber=turn_number,
                        hash=latest_identity[2],
                        ready=True,
                        cascade=False,
                        source=sorted(sources[latest_identity]),
                        stabilityCriteria={
                            "boardInstanceActive": True,
                            "dimensions": "8x8",
                            "readyAcrossScan": True,
                            "cascadeFalseAcrossScan": True,
                            "allDotsStableAcrossScan": True,
                            "dtoCells": 64,
                            "knownGemTypes": 64,
                            "dtoDotMultiplierMatches": 64,
                            "consecutiveConfirmations": confirmations,
                        },
                        cells=[
                            {
                                **value,
                                "gameObject": hex_pointer(
                                    elements[all_dots_index(value["col"], value["row"])]
                                )
                                if elements
                                else None,
                            }
                            for value in cell_payload(batch, dots)
                        ],
                        board8x8=[
                            [
                                {
                                    "gem": model.cells[row][col].gem_type.name,
                                    "multiplier": model.cells[row][col].multiplier,
                                }
                                for col in range(8)
                            ]
                            for row in range(8)
                        ],
                    )
                    print(
                        f"STABLE publish seq={batch.sequence}: 64/64 DTO<->Dot multipliers",
                        flush=True,
                    )

            time.sleep(args.scan_interval)

        total_matches = sum(value["matches"] for value in best_checks.values())
        total_mismatches = sum(value["mismatchCount"] for value in best_checks.values())
        total_missing = sum(value["missingCount"] for value in best_checks.values())
        write_event(
            log_file,
            "watch_summary",
            board=hex_pointer(current_board),
            sawBoard=saw_board,
            currentTransitions=len(transition_hashes),
            stablePublished=len(published_hashes),
            crosscheckBestPerTransition={
                "matches": total_matches,
                "mismatches": total_mismatches,
                "missing": total_missing,
            },
            hashes=transition_hashes,
        )
        print(
            f"Watcher stopped: transitions={len(transition_hashes)}, "
            f"stable={len(published_hashes)}; log: {log_path}",
            flush=True,
        )
        return 0 if published_hashes else 2


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
