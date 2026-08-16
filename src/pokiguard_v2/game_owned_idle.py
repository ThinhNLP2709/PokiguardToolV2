"""Server-authoritative AFK state and consuming-action reset evidence.

Numeric idle values in this module can only enter through
``observe_server_payload``.  Accepted/rejected actions never increment,
decrement, or set the server counter to zero.  A consuming action may instead
establish a non-numeric reset baseline, but only after repeated runtime reset
evidence has certified that action kind.
"""

from __future__ import annotations

from dataclasses import dataclass, replace
from enum import Enum
from typing import Iterable

from .state import GameOwnedIdleStatus, GameState


class IdleFreshness(str, Enum):
    """What the cached observation proves about the current combat state."""

    EXACT_SERVER_EVENT = "exact_server_event"
    CURRENT_STATE_UNPROVEN = "current_state_unproven"
    SESSION_ENDED = "session_ended"


class PassReadiness(str, Enum):
    """Production PASS readiness; names intentionally match the task model."""

    UNKNOWN = GameOwnedIdleStatus.UNKNOWN.value
    RESET_BASELINE_CONFIRMED = GameOwnedIdleStatus.RESET_BASELINE_CONFIRMED.value
    PASS_ALLOWED = GameOwnedIdleStatus.PASS_ALLOWED.value
    PASS_FORBIDDEN_MANDATORY_ACTION = (
        GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION.value
    )


class ResetConfidence(str, Enum):
    RESET_CONFIRMED_EXPLICIT = "reset_confirmed_explicit"
    RESET_CONFIRMED_BY_SERVER_SEQUENCE = "reset_confirmed_by_server_sequence"
    RESET_STRONGLY_INFERRED = "reset_strongly_inferred"
    RESET_UNKNOWN = "reset_unknown"


class AcceptedActivityKind(str, Enum):
    SWAP = "swap"
    CAST = "cast"
    EVOLVE = "evolve"


_CONSUMING_KINDS = frozenset(
    {AcceptedActivityKind.SWAP, AcceptedActivityKind.CAST}
)


@dataclass(frozen=True)
class AcceptedActivity:
    kind: AcceptedActivityKind
    source_message_type: str
    source_srv_seq: int | None
    source_turn: int | None
    source_timestamp: str | None
    observed_timestamp: str
    idle_before_count: int | None = None
    idle_before_threshold: int | None = None

    def __post_init__(self) -> None:
        expected = {
            AcceptedActivityKind.SWAP: {"MATCH_MOVE_RES"},
            AcceptedActivityKind.CAST: {
                "MATCH_CARD_USE_RES",
                "MATCH_SKILL_USE_RES",
                # A strong read-only runtime proof may establish that CAST
                # consumed the local turn even when the short-lived response
                # DTO was reclaimed first.  This provenance is deliberately
                # distinct from a server response and can never by itself
                # upgrade CAST reset capability to production-ready.
                "DIRECT_CAST_STATE_TRANSITION",
            },
            AcceptedActivityKind.EVOLVE: {"MATCH_FUSION_RES"},
        }
        if self.source_message_type not in expected[self.kind]:
            raise ValueError("accepted activity/source message mismatch")
        if self.source_srv_seq is not None and self.source_srv_seq < 0:
            raise ValueError("source_srv_seq cannot be negative")
        if self.source_turn is not None and self.source_turn < 0:
            raise ValueError("source_turn cannot be negative")
        if not self.observed_timestamp:
            raise ValueError("observed_timestamp is required")
        if (self.idle_before_count is None) != (
            self.idle_before_threshold is None
        ):
            raise ValueError("idle-before count/threshold must be both known or both UNKNOWN")
        if self.idle_before_count is not None:
            if self.idle_before_count < 0:
                raise ValueError("idle_before_count cannot be negative")
            if (
                self.idle_before_threshold is None
                or self.idle_before_threshold <= 0
                or self.idle_before_count > self.idle_before_threshold
            ):
                raise ValueError("idle-before count/threshold is invalid")


