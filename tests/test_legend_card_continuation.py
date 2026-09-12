from __future__ import annotations

from dataclasses import replace
from pathlib import Path
from types import SimpleNamespace
import sys
import unittest
from unittest.mock import Mock, patch


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.legend_card_continuation import (
    LegendContinuationVerdict,
    classify_legend_card_continuation,
)
from pokiguard_v2.combat_lifecycle import (
    CombatLifecycleObservation,
    CombatLifecycleSignals,
    CombatLifecycleState,
)
from pokiguard_v2.memory_board_provider import ProviderPoll
from pokiguard_v2.pet_skill_action import PetSkillActionState
from pokiguard_v2.pet_skill_shadow import QteTimingResult
from pokiguard_v2.state import BattleState
from tools.legend_card_continuation_audit import Phase3c0RuntimeHook
from tools.pet_skill_action import build_parser
from tools.pet_qte_observer import _poll_provider
from tests.test_actionability import actionable_state
from tests.test_pet_skill_action import (
    BINDING,
    SESSION_A,
    capability,
    card,
    executor,
    geometry,
    qte,
)


def continuation_state(*, legend: bool, other_modal: bool = False, turn: int = 11):
    state = actionable_state()
    return replace(
        state,
        battle=replace(
            state.battle,
            session_key=SESSION_A,
            board_instance=SESSION_A.board_instance,
            match_id=SESSION_A.match_id,
            turn_number=turn,
            board_modal_open=bool(legend or other_modal),
            board_is_using_legend_card=legend,
            board_is_using_mega=other_modal,
            board_is_mega1_panel_open=False,
            board_is_mega2_panel_open=False,
        ),
    )


class LegendContinuationClassifierTests(unittest.TestCase):
    def test_latched_legend_isolated_as_only_normal_gate_blocker(self):
        sample = classify_legend_card_continuation(
            continuation_state(legend=True),
            expected_session=SESSION_A,
            source_turn=11,
        )
        self.assertEqual(
            sample.verdict,
            LegendContinuationVerdict.SAME_TURN_BLOCKED_ONLY_BY_LEGEND_LATCH,
        )
        self.assertTrue(sample.conclusive_same_turn)
        self.assertEqual(sample.actual_gate_reason.value, "MODAL_OPEN")
        self.assertEqual(sample.without_legend_gate_reason.value, "PASS")

    def test_cleared_legend_and_ready_board_are_actionable(self):
        sample = classify_legend_card_continuation(
            continuation_state(legend=False),
            expected_session=SESSION_A,
            source_turn=11,
        )
        self.assertEqual(
            sample.verdict, LegendContinuationVerdict.SAME_TURN_ACTIONABLE
        )

    def test_another_modal_is_never_blames_on_legend(self):
        sample = classify_legend_card_continuation(
            continuation_state(legend=True, other_modal=True),
            expected_session=SESSION_A,
            source_turn=11,
        )
        self.assertEqual(
            sample.verdict,
            LegendContinuationVerdict.WAITING_FOR_CURRENT_STATE,
        )
        self.assertEqual(sample.without_legend_gate_reason.value, "MODAL_OPEN")

    def test_boss_turn_waits_for_next_local_turn(self):
        state = continuation_state(legend=True, turn=12)
        state = replace(
            state,
            battle=replace(
                state.battle,
                is_local_turn=False,
                current_turn_player="boss",
            ),
        )
        sample = classify_legend_card_continuation(
            state,
            expected_session=SESSION_A,
            source_turn=11,
        )
        self.assertEqual(
            sample.verdict,
            LegendContinuationVerdict.WAITING_FOR_NEXT_LOCAL_TURN,
        )
        self.assertFalse(sample.conclusive_same_turn)
        self.assertFalse(sample.conclusive_continuation)

    def test_next_local_turn_with_cleared_legend_is_actionable(self):
        sample = classify_legend_card_continuation(
            continuation_state(legend=False, turn=13),
            expected_session=SESSION_A,
            source_turn=11,
        )

        self.assertEqual(
            sample.verdict,
            LegendContinuationVerdict.NEXT_LOCAL_TURN_ACTIONABLE,
        )
        self.assertTrue(sample.conclusive_continuation)

    def test_next_local_turn_can_isolate_legend_latch(self):
        sample = classify_legend_card_continuation(
            continuation_state(legend=True, turn=13),
            expected_session=SESSION_A,
            source_turn=11,
        )

        self.assertEqual(
            sample.verdict,
            LegendContinuationVerdict.NEXT_LOCAL_TURN_BLOCKED_ONLY_BY_LEGEND_LATCH,
        )
        self.assertTrue(sample.conclusive_continuation)

    def test_unknown_exact_modal_signal_waits_fail_closed(self):
        state = continuation_state(legend=True)
        state = replace(
            state,
            battle=replace(state.battle, board_is_mega1_panel_open=None),
        )
        sample = classify_legend_card_continuation(
            state,
            expected_session=SESSION_A,
            source_turn=11,
        )
        self.assertEqual(
            sample.verdict,
            LegendContinuationVerdict.WAITING_FOR_CURRENT_STATE,
        )


