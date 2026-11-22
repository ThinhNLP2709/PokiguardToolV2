"""Counterfactual review preserves common input and explicit unknown effects."""
from copy import deepcopy
import json
from pathlib import Path
import unittest

from pokiguard_v2.reasoning_common_problem import CommonProblem
from tools.compare_same_state_decisions import compare, classify_pair


class SameStateReviewTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.cases=json.loads((Path(__file__).parent/'fixtures/reasoning_same_state_20261119.json').read_bytes())['cases']
        cls.results=[compare(CommonProblem.from_dict(c['problem'])) for c in cls.cases]

    def test_exact_input_and_actions_are_preserved_without_hindsight(self):
        for case,result in zip(self.cases,self.results):
            p=CommonProblem.from_dict(case['problem'])
            self.assertEqual(p.snapshot_id,result['snapshot_id'])
            self.assertEqual(case['baseline'],result['basic']['action'])
            self.assertEqual(case['reasoning'],result['reasoning']['action'])
            self.assertEqual(case['problem'],p.to_dict())
            self.assertFalse(result['observed_future_injected']);self.assertFalse(result['training_eligible'])
            self.assertIsNone(result['quality_label']);self.assertFalse(result['input_authority'])

    def test_offense_and_denial_still_disclose_forgone_healing(self):
        result=self.results[0];a=result['basic'];b=result['reasoning']
        self.assertEqual((3,0),(a['known_reply_sword_max'],b['known_reply_sword_max']))
        self.assertEqual((0,3),(a['known_resources']['sword']['effective'],b['known_resources']['sword']['effective']))
        self.assertEqual((3,0),(a['known_resources']['health']['effective'],b['known_resources']['health']['effective']))
        self.assertEqual('TRADEOFF',result['comparison']['category'])

    def test_more_collection_never_hides_additional_unknown_refill(self):
        result=self.results[1]
        self.assertEqual((3,24),(result['basic']['unresolved_refill_cells'],result['reasoning']['unresolved_refill_cells']))
        self.assertNotEqual('CONDITIONAL_MECHANICAL_ADVANTAGE',result['comparison']['category'])
        self.assertTrue(any(d['dimension']=='unresolved_refill_cells' for d in result['comparison']['costs']))
        self.assertIsNone(result['reasoning']['net_resource_prediction'])

    def test_opaque_different_horizon_and_pending_cascade_cannot_receive_advantage_label(self):
        a=deepcopy(self.results[0]['basic']);b=deepcopy(self.results[0]['reasoning'])
        for key,value in (('coverage','OTHER_HORIZON'),('unresolved_local_effect',True),('status','UNKNOWN')):
            modified=dict(b,**{key:value})
            self.assertEqual('INSUFFICIENT_DATA',classify_pair(a,modified)['category'])


if __name__=='__main__':unittest.main()
