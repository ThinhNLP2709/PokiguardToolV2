"""One-generation, closed-loop Pet Skill QTE direction input.

This module grants exactly one narrow authority: a discrete Up/Down/Left/Right
press for a current, read-only validated QTE.  It cannot represent Space,
Enter, a card click, or any gameplay action outside the direction sequence.
"""

from __future__ import annotations

from dataclasses import dataclass, replace
from enum import Enum
import math
import time
from typing import Callable, Protocol

from .pet_qte_observer import QteGenerationIdentity
from .pet_skill_shadow import QteDirection, QteEvidenceStatus, QteSnapshot
from .state import CombatSessionKey
from .win32_input import ClientGeometry, WindowBinding


class AutomatedQteDirection(str, Enum):
    """The complete and intentionally closed Phase 3B.2 input vocabulary."""

    UP = "UP"
    DOWN = "DOWN"
    LEFT = "LEFT"
    RIGHT = "RIGHT"


_DIRECTION_VIRTUAL_KEYS: dict[AutomatedQteDirection, tuple[int, str]] = {
    AutomatedQteDirection.UP: (0x26, "VK_UP"),
    AutomatedQteDirection.DOWN: (0x28, "VK_DOWN"),
    AutomatedQteDirection.LEFT: (0x25, "VK_LEFT"),
    AutomatedQteDirection.RIGHT: (0x27, "VK_RIGHT"),
}


def automated_direction(value: QteDirection) -> AutomatedQteDirection | None:
    if value is QteDirection.UP:
        return AutomatedQteDirection.UP
    if value is QteDirection.DOWN:
        return AutomatedQteDirection.DOWN
    if value is QteDirection.LEFT:
        return AutomatedQteDirection.LEFT
    if value is QteDirection.RIGHT:
        return AutomatedQteDirection.RIGHT
    return None


class QteDirectionInputStatus(str, Enum):
    SENT = "SENT"
    WINDOW_INVALID = "WINDOW_INVALID"
    WINDOW_CHANGED = "WINDOW_CHANGED"
    GAME_NOT_FOREGROUND = "GAME_NOT_FOREGROUND"
    INPUT_FAILED = "INPUT_FAILED"


@dataclass(frozen=True)
class QteDirectionInputResult:
    status: QteDirectionInputStatus
    direction: AutomatedQteDirection
    virtual_key: int
    physical_mapping: str
    logical_presses: int

    @property
    def sent(self) -> bool:
        return (
            self.status is QteDirectionInputStatus.SENT
            and self.logical_presses == 1
        )


class DirectionKeyboardBackend(Protocol):
    def client_geometry(self, hwnd: int) -> ClientGeometry | None: ...
    def is_foreground(self, hwnd: int) -> bool: ...
    def window_pid(self, hwnd: int) -> int | None: ...
    def press_virtual_key(self, virtual_key: int) -> bool: ...


class QteDirectionInputExecutor:
    """Foreground-gated normal input with no arbitrary-key public method."""

    def __init__(self, backend: DirectionKeyboardBackend) -> None:
        self._backend = backend

    def send_qte_direction(
        self,
        binding: WindowBinding,
        direction: AutomatedQteDirection,
    ) -> QteDirectionInputResult:
        if not isinstance(direction, AutomatedQteDirection):
            raise TypeError("QTE input accepts AutomatedQteDirection only")
        virtual_key, label = _DIRECTION_VIRTUAL_KEYS[direction]

        status = QteDirectionInputStatus.SENT
        geometry = self._backend.client_geometry(binding.hwnd)
        if self._backend.window_pid(binding.hwnd) != binding.pid or geometry is None:
            status = QteDirectionInputStatus.WINDOW_INVALID
        elif (
            geometry.width != binding.initial_width
            or geometry.height != binding.initial_height
        ):
            status = QteDirectionInputStatus.WINDOW_CHANGED
        elif not self._backend.is_foreground(binding.hwnd):
            status = QteDirectionInputStatus.GAME_NOT_FOREGROUND
        elif not self._backend.press_virtual_key(virtual_key):
            status = QteDirectionInputStatus.INPUT_FAILED

        return QteDirectionInputResult(
            status=status,
            direction=direction,
            virtual_key=virtual_key,
            physical_mapping=f"{label}(0x{virtual_key:02X})",
            logical_presses=1 if status is QteDirectionInputStatus.SENT else 0,
        )


