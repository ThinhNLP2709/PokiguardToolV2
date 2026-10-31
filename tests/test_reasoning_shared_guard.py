"""Finite D1 guard remediation; historical native rows keep their original source."""
from copy import deepcopy
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import tempfile
from types import SimpleNamespace
import unittest
from unittest.mock import patch

from pokiguard_v2.reasoning_component_guard import VERSION,debit_guard
from pokiguard_v2.reasoning_native_boundary_review import SCHEMA,ORIGIN,CHANGED,verified_origin,normalized
from pokiguard_v2.reasoning_calibration import source_fingerprint
from pokiguard_v2.reasoning_snapshot import canonical_json
from pokiguard_v2.reasoning_swap_timing import SwapTimingCollector
from pokiguard_v2.basic_policy import PolicyConfig
from tests.test_reasoning_operational import native_state,operational_authority
from tests.test_reasoning_pilot import MemorySink
from tests import test_reasoning_d1_native as fixtures

ROOT=Path(__file__).resolve().parents[1]
REM=ROOT/'docs/phase5/artifacts/5d1_main_pilot_20261016_v1/shared_guard_remediation'


class SharedGuardTests(unittest.TestCase):
    def collector(self,policy=VERSION):
        a=operational_authority(native_state(),PolicyConfig(),max_read_span_ms=100)
        from pokiguard_v2.reasoning_root_policy import POLICY
        from pokiguard_v2.reasoning_config_projection import VERSION as PROJECTION
        from pokiguard_v2.reasoning_snapshot import FrozenJSON
        return SwapTimingCollector(sink=MemorySink(),component_monitor=True,
            operational_authority=replace(a,root_read_policy=FrozenJSON.of(POLICY),
                config_projection_policy=PROJECTION,component_guard_policy=policy))

    def monitor(self,h,i,*,policy=VERSION,guard=250_000_000):
        c=self.collector(policy);c.component_limits=dict(controller_tail=100_000_000,
            final_input=200_000_000,aggregate=300_000_000+guard)
        sample=dict(decision_exit_ns=0,preflight_start_ns=h,read_end_ns=h,validation_end_ns=h)
        payload={};c._monitor_components(payload,sample,h+i);return c,payload

    def test_exact_observed_native_fault_becomes_visible_within_guard_without_AI_breaker(self):
        issue=json.loads((REM/'issue_and_protocol.json').read_text())
        raw=issue['first_fault']['payload'];c=self.collector();c.component_limits=raw['component_limits_ns']
        result={};c._monitor_components(result,raw,raw['executor_return_ns'])
        self.assertTrue(result['component_overruns']['controller_tail'])
        self.assertEqual(result['component_guard']['debit_ns'],2_722_000)
        self.assertIsNone(result['component_fault']);self.assertFalse(c.disabled)
        self.assertFalse(result['reserve_overrun'])

    def test_one_shared_pool_exact_boundary_and_one_ns_exhaustion(self):
        for h,i,expected in [(225_000_000,325_000_000,False),(225_000_001,325_000_000,True),
            (350_000_000,0,False),(350_000_001,0,True),(0,450_000_001,True)]:
            with self.subTest(h=h,i=i):
                c,p=self.monitor(h,i)
                self.assertEqual(c.disabled,expected)
                self.assertEqual(p['component_guard']['exhausted'],expected)

    def test_unused_other_component_cannot_hide_shared_guard_exhaustion(self):
        c,p=self.monitor(351_000_000,0)
        self.assertFalse(p['component_overruns']['aggregate']);self.assertTrue(c.disabled)
        self.assertEqual(p['component_fault'],'TIMING_SHARED_GUARD_EXHAUSTED')

    def test_invalid_clock_still_faults_without_guard_credit(self):
        c=self.collector();p={};c._monitor_components(p,dict(decision_exit_ns=20,
            preflight_start_ns=10,read_end_ns=30,validation_end_ns=40),50)
        self.assertTrue(c.disabled);self.assertEqual(p['component_fault'],'TIMING_INVALID_INTERVAL')
        self.assertIsNone(p['component_guard'])

    def test_legacy_monitor_keeps_original_fault_and_authority_identity(self):
        c,p=self.monitor(100_000_001,0,policy=None)
        self.assertTrue(c.disabled);self.assertEqual(p['component_fault'],'TIMING_CONTROLLER_TAIL')
        self.assertNotIn('component_guard',p)
        a=c.authority;raw=__import__('pokiguard_v2.board_diagnostics',fromlist=['jsonable']).jsonable(a)
        raw.pop('component_guard_policy')
        self.assertIsNone(raw.pop('action_profile'))
        self.assertIsNone(raw.pop('demon_profile'))
        self.assertEqual(a.identity,__import__('pokiguard_v2.reasoning_snapshot',fromlist=['digest']).digest(raw))

    def test_bad_guard_inputs_and_policy_are_rejected(self):
        for value in (-1,True,1.0,None):
            with self.subTest(value=value),self.assertRaises(ValueError):debit_guard(value,0,1,1,250)
        with self.assertRaises(ValueError):self.collector('UNKNOWN_GUARD')

    def test_each_component_cannot_independently_spend_the_full_pool(self):
        p=debit_guard(300,400,100,200,250)
        self.assertEqual(p['debit_ns'],400);self.assertTrue(p['exhausted'])


