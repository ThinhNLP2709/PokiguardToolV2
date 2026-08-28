"""Bounded automatic technical-recovery state and capability boundaries.

The coordinator is deliberately independent from the live Win32 runner.  It
owns authorization and evidence; callers own read-only state acquisition and
normal foreground input. Production triggers are limited to sequence desync,
a rigorously proven zero-legal-move board, a narrowly proven loss of the
current MatchService actionability state, a durable Board player-left signal,
a fully actionable local combat turn on which the farm controller nevertheless
reaches its terminal deadline, and a bounded exact-session watchdog proving
that all authoritative combat-progress fields are frozen.
"""

from __future__ import annotations

from dataclasses import asdict, dataclass, field, is_dataclass
from datetime import datetime, timezone
from enum import Enum
import json
from pathlib import Path
import re
from typing import Any
from uuid import uuid4

from .actionability import ActionabilityGate, GateContext
from .board_diagnostics import (
    BoardDiagnosticResult,
    diagnostic_board_hash,
    game_state_payload,
)
from .combat_lifecycle import CombatLifecycleState
from .state import (
    CombatSessionKey,
    GameOwnedIdleStatus,
    GamePhase,
    GameState,
)


# Product rule confirmed live: gameplay input is accepted while the
# authoritative timer displays 1 second. Only 0 is terminal for new input and
# routes the exact farm-owned recovery gate instead.
MANDATORY_RESET_RECOVERY_FLOOR_SECONDS = 1

# A normal 14-second turn changes at least the server timer or turn/sequence
# identity. Give reconnects, animations and short server stalls substantially
# longer than one whole turn before declaring the exact active combat frozen.
# This watchdog authorizes recovery only; it never authorizes gameplay input.
ACTIVE_COMBAT_PROGRESS_STALL_SECONDS = 45.0
ACTIVE_COMBAT_PROGRESS_STALL_MIN_SAMPLES = 4


@dataclass(frozen=True)
class ActiveCombatProgressStall:
    session_key: CombatSessionKey
    match_id: str
    turn: int
    current_player: str
    local_username: str
    remaining_seconds: int
    local_move_sequence: int
    last_move_sequence: int
    highest_acked_sequence: int
    unchanged_seconds: float
    sample_count: int


class ActiveCombatProgressWatchdog:
    """Prove that a live MatchService combat signature stopped advancing.

    Every field comes from the read-only direct MatchService/runtime roots. Any
    identity, timer, turn, move-sequence or ACK progress restarts the clock.
    Missing/invalid evidence also resets the clock so an absence of data can
    never be promoted into recovery authority.
    """

    def __init__(
        self,
        *,
        stall_seconds: float = ACTIVE_COMBAT_PROGRESS_STALL_SECONDS,
        minimum_samples: int = ACTIVE_COMBAT_PROGRESS_STALL_MIN_SAMPLES,
    ) -> None:
        if stall_seconds <= 0:
            raise ValueError("active-combat stall seconds must be positive")
        if minimum_samples < 2:
            raise ValueError("active-combat stall requires at least two samples")
        self.stall_seconds = float(stall_seconds)
        self.minimum_samples = int(minimum_samples)
        self._signature: tuple[Any, ...] | None = None
        self._unchanged_since: float | None = None
        self._sample_count = 0

    def reset(self) -> None:
        self._signature = None
        self._unchanged_since = None
        self._sample_count = 0

    def observe(
        self,
        *,
        sampled_at: float,
        session_key: CombatSessionKey | None,
        match_id: str | None,
        turn: int | None,
        current_player: str | None,
        local_username: str | None,
        remaining_seconds: int | None,
        local_move_sequence: int | None,
        last_move_sequence: int | None,
        highest_acked_sequence: int | None,
        eligible: bool,
    ) -> ActiveCombatProgressStall | None:
        exact = bool(
            eligible
            and session_key is not None
            and match_id
            and session_key.match_id == match_id
            and turn is not None
            and turn >= 2
            and current_player
            and local_username
            and remaining_seconds is not None
            and remaining_seconds >= 0
            and local_move_sequence is not None
            and local_move_sequence >= 1
            and last_move_sequence is not None
            and last_move_sequence >= 0
            and highest_acked_sequence is not None
            and highest_acked_sequence > 0
        )
        if not exact:
            self.reset()
            return None

        assert session_key is not None
        assert match_id is not None
        assert turn is not None
        assert current_player is not None
        assert local_username is not None
        assert remaining_seconds is not None
        assert local_move_sequence is not None
        assert last_move_sequence is not None
        assert highest_acked_sequence is not None
        signature = (
            session_key,
            match_id,
            int(turn),
            current_player.casefold(),
            local_username.casefold(),
            int(remaining_seconds),
            int(local_move_sequence),
            int(last_move_sequence),
            int(highest_acked_sequence),
        )
        if signature != self._signature:
            self._signature = signature
            self._unchanged_since = float(sampled_at)
            self._sample_count = 1
            return None

        self._sample_count += 1
        assert self._unchanged_since is not None
        unchanged_seconds = max(0.0, float(sampled_at) - self._unchanged_since)
        if (
            self._sample_count < self.minimum_samples
            or unchanged_seconds < self.stall_seconds
        ):
            return None
        return ActiveCombatProgressStall(
            session_key=session_key,
            match_id=match_id,
            turn=int(turn),
            current_player=current_player,
            local_username=local_username,
            remaining_seconds=int(remaining_seconds),
            local_move_sequence=int(local_move_sequence),
            last_move_sequence=int(last_move_sequence),
            highest_acked_sequence=int(highest_acked_sequence),
            unchanged_seconds=unchanged_seconds,
            sample_count=self._sample_count,
        )


class TechnicalFailureReason(str, Enum):
    SEQUENCE_DESYNC = "SEQUENCE_DESYNC"
    DEAD_BOARD_NO_REFRESH = "DEAD_BOARD_NO_REFRESH"
    ACTIONABILITY_STATE_LOST = "ACTIONABILITY_STATE_LOST"
    CONTROLLER_STALLED_ACTIVE_COMBAT = "CONTROLLER_STALLED_ACTIVE_COMBAT"
    ACTIVE_COMBAT_PROGRESS_STALLED = "ACTIVE_COMBAT_PROGRESS_STALLED"
    LOCAL_PLAYER_LEFT_ACTIVE_COMBAT = "LOCAL_PLAYER_LEFT_ACTIVE_COMBAT"
    LATE_MANDATORY_RESET = "LATE_MANDATORY_RESET"
    ENTRY_OPENING_TIMEOUT_ACTIVE_COMBAT = "ENTRY_OPENING_TIMEOUT_ACTIVE_COMBAT"


class RecoveryTriggerSource(str, Enum):
    PRODUCTION_SEQUENCE_GUARD = "PRODUCTION_SEQUENCE_GUARD"
    PRODUCTION_DEAD_BOARD_DIAGNOSTIC = "PRODUCTION_DEAD_BOARD_DIAGNOSTIC"
    PRODUCTION_ACTIONABILITY_DEADLINE = "PRODUCTION_ACTIONABILITY_DEADLINE"
    PRODUCTION_UNCONFIRMED_PASS_RESET = "PRODUCTION_UNCONFIRMED_PASS_RESET"
    PRODUCTION_CONTROLLER_STALL = "PRODUCTION_CONTROLLER_STALL"
    PRODUCTION_ACTIVE_COMBAT_PROGRESS_STALL = (
        "PRODUCTION_ACTIVE_COMBAT_PROGRESS_STALL"
    )
    PRODUCTION_BOARD_LEFT_ACTOR_SET = "PRODUCTION_BOARD_LEFT_ACTOR_SET"
    PRODUCTION_LATE_MANDATORY_RESET = "PRODUCTION_LATE_MANDATORY_RESET"
    PRODUCTION_ENTRY_OPENING_TIMEOUT = "PRODUCTION_ENTRY_OPENING_TIMEOUT"
    TEST_ONLY = "TEST_ONLY"


