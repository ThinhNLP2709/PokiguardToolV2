"""Current b10 native joins and source-boundary controls; no game IO."""
from copy import deepcopy
import json
from pathlib import Path
import tempfile
import unittest

from pokiguard_v2.reasoning_calibration import source_files, source_fingerprint
from pokiguard_v2.reasoning_e1_b10_native import (
    copy_native, verify_native, verify_boundary, reference, REQUEST_SHA, NATIVE_SOURCE,
)

ROOT = Path(__file__).resolve().parents[1]
COMPLETION = ROOT / 'docs/phase5/artifacts/5e1_b10_requalification_20261022/completion'


class B10E1Tests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory(dir=COMPLETION)
        self.addCleanup(self.temp.cleanup)
        self.out = Path(self.temp.name)
        self.cal = copy_native(self.out, COMPLETION)
        path = self.out / 'source_manifest.json'
        path.write_text(json.dumps(dict(fingerprint=source_fingerprint(ROOT), files=source_files(ROOT))), 'utf-8')
        self.cal['source_manifest'] = reference(self.out, path)

    def mutate(self, key, mutation):
        path = self.out / self.cal[key]['path']
        if key == 'records':
            value = [json.loads(x) for x in path.read_text('utf-8').splitlines()]
            mutation(value)
            path.write_text(''.join(json.dumps(x) + '\n' for x in value), 'utf-8')
        else:
            value = json.loads(path.read_text('utf-8'))
            mutation(value)
            path.write_text(json.dumps(value), 'utf-8')
        self.cal[key] = reference(self.out, path)

    def test_actual_three_matches_five_rows_two_ack_maxima(self):
        result = verify_native(self.out, self.cal)
        self.assertEqual((result['total_sent'], result['ack_samples'], result['terminal_excluded']), (5, 2, 3))
        self.assertEqual((result['H_ms'], result['I_ms']), (147.4428, 1676.2507))
        self.assertIsNone(result['native_U_ms'])
        self.assertEqual(result['player_stats'], [123644, 3566, 250, 1856])
        self.assertEqual(result['actual_recoveries'], 0)
        self.assertEqual(self.cal['request']['sha256'], REQUEST_SHA)

    def test_current_setup_only_boundary_preserves_actual_native_gameplay(self):
        result = verify_boundary(self.out, self.cal, source_fingerprint(ROOT))
        self.assertTrue(result['basic_solver_demon_planner_reader_collector_input_ack_qte_farm_stop_byte_exact'])
        self.assertTrue(result['effective_sword_basic_is_the_control'])

    def test_historical_1749_and_D3_cannot_accept_new_native(self):
        from pokiguard_v2.reasoning_e1_native import verify_native as old
        from pokiguard_v2.reasoning_demon_native import verify_native as d3
        for verifier in (old, d3):
            with self.subTest(verifier=verifier.__module__), self.assertRaises(ValueError):
                verifier(self.out, self.cal)

    def test_missing_timing_or_wrong_source_rejected_even_if_rehashed(self):
        self.mutate('records', lambda value: value.pop())
        with self.assertRaises(ValueError):
            verify_native(self.out, self.cal)

    def test_changed_timing_identity_is_rejected(self):
        self.mutate('records', lambda value: value[0]['payload'].update(decision_source_hash='0' * 64))
        with self.assertRaises(ValueError):
            verify_native(self.out, self.cal)

    def test_partial_input_or_dropped_records_are_rejected(self):
        self.mutate('watermarks', lambda value: value.update(collector_dropped=1))
        with self.assertRaises(ValueError):
            verify_native(self.out, self.cal)

    def test_terminal_exclusion_requires_strong_zero_boss_hp(self):
        ref = self.cal['combats'][0]
        path = self.out / ref['path']
        rows = [json.loads(x) for x in path.read_text('utf-8').splitlines()]
        next(x for x in rows if x['event'] == 'auto_controller_summary')['terminalCombatSnapshot']['boss_hp'] = 1
        path.write_text(''.join(json.dumps(x) + '\n' for x in rows), 'utf-8')
        self.cal['combats'][0] = reference(self.out, path)
        with self.assertRaises(ValueError):
            verify_native(self.out, self.cal)

    def test_native_source_and_runtime_manifest_cannot_be_relabelled(self):
        self.mutate('source_manifest', lambda value: value['files'].update({'tools/basic_auto_bot.py': '0' * 64}))
        with self.assertRaises(ValueError):
            verify_boundary(self.out, self.cal, source_fingerprint(ROOT))
        self.assertEqual(NATIVE_SOURCE, 'b825f71927cd937f7fa47ff5066214b38fa37f8ace7b86a285f5b667e34db84f')


if __name__ == '__main__':
    unittest.main()
