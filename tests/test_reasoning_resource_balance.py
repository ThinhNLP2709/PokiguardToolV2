"""Resource benefit uncertainty never becomes a future skill/input authority."""
from copy import deepcopy
from dataclasses import replace
import json
from pathlib import Path
import unittest

from pokiguard_v2.reasoning_common_tactics import evaluate_context
from pokiguard_v2.reasoning_common_planner import _features,_score,_root_step,Work,CommonLimits,CommonDecision
from pokiguard_v2.reasoning_common_problem import PROFILES,CommonProblem
from pokiguard_v2.reasoning_snapshot import FrozenJSON
from pokiguard_v2.reasoning_runner import _decision_summary
from pokiguard_v2.board_simulator import SimulatedCell,SwapMove
from pokiguard_v2.state import GemType
from tools.audit_resource_balances import reconcile_resources
from tests.test_reasoning_strategy_intent import context,step
from tests.test_reasoning_drain_resources import changed

FIXTURE=Path(__file__).parent/'fixtures/reasoning_resource_balance_20261119.json'

def score(value,root):
    f,w,d=_features(value,root,[],0)
    return _score(value,root,f,w,d),d


class ResourceBalanceTests(unittest.TestCase):
    def test_attack_rage_keeps_conditional_upside_without_certain_skill_unlock(self):
        for profile in sorted(PROFILES):
            value=changed(context(profile,resource_requirements=dict(mana=100,rage=100)),own=dict(mana=80,rage=80))
            root=step(value,sword=3,mana=1,rage=1)
            candidate,d=score(value,root);bound=dict(candidate.features)['R']
            with self.subTest(profile=profile):
                self.assertLess(bound.low,bound.high)
                self.assertNotEqual('UNSUPPORTED',bound.status)
                readiness=d['tactical_context']['skill_resource_readiness']
                self.assertIsNone(readiness['after']);self.assertEqual(0,readiness['unlock_bonus'])
                self.assertEqual(1,readiness['conditional_gross_after'])
                self.assertGreater(readiness['conditional_unlock_bonus'],0)
                self.assertFalse(d['tactical_context']['resource_stockpile_sensitivity']['net_balance_prediction'])

    def test_no_attack_keeps_existing_two_resource_unlock_and_fixed_benefit(self):
        value=changed(context('skill_rush',resource_requirements=dict(mana=100,rage=100)),own=dict(mana=80,rage=80))
        candidate,d=score(value,step(value,mana=1,rage=1));r=dict(candidate.features)['R']
        self.assertEqual(r.low,r.high)
        self.assertEqual(1,d['tactical_context']['skill_resource_readiness']['after'])
        self.assertGreater(d['tactical_context']['skill_resource_readiness']['unlock_bonus'],0)

    def test_attack_can_spend_existing_rage_even_without_any_rage_gain(self):
        value=changed(context('skill_rush',resource_requirements=dict(mana=100,rage=100)),own=dict(mana=80,rage=120))
        candidate,d=score(value,step(value,sword=3,mana=1))
        self.assertLess(dict(candidate.features)['R'].low,dict(candidate.features)['R'].high)
        self.assertIsNone(d['tactical_context']['skill_resource_readiness']['after'])
        self.assertEqual(0,d['tactical_context']['skill_resource_readiness']['unlock_bonus'])

    def test_mana_only_skill_does_not_require_an_unrelated_rage_balance(self):
        value=changed(context('skill_rush',resource_requirements=dict(mana=100,rage=0)),own=dict(mana=80,rage=80))
        a,d=score(value,step(value,sword=3,mana=1,rage=1))
        self.assertEqual(dict(a.features)['R'].low,dict(a.features)['R'].high)
        self.assertEqual(1,d['tactical_context']['skill_resource_readiness']['after'])
        self.assertGreater(d['tactical_context']['skill_resource_readiness']['unlock_bonus'],0)

    def test_no_bankable_rage_has_no_artificial_penalty_or_extra_interval(self):
        value=changed(context(),own=dict(mana=0,rage=100))
        a,d=score(value,step(value,sword=3,mana=3))
        r=dict(a.features)['R'];self.assertEqual(r.low,r.high);self.assertGreater(r.low,0)
        self.assertFalse(d['tactical_context']['resource_stockpile_sensitivity']['resource_sensitive'])

    def test_evolution_priority_and_same_burst_demon_rage_are_preserved(self):
        from pokiguard_v2.reasoning_common_models import DEMON_RAGE_REFERENCE
        value=changed(context('mega_icarus_spam_skill',evolution=dict(pending=True,mana_cost=240)),own=dict(mana=200,rage=20))
        a,d=score(value,step(value,sword=3,mana=2,rage=3))
        self.assertEqual('EVOLUTION_COST',d['tactical_context']['resource_value']['mana']['goal_origin'])
        self.assertGreater(dict(a.features)['R'].low,0)
        value=changed(context('demon_aegis_farm',demon_strategy=dict(rage_reference=DEMON_RAGE_REFERENCE.plain()),
            operator_demon_rage_discount=1),own=dict(mana=0,rage=20))
        root=replace(step(value,sword=3,rage=4),coverage='CONDITIONAL_PASSIVE_FIRST_WAVE_ONLY',
            passive_swords=3,passive_physical=3,passive_rage=4)
        f,_,d=_features(value,root,[],0)
        self.assertEqual(1,f['F']);self.assertEqual(3,d['nominal_sword_reference'])
        self.assertFalse(d['automatic_kill_claim'])

    def test_missing_conversion_and_unresolved_local_effect_stay_unsupported(self):
        value=changed(context(),own=dict(mana=0,rage=0));facts=value.facts.plain();facts['conversion']={}
        value=replace(value,facts=FrozenJSON.of(facts))
        a,_=score(value,step(value,sword=3,rage=3));self.assertEqual('UNSUPPORTED',dict(a.features)['R'].status)
        value=context();root=replace(step(value,sword=3,rage=3),unresolved_residual=True)
        a,_=score(value,root);self.assertEqual('UNSUPPORTED',dict(a.features)['R'].status)

    def test_skill_and_pass_do_not_gain_a_new_resource_credit(self):
        value=context('mega_icarus_spam_skill',resource_requirements=dict(mana=100,rage=100))
        for root in (step(value,family='pet_skill',mana=5,rage=5,mana_cost=100,rage_cost=100),step(value,family='pass')):
            a,d=score(value,root);self.assertEqual(0,dict(a.features)['R'].low)
            self.assertEqual(0,dict(a.features)['R'].high)
            self.assertFalse(d['tactical_context']['resource_stockpile_sensitivity']['attack_rage_order_unknown'])

    def test_summary_keeps_both_resource_scenarios_without_input_authority(self):
        value=changed(context('skill_rush',resource_requirements=dict(mana=100,rage=100)),own=dict(mana=80,rage=80))
        candidate,_=score(value,step(value,sword=3,mana=1,rage=1))
        result=CommonDecision(value.snapshot_id,value.intent.config_hash,value.baseline,'RETAIN_BASELINE',
            'TEST',None,(candidate,),FrozenJSON.of(dict(stage='ONE_STEP_COMPLETE')))
        summary=_decision_summary(value,result,None);c=summary['candidates'][0]['tactical_context']
        self.assertTrue(c['resource_sensitivity']['resource_sensitive'])
        self.assertIsNone(c['skill_readiness']['after'])
        self.assertLessEqual(len(json.dumps(summary,separators=(',',':')).encode()),12000)
        self.assertFalse(summary['worker_input_sent'])

    def test_native_before_inputs_keep_retrospective_values_out_of_scoring(self):
        fixture=json.loads(FIXTURE.read_text(encoding='utf-8'));sensitive=0;ordinary=0
        for case in fixture['cases']:
            value=CommonProblem.from_dict(case['problem'])
            grid=tuple(tuple(SimulatedCell(GemType(g),m) for g,m in row) for row in value.board)
            root=_root_step(value,grid,SwapMove(*(tuple(v) for v in case['sent_move'])),
                Work(CommonLimits(nodes=50000),lambda:0,lambda:False,None))
            a,d=score(value,root);bound=dict(a.features)['R']
            if root.resources.effective(GemType.SWORD):
                sensitive+=1;self.assertLess(bound.low,bound.high)
            else:
                ordinary+=1;self.assertEqual(bound.low,bound.high)
            changed_case=deepcopy(case);changed_case['retrospective']['observed_after']=dict(mana=99999999,rage=99999999)
            b,_=score(CommonProblem.from_dict(changed_case['problem']),root)
            self.assertEqual(a,b)
        self.assertEqual((3,1),(sensitive,ordinary))


