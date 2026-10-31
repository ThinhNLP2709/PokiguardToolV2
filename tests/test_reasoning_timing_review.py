"""P18 file-only and fake-controller tests. No live game/input authority."""
from copy import deepcopy
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import shutil
import tempfile
import time
from types import SimpleNamespace
import unittest
from unittest.mock import patch

from pokiguard_v2.autonomous_control import AutonomousSource
from pokiguard_v2.basic_policy import PolicyConfig, BasicPolicyEngine
from pokiguard_v2.reasoning_operational import command_wait_ms, operational_deadline_ns
from pokiguard_v2.reasoning_pilot import PilotSelectionBridge
from pokiguard_v2.reasoning_snapshot import FrozenJSON, canonical_json, digest
from pokiguard_v2.reasoning_swap_timing import SwapTimingCollector, timing_safely
from pokiguard_v2.reasoning_timing_review import (MONITOR, COMMAND, verify_timing_review, verify_sources,
    recompute_supplement, validate_costs, methods, load_reviewed_authority, QUALIFICATION_GATES)
from tests import test_reasoning_operational_lifecycle as lifecycle
from pokiguard_v2.win32_input import (ForegroundClickExecutor, NativeWin32Backend,
    WindowBinding, BoardCalibration, map_swap_to_pixels, ClickStatus)
from tests.test_win32_input import FakeBackend
from tests.test_reasoning_pilot import MemorySink
from tests.test_reasoning_operational import native_state, operational_authority, PARAMS
from tests import test_reasoning_operational as operational_tests
from tests.reasoning_controller_fixture import controller_trace
from tools.review_reasoning_timing_v3 import export_review, ROOT
from tools.review_reasoning_calibration import ref


class CommandAccountingTests(unittest.TestCase):
    def actual_wait_trace(self, settle=.06, hold=.075):
        trace=[]
        class Backend(FakeBackend):
            mouse_button_hold_seconds=hold
            # Run the real backend click implementation, replacing only native
            # down/up and sleep. No NativeWin32Backend instance/native call.
            click_mouse=NativeWin32Backend.click_mouse
            def mouse_left_down(self):trace.append(('down',None))
            def mouse_left_up(self):trace.append(('up',None))
        backend=Backend()
        executor=ForegroundClickExecutor(backend,click_delay_seconds=1.0,cursor_settle_seconds=settle,
            sleeper=lambda seconds:trace.append(('executor_wait',seconds)))
        binding=WindowBinding(5,123,'SYNTHETIC_NO_WINDOW',1280,720)
        with patch('pokiguard_v2.win32_input.random.uniform',side_effect=lambda low,high:high), \
             patch('pokiguard_v2.win32_input.time.sleep',side_effect=lambda seconds:trace.append(('hold',seconds))):
            plan=map_swap_to_pixels((4,2),(4,3),BoardCalibration(),backend.geometry)
            result=executor.send_swap(binding,plan,remaining_seconds=20)
        self.assertEqual(result.sent_clicks,2)
        self.assertEqual([kind for kind,value in trace].count('down'),2)
        self.assertEqual([kind for kind,value in trace].count('up'),2)
        return trace

    def test_C01_real_two_click_executor_maximum_has_two_settles_two_holds(self):
        trace=self.actual_wait_trace()
        self.assertEqual([v for k,v in trace if k=='executor_wait'],[1,.06,1.85,.06])
        self.assertEqual([v for k,v in trace if k=='hold'],[.075,.075])
        self.assertAlmostEqual(sum(v for k,v in trace if v is not None)*1000,3120)
        self.assertEqual(command_wait_ms(**PARAMS),3120)

    def test_C02_nonzero_and_zero_settle_follow_actual_trace(self):
        for settle,hold in ((0,.075),(.12,.09),(.25,1)):
            with self.subTest(settle=settle,hold=hold):
                trace=self.actual_wait_trace(settle,hold)
                total=sum(v for k,v in trace if v is not None)*1000
                self.assertAlmostEqual(command_wait_ms(cursor_settle_seconds=settle,mouse_button_hold_seconds=hold),total)

    def test_C03_old3060_cannot_construct_current_authority(self):
        a=operational_authority(native_state(),PolicyConfig());c=a.reserve_components.plain();c['command_wait_ms']=3060
        with self.assertRaises(ValueError):replace(a,reserve_components=FrozenJSON.of(c))

    def test_C04_invalid_parameters_and_unsupported_transport(self):
        for bad in (-1,float('nan'),float('inf'),True,.251):
            with self.subTest(bad=bad),self.assertRaises(ValueError):
                command_wait_ms(cursor_settle_seconds=bad,mouse_button_hold_seconds=.075)
        for kw in (dict(input_mode='background'),dict(board_mode='drag')):
            with self.assertRaises(ValueError):operational_authority(native_state(),PolicyConfig(),**kw)


