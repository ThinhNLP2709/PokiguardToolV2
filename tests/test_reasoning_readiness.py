"""P3 setup/export/clock tests with file/native fakes only."""
from dataclasses import replace
import hashlib, json
from pathlib import Path
import tempfile, time, unittest
from unittest.mock import patch
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.reasoning_calibration import (BasicCalibrationActivation,build_request,decode_config,source_fingerprint)
from pokiguard_v2.reasoning_snapshot import canonical_json
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.reasoning_swap_timing import SwapTimingCollector
from tests.test_reasoning_pilot import MemorySink,scoped_state
from tools.basic_calibration import export
from tests import test_reasoning_pilot_preparation as artifact_fixture


class ActivationTests(unittest.TestCase):
    def setUp(self):
        self.temp=tempfile.TemporaryDirectory();self.addCleanup(self.temp.cleanup)
        self.root=Path(self.temp.name);(self.root/'src').mkdir();(self.root/'src/a.py').write_text('x=1\n')
        self.exe=self.root/'PetPuzzle.exe';self.exe.write_bytes(b'SYNTHETIC')
        (self.root/'GameAssembly.dll').write_bytes(b'SYNTHETIC')
        self.config=DesktopConfig(boss_id='1',boss_name='OFFLINE',max_match_attempts=3)
        self.patch=patch('pokiguard_v2.reasoning_calibration.validate_supported_game_assembly',return_value='1'*64)
        self.patch.start();self.addCleanup(self.patch.stop)
        self.data=build_request(self.root,self.config,self.exe,cohort='SYNTHETIC ONLY')
        self.path=self.root/'request.json';self.path.write_text(canonical_json(self.data))
        self.sha=hashlib.sha256(self.path.read_bytes()).hexdigest()

    def activation(self,**kwargs):
        return BasicCalibrationActivation(self.path,self.sha,root=self.root,directory=self.root/'ai',
          game_executable=lambda:self.exe,**kwargs)

    def test_roundtrip_full_config_and_no_resources_before_start(self):
        self.assertEqual(decode_config(jsonable(self.config)),self.config)
        a=self.activation();self.assertIsNone(a.session);self.assertFalse(a.claim_path.exists())
        self.assertFalse((self.root/'ai').exists())

    def test_source_build_and_expiry_rechecked_before_claim(self):
        a=self.activation();(self.root/'src/a.py').write_text('x=2\n')
        with self.assertRaises(ValueError):a.claim(self.config,None)
        self.assertFalse(a.claim_path.exists())
        with self.assertRaises(ValueError):self.activation(now=self.data['expires_at'])

    def test_config_drift_resume_and_restart_do_not_reset_cap(self):
        a=self.activation()
        for config,checkpoint in ((replace(self.config,max_match_attempts=4),None),(self.config,Path('checkpoint'))):
            with self.assertRaises(ValueError):a.validate_launch(config,checkpoint)
        a.claim(self.config,None)
        with self.assertRaises(ValueError):a.claim(self.config,None)
        with self.assertRaises(ValueError):self.activation()
        duplicate=self.root/'copied_request.json';duplicate.write_bytes(self.path.read_bytes())
        with self.assertRaises(ValueError):
            BasicCalibrationActivation(duplicate,self.sha,root=self.root,directory=self.root/'another_ai',
              game_executable=lambda:self.exe)

    def test_session_is_basic_only_stop_signal_and_no_second_factory(self):
        sink=MemorySink();sink.stop=lambda:None;sink.flush=lambda timeout:True;sink.close=lambda timeout:True
        with patch('pokiguard_v2.reasoning_swap_timing.BoundedDiagnostics',return_value=sink):
            a=self.activation();a.claim(self.config,None);s=a(self.config)
            self.assertEqual(set(s.prepare_options()),{'swap_timing_adapter'})
            s.bind_run('farm',self.root/'farm');self.assertTrue((self.root/'ai/session.json').is_file())
            s.stop();self.assertEqual(s.prepare_options(),{})
            s.finalizer.join(3);self.assertFalse(s.finalizer.is_alive())
            with self.assertRaises(ValueError):a(self.config)

    def test_wrong_hash_executable_or_missing_fields_rejected(self):
        self.sha='0'*64
        with self.assertRaises(ValueError):self.activation()
        with self.assertRaises(ValueError):decode_config({})

    def test_cap_max5_and_nonforeground_are_rejected(self):
        from pokiguard_v2.input_delivery import InputDeliveryMode
        for c in (replace(self.config,max_match_attempts=6),
                  replace(self.config,input_delivery_mode=InputDeliveryMode.PINNED_FOREGROUND_LEASE_BETA)):
            with self.assertRaises(ValueError):build_request(self.root,c,self.exe,cohort='OFFLINE')

    def test_existing_manager_start_is_one_shot_and_drift_is_rejected(self):
        from pokiguard_v2.desktop_farm_controller import DesktopFarmControllerManager
        a=self.activation();reset=self.root/'reset.json';reset.write_text('{}')
        calls=[]
        manager=DesktopFarmControllerManager(self.root,runner=lambda *args:calls.append(args) or 0,
          reset_evidence=reset,calibration_gate=a)
        self.assertFalse(manager.start(replace(self.config,max_match_attempts=4)).accepted)
        self.assertFalse(a.claimed)
        self.assertTrue(manager.start(self.config).accepted)
        end=time.perf_counter()+3
        while manager.snapshot().active and time.perf_counter()<end:time.sleep(.01)
        self.assertFalse(manager.snapshot().active);self.assertEqual(len(calls),1)
        self.assertFalse(manager.start(self.config).accepted)

    def test_desktop_parser_has_no_implicit_request(self):
        from tools.desktop_ui import build_parser
        args=build_parser().parse_args([])
        self.assertIsNone(args.basic_calibration_request);self.assertIsNone(args.basic_calibration_sha256)


