#!/usr/bin/env python3
"""Phase 2C.1 memory -> gate -> V1 solver -> F8 -> one foreground swap."""

from __future__ import annotations

import argparse
from dataclasses import asdict, dataclass, is_dataclass, replace
from datetime import datetime
from enum import Enum
import json
from pathlib import Path
import sys
import time
from typing import Any, Sequence

try:
    import winsound
except ImportError:  # pragma: no cover - Windows-only runtime tool
    winsound = None


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.action_control import (  # noqa: E402
    AckStatus,
    ActionIdentity,
    ActionLock,
    SkipTracker,
    invalidate_pending_for_sequence_desync,
)
from pokiguard_v2.actionability import (  # noqa: E402
    ActionabilityGate,
    GateContext,
    GateReason,
)
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
    ProviderSetupError,
    utc_timestamp,
)
from pokiguard_v2.state import GamePhase, GameState  # noqa: E402
from pokiguard_v2.sequence_desync_artifacts import (  # noqa: E402
    write_sequence_desync_artifact,
)
from pokiguard_v2.v1_solver_adapter import (  # noqa: E402
    ShadowDecision,
    V1ShadowSession,
    V1SolverAdapter,
)
from pokiguard_v2.win32_input import (  # noqa: E402
    BoardCalibration,
    CoordinatePlan,
    CoordinateSafetyError,
    ForegroundClickExecutor,
    HotkeyEdges,
    NativeWin32Backend,
    WindowBinding,
    find_window_for_pid,
    map_swap_to_pixels,
)
from pokiguard_v2.win32_screenshot import capture_client_png  # noqa: E402
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.runtime_common import attach_target, default_log_path, hex_pointer  # noqa: E402
from tools.sequence_desync_runtime import RuntimeSequenceMonitor  # noqa: E402


@dataclass(frozen=True)
class Proposal:
    identity: ActionIdentity
    state: GameState
    decision: ShadowDecision
    solver_session_before: V1ShadowSession
    solver_session_after: V1ShadowSession
    coordinate_plan: CoordinatePlan
    created_at: float


@dataclass
class Counters:
    proposals: int = 0
    confirmations: int = 0
    proposal_expired: int = 0
    actions_sent: int = 0
    acknowledged: int = 0
    timeouts: int = 0
    input_failures: int = 0
    partial_inputs: int = 0
    duplicate_inputs: int = 0
    dry_run_prepared: int = 0
    auto_pauses: int = 0
    sequence_desync_detections: int = 0
    proposals_invalidated_sequence_desync: int = 0
    actions_rejected_sequence_desync: int = 0


def _jsonable(value: Any) -> Any:
    if is_dataclass(value):
        return _jsonable(asdict(value))
    if isinstance(value, Enum):
        return value.value
    if isinstance(value, dict):
        return {str(key): _jsonable(item) for key, item in value.items()}
    if isinstance(value, (tuple, list, set)):
        return [_jsonable(item) for item in value]
    return value


def _write(log: Any, event: str, **fields: Any) -> None:
    log.write(
        json.dumps(
            {"timestamp": utc_timestamp(), "event": event, **_jsonable(fields)},
            ensure_ascii=False,
            separators=(",", ":"),
        )
        + "\n"
    )


def _signal_proposal(enabled: bool) -> bool:
    """Audibly distinguish a ready proposal from premature F8 presses."""

    if not enabled or winsound is None:
        return False
    try:
        winsound.Beep(880, 120)
        return True
    except RuntimeError:
        return False


def _signal_recovery_required(enabled: bool) -> bool:
    if not enabled or winsound is None:
        return False
    try:
        winsound.Beep(440, 180)
        winsound.Beep(330, 260)
        return True
    except RuntimeError:
        return False


def _state_identity(state: GameState) -> tuple[Any, int, str] | None:
    return state.dedup_key


def _copy_solver_session(value: V1ShadowSession) -> V1ShadowSession:
    return V1ShadowSession(value.consecutive_skips, value.published_turns)


