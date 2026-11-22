"""Shared boss knowledge cannot certify safety or force a combat stop."""
from dataclasses import replace
import unittest

from pokiguard_v2.boss_threat import assess_boss_threat, state_boss_threat
from pokiguard_v2.reasoning_common_problem import PROFILES
from pokiguard_v2.reasoning_common_tactics import evaluate_context
from pokiguard_v2.reasoning_snapshot import FrozenJSON
from tests.test_phase3c1_pet_skill_policy import session_state
from tests.test_reasoning_strategy_intent import context, step


def assessment(*, hp=70, mana=0, rage=0):
    return assess_boss_threat(dict(hp=hp, max_hp=100),
        dict(mana=mana, max_mana=300, rage=rage, max_rage=250))


class BossThreatTests(unittest.TestCase):
    def test_empty_boss_resources_do_not_exclude_self_charge_and_skill(self):
        value = assessment()
        self.assertEqual(0, value['stored_resource_pressure'])
        self.assertFalse(value['low_resources_exclude_skill'])
        self.assertFalse(value['no_known_sword_certifies_safety'])
        self.assertTrue(value['self_charge_mana_possible'])
        self.assertTrue(value['self_charge_rage_possible'])
        self.assertIsNone(value['skill_ready'])
        self.assertFalse(value['stop_for_unknown_skill'])

    def test_full_resources_do_not_invent_a_ready_card_or_heal_cooldown(self):
        value = assessment(mana=300, rage=250)
        self.assertTrue(value['protection_requested'])
        for key in ('skill_ready', 'skill_cost', 'skill_cooldown', 'heal_trigger',
                    'heal_recurrence', 'next_skill_damage', 'self_charge_amount'):
            self.assertIsNone(value[key], key)
        self.assertFalse(value['drain_prevents_skill_certified'])
        self.assertFalse(value['survival_certified'])

    def test_mana_and_rage_independently_make_shield_buffer_more_valuable(self):
        empty = assessment(hp=100)
        for value in (assessment(hp=100, mana=300), assessment(hp=100, rage=100)):
            self.assertGreater(value['shield_buffer_pressure'], empty['shield_buffer_pressure'])
        rage = assessment(rage=100)
        self.assertEqual(.4, rage['snapshot_rage_fraction'])
        self.assertEqual(1, rage['rage_reference_fraction'])
        self.assertIsNone(rage['skill_cost'])

    def test_two_resources_are_not_added_as_simultaneous_drain_benefits(self):
        mana = assessment(mana=300)
        both = assessment(mana=300, rage=250)
        self.assertEqual(mana['stored_resource_pressure'], both['stored_resource_pressure'])
        self.assertLessEqual(both['stored_resource_pressure'], 1)

    def test_missing_and_invalid_resources_remain_unknown(self):
        for boss in ({}, dict(mana=-1, max_mana=300), dict(rage=True, max_rage=250)):
            value = assess_boss_threat(dict(hp=70, max_hp=100), boss)
            self.assertIsNone(value['stored_resource_pressure'])
            self.assertEqual(['mana', 'rage'], value['missing_resources'])
            self.assertIsNone(value['skill_ready'])
            self.assertFalse(value['low_resources_exclude_skill'])
        zero = assess_boss_threat({}, dict(mana=0, max_mana=0, rage=0, max_rage=0))
        self.assertEqual([], zero['missing_resources'])
        self.assertFalse(zero['low_resources_exclude_skill'])

    def test_no_island_or_specific_boss_skill_is_invented(self):
        value = assessment()
        self.assertIn('UNKNOWN', value['current_boss_scope'])
        self.assertIn('ANCIENT_ISLAND', value['capability_scope'])
        self.assertIn('NOT_A_GENERAL_HEAL_FORMULA', value['boss_heal_support'])
        self.assertFalse(value['low_boss_hp_certifies_kill'])

    def test_state_adapter_reads_only_published_participant_fields(self):
        state = session_state(mana=0, rage=0)
        value = state_boss_threat(state)
        self.assertIsNone(value['skill_ready'])
        self.assertFalse(value['no_known_sword_certifies_safety'])
        missing = replace(state, player=None, opponents=())
        self.assertEqual(['mana', 'rage'], state_boss_threat(missing)['missing_resources'])

    def test_every_common_style_gets_shared_knowledge_and_buffer_value(self):
        for profile in sorted(PROFILES):
            base = context(profile)
            facts = base.facts.plain()
            facts['self'].update(hp=100, max_hp=100, shield=0)
            facts['opponent'].update(mana=300, max_mana=300, rage=0)
            loaded = replace(base, facts=FrozenJSON.of(facts))
            features, details, _ = evaluate_context(loaded, step(loaded, shield=3), [], 0)
            facts['opponent']['mana'] = 0
            empty = replace(base, facts=FrozenJSON.of(facts))
            low, empty_details, _ = evaluate_context(empty, step(empty, shield=3), [], 0)
            with self.subTest(profile=profile):
                self.assertGreater(features['P'], low['P'])
                self.assertEqual('boss_threat.v1', details['boss_skill_threat']['knowledge_version'])
                self.assertIsNone(empty_details['boss_skill_threat']['skill_ready'])
                self.assertEqual(0, evaluate_context(loaded, step(loaded, health=3), [], 0)[0]['P'])

    def test_g1_g2_g3_also_receive_shared_knowledge_without_inventing_casts(self):
        from tests.test_galaxy_pet_reasoning import state, cap, policy
        from tests.test_galaxy_glank import facts
        for element in ('GALAXY_RICKY', 'GALAXY_2', 'GALAXY_DRAGON_KNIGHT'):
            result = policy().decide(state(200, 200), pet_skill_capability=cap(element))
            with self.subTest(element=element):
                threat = facts(result)['boss_skill_threat']
                self.assertEqual('boss_threat.v1', threat['knowledge_version'])
                self.assertIsNone(threat['skill_ready'])
                self.assertFalse(threat['low_resources_exclude_skill'])

    def test_g2_does_not_defer_ready_mitigation_with_loaded_boss_resources(self):
        from tests.test_galaxy_glank import engine, recorded, cap
        from pokiguard_v2.basic_policy import PolicyAction
        source = recorded(27)
        own = replace(source.player, hp=source.player.max_hp*7//10)
        boss = replace(source.opponents[0], mana=source.opponents[0].max_mana)
        state = replace(source, player=own, opponents=(boss,))
        result = engine().decide(state, pet_skill_capability=cap())
        self.assertIs(result.action, PolicyAction.PET_SKILL)
        self.assertEqual('GALAXY_G2_FIRE_PROTECTION', result.trace.policy_step)


if __name__ == '__main__':
    unittest.main()
