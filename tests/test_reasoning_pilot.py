"""D1-P1 software integration only; all native input surfaces are explicit fakes."""
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import subprocess
import sys
import tempfile
import threading
import time
import unittest
from unittest.mock import patch
from tests.game_update_fixture import historical_test_view

from pokiguard_v2.basic_policy import BasicPolicyEngine, PolicyConfig, PlayStyle
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.reasoning_diagnostics import DiagnosticBuffer, LogLimits
from pokiguard_v2.reasoning_pilot import (PilotSelectionBridge, create_pilot_bridge,
                                        snapshot_from_state, observe_pilot_safely)
from pokiguard_v2.reasoning_pilot_contract import PilotAuthority, runtime_witness
from pokiguard_v2.reasoning_planner import MODEL_VERSION
from pokiguard_v2.reasoning_selection import select_safely, revalidate_safely, _bounded_pilot_comparison
from pokiguard_v2.reasoning_snapshot import FrozenJSON, canonical_json
from tests.reasoning_controller_fixture import controller_trace
from tests.test_reasoning_selection import tactical_combat, completed_fixture, original_controller
from tests.test_actionability import actionable_state
from tools.qualify_reasoning_selection import controller_ast_audit


class MemorySink:
    def __init__(self):
        self.buffer = DiagnosticBuffer(LogLimits(records=432, bytes=6*1024*1024))

    def enqueue(self, raw, **kwargs):
        return self.buffer.enqueue(raw, **kwargs)


def scoped_state():
    state = tactical_combat()
    return replace(state, battle=replace(actionable_state().battle,
        turn_number=14, srv_seq=14, current_turn_player='happi',
        turn_time_remaining_seconds=12, turn_duration_seconds=14,
        turn_timer_source='OFFLINE_VALID', local_move_sequence=0, last_move_sequence=0),
        opponents=tuple(replace(b, attack=7, max_mana=250, max_power=250) for b in state.opponents))


def pilot_authority(state, config, *, minimal_model=False):
    # Numerical effects remain confined to this explicitly synthetic authority.
    model = FrozenJSON.of({'version': MODEL_VERSION}) if minimal_model else (
        completed_fixture(state, config)[3]['job'].snapshot.evidence('planner.model').value)
    return PilotAuthority(config.play_style.value, canonical_json(jsonable(config)),
        FrozenJSON.of(dict(account_binding='SYNTHETIC_ACCOUNT', boss='SYNTHETIC_BOSS',
                           loadout='SYNTHETIC_NORMAL')), runtime_witness(state, config), model,
        '1'*64, 'OFFLINE_VALID', 2000, 150, 100, 200,
        'OFFLINE_NATIVE_FAKES', '2'*64, 100, 500)


def await_completed(bridge, timeout=3):
    """Test owner only. The production controller has no wait/poll for results."""
    limit = time.perf_counter() + timeout
    while time.perf_counter() < limit:
        if bridge.completed is not None:
            return bridge.completed
        if bridge.disabled:
            raise AssertionError(dict(counts=dict(bridge.bridge_counts),
                errors=[json.loads(raw)['payload'] for raw in bridge.sink.buffer.items
                        if json.loads(raw)['event_type']=='reasoning.pilot_error']))
        time.sleep(.005)
    raise AssertionError(dict(bridge.bridge_counts))


