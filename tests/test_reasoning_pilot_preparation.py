"""P2 offline component/failure tests; no native input or calibration claims."""
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import tempfile
import time
import unittest
from unittest.mock import patch
import uuid

from pokiguard_v2.basic_policy import PolicyConfig, PlayStyle
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.reasoning_pilot import PilotSelectionBridge
from pokiguard_v2.reasoning_warm_runner import WarmIsolatedRunner
from pokiguard_v2.reasoning_pilot_activation import PilotArtifactRequest, load_pilot_authority, SCHEMA
from pokiguard_v2.reasoning_swap_timing import (SwapTimingCollector, SwapTimingRequest,
    SwapTimingSession, timing_safely, prepare_reasoning_options_safely)
from pokiguard_v2.reasoning_snapshot import canonical_json
from tests.test_reasoning_pilot import MemorySink, scoped_state, pilot_authority
from tests.test_reasoning_selection import completed_fixture, original_controller
from tests.reasoning_controller_fixture import controller_trace
from tests.reasoning_worker_fixtures import hang, corrupt, raises


def wait_for(predicate, seconds=4):
    end = time.perf_counter()+seconds
    while time.perf_counter()<end:
        if predicate(): return
        time.sleep(.002)
    raise AssertionError("offline component deadline")


class WarmRunnerTests(unittest.TestCase):
    def job(self):
        s=scoped_state();c=PolicyConfig(minimum_turn_time_seconds=1,minimum_evolve_time_seconds=1)
        old=completed_fixture(s,c)[3]['job']
        now=time.perf_counter_ns()
        return replace(old,job_id=uuid.uuid4().hex,created_ns=now,deadline_ns=now+4_000_000_000)

    def test_two_real_jobs_reuse_one_child_and_reap_on_stop(self):
        runner=WarmIsolatedRunner();self.addCleanup(runner.close)
        wait_for(runner.ready.is_set)
        for _ in range(2):
            job=self.job();self.assertTrue(runner.submit(job))
            wait_for(lambda: runner.outcome is not None)
            self.assertIsNotNone(runner.outcome[0])
            self.assertEqual(runner.current.job_id,job.job_id)
        self.assertEqual(runner.counters['processes'],1)
        self.assertTrue(runner.close())
        self.assertEqual(runner.counters['reaped'],1)

    def test_stop_hung_child_is_signal_only_and_reaped_off_caller(self):
        runner=WarmIsolatedRunner(compute=hang);self.addCleanup(runner.close)
        wait_for(runner.ready.is_set)
        self.assertTrue(runner.submit(self.job()))
        wait_for(lambda:runner.active_job is not None)
        start=time.perf_counter();runner.stop()
        self.assertLess(time.perf_counter()-start,.05)
        self.assertTrue(runner.close())
        self.assertEqual(runner.counters['reaped'],1)

    def test_deadline_does_not_reset_after_warm_start(self):
        runner=WarmIsolatedRunner();self.addCleanup(runner.close)
        job=self.job();job=replace(job,deadline_ns=job.created_ns+50_000_000)
        self.assertTrue(runner.submit(job))
        wait_for(lambda:runner.outcome is not None)
        self.assertIsNone(runner.outcome[0]);self.assertEqual(runner.outcome[1],'DEADLINE')
        self.assertEqual(runner.current.deadline_ns,job.deadline_ns)

    def test_worker_faults_retire_child_and_keep_baseline(self):
        for compute in (corrupt,raises):
            with self.subTest(compute=compute.__name__):
                runner=WarmIsolatedRunner(compute=compute);self.addCleanup(runner.close)
                wait_for(runner.ready.is_set);job=self.job();runner.submit(job)
                wait_for(lambda:runner.outcome is not None)
                self.assertIsNone(runner.outcome[0]);self.assertGreater(runner.counters['faults'],0)
                self.assertFalse(runner.disposition(job,current_binding=job.binding).used_proposal)
                self.assertTrue(runner.close())

    def test_stop_during_startup_leaves_no_worker(self):
        runner=WarmIsolatedRunner();runner.stop()
        self.assertTrue(runner.close())
        self.assertEqual(runner.counters['processes'],runner.counters['reaped'])


