#!/usr/bin/env python3
"""Phase 2C.2B Stage B3/B4/B5 BASIC combat acceptance controller."""

from __future__ import annotations

import argparse
from dataclasses import asdict, dataclass, field, is_dataclass, replace
from datetime import datetime
from enum import Enum
import json
from pathlib import Path
import sys
import time
import traceback
from contextlib import nullcontext
from typing import Any, Callable, Sequence

try:
    import winsound
except ImportError:  # pragma: no cover
    winsound = None


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
POST_EVOLVE_INPUT_SETTLE_SECONDS = 3.5
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.actionability import ActionabilityGate, GateContext  # noqa: E402
from pokiguard_v2.autonomous_control import (  # noqa: E402
    ActionResultKind,
    AutonomousActionIdentity,
    AutonomousGuard,
    AutonomousStatus,
    ConsumingTurnRegistry,
    PendingAutonomousAction,
    SwapAcceptanceStatus,
    TurnTransitionKind,
    TurnTransitionTracker,
    classify_swap_acceptance,
    direct_runtime_proves_cast_accepted,
    direct_runtime_proves_swap_accepted,
    direct_runtime_swap_preflight_failure,
    plan_action_response_wait,
)
from pokiguard_v2.authoritative_pass import (  # noqa: E402
    AuthoritativePassCoordinator,
    PassResultKind,
    PassWaitState,
    server_timestamp_not_before,
)
from pokiguard_v2.basic_policy import (  # noqa: E402
    BasicPolicyEngine,
    Intelligence,
    ManaPriority,
    PlayStyle,
    PolicyAction,
    PolicyConfig,
)
from pokiguard_v2.board_diagnostics import (  # noqa: E402
    analyze_game_state,
    jsonable,
    write_diagnostic_artifact,
)
from pokiguard_v2.combat_lifecycle import CombatLifecycleState  # noqa: E402
from pokiguard_v2.controller_lease import AutomationControllerLease  # noqa: E402
from pokiguard_v2.gameplay_ui import (  # noqa: E402
    GameplayControl,
    locate_gameplay_control,
)
from pokiguard_v2.game_owned_idle import (  # noqa: E402
    AcceptedActivityKind,
    GameOwnedIdleCache,
    PassReadiness,
    ResetConfidence,
    apply_idle_readiness_to_state,
)
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
    ProviderPoll,
    ProviderSetupError,
    utc_timestamp,
)
from pokiguard_v2.opening_snapshot import (  # noqa: E402
    JARRAY_TYPE_INFO_RVA,
    JOBJECT_TYPE_INFO_RVA,
    JPROPERTY_TYPE_INFO_RVA,
    JVALUE_TYPE_INFO_RVA,
    NewtonsoftClasses,
    read_match_payload_board_snapshot,
    read_match_start_opening_snapshot,
)
from pokiguard_v2.reset_evidence_store import (  # noqa: E402
    load_reset_capabilities,
)
from pokiguard_v2.app_paths import current_app_paths  # noqa: E402
from pokiguard_v2.runtime_calibration import (  # noqa: E402
    production_input_calibration,
)
from pokiguard_v2.recovery_ui import (  # noqa: E402
    locate_confirm_leave,
    locate_exit_back,
)
from pokiguard_v2.sequence_desync import (  # noqa: E402
    RecoveryLifecycleState,
    RecoveryStateMachine,
)
from pokiguard_v2.sequence_desync_artifacts import (  # noqa: E402
    write_sequence_desync_artifact,
)
from pokiguard_v2.state import (  # noqa: E402
    CardState,
    FusionState,
    GamePhase,
    GameOwnedIdleStatus,
    GameState,
    TerminalCombatSnapshot,
    TerminalResult,
)
from pokiguard_v2.terminal_result import (  # noqa: E402
    capture_terminal_snapshot,
    merge_terminal_snapshots,
)
from pokiguard_v2.technical_recovery import (  # noqa: E402
    ActiveCombatProgressStall,
    ActiveCombatProgressWatchdog,
    MANDATORY_RESET_RECOVERY_FLOOR_SECONDS,
)
from pokiguard_v2.win32_input import (  # noqa: E402
    AutoHotkeyEdges,
    BoardCalibration,
    BoardInputMode,
    CoordinateSafetyError,
    ForegroundClickExecutor,
    NativeWin32Backend,
    find_window_for_pid,
    map_swap_to_pixels,
)
from pokiguard_v2.win32_screenshot import capture_client_png, capture_client_rgb  # noqa: E402
from tools.idle_state_watch import ServerMessage, read_match_runtime  # noqa: E402
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.runtime_common import attach_target, hex_pointer  # noqa: E402
from tools.sequence_desync_runtime import (  # noqa: E402
    RuntimeSequenceMonitor,
    RuntimeSequenceObservation,
)
from tools.sequence_recovery import _live_exit_calibration, _locate_temporally  # noqa: E402


@dataclass(frozen=True)
class SharedCombatRuntime:
    """Farm-owned live dependencies for one already-proven combat session.

    Passing this object avoids a second attach/provider/executor after entry.
    The legacy CLI leaves it unset and retains its existing construction path.
    """

    target: Any
    provider: MemoryBoardStateProvider
    monitor: RuntimeSequenceMonitor
    binding: Any
    executor: ForegroundClickExecutor
    backend: NativeWin32Backend
    expected_session: Any | None = None
    gameplay_capability: Any | None = None
    technical_recovery_dispatcher: Any | None = None
    # Farm-owned contextual F6/F9 latch. Combat calls poll(), never take().  The
    # wrapper registers F6 with FarmRun immediately (so recovery can suppress a
    # not-yet-sent re-entry), while this combat controller deliberately keeps
    # playing the current match. The outer farm loop consumes the audit latch at
    # the next boundary. This preserves F6 graceful drain != F9 emergency stop.
    farm_control_hotkeys: Any | None = None
    # Optional same-process status projection. It is called only when a new
    # authoritative LOCAL/BOSS TurnNumber is deduplicated; it performs no
    # extra memory read and owns no input capability.
    turn_progress_observer: (
        Callable[[str, Any, int, int, int], None] | None
    ) = None


def _reserve_farm_gameplay(
    runtime: SharedCombatRuntime,
    *,
    action: PolicyAction,
    session: Any,
    foreground: bool,
) -> tuple[bool, Any | None]:
    """Ask the farm ledger at the final input boundary, if farm-owned."""

    if runtime.gameplay_capability is None:
        return True, None
    permit = runtime.gameplay_capability.reserve(
        action=action.value,
        session=session,
        foreground=foreground,
    )
    return permit is not None, permit


def _complete_farm_gameplay(
    runtime: SharedCombatRuntime,
    permit: Any | None,
    *,
    sent: bool,
    detail: str,
) -> bool:
    if runtime.gameplay_capability is None:
        return True
    if permit is None:
        return False
    return bool(runtime.gameplay_capability.complete(permit, sent=sent, detail=detail))


def _execute_farm_gameplay_input(
    runtime: SharedCombatRuntime,
    operation: Any,
) -> tuple[bool, Any | None]:
    """Serialize a farm-owned physical input against emergency revocation."""

    capability = runtime.gameplay_capability
    executor = getattr(capability, "execute", None)
    if executor is None:
        return True, operation()
    return executor(operation)


def _farm_emergency_requested(runtime: SharedCombatRuntime | None) -> bool:
    if runtime is None or runtime.farm_control_hotkeys is None:
        return False
    _graceful, emergency = runtime.farm_control_hotkeys.poll()
    return bool(emergency)


def _cancel_farm_gameplay(
    runtime: SharedCombatRuntime,
    permit: Any | None,
    *,
    detail: str,
) -> None:
    if runtime.gameplay_capability is not None and permit is not None:
        runtime.gameplay_capability.cancel(permit, detail=detail)


def _abandon_farm_pass_preflight(
    runtime: SharedCombatRuntime,
    permit: Any | None,
    *,
    detail: str,
) -> bool:
    """Release only an unsent farm-owned PASS after its final preflight."""

    if runtime.gameplay_capability is None or permit is None:
        return False
    abandon = getattr(runtime.gameplay_capability, "abandon_pass_preflight", None)
    return bool(abandon is not None and abandon(permit, detail=detail))


def _abandon_farm_gameplay_preflight(
    runtime: SharedCombatRuntime,
    permit: Any | None,
    *,
    detail: str,
) -> bool:
    """Release an unsent physical-action permit after a fresh-state change."""

    if runtime.gameplay_capability is None or permit is None:
        return False
    abandon = getattr(
        runtime.gameplay_capability,
        "abandon_gameplay_preflight",
        None,
    )
    return bool(abandon is not None and abandon(permit, detail=detail))


def _farm_owned_board_only_pass_tracking_allowed(state: GameState) -> bool:
    """Allow a farm-owned zero-input PASS tracker through a stats-only gap.

    PASS itself emits no Windows input. During a transient participant scan
    gap the current board, turn ownership, lifecycle and live boss can still be
    authoritative. Tracking that already-selected wait lets the later exact
    AFK payload close the PASS cycle instead of orphaning it as UNKNOWN.
    """

    boss = next(
        (participant for participant in state.opponents if participant.is_boss),
        None,
    )
    return bool(
        state.player is None
        and boss is not None
        and boss.hp is not None
        and boss.hp > 0
        and state.battle.session_key is not None
        and state.battle.is_local_turn is True
        and state.board.production_ready
        and state.battle.stable
        and state.battle.acknowledged
        and state.battle.latest
    )


def _transient_board_only_pass_participant_gap(
    state: GameState,
    error: Exception,
) -> bool:
    """Recognize the exact no-input PASS rejection seen during stats gaps."""

    return bool(
        str(error) == "PASS start rejected: participant_not_alive"
        and _farm_owned_board_only_pass_tracking_allowed(state)
    )


def _farm_owned_pass_unknown_can_wait_for_recovery(
    *,
    reason: str,
    farm_owned: bool,
    recovery_available: bool,
) -> bool:
    """Keep the controller live until its bounded active-turn recovery gate.

    This is defense in depth for an authoritative PASS state that remains
    unknown despite the board-only tracker above. The existing terminal-turn
    detector may then hand off technical recovery before an AFK timeout; this
    helper never authorizes gameplay input or another PASS.
    """

    return bool(
        reason == "PASS_STATE_UNKNOWN"
        and farm_owned
        and recovery_available
    )


def _dispatch_technical_recovery(
    runtime: SharedCombatRuntime,
    *,
    reason: str,
    state: GameState | None,
    desync: Any | None = None,
    analysis: Any | None = None,
    actionability_evidence: dict[str, Any] | None = None,
    unconfirmed_pass_evidence: dict[str, Any] | None = None,
    controller_stall_evidence: dict[str, Any] | None = None,
    active_combat_progress_stall: ActiveCombatProgressStall | None = None,
    active_combat_progress_evidence: dict[str, Any] | None = None,
    local_player_left_evidence: dict[str, Any] | None = None,
    late_mandatory_reset_evidence: dict[str, Any] | None = None,
) -> bool:
    """Dispatch only bounded, evidence-validated production technical reasons.

    The gameplay controller owns detection and immediate action invalidation;
    the outer Phase 2D.3 runner owns all recovery UI and re-entry.  Absence of
    a dispatcher preserves the already accepted standalone/B5 behavior.
    """

    dispatcher = runtime.technical_recovery_dispatcher
    if dispatcher is None:
        return False
    if reason == "SEQUENCE_DESYNC" and desync is not None:
        return bool(dispatcher.dispatch_sequence_desync(desync, state=state))
    if (
        reason == "DEAD_BOARD_NO_REFRESH"
        and state is not None
        and analysis is not None
    ):
        return bool(dispatcher.dispatch_dead_board(state, analysis))
    if reason == "ACTIONABILITY_STATE_LOST" and actionability_evidence is not None:
        return bool(
            dispatcher.dispatch_actionability_state_lost(
                **actionability_evidence
            )
        )
    if (
        reason == "ACTIONABILITY_STATE_LOST"
        and unconfirmed_pass_evidence is not None
    ):
        return bool(
            dispatcher.dispatch_unconfirmed_pass_runtime_reset(
                **unconfirmed_pass_evidence
            )
        )
    if (
        reason == "CONTROLLER_STALLED_ACTIVE_COMBAT"
        and state is not None
        and controller_stall_evidence is not None
    ):
        return bool(
            dispatcher.dispatch_controller_stalled_active_combat(
                state,
                **controller_stall_evidence,
            )
        )
    if (
        reason == "ACTIVE_COMBAT_PROGRESS_STALLED"
        and state is not None
        and active_combat_progress_stall is not None
        and active_combat_progress_evidence is not None
    ):
        return bool(
            dispatcher.dispatch_active_combat_progress_stalled(
                state,
                stall=active_combat_progress_stall,
                **active_combat_progress_evidence,
            )
        )
    if (
        reason == "LOCAL_PLAYER_LEFT_ACTIVE_COMBAT"
        and state is not None
        and local_player_left_evidence is not None
    ):
        return bool(
            dispatcher.dispatch_local_player_left_active_combat(
                state,
                **local_player_left_evidence,
            )
        )
    if (
        reason == "LATE_MANDATORY_RESET"
        and state is not None
        and late_mandatory_reset_evidence is not None
    ):
        return bool(
            dispatcher.dispatch_late_mandatory_reset(
                state,
                **late_mandatory_reset_evidence,
            )
        )
    return False


def _force_full_pass_scan_once(
    current_attempt_identity: tuple[Any, ...] | None,
    last_forced_identity: tuple[Any, ...] | None,
) -> bool:
    """Use one discovery scan per PASS attempt, then fast learned regions."""

    return bool(
        current_attempt_identity is not None
        and current_attempt_identity != last_forced_identity
    )


def _provider_available_board_sequences(
    scan_diagnostics: dict[str, Any],
) -> tuple[int, ...]:
    """Return exact validated boards already retained by the provider.

    Transport/runtime-heap snapshots can be captured while a slow scan crosses
    the opponent -> local boundary, before the direct MatchService ACK sample
    is refreshed. They are not publishable yet, but re-scanning the complete
    heap for the same sequence only burns the new 14-second turn. Unattested
    heap candidates remain excluded.
    """

    sequences: set[int] = set()
    for batch in scan_diagnostics.get("trackedBatches", ()):
        if not (
            batch.get("ackAttested")
            or batch.get("transportAttested")
            or batch.get("runtimeHeapAttested")
        ):
            continue
        try:
            sequence = int(batch["srvSeq"])
        except (KeyError, TypeError, ValueError):
            continue
        if sequence >= 0:
            sequences.add(sequence)
    return tuple(sorted(sequences))


def _unoffered_transport_board_messages(
    board_messages: Sequence[Any],
    offered_addresses: set[int],
) -> tuple[Any, ...]:
    """Retain current board DTOs even while authoritative PASS owns input.

    PASS suppresses gameplay input, not read-only current-state capture.  A
    MATCH_MOVE_RES observed at the PASS -> next-local-turn boundary can be
    reclaimed before the following provider poll.  Dropping it here forces a
    broad recovery scan and can consume the configured action floor. The
    provider still requires exact match identity, DTO validation and the same
    sequence in MatchService._ackedSeqs before publication.
    """

    return tuple(
        message
        for message in board_messages
        if message.event_type == "MATCH_MOVE_RES"
        and message.payload_address is not None
        and message.address not in offered_addresses
    )


def _mandatory_cached_board_fastpath_allowed(
    mandatory_reset_pending: bool,
    completed_fastpath_polls: int,
    *,
    maximum_fastpath_polls: int = 2,
) -> bool:
    """Bound the post-IDLE_2 cached-provider fast path.

    Runtime monitoring performed during PASS_WAIT may already have retained
    the complete board for the next local turn. The provider still requires
    two stable, ACK-correlated polls before publication. A broad transport
    scan before those polls can consume most of the mandatory turn. Give the
    cached evidence exactly two cheap publication opportunities; normal
    discovery resumes immediately if they do not publish.
    """

    return bool(
        mandatory_reset_pending
        and maximum_fastpath_polls > 0
        and 0 <= completed_fastpath_polls < maximum_fastpath_polls
    )


def _dispatch_unconfirmed_pass_recovery(
    runtime: SharedCombatRuntime,
    *,
    terminal: Any,
    raw_runtime: Any,
    active_session: Any,
    state: GameState | None,
) -> bool:
    if (
        terminal.result is not PassResultKind.PASS_STATE_UNCONFIRMED
        or raw_runtime is None
        or active_session is None
    ):
        return False
    attempt = terminal.attempt
    return _dispatch_technical_recovery(
        runtime,
        reason="ACTIONABILITY_STATE_LOST",
        state=state,
        unconfirmed_pass_evidence={
            "session_key": active_session,
            "match_id": raw_runtime.match_id,
            "source_turn": attempt.source_turn,
            "source_srv_seq": attempt.source_srv_seq,
            "source_board_hash": attempt.board_hash,
            "source_local_move_sequence": attempt.source_local_move_sequence,
            "current_turn": raw_runtime.turn,
            "current_player": raw_runtime.current_player,
            "local_username": raw_runtime.local_username,
            "current_local_move_sequence": raw_runtime.local_move_sequence,
            "current_last_move_sequence": raw_runtime.last_move_sequence,
            "current_highest_acked_sequence": (
                raw_runtime.highest_acked_sequence
            ),
            "gameplay_inputs_during_wait": (
                terminal.gameplay_inputs_during_wait
            ),
            "terminal_detail": terminal.detail,
        },
    )


def _prime_transport_for_runtime(
    runtime: SharedCombatRuntime,
    *,
    farm_owned: bool,
) -> dict[str, Any]:
    """Entry already learned transport regions; do not rescan them at handoff."""

    if farm_owned:
        return {
            "reusedEntryRegionEvidence": True,
            "expectedSession": runtime.expected_session,
            "additionalScanBytes": 0,
        }
    return runtime.monitor.prime_regions()


def _farm_owned_guard_requires_stop(
    *,
    farm_owned: bool,
    status: AutonomousStatus,
) -> bool:
    """A farm cycle cannot wait indefinitely for an interactive B5 takeover."""

    return farm_owned and status in {
        AutonomousStatus.PAUSED_BY_USER,
        AutonomousStatus.AUTO_PAUSED,
        AutonomousStatus.RECOVERY_REQUIRED,
    }


@dataclass
class Counters:
    sessions_started: int = 0
    sessions_completed: int = 0
    evolve_sent: int = 0
    evolve_success: int = 0
    evolve_failed: int = 0
    swap_sent: int = 0
    swap_acknowledged: int = 0
    swap_rejected: int = 0
    cast_sent: int = 0
    cast_accepted: int = 0
    cast_rejected: int = 0
    duplicate_inputs: int = 0
    duplicate_actions_blocked: int = 0
    misclicks: int = 0
    partial_inputs: int = 0
    wrong_turn_inputs: int = 0
    wrong_turn_actions_blocked: int = 0
    stale_actions: int = 0
    stale_actions_blocked: int = 0
    expired_actions: int = 0
    action_response_timeouts: int = 0
    action_response_wait_extensions: int = 0
    user_state_changes: int = 0
    pass_required: int = 0
    policy_no_safe_move: int = 0
    dead_board: int = 0
    sequence_desync: int = 0
    too_late: int = 0
    recovery_steps: int = 0
    input_actions_total: int = 0
    turn_consuming_actions_total: int = 0
    evolve_attempts: int = 0
    swap_actions: int = 0
    cast_actions: int = 0
    undefined_policy: int = 0
    local_turns_observed: int = 0
    boss_turns_observed: int = 0
    action_aborted_due_lifecycle: int = 0
    swap_aborted_due_lifecycle: int = 0
    safety_limit_reached: int = 0
    boss_turn_inputs: int = 0
    postmatch_inputs: int = 0
    lobby_inputs: int = 0
    input_after_combat: int = 0
    local_turn_deadline_safe_stops: int = 0
    auto_pass_started: int = 0
    pass_confirmed_idle_1: int = 0
    pass_confirmed_idle_2: int = 0
    pass_state_unconfirmed: int = 0
    pass_aborted: int = 0
    pass_gameplay_inputs: int = 0
    wrong_third_pass: int = 0
    mandatory_reset_actions: int = 0
    mandatory_actions_required: int = 0
    mandatory_swap_sent: int = 0
    mandatory_swap_acknowledged: int = 0
    mandatory_swap_rejected: int = 0
    mandatory_cast_sent: int = 0
    mandatory_cast_accepted: int = 0
    mandatory_cast_rejected: int = 0
    mandatory_reset_unknown: int = 0
    reset_baselines_confirmed: int = 0
    pass_reset_cycles_confirmed: int = 0
    pass_after_reset_idle_1: int = 0
    cast_reset_correlations: int = 0
    evolve_proposals: int = 0
    evolve_only_turn_waits: int = 0
    evolve_only_turns_completed: int = 0
    evolve_only_authoritative_idle_events: int = 0
    cast_proposals: int = 0
    attack_priority_evolve_violations: int = 0
    same_turn_swap_after_cast: int = 0
    policy_branches: dict[str, int] = field(default_factory=dict)


@dataclass(frozen=True)
class B4CastAcceptanceEvidence:
    accepted: bool
    reason: str
    session: Any
    card_object_address: int | None
    card_id: int | None
    card_name: str | None
    card_element_type: str | None
    card_interaction_authority: str | None
    actual_cost: int | None
    cost_source: str | None
    mana_before: int | None
    mana_after: int | None
    expected_mana_after: int | None
    source_turn: int
    observed_turn: int | None
    observed_current_player: str | None
    response_accepted: bool
    card_state_accepted: bool
    direct_owner_mana_accepted: bool
    card_interactable_before: bool | None
    card_interactable_after: bool | None
    has_used_this_turn_before: bool | None
    has_used_this_turn_after: bool | None
    last_turn_used_before: int | None
    last_turn_used_after: int | None
    consuming_transition_seen: bool


@dataclass(frozen=True)
class EvolveOnlyTurnWait:
    """Zero-input wait after EVOLVE when no safe same-turn input remains.

    The game has now shown that a terminal EVOLVE attempt, successful or
    failed, can make the remainder of that local turn non-AFK: the opponent
    turn arrives without a correlated AFK payload. An unconfirmed EVOLVE can
    instead become a real server AFK turn. This state therefore must not borrow
    PASS_WAIT or mutate/count an intentional PASS; it only observes the exact
    server outcome and lets GameOwnedIdleCache ingest any real AFK payload.
    """

    session: Any
    match_id: str
    source_turn: int
    source_srv_seq: int
    board_hash: str
    source_local_move_sequence: int | None
    started_timestamp: str
    gameplay_inputs_total: int
    opponent_turn_observed: bool = False
    authoritative_idle_observed: bool = False
    direct_idle_requires_turn_correlation: bool = False
    origin: str = "TERMINAL_EVOLVE_POLICY_PASS"


def _evolve_only_turn_wait_status(
    wait: EvolveOnlyTurnWait,
    *,
    current_session: Any,
    current_match_id: str | None,
    current_turn: int | None,
    is_local_turn: bool | None,
    current_local_move_sequence: int | None,
    gameplay_inputs_total: int,
) -> str:
    """Classify an EVOLVE-only zero-input turn without inventing AFK state."""

    if current_session != wait.session:
        return "ABORT_SESSION_CHANGED"
    if current_match_id is None or current_turn is None or is_local_turn is None:
        return "WAIT_RUNTIME"
    if current_match_id != wait.match_id:
        return "ABORT_SESSION_CHANGED"
    if gameplay_inputs_total != wait.gameplay_inputs_total:
        return "ABORT_GAMEPLAY_INPUT_OBSERVED"
    if (
        wait.source_local_move_sequence is not None
        and current_local_move_sequence is not None
        and current_local_move_sequence != wait.source_local_move_sequence
    ):
        return "ABORT_LOCAL_MOVE_SEQUENCE_CHANGED"
    if current_turn < wait.source_turn:
        return "ABORT_TURN_REGRESSED"
    if current_turn == wait.source_turn:
        return "WAIT_SOURCE_TURN"
    if is_local_turn:
        return "COMPLETED_NEXT_LOCAL_TURN"
    return "WAIT_OPPONENT_TURN"


def _can_wait_after_unconfirmed_evolve(
    pending: PendingAutonomousAction,
    *,
    pass_stage: str,
    active_session: Any,
    current_turn: int | None,
    is_local_turn: bool | None,
    is_first_local_turn: bool,
    lifecycle_active: bool,
    board_current_valid: bool,
    idle_can_pass: bool,
    idle_must_act: bool,
    sequence_desync: bool,
    timeout_reason: str,
) -> tuple[bool, str]:
    """Permit a zero-input wait, never a repeated EVOLVE click.

    This is deliberately limited to the production B5 controller used by the
    Phase 2D farm. A confirmed consuming reset (or exact idle=0/1) must make
    one AFK outcome safe. The authoritative event later decides whether the
    server counted a pass; this function never increments idle locally.
    """

    if pass_stage != "B5":
        return False, "NOT_B5_PRODUCTION"
    if pending.identity.action is not PolicyAction.EVOLVE or pending.consumes_turn:
        return False, "NOT_NONCONSUMING_EVOLVE"
    if active_session != pending.identity.source.session:
        return False, "SESSION_CHANGED"
    if current_turn != pending.identity.source.turn or is_local_turn is not True:
        return False, "SOURCE_TURN_CHANGED"
    if is_first_local_turn:
        return False, "FIRST_LOCAL_TURN_FORBIDDEN"
    if not lifecycle_active or not board_current_valid:
        return False, "CURRENT_COMBAT_BOARD_UNPROVEN"
    if sequence_desync:
        return False, "SEQUENCE_DESYNC"
    # The response observer may reach the action floor immediately, or only
    # after using its one bounded read-only extension.  Both are terminal
    # observation timeouts and neither authorizes another EVOLVE click.  The
    # remaining session/turn/board/idle checks above are the safety proof for
    # waiting through the server-owned end of this turn.
    if timeout_reason not in {
        "INSUFFICIENT_SAFE_TURN_TIME",
        "EXTENSION_LIMIT_REACHED",
    }:
        return False, "TIMEOUT_OBSERVATION_STATE_UNSAFE"
    if not idle_can_pass or idle_must_act:
        return False, "AUTHORITATIVE_IDLE_DOES_NOT_ALLOW_PASS"
    return True, "SAFE_ZERO_INPUT_WAIT_AFTER_UNCONFIRMED_EVOLVE"


def _b4_evolve_forbidden(
    *, stage: str, mana_priority: ManaPriority, action: PolicyAction
) -> bool:
    """Hard controller assertion: B4 ATTACK can never reach EVOLVE input."""

    return bool(
        stage == "B4"
        and mana_priority is ManaPriority.ATTACK
        and action is PolicyAction.EVOLVE
    )


def _b4_cast_acceptance_evidence(
    pending: PendingAutonomousAction,
    *,
    mana_after: int | None,
    card_after: CardState | None,
    observed_turn: int | None,
    observed_current_player: str | None,
) -> B4CastAcceptanceEvidence:
    """Require cost, mana, card/response and exact consuming-turn evidence."""

    expected_mana_after = (
        pending.mana_before - pending.mana_cost
        if pending.mana_before is not None
        and pending.mana_cost is not None
        and pending.mana_cost > 0
        else None
    )
    response_accepted = bool(
        pending.server_response_seen and pending.response_success is True
    )
    same_card = bool(
        card_after is not None
        and card_after.object_address == pending.card_object_address
        and card_after.card_id == pending.card_id
        and card_after.is_attack
    )
    card_state_accepted = bool(
        same_card
        and card_after is not None
        and card_after.last_turn_used == pending.identity.source.turn
        and (
            card_after.has_used_this_turn
            or card_after.interactable is False
            or observed_turn != pending.identity.source.turn
        )
    )
    exact_mana = bool(
        expected_mana_after is not None
        and expected_mana_after >= 0
        and mana_after == expected_mana_after
    )
    exact_turn = bool(
        pending.consuming_transition_seen
        and observed_turn == pending.identity.source.turn + 1
        and observed_current_player
        and observed_current_player.casefold()
        != pending.identity.source.current_turn_player.casefold()
    )
    # The fast standard-card path deliberately avoids discovering a managed
    # CardUI wrapper.  It therefore cannot expose CardUI.lastTurnUsed or
    # hasUsedThisTurn after the click.  For this exact authority only, the
    # combination of the full runtime cost delta and the immediately following
    # opponent turn is the server-owned acceptance proof.  Either signal alone
    # remains insufficient.
    direct_owner_mana_accepted = bool(
        pending.card_interaction_authority
        == "BOARD_SELECTED_CARDDATA_CARD_STRIP"
        and exact_mana
        and exact_turn
    )
    accepted = bool(
        pending.identity.action is PolicyAction.CAST
        and pending.card_interactable_before is True
        and pending.card_has_used_this_turn_before is False
        and exact_mana
        and exact_turn
        and (
            response_accepted
            or card_state_accepted
            or direct_owner_mana_accepted
        )
    )
    failures: list[str] = []
    if pending.identity.action is not PolicyAction.CAST:
        failures.append("not_cast")
    if pending.card_interactable_before is not True:
        failures.append("card_not_interactable_before")
    if pending.card_has_used_this_turn_before is not False:
        failures.append("card_used_before")
    if not exact_mana:
        failures.append("mana_delta_unproven")
    if not exact_turn:
        failures.append("consuming_turn_unproven")
    if not (
        response_accepted
        or card_state_accepted
        or direct_owner_mana_accepted
    ):
        failures.append("response_card_or_direct_mana_unproven")
    return B4CastAcceptanceEvidence(
        accepted=accepted,
        reason="accepted" if accepted else ",".join(failures),
        session=pending.identity.source.session,
        card_object_address=pending.card_object_address,
        card_id=pending.card_id,
        card_name=pending.card_name,
        card_element_type=pending.card_element_type,
        card_interaction_authority=pending.card_interaction_authority,
        actual_cost=pending.mana_cost,
        cost_source=pending.card_cost_source,
        mana_before=pending.mana_before,
        mana_after=mana_after,
        expected_mana_after=expected_mana_after,
        source_turn=pending.identity.source.turn,
        observed_turn=observed_turn,
        observed_current_player=observed_current_player,
        response_accepted=response_accepted,
        card_state_accepted=card_state_accepted,
        direct_owner_mana_accepted=direct_owner_mana_accepted,
        card_interactable_before=pending.card_interactable_before,
        card_interactable_after=(
            card_after.interactable if card_after is not None else None
        ),
        has_used_this_turn_before=pending.card_has_used_this_turn_before,
        has_used_this_turn_after=(
            card_after.has_used_this_turn if card_after is not None else None
        ),
        last_turn_used_before=pending.card_last_turn_used,
        last_turn_used_after=(
            card_after.last_turn_used if card_after is not None else None
        ),
        consuming_transition_seen=pending.consuming_transition_seen,
    )


def _jsonable(value: Any) -> Any:
    if is_dataclass(value):
        return _jsonable(asdict(value))
    if isinstance(value, Enum):
        return value.value
    if isinstance(value, dict):
        return {str(key): _jsonable(item) for key, item in value.items()}
    if isinstance(value, (tuple, list, set)):
        return [_jsonable(item) for item in value]
    if isinstance(value, Path):
        return str(value)
    return value


def _write(log: Any, event: str, **fields: Any) -> None:
    timestamp = utc_timestamp()
    payload = {"timestamp": timestamp, "event": event, **_jsonable(fields)}
    log.write(json.dumps(payload, ensure_ascii=False, separators=(",", ":")) + "\n")
    # Keep the established action_result event for Stage A/report tooling and
    # add the explicit Stage B2 terminal vocabulary requested for every
    # accepted, rejected, expired or aborted autonomous action.
    if event == "action_result" and (
        fields.get("action") is not None or fields.get("pending") is not None
    ):
        terminal = {**payload, "event": "action_terminal"}
        log.write(
            json.dumps(terminal, ensure_ascii=False, separators=(",", ":"))
            + "\n"
        )
    log.flush()


def _persist_fatal_controller_error(
    args: argparse.Namespace,
    exc: BaseException,
) -> Path | None:
    """Append an otherwise-unhandled controller failure to durable JSONL.

    The controller is normally launched in a hidden process, so stderr alone is not
    acceptable diagnostic evidence.  This helper must never mask the original
    failure; if the configured log cannot be opened it returns ``None``.
    """

    configured = getattr(args, "log", None)
    fatal_stage = str(
        getattr(args, "pass_acceptance_stage", "B3") or "B3"
    ).casefold()
    path = (
        Path(configured).resolve()
        if configured is not None
        else (
            current_app_paths().logs_root
            / f"phase2c2b_stage_{fatal_stage}_fatal_{datetime.now():%Y%m%d_%H%M%S}.jsonl"
        ).resolve()
    )
    try:
        path.parent.mkdir(parents=True, exist_ok=True)
        with path.open("a", encoding="utf-8", buffering=1) as log:
            _write(
                log,
                "controller_fatal_error",
                exceptionType=type(exc).__name__,
                detail=str(exc),
                traceback="".join(
                    traceback.format_exception(type(exc), exc, exc.__traceback__)
                ),
                failClosed=True,
                automaticInputDisabled=True,
            )
        return path
    except (OSError, RuntimeError, TypeError, ValueError):
        return None


def _beep(kind: str, enabled: bool) -> bool:
    if not enabled or winsound is None:
        return False
    patterns = {
        # One pause alert is a deliberately unmistakable three-tone pattern.
        # The previous 120 ms chirp was lost under normal game audio in the
        # Stage B3 retry even though the controller had already fail-closed.
        "pause": ((760, 220), (520, 220), (760, 320)),
        "resume": ((780, 100), (930, 100)),
        "recovery": ((440, 180), (330, 260)),
        "success": ((880, 140), (1100, 220)),
    }
    try:
        for frequency, duration in patterns[kind]:
            winsound.Beep(frequency, duration)
        return True
    except RuntimeError:
        return False


def _attack_cost(card: CardState) -> int:
    return _attack_cost_evidence(card)[0]


def _attack_cost_evidence(card: CardState) -> tuple[int, str]:
    if card.mana_cost > 0:
        return card.mana_cost, "CardData.manaCost"
    if card.condition_use is not None and card.condition_use > 0:
        return int(card.condition_use), "CardData.conditionUse"
    raise ValueError("attack card actual mana cost is UNKNOWN")


