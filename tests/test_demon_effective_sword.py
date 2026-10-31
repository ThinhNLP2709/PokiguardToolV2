"""Weighted BASIC threshold, using the disputed native board and geometry."""
from dataclasses import replace
import json
from pathlib import Path
import unittest

from pokiguard_v2.basic_policy import BasicPolicyEngine, PolicyAction
from pokiguard_v2.board_simulator import simulate_move
from pokiguard_v2.demon_aegis import evaluate_demon_aegis_move, _best_next_activation
from pokiguard_v2.gameplay_profile import DemonTargetGem
from pokiguard_v2.pet_configuration import basic_policy_config
from pokiguard_v2.state import BoardState, CellState, GemType, ParticipantState
from tests.test_basic_policy import combat_state
from tests.test_demon_aegis_farm import passive_board, TARGET_MOVE
from tests.test_demon_target_gem import config, relabel

ROOT=Path(__file__).resolve().parents[1]
EVIDENCE=ROOT/'docs/artifacts/multiplier_b10_review_20261022/evidence.json'


def native(turn):
    evidence=json.loads(EVIDENCE.read_text('utf-8'))
    row=next(r['raw_decision'] for r in evidence['replay'] if r['raw_decision']['turn']==turn)
    board=BoardState(tuple(tuple(CellState(y,x,GemType(g),m) for x,(g,m) in enumerate(line))
        for y,line in enumerate(row['boardSnapshot'])))
    state=combat_state(board=board)
    state=replace(state,player=ParticipantState(**row['player']),
        opponents=(ParticipantState(**row['boss']),))
    return row,state


def decide(board, target=DemonTargetGem.SHIELD, threshold=4):
    c=basic_policy_config(replace(config(target),pet_skill_fire_value=threshold))
    return BasicPolicyEngine(c).decide(combat_state(board=board))


def swords(board, weights):
    points=((0,1),(1,2),(2,3))
    return BoardState(tuple(tuple(replace(cell,
        gem=GemType.SWORD if weights[points.index((y,x))] else GemType.MANA,
        multiplier=weights[points.index((y,x))] or 1) if (y,x) in points else cell
        for x,cell in enumerate(line)) for y,line in enumerate(board.cells)))


class DemonEffectiveSwordTests(unittest.TestCase):
    def test_exact_turn7_now_uses_three_sword_cells_effective_four(self):
        row,state=native(7)
        c=basic_policy_config(replace(config(DemonTargetGem.HEALTH),pet_skill_fire_value=4))
        result=BasicPolicyEngine(c).decide(state)
        self.assertEqual(row['policyStep'],'DEMON_AEGIS_SETUP')
        self.assertEqual((result.action,result.trace.policy_step),(PolicyAction.SWAP,'DEMON_AEGIS_PASSIVE_FIRE'))
        value=simulate_move(state.board,result.move)
        self.assertEqual(value.total.cells(GemType.SWORD),0)
        passive=evaluate_demon_aegis_move(state.board,value,target_gem=GemType.HEALTH,include_next_turn=False)
        self.assertEqual((passive.sword_cells,passive.sword_effective),(3,4))
        self.assertIn('blastSwordEffective=4 >= 4',result.trace.why_selected)

    def test_x2_plus_two_regular_meets_four_for_all_five_targets(self):
        for target in DemonTargetGem:
            board=relabel(swords(passive_board(),(2,1,1)),GemType(target.value))
            result=decide(board,target)
            self.assertEqual(result.trace.policy_step,'DEMON_AEGIS_PASSIVE_FIRE',target)
            passive=evaluate_demon_aegis_move(board,simulate_move(board,result.move),
                target_gem=GemType(target.value),include_next_turn=False)
            self.assertEqual((passive.sword_cells,passive.sword_effective),(3,4))

    def test_x3_plus_one_regular_meets_four_but_three_regular_do_not(self):
        self.assertEqual(decide(swords(passive_board(),(3,1,0))).trace.policy_step,'DEMON_AEGIS_PASSIVE_FIRE')
        self.assertNotEqual(decide(swords(passive_board(),(1,1,1))).trace.policy_step,'DEMON_AEGIS_PASSIVE_FIRE')

    def test_one_high_multiplier_sword_does_not_bypass_two_cell_floor(self):
        for multiplier in (4,7):
            with self.subTest(multiplier=multiplier):
                self.assertNotEqual(decide(swords(passive_board(),(multiplier,0,0))).trace.policy_step,
                    'DEMON_AEGIS_PASSIVE_FIRE')

    def weighted_native(self):
        _,state=native(9)
        board=BoardState(tuple(tuple(replace(c,multiplier=3 if (y,x)==(4,0) else 1)
            if c.gem is GemType.SWORD else c for x,c in enumerate(line))
            for y,line in enumerate(state.board.cells)))
        return board

    def test_fire_ranking_prefers_three_cells_effective_five_over_four_regular(self):
        board=self.weighted_native()
        # The old turn9 selection covers four x1 Swords; another sweep covers
        # three Swords including the x3 at row5/column1, for effective five.
        row,_=native(9)
        from pokiguard_v2.board_simulator import SwapMove
        old_move=SwapMove(tuple(row['move']['first']),tuple(row['move']['second']))
        old=evaluate_demon_aegis_move(board,simulate_move(board,old_move),target_gem=GemType.HEALTH,include_next_turn=False)
        self.assertEqual((old.sword_cells,old.sword_effective),(4,4))
        result=decide(board,DemonTargetGem.HEALTH)
        chosen=evaluate_demon_aegis_move(board,simulate_move(board,result.move),target_gem=GemType.HEALTH,include_next_turn=False)
        self.assertEqual((chosen.sword_cells,chosen.sword_effective),(3,5))

    def test_setup_forecast_uses_same_effective_ranking_and_two_cell_floor(self):
        self.assertEqual(_best_next_activation(self.weighted_native().cells,GemType.HEALTH),(3,5))
        self.assertEqual(_best_next_activation(swords(passive_board(),(7,0,0)).cells,GemType.SHIELD),(0,0))