class ComponentMonitorTests(unittest.TestCase):
    def sample(self, *, h=15_000_000, i=3_220_000_000, monitor=True, authority=True, mutate=None):
        s=native_state();c=PolicyConfig();a=operational_authority(s,c) if authority else None
        sink=MemorySink();faults=[]
        t=SwapTimingCollector(sink=sink,operational_authority=a,on_fault=faults.append,component_monitor=monitor)
        t.pending=dict(preflight_start_ns=10_000_000_000+h,decision_exit_ns=10_000_000_000,
            read_end_ns=10_000_000_000+h,validation_end_ns=10_000_000_000+h,preflight_failure=None)
        if mutate:mutate(t.pending)
        with patch('pokiguard_v2.reasoning_swap_timing.time.perf_counter_ns',return_value=10_000_000_000+h+i):
            timing_safely(t,'finish',result=SimpleNamespace(sent_clicks=2,input_mode='two_click',status=ClickStatus.SENT))
        return t,json.loads(sink.buffer.items[0])['payload'],faults

    def test_M01_exact_component_limits_do_not_fault(self):
        t,p,f=self.sample()
        self.assertFalse(t.disabled);self.assertEqual(f,[])
        self.assertEqual(p['component_limits_ns'],dict(controller_tail=15_000_000,final_input=3_220_000_000,aggregate=3_485_000_000))
        self.assertFalse(any(p['component_overruns'].values()))

    def test_setup_cached_metadata_matches_uncached_payload_bytes_and_meaning(self):
        a=operational_authority(native_state(),PolicyConfig());payloads=[]
        for monitor in (False,True):
            sink=MemorySink();t=SwapTimingCollector(sink=sink,operational_authority=a,component_monitor=monitor)
            t.pending=dict(preflight_start_ns=20_000_000,decision_exit_ns=10_000_000,
                           read_end_ns=21_000_000,validation_end_ns=22_000_000)
            with patch('pokiguard_v2.reasoning_swap_timing.time.perf_counter_ns',return_value=23_000_000):
                t.finish(result=None,status='SYNTHETIC_NO_INPUT')
            payloads.append(json.loads(sink.buffer.items[0])['payload'])
        self.assertEqual(payloads[0],{k:payloads[1][k] for k in payloads[0]})
        self.assertEqual(payloads[1]['authority_sha256'],a.identity)

    def test_M02_H_plus_one_ns_disables_AI_below_aggregate(self):
        t,p,f=self.sample(h=15_000_001)
        self.assertEqual(f,['TIMING_CONTROLLER_TAIL']);self.assertTrue(t.disabled)
        self.assertFalse(p['reserve_overrun']);self.assertTrue(p['component_overruns']['controller_tail'])
        self.assertEqual(p['operational_fault'],f[0])

    def test_M03_I_plus_one_ns_disables_AI_below_aggregate(self):
        t,p,f=self.sample(i=3_220_000_001)
        self.assertEqual(f,['TIMING_FINAL_INPUT']);self.assertFalse(p['reserve_overrun'])
        self.assertTrue(p['component_overruns']['final_input'])

    def test_M04_invalid_reversed_aggregate_and_first_fault(self):
        for mutation in (lambda p:p.update(decision_exit_ns=None),
                         lambda p:p.update(decision_exit_ns='INVALID'),
                         lambda p:p.pop('preflight_start_ns'),
                         lambda p:p.update(read_end_ns=p['preflight_start_ns']-1)):
            t,p,f=self.sample(mutate=mutation)
            self.assertEqual(f,['TIMING_INVALID_INTERVAL']);self.assertTrue(p['reserve_overrun'])
        t,p,f=self.sample(i=4_000_000_000)
        self.assertTrue(p['component_overruns']['aggregate'])
        t._fault('SECOND_FAULT')
        self.assertEqual(t.fault_reason,p['operational_fault']);self.assertEqual(len(f),1)

    def test_M06_legacy_and_basic_have_no_component_monitor(self):
        for authority in (True,False):
            t,p,f=self.sample(h=15_000_001,monitor=False,authority=authority)
            self.assertNotIn('component_monitor',p);self.assertEqual(f,[]);self.assertFalse(t.disabled)
        with self.assertRaises(ValueError):SwapTimingCollector(sink=MemorySink(),component_monitor=True)

    def test_M07_post_click_fault_preserves_real_controller_ack_and_input_count(self):
        box={}
        def factory(s,c):
            a=operational_authority(s,c)
            components=a.reserve_components.plain();components.update(controller_tail_ms=0,selector_extra_ms=0)
            a=replace(a,reserve_components=FrozenJSON.of(components))
            b=PilotSelectionBridge(authority=a,diagnostics=MemorySink(),verified_build_sha256=a.game_build_sha256,
                enabled=True,decision_budget=True,warm_worker=True)
            box['b']=b;self.addCleanup(b.close);return b
        def timing(s,c):
            b=box['b'];t=SwapTimingCollector(sink=b.timing_diagnostics,operational_authority=b.pilot_authority,
                component_monitor=True,on_fault=lambda reason:setattr(b,'disabled',True))
            box['t']=t;return t
        with tempfile.TemporaryDirectory() as name:
            d=Path(name)
            before=controller_trace(d/'basic.jsonl',initial_combat=native_state(),real_processing_clock=True,timer_source='MatchService.server_tick')
            current=controller_trace(d/'ai.jsonl',initial_combat=native_state(),real_processing_clock=True,
                timer_source='MatchService.server_tick',target_pid=7,selection_factory=factory,timing_factory=timing)
        self.assertTrue(box['b'].close());self.assertEqual(before[1],current[1])
        self.assertEqual(current[1].count('FAKE_NORMAL_INPUT'),1);self.assertEqual(current[1].count('executor.ack'),1)
        self.assertEqual(box['t'].fault_reason,'TIMING_CONTROLLER_TAIL')

    def test_M08_one_fault_matches_durable_session_receipt(self):
        from tests.test_reasoning_operational import OperationalSessionTests
        with tempfile.TemporaryDirectory() as name:
            root=Path(name);s=OperationalSessionTests().session(root)
            s.data['component_monitor']=MONITOR;s.bind_run('SYNTHETIC_FARM',root/'farm')
            try:
                t=s.collector;self.assertTrue(t.component_monitor)
                t.pending=dict(preflight_start_ns=20_000_000,decision_exit_ns=0,read_end_ns=20_000_000,validation_end_ns=20_000_000)
                with patch('pokiguard_v2.reasoning_swap_timing.time.perf_counter_ns',return_value=100_000_000):
                    t.finish(result=SimpleNamespace(sent_clicks=2,input_mode='two_click',status=ClickStatus.SENT))
                self.assertEqual(s.first_fault['reason'],t.fault_reason)
            finally:s.stop();s.finalizer.join(5)
            self.assertFalse(s.finalizer.is_alive())
            receipt=json.loads((root/'ai/watermarks.json').read_text(encoding='utf-8'))
            self.assertEqual(receipt['session']['first_fault']['reason'],t.fault_reason)
            rows=[json.loads(l) for p in (root/'ai/combat_0').glob('reasoning.*.jsonl') for l in p.read_text(encoding='utf-8').splitlines()]
            rows=[r for r in rows if r['event_type']=='reasoning.swap_timing']
            self.assertEqual(len(rows),1);self.assertEqual(rows[0]['payload']['operational_fault'],t.fault_reason)


