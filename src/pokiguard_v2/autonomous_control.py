"""Pure state machine primitives for the Phase 2C.2B BASIC subset."""

from __future__ import annotations

from dataclasses import dataclass
from enum import Enum
import hashlib
from typing import Any

from .basic_policy import PolicyAction, PolicyDecision
from .state import CombatSessionKey, GameState


class AutonomousStatus(str, Enum):
    WAITING_FOR_COMBAT = "WAITING_FOR_COMBAT"
    RUNNING = "RUNNING"
    INPUT_LOCKED = "INPUT_LOCKED"
    PAUSED_BY_USER = "PAUSED_BY_USER"
    AUTO_PAUSED = "AUTO_PAUSED"
    RECOVERY_REQUIRED = "RECOVERY_REQUIRED"
    STOPPED = "STOPPED"


class ActionResultKind(str, Enum):
    EVOLVE_SUCCESS = "EVOLVE_SUCCESS"
    EVOLVE_FAILED = "EVOLVE_FAILED"
    SWAP_ACKNOWLEDGED = "SWAP_ACKNOWLEDGED"
    SWAP_REJECTED = "SWAP_REJECTED"
    CAST_ACCEPTED = "CAST_ACCEPTED"
    CAST_REJECTED = "CAST_REJECTED"
    SEQUENCE_DESYNC = "SEQUENCE_DESYNC"
    ACTION_EXPIRED = "ACTION_EXPIRED"
    ACTION_OUTCOME_UNCONFIRMED = "ACTION_OUTCOME_UNCONFIRMED"
    ACTION_ABORTED_STATE_CHANGED = "ACTION_ABORTED_STATE_CHANGED"


class SwapAcceptanceStatus(str, Enum):
    """Strength of evidence observed after one physical SWAP input."""

    WAITING = "WAITING"
    EXACT_RUNTIME_ACCEPTED = "EXACT_RUNTIME_ACCEPTED"
    SEQUENCE_ADVANCED_UNATTRIBUTED = "SEQUENCE_ADVANCED_UNATTRIBUTED"


def _critical_state_fingerprint(state: GameState) -> str:
    """Hash gameplay-relevant state while deliberately excluding timer ticks."""

    battle = state.battle
    critical = (
        state.player,
        state.opponents,
        state.cards,
        state.fusion,
        battle.local_move_sequence,
        battle.last_move_sequence,
        battle.is_board_ready,
        battle.is_cascade_running,
        battle.board_current_state,
        battle.board_has_destroyed_this_turn,
        battle.board_is_processing_ui,
        battle.board_is_game_over,
        battle.board_modal_open,
        battle.match_over,
        battle.deferred_game_over,
        battle.connection_ready,
        battle.reconnecting,
        battle.match_resyncing,
        battle.presentation_busy,
        battle.client_move_allowed,
    )
    return hashlib.sha256(repr(critical).encode("utf-8")).hexdigest()


@dataclass(frozen=True)
class AutonomousSource:
    session: CombatSessionKey
    srv_seq: int
    board_hash: str
    turn: int
    current_turn_player: str
    critical_state_hash: str

    @classmethod
    def from_state(cls, state: GameState) -> "AutonomousSource":
        battle = state.battle
        if (
            battle.session_key is None
            or battle.srv_seq is None
            or battle.board_hash is None
            or battle.turn_number is None
            or battle.current_turn_player is None
        ):
            raise ValueError("autonomous action source is incomplete")
        return cls(
            battle.session_key,
            battle.srv_seq,
            battle.board_hash,
            battle.turn_number,
            battle.current_turn_player,
            _critical_state_fingerprint(state),
        )

    def matches(self, state: GameState) -> bool:
        battle = state.battle
        return bool(
            battle.session_key == self.session
            and battle.srv_seq == self.srv_seq
            and battle.board_hash == self.board_hash
            and battle.turn_number == self.turn
            and battle.current_turn_player == self.current_turn_player
            and _critical_state_fingerprint(state) == self.critical_state_hash
        )


