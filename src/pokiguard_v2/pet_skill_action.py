"""One-shot, fail-closed Pet Skill card/QTE/Perfect execution primitive.

The executor is intentionally policy-free.  A controlled harness supplies a
fresh read-only observation and explicitly invokes one action.  The primitive
owns at most one mouse click, the accepted Phase 3B.2 closed-loop directions,
and one Space confirmation.  Current-generation CardUI runtime ``PERFECT`` is
the terminal acknowledgement for this external input primitive.  Server result
callbacks and post-effect board snapshots belong to the game's own resolution
flow; neither is required for the executor to report that its QTE input
succeeded.  A later gameplay controller must independently wait for its normal
fresh/actionable board gate before sending a SWAP/CAST/EVOLVE input.
"""

from __future__ import annotations

from dataclasses import dataclass, replace
from enum import Enum
import math
import time
import uuid
from typing import Callable, Protocol

from .combat_lifecycle import CombatLifecycleState
from .pet_qte_observer import QteBindingStatus
from .pet_skill_shadow import (
    PetSkillCapability,
    QteEvidenceStatus,
    QteSnapshot,
    QteTimingResult,
)
from .qte_direction_assist import (
    QteAssistEvent,
    QteAssistSummary,
    QteDirectionAssist,
    QteDirectionRecordStatus,
)
from .state import CardState, CombatSessionKey, GamePhase, GameState
from .win32_input import (
    ClickPointResult,
    ClientGeometry,
    WindowBinding,
)


class PetSkillActionState(str, Enum):
    IDLE = "IDLE"
    PREFLIGHT = "PREFLIGHT"
    CARD_CLICK = "CARD_CLICK"
    WAIT_QTE_GENERATION = "WAIT_QTE_GENERATION"
    DIRECTIONS = "DIRECTIONS"
    DIRECTIONS_COMPLETE = "DIRECTIONS_COMPLETE"
    WAIT_PERFECT_TARGET = "WAIT_PERFECT_TARGET"
    CONFIRM_PREFLIGHT = "CONFIRM_PREFLIGHT"
    SPACE_SENT = "SPACE_SENT"
    WAIT_RESULT = "WAIT_RESULT"
    RESULT_CORRELATED = "RESULT_CORRELATED"
    POST_SKILL_REREAD = "POST_SKILL_REREAD"
    COMPLETE = "COMPLETE"
    FAILED = "FAILED"


class PetSkillActionResultKind(str, Enum):
    SUCCESS_PERFECT = "SUCCESS_PERFECT"
    PREFLIGHT_REJECTED = "PREFLIGHT_REJECTED"
    CARD_CLICK_UNCONFIRMED = "CARD_CLICK_UNCONFIRMED"
    CARD_CLICK_SENT_QTE_UNCONFIRMED = "CARD_CLICK_SENT_QTE_UNCONFIRMED"
    QTE_NOT_OBSERVED = "QTE_NOT_OBSERVED"
    QTE_STALE_OR_AMBIGUOUS = "QTE_STALE_OR_AMBIGUOUS"
    DIRECTION_FAILED = "DIRECTION_FAILED"
    DIRECTION_UNCONFIRMED = "DIRECTION_UNCONFIRMED"
    PERFECT_WINDOW_INVALID = "PERFECT_WINDOW_INVALID"
    PERFECT_WINDOW_MISSED = "PERFECT_WINDOW_MISSED"
    SPACE_INPUT_FAILED = "SPACE_INPUT_FAILED"
    SPACE_SENT_RESULT_UNCONFIRMED = "SPACE_SENT_RESULT_UNCONFIRMED"
    TIMING_RESULT_MISMATCH = "TIMING_RESULT_MISMATCH"
    POST_SKILL_REREAD_UNCONFIRMED = "POST_SKILL_REREAD_UNCONFIRMED"
    INVALIDATED = "INVALIDATED"
    EMERGENCY_STOPPED = "EMERGENCY_STOPPED"
    SHUTDOWN = "SHUTDOWN"


class QteSpaceInputStatus(str, Enum):
    SENT = "SENT"
    WINDOW_INVALID = "WINDOW_INVALID"
    WINDOW_CHANGED = "WINDOW_CHANGED"
    GAME_NOT_FOREGROUND = "GAME_NOT_FOREGROUND"
    INPUT_FAILED = "INPUT_FAILED"


@dataclass(frozen=True)
class QteSpaceInputResult:
    status: QteSpaceInputStatus
    virtual_key: int = 0x20
    physical_mapping: str = "VK_SPACE(0x20)"
    logical_presses: int = 0

    @property
    def sent(self) -> bool:
        return self.status is QteSpaceInputStatus.SENT and self.logical_presses == 1


class PetSkillMouseExecutor(Protocol):
    def send_normalized_point(
        self,
        binding: WindowBinding,
        normalized_point: tuple[float, float],
        *,
        settle_cursor: bool = False,
    ) -> ClickPointResult: ...


class SpaceKeyboardBackend(Protocol):
    def client_geometry(self, hwnd: int) -> ClientGeometry | None: ...
    def is_foreground(self, hwnd: int) -> bool: ...
    def window_pid(self, hwnd: int) -> int | None: ...
    def press_virtual_key(self, virtual_key: int) -> bool: ...


class QteSpaceInputExecutor:
    """Narrow foreground-gated confirm boundary; it can emit only Space."""

    def __init__(self, backend: SpaceKeyboardBackend) -> None:
        self._backend = backend

    def send_space(self, binding: WindowBinding) -> QteSpaceInputResult:
        geometry = self._backend.client_geometry(binding.hwnd)
        if self._backend.window_pid(binding.hwnd) != binding.pid or geometry is None:
            status = QteSpaceInputStatus.WINDOW_INVALID
        elif (
            geometry.width != binding.initial_width
            or geometry.height != binding.initial_height
        ):
            status = QteSpaceInputStatus.WINDOW_CHANGED
        elif not self._backend.is_foreground(binding.hwnd):
            status = QteSpaceInputStatus.GAME_NOT_FOREGROUND
        elif not self._backend.press_virtual_key(0x20):
            status = QteSpaceInputStatus.INPUT_FAILED
        else:
            status = QteSpaceInputStatus.SENT
        return QteSpaceInputResult(
            status=status,
            logical_presses=1 if status is QteSpaceInputStatus.SENT else 0,
        )