class QteAssistState(str, Enum):
    DISARMED = "DISARMED"
    ARMED_WAITING_FOR_QTE = "ARMED_WAITING_FOR_QTE"
    BOUND_TO_GENERATION = "BOUND_TO_GENERATION"
    EXECUTING_DIRECTIONS = "EXECUTING_DIRECTIONS"


class QteDirectionRecordStatus(str, Enum):
    SENT_AWAITING_PROGRESS = "SENT_AWAITING_PROGRESS"
    AUTHORITATIVELY_CONFIRMED = "AUTHORITATIVELY_CONFIRMED"
    INPUT_SENT_UNCONFIRMED = "INPUT_SENT_UNCONFIRMED"
    INVALIDATED = "INVALIDATED"


@dataclass(frozen=True)
class QteDirectionRecord:
    match_id: str
    qte_generation: int
    skill_card_id: int
    source_current_index: int
    expected_direction: AutomatedQteDirection
    physical_mapping: str
    send_timestamp: float
    post_read_timestamp: float | None
    post_current_index: int | None
    post_correct_count: int | None
    status: QteDirectionRecordStatus
    failure_reason: str | None = None


@dataclass(frozen=True)
class QteAssistSummary:
    match_id: str
    qte_generation: int
    skill_card_id: int
    sequence: tuple[AutomatedQteDirection, ...]
    sequence_length: int
    directions_sent: int
    directions_confirmed: int
    wrong_directions: int
    skipped_directions: int
    duplicate_directions: int
    stale_directions: int
    unconfirmed_directions: int
    blind_retries: int
    automated_card_clicks: int
    automated_space_presses: int
    completion_elapsed: float | None
    perfect_start: float | None
    perfect_end: float | None
    headroom_to_perfect_start: float | None
    final_qte_state: str
    automation_stop_reason: str
    records: tuple[QteDirectionRecord, ...]


@dataclass(frozen=True)
class QteAssistEvent:
    event: str
    state: QteAssistState
    reason: str | None = None
    direction_record: QteDirectionRecord | None = None
    summary: QteAssistSummary | None = None


@dataclass(frozen=True)
class _GenerationBinding:
    identity: QteGenerationIdentity
    session_key: CombatSessionKey
    window_binding: WindowBinding
    match_id: str
    skill_card_id: int
    sequence: tuple[AutomatedQteDirection, ...]
    perfect_start: float
    perfect_end: float
    expected_index: int
    expected_correct_count: int
    expected_presses: tuple[QteDirection, ...]
    cached_expected_direction: AutomatedQteDirection


@dataclass(frozen=True)
class _PendingDirection:
    source_index: int
    source_correct_count: int
    source_presses: tuple[QteDirection, ...]
    direction: AutomatedQteDirection
    sent_at_monotonic: float
    record_index: int


