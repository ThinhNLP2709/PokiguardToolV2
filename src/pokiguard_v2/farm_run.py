"""Bounded Phase 2D.4 multi-match farm-run authority.

This module is deliberately pure: live runners own read-only observations and
normal foreground input, while :class:`FarmRun` owns every input capability,
session identity, counter, and hard-stop boundary.
"""

from __future__ import annotations

from dataclasses import asdict, dataclass, field, is_dataclass, replace
from datetime import datetime, timezone
from enum import Enum
import json
from pathlib import Path
from typing import Any
from uuid import uuid4

from .boss_entry import BossLobbyState, FarmTarget
from .farm_cycle import OpeningEvidence
from .state import CombatSessionKey


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


class FarmRunState(str, Enum):
    WAIT_INITIAL_BOSS_LOBBY = "WAIT_INITIAL_BOSS_LOBBY"
    RESOLVE_TARGET = "RESOLVE_TARGET"
    ENTRY_READY = "ENTRY_READY"
    ENTRY_PENDING = "ENTRY_PENDING"
    WAIT_OPENING = "WAIT_OPENING"
    COMBAT_ACTIVE = "COMBAT_ACTIVE"
    WAIT_POSTMATCH = "WAIT_POSTMATCH"
    WAIT_BOSS_LOBBY = "WAIT_BOSS_LOBBY"
    RECOVERY_PENDING = "RECOVERY_PENDING"
    RECOVERY_ACTIVE = "RECOVERY_ACTIVE"
    RECOVERY_OPENING_READY = "RECOVERY_OPENING_READY"
    FARM_RUN_COMPLETE = "FARM_RUN_COMPLETE"
    SAFE_STOP = "SAFE_STOP"
    ERROR = "ERROR"


class FarmRunStopReason(str, Enum):
    FARM_TARGET_COMPLETED = "FARM_TARGET_COMPLETED"
    FARM_START_STATE_INVALID = "FARM_START_STATE_INVALID"
    TARGET_RESOLUTION_FAILED = "TARGET_RESOLUTION_FAILED"
    ENTRY_CAPABILITY_DENIED = "ENTRY_CAPABILITY_DENIED"
    ENTRY_INPUT_FAILED = "ENTRY_INPUT_FAILED"
    ENTRY_TIMEOUT = "ENTRY_TIMEOUT"
    OPENING_INVARIANT_FAILED = "OPENING_ACCEPTANCE_INVARIANT_FAILED"
    SESSION_REUSE_AMBIGUOUS = "SESSION_REUSE_AMBIGUOUS"
    MATCH_ATTEMPT_LIMIT_REACHED = "MATCH_ATTEMPT_LIMIT_REACHED"
    RECOVERY_LIMIT_REACHED = "RECOVERY_LIMIT_REACHED"
    RECOVERY_FAILED = "RECOVERY_FAILED"
    GAMEPLAY_CAPABILITY_DENIED = "GAMEPLAY_CAPABILITY_DENIED"
    POSTMATCH_UI_AMBIGUOUS = "POSTMATCH_UI_AMBIGUOUS"
    RETURN_LOBBY_TIMEOUT = "RETURN_LOBBY_TIMEOUT"
    FOREGROUND_LOST = "FOREGROUND_LOST"
    SAFETY_LIMIT_REACHED = "SAFETY_LIMIT_REACHED"
    COMBAT_SAFE_STOP = "COMBAT_SAFE_STOP"
    EMERGENCY_STOP = "F9_EMERGENCY_STOP"
    CONTROLLER_CONFLICT = "CONTROLLER_CONFLICT"
    STAGE_B1_ACTION_ACCEPTED = "STAGE_B1_ACTION_ACCEPTED"
    INTERNAL_INVARIANT = "FARM_RUN_INTERNAL_INVARIANT"


class MatchResult(str, Enum):
    WIN = "WIN"
    LOSS = "LOSS"
    TECHNICAL_ABORT = "TECHNICAL_ABORT"
    SAFE_STOP = "SAFE_STOP"
    UNKNOWN = "UNKNOWN"


