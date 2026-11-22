"""Resource evidence must not become a skill permission or server formula."""
from copy import deepcopy
from dataclasses import replace
import json
from pathlib import Path
import tempfile
import unittest

from tests.reasoning_test_paths import reasoning_temp_root
from tests.test_combat_board_evidence import boundary_rows
from tests.test_ordered_resource_evidence import message
from tests.test_combat_outcome_evidence import projected
from tests.test_reasoning_strategy_intent import context
from tests.test_reasoning_drain_resources import changed
from pokiguard_v2.reasoning_common_problem import EffectChoice
from pokiguard_v2.reasoning_snapshot import Action
from tools.audit_ordered_resource_readiness import affordability,audit_interval,audit_file,audit_snapshot


def interval():
    rows=boundary_rows();b=rows[0]['stateEvidence'];a=rows[2]['stateEvidence']
    for s in (b,a):
        s['player'].update(mana=100,max_mana=300,power=80,max_power=250,is_local=True,is_boss=False)
        s['bosses'][0].update(mana=100,max_mana=300,power=100,max_power=250,is_local=False,is_boss=True)
    a['player']['power']=85;a['bosses'][0]['power']=0
    e=projected(message()).to_dict()['evidence']
    obs=dict(e,actor_identity='BOSS',provenance=dict(raw_response_sha256=e['raw_sha256']))
    return b,a,obs


class AffordabilityTests(unittest.TestCase):
    def test_both_resources_are_required_with_exact_boundary_and_zero_cost(self):
        self.assertFalse(affordability(dict(mana=120,rage=100),dict(mana=1000,rage=99))['affordable'])
        self.assertFalse(affordability(dict(mana=120,rage=100),dict(mana=119,rage=250))['affordable'])
        self.assertTrue(affordability(dict(mana=120,rage=100),dict(mana=120,rage=100))['affordable'])
        self.assertTrue(affordability(dict(mana=120,rage=0),dict(mana=120,rage=0))['affordable'])
        self.assertTrue(affordability(dict(mana=0,rage=0),dict(mana=0,rage=0))['affordable'])

    def test_missing_boolean_negative_and_stale_guesses_do_not_become_ready(self):
        for needs,own in (({},dict(mana=200,rage=250)),(dict(mana=100),dict(mana=200,rage=250)),
                (dict(mana=True,rage=0),dict(mana=200,rage=0)),
                (dict(mana=100,rage=-1),dict(mana=200,rage=250)),
                (dict(mana=100,rage=0),dict(mana=None,rage=0))):
            with self.subTest(needs=needs,own=own):self.assertIsNone(affordability(needs,own)['affordable'])

    def test_snapshot_uses_observed_balances_and_does_not_claim_next_turn_permission(self):
        p=changed(context(resource_requirements=dict(mana=120,rage=100)),own=dict(mana=500,rage=90))
        r=audit_snapshot(p)
        self.assertFalse(r['resource_check']['affordable']);self.assertLess(r['readiness_before'],1)
        self.assertIsNone(r['next_turn_skill_usable']);self.assertFalse(r['input_authority'])
        self.assertFalse(r['training_eligible'])

    def test_enough_resources_does_not_override_a_blocked_skill_owner(self):
        p=context(resource_requirements=dict(mana=120,rage=100))
        p=replace(p,effects=(EffectChoice(Action('pet_skill',card_source='SYNTHETIC'),False,
            'SKILL_NOT_ACTIONABLE',None,'UNKNOWN','UNKNOWN',120,100),))
        r=audit_snapshot(p)
        self.assertTrue(r['resource_check']['affordable']);self.assertFalse(r['contradictions'])
        self.assertEqual(0,r['eligible_pet_skill_effects']);self.assertIsNone(r['next_turn_skill_usable'])

    def test_insufficient_eligible_skill_or_conflicting_costs_are_reported(self):
        p=context(resource_requirements=dict(mana=120,rage=100))
        p=replace(p,effects=(EffectChoice(Action('pet_skill',card_source='SYNTHETIC'),True,
            'SYNTHETIC_AVAILABLE',(),'UNCHANGED_BOARD','USER_CALIBRATED',120,200),))
        r=audit_snapshot(p)
        self.assertIn('ELIGIBLE_SKILL_WITH_INSUFFICIENT_ACTUAL_RESOURCES',r['contradictions'])
        self.assertIn('REQUIREMENT_AND_EFFECT_COST_MISMATCH',r['contradictions'])