class V3FileReviewTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.temp=tempfile.TemporaryDirectory(dir=ROOT);cls.package=Path(cls.temp.name)/'template'
        # V3 remains bound to frozen P18, not silently rebound to P21.
        cls.frozen_root=ROOT/'docs/phase5/artifacts/5d1_root_policy_p21_v1/before'
        shutil.copytree(ROOT/'docs/phase5/artifacts/5d1_source_timing_rebind_p18_v1/review_final',cls.package)
        cls.original=json.loads((cls.package/'calibration_review.json').read_text(encoding='utf-8'))
    @classmethod
    def tearDownClass(cls):cls.temp.cleanup()
    def setUp(self):
        self.tempdir=tempfile.TemporaryDirectory(dir=ROOT);self.addCleanup(self.tempdir.cleanup)
        self.directory=Path(self.tempdir.name)/'package';shutil.copytree(self.package,self.directory)
        self.data=deepcopy(self.original)
    def verify(self):
        d=self.data
        return verify_timing_review(self.directory,d,runtime_sha256=d['target_runtime_sha256'],host_sha256=d['host_sha256'],
            game_build_sha256=d['game_build_sha256'],policy_json=d['policy_json'],witness=d['proposed_scope_witness'],
            current_root=self.frozen_root)
    def rejected(self):
        with self.assertRaises((ValueError,KeyError,TypeError,IndexError)):self.verify()
    def write(self,reference,value,lines=False):
        p=self.directory/reference['path']
        p.write_text(('\n'.join(canonical_json(v) for v in value) if lines else canonical_json(value))+'\n',encoding='utf-8')
        reference['sha256']=hashlib.sha256(p.read_bytes()).hexdigest()
    def alter_raw(self,name,fn,lines=False):
        reference=self.data['p15_files']['closure/'+name];p=self.directory/reference['path']
        value=[json.loads(l) for l in p.read_text(encoding='utf-8').splitlines()] if lines else json.loads(p.read_text(encoding='utf-8'))
        fn(value);self.write(reference,value,lines)

    def test_S01_exact_offline_source_review_without_authority(self):
        r=self.verify();self.assertTrue(r['source_review']['protected_methods_exact'])
        self.assertFalse(self.data['live_acceptance']);self.assertIsNone(r['native_U_ms'])

    def test_validated_v3_loader_maps_only_recomputed_components_and_unknown_U(self):
        # Synthetic activation/cost receipt in a disposable test package. All
        # real native/source review checks still execute. No session/claim.
        fixture=operational_tests.OperationalLoaderTests();data,doc=fixture.package(self.directory)
        data.update(runtime_sha256=self.data['target_runtime_sha256'],host_sha256=self.data['host_sha256'],
            game_build_sha256=self.data['game_build_sha256'],policy_json=self.data['policy_json'],
            witness=self.data['proposed_scope_witness'],max_read_span_ms=100,component_monitor=MONITOR,
            command_ceiling_version=COMMAND,timing_addendum=self.data['addendum'],
            calibration=ref(self.directory,self.directory/'calibration_review.json'))
        costs=dict(selector_extra_ms=12)
        data['selector_allowance']=doc('SYNTHETIC_V3_ALLOWANCE.json',dict(scope='OFFLINE_REVIEWED_V3_SELECTOR',
            runtime_sha256=data['runtime_sha256'],host_sha256=data['host_sha256'],costs=costs,
            qualification=doc('SYNTHETIC_V3_COST.json',{'SYNTHETIC_NOT_REAL_QUALIFICATION':True})))
        activation={k:data[k] for k in ('run_id','total_attempt_cap','full_config_sha256','runtime_sha256',
            'host_sha256','contract_sha256','decision_sha256')}
        data['activation_review']=doc('SYNTHETIC_V3_ACTIVATION.json',activation|dict(accepted=True,scope='BOUNDED_OPERATIONAL_PILOT'))
        data['activation_sha256']=data['activation_review']['sha256']
        with self.assertRaises(ValueError):fixture.load(self.directory,data)
        # A fake installed P18 view tests the original v3 consumer; the real
        # installed P21 is deliberately rejected above.
        def frozen_sources(*args,**kwargs):
            kwargs['current_root']=self.frozen_root
            return verify_sources(*args,**kwargs)
        with patch('pokiguard_v2.reasoning_timing_review.validate_costs',return_value=costs), \
             patch('pokiguard_v2.reasoning_timing_review.verify_sources',side_effect=frozen_sources):
            a=fixture.load(self.directory,data)
        self.assertEqual(a.calibration_samples,26);self.assertIsNone(a.native_U_ms)
        self.assertEqual(a.reserve_components.plain()['controller_tail_ms'],405.3797)
        self.assertEqual(a.reserve_components.plain()['command_wait_ms'],3120)
        self.assertEqual(a.reserve_components.plain()['selector_extra_ms'],12)
        self.assertFalse((self.directory/'logs/operational_pilot_claims').exists())

    def test_S02_protected_deadline_stop_factory_edits_rejected_after_repin(self):
        # Simulate an installed successor and re-pin its bytes, map and method
        # claims. The protected AST/approved method hashes must still reject it.
        from pokiguard_v2.reasoning_calibration import source_files
        for old,new in [('return None','return 123'),('self.stopped = True','self.stopped = False'),
                        ('enabled=True, authority=self.authority','enabled=False, authority=self.authority')]:
            with self.subTest(edit=old),tempfile.TemporaryDirectory() as tmp:
                root=Path(tmp)
                for base in ('src','tools','tests'):
                    for name in source_files(self.frozen_root):
                        if name.startswith(base+'/'):
                            p=root/name;p.parent.mkdir(parents=True,exist_ok=True);shutil.copyfile(self.frozen_root/name,p)
                name='src/pokiguard_v2/reasoning_operational.py';path=root/name
                text=path.read_text(encoding='utf-8');self.assertIn(old,text);path.write_text(text.replace(old,new,1),encoding='utf-8')
                data=deepcopy(self.data);files=source_files(root);fingerprint=digest(files)
                target=self.directory/data['target_changes'][name]['after']['path'];target.write_bytes(path.read_bytes())
                data['target_changes'][name]['after']=ref(self.directory,target);data['target_methods'][name]=methods(path.read_bytes())
                self.write(data['target_manifest'],dict(files=files,fingerprint=fingerprint));data['target_runtime_sha256']=fingerprint
                with self.assertRaises(ValueError):verify_sources(self.directory,data,runtime_sha256=fingerprint,current_root=root)
                target.write_bytes((self.frozen_root/name).read_bytes())

    def test_S03_p16_approved_body_or_extra_edit_rejected(self):
        p=self.data['p16_changes']['src/pokiguard_v2/reasoning_pilot.py']['after']
        path=self.directory/p['path'];path.write_bytes(path.read_bytes()+b'\n# unreviewed\n');p.update(ref(self.directory,path))
        self.rejected()

    def test_S04_missing_extra_source_and_declared_target_forgery(self):
        self.data['target_changes'].pop('src/pokiguard_v2/reasoning_timing_review.py');self.rejected()
        self.data=deepcopy(self.original);self.data['target_runtime_sha256']='f'*64;self.rejected()

    def test_S05_host_or_source_rebind_rejected(self):
        self.data['host_sha256']='0'*64;self.rejected()

    def test_N01_all_native_rows_anchors_evolve_errors_preserved(self):
        n=self.verify()['native'];self.assertEqual((n['calibration_samples'],n['anchor_samples']),(26,20))
        self.assertEqual(n['counts']['superseded_evolve'],4);self.assertEqual(n['counts']['attempts'],3)
        self.assertEqual(n['original_errors'],['MISSING_OR_MIXED_RUNTIME_WITNESS'])

    def test_N02_omitted_opening_terminal_or_maximum_raw_rejected(self):
        base=json.loads((self.directory/self.data['base_review']['path']).read_text(encoding='utf-8'))
        name='base/'+base['archive_mapping'][base['roles']['records']]['path']
        p=self.directory/name;rows=p.read_text(encoding='utf-8').splitlines();p.write_text('\n'.join(rows[1:]),encoding='utf-8')
        self.rejected()

    def test_N03_wrong_full_source_join_rejected(self):
        name=next(n.removeprefix('closure/') for n in self.data['p15_files'] if '/reasoning.' in n)
        self.alter_raw(name,lambda rows:next(r for r in rows if r['event_type']=='reasoning.swap_timing')['payload']['autonomous_source'].update(turn=999),True)
        self.rejected()

    def test_N04_forged_terminal_or_partial_input_rejected(self):
        self.alter_raw('farm_run/run.json',lambda r:r['snapshot']['attempts'][0]['terminal_snapshot'].update(boss_hp=1));self.rejected()

    def test_N05_supplement_cannot_be_relabeled_BASIC_or_33anchors(self):
        self.data['review']['supplement']['scope']='BASIC_CALIBRATION_ONLY';self.rejected()
        self.data=deepcopy(self.original);self.data['review']['anchor_samples']=33;self.rejected()

    def test_N06_root_vetoed_costs_retained(self):
        s=self.verify()['supplement'];self.assertEqual(s['root_span_vetoes'],5)
        self.assertEqual(s['maxima_ms']['H_ms'],405.3797)
        self.data['review']['supplement']['intervals'].pop();self.rejected()

    def test_N07_missing16_and_unknown_live_fault_not_filled(self):
        self.data['review']['supplement']['missing_swap_timings']=0;self.rejected()
        self.data=deepcopy(self.original);self.data['review']['supplement']['live_fault_reason']='CLOSED';self.rejected()

    def test_N08_p15_watermark_raw_hash_or_sequence_change_rejected(self):
        self.alter_raw('operational_pilot/watermarks.json',lambda w:w.update(collector_dropped=1));self.rejected()

    def test_M05_monitor_guard_span_margin_required(self):
        for field,value in [('component_monitor',False),('command_ceiling_version','OLD'),('native_U_ms',0)]:
            with self.subTest(field=field):
                self.data=deepcopy(self.original);self.data[field]=value;self.rejected()
        fake=SimpleNamespace(runtime_sha256=self.data['target_runtime_sha256'])
        for key,value in [('component_monitor',False),('max_read_span_ms',101),('host_guard_ms',249),('return_margin_ms',99)]:
            data=dict(component_monitor=MONITOR,command_ceiling_version=COMMAND,max_read_span_ms=100,host_guard_ms=250,
                      return_margin_ms=100,total_attempt_cap=3);data[key]=value
            with self.subTest(key=key),self.assertRaises(ValueError):
                load_reviewed_authority(self.directory,data,self.data,fake,policy_json=self.data['policy_json'],now=0)

    def test_U01_strict_finite_U_and_all_unknown_fields_stay_null(self):
        for field in ('native_U_ms','transport_age_ms','host_unity_alignment_ms'):
            self.data=deepcopy(self.original);self.data[field]=0;self.rejected()
        from pokiguard_v2.reasoning_pilot_contract import PilotAuthority
        self.assertIsNone(self.original['native_U_ms'])


