#!/usr/bin/env python3
"""Execute explicitly bounded Pet Skill card/QTE/Perfect actions.

This is a controlled Phase 3B.3 acceptance harness, not gameplay policy.  The
operator explicitly starts it with ``--execute-once`` and manually prepares
combat/resources.  The harness then owns one card click, its fresh QTE
generation, the accepted closed-loop direction inputs, and one Space confirm.
The separate ``--b4-two-same-match`` mode authorizes at most two such actions
in one retained match/session, with independent current evidence for each.
"""

from __future__ import annotations

import argparse
from dataclasses import replace
from pathlib import Path
import signal
import sys
import threading
import time
from typing import Any, Callable


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.app_paths import current_app_paths  # noqa: E402
from pokiguard_v2.combat_lifecycle import CombatLifecycleState  # noqa: E402
from pokiguard_v2.controller_lease import AutomationControllerLease  # noqa: E402
from pokiguard_v2.gameplay_ui import locate_native_pet_skill_control  # noqa: E402
from pokiguard_v2.native_card_ui import NativeCardUiReader, NativeGeometryBusyError  # noqa: E402
from pokiguard_v2.combat_cards import read_combat_card  # noqa: E402
from pokiguard_v2.il2cpp_external import (  # noqa: E402
    BOARD_ACTIVE_OFFSET, CARD_UI_TYPE_INFO_RVA, ExternalReadError,
)
from pokiguard_v2.il2cpp_layout import LayoutValidationError  # noqa: E402
from pokiguard_v2.pet_skill_action import (  # noqa: E402
    PetSkillActionExecutor,
    PetSkillActionObservation,
    PetSkillActionResultKind,
    PetSkillActionState,
    PetSkillCardGeometryProof,
    QteSpaceInputExecutor,
)
from pokiguard_v2.qte_direction_assist import (  # noqa: E402
    QteDirectionAssist,
    QteDirectionInputExecutor,
)
from pokiguard_v2.state import CardState, GamePhase  # noqa: E402
from pokiguard_v2.win32_input import (  # noqa: E402
    DEFAULT_SWAP_CURSOR_SETTLE_SECONDS,
    ForegroundClickExecutor,
    NativeWin32Backend,
    find_window_for_pid,
)
from pokiguard_v2.win32_screenshot import capture_client_rgb  # noqa: E402
from tools.pet_qte_observer import run as run_observer  # noqa: E402
from tools.runtime_common import default_log_path  # noqa: E402


