"""Bounded intentional PASS_WAIT state machine with a zero-input executor.

PASS is represented as waiting for the game-owned turn timeout.  This module
has no mouse, keyboard, process-write, game-call, or network-call dependency.
It only correlates lifecycle/turn observations with exact AFK payloads.
"""

from __future__ import annotations

from dataclasses import dataclass
from datetime import datetime, timezone
from enum import Enum

from .game_owned_idle import GameOwnedIdleState, PassReadinessResult


def server_timestamp_not_before(source: str | None, started: str) -> bool:
    """Compare game-local naive timestamps with the controller UTC timestamp."""

    if not source:
        return False
    try:
        source_dt = datetime.fromisoformat(source.replace("Z", "+00:00"))
        started_dt = datetime.fromisoformat(started.replace("Z", "+00:00"))
    except ValueError:
        return False
    if source_dt.tzinfo is None:
        source_dt = source_dt.replace(tzinfo=datetime.now().astimezone().tzinfo)
    if started_dt.tzinfo is None:
        started_dt = started_dt.replace(tzinfo=timezone.utc)
    # Allow one second for coarse server timestamp precision.
    return source_dt.timestamp() + 1.0 >= started_dt.timestamp()


class PassWaitState(str, Enum):
    IDLE = "idle"
    PASS_WAIT = "pass_wait"
    TERMINAL = "terminal"


class PassResultKind(str, Enum):
    PASS_CONFIRMED_IDLE_1 = "PASS_CONFIRMED_IDLE_1"
    PASS_CONFIRMED_IDLE_2 = "PASS_CONFIRMED_IDLE_2"
    PASS_STATE_UNCONFIRMED = "PASS_STATE_UNCONFIRMED"
    PASS_ABORTED_STATE_CHANGED = "PASS_ABORTED_STATE_CHANGED"
    PASS_ABORTED_USER_ACTION = "PASS_ABORTED_USER_ACTION"
    PASS_ABORTED_COMBAT_END = "PASS_ABORTED_COMBAT_END"
    SEQUENCE_DESYNC = "SEQUENCE_DESYNC"


@dataclass(frozen=True)
class PassAttempt:
    session_id: str
    match_id: str
    local_username: str
    source_turn: int
    source_srv_seq: int
    board_hash: str
    policy_reason: str
    started_timestamp: str
    turn_remaining: int
    idle_before: PassReadinessResult
    gameplay_inputs_at_start: int
    source_local_move_sequence: int | None
    pass_index: int


@dataclass(frozen=True)
class PassTerminalResult:
    result: PassResultKind
    attempt: PassAttempt
    completed_timestamp: str
    authoritative_idle: GameOwnedIdleState | None
    detail: str
    gameplay_inputs_during_wait: int


