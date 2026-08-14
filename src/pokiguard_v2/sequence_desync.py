"""Session-terminal sequence-desync detection and recovery coordination.

The detector consumes read-only server-message observations.  It deliberately
does not attempt to repair MatchService sequence counters or the network
protocol: a positive signal makes the current combat session terminal.
"""

from __future__ import annotations

from collections import deque
from dataclasses import asdict, dataclass, field, is_dataclass
from enum import Enum
import re
from typing import Any, Iterable, Mapping

from .combat_lifecycle import CombatLifecycleState


class SequenceDesyncSource(str, Enum):
    FORCE_RESYNC = "FORCE_RESYNC"
    MATCH_REJECT_SEQ_GAP = "MATCH_REJECT_SEQ_GAP"
    MATCH_REJECT_SEQ_DUPLICATE = "MATCH_REJECT_SEQ_DUPLICATE"
    MULTIPLE = "MULTIPLE"


class SequenceRejectKind(str, Enum):
    SEQ_GAP = "SEQ_GAP"
    SEQ_DUPLICATE = "SEQ_DUPLICATE"
    MULTIPLE = "SEQ_GAP_OR_DUPLICATE"
    OTHER_REJECT = "OTHER_REJECT"


@dataclass(frozen=True)
class SequenceRootTelemetry:
    """Observed sequence values; unavailable relationships remain ``None``."""

    expected_client_sequence: int | None = None
    observed_client_sequence: int | None = None
    current_server_sequence: int | None = None
    highest_acked_sequence: int | None = None
    last_move_sequence: int | None = None
    gap: bool | None = None
    duplicate: bool | None = None
    relationship_evidence: str = "UNKNOWN"

    @classmethod
    def observed(
        cls,
        *,
        expected_client_sequence: int | None = None,
        observed_client_sequence: int | None = None,
        current_server_sequence: int | None = None,
        highest_acked_sequence: int | None = None,
        last_move_sequence: int | None = None,
    ) -> "SequenceRootTelemetry":
        gap = duplicate = None
        evidence = "UNKNOWN_EXPECTED_SEQUENCE"
        if expected_client_sequence is not None and observed_client_sequence is not None:
            gap = observed_client_sequence > expected_client_sequence
            duplicate = observed_client_sequence < expected_client_sequence
            evidence = "EXPECTED_AND_OBSERVED_SEQUENCE"
        return cls(
            expected_client_sequence,
            observed_client_sequence,
            current_server_sequence,
            highest_acked_sequence,
            last_move_sequence,
            gap,
            duplicate,
            evidence,
        )


@dataclass(frozen=True)
class SequenceDesyncSignal:
    event_type: str
    sources: tuple[SequenceDesyncSource, ...]
    reject_kind: SequenceRejectKind | None
    structured_value: str | int | None
    evidence_field: str
    raw_text: str | None = None


@dataclass(frozen=True)
class SequenceDesyncState:
    detected: bool = False
    source: SequenceDesyncSource | None = None
    first_seen_at: str | None = None
    last_seen_at: str | None = None
    session_key: Any | None = None
    match_id: str | None = None
    turn: int | None = None
    srv_seq: int | None = None
    reject_count: int = 0
    terminal_for_session: bool = False
    reject_kind: SequenceRejectKind | None = None
    evidence_fields: tuple[str, ...] = ()
    root_telemetry: SequenceRootTelemetry = field(default_factory=SequenceRootTelemetry)


_WORD_GAP = re.compile(r"\b(gap|missing|skipped|out[ _-]?of[ _-]?order)\b", re.I)
_WORD_DUPLICATE = re.compile(r"\b(duplicate|duplicated|already[ _-]?(?:used|seen))\b", re.I)
_WORD_SEQUENCE = re.compile(r"\b(seq(?:uence)?(?:num|number)?|srvseq)\b", re.I)


