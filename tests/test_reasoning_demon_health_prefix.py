"""Known Health collection is useful without claiming net HP or survival."""
from dataclasses import replace
import json
from pathlib import Path
import unittest

from pokiguard_v2.reasoning_common_problem import PROFILES, CommonProblem
from pokiguard_v2.reasoning_common_planner import _root_step, Work, CommonLimits, CommonDecision
from pokiguard_v2.reasoning_snapshot import FrozenJSON
from pokiguard_v2.reasoning_runner import _decision_summary
from pokiguard_v2.board_simulator import SimulatedCell
from pokiguard_v2.state import GemType
from tests.test_reasoning_demon_prefix import prefix, score
from tests.test_reasoning_strategy_intent import context


def wounded(profile='demon_aegis_farm', hp=30):
    value=context(profile)
    facts=value.facts.plain();facts['self'].update(hp=hp,shield=0)
    return replace(value,facts=FrozenJSON.of(facts))


class DemonHealthPrefixTests(unittest.TestCase):
    def test_wounded_sweep_preserves_collection_only_and_all_other_unknowns(self):
        value=wounded();candidate=score(value,prefix(value,sword=3,health=3,rage=5,shield=5,drain=5))
        bounds=dict(candidate.features);p=bounds['P']
        self.assertAlmostEqual(.35,p.low);self.assertEqual(1.,p.high)
        self.assertEqual('DEMON_FIRST_WAVE_HEALTH_OPPORTUNITY',p.reason)
        self.assertEqual('PRESENT',p.status)
        for name in ('R','T','B'):
            self.assertEqual((0,1,'UNSUPPORTED'),(bounds[name].low,bounds[name].high,bounds[name].status))
        self.assertFalse(candidate.details.plain()['automatic_kill_claim'])
        self.assertIsNone(candidate.details.plain()['offensive_opportunity']['estimated_damage'])

    def test_missing_health_collection_and_full_or_unknown_hp_get_no_floor(self):
        for hp,health in ((100,6),(None,6),(30,0)):
            with self.subTest(hp=hp,health=health):
                value=wounded(hp=hp);p=dict(score(value,prefix(value,sword=4,health=health)).features)['P']
                self.assertEqual((0,1,'UNSUPPORTED'),(p.low,p.high,p.status))

    def test_not_a_shield_or_drain_floor_even_when_boss_resources_are_full(self):
        value=wounded()
        for gems in (dict(shield=6),dict(drain=6),dict(shield=6,drain=6)):
            p=dict(score(value,prefix(value,sword=4,**gems)).features)['P']
            self.assertEqual('UNSUPPORTED',p.status);self.assertEqual(0,p.low)

    def test_more_missing_hp_increases_health_opportunity_without_damage_model(self):
        lows=[dict(score(wounded(hp=hp),prefix(wounded(hp=hp),sword=3,health=3)).features)['P'].low
              for hp in (90,60,30,10)]
        self.assertEqual(lows,sorted(lows));self.assertLess(lows[0],lows[-1])

    def test_prefix_is_monotone_for_additional_health_collection_and_saturates(self):
        for hp in (10,30,90):
            value=wounded(hp=hp)
            for known in range(1,17):
                p=dict(score(value,prefix(value,health=known)).features)['P']
                for extra in range(17):
                    opportunity=min(1.,(known+extra)/6)*(1-hp/100)
                    self.assertLessEqual(p.low,opportunity);self.assertGreaterEqual(p.high,opportunity)

    def test_all_five_targets_use_same_health_opportunity(self):
        for target in ('shield','health','mana','drain','rage'):
            value=wounded();settings=value.intent.settings.plain();settings['demon_target_gem']=target
            value=replace(value,intent=replace(value.intent,settings=FrozenJSON.of(settings)))
            self.assertAlmostEqual(.35,dict(score(value,prefix(value,sword=3,health=3)).features)['P'].low)

    def test_other_styles_and_unverified_or_ordinary_geometry_keep_unknown(self):
        for profile in PROFILES-{'demon_aegis_farm'}:
            value=wounded(profile);p=dict(score(value,prefix(value,sword=3,health=3)).features)['P']
            self.assertEqual('UNSUPPORTED',p.status)
        value=wounded()
        for coverage in ('DEMON_PASSIVE_EFFECT_UNKNOWN','EXISTING_SOLVER_KNOWN_CASCADES_NO_REFILL'):
            root=replace(prefix(value,sword=3,health=3),coverage=coverage)
            self.assertEqual('UNSUPPORTED',dict(score(value,root).features)['P'].status)

    def test_native_geometry_and_serialized_summary_keep_the_reason(self):
        fixture=json.loads((Path(__file__).parent/'fixtures/reasoning_demon_prefix_20261119.json').read_bytes())
        found=0
        for case in fixture['cases']:
            value=CommonProblem.from_dict(case['problem'])
            grid=tuple(tuple(SimulatedCell(GemType(g),m) for g,m in row) for row in value.board)
            root=_root_step(value,grid,value.baseline.move,Work(CommonLimits(nodes=50000),lambda:0,lambda:False,None))
            candidate=score(value,root);p=dict(candidate.features)['P']
            if root.resources.effective(GemType.HEALTH) and candidate.details.plain()['tactical_context']['self_hp_fraction']<1:
                self.assertGreater(p.low,0);found+=1
                result=CommonDecision(value.snapshot_id,value.intent.config_hash,value.baseline,'RETAIN_BASELINE',
                    'TEST',None,(candidate,),FrozenJSON.of(dict(stage='ONE_STEP_COMPLETE')))
                summary=_decision_summary(value,result,None)
                self.assertEqual(p.reason,summary['candidates'][0]['features']['P']['reason'])
                self.assertEqual('UNSUPPORTED',summary['candidates'][0]['actual_damage_survival'])
        self.assertGreater(found,0)

if __name__=='__main__':
    unittest.main()
