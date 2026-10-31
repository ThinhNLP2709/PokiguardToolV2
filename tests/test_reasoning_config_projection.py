from tests.game_update_fixture import historical_test_view
"""P27 integration proof using legacy oracles and explicit offline fakes."""
from copy import deepcopy
from dataclasses import fields, replace
import hashlib
import importlib.util
import json
from pathlib import Path
import shutil
import sys
import tempfile
from types import SimpleNamespace
import unittest
from unittest.mock import patch

from pokiguard_v2.basic_policy import PolicyConfig
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.autonomous_control import AutonomousSource
from pokiguard_v2.reasoning_snapshot import FrozenJSON, digest
from pokiguard_v2.reasoning_swap_timing import SwapTimingCollector, timing_safely
from pokiguard_v2 import reasoning_config_projection as projection
from pokiguard_v2.reasoning_projection_review import verify_review, verify_sources
from pokiguard_v2 import reasoning_root_policy as v4
from tests.test_reasoning_root_policy import authority as root_authority
from tests.test_reasoning_pilot import MemorySink
from tests import test_reasoning_operational_lifecycle as lifecycle
from tests.test_reasoning_operational import native_state, PARAMS
from tests.reasoning_controller_fixture import controller_trace, assert_c3_source_compatibility
from tools.review_reasoning_projection import ROOT, export_review, prepare_draft

ART = ROOT/'docs/phase5/artifacts/5d1_config_projection_integration_p27_v1'
P26 = ROOT/'docs/phase5/artifacts/5d1_config_serialization_proof_p26_v1'


def authority(s=None, c=None):
    a=root_authority(s,c)
    return replace(a,config_projection_policy=projection.VERSION)


def module(path, name):
    spec=importlib.util.spec_from_file_location(name,path);value=importlib.util.module_from_spec(spec)
    sys.modules[name]=value;spec.loader.exec_module(value);return value


def legacy_collector():
    return module(ART/'before/src/pokiguard_v2/reasoning_swap_timing.py',
                  'pokiguard_v2._p27_legacy_collector').SwapTimingCollector


def p26_lib():
    with patch.object(sys,'path',[str(P26/'harness')]+sys.path):
        proof=module(P26/'harness/prove_config_projection.py','_p27_inherited_p26_proof')
        lib=proof.imports();lib.candidate=projection
        # The sealed P26 corpus has 18 fields; the new target is tested below
        # against all current fields rather than rewriting historical artifacts.
        saved=ROOT/'docs/artifacts/demon_target_gem_20261022'
        manifest=json.loads((saved/'before_source.json').read_text('utf-8'))
        path=saved/'before/src/pokiguard_v2/basic_policy.py'
        assert hashlib.sha256(path.read_bytes()).hexdigest()==manifest['files']['src/pokiguard_v2/basic_policy.py']
        old=module(path,'pokiguard_v2._before_demon_target_policy')
        lib.PolicyConfig=old.PolicyConfig
        for name,enum in (('play_style',old.PlayStyle),('mana_priority',old.ManaPriority),
                          ('intelligence',old.Intelligence)):
            lib.enums[name]=enum
    return proof,lib


