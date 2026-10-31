"""E2 offline target-geometry regression; no native or input capability."""
from dataclasses import replace
import unittest
from unittest.mock import patch

from pokiguard_v2.board_simulator import ResourceResult, ResourceTally, SimulatedCell, SwapMove, evaluate_all_moves
from pokiguard_v2.demon_aegis import evaluate_demon_aegis_move
from pokiguard_v2.reasoning_planner import plan
from pokiguard_v2.reasoning_refinement import Limits, Transition, Work, analyze_root, best_followup, refine
from pokiguard_v2.reasoning_snapshot import Action, FrozenJSON
from pokiguard_v2.state import GemType
from tools.evaluate_reasoning_planner import board_data, snapshot


TARGETS = (GemType.SHIELD, GemType.HEALTH, GemType.MANA, GemType.DRAIN, GemType.RAGE)


def target_snapshot(target):
    board = [[list(cell) for cell in row] for row in board_data()]
    other = 'mana' if target is not GemType.MANA else 'health'
    board[1][0] = [target.value, 1]
    board[1][1] = [target.value, 2]
    board[1][2] = [other, 1]
    board[2][2] = [target.value, 1]
    board[0][0] = ['sword', 2]
    data = tuple(tuple(tuple(cell) for cell in row) for row in board)
    value = snapshot('demon_aegis_farm', board=data,
        baseline=Action('swap', SwapMove((1, 2), (2, 2))), setting=4)
    return replace(value, intent=replace(value.intent,
        settings=FrozenJSON.of(dict(value.intent.settings.plain(), demon_target_gem=target.value))))


class RefinementTargetReliabilityTests(unittest.TestCase):
    def test_all_five_direct_passive_roots_remain_explicitly_unsupported(self):
        for target in TARGETS:
            with self.subTest(target=target):
                value = target_snapshot(target)
                root = next(c for c in plan(value).scores if c.baseline_member)
                result = analyze_root(value, root, Work(Limits(), lambda: 0, lambda: False),
                    True, False, value.evidence('planner.model').value.plain())
                self.assertEqual(result['status'], 'UNSUPPORTED_PASSIVE_ROOT_RESIDUAL')
                self.assertEqual(result['nodes'], 0)
                self.assertFalse(result['completed'])

    def test_followup_geometry_matches_existing_public_evaluator_for_each_target(self):
        for target in TARGETS:
            with self.subTest(target=target):
                value = target_snapshot(target)
                board = tuple(tuple(SimulatedCell(GemType(g), m) for g, m in row)
                              for row in value.board)
                expected = max((evaluate_demon_aegis_move(value.board_state(), move,
                    include_next_turn=False, target_gem=target).sword_cells
                    for move in evaluate_all_moves(value.board_state())), default=0)
                result = best_followup(board, value, value.evidence('planner.model').value.plain(),
                    Work(Limits(), lambda: 0, lambda: False), False)
                self.assertEqual(result['passive_swords_max'], expected)
                self.assertFalse(result['guarantee'])
                self.assertEqual(result['survival'], 'UNMODELED')

    def test_legacy_missing_target_is_exactly_shield(self):
        value = target_snapshot(GemType.SHIELD)
        settings = value.intent.settings.plain()
        settings.pop('demon_target_gem')
        legacy = replace(value, intent=replace(value.intent, settings=FrozenJSON.of(settings)))
        for state in (value, legacy):
            result = refine(state, plan(state), Limits(roots=1), clock=lambda: 0)
            self.assertIsNone(result.diagnostics.plain()['failure'])
            self.assertEqual(result.diagnostics.plain()['analyses'][0]['status'],
                             'UNSUPPORTED_PASSIVE_ROOT_RESIDUAL')
            self.assertTrue(result.incumbent_usable)
            self.assertEqual(result.to_dict()['disposition'], 'RETAIN_COMPLETED_R1')
            self.assertFalse(result.to_dict()['r2_promotion'])

    def test_non_shield_cascade_passive_is_not_given_an_ordinary_residual(self):
        value = target_snapshot(GemType.MANA)
        value = replace(value, intent=replace(value.intent,
            settings=FrozenJSON.of(dict(value.intent.settings.plain(), demon_target_gem='health'))))
        move = next(v.move for v in evaluate_all_moves(value.board_state())
            if not evaluate_demon_aegis_move(value.board_state(), v,
                include_next_turn=False, target_gem=GemType.HEALTH).activates_passive)
        value = replace(value, baseline=Action('swap', move))
        root = next(c for c in plan(value).scores if c.baseline_member)
        board = tuple(tuple(SimulatedCell(GemType(g), m) for g, m in row) for row in value.board)
        # This explicitly supplied transition tests the unsupported-effect
        # boundary; it is not an observed cascade or a new passive world model.
        transition = Transition(root.action.move,
            ResourceResult(((GemType.HEALTH, ResourceTally(3, 3)),)), board, 1)
        with patch('pokiguard_v2.reasoning_refinement.transition', return_value=transition):
            result = analyze_root(value, root, Work(Limits(), lambda: 0, lambda: False),
                True, False, value.evidence('planner.model').value.plain())
        self.assertEqual(result['status'], 'UNSUPPORTED_POSSIBLE_CASCADE_PASSIVE')
        self.assertFalse(result['completed'])


if __name__ == '__main__':
    unittest.main()