class Phase3b3RuntimeHook:
    """Bridge production read-only evidence to one PetSkillActionExecutor."""

    name = "PHASE3B3_ONE_FULL_PET_SKILL_ACTION"

    def __init__(
        self,
        *,
        direction_ack_timeout_seconds: float,
        qte_generation_timeout_seconds: float,
        result_timeout_seconds: float,
        post_state_timeout_seconds: float,
    ) -> None:
        self._direction_ack_timeout = direction_ack_timeout_seconds
        self._qte_generation_timeout = qte_generation_timeout_seconds
        self._result_timeout = result_timeout_seconds
        self._post_state_timeout = post_state_timeout_seconds
        self._emit: Callable[..., None] | None = None
        self._target: Any = None
        self._backend: NativeWin32Backend | None = None
        self._binding: Any = None
        self._executor: PetSkillActionExecutor | None = None
        self._executor_factory: Callable[[], PetSkillActionExecutor] | None = None
        self._latest_context: dict[str, Any] | None = None
        self._inactive_sessions: set[Any] = set()
        self._invocation_consumed = False
        self._last_wait_reason: tuple | None = None
        self._last_event_count = 0
        self._result_emitted = False
        self._native_cards: NativeCardUiReader | None = None
        self._geometry_reason = "not_requested"
        self._geometry_read_attempts = 0
        self._geometry_retry_reason: str | None = None
        self._geometry_elapsed_ms = 0.0
        self._preflight_timing: dict[str, float] = {}
        self._last_observation: PetSkillActionObservation | None = None
        self._post_state_not_before: float | None = None
        self._last_control_refresh_signature: tuple[Any, ...] | None = None
        self._last_control_refresh_emit = 0.0
        self._last_control_read_rejection: str | None = None
        self._last_post_space_read_rejection: str | None = None
        self._stage_lock = threading.Lock()
        self._stage_name: str | None = None
        self._stage_started = 0.0
        self._stage_generation = 0
        self._stage_stall_generation = -1
        self._fatal_stop_reason: str | None = None
        self._watchdog_stop = threading.Event()
        self._watchdog_thread: threading.Thread | None = None
        # The game consumes MATCH_SKILL_USE_RES internally.  The external
        # one-shot contract ends at current-generation CardUI runtime PERFECT,
        # so do not run the high-frequency dispatcher-response tap at all.
        self._result_tap: Any | None = None
        self._post_transport_offers: set[tuple[str, int, int, str]] = set()

    @property
    def critical_qte_session(self) -> Any:
        """Keep control-only RPM until CardUI reports current runtime completion."""
        if self._fatal_stop_reason is not None:
            return None
        executor = self._executor
        if executor is not None and executor.action_id is not None and executor.state in {
            PetSkillActionState.WAIT_QTE_GENERATION, PetSkillActionState.DIRECTIONS,
            PetSkillActionState.DIRECTIONS_COMPLETE, PetSkillActionState.WAIT_PERFECT_TARGET,
            PetSkillActionState.CONFIRM_PREFLIGHT, PetSkillActionState.WAIT_RESULT,
        }:
            return executor.action_id.session_key
        return None

    @property
    def server_result_optional(self) -> bool:
        """Keep server-response heap scans outside the one-shot action."""

        return True

    @property
    def pre_action_watch_session(self) -> Any:
        """Current combat session while waiting for or preflighting the card.

        ``PREFLIGHT`` has not emitted input yet.  Keep using the exact native-hand
        refresh plus control-only ownership read for its mandatory second sample;
        falling back to a full board poll here can transiently lose publication
        during an otherwise valid turn and incorrectly consume the one-shot with
        zero card clicks.
        """

        if self._fatal_stop_reason is not None:
            return None
        executor = self._executor
        context = self._latest_context or {}
        session = (
            executor.action_id.session_key
            if executor is not None
            and executor.state is PetSkillActionState.PREFLIGHT
            and executor.action_id is not None
            else context.get("session")
        )
        if (
            executor is not None
            and (
                (
                    executor.state is PetSkillActionState.IDLE
                    and not self._invocation_consumed
                )
                or executor.state is PetSkillActionState.PREFLIGHT
            )
            and session is not None
        ):
            return session
        return None

    @property
    def result_wait_session(self) -> Any:
        """Disable response/transport capture during the CardUI result wait.

        ``critical_qte_session`` supplies the direct runtime read until Perfect
        is observed. No PendingCombat capture or full-board poll is needed.
        """

        return None

    def poll_delay_seconds(self) -> float:
        if self._executor is None:
            return 0.025
        return self._executor.recommended_wait_seconds(
            self._last_observation, monotonic_now=time.monotonic(),
        )

    @property
    def post_qte_session(self) -> Any:
        """Legacy routing; the current executor completes before these states."""
        executor = self._executor
        if executor is not None and executor.action_id is not None and executor.state in {
            PetSkillActionState.RESULT_CORRELATED,
            PetSkillActionState.POST_SKILL_REREAD,
        }:
            return executor.action_id.session_key
        return None

    @property
    def done(self) -> bool:
        return bool(
            self._fatal_stop_reason is not None
            or self._executor is not None
            and self._executor.result is not None
        )

    @property
    def result(self) -> Any:
        return self._executor.result if self._executor is not None else None

    @property
    def completed_successfully(self) -> bool:
        return bool(self.result is not None and self.result.success)

    @property
    def summary(self) -> Any:
        if self._executor is None:
            return None
        if self._fatal_stop_reason is not None and self._executor.result is None:
            return {
                "state": "FAILED_BEFORE_ACTION",
                "reason": self._fatal_stop_reason,
                "cardClicks": 0,
                "spacePresses": 0,
            }
        return self._executor.result or {
            "state": self._executor.state,
            "telemetry": self._executor.telemetry,
            "invocationConsumed": self._invocation_consumed,
        }

    def attach(self, target: Any, emit: Callable[..., None]) -> None:
        if "64" not in str(target.architecture):
            raise RuntimeError("Phase 3B.3 requires the accepted x64 game target")
        backend = NativeWin32Backend()
        binding = find_window_for_pid(target.pid, backend)
        self._target = target
        self._backend = backend
        self._binding = binding
        self._result_tap = None

        def build_executor() -> PetSkillActionExecutor:
            directions = QteDirectionAssist(
                QteDirectionInputExecutor(backend),
                response_timeout_seconds=self._direction_ack_timeout,
                timestamp=time.monotonic,
            )
            return PetSkillActionExecutor(
                ForegroundClickExecutor(backend),
                directions,
                QteSpaceInputExecutor(backend),
                qte_generation_timeout_seconds=self._qte_generation_timeout,
                result_timeout_seconds=self._result_timeout,
                post_state_timeout_seconds=self._post_state_timeout,
            )

        self._executor_factory = build_executor
        self._executor = build_executor()
        self._emit = emit
        emit(
            "pet_skill_action_harness_attached",
            pid=target.pid,
            hwnd=binding.hwnd,
            architecture=target.architecture,
            actionLimit=1,
            cardClickLimit=1,
            confirmKey="VK_SPACE",
            allowedDirectionKeys=["UP", "DOWN", "LEFT", "RIGHT"],
            inputAuthority="PET_SKILL_ONE_FULL_ACTION",
            basicPolicyIntegration=False,
        )
        self._watchdog_thread = threading.Thread(
            target=self._watch_stages,
            name="phase3b3-stage-watchdog",
            daemon=True,
        )
        self._watchdog_thread.start()

    def started(self, log_path: Path) -> None:
        print(f"Phase 3B.3 one-shot Pet Skill action; log: {log_path}", flush=True)
        print(
            "WAITING: prepare combat and resources; the harness will execute exactly one "
            "current actionable Pet Skill. Do not run FarmRunner/BASIC concurrently.",
            flush=True,
        )

    def runtime_context(self, **context: Any) -> None:
        self._latest_context = context

    def dispatcher_qte_results(self, match_id: str) -> tuple[Any, ...]:
        """Return immutable responses retained from exact dispatcher roots."""

        tap = self._result_tap
        return tap.results(match_id) if tap is not None else ()

    def dispatcher_qte_board_snapshot(
        self, match_id: str, message_address: int
    ) -> Any:
        """Return a strict board decoded from the callback-owned raw JSON."""

        tap = self._result_tap
        return (
            tap.board_snapshot(match_id, message_address)
            if tap is not None
            else None
        )

    def offer_dispatcher_post_qte_boards(self, provider: Any, session: Any) -> None:
        """Offer later callback boards while waiting for fresh post-skill state.

        A skill response can legitimately omit its board. Keeping the already
        pre-armed read-only dispatcher tap alive lets the next current-match
        move/card response provide a strict transport board. The normal provider
        remains responsible for exact ACK/latest and presentation stability.
        """

        tap = self._result_tap
        if tap is None or session is None:
            return
        for event_type, snapshot in tap.transport_board_snapshots(session.match_id):
            if snapshot.match_id != session.match_id:
                continue
            identity = (
                snapshot.match_id,
                snapshot.message_address,
                snapshot.board_token_address,
                event_type,
            )
            if identity in self._post_transport_offers:
                continue
            accepted = provider.offer_transport_board_snapshot(
                snapshot,
                event_type=event_type,
            )
            self._post_transport_offers.add(identity)
            if self._emit is not None:
                self._emit(
                    "post_qte_dispatcher_board_snapshot_offered",
                    session=session,
                    eventType=event_type,
                    responseAddress=f"0x{snapshot.message_address:016X}",
                    boardAddress=f"0x{snapshot.board_token_address:016X}",
                    srvSeq=snapshot.sequence,
                    completeCells=len(snapshot.cells),
                    accepted=accepted,
                    authority=(
                        "ChatService.__c__DisplayClass275_0.json+"
                        f"{event_type}.matchPayload.board+MatchService._ackedSeqs"
                    ),
                )

    @property
    def dispatcher_tap_diagnostics(self) -> Any:
        tap = self._result_tap
        return tap.diagnostics if tap is not None else None

    def _sync_result_tap(self) -> None:
        tap = self._result_tap
        executor = self._executor
        if tap is None or executor is None:
            return
        # Compatibility cleanup for injected test/legacy taps.  Production no
        # longer arms one because the callback is outside the action contract.
        tap.disarm()

    def trace_stage(self, stage: str) -> None:
        """Track bounded observer calls without emitting per-cycle log noise."""

        now = time.monotonic()
        with self._stage_lock:
            if stage.endswith("_begin"):
                self._stage_name = stage[:-6]
                self._stage_started = now
                self._stage_generation += 1
                return
            if stage.endswith("_end") and self._stage_name == stage[:-4]:
                self._stage_name = None
                self._stage_started = 0.0

    def _input_phase_watchdog_active(self) -> bool:
        executor = self._executor
        if executor is None or self._fatal_stop_reason is not None:
            return False
        if executor.state is PetSkillActionState.IDLE:
            return self.pre_action_watch_session is not None
        return executor.state in {
            PetSkillActionState.PREFLIGHT,
            PetSkillActionState.CARD_CLICK,
            PetSkillActionState.WAIT_QTE_GENERATION,
            PetSkillActionState.DIRECTIONS,
            PetSkillActionState.DIRECTIONS_COMPLETE,
            PetSkillActionState.WAIT_PERFECT_TARGET,
            PetSkillActionState.CONFIRM_PREFLIGHT,
        }

    def _check_stage_stall(self, now: float, *, limit_seconds: float = 2.0) -> bool:
        """Fail closed if a synchronous read could later resume into stale input."""

        if not self._input_phase_watchdog_active():
            return False
        with self._stage_lock:
            stage = self._stage_name
            started = self._stage_started
            generation = self._stage_generation
            if (
                stage is None
                or now - started < limit_seconds
                or generation == self._stage_stall_generation
            ):
                return False
            self._stage_stall_generation = generation
        reason = f"OBSERVER_STAGE_STALLED:{stage}"
        self._fatal_stop_reason = reason
        executor = self._executor
        if executor is not None and executor.active:
            executor.abort(monotonic_now=now, reason=reason)
            self._emit_events()
        if self._emit is not None:
            self._emit(
                "pet_skill_action_stage_stalled",
                stage=stage,
                elapsedSeconds=round(now - started, 6),
                actionState=(executor.state if executor is not None else None),
                cardClicks=(executor.result.card_clicks if executor and executor.result else 0),
                spacePresses=(executor.result.space_presses if executor and executor.result else 0),
                failClosed=True,
            )
        print(
            f"PET SKILL ACTION READ STALL: {stage}; input authority revoked.",
            flush=True,
        )
        return True

    def _watch_stages(self) -> None:
        while not self._watchdog_stop.wait(0.1):
            self._check_stage_stall(time.monotonic())

    def pet_skill_control_refresh(
        self,
        cards: tuple[Any, ...],
        *,
        reason: str,
        elapsed_ms: float,
    ) -> None:
        """Bounded telemetry for the pre-action native hand refresh."""

        now = time.monotonic()
        signature = (
            reason,
            tuple(
                (
                    getattr(card, "card_id", None),
                    getattr(card, "data_address", None),
                    getattr(card, "button_address", None),
                    getattr(card, "interactable", None),
                    getattr(card, "has_used_this_turn", None),
                    getattr(card, "action_pending", None),
                )
                for card in cards
            ),
        )
        if (
            signature != self._last_control_refresh_signature
            or now - self._last_control_refresh_emit >= 5.0
        ):
            if self._emit is not None:
                self._emit(
                    "pet_skill_control_refresh",
                    reason=reason,
                    elapsedMs=round(elapsed_ms, 3),
                    cards=cards,
                )
            self._last_control_refresh_signature = signature
            self._last_control_refresh_emit = now

    def retain_pre_action_after_transient_read_failure(self, reason: str) -> bool:
        """Keep the exact watch session across one input-free transient read.

        A torn control, runtime-singleton or local-actor sample must not throw
        the idle/PREFLIGHT harness back to the expensive full-board discovery
        path.  Every retained cycle still starts with the exact control-only
        ownership read, so a real lifecycle edge becomes the authoritative
        ``qte_control_session_not_owned`` and is not retained.  Once any card
        click has been sent this method always returns false.
        """

        executor = self._executor
        transient = (
            reason in {
                "QTE_CONTROL_READ_FAILED",
                "QTE_CURRENT_RUNTIME_UNREADABLE",
                "QTE_CURRENT_ACTOR_UNREADABLE",
            }
            or reason.startswith("qte_control_rejected:")
        )
        input_free_pre_action = bool(
            executor is not None
            and executor.state in {
                PetSkillActionState.IDLE,
                PetSkillActionState.PREFLIGHT,
            }
            and executor.telemetry.card_click_timestamp is None
            and executor.telemetry.space_send_timestamp is None
        )
        if not transient or not input_free_pre_action:
            return False
        if reason != self._last_control_read_rejection and self._emit is not None:
            self._emit(
                "pet_skill_pre_action_control_read_retry",
                reason=reason,
                actionState=executor.state,
                session=self.pre_action_watch_session,
                inputEmitted=False,
                fullProviderFallback=False,
            )
        self._last_control_read_rejection = reason
        return True

    def retain_pre_action_after_control_read_failure(self, reason: str) -> bool:
        """Backward-compatible name for the generalized transient-read gate."""

        return self.retain_pre_action_after_transient_read_failure(reason)

    def retain_post_space_after_control_read_failure(self, reason: str) -> bool:
        """Keep only read-only result/post-state work after the QTE closes.

        A PERFECT Pet Skill may kill the boss and tear down ``Board`` ownership
        before the optional ``MATCH_SKILL_USE_RES`` callback is sampled. Once the
        one Space is already sent and runtime completion belongs to this exact
        QTE, losing ACTIVE_COMBAT cannot authorize any additional input.  Keep
        the immutable ActionId/MatchId until an exact terminal state is read or
        the original bounded settle deadline expires. The dispatcher tap may
        still collect telemetry, but it is not a success dependency.
        """

        executor = self._executor
        retain = bool(
            executor is not None
            and executor.active
            and executor.action_id is not None
            and executor.state
            in {
                PetSkillActionState.WAIT_RESULT,
                PetSkillActionState.RESULT_CORRELATED,
                PetSkillActionState.POST_SKILL_REREAD,
            }
            and executor.telemetry.space_send_timestamp is not None
            and executor.runtime_completion_observed
            and self._target is not None
            and self._target.is_running()
        )
        if not retain:
            return False
        if reason != self._last_post_space_read_rejection and self._emit is not None:
            self._emit(
                "pet_skill_post_space_readonly_retained",
                reason=reason,
                actionState=executor.state,
                actionId=executor.action_id,
                session=executor.action_id.session_key,
                inputEmitted=False,
                cardClicks=1,
                spacePresses=1,
            )
        self._last_post_space_read_rejection = reason
        return True

    def correlated_readonly_result(
        self,
        value: Any,
        *,
        sampled_monotonic: float,
    ) -> None:
        """Apply an exact dispatcher result after ACTIVE_COMBAT has closed."""

        context = dict(self._latest_context or {})
        runtime = context.get("runtime")
        if runtime is None:
            return
        # Correlation is against the retained completed QTE and immutable
        # ActionId.  The terminal GameState sampled before this callback is not
        # a post-correlation reread, so clear it and request a later poll.
        context.update(
            lifecycle_valid=True,
            control_battle=None,
            game_state=None,
            game_state_sampled_monotonic=None,
        )
        self._latest_context = context
        self.correlated_result(
            value,
            sampled_monotonic=sampled_monotonic,
            game_state=None,
            resources=context.get("resources") or {},
            runtime=runtime,
            control_battle=None,
        )

    def observe_post_space_readonly(
        self,
        game_state: Any,
        *,
        sampled_monotonic: float,
        reason: str,
    ) -> None:
        """Advance a bounded no-input wait and accept only exact terminal state."""

        executor = self._executor
        if executor is None or not executor.active or executor.action_id is None:
            return
        context = dict(self._latest_context or {})
        if not context:
            return
        action = executor.action_id
        battle = getattr(game_state, "battle", None) if game_state is not None else None
        terminal_snapshot = (
            getattr(game_state, "terminal_snapshot", None)
            if game_state is not None
            else None
        )
        battle_match_id = getattr(battle, "match_id", None)
        snapshot_match_id = getattr(terminal_snapshot, "match_id", None)
        lifecycle = getattr(battle, "combat_lifecycle", None)
        terminal = bool(
            battle is not None
            and (
                lifecycle is CombatLifecycleState.POSTMATCH
                or getattr(battle, "match_over", None) is True
                or getattr(battle, "board_is_game_over", None) is True
                or getattr(battle, "local_has_left_match", None) is True
            )
        )
        exact_terminal = bool(
            terminal
            and action.match_id in {battle_match_id, snapshot_match_id}
        )
        context.update(
            sampled_monotonic=sampled_monotonic,
            control_sampled_monotonic=None,
            lifecycle_valid=not exact_terminal,
            control_battle=(battle if exact_terminal else None),
            game_state=(game_state if exact_terminal else None),
            game_state_sampled_monotonic=(sampled_monotonic if exact_terminal else None),
        )
        self._latest_context = context
        qte = None if exact_terminal else (
            self._last_observation.qte if self._last_observation is not None else None
        )
        observation = self._observation(qte, inactive_qte_proven=False)
        if observation is None:
            return
        self._last_observation = observation
        executor.step(observation, monotonic_now=sampled_monotonic)
        self._sync_result_tap()
        self._emit_events()
        if self._emit is not None and exact_terminal:
            self._emit(
                "pet_skill_terminal_post_state_observed",
                reason=reason,
                actionState=executor.state,
                actionId=action,
                matchId=action.match_id,
                freshAfterCorrelation=bool(
                    self._post_state_not_before is not None
                    and sampled_monotonic > self._post_state_not_before
                ),
                inputEmitted=False,
            )

    def note_control_read_success(self) -> None:
        self._last_control_read_rejection = None
        self._last_post_space_read_rejection = None

    def inactive(self, session: Any) -> None:
        self._inactive_sessions.add(session)
        self._drive(None, inactive_qte_proven=True)

    def snapshot(self, value: Any, *, lifecycle_valid: bool) -> None:
        if self._latest_context is not None:
            self._latest_context["lifecycle_valid"] = bool(lifecycle_valid)
        self._drive(value, inactive_qte_proven=False)

    def correlated_result(
        self,
        value: Any,
        *,
        sampled_monotonic: float,
        game_state: Any,
        resources: dict[str, Any],
        runtime: Any,
        control_battle: Any = None,
    ) -> None:
        executor = self._executor
        if executor is None or not executor.active or value is None:
            return
        context = dict(self._latest_context or {})
        context.update(
            sampled_monotonic=sampled_monotonic,
            resources=resources,
            runtime=runtime,
            # The board sampled before the response scan is not the required
            # post-correlation reread. Wait for a later normal provider poll.
            game_state=None,
            control_battle=control_battle,
        )
        self._latest_context = context
        observation = self._observation(value, inactive_qte_proven=False)
        if observation is None:
            executor.abort(
                monotonic_now=time.monotonic(),
                reason="CORRELATED_RESULT_CONTEXT_UNAVAILABLE",
            )
            self._emit_events()
            return
        now = time.monotonic()
        previous_state = executor.state
        executor.step(observation, monotonic_now=now)
        self._sync_result_tap()
        if (
            executor.state is PetSkillActionState.POST_SKILL_REREAD
            and previous_state is not PetSkillActionState.POST_SKILL_REREAD
        ):
            self._post_state_not_before = now
        self._emit_events()

    def server_rejected_result(
        self,
        *,
        reason: str,
        response_address: int | None = None,
    ) -> None:
        """Apply an exactly correlated explicit reject; absence is ignored."""

        executor = self._executor
        if executor is None or not executor.active:
            return
        executor.reject_server_result(
            monotonic_now=time.monotonic(),
            reason=reason,
        )
        self._sync_result_tap()
        self._emit_events()
        if self._emit is not None:
            self._emit(
                "pet_skill_server_reject_applied",
                reason=reason,
                responseAddress=(
                    f"0x{response_address:016X}"
                    if response_address is not None
                    else None
                ),
                actionId=executor.action_id,
                inputEmitted=False,
            )

    def unreadable(self, reason: str) -> None:
        executor = self._executor
        if executor is not None and executor.active:
            executor.abort(monotonic_now=time.monotonic(), reason=reason)
            self._emit_events()

    def invalidate(self, reason: str) -> None:
        executor = self._executor
        if executor is not None and executor.active:
            executor.abort(monotonic_now=time.monotonic(), reason=reason)
            self._emit_events()
        self._latest_context = None
        self._inactive_sessions.clear()
        if self._result_tap is not None:
            self._result_tap.disarm()

    def stop(self, reason: str) -> None:
        self._watchdog_stop.set()
        executor = self._executor
        if executor is not None and executor.active:
            executor.abort(monotonic_now=time.monotonic(), reason=reason)
            self._emit_events()
        if self._result_tap is not None:
            self._result_tap.stop()

    def _drive(self, qte: Any, *, inactive_qte_proven: bool) -> None:
        if self._fatal_stop_reason is not None:
            return
        executor = self._executor
        if executor is None:
            return
        observation = self._observation(
            qte,
            inactive_qte_proven=inactive_qte_proven,
        )
        if observation is None:
            return
        self._last_observation = observation
        now = time.monotonic()
        if executor.state in {PetSkillActionState.IDLE, PetSkillActionState.PREFLIGHT}:
            self._preflight_timing = {
                "geometryMs": round(self._geometry_elapsed_ms, 3),
                "sampleAgeMs": round((now - observation.sampled_monotonic) * 1000, 3),
            }
        if executor.state is PetSkillActionState.IDLE and not self._invocation_consumed:
            ready, reason = executor.can_execute(observation, monotonic_now=now)
            if not ready:
                diagnostic = (self._latest_context or {}).get("card_diagnostics") or {}
                resources = (self._latest_context or {}).get("resources") or {}
                wait_identity = (
                    reason,
                    observation.mana,
                    observation.power,
                    resources.get("resourceCurrent"),
                    self._geometry_reason,
                    diagnostic.get("nativeCardDiscoveryReason"),
                )
                if wait_identity != self._last_wait_reason and self._emit is not None:
                    self._emit(
                        "pet_skill_action_waiting",
                        reason=reason,
                        session=observation.session_key,
                        turn=observation.turn_number,
                        mana=observation.mana,
                        power=observation.power,
                        capability=observation.capability,
                        geometryReason=self._geometry_reason,
                        geometryReadAttempts=self._geometry_read_attempts,
                        geometryRetryReason=self._geometry_retry_reason,
                        preflightTiming=self._preflight_timing,
                        resourceCurrent=resources.get("resourceCurrent"),
                        resourceSource=resources.get("resourceSource"),
                        resourceReadError=resources.get("resourceReadError"),
                        resourceSampledMonotonic=resources.get("resourceSampledMonotonic"),
                        cardDiscovery=(self._latest_context or {}).get("card_diagnostics"),
                    )
                    self._last_wait_reason = wait_identity
                return
            self._invocation_consumed = True
            executor.begin(observation, monotonic_now=now)
            self._sync_result_tap()
            self._emit_events()
            return
        if executor.active:
            previous_state = executor.state
            executor.step(observation, monotonic_now=now)
            if (
                executor.state is PetSkillActionState.POST_SKILL_REREAD
                and previous_state is not PetSkillActionState.POST_SKILL_REREAD
            ):
                # The GameState carried by this same observation predates or is
                # concurrent with runtime completion. Require a later poll.
                self._post_state_not_before = now
            self._sync_result_tap()
            self._emit_events()
            self._rearm_after_zero_input_preflight_race(executor)

    def _rearm_after_zero_input_preflight_race(
        self,
        completed_executor: PetSkillActionExecutor,
    ) -> bool:
        """Keep waiting when the final card sample loses the turn before input.

        The initial and final card proofs intentionally use separate reads.  A
        normal turn boundary can land between them.  That is not an invocation:
        no click, direction, or Space was emitted, so a fresh executor may wait
        for the next actionable turn.  Every post-input or ownership failure
        remains terminal.
        """

        result = completed_executor.result
        factory = self._executor_factory
        rearmable = {
            "FINAL_CARD_LOCAL_TURN_NOT_ACTIONABLE",
            "FINAL_CARD_PET_SKILL_BUTTON_NOT_ACTIONABLE",
            "FINAL_CARD_PET_SKILL_CARDUI_NOT_CURRENTLY_USABLE",
            "FINAL_CARD_PREFLIGHT_SAMPLE_STALE",
        }
        card_diagnostics = (self._latest_context or {}).get("card_diagnostics") or {}
        native_card_reason = str(
            card_diagnostics.get("nativeCardDiscoveryReason", "")
        )
        # The native hand is intentionally sampled again between the initial
        # preflight and the card click.  A geometry fence can change during
        # that read while Unity is laying out the strip.  In that exact case
        # refresh_pet_skill_cards publishes no candidates, so the derived
        # capability is temporarily NO_CAPABILITY.  With zero emitted input,
        # keep waiting for another complete hand sample.  Do not generalize a
        # genuinely absent capability: only the explicit reader-error evidence
        # makes this final-preflight rejection retryable.
        transient_native_hand_rejection = bool(
            result is not None
            and result.reason == "FINAL_CARD_CURRENT_PET_SKILL_CAPABILITY_MISSING"
            and native_card_reason.startswith("pet_skill_control_read_error:")
        )
        if (
            result is None
            or result.kind is not PetSkillActionResultKind.PREFLIGHT_REJECTED
            or (
                result.reason not in rearmable
                and not transient_native_hand_rejection
            )
            or result.card_clicks != 0
            or result.space_presses != 0
            or factory is None
        ):
            return False
        previous_action = completed_executor.action_id
        self._executor = factory()
        self._invocation_consumed = False
        self._last_event_count = 0
        self._result_emitted = False
        self._last_wait_reason = None
        self._last_observation = None
        self._post_state_not_before = None
        if self._emit is not None:
            self._emit(
                "pet_skill_action_preflight_rearmed",
                reason=result.reason,
                previousActionId=previous_action,
                cardClicks=0,
                spacePresses=0,
                inputEmitted=False,
                nativeCardDiscoveryReason=(
                    native_card_reason if transient_native_hand_rejection else None
                ),
            )
        return True

    def _observation(
        self,
        qte: Any,
        *,
        inactive_qte_proven: bool,
    ) -> PetSkillActionObservation | None:
        context = self._latest_context
        backend = self._backend
        binding = self._binding
        target = self._target
        if context is None or backend is None or binding is None or target is None:
            return None
        session = context.get("session")
        runtime = context.get("runtime")
        resources = context.get("resources") or {}
        capability = context.get("capability")
        live_cards: tuple[CardState, ...] = tuple(context.get("live_cards") or ())
        live_card = None
        if capability is not None:
            exact = tuple(
                card
                for card in live_cards
                if card.object_address == capability.live_card_address
                and card.button_address == capability.live_button_address
                and card.data_address == capability.card_data_address
                and card.card_id == capability.skill_card_id
            )
            if len(exact) == 1:
                live_card = exact[0]
        current_geometry = backend.client_geometry(binding.hwnd)
        window_current = bool(
            backend.window_pid(binding.hwnd) == binding.pid
            and current_geometry is not None
            and current_geometry.width == binding.initial_width
            and current_geometry.height == binding.initial_height
        )
        game_state = context.get("game_state")
        battle = context.get("control_battle") or (game_state.battle if game_state is not None else None)
        local_turn = bool(
            runtime is not None
            and runtime.current_player
            and runtime.local_username
            and runtime.current_player == runtime.local_username
        )
        technical_recovery = bool(
            battle is not None
            and (
                battle.reconnecting is True
                or battle.match_resyncing is True
                or battle.connection_ready is False
            )
        )
        postmatch = bool(
            battle is not None
            and (
                battle.match_over is True
                or battle.board_is_game_over is True
                or battle.local_has_left_match is True
            )
        )
        geometry_ready = bool(
            self._executor is not None
            and self._executor.state
            in {PetSkillActionState.IDLE, PetSkillActionState.PREFLIGHT}
            and (
                not self._invocation_consumed
                or self._executor.state is PetSkillActionState.PREFLIGHT
            )
            and inactive_qte_proven
            and session in self._inactive_sessions
            and local_turn
            and capability is not None
            and capability.current
            and capability.effective_mana_cost is not None
            and capability.effective_power_cost is not None
            and resources.get("mana") is not None
            and resources.get("power") is not None
            and resources["mana"] >= capability.effective_mana_cost
            and resources["power"] >= capability.effective_power_cost
        )
        geometry_started = time.monotonic()
        geometry = None
        if window_current and geometry_ready:
            self.trace_stage("card_geometry_begin")
            try:
                geometry = self._geometry_proof(session, live_card)
            finally:
                self.trace_stage("card_geometry_end")
        if geometry is not None and live_card is not None and (
            geometry.session_key == session
            and geometry.card_ui_address == live_card.object_address
            and geometry.button_address == live_card.button_address
            and geometry.card_data_address == live_card.data_address
            and geometry.skill_card_id == live_card.card_id
        ):
            # Only refresh layout diagnostics from this exact current proof;
            # identity, resources and usability remain independently checked.
            live_card = replace(live_card, ui_slot=geometry.slot_index,
                                ui_slot_count=geometry.slot_count)
        self._geometry_elapsed_ms = (time.monotonic() - geometry_started) * 1000
        post_state_fresh = bool(
            self._executor is not None
            and self._executor.state is PetSkillActionState.POST_SKILL_REREAD
            and game_state is not None
            and self._post_state_not_before is not None
            and context.get("game_state_sampled_monotonic") is not None
            and context["game_state_sampled_monotonic"] > self._post_state_not_before
        )
        return PetSkillActionObservation(
            sampled_monotonic=float(context.get("sampled_monotonic", time.monotonic())),
            control_sampled_monotonic=context.get("control_sampled_monotonic"),
            match_id=(runtime.match_id if runtime is not None else None),
            session_key=session,
            lifecycle=(
                CombatLifecycleState.ACTIVE
                if context.get("lifecycle_valid")
                else CombatLifecycleState.UNKNOWN
            ),
            local_actor=context.get("local_actor"),
            turn_number=(runtime.turn if runtime is not None else None),
            is_local_turn=local_turn,
            mana=resources.get("mana"),
            power=resources.get("power"),
            capability=capability,
            live_card=live_card,
            geometry=geometry,
            qte=qte,
            inactive_qte_proven=bool(
                session in self._inactive_sessions
                and (inactive_qte_proven or (qte is not None and executor_is_active(self._executor)))
            ),
            window_binding=binding if window_current else None,
            game_foreground=backend.is_foreground(binding.hwnd),
            process_running=bool(target.is_running()),
            input_authority_owned=True,
            conflicting_gameplay_action=False,
            technical_recovery=technical_recovery,
            sequence_desync=False,
            postmatch_or_terminal=postmatch,
            post_state=game_state if post_state_fresh else None,
            post_state_fresh=post_state_fresh,
            board_dedup_key=(
                game_state.dedup_key
                if game_state is not None
                and getattr(game_state, "phase", None) is GamePhase.COMBAT
                else None
            ),
        )

    def _geometry_proof(
        self,
        session: Any,
        live_card: CardState | None,
    ) -> PetSkillCardGeometryProof | None:
        self._geometry_reason = "CURRENT_CARD_GEOMETRY_IDENTITY_MISSING"
        self._geometry_read_attempts = 0
        self._geometry_retry_reason = None
        if (
            session is None
            or live_card is None
            or live_card.button_address is None
        ):
            return None
        try:
            if not self._backend.is_foreground(self._binding.hwnd):
                self._geometry_reason = "GAME_NOT_FOREGROUND"
                return None
            if self._native_cards is None:
                self._native_cards = NativeCardUiReader(
                    self._target.memory, self._target.game_assembly.base
                )
            card_class = self._target.resolver.resolve_type_info_class(CARD_UI_TYPE_INFO_RVA)
            if card_class is None:
                self._geometry_reason = "CARD_UI_CLASS_UNKNOWN"
                return None
            for attempt in range(2):
                self._geometry_read_attempts = attempt + 1
                try:
                    # One fresh whole-hand reread is allowed before any input.
                    # read_hand clears every per-read geometry cache/fence.
                    hand = self._native_cards.read_hand(session.board_instance, card_class)
                    break
                except NativeGeometryBusyError as exc:
                    self._geometry_retry_reason = str(exc)
                    if attempt == 1:
                        raise
            # Slot from an earlier provider poll is only diagnostic. Resolve
            # it from this validated hand, never require/reuse a stale slot.
            entry = hand.entry_for_card(live_card.object_address)
            if entry is None:
                self._geometry_reason = "CARD_NOT_IN_CURRENT_VISIBLE_HAND"
                return None
            self._native_cards.validate_button_owner(
                live_card.object_address, live_card.button_address, entry
            )
            # Re-read current CardUI fields, not only its geometry. The action
            # sample must still refer to this exact data/Button and be usable.
            active = self._target.resolver.read_pointer(session.board_instance + BOARD_ACTIVE_OFFSET)
            current = read_combat_card(
                self._target.memory, live_card.object_address,
                expected_class=card_class, expected_board=session.board_instance,
                expected_active=active,
            )
            if (current.card_data != live_card.data_address or current.button != live_card.button_address
                    or not current.ui_interactable or current.action_pending
                    or current.is_placeholder or current.has_used_this_turn):
                self._geometry_reason = "CARD_CHANGED_BEFORE_GEOMETRY_PROOF"
                return None
            capture = capture_client_rgb(self._target.pid)
        except (OSError, RuntimeError, ValueError, ExternalReadError, LayoutValidationError) as exc:
            self._geometry_reason = str(exc)
            return None
        if (
            capture.width != self._binding.initial_width
            or capture.height != self._binding.initial_height
        ):
            self._geometry_reason = "CAPTURE_WINDOW_SIZE_CHANGED"
            return None
        location = locate_native_pet_skill_control(
            capture.rgb,
            capture.width,
            capture.height,
            entry.viewport_rect,
            root_aspect=entry.root_aspect,
        )
        self._geometry_reason = location.reason
        if not location.found or location.normalized_point is None:
            return None
        return PetSkillCardGeometryProof(
            session_key=session,
            card_ui_address=live_card.object_address,
            button_address=live_card.button_address,
            card_data_address=live_card.data_address,
            skill_card_id=live_card.card_id,
            window_binding=self._binding,
            normalized_point=location.normalized_point,
            slot_index=hand.slot_for_card(live_card.object_address),
            slot_count=len(hand.visible),
            source=(
                "Board.cardsInHand+native_components+handle_roundtrip+"
                "current_RectTransform+"
                f"visual_{location.reason}"
            ),
        )

    def _emit_events(self) -> None:
        if self._executor is None or self._emit is None:
            return
        events = self._executor.events
        for item in events[self._last_event_count :]:
            geometry = (
                self._last_observation.geometry
                if self._last_observation is not None
                else None
            )
            self._emit(
                item.event,
                actionState=item.state,
                monotonicAt=item.monotonic_at,
                reason=item.reason,
                directionEvent=item.direction_event,
                actionId=(
                    self._executor.action_id
                ),
                telemetry=self._executor.telemetry,
                lastCardPreflightTiming=self._preflight_timing,
                geometryReason=self._geometry_reason,
                geometryReadAttempts=self._geometry_read_attempts,
                geometryRetryReason=self._geometry_retry_reason,
                cardClickInput=(
                    {
                        "normalizedPoint": geometry.normalized_point,
                        "cursorSettleSeconds": DEFAULT_SWAP_CURSOR_SETTLE_SECONDS,
                        "mouseButtonHoldSeconds": getattr(
                            self._backend, "mouse_button_hold_seconds", None
                        ),
                        "singleClickNoRetry": True,
                    }
                    if item.state in {
                        PetSkillActionState.CARD_CLICK,
                        PetSkillActionState.WAIT_QTE_GENERATION,
                    }
                    and geometry is not None
                    else None
                ),
            )
        self._last_event_count = len(events)
        if self._executor.result is not None and not self._result_emitted:
            result = self._executor.result
            self._emit("pet_skill_action_result", result=result,
                       lastCardPreflightTiming=self._preflight_timing,
                       geometryReason=self._geometry_reason,
                       geometryReadAttempts=self._geometry_read_attempts,
                       geometryRetryReason=self._geometry_retry_reason)
            self._result_emitted = True
            print(
                f"PET SKILL ACTION {result.kind.value}: {result.reason}; "
                f"cardClicks={result.card_clicks}, Space={result.space_presses}",
                flush=True,
            )


