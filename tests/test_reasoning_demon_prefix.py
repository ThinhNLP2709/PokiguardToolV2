"""A declared Demon sweep keeps its known prefix without inventing a future."""
from dataclasses import replace
import json
from pathlib import Path
import unittest

from pokiguard_v2.reasoning_common_planner import _features,_score,_root_step,CommonLimits,Work
from pokiguard_v2.reasoning_common_problem import CommonProblem,PROFILES
from pokiguard_v2.reasoning_snapshot import FrozenJSON
from pokiguard_v2.board_simulator import SimulatedCell
from pokiguard_v2.state import GemType
from tests.test_reasoning_strategy_intent import context,step


def prefix(value,**gems):
    return replace(step(value,**gems),coverage='CONDITIONAL_PASSIVE_FIRST_WAVE_ONLY',
        passive_swords=gems.get('sword',0),passive_physical=gems.get('sword',0),unresolved_residual=True)


def score(value,root):
    f,w,d=_features(value,root,[],0)
    return _score(value,root,f,w,d)


class DemonPrefixTests(unittest.TestCase):
    def test_known_swords_and_completed_nominal_goal_do_not_start_from_zero(self):
        value=context('demon_aegis_farm');root=prefix(value,sword=4)
        c=score(value,root);bounds=dict(c.features)
        self.assertEqual((0.5,1.),(bounds['D'].low,bounds['D'].high))
        self.assertEqual((1.,1.),(bounds['F'].low,bounds['F'].high))
        self.assertEqual('DEMON_FIRST_WAVE_FLOOR',bounds['F'].reason)
        self.assertFalse(c.details.plain()['automatic_kill_claim'])

    def test_subgoal_keeps_sword_floor_without_crediting_an_unreached_goal(self):
        value=context('demon_aegis_farm');bounds=dict(score(value,prefix(value,sword=2)).features)
        self.assertEqual((0.25,1.),(bounds['D'].low,bounds['D'].high))
        self.assertEqual((0,1,'UNSUPPORTED'),(bounds['F'].low,bounds['F'].high,bounds['F'].status))

    def test_missing_continuation_does_not_earn_net_resources_or_survival(self):
        value=context('demon_aegis_farm');bounds=dict(score(value,prefix(value,sword=4,rage=5,health=5)).features)
        for name in ('R','P','T','B'):
            self.assertEqual((0,1,'UNSUPPORTED'),(bounds[name].low,bounds[name].high,bounds[name].status),name)

    def test_non_demon_styles_keep_their_existing_unknown_bounds(self):
        for profile in sorted(PROFILES-{'demon_aegis_farm'}):
            value=context(profile);bounds=dict(score(value,prefix(value,sword=4)).features)
            with self.subTest(profile=profile):
                for name in ('F','D'):self.assertEqual('UNSUPPORTED',bounds[name].status)

    def test_unverified_or_ordinary_cascade_is_not_a_declared_passive_prefix(self):
        value=context('demon_aegis_farm')
        for coverage in ('DEMON_PASSIVE_EFFECT_UNKNOWN','EXISTING_SOLVER_KNOWN_CASCADES_NO_REFILL'):
            c=score(value,replace(prefix(value,sword=4),coverage=coverage))
            for name in ('F','D'):self.assertEqual('UNSUPPORTED',dict(c.features)[name].status)

    def test_no_swords_does_not_receive_a_floor(self):
        value=context('demon_aegis_farm');bounds=dict(score(value,prefix(value,mana=4)).features)
        for name in ('F','D'):self.assertEqual('UNSUPPORTED',bounds[name].status)

    def test_floor_is_independent_of_the_configured_activation_gem(self):
        for target in ('shield','health','mana','drain','rage'):
            value=context('demon_aegis_farm')
            value=replace(value,intent=replace(value.intent,settings=FrozenJSON.of(
                dict(value.intent.settings.plain(),demon_target_gem=target))))
            c=score(value,prefix(value,sword=4))
            self.assertEqual(0.5,dict(c.features)['D'].low,target)

    def test_floor_respects_physical_sword_requirement_for_nominal_goal(self):
        value=context('demon_aegis_farm')
        c=score(value,replace(prefix(value,sword=4),passive_physical=1))
        self.assertEqual(0.5,dict(c.features)['D'].low)
        self.assertEqual('UNSUPPORTED',dict(c.features)['F'].status)

    def test_first_wave_lower_bound_is_monotone_for_unobserved_extra_collection(self):
        value=context('demon_aegis_farm')
        for known in range(1,17):
            b=dict(score(value,prefix(value,sword=known)).features)['D']
            for extra in range(17):
                completed=min(1.,(known+extra)/8)
                self.assertLessEqual(b.low,completed);self.assertGreaterEqual(b.high,completed)

    def test_native_prefixes_keep_evidence_without_inventing_damage(self):
        fixture=json.loads((Path(__file__).parent/'fixtures/reasoning_demon_prefix_20261119.json').read_bytes())
        for case in fixture['cases']:
            p=CommonProblem.from_dict(case['problem'])
            grid=tuple(tuple(SimulatedCell(GemType(g),m) for g,m in row) for row in p.board)
            root=_root_step(p,grid,p.baseline.move,Work(CommonLimits(nodes=50000),lambda:0,lambda:False,None))
            self.assertTrue(root.unresolved_residual)
            c=score(p,root);bounds=dict(c.features)
            self.assertEqual(0.5,bounds['D'].low);self.assertEqual(1.,bounds['F'].low)
            self.assertFalse(c.details.plain()['damage_context']['kill_certified'])
            self.assertEqual('UNSUPPORTED',bounds['T'].status)


if __name__=='__main__':unittest.main()
