#!/usr/bin/env python3
"""Read-only dead-board, timer and Fusion diagnostic watcher (NO INPUT)."""

from __future__ import annotations

import argparse
from dataclasses import asdict, replace
import json
from pathlib import Path
import sys
import time
from typing import Any, Iterable, Sequence


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.board_diagnostics import (  # noqa: E402
    analyze_game_state,
    classify_move_timing,
    jsonable,
    write_diagnostic_artifact,
)
from pokiguard_v2.combat_cards import validate_fusion_card_ui_hits  # noqa: E402
from pokiguard_v2.combat_lifecycle import (  # noqa: E402
    CombatLifecycleState,
    CombatSessionTracker,
    read_combat_lifecycle,
)
from pokiguard_v2.fusion_diagnostics import (  # noqa: E402
    FusionAttemptTracker,
    FusionResponse,
    FusionRuntimeSnapshot,
)
from pokiguard_v2.game_owned_idle import (  # noqa: E402
    AcceptedActivityKind,
    GameOwnedIdleCache,
    IdleFreshness,
)
from pokiguard_v2.il2cpp_external import (  # noqa: E402
    ACTIVE_PLAYER_STATS_TYPE_INFO_RVA,
    FUSION_CARD_UI_TYPE_INFO_RVA,
    ExternalReadError,
)
from pokiguard_v2.il2cpp_layout import LayoutValidationError  # noqa: E402
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
    ProviderSetupError,
)
from pokiguard_v2.memory_scan import (  # noqa: E402
    regions_containing_addresses,
    scan_aligned_qwords,
)
from pokiguard_v2.state import GamePhase  # noqa: E402
from pokiguard_v2.sequence_desync import (  # noqa: E402
    SequenceDesyncTracker,
    SequenceEventRing,
    SequenceRootTelemetry,
    classify_sequence_signal,
)
from pokiguard_v2.sequence_desync_artifacts import (  # noqa: E402
    write_sequence_desync_artifact,
)
from pokiguard_v2.win32_screenshot import capture_client_png  # noqa: E402
from tools.idle_state_watch import (  # noqa: E402
    CHAT_MESSAGE_DTO_TYPE_INFO_RVA,
    MatchRuntime,
    ServerMessage,
    _read_board_observation,
    _read_participants,
    _regions,
    read_match_runtime,
    read_server_message,
)
from tools.lifecycle_idle_watch import (  # noqa: E402
    ACTION_RESPONSES,
    _message_actor,
    _message_identity,
    _message_rejected,
    _message_sort_key,
    _session_id,
    _utc_timestamp,
)
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.runtime_common import attach_target, default_log_path, hex_pointer  # noqa: E402


def _write(log: Any, event: str, **fields: Any) -> None:
    log.write(
        json.dumps(
            jsonable({"timestamp": _utc_timestamp(), "event": event, **fields}),
            ensure_ascii=False,
            separators=(",", ":"),
        )
        + "\n"
    )
    log.flush()


def _response_success(message: ServerMessage) -> bool | None:
    bools = dict(message.payload_bools)
    if _message_rejected(message):
        return False
    if bools.get("success") is True or bools.get("accepted") is True:
        return True
    if message.event_type == "MATCH_FUSION_RES":
        return None
    return True


def _response_reason(message: ServerMessage) -> str | None:
    strings = dict(message.payload_strings)
    return (
        message.reject_reason
        or strings.get("reason")
        or strings.get("error")
        or strings.get("message")
    )


def _response_code(message: ServerMessage) -> str | int | None:
    ints = dict(message.payload_ints)
    strings = dict(message.payload_strings)
    return (
        ints.get("errorCode")
        or ints.get("code")
        or strings.get("errorCode")
        or strings.get("code")
    )


def _local_turn(runtime: MatchRuntime, lifecycle: CombatLifecycleState) -> bool:
    return bool(
        lifecycle is CombatLifecycleState.ACTIVE
        and runtime.local_username
        and runtime.current_player
        and runtime.local_username.casefold() == runtime.current_player.casefold()
    )


