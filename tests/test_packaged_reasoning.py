"""Exact package opt-in gates, durable batch cap, no process attachment/input."""
from dataclasses import replace
import hashlib,json
from pathlib import Path
import tempfile,time,unittest,uuid
from unittest.mock import patch

from pokiguard_v2.app_paths import resolve_app_paths
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.packaged_reasoning import package_identity,PackagedAcceptanceLaunch,BASIC_PROTOCOL,MANIFEST
from pokiguard_v2.reasoning_calibration import decode_config
from pokiguard_v2.reasoning_operational import host_fingerprint
from pokiguard_v2.reasoning_snapshot import digest

ROOT=Path(__file__).resolve().parents[1]


class PackagedReasoningTests(unittest.TestCase):
    def setUp(self):
        self.temp=tempfile.TemporaryDirectory(dir=ROOT/'docs/phase5/artifacts/5f1_packaged_20261031')
        self.addCleanup(self.temp.cleanup);self.root=Path(self.temp.name)
        self.exe=self.root/'install/Tool.exe';self.exe.parent.mkdir();self.exe.write_bytes(b'SYNTHETIC_EXE')
        self.paths=resolve_app_paths(frozen=True,executable=self.exe,module_file=self.root/'bundle/pokiguard_v2/app_paths.py',
            environ={'POKIGUARD_V2_DATA_ROOT':str(self.root/'data')})
        asset=self.paths.package_root/'resources/package_build.json';asset.parent.mkdir(parents=True)
        files={'src/a.py':'0'*64};asset.write_text(json.dumps(dict(schema=MANIFEST,source_sha256=digest(files),source_files=files)),encoding='utf-8')
        self.identity=package_identity(self.paths,self.exe)
        self.game=self.root/'game.exe';self.game.write_bytes(b'SYNTHETIC_GAME')
        cal=json.loads((ROOT/'docs/phase5/artifacts/5e2_live_20261029/basic3_request.json').read_text(encoding='utf-8'))
        self.config=replace(decode_config(cal['config']),target_completed_matches=2,max_match_attempts=2)
        self.path=self.paths.data_root/'acceptance/request.json';self.path.parent.mkdir(parents=True)
        now=time.time()
        self.req=dict(schema='pokiguard.packaged_basic_acceptance.v1',pilot_protocol=BASIC_PROTOCOL,
            package=self.identity,full_config=jsonable(self.config),full_config_sha256=digest(jsonable(self.config)),
            runtime_sha256=self.identity['source_sha256'],host_sha256=host_fingerprint(),run_id=uuid.uuid4().hex,
            batch_id='F1_'+uuid.uuid4().hex,created_at=now,expires_at=now+600,assigned_slots=[1,2],
            total_attempt_cap=2,batch_total_attempt_cap=4,reasoning_enabled=False,manual_start_only=True,
            game_executable=str(self.game),game_executable_sha256=hashlib.sha256(self.game.read_bytes()).hexdigest(),
            game_build_sha256='1'*64)
        self.addCleanup(patch.stopall)
        patch('pokiguard_v2.packaged_reasoning.package_identity',return_value=self.identity).start()
        patch('pokiguard_v2.game_location.validate_supported_game_assembly',return_value='1'*64).start()

    def launch(self):
        self.path.write_text(json.dumps(self.req),encoding='utf-8')
        return PackagedAcceptanceLaunch(self.path,hashlib.sha256(self.path.read_bytes()).hexdigest(),
            paths=self.paths,directory=self.paths.data_root/'timing',game_executable=lambda:self.game)

    def test_valid_preview_has_no_claim_worker_or_auto_start(self):
        x=self.launch();self.assertFalse(x.claimed);self.assertIsNone(x.session);self.assertFalse(x.claim_path.exists())

    def test_exact_package_identity_rejects_wrong_install_root(self):
        with self.assertRaises(ValueError):package_identity(self.paths,self.root/'different.exe')

    def test_source_mode_cannot_use_packaged_gate(self):
        with self.assertRaises(ValueError):package_identity(replace(self.paths,frozen=False),self.exe)

    def test_expired_or_increased_cap_rejected(self):
        for field,value in [('expires_at',self.req['created_at']-1),('total_attempt_cap',3),('batch_total_attempt_cap',5)]:
            old=self.req[field];self.req[field]=value
            with self.subTest(field=field),self.assertRaises(ValueError):self.launch()
            self.req[field]=old

    def test_package_or_game_digest_drift_rejected(self):
        self.req['package']=dict(self.identity,executable_sha256='0'*64)
        with self.assertRaises(ValueError):self.launch()
        self.req['package']=self.identity;self.req['game_executable_sha256']='0'*64
        with self.assertRaises(ValueError):self.launch()

    def test_nonshield_or_foreground_change_rejected(self):
        for field,value in [('demon_target_gem','health'),('input_delivery_mode','background'),('max_match_attempts',3)]:
            old=self.req['full_config'][field];self.req['full_config'][field]=value
            with self.subTest(field=field),self.assertRaises(ValueError):self.launch()
            self.req['full_config'][field]=old

    def test_claim_and_delivery_once_and_copy_with_new_nonce_cannot_reset_batch(self):
        with patch('pokiguard_v2.reasoning_swap_timing.SwapTimingSession') as factory:
            x=self.launch();x.claim(self.config,None);self.assertTrue(x.claim_path.exists())
            self.assertIs(x(self.config),factory.return_value)
            with self.assertRaises(ValueError):x(self.config)
            self.req['run_id']=uuid.uuid4().hex
            with self.assertRaises(ValueError):self.launch()

    def test_changed_config_or_resume_rejected_before_claim(self):
        x=self.launch()
        for cfg,checkpoint in [(replace(self.config,pet_skill_fire_value=3),None),(self.config,object())]:
            with self.assertRaises(ValueError):x.claim(cfg,checkpoint)
        self.assertFalse(x.claim_path.exists())

    def test_request_mutation_between_preview_and_start_rejected(self):
        x=self.launch();self.path.write_text('{}',encoding='utf-8')
        with self.assertRaises(ValueError):x.claim(self.config,None)
        self.assertFalse(x.claim_path.exists())

    def test_unreviewed_reasoning_protocol_cannot_use_basic_request(self):
        self.req['pilot_protocol']='F1_B12_DEMON_SHIELD_PACKAGE2_V1'
        with self.assertRaises((ValueError,KeyError)):self.launch()

    def test_private_request_must_stay_inside_data_root(self):
        self.path=self.root/'outside.json'
        with self.assertRaises(ValueError):self.launch()


if __name__=='__main__':unittest.main()
