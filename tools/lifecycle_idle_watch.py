#!/usr/bin/env python3
"""Read-only lifecycle + authoritative idle/reset watcher for Phase 2C.2A.3.

Start it in the lobby.  It never sends input and never changes a process value.
The JSONL timeline remains useful when the terminal is hidden during combat.
"""

from __future__ import annotations

import argparse
from dataclasses import asdict, is_dataclass
from enum import Enum
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

from pokiguard_v2.combat_lifecycle import (  # noqa: E402
    CombatLifecycleState,
    CombatSessionTracker,
    read_combat_lifecycle,
)
from pokiguard_v2.game_owned_idle import (  # noqa: E402
    AcceptedActivityKind,
    GameOwnedIdleCache,
)
from pokiguard_v2.il2cpp_external import (  # noqa: E402
    ACTIVE_PLAYER_STATS_TYPE_INFO_RVA,
    ExternalReadError,
)
from pokiguard_v2.il2cpp_layout import LayoutValidationError  # noqa: E402
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
)
from pokiguard_v2.memory_scan import (  # noqa: E402
    regions_containing_addresses,
    scan_aligned_qwords,
)
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
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.runtime_common import attach_target, default_log_path, hex_pointer  # noqa: E402


ACTION_RESPONSES = {
    "MATCH_MOVE_RES": AcceptedActivityKind.SWAP,
    "MATCH_CARD_USE_RES": AcceptedActivityKind.CAST,
    "MATCH_FUSION_RES": AcceptedActivityKind.EVOLVE,
}


def _jsonable(value: Any) -> Any:
    if is_dataclass(value):
        return _jsonable(asdict(value))
    if isinstance(value, Enum):
        return value.value
    if isinstance(value, dict):
        return {str(key): _jsonable(item) for key, item in value.items()}
    if isinstance(value, (tuple, list)):
        return [_jsonable(item) for item in value]
    return value


def _utc_timestamp() -> str:
    return time.strftime("%Y-%m-%dT%H:%M:%S", time.gmtime()) + (
        f".{int(time.time_ns() / 1_000_000) % 1000:03d}Z"
    )


def _write(log: Any, event: str, **fields: Any) -> None:
    payload = {"timestamp": _utc_timestamp(), "event": event, **fields}
    log.write(
        json.dumps(_jsonable(payload), ensure_ascii=False, separators=(",", ":"))
        + "\n"
    )
    log.flush()


def _session_id(session: Any) -> str | None:
    if session is None:
        return None
    return (
        f"epoch={session.lifecycle_epoch}|board={hex_pointer(session.board_instance)}"
        f"|match={session.match_id}"
    )


def _message_rejected(message: ServerMessage) -> bool:
    bools = dict(message.payload_bools)
    return bool(
        message.reject_reason
        or bools.get("rejected") is True
        or bools.get("success") is False
        or bools.get("accepted") is False
    )


def _message_actor(message: ServerMessage) -> str | None:
    strings = dict(message.payload_strings)
    return (
        strings.get("actorUsername")
        or strings.get("username")
        or message.username
    )


def _message_sort_key(message: ServerMessage) -> tuple[str, int, int]:
    return (
        message.timestamp or "",
        message.server_sequence if message.server_sequence is not None else 2**63 - 1,
        message.address,
    )


def _message_identity(message: ServerMessage) -> tuple[Any, ...]:
    """Deduplicate semantic server messages, not transient managed copies.

    One websocket DTO may survive in more than one managed object/address. The
    address is therefore provenance only and must not make an old accepted
    action look new after a later authoritative idle payload.
    """

    return (
        message.match_id,
        message.event_type,
        message.timestamp,
        message.server_sequence,
        message.username,
        message.from_col,
        message.from_row,
        message.to_col,
        message.to_row,
        message.card_id,
        message.skill_card_id,
        message.reject_reason,
        message.payload_ints,
        message.payload_bools,
        message.payload_strings,
    )


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--watch", action="store_true")
    parser.add_argument("--log", type=Path)
    parser.add_argument("--interval", type=float, default=0.20)
    parser.add_argument("--full-rescan-interval", type=int, default=12)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument("--matches", type=int, default=3)
    parser.add_argument("--timeout", type=float, default=0.0)
    parser.add_argument(
        "--allow-combat-start",
        action="store_true",
        help="recovery telemetry only; a lobby start remains preferred",
    )
    return parser