class TimingExportTests(unittest.TestCase):
    def test_real_timing_writer_flushes_off_stop_and_exports_watermark(self):
        from pokiguard_v2.reasoning_swap_timing import SwapTimingSession,SwapTimingRequest
        from pokiguard_v2.basic_policy import PolicyConfig
        with tempfile.TemporaryDirectory() as d:
            root=Path(d);config=DesktopConfig(max_match_attempts=3)
            session=SwapTimingSession(SwapTimingRequest('OFFLINE',canonical_json(jsonable(config)),3),
              config=config,directory=root/'ai')
            session.bind_run('farm',root/'farm')
            session.collector.start(state=scoped_state(),config=PolicyConfig(),input_mode='foreground',source_hash='s')
            # Positive warm-writer Stop timing; cold spawn is not a .5s
            # durability guarantee. This wait is outside the measured Stop.
            self.assertTrue(session.sink.flush(3),session.sink.buffer.stats())
            start=time.perf_counter_ns();session.stop();elapsed=(time.perf_counter_ns()-start)/1e6
            self.assertLess(elapsed,25)
            session.finalizer.join(3);self.assertFalse(session.finalizer.is_alive())
            watermark=json.loads((root/'ai/watermarks.json').read_text())
            self.assertTrue(watermark['flushed']);self.assertTrue(watermark['closed'])
            self.assertEqual(watermark['before_close']['written'],1)

    def test_stop_logging_failure_still_closes_collector(self):
        from pokiguard_v2.basic_policy import PolicyConfig
        sink=MemorySink();c=SwapTimingCollector(sink=sink,run_id='OFFLINE')
        c.start(state=scoped_state(),config=PolicyConfig(),input_mode='foreground',source_hash='s')
        with patch.object(sink,'enqueue',side_effect=OSError('SYNTHETIC_DISK_FAULT')):c.stop()
        self.assertTrue(c.stopped);self.assertTrue(c.disabled);self.assertIsNone(c.pending)

    def test_stop_preserves_incomplete_interval_without_claiming_input(self):
        from pokiguard_v2.basic_policy import PolicyConfig
        sink=MemorySink();c=SwapTimingCollector(sink=sink,run_id='OFFLINE')
        c.start(state=scoped_state(),config=PolicyConfig(),input_mode='foreground',source_hash='s')
        c.stop();c.stop()
        self.assertEqual(len(sink.buffer.items),1)
        row=json.loads(sink.buffer.items[0])['payload']
        self.assertEqual(row['status'],'STOP_OR_CONTROLLER_EXIT');self.assertFalse(row['required_input_completed'])

    def test_export_joins_full_source_and_retains_all_attempts(self):
        from pokiguard_v2.basic_policy import PolicyConfig
        from pokiguard_v2.win32_input import ClickStatus
        from types import SimpleNamespace
        with tempfile.TemporaryDirectory() as d:
            root=Path(d);timing=root/'ai';farm=root/'farm';timing.mkdir();(farm/'matches/attempt_001').mkdir(parents=True)
            config=DesktopConfig(boss_id='1',max_match_attempts=3)
            req=dict(schema='pokiguard.basic_calibration_request.v1',run_id='OFFLINE',config=jsonable(config),
              total_attempt_cap=3,source_sha256='SYNTHETIC',game_build_sha256='SYNTHETIC')
            request=root/'request.json';request.write_text(canonical_json(req));request_sha=hashlib.sha256(request.read_bytes()).hexdigest()
            (timing/'session.json').write_text(canonical_json(dict(run_id='OFFLINE',farm_run_id='farm',
              farm_directory=str(farm.resolve()),config_json=canonical_json(req['config']),total_attempt_cap=3)))
            sink=MemorySink();c=SwapTimingCollector(sink=sink,run_id='OFFLINE')
            state=scoped_state();state=replace(state,battle=replace(state.battle,turn_timer_source='MatchService.server_tick'))
            c.start(state=state,config=PolicyConfig(),input_mode='foreground',source_hash='s')
            c.preflight(remaining=12,failure=None,read_end_ns=time.perf_counter_ns())
            c.finish(result=SimpleNamespace(sent_clicks=2,input_mode='two_click',status=ClickStatus.SENT))
            raw=sink.buffer.items[0];(timing/'timing.jsonl').write_bytes(raw)
            source=json.loads(raw)['payload']['autonomous_source']
            rows=[dict(event='action_sent',action='SWAP',identity=dict(source=source)),
                  dict(event='action_result',result='SWAP_ACKNOWLEDGED',action=dict(identity=dict(source=source)))]
            combat=farm/'matches/attempt_001/combat.jsonl';combat.write_text('\n'.join(canonical_json(r) for r in rows))
            attempts=[dict(attempt_index=1,local_turns=2,result='LOSS'),dict(attempt_index=2,local_turns=0,result='UNKNOWN')]
            (farm/'run.json').write_text(canonical_json(dict(snapshot=dict(farm_run_id='farm',attempts=attempts,
              match_attempts=2,limits=dict(max_match_attempts=3)))))
            report=export(request,request_sha,timing,farm)
            self.assertEqual(report['all_attempt_count'],2);self.assertEqual(report['local_turn_cost'],2)
            self.assertTrue(report['samples'][0]['eligible_for_descriptive_R']);self.assertFalse(report['reasoning_authority'])
            self.assertIsNone(report['U_ms']);self.assertEqual(report['R_descriptive_ms']['N'],1)
            self.assertIn('MISSING_FINAL_DIAGNOSTIC_WATERMARK',report['errors'])
            pending=sink.buffer.take();sink.buffer.finish(pending,written=True)
            watermark=dict(run_id='OFFLINE',flushed=True,closed=True,collector_dropped=0,
              collector_disabled=False,before_close=sink.buffer.stats())
            (timing/'watermarks.json').write_text(canonical_json(watermark))
            self.assertEqual(export(request,request_sha,timing,farm)['errors'],[])
            combat.write_text(combat.read_text()+'\n'+canonical_json(rows[-1]))
            self.assertFalse(export(request,request_sha,timing,farm)['samples'][0]['eligible_for_descriptive_R'])
            (timing/'timing.jsonl').write_bytes(b'')
            self.assertIn('MISSING_TIMING_FOR_SENT_SWAP',export(request,request_sha,timing,farm)['errors'])


class ClockProofTests(unittest.TestCase):
    def test_verdict_label_and_uncovered_sum_are_insufficient(self):
        helper=artifact_fixture.ArtifactTests()
        for kind in ('no_derivation','underestimated','bad_evidence'):
            with self.subTest(kind=kind),tempfile.TemporaryDirectory() as d:
                root=Path(d);data,policy=helper.make_data(root);proof=json.loads((root/'bound.json').read_text())
                if kind=='no_derivation':proof.pop('derivation')
                elif kind=='underestimated':proof['uncertainty_ms']=999
                else:proof['derivation']['components'][0]['evidence'][0]['sha256']='0'*64
                (root/'bound.json').write_text(canonical_json(proof))
                data['timer_bound']['report_sha256']=hashlib.sha256((root/'bound.json').read_bytes()).hexdigest()
                with self.assertRaises(ValueError):helper.load(root/'pilot.json',data,policy)


if __name__=='__main__':unittest.main()