class Phase3c0RuntimeHookTests(unittest.TestCase):
    def setUp(self):
        self.now = 10.0
        self.events = []
        self.hook = Phase3c0RuntimeHook(
            direction_ack_timeout_seconds=1.25,
            qte_generation_timeout_seconds=3,
            result_timeout_seconds=5,
            post_state_timeout_seconds=4,
            continuation_timeout_seconds=15,
        )
        action, self.mouse, self.backend = executor()
        self.hook._executor = action
        self.hook._backend = self.backend
        self.hook._binding = BINDING
        self.hook._target = SimpleNamespace(is_running=lambda: True)
        self.hook._geometry_proof = lambda *_: geometry()
        self.hook._emit = lambda event, **fields: self.events.append((event, fields))
        for target in (
            "tools.pet_skill_action.time.monotonic",
            "tools.legend_card_continuation_audit.time.monotonic",
        ):
            clock = patch(target, side_effect=lambda: self.now)
            clock.start()
            self.addCleanup(clock.stop)

    def context(self, *, state=None, fresh=False):
        battle = BattleState(
            session_key=SESSION_A,
            match_id=SESSION_A.match_id,
            board_instance=SESSION_A.board_instance,
            turn_number=11,
            local_actor_number=1,
            is_local_turn=True,
            is_board_ready=True,
            board_current_state=1,
            is_cascade_running=False,
            board_is_processing_ui=False,
            board_is_using_legend_card=True,
            board_is_using_mega=False,
            board_is_mega1_panel_open=False,
            board_is_mega2_panel_open=False,
        )
        self.hook.runtime_context(
            sampled_monotonic=self.now,
            control_sampled_monotonic=self.now,
            game_state_sampled_monotonic=(self.now if fresh else None),
            provider_state_fresh=fresh,
            provider_reason="test",
            session=SESSION_A,
            runtime=SimpleNamespace(
                match_id=SESSION_A.match_id,
                turn=11,
                local_username="local",
                current_player="local",
            ),
            local_actor=1,
            lifecycle_valid=True,
            control_battle=battle,
            game_state=state,
            resources={"mana": 300, "power": 250},
            capability=capability(),
            live_cards=(card(),),
        )

    def drive(self, value=None):
        self.now += 0.05
        self.context()
        if value is None:
            self.hook.inactive(SESSION_A)
        else:
            self.hook.snapshot(value, lifecycle_valid=True)

    def sample(self, *, index, elapsed, complete=False):
        value = qte(
            index=index,
            elapsed=elapsed,
            completed=complete,
            active=not complete,
            runtime=QteTimingResult.PERFECT if complete else None,
            predicted=QteTimingResult.PERFECT if complete else None,
        )
        return replace(
            value,
            identity=replace(value.identity, server_challenge_id=101),
        )

    def finish_skill(self):
        self.drive()
        self.drive()
        self.assertEqual(
            self.hook._executor.state, PetSkillActionState.WAIT_QTE_GENERATION
        )
        for index, elapsed in ((0, 0.2), (0, 0.25), (1, 0.3), (1, 0.35), (2, 0.4)):
            self.drive(self.sample(index=index, elapsed=elapsed))
        self.drive(self.sample(index=2, elapsed=3.15))
        self.drive(self.sample(index=2, elapsed=3.16, complete=True))

    def test_keeps_observer_alive_then_stops_on_latch_only_proof(self):
        self.finish_skill()
        self.assertFalse(self.hook.done)
        self.assertEqual(len(self.mouse.points), 1)
        self.assertEqual(self.backend.keys[-1], 0x20)
        input_counts = (len(self.mouse.points), len(self.backend.keys))

        self.now += 0.1
        self.context(state=continuation_state(legend=True), fresh=True)
        self.hook.inactive(SESSION_A)

        self.assertTrue(self.hook.done)
        self.assertTrue(self.hook.completed_successfully)
        self.assertEqual(
            self.hook.summary["reason"],
            "SAME_TURN_BLOCKED_ONLY_BY_LEGEND_LATCH",
        )
        self.assertEqual(
            input_counts, (len(self.mouse.points), len(self.backend.keys))
        )
        self.assertEqual(self.hook.summary["postPerfectGameplayInput"], 0)

    def test_hook_keeps_observing_through_boss_turn(self):
        self.finish_skill()
        self.now += 0.1
        boss_turn = continuation_state(legend=True, turn=12)
        boss_turn = replace(
            boss_turn,
            battle=replace(
                boss_turn.battle,
                is_local_turn=False,
                current_turn_player="boss",
            ),
        )

        self.context(state=boss_turn, fresh=True)
        self.hook.inactive(SESSION_A)

        self.assertFalse(self.hook.done)
        self.assertEqual(
            self.hook.summary["sample"].verdict,
            LegendContinuationVerdict.WAITING_FOR_NEXT_LOCAL_TURN,
        )

    def test_post_perfect_control_gap_is_retained_without_input(self):
        self.finish_skill()
        self.assertEqual(self.hook.continuation_audit_session, SESSION_A)
        input_counts = (len(self.mouse.points), len(self.backend.keys))

        self.now += 0.25
        retained = self.hook.retain_post_perfect_after_control_read_failure(
            "qte_control_rejected:QTE current owner unavailable"
        )

        self.assertTrue(retained)
        self.assertFalse(self.hook.done)
        self.assertEqual(
            input_counts, (len(self.mouse.points), len(self.backend.keys))
        )
        self.assertEqual(
            self.events[-1][0],
            "legend_card_post_perfect_ownership_gap_retained",
        )

    def test_post_perfect_control_gap_times_out_fail_closed(self):
        self.finish_skill()
        self.now += 15.1

        retained = self.hook.retain_post_perfect_after_control_read_failure(
            "qte_control_rejected:QTE current owner unavailable"
        )

        self.assertTrue(retained)
        self.assertTrue(self.hook.done)
        self.assertFalse(self.hook.completed_successfully)
        self.assertEqual(
            self.hook.summary["reason"], "POST_PERFECT_CURRENT_STATE_TIMEOUT"
        )

    def test_continuation_route_checks_control_before_full_board(self):
        self.finish_skill()
        provider = SimpleNamespace()
        provider.poll_qte_control = Mock(
            return_value=SimpleNamespace(
                control_battle=None,
                reason="qte_control_rejected:QTE current owner unavailable",
            )
        )
        provider.poll = Mock()

        result, critical = _poll_provider(provider, self.hook)

        self.assertFalse(critical)
        self.assertIsNone(result.control_battle)
        provider.poll_qte_control.assert_called_once_with(SESSION_A)
        provider.poll.assert_not_called()

    def test_continuation_route_publishes_full_board_after_control_recovers(self):
        self.finish_skill()
        order = []
        lifecycle = CombatLifecycleObservation(
            CombatLifecycleState.ACTIVE,
            CombatLifecycleSignals(
                board_instance=SESSION_A.board_instance,
                match_id=SESSION_A.match_id,
            ),
            "test",
        )
        control = ProviderPoll(
            None,
            False,
            "qte_control_only",
            session_key=SESSION_A,
            combat_lifecycle=lifecycle,
            control_battle=BattleState(
                session_key=SESSION_A,
                board_instance=SESSION_A.board_instance,
                match_id=SESSION_A.match_id,
            ),
        )
        full = ProviderPoll(
            continuation_state(legend=False),
            True,
            "stable",
            session_key=SESSION_A,
            combat_lifecycle=lifecycle,
        )
        provider = SimpleNamespace(
            poll_qte_control=Mock(
                side_effect=lambda session: order.append("control") or control
            ),
            poll=Mock(side_effect=lambda: order.append("full") or full),
        )

        result, critical = _poll_provider(provider, self.hook)

        self.assertFalse(critical)
        self.assertEqual(order, ["control", "full"])
        self.assertIs(result.state, full.state)
        self.assertIs(result.control_battle, control.control_battle)
        self.assertEqual(result.session_key, SESSION_A)


class Phase3c0CliTests(unittest.TestCase):
    def test_c0_is_explicit_and_mutually_exclusive(self):
        args = build_parser().parse_args(["--c0-continuation-audit"])
        self.assertTrue(args.c0_continuation_audit)
        self.assertEqual(args.continuation_timeout, 60.0)
        with self.assertRaises(SystemExit):
            build_parser().parse_args(
                ["--execute-once", "--c0-continuation-audit"]
            )


if __name__ == "__main__":
    unittest.main()
