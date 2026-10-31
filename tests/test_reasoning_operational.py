"""Operational P10 software tests. All game/input/calibration data are fakes."""
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import tempfile
import time
from types import SimpleNamespace
import unittest
from unittest.mock import patch

from pokiguard_v2.autonomous_control import AutonomousSource
from pokiguard_v2.basic_policy import BasicPolicyEngine, PolicyConfig
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.reasoning_diagnostics import encode_event
from pokiguard_v2.reasoning_operational import (OperationalPilotAuthority, OperationalArtifactRequest,
    ORIGIN, SCHEMA, CONTEXT, authority_deadline, command_wait_ms, load_operational_authority,
    operational_deadline_ns, native_model_required)
from pokiguard_v2.reasoning_pilot import PilotSelectionBridge, snapshot_from_state
from pokiguard_v2.reasoning_pilot_contract import runtime_witness
from pokiguard_v2.reasoning_snapshot import FrozenJSON, canonical_json, digest
from pokiguard_v2.reasoning_swap_timing import SwapTimingCollector, timing_safely, operational_preflight_failure
from pokiguard_v2.win32_input import ClickStatus
from tests.test_reasoning_pilot import MemorySink, scoped_state, pilot_authority
from tests.reasoning_controller_fixture import controller_trace

PARAMS = dict(cursor_settle_seconds=.06, mouse_button_hold_seconds=.075)


def operational_authority(state, config, **changes):
    a = OperationalPilotAuthority(config.play_style.value, canonical_json(jsonable(config)),
        FrozenJSON.of(dict(account_binding="SYNTHETIC",boss="SYNTHETIC",loadout="SYNTHETIC")),
        runtime_witness(state, config), FrozenJSON.of({"version":"5b2.scoped_inputs.v1"}), '1'*64, '3'*64, '4'*64, '5'*64,
        '6'*64, '7'*64, FrozenJSON.of(dict(controller_tail_ms=10, final_input_ms=100,
            selector_extra_ms=5, command_wait_ms=3120, host_guard_ms=250)), FrozenJSON.of(PARAMS),
        200, 1, time.perf_counter_ns()+60_000_000_000)
    return replace(a, **changes)


def native_state():
    s = scoped_state()
    return replace(s, battle=replace(s.battle, turn_timer_source='MatchService.server_tick'))


class OperationalDeadlineTests(unittest.TestCase):
    def test_original_observation_charges_read_basic_queue_and_compute(self):
        t0 = 100_000_000_000
        kw = dict(observed_ns=t0, remaining_ms=14000, reserve_ms=5000)
        self.assertEqual(operational_deadline_ns(now_ns=t0+1_000_000_000, **kw),t0+4_000_000_000)
        self.assertIsNone(operational_deadline_ns(now_ns=t0+3_960_000_000, **kw))
        self.assertEqual(operational_deadline_ns(now_ns=t0, remaining_ms=7000,
            observed_ns=t0, reserve_ms=5000),t0+1_900_000_000)

    def test_invalid_values_and_exhaustion_fail_without_reset(self):
        base=dict(observed_ns=100,now_ns=100,remaining_ms=14000,reserve_ms=5000)
        for changes in (dict(reserve_ms=None), dict(remaining_ms=float('nan')),
                        dict(configured_ms=6001),dict(observed_ns=101),dict(return_margin_ms=99),
                        dict(remaining_ms=5100),dict(now_ns=-1),dict(reserve_ms=True)):
            self.assertIsNone(operational_deadline_ns(**(base|changes)),changes)

    def test_strict_deadline_keeps_its_meaning_and_operational_has_no_U(self):
        s=native_state();c=PolicyConfig();a=operational_authority(s,c)
        self.assertIsNone(a.native_U_ms);self.assertFalse(hasattr(a,'uncertainty_ms'))
        t0=100_000_000_000
        self.assertEqual(authority_deadline(a,observed_ns=t0,remaining_ms=14000,
            slice_started_ns=t0+1_000_000_000,now_ns=t0+1_000_000_000),t0+4_000_000_000)
        old=pilot_authority(scoped_state(),PolicyConfig(minimum_turn_time_seconds=1,minimum_evolve_time_seconds=1))
        self.assertEqual(authority_deadline(old,observed_ns=t0,remaining_ms=14000,
            slice_started_ns=t0+1_000_000_000,now_ns=t0+1_000_000_000),t0+5_000_000_000)

    def test_reserve_covers_fallback_random_and_minimum_floor(self):
        c=PolicyConfig();a=operational_authority(native_state(),c)
        self.assertEqual(command_wait_ms(**PARAMS),3120)
        self.assertEqual(a.reserve_ms,max(3485,c.minimum_turn_time_seconds*1000))
        self.assertTrue(native_model_required(a))
        for changes in (dict(model=FrozenJSON.of(dict(version='5b2.scoped_inputs.v1',health=20))),
                        dict(timer_source='OFFLINE_VALID'),dict(calibration_samples=0),
                        dict(valid_until_ns=0),dict(budget_ms=6001)):
            with self.assertRaises(ValueError):replace(a,**changes)
        components=a.reserve_components.plain();components['command_wait_ms']=1
        with self.assertRaises(ValueError):replace(a,reserve_components=FrozenJSON.of(components))

    def test_expired_or_changed_cohort_never_matches(self):
        s=native_state();c=PolicyConfig();a=operational_authority(s,c)
        self.assertTrue(a.matches(s,c))
        self.assertFalse(replace(a,valid_until_ns=1).matches(s,c))
        with self.assertRaises(ValueError):a.matches(replace(s,player=replace(s.player,is_local=False)),c)


