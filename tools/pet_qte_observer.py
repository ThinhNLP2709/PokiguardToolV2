#!/usr/bin/env python3
"""Production Phase 3B.1 Pet Skill/QTE shadow observer (RPM only, no input)."""

from __future__ import annotations

import argparse
from contextlib import nullcontext
from dataclasses import asdict, is_dataclass, replace
from datetime import datetime
from enum import Enum
import json
from pathlib import Path
import sys
import time
from typing import Any


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.il2cpp_external import (  # noqa: E402
    ACTIVE_AUDITION_STAGE,
    ACTIVE_DOT_SKILL_CARD,
    ACTIVE_PLAYER_STATS_TYPE_INFO_RVA,
    ACTIVE_SINGLETON,
    AUDITION_CHALLENGE_TYPE_INFO_RVA,
    AUDITION_STAGE_TYPE_INFO_RVA,
    BOARD_SINGLETON,
    CARD_DATA_TYPE_INFO_RVA,
    CARD_UI_TYPE_INFO_RVA,
    CHAT_MESSAGE_DTO_TYPE_INFO_RVA,
    MATCH_SERVICE_SINGLETON,
    PET_USER_DTO_TYPE_INFO_RVA,
    ExternalReadError,
)
from pokiguard_v2.gameplay_profile import AuditionMode  # noqa: E402
from pokiguard_v2.il2cpp_layout import LayoutValidationError  # noqa: E402
from pokiguard_v2.combat_lifecycle import CombatLifecycleState  # noqa: E402
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
    ProviderPoll,
)
from pokiguard_v2.memory_scan import (  # noqa: E402
    bounded_private_writable_regions,
    regions_containing_addresses,
    scan_aligned_qwords,
)
from pokiguard_v2.opening_snapshot import (  # noqa: E402
    JARRAY_TYPE_INFO_RVA,
    JOBJECT_TYPE_INFO_RVA,
    JPROPERTY_TYPE_INFO_RVA,
    JVALUE_TYPE_INFO_RVA,
    NewtonsoftClasses,
    OpeningBoardSnapshot,
    read_match_payload_board_snapshot,
)
from pokiguard_v2.pet_qte_observer import (  # noqa: E402
    BoundQteObservation,
    DOT_SKILL_ELEMENT_TYPES,
    QTE_RESULT_TYPES,
    QteBindingContext,
    QteBindingStatus,
    QteSessionTracker,
    correlate_qte_response_envelope,
    read_audition_v3_qte,
    read_card_ui_qte,
    read_player_pet_skill,
    read_qte_card_data,
    read_server_qte_challenge,
)
from pokiguard_v2.pet_skill_shadow import (  # noqa: E402
    LivePetSkillCard,
    PetSkillCapabilityProvider,
    PetSkillCapabilityStatus,
    QteEvidenceStatus,
    QteObserver,
    live_pet_skill_card_from_state,
)
from pokiguard_v2.player_stats import (  # noqa: E402
    read_active_participants,
    read_match_local_actor_number,
)
from pokiguard_v2.state import GamePhase  # noqa: E402
from tools.idle_state_watch import read_match_runtime, read_server_message  # noqa: E402
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.runtime_common import attach_target, default_log_path, hex_pointer  # noqa: E402


# Keep the control loop free to sample MatchService.PendingCombat and
# BoardWsApplier._pendingBatches while the pre-armed dispatcher tap waits for
# the short-lived result callback.  A broad heap scan blocks that owner-root
# sampling for 1.5--3.5 seconds.  Live v1.0.33 evidence observed the response
# roughly one second after Space, exactly while the former 0.75-second fallback
# scan was blocking.  Three seconds stays well inside the bounded 15-second
# result deadline and leaves ample fallback time if the direct tap is absent.
DISPATCHER_RESULT_EXCLUSIVE_WINDOW_SECONDS = 3.0


def _defer_heap_result_scan(
    *,
    dispatcher_available: bool,
    dispatcher_result_count: int,
    completion_epoch: float | None,
    observed_epoch: float,
) -> bool:
    if dispatcher_result_count > 0 or not dispatcher_available:
        return False
    if completion_epoch is None:
        return False
    elapsed = observed_epoch - completion_epoch
    return 0.0 <= elapsed < DISPATCHER_RESULT_EXCLUSIVE_WINDOW_SECONDS


def _poll_provider(provider: Any, runtime_hook: Any) -> tuple[Any, bool]:
    def trace(stage: str) -> None:
        callback = getattr(runtime_hook, "trace_stage", None)
        if callable(callback):
            callback(stage)

    def control_poll(expected_session: Any) -> Any:
        trace("qte_control_begin")
        try:
            return provider.poll_qte_control(expected_session)
        finally:
            trace("qte_control_end")

    session = getattr(runtime_hook, "critical_qte_session", None)
    if session is not None:
        # As soon as the one Space has been sent, retain any directly owned
        # PendingCombat/owner-queue batch while its short-lived root still
        # exists. This path performs no heap scan and the candidate remains
        # subject to the normal exact ACK and stability gates after response
        # correlation.
        result_wait = getattr(runtime_hook, "result_wait_session", None)
        if result_wait is not None:
            capture = getattr(provider, "capture_transient_batches", None)
            if callable(capture):
                capture()
        control = control_poll(session)
        if control.control_battle is not None or result_wait is None:
            return control, True
        # A PERFECT skill can end combat before the queued response is sampled.
        # Read the normal provider once to preserve an exact terminal GameState,
        # but never substitute an ordinary ACTIVE/stale full poll for the lost
        # QTE control owner.
        full = provider.poll()
        if _exact_terminal_state_for_session(full, session):
            return replace(
                full,
                reason=f"post_space_terminal:{control.reason}:{full.reason}",
            ), True
        return control, True
    watch_session = getattr(runtime_hook, "pre_action_watch_session", None)
    if watch_session is not None:
        # Once one full poll has established exact combat ownership, Pet Skill
        # discovery no longer depends on playable board publication. Refresh
        # the native hand and current controls only; an ACK heap gap must not
        # delay a lit card until the turn has expired.
        refresh = getattr(provider, "refresh_pet_skill_cards", None)
        refresh_started = time.monotonic()
        cards: tuple[Any, ...] = ()
        if callable(refresh):
            trace("pet_skill_refresh_begin")
            try:
                require_fusion = bool(
                    getattr(runtime_hook, "require_fusion_success", True)
                )
                cards = tuple(
                    refresh(watch_session)
                    if require_fusion
                    else refresh(
                        watch_session,
                        require_fusion_success=False,
                    )
                )
            finally:
                trace("pet_skill_refresh_end")
        refresh_elapsed_ms = (time.monotonic() - refresh_started) * 1000
        refresh_observed = getattr(
            runtime_hook, "pet_skill_control_refresh", None
        )
        if callable(refresh_observed):
            diagnostics = getattr(provider, "scan_diagnostics", {})
            refresh_observed(
                cards,
                reason=str(
                    diagnostics.get("nativeCardDiscoveryReason", "unknown")
                ),
                elapsed_ms=refresh_elapsed_ms,
            )
        return control_poll(watch_session), True
    continuation_session = getattr(
        runtime_hook, "continuation_audit_session", None
    )
    if continuation_session is not None:
        # Phase 3C.0 owns no gameplay input after runtime PERFECT.  Probe the
        # immutable action/session boundary before asking the normal provider
        # for a playable board.  Legend-card animation can temporarily remove
        # Board/Active; calling provider.poll() during that gap would invalidate
        # its lifecycle tracker and manufacture a new epoch when the same board
        # returns.
        control = control_poll(continuation_session)
        if control.control_battle is None:
            return control, False
        full = provider.poll()
        if full.state is not None and (
            full.state.phase is not GamePhase.COMBAT
            or full.state.battle.session_key != continuation_session
        ):
            return ProviderPoll(
                None,
                False,
                "continuation_state_session_disagrees",
                session_key=control.session_key,
                combat_lifecycle=control.combat_lifecycle,
                control_battle=control.control_battle,
            ), False
        return replace(
            full,
            session_key=control.session_key,
            combat_lifecycle=control.combat_lifecycle,
            control_battle=control.control_battle,
        ), False
    post_session = getattr(runtime_hook, "post_qte_session", None)
    if post_session is not None:
        offer_post_boards = getattr(
            runtime_hook, "offer_dispatcher_post_qte_boards", None
        )
        if callable(offer_post_boards):
            offer_post_boards(provider, post_session)
    full = provider.poll()
    if post_session is None:
        return full, False
    # Publication is allowed to wait during skill effects/cascade. Ownership
    # is NOT allowed to fall back to a previously published board or session.
    control = control_poll(post_session)
    if control.control_battle is None:
        if _exact_terminal_state_for_session(full, post_session):
            return replace(
                full,
                reason=f"post_qte_terminal:{control.reason}:{full.reason}",
            ), False
        return replace(control, reason=f"post_qte_control_rejected:{full.reason}:{control.reason}"), False
    if full.state is not None and (
        full.state.phase is not GamePhase.COMBAT
        or full.state.battle.session_key != post_session
    ):
        return ProviderPoll(None, False, "post_qte_state_session_disagrees"), False
    return replace(full, session_key=control.session_key,
                   combat_lifecycle=control.combat_lifecycle,
                   control_battle=control.control_battle), False


