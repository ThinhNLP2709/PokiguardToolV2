"""C3 composed offline boundaries, including the unmodified controller Stop.

The controlled Stop harness executes tools.basic_auto_bot.run itself. Policy /
preflight cases below are component compositions, not synthetic live games.
"""
from __future__ import annotations
from tests.game_update_fixture import historical_test_view

from contextlib import ExitStack, redirect_stdout
from dataclasses import replace
import hashlib
import io
import json
import os
from pathlib import Path
import tempfile
import time
from types import SimpleNamespace
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.autonomous_control import (
    AutonomousActionIdentity, AutonomousGuard, PendingAutonomousAction,
    direct_runtime_swap_preflight_failure,
)
from pokiguard_v2.basic_policy import PlayStyle, PolicyAction
from pokiguard_v2.reasoning_settings import AISettings, RunShadowSession
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.reasoning_shadow import ShadowAdapter, attach_shadow_log
from tests import reasoning_worker_fixtures as fault
from tests.test_reasoning_runner import wait_for
from tests.test_reasoning_shadow import MemorySink, publication, sent_row
from tools import basic_auto_bot as bot

ROOT=Path(__file__).resolve().parents[1]


def evidence(kind, **fields):
    destination=os.environ.get("POKIGUARD_C3_OFFLINE_EVIDENCE")
    if destination:
        path=Path(destination);path.parent.mkdir(parents=True,exist_ok=True)
        with path.open("a",encoding="utf-8") as stream:
            stream.write(json.dumps(dict(kind=kind,**fields),separators=(",",":"))+"\n")


def stopped_controller(path, adapter=None, pending=False, before_stop=None):
    """Native/game surfaces are fail-closed sentinels, never available handles."""
    calls=[]
    def noted(name, value=None):
        def call(*args,**kwargs):
            calls.append(name)
            return value
        return call
    target=SimpleNamespace(pid=0,game_assembly=SimpleNamespace(base=1),
                           is_running=noted("process.is_running",True))
    provider=SimpleNamespace(scan_diagnostics={"lobbyBaselineReady":True},metrics={})
    executor=SimpleNamespace(swap_pacer=SimpleNamespace(decision=lambda:{}))
    runtime=bot.SharedCombatRuntime(target,provider,SimpleNamespace(),None,executor,None)
    guard=AutonomousGuard();guard.begin_session()
    if pending:
        _,state,decision,_,_=publication()
        identity=AutonomousActionIdentity.from_decision(state,decision)
        assert guard.reserve(identity)
        guard.begin(PendingAutonomousAction(identity,0,None,None))
    def stop_poll():
        calls.append("hotkeys.poll")
        if before_stop is not None:before_stop()
        return False,False,True
    hotkeys=SimpleNamespace(poll=stop_poll)
    tap=SimpleNamespace(diagnostics={})
    tap_context=Mock();tap_context.__enter__=Mock(return_value=tap);tap_context.__exit__=Mock(return_value=False)
    args=bot.build_parser().parse_args(["--watch","--no-beep","--pass-acceptance-stage","DISABLED","--log",str(path)])
    with ExitStack() as stack:
        for name,value in {
            "AutoHotkeyEdges":lambda:hotkeys,
            "AutonomousGuard":lambda:guard,
            "DispatcherTransportTap":lambda _:tap_context,
            "_prime_transport_for_runtime":noted("transport.prime",{}),
            "read_match_runtime":noted("runtime.read",(None,SimpleNamespace(match_id=None))),
        }.items():stack.enter_context(patch.object(bot,name,value))
        for name in ("attach_target","capture_client_rgb","NativeWin32Backend","_create_shared_combat_runtime"):
            stack.enter_context(patch.object(bot,name,side_effect=AssertionError("native boundary forbidden: "+name)))
        stack.enter_context(redirect_stdout(io.StringIO()))
        result=bot.run(args,shared_runtime=runtime,shadow_adapter=adapter)
    rows=[json.loads(line) for line in path.read_text(encoding="utf-8").splitlines()]
    for row in rows:
        row.pop("timestamp",None)
        if row["event"]=="auto_controller_started":row["config"]["log"]="OFFLINE_NORMALIZED_PATH"
    return result,calls,rows,guard