class OperationalCollectorTests(unittest.TestCase):
    def setUp(self):
        self.s=native_state();self.c=PolicyConfig();self.sink=MemorySink();self.faults=[]
        self.a=operational_authority(self.s,self.c)

    def collector(self, **kw):
        return SwapTimingCollector(sink=self.sink,operational_authority=self.a,on_fault=self.faults.append,**kw)

    def decision(self,b):
        b.observe_start();b.observe_end(state=self.s)
        b.decision(state=self.s,config=self.c,input_parameters=PARAMS)

    def test_full_controller_and_input_tail_with_unknown_U(self):
        b=self.collector();self.decision(b)
        b.checkpoint(name='fresh');b.checkpoint(name='final')
        b.start(state=self.s,config=self.c,input_mode='foreground',
                source_hash=AutonomousSource.from_state(self.s).critical_state_hash)
        b.preflight(remaining=12,failure=None,read_end_ns=time.perf_counter_ns())
        b.finish(result=SimpleNamespace(sent_clicks=2,input_mode='two_click',status=ClickStatus.SENT))
        row=json.loads(self.sink.buffer.items[0]);p=row['payload']
        self.assertEqual(row['correlation']['mode'],'OPERATIONAL_PILOT')
        self.assertGreaterEqual(p['full_tail_ns'],p['elapsed_upper_bound_ns'])
        self.assertLessEqual(p['observation_read_end_ns'],p['decision_exit_ns'])
        self.assertIsNone(p['native_U_ms']);self.assertIsNone(p['first_input_ns'])
        self.assertFalse(b.disabled);self.assertEqual(self.faults,[])

    def test_unbound_tail_and_parameter_change_disable_only_pilot(self):
        b=self.collector();b.decision(state=self.s,config=self.c,input_parameters={})
        self.assertTrue(b.disabled);self.assertEqual(self.faults,['INPUT_PARAMETERS_CHANGED'])

    def test_overrun_retains_event_and_invalidates_pilot(self):
        b=self.collector();self.decision(b)
        b.start(state=self.s,config=self.c,input_mode='foreground',
                source_hash=AutonomousSource.from_state(self.s).critical_state_hash)
        b.pending['decision_exit_ns']-=10_000_000_000
        b.finish(result=None,status='EXECUTOR_EXCEPTION')
        self.assertTrue(json.loads(self.sink.buffer.items[0])['payload']['reserve_overrun'])
        self.assertTrue(b.disabled);self.assertEqual(self.faults,['RESERVE_OVERRUN_OR_UNBOUND'])

    def test_stop_and_superseded_decisions_remain_in_ledger(self):
        b=self.collector();self.decision(b);self.decision(b);b.stop();b.stop()
        rows=[json.loads(x) for x in self.sink.buffer.items]
        self.assertEqual([r['event_seq'] for r in rows],[1,2])
        self.assertEqual([r['payload']['status'] for r in rows],
            ['SUPERSEDED_BEFORE_PREFLIGHT','STOP_OR_CONTROLLER_EXIT'])

    def test_sink_fault_does_not_escape_to_game_owner(self):
        b=self.collector();self.decision(b)
        with patch.object(self.sink,'enqueue',side_effect=OSError('SYNTHETIC')):
            timing_safely(b,'stop')
        self.assertTrue(b.disabled);self.assertEqual(b.dropped,1)

    def test_existing_preflight_vetoes_excess_read_span_before_input(self):
        b=self.collector();self.decision(b)
        b.start(state=self.s,config=self.c,input_mode='foreground',
                source_hash=AutonomousSource.from_state(self.s).critical_state_hash)
        self.assertEqual(operational_preflight_failure(b,
            read_end_ns=b.pending['preflight_start_ns']+201_000_000,input_parameters=PARAMS),
            'OPERATIONAL_READ_SPAN_EXCEEDED')
        self.assertTrue(b.disabled)

    def test_basic_calibration_does_not_acquire_operational_veto(self):
        b=SwapTimingCollector(sink=self.sink)
        self.assertIsNone(operational_preflight_failure(b,read_end_ns=-1,input_parameters={}))