def _notify_explicit_server_reject(
    runtime_hook: Any,
    correlation: Any,
    result: Any,
) -> None:
    """Forward only an already current/action-bounded explicit rejection."""

    if runtime_hook is None or correlation.provenance != "EXPLICIT_REJECT":
        return
    callback = getattr(runtime_hook, "server_rejected_result", None)
    if callable(callback):
        callback(reason=correlation.reason, response_address=result.address)


def _exact_terminal_state_for_session(poll: Any, session: Any) -> bool:
    """Require a terminal GameState tied to the retained action MatchId."""

    state = getattr(poll, "state", None)
    battle = getattr(state, "battle", None) if state is not None else None
    if battle is None or session is None:
        return False
    terminal_snapshot = getattr(state, "terminal_snapshot", None)
    match_ids = {
        value
        for value in (
            getattr(battle, "match_id", None),
            getattr(terminal_snapshot, "match_id", None),
        )
        if value
    }
    if getattr(session, "match_id", None) not in match_ids:
        return False
    return bool(
        getattr(battle, "combat_lifecycle", None) is CombatLifecycleState.POSTMATCH
        or getattr(battle, "match_over", None) is True
        or getattr(battle, "board_is_game_over", None) is True
        or getattr(battle, "local_has_left_match", None) is True
    )


def _poll_delay(interval: float, runtime_hook: Any) -> float:
    callback = getattr(runtime_hook, "poll_delay_seconds", None)
    return min(interval, max(0.005, float(callback()))) if callable(callback) else interval


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


def _write(log: Any, event: str, **fields: Any) -> None:
    payload = {
        "timestamp": time.strftime("%Y-%m-%dT%H:%M:%S", time.gmtime())
        + f".{int(time.time_ns() / 1_000_000) % 1000:03d}Z",
        "event": event,
        **fields,
    }
    log.write(
        json.dumps(_jsonable(payload), ensure_ascii=False, separators=(",", ":"))
        + "\n"
    )
    log.flush()


def _session_text(session: Any) -> str | None:
    if session is None:
        return None
    return (
        f"epoch={session.lifecycle_epoch}|board=0x{session.board_instance:016X}"
        f"|match={session.match_id}"
    )


def _regions(target: Any, max_region_mib: int) -> tuple[Any, ...]:
    return bounded_private_writable_regions(
        target.memory.iter_readable_regions(),
        max_region_size=max_region_mib * 1024 * 1024,
    )


def _scan_qte_results(
    target: Any,
    *,
    dto_class: int,
    match_id: str,
    all_regions: tuple[Any, ...],
    learned_regions: set[Any],
    full: bool,
    chunk_mib: int,
) -> tuple[Any, ...]:
    values = []
    primary: tuple[Any, ...] = (
        tuple(sorted(learned_regions, key=lambda item: item.base))
        if learned_regions
        else all_regions
    )
    scan_sets = [primary]
    if full and primary != all_regions:
        # Always inspect the already learned ChatMessageDTO regions first.
        # MATCH_SKILL_USE_RES can be short-lived, while a full private-memory
        # scan is comparatively expensive.  The broad scan remains a bounded
        # discovery fallback and never changes correlation authority.
        scan_sets.append(all_regions)
    seen_addresses: set[int] = set()
    for selected in scan_sets:
        scan = scan_aligned_qwords(
            target.memory,
            selected,
            {"qte_result": dto_class},
            chunk_size=chunk_mib * 1024 * 1024,
        )
        learned_regions.update(
            regions_containing_addresses(all_regions, scan.matches["qte_result"])
        )
        for address in scan.matches["qte_result"]:
            if address in seen_addresses:
                continue
            seen_addresses.add(address)
            try:
                message = read_server_message(
                    target.memory,
                    address,
                    expected_class=dto_class,
                    expected_match_id=match_id,
                )
                if message.event_type in QTE_RESULT_TYPES:
                    values.append(message)
            except (ExternalReadError, OSError, LayoutValidationError):
                continue
        if values:
            break
    return tuple(values)


def _requires_full_qte_result_scan(
    scan_number: int,
    learned_region_count: int,
) -> bool:
    """Schedule bounded rediscovery for a short-lived result envelope.

    A successful live action on 2026-09-08 proved that one ascending full scan
    can race a newly allocated ``MATCH_SKILL_USE_RES``: the scan found ordinary
    ChatMessageDTO regions, then every later pass remained confined to those
    stale hints.  The first two scans therefore always rediscover the bounded
    private/writable envelope.  Afterwards a full pass every eighth scan keeps
    discovering newly used managed regions while the fast learned-region scan
    remains the common path.  Result collection occurs only after the one Space
    has already been sent and never grants input authority.
    """

    if scan_number <= 0:
        raise ValueError("QTE result scan number must be positive")
    if learned_region_count < 0:
        raise ValueError("learned region count cannot be negative")
    return bool(
        learned_region_count == 0
        or scan_number <= 2
        or scan_number % 8 == 0
    )


def _server_timestamp_epoch(value: str | None) -> float | None:
    """Convert the game's ISO timestamp to epoch using local time if naive."""

    if not value:
        return None
    try:
        parsed = datetime.fromisoformat(value.replace("Z", "+00:00"))
    except ValueError:
        return None
    if parsed.tzinfo is not None:
        return parsed.timestamp()
    return time.mktime(parsed.timetuple()) + parsed.microsecond / 1_000_000.0


def _resolve_newtonsoft_classes(target: Any) -> NewtonsoftClasses | None:
    values = tuple(
        target.resolver.resolve_type_info_class(rva)
        for rva in (
            JARRAY_TYPE_INFO_RVA,
            JOBJECT_TYPE_INFO_RVA,
            JPROPERTY_TYPE_INFO_RVA,
            JVALUE_TYPE_INFO_RVA,
        )
    )
    if any(value is None for value in values):
        return None
    return NewtonsoftClasses(*(int(value) for value in values))


def _offer_qte_result_board_snapshot(
    target: Any,
    provider: Any,
    result: Any,
    *,
    classes: NewtonsoftClasses,
) -> tuple[OpeningBoardSnapshot, bool]:
    """Offer the exact current skill response board to the normal ACK gate."""

    if result.event_type != "MATCH_SKILL_USE_RES":
        raise LayoutValidationError("QTE result is not a skill-use response")
    if result.payload_address is None:
        raise LayoutValidationError("skill-use response has no matchPayload")
    snapshot = read_match_payload_board_snapshot(
        target.memory,
        match_id=result.match_id,
        message_address=result.address,
        payload_address=result.payload_address,
        classes=classes,
        event_type=result.event_type,
    )
    accepted = provider.offer_transport_board_snapshot(
        snapshot,
        event_type=result.event_type,
    )
    return snapshot, accepted


def _offer_dispatcher_raw_qte_board_snapshot(
    provider: Any,
    result: Any,
    snapshot: OpeningBoardSnapshot,
) -> tuple[OpeningBoardSnapshot, bool]:
    """Bind a strict callback-JSON board to its exact decoded response."""

    if result.event_type != "MATCH_SKILL_USE_RES":
        raise LayoutValidationError("QTE result is not a skill-use response")
    if (
        snapshot.match_id != result.match_id
        or snapshot.message_address != result.address
    ):
        raise LayoutValidationError("callback JSON board identity differs from response")
    accepted = provider.offer_transport_board_snapshot(
        snapshot,
        event_type=result.event_type,
    )
    return snapshot, accepted


def _participant_snapshot(
    target: Any,
    *,
    active_instance: int,
    stats_class: int | None,
    local_actor_number: int,
    fallback_state: Any | None,
) -> dict[str, Any]:
    """Take a fresh participant sample without requiring a stable board frame."""

    local = None
    boss = None
    resource_read_error = None
    if stats_class is not None:
        try:
            participants = read_active_participants(
                target.memory,
                active_instance,
                expected_class=stats_class,
                local_actor_number=local_actor_number,
            )
            local = next((item for item in participants if item.is_local), None)
            boss = next((item for item in participants if item.is_boss), None)
            if local is None:
                resource_read_error = "current local actor is absent from Active.playerStatsMap"
        except (ExternalReadError, OSError, LayoutValidationError) as exc:
            resource_read_error = f"{type(exc).__name__}: {exc}"
    else:
        resource_read_error = "Active.PlayerStats class is unresolved"
    fallback_player = fallback_state.player if fallback_state is not None else None
    fallback_boss = next(
        (
            item
            for item in (fallback_state.opponents if fallback_state is not None else ())
            if item.is_boss
        ),
        None,
    )
    return {
        # Mana and power authorize a real card click.  Never substitute the
        # board provider's older participant snapshot when the exact
        # Active.playerStatsMap read is torn; the next fast-watch sample will
        # retry it.  HP remains observational and may use the current board
        # fallback for post-skill diagnostics.
        "resourceCurrent": local is not None,
        "resourceSource": local.source if local is not None else "UNAVAILABLE",
        "resourceReadError": resource_read_error,
        "resourceSampledMonotonic": time.monotonic(),
        "localActor": local_actor_number,
        "localHp": local.hp if local is not None else (
            fallback_player.hp if fallback_player is not None else None
        ),
        "localMaxHp": local.max_hp if local is not None else (
            fallback_player.max_hp if fallback_player is not None else None
        ),
        "mana": local.mana if local is not None else None,
        "power": local.power if local is not None else None,
        "bossActor": boss.actor_number if boss is not None else (
            fallback_boss.actor_number if fallback_boss is not None else None
        ),
        "bossHp": boss.hp if boss is not None else (
            fallback_boss.hp if fallback_boss is not None else None
        ),
        "bossMaxHp": boss.max_hp if boss is not None else (
            fallback_boss.max_hp if fallback_boss is not None else None
        ),
        "boardHash": (
            fallback_state.battle.board_hash if fallback_state is not None else None
        ),
    }


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--watch", action="store_true", help="required safety switch")
    parser.add_argument("--log", type=Path, help="JSONL output path")
    parser.add_argument("--interval", type=float, default=0.05)
    parser.add_argument("--timeout", type=float, default=0.0)
    parser.add_argument("--qtes", type=int, default=3)
    parser.add_argument(
        "--audition-mode",
        choices=[value.value for value in AuditionMode],
        default=AuditionMode.V3_TWO_DIRECTION.value,
    )
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument(
        "--allow-combat-start",
        action="store_true",
        help="diagnostic recovery only; starting in lobby is safer",
    )
    return parser