class RetrospectiveResourceLedgerTests(unittest.TestCase):
    def interval(self):return deepcopy(json.loads(FIXTURE.read_text(encoding='utf-8'))['boss_intervals'][0])

    def test_both_sides_of_mana_transfer_match_without_using_raw_after_keys(self):
        i=self.interval();a=reconcile_resources(i['before'],i['after'],i['effects'])
        mana=[r for r in a['resources'] if r['resource']=='MANA']
        self.assertTrue(all(r['status']=='REPORTED_FLOW_RECONCILES' for r in mana))
        self.assertEqual(68,next(r['reported_lost'] for r in mana if r['role']=='LOCAL'))
        for s in i['effects']:s['after']={'MANA':99999999,'POWER':-999999}
        self.assertEqual(a,reconcile_resources(i['before'],i['after'],i['effects']))
        self.assertFalse(a['training_eligible']);self.assertIsNone(a['prediction'])

    def test_extra_rage_is_not_silently_promoted_to_a_turn_tick_formula(self):
        i=self.interval();a=reconcile_resources(i['before'],i['after'],i['effects'])
        power=[r for r in a['resources'] if r['resource']=='POWER']
        self.assertEqual([5,5],[r['unexplained_delta'] for r in power])
        self.assertTrue(all(r['status']=='UNEXPLAINED_CHANGE' for r in power))
        self.assertIn('NOT_A_SERVER_RESOURCE_FORMULA',a['limits'])

    def test_invalid_session_role_capacity_or_step_order_cannot_join(self):
        for field in ('session','role','capacity','order'):
            i=self.interval()
            if field=='session':i['after']['board_instance']+=1
            elif field=='role':i['after']['player']['is_local']=False
            elif field=='capacity':i['after']['player']['max_mana']+=1
            else:i['effects'].reverse()
            with self.subTest(field=field),self.assertRaises(ValueError):
                reconcile_resources(i['before'],i['after'],i['effects'])

    def test_unknown_transfer_type_and_signed_amount_remain_unknown(self):
        for mode in ('type','amount'):
            i=self.interval();s=next(s for s in i['effects'] if s['kind']=='STEAL')
            if mode=='type':s['steal_type']=None
            else:s['amount']=-1
            a=reconcile_resources(i['before'],i['after'],i['effects'])
            self.assertTrue(all(r['unexplained_delta'] is None and r['status']=='UNKNOWN_EFFECT_SEMANTICS' for r in a['resources']))


if __name__=='__main__':unittest.main()