def executor_is_active(executor: PetSkillActionExecutor | None) -> bool:
    return bool(executor is not None and executor.active)


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    authority = parser.add_mutually_exclusive_group()
    authority.add_argument(
        "--execute-once",
        action="store_true",
        help="required explicit authority for exactly one full Pet Skill action",
    )
    authority.add_argument(
        "--b4-two-same-match",
        action="store_true",
        help="B4 only: authorize at most two full actions in one retained match/session",
    )
    parser.add_argument("--log", type=Path, help="JSONL output path")
    parser.add_argument("--interval", type=float, default=0.025)
    parser.add_argument("--timeout", type=float, default=900.0)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument("--direction-ack-timeout", type=float, default=1.25)
    parser.add_argument("--qte-generation-timeout", type=float, default=3.0)
    parser.add_argument(
        "--result-timeout",
        type=float,
        default=15.0,
        help=(
            "bounded read-only wait for current CardUI runtime completion after "
            "Space (default: 15 seconds; Space is never retried)"
        ),
    )
    parser.add_argument(
        "--post-state-timeout",
        type=float,
        default=30.0,
        help=(
            "deprecated compatibility option; runtime PERFECT now completes "
            "the one-shot and later gameplay uses its normal board gate"
        ),
    )
    parser.add_argument(
        "--allow-combat-start",
        action="store_true",
        help="diagnostic only; starting in the boss lobby is the accepted procedure",
    )
    return parser