class AuthoritativePassCoordinator:
    """Own one bounded PASS_WAIT lock; never emits gameplay input."""

    def __init__(self, *, max_auto_passes: int) -> None:
        if max_auto_passes not in (1, 2):
            raise ValueError("max_auto_passes must be 1 or 2")
        self.max_auto_passes = max_auto_passes
        self.state = PassWaitState.IDLE
        self._session_id: str | None = None
        self._attempt: PassAttempt | None = None
        self._terminal: PassTerminalResult | None = None
        self._confirmed_passes = 0
        self._last_confirmed_pass_source_turn: int | None = None
        self._turn_end_observed = False
        self._pending_direct_idle: GameOwnedIdleState | None = None
        self._next_local_scans = 0

    @property
    def attempt(self) -> PassAttempt | None:
        return self._attempt

    @property
    def terminal(self) -> PassTerminalResult | None:
        return self._terminal

    @property
    def confirmed_passes(self) -> int:
        return self._confirmed_passes

    @property
    def last_confirmed_pass_source_turn(self) -> int | None:
        return self._last_confirmed_pass_source_turn

    @property
    def gameplay_locked(self) -> bool:
        return self.state is PassWaitState.PASS_WAIT

    def begin_session(self, session_id: str) -> None:
        if not session_id.strip():
            raise ValueError("session_id is required")
        if session_id != self._session_id:
            self._session_id = session_id
            self._attempt = None
            self._terminal = None
            self._confirmed_passes = 0
            self._last_confirmed_pass_source_turn = None
            self._turn_end_observed = False
            self._pending_direct_idle = None
            self._next_local_scans = 0
            self.state = PassWaitState.IDLE

    def clear_session(self) -> None:
        self._session_id = None
        self._attempt = None
        self._terminal = None
        self._confirmed_passes = 0
        self._last_confirmed_pass_source_turn = None
        self._turn_end_observed = False
        self._pending_direct_idle = None
        self._next_local_scans = 0
        self.state = PassWaitState.IDLE

    def start(
        self,
        *,
        session_id: str,
        match_id: str,
        local_username: str,
        source_turn: int,
        source_srv_seq: int,
        board_hash: str,
        policy_reason: str,
        started_timestamp: str,
        turn_remaining: int,
        idle_before: PassReadinessResult,
        gameplay_inputs_total: int,
        source_local_move_sequence: int | None,
        lifecycle_active: bool,
        is_local_turn: bool,
        is_first_local_turn: bool,
        sequence_desync: bool,
        participants_alive: bool,
        board_current_valid: bool,
        policy_selected_pass: bool,
    ) -> PassAttempt:
        self.begin_session(session_id)
        if self.state is not PassWaitState.IDLE:
            raise ValueError("PASS coordinator is not idle")
        if self._confirmed_passes >= self.max_auto_passes:
            raise ValueError("bounded autonomous PASS budget is exhausted")
        failures = []
        if not lifecycle_active:
            failures.append("lifecycle_not_active")
        if not is_local_turn:
            failures.append("not_local_turn")
        if is_first_local_turn:
            failures.append("first_local_turn_forbidden")
        if sequence_desync:
            failures.append("sequence_desync")
        if not participants_alive:
            failures.append("participant_not_alive")
        if not board_current_valid:
            failures.append("board_not_current_valid")
        if not policy_selected_pass:
            failures.append("policy_did_not_select_pass")
        if idle_before.can_pass_now is not True:
            failures.append(f"idle_not_passable:{idle_before.readiness.value}")
        if source_turn < 0 or source_srv_seq < 0 or turn_remaining < 0:
            failures.append("invalid_turn_sequence_or_timer")
        if not match_id or not local_username or not board_hash or not started_timestamp:
            failures.append("missing_identity_or_timestamp")
        if failures:
            raise ValueError("PASS start rejected: " + ",".join(failures))

        attempt = PassAttempt(
            session_id=session_id,
            match_id=match_id,
            local_username=local_username,
            source_turn=source_turn,
            source_srv_seq=source_srv_seq,
            board_hash=board_hash,
            policy_reason=policy_reason,
            started_timestamp=started_timestamp,
            turn_remaining=turn_remaining,
            idle_before=idle_before,
            gameplay_inputs_at_start=gameplay_inputs_total,
            source_local_move_sequence=source_local_move_sequence,
            pass_index=self._confirmed_passes + 1,
        )
        self._attempt = attempt
        self._terminal = None
        self._turn_end_observed = False
        self._pending_direct_idle = None
        self._next_local_scans = 0
        self.state = PassWaitState.PASS_WAIT
        return attempt

    def _finish(
        self,
        result: PassResultKind,
        *,
        timestamp: str,
        gameplay_inputs_total: int,
        authoritative_idle: GameOwnedIdleState | None = None,
        detail: str,
    ) -> PassTerminalResult:
        if self.state is not PassWaitState.PASS_WAIT or self._attempt is None:
            raise ValueError("no PASS_WAIT is active")
        inputs = gameplay_inputs_total - self._attempt.gameplay_inputs_at_start
        if inputs < 0:
            raise ValueError("gameplay input total moved backwards")
        terminal = PassTerminalResult(
            result=result,
            attempt=self._attempt,
            completed_timestamp=timestamp,
            authoritative_idle=authoritative_idle,
            detail=detail,
            gameplay_inputs_during_wait=inputs,
        )
        if result in {
            PassResultKind.PASS_CONFIRMED_IDLE_1,
            PassResultKind.PASS_CONFIRMED_IDLE_2,
        }:
            if inputs != 0:
                raise AssertionError("a confirmed PASS must send zero gameplay input")
            self._confirmed_passes += 1
            self._last_confirmed_pass_source_turn = self._attempt.source_turn
        self._terminal = terminal
        self._pending_direct_idle = None
        self.state = PassWaitState.TERMINAL
        return terminal

    def observe_turn_end(self) -> None:
        if self.state is PassWaitState.PASS_WAIT:
            self._turn_end_observed = True

    def abort_user_action(
        self, *, timestamp: str, gameplay_inputs_total: int, detail: str
    ) -> PassTerminalResult | None:
        """Abort when a manual SWAP/CAST is authoritatively observed."""

        if self.state is not PassWaitState.PASS_WAIT:
            return None
        return self._finish(
            PassResultKind.PASS_ABORTED_USER_ACTION,
            timestamp=timestamp,
            gameplay_inputs_total=gameplay_inputs_total,
            detail=detail,
        )

    def abort_state_changed(
        self, *, timestamp: str, gameplay_inputs_total: int, detail: str
    ) -> PassTerminalResult | None:
        if self.state is not PassWaitState.PASS_WAIT:
            return None
        return self._finish(
            PassResultKind.PASS_ABORTED_STATE_CHANGED,
            timestamp=timestamp,
            gameplay_inputs_total=gameplay_inputs_total,
            detail=detail,
        )

    def observe_authoritative_idle(
        self,
        idle: GameOwnedIdleState,
        *,
        timestamp: str,
        gameplay_inputs_total: int,
        newly_observed_after_start: bool,
    ) -> PassTerminalResult | None:
        if self.state is not PassWaitState.PASS_WAIT or self._attempt is None:
            return None
        attempt = self._attempt
        if idle.session_id != attempt.session_id:
            return None
        if idle.username.casefold() != attempt.local_username.casefold():
            return self._finish(
                PassResultKind.PASS_ABORTED_STATE_CHANGED,
                timestamp=timestamp,
                gameplay_inputs_total=gameplay_inputs_total,
                authoritative_idle=idle,
                detail="authoritative idle username mismatch",
            )
        turn_ordered = bool(
            idle.source_turn is not None
            and idle.source_turn > attempt.source_turn
        )
        direct_candidate = bool(
            idle.source_message_type == "MATCH_AFK_WARN"
            and newly_observed_after_start
            and server_timestamp_not_before(
                idle.source_timestamp, attempt.started_timestamp
            )
        )
        if direct_candidate and not self._turn_end_observed:
            # The direct warning is normally published in the final timer tick,
            # before MatchService advances to the opponent/next local turn.
            # Retain this exact server DTO and finish only after durable runtime
            # ordering proves the attempted turn ended.
            self._pending_direct_idle = idle
            return None
        direct_correlated = direct_candidate and self._turn_end_observed
        if not (turn_ordered or direct_correlated):
            return None
        expected_count = attempt.pass_index
        result = (
            {
                1: PassResultKind.PASS_CONFIRMED_IDLE_1,
                2: PassResultKind.PASS_CONFIRMED_IDLE_2,
            }[idle.idle_count]
            if idle.idle_count == expected_count and idle.idle_count in (1, 2)
            else PassResultKind.PASS_STATE_UNCONFIRMED
        )
        return self._finish(
            result,
            timestamp=timestamp,
            gameplay_inputs_total=gameplay_inputs_total,
            authoritative_idle=idle,
            detail=(
                f"{idle.source_message_type} reported "
                f"{idle.idle_count}/{idle.threshold}; expected {expected_count}"
            ),
        )

    def observe_runtime(
        self,
        *,
        timestamp: str,
        gameplay_inputs_total: int,
        session_id: str | None,
        lifecycle_active: bool | None,
        sequence_desync: bool,
        current_turn: int | None,
        is_local_turn: bool | None,
        current_local_move_sequence: int | None,
        scan_complete_for_next_local_turn: bool = False,
    ) -> PassTerminalResult | None:
        if self.state is not PassWaitState.PASS_WAIT or self._attempt is None:
            return None
        if gameplay_inputs_total != self._attempt.gameplay_inputs_at_start:
            return self._finish(
                PassResultKind.PASS_ABORTED_USER_ACTION,
                timestamp=timestamp,
                gameplay_inputs_total=gameplay_inputs_total,
                detail="gameplay input observed during PASS_WAIT",
            )
        if sequence_desync:
            return self._finish(
                PassResultKind.SEQUENCE_DESYNC,
                timestamp=timestamp,
                gameplay_inputs_total=gameplay_inputs_total,
                detail="terminal sequence desync during PASS_WAIT",
            )
        # ``None`` means the provider could not classify presentation state in
        # this poll. It is not evidence that combat ended. Only an explicit
        # negative lifecycle may terminate PASS_WAIT as COMBAT_END.
        if lifecycle_active is False:
            return self._finish(
                PassResultKind.PASS_ABORTED_COMBAT_END,
                timestamp=timestamp,
                gameplay_inputs_total=gameplay_inputs_total,
                detail="combat lifecycle ended during PASS_WAIT",
            )
        if session_id != self._attempt.session_id:
            return self._finish(
                PassResultKind.PASS_ABORTED_STATE_CHANGED,
                timestamp=timestamp,
                gameplay_inputs_total=gameplay_inputs_total,
                detail="combat session changed during PASS_WAIT",
            )
        if (
            self._attempt.source_local_move_sequence is not None
            and current_local_move_sequence is not None
            # A local move advances this monotonic counter. A lower value can
            # be exposed transiently by a stale/partially reset MatchService
            # read and is not evidence of user input within the same session.
            and current_local_move_sequence
            > self._attempt.source_local_move_sequence
        ):
            return self._finish(
                PassResultKind.PASS_ABORTED_USER_ACTION,
                timestamp=timestamp,
                gameplay_inputs_total=gameplay_inputs_total,
                detail="local move sequence changed during PASS_WAIT",
            )
        if current_turn is not None and current_turn > self._attempt.source_turn:
            self._turn_end_observed = True
        if self._turn_end_observed and self._pending_direct_idle is not None:
            pending_direct = self._pending_direct_idle
            self._pending_direct_idle = None
            terminal = self.observe_authoritative_idle(
                pending_direct,
                timestamp=timestamp,
                gameplay_inputs_total=gameplay_inputs_total,
                newly_observed_after_start=True,
            )
            if terminal is not None:
                return terminal
        next_local = bool(
            is_local_turn is True
            and current_turn is not None
            and current_turn > self._attempt.source_turn
        )
        if next_local and scan_complete_for_next_local_turn:
            self._next_local_scans += 1
        if next_local and self._next_local_scans >= 2:
            return self._finish(
                PassResultKind.PASS_STATE_UNCONFIRMED,
                timestamp=timestamp,
                gameplay_inputs_total=gameplay_inputs_total,
                detail="next local turn reached without a correlated AFK payload",
            )
        return None

    def take_terminal(self) -> PassTerminalResult | None:
        terminal = self._terminal
        if self.state is PassWaitState.TERMINAL:
            self._attempt = None
            self._terminal = None
            self._turn_end_observed = False
            self._pending_direct_idle = None
            self._next_local_scans = 0
            self.state = PassWaitState.IDLE
        return terminal

    def begin_new_reset_cycle(
        self,
        session_id: str,
        *,
        reset_source_turn: int | None = None,
    ) -> bool:
        """Reset only the bounded PASS budget after a proven consuming reset."""

        if self.state is not PassWaitState.IDLE:
            raise ValueError("cannot begin a reset cycle while PASS is active")
        if self._session_id != session_id:
            raise ValueError("reset cycle session mismatch")
        if (
            reset_source_turn is not None
            and self._last_confirmed_pass_source_turn is not None
            and reset_source_turn <= self._last_confirmed_pass_source_turn
        ):
            return False
        self._confirmed_passes = 0
        self._last_confirmed_pass_source_turn = None
        return True


__all__ = [
    "AuthoritativePassCoordinator",
    "PassAttempt",
    "PassResultKind",
    "PassTerminalResult",
    "PassWaitState",
    "server_timestamp_not_before",
]
