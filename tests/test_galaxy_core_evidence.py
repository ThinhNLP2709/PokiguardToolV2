"""Galaxy legacy evidence must not become fabricated skill/phase authority."""
from copy import deepcopy
from dataclasses import replace
import json
from pathlib import Path
import unittest

from pokiguard_v2.reasoning_common_problem import CommonProblem
from pokiguard_v2.reasoning_common_planner import plan_common
from pokiguard_v2.reasoning_snapshot import FrozenJSON
from tools.compare_same_state_decisions import compare, project_action
from tools.prepare_galaxy_core_evidence import (
    FIXTURE, fixture_problem, joined_g2_problem, replay_case,
)
from tools.audit_active_skill_inventory import sha_file

JOINED = Path(__file__).parent / 'fixtures/galaxy_core_20261124/cases.json'


def build_joined(case):
    return joined_g2_problem(case['record'], case['capability'], case['rows'], case['config'],
        run_id=case['run_id'], combat_sha256=case['combat_sha256'], tactical_enabled=case['tactical_enabled'])[0]


class GalaxyCoreEvidenceTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.partial = json.loads(FIXTURE.read_text(encoding='utf-8'))
        cls.joined = json.loads(JOINED.read_text(encoding='utf-8'))['cases']
        cls.problems = [fixture_problem(c, cls.partial['runs'][c['pet']], i, sha_file(FIXTURE))
            for i, c in enumerate(cls.partial['cases'])]

    def test_all_37_fixture_states_roundtrip_without_invented_context(self):
        self.assertEqual(37, len(self.problems))
        for p in self.problems:
            self.assertEqual(p, CommonProblem.from_dict(p.to_dict()))
            self.assertTrue(p.source.session_id.startswith('UNKNOWN_FIXTURE_SESSION:'))
            self.assertTrue(p.source.match_id.startswith('UNKNOWN_FIXTURE_MATCH:'))
            self.assertFalse(p.intent.scope.plain()['original_combat_available'])
            self.assertFalse(p.intent.scope.plain()['input_authority'])

    def test_fixture_pet_counts_do_not_claim_three_complete_traces(self):
        self.assertEqual({'g1': 1, 'g2': 35, 'g3': 1},
            {pet: sum(p.facts.plain()['fixture_alias'] == pet for p in self.problems) for pet in ('g1', 'g2', 'g3')})

    def test_partial_fixture_does_not_borrow_mock_card_cost_or_default_settings(self):
        for p in self.problems:
            self.assertEqual({}, p.facts.plain()['resource_requirements'])
            self.assertEqual('UNKNOWN', p.facts.plain()['baseline_execution_mode'])
            self.assertIsNone(p.intent.settings.plain()['mega_self_protection'])
            self.assertIsNone(p.intent.settings.plain()['main_pet'])
            self.assertIsNone(p.intent.settings.plain()['evolution'])
            for effect in p.effects:
                self.assertIsNone(effect.mana_cost)
                self.assertIsNone(effect.rage_cost)

    def test_all_31_recorded_swaps_are_legal_in_their_recorded_screen_board(self):
        swaps = [p for p in self.problems if p.baseline.family == 'swap']
        self.assertEqual(31, len(swaps))
        for p in swaps:
            self.assertEqual('MODELED', project_action(p, p.baseline)['status'])

    def test_six_fixture_skills_are_opaque_and_retained_not_zero_damage(self):
        skills = [p for p in self.problems if p.baseline.family == 'pet_skill']
        self.assertEqual(6, len(skills))
        for p in skills:
            self.assertIsNone(p.effects[0].cleared)
            self.assertEqual('UNKNOWN', p.effects[0].support)
            decision = plan_common(p, clock=lambda: 0)
            self.assertIn(decision.proposal, (None, p.baseline))
            projection = project_action(p, p.baseline)
            self.assertEqual('UNKNOWN', projection['status'])
            self.assertEqual('ACTION_EFFECT_UNMODELED', projection['reason'])
            self.assertIsNone(projection['damage_prediction'])

    def test_g2_uses_weighted_shields_and_reports_cost_of_collecting_them(self):
        p = next(p for p in self.problems if p.facts.plain()['fixture_alias'] == 'g2' and p.source.turn == 9)
        item = replay_case(p, replay=True)
        f, review = item['pre_action_features'], item['g2_strategy_review']
        self.assertGreaterEqual(f['shield_effective'], f['shield_physical'])
        for side in ('baseline', 'common'):
            self.assertEqual(f['shield_effective'], review[side]['known_shield_consumed']
                + review[side]['known_shield_remaining_ignoring_refill'])
            self.assertIsNone(review[side]['added_shield_from_refill'])
        self.assertTrue(review['shield_collection_can_cost_skill_potential'])
        self.assertFalse(review['common_planner_has_pet_specific_shield_skill_utility'])
        self.assertTrue(review['mechanical_classifier_is_not_g2_strategy_quality'])

    def test_five_exact_g2_clicks_roundtrip_with_actual_cost_and_recorded_route(self):
        self.assertEqual(5, len(self.joined))
        for c in self.joined:
            p = build_joined(c)
            self.assertEqual(p, CommonProblem.from_dict(p.to_dict()))
            self.assertEqual((200, 200), (p.effects[0].mana_cost, p.effects[0].rage_cost))
            self.assertEqual('galaxy', p.intent.settings.plain()['main_pet'])
            self.assertEqual('none', p.intent.settings.plain()['evolution'])
            self.assertEqual('none', p.intent.settings.plain()['mega_self_protection'])
            self.assertEqual(dict(mana=200, rage=200), p.facts.plain()['resource_requirements'])

    def test_recorded_basic_config_does_not_relabel_enabled_per_pet_tactics(self):
        for c in self.joined:
            self.assertEqual('basic', c['config']['intelligence'])
            p = build_joined(c)
            self.assertEqual('GALAXY_PER_PET_TACTICS', p.facts.plain()['baseline_execution_mode'])
            self.assertFalse(p.facts.plain()['common_worker_execution'])
            self.assertIn('NOT_UI_BASIC_VS_REASONING', replay_case(p, replay=False)['comparison_scope'])

    def test_missing_phase_never_guesses_first_or_fourth_from_sparse_turns(self):
        for p in self.problems + [build_joined(c) for c in self.joined]:
            f = p.facts.plain()
            self.assertIsNone(f['phase_next'])
            self.assertIsNone(f['phase_max'])
            self.assertEqual('UNKNOWN', f['phase_support'])
            self.assertIsNone(f['stored_mark_damage'])
            self.assertIsNone(f['active_buff_remaining'])
            self.assertIsNone(f['random_outcome'])
            self.assertEqual(0, f['guaranteed_refund_credit'])

    def test_galaxy_never_receives_mega_geometry_or_icarus_heal_credit(self):
        for c in self.joined:
            e = build_joined(c).effects[0]
            self.assertIsNone(e.cleared)
            self.assertIsNone(e.facts.plain()['seal_element_type'])
            self.assertFalse(e.facts.plain()['self_heal_present'])
            self.assertEqual('UNKNOWN_NOT_CREDITED', e.facts.plain()['self_heal_knowledge'])

    def test_zero_input_or_unverified_controller_cannot_become_a_cast(self):
        for key in ('logged_click_card_cost_join', 'controller_join_verified'):
            c = deepcopy(self.joined[0]); c['record'][key] = False
            with self.assertRaisesRegex(ValueError, 'EXACT_LOGGED_CLICK_REQUIRED'): build_joined(c)

    def test_wrong_card_family_owner_source_and_actionability_are_rejected(self):
        for key, value in (('status', 'STALE'), ('element_type', 'MEGA_ICARUS'),
                ('element_type', 'GALAXY_RICKY'), ('skill_family', 'MEGA_TREX_CLICK_ONLY'),
                ('ownership_current', False), ('live_card_present', False), ('live_card_actionable', False),
                ('card_id', 999), ('source', 'PetUserDTO.cardDTO')):
            c = deepcopy(self.joined[0]); c['capability'][key] = value
            with self.subTest(key=key, value=value), self.assertRaisesRegex(ValueError, 'CURRENT_G2_CARD_REQUIRED'):
                build_joined(c)

    def test_foreign_card_session_or_controller_match_is_rejected(self):
        c = deepcopy(self.joined[0]); c['capability']['session_key']['match_id'] = 'M_foreign'
        with self.assertRaisesRegex(ValueError, 'CURRENT_G2_CARD_REQUIRED'): build_joined(c)
        c = deepcopy(self.joined[0]); c['record']['match_id'] = 'M_foreign'
        with self.assertRaisesRegex(ValueError, 'CONTROLLER_ACTION_IDENTITY_CONFLICT'): build_joined(c)

    def test_unknown_cost_sources_and_changed_dispatch_cost_are_rejected(self):
        c = deepcopy(self.joined[0]); c['capability']['effective_mana_cost_source'] = 'UNKNOWN'
        with self.assertRaisesRegex(ValueError, 'KNOWN_COST_SOURCES_REQUIRED'): build_joined(c)
        c = deepcopy(self.joined[0]); c['capability']['effective_power_cost'] = None
        with self.assertRaisesRegex(ValueError, 'COST_CONFLICT'): build_joined(c)
        c = deepcopy(self.joined[0]); dict(c['rows'])[c['record']['controller_start_line']]['requiredRage'] = 0
        with self.assertRaisesRegex(ValueError, 'DISPATCH_COST_CONFLICT'): build_joined(c)

    def test_missing_mana_or_rage_cannot_be_funded_by_declared_refund(self):
        for key in ('mana', 'power'):
            c = deepcopy(self.joined[0])
            for _, row in c['rows']:
                if row.get('event') == 'policy_decision': row['player'][key] = 199
            with self.subTest(key=key), self.assertRaisesRegex(ValueError, 'PRE_RESOURCES_OR_COST_CONFLICT'):
                build_joined(c)

    def test_foreign_route_does_not_silently_inherit_no_evolution_acceptance(self):
        for key, value in (('evolution_target', 'normal'), ('main_pet', 'normal'),
                ('damage_card', 'attack'), ('play_style', 'mega_icarus_spam_skill')):
            c = deepcopy(self.joined[0]); c['config'][key] = value
            with self.subTest(key=key), self.assertRaisesRegex(ValueError, 'LEGACY_G2_ROUTE_NOT_VERIFIED'):
                build_joined(c)

    def test_pre_policy_conflict_is_not_resolved_by_picking_latest_row(self):
        c = deepcopy(self.joined[0]); row = deepcopy(next(r for _, r in c['rows'] if r['event'] == 'policy_decision'))
        row['player']['mana'] += 1
        c['rows'].append([c['record']['controller_start_line']-1, row])
        with self.assertRaisesRegex(ValueError, 'CONFLICTING_PRE_POLICY_STATE'): build_joined(c)

    def test_wrong_board_domain_order_and_actor_are_rejected(self):
        for mode in ('domain', 'order', 'owner'):
            c = deepcopy(self.joined[0])
            for _, row in c['rows']:
                if row.get('event') != 'policy_decision': continue
                if mode == 'domain': row['boardSnapshot'][0][0][1] = True
                elif mode == 'order': row['boardSnapshotOrder'] = 'bottom_origin'
                else: row['player']['is_local'] = False
            with self.subTest(mode=mode), self.assertRaises(ValueError): build_joined(c)

    def test_later_win_hp_resource_or_response_cannot_change_pre_input(self):
        for c in self.joined:
            original = build_joined(c)
            altered = deepcopy(c)
            altered['record'].update(resources_after=[99999999, 250], post_turn=999,
                resource_net_delta=[99999999, 0], resource_endpoint_consistent=True)
            altered['rows'].append([99999, dict(event='terminal_combat_snapshot', hp=0, won=True, damage=99999999)])
            after = build_joined(altered)
            self.assertEqual(original, after)
            self.assertEqual(compare(original), compare(after))

    def test_fixture_future_labels_and_old_resource_tallies_are_not_model_inputs(self):
        case = deepcopy(self.partial['cases'][1])
        before = fixture_problem(case, self.partial['runs']['g2'], 1, sha_file(FIXTURE))
        case.update(won=True, actual_refill=['sword']*64, damage=99999999, old_resources=[['sword', 64, 999]])
        after = fixture_problem(case, self.partial['runs']['g2'], 1, sha_file(FIXTURE))
        self.assertEqual(before, after)

    def test_low_hp_does_not_invent_galaxy_heal_or_make_opaque_action_zero(self):
        p = build_joined(self.joined[0]); f = p.facts.plain(); f['self']['hp'] = 1
        low = replace(p, facts=FrozenJSON.of(f))
        r = compare(low)
        self.assertEqual('pet_skill', r['reasoning']['action']['family'])
        self.assertEqual('UNKNOWN', r['reasoning']['status'])
        self.assertIsNone(r['reasoning']['damage_prediction'])

    def test_no_exported_quality_training_input_or_future_authority(self):
        r = replay_case(build_joined(self.joined[0]), replay=True)
        self.assertIsNone(r['quality_label'])
        self.assertFalse(r['training_eligible'])
        self.assertFalse(r['input_authority'])
        self.assertFalse(r['same_state_common_replay']['observed_future_injected'])
        self.assertFalse(r['same_state_common_replay']['global_optimum_claim'])


if __name__ == '__main__': unittest.main()