class TimingTests(unittest.TestCase):
    def test_session_keeps_writer_across_matches_and_stops_once_per_run(self):
        from pokiguard_v2.desktop_control_plane import DesktopConfig
        config=DesktopConfig(max_match_attempts=3)
        request=SwapTimingRequest('OFFLINE',canonical_json(jsonable(config)),3)
        sink=MemorySink();sink.stop=lambda:None
        with patch('pokiguard_v2.reasoning_swap_timing.BoundedDiagnostics',return_value=sink):
            session=SwapTimingSession(request,config=config,directory=Path('unused'))
        first=session.prepare_options()['swap_timing_adapter'];first.sequence=7;first.stop()
        second=session.prepare_options()['swap_timing_adapter']
        self.assertIsNot(first,second);self.assertFalse(second.stopped)
        self.assertEqual(second.sequence,7)
        session.stop();self.assertEqual(session.prepare_options(),{})

    def test_actual_controller_instrumentation_preserves_input_and_ack_order(self):
        box={}
        def factory(state,config):
            b=SwapTimingCollector(sink=MemorySink());box['collector']=b;return b
        with tempfile.TemporaryDirectory() as d:
            new=controller_trace(Path(d)/'new.jsonl',initial_combat=scoped_state(),timing_factory=factory,
                                 real_processing_clock=True)
            old=controller_trace(Path(d)/'old.jsonl',initial_combat=scoped_state(),controller_module=original_controller())
        self.assertEqual(new[1],old[1]);self.assertEqual(new[1].count('executor.ack'),1)
        events=[json.loads(b) for b in box['collector'].sink.buffer.items]
        self.assertEqual(len(events),1)
        p=events[0]['payload'];self.assertTrue(p['required_input_completed'])
        self.assertLessEqual(p['preflight_start_ns'],p['read_end_ns'])
        self.assertLessEqual(p['read_end_ns'],p['executor_return_ns'])
        self.assertEqual(p['native_timer_bound'],'UNBOUND')

    def test_preflight_rejection_is_not_completed_duration(self):
        box={}
        def factory(*_):
            box['b']=SwapTimingCollector(sink=MemorySink());return box['b']
        with tempfile.TemporaryDirectory() as d:
            (_,calls,_)=controller_trace(Path(d)/'x.jsonl',case='wrong_turn',initial_combat=scoped_state(),
                                         timing_factory=factory,real_processing_clock=True)
        self.assertNotIn('FAKE_NORMAL_INPUT',calls)
        p=json.loads(box['b'].sink.buffer.items[0])['payload']
        self.assertFalse(p['required_input_completed']);self.assertEqual(p['status'],'PREFLIGHT_REJECTED')

    def test_sink_exception_only_disables_telemetry(self):
        b=SwapTimingCollector(sink=MemorySink())
        b.sink.enqueue=lambda *_a,**_k: (_ for _ in ()).throw(OSError('offline fault'))
        state=scoped_state();config=PolicyConfig()
        timing_safely(b,'start',state=state,config=config,input_mode='foreground',source_hash='x')
        timing_safely(b,'finish',result=None)
        self.assertTrue(b.disabled);self.assertEqual(b.dropped,1)

    def test_bad_session_or_option_cannot_add_unowned_input_arguments(self):
        class Bad:
            def prepare_options(self):return {'executor':'forbidden'}
        self.assertEqual(prepare_reasoning_options_safely(Bad()),{})
        self.assertEqual(prepare_reasoning_options_safely(object()),{})