@dataclass(frozen=True)
class AutonomousActionIdentity:
    source: AutonomousSource
    action: PolicyAction
    target: tuple[Any, ...]

    @classmethod
    def from_decision(
        cls, state: GameState, decision: PolicyDecision, *, attempt: int = 0
    ) -> "AutonomousActionIdentity":
        if decision.action is PolicyAction.SWAP and decision.move is not None:
            target: tuple[Any, ...] = (
                decision.move.first,
                decision.move.second,
            )
        elif decision.action is PolicyAction.CAST:
            target = (decision.card_object_address,)
        elif decision.action is PolicyAction.EVOLVE:
            fusion = state.fusion
            target = (
                fusion.ui_address if fusion is not None else None,
                fusion.last_attempt_turn if fusion is not None else None,
                attempt,
            )
        else:
            target = ()
        return cls(AutonomousSource.from_state(state), decision.action, target)


@dataclass
class PendingAutonomousAction:
    identity: AutonomousActionIdentity
    sent_at: float
    mana_before: int | None
    mana_cost: int | None
    card_last_turn_used: int | None = None
    card_id: int | None = None
    card_object_address: int | None = None
    card_name: str | None = None
    card_element_type: str | None = None
    card_cost_source: str | None = None
    card_interaction_authority: str | None = None
    card_interactable_before: bool | None = None
    card_has_used_this_turn_before: bool | None = None
    local_move_sequence_before: int | None = None
    last_move_sequence_before: int | None = None
    fusion_last_attempt_turn_before: int | None = None
    fusion_used_before: bool | None = None
    server_response_seen: bool = False
    response_success: bool | None = None
    response_evidence: Any | None = None
    consuming_transition_seen: bool = False
    consuming_transition_evidence: Any | None = None
    idle_state_before: Any | None = None
    reset_baseline_before: Any | None = None
    mandatory_after_idle_2: bool = False
    response_deadline: float | None = None
    response_wait_extensions: int = 0

    @property
    def consumes_turn(self) -> bool:
        return self.identity.action in {PolicyAction.SWAP, PolicyAction.CAST}


@dataclass(frozen=True)
class ActionResponseWaitPlan:
    """A bounded read-only retry plan for an action whose ACK is late.

    This never authorizes a second click.  Re-sending an input while the first
    one may already be in the server pipeline can duplicate a CAST or corrupt a
    SWAP.  The only safe retry is a short additional observation window while
    the exact source turn is still local and has enough time remaining.
    """

    extend_observation: bool
    extension_seconds: float = 0.0
    reason: str = "RELEASE_AS_UNCONFIRMED"


def plan_action_response_wait(
    pending: PendingAutonomousAction,
    *,
    session: CombatSessionKey | None,
    turn: int | None,
    is_local_turn: bool | None,
    remaining_seconds: float | int | None,
    minimum_action_time: float,
    max_extensions: int = 1,
    maximum_extension_seconds: float = 2.0,
) -> ActionResponseWaitPlan:
    """Choose one fail-closed response-observation retry, never an input retry."""

    if pending.response_wait_extensions >= max_extensions:
        return ActionResponseWaitPlan(False, reason="EXTENSION_LIMIT_REACHED")
    if (
        session != pending.identity.source.session
        or turn != pending.identity.source.turn
        or is_local_turn is not True
        or remaining_seconds is None
    ):
        return ActionResponseWaitPlan(False, reason="SOURCE_TURN_NOT_FRESH_LOCAL")
    spare = float(remaining_seconds) - float(minimum_action_time) - 0.25
    extension = min(float(maximum_extension_seconds), spare)
    if extension < 0.5:
        return ActionResponseWaitPlan(False, reason="INSUFFICIENT_SAFE_TURN_TIME")
    return ActionResponseWaitPlan(
        True,
        extension_seconds=extension,
        reason="FRESH_SOURCE_TURN_HAS_SAFE_OBSERVATION_TIME",
    )