class NativeBoundaryTests(unittest.TestCase):
    def setUp(self):
        temp=tempfile.TemporaryDirectory(dir=ROOT);self.addCleanup(temp.cleanup);self.d=Path(temp.name)
        from tools.review_reasoning_calibration import ref
        import shutil
        for n in CHANGED:
            dst=self.d/'before'/n;dst.parent.mkdir(parents=True,exist_ok=True);shutil.copyfile(REM/'before'/n,dst)
        shutil.copyfile(REM/'before_source_manifest.json',self.d/'before_manifest.json')
        # Replay this historical review against exact D1 source bytes. D2's
        # current source must not be relabeled as the old c707/BA4856 boundary.
        phase=ROOT/'docs/phase5/artifacts/5d2_skill_rush_v1'
        expected=json.loads((phase/'before_source.json').read_text(encoding='utf-8'))
        self.historical=self.d/'historical_source';self.historical.mkdir()
        for name,sha in expected['files'].items():
            candidates=[phase/'before'/name,phase/'pre_skill_timing'/name,
                phase/'offline_completion_v1/before'/name,ROOT/name]
            original=next((p for p in candidates if p.is_file() and hashlib.sha256(p.read_bytes()).hexdigest()==sha),None)
            self.assertIsNotNone(original,name)
            dst=self.historical/name;dst.parent.mkdir(parents=True,exist_ok=True);shutil.copyfile(original,dst)
        self.historical_sha=source_fingerprint(self.historical)
        self.assertEqual(self.historical_sha,expected['fingerprint'])
        for module in ('reasoning_native_boundary_review','reasoning_d1_native'):
            view=patch('pokiguard_v2.'+module+'.__file__',str(self.historical/'src/pokiguard_v2'/(module+'.py')))
            view.start();self.addCleanup(view.stop)
        self.review=dict(schema=SCHEMA,origin_sha256=ORIGIN,current_sha256=self.historical_sha,
            basic_boundary_execution_unchanged=True,before_manifest=ref(self.d,self.d/'before_manifest.json'),
            before_files={n:ref(self.d,self.d/'before'/n) for n in CHANGED})
        self.ref=ref

    def check(self):
        p=self.d/'review.json';p.write_text(canonical_json(self.review),encoding='utf-8')
        return verified_origin(self.d,self.ref(self.d,p),current_sha256=self.historical_sha)

    def test_exact_review_accepts_origin_without_changing_observed_raw_hashes(self):
        result=self.check();self.assertEqual(result['source_sha256'],ORIGIN)
        self.assertNotEqual(result['current_source_sha256'],ORIGIN)

    def test_current_d2_source_cannot_reuse_the_old_d1_review(self):
        p=self.d/'review.json';p.write_text(canonical_json(self.review),encoding='utf-8')
        with patch('pokiguard_v2.reasoning_native_boundary_review.__file__',
                str(ROOT/'src/pokiguard_v2/reasoning_native_boundary_review.py')):
            with self.assertRaises(ValueError):
                verified_origin(self.d,self.ref(self.d,p),current_sha256=source_fingerprint(ROOT))

    def test_changed_origin_manifest_or_before_bytes_or_current_source_rejected(self):
        for field,value in [('origin_sha256','0'*64),('current_sha256','0'*64),('basic_boundary_execution_unchanged',False)]:
            original=self.review[field];self.review[field]=value
            with self.subTest(field=field),self.assertRaises(ValueError):self.check()
            self.review[field]=original
        key=next(iter(CHANGED));self.review['before_files'][key]['sha256']='0'*64
        with self.assertRaises(ValueError):self.check()

    def test_boundary_normalization_cannot_hide_input_timing_or_other_authority_changes(self):
        n='src/pokiguard_v2/reasoning_swap_timing.py';raw=(REM/'before'/n).read_text(encoding='utf-8')
        self.assertNotEqual(normalized(raw,n),normalized(raw.replace('ended = time.perf_counter_ns()',
            'ended = 0'),n))
        n='src/pokiguard_v2/reasoning_operational.py';raw=(REM/'before'/n).read_text(encoding='utf-8')
        self.assertNotEqual(normalized(raw,n),normalized(raw.replace('return self._reserve_ms','return 0'),n))

    def test_real_closed_BASIC_raw_can_be_verified_on_reviewed_boundary_without_rewriting_source(self):
        from pokiguard_v2.reasoning_d1_native import verify_native
        self.check();pkg=ROOT/'docs/phase5/artifacts/5d1_main_pilot_20261016_v1/simple_reasoning/package'
        import shutil
        shutil.copytree(pkg,self.d/'native');d=self.d/'native';cal=json.loads((d/'calibration.json').read_text())
        shutil.copytree(self.d/'before',d/'before');shutil.copyfile(self.d/'before_manifest.json',d/'before_manifest.json')
        (d/'review.json').write_text(canonical_json(self.review),encoding='utf-8');cal['native_boundary_review']=self.ref(d,d/'review.json')
        source=cal['runtime_sha256'];request=SimpleNamespace(runtime_sha256=self.historical_sha,
            host_sha256=cal['host_sha256'],verified_build_sha256=cal['game_build_sha256'])
        result=verify_native(d,cal,request,policy_json=cal['policy_json'],witness=cal['witness'])
        self.assertEqual((result['anchors'],result['returns']),(40,46));self.assertEqual(cal['runtime_sha256'],source)
        self.assertEqual(result['native_origin_sha256'],ORIGIN)
        del cal['native_boundary_review']
        with self.assertRaises(ValueError):verify_native(d,cal,request,policy_json=cal['policy_json'],witness=cal['witness'])