def run(args: argparse.Namespace) -> int:
    if not args.watch:
        raise ValueError("watcher must be started with --watch")
    if not 0.05 <= args.interval <= 5:
        raise ValueError("--interval must be between 0.05 and 5 seconds")
    if args.matches < 0 or args.timeout < 0:
        raise ValueError("matches/timeout cannot be negative")

    log_path = (args.log or default_log_path("lifecycle_idle_watch")).resolve()
    log_path.parent.mkdir(parents=True, exist_ok=True)
    with attach_target() as target, log_path.open("a", encoding="utf-8", buffering=1) as log:
        provider = MemoryBoardStateProvider(
            target,
            MemoryProviderConfig(
                max_region_mib=args.max_region_mib,
                chunk_mib=args.chunk_mib,
                full_rescan_interval=max(args.full_rescan_interval, 2),
                require_lobby_start=not args.allow_combat_start,
            ),
        )
        started = time.monotonic()
        dto_class = target.resolver.resolve_type_info_class(
            CHAT_MESSAGE_DTO_TYPE_INFO_RVA
        )
        stats_class = target.resolver.resolve_type_info_class(
            ACTIVE_PLAYER_STATS_TYPE_INFO_RVA
        )
        idle_cache = GameOwnedIdleCache()
        lifecycle_sessions = CombatSessionTracker()
        learned_regions: set[Any] = set()
        seen_messages: set[tuple[Any, ...]] = set()
        previous_signature: tuple[Any, ...] | None = None
        previous_turn: tuple[Any, ...] | None = None
        previous_session: str | None = None
        previous_fusion: Any = None
        active_seen = False
        completed = 0
        scans = 0

        _write(
            log,
            "lifecycle_idle_watch_started",
            pid=target.pid,
            architecture=target.architecture,
            gameassemblyBase=hex_pointer(target.game_assembly.base),
            access=["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"],
            noInput=True,
            noAutonomousActions=True,
            resetClasses=[
                "RESET_CONFIRMED_EXPLICIT",
                "RESET_CONFIRMED_BY_SERVER_SEQUENCE",
                "RESET_STRONGLY_INFERRED",
                "RESET_UNKNOWN",
            ],
        )
        print(f"Lifecycle/idle watcher ready (READ-ONLY), log: {log_path}", flush=True)

        while target.is_running():
            if args.timeout and time.monotonic() - started >= args.timeout:
                break
            try:
                poll = provider.poll()
            except (ExternalReadError, OSError, LayoutValidationError, RuntimeError) as exc:
                poll = None
                _write(log, "provider_poll_error", detail=str(exc))

            try:
                _match_service, runtime = read_match_runtime(target)
            except (ExternalReadError, OSError, LayoutValidationError) as exc:
                runtime = MatchRuntime(
                    None, None, None, None, None, None, None,
                    None, None, None, None, None,
                )
                _write(log, "runtime_read_error", detail=str(exc))

            board_instance, board_observation = _read_board_observation(target)
            provider_observation = poll.combat_lifecycle if poll is not None else None
            observation = read_combat_lifecycle(
                target.resolver,
                board=(
                    board_observation
                    if board_observation is not None and board_observation.accepted
                    else None
                ),
                match_id=runtime.match_id,
                match_over=(
                    provider_observation.signals.match_over
                    if provider_observation is not None
                    else None
                ),
                deferred_game_over=(
                    provider_observation.signals.deferred_game_over
                    if provider_observation is not None
                    else None
                ),
            )
            lifecycle = observation.state
            signals = observation.signals
            session = lifecycle_sessions.observe(
                lifecycle,
                signals.board_instance,
                signals.match_id,
            )
            session_id = _session_id(session)
            if stats_class is None:
                stats_class = target.resolver.resolve_type_info_class(
                    ACTIVE_PLAYER_STATS_TYPE_INFO_RVA
                )
            participants = _read_participants(target, board_observation, stats_class)
            boss = next((item for item in participants if item.is_boss is True), None)
            player = next((item for item in participants if item.is_local is True), None)

            signature = (
                lifecycle,
                signals.match_host_state,
                signals.current_rig,
                signals.scene_loading,
                signals.scene_unloading,
                signals.hub_suspended,
                signals.board_instance,
                signals.active_instance,
                signals.manager_match_instance,
                signals.objects_consistent,
                signals.match_id,
            )
            if signature != previous_signature:
                _write(
                    log,
                    "combat_lifecycle_changed",
                    lifecycle=lifecycle,
                    reason=observation.reason,
                    session=session_id,
                    signals=signals,
                    turn=runtime.turn,
                    currentTurnPlayer=runtime.current_player,
                    localUsername=runtime.local_username,
                    srvSeq=runtime.highest_acked_sequence,
                    bossHP=boss.hp if boss is not None else None,
                    bossMaxHP=boss.max_hp if boss is not None else None,
                    playerMana=player.mana if player is not None else None,
                    providerReason=(poll.reason if poll is not None else None),
                )
                previous_signature = signature

            if lifecycle is CombatLifecycleState.ACTIVE and session_id is not None:
                active_seen = True
                if previous_session != session_id:
                    idle_cache.begin_session(session_id)
                    seen_messages.clear()
                    _write(log, "combat_session_started", session=session_id)
                previous_session = session_id
            else:
                if previous_session is not None:
                    idle_cache.clear(f"lifecycle:{lifecycle.value}")
                    _write(
                        log,
                        "combat_session_invalidated",
                        session=previous_session,
                        lifecycle=lifecycle,
                        idleCacheCleared=True,
                    )
                    previous_session = None
                    if active_seen:
                        completed += 1
                        active_seen = False
                if args.matches and completed >= args.matches:
                    break

            local_turn = bool(
                lifecycle is CombatLifecycleState.ACTIVE
                and runtime.local_username
                and runtime.current_player
                and runtime.local_username.casefold() == runtime.current_player.casefold()
            )
            first_local_turn = bool(
                lifecycle is CombatLifecycleState.ACTIVE
                and local_turn
                and runtime.turn in (0, 1)
            )
            turn_signature = (
                session_id,
                runtime.turn,
                runtime.current_player,
                runtime.highest_acked_sequence,
            )
            if lifecycle is CombatLifecycleState.ACTIVE and turn_signature != previous_turn:
                _write(
                    log,
                    "combat_turn_changed",
                    session=session_id,
                    turn=runtime.turn,
                    currentTurnPlayer=runtime.current_player,
                    localUsername=runtime.local_username,
                    isLocalTurn=local_turn,
                    isFirstLocalTurn=first_local_turn,
                    remaining=runtime.remaining,
                    srvSeq=runtime.highest_acked_sequence,
                    bossHP=boss.hp if boss is not None else None,
                    bossMaxHP=boss.max_hp if boss is not None else None,
                )
                previous_turn = turn_signature

            if lifecycle is not CombatLifecycleState.ACTIVE or not runtime.match_id:
                time.sleep(args.interval)
                continue
            if dto_class is None:
                dto_class = target.resolver.resolve_type_info_class(
                    CHAT_MESSAGE_DTO_TYPE_INFO_RVA
                )
            if dto_class is None:
                time.sleep(args.interval)
                continue

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
                {"chat_message": int(dto_class)},
                chunk_size=args.chunk_mib * 1024 * 1024,
            )
            learned_regions.update(
                regions_containing_addresses(all_regions, scan.matches["chat_message"])
            )
            messages: list[ServerMessage] = []
            for address in scan.matches["chat_message"]:
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

            for message in sorted(messages, key=_message_sort_key):
                authoritative_idle = bool(
                    message.event_type in {"MATCH_AFK_WARN", "MATCH_TURN_END"}
                    and message.username
                    and message.idle_count is not None
                    and message.threshold is not None
                )
                idle_before = idle_cache.state
                idle_payload_rejection: str | None = None
                if authoritative_idle:
                    try:
                        idle_cache.observe_server_payload(
                            session_id=session_id or runtime.match_id,
                            username=message.username or "",
                            idle_count=(
                                message.idle_count
                                if message.idle_count is not None
                                else -1
                            ),
                            threshold=(
                                message.threshold
                                if message.threshold is not None
                                else -1
                            ),
                            source_message_type=message.event_type,
                            source_srv_seq=message.server_sequence,
                            source_turn=message.source_turn,
                            source_timestamp=message.timestamp,
                            observed_timestamp=_utc_timestamp(),
                        )
                    except ValueError as exc:
                        # A heap candidate that passes the DTO/JObject layout
                        # gates may still carry a stale or nonsensical boxed
                        # pair. Reject only that payload; never terminate the
                        # evidence collector or mutate the authoritative cache.
                        authoritative_idle = False
                        idle_payload_rejection = str(exc)

                activity_kind = ACTION_RESPONSES.get(message.event_type)
                activity_actor = _message_actor(message)
                activity_is_local = bool(
                    activity_actor
                    and runtime.local_username
                    and activity_actor.casefold() == runtime.local_username.casefold()
                )
                activity_accepted = bool(
                    activity_kind is not None
                    and activity_is_local
                    and not _message_rejected(message)
                )
                if activity_accepted:
                    idle_cache.observe_accepted_activity(
                        session_id=session_id or runtime.match_id,
                        kind=activity_kind,
                        source_message_type=message.event_type,
                        source_srv_seq=message.server_sequence,
                        source_turn=message.source_turn,
                        source_timestamp=message.timestamp,
                        observed_timestamp=_utc_timestamp(),
                    )

                readiness = idle_cache.pass_readiness(
                    current_session_id=session_id,
                    local_username=runtime.local_username,
                    current_turn=runtime.turn,
                    is_local_turn=local_turn,
                    lifecycle_active=lifecycle is CombatLifecycleState.ACTIVE,
                )
                _write(
                    log,
                    "server_match_message",
                    session=session_id,
                    lifecycle=lifecycle,
                    turn=runtime.turn,
                    currentTurnPlayer=runtime.current_player,
                    localUsername=runtime.local_username,
                    srvSeq=runtime.highest_acked_sequence,
                    message=message,
                    authoritativeIdle=authoritative_idle,
                    idlePayloadRejection=idle_payload_rejection,
                    acceptedActivity=activity_kind if activity_accepted else None,
                    activityActor=activity_actor,
                    activityIsLocal=activity_is_local,
                    rejected=_message_rejected(message),
                    idleBefore=idle_before,
                    idleAfter=idle_cache.state,
                    passReadiness=readiness,
                )

            fusion = provider.observed_fusion
            if fusion != previous_fusion:
                _write(
                    log,
                    "fusion_state_changed",
                    session=session_id,
                    lifecycle=lifecycle,
                    turn=runtime.turn,
                    before=previous_fusion,
                    after=fusion,
                    note="EVOLVE reset remains UNKNOWN unless a response/idle sequence proves it",
                )
                previous_fusion = fusion

            time.sleep(args.interval)

        _write(
            log,
            "lifecycle_idle_watch_stopped",
            completedMatches=completed,
            finalLifecycle=(previous_signature[0] if previous_signature else None),
            finalIdleState=idle_cache.state,
        )
        print(f"Watcher stopped, log: {log_path}", flush=True)
    return 0


def main(argv: Sequence[str] | None = None) -> int:
    try:
        return run(build_parser().parse_args(argv))
    except (ValueError, OSError, ProcessProbeError) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
