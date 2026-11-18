"""Drain must value both Mana and Rage without inventing transfer amounts."""
from dataclasses import replace
import json
from pathlib import Path
import unittest

from pokiguard_v2.reasoning_common_problem import PROFILES
from pokiguard_v2.reasoning_common_tactics import evaluate_context
from pokiguard_v2.reasoning_common_planner import _features, _score
from pokiguard_v2.reasoning_snapshot import FrozenJSON
from tests.test_reasoning_strategy_intent import context, step

FIXTURE=Path(__file__).parent/'fixtures/reasoning_drain_resources_20261118.json'


def changed(value, *, own=None, boss=None, settings=None):
    facts=value.facts.plain()
    facts['self'].update(own or {});facts['opponent'].update(boss or {})
    intent=value.intent
    if settings is not None:
        config=intent.settings.plain();config.update(settings)
        intent=replace(intent,settings=FrozenJSON.of(config))
    return replace(value,facts=FrozenJSON.of(facts),intent=intent)


class DrainResourceTests(unittest.TestCase):
    def test_rage_only_is_exposed_to_boss_drain_in_every_style(self):
        for profile in sorted(PROFILES):
            v=changed(context(profile),own=dict(mana=0,rage=100),boss=dict(hp=200000))
            rich=evaluate_context(v,step(v),[step(v,drain=3)],0)[0]['T']
            empty=changed(v,own=dict(rage=0))
            poor=evaluate_context(empty,step(empty),[step(empty,drain=3)],0)[0]['T']
            with self.subTest(profile=profile):
                self.assertGreater(rich,poor)
                self.assertEqual(0,poor)

    def test_boss_rage_can_make_our_drain_protective_with_zero_boss_mana(self):
        for profile in sorted(PROFILES):
            v=changed(context(profile),boss=dict(mana=0,rage=100))
            rich=evaluate_context(v,step(v,drain=3),[],0)[1]['protection_proxy']['drain']
            empty=changed(v,boss=dict(rage=0))
            poor=evaluate_context(empty,step(empty,drain=3),[],0)[1]['protection_proxy']['drain']
            with self.subTest(profile=profile):self.assertGreater(rich,poor)

    def test_demon_target_does_not_hardcode_the_resource_being_drained(self):
        for target in ('shield','health','mana','drain','rage'):
            v=changed(context('demon_aegis_farm'),own=dict(mana=0,rage=100),
                boss=dict(mana=0,rage=100),settings=dict(demon_target_gem=target))
            f,details,_=evaluate_context(v,step(v,drain=3),[step(v,drain=3)],0)
            with self.subTest(target=target):
                self.assertGreater(f['T'],0);self.assertGreater(details['protection_proxy']['drain'],0)

    def test_full_mana_and_rage_are_one_resource_scenario_not_added_transfers(self):
        v=context()
        both=evaluate_context(v,step(v,drain=3),[step(v,drain=3)],0)
        mono=changed(v,own=dict(rage=0),boss=dict(rage=0))
        mana=evaluate_context(mono,step(mono,drain=3),[step(mono,drain=3)],0)
        self.assertEqual(both[1]['boss_reply_proxy']['drain'],mana[1]['boss_reply_proxy']['drain'])
        self.assertEqual(both[1]['protection_proxy']['drain'],mana[1]['protection_proxy']['drain'])
        d=both[1]['drain_resources']
        self.assertEqual('MAX_SINGLE_RESOURCE_NOT_SIMULTANEOUS_TRANSFERS',d['aggregation'])
        self.assertEqual('UNKNOWN',d['amount_formula']);self.assertEqual('UNKNOWN',d['resource_selection'])
        self.assertEqual('NOT_MODELED',d['hp_steal'])

    def test_mana_only_keeps_previous_structural_formula(self):
        v=changed(context(),own=dict(mana=150,max_mana=300,rage=0),boss=dict(mana=150,max_mana=300,rage=0))
        result=evaluate_context(v,step(v,drain=3),[step(v,drain=3)],0)[1]
        self.assertAlmostEqual(3/8*.5,result['boss_reply_proxy']['drain'])
        self.assertAlmostEqual(3/6*.5*(.35+.65*.5),result['protection_proxy']['drain'])

    def test_unknown_rage_balance_cannot_claim_zero_threat_or_protection(self):
        v=changed(context(),own=dict(mana=0,rage=None),boss=dict(mana=0,rage=None))
        f,w,d=_features(v,step(v,drain=3),[step(v,drain=3)],0)
        score=_score(v,step(v,drain=3),f,w,d)
        for name in ('T','P'):
            bound=dict(score.features)[name]
            self.assertEqual((0,1,'UNSUPPORTED'),(bound.low,bound.high,bound.status))
        no_drain=_features(v,step(v),[],0)
        self.assertNotIn('T',no_drain[2]['unknown_features'])
        self.assertNotIn('P',no_drain[2]['unknown_features'])

    def test_zero_capacity_and_zero_balance_are_known_empty(self):
        v=changed(context(),own=dict(mana=0,max_mana=0,rage=0,max_rage=0),
            boss=dict(mana=0,max_mana=0,rage=0,max_rage=0))
        f,d,unknown=evaluate_context(v,step(v,drain=3),[step(v,drain=3)],0)
        self.assertEqual(0,f['T']);self.assertEqual(0,d['protection_proxy']['drain'])
        self.assertNotIn('P',unknown);self.assertNotIn('T',unknown)

    def test_invalid_or_missing_balance_uses_existing_unknown_bound(self):
        for bad in (None,True,-1,float('nan')):
            # Frozen JSON rejects nonfinite numbers before the adviser sees them.
            if type(bad) is float:continue
            v=changed(context(),own=dict(mana=0,rage=bad))
            f,w,d=_features(v,step(v),[step(v,drain=3)],0)
            self.assertEqual('UNSUPPORTED',dict(_score(v,step(v),f,w,d).features)['T'].status)

    def test_rage_exposure_uses_current_setting_reference_and_capacity(self):
        v=changed(context(),own=dict(mana=0,rage=50,max_rage=250),settings=dict(rage_target=100))
        a=evaluate_context(v,step(v),[step(v,drain=3)],0)[1]['boss_reply_proxy']['drain']
        b=changed(v,settings=dict(rage_target=200))
        self.assertGreater(a,evaluate_context(b,step(b),[step(b,drain=3)],0)[1]['boss_reply_proxy']['drain'])
        small=changed(v,own=dict(max_rage=50))
        self.assertEqual(3/8,evaluate_context(small,step(small),[step(small,drain=3)],0)[1]['boss_reply_proxy']['drain'])

    def test_fewer_swords_can_be_better_when_it_denies_a_drain_of_our_rage(self):
        v=changed(context('careful'),own=dict(mana=0,rage=100))
        many=step(v,sword=5);safer=step(v,sword=4)
        f,w,d=_features(v,many,[step(v,drain=5)],0);a=_score(v,many,f,w,d)
        f,w,d=_features(v,safer,[],0);b=_score(v,safer,f,w,d)
        self.assertGreater(b.utility.low,a.utility.high)

    def test_all_action_families_share_rage_exposure_without_granting_an_action(self):
        v=changed(context('mega_icarus_spam_skill'),own=dict(mana=0,rage=100))
        for family in ('swap','pet_skill','pass'):
            f,d,_=evaluate_context(v,step(v,family=family),[step(v,drain=3)],0)
            with self.subTest(family=family):
                self.assertGreater(f['T'],0)
                self.assertNotIn('input_authority',d)

    def test_native_power_steals_are_not_treated_as_mana_only_exposure(self):
        data=json.loads(FIXTURE.read_text(encoding='utf-8'))
        for case in data['cases']:
            v=changed(context('demon_aegis_farm'),own=case['own'],boss=case['boss'])
            _,d,_=evaluate_context(v,step(v),[step(v,drain=case['known_drain_gems'])],0)
            risk=d['boss_reply_proxy']['drain']
            old=case['known_drain_gems']/8*case['own']['mana']/case['own']['max_mana']
            with self.subTest(match=case['match_id'],turn=case['boss_turn']):
                self.assertGreater(risk,old)
                self.assertEqual('POWER',case['observed_steal_type'])
                self.assertEqual('UNKNOWN',d['drain_resources']['amount_formula'])

    def test_bounded_worker_summary_keeps_the_resource_scope_without_damage_claim(self):
        from pokiguard_v2.reasoning_common_planner import CommonDecision
        from pokiguard_v2.reasoning_runner import _decision_summary
        v=changed(context('careful'),own=dict(mana=0,rage=100),boss=dict(mana=0,rage=100))
        root=step(v,drain=3)
        f,w,d=_features(v,root,[step(v,drain=3)],0);candidate=_score(v,root,f,w,d)
        decision=CommonDecision(v.snapshot_id,v.intent.config_hash,v.baseline,
            'RETAIN_BASELINE','TEST_DRAIN_RESOURCES',None,(candidate,),FrozenJSON.of(dict(stage='ONE_STEP_COMPLETE')))
        summary=_decision_summary(v,decision,None)
        saved=summary['candidates'][0]['tactical_context']['drain_resources']
        self.assertEqual(1,saved['self_exposed']['rage']);self.assertEqual(0,saved['self_exposed']['mana'])
        self.assertEqual('UNKNOWN',saved['amount_formula'])
        self.assertLessEqual(len(json.dumps(summary,separators=(',',':')).encode()),12000)
        self.assertFalse(summary['worker_input_sent'])


if __name__=='__main__':unittest.main()
