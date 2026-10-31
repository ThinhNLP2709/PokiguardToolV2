"""P14 launch/setup tests use temporary files and fake native surfaces only."""
from contextlib import ExitStack
from dataclasses import replace
import hashlib
import json
from pathlib import Path
from types import SimpleNamespace
import tempfile
import time
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.reasoning_operational_launch import OperationalPilotLaunch, operational_policy_json
from pokiguard_v2.reasoning_calibration import decode_config
from pokiguard_v2.reasoning_snapshot import canonical_json, digest
from pokiguard_v2.board_diagnostics import jsonable
from tests import test_reasoning_operational as legacy
from tools.review_reasoning_calibration import export_review, ROOT
from tools import desktop_ui


class OperationalLaunchTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.base=tempfile.TemporaryDirectory(dir=ROOT)
        cls.template=Path(cls.base.name)/'review'
        import shutil
        # Historical launch contract under explicitly mocked P14 source/build;
        # never silently export/rebind the current changed runtime as P14.
        shutil.copytree(ROOT/'docs/phase5/artifacts/5d1_operational_launch_p14_v1/review_final',cls.template)
        cls.review=json.loads((cls.template/'calibration_review.json').read_text(encoding='utf-8'))

    @classmethod
    def tearDownClass(cls):cls.base.cleanup()

    def setUp(self):
        import shutil
        self.temp=tempfile.TemporaryDirectory(dir=ROOT);self.addCleanup(self.temp.cleanup)
        self.root=Path(self.temp.name);self.dir=self.root/'review';shutil.copytree(self.template,self.dir)
        helper=legacy.OperationalLoaderTests();self.data,self.doc=helper.package(self.dir)
        d=self.data;r=self.review
        d.update(runtime_sha256=r['target_runtime_sha256'],host_sha256=r['host_sha256'],
            game_build_sha256=r['game_build_sha256'],policy_json=r['policy_json'],
            witness=r['proposed_scope_witness'],max_read_span_ms=100)
        request=json.loads((self.dir/r['archive_mapping'][r['roles']['request']]['path']).read_text(encoding='utf-8'))
        d['full_config']=request['config'];d['full_config_sha256']=digest(d['full_config'])
        d['game_executable']=str(self.root/'SYNTHETIC.exe');d['game_executable_sha256']='e'*64
        self.config=decode_config(d['full_config'])
        d['calibration']=self.doc('SYNTHETIC_REVIEW.json',r)
        paths=dict(completed=2,timeout=1,error=1,fallback=1)
        q=self.doc('SYNTHETIC_QUALIFICATION.json',dict(pass_all=True,gates=dict(fake_only=True),
            runtime_sha256=d['runtime_sha256'],host_sha256=d['host_sha256'],selector_paths_ms={k:dict(max=v) for k,v in paths.items()}))
        d['selector_allowance']=self.doc('SYNTHETIC_ALLOWANCE.json',dict(scope='OFFLINE_OPERATIONAL_SELECTOR',
            runtime_sha256=d['runtime_sha256'],host_sha256=d['host_sha256'],paths=paths,qualification=q))
        d.update(created_at=time.time()-1,expires_at=time.time()+120)
        self.approve_fake()
        self.stack=ExitStack();self.addCleanup(self.stack.close)
        for name,value in [('pokiguard_v2.reasoning_operational_launch.source_fingerprint',d['runtime_sha256']),
                           ('pokiguard_v2.reasoning_calibration.source_fingerprint',d['runtime_sha256']),
                           ('pokiguard_v2.reasoning_operational_launch.host_fingerprint',d['host_sha256']),
                           ('pokiguard_v2.reasoning_operational.host_fingerprint',d['host_sha256']),
                           ('pokiguard_v2.game_location.validate_supported_game_assembly',d['game_build_sha256']),
                           ('pokiguard_v2.game_location.game_assembly_sha256','e'*64)]:
            self.stack.enter_context(patch(name,return_value=value))

    def approve_fake(self):
        d=self.data
        review={k:d[k] for k in ('run_id','total_attempt_cap','full_config_sha256','runtime_sha256',
                                 'host_sha256','contract_sha256','decision_sha256')}
        d['activation_review']=self.doc('SYNTHETIC_ACTIVATION.json',review|dict(accepted=True,scope='BOUNDED_OPERATIONAL_PILOT'))
        d['activation_sha256']=d['activation_review']['sha256']

    def launch(self):
        path=self.dir/'SYNTHETIC_REQUEST.json';path.write_text(canonical_json(self.data),encoding='utf-8')
        return OperationalPilotLaunch(path,hashlib.sha256(path.read_bytes()).hexdigest(),root=self.root,
            directory=self.root/'pilot',game_executable=lambda:self.data['game_executable'])

    def test_valid_preview_allocates_no_worker_claim_or_game_capability(self):
        with patch('pokiguard_v2.reasoning_pilot.create_pilot_bridge',side_effect=AssertionError('worker')):
            gate=self.launch()
            self.assertIsNone(gate.session);self.assertFalse(gate.claim_path.exists())
            gate.validate_launch(self.config,None)
        self.assertEqual(operational_policy_json(self.config),self.review['policy_json'])
        from tools.basic_auto_bot import build_parser
        self.assertEqual(build_parser().get_default('minimum_action_time'),1)

    def test_production_policy1_can_claim_once_and_deliver_one_session(self):
        gate=self.launch();gate.claim(self.config,None)
        self.assertTrue(gate.claim_path.exists());self.assertTrue(gate.claimed)
        session=gate(self.config);self.addCleanup(session.stop)
        self.assertEqual(session.authority.calibration_samples,26)
        self.assertIsNone(session.adapter)
        with self.assertRaises(ValueError):gate.claim(self.config,None)
        with self.assertRaises(ValueError):gate(self.config)
        with self.assertRaises(ValueError):self.launch()

    def test_missing_independent_approval_rejected_before_claim(self):
        self.data['activation_review']=self.doc('NOT_ACCEPTED.json',dict(accepted=False))
        self.data['activation_sha256']=self.data['activation_review']['sha256']
        with self.assertRaises(ValueError):self.launch()
        self.assertFalse((self.root/'logs/operational_pilot_claims').exists())

    def test_expiry_cap_config_policy_and_resume_fail_closed(self):
        original=json.loads(canonical_json(self.data))
        for fault in ('expiry','cap','config','policy'):
            self.data=json.loads(canonical_json(original))
            if fault=='expiry':self.data['expires_at']=time.time()-1
            elif fault=='cap':self.data['total_attempt_cap']=4
            elif fault=='config':self.data['full_config']['target_completed_matches']=4
            else:self.data['policy_json']=canonical_json(jsonable(legacy.PolicyConfig()))
            with self.subTest(fault=fault),self.assertRaises(ValueError):self.launch()
        self.data=original;gate=self.launch()
        with self.assertRaises(ValueError):gate.validate_launch(self.config,Path('checkpoint.json'))
        with self.assertRaises(ValueError):gate.validate_launch(replace(self.config,target_completed_matches=2),None)

    def test_source_host_build_or_selected_file_drift_rejected(self):
        for name in ('source_fingerprint','host_fingerprint'):
            with self.subTest(name=name),patch('pokiguard_v2.reasoning_operational_launch.'+name,return_value='f'*64),self.assertRaises(ValueError):self.launch()
        with patch('pokiguard_v2.game_location.game_assembly_sha256',return_value='f'*64),self.assertRaises(ValueError):self.launch()
        with patch('pokiguard_v2.game_location.validate_supported_game_assembly',return_value='f'*64),self.assertRaises(ValueError):self.launch()
        gate=self.launch();gate.game_executable=lambda:self.root/'OTHER.exe'
        with self.assertRaises(ValueError):gate.verify()

    def test_mutated_request_after_preview_rejected_at_start(self):
        gate=self.launch();gate.path.write_text('{}',encoding='utf-8')
        with self.assertRaises(ValueError):gate.claim(self.config,None)
        self.assertFalse(gate.claim_path.exists())

    def test_fault_before_session_binding_keeps_claim_consumed(self):
        gate=self.launch();gate.claim(self.config,None);session=gate(self.config)
        with patch('pokiguard_v2.reasoning_pilot.create_pilot_bridge',return_value=None),self.assertRaises(ValueError):
            session.bind_run('SYNTHETIC_FARM',self.root/'farm')
        self.assertEqual(session.prepare_options(),{});self.assertTrue(session.stopped)
        self.assertTrue(gate.claim_path.exists())

    def test_compatibility_rejects_runtime_change_hidden_in_known_setup_file(self):
        from pokiguard_v2.reasoning_calibration_review import source_compatibility
        ref=self.review['source_compatibility'];path=self.dir/ref['path']
        c=json.loads(path.read_text(encoding='utf-8'))
        pair=c['changed']['src/pokiguard_v2/reasoning_operational.py']['after']
        source=self.dir/pair['path'];text=source.read_text(encoding='utf-8')
        self.assertIn('self.stopped = True',text)
        source.write_text(text.replace('self.stopped = True','self.stopped = False',1),encoding='utf-8')
        pair['sha256']=hashlib.sha256(source.read_bytes()).hexdigest()
        c['target_files']['src/pokiguard_v2/reasoning_operational.py']=pair['sha256']
        c['target_runtime_sha256']=digest(c['target_files'])
        path.write_text(canonical_json(c),encoding='utf-8')
        with self.assertRaises(ValueError):source_compatibility(self.dir,
            dict(path=ref['path'],sha256=hashlib.sha256(path.read_bytes()).hexdigest()),
            c['native_runtime_sha256'],c['target_runtime_sha256'])


