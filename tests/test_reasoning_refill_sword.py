"""One-cell refill vulnerability is conditional risk, never favorable credit."""
from copy import deepcopy
from dataclasses import replace
import json
from pathlib import Path
import unittest

from pokiguard_v2.board_simulator import SimulatedCell,SwapMove,_CellValue
from pokiguard_v2.reasoning_common_planner import (
    _refill_sword_hazard,_root_step,_replies,_features,_score,
    CommonLimits,CommonDecision,Work,Exhausted,plan_common)
from pokiguard_v2.reasoning_common_problem import CommonProblem,PROFILES
from pokiguard_v2.reasoning_runner import _decision_summary
from pokiguard_v2.reasoning_snapshot import FrozenJSON
from pokiguard_v2.state import GemType
from tests.test_reasoning_strategy_intent import context

FIXTURE=Path(__file__).parent/'fixtures/reasoning_single_refill_20261119.json'
def work(**kw):return Work(CommonLimits(nodes=50000),kw.get('clock',lambda:0),kw.get('cancelled',lambda:False),None)
def native(index=0):
    c=json.loads(FIXTURE.read_text(encoding='utf-8'))['cases'][index]
    p=CommonProblem.from_dict(c['problem'])
    grid=tuple(tuple(SimulatedCell(GemType(g),m) for g,m in row) for row in p.board)
    root=_root_step(p,grid,SwapMove(*(tuple(v) for v in c['root'])),work())
    replies,_,maximum=_replies(root.after,work(),True)
    return p,root,replies,maximum
def score(p,root,replies,maximum,witness):
    f,w,d=_features(p,root,replies,maximum,witness)
    return _score(p,root,f,w,d)