def _must_pause_for_no_safe_move(
    decision: PolicyDecision,
    *,
    legal_move_count: int,
    safe_move_count: int,
    first_local_turn: bool | None,
) -> bool:
    """Keep the terminal safety pause except for the mandatory Sword branch."""

    # EVOLVE is non-consuming and must always be attempted before board
    # safety is considered. CAST is itself the consuming safe action and also
    # does not depend on a board swap. Only an otherwise-unsafe Sword SWAP is
    # exempt among board actions.
    if decision.action in {
        PolicyAction.EVOLVE,
        PolicyAction.CAST,
        PolicyAction.PASS,
    }:
        return False
    # An unknown authoritative PASS state is distinct from a generic
    # no-safe-move policy failure and is classified later as its own safe stop.
    if (
        decision.action is PolicyAction.NONE
        and decision.trace.blocker == "GAME_OWNED_SKIP_STATE_UNKNOWN"
    ):
        return False
    # A decision that finished after the configured action floor is not a
    # gameplay conclusion about move safety.  The dedicated deadline branch
    # below records a zero-input late turn and lets the next authoritative turn
    # re-evaluate; classifying it here as POLICY_NO_SAFE_MOVE permanently stops
    # an otherwise healthy farm run.
    if (
        decision.action is PolicyAction.NONE
        and decision.trace.blocker == "TURN_TIMER_SAFETY_MARGIN"
    ):
        return False
    return bool(
        legal_move_count > 0
        and safe_move_count == 0
        and first_local_turn is not True
        and not (
            decision.action is PolicyAction.SWAP
            and (
                decision.trace.policy_step == "STEP_2_SWORD"
                or decision.trace.skip_status.value
                == "pass_forbidden_mandatory_action"
            )
            and decision.move is not None
        )
    )


def _policy_none_stop_reason(
    decision: PolicyDecision,
    *,
    legal_move_count: int,
    safe_move_count: int,
) -> str:
    if decision.trace.blocker == "GAME_OWNED_SKIP_STATE_UNKNOWN":
        return "PASS_STATE_UNKNOWN"
    if legal_move_count > 0 and safe_move_count == 0:
        return "POLICY_NO_SAFE_MOVE"
    return decision.trace.blocker or "POLICY_NONE"


def _fusion_terminal_result(
    pending: PendingAutonomousAction,
    fusion_now: FusionState | None,
) -> ActionResultKind | None:
    """Classify a Fusion response or its durable terminal equivalent.

    A local ``MATCH_FUSION_RES success=false`` is itself the terminal failure
    result requested by Stage B2. A current-session MatchService transition
    from ``LocalFusionUsed=false`` to ``true`` with
    ``LocalFusionLastAttemptTurn == source turn`` is the terminal success
    equivalent and can arrive before the heap message scan. A positive response
    still requires the durable ``fusion.used`` state.
    """

    durable_success = bool(
        fusion_now is not None
        and pending.fusion_used_before is False
        and fusion_now.used is True
        and fusion_now.last_attempt_turn == pending.identity.source.turn
    )
    if durable_success:
        return ActionResultKind.EVOLVE_SUCCESS
    if not pending.server_response_seen or pending.response_success is None:
        return None
    if pending.response_success is False:
        return ActionResultKind.EVOLVE_FAILED
    if fusion_now is not None and fusion_now.used is True:
        return ActionResultKind.EVOLVE_SUCCESS
    return None


def _latest_fusion_for_terminal(
    state: GameState | None,
    provider_fusion: FusionState | None,
) -> FusionState | None:
    """Use the newest current-session Fusion sample while Board DTO lags.

    ``MemoryBoardStateProvider`` reads and validates MatchService/Fusion before
    it attempts to resolve and stabilize the newest board batch. Therefore its
    ``observed_fusion`` remains authoritative for the current lifecycle even
    when that poll cannot yet publish a complete ``GameState``. A complete
    GameState is still required before policy can issue the same-turn follow-up
    action.
    """

    if provider_fusion is not None:
        return provider_fusion
    return state.fusion if state is not None else None


def _post_evolve_settle_status(
    state: GameState,
    *,
    source_session: Any,
    source_turn: int,
    not_before: float,
    now: float,
) -> str:
    """Keep follow-up input out of the proven Fusion animation window."""

    if (
        state.battle.session_key != source_session
        or state.battle.turn_number != source_turn
        or state.battle.is_local_turn is not True
    ):
        return "SOURCE_CHANGED"
    return "WAIT" if now < not_before else "READY"


def _evolve_terminal_touches_turn(result: ActionResultKind) -> bool:
    """Both accepted and rejected Fusion attempts are server-visible activity."""

    return result in {
        ActionResultKind.EVOLVE_SUCCESS,
        ActionResultKind.EVOLVE_FAILED,
    }


def _sent_action_count(counters: Counters) -> int:
    """Count only inputs that were fully sent to the foreground game window."""

    return counters.input_actions_total


def _turn_consuming_action_count(counters: Counters) -> int:
    return counters.turn_consuming_actions_total


def _action_budget_reached(
    counters: Counters,
    *,
    max_actions: int,
    pending: PendingAutonomousAction | None,
) -> bool:
    """Stop between actions, never while the last input awaits a terminal result."""

    return bool(
        max_actions > 0
        and pending is None
        and _sent_action_count(counters) >= max_actions
    )


def _bounded_stop_reason(
    counters: Counters,
    *,
    max_turn_actions: int,
    max_total_input_actions: int,
    pending: PendingAutonomousAction | None,
    legacy_max_actions: int | None = None,
) -> str | None:
    """Return a hard-stop reason only after the latest input is terminal."""

    if pending is not None:
        return None
    if (
        legacy_max_actions is not None
        and counters.input_actions_total >= legacy_max_actions
    ):
        return "LEGACY_ACTION_BUDGET_REACHED"
    if (
        max_turn_actions > 0
        and counters.turn_consuming_actions_total >= max_turn_actions
    ):
        return "AUTO_STOP_AFTER_ACK"
    if (
        max_total_input_actions > 0
        and counters.input_actions_total >= max_total_input_actions
    ):
        return "AUTO_PAUSE_SAFETY_LIMIT"
    return None


def _runtime_observation_for_controller(
    target: Any,
    monitor: RuntimeSequenceMonitor,
    *,
    session_key: Any,
    match_id: str,
    turn: int | None,
    srv_seq: int | None,
    fast_bounded_handoff: bool,
) -> RuntimeSequenceObservation:
    """Observe runtime without rescanning the already-proven B1 opening.

    The Phase 2D.4 B1 recovery coordinator hands over the same provider and
    sequence monitor after it has already proven a fresh opening. On only the
    first handoff iteration, a direct MatchService read is sufficient to bind
    turn ownership/timer while preserving those existing proofs. Every later
    iteration uses the normal monitor so terminal server evidence is still
    required for the one action.
    """

    if fast_bounded_handoff:
        _service, runtime = read_match_runtime(target)
        return RuntimeSequenceObservation(runtime, (), False)
    return monitor.poll(
        session_key=session_key,
        match_id=match_id,
        turn=turn,
        srv_seq=srv_seq,
        timestamp=utc_timestamp(),
    )


def _fresh_opening_handoff_state(
    cached: GameState | None,
    runtime: Any,
    *,
    expected_session: Any,
) -> GameState | None:
    """Refresh a proven immutable opening from cheap direct MatchService roots.

    Entry already proved the exact 64-cell MATCH_START board with two stable
    confirmations. Before any local move, that board cannot change. Reusing it
    avoids a second provider/heap stabilization cycle, while direct roots must
    still prove the exact session, first local turn, pristine move sequence and
    a positive current timer on every use.
    """

    if cached is None or cached.phase is not GamePhase.COMBAT:
        return None
    battle = cached.battle
    opening_source = any("MATCH_START" in source for source in battle.sources)
    same_local_owner = bool(
        runtime.current_player
        and runtime.local_username
        and runtime.current_player.casefold() == runtime.local_username.casefold()
    )
    if not (
        cached.board is not None
        and cached.board.production_ready
        and battle.session_key == expected_session
        and battle.match_id == expected_session.match_id
        and battle.turn_number in (0, 1)
        and battle.local_move_sequence == 0
        and battle.last_move_sequence in (None, -1, 0)
        and opening_source
        and runtime.match_id == expected_session.match_id
        and runtime.turn in (0, 1)
        and runtime.local_move_sequence == 0
        and runtime.last_move_sequence in (None, -1, 0)
        and runtime.remaining is not None
        and runtime.remaining >= 1
        and same_local_owner
    ):
        return None
    refreshed_battle = replace(
        battle,
        turn_number=int(runtime.turn),
        current_turn_player=str(runtime.current_player),
        local_username=str(runtime.local_username),
        is_local_turn=True,
        turn_time_remaining_seconds=int(runtime.remaining),
        turn_timer_source="MatchService.server_tick",
        local_move_sequence=0,
        last_move_sequence=runtime.last_move_sequence,
        last_move_from_col=None,
        last_move_from_row=None,
        last_move_to_col=None,
        last_move_to_row=None,
    )
    return replace(cached, timestamp=utc_timestamp(), battle=refreshed_battle)


def _record_turn_observation(
    counters: Counters,
    observed: set[tuple[Any, int, str]],
    *,
    session: Any,
    turn: int | None,
    current_player: str | None,
    local_username: str | None,
    progress_observer: (
        Callable[[str, Any, int, int, int], None] | None
    ) = None,
) -> str | None:
    """Count authoritative local/opponent turns once, never once per poll."""

    if session is None or turn is None or not current_player or not local_username:
        return None
    role = (
        "LOCAL"
        if current_player.casefold() == local_username.casefold()
        else "BOSS"
    )
    key = (session, int(turn), role)
    if key in observed:
        return None
    observed.add(key)
    if role == "LOCAL":
        counters.local_turns_observed += 1
    else:
        counters.boss_turns_observed += 1
    if progress_observer is not None:
        try:
            progress_observer(
                role,
                session,
                int(turn),
                counters.local_turns_observed,
                counters.boss_turns_observed,
            )
        except Exception:
            # Desktop status is diagnostic only. A rendering/projection fault
            # must never affect gameplay, memory polling, or input ownership.
            pass
    return role


def _observe_fast_runtime_turn(
    tracker: TurnTransitionTracker,
    counters: Counters,
    observed: set[tuple[Any, int, str]],
    *,
    session: Any,
    turn: int | None,
    current_player: str | None,
    local_username: str | None,
    progress_observer: (
        Callable[[str, Any, int, int, int], None] | None
    ) = None,
) -> tuple[TurnTransitionObservation | None, str | None]:
    """Observe fast transition and status progress through their own APIs.

    The transition tracker deliberately owns only action/turn proof. Desktop
    status projection belongs to the deduplicated counter helper and must not
    be passed into ``TurnTransitionTracker.observe_runtime``.
    """

    transition = tracker.observe_runtime(
        session=session,
        turn=turn,
        current_player=current_player,
        local_username=local_username,
    )
    role = _record_turn_observation(
        counters,
        observed,
        session=session,
        turn=turn,
        current_player=current_player,
        local_username=local_username,
        progress_observer=progress_observer,
    )
    return transition, role


def _local_turn_action_deadline_reached(
    *,
    session: Any,
    turn: int | None,
    match_id: str | None,
    current_player: str | None,
    local_username: str | None,
    remaining_seconds: int | None,
    warning_seconds: int,
    status: AutonomousStatus,
    pending: PendingAutonomousAction | None,
    consuming_action_turns: set[tuple[Any, int]],
) -> bool:
    """Fail closed before a local turn silently expires without an action."""

    if (
        session is None
        or turn is None
        or not match_id
        or match_id != getattr(session, "match_id", None)
        or not current_player
        or not local_username
        or current_player.casefold() != local_username.casefold()
        or remaining_seconds is None
        or remaining_seconds < 0
        or remaining_seconds >= warning_seconds
        or status is not AutonomousStatus.RUNNING
        or pending is not None
    ):
        return False
    return (session, int(turn)) not in consuming_action_turns


def _local_turn_deadline_warning_seconds(minimum_action_time: int) -> int:
    """Allow input at one displayed second; block only below that floor."""

    if minimum_action_time < 0:
        raise ValueError("minimum action time cannot be negative")
    return min(
        max(minimum_action_time, MANDATORY_RESET_RECOVERY_FLOOR_SECONDS),
        10,
    )


def _mandatory_reset_recovery_warning_seconds(minimum_action_time: int) -> int:
    """Apply the same hard production floor to an exact idle-2 reset turn."""

    if not 1 <= minimum_action_time <= 10:
        raise ValueError("minimum action time must be between 1 and 10 seconds")
    return max(minimum_action_time, MANDATORY_RESET_RECOVERY_FLOOR_SECONDS)


def _late_mandatory_reset_recovery_required(
    *,
    pass_stage: str,
    mandatory_reset_pending: bool,
    readiness: Any,
    action: PolicyAction,
    remaining_seconds: int | None,
    warning_seconds: int,
) -> bool:
    """Select recovery only for the exact late authoritative idle-2 turn."""

    return bool(
        pass_stage == "B5"
        and mandatory_reset_pending
        and readiness.readiness is PassReadiness.PASS_FORBIDDEN_MANDATORY_ACTION
        and readiness.must_act_now is True
        and readiness.state is not None
        and readiness.state.idle_count == readiness.state.threshold - 1
        # A normal policy pass reaches this helper after selecting the
        # consuming SWAP/CAST.  On a genuinely late poll the unchanged
        # actionability gate instead returns NONE before a consuming action
        # can be selected.  That exact NONE case still needs the same bounded
        # recovery path; otherwise the mandatory-action assertion below
        # would stop the controller in active combat and leave the game to
        # consume the third idle turn.
        and action in {PolicyAction.SWAP, PolicyAction.CAST, PolicyAction.NONE}
        and remaining_seconds is not None
        and 0 <= remaining_seconds < warning_seconds
    )


def _verified_dead_board_preempts_mandatory_action(
    *,
    mandatory_reset_pending: bool,
    action: PolicyAction,
    dead_board: bool | None,
) -> bool:
    """Route an exhaustive dead board to recovery before the idle-2 assertion.

    ``EXIT_MATCH`` is a proposal-only technical result: it sends no gameplay
    input and must never be mistaken for a third PASS.  When the exact board
    scan proves there is no match-producing swap, the outer farm coordinator
    already owns the bounded exit/re-entry path.  That evidence is stronger
    than the generic requirement to choose SWAP/CAST at authoritative idle 2.

    Every other non-consuming action remains subject to the mandatory-action
    assertion below; this helper does not weaken the three-idle fail-safe.
    """

    return bool(
        mandatory_reset_pending
        and (action is PolicyAction.EXIT_MATCH or dead_board is True)
    )


def _without_optional_card_actions(
    state: GameState,
    suppressed: frozenset[PolicyAction],
) -> GameState:
    """Mask failed optional UI actions for one source turn only.

    A card locator failure is not evidence that normal board input is unsafe.
    The controller therefore re-runs the unchanged BASIC policy with only the
    failed optional action unavailable.  The caller scopes ``suppressed`` to
    the authoritative combat session and turn.
    """

    cards = state.cards
    fusion = state.fusion
    if PolicyAction.CAST in suppressed:
        cards = tuple(
            replace(card, interactable=False) if card.is_attack else card
            for card in cards
        )
    if PolicyAction.EVOLVE in suppressed and fusion is not None:
        fusion = replace(fusion, ui_interactable=False)
    if cards is state.cards and fusion is state.fusion:
        return state
    return replace(state, cards=cards, fusion=fusion)


def _retain_mandatory_consuming_action_requirement(
    state: GameState,
    *,
    mandatory_reset_pending: bool,
) -> GameState:
    """Keep an exact 2/3 requirement fail-closed until reset is proven.

    A mandatory SWAP can outlive its response deadline while runtime sequence
    state advances without enough coordinate evidence to attribute that
    advance to the input.  A later per-turn idle view may then be UNKNOWN
    because its source turn is stale.  That uncertainty must not re-enable the
    non-consuming EVOLVE branch or a third PASS.  Preserve only the already
    proven requirement to choose SWAP/CAST; do not synthesize an idle count or
    treat an unattributed sequence advance as reset evidence.
    """

    if (
        not mandatory_reset_pending
        or state.battle.consecutive_pass_status
        is GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION
    ):
        return state
    return replace(
        state,
        battle=replace(
            state.battle,
            consecutive_pass_status=(
                GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION
            ),
            consecutive_pass_confidence="retained_exact_idle_2_pending_reset",
        ),
    )


def _policy_branch(policy_step: str) -> str:
    """Map exact BASIC trace steps to the B3 report vocabulary."""

    if policy_step == "STEP_5_SAFE_FALLBACK":
        return "SAFE_RESOURCE_FALLBACK"
    for branch in (
        "EVOLVE",
        "SWORD",
        "RAGE",
        "MANA",
        "HEALTH",
        "CAST",
        "DRAIN",
        "SHIELD",
    ):
        if branch in policy_step:
            return branch
    if policy_step.startswith("STEP_7_MANDATORY"):
        return "MANDATORY"
    if policy_step.startswith("STEP_6_PASS"):
        return "PASS_REQUIRED"
    return policy_step or "UNDEFINED"


def _record_policy_observation(
    counters: Counters,
    observed: set[tuple[Any, ...]],
    *,
    state: GameState,
    decision: Any,
) -> str | None:
    """Count one policy branch per immutable source/selected proposal."""

    key = (
        state.dedup_key,
        state.battle.turn_number,
        decision.trace.policy_step,
        decision.action,
        decision.move,
        decision.card_object_address,
    )
    if key in observed:
        return None
    observed.add(key)
    branch = _policy_branch(decision.trace.policy_step)
    counters.policy_branches[branch] = counters.policy_branches.get(branch, 0) + 1
    if decision.action is PolicyAction.EVOLVE:
        counters.evolve_proposals += 1
    elif decision.action is PolicyAction.CAST:
        counters.cast_proposals += 1
    return branch


def _record_sent_input_safety(counters: Counters, state: GameState) -> None:
    """Telemetry backstop for invariants that must remain zero in B3."""

    lifecycle = state.battle.combat_lifecycle
    if state.battle.is_local_turn is not True:
        counters.wrong_turn_inputs += 1
        counters.boss_turn_inputs += 1
    if lifecycle is CombatLifecycleState.POSTMATCH:
        counters.postmatch_inputs += 1
    if lifecycle is CombatLifecycleState.LOBBY:
        counters.lobby_inputs += 1
    if lifecycle is not CombatLifecycleState.ACTIVE:
        counters.input_after_combat += 1


def _classify_combat_result(state: GameState | None) -> str:
    if state is None:
        return "ENDED_RESULT_UNKNOWN"
    if state.player is not None and state.player.hp is not None and state.player.hp <= 0:
        return "LOSS"
    boss = next(
        (participant for participant in state.opponents if participant.is_boss is True),
        state.opponents[0] if state.opponents else None,
    )
    if boss is not None and boss.hp is not None and boss.hp <= 0:
        return "WIN"
    return "ENDED_RESULT_UNKNOWN"


def _pass_cycle_coverage(counters: Counters) -> str:
    if counters.pass_reset_cycles_confirmed > 0:
        return "FULL"
    if (
        counters.pass_confirmed_idle_1 > 0
        or counters.pass_confirmed_idle_2 > 0
        or counters.mandatory_actions_required > 0
    ):
        return "PARTIAL"
    return "NOT_OBSERVED"


def _reported_cast_reset_confidence(
    observed: Sequence[ResetConfidence],
    capability: Any,
) -> str:
    values = set(observed)
    values.add(
        getattr(
            capability,
            "confidence",
            ResetConfidence.RESET_UNKNOWN,
        )
    )
    if values & {
        ResetConfidence.RESET_CONFIRMED_EXPLICIT,
        ResetConfidence.RESET_CONFIRMED_BY_SERVER_SEQUENCE,
    }:
        return "CONFIRMED"
    if ResetConfidence.RESET_STRONGLY_INFERRED in values:
        return "STRONGLY_INFERRED"
    return "UNKNOWN"


def _attempt_classification(
    stop_reason: str,
    counters: Counters,
    *,
    pass_stage: str = "B3",
) -> str:
    if stop_reason.startswith("B4_CAST_ACCEPTED"):
        unsafe = (
            counters.duplicate_inputs
            + counters.misclicks
            + counters.partial_inputs
            + counters.wrong_turn_inputs
            + counters.stale_actions
            + counters.boss_turn_inputs
            + counters.postmatch_inputs
            + counters.lobby_inputs
            + counters.input_after_combat
            + counters.same_turn_swap_after_cast
            + counters.evolve_sent
            + counters.attack_priority_evolve_violations
        )
        return (
            "B4_PASS_STRONG"
            if counters.cast_accepted >= 1 and unsafe == 0
            else "B4_CAST_ACCEPTED_WITH_SAFETY_FINDING"
        )
    if stop_reason == "COMBAT_LIFECYCLE_ENDED":
        unsafe = (
            counters.duplicate_inputs
            + counters.misclicks
            + counters.partial_inputs
            + counters.wrong_turn_inputs
            + counters.stale_actions
            + counters.boss_turn_inputs
            + counters.postmatch_inputs
            + counters.lobby_inputs
            + counters.input_after_combat
            + counters.wrong_third_pass
        )
        if pass_stage == "B5":
            if counters.sessions_completed != 1 or unsafe != 0:
                return "FULL_MATCH_COMPLETED_WITH_SAFETY_FINDING"
            return (
                "B5_PASS_STRONG"
                if counters.pass_reset_cycles_confirmed > 0
                else "FULL_MATCH_PASS"
            )
        return (
            "FULL_COMBAT_COMPLETED"
            if counters.sessions_completed == 1 and unsafe == 0
            else "FULL_COMBAT_COMPLETED_WITH_SAFETY_FINDING"
        )
    if stop_reason in {
        "PASS_REQUIRED_BUT_DISABLED",
        "PASS_STATE_UNKNOWN",
        "PASS_STATE_UNCONFIRMED",
        "PASS_ABORTED_STATE_CHANGED",
        "PASS_ABORTED_COMBAT_END",
        "SEQUENCE_DESYNC",
        "ACTIONABILITY_STATE_LOST",
        "CONTROLLER_STALLED_ACTIVE_COMBAT",
        "ACTIVE_COMBAT_PROGRESS_STALLED",
        "ACTIVE_COMBAT_PROGRESS_STALL_PREFLIGHT_REJECTED",
        "LOCAL_PLAYER_LEFT_ACTIVE_COMBAT",
        "LATE_MANDATORY_RESET",
        "ACTION_RESPONSE_TIMEOUT",
        "POLICY_NO_SAFE_MOVE",
        "DEAD_BOARD_NO_REFRESH",
        "REJECTED_SEQUENCE_DESYNC",
        "AUTO_PAUSE_SAFETY_LIMIT",
        "LOCAL_TURN_ACTION_DEADLINE",
        "B4_EVOLVE_FORBIDDEN",
        "B4_SAME_TURN_SWAP_AFTER_CAST_BLOCKED",
    } or stop_reason.startswith("BASIC_"):
        return "SAFE_STOP"
    return "STOPPED_OTHER"


def _combat_end_stop_reason(
    current_stop_reason: str,
    status_before_end: AutonomousStatus,
) -> str:
    """Do not turn an earlier safe terminal pause into a completed B3 PASS."""

    if (
        status_before_end
        in {AutonomousStatus.AUTO_PAUSED, AutonomousStatus.RECOVERY_REQUIRED}
        and current_stop_reason != "PROCESS_OR_CONTROLLER_STOPPED"
    ):
        return current_stop_reason
    return "COMBAT_LIFECYCLE_ENDED"


def _combat_ownership_ended(
    *,
    lifecycle_event: str | None,
    lifecycle_state: CombatLifecycleState | None,
    session_seen: bool,
    active_session: Any,
    state: GameState | None,
) -> bool:
    """Recognize terminal ownership even when BoardTracker says ``postmatch``.

    A terminal provider poll may clear its publishable GameState at the same
    time that CombatLifecycle resolves POSTMATCH. Requiring the legacy literal
    ``board_lost`` event then leaves the controller scanning forever behind a
    visible result modal. Lifecycle ownership is the authoritative boundary;
    no terminal value is inferred here.
    """

    if lifecycle_event == "board_lost":
        return True
    if not session_seen or active_session is None:
        return False
    if state is not None and state.phase is not GamePhase.COMBAT:
        return True
    return lifecycle_state in {
        CombatLifecycleState.POSTMATCH,
        CombatLifecycleState.LOBBY,
        CombatLifecycleState.STALE_SERVER_MATCH,
    }


def _cancel_unsent(
    guard: AutonomousGuard,
    identity: AutonomousActionIdentity,
    *,
    consuming_turns: ConsumingTurnRegistry | None = None,
) -> None:
    """Cancel only proposal-side locks; sent identities remain single-use."""

    guard.cancel_reservation(identity)
    if consuming_turns is not None and identity.action in {
        PolicyAction.SWAP,
        PolicyAction.CAST,
    }:
        consuming_turns.cancel(identity.source.session, identity.source.turn)


def _local_message(message: ServerMessage, state: GameState) -> bool:
    strings = dict(message.payload_strings)
    actor = strings.get("actorUsername") or message.username
    local = state.battle.local_username
    return bool(actor and local and actor.casefold() == local.casefold())


def _authoritative_idle_owner_rejection(
    message_username: str | None,
    local_username: str | None,
) -> str | None:
    """Reject non-local AFK payloads without invalidating cached local truth.

    Message scans can transiently surface an incomplete nested ``afkWarn``
    object (for example a NUL-only username) while the containing turn-end DTO
    is still being populated.  Such a candidate is not evidence about the
    local player's idle state, so callers must ignore it rather than clearing
    an already session-bound state/reset baseline.
    """

    if local_username is None or not local_username.strip():
        return "authoritative_local_username_unknown"
    if message_username is None or not message_username.strip("\x00 \t\r\n"):
        return "authoritative_username_unreadable"
    if message_username.casefold() != local_username.casefold():
        return "authoritative_username_mismatch"
    return None


def _idle_session_id(session: Any) -> str | None:
    if session is None:
        return None
    return (
        f"epoch={session.lifecycle_epoch}|board={hex_pointer(session.board_instance)}"
        f"|match={session.match_id}"
    )


def _pass_lifecycle_evidence(
    lifecycle_state: CombatLifecycleState | None,
    runtime_match_id: str | None,
) -> bool | None:
    """Map runtime evidence without turning a transient provider miss into exit."""

    if lifecycle_state is not None:
        return lifecycle_state is CombatLifecycleState.ACTIVE
    if runtime_match_id is None:
        return False
    return None


def _provider_poll_for_controller(
    provider: MemoryBoardStateProvider,
    *,
    pass_wait_locked: bool,
    active_session: Any,
    fast_opening_runtime: Any | None = None,
) -> ProviderPoll:
    """Never let a board/ACK heap scan hide the transient AFK response.

    PASS_WAIT deliberately sends no gameplay input and cannot evaluate a new
    board.  Its authoritative dependencies are sampled separately through the
    direct MatchService roots and RuntimeSequenceMonitor before this call.  A
    normal provider poll can include a multi-second fallback heap scan, so it
    must be deferred until PASS_WAIT has reached a terminal result.
    """

    if pass_wait_locked and active_session is not None:
        return ProviderPoll(
            state=None,
            publish=False,
            reason="pass_wait_runtime_only",
            session_key=active_session,
        )
    if fast_opening_runtime is not None and active_session is not None:
        state = _fresh_opening_handoff_state(
            provider.last_published_state,
            fast_opening_runtime,
            expected_session=active_session,
        )
        if state is not None:
            return ProviderPoll(
                state=state,
                publish=True,
                reason="proven_opening_direct_runtime_handoff",
                confirmations=2,
                session_key=active_session,
            )
    return provider.poll()


@dataclass(frozen=True)
class PassTerminalDisposition:
    confirmed: bool
    stop: bool
    stop_reason: str | None = None
    begin_p3_mandatory_reset: bool = False
    complete_reset_cycle: bool = False


def _pass_terminal_disposition(
    pass_stage: str,
    result: PassResultKind,
    *,
    p3_reset_validation_pending: bool,
) -> PassTerminalDisposition:
    confirmed = result in {
        PassResultKind.PASS_CONFIRMED_IDLE_1,
        PassResultKind.PASS_CONFIRMED_IDLE_2,
    }
    if not confirmed:
        return PassTerminalDisposition(False, True, result.value)
    if pass_stage == "P1":
        return PassTerminalDisposition(
            True, True, "P1_ONE_AUTONOMOUS_PASS_CONFIRMED"
        )
    if pass_stage == "P2" and result is PassResultKind.PASS_CONFIRMED_IDLE_2:
        return PassTerminalDisposition(
            True, True, "P2_TWO_AUTONOMOUS_PASSES_CONFIRMED"
        )
    if (
        pass_stage == "P3"
        and p3_reset_validation_pending
        and result is PassResultKind.PASS_CONFIRMED_IDLE_1
    ):
        return PassTerminalDisposition(
            True, True, "P3_MANDATORY_RESET_CYCLE_CONFIRMED"
        )
    if (
        pass_stage == "B5"
        and p3_reset_validation_pending
        and result is PassResultKind.PASS_CONFIRMED_IDLE_1
    ):
        return PassTerminalDisposition(
            True,
            False,
            complete_reset_cycle=True,
        )
    return PassTerminalDisposition(
        True,
        False,
        begin_p3_mandatory_reset=(
            pass_stage in {"P3", "B3", "B4", "B5"}
            and result is PassResultKind.PASS_CONFIRMED_IDLE_2
        ),
    )


def _acceptance_forced_pass_decision(
    state: GameState,
    decision: Any,
    *,
    pass_stage: str,
    force_after_actions: int,
    accepted_consuming_actions: int,
    pass_coordinator: AuthoritativePassCoordinator | None,
    idle_readiness: Any,
) -> Any:
    """Override BASIC only for an explicit, bounded P2/P3 acceptance run."""

    eligible = bool(
        force_after_actions > 0
        and pass_stage in {"P2", "P3"}
        and accepted_consuming_actions >= force_after_actions
        and pass_coordinator is not None
        and pass_coordinator.confirmed_passes < pass_coordinator.max_auto_passes
        and state.battle.is_local_turn is True
        and state.battle.is_first_local_turn is not True
        and idle_readiness.can_pass_now is True
        and idle_readiness.must_act_now is not True
    )
    if not eligible:
        return decision
    trace = replace(
        decision.trace,
        selected_action=PolicyAction.PASS,
        policy_step="PHASE_2C2C_FORCED_PASS",
        candidate_count=0,
        why_selected=(
            "Explicit acceptance-only trigger after "
            f"{accepted_consuming_actions} accepted consuming actions; "
            "server-owned idle readiness permits the bounded PASS"
        ),
        candidates=(),
        selected_candidate=None,
        blocker=None,
    )
    return replace(
        decision,
        action=PolicyAction.PASS,
        trace=trace,
        move=None,
        card_object_address=None,
        consumes_turn=True,
        requires_state_reread=False,
    )


def _message_actor(message: ServerMessage) -> str | None:
    strings = dict(message.payload_strings)
    return strings.get("actorUsername") or strings.get("username") or message.username


def _pass_wait_activity_is_fresh(message: ServerMessage, attempt: Any) -> bool:
    """Reject stale/partially-reused DTOs surfaced by a later full heap scan."""

    return bool(
        attempt is not None
        and message.server_sequence is not None
        and message.server_sequence > attempt.source_srv_seq
        and server_timestamp_not_before(
            message.timestamp, attempt.started_timestamp
        )
    )


def _participants_alive(state: GameState) -> bool:
    if state.player is None or state.player.hp is None or state.player.hp <= 0:
        return False
    boss = next(
        (value for value in state.opponents if value.is_boss is True),
        state.opponents[0] if state.opponents else None,
    )
    return bool(boss is not None and boss.hp is not None and boss.hp > 0)


def _observe_consuming_idle_acceptance(
    idle_cache: GameOwnedIdleCache,
    pending: PendingAutonomousAction,
    *,
    kind: AcceptedActivityKind,
    source_srv_seq: int | None,
    source_timestamp: str | None,
    source_message_type: str | None = None,
) -> Any:
    session_id = _idle_session_id(pending.identity.source.session)
    if session_id is None:
        raise ValueError("accepted consuming action has no idle session identity")
    return idle_cache.observe_accepted_activity(
        session_id=session_id,
        kind=kind,
        source_message_type=(
            source_message_type
            or (
                "MATCH_MOVE_RES"
                if kind is AcceptedActivityKind.SWAP
                else "MATCH_CARD_USE_RES"
            )
        ),
        source_srv_seq=source_srv_seq,
        source_turn=pending.identity.source.turn,
        source_timestamp=source_timestamp,
        observed_timestamp=utc_timestamp(),
    )


def _observe_cast_idle_reset(
    idle_cache: GameOwnedIdleCache,
    pending: PendingAutonomousAction,
    *,
    allow_direct_state: bool,
) -> Any | None:
    """Record honest CAST reset candidacy without inventing a response DTO.

    A direct MatchService opponent-turn transition can prove that CAST consumed
    the turn, but it is not a MATCH_CARD_USE_RES/MATCH_SKILL_USE_RES message.
    B5 may retain that distinct provenance so a later server-owned idle payload
    can classify the reset as strongly inferred.  B4 preserves its accepted
    behavior and clears the candidate if the response DTO was not retained.
    """

    response = pending.response_evidence
    if not (
        isinstance(response, ServerMessage)
        and response.event_type in {"MATCH_CARD_USE_RES", "MATCH_SKILL_USE_RES"}
        and pending.server_response_seen
        and pending.response_success is True
    ):
        if not (allow_direct_state and pending.consuming_transition_seen):
            idle_cache.clear("cast_accepted_without_attributed_reset_response")
            return None
        runtime = pending.consuming_transition_evidence
        return _observe_consuming_idle_acceptance(
            idle_cache,
            pending,
            kind=AcceptedActivityKind.CAST,
            source_srv_seq=getattr(runtime, "highest_acked_sequence", None),
            source_timestamp=None,
            source_message_type="DIRECT_CAST_STATE_TRANSITION",
        )
    return _observe_consuming_idle_acceptance(
        idle_cache,
        pending,
        kind=AcceptedActivityKind.CAST,
        source_srv_seq=response.server_sequence,
        source_timestamp=response.timestamp,
        source_message_type=response.event_type,
    )