class TechnicalRecoveryState(str, Enum):
    IDLE = "IDLE"
    TECHNICAL_FAILURE_DETECTED = "TECHNICAL_FAILURE_DETECTED"
    GAMEPLAY_LOCKED = "GAMEPLAY_LOCKED"
    RESOLVE_EXIT_CONTROL = "RESOLVE_EXIT_CONTROL"
    EXIT_READY = "EXIT_READY"
    EXIT_INPUT_SENT = "EXIT_INPUT_SENT"
    WAIT_EXIT_MODAL = "WAIT_EXIT_MODAL"
    CONFIRM_MODAL_READY = "CONFIRM_MODAL_READY"
    CONFIRM_INPUT_SENT = "CONFIRM_INPUT_SENT"
    WAIT_LOCAL_COMBAT_END = "WAIT_LOCAL_COMBAT_END"
    WAIT_BOSS_LOBBY = "WAIT_BOSS_LOBBY"
    CLEAR_OLD_SESSION = "CLEAR_OLD_SESSION"
    RESOLVE_REENTRY_TARGET = "RESOLVE_REENTRY_TARGET"
    VERIFY_REENTRY_TARGET = "VERIFY_REENTRY_TARGET"
    REENTRY_READY = "REENTRY_READY"
    REENTRY_INPUT_SENT = "REENTRY_INPUT_SENT"
    WAIT_NEW_SESSION = "WAIT_NEW_SESSION"
    WAIT_NEW_OPENING = "WAIT_NEW_OPENING"
    RECOVERY_COMPLETE = "RECOVERY_COMPLETE"
    RECOVERY_BLOCKED = "RECOVERY_BLOCKED"
    RECOVERY_LIMIT_REACHED = "RECOVERY_LIMIT_REACHED"
    ERROR = "ERROR"


class TechnicalRecoveryResult(str, Enum):
    RECOVERY_COMPLETE = "RECOVERY_COMPLETE"
    RECOVERY_BLOCKED_FOREGROUND = "RECOVERY_BLOCKED_FOREGROUND"
    RECOVERY_EXIT_LOCATOR_FAILED = "RECOVERY_EXIT_LOCATOR_FAILED"
    RECOVERY_CONFIRM_FAILED = "RECOVERY_CONFIRM_FAILED"
    RECOVERY_LOBBY_TIMEOUT = "RECOVERY_LOBBY_TIMEOUT"
    RECOVERY_TARGET_FAILED = "RECOVERY_TARGET_FAILED"
    RECOVERY_REENTRY_FAILED = "RECOVERY_REENTRY_FAILED"
    RECOVERY_NEW_SESSION_FAILED = "RECOVERY_NEW_SESSION_FAILED"
    RECOVERY_OPENING_FAILED = "RECOVERY_OPENING_FAILED"
    RECOVERY_LIMIT_REACHED = "RECOVERY_LIMIT_REACHED"
    RECOVERY_ABORTED_USER_STOP = "RECOVERY_ABORTED_USER_STOP"


class RecoveryInputDomain(str, Enum):
    RECOVERY_EXIT = "RECOVERY_EXIT"
    RECOVERY_CONFIRM = "RECOVERY_CONFIRM"
    RECOVERY_TARGET_SELECT = "RECOVERY_TARGET_SELECT"
    RECOVERY_REENTRY = "RECOVERY_REENTRY"


@dataclass(frozen=True)
class FailedSessionEvidence:
    session_key: Any
    match_id: str
    board_instance: int | None
    lifecycle_epoch: int | None
    turn: int | None
    srv_seq: int | None
    board_hash: str | None

    def __post_init__(self) -> None:
        if not self.match_id.strip():
            raise ValueError("failed recovery session requires match_id")


@dataclass(frozen=True)
class RecoveryTrigger:
    trigger_id: str
    reason: TechnicalFailureReason | None
    source: RecoveryTriggerSource
    failed_session: FailedSessionEvidence
    detected_at: str
    evidence_source: str

    def __post_init__(self) -> None:
        if not self.trigger_id or not self.detected_at or not self.evidence_source:
            raise ValueError("recovery trigger identity/provenance is incomplete")
        if self.source is RecoveryTriggerSource.TEST_ONLY:
            if self.reason is not None:
                raise ValueError("TEST_ONLY must not pretend a technical failure reason")
        elif self.reason is None:
            raise ValueError("production recovery requires an exact technical reason")

    @property
    def identity(self) -> tuple[Any, ...]:
        failed = self.failed_session
        return (
            self.source.value,
            self.reason.value if self.reason is not None else "TEST_ONLY",
            failed.session_key,
            failed.match_id,
            failed.turn,
            failed.srv_seq,
            failed.board_hash,
        )


@dataclass(frozen=True)
class RecoveryPermit:
    attempt_id: str
    domain: RecoveryInputDomain
    nonce: str


@dataclass(frozen=True)
class RecoveryInputRecord:
    domain: RecoveryInputDomain
    sent: bool
    detail: str


@dataclass(frozen=True)
class RecoveredOpeningEvidence:
    session: CombatSessionKey
    match_id: str
    board_hash: str
    srv_seq: int
    complete_cells: int
    unique_coordinates: int
    source: str
    first_local_turn: bool
    local_move_sequence: int | None
    stable_confirmations: int
    production_ready: bool = True
    gem_types_valid: bool = True
    multipliers_valid: bool = True
    fresh_dto: bool = True
    timer_safe: bool = True


@dataclass
class RecoverySafetyCounters:
    recovery_attempts: int = 0
    gameplay_inputs_after_trigger: int = 0
    gameplay_inputs_during_recovery: int = 0
    gameplay_inputs_in_recovered_combat: int = 0
    duplicate_exit: int = 0
    duplicate_confirm: int = 0
    duplicate_reentry: int = 0
    wrong_ui_click: int = 0
    stale_session_confusion: int = 0
    wrong_target: int = 0


@dataclass(frozen=True)
class TechnicalRecoverySnapshot:
    recovery_id: str
    state: TechnicalRecoveryState
    result: TechnicalRecoveryResult | None
    result_detail: str | None
    max_technical_recoveries: int
    gameplay_locked: bool
    trigger: RecoveryTrigger | None
    old_session_invalidated: bool
    new_session: CombatSessionKey | None
    new_opening: RecoveredOpeningEvidence | None
    input_records: tuple[RecoveryInputRecord, ...]
    safety: RecoverySafetyCounters
    history: tuple[dict[str, Any], ...]


def utc_timestamp() -> str:
    return datetime.now(timezone.utc).isoformat(timespec="milliseconds").replace(
        "+00:00", "Z"
    )


def _jsonable(value: Any) -> Any:
    if is_dataclass(value):
        return _jsonable(asdict(value))
    if isinstance(value, Enum):
        return value.value
    if isinstance(value, Path):
        return str(value)
    if isinstance(value, dict):
        return {str(key): _jsonable(item) for key, item in value.items()}
    if isinstance(value, (tuple, list, set)):
        return [_jsonable(item) for item in value]
    return value


def failed_session_from_state(state: GameState) -> FailedSessionEvidence:
    session = state.battle.session_key
    match_id = state.battle.match_id or (session.match_id if session is not None else None)
    if session is None or match_id is None:
        raise ValueError("technical recovery requires a current combat session")
    return FailedSessionEvidence(
        session_key=session,
        match_id=match_id,
        board_instance=state.battle.board_instance,
        lifecycle_epoch=session.lifecycle_epoch,
        turn=state.battle.turn_number,
        srv_seq=state.battle.srv_seq,
        board_hash=state.battle.board_hash,
    )