class ArtifactTests(unittest.TestCase):
    def make_data(self, directory):
        state=scoped_state();config=PolicyConfig(minimum_turn_time_seconds=1,minimum_evolve_time_seconds=1)
        state=replace(state,battle=replace(state.battle,turn_timer_source='MatchService.server_tick'))
        a=pilot_authority(state,config,minimal_model=True)
        collector=SwapTimingCollector(sink=MemorySink())
        collector.start(state=state,config=config,input_mode='foreground',source_hash='s'*64)
        collector.preflight(remaining=12,failure=None,read_end_ns=time.perf_counter_ns())
        from pokiguard_v2.win32_input import ClickStatus
        collector.finish(result=type('Result',(),{'sent_clicks':2,'input_mode':'two_click','status':ClickStatus.SENT})())
        record=directory/'timing.jsonl';record.write_bytes(collector.sink.buffer.items[0]+b'\n')
        proof=dict(verdict='ACCEPTED_BOUNDED_NATIVE_TIMER',game_build_sha256='1'*64,
            runtime_sha256='3'*64,timer_source='MatchService.server_tick',
            clock_domain='host.perf_counter_ns',uncertainty_ms=1000)
        # Schema exercise only: the evidence text is explicitly synthetic,
        # not a physical timer bound or permission to use it on the game.
        evidence=directory/'SYNTHETIC_CLOCK.txt'
        evidence.write_text('SYNTHETIC OFFLINE SCHEMA EXERCISE ONLY\n')
        ref=dict(path=evidence.name,sha256=hashlib.sha256(evidence.read_bytes()).hexdigest(),first_line=1,last_line=1)
        proof['derivation']=dict(method='BOUNDED_COMPONENT_SUM_V1',components=[
            dict(name=name,upper_ms=200,evidence=[ref]) for name in
            ('anchor_age','transport_age','host_unity_alignment','read_span','quantization')])
        (directory/'bound.json').write_text(canonical_json(proof),encoding='utf-8')
        data=dict(schema=SCHEMA,origin='NATIVE_OBSERVATION',created_at=100,expires_at=200,
            runtime_sha256='3'*64,game_build_sha256='1'*64,policy_json=a.policy_json,
            scope=a.scope.plain(),witness=a.witness.plain(),model=a.model.plain(),
            samples=[dict(origin='NATIVE_OBSERVATION',timer_source='MatchService.server_tick',
                input_mode='foreground',board_mode='two_click',record_path='timing.jsonl',
                record_sha256=hashlib.sha256(record.read_bytes()).hexdigest(),line=1)],
            timer_bound=dict(report_path='bound.json',report_sha256=hashlib.sha256((directory/'bound.json').read_bytes()).hexdigest()),
            return_margin_ms=100,max_read_span_ms=200,budget_ms=4000)
        return data,a.policy_json

    def load(self,path,data,policy,**kwargs):
        path.write_text(canonical_json(data),encoding='utf-8')
        req=PilotArtifactRequest(str(path),hashlib.sha256(path.read_bytes()).hexdigest(),'1'*64,'3'*64,
                                data['timer_bound']['report_sha256'])
        return load_pilot_authority(req,policy_json=policy,now=kwargs.get('now',150))

    def test_schema_and_measured_vectors_validated_with_explicit_synthetic_fixture(self):
        # Values label native to exercise the native branch, but this whole
        # fixture has NO native IO and is not a real accepted calibration.
        with tempfile.TemporaryDirectory() as d:
            p=Path(d)/'pilot.json';data,policy=self.make_data(Path(d))
            a=self.load(p,data,policy)
            self.assertEqual(a.calibration_samples,1)
            self.assertGreaterEqual(a.reserve_ms,a.input_p99_ms+250)

    def test_missing_provenance_expiry_scope_and_zero_filled_model_rejected(self):
        for kind in ('expiry','source','origin','sample_sha','clock_sha','model'):
            with self.subTest(kind=kind),tempfile.TemporaryDirectory() as d:
                p=Path(d)/'pilot.json';data,policy=self.make_data(Path(d))
                if kind=='expiry':data['expires_at']=140
                elif kind=='source':data['runtime_sha256']='4'*64
                elif kind=='origin':data['origin']='SYNTHETIC_SPEC'
                elif kind=='sample_sha':data['samples'][0]['record_sha256']='4'*64
                elif kind=='clock_sha':data['timer_bound']['report_sha256']='4'*64
                else:data['model']['protection']={'health':20}
                with self.assertRaises(ValueError):self.load(p,data,policy)

    def test_native_origin_label_alone_is_insufficient(self):
        with tempfile.TemporaryDirectory() as d:
            p=Path(d)/'pilot.json';data,policy=self.make_data(Path(d));data['samples']=[]
            with self.assertRaises(ValueError):self.load(p,data,policy)