def _observe_b4_cast_idle_reset(
    idle_cache: GameOwnedIdleCache,
    pending: PendingAutonomousAction,
) -> Any | None:
    """Compatibility wrapper for B4's response-only reset evidence."""

    return _observe_cast_idle_reset(
        idle_cache,
        pending,
        allow_direct_state=False,
    )


def _reset_pass_cycle_after_consuming_action(
    pass_coordinator: AuthoritativePassCoordinator | None,
    reset_baseline: Any,
) -> bool:
    """Align the bounded PASS index with the server's consuming-action reset."""

    if pass_coordinator is None or reset_baseline is None:
        return False
    pass_coordinator.begin_new_reset_cycle(reset_baseline.session_id)
    return True


def _message_rejected(message: ServerMessage) -> bool:
    bools = dict(message.payload_bools)
    return bool(
        message.reject_reason
        or bools.get("rejected") is True
        or bools.get("success") is False
    )


def _same_source(state: GameState, pending: PendingAutonomousAction) -> bool:
    return pending.identity.source.matches(state)


def _terminal_artifact(
    *,
    root: Path,
    event: str,
    target: Any,
    state: GameState,
    policy: BasicPolicyEngine,
) -> str | None:
    try:
        analysis = analyze_game_state(state, policy_engine=policy)
        artifact = write_diagnostic_artifact(
            root,
            event=event,
            state=state,
            analysis=analysis,
            screenshot_capture=lambda path: capture_client_png(target.pid, path),
        )
        return str(artifact.directory)
    except (FileExistsError, OSError, RuntimeError, ValueError):
        return None


def _card_diagnostics(state: GameState) -> dict[str, Any]:
    """Read-only evidence for why a CAST was or was not affordable.

    STEP_3_FINISH_CAST and STEP_5_CAST both draw from the same Attack-card
    pool, so every decision records the exact gate each live card passed or
    failed.  Purely observational: it never influences policy.
    """
    player_mana = state.player.mana if state.player is not None else None
    cards: list[dict[str, Any]] = []
    for card in state.cards:
        mana_cost = card.mana_cost
        condition_use = card.condition_use
        if mana_cost > 0:
            cost: int | None = mana_cost
            cost_source = "CardData.manaCost"
        elif condition_use is not None and condition_use > 0:
            cost = int(condition_use)
            cost_source = "CardData.conditionUse"
        else:
            cost = None
            cost_source = "UNRESOLVED_TREATED_AS_INFINITE"
        gates = {
            "isAttack": card.is_attack,
            "interactable": card.interactable,
            "notActionPending": not card.action_pending,
            "notUsedThisTurn": not card.has_used_this_turn,
            "uiLocated": bool(
                card.ui_slot is not None
                and card.ui_slot_count is not None
                and 0 <= card.ui_slot < card.ui_slot_count
            ),
        }
        blocked_by = tuple(name for name, passed in gates.items() if not passed)
        affordable = (
            None
            if cost is None or player_mana is None
            else player_mana >= cost
        )
        cards.append(
            {
                "cardId": card.card_id,
                "objectAddress": card.object_address,
                "name": card.name,
                "elementType": card.element_type,
                "skillType": card.skill_type,
                "manaCost": mana_cost,
                "conditionUse": condition_use,
                "resolvedCost": cost,
                "costSource": cost_source,
                "gates": gates,
                "blockedBy": blocked_by,
                "isPlaceholder": card.is_placeholder,
                "hasUsedThisMatch": card.has_used_this_match,
                "lastTurnUsed": card.last_turn_used,
                "cooldownTurns": card.cooldown_turns,
                "uiSlot": card.ui_slot,
                "uiSlotCount": card.ui_slot_count,
                "interactionAuthority": card.interaction_authority,
                "affordable": affordable,
                "usableNow": bool(not blocked_by and affordable),
            }
        )
    attack_cards = [value for value in cards if value["gates"]["isAttack"]]
    return {
        "playerMana": player_mana,
        "cardCount": len(cards),
        "attackCardCount": len(attack_cards),
        "attackPassingGates": sum(1 for v in attack_cards if not v["blockedBy"]),
        "attackWithUnresolvedCost": sum(
            1 for v in attack_cards if v["resolvedCost"] is None
        ),
        "attackUsableNow": sum(1 for v in attack_cards if v["usableNow"]),
        "cards": tuple(cards),
    }


def _decision_fields(state: GameState, decision: Any, analysis: Any) -> dict[str, Any]:
    boss = next((value for value in state.opponents if value.is_boss is True), None)
    selected = decision.trace.selected_candidate
    return {
        "cardDiagnostics": _card_diagnostics(state),
        "session": state.battle.session_key,
        "matchId": state.battle.match_id,
        "turn": state.battle.turn_number,
        "srvSeq": state.battle.srv_seq,
        "boardHash": state.battle.board_hash,
        # Preserve the exact screen-oriented 8x8 evidence used by policy. Heap
        # DTOs are managed objects and may be reclaimed before a post-run audit;
        # a hash alone cannot reproduce a disputed collapse/Sword evaluation.
        "boardSnapshot": tuple(
            tuple((cell.gem.value, cell.multiplier) for cell in row)
            for row in state.board.cells
        ),
        "boardSnapshotOrder": "screen_rows_top_to_bottom_columns_left_to_right",
        "allLegalCandidates": _mandatory_candidate_fields(analysis),
        "player": state.player,
        "boss": boss,
        "policyStep": decision.trace.policy_step,
        "selectedAction": decision.action,
        "timerRemaining": state.battle.turn_time_remaining_seconds,
        "legalMoveCount": analysis.legal_match_producing_moves,
        "safeMoveCount": analysis.safe_move_count,
        "bossMana": boss.mana if boss is not None else None,
        "bossRage": boss.power if boss is not None else None,
        "safeResourceCandidates": analysis.policy_observability.get(
            "safeResourcesAvailable", {}
        ),
        "move": decision.move,
        "resources": selected.total_resources if selected is not None else None,
        "swordResult": selected.sword_effective if selected is not None else None,
        "cascade": selected.known_cascades if selected is not None else None,
        "unknownExposure": selected.unknown_cells if selected is not None else None,
        "safe": selected.safe if selected is not None else None,
        "dangerScore": selected.danger_score if selected is not None else None,
        "opponentSwordReplies": (
            selected.opponent_sword_replies if selected is not None else None
        ),
        "opponentSwordReplyEffectiveMax": (
            selected.opponent_sword_reply_effective_max
            if selected is not None
            else None
        ),
        "indirectSwordReplies": (
            selected.indirect_sword_replies if selected is not None else None
        ),
    }


def _mandatory_candidate_fields(analysis: Any) -> tuple[dict[str, Any], ...]:
    """Compact, deterministic evidence for every legal mandatory candidate."""

    candidates: list[dict[str, Any]] = []
    for value in analysis.legal_moves:
        danger = value.get("danger", {})
        exposure = value.get("unknownExposure", {})
        resources = value.get("resources", {}).get("total", {})
        candidates.append(
            {
                "from": value.get("from"),
                "to": value.get("to"),
                "safe": danger.get("safe"),
                "dangerScore": danger.get("dangerScore"),
                "swordPotentialsLeft": danger.get("swordPotentialsLeft"),
                "swordPotentialEffectiveMax": danger.get(
                    "swordPotentialEffectiveMax"
                ),
                "shieldEffective": resources.get("shield", {}).get(
                    "effective"
                ),
                "unknownCells": exposure.get("cells"),
                "totalEffective": sum(
                    int(tally.get("effective", 0))
                    for tally in resources.values()
                    if isinstance(tally, dict)
                ),
                "horizontal": value.get("horizontal"),
                "calculable": value.get("calculable"),
            }
        )
    return tuple(candidates)


def _manual_recovery_step(
    *,
    recovery: RecoveryStateMachine,
    target: Any,
    executor: ForegroundClickExecutor,
    binding: Any,
    log: Any,
) -> bool:
    if recovery.state is RecoveryLifecycleState.RECOVERY_REQUIRED:
        locator = _locate_temporally(target.pid, locate_exit_back)
        if not locator.found:
            capture = capture_client_rgb(target.pid)
            calibrated = _live_exit_calibration(
                pid=target.pid,
                width=capture.width,
                height=capture.height,
            )
            if calibrated is not None:
                locator = calibrated
        if not locator.found or locator.normalized_point is None:
            _write(log, "recovery_blocked", control="EXIT_BACK", locator=locator)
            return False
        if not recovery.request():
            return False
        result = executor.send_normalized_point(binding, locator.normalized_point)
        _write(log, "recovery_ui_step", control="EXIT_BACK", locator=locator, result=result)
        if not result.sent:
            recovery.block(result.status.value)
            return False
        recovery.exit_control_clicked()
        return True
    if recovery.state is RecoveryLifecycleState.CONFIRM_MODAL_VISIBLE:
        capture = capture_client_rgb(target.pid)
        locator = locate_confirm_leave(capture.rgb, capture.width, capture.height)
        if not locator.found or locator.normalized_point is None:
            _write(log, "recovery_blocked", control="CONFIRM_LEAVE", locator=locator)
            return False
        result = executor.send_normalized_point(binding, locator.normalized_point)
        _write(log, "recovery_ui_step", control="CONFIRM_LEAVE", locator=locator, result=result)
        return result.sent
    _write(log, "recovery_hotkey_ignored", state=recovery.state)
    return False


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--watch", action="store_true", required=True)
    parser.add_argument("--play-style", choices=[value.value for value in PlayStyle], default="simple")
    parser.add_argument("--mana-priority", choices=[value.value for value in ManaPriority], default="evolution")
    parser.add_argument("--intelligence", choices=[value.value for value in Intelligence], default="basic")
    parser.add_argument(
        "--board-input-mode",
        choices=[value.value for value in BoardInputMode],
        default=BoardInputMode.TWO_CLICK.value,
        help="normal adjacent-swap gesture; cards and modal controls remain clicks",
    )
    parser.add_argument("--minimum-action-time", type=int, default=1)
    parser.add_argument(
        "--cast-when-boss-hp-below",
        type=int,
        default=30_000,
        help=(
            "Step 3 finisher: with no Sword on the board and boss current HP at or "
            "below this value, CAST as soon as one Attack card is affordable. "
            "0 disables the finisher."
        ),
    )
    parser.add_argument(
        "--cast-mana-stockpile",
        type=int,
        default=480,
        help="Step 5 stockpile: CAST only above this mana (default keeps a 320 reserve).",
    )
    parser.add_argument(
        "--rage-target",
        type=int,
        default=100,
        help="Step 3 Rage floor to reach before switching to Mana.",
    )
    parser.add_argument("--interval", type=float, default=0.10)
    parser.add_argument("--action-timeout", type=float, default=9.0)
    parser.add_argument("--matches", type=int, default=1)
    parser.add_argument(
        "--max-actions",
        type=int,
        default=None,
        help="deprecated bounded-stage cap; must be omitted in Stage B3/B4/B5",
    )
    parser.add_argument(
        "--max-turn-actions",
        type=int,
        default=0,
        help="deprecated bounded-stage consuming-action cap; zero disables it",
    )
    parser.add_argument(
        "--max-total-input-actions",
        type=int,
        default=100,
        help="emergency Stage B3/B4/B5 ceiling on all EVOLVE+SWAP+CAST inputs",
    )
    parser.add_argument(
        "--max-fusion-attempts-per-turn",
        type=int,
        default=2,
        help="conservative EVOLVE retry ceiling for one concrete combat turn",
    )
    parser.add_argument(
        "--v1-root",
        type=Path,
        default=None,
        help=argparse.SUPPRESS,  # legacy CLI compatibility; production no longer reads V1
    )
    parser.add_argument("--timeout", type=float, default=0.0, help="diagnostic/runtime limit; zero is unlimited")
    parser.add_argument(
        "--postmatch-observation-timeout",
        type=float,
        default=20.0,
        help="read-only seconds to observe POSTMATCH -> LOBBY after input is disabled",
    )
    parser.add_argument("--log", type=Path)
    parser.add_argument("--no-beep", action="store_true")
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument(
        "--ack-heap-region-mib",
        type=int,
        default=16,
        help="bounded region-size envelope for exact-ACK WsCombatBatch fallback",
    )
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument(
        "--pass-acceptance-stage",
        choices=("DISABLED", "P1", "P2", "P3", "B3", "B4", "B5"),
        default="DISABLED",
        help=(
            "authoritative PASS mode: P1/P2/P3 are bounded acceptance; "
            "B3 continues one complete production combat; B4 stops after a "
            "strong attack-priority CAST acceptance; B5 runs one full BASIC "
            "combat with production PASS/reset-cycle telemetry; DISABLED blocks PASS"
        ),
    )
    parser.add_argument(
        "--reset-evidence",
        type=Path,
        help="audited P0 reset-capability JSON; required for P1/P2/P3/B3/B4/B5",
    )
    parser.add_argument(
        "--acceptance-force-pass-after-actions",
        type=int,
        default=0,
        help=(
            "acceptance-only P2/P3 trigger; after N server-accepted consuming "
            "actions, force consecutive PASS decisions while authoritative "
            "idle readiness permits them; zero disables"
        ),
    )
    return parser


def _validate_args(args: argparse.Namespace) -> None:
    phase2d4_bounded_handoff = bool(
        getattr(args, "phase2d4_bounded_handoff", False)
    )
    if args.intelligence != Intelligence.BASIC.value:
        raise ValueError("REASONING is disabled; Phase 2C.2B Stage B3/B4/B5 supports BASIC only")
    if not 0.05 <= args.interval <= 1.0:
        raise ValueError("--interval must be between 0.05 and 1.0 seconds")
    if not 1 <= args.minimum_action_time <= 10:
        raise ValueError("--minimum-action-time must be between 1 and 10 seconds")
    if not 3.0 <= args.action_timeout <= 20.0:
        raise ValueError("--action-timeout must be between 3 and 20 seconds")
    if args.matches != 1:
        raise ValueError("Stage B3/B4/B5 is exactly one combat; --matches must be 1")
    if args.max_actions is not None:
        raise ValueError("Stage B3/B4/B5 requires --max-actions to be omitted")
    if phase2d4_bounded_handoff and args.max_turn_actions != 1:
        raise ValueError(
            "Phase 2D.4 B1 bounded handoff requires --max-turn-actions 1"
        )
    if not phase2d4_bounded_handoff and args.max_turn_actions != 0:
        raise ValueError("Stage B3/B4/B5 requires --max-turn-actions 0 (disabled)")
    if not 50 <= args.max_total_input_actions <= 1000:
        raise ValueError(
            "Stage B3/B4/B5 --max-total-input-actions safety ceiling must be between 50 and 1000"
        )
    if not 1 <= args.max_fusion_attempts_per_turn <= 3:
        raise ValueError("--max-fusion-attempts-per-turn must be between 1 and 3")
    if args.timeout < 0:
        raise ValueError("--timeout cannot be negative")
    if not args.max_region_mib <= args.ack_heap_region_mib <= 32:
        raise ValueError(
            "--ack-heap-region-mib must cover --max-region-mib and be <= 32"
        )
    if not 1.0 <= args.postmatch_observation_timeout <= 60.0:
        raise ValueError(
            "--postmatch-observation-timeout must be between 1 and 60 seconds"
        )
    if args.pass_acceptance_stage == "DISABLED":
        if args.reset_evidence is not None:
            raise ValueError("--reset-evidence requires P1/P2/P3/B3/B4/B5 authoritative PASS")
    elif args.reset_evidence is None:
        raise ValueError("P1/P2/P3/B3/B4/B5 requires --reset-evidence from a clean P0 PASS")
    if args.pass_acceptance_stage == "B4" and args.mana_priority != ManaPriority.ATTACK.value:
        raise ValueError("Stage B4 requires --mana-priority attack")
    if args.pass_acceptance_stage == "B5":
        if args.play_style != PlayStyle.SIMPLE.value:
            raise ValueError("Stage B5 requires --play-style simple")
        if args.mana_priority != ManaPriority.EVOLUTION.value:
            raise ValueError("Stage B5 requires --mana-priority evolution")
    if args.acceptance_force_pass_after_actions < 0:
        raise ValueError("--acceptance-force-pass-after-actions cannot be negative")
    if args.acceptance_force_pass_after_actions > 0:
        if args.pass_acceptance_stage not in {"P2", "P3"}:
            raise ValueError(
                "--acceptance-force-pass-after-actions requires P2 or P3"
            )
        if args.acceptance_force_pass_after_actions > 50:
            raise ValueError(
                "--acceptance-force-pass-after-actions must be <= 50"
            )


def _create_shared_combat_runtime(
    target: Any,
    args: argparse.Namespace,
    v1_config: dict[str, Any],
) -> SharedCombatRuntime:
    """Create the legacy CLI-owned runtime once, from a clean lobby."""

    backend = NativeWin32Backend()
    binding = find_window_for_pid(target.pid, backend)
    executor = ForegroundClickExecutor(
        backend,
        click_delay_seconds=float(v1_config.get("click_delay_seconds", 0.35)),
        cursor_settle_seconds=float(
            v1_config.get("cursor_settle_seconds", 0.06)
        ),
        input_mode=BoardInputMode(args.board_input_mode),
    )
    provider = MemoryBoardStateProvider(
        target,
        MemoryProviderConfig(
            max_region_mib=args.max_region_mib,
            chunk_mib=args.chunk_mib,
            required_confirmations=2,
            require_lobby_start=True,
            allow_ack_heap_scan=True,
            ack_heap_region_mib=args.ack_heap_region_mib,
            extended_fusion_ui_region_mib=max(args.max_region_mib, 16),
            extended_card_ui_region_mib=max(args.max_region_mib, 16),
        ),
    )
    monitor = RuntimeSequenceMonitor(
        target,
        max_region_mib=max(args.max_region_mib, 16),
        chunk_mib=args.chunk_mib,
        full_rescan_interval=8,
    )
    return SharedCombatRuntime(target, provider, monitor, binding, executor, backend)