class OperationalLoaderTests(unittest.TestCase):
    def package(self,d):
        s=native_state();c=PolicyConfig();a=operational_authority(s,c)
        def doc(name,data):
            p=d/name;p.write_text(canonical_json(data),encoding='utf-8');return dict(path=name,sha256=hashlib.sha256(p.read_bytes()).hexdigest())
        contract=doc('SYNTHETIC_CONTRACT.json',{'kind':'SYNTHETIC OFFLINE ONLY'})
        decision=doc('SYNTHETIC_DECISION.json',dict(accepted=True,scope='OFFLINE_IMPLEMENTATION_AND_READINESS_ONLY',contract_sha256=contract['sha256']))
        data=dict(schema=SCHEMA,origin=ORIGIN,created_at=100,expires_at=200,runtime_sha256='3'*64,
            host_sha256='4'*64,contract_sha256=contract['sha256'],decision_sha256=decision['sha256'],
            full_config_sha256='8'*64,game_build_sha256='1'*64,policy_json=a.policy_json,
            native_U_ms=None,transport_age_ms=None,host_unity_alignment_ms=None,contract=contract,decision=decision,
            activation='EXPLICIT_BOUNDED_PILOT_REQUEST',total_attempt_cap=3,run_id='a'*32,
            scope=a.scope.plain(),witness=a.witness.plain(),model=a.model.plain(),input_parameters=PARAMS,
            max_read_span_ms=200,host_guard_ms=250,return_margin_ms=100,budget_ms=4000)
        review={k:data[k] for k in ('run_id','total_attempt_cap','full_config_sha256','runtime_sha256',
            'host_sha256','contract_sha256','decision_sha256')}
        activation=doc('SYNTHETIC_ACTIVATION.json',review|dict(accepted=True,scope='BOUNDED_OPERATIONAL_PILOT'))
        data.update(activation_review=activation,activation_sha256=activation['sha256'])
        sink=MemorySink();b=SwapTimingCollector(sink=sink,run_id='SYNTHETIC')
        b.observe_start();b.observe_end(state=s);b.decision(state=s,config=c,input_parameters=PARAMS)
        b.start(state=s,config=c,input_mode='foreground',source_hash=AutonomousSource.from_state(s).critical_state_hash)
        b.preflight(remaining=12,failure=None,read_end_ns=time.perf_counter_ns())
        b.finish(result=SimpleNamespace(sent_clicks=2,input_mode='two_click',status=ClickStatus.SENT))
        records=d/'SYNTHETIC_TIMING.jsonl';records.write_bytes(sink.buffer.items[0])
        source=json.loads(sink.buffer.items[0])['payload']['autonomous_source']
        combat=d/'SYNTHETIC_COMBAT.jsonl';combat.write_text('\n'.join(canonical_json(x) for x in [
            dict(event='action_sent',action='SWAP',identity=dict(source=source)),
            dict(event='action_result',result='SWAP_ACKNOWLEDGED',action=dict(identity=dict(source=source)))]))
        def ref(p):return dict(path=p.name,sha256=hashlib.sha256(p.read_bytes()).hexdigest())
        stats=dict(accounting_valid=True,eligible=1,written=1,dropped_before_enqueue=0,failed_write=0,
            discarded_after_enqueue=0,queued=0,in_writer=0)
        calibration=dict(mode='BASIC_CALIBRATION_ONLY',origin='NATIVE_OBSERVATION',runtime_sha256='3'*64,
            host_sha256='4'*64,policy_json=a.policy_json,witness=a.witness.plain(),total_attempt_cap=3,
            attempt_ledger=doc('SYNTHETIC_LEDGER.json',[dict(index=0,status='COMPLETED')]),
            watermarks=doc('SYNTHETIC_WATERMARK.json',dict(flushed=True,closed=True,collector_dropped=0,
                collector_disabled=False,sequence=1,before_close=stats)),records=ref(records),combat_records=[ref(combat)])
        calibration['farm_export']=doc('SYNTHETIC_FARM_EXPORT.json',dict(schema='pokiguard.basic_calibration_export.v1',
            finalized=True,errors=[],source_sha256='3'*64,game_build_sha256='1'*64,host_sha256='4'*64,
            total_attempt_cap=3,all_attempt_count=1,all_attempts=[dict(attempt_index=1)]))
        data['calibration']=doc('SYNTHETIC_CALIBRATION.json',calibration)
        data['selector_allowance']=doc('SYNTHETIC_ALLOWANCE.json',dict(scope='OFFLINE_OPERATIONAL_SELECTOR',
            runtime_sha256='3'*64,host_sha256='4'*64,paths=dict(completed=1,timeout=2,error=3,fallback=4)))
        return data,doc

    def load(self,d,data,**kw):
        p=d/'SYNTHETIC_REQUEST.json';p.write_text(canonical_json(data),encoding='utf-8')
        request=OperationalArtifactRequest(str(p),hashlib.sha256(p.read_bytes()).hexdigest(),
            data['game_build_sha256'],data['runtime_sha256'],data['host_sha256'],data['contract_sha256'],
            data['decision_sha256'],data['full_config_sha256'],data['activation_sha256'])
        return load_operational_authority(request,policy_json=data['policy_json'],now=kw.get('now',150))

    def test_complete_synthetic_schema_keeps_unknown_U_and_measured_components(self):
        with tempfile.TemporaryDirectory() as name:
            d=Path(name);data,_=self.package(d);a=self.load(d,data)
            self.assertEqual(a.context,CONTEXT);self.assertIsNone(a.native_U_ms)
            self.assertGreaterEqual(a.reserve_ms,3310);self.assertEqual(a.calibration_samples,1)

    def test_missing_provenance_bound_forgery_caps_and_effects_rejected(self):
        for change in ('u','model','expiry','cap','clock','readspan','guard','path','acceptance'):
            with self.subTest(change=change),tempfile.TemporaryDirectory() as name:
                d=Path(name);data,doc=self.package(d)
                if change=='u':data['native_U_ms']=0
                elif change=='model':data['model']['health']=20
                elif change=='expiry':data['expires_at']=150
                elif change=='cap':data['total_attempt_cap']=13
                elif change=='clock':data['origin']='NATIVE_INPUT_CALIBRATED'
                elif change=='readspan':data['max_read_span_ms']=.00000001
                elif change=='guard':data['host_guard_ms']=249
                elif change=='path':data['calibration']['path']='../escape.json'
                else:
                    data['activation_review']=doc('NO_ACTIVATION.json',dict(accepted=False))
                    data['activation_sha256']=data['activation_review']['sha256']
                with self.assertRaises((ValueError,KeyError)):self.load(d,data)

    def test_tampered_native_records_and_watermark_are_rejected(self):
        for fault in ('missing_H','ack','input_params','drop','record_hash','sequence','farm_ledger'):
            with self.subTest(fault=fault),tempfile.TemporaryDirectory() as name:
                d=Path(name);data,doc=self.package(d)
                cal=json.loads((d/data['calibration']['path']).read_text())
                if fault in ('missing_H','input_params','sequence'):
                    row=json.loads((d/cal['records']['path']).read_text())
                    if fault=='missing_H':row['payload'].pop('decision_exit_ns')
                    elif fault=='sequence':row['event_seq']=2
                    else:row['payload']['input_parameters']={}
                    cal['records']=doc('BAD_RECORD.jsonl',row)
                elif fault=='ack':cal['combat_records']=[doc('NO_ACK.jsonl',dict(event='action_sent'))]
                elif fault=='drop':cal['watermarks']=doc('BAD_WATERMARK.json',dict(flushed=True,closed=True,
                    collector_dropped=1,collector_disabled=False))
                elif fault=='farm_ledger':cal['farm_export']=doc('BAD_FARM_EXPORT.json',dict(finalized=False))
                else:cal['records']['sha256']='0'*64
                data['calibration']=doc('BAD_CALIBRATION.json',cal)
                with self.assertRaises((ValueError,KeyError)):self.load(d,data)


