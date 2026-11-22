"""Wire membership and context readiness, using synthetic/saved files only."""
from copy import deepcopy
import hashlib
import json
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

from pokiguard_v2.combat_outcome_evidence import observed_effect_totals
from tests.reasoning_test_paths import reasoning_temp_root
from tests.test_combat_outcome_evidence import envelope, projected
from tests import test_combat_outcome_evidence as capture_fixtures
from tests.test_action_outcome_normalization import fixture
from tools.normalize_action_outcomes import checked, extract
from tools.audit_demon_damage_context import audit_file, summarize


class PowerPresenceTests(unittest.TestCase):
    def test_absent_null_false_and_true_survive_all_response_types_without_mutation(self):
        for event in ('MATCH_MOVE_RES', 'MATCH_CARD_USE_RES', 'MATCH_SKILL_USE_RES'):
            for presence, value in (('ABSENT', None), ('NULL', None), ('VALUE', False), ('VALUE', True)):
                raw = envelope(event)
                step = raw['matchPayload']['combatSteps'][0]
                if presence == 'ABSENT': del step['fullPower']
                else: step['fullPower'] = value
                original = deepcopy(raw)
                record = projected(raw).to_dict()
                kept = checked(record)['steps'][0]
                self.assertEqual(presence, kept['full_power_presence'])
                self.assertIs(value, kept['full_power'])
                self.assertEqual(original, raw)
                self.assertFalse(record['damage_prediction'])
                self.assertFalse(record['input_authority'])

    def test_optional_presence_cannot_evict_legacy_evidence_at_the_byte_limit(self):
        record = projected().to_dict()
        base = deepcopy(record['evidence'])
        for step in base['steps']: step.pop('full_power_presence')
        size = len(json.dumps(base, ensure_ascii=True, sort_keys=True, separators=(',', ':')).encode())
        with patch('pokiguard_v2.combat_outcome_evidence.MAX_CAPTURE_BYTES', size):
            capped = projected().to_dict()
        self.assertEqual('CAPTURED', capped['status'])
        self.assertEqual(base, capped['evidence'])
        self.assertEqual(observed_effect_totals(record), observed_effect_totals(capped))
        with patch('pokiguard_v2.combat_outcome_evidence.MAX_CAPTURE_BYTES', size - 1):
            self.assertEqual('CAPTURE_SIZE_LIMIT', projected().reason)

    def test_legacy_membership_stays_unknown_and_conflicting_new_metadata_is_rejected(self):
        legacy = projected().to_dict()
        for step in legacy['evidence']['steps']: step.pop('full_power_presence')
        self.assertEqual(legacy['evidence'], checked(legacy))
        for presence, value in (('ABSENT', True), ('NULL', False), ('VALUE', None), ('UNKNOWN', None), (None, None)):
            bad = deepcopy(legacy)
            bad['evidence']['steps'][0].update(full_power_presence=presence, full_power=value)
            with self.assertRaisesRegex(ValueError, 'FULL_POWER_PRESENCE_CONFLICT'): checked(bad)

    def test_optional_membership_budget_difference_does_not_create_duplicate_effect_conflicts(self):
        raw = envelope()
        raw['matchPayload']['combatSteps'][0].pop('fullPower')
        record = projected(raw).to_dict()
        legacy = deepcopy(record)
        for step in legacy['evidence']['steps']: step.pop('full_power_presence')
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as directory:
            path = Path(directory) / 'combat.jsonl'
            def run(records):
                path.write_text('\n'.join(json.dumps(dict(combatOutcome=r)) for r in records), encoding='utf-8')
                return extract(path)
            for records in ((legacy, record), (record, legacy)):
                result = run(records)
                self.assertEqual(1, len(result['observations']))
                self.assertEqual(1, result['duplicate_outcomes'])
                self.assertEqual('ABSENT', result['observations'][0]['steps'][0]['full_power_presence'])
                self.assertEqual(1400, sum(s['observed_amount'] for s in result['observations'][0]['effect_totals']
                    if s['kind']=='DAMAGE'))
            conflicting = deepcopy(record)
            conflicting['evidence']['steps'][0]['full_power_presence'] = 'NULL'
            result = run((record, conflicting))
            self.assertFalse(result['observations'])
            self.assertEqual('CONFLICTING_OUTCOME_IDENTITY', result['excluded'][0]['reason'])

    def test_presence_reaches_exact_board_export_without_an_extra_memory_query(self):
        helper = capture_fixtures.OutcomeTapTests()
        helper.setUp()
        snapshot = helper.capture(envelope())
        record = helper.tap.combat_outcome_fields(snapshot)['combatOutcome']
        self.assertEqual(['VALUE', 'ABSENT', 'VALUE'],
            [s['full_power_presence'] for s in record['evidence']['steps']])
        self.assertEqual([], helper.target.memory.mock_calls)
        self.assertEqual(64, len(snapshot.cells))
        self.assertEqual(0, helper.tap.diagnostics.raw_board_rejections)