def _decide_without_committing(
    adapter: V1SolverAdapter,
    state: GameState,
    session: V1ShadowSession,
) -> tuple[ShadowDecision, V1ShadowSession, V1ShadowSession]:
    before = _copy_solver_session(session)
    after = _copy_solver_session(before)
    decision = adapter.decide(state, session=after)
    return decision, before, after


def _same_source(state: GameState, identity: ActionIdentity) -> bool:
    battle = state.battle
    return bool(
        state.phase is GamePhase.COMBAT
        and battle.session_key == identity.session_key
        and battle.srv_seq == identity.source_srv_seq
        and battle.board_hash == identity.source_board_hash
    )


def _gate_context(
    provider: MemoryBoardStateProvider,
    executor: ForegroundClickExecutor,
    binding: WindowBinding,
    action_lock: ActionLock,
    skips: SkipTracker,
    sequence_desync: Any | None = None,
) -> tuple[GateContext, Any]:
    window = executor.window_status(binding)
    return (
        GateContext(
            current_session=provider.current_session_key,
            game_foreground=window.foreground,
            window_valid=window.valid,
            input_locked=action_lock.locked,
            auto_paused=skips.auto_paused,
            sequence_desync=sequence_desync,
        ),
        window,
    )


def _coordinate_plan(
    decision: ShadowDecision,
    calibration: BoardCalibration,
    window: Any,
    backend: NativeWin32Backend,
) -> CoordinatePlan:
    if decision.first is None or decision.second is None:
        raise CoordinateSafetyError("solver did not produce a SWAP")
    if window.geometry is None:
        raise CoordinateSafetyError("game client geometry is unavailable")
    return map_swap_to_pixels(
        decision.first,
        decision.second,
        calibration,
        window.geometry,
        virtual_screen=backend.virtual_screen(),
    )


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(
        description="Phase 2C.1 safe single-step board swap (F8 confirm, F9 stop)"
    )
    mode = parser.add_mutually_exclusive_group(required=True)
    mode.add_argument(
        "--single-step",
        action="store_true",
        help="F8 revalidates and sends exactly one two-click swap",
    )
    mode.add_argument(
        "--dry-run",
        action="store_true",
        help="F8 revalidates every gate/coordinate but never clicks",
    )
    parser.add_argument("--v1-root", type=Path, default=Path(r"D:\PokiguardAuto"))
    parser.add_argument("--log", type=Path)
    parser.add_argument("--scan-interval", type=float, default=0.10)
    parser.add_argument("--ack-timeout", type=float, default=7.0)
    parser.add_argument("--max-actions", type=int, default=0)
    parser.add_argument("--timeout", type=float, default=0.0)
    parser.add_argument(
        "--no-beep",
        action="store_true",
        help="disable the short ready beep emitted for each new proposal",
    )
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    return parser


