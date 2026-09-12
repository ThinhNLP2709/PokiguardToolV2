"""Phase 3C.0 bounded one-skill same-turn continuation audit.

The accepted Phase 3B.3 primitive executes exactly one Pet Skill.  After its
current-generation runtime PERFECT result, this hook emits no further input.
It keeps the read-only observer alive until a fresh full-board publication can
show whether normal Phase 2 actionability is blocked only by the native
``Board.isUsingLegendCard`` flag.
"""

from __future__ import annotations

import math
from pathlib import Path
import time
from typing import Any

from pokiguard_v2.legend_card_continuation import (
    LegendContinuationSample,
    LegendContinuationVerdict,
    classify_legend_card_continuation,
)
from tools.pet_skill_action import Phase3b3RuntimeHook


class Phase3c0RuntimeHook(Phase3b3RuntimeHook):
    name = "PHASE3C0_LEGEND_CARD_SAME_TURN_AUDIT"

    def __init__(
        self,
        *,
        continuation_timeout_seconds: float,
        **kwargs: Any,
    ) -> None:
        super().__init__(**kwargs)
        if not 1.0 <= continuation_timeout_seconds <= 60.0:
            raise ValueError("continuation timeout must be between 1 and 60 seconds")
        self._continuation_timeout = continuation_timeout_seconds
        self._audit_session: Any = None
        self._audit_turn: int | None = None
        self._audit_actor: int | None = None
        self._accepted_at: float | None = None
        self._inactive_after_result: float | None = None
        self._audit_sample: LegendContinuationSample | None = None
        self._audit_reason: str | None = None
        self._audit_complete = False
        self._audit_conclusive = False
        self._last_audit_signature: tuple[Any, ...] | None = None
        self._last_post_perfect_gap_reason: str | None = None

    @property
    def done(self) -> bool:
        result = self.result
        return bool(
            self._fatal_stop_reason is not None
            or result is not None
            and not result.success
            or self._audit_complete
        )

    @property
    def completed_successfully(self) -> bool:
        return bool(
            self.result is not None
            and self.result.success
            and self._audit_complete
            and self._audit_conclusive
        )

    @property
    def summary(self) -> Any:
        return {
            "kind": "PHASE3C0_AUDIT",
            "conclusive": self._audit_conclusive,
            "reason": self._audit_reason,
            "session": self._audit_session,
            "sourceTurn": self._audit_turn,
            "localActor": self._audit_actor,
            "inactiveAfterPerfect": self._inactive_after_result is not None,
            "sample": self._audit_sample,
            "action": self.result,
            "postPerfectGameplayInput": 0,
        }

    @property
    def continuation_audit_session(self) -> Any:
        """Retain the exact action session for bounded post-Perfect RPM.

        This only changes observer routing.  The accepted action is already
        complete and the audit has no input authority.
        """

        if (
            self._accepted_at is not None
            and not self._audit_complete
            and self._audit_session is not None
        ):
            return self._audit_session
        return None

    def retain_post_perfect_after_control_read_failure(
        self,
        reason: str,
        *,
        poll: Any = None,
    ) -> bool:
        """Wait through a bounded Board/Active gap after runtime PERFECT.

        A Legend-card animation may temporarily remove the combat singletons.
        The failed sample is never treated as current board evidence and cannot
        emit gameplay input.  Only a later fresh, same-session full publication
        can make the continuation audit conclusive.
        """

        if (
            self._accepted_at is None
            or self._audit_complete
            or self._audit_session is None
        ):
            return False
        now = time.monotonic()
        if now - self._accepted_at >= self._continuation_timeout:
            self._finish_audit("POST_PERFECT_CURRENT_STATE_TIMEOUT", conclusive=False)
            return True
        if reason != self._last_post_perfect_gap_reason and self._emit is not None:
            lifecycle = getattr(poll, "combat_lifecycle", None)
            self._emit(
                "legend_card_post_perfect_ownership_gap_retained",
                reason=reason,
                session=self._audit_session,
                lifecycle=getattr(lifecycle, "state", None),
                lifecycleReason=getattr(lifecycle, "reason", None),
                providerSession=getattr(poll, "session_key", None),
                elapsedSeconds=now - self._accepted_at,
                inputEmitted=False,
                postPerfectGameplayInput=0,
            )
        self._last_post_perfect_gap_reason = reason
        return True

    def started(self, log_path: Path) -> None:
        print(f"Phase 3C.0 legend-card continuation audit; log: {log_path}", flush=True)
        print(
            "WAITING: play/evolve manually. The harness uses exactly one current "
            "Pet Skill, then performs read-only same-turn observation and stops.",
            flush=True,
        )
        if self._emit is not None:
            self._emit(
                "legend_card_continuation_authorized",
                actionLimit=1,
                postPerfectGameplayInput=0,
                continuationTimeoutSeconds=self._continuation_timeout,
                basicPolicyIntegration=False,
            )

    def attach(self, target: Any, emit: Any) -> None:
        def audit_emit(event: str, **fields: Any) -> None:
            if event == "pet_skill_action_harness_attached":
                fields.update(
                    actionLimit=1,
                    inputAuthority="PHASE3C0_ONE_SKILL_THEN_READ_ONLY",
                    postPerfectGameplayInput=0,
                )
            emit(event, **fields)

        super().attach(target, audit_emit)

    def runtime_context(self, **context: Any) -> None:
        super().runtime_context(**context)
        if self._accepted_at is None or self._audit_complete:
            return
        now = time.monotonic()
        if now - self._accepted_at >= self._continuation_timeout:
            self._finish_audit("POST_PERFECT_CURRENT_STATE_TIMEOUT", conclusive=False)
            return
        runtime = context.get("runtime")
        if (
            context.get("session") != self._audit_session
            or runtime is None
            or runtime.match_id != self._audit_session.match_id
            or context.get("local_actor") != self._audit_actor
            or not context.get("lifecycle_valid")
        ):
            self._finish_audit("SESSION_OR_OWNER_CHANGED_AFTER_PERFECT", conclusive=False)
            return
        self._evaluate_current_context()

    def note_control_read_success(self) -> None:
        super().note_control_read_success()
        self._last_post_perfect_gap_reason = None

    def inactive(self, session: Any) -> None:
        context = self._latest_context or {}
        sampled = context.get("sampled_monotonic")
        now = time.monotonic()
        if (
            self._accepted_at is not None
            and not self._audit_complete
            and session == self._audit_session
            and context.get("session") == session
            and isinstance(sampled, (float, int))
            and math.isfinite(sampled)
            and self._accepted_at < sampled <= now
            and now - sampled <= 0.5
        ):
            if self._inactive_after_result is None and self._emit is not None:
                self._emit(
                    "legend_card_qte_inactive_after_perfect",
                    session=session,
                    sourceTurn=self._audit_turn,
                    sampledMonotonic=sampled,
                    inputEmitted=False,
                )
            self._inactive_after_result = float(sampled)
        super().inactive(session)
        self._evaluate_current_context()

    def invalidate(self, reason: str) -> None:
        if self._accepted_at is not None and not self._audit_complete:
            self._finish_audit(
                f"POST_PERFECT_CONTEXT_INVALIDATED:{reason}", conclusive=False
            )
        super().invalidate(reason)

    def stop(self, reason: str) -> None:
        if self._accepted_at is not None and not self._audit_complete:
            self._finish_audit(f"AUDIT_STOPPED:{reason}", conclusive=False)
        super().stop(reason)

    def _drive(self, qte: Any, *, inactive_qte_proven: bool) -> None:
        had_result = self.result is not None
        super()._drive(qte, inactive_qte_proven=inactive_qte_proven)
        result = self.result
        if had_result or result is None or not result.success or self._accepted_at is not None:
            return
        action = result.action_id
        if action is None:
            self._finish_audit("PERFECT_ACTION_ID_MISSING", conclusive=False)
            return
        self._audit_session = action.session_key
        self._audit_turn = action.source_turn
        self._audit_actor = action.local_actor
        self._accepted_at = time.monotonic()
        if self._emit is not None:
            context = self._latest_context or {}
            battle = context.get("control_battle")
            self._emit(
                "legend_card_post_perfect_audit_started",
                actionId=action,
                session=self._audit_session,
                sourceTurn=self._audit_turn,
                legendFlagAtPerfect=getattr(
                    battle, "board_is_using_legend_card", None
                ),
                deadlineMonotonic=self._accepted_at + self._continuation_timeout,
                postPerfectGameplayInput=0,
            )

    def _evaluate_current_context(self) -> None:
        if (
            self._accepted_at is None
            or self._audit_complete
            or self._inactive_after_result is None
            or self._audit_session is None
            or self._audit_turn is None
        ):
            return
        context = self._latest_context or {}
        state = context.get("game_state")
        sampled = context.get("game_state_sampled_monotonic")
        if (
            not context.get("provider_state_fresh")
            or state is None
            or not isinstance(sampled, (float, int))
            or not math.isfinite(sampled)
            or sampled <= self._accepted_at
        ):
            return
        sample = classify_legend_card_continuation(
            state,
            expected_session=self._audit_session,
            source_turn=self._audit_turn,
        )
        self._audit_sample = sample
        battle = state.battle
        signature = (
            sample.verdict,
            sample.observed_turn,
            sample.legend_flag,
            sample.other_modal_open,
            sample.actual_gate_reason,
            sample.without_legend_gate_reason,
            battle.is_board_ready,
            battle.is_cascade_running,
            battle.board_current_state,
            battle.board_is_processing_ui,
            battle.presentation_busy,
        )
        if signature != self._last_audit_signature and self._emit is not None:
            self._emit(
                "legend_card_continuation_sample",
                sample=sample,
                providerReason=context.get("provider_reason"),
                boardModalOpen=battle.board_modal_open,
                modalSignals={
                    "isUsingLegendCard": battle.board_is_using_legend_card,
                    "isUsingMega": battle.board_is_using_mega,
                    "mega1PanelOpen": battle.board_is_mega1_panel_open,
                    "mega2PanelOpen": battle.board_is_mega2_panel_open,
                },
                boardReady=battle.is_board_ready,
                cascadeRunning=battle.is_cascade_running,
                boardCurrentState=battle.board_current_state,
                boardProcessingUi=battle.board_is_processing_ui,
                presentationBusy=battle.presentation_busy,
                currentPlayer=battle.current_turn_player,
                isLocalTurn=battle.is_local_turn,
                clientMoveAllowed=battle.client_move_allowed,
                inputEmitted=False,
            )
            self._last_audit_signature = signature
        if sample.conclusive_continuation:
            self._finish_audit(sample.verdict.value, conclusive=True)
        elif sample.verdict is LegendContinuationVerdict.SESSION_CHANGED:
            self._finish_audit(sample.verdict.value, conclusive=False)

    def _finish_audit(self, reason: str, *, conclusive: bool) -> None:
        if self._audit_complete:
            return
        self._audit_complete = True
        self._audit_conclusive = conclusive
        self._audit_reason = reason
        if self._emit is not None:
            self._emit(
                "legend_card_continuation_audit_complete",
                conclusive=conclusive,
                reason=reason,
                session=self._audit_session,
                sourceTurn=self._audit_turn,
                sample=self._audit_sample,
                action=self.result,
                postPerfectGameplayInput=0,
            )
        print(
            f"PHASE 3C.0 AUDIT {'CONCLUSIVE' if conclusive else 'INCONCLUSIVE'}: "
            f"{reason}",
            flush=True,
        )