class FarmInputDomain(str, Enum):
    BOSS_TARGET_SELECT = "BOSS_TARGET_SELECT"
    BOSS_ENTRY = "BOSS_ENTRY"
    GAMEPLAY_SWAP = "GAMEPLAY_SWAP"
    GAMEPLAY_CAST = "GAMEPLAY_CAST"
    GAMEPLAY_EVOLVE = "GAMEPLAY_EVOLVE"
    GAMEPLAY_PASS = "GAMEPLAY_PASS"
    POSTMATCH_CONFIRM = "POSTMATCH_CONFIRM"
    RECOVERY_EXIT = "RECOVERY_EXIT"
    RECOVERY_CONFIRM = "RECOVERY_CONFIRM"
    RECOVERY_TARGET_SELECT = "RECOVERY_TARGET_SELECT"
    RECOVERY_REENTRY = "RECOVERY_REENTRY"

    @property
    def gameplay(self) -> bool:
        return self.value.startswith("GAMEPLAY_")

    @property
    def recovery(self) -> bool:
        return self.value.startswith("RECOVERY_")


@dataclass(frozen=True)
class FarmRunLimits:
    target_completed_matches: int = 3
    max_technical_recoveries: int = 1
    max_match_attempts: int = 5

    def __post_init__(self) -> None:
        if self.target_completed_matches <= 0:
            raise ValueError("target_completed_matches must be positive")
        if self.max_technical_recoveries < 0:
            raise ValueError("max_technical_recoveries cannot be negative")
        if self.max_match_attempts <= 0:
            raise ValueError("max_match_attempts must be positive")
        if self.target_completed_matches > self.max_match_attempts:
            raise ValueError("target_completed_matches cannot exceed max_match_attempts")


@dataclass
class FarmRunSafetyCounters:
    duplicate_gameplay_input: int = 0
    duplicate_lobby_entry: int = 0
    duplicate_recovery_exit: int = 0
    duplicate_recovery_confirm: int = 0
    duplicate_recovery_reentry: int = 0
    wrong_target: int = 0
    wrong_turn_input: int = 0
    opponent_turn_input: int = 0
    stale_action: int = 0
    stale_session_confusion: int = 0
    postmatch_gameplay_input: int = 0
    lobby_gameplay_input: int = 0
    input_after_farm_stop: int = 0

    def nonzero(self) -> dict[str, int]:
        return {key: value for key, value in asdict(self).items() if value}


@dataclass
class MatchTelemetry:
    attempt_index: int
    match_id: str
    session_key: CombatSessionKey
    start_timestamp: str
    recovered: bool = False
    end_timestamp: str | None = None
    result: MatchResult = MatchResult.UNKNOWN
    local_turns: int = 0
    boss_turns: int = 0
    swap_sent: int = 0
    swap_acknowledged: int = 0
    swap_rejected: int = 0
    cast_sent: int = 0
    cast_accepted: int = 0
    cast_rejected: int = 0
    evolve_attempts: int = 0
    evolve_failed: int = 0
    evolve_success: int = 0
    pass_count: int = 0
    dead_board: int = 0
    sequence_desync: int = 0
    normal_postmatch: bool = False
    technical_recovery: bool = False
    next_match_id: str | None = None


@dataclass(frozen=True)
class FarmInputPermit:
    token: str
    domain: FarmInputDomain
    session: CombatSessionKey | None
    attempt_index: int | None


@dataclass(frozen=True)
class FarmInputRecord:
    domain: FarmInputDomain
    session: CombatSessionKey | None
    attempt_index: int | None
    sent: bool
    timestamp: str
    detail: str


@dataclass(frozen=True)
class FarmRunEvent:
    index: int
    timestamp: str
    event: str
    state: FarmRunState
    detail: dict[str, Any] = field(default_factory=dict)


@dataclass(frozen=True)
class FarmRunSnapshot:
    farm_run_id: str
    target: FarmTarget
    limits: FarmRunLimits
    state: FarmRunState
    match_attempts: int
    completed_matches: int
    wins: int
    losses: int
    technical_aborts: int
    technical_recoveries: int
    safe_stops: int
    current_match_id: str | None
    current_session_key: CombatSessionKey | None
    total_gameplay_inputs: int
    total_lobby_inputs: int
    total_postmatch_inputs: int
    total_recovery_inputs: int
    stop_reason: FarmRunStopReason | None
    attempts: tuple[MatchTelemetry, ...]
    input_records: tuple[FarmInputRecord, ...]
    safety: FarmRunSafetyCounters
    events: tuple[FarmRunEvent, ...]


