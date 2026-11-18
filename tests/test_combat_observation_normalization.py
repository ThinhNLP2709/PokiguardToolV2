"""Offline native observations plus malformed/ambiguous evidence; no game input."""
from copy import deepcopy
import json
from pathlib import Path
import tempfile
import unittest

from tests.reasoning_test_paths import reasoning_temp_root
from tools.normalize_combat_observations import extract, first_wave, normalize


FIXTURE = Path(__file__).parent/'fixtures/combat_normalization_20261118.json'


def cases():
    return json.loads(FIXTURE.read_text(encoding='utf-8'))['cases']


def observed(case):
    return normalize(case['sent'], case['capture'], target=case['target'], acknowledged=case['acknowledged'])


class CombatObservationNormalizationTests(unittest.TestCase):
    def test_two_native_first_waves_match_all_six_effective_counts(self):
        for case, physical, effective in zip(cases()[:2], (4, 6), (5, 7)):
            with self.subTest(turn=case['sent']['turn']):
                result = observed(case)
                self.assertEqual(physical, result['first_wave']['physical']['sword'])
                self.assertEqual(effective, result['first_wave']['effective']['sword'])
                self.assertEqual(result['first_wave']['effective'], result['server_destroyed'])
                self.assertFalse(result['matches_physical_ledger'])
                self.assertTrue(result['usable_observation'])

    def test_native_x3_mana_and_x4_health_are_counted_without_rounding(self):
        result = observed(cases()[1])
        self.assertEqual((3, 5), (result['first_wave']['physical']['mana'], result['first_wave']['effective']['mana']))
        self.assertEqual((5, 8), (result['first_wave']['physical']['health'], result['first_wave']['effective']['health']))

    def test_hp_damage_is_separate_from_all_shield_blocks(self):
        for case, hp, block, gross in zip(cases()[:2], (164256, 227493), (870, 3451), (165126, 230944)):
            result = observed(case)
            self.assertEqual(hp, result['hp_damage'])
            self.assertEqual(block, result['shield_blocked'])
            self.assertEqual(gross, result['observed_hp_damage_plus_blocked'])
            self.assertTrue(result['hp_ledger_consistent'])
            self.assertTrue(result['shield_ledger_consistent'])

    def test_power_is_added_before_damage_without_inventing_full_power_threshold(self):
        for case, before, added, after in zip(cases()[:2], (75, 110), (100, 120), (175, 230)):
            power = observed(case)['power']
            self.assertEqual((before, added, after), (power['before'], power['added_before_damage'], power['after']))
            self.assertTrue(power['consistent'])
            self.assertTrue(power['ordered_before_damage'])
            self.assertEqual([True], power['damage_full_power'])

    def test_no_predictive_coefficient_or_input_authority_is_created(self):
        for case in cases():
            result = observed(case)
            self.assertFalse(result['calibration_eligible'])
            self.assertFalse(result['input_authority'])
            self.assertEqual('DESCRIPTIVE_OBSERVATION_NOT_PREDICTIVE_COEFFICIENT', result['ratio_kind'])
            self.assertIn('ELEMENT_CRIT_BUFF_CONTEXT', result['unverified'])
        self.assertEqual(33025.2, observed(cases()[0])['observed_per_effective_sword'])
        self.assertEqual(32992.0, observed(cases()[1])['observed_per_effective_sword'])

    def test_terminal_overkill_without_ack_is_censored(self):
        result = observed(cases()[2])
        self.assertFalse(result['usable_observation'])
        self.assertIsNone(result['observed_per_effective_sword'])
        self.assertEqual({'NO_SWAP_ACK', 'TERMINAL_OR_UNKNOWN_HP', 'HP_LEDGER_MISMATCH'}, set(result['observation_blockers']))
        self.assertEqual([None], result['power']['damage_full_power'])

    def test_missing_full_power_remains_unknown(self):
        case = cases()[0]
        del case['capture']['evidence']['steps'][-1]['full_power']
        self.assertEqual([None], observed(case)['power']['damage_full_power'])

    def test_first_wave_uses_selected_target_for_all_five_demon_gems(self):
        case = cases()[0]
        for target in ('shield', 'health', 'mana', 'drain', 'rage'):
            board = deepcopy(case['sent']['boardSnapshot'])
            for row in board:
                for cell in row:
                    if cell[0] == 'shield': cell[0] = target
                    elif cell[0] == target: cell[0] = 'shield'
            result = first_wave(board, case['sent']['identity']['target'], target)
            self.assertEqual(5, result['effective']['sword'])

    def test_unknown_cells_boolean_or_unsupported_multipliers_are_rejected(self):
        for cell in (['unknown', 1], ['sword', True], ['sword', 0], ['sword', 8], ['sword']):
            case = cases()[0]
            case['sent']['boardSnapshot'][0][0] = cell
            with self.subTest(cell=cell), self.assertRaises(ValueError): observed(case)

    def test_invalid_move_or_non_swap_input_is_rejected(self):
        for move in ([[0, 0], [7, 7]], [[False, 0], [0, 1]], [[0, 0], [0, 1]]):
            case = cases()[0]
            case['sent']['move'] = dict(first=move[0], second=move[1])
            case['sent']['identity']['target'] = move
            with self.subTest(move=move), self.assertRaises(ValueError): observed(case)
        case = cases()[0]; case['sent']['identity']['action'] = 'use_card'
        with self.assertRaises(ValueError): observed(case)

    def test_wrong_actor_match_stale_sequence_or_source_board_is_rejected(self):
        mutations = [lambda c: c['capture']['evidence'].update(actor_identity='BOSS'),
            lambda c: c['capture']['evidence'].update(match_id='STALE'),
            lambda c: c['capture']['evidence'].update(server_sequence=18),
            lambda c: c['capture']['evidence'].update(server_sequence=True),
            lambda c: c['sent'].update(boardHash='DIFFERENT'),
            lambda c: c['sent'].update(boardSnapshotOrder='bottom_to_top')]
        for mutate in mutations:
            case = cases()[0]; mutate(case)
            with self.subTest(mutate=mutate), self.assertRaises(ValueError): observed(case)

    def test_unknown_server_tag_or_mismatch_cannot_receive_a_coefficient(self):
        case = cases()[0]; case['capture']['evidence']['destroyed_by_tag']['future Dot'] = 2
        with self.assertRaisesRegex(ValueError, 'DESTROYED_TAG_DOMAIN'): observed(case)
        case = cases()[0]; case['capture']['evidence']['destroyed_by_tag']['vang Dot'] = 6
        result = observed(case)
        self.assertFalse(result['usable_observation'])
        self.assertIsNone(result['observed_per_effective_sword'])

    def test_intermediate_shield_mismatch_and_missing_hp_are_not_clean_samples(self):
        case = cases()[1]; case['capture']['evidence']['steps'][4]['after']['SHIELD'] += 1
        result = observed(case)
        self.assertIn('SHIELD_LEDGER_MISMATCH', result['observation_blockers'])
        case = cases()[0]; case['capture']['evidence']['steps'][-1]['after'] = None
        result = observed(case)
        self.assertIn('TERMINAL_OR_UNKNOWN_HP', result['observation_blockers'])

    def test_incomplete_steps_power_mismatch_or_malformed_after_are_rejected(self):
        case = cases()[0]; case['capture']['evidence']['steps'].pop(1)
        self.assertIn('INCOMPLETE_STEP_INDEX', observed(case)['observation_blockers'])
        case = cases()[0]; case['capture']['evidence']['steps'][0]['after']['POWER'] = 999
        self.assertIn('POWER_LEDGER_MISMATCH', observed(case)['observation_blockers'])
        case = cases()[0]; case['capture']['evidence']['steps'][-1]['after'] = [88539]
        with self.assertRaisesRegex(ValueError, 'STEP_FIELD_TYPE'): observed(case)

    def _extract(self, captures, *, with_ack=True, ack_target=None, extra_action=None):
        case = cases()[0]
        identity = deepcopy(case['sent']['identity'])
        if ack_target is not None: identity['target'] = ack_target
        rows = [dict(event='auto_controller_started', config=dict(play_style='demon_aegis_farm',
            damage_card='pet_passive', demon_target_gem='shield')), case['sent']]
        if extra_action is not None: rows.append(extra_action)
        rows.extend(dict(event='dispatcher_combat_outcome', combatOutcome=c) for c in captures)
        if with_ack: rows.append(dict(event='action_result', result='SWAP_ACKNOWLEDGED', action=dict(identity=identity)))
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as directory:
            path = Path(directory)/'combat.jsonl'
            path.write_text(''.join(json.dumps(row)+'\n' for row in rows), encoding='utf-8')
            return extract(path)

    def test_identical_callbacks_are_deduplicated_with_line_provenance(self):
        capture = cases()[0]['capture']
        result = self._extract([capture, deepcopy(capture)])
        self.assertEqual(1, len(result['observations']))
        self.assertFalse(result['excluded'])
        provenance = result['observations'][0]['provenance']
        self.assertEqual((2, 3), (provenance['action_line'], provenance['outcome_line']))
        self.assertEqual(64, len(provenance['combat_sha256']))

    def test_conflicting_or_ambiguous_responses_are_not_joined(self):
        capture = cases()[0]['capture']
        for key, value, reason in (('raw_sha256', 'a'*64, 'AMBIGUOUS_RESPONSE'),
                ('server_sequence', 21, 'AMBIGUOUS_RESPONSE'), ('total_damage_display', 1, 'CONFLICTING_DUPLICATE')):
            other = deepcopy(capture); other['evidence'][key] = value
            result = self._extract([capture, other])
            self.assertFalse(result['observations'])
            self.assertEqual(reason, result['excluded'][0]['reason'])

    def test_missing_response_or_wrong_ack_target_is_not_accepted(self):
        result = self._extract([])
        self.assertEqual('MISSING_RESPONSE', result['excluded'][0]['reason'])
        for kwargs in (dict(with_ack=False), dict(ack_target=[[0, 0], [0, 1]])):
            result = self._extract([cases()[0]['capture']], **kwargs)
            self.assertIn('NO_SWAP_ACK', result['observations'][0]['observation_blockers'])

    def test_next_non_swap_action_bounds_the_response_window(self):
        action = deepcopy(cases()[0]['sent'])
        action['selectedAction'] = 'use_card'; action['identity']['source']['srv_seq'] = 19
        result = self._extract([cases()[0]['capture']], extra_action=action)
        self.assertFalse(result['observations'])
        self.assertEqual('MISSING_RESPONSE', result['excluded'][0]['reason'])


if __name__ == '__main__':
    unittest.main()