class ReasoningIntegrationTests(unittest.TestCase):
    @historical_test_view()
    def test_c2_sources_preserved_except_documented_AI_rotation_fix(self):
        from tests.reasoning_controller_fixture import assert_c3_source_compatibility
        assert_c3_source_compatibility(self)

    def test_actual_controller_stop_order_and_pending_parity_100_trials(self):
        with tempfile.TemporaryDirectory() as temp:
            directory=Path(temp)
            for trial in range(100):
                with self.subTest(trial=trial):
                    pending=bool(trial%2)
                    baseline=stopped_controller(directory/f"baseline-{trial}.jsonl",pending=pending)
                    sink=MemorySink(fail=trial%4==0)
                    adapter=ShadowAdapter(diagnostics=sink,compute=fault.hang)
                    if trial%4==1:sink.buffer.disable("C3 known disk/full fault")
                    if trial%4==2:adapter.stop()
                    try:
                        start=time.perf_counter_ns()
                        actual=stopped_controller(directory/f"shadow-{trial}.jsonl",adapter,pending)
                        elapsed=time.perf_counter_ns()-start
                        self.assertEqual(baseline[:3],actual[:3])
                        self.assertEqual(actual[1],["transport.prime","runtime.read","process.is_running","hotkeys.poll"])
                        self.assertFalse(actual[3].input_allowed)
                        self.assertTrue(adapter.stopped.is_set())
                        summary=actual[2][-1]
                        self.assertEqual(summary["stopReason"],"EMERGENCY_STOP")
                        self.assertEqual(summary["totalInputs"],0)
                        evidence("actual_controller_stop",trial=trial,pending=pending,fixture=trial%4,
                            full_controller_ns=elapsed,calls=actual[1],gameplay_log_parity=True,total_inputs=0)
                    finally:self.assertTrue(adapter.close())

    def test_native_session_stop_executes_actual_controller_with_active_hung_worker(self):
        with tempfile.TemporaryDirectory() as temp:
            directory=Path(temp)
            from pokiguard_v2.reasoning_shadow import create_shadow
            session=RunShadowSession(DesktopConfig(ai=AISettings(True)),directory=directory/"ai",
                observer=lambda *_:True,
                factory=lambda **kw:create_shadow(compute=fault.hang,**kw))
            adapter=session.prepare()
            self.assertIsNotNone(adapter)
            _,_,_,_,raw=publication()
            def seed_existing_job():
                adapter.observe_line(raw)
                wait_for(lambda:bool(adapter.runner.active_pid))
            try:
                result,calls,rows,guard=stopped_controller(directory/"actual.jsonl",adapter,pending=True,before_stop=seed_existing_job)
                self.assertEqual(result,0);self.assertFalse(guard.input_allowed)
                self.assertEqual(rows[-1]["totalInputs"],0)
                self.assertEqual(calls.count("runtime.read"),1)
            finally:
                session.stop();self.assertTrue(adapter.close(2))
            self.assertEqual(adapter.runner.counters["processes"],adapter.runner.counters["reaped"])

    def test_real_preflight_guards_compose_with_shadow_without_source_or_action_authority(self):
        config,state,decision,fields,raw=publication()
        for case in ("normal","stale","wrong_turn","pending","duplicate","stopped"):
            outputs=[]
            for enabled in (False,True):
                adapter=ShadowAdapter(diagnostics=MemorySink(),compute=fault.retain) if enabled else None
                original=io.StringIO();log=attach_shadow_log(original,adapter,config)
                guard=AutonomousGuard();guard.begin_session()
                identity=AutonomousActionIdentity.from_decision(state,decision)
                pending=PendingAutonomousAction(identity,0,None,None)
                calls=["provider.poll"]
                fresh=replace(state,battle=replace(state.battle,turn_number=state.battle.turn_number+1)) if case=="stale" else state
                if case in {"pending","duplicate"}:
                    self.assertTrue(guard.reserve(identity));guard.begin(pending)
                    if case=="duplicate":guard.complete_pending()
                if case=="stopped":guard.stop()
                try:
                    bot._write(log,"policy_decision",**fields,trace=decision.trace)
                    allowed=identity.source.matches(fresh) and guard.reserve(identity)
                    if allowed:
                        calls.extend(("window.status","capture.modal","runtime.preflight"))
                        failure=direct_runtime_swap_preflight_failure(pending,match_id=state.battle.match_id,
                            turn=state.battle.turn_number,current_player="boss" if case=="wrong_turn" else "local",
                            local_username="local",remaining_seconds=10,local_move_sequence=None,minimum_action_time=1)
                        if failure is None:
                            calls.append("FAKE_NORMAL_INPUT")
                            guard.begin(pending)
                            log.write(sent_row(state,decision,fields))
                            bot._write(log,"action_result",result="SWAP_ACKNOWLEDGED",action={"identity":identity})
                            guard.complete_pending()
                        else:guard.cancel_reservation(identity)
                    rows=[json.loads(line) for line in original.getvalue().splitlines()]
                    for row in rows:row.pop("timestamp",None)
                    outputs.append((calls,rows,guard.input_allowed,guard.executed_count))
                finally:
                    if adapter:self.assertTrue(adapter.close())
            self.assertEqual(outputs[0],outputs[1],case)
            self.assertEqual(outputs[1][0].count("FAKE_NORMAL_INPUT"),int(case=="normal"))

    def test_all_profiles_published_basic_bytes_and_no_non_swap_guessing(self):
        for profile in PlayStyle:
            config,_,_,fields,raw=publication(profile)
            baseline=io.StringIO();actual=io.StringIO()
            adapter=ShadowAdapter(diagnostics=MemorySink(),compute=fault.retain)
            try:
                observed=attach_shadow_log(actual,adapter,config)
                with patch.object(bot,"utc_timestamp",return_value="C3_FROZEN_TIME"):
                    bot._write(baseline,"policy_decision",**fields)
                    bot._write(observed,"policy_decision",**fields)
                self.assertEqual(baseline.getvalue(),actual.getvalue())
                self.assertFalse(hasattr(adapter,"executor"));self.assertFalse(hasattr(adapter,"provider"))
            finally:self.assertTrue(adapter.close())

    def test_worker_faults_do_not_replace_or_mutate_basic_publication_30_trials_each(self):
        config,state,decision,fields,raw=publication()
        for variant in (fault.crash,fault.corrupt,fault.mismatch,fault.raises,fault.hang,fault.cooperative):
            for trial in range(30):
                with self.subTest(variant=variant.__name__,trial=trial):
                    sink=MemorySink();adapter=ShadowAdapter(diagnostics=sink,compute=variant,
                        budget_ms=350 if variant in (fault.hang,fault.cooperative) else 4000)
                    original=io.StringIO();observed=attach_shadow_log(original,adapter,config)
                    try:
                        observed.write(raw)
                        wait_for(lambda:adapter.runner.outcome is not None or adapter.runner.counters["faults"]>0)
                        observed.write(sent_row(state,decision,fields))
                        wait_for(lambda:adapter.counts["dispatched"]==1)
                        self.assertTrue(original.getvalue().startswith(raw))
                        actual=json.loads(original.getvalue()[len(raw):])
                        expected=json.loads(sent_row(state,decision,fields))
                        actual.pop("timestamp");expected.pop("timestamp")
                        self.assertEqual(actual,expected)
                        self.assertIs(decision.action,PolicyAction.SWAP)
                        for row in sink.records():
                            self.assertFalse(row["input_authority"])
                            self.assertFalse(row["payload"].get("selection_authority",False))
                        outcome=adapter.runner.outcome
                        evidence("worker_fault",variant=variant.__name__,trial=trial,
                            reason=None if outcome is None else outcome[1],counts=dict(adapter.counts),
                            runner_counts=dict(adapter.runner.counters),baseline_action=decision.action.value,
                            gameplay_publication_parity=True,input_authority=False)
                    finally:
                        self.assertTrue(adapter.close(2))
                        self.assertEqual(adapter.runner.counters["processes"],adapter.runner.counters["reaped"])

if __name__=="__main__":unittest.main()
