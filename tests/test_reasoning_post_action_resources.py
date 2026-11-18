"""Known gain exposure is conditional, never a prediction of the net balance."""
from dataclasses import replace
import json
from pathlib import Path
import unittest

from pokiguard_v2.reasoning_common_tactics import evaluate_context
from pokiguard_v2.reasoning_common_planner import _features,_score,_root_step,Work,CommonLimits,CommonDecision
from pokiguard_v2.reasoning_common_problem import CommonProblem,PROFILES
from pokiguard_v2.reasoning_snapshot import FrozenJSON
from pokiguard_v2.board_simulator import SimulatedCell,SwapMove
from pokiguard_v2.reasoning_runner import _decision_summary
from pokiguard_v2.state import GemType
from tests.test_reasoning_strategy_intent import context,step
from tests.test_reasoning_drain_resources import changed

FIXTURE=Path(__file__).parent/'fixtures/reasoning_post_action_resources_20261118.json'


def score(value,root,replies):
    f,w,d=_features(value,root,replies,0)
    return _score(value,root,f,w,d),d


class PostActionResourceTests(unittest.TestCase):
    def test_empty_mana_before_gain_does_not_certify_an_empty_drain_target(self):
        for profile in sorted(PROFILES):
            value=changed(context(profile),own=dict(mana=0,rage=0),boss=dict(hp=200000))
            result,details=score(value,step(value,mana=3),[step(value,drain=3)])
            bound=dict(result.features)['T']
            with self.subTest(profile=profile):
                self.assertEqual(0,bound.low);self.assertGreater(bound.high,0)
                sensitivity=details['tactical_context']['boss_reply_sensitivity']
                self.assertTrue(sensitivity['resource_sensitive'])
                self.assertFalse(sensitivity['policy_sensitive'])

    def test_nonattacking_rage_gain_is_valued_up_to_the_setting_reference(self):
        value=changed(context(),own=dict(mana=0,rage=20),settings=dict(rage_target=100))
        result,d=score(value,step(value,rage=3),[step(value,drain=3)])
        exp=d['tactical_context']['drain_resources']
        self.assertEqual(.2,exp['self_exposed']['rage'])
        self.assertEqual(.8,exp['self_after_known_gain_exposed']['rage'])
        self.assertGreater(dict(result.features)['T'].high,dict(result.features)['T'].low)

    def test_gain_is_capped_at_capacity_not_unbounded_or_credited_twice(self):
        value=changed(context(),own=dict(mana=280,max_mana=300,rage=0))
        _,d=score(value,step(value,mana=3),[step(value,drain=3)])
        item=d['tactical_context']['drain_resources']['known_gain_context']['gains']['mana']
        self.assertEqual(300,item['conditional_gross_balance'])
        self.assertEqual(280,item['balance_before'])
        saturated=changed(value,own=dict(mana=300))
        result,d=score(saturated,step(saturated,mana=3),[step(saturated,drain=3)])
        self.assertEqual(dict(result.features)['T'].low,dict(result.features)['T'].high)
        self.assertFalse(d['tactical_context']['boss_reply_sensitivity']['resource_sensitive'])

    def test_no_gain_and_pass_do_not_synthesize_resource_growth(self):
        value=changed(context(),own=dict(mana=0,rage=0))
        for root in (step(value,health=3),step(value,family='pass')):
            result,d=score(value,root,[step(value,drain=3)])
            self.assertEqual(0,dict(result.features)['T'].high)
            self.assertEqual(d['tactical_context']['drain_resources']['self_exposed'],
                d['tactical_context']['drain_resources']['self_after_known_gain_exposed'])

    def test_attack_does_not_invent_stored_rage_from_its_gross_gain(self):
        value=changed(context('demon_aegis_farm'),own=dict(mana=0,rage=40))
        _,d=score(value,step(value,sword=4,rage=5),[step(value,drain=3)])
        exp=d['tactical_context']['drain_resources']
        self.assertEqual(.4,exp['self_after_known_gain_exposed']['rage'])
        self.assertEqual('ATTACK_RAGE_SPEND_ORDER_UNKNOWN_KEEP_REFERENCE',
            exp['known_gain_context']['gains']['rage']['status'])
        self.assertIn('ATTACK_RAGE_SPEND_ORDER',exp['known_gain_context']['unmodeled'])

    def test_skill_cost_and_gain_order_remain_unmodeled(self):
        value=context('mega_icarus_spam_skill')
        root=step(value,family='pet_skill',mana=8,rage=5,mana_cost=200,rage_cost=100)
        _,d=score(value,root,[step(value,drain=3)])
        exp=d['tactical_context']['drain_resources']
        self.assertEqual(exp['self_exposed'],exp['self_after_known_gain_exposed'])
        self.assertEqual('SKILL_POST_BALANCE_UNMODELED',exp['known_gain_context']['status'])
        self.assertFalse(exp['known_gain_context']['net_balance_prediction'])

    def test_unknown_gain_conversion_is_unknown_risk_not_a_zero_gain_claim(self):
        value=changed(context(),own=dict(mana=0,rage=0))
        facts=value.facts.plain();facts['conversion']={}
        value=replace(value,facts=FrozenJSON.of(facts))
        result,d=score(value,step(value,mana=3),[step(value,drain=3)])
        self.assertEqual('UNSUPPORTED',dict(result.features)['T'].status)
        self.assertIn('DRAIN_BALANCE_UNKNOWN_SELF_MANA',d['unknown_effects'])
        no_drain,d=score(value,step(value,mana=3),[])
        self.assertNotIn('T',d['unknown_features'])

    def test_transfer_and_refill_are_named_and_not_invented(self):
        value=changed(context(),own=dict(mana=0,rage=0))
        root=step(value,mana=3,drain=4)
        root=replace(root,after=((SimulatedCell(GemType.UNKNOWN,None),*root.after[0][1:]),*root.after[1:]))
        _,d=score(value,root,[step(value,drain=3)])
        scope=d['tactical_context']['drain_resources']['known_gain_context']
        self.assertEqual(90,scope['gains']['mana']['conditional_gross_balance'])
        self.assertIn('TRANSFER_AMOUNT_AND_ORDER',scope['unmodeled'])
        self.assertIn('REFILL_AND_FURTHER_CASCADES',scope['unmodeled'])
        self.assertFalse(scope['net_balance_prediction'])

    def test_reply_order_keeps_one_complete_scenario_and_unchanged_bounds(self):
        from pokiguard_v2.reasoning_snapshot import Action
        value=changed(context(),own=dict(mana=0,rage=0))
        root=step(value,mana=3)
        a=replace(step(value,drain=4),action=Action('swap',SwapMove((0,0),(0,1))))
        b=replace(step(value,health=3),action=Action('swap',SwapMove((1,0),(1,1))))
        first,d=score(value,root,[a,b]);second,_=score(value,root,[b,a])
        self.assertEqual(dict(first.features)['T'],dict(second.features)['T'])
        upper=d['tactical_context']['boss_reply_sensitivity']['alternative_proxy']
        singles=[score(value,root,[r])[1]['tactical_context']['boss_reply_sensitivity']['alternative_proxy'] for r in (a,b)]
        self.assertIn(upper,singles)

    def test_worker_summary_keeps_conditional_resource_scope_in_budget(self):
        value=changed(context(),own=dict(mana=0,rage=0))
        root=step(value,mana=3);candidate,_=score(value,root,[step(value,drain=3)])
        result=CommonDecision(value.snapshot_id,value.intent.config_hash,value.baseline,'RETAIN_BASELINE',
            'TEST_POST_GAIN',None,(candidate,),FrozenJSON.of(dict(stage='ONE_STEP_COMPLETE')))
        summary=_decision_summary(value,result,None)
        saved=summary['candidates'][0]['tactical_context']['drain_resources']['known_gain_context']
        self.assertFalse(saved['net_balance_prediction'])
        self.assertLessEqual(len(json.dumps(summary,separators=(',',':')).encode()),12000)
        self.assertFalse(summary['worker_input_sent'])

    def test_native_ordinary_gain_and_attack_uncertainty_stay_separate(self):
        data=json.loads(FIXTURE.read_text(encoding='utf-8'))
        for case in data['cases']:
            value=CommonProblem.from_dict(case['problem'])
            grid=tuple(tuple(SimulatedCell(GemType(g),m) for g,m in row) for row in value.board)
            root=_root_step(value,grid,SwapMove(*(tuple(p) for p in case['sent_move'])),
                Work(CommonLimits(nodes=50000),lambda:0,lambda:False,None))
            _,d=score(value,root,[])
            info=d['tactical_context']['drain_resources']['known_gain_context']
            self.assertFalse(info['net_balance_prediction'])
            if case['source_turn']==3:
                self.assertEqual(120,info['gains']['mana']['conditional_gross_balance'])
                self.assertEqual(120,case['retrospective']['mana_after'])
            if case['source_turn']==5:
                self.assertIn('ATTACK_RAGE_SPEND_ORDER',info['unmodeled'])
            if case['source_turn']==11:
                self.assertIn('TRANSFER_AMOUNT_AND_ORDER',info['unmodeled'])
                self.assertEqual(412,info['gains']['mana']['conditional_gross_balance'])
                self.assertNotEqual(412,case['retrospective']['mana_after'])


if __name__=='__main__':unittest.main()
