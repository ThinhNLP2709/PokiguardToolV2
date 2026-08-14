"""Correlation model for read-only Fusion attempt instrumentation.

The tracker never proposes or executes input.  It correlates the durable
``LocalFusionLastAttemptTurn`` transition, transient ``MATCH_FUSION_RES`` and
before/after runtime snapshots without inventing mana, turn or idle changes.
"""

from __future__ import annotations

from dataclasses import asdict, dataclass, field
from enum import Enum
from typing import Any

from .state import FusionState


class FusionIdleReset(str, Enum):
    CONFIRMED = "CONFIRMED"
    NO_RESET = "NO_RESET"
    UNKNOWN = "UNKNOWN"


class FusionTurnConsumption(str, Enum):
    NOT_CONSUMED_AT_RESPONSE = "NOT_CONSUMED_AT_RESPONSE"
    TURN_CHANGED = "TURN_CHANGED"
    UNKNOWN = "UNKNOWN"


@dataclass(frozen=True)
class FusionRuntimeSnapshot:
    session_id: str
    timestamp: str
    mana: int | None
    current_turn_player: str | None
    local_username: str | None
    turn_number: int | None
    turn_remaining: int | None
    idle_count: int | None
    idle_threshold: int | None
    idle_authoritative: bool
    fusion: FusionState | None
    ui_interactable: bool | None
    ui_address: int | None = None

    @property
    def is_local_turn(self) -> bool | None:
        if not self.current_turn_player or not self.local_username:
            return None
        return self.current_turn_player.casefold() == self.local_username.casefold()


@dataclass(frozen=True)
class FusionResponse:
    observed_timestamp: str
    server_timestamp: str | None
    success: bool | None
    reason: str | None = None
    code: str | int | None = None
    message_address: int | None = None


@dataclass
class FusionAttemptRecord:
    attempt_id: int
    session_id: str
    attempt_turn: int | None
    attempt_timestamp: str
    before: FusionRuntimeSnapshot | None
    request_evidence: list[str] = field(default_factory=list)
    request_state: FusionRuntimeSnapshot | None = None
    response: FusionResponse | None = None
    response_snapshot: FusionRuntimeSnapshot | None = None
    after_response: FusionRuntimeSnapshot | None = None
    actionable_again: FusionRuntimeSnapshot | None = None
    retry_allowed: bool | None = None
    same_turn_retry_observed: bool = False
    confounding_activities: list[str] = field(default_factory=list)
    idle_reset: FusionIdleReset = FusionIdleReset.UNKNOWN

    @property
    def mana_delta(self) -> int | None:
        if (
            self.before is None
            or self.after_response is None
            or self.before.mana is None
            or self.after_response.mana is None
        ):
            return None
        return self.after_response.mana - self.before.mana

    @property
    def turn_consumption(self) -> FusionTurnConsumption:
        if self.before is None or self.after_response is None:
            return FusionTurnConsumption.UNKNOWN
        if (
            self.before.turn_number == self.after_response.turn_number
            and self.before.is_local_turn is True
            and self.after_response.is_local_turn is True
        ):
            return FusionTurnConsumption.NOT_CONSUMED_AT_RESPONSE
        if self.before.turn_number != self.after_response.turn_number:
            return FusionTurnConsumption.TURN_CHANGED
        return FusionTurnConsumption.UNKNOWN

    def payload(self) -> dict[str, Any]:
        return {
            "attemptId": self.attempt_id,
            "session": self.session_id,
            "turn": self.attempt_turn,
            "timestamp": self.attempt_timestamp,
            "before": asdict(self.before) if self.before else None,
            "requestEvidence": list(self.request_evidence),
            "requestState": asdict(self.request_state) if self.request_state else None,
            "response": asdict(self.response) if self.response else None,
            "responseSnapshot": (
                asdict(self.response_snapshot) if self.response_snapshot else None
            ),
            "after": asdict(self.after_response) if self.after_response else None,
            "actionableAgain": (
                asdict(self.actionable_again) if self.actionable_again else None
            ),
            "semantics": {
                "manaDelta": self.mana_delta,
                "turnConsumption": self.turn_consumption.value,
                "retryAllowed": self.retry_allowed,
                "sameTurnRetryObserved": self.same_turn_retry_observed,
                "idleReset": self.idle_reset.value,
                "confoundingActivities": list(self.confounding_activities),
            },
        }