class OrderedBalanceTests(unittest.TestCase):
    def test_both_participants_have_explicit_order_and_published_endpoint(self):
        b,a,o=interval();r=audit_interval(b,a,o)
        self.assertTrue(all(v['endpoint_status'] in ('LAST_STAT_EQUALS_ENDPOINT','NO_RESOURCE_UPDATE_CAPTURED') for v in r['resources']))
        own=next(v for v in r['resources'] if v['role']=='LOCAL' and v['resource']=='POWER')
        self.assertEqual((80,85,5),(own['before'],own['after'],own['observed_delta']))
        self.assertEqual('EXACT_REPORTED_DELTA',own['checks'][0]['status'])
        self.assertIsNone(r['server_resource_formula']);self.assertFalse(r['input_authority'])

    def test_gain_cap_and_spend_are_not_added_as_gross_balance(self):
        b,a,o=interval();b['player']['power']=175;a['player']['power']=150
        target=b['local_identity']
        o['resource_operations']=[dict(type='STAT_CHANGE',operation_index=i,target=target,stat_type='POWER',
            delta=d,new_value=v,reason=reason,source_label=None) for i,d,v,reason in
            ((1,120,250,None),(2,5,250,None),(3,-100,150,'FULL_POWER'))]
        r=audit_interval(b,a,o);own=next(v for v in r['resources'] if v['role']=='LOCAL' and v['resource']=='POWER')
        self.assertEqual(-25,own['observed_delta']);self.assertEqual(25,own['reported_stat_delta_sum'])
        self.assertEqual(['CAP_OR_FLOOR_PATTERN_OBSERVED']*2+['EXACT_REPORTED_DELTA'],[c['status'] for c in own['checks']])
        self.assertEqual(150,own['last_stat_value'])

    def test_reported_delta_mismatch_or_unknown_is_not_silently_repaired(self):
        b,a,o=interval();o['resource_operations'][0]['delta']=50
        r=audit_interval(b,a,o);own=next(v for v in r['resources'] if v['role']=='LOCAL' and v['resource']=='POWER')
        self.assertEqual('UNEXPLAINED_REPORTED_DELTA',own['checks'][0]['status'])
        o['resource_operations'][0]['delta']=None
        r=audit_interval(b,a,o);own=next(v for v in r['resources'] if v['role']=='LOCAL' and v['resource']=='POWER')
        self.assertIsNone(own['reported_stat_delta_sum']);self.assertEqual('TRACE_FIELD_UNKNOWN',own['endpoint_status'])

    def test_changed_identity_capacity_role_and_order_fail_closed(self):
        for kind in ('epoch','sequence','capacity','role','order'):
            b,a,o=interval()
            if kind=='epoch':a['lifecycle_epoch']+=1
            elif kind=='sequence':o['server_sequence']+=1
            elif kind=='capacity':a['player']['max_power']+=1
            elif kind=='role':a['player']['is_boss']=True
            else:o['resource_operations'][1]['operation_index']=0
            with self.subTest(kind=kind),self.assertRaises(ValueError):audit_interval(b,a,o)

    def test_absent_trace_differs_from_empty_and_steps_are_not_counted_again(self):
        b,a,o=interval();o['resource_operations']=None
        r=audit_interval(b,a,o);self.assertTrue(all(v['endpoint_status']=='TRACE_ABSENT' for v in r['resources']))
        o['resource_operations']=[]
        self.assertFalse(any(v['checks'] for v in audit_interval(b,a,o)['resources']))

    def test_unknown_resource_participant_cannot_look_like_an_unchanged_balance(self):
        b,a,o=interval();o['resource_operations'][0]['target']='sha256:'+'a'*64
        with self.assertRaisesRegex(ValueError,'UNKNOWN_RESOURCE_PARTICIPANT'):audit_interval(b,a,o)

    def test_input_is_immutable_and_published_endpoint_mismatch_is_explicit(self):
        b,a,o=interval();a['player']['power']=90;old=deepcopy((b,a,o))
        r=audit_interval(b,a,o)
        self.assertEqual((b,a,o),old)
        own=next(v for v in r['resources'] if v['role']=='LOCAL' and v['resource']=='POWER')
        self.assertEqual('LAST_STAT_DIFFERS_FROM_ENDPOINT',own['endpoint_status'])

    def test_no_published_boundary_never_synthesizes_net_balance(self):
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as directory:
            path=Path(directory)/'combat.jsonl';rows=boundary_rows()[1:]
            path.write_bytes(('\n'.join(json.dumps(r) for r in rows)+'\n').encode())
            report=audit_file(path)
        self.assertFalse(report['intervals']);self.assertEqual('NO_UNIQUE_PUBLISHED_RESOURCE_BOUNDARIES',report['excluded'][0]['reason'])


if __name__=='__main__':unittest.main()