class TechnicalRecoveryCoordinator:
    """Single-attempt, fail-closed automatic technical recovery authority."""

    def __init__(self, *, max_technical_recoveries: int = 1) -> None:
        if max_technical_recoveries != 1:
            raise ValueError("Phase 2D.3 requires max_technical_recoveries=1")
        self.recovery_id = uuid4().hex
        self.max_technical_recoveries = max_technical_recoveries
        self.state = TechnicalRecoveryState.IDLE
        self.result: TechnicalRecoveryResult | None = None
        self.result_detail: str | None = None
        self.gameplay_locked = False
        self.trigger: RecoveryTrigger | None = None
        self.old_session_invalidated = False
        self.new_session: CombatSessionKey | None = None
        self.new_opening: RecoveredOpeningEvidence | None = None
        self.input_records: list[RecoveryInputRecord] = []
        self.safety = RecoverySafetyCounters()
        self.history: list[dict[str, Any]] = []
        self._pending: RecoveryPermit | None = None
        self._used_domains: set[RecoveryInputDomain] = set()
        self._seen_trigger_identities: set[tuple[Any, ...]] = set()
        self._local_combat_ended = False
        self._target_verified = False
        self._transition(TechnicalRecoveryState.IDLE, "coordinator_created")

    @property
    def recovery_pending(self) -> bool:
        return self.trigger is not None and self.state not in {
            TechnicalRecoveryState.RECOVERY_COMPLETE,
            TechnicalRecoveryState.RECOVERY_BLOCKED,
            TechnicalRecoveryState.RECOVERY_LIMIT_REACHED,
            TechnicalRecoveryState.ERROR,
        }

    def snapshot(self) -> TechnicalRecoverySnapshot:
        return TechnicalRecoverySnapshot(
            recovery_id=self.recovery_id,
            state=self.state,
            result=self.result,
            result_detail=self.result_detail,
            max_technical_recoveries=self.max_technical_recoveries,
            gameplay_locked=self.gameplay_locked,
            trigger=self.trigger,
            old_session_invalidated=self.old_session_invalidated,
            new_session=self.new_session,
            new_opening=self.new_opening,
            input_records=tuple(self.input_records),
            safety=RecoverySafetyCounters(**asdict(self.safety)),
            history=tuple(dict(item) for item in self.history),
        )

    def _transition(self, state: TechnicalRecoveryState, event: str, **detail: Any) -> None:
        old = self.state
        self.state = state
        self.history.append(
            {
                "index": len(self.history) + 1,
                "timestamp": utc_timestamp(),
                "event": event,
                "oldState": old.value,
                "newState": state.value,
                "detail": _jsonable(detail),
            }
        )

    def trigger_recovery(self, trigger: RecoveryTrigger) -> bool:
        if trigger.identity in self._seen_trigger_identities:
            self.history.append(
                {
                    "index": len(self.history) + 1,
                    "timestamp": utc_timestamp(),
                    "event": "duplicate_trigger_ignored",
                    "oldState": self.state.value,
                    "newState": self.state.value,
                    "detail": {"triggerId": trigger.trigger_id},
                }
            )
            return False
        self._seen_trigger_identities.add(trigger.identity)
        if self.safety.recovery_attempts >= self.max_technical_recoveries or self.trigger is not None:
            self.gameplay_locked = True
            self.result = TechnicalRecoveryResult.RECOVERY_LIMIT_REACHED
            self.result_detail = "a second distinct technical recovery was requested"
            self._transition(
                TechnicalRecoveryState.RECOVERY_LIMIT_REACHED,
                "recovery_limit_reached",
                attemptedTrigger=trigger,
            )
            return False
        if self.state is not TechnicalRecoveryState.IDLE:
            self._error("recovery trigger received outside IDLE")
            return False
        self.trigger = trigger
        self.safety.recovery_attempts += 1
        self._transition(
            TechnicalRecoveryState.TECHNICAL_FAILURE_DETECTED,
            "technical_failure_detected",
            trigger=trigger,
        )
        self.gameplay_locked = True
        self._transition(
            TechnicalRecoveryState.GAMEPLAY_LOCKED,
            "gameplay_locked",
            pendingGameplayInvalidated=True,
        )
        self._transition(
            TechnicalRecoveryState.RESOLVE_EXIT_CONTROL,
            "resolve_exit_control",
        )
        return True

    def record_gameplay_boundary(self, *, sent: bool, recovered_combat: bool = False) -> bool:
        """Deny gameplay after trigger and expose any boundary violation."""

        if not self.gameplay_locked:
            return True
        if sent:
            self.safety.gameplay_inputs_after_trigger += 1
            if self.state is TechnicalRecoveryState.RECOVERY_COMPLETE or recovered_combat:
                self.safety.gameplay_inputs_in_recovered_combat += 1
            else:
                self.safety.gameplay_inputs_during_recovery += 1
            self._error("gameplay input was reported after technical recovery trigger")
        return False

    def exit_control_ready(self, *, locator_proof: str) -> bool:
        if self.state is not TechnicalRecoveryState.RESOLVE_EXIT_CONTROL or not locator_proof:
            return False
        self._transition(
            TechnicalRecoveryState.EXIT_READY,
            "exit_control_ready",
            locatorProof=locator_proof,
        )
        return True

    def confirm_modal_ready(self, *, locator_proof: str) -> bool:
        if self.state is not TechnicalRecoveryState.WAIT_EXIT_MODAL or not locator_proof:
            return False
        self._transition(
            TechnicalRecoveryState.CONFIRM_MODAL_READY,
            "confirm_modal_ready",
            locatorProof=locator_proof,
        )
        return True

    def reserve_exit(
        self, *, foreground: bool, same_session: bool, lifecycle_active: bool
    ) -> RecoveryPermit | None:
        if not foreground:
            self.block(
                TechnicalRecoveryResult.RECOVERY_BLOCKED_FOREGROUND,
                "foreground lost before recovery Exit click",
            )
            return None
        if not same_session or not lifecycle_active or not self.gameplay_locked:
            self.block(
                TechnicalRecoveryResult.RECOVERY_EXIT_LOCATOR_FAILED,
                "failed-session/lifecycle changed before Exit click",
            )
            return None
        return self._reserve(RecoveryInputDomain.RECOVERY_EXIT, TechnicalRecoveryState.EXIT_READY)

    def reserve_confirm(
        self, *, foreground: bool, context_valid: bool
    ) -> RecoveryPermit | None:
        if not foreground:
            self.block(
                TechnicalRecoveryResult.RECOVERY_BLOCKED_FOREGROUND,
                "foreground lost before recovery confirm click",
            )
            return None
        if not context_valid or not self.gameplay_locked:
            self.block(
                TechnicalRecoveryResult.RECOVERY_CONFIRM_FAILED,
                "leave-confirm context changed before click",
            )
            return None
        return self._reserve(
            RecoveryInputDomain.RECOVERY_CONFIRM,
            TechnicalRecoveryState.CONFIRM_MODAL_READY,
        )

    def reserve_target_select(self, *, foreground: bool) -> RecoveryPermit | None:
        if not foreground:
            self.block(
                TechnicalRecoveryResult.RECOVERY_BLOCKED_FOREGROUND,
                "foreground lost before recovery target selection",
            )
            return None
        return self._reserve(
            RecoveryInputDomain.RECOVERY_TARGET_SELECT,
            TechnicalRecoveryState.VERIFY_REENTRY_TARGET,
        )

    def reentry_ready(self, *, proof: str) -> bool:
        if self.state is not TechnicalRecoveryState.VERIFY_REENTRY_TARGET or not proof:
            return False
        self._transition(
            TechnicalRecoveryState.REENTRY_READY,
            "reentry_ready",
            proof=proof,
        )
        return True

    def reserve_reentry(self, *, foreground: bool) -> RecoveryPermit | None:
        if not foreground:
            self.block(
                TechnicalRecoveryResult.RECOVERY_BLOCKED_FOREGROUND,
                "foreground lost before recovery re-entry",
            )
            return None
        if not self._target_verified:
            self.block(
                TechnicalRecoveryResult.RECOVERY_TARGET_FAILED,
                "re-entry target was not exactly verified",
            )
            return None
        return self._reserve(
            RecoveryInputDomain.RECOVERY_REENTRY,
            TechnicalRecoveryState.REENTRY_READY,
        )

    def _reserve(
        self, domain: RecoveryInputDomain, required_state: TechnicalRecoveryState
    ) -> RecoveryPermit | None:
        if domain in self._used_domains:
            if domain is RecoveryInputDomain.RECOVERY_EXIT:
                self.safety.duplicate_exit += 1
            elif domain is RecoveryInputDomain.RECOVERY_CONFIRM:
                self.safety.duplicate_confirm += 1
            elif domain is RecoveryInputDomain.RECOVERY_REENTRY:
                self.safety.duplicate_reentry += 1
            self.block(self._failure_for_domain(domain), f"duplicate {domain.value} attempt")
            return None
        if self.state is not required_state or self._pending is not None:
            return None
        permit = RecoveryPermit(self.recovery_id, domain, uuid4().hex)
        self._pending = permit
        self._used_domains.add(domain)
        self.history.append(
            {
                "index": len(self.history) + 1,
                "timestamp": utc_timestamp(),
                "event": "recovery_input_reserved",
                "oldState": self.state.value,
                "newState": self.state.value,
                "detail": {"domain": domain.value, "nonce": permit.nonce},
            }
        )
        return permit

    def cancel_input(self, permit: RecoveryPermit, *, detail: str) -> bool:
        if permit != self._pending:
            return False
        self._pending = None
        self.block(self._failure_for_domain(permit.domain), detail)
        return True

    def complete_input(self, permit: RecoveryPermit, *, sent: bool, detail: str) -> bool:
        if permit != self._pending or permit.attempt_id != self.recovery_id:
            return False
        self._pending = None
        self.input_records.append(RecoveryInputRecord(permit.domain, sent, detail))
        if not sent:
            self.block(self._failure_for_domain(permit.domain), detail)
            return False
        if permit.domain is RecoveryInputDomain.RECOVERY_EXIT:
            self._transition(
                TechnicalRecoveryState.EXIT_INPUT_SENT,
                "recovery_exit_input_sent",
                detail=detail,
            )
            self._transition(
                TechnicalRecoveryState.WAIT_EXIT_MODAL,
                "wait_exit_modal",
            )
        elif permit.domain is RecoveryInputDomain.RECOVERY_CONFIRM:
            self._transition(
                TechnicalRecoveryState.CONFIRM_INPUT_SENT,
                "recovery_confirm_input_sent",
                detail=detail,
            )
            self._transition(
                TechnicalRecoveryState.WAIT_LOCAL_COMBAT_END,
                "wait_local_combat_end",
            )
        elif permit.domain is RecoveryInputDomain.RECOVERY_TARGET_SELECT:
            self._transition(
                TechnicalRecoveryState.VERIFY_REENTRY_TARGET,
                "recovery_target_select_input_sent",
                detail=detail,
            )
        elif permit.domain is RecoveryInputDomain.RECOVERY_REENTRY:
            self._transition(
                TechnicalRecoveryState.REENTRY_INPUT_SENT,
                "recovery_reentry_input_sent",
                detail=detail,
            )
            self._transition(
                TechnicalRecoveryState.WAIT_NEW_SESSION,
                "wait_new_session",
            )
        return True

    @staticmethod
    def _failure_for_domain(domain: RecoveryInputDomain) -> TechnicalRecoveryResult:
        if domain is RecoveryInputDomain.RECOVERY_EXIT:
            return TechnicalRecoveryResult.RECOVERY_EXIT_LOCATOR_FAILED
        if domain is RecoveryInputDomain.RECOVERY_CONFIRM:
            return TechnicalRecoveryResult.RECOVERY_CONFIRM_FAILED
        if domain is RecoveryInputDomain.RECOVERY_TARGET_SELECT:
            return TechnicalRecoveryResult.RECOVERY_TARGET_FAILED
        return TechnicalRecoveryResult.RECOVERY_REENTRY_FAILED

    def observe_local_lifecycle(self, lifecycle: CombatLifecycleState) -> bool:
        if self.state not in {
            TechnicalRecoveryState.WAIT_LOCAL_COMBAT_END,
            TechnicalRecoveryState.WAIT_BOSS_LOBBY,
        }:
            return False
        if lifecycle in {
            CombatLifecycleState.LEAVING,
            CombatLifecycleState.POSTMATCH,
            CombatLifecycleState.LOBBY,
            CombatLifecycleState.STALE_SERVER_MATCH,
        }:
            self._local_combat_ended = True
            if self.state is not TechnicalRecoveryState.WAIT_BOSS_LOBBY:
                self._transition(
                    TechnicalRecoveryState.WAIT_BOSS_LOBBY,
                    "old_local_combat_ended",
                    lifecycle=lifecycle,
                )
            return True
        return False

    def observe_boss_lobby(self, *, exact_boss_lobby: bool) -> bool:
        if (
            self.state is not TechnicalRecoveryState.WAIT_BOSS_LOBBY
            or not self._local_combat_ended
            or not exact_boss_lobby
        ):
            return False
        self._transition(
            TechnicalRecoveryState.CLEAR_OLD_SESSION,
            "exact_boss_lobby_confirmed",
        )
        return True

    def clear_old_session(
        self,
        *,
        provider_session_none: bool,
        pending_action_none: bool,
        desync_old_session_ended: bool,
    ) -> bool:
        if self.state is not TechnicalRecoveryState.CLEAR_OLD_SESSION:
            return False
        if not (provider_session_none and pending_action_none and desync_old_session_ended):
            self.block(
                TechnicalRecoveryResult.RECOVERY_NEW_SESSION_FAILED,
                "old local session state did not clear completely",
            )
            return False
        self.old_session_invalidated = True
        self._transition(
            TechnicalRecoveryState.RESOLVE_REENTRY_TARGET,
            "old_session_invalidated",
            cleared=(
                "old MatchId/session/Board ownership",
                "srvSeq and board caches",
                "idle/desync/action/card/fusion transient state",
            ),
        )
        return True

    def resolve_target(
        self,
        *,
        resolved: bool,
        available: bool,
        selected: bool,
        exact_identity: bool,
        target_id: str | None,
        target_name: str | None,
    ) -> bool:
        if self.state is not TechnicalRecoveryState.RESOLVE_REENTRY_TARGET:
            return False
        if not (resolved and available and selected and exact_identity):
            if resolved and not exact_identity:
                self.safety.wrong_target += 1
            self.block(
                TechnicalRecoveryResult.RECOVERY_TARGET_FAILED,
                "re-entry target missing, ambiguous, unavailable, unselected, or not exact",
            )
            return False
        self._target_verified = True
        self._transition(
            TechnicalRecoveryState.VERIFY_REENTRY_TARGET,
            "reentry_target_resolved",
            targetId=target_id,
            targetName=target_name,
        )
        return True

    def accept_new_session(self, session: CombatSessionKey) -> bool:
        if self.state is not TechnicalRecoveryState.WAIT_NEW_SESSION or self.trigger is None:
            return False
        failed = self.trigger.failed_session
        fresh = bool(
            session.match_id != failed.match_id
            and session != failed.session_key
            and (
                failed.board_instance is None
                or session.board_instance != failed.board_instance
            )
            and (
                failed.lifecycle_epoch is None
                or session.lifecycle_epoch > failed.lifecycle_epoch
            )
        )
        if not fresh:
            self.safety.stale_session_confusion += 1
            self.block(
                TechnicalRecoveryResult.RECOVERY_NEW_SESSION_FAILED,
                "recovered combat did not prove a fresh MatchId/session/Board/epoch",
            )
            return False
        self.new_session = session
        self._transition(
            TechnicalRecoveryState.WAIT_NEW_OPENING,
            "fresh_new_session_confirmed",
            oldSession=failed,
            newSession=session,
        )
        return True

    def accept_opening(self, opening: RecoveredOpeningEvidence) -> bool:
        if (
            self.state is not TechnicalRecoveryState.WAIT_NEW_OPENING
            or self.new_session is None
            or self.trigger is None
        ):
            return False
        source = "ChatMessageDTO.MATCH_START.matchPayload.board"
        failed_hash = self.trigger.failed_session.board_hash
        valid = bool(
            opening.session == self.new_session
            and opening.match_id == self.new_session.match_id
            and re.fullmatch(r"[0-9a-fA-F]{64}", opening.board_hash) is not None
            and (failed_hash is None or opening.board_hash != failed_hash)
            and opening.complete_cells == 64
            and opening.unique_coordinates == 64
            and opening.source == source
            and opening.first_local_turn
            and opening.local_move_sequence == 0
            and opening.stable_confirmations >= 2
            and opening.production_ready
            and opening.gem_types_valid
            and opening.multipliers_valid
            and opening.fresh_dto
            and opening.timer_safe
        )
        if not valid:
            self.block(
                TechnicalRecoveryResult.RECOVERY_OPENING_FAILED,
                "recovered opening failed freshness/64-cell/first-turn invariants",
            )
            return False
        self.new_opening = opening
        self.result = TechnicalRecoveryResult.RECOVERY_COMPLETE
        self.result_detail = "RECOVERY_NEW_COMBAT_OPENING_READY"
        self._transition(
            TechnicalRecoveryState.RECOVERY_COMPLETE,
            "recovery_new_combat_opening_ready",
            opening=opening,
            gameplayInRecoveredCombat=0,
            hardStop=True,
        )
        return True

    def block(self, result: TechnicalRecoveryResult, detail: str) -> None:
        if self.state in {
            TechnicalRecoveryState.RECOVERY_COMPLETE,
            TechnicalRecoveryState.RECOVERY_LIMIT_REACHED,
        }:
            return
        self._pending = None
        self.gameplay_locked = True
        self.result = result
        self.result_detail = detail
        self._transition(
            TechnicalRecoveryState.RECOVERY_BLOCKED,
            "recovery_blocked",
            result=result,
            detail=detail,
        )

    def emergency_stop(self, *, detail: str = "F9 emergency stop") -> None:
        self._pending = None
        self.gameplay_locked = True
        self.result = TechnicalRecoveryResult.RECOVERY_ABORTED_USER_STOP
        self.result_detail = detail
        self._transition(
            TechnicalRecoveryState.RECOVERY_BLOCKED,
            "recovery_aborted_user_stop",
            detail=detail,
        )

    def _error(self, detail: str) -> None:
        self._pending = None
        self.gameplay_locked = True
        self.result_detail = detail
        self._transition(TechnicalRecoveryState.ERROR, "recovery_error", detail=detail)