@dataclass(frozen=True)
class PetSkillCardGeometryProof:
    """Current runtime-identity-to-visual-slot proof for one CardUI/Button."""

    session_key: CombatSessionKey
    card_ui_address: int
    button_address: int
    card_data_address: int
    skill_card_id: int
    window_binding: WindowBinding
    normalized_point: tuple[float, float]
    slot_index: int
    slot_count: int
    source: str

    def __post_init__(self) -> None:
        if min(
            self.card_ui_address,
            self.button_address,
            self.card_data_address,
            self.skill_card_id,
        ) <= 0:
            raise ValueError("Pet Skill geometry identity values must be positive")
        x, y = self.normalized_point
        if not (0.0 <= x <= 1.0 and 0.0 <= y <= 1.0):
            raise ValueError("Pet Skill geometry point is outside the client")
        if not 1 <= self.slot_count <= 16 or not 0 <= self.slot_index < self.slot_count:
            raise ValueError("Pet Skill geometry slot is invalid")
        if not self.source.strip():
            raise ValueError("Pet Skill geometry source is required")


@dataclass(frozen=True)
class PetSkillActionId:
    value: str
    match_id: str
    session_key: CombatSessionKey
    lifecycle_epoch: int
    local_actor: int
    source_turn: int
    skill_card_id: int


@dataclass(frozen=True)
class PetSkillActionObservation:
    """One fresh, read-only preflight sample assembled by the harness."""

    sampled_monotonic: float
    match_id: str | None
    session_key: CombatSessionKey | None
    lifecycle: CombatLifecycleState
    local_actor: int | None
    turn_number: int | None
    is_local_turn: bool | None
    mana: int | None
    power: int | None
    capability: PetSkillCapability | None
    live_card: CardState | None
    geometry: PetSkillCardGeometryProof | None
    qte: QteSnapshot | None
    inactive_qte_proven: bool
    window_binding: WindowBinding | None
    game_foreground: bool = True
    process_running: bool = True
    input_authority_owned: bool = True
    conflicting_gameplay_action: bool = False
    technical_recovery: bool = False
    sequence_desync: bool = False
    postmatch_or_terminal: bool = False
    emergency_stop: bool = False
    shutdown_requested: bool = False
    post_state: GameState | None = None
    post_state_fresh: bool = False
    control_sampled_monotonic: float | None = None
    board_dedup_key: tuple[object, int, str] | None = None


@dataclass(frozen=True)
class PetSkillActionEvent:
    event: str
    state: PetSkillActionState
    monotonic_at: float
    reason: str | None = None
    direction_event: QteAssistEvent | None = None


@dataclass(frozen=True)
class PetSkillActionTelemetry:
    card_click_timestamp: float | None = None
    qte_first_observed_timestamp: float | None = None
    qte_detection_latency: float | None = None
    qte_generation: int | None = None
    sequence_length: int | None = None
    direction_summary: QteAssistSummary | None = None
    directions_complete_elapsed: float | None = None
    perfect_start: float | None = None
    perfect_end: float | None = None
    target_confirm_elapsed: float | None = None
    confirm_target_error: float | None = None
    final_preflight_elapsed: float | None = None
    space_send_timestamp: float | None = None
    space_send_elapsed: float | None = None
    start_margin: float | None = None
    end_margin: float | None = None
    predicted_result: QteTimingResult | None = None
    runtime_result: QteTimingResult | None = None
    runtime_result_text: str | None = None
    server_response_correlated: bool = False
    server_result: QteTimingResult | None = None
    server_result_text: str | None = None
    server_reject_observed: bool = False
    server_reject_reason: str | None = None
    qte_elapsed_ms: int | None = None
    resources_before: tuple[int | None, int | None] = (None, None)
    resources_after: tuple[int | None, int | None] = (None, None)
    turn_before: int | None = None
    turn_after: int | None = None


@dataclass(frozen=True)
class PetSkillActionResult:
    kind: PetSkillActionResultKind
    state: PetSkillActionState
    action_id: PetSkillActionId | None
    reason: str
    card_clicks: int
    space_presses: int
    telemetry: PetSkillActionTelemetry
    post_state: GameState | None = None

    @property
    def success(self) -> bool:
        return self.kind is PetSkillActionResultKind.SUCCESS_PERFECT