class PilotTests(unittest.TestCase):
    def setUp(self):
        self.state = scoped_state()
        self.config = PolicyConfig(minimum_turn_time_seconds=1, minimum_evolve_time_seconds=1)

    def bridge(self, *, state=None, config=None, sink=None, minimal_model=False):
        state, config = state or self.state, config or self.config
        a = pilot_authority(state, config, minimal_model=minimal_model)
        b = PilotSelectionBridge(authority=a, diagnostics=sink or MemorySink(),
                                  verified_build_sha256=a.game_build_sha256, enabled=True)
        self.addCleanup(b.close)
        return b

    def complete(self, bridge, state=None, config=None):
        now = time.perf_counter_ns()
        self.assertTrue(bridge.observe(state or self.state, config or self.config,
            observed_ns=now, read_end_ns=now, context=bridge.pilot_authority.context))
        return await_completed(bridge)

    def select(self, bridge, *, state=None, config=None, **kwargs):
        state, config = state or self.state, config or self.config
        return select_safely(bridge, state, BasicPolicyEngine(config).decide(state), config,
            now_ns=time.perf_counter_ns(), input_allowed=True,
            context=bridge.pilot_authority.context, **kwargs)

    def test_actual_producer_isolated_worker_and_completed_selector(self):
        b = self.bridge()
        offer = self.complete(b)
        selected = self.select(b)
        self.assertIs(selected.receipt, offer)
        self.assertNotEqual(selected.decision.move, offer.job.snapshot.baseline.move)
        self.assertEqual(b.runner.counters['processes'], 1)
        self.assertEqual(b.bridge_counts['jobs_submitted'], 1)
        self.assertEqual(b.bridge_counts['completed_published'], 1)
        self.assertLess(offer.job.created_ns, offer.completed_ns)
        self.assertLess(offer.completed_ns, offer.job.deadline_ns)
        self.assertTrue(b.close())
        self.assertEqual(b.runner.counters['reaped'], 1)

    def test_missing_effects_and_boss_threat_remain_unknown(self):
        b = self.bridge(minimal_model=True)
        offer = self.complete(b)
        self.assertIsNone(offer.reply.proposal)
        self.assertEqual(b.last_snapshot.evidence('planner.model').value.plain(), {'version': MODEL_VERSION})
        self.assertEqual(b.last_snapshot.evidence('planner.known_boss_threat').availability, 'MISSING')
        self.assertIsNone(self.select(b).receipt)

    def test_disabled_factory_allocates_nothing(self):
        with patch('pokiguard_v2.reasoning_pilot.IsolatedRunner', side_effect=AssertionError('spawn')):
            self.assertIsNone(create_pilot_bridge())
            self.assertIsNone(create_pilot_bridge(enabled=True))

    def test_missing_build_attestation_rejects_factory(self):
        a = pilot_authority(self.state, self.config)
        with patch('pokiguard_v2.reasoning_pilot.IsolatedRunner', side_effect=AssertionError('spawn')):
            self.assertIsNone(create_pilot_bridge(enabled=True, authority=a,
                                                  verified_build_sha256='3'*64, diagnostics=MemorySink()))

    def test_factory_does_not_overlap_owner_during_cleanup(self):
        a = pilot_authority(self.state, self.config)
        with patch('pokiguard_v2.reasoning_pilot._factory_owner', None):
            first = create_pilot_bridge(enabled=True, authority=a,
                verified_build_sha256=a.game_build_sha256, diagnostics=MemorySink())
            self.assertIsNotNone(first)
            self.addCleanup(first.close)
            self.assertIsNone(create_pilot_bridge(enabled=True, authority=a,
                verified_build_sha256=a.game_build_sha256, diagnostics=MemorySink()))

    def test_uncalibrated_or_weakened_reserve_rejected(self):
        a = pilot_authority(self.state, self.config)
        for fields in (dict(calibration_samples=0), dict(calibration_origin='UNKNOWN'),
                       dict(reserve_ms=500), dict(uncertainty_ms=float('nan')),
                       dict(input_mode='background'), dict(timer_source='UNKNOWN')):
            with self.subTest(fields=fields), self.assertRaises(ValueError):
                replace(a, **fields)

    def test_production_scope_rejects_synthetic_effects(self):
        a = pilot_authority(self.state, self.config)
        with self.assertRaises(ValueError):
            replace(a, calibration_origin='NATIVE_INPUT_CALIBRATED', timer_source='MatchService.server_tick')

    def test_fake_authority_never_authorizes_real_pid(self):
        b = self.bridge()
        self.assertEqual(b.controller_context(target_pid=123, shared_runtime=True), 'PRODUCTION_GATED')
        self.assertEqual(b.controller_context(target_pid=0, shared_runtime=False), 'PRODUCTION_GATED')

    def test_clock_and_read_span_invalid_do_not_start_job(self):
        b = self.bridge()
        now = time.perf_counter_ns()
        for observed, end in ((now+1, now), (now-1_000_000_000, now), (-1, now)):
            self.assertFalse(b.observe(self.state, self.config, observed_ns=observed,
                read_end_ns=end, context=b.pilot_authority.context))
        self.assertEqual(b.runner.counters['submitted'], 0)

    def test_admission_never_waits_for_owner_lock(self):
        b = self.bridge()
        now = time.perf_counter_ns()
        with b.request_lock:
            self.assertFalse(b.observe(self.state, self.config, observed_ns=now,
                read_end_ns=now, context=b.pilot_authority.context))
        self.assertEqual(b.bridge_counts['admission_busy'], 1)

    def test_same_source_does_not_resubmit_or_reset_deadline(self):
        b = self.bridge()
        offer = self.complete(b)
        now = time.perf_counter_ns()
        self.assertTrue(b.observe(self.state, self.config, observed_ns=now,
            read_end_ns=now, context=b.pilot_authority.context))
        limit=time.perf_counter()+.3
        while not b.bridge_counts['same_source_no_deadline_reset'] and time.perf_counter()<limit:
            time.sleep(.005)
        self.assertEqual(b.runner.counters['submitted'], 1)
        self.assertEqual(b.completed.job.deadline_ns, offer.job.deadline_ns)

    def test_no_completed_offer_retains_baseline(self):
        b = self.bridge()
        selected = self.select(b)
        self.assertIsNone(selected.receipt)
        self.assertEqual(selected.reason, 'NO_COMPLETED_PROPOSAL')

    def test_changed_config_and_source_do_not_dispatch_offer(self):
        b = self.bridge()
        self.complete(b)
        changed = replace(self.state, player=replace(self.state.player, mana=0))
        self.assertIsNone(self.select(b, state=changed).receipt)
        self.assertIsNone(self.select(b, config=replace(self.config, rage_target=110)).receipt)

    def test_late_and_final_reserve_rejected(self):
        b = self.bridge()
        offer = self.complete(b)
        baseline=BasicPolicyEngine(self.config).decide(self.state)
        for fields in (dict(now_ns=offer.job.deadline_ns),
                       dict(now_ns=time.perf_counter_ns(), final=True, final_remaining_seconds=2)):
            self.assertIsNotNone(revalidate_safely(b, offer, self.state, baseline, self.config,
                input_allowed=True, context=b.pilot_authority.context, **fields))

    def test_stop_signal_does_not_join_worker_or_sink(self):
        b=self.bridge()
        threads=[];original=b.runner.close
        def close(*args,**kwargs):
            threads.append(threading.get_ident())
            return original(*args,**kwargs)
        with patch.object(b.runner,'close',side_effect=close):
            start=time.perf_counter();b.stop()
            self.assertLess(time.perf_counter()-start,.05)
            self.assertNotIn(threading.get_ident(),threads)
        self.assertIsNone(self.select(b).receipt)

    def test_full_unknown_intervals_can_win_without_filling_them(self):
        b=self.bridge();offer=self.complete(b)
        pair=json.loads(offer.reply.summary_json)['candidates'][:2]
        self.assertTrue(all(_bounded_pilot_comparison(c) for c in pair))
        self.assertEqual(b.last_snapshot.evidence('planner.known_boss_threat').availability,'MISSING')

    def test_malformed_or_zero_filled_interval_cannot_override(self):
        b=self.bridge();offer=self.complete(b)
        candidate=json.loads(offer.reply.summary_json)['candidates'][0]
        for name in ('wrong_sum','zero_unknown','fake_future','nonfinite','fake_known'):
            c=json.loads(json.dumps(candidate))
            if name=='wrong_sum':c['utility']['high']+=1
            elif name=='zero_unknown':c['features']['R']=dict(low=0,high=0,status='UNSUPPORTED')
            elif name=='fake_future':c['features']['H']['high']=.5
            elif name=='nonfinite':c['contributions']['D'][1]=float('nan')
            else:c['features']['T']['status']='UNSUPPORTED'
            with self.subTest(name=name):self.assertFalse(_bounded_pilot_comparison(c))

    def test_actual_worker_exception_and_corrupt_reply_keep_basic(self):
        from tests.reasoning_worker_fixtures import raises,corrupt
        for target in (raises,corrupt):
            with self.subTest(target=target.__name__):
                b=self.bridge();b.runner.compute=target
                now=time.perf_counter_ns();b.observe(self.state,self.config,observed_ns=now,
                    read_end_ns=now,context=b.pilot_authority.context)
                limit=time.perf_counter()+3
                while b.runner.counters['faults']==0 and time.perf_counter()<limit:time.sleep(.005)
                self.assertGreater(b.runner.counters['faults'],0)
                self.assertIsNone(self.select(b).receipt)
                self.assertTrue(b.close())
                self.assertEqual(b.runner.counters['processes'],b.runner.counters['reaped'])

    def test_stop_reaps_hung_compute_off_controller(self):
        from tests.reasoning_worker_fixtures import hang
        b=self.bridge();b.runner.compute=hang
        now=time.perf_counter_ns();b.observe(self.state,self.config,observed_ns=now,
            read_end_ns=now,context=b.pilot_authority.context)
        limit=time.perf_counter()+2
        while not b.runner.counters['processes'] and time.perf_counter()<limit:time.sleep(.005)
        self.assertEqual(b.runner.counters['processes'],1)
        start=time.perf_counter();b.stop()
        self.assertLess(time.perf_counter()-start,.05)
        self.assertTrue(b.close())
        self.assertEqual(b.runner.counters['reaped'],1)

    def test_unsupported_baseline_family_stays_with_existing_owner(self):
        from pokiguard_v2.basic_policy import PolicyAction
        b=self.bridge();baseline=BasicPolicyEngine(self.config).decide(self.state)
        with patch('pokiguard_v2.reasoning_pilot.BasicPolicyEngine') as engine:
            engine.return_value.decide.return_value=replace(baseline,action=PolicyAction.CAST)
            now=time.perf_counter_ns()
            b._prepare((self.state,self.config,now,now))
        self.assertEqual(b.runner.counters['submitted'],0)
        self.assertEqual(b.bridge_counts['baseline_family_unsupported'],1)

    def test_virtual_source_record_hash_is_exportable(self):
        b=self.bridge();self.complete(b);s=b.last_snapshot
        source=dict(source=s.source.to_dict(),board=s.board,recorded=s.recorded.plain(),
            config=s.intent.settings.plain(),baseline=s.baseline.to_dict(),baseline_reason=s.baseline_reason)
        self.assertEqual(hashlib.sha256(canonical_json(source).encode()).hexdigest(),s.provenance.record_sha256)

    def test_sink_exception_disables_ai_not_basic(self):
        sink=MemorySink()
        sink.enqueue=lambda *_,**__: (_ for _ in ()).throw(OSError('synthetic disk fault'))
        b=self.bridge(sink=sink)
        b._record('SYNTHETIC_TEST', 'ROOT', time.perf_counter_ns())
        limit=time.perf_counter()+.5
        while not b.disabled and time.perf_counter()<limit: time.sleep(.005)
        self.assertTrue(b.disabled)
        self.assertIsNone(self.select(b).receipt)

    def test_root_and_preflight_never_plan_or_wait(self):
        b=self.bridge();offer=self.complete(b)
        baseline=BasicPolicyEngine(self.config).decide(self.state)
        with patch('pokiguard_v2.reasoning_pilot.BasicPolicyEngine', side_effect=AssertionError('plan on host')):
            result=select_safely(b,self.state,baseline,self.config,now_ns=time.perf_counter_ns(),
                input_allowed=True,context=b.pilot_authority.context)
            self.assertIs(result.receipt,offer)
            self.assertIsNone(revalidate_safely(b,offer,self.state,baseline,self.config,
                now_ns=time.perf_counter_ns(),input_allowed=True,context=b.pilot_authority.context))

    def test_disabled_controller_import_stays_light(self):
        p=subprocess.run([sys.executable,'-c',
            "import tools.basic_auto_bot,sys; assert not any(n.startswith('pokiguard_v2.reasoning_') for n in sys.modules)"],
            capture_output=True,text=True)
        self.assertEqual(p.returncode,0,p.stderr)

    @historical_test_view()
    def test_ast_removes_only_optional_reasoning_hooks(self):
        result=controller_ast_audit()
        self.assertTrue(result['pass_ast'],result)
        self.assertTrue(result['pass_counts'],result)