class OperationalControllerTests(unittest.TestCase):
    def test_actual_controller_same_reads_and_ack_with_native_fake_projection(self):
        box={}
        def factory(s,c):
            a=operational_authority(s,c)
            b=PilotSelectionBridge(authority=a,diagnostics=MemorySink(),verified_build_sha256=a.game_build_sha256,
                enabled=True,decision_budget=True,warm_worker=True)
            box['bridge']=b;return b
        with tempfile.TemporaryDirectory() as name:
            d=Path(name)
            before=controller_trace(d/'basic.jsonl',initial_combat=native_state(),real_processing_clock=True,timer_source='MatchService.server_tick')
            current=controller_trace(d/'pilot.jsonl',initial_combat=native_state(),real_processing_clock=True,timer_source='MatchService.server_tick',
                target_pid=7,selection_factory=factory)
        b=box['bridge'];self.addCleanup(b.close)
        self.assertEqual(before[1],current[1]);self.assertEqual(current[1].count('executor.ack'),1)
        self.assertGreaterEqual(b.bridge_counts['decision_wait_started'],1)
        self.assertTrue(b.close());self.assertEqual(b.runner.counters['processes'],b.runner.counters['reaped'])
        self.assertLessEqual(b.budget_receipts[0]['deadline_ns'],b.preparation[0]['observed_ns']+4_000_000_000)
        self.assertEqual(b.last_snapshot.recorded.plain()['timing_mode'],'OPERATIONAL_PROJECTION')

    def test_controller_timing_uses_separate_producer_and_preserves_input_order(self):
        box={}
        def factory(s,c):
            a=operational_authority(s,c);b=PilotSelectionBridge(authority=a,diagnostics=MemorySink(),
                verified_build_sha256=a.game_build_sha256,enabled=True,decision_budget=True,warm_worker=True)
            box['b']=b;self.addCleanup(b.close);return b
        def timing(s,c):
            b=box['b'];a=b.pilot_authority
            t=SwapTimingCollector(sink=b.timing_diagnostics,operational_authority=a,
                on_fault=lambda reason:setattr(b,'disabled',True))
            box['t']=t;return t
        with tempfile.TemporaryDirectory() as name:
            d=Path(name);before=controller_trace(d/'basic.jsonl',initial_combat=native_state(),
                real_processing_clock=True,timer_source='MatchService.server_tick')
            current=controller_trace(d/'pilot.jsonl',initial_combat=native_state(),real_processing_clock=True,
                timer_source='MatchService.server_tick',target_pid=7,selection_factory=factory,timing_factory=timing)
        b=box['b'];self.assertTrue(b.close());self.assertEqual(before[1],current[1])
        rows=[json.loads(x) for x in b.sink.buffer.items]
        timing_rows=[r for r in rows if r['event_type']=='reasoning.swap_timing']
        self.assertEqual(len(timing_rows),1);self.assertFalse(b.sink.buffer.disabled)
        self.assertFalse(box['t'].disabled);self.assertIsNone(timing_rows[0]['payload']['native_U_ms'])

    def test_stop_stale_and_worker_failure_never_add_game_reads_or_second_input(self):
        from tests.reasoning_worker_fixtures import raises, hang
        from pokiguard_v2.reasoning_warm_runner import WarmIsolatedRunner
        for case,compute,budget in [('stale',None,4000),('wrong_turn',None,4000),
                ('stop_in_reasoning',hang,4000),('normal',raises,4000),('normal',hang,50)]:
            with self.subTest(case=case,compute=compute),tempfile.TemporaryDirectory() as name:
                box={}
                def factory(s,c):
                    a=operational_authority(s,c,budget_ms=budget)
                    with patch('pokiguard_v2.reasoning_warm_runner.WarmIsolatedRunner',
                        side_effect=lambda **kw:WarmIsolatedRunner(compute=compute,**kw)):
                        b=PilotSelectionBridge(authority=a,diagnostics=MemorySink(),
                            verified_build_sha256=a.game_build_sha256,enabled=True,decision_budget=True,warm_worker=True)
                    box['b']=b;self.addCleanup(b.close);return b
                current=controller_trace(Path(name)/'pilot.jsonl',initial_combat=native_state(),
                    real_processing_clock=True,timer_source='MatchService.server_tick',target_pid=7,
                    selection_factory=factory,case=case)
                self.assertTrue(box['b'].close())
                self.assertLessEqual(current[1].count('FAKE_NORMAL_INPUT'),1)
                if case in ('stale','wrong_turn','stop_in_reasoning'):
                    self.assertNotIn('FAKE_NORMAL_INPUT',current[1])

    def test_timing_parameter_fault_keeps_valid_basic_input(self):
        box={}
        def factory(s,c):
            params=dict(PARAMS,cursor_settle_seconds=.1)
            a=operational_authority(s,c)
            components=a.reserve_components.plain();components['command_wait_ms']=command_wait_ms(**params)
            a=replace(a,input_parameters=FrozenJSON.of(params),reserve_components=FrozenJSON.of(components))
            b=PilotSelectionBridge(authority=a,diagnostics=MemorySink(),verified_build_sha256=a.game_build_sha256,
                enabled=True,decision_budget=True,warm_worker=True)
            box['b']=b;self.addCleanup(b.close);return b
        def timing(s,c):
            b=box['b'];return SwapTimingCollector(sink=b.timing_diagnostics,operational_authority=b.pilot_authority,
                on_fault=lambda reason:setattr(b,'disabled',True))
        with tempfile.TemporaryDirectory() as name:
            result=controller_trace(Path(name)/'fault.jsonl',initial_combat=native_state(),real_processing_clock=True,
                timer_source='MatchService.server_tick',target_pid=7,selection_factory=factory,timing_factory=timing)
        self.assertEqual(result[1].count('FAKE_NORMAL_INPUT'),1)
        self.assertEqual(result[1].count('executor.ack'),1);self.assertTrue(box['b'].disabled)