def direct_runtime_swap_preflight_failure(
    pending: PendingAutonomousAction,
    *,
    match_id: str | None,
    turn: int | None,
    current_player: str | None,
    local_username: str | None,
    remaining_seconds: int | None,
    local_move_sequence: int | None,
    minimum_action_time: float,
) -> str | None:
    """Validate the cheap MatchService witness immediately before SWAP input.

    A full provider/policy re-read happens earlier, but screenshot/modal and
    coordinate work can consume most of a late turn.  This final direct read
    prevents a stale proposal from reaching the server after turn ownership
    changed. The configured floor is inclusive, matching the policy gate and
    live evidence that the game still accepts a SWAP at one displayed second.
    """

    identity = pending.identity
    if identity.action is not PolicyAction.SWAP:
        return "NOT_SWAP"
    if match_id != identity.source.session.match_id:
        return "MATCH_CHANGED"
    if turn != identity.source.turn:
        return "TURN_CHANGED"
    if not current_player or not local_username:
        return "TURN_OWNER_UNKNOWN"
    if current_player.casefold() != local_username.casefold():
        return "TURN_NOT_LOCAL"
    if remaining_seconds is None:
        return "TIMER_UNKNOWN"
    if float(remaining_seconds) < float(minimum_action_time):
        return "TIMER_AT_OR_BELOW_ACTION_FLOOR"
    if (
        pending.local_move_sequence_before is not None
        and local_move_sequence != pending.local_move_sequence_before
    ):
        return "LOCAL_MOVE_SEQUENCE_CHANGED"
    return None


def direct_runtime_proves_swap_accepted(
    pending: PendingAutonomousAction,
    *,
    session: CombatSessionKey,
    turn: int | None,
    current_player: str | None,
    local_username: str | None,
    local_move_sequence: int | None,
    last_move_sequence: int | None,
    last_move_from_col: int | None,
    last_move_from_row: int | None,
    last_move_to_col: int | None,
    last_move_to_row: int | None,
) -> bool:
    """Accept a SWAP from one exact, internally consistent runtime transition.

    This is deliberately stronger than merely observing the opponent turn.
    It requires the local sequence to advance exactly once and MatchService's
    durable LastMove fields to equal the bot's click order after converting
    solver/screen rows back to runtime rows.  Any absent or conflicting field
    fails closed and leaves the normal server-ACK path in charge.
    """

    identity = pending.identity
    if (
        identity.action is not PolicyAction.SWAP
        or session != identity.source.session
        or turn != identity.source.turn + 1
        or not current_player
        or not local_username
        or current_player.casefold() == local_username.casefold()
        or pending.local_move_sequence_before is None
        or local_move_sequence != pending.local_move_sequence_before + 1
        or last_move_sequence != local_move_sequence
        or len(identity.target) != 2
    ):
        return False
    first, second = identity.target
    if (
        not isinstance(first, tuple)
        or not isinstance(second, tuple)
        or len(first) != 2
        or len(second) != 2
    ):
        return False
    first_row, first_col = first
    second_row, second_col = second
    if not all(
        isinstance(value, int) and 0 <= value < 8
        for value in (first_row, first_col, second_row, second_col)
    ):
        return False
    return (
        last_move_from_col,
        last_move_from_row,
        last_move_to_col,
        last_move_to_row,
    ) == (
        first_col,
        7 - first_row,
        second_col,
        7 - second_row,
    )