class FarmRun:
    """Single-owner, bounded multi-match state and capability ledger."""

    _TECHNICAL_REASONS = {"SEQUENCE_DESYNC", "DEAD_BOARD_NO_REFRESH"}

    def __init__(
        self,
        target: FarmTarget,
        *,
        limits: FarmRunLimits | None = None,
        farm_run_id: str | None = None,
    ) -> None:
        self.farm_run_id = farm_run_id or uuid4().hex
        self.target = target
        self.limits = limits or FarmRunLimits()
        self.state = FarmRunState.WAIT_INITIAL_BOSS_LOBBY
        self.match_attempts = 0
        self.completed_matches = 0
        self.wins = 0
        self.losses = 0
        self.technical_aborts = 0
        self.technical_recoveries = 0
        self.safe_stops = 0
        self.current_session: CombatSessionKey | None = None
        self.stop_reason: FarmRunStopReason | None = None
        self.attempts: list[MatchTelemetry] = []
        self.input_records: list[FarmInputRecord] = []
        self.safety = FarmRunSafetyCounters()
        self.events: list[FarmRunEvent] = []
        self._seen_sessions: set[CombatSessionKey] = set()
        self._seen_match_ids: set[str] = set()
        self._pending: FarmInputPermit | None = None
        self._recovered_opening: OpeningEvidence | None = None
        self._test_only_recovery_required = False
        self._event("farm_run_created", target=target, limits=self.limits)

    @property
    def stopped(self) -> bool:
        return self.state in {
            FarmRunState.FARM_RUN_COMPLETE,
            FarmRunState.SAFE_STOP,
            FarmRunState.ERROR,
        }

    @property
    def current_attempt(self) -> MatchTelemetry | None:
        return self.attempts[-1] if self.attempts and self.current_session is not None else None

    def snapshot(self) -> FarmRunSnapshot:
        gameplay = sum(r.sent for r in self.input_records if r.domain.gameplay)
        lobby = sum(
            r.sent
            for r in self.input_records
            if r.domain in {FarmInputDomain.BOSS_TARGET_SELECT, FarmInputDomain.BOSS_ENTRY}
        )
        postmatch = sum(
            r.sent for r in self.input_records if r.domain is FarmInputDomain.POSTMATCH_CONFIRM
        )
        recovery = sum(r.sent for r in self.input_records if r.domain.recovery)
        return FarmRunSnapshot(
            self.farm_run_id,
            self.target,
            self.limits,
            self.state,
            self.match_attempts,
            self.completed_matches,
            self.wins,
            self.losses,
            self.technical_aborts,
            self.technical_recoveries,
            self.safe_stops,
            self.current_session.match_id if self.current_session is not None else None,
            self.current_session,
            gameplay,
            lobby,
            postmatch,
            recovery,
            self.stop_reason,
            tuple(self.attempts),
            tuple(self.input_records),
            FarmRunSafetyCounters(**asdict(self.safety)),
            tuple(self.events),
        )

    def observe_initial_lobby(self, lobby: BossLobbyState) -> bool:
        if self.state is not FarmRunState.WAIT_INITIAL_BOSS_LOBBY:
            return self._reject("initial_lobby_out_of_order")
        if lobby is not BossLobbyState.BOSS_LOBBY:
            self.safe_stop(FarmRunStopReason.FARM_START_STATE_INVALID, observed=lobby)
            return False
        self._transition(FarmRunState.RESOLVE_TARGET, "initial_boss_lobby_ready")
        return True

    def target_resolved(self, *, exact: bool = True) -> bool:
        if self.state is not FarmRunState.RESOLVE_TARGET:
            return self._reject("target_resolution_out_of_order")
        if not exact:
            self.safety.wrong_target += 1
            self.safe_stop(FarmRunStopReason.TARGET_RESOLUTION_FAILED)
            return False
        if not self._entry_budget_available():
            return False
        self._transition(FarmRunState.ENTRY_READY, "exact_target_resolved")
        return True

    def reserve_entry(self, *, foreground: bool) -> FarmInputPermit | None:
        if self.stopped:
            self.safety.input_after_farm_stop += 1
            return None
        if self.state is not FarmRunState.ENTRY_READY or self._pending is not None:
            self.safety.duplicate_lobby_entry += 1
            self.safe_stop(FarmRunStopReason.ENTRY_CAPABILITY_DENIED)
            return None
        if not self._entry_budget_available():
            return None
        if not foreground:
            self.safe_stop(FarmRunStopReason.FOREGROUND_LOST)
            return None
        permit = FarmInputPermit(
            uuid4().hex,
            FarmInputDomain.BOSS_ENTRY,
            None,
            self.match_attempts + 1,
        )
        self._pending = permit
        self._transition(FarmRunState.ENTRY_PENDING, "entry_input_reserved")
        return permit

    def complete_entry(self, permit: FarmInputPermit, *, sent: bool, detail: str = "") -> bool:
        if permit != self._pending or permit.domain is not FarmInputDomain.BOSS_ENTRY:
            self.safe_stop(FarmRunStopReason.ENTRY_CAPABILITY_DENIED)
            return False
        self._pending = None
        self._record_input(permit, sent=sent, detail=detail)
        if not sent:
            self.safe_stop(FarmRunStopReason.ENTRY_INPUT_FAILED, detail=detail)
            return False
        return True

    def cancel_entry(self, permit: FarmInputPermit, *, detail: str = "") -> bool:
        return self.complete_entry(permit, sent=False, detail=detail)

    def accept_session(self, session: CombatSessionKey, *, recovered: bool = False) -> bool:
        allowed = (
            self.state is FarmRunState.ENTRY_PENDING
            or (recovered and self.state is FarmRunState.RECOVERY_ACTIVE)
        )
        if not allowed or self._pending is not None:
            return self._reject("session_out_of_order", session=session, recovered=recovered)
        if session in self._seen_sessions or session.match_id in self._seen_match_ids:
            self.safety.stale_session_confusion += 1
            self.safe_stop(FarmRunStopReason.SESSION_REUSE_AMBIGUOUS, session=session)
            return False
        if self.match_attempts >= self.limits.max_match_attempts:
            self.safe_stop(FarmRunStopReason.MATCH_ATTEMPT_LIMIT_REACHED)
            return False
        previous = self.attempts[-1] if self.attempts else None
        if previous is not None:
            previous.next_match_id = session.match_id
        self._seen_sessions.add(session)
        self._seen_match_ids.add(session.match_id)
        self.match_attempts += 1
        self.current_session = session
        self.attempts.append(
            MatchTelemetry(
                self.match_attempts,
                session.match_id,
                session,
                utc_timestamp(),
                recovered=recovered,
            )
        )
        self._transition(
            FarmRunState.WAIT_OPENING,
            "fresh_combat_session_accepted",
            session=session,
            recovered=recovered,
        )
        return True

    def accept_opening(
        self,
        opening: OpeningEvidence,
        *,
        recovered: bool = False,
        test_only_recovery: bool = False,
    ) -> bool:
        valid_for_gameplay = opening.valid()
        valid_only_for_test_recovery = bool(
            test_only_recovery
            and not recovered
            and not opening.timer_safe
            and replace(opening, timer_safe=True).valid()
        )
        if (
            self.state is not FarmRunState.WAIT_OPENING
            or self.current_session is None
            or opening.session != self.current_session
            or not (valid_for_gameplay or valid_only_for_test_recovery)
        ):
            self.safe_stop(FarmRunStopReason.OPENING_INVARIANT_FAILED, opening=opening)
            return False
        if recovered:
            self._recovered_opening = opening
            self._transition(
                FarmRunState.RECOVERY_OPENING_READY,
                "recovery_new_combat_opening_ready",
                opening=opening,
            )
        else:
            self._test_only_recovery_required = test_only_recovery
            self._transition(
                FarmRunState.COMBAT_ACTIVE,
                (
                    "combat_opening_ready_for_test_only_recovery"
                    if test_only_recovery
                    else "combat_opening_ready"
                ),
                opening=opening,
                gameplayPermitted=(not test_only_recovery),
                timerSafeForGameplay=valid_for_gameplay,
            )
        return True

    def resume_recovered_gameplay(self, *, old_state_leak_free: bool) -> bool:
        if (
            self.state is not FarmRunState.RECOVERY_OPENING_READY
            or self.current_session is None
            or self._recovered_opening is None
        ):
            return self._reject("recovery_handoff_out_of_order")
        if not old_state_leak_free:
            self.safety.stale_session_confusion += 1
            self.safe_stop(FarmRunStopReason.RECOVERY_FAILED, detail="old state leak")
            return False
        self._transition(
            FarmRunState.COMBAT_ACTIVE,
            "recovery_handoff_to_gameplay",
            session=self.current_session,
            opening=self._recovered_opening,
            proposalReused=False,
            fullStateRereadRequired=True,
        )
        return True

    def reserve_gameplay(
        self,
        domain: FarmInputDomain,
        session: CombatSessionKey,
        *,
        foreground: bool,
    ) -> FarmInputPermit | None:
        if self.stopped:
            self.safety.input_after_farm_stop += 1
            return None
        if self._test_only_recovery_required:
            self.safety.lobby_gameplay_input += 1
            self.safe_stop(
                FarmRunStopReason.GAMEPLAY_CAPABILITY_DENIED,
                detail="initial Stage B1 combat is recovery-only",
            )
            return None
        if not domain.gameplay:
            self.safe_stop(FarmRunStopReason.GAMEPLAY_CAPABILITY_DENIED)
            return None
        if self.state is not FarmRunState.COMBAT_ACTIVE:
            if self.state is FarmRunState.WAIT_POSTMATCH:
                self.safety.postmatch_gameplay_input += 1
            else:
                self.safety.lobby_gameplay_input += 1
            self.safe_stop(FarmRunStopReason.GAMEPLAY_CAPABILITY_DENIED)
            return None
        if session != self.current_session:
            self.safety.stale_action += 1
            self.safe_stop(FarmRunStopReason.GAMEPLAY_CAPABILITY_DENIED)
            return None
        if self._pending is not None:
            self.safety.duplicate_gameplay_input += 1
            self.safe_stop(FarmRunStopReason.GAMEPLAY_CAPABILITY_DENIED)
            return None
        if not foreground:
            self.safe_stop(FarmRunStopReason.FOREGROUND_LOST)
            return None
        permit = FarmInputPermit(
            uuid4().hex, domain, session, self.match_attempts
        )
        self._pending = permit
        self._event("gameplay_input_reserved", domain=domain, session=session)
        return permit

    def complete_gameplay(
        self, permit: FarmInputPermit, *, sent: bool, detail: str = ""
    ) -> bool:
        if permit != self._pending or not permit.domain.gameplay:
            self.safe_stop(FarmRunStopReason.GAMEPLAY_CAPABILITY_DENIED)
            return False
        self._pending = None
        if permit.domain is FarmInputDomain.GAMEPLAY_PASS and sent:
            self.safe_stop(
                FarmRunStopReason.INTERNAL_INVARIANT,
                detail="PASS cannot send a Windows input",
            )
            return False
        self._record_input(permit, sent=sent, detail=detail)
        if permit.domain is not FarmInputDomain.GAMEPLAY_PASS and not sent:
            self.safe_stop(FarmRunStopReason.GAMEPLAY_CAPABILITY_DENIED, detail=detail)
            return False
        return True

    def cancel_gameplay(self, permit: FarmInputPermit, *, detail: str = "") -> bool:
        if permit != self._pending:
            self.safe_stop(FarmRunStopReason.GAMEPLAY_CAPABILITY_DENIED)
            return False
        self._pending = None
        self.safe_stop(FarmRunStopReason.GAMEPLAY_CAPABILITY_DENIED, detail=detail)
        return False

    def apply_combat_summary(self, summary: dict[str, Any]) -> None:
        attempt = self.current_attempt
        if attempt is None:
            return
        counters = summary.get("counters") or {}
        attempt.local_turns = int(summary.get("localTurnsObserved") or 0)
        attempt.boss_turns = int(summary.get("bossTurnsObserved") or 0)
        attempt.swap_sent = int(counters.get("swap_sent") or 0)
        attempt.swap_acknowledged = int(counters.get("swap_acknowledged") or 0)
        attempt.swap_rejected = int(counters.get("swap_rejected") or 0)
        attempt.cast_sent = int(counters.get("cast_sent") or 0)
        attempt.cast_accepted = int(counters.get("cast_accepted") or 0)
        attempt.cast_rejected = int(counters.get("cast_rejected") or 0)
        attempt.evolve_attempts = int(counters.get("evolve_attempts") or 0)
        attempt.evolve_failed = int(counters.get("evolve_failed") or 0)
        attempt.evolve_success = int(counters.get("evolve_success") or 0)
        attempt.pass_count = int(summary.get("passExecuted") or 0)
        attempt.dead_board = int(counters.get("dead_board") or 0)
        attempt.sequence_desync = int(counters.get("sequence_desync") or 0)

    def normal_combat_ended(self, result: MatchResult) -> bool:
        if self.state is not FarmRunState.COMBAT_ACTIVE or self.current_attempt is None:
            return self._reject("normal_combat_end_out_of_order")
        if result not in {MatchResult.WIN, MatchResult.LOSS, MatchResult.UNKNOWN}:
            self.safe_stop(FarmRunStopReason.INTERNAL_INVARIANT, result=result)
            return False
        if self._pending is not None:
            self.safe_stop(FarmRunStopReason.INTERNAL_INVARIANT, detail="pending capability")
            return False
        attempt = self.current_attempt
        attempt.result = result
        attempt.end_timestamp = utc_timestamp()
        self.completed_matches += 1
        if result is MatchResult.WIN:
            self.wins += 1
        elif result is MatchResult.LOSS:
            self.losses += 1
        self.current_session = None
        self._transition(FarmRunState.WAIT_POSTMATCH, "normal_combat_ended", result=result)
        return True

    def observe_postmatch(self) -> bool:
        if self.state is not FarmRunState.WAIT_POSTMATCH:
            return self._reject("postmatch_out_of_order")
        self.attempts[-1].normal_postmatch = True
        self._transition(FarmRunState.WAIT_BOSS_LOBBY, "normal_postmatch_observed")
        return True

    def reserve_postmatch(self, *, foreground: bool) -> FarmInputPermit | None:
        if self.state is not FarmRunState.WAIT_BOSS_LOBBY or self._pending is not None:
            self.safe_stop(FarmRunStopReason.POSTMATCH_UI_AMBIGUOUS)
            return None
        if any(
            r.domain is FarmInputDomain.POSTMATCH_CONFIRM
            and r.attempt_index == self.match_attempts
            for r in self.input_records
        ):
            self.safe_stop(FarmRunStopReason.POSTMATCH_UI_AMBIGUOUS)
            return None
        if not foreground:
            self.safe_stop(FarmRunStopReason.FOREGROUND_LOST)
            return None
        permit = FarmInputPermit(
            uuid4().hex,
            FarmInputDomain.POSTMATCH_CONFIRM,
            None,
            self.match_attempts,
        )
        self._pending = permit
        return permit

    def complete_postmatch(
        self, permit: FarmInputPermit, *, sent: bool, detail: str = ""
    ) -> bool:
        if permit != self._pending or permit.domain is not FarmInputDomain.POSTMATCH_CONFIRM:
            self.safe_stop(FarmRunStopReason.POSTMATCH_UI_AMBIGUOUS)
            return False
        self._pending = None
        self._record_input(permit, sent=sent, detail=detail)
        if not sent:
            self.safe_stop(FarmRunStopReason.POSTMATCH_UI_AMBIGUOUS, detail=detail)
            return False
        return True

    def observe_return_lobby(self, lobby: BossLobbyState) -> bool:
        if self.state is not FarmRunState.WAIT_BOSS_LOBBY:
            return self._reject("return_lobby_out_of_order")
        if lobby is not BossLobbyState.BOSS_LOBBY:
            self.safe_stop(FarmRunStopReason.RETURN_LOBBY_TIMEOUT, lobby=lobby)
            return False
        if self.completed_matches >= self.limits.target_completed_matches:
            self.stop_reason = FarmRunStopReason.FARM_TARGET_COMPLETED
            self._transition(FarmRunState.FARM_RUN_COMPLETE, "farm_target_completed")
            return True
        if self.match_attempts >= self.limits.max_match_attempts:
            self.safe_stop(FarmRunStopReason.MATCH_ATTEMPT_LIMIT_REACHED)
            return False
        self._transition(FarmRunState.RESOLVE_TARGET, "boss_lobby_ready_for_next_match")
        return True

    def technical_failure(self, reason: str) -> bool:
        if reason not in self._TECHNICAL_REASONS:
            self.safe_stop(FarmRunStopReason.COMBAT_SAFE_STOP, detail=reason)
            return False
        return self._record_technical_abort(reason=reason, test_only=False)

    def test_only_recovery_trigger(self) -> bool:
        """Record the explicit Stage B1 abandoned match without faking a fault."""
        if not self._test_only_recovery_required:
            return self._reject("test_only_recovery_not_required")
        self._test_only_recovery_required = False
        return self._record_technical_abort(reason="TEST_ONLY", test_only=True)

    def _record_technical_abort(self, *, reason: str, test_only: bool) -> bool:
        if self.state is not FarmRunState.COMBAT_ACTIVE or self.current_attempt is None:
            return self._reject("technical_failure_out_of_order", reason=reason)
        self._pending = None
        attempt = self.current_attempt
        attempt.result = MatchResult.TECHNICAL_ABORT
        attempt.end_timestamp = utc_timestamp()
        attempt.technical_recovery = True
        if reason == "SEQUENCE_DESYNC":
            attempt.sequence_desync += 1
        elif reason == "DEAD_BOARD_NO_REFRESH":
            attempt.dead_board += 1
        self.technical_aborts += 1
        self.current_session = None
        self._transition(
            FarmRunState.RECOVERY_PENDING,
            "technical_abort_recorded",
            reason=reason,
            testOnly=test_only,
            naturallyOccurringTechnicalFailure=(not test_only),
        )
        if self.technical_recoveries >= self.limits.max_technical_recoveries:
            self.safe_stop(FarmRunStopReason.RECOVERY_LIMIT_REACHED)
            return False
        if self.match_attempts >= self.limits.max_match_attempts:
            self.safe_stop(FarmRunStopReason.MATCH_ATTEMPT_LIMIT_REACHED)
            return False
        return True

    def complete_stage_b1(self, *, invariant: str) -> bool:
        if self.state is not FarmRunState.COMBAT_ACTIVE or self._pending is not None:
            return self._reject("stage_b1_completion_out_of_order")
        self.stop_reason = FarmRunStopReason.STAGE_B1_ACTION_ACCEPTED
        self.current_session = None
        self._transition(
            FarmRunState.FARM_RUN_COMPLETE,
            "stage_b1_recovery_resume_proven",
            invariant=invariant,
        )
        return True

    def begin_recovery(self) -> bool:
        if self.state is not FarmRunState.RECOVERY_PENDING:
            return self._reject("recovery_start_out_of_order")
        self._transition(FarmRunState.RECOVERY_ACTIVE, "technical_recovery_started")
        return True

    def record_successful_recovery(self, records: tuple[Any, ...]) -> bool:
        if self.state is not FarmRunState.RECOVERY_ACTIVE:
            return self._reject("recovery_completion_out_of_order")
        if self.technical_recoveries >= self.limits.max_technical_recoveries:
            self.safe_stop(FarmRunStopReason.RECOVERY_LIMIT_REACHED)
            return False
        domain_map = {
            "RECOVERY_EXIT": FarmInputDomain.RECOVERY_EXIT,
            "RECOVERY_CONFIRM": FarmInputDomain.RECOVERY_CONFIRM,
            "RECOVERY_TARGET_SELECT": FarmInputDomain.RECOVERY_TARGET_SELECT,
            "RECOVERY_REENTRY": FarmInputDomain.RECOVERY_REENTRY,
        }
        for record in records:
            raw = getattr(record, "domain", None)
            name = getattr(raw, "value", raw)
            domain = domain_map.get(str(name))
            if domain is None:
                self.safe_stop(FarmRunStopReason.RECOVERY_FAILED, detail="unknown recovery domain")
                return False
            permit = FarmInputPermit(uuid4().hex, domain, None, self.match_attempts)
            self._record_input(
                permit,
                sent=bool(getattr(record, "sent", False)),
                detail=str(getattr(record, "detail", "")),
            )
        sent_names = [r.domain for r in self.input_records if r.domain.recovery and r.sent]
        if sent_names.count(FarmInputDomain.RECOVERY_EXIT) != 1:
            self.safe_stop(FarmRunStopReason.RECOVERY_FAILED, detail="recovery Exit count")
            return False
        if sent_names.count(FarmInputDomain.RECOVERY_CONFIRM) != 1:
            self.safe_stop(FarmRunStopReason.RECOVERY_FAILED, detail="recovery confirm count")
            return False
        if sent_names.count(FarmInputDomain.RECOVERY_REENTRY) != 1:
            self.safe_stop(FarmRunStopReason.RECOVERY_FAILED, detail="recovery re-entry count")
            return False
        self.technical_recoveries += 1
        self._event("technical_recovery_completed", count=self.technical_recoveries)
        return True

    def safe_stop(self, reason: FarmRunStopReason, **detail: Any) -> None:
        if self.stopped:
            return
        if self.current_attempt is not None:
            attempt = self.current_attempt
            if attempt.end_timestamp is None:
                attempt.end_timestamp = utc_timestamp()
                attempt.result = MatchResult.SAFE_STOP
        self.current_session = None
        self._pending = None
        self.safe_stops += 1
        self.stop_reason = reason
        self._transition(FarmRunState.SAFE_STOP, "farm_run_safe_stop", reason=reason, **detail)

    def _entry_budget_available(self) -> bool:
        if self.completed_matches >= self.limits.target_completed_matches:
            self.stop_reason = FarmRunStopReason.FARM_TARGET_COMPLETED
            self._transition(FarmRunState.FARM_RUN_COMPLETE, "entry_blocked_target_complete")
            return False
        if self.match_attempts >= self.limits.max_match_attempts:
            self.safe_stop(FarmRunStopReason.MATCH_ATTEMPT_LIMIT_REACHED)
            return False
        return True

    def _record_input(self, permit: FarmInputPermit, *, sent: bool, detail: str) -> None:
        self.input_records.append(
            FarmInputRecord(
                permit.domain,
                permit.session,
                permit.attempt_index,
                sent,
                utc_timestamp(),
                detail,
            )
        )

    def _event(self, event: str, **detail: Any) -> None:
        self.events.append(
            FarmRunEvent(
                len(self.events) + 1,
                utc_timestamp(),
                event,
                self.state,
                _jsonable(detail),
            )
        )

    def _transition(self, state: FarmRunState, event: str, **detail: Any) -> None:
        old = self.state
        self.state = state
        self._event(event, oldState=old, **detail)

    def _reject(self, event: str, **detail: Any) -> bool:
        self._event(event, **detail)
        return False


