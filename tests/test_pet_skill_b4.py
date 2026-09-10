from __future__ import annotations

from dataclasses import replace
from types import SimpleNamespace
import unittest
from unittest.mock import patch

from pokiguard_v2.pet_skill_action import PetSkillActionState
from pokiguard_v2.pet_skill_shadow import QteTimingResult, QteDirection
from pokiguard_v2.state import BattleState
from tools.pet_skill_action import build_parser, run
from tools.pet_skill_b4 import Phase3b3B4RuntimeHook
from tests.test_pet_skill_action import (
    SESSION_A, SESSION_B, BINDING, capability, card, geometry, qte, executor,
)


class B4CoordinatorTests(unittest.TestCase):
    def setUp(self):
        self.hook = Phase3b3B4RuntimeHook(direction_ack_timeout_seconds=1.25,
            qte_generation_timeout_seconds=3, result_timeout_seconds=5,
            post_state_timeout_seconds=4)
        self.inputs = []
        self.now = 10.0
        self.turn = 11
        self.context_changes = {}
        self.events = []
        self.hook._emit = lambda event, **fields: self.events.append((event, fields))
        self.hook._executor_factory = self.new_executor
        self.hook._executor = self.new_executor()
        self.hook._binding = BINDING
        self.hook._target = SimpleNamespace(is_running=lambda: True)
        self.hook._geometry_proof = lambda *_: geometry()
        clock = patch("tools.pet_skill_action.time.monotonic", side_effect=lambda: self.now)
        clock.start()
        self.addCleanup(clock.stop)

    def new_executor(self):
        action, mouse, backend = executor()
        action._action_id_factory = lambda: f"action-{len(self.inputs)}"
        self.inputs.append((mouse, backend))
        self.hook._backend = backend
        return action

    def context(self, **changes):
        battle = BattleState(session_key=SESSION_A, match_id="M_A", board_instance=SESSION_A.board_instance,
            turn_number=self.turn, local_actor_number=1, is_local_turn=True,
            is_board_ready=True, board_current_state=1, is_cascade_running=False,
            board_is_processing_ui=False, board_is_resuming=False,
            presentation_busy=False, clock_paused=False, start_gate_paused=False,
            board_is_game_over=False, match_over=False, deferred_game_over=False,
            local_has_left_match=False, reconnecting=False, match_resyncing=False,
            connection_ready=True)
        fields = dict(sampled_monotonic=self.now, control_sampled_monotonic=self.now,
            session=SESSION_A, runtime=SimpleNamespace(match_id="M_A", turn=self.turn,
                local_username="local", current_player="local"),
            local_actor=1, lifecycle_valid=True, control_battle=battle,
            resources={"mana":300,"power":250}, capability=capability(), live_cards=(card(),))
        fields.update(self.context_changes)
        fields.update(changes)
        self.hook.runtime_context(**fields)

    def drive(self, value=None):
        self.now += .05
        self.context()
        if value is None:
            self.hook.inactive(SESSION_A)
        else:
            self.hook.snapshot(value, lifecycle_valid=True)

    def sample(self, generation=1, challenge=101, index=0, elapsed=.2,
               complete=False, window=(3.0,3.3), sequence=None):
        fields = dict(generation=generation, index=index, elapsed=elapsed,
            completed=complete, active=not complete, perfect_start=window[0],
            perfect_end=window[1], runtime=QteTimingResult.PERFECT if complete else None,
            predicted=QteTimingResult.PERFECT if complete else None)
        if sequence is not None:
            fields["sequence"] = sequence
        value = qte(**fields)
        return replace(value, turn_number=self.turn,
            identity=replace(value.identity, turn_number=self.turn,
                             server_challenge_id=challenge))

    def finish(self, generation=1, challenge=101, window=(3.0,3.3), sequence=None):
        self.drive()
        self.drive()
        self.assertEqual(self.hook._executor.state, PetSkillActionState.WAIT_QTE_GENERATION)
        for index, elapsed in ((0,.2),(0,.25),(1,.30),(1,.35),(2,.40)):
            self.drive(self.sample(generation,challenge,index,elapsed,window=window,sequence=sequence))
        self.drive(self.sample(generation,challenge,2,sum(window)/2,window=window,sequence=sequence))
        self.drive(self.sample(generation,challenge,2,sum(window)/2+.01,True,window,sequence))

    def test_two_actions_same_session_new_generation_and_window_then_stop(self):
        self.finish()
        self.assertFalse(self.hook.done)
        self.assertEqual(len(self.hook._accepted), 1)
        first = self.hook._accepted[0]
        self.turn = 13
        second_sequence = (QteDirection.RIGHT, QteDirection.DOWN)
        self.finish(2,102,window=(2.0,2.4),sequence=second_sequence)
        self.assertTrue(self.hook.completed_successfully)
        self.assertEqual(self.hook.summary["acceptedActions"],2)
        self.assertNotEqual(first.action_id.value,self.hook._accepted[1].action_id.value)
        self.assertAlmostEqual(self.hook._accepted[1].telemetry.target_confirm_elapsed,2.2)
        self.assertEqual([len(mouse.points) for mouse,_ in self.inputs],[1,1])
        self.assertEqual(self.inputs[1][1].keys,[0x27,0x28,0x20])
        self.turn = 15
        self.drive()
        self.drive(self.sample(3,103))
        self.assertEqual(len(self.inputs),2)
        self.assertEqual(len(self.hook._accepted),2)

    def test_first_result_is_immediate_no_response_or_post_state_required(self):
        self.finish()
        result = self.hook._accepted[0]
        self.assertTrue(result.success)
        self.assertIsNone(result.post_state)
        self.assertFalse(result.telemetry.server_response_correlated)
        self.assertFalse(self.hook.completed_successfully)
        self.assertIsNone(self.hook.result_wait_session)

    def test_no_second_click_on_old_completed_snapshot_or_same_turn(self):
        self.finish()
        self.drive(self.sample(index=2,elapsed=3.16,complete=True))
        self.drive()
        self.drive()
        self.assertFalse(self.hook.done)
        self.assertEqual(self.inputs[1][0].points,[])
        self.assertEqual(self.hook._b4_wait_reason,"B4_WAIT_LATER_LOCAL_TURN")

    def test_busy_and_unknown_control_delay_second_action(self):
        self.finish()
        self.turn = 13
        self.context()
        base = self.hook._latest_context["control_battle"]
        for field in ("is_cascade_running","board_is_processing_ui","presentation_busy",
                      "clock_paused","board_is_resuming"):
            for value in (True,None):
                self.context_changes = {"control_battle":replace(base, **{field:value})}
                self.drive()
                self.assertEqual(self.inputs[1][0].points,[])
                self.assertEqual(self.hook._b4_wait_reason,"B4_WAIT_READY_CONTROL")
        self.context_changes = {}
        self.drive()
        self.drive()
        self.assertEqual(len(self.inputs[1][0].points),1)

    def test_stale_control_and_no_resource_cannot_authorize_second_click(self):
        self.finish()
        self.turn = 13
        self.context_changes = {"control_sampled_monotonic":self.now-1}
        self.drive()
        self.assertEqual(self.hook._b4_wait_reason,"B4_WAIT_FRESH_CONTROL")
        self.context_changes = {"resources":{"mana":199,"power":250}}
        self.drive()
        self.drive()
        self.assertEqual(self.inputs[1][0].points,[])

    def test_old_generation_or_challenge_blocks_second_directions(self):
        self.finish()
        self.turn = 13
        self.drive()
        self.drive()
        self.drive(self.sample(generation=2,challenge=101))
        self.assertTrue(self.hook.done)
        self.assertFalse(self.hook.completed_successfully)
        self.assertEqual(self.inputs[1][1].keys,[])
        self.assertEqual(len(self.hook._accepted),1)

    def test_old_generation_with_new_challenge_is_also_rejected(self):
        self.finish()
        self.turn = 13
        self.drive()
        self.drive()
        self.drive(self.sample(generation=1,challenge=102))
        self.assertEqual(self.hook._fatal_stop_reason,"B4_OLD_OR_FOREIGN_QTE_GENERATION")
        self.assertEqual(self.inputs[1][1].keys,[])

    def test_second_action_still_requires_inactive_qte_with_ready_card_and_resources(self):
        self.finish()
        self.turn = 13
        self.drive(self.sample(generation=2,challenge=102))
        self.drive(self.sample(generation=2,challenge=102))
        self.assertEqual(self.hook._b4_wait_reason,"B4_WAIT_CURRENT_INACTIVE_EDGE")
        self.assertEqual(self.inputs[1][0].points,[])
        self.assertEqual(self.inputs[1][1].keys,[])

    def test_pending_or_used_this_turn_card_still_blocks_second_click(self):
        self.finish()
        self.turn = 13
        for field in ('action_pending','has_used_this_turn','is_placeholder'):
            self.context_changes = {'live_cards':(replace(card(),**{field:True}),)}
            self.drive()
            self.drive()
            self.assertEqual(self.inputs[1][0].points,[])
        self.context_changes = {}
        self.drive()
        self.drive()
        self.assertEqual(len(self.inputs[1][0].points),1)

    def test_zero_challenge_cannot_authorize_second_directions(self):
        self.finish()
        self.turn = 13
        self.drive()
        self.drive()
        self.drive(self.sample(generation=2,challenge=0))
        self.assertEqual(self.hook._fatal_stop_reason,"B4_OLD_OR_FOREIGN_QTE_GENERATION")
        self.assertEqual(self.inputs[1][1].keys,[])

    def test_equal_sequence_and_window_values_are_valid_with_new_identity(self):
        self.finish()
        self.turn = 13
        self.finish(2,102)
        self.assertTrue(self.hook.completed_successfully)
        self.assertEqual(self.hook._accepted_qtes[0].sequence,self.hook._accepted_qtes[1].sequence)
        self.assertEqual([len(mouse.points) for mouse,_ in self.inputs],[1,1])

    def test_changed_match_stops_and_preserves_first_perfect(self):
        self.finish()
        self.context(session=SESSION_B)
        self.assertTrue(self.hook.done)
        self.assertTrue(self.hook._accepted[0].success)
        self.assertEqual(self.inputs[1][0].points,[])

    def test_terminal_and_stop_between_actions_are_incomplete_not_pass(self):
        self.finish()
        self.hook.invalidate("MATCH_CHANGED")
        self.assertTrue(self.hook.done)
        self.assertFalse(self.hook.completed_successfully)
        self.assertEqual(self.hook.summary["kind"],"B4_INCOMPLETE")
        self.assertEqual(len(self.hook._accepted),1)

    def test_operator_abort_between_actions_stops(self):
        self.finish()
        self.hook.stop("OPERATOR_ABORT")
        self.turn=13
        self.drive()
        self.assertTrue(self.hook.done)
        self.assertEqual(self.inputs[1][0].points,[])

    def test_second_card_unconfirmed_is_not_retried(self):
        self.finish()
        self.turn=13
        self.drive()
        self.drive()
        self.now += 4
        self.drive()
        self.assertTrue(self.hook.done)
        self.assertFalse(self.hook.completed_successfully)
        self.assertEqual([len(mouse.points) for mouse,_ in self.inputs],[1,1])
        self.assertEqual(len(self.hook._accepted),1)


class B4CliTests(unittest.TestCase):
    def test_existing_one_shot_and_b4_are_mutually_exclusive(self):
        args=build_parser().parse_args(["--execute-once"])
        self.assertFalse(args.b4_two_same_match)
        with self.assertRaises(SystemExit):
            build_parser().parse_args(["--execute-once","--b4-two-same-match"])

    def test_b4_requires_lobby(self):
        args=build_parser().parse_args(["--b4-two-same-match","--allow-combat-start"])
        with self.assertRaisesRegex(ValueError,"boss-lobby"):
            run(args)