def run(args: argparse.Namespace) -> int:
    if not 0.05 <= args.scan_interval <= 2.0:
        raise ValueError("--scan-interval must be between 0.05 and 2 seconds")
    if not 1.0 <= args.ack_timeout <= 30.0:
        raise ValueError("--ack-timeout must be between 1 and 30 seconds")
    if args.max_actions < 0 or args.timeout < 0:
        raise ValueError("action/time limits cannot be negative")

    adapter = V1SolverAdapter(args.v1_root)
    config = adapter.config
    calibration = BoardCalibration(
        float(config.get("board_first_center_x", 0.3620)),
        float(config.get("board_first_center_y", 0.1625)),
        float(config.get("board_step_x", 0.0393)),
        float(config.get("board_step_y", 0.0787)),
    )
    calibration.validate()
    click_delay = float(config.get("click_delay_seconds", 0.35))
    cursor_settle = float(config.get("cursor_settle_seconds", 0.06))
    log_path = (
        args.log
        or PROJECT_ROOT
        / "logs"
        / f"phase2c1_{datetime.now():%Y%m%d_%H%M%S}.jsonl"
    ).resolve()
    log_path.parent.mkdir(parents=True, exist_ok=True)

    backend = NativeWin32Backend()
    hotkeys = HotkeyEdges()
    action_lock = ActionLock(args.ack_timeout)
    skips = SkipTracker()
    counters = Counters()

    with attach_target() as target, log_path.open(
        "a", encoding="utf-8", buffering=1
    ) as log:
        binding = find_window_for_pid(target.pid, backend)
        executor = ForegroundClickExecutor(
            backend,
            click_delay_seconds=click_delay,
            cursor_settle_seconds=cursor_settle,
        )
        initial_window = executor.window_status(binding)
        if not initial_window.valid or initial_window.geometry is None:
            raise RuntimeError(f"game window is not safe: {initial_window.reason}")
        provider = MemoryBoardStateProvider(
            target,
            MemoryProviderConfig(
                max_region_mib=args.max_region_mib,
                chunk_mib=args.chunk_mib,
                required_confirmations=2,
                require_lobby_start=True,
            ),
        )
        sequence_monitor = RuntimeSequenceMonitor(
            target,
            max_region_mib=args.max_region_mib,
            chunk_mib=args.chunk_mib,
        )
        mode = "SINGLE_STEP" if args.single_step else "DRY_RUN"
        _write(
            log,
            "controller_started",
            mode=mode,
            pid=target.pid,
            gameAssemblyBase=hex_pointer(target.game_assembly.base),
            processAccess=["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"],
            inputApi=(
                "SetCursorPos+mouse_event" if args.single_step else "NONE"
            ),
            hotkeys={"confirm": "F8", "stop": "F9"},
            window=binding,
            clientGeometry=initial_window.geometry,
            calibration=calibration,
            clickDelaySeconds=click_delay,
            acknowledgementTimeoutSeconds=args.ack_timeout,
            cardFusionMode="READ_LOG_ONLY",
        )
        print(f"Phase 2C.1 {mode}; log: {log_path}", flush=True)
        print(
            "Keep Pokiguard foreground. F8 confirms ONE proposal; F9/Ctrl+C stops.",
            flush=True,
        )

        started = time.monotonic()
        solver_session = V1ShadowSession()
        pending_solver_session: V1ShadowSession | None = None
        pending_source_state: GameState | None = None
        proposal: Proposal | None = None
        decided_sources: set[tuple[Any, int, str]] = set()
        previous_provider: tuple[Any, ...] | None = None
        previous_gate: tuple[Any, ...] | None = None
        previous_cards: tuple[Any, ...] = ()
        previous_fusion: Any | None = None
        action_limit_pending = False
        last_stable_state: GameState | None = None
        sequence_artifact_saved = False
        sequence_artifact_attempted = False

        try:
            while target.is_running():
                now = time.monotonic()
                if args.timeout and now - started >= args.timeout:
                    _write(log, "controller_timeout")
                    break
                confirm_pressed, stop_pressed = hotkeys.poll()
                if stop_pressed:
                    _write(log, "emergency_stop", key="F9")
                    print("F9 emergency stop received.", flush=True)
                    break

                result = provider.poll()
                state = result.state
                if state is not None:
                    last_stable_state = state
                provider_signature = (
                    result.reason,
                    result.lifecycle_event,
                    result.session_key,
                    result.confirmations,
                )
                if provider_signature != previous_provider:
                    _write(
                        log,
                        "provider_status",
                        reason=result.reason,
                        lifecycle=result.lifecycle_event,
                        session=result.session_key,
                        confirmations=result.confirmations,
                    )
                    previous_provider = provider_signature

                if result.lifecycle_event in {"board_found", "session_changed"}:
                    if result.session_key is not None:
                        skips.start_session(result.session_key)
                        if (
                            sequence_monitor.tracker.active_session is not None
                            and sequence_monitor.tracker.active_session
                            != result.session_key
                        ):
                            sequence_monitor.end_session(
                                sequence_monitor.tracker.active_session
                            )
                        sequence_monitor.begin_session(
                            result.session_key,
                            result.session_key.match_id,
                            clean=True,
                        )
                    solver_session = V1ShadowSession()
                    proposal = None
                    decided_sources.clear()
                    previous_gate = None
                    _write(
                        log,
                        "session_started",
                        session=result.session_key,
                    )
                    sequence_artifact_saved = False
                    sequence_artifact_attempted = False

                sequence_observation = None
                current_session = provider.current_session_key
                if current_session is not None:
                    try:
                        sequence_observation = sequence_monitor.poll(
                            session_key=current_session,
                            match_id=current_session.match_id,
                            turn=(state.battle.turn_number if state is not None else None),
                            srv_seq=(state.battle.srv_seq if state is not None else None),
                            timestamp=utc_timestamp(),
                        )
                    except (OSError, RuntimeError, ValueError) as exc:
                        _write(log, "sequence_monitor_error", detail=str(exc))
                desync_state = sequence_monitor.tracker.state
                if sequence_observation is not None and sequence_observation.messages:
                    _write(
                        log,
                        "sequence_messages_observed",
                        count=len(sequence_observation.messages),
                        state=desync_state,
                    )
                if sequence_observation is not None and sequence_observation.first_detected:
                    counters.sequence_desync_detections += 1
                    invalidated_proposal = proposal
                    if invalidated_proposal is not None:
                        counters.proposals_invalidated_sequence_desync += 1
                    proposal = None
                    pending_invalidation = invalidate_pending_for_sequence_desync(
                        invalidated_proposal,
                        action_lock,
                        now=time.monotonic(),
                    )
                    pending_result = pending_invalidation.action_result
                    if pending_result is not None:
                        counters.actions_rejected_sequence_desync += 1
                    pending_solver_session = None
                    pending_source_state = None
                    beeped = _signal_recovery_required(not args.no_beep)
                    _write(
                        log,
                        "sequence_desync_detected",
                        state=desync_state,
                        proposalInvalidated=(
                            invalidated_proposal.identity
                            if invalidated_proposal is not None
                            else None
                        ),
                        pendingActionResult=pending_result,
                        result="REJECTED_SEQUENCE_DESYNC",
                        gameplayBlocked=True,
                        noRetry=True,
                        timerTelemetryOnly=True,
                        recoveryRequiredSignal=beeped,
                        automaticExit=False,
                    )
                    _write(
                        log,
                        "recovery_required",
                        reason="SEQUENCE_DESYNC",
                        state=desync_state,
                        userConfirmationTool="tools/sequence_recovery.py",
                        automaticExit=False,
                    )
                    print(
                        "SEQUENCE_DESYNC: gameplay locked for this combat; "
                        "normal UI recovery is required.",
                        flush=True,
                    )
                if desync_state.terminal_for_session:
                    if not sequence_artifact_attempted and last_stable_state is not None:
                        sequence_artifact_attempted = True
                        try:
                            artifact = write_sequence_desync_artifact(
                                PROJECT_ROOT / "logs" / "sequence_desync",
                                desync=desync_state,
                                state=last_stable_state,
                                recent_events=sequence_monitor.events.snapshot(),
                                screenshot_writer=lambda path: capture_client_png(
                                    target.pid, path
                                ),
                                correlation={
                                    "fusionState": last_stable_state.fusion,
                                    "causalConclusion": "UNKNOWN",
                                },
                            )
                            sequence_artifact_saved = True
                            _write(
                                log,
                                "sequence_desync_artifact_saved",
                                directory=str(artifact.directory),
                            )
                        except FileExistsError:
                            sequence_artifact_saved = True
                        except (OSError, RuntimeError, ValueError) as exc:
                            _write(
                                log,
                                "sequence_desync_artifact_error",
                                detail=str(exc),
                            )
                    if confirm_pressed:
                        _write(
                            log,
                            "confirmation_ignored",
                            reason=GateReason.SEQUENCE_DESYNC,
                        )
                    time.sleep(args.scan_interval)
                    continue

                if action_lock.locked:
                    acknowledgement = action_lock.observe(
                        state,
                        now=time.monotonic(),
                        lifecycle_event=result.lifecycle_event,
                        observed_srv_seq=(
                            provider.metrics.highest_acked_sequence
                        ),
                    )
                    if acknowledgement.status is AckStatus.ACKNOWLEDGED:
                        counters.acknowledged += 1
                        if pending_solver_session is not None:
                            solver_session = pending_solver_session
                        skips.acknowledged()
                        _write(
                            log,
                            "action_acknowledged",
                            outcome=acknowledgement.outcome,
                            sourceSeq=(
                                action_lock.pending.identity.source_srv_seq
                                if action_lock.pending is not None
                                else pending_source_state.battle.srv_seq
                                if pending_source_state is not None
                                else None
                            ),
                            newSeq=acknowledgement.new_srv_seq,
                            latencyMs=acknowledgement.latency_ms,
                        )
                        sequence_monitor.record(
                            {
                                "timestamp": utc_timestamp(),
                                "event": "action_acknowledged",
                                "outcome": acknowledgement.outcome,
                                "newSeq": acknowledgement.new_srv_seq,
                                "latencyMs": acknowledgement.latency_ms,
                            }
                        )
                        print(
                            f"ACK {acknowledgement.outcome.value} "
                            f"newSeq={acknowledgement.new_srv_seq} "
                            f"latency={acknowledgement.latency_ms}ms",
                            flush=True,
                        )
                        pending_solver_session = None
                        pending_source_state = None
                    elif acknowledgement.status is AckStatus.TIMEOUT:
                        counters.timeouts += 1
                        _write(
                            log,
                            "action_timeout",
                            outcome=acknowledgement.outcome,
                            latencyMs=acknowledgement.latency_ms,
                        )
                        if pending_source_state is not None:
                            was_paused = skips.auto_paused
                            counted = skips.record(
                                pending_source_state, ["MOVE_NO_STATE_CHANGE"]
                            )
                            if counted and skips.auto_paused and not was_paused:
                                counters.auto_pauses += 1
                                _write(
                                    log,
                                    "auto_pause",
                                    trigger="TWO_SKIP_CEILING",
                                    consecutiveSkips=skips.consecutive,
                                    reasons=skips.reasons,
                                )
                        pending_solver_session = None
                        pending_source_state = None
                        print("ACTION TIMEOUT; same identity will not be retried.", flush=True)
                    if (
                        acknowledgement.status
                        in {AckStatus.ACKNOWLEDGED, AckStatus.TIMEOUT}
                        and action_limit_pending
                    ):
                        _write(
                            log,
                            "action_limit_complete",
                            limit=args.max_actions,
                            finalStatus=acknowledgement.status,
                            finalOutcome=acknowledgement.outcome,
                        )
                        break
                    if action_lock.locked:
                        if confirm_pressed:
                            _write(log, "confirmation_ignored", reason="INPUT_LOCKED")
                        time.sleep(args.scan_interval)
                        continue

                if result.lifecycle_event == "board_lost":
                    if sequence_monitor.tracker.active_session is not None:
                        sequence_monitor.end_session(
                            sequence_monitor.tracker.active_session
                        )
                    proposal = None
                    previous_gate = None
                    _write(log, "session_ended")

                if state is None or state.phase is not GamePhase.COMBAT:
                    if confirm_pressed:
                        unavailable_reason = (
                            "NOT_IN_COMBAT"
                            if provider.current_session_key is None
                            else f"STATE_UNAVAILABLE:{result.reason}"
                        )
                        _write(
                            log,
                            "confirmation_ignored",
                            reason=unavailable_reason,
                        )
                    time.sleep(args.scan_interval)
                    continue

                if state.cards != previous_cards:
                    _write(log, "cards_read_only", cards=state.cards)
                    previous_cards = state.cards
                if state.fusion != previous_fusion:
                    _write(log, "fusion_read_only", fusion=state.fusion)
                    previous_fusion = state.fusion

                source_key = _state_identity(state)
                if proposal is not None and source_key != (
                    proposal.identity.session_key,
                    proposal.identity.source_srv_seq,
                    proposal.identity.source_board_hash,
                ):
                    counters.proposal_expired += 1
                    _write(
                        log,
                        "proposal_expired",
                        reason="SOURCE_STATE_CHANGED",
                        proposal=proposal.identity,
                        currentState=source_key,
                    )
                    proposal = None

                gate_context, window = _gate_context(
                    provider,
                    executor,
                    binding,
                    action_lock,
                    skips,
                    sequence_monitor.tracker.state,
                )
                gate = ActionabilityGate.evaluate(state, gate_context)

                if proposal is not None:
                    if not gate.actionable:
                        counters.proposal_expired += 1
                        _write(
                            log,
                            "proposal_expired",
                            reason=gate.reason,
                            details=gate.details,
                            proposal=proposal.identity,
                        )
                        proposal = None
                    elif confirm_pressed:
                        counters.confirmations += 1
                        fresh_poll = provider.poll()
                        fresh = fresh_poll.state
                        if fresh is None or not _same_source(fresh, proposal.identity):
                            counters.proposal_expired += 1
                            _write(
                                log,
                                "proposal_expired",
                                reason="REVALIDATED_STATE_CHANGED",
                                proposal=proposal.identity,
                                providerReason=fresh_poll.reason,
                                freshState=(fresh.dedup_key if fresh else None),
                            )
                            proposal = None
                            time.sleep(args.scan_interval)
                            continue
                        fresh_context, fresh_window = _gate_context(
                            provider,
                            executor,
                            binding,
                            action_lock,
                            skips,
                            sequence_monitor.tracker.state,
                        )
                        fresh_gate = ActionabilityGate.evaluate(fresh, fresh_context)
                        if not fresh_gate.actionable:
                            counters.proposal_expired += 1
                            _write(
                                log,
                                "proposal_expired",
                                reason=fresh_gate.reason,
                                details=fresh_gate.details,
                                proposal=proposal.identity,
                            )
                            proposal = None
                            time.sleep(args.scan_interval)
                            continue
                        work = _copy_solver_session(proposal.solver_session_before)
                        fresh_decision = adapter.decide(fresh, session=work)
                        if (
                            fresh_decision.solver_action != proposal.decision.solver_action
                            or fresh_decision.first != proposal.decision.first
                            or fresh_decision.second != proposal.decision.second
                        ):
                            counters.proposal_expired += 1
                            _write(
                                log,
                                "proposal_expired",
                                reason="SOLVER_MOVE_CHANGED",
                                oldDecision=proposal.decision,
                                freshDecision=fresh_decision,
                            )
                            proposal = None
                            time.sleep(args.scan_interval)
                            continue
                        try:
                            fresh_plan = _coordinate_plan(
                                fresh_decision,
                                calibration,
                                fresh_window,
                                backend,
                            )
                        except CoordinateSafetyError as exc:
                            _write(
                                log,
                                "action_skipped",
                                reason="COORDINATE_INVALID",
                                details=str(exc),
                                source=fresh.dedup_key,
                            )
                            skips.record(fresh, ["COORDINATE_INVALID"])
                            proposal = None
                            time.sleep(args.scan_interval)
                            continue
                        if not action_lock.reserve(proposal.identity):
                            counters.duplicate_inputs += 1
                            _write(
                                log,
                                "action_skipped",
                                reason="DUPLICATE_ACTION_IDENTITY",
                                action=proposal.identity,
                            )
                            proposal = None
                            time.sleep(args.scan_interval)
                            continue

                        if args.dry_run:
                            counters.dry_run_prepared += 1
                            decided_sources.add(source_key)
                            _write(
                                log,
                                "dry_run_action_prepared",
                                action=proposal.identity,
                                gate=fresh_gate,
                                screenFrom=(
                                    fresh_plan.first.screen_x,
                                    fresh_plan.first.screen_y,
                                ),
                                screenTo=(
                                    fresh_plan.second.screen_x,
                                    fresh_plan.second.screen_y,
                                ),
                                inputCalls=False,
                            )
                            print("DRY-RUN validated; NO INPUT sent.", flush=True)
                            proposal = None
                            time.sleep(args.scan_interval)
                            continue

                        click_result = executor.send_swap(binding, fresh_plan)
                        if not click_result.sent:
                            counters.input_failures += 1
                            if click_result.sent_clicks:
                                counters.partial_inputs += 1
                                counted = skips.record(
                                    fresh, [click_result.status.value]
                                )
                                skips.auto_paused = True
                                if not skips.reasons or (
                                    skips.reasons[-1]
                                    != click_result.status.value
                                ):
                                    skips.reasons.append(
                                        click_result.status.value
                                    )
                                counters.auto_pauses += 1
                                _write(
                                    log,
                                    "auto_pause",
                                    trigger="PARTIAL_INPUT_EMERGENCY",
                                    countedAsSkip=counted,
                                    consecutiveSkips=skips.consecutive,
                                    reasons=skips.reasons,
                                )
                            else:
                                skips.record(fresh, [click_result.status.value])
                            _write(
                                log,
                                "action_input_failed",
                                action=proposal.identity,
                                status=click_result.status,
                                sentClicks=click_result.sent_clicks,
                                autoPaused=skips.auto_paused,
                            )
                            print(
                                f"INPUT FAILED {click_result.status.value}; "
                                "identity consumed, no retry.",
                                flush=True,
                            )
                            proposal = None
                            time.sleep(args.scan_interval)
                            continue

                        sent_at = time.monotonic()
                        action_lock.begin(
                            proposal.identity,
                            source_turn_number=fresh.battle.turn_number,
                            source_turn_player=fresh.battle.current_turn_player,
                            now=sent_at,
                        )
                        counters.actions_sent += 1
                        pending_solver_session = proposal.solver_session_after
                        pending_source_state = fresh
                        _write(
                            log,
                            "action_sent",
                            action=proposal.identity,
                            sourceSeq=proposal.identity.source_srv_seq,
                            sourceBoardHash=proposal.identity.source_board_hash,
                            fromCell=proposal.identity.first,
                            toCell=proposal.identity.second,
                            clientFrom=(
                                fresh_plan.first.client_x,
                                fresh_plan.first.client_y,
                            ),
                            clientTo=(
                                fresh_plan.second.client_x,
                                fresh_plan.second.client_y,
                            ),
                            screenFrom=(
                                fresh_plan.first.screen_x,
                                fresh_plan.first.screen_y,
                            ),
                            screenTo=(
                                fresh_plan.second.screen_x,
                                fresh_plan.second.screen_y,
                            ),
                            sentClicks=2,
                        )
                        sequence_monitor.record(
                            {
                                "timestamp": utc_timestamp(),
                                "event": "action_sent",
                                "session": proposal.identity.session_key,
                                "sourceSrvSeq": proposal.identity.source_srv_seq,
                                "sourceBoardHash": proposal.identity.source_board_hash,
                                "fromCell": proposal.identity.first,
                                "toCell": proposal.identity.second,
                            }
                        )
                        print(
                            f"ACTION SENT seq={proposal.identity.source_srv_seq} "
                            f"{proposal.identity.first}->{proposal.identity.second}; LOCKED",
                            flush=True,
                        )
                        proposal = None
                        if args.max_actions and counters.actions_sent >= args.max_actions:
                            action_limit_pending = True
                            _write(log, "action_limit_reached", limit=args.max_actions)
                    time.sleep(args.scan_interval)
                    continue

                gate_signature = (source_key, gate.reason, tuple(sorted(gate.details)))
                if not gate.actionable:
                    if gate_signature != previous_gate:
                        counted = skips.record(state, [gate.reason.value])
                        _write(
                            log,
                            "action_skipped",
                            reason=gate.reason,
                            details=gate.details,
                            source=source_key,
                            countedAsSkip=counted,
                            consecutiveSkips=skips.consecutive,
                            autoPaused=skips.auto_paused,
                        )
                        if skips.auto_paused and counted:
                            counters.auto_pauses += 1
                            _write(
                                log,
                                "auto_pause",
                                consecutiveSkips=skips.consecutive,
                                reasons=skips.reasons,
                            )
                            print(
                                f"AUTO_PAUSE after 2 skips: {skips.reasons}",
                                flush=True,
                            )
                        previous_gate = gate_signature
                    if confirm_pressed:
                        _write(
                            log,
                            "confirmation_ignored",
                            reason=gate.reason,
                        )
                    time.sleep(args.scan_interval)
                    continue
                previous_gate = gate_signature

                if source_key is None or source_key in decided_sources:
                    if confirm_pressed:
                        _write(log, "confirmation_ignored", reason="NO_NEW_PROPOSAL")
                    time.sleep(args.scan_interval)
                    continue
                decision, before, after = _decide_without_committing(
                    adapter, state, solver_session
                )
                if (
                    decision.solver_action == "skip"
                    or decision.first is None
                    or decision.second is None
                ):
                    solver_session = after
                    decided_sources.add(source_key)
                    counted = skips.record(state, ["SOLVER_SKIP", decision.reason])
                    _write(
                        log,
                        "action_skipped",
                        reason="SOLVER_SKIP",
                        solverReason=decision.reason,
                        source=source_key,
                        countedAsSkip=counted,
                        consecutiveSkips=skips.consecutive,
                        autoPaused=skips.auto_paused,
                    )
                    if skips.auto_paused and counted:
                        counters.auto_pauses += 1
                        _write(
                            log,
                            "auto_pause",
                            consecutiveSkips=skips.consecutive,
                            reasons=skips.reasons,
                        )
                    time.sleep(args.scan_interval)
                    continue
                try:
                    plan = _coordinate_plan(decision, calibration, window, backend)
                except CoordinateSafetyError as exc:
                    decided_sources.add(source_key)
                    counted = skips.record(state, ["COORDINATE_INVALID"])
                    _write(
                        log,
                        "action_skipped",
                        reason="COORDINATE_INVALID",
                        details=str(exc),
                        countedAsSkip=counted,
                    )
                    time.sleep(args.scan_interval)
                    continue
                identity = ActionIdentity(
                    state.battle.session_key,
                    int(state.battle.srv_seq),
                    str(state.battle.board_hash),
                    decision.first,
                    decision.second,
                )
                if action_lock.was_executed(identity):
                    counters.duplicate_inputs += 1
                    decided_sources.add(source_key)
                    _write(
                        log,
                        "action_skipped",
                        reason="DUPLICATE_ACTION_IDENTITY",
                        action=identity,
                    )
                    time.sleep(args.scan_interval)
                    continue
                proposal = Proposal(
                    identity,
                    state,
                    decision,
                    before,
                    after,
                    plan,
                    time.monotonic(),
                )
                counters.proposals += 1
                _write(
                    log,
                    "proposal",
                    session=identity.session_key,
                    srvSeq=identity.source_srv_seq,
                    boardHash=identity.source_board_hash,
                    fromCell=identity.first,
                    toCell=identity.second,
                    score=decision.score,
                    solverReason=decision.reason,
                    gate=gate.reason,
                    screenFrom=(plan.first.screen_x, plan.first.screen_y),
                    screenTo=(plan.second.screen_x, plan.second.screen_y),
                )
                beeped = _signal_proposal(not args.no_beep)
                _write(log, "proposal_ready_signal", beeped=beeped)
                print(
                    f"PROPOSAL seq={identity.source_srv_seq} "
                    f"{identity.first}->{identity.second} score={decision.score}; "
                    "press F8 while game is foreground",
                    flush=True,
                )
                if confirm_pressed:
                    _write(
                        log,
                        "confirmation_ignored",
                        reason="F8_PRECEDED_PROPOSAL",
                    )
                time.sleep(args.scan_interval)
        finally:
            _write(
                log,
                "controller_summary",
                mode=mode,
                counters=counters,
                executedIdentities=action_lock.executed_count,
                consecutiveSkips=skips.consecutive,
                skipReasons=skips.reasons,
                autoPaused=skips.auto_paused,
                providerMetrics=provider.metrics,
                cardsFusionReadOnly=True,
                memoryWrites=False,
                directGameCalls=False,
                networkManipulation=False,
            )
        print(f"Controller stopped; log: {log_path}", flush=True)
        return 0


def main(argv: Sequence[str] | None = None) -> int:
    try:
        return run(build_parser().parse_args(argv))
    except KeyboardInterrupt:
        print("Ctrl+C stop received.")
        return 130
    except (
        CoordinateSafetyError,
        FileNotFoundError,
        OSError,
        ProcessProbeError,
        ProviderSetupError,
        RuntimeError,
        ValueError,
    ) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