@dataclass(frozen=True)
class ResetProof:
    """One ordered runtime cycle proving reset semantics for an action kind."""

    session_id: str
    activity: AcceptedActivity
    confirming_idle_count: int
    confirming_threshold: int
    confirming_source_event: str
    confirming_source_turn: int | None
    confirming_source_srv_seq: int | None
    confirming_source_timestamp: str | None
    confidence: ResetConfidence

    def __post_init__(self) -> None:
        if self.activity.kind not in _CONSUMING_KINDS:
            raise ValueError("EVOLVE cannot produce a consuming reset proof")
        if self.activity.idle_before_count is None:
            raise ValueError("reset proof requires an authoritative idle-before value")
        if self.confirming_idle_count != 1:
            raise ValueError("runtime reset proof requires the next idle warning to be 1")
        if self.confirming_threshold <= 1:
            raise ValueError("reset proof threshold must allow at least one later PASS")
        if self.confidence is ResetConfidence.RESET_UNKNOWN:
            raise ValueError("reset proof confidence cannot be UNKNOWN")

    @property
    def identity(self) -> tuple[object, ...]:
        return (
            self.session_id,
            self.activity.kind,
            self.activity.source_timestamp,
            self.activity.source_srv_seq,
            self.activity.source_turn,
            self.confirming_source_timestamp,
            self.confirming_source_srv_seq,
            self.confirming_source_turn,
        )


@dataclass(frozen=True)
class ResetCapability:
    kind: AcceptedActivityKind
    confirmations: int
    required_confirmations: int
    confidence: ResetConfidence
    proof_identities: tuple[tuple[object, ...], ...] = ()

    def __post_init__(self) -> None:
        if self.kind not in _CONSUMING_KINDS:
            raise ValueError("only SWAP/CAST can be reset capabilities")
        if self.confirmations < 0 or self.required_confirmations <= 0:
            raise ValueError("reset capability confirmation counts are invalid")
        if self.confirmations != len(self.proof_identities):
            raise ValueError("confirmations must equal unique proof identities")

    @property
    def production_ready(self) -> bool:
        return bool(
            self.confirmations >= self.required_confirmations
            and self.confidence
            in {
                ResetConfidence.RESET_CONFIRMED_EXPLICIT,
                ResetConfidence.RESET_CONFIRMED_BY_SERVER_SEQUENCE,
            }
        )


@dataclass(frozen=True)
class ResetBaseline:
    session_id: str
    activity: AcceptedActivity
    capability: ResetCapability

    def __post_init__(self) -> None:
        if not self.capability.production_ready:
            raise ValueError("reset baseline requires a production-ready capability")
        if self.activity.kind is not self.capability.kind:
            raise ValueError("baseline activity/capability mismatch")


@dataclass(frozen=True)
class GameOwnedIdleState:
    session_id: str
    username: str
    idle_count: int
    threshold: int
    source_message_type: str
    source_srv_seq: int | None
    source_turn: int | None
    source_timestamp: str | None
    observed_timestamp: str
    authoritative: bool = True
    freshness: IdleFreshness = IdleFreshness.EXACT_SERVER_EVENT
    stale_reason: str | None = None
    reset_confidence: ResetConfidence = ResetConfidence.RESET_UNKNOWN
    reset_activity: AcceptedActivity | None = None
    reset_from_idle_count: int | None = None
    source_path: str | None = None

    def __post_init__(self) -> None:
        if not self.session_id.strip():
            raise ValueError("session_id is required")
        if not self.username.strip():
            raise ValueError("username is required")
        if self.idle_count < 0:
            raise ValueError("idle_count cannot be negative")
        if self.threshold <= 0 or self.idle_count > self.threshold:
            raise ValueError("idle_count/threshold is invalid")
        if self.source_message_type not in {"MATCH_AFK_WARN", "MATCH_TURN_END"}:
            raise ValueError("source_message_type is not an authoritative idle source")
        if self.source_srv_seq is not None and self.source_srv_seq < 0:
            raise ValueError("source_srv_seq cannot be negative")
        if self.source_turn is not None and self.source_turn < 0:
            raise ValueError("source_turn cannot be negative")
        if not self.observed_timestamp:
            raise ValueError("observed_timestamp is required")
        if not self.authoritative:
            raise ValueError("GameOwnedIdleState only accepts authoritative payloads")
        if self.freshness is IdleFreshness.EXACT_SERVER_EVENT and self.stale_reason:
            raise ValueError("a fresh event cannot have stale_reason")
        if self.reset_from_idle_count is not None and self.reset_from_idle_count < 0:
            raise ValueError("reset_from_idle_count cannot be negative")

    @property
    def status(self) -> PassReadiness:
        if self.freshness is not IdleFreshness.EXACT_SERVER_EVENT:
            return PassReadiness.UNKNOWN
        if self.idle_count >= self.threshold - 1:
            return PassReadiness.PASS_FORBIDDEN_MANDATORY_ACTION
        return PassReadiness.PASS_ALLOWED


