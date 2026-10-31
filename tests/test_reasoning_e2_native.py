"""Current E2 native accounting and setup guard regressions; no game APIs."""
from copy import deepcopy
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import shutil
import tempfile
import unittest

from pokiguard_v2.reasoning_calibration import decode_config,source_files,source_fingerprint
from pokiguard_v2.reasoning_e2_native import verify_native,verify_boundary,check_config

ROOT=Path(__file__).resolve().parents[1]
PACKAGE=ROOT/'docs/phase5/artifacts/5e2_live_20261029/reasoning20_setup'


class E2NativeTests(unittest.TestCase):
    def setUp(self):
        self.temp=tempfile.TemporaryDirectory(dir=PACKAGE)
        self.addCleanup(self.temp.cleanup)
        self.out=Path(self.temp.name)
        shutil.copytree(PACKAGE/'native',self.out/'native')
        shutil.copytree(PACKAGE/'before',self.out/'before')
        shutil.copyfile(PACKAGE/'basic5_allocation.json',self.out/'basic5_allocation.json')
        self.cal=json.loads((PACKAGE/'calibration.json').read_text(encoding='utf-8'))
        current=self.out/'source_manifest.json'
        current.write_text(json.dumps(dict(fingerprint=source_fingerprint(ROOT),files=source_files(ROOT))),encoding='utf-8')
        self.cal['source_manifest']=self.ref(current)

    def ref(self,path):
        return dict(path=path.relative_to(self.out).as_posix(),sha256=hashlib.sha256(path.read_bytes()).hexdigest())

    def mutate(self,ref,change,*,lines=False):
        p=self.out/ref['path']
        value=([json.loads(l) for l in p.read_text(encoding='utf-8').splitlines()] if lines else json.loads(p.read_text(encoding='utf-8')))
        change(value)
        p.write_text(''.join(json.dumps(r)+'\n' for r in value) if lines else json.dumps(value),encoding='utf-8')
        ref.update(self.ref(p))

    def test_all_five_actual_controls_and_two_qualified_timing_samples(self):
        n=verify_native(self.out,self.cal)
        self.assertEqual((n['basic_attempts_consumed'],n['basic_wins'],n['total_basic_sent'],n['total_basic_ACK'],n['total_basic_terminal']),(5,5,9,4,5))
        self.assertEqual((n['H_ms'],n['I_ms'],n['ack_samples']),(127.3942,2359.0343,2))
        self.assertEqual(n['player_stats'],[109491,2771,250,1819])
        self.assertIsNone(n['native_U_ms'])

    def test_only_setup_dispatch_boundary_can_differ(self):
        result=verify_boundary(self.out,self.cal,source_fingerprint(ROOT))
        self.assertTrue(result['gameplay_controller_reader_input_ACK_QTE_worker_logger_byte_exact'])

    def test_rehashed_missing_timing_or_wrong_identity_is_rejected(self):
        for lane in ('missing','identity'):
            with self.subTest(lane=lane):
                original=deepcopy(self.cal['records'])
                original_bytes=(self.out/original['path']).read_bytes()
                self.mutate(self.cal['records'],lambda rs: rs.pop() if lane=='missing' else rs[0]['payload'].update(source_hash='0'*64),lines=True)
                with self.assertRaises(ValueError):verify_native(self.out,self.cal)
                (self.out/original['path']).write_bytes(original_bytes);self.cal['records']=original

    def test_rehashed_failed_second_control_cannot_be_ignored(self):
        self.mutate(self.cal['basic2']['run'],lambda d:d['snapshot'].update(technical_aborts=1))
        with self.assertRaises(ValueError):verify_native(self.out,self.cal)

    def test_rehashed_bad_terminal_cannot_be_an_ACK_exclusion(self):
        self.mutate(self.cal['combats'][0],lambda rows:next(r for r in rows if r['event']=='auto_controller_summary')['terminalCombatSnapshot'].update(boss_hp=1),lines=True)
        with self.assertRaises(ValueError):verify_native(self.out,self.cal)

    def test_drop_and_incomplete_writer_rejected(self):
        self.mutate(self.cal['watermarks'],lambda d:d.update(collector_dropped=1))
        with self.assertRaises(ValueError):verify_native(self.out,self.cal)

    def test_slot_reset_or_wrong_assignment_rejected(self):
        self.mutate(self.cal['basic5_allocation'],lambda d:d['assignment'][5].update(status='COMPLETED'))
        with self.assertRaises(ValueError):verify_native(self.out,self.cal)

    def test_historical_protocols_do_not_admit_E2_calibration(self):
        from pokiguard_v2.reasoning_e1_b10_native import verify_native as e1
        from pokiguard_v2.reasoning_demon_native import verify_native as d3
        for old in (e1,d3):
            with self.subTest(verifier=old.__module__),self.assertRaises(ValueError):old(self.out,self.cal)

    def test_caps_target_and_nonshield_settings_rejected(self):
        from pokiguard_v2.gameplay_profile import DemonTargetGem
        spec=json.loads((PACKAGE/'native/basic2/spec.json').read_text(encoding='utf-8'))
        c=replace(decode_config(spec['config']),target_completed_matches=20,max_match_attempts=20)
        check_config(c)
        for changed in (replace(c,max_match_attempts=21),replace(c,boss_id='1289'),replace(c,demon_target_gem=DemonTargetGem.HEALTH)):
            with self.assertRaises(ValueError):check_config(changed)

    def test_relabelled_source_manifest_is_rejected(self):
        self.mutate(self.cal['source_manifest'],lambda d:d['files'].update({'tools/basic_auto_bot.py':'0'*64}))
        with self.assertRaises(ValueError):verify_boundary(self.out,self.cal,source_fingerprint(ROOT))


if __name__=='__main__':unittest.main()
