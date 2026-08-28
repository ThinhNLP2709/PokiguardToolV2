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
from typing import Any, Callable
from uuid import uuid4

from .boss_entry import BossLobbyState, FarmTarget
from .farm_checkpoint import (
    CHECKPOINT_SCHEMA,
    CheckpointPayload,
    ResumeDecision,
)
from .farm_control import FarmControlState, GracefulStopController
from .farm_cycle import OpeningEvidence
from .state import (
    CombatSessionKey,
    ResultConsistency,
    TerminalCombatSnapshot,
    TerminalResult,
    TerminalResultConfidence,
)
from .terminal_result import reconcile_results


def utc_timestamp() -> str:
    return datetime.now(timezone.utc).isoformat(timespec="milliseconds").replace(
        "+00:00", "Z"
    )


def _duration_seconds(start: str, end: str | None) -> float | None:
    if end is None:
        return None
    try:
        return max(
            0.0,
            (datetime.fromisoformat(end.replace("Z", "+00:00"))
             - datetime.fromisoformat(start.replace("Z", "+00:00"))).total_seconds(),
        )
    except ValueError:
        return None


def _epoch_seconds(timestamp: str) -> float:
    try:
        return datetime.fromisoformat(timestamp.replace("Z", "+00:00")).timestamp()
    except ValueError:
        return 0.0


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
    RESULT_CONFLICT = "RESULT_CONFLICT"
    RETURN_LOBBY_TIMEOUT = "RETURN_LOBBY_TIMEOUT"
    ROOM_EJECTED = "ROOM_EJECTED_TO_BOSS_MAP"
    FOREGROUND_LOST = "FOREGROUND_LOST"
    SAFETY_LIMIT_REACHED = "SAFETY_LIMIT_REACHED"
    COMBAT_SAFE_STOP = "COMBAT_SAFE_STOP"
    EMERGENCY_STOP = "F9_EMERGENCY_STOP"
    CONTROLLER_CONFLICT = "CONTROLLER_CONFLICT"
    STAGE_B1_ACTION_ACCEPTED = "STAGE_B1_ACTION_ACCEPTED"
    INTERNAL_INVARIANT = "FARM_RUN_INTERNAL_INVARIANT"
    STOPPED_GRACEFULLY = "STOPPED_GRACEFULLY"
    RESUME_START_STATE_UNSAFE = "RESUME_START_STATE_UNSAFE"
    CHECKPOINT_INVALID = "CHECKPOINT_INVALID"
    CHECKPOINT_SCHEMA_UNSUPPORTED = "CHECKPOINT_SCHEMA_UNSUPPORTED"
    CHECKPOINT_CONFIG_MISMATCH = "CHECKPOINT_CONFIG_MISMATCH"
    CHECKPOINT_MATCH_ID_CONFLICT = "CHECKPOINT_MATCH_ID_CONFLICT"
    CHECKPOINT_ALREADY_COMPLETED = "CHECKPOINT_ALREADY_COMPLETED"
    CHECKPOINT_NOT_RESUMABLE = "CHECKPOINT_NOT_RESUMABLE"


class MatchResult(str, Enum):
    WIN = "WIN"
    LOSS = "LOSS"
    TECHNICAL_ABORT = "TECHNICAL_ABORT"
    SAFE_STOP = "SAFE_STOP"
    UNKNOWN = "UNKNOWN"


class FarmInputDomain(str, Enum):
    BOSS_ROOM_SHELL_EXIT = "BOSS_ROOM_SHELL_EXIT"
    BOSS_ROOM_SHELL_CONFIRM = "BOSS_ROOM_SHELL_CONFIRM"
    BOSS_TARGET_SELECT = "BOSS_TARGET_SELECT"
    BOSS_CARD_SELECT = "BOSS_CARD_SELECT"
    BOSS_ENTRY = "BOSS_ENTRY"
    BOSS_ENTRY_RETRY = "BOSS_ENTRY_RETRY"
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
    # Compatibility-only checkpoint/CLI value. Successful technical recovery
    # is an operational requirement and is no longer capped over a farm run.
    # Each incident is still guarded by its own one-shot recovery coordinator.
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
    duplicate_postmatch_confirm: int = 0
    result_double_count: int = 0
    result_conflict: int = 0

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
    swap_aborted_state_changed: int = 0
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
    terminal_snapshot: TerminalCombatSnapshot | None = None
    terminal_result_confidence: TerminalResultConfidence = (
        TerminalResultConfidence.UNKNOWN
    )
    terminal_result_sources: tuple[str, ...] = ()
    terminal_local_hp: int | None = None
    terminal_boss_hp: int | None = None
    terminal_snapshot_timestamp: str | None = None
    postmatch_ui_result: TerminalResult = TerminalResult.UNKNOWN
    postmatch_ui_text: str | None = None
    result_consistency: ResultConsistency = ResultConsistency.BOTH_UNKNOWN
    duration_seconds: float | None = None
    provider_read_errors: int = 0
    provider_dto_rejections: int = 0
    provider_stale_skips: int = 0
    provider_unstable_skips: int = 0
    provider_ambiguous_latest_skips: int = 0
    provider_opening_snapshot_rejections: int = 0


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
    unknown_results: int
    technical_aborts: int
    technical_recoveries: int
    technical_exits: int
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
    unique_match_ids: tuple[str, ...]
    result_accounting_consistent: bool
    attempt_accounting_consistent: bool
    memory_terminal_result_proven: bool
    result_consistent_count: int
    memory_incomplete_count: int
    result_conflict_count: int
    total_swap_sent: int
    total_swap_acknowledged: int
    total_swap_rejected: int
    total_swap_aborted_state_changed: int
    total_cast_sent: int
    total_cast_accepted: int
    total_cast_rejected: int
    total_evolve_attempts: int
    total_evolve_failed: int
    total_evolve_success: int
    total_pass_count: int
    total_provider_read_errors: int
    total_provider_dto_rejections: int
    total_provider_stale_skips: int
    total_provider_unstable_skips: int
    total_provider_ambiguous_latest_skips: int
    total_provider_opening_snapshot_rejections: int
    start_timestamp: str
    end_timestamp: str | None
    duration_seconds: float | None
    average_match_duration_seconds: float | None
    longest_match_duration_seconds: float | None
    control_state: FarmControlState | None = None
    graceful_stop_requested_at: str | None = None
    checkpoint_seq: int = 0
    continuation_of: str | None = None


