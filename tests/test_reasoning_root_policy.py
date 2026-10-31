"""P21 offline gates: synthetic game/executor only, sealed native files read-only."""
from collections import Counter,deque
from copy import deepcopy
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import shutil
import tempfile
import threading
import time
import unittest
from unittest.mock import patch

from pokiguard_v2.basic_policy import BasicPolicyEngine,PolicyConfig
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.reasoning_diagnostics import DiagnosticBuffer,LogLimits
from pokiguard_v2.reasoning_operational import authority_deadline,operational_deadline_ns
from pokiguard_v2.reasoning_pilot import PilotSelectionBridge
from pokiguard_v2.reasoning_selection import GuardedSelectionAdapter
from pokiguard_v2.reasoning_snapshot import FrozenJSON,digest
from pokiguard_v2.reasoning_swap_timing import SwapTimingCollector,operational_preflight_failure
from pokiguard_v2.reasoning_root_policy import POLICY,validate_policy,verify_review,verify_sources,P20_CONTRACT
from tests.test_reasoning_operational import native_state,operational_authority,PARAMS
from tests import test_reasoning_operational as operational_tests
from tests.test_reasoning_pilot import MemorySink
from tests import test_reasoning_operational_lifecycle as lifecycle
from tests.reasoning_controller_fixture import controller_trace
from tools.review_reasoning_timing_v4 import ROOT,export_review
from tools.review_reasoning_calibration import ref


def authority(state=None,config=None):
    state=state or native_state();config=config or PolicyConfig()
    return operational_authority(state,config,max_read_span_ms=100,root_read_policy=FrozenJSON.of(POLICY))


def inert(a):
    b=object.__new__(PilotSelectionBridge)
    GuardedSelectionAdapter.__init__(b,diagnostics=DiagnosticBuffer(
        LogLimits(records=64,bytes=128*1024,reserved_bytes=16*1024)),
        enabled=True,pilot_authority=a)
    b.request_lock=threading.Lock();b.request=None;b.observation=None
    b.bridge_counts=Counter();b.wake=threading.Event();b.decision_budget=True
    b.last_admission=None;b.checkpoints=deque(maxlen=64)
    return b


