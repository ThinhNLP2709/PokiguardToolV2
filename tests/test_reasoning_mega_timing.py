"""No game/process/input surfaces; synthetic clocks and immutable native files."""
import ast
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import tempfile
import time
from types import SimpleNamespace as NS
import unittest
from unittest.mock import patch

from pokiguard_v2.reasoning_mega_timing import input_interval,MegaClickTimingCollector,MegaClickTimingSession
from pokiguard_v2.reasoning_calibration import (D4_CONTROL_PROTOCOL,D4_INPUT_TIMING_PROTOCOL,
    check_config,d4_probe_run_id,verify_d4_probe_parent,SwapTimingRequest,BasicCalibrationActivation,SCHEMA)
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.reasoning_snapshot import canonical_json
from tests.test_reasoning_d4_control import config
from tests.test_reasoning_pilot import MemorySink

ROOT=Path(__file__).resolve().parents[1]
NATIVE=ROOT/'docs/phase5/artifacts/5d4_smallblue_basic3_live_20261018_041121'


def result(**changes):
    values=dict(kind=NS(value='SUCCESS_NO_ACTION'),card_clicks=1,space_presses=0,
        direction_presses=0,telemetry=NS(card_click_timestamp=10.25))
    values.update(changes);return NS(**values)


class InputTimingTests(unittest.TestCase):
    def test_production_wrapper_records_skill_instead_of_silently_skipping_subclass(self):
        from pokiguard_v2.reasoning_swap_timing import timing_safely
        sink=MemorySink();c=MegaClickTimingCollector(sink=sink,run_id='FAKE_WRAPPER')
        c.input_clock=dict(implementation='FAKE_TICKS',resolution_seconds=.015625)
        c.decision_interval=dict(decision_exit_ns=99_800_000_000,decision_source_hash='HASH')
        with patch('pokiguard_v2.reasoning_mega_timing.time.monotonic',side_effect=[10,22]), \
             patch('pokiguard_v2.reasoning_mega_timing.time.perf_counter_ns',side_effect=[100_000_000_000,112_000_000_000,112_000_001_000]):
            timing_safely(c,'skill_start',match_id='FAKE',turn=3,source_hash='HASH',skill_card_id=22)
            timing_safely(c,'skill_finish',result=result())
        self.assertEqual(len(sink.buffer.items),1,'production wrapper silently dropped the collector')
        p=json.loads(sink.buffer.items[0])['payload']
        self.assertEqual(p['click_only_input']['required_input_upper_ms'],282.25)
        self.assertEqual(p['full_primitive_ns'],12_000_000_000)

    def test_unknown_subclasses_still_have_no_wrapper_access(self):
        from pokiguard_v2.reasoning_swap_timing import SwapTimingCollector,timing_safely
        class Unknown(SwapTimingCollector):pass
        for unknown in (Unknown(sink=MemorySink()),object(),None):
            timing_safely(unknown,'method_that_must_not_be_called')
        sink=MemorySink();c=Unknown(sink=sink,measure_skills=True)
        timing_safely(c,'skill_start',match_id='FAKE',turn=1,source_hash='HASH',skill_card_id=22)
        self.assertIsNone(c.skill_interval);self.assertEqual(len(sink.buffer.items),0)

    def test_real_controller_wrapper_collects_and_preserves_read_capture_input_ack_order(self):
        from tests.reasoning_controller_fixture import controller_trace
        with tempfile.TemporaryDirectory() as name:
            plain=controller_trace(Path(name)/'plain.jsonl')
            sink=MemorySink();holders=[]
            def factory(state,config):
                c=MegaClickTimingCollector(sink=sink,run_id='OFFLINE_CONTROLLER');holders.append(c);return c
            measured=controller_trace(Path(name)/'measured.jsonl',timing_factory=factory)
            self.assertEqual(plain[0],measured[0]);self.assertEqual(plain[1],measured[1])
            def actions(rows):
                return [(e['event'],e.get('action'),e.get('result'),e.get('move')) for e in rows
                    if e['event'] in ('policy_decision','action_sent','action_result','action_terminal')]
            self.assertEqual(actions(plain[2]),actions(measured[2]))
            records=[json.loads(x) for x in sink.buffer.items]
            self.assertTrue(any(e['event_type']=='reasoning.swap_timing' for e in records))
            self.assertTrue(holders[0].stopped);self.assertGreater(holders[0].sequence,0)

    def test_zero_callbacks_marks_measurement_unavailable_instead_of_false_empty_success(self):
        c=replace(config(),target_completed_matches=1,max_match_attempts=1)
        req=SwapTimingRequest('FAKE',canonical_json(jsonable(c)),1)
        sink=MemorySink();sink.stop=lambda:None
        with patch('pokiguard_v2.reasoning_swap_timing.BoundedDiagnostics',return_value=sink):
            session=MegaClickTimingSession(req,config=c,directory=Path('UNUSED'))
            session.stop()
            self.assertTrue(session.collector.disabled)
            self.assertEqual(session.collector.fault_reason,'D4_PROBE_NO_MEASUREMENT_RECORDS')
            self.assertTrue(session.stopped);self.assertEqual(session.collector.sequence,0)

    def test_real_session_options_wrapper_writer_and_watermark_roundtrip_without_game(self):
        from pokiguard_v2.reasoning_swap_timing import prepare_reasoning_options_safely,timing_safely
        c=replace(config(),target_completed_matches=1,max_match_attempts=1)
        req=SwapTimingRequest('FAKE_DURABLE',canonical_json(jsonable(c)),1)
        with tempfile.TemporaryDirectory() as name:
            path=Path(name);session=MegaClickTimingSession(req,config=c,directory=path/'timing')
            session.bind_run('FAKE_NO_GAME',path/'farm')
            collector=prepare_reasoning_options_safely(session)['swap_timing_adapter']
            collector.decision_interval=dict(decision_exit_ns=time.perf_counter_ns(),decision_source_hash='FAKE')
            timing_safely(collector,'skill_start',match_id='FAKE',turn=3,source_hash='FAKE',skill_card_id=22)
            fake_result=result(telemetry=NS(card_click_timestamp=time.monotonic()))
            timing_safely(collector,'skill_finish',result=fake_result)
            # This positive roundtrip tests a durable record, not a guarantee
            # that cold Windows spawn finishes inside the runtime's .5s drain.
            # Test-only warm-up; the production Stop/drain bound is unchanged.
            self.assertTrue(session.sink.flush(3),session.sink.buffer.stats())
            session.stop();session.finalizer.join(4)
            self.assertFalse(session.finalizer.is_alive())
            water=json.loads((path/'timing/watermarks.json').read_text('utf-8'))
            self.assertTrue(water['flushed']);self.assertTrue(water['closed'])
            self.assertEqual(water['sequence'],1);self.assertEqual(water['before_close']['written'],1)
            self.assertFalse(water['collector_disabled']);self.assertEqual(water['collector_dropped'],0)
            records=[json.loads(line) for p in (path/'timing').glob('*.jsonl') for line in p.read_text('utf-8').splitlines()]
            self.assertEqual(len(records),1)
            self.assertEqual(records[0]['payload']['click_only_input']['status'],'OBSERVED_PADDED_ELAPSED')
            self.assertFalse(records[0]['input_authority'])

    def test_retry_parent_counts_failed_probe_and_never_resets_original_claim(self):
        from pokiguard_v2.reasoning_calibration import verify_d4_retry_parent,d4_retry_run_id,D4_INPUT_RETRY_PROTOCOL
        failed=ROOT/'docs/phase5/artifacts/5d4_input_probe1_live_20261018_125726/closure.json'
        parent=NATIVE/'closure.json'
        data=dict(native_parent=dict(path=parent.relative_to(ROOT).as_posix(),sha256=hashlib.sha256(parent.read_bytes()).hexdigest()),
            retry_parent=dict(path=failed.relative_to(ROOT).as_posix(),sha256=hashlib.sha256(failed.read_bytes()).hexdigest()),
            previous_attempts_consumed=4,probe_attempt_cap=1,remaining_after_probe=1,total_case_cap=6)
        data['run_id']=d4_retry_run_id(data['retry_parent']['sha256'])
        verify_d4_retry_parent(data,ROOT)
        self.assertNotEqual(data['run_id'],d4_probe_run_id(data['native_parent']['sha256']))
        verify_d4_retry_parent(dict(data,remaining_after_probe=2,total_case_cap=7),ROOT)
        for change in (dict(previous_attempts_consumed=3),dict(remaining_after_probe=2),dict(total_case_cap=7),
                dict(total_case_cap=8),dict(run_id='a'*32),dict(probe_attempt_cap=2)):
            with self.subTest(change=change),self.assertRaises(ValueError):verify_d4_retry_parent(dict(data,**change),ROOT)
        check_config(replace(config(),target_completed_matches=1,max_match_attempts=1),1,profile_protocol=D4_INPUT_RETRY_PROTOCOL)

    def test_retry_drafts_need_authorization_and_both_allocations_share_one_claim(self):
        from tools.prepare_d4_control import prepare,activate
        from pokiguard_v2.reasoning_calibration import D4_INPUT_RETRY_PROTOCOL
        from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
        from pokiguard_v2.desktop_control_plane import DesktopConfig
        with tempfile.TemporaryDirectory() as name:
            root=Path(name);prefs=root/'prefs.json';DesktopPreferenceStore(prefs).save(DesktopConfig());before=prefs.read_bytes()
            for source in (NATIVE/'closure.json',ROOT/'docs/phase5/artifacts/5d4_input_probe1_live_20261018_125726/closure.json'):
                target=root/source.relative_to(ROOT);target.parent.mkdir(parents=True,exist_ok=True);target.write_bytes(source.read_bytes())
            exe=root/'FAKE.exe';exe.write_bytes(b'NO_GAME')
            def build(_root,c,game,**kwargs):
                return dict(schema=SCHEMA,run_id='a'*32,reasoning_enabled=False,created_at=1000,expires_at=2000,
                    source_sha256='s',host_sha256='h',game_executable=str(exe),game_executable_sha256='e',
                    game_build_sha256='b',config=jsonable(c),total_attempt_cap=1,profile_protocol=kwargs['profile_protocol'])
            with patch('tools.prepare_d4_control.ROOT',root), \
                 patch('tools.prepare_d4_control.source_fingerprint',return_value='s'), \
                 patch('tools.prepare_d4_control.build_request',side_effect=build):
                with self.assertRaises(ValueError):prepare(prefs,exe,root/'bad.json',total_cap=7)
                one=prepare(prefs,exe,root/'six.json',retry=True,total_cap=6)
                two=prepare(prefs,exe,root/'seven.json',retry=True,total_cap=7)
                self.assertFalse(one['accepted']);self.assertFalse(two['request_created'])
                self.assertEqual((one['planned_basic_attempts'],one['planned_reasoning_attempts']),(5,1))
                self.assertEqual((two['planned_basic_attempts'],two['planned_reasoning_attempts']),(5,2))
                with self.assertRaises(ValueError):activate(root/'seven.json',root/'blank.json',authorization='')
                a1=activate(root/'six.json',root/'req6.json',authorization='SYNTHETIC_TEST_ONLY')
                a2=activate(root/'seven.json',root/'req7.json',authorization='SYNTHETIC_TEST_ONLY')
                self.assertEqual(a1['run_id'],a2['run_id']);self.assertEqual(a2['profile_protocol'],D4_INPUT_RETRY_PROTOCOL)
                self.assertEqual(before,prefs.read_bytes())
            with patch('pokiguard_v2.reasoning_calibration.time.time',return_value=1001), \
                 patch('pokiguard_v2.reasoning_calibration.host_fingerprint',return_value='h'), \
                 patch('pokiguard_v2.reasoning_calibration.source_fingerprint',return_value='s'), \
                 patch('pokiguard_v2.reasoning_calibration.validate_supported_game_assembly',return_value='b'), \
                 patch('pokiguard_v2.reasoning_calibration.game_assembly_sha256',return_value='e'), \
                 patch('pokiguard_v2.reasoning_mega_timing.MegaClickTimingSession') as factory:
                make=lambda p:BasicCalibrationActivation(p,hashlib.sha256(p.read_bytes()).hexdigest(),root=root,
                    directory=root/'timing',game_executable=lambda:exe)
                activation=make(root/'req7.json');factory.assert_not_called()
                activation.claim(activation.config,None)
                with self.assertRaises(ValueError):make(root/'req6.json')
                self.assertIs(activation(activation.config),factory.return_value)
                self.assertNotIn('selection_adapter',factory.call_args.kwargs)

    def test_same_clock_complete_click_excludes_readonly_wait_without_subtracting_qpc(self):
        start=dict(monotonic_start=10,implementation='FAKE_TICKS',resolution_seconds=.015625)
        value=input_interval(start,result(),22)
        self.assertEqual(value['status'],'OBSERVED_PADDED_ELAPSED')
        self.assertEqual(value['required_input_upper_ms'],282.25)
        self.assertEqual(value['post_click_readonly_elapsed_ms'],11750)
        self.assertFalse(value['exact_click_timestamp']);self.assertFalse(value['input_authority'])
        self.assertFalse(value['sample_max_is_future_bound'])

    def test_explicit_repeat_requires_exact_consumed_foreground_stop_and_cap8(self):
        from pokiguard_v2.reasoning_calibration import verify_d4_retry_parent,d4_retry_run_id
        frozen_root=ROOT/'docs/phase5/artifacts/5d4_input_repeat1_live_20261018_143456/native_source'
        old=ROOT/'docs/phase5/artifacts/5d4_input_probe1_live_20261018_125726/closure.json'
        stopped=ROOT/'docs/phase5/artifacts/5d4_input_retry1_live_20261018_140315/closure.json'
        ref=lambda p:dict(path=p.relative_to(ROOT).as_posix(),sha256=hashlib.sha256(p.read_bytes()).hexdigest())
        data=dict(native_parent=ref(NATIVE/'closure.json'),prior_retry_parent=ref(old),retry_parent=ref(stopped),
            previous_attempts_consumed=5,probe_attempt_cap=1,remaining_after_probe=2,total_case_cap=8,
            planned_basic_attempts=6,planned_reasoning_attempts=2,run_id=d4_retry_run_id(ref(stopped)['sha256']))
        verify_d4_retry_parent(data,ROOT)
        self.assertNotEqual(data['run_id'],d4_retry_run_id(ref(old)['sha256']))
        for change in (dict(previous_attempts_consumed=4),dict(probe_attempt_cap=2),dict(total_case_cap=7),
                dict(total_case_cap=9),dict(remaining_after_probe=3),dict(planned_reasoning_attempts=1),
                dict(planned_basic_attempts=5),dict(prior_retry_parent={}),dict(run_id='a'*32)):
            with self.subTest(change=change),self.assertRaises(ValueError):verify_d4_retry_parent(dict(data,**change),ROOT)
        manifest=json.loads((stopped.parent/'native_source_manifest.json').read_text('utf-8'))
        allowed={'src/pokiguard_v2/reasoning_calibration.py','tools/prepare_d4_control.py',
            'tests/reasoning_controller_fixture.py','tests/test_reasoning_mega_timing.py'}
        for name,h in manifest['files'].items():
            if name not in allowed:self.assertEqual(hashlib.sha256((frozen_root/name).read_bytes()).hexdigest(),h,name)
        name='src/pokiguard_v2/reasoning_calibration.py'
        before=ast.parse((stopped.parent/'native_source'/name).read_text('utf-8'))
        after=ast.parse((frozen_root/name).read_text('utf-8'))
        for tree in (before,after):
            tree.body=[n for n in tree.body if not (isinstance(n,ast.FunctionDef) and n.name=='verify_d4_retry_parent')]
        self.assertEqual(ast.dump(before),ast.dump(after),'repeat changed runtime beyond setup parent admission')

    def test_repeat_preview_and_single_start_preserve_prior_claim_and_preferences(self):
        from tools.prepare_d4_control import prepare,activate
        from pokiguard_v2.reasoning_calibration import D4_INPUT_RETRY_PROTOCOL,d4_retry_run_id
        from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
        from pokiguard_v2.desktop_control_plane import DesktopConfig
        with tempfile.TemporaryDirectory() as name:
            root=Path(name);prefs=root/'prefs.json';DesktopPreferenceStore(prefs).save(DesktopConfig());before=prefs.read_bytes()
            old=ROOT/'docs/phase5/artifacts/5d4_input_probe1_live_20261018_125726/closure.json'
            stopped=ROOT/'docs/phase5/artifacts/5d4_input_retry1_live_20261018_140315/closure.json'
            for source in (NATIVE/'closure.json',old,stopped):
                target=root/source.relative_to(ROOT);target.parent.mkdir(parents=True,exist_ok=True);target.write_bytes(source.read_bytes())
            oldclaim=root/'logs/basic_calibration_claims'/(d4_retry_run_id(hashlib.sha256(old.read_bytes()).hexdigest())+'.json')
            oldclaim.parent.mkdir(parents=True);oldclaim.write_bytes(b'PRESERVE_CONSUMED_CLAIM')
            exe=root/'FAKE.exe';exe.write_bytes(b'NO_GAME')
            def build(_root,c,game,**kwargs):
                return dict(schema=SCHEMA,run_id='a'*32,reasoning_enabled=False,created_at=1000,expires_at=2000,
                    source_sha256='s',host_sha256='h',game_executable=str(exe),game_executable_sha256='e',
                    game_build_sha256='b',config=jsonable(c),total_attempt_cap=1,profile_protocol=kwargs['profile_protocol'])
            with patch('tools.prepare_d4_control.ROOT',root), \
                 patch('tools.prepare_d4_control.source_fingerprint',return_value='s'), \
                 patch('tools.prepare_d4_control.build_request',side_effect=build):
                draft=root/'draft8.json';d=prepare(prefs,exe,draft,retry=True,total_cap=8)
                self.assertEqual((d['previous_attempts_consumed'],d['planned_basic_attempts'],d['planned_reasoning_attempts']),(5,6,2))
                self.assertFalse(d['accepted']);self.assertFalse(d['request_created'])
                with self.assertRaises(ValueError):prepare(prefs,exe,root/'bad9.json',retry=True,total_cap=9)
                with self.assertRaises(ValueError):activate(draft,root/'blank.json',authorization='')
                request=root/'repeat.json';one=activate(draft,request,authorization='SYNTHETIC_EXPLICIT_REPEAT')
                self.assertEqual(one['total_case_cap'],8);self.assertFalse(one['reasoning_enabled'])
                self.assertEqual(one['total_attempt_cap'],1);self.assertEqual(one['remaining_after_probe'],2)
            with patch('pokiguard_v2.reasoning_calibration.time.time',return_value=1001), \
                 patch('pokiguard_v2.reasoning_calibration.host_fingerprint',return_value='h'), \
                 patch('pokiguard_v2.reasoning_calibration.source_fingerprint',return_value='s'), \
                 patch('pokiguard_v2.reasoning_calibration.validate_supported_game_assembly',return_value='b'), \
                 patch('pokiguard_v2.reasoning_calibration.game_assembly_sha256',return_value='e'), \
                 patch('pokiguard_v2.reasoning_mega_timing.MegaClickTimingSession') as factory:
                make=lambda:BasicCalibrationActivation(request,hashlib.sha256(request.read_bytes()).hexdigest(),root=root,
                    directory=root/'timing',game_executable=lambda:exe)
                a=make();factory.assert_not_called();self.assertFalse(a.claim_path.exists())
                a.claim(a.config,None)
                with self.assertRaises(ValueError):make()
                self.assertIs(a(a.config),factory.return_value)
            self.assertEqual(before,prefs.read_bytes());self.assertEqual(oldclaim.read_bytes(),b'PRESERVE_CONSUMED_CLAIM')

    def test_missing_interval_failed_or_extra_input_never_calibrates(self):
        start=dict(monotonic_start=10,implementation='FAKE',resolution_seconds=.015625)
        cases=[None,result(kind=NS(value='UNCERTAIN')),result(card_clicks=0),result(card_clicks=2),result(card_clicks=True),
            result(space_presses=1),result(direction_presses=1),
            result(telemetry=NS(card_click_timestamp=9)),result(telemetry=NS(card_click_timestamp=23)),
            result(telemetry=NS(card_click_timestamp=float('nan'))),result(telemetry=None)]
        for item in cases:
            with self.subTest(item=item):
                self.assertEqual(input_interval(start,item,22)['status'],'UNPROVEN')
        for modified in ({},dict(start,resolution_seconds=0),dict(start,resolution_seconds=float('nan'))):
            self.assertEqual(input_interval(modified,result(),22)['status'],'UNPROVEN')

    def test_whole_primitive_record_retained_beside_new_input_interval(self):
        sink=MemorySink();c=MegaClickTimingCollector(sink=sink,run_id='FAKE')
        c.input_clock=dict(implementation='FAKE_TICKS',resolution_seconds=.015625)
        c.decision_interval=dict(decision_exit_ns=99_800_000_000,decision_source_hash='HASH')
        with patch('pokiguard_v2.reasoning_mega_timing.time.monotonic',side_effect=[10,22]), \
             patch('pokiguard_v2.reasoning_mega_timing.time.perf_counter_ns',side_effect=[100_000_000_000,112_000_000_000,112_000_001_000]):
            c.skill_start(match_id='FAKE',turn=3,source_hash='HASH',skill_card_id=22)
            c.skill_finish(result=result())
        e=json.loads(sink.buffer.items[0]);p=e['payload']
        self.assertEqual(p['full_primitive_ns'],12_000_000_000)
        self.assertEqual(p['click_only_input']['required_input_upper_ms'],282.25)
        self.assertEqual(p['first_click_status'],'NOT_MEASURED')
        self.assertIsNone(p['first_click_ns']);self.assertTrue(p['complete_interval_bound'])

    def test_stop_mid_skill_is_unproven_and_no_replay(self):
        sink=MemorySink();c=MegaClickTimingCollector(sink=sink,run_id='FAKE')
        c.skill_start(match_id='FAKE',turn=3,source_hash='HASH',skill_card_id=22)
        c.stop();c.stop()
        self.assertEqual(c.sequence,1)
        p=json.loads(sink.buffer.items[0])['payload']
        self.assertEqual(p['status'],'STOP_OR_CONTROLLER_EXIT')
        self.assertEqual(p['click_only_input']['status'],'UNPROVEN')

    def test_session_match_boundary_keeps_collector_type_sequence_and_loss(self):
        c=replace(config(),target_completed_matches=1,max_match_attempts=1)
        req=SwapTimingRequest('FAKE',canonical_json(jsonable(c)),1)
        with patch('pokiguard_v2.reasoning_swap_timing.BoundedDiagnostics',return_value=MemorySink()):
            session=MegaClickTimingSession(req,config=c,directory=Path('UNUSED'))
            old=session.collector;old.sequence=4;old.dropped=2;old.stop()
            new=session.prepare_options()['swap_timing_adapter']
            self.assertIsInstance(new,MegaClickTimingCollector);self.assertIsNot(new,old)
            self.assertEqual(new.sequence,4);self.assertEqual(session.prior_dropped,2)
            session.stopped=True;self.assertEqual(session.prepare_options(),{})

    def test_probe_has_exact_same_cohort_but_only_one_attempt(self):
        c=replace(config(),target_completed_matches=1,max_match_attempts=1)
        check_config(c,1,profile_protocol=D4_INPUT_TIMING_PROTOCOL)
        with self.assertRaises(ValueError):check_config(c,1,profile_protocol=D4_CONTROL_PROTOCOL)
        with self.assertRaises(ValueError):check_config(config(),3,profile_protocol=D4_INPUT_TIMING_PROTOCOL)
        with self.assertRaises(ValueError):check_config(replace(c,pet_skill_fire_value=5),1,profile_protocol=D4_INPUT_TIMING_PROTOCOL)

    def test_parent_and_deterministic_claim_identity_prevent_fresh_request_reset(self):
        path=NATIVE/'closure.json';parent=dict(path=path.relative_to(ROOT).as_posix(),sha256=hashlib.sha256(path.read_bytes()).hexdigest())
        data=dict(native_parent=parent,previous_attempts_consumed=3,probe_attempt_cap=1,
            remaining_after_probe=2,total_case_cap=6,run_id=d4_probe_run_id(parent['sha256']))
        verify_d4_probe_parent(data,ROOT)
        self.assertEqual(data['run_id'],d4_probe_run_id(parent['sha256']))
        for change in (dict(run_id='a'*32),dict(total_case_cap=7),dict(remaining_after_probe=3),dict(probe_attempt_cap=2)):
            with self.subTest(change=change),self.assertRaises(ValueError):verify_d4_probe_parent(dict(data,**change),ROOT)

    def test_inert_probe_preview_one_start_and_second_request_cannot_reopen_cap(self):
        from tools.prepare_d4_control import prepare,activate
        from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
        from pokiguard_v2.desktop_control_plane import DesktopConfig
        with tempfile.TemporaryDirectory() as name:
            root=Path(name);prefs=root/'prefs.json';DesktopPreferenceStore(prefs).save(DesktopConfig())
            parent=root/'docs/phase5/artifacts/5d4_smallblue_basic3_live_20261018_041121/closure.json'
            parent.parent.mkdir(parents=True);parent.write_bytes((NATIVE/'closure.json').read_bytes())
            exe=root/'FAKE.exe';exe.write_bytes(b'SYNTHETIC-NOT-A-GAME')
            before=prefs.read_bytes();draft=root/'draft.json'
            def build(_root,c,game,**kwargs):
                return dict(schema=SCHEMA,run_id='a'*32,reasoning_enabled=False,created_at=1000,expires_at=2000,
                    source_sha256='s',host_sha256='h',game_executable=str(exe),game_executable_sha256='e',
                    game_build_sha256='b',config=jsonable(c),total_attempt_cap=1,profile_protocol=D4_INPUT_TIMING_PROTOCOL)
            with patch('tools.prepare_d4_control.ROOT',root), \
                 patch('tools.prepare_d4_control.source_fingerprint',return_value='s'), \
                 patch('tools.prepare_d4_control.build_request',side_effect=build):
                d=prepare(prefs,exe,draft,probe=True)
                self.assertFalse(d['accepted']);self.assertFalse(d['request_created'])
                self.assertEqual((d['planned_basic_attempts'],d['planned_reasoning_attempts'],d['total_case_cap']),(4,2,6))
                with self.assertRaises(ValueError):activate(draft,root/'blank.json',authorization='')
                a1=root/'request1.json';a2=root/'request2.json'
                one=activate(draft,a1,authorization='SYNTHETIC_TEST_ONLY');two=activate(draft,a2,authorization='SYNTHETIC_TEST_ONLY')
                self.assertEqual(one['run_id'],two['run_id']);self.assertEqual(before,prefs.read_bytes())
            with patch('pokiguard_v2.reasoning_calibration.time.time',return_value=1001), \
                 patch('pokiguard_v2.reasoning_calibration.host_fingerprint',return_value='h'), \
                 patch('pokiguard_v2.reasoning_calibration.source_fingerprint',return_value='s'), \
                 patch('pokiguard_v2.reasoning_calibration.validate_supported_game_assembly',return_value='b'), \
                 patch('pokiguard_v2.reasoning_calibration.game_assembly_sha256',return_value='e'), \
                 patch('pokiguard_v2.reasoning_mega_timing.MegaClickTimingSession') as factory:
                make=lambda p:BasicCalibrationActivation(p,hashlib.sha256(p.read_bytes()).hexdigest(),root=root,
                    directory=root/'timing',game_executable=lambda:exe)
                activation=make(a1);self.assertFalse(activation.claim_path.exists());factory.assert_not_called()
                c=activation.config
                with self.assertRaises(ValueError):activation(c)
                activation.claim(c,None)
                with self.assertRaises(ValueError):make(a2)
                self.assertIs(activation(c),factory.return_value)
                self.assertNotIn('selection_adapter',factory.call_args.kwargs)
                with self.assertRaises(ValueError):activation(c)

    def test_native_long_nonterminal_waits_not_cherry_picked_to_terminal_samples(self):
        closure=json.loads((NATIVE/'closure.json').read_text('utf-8'))
        self.assertEqual(closure['skills']['total'],7)
        self.assertGreater(closure['timing']['reserve_lower_without_selector_ms'],16000)
        self.assertEqual(closure['clock_metadata']['monotonic']['implementation'],'GetTickCount64()')
        self.assertEqual(closure['clock_metadata']['perf_counter']['implementation'],'QueryPerformanceCounter()')
        self.assertFalse(closure['reasoning_activation'])

    def test_exact_native_core_execution_and_historical_calibration_ast_preserved(self):
        manifest=json.loads((NATIVE/'native_source_manifest.json').read_text('utf-8'))
        self.assertEqual(manifest['fingerprint'],'218d0e6c39a532d9da0c197ccbccceab459289282d087db1545699019f99f1df')
        allowed={'src/pokiguard_v2/reasoning_calibration.py','tools/prepare_d4_control.py',
            'tests/reasoning_controller_fixture.py','tests/test_reasoning_d4_control.py'}
        frozen=ROOT/'docs/phase5/artifacts/5d4_input_probe1_live_20261018_125726/native_source'
        for name,h in manifest['files'].items():
            if name not in allowed:self.assertEqual(hashlib.sha256((frozen/name).read_bytes()).hexdigest(),h,name)
        old=ast.parse((NATIVE/'native_source/src/pokiguard_v2/reasoning_calibration.py').read_text('utf-8'))
        new=ast.parse((frozen/'src/pokiguard_v2/reasoning_calibration.py').read_text('utf-8'))
        added={'d4_probe_run_id','verify_d4_probe_parent'}
        new.body=[n for n in new.body if not (isinstance(n,ast.FunctionDef) and n.name in added)
            and not (isinstance(n,ast.Assign) and any(isinstance(t,ast.Name) and t.id=='D4_INPUT_TIMING_PROTOCOL' for t in n.targets))]
        fn=next(n for n in new.body if isinstance(n,ast.FunctionDef) and n.name=='check_config')
        self.assertEqual(ast.unparse(fn.body[0].test),'profile_protocol == D4_INPUT_TIMING_PROTOCOL');fn.body.pop(0)
        cls=next(n for n in new.body if isinstance(n,ast.ClassDef) and n.name=='BasicCalibrationActivation')
        for method in cls.body:
            if not isinstance(method,ast.FunctionDef):continue
            method.body=[n for n in method.body if not (isinstance(n,ast.If) and 'D4_INPUT_TIMING_PROTOCOL' in ast.unparse(n.test))
                and not (isinstance(n,ast.Assign) and any(isinstance(t,ast.Name) and t.id=='factory' for t in n.targets))]
            for node in ast.walk(method):
                if isinstance(node,ast.Call) and isinstance(node.func,ast.Name) and node.func.id=='factory':node.func.id='SwapTimingSession'
        self.assertEqual(ast.dump(old),ast.dump(new))

    def test_historical_remediation_changes_no_gameplay_and_only_accepts_exact_collector(self):
        frozen_root=ROOT/'docs/phase5/artifacts/5d4_input_repeat1_live_20261018_143456/native_source'
        failed=ROOT/'docs/phase5/artifacts/5d4_input_probe1_live_20261018_125726'
        manifest=json.loads((failed/'native_source_manifest.json').read_text('utf-8'))
        self.assertEqual(manifest['fingerprint'],'97d97cdb8215b7716fbb3586a64e4b0fe4126170896a599730fa822c900a61ad')
        allowed={'src/pokiguard_v2/reasoning_calibration.py','src/pokiguard_v2/reasoning_swap_timing.py',
            'src/pokiguard_v2/reasoning_mega_timing.py','tools/prepare_d4_control.py',
            'tests/reasoning_controller_fixture.py','tests/test_reasoning_mega_timing.py'}
        for name,h in manifest['files'].items():
            if name not in allowed:self.assertEqual(hashlib.sha256((frozen_root/name).read_bytes()).hexdigest(),h,name)
        rel='src/pokiguard_v2/reasoning_swap_timing.py'
        old=ast.parse((failed/'native_source'/rel).read_text('utf-8'));new=ast.parse((frozen_root/rel).read_text('utf-8'))
        a=next(n for n in old.body if isinstance(n,ast.FunctionDef) and n.name=='timing_safely')
        b=next(n for n in new.body if isinstance(n,ast.FunctionDef) and n.name=='timing_safely')
        self.assertEqual(ast.unparse(b.body[0].test),'type(adapter) is not SwapTimingCollector')
        self.assertEqual(ast.unparse(b.body[0].body[-1].test),'type(adapter) is not MegaClickTimingCollector')
        self.assertEqual(ast.unparse(b.body[0].body[1]),'from .reasoning_mega_timing import MegaClickTimingCollector')
        b.body[0].body=a.body[0].body
        self.assertEqual(ast.dump(old),ast.dump(new))
        rel='src/pokiguard_v2/reasoning_mega_timing.py'
        old=ast.parse((failed/'native_source'/rel).read_text('utf-8'));new=ast.parse((frozen_root/rel).read_text('utf-8'))
        cls=next(n for n in new.body if isinstance(n,ast.ClassDef) and n.name=='MegaClickTimingSession')
        self.assertEqual(sum(isinstance(n,ast.FunctionDef) and n.name=='stop' for n in cls.body),1)
        cls.body=[n for n in cls.body if not (isinstance(n,ast.FunctionDef) and n.name=='stop')]
        self.assertEqual(ast.dump(old),ast.dump(new))
        rel='src/pokiguard_v2/reasoning_calibration.py'
        old=ast.parse((failed/'native_source'/rel).read_text('utf-8'));new=ast.parse((frozen_root/rel).read_text('utf-8'))
        new.body=[n for n in new.body if not (isinstance(n,ast.FunctionDef) and n.name in {'d4_retry_run_id','verify_d4_retry_parent'})
            and not (isinstance(n,ast.Assign) and any(isinstance(t,ast.Name) and t.id=='D4_INPUT_RETRY_PROTOCOL' for t in n.targets))]
        fn=next(n for n in new.body if isinstance(n,ast.FunctionDef) and n.name=='check_config')
        self.assertEqual(ast.unparse(fn.body[0].test),'profile_protocol == D4_INPUT_RETRY_PROTOCOL');fn.body.pop(0)
        cls=next(n for n in new.body if isinstance(n,ast.ClassDef) and n.name=='BasicCalibrationActivation')
        for method in cls.body:
            if isinstance(method,ast.FunctionDef):
                method.body=[n for n in method.body if not (isinstance(n,ast.If) and 'D4_INPUT_RETRY_PROTOCOL' in ast.unparse(n.test))]
        self.assertEqual(ast.dump(old),ast.dump(new))


if __name__=='__main__':unittest.main()