class SingleRefillSwordTests(unittest.TestCase):
    def test_native_zero_known_sword_does_not_hide_one_cell_completion(self):
        for index in (0,1):
            p,root,replies,maximum=native(index)
            self.assertEqual(0,maximum)
            witness=_refill_sword_hazard(root.after,work())
            self.assertIsNotNone(witness);self.assertEqual(6,witness['effective_swords'])
            a=score(p,root,replies,maximum,None);b=score(p,root,replies,maximum,witness)
            self.assertEqual(dict(a.features)['T'].low,dict(b.features)['T'].low)
            self.assertGreater(dict(b.features)['T'].high,dict(a.features)['T'].high)
            self.assertLess(b.utility.low,a.utility.low);self.assertEqual(b.utility.high,a.utility.high)

    def test_hazard_reuses_existing_solver_without_auto_match_credit(self):
        from pokiguard_v2.board_simulator import _hypothetical_unknown_hazard
        _,root,_,_=native()
        hazard=_refill_sword_hazard(root.after,work())
        board=[[_CellValue(x.gem,x.multiplier) for x in row] for row in root.after]
        sites,units,auto_sites,auto_units=_hypothetical_unknown_hazard(board)
        self.assertEqual((sites,units),(hazard['completion_sites'],hazard['effective_swords']))
        self.assertEqual((auto_sites,auto_units),(hazard['auto_match_sites'],hazard['auto_match_effective_swords']))
        self.assertIsNone(hazard['probability']);self.assertIsNone(hazard['damage'])
        self.assertFalse(hazard['complete_refill'])

    def test_native_safer_sword_move_has_no_single_refill_witness(self):
        _,root,_,maximum=native(2)
        self.assertEqual(0,maximum);self.assertIsNone(_refill_sword_hazard(root.after,work()))

    def test_complete_or_all_unknown_board_cannot_receive_an_invented_witness(self):
        p=context();full=tuple(tuple(SimulatedCell(GemType(g),m) for g,m in row) for row in p.board)
        self.assertIsNone(_refill_sword_hazard(full,work()))
        empty=tuple(tuple(SimulatedCell(GemType.UNKNOWN,None) for _ in range(8)) for _ in range(8))
        self.assertIsNone(_refill_sword_hazard(empty,work()))

    def test_immediate_match_is_not_claimed_as_an_opponent_swap(self):
        grid=[[SimulatedCell(GemType.MANA,1) for _ in range(8)] for _ in range(8)]
        grid[0][0]=grid[0][1]=SimulatedCell(GemType.SWORD,1)
        grid[0][2]=SimulatedCell(GemType.UNKNOWN,None)
        self.assertIsNone(_refill_sword_hazard(tuple(tuple(r) for r in grid),work()))

    def test_search_preserves_input_and_is_bounded_by_existing_cancellation(self):
        _,root,_,_=native();before=deepcopy(root.after)
        _refill_sword_hazard(root.after,work());self.assertEqual(before,root.after)
        with self.assertRaises(Exhausted):_refill_sword_hazard(root.after,work(cancelled=lambda:True))
        with self.assertRaises(Exhausted):_refill_sword_hazard(root.after,work(clock=lambda:10**20))

    def test_risk_only_no_positive_reward_or_input_authority_all_styles(self):
        p,root,replies,maximum=native();witness=_refill_sword_hazard(root.after,work())
        for profile in sorted(PROFILES):
            v=context(profile)
            a=score(v,root,replies,maximum,None);b=score(v,root,replies,maximum,witness)
            for key in ('F','R','D','P','H','B','X','L','E'):
                self.assertEqual(dict(a.features)[key],dict(b.features)[key])
            self.assertLessEqual(b.utility.low,a.utility.low)
            self.assertEqual(b.utility.high,a.utility.high)

    def test_unresolved_local_cascade_keeps_unsupported_risk(self):
        p,root,replies,maximum=native();witness=_refill_sword_hazard(root.after,work())
        root=replace(root,unresolved_residual=True)
        a=score(p,root,replies,maximum,None);b=score(p,root,replies,maximum,witness)
        self.assertEqual(a,b);self.assertEqual('UNSUPPORTED',dict(b.features)['T'].status)

    def test_worker_summary_retains_witness_and_stays_bounded(self):
        p,root,replies,maximum=native();p=replace(p,baseline=root.action)
        candidate=score(p,root,replies,maximum,_refill_sword_hazard(root.after,work()))
        decision=CommonDecision(p.snapshot_id,p.intent.config_hash,p.baseline,'RETAIN_BASELINE',
            'TEST',None,(candidate,),FrozenJSON.of(dict(stage='ONE_STEP_COMPLETE')))
        summary=_decision_summary(p,decision,None)
        self.assertFalse(summary['worker_input_sent'])
        self.assertLessEqual(len(json.dumps(summary,separators=(',',':')).encode()),12000)
        self.assertTrue(any(c.get('tactical_context',{}).get('reply_sensitivity',{}).get('refill_sword_hazard')
            for c in summary['candidates']))

    def test_retention_summary_can_drop_optional_second_candidate_to_fit_budget(self):
        p,_,_,_=native(3);decision=plan_common(p,clock=lambda:0)
        self.assertIsNone(decision.proposal)
        # Stress optional diagnostic content without changing action scores.
        stressed=[]
        for candidate in decision.scores:
            details=candidate.details.plain()
            if not candidate.baseline_member:details['damage_context']={'diagnostic_stress':'x'*12000}
            stressed.append(replace(candidate,details=FrozenJSON.of(details)))
        decision=replace(decision,scores=tuple(stressed))
        summary=_decision_summary(p,decision,None)
        self.assertLessEqual(len(json.dumps(summary,separators=(',',':')).encode()),12000)
        self.assertEqual(1,len(summary['candidates']))
        self.assertEqual(p.candidate_id(p.baseline),summary['candidates'][0]['candidate_id'])
        self.assertGreater(summary['omitted_candidate_summaries'],0)

    def test_large_proposal_summary_preserves_both_required_candidates(self):
        case=json.loads(FIXTURE.read_text(encoding='utf-8'))['cases'][4]
        p=CommonProblem.from_dict(case['problem']);decision=plan_common(p,clock=lambda:0)
        self.assertIsNotNone(decision.proposal)
        summary=_decision_summary(p,decision,None)
        self.assertLessEqual(len(json.dumps(summary,separators=(',',':')).encode()),12000)
        self.assertTrue({p.candidate_id(p.baseline),p.candidate_id(decision.proposal)}
            <={c['candidate_id'] for c in summary['candidates']})

if __name__=='__main__':unittest.main()