class ProjectionTests(unittest.TestCase):
    def test_current_target_enum_is_included_in_fast_projection_without_cache(self):
        from pokiguard_v2.gameplay_profile import DemonTargetGem
        for target in DemonTargetGem:
            c=replace(PolicyConfig(),demon_target_gem=target)
            expected=jsonable(c)
            with patch.object(projection,'jsonable',side_effect=AssertionError('unexpected fallback')):
                self.assertEqual(projection.project_config(c),expected)
            self.assertEqual(expected['demon_target_gem'],target.value)

    def test_exact_inherited118_parity_cases_and_all18_current_fields(self):
        proof,lib=p26_lib();result,corpus=proof.parity_proof(lib)
        original=json.loads((P26/'parity_proof.json').read_text(encoding='utf-8'))
        self.assertEqual(result['case_count'],118);self.assertEqual(result['failed'],[])
        self.assertEqual([x['label'] for x in result['case_records']],
                         [x['label'] for x in original['case_records']])
        self.assertEqual(len(result['all18_field_replacements']),18)
        self.assertEqual(len(corpus),67)

    def test_successor_is_immutable_distinct_and_cannot_spoof_policy(self):
        a=authority();old=root_authority()
        self.assertNotEqual(a.identity,old.identity)
        with self.assertRaises(ValueError):replace(a,config_projection_policy='unreviewed')
        with self.assertRaises(ValueError):replace(a,root_read_policy=None)
        self.assertEqual((a.max_root_poll_span_ms,a.max_read_span_ms),(250,100))
        self.assertIsNone(a.native_U_ms)

    def exercise(self,cls,*,config=None,monitor=True,a=None,bad_source=False,bad_params=False,overrun=False):
        s=native_state();c=config if config is not None else PolicyConfig();sink=MemorySink();faults=[]
        t=cls(sink=sink,run_id='SYNTHETIC',operational_authority=a,component_monitor=monitor,on_fault=faults.append)
        ticks=iter(range(1_000_000,1_001_000,10))
        with patch('time.perf_counter_ns',side_effect=lambda:next(ticks)),patch('time.time_ns',return_value=123):
            t.observe_start();t.observe_end(state=s)
            t.decision(state=s,config=c,input_parameters={} if bad_params else PARAMS)
            t.checkpoint(name='fresh');t.checkpoint(name='final')
            t.start(state=s,config=c,input_mode='foreground',
                source_hash='changed' if bad_source else AutonomousSource.from_state(s).critical_state_hash)
            t.preflight(remaining=12,failure=None,read_end_ns=1_000_060)
            if overrun:t.component_limits['controller_tail']=0
            t.finish(result=None,status='SYNTHETIC_NO_INPUT');t.stop()
        return sink.buffer.items,faults,t.disabled,t.fault_reason

    def test_real_before_after_payload_field_clock_fault_equivalence(self):
        old=legacy_collector()
        for a,monitor in [(None,False),(root_authority(),False),(root_authority(),True),
                          (authority(),False),(authority(),True)]:
            for changes in ({},{'bad_source':True},{'bad_params':True}):
                with self.subTest(kind=type(a).__name__,monitor=monitor,changes=changes):
                    self.assertEqual(self.exercise(old,a=a,monitor=monitor,**changes),
                                     self.exercise(SwapTimingCollector,a=a,monitor=monitor,**changes))
        for changes in ({},{'overrun':True}):
            a=authority()
            self.assertEqual(self.exercise(old,a=a,**changes),self.exercise(SwapTimingCollector,a=a,**changes))

    def test_only_exact_successor_plus_monitor_uses_projection(self):
        a=authority()
        for value,monitor,want in [(None,False,0),(root_authority(),False,0),(root_authority(),True,0),
                                   (a,False,0),(a,True,1)]:
            with patch.object(projection,'project_config',wraps=projection.project_config) as spy:
                self.exercise(SwapTimingCollector,a=value,monitor=monitor)
                self.assertEqual(spy.call_count,want)

    def test_actual_collector_uses_all_current_config_and_identical_exceptions(self):
        proof,lib=p26_lib();cases,base,replacements=proof.build_cases(lib);old=legacy_collector();s=native_state();a=authority()
        def outcome(cls,c):
            t=cls(sink=MemorySink(),operational_authority=a,component_monitor=True)
            try:
                with patch('pokiguard_v2.reasoning_pilot_contract.runtime_witness',return_value=a.witness), \
                        patch('time.perf_counter_ns',return_value=1):
                    t.start(state=s,config=c,input_mode='foreground',source_hash='x')
                return t.pending
            except Exception as exc:return type(exc).__name__,str(exc)
        for case in cases:
            with self.subTest(case=case['label']):self.assertEqual(outcome(old,case['config']),outcome(SwapTimingCollector,case['config']))
        t=SwapTimingCollector(sink=MemorySink(),operational_authority=a,component_monitor=True)
        for c in [base,replace(base,boss_high_mana=999),base]:
            t.start(state=s,config=c,input_mode='foreground',source_hash='x')
            self.assertEqual(t.pending['policy_sha256'],digest(jsonable(c)))
        c=replace(base);object.__setattr__(c,'boss_high_mana',998)
        t.start(state=s,config=c,input_mode='foreground',source_hash='x')
        self.assertEqual(t.pending['policy_sha256'],digest(jsonable(c)))

    def test_no_witness_hash_reuse_and_exact_call_order(self):
        s=native_state();c=PolicyConfig();a=authority();t=SwapTimingCollector(sink=MemorySink(),operational_authority=a,component_monitor=True)
        events=[]
        from pokiguard_v2.reasoning_pilot_contract import runtime_witness
        original_source=AutonomousSource.from_state;original_project=projection.project_config
        def witness(*args):events.append('witness');return runtime_witness(*args)
        def source(*args):events.append('source');return original_source(*args)
        def project(*args):events.append('config');return original_project(*args)
        def clock():events.append('timestamp');return 1
        with patch('pokiguard_v2.reasoning_pilot_contract.runtime_witness',side_effect=witness), \
                patch.object(AutonomousSource,'from_state',side_effect=source), \
                patch.object(projection,'project_config',side_effect=project),patch('time.perf_counter_ns',side_effect=clock):
            for _ in range(2):t.start(state=s,config=c,input_mode='foreground',source_hash='x')
        self.assertEqual(events,['witness','source','config','timestamp']*2)

    def test_ai_timing_error_isolated_by_existing_safe_seam(self):
        s=native_state();t=SwapTimingCollector(sink=MemorySink(),operational_authority=authority(),component_monitor=True)
        with patch.object(projection,'project_config',side_effect=RuntimeError('SYNTHETIC_AI_ONLY')):
            self.assertIsNone(timing_safely(t,'start',state=s,config=PolicyConfig(),input_mode='foreground',source_hash='x'))
        self.assertTrue(t.disabled);self.assertIsNone(t.pending)

    def test_controller_read_input_ack_parity_with_successor_and_ai_failure(self):
        from pokiguard_v2.reasoning_pilot import PilotSelectionBridge
        for fail in ('none','exception','post_return'):
            box={}
            def factory(s,c):
                a=authority(s,c);b=PilotSelectionBridge(authority=a,diagnostics=MemorySink(),
                    verified_build_sha256=a.game_build_sha256,enabled=True,decision_budget=True,warm_worker=True)
                box['b']=b;self.addCleanup(b.close);return b
            def timing(s,c):
                t=SwapTimingCollector(sink=box['b'].timing_diagnostics,operational_authority=box['b'].pilot_authority,component_monitor=True)
                if fail=='post_return':t.component_limits['controller_tail']=0
                box['t']=t;return t
            with tempfile.TemporaryDirectory() as name:
                d=Path(name);kwargs=dict(initial_combat=native_state(),real_processing_clock=True,timer_source='MatchService.server_tick')
                base=controller_trace(d/'basic.jsonl',**kwargs)
                if fail=='exception':
                    with patch.object(projection,'project_config',side_effect=RuntimeError('SYNTHETIC_AI_ONLY')):
                        ai=controller_trace(d/'ai.jsonl',**kwargs,target_pid=7,selection_factory=factory,timing_factory=timing)
                else:ai=controller_trace(d/'ai.jsonl',**kwargs,target_pid=7,selection_factory=factory,timing_factory=timing)
            self.assertEqual(base[1],ai[1]);self.assertEqual(ai[1].count('FAKE_NORMAL_INPUT'),1)
            self.assertEqual(ai[1].count('executor.ack'),1)
            self.assertTrue(box['b'].close())

    @historical_test_view()
    def test_exact_historical_fixture_ancestry(self):assert_c3_source_compatibility(self)

    def test_fixture_pair_checks_fresh_bytes_on_next_invocation(self):
        from tests.reasoning_controller_fixture import before_p27_path
        target=ROOT/'src/pokiguard_v2/reasoning_swap_timing.py'
        before_p27_path(ROOT,target.relative_to(ROOT).as_posix())
        original=Path.read_bytes
        def changed(p):return b'SYNTHETIC_TAMPER' if p==target else original(p)
        with patch.object(Path,'read_bytes',changed),self.assertRaises(AssertionError):
            before_p27_path(ROOT,target.relative_to(ROOT).as_posix())
        before_p27_path(ROOT,target.relative_to(ROOT).as_posix())

    def test_legacy_and_v2_v3_v4_requests_cannot_smuggle_projection_opt_in(self):
        from tests.test_reasoning_operational import OperationalLoaderTests
        fixture=OperationalLoaderTests()
        for schema in (None,'pokiguard.reasoning.operational_calibration_review.v2',
                       'pokiguard.reasoning.operational_calibration_review.v3',v4.SCHEMA):
            for target in ('request','calibration'):
                with tempfile.TemporaryDirectory() as name:
                    d=Path(name);data,doc=fixture.package(d)
                    value=json.loads((d/data['calibration']['path']).read_text(encoding='utf-8'))
                    if schema:value['schema']=schema
                    if target=='request':data['config_projection_policy']=projection.VERSION
                    else:value['config_projection_policy']=projection.VERSION
                    data['calibration']=doc('SYNTHETIC_BAD_CAL.json',value)
                    with self.assertRaisesRegex(ValueError,'projection successor native binding pending'):
                        fixture.load(d,data)