class FarmRunEntryCapability:
    def __init__(self, run: FarmRun) -> None:
        self.run = run
        self.entry_number = run.match_attempts + 1

    def reserve(self, *, foreground: bool) -> FarmInputPermit | None:
        return self.run.reserve_entry(foreground=foreground)

    def complete(self, permit: FarmInputPermit, *, sent: bool, detail: str = "") -> bool:
        return self.run.complete_entry(permit, sent=sent, detail=detail)

    def cancel(self, permit: FarmInputPermit, *, detail: str = "") -> bool:
        return self.run.cancel_entry(permit, detail=detail)


_ACTION_DOMAINS = {
    "SWAP": FarmInputDomain.GAMEPLAY_SWAP,
    "CAST": FarmInputDomain.GAMEPLAY_CAST,
    "EVOLVE": FarmInputDomain.GAMEPLAY_EVOLVE,
    "PASS": FarmInputDomain.GAMEPLAY_PASS,
}


class FarmRunGameplayCapability:
    def __init__(self, run: FarmRun, session: CombatSessionKey) -> None:
        self.run = run
        self.session = session

    def reserve(
        self, *, action: str, session: CombatSessionKey, foreground: bool
    ) -> FarmInputPermit | None:
        domain = _ACTION_DOMAINS.get(action.upper())
        if domain is None:
            self.run.safe_stop(FarmRunStopReason.GAMEPLAY_CAPABILITY_DENIED, action=action)
            return None
        return self.run.reserve_gameplay(domain, session, foreground=foreground)

    def complete(self, permit: FarmInputPermit, *, sent: bool, detail: str = "") -> bool:
        return self.run.complete_gameplay(permit, sent=sent, detail=detail)

    def cancel(self, permit: FarmInputPermit, *, detail: str = "") -> bool:
        return self.run.cancel_gameplay(permit, detail=detail)


