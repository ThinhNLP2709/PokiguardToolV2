"""Common host/worker/controller qualification with synthetic native surfaces."""
from dataclasses import replace
import json,tempfile,threading,time,unittest
from pathlib import Path
from unittest.mock import patch
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.reasoning_common_evidence import packet,packet_hash,incumbent_action
from pokiguard_v2.reasoning_common_selection import (CommonAdmission,CommonCompleted,CommonSelectionBridge,
    CONTEXT,create_common_bridge,_CheckpointLog)
from pokiguard_v2.reasoning_full_actions import publish_context_safely
from pokiguard_v2.reasoning_runner import make_job,_reply_for
from pokiguard_v2.reasoning_selection import select_safely,revalidate_safely
from pokiguard_v2.reasoning_snapshot import FrozenJSON,canonical_json
from pokiguard_v2.state import GamePhase
from tests.test_reasoning_common_evidence import fixture
from tests.test_reasoning_pilot import MemorySink,scoped_state
from tests.reasoning_controller_fixture import controller_trace


def admission(config,**kwargs):
    return CommonAdmission(canonical_json(jsonable(config)),
        FrozenJSON.of({'swap':100,'pet_skill':300,'pass':100}),
        FrozenJSON.of(dict(conversion=dict(mana=30,rage=20))),**kwargs)


def completed_fixture():
    value=fixture();a=admission(value[1]);now=time.perf_counter_ns()
    problem=a.problem(value,run_id='SYNTHETIC_COMMON',generation=1,observed_ns=now,read_end_ns=now)
    limit=a.limit(value,now,now,time.perf_counter_ns())
    job=make_job(problem,deadline=limit,generation=1)
    wire=dict(snapshot=problem.to_dict(),binding=vars(job.binding),job_id=job.job_id,generation=job.generation,
        refinement=False,budget_ns=limit-job.created_ns)
    raw=_reply_for(wire,threading.Event())
    return value,a,job,raw