class RootPolicyTests(unittest.TestCase):
    def test_legacy_identity_and100_boundary_are_preserved(self):
        s=native_state();c=PolicyConfig();a=operational_authority(s,c,max_read_span_ms=100)
        self.assertIsNone(a.component_guard_policy)
        raw=jsonable(a);raw.pop('root_read_policy');raw.pop('config_projection_policy');raw.pop('component_guard_policy')
        self.assertIsNone(raw.pop('action_profile'))  # Absent D2 opt-in preserves the legacy wire identity.
        self.assertIsNone(raw.pop('demon_profile'))  # Absent D3 opt-in also preserves the legacy wire identity.
        self.assertEqual(a.identity,digest(raw))
        for span,expected in [(100_000_000,True),(100_000_001,False)]:
            b=inert(a);self.assertEqual(b.observe(s,c,observed_ns=1,read_end_ns=1+span,context=a.context),expected)

    def test_successor250_boundary_and_invalid_clock(self):
        s=native_state();c=PolicyConfig();a=authority(s,c)
        for start,end,expected in [(1,250_000_001,True),(1,250_000_002,False),(2,1,False),(-1,1,False),(True,2,False)]:
            b=inert(a);self.assertEqual(b.observe(s,c,observed_ns=start,read_end_ns=end,context=a.context),expected)

    def test_final100_boundary_is_independent_of_root250(self):
        a=authority()
        for span,reason in [(100_000_000,None),(100_000_001,'OPERATIONAL_READ_SPAN_EXCEEDED')]:
            sink=MemorySink();faults=[];t=SwapTimingCollector(sink=sink,operational_authority=a,on_fault=faults.append)
            t.pending={'preflight_start_ns':1}
            self.assertEqual(operational_preflight_failure(t,read_end_ns=1+span,input_parameters=PARAMS),reason)
            self.assertEqual(faults,[] if reason is None else [reason])

    def test_policy_types_mutability_and_final_conflict_rejected(self):
        for key,value in [('max_root_poll_span_ms',True),('max_root_poll_span_ms',250.0),('max_root_poll_span_ms',float('nan')),
                          ('max_root_poll_span_ms',251),('max_final_read_span_ms',250),('version','OLD')]:
            with self.subTest(key=key,value=value),self.assertRaises(ValueError):validate_policy(POLICY|{key:value})
        with self.assertRaises(ValueError):replace(authority(),max_read_span_ms=250)
        with self.assertRaises(ValueError):replace(authority(),root_read_policy=POLICY)
        value=deepcopy(POLICY);a=replace(authority(),root_read_policy=FrozenJSON.of(value));value['max_root_poll_span_ms']=999
        self.assertEqual(a.max_root_poll_span_ms,250)

    def test_original_t0_and50ms_floor_no_reset(self):
        a=authority();t0=1_000_000_000;now=t0+250_000_000
        self.assertEqual(authority_deadline(a,observed_ns=t0,remaining_ms=13000,slice_started_ns=now,now_ns=now),t0+4_000_000_000)
        kw=dict(observed_ns=t0,remaining_ms=13000,reserve_ms=a.reserve_ms)
        self.assertEqual(operational_deadline_ns(**kw,now_ns=t0+3_950_000_000),t0+4_000_000_000)
        self.assertIsNone(operational_deadline_ns(**kw,now_ns=t0+3_950_000_001))

    def test_rejected_root_blocks_same_source_cached_offer_and_budget_wait(self):
        s=native_state();c=PolicyConfig();a=authority(s,c);baseline=BasicPolicyEngine(c).decide(s)
        b=PilotSelectionBridge(authority=a,diagnostics=MemorySink(),verified_build_sha256=a.game_build_sha256,
            enabled=True,decision_budget=True,warm_worker=True);self.addCleanup(b.close)
        now=time.perf_counter_ns();b.observe(s,c,observed_ns=now,read_end_ns=now,context=a.context)
        self.assertEqual(b.await_decision(s,baseline,c,context=a.context,stop_requested=lambda:False),'COMPLETED')
        self.assertIsNotNone(b.completed)
        b.observe(s,c,observed_ns=1,read_end_ns=250_000_002,context=a.context)
        self.assertEqual(b.select(s,baseline,c,now_ns=300_000_000,input_allowed=True,context=a.context).reason,
                         'OBSERVATION_READ_SPAN_EXCEEDED')
        self.assertEqual(b.await_decision(s,baseline,c,context=a.context,stop_requested=lambda:False),
                         'OBSERVATION_READ_SPAN_EXCEEDED')
        self.assertEqual(b.bridge_counts['decision_wait_started'],1)
        self.assertEqual(b.runner.counters['submitted'],1)
        self.assertEqual(b.last_admission['root_read_policy'],POLICY)

    def test_legacy_request_or_review_cannot_smuggle_successor_policy(self):
        fixture=operational_tests.OperationalLoaderTests()
        for target in ('request','calibration'):
            with tempfile.TemporaryDirectory() as name:
                d=Path(name);data,doc=fixture.package(d)
                if target=='request':data['root_read_policy']=POLICY
                else:
                    value=json.loads((d/data['calibration']['path']).read_text());value['root_read_policy']=POLICY
                    data['calibration']=doc('SYNTHETIC_BAD_CAL.json',value)
                with self.assertRaises(ValueError):fixture.load(d,data)

    def test_real_fake_controller_retention_preserves_read_input_ack_order(self):
        box={}
        def factory(s,c):
            a=authority(s,c);b=PilotSelectionBridge(authority=a,diagnostics=MemorySink(),
                verified_build_sha256=a.game_build_sha256,enabled=True,decision_budget=True,warm_worker=True)
            box['b']=b;self.addCleanup(b.close);return b
        def timing(s,c):
            t=SwapTimingCollector(sink=box['b'].timing_diagnostics,operational_authority=box['b'].pilot_authority,
                                  component_monitor=True);box['t']=t;return t
        with tempfile.TemporaryDirectory() as name:
            d=Path(name);base=controller_trace(d/'basic.jsonl',initial_combat=native_state(),real_processing_clock=True,timer_source='MatchService.server_tick')
            ai=controller_trace(d/'ai.jsonl',initial_combat=native_state(),real_processing_clock=True,
                timer_source='MatchService.server_tick',target_pid=7,selection_factory=factory,timing_factory=timing)
        self.assertEqual(base[1],ai[1]);self.assertEqual(ai[1].count('FAKE_NORMAL_INPUT'),1)
        self.assertEqual(ai[1].count('executor.ack'),1);self.assertTrue(box['b'].close())
        self.assertEqual(box['t'].operational_metadata['root_read_policy'],POLICY)

    def test_p19_counterfactual_is_only_stored_arithmetic(self):
        p=ROOT/'docs/phase5/artifacts/5d1_admission_coverage_review_p20_v1/p19_turn_evidence.json'
        data=json.loads(p.read_text(encoding='utf-8'));rows=data['swaps']
        self.assertEqual(len(rows),30);self.assertEqual(len(data['superseded']),3)
        self.assertEqual(sum(x['actual_budget_reason']=='OBSERVATION_READ_SPAN_EXCEEDED' for x in rows),19)
        self.assertTrue(all(x['counterfactual_root250_only']['future_worker_outcome']=='NOT_MEASURED' for x in rows))