class FusionAttemptTracker:
    """Stateful correlation for one watcher process; all outputs are evidence."""

    def __init__(self) -> None:
        self._session: str | None = None
        self._previous: FusionRuntimeSnapshot | None = None
        self._records: list[FusionAttemptRecord] = []
        self._next_id = 1

    @property
    def records(self) -> tuple[FusionAttemptRecord, ...]:
        return tuple(self._records)

    def begin_session(self, session_id: str) -> None:
        if session_id != self._session:
            self._session = session_id
            self._previous = None

    def end_session(self) -> None:
        self._session = None
        self._previous = None

    def _new_record(
        self,
        snapshot: FusionRuntimeSnapshot,
        *,
        evidence: str,
        before: FusionRuntimeSnapshot | None,
        attempt_turn: int | None = None,
    ) -> FusionAttemptRecord:
        record = FusionAttemptRecord(
            attempt_id=self._next_id,
            session_id=snapshot.session_id,
            attempt_turn=(
                attempt_turn
                if attempt_turn is not None
                else (
                    snapshot.fusion.last_attempt_turn
                    if snapshot.fusion is not None
                    else snapshot.turn_number
                )
            ),
            attempt_timestamp=snapshot.timestamp,
            before=before,
            request_evidence=[evidence],
            request_state=snapshot,
        )
        self._next_id += 1
        previous = self._records[-1] if self._records else None
        if (
            previous is not None
            and previous.session_id == record.session_id
            and previous.attempt_turn == record.attempt_turn
            and previous.response is not None
            and previous.response.success is False
        ):
            record.same_turn_retry_observed = True
        self._records.append(record)
        return record

    def observe_snapshot(
        self, snapshot: FusionRuntimeSnapshot
    ) -> tuple[FusionAttemptRecord, ...]:
        self.begin_session(snapshot.session_id)
        changed: list[FusionAttemptRecord] = []
        previous = self._previous
        current_fusion = snapshot.fusion
        previous_fusion = previous.fusion if previous is not None else None
        attempt_transition = bool(
            current_fusion is not None
            and current_fusion.last_attempt_turn is not None
            and current_fusion.last_attempt_turn >= 0
            and (
                previous_fusion is None
                or current_fusion.last_attempt_turn
                != previous_fusion.last_attempt_turn
            )
        )
        if attempt_transition:
            provisional = next(
                (
                    value
                    for value in reversed(self._records)
                    if value.session_id == snapshot.session_id
                    and value.response is not None
                    and (
                        value.attempt_turn is None
                        or value.attempt_turn < 0
                        or value.attempt_turn == current_fusion.last_attempt_turn
                    )
                    and (
                        "MATCH_FUSION_RES response (request transition not retained)"
                        in value.request_evidence
                    )
                    and (
                        "MatchService.LocalFusionLastAttemptTurn changed"
                        not in value.request_evidence
                    )
                ),
                None,
            )
            if provisional is not None:
                provisional.attempt_turn = current_fusion.last_attempt_turn
                if (
                    "MatchService.LocalFusionLastAttemptTurn changed"
                    not in provisional.request_evidence
                ):
                    provisional.request_evidence.append(
                        "MatchService.LocalFusionLastAttemptTurn changed"
                    )
                provisional.request_state = snapshot
                # The server DTO can become visible one poll before the durable
                # MatchService fields.  This is the first settled post-response
                # snapshot and replaces only the provisional one.
                provisional.after_response = snapshot
                changed.append(provisional)
            else:
                changed.append(
                    self._new_record(
                        snapshot,
                        evidence="MatchService.LocalFusionLastAttemptTurn changed",
                        before=previous,
                    )
                )
        elif (
            current_fusion is not None
            and current_fusion.used
            and (previous_fusion is None or not previous_fusion.used)
        ):
            pending = next(
                (
                    value
                    for value in reversed(self._records)
                    if value.session_id == snapshot.session_id
                    and value.attempt_turn == current_fusion.last_attempt_turn
                ),
                None,
            )
            if pending is None:
                pending = self._new_record(
                    snapshot,
                    evidence="MatchService.LocalFusionUsed changed true",
                    before=previous,
                )
            elif "MatchService.LocalFusionUsed changed true" not in pending.request_evidence:
                pending.request_evidence.append(
                    "MatchService.LocalFusionUsed changed true"
                )
            pending.request_state = snapshot
            changed.append(pending)

        for record in reversed(self._records):
            if record.session_id != snapshot.session_id or record.response is None:
                continue
            # Preserve the closest snapshot captured with the response.  Later
            # board/card activity must not contaminate observed mana/turn deltas.
            if record.after_response is None:
                record.after_response = snapshot
            fusion = snapshot.fusion
            response_complete = record.response.success is not None
            actionable = bool(
                response_complete
                and fusion is not None
                and fusion.enabled
                and not fusion.used
                and not fusion.locked_this_turn
                and snapshot.ui_interactable is True
            )
            if actionable:
                record.actionable_again = snapshot
                record.retry_allowed = True
                changed.append(record)
            elif record.response.success is True:
                record.retry_allowed = False
            elif record.actionable_again is not None:
                # Historical fact: this failed attempt did become retryable.
                # A later attempt/success must not erase that observation.
                record.retry_allowed = True
            elif fusion is not None and fusion.used:
                record.retry_allowed = False
            elif response_complete:
                # False means "not yet proven actionable", never "retry now".
                record.retry_allowed = False
            break
        self._previous = snapshot
        return _dedupe(changed)

    def observe_response(
        self,
        response: FusionResponse,
        snapshot: FusionRuntimeSnapshot,
    ) -> FusionAttemptRecord:
        self.begin_session(snapshot.session_id)
        fusion = snapshot.fusion
        durable_attempt_turn = (
            fusion.last_attempt_turn if fusion is not None else None
        )
        attempt_turn = durable_attempt_turn
        if (
            snapshot.is_local_turn is True
            and snapshot.turn_number is not None
            and snapshot.turn_number >= 0
            and snapshot.turn_number != durable_attempt_turn
        ):
            # The response DTO routinely becomes visible before MatchService
            # publishes LastAttemptTurn for the current click.  Attribute the
            # provisional record to the live local turn, then merge it when the
            # durable transition arrives.
            attempt_turn = snapshot.turn_number
        record = next(
            (
                value
                for value in reversed(self._records)
                if value.session_id == snapshot.session_id
                and value.response is None
                and (attempt_turn is None or value.attempt_turn == attempt_turn)
            ),
            None,
        )
        if record is None:
            record = self._new_record(
                snapshot,
                evidence="MATCH_FUSION_RES response (request transition not retained)",
                before=self._previous,
                attempt_turn=attempt_turn,
            )
        record.response = response
        record.response_snapshot = snapshot
        record.after_response = snapshot
        if fusion is not None and fusion.drop_reason and not response.reason:
            record.response = FusionResponse(
                observed_timestamp=response.observed_timestamp,
                server_timestamp=response.server_timestamp,
                success=response.success,
                reason=fusion.drop_reason,
                code=response.code,
                message_address=response.message_address,
            )
        self.observe_snapshot(snapshot)
        return record

    def observe_activity(self, session_id: str, kind: str) -> None:
        if kind.casefold() == "evolve":
            return
        for record in reversed(self._records):
            if record.session_id == session_id and record.response is not None:
                record.confounding_activities.append(kind)
                return

    def observe_authoritative_idle(
        self,
        session_id: str,
        idle_count: int,
        threshold: int,
    ) -> FusionAttemptRecord | None:
        if idle_count < 0 or threshold <= 0 or idle_count > threshold:
            raise ValueError("invalid authoritative idle payload")
        record = next(
            (
                value
                for value in reversed(self._records)
                if value.session_id == session_id
                and value.response is not None
                and value.idle_reset is FusionIdleReset.UNKNOWN
            ),
            None,
        )
        if record is None:
            return None
        before = record.before
        if (
            before is None
            or not before.idle_authoritative
            or before.idle_count is None
            or record.confounding_activities
        ):
            record.idle_reset = FusionIdleReset.UNKNOWN
        elif idle_count < before.idle_count:
            record.idle_reset = FusionIdleReset.CONFIRMED
        elif idle_count > before.idle_count:
            record.idle_reset = FusionIdleReset.NO_RESET
        return record


def _dedupe(values: list[FusionAttemptRecord]) -> tuple[FusionAttemptRecord, ...]:
    seen: set[int] = set()
    result: list[FusionAttemptRecord] = []
    for value in values:
        if id(value) in seen:
            continue
        seen.add(id(value))
        result.append(value)
    return tuple(result)


__all__ = [
    "FusionAttemptRecord",
    "FusionAttemptTracker",
    "FusionIdleReset",
    "FusionResponse",
    "FusionRuntimeSnapshot",
    "FusionTurnConsumption",
]