def classify_swap_acceptance(
    pending: PendingAutonomousAction,
    *,
    exact_runtime_accepted: bool,
    highest_acked_sequence: int | None,
) -> SwapAcceptanceStatus:
    """Never promote an unattributed server-sequence advance to SWAP success.

    A turn timeout, boss move, AFK warning, or other server event can advance
    ``_ackedSeqs`` after two physical clicks that the board never accepted.
    Only the exact MatchService move-sequence/coordinate proof accepted by
    :func:`direct_runtime_proves_swap_accepted` is terminal success.  A bare
    sequence advance is retained as diagnostics while the action remains
    unconfirmed and therefore cannot reset authoritative idle state locally.
    """

    if pending.identity.action is not PolicyAction.SWAP:
        return SwapAcceptanceStatus.WAITING
    if exact_runtime_accepted:
        return SwapAcceptanceStatus.EXACT_RUNTIME_ACCEPTED
    if (
        highest_acked_sequence is not None
        and highest_acked_sequence > pending.identity.source.srv_seq
    ):
        return SwapAcceptanceStatus.SEQUENCE_ADVANCED_UNATTRIBUTED
    return SwapAcceptanceStatus.WAITING


def direct_runtime_proves_cast_accepted(
    pending: PendingAutonomousAction,
    *,
    session: CombatSessionKey,
    turn: int | None,
    current_player: str | None,
    local_username: str | None,
    local_move_sequence: int | None,
    last_move_sequence: int | None,
) -> bool:
    """Accept CAST from the exact consuming turn transition when DTO is missed.

    CAST does not advance MatchService's local board-move sequence. A same-
    session transition from the pending local source turn to the immediately
    following opponent turn, while both move-sequence fields remain unchanged,
    is the durable accepted transition. Rejections do not consume the turn.
    """

    identity = pending.identity
    return bool(
        identity.action is PolicyAction.CAST
        and session == identity.source.session
        and turn == identity.source.turn + 1
        and current_player
        and local_username
        and current_player.casefold() != local_username.casefold()
        and pending.local_move_sequence_before is not None
        and local_move_sequence == pending.local_move_sequence_before
        and pending.last_move_sequence_before is not None
        and last_move_sequence == pending.last_move_sequence_before
    )


class AutonomousGuard:
    """Single-owner identity registry and immediate pause/stop boundary."""

    def __init__(self) -> None:
        self.status = AutonomousStatus.WAITING_FOR_COMBAT
        self.pending: PendingAutonomousAction | None = None
        self._reserved: set[AutonomousActionIdentity] = set()
        self._executed: set[AutonomousActionIdentity] = set()

    @property
    def input_allowed(self) -> bool:
        return self.status is AutonomousStatus.RUNNING and self.pending is None

    @property
    def executed_count(self) -> int:
        return len(self._executed)

    def begin_session(self) -> None:
        self.status = AutonomousStatus.RUNNING
        self.pending = None
        self._reserved.clear()

    def reserve(self, identity: AutonomousActionIdentity) -> bool:
        if (
            not self.input_allowed
            or identity in self._reserved
            or identity in self._executed
        ):
            return False
        self._reserved.add(identity)
        return True

    def cancel_reservation(self, identity: AutonomousActionIdentity) -> bool:
        """Release a proposal that never produced input.

        Only ``begin`` promotes a source identity to the executed registry.
        This lets pause/resume and fresh-state invalidation discard a stale
        proposal while still permanently blocking duplicate sent input.
        """

        if identity not in self._reserved:
            return False
        self._reserved.remove(identity)
        return True

    def begin(self, pending: PendingAutonomousAction) -> None:
        if pending.identity not in self._reserved:
            raise ValueError("identity must be reserved before input")
        if not self.input_allowed:
            raise RuntimeError("autonomous input is not currently allowed")
        self._reserved.remove(pending.identity)
        self._executed.add(pending.identity)
        self.pending = pending
        self.status = AutonomousStatus.INPUT_LOCKED

    def complete_pending(self) -> PendingAutonomousAction:
        if self.pending is None:
            raise RuntimeError("no autonomous action is pending")
        value = self.pending
        self.pending = None
        if self.status not in {
            AutonomousStatus.PAUSED_BY_USER,
            AutonomousStatus.AUTO_PAUSED,
        }:
            self.status = AutonomousStatus.RUNNING
        return value

    def pause(self, *, automatic: bool) -> None:
        self.status = (
            AutonomousStatus.AUTO_PAUSED
            if automatic
            else AutonomousStatus.PAUSED_BY_USER
        )

    def resume(self) -> bool:
        if self.pending is not None or self.status is AutonomousStatus.RECOVERY_REQUIRED:
            return False
        if self.status in {AutonomousStatus.AUTO_PAUSED, AutonomousStatus.PAUSED_BY_USER}:
            self.status = AutonomousStatus.RUNNING
            return True
        return False

    def require_recovery(self) -> PendingAutonomousAction | None:
        pending = self.pending
        self.pending = None
        self.status = AutonomousStatus.RECOVERY_REQUIRED
        return pending

    def stop(self) -> PendingAutonomousAction | None:
        """Immediately disable input and release any pending action."""

        pending = self.pending
        self.pending = None
        self._reserved.clear()
        self.status = AutonomousStatus.STOPPED
        return pending