class TechnicalRecoveryDispatcher:
    """Validate production/test trigger provenance into one coordinator path."""

    def __init__(self, coordinator: TechnicalRecoveryCoordinator) -> None:
        self.coordinator = coordinator

    @property
    def recovery_pending(self) -> bool:
        return self.coordinator.recovery_pending

    def dispatch_sequence_desync(
        self,
        desync: Any,
        *,
        state: GameState | None = None,
        evidence_source: str = "SequenceDesyncState.terminal_for_session",
    ) -> bool:
        if not bool(getattr(desync, "detected", False)) or not bool(
            getattr(desync, "terminal_for_session", False)
        ):
            return False
        if state is not None:
            failed = failed_session_from_state(state)
            if (
                failed.match_id != getattr(desync, "match_id", None)
                or failed.session_key != getattr(desync, "session_key", None)
            ):
                return False
        else:
            match_id = str(getattr(desync, "match_id", "") or "")
            session_key = getattr(desync, "session_key", None)
            if not match_id or session_key is None:
                return False
            failed = FailedSessionEvidence(
                session_key=session_key,
                match_id=match_id,
                board_instance=None,
                lifecycle_epoch=None,
                turn=getattr(desync, "turn", None),
                srv_seq=getattr(desync, "srv_seq", None),
                board_hash=None,
            )
        trigger = RecoveryTrigger(
            trigger_id=uuid4().hex,
            reason=TechnicalFailureReason.SEQUENCE_DESYNC,
            source=RecoveryTriggerSource.PRODUCTION_SEQUENCE_GUARD,
            failed_session=failed,
            detected_at=str(getattr(desync, "first_seen_at", None) or utc_timestamp()),
            evidence_source=evidence_source,
        )
        return self.coordinator.trigger_recovery(trigger)

    def dispatch_dead_board(
        self,
        state: GameState,
        analysis: BoardDiagnosticResult,
        *,
        evidence_source: str = "BoardDiagnosticResult.dead_board",
    ) -> bool:
        exact = bool(
            analysis.dead_board is True
            and analysis.legal_match_producing_moves == 0
            and analysis.total_adjacent_swaps == 112
            and analysis.illegal_no_match_swaps == 112
            and state.board is not None
            and analysis.state_timestamp == state.timestamp
            and analysis.diagnostic_board_hash == diagnostic_board_hash(state.board)
            and state.battle.combat_lifecycle is CombatLifecycleState.ACTIVE
        )
        if not exact:
            return False
        return self.coordinator.trigger_recovery(
            RecoveryTrigger(
                trigger_id=uuid4().hex,
                reason=TechnicalFailureReason.DEAD_BOARD_NO_REFRESH,
                source=RecoveryTriggerSource.PRODUCTION_DEAD_BOARD_DIAGNOSTIC,
                failed_session=failed_session_from_state(state),
                detected_at=utc_timestamp(),
                evidence_source=evidence_source,
            )
        )

    def dispatch_actionability_state_lost(
        self,
        *,
        session_key: CombatSessionKey,
        match_id: str,
        turn: int,
        current_player: str | None,
        local_username: str | None,
        remaining_seconds: int,
        warning_seconds: int,
        local_move_sequence: int | None,
        last_move_sequence: int | None,
        provider_reason: str,
        actionability_gate_reason: str | None,
        accepted_consuming_actions: int,
        last_accepted_srv_seq: int | None,
        last_accepted_board_hash: str | None,
        highest_acked_sequence: int | None = None,
        last_published_turn: int | None = None,
        evidence_source: str = "MatchService actionability telemetry at deadline",
    ) -> bool:
        """Arm recovery only for the reconnect/reset signature seen in B3.

        A plain slow policy decision remains a safe-stop. Recovery is allowed
        only after this exact session already completed a consuming action,
        the late local-turn telemetry regressed to the pristine ``0/None``
        sequence pair, and the provider simultaneously lost current DTO
        evidence. This prevents a first-turn ``0/None`` value from being
        mistaken for a technical failure.
        """

        reconnect_signature = bool(
            local_move_sequence == 0
            and last_move_sequence is None
            and (
                provider_reason
                in {
                    "no_current_ack_attested_complete_batch",
                    "stale_sequence",
                }
                or (
                    provider_reason == "awaiting_stability_confirmation"
                    and actionability_gate_reason
                    in {"DISCONNECTED", "RECONNECTING"}
                )
            )
        )
        unresolved_acked_transport = bool(
            provider_reason == "latest_acked_batch_not_resolved"
            and local_move_sequence is not None
            and local_move_sequence > 0
            and last_move_sequence == local_move_sequence
            and highest_acked_sequence is not None
            and last_accepted_srv_seq is not None
            and highest_acked_sequence > last_accepted_srv_seq
            and last_published_turn is not None
            and last_published_turn < turn
        )
        exact = bool(
            match_id
            and session_key.match_id == match_id
            and turn > 1
            and current_player
            and local_username
            and current_player.casefold() == local_username.casefold()
            and 0 <= remaining_seconds <= warning_seconds <= 10
            and accepted_consuming_actions > 0
            and (reconnect_signature or unresolved_acked_transport)
            and last_accepted_srv_seq is not None
            and last_accepted_srv_seq > 0
            and bool(last_accepted_board_hash)
        )
        if not exact:
            return False
        failed = FailedSessionEvidence(
            session_key=session_key,
            match_id=match_id,
            board_instance=session_key.board_instance,
            lifecycle_epoch=session_key.lifecycle_epoch,
            turn=turn,
            srv_seq=last_accepted_srv_seq,
            board_hash=last_accepted_board_hash,
        )
        return self.coordinator.trigger_recovery(
            RecoveryTrigger(
                trigger_id=uuid4().hex,
                reason=TechnicalFailureReason.ACTIONABILITY_STATE_LOST,
                source=RecoveryTriggerSource.PRODUCTION_ACTIONABILITY_DEADLINE,
                failed_session=failed,
                detected_at=utc_timestamp(),
                evidence_source=evidence_source,
            )
        )

    def dispatch_unconfirmed_pass_runtime_reset(
        self,
        *,
        session_key: CombatSessionKey,
        match_id: str,
        source_turn: int,
        source_srv_seq: int,
        source_board_hash: str,
        source_local_move_sequence: int | None,
        current_turn: int,
        current_player: str | None,
        local_username: str | None,
        current_local_move_sequence: int | None,
        current_last_move_sequence: int | None,
        current_highest_acked_sequence: int | None,
        gameplay_inputs_during_wait: int,
        terminal_detail: str,
        evidence_source: str = "PASS_WAIT next-turn runtime reset",
    ) -> bool:
        """Recover an unconfirmed PASS only when runtime identity was reset.

        Missing AFK data alone is not sufficient. The current local turn must
        be later than the PASS source, zero input must have occurred during
        the wait, and previously nonzero action telemetry must have regressed
        to the reconnect-only ``0/None/None`` sequence tuple.
        """

        exact = bool(
            match_id
            and session_key.match_id == match_id
            and source_turn > 1
            and current_turn > source_turn
            and source_srv_seq > 0
            and bool(source_board_hash)
            and source_local_move_sequence is not None
            and source_local_move_sequence > 0
            and current_player
            and local_username
            and current_player.casefold() == local_username.casefold()
            and current_local_move_sequence == 0
            and current_last_move_sequence is None
            and current_highest_acked_sequence is None
            and gameplay_inputs_during_wait == 0
            and terminal_detail
            == "next local turn reached without a correlated AFK payload"
        )
        if not exact:
            return False
        return self.coordinator.trigger_recovery(
            RecoveryTrigger(
                trigger_id=uuid4().hex,
                reason=TechnicalFailureReason.ACTIONABILITY_STATE_LOST,
                source=RecoveryTriggerSource.PRODUCTION_UNCONFIRMED_PASS_RESET,
                failed_session=FailedSessionEvidence(
                    session_key=session_key,
                    match_id=match_id,
                    board_instance=session_key.board_instance,
                    lifecycle_epoch=session_key.lifecycle_epoch,
                    turn=current_turn,
                    srv_seq=source_srv_seq,
                    board_hash=source_board_hash,
                ),
                detected_at=utc_timestamp(),
                evidence_source=evidence_source,
            )
        )

    def dispatch_controller_stalled_active_combat(
        self,
        state: GameState,
        *,
        session_key: CombatSessionKey,
        match_id: str,
        turn: int,
        remaining_seconds: int,
        warning_seconds: int,
        game_foreground: bool,
        window_valid: bool,
        controller_running: bool,
        pending_action: bool,
        consuming_action_sent: bool,
        authoritative_pass_wait_active: bool,
        evolve_wait_active: bool,
        sequence_desync: Any | None,
        evidence_source: str = (
            "fully actionable ACTIVE local turn at terminal controller deadline"
        ),
    ) -> bool:
        """Recover a proven controller stall before later idle turns can eject.

        This is deliberately not a generic timeout trigger. The same current
        state must still pass the complete production actionability gate, the
        normal controller must still own the turn, and no gameplay/PASS/Fusion
        outcome may be pending. Reconnects, animations, boss turns, modal UI,
        foreground loss and valid authoritative PASS waits remain zero-input
        waits or safe stops.
        """

        battle = state.battle
        exact_identity = bool(
            match_id
            and session_key.match_id == match_id
            and state.phase is GamePhase.COMBAT
            and battle.combat_lifecycle is CombatLifecycleState.ACTIVE
            and battle.session_key == session_key
            and battle.match_id == match_id
            and battle.board_instance == session_key.board_instance
            and battle.turn_number == turn
            and turn > 0
            and battle.is_local_turn is True
            and battle.current_turn_player
            and battle.local_username
            and battle.current_turn_player.casefold()
            == battle.local_username.casefold()
            and 0 <= remaining_seconds < warning_seconds <= 10
        )
        if not exact_identity:
            return False
        if (
            not controller_running
            or pending_action
            or consuming_action_sent
            or authoritative_pass_wait_active
            or evolve_wait_active
            or (
                sequence_desync is not None
                and bool(getattr(sequence_desync, "terminal_for_session", False))
            )
        ):
            return False

        gate = ActionabilityGate.evaluate(
            state,
            GateContext(
                current_session=session_key,
                game_foreground=game_foreground,
                window_valid=window_valid,
                input_locked=False,
                auto_paused=False,
                sequence_desync=sequence_desync,
                allow_opening_board_only=True,
                allow_authoritative_board_only_stats=True,
            ),
        )
        if not gate.actionable:
            return False

        return self.coordinator.trigger_recovery(
            RecoveryTrigger(
                trigger_id=uuid4().hex,
                reason=TechnicalFailureReason.CONTROLLER_STALLED_ACTIVE_COMBAT,
                source=RecoveryTriggerSource.PRODUCTION_CONTROLLER_STALL,
                failed_session=failed_session_from_state(state),
                detected_at=utc_timestamp(),
                evidence_source=evidence_source,
            )
        )

    def dispatch_active_combat_progress_stalled(
        self,
        state: GameState,
        *,
        stall: ActiveCombatProgressStall,
        game_foreground: bool,
        window_valid: bool,
        controller_running: bool,
        pending_action: bool,
        accepted_consuming_actions: int,
        authoritative_pass_wait_active: bool,
        evolve_wait_active: bool,
        sequence_desync: Any | None,
        evidence_source: str = (
            "unchanged direct MatchService turn/timer/move/ACK signature"
        ),
    ) -> bool:
        """Recover a whole-combat freeze on either the local or boss turn.

        Unlike the local deadline detector, this path does not assume which
        player should act. It requires a previously productive, exact ACTIVE
        session plus 45 seconds of unchanged authoritative progress fields.
        Short lag, animation, reconnect, foreground loss, missing reads and all
        pending gameplay/PASS/Fusion states remain non-authoritative.
        """

        battle = state.battle
        exact_identity = bool(
            stall.match_id
            and stall.session_key.match_id == stall.match_id
            and state.phase is GamePhase.COMBAT
            and battle.combat_lifecycle is CombatLifecycleState.ACTIVE
            and battle.session_key == stall.session_key
            and battle.match_id == stall.match_id
            and battle.board_instance == stall.session_key.board_instance
            and battle.turn_number == stall.turn
            and battle.current_turn_player
            and battle.current_turn_player.casefold()
            == stall.current_player.casefold()
            and battle.local_username
            and battle.local_username.casefold() == stall.local_username.casefold()
            and state.board is not None
            and state.board.production_ready
            and stall.turn >= 2
            and stall.remaining_seconds >= 0
            and stall.local_move_sequence >= 1
            and stall.last_move_sequence >= 0
            and stall.highest_acked_sequence > 0
            and stall.unchanged_seconds >= ACTIVE_COMBAT_PROGRESS_STALL_SECONDS
            and stall.sample_count >= ACTIVE_COMBAT_PROGRESS_STALL_MIN_SAMPLES
        )
        if not exact_identity:
            return False
        if (
            not game_foreground
            or not window_valid
            or not controller_running
            or pending_action
            or accepted_consuming_actions < 1
            or authoritative_pass_wait_active
            or evolve_wait_active
            or (
                sequence_desync is not None
                and bool(getattr(sequence_desync, "terminal_for_session", False))
            )
        ):
            return False

        return self.coordinator.trigger_recovery(
            RecoveryTrigger(
                trigger_id=uuid4().hex,
                reason=TechnicalFailureReason.ACTIVE_COMBAT_PROGRESS_STALLED,
                source=(
                    RecoveryTriggerSource.PRODUCTION_ACTIVE_COMBAT_PROGRESS_STALL
                ),
                failed_session=failed_session_from_state(state),
                detected_at=utc_timestamp(),
                evidence_source=evidence_source,
            )
        )

    def dispatch_local_player_left_active_combat(
        self,
        state: GameState,
        *,
        session_key: CombatSessionKey,
        match_id: str,
        evidence_source: str = (
            "local actor is present in validated Board._leftActorNumbers"
        ),
    ) -> bool:
        """Recover only when the game durably marks the local actor as left.

        ``MatchService.Players`` is a server snapshot and may remain stale in
        this state. ``Board._leftActorNumbers`` is updated by the client-side
        player-left handler and directly drives the in-combat "left" visual.
        The exact farm-owned combat identity must still agree before recovery
        is armed; this path never authorizes a gameplay action.
        """

        battle = state.battle
        exact_identity = bool(
            match_id
            and session_key.match_id == match_id
            and state.phase is GamePhase.COMBAT
            and battle.combat_lifecycle is CombatLifecycleState.ACTIVE
            and battle.session_key == session_key
            and battle.match_id == match_id
            and battle.board_instance == session_key.board_instance
            and battle.local_actor_number is not None
            and battle.local_actor_number > 0
            and battle.local_has_left_match is True
        )
        if not exact_identity:
            return False

        return self.coordinator.trigger_recovery(
            RecoveryTrigger(
                trigger_id=uuid4().hex,
                reason=TechnicalFailureReason.LOCAL_PLAYER_LEFT_ACTIVE_COMBAT,
                source=RecoveryTriggerSource.PRODUCTION_BOARD_LEFT_ACTOR_SET,
                failed_session=failed_session_from_state(state),
                detected_at=utc_timestamp(),
                evidence_source=evidence_source,
            )
        )

    def dispatch_entry_opening_timeout_active_combat(
        self,
        *,
        session_key: CombatSessionKey,
        match_id: str,
        provider_session: CombatSessionKey | None,
        entry_clicks: int,
        gameplay_inputs: int,
        published_turn: int,
        first_local_turn: bool,
        local_move_sequence: int | None,
        srv_seq: int,
        board_hash: str,
        board_source: str,
        evidence_source: str = (
            "entry missed opening after current ACK-attested combat board advanced"
        ),
    ) -> bool:
        """Recover when entry missed the immutable opening but combat is live.

        The entry click is already irreversible. Gameplay never started, and a
        later current MATCH_MOVE_RES board proves the game advanced beyond the
        pristine opening. Recovery preflight still revalidates the exact failed
        session immediately before any normal Exit UI input.
        """

        exact = bool(
            match_id
            and session_key.match_id == match_id
            and provider_session == session_key
            and entry_clicks == 1
            and gameplay_inputs == 0
            and published_turn > 1
            and first_local_turn is False
            and local_move_sequence == 0
            and srv_seq > 0
            and bool(board_hash)
            and board_source
            == "ChatMessageDTO.MATCH_MOVE_RES.matchPayload.board"
        )
        if not exact:
            return False
        return self.coordinator.trigger_recovery(
            RecoveryTrigger(
                trigger_id=uuid4().hex,
                reason=TechnicalFailureReason.ENTRY_OPENING_TIMEOUT_ACTIVE_COMBAT,
                source=RecoveryTriggerSource.PRODUCTION_ENTRY_OPENING_TIMEOUT,
                failed_session=FailedSessionEvidence(
                    session_key=session_key,
                    match_id=match_id,
                    board_instance=session_key.board_instance,
                    lifecycle_epoch=session_key.lifecycle_epoch,
                    turn=published_turn,
                    srv_seq=srv_seq,
                    board_hash=board_hash,
                ),
                detected_at=utc_timestamp(),
                evidence_source=evidence_source,
            )
        )

    def dispatch_late_mandatory_reset(
        self,
        state: GameState,
        *,
        session_key: CombatSessionKey,
        match_id: str,
        turn: int,
        remaining_seconds: int,
        minimum_action_time: int,
        recovery_warning_seconds: int,
        selected_action: str,
        policy_blocker: str | None = None,
        mandatory_reset_pending: bool,
        game_foreground: bool,
        window_valid: bool,
        controller_running: bool,
        pending_action: bool,
        consuming_action_sent: bool,
        authoritative_pass_wait_active: bool,
        evolve_wait_active: bool,
        sequence_desync: Any | None,
        evidence_source: str = (
            "authoritative idle threshold reached on a late mandatory reset turn"
        ),
    ) -> bool:
        """Recover before idle ejection when a reset turn arrives unusually late.

        This is separate from the normal user-approved action floor.  It is
        armed only by an exact server-owned ``threshold - 1`` idle state on the
        same actionable local turn, before any consuming input is sent.  A
        first-turn mandatory action, ordinary slow decision, locally counted
        PASS, or unproven/stale idle state cannot trigger this path.
        """

        battle = state.battle
        # PolicyAction values cross this boundary as lower-case wire values
        # (``swap``/``cast``), while older direct dispatcher callers used enum
        # names (``SWAP``/``CAST``).  Normalize once at the boundary so an
        # otherwise exact authoritative 2/3 recovery proof cannot be rejected
        # solely because of enum serialization casing.
        normalized_selected_action = str(selected_action).strip().upper()
        threshold = battle.consecutive_pass_threshold
        idle_count = battle.consecutive_passes
        selected_action_is_safe_recovery_evidence = bool(
            normalized_selected_action in {"SWAP", "CAST"}
            or (
                normalized_selected_action == "NONE"
                and policy_blocker == "TURN_TIMER_SAFETY_MARGIN"
            )
        )
        exact_identity_and_idle = bool(
            mandatory_reset_pending
            and selected_action_is_safe_recovery_evidence
            and match_id
            and session_key.match_id == match_id
            and state.phase is GamePhase.COMBAT
            and battle.combat_lifecycle is CombatLifecycleState.ACTIVE
            and battle.session_key == session_key
            and battle.match_id == match_id
            and battle.board_instance == session_key.board_instance
            and battle.turn_number == turn
            and turn > 0
            and battle.is_local_turn is True
            and battle.current_turn_player
            and battle.local_username
            and battle.current_turn_player.casefold()
            == battle.local_username.casefold()
            and battle.turn_time_remaining_seconds == remaining_seconds
            and 1 <= minimum_action_time <= 10
            and recovery_warning_seconds
            == max(
                minimum_action_time,
                MANDATORY_RESET_RECOVERY_FLOOR_SECONDS,
            )
            and 0 <= remaining_seconds < recovery_warning_seconds <= 10
            and threshold is not None
            and threshold > 1
            and idle_count == threshold - 1
            and battle.consecutive_pass_status
            is GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION
            and bool(battle.consecutive_pass_source)
        )
        if not exact_identity_and_idle:
            return False
        if (
            not controller_running
            or pending_action
            or consuming_action_sent
            or authoritative_pass_wait_active
            or evolve_wait_active
            or (
                sequence_desync is not None
                and bool(getattr(sequence_desync, "terminal_for_session", False))
            )
        ):
            return False

        gate = ActionabilityGate.evaluate(
            state,
            GateContext(
                current_session=session_key,
                game_foreground=game_foreground,
                window_valid=window_valid,
                input_locked=False,
                auto_paused=False,
                sequence_desync=sequence_desync,
                allow_opening_board_only=True,
                allow_authoritative_board_only_stats=True,
            ),
        )
        if not gate.actionable:
            return False

        return self.coordinator.trigger_recovery(
            RecoveryTrigger(
                trigger_id=uuid4().hex,
                reason=TechnicalFailureReason.LATE_MANDATORY_RESET,
                source=RecoveryTriggerSource.PRODUCTION_LATE_MANDATORY_RESET,
                failed_session=failed_session_from_state(state),
                detected_at=utc_timestamp(),
                evidence_source=evidence_source,
            )
        )

    def dispatch_policy_no_safe_move(
        self, *, legal_move_count: int, safe_move_count: int
    ) -> bool:
        # Explicit non-dispatch contract: this belongs to BASIC PASS/mandatory
        # policy even when every legal move is dangerous.
        return False

    def arm_test_only(self, state: GameState) -> bool:
        if state.battle.combat_lifecycle is not CombatLifecycleState.ACTIVE:
            return False
        return self.arm_test_only_evidence(failed_session_from_state(state))

    def arm_test_only_evidence(self, failed: FailedSessionEvidence) -> bool:
        """Arm TEST_ONLY from a hardened ACTIVE lifecycle identity.

        A tool attached after combat began can lack the lobby batch baseline
        needed to publish a board.  This relaxation belongs only to explicit
        UI acceptance; production desync/dead-board triggers stay unchanged.
        """

        return self.coordinator.trigger_recovery(
            RecoveryTrigger(
                trigger_id=uuid4().hex,
                reason=None,
                source=RecoveryTriggerSource.TEST_ONLY,
                failed_session=failed,
                detected_at=utc_timestamp(),
                evidence_source=(
                    "explicit --recovery-ui-test; hardened ACTIVE lifecycle identity; "
                    "no technical failure claimed"
                ),
            )
        )