class OperationalCLIArgumentsTests(unittest.TestCase):
    def test_default_arguments_keep_basic_path_and_no_request(self):
        args=desktop_ui.build_parser().parse_args([]);desktop_ui._validate_args(args)
        self.assertIsNone(args.operational_pilot_request)

    def test_partial_offline_or_mixed_operational_arguments_rejected(self):
        for argv in (['--operational-pilot-request','a.json'],
                     ['--operational-pilot-sha256','0'*64],
                     ['--offline','--operational-pilot-request','a.json','--operational-pilot-sha256','0'*64],
                     ['--basic-calibration-request','b.json','--operational-pilot-request','a.json','--operational-pilot-sha256','0'*64]):
            with self.subTest(argv=argv),self.assertRaises(ValueError):
                desktop_ui._validate_args(desktop_ui.build_parser().parse_args(argv))

    def test_invalid_request_returns_before_runtime_ui_or_ordinary_preference_write(self):
        with tempfile.TemporaryDirectory(dir=ROOT) as name:
            root=Path(name);prefs=root/'preferences.json';prefs.write_text('{}',encoding='utf-8');before=prefs.read_bytes()
            paths=Mock(frozen=False,source_root=root,preferences_file=prefs)
            args=desktop_ui.build_parser().parse_args(['--artifacts',str(root/'ui'),
                '--operational-pilot-request',str(root/'DRAFT.json'),'--operational-pilot-sha256','0'*64])
            with patch.object(desktop_ui,'current_app_paths',return_value=paths), \
                 patch.object(desktop_ui,'configure_diagnostic_image_writes'), \
                 patch('pokiguard_v2.reasoning_operational_launch.OperationalPilotLaunch',side_effect=ValueError('UNAPPROVED')), \
                 patch.object(desktop_ui,'ReadOnlyGameStatusProvider') as native, \
                 patch.object(desktop_ui,'create_root') as ui:
                self.assertEqual(desktop_ui.run(args),2);native.assert_not_called();ui.assert_not_called()
            self.assertEqual(prefs.read_bytes(),before)
            self.assertIn('OPERATIONAL_PILOT_REJECTED',(root/'ui/events.jsonl').read_text(encoding='utf-8'))

    def test_valid_setup_routes_existing_factory_and_private_preferences_without_start(self):
        class BoundaryReached(Exception):pass
        from pokiguard_v2.desktop_control_plane import DesktopConfig
        from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
        from pokiguard_v2.desktop_ui import DesktopEventLog
        with tempfile.TemporaryDirectory(dir=ROOT) as name:
            root=Path(name);prefs=root/'preferences.json';prefs.write_text('{}',encoding='utf-8');before=prefs.read_bytes()
            paths=Mock(frozen=False,source_root=root,preferences_file=prefs,reset_evidence=root/'reset',farm_runs=root/'runs',data_root=root)
            gate=SimpleNamespace(config=DesktopConfig(boss_id='1289',target_completed_matches=3,max_match_attempts=3))
            args=desktop_ui.build_parser().parse_args(['--artifacts',str(root/'ui'),
                '--operational-pilot-request',str(root/'REQUEST.json'),'--operational-pilot-sha256','0'*64])
            logs=[]
            def logger(*args,**kwargs):
                log=DesktopEventLog(*args,**kwargs);logs.append(log);return log
            with patch.object(desktop_ui,'current_app_paths',return_value=paths), \
                 patch.object(desktop_ui,'configure_diagnostic_image_writes'), \
                 patch('pokiguard_v2.reasoning_operational_launch.OperationalPilotLaunch',return_value=gate), \
                 patch.object(desktop_ui,'ReadOnlyGameStatusProvider'), \
                 patch.object(desktop_ui,'DesktopFarmControllerManager') as manager, \
                 patch.object(desktop_ui,'DesktopPreferenceStore',side_effect=DesktopPreferenceStore) as stores, \
                 patch.object(desktop_ui,'DesktopEventLog',side_effect=logger), \
                 patch.object(desktop_ui,'DesktopControlPlane',side_effect=BoundaryReached) as control, \
                 patch.object(desktop_ui,'create_root') as ui, self.assertRaises(BoundaryReached):
                try:desktop_ui.run(args)
                finally:
                    self.assertIs(manager.call_args.kwargs['reasoning_session_factory'],gate)
                    self.assertIs(manager.call_args.kwargs['calibration_gate'],gate)
                    self.assertEqual(control.call_args.kwargs['config'],gate.config)
                    self.assertEqual(stores.call_args.args[0],root/'ui/session_preferences.json')
                    ui.assert_not_called()
                    for log in logs:log.close()  # Fake boundary owns test cleanup.
            self.assertEqual(prefs.read_bytes(),before)


