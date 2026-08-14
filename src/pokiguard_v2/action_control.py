"""Single-attempt action identity, acknowledgement lock and two-skip ceiling."""

from __future__ import annotations

from dataclasses import dataclass
from enum import Enum
from typing import Any, Iterable

from .state import CombatSessionKey, GamePhase, GameState


Cell = tuple[int, int]


@dataclass(frozen=True)
class ActionIdentity:
    session_key: CombatSessionKey
    source_srv_seq: int
    source_board_hash: str
    first: Cell
    second: Cell


class AckStatus(str, Enum):
    WAITING = "WAITING"
    ACKNOWLEDGED = "ACKNOWLEDGED"
    TIMEOUT = "TIMEOUT"
    REJECTED = "REJECTED"


class AckOutcome(str, Enum):
    MOVE_ACCEPTED = "MOVE_ACCEPTED"
    TURN_OR_STATE_TRANSITION = "TURN_OR_STATE_TRANSITION"
    SESSION_ENDED = "SESSION_ENDED"
    MOVE_NO_STATE_CHANGE = "MOVE_NO_STATE_CHANGE"
    REJECTED_SEQUENCE_DESYNC = "REJECTED_SEQUENCE_DESYNC"


@dataclass(frozen=True)
class AckResult:
    status: AckStatus
    outcome: AckOutcome | None = None
    new_srv_seq: int | None = None
    latency_ms: int | None = None


@dataclass(frozen=True)
class PendingAction:
    identity: ActionIdentity
    source_turn_number: int | None
    source_turn_player: str | None
    sent_at: float


@dataclass(frozen=True)
class SequenceDesyncInvalidation:
    proposal_invalidated: bool
    action_result: AckResult | None


class ActionLock:
    """Reserve each source action once and lock until transition or timeout."""

    def __init__(self, timeout_seconds: float = 7.0) -> None:
        if timeout_seconds <= 0:
            raise ValueError("timeout_seconds must be positive")
        self.timeout_seconds = timeout_seconds
        self._executed: set[ActionIdentity] = set()
        self._pending: PendingAction | None = None

    @property
    def locked(self) -> bool:
        return self._pending is not None

    @property
    def pending(self) -> PendingAction | None:
        return self._pending

    @property
    def executed_count(self) -> int:
        return len(self._executed)

    def was_executed(self, identity: ActionIdentity) -> bool:
        return identity in self._executed

    def reserve(self, identity: ActionIdentity) -> bool:
        if self.locked or identity in self._executed:
            return False
        self._executed.add(identity)
        return True

    def begin(
        self,
        identity: ActionIdentity,
        *,
        source_turn_number: int | None,
        source_turn_player: str | None,
        now: float,
    ) -> None:
        if identity not in self._executed:
            raise ValueError("action must be reserved before it is locked")
        if self._pending is not None:
            raise RuntimeError("an input action is already locked")
        self._pending = PendingAction(
            identity,
            source_turn_number,
            source_turn_player,
            now,
        )

    def cancel_without_retry(self) -> None:
        """Release the lock while preserving the one-attempt identity."""

        self._pending = None

    def invalidate_sequence_desync(self, *, now: float) -> AckResult:
        """Immediately terminate ACK waiting after authoritative desync.

        The identity remains consumed in ``_executed`` and therefore cannot be
        retried in this or any subsequent state of the same controller run.
        """

        pending = self._pending
        if pending is None:
            raise RuntimeError("no action is awaiting acknowledgement")
        latency = max(0, round((now - pending.sent_at) * 1000))
        self._pending = None
        return AckResult(
            AckStatus.REJECTED,
            AckOutcome.REJECTED_SEQUENCE_DESYNC,
            latency_ms=latency,
        )

    def observe(
        self,
        state: GameState | None,
        *,
        now: float,
        lifecycle_event: str | None = None,
        observed_srv_seq: int | None = None,
    ) -> AckResult:
        pending = self._pending
        if pending is None:
            raise RuntimeError("no action is awaiting acknowledgement")
        latency = max(0, round((now - pending.sent_at) * 1000))
        if lifecycle_event in {"board_lost", "session_changed"} or (
            state is not None and state.phase is not GamePhase.COMBAT
        ):
            self._pending = None
            return AckResult(
                AckStatus.ACKNOWLEDGED,
                AckOutcome.SESSION_ENDED,
                latency_ms=latency,
            )
        # MatchService._ackedSeqs is available while the renderer/provider is
        # intentionally withholding an unstable GameState.  It is a stronger
        # and earlier transition witness than waiting for the next fully
        # settled board to be published.
        if (
            observed_srv_seq is not None
            and observed_srv_seq > pending.identity.source_srv_seq
        ):
            self._pending = None
            return AckResult(
                AckStatus.ACKNOWLEDGED,
                AckOutcome.MOVE_ACCEPTED,
                observed_srv_seq,
                latency,
            )
        if state is not None and state.phase is GamePhase.COMBAT:
            battle = state.battle
            if battle.session_key != pending.identity.session_key:
                self._pending = None
                return AckResult(
                    AckStatus.ACKNOWLEDGED,
                    AckOutcome.SESSION_ENDED,
                    battle.srv_seq,
                    latency,
                )
            if (
                battle.srv_seq is not None
                and battle.srv_seq > pending.identity.source_srv_seq
            ) or (
                battle.board_hash is not None
                and battle.board_hash != pending.identity.source_board_hash
            ):
                self._pending = None
                return AckResult(
                    AckStatus.ACKNOWLEDGED,
                    AckOutcome.MOVE_ACCEPTED,
                    battle.srv_seq,
                    latency,
                )
            if (
                battle.turn_number != pending.source_turn_number
                or battle.current_turn_player != pending.source_turn_player
            ):
                self._pending = None
                return AckResult(
                    AckStatus.ACKNOWLEDGED,
                    AckOutcome.TURN_OR_STATE_TRANSITION,
                    battle.srv_seq,
                    latency,
                )
        if now - pending.sent_at >= self.timeout_seconds:
            self._pending = None
            return AckResult(
                AckStatus.TIMEOUT,
                AckOutcome.MOVE_NO_STATE_CHANGE,
                latency_ms=latency,
            )
        return AckResult(AckStatus.WAITING, latency_ms=latency)