class BudgetControllerTests(unittest.TestCase):
    def trace(self, path, *, profile='simple', case='normal', budget_ms=4000, compute=None, minimal=False):
        box={}
        def factory(state,config):
            authority=replace(pilot_authority(state,config,minimal_model=minimal),budget_ms=budget_ms)
            bridge=PilotSelectionBridge(authority=authority,diagnostics=MemorySink(),
                verified_build_sha256=authority.game_build_sha256,enabled=True,
                warm_worker=True,decision_budget=True)
            if compute is not None:bridge.runner.compute=compute
            box['bridge']=bridge
            self.addCleanup(bridge.close)
            return bridge  # No state/job admission or wait before controller.run.
        trace=controller_trace(path,initial_combat=scoped_state(),profile=profile,case=case,
            selection_factory=factory,real_processing_clock=True)
        return trace,box['bridge']

    def test_actual_controller_completes_cold_worker_within_budget_and_acks(self):
        for profile in ('simple','careful'):
            with self.subTest(profile=profile),tempfile.TemporaryDirectory() as d:
                trace,b=self.trace(Path(d)/'new.jsonl',profile=profile)
                old=controller_trace(Path(d)/'old.jsonl',initial_combat=scoped_state(),profile=profile,
                    controller_module=original_controller())
                self.assertEqual(trace[1],old[1])
                self.assertEqual(trace[1].count('FAKE_NORMAL_INPUT'),1)
                self.assertEqual(trace[1].count('executor.ack'),1)
                self.assertEqual(b.counts['VALID_COMPLETED_R1'],3,b.counts)
                self.assertTrue(any(r['event']=='policy_decision' and r.get('policyStep')=='REASONING_R1_SWAP' for r in trace[2]))
                self.assertEqual(b.budget_receipts[-1]['reason'],'COMPLETED')
                self.assertLess(b.budget_receipts[-1]['ended_ns'],b.budget_receipts[-1]['deadline_ns'])
                self.assertTrue(b.close())

    def test_deadline_fault_and_unknown_model_retain_basic(self):
        for case,compute,budget,minimal in (('deadline',hang,50,False),('fault',raises,4000,False),
                                             ('unknown',None,4000,True)):
            with self.subTest(case=case),tempfile.TemporaryDirectory() as d:
                trace,b=self.trace(Path(d)/'new.jsonl',compute=compute,budget_ms=budget,minimal=minimal)
                old=controller_trace(Path(d)/'old.jsonl',initial_combat=scoped_state(),controller_module=original_controller())
                self.assertEqual(trace[1],old[1]);self.assertEqual(b.counts['VALID_COMPLETED_R1'],0)
                self.assertTrue(b.close())

    def test_stop_inside_decision_has_zero_input(self):
        with tempfile.TemporaryDirectory() as d:
            trace,b=self.trace(Path(d)/'new.jsonl',case='stop_in_reasoning',compute=hang)
            self.assertNotIn('FAKE_NORMAL_INPUT',trace[1])
            self.assertEqual(b.budget_receipts[-1]['reason'],'STOPPED')
            self.assertLess(b.budget_receipts[-1]['ended_ns']-b.budget_receipts[-1]['started_ns'],25_000_000)
            self.assertTrue(b.close())

    def test_reasoned_executor_skips_only_optional_random_and_preserves_pacing(self):
        from pokiguard_v2.win32_input import ForegroundClickExecutor, WindowBinding, map_swap_to_pixels, BoardCalibration
        from tests.test_win32_input import FakeBackend
        backend=FakeBackend();sleeps=[]
        executor=ForegroundClickExecutor(backend,sleeper=sleeps.append)
        binding=WindowBinding(5,123,'OFFLINE',1280,720)
        plan=map_swap_to_pixels((4,2),(4,3),BoardCalibration(),backend.geometry)
        with patch('pokiguard_v2.win32_input.random.uniform',side_effect=AssertionError('optional random used')):
            result=executor.send_swap(binding,plan,remaining_seconds=5,reasoned=True)
        self.assertEqual(backend.clicks,2);self.assertEqual(result.inter_click_delay_seconds,.35)
        self.assertEqual(sleeps,[executor.cursor_settle_seconds,.35,executor.cursor_settle_seconds])


class SessionWiringTests(unittest.TestCase):
    def test_explicit_desktop_factory_passed_and_signal_stopped(self):
        from pokiguard_v2.desktop_control_plane import DesktopConfig
        from pokiguard_v2.desktop_farm_controller import DesktopFarmControllerManager, ControllerLaunch
        from pokiguard_v2.win32_input import FarmControlHotkeyEdges
        from unittest.mock import Mock
        config=DesktopConfig(boss_id='1289');session=Mock();factory=Mock(return_value=session)
        with tempfile.TemporaryDirectory() as d:
            manager=DesktopFarmControllerManager(Path(d),reasoning_session_factory=factory)
            with patch('tools.farm_run.run',return_value=0) as run:
                self.assertEqual(manager._run_production(ControllerLaunch(config,None),FarmControlHotkeyEdges(),lambda *_:None),0)
        factory.assert_called_once_with(config)
        self.assertIs(run.call_args.kwargs['reasoning_session'],session)
        session.stop.assert_called_once_with()

    def test_bad_desktop_factory_keeps_ordinary_basic(self):
        from pokiguard_v2.desktop_control_plane import DesktopConfig
        from pokiguard_v2.desktop_farm_controller import DesktopFarmControllerManager, ControllerLaunch
        from pokiguard_v2.win32_input import FarmControlHotkeyEdges
        config=DesktopConfig(boss_id='1289')
        with tempfile.TemporaryDirectory() as d:
            manager=DesktopFarmControllerManager(Path(d),reasoning_session_factory=lambda _:(_ for _ in ()).throw(ValueError('bad artifact')))
            with patch('tools.farm_run.run',return_value=0) as run:
                self.assertEqual(manager._run_production(ControllerLaunch(config,None),FarmControlHotkeyEdges(),lambda *_:None),0)
        self.assertNotIn('reasoning_session',run.call_args.kwargs)


if __name__=='__main__':unittest.main()
