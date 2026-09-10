"""B4-only two-action coordinator; retains the observer across QTE generations.

No board policy, consumable input, response wait or automatic match re-entry.
The production one-action primitive and its direction/Space timing are unchanged.
"""

from __future__ import annotations

import math
from pathlib import Path
import time
from typing import Any

from pokiguard_v2.pet_skill_action import PetSkillActionState
from tools.pet_skill_action import Phase3b3RuntimeHook


class Phase3b3B4RuntimeHook(Phase3b3RuntimeHook):
    name = "PHASE3B3_B4_TWO_ACTIONS_SAME_MATCH"

    def __init__(self, **kwargs: Any) -> None:
        super().__init__(**kwargs)
        self._b4_session: Any = None
        self._accepted: list[Any] = []
        self._accepted_qtes: list[Any] = []
        self._accepted_at: float | None = None
        self._inactive_after_result: float | None = None
        self._b4_wait_reason: str | None = None

    @property
    def completed_successfully(self) -> bool:
        return len(self._accepted) == 2 and self._fatal_stop_reason is None

    @property
    def done(self) -> bool:
        return bool(self.completed_successfully or self._fatal_stop_reason
                    or (self.result is not None and not self.result.success))

    @property
    def summary(self) -> Any:
        return {
            "kind": ("B4_SUCCESS_TWO_CURRENT_PERFECT" if self.completed_successfully
                     else "B4_INCOMPLETE"),
            "reason": self._fatal_stop_reason,
            "actionLimit": 2,
            "acceptedActions": len(self._accepted),
            "session": self._b4_session,
            "actions": tuple(self._accepted),
            "qteIdentities": tuple(qte.identity for qte in self._accepted_qtes),
            "currentAction": super().summary,
        }

    def started(self, log_path: Path) -> None:
        print(f"Phase 3B.3 B4: at most TWO Pet Skills in ONE match; log: {log_path}", flush=True)
        print("Play/evolve manually; no Mana/Rage consumables. Keep foreground. "
              "After first PERFECT, keep playing in this match; the harness waits "
              "for a later ready local turn and resources. Stops after second "
              "PERFECT or any failure/session exit.", flush=True)
        if self._emit is not None:
            self._emit("pet_skill_b4_authorized", actionLimit=2,
                       perActionClickLimit=1, sameMatchRequired=True,
                       basicPolicyIntegration=False, consumableInput=False)

    def attach(self, target: Any, emit: Any) -> None:
        def b4_emit(event: str, **fields: Any) -> None:
            if event == "pet_skill_action_harness_attached":
                fields.update(actionLimit=2, cardClickLimit=2,
                              perActionClickLimit=1, sameMatchRequired=True,
                              inputAuthority="B4_TWO_FULL_ACTIONS_SAME_MATCH")
            emit(event, **fields)
        super().attach(target, b4_emit)

    def _stop_b4(self, reason: str) -> None:
        if self._fatal_stop_reason is not None or self.completed_successfully:
            return
        self._fatal_stop_reason = reason
        if self._executor is not None and self._executor.active:
            self._executor.abort(monotonic_now=time.monotonic(), reason=reason)
            self._emit_events()
        if self._emit is not None:
            self._emit("pet_skill_b4_stopped", reason=reason,
                       acceptedActions=len(self._accepted), session=self._b4_session)

    def runtime_context(self, **context: Any) -> None:
        super().runtime_context(**context)
        if self._b4_session is None or self.done:
            return
        runtime = context.get("runtime")
        if (context.get("session") != self._b4_session or runtime is None
                or runtime.match_id != self._b4_session.match_id
                or not context.get("lifecycle_valid")):
            self._stop_b4("B4_SESSION_CHANGED_OR_TERMINAL")
        elif self._accepted and context.get("local_actor") != self._accepted[0].action_id.local_actor:
            self._stop_b4("B4_LOCAL_ACTOR_CHANGED")

    def invalidate(self, reason: str) -> None:
        if self._b4_session is not None and not self.completed_successfully:
            self._stop_b4(f"B4_SESSION_INVALIDATED:{reason}")
        super().invalidate(reason)

    def stop(self, reason: str) -> None:
        if not self.done:
            self._stop_b4(f"B4_INCOMPLETE:{reason}")
        super().stop(reason)

    def inactive(self, session: Any) -> None:
        # Called only after a proven null ActiveDotSkillCard singleton. Never
        # substitute a failed/torn read or an old completed snapshot for this edge.
        context = self._latest_context or {}
        sampled = context.get("sampled_monotonic")
        now = time.monotonic()
        if (len(self._accepted) == 1 and session == self._b4_session
                and context.get("session") == session
                and self._accepted_at is not None
                and isinstance(sampled, (float, int)) and math.isfinite(sampled)
                and self._accepted_at < sampled <= now
                and now - sampled <= .35):
            if self._inactive_after_result is None and self._emit is not None:
                self._emit("pet_skill_b4_inactive_edge", session=session,
                           sampledMonotonic=sampled, afterAction=self._accepted[0].action_id)
            self._inactive_after_result = sampled
        super().inactive(session)

    def _second_preflight_problem(self, qte: Any, inactive: bool) -> str | None:
        context = self._latest_context or {}
        now = time.monotonic()
        if self._inactive_after_result is None or not inactive or qte is not None:
            return "B4_WAIT_CURRENT_INACTIVE_EDGE"
        sampled = context.get("control_sampled_monotonic")
        if (not isinstance(sampled, (float, int)) or not math.isfinite(sampled)
                or sampled <= self._accepted_at or not 0 <= now - sampled <= .35):
            return "B4_WAIT_FRESH_CONTROL"
        previous = self._accepted[0].action_id
        runtime = context.get("runtime")
        battle = context.get("control_battle")
        if (runtime is None or runtime.turn is None or runtime.turn <= previous.source_turn
                or not runtime.local_username or runtime.current_player != runtime.local_username):
            return "B4_WAIT_LATER_LOCAL_TURN"
        if (battle is None or battle.session_key != self._b4_session
                or battle.match_id != previous.match_id or battle.turn_number != runtime.turn
                or battle.local_actor_number != previous.local_actor):
            return "B4_WAIT_EXACT_CONTROL_OWNER"
        if (battle.is_board_ready is not True or battle.board_current_state != 1
                or any(getattr(battle, field) is not False for field in (
                    "is_cascade_running", "board_is_processing_ui", "board_is_resuming",
                    "presentation_busy", "clock_paused", "start_gate_paused",
                    "board_is_game_over", "match_over", "deferred_game_over",
                    "local_has_left_match", "reconnecting", "match_resyncing"))
                or battle.connection_ready is not True or battle.is_local_turn is not True):
            return "B4_WAIT_READY_CONTROL"
        return None

    def _drive(self, qte: Any, *, inactive_qte_proven: bool) -> None:
        if self.done or self._executor is None:
            return
        if len(self._accepted) == 1:
            if self._executor.state in {PetSkillActionState.IDLE, PetSkillActionState.PREFLIGHT}:
                reason = self._second_preflight_problem(qte, inactive_qte_proven)
                if reason is not None:
                    if reason != self._b4_wait_reason and self._emit is not None:
                        self._emit("pet_skill_b4_waiting", reason=reason,
                                   acceptedActions=1, session=self._b4_session,
                                   control=(self._latest_context or {}).get("control_battle"))
                    self._b4_wait_reason = reason
                    return
                self._b4_wait_reason = None
            # Before binding/sending any direction in action 2, independently
            # reject generation/challenge reuse. Equal sequence values or equal
            # timing values may be legitimate; their current ownership may not.
            elif qte is not None and qte.observationally_current:
                old = self._accepted_qtes[0].identity
                identity = qte.identity
                if (identity is None or old is None
                        or identity.session_key != old.session_key
                        or identity.observer_generation <= old.observer_generation
                        or identity.server_challenge_id is None
                        or identity.server_challenge_id <= 0
                        or identity.server_challenge_id == old.server_challenge_id):
                    self._stop_b4("B4_OLD_OR_FOREIGN_QTE_GENERATION")
                    return
        super()._drive(qte, inactive_qte_proven=inactive_qte_proven)
        current = self._executor
        if current is None:
            return
        if self._b4_session is None and current.action_id is not None:
            self._b4_session = current.action_id.session_key
        result = current.result
        if result is None or not result.success:
            return
        # The primitive has already finished. Record it without requiring a
        # server response or board delta; only the *next* action waits for ready.
        if (qte is None or qte.identity is None or qte.identity.server_challenge_id is None
                or qte.identity.server_challenge_id <= 0
                or qte.identity.session_key != self._b4_session):
            self._stop_b4("B4_COMPLETED_QTE_IDENTITY_MISSING")
            return
        self._accepted.append(result)
        self._accepted_qtes.append(qte)
        self._accepted_at = time.monotonic()
        if self._emit is not None:
            self._emit("pet_skill_b4_action_accepted", ordinal=len(self._accepted),
                       action=result, qteIdentity=qte.identity, sequence=qte.sequence,
                       perfectWindow=(qte.perfect_start, qte.perfect_end))
        print(f"B4 PERFECT {len(self._accepted)}/2", flush=True)
        if len(self._accepted) == 2:
            return
        if self._executor_factory is None:
            self._stop_b4("B4_EXECUTOR_FACTORY_UNAVAILABLE")
            return
        # Keep the SAME observer/tracker in run_observer; only replace this
        # completed one-action executor. Never reset the tracker to generation 1.
        self._executor = self._executor_factory()
        self._invocation_consumed = False
        self._last_event_count = 0
        self._result_emitted = False
        self._last_wait_reason = None
        self._last_observation = None
        self._post_state_not_before = None
        self._inactive_sessions.clear()
        self._inactive_after_result = None