class SharedGuardAuthorityTests(unittest.TestCase):
    def setUp(self):
        self.f=fixtures.D1NativeTests();self.f.setUp();self.addCleanup(self.f.doCleanups)

    def test_mode_requires_independent_pin_and_matching_cost_mode(self):
        f=self.f;f.data['component_guard_policy']=VERSION
        with self.assertRaisesRegex(ValueError,'independently pinned'):f.load()
        activation=f.get(f.data['activation_review']);activation['component_guard_policy']=VERSION
        f.update('activation_review',activation);f.data['activation_sha256']=f.data['activation_review']['sha256']
        with self.assertRaisesRegex(ValueError,'matching collector guard'):f.load()
        allowance=f.get(f.data['selector_allowance']);allowance['qualification']=f.doc('SHARED_COST.json',dict(profile='simple',component_guard_policy=VERSION))
        f.update('selector_allowance',allowance)
        activation['selector_allowance_sha256']=f.data['selector_allowance']['sha256']
        f.update('activation_review',activation);f.data['activation_sha256']=f.data['activation_review']['sha256']
        a=f.load();self.assertEqual(a.component_guard_policy,VERSION)

    def test_claimed_shared_cost_without_actual_raw_path_is_rejected(self):
        from pokiguard_v2.reasoning_d1_native import validate_costs,SOURCE_POLICY
        from pokiguard_v2.reasoning_config_projection import VERSION as PROJECTION
        f=self.f;p=f.directory/'pipeline_raw.jsonl'
        p.write_text(('{}\n'.format(json.dumps(dict(source_projection_policy=SOURCE_POLICY))))*6000,encoding='utf-8')
        q=dict(source_projection_policy=SOURCE_POLICY,config_projection_policy=PROJECTION,
            profile='simple',component_guard_policy=VERSION,raw_sha256={'pipeline_raw.jsonl':hashlib.sha256(p.read_bytes()).hexdigest()})
        with self.assertRaisesRegex(ValueError,'actual shared guard'):validate_costs(f.directory,q)


