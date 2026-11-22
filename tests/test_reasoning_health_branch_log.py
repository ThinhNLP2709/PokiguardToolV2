"""A compact scorer witness survives alternative-summary omission, not as input."""
from copy import deepcopy
from dataclasses import replace
import json
from pathlib import Path
import threading
import time
import unittest
from unittest.mock import patch

from pokiguard_v2.reasoning_common_problem import CommonProblem
from pokiguard_v2.reasoning_common_planner import plan_common
from pokiguard_v2.reasoning_runner import _decision_summary,_health_prefix_summary,_reply_for,_validate_reply,make_job
from pokiguard_v2.reasoning_snapshot import Action
from tests.test_reasoning_strategy_intent import context

FIXTURE=Path(__file__).parent/'fixtures/reasoning_health_branch_log_20261120.json'

def size(value):return len(json.dumps(value,separators=(',',':')).encode())


class HealthBranchLogTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.fixture=json.loads(FIXTURE.read_bytes())
        cls.problem=CommonProblem.from_dict(cls.fixture['problem'])
        cls.decision=plan_common(cls.problem,clock=lambda:0)

    def baseline_summary(self):
        with patch('pokiguard_v2.reasoning_runner._health_prefix_summary',side_effect=lambda s,*_:s):
            return _decision_summary(self.problem,self.decision,None)

    def minimal(self,proposal=None):
        ids=[self.problem.candidate_id(self.problem.baseline)]
        if proposal is not None:ids.append(self.problem.candidate_id(proposal))
        return dict(baseline_candidate_id=ids[0],proposed_candidate_id=ids[-1] if proposal else None,
            candidates=[dict(candidate_id=cid,keep='mandatory') for cid in ids],omitted_candidate_summaries=0)

    def padded(self,summary,length):
        result=deepcopy(summary);result['padding']=''
        result['padding']='x'*(length-size(result));self.assertEqual(length,size(result))
        return result

    def test_real_frame_keeps_unpublished_candidate_and_exact_bound(self):
        base=self.baseline_summary();before=self.decision.to_dict()
        summary=_decision_summary(self.problem,self.decision,None)
        branch=summary['demon_health_prefix'];sample=branch['sample']
        self.assertEqual(8,summary['evaluated_count']);self.assertEqual(1,branch['scored'])
        self.assertEqual(0,branch['omitted']);self.assertEqual('COLLECTION_PROXY',branch['kind'])
        self.assertEqual(self.fixture['expected_action'],sample['action'])
        self.assertEqual(self.problem.candidate_id(Action.from_dict(sample['action'])),sample['candidate_id'])
        self.assertEqual([self.fixture['expected_p']['low'],1.],sample['p'])
        self.assertEqual(4,sample['health_effective']);self.assertEqual('ALTERNATIVE',sample['role'])
        self.assertNotIn(sample['candidate_id'],{c['candidate_id'] for c in base['candidates']})
        self.assertLessEqual(size(branch),512);self.assertLessEqual(size(summary),12000)
        mandatory={base['baseline_candidate_id'],base['proposed_candidate_id']}-{None}
        self.assertEqual({c['candidate_id']:c for c in base['candidates'] if c['candidate_id'] in mandatory},
            {c['candidate_id']:c for c in summary['candidates'] if c['candidate_id'] in mandatory})
        self.assertEqual(before,self.decision.to_dict())

    def test_no_match_or_other_style_leaves_the_existing_summary_identical(self):
        result=replace(self.decision,scores=tuple(s for s in self.decision.scores
            if dict(s.features)['P'].reason!='DEMON_FIRST_WAVE_HEALTH_OPPORTUNITY'))
        summary=self.minimal();saved=deepcopy(summary)
        self.assertIs(summary,_health_prefix_summary(summary,self.problem,result))
        other=context('simple')
        self.assertIs(summary,_health_prefix_summary(summary,other,self.decision))
        self.assertEqual(saved,summary)

    def test_many_scored_branches_keep_one_sample_and_explicit_omission_count(self):
        template=next(s for s in self.decision.scores if dict(s.features)['P'].reason=='DEMON_FIRST_WAVE_HEALTH_OPPORTUNITY')
        scores=tuple(replace(template,candidate_id=s.candidate_id,action=s.action) for s in self.decision.scores)
        result=replace(self.decision,scores=scores)
        summary=_health_prefix_summary(self.minimal(),self.problem,result)
        branch=summary['demon_health_prefix']
        self.assertEqual(len(scores),branch['scored']);self.assertEqual(len(scores)-1,branch['omitted'])
        self.assertIsInstance(branch['sample'],dict);self.assertLessEqual(size(branch),512)

    def test_optional_alternative_can_be_trimmed_without_touching_base_or_proposal(self):
        alternative=next(s.action for s in self.decision.scores if s.action!=self.problem.baseline)
        result=replace(self.decision,proposal=alternative)
        summary=self.minimal(alternative)
        summary['candidates'].append(dict(candidate_id='optional',padding='x'*1200))
        summary=self.padded(summary,11999);saved=deepcopy(summary)
        changed=_health_prefix_summary(summary,self.problem,result)
        self.assertLessEqual(size(changed),12000);self.assertIsNotNone(changed['demon_health_prefix']['sample'])
        self.assertEqual(saved['candidates'][:2],changed['candidates'])
        self.assertEqual(1,changed['omitted_candidate_summaries']);self.assertEqual(saved,summary)

    def test_count_only_when_mandatory_attribution_leaves_no_room_for_sample(self):
        summary=self.padded(self.minimal(),11900);saved=deepcopy(summary)
        changed=_health_prefix_summary(summary,self.problem,self.decision)
        self.assertEqual(1,changed['demon_health_prefix']['scored'])
        self.assertEqual(1,changed['demon_health_prefix']['omitted'])
        self.assertIsNone(changed['demon_health_prefix']['sample'])
        self.assertEqual(saved['candidates'],changed['candidates']);self.assertLessEqual(size(changed),12000)
        self.assertEqual(saved,summary)

    def test_no_room_or_already_oversize_keeps_original_attribution_and_size(self):
        for n in (11999,12000,12001):
            summary=self.padded(self.minimal(),n);saved=deepcopy(summary)
            changed=_health_prefix_summary(summary,self.problem,self.decision)
            self.assertEqual(saved,changed);self.assertEqual(n,size(changed))
            self.assertNotIn('demon_health_prefix',changed)

    def test_witness_failure_does_not_fail_the_summary(self):
        expected=self.baseline_summary()
        with patch('pokiguard_v2.reasoning_runner._health_prefix_summary',side_effect=RuntimeError('diagnostic fault')):
            actual=_decision_summary(self.problem,self.decision,None)
        self.assertEqual('RuntimeError',actual.pop('demon_health_prefix_error'))
        self.assertEqual(expected,actual)

    def test_worker_roundtrip_keeps_witness_without_action_or_input_authority_change(self):
        job=make_job(self.problem,deadline=time.perf_counter_ns()+4_000_000_000)
        wire=dict(snapshot=self.problem.to_dict(),binding=vars(job.binding),job_id=job.job_id,
            generation=job.generation,refinement=False,budget_ns=4_000_000_000)
        with patch('pokiguard_v2.reasoning_common_planner.plan_common',return_value=self.decision):
            raw=_reply_for(wire,threading.Event())
        reply=_validate_reply(json.dumps(raw,separators=(',',':')).encode(),job)
        self.assertEqual(self.decision.proposal,reply.proposal)
        self.assertEqual(self.decision.reason,reply.reason)
        self.assertEqual(self.fixture['expected_action'],json.loads(reply.summary_json)['demon_health_prefix']['sample']['action'])
        self.assertFalse(raw['input_authority']);self.assertFalse(raw['r2_promotion'])
        self.assertFalse(raw['summary']['worker_input_sent']);self.assertIsNone(raw['summary']['dispatched_candidate_id'])


if __name__=='__main__':unittest.main()