class RecoveryReentryCapability:
    """Adapter used by the accepted Phase 2D.1 entry click boundary."""

    entry_number = 1

    def __init__(
        self,
        coordinator: TechnicalRecoveryCoordinator,
        authority: Any | None = None,
    ) -> None:
        self.coordinator = coordinator
        self._authority = authority

    def reserve(self, *, foreground: bool) -> RecoveryPermit | None:
        if self._authority is not None and self._authority.emergency_requested:
            self.coordinator.emergency_stop(
                detail="emergency authority revoked before recovery re-entry"
            )
            return None
        if self.coordinator.state is TechnicalRecoveryState.VERIFY_REENTRY_TARGET:
            if not self.coordinator.reentry_ready(
                proof="Phase2D1 exact target + stable Start + atomic preflight"
            ):
                return None
        return self.coordinator.reserve_reentry(foreground=foreground)

    def complete(self, permit: RecoveryPermit, *, sent: bool, detail: str = "") -> bool:
        return self.coordinator.complete_input(permit, sent=sent, detail=detail)

    def cancel(self, permit: RecoveryPermit, *, detail: str = "") -> bool:
        return self.coordinator.cancel_input(permit, detail=detail)

    def execute(self, operation: Any) -> tuple[bool, Any | None]:
        if self._authority is None:
            return True, operation()
        authorized, result = self._authority.execute_if_authorized(operation)
        if not authorized:
            self.coordinator.emergency_stop(
                detail="emergency authority revoked before recovery re-entry input"
            )
        return authorized, result