class CostProofTests(unittest.TestCase):
    def synthetic_costs(self,d):
        """Complete artificial raw cost fixture; never exported as real proof."""
        from pokiguard_v2.reasoning_calibration import source_files, source_fingerprint
        from pokiguard_v2.reasoning_operational import host_fingerprint
        from tools.qualify_reasoning_selection import quantiles
        q=dict(schema='5d1.p18.qualification.v1',component_monitor=MONITOR,runtime_sha256=source_fingerprint(ROOT),
               host_sha256=host_fingerprint(),pass_all=True,gates={k:True for k in QUALIFICATION_GATES},
               stress=dict(seconds=60,max_queued_records=1,peak_traced_bytes=1024))
        for filename,modes,key,cpukey in [
            ('checkpoint_raw.jsonl',('disabled','completed','timeout','error','fallback'),'selector_paths_ms','mean_cpu_ms_per_three_checkpoints'),
            ('admission_raw.jsonl',('admitted','span_rejected','clock_rejected','busy'),'admission_paths_ms','admission_mean_cpu_ms')]:
            q[key]={};q[cpukey]={}
            with (d/filename).open('w',encoding='utf-8') as f:
                for mode in modes:
                    values=[]
                    for index in range(6000):
                        ms=.4 if index==5999 else .1;values.append(ms)
                        f.write(canonical_json(dict(path=mode,index=index,warmup=index<1000,ms=ms,cpu_ms=.0))+'\n')
                    q[key][mode]=quantiles(values[1000:]);q[cpukey][mode]=.0
        with (d/'pipeline_raw.jsonl').open('w',encoding='utf-8') as f:
            for index in range(6000):f.write(canonical_json(dict(index=index,warmup=index<1000,ms=.1))+'\n')
        q['full_timing_pipeline_ms']=quantiles([.1]*5000);q['stop_ms']=quantiles([.01]*1000)
        (d/'stop_raw.json').write_text(canonical_json([.01]*1000),encoding='utf-8')
        (d/'source_manifest.json').write_text(canonical_json(dict(files=source_files(ROOT),fingerprint=q['runtime_sha256'])),encoding='utf-8')
        q['raw_sha256']={n:hashlib.sha256((d/n).read_bytes()).hexdigest() for n in
            ('checkpoint_raw.jsonl','admission_raw.jsonl','pipeline_raw.jsonl','stop_raw.json','source_manifest.json')}
        return q

    def test_Q01_raw_positive_is_checked_against_actual_final_source(self):
        with tempfile.TemporaryDirectory() as name:
            d=Path(name);q=self.synthetic_costs(d);costs=validate_costs(d,q)
            self.assertEqual(costs['raw_values'],61000);self.assertEqual(costs['selector_extra_ms'],.5)
            q['runtime_sha256']='0'*64
            with self.assertRaises(ValueError):validate_costs(d,q)

    def test_Q02_forged_pass_or_omitted_raw_cannot_grant_allowance(self):
        with tempfile.TemporaryDirectory() as name:
            d=Path(name);q=self.synthetic_costs(d)
            for mutation in ('summary','warmup','missing','duplicate'):
                with self.subTest(mutation=mutation):
                    changed=deepcopy(q)
                    if mutation=='summary':
                        changed['selector_paths_ms']['completed']['max']=.1
                    else:
                        rows=(d/'checkpoint_raw.jsonl').read_text(encoding='utf-8').splitlines()
                        if mutation=='warmup':
                            row=json.loads(rows[1000]);row['warmup']=True;rows[1000]=canonical_json(row)
                        elif mutation=='missing':rows.pop()
                        else:rows[5999]=rows[5998]
                        (d/'bad_raw.jsonl').write_text('\n'.join(rows)+'\n',encoding='utf-8')
                        # Re-pin the changed raw; index/warmup/summary checks,
                        # rather than a stale SHA, must reject it.
                        original=(d/'checkpoint_raw.jsonl').read_bytes()
                        (d/'checkpoint_raw.jsonl').write_bytes((d/'bad_raw.jsonl').read_bytes())
                        changed['raw_sha256']['checkpoint_raw.jsonl']=hashlib.sha256((d/'checkpoint_raw.jsonl').read_bytes()).hexdigest()
                    with self.assertRaises(ValueError):validate_costs(d,changed)
                    if mutation!='summary':(d/'checkpoint_raw.jsonl').write_bytes(original)

    def test_Q03_stress_receipt_explicit_limit_and_no_override_quota(self):
        with tempfile.TemporaryDirectory() as name:
            d=Path(name);q=self.synthetic_costs(d);costs=validate_costs(d,q)
            self.assertEqual(costs['stress_evidence'],'RECEIPT_ONLY_NO_PER_CYCLE_TRACE')
            self.assertEqual(costs['completed_branch'],'RETENTION_ONLY_NO_OVERRIDE_QUOTA')

    def test_D01_original_deadline_no_reset_short_window(self):
        kwargs=dict(observed_ns=1_000_000_000,remaining_ms=7000,reserve_ms=6761.9149)
        first=operational_deadline_ns(now_ns=1_000_000_000,**kwargs)
        self.assertEqual(first,1_138_085_100)
        self.assertIsNone(operational_deadline_ns(now_ns=1_100_000_000,**kwargs))

    def test_D02_completed_retention_does_not_require_override(self):
        s=native_state();c=PolicyConfig();a=operational_authority(s,c)
        b=PilotSelectionBridge(authority=a,diagnostics=MemorySink(),verified_build_sha256=a.game_build_sha256,
            enabled=True,decision_budget=True,warm_worker=True)
        try:
            now=time.perf_counter_ns();b.observe(s,c,observed_ns=now,read_end_ns=now,context=a.context)
            self.assertEqual(b.await_decision(s,BasicPolicyEngine(c).decide(s),c,context=a.context,stop_requested=lambda:False),'COMPLETED')
            self.assertEqual(b.completed.reply.disposition,'RETAIN_BASELINE');self.assertIsNone(b.completed.reply.proposal)
        finally:self.assertTrue(b.close())

    def test_L01_monitor_stop_is_signal_only_and_idempotent(self):
        t=SwapTimingCollector(sink=MemorySink(),operational_authority=operational_authority(native_state(),PolicyConfig()),component_monitor=True)
        begin=time.perf_counter();t.stop();t.stop()
        self.assertLess(time.perf_counter()-begin,.025);self.assertTrue(t.stopped)

    def test_L02_expired_request_cannot_reach_review_or_create_claim(self):
        with tempfile.TemporaryDirectory() as name:
            d=Path(name);fixture=operational_tests.OperationalLoaderTests();data,_=fixture.package(d)
            data['expires_at']=150
            with self.assertRaises(ValueError):fixture.load(d,data)
            self.assertFalse((d/'logs/operational_pilot_claims').exists())

    def test_L03_ordinary_default_has_no_operational_metadata_or_monitor(self):
        t=SwapTimingCollector(sink=MemorySink());self.assertFalse(t.component_monitor)
        self.assertFalse(hasattr(t,'operational_metadata'))


class V3SessionLifecycleTests(lifecycle.SessionLifecycleTests):
    """The unchanged P16 lifecycle/race suite, now with the validated mode on."""
    def setUp(self):
        super().setUp()
        self.session.data['component_monitor']=MONITOR


if __name__=='__main__':unittest.main()
