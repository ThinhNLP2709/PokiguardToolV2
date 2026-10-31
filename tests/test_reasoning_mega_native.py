"""D4 file-only native admission and synthetic timing; no game/process handles."""
from dataclasses import replace
import hashlib,json,tempfile,time,unittest
from pathlib import Path
from types import SimpleNamespace as NS
from unittest.mock import patch

from tools.prepare_d4_reasoning import copy_native
from pokiguard_v2.reasoning_mega_native import verify_native,verify_boundary,check_config,run_id,CHANGED,ADDED
from pokiguard_v2.reasoning_calibration import source_files,source_fingerprint,decode_config
from pokiguard_v2.reasoning_mega_timing import MegaClickTimingCollector,required_input_ns
from pokiguard_v2.reasoning_swap_timing import timing_safely,operational_preflight_failure
from tests.test_reasoning_mega import fixture,PARAMS
from tests.test_reasoning_pilot import MemorySink

ROOT=Path(__file__).resolve().parents[1]


class MegaNativeTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.temp=tempfile.TemporaryDirectory();cls.directory=Path(cls.temp.name)
        cls.cal=copy_native(cls.directory)
    @classmethod
    def tearDownClass(cls):cls.temp.cleanup()

    def test_raw_native_all_attempt_join_and_click_clock_are_own_mega(self):
        review=verify_native(self.directory,self.cal)
        self.assertEqual((review['swap_samples'],review['skill_samples'],review['attempts_consumed']),(11,4,6))
        self.assertEqual(review['remaining_reasoning'],2);self.assertEqual(review['total_case_cap'],8)
        self.assertIsNone(review['native_U_ms'])
        self.assertEqual(len(review['input_intervals']),4)
        self.assertTrue(review['sample_maxima_not_future_bound'])
        self.assertLess(max(x['required_input_upper_ms'] for x in review['input_intervals']),400)
        self.assertGreater(max(x['post_click_readonly_elapsed_ms'] for x in review['input_intervals']),10000)

    def test_history_roles_or_skill_splice_cannot_rebind_native_authority(self):
        for change in (dict(history=self.cal['history'][:-1]),dict(history=list(reversed(self.cal['history']))),
                dict(raw_audit=self.cal['raw_audit'][:-1]),dict(records=self.cal['combat']),
                dict(pet_skills=self.cal['pet_skills'][:3]),dict(request=self.cal['session'])):
            with self.subTest(change=list(change)),self.assertRaises((ValueError,KeyError)):
                verify_native(self.directory,dict(self.cal,**change))

    def test_frozen_native_controller_reader_executor_and_basic_are_exact(self):
        # D4's admission remains bound to its own accepted source. E1 adds a
        # separate protocol; those files must not silently re-certify D4.
        frozen=ROOT/'docs/phase5/artifacts/5d4_smallblue_reasoning2_live_20261018_234026/native_source'
        manifest=dict(fingerprint=source_fingerprint(frozen),files=source_files(frozen))
        p=self.directory/'current_source.json';p.write_text(json.dumps(manifest),encoding='utf-8')
        ref=dict(path=p.name,sha256=hashlib.sha256(p.read_bytes()).hexdigest())
        review=verify_boundary(self.directory,dict(self.cal,source_manifest=ref),manifest['fingerprint'],root=frozen)
        self.assertTrue(review['controller_byte_exact']);self.assertEqual(set(review['changed_files']),CHANGED)
        self.assertEqual(set(review['added_files']),ADDED)
        current=dict(fingerprint=source_fingerprint(ROOT),files=source_files(ROOT))
        p.write_text(json.dumps(current),encoding='utf-8')
        ref['sha256']=hashlib.sha256(p.read_bytes()).hexdigest()
        with self.assertRaisesRegex(ValueError,'unreviewed Mega source additions/changes'):
            verify_boundary(self.directory,dict(self.cal,source_manifest=ref),current['fingerprint'])

    def test_only_two_reserved_solo_no_qte_attempts_are_configured(self):
        p=ROOT/'docs/phase5/artifacts/5d4_repeat_measurement_preparation_20261018/repeat_request_cap8.json'
        c=replace(decode_config(json.loads(p.read_text('utf-8'))['config']),target_completed_matches=2,max_match_attempts=2)
        check_config(c)
        for bad in (replace(c,max_match_attempts=3),replace(c,target_completed_matches=1),
                replace(c,pet_skill_fire_value=7),replace(c,boss_id='1289')):
            with self.assertRaises(ValueError):check_config(bad)
        self.assertEqual(run_id(),run_id());self.assertEqual(len(run_id()),32)

    def test_operational_skill_monitors_required_click_and_keeps_whole_readonly_span(self):
        *_,a,packet,snap=fixture();sink=MemorySink()
        c=MegaClickTimingCollector(sink=sink,run_id='SYNTHETIC',operational_authority=a,component_monitor=True)
        c.input_clock=dict(implementation='FAKE_TICKS',resolution_seconds=.015625)
        c.decision_interval=dict(decision_exit_ns=99_800_000_000,decision_source_hash='HASH')
        result=NS(kind=NS(value='SUCCESS_NO_ACTION'),card_clicks=1,space_presses=0,direction_presses=0,
            telemetry=NS(card_click_timestamp=10.25))
        with patch('pokiguard_v2.reasoning_mega_timing.time.monotonic',side_effect=[10,22]), \
             patch('pokiguard_v2.reasoning_mega_timing.time.perf_counter_ns',side_effect=[100_000_000_000,112_000_000_000,112_000_001_000]):
            timing_safely(c,'skill_start',match_id='FAKE',turn=3,source_hash='HASH',skill_card_id=22)
            timing_safely(c,'skill_finish',result=result)
        self.assertFalse(c.disabled,c.fault_reason)
        p=json.loads(sink.buffer.items[0])['payload']
        self.assertEqual(p['full_primitive_ns'],12_000_000_000)
        self.assertEqual(p['required_input_ns'],282_250_000)
        self.assertIsNone(p['first_click_ns']);self.assertFalse(p['component_guard']['exhausted'])

    def test_unknown_or_tampered_click_measurement_cannot_become_reserve(self):
        self.assertIsNone(required_input_ns({}))
        self.assertIsNone(required_input_ns(dict(click_only_input=dict(status='OBSERVED_PADDED_ELAPSED'))))
        *_,a,packet,snap=fixture();sink=MemorySink();faults=[]
        c=MegaClickTimingCollector(sink=sink,run_id='FAKE',operational_authority=a,component_monitor=True,on_fault=faults.append)
        c.decision_interval=dict(decision_exit_ns=time.perf_counter_ns(),decision_source_hash='HASH')
        timing_safely(c,'skill_start',match_id='FAKE',turn=3,source_hash='HASH',skill_card_id=22)
        timing_safely(c,'skill_finish',result=NS(kind=NS(value='SUCCESS_NO_ACTION'),card_clicks=1,
            space_presses=0,direction_presses=0,telemetry=NS(card_click_timestamp=None)))
        self.assertTrue(c.disabled);self.assertEqual(faults,['D4_SKILL_REQUIRED_INPUT_UNPROVEN'])

    def test_mega_subclass_keeps_existing_swap_preflight_veto(self):
        s,c,b,cap,h,a,packet,snap=fixture();collector=MegaClickTimingCollector(sink=MemorySink(),run_id='FAKE',
            operational_authority=a,component_monitor=True)
        collector.start(state=s,config=c,input_mode='foreground',source_hash='HASH')
        failure=operational_preflight_failure(collector,read_end_ns=time.perf_counter_ns(),input_parameters=dict(PARAMS,cursor_settle_seconds=.07))
        self.assertEqual(failure,'OPERATIONAL_INPUT_PARAMETERS_CHANGED');self.assertTrue(collector.disabled)


if __name__=='__main__':unittest.main()