class ProjectionLifecycleTests(lifecycle.SessionLifecycleTests):
    def setUp(self):
        super().setUp()
        self.session.authority=replace(self.session.authority,max_read_span_ms=100,
            root_read_policy=FrozenJSON.of(v4.POLICY),config_projection_policy=projection.VERSION)


class ProjectionReviewTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.temp=tempfile.TemporaryDirectory(dir=ROOT);cls.package=Path(cls.temp.name)/'review'
        cls.historical_root=ROOT/'docs/phase5/artifacts/5d1_offline_closeout_v1/before'
        shutil.copytree(ART/'review_verified',cls.package)
        cls.original=json.loads((cls.package/'source_review.json').read_text(encoding='utf-8'))
    @classmethod
    def tearDownClass(cls):cls.temp.cleanup()
    def setUp(self):
        temp=tempfile.TemporaryDirectory(dir=ROOT);self.addCleanup(temp.cleanup)
        self.directory=Path(temp.name)/'review';shutil.copytree(self.package,self.directory);self.data=deepcopy(self.original)
    def verify(self,root=None):
        return verify_review(self.directory,self.data,runtime_sha256=self.data['target_runtime_sha256'],
                             host_sha256=self.data['host_sha256'],current_root=self.historical_root if root is None else root)
    def test_exact_source_review_separate_native_cohorts_pending_H(self):
        result=self.verify();p=result['historical_native']
        self.assertEqual((p['calibration_samples'],p['anchor_samples'],p['supplement_samples'],p['p19_samples']),(26,20,7,30))
        self.assertEqual(result['historical_cost_basis_ms'],dict(H_ms=405.3797,I_ms=2972.325))
        self.assertIsNone(result['current_native_cost_basis_ms']);self.assertFalse(result['activation_supported'])
    def test_original_v4_rejects_actual_new_source(self):
        p=self.directory/'parent';d=json.loads((p/'calibration_review.json').read_text(encoding='utf-8'))
        with self.assertRaises(ValueError):v4.verify_sources(p,d,runtime_sha256=self.data['target_runtime_sha256'],current_root=ROOT)
    def test_source_and_repin_tamper_fail_closed(self):
        from pokiguard_v2.reasoning_calibration import source_files
        from tools.review_reasoning_calibration import ref
        with tempfile.TemporaryDirectory() as name:
            root=Path(name)
            for rel in source_files(self.historical_root):
                dest=root/rel;dest.parent.mkdir(parents=True,exist_ok=True);shutil.copyfile(self.historical_root/rel,dest)
            rel='src/pokiguard_v2/reasoning_swap_timing.py';f=root/rel
            f.write_text(f.read_text(encoding='utf-8').replace('self.component_monitor and self.authority.config_projection_policy',
                         'True and self.authority.config_projection_policy'),encoding='utf-8')
            pair=self.data['changes'][rel]['after'];dest=self.directory/pair['path'];dest.write_bytes(f.read_bytes());pair.update(ref(self.directory,dest))
            files=source_files(root);target=self.directory/self.data['target_manifest']['path']
            target.write_text(json.dumps(dict(files=files,fingerprint=digest(files))),encoding='utf-8')
            self.data['target_manifest'].update(ref(self.directory,target));self.data['target_runtime_sha256']=digest(files)
            with self.assertRaises(ValueError):self.verify(root)
    def test_proof_pending_or_host_tamper_rejected(self):
        for key,value in [('native_binding','ACCEPTED'),('native_U_ms',0),('host_sha256','0'*64)]:
            self.data=deepcopy(self.original);self.data[key]=value
            with self.assertRaises(ValueError):
                verify_review(self.directory,self.data,runtime_sha256=self.data['target_runtime_sha256'],host_sha256=self.original['host_sha256'])
        self.data=deepcopy(self.original);self.data['candidate']['sha256']='0'*64
        with self.assertRaises(ValueError):self.verify()
    def test_native_pending_blocks_draft_even_with_costs_pass_and_creates_nothing(self):
        q=self.directory/'SYNTHETIC_Q.json';q.write_text('{}',encoding='utf-8');out=self.directory/'no_draft'
        historical=lambda *a,**kw:verify_review(*a,**kw,current_root=self.historical_root)
        with patch('tools.review_reasoning_projection.validate_costs',return_value={'selector_extra_ms':1}), \
                patch('tools.review_reasoning_projection.verify_review',side_effect=historical), \
                patch('tools.review_reasoning_projection.source_fingerprint',return_value=self.original['target_runtime_sha256']):
            with self.assertRaisesRegex(ValueError,'native H source binding pending'):
                prepare_draft(self.directory/'source_review.json',q,out)
        self.assertFalse(out.exists())


if __name__=='__main__':unittest.main()