def run(args: argparse.Namespace) -> int:
    b4 = bool(getattr(args, "b4_two_same_match", False))
    if not args.execute_once and not b4:
        raise ValueError("explicit --execute-once or --b4-two-same-match authority required")
    if b4 and args.allow_combat_start:
        raise ValueError("B4 requires a fresh boss-lobby baseline")
    log_path = (args.log or default_log_path("phase3b3_pet_skill_action")).resolve()
    observer_args = argparse.Namespace(
        watch=True,
        log=log_path,
        interval=args.interval,
        timeout=args.timeout,
        # The hook's ``done`` signal owns termination at current-generation
        # runtime PERFECT. The observer's raw callback counter is telemetry.
        qtes=0,
        max_region_mib=args.max_region_mib,
        chunk_mib=args.chunk_mib,
        allow_combat_start=args.allow_combat_start,
    )
    hook_type = Phase3b3RuntimeHook
    if b4:
        from tools.pet_skill_b4 import Phase3b3B4RuntimeHook
        hook_type = Phase3b3B4RuntimeHook
    hook = hook_type(
        direction_ack_timeout_seconds=args.direction_ack_timeout,
        qte_generation_timeout_seconds=args.qte_generation_timeout,
        result_timeout_seconds=args.result_timeout,
        post_state_timeout_seconds=args.post_state_timeout,
    )
    previous_interrupt = signal.getsignal(signal.SIGINT)
    previous_terminate = signal.getsignal(signal.SIGTERM)

    def operator_abort(_signum: int, _frame: Any) -> None:
        hook.stop("OPERATOR_ABORT")
        raise KeyboardInterrupt

    signal.signal(signal.SIGINT, operator_abort)
    signal.signal(signal.SIGTERM, operator_abort)
    try:
        with AutomationControllerLease(current_app_paths().controller_lock):
            observer_result = run_observer(observer_args, runtime_hook=hook)
            if observer_result != 0:
                return observer_result
            return 0 if hook.completed_successfully else 2
    except KeyboardInterrupt:
        print("Pet Skill action stopped; no further input can be sent.", flush=True)
        return 130
    finally:
        hook.stop("HARNESS_EXIT")
        signal.signal(signal.SIGINT, previous_interrupt)
        signal.signal(signal.SIGTERM, previous_terminate)


def main() -> int:
    try:
        return run(build_parser().parse_args())
    except (OSError, RuntimeError, ValueError) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