class DamageContextAuditTests(unittest.TestCase):
    def run_case(self, transform=None, *, duplicate=False, ack=True):
        sent, capture = fixture()
        config = dict(play_style='demon_aegis_farm', damage_card='pet_passive',
            demon_target_gem='shield', main_pet='normal', evolution_target='none')
        if transform: transform(sent, capture, config)
        rows = [dict(event='auto_controller_started', config=config), sent, dict(combatOutcome=capture)]
        if ack:
            rows.append(dict(event='action_result', result='SWAP_ACKNOWLEDGED', action=dict(identity=sent['identity'])))
        if duplicate: rows.append(dict(combatOutcome=deepcopy(capture)))
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as directory:
            path = Path(directory) / 'combat.jsonl'
            # Blank lines must not move the exact physical action_line binding.
            raw = ('\n' + '\n'.join(json.dumps(row) for row in rows) + '\n').encode()
            path.write_bytes(raw)
            context = audit_file(path)
            self.assertEqual(hashlib.sha256(raw).hexdigest(), context['sha256'])
            self.assertEqual(raw, path.read_bytes())
            observation = extract(path)['observations'][0]
        return context, observation

    def test_exact_action_context_remains_observation_without_fitting_or_invented_fields(self):
        case, obs = self.run_case()
        self.assertEqual(1, len(case['records']))
        r = case['records'][0]
        self.assertEqual('EXACT_SWAP_SENT_ACK', r['action_binding_status'])
        self.assertEqual(obs['action_binding']['source'], r['source'])
        self.assertIsNotNone(r['first_wave'])
        self.assertIn('PET_AVATAR_GEAR_IDENTITIES_NOT_BOUND', r['calibration_blockers'])
        self.assertIn('ELEMENT_CRIT_BUFF_CONTEXT_UNKNOWN', r['calibration_blockers'])
        self.assertFalse(r['calibration_eligible'])
        self.assertFalse(r['training_eligible'])
        self.assertIsNone(r['prediction'])
        self.assertNotIn('SYNTHETIC_NATIVE_ACTOR', json.dumps(case))

    def test_old_null_does_not_become_wire_absent_and_old_boolean_is_not_new_wire_metadata(self):
        case, _ = self.run_case()
        states = [s['state'] for s in case['records'][0]['full_power_states']]
        self.assertTrue(states)
        self.assertTrue(all(s.startswith(('LEGACY_', 'UNKNOWN_')) for s in states))
        self.assertIn('FULL_POWER_WIRE_PRESENCE_NOT_RETAINED', case['records'][0]['calibration_blockers'])

    def test_new_presence_survives_normalization_and_does_not_certify_a_model(self):
        def change(sent, capture, config):
            for step in capture['evidence']['steps']:
                step['full_power_presence'] = 'VALUE' if type(step.get('full_power')) is bool else 'NULL'
        case, obs = self.run_case(change)
        self.assertTrue(all('full_power_presence' in s for s in obs['steps']))
        r = case['records'][0]
        self.assertTrue(all(s['state'].startswith('WIRE_') for s in r['full_power_states']))
        self.assertNotIn('FULL_POWER_WIRE_PRESENCE_NOT_RETAINED', r['calibration_blockers'])
        self.assertIn('FULL_POWER_ACTIVATION_COST_AND_CROSS_LIST_ORDER_UNKNOWN', r['calibration_blockers'])
        self.assertEqual(0, summarize([case])['calibration_eligible'])

    def test_stats_require_explicit_ownership_and_whole_loadout_is_never_inferred(self):
        def change(sent, capture, config):
            sent['player'].update(is_local=True, is_boss=False, actor_number=1,
                source='Active.playerStatsMap/ObfuscatedInt.Value', hp=100, max_hp=200,
                mana=10, max_mana=100, power=50, max_power=250, attack=1819, shield=0)
            sent['boss'].update(is_local=False, is_boss=True, actor_number=99,
                source='Active.playerStatsMap/ObfuscatedInt.Value', hp=1000, max_hp=2000,
                mana=10, max_mana=100, power=50, max_power=250, attack=766, shield=0)
        case, _ = self.run_case(change)
        self.assertTrue(case['records'][0]['self_stats']['complete_numeric_fields'])
        self.assertEqual(1819, case['records'][0]['self_stats']['observed']['attack'])
        self.assertIn('PET_AVATAR_GEAR_IDENTITIES_NOT_BOUND', case['records'][0]['calibration_blockers'])
        def wrong(sent, capture, config):
            change(sent, capture, config)
            sent['player']['is_local'] = None
        other, _ = self.run_case(wrong)
        self.assertIsNone(other['records'][0]['self_stats']['observed'])

    def test_duplicates_cannot_add_samples_and_conflicting_contexts_are_excluded(self):
        case, _ = self.run_case(duplicate=True)
        self.assertEqual(1, summarize([case, deepcopy(case)])['unique_local_observations'])
        conflicting = deepcopy(case)
        conflicting['records'][0]['observed_damage_component_sum'] = 123
        result = summarize([case, conflicting])
        self.assertEqual(1, result['conflicting_identities'])
        self.assertEqual(0, result['unique_local_observations'])

    def test_zero_floor_missing_components_and_no_ack_do_not_turn_into_exact_targets(self):
        def change(sent, capture, config):
            capture['evidence']['steps'] = [s for s in capture['evidence']['steps'] if s['kind'] != 'HEAL']
            for step in capture['evidence']['steps']:
                if step['kind'] == 'DAMAGE': step['after'] = {'HP': 0}
        case, _ = self.run_case(change, ack=False)
        r = case['records'][0]
        self.assertIn('ZERO_HP_CENSORED', r['calibration_blockers'])
        self.assertIn('NO_EXACT_SWAP_SENT_ACK', r['calibration_blockers'])
        self.assertIsNone(r['observed_heal_component_sum'])
        self.assertFalse(r['missing_component_is_zero'])
        self.assertFalse(r['calibration_eligible'])

    def test_other_styles_or_damage_sources_do_not_become_demon_samples(self):
        for key, value in (('play_style', 'simple'), ('damage_card', 'pet_skill')):
            case, _ = self.run_case(lambda s, c, config: config.update({key: value}))
            self.assertFalse(case['records'])
            self.assertEqual(['NOT_ONE_DECLARED_DEMON_PASSIVE_CONFIGURATION'], case['file_exclusions'])


if __name__ == '__main__': unittest.main()