class QteDirectionAssist:
    """One-arm/one-generation closed-loop state machine.

    ``observe`` is deliberately poll-driven and never starts a worker.  A new
    direction can be sent only on a fresh poll after bind/ack; the following
    poll must then prove exactly one authoritative progress transition.
    """

    def __init__(
        self,
        executor: QteDirectionInputExecutor,
        *,
        response_timeout_seconds: float = 1.25,
        timestamp: Callable[[], float] = time.time,
    ) -> None:
        if not 0.10 <= response_timeout_seconds <= 2.0:
            raise ValueError("QTE response timeout must be between 0.10 and 2.0 seconds")
        self._executor = executor
        self.response_timeout_seconds = float(response_timeout_seconds)
        self._timestamp = timestamp
        self._state = QteAssistState.DISARMED
        self._armed_session: CombatSessionKey | None = None
        self._armed_window: WindowBinding | None = None
        self._binding: _GenerationBinding | None = None
        self._pending: _PendingDirection | None = None
        self._records: list[QteDirectionRecord] = []
        self._confirmed = 0
        self._last_summary: QteAssistSummary | None = None

    @property
    def state(self) -> QteAssistState:
        return self._state

    @property
    def last_summary(self) -> QteAssistSummary | None:
        return self._last_summary

    @property
    def direction_records(self) -> tuple[QteDirectionRecord, ...]:
        return tuple(self._records)

    def arm(
        self,
        *,
        session_key: CombatSessionKey,
        window_binding: WindowBinding,
        inactive_baseline_proven: bool,
    ) -> tuple[QteAssistEvent, ...]:
        if self._state is not QteAssistState.DISARMED:
            raise RuntimeError("QTE direction assist is already armed")
        if not inactive_baseline_proven:
            raise ValueError("arming requires a proven current-session inactive QTE")
        if window_binding.pid <= 0 or window_binding.hwnd <= 0:
            raise ValueError("a positive PID/HWND binding is required")
        self._armed_session = session_key
        self._armed_window = window_binding
        self._binding = None
        self._pending = None
        self._records = []
        self._confirmed = 0
        self._last_summary = None
        self._state = QteAssistState.ARMED_WAITING_FOR_QTE
        return (QteAssistEvent("qte_direction_assist_armed", self._state),)

    def abort(self, reason: str = "OPERATOR_ABORT") -> tuple[QteAssistEvent, ...]:
        if self._state is QteAssistState.DISARMED:
            return ()
        return self._finish(reason, final_qte_state="ABORTED")

    def invalidate(self, reason: str) -> tuple[QteAssistEvent, ...]:
        if self._state is QteAssistState.DISARMED:
            return ()
        return self._finish(reason, final_qte_state="INVALIDATED")

    def observe(
        self,
        snapshot: QteSnapshot | None,
        *,
        window_binding: WindowBinding,
        monotonic_now: float,
        lifecycle_valid: bool,
        authority_owned: bool,
        emergency_stop: bool = False,
        shutdown_requested: bool = False,
    ) -> tuple[QteAssistEvent, ...]:
        if self._state is QteAssistState.DISARMED:
            return ()
        if emergency_stop:
            return self._finish("EMERGENCY_STOP", final_qte_state="ABORTED")
        if shutdown_requested:
            return self._finish("SHUTDOWN", final_qte_state="ABORTED")
        if not lifecycle_valid:
            return self._finish("LIFECYCLE_INVALID", final_qte_state="INVALIDATED")
        if not authority_owned:
            return self._finish("INPUT_AUTHORITY_NOT_OWNED", final_qte_state="INVALIDATED")
        if self._armed_window != window_binding:
            return self._finish("WINDOW_BINDING_CHANGED", final_qte_state="INVALIDATED")
        if snapshot is None:
            return () if self._state is QteAssistState.ARMED_WAITING_FOR_QTE else self._finish(
                "QTE_SNAPSHOT_MISSING", final_qte_state="INVALIDATED"
            )
        if snapshot.session_key != self._armed_session:
            return self._finish("COMBAT_SESSION_CHANGED", final_qte_state="INVALIDATED")

        if self._state is QteAssistState.ARMED_WAITING_FOR_QTE:
            if snapshot.evidence_status is QteEvidenceStatus.INACTIVE:
                return ()
            problem = self._initial_snapshot_problem(snapshot)
            if problem is not None:
                return self._finish(problem, final_qte_state="INVALIDATED")
            assert snapshot.identity is not None
            assert snapshot.match_id is not None
            assert snapshot.skill_card_id is not None
            assert snapshot.current_index is not None
            assert snapshot.correct_count is not None
            assert snapshot.perfect_start is not None
            assert snapshot.perfect_end is not None
            sequence = tuple(automated_direction(item) for item in snapshot.sequence)
            if any(item is None for item in sequence):
                return self._finish("UNKNOWN_DIRECTION", final_qte_state="INVALIDATED")
            expected = automated_direction(snapshot.expected_direction)
            if expected is None:
                return self._finish("EXPECTED_DIRECTION_UNKNOWN", final_qte_state="INVALIDATED")
            self._binding = _GenerationBinding(
                identity=snapshot.identity,
                session_key=snapshot.session_key,
                window_binding=window_binding,
                match_id=snapshot.match_id,
                skill_card_id=snapshot.skill_card_id,
                sequence=tuple(item for item in sequence if item is not None),
                perfect_start=snapshot.perfect_start,
                perfect_end=snapshot.perfect_end,
                expected_index=snapshot.current_index,
                expected_correct_count=snapshot.correct_count,
                expected_presses=snapshot.presses,
                cached_expected_direction=expected,
            )
            self._state = QteAssistState.BOUND_TO_GENERATION
            return (
                QteAssistEvent(
                    "qte_direction_generation_bound",
                    self._state,
                    reason="fresh index-0 generation; next poll is preflight",
                ),
            )

        if self._binding is None:
            return self._finish("INTERNAL_BINDING_MISSING", final_qte_state="INVALIDATED")
        identity_problem = self._identity_problem(snapshot)
        if identity_problem is not None:
            if self._pending is not None:
                self._mark_pending(
                    QteDirectionRecordStatus.INVALIDATED,
                    snapshot,
                    identity_problem,
                )
            return self._finish(identity_problem, final_qte_state="INVALIDATED")

        if self._state is QteAssistState.EXECUTING_DIRECTIONS:
            return self._observe_pending(snapshot, monotonic_now)

        return self._send_one(snapshot, window_binding, monotonic_now)

    def observe_unavailable(
        self,
        *,
        monotonic_now: float,
        reason: str,
    ) -> tuple[QteAssistEvent, ...]:
        """Handle one torn/missing read without inventing rejection or retry.

        Before any physical input a transient read simply authorizes nothing.
        After a direction was sent, the assist retains the exact pending input
        until its bounded ACK deadline so the next clean read can still prove
        progress. Expiry records INPUT_SENT_UNCONFIRMED and never resends.
        """

        if self._state is QteAssistState.DISARMED:
            return ()
        if self._state is QteAssistState.ARMED_WAITING_FOR_QTE:
            return ()
        if self._state is not QteAssistState.EXECUTING_DIRECTIONS:
            return self._finish(reason, final_qte_state="INVALIDATED")
        pending = self._pending
        if pending is None:
            return self._finish("INTERNAL_PENDING_MISSING", final_qte_state="INVALIDATED")
        if monotonic_now - pending.sent_at_monotonic < self.response_timeout_seconds:
            return ()
        record = self._records[pending.record_index]
        updated = replace(
            record,
            status=QteDirectionRecordStatus.INPUT_SENT_UNCONFIRMED,
            failure_reason=f"{reason}:QTE_PROGRESS_TIMEOUT_NO_RETRY",
        )
        self._records[pending.record_index] = updated
        return (
            QteAssistEvent(
                "qte_direction_input_unconfirmed",
                self._state,
                reason="QTE_PROGRESS_TIMEOUT_NO_RETRY",
                direction_record=updated,
            ),
            *self._finish(
                "INPUT_SENT_UNCONFIRMED",
                final_qte_state="INPUT_SENT_UNCONFIRMED",
            ),
        )

    @staticmethod
    def _initial_snapshot_problem(snapshot: QteSnapshot) -> str | None:
        if not snapshot.observationally_current or snapshot.identity is None:
            return "QTE_NOT_CURRENT_OR_AMBIGUOUS"
        if not snapshot.active or snapshot.completed:
            return "QTE_NOT_ACTIVE"
        if not snapshot.match_id or snapshot.skill_card_id is None:
            return "QTE_IDENTITY_INCOMPLETE"
        if snapshot.local_actor is None or snapshot.turn_number is None:
            return "QTE_OWNER_OR_TURN_UNKNOWN"
        if not 1 <= snapshot.sequence_length <= 64:
            return "QTE_SEQUENCE_LENGTH_INVALID"
        if len(snapshot.sequence) != snapshot.sequence_length:
            return "QTE_SEQUENCE_INCOMPLETE"
        if snapshot.current_index != 0 or snapshot.correct_count != 0:
            return "QTE_MIDSTREAM_PROGRESS"
        if snapshot.presses or snapshot.raw_presses:
            return "QTE_MIDSTREAM_PRESSES"
        if (
            snapshot.perfect_start is None
            or snapshot.perfect_end is None
            or not math.isfinite(snapshot.perfect_start)
            or not math.isfinite(snapshot.perfect_end)
            or not 0 <= snapshot.perfect_start < snapshot.perfect_end
        ):
            return "QTE_PERFECT_WINDOW_INVALID"
        return None

    def _identity_problem(self, snapshot: QteSnapshot) -> str | None:
        bound = self._binding
        assert bound is not None
        if not snapshot.observationally_current or snapshot.identity is None:
            return "QTE_NO_LONGER_CURRENT"
        if snapshot.identity != bound.identity:
            return "QTE_GENERATION_CHANGED"
        if snapshot.session_key != bound.session_key or snapshot.match_id != bound.match_id:
            return "QTE_SESSION_OR_MATCH_CHANGED"
        if snapshot.skill_card_id != bound.skill_card_id:
            return "QTE_SKILL_CARD_CHANGED"
        if snapshot.local_actor != bound.identity.local_actor_number:
            return "QTE_LOCAL_ACTOR_CHANGED"
        if snapshot.turn_number != bound.identity.turn_number:
            return "QTE_TURN_CHANGED"
        if tuple(automated_direction(item) for item in snapshot.sequence) != bound.sequence:
            return "QTE_SEQUENCE_CHANGED"
        if not snapshot.active or snapshot.completed:
            return "QTE_CLOSED_UNEXPECTEDLY"
        return None

    def _send_one(
        self,
        snapshot: QteSnapshot,
        window_binding: WindowBinding,
        monotonic_now: float,
    ) -> tuple[QteAssistEvent, ...]:
        bound = self._binding
        assert bound is not None
        if (
            snapshot.current_index != bound.expected_index
            or snapshot.correct_count != bound.expected_correct_count
            or snapshot.presses != bound.expected_presses
        ):
            return self._finish("QTE_PREINPUT_CHANGED", final_qte_state="INVALIDATED")
        fresh_expected = automated_direction(snapshot.expected_direction)
        if fresh_expected is None or fresh_expected != bound.cached_expected_direction:
            return self._finish("QTE_PREINPUT_CHANGED", final_qte_state="INVALIDATED")
        if not 0 <= bound.expected_index < len(bound.sequence):
            return self._finish("QTE_INDEX_OUT_OF_RANGE", final_qte_state="INVALIDATED")
        if fresh_expected != bound.sequence[bound.expected_index]:
            return self._finish("QTE_EXPECTED_DIRECTION_CONFLICT", final_qte_state="INVALIDATED")

        result = self._executor.send_qte_direction(window_binding, fresh_expected)
        if not result.sent:
            return self._finish(
                f"DIRECTION_INPUT_{result.status.value}",
                final_qte_state="INVALIDATED",
            )
        record = QteDirectionRecord(
            match_id=bound.match_id,
            qte_generation=bound.identity.observer_generation,
            skill_card_id=bound.skill_card_id,
            source_current_index=bound.expected_index,
            expected_direction=fresh_expected,
            physical_mapping=result.physical_mapping,
            send_timestamp=self._timestamp(),
            post_read_timestamp=None,
            post_current_index=None,
            post_correct_count=None,
            status=QteDirectionRecordStatus.SENT_AWAITING_PROGRESS,
        )
        self._records.append(record)
        self._pending = _PendingDirection(
            source_index=bound.expected_index,
            source_correct_count=bound.expected_correct_count,
            source_presses=bound.expected_presses,
            direction=fresh_expected,
            sent_at_monotonic=monotonic_now,
            record_index=len(self._records) - 1,
        )
        self._state = QteAssistState.EXECUTING_DIRECTIONS
        return (
            QteAssistEvent(
                "qte_direction_input_sent",
                self._state,
                direction_record=record,
            ),
        )

    def _observe_pending(
        self,
        snapshot: QteSnapshot,
        monotonic_now: float,
    ) -> tuple[QteAssistEvent, ...]:
        pending = self._pending
        bound = self._binding
        assert pending is not None and bound is not None
        expected_index = pending.source_index + 1
        expected_correct = pending.source_correct_count + 1
        exact_progress = (
            snapshot.current_index == expected_index
            and snapshot.correct_count == expected_correct
            and len(snapshot.presses) == len(pending.source_presses) + 1
            and snapshot.presses[:-1] == pending.source_presses
            and automated_direction(snapshot.presses[-1]) == pending.direction
        )
        if exact_progress:
            record = self._mark_pending(
                QteDirectionRecordStatus.AUTHORITATIVELY_CONFIRMED,
                snapshot,
                None,
            )
            self._confirmed += 1
            self._pending = None
            if expected_index == len(bound.sequence):
                return (
                    QteAssistEvent(
                        "qte_direction_progress_confirmed",
                        QteAssistState.EXECUTING_DIRECTIONS,
                        direction_record=record,
                    ),
                    *self._finish(
                        "DIRECTIONS_COMPLETE",
                        final_qte_state="DIRECTIONS_COMPLETE",
                        completion_snapshot=snapshot,
                    ),
                )
            next_expected = automated_direction(snapshot.expected_direction)
            if next_expected is None or next_expected != bound.sequence[expected_index]:
                return self._finish(
                    "NEXT_DIRECTION_UNKNOWN_OR_CHANGED",
                    final_qte_state="INVALIDATED",
                )
            self._binding = replace(
                bound,
                expected_index=expected_index,
                expected_correct_count=expected_correct,
                expected_presses=snapshot.presses,
                cached_expected_direction=next_expected,
            )
            self._state = QteAssistState.BOUND_TO_GENERATION
            return (
                QteAssistEvent(
                    "qte_direction_progress_confirmed",
                    self._state,
                    direction_record=record,
                ),
            )

        unchanged = (
            snapshot.current_index == pending.source_index
            and snapshot.correct_count == pending.source_correct_count
            and snapshot.presses == pending.source_presses
        )
        if unchanged and monotonic_now - pending.sent_at_monotonic < self.response_timeout_seconds:
            return ()
        if unchanged:
            record = self._mark_pending(
                QteDirectionRecordStatus.INPUT_SENT_UNCONFIRMED,
                snapshot,
                "QTE_PROGRESS_TIMEOUT_NO_RETRY",
            )
            return (
                QteAssistEvent(
                    "qte_direction_input_unconfirmed",
                    QteAssistState.EXECUTING_DIRECTIONS,
                    reason="QTE_PROGRESS_TIMEOUT_NO_RETRY",
                    direction_record=record,
                ),
                *self._finish(
                    "INPUT_SENT_UNCONFIRMED",
                    final_qte_state="INPUT_SENT_UNCONFIRMED",
                ),
            )

        reason = "QTE_PROGRESS_UNEXPECTED"
        if snapshot.current_index is not None and snapshot.current_index > expected_index:
            reason = "QTE_INDEX_JUMPED"
        elif snapshot.correct_count != expected_correct:
            reason = "QTE_CORRECT_COUNT_UNEXPECTED"
        elif len(snapshot.presses) > len(pending.source_presses) + 1:
            reason = "QTE_MULTIPLE_PRESSES_OBSERVED"
        elif (
            len(snapshot.presses) == len(pending.source_presses) + 1
            and snapshot.presses[:-1] == pending.source_presses
            and automated_direction(snapshot.presses[-1]) != pending.direction
        ):
            reason = "QTE_DIRECTION_MISMATCH"
        record = self._mark_pending(
            QteDirectionRecordStatus.INVALIDATED,
            snapshot,
            reason,
        )
        return (
            QteAssistEvent(
                "qte_direction_progress_invalid",
                QteAssistState.EXECUTING_DIRECTIONS,
                reason=reason,
                direction_record=record,
            ),
            *self._finish(reason, final_qte_state="INVALIDATED"),
        )

    def _mark_pending(
        self,
        status: QteDirectionRecordStatus,
        snapshot: QteSnapshot,
        reason: str | None,
    ) -> QteDirectionRecord:
        pending = self._pending
        assert pending is not None
        updated = replace(
            self._records[pending.record_index],
            post_read_timestamp=snapshot.observed_at,
            post_current_index=snapshot.current_index,
            post_correct_count=snapshot.correct_count,
            status=status,
            failure_reason=reason,
        )
        self._records[pending.record_index] = updated
        return updated

    def _finish(
        self,
        reason: str,
        *,
        final_qte_state: str,
        completion_snapshot: QteSnapshot | None = None,
    ) -> tuple[QteAssistEvent, ...]:
        bound = self._binding
        summary = None
        if bound is not None:
            # A lifecycle/generation/abort edge may arrive without another QTE
            # snapshot. Preserve the fact that the one physical press was sent,
            # but never invent an ACK or leave the record in an in-flight state.
            if self._pending is not None:
                record_index = self._pending.record_index
                record = self._records[record_index]
                if record.status is QteDirectionRecordStatus.SENT_AWAITING_PROGRESS:
                    self._records[record_index] = replace(
                        record,
                        status=QteDirectionRecordStatus.INVALIDATED,
                        failure_reason=reason,
                    )
            completion_elapsed = (
                completion_snapshot.current_elapsed
                if completion_snapshot is not None
                else None
            )
            unconfirmed = sum(
                item.status is QteDirectionRecordStatus.INPUT_SENT_UNCONFIRMED
                for item in self._records
            )
            invalidated = sum(
                item.status is QteDirectionRecordStatus.INVALIDATED
                for item in self._records
            )
            summary = QteAssistSummary(
                match_id=bound.match_id,
                qte_generation=bound.identity.observer_generation,
                skill_card_id=bound.skill_card_id,
                sequence=bound.sequence,
                sequence_length=len(bound.sequence),
                directions_sent=len(self._records),
                directions_confirmed=self._confirmed,
                wrong_directions=(
                    1
                    if "CORRECT_COUNT" in reason or "DIRECTION_MISMATCH" in reason
                    else 0
                ),
                skipped_directions=(1 if "JUMPED" in reason else 0),
                duplicate_directions=(1 if "MULTIPLE_PRESSES" in reason else 0),
                stale_directions=(
                    1
                    if any(
                        marker in reason
                        for marker in ("GENERATION", "SESSION", "MATCH", "SKILL_CARD", "TURN")
                    )
                    and bool(self._records)
                    else 0
                ),
                unconfirmed_directions=unconfirmed,
                blind_retries=0,
                automated_card_clicks=0,
                automated_space_presses=0,
                completion_elapsed=completion_elapsed,
                perfect_start=bound.perfect_start,
                perfect_end=bound.perfect_end,
                headroom_to_perfect_start=(
                    bound.perfect_start - completion_elapsed
                    if completion_elapsed is not None
                    else None
                ),
                final_qte_state=final_qte_state,
                automation_stop_reason=reason,
                records=tuple(self._records),
            )
            # An invalidated physical input is telemetry, not automatically a
            # proven wrong key.  Keep the count explicit without inventing the
            # game's classification.
            if invalidated and summary.wrong_directions == 0:
                summary = replace(summary, wrong_directions=0)
        self._last_summary = summary
        self._state = QteAssistState.DISARMED
        self._armed_session = None
        self._armed_window = None
        self._binding = None
        self._pending = None
        event_name = (
            "qte_direction_sequence_complete"
            if reason == "DIRECTIONS_COMPLETE"
            else "qte_direction_assist_disarmed"
        )
        return (QteAssistEvent(event_name, self._state, reason=reason, summary=summary),)


__all__ = [
    "AutomatedQteDirection",
    "QteAssistEvent",
    "QteAssistState",
    "QteAssistSummary",
    "QteDirectionAssist",
    "QteDirectionInputExecutor",
    "QteDirectionInputResult",
    "QteDirectionInputStatus",
    "QteDirectionRecord",
    "QteDirectionRecordStatus",
    "automated_direction",
]