class OperationalSessionTests(unittest.TestCase):
    def session(self,d,config=None):
        from pokiguard_v2.desktop_control_plane import DesktopConfig
        from pokiguard_v2.pet_configuration import basic_policy_config
        from pokiguard_v2.reasoning_operational import OperationalPilotSession
        config=config or DesktopConfig(boss_id='1',max_match_attempts=3)
        c=basic_policy_config(config);a=operational_authority(native_state(),c)
        path=d/'SYNTHETIC_SESSION.json';path.write_text(canonical_json(dict(run_id='a'*32,total_attempt_cap=3,
            expires_at=time.time()+120)))
        req=OperationalArtifactRequest(str(path),hashlib.sha256(path.read_bytes()).hexdigest(),
            '1'*64,'3'*64,'4'*64,'5'*64,'6'*64,digest(jsonable(config)),'9'*64)
        with patch('pokiguard_v2.reasoning_calibration.source_fingerprint',return_value='3'*64), \
             patch('pokiguard_v2.reasoning_operational.host_fingerprint',return_value='4'*64), \
             patch('pokiguard_v2.game_location.validate_supported_game_assembly',return_value='1'*64), \
             patch('pokiguard_v2.reasoning_operational.load_operational_authority',return_value=a):
            return OperationalPilotSession(req,root=d,config=config,policy_json=a.policy_json,
                directory=d/'ai',game_executable=d/'SYNTHETIC.exe')

    def test_claim_no_resources_before_bind_and_no_restart_cap_reset(self):
        with tempfile.TemporaryDirectory() as name:
            d=Path(name);s=self.session(d);self.addCleanup(s.stop)
            self.assertIsNone(s.adapter);self.assertEqual(s.prepare_options(),{})
            with self.assertRaises(FileExistsError):self.session(d)

    def test_failed_binding_stays_basic_and_claim_stays_consumed(self):
        with tempfile.TemporaryDirectory() as name:
            d=Path(name);s=self.session(d)
            with patch('pokiguard_v2.reasoning_pilot.create_pilot_bridge',return_value=None),self.assertRaises(ValueError):
                s.bind_run('SYNTHETIC_FARM',d/'farm')
            self.assertEqual(s.prepare_options(),{});self.assertTrue(s.stopped)
            with self.assertRaises(FileExistsError):self.session(d)

    def test_real_offline_writer_has_one_producer_and_durable_stop_receipt(self):
        with tempfile.TemporaryDirectory() as name:
            d=Path(name);s=self.session(d);self.addCleanup(s.stop)
            s.bind_run('SYNTHETIC_FARM',d/'farm')
            options=s.prepare_options();b=options['selection_adapter'];t=options['swap_timing_adapter']
            state=native_state()
            from pokiguard_v2.pet_configuration import basic_policy_config
            from pokiguard_v2.desktop_control_plane import DesktopConfig
            config=basic_policy_config(DesktopConfig(boss_id='1',max_match_attempts=3))
            t.observe_start();t.observe_end(state=state);t.decision(state=state,config=config,input_parameters=PARAMS)
            t.start(state=state,config=config,input_mode='foreground',source_hash=AutonomousSource.from_state(state).critical_state_hash)
            t.preflight(remaining=12,failure=None,read_end_ns=time.perf_counter_ns())
            t.finish(result=SimpleNamespace(sent_clicks=2,input_mode='two_click',status=ClickStatus.SENT))
            s.stop();s.finalizer.join(5)
            self.assertFalse(s.finalizer.is_alive());self.assertEqual(s.prepare_options(),{})
            watermark=json.loads((d/'ai/watermarks.json').read_text())
            self.assertTrue(watermark['combats'][0]['closed'])
            stats=watermark['combats'][0]['after_close']
            self.assertEqual(stats['wrong_producer'],0);self.assertEqual(stats['eligible'],stats['written'])
            rows=[json.loads(line) for p in (d/'ai').rglob('*.jsonl') for line in p.read_text().splitlines()]
            self.assertEqual(len([r for r in rows if r['event_type']=='reasoning.swap_timing']),1)

    def test_flush_failure_still_closes_owned_writer_off_stop(self):
        with tempfile.TemporaryDirectory() as name:
            d=Path(name);s=self.session(d);s.bind_run('SYNTHETIC_FARM',d/'farm')
            with patch.object(s.adapter.sink,'flush',side_effect=OSError('SYNTHETIC_FLUSH_FAULT')):
                start=time.perf_counter();s.stop();self.assertLess(time.perf_counter()-start,.025)
                s.finalizer.join(5)
            self.assertFalse(s.finalizer.is_alive());self.assertTrue(s.adapter.sink.reaped)
            item=json.loads((d/'ai/watermarks.json').read_text())['combats'][0]
            self.assertEqual(item['error'],'OSError');self.assertTrue(item['closed'])
            self.assertFalse(item['flushed']);self.assertTrue(s.faulted)


if __name__=='__main__':unittest.main()