def _sequence_sources(value: str) -> tuple[SequenceDesyncSource, ...]:
    normalized = value.strip()
    upper = normalized.upper().replace("-", "_").replace(" ", "_")
    if upper in {"FORCE_RESYNC", "MATCH_FORCE_RESYNC"}:
        return (SequenceDesyncSource.FORCE_RESYNC,)
    mentions_sequence = bool(_WORD_SEQUENCE.search(normalized)) or upper.startswith("SEQ_")
    gap = mentions_sequence and bool(_WORD_GAP.search(normalized))
    duplicate = mentions_sequence and bool(_WORD_DUPLICATE.search(normalized))
    if upper in {"SEQ_GAP", "SEQUENCE_GAP", "SEQNUM_GAP"} or upper.endswith(
        "_SEQ_GAP"
    ):
        gap = True
    if upper in {"SEQ_DUPLICATE", "SEQUENCE_DUPLICATE", "SEQNUM_DUPLICATE"} or upper.endswith(
        "_SEQ_DUPLICATE"
    ):
        duplicate = True
    sources: list[SequenceDesyncSource] = []
    if gap:
        sources.append(SequenceDesyncSource.MATCH_REJECT_SEQ_GAP)
    if duplicate:
        sources.append(SequenceDesyncSource.MATCH_REJECT_SEQ_DUPLICATE)
    return tuple(sources)


def classify_sequence_signal(
    *,
    event_type: str,
    reject_code: str | int | None = None,
    reject_reason: str | None = None,
    fallback_text: str | None = None,
) -> SequenceDesyncSignal | None:
    """Classify strong server evidence, preferring structured DTO fields.

    ``ChatMessageDTO.rejectReason`` is a declared structured field at +0x100.
    Free-text payload matching is allowed only when neither code nor that field
    is populated.  Unrelated MATCH_REJECT messages are intentionally ignored.
    """

    kind = str(event_type or "").strip().upper()
    if kind == "FORCE_RESYNC":
        return SequenceDesyncSignal(
            kind,
            (SequenceDesyncSource.FORCE_RESYNC,),
            None,
            "FORCE_RESYNC",
            "event_type",
        )
    if kind != "MATCH_REJECT":
        return None

    field_name: str
    structured: str | int | None
    if reject_code is not None and str(reject_code).strip():
        structured = reject_code
        field_name = "reject_code"
    elif reject_reason is not None and reject_reason.strip():
        structured = reject_reason
        field_name = "ChatMessageDTO.rejectReason"
    elif fallback_text is not None and fallback_text.strip():
        structured = fallback_text
        field_name = "fallback_text"
    else:
        return None

    sources = _sequence_sources(str(structured))
    if not sources:
        return None
    if sources == (SequenceDesyncSource.MATCH_REJECT_SEQ_GAP,):
        reject_kind = SequenceRejectKind.SEQ_GAP
    elif sources == (SequenceDesyncSource.MATCH_REJECT_SEQ_DUPLICATE,):
        reject_kind = SequenceRejectKind.SEQ_DUPLICATE
    elif SequenceDesyncSource.FORCE_RESYNC in sources:
        reject_kind = None
    else:
        reject_kind = SequenceRejectKind.MULTIPLE
    return SequenceDesyncSignal(
        kind,
        sources,
        reject_kind,
        structured,
        field_name,
        fallback_text,
    )


def _aggregate_source(values: Iterable[SequenceDesyncSource]) -> SequenceDesyncSource:
    unique = set(values)
    return next(iter(unique)) if len(unique) == 1 else SequenceDesyncSource.MULTIPLE