class FarmRunArtifactWriter:
    """Durable per-run audit tree under ``logs/farm_runs``."""

    def __init__(self, directory: Path) -> None:
        self.directory = directory.resolve()
        self.directory.mkdir(parents=True, exist_ok=False)
        (self.directory / "matches").mkdir()
        (self.directory / "recoveries").mkdir()
        self.events_path = self.directory / "events.jsonl"
        self.run_path = self.directory / "run.json"

    @classmethod
    def create(cls, root: Path, farm_run_id: str) -> "FarmRunArtifactWriter":
        candidate = root.resolve() / farm_run_id
        if candidate.exists():
            candidate = root.resolve() / f"{farm_run_id}_{uuid4().hex[:6]}"
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

    def finalize(self, run: FarmRun, **extra: Any) -> None:
        self.run_path.write_text(
            json.dumps(
                {
                    "schema": "pokiguard.farm_run.v1",
                    "snapshot": _jsonable(run.snapshot()),
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
    "FarmInputDomain",
    "FarmInputPermit",
    "FarmInputRecord",
    "FarmRun",
    "FarmRunArtifactWriter",
    "FarmRunEntryCapability",
    "FarmRunEvent",
    "FarmRunGameplayCapability",
    "FarmRunLimits",
    "FarmRunSafetyCounters",
    "FarmRunSnapshot",
    "FarmRunState",
    "FarmRunStopReason",
    "MatchResult",
    "MatchTelemetry",
]