class RootPolicyLifecycleTests(lifecycle.SessionLifecycleTests):
    """Reuse real fake-worker/session cleanup/fault races under the new authority."""
    def setUp(self):
        super().setUp()
        self.session.authority=replace(self.session.authority,max_read_span_ms=100,root_read_policy=FrozenJSON.of(POLICY))


class V4ReviewTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.temp=tempfile.TemporaryDirectory(dir=ROOT);cls.package=Path(cls.temp.name)/'review'
        # V4 remains pinned to source297. New source must use its own review.
        cls.historical_root=ROOT/'docs/phase5/artifacts/5d1_config_projection_integration_p27_v1/before'
        shutil.copytree(ROOT/'docs/phase5/artifacts/5d1_root_policy_p21_v1/review_verified',cls.package)
        cls.original=json.loads((cls.package/'calibration_review.json').read_text(encoding='utf-8'))
    @classmethod
    def tearDownClass(cls):cls.temp.cleanup()
    def setUp(self):
        self.tempdir=tempfile.TemporaryDirectory(dir=ROOT);self.addCleanup(self.tempdir.cleanup)
        self.directory=Path(self.tempdir.name)/'review';shutil.copytree(self.package,self.directory);self.data=deepcopy(self.original)
    def verify(self,root=None):
        d=self.data;return verify_review(self.directory,d,runtime_sha256=d['target_runtime_sha256'],host_sha256=d['host_sha256'],
            game_build_sha256=d['game_build_sha256'],policy_json=d['policy_json'],witness=d['proposed_scope_witness'],
            current_root=self.historical_root if root is None else root)
    def test_full_distinct_native_lineage_and_no_authority(self):
        v=self.verify();self.assertEqual((v['calibration_samples'],v['anchor_samples'],v['supplement_samples'],v['p19_samples']),(26,20,7,30))
        self.assertEqual(v['p19']['jobs'],[7,1,0]);self.assertEqual(v['cost_basis_ms'],dict(H_ms=405.3797,I_ms=2972.325))
        self.assertFalse(self.data['live_acceptance']);self.assertIsNone(v['native_U_ms'])
    def test_policy_scope_unknown_and_counts_tamper_rejected(self):
        for key,value in [('root_read_policy',POLICY|{'max_final_read_span_ms':250}),('native_U_ms',0),('host_sha256','0'*64)]:
            self.data=deepcopy(self.original);self.data[key]=value
            with self.assertRaises(ValueError):self.verify()
        self.data=deepcopy(self.original);self.data['review']['p19']['returns']=27
        with self.assertRaises(ValueError):self.verify()
    def test_source_deadline_repin_cannot_bypass_approved_body(self):
        from pokiguard_v2.reasoning_calibration import source_files
        with tempfile.TemporaryDirectory() as name:
            root=Path(name)
            for rel in source_files(self.historical_root):
                dest=root/rel;dest.parent.mkdir(parents=True,exist_ok=True);shutil.copyfile(self.historical_root/rel,dest)
            rel='src/pokiguard_v2/reasoning_operational.py';f=root/rel
            f.write_text(f.read_text(encoding='utf-8').replace('return None','return 123',1),encoding='utf-8')
            pair=self.data['changes'][rel]['after'];dest=self.directory/pair['path'];dest.write_bytes(f.read_bytes());pair.update(ref(self.directory,dest))
            files=source_files(root);target=self.directory/self.data['target_manifest']['path']
            target.write_text(json.dumps(dict(files=files,fingerprint=digest(files))),encoding='utf-8')
            self.data['target_manifest'].update(ref(self.directory,target));self.data['target_runtime_sha256']=digest(files)
            with self.assertRaises(ValueError):self.verify(root)
    def test_p19_omission_or_hash_repin_rejected(self):
        role=self.data['p19_files']['reasoning2'];dest=self.directory/role['path'];dest.write_text('',encoding='utf-8');role.update(ref(self.directory,dest))
        with self.assertRaises(ValueError):self.verify()
    def test_validated_loader_requires_independent_policy_activation(self):
        fixture=operational_tests.OperationalLoaderTests();data,doc=fixture.package(self.directory)
        data.update(runtime_sha256=self.data['target_runtime_sha256'],host_sha256=self.data['host_sha256'],
            game_build_sha256=self.data['game_build_sha256'],policy_json=self.data['policy_json'],witness=self.data['proposed_scope_witness'],
            max_read_span_ms=100,component_monitor=self.data['component_monitor'],command_ceiling_version=self.data['command_ceiling_version'],
            timing_addendum=ref(self.directory,self.directory/'parent/timing_addendum.md'),root_read_policy=POLICY,
            root_policy_contract=self.data['root_policy_contract'],calibration=ref(self.directory,self.directory/'calibration_review.json'))
        costs=dict(selector_extra_ms=12)
        data['selector_allowance']=doc('SYNTHETIC_ALLOWANCE.json',dict(scope='OFFLINE_REVIEWED_V4_SELECTOR',runtime_sha256=data['runtime_sha256'],
            host_sha256=data['host_sha256'],root_read_policy=POLICY,costs=costs,qualification=doc('SYNTHETIC_COST.json',{})))
        activation={k:data[k] for k in ['run_id','total_attempt_cap','full_config_sha256','runtime_sha256','host_sha256','contract_sha256','decision_sha256']}
        activation.update(accepted=True,scope='BOUNDED_OPERATIONAL_PILOT',root_read_policy=POLICY,
            calibration_sha256=data['calibration']['sha256'],selector_allowance_sha256=data['selector_allowance']['sha256'],root_policy_contract_sha256=P20_CONTRACT)
        data['activation_review']=doc('SYNTHETIC_ACTIVATION.json',activation);data['activation_sha256']=data['activation_review']['sha256']
        historical_verify=lambda *args,**kwargs:verify_review(*args,**kwargs,current_root=self.historical_root)
        with patch('pokiguard_v2.reasoning_root_policy.validate_costs',return_value=costs), \
                patch('pokiguard_v2.reasoning_root_policy.verify_review',side_effect=historical_verify):
            a=fixture.load(self.directory,data)
        self.assertEqual((a.max_root_poll_span_ms,a.max_read_span_ms),(250,100));self.assertIsNone(a.native_U_ms)
        activation['root_read_policy']=POLICY|{'max_root_poll_span_ms':251}
        data['activation_review']=doc('SYNTHETIC_BAD_ACTIVATION.json',activation);data['activation_sha256']=data['activation_review']['sha256']
        with self.assertRaises(ValueError):fixture.load(self.directory,data)


if __name__=='__main__':unittest.main()