def invalidate_pending_for_sequence_desync(
    proposal: Any | None,
    action_lock: ActionLock,
    *,
    now: float,
) -> SequenceDesyncInvalidation:
    """Purely coordinate proposal/ACK-lock invalidation for a terminal session."""

    result = (
        action_lock.invalidate_sequence_desync(now=now)
        if action_lock.locked
        else None
    )
    return SequenceDesyncInvalidation(proposal is not None, result)


class SkipTracker:
    """Count each unique local-turn source state once; pause at two skips."""

    def __init__(self, ceiling: int = 2) -> None:
        if ceiling != 2:
            raise ValueError("Phase 2C.1 hard ceiling is exactly two skips")
        self.ceiling = ceiling
        self.consecutive = 0
        self.reasons: list[str] = []
        self._counted: set[tuple[CombatSessionKey, int, str]] = set()
        self.session: CombatSessionKey | None = None
        self.auto_paused = False

    def start_session(self, session: CombatSessionKey) -> None:
        if session != self.session:
            self.session = session
            self.reset()

    def reset(self) -> None:
        self.consecutive = 0
        self.reasons.clear()
        self._counted.clear()
        self.auto_paused = False

    def acknowledged(self) -> None:
        self.reset()

    def record(self, state: GameState, reasons: Iterable[str]) -> bool:
        battle = state.battle
        if (
            state.phase is not GamePhase.COMBAT
            or battle.session_key is None
            or battle.srv_seq is None
            or battle.board_hash is None
            or battle.is_local_turn is not True
        ):
            return False
        self.start_session(battle.session_key)
        if self.auto_paused:
            return False
        key = (battle.session_key, battle.srv_seq, battle.board_hash)
        if key in self._counted:
            return False
        self._counted.add(key)
        reason_text = ",".join(str(reason) for reason in reasons) or "UNKNOWN"
        self.reasons.append(reason_text)
        self.consecutive += 1
        if self.consecutive >= self.ceiling:
            self.auto_paused = True
        return True