def run(args: argparse.Namespace, *, shared_runtime: SharedCombatRuntime | None = None) -> int:
    _validate_args(args)

    if (
        bool(getattr(args, "phase2d4_bounded_handoff", False))
        and shared_runtime is None
    ):
        raise ValueError("Phase 2D.4 B1 bounded handoff requires shared runtime")

    configured_mana_priority = ManaPriority(args.mana_priority)
    policy = BasicPolicyEngine(
        PolicyConfig(
            play_style=PlayStyle(args.play_style),
            mana_priority=configured_mana_priority,
            intelligence=Intelligence.BASIC,
            minimum_turn_time_seconds=args.minimum_action_time,
            # Step 1 is the operator-owned rule: after the opening action, an
            # affordable selected evolution is tried before board policy.
            # Retain only the inclusive hard action floor. Authoritative
            # idle-2 still defers non-consuming EVOLVE to mandatory SWAP/CAST.
            minimum_evolve_time_seconds=args.minimum_action_time,
            cast_when_boss_hp_below=getattr(args, "cast_when_boss_hp_below", 30_000),
            cast_mana_stockpile_threshold=getattr(args, "cast_mana_stockpile", 480),
            rage_target=getattr(args, "rage_target", 100),
        )
    )
    # Production V2 uses only these accepted normal-input calibration values;
    # it no longer depends on a separate PokiguardAuto checkout at runtime.
    v1_config = production_input_calibration()
    pass_stage = args.pass_acceptance_stage
    stage_name = (
        "b5"
        if pass_stage == "B5"
        else (
            "b4"
            if pass_stage == "B4"
            else ("b3" if pass_stage == "B3" else "b1")
        )
    )
    log_path = (
        args.log
        or current_app_paths().logs_root
        / f"phase2c2b_stage_{stage_name}_{datetime.now():%Y%m%d_%H%M%S}.jsonl"
    ).resolve()
    log_path.parent.mkdir(parents=True, exist_ok=True)
    hotkeys = AutoHotkeyEdges()
    guard = AutonomousGuard()
    recovery = RecoveryStateMachine()
    counters = Counters()
    reset_capabilities = (
        load_reset_capabilities(args.reset_evidence.resolve())
        if args.reset_evidence is not None
        else ()
    )
    idle_cache = GameOwnedIdleCache(seeded_capabilities=reset_capabilities)
    pass_coordinator = (
        AuthoritativePassCoordinator(
            max_auto_passes=1 if pass_stage == "P1" else 2
        )
        if pass_stage != "DISABLED"
        else None
    )

    runtime_owner = attach_target() if shared_runtime is None else nullcontext(shared_runtime.target)
    with runtime_owner as target, log_path.open("a", encoding="utf-8", buffering=1) as log:
        runtime = shared_runtime or _create_shared_combat_runtime(target, args, v1_config)
        binding = runtime.binding
        executor = runtime.executor
        provider = runtime.provider
        monitor = runtime.monitor
        backend = runtime.backend
        opening_message_max_region_mib = max(args.max_region_mib, 16)
        try:
            transport_region_prime = _prime_transport_for_runtime(
                runtime,
                farm_owned=shared_runtime is not None,
            )
            _write(
                log,
                (
                    "farm_handoff_transport_regions_reused"
                    if shared_runtime is not None
                    else "transport_region_prime"
                ),
                result=transport_region_prime,
            )
        except (OSError, RuntimeError, ValueError) as exc:
            # Fail closed naturally until a later bounded full scan learns a
            # live region.  Controller startup remains useful for diagnostics.
            transport_region_prime = {"error": str(exc)}
            _write(log, "transport_region_prime_failed", error=str(exc))
        opening_classes = None
        opening_offered_message = None
        preopening_match_id: str | None = None
        preopening_session: tuple[str, str] | None = None
        preloaded_opening = None
        preloaded_opening_message: int | None = None
        try:
            _service, lobby_runtime = read_match_runtime(target)
            lobby_runtime_match_id = lobby_runtime.match_id
        except (OSError, RuntimeError, ValueError):
            lobby_runtime_match_id = None
        calibration = BoardCalibration(
            float(v1_config.get("board_first_center_x", 0.3620)),
            float(v1_config.get("board_first_center_y", 0.1625)),
            float(v1_config.get("board_step_x", 0.0393)),
            float(v1_config.get("board_step_y", 0.0787)),
        )
        calibration.validate()
        _write(
            log,
            "auto_controller_started",
            mode=(
                "STAGE_B5_FULL_BASIC_COMBAT_AUTHORITATIVE_PASS_CYCLE"
                if pass_stage == "B5"
                else (
                    "STAGE_B4_ATTACK_PRIORITY_CAST_ACCEPTANCE"
                    if pass_stage == "B4"
                    else (
                        "STAGE_B3_ONE_COMPLETE_COMBAT_AUTHORITATIVE_PASS"
                        if pass_stage == "B3"
                        else (
                            "STAGE_B3_ONE_COMPLETE_COMBAT_PASS_DISABLED"
                            if pass_stage == "DISABLED"
                            else f"PHASE_2C2C_{pass_stage}_BOUNDED_PASS"
                        )
                    )
                )
            ),
            pid=target.pid,
            gameAssemblyBase=hex_pointer(target.game_assembly.base),
            config=vars(args),
            allowedActions=(
                ["SWAP", "CAST", "PASS"]
                if pass_stage == "B4"
                else (
                    ["EVOLVE", "SWAP", "CAST", "PASS"]
                    if pass_stage != "DISABLED"
                    else ["EVOLVE", "SWAP", "CAST"]
                )
            ),
            disabledActions=(
                ["EVOLVE", "AUTOMATIC_EXIT", "AUTOMATIC_REENTRY"]
                if pass_stage == "B4"
                else (
                    ["PASS", "AUTOMATIC_EXIT", "AUTOMATIC_REENTRY"]
                    if pass_stage == "DISABLED"
                    else ["AUTOMATIC_EXIT", "AUTOMATIC_REENTRY"]
                )
            ),
            passAcceptanceStage=pass_stage,
            b4Acceptance=(
                {
                    "manaPriority": configured_mana_priority,
                    "castThreshold": "playerMana > 480",
                    "dynamicAttackCard": True,
                    "stopAfterStrongCastAcceptance": True,
                    "evolveInputHardLimit": 0,
                    "maximumManualSessions": 3,
                }
                if pass_stage == "B4"
                else None
            ),
            b5Acceptance=(
                {
                    "playStyle": args.play_style,
                    "manaPriority": configured_mana_priority,
                    "intelligence": args.intelligence,
                    "completeCombat": True,
                    "stopAfterCast": False,
                    "authoritativePassOnly": True,
                    "maximumAutomaticPassesPerResetCycle": 2,
                    "mandatoryConsumingActionAfterIdle2": True,
                }
                if pass_stage == "B5"
                else None
            ),
            resetCapabilities=reset_capabilities,
            hotkeys={"pauseResume": "F7", "stop": "F9", "recoveryStep": "F10"},
            processAccess=["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"],
            openingMessageMaxRegionMiB=opening_message_max_region_mib,
            transportRegionPrime=transport_region_prime,
            provider=provider.scan_diagnostics,
            swapInputPacing=executor.swap_pacer.decision(),
        )
        if provider.scan_diagnostics["lobbyBaselineReady"]:
            print(f"Phase 2C.2B Stage {stage_name.upper()} ready in lobby; log: {log_path}", flush=True)
        else:
            print(f"Phase 2C.2B Stage {stage_name.upper()} waiting for lobby baseline; log: {log_path}", flush=True)
        print("F7 pause/resume, F9 emergency stop, F10 manual recovery only.", flush=True)
        if pass_stage != "DISABLED":
            print(
                (
                    "Stage B3/B4/B5: production PASS = zero input and server-confirmed."
                    if pass_stage in {"B3", "B4", "B5"}
                    else f"Phase 2C.2C {pass_stage}: PASS = zero input, bounded and server-confirmed."
                ),
                flush=True,
            )

        active_session = runtime.expected_session
        handoff_session_pending = runtime.expected_session is not None
        opening_fast_action_pending = runtime.expected_session is not None
        started = time.monotonic()
        last_state: GameState | None = None
        source_decisions: dict[tuple[Any, ...], tuple[PolicyAction, tuple[Any, ...]]] = {}
        pass_preflight_wait_sources: set[tuple[Any, ...]] = set()
        evolve_attempts = 0
        fusion_attempts_by_turn: dict[tuple[Any, int], int] = {}
        consuming_turns = ConsumingTurnRegistry()
        turn_transitions = TurnTransitionTracker()
        opening_ready_logged: set[Any] = set()
        opening_board_only_logged: set[Any] = set()
        transport_offered_messages: set[int] = set()
        runtime_offered_batches: set[tuple[int, int]] = set()
        fast_transition_deadline: float | None = None
        stop_reason = "PROCESS_OR_CONTROLLER_STOPPED"
        session_seen = False
        action_baseline_ready = False
        last_gate = None
        last_provider_status = None
        last_lifecycle_key: tuple[Any, Any] | None = None
        observed_turns: set[tuple[Any, int, str]] = set()
        observed_policy_sources: set[tuple[Any, ...]] = set()
        consuming_action_turns: set[tuple[Any, int]] = set()
        lifecycle_timeline: list[dict[str, Any]] = []
        full_combat_result = "NOT_COMPLETED"
        terminal_combat_snapshot: TerminalCombatSnapshot | None = None
        session_cleared = False
        combat_ended = False
        postmatch_observation_deadline: float | None = None
        pass_full_scan_attempt_identity: tuple[Any, ...] | None = None
        p3_mandatory_reset_pending = False
        mandatory_cached_board_fastpath_polls = 0
        p3_reset_validation_pending = False
        p3_reset_validation_activity = None
        last_idle_observability: tuple[Any, ...] | None = None
        direct_pass_result_turn: int | None = None
        b4_cast_acceptance_complete = False
        b4_cast_acceptance_records: list[B4CastAcceptanceEvidence] = []
        b4_cast_evidence_observed: set[tuple[Any, ...]] = set()
        accepted_cast_turns: set[tuple[Any, int]] = set()
        attack_priority_skip_logged: set[Any] = set()
        mandatory_action_records: list[dict[str, Any]] = []
        mandatory_telemetry_logged: set[tuple[Any, ...]] = set()
        correlated_cast_resets: set[tuple[Any, ...]] = set()
        post_evolve_input_settle: tuple[
            Any, int, float, ActionResultKind
        ] | None = None
        post_evolve_settle_logged = False
        terminal_evolve_activity_turns: set[tuple[Any, int]] = set()
        unconfirmed_action_turns: set[tuple[Any, int]] = set()
        evolve_only_turn_wait: EvolveOnlyTurnWait | None = None
        optional_card_suppressions: dict[
            tuple[Any, int], set[PolicyAction]
        ] = {}
        active_progress_watchdog = ActiveCombatProgressWatchdog()

        def observe_b5_server_reset(observed_idle: Any) -> None:
            """Consume only exact server idle evidence after a reset action."""

            nonlocal p3_mandatory_reset_pending
            activity = getattr(observed_idle, "reset_activity", None)
            confidence = getattr(
                observed_idle,
                "reset_confidence",
                ResetConfidence.RESET_UNKNOWN,
            )
            if activity is not None and activity.kind is AcceptedActivityKind.CAST:
                proof_key = (
                    observed_idle.session_id,
                    activity.source_turn,
                    observed_idle.source_turn,
                    observed_idle.source_srv_seq,
                    observed_idle.idle_count,
                    confidence,
                )
                if proof_key not in correlated_cast_resets:
                    correlated_cast_resets.add(proof_key)
                    counters.cast_reset_correlations += 1
                    _write(
                        log,
                        "cast_reset_correlated",
                        acceptedActivity=activity,
                        authoritativeIdle=observed_idle,
                        confidence=confidence,
                        explicitZero=(observed_idle.idle_count == 0),
                        localIdleMutation=False,
                    )
            if (
                pass_stage == "B5"
                and pass_coordinator is not None
                and pass_coordinator.confirmed_passes > 0
                and confidence is not ResetConfidence.RESET_UNKNOWN
                and activity is not None
                and (
                    not p3_reset_validation_pending
                    or activity == p3_reset_validation_activity
                )
            ):
                # An accepted consuming action had no production-ready
                # baseline at acceptance time. The exact later server payload
                # now proves a new cycle without synthesizing idleCount=0.
                reset_accepted = pass_coordinator.begin_new_reset_cycle(
                    observed_idle.session_id,
                    reset_source_turn=activity.source_turn,
                )
                if reset_accepted:
                    counters.reset_baselines_confirmed += 1
                    p3_mandatory_reset_pending = False
                    _write(
                        log,
                        "b5_pass_cycle_reset_from_server_idle",
                        acceptedActivity=activity,
                        authoritativeIdle=observed_idle,
                        confidence=confidence,
                        mandatoryCycleTarget=p3_reset_validation_pending,
                        currentConfirmedPasses=pass_coordinator.confirmed_passes,
                        nextTarget="natural BASIC PASS -> authoritative 1/3",
                    )
                else:
                    _write(
                        log,
                        "b5_stale_reset_evidence_ignored",
                        acceptedActivity=activity,
                        authoritativeIdle=observed_idle,
                        confidence=confidence,
                        lastConfirmedPassSourceTurn=(
                            pass_coordinator.last_confirmed_pass_source_turn
                        ),
                        reason="reset activity did not occur after confirmed PASS",
                    )

        def complete_p3_mandatory_reset(
            activity: Any,
            *,
            mandatory_after_idle_2: bool = False,
        ) -> bool:
            nonlocal p3_mandatory_reset_pending
            nonlocal p3_reset_validation_pending
            nonlocal p3_reset_validation_activity
            nonlocal stop_reason
            baseline = idle_cache.reset_baseline
            prior_confirmed_passes = (
                pass_coordinator.confirmed_passes
                if pass_coordinator is not None
                else None
            )
            if _reset_pass_cycle_after_consuming_action(
                pass_coordinator, baseline
            ):
                counters.reset_baselines_confirmed += 1
                _write(
                    log,
                    "pass_cycle_reset_by_consuming_action",
                    activity=activity,
                    resetBaseline=baseline,
                    priorConfirmedPasses=prior_confirmed_passes,
                    currentConfirmedPasses=pass_coordinator.confirmed_passes,
                )
            mandatory = bool(
                mandatory_after_idle_2 or p3_mandatory_reset_pending
            )
            if (
                pass_stage == "B5"
                and p3_reset_validation_pending
                and not mandatory
            ):
                _write(
                    log,
                    "b5_mandatory_reset_cycle_intervening_action",
                    targetActivity=p3_reset_validation_activity,
                    interveningActivity=activity,
                    cycleTargetInvalidated=True,
                )
                p3_reset_validation_pending = False
                p3_reset_validation_activity = None
            if pass_stage not in {"P3", "B3", "B4", "B5"} or not mandatory:
                return True
            counters.mandatory_reset_actions += 1
            if baseline is None:
                if pass_stage == "B5":
                    # The accepted action consumed the mandatory turn, but it
                    # does not license a future PASS. Keep the coordinator's
                    # exhausted two-PASS budget until a later exact server
                    # payload proves a reset; ordinary safe actions may still
                    # continue in the meantime.
                    p3_mandatory_reset_pending = False
                    p3_reset_validation_pending = True
                    p3_reset_validation_activity = activity
                    counters.mandatory_reset_unknown += 1
                    _write(
                        log,
                        "mandatory_reset_unconfirmed",
                        activity=activity,
                        idleState=idle_cache.state,
                        resetBaseline=None,
                        continueSafeNonPassPolicy=True,
                        passRemainsFailClosed=True,
                    )
                    return False
                guard.pause(automatic=True)
                stop_reason = (
                    "P3_MANDATORY_ACTION_RESET_UNKNOWN"
                    if pass_stage == "P3"
                    else "PASS_STATE_UNKNOWN"
                )
                _write(
                    log,
                    "p3_mandatory_reset_unconfirmed",
                    activity=activity,
                    idleState=idle_cache.state,
                    resetBaseline=None,
                    failClosed=True,
                )
                if pass_stage != "B4":
                    _beep("pause", not args.no_beep)
                return False
            p3_mandatory_reset_pending = False
            if pass_coordinator is None:
                raise AssertionError("mandatory reset requires a PASS coordinator")
            if pass_stage in {"P3", "B5"}:
                p3_reset_validation_pending = True
                p3_reset_validation_activity = activity
                _write(
                    log,
                    (
                        "b5_mandatory_reset_baseline_confirmed"
                        if pass_stage == "B5"
                        else "p3_mandatory_reset_baseline_confirmed"
                    ),
                    activity=activity,
                    resetBaseline=baseline,
                    nextTarget="policy-selected PASS -> authoritative 1/N",
                )
            else:
                _write(
                    log,
                    "mandatory_reset_baseline_confirmed",
                    activity=activity,
                    resetBaseline=baseline,
                    continueCombat=True,
                )
            return True

        def try_complete_b4_cast(
            pending: PendingAutonomousAction,
            runtime: Any,
        ) -> bool:
            """Complete a strong B4/B5 CAST after exact state proof."""

            nonlocal b4_cast_acceptance_complete
            nonlocal stop_reason
            if (
                pass_stage not in {"B4", "B5"}
                or pending.identity.action is not PolicyAction.CAST
            ):
                return False
            try:
                participants, cards = provider.read_current_combat_evidence()
            except (OSError, RuntimeError, ValueError):
                participants, cards = (), ()
            player_after = next(
                (participant for participant in participants if participant.is_local is True),
                None,
            )
            card_after = next(
                (
                    card
                    for card in cards
                    if card.object_address == pending.card_object_address
                ),
                None,
            )
            proof = _b4_cast_acceptance_evidence(
                pending,
                mana_after=(player_after.mana if player_after is not None else None),
                card_after=card_after,
                observed_turn=getattr(runtime, "turn", None),
                observed_current_player=getattr(runtime, "current_player", None),
            )
            proof_key = (
                proof.reason,
                proof.mana_after,
                proof.has_used_this_turn_after,
                proof.last_turn_used_after,
                proof.response_accepted,
            )
            if proof_key not in b4_cast_evidence_observed:
                b4_cast_evidence_observed.add(proof_key)
                _write(
                    log,
                    "b4_cast_acceptance_evaluated",
                    evidence=proof,
                    response=pending.response_evidence,
                    idleBefore=pending.idle_state_before,
                    resetBaselineBefore=pending.reset_baseline_before,
                    failClosed=not proof.accepted,
                )
            if not proof.accepted:
                return False

            accepted = guard.complete_pending()
            counters.cast_accepted += 1
            accepted_cast_turns.add(
                (accepted.identity.source.session, accepted.identity.source.turn)
            )
            idle_activity = _observe_cast_idle_reset(
                idle_cache,
                accepted,
                allow_direct_state=(pass_stage == "B5"),
            )
            reset_ok = bool(
                idle_activity is not None
                and complete_p3_mandatory_reset(
                    idle_activity,
                    mandatory_after_idle_2=accepted.mandatory_after_idle_2,
                )
            )
            if accepted.mandatory_after_idle_2:
                counters.mandatory_cast_accepted += 1
                mandatory_action_records.append(
                    {
                        "action": "CAST",
                        "result": "CAST_ACCEPTED",
                        "identity": accepted.identity,
                        "resetEvidence": idle_cache.reset_baseline,
                        "resetStatus": (
                            "RESET_BASELINE_CONFIRMED"
                            if reset_ok
                            else "RESET_UNKNOWN"
                        ),
                    }
                )
            b4_cast_acceptance_records.append(proof)
            _write(
                log,
                "action_result",
                result=ActionResultKind.CAST_ACCEPTED,
                action=accepted,
                evidence=(
                    f"{pass_stage}_EXACT_COST_MANA_CARD_OR_RESPONSE_AND_BOSS_TURN"
                ),
                castAcceptance=proof,
                response=pending.response_evidence,
                runtime=runtime,
                idleResetActivity=idle_activity,
                idleStateAfter=idle_cache.state,
                resetBaselineAfter=idle_cache.reset_baseline,
                castResetCapability=idle_cache.reset_capability(
                    AcceptedActivityKind.CAST
                ),
                sameTurnSwapBlocked=True,
            )
            if pass_stage == "B4":
                b4_cast_acceptance_complete = True
                stop_reason = (
                    "B4_CAST_ACCEPTED"
                    if reset_ok
                    else "B4_CAST_ACCEPTED_RESET_UNKNOWN"
                )
                guard.stop()
                _write(
                    log,
                    "b4_acceptance_complete",
                    stopReason=stop_reason,
                    castAcceptance=proof,
                    sameTurnSwapAfterCast=counters.same_turn_swap_after_cast,
                    evolveInputs=counters.evolve_sent,
                    automaticInputDisabled=True,
                )
                _beep("success", not args.no_beep)
            else:
                _write(
                    log,
                    "b5_strong_cast_accepted_continue",
                    castAcceptance=proof,
                    mandatoryAfterIdle2=accepted.mandatory_after_idle_2,
                    resetStatus=(
                        "RESET_BASELINE_CONFIRMED"
                        if reset_ok
                        else "RESET_UNKNOWN"
                    ),
                    sameTurnSwapBlocked=True,
                    continueCombat=True,
                )
            return True

        def complete_direct_runtime_consuming_action(runtime: Any) -> bool:
            """Complete an exact SWAP/CAST opponent-turn transition."""

            pending = guard.pending
            if pending is None or active_session is None:
                return False
            common = {
                "session": active_session,
                "turn": runtime.turn,
                "current_player": runtime.current_player,
                "local_username": runtime.local_username,
                "local_move_sequence": runtime.local_move_sequence,
                "last_move_sequence": runtime.last_move_sequence,
            }
            swap_accepted = direct_runtime_proves_swap_accepted(
                pending,
                **common,
                last_move_from_col=runtime.last_move_from_col,
                last_move_from_row=runtime.last_move_from_row,
                last_move_to_col=runtime.last_move_to_col,
                last_move_to_row=runtime.last_move_to_row,
            )
            cast_accepted = direct_runtime_proves_cast_accepted(
                pending,
                **common,
            )
            if not swap_accepted and not cast_accepted:
                return False

            if cast_accepted and pass_stage in {"B4", "B5"}:
                pending.consuming_transition_seen = True
                pending.consuming_transition_evidence = runtime
                return try_complete_b4_cast(pending, runtime)

            accepted = guard.complete_pending()
            if swap_accepted:
                executor.note_swap_acknowledged(
                    max(0.0, time.monotonic() - accepted.sent_at)
                )
                counters.swap_acknowledged += 1
                if accepted.mandatory_after_idle_2:
                    counters.mandatory_swap_acknowledged += 1
                result = ActionResultKind.SWAP_ACKNOWLEDGED
                kind = AcceptedActivityKind.SWAP
                evidence = (
                    "EXACT_MATCHSERVICE_LOCAL_SEQUENCE_LAST_MOVE_AND_OPPONENT_TURN"
                )
                source_message_type = "MATCH_MOVE_RES"
            else:
                counters.cast_accepted += 1
                result = ActionResultKind.CAST_ACCEPTED
                kind = AcceptedActivityKind.CAST
                evidence = (
                    "EXACT_MATCHSERVICE_UNCHANGED_MOVE_SEQUENCE_AND_OPPONENT_TURN"
                )
                source_message_type = "DIRECT_CAST_STATE_TRANSITION"
            _write(
                log,
                "action_result",
                result=result,
                action=accepted,
                evidence=evidence,
                runtime=runtime,
                sameTurnSwapBlocked=cast_accepted,
            )
            idle_activity = (
                _observe_cast_idle_reset(
                    idle_cache,
                    accepted,
                    allow_direct_state=True,
                )
                if kind is AcceptedActivityKind.CAST
                else _observe_consuming_idle_acceptance(
                    idle_cache,
                    accepted,
                    kind=kind,
                    source_srv_seq=runtime.highest_acked_sequence,
                    source_timestamp=None,
                    source_message_type=source_message_type,
                )
            )
            _write(
                log,
                "idle_reset_activity_accepted",
                activity=idle_activity,
                resetBaseline=idle_cache.reset_baseline,
            )
            if idle_activity is not None:
                reset_ok = complete_p3_mandatory_reset(
                    idle_activity,
                    mandatory_after_idle_2=accepted.mandatory_after_idle_2,
                )
                if accepted.mandatory_after_idle_2:
                    mandatory_action_records.append(
                        {
                            "action": kind.value.upper(),
                            "result": result.value,
                            "identity": accepted.identity,
                            "resetEvidence": idle_cache.reset_baseline,
                            "resetStatus": (
                                "RESET_BASELINE_CONFIRMED"
                                if reset_ok
                                else "RESET_UNKNOWN"
                            ),
                        }
                    )
            return True

        while target.is_running():
            fast_bounded_handoff_iteration = bool(
                handoff_session_pending and active_session is not None
            )
            if b4_cast_acceptance_complete:
                break
            if args.timeout and time.monotonic() - started >= args.timeout:
                stop_reason = "CONTROLLER_TIMEOUT"
                _write(log, "controller_timeout", seconds=args.timeout)
                break
            pause_toggle, recovery_hotkey, stop = hotkeys.poll()
            # Keep the farm's F6 latch alive.  Latch only: combat never reads
            # the result and never exits early on it.
            if (
                shared_runtime is not None
                and shared_runtime.farm_control_hotkeys is not None
            ):
                _graceful, farm_emergency = (
                    shared_runtime.farm_control_hotkeys.poll()
                )
                stop = stop or farm_emergency
            if stop:
                if pass_coordinator is not None and pass_coordinator.gameplay_locked:
                    pass_terminal = pass_coordinator.abort_state_changed(
                        timestamp=utc_timestamp(),
                        gameplay_inputs_total=counters.input_actions_total,
                        detail="F9 emergency stop during PASS_WAIT",
                    )
                    if pass_terminal is not None:
                        counters.pass_aborted += 1
                        _write(
                            log,
                            "pass_result",
                            result=pass_terminal.result,
                            passAttempt=pass_terminal.attempt,
                            detail=pass_terminal.detail,
                        )
                aborted = guard.stop()
                stop_reason = "EMERGENCY_STOP"
                _write(log, "emergency_stop", key="F9", pending=aborted)
                if aborted is not None:
                    _write(
                        log,
                        "action_result",
                        result=ActionResultKind.ACTION_ABORTED_STATE_CHANGED,
                        action=aborted,
                        reason="EMERGENCY_STOP",
                    )
                break
            if pause_toggle:
                if pass_coordinator is not None and pass_coordinator.gameplay_locked:
                    pass_terminal = pass_coordinator.abort_state_changed(
                        timestamp=utc_timestamp(),
                        gameplay_inputs_total=counters.input_actions_total,
                        detail="F7 user pause during PASS_WAIT",
                    )
                    if pass_terminal is not None:
                        counters.pass_aborted += 1
                        _write(
                            log,
                            "pass_result",
                            result=pass_terminal.result,
                            passAttempt=pass_terminal.attempt,
                            detail=pass_terminal.detail,
                        )
                if guard.status in {AutonomousStatus.PAUSED_BY_USER, AutonomousStatus.AUTO_PAUSED}:
                    resumed = guard.resume()
                    _write(log, "user_resume", key="F7", resumed=resumed)
                    _beep("resume", not args.no_beep)
                elif guard.status in {AutonomousStatus.RUNNING, AutonomousStatus.INPUT_LOCKED}:
                    pending = guard.pending
                    if pending is not None:
                        # A sent action still needs its terminal response; F7
                        # prevents every later input while the pending lock is
                        # retained. A reserved but unsent proposal is released
                        # by the pre-input pause path below.
                        guard.pause(automatic=False)
                    else:
                        guard.pause(automatic=False)
                    _write(log, "user_pause", key="F7", pending=pending, staleProposalRetained=False)
                    _beep("pause", not args.no_beep)

            if (
                guard.status is AutonomousStatus.RECOVERY_REQUIRED
                and runtime.technical_recovery_dispatcher is not None
                and runtime.technical_recovery_dispatcher.recovery_pending
            ):
                guard.stop()
                _write(
                    log,
                    "technical_recovery_handoff",
                    reason=stop_reason,
                    gameplayInputDisabled=True,
                    pending=None,
                    automaticUiOwnedByOuterCoordinator=True,
                )
                break

            if _farm_owned_guard_requires_stop(
                farm_owned=runtime.gameplay_capability is not None,
                status=guard.status,
            ):
                paused_status = guard.status
                guard.stop()
                if stop_reason == "PROCESS_OR_CONTROLLER_STOPPED":
                    stop_reason = "FARM_GAMEPLAY_AUTO_PAUSED"
                _write(
                    log,
                    "farm_safe_stop_immediate",
                    reason=stop_reason,
                    pausedStatus=paused_status,
                    automaticInputDisabled=True,
                    userCanTakeOver=True,
                )
                break

            # MATCH_START may be shorter-lived than Board/Active lifecycle
            # construction. Capture and fully decode it as soon as the direct
            # MatchService CurrentMatchId changes away from the lobby value;
            # bind it to the provider only after the real Board session exists.
            if active_session is None and preloaded_opening is None:
                try:
                    _service, early_runtime = read_match_runtime(target)
                    early_match_id = early_runtime.match_id
                    if (
                        early_match_id
                        and early_match_id != lobby_runtime_match_id
                    ):
                        if early_match_id != preopening_match_id:
                            if preopening_session is not None:
                                monitor.end_session(preopening_session)
                            preopening_match_id = early_match_id
                            preopening_session = (
                                "opening-preload",
                                early_match_id,
                            )
                            monitor.begin_session(
                                preopening_session,
                                early_match_id,
                                clean=True,
                            )
                            _write(
                                log,
                                "opening_preload_started",
                                matchId=early_match_id,
                                runtime=early_runtime,
                            )
                        early_observation = monitor.poll(
                            session_key=preopening_session,
                            match_id=early_match_id,
                            turn=early_runtime.turn,
                            srv_seq=None,
                            timestamp=utc_timestamp(),
                        )
                        early_start = early_observation.current_match_start
                        if (
                            early_start is not None
                            and early_start.payload_address is not None
                            and early_start.address != preloaded_opening_message
                        ):
                            if opening_classes is None:
                                resolved = tuple(
                                    target.resolver.resolve_type_info_class(rva)
                                    for rva in (
                                        JARRAY_TYPE_INFO_RVA,
                                        JOBJECT_TYPE_INFO_RVA,
                                        JPROPERTY_TYPE_INFO_RVA,
                                        JVALUE_TYPE_INFO_RVA,
                                    )
                                )
                                if all(value is not None for value in resolved):
                                    opening_classes = NewtonsoftClasses(
                                        *(int(value) for value in resolved)
                                    )
                            if opening_classes is not None:
                                preloaded_opening = (
                                    read_match_start_opening_snapshot(
                                        target.memory,
                                        match_id=early_match_id,
                                        message_address=early_start.address,
                                        payload_address=early_start.payload_address,
                                        classes=opening_classes,
                                    )
                                )
                                preloaded_opening_message = early_start.address
                                _write(
                                    log,
                                    "opening_snapshot_preloaded",
                                    matchId=early_match_id,
                                    messageAddress=hex_pointer(
                                        early_start.address
                                    ),
                                    srvSeq=preloaded_opening.sequence,
                                    completeCells=len(preloaded_opening.cells),
                                )
                except (OSError, RuntimeError, ValueError) as exc:
                    _write(
                        log,
                        "opening_preload_read_error",
                        detail=str(exc),
                    )

            # Full Board publication is deliberately strict and can lag a
            # short boss turn while the next DTO is found and stabilized.
            # Retain direct current-owner batches before slower heap/message
            # work can outlive their PendingCombat/queue references. They are
            # not publishable until the provider later observes the same srvSeq
            # in MatchService._ackedSeqs.
            if (
                active_session is not None
                and not (
                    pass_coordinator is not None
                    and pass_coordinator.gameplay_locked
                )
            ):
                captured_batches = provider.capture_transient_batches()
                if captured_batches:
                    _write(
                        log,
                        "transient_batches_captured",
                        session=active_session,
                        batches=[
                            {
                                "address": identity[0],
                                "srvSeq": identity[1],
                                "boardHash": identity[2],
                            }
                            for identity in captured_batches
                        ],
                    )

            # MATCH_MOVE_RES carries the same server board that becomes a
            # WsCombatBatch, but the managed batch may be reclaimed before a
            # full heap scan finishes.  Sample current-match transport DTOs
            # before any potentially slow provider scan.  The provider still
            # requires the exact srvSeq in MatchService._ackedSeqs before this
            # witness can ever become publishable.
            early_messages: tuple[ServerMessage, ...] = ()
            early_observation = None
            if active_session is not None:
                try:
                    if not p3_mandatory_reset_pending:
                        mandatory_cached_board_fastpath_polls = 0
                    absorbed_transport_regions = monitor.absorb_region_hints(
                        provider.transport_region_hints
                    )
                    if absorbed_transport_regions:
                        _write(
                            log,
                            "transport_regions_absorbed_from_provider_warmup",
                            addedRegions=absorbed_transport_regions,
                            source="boss_turn_combined_card_chat_class_scan",
                        )
                    pass_scan_identity = None
                    if (
                        pass_coordinator is not None
                        and pass_coordinator.gameplay_locked
                        and pass_coordinator.attempt is not None
                    ):
                        pass_scan_identity = (
                            pass_coordinator.attempt.session_id,
                            pass_coordinator.attempt.source_turn,
                            pass_coordinator.attempt.source_srv_seq,
                        )
                    force_full_pass_scan = _force_full_pass_scan_once(
                        pass_scan_identity,
                        pass_full_scan_attempt_identity,
                    )
                    # Capture short-lived MATCH_MOVE_RES objects as soon as an
                    # ACK advances, including while the opponent still owns the
                    # turn. Waiting for the opponent -> local boundary lost the
                    # board-bearing boss response in E2.3 B6 attempt 4. The
                    # monitor reserves one bounded/full opportunity per exact
                    # (match, turn, ACK) identity, so an unchanged watermark
                    # cannot trigger repeated broad scans.
                    allow_gap_full_scan = True
                    provider_scan_diagnostics = provider.scan_diagnostics
                    available_board_sequences = (
                        _provider_available_board_sequences(
                            provider_scan_diagnostics
                        )
                    )
                    mandatory_cached_fastpath = (
                        _mandatory_cached_board_fastpath_allowed(
                            p3_mandatory_reset_pending,
                            mandatory_cached_board_fastpath_polls,
                        )
                    )
                    if fast_bounded_handoff_iteration or mandatory_cached_fastpath:
                        early_observation = _runtime_observation_for_controller(
                            target,
                            monitor,
                            session_key=active_session,
                            match_id=active_session.match_id,
                            turn=(
                                last_state.battle.turn_number
                                if last_state is not None
                                else None
                            ),
                            srv_seq=(
                                last_state.battle.srv_seq
                                if last_state is not None
                                else None
                            ),
                            fast_bounded_handoff=True,
                        )
                        if mandatory_cached_fastpath:
                            mandatory_cached_board_fastpath_polls += 1
                        _write(
                            log,
                            (
                                "mandatory_cached_board_fastpath_poll"
                                if mandatory_cached_fastpath
                                else "bounded_handoff_direct_runtime_sample"
                            ),
                            session=active_session,
                            runtime=early_observation.runtime,
                            serverDtoScanPerformed=False,
                            reusedProvenOpening=True,
                            fastpathPoll=(
                                mandatory_cached_board_fastpath_polls
                                if mandatory_cached_fastpath
                                else None
                            ),
                        )
                    else:
                        early_observation = monitor.poll(
                            session_key=active_session,
                            match_id=active_session.match_id,
                            turn=(
                                last_state.battle.turn_number
                                if last_state is not None
                                else None
                            ),
                            srv_seq=(
                                last_state.battle.srv_seq
                                if last_state is not None
                                else None
                            ),
                            timestamp=utc_timestamp(),
                            force_full_scan=force_full_pass_scan,
                            enable_gap_full_scan=allow_gap_full_scan,
                            allow_gap_full_escalation=True,
                            available_board_sequences=available_board_sequences,
                            offered_board_message_addresses=(
                                transport_offered_messages
                            ),
                        )
                        if (
                            force_full_pass_scan
                            and early_observation.scan_performed
                        ):
                            pass_full_scan_attempt_identity = pass_scan_identity
                    early_messages = early_observation.messages
                    if (
                        pass_coordinator is not None
                        and pass_coordinator.gameplay_locked
                        and early_observation.scan_performed
                    ):
                        _write(
                            log,
                            "pass_message_scan",
                            fullScan=early_observation.full_scan_performed,
                            scanReason=early_observation.scan_reason,
                            elapsedSeconds=(
                                early_observation.scan_elapsed_seconds
                            ),
                            regionCount=early_observation.scan_region_count,
                            bytesRead=early_observation.scan_bytes_read,
                            messageCount=len(early_observation.messages),
                            runtime=early_observation.runtime,
                        )
                    elif (
                        early_observation.scan_performed
                        and early_observation.full_scan_performed
                    ):
                        _write(
                            log,
                            "transport_full_scan",
                            reason=early_observation.scan_reason,
                            elapsedSeconds=early_observation.scan_elapsed_seconds,
                            regionCount=early_observation.scan_region_count,
                            bytesRead=early_observation.scan_bytes_read,
                            messageCount=len(early_observation.messages),
                            boardMessageCount=len(early_observation.board_messages),
                            heapBatchCount=len(early_observation.combat_batches),
                            runtime=early_observation.runtime,
                        )
                    elif (
                        early_observation.scan_performed
                        and early_observation.scan_reason
                        == "LOCAL_TURN_ACK_GAP_BOUNDED"
                    ):
                        _write(
                            log,
                            "transport_gap_bounded_scan",
                            reason=early_observation.scan_reason,
                            elapsedSeconds=early_observation.scan_elapsed_seconds,
                            regionCount=early_observation.scan_region_count,
                            bytesRead=early_observation.scan_bytes_read,
                            messageCount=len(early_observation.messages),
                            boardMessageCount=len(early_observation.board_messages),
                            heapBatchCount=len(early_observation.combat_batches),
                            runtime=early_observation.runtime,
                        )
                    move_messages = _unoffered_transport_board_messages(
                        early_observation.board_messages,
                        transport_offered_messages,
                    )
                    for batch in early_observation.combat_batches:
                        batch_key = (batch.address, batch.sequence)
                        if batch_key in runtime_offered_batches:
                            continue
                        accepted = provider.offer_runtime_heap_batch(batch)
                        runtime_offered_batches.add(batch_key)
                        _write(
                            log,
                            "runtime_heap_batch_offered",
                            batchAddress=hex_pointer(batch.address),
                            boardAddress=hex_pointer(batch.board_array),
                            srvSeq=batch.sequence,
                            completeCells=len(batch.cells),
                            accepted=accepted,
                        )
                    if move_messages and opening_classes is None:
                        resolved = tuple(
                            target.resolver.resolve_type_info_class(rva)
                            for rva in (
                                JARRAY_TYPE_INFO_RVA,
                                JOBJECT_TYPE_INFO_RVA,
                                JPROPERTY_TYPE_INFO_RVA,
                                JVALUE_TYPE_INFO_RVA,
                            )
                        )
                        if all(value is not None for value in resolved):
                            opening_classes = NewtonsoftClasses(
                                *(int(value) for value in resolved)
                            )
                    if opening_classes is not None:
                        for message in move_messages:
                            try:
                                snapshot = read_match_payload_board_snapshot(
                                    target.memory,
                                    match_id=active_session.match_id,
                                    message_address=message.address,
                                    payload_address=int(message.payload_address),
                                    classes=opening_classes,
                                    event_type=message.event_type,
                                )
                                accepted = provider.offer_transport_board_snapshot(
                                    snapshot, event_type=message.event_type
                                )
                                transport_offered_messages.add(message.address)
                                _write(
                                    log,
                                    "transport_board_snapshot_offered",
                                    eventType=message.event_type,
                                    messageAddress=hex_pointer(message.address),
                                    boardAddress=hex_pointer(
                                        snapshot.board_token_address
                                    ),
                                    srvSeq=snapshot.sequence,
                                    completeCells=len(snapshot.cells),
                                    accepted=accepted,
                                )
                            except (OSError, RuntimeError, ValueError) as exc:
                                _write(
                                    log,
                                    "transport_board_snapshot_rejected",
                                    eventType=message.event_type,
                                    messageAddress=hex_pointer(message.address),
                                    reason=str(exc),
                                )
                except (OSError, RuntimeError, ValueError) as exc:
                    _write(log, "early_runtime_monitor_error", detail=str(exc))

            # Briefly sample the direct MatchService turn roots first. This
            # path never evaluates policy and never sends gameplay input.
            if (
                active_session is not None
                and turn_transitions.action is not None
                and not turn_transitions.opponent_seen
                and fast_transition_deadline is not None
                and time.monotonic() < fast_transition_deadline
            ):
                try:
                    _service, fast_runtime = read_match_runtime(target)
                    fast_transition, role = _observe_fast_runtime_turn(
                        turn_transitions,
                        counters,
                        observed_turns,
                        session=active_session,
                        turn=fast_runtime.turn,
                        current_player=fast_runtime.current_player,
                        local_username=fast_runtime.local_username,
                        progress_observer=(
                            shared_runtime.turn_progress_observer
                            if shared_runtime is not None
                            else None
                        ),
                    )
                    if fast_transition is not None:
                        _write(
                            log,
                            "turn_transition",
                            kind=fast_transition.kind,
                            evidence="MatchService fast direct-root sample",
                            priorAction=fast_transition.action,
                            runtime=fast_runtime,
                        )
                        if (
                            fast_transition.kind
                            is TurnTransitionKind.LOCAL_TURN_WITHOUT_OBSERVED_OPPONENT
                        ):
                            guard.pause(automatic=True)
                            stop_reason = "TURN_TRANSITION_NOT_PROVEN"
                            _write(
                                log,
                                "auto_pause",
                                reason=stop_reason,
                                action=fast_transition.action,
                                runtime=fast_runtime,
                            )
                            _beep("pause", not args.no_beep)
                        elif (
                            fast_transition.kind is TurnTransitionKind.OPPONENT_TURN
                            and complete_direct_runtime_consuming_action(
                                fast_runtime
                            )
                        ):
                            pass
                        fast_transition_deadline = None
                    if role is not None:
                        _write(
                            log,
                            "turn_observed",
                            role=role,
                            session=active_session,
                            turn=fast_runtime.turn,
                            source="MatchService fast direct-root sample",
                        )
                except (OSError, RuntimeError, ValueError) as exc:
                    _write(
                        log,
                        "runtime_turn_sample_unavailable",
                        detail=str(exc),
                    )
                time.sleep(args.interval)
                continue

            if (
                turn_transitions.action is not None
                and not turn_transitions.opponent_seen
                and fast_transition_deadline is not None
                and time.monotonic() >= fast_transition_deadline
            ):
                expired_transition = (
                    turn_transitions.expire_unconfirmed_local()
                )
                fast_transition_deadline = None
                if expired_transition is not None:
                    guard.pause(automatic=True)
                    stop_reason = "TURN_TRANSITION_NOT_PROVEN"
                    _write(
                        log,
                        "turn_transition",
                        kind=expired_transition.kind,
                        evidence="MatchService transition deadline expired",
                        priorAction=expired_transition.action,
                    )
                    _write(
                        log,
                        "auto_pause",
                        reason=stop_reason,
                        action=expired_transition.action,
                    )
                    _beep("pause", not args.no_beep)

            poll = _provider_poll_for_controller(
                provider,
                pass_wait_locked=bool(
                    pass_coordinator is not None
                    and pass_coordinator.gameplay_locked
                ),
                active_session=active_session,
                fast_opening_runtime=(
                    early_observation.runtime
                    if fast_bounded_handoff_iteration
                    and early_observation is not None
                    else None
                ),
            )
            provider_status = (
                poll.reason,
                poll.lifecycle_event,
                str(poll.combat_lifecycle.state) if poll.combat_lifecycle else None,
                provider.scan_diagnostics["lobbyBaselineReady"],
            )
            if provider_status != last_provider_status:
                lifecycle_key = (
                    poll.combat_lifecycle.state
                    if poll.combat_lifecycle is not None
                    else None,
                    poll.lifecycle_event,
                )
                if lifecycle_key != last_lifecycle_key:
                    lifecycle_sample = {
                        "timestamp": utc_timestamp(),
                        "state": (
                            poll.combat_lifecycle.state.value
                            if poll.combat_lifecycle is not None
                            else None
                        ),
                        "lifecycleEvent": poll.lifecycle_event,
                        "reason": poll.reason,
                        "session": _jsonable(poll.session_key),
                    }
                    lifecycle_timeline.append(lifecycle_sample)
                    _write(log, "lifecycle_observed", **lifecycle_sample)
                    last_lifecycle_key = lifecycle_key
                _write(
                    log,
                    "provider_status",
                    reason=poll.reason,
                    lifecycle=poll.lifecycle_event,
                    combatLifecycle=(
                        poll.combat_lifecycle.state if poll.combat_lifecycle else None
                    ),
                    confirmations=poll.confirmations,
                    session=poll.session_key,
                    diagnostics=provider.scan_diagnostics,
                )
                last_provider_status = provider_status
            if hotkeys.emergency_stop_requested() or _farm_emergency_requested(
                shared_runtime
            ):
                aborted = guard.stop()
                stop_reason = "EMERGENCY_STOP"
                _write(log, "emergency_stop", key="F9", pending=aborted, checkpoint="AFTER_PROVIDER_POLL")
                if aborted is not None:
                    _write(
                        log,
                        "action_result",
                        result=ActionResultKind.ACTION_ABORTED_STATE_CHANGED,
                        action=aborted,
                        reason="EMERGENCY_STOP",
                    )
                break
            state = poll.state
            if state is not None and state.terminal_snapshot is not None:
                terminal_combat_snapshot = merge_terminal_snapshots(
                    terminal_combat_snapshot, state.terminal_snapshot
                )
                if terminal_combat_snapshot.result is not TerminalResult.UNKNOWN:
                    full_combat_result = terminal_combat_snapshot.result.value
            if state is not None and state.phase is GamePhase.COMBAT:
                last_state = state
                role = _record_turn_observation(
                    counters,
                    observed_turns,
                    session=state.battle.session_key,
                    turn=state.battle.turn_number,
                    current_player=state.battle.current_turn_player,
                    local_username=state.battle.local_username,
                    progress_observer=(
                        shared_runtime.turn_progress_observer
                        if shared_runtime is not None
                        else None
                    ),
                )
                if role is not None:
                    _write(
                        log,
                        "turn_observed",
                        role=role,
                        session=state.battle.session_key,
                        turn=state.battle.turn_number,
                        source="published GameState",
                    )
                if (
                    active_session is not None
                    and state.battle.session_key == active_session
                    and state.battle.match_id == active_session.match_id
                    and state.battle.local_has_left_match is True
                ):
                    recovery_dispatched = _dispatch_technical_recovery(
                        runtime,
                        reason="LOCAL_PLAYER_LEFT_ACTIVE_COMBAT",
                        state=state,
                        local_player_left_evidence={
                            "session_key": active_session,
                            "match_id": active_session.match_id,
                        },
                    )
                    invalidated = (
                        guard.require_recovery()
                        if recovery_dispatched
                        else guard.pause(automatic=True)
                    )
                    stop_reason = "LOCAL_PLAYER_LEFT_ACTIVE_COMBAT"
                    _write(
                        log,
                        "technical_recovery_handoff",
                        reason=stop_reason,
                        session=active_session,
                        turn=state.battle.turn_number,
                        localActorNumber=state.battle.local_actor_number,
                        localHasLeftMatch=True,
                        evidenceSource="Board._leftActorNumbers",
                        pending=invalidated,
                        gameplayInputDisabled=True,
                        automaticUiOwnedByOuterCoordinator=recovery_dispatched,
                        failClosed=True,
                    )
                    _beep(
                        "recovery" if recovery_dispatched else "pause",
                        not args.no_beep,
                    )
                    break
            if poll.reason == "stable_non_board_fusion_transition":
                _write(
                    log,
                    "post_fusion_follow_up_checkpoint",
                    stage="FRESH_STATE_PUBLISHED",
                    session=state.battle.session_key if state is not None else None,
                    turn=state.battle.turn_number if state is not None else None,
                    srvSeq=state.battle.srv_seq if state is not None else None,
                    fusion=state.fusion if state is not None else None,
                )

            # Fusion success is a non-consuming same-turn action. Resolve its
            # exact durable MatchService transition before the slower managed-
            # heap response scan so a complete board reread still has time to
            # produce the required same-turn follow-up SWAP/CAST.
            direct_pending = guard.pending
            if (
                direct_pending is not None
                and direct_pending.identity.action is PolicyAction.EVOLVE
                and provider.current_session_key
                == direct_pending.identity.source.session
            ):
                direct_fusion = provider.observed_fusion
                direct_result = _fusion_terminal_result(
                    direct_pending,
                    direct_fusion,
                )
                if direct_result is ActionResultKind.EVOLVE_SUCCESS:
                    guard.complete_pending()
                    counters.evolve_success += 1
                    terminal_evolve_activity_turns.add(
                        (
                            direct_pending.identity.source.session,
                            direct_pending.identity.source.turn,
                        )
                    )
                    post_evolve_input_settle = (
                        direct_pending.identity.source.session,
                        direct_pending.identity.source.turn,
                        time.monotonic() + POST_EVOLVE_INPUT_SETTLE_SECONDS,
                        direct_result,
                    )
                    post_evolve_settle_logged = False
                    _write(
                        log,
                        "action_result",
                        result=direct_result,
                        action=direct_pending,
                        response=direct_pending.response_evidence,
                        terminalEquivalent="MATCH_SERVICE_DURABLE_FUSION_TRANSITION",
                        fusion=direct_fusion,
                        requiresFreshState=True,
                    )
                    _write(
                        log,
                        "evolve_idle_semantics",
                        consumesTurn=False,
                        idleState=idle_cache.state,
                        resetBaseline=idle_cache.reset_baseline,
                        localIdleMutation=False,
                    )
                    time.sleep(args.interval)
                    continue

            if (
                poll.session_key is not None
                and (
                    poll.lifecycle_event in {"board_found", "session_changed"}
                    or handoff_session_pending
                )
            ):
                if runtime.expected_session is not None and poll.session_key != runtime.expected_session:
                    guard.stop()
                    stop_reason = "FARM_HANDOFF_SESSION_MISMATCH"
                    _write(
                        log,
                        "farm_handoff_rejected",
                        expectedSession=runtime.expected_session,
                        observedSession=poll.session_key,
                    )
                    break
                active_session = poll.session_key
                handoff_session_pending = False
                if runtime.expected_session is not None:
                    _write(log, "farm_handoff_session_confirmed", session=active_session)
                if preopening_session is not None:
                    monitor.end_session(preopening_session)
                if runtime.expected_session is None:
                    monitor.begin_session(active_session, active_session.match_id, clean=True)
                guard.begin_session()
                idle_session = _idle_session_id(active_session)
                if idle_session is None:
                    raise RuntimeError("combat session has no idle-state identity")
                idle_cache.begin_session(idle_session)
                if pass_coordinator is not None:
                    pass_coordinator.begin_session(idle_session)
                recovery = RecoveryStateMachine()
                source_decisions.clear()
                consuming_turns.clear()
                consuming_action_turns.clear()
                turn_transitions.clear()
                evolve_attempts = 0
                fusion_attempts_by_turn.clear()
                opening_ready_logged.clear()
                opening_board_only_logged.clear()
                transport_offered_messages.clear()
                runtime_offered_batches.clear()
                fast_transition_deadline = None
                action_baseline_ready = False
                opening_offered_message = None
                session_seen = True
                p3_mandatory_reset_pending = False
                p3_reset_validation_pending = False
                p3_reset_validation_activity = None
                post_evolve_input_settle = None
                post_evolve_settle_logged = False
                terminal_evolve_activity_turns.clear()
                unconfirmed_action_turns.clear()
                evolve_only_turn_wait = None
                optional_card_suppressions.clear()
                direct_pass_result_turn = None
                active_progress_watchdog.reset()
                counters.sessions_started += 1
                _write(log, "combat_session_started", session=active_session)
                if (
                    preloaded_opening is not None
                    and preloaded_opening.match_id == active_session.match_id
                ):
                    accepted = provider.offer_opening_snapshot(
                        preloaded_opening
                    )
                    opening_offered_message = preloaded_opening.message_address
                    _write(
                        log,
                        "opening_snapshot_offered",
                        source="preloaded_before_board_lifecycle",
                        messageAddress=hex_pointer(
                            preloaded_opening.message_address
                        ),
                        boardAddress=hex_pointer(
                            preloaded_opening.board_token_address
                        ),
                        srvSeq=preloaded_opening.sequence,
                        completeCells=len(preloaded_opening.cells),
                        accepted=accepted,
                    )

            messages: tuple[ServerMessage, ...] = ()
            raw_runtime = None
            observation = None
            if active_session is not None:
                try:
                    # The pre-provider observation was taken in this same
                    # controller iteration specifically to preserve transient
                    # MATCH_MOVE_RES payloads. Reuse it here instead of scanning
                    # the learned ChatMessageDTO regions a second time. Live
                    # retry-11 evidence showed the duplicate scan consumed the
                    # opening turn before the already-valid two-sample board
                    # could reach policy. If the session became active during
                    # provider.poll(), no early observation exists and the
                    # normal post-provider poll still runs.
                    observation = early_observation
                    if observation is None:
                        observation = monitor.poll(
                            session_key=active_session,
                            match_id=active_session.match_id,
                            turn=(
                                state.battle.turn_number
                                if state is not None
                                else None
                            ),
                            srv_seq=(
                                state.battle.srv_seq
                                if state is not None
                                else None
                            ),
                            timestamp=utc_timestamp(),
                        )
                    messages = tuple(
                        dict.fromkeys((*early_messages, *observation.messages))
                    )
                    raw_runtime = observation.runtime
                    role = _record_turn_observation(
                        counters,
                        observed_turns,
                        session=active_session,
                        turn=raw_runtime.turn,
                        current_player=raw_runtime.current_player,
                        local_username=raw_runtime.local_username,
                        progress_observer=(
                            shared_runtime.turn_progress_observer
                            if shared_runtime is not None
                            else None
                        ),
                    )
                    if role is not None:
                        _write(
                            log,
                            "turn_observed",
                            role=role,
                            session=active_session,
                            turn=raw_runtime.turn,
                            source="MatchService runtime monitor",
                        )
                    runtime_transition = turn_transitions.observe_runtime(
                        session=active_session,
                        turn=raw_runtime.turn,
                        current_player=raw_runtime.current_player,
                        local_username=raw_runtime.local_username,
                    )
                    if runtime_transition is not None:
                        _write(
                            log,
                            "turn_transition",
                            kind=runtime_transition.kind,
                            evidence="MatchService.CurrentTurnPlayer/TurnNumber",
                            priorAction=runtime_transition.action,
                            runtime=raw_runtime,
                        )
                        if (
                            runtime_transition.kind
                            is TurnTransitionKind.LOCAL_TURN_WITHOUT_OBSERVED_OPPONENT
                        ):
                            guard.pause(automatic=True)
                            stop_reason = "TURN_TRANSITION_NOT_PROVEN"
                            _write(
                                log,
                                "auto_pause",
                                reason=stop_reason,
                                action=runtime_transition.action,
                                runtime=raw_runtime,
                            )
                            _beep("pause", not args.no_beep)
                        elif (
                            runtime_transition.kind is TurnTransitionKind.OPPONENT_TURN
                            and complete_direct_runtime_consuming_action(
                                raw_runtime
                            )
                        ):
                            pass
                    action_baseline_ready = action_baseline_ready or monitor.has_scanned
                    start_message = observation.current_match_start
                    if (
                        start_message is not None
                        and start_message.address != opening_offered_message
                        and start_message.payload_address is not None
                    ):
                        if opening_classes is None:
                            resolved = tuple(
                                target.resolver.resolve_type_info_class(rva)
                                for rva in (
                                    JARRAY_TYPE_INFO_RVA,
                                    JOBJECT_TYPE_INFO_RVA,
                                    JPROPERTY_TYPE_INFO_RVA,
                                    JVALUE_TYPE_INFO_RVA,
                                )
                            )
                            if all(value is not None for value in resolved):
                                opening_classes = NewtonsoftClasses(
                                    *(int(value) for value in resolved)
                                )
                        if opening_classes is not None:
                            try:
                                opening = read_match_start_opening_snapshot(
                                    target.memory,
                                    match_id=active_session.match_id,
                                    message_address=start_message.address,
                                    payload_address=start_message.payload_address,
                                    classes=opening_classes,
                                )
                                accepted = provider.offer_opening_snapshot(opening)
                                opening_offered_message = start_message.address
                                _write(
                                    log,
                                    "opening_snapshot_offered",
                                    messageAddress=hex_pointer(start_message.address),
                                    boardAddress=hex_pointer(
                                        opening.board_token_address
                                    ),
                                    srvSeq=opening.sequence,
                                    completeCells=len(opening.cells),
                                    accepted=accepted,
                                )
                            except (OSError, RuntimeError, ValueError) as exc:
                                _write(
                                    log,
                                    "opening_snapshot_rejected",
                                    messageAddress=hex_pointer(
                                        start_message.address
                                    ),
                                    reason=str(exc),
                                )
                except (OSError, RuntimeError, ValueError) as exc:
                    _write(log, "runtime_monitor_error", detail=str(exc))

            if poll.reason == "stable_non_board_fusion_transition":
                _write(
                    log,
                    "post_fusion_follow_up_checkpoint",
                    stage="RUNTIME_MONITOR_COMPLETE",
                    messageCount=len(messages),
                    runtime=raw_runtime,
                )

            acceptance_stop_requested = False
            idle_session = _idle_session_id(active_session)
            if (
                pass_coordinator is not None
                and pass_coordinator.gameplay_locked
                and raw_runtime is not None
                and pass_coordinator.attempt is not None
                and raw_runtime.turn is not None
                and raw_runtime.turn > pass_coordinator.attempt.source_turn
            ):
                pass_coordinator.observe_turn_end()

            for message in messages:
                if (
                    message.event_type == "MATCH_GAME_OVER"
                    and active_session is not None
                    and message.match_id == active_session.match_id
                ):
                    winner = dict(message.payload_strings).get("winner")
                    terminal_observation = capture_terminal_snapshot(
                        session_key=active_session,
                        timestamp=utc_timestamp(),
                        active_state=last_state,
                        terminal_participants=(
                            state.participants if state is not None else ()
                        ),
                        terminal_event_type="MATCH_GAME_OVER",
                        terminal_winner=winner,
                        local_username=(
                            raw_runtime.local_username
                            if raw_runtime is not None
                            else (
                                last_state.battle.local_username
                                if last_state is not None
                                else None
                            )
                        ),
                        ui_text=(
                            state.terminal_snapshot.ui_text
                            if state is not None
                            and state.terminal_snapshot is not None
                            else None
                        ),
                        captured_before_cleanup=True,
                    )
                    terminal_combat_snapshot = merge_terminal_snapshots(
                        terminal_combat_snapshot, terminal_observation
                    )
                    if (
                        terminal_combat_snapshot.result
                        is not TerminalResult.UNKNOWN
                    ):
                        full_combat_result = terminal_combat_snapshot.result.value
                    _write(
                        log,
                        "authoritative_terminal_event_observed",
                        message=message,
                        terminalCombatSnapshot=terminal_combat_snapshot,
                    )
                authoritative_idle = bool(
                    idle_session is not None
                    and raw_runtime is not None
                    and message.event_type in {"MATCH_AFK_WARN", "MATCH_TURN_END"}
                    and message.username
                    and message.idle_count is not None
                    and message.threshold is not None
                )
                idle_rejection = None
                if authoritative_idle:
                    idle_rejection = _authoritative_idle_owner_rejection(
                        message.username,
                        raw_runtime.local_username,
                    )
                if authoritative_idle and idle_rejection is not None:
                    # A foreign or partially materialized candidate says
                    # nothing about the cached local-player state.  Preserve
                    # the same-session state/reset baseline and fail closed via
                    # ordinary freshness/turn checks if it later becomes stale.
                    authoritative_idle = False
                if (
                    authoritative_idle
                    and message.event_type == "MATCH_TURN_END"
                    and message.source_turn != raw_runtime.turn
                ):
                    authoritative_idle = False
                    idle_rejection = "stale_nested_idle_turn"

                observed_idle = None
                if authoritative_idle:
                    try:
                        observed_idle = idle_cache.observe_server_payload(
                            session_id=idle_session,
                            username=message.username or "",
                            idle_count=int(message.idle_count),
                            threshold=int(message.threshold),
                            source_message_type=message.event_type,
                            source_srv_seq=message.server_sequence,
                            source_turn=message.source_turn,
                            source_timestamp=message.timestamp,
                            observed_timestamp=utc_timestamp(),
                            source_path=(
                                "MATCH_TURN_END.matchPayload.afkWarn"
                                if message.event_type == "MATCH_TURN_END"
                                else "MATCH_AFK_WARN"
                            ),
                        )
                    except ValueError as exc:
                        idle_rejection = str(exc)
                        authoritative_idle = False
                if observed_idle is not None:
                    observe_b5_server_reset(observed_idle)
                    # An authoritative 2/3 warning can follow any unaccepted
                    # or timed-out consuming action, not only an intentional
                    # PASS coordinated by this process. Preserve that exact
                    # game-owned requirement across the next local turn so a
                    # source-turn-less MATCH_AFK_WARN cannot degrade to
                    # ``idle_state_source_turn_mismatch`` and permit a third
                    # zero-input turn. The normal PASS terminal path owns the
                    # same transition while its coordinator is locked.
                    if (
                        pass_stage == "B5"
                        and observed_idle.idle_count
                        == observed_idle.threshold - 1
                        and not p3_mandatory_reset_pending
                        and not (
                            pass_coordinator is not None
                            and pass_coordinator.gameplay_locked
                        )
                    ):
                        p3_mandatory_reset_pending = True
                        counters.mandatory_actions_required += 1
                        _write(
                            log,
                            "mandatory_action_state_entered",
                            authoritativeIdle=observed_idle,
                            allowedActions=["SWAP", "CAST"],
                            evolveSatisfiesMandatory=False,
                            thirdPassForbidden=True,
                            source="AUTHORITATIVE_IDLE_2_OUTSIDE_PASS_WAIT",
                        )
                    if (
                        evolve_only_turn_wait is not None
                        and observed_idle.session_id == idle_session
                    ):
                        evolve_only_turn_wait = replace(
                            evolve_only_turn_wait,
                            authoritative_idle_observed=True,
                            direct_idle_requires_turn_correlation=bool(
                                evolve_only_turn_wait.direct_idle_requires_turn_correlation
                                or (
                                    observed_idle.source_message_type
                                    == "MATCH_AFK_WARN"
                                    and observed_idle.source_turn is None
                                )
                            ),
                        )
                        counters.evolve_only_authoritative_idle_events += 1
                        _write(
                            log,
                            "evolve_only_turn_authoritative_idle_observed",
                            wait=evolve_only_turn_wait,
                            authoritativeIdle=observed_idle,
                            countedAsIntentionalPass=False,
                            localIdleMutation=False,
                        )
                if authoritative_idle or idle_rejection is not None:
                    _write(
                        log,
                        "authoritative_idle_observed",
                        session=active_session,
                        runtime=raw_runtime,
                        message=message,
                        accepted=authoritative_idle,
                        rejection=idle_rejection,
                        idleState=idle_cache.state,
                    )

                if (
                    observed_idle is not None
                    and pass_coordinator is not None
                    and pass_coordinator.gameplay_locked
                ):
                    terminal = pass_coordinator.observe_authoritative_idle(
                        observed_idle,
                        timestamp=utc_timestamp(),
                        gameplay_inputs_total=counters.input_actions_total,
                        newly_observed_after_start=True,
                    )
                    if terminal is not None:
                        counters.pass_gameplay_inputs += (
                            terminal.gameplay_inputs_during_wait
                        )
                        if terminal.result is PassResultKind.PASS_CONFIRMED_IDLE_1:
                            counters.pass_confirmed_idle_1 += 1
                        elif terminal.result is PassResultKind.PASS_CONFIRMED_IDLE_2:
                            counters.pass_confirmed_idle_2 += 1
                        elif terminal.result is PassResultKind.PASS_STATE_UNCONFIRMED:
                            counters.pass_state_unconfirmed += 1
                        else:
                            counters.pass_aborted += 1
                        if (
                            terminal.authoritative_idle is not None
                            and terminal.authoritative_idle.source_message_type
                            == "MATCH_AFK_WARN"
                            and terminal.authoritative_idle.source_turn is None
                            and terminal.result
                            in {
                                PassResultKind.PASS_CONFIRMED_IDLE_1,
                                PassResultKind.PASS_CONFIRMED_IDLE_2,
                            }
                        ):
                            direct_pass_result_turn = terminal.attempt.source_turn
                        _write(
                            log,
                            "pass_result",
                            result=terminal.result,
                            passAttempt=terminal.attempt,
                            authoritativeIdle=terminal.authoritative_idle,
                            detail=terminal.detail,
                            gameplayInputsDuringWait=terminal.gameplay_inputs_during_wait,
                            serverTurnEndObserved=True,
                            afkWarnPayload=terminal.authoritative_idle,
                            idleAfter=idle_cache.state,
                        )
                        if _dispatch_unconfirmed_pass_recovery(
                            runtime,
                            terminal=terminal,
                            raw_runtime=raw_runtime,
                            active_session=active_session,
                            state=last_state,
                        ):
                            guard.require_recovery()
                            stop_reason = "ACTIONABILITY_STATE_LOST"
                            _write(
                                log,
                                "technical_recovery_handoff",
                                reason=stop_reason,
                                passResult=terminal.result,
                                passAttempt=terminal.attempt,
                                runtime=raw_runtime,
                                gameplayInputDisabled=True,
                                automaticUiOwnedByOuterCoordinator=True,
                            )
                            _beep("recovery", not args.no_beep)
                            acceptance_stop_requested = True
                            pass_coordinator.take_terminal()
                            continue
                        disposition = _pass_terminal_disposition(
                            pass_stage,
                            terminal.result,
                            p3_reset_validation_pending=p3_reset_validation_pending,
                        )
                        if disposition.stop:
                            guard.pause(automatic=True)
                            stop_reason = disposition.stop_reason
                            _beep("pause", not args.no_beep)
                            acceptance_stop_requested = True
                        else:
                            if disposition.complete_reset_cycle:
                                p3_reset_validation_pending = False
                                p3_reset_validation_activity = None
                                counters.pass_reset_cycles_confirmed += 1
                                counters.pass_after_reset_idle_1 += 1
                                _write(
                                    log,
                                    "b5_authoritative_pass_reset_cycle_confirmed",
                                    passAttempt=terminal.attempt,
                                    authoritativeIdle=terminal.authoritative_idle,
                                    completeSequence=(
                                        "PASS_1 -> PASS_2 -> mandatory consuming "
                                        "action -> later PASS_1"
                                    ),
                                )
                            if disposition.begin_p3_mandatory_reset:
                                p3_mandatory_reset_pending = True
                                counters.mandatory_actions_required += 1
                                _write(
                                    log,
                                    "mandatory_action_state_entered",
                                    authoritativeIdle=terminal.authoritative_idle,
                                    allowedActions=["SWAP", "CAST"],
                                    evolveSatisfiesMandatory=False,
                                    thirdPassForbidden=True,
                                )
                            pass_coordinator.take_terminal()

                activity_kind = {
                    "MATCH_MOVE_RES": AcceptedActivityKind.SWAP,
                    "MATCH_CARD_USE_RES": AcceptedActivityKind.CAST,
                    "MATCH_SKILL_USE_RES": AcceptedActivityKind.CAST,
                    "MATCH_FUSION_RES": AcceptedActivityKind.EVOLVE,
                }.get(message.event_type)
                actor = _message_actor(message)
                local_activity = bool(
                    activity_kind is not None
                    and raw_runtime is not None
                    and actor
                    and raw_runtime.local_username
                    and actor.casefold() == raw_runtime.local_username.casefold()
                    and not _message_rejected(message)
                )
                pass_wait_activity = bool(
                    local_activity
                    and pass_coordinator is not None
                    and pass_coordinator.gameplay_locked
                )
                fresh_pass_wait_activity = bool(
                    pass_wait_activity
                    and _pass_wait_activity_is_fresh(
                        message, pass_coordinator.attempt
                    )
                )
                if pass_wait_activity and not fresh_pass_wait_activity:
                    _write(
                        log,
                        "pass_stale_activity_ignored",
                        message=message,
                        passAttempt=pass_coordinator.attempt,
                        reason="server_timestamp_or_sequence_not_new_for_pass_wait",
                    )
                if (
                    fresh_pass_wait_activity
                    and pass_coordinator is not None
                ):
                    terminal = pass_coordinator.abort_user_action(
                        timestamp=utc_timestamp(),
                        gameplay_inputs_total=counters.input_actions_total,
                        detail=f"manual {message.event_type} observed during PASS_WAIT",
                    )
                    if terminal is not None:
                        counters.pass_aborted += 1
                        _write(
                            log,
                            "pass_result",
                            result=terminal.result,
                            passAttempt=terminal.attempt,
                            response=message,
                            detail=terminal.detail,
                        )
                        guard.pause(automatic=True)
                        stop_reason = terminal.result.value
                        _beep("pause", not args.no_beep)
                        acceptance_stop_requested = True

            if acceptance_stop_requested:
                break

            desync = monitor.tracker.state
            if desync.terminal_for_session and guard.status is not AutonomousStatus.RECOVERY_REQUIRED:
                if pass_coordinator is not None and pass_coordinator.gameplay_locked:
                    pass_terminal = pass_coordinator.observe_runtime(
                        timestamp=utc_timestamp(),
                        gameplay_inputs_total=counters.input_actions_total,
                        session_id=idle_session,
                        lifecycle_active=True,
                        sequence_desync=True,
                        current_turn=(raw_runtime.turn if raw_runtime is not None else None),
                        is_local_turn=None,
                        current_local_move_sequence=(
                            raw_runtime.local_move_sequence
                            if raw_runtime is not None
                            else None
                        ),
                    )
                    if pass_terminal is not None:
                        counters.pass_aborted += 1
                        _write(
                            log,
                            "pass_result",
                            result=pass_terminal.result,
                            passAttempt=pass_terminal.attempt,
                            detail=pass_terminal.detail,
                        )
                idle_cache.clear("sequence_desync_terminal")
                invalidated = guard.require_recovery()
                counters.sequence_desync += 1
                _write(
                    log,
                    "action_result",
                    result=ActionResultKind.SEQUENCE_DESYNC,
                    pending=invalidated,
                    state=desync,
                )
                if last_state is not None:
                    try:
                        artifact = write_sequence_desync_artifact(
                            log_path.parent / "sequence_desync",
                            desync=desync,
                            state=last_state,
                            recent_events=monitor.events.snapshot(),
                            screenshot_writer=lambda path: capture_client_png(target.pid, path),
                        )
                        _write(log, "sequence_desync_artifact_saved", directory=str(artifact.directory))
                    except (FileExistsError, OSError, RuntimeError, ValueError):
                        pass
                recovery.desync_detected()
                recovery_dispatched = _dispatch_technical_recovery(
                    runtime,
                    reason="SEQUENCE_DESYNC",
                    state=last_state,
                    desync=desync,
                )
                _beep("recovery", not args.no_beep)
                _write(
                    log,
                    "recovery_required",
                    reason="SEQUENCE_DESYNC",
                    automaticExit=recovery_dispatched,
                    technicalRecoveryHandoff=recovery_dispatched,
                )
                stop_reason = "REJECTED_SEQUENCE_DESYNC"

            if guard.status is AutonomousStatus.RECOVERY_REQUIRED:
                if (
                    runtime.technical_recovery_dispatcher is not None
                    and runtime.technical_recovery_dispatcher.recovery_pending
                ):
                    guard.stop()
                    _write(
                        log,
                        "technical_recovery_handoff",
                        reason=stop_reason,
                        gameplayInputDisabled=True,
                        pending=None,
                        automaticUiOwnedByOuterCoordinator=True,
                    )
                    break
                if poll.combat_lifecycle is not None:
                    recovery.observe_lifecycle(poll.combat_lifecycle.state)
                if recovery.state is RecoveryLifecycleState.BOSS_MAP_OR_LOBBY:
                    counters.sessions_completed += 1
                    recovered_session = active_session
                    if recovered_session is not None:
                        monitor.end_session(recovered_session)
                        recovered_idle_session = _idle_session_id(recovered_session)
                        if recovered_idle_session is not None:
                            idle_cache.end_session(recovered_idle_session)
                    if pass_coordinator is not None:
                        pass_coordinator.clear_session()
                    active_session = None
                    source_decisions.clear()
                    consuming_turns.clear()
                    consuming_action_turns.clear()
                    unconfirmed_action_turns.clear()
                    optional_card_suppressions.clear()
                    turn_transitions.clear()
                    session_cleared = True
                    _write(
                        log,
                        "manual_recovery_complete",
                        lifecycle=poll.combat_lifecycle.state if poll.combat_lifecycle else None,
                        session=recovered_session,
                        sessionCleared=session_cleared,
                        automaticReentry=False,
                    )
                    break
                if recovery.state is RecoveryLifecycleState.EXIT_CONTROL_CLICKED:
                    modal = _locate_temporally(
                        target.pid,
                        locate_confirm_leave,
                        attempts=3,
                        interval=0.08,
                        minimum_hits=2,
                    )
                    if modal.found:
                        recovery.modal_visible()
                        _write(log, "confirm_modal_proven", locator=modal)
                        _beep("recovery", not args.no_beep)
                if recovery_hotkey and _manual_recovery_step(
                    recovery=recovery,
                    target=target,
                    executor=executor,
                    binding=binding,
                    log=log,
                ):
                    counters.recovery_steps += 1
                time.sleep(args.interval)
                continue

            if pass_coordinator is not None and pass_coordinator.gameplay_locked:
                runtime_for_pass = raw_runtime
                lifecycle_for_pass = _pass_lifecycle_evidence(
                    (
                        poll.combat_lifecycle.state
                        if poll.combat_lifecycle is not None
                        else None
                    ),
                    (
                        runtime_for_pass.match_id
                        if runtime_for_pass is not None
                        else None
                    ),
                )
                attempt_for_pass = pass_coordinator.attempt
                runtime_session_matches = bool(
                    runtime_for_pass is not None
                    and attempt_for_pass is not None
                    and runtime_for_pass.match_id == attempt_for_pass.match_id
                )
                local_for_pass = None
                if runtime_for_pass is not None:
                    local_for_pass = bool(
                        runtime_for_pass.local_username
                        and runtime_for_pass.current_player
                        and runtime_for_pass.local_username.casefold()
                        == runtime_for_pass.current_player.casefold()
                    )
                pass_terminal = pass_coordinator.observe_runtime(
                    timestamp=utc_timestamp(),
                    gameplay_inputs_total=counters.input_actions_total,
                    session_id=(idle_session if runtime_session_matches else None),
                    lifecycle_active=lifecycle_for_pass,
                    sequence_desync=False,
                    current_turn=(
                        runtime_for_pass.turn if runtime_for_pass is not None else None
                    ),
                    is_local_turn=local_for_pass,
                    current_local_move_sequence=(
                        runtime_for_pass.local_move_sequence
                        if runtime_for_pass is not None
                        else None
                    ),
                    scan_complete_for_next_local_turn=bool(
                        observation is not None and observation.scan_performed
                    ),
                )
                if pass_terminal is not None:
                    counters.pass_gameplay_inputs += (
                        pass_terminal.gameplay_inputs_during_wait
                    )
                    if pass_terminal.result is PassResultKind.PASS_CONFIRMED_IDLE_1:
                        counters.pass_confirmed_idle_1 += 1
                    elif pass_terminal.result is PassResultKind.PASS_CONFIRMED_IDLE_2:
                        counters.pass_confirmed_idle_2 += 1
                    elif pass_terminal.result is PassResultKind.PASS_STATE_UNCONFIRMED:
                        counters.pass_state_unconfirmed += 1
                    else:
                        counters.pass_aborted += 1
                    if (
                        pass_terminal.authoritative_idle is not None
                        and pass_terminal.authoritative_idle.source_message_type
                        == "MATCH_AFK_WARN"
                        and pass_terminal.authoritative_idle.source_turn is None
                        and pass_terminal.result
                        in {
                            PassResultKind.PASS_CONFIRMED_IDLE_1,
                            PassResultKind.PASS_CONFIRMED_IDLE_2,
                        }
                    ):
                        direct_pass_result_turn = pass_terminal.attempt.source_turn
                    _write(
                        log,
                        "pass_result",
                        result=pass_terminal.result,
                        passAttempt=pass_terminal.attempt,
                        authoritativeIdle=pass_terminal.authoritative_idle,
                        detail=pass_terminal.detail,
                        gameplayInputsDuringWait=pass_terminal.gameplay_inputs_during_wait,
                        serverTurnEndObserved=True,
                        afkWarnPayload=pass_terminal.authoritative_idle,
                        idleAfter=idle_cache.state,
                    )
                    if _dispatch_unconfirmed_pass_recovery(
                        runtime,
                        terminal=pass_terminal,
                        raw_runtime=raw_runtime,
                        active_session=active_session,
                        state=last_state,
                    ):
                        guard.require_recovery()
                        stop_reason = "ACTIONABILITY_STATE_LOST"
                        _write(
                            log,
                            "technical_recovery_handoff",
                            reason=stop_reason,
                            passResult=pass_terminal.result,
                            passAttempt=pass_terminal.attempt,
                            runtime=raw_runtime,
                            gameplayInputDisabled=True,
                            automaticUiOwnedByOuterCoordinator=True,
                        )
                        _beep("recovery", not args.no_beep)
                        pass_coordinator.take_terminal()
                        break
                    disposition = _pass_terminal_disposition(
                        pass_stage,
                        pass_terminal.result,
                        p3_reset_validation_pending=p3_reset_validation_pending,
                    )
                    if disposition.stop:
                        guard.pause(automatic=True)
                        stop_reason = disposition.stop_reason
                        _beep("pause", not args.no_beep)
                        break
                    if disposition.complete_reset_cycle:
                        p3_reset_validation_pending = False
                        p3_reset_validation_activity = None
                        counters.pass_reset_cycles_confirmed += 1
                        counters.pass_after_reset_idle_1 += 1
                        _write(
                            log,
                            "b5_authoritative_pass_reset_cycle_confirmed",
                            passAttempt=pass_terminal.attempt,
                            authoritativeIdle=pass_terminal.authoritative_idle,
                            completeSequence=(
                                "PASS_1 -> PASS_2 -> mandatory consuming "
                                "action -> later PASS_1"
                            ),
                        )
                    if disposition.begin_p3_mandatory_reset:
                        p3_mandatory_reset_pending = True
                        counters.mandatory_actions_required += 1
                        _write(
                            log,
                            "mandatory_action_state_entered",
                            authoritativeIdle=pass_terminal.authoritative_idle,
                            allowedActions=["SWAP", "CAST"],
                            evolveSatisfiesMandatory=False,
                            thirdPassForbidden=True,
                        )
                    pass_coordinator.take_terminal()
                if pass_coordinator.gameplay_locked:
                    time.sleep(args.interval)
                    continue

            if evolve_only_turn_wait is not None:
                runtime_local_turn = None
                if raw_runtime is not None:
                    runtime_local_turn = bool(
                        raw_runtime.local_username
                        and raw_runtime.current_player
                        and raw_runtime.local_username.casefold()
                        == raw_runtime.current_player.casefold()
                    )
                evolve_wait_status = _evolve_only_turn_wait_status(
                    evolve_only_turn_wait,
                    current_session=active_session,
                    current_match_id=(
                        raw_runtime.match_id if raw_runtime is not None else None
                    ),
                    current_turn=(raw_runtime.turn if raw_runtime is not None else None),
                    is_local_turn=runtime_local_turn,
                    current_local_move_sequence=(
                        raw_runtime.local_move_sequence
                        if raw_runtime is not None
                        else None
                    ),
                    gameplay_inputs_total=counters.input_actions_total,
                )
                if evolve_wait_status in {
                    "WAIT_RUNTIME",
                    "WAIT_SOURCE_TURN",
                    "WAIT_OPPONENT_TURN",
                }:
                    if (
                        evolve_wait_status == "WAIT_OPPONENT_TURN"
                        and not evolve_only_turn_wait.opponent_turn_observed
                    ):
                        evolve_only_turn_wait = replace(
                            evolve_only_turn_wait,
                            opponent_turn_observed=True,
                        )
                        _write(
                            log,
                            "evolve_only_turn_opponent_observed",
                            wait=evolve_only_turn_wait,
                            runtime=raw_runtime,
                            gameplayInputSent=False,
                        )
                    time.sleep(args.interval)
                    continue
                if evolve_wait_status == "COMPLETED_NEXT_LOCAL_TURN":
                    completed_evolve_wait = evolve_only_turn_wait
                    evolve_only_turn_wait = None
                    counters.evolve_only_turns_completed += 1
                    if completed_evolve_wait.direct_idle_requires_turn_correlation:
                        direct_pass_result_turn = completed_evolve_wait.source_turn
                    _write(
                        log,
                        "evolve_only_turn_completed",
                        wait=completed_evolve_wait,
                        runtime=raw_runtime,
                        result=(
                            "AUTHORITATIVE_IDLE_OBSERVED"
                            if completed_evolve_wait.authoritative_idle_observed
                            else "NO_AFK_PAYLOAD_OBSERVED"
                        ),
                        countedAsIntentionalPass=False,
                        passCoordinatorUsed=False,
                        gameplayInputsDuringWait=(
                            counters.input_actions_total
                            - completed_evolve_wait.gameplay_inputs_total
                        ),
                    )
                    # Force a full provider reread for the new local turn;
                    # never reuse the EVOLVE turn's board snapshot.
                    time.sleep(args.interval)
                    continue
                guard.pause(automatic=True)
                stop_reason = "EVOLVE_ONLY_TURN_STATE_CHANGED"
                _write(
                    log,
                    "auto_pause",
                    reason=stop_reason,
                    detail=evolve_wait_status,
                    wait=evolve_only_turn_wait,
                    runtime=raw_runtime,
                    failClosed=True,
                )
                _beep("pause", not args.no_beep)
                break

            accepted_consuming_actions = (
                counters.swap_acknowledged + counters.cast_accepted
            )
            progress_window = executor.window_status(binding)
            progress_state = last_state
            progress_state_exact = bool(
                raw_runtime is not None
                and active_session is not None
                and progress_state is not None
                and progress_state.phase is GamePhase.COMBAT
                and progress_state.battle.combat_lifecycle
                is CombatLifecycleState.ACTIVE
                and progress_state.battle.session_key == active_session
                and progress_state.battle.match_id == raw_runtime.match_id
                and progress_state.battle.turn_number == raw_runtime.turn
                and progress_state.battle.current_turn_player
                and raw_runtime.current_player
                and progress_state.battle.current_turn_player.casefold()
                == raw_runtime.current_player.casefold()
                and progress_state.battle.local_username
                and raw_runtime.local_username
                and progress_state.battle.local_username.casefold()
                == raw_runtime.local_username.casefold()
                and progress_state.board is not None
                and progress_state.board.production_ready
            )
            progress_stall = active_progress_watchdog.observe(
                sampled_at=time.monotonic(),
                session_key=active_session,
                match_id=(raw_runtime.match_id if raw_runtime is not None else None),
                turn=(raw_runtime.turn if raw_runtime is not None else None),
                current_player=(
                    raw_runtime.current_player if raw_runtime is not None else None
                ),
                local_username=(
                    raw_runtime.local_username if raw_runtime is not None else None
                ),
                remaining_seconds=(
                    raw_runtime.remaining if raw_runtime is not None else None
                ),
                local_move_sequence=(
                    raw_runtime.local_move_sequence
                    if raw_runtime is not None
                    else None
                ),
                last_move_sequence=(
                    raw_runtime.last_move_sequence if raw_runtime is not None else None
                ),
                highest_acked_sequence=(
                    raw_runtime.highest_acked_sequence
                    if raw_runtime is not None
                    else None
                ),
                eligible=bool(
                    progress_state_exact
                    and progress_window.valid
                    and progress_window.foreground
                    and guard.status is AutonomousStatus.RUNNING
                    and guard.pending is None
                    and accepted_consuming_actions >= 1
                    and not (
                        pass_coordinator is not None
                        and pass_coordinator.gameplay_locked
                    )
                    and evolve_only_turn_wait is None
                    and not (
                        desync is not None
                        and bool(getattr(desync, "terminal_for_session", False))
                    )
                ),
            )
            if progress_stall is not None:
                recovery_dispatched = _dispatch_technical_recovery(
                    runtime,
                    reason="ACTIVE_COMBAT_PROGRESS_STALLED",
                    state=progress_state,
                    active_combat_progress_stall=progress_stall,
                    active_combat_progress_evidence={
                        "game_foreground": bool(progress_window.foreground),
                        "window_valid": bool(progress_window.valid),
                        "controller_running": (
                            guard.status is AutonomousStatus.RUNNING
                        ),
                        "pending_action": guard.pending is not None,
                        "accepted_consuming_actions": accepted_consuming_actions,
                        "authoritative_pass_wait_active": bool(
                            pass_coordinator is not None
                            and pass_coordinator.gameplay_locked
                        ),
                        "evolve_wait_active": evolve_only_turn_wait is not None,
                        "sequence_desync": desync,
                    },
                )
                _write(
                    log,
                    "active_combat_progress_stalled",
                    stall=progress_stall,
                    recoveryDispatched=recovery_dispatched,
                    gameplayInputSent=False,
                    evidenceSource=(
                        "direct MatchService turn/current-player/timer/"
                        "move-sequence/ACK signature"
                    ),
                )
                if recovery_dispatched:
                    invalidated = guard.require_recovery()
                    stop_reason = "ACTIVE_COMBAT_PROGRESS_STALLED"
                    _write(
                        log,
                        "technical_recovery_handoff",
                        reason=stop_reason,
                        session=active_session,
                        turn=progress_stall.turn,
                        currentTurnPlayer=progress_stall.current_player,
                        remaining=progress_stall.remaining_seconds,
                        unchangedSeconds=progress_stall.unchanged_seconds,
                        samples=progress_stall.sample_count,
                        highestAckedSequence=(
                            progress_stall.highest_acked_sequence
                        ),
                        pending=invalidated,
                        gameplayInputDisabled=True,
                        automaticUiOwnedByOuterCoordinator=True,
                    )
                    _beep("recovery", not args.no_beep)
                    break
                guard.pause(automatic=True)
                stop_reason = "ACTIVE_COMBAT_PROGRESS_STALL_PREFLIGHT_REJECTED"
                _write(
                    log,
                    "farm_safe_stop_immediate",
                    reason=stop_reason,
                    automaticInputDisabled=True,
                    failClosed=True,
                )
                break

            deadline_turn = (
                raw_runtime.turn
                if raw_runtime is not None
                else (state.battle.turn_number if state is not None else None)
            )
            deadline_match_id = (
                raw_runtime.match_id
                if raw_runtime is not None
                else (state.battle.match_id if state is not None else None)
            )
            deadline_current_player = (
                raw_runtime.current_player
                if raw_runtime is not None
                else (
                    state.battle.current_turn_player if state is not None else None
                )
            )
            deadline_local_username = (
                raw_runtime.local_username
                if raw_runtime is not None
                else (state.battle.local_username if state is not None else None)
            )
            deadline_remaining = (
                raw_runtime.remaining
                if raw_runtime is not None
                else (
                    state.battle.turn_time_remaining_seconds
                    if state is not None
                    else None
                )
            )
            deadline_warning_seconds = _local_turn_deadline_warning_seconds(
                args.minimum_action_time
            )
            if _local_turn_action_deadline_reached(
                session=active_session,
                turn=deadline_turn,
                match_id=deadline_match_id,
                current_player=deadline_current_player,
                local_username=deadline_local_username,
                remaining_seconds=deadline_remaining,
                warning_seconds=deadline_warning_seconds,
                status=guard.status,
                pending=guard.pending,
                consuming_action_turns=consuming_action_turns,
            ):
                diagnostics = provider.scan_diagnostics
                recovery_dispatched = bool(
                    raw_runtime is not None
                    and active_session is not None
                    and _dispatch_technical_recovery(
                        runtime,
                        reason="ACTIONABILITY_STATE_LOST",
                        state=last_state,
                        actionability_evidence={
                            "session_key": active_session,
                            "match_id": raw_runtime.match_id,
                            "turn": int(raw_runtime.turn),
                            "current_player": raw_runtime.current_player,
                            "local_username": raw_runtime.local_username,
                            "remaining_seconds": int(raw_runtime.remaining),
                            "warning_seconds": deadline_warning_seconds,
                            "local_move_sequence": (
                                raw_runtime.local_move_sequence
                            ),
                            "last_move_sequence": raw_runtime.last_move_sequence,
                            "provider_reason": poll.reason,
                            "actionability_gate_reason": (
                                last_gate[1]
                                if isinstance(last_gate, tuple)
                                and len(last_gate) > 1
                                else None
                            ),
                            "accepted_consuming_actions": (
                                accepted_consuming_actions
                            ),
                            "last_accepted_srv_seq": diagnostics[
                                "lastAcceptedSeq"
                            ],
                            "last_accepted_board_hash": diagnostics[
                                "lastAcceptedHash"
                            ],
                            "highest_acked_sequence": diagnostics[
                                "highestAckedSequence"
                            ],
                            "last_published_turn": (
                                last_state.battle.turn_number
                                if last_state is not None
                                else None
                            ),
                        },
                    )
                )
                recovery_reason = (
                    "ACTIONABILITY_STATE_LOST" if recovery_dispatched else None
                )
                if (
                    not recovery_dispatched
                    and raw_runtime is not None
                    and active_session is not None
                    and last_state is not None
                ):
                    deadline_window = executor.window_status(binding)
                    recovery_dispatched = _dispatch_technical_recovery(
                        runtime,
                        reason="CONTROLLER_STALLED_ACTIVE_COMBAT",
                        state=last_state,
                        controller_stall_evidence={
                            "session_key": active_session,
                            "match_id": raw_runtime.match_id,
                            "turn": int(raw_runtime.turn),
                            "remaining_seconds": int(raw_runtime.remaining),
                            "warning_seconds": deadline_warning_seconds,
                            "game_foreground": bool(deadline_window.foreground),
                            "window_valid": bool(deadline_window.valid),
                            "controller_running": (
                                guard.status is AutonomousStatus.RUNNING
                            ),
                            "pending_action": guard.pending is not None,
                            "consuming_action_sent": (
                                (active_session, int(raw_runtime.turn))
                                in consuming_action_turns
                            ),
                            "authoritative_pass_wait_active": bool(
                                pass_coordinator is not None
                                and pass_coordinator.gameplay_locked
                            ),
                            "evolve_wait_active": evolve_only_turn_wait is not None,
                            "sequence_desync": desync,
                        },
                    )
                    if recovery_dispatched:
                        recovery_reason = "CONTROLLER_STALLED_ACTIVE_COMBAT"
                if recovery_dispatched:
                    guard.require_recovery()
                    stop_reason = recovery_reason or "ACTIONABILITY_STATE_LOST"
                    _write(
                        log,
                        "technical_recovery_handoff",
                        reason=stop_reason,
                        deadlineReason="LOCAL_TURN_ACTION_DEADLINE",
                        session=active_session,
                        turn=deadline_turn,
                        remaining=deadline_remaining,
                        providerReason=poll.reason,
                        actionabilityGateReason=(
                            last_gate[1]
                            if isinstance(last_gate, tuple)
                            and len(last_gate) > 1
                            else None
                        ),
                        acceptedConsumingActions=accepted_consuming_actions,
                        localMoveSequence=raw_runtime.local_move_sequence,
                        lastMoveSequence=raw_runtime.last_move_sequence,
                        lastAcceptedSequence=diagnostics["lastAcceptedSeq"],
                        gameplayInputDisabled=True,
                        automaticUiOwnedByOuterCoordinator=True,
                    )
                    _beep("recovery", not args.no_beep)
                    break
                guard.pause(automatic=True)
                counters.local_turn_deadline_safe_stops += 1
                stop_reason = "LOCAL_TURN_ACTION_DEADLINE"
                _write(
                    log,
                    "auto_pause",
                    reason=stop_reason,
                    session=active_session,
                    turn=deadline_turn,
                    remaining=deadline_remaining,
                    warningSeconds=deadline_warning_seconds,
                    providerReason=poll.reason,
                    providerConfirmations=poll.confirmations,
                    highestAckedSequence=provider.metrics.highest_acked_sequence,
                    lastAcceptedSequence=diagnostics["lastAcceptedSeq"],
                    runtime=raw_runtime,
                    automaticPass=False,
                    userCanTakeOver=True,
                )
                _beep("pause", not args.no_beep)
                if runtime.gameplay_capability is not None:
                    guard.stop()
                    _write(
                        log,
                        "farm_safe_stop_immediate",
                        reason=stop_reason,
                        automaticInputDisabled=True,
                        userCanTakeOver=True,
                    )
                    break
                time.sleep(args.interval)
                continue

            if combat_ended:
                lifecycle_now = (
                    poll.combat_lifecycle.state
                    if poll.combat_lifecycle is not None
                    else CombatLifecycleState.UNKNOWN
                )
                if lifecycle_now in {
                    CombatLifecycleState.LOBBY,
                    CombatLifecycleState.STALE_SERVER_MATCH,
                }:
                    _write(
                        log,
                        "postmatch_observation_complete",
                        lifecycle=lifecycle_now,
                        automaticInputDisabled=True,
                        activeSession=active_session,
                    )
                    break
                if (
                    postmatch_observation_deadline is not None
                    and time.monotonic() >= postmatch_observation_deadline
                ):
                    _write(
                        log,
                        "postmatch_observation_timeout",
                        lifecycle=lifecycle_now,
                        timeoutSeconds=args.postmatch_observation_timeout,
                        automaticInputDisabled=True,
                        activeSession=active_session,
                    )
                    break
                time.sleep(args.interval)
                continue

            if _combat_ownership_ended(
                lifecycle_event=poll.lifecycle_event,
                lifecycle_state=(
                    poll.combat_lifecycle.state
                    if poll.combat_lifecycle is not None
                    else None
                ),
                session_seen=session_seen,
                active_session=active_session,
                state=state,
            ):
                ended_session = active_session
                lifecycle_stop_reason = _combat_end_stop_reason(
                    stop_reason, guard.status
                )
                pending_at_end = guard.pending
                terminal_result = None
                if pending_at_end is not None:
                    # Neither a bare _ackedSeqs advance nor a positive card
                    # response is enough after ownership ends. Exact SWAP
                    # coordinates/LocalSeqNum or the durable CAST transition
                    # must have completed the pending action before this point.
                    # Never invent acceptance from a terminal server sequence.
                    terminal_result = ActionResultKind.ACTION_ABORTED_STATE_CHANGED
                    counters.action_aborted_due_lifecycle += 1
                    if pending_at_end.identity.action is PolicyAction.SWAP:
                        executor.note_swap_unconfirmed(
                            "COMBAT_ENDED_WITH_UNCONFIRMED_SWAP"
                        )
                        counters.swap_aborted_due_lifecycle += 1
                        sequence_status = classify_swap_acceptance(
                            pending_at_end,
                            exact_runtime_accepted=False,
                            highest_acked_sequence=(
                                provider.metrics.highest_acked_sequence
                            ),
                        )
                        if pending_at_end.mandatory_after_idle_2:
                            mandatory_action_records.append(
                                {
                                    "action": "SWAP",
                                    "result": "COMBAT_END_UNCONFIRMED",
                                    "identity": pending_at_end.identity,
                                    "sequenceEvidence": sequence_status,
                                    "resetEvidence": None,
                                    "resetStatus": "COMBAT_ENDED_NO_FUTURE_PASS",
                                }
                            )
                    guard.stop()
                    _write(
                        log,
                        "action_result",
                        result=terminal_result,
                        action=pending_at_end,
                        reason="COMBAT_LIFECYCLE_ENDED",
                    )
                # Prefer terminal PlayerStats captured from the current
                # POSTMATCH ownership chain.  Fall back to the last ACTIVE
                # state only when the terminal read is unavailable; that path
                # correctly remains UNKNOWN unless death was already visible.
                if terminal_combat_snapshot is None and ended_session is not None:
                    terminal_combat_snapshot = capture_terminal_snapshot(
                        session_key=ended_session,
                        timestamp=utc_timestamp(),
                        active_state=last_state,
                        terminal_participants=(
                            state.participants if state is not None else ()
                        ),
                        local_username=(
                            last_state.battle.local_username
                            if last_state is not None
                            else None
                        ),
                        ui_text=(
                            state.terminal_snapshot.ui_text
                            if state is not None
                            and state.terminal_snapshot is not None
                            else None
                        ),
                        captured_before_cleanup=bool(
                            state is not None and state.participants
                        ),
                    )
                if terminal_combat_snapshot is not None:
                    full_combat_result = terminal_combat_snapshot.result.value
                else:
                    full_combat_result = "UNKNOWN"
                _write(
                    log,
                    "terminal_combat_snapshot",
                    session=ended_session,
                    terminalCombatSnapshot=terminal_combat_snapshot,
                    persistedBeforeControllerCleanup=True,
                )
                if ended_session is not None:
                    monitor.end_session(ended_session)
                    ended_idle_session = _idle_session_id(ended_session)
                    if ended_idle_session is not None:
                        idle_cache.end_session(ended_idle_session)
                if pass_coordinator is not None:
                    pass_coordinator.clear_session()
                counters.sessions_completed += 1
                guard.stop()
                stop_reason = lifecycle_stop_reason
                active_session = None
                active_progress_watchdog.reset()
                source_decisions.clear()
                consuming_turns.clear()
                consuming_action_turns.clear()
                unconfirmed_action_turns.clear()
                optional_card_suppressions.clear()
                turn_transitions.clear()
                fusion_attempts_by_turn.clear()
                fast_transition_deadline = None
                action_baseline_ready = False
                session_cleared = True
                combat_ended = True
                postmatch_observation_deadline = (
                    time.monotonic() + args.postmatch_observation_timeout
                )
                _write(
                    log,
                    "combat_session_ended",
                    session=ended_session,
                    lifecycle=poll.lifecycle_event,
                    pendingAtEnd=pending_at_end,
                    terminalActionResult=terminal_result,
                    fullCombatResult=full_combat_result,
                    terminalCombatSnapshot=terminal_combat_snapshot,
                    controllerStopReason=stop_reason,
                    sessionCleared=session_cleared,
                    automaticInputDisabled=True,
                )
                time.sleep(args.interval)
                continue

            pending = guard.pending
            if pending is not None:
                for message in messages:
                    response_state = state or last_state
                    if response_state is None:
                        continue
                    is_local_response = _local_message(message, response_state)
                    if pending.identity.action is PolicyAction.EVOLVE and message.event_type == "MATCH_FUSION_RES":
                        if not is_local_response:
                            continue
                        pending.server_response_seen = True
                        pending.response_success = dict(message.payload_bools).get("success")
                        pending.response_evidence = message
                    elif pending.identity.action is PolicyAction.CAST and message.event_type in {"MATCH_CARD_USE_RES", "MATCH_SKILL_USE_RES"}:
                        if not is_local_response:
                            continue
                        pending.server_response_seen = True
                        pending.response_success = not _message_rejected(message)
                        pending.response_evidence = message
                    elif pending.identity.action is PolicyAction.SWAP and message.event_type == "MATCH_REJECT":
                        if not is_local_response and (
                            message.username is not None
                            or dict(message.payload_strings).get("actorUsername") is not None
                        ):
                            continue
                        guard.complete_pending()
                        turn_transitions.clear()
                        guard.pause(automatic=True)
                        stop_reason = "SWAP_REJECTED"
                        counters.swap_rejected += 1
                        if pending.mandatory_after_idle_2:
                            counters.mandatory_swap_rejected += 1
                            mandatory_action_records.append(
                                {
                                    "action": "SWAP",
                                    "result": "SWAP_REJECTED",
                                    "identity": pending.identity,
                                    "resetEvidence": None,
                                    "resetStatus": "RESET_NOT_ESTABLISHED",
                                }
                            )
                        rejected_idle_session = _idle_session_id(
                            pending.identity.source.session
                        )
                        if rejected_idle_session is not None:
                            idle_cache.observe_rejected_activity(
                                session_id=rejected_idle_session,
                                kind=AcceptedActivityKind.SWAP,
                            )
                        _write(
                            log,
                            "action_result",
                            result=ActionResultKind.SWAP_REJECTED,
                            action=pending,
                            response=message,
                            autoPaused=True,
                        )
                        _beep("pause", not args.no_beep)
                        break
                if guard.pending is None:
                    time.sleep(args.interval)
                    continue

                if (
                    pending.identity.action is PolicyAction.CAST
                    and pending.server_response_seen
                    and pending.response_success is False
                ):
                    guard.complete_pending()
                    turn_transitions.clear()
                    guard.pause(automatic=True)
                    stop_reason = "CAST_REJECTED"
                    counters.cast_rejected += 1
                    if pending.mandatory_after_idle_2:
                        counters.mandatory_cast_rejected += 1
                        mandatory_action_records.append(
                            {
                                "action": "CAST",
                                "result": "CAST_REJECTED",
                                "identity": pending.identity,
                                "resetEvidence": None,
                                "resetStatus": "RESET_NOT_ESTABLISHED",
                            }
                        )
                    rejected_idle_session = _idle_session_id(
                        pending.identity.source.session
                    )
                    if rejected_idle_session is not None:
                        idle_cache.observe_rejected_activity(
                            session_id=rejected_idle_session,
                            kind=AcceptedActivityKind.CAST,
                        )
                    _write(
                        log,
                        "action_result",
                        result=ActionResultKind.CAST_REJECTED,
                        action=pending,
                        response=pending.response_evidence,
                        autoPaused=True,
                    )
                    _beep("pause", not args.no_beep)
                    time.sleep(args.interval)
                    continue

                if pending.identity.action is PolicyAction.SWAP:
                    sequence_status = classify_swap_acceptance(
                        pending,
                        exact_runtime_accepted=False,
                        highest_acked_sequence=(
                            provider.metrics.highest_acked_sequence
                        ),
                    )
                    if (
                        sequence_status
                        is SwapAcceptanceStatus.SEQUENCE_ADVANCED_UNATTRIBUTED
                        and not pending.server_response_seen
                    ):
                        pending.server_response_seen = True
                        pending.response_success = None
                        pending.response_evidence = {
                            "kind": sequence_status.value,
                            "sourceSrvSeq": pending.identity.source.srv_seq,
                            "highestAckedSequence": (
                                provider.metrics.highest_acked_sequence
                            ),
                        }
                        _write(
                            log,
                            "swap_sequence_advance_unattributed",
                            action=pending,
                            evidence=pending.response_evidence,
                            accepted=False,
                            idleResetApplied=False,
                            pendingRetained=True,
                        )
                elif pending.identity.action is PolicyAction.EVOLVE:
                    fusion_now = _latest_fusion_for_terminal(
                        state,
                        provider.observed_fusion,
                    )
                    result_kind = _fusion_terminal_result(pending, fusion_now)
                    if result_kind is not None:
                        guard.complete_pending()
                        if _evolve_terminal_touches_turn(result_kind):
                            terminal_evolve_activity_turns.add(
                                (
                                    pending.identity.source.session,
                                    pending.identity.source.turn,
                                )
                            )
                        if result_kind is ActionResultKind.EVOLVE_SUCCESS:
                            counters.evolve_success += 1
                        else:
                            counters.evolve_failed += 1
                        post_evolve_input_settle = (
                            pending.identity.source.session,
                            pending.identity.source.turn,
                            time.monotonic() + POST_EVOLVE_INPUT_SETTLE_SECONDS,
                            result_kind,
                        )
                        post_evolve_settle_logged = False
                        _write(log, "action_result", result=result_kind, action=pending, response=pending.response_evidence, requiresFreshState=True)
                        _write(
                            log,
                            "evolve_idle_semantics",
                            consumesTurn=False,
                            idleState=idle_cache.state,
                            resetBaseline=idle_cache.reset_baseline,
                            localIdleMutation=False,
                        )
                        time.sleep(args.interval)
                        continue
                elif pending.identity.action is PolicyAction.CAST:
                    if (
                        pass_stage in {"B4", "B5"}
                        and pending.consuming_transition_seen
                        and pending.consuming_transition_evidence is not None
                        and try_complete_b4_cast(
                            pending, pending.consuming_transition_evidence
                        )
                    ):
                        time.sleep(args.interval)
                        continue
                    current_card = None
                    if state is not None:
                        current_card = next((card for card in state.cards if card.object_address == pending.card_object_address), None)
                    accepted = bool(
                        pass_stage not in {"B4", "B5"}
                        and
                        pending.server_response_seen
                        and pending.response_success is True
                        and state is not None
                        and (
                            state.battle.turn_number != pending.identity.source.turn
                            or state.battle.is_local_turn is not True
                            or (
                                current_card is not None
                                and (
                                    current_card.has_used_this_turn
                                    or current_card.last_turn_used == pending.identity.source.turn
                                )
                            )
                        )
                    )
                    if accepted:
                        guard.complete_pending()
                        counters.cast_accepted += 1
                        _write(log, "action_result", result=ActionResultKind.CAST_ACCEPTED, action=pending, response=pending.response_evidence, sameTurnSwapBlocked=True)
                        response = pending.response_evidence
                        idle_activity = _observe_consuming_idle_acceptance(
                            idle_cache,
                            pending,
                            kind=AcceptedActivityKind.CAST,
                            source_srv_seq=(
                                response.server_sequence
                                if isinstance(response, ServerMessage)
                                else None
                            ),
                            source_timestamp=(
                                response.timestamp
                                if isinstance(response, ServerMessage)
                                else None
                            ),
                            source_message_type=(
                                response.event_type
                                if isinstance(response, ServerMessage)
                                else None
                            ),
                        )
                        _write(
                            log,
                            "idle_reset_activity_accepted",
                            activity=idle_activity,
                            resetBaseline=idle_cache.reset_baseline,
                        )
                        complete_p3_mandatory_reset(idle_activity)
                        time.sleep(args.interval)
                        continue

                response_deadline = (
                    pending.response_deadline
                    if pending.response_deadline is not None
                    else pending.sent_at + args.action_timeout
                )
                now = time.monotonic()
                if now >= response_deadline:
                    timeout_turn = None
                    timeout_remaining = None
                    timeout_is_local: bool | None = None
                    if raw_runtime is not None:
                        timeout_turn = raw_runtime.turn
                        timeout_remaining = raw_runtime.remaining
                        if raw_runtime.current_player and raw_runtime.local_username:
                            timeout_is_local = (
                                raw_runtime.current_player.casefold()
                                == raw_runtime.local_username.casefold()
                            )
                    elif state is not None:
                        timeout_turn = state.battle.turn_number
                        timeout_remaining = state.battle.turn_time_remaining_seconds
                        timeout_is_local = state.battle.is_local_turn
                    wait_plan = plan_action_response_wait(
                        pending,
                        session=active_session,
                        turn=timeout_turn,
                        is_local_turn=timeout_is_local,
                        remaining_seconds=timeout_remaining,
                        minimum_action_time=args.minimum_action_time,
                    )
                    if wait_plan.extend_observation:
                        pending.response_wait_extensions += 1
                        pending.response_deadline = now + wait_plan.extension_seconds
                        counters.action_response_wait_extensions += 1
                        _write(
                            log,
                            "action_response_wait_extended",
                            action=pending,
                            extensionSeconds=wait_plan.extension_seconds,
                            extensionIndex=pending.response_wait_extensions,
                            reason=wait_plan.reason,
                            inputRetried=False,
                            responseObservationRetried=True,
                        )
                        time.sleep(args.interval)
                        continue

                    guard.complete_pending()
                    counters.expired_actions += 1
                    counters.action_response_timeouts += 1
                    if pending.identity.action is PolicyAction.SWAP:
                        executor.note_swap_unconfirmed(
                            "SWAP_RESPONSE_OR_ACK_TIMEOUT"
                        )
                        pacing = executor.swap_pacer.decision(
                            remaining_seconds=timeout_remaining
                        )
                        _write(
                            log,
                            "swap_input_pacing_degraded",
                            action=pending,
                            pacing=pacing,
                            inputRetried=False,
                        )
                    turn_key = (
                        pending.identity.source.session,
                        pending.identity.source.turn,
                    )
                    unconfirmed_action_turns.add(turn_key)
                    if pending.consumes_turn:
                        # Keep the consuming transition tracker alive.  It may
                        # still prove that the original input was accepted, or
                        # observe the server-owned PASS transition when it was
                        # not.  Re-arm only a short read-only sampling window;
                        # never send the physical input again.
                        fast_transition_deadline = now + 3.0
                    if pending.mandatory_after_idle_2:
                        mandatory_action_records.append(
                            {
                                "action": pending.identity.action.value,
                                "result": ActionResultKind.ACTION_OUTCOME_UNCONFIRMED.value,
                                "identity": pending.identity,
                                "resetEvidence": None,
                                "resetStatus": "RESET_NOT_ESTABLISHED",
                            }
                        )
                    timeout_idle_readiness = idle_cache.pass_readiness(
                        current_session_id=_idle_session_id(active_session),
                        local_username=(
                            raw_runtime.local_username
                            if raw_runtime is not None
                            else (
                                state.battle.local_username
                                if state is not None
                                else None
                            )
                        ),
                        current_turn=timeout_turn,
                        is_local_turn=timeout_is_local,
                        lifecycle_active=bool(
                            state is not None
                            and state.battle.combat_lifecycle
                            is CombatLifecycleState.ACTIVE
                        ),
                        is_first_local_turn=bool(
                            state is not None
                            and state.battle.is_first_local_turn is True
                        ),
                    )
                    timeout_board_current = bool(
                        state is not None
                        and state.battle.session_key == active_session
                        and state.battle.turn_number == timeout_turn
                        and state.board.production_ready
                        and state.battle.stable
                        and state.battle.acknowledged
                        and state.battle.latest
                    )
                    start_evolve_wait, evolve_wait_reason = (
                        _can_wait_after_unconfirmed_evolve(
                            pending,
                            pass_stage=pass_stage,
                            active_session=active_session,
                            current_turn=timeout_turn,
                            is_local_turn=timeout_is_local,
                            is_first_local_turn=bool(
                                state is not None
                                and state.battle.is_first_local_turn is True
                            ),
                            lifecycle_active=bool(
                                state is not None
                                and state.battle.combat_lifecycle
                                is CombatLifecycleState.ACTIVE
                            ),
                            board_current_valid=timeout_board_current,
                            idle_can_pass=timeout_idle_readiness.can_pass_now,
                            idle_must_act=timeout_idle_readiness.must_act_now,
                            sequence_desync=(
                                monitor.tracker.state.terminal_for_session
                            ),
                            timeout_reason=wait_plan.reason,
                        )
                    )
                    _write(
                        log,
                        "action_result",
                        result=ActionResultKind.ACTION_OUTCOME_UNCONFIRMED,
                        action=pending,
                        reason="RESPONSE_OR_ACK_TIMEOUT",
                        timeoutPlan=wait_plan,
                        autoPaused=False,
                        countedAsRejected=False,
                        countedAsAuthoritativePass=False,
                        localIdleIncremented=False,
                        sameTurnInputSuppressed=True,
                        inputRetried=False,
                        authoritativeIdleRequired=True,
                        zeroInputWaitEligible=start_evolve_wait,
                        zeroInputWaitReason=evolve_wait_reason,
                        idleReadiness=timeout_idle_readiness,
                    )
                    if start_evolve_wait:
                        evolve_only_turn_wait = EvolveOnlyTurnWait(
                            session=pending.identity.source.session,
                            match_id=pending.identity.source.session.match_id,
                            source_turn=pending.identity.source.turn,
                            source_srv_seq=pending.identity.source.srv_seq,
                            board_hash=pending.identity.source.board_hash,
                            source_local_move_sequence=(
                                pending.local_move_sequence_before
                            ),
                            started_timestamp=utc_timestamp(),
                            gameplay_inputs_total=counters.input_actions_total,
                            origin="ACTION_RESPONSE_TIMEOUT",
                        )
                        counters.evolve_only_turn_waits += 1
                        _write(
                            log,
                            "unconfirmed_evolve_zero_input_wait_started",
                            wait=evolve_only_turn_wait,
                            timeoutPlan=wait_plan,
                            idleReadiness=timeout_idle_readiness,
                            inputRetried=False,
                            gameplayInputSent=False,
                            localIdleMutation=False,
                            authoritativeOutcomeRequired=True,
                        )
                time.sleep(args.interval)
                continue

            # Hard bounds are checked only after the latest input has a
            # terminal result and before another proposal can be evaluated.
            budget_reason = _bounded_stop_reason(
                counters,
                max_turn_actions=args.max_turn_actions,
                max_total_input_actions=args.max_total_input_actions,
                pending=guard.pending,
                legacy_max_actions=args.max_actions,
            )
            if budget_reason is not None:
                stop_reason = budget_reason
                guard.pause(automatic=True)
                if budget_reason == "AUTO_PAUSE_SAFETY_LIMIT":
                    counters.safety_limit_reached += 1
                _write(
                    log,
                    "auto_pause",
                    reason=budget_reason,
                    maxTurnActions=args.max_turn_actions,
                    maxTotalInputActions=args.max_total_input_actions,
                    legacyMaxActions=args.max_actions,
                    inputActionsTotal=counters.input_actions_total,
                    turnConsumingActionsTotal=counters.turn_consuming_actions_total,
                    terminalResultObserved=True,
                )
                _beep("pause", not args.no_beep)
                break

            if state is None or state.phase is not GamePhase.COMBAT:
                if (
                    guard.status is AutonomousStatus.RUNNING
                    and raw_runtime is not None
                    and raw_runtime.turn in (0, 1)
                    and raw_runtime.local_username
                    and raw_runtime.current_player
                    and raw_runtime.local_username.casefold()
                    == raw_runtime.current_player.casefold()
                    and raw_runtime.remaining is not None
                    and raw_runtime.remaining < args.minimum_action_time
                ):
                    guard.pause(automatic=True)
                    _write(
                        log,
                        "auto_pause",
                        reason="OPENING_STATE_UNAVAILABLE_BEFORE_TIMER_MARGIN",
                        runtime=raw_runtime,
                        automaticPass=False,
                    )
                    _beep("pause", not args.no_beep)
                time.sleep(args.interval)
                continue
            transition = turn_transitions.observe(state)
            if transition is not None:
                _write(
                    log,
                    "turn_transition",
                    kind=transition.kind,
                    priorAction=transition.action,
                    newSource=transition.new_source,
                )
                if (
                    transition.kind
                    is TurnTransitionKind.LOCAL_TURN_WITHOUT_OBSERVED_OPPONENT
                ):
                    guard.pause(automatic=True)
                    stop_reason = "TURN_TRANSITION_NOT_PROVEN"
                    _write(
                        log,
                        "auto_pause",
                        reason=stop_reason,
                        action=transition.action,
                        state=state.dedup_key,
                    )
                    _beep("pause", not args.no_beep)
                    continue
            if turn_transitions.action is not None:
                # After a terminal SWAP/CAST result, observe the boss turn and
                # the later fresh local turn before any new policy decision.
                # This also prevents an ACK publication race from evaluating
                # the just-consumed local turn again.
                time.sleep(args.interval)
                continue
            if guard.status is not AutonomousStatus.RUNNING:
                time.sleep(args.interval)
                continue

            current_turn_key = (
                (state.battle.session_key, int(state.battle.turn_number))
                if state.battle.session_key is not None
                and state.battle.turn_number is not None
                else None
            )
            if (
                current_turn_key is not None
                and current_turn_key in unconfirmed_action_turns
            ):
                # The action may have reached the server even though its ACK
                # was not captured.  Treat the rest of this source turn as a
                # deliberate zero-input wait.  The game-owned AFK payload —
                # not a local counter — will later determine whether it was a
                # PASS and whether the idle budget reset.
                time.sleep(args.interval)
                continue

            if post_evolve_input_settle is not None:
                (
                    settle_session,
                    settle_turn,
                    settle_not_before,
                    settle_result,
                ) = post_evolve_input_settle
                settle_now = time.monotonic()
                settle_status = _post_evolve_settle_status(
                    state,
                    source_session=settle_session,
                    source_turn=settle_turn,
                    not_before=settle_not_before,
                    now=settle_now,
                )
                if settle_status == "WAIT":
                    if not post_evolve_settle_logged:
                        post_evolve_settle_logged = True
                        _write(
                            log,
                            "post_evolve_input_settle_started",
                            session=settle_session,
                            turn=settle_turn,
                            terminalResult=settle_result,
                            settleSeconds=POST_EVOLVE_INPUT_SETTLE_SECONDS,
                            remainingSeconds=max(
                                0.0, settle_not_before - settle_now
                            ),
                            gameplayInputSent=False,
                        )
                    time.sleep(args.interval)
                    continue
                _write(
                    log,
                    "post_evolve_input_settle_complete",
                    session=settle_session,
                    sourceTurn=settle_turn,
                    currentTurn=state.battle.turn_number,
                    terminalResult=settle_result,
                    status=settle_status,
                    requireFreshActionabilityReread=True,
                )
                post_evolve_input_settle = None
                post_evolve_settle_logged = False

            window = executor.window_status(binding)
            gate = ActionabilityGate.evaluate(
                state,
                GateContext(
                    current_session=provider.current_session_key,
                    game_foreground=window.foreground,
                    window_valid=window.valid,
                    input_locked=False,
                    auto_paused=False,
                    sequence_desync=desync,
                    allow_opening_board_only=True,
                    allow_authoritative_board_only_stats=True,
                ),
            )
            if poll.reason == "stable_non_board_fusion_transition":
                _write(
                    log,
                    "post_fusion_follow_up_checkpoint",
                    stage="ACTIONABILITY_EVALUATED",
                    actionable=gate.actionable,
                    reason=gate.reason,
                    details=gate.details,
                )
            if not gate.actionable:
                gate_key = (state.dedup_key, gate.reason, tuple(sorted(gate.details)))
                if gate_key != last_gate:
                    _write(log, "action_gate_blocked", reason=gate.reason, details=gate.details)
                    last_gate = gate_key
                time.sleep(args.interval)
                continue
            last_gate = None
            if not action_baseline_ready:
                _write(log, "action_gate_blocked", reason="SERVER_DTO_BASELINE_NOT_READY")
                time.sleep(args.interval)
                continue

            current_idle_session = _idle_session_id(state.battle.session_key)
            if (
                direct_pass_result_turn is not None
                and current_idle_session is not None
                and state.battle.is_local_turn is True
                and state.battle.turn_number is not None
                and state.battle.turn_number > direct_pass_result_turn
            ):
                try:
                    associated = idle_cache.associate_direct_pass_result_with_turn(
                        session_id=current_idle_session,
                        completed_pass_turn=direct_pass_result_turn,
                        current_local_turn=state.battle.turn_number,
                    )
                    _write(
                        log,
                        "direct_idle_turn_correlated",
                        state=associated,
                        completedPassTurn=direct_pass_result_turn,
                        currentLocalTurn=state.battle.turn_number,
                    )
                    direct_pass_result_turn = None
                except ValueError as exc:
                    _write(
                        log,
                        "direct_idle_turn_correlation_rejected",
                        detail=str(exc),
                        completedPassTurn=direct_pass_result_turn,
                        currentLocalTurn=state.battle.turn_number,
                    )
                    # The direct event has either been superseded by a richer
                    # turn-associated payload or no longer belongs to the
                    # active cache session.  Do not retry a stale correlation
                    # on every later local turn.
                    direct_pass_result_turn = None
            idle_readiness = idle_cache.pass_readiness(
                current_session_id=current_idle_session,
                local_username=state.battle.local_username,
                current_turn=state.battle.turn_number,
                is_local_turn=state.battle.is_local_turn,
                lifecycle_active=(
                    state.battle.combat_lifecycle is CombatLifecycleState.ACTIVE
                ),
                is_first_local_turn=state.battle.is_first_local_turn,
            )
            state = _retain_mandatory_consuming_action_requirement(
                apply_idle_readiness_to_state(state, idle_readiness),
                mandatory_reset_pending=p3_mandatory_reset_pending,
            )
            last_state = state
            idle_observability = (
                state.battle.session_key,
                state.battle.turn_number,
                idle_readiness.readiness,
                idle_readiness.reason,
                idle_readiness.state,
                idle_readiness.reset_baseline,
            )
            if idle_observability != last_idle_observability:
                _write(
                    log,
                    "idle_readiness",
                    session=state.battle.session_key,
                    matchId=state.battle.match_id,
                    turn=state.battle.turn_number,
                    currentTurnPlayer=state.battle.current_turn_player,
                    readiness=idle_readiness,
                )
                last_idle_observability = idle_observability

            opening_authoritative = bool(
                "ChatMessageDTO.MATCH_START.matchPayload.board"
                in state.battle.sources
                and state.battle.is_first_local_turn is True
                and state.battle.local_move_sequence == 0
                and state.battle.last_move_sequence in (None, -1, 0)
            )
            if opening_authoritative and state.battle.session_key not in opening_ready_logged:
                opening_ready_logged.add(state.battle.session_key)
                _write(
                    log,
                    "OPENING_BOARD_READY",
                    session=state.battle.session_key,
                    matchId=state.battle.match_id,
                    turn=state.battle.turn_number,
                    srvSeq=state.battle.srv_seq,
                    boardHash=state.battle.board_hash,
                    completeCells=64,
                    sources=state.battle.sources,
                )

            optional_turn_key = (
                (state.battle.session_key, int(state.battle.turn_number))
                if state.battle.session_key is not None
                and state.battle.turn_number is not None
                else None
            )
            suppressed_optional_actions = frozenset(
                optional_card_suppressions.get(optional_turn_key, set())
                if optional_turn_key is not None
                else ()
            )
            if gate.details.get("boardOnlyStatsFallback") is True:
                suppressed_optional_actions = suppressed_optional_actions | frozenset(
                    {PolicyAction.EVOLVE, PolicyAction.CAST}
                )
                board_only_log_key = (
                    state.battle.session_key,
                    state.battle.turn_number,
                )
                if board_only_log_key not in opening_board_only_logged:
                    opening_board_only_logged.add(board_only_log_key)
                    _write(
                        log,
                        (
                            "opening_board_only_stats_fallback"
                            if gate.details.get("openingBoardOnly") is True
                            else "authoritative_board_only_stats_fallback"
                        ),
                        session=state.battle.session_key,
                        turn=state.battle.turn_number,
                        srvSeq=state.battle.srv_seq,
                        boardHash=state.battle.board_hash,
                        playerStatsKnown=state.player is not None,
                        bossStatsKnown=bool(state.opponents),
                        suppressedActions=[
                            PolicyAction.EVOLVE,
                            PolicyAction.CAST,
                        ],
                    )
            policy_state = _without_optional_card_actions(
                state, suppressed_optional_actions
            )
            analysis = analyze_game_state(policy_state, policy_engine=policy)
            basic_decision = policy.decide(policy_state)
            decision = _acceptance_forced_pass_decision(
                state,
                basic_decision,
                pass_stage=pass_stage,
                force_after_actions=args.acceptance_force_pass_after_actions,
                accepted_consuming_actions=(
                    counters.swap_acknowledged + counters.cast_accepted
                ),
                pass_coordinator=pass_coordinator,
                idle_readiness=idle_readiness,
            )
            if decision != basic_decision:
                _write(
                    log,
                    "acceptance_forced_pass_selected",
                    stage=pass_stage,
                    threshold=args.acceptance_force_pass_after_actions,
                    acceptedConsumingActions=(
                        counters.swap_acknowledged + counters.cast_accepted
                    ),
                    coordinatorConfirmedPasses=(
                        pass_coordinator.confirmed_passes
                        if pass_coordinator is not None
                        else None
                    ),
                    readiness=idle_readiness,
                    originalDecision=basic_decision,
                    forcedDecision=decision,
                )
            observed_branch = _record_policy_observation(
                counters,
                observed_policy_sources,
                state=state,
                decision=decision,
            )
            if observed_branch is not None:
                _write(
                    log,
                    "policy_branch_observed",
                    branch=observed_branch,
                    policyStep=decision.trace.policy_step,
                    action=decision.action,
                    session=state.battle.session_key,
                    turn=state.battle.turn_number,
                    srvSeq=state.battle.srv_seq,
                    boardHash=state.battle.board_hash,
                )
                if (
                    pass_stage == "B4"
                    and state.battle.session_key not in attack_priority_skip_logged
                ):
                    attack_priority_skip_logged.add(state.battle.session_key)
                    _write(
                        log,
                        "EVOLVE_SKIPPED_MANA_PRIORITY_ATTACK",
                        session=state.battle.session_key,
                        turn=state.battle.turn_number,
                        mana=(state.player.mana if state.player is not None else None),
                        fusion=state.fusion,
                        hardAssertion="evolve_input_count_must_equal_zero",
                    )
            if _b4_evolve_forbidden(
                stage=pass_stage,
                mana_priority=configured_mana_priority,
                action=decision.action,
            ):
                counters.attack_priority_evolve_violations += 1
                guard.stop()
                stop_reason = "B4_EVOLVE_FORBIDDEN"
                _write(
                    log,
                    "b4_hard_assertion_failed",
                    reason=stop_reason,
                    decision=decision,
                    evolveProposals=counters.evolve_proposals,
                    evolveInputs=counters.evolve_sent,
                    automaticInputDisabled=True,
                )
                _beep("pause", not args.no_beep)
                break
            if _verified_dead_board_preempts_mandatory_action(
                mandatory_reset_pending=p3_mandatory_reset_pending,
                action=decision.action,
                dead_board=analysis.dead_board,
            ):
                # The exhaustive board proof is a technical recovery signal,
                # not a PASS/NONE proposal.  Dispatch it before the generic
                # idle-2 consuming-action assertion so the outer coordinator
                # can perform its already bounded lobby recovery.
                counters.dead_board += 1
                stop_reason = "DEAD_BOARD_NO_REFRESH"
                guard.require_recovery()
                recovery.manual_test_required()
                artifact = _terminal_artifact(
                    root=log_path.parent / "dead_board",
                    event="DEAD_BOARD_NO_REFRESH",
                    target=target,
                    state=state,
                    policy=policy,
                )
                recovery_dispatched = _dispatch_technical_recovery(
                    runtime,
                    reason="DEAD_BOARD_NO_REFRESH",
                    state=state,
                    analysis=analysis,
                )
                _write(
                    log,
                    "recovery_required",
                    reason="DEAD_BOARD_NO_REFRESH",
                    artifact=artifact,
                    automaticExit=recovery_dispatched,
                    technicalRecoveryHandoff=recovery_dispatched,
                    preemptedMandatoryActionAssertion=True,
                    authoritativeIdle=idle_readiness,
                )
                _beep("recovery", not args.no_beep)
                continue
            if (
                p3_mandatory_reset_pending
                and decision.action not in {PolicyAction.SWAP, PolicyAction.CAST}
            ):
                mandatory_recovery_warning = (
                    _mandatory_reset_recovery_warning_seconds(
                        args.minimum_action_time
                    )
                )
                if (
                    runtime.technical_recovery_dispatcher is not None
                    and _late_mandatory_reset_recovery_required(
                        pass_stage=pass_stage,
                        mandatory_reset_pending=p3_mandatory_reset_pending,
                        readiness=idle_readiness,
                        action=decision.action,
                        remaining_seconds=(
                            state.battle.turn_time_remaining_seconds
                        ),
                        warning_seconds=mandatory_recovery_warning,
                    )
                ):
                    recovery_dispatched = _dispatch_technical_recovery(
                        runtime,
                        reason="LATE_MANDATORY_RESET",
                        state=state,
                        late_mandatory_reset_evidence={
                            "session_key": state.battle.session_key,
                            "match_id": state.battle.match_id,
                            "turn": int(state.battle.turn_number),
                            "remaining_seconds": int(
                                state.battle.turn_time_remaining_seconds
                            ),
                            "minimum_action_time": args.minimum_action_time,
                            "recovery_warning_seconds": (
                                mandatory_recovery_warning
                            ),
                            "selected_action": decision.action.value,
                            "policy_blocker": decision.trace.blocker,
                            "mandatory_reset_pending": True,
                            "game_foreground": bool(window.foreground),
                            "window_valid": bool(window.valid),
                            "controller_running": (
                                guard.status is AutonomousStatus.RUNNING
                            ),
                            "pending_action": guard.pending is not None,
                            "consuming_action_sent": (
                                (
                                    state.battle.session_key,
                                    int(state.battle.turn_number),
                                )
                                in consuming_action_turns
                            ),
                            "authoritative_pass_wait_active": bool(
                                pass_coordinator is not None
                                and pass_coordinator.gameplay_locked
                            ),
                            "evolve_wait_active": (
                                evolve_only_turn_wait is not None
                            ),
                            "sequence_desync": monitor.tracker.state,
                        },
                    )
                    if recovery_dispatched:
                        guard.require_recovery()
                        stop_reason = "LATE_MANDATORY_RESET"
                        _write(
                            log,
                            "technical_recovery_handoff",
                            reason=stop_reason,
                            deadlineReason=(
                                "LATE_AUTHORITATIVE_MANDATORY_RESET_"
                                "POLICY_BLOCKED"
                            ),
                            session=state.battle.session_key,
                            turn=state.battle.turn_number,
                            remaining=(
                                state.battle.turn_time_remaining_seconds
                            ),
                            minimumActionTime=args.minimum_action_time,
                            recoveryWarningSeconds=(
                                mandatory_recovery_warning
                            ),
                            authoritativeIdle=idle_readiness.state,
                            selectedAction=decision.action,
                            policyBlocker=decision.trace.blocker,
                            gameplayInputSent=False,
                            automaticUiOwnedByOuterCoordinator=True,
                        )
                        _beep("recovery", not args.no_beep)
                        break
                    guard.stop()
                    stop_reason = "LATE_MANDATORY_RESET_PREFLIGHT_REJECTED"
                    _write(
                        log,
                        "farm_safe_stop_immediate",
                        reason=stop_reason,
                        session=state.battle.session_key,
                        turn=state.battle.turn_number,
                        remaining=state.battle.turn_time_remaining_seconds,
                        gameplayInputSent=False,
                        failClosed=True,
                    )
                    _beep("pause", not args.no_beep)
                    break
                # Defense in depth around the policy boundary.  EVOLVE is a
                # function card and PASS/NONE sends no consuming input; none
                # can reset two authoritative idle turns.  Never let such a
                # proposal reach the executor even if a future policy change
                # accidentally reintroduces it.
                counters.wrong_third_pass += 1
                guard.stop()
                stop_reason = "MANDATORY_CONSUMING_ACTION_NOT_SELECTED"
                _write(
                    log,
                    "mandatory_consuming_action_assertion_failed",
                    reason=stop_reason,
                    session=state.battle.session_key,
                    turn=state.battle.turn_number,
                    decision=decision,
                    readiness=idle_readiness,
                    automaticInputDisabled=True,
                    failClosed=True,
                )
                _beep("pause", not args.no_beep)
                break
            if poll.reason == "stable_non_board_fusion_transition":
                _write(
                    log,
                    "post_fusion_follow_up_checkpoint",
                    stage="POLICY_EVALUATED",
                    action=decision.action,
                    move=decision.move,
                    policyStep=decision.trace.policy_step,
                    legalMoveCount=analysis.legal_match_producing_moves,
                    safeMoveCount=analysis.safe_move_count,
                )
            decision_key = (
                state.dedup_key,
                state.player,
                state.opponents,
                state.cards,
                state.fusion,
                state.battle.turn_time_remaining_seconds,
                state.battle.client_move_allowed,
                tuple(sorted(action.value for action in suppressed_optional_actions)),
            )
            signature = (decision.action, (decision.move, decision.card_object_address))
            previous = source_decisions.get(decision_key)
            if previous is not None and previous != signature:
                guard.pause(automatic=True)
                counters.stale_actions_blocked += 1
                _write(log, "action_result", result=ActionResultKind.ACTION_ABORTED_STATE_CHANGED, reason="NONDETERMINISTIC_POLICY_FOR_SAME_SOURCE", autoPaused=True)
                continue
            source_decisions[decision_key] = signature
            fields = _decision_fields(state, decision, analysis)
            if pass_stage == "B5" and p3_mandatory_reset_pending:
                mandatory_key = (
                    state.battle.session_key,
                    state.battle.turn_number,
                    state.battle.srv_seq,
                    state.battle.board_hash,
                    decision.action,
                    decision.move,
                    decision.card_object_address,
                )
                if mandatory_key not in mandatory_telemetry_logged:
                    mandatory_telemetry_logged.add(mandatory_key)
                    _write(
                        log,
                        "MANDATORY_ACTION_REQUIRED",
                        **fields,
                        authoritativeIdle=idle_cache.state,
                        readiness=idle_readiness,
                        legalCandidates=_mandatory_candidate_fields(analysis),
                        selectedReason=decision.trace.why_selected,
                        selectedConsumesTurn=decision.action
                        in {PolicyAction.SWAP, PolicyAction.CAST},
                        evolveSatisfiesMandatory=False,
                    )
                    if decision.action is PolicyAction.EVOLVE:
                        _write(
                            log,
                            "mandatory_action_deferred_for_evolve",
                            session=state.battle.session_key,
                            turn=state.battle.turn_number,
                            decision=decision,
                            mandatoryStateRetained=True,
                            consumesTurn=False,
                        )
            if _must_pause_for_no_safe_move(
                decision,
                legal_move_count=analysis.legal_match_producing_moves,
                safe_move_count=analysis.safe_move_count,
                first_local_turn=state.battle.is_first_local_turn,
            ):
                counters.policy_no_safe_move += 1
                guard.pause(automatic=True)
                stop_reason = "POLICY_NO_SAFE_MOVE"
                artifact = _terminal_artifact(
                    root=log_path.parent / "policy_pause",
                    event=stop_reason,
                    target=target,
                    state=state,
                    policy=policy,
                )
                _write(
                    log,
                    "auto_pause",
                    reason=stop_reason,
                    artifact=artifact,
                    **fields,
                )
                _beep("pause", not args.no_beep)
                continue
            _write(log, "policy_decision", **fields, trace=decision.trace)

            if decision.trace.blocker == "TURN_TIMER_SAFETY_MARGIN":
                counters.too_late += 1
                _write(log, "too_late_to_act", **fields)
                time.sleep(args.interval)
                continue
            if decision.action is PolicyAction.PASS:
                if (
                    p3_mandatory_reset_pending
                    or idle_readiness.readiness
                    is PassReadiness.PASS_FORBIDDEN_MANDATORY_ACTION
                ):
                    counters.wrong_third_pass += 1
                    guard.pause(automatic=True)
                    stop_reason = "WRONG_THIRD_PASS_BLOCKED"
                    _write(
                        log,
                        "pass_start_rejected",
                        reason=stop_reason,
                        readiness=idle_readiness,
                        p3MandatoryResetPending=p3_mandatory_reset_pending,
                        failClosed=True,
                    )
                    _beep("pause", not args.no_beep)
                    continue
                if pass_coordinator is None:
                    guard.pause(automatic=True)
                    stop_reason = "PASS_REQUIRED_BUT_DISABLED"
                    _write(log, "pass_required_but_disabled", **fields, autoPaused=True)
                    _beep("pause", not args.no_beep)
                    continue
                fresh_pass_poll = provider.poll()
                if hotkeys.emergency_stop_requested() or _farm_emergency_requested(
                    shared_runtime
                ):
                    guard.stop()
                    stop_reason = "EMERGENCY_STOP"
                    _write(log, "emergency_stop", key="F9", checkpoint="BEFORE_PASS_WAIT")
                    break
                fresh_pass = fresh_pass_poll.state
                if fresh_pass is None:
                    _write(
                        log,
                        "pass_start_rejected",
                        reason="FRESH_STATE_UNAVAILABLE",
                        **fields,
                    )
                    time.sleep(args.interval)
                    continue
                fresh_pass_readiness = idle_cache.pass_readiness(
                    current_session_id=_idle_session_id(
                        fresh_pass.battle.session_key
                    ),
                    local_username=fresh_pass.battle.local_username,
                    current_turn=fresh_pass.battle.turn_number,
                    is_local_turn=fresh_pass.battle.is_local_turn,
                    lifecycle_active=(
                        fresh_pass.battle.combat_lifecycle
                        is CombatLifecycleState.ACTIVE
                    ),
                    is_first_local_turn=fresh_pass.battle.is_first_local_turn,
                )
                fresh_pass = apply_idle_readiness_to_state(
                    fresh_pass, fresh_pass_readiness
                )
                fresh_pass_window = executor.window_status(binding)
                fresh_pass_gate = ActionabilityGate.evaluate(
                    fresh_pass,
                    GateContext(
                        provider.current_session_key,
                        fresh_pass_window.foreground,
                        fresh_pass_window.valid,
                        sequence_desync=monitor.tracker.state,
                        allow_authoritative_board_only_stats=True,
                    ),
                )
                fresh_basic_decision = policy.decide(fresh_pass)
                fresh_pass_decision = _acceptance_forced_pass_decision(
                    fresh_pass,
                    fresh_basic_decision,
                    pass_stage=pass_stage,
                    force_after_actions=args.acceptance_force_pass_after_actions,
                    accepted_consuming_actions=(
                        counters.swap_acknowledged + counters.cast_accepted
                    ),
                    pass_coordinator=pass_coordinator,
                    idle_readiness=fresh_pass_readiness,
                )
                if not fresh_pass_gate.actionable:
                    _write(
                        log,
                        "pass_start_rejected",
                        reason="FRESH_ACTIONABILITY_BLOCKED",
                        gate=fresh_pass_gate,
                    )
                    time.sleep(args.interval)
                    continue
                if (
                    fresh_pass_decision.action is not PolicyAction.PASS
                    or fresh_pass.dedup_key != state.dedup_key
                ):
                    _write(
                        log,
                        "pass_start_rejected",
                        reason="POLICY_OR_SOURCE_CHANGED_ON_FRESH_REREAD",
                        originalDecision=decision,
                        freshDecision=fresh_pass_decision,
                        originalSource=state.dedup_key,
                        freshSource=fresh_pass.dedup_key,
                    )
                    time.sleep(args.interval)
                    continue
                fresh_pass_turn_key = (
                    fresh_pass.battle.session_key,
                    int(fresh_pass.battle.turn_number),
                )
                if fresh_pass_turn_key in terminal_evolve_activity_turns:
                    terminal_evolve_activity_turns.discard(fresh_pass_turn_key)
                    evolve_only_turn_wait = EvolveOnlyTurnWait(
                        session=fresh_pass.battle.session_key,
                        match_id=fresh_pass.battle.match_id or "",
                        source_turn=int(fresh_pass.battle.turn_number),
                        source_srv_seq=int(fresh_pass.battle.srv_seq),
                        board_hash=fresh_pass.battle.board_hash or "",
                        source_local_move_sequence=(
                            fresh_pass.battle.local_move_sequence
                        ),
                        started_timestamp=utc_timestamp(),
                        gameplay_inputs_total=counters.input_actions_total,
                    )
                    counters.evolve_only_turn_waits += 1
                    _write(
                        log,
                        "evolve_only_turn_wait_started",
                        wait=evolve_only_turn_wait,
                        originalPolicyDecision=fresh_pass_decision,
                        idleState=idle_cache.state,
                        resetBaseline=idle_cache.reset_baseline,
                        countedAsIntentionalPass=False,
                        passCoordinatorUsed=False,
                        gameplayInputSent=False,
                        reason=(
                            "terminal EVOLVE attempt is user activity and the same-turn "
                            "PASS policy requires no additional input"
                        ),
                    )
                    continue
                if fresh_pass.dedup_key in pass_preflight_wait_sources:
                    # This exact board/turn already lost its optional local
                    # participant snapshot at the final PASS preflight.  Wait
                    # with zero input until the authoritative state changes;
                    # do not reserve or count an unproven PASS repeatedly.
                    time.sleep(args.interval)
                    continue
                counters.pass_required += 1
                farm_pass_ok, farm_pass_permit = _reserve_farm_gameplay(
                    runtime,
                    action=PolicyAction.PASS,
                    session=fresh_pass.battle.session_key,
                    foreground=(
                        fresh_pass_window.valid
                        and fresh_pass_window.foreground is True
                    ),
                )
                if not farm_pass_ok:
                    guard.stop()
                    stop_reason = "FARM_GAMEPLAY_CAPABILITY_DENIED"
                    _write(
                        log,
                        "farm_gameplay_capability_denied",
                        action="PASS",
                        session=fresh_pass.battle.session_key,
                        inputSent=False,
                    )
                    _beep("pause", not args.no_beep)
                    break
                board_only_pass_tracking = bool(
                    runtime.gameplay_capability is not None
                    and _farm_owned_board_only_pass_tracking_allowed(fresh_pass)
                )
                if board_only_pass_tracking:
                    _write(
                        log,
                        "pass_preflight_board_only_stats_tracking_allowed",
                        session=fresh_pass.battle.session_key,
                        turn=fresh_pass.battle.turn_number,
                        bossHp=next(
                            (
                                participant.hp
                                for participant in fresh_pass.opponents
                                if participant.is_boss
                            ),
                            None,
                        ),
                        boardProductionReady=fresh_pass.board.production_ready,
                        gameplayInputSent=False,
                        safetyBasis=(
                            "PASS executor is zero-input; lifecycle, local-turn, "
                            "live-boss and current ACK-attested board remain exact"
                        ),
                    )
                try:
                    pass_attempt = pass_coordinator.start(
                        session_id=_idle_session_id(
                            fresh_pass.battle.session_key
                        )
                        or "",
                        match_id=fresh_pass.battle.match_id or "",
                        local_username=fresh_pass.battle.local_username or "",
                        source_turn=int(fresh_pass.battle.turn_number),
                        source_srv_seq=int(fresh_pass.battle.srv_seq),
                        board_hash=fresh_pass.battle.board_hash or "",
                        policy_reason=fresh_pass_decision.trace.why_selected,
                        started_timestamp=utc_timestamp(),
                        turn_remaining=int(
                            fresh_pass.battle.turn_time_remaining_seconds
                        ),
                        idle_before=fresh_pass_readiness,
                        gameplay_inputs_total=counters.input_actions_total,
                        source_local_move_sequence=(
                            fresh_pass.battle.local_move_sequence
                        ),
                        lifecycle_active=True,
                        is_local_turn=fresh_pass.battle.is_local_turn is True,
                        is_first_local_turn=(
                            fresh_pass.battle.is_first_local_turn is True
                        ),
                        sequence_desync=(
                            monitor.tracker.state.terminal_for_session
                        ),
                        participants_alive=(
                            _participants_alive(fresh_pass)
                            or board_only_pass_tracking
                        ),
                        board_current_valid=bool(
                            fresh_pass.board.production_ready
                            and fresh_pass.battle.stable
                            and fresh_pass.battle.acknowledged
                            and fresh_pass.battle.latest
                        ),
                        policy_selected_pass=True,
                    )
                except (TypeError, ValueError) as exc:
                    if (
                        runtime.gameplay_capability is not None
                        and _transient_board_only_pass_participant_gap(
                            fresh_pass, exc
                        )
                    ):
                        abandoned = _abandon_farm_pass_preflight(
                            runtime,
                            farm_pass_permit,
                            detail=(
                                "transient board-only participant gap before "
                                f"PASS start: {exc}"
                            ),
                        )
                        if not abandoned:
                            guard.stop()
                            stop_reason = "FARM_GAMEPLAY_CAPABILITY_CANCELLED"
                            break
                        pass_preflight_wait_sources.add(fresh_pass.dedup_key)
                        counters.pass_aborted += 1
                        _write(
                            log,
                            "pass_preflight_deferred_board_only_stats",
                            detail=str(exc),
                            state=fresh_pass.dedup_key,
                            gameplayInputSent=False,
                            passCounted=False,
                            nextAction="wait_for_authoritative_state_change",
                        )
                        time.sleep(args.interval)
                        continue
                    _cancel_farm_gameplay(
                        runtime,
                        farm_pass_permit,
                        detail=f"PASS start rejected: {exc}",
                    )
                    guard.pause(automatic=True)
                    stop_reason = "PASS_START_VALIDATION_FAILED"
                    _write(
                        log,
                        "pass_start_rejected",
                        reason=stop_reason,
                        detail=str(exc),
                        readiness=fresh_pass_readiness,
                        state=fresh_pass.dedup_key,
                    )
                    _beep("pause", not args.no_beep)
                    if runtime.gameplay_capability is not None:
                        guard.stop()
                        stop_reason = "FARM_GAMEPLAY_CAPABILITY_CANCELLED"
                        break
                    continue
                if not _complete_farm_gameplay(
                    runtime,
                    farm_pass_permit,
                    sent=False,
                    detail="authoritative PASS wait started; Windows inputs=0",
                ):
                    guard.stop()
                    stop_reason = "FARM_GAMEPLAY_CAPABILITY_COMPLETION_FAILED"
                    _write(
                        log,
                        "farm_gameplay_capability_failed",
                        action="PASS",
                        inputSent=False,
                    )
                    _beep("pause", not args.no_beep)
                    break
                counters.auto_pass_started += 1
                _write(
                    log,
                    "pass_wait_started",
                    passAttempt=pass_attempt,
                    session=fresh_pass.battle.session_key,
                    matchId=fresh_pass.battle.match_id,
                    turn=fresh_pass.battle.turn_number,
                    srvSeq=fresh_pass.battle.srv_seq,
                    boardHash=fresh_pass.battle.board_hash,
                    currentTurnPlayer=fresh_pass.battle.current_turn_player,
                    idleBefore=fresh_pass_readiness,
                    policyReason=fresh_pass_decision.trace.why_selected,
                    legalMoveCount=analysis.legal_match_producing_moves,
                    safeMoveCount=analysis.safe_move_count,
                    passStartTimestamp=pass_attempt.started_timestamp,
                    turnRemaining=fresh_pass.battle.turn_time_remaining_seconds,
                    gameplayInputSent=False,
                )
                # PASS executor is intentionally empty. The coordinator lock
                # owns this local turn until turn-end + authoritative AFK data.
                continue
            if decision.action is PolicyAction.EXIT_MATCH or analysis.dead_board is True:
                counters.dead_board += 1
                stop_reason = "DEAD_BOARD_NO_REFRESH"
                guard.require_recovery()
                recovery.manual_test_required()
                artifact = _terminal_artifact(root=log_path.parent / "dead_board", event="DEAD_BOARD_NO_REFRESH", target=target, state=state, policy=policy)
                recovery_dispatched = _dispatch_technical_recovery(
                    runtime,
                    reason="DEAD_BOARD_NO_REFRESH",
                    state=state,
                    analysis=analysis,
                )
                _write(
                    log,
                    "recovery_required",
                    reason="DEAD_BOARD_NO_REFRESH",
                    artifact=artifact,
                    automaticExit=recovery_dispatched,
                    technicalRecoveryHandoff=recovery_dispatched,
                )
                _beep("recovery", not args.no_beep)
                continue
            if decision.action is PolicyAction.NONE:
                reason = _policy_none_stop_reason(
                    decision,
                    legal_move_count=analysis.legal_match_producing_moves,
                    safe_move_count=analysis.safe_move_count,
                )
                if reason == "POLICY_NO_SAFE_MOVE":
                    counters.policy_no_safe_move += 1
                else:
                    counters.undefined_policy += 1
                if _farm_owned_pass_unknown_can_wait_for_recovery(
                    reason=reason,
                    farm_owned=runtime.gameplay_capability is not None,
                    recovery_available=(
                        runtime.technical_recovery_dispatcher is not None
                    ),
                ):
                    _write(
                        log,
                        "farm_pass_state_unknown_waiting_for_bounded_recovery",
                        reason=reason,
                        session=state.battle.session_key,
                        turn=state.battle.turn_number,
                        remaining=state.battle.turn_time_remaining_seconds,
                        gameplayInputSent=False,
                        nextAction=(
                            "wait for authoritative state change or terminal "
                            "active-turn technical recovery gate"
                        ),
                    )
                    time.sleep(args.interval)
                    continue
                guard.pause(automatic=True)
                stop_reason = reason
                artifact = _terminal_artifact(root=log_path.parent / "policy_pause", event=reason, target=target, state=state, policy=policy)
                _write(log, "auto_pause", reason=reason, artifact=artifact, **fields)
                _beep("pause", not args.no_beep)
                continue

            if decision.action is PolicyAction.EVOLVE:
                if _b4_evolve_forbidden(
                    stage=pass_stage,
                    mana_priority=configured_mana_priority,
                    action=decision.action,
                ):
                    counters.attack_priority_evolve_violations += 1
                    guard.stop()
                    stop_reason = "B4_EVOLVE_FORBIDDEN"
                    _write(
                        log,
                        "b4_hard_assertion_failed",
                        reason=stop_reason,
                        checkpoint="BEFORE_ACTION_IDENTITY",
                        evolveInputs=counters.evolve_sent,
                        automaticInputDisabled=True,
                    )
                    _beep("pause", not args.no_beep)
                    break
                fusion_turn_key = (
                    state.battle.session_key,
                    int(state.battle.turn_number),
                )
                attempts_this_turn = fusion_attempts_by_turn.get(
                    fusion_turn_key, 0
                )
                if attempts_this_turn >= args.max_fusion_attempts_per_turn:
                    guard.pause(automatic=True)
                    stop_reason = "FUSION_RETRY_LIMIT"
                    _write(
                        log,
                        "auto_pause",
                        reason=stop_reason,
                        attemptsThisTurn=attempts_this_turn,
                        maxFusionAttemptsPerTurn=args.max_fusion_attempts_per_turn,
                        **fields,
                    )
                    _beep("pause", not args.no_beep)
                    continue

            identity = AutonomousActionIdentity.from_decision(state, decision, attempt=evolve_attempts + 1)
            if opening_fast_action_pending and active_session is not None:
                try:
                    _service, opening_fresh_runtime = read_match_runtime(target)
                    opening_fresh_state = _fresh_opening_handoff_state(
                        provider.last_published_state,
                        opening_fresh_runtime,
                        expected_session=active_session,
                    )
                except (OSError, RuntimeError, ValueError):
                    opening_fresh_state = None
                fresh_poll = (
                    ProviderPoll(
                        state=opening_fresh_state,
                        publish=True,
                        reason="proven_opening_direct_runtime_preflight",
                        confirmations=2,
                        session_key=active_session,
                    )
                    if opening_fresh_state is not None
                    else provider.poll()
                )
            else:
                fresh_poll = provider.poll()
            if hotkeys.emergency_stop_requested() or _farm_emergency_requested(
                shared_runtime
            ):
                aborted = guard.stop()
                stop_reason = "EMERGENCY_STOP"
                _write(log, "emergency_stop", key="F9", pending=aborted, checkpoint="AFTER_FRESH_POLL")
                break
            fresh = fresh_poll.state
            if fresh is not None:
                fresh_idle_readiness = idle_cache.pass_readiness(
                    current_session_id=_idle_session_id(fresh.battle.session_key),
                    local_username=fresh.battle.local_username,
                    current_turn=fresh.battle.turn_number,
                    is_local_turn=fresh.battle.is_local_turn,
                    lifecycle_active=(
                        fresh.battle.combat_lifecycle
                        is CombatLifecycleState.ACTIVE
                    ),
                    is_first_local_turn=fresh.battle.is_first_local_turn,
                )
                fresh = _retain_mandatory_consuming_action_requirement(
                    apply_idle_readiness_to_state(fresh, fresh_idle_readiness),
                    mandatory_reset_pending=p3_mandatory_reset_pending,
                )
            if fresh is None or not identity.source.matches(fresh):
                counters.expired_actions += 1
                if (
                    fresh is not None
                    and fresh.battle.session_key == identity.source.session
                ):
                    counters.user_state_changes += 1
                _write(log, "action_result", result=ActionResultKind.ACTION_ABORTED_STATE_CHANGED, identity=identity, freshState=fresh.dedup_key if fresh else None)
                time.sleep(args.interval)
                continue
            if not guard.reserve(identity):
                counters.duplicate_actions_blocked += 1
                _write(log, "action_duplicate_blocked", identity=identity)
                time.sleep(args.interval)
                continue
            _write(log, "action_identity_created", identity=identity)
            fresh_window = executor.window_status(binding)
            fresh_gate = ActionabilityGate.evaluate(
                fresh,
                GateContext(
                    provider.current_session_key,
                    fresh_window.foreground,
                    fresh_window.valid,
                    sequence_desync=monitor.tracker.state,
                    allow_opening_board_only=True,
                    allow_authoritative_board_only_stats=True,
                ),
            )
            if not fresh_gate.actionable:
                counters.expired_actions += 1
                _cancel_unsent(guard, identity)
                _write(log, "action_result", result=ActionResultKind.ACTION_ABORTED_STATE_CHANGED, identity=identity, gate=fresh_gate)
                time.sleep(args.interval)
                continue
            fresh_optional_turn_key = (
                (fresh.battle.session_key, int(fresh.battle.turn_number))
                if fresh.battle.session_key is not None
                and fresh.battle.turn_number is not None
                else None
            )
            fresh_suppressed_actions = frozenset(
                optional_card_suppressions.get(fresh_optional_turn_key, set())
                if fresh_optional_turn_key is not None
                else ()
            )
            if fresh_gate.details.get("openingBoardOnly") is True:
                fresh_suppressed_actions = fresh_suppressed_actions | frozenset(
                    {PolicyAction.EVOLVE, PolicyAction.CAST}
                )
            fresh_decision = policy.decide(
                _without_optional_card_actions(fresh, fresh_suppressed_actions)
            )
            if (
                fresh_decision.action is not decision.action
                or fresh_decision.move != decision.move
                or fresh_decision.card_object_address != decision.card_object_address
            ):
                counters.expired_actions += 1
                _cancel_unsent(guard, identity)
                _write(
                    log,
                    "action_result",
                    result=ActionResultKind.ACTION_ABORTED_STATE_CHANGED,
                    identity=identity,
                    reason="POLICY_CHANGED_ON_FRESH_REREAD",
                    originalDecision=decision,
                    freshDecision=fresh_decision,
                )
                time.sleep(args.interval)
                continue
            mandatory_recovery_warning = (
                _mandatory_reset_recovery_warning_seconds(
                    args.minimum_action_time
                )
            )
            if (
                runtime.technical_recovery_dispatcher is not None
                and _late_mandatory_reset_recovery_required(
                    pass_stage=pass_stage,
                    mandatory_reset_pending=p3_mandatory_reset_pending,
                    readiness=fresh_idle_readiness,
                    action=fresh_decision.action,
                    remaining_seconds=(
                        fresh.battle.turn_time_remaining_seconds
                    ),
                    warning_seconds=mandatory_recovery_warning,
                )
            ):
                _cancel_unsent(guard, identity)
                recovery_dispatched = _dispatch_technical_recovery(
                    runtime,
                    reason="LATE_MANDATORY_RESET",
                    state=fresh,
                    late_mandatory_reset_evidence={
                        "session_key": fresh.battle.session_key,
                        "match_id": fresh.battle.match_id,
                        "turn": int(fresh.battle.turn_number),
                        "remaining_seconds": int(
                            fresh.battle.turn_time_remaining_seconds
                        ),
                        "minimum_action_time": args.minimum_action_time,
                        "recovery_warning_seconds": (
                            mandatory_recovery_warning
                        ),
                        "selected_action": fresh_decision.action.value,
                        "mandatory_reset_pending": True,
                        "game_foreground": bool(fresh_window.foreground),
                        "window_valid": bool(fresh_window.valid),
                        "controller_running": (
                            guard.status is AutonomousStatus.RUNNING
                        ),
                        "pending_action": guard.pending is not None,
                        "consuming_action_sent": (
                            (
                                fresh.battle.session_key,
                                int(fresh.battle.turn_number),
                            )
                            in consuming_action_turns
                        ),
                        "authoritative_pass_wait_active": bool(
                            pass_coordinator is not None
                            and pass_coordinator.gameplay_locked
                        ),
                        "evolve_wait_active": (
                            evolve_only_turn_wait is not None
                        ),
                        "sequence_desync": monitor.tracker.state,
                    },
                )
                if recovery_dispatched:
                    guard.require_recovery()
                    stop_reason = "LATE_MANDATORY_RESET"
                    _write(
                        log,
                        "technical_recovery_handoff",
                        reason=stop_reason,
                        deadlineReason="LATE_AUTHORITATIVE_MANDATORY_RESET",
                        session=fresh.battle.session_key,
                        turn=fresh.battle.turn_number,
                        remaining=(
                            fresh.battle.turn_time_remaining_seconds
                        ),
                        minimumActionTime=args.minimum_action_time,
                        recoveryWarningSeconds=mandatory_recovery_warning,
                        authoritativeIdle=fresh_idle_readiness.state,
                        selectedAction=fresh_decision.action,
                        gameplayInputSent=False,
                        automaticUiOwnedByOuterCoordinator=True,
                    )
                    _beep("recovery", not args.no_beep)
                    break
                guard.stop()
                stop_reason = "LATE_MANDATORY_RESET_PREFLIGHT_REJECTED"
                _write(
                    log,
                    "farm_safe_stop_immediate",
                    reason=stop_reason,
                    session=fresh.battle.session_key,
                    turn=fresh.battle.turn_number,
                    remaining=fresh.battle.turn_time_remaining_seconds,
                    gameplayInputSent=False,
                    failClosed=True,
                )
                _beep("pause", not args.no_beep)
                break
            if fresh.battle.turn_time_remaining_seconds is None or fresh.battle.turn_time_remaining_seconds < args.minimum_action_time:
                counters.too_late += 1
                _cancel_unsent(guard, identity)
                _write(log, "action_result", result=ActionResultKind.ACTION_EXPIRED, identity=identity, reason="TOO_LATE_TO_ACT")
                time.sleep(args.interval)
                continue

            sent_at = time.monotonic()
            pending_action = PendingAutonomousAction(
                identity,
                sent_at,
                fresh.player.mana if fresh.player is not None else None,
                None,
                local_move_sequence_before=fresh.battle.local_move_sequence,
                last_move_sequence_before=fresh.battle.last_move_sequence,
                fusion_last_attempt_turn_before=(
                    fresh.fusion.last_attempt_turn if fresh.fusion is not None else None
                ),
                fusion_used_before=(
                    fresh.fusion.used if fresh.fusion is not None else None
                ),
                idle_state_before=idle_cache.state,
                reset_baseline_before=idle_cache.reset_baseline,
                mandatory_after_idle_2=bool(
                    pass_stage == "B5"
                    and p3_mandatory_reset_pending
                    and decision.action in {PolicyAction.SWAP, PolicyAction.CAST}
                ),
                response_deadline=sent_at + args.action_timeout,
            )
            if decision.action is PolicyAction.SWAP:
                if decision.move is None or fresh_window.geometry is None:
                    raise CoordinateSafetyError("SWAP decision has no complete coordinate source")
                turn_key = (fresh.battle.session_key, int(fresh.battle.turn_number))
                if turn_key in accepted_cast_turns:
                    counters.same_turn_swap_after_cast += 1
                    _cancel_unsent(guard, identity)
                    guard.stop()
                    stop_reason = "B4_SAME_TURN_SWAP_AFTER_CAST_BLOCKED"
                    _write(
                        log,
                        "b4_hard_assertion_failed",
                        reason=stop_reason,
                        identity=identity,
                        automaticInputDisabled=True,
                    )
                    _beep("pause", not args.no_beep)
                    break
                if not consuming_turns.reserve(*turn_key):
                    counters.wrong_turn_actions_blocked += 1
                    _cancel_unsent(guard, identity)
                    guard.pause(automatic=True)
                    _write(log, "action_result", result=ActionResultKind.ACTION_ABORTED_STATE_CHANGED, reason="CONSUMING_ACTION_ALREADY_SENT_THIS_TURN")
                    continue
                capture = capture_client_rgb(target.pid)
                leave_modal = locate_confirm_leave(
                    capture.rgb, capture.width, capture.height
                )
                if leave_modal.found:
                    _cancel_unsent(guard, identity, consuming_turns=consuming_turns)
                    guard.pause(automatic=True)
                    _write(
                        log,
                        "action_result",
                        result=ActionResultKind.ACTION_ABORTED_STATE_CHANGED,
                        reason="LEAVE_MODAL_VISIBLE_BEFORE_GAMEPLAY_CLICK",
                        modal=leave_modal,
                        autoPaused=True,
                    )
                    continue
                plan = map_swap_to_pixels(decision.move.first, decision.move.second, calibration, fresh_window.geometry, virtual_screen=backend.virtual_screen())
                if hotkeys.emergency_stop_requested() or _farm_emergency_requested(
                    shared_runtime
                ):
                    guard.stop()
                    stop_reason = "EMERGENCY_STOP"
                    _write(log, "emergency_stop", key="F9", checkpoint="BEFORE_SWAP_INPUT")
                    break
                if hotkeys.pause_toggle_requested():
                    _cancel_unsent(guard, identity, consuming_turns=consuming_turns)
                    guard.pause(automatic=False)
                    _write(log, "user_pause", key="F7", checkpoint="BEFORE_SWAP_INPUT", staleProposalRetained=False)
                    _beep("pause", not args.no_beep)
                    continue
                farm_window = executor.window_status(binding)
                farm_swap_ok, farm_swap_permit = _reserve_farm_gameplay(
                    runtime,
                    action=PolicyAction.SWAP,
                    session=fresh.battle.session_key,
                    foreground=farm_window.valid and farm_window.foreground is True,
                )
                if not farm_swap_ok:
                    _cancel_unsent(guard, identity, consuming_turns=consuming_turns)
                    guard.stop()
                    stop_reason = "FARM_GAMEPLAY_CAPABILITY_DENIED"
                    _write(
                        log,
                        "farm_gameplay_capability_denied",
                        action="SWAP",
                        session=fresh.battle.session_key,
                        inputSent=False,
                    )
                    _beep("pause", not args.no_beep)
                    break
                try:
                    _service, pre_input_runtime = read_match_runtime(target)
                    pre_input_failure = direct_runtime_swap_preflight_failure(
                        pending_action,
                        match_id=pre_input_runtime.match_id,
                        turn=pre_input_runtime.turn,
                        current_player=pre_input_runtime.current_player,
                        local_username=pre_input_runtime.local_username,
                        remaining_seconds=pre_input_runtime.remaining,
                        local_move_sequence=(
                            pre_input_runtime.local_move_sequence
                        ),
                        minimum_action_time=args.minimum_action_time,
                    )
                except (OSError, RuntimeError, ValueError) as exc:
                    pre_input_runtime = None
                    pre_input_failure = (
                        f"DIRECT_RUNTIME_READ_FAILED:{type(exc).__name__}"
                    )
                if pre_input_failure is not None:
                    counters.expired_actions += 1
                    if pre_input_failure in {
                        "TIMER_UNKNOWN",
                        "TIMER_AT_OR_BELOW_ACTION_FLOOR",
                    }:
                        counters.too_late += 1
                    abandoned = _abandon_farm_gameplay_preflight(
                        runtime,
                        farm_swap_permit,
                        detail=(
                            "SWAP final direct-runtime preflight rejected: "
                            f"{pre_input_failure}"
                        ),
                    )
                    _cancel_unsent(
                        guard,
                        identity,
                        consuming_turns=consuming_turns,
                    )
                    _write(
                        log,
                        "action_result",
                        result=ActionResultKind.ACTION_ABORTED_STATE_CHANGED,
                        identity=identity,
                        reason="FINAL_SWAP_DIRECT_RUNTIME_PREFLIGHT_REJECTED",
                        preflightFailure=pre_input_failure,
                        directRuntime=pre_input_runtime,
                        inputSent=False,
                        farmPermitReleased=abandoned,
                    )
                    if runtime.gameplay_capability is not None and not abandoned:
                        guard.stop()
                        stop_reason = "FARM_GAMEPLAY_CAPABILITY_CANCELLED"
                        break
                    time.sleep(args.interval)
                    continue
                actual_send_start = time.monotonic()
                pending_action.sent_at = actual_send_start
                pending_action.response_deadline = (
                    actual_send_start + args.action_timeout
                )
                try:
                    input_authorized, click = _execute_farm_gameplay_input(
                        runtime,
                        lambda: executor.send_swap(
                            binding,
                            plan,
                            remaining_seconds=(
                                fresh.battle.turn_time_remaining_seconds
                            ),
                        ),
                    )
                except Exception:
                    _cancel_farm_gameplay(
                        runtime,
                        farm_swap_permit,
                        detail="SWAP executor raised before result",
                    )
                    raise
                if not input_authorized or click is None:
                    guard.stop()
                    stop_reason = "EMERGENCY_STOP"
                    _write(
                        log,
                        "emergency_stop",
                        key="UI",
                        checkpoint="ATOMIC_SWAP_INPUT_GATE",
                        inputSent=False,
                    )
                    break
                if not _complete_farm_gameplay(
                    runtime,
                    farm_swap_permit,
                    sent=click.sent_clicks > 0,
                    detail=(
                        f"SWAP:{click.status.value};sentClicks={click.sent_clicks};"
                        f"interClickDelay={click.inter_click_delay_seconds};"
                        f"cursorSettle={click.cursor_settle_seconds};"
                        f"buttonHold={click.mouse_button_hold_seconds};"
                        f"inputMode={click.input_mode};"
                        f"dragDuration={click.drag_duration_seconds};"
                        f"dragSteps={click.drag_steps};"
                        f"dragOvershootPixels={click.drag_overshoot_pixels};"
                        f"pacing={click.pacing_mode}"
                    ),
                ):
                    guard.stop()
                    stop_reason = "FARM_GAMEPLAY_CAPABILITY_COMPLETION_FAILED"
                    _beep("pause", not args.no_beep)
                    break
                if not click.sent:
                    if click.sent_clicks > 0:
                        # One physical click reached the game. Permanently
                        # consume the identity and total-input budget; never
                        # let a later loop retry this partial input.
                        guard.begin(pending_action)
                        guard.complete_pending()
                        _record_sent_input_safety(counters, fresh)
                        counters.input_actions_total += 1
                        counters.partial_inputs += 1
                        counters.swap_rejected += 1
                        if pending_action.mandatory_after_idle_2:
                            counters.mandatory_swap_rejected += 1
                            mandatory_action_records.append(
                                {
                                    "action": "SWAP",
                                    "result": "PARTIAL_INPUT",
                                    "identity": identity,
                                    "resetEvidence": None,
                                    "resetStatus": "RESET_NOT_ESTABLISHED",
                                }
                            )
                    else:
                        _cancel_unsent(
                            guard,
                            identity,
                            consuming_turns=consuming_turns,
                        )
                    guard.pause(automatic=True)
                    _write(
                        log,
                        "action_result",
                        result=ActionResultKind.SWAP_REJECTED,
                        action=pending_action if click.sent_clicks > 0 else None,
                        identity=identity,
                        reason=click.status,
                        sentClicks=click.sent_clicks,
                        interClickDelaySeconds=(
                            click.inter_click_delay_seconds
                        ),
                        cursorSettleSeconds=click.cursor_settle_seconds,
                        mouseButtonHoldSeconds=(
                            click.mouse_button_hold_seconds
                        ),
                        inputPacingMode=click.pacing_mode,
                        inputPacingReason=click.pacing_reason,
                        inputLagScore=click.lag_score,
                        inputMode=click.input_mode,
                        dragDurationSeconds=click.drag_duration_seconds,
                        dragSteps=click.drag_steps,
                        dragOvershootPixels=click.drag_overshoot_pixels,
                        autoPaused=True,
                    )
                    continue
                guard.begin(pending_action)
                turn_transitions.begin(identity)
                fast_transition_deadline = time.monotonic() + args.action_timeout
                consuming_action_turns.add(turn_key)
                opening_fast_action_pending = False
                _record_sent_input_safety(counters, fresh)
                counters.swap_sent += 1
                if pending_action.mandatory_after_idle_2:
                    counters.mandatory_swap_sent += 1
                counters.swap_actions += 1
                counters.input_actions_total += 1
                counters.turn_consuming_actions_total += 1
                _write(
                    log,
                    "action_sent",
                    action="SWAP",
                    identity=identity,
                    sentClicks=click.sent_clicks,
                    plan=plan,
                    interClickDelaySeconds=click.inter_click_delay_seconds,
                    cursorSettleSeconds=click.cursor_settle_seconds,
                    mouseButtonHoldSeconds=click.mouse_button_hold_seconds,
                    inputPacingMode=click.pacing_mode,
                    inputPacingReason=click.pacing_reason,
                    inputLagScore=click.lag_score,
                    inputMode=click.input_mode,
                    dragDurationSeconds=click.drag_duration_seconds,
                    dragSteps=click.drag_steps,
                    dragOvershootPixels=click.drag_overshoot_pixels,
                    **fields,
                )
            else:
                control = GameplayControl.EVOLVE if decision.action is PolicyAction.EVOLVE else GameplayControl.CAST_ATTACK
                card = None
                if decision.action is PolicyAction.EVOLVE:
                    fusion = fresh.fusion
                    if (
                        fusion is None
                        or not fusion.interaction_authorized
                        or fusion.ui_slot is None
                        or fusion.ui_slot_count is None
                    ):
                        _cancel_unsent(guard, identity)
                        if fresh_optional_turn_key is not None:
                            optional_card_suppressions.setdefault(
                                fresh_optional_turn_key, set()
                            ).add(PolicyAction.EVOLVE)
                        _write(
                            log,
                            "optional_card_action_skipped",
                            action="EVOLVE",
                            reason="FUSION_RUNTIME_AUTHORITY_OR_SLOT_NOT_PROVEN",
                            boardOnlyFallback=True,
                        )
                        continue
                    slot_index = fusion.ui_slot
                    slot_count = fusion.ui_slot_count
                else:
                    card = next((value for value in fresh.cards if value.object_address == decision.card_object_address), None)
                    if (
                        card is None
                        or not card.is_attack
                        or not card.interactable
                        or card.action_pending
                        or card.has_used_this_turn
                        or card.ui_slot is None
                        or card.ui_slot_count is None
                    ):
                        _cancel_unsent(guard, identity)
                        if fresh_optional_turn_key is not None:
                            optional_card_suppressions.setdefault(
                                fresh_optional_turn_key, set()
                            ).add(PolicyAction.CAST)
                        _write(
                            log,
                            "optional_card_action_skipped",
                            action="CAST",
                            reason="ATTACK_CARD_OR_RUNTIME_SLOT_NOT_PROVEN",
                            boardOnlyFallback=True,
                        )
                        continue
                    slot_index = card.ui_slot
                    slot_count = card.ui_slot_count
                capture = capture_client_rgb(target.pid)
                leave_modal = locate_confirm_leave(
                    capture.rgb, capture.width, capture.height
                )
                if leave_modal.found:
                    _cancel_unsent(guard, identity)
                    guard.pause(automatic=True)
                    _write(
                        log,
                        "action_result",
                        result=ActionResultKind.ACTION_ABORTED_STATE_CHANGED,
                        reason="LEAVE_MODAL_VISIBLE_BEFORE_GAMEPLAY_CLICK",
                        modal=leave_modal,
                        autoPaused=True,
                    )
                    continue
                locator = locate_gameplay_control(
                    capture.rgb,
                    capture.width,
                    capture.height,
                    control,
                    slot_index=slot_index,
                    slot_count=slot_count,
                )
                if not locator.found or locator.normalized_point is None:
                    _cancel_unsent(guard, identity)
                    if fresh_optional_turn_key is not None:
                        optional_card_suppressions.setdefault(
                            fresh_optional_turn_key, set()
                        ).add(decision.action)
                    _write(
                        log,
                        "optional_card_action_skipped",
                        action=(
                            "EVOLVE"
                            if decision.action is PolicyAction.EVOLVE
                            else "CAST"
                        ),
                        reason="UI_CONTROL_NOT_CONFIDENT",
                        locator=locator,
                        boardOnlyFallback=True,
                        autoPaused=False,
                    )
                    continue
                if decision.action is PolicyAction.EVOLVE:
                    fusion = fresh.fusion
                    if fusion.mana_cost is None or fusion.mana_cost <= 0:
                        _cancel_unsent(guard, identity)
                        guard.pause(automatic=True)
                        _write(
                            log,
                            "action_result",
                            result=ActionResultKind.ACTION_ABORTED_STATE_CHANGED,
                            identity=identity,
                            reason="FUSION_ACTUAL_COST_NOT_PROVEN",
                            autoPaused=True,
                        )
                        continue
                    pending_action.mana_cost = fusion.mana_cost
                else:
                    if card is None:  # pragma: no cover - narrowed above
                        raise AssertionError("validated Attack card disappeared")
                    turn_key = (fresh.battle.session_key, int(fresh.battle.turn_number))
                    if not consuming_turns.reserve(*turn_key):
                        counters.wrong_turn_actions_blocked += 1
                        _cancel_unsent(guard, identity)
                        guard.pause(automatic=True)
                        _write(log, "action_result", result=ActionResultKind.ACTION_ABORTED_STATE_CHANGED, reason="CONSUMING_ACTION_ALREADY_SENT_THIS_TURN")
                        continue
                    attack_cost, attack_cost_source = _attack_cost_evidence(card)
                    if (
                        fresh.player is None
                        or fresh.player.mana is None
                        or fresh.player.mana < attack_cost
                    ):
                        _cancel_unsent(
                            guard, identity, consuming_turns=consuming_turns
                        )
                        guard.pause(automatic=True)
                        _write(
                            log,
                            "action_result",
                            result=ActionResultKind.ACTION_ABORTED_STATE_CHANGED,
                            identity=identity,
                            reason="ATTACK_CARD_INSUFFICIENT_CURRENT_MANA",
                            mana=(
                                fresh.player.mana
                                if fresh.player is not None
                                else None
                            ),
                            actualCost=attack_cost,
                            autoPaused=True,
                        )
                        continue
                    pending_action.mana_cost = attack_cost
                    pending_action.card_id = card.card_id
                    pending_action.card_object_address = card.object_address
                    pending_action.card_last_turn_used = card.last_turn_used
                    pending_action.card_name = card.name
                    pending_action.card_element_type = card.element_type
                    pending_action.card_cost_source = attack_cost_source
                    pending_action.card_interaction_authority = (
                        card.interaction_authority
                    )
                    pending_action.card_interactable_before = card.interactable
                    pending_action.card_has_used_this_turn_before = (
                        card.has_used_this_turn
                    )
                if hotkeys.emergency_stop_requested() or _farm_emergency_requested(
                    shared_runtime
                ):
                    guard.stop()
                    stop_reason = "EMERGENCY_STOP"
                    _write(log, "emergency_stop", key="F9", checkpoint="BEFORE_CARD_INPUT")
                    break
                if hotkeys.pause_toggle_requested():
                    _cancel_unsent(guard, identity, consuming_turns=consuming_turns)
                    guard.pause(automatic=False)
                    _write(log, "user_pause", key="F7", checkpoint="BEFORE_CARD_INPUT", staleProposalRetained=False)
                    _beep("pause", not args.no_beep)
                    continue
                farm_window = executor.window_status(binding)
                farm_card_ok, farm_card_permit = _reserve_farm_gameplay(
                    runtime,
                    action=decision.action,
                    session=fresh.battle.session_key,
                    foreground=farm_window.valid and farm_window.foreground is True,
                )
                if not farm_card_ok:
                    _cancel_unsent(guard, identity, consuming_turns=consuming_turns)
                    guard.stop()
                    stop_reason = "FARM_GAMEPLAY_CAPABILITY_DENIED"
                    _write(
                        log,
                        "farm_gameplay_capability_denied",
                        action=decision.action,
                        session=fresh.battle.session_key,
                        inputSent=False,
                    )
                    _beep("pause", not args.no_beep)
                    break
                try:
                    input_authorized, click = _execute_farm_gameplay_input(
                        runtime,
                        lambda: executor.send_normalized_point(
                            binding, locator.normalized_point
                        ),
                    )
                except Exception:
                    _cancel_farm_gameplay(
                        runtime,
                        farm_card_permit,
                        detail=f"{decision.action.value} executor raised before result",
                    )
                    raise
                if not input_authorized or click is None:
                    guard.stop()
                    stop_reason = "EMERGENCY_STOP"
                    _write(
                        log,
                        "emergency_stop",
                        key="UI",
                        checkpoint="ATOMIC_CARD_INPUT_GATE",
                        inputSent=False,
                    )
                    break
                if not _complete_farm_gameplay(
                    runtime,
                    farm_card_permit,
                    sent=click.sent,
                    detail=f"{decision.action.value}:{click.status.value}",
                ):
                    guard.stop()
                    stop_reason = "FARM_GAMEPLAY_CAPABILITY_COMPLETION_FAILED"
                    _beep("pause", not args.no_beep)
                    break
                if not click.sent:
                    _cancel_unsent(guard, identity, consuming_turns=consuming_turns)
                    guard.pause(automatic=True)
                    _write(log, "action_result", result=ActionResultKind.ACTION_ABORTED_STATE_CHANGED, reason=click.status, autoPaused=True)
                    continue
                # Any successful card click invalidates the pristine-opening
                # handoff.  EVOLVE does not consume the turn, but it can alter
                # fusion/player state; the next decision therefore requires a
                # normal authoritative provider publication.  CAST consumes
                # the turn and must likewise never reuse the opening snapshot.
                opening_fast_action_pending = False
                guard.begin(pending_action)
                _record_sent_input_safety(counters, fresh)
                if decision.action is PolicyAction.EVOLVE:
                    evolve_attempts += 1
                    counters.evolve_sent += 1
                    counters.evolve_attempts += 1
                    counters.input_actions_total += 1
                    fusion_turn_key = (
                        fresh.battle.session_key,
                        int(fresh.battle.turn_number),
                    )
                    fusion_attempts_by_turn[fusion_turn_key] = (
                        fusion_attempts_by_turn.get(fusion_turn_key, 0) + 1
                    )
                    _write(log, "action_sent", action="EVOLVE", identity=identity, attemptIndex=evolve_attempts, mana=fresh.player.mana if fresh.player else None, manaCost=pending_action.mana_cost, locator=locator, **fields)
                else:
                    counters.cast_sent += 1
                    if pending_action.mandatory_after_idle_2:
                        counters.mandatory_cast_sent += 1
                    turn_transitions.begin(identity)
                    fast_transition_deadline = time.monotonic() + args.action_timeout
                    consuming_action_turns.add(turn_key)
                    counters.cast_actions += 1
                    counters.input_actions_total += 1
                    counters.turn_consuming_actions_total += 1
                    _write(
                        log,
                        "action_sent",
                        action="CAST",
                        identity=identity,
                        card=card,
                        manaBefore=fresh.player.mana if fresh.player else None,
                        manaCost=pending_action.mana_cost,
                        manaCostSource=pending_action.card_cost_source,
                        idleBefore=pending_action.idle_state_before,
                        resetBaselineBefore=pending_action.reset_baseline_before,
                        locator=locator,
                        waitState="WAIT_CARD_RESPONSE",
                        **fields,
                    )

            time.sleep(args.interval)

        if guard.pending is not None:
            abandoned = guard.stop()
            _write(
                log,
                "action_result",
                result=ActionResultKind.ACTION_ABORTED_STATE_CHANGED,
                action=abandoned,
                reason="CONTROLLER_OR_PROCESS_STOPPED",
            )
        _write(
            log,
            "auto_controller_summary",
            counters=counters,
            stopReason=stop_reason,
            attemptClassification=_attempt_classification(
                stop_reason,
                counters,
                pass_stage=pass_stage,
            ),
            passCycleCoverage=_pass_cycle_coverage(counters),
            fullCombatResult=full_combat_result,
            terminalCombatSnapshot=terminal_combat_snapshot,
            providerMetrics=provider.metrics,
            swapInputPacing=executor.swap_pacer.decision(),
            localTurnsObserved=counters.local_turns_observed,
            bossTurnsObserved=counters.boss_turns_observed,
            totalInputs=counters.input_actions_total,
            turnConsumingActions=counters.turn_consuming_actions_total,
            policyBranchCoverage=counters.policy_branches,
            configuredManaPriority=configured_mana_priority,
            b4CastAcceptanceRecords=b4_cast_acceptance_records,
            castProposals=counters.cast_proposals,
            castInputs=counters.cast_sent,
            castAccepted=counters.cast_accepted,
            castRejected=counters.cast_rejected,
            sameTurnSwapAfterCast=counters.same_turn_swap_after_cast,
            evolveProposals=counters.evolve_proposals,
            evolveInputs=counters.evolve_sent,
            attackPriorityEvolveViolations=(
                counters.attack_priority_evolve_violations
            ),
            actionAbortedDueLifecycle=counters.action_aborted_due_lifecycle,
            swapAbortedDueLifecycle=counters.swap_aborted_due_lifecycle,
            localTurnDeadlineSafeStops=counters.local_turn_deadline_safe_stops,
            safetyTelemetry={
                "duplicate": counters.duplicate_inputs,
                "misclick": counters.misclicks,
                "partialInput": counters.partial_inputs,
                "wrongTurn": counters.wrong_turn_inputs,
                "staleAction": counters.stale_actions,
                "bossTurnInput": counters.boss_turn_inputs,
                "postmatchInput": counters.postmatch_inputs,
                "lobbyInput": counters.lobby_inputs,
                "inputAfterCombat": counters.input_after_combat,
            },
            lifecycleTimeline=lifecycle_timeline,
            sessionCleared=session_cleared,
            activeSession=active_session,
            status=guard.status,
            pending=guard.pending,
            executedIdentities=guard.executed_count,
            automaticPass=pass_stage != "DISABLED",
            passAcceptanceStage=pass_stage,
            authoritativePassMode=(
                "PRODUCTION" if pass_stage in {"B3", "B4", "B5"} else pass_stage
            ),
            acceptanceForcedPassEnabled=(
                args.acceptance_force_pass_after_actions > 0
            ),
            passCoordinator=(
                {
                    "state": pass_coordinator.state,
                    "confirmedPasses": pass_coordinator.confirmed_passes,
                    "terminal": pass_coordinator.terminal,
                }
                if pass_coordinator is not None
                else None
            ),
            latestIdleState=idle_cache.state,
            resetBaseline=idle_cache.reset_baseline,
            swapResetCapability=idle_cache.reset_capability(
                AcceptedActivityKind.SWAP
            ),
            castResetCapability=idle_cache.reset_capability(
                AcceptedActivityKind.CAST
            ),
            castResetConfidence=_reported_cast_reset_confidence(
                tuple(key[-1] for key in correlated_cast_resets),
                idle_cache.reset_capability(AcceptedActivityKind.CAST),
            ),
            castResetCorrelations=counters.cast_reset_correlations,
            passProposals=counters.pass_required,
            passExecuted=counters.auto_pass_started,
            evolveOnlyTurnWaits=counters.evolve_only_turn_waits,
            evolveOnlyTurnsCompleted=counters.evolve_only_turns_completed,
            evolveOnlyAuthoritativeIdleEvents=(
                counters.evolve_only_authoritative_idle_events
            ),
            authoritativeIdle1Count=counters.pass_confirmed_idle_1,
            authoritativeIdle2Count=counters.pass_confirmed_idle_2,
            passResetCyclesConfirmed=counters.pass_reset_cycles_confirmed,
            passAfterResetReturnedIdle1=(
                counters.pass_after_reset_idle_1 > 0
            ),
            thirdPassCount=counters.wrong_third_pass,
            localFakeIdleIncrementCount=0,
            mandatoryActionCount=counters.mandatory_reset_actions,
            mandatoryActionRequiredCount=counters.mandatory_actions_required,
            mandatoryActionResults=mandatory_action_records,
            mandatoryResetUnknown=counters.mandatory_reset_unknown,
            mandatorySwap={
                "sent": counters.mandatory_swap_sent,
                "acknowledged": counters.mandatory_swap_acknowledged,
                "rejected": counters.mandatory_swap_rejected,
            },
            mandatoryCast={
                "sent": counters.mandatory_cast_sent,
                "accepted": counters.mandatory_cast_accepted,
                "rejected": counters.mandatory_cast_rejected,
            },
            passGameplayInputCount=counters.pass_gameplay_inputs,
            wrongThirdPassCount=counters.wrong_third_pass,
            automaticExit=False,
            automaticReentry=False,
            memoryWrites=False,
            directGameCalls=False,
            networkManipulation=False,
        )
        print(f"Stage {stage_name.upper()} controller stopped ({stop_reason}); log: {log_path}", flush=True)
        return 0


def main(argv: Sequence[str] | None = None) -> int:
    args = build_parser().parse_args(argv)
    try:
        with AutomationControllerLease(current_app_paths().controller_lock):
            return run(args)
    except KeyboardInterrupt:
        print("Ctrl+C emergency stop received.")
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
        fatal_log = _persist_fatal_controller_error(args, exc)
        _beep("pause", not args.no_beep)
        print(f"ERROR: {exc}", file=sys.stderr)
        if fatal_log is not None:
            print(f"Fatal controller evidence: {fatal_log}", file=sys.stderr)
        return 1
    except Exception as exc:  # noqa: BLE001 - controller must fail closed and log
        fatal_log = _persist_fatal_controller_error(args, exc)
        _beep("pause", not args.no_beep)
        print(
            f"UNEXPECTED CONTROLLER ERROR ({type(exc).__name__}): {exc}",
            file=sys.stderr,
        )
        if fatal_log is not None:
            print(f"Fatal controller evidence: {fatal_log}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