class ConsumingTurnRegistry:
    """Allow at most one SWAP/CAST input for a concrete combat turn."""

    def __init__(self) -> None:
        self._turns: set[tuple[CombatSessionKey, int]] = set()

    def reserve(self, session: CombatSessionKey, turn: int) -> bool:
        key = (session, turn)
        if key in self._turns:
            return False
        self._turns.add(key)
        return True

    def cancel(self, session: CombatSessionKey, turn: int) -> bool:
        """Release a turn reservation when normal input was not sent."""

        key = (session, turn)
        if key not in self._turns:
            return False
        self._turns.remove(key)
        return True

    def clear(self) -> None:
        self._turns.clear()


class TurnTransitionKind(str, Enum):
    OPPONENT_TURN = "OPPONENT_TURN"
    LOCAL_TURN_RETURNED = "LOCAL_TURN_RETURNED"
    LOCAL_TURN_RETURNED_BY_AUTHORITATIVE_ADVANCE = (
        "LOCAL_TURN_RETURNED_BY_AUTHORITATIVE_ADVANCE"
    )
    LOCAL_TURN_WITHOUT_OBSERVED_OPPONENT = "LOCAL_TURN_WITHOUT_OBSERVED_OPPONENT"


@dataclass(frozen=True)
class TurnTransitionObservation:
    kind: TurnTransitionKind
    action: AutonomousActionIdentity
    new_source: AutonomousSource | None