class CommonSelectionTests(unittest.TestCase):
    def test_checkpoint_log_is_bounded_and_never_overwrites(self):
        buffer=_CheckpointLog()
        for i in range(64):self.assertTrue(buffer.enqueue(str(i).encode()))
        self.assertFalse(buffer.enqueue(b'overflow'));self.assertFalse(buffer.enqueue(b'x'*2049))
        self.assertEqual([str(i).encode() for i in range(64)],[buffer.take() for _ in range(64)])
        self.assertIsNone(buffer.take())

    def test_stop_interrupts_hung_worker_and_preserves_basic(self):
        from tests.reasoning_worker_fixtures import hang
        value=fixture();state,config,base,*_=value
        bridge=CommonSelectionBridge(admission=admission(config),diagnostics=MemorySink(),enabled=True)
        try:
            bridge.runner.compute=hang
            now=time.perf_counter_ns();bridge.observe(state,config,observed_ns=now,read_end_ns=now,context=CONTEXT)
            publish_context_safely(bridge,*value)
            self.assertEqual('STOPPED',bridge.await_decision(state,base,config,context=CONTEXT,
                stop_requested=lambda:bridge.runner.counters['processes']>0))
            self.assertIs(base,select_safely(bridge,state,base,config,now_ns=time.perf_counter_ns(),
                input_allowed=True,context=CONTEXT).decision)
        finally:self.assertTrue(bridge.close())
        self.assertEqual(bridge.runner.counters['processes'],bridge.runner.counters['reaped'])

    def test_admission_cannot_relabel_native_or_invent_effect(self):
        value=fixture();a=admission(value[1])
        for changes in (dict(context='PRODUCTION'),dict(reserves=FrozenJSON.of(dict(swap=0))),
                dict(models=FrozenJSON.of(dict(demon_geometry='GUESSED'))),
                dict(models=FrozenJSON.of(dict(conversion=dict(rage=-1)))),
                dict(budget_ms=6001)):
            with self.assertRaises(ValueError):replace(a,**changes)
        with patch('pokiguard_v2.reasoning_common_selection.WarmIsolatedRunner') as runner:
            self.assertIsNone(create_common_bridge(enabled=False));runner.assert_not_called()

    def test_complete_host_recomputes_comparison_and_rejects_corrupt_utility(self):
        value,a,job,raw=completed_fixture()
        result=CommonCompleted.prepare(job,canonical_json(raw).encode(),value,a)
        self.assertEqual(packet_hash(value),result.context_hash)
        self.assertLess(result.completed_ns,job.deadline_ns)
        bad=json.loads(canonical_json(raw));bad['summary']['candidates'][0]['utility']['low']+=10
        with self.assertRaisesRegex(ValueError,'utility/attribution'):
            CommonCompleted.prepare(job,canonical_json(bad).encode(),value,a)
        bad=json.loads(canonical_json(raw));bad['summary']['common_diagnostics']['global_optimum_claim']=True
        with self.assertRaises(ValueError):CommonCompleted.prepare(job,canonical_json(bad).encode(),value,a)
        with self.assertRaises(ValueError):CommonCompleted.prepare(job,canonical_json(raw).encode(),value,a,
            clock=lambda:job.deadline_ns+1)
        with self.assertRaises(ValueError):CommonCompleted.prepare(job,canonical_json(raw).encode(),value,a,
            cancelled=lambda:True)

    def test_current_config_capability_pass_owner_and_source_must_match(self):
        value,a,job,raw=completed_fixture();state,config,base,cap,h,owner,passed=value
        bridge=CommonSelectionBridge(admission=a,diagnostics=MemorySink(),enabled=True)
        self.addCleanup(bridge.close)
        bridge.last_admission='ADMITTED';bridge.action_context=value
        bridge.completed=CommonCompleted.prepare(job,canonical_json(raw).encode(),value,a)
        result=select_safely(bridge,state,base,config,now_ns=time.perf_counter_ns(),input_allowed=True,context=CONTEXT)
        self.assertIsNotNone(result.receipt)
        self.assertIsNone(revalidate_safely(bridge,result.receipt,state,base,config,
            now_ns=time.perf_counter_ns(),input_allowed=True,context=CONTEXT,final=True,final_remaining_seconds=14))
        fresh=replace(state,battle=replace(state.battle,turn_time_remaining_seconds=13))
        bridge.action_context=packet(fresh,config,base,replace(cap,observed_at=999),h,True)
        self.assertIsNone(revalidate_safely(bridge,result.receipt,fresh,base,config,
            now_ns=time.perf_counter_ns(),input_allowed=True,context=CONTEXT))
        for changed in (replace(state,phase=GamePhase.UNKNOWN,board=None),
                replace(state,battle=replace(state.battle,is_local_turn=False))):
            self.assertIsNone(select_safely(bridge,changed,base,config,now_ns=time.perf_counter_ns(),
                input_allowed=True,context=CONTEXT).receipt)
        for changed in (packet(state,config,base,replace(cap,cooldown_turns=1),h,True),
                packet(state,config,base,cap,h,True,False)):
            bridge.action_context=changed
            self.assertIsNone(select_safely(bridge,state,base,config,now_ns=time.perf_counter_ns(),
                input_allowed=True,context=CONTEXT).receipt)
        bridge.action_context=value
        changed=replace(state,player=replace(state.player,hp=state.player.hp-1))
        self.assertIsNone(select_safely(bridge,changed,base,config,now_ns=time.perf_counter_ns(),
            input_allowed=True,context=CONTEXT).receipt)
        self.assertEqual('PRODUCTION_GATED',bridge.controller_context(target_pid=123,shared_runtime=True))
        self.assertEqual('PRODUCTION_GATED',bridge.controller_context(target_pid=0,shared_runtime=False))

    def test_actual_warm_worker_then_reobservation_invalidates_offer(self):
        value=fixture();state,config,base,*_=value
        bridge=CommonSelectionBridge(admission=admission(config),diagnostics=MemorySink(),enabled=True)
        try:
            now=time.perf_counter_ns();bridge.observe(state,config,observed_ns=now,read_end_ns=now,context=CONTEXT)
            publish_context_safely(bridge,*value)
            self.assertEqual('COMPLETED',bridge.await_decision(state,base,config,context=CONTEXT,stop_requested=lambda:False),
                bridge.preparation_reason)
            self.assertIsNotNone(bridge.completed)
            now=time.perf_counter_ns();bridge.observe(state,config,observed_ns=now,read_end_ns=now,context=CONTEXT)
            self.assertIsNone(select_safely(bridge,state,base,config,now_ns=now,input_allowed=True,context=CONTEXT).receipt)
            start=time.perf_counter();bridge.stop();self.assertLess(time.perf_counter()-start,.05)
        finally:self.assertTrue(bridge.close())
        self.assertEqual(bridge.runner.counters['processes'],bridge.runner.counters['reaped'])

    def test_worker_fault_keeps_exact_basic_and_reaps_child(self):
        from tests.reasoning_worker_fixtures import raises
        value=fixture();state,config,base,*_=value
        bridge=CommonSelectionBridge(admission=admission(config),diagnostics=MemorySink(),enabled=True)
        try:
            bridge.runner.compute=raises
            now=time.perf_counter_ns();bridge.observe(state,config,observed_ns=now,read_end_ns=now,context=CONTEXT)
            publish_context_safely(bridge,*value)
            self.assertIn(bridge.await_decision(state,base,config,context=CONTEXT,stop_requested=lambda:False),('FALLBACK','UNAVAILABLE'))
            selected=select_safely(bridge,state,base,config,now_ns=time.perf_counter_ns(),input_allowed=True,context=CONTEXT)
            self.assertIs(base,selected.decision);self.assertIsNone(selected.receipt)
        finally:self.assertTrue(bridge.close())


class CommonControllerTests(unittest.TestCase):
    def test_actual_controller_preserves_existing_read_input_ack_sequence(self):
        box={}
        def factory(state,config):
            bridge=CommonSelectionBridge(admission=admission(config),diagnostics=MemorySink(),enabled=True)
            box['bridge']=bridge;self.addCleanup(bridge.close)
            return bridge
        with tempfile.TemporaryDirectory() as folder:
            options=dict(initial_combat=scoped_state(),real_processing_clock=True)
            before=controller_trace(Path(folder)/'basic.jsonl',**options)
            current=controller_trace(Path(folder)/'common.jsonl',selection_factory=factory,**options)
        self.assertEqual(before[1],current[1])
        self.assertEqual(1,current[1].count('FAKE_NORMAL_INPUT'))
        self.assertEqual(1,current[1].count('executor.ack'))
        bridge=box['bridge']
        self.assertTrue(bridge.budget_receipts,(bridge.last_admission,bridge.preparation_reason,bridge.counts))
        self.assertEqual('COMPLETED',bridge.budget_receipts[-1]['reason'],bridge.preparation_reason)
        self.assertGreaterEqual(bridge.counts['VALID_COMPLETED_COMMON'],3)


if __name__=='__main__':unittest.main()