class SequenceDesyncTracker:
    """Sticky, explicitly session-scoped terminal-state tracker."""

    def __init__(self) -> None:
        self._state = SequenceDesyncState()
        self._active_session: Any | None = None
        self._active_match_id: str | None = None
        self._old_session_ended = False
        self._sources: set[SequenceDesyncSource] = set()

    @property
    def state(self) -> SequenceDesyncState:
        return self._state

    @property
    def active_session(self) -> Any | None:
        return self._active_session

    def begin_session(self, session_key: Any, match_id: str, *, clean: bool) -> bool:
        if session_key is None or not str(match_id).strip():
            raise ValueError("session_key and match_id are required")
        if self._active_session is None and not self._state.detected:
            self._active_session = session_key
            self._active_match_id = match_id
            self._old_session_ended = False
            return True
        if session_key == self._active_session and match_id == self._active_match_id:
            return True
        if not (clean and self._old_session_ended):
            return False
        self._active_session = session_key
        self._active_match_id = match_id
        self._old_session_ended = False
        self._sources.clear()
        self._state = SequenceDesyncState()
        return True

    def end_session(self, session_key: Any | None = None) -> None:
        if session_key is None or session_key == self._active_session:
            self._old_session_ended = True

    def observe(
        self,
        signal: SequenceDesyncSignal | None,
        *,
        timestamp: str,
        session_key: Any,
        match_id: str,
        turn: int | None,
        srv_seq: int | None,
        root_telemetry: SequenceRootTelemetry | None = None,
    ) -> bool:
        """Return ``True`` only for the first terminal detection in a session."""

        if signal is None:
            return False
        if session_key != self._active_session or match_id != self._active_match_id:
            return False
        first = not self._state.detected
        self._sources.update(signal.sources)
        evidence = tuple(dict.fromkeys((*self._state.evidence_fields, signal.evidence_field)))
        reject_count = self._state.reject_count + (
            1 if signal.event_type == "MATCH_REJECT" else 0
        )
        reject_kind = signal.reject_kind or self._state.reject_kind
        if (
            self._state.reject_kind is not None
            and signal.reject_kind is not None
            and self._state.reject_kind != signal.reject_kind
        ):
            reject_kind = SequenceRejectKind.MULTIPLE
        self._state = SequenceDesyncState(
            detected=True,
            source=_aggregate_source(self._sources),
            first_seen_at=(timestamp if first else self._state.first_seen_at),
            last_seen_at=timestamp,
            session_key=session_key,
            match_id=match_id,
            turn=turn,
            srv_seq=srv_seq,
            reject_count=reject_count,
            terminal_for_session=True,
            reject_kind=reject_kind,
            evidence_fields=evidence,
            root_telemetry=root_telemetry or self._state.root_telemetry,
        )
        return first


class RecoveryLifecycleState(str, Enum):
    ACTIVE_COMBAT = "ACTIVE_COMBAT"
    SEQUENCE_DESYNC = "SEQUENCE_DESYNC"
    RECOVERY_REQUIRED = "RECOVERY_REQUIRED"
    RECOVERY_REQUESTED = "RECOVERY_REQUESTED"
    EXIT_CONTROL_CLICKED = "EXIT_CONTROL_CLICKED"
    CONFIRM_MODAL_VISIBLE = "CONFIRM_MODAL_VISIBLE"
    LEAVING_COMBAT = "LEAVING_COMBAT"
    BOSS_MAP_OR_LOBBY = "BOSS_MAP_OR_LOBBY"
    READY_FOR_NEW_MATCH = "READY_FOR_NEW_MATCH"
    RECOVERY_BLOCKED = "RECOVERY_BLOCKED"


