"""Current E1 raw-evidence and CLI-boundary checks; no native/game input."""
from copy import deepcopy
from dataclasses import replace
import json
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

from pokiguard_v2.reasoning_e1_native import copy_native, verify_native, verify_boundary, reference, CHANGED
from pokiguard_v2.reasoning_calibration import source_files, source_fingerprint, decode_config
from tests.game_update_fixture import historical_config_shape, historical_test_view, before_demon_target_path

ROOT = Path(__file__).resolve().parents[1]
COMPLETION = ROOT/'docs/phase5/artifacts/5e1_requalification_1749_20261021/completion'


class CurrentE1Tests(unittest.TestCase):
    def setUp(self):
        self.enterContext(historical_config_shape())
        self.temp = tempfile.TemporaryDirectory(dir=ROOT/'docs/phase5/artifacts')
        self.addCleanup(self.temp.cleanup)
        self.out = Path(self.temp.name)
        self.cal = copy_native(self.out, COMPLETION)
        path = self.out/'source_manifest.json'
        path.write_text(json.dumps(dict(fingerprint=source_fingerprint(ROOT),files=source_files(ROOT))), 'utf-8')
        self.cal['source_manifest'] = reference(self.out,path)

    def mutate(self, key, mutation):
        path = self.out/self.cal[key]['path']
        if key == 'records':
            value = [json.loads(x) for x in path.read_text('utf-8').splitlines()]
            mutation(value)
            path.write_text(''.join(json.dumps(v)+'\n' for v in value),'utf-8')
        else:
            value = json.loads(path.read_text('utf-8')); mutation(value)
            path.write_text(json.dumps(value),'utf-8')
        self.cal[key] = reference(self.out,path)

    def test_actual_counts_and_ack_only_maxima_no_historical_nine_sample_relabel(self):
        r = verify_native(self.out,self.cal)
        self.assertEqual((r['total_sent'],r['ack_samples'],r['terminal_excluded']),(6,3,3))
        self.assertEqual((r['H_ms'],r['I_ms']),(160.6016,2827.0229))
        self.assertIsNone(r['native_U_ms'])
        self.assertEqual(r['witness']['loadout']['cards'],[])
        self.assertEqual(r['actual_recoveries'],0)

    def test_missing_timing_and_missing_durability_are_rejected(self):
        self.mutate('records',lambda v:v.pop())
        with self.assertRaises(ValueError):verify_native(self.out,self.cal)

    def test_dropped_log_is_rejected_even_if_rehashed(self):
        self.mutate('watermarks',lambda v:v.update(collector_dropped=1))
        with self.assertRaises(ValueError):verify_native(self.out,self.cal)

    def test_wrong_source_identity_or_interval_cannot_be_rehashed_into_acceptance(self):
        self.mutate('records',lambda v:v[0]['payload'].update(decision_source_hash='0'*64))
        with self.assertRaises(ValueError):verify_native(self.out,self.cal)

    def test_incomplete_click_or_missing_ack_cannot_count_as_sample(self):
        self.mutate('records',lambda v:v[0]['payload'].update(sent_clicks=1))
        with self.assertRaises(ValueError):verify_native(self.out,self.cal)

    def test_terminal_exclusion_needs_strong_zero_boss_hp(self):
        path = self.out/self.cal['combats'][0]['path']
        rows = [json.loads(x) for x in path.read_text('utf-8').splitlines()]
        summary = next(x for x in rows if x['event']=='auto_controller_summary')
        summary['terminalCombatSnapshot']['boss_hp']=1
        path.write_text(''.join(json.dumps(v)+'\n' for v in rows),'utf-8')
        self.cal['combats'][0] = reference(self.out,path)
        with self.assertRaises(ValueError):verify_native(self.out,self.cal)

    def test_request_and_historical_d3_gate_are_not_rebound(self):
        from pokiguard_v2.reasoning_demon_native import verify_native as verify_d3
        with self.assertRaises(ValueError):verify_d3(self.out,self.cal)
        self.mutate('request',lambda v:v.update(total_attempt_cap=4))
        with self.assertRaises(ValueError):verify_native(self.out,self.cal)

    @historical_test_view()
    def test_historical_E1_boundary_rejects_b10_source_without_rebinding(self):
        # Native3/3 is evidence for game1.7.4.9. Changing runtime tables must
        # invalidate its activation even when the actual controller is exact.
        with self.assertRaises(ValueError):
            verify_boundary(self.out,self.cal,source_fingerprint(ROOT))
        before = json.loads((ROOT/'docs/artifacts/game_1_7_4_b10_audit_20261022/before_source.json').read_text('utf-8'))
        self.assertEqual(before['fingerprint'],'3a5d5fd5b44652a56371577175cc207414e68dd03adade2b5cba83e45ab7cc37')
        import hashlib
        for name in ('tools/basic_auto_bot.py','tools/farm_run.py',
                     'src/pokiguard_v2/desktop_farm_controller.py',
                     'src/pokiguard_v2/reasoning_demon.py','src/pokiguard_v2/win32_input.py'):
            self.assertEqual(hashlib.sha256(before_demon_target_path(ROOT,name).read_bytes()).hexdigest(),before['files'][name])

    def test_changed_manifest_cannot_bypass_real_current_source(self):
        self.mutate('source_manifest',lambda v:v['files'].update({'tools/basic_auto_bot.py':'0'*64}))
        with self.assertRaises(ValueError):verify_boundary(self.out,self.cal,source_fingerprint(ROOT))

    def test_legacy_recovery_field_is_not_a_zero_recovery_enforcement_gate(self):
        from pokiguard_v2.desktop_farm_controller import DesktopFarmControllerManager, ControllerLaunch
        from pokiguard_v2.win32_input import FarmControlHotkeyEdges
        from tools import farm_run
        raw = json.loads((COMPLETION/'native/request.json').read_text('utf-8'))
        config = decode_config(dict(raw['config'],demon_target_gem='shield'))
        manager = DesktopFarmControllerManager(project_root=ROOT)
        for limit in (0,1,2):
            with self.subTest(limit=limit), patch.object(farm_run,'run',return_value=0) as run:
                launch = ControllerLaunch(config=replace(config,max_technical_recoveries=limit),checkpoint_path=None)
                self.assertEqual(manager._run_production(launch,FarmControlHotkeyEdges(),lambda *a:None),0)
                args = run.call_args.args[0]
                self.assertEqual(args.max_technical_recoveries,1)
                self.assertEqual(args.max_match_attempts,3)
                self.assertEqual(args.target_matches,3)
                self.assertTrue(args.new_run)
                self.assertIsNone(args.resume)


if __name__ == '__main__':
    unittest.main()
