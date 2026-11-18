"""Recorded future coverage, conservative intervals and real worker validation.

Saved inputs only; native evidence is never loaded as runtime authority.
"""
from dataclasses import replace
import json
from pathlib import Path
import time
import unittest
from unittest.mock import patch

from pokiguard_v2 import reasoning_common_planner as planner
from pokiguard_v2.reasoning_common_problem import CommonProblem
from pokiguard_v2.reasoning_snapshot import Action
from pokiguard_v2.board_simulator import SwapMove


FIXTURE=Path(__file__).parent/'fixtures/reasoning_bounded_future_20261118.json'


def recorded(index):
    row=json.loads(FIXTURE.read_text(encoding='utf-8'))['cases'][index]
    value=CommonProblem.from_dict(row['problem'])
    assert value.snapshot_id==row['snapshot_id']
    return value


class BoundedFutureTests(unittest.TestCase):
    def test_unresolved_refill_does_not_discard_other_completed_branches(self):
        expected=(SwapMove((3,5),(4,5)),SwapMove((0,2),(1,2)))
        for index,move in enumerate(expected):
            with self.subTest(index=index):
                value=recorded(index);result=planner.plan_common(value,clock=lambda:0)
                self.assertEqual(Action('swap',move),result.proposal or result.baseline)
                diag=result.diagnostics.plain()
                self.assertEqual('LOOKAHEAD_COMPLETE',diag['stage'])
                self.assertEqual(1,diag['lookahead_unknown_roots'])
                unknown=[s for s in result.scores if dict(s.features)['H'].status=='UNSUPPORTED']
                self.assertEqual(1,len(unknown))
                bound=dict(unknown[0].features)['H']
                self.assertEqual((0,.5),(bound.low,bound.high))
                info=unknown[0].details.plain()['lookahead']
                self.assertNotEqual('COMPLETED_ALL_NOMINAL_TIES',info['status'])
                self.assertEqual(0,info['favorable_refill_credit'])
                self.assertTrue(any(s.details.plain()['lookahead']['status']=='COMPLETED_ALL_NOMINAL_TIES'
                    for s in result.scores))
                self.assertFalse(result.to_dict()['input_authority'])

    def test_unknown_incumbent_keeps_its_possible_upside_without_positive_floor(self):
        value=recorded(1);result=planner.plan_common(value,clock=lambda:0)
        self.assertIsNone(result.proposal)
        base=next(s for s in result.scores if s.baseline_member)
        future=dict(base.features)['H']
        self.assertEqual((0,.5,'UNSUPPORTED'),(future.low,future.high,future.status))
        self.assertGreater(dict(base.contributions)['H'].high,0)
        self.assertEqual(0,dict(base.contributions)['H'].low)

    def test_known_mega_setup_can_change_choice_despite_an_unresolved_alternative(self):
        value=recorded(2)
        one=planner.plan_common(value,planner.CommonLimits(lookahead=False),clock=lambda:0)
        self.assertEqual(SwapMove((6,3),(7,3)),one.proposal.move)
        result=planner.plan_common(value,clock=lambda:0)
        self.assertNotEqual(one.proposal,result.proposal)
        chosen=next(s for s in result.scores if s.action==result.proposal)
        base=next(s for s in result.scores if s.baseline_member)
        # This fully covered setup remains valid, but valuing Rage theft can
        # favor another six-Sword move that also takes Drain and Health.
        setup=next(s for s in result.scores if s.action==Action('swap',SwapMove((0,6),(1,6))))
        self.assertEqual((.5,.5),(dict(setup.features)['H'].low,dict(setup.features)['H'].high))
        self.assertGreaterEqual(chosen.utility.low,setup.utility.low)
        info=chosen.details.plain()['lookahead']
        self.assertGreater(dict(chosen.features)['H'].low,0)
        self.assertEqual(dict(chosen.features)['H'].low,dict(chosen.features)['H'].high)
        self.assertEqual(info['nominal_total']+info['alternative_total'],
            info['nominal_examined']+info['alternative_examined'])
        self.assertEqual(0,info['favorable_refill_credit'])
        self.assertEqual(6,chosen.details.plain()['resources']['sword']['effective'])
        self.assertGreaterEqual(chosen.utility.low-base.utility.high,.05)

    def test_entirely_unknown_future_preserves_completed_one_step_comparison(self):
        value=recorded(0)
        one=planner.plan_common(value,planner.CommonLimits(lookahead=False),clock=lambda:0)
        with patch.object(planner,'_setup',return_value=None):
            result=planner.plan_common(value,clock=lambda:0)
        self.assertEqual('ONE_STEP_COMPLETE',result.diagnostics.plain()['stage'])
        self.assertEqual('COMMON_FUTURE_INCOMPLETE_USE_COMPLETED_R1',result.reason)
        self.assertEqual(one.proposal,result.proposal)
        self.assertEqual(one.scores,result.scores)

    def test_node_cap_discards_partial_refinements(self):
        value=recorded(0)
        one=planner.plan_common(value,planner.CommonLimits(lookahead=False),clock=lambda:0)
        limits=planner.CommonLimits(nodes=one.diagnostics.plain()['nodes'])
        result=planner.plan_common(value,limits,clock=lambda:0)
        self.assertEqual('COMMON_LOOKAHEAD_NODE_CAP_USE_COMPLETED_R1',result.reason)
        self.assertEqual(one.proposal,result.proposal)
        self.assertEqual(one.scores,result.scores)

    def test_cancellation_and_deadline_after_a_completed_branch_use_one_step(self):
        value=recorded(0)
        one=planner.plan_common(value,planner.CommonLimits(lookahead=False),clock=lambda:0)
        original=planner._future_setup
        for reason in ('CANCELLED','DEADLINE'):
            with self.subTest(reason=reason):
                finished=[False]
                def future(*args):
                    answer=original(*args);finished[0]=True
                    return answer
                with patch.object(planner,'_future_setup',side_effect=future):
                    result=planner.plan_common(value,
                        clock=lambda:4_000_000_000 if finished[0] and reason=='DEADLINE' else 0,
                        cancelled=lambda:finished[0] and reason=='CANCELLED')
                self.assertEqual('COMMON_LOOKAHEAD_'+reason+'_USE_COMPLETED_R1',result.reason)
                self.assertEqual(one.proposal,result.proposal)
                self.assertEqual(one.scores,result.scores)

    def test_real_worker_host_and_fresh_final_keep_unknown_coverage_honest(self):
        from pokiguard_v2.basic_policy import BasicPolicyEngine
        from pokiguard_v2.reasoning_common_evidence import packet
        from pokiguard_v2.reasoning_common_selection import CommonSelectionBridge,CommonCompleted,CONTEXT
        from pokiguard_v2.reasoning_full_actions import publish_context_safely
        from pokiguard_v2.reasoning_selection import select_safely,revalidate_safely
        from pokiguard_v2.reasoning_runner import REPLY_SCHEMA
        from pokiguard_v2.reasoning_snapshot import canonical_json
        from tests.test_reasoning_common_models import demon_packet
        from tests.test_reasoning_common_selection import admission
        from tests.test_reasoning_pilot import MemorySink

        state,config,_,_,history,*_=demon_packet()
        state=replace(state,board=recorded(0).board_state())
        baseline=BasicPolicyEngine(config).decide(state)
        value=packet(state,config,baseline,None,history,True)
        host=admission(config)
        bridge=CommonSelectionBridge(admission=host,diagnostics=MemorySink(),enabled=True)
        try:
            now=time.perf_counter_ns()
            bridge.observe(state,config,observed_ns=now,read_end_ns=now,context=CONTEXT)
            publish_context_safely(bridge,*value)
            bridge.await_decision(state,baseline,config,context=CONTEXT,stop_requested=lambda:False)
            self.assertIsNotNone(bridge.completed,bridge.preparation_reason)
            completed=bridge.completed
            diag=json.loads(completed.reply.summary_json)['common_diagnostics']
            self.assertEqual(1,diag['lookahead_unknown_roots'])
            selected=select_safely(bridge,state,baseline,config,now_ns=time.perf_counter_ns(),
                input_allowed=True,context=CONTEXT)
            self.assertIsNotNone(selected.receipt)
            self.assertIsNone(revalidate_safely(bridge,selected.receipt,state,baseline,config,
                now_ns=time.perf_counter_ns(),input_allowed=True,context=CONTEXT))
            self.assertIsNone(revalidate_safely(bridge,selected.receipt,state,baseline,config,
                now_ns=time.perf_counter_ns(),input_allowed=True,context=CONTEXT,
                final=True,final_remaining_seconds=14))
            reply=completed.reply;job=completed.job
            raw=dict(schema=REPLY_SCHEMA,job_id=job.job_id,generation=job.generation,
                binding=vars(job.binding),disposition=reply.disposition,reason=reply.reason,
                proposal=None if reply.proposal is None else reply.proposal.to_dict(),compute_ns=reply.compute_ns,
                input_authority=False,r2_promotion=False,summary=json.loads(reply.summary_json))
            raw['summary']['common_diagnostics']['lookahead_unknown_roots']=0
            with self.assertRaisesRegex(ValueError,'coverage'):
                CommonCompleted.prepare(job,canonical_json(raw).encode(),value,host)
        finally:self.assertTrue(bridge.close())
        self.assertEqual(bridge.runner.counters['processes'],bridge.runner.counters['reaped'])


if __name__=='__main__':unittest.main()