class OperationalDraftTests(unittest.TestCase):
    def test_draft_has_no_run_expiry_claim_or_accepted_live_review(self):
        import shutil
        from tools.prepare_operational_pilot import prepare_draft
        old=ROOT/'docs/phase5/artifacts/5d1_calibration_review_p13_v1'
        with tempfile.TemporaryDirectory(dir=ROOT) as name:
            directory=Path(name);review=directory/'review'
            shutil.copytree(old/'review_final',review,ignore=shutil.ignore_patterns('qualification','selector_allowance.json','readiness.json'))
            q=json.loads((old/'qualification_final/qualification.json').read_text(encoding='utf-8'))
            # Explicit historical pin fixture; no current-source acceptance.
            with patch('tools.prepare_operational_pilot.source_fingerprint',return_value=q['runtime_sha256']), \
                 patch('tools.prepare_operational_pilot.host_fingerprint',return_value=q['host_sha256']), \
                 patch('pokiguard_v2.reasoning_operational_launch.OperationalPilotSession',side_effect=AssertionError('claim')):
                draft=prepare_draft(review/'calibration_review.json',old/'qualification_final/qualification.json',directory/'draft')
            self.assertIs(draft['accepted'],False);self.assertIs(draft['live_acceptance'],False)
            self.assertIsNone(draft['override_quota']);self.assertIsNone(draft['run_id']);self.assertIsNone(draft['expires_at'])
            self.assertIsNone(draft['request_template']['activation_review'])
            self.assertFalse(draft['claim_created'])

    def test_normal_completed_retention_raw_qualification_is_valid(self):
        from tools.prepare_operational_pilot import validate_qualification
        directory=ROOT/'docs/phase5/artifacts/5d1_calibration_review_p13_v1/qualification_final'
        q=json.loads((directory/'qualification.json').read_text(encoding='utf-8'))
        validate_qualification(directory,q)
        self.assertEqual(q['measured_path_outcomes']['completed']['root'],'RETAIN_BASELINE')

    def test_forged_measurement_summary_cannot_be_used_as_allowance(self):
        from tools.prepare_operational_pilot import validate_qualification
        directory=ROOT/'docs/phase5/artifacts/5d1_calibration_review_p13_v1/qualification_final'
        q=json.loads((directory/'qualification.json').read_text(encoding='utf-8'))
        q['selector_paths_ms']['completed']['max']=0
        with self.assertRaises(ValueError):validate_qualification(directory,q)


if __name__=='__main__':unittest.main()
