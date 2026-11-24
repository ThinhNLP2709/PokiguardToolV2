"""Legacy T-Rex replay provenance, family separation and future-leak guards."""
from copy import deepcopy
from dataclasses import replace
import json
from pathlib import Path
import unittest

from pokiguard_v2.mega_icarus import MEGA_TREX_SEAL_CELLS,MEGA_ICARUS_SEAL_CELLS,count_seal_gems
from pokiguard_v2.reasoning_common_problem import CommonProblem
from pokiguard_v2.reasoning_common_planner import plan_common
from pokiguard_v2.reasoning_snapshot import FrozenJSON
from pokiguard_v2.state import GemType
from tools.prepare_trex_core_evidence import pre_problem
from tools.compare_same_state_decisions import compare,project_action

FIXTURE=Path(__file__).parent/'fixtures/trex_core_20261124/cases.json'


def cases():return json.loads(FIXTURE.read_text(encoding='utf-8'))['cases']


def build(case):
    return pre_problem(case['record'],case['capability'],case['rows'],case['config'],
                       run_id=case['run_id'],combat_sha256=case['combat_sha256'])


def good():return [c for c in cases() if c['expected_exclusion'] is None]


class TrexCoreEvidenceTests(unittest.TestCase):
    def test_seven_match_sample_and_two_conflicts_remain_separate(self):
        data=cases()
        self.assertEqual(7,len({c['record']['match_id'] for c in good()}))
        self.assertEqual(2,sum(c['expected_exclusion'] is not None for c in data))
        for case in data:
            if case['expected_exclusion'] is not None:
                with self.assertRaisesRegex(ValueError,'CONFLICTING_PRE_POLICY_STATE'):build(case)

    def test_existing_common_schema_roundtrips_real_legacy_pre_states(self):
        for case in good():
            value,features=build(case)
            self.assertEqual(value,CommonProblem.from_dict(value.to_dict()))
            self.assertEqual('MEGA_TREX',features['seal_type'])
            self.assertEqual((200,200),(value.effects[0].mana_cost,value.effects[0].rage_cost))
            self.assertEqual('pet_skill',value.baseline.family)
            self.assertEqual('normal',value.intent.settings.plain()['main_pet'])

    def test_trex_has_its_own_30_cell_mask(self):
        case=good()[0];p,features=build(case)
        self.assertEqual(set(MEGA_TREX_SEAL_CELLS),set(p.effects[0].cleared))
        self.assertEqual(30,len(p.effects[0].cleared))
        self.assertEqual(22,len(set(MEGA_TREX_SEAL_CELLS)^set(MEGA_ICARUS_SEAL_CELLS)))
        for gem in GemType:
            if gem is GemType.UNKNOWN:continue
            tally=count_seal_gems(p.board_state(),gem,cells=MEGA_TREX_SEAL_CELLS)
            self.assertEqual(tally.effective,features['conditional_seal_counts'][gem.value]['effective'])

    def test_multipliers_are_weighted_not_just_physical_cells(self):
        differences=[]
        for case in good():
            _,f=build(case)
            differences.extend(t['effective']>t['physical'] for t in f['conditional_seal_counts'].values())
        self.assertTrue(any(differences))

    def test_icarus_intrinsic_heal_is_not_credited_to_trex(self):
        for case in good():
            p,_=build(case);f=p.effects[0].facts.plain()
            self.assertFalse(f['self_heal_present'])
            self.assertIsNone(f['self_heal_provenance'])
            self.assertEqual('UNKNOWN_NOT_CREDITED',f['self_heal_knowledge'])
            self.assertEqual('UNKNOWN',p.facts.plain()['healing_knowledge']['fusion_lifesteal'])
            self.assertFalse(project_action(p,p.baseline)['self_heal_present'])

    def test_low_hp_does_not_create_an_intrinsic_heal_credit(self):
        p,_=build(good()[0]);facts=p.facts.plain()
        facts['self']['hp']=facts['self']['max_hp']//4
        low=replace(p,facts=FrozenJSON.of(facts))
        decision=plan_common(low,clock=lambda:0)
        score=next(x for x in decision.scores if x.action==low.baseline)
        self.assertEqual(0,score.details.plain()['tactical_context']['protection_proxy']['self_heal_opportunity'])
        self.assertIsNone(low.facts.plain()['skill_damage_model'])

    def test_unknown_old_protection_setting_is_not_filled_with_current_default(self):
        for case in good():
            p,_=build(case)
            self.assertIsNone(p.intent.settings.plain()['mega_self_protection'])
            self.assertIsNone(p.facts.plain()['historical_source_sha256'])
            self.assertIsNone(p.facts.plain()['historical_game_build_sha256'])
            self.assertFalse(p.facts.plain()['raw_tag_board_hash_recomputed'])

    def test_post_hp_resource_or_win_poison_cannot_change_pre_input_or_decision(self):
        for case in good():
            original,_=build(case)
            poisoned=deepcopy(case)
            poisoned['record']['resources_after']=[99999999,0]
            poisoned['record']['resource_net_delta']=[-99999,99999]
            poisoned['record']['post_turn']=999
            poisoned['future_hp']=0
            poisoned['future_win_label']=True
            after,_=build(poisoned)
            self.assertEqual(original.snapshot_id,after.snapshot_id)
            self.assertEqual(plan_common(original,clock=lambda:0),plan_common(after,clock=lambda:0))

    def test_policy_row_after_dispatch_cannot_supply_the_pre_board(self):
        case=deepcopy(good()[0])
        case['rows']=[[case['record']['controller_start_line']+1,d] if d.get('event')=='policy_decision' else [n,d]
                      for n,d in case['rows']]
        with self.assertRaisesRegex(ValueError,'PRE_POLICY_BOARD_MISSING'):build(case)

    def test_duplicate_pre_rows_must_agree_instead_of_picking_latest(self):
        case=deepcopy(good()[0])
        n,d=next((n,d) for n,d in case['rows'] if d.get('event')=='policy_decision')
        d=deepcopy(d);d['player']['hp']-=1
        case['rows'].append([n+0.5,d])
        with self.assertRaisesRegex(ValueError,'CONFLICTING_PRE_POLICY_STATE'):build(case)

    def test_wrong_card_family_session_and_cost_do_not_reuse_trex_evidence(self):
        for field,value in [('element_type','MEGA_ICARUS'),('skill_family','MEGA_ICARUS_CLICK_ONLY'),
                            ('session_key',{}),('skill_card_id',22),('effective_power_cost',150)]:
            case=deepcopy(good()[0]);case['capability'][field]=value
            with self.assertRaises(ValueError,msg=field):build(case)

    def test_mana_rage_before_click_must_match_the_logged_policy(self):
        for index in (0,1):
            case=deepcopy(good()[0]);case['record']['resources_before'][index]+=1
            with self.assertRaisesRegex(ValueError,'PRE_RESOURCES_OR_COST_CONFLICT'):build(case)

    def test_changed_route_and_condition_are_not_silently_migrated(self):
        for field,value in [('evolution_target','none'),('main_pet','mega'),('pet_skill_fire_value',6)]:
            case=deepcopy(good()[0]);case['config'][field]=value
            with self.assertRaises(ValueError,msg=field):build(case)

    def test_unknown_owner_board_shape_or_coordinate_order_is_not_repaired(self):
        for kind in ('owner','board','order'):
            case=deepcopy(good()[0])
            for _,row in case['rows']:
                if row.get('event')!='policy_decision':continue
                if kind=='owner':row['player']['is_local']=None
                elif kind=='board':row['boardSnapshot'][0][0]=['sword',True]
                else:row['boardSnapshotOrder']='bottom_to_top'
            with self.assertRaises(ValueError,msg=kind):build(case)

    def test_zero_input_or_controller_join_failure_never_creates_skill_case(self):
        for field in ('logged_click_card_cost_join','controller_join_verified'):
            case=deepcopy(good()[0]);case['record'][field]=False
            with self.assertRaisesRegex(ValueError,'EXACT_LOGGED_CLICK_REQUIRED'):build(case)

    def test_each_actual_resource_cost_still_blocks_insufficient_funds(self):
        p,_=build(good()[0])
        for name in ('mana','rage'):
            facts=p.facts.plain();facts['self'][name]=199
            insufficient=replace(p,facts=FrozenJSON.of(facts))
            projected=project_action(insufficient,insufficient.baseline)
            self.assertEqual('ACTUAL_ACTION_RESOURCES_INSUFFICIENT',projected['reason'])

    def test_two_swap_proposals_have_explicit_tradeoffs_not_win_labels(self):
        changed=[c for c in good() if c.get('expected_replay_action')=='swap']
        self.assertEqual(2,len(changed))
        for case in changed:
            p,_=build(case);result=compare(p)
            self.assertEqual('swap',result['reasoning']['action']['family'])
            self.assertEqual('INSUFFICIENT_DATA',result['comparison']['category'])
            self.assertTrue(result['comparison']['benefits'])
            self.assertTrue(result['comparison']['costs'])
            self.assertIsNone(result['quality_label'])
            self.assertFalse(result['observed_future_injected'])
            self.assertFalse(result['training_eligible'])

    def test_source_structures_are_not_mutated_and_no_observation_is_in_problem(self):
        case=good()[0];before=deepcopy(case)
        p,_=build(case)
        self.assertEqual(case,before)
        self.assertNotIn('resources_after',json.dumps(p.to_dict()))
        self.assertNotIn('resource_net_delta',json.dumps(p.to_dict()))
        self.assertIsNone(p.facts.plain()['skill_damage_model'])


if __name__=='__main__':unittest.main()
