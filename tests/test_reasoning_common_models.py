"""Use the confirmed declaration with real BASIC configs, synthetic boards."""
from dataclasses import replace
import time,unittest
from pokiguard_v2.basic_policy import BasicPolicyEngine,PlayStyle
from pokiguard_v2.gameplay_profile import DamageCardMode,MainPetType,EvolutionTarget,DemonTargetGem
from pokiguard_v2.reasoning_common_models import DEMON_GEOMETRY,DEMON_TARGETS,DEMON_DECLARATION,demon_effect
from pokiguard_v2.reasoning_common_evidence import build_problem,packet
from pokiguard_v2.reasoning_common_planner import plan_common,CommonLimits
from pokiguard_v2.reasoning_common_selection import CommonAdmission
from pokiguard_v2.reasoning_snapshot import FrozenJSON,canonical_json
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.state import BoardState,CellState,GemType
from tests.test_reasoning_common_evidence import fixture
from tools.evaluate_reasoning_planner import demon_board


def demon_packet(target='shield'):
    state,config,base,cap,h,owner,passed=fixture()
    source=demon_board(swords=2,multiplier=2)
    board=BoardState(tuple(tuple(CellState(r,c,GemType(target if g=='shield' else 'shield' if g==target else g),m)
        for c,(g,m) in enumerate(row)) for r,row in enumerate(source)))
    state=replace(state,board=board)
    config=replace(config,play_style=PlayStyle.DEMON_AEGIS_FARM,main_pet=MainPetType.NORMAL,
        evolution=EvolutionTarget.NONE,damage_card=DamageCardMode.PET_PASSIVE,
        demon_target_gem=DemonTargetGem(target),pet_skill_fire_value=4)
    base=BasicPolicyEngine(config).decide(state)
    return packet(state,config,base,None,h,True)


class DeclaredCommonModelsTests(unittest.TestCase):
    def test_all_five_actual_configs_resolve_the_same_declared_geometry(self):
        for target in DEMON_TARGETS:
            value=demon_packet(target);now=time.perf_counter_ns()
            problem=build_problem(value,run_id='SYNTHETIC',generation=1,observed_ns=now,read_end_ns=now)
            facts=problem.facts.plain()
            self.assertEqual(DEMON_GEOMETRY,facts['demon_geometry'])
            self.assertEqual(target,facts['demon_effect']['configured_target'])
            self.assertEqual(DEMON_DECLARATION.plain(),facts['demon_effect']['declaration'])
            self.assertEqual('USER_DECLARATION',facts['demon_effect']['declaration']['origin'])
            self.assertEqual(value[2].move,problem.baseline.move)
            result=plan_common(problem,CommonLimits(lookahead=False))
            self.assertTrue(result.scores)
            self.assertTrue(all(c.details.plain()['effect_provenance']==facts['demon_effect'] for c in result.scores))
            self.assertFalse(result.to_dict()['input_authority'])

    def test_declaration_is_not_damage_timing_or_actual_pet_proof(self):
        declaration=DEMON_DECLARATION.plain()
        self.assertIn('SERVER_DAMAGE',declaration['does_not_confirm'])
        self.assertIn('LIVE_INPUT_TIMING',declaration['does_not_confirm'])
        self.assertEqual(5,len(declaration['targets']))
        for config in (fixture()[1],replace(demon_packet()[1],damage_card=DamageCardMode.PET_SKILL)):
            geometry,evidence=demon_effect(config)
            self.assertIsNone(geometry);self.assertEqual('NOT_APPLIED',evidence['status'])

    def test_explicit_unknown_override_and_config_identity_remain_effective(self):
        value=demon_packet();now=time.perf_counter_ns()
        problem=build_problem(value,run_id='SYNTHETIC',generation=1,observed_ns=now,read_end_ns=now,demon_geometry=None)
        self.assertIsNone(problem.facts.plain()['demon_geometry'])
        self.assertIn('UNCONFIRMED',plan_common(problem).reason)
        admission=CommonAdmission(canonical_json(jsonable(value[1])),FrozenJSON.of(dict(swap=100)),FrozenJSON.of({}))
        confirmed=admission.problem(value,run_id='SYNTHETIC',generation=1,observed_ns=now,read_end_ns=now)
        self.assertEqual(DEMON_GEOMETRY,confirmed.facts.plain()['demon_geometry'])
        changed=list(value);changed[1]=replace(value[1],demon_target_gem=DemonTargetGem.MANA)
        with self.assertRaisesRegex(ValueError,'config changed'):
            admission.problem(tuple(changed),run_id='SYNTHETIC',generation=1,observed_ns=now,read_end_ns=now)


if __name__=='__main__':unittest.main()