@dataclass(frozen=True)
class PassReadinessResult:
    readiness: PassReadiness
    can_pass_now: bool | None
    must_act_now: bool | None
    reason: str
    state: GameOwnedIdleState | None
    reset_baseline: ResetBaseline | None = None


class GameOwnedIdleCache:
    """One-session idle cache with process-lifetime reset capability proofs."""

    def __init__(
        self,
        *,
        required_reset_confirmations: int = 2,
        seeded_capabilities: Iterable[ResetCapability] = (),
    ) -> None:
        if required_reset_confirmations <= 0:
            raise ValueError("required_reset_confirmations must be positive")
        self._required_reset_confirmations = required_reset_confirmations
        self._session_id: str | None = None
        self._state: GameOwnedIdleState | None = None
        self._accepted_activity: AcceptedActivity | None = None
        self._baseline: ResetBaseline | None = None
        self._proofs: dict[AcceptedActivityKind, dict[tuple[object, ...], ResetProof]] = {
            AcceptedActivityKind.SWAP: {},
            AcceptedActivityKind.CAST: {},
        }
        for capability in seeded_capabilities:
            if not capability.production_ready:
                raise ValueError("seeded reset capability is not production-ready")
            # Seed identities are retained as opaque, already-audited proof
            # keys. Runtime proofs may add further distinct identities.
            for identity in capability.proof_identities:
                self._proofs[capability.kind][identity] = None  # type: ignore[assignment]
            self._seeded_confidence = getattr(self, "_seeded_confidence", {})
            self._seeded_confidence[capability.kind] = capability.confidence

    @property
    def state(self) -> GameOwnedIdleState | None:
        return self._state

    @property
    def reset_baseline(self) -> ResetBaseline | None:
        return self._baseline

    @property
    def pending_reset_activity(self) -> AcceptedActivity | None:
        return self._accepted_activity

    def reset_capability(self, kind: AcceptedActivityKind) -> ResetCapability:
        if kind not in _CONSUMING_KINDS:
            raise ValueError("EVOLVE has no consuming reset capability")
        proofs = self._proofs[kind]
        confidence = getattr(self, "_seeded_confidence", {}).get(
            kind, ResetConfidence.RESET_UNKNOWN
        )
        for proof in proofs.values():
            if proof is None:
                continue
            if proof.confidence is ResetConfidence.RESET_CONFIRMED_EXPLICIT:
                confidence = proof.confidence
                break
            if proof.confidence is ResetConfidence.RESET_CONFIRMED_BY_SERVER_SEQUENCE:
                confidence = proof.confidence
            elif confidence is ResetConfidence.RESET_UNKNOWN:
                confidence = proof.confidence
        return ResetCapability(
            kind=kind,
            confirmations=len(proofs),
            required_confirmations=self._required_reset_confirmations,
            confidence=confidence,
            proof_identities=tuple(proofs),
        )

    def begin_session(self, session_id: str) -> None:
        if not session_id.strip():
            raise ValueError("session_id is required")
        if self._session_id != session_id:
            self._session_id = session_id
            self._state = None
            self._accepted_activity = None
            self._baseline = None

    @staticmethod
    def _event_is_ordered_after_activity(
        activity: AcceptedActivity,
        *,
        source_srv_seq: int | None,
        source_turn: int | None,
    ) -> bool:
        if (
            activity.source_srv_seq is not None
            and source_srv_seq is not None
            and source_srv_seq > activity.source_srv_seq
        ):
            return True
        return bool(
            activity.source_turn is not None
            and source_turn is not None
            and source_turn > activity.source_turn
        )

    def _reject_stale_turn(self, source_turn: int | None) -> None:
        previous = self._state
        if (
            previous is not None
            and previous.freshness is IdleFreshness.EXACT_SERVER_EVENT
            and previous.source_turn is not None
            and source_turn is not None
            and source_turn < previous.source_turn
        ):
            raise ValueError("stale authoritative idle event turn")

    def observe_server_payload(
        self,
        *,
        session_id: str,
        username: str,
        idle_count: int,
        threshold: int,
        source_message_type: str,
        source_srv_seq: int | None,
        source_turn: int | None,
        source_timestamp: str | None,
        observed_timestamp: str,
        source_path: str | None = None,
    ) -> GameOwnedIdleState:
        """Replace numeric values with an exact payload; never do arithmetic."""

        self.begin_session(session_id)
        self._reject_stale_turn(source_turn)
        previous = self._state
        activity = self._accepted_activity
        reset_confidence = ResetConfidence.RESET_UNKNOWN
        reset_from = None
        proof: ResetProof | None = None

        if idle_count == 0:
            reset_confidence = ResetConfidence.RESET_CONFIRMED_EXPLICIT
            reset_from = previous.idle_count if previous is not None else None
        elif activity is not None and activity.kind in _CONSUMING_KINDS:
            reset_from = activity.idle_before_count
            ordered = self._event_is_ordered_after_activity(
                activity,
                source_srv_seq=source_srv_seq,
                source_turn=source_turn,
            )
            reset_shape = bool(
                activity.idle_before_count is not None
                and activity.idle_before_threshold == threshold
                and idle_count == 1
            )
            if reset_shape:
                direct_cast_state = bool(
                    activity.kind is AcceptedActivityKind.CAST
                    and activity.source_message_type
                    == "DIRECT_CAST_STATE_TRANSITION"
                )
                reset_confidence = (
                    ResetConfidence.RESET_CONFIRMED_BY_SERVER_SEQUENCE
                    if ordered and not direct_cast_state
                    else ResetConfidence.RESET_STRONGLY_INFERRED
                )
                proof = ResetProof(
                    session_id=session_id,
                    activity=activity,
                    confirming_idle_count=idle_count,
                    confirming_threshold=threshold,
                    confirming_source_event=source_message_type,
                    confirming_source_turn=source_turn,
                    confirming_source_srv_seq=source_srv_seq,
                    confirming_source_timestamp=source_timestamp,
                    confidence=reset_confidence,
                )
            elif (
                previous is not None
                and idle_count < previous.idle_count
            ):
                direct_cast_state = bool(
                    activity.kind is AcceptedActivityKind.CAST
                    and activity.source_message_type
                    == "DIRECT_CAST_STATE_TRANSITION"
                )
                reset_confidence = (
                    ResetConfidence.RESET_CONFIRMED_BY_SERVER_SEQUENCE
                    if ordered and not direct_cast_state
                    else ResetConfidence.RESET_STRONGLY_INFERRED
                )
        elif previous is not None and idle_count < previous.idle_count:
            # A lower exact server value is real state but cannot be attributed
            # to a reset action without a correlated accepted activity.
            reset_from = previous.idle_count
            reset_confidence = ResetConfidence.RESET_STRONGLY_INFERRED

        state = GameOwnedIdleState(
            session_id=session_id,
            username=username,
            idle_count=idle_count,
            threshold=threshold,
            source_message_type=source_message_type,
            source_srv_seq=source_srv_seq,
            source_turn=source_turn,
            source_timestamp=source_timestamp,
            observed_timestamp=observed_timestamp,
            reset_confidence=reset_confidence,
            reset_activity=(
                activity
                if reset_confidence is not ResetConfidence.RESET_UNKNOWN
                else None
            ),
            reset_from_idle_count=reset_from,
            source_path=source_path,
        )
        self._state = state
        self._baseline = None
        if proof is not None and proof.confidence in {
            ResetConfidence.RESET_CONFIRMED_EXPLICIT,
            ResetConfidence.RESET_CONFIRMED_BY_SERVER_SEQUENCE,
        }:
            self._proofs[activity.kind][proof.identity] = proof
        # A direct MATCH_AFK_WARN has no declared turn.  Keep the reset
        # candidate only when that first observation is merely inferred so a
        # later turn-associated MATCH_TURN_END.afkWarn can provide the ordered
        # proof.  Numeric state still comes from the direct payload itself.
        if not (
            proof is not None
            and proof.confidence is ResetConfidence.RESET_STRONGLY_INFERRED
            and source_turn is None
        ):
            self._accepted_activity = None
        return state

    def observe_accepted_activity(
        self,
        *,
        session_id: str,
        kind: AcceptedActivityKind,
        source_message_type: str,
        source_srv_seq: int | None,
        source_turn: int | None,
        source_timestamp: str | None,
        observed_timestamp: str,
    ) -> AcceptedActivity:
        """Record exact acceptance without changing a numeric idle value."""

        self.begin_session(session_id)
        before = self._state
        before_is_exact = bool(
            before is not None
            and before.freshness is IdleFreshness.EXACT_SERVER_EVENT
        )
        activity = AcceptedActivity(
            kind=kind,
            source_message_type=source_message_type,
            source_srv_seq=source_srv_seq,
            source_turn=source_turn,
            source_timestamp=source_timestamp,
            observed_timestamp=observed_timestamp,
            idle_before_count=(before.idle_count if before_is_exact else None),
            idle_before_threshold=(before.threshold if before_is_exact else None),
        )

        if kind is AcceptedActivityKind.EVOLVE:
            # EVOLVE is non-consuming. Preserve a still-fresh exact event and
            # never make it a reset candidate.
            return activity

        self._accepted_activity = activity
        capability = self.reset_capability(kind)
        if capability.production_ready:
            self._baseline = ResetBaseline(session_id, activity, capability)
        # An accepted consuming action whose own reset capability is not yet
        # production-ready does not invalidate an earlier confirmed baseline.
        # With no intervening PASS, that older action still proves the current
        # pass cycle was reset.  Keep the new activity as the candidate for a
        # later server-owned reset proof, but do not discard existing proof.
        self.mark_current_state_unproven(
            session_id, f"accepted_{kind.value}_awaiting_authoritative_idle"
        )
        return activity

    def observe_rejected_activity(
        self, *, session_id: str, kind: AcceptedActivityKind
    ) -> None:
        """Rejected actions never reset or invalidate an exact idle payload."""

        self.begin_session(session_id)
        if self._accepted_activity is not None and self._accepted_activity.kind is kind:
            self._accepted_activity = None
        # Rejection of a newer attempted action cannot invalidate an already
        # confirmed consuming-action baseline from the same session.

    def mark_current_state_unproven(self, session_id: str, reason: str) -> None:
        if (
            self._state is None
            or self._session_id != session_id
            or self._state.freshness is not IdleFreshness.EXACT_SERVER_EVENT
        ):
            return
        self._state = replace(
            self._state,
            freshness=IdleFreshness.CURRENT_STATE_UNPROVEN,
            stale_reason=reason,
        )

    def associate_direct_pass_result_with_turn(
        self,
        *,
        session_id: str,
        completed_pass_turn: int,
        current_local_turn: int,
    ) -> GameOwnedIdleState:
        """Attach a newly observed direct AFK result to the next local turn.

        This changes no numeric value.  It is permitted only for an exact
        direct MATCH_AFK_WARN already correlated by PASS_WAIT and a strictly
        later local turn in the same session.
        """

        if self._session_id != session_id or self._state is None:
            raise ValueError("direct PASS result session mismatch")
        state = self._state
        if (
            state.freshness is not IdleFreshness.EXACT_SERVER_EVENT
            or state.source_message_type != "MATCH_AFK_WARN"
            or state.source_turn is not None
            or current_local_turn <= completed_pass_turn
        ):
            raise ValueError("idle state is not an associable direct PASS result")
        self._state = replace(
            state,
            source_turn=current_local_turn,
            source_path="MATCH_AFK_WARN+PASS_WAIT_turn_correlation",
        )
        return self._state

    def end_session(self, session_id: str) -> None:
        if self._session_id == session_id:
            self.clear("combat_session_ended")

    def clear(self, _reason: str) -> None:
        self._state = None
        self._accepted_activity = None
        self._baseline = None
        self._session_id = None

    def pass_readiness(
        self,
        *,
        current_session_id: str | None,
        local_username: str | None,
        current_turn: int | None = None,
        is_local_turn: bool | None = None,
        lifecycle_active: bool | None = None,
        is_first_local_turn: bool | None = None,
    ) -> PassReadinessResult:
        """Map only current, session-bound authoritative/reset evidence."""

        state = self._state
        baseline = self._baseline
        if lifecycle_active is not True:
            reason = "combat_lifecycle_not_active"
        elif current_session_id is None or current_session_id != self._session_id:
            reason = "idle_state_session_mismatch"
        elif is_local_turn is not True or current_turn is None:
            reason = "idle_state_requires_current_local_turn"
        elif is_first_local_turn is True:
            return PassReadinessResult(
                PassReadiness.PASS_FORBIDDEN_MANDATORY_ACTION,
                can_pass_now=False,
                must_act_now=True,
                reason="first_local_turn_absolutely_forbids_pass",
                state=state,
                reset_baseline=baseline,
            )
        elif baseline is not None and baseline.session_id == current_session_id:
            return PassReadinessResult(
                PassReadiness.RESET_BASELINE_CONFIRMED,
                can_pass_now=True,
                must_act_now=False,
                reason="production_ready_consuming_reset_baseline",
                state=state,
                reset_baseline=baseline,
            )
        elif state is None:
            reason = "authoritative_idle_payload_not_observed"
        elif local_username is None or local_username.casefold() != state.username.casefold():
            reason = "idle_state_not_owned_by_local_player"
        elif state.freshness is not IdleFreshness.EXACT_SERVER_EVENT:
            reason = f"idle_state_not_current:{state.freshness.value}"
        elif state.source_turn != current_turn:
            reason = "idle_state_source_turn_mismatch"
        else:
            must_act = state.idle_count >= state.threshold - 1
            readiness = (
                PassReadiness.PASS_FORBIDDEN_MANDATORY_ACTION
                if must_act
                else PassReadiness.PASS_ALLOWED
            )
            return PassReadinessResult(
                readiness,
                can_pass_now=not must_act,
                must_act_now=must_act,
                reason="exact_turn_associated_server_idle_payload",
                state=state,
                reset_baseline=None,
            )
        return PassReadinessResult(
            PassReadiness.UNKNOWN,
            None,
            None,
            reason,
            state,
            reset_baseline=baseline,
        )