class RecoveryArtifactWriter:
    """Audit artifact owner for one recovery attempt."""

    def __init__(self, directory: Path) -> None:
        self.directory = directory.resolve()
        self.directory.mkdir(parents=True, exist_ok=False)
        self.events_path = self.directory / "events.jsonl"
        self.recovery_path = self.directory / "recovery.json"

    @classmethod
    def create(cls, root: Path) -> "RecoveryArtifactWriter":
        stamp = datetime.now().strftime("%Y%m%d_%H%M%S_%f")[:-3]
        candidate = root / stamp
        suffix = 1
        while candidate.exists():
            candidate = root / f"{stamp}_{suffix:02d}"
            suffix += 1
        return cls(candidate)

    def event(self, event: str, **fields: Any) -> None:
        with self.events_path.open("a", encoding="utf-8") as output:
            output.write(
                json.dumps(
                    {"timestamp": utc_timestamp(), "event": event, **_jsonable(fields)},
                    ensure_ascii=False,
                    separators=(",", ":"),
                )
                + "\n"
            )

    def write_failure(self, coordinator: TechnicalRecoveryCoordinator, state: GameState | None) -> None:
        (self.directory / "failure_state.json").write_text(
            json.dumps(
                {
                    "schema": "pokiguard.technical_recovery.failure.v1",
                    "trigger": _jsonable(coordinator.trigger),
                    "gameState": _jsonable(state),
                },
                ensure_ascii=False,
                indent=2,
            ),
            encoding="utf-8",
        )
        board_payload: dict[str, Any]
        if state is not None and state.board is not None:
            board_payload = game_state_payload(state)
        else:
            board_payload = {
                "schema": "pokiguard.technical_recovery.board_unavailable.v1",
                "available": False,
                "reason": "captured trigger did not contain a full runtime board",
            }
        (self.directory / "board.json").write_text(
            json.dumps(_jsonable(board_payload), ensure_ascii=False, indent=2),
            encoding="utf-8",
        )

    def finalize(self, coordinator: TechnicalRecoveryCoordinator, **extra: Any) -> None:
        self.recovery_path.write_text(
            json.dumps(
                {
                    "schema": "pokiguard.technical_recovery.v1",
                    "snapshot": _jsonable(coordinator.snapshot()),
                    **_jsonable(extra),
                    "memoryWrites": False,
                    "directGameCalls": False,
                    "networkManipulation": False,
                },
                ensure_ascii=False,
                indent=2,
            ),
            encoding="utf-8",
        )


__all__ = [
    "ACTIVE_COMBAT_PROGRESS_STALL_MIN_SAMPLES",
    "ACTIVE_COMBAT_PROGRESS_STALL_SECONDS",
    "ActiveCombatProgressStall",
    "ActiveCombatProgressWatchdog",
    "MANDATORY_RESET_RECOVERY_FLOOR_SECONDS",
    "FailedSessionEvidence",
    "RecoveredOpeningEvidence",
    "RecoveryArtifactWriter",
    "RecoveryInputDomain",
    "RecoveryInputRecord",
    "RecoveryPermit",
    "RecoveryReentryCapability",
    "RecoverySafetyCounters",
    "RecoveryTrigger",
    "RecoveryTriggerSource",
    "TechnicalFailureReason",
    "TechnicalRecoveryCoordinator",
    "TechnicalRecoveryDispatcher",
    "TechnicalRecoveryResult",
    "TechnicalRecoverySnapshot",
    "TechnicalRecoveryState",
    "failed_session_from_state",
]