def _fusion_snapshot(
    *,
    session_id: str,
    runtime: MatchRuntime,
    player: Any,
    fusion: Any,
    fusion_ui: Any,
    idle_cache: GameOwnedIdleCache,
) -> FusionRuntimeSnapshot:
    idle = idle_cache.state
    exact_idle = bool(
        idle is not None
        and idle.session_id == session_id
        and idle.freshness is IdleFreshness.EXACT_SERVER_EVENT
    )
    return FusionRuntimeSnapshot(
        session_id=session_id,
        timestamp=_utc_timestamp(),
        mana=player.mana if player is not None else None,
        current_turn_player=runtime.current_player,
        local_username=runtime.local_username,
        turn_number=runtime.turn,
        turn_remaining=runtime.remaining,
        idle_count=idle.idle_count if exact_idle and idle is not None else None,
        idle_threshold=idle.threshold if exact_idle and idle is not None else None,
        idle_authoritative=exact_idle,
        fusion=fusion,
        ui_interactable=(fusion_ui.interactable if fusion_ui is not None else None),
        ui_address=(fusion_ui.address if fusion_ui is not None else None),
    )


def _state_with_authoritative_idle(state: Any, idle_cache: GameOwnedIdleCache) -> Any:
    idle = idle_cache.state
    session_id = _session_id(state.battle.session_key)
    if (
        idle is None
        or session_id is None
        or idle.session_id != session_id
        or idle.freshness is not IdleFreshness.EXACT_SERVER_EVENT
    ):
        return state
    return replace(
        state,
        battle=replace(
            state.battle,
            consecutive_passes=idle.idle_count,
            consecutive_pass_threshold=idle.threshold,
            consecutive_pass_source=(
                f"{idle.source_message_type}@{idle.observed_timestamp}"
            ),
        ),
    )


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--watch", action="store_true")
    parser.add_argument("--log", type=Path)
    parser.add_argument(
        "--artifact-root", type=Path, default=PROJECT_ROOT / "logs" / "dead_board"
    )
    parser.add_argument(
        "--sequence-artifact-root",
        type=Path,
        default=PROJECT_ROOT / "logs" / "sequence_desync",
    )
    parser.add_argument("--interval", type=float, default=0.15)
    parser.add_argument("--full-rescan-interval", type=int, default=8)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument("--matches", type=int, default=1)
    parser.add_argument("--timeout", type=float, default=0.0)
    parser.add_argument("--no-screenshot", action="store_true")
    parser.add_argument(
        "--allow-combat-start",
        action="store_true",
        help="recovery diagnostics only; a lobby start remains required by default",
    )
    return parser