def apply_idle_readiness_to_state(
    state: GameState, readiness: PassReadinessResult
) -> GameState:
    """Return an immutable policy view without inventing a numeric zero."""

    exact = readiness.state if readiness.readiness in {
        PassReadiness.PASS_ALLOWED,
        PassReadiness.PASS_FORBIDDEN_MANDATORY_ACTION,
    } else None
    baseline = (
        readiness.reset_baseline
        if readiness.readiness is PassReadiness.RESET_BASELINE_CONFIRMED
        else None
    )
    source = None
    evidence = None
    confidence = None
    if exact is not None:
        source = (
            f"{exact.source_path or exact.source_message_type}"
            f"@{exact.observed_timestamp}"
        )
        evidence = (
            exact.reset_activity.kind.value
            if exact.reset_activity is not None
            else None
        )
        confidence = exact.reset_confidence.value
    elif baseline is not None:
        source = "accepted_consuming_reset_baseline"
        evidence = (
            f"{baseline.activity.kind.value}:"
            f"{baseline.activity.source_message_type}:"
            f"turn={baseline.activity.source_turn}:"
            f"seq={baseline.activity.source_srv_seq}"
        )
        confidence = baseline.capability.confidence.value

    return replace(
        state,
        battle=replace(
            state.battle,
            consecutive_passes=(exact.idle_count if exact is not None else None),
            consecutive_pass_threshold=(
                exact.threshold if exact is not None else None
            ),
            consecutive_pass_source=source,
            consecutive_pass_status=GameOwnedIdleStatus(readiness.readiness.value),
            consecutive_pass_reset_evidence=evidence,
            consecutive_pass_confidence=confidence,
        ),
    )


__all__ = [
    "AcceptedActivity",
    "AcceptedActivityKind",
    "apply_idle_readiness_to_state",
    "GameOwnedIdleCache",
    "GameOwnedIdleState",
    "IdleFreshness",
    "PassReadiness",
    "PassReadinessResult",
    "ResetBaseline",
    "ResetCapability",
    "ResetConfidence",
    "ResetProof",
]