class PilotControllerTests(unittest.TestCase):
    def run_case(self, *, profile='simple', case='normal', ready=True, target_pid=0):
        box={}
        def factory(state,config):
            a=pilot_authority(state,config)
            b=PilotSelectionBridge(authority=a, diagnostics=MemorySink(),
                verified_build_sha256=a.game_build_sha256,enabled=True)
            box['bridge']=b
            self.addCleanup(b.close)
            if ready:
                now=time.perf_counter_ns()
                b.observe(state,config,observed_ns=now,read_end_ns=now,context=a.context)
                # A preceding existing snapshot may complete before this root.
                # Waiting is confined to fixture setup, outside controller.run.
                await_completed(b)
            return b
        with tempfile.TemporaryDirectory() as folder:
            result=controller_trace(Path(folder)/'run.jsonl',initial_combat=scoped_state(),
                profile=profile,case=case,selection_factory=factory,target_pid=target_pid,
                real_processing_clock=True)
        return result,box['bridge']

    def test_actual_pipeline_simple_existing_input_and_ack(self):
        (_,calls,rows),b=self.run_case()
        self.assertEqual(calls.count('FAKE_NORMAL_INPUT'),1)
        self.assertEqual(calls.count('executor.ack'),1)
        self.assertEqual(b.counts['VALID_COMPLETED_R1'],3)
        self.assertEqual(b.bridge_counts['completed_published'],1)
        decision=next(r for r in rows if r['event']=='policy_decision')
        self.assertEqual(decision['policyStep'],'REASONING_R1_SWAP')

    def test_actual_pipeline_careful_existing_input_and_ack(self):
        (_,calls,_),b=self.run_case(profile='careful')
        self.assertEqual(calls.count('executor.ack'),1)
        self.assertEqual(b.counts['VALID_COMPLETED_R1'],3)

    def test_same_existing_read_capture_input_order(self):
        (_,calls,_),_=self.run_case()
        with tempfile.TemporaryDirectory() as folder:
            old=controller_trace(Path(folder)/'old.jsonl',initial_combat=scoped_state(),
                                 controller_module=original_controller())
        self.assertEqual(calls,old[1])

    def test_real_pid_keeps_fake_capability_gated(self):
        (_,calls,rows),b=self.run_case(target_pid=123)
        self.assertEqual(calls.count('FAKE_NORMAL_INPUT'),1)
        self.assertEqual(b.counts['PRODUCTION_GATED'],1)
        self.assertNotEqual(next(r for r in rows if r['event']=='policy_decision')['policyStep'],
                            'REASONING_R1_SWAP')

    def test_first_observation_does_not_wait_for_worker(self):
        (_,calls,rows),b=self.run_case(ready=False)
        self.assertEqual(calls.count('FAKE_NORMAL_INPUT'),1)
        self.assertEqual(b.counts['NO_COMPLETED_PROPOSAL'],1)
        self.assertNotEqual(next(r for r in rows if r['event']=='policy_decision')['policyStep'],
                            'REASONING_R1_SWAP')

    def test_stale_source_never_sends_input(self):
        (_,calls,_),_=self.run_case(case='stale')
        self.assertNotIn('FAKE_NORMAL_INPUT',calls)

    def test_pending_input_never_sends_replacement(self):
        (_,calls,_),_=self.run_case(case='pending')
        self.assertEqual(calls.count('FAKE_NORMAL_INPUT'),1)
        self.assertEqual(calls.count('executor.ack'),0)

    def test_stop_before_input_never_dispatches(self):
        (_,calls,_),_=self.run_case(case='stop_before_input')
        self.assertNotIn('FAKE_NORMAL_INPUT',calls)


if __name__=='__main__':
    unittest.main()