def run(args: argparse.Namespace) -> int:
    if not args.watch:
        raise ValueError("start the diagnostic watcher with --watch")
    if not 0.05 <= args.interval <= 5:
        raise ValueError("--interval must be between 0.05 and 5 seconds")
    if args.matches < 0 or args.timeout < 0:
        raise ValueError("matches/timeout cannot be negative")

    log_path = (args.log or default_log_path("combat_diagnostic_watch")).resolve()
    artifact_root = args.artifact_root.resolve()
    sequence_artifact_root = args.sequence_artifact_root.resolve()
    log_path.parent.mkdir(parents=True, exist_ok=True)
    artifact_root.mkdir(parents=True, exist_ok=True)
    sequence_artifact_root.mkdir(parents=True, exist_ok=True)

    with attach_target() as target, log_path.open(
        "a", encoding="utf-8", buffering=1
    ) as log:
        provider = MemoryBoardStateProvider(
            target,
            MemoryProviderConfig(
                max_region_mib=args.max_region_mib,
                chunk_mib=args.chunk_mib,
                full_rescan_interval=max(args.full_rescan_interval, 2),
                require_lobby_start=not args.allow_combat_start,
            ),
        )
        dto_class = target.resolver.resolve_type_info_class(
            CHAT_MESSAGE_DTO_TYPE_INFO_RVA
        )
        fusion_ui_class = target.resolver.resolve_type_info_class(
            FUSION_CARD_UI_TYPE_INFO_RVA
        )
        stats_class = target.resolver.resolve_type_info_class(
            ACTIVE_PLAYER_STATS_TYPE_INFO_RVA
        )
        lifecycle_sessions = CombatSessionTracker()
        idle_cache = GameOwnedIdleCache()
        fusion_tracker = FusionAttemptTracker()
        sequence_tracker = SequenceDesyncTracker()
        sequence_events = SequenceEventRing(50)
        learned_regions: set[Any] = set()
        seen_messages: set[tuple[Any, ...]] = set()
        logged_fusion_signatures: set[tuple[Any, ...]] = set()
        analyzed_states: set[tuple[Any, ...]] = set()
        artifact_states: set[tuple[Any, ...]] = set()
        previous_lifecycle: tuple[Any, ...] | None = None
        previous_session: str | None = None
        previous_runtime: MatchRuntime | None = None
        previous_local_turn = False
        turn_attempted = False
        turn_start_move_sequence: int | None = None
        last_analysis: Any = None
        last_analysis_key: tuple[Any, ...] | None = None
        last_local_remaining: int | None = None
        pending_move: dict[str, Any] | None = None
        previous_ui_signature: tuple[Any, ...] | None = None
        completed = 0
        active_seen = False
        last_stable_state = None
        scans = 0
        started = time.monotonic()

        _write(
            log,
            "combat_diagnostic_watch_started",
            pid=target.pid,
            architecture=target.architecture,
            gameassemblyBase=hex_pointer(target.game_assembly.base),
            access=["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"],
            noInput=True,
            noAutonomousActions=True,
            artifactRoot=str(artifact_root),
            sequenceArtifactRoot=str(sequence_artifact_root),
            screenshotEnabled=not args.no_screenshot,
            deadBoardDefinition=(
                "ACTIVE && localTurn && stable/current && 64 valid cells "
                "&& exhaustiveLegalMoves==0"
            ),
        )
        print(f"Combat diagnostic watcher ready (READ-ONLY), log: {log_path}", flush=True)

        while target.is_running():
            if args.timeout and time.monotonic() - started >= args.timeout:
                break
            try:
                poll = provider.poll()
            except (ExternalReadError, OSError, LayoutValidationError, RuntimeError) as exc:
                poll = None
                _write(log, "provider_poll_error", detail=str(exc))
            if poll is not None and poll.state is not None:
                last_stable_state = poll.state
            try:
                _match_service, runtime = read_match_runtime(target)
            except (ExternalReadError, OSError, LayoutValidationError) as exc:
                runtime = MatchRuntime(
                    None, None, None, None, None, None, None,
                    None, None, None, None, None,
                )
                _write(log, "runtime_read_error", detail=str(exc))

            _board_instance, board_observation = _read_board_observation(target)
            provider_lifecycle = poll.combat_lifecycle if poll is not None else None
            observation = read_combat_lifecycle(
                target.resolver,
                board=(
                    board_observation
                    if board_observation is not None and board_observation.accepted
                    else None
                ),
                match_id=runtime.match_id,
                match_over=(
                    provider_lifecycle.signals.match_over
                    if provider_lifecycle is not None
                    else None
                ),
                deferred_game_over=(
                    provider_lifecycle.signals.deferred_game_over
                    if provider_lifecycle is not None
                    else None
                ),
            )
            lifecycle = observation.state
            session = lifecycle_sessions.observe(
                lifecycle,
                observation.signals.board_instance,
                observation.signals.match_id,
            )
            session_id = _session_id(session)
            if stats_class is None:
                stats_class = target.resolver.resolve_type_info_class(
                    ACTIVE_PLAYER_STATS_TYPE_INFO_RVA
                )
            participants = _read_participants(target, board_observation, stats_class)
            player = next((item for item in participants if item.is_local is True), None)
            boss = next((item for item in participants if item.is_boss is True), None)

            lifecycle_signature = (
                lifecycle,
                observation.reason,
                session_id,
                observation.signals.board_instance,
                observation.signals.match_id,
            )
            if lifecycle_signature != previous_lifecycle:
                _write(
                    log,
                    "combat_lifecycle_changed",
                    lifecycle=lifecycle,
                    reason=observation.reason,
                    session=session_id,
                    signals=observation.signals,
                    turn=runtime.turn,
                    currentTurnPlayer=runtime.current_player,
                    remaining=runtime.remaining,
                )
                previous_lifecycle = lifecycle_signature
                sequence_events.append(
                    {
                        "timestamp": _utc_timestamp(),
                        "event": "combat_lifecycle_changed",
                        "lifecycle": lifecycle.value,
                        "session": session_id,
                        "matchId": runtime.match_id,
                        "turn": runtime.turn,
                    }
                )

            if lifecycle is CombatLifecycleState.ACTIVE and session_id is not None:
                active_seen = True
                if session_id != previous_session:
                    idle_cache.begin_session(session_id)
                    fusion_tracker.begin_session(session_id)
                    seen_messages.clear()
                    analyzed_states.clear()
                    artifact_states.clear()
                    last_analysis = None
                    last_analysis_key = None
                    previous_local_turn = False
                    previous_runtime = None
                    turn_attempted = False
                    last_local_remaining = None
                    pending_move = None
                    last_stable_state = poll.state if poll is not None else None
                    sequence_events = SequenceEventRing(50)
                    if not sequence_tracker.begin_session(
                        session_id,
                        runtime.match_id or "",
                        clean=True,
                    ):
                        _write(
                            log,
                            "sequence_session_start_blocked",
                            session=session_id,
                            reason="old_session_not_ended_or_new_session_not_clean",
                        )
                    _write(log, "combat_session_started", session=session_id)
                previous_session = session_id
            else:
                if previous_session is not None:
                    sequence_tracker.end_session(previous_session)
                    for record in fusion_tracker.records:
                        if record.session_id == previous_session:
                            _write(log, "fusion_attempt_final", attempt=record.payload())
                    idle_cache.clear(f"lifecycle:{lifecycle.value}")
                    fusion_tracker.end_session()
                    _write(
                        log,
                        "combat_session_invalidated",
                        session=previous_session,
                        lifecycle=lifecycle,
                    )
                    previous_session = None
                    previous_local_turn = False
                    previous_runtime = None
                    turn_attempted = False
                    last_local_remaining = None
                    pending_move = None
                    if active_seen:
                        completed += 1
                        active_seen = False
                if args.matches and completed >= args.matches:
                    break

            local_turn = _local_turn(runtime, lifecycle)
            if local_turn:
                last_local_remaining = runtime.remaining
            if local_turn and not previous_local_turn:
                turn_attempted = False
                turn_start_move_sequence = runtime.last_move_sequence
                _write(
                    log,
                    "local_turn_started",
                    session=session_id,
                    turn=runtime.turn,
                    remaining=runtime.remaining,
                    lastMoveSequence=runtime.last_move_sequence,
                )
            elif previous_local_turn and not local_turn and session_id is not None:
                timing = classify_move_timing(
                    legal_move_count=(
                        last_analysis.legal_match_producing_moves
                        if last_analysis is not None
                        else None
                    ),
                    remaining_seconds=last_local_remaining,
                    attempted=turn_attempted,
                )
                _write(
                    log,
                    "local_turn_timing_outcome",
                    session=session_id,
                    turn=(previous_runtime.turn if previous_runtime else None),
                    classification=timing,
                    legalMoveCount=(
                        last_analysis.legal_match_producing_moves
                        if last_analysis is not None
                        else None
                    ),
                    lastObservedRemaining=last_local_remaining,
                    attempted=turn_attempted,
                    turnStartMoveSequence=turn_start_move_sequence,
                )
            previous_local_turn = local_turn

            if (
                previous_runtime is not None
                and runtime.last_move_sequence is not None
                and runtime.last_move_sequence != previous_runtime.last_move_sequence
                and session_id is not None
            ):
                turn_attempted = True
                timing = classify_move_timing(
                    legal_move_count=(
                        last_analysis.legal_match_producing_moves
                        if last_analysis is not None
                        else None
                    ),
                    remaining_seconds=runtime.remaining,
                    attempted=True,
                )
                pending_move = {
                    "session": session_id,
                    "turn": runtime.turn,
                    "actualMoveTimestamp": _utc_timestamp(),
                    "remainingAtActualMove": runtime.remaining,
                    "lastMoveSequence": runtime.last_move_sequence,
                    "fromRuntime": {
                        "row": runtime.last_move_from_row,
                        "col": runtime.last_move_from_col,
                    },
                    "toRuntime": {
                        "row": runtime.last_move_to_row,
                        "col": runtime.last_move_to_col,
                    },
                    "classificationAtAttempt": timing.value,
                    "legalMoveCount": (
                        last_analysis.legal_match_producing_moves
                        if last_analysis is not None
                        else None
                    ),
                }
                _write(log, "actual_move_detected", **pending_move)
                sequence_events.append(
                    {
                        "timestamp": _utc_timestamp(),
                        "event": "actual_move_detected",
                        **pending_move,
                        "localMoveSequence": runtime.local_move_sequence,
                        "highestAckedSequence": runtime.highest_acked_sequence,
                    }
                )
            previous_runtime = runtime

            messages: list[ServerMessage] = []
            fusion_ui = None
            if (
                lifecycle is CombatLifecycleState.ACTIVE
                and runtime.match_id
                and session_id is not None
            ):
                if dto_class is None:
                    dto_class = target.resolver.resolve_type_info_class(
                        CHAT_MESSAGE_DTO_TYPE_INFO_RVA
                    )
                if fusion_ui_class is None:
                    fusion_ui_class = target.resolver.resolve_type_info_class(
                        FUSION_CARD_UI_TYPE_INFO_RVA
                    )
                labels: dict[str, int] = {}
                if dto_class is not None:
                    labels["chat_message"] = int(dto_class)
                if fusion_ui_class is not None:
                    labels["fusion_ui"] = int(fusion_ui_class)
                if labels:
                    scans += 1
                    all_regions = _regions(target, args.max_region_mib)
                    full = not learned_regions or scans % args.full_rescan_interval == 0
                    selected: Iterable[Any] = (
                        all_regions
                        if full
                        else tuple(sorted(learned_regions, key=lambda region: region.base))
                    )
                    scan = scan_aligned_qwords(
                        target.memory,
                        selected,
                        labels,
                        chunk_size=args.chunk_mib * 1024 * 1024,
                    )
                    for hits in scan.matches.values():
                        learned_regions.update(
                            regions_containing_addresses(all_regions, hits)
                        )
                    if dto_class is not None:
                        for address in scan.matches.get("chat_message", ()):
                            try:
                                message = read_server_message(
                                    target.memory,
                                    address,
                                    expected_class=int(dto_class),
                                    expected_match_id=runtime.match_id,
                                )
                            except (ExternalReadError, OSError, LayoutValidationError):
                                continue
                            identity = _message_identity(message)
                            if identity not in seen_messages:
                                seen_messages.add(identity)
                                messages.append(message)
                    if fusion_ui_class is not None:
                        ui_values = validate_fusion_card_ui_hits(
                            target.memory,
                            scan.matches.get("fusion_ui", ()),
                            expected_class=int(fusion_ui_class),
                        )
                        if len(ui_values) == 1:
                            fusion_ui = ui_values[0]
                        ui_signature = tuple(
                            (item.address, item.button, item.interactable)
                            for item in ui_values
                        )
                        if ui_signature != previous_ui_signature:
                            _write(
                                log,
                                "fusion_ui_state_changed",
                                session=session_id,
                                candidates=ui_values,
                                accepted=(fusion_ui if len(ui_values) == 1 else None),
                                failClosedReason=(
                                    None
                                    if len(ui_values) == 1
                                    else f"expected exactly one live FusionCardUI; got {len(ui_values)}"
                                ),
                            )
                            previous_ui_signature = ui_signature

            ordered_messages = sorted(messages, key=_message_sort_key)
            for message in ordered_messages:
                sequence_events.append(
                    {
                        "timestamp": _utc_timestamp(),
                        "event": "server_match_message",
                        "session": session_id,
                        "turn": runtime.turn,
                        "srvSeq": (
                            poll.state.battle.srv_seq
                            if poll is not None and poll.state is not None
                            else None
                        ),
                        "lastMoveSequence": runtime.last_move_sequence,
                        "localMoveSequence": runtime.local_move_sequence,
                        "highestAckedSequence": runtime.highest_acked_sequence,
                        "message": message,
                    }
                )
                payload_strings = dict(message.payload_strings)
                sequence_signal = classify_sequence_signal(
                    event_type=message.event_type,
                    reject_code=_response_code(message),
                    reject_reason=message.reject_reason,
                    fallback_text=(
                        payload_strings.get("reason")
                        or payload_strings.get("error")
                        or payload_strings.get("message")
                    ),
                )
                first_desync = False
                if session_id is not None and runtime.match_id:
                    first_desync = sequence_tracker.observe(
                        sequence_signal,
                        timestamp=_utc_timestamp(),
                        session_key=session_id,
                        match_id=runtime.match_id,
                        turn=runtime.turn,
                        srv_seq=(
                            poll.state.battle.srv_seq
                            if poll is not None and poll.state is not None
                            else None
                        ),
                        root_telemetry=SequenceRootTelemetry.observed(
                            observed_client_sequence=runtime.local_move_sequence,
                            current_server_sequence=(
                                poll.state.battle.srv_seq
                                if poll is not None and poll.state is not None
                                else None
                            ),
                            highest_acked_sequence=runtime.highest_acked_sequence,
                            last_move_sequence=runtime.last_move_sequence,
                        ),
                    )
                if sequence_signal is not None:
                    _write(
                        log,
                        "sequence_desync_signal",
                        firstDetection=first_desync,
                        signal=sequence_signal,
                        state=sequence_tracker.state,
                        gameplayBlocked=sequence_tracker.state.terminal_for_session,
                        timerTelemetryOnly=True,
                        noRetry=True,
                    )
                if first_desync:
                    _write(
                        log,
                        "recovery_required",
                        reason="SEQUENCE_DESYNC",
                        state=sequence_tracker.state,
                        inputMode="NONE_READ_ONLY_WATCHER",
                        automaticExit=False,
                    )
                    if last_stable_state is None:
                        _write(
                            log,
                            "sequence_desync_artifact_error",
                            detail="no last valid 64-cell board is available",
                        )
                    else:
                        try:
                            artifact = write_sequence_desync_artifact(
                                sequence_artifact_root,
                                desync=sequence_tracker.state,
                                state=last_stable_state,
                                recent_events=sequence_events.snapshot(),
                                screenshot_writer=lambda path: capture_client_png(
                                    target.pid, path
                                ),
                                correlation={
                                    "fusionState": last_stable_state.fusion,
                                    "fusionAttemptsObserved": len(fusion_tracker.records),
                                    "causalConclusion": "UNKNOWN",
                                },
                            )
                            _write(
                                log,
                                "sequence_desync_artifact_saved",
                                directory=str(artifact.directory),
                                stateJson=str(artifact.state_json),
                                boardJson=str(artifact.board_json),
                                screenshot=str(artifact.screenshot),
                                recentEventsJson=str(artifact.recent_events_json),
                            )
                        except (OSError, RuntimeError, ValueError) as exc:
                            _write(
                                log,
                                "sequence_desync_artifact_error",
                                detail=str(exc),
                            )
                authoritative_idle = bool(
                    message.event_type in {"MATCH_AFK_WARN", "MATCH_TURN_END"}
                    and message.username
                    and message.idle_count is not None
                    and message.threshold is not None
                )
                idle_rejection = None
                if authoritative_idle and session_id is not None:
                    try:
                        idle_cache.observe_server_payload(
                            session_id=session_id,
                            username=message.username or "",
                            idle_count=message.idle_count or 0,
                            threshold=message.threshold or 0,
                            source_message_type=message.event_type,
                            source_srv_seq=message.server_sequence,
                            source_turn=message.source_turn,
                            source_timestamp=message.timestamp,
                            observed_timestamp=_utc_timestamp(),
                        )
                        fusion_tracker.observe_authoritative_idle(
                            session_id,
                            message.idle_count or 0,
                            message.threshold or 0,
                        )
                    except ValueError as exc:
                        authoritative_idle = False
                        idle_rejection = str(exc)

                activity_kind = ACTION_RESPONSES.get(message.event_type)
                actor = _message_actor(message)
                is_local_actor = bool(
                    actor
                    and runtime.local_username
                    and actor.casefold() == runtime.local_username.casefold()
                )
                accepted_activity = bool(
                    activity_kind is not None
                    and is_local_actor
                    and not _message_rejected(message)
                )
                if accepted_activity and session_id is not None:
                    idle_cache.observe_accepted_activity(
                        session_id=session_id,
                        kind=activity_kind,
                        source_message_type=message.event_type,
                        source_srv_seq=message.server_sequence,
                        source_turn=message.source_turn,
                        source_timestamp=message.timestamp,
                        observed_timestamp=_utc_timestamp(),
                    )
                    fusion_tracker.observe_activity(session_id, activity_kind.value)

                if message.event_type in {"MATCH_MOVE_RES", "MATCH_REJECT"}:
                    rejected = _message_rejected(message)
                    move_local = is_local_actor or (
                        pending_move is not None
                        and pending_move.get("session") == session_id
                        and actor is None
                    )
                    if move_local and pending_move is not None:
                        classification = classify_move_timing(
                            legal_move_count=pending_move.get("legalMoveCount"),
                            remaining_seconds=pending_move.get("remainingAtActualMove"),
                            attempted=True,
                            accepted=not rejected,
                            reject_reason=_response_reason(message),
                        )
                        _write(
                            log,
                            "actual_move_result",
                            **pending_move,
                            response=message,
                            accepted=not rejected,
                            rejectionReason=_response_reason(message),
                            classification=classification,
                        )
                        pending_move = None

                _write(
                    log,
                    "server_match_message",
                    session=session_id,
                    turn=runtime.turn,
                    currentTurnPlayer=runtime.current_player,
                    message=message,
                    actor=actor,
                    localActor=is_local_actor,
                    authoritativeIdle=authoritative_idle,
                    idlePayloadRejection=idle_rejection,
                    acceptedActivity=(activity_kind if accepted_activity else None),
                    rejected=_message_rejected(message),
                    idleState=idle_cache.state,
                )

            if session_id is not None and lifecycle is CombatLifecycleState.ACTIVE:
                snapshot = _fusion_snapshot(
                    session_id=session_id,
                    runtime=runtime,
                    player=player,
                    fusion=provider.observed_fusion,
                    fusion_ui=fusion_ui,
                    idle_cache=idle_cache,
                )
                for record in fusion_tracker.observe_snapshot(snapshot):
                    signature = (
                        record.attempt_id,
                        bool(record.response),
                        record.retry_allowed,
                        record.mana_delta,
                        record.idle_reset,
                    )
                    if signature not in logged_fusion_signatures:
                        _write(log, "fusion_attempt_state", attempt=record.payload())
                        logged_fusion_signatures.add(signature)
                for message in ordered_messages:
                    if message.event_type != "MATCH_FUSION_RES":
                        continue
                    response_success = _response_success(message)
                    response_actor = _message_actor(message)
                    response_is_local = bool(
                        response_actor
                        and runtime.local_username
                        and response_actor.casefold()
                        == runtime.local_username.casefold()
                    )
                    if response_success is None or not response_is_local:
                        _write(
                            log,
                            "fusion_response_uncorrelated",
                            session=session_id,
                            rawMessage=message,
                            reason=(
                                "missing exact success/accepted boolean"
                                if response_success is None
                                else "response actor is not proven local"
                            ),
                        )
                        continue
                    response = FusionResponse(
                        observed_timestamp=_utc_timestamp(),
                        server_timestamp=message.timestamp,
                        success=response_success,
                        reason=_response_reason(message),
                        code=_response_code(message),
                        message_address=message.address,
                    )
                    record = fusion_tracker.observe_response(response, snapshot)
                    _write(
                        log,
                        "fusion_attempt_response",
                        attempt=record.payload(),
                        rawMessage=message,
                    )

            if (
                poll is not None
                and poll.state is not None
                and poll.state.phase is GamePhase.COMBAT
                and poll.state.battle.stable
                and poll.state.battle.is_local_turn is True
            ):
                diagnostic_state = _state_with_authoritative_idle(
                    poll.state, idle_cache
                )
                key = diagnostic_state.dedup_key
                if key is not None and key not in analyzed_states:
                    state_timestamp = diagnostic_state.timestamp
                    analysis = analyze_game_state(diagnostic_state)
                    try:
                        _service_after, runtime_after = read_match_runtime(target)
                        remaining_at_decision = runtime_after.remaining
                    except (ExternalReadError, OSError, LayoutValidationError):
                        remaining_at_decision = None
                    analyzed_states.add(key)
                    last_analysis = analysis
                    last_analysis_key = key
                    _write(
                        log,
                        "stable_local_board_diagnostic",
                        session=session_id,
                        matchId=diagnostic_state.battle.match_id,
                        srvSeq=diagnostic_state.battle.srv_seq,
                        turn=diagnostic_state.battle.turn_number,
                        currentTurnPlayer=diagnostic_state.battle.current_turn_player,
                        boardInstance=hex_pointer(
                            diagnostic_state.battle.board_instance
                        ),
                        boardHash=diagnostic_state.battle.board_hash,
                        diagnosticBoardHash=analysis.diagnostic_board_hash,
                        isBoardReady=diagnostic_state.battle.is_board_ready,
                        isCascadeRunning=diagnostic_state.battle.is_cascade_running,
                        turnDuration=diagnostic_state.battle.turn_duration_seconds,
                        turnRemainingAtState=(
                            diagnostic_state.battle.turn_time_remaining_seconds
                        ),
                        stateTimestamp=state_timestamp,
                        decisionTimestamp=analysis.decision_timestamp,
                        turnRemainingAtDecision=remaining_at_decision,
                        player=diagnostic_state.player,
                        boss=boss,
                        participants=diagnostic_state.participants,
                        fusion=diagnostic_state.fusion,
                        fusionUi=fusion_ui,
                        cards=diagnostic_state.cards,
                        idleState=idle_cache.state,
                        cells=[
                            {
                                "runtimeRow": 7 - cell.row,
                                "runtimeCol": cell.col,
                                "screenRow": cell.row,
                                "screenCol": cell.col,
                                "gemType": cell.gem.value,
                                "multiplier": cell.multiplier,
                            }
                            for row in diagnostic_state.board.cells
                            for cell in row
                        ],
                        totalAdjacentSwaps=analysis.total_adjacent_swaps,
                        legalMoveCount=analysis.legal_match_producing_moves,
                        illegalNoMatchSwaps=analysis.illegal_no_match_swaps,
                        safeMoveCount=analysis.safe_move_count,
                        dangerousMoveCount=analysis.dangerous_move_count,
                        deadBoard=analysis.dead_board,
                        legalMoves=analysis.legal_moves,
                        policy=analysis.policy,
                        policyObservability=analysis.policy_observability,
                    )
                    if (
                        analysis.legal_match_producing_moves <= 2
                        and key not in artifact_states
                    ):
                        event = (
                            "dead_board"
                            if analysis.legal_match_producing_moves == 0
                            else "low_legal_move_count"
                        )
                        capture = (
                            None
                            if args.no_screenshot
                            else lambda path: capture_client_png(target.pid, path)
                        )
                        try:
                            artifact = write_diagnostic_artifact(
                                artifact_root,
                                event=event,
                                state=diagnostic_state,
                                analysis=analysis,
                                screenshot_capture=capture,
                            )
                            artifact_states.add(key)
                            _write(
                                log,
                                "board_diagnostic_artifact_saved",
                                eventName=event,
                                directory=str(artifact.directory),
                                boardJson=str(artifact.board_json),
                                boardText=str(artifact.board_text),
                                analysisJson=str(artifact.analysis_json),
                                screenshot=(
                                    str(artifact.screenshot)
                                    if artifact.screenshot is not None
                                    else None
                                ),
                                legalMoveCount=analysis.legal_match_producing_moves,
                                deadBoard=analysis.dead_board,
                            )
                        except (OSError, RuntimeError, ValueError) as exc:
                            _write(
                                log,
                                "board_diagnostic_artifact_error",
                                eventName=event,
                                detail=str(exc),
                            )

            time.sleep(args.interval)

        _write(
            log,
            "combat_diagnostic_watch_stopped",
            completedMatches=completed,
            analyzedStableLocalBoards=len(analyzed_states),
            finalAnalysisKey=last_analysis_key,
            providerMetrics=asdict(provider.metrics),
            fusionAttempts=[record.payload() for record in fusion_tracker.records],
        )
        print(f"Watcher stopped, log: {log_path}", flush=True)
    return 0


def main(argv: Sequence[str] | None = None) -> int:
    try:
        return run(build_parser().parse_args(argv))
    except (
        ValueError,
        OSError,
        ProcessProbeError,
        ProviderSetupError,
    ) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