def run(
    args: argparse.Namespace,
    *,
    runtime_hook: Any | None = None,
    shared_target: Any | None = None,
    shared_provider: Any | None = None,
) -> int:
    if not args.watch:
        raise ValueError("start the observer with --watch")
    if not 0.02 <= args.interval <= 1.0:
        raise ValueError("--interval must be between 0.02 and 1.0 seconds")
    if args.timeout < 0 or not 0 <= args.qtes <= 20:
        raise ValueError("timeout/qtes is outside the allowed range")
    if not 1 <= args.max_region_mib <= 32 or not 1 <= args.chunk_mib <= 16:
        raise ValueError("scan size is outside the allowed range")

    log_path = (args.log or default_log_path("phase3b1_qte_shadow")).resolve()
    log_path.parent.mkdir(parents=True, exist_ok=True)
    target_context = (
        nullcontext(shared_target) if shared_target is not None else attach_target()
    )
    with target_context as target, log_path.open(
        "a", encoding="utf-8", buffering=1
    ) as log:
        provider = shared_provider or MemoryBoardStateProvider(
            target,
            MemoryProviderConfig(
                max_region_mib=args.max_region_mib,
                chunk_mib=args.chunk_mib,
                full_rescan_interval=8,
                require_lobby_start=not args.allow_combat_start,
            ),
        )
        audition_mode = AuditionMode(
            getattr(
                runtime_hook,
                "audition_mode",
                getattr(args, "audition_mode", AuditionMode.V3_TWO_DIRECTION.value),
            )
        )
        tracker = QteSessionTracker(audition_mode)
        capability_provider = PetSkillCapabilityProvider()
        shadow_observer = QteObserver()
        if runtime_hook is not None:
            runtime_hook.attach(
                target,
                lambda event, **fields: _write(log, event, **fields),
            )
        started = time.monotonic()
        last_state = None
        previous_pet_signature = None
        previous_skill_signature = None
        previous_qte_signature = None
        previous_capability_signature = None
        previous_shadow_generation = None
        previous_shadow_direction_signature = None
        previous_shadow_progress_signature = None
        previous_shadow_timing_signature = None
        previous_shadow_runtime_result_signature = None
        previous_shadow_rejection_signature = None
        previous_match_id = None
        pending: BoundQteObservation | None = None
        pending_before = None
        pending_completion_epoch: float | None = None
        closed_identities: set[Any] = set()
        seen_results: set[int] = set()
        learned_result_regions: set[Any] = set()
        result_scan_number = 0
        full_result_scan_count = 0
        last_result_scan = 0.0
        completed_qtes = 0
        board_payload_classes: NewtonsoftClasses | None = None

        pet_class = target.resolver.resolve_type_info_class(PET_USER_DTO_TYPE_INFO_RVA)
        card_data_class = target.resolver.resolve_type_info_class(
            CARD_DATA_TYPE_INFO_RVA
        )
        card_ui_class = target.resolver.resolve_type_info_class(CARD_UI_TYPE_INFO_RVA)
        audition_stage_class = target.resolver.resolve_type_info_class(
            AUDITION_STAGE_TYPE_INFO_RVA
        )
        audition_challenge_class = target.resolver.resolve_type_info_class(
            AUDITION_CHALLENGE_TYPE_INFO_RVA
        )
        stats_class = target.resolver.resolve_type_info_class(
            ACTIVE_PLAYER_STATS_TYPE_INFO_RVA
        )
        dto_class = target.resolver.resolve_type_info_class(
            CHAT_MESSAGE_DTO_TYPE_INFO_RVA
        )
        _write(
            log,
            "observer_started",
            pid=target.pid,
            architecture=target.architecture,
            gameAssemblyBase=hex_pointer(target.game_assembly.base),
            access=["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"],
            noInput=runtime_hook is None,
            noProcessWrite=True,
            noIl2CppInvocation=True,
            requiredBoundary="current MatchId + lifecycle epoch + local actor + skill card + inactive edge",
            qteTarget=args.qtes,
            lobbyBaselineRequired=not args.allow_combat_start,
            runtimeHook=(runtime_hook.name if runtime_hook is not None else None),
            auditionMode=audition_mode.value,
        )
        if runtime_hook is None:
            print(f"Phase 3B.1 production shadow observer READ-ONLY; log: {log_path}", flush=True)
            print("NO INPUT: perform every Pet Skill/QTE action manually.", flush=True)
        else:
            runtime_hook.started(log_path)

        def trace_runtime_stage(stage: str) -> None:
            if runtime_hook is None:
                return
            callback = getattr(runtime_hook, "trace_stage", None)
            if callable(callback):
                callback(stage)

        while target.is_running():
            now = time.monotonic()
            if args.timeout and now - started >= args.timeout:
                _write(log, "observer_timeout", completedQtes=completed_qtes)
                break
            if args.qtes and completed_qtes >= args.qtes:
                _write(log, "observer_target_reached", completedQtes=completed_qtes)
                break
            if runtime_hook is not None and bool(
                getattr(runtime_hook, "done", False)
            ):
                _write(
                    log,
                    "runtime_hook_target_reached",
                    completedQtes=completed_qtes,
                    runtimeHook=runtime_hook.name,
                )
                break
            critical_poll = getattr(runtime_hook, "critical_qte_session", None) is not None
            watch_poll = getattr(runtime_hook, "pre_action_watch_session", None) is not None
            owned_poll = (
                critical_poll
                or watch_poll
                or getattr(runtime_hook, "post_qte_session", None) is not None
                or getattr(runtime_hook, "continuation_audit_session", None)
                is not None
            )
            poll_started = time.monotonic()
            try:
                trace_runtime_stage("provider_poll_begin")
                poll, critical_poll = _poll_provider(provider, runtime_hook)
                trace_runtime_stage("provider_poll_end")
            except (ExternalReadError, OSError, LayoutValidationError, RuntimeError) as exc:
                poll = None
                _write(log, "provider_error", detail=str(exc))
            provider_poll_ms = (time.monotonic() - poll_started) * 1000
            if owned_poll:
                last_state = None  # control-only read is never a playable board
            if owned_poll and (poll is None or poll.control_battle is None):
                # No stale last_state fallback while QTE owns input.
                last_state = None
                control_reason = (
                    poll.reason if poll is not None else "QTE_CONTROL_READ_FAILED"
                )
                retain_post_space = getattr(
                    runtime_hook,
                    "retain_post_space_after_control_read_failure",
                    None,
                )
                if callable(retain_post_space) and retain_post_space(control_reason):
                    # No input remains after the one Space.  Keep the immutable
                    # completed QTE/ActionId alive while the pre-armed dispatcher
                    # tap captures the exact old-MatchId response.  This branch
                    # intentionally does not resolve current combat singletons.
                    if (
                        pending is not None
                        and pending.status is QteBindingStatus.COMPLETED_CURRENT
                        and pending_completion_epoch is not None
                        and now - last_result_scan >= 0.1
                    ):
                        last_result_scan = now
                        result_scan_number += 1
                        direct = getattr(runtime_hook, "dispatcher_qte_results", None)
                        results = (
                            tuple(direct(pending.identity.session_key.match_id))
                            if callable(direct) and pending.identity is not None
                            else ()
                        )
                        diagnostics = getattr(
                            runtime_hook, "dispatcher_tap_diagnostics", None
                        )
                        _write(
                            log,
                            "qte_result_scan",
                            session=(
                                _session_text(pending.identity.session_key)
                                if pending.identity is not None
                                else None
                            ),
                            scanNumber=result_scan_number,
                            fullRequested=False,
                            fullDirection=None,
                            fullScanCount=full_result_scan_count,
                            learnedRegionCount=len(learned_result_regions),
                            learnedRegionBytes=sum(
                                region.size for region in learned_result_regions
                            ),
                            allRegionCount=0,
                            resultCount=len(results),
                            elapsedMs=0.0,
                            discoverySource="dispatcher_owned_callback_terminal_wait",
                            dispatcherTap=diagnostics,
                        )
                        observed_epoch = time.time()
                        for result in results:
                            if result.address in seen_results:
                                continue
                            seen_results.add(result.address)
                            payload_ints = dict(result.payload_ints)
                            response_skill_card_id = (
                                result.skill_card_id
                                if result.skill_card_id is not None
                                else payload_ints.get("skillCardId")
                            )
                            correlation = correlate_qte_response_envelope(
                                pending,
                                event_type=result.event_type,
                                match_id=result.match_id,
                                skill_card_id=response_skill_card_id,
                                qte_challenge_id=result.qte_challenge_id,
                                reject_reason=result.reject_reason,
                                payload_bools=result.payload_bools,
                                server_timestamp_epoch=_server_timestamp_epoch(
                                    result.timestamp
                                ),
                                completion_epoch=pending_completion_epoch,
                                observed_epoch=observed_epoch,
                            )
                            _write(
                                log,
                                "qte_result_message",
                                session=(
                                    _session_text(pending.identity.session_key)
                                    if pending.identity is not None
                                    else None
                                ),
                                result=result,
                                correlation=correlation,
                                predicted=pending.predicted_timing_result,
                                displayed=(
                                    pending.qte.displayed_timing_result
                                    if pending.qte is not None
                                    else None
                                ),
                                before=pending_before,
                                after=None,
                                terminalReadOnly=True,
                            )
                            _notify_explicit_server_reject(
                                runtime_hook, correlation, result
                            )
                            identity = pending.identity
                            if not correlation.current or identity is None:
                                continue
                            server_timing = dict(result.payload_strings).get(
                                "timingResult"
                            )
                            shadow_result = shadow_observer.correlate_server_response(
                                generation=identity.observer_generation,
                                response_key=f"0x{result.address:016X}",
                                match_id=result.match_id,
                                skill_card_id=response_skill_card_id,
                                correlation=correlation,
                                server_timing_result=server_timing,
                            )
                            if shadow_result is None:
                                continue
                            _write(
                                log,
                                "qte_server_result_correlated",
                                session=_session_text(identity.session_key),
                                generation=identity.observer_generation,
                                responseAddress=hex_pointer(result.address),
                                correlation=correlation,
                                serverResult=shadow_result.server_resolved_result,
                                serverResultRaw=server_timing,
                                timingEchoAvailable=server_timing is not None,
                                terminalReadOnly=True,
                            )
                            result_callback = getattr(
                                runtime_hook, "correlated_readonly_result", None
                            )
                            if callable(result_callback):
                                result_callback(
                                    shadow_result,
                                    sampled_monotonic=now,
                                )
                            completed_qtes += 1
                            closed_identities.add(identity)
                            _write(
                                log,
                                "qte_closed",
                                completedQtes=completed_qtes,
                                session=_session_text(identity.session_key),
                                generation=identity.observer_generation,
                                correlationProvenance=correlation.provenance,
                                predictedTiming=pending.predicted_timing_result,
                                displayedTiming=(
                                    pending.qte.displayed_timing_result
                                    if pending.qte is not None
                                    else None
                                ),
                                rawDisplayedTiming=(
                                    pending.qte.displayed_timing_text
                                    if pending.qte is not None
                                    else None
                                ),
                                resourceDelta=None,
                                boardHashBefore=(
                                    pending_before.get("boardHash")
                                    if pending_before is not None
                                    else None
                                ),
                                boardHashAfter=None,
                                turnBefore=(
                                    pending_before.get("turn")
                                    if pending_before is not None
                                    else None
                                ),
                                turnAfter=None,
                                currentPlayerAfter=None,
                                terminalReadOnly=True,
                            )
                            pending = None
                            pending_before = None
                            pending_completion_epoch = None
                            break
                    readonly_tick = getattr(
                        runtime_hook, "observe_post_space_readonly", None
                    )
                    if callable(readonly_tick):
                        readonly_tick(
                            poll.state if poll is not None else None,
                            sampled_monotonic=poll_started,
                            reason=control_reason,
                        )
                    time.sleep(_poll_delay(args.interval, runtime_hook))
                    continue
                retain_post_perfect = getattr(
                    runtime_hook,
                    "retain_post_perfect_after_control_read_failure",
                    None,
                )
                if callable(retain_post_perfect) and retain_post_perfect(
                    control_reason,
                    poll=poll,
                ):
                    time.sleep(_poll_delay(args.interval, runtime_hook))
                    continue
                retain = getattr(
                    runtime_hook,
                    "retain_pre_action_after_control_read_failure",
                    None,
                )
                if callable(retain) and retain(control_reason):
                    time.sleep(_poll_delay(args.interval, runtime_hook))
                    continue
                runtime_hook.invalidate(control_reason)
                continue
            if poll is not None and poll.state is not None:
                if poll.state.phase is GamePhase.COMBAT:
                    last_state = poll.state
                elif poll.state.phase is not GamePhase.COMBAT:
                    last_state = None

            try:
                trace_runtime_stage("runtime_singletons_begin")
                match_service_resolution = target.resolver.resolve_singleton(
                    MATCH_SERVICE_SINGLETON
                )
                active_resolution = target.resolver.resolve_singleton(ACTIVE_SINGLETON)
                board_resolution = target.resolver.resolve_singleton(BOARD_SINGLETON)
                _match_service, runtime = read_match_runtime(target)
                trace_runtime_stage("runtime_singletons_end")
            except (ExternalReadError, OSError, LayoutValidationError) as exc:
                _write(log, "runtime_error", detail=str(exc))
                if owned_poll:
                    reason = "QTE_CURRENT_RUNTIME_UNREADABLE"
                    retain = getattr(
                        runtime_hook,
                        "retain_pre_action_after_transient_read_failure",
                        None,
                    )
                    if callable(retain) and retain(reason):
                        time.sleep(_poll_delay(args.interval, runtime_hook))
                        continue
                    runtime_hook.invalidate(reason)
                time.sleep(args.interval)
                continue

            if runtime.match_id != previous_match_id:
                _write(
                    log,
                    "match_changed",
                    before=previous_match_id,
                    after=runtime.match_id,
                    turn=runtime.turn,
                )
                tracker.invalidate()
                shadow_observer.invalidate("match_changed")
                if runtime_hook is not None:
                    runtime_hook.invalidate("MATCH_CHANGED")
                previous_match_id = runtime.match_id
                pending = None
                pending_before = None
                pending_completion_epoch = None
                closed_identities.clear()
                seen_results.clear()
                learned_result_regions.clear()
                full_result_scan_count = 0
                previous_capability_signature = None
                previous_shadow_generation = None
                previous_shadow_direction_signature = None
                previous_shadow_progress_signature = None
                previous_shadow_timing_signature = None
                previous_shadow_runtime_result_signature = None
                previous_shadow_rejection_signature = None

            stable_state_current = bool(
                last_state is not None
                and last_state.battle.session_key is not None
                and runtime.match_id == last_state.battle.session_key.match_id
            )
            direct_session = (
                poll.session_key
                if poll is not None
                and poll.combat_lifecycle is not None
                and poll.combat_lifecycle.state is CombatLifecycleState.ACTIVE
                else None
            )
            session = (
                last_state.battle.session_key
                if stable_state_current and last_state is not None
                else direct_session
            )
            if (
                session is None
                or runtime.match_id != session.match_id
                or not match_service_resolution.resolved
                or match_service_resolution.instance is None
                or not active_resolution.resolved
                or active_resolution.instance is None
                or not board_resolution.resolved
                or board_resolution.instance != session.board_instance
            ):
                if runtime_hook is not None:
                    if owned_poll:
                        _write(log, "qte_ownership_rejected",
                               providerReason=poll.reason if poll is not None else None,
                               providerSession=poll.session_key if poll is not None else None,
                               lifecycle=poll.combat_lifecycle if poll is not None else None,
                               control=poll.control_battle if poll is not None else None,
                               selectedSession=session, runtimeMatchId=runtime.match_id,
                               matchService=match_service_resolution, active=active_resolution,
                               board=board_resolution, ownedPoll=owned_poll)
                    runtime_hook.invalidate("ACTIVE_COMBAT_OWNERSHIP_INVALID")
                time.sleep(args.interval)
                continue
            if stable_state_current and last_state is not None:
                actor = last_state.battle.local_actor_number
            else:
                try:
                    actor = read_match_local_actor_number(
                        target.memory,
                        int(match_service_resolution.instance),
                        runtime.local_username,
                    )
                except (ExternalReadError, OSError, LayoutValidationError) as exc:
                    _write(
                        log,
                        "local_actor_read_rejected",
                        detail=str(exc),
                        transient=True,
                    )
                    if owned_poll:
                        reason = "QTE_CURRENT_ACTOR_UNREADABLE"
                        retain = getattr(
                            runtime_hook,
                            "retain_pre_action_after_transient_read_failure",
                            None,
                        )
                        if callable(retain) and retain(reason):
                            time.sleep(_poll_delay(args.interval, runtime_hook))
                            continue
                        runtime_hook.invalidate(reason)
                    time.sleep(args.interval)
                    continue
            if actor is None:
                if owned_poll:
                    runtime_hook.invalidate("QTE_CURRENT_ACTOR_UNAVAILABLE")
                time.sleep(args.interval)
                continue
            fallback_state = last_state if stable_state_current else None
            if owned_poll and not critical_poll:
                _write(log, "post_qte_provider_poll", reason=poll.reason,
                       session=session, currentBoardAvailable=fallback_state is not None,
                       control=poll.control_battle, providerMs=round(provider_poll_ms, 3))

            trace_runtime_stage("type_classes_begin")
            if pet_class is None:
                pet_class = target.resolver.resolve_type_info_class(
                    PET_USER_DTO_TYPE_INFO_RVA
                )
            if card_data_class is None:
                card_data_class = target.resolver.resolve_type_info_class(
                    CARD_DATA_TYPE_INFO_RVA
                )
            if card_ui_class is None:
                card_ui_class = target.resolver.resolve_type_info_class(
                    CARD_UI_TYPE_INFO_RVA
                )
            if dto_class is None:
                dto_class = target.resolver.resolve_type_info_class(
                    CHAT_MESSAGE_DTO_TYPE_INFO_RVA
                )
            if stats_class is None:
                stats_class = target.resolver.resolve_type_info_class(
                    ACTIVE_PLAYER_STATS_TYPE_INFO_RVA
                )
            trace_runtime_stage("type_classes_end")

            trace_runtime_stage("participant_snapshot_begin")
            current_resource = _participant_snapshot(
                target,
                active_instance=int(active_resolution.instance),
                stats_class=stats_class,
                local_actor_number=actor,
                fallback_state=fallback_state,
            )
            trace_runtime_stage("participant_snapshot_end")

            # A 1.7.4 skill response is a generic ChatMessageDTO envelope and
            # normally appears after ActiveDotSkillCard has already become
            # null.  Scan from the retained completed observation instead of
            # requiring the QTE object to remain active.
            should_scan_result = bool(
                pending is not None
                and pending.status is QteBindingStatus.COMPLETED_CURRENT
                and pending_completion_epoch is not None
                and dto_class is not None
                and now - last_result_scan >= 0.1
            )
            dispatcher_results: tuple[Any, ...] = ()
            dispatcher_diagnostics = None
            if should_scan_result and runtime_hook is not None:
                direct = getattr(runtime_hook, "dispatcher_qte_results", None)
                if callable(direct):
                    dispatcher_results = tuple(direct(session.match_id))
                    dispatcher_diagnostics = getattr(
                        runtime_hook, "dispatcher_tap_diagnostics", None
                    )
                    # Phase 3B.3 finishes at current runtime PERFECT and does
                    # not start a response tap. Other diagnostic observers may
                    # still supply a tap; an optional empty result must never
                    # trigger a broad response heap scan.
                    if (
                        bool(getattr(runtime_hook, "server_result_optional", False))
                        and not dispatcher_results
                    ):
                        should_scan_result = False
                    elif _defer_heap_result_scan(
                        dispatcher_available=True,
                        dispatcher_result_count=len(dispatcher_results),
                        completion_epoch=pending_completion_epoch,
                        observed_epoch=time.time(),
                    ):
                        should_scan_result = False
            if should_scan_result:
                last_result_scan = now
                result_scan_number += 1
                result_scan_started = time.monotonic()
                if dispatcher_results:
                    results = dispatcher_results
                    all_regions: tuple[Any, ...] = ()
                    full_result_scan = False
                    full_scan_direction = "dispatcher_owned_callback"
                    discovery_source = (
                        "UnityMainThreadDispatcher.PendingAction->"
                        "ChatService.__c__DisplayClass275_0.message"
                    )
                else:
                    all_regions = _regions(target, args.max_region_mib)
                    # MATCH_SKILL_USE_RES is a short-lived ChatMessageDTO. Do not
                    # dilute its scan cadence with regions learned only from the
                    # WsCombatBatch class: those are captured separately through
                    # direct owner roots and become relevant only to post-state.
                    message_hints = getattr(
                        provider, "chat_message_region_hints", ()
                    )
                    learned_result_regions.update(message_hints)
                    full_result_scan = _requires_full_qte_result_scan(
                        result_scan_number,
                        len(learned_result_regions),
                    )
                    if full_result_scan:
                        full_result_scan_count += 1
                    # Alternate the broad pass so a just-allocated DTO cannot be
                    # missed forever merely because its region was traversed before
                    # the server populated it.  Learned regions are still searched
                    # first inside _scan_qte_results.
                    full_scan_direction = (
                        "descending"
                        if full_result_scan and full_result_scan_count % 2 == 0
                        else "ascending"
                    )
                    scan_regions = (
                        tuple(reversed(all_regions))
                        if full_scan_direction == "descending"
                        else all_regions
                    )
                    results = _scan_qte_results(
                        target,
                        dto_class=dto_class,
                        match_id=session.match_id,
                        all_regions=scan_regions,
                        learned_regions=learned_result_regions,
                        full=full_result_scan,
                        chunk_mib=args.chunk_mib,
                    )
                    discovery_source = "bounded_heap_scan"
                result_scan_ms = (time.monotonic() - result_scan_started) * 1000
                _write(
                    log,
                    "qte_result_scan",
                    session=_session_text(session),
                    scanNumber=result_scan_number,
                    fullRequested=full_result_scan,
                    fullDirection=(
                        full_scan_direction if full_result_scan else None
                    ),
                    fullScanCount=full_result_scan_count,
                    learnedRegionCount=len(learned_result_regions),
                    learnedRegionBytes=sum(
                        region.size for region in learned_result_regions
                    ),
                    allRegionCount=len(all_regions),
                    resultCount=len(results),
                    elapsedMs=round(result_scan_ms, 3),
                    discoverySource=discovery_source,
                    dispatcherTap=dispatcher_diagnostics,
                )
                observed_epoch = time.time()
                for result in results:
                    if result.address in seen_results:
                        continue
                    seen_results.add(result.address)
                    payload_ints = dict(result.payload_ints)
                    response_skill_card_id = (
                        result.skill_card_id
                        if result.skill_card_id is not None
                        else payload_ints.get("skillCardId")
                    )
                    correlation = correlate_qte_response_envelope(
                        pending,
                        event_type=result.event_type,
                        match_id=result.match_id,
                        skill_card_id=response_skill_card_id,
                        qte_challenge_id=result.qte_challenge_id,
                        reject_reason=result.reject_reason,
                        payload_bools=result.payload_bools,
                        server_timestamp_epoch=_server_timestamp_epoch(result.timestamp),
                        completion_epoch=pending_completion_epoch,
                        observed_epoch=observed_epoch,
                    )
                    _write(
                        log,
                        "qte_result_message",
                        session=_session_text(session),
                        result=result,
                        correlation=correlation,
                        predicted=pending.predicted_timing_result,
                        displayed=(
                            pending.qte.displayed_timing_result
                            if pending.qte is not None
                            else None
                        ),
                        before=pending_before,
                        after={
                            "turn": runtime.turn,
                            "currentTurnPlayer": runtime.current_player,
                            **current_resource,
                        },
                    )
                    _notify_explicit_server_reject(runtime_hook, correlation, result)
                    if correlation.current:
                        direct_board = None
                        if runtime_hook is not None:
                            direct_board_reader = getattr(
                                runtime_hook,
                                "dispatcher_qte_board_snapshot",
                                None,
                            )
                            if callable(direct_board_reader):
                                direct_board = direct_board_reader(
                                    result.match_id, result.address
                                )
                        if direct_board is not None:
                            try:
                                result_board, result_board_accepted = (
                                    _offer_dispatcher_raw_qte_board_snapshot(
                                        provider,
                                        result,
                                        direct_board,
                                    )
                                )
                                _write(
                                    log,
                                    "qte_result_board_snapshot_offered",
                                    session=_session_text(session),
                                    responseAddress=hex_pointer(result.address),
                                    boardAddress=hex_pointer(
                                        result_board.board_token_address
                                    ),
                                    srvSeq=result_board.sequence,
                                    completeCells=len(result_board.cells),
                                    accepted=result_board_accepted,
                                    authority=(
                                        "ChatService.__c__DisplayClass275_0.json+"
                                        "MATCH_SKILL_USE_RES.matchPayload.board+"
                                        "MatchService._ackedSeqs"
                                    ),
                                )
                            except (LayoutValidationError, ValueError) as exc:
                                _write(
                                    log,
                                    "qte_result_board_snapshot_rejected",
                                    session=_session_text(session),
                                    responseAddress=hex_pointer(result.address),
                                    reason=str(exc),
                                )
                        else:
                            if board_payload_classes is None:
                                board_payload_classes = _resolve_newtonsoft_classes(target)
                            if board_payload_classes is None:
                                _write(
                                    log,
                                    "qte_result_board_snapshot_unavailable",
                                    session=_session_text(session),
                                    responseAddress=hex_pointer(result.address),
                                    reason="NEWTONSOFT_TYPE_INFO_UNAVAILABLE",
                                )
                            else:
                                try:
                                    result_board, result_board_accepted = (
                                        _offer_qte_result_board_snapshot(
                                            target,
                                            provider,
                                            result,
                                            classes=board_payload_classes,
                                        )
                                    )
                                    _write(
                                        log,
                                        "qte_result_board_snapshot_offered",
                                        session=_session_text(session),
                                        responseAddress=hex_pointer(result.address),
                                        boardAddress=hex_pointer(
                                            result_board.board_token_address
                                        ),
                                        srvSeq=result_board.sequence,
                                        completeCells=len(result_board.cells),
                                        accepted=result_board_accepted,
                                        authority=(
                                            "MATCH_SKILL_USE_RES.matchPayload.board+"
                                            "MatchService._ackedSeqs"
                                        ),
                                    )
                                except (
                                    ExternalReadError,
                                    OSError,
                                    LayoutValidationError,
                                    ValueError,
                                ) as exc:
                                    _write(
                                        log,
                                        "qte_result_board_snapshot_rejected",
                                        session=_session_text(session),
                                        responseAddress=hex_pointer(result.address),
                                        reason=str(exc),
                                    )
                        completed_qtes += 1
                        identity = pending.identity
                        shadow_result = None
                        resource_turn = None
                        if identity is not None:
                            closed_identities.add(identity)
                            server_timing = dict(result.payload_strings).get(
                                "timingResult"
                            )
                            shadow_result = shadow_observer.correlate_server_response(
                                generation=identity.observer_generation,
                                response_key=f"0x{result.address:016X}",
                                match_id=result.match_id,
                                skill_card_id=response_skill_card_id,
                                correlation=correlation,
                                server_timing_result=server_timing,
                            )
                            post_actor = (
                                actor
                                if runtime.current_player == runtime.local_username
                                else current_resource.get("bossActor")
                                if runtime.current_player
                                else None
                            )
                            automatic_effect_overlap = bool(
                                shadow_result is not None
                                and shadow_result.qte_family.value
                                == "AUTOMATIC_DOT_DESTRUCTION"
                                and pending_before is not None
                                and (
                                    current_resource["localHp"]
                                    != pending_before["localHp"]
                                    or current_resource["bossHp"]
                                    != pending_before["bossHp"]
                                    or current_resource["boardHash"]
                                    != pending_before["boardHash"]
                                    or runtime.turn != identity.turn_number
                                    or post_actor != identity.local_actor_number
                                )
                            )
                            resource_turn = shadow_observer.observe_resolution(
                                generation=identity.observer_generation,
                                mana_after=current_resource["mana"],
                                power_after=current_resource["power"],
                                post_resolution_turn=runtime.turn,
                                post_resolution_local_actor=post_actor,
                                concurrent_resource_change=automatic_effect_overlap,
                            )
                            _write(
                                log,
                                "qte_server_result_correlated",
                                session=_session_text(session),
                                generation=identity.observer_generation,
                                responseAddress=hex_pointer(result.address),
                                correlation=correlation,
                                serverResult=(
                                    shadow_result.server_resolved_result
                                    if shadow_result is not None
                                    else None
                                ),
                                serverResultRaw=server_timing,
                                timingEchoAvailable=server_timing is not None,
                            )
                            if resource_turn is not None:
                                resource_delta, turn_semantics = resource_turn
                                _write(
                                    log,
                                    "pet_skill_resource_delta",
                                    session=_session_text(session),
                                    generation=identity.observer_generation,
                                    resourceDelta=resource_delta,
                                )
                                _write(
                                    log,
                                    "pet_skill_turn_semantics_observed",
                                    session=_session_text(session),
                                    generation=identity.observer_generation,
                                    turnSemantics=turn_semantics,
                                )
                            if runtime_hook is not None:
                                result_callback = getattr(
                                    runtime_hook, "correlated_result", None
                                )
                                if callable(result_callback):
                                    result_callback(
                                        shadow_observer.pending_completed
                                        or shadow_result,
                                        sampled_monotonic=now,
                                        game_state=fallback_state,
                                        resources=current_resource,
                                        runtime=runtime,
                                        control_battle=(poll.control_battle if owned_poll else None),
                                    )
                        _write(
                            log,
                            "qte_closed",
                            completedQtes=completed_qtes,
                            session=_session_text(session),
                            generation=(
                                identity.observer_generation
                                if identity is not None
                                else None
                            ),
                            correlationProvenance=correlation.provenance,
                            predictedTiming=pending.predicted_timing_result,
                            displayedTiming=(
                                pending.qte.displayed_timing_result
                                if pending.qte is not None
                                else None
                            ),
                            rawDisplayedTiming=(
                                pending.qte.displayed_timing_text
                                if pending.qte is not None
                                else None
                            ),
                            resourceDelta={
                                "mana": (
                                    None
                                    if pending_before is None
                                    or pending_before["mana"] is None
                                    or current_resource["mana"] is None
                                    else current_resource["mana"]
                                    - pending_before["mana"]
                                ),
                                "power": (
                                    None
                                    if pending_before is None
                                    or pending_before["power"] is None
                                    or current_resource["power"] is None
                                    else current_resource["power"]
                                    - pending_before["power"]
                                ),
                                "localHp": (
                                    None
                                    if pending_before is None
                                    or pending_before["localHp"] is None
                                    or current_resource["localHp"] is None
                                    else current_resource["localHp"]
                                    - pending_before["localHp"]
                                ),
                                "bossHp": (
                                    None
                                    if pending_before is None
                                    or pending_before["bossHp"] is None
                                    or current_resource["bossHp"] is None
                                    else current_resource["bossHp"]
                                    - pending_before["bossHp"]
                                ),
                            },
                            boardHashBefore=(
                                pending_before["boardHash"]
                                if pending_before is not None
                                else None
                            ),
                            boardHashAfter=current_resource["boardHash"],
                            turnBefore=(
                                pending_before["turn"]
                                if pending_before is not None
                                else None
                            ),
                            turnAfter=runtime.turn,
                            currentPlayerAfter=runtime.current_player,
                        )
                        pending = None
                        pending_before = None
                        pending_completion_epoch = None
                        break
            try:
                trace_runtime_stage("source_pet_begin")
                pet = read_player_pet_skill(
                    target.memory,
                    int(active_resolution.instance),
                    expected_pet_class=pet_class,
                    expected_card_class=card_data_class,
                )
                trace_runtime_stage("source_pet_end")
            except (ExternalReadError, OSError, LayoutValidationError) as exc:
                _write(log, "pet_read_rejected", detail=str(exc), session=_session_text(session))
                pet = None
            pet_skill_valid = bool(
                pet is not None
                and pet.skill_card_id is not None
                and pet.card_data is not None
                and pet.card_identity_matches is True
            )
            if not pet_skill_valid:
                # A live evolution does not replace Active.playerPets: it can
                # remain the ordinary source pet with no skillCardId.  Keep
                # observing CardUI instead of blocking the QTE path here.
                signature = (
                    pet.address if pet else None,
                    pet.pet_id if pet else None,
                    "source_pet_skill_missing",
                )
                if signature != previous_pet_signature:
                    _write(
                        log,
                        "source_pet_skill_unavailable",
                        session=_session_text(session),
                        pet=pet,
                        nonBlocking=True,
                    )
                    previous_pet_signature = signature

            # The ordinary GameState card tuple intentionally excludes the
            # post-Fusion Pet Skill so BASIC cannot treat it as CAST.  The
            # memory provider exposes that exact CardUI/Button through a
            # separate observation-only channel for the 3B harnesses.
            runtime_skill_cards_by_identity = {
                (card.object_address, card.data_address): card
                for card in provider.observed_pet_skill_cards
            }
            for card in (fallback_state.cards if fallback_state is not None else ()):
                if card.element_type.upper() in DOT_SKILL_ELEMENT_TYPES:
                    runtime_skill_cards_by_identity.setdefault(
                        (card.object_address, card.data_address), card
                    )
            runtime_skill_cards = tuple(runtime_skill_cards_by_identity.values())
            live_skill_candidates = [
                live_pet_skill_card_from_state(
                    card,
                    session_key=session,
                    active_instance=int(active_resolution.instance),
                )
                for card in runtime_skill_cards
            ]
            if len(runtime_skill_cards) == 1:
                runtime_card = runtime_skill_cards[0]
                skill_signature = (
                    session,
                    runtime_card.card_id,
                    runtime_card.data_address,
                    runtime_card.element_type,
                    runtime_card.skill_type,
                    runtime_card.mana_cost,
                    runtime_card.power_cost,
                    runtime_card.interactable,
                )
                if skill_signature != previous_skill_signature:
                    _write(
                        log,
                        "evolved_skill_card_available",
                        session=_session_text(session),
                        turn=runtime.turn,
                        localActor=actor,
                        sourcePet=pet,
                        card=runtime_card,
                        resource={
                            "mana": current_resource["mana"],
                            "power": current_resource["power"],
                        },
                    )
                    previous_skill_signature = skill_signature
            elif len(runtime_skill_cards) > 1:
                skill_signature = (
                    session,
                    "ambiguous",
                    tuple(
                        (card.card_id, card.data_address)
                        for card in runtime_skill_cards
                    ),
                )
                if skill_signature != previous_skill_signature:
                    _write(
                        log,
                        "evolved_skill_card_ambiguous",
                        session=_session_text(session),
                        cards=runtime_skill_cards,
                    )
                    previous_skill_signature = skill_signature

            if pet_skill_valid:
                matching_card = next(
                    (
                        card
                        for card in runtime_skill_cards
                        if card.card_id == pet.skill_card_id
                        or card.data_address == pet.card_data_address
                    ),
                    None,
                )
                pet_signature = (
                    session,
                    pet.pet_id,
                    pet.skill_card_id,
                    pet.card_data.card_id,
                    pet.card_data.skill_type,
                    pet.card_data.mana_cost,
                    pet.card_data.power_cost,
                    matching_card.interactable if matching_card else None,
                )
                if pet_signature != previous_pet_signature:
                    _write(
                        log,
                        "pet_skill_identity",
                        session=_session_text(session),
                        turn=runtime.turn,
                        localActor=actor,
                        pet=pet,
                        currentCardUi=(
                            {
                                "address": hex_pointer(matching_card.object_address),
                                "interactable": matching_card.interactable,
                                "pending": matching_card.action_pending,
                                "usedThisTurn": matching_card.has_used_this_turn,
                                "usedThisMatch": matching_card.has_used_this_match,
                            }
                            if matching_card is not None
                            else None
                        ),
                        resource={
                            "mana": current_resource["mana"],
                            "power": current_resource["power"],
                        },
                    )
                    previous_pet_signature = pet_signature

            challenge_read_error = None
            try:
                trace_runtime_stage("server_challenge_begin")
                challenge = read_server_qte_challenge(
                    target.memory,
                    int(match_service_resolution.instance),
                    match_id=runtime.match_id or "",
                )
                trace_runtime_stage("server_challenge_end")
            except (ExternalReadError, OSError, LayoutValidationError) as exc:
                challenge = None
                challenge_read_error = f"{type(exc).__name__}: {exc}"
                # A failed stable read is not evidence that the server challenge
                # disappeared.  Preserve the exception so the tracker can bridge
                # at most one sample from an already-bound, still-exact CardUI
                # generation instead of relabelling it WRONG_SESSION.
                _write(
                    log,
                    "server_qte_challenge_read_rejected",
                    session=_session_text(session),
                    turn=runtime.turn,
                    detail=challenge_read_error,
                    boundGeneration=(tracker.identity.observer_generation
                                     if tracker.identity is not None else None),
                    transient=True,
                )
            candidates = []
            active_qte_card = None
            qte_sampled_monotonic = time.monotonic()
            audition_stage_resolution = None
            if audition_mode is AuditionMode.V3_TWO_DIRECTION:
                trace_runtime_stage("audition_stage_singleton_begin")
                audition_stage_resolution = target.resolver.resolve_singleton(
                    ACTIVE_AUDITION_STAGE
                )
                trace_runtime_stage("audition_stage_singleton_end")
            trace_runtime_stage("active_qte_singleton_begin")
            active_qte_resolution = target.resolver.resolve_singleton(
                ACTIVE_DOT_SKILL_CARD
            )
            trace_runtime_stage("active_qte_singleton_end")
            if (
                active_qte_resolution.resolved
                and active_qte_resolution.instance is not None
                and card_ui_class is not None
            ):
                try:
                    trace_runtime_stage("active_qte_read_begin")
                    if audition_mode is AuditionMode.V3_TWO_DIRECTION:
                        if (
                            audition_stage_resolution is None
                            or not audition_stage_resolution.resolved
                            or audition_stage_resolution.instance is None
                        ):
                            raise LayoutValidationError(
                                "Audition V3 stage is not current"
                            )
                        if audition_stage_class is None:
                            audition_stage_class = target.resolver.resolve_type_info_class(
                                AUDITION_STAGE_TYPE_INFO_RVA
                            )
                        if audition_challenge_class is None:
                            audition_challenge_class = target.resolver.resolve_type_info_class(
                                AUDITION_CHALLENGE_TYPE_INFO_RVA
                            )
                        if audition_stage_class is None or audition_challenge_class is None:
                            raise LayoutValidationError(
                                "Audition V3 type information is unavailable"
                            )
                        source_challenge = challenge or tracker.bound_challenge
                        if source_challenge is None:
                            raise LayoutValidationError(
                                "Audition V3 server challenge is unavailable"
                            )
                        qte, challenge = read_audition_v3_qte(
                            target.memory,
                            int(audition_stage_resolution.instance),
                            server_challenge=source_challenge,
                            expected_stage_class=audition_stage_class,
                            expected_challenge_class=audition_challenge_class,
                            expected_card_ui_class=card_ui_class,
                            expected_card_ui_address=int(active_qte_resolution.instance),
                            expected_board=session.board_instance,
                            expected_active=int(active_resolution.instance),
                            require_button=True,
                        )
                    else:
                        qte = read_card_ui_qte(
                            target.memory,
                            int(active_qte_resolution.instance),
                            expected_class=card_ui_class,
                            expected_board=session.board_instance,
                            expected_active=int(active_resolution.instance),
                            expected_card_data=None,
                            require_button=True,
                        )
                    active_qte_card = read_qte_card_data(
                        target.memory,
                        qte,
                        expected_card_class=card_data_class,
                    )
                    candidates.append(qte)
                    # During a live challenge ActiveDotSkillCard is the exact
                    # current QTE owner.  If Unity represents it with a second
                    # CardUI wrapper for the same CardData, do not manufacture
                    # an ambiguity against the pre-click strip wrapper.
                    live_skill_candidates = [
                        item
                        for item in live_skill_candidates
                        if item.card_data.address != active_qte_card.address
                    ]
                    live_skill_candidates.append(
                        LivePetSkillCard(
                            session_key=session,
                            card_data=active_qte_card,
                            card_ui_address=qte.address,
                            board_instance=qte.board_instance,
                            active_instance=qte.active_instance,
                            button_address=qte.button_address,
                            button_interactable=qte.button_interactable,
                            button_validated=qte.button_validated,
                            source="CardUI.ActiveDotSkillCard",
                        )
                    )
                    trace_runtime_stage("active_qte_read_end")
                except (ExternalReadError, OSError, LayoutValidationError) as exc:
                    _write(
                        log,
                        "active_qte_rejected",
                        session=_session_text(session),
                        object=hex_pointer(active_qte_resolution.instance),
                        detail=str(exc),
                    )
            capability = capability_provider.observe(
                observed_at=time.time(),
                current_session=session,
                source_pet=pet,
                candidates=live_skill_candidates,
            )
            if runtime_hook is not None:
                context_callback = getattr(runtime_hook, "runtime_context", None)
                if callable(context_callback):
                    context_callback(
                        sampled_monotonic=qte_sampled_monotonic,
                        control_sampled_monotonic=(poll_started if owned_poll else None),
                        session=session,
                        runtime=runtime,
                        local_actor=actor,
                        resources=current_resource,
                        capability=capability,
                        live_cards=runtime_skill_cards,
                        card_diagnostics={key: value for key, value in provider.scan_diagnostics.items()
                                          if key.startswith("runtimeCardLayout")
                                          or key == "nativeCardDiscoveryReason"},
                        game_state=fallback_state,
                        # A normal provider publication is the only current,
                        # playable board sample.  Retained ``last_state`` is
                        # useful to the QTE primitive but must not be mistaken
                        # for post-PERFECT evidence by the 3C.0 audit.
                        provider_state_fresh=bool(
                            poll is not None
                            and poll.state is not None
                            and poll.state.phase is GamePhase.COMBAT
                        ),
                        provider_reason=(poll.reason if poll is not None else None),
                        game_state_sampled_monotonic=(
                            poll_started
                            if poll is not None
                            and poll.state is not None
                            and poll.state.phase is GamePhase.COMBAT
                            else None
                        ),
                        control_battle=(poll.control_battle if owned_poll else None),
                        lifecycle_valid=(
                            runtime.match_id == session.match_id
                            and match_service_resolution.resolved
                            and active_resolution.resolved
                            and board_resolution.instance == session.board_instance
                        ),
                    )
                    # Clear the deduplication key only after the whole current
                    # ownership/runtime/actor/resource context has succeeded,
                    # not merely after its first control sub-read.  Persistent
                    # torn actor/runtime samples therefore remain bounded in
                    # the log while still being retried by fast-watch.
                    read_success = getattr(
                        runtime_hook, "note_control_read_success", None
                    )
                    if callable(read_success):
                        read_success()
            capability_signature = (
                capability.status,
                capability.session_key,
                capability.card_data_address,
                capability.live_card_address,
                capability.live_card_actionable,
                capability.effective_mana_cost,
                capability.effective_power_cost,
                capability.stale_reason,
            )
            if capability_signature != previous_capability_signature:
                _write(
                    log,
                    "pet_skill_capability_observed",
                    session=_session_text(session),
                    capability=capability,
                )
                if capability.live_card_present:
                    _write(
                        log,
                        "pet_skill_live_card_observed",
                        session=_session_text(session),
                        cardUi=hex_pointer(capability.live_card_address),
                        button=hex_pointer(capability.live_button_address),
                        interactable=capability.live_card_actionable,
                        observationOnly=True,
                    )
                elif capability.status in {
                    PetSkillCapabilityStatus.AMBIGUOUS,
                    PetSkillCapabilityStatus.STALE,
                    PetSkillCapabilityStatus.INVALID,
                }:
                    _write(
                        log,
                        "qte_ambiguous"
                        if capability.status is PetSkillCapabilityStatus.AMBIGUOUS
                        else "qte_stale_rejected",
                        session=_session_text(session),
                        capabilityStatus=capability.status,
                        detail=capability.stale_reason,
                    )
                previous_capability_signature = capability_signature
            if not candidates or active_qte_card is None:
                # Only a proven null singleton is an inactive edge.  A failed
                # or torn read must not manufacture freshness mid-QTE.
                v3_inactive = bool(
                    audition_mode is AuditionMode.V3_TWO_DIRECTION
                    and audition_stage_resolution is not None
                    and audition_stage_resolution.instance is None
                    and audition_stage_resolution.status in {
                        "instance_null",
                        "static_fields_null",
                        "type_info_uninitialized",
                        "type_info_uninitialized_or_invalid",
                    }
                )
                v2_inactive = bool(
                    audition_mode is AuditionMode.V2_FOUR_DIRECTION
                    and active_qte_resolution.status == "instance_null"
                    and active_qte_resolution.instance is None
                )
                if v3_inactive or v2_inactive:
                    tracker.note_inactive(session)
                    shadow_observer.note_inactive(session)
                    if runtime_hook is not None:
                        runtime_hook.inactive(session)
                elif runtime_hook is not None:
                    unreadable = getattr(runtime_hook, "unreadable", None)
                    if callable(unreadable):
                        unreadable("ACTIVE_QTE_UNREADABLE_OR_AMBIGUOUS")
                    else:
                        runtime_hook.invalidate("ACTIVE_QTE_UNREADABLE_OR_AMBIGUOUS")
                time.sleep(args.interval)
                continue

            qte_card_signature = (
                session,
                active_qte_card.card_id,
                active_qte_card.address,
                active_qte_card.element_type,
                active_qte_card.skill_type,
                active_qte_card.mana_cost,
                active_qte_card.power_cost,
            )
            if qte_card_signature != previous_skill_signature:
                _write(
                    log,
                    "active_qte_skill_identity",
                    session=_session_text(session),
                    turn=runtime.turn,
                    localActor=actor,
                    sourcePet=pet,
                    card=active_qte_card,
                    resource={
                        "mana": current_resource["mana"],
                        "power": current_resource["power"],
                    },
                )
                previous_skill_signature = qte_card_signature

            if runtime.turn is None:
                rejection_signature = (session, "TURN_UNKNOWN")
                if rejection_signature != previous_shadow_rejection_signature:
                    _write(
                        log,
                        "qte_stale_rejected",
                        session=_session_text(session),
                        status="TURN_UNKNOWN",
                        detail="current MatchService turn is unavailable",
                    )
                    previous_shadow_rejection_signature = rejection_signature
                time.sleep(args.interval)
                continue

            context = QteBindingContext(
                session_key=session,
                local_actor_number=actor,
                skill_card_id=int(active_qte_card.card_id),
                card_data_address=int(active_qte_card.address),
                turn_number=int(runtime.turn),
                player_mana=current_resource["mana"],
                player_power=current_resource["power"],
            )
            if challenge_read_error is not None:
                observation = tracker.observe_after_server_challenge_read_failure(
                    context,
                    candidates,
                    element_type=active_qte_card.element_type,
                    read_error=challenge_read_error,
                )
            else:
                observation = tracker.observe(
                    context,
                    candidates,
                    challenge,
                    element_type=active_qte_card.element_type,
                )
            shadow = shadow_observer.observe(
                observed_at=time.time(),
                session_key=session,
                observation=observation,
                capability=capability,
                player_mana=current_resource["mana"],
                player_power=current_resource["power"],
            )
            if runtime_hook is not None:
                runtime_hook.snapshot(
                    shadow,
                    lifecycle_valid=(
                        runtime.match_id == session.match_id
                        and match_service_resolution.resolved
                        and active_resolution.resolved
                        and board_resolution.instance == session.board_instance
                    ),
                )
            if critical_poll:
                _write(log, "qte_critical_poll", providerMs=round(provider_poll_ms, 3),
                       cycleMs=round((time.monotonic() - poll_started) * 1000, 3),
                       sampleAgeMs=round((time.monotonic() - qte_sampled_monotonic) * 1000, 3),
                       currentIndex=shadow.current_index, correctCount=shadow.correct_count,
                       elapsed=shadow.current_elapsed)
            if shadow.observationally_current:
                if shadow.qte_generation != previous_shadow_generation:
                    _write(
                        log,
                        "qte_generation_started",
                        session=_session_text(session),
                        snapshot=shadow,
                    )
                    _write(
                        log,
                        "qte_perfect_window_observed",
                        session=_session_text(session),
                        generation=shadow.qte_generation,
                        perfectStart=shadow.perfect_start,
                        perfectEnd=shadow.perfect_end,
                        recommendedConfirmElapsed=shadow.recommended_confirm_elapsed,
                        source="MatchService.ServerQteWindow+CardUI",
                    )
                    previous_shadow_generation = shadow.qte_generation
                    previous_shadow_direction_signature = None
                    previous_shadow_progress_signature = None
                    previous_shadow_timing_signature = None
                    previous_shadow_runtime_result_signature = None
                direction_signature = (
                    shadow.qte_generation,
                    shadow.current_index,
                    shadow.expected_direction,
                )
                if direction_signature != previous_shadow_direction_signature:
                    _write(
                        log,
                        "qte_shadow_direction",
                        session=_session_text(session),
                        generation=shadow.qte_generation,
                        index=shadow.current_index,
                        expectedDirection=shadow.expected_direction,
                        shadowOnly=True,
                    )
                    previous_shadow_direction_signature = direction_signature
                progress_signature = (
                    shadow.qte_generation,
                    shadow.current_index,
                    shadow.correct_count,
                    shadow.raw_presses,
                    shadow.completed,
                )
                if progress_signature != previous_shadow_progress_signature:
                    _write(
                        log,
                        "qte_progress_observed",
                        session=_session_text(session),
                        generation=shadow.qte_generation,
                        currentIndex=shadow.current_index,
                        correctCount=shadow.correct_count,
                        rawPresses=shadow.raw_presses,
                        normalizedPresses=shadow.presses,
                        completed=shadow.completed,
                    )
                    if shadow.completed:
                        compared = min(len(shadow.sequence), len(shadow.presses))
                        direction_matches = sum(
                            1
                            for expected, pressed in zip(
                                shadow.sequence, shadow.presses
                            )
                            if expected == pressed
                        )
                        _write(
                            log,
                            "qte_generation_completed",
                            session=_session_text(session),
                            generation=shadow.qte_generation,
                            qteElapsedMs=shadow.qte_elapsed_ms,
                            predicted=shadow.predicted_timing_result,
                            runtimeDisplay=shadow.runtime_display_result,
                            expectedDirections=shadow.sequence,
                            recordedPresses=shadow.presses,
                            comparedDirections=compared,
                            shadowDirectionMatches=direction_matches,
                            shadowDirectionMismatches=compared - direction_matches,
                            completeSequenceAgreement=(
                                shadow.sequence == shadow.presses
                            ),
                        )
                    previous_shadow_progress_signature = progress_signature
                timing_signature = (
                    shadow.qte_generation,
                    shadow.timing_region,
                    shadow.predicted_timing_result,
                )
                if timing_signature != previous_shadow_timing_signature:
                    _write(
                        log,
                        "qte_shadow_timing_prediction",
                        session=_session_text(session),
                        generation=shadow.qte_generation,
                        elapsed=shadow.current_elapsed,
                        timingRegion=shadow.timing_region,
                        prediction=shadow.predicted_timing_result,
                        recommendedConfirmElapsed=shadow.recommended_confirm_elapsed,
                        shadowOnly=True,
                    )
                    previous_shadow_timing_signature = timing_signature
                runtime_result_signature = (
                    shadow.qte_generation,
                    shadow.runtime_result_text,
                    shadow.runtime_display_result,
                )
                if (
                    shadow.runtime_display_result is not None
                    and runtime_result_signature
                    != previous_shadow_runtime_result_signature
                ):
                    _write(
                        log,
                        "qte_runtime_result_observed",
                        session=_session_text(session),
                        generation=shadow.qte_generation,
                        rawText=shadow.runtime_result_text,
                        runtimeResult=shadow.runtime_display_result,
                        prediction=shadow.predicted_timing_result,
                        consistent=shadow.prediction_runtime_consistent,
                    )
                    previous_shadow_runtime_result_signature = runtime_result_signature
            elif shadow.evidence_status in {
                QteEvidenceStatus.STALE,
                QteEvidenceStatus.AMBIGUOUS,
            }:
                rejection_signature = (
                    session,
                    shadow.evidence_status,
                    shadow.ownership_status,
                    shadow.stale_reason,
                )
                if rejection_signature != previous_shadow_rejection_signature:
                    _write(
                        log,
                        "qte_ambiguous"
                        if shadow.evidence_status is QteEvidenceStatus.AMBIGUOUS
                        else "qte_stale_rejected",
                        session=_session_text(session),
                        status=shadow.ownership_status,
                        detail=shadow.stale_reason,
                    )
                    previous_shadow_rejection_signature = rejection_signature
            qte_signature = (
                observation.status,
                observation.identity,
                observation.qte.current_index if observation.qte else None,
                observation.qte.correct_count if observation.qte else None,
                observation.qte.finished if observation.qte else None,
                observation.qte.qte_presses if observation.qte else (),
                observation.qte.displayed_timing_text if observation.qte else None,
                observation.qte.displayed_timing_result if observation.qte else None,
                observation.predicted_timing_result,
            )
            if qte_signature != previous_qte_signature:
                _write(
                    log,
                    "qte_observation",
                    session=_session_text(session),
                    turn=runtime.turn,
                    currentTurnPlayer=runtime.current_player,
                    observation=observation,
                    playerResource=current_resource,
                )
                previous_qte_signature = qte_signature

            if (
                observation.current
                and observation.identity not in closed_identities
            ):
                if pending is None or pending.identity != observation.identity:
                    pending_before = {
                        "turn": runtime.turn,
                        "currentTurnPlayer": runtime.current_player,
                        **current_resource,
                    }
                    result_scan_number = 0
                    full_result_scan_count = 0
                    last_result_scan = 0.0
                pending = observation
                if (
                    observation.status is QteBindingStatus.COMPLETED_CURRENT
                    and pending_completion_epoch is None
                ):
                    pending_completion_epoch = time.time()

            time.sleep(_poll_delay(args.interval, runtime_hook))

        if runtime_hook is not None:
            runtime_hook.stop("HARNESS_STOPPED")
        _write(
            log,
            "observer_stopped",
            completedQtes=completed_qtes,
            runtimeHook=(runtime_hook.name if runtime_hook is not None else None),
            runtimeHookSummary=(
                runtime_hook.summary if runtime_hook is not None else None
            ),
        )
        print(f"Observer stopped; QTE correlated: {completed_qtes}", flush=True)
        return 0


def main() -> int:
    try:
        return run(build_parser().parse_args())
    except (ProcessProbeError, OSError, ValueError) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