class TurnTransitionTracker:
    """Prove the opponent turn between autonomous consuming actions."""

    def __init__(self) -> None:
        self.action: AutonomousActionIdentity | None = None
        self.opponent_seen = False
        self.unconfirmed_local_seen = False

    def begin(self, action: AutonomousActionIdentity) -> None:
        if action.action not in {PolicyAction.SWAP, PolicyAction.CAST}:
            raise ValueError("turn transition tracking requires SWAP or CAST")
        self.action = action
        self.opponent_seen = False
        self.unconfirmed_local_seen = False

    def clear(self) -> None:
        self.action = None
        self.opponent_seen = False
        self.unconfirmed_local_seen = False

    def expire_unconfirmed_local(self) -> TurnTransitionObservation | None:
        """Fail closed only after a local-looking transition stayed unresolved."""

        action = self.action
        if (
            action is None
            or self.opponent_seen
            or not self.unconfirmed_local_seen
        ):
            return None
        observation = TurnTransitionObservation(
            TurnTransitionKind.LOCAL_TURN_WITHOUT_OBSERVED_OPPONENT,
            action,
            None,
        )
        self.clear()
        return observation

    def observe(self, state: GameState) -> TurnTransitionObservation | None:
        action = self.action
        if action is None:
            return None
        if state.battle.session_key != action.source.session:
            return None
        # A provider may republish the exact pre-action source before its
        # accepted result has propagated to the current board. Ignore it.
        if action.source.matches(state):
            return None
        new_source = AutonomousSource.from_state(state)
        if state.battle.is_local_turn is False:
            if self.opponent_seen:
                return None
            self.opponent_seen = True
            self.unconfirmed_local_seen = False
            return TurnTransitionObservation(
                TurnTransitionKind.OPPONENT_TURN, action, new_source
            )
        if state.battle.is_local_turn is True:
            if (
                state.battle.turn_number is not None
                and state.battle.turn_number <= action.source.turn
            ):
                # ACK/state publication can precede the authoritative player
                # transition. Wait; do not call this a new local turn.
                return None
            if not self.opponent_seen:
                turn_delta = (
                    state.battle.turn_number - action.source.turn
                    if state.battle.turn_number is not None
                    else None
                )
                if (
                    turn_delta is not None
                    and turn_delta >= 2
                    and turn_delta % 2 == 0
                ):
                    # In this two-participant boss match, an authoritative
                    # return to the local actor two turns later necessarily
                    # crosses the intervening boss turn. A laggy client can
                    # publish 1 -> 3 without our sampler seeing transient turn
                    # 2. The complete fresh Board is still required before
                    # policy can issue another input.
                    observation = TurnTransitionObservation(
                        TurnTransitionKind.LOCAL_TURN_RETURNED_BY_AUTHORITATIVE_ADVANCE,
                        action,
                        new_source,
                    )
                    self.clear()
                    return observation
                # MatchService fields are not updated atomically. Live evidence
                # observed TurnNumber advance about 0.55 s after a SWAP while
                # CurrentTurnPlayer still held the local actor. Keep input
                # locked and wait for the actor field to settle or for the
                # controller's bounded transition deadline to expire.
                self.unconfirmed_local_seen = True
                return None
            observation = TurnTransitionObservation(
                TurnTransitionKind.LOCAL_TURN_RETURNED,
                action,
                new_source,
            )
            self.clear()
            return observation
        return None

    def observe_runtime(
        self,
        *,
        session: CombatSessionKey,
        turn: int | None,
        current_player: str | None,
        local_username: str | None,
    ) -> TurnTransitionObservation | None:
        """Observe turn ownership from the direct MatchService runtime root.

        Full Board publication is intentionally stricter and can lag several
        seconds behind a turn transition while an ACK-attested DTO is located
        and stabilized. CurrentTurnPlayer/TurnNumber/CurrentMatchId are direct
        read-only MatchService fields, so they are the correct low-latency
        witness that no action occurred during the boss turn.
        """

        action = self.action
        if (
            action is None
            or session != action.source.session
            or turn is None
            or not current_player
            or not local_username
            or turn <= action.source.turn
        ):
            return None
        is_local = current_player.casefold() == local_username.casefold()
        if not is_local:
            if self.opponent_seen:
                return None
            self.opponent_seen = True
            self.unconfirmed_local_seen = False
            return TurnTransitionObservation(
                TurnTransitionKind.OPPONENT_TURN, action, None
            )
        if not self.opponent_seen:
            turn_delta = turn - action.source.turn
            if turn_delta >= 2 and turn_delta % 2 == 0:
                observation = TurnTransitionObservation(
                    TurnTransitionKind.LOCAL_TURN_RETURNED_BY_AUTHORITATIVE_ADVANCE,
                    action,
                    None,
                )
                self.clear()
                return observation
            self.unconfirmed_local_seen = True
            return None
        observation = TurnTransitionObservation(
            TurnTransitionKind.LOCAL_TURN_RETURNED,
            action,
            None,
        )
        self.clear()
        return observation


__all__ = [
    "ActionResultKind",
    "AutonomousActionIdentity",
    "AutonomousGuard",
    "AutonomousSource",
    "AutonomousStatus",
    "SwapAcceptanceStatus",
    "ConsumingTurnRegistry",
    "PendingAutonomousAction",
    "classify_swap_acceptance",
    "direct_runtime_proves_cast_accepted",
    "direct_runtime_proves_swap_accepted",
    "direct_runtime_swap_preflight_failure",
    "TurnTransitionKind",
    "TurnTransitionObservation",
    "TurnTransitionTracker",
]