class PetSkillActionExecutor:
    """Poll-driven one-action state machine.

    The caller runs this object on an action worker and owns the shared
    ``AutomationControllerLease`` for the complete invocation.  ``step`` never
    sleeps; ``recommended_wait_seconds`` gives a bounded non-busy poll delay.
    """

    def __init__(
        self,
        mouse: PetSkillMouseExecutor,
        directions: QteDirectionAssist,
        space: QteSpaceInputExecutor,
        *,
        qte_generation_timeout_seconds: float = 3.0,
        result_timeout_seconds: float = 15.0,
        post_state_timeout_seconds: float = 15.0,
        maximum_sample_age_seconds: float = 0.35,
        timestamp: Callable[[], float] = time.monotonic,
        action_id_factory: Callable[[], str] = lambda: uuid.uuid4().hex,
    ) -> None:
        if not 0.5 <= qte_generation_timeout_seconds <= 10.0:
            raise ValueError("QTE generation timeout must be between 0.5 and 10 seconds")
        if not 0.5 <= result_timeout_seconds <= 15.0:
            raise ValueError("result timeout must be between 0.5 and 15 seconds")
        if not 0.5 <= post_state_timeout_seconds <= 30.0:
            raise ValueError("post-state timeout must be between 0.5 and 30 seconds")
        if not 0.05 <= maximum_sample_age_seconds <= 1.0:
            raise ValueError("sample age limit must be between 0.05 and 1 second")
        self._mouse = mouse
        self._directions = directions
        self._space = space
        self._qte_timeout = float(qte_generation_timeout_seconds)
        self._result_timeout = float(result_timeout_seconds)
        self._post_timeout = float(post_state_timeout_seconds)
        self._sample_age = float(maximum_sample_age_seconds)
        self._timestamp = timestamp
        self._action_id_factory = action_id_factory
        self._state = PetSkillActionState.IDLE
        self._action_id: PetSkillActionId | None = None
        self._window: WindowBinding | None = None
        self._card_ui: int | None = None
        self._button: int | None = None
        self._card_data: int | None = None
        self._geometry: PetSkillCardGeometryProof | None = None
        self._deadline: float | None = None
        self._qte_identity = None
        self._runtime_completion_identity = None
        self._source_board_key: tuple[object, int, str] | None = None
        self._card_clicks = 0
        self._space_presses = 0
        self._telemetry = PetSkillActionTelemetry()
        self._result: PetSkillActionResult | None = None
        self._events: list[PetSkillActionEvent] = []
        self._logged_qte_initialization_wait = False
        self._logged_qte_cleanup_wait = False

    @property
    def state(self) -> PetSkillActionState:
        return self._state

    @property
    def result(self) -> PetSkillActionResult | None:
        return self._result

    @property
    def action_id(self) -> PetSkillActionId | None:
        return self._action_id

    @property
    def events(self) -> tuple[PetSkillActionEvent, ...]:
        return tuple(self._events)

    @property
    def telemetry(self) -> PetSkillActionTelemetry:
        return self._telemetry

    @property
    def runtime_completion_observed(self) -> bool:
        """Historical completion for this bound action, never fresh input authority."""
        return bool(self._qte_identity is not None
                    and self._runtime_completion_identity == self._qte_identity)

    @property
    def active(self) -> bool:
        return self._state not in {
            PetSkillActionState.IDLE,
            PetSkillActionState.COMPLETE,
            PetSkillActionState.FAILED,
        }

    def can_execute(
        self,
        observation: PetSkillActionObservation,
        *,
        monotonic_now: float,
    ) -> tuple[bool, str]:
        problem = self._initial_preflight_problem(observation, monotonic_now)
        return problem is None, problem or "CURRENT_ACTIONABLE_PET_SKILL"

    def begin(
        self,
        observation: PetSkillActionObservation,
        *,
        monotonic_now: float,
    ) -> tuple[PetSkillActionEvent, ...]:
        if self._state is not PetSkillActionState.IDLE:
            raise RuntimeError("Pet Skill executor accepts only one invocation")
        start = len(self._events)
        self._transition(PetSkillActionState.PREFLIGHT, monotonic_now)
        problem = self._initial_preflight_problem(observation, monotonic_now)
        if problem is not None:
            kind = (
                PetSkillActionResultKind.EMERGENCY_STOPPED
                if observation.emergency_stop
                else PetSkillActionResultKind.SHUTDOWN
                if observation.shutdown_requested
                else PetSkillActionResultKind.PREFLIGHT_REJECTED
            )
            self._fail(kind, problem, monotonic_now)
            return tuple(self._events[start:])

        capability = observation.capability
        card = observation.live_card
        geometry = observation.geometry
        session = observation.session_key
        window = observation.window_binding
        assert capability is not None and capability.skill_card_id is not None
        assert card is not None and card.button_address is not None
        assert geometry is not None and session is not None and window is not None
        assert observation.local_actor is not None and observation.turn_number is not None
        self._action_id = PetSkillActionId(
            value=self._action_id_factory(),
            match_id=session.match_id,
            session_key=session,
            lifecycle_epoch=session.lifecycle_epoch,
            local_actor=observation.local_actor,
            source_turn=observation.turn_number,
            skill_card_id=capability.skill_card_id,
        )
        self._window = window
        self._card_ui = card.object_address
        self._button = card.button_address
        self._card_data = card.data_address
        self._geometry = geometry
        self._source_board_key = observation.board_dedup_key
        self._telemetry = PetSkillActionTelemetry(
            resources_before=(observation.mana, observation.power),
            turn_before=observation.turn_number,
        )
        self._event(
            "pet_skill_action_initial_preflight_complete",
            monotonic_now,
            "FRESH_DIRECT_CARD_PREFLIGHT_REQUIRED_BEFORE_CLICK",
        )
        return tuple(self._events[start:])

    def step(
        self,
        observation: PetSkillActionObservation,
        *,
        monotonic_now: float,
    ) -> tuple[PetSkillActionEvent, ...]:
        if not self.active:
            return ()
        start = len(self._events)
        stop_kind, stop_reason = self._stop_problem(observation)
        control_sample_time = observation.control_sampled_monotonic
        sample_time = (min(observation.sampled_monotonic, control_sample_time)
                       if control_sample_time is not None else observation.sampled_monotonic)
        if stop_kind is None and self._state in {
            PetSkillActionState.WAIT_QTE_GENERATION, PetSkillActionState.DIRECTIONS,
            PetSkillActionState.WAIT_PERFECT_TARGET, PetSkillActionState.CONFIRM_PREFLIGHT,
        } and not 0 <= monotonic_now - sample_time <= self._sample_age:
            stop_kind, stop_reason = PetSkillActionResultKind.INVALIDATED, "QTE_CONTROL_SAMPLE_STALE"
        if stop_kind is not None:
            self._record_direction_events(self._directions.abort(stop_reason), monotonic_now)
            self._fail(stop_kind, stop_reason, monotonic_now)
            return tuple(self._events[start:])

        if self._state is PetSkillActionState.PREFLIGHT:
            self._step_card_click(observation, monotonic_now)
        elif self._state is PetSkillActionState.WAIT_QTE_GENERATION:
            self._step_wait_qte(observation, monotonic_now)
        elif self._state is PetSkillActionState.DIRECTIONS:
            self._step_directions(observation, monotonic_now)
        elif self._state in {
            PetSkillActionState.DIRECTIONS_COMPLETE,
            PetSkillActionState.WAIT_PERFECT_TARGET,
            PetSkillActionState.CONFIRM_PREFLIGHT,
        }:
            self._step_perfect(observation, monotonic_now)
        elif self._state in {
            PetSkillActionState.SPACE_SENT,
            PetSkillActionState.WAIT_RESULT,
        }:
            self._step_result(observation, monotonic_now)
        elif self._state in {
            PetSkillActionState.RESULT_CORRELATED,
            PetSkillActionState.POST_SKILL_REREAD,
        }:
            self._step_post_state(observation, monotonic_now)
        return tuple(self._events[start:])

    def abort(
        self,
        *,
        monotonic_now: float,
        emergency: bool = False,
        reason: str = "OPERATOR_ABORT",
    ) -> tuple[PetSkillActionEvent, ...]:
        if not self.active:
            return ()
        start = len(self._events)
        self._record_direction_events(
            self._directions.abort("EMERGENCY_STOP" if emergency else reason), monotonic_now,
        )
        self._fail(
            PetSkillActionResultKind.EMERGENCY_STOPPED
            if emergency
            else PetSkillActionResultKind.INVALIDATED,
            "EMERGENCY_STOP" if emergency else reason,
            monotonic_now,
        )
        return tuple(self._events[start:])

    def reject_server_result(
        self,
        *,
        monotonic_now: float,
        reason: str,
    ) -> tuple[PetSkillActionEvent, ...]:
        """Fail a post-Space action on an exactly correlated explicit reject.

        Missing callbacks are deliberately ignored.  This boundary is only for
        a response that the observer has already tied to the current immutable
        action identity and classified as an explicit server rejection.
        """

        if not self.active:
            return ()
        start = len(self._events)
        if self._space_presses != 1 or self._state not in {
            PetSkillActionState.SPACE_SENT,
            PetSkillActionState.WAIT_RESULT,
            PetSkillActionState.RESULT_CORRELATED,
            PetSkillActionState.POST_SKILL_REREAD,
        }:
            return ()
        clean_reason = reason.strip() or "server rejected skill"
        self._telemetry = self._replace_telemetry(
            server_reject_observed=True,
            server_reject_reason=clean_reason,
        )
        self._fail(
            PetSkillActionResultKind.INVALIDATED,
            f"CURRENT_ACTION_SERVER_REJECTED:{clean_reason}",
            monotonic_now,
        )
        return tuple(self._events[start:])

    def recommended_wait_seconds(
        self,
        observation: PetSkillActionObservation | None = None,
        *,
        monotonic_now: float | None = None,
    ) -> float:
        """Worker poll delay; short near midpoint, never a fixed QTE sleep."""

        if self._state is PetSkillActionState.WAIT_PERFECT_TARGET and observation:
            snapshot = observation.qte
            if snapshot and snapshot.current_elapsed is not None:
                target = self._telemetry.target_confirm_elapsed
                if target is not None:
                    sample_age = max(
                        0.0,
                        (monotonic_now if monotonic_now is not None else observation.sampled_monotonic)
                        - observation.sampled_monotonic,
                    )
                    remaining = target - (snapshot.current_elapsed + sample_age)
                    return max(0.005, min(0.04, remaining / 2.0))
        return 0.025

    def _step_card_click(
        self,
        observation: PetSkillActionObservation,
        now: float,
    ) -> None:
        problem = self._card_click_preflight_problem(observation, now)
        if problem is not None:
            self._fail(PetSkillActionResultKind.PREFLIGHT_REJECTED, problem, now)
            return
        session = observation.session_key
        window = observation.window_binding
        geometry = observation.geometry
        assert session is not None and window is not None and geometry is not None
        self._directions.arm(
            session_key=session,
            window_binding=window,
            inactive_baseline_proven=observation.inactive_qte_proven,
        )
        self._transition(PetSkillActionState.CARD_CLICK, now)
        # The 1.7.4 legacy Unity input path may sample the mouse position on a
        # rendered frame after SetCursorPos.  Use the same bounded cursor-settle
        # proof already required by reliable board swaps, while retaining the
        # one-click/no-retry authority of this action.
        click = self._mouse.send_normalized_point(
            window,
            geometry.normalized_point,
            settle_cursor=True,
        )
        if not click.sent:
            self._directions.abort("CARD_CLICK_INPUT_FAILED")
            self._fail(
                PetSkillActionResultKind.CARD_CLICK_UNCONFIRMED,
                f"PET_SKILL_CLICK_{click.status.value}",
                now,
            )
            return
        self._card_clicks = 1
        self._telemetry = self._replace_telemetry(card_click_timestamp=self._timestamp())
        self._deadline = now + self._qte_timeout
        self._transition(PetSkillActionState.WAIT_QTE_GENERATION, now)

    def _step_wait_qte(
        self,
        observation: PetSkillActionObservation,
        now: float,
    ) -> None:
        if self._deadline is not None and now >= self._deadline:
            self._directions.abort("QTE_NOT_OBSERVED_AFTER_CARD_CLICK")
            self._fail(
                PetSkillActionResultKind.CARD_CLICK_SENT_QTE_UNCONFIRMED,
                "CARD_CLICK_SENT_QTE_UNCONFIRMED_NO_RETRY",
                now,
            )
            return
        qte = observation.qte
        if qte is None or qte.evidence_status is QteEvidenceStatus.INACTIVE:
            return
        if self._qte_initialization_pending(observation):
            # CardUI can become active before ServerQteArrows is published.
            # Wait read-only inside the ORIGINAL click deadline; do not arm,
            # guess a direction, resend the card, or reset the timeout.
            if not self._logged_qte_initialization_wait:
                self._event("pet_skill_qte_initialization_wait", now,
                            "CURRENT_CARD_WAITING_FOR_SERVER_SEQUENCE")
                self._logged_qte_initialization_wait = True
            return
        problem = self._fresh_qte_problem(qte)
        if problem is not None:
            self._directions.invalidate(problem)
            self._fail(PetSkillActionResultKind.QTE_STALE_OR_AMBIGUOUS, problem, now)
            return
        assert qte.identity is not None and qte.qte_generation is not None
        self._qte_identity = qte.identity
        detected = self._timestamp()
        click_time = self._telemetry.card_click_timestamp
        self._telemetry = self._replace_telemetry(
            qte_first_observed_timestamp=detected,
            qte_detection_latency=(
                max(0.0, detected - click_time) if click_time is not None else None
            ),
            qte_generation=qte.qte_generation,
            sequence_length=qte.sequence_length,
            perfect_start=qte.perfect_start,
            perfect_end=qte.perfect_end,
            target_confirm_elapsed=(
                (qte.perfect_start + qte.perfect_end) / 2.0
                if qte.perfect_start is not None and qte.perfect_end is not None
                else None
            ),
        )
        events = self._directions.observe(
            qte,
            window_binding=self._required_window(),
            monotonic_now=now,
            lifecycle_valid=True,
            authority_owned=True,
        )
        self._record_direction_events(events, now)
        if not events or self._directions.state.value == "DISARMED":
            self._fail(
                PetSkillActionResultKind.QTE_STALE_OR_AMBIGUOUS,
                "FRESH_QTE_BIND_FAILED",
                now,
            )
            return
        self._transition(PetSkillActionState.DIRECTIONS, now)

    def _step_directions(
        self,
        observation: PetSkillActionObservation,
        now: float,
    ) -> None:
        qte = observation.qte
        if qte is None:
            events = self._directions.observe_unavailable(
                monotonic_now=now,
                reason="ACTIVE_QTE_UNREADABLE_OR_AMBIGUOUS",
            )
        else:
            problem = self._bound_qte_problem(qte, require_complete=False)
            if problem is not None:
                self._record_direction_events(self._directions.invalidate(problem), now)
                self._fail(PetSkillActionResultKind.QTE_STALE_OR_AMBIGUOUS, problem, now)
                return
            if (qte.current_elapsed is not None and qte.perfect_end is not None
                    and qte.current_elapsed + max(0.0, now - observation.sampled_monotonic) > qte.perfect_end):
                self._record_direction_events(self._directions.invalidate("PERFECT_WINDOW_MISSED"), now)
                self._fail(PetSkillActionResultKind.PERFECT_WINDOW_MISSED, "PERFECT_WINDOW_MISSED_DURING_DIRECTIONS", now)
                return
            events = self._directions.observe(
                qte,
                window_binding=self._required_window(),
                monotonic_now=now,
                lifecycle_valid=True,
                authority_owned=True,
            )
        self._record_direction_events(events, now)
        summary = next((item.summary for item in events if item.summary is not None), None)
        if summary is None:
            return
        self._telemetry = self._replace_telemetry(
            direction_summary=summary,
            directions_complete_elapsed=summary.completion_elapsed,
        )
        clean = bool(
            summary.automation_stop_reason == "DIRECTIONS_COMPLETE"
            and summary.directions_confirmed == summary.sequence_length
            and summary.directions_sent == summary.sequence_length
            and all(
                item.status is QteDirectionRecordStatus.AUTHORITATIVELY_CONFIRMED
                for item in summary.records
            )
            and not any(
                (
                    summary.wrong_directions,
                    summary.skipped_directions,
                    summary.duplicate_directions,
                    summary.stale_directions,
                    summary.unconfirmed_directions,
                    summary.blind_retries,
                )
            )
        )
        if not clean:
            kind = (
                PetSkillActionResultKind.DIRECTION_UNCONFIRMED
                if summary.unconfirmed_directions
                else PetSkillActionResultKind.DIRECTION_FAILED
            )
            self._fail(kind, summary.automation_stop_reason, now)
            return
        self._transition(PetSkillActionState.DIRECTIONS_COMPLETE, now)
        self._transition(PetSkillActionState.WAIT_PERFECT_TARGET, now)

    def _step_perfect(
        self,
        observation: PetSkillActionObservation,
        now: float,
    ) -> None:
        qte = observation.qte
        if qte is None:
            self._fail(
                PetSkillActionResultKind.QTE_STALE_OR_AMBIGUOUS,
                "QTE_MISSING_DURING_PERFECT_WAIT",
                now,
            )
            return
        problem = self._bound_qte_problem(qte, require_complete=True)
        if problem is not None:
            self._fail(PetSkillActionResultKind.QTE_STALE_OR_AMBIGUOUS, problem, now)
            return
        start = qte.perfect_start
        end = qte.perfect_end
        elapsed = qte.current_elapsed
        if (
            start is None
            or end is None
            or elapsed is None
            or not all(math.isfinite(item) for item in (start, end, elapsed))
            or not 0 <= start < end
        ):
            self._fail(
                PetSkillActionResultKind.PERFECT_WINDOW_INVALID,
                "CURRENT_PERFECT_WINDOW_INVALID",
                now,
            )
            return
        if start != self._telemetry.perfect_start or end != self._telemetry.perfect_end:
            self._fail(
                PetSkillActionResultKind.PERFECT_WINDOW_INVALID,
                "CURRENT_PERFECT_WINDOW_CHANGED",
                now,
            )
            return
        target = (start + end) / 2.0
        sample_age = max(0.0, now - observation.sampled_monotonic)
        estimated = elapsed + sample_age
        if elapsed > end or estimated > end:
            self._fail(
                PetSkillActionResultKind.PERFECT_WINDOW_MISSED,
                "PERFECT_WINDOW_MISSED",
                now,
            )
            return
        if estimated < target:
            return
        if elapsed < start:
            # Wall time cannot advance Unity's clock during a frozen frame.
            # Require RAM to actually enter Perfect, not projection alone.
            return
        self._transition(PetSkillActionState.CONFIRM_PREFLIGHT, now)
        final_problem = self._final_confirm_problem(observation, qte, now)
        if final_problem is not None:
            self._fail(PetSkillActionResultKind.INVALIDATED, final_problem, now)
            return
        if self._space_presses != 0:
            self._fail(
                PetSkillActionResultKind.INVALIDATED,
                "SPACE_AUTHORITY_ALREADY_CONSUMED",
                now,
            )
            return
        result = self._space.send_space(self._required_window())
        if not result.sent:
            self._fail(
                PetSkillActionResultKind.SPACE_INPUT_FAILED,
                f"SPACE_{result.status.value}",
                now,
            )
            return
        self._space_presses = 1
        sent_at = self._timestamp()
        self._telemetry = self._replace_telemetry(
            final_preflight_elapsed=estimated,
            space_send_timestamp=sent_at,
            space_send_elapsed=estimated,
            confirm_target_error=estimated - target,
            start_margin=estimated - start,
            end_margin=end - estimated,
        )
        self._transition(PetSkillActionState.SPACE_SENT, now)
        self._deadline = now + self._result_timeout
        self._transition(PetSkillActionState.WAIT_RESULT, now)

    def _step_result(
        self,
        observation: PetSkillActionObservation,
        now: float,
    ) -> None:
        qte = observation.qte
        if qte is not None and self._terminal_cleanup_pending(observation):
            # The observer deliberately removes generation authority from an
            # INACTIVE snapshot. Keep the earlier bound completion only for
            # result correlation, not as a replacement current QTE/input state.
            if not self._logged_qte_cleanup_wait:
                self._event("pet_skill_qte_cleanup_wait", now,
                            "QTE_CLOSED_AFTER_RUNTIME_PERFECT_WAITING_FOR_GAME_SETTLE")
                self._logged_qte_cleanup_wait = True
            qte = None  # Follow the existing no-QTE bounded result wait below.
        if qte is not None:
            problem = self._bound_qte_problem(qte, require_complete=True, allow_terminal=True)
            if problem is not None:
                self._fail(PetSkillActionResultKind.INVALIDATED, problem, now)
                return
            if qte.completed:
                self._runtime_completion_identity = qte.identity
                self._telemetry = self._replace_telemetry(
                    predicted_result=qte.predicted_timing_result,
                    runtime_result=qte.runtime_display_result,
                    runtime_result_text=qte.runtime_result_text,
                    server_response_correlated=qte.server_response_correlated,
                    server_result=qte.server_resolved_result,
                    server_result_text=qte.server_result_text,
                    qte_elapsed_ms=qte.qte_elapsed_ms,
                )
                if qte.runtime_display_result is None:
                    # ``finished`` and the display result can become visible in
                    # adjacent reads.  Keep the original bounded post-Space
                    # deadline; Space is never retried.
                    if self._deadline is None or now < self._deadline:
                        return
                elif not self._runtime_perfect_agrees(qte):
                    self._fail(
                        PetSkillActionResultKind.TIMING_RESULT_MISMATCH,
                        "CURRENT_GENERATION_RUNTIME_RESULT_IS_NOT_PERFECT",
                        now,
                    )
                    return
                else:
                    # This is the exact boundary requested for the external
                    # primitive: the current server challenge was bound, every
                    # direction was RAM-ACKed, one Space was sent in the current
                    # window and this same CardUI generation resolved PERFECT.
                    # Do not turn that accepted action into a false failure when
                    # the transient response/board transport object is reclaimed.
                    # Future board play still has to pass its independent normal
                    # GameState/actionability gate; this executor emits no more
                    # input after completing here.
                    self._event(
                        "pet_skill_runtime_perfect_accepted",
                        now,
                        "CURRENT_GENERATION_CARDUI_RUNTIME_PERFECT",
                    )
                    self._state = PetSkillActionState.COMPLETE
                    self._result = PetSkillActionResult(
                        kind=PetSkillActionResultKind.SUCCESS_PERFECT,
                        state=self._state,
                        action_id=self._action_id,
                        reason="CURRENT_GENERATION_RUNTIME_PERFECT",
                        card_clicks=self._card_clicks,
                        space_presses=self._space_presses,
                        telemetry=self._telemetry,
                    )
                    self._event("pet_skill_action_complete", now)
                    return
        if self._deadline is not None and now >= self._deadline:
            self._fail(
                PetSkillActionResultKind.SPACE_SENT_RESULT_UNCONFIRMED,
                "SPACE_SENT_RUNTIME_COMPLETION_UNCONFIRMED_NO_RETRY",
                now,
            )

    def _terminal_cleanup_pending(self, observation: PetSkillActionObservation) -> bool:
        qte, action, capability = observation.qte, self._action_id, observation.capability
        return bool(
            self._space_presses == 1 and self.runtime_completion_observed
            and qte is not None and action is not None and capability is not None
            and qte.evidence_status is QteEvidenceStatus.INACTIVE
            and qte.ownership_status is QteBindingStatus.INACTIVE
            and not qte.active and not qte.completed
            and qte.identity is None and qte.qte_generation is None
            and qte.match_id == action.match_id and qte.session_key == action.session_key
            and observation.local_actor == action.local_actor
            and capability.current and capability.session_key == action.session_key
            and capability.skill_card_id == action.skill_card_id
            and capability.live_card_address == self._card_ui
            and capability.live_button_address == self._button
            and capability.card_data_address == self._card_data
        )

    def _step_post_state(
        self,
        observation: PetSkillActionObservation,
        now: float,
    ) -> None:
        qte = observation.qte
        if qte is not None:
            inactive_current = bool(
                qte.evidence_status is QteEvidenceStatus.INACTIVE
                and qte.ownership_status is QteBindingStatus.INACTIVE
                and qte.identity is None
                and self._action_id is not None
                and qte.match_id == self._action_id.match_id
                and qte.session_key == self._action_id.session_key
            )
            if not inactive_current:
                problem = self._bound_qte_problem(
                    qte,
                    require_complete=True,
                    allow_terminal=True,
                )
                if problem is not None:
                    self._fail(PetSkillActionResultKind.INVALIDATED, problem, now)
                    return
        if (
            qte is not None
            and self._qte_identity is not None
            and qte.identity == self._qte_identity
            and qte.server_response_correlated
        ):
            # Best-effort telemetry only.  Even a server timing echo does not
            # replace or veto the already observed CardUI runtime PERFECT;
            # explicit rejects arrive through ``reject_server_result``.
            self._telemetry = self._replace_telemetry(
                server_response_correlated=True,
                server_result=qte.server_resolved_result,
                server_result_text=qte.server_result_text,
            )
        if observation.post_state_fresh and observation.post_state is not None:
            state = observation.post_state
            if (
                state.battle.match_id is not None
                and self._action_id is not None
                and state.battle.match_id != self._action_id.match_id
            ):
                self._fail(
                    PetSkillActionResultKind.INVALIDATED,
                    "POST_STATE_WRONG_MATCH",
                    now,
                )
                return
            battle = state.battle
            terminal = bool(
                state.phase is not GamePhase.COMBAT
                and (
                    battle.combat_lifecycle is CombatLifecycleState.POSTMATCH
                    or battle.match_over is True
                    or battle.board_is_game_over is True
                    or battle.local_has_left_match is True
                )
            )
            settled_combat = bool(
                state.phase is GamePhase.COMBAT
                and battle.stable
                and battle.is_board_ready is True
                and battle.is_cascade_running is False
                and battle.board_is_processing_ui is not True
                and battle.presentation_busy is not True
                and battle.board_is_game_over is not True
                and battle.match_over is not True
            )
            resources_after = (
                state.player.mana if state.player is not None else None,
                state.player.power if state.player is not None else None,
            )
            post_key = state.dedup_key
            board_progressed = bool(
                self._source_board_key is not None
                and post_key is not None
                and post_key != self._source_board_key
            )
            turn_progressed = bool(
                self._telemetry.turn_before is not None
                and battle.turn_number is not None
                and battle.turn_number != self._telemetry.turn_before
            )
            resources_progressed = any(
                before is not None and after is not None and before != after
                for before, after in zip(
                    self._telemetry.resources_before,
                    resources_after,
                )
            )
            authoritative_progress = bool(
                board_progressed or turn_progressed or resources_progressed
            )
            if not (terminal or (settled_combat and authoritative_progress)):
                return
            self._telemetry = self._replace_telemetry(
                resources_after=resources_after,
                turn_after=state.battle.turn_number,
            )
            self._state = PetSkillActionState.COMPLETE
            self._result = PetSkillActionResult(
                kind=PetSkillActionResultKind.SUCCESS_PERFECT,
                state=self._state,
                action_id=self._action_id,
                reason=(
                    "CURRENT_GENERATION_RUNTIME_PERFECT_AND_TERMINAL_STATE"
                    if terminal
                    else "CURRENT_GENERATION_RUNTIME_PERFECT_AND_SETTLED_GAME_STATE"
                ),
                card_clicks=self._card_clicks,
                space_presses=self._space_presses,
                telemetry=self._telemetry,
                post_state=state,
            )
            self._event("pet_skill_action_complete", now)
            return
        if self._deadline is not None and now >= self._deadline:
            self._fail(
                PetSkillActionResultKind.POST_SKILL_REREAD_UNCONFIRMED,
                "RUNTIME_PERFECT_BUT_FRESH_SETTLED_GAME_STATE_UNAVAILABLE",
                now,
            )

    def _initial_preflight_problem(
        self,
        observation: PetSkillActionObservation,
        now: float,
    ) -> str | None:
        stop_kind, stop = self._stop_problem(observation)
        if stop_kind is not None:
            return stop
        if now < observation.sampled_monotonic or now - observation.sampled_monotonic > self._sample_age:
            return "PREFLIGHT_SAMPLE_STALE"
        session = observation.session_key
        if session is None or not observation.match_id or observation.match_id != session.match_id:
            return "CURRENT_MATCH_OR_SESSION_UNKNOWN"
        if observation.lifecycle is not CombatLifecycleState.ACTIVE:
            return "ACTIVE_COMBAT_NOT_PROVEN"
        if observation.local_actor is None or observation.local_actor <= 0:
            return "LOCAL_ACTOR_UNKNOWN"
        if observation.turn_number is None or observation.is_local_turn is not True:
            return "LOCAL_TURN_NOT_ACTIONABLE"
        capability = observation.capability
        if capability is None or not capability.current:
            return "CURRENT_PET_SKILL_CAPABILITY_MISSING"
        if capability.session_key != session or capability.skill_card_id is None:
            return "PET_SKILL_CAPABILITY_WRONG_SESSION"
        if capability.effective_mana_cost is None or capability.effective_power_cost is None:
            return "PET_SKILL_EFFECTIVE_COST_UNKNOWN"
        if observation.mana is None or observation.power is None:
            return "CURRENT_RESOURCES_UNKNOWN"
        if observation.mana < capability.effective_mana_cost:
            return "INSUFFICIENT_MANA"
        if observation.power < capability.effective_power_cost:
            return "INSUFFICIENT_RAGE"
        if capability.live_card_actionable is not True:
            return "PET_SKILL_BUTTON_NOT_ACTIONABLE"
        card = observation.live_card
        if card is None or card.button_address is None:
            return "EXACT_LIVE_PET_SKILL_CARDUI_MISSING"
        if (
            card.object_address != capability.live_card_address
            or card.button_address != capability.live_button_address
            or card.data_address != capability.card_data_address
            or card.card_id != capability.skill_card_id
        ):
            return "PET_SKILL_CARDUI_IDENTITY_CONFLICT"
        if (
            not card.interactable
            or card.action_pending
            or card.is_placeholder
            or card.has_used_this_turn
        ):
            return "PET_SKILL_CARDUI_NOT_CURRENTLY_USABLE"
        geometry = observation.geometry
        window = observation.window_binding
        if geometry is None or window is None:
            return "PET_SKILL_BUTTON_GEOMETRY_UNKNOWN"
        if window.pid <= 0 or window.hwnd <= 0:
            return "GAME_WINDOW_BINDING_INVALID"
        if not observation.game_foreground:
            return "GAME_NOT_FOREGROUND"
        if (
            geometry.session_key != session
            or geometry.window_binding != window
            or geometry.card_ui_address != card.object_address
            or geometry.button_address != card.button_address
            or geometry.card_data_address != card.data_address
            or geometry.skill_card_id != card.card_id
            or geometry.slot_index != card.ui_slot
            or geometry.slot_count != card.ui_slot_count
        ):
            return "PET_SKILL_BUTTON_GEOMETRY_STALE_OR_AMBIGUOUS"
        if not observation.inactive_qte_proven:
            return "CURRENT_SESSION_INACTIVE_QTE_BASELINE_MISSING"
        if observation.qte is not None:
            if (
                observation.qte.session_key != session
                or observation.qte.evidence_status is not QteEvidenceStatus.INACTIVE
            ):
                return "CONFLICTING_OR_AMBIGUOUS_QTE"
        return None

    def _stop_problem(
        self,
        observation: PetSkillActionObservation,
    ) -> tuple[PetSkillActionResultKind | None, str]:
        # A skill can legitimately end the combat immediately after the one
        # Space confirm.  At that point this executor has no remaining input
        # authority: it only records optional result telemetry and performs a
        # fresh read.  Permit an explicitly observed terminal state with no
        # current QTE to cross that read-only boundary.  This does not weaken
        # any pre-Space gate, and an inactive/stale QTE is still rejected.
        terminal_readonly_wait = bool(
            self._space_presses == 1
            and (
                self.runtime_completion_observed
                or self._current_runtime_perfect(observation.qte)
            )
            and self._state
            in {
                PetSkillActionState.WAIT_RESULT,
                PetSkillActionState.RESULT_CORRELATED,
                PetSkillActionState.POST_SKILL_REREAD,
            }
            and observation.postmatch_or_terminal
            and observation.qte is None
        )
        if observation.emergency_stop:
            return PetSkillActionResultKind.EMERGENCY_STOPPED, "EMERGENCY_STOP"
        if observation.shutdown_requested:
            return PetSkillActionResultKind.SHUTDOWN, "SHUTDOWN_REQUESTED"
        if not observation.process_running:
            return PetSkillActionResultKind.INVALIDATED, "GAME_PROCESS_EXITED"
        # Foreground is mandatory only while this action can still emit input.
        # Once the single Space has been sent, WAIT_RESULT and post-state work
        # are read-only.  Moving focus after the visible QTE completes must not
        # discard an otherwise current response or cause any retry.
        if (
            not observation.game_foreground
            and self._state not in {
                PetSkillActionState.SPACE_SENT,
                PetSkillActionState.WAIT_RESULT,
                PetSkillActionState.RESULT_CORRELATED,
                PetSkillActionState.POST_SKILL_REREAD,
            }
        ):
            return PetSkillActionResultKind.INVALIDATED, "GAME_NOT_FOREGROUND"
        if (
            not observation.input_authority_owned
            and self._state not in {
                PetSkillActionState.SPACE_SENT,
                PetSkillActionState.WAIT_RESULT,
                PetSkillActionState.RESULT_CORRELATED,
                PetSkillActionState.POST_SKILL_REREAD,
            }
        ):
            return PetSkillActionResultKind.INVALIDATED, "INPUT_AUTHORITY_NOT_OWNED"
        if observation.conflicting_gameplay_action:
            return PetSkillActionResultKind.INVALIDATED, "CONFLICTING_GAMEPLAY_ACTION"
        if observation.technical_recovery and not terminal_readonly_wait:
            return PetSkillActionResultKind.INVALIDATED, "TECHNICAL_RECOVERY_ACTIVE"
        if observation.sequence_desync and not terminal_readonly_wait:
            return PetSkillActionResultKind.INVALIDATED, "SEQUENCE_DESYNC_ACTIVE"
        if observation.postmatch_or_terminal and not terminal_readonly_wait:
            return PetSkillActionResultKind.INVALIDATED, "POSTMATCH_OR_TERMINAL"
        if self._window is not None and observation.window_binding != self._window:
            return PetSkillActionResultKind.INVALIDATED, "WINDOW_BINDING_CHANGED"
        if self._action_id is not None:
            if not terminal_readonly_wait and (
                observation.session_key != self._action_id.session_key
                or observation.match_id != self._action_id.match_id
                or observation.lifecycle is not CombatLifecycleState.ACTIVE
            ):
                return PetSkillActionResultKind.INVALIDATED, "COMBAT_SESSION_INVALIDATED"
        return None, ""

    def _card_click_preflight_problem(
        self,
        observation: PetSkillActionObservation,
        now: float,
    ) -> str | None:
        problem = self._initial_preflight_problem(observation, now)
        if problem is not None:
            return f"FINAL_CARD_{problem}"
        action = self._action_id
        card = observation.live_card
        geometry = observation.geometry
        if action is None or card is None or geometry is None:
            return "FINAL_CARD_ACTION_IDENTITY_MISSING"
        if (
            observation.session_key != action.session_key
            or observation.match_id != action.match_id
            or observation.local_actor != action.local_actor
            or observation.turn_number != action.source_turn
            or card.object_address != self._card_ui
            or card.button_address != self._button
            or card.data_address != self._card_data
            or card.card_id != action.skill_card_id
            or geometry != self._geometry
            or observation.window_binding != self._window
        ):
            return "FINAL_CARD_PREFLIGHT_IDENTITY_CHANGED"
        return None

    def _qte_initialization_pending(self, observation: PetSkillActionObservation) -> bool:
        """Only the proven pre-bind sequence-publication gap is transient.

        QteSessionTracker emits SEQUENCE_UNAVAILABLE only after checking its
        current-session inactive edge, Board/actor/CardData and challenge
        MatchId. All other unknown/stale/ambiguous states still fail closed.
        The exact clicked card's current capability must independently agree.
        """
        qte, action, capability = observation.qte, self._action_id, observation.capability
        return bool(
            action is not None and qte is not None and capability is not None
            and self._qte_identity is None
            and qte.ownership_status is QteBindingStatus.SEQUENCE_UNAVAILABLE
            and qte.evidence_status is QteEvidenceStatus.UNKNOWN
            and qte.identity is None and qte.qte_generation is None
            and not qte.completed
            and qte.session_key == action.session_key and qte.match_id == action.match_id
            and observation.local_actor == action.local_actor
            and observation.turn_number == action.source_turn
            and observation.is_local_turn is True
            and capability.current and capability.session_key == action.session_key
            and capability.skill_card_id == action.skill_card_id
            and capability.live_card_address == self._card_ui
            and capability.live_button_address == self._button
            and capability.card_data_address == self._card_data
        )

    def _fresh_qte_problem(self, qte: QteSnapshot) -> str | None:
        action = self._action_id
        if action is None:
            return "ACTION_ID_MISSING"
        if not qte.observationally_current or qte.identity is None:
            return "QTE_NOT_CURRENT_OR_AMBIGUOUS"
        if qte.session_key != action.session_key or qte.match_id != action.match_id:
            return "QTE_WRONG_SESSION"
        if qte.skill_card_id != action.skill_card_id or qte.local_actor != action.local_actor:
            return "QTE_WRONG_CARD_OR_ACTOR"
        if qte.turn_number != action.source_turn:
            return "QTE_WRONG_SOURCE_TURN"
        if not qte.active or qte.completed:
            return "QTE_NOT_FRESH_ACTIVE"
        if qte.current_index != 0 or qte.correct_count != 0 or qte.presses:
            return "QTE_MIDSTREAM_NOT_FRESH"
        return None

    def _bound_qte_problem(
        self,
        qte: QteSnapshot,
        *,
        require_complete: bool,
        allow_terminal: bool = False,
    ) -> str | None:
        action = self._action_id
        if action is None or self._qte_identity is None:
            return "QTE_ACTION_BINDING_MISSING"
        if (
            not qte.observationally_current
            or qte.identity != self._qte_identity
            or qte.ownership_status not in {
                QteBindingStatus.BOUND_CURRENT,
                QteBindingStatus.COMPLETED_CURRENT,
            }
        ):
            return "QTE_GENERATION_CHANGED_OR_STALE"
        if qte.session_key != action.session_key or qte.match_id != action.match_id:
            return "QTE_SESSION_OR_MATCH_CHANGED"
        if qte.skill_card_id != action.skill_card_id or qte.local_actor != action.local_actor:
            return "QTE_SKILL_OR_ACTOR_CHANGED"
        if qte.turn_number != action.source_turn:
            return "QTE_TURN_CHANGED"
        if require_complete:
            if (
                qte.current_index != qte.sequence_length
                or qte.correct_count != qte.sequence_length
                or len(qte.presses) != qte.sequence_length
            ):
                return "QTE_DIRECTIONS_NOT_AUTHORITATIVELY_COMPLETE"
        if not allow_terminal and (not qte.active or qte.completed):
            return "QTE_CLOSED_BEFORE_CONFIRM"
        return None

    def _final_confirm_problem(
        self,
        observation: PetSkillActionObservation,
        qte: QteSnapshot,
        now: float,
    ) -> str | None:
        if now - observation.sampled_monotonic > self._sample_age:
            return "CONFIRM_PREFLIGHT_SAMPLE_STALE"
        stop_kind, reason = self._stop_problem(observation)
        if stop_kind is not None:
            return reason
        action = self._action_id
        capability = observation.capability
        if action is None:
            return "CONFIRM_ACTION_ID_MISSING"
        if (
            capability is None
            or not capability.current
            or capability.session_key != action.session_key
            or capability.skill_card_id != action.skill_card_id
        ):
            return "CONFIRM_CURRENT_SKILL_CAPABILITY_CHANGED"
        if (
            observation.local_actor != action.local_actor
            or observation.turn_number != action.source_turn
            or observation.is_local_turn is not True
        ):
            return "CONFIRM_SOURCE_TURN_OR_OWNER_CHANGED"
        problem = self._bound_qte_problem(qte, require_complete=True)
        if problem is not None:
            return problem
        elapsed = qte.current_elapsed
        start = qte.perfect_start
        end = qte.perfect_end
        if elapsed is None or start is None or end is None:
            return "CONFIRM_TIMING_UNKNOWN"
        estimated = elapsed + max(0.0, now - observation.sampled_monotonic)
        if not start <= elapsed <= end or not start <= estimated <= end:
            return "CONFIRM_NOT_INSIDE_CURRENT_PERFECT_WINDOW"
        return None

    @staticmethod
    def _runtime_perfect_agrees(qte: QteSnapshot) -> bool:
        return qte.runtime_display_result is QteTimingResult.PERFECT

    def _current_runtime_perfect(self, qte: QteSnapshot | None) -> bool:
        return bool(
            qte is not None
            and self._qte_identity is not None
            and qte.identity == self._qte_identity
            and qte.completed
            and qte.runtime_display_result is QteTimingResult.PERFECT
        )

    def _replace_telemetry(self, **changes: object) -> PetSkillActionTelemetry:
        return replace(self._telemetry, **changes)

    def _required_window(self) -> WindowBinding:
        if self._window is None:
            raise AssertionError("Pet Skill action has no window binding")
        return self._window

    def _record_direction_events(self, events: tuple[QteAssistEvent, ...], now: float) -> None:
        for item in events:
            self._events.append(PetSkillActionEvent(
                "pet_skill_direction_event", self._state, now, item.reason, item,
            ))
            if item.summary is not None:
                self._telemetry = self._replace_telemetry(direction_summary=item.summary)

    def _transition(self, state: PetSkillActionState, now: float) -> None:
        self._state = state
        self._event("pet_skill_action_state", now)

    def _event(self, event: str, now: float, reason: str | None = None) -> None:
        self._events.append(PetSkillActionEvent(event, self._state, now, reason))

    def _fail(
        self,
        kind: PetSkillActionResultKind,
        reason: str,
        now: float,
    ) -> None:
        self._state = PetSkillActionState.FAILED
        self._result = PetSkillActionResult(
            kind=kind,
            state=self._state,
            action_id=self._action_id,
            reason=reason,
            card_clicks=self._card_clicks,
            space_presses=self._space_presses,
            telemetry=self._telemetry,
        )
        self._event("pet_skill_action_failed", now, reason)


__all__ = [
    "PetSkillActionEvent",
    "PetSkillActionExecutor",
    "PetSkillActionId",
    "PetSkillActionObservation",
    "PetSkillActionResult",
    "PetSkillActionResultKind",
    "PetSkillActionState",
    "PetSkillActionTelemetry",
    "PetSkillCardGeometryProof",
    "QteSpaceInputExecutor",
    "QteSpaceInputResult",
    "QteSpaceInputStatus",
]