class FarmRun:
    """Single-owner, bounded multi-match state and capability ledger."""

    _TECHNICAL_REASONS = {
        "SEQUENCE_DESYNC",
        "DEAD_BOARD_NO_REFRESH",
        "ACTIONABILITY_STATE_LOST",
        "CONTROLLER_STALLED_ACTIVE_COMBAT",
        "ACTIVE_COMBAT_PROGRESS_STALLED",
        "LOCAL_PLAYER_LEFT_ACTIVE_COMBAT",
        "LATE_MANDATORY_RESET",
        "ROOM_EJECTED_TO_BOSS_MAP",
        "ENTRY_OPENING_TIMEOUT_ACTIVE_COMBAT",
    }

    def __init__(
        self,
        target: FarmTarget,
        *,
        limits: FarmRunLimits | None = None,
        farm_run_id: str | None = None,
        control: GracefulStopController | None = None,
        resume: ResumeDecision | None = None,
        continuation_of: str | None = None,
        max_retained_events: int = 4000,
    ) -> None:
        self.farm_run_id = farm_run_id or uuid4().hex
        self.target = target
        self.limits = limits or FarmRunLimits()
        self.state = FarmRunState.WAIT_INITIAL_BOSS_LOBBY
        self.match_attempts = 0
        self.completed_matches = 0
        self.wins = 0
        self.losses = 0
        self.unknown_results = 0
        self.technical_aborts = 0
        self.technical_recoveries = 0
        self.technical_exits = 0
        self.safe_stops = 0
        self.current_session: CombatSessionKey | None = None
        self.stop_reason: FarmRunStopReason | None = None
        self.attempts: list[MatchTelemetry] = []
        self.input_records: list[FarmInputRecord] = []
        self.safety = FarmRunSafetyCounters()
        self.events: list[FarmRunEvent] = []
        self._max_retained_events = max(1, int(max_retained_events))
        self._event_index = 0
        self._seen_sessions: set[CombatSessionKey] = set()
        self._seen_match_ids: set[str] = set()
        self._pending: FarmInputPermit | None = None
        self._recovered_opening: OpeningEvidence | None = None
        self._test_only_recovery_required = False
        self._ejected_map_reentry_pending = False
        self._control = control
        self.continuation_of = continuation_of
        self.checkpoint_seq = 0
        self.resumed = False
        self.historical_counters: dict[str, int] = {}
        self.historical_action_aggregates: dict[str, int] = {}
        self.historical_consistency_aggregates: dict[str, int] = {}
        self.historical_last_completed_match_id: str | None = None
        self.start_timestamp = utc_timestamp()
        self.end_timestamp: str | None = None
        self._event("farm_run_created", target=target, limits=self.limits)
        if resume is not None:
            self._seed_from_resume(resume)

    def _seed_from_resume(self, resume: ResumeDecision) -> None:
        """Restore durable HISTORY only.  No executable gameplay state ever."""
        if not resume.allowed:
            self.safe_stop(
                FarmRunStopReason.CHECKPOINT_INVALID,
                detail=resume.reason or "resume not allowed",
            )
            return
        counters = resume.historical_counters
        self.match_attempts = int(counters.get("match_attempts", 0))
        self.completed_matches = int(counters.get("completed_matches", 0))
        self.wins = int(counters.get("wins", 0))
        self.losses = int(counters.get("losses", 0))
        self.unknown_results = int(counters.get("unknown_results", 0))
        self.technical_aborts = int(counters.get("technical_aborts", 0))
        self.technical_recoveries = int(counters.get("technical_recoveries", 0))
        self.technical_exits = int(counters.get("technical_exits", 0))
        self._seen_match_ids.update(resume.seen_match_ids)
        self.resumed = True
        self.historical_counters = dict(counters)
        self.historical_action_aggregates = dict(
            resume.historical_action_aggregates
        )
        self.historical_consistency_aggregates = dict(
            resume.historical_consistency_aggregates
        )
        self.historical_last_completed_match_id = resume.last_completed_match_id
        if resume.run_started_at > 0:
            self.start_timestamp = (
                datetime.fromtimestamp(resume.run_started_at, tz=timezone.utc)
                .isoformat(timespec="milliseconds")
                .replace("+00:00", "Z")
            )
        self._event(
            "farm_run_resumed_from_checkpoint",
            continuationOf=self.continuation_of,
            historicalCompleted=self.completed_matches,
            remainingCompleted=resume.remaining_completed,
            seenMatchIds=len(self._seen_match_ids),
            executableGameplayStateRestored=False,
        )

    def graceful_stop_requested(self) -> bool:
        return self._control is not None and self._control.state is not FarmControlState.RUNNING

    def graceful_stop_request(
        self, *, lifecycle: str, match_id: str | None
    ) -> bool:
        """Accept one operator graceful-stop press.  Edge-triggered, idempotent."""
        now = _epoch_seconds(utc_timestamp())
        if self._control is None:
            self._control = GracefulStopController(timestamp=now)
        accepted = self._control.request_graceful_stop(
            timestamp=now,
            farm_state=self.state.value,
            lifecycle=lifecycle,
            match_id=match_id,
        )
        if not accepted:
            self._event("graceful_stop_duplicate_ignored", controlState=self._control.state.value)
            return False
        self._event(
            "graceful_stop_requested",
            lifecycle=lifecycle,
            matchId=match_id,
            farmState=self.state.value,
        )
        # Irrevocability is scoped to the entry permit that is currently in
        # flight.  Once a match has drained back to the lobby, a later stop
        # request must be allowed to stop immediately at the lobby even though
        # an earlier entry was sent.
        entry_pending_irrevocable = (
            self.state is FarmRunState.ENTRY_PENDING
            and self._control.snapshot().entry_irrevocably_sent
        )
        if (
            self.current_session is None
            and not entry_pending_irrevocable
            and self.state in {
                FarmRunState.WAIT_INITIAL_BOSS_LOBBY,
                FarmRunState.RESOLVE_TARGET,
                FarmRunState.ENTRY_READY,
                FarmRunState.ENTRY_PENDING,
            }
        ):
            # At or before boss entry: no match in flight, stop now.
            self._control.stop_at_lobby()
            self.stop_reason = FarmRunStopReason.STOPPED_GRACEFULLY
            self.end_timestamp = utc_timestamp()
            self.current_session = None
            self._pending = None
            self._transition(
                FarmRunState.FARM_RUN_COMPLETE, "graceful_stop_at_boss_lobby"
            )
        elif self.current_session is not None:
            self._control.mark_draining_current_match()
        return True

    def checkpoint_payload(self, *, finalized_status: str | None = None) -> CheckpointPayload:
        snapshot = self.snapshot()
        self.checkpoint_seq += 1
        now = _epoch_seconds(utc_timestamp())
        control = self._control.snapshot() if self._control is not None else None
        return CheckpointPayload(
            schema_version=CHECKPOINT_SCHEMA,
            farm_run_id=self.farm_run_id,
            continuation_of=self.continuation_of,
            checkpoint_seq=self.checkpoint_seq,
            created_at=_epoch_seconds(self.start_timestamp),
            updated_at=now,
            target_boss_id=str(self.target.boss_id),
            target_boss_name=str(self.target.boss_name or ""),
            configured_limits={
                "target_completed_matches": self.limits.target_completed_matches,
                "max_technical_recoveries": self.limits.max_technical_recoveries,
                "max_match_attempts": self.limits.max_match_attempts,
            },
            run_started_at=_epoch_seconds(self.start_timestamp),
            match_attempts=self.match_attempts,
            completed_matches=self.completed_matches,
            wins=self.wins,
            losses=self.losses,
            unknown_results=self.unknown_results,
            technical_aborts=self.technical_aborts,
            technical_recoveries=self.technical_recoveries,
            technical_exits=self.technical_exits,
            last_completed_match_id=next(
                (
                    item.match_id
                    for item in reversed(self.attempts)
                    if item.end_timestamp is not None
                    and item.result
                    in {MatchResult.WIN, MatchResult.LOSS, MatchResult.UNKNOWN}
                ),
                self.historical_last_completed_match_id,
            ),
            seen_match_ids=tuple(sorted(self._seen_match_ids)),
            action_aggregates={
                "swap_sent": snapshot.total_swap_sent,
                "swap_acknowledged": snapshot.total_swap_acknowledged,
                "swap_rejected": snapshot.total_swap_rejected,
                "swap_aborted_state_changed": (
                    snapshot.total_swap_aborted_state_changed
                ),
                "cast_sent": snapshot.total_cast_sent,
                "cast_accepted": snapshot.total_cast_accepted,
                "cast_rejected": snapshot.total_cast_rejected,
                "evolve_attempts": snapshot.total_evolve_attempts,
                "evolve_success": snapshot.total_evolve_success,
                "evolve_failed": snapshot.total_evolve_failed,
            },
            pass_totals=snapshot.total_pass_count,
            consistency_aggregates={
                "consistent": snapshot.result_consistent_count,
                "memory_incomplete": snapshot.memory_incomplete_count,
                "conflicts": snapshot.result_conflict_count,
                "strong_terminal_results": (
                    self.historical_consistency_aggregates.get(
                        "strong_terminal_results", 0
                    )
                    + sum(
                        item.terminal_result_confidence
                        is TerminalResultConfidence.STRONG
                        and item.result in {MatchResult.WIN, MatchResult.LOSS}
                        and item.end_timestamp is not None
                        for item in self.attempts
                    )
                ),
            },
            last_safe_lifecycle="BOSS_LOBBY",
            stop_request_state=(control.state.value if control is not None else None),
            stop_reason=(self.stop_reason.value if self.stop_reason is not None else None),
            finalized_status=finalized_status,
        )

    def record_technical_exit(self, records: Any) -> bool:
        """Graceful stop during recovery: exit to lobby, never re-enter."""
        exits = confirms = reentries = 0
        domain_map = {
            "RECOVERY_EXIT": FarmInputDomain.RECOVERY_EXIT,
            "RECOVERY_CONFIRM": FarmInputDomain.RECOVERY_CONFIRM,
            "RECOVERY_TARGET_SELECT": FarmInputDomain.RECOVERY_TARGET_SELECT,
            "RECOVERY_REENTRY": FarmInputDomain.RECOVERY_REENTRY,
        }
        for record in records:
            raw = getattr(record, "domain", None)
            domain = domain_map.get(str(getattr(raw, "value", raw)))
            if domain is None:
                self.safe_stop(
                    FarmRunStopReason.RECOVERY_FAILED,
                    detail="unknown technical-exit recovery domain",
                )
                return False
            sent = bool(getattr(record, "sent", False))
            permit = FarmInputPermit(uuid4().hex, domain, None, self.match_attempts)
            self._record_input(
                permit,
                sent=sent,
                detail=str(getattr(record, "detail", "")),
            )
            if domain is FarmInputDomain.RECOVERY_EXIT and sent:
                exits += 1
            elif domain is FarmInputDomain.RECOVERY_CONFIRM and sent:
                confirms += 1
            elif domain is FarmInputDomain.RECOVERY_REENTRY and sent:
                reentries += 1
        if reentries:
            self.safe_stop(
                FarmRunStopReason.INTERNAL_INVARIANT,
                detail="technical exit must not re-enter a match",
            )
            return False
        if exits != 1 or confirms != 1:
            self.safe_stop(
                FarmRunStopReason.RECOVERY_FAILED, detail="technical exit input count"
            )
            return False
        self.technical_exits += 1
        if self._control is not None:
            self._control.suppress_recovery_reentry()
            self._control.stop_at_lobby()
        self.end_timestamp = utc_timestamp()
        self._transition(
            FarmRunState.FARM_RUN_COMPLETE,
            "technical_exit_completed_no_reentry",
            technicalExits=self.technical_exits,
        )
        self.stop_reason = FarmRunStopReason.STOPPED_GRACEFULLY
        return True

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
            if r.domain
            in {
                FarmInputDomain.BOSS_ROOM_SHELL_EXIT,
                FarmInputDomain.BOSS_ROOM_SHELL_CONFIRM,
                FarmInputDomain.BOSS_TARGET_SELECT,
                FarmInputDomain.BOSS_CARD_SELECT,
                FarmInputDomain.BOSS_ENTRY,
                FarmInputDomain.BOSS_ENTRY_RETRY,
            }
        )
        postmatch = sum(
            r.sent for r in self.input_records if r.domain is FarmInputDomain.POSTMATCH_CONFIRM
        )
        recovery = sum(r.sent for r in self.input_records if r.domain.recovery)
        consistent = self.historical_consistency_aggregates.get("consistent", 0) + sum(
            item.result_consistency is ResultConsistency.CONSISTENT
            for item in self.attempts
        )
        memory_incomplete = self.historical_consistency_aggregates.get(
            "memory_incomplete", 0
        ) + sum(
            item.result_consistency is ResultConsistency.MEMORY_INCOMPLETE
            for item in self.attempts
        )
        conflicts = self.historical_consistency_aggregates.get("conflicts", 0) + sum(
            item.result_consistency is ResultConsistency.RESULT_CONFLICT
            for item in self.attempts
        )
        accounting_consistent = (
            self.wins + self.losses + self.unknown_results
            == self.completed_matches
        )
        explicit_other_aborts = sum(
            item.result is MatchResult.SAFE_STOP for item in self.attempts
        )
        attempt_accounting_consistent = (
            self.match_attempts
            == self.completed_matches + self.technical_aborts + explicit_other_aborts
        )
        current_strong_results = sum(
            item.terminal_result_confidence is TerminalResultConfidence.STRONG
            and item.result in {MatchResult.WIN, MatchResult.LOSS}
            and item.end_timestamp is not None
            for item in self.attempts
        )
        memory_proven = bool(
            self.completed_matches > 0
            and self.historical_consistency_aggregates.get(
                "strong_terminal_results", 0
            )
            + current_strong_results
            == self.completed_matches
        )
        duration = _duration_seconds(self.start_timestamp, self.end_timestamp)
        match_durations = [
            item.duration_seconds
            for item in self.attempts
            if item.duration_seconds is not None
        ]
        return FarmRunSnapshot(
            self.farm_run_id,
            self.target,
            self.limits,
            self.state,
            self.match_attempts,
            self.completed_matches,
            self.wins,
            self.losses,
            self.unknown_results,
            self.technical_aborts,
            self.technical_recoveries,
            self.technical_exits,
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
            tuple(sorted(self._seen_match_ids)),
            accounting_consistent,
            attempt_accounting_consistent,
            memory_proven,
            consistent,
            memory_incomplete,
            conflicts,
            self.historical_action_aggregates.get("swap_sent", 0)
            + sum(item.swap_sent for item in self.attempts),
            self.historical_action_aggregates.get("swap_acknowledged", 0)
            + sum(item.swap_acknowledged for item in self.attempts),
            self.historical_action_aggregates.get("swap_rejected", 0)
            + sum(item.swap_rejected for item in self.attempts),
            self.historical_action_aggregates.get(
                "swap_aborted_state_changed", 0
            )
            + sum(item.swap_aborted_state_changed for item in self.attempts),
            self.historical_action_aggregates.get("cast_sent", 0)
            + sum(item.cast_sent for item in self.attempts),
            self.historical_action_aggregates.get("cast_accepted", 0)
            + sum(item.cast_accepted for item in self.attempts),
            self.historical_action_aggregates.get("cast_rejected", 0)
            + sum(item.cast_rejected for item in self.attempts),
            self.historical_action_aggregates.get("evolve_attempts", 0)
            + sum(item.evolve_attempts for item in self.attempts),
            self.historical_action_aggregates.get("evolve_failed", 0)
            + sum(item.evolve_failed for item in self.attempts),
            self.historical_action_aggregates.get("evolve_success", 0)
            + sum(item.evolve_success for item in self.attempts),
            self.historical_counters.get("pass_totals", 0)
            + sum(item.pass_count for item in self.attempts),
            sum(item.provider_read_errors for item in self.attempts),
            sum(item.provider_dto_rejections for item in self.attempts),
            sum(item.provider_stale_skips for item in self.attempts),
            sum(item.provider_unstable_skips for item in self.attempts),
            sum(item.provider_ambiguous_latest_skips for item in self.attempts),
            sum(
                item.provider_opening_snapshot_rejections
                for item in self.attempts
            ),
            self.start_timestamp,
            self.end_timestamp,
            duration,
            (
                sum(match_durations) / len(match_durations)
                if match_durations
                else None
            ),
            max(match_durations) if match_durations else None,
            (
                self._control.state if self._control is not None else None
            ),
            (
                datetime.fromtimestamp(
                    self._control.request.requested_at, tz=timezone.utc
                )
                .isoformat(timespec="milliseconds")
                .replace("+00:00", "Z")
                if self._control is not None and self._control.request is not None
                else None
            ),
            self.checkpoint_seq,
            self.continuation_of,
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
        # Hard graceful-stop gate.  GRACEFUL_STOP_NO_NEW_ENTRY_PROVEN lives here.
        if (
            self._control is not None
            and not self._control.entry_allowed()
        ):
            self._event("entry_denied_graceful_stop", controlState=self._control.state.value)
            self.stop_reason = FarmRunStopReason.STOPPED_GRACEFULLY
            self.end_timestamp = utc_timestamp()
            self.current_session = None
            self._pending = None
            self._transition(
                FarmRunState.FARM_RUN_COMPLETE,
                "graceful_stop_blocked_new_entry",
            )
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

    def reserve_lobby_card_select(
        self,
        *,
        foreground: bool,
        exact_attack_identity: bool,
        no_combat_owner: bool,
        selected_attack_missing: bool,
        unique_room_attack: bool,
    ) -> FarmInputPermit | None:
        """Reserve one exact Attack-card Toggle before the next entry.

        Card selection is ordinary lobby UI input.  It never creates a match
        and leaves the run in ``ENTRY_READY`` so the independent Start permit
        is still required afterwards.
        """

        attempt_index = self.match_attempts + 1
        if self.stopped:
            self.safety.input_after_farm_stop += 1
            return None
        if (
            self.state is not FarmRunState.ENTRY_READY
            or self._pending is not None
            or not foreground
            or not exact_attack_identity
            or not no_combat_owner
            or not selected_attack_missing
            or not unique_room_attack
        ):
            if not foreground:
                self.safe_stop(FarmRunStopReason.FOREGROUND_LOST)
            else:
                self.safe_stop(
                    FarmRunStopReason.ENTRY_CAPABILITY_DENIED,
                    detail="pre-entry Attack-card selection proof rejected",
                )
            return None
        if any(
            record.domain is FarmInputDomain.BOSS_CARD_SELECT
            and record.attempt_index == attempt_index
            and record.sent
            for record in self.input_records
        ):
            self.safety.duplicate_lobby_entry += 1
            self.safe_stop(
                FarmRunStopReason.ENTRY_CAPABILITY_DENIED,
                detail="duplicate pre-entry Attack-card selection",
            )
            return None
        permit = FarmInputPermit(
            uuid4().hex,
            FarmInputDomain.BOSS_CARD_SELECT,
            None,
            attempt_index,
        )
        self._pending = permit
        self._event("boss_card_select_reserved", attemptIndex=attempt_index)
        return permit

    def complete_lobby_card_select(
        self, permit: FarmInputPermit, *, sent: bool, detail: str = ""
    ) -> bool:
        if (
            permit != self._pending
            or permit.domain is not FarmInputDomain.BOSS_CARD_SELECT
        ):
            self.safe_stop(
                FarmRunStopReason.ENTRY_CAPABILITY_DENIED,
                detail="pre-entry Attack-card capability mismatch",
            )
            return False
        self._pending = None
        self._record_input(permit, sent=sent, detail=detail)
        if not sent:
            self.safe_stop(FarmRunStopReason.ENTRY_INPUT_FAILED, detail=detail)
            return False
        return True

    def complete_entry(self, permit: FarmInputPermit, *, sent: bool, detail: str = "") -> bool:
        if permit != self._pending or permit.domain is not FarmInputDomain.BOSS_ENTRY:
            self.safe_stop(FarmRunStopReason.ENTRY_CAPABILITY_DENIED)
            return False
        self._pending = None
        self._record_input(permit, sent=sent, detail=detail)
        if not sent:
            self.safe_stop(FarmRunStopReason.ENTRY_INPUT_FAILED, detail=detail)
            return False
        if self._control is not None:
            # Input already sent: this match becomes the draining current match.
            self._control.mark_entry_irrevocable()
        return True

    def reserve_entry_retry(
        self,
        *,
        foreground: bool,
        exact_same_target: bool,
        no_combat_owner: bool,
        stable_same_button: bool,
    ) -> FarmInputPermit | None:
        """Reserve one lag-response retry for the already pending entry.

        This never starts a second farm attempt.  The caller must independently
        re-prove that the first Start click created no session and that the
        exact same room target and Start control remain stable.
        """

        attempt_index = self.match_attempts + 1
        if self.stopped:
            self.safety.input_after_farm_stop += 1
            return None
        if (
            self.state is not FarmRunState.ENTRY_PENDING
            or self._pending is not None
            or self.current_session is not None
            or not foreground
            or not exact_same_target
            or not no_combat_owner
            or not stable_same_button
        ):
            if not foreground:
                self.safe_stop(FarmRunStopReason.FOREGROUND_LOST)
            else:
                self.safe_stop(
                    FarmRunStopReason.ENTRY_CAPABILITY_DENIED,
                    detail="entry retry proof rejected",
                )
            return None
        if self._control is not None and not self._control.entry_allowed():
            self.safe_stop(
                FarmRunStopReason.ENTRY_CAPABILITY_DENIED,
                detail="entry retry denied by graceful-stop gate",
            )
            return None
        first_entries = [
            record
            for record in self.input_records
            if record.domain is FarmInputDomain.BOSS_ENTRY
            and record.attempt_index == attempt_index
            and record.sent
        ]
        prior_retries = [
            record
            for record in self.input_records
            if record.domain is FarmInputDomain.BOSS_ENTRY_RETRY
            and record.attempt_index == attempt_index
            and record.sent
        ]
        if len(first_entries) != 1 or prior_retries:
            self.safety.duplicate_lobby_entry += 1
            self.safe_stop(
                FarmRunStopReason.ENTRY_CAPABILITY_DENIED,
                detail="entry retry missing first click or duplicated",
            )
            return None
        permit = FarmInputPermit(
            uuid4().hex,
            FarmInputDomain.BOSS_ENTRY_RETRY,
            None,
            attempt_index,
        )
        self._pending = permit
        self._event("entry_retry_reserved", attemptIndex=attempt_index)
        return permit

    def complete_entry_retry(
        self, permit: FarmInputPermit, *, sent: bool, detail: str = ""
    ) -> bool:
        if (
            permit != self._pending
            or permit.domain is not FarmInputDomain.BOSS_ENTRY_RETRY
        ):
            self.safe_stop(FarmRunStopReason.ENTRY_CAPABILITY_DENIED)
            return False
        self._pending = None
        self._record_input(permit, sent=sent, detail=detail)
        if not sent:
            self.safe_stop(FarmRunStopReason.ENTRY_INPUT_FAILED, detail=detail)
            return False
        self._event("entry_retry_sent", attemptIndex=permit.attempt_index)
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
            reason = (
                FarmRunStopReason.CHECKPOINT_MATCH_ID_CONFLICT
                if self.resumed
                else FarmRunStopReason.SESSION_REUSE_AMBIGUOUS
            )
            self.safe_stop(reason, session=session)
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

    def abandon_pass_preflight(
        self, permit: FarmInputPermit, *, detail: str = ""
    ) -> bool:
        """Release an unsent PASS permit after a transient final preflight.

        PASS is the only gameplay domain with deliberately zero Windows
        input.  A board-only state can lose its optional local participant
        snapshot between policy selection and the final authoritative PASS
        validation.  Releasing that one zero-input permit is safe; it neither
        counts a PASS nor grants a second physical-input capability.  Every
        other domain or capability mismatch still fails closed.
        """

        if (
            permit != self._pending
            or permit.domain is not FarmInputDomain.GAMEPLAY_PASS
        ):
            self.safe_stop(FarmRunStopReason.GAMEPLAY_CAPABILITY_DENIED)
            return False
        self._pending = None
        self._record_input(permit, sent=False, detail=detail)
        self._event(
            "gameplay_pass_preflight_abandoned",
            session=permit.session,
            detail=detail,
            windowsInputSent=False,
        )
        return True

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
        attempt.swap_aborted_state_changed = int(
            summary.get("swapAbortedDueLifecycle") or 0
        )
        attempt.cast_sent = int(counters.get("cast_sent") or 0)
        attempt.cast_accepted = int(counters.get("cast_accepted") or 0)
        attempt.cast_rejected = int(counters.get("cast_rejected") or 0)
        attempt.evolve_attempts = int(counters.get("evolve_attempts") or 0)
        attempt.evolve_failed = int(counters.get("evolve_failed") or 0)
        attempt.evolve_success = int(counters.get("evolve_success") or 0)
        attempt.pass_count = int(summary.get("passExecuted") or 0)
        attempt.dead_board = int(counters.get("dead_board") or 0)
        attempt.sequence_desync = int(counters.get("sequence_desync") or 0)
        provider = summary.get("providerMetrics") or {}
        prior_attempts = self.attempts[:-1]
        attempt.provider_read_errors = max(
            0,
            int(provider.get("read_errors") or 0)
            - sum(item.provider_read_errors for item in prior_attempts),
        )
        attempt.provider_dto_rejections = max(
            0,
            int(provider.get("dto_rejections") or 0)
            - sum(item.provider_dto_rejections for item in prior_attempts),
        )
        attempt.provider_stale_skips = max(
            0,
            int(provider.get("stale_skips") or 0)
            - sum(item.provider_stale_skips for item in prior_attempts),
        )
        attempt.provider_unstable_skips = max(
            0,
            int(provider.get("unstable_skips") or 0)
            - sum(item.provider_unstable_skips for item in prior_attempts),
        )
        attempt.provider_ambiguous_latest_skips = max(
            0,
            int(provider.get("ambiguous_latest_skips") or 0)
            - sum(
                item.provider_ambiguous_latest_skips for item in prior_attempts
            ),
        )
        attempt.provider_opening_snapshot_rejections = max(
            0,
            int(provider.get("opening_snapshot_rejections") or 0)
            - sum(
                item.provider_opening_snapshot_rejections
                for item in prior_attempts
            ),
        )

    def normal_combat_ended(
        self, result: MatchResult | TerminalCombatSnapshot
    ) -> bool:
        terminal = result if isinstance(result, TerminalCombatSnapshot) else None
        if (
            self.state in {FarmRunState.WAIT_POSTMATCH, FarmRunState.WAIT_BOSS_LOBBY}
            and self.attempts
            and self.attempts[-1].end_timestamp is not None
            and (
                terminal is None
                or terminal.match_id == self.attempts[-1].match_id
            )
        ):
            # Repeated POSTMATCH provider polling is expected.  It is an
            # idempotent observation, not a second accounting operation.
            self._event(
                "duplicate_terminal_observation_ignored",
                matchId=self.attempts[-1].match_id,
            )
            return True
        if self.state is not FarmRunState.COMBAT_ACTIVE or self.current_attempt is None:
            self.safety.result_double_count += 1
            return self._reject("normal_combat_end_out_of_order")
        if terminal is not None:
            if (
                terminal.session_key != self.current_session
                or terminal.match_id != self.current_attempt.match_id
            ):
                self.safety.stale_session_confusion += 1
                self.safe_stop(
                    FarmRunStopReason.INTERNAL_INVARIANT,
                    detail="terminal snapshot session mismatch",
                )
                return False
            if (
                terminal.result is TerminalResult.UNKNOWN
                and terminal.confidence is TerminalResultConfidence.UNKNOWN
                and not terminal.evidence_sources
            ):
                # Lifecycle loss alone is not a normal terminal result. In
                # particular, an abrupt room ejection can clear Board/Active
                # before any HP/event/UI evidence is captured. Never turn
                # that technical disappearance into a completed UNKNOWN.
                self.safe_stop(
                    FarmRunStopReason.COMBAT_SAFE_STOP,
                    detail="COMBAT_TERMINAL_UNPROVEN",
                )
                return False
            result = {
                TerminalResult.WIN: MatchResult.WIN,
                TerminalResult.LOSS: MatchResult.LOSS,
                TerminalResult.UNKNOWN: MatchResult.UNKNOWN,
            }[terminal.result]
        if result not in {MatchResult.WIN, MatchResult.LOSS, MatchResult.UNKNOWN}:
            self.safe_stop(FarmRunStopReason.INTERNAL_INVARIANT, result=result)
            return False
        if self._pending is not None:
            self.safe_stop(FarmRunStopReason.INTERNAL_INVARIANT, detail="pending capability")
            return False
        attempt = self.current_attempt
        attempt.result = result
        attempt.end_timestamp = utc_timestamp()
        attempt.duration_seconds = _duration_seconds(
            attempt.start_timestamp, attempt.end_timestamp
        )
        if terminal is not None:
            attempt.terminal_snapshot = terminal
            attempt.terminal_result_confidence = terminal.confidence
            attempt.terminal_result_sources = terminal.evidence_sources
            attempt.terminal_local_hp = terminal.local_hp
            attempt.terminal_boss_hp = terminal.boss_hp
            attempt.terminal_snapshot_timestamp = terminal.timestamp
            attempt.postmatch_ui_result = terminal.ui_result
            attempt.postmatch_ui_text = terminal.ui_text
            attempt.result_consistency = reconcile_results(
                terminal.result, terminal.ui_result
            )
        self.completed_matches += 1
        if result is MatchResult.WIN:
            self.wins += 1
        elif result is MatchResult.LOSS:
            self.losses += 1
        else:
            self.unknown_results += 1
        if self.wins + self.losses + self.unknown_results != self.completed_matches:
            self.safe_stop(
                FarmRunStopReason.INTERNAL_INVARIANT,
                detail="RESULT_ACCOUNTING_INCONSISTENT",
            )
            return False
        self.current_session = None
        self._transition(FarmRunState.WAIT_POSTMATCH, "normal_combat_ended", result=result)
        return True

    def record_postmatch_ui_audit(
        self, ui_result: TerminalResult, *, ui_text: str | None = None
    ) -> ResultConsistency | None:
        if not self.attempts or self.attempts[-1].end_timestamp is None:
            self._reject("postmatch_ui_audit_out_of_order")
            return None
        attempt = self.attempts[-1]
        memory = {
            MatchResult.WIN: TerminalResult.WIN,
            MatchResult.LOSS: TerminalResult.LOSS,
        }.get(attempt.result, TerminalResult.UNKNOWN)
        prior = attempt.result_consistency
        attempt.postmatch_ui_result = ui_result
        attempt.postmatch_ui_text = ui_text
        attempt.result_consistency = reconcile_results(memory, ui_result)
        if (
            attempt.result_consistency is ResultConsistency.RESULT_CONFLICT
            and prior is not ResultConsistency.RESULT_CONFLICT
        ):
            self.safety.result_conflict += 1
        self._event(
            "result_ui_audit",
            matchId=attempt.match_id,
            memoryResult=memory,
            uiResult=ui_result,
            resultConsistency=attempt.result_consistency,
            uiText=ui_text,
        )
        return attempt.result_consistency

    def observe_postmatch(self) -> bool:
        if self.state is FarmRunState.WAIT_BOSS_LOBBY:
            return True
        if self.state is not FarmRunState.WAIT_POSTMATCH:
            return self._reject("postmatch_out_of_order")
        if self._control is not None and self.graceful_stop_requested():
            self._control.mark_draining_postmatch()
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
            self.safety.duplicate_postmatch_confirm += 1
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

    def reserve_target_select(
        self,
        *,
        foreground: bool,
        direct_map_after_shell_exit: bool = False,
    ) -> FarmInputPermit | None:
        """Reserve one exact-target map selection while returning to the lobby.

        This is ordinary lobby UI input, never gameplay and never a new combat
        entry.  It is permitted while gracefully draining because reaching the
        exact selected boss room is the required safe stop boundary.
        """

        if self.stopped:
            self.safety.input_after_farm_stop += 1
            return None
        if self.state is not FarmRunState.WAIT_BOSS_LOBBY or self._pending is not None:
            self.safety.duplicate_lobby_entry += 1
            self.safe_stop(
                FarmRunStopReason.RETURN_LOBBY_TIMEOUT,
                detail="target selection reserved outside return-to-lobby state",
            )
            return None
        if any(
            record.domain is FarmInputDomain.BOSS_TARGET_SELECT
            and record.attempt_index == self.match_attempts
            and record.sent
            for record in self.input_records
        ):
            self.safety.duplicate_lobby_entry += 1
            self.safe_stop(
                FarmRunStopReason.RETURN_LOBBY_TIMEOUT,
                detail="duplicate target selection in one return transition",
            )
            return None
        shell_exit_sent = any(
            record.domain is FarmInputDomain.BOSS_ROOM_SHELL_EXIT
            and record.attempt_index == self.match_attempts
            and record.sent
            for record in self.input_records
        )
        shell_confirm_sent = any(
            record.domain is FarmInputDomain.BOSS_ROOM_SHELL_CONFIRM
            and record.attempt_index == self.match_attempts
            and record.sent
            for record in self.input_records
        )
        if shell_exit_sent and not shell_confirm_sent and not direct_map_after_shell_exit:
            self.safety.duplicate_lobby_entry += 1
            self.safe_stop(
                FarmRunStopReason.RETURN_LOBBY_TIMEOUT,
                detail="target selection attempted before room-shell leave confirmation",
            )
            return None
        if not foreground:
            self.safe_stop(FarmRunStopReason.FOREGROUND_LOST)
            return None
        permit = FarmInputPermit(
            uuid4().hex,
            FarmInputDomain.BOSS_TARGET_SELECT,
            None,
            self.match_attempts,
        )
        self._pending = permit
        self._event("boss_target_select_reserved", attemptIndex=self.match_attempts)
        return permit

    def complete_target_select(
        self, permit: FarmInputPermit, *, sent: bool, detail: str = ""
    ) -> bool:
        if (
            permit != self._pending
            or permit.domain is not FarmInputDomain.BOSS_TARGET_SELECT
        ):
            self.safe_stop(
                FarmRunStopReason.RETURN_LOBBY_TIMEOUT,
                detail="target selection capability mismatch",
            )
            return False
        self._pending = None
        self._record_input(permit, sent=sent, detail=detail)
        if not sent:
            self.safe_stop(FarmRunStopReason.RETURN_LOBBY_TIMEOUT, detail=detail)
            return False
        return True

    def reserve_room_shell_exit(self, *, foreground: bool) -> FarmInputPermit | None:
        """Reserve one normal close click for a detached postmatch room shell.

        This capability exists only while returning from a completed match.
        It does not enter combat and it cannot be reused in the same return
        transition.  The caller owns the independent visual/runtime proof.
        """

        if self.stopped:
            self.safety.input_after_farm_stop += 1
            return None
        if self.state is not FarmRunState.WAIT_BOSS_LOBBY or self._pending is not None:
            self.safety.duplicate_lobby_entry += 1
            self.safe_stop(
                FarmRunStopReason.RETURN_LOBBY_TIMEOUT,
                detail="room-shell exit reserved outside return-to-lobby state",
            )
            return None
        if any(
            record.domain is FarmInputDomain.BOSS_ROOM_SHELL_EXIT
            and record.attempt_index == self.match_attempts
            and record.sent
            for record in self.input_records
        ):
            self.safety.duplicate_lobby_entry += 1
            self.safe_stop(
                FarmRunStopReason.RETURN_LOBBY_TIMEOUT,
                detail="duplicate room-shell exit in one return transition",
            )
            return None
        if not foreground:
            self.safe_stop(FarmRunStopReason.FOREGROUND_LOST)
            return None
        permit = FarmInputPermit(
            uuid4().hex,
            FarmInputDomain.BOSS_ROOM_SHELL_EXIT,
            None,
            self.match_attempts,
        )
        self._pending = permit
        self._event("boss_room_shell_exit_reserved", attemptIndex=self.match_attempts)
        return permit

    def complete_room_shell_exit(
        self, permit: FarmInputPermit, *, sent: bool, detail: str = ""
    ) -> bool:
        if (
            permit != self._pending
            or permit.domain is not FarmInputDomain.BOSS_ROOM_SHELL_EXIT
        ):
            self.safe_stop(
                FarmRunStopReason.RETURN_LOBBY_TIMEOUT,
                detail="room-shell exit capability mismatch",
            )
            return False
        self._pending = None
        self._record_input(permit, sent=sent, detail=detail)
        if not sent:
            self.safe_stop(FarmRunStopReason.RETURN_LOBBY_TIMEOUT, detail=detail)
            return False
        return True

    def reserve_room_shell_confirm(self, *, foreground: bool) -> FarmInputPermit | None:
        """Reserve the single modal confirmation after a detached-shell close.

        The confirmation is ordinary postmatch lobby navigation.  It is kept
        separate from technical-recovery confirmation so acceptance telemetry
        cannot misclassify a normal detached-shell repair as a recovery.
        """

        if self.stopped:
            self.safety.input_after_farm_stop += 1
            return None
        if self.state is not FarmRunState.WAIT_BOSS_LOBBY or self._pending is not None:
            self.safety.duplicate_lobby_entry += 1
            self.safe_stop(
                FarmRunStopReason.RETURN_LOBBY_TIMEOUT,
                detail="room-shell confirmation reserved outside return-to-lobby state",
            )
            return None
        shell_exits = [
            record
            for record in self.input_records
            if record.domain is FarmInputDomain.BOSS_ROOM_SHELL_EXIT
            and record.attempt_index == self.match_attempts
            and record.sent
        ]
        if len(shell_exits) != 1 or any(
            record.domain is FarmInputDomain.BOSS_ROOM_SHELL_CONFIRM
            and record.attempt_index == self.match_attempts
            and record.sent
            for record in self.input_records
        ):
            self.safety.duplicate_lobby_entry += 1
            self.safe_stop(
                FarmRunStopReason.RETURN_LOBBY_TIMEOUT,
                detail="room-shell confirmation missing exit or duplicated",
            )
            return None
        if not foreground:
            self.safe_stop(FarmRunStopReason.FOREGROUND_LOST)
            return None
        permit = FarmInputPermit(
            uuid4().hex,
            FarmInputDomain.BOSS_ROOM_SHELL_CONFIRM,
            None,
            self.match_attempts,
        )
        self._pending = permit
        self._event("boss_room_shell_confirm_reserved", attemptIndex=self.match_attempts)
        return permit

    def complete_room_shell_confirm(
        self, permit: FarmInputPermit, *, sent: bool, detail: str = ""
    ) -> bool:
        if (
            permit != self._pending
            or permit.domain is not FarmInputDomain.BOSS_ROOM_SHELL_CONFIRM
        ):
            self.safe_stop(
                FarmRunStopReason.RETURN_LOBBY_TIMEOUT,
                detail="room-shell confirmation capability mismatch",
            )
            return False
        self._pending = None
        self._record_input(permit, sent=sent, detail=detail)
        if not sent:
            self.safe_stop(FarmRunStopReason.RETURN_LOBBY_TIMEOUT, detail=detail)
            return False
        return True

    def observe_return_lobby(self, lobby: BossLobbyState) -> bool:
        if self.state is not FarmRunState.WAIT_BOSS_LOBBY:
            return self._reject("return_lobby_out_of_order")
        if lobby is not BossLobbyState.BOSS_LOBBY:
            self.safe_stop(FarmRunStopReason.RETURN_LOBBY_TIMEOUT, lobby=lobby)
            return False
        if self._ejected_map_reentry_pending:
            self.safe_stop(
                FarmRunStopReason.INTERNAL_INVARIANT,
                detail="ejected map re-entry was not completed before lobby observation",
            )
            return False
        if (
            self.attempts
            and self.attempts[-1].result_consistency
            is ResultConsistency.RESULT_CONFLICT
        ):
            self.safe_stop(
                FarmRunStopReason.RESULT_CONFLICT,
                matchId=self.attempts[-1].match_id,
            )
            return False
        if self.completed_matches >= self.limits.target_completed_matches:
            self.stop_reason = FarmRunStopReason.FARM_TARGET_COMPLETED
            self.end_timestamp = utc_timestamp()
            self._transition(FarmRunState.FARM_RUN_COMPLETE, "farm_target_completed")
            return True
        if self.graceful_stop_requested():
            # Drained to the exact boss lobby; never reserve the next entry.
            if self._control is not None:
                self._control.stop_at_lobby()
            self.stop_reason = FarmRunStopReason.STOPPED_GRACEFULLY
            self.end_timestamp = utc_timestamp()
            self.current_session = None
            self._transition(
                FarmRunState.FARM_RUN_COMPLETE,
                "graceful_stop_completed_at_boss_lobby",
                completedMatches=self.completed_matches,
            )
            return True
        if self.match_attempts >= self.limits.max_match_attempts:
            self.safe_stop(FarmRunStopReason.MATCH_ATTEMPT_LIMIT_REACHED)
            return False
        if self._control is not None:
            # The irrevocable entry's match has drained; it must not exempt
            # future entries from the graceful-stop gate.
            self._control.clear_entry_irrevocable()
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
        entry_opening_timeout = bool(
            reason == "ENTRY_OPENING_TIMEOUT_ACTIVE_COMBAT"
            and self.state is FarmRunState.WAIT_OPENING
        )
        if (
            self.state is not FarmRunState.COMBAT_ACTIVE
            and not entry_opening_timeout
        ) or self.current_attempt is None:
            return self._reject("technical_failure_out_of_order", reason=reason)
        self._pending = None
        attempt = self.current_attempt
        attempt.result = MatchResult.TECHNICAL_ABORT
        attempt.end_timestamp = utc_timestamp()
        attempt.duration_seconds = _duration_seconds(
            attempt.start_timestamp, attempt.end_timestamp
        )
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
        if self.match_attempts >= self.limits.max_match_attempts:
            self.safe_stop(FarmRunStopReason.MATCH_ATTEMPT_LIMIT_REACHED)
            return False
        return True

    def complete_stage_b1(self, *, invariant: str) -> bool:
        if self.state is not FarmRunState.COMBAT_ACTIVE or self._pending is not None:
            return self._reject("stage_b1_completion_out_of_order")
        self.stop_reason = FarmRunStopReason.STAGE_B1_ACTION_ACCEPTED
        self.end_timestamp = utc_timestamp()
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

    def begin_ejected_map_reentry(
        self,
        *,
        target_boss_id: str,
        exact_world_map: bool,
        detached_room_shell: bool = False,
        no_combat_owner: bool,
    ) -> bool:
        """Move a proven owner-free ejection to exact-pet map recovery.

        Unity may stop first on a detached room shell before displaying the
        island map. That shell is accepted only as a mutually exclusive origin
        with exact runtime/visual proof in the caller; it does not weaken the
        later exact map target selection.
        """

        expected_id = str(self.target.boss_id or "").strip()
        if (
            self.state
            not in {FarmRunState.RECOVERY_PENDING, FarmRunState.RECOVERY_ACTIVE}
            or self._pending is not None
            or self._ejected_map_reentry_pending
            or int(bool(exact_world_map)) + int(bool(detached_room_shell)) != 1
            or not no_combat_owner
            or not expected_id
            or str(target_boss_id).strip() != expected_id
        ):
            return self._reject(
                "ejected_map_reentry_preflight_rejected",
                expectedBossId=expected_id,
                observedBossId=str(target_boss_id).strip(),
                exactWorldMap=exact_world_map,
                detachedRoomShell=detached_room_shell,
                noCombatOwner=no_combat_owner,
            )
        self._ejected_map_reentry_pending = True
        self._transition(
            FarmRunState.WAIT_BOSS_LOBBY,
            "ejected_map_reentry_started",
            targetBossId=expected_id,
            priorAttempt=self.match_attempts,
            origin=(
                "DETACHED_ROOM_SHELL"
                if detached_room_shell
                else "WORLD_BOSS_LIST"
            ),
        )
        return True

    def prepare_failed_recovery_map_fallback(
        self, records: tuple[Any, ...]
    ) -> bool:
        """Audit a failed in-room recovery before falling back to exact map ID."""

        if self.state is not FarmRunState.RECOVERY_ACTIVE or self._pending is not None:
            return self._reject("recovery_map_fallback_out_of_order")
        domain_map = {
            "RECOVERY_EXIT": FarmInputDomain.RECOVERY_EXIT,
            "RECOVERY_CONFIRM": FarmInputDomain.RECOVERY_CONFIRM,
            "RECOVERY_TARGET_SELECT": FarmInputDomain.RECOVERY_TARGET_SELECT,
            "RECOVERY_REENTRY": FarmInputDomain.RECOVERY_REENTRY,
        }
        sent_domains: list[FarmInputDomain] = []
        converted: list[tuple[FarmInputPermit, bool, str]] = []
        for record in records:
            raw = getattr(record, "domain", None)
            name = str(getattr(raw, "value", raw))
            domain = domain_map.get(name)
            if domain is None:
                return self._reject(
                    "recovery_map_fallback_unknown_domain", domain=name
                )
            sent = bool(getattr(record, "sent", False))
            if sent:
                sent_domains.append(domain)
            converted.append(
                (
                    FarmInputPermit(
                        uuid4().hex, domain, None, self.match_attempts
                    ),
                    sent,
                    str(getattr(record, "detail", "")),
                )
            )
        if (
            sent_domains.count(FarmInputDomain.RECOVERY_EXIT) > 1
            or sent_domains.count(FarmInputDomain.RECOVERY_CONFIRM) > 1
            or sent_domains.count(FarmInputDomain.RECOVERY_REENTRY) > 1
            or FarmInputDomain.RECOVERY_TARGET_SELECT in sent_domains
        ):
            return self._reject(
                "recovery_map_fallback_ambiguous_inputs",
                sentDomains=sent_domains,
            )
        for permit, sent, detail in converted:
            self._record_input(permit, sent=sent, detail=detail)
        self._event(
            "failed_recovery_inputs_audited_for_map_fallback",
            sentDomains=sent_domains,
            reentryInputSent=(
                FarmInputDomain.RECOVERY_REENTRY in sent_domains
            ),
            noCombatOwnerRequiredBeforeFallback=True,
        )
        return True

    def complete_failed_recovery_room_fallback(
        self,
        *,
        target_boss_id: str,
        exact_target_room: bool,
        no_combat_owner: bool,
    ) -> bool:
        """Resume the farm loop when a failed recovery already reached our room.

        The Phase 2D.3 recovery owns its Exit/Confirm/Re-entry inputs, but it can
        still fail before handing recovered gameplay back to FarmRunner. If the
        outer runner independently proves that the game is again in the exact
        pinned boss room with no live combat owner, the safest continuation is
        a fresh normal entry. No recovery session, opening, proposal, or ACK
        state is reused.
        """

        expected_id = str(self.target.boss_id or "").strip()
        if (
            self.state is not FarmRunState.RECOVERY_ACTIVE
            or self._pending is not None
            or self._ejected_map_reentry_pending
            or not exact_target_room
            or not no_combat_owner
            or not expected_id
            or str(target_boss_id).strip() != expected_id
        ):
            self.safe_stop(
                FarmRunStopReason.RECOVERY_FAILED,
                detail="exact target room was not proven after failed recovery",
            )
            return False
        self.technical_recoveries += 1
        self.current_session = None
        self._transition(
            FarmRunState.WAIT_BOSS_LOBBY,
            "failed_recovery_exact_room_restored",
            targetBossId=expected_id,
            count=self.technical_recoveries,
            oldCombatStateReused=False,
        )
        return True

    def complete_ejected_map_reentry(
        self,
        *,
        target_boss_id: str,
        exact_target_room: bool,
        no_combat_owner: bool,
    ) -> bool:
        """Count one bounded recovery only after the exact room is restored."""

        expected_id = str(self.target.boss_id or "").strip()
        if (
            self.state is not FarmRunState.WAIT_BOSS_LOBBY
            or not self._ejected_map_reentry_pending
            or self._pending is not None
            or not exact_target_room
            or not no_combat_owner
            or not expected_id
            or str(target_boss_id).strip() != expected_id
        ):
            self.safe_stop(
                FarmRunStopReason.RECOVERY_FAILED,
                detail="exact target room was not proven after map re-entry",
            )
            return False
        self._ejected_map_reentry_pending = False
        self.technical_recoveries += 1
        self._event(
            "ejected_map_reentry_completed",
            targetBossId=expected_id,
            count=self.technical_recoveries,
        )
        return True

    def record_successful_recovery(self, records: tuple[Any, ...]) -> bool:
        if self.state is not FarmRunState.RECOVERY_ACTIVE:
            return self._reject("recovery_completion_out_of_order")
        domain_map = {
            "RECOVERY_EXIT": FarmInputDomain.RECOVERY_EXIT,
            "RECOVERY_CONFIRM": FarmInputDomain.RECOVERY_CONFIRM,
            "RECOVERY_TARGET_SELECT": FarmInputDomain.RECOVERY_TARGET_SELECT,
            "RECOVERY_REENTRY": FarmInputDomain.RECOVERY_REENTRY,
        }
        invocation_sent_domains: list[FarmInputDomain] = []
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
            if bool(getattr(record, "sent", False)):
                invocation_sent_domains.append(domain)
        # Validate the one-shot Phase 2D.3 invocation, not the cumulative
        # farm-run history.  A bounded D5 soak may legitimately complete a
        # second independent recovery, producing two of each domain overall.
        if invocation_sent_domains.count(FarmInputDomain.RECOVERY_EXIT) != 1:
            self.safe_stop(FarmRunStopReason.RECOVERY_FAILED, detail="recovery Exit count")
            return False
        if invocation_sent_domains.count(FarmInputDomain.RECOVERY_CONFIRM) != 1:
            self.safe_stop(FarmRunStopReason.RECOVERY_FAILED, detail="recovery confirm count")
            return False
        if invocation_sent_domains.count(FarmInputDomain.RECOVERY_REENTRY) != 1:
            self.safe_stop(FarmRunStopReason.RECOVERY_FAILED, detail="recovery re-entry count")
            return False
        self.technical_recoveries += 1
        self._event("technical_recovery_completed", count=self.technical_recoveries)
        return True

    def safe_stop(self, reason: FarmRunStopReason, **detail: Any) -> None:
        if (
            reason is FarmRunStopReason.EMERGENCY_STOP
            and self._control is not None
        ):
            self._control.emergency_stop(
                timestamp=_epoch_seconds(utc_timestamp())
            )
        if self.stopped:
            return
        if self.current_attempt is not None:
            attempt = self.current_attempt
            if attempt.end_timestamp is None:
                attempt.end_timestamp = utc_timestamp()
                attempt.result = MatchResult.SAFE_STOP
        self.current_session = None
        self._pending = None
        self._ejected_map_reentry_pending = False
        self.safe_stops += 1
        self.stop_reason = reason
        self.end_timestamp = self.end_timestamp or utc_timestamp()
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
        self._event_index += 1
        self.events.append(
            FarmRunEvent(
                self._event_index,
                utc_timestamp(),
                event,
                self.state,
                _jsonable(detail),
            )
        )
        # Bounded in-memory ring; full history is streamed to events.jsonl.
        excess = len(self.events) - self._max_retained_events
        if excess > 0:
            del self.events[:excess]

    def _transition(self, state: FarmRunState, event: str, **detail: Any) -> None:
        old = self.state
        self.state = state
        self._event(event, oldState=old, **detail)

    def _reject(self, event: str, **detail: Any) -> bool:
        self._event(event, **detail)
        return False


class FarmRunEntryCapability:
    def __init__(self, run: FarmRun, authority: Any | None = None) -> None:
        self.run = run
        self.entry_number = run.match_attempts + 1
        self._authority = authority

    def reserve(self, *, foreground: bool) -> FarmInputPermit | None:
        if self._authority is not None and self._authority.emergency_requested:
            self.run.safe_stop(
                FarmRunStopReason.EMERGENCY_STOP,
                detail="emergency authority revoked before boss entry reserve",
            )
            return None
        return self.run.reserve_entry(foreground=foreground)

    def complete(self, permit: FarmInputPermit, *, sent: bool, detail: str = "") -> bool:
        return self.run.complete_entry(permit, sent=sent, detail=detail)

    def cancel(self, permit: FarmInputPermit, *, detail: str = "") -> bool:
        return self.run.cancel_entry(permit, detail=detail)

    def reserve_retry(
        self,
        *,
        foreground: bool,
        exact_same_target: bool,
        no_combat_owner: bool,
        stable_same_button: bool,
    ) -> FarmInputPermit | None:
        if self._authority is not None and self._authority.emergency_requested:
            self.run.safe_stop(
                FarmRunStopReason.EMERGENCY_STOP,
                detail="emergency authority revoked before boss entry retry",
            )
            return None
        return self.run.reserve_entry_retry(
            foreground=foreground,
            exact_same_target=exact_same_target,
            no_combat_owner=no_combat_owner,
            stable_same_button=stable_same_button,
        )

    def complete_retry(
        self, permit: FarmInputPermit, *, sent: bool, detail: str = ""
    ) -> bool:
        return self.run.complete_entry_retry(permit, sent=sent, detail=detail)

    def execute(self, operation: Callable[[], Any]) -> tuple[bool, Any | None]:
        if self._authority is None:
            return True, operation()
        authorized, result = self._authority.execute_if_authorized(operation)
        if not authorized and not self.run.stopped:
            self.run.safe_stop(
                FarmRunStopReason.EMERGENCY_STOP,
                detail="emergency authority revoked before boss entry input",
            )
        return authorized, result


class FarmRunLobbyCardCapability:
    """One bounded normal lobby click for the unique required Attack card."""

    def __init__(self, run: FarmRun, authority: Any | None = None) -> None:
        self.run = run
        self._authority = authority

    def reserve(
        self,
        *,
        foreground: bool,
        exact_attack_identity: bool,
        no_combat_owner: bool,
        selected_attack_missing: bool,
        unique_room_attack: bool,
    ) -> FarmInputPermit | None:
        if self._authority is not None and self._authority.emergency_requested:
            self.run.safe_stop(
                FarmRunStopReason.EMERGENCY_STOP,
                detail="emergency authority revoked before lobby card selection",
            )
            return None
        return self.run.reserve_lobby_card_select(
            foreground=foreground,
            exact_attack_identity=exact_attack_identity,
            no_combat_owner=no_combat_owner,
            selected_attack_missing=selected_attack_missing,
            unique_room_attack=unique_room_attack,
        )

    def complete(
        self, permit: FarmInputPermit, *, sent: bool, detail: str = ""
    ) -> bool:
        return self.run.complete_lobby_card_select(
            permit, sent=sent, detail=detail
        )

    def execute(self, operation: Callable[[], Any]) -> tuple[bool, Any | None]:
        if self._authority is None:
            return True, operation()
        authorized, result = self._authority.execute_if_authorized(operation)
        if not authorized and not self.run.stopped:
            self.run.safe_stop(
                FarmRunStopReason.EMERGENCY_STOP,
                detail="emergency authority revoked before lobby card input",
            )
        return authorized, result


_ACTION_DOMAINS = {
    "SWAP": FarmInputDomain.GAMEPLAY_SWAP,
    "CAST": FarmInputDomain.GAMEPLAY_CAST,
    "EVOLVE": FarmInputDomain.GAMEPLAY_EVOLVE,
    "PASS": FarmInputDomain.GAMEPLAY_PASS,
}


class FarmRunGameplayCapability:
    def __init__(
        self,
        run: FarmRun,
        session: CombatSessionKey,
        authority: Any | None = None,
    ) -> None:
        self.run = run
        self.session = session
        self._authority = authority

    def reserve(
        self, *, action: str, session: CombatSessionKey, foreground: bool
    ) -> FarmInputPermit | None:
        if self._authority is not None and self._authority.emergency_requested:
            self.run.safe_stop(
                FarmRunStopReason.EMERGENCY_STOP,
                detail=f"emergency authority revoked before {action} reserve",
            )
            return None
        domain = _ACTION_DOMAINS.get(action.upper())
        if domain is None:
            self.run.safe_stop(FarmRunStopReason.GAMEPLAY_CAPABILITY_DENIED, action=action)
            return None
        return self.run.reserve_gameplay(domain, session, foreground=foreground)

    def complete(self, permit: FarmInputPermit, *, sent: bool, detail: str = "") -> bool:
        return self.run.complete_gameplay(permit, sent=sent, detail=detail)

    def cancel(self, permit: FarmInputPermit, *, detail: str = "") -> bool:
        return self.run.cancel_gameplay(permit, detail=detail)

    def abandon_pass_preflight(
        self, permit: FarmInputPermit, *, detail: str = ""
    ) -> bool:
        return self.run.abandon_pass_preflight(permit, detail=detail)

    def graceful_stop_requested(self) -> bool:
        """Combat can poll this each turn to honor F6 mid-match."""
        return self.run.graceful_stop_requested()

    def execute(self, operation: Callable[[], Any]) -> tuple[bool, Any | None]:
        if self._authority is None:
            return True, operation()
        authorized, result = self._authority.execute_if_authorized(operation)
        if not authorized and not self.run.stopped:
            self.run.safe_stop(
                FarmRunStopReason.EMERGENCY_STOP,
                detail="emergency authority revoked before gameplay input",
            )
        return authorized, result


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
                    "schema": "pokiguard.farm_run.v2",
                    "phase2d4BaseCommit": (
                        "f87eb9ec5f2e794de635a1d4dbe63375371a142c"
                    ),
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
    "FarmControlState",
    "FarmInputDomain",
    "GracefulStopController",
    "FarmInputPermit",
    "FarmInputRecord",
    "FarmRun",
    "FarmRunArtifactWriter",
    "FarmRunEntryCapability",
    "FarmRunLobbyCardCapability",
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