class RecoveryStateMachine:
    """Fail-closed state machine for user-confirmed normal UI recovery."""

    def __init__(self) -> None:
        self.state = RecoveryLifecycleState.ACTIVE_COMBAT
        self.history = [self.state]
        self.blocked_reason: str | None = None

    def _set(self, value: RecoveryLifecycleState) -> None:
        if value is not self.state:
            self.state = value
            self.history.append(value)

    def desync_detected(self) -> None:
        self._set(RecoveryLifecycleState.SEQUENCE_DESYNC)
        self._set(RecoveryLifecycleState.RECOVERY_REQUIRED)

    def manual_test_required(self) -> None:
        """Arm the same UI path without claiming a real desync signal."""

        if self.state is RecoveryLifecycleState.ACTIVE_COMBAT:
            self._set(RecoveryLifecycleState.RECOVERY_REQUIRED)

    def request(self) -> bool:
        if self.state is not RecoveryLifecycleState.RECOVERY_REQUIRED:
            return False
        self._set(RecoveryLifecycleState.RECOVERY_REQUESTED)
        return True

    def exit_control_clicked(self) -> bool:
        if self.state is not RecoveryLifecycleState.RECOVERY_REQUESTED:
            return False
        self._set(RecoveryLifecycleState.EXIT_CONTROL_CLICKED)
        return True

    def modal_visible(self) -> bool:
        if self.state is not RecoveryLifecycleState.EXIT_CONTROL_CLICKED:
            return False
        self._set(RecoveryLifecycleState.CONFIRM_MODAL_VISIBLE)
        return True

    def observe_lifecycle(self, lifecycle: CombatLifecycleState) -> None:
        if self.state in {
            RecoveryLifecycleState.CONFIRM_MODAL_VISIBLE,
            RecoveryLifecycleState.EXIT_CONTROL_CLICKED,
        } and lifecycle in {
            CombatLifecycleState.LEAVING,
            CombatLifecycleState.POSTMATCH,
        }:
            self._set(RecoveryLifecycleState.LEAVING_COMBAT)
        if self.state in {
            RecoveryLifecycleState.CONFIRM_MODAL_VISIBLE,
            RecoveryLifecycleState.LEAVING_COMBAT,
            RecoveryLifecycleState.EXIT_CONTROL_CLICKED,
        } and lifecycle in {
            CombatLifecycleState.LOBBY,
            CombatLifecycleState.STALE_SERVER_MATCH,
        }:
            self._set(RecoveryLifecycleState.BOSS_MAP_OR_LOBBY)

    def ready_for_new_match(self, *, clean_new_session: bool) -> bool:
        if (
            self.state is RecoveryLifecycleState.BOSS_MAP_OR_LOBBY
            and clean_new_session
        ):
            self._set(RecoveryLifecycleState.READY_FOR_NEW_MATCH)
            return True
        return False

    def block(self, reason: str) -> None:
        self.blocked_reason = reason
        self._set(RecoveryLifecycleState.RECOVERY_BLOCKED)


class BoardTerminalKind(str, Enum):
    NONE = "NONE"
    DEAD_BOARD = "DEAD_BOARD"
    SEQUENCE_DESYNC = "SEQUENCE_DESYNC"
    POLICY_NO_SAFE_MOVE = "POLICY_NO_SAFE_MOVE"


def classify_board_terminal(
    *,
    legal_move_count: int | None,
    safe_move_count: int | None,
    sequence_desync: SequenceDesyncState | None,
) -> BoardTerminalKind:
    if sequence_desync is not None and sequence_desync.terminal_for_session:
        return BoardTerminalKind.SEQUENCE_DESYNC
    if legal_move_count == 0:
        return BoardTerminalKind.DEAD_BOARD
    if legal_move_count is not None and legal_move_count > 0 and safe_move_count == 0:
        return BoardTerminalKind.POLICY_NO_SAFE_MOVE
    return BoardTerminalKind.NONE


class SequenceEventRing:
    def __init__(self, max_events: int = 50) -> None:
        if not 20 <= max_events <= 50:
            raise ValueError("sequence event ring must retain 20..50 events")
        self._items: deque[dict[str, Any]] = deque(maxlen=max_events)

    def append(self, event: Mapping[str, Any]) -> None:
        self._items.append(dict(event))

    def snapshot(self) -> tuple[dict[str, Any], ...]:
        return tuple(dict(item) for item in self._items)


def sequence_jsonable(value: Any) -> Any:
    if is_dataclass(value):
        return sequence_jsonable(asdict(value))
    if isinstance(value, Enum):
        return value.value
    if isinstance(value, Mapping):
        return {str(key): sequence_jsonable(item) for key, item in value.items()}
    if isinstance(value, (tuple, list, set)):
        return [sequence_jsonable(item) for item in value]
    return value


__all__ = [
    "BoardTerminalKind",
    "RecoveryLifecycleState",
    "RecoveryStateMachine",
    "SequenceDesyncSignal",
    "SequenceDesyncSource",
    "SequenceDesyncState",
    "SequenceDesyncTracker",
    "SequenceEventRing",
    "SequenceRejectKind",
    "SequenceRootTelemetry",
    "classify_board_terminal",
    "classify_sequence_signal",
    "sequence_jsonable",
]