class SharedGuardFlowTests(unittest.TestCase):
    def test_real_controller_keeps_one_input_ACK_on_shared_mode_and_exhaustion(self):
        from collections import Counter,deque
        from pokiguard_v2.reasoning_operational import OperationalPilotSession
        from pokiguard_v2.reasoning_pilot import PilotSelectionBridge
        from pokiguard_v2.reasoning_snapshot import FrozenJSON
        from pokiguard_v2.reasoning_root_policy import POLICY
        from pokiguard_v2.reasoning_config_projection import VERSION as PROJECTION
        from tests.reasoning_controller_fixture import controller_trace
        for profile in ('simple','careful'):
            for exhaust in (False,True):
                box={}
                def bridge(state,config):
                    a=operational_authority(state,config,max_read_span_ms=100,root_read_policy=FrozenJSON.of(POLICY),
                        config_projection_policy=PROJECTION,component_guard_policy=VERSION)
                    b=PilotSelectionBridge(authority=a,diagnostics=MemorySink(),verified_build_sha256=a.game_build_sha256,
                        enabled=True,decision_budget=True,warm_worker=True);box['b']=b;self.addCleanup(b.close)
                    session=object.__new__(OperationalPilotSession);session.bridges=[b];session.prepare_calls=1
                    session.session_counts=Counter();session.status_history=deque(maxlen=32);session.first_fault=None
                    session.faulted=False;session.adapter=b;box['session']=session
                    return b
                def timing(state,config):
                    return SwapTimingCollector(sink=box['b'].timing_diagnostics,operational_authority=box['b'].pilot_authority,
                        component_monitor=True,on_fault=box['session']._fault)
                original=debit_guard
                def injected(*args):
                    value=original(*args)
                    if exhaust:value.update(exhausted=True,debit_ns=value['shared_guard_ns']+1,remaining_ns=0)
                    return value
                with tempfile.TemporaryDirectory() as name:
                    d=Path(name);kw=dict(profile=profile,initial_combat=native_state(),real_processing_clock=True,
                        timer_source='MatchService.server_tick')
                    baseline=controller_trace(d/'base.jsonl',**kw)
                    with patch('pokiguard_v2.reasoning_component_guard.debit_guard',side_effect=injected):
                        selected=controller_trace(d/'AI.jsonl',**kw,target_pid=7,selection_factory=bridge,timing_factory=timing)
                    self.assertEqual(baseline[1],selected[1]);self.assertEqual(selected[1].count('FAKE_NORMAL_INPUT'),1)
                    self.assertEqual(selected[1].count('executor.ack'),1)
                    self.assertEqual(box['session'].faulted,exhaust)
                    if exhaust:self.assertEqual(box['session'].first_fault['reason'],'TIMING_SHARED_GUARD_EXHAUSTED')
                    self.assertTrue(box['b'].close())


if __name__=='__main__':unittest.main()
