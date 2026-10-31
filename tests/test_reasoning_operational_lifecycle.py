"""P16 regression: synthetic states/temp claims only; no native game access."""
from dataclasses import replace
import json
from pathlib import Path
import tempfile
import threading
import time
import unittest
from unittest.mock import patch

from pokiguard_v2.autonomous_control import AutonomousSource
from pokiguard_v2.basic_policy import BasicPolicyEngine, PolicyConfig
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.pet_configuration import basic_policy_config
from pokiguard_v2.reasoning_pilot import PilotSelectionBridge, await_pilot_safely
from pokiguard_v2.reasoning_selection import select_safely, revalidate_safely
from pokiguard_v2.win32_input import ClickStatus
from types import SimpleNamespace
from tests import test_reasoning_operational as fixture
from tests.test_reasoning_pilot import MemorySink


def wait_owner(predicate, timeout=5):
    """Test owner wait only; never inserted into the runtime decision path."""
    deadline = time.perf_counter()+timeout
    while not predicate():
        if time.perf_counter() >= deadline: raise AssertionError("cleanup not confirmed")
        time.sleep(.005)


class SessionLifecycleTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory()
        self.addCleanup(self.temp.cleanup)
        self.root = Path(self.temp.name)
        self.session = fixture.OperationalSessionTests().session(self.root)
        self.addCleanup(self.finish)

    def finish(self):
        self.session.stop()
        if self.session.finalizer is not None:
            self.session.finalizer.join(5)
            self.assertFalse(self.session.finalizer.is_alive())

    def bind(self):
        self.session.bind_run("SYNTHETIC_FARM", self.root/"farm")
        return self.session.adapter

    def retire(self):
        # These cases require a healthy, warm owner before testing expiry/cap
        # or successor behavior. Stop-during-startup is exercised separately;
        # do not make that race the unspoken prerequisite of a healthy close.
        wait_owner(lambda: self.session.adapter.runner.ready.is_set()
            or self.session.adapter.disabled)
        self.assertFalse(self.session.adapter.disabled)
        self.assertTrue(self.session.adapter.runner.ready.is_set())
        self.session.collector.stop()
        self.session.adapter.stop()
        index = len(self.session.bridges)-1
        wait_owner(lambda: index in self.session.retirements)
        return self.session.retirements[index]

    def receipt(self):
        self.finish()
        return json.loads((self.root/"ai/watermarks.json").read_text(encoding="utf-8"))

    def test_three_real_offline_workers_writers_successors_and_durable_sequences(self):
        self.bind()
        s = fixture.native_state()
        c = basic_policy_config(DesktopConfig(boss_id="1", max_match_attempts=3))
        for index in range(3):
            options = self.session.prepare_options()
            b, t = options["selection_adapter"], options["swap_timing_adapter"]
            now = time.perf_counter_ns()
            b.observe(s,c,observed_ns=now,read_end_ns=now,context=b.pilot_authority.context)
            self.assertEqual(await_pilot_safely(b,s,BasicPolicyEngine(c).decide(s),c,
                context=b.pilot_authority.context,stop_requested=lambda:False),"COMPLETED")
            t.observe_start(); t.observe_end(state=s)
            t.decision(state=s,config=c,input_parameters=fixture.PARAMS)
            t.start(state=s,config=c,input_mode="foreground",
                    source_hash=AutonomousSource.from_state(s).critical_state_hash)
            t.preflight(remaining=12,failure=None,read_end_ns=time.perf_counter_ns())
            t.finish(result=SimpleNamespace(sent_clicks=2,input_mode="two_click",status=ClickStatus.SENT))
            self.assertTrue(self.retire()["healthy"])
            self.assertEqual(len(self.session.bridges),index+1)
            self.assertFalse(self.session.faulted)
        receipt = self.receipt()
        self.assertEqual(receipt["sequence"],3)
        self.assertEqual(len(receipt["combats"]),3)
        self.assertFalse(receipt["session"]["faulted"])
        for combat in receipt["combats"]:
            self.assertTrue(combat["healthy"])
            self.assertEqual(combat["worker_counts"]["completed"],1)
            self.assertEqual(combat["worker_counts"]["reaped"],1)
            stats = combat["after_close"]
            self.assertEqual(stats["eligible"],stats["written"])
            self.assertEqual(stats["failure"],"CLOSED")

    def test_pending_cleanup_keeps_basic_without_wait_or_false_fault(self):
        b = self.bind()
        with patch.object(b,"stop"):
            b.stopped = True
            with patch.object(b.thread,"is_alive",return_value=True):
                with patch.object(self.session,"_new_bridge",side_effect=AssertionError("overlap")):
                    start = time.perf_counter()
                    self.assertEqual(self.session.prepare_options(),{})
                    self.assertLess(time.perf_counter()-start,.025)
                    self.assertFalse(self.session.faulted)
                    self.assertEqual(self.session.status_history[-1]["reason"],"SUCCESSOR_CLEANUP_PENDING")

    def test_closed_sink_alone_is_not_cleanup_confirmation(self):
        b = self.bind()
        with patch.object(b.thread,"is_alive",return_value=True):
            b.stopped = True
            b.sink.buffer.disable("CLOSED")
            self.assertEqual(self.session.prepare_options(),{})
            self.assertEqual(len(self.session.bridges),1)
            self.assertFalse(self.session.faulted)

    def test_actual_active_sink_failure_is_persisted(self):
        b = self.bind()
        b.sink.buffer.disable("SYNTHETIC_WRITER_FAILURE")
        self.assertEqual(self.session.prepare_options(),{})
        receipt = self.receipt()
        self.assertTrue(receipt["session"]["faulted"])
        fault = receipt["session"]["first_fault"]
        self.assertEqual(fault["reason"],"ACTIVE_DIAGNOSTICS_UNAVAILABLE")
        self.assertEqual(fault["stage"],"PREPARE")
        self.assertEqual(fault["combat_index"],0)

    def test_expiry_after_healthy_close_is_persisted_outside_closed_log(self):
        self.bind(); self.retire()
        self.session.data["expires_at"] = 0
        self.assertEqual(self.session.prepare_options(),{})
        receipt = self.receipt()
        self.assertEqual(receipt["session"]["first_fault"]["reason"],"REQUEST_EXPIRED")
        self.assertTrue(receipt["combats"][0]["healthy"])

    def test_unconfirmed_worker_cleanup_cannot_allocate_successor(self):
        b = self.bind()
        with patch.object(b.thread,"is_alive",return_value=True):
            b.stopped = True; b.cleanup_ok = False
            with patch.object(self.session,"_new_bridge",side_effect=AssertionError("overlap")):
                self.assertEqual(self.session.prepare_options(),{})
                self.assertEqual(self.session.first_fault["reason"],"WORKER_CLEANUP_UNCONFIRMED")

    def test_unhealthy_retirement_and_cap_do_not_reset_claim(self):
        self.bind(); self.retire()
        claim = self.root/"logs/operational_pilot_claims"/("a"*32+".json")
        original = claim.read_bytes()
        self.session.data["total_attempt_cap"] = 1
        self.assertEqual(self.session.prepare_options(),{})
        self.assertEqual(self.session.first_fault["reason"],"RESOURCE_CAP_EXHAUSTED")
        self.assertEqual(claim.read_bytes(),original)
        with self.assertRaises(FileExistsError): fixture.OperationalSessionTests().session(self.root)

    def test_unhealthy_retirement_stays_disabled(self):
        self.bind(); item = self.retire(); item["healthy"] = False
        self.assertEqual(self.session.prepare_options(),{})
        self.assertEqual(self.session.first_fault["reason"],"RETIRED_BRIDGE_UNHEALTHY")

    def test_factory_unavailable_keeps_basic_and_status_without_replacing_owner(self):
        self.bind(); self.retire()
        with patch("pokiguard_v2.reasoning_pilot.create_pilot_bridge",return_value=None):
            self.assertEqual(self.session.prepare_options(),{})
        self.assertEqual(len(self.session.bridges),1)
        self.assertFalse(self.session.faulted)
        self.assertEqual(self.session.status_history[-1]["reason"],"SUCCESSOR_FACTORY_UNAVAILABLE")

    def test_stop_racing_factory_never_delivers_new_options_and_reaps_every_owner(self):
        self.bind(); self.retire()
        from pokiguard_v2.reasoning_pilot import create_pilot_bridge
        def racing_factory(**kwargs):
            bridge = create_pilot_bridge(**kwargs)
            self.session.stop()
            return bridge
        with patch("pokiguard_v2.reasoning_pilot.create_pilot_bridge",side_effect=racing_factory):
            self.assertEqual(self.session.prepare_options(),{})
        receipt = self.receipt()
        self.assertEqual(len(receipt["combats"]),2)
        self.assertTrue(all(x["bridge_closed"] and x["closed"] for x in receipt["combats"]))
        self.assertEqual(self.session.prepare_options(),{})

    def test_busy_prepare_and_signal_only_stop_have_bounded_status(self):
        self.bind()
        with self.session.options_lock:
            for _ in range(100): self.assertEqual(self.session.prepare_options(),{})
            start = time.perf_counter(); self.session.stop()
            self.assertLess(time.perf_counter()-start,.025)
        self.assertLessEqual(len(self.session.status_history),32)
        self.assertEqual(self.session.session_counts["PREPARE_BUSY"],100)


class AdmissionRegressionTests(unittest.TestCase):
    def bridge(self):
        s = fixture.native_state(); c = PolicyConfig()
        a = fixture.operational_authority(s,c,max_read_span_ms=100)
        b = PilotSelectionBridge(authority=a,diagnostics=MemorySink(),
            verified_build_sha256=a.game_build_sha256,enabled=True,decision_budget=True,warm_worker=True)
        self.addCleanup(b.close)
        return b,s,c,BasicPolicyEngine(c).decide(s)

    def complete(self,b,s,c,baseline):
        now=time.perf_counter_ns()
        self.assertTrue(b.observe(s,c,observed_ns=now,read_end_ns=now,context=b.pilot_authority.context))
        self.assertEqual(await_pilot_safely(b,s,baseline,c,context=b.pilot_authority.context,
            stop_requested=lambda:False),"COMPLETED")
        return b.completed

    def test_rejected_same_source_cannot_reuse_old_completion_at_any_checkpoint(self):
        b,s,c,baseline = self.bridge(); offer = self.complete(b,s,c,baseline)
        now=time.perf_counter_ns()
        self.assertFalse(b.observe(s,c,observed_ns=now-101_000_000,read_end_ns=now,context=b.pilot_authority.context))
        reason = "OBSERVATION_READ_SPAN_EXCEEDED"
        self.assertEqual(await_pilot_safely(b,s,baseline,c,context=b.pilot_authority.context,
            stop_requested=lambda:False),reason)
        selected = select_safely(b,s,baseline,c,now_ns=now,input_allowed=True,context=b.pilot_authority.context)
        self.assertIsNone(selected.receipt); self.assertEqual(selected.reason,reason)
        for final in (False,True):
            self.assertEqual(revalidate_safely(b,offer,s,baseline,c,now_ns=now,
                input_allowed=True,context=b.pilot_authority.context,final=final,final_remaining_seconds=12),reason)
        self.assertEqual(b.runner.counters["submitted"],1)
        self.assertEqual(b.budget_receipts[-1]["admission"]["reason"],reason)

    def test_invalid_clock_and_busy_admission_explain_fallback_without_wait(self):
        b,s,c,baseline = self.bridge(); self.complete(b,s,c,baseline)
        now=time.perf_counter_ns()
        for observed,end,reason in [(now+1,now,"OBSERVATION_CLOCK_INVALID"),
                                    (True,now,"OBSERVATION_CLOCK_INVALID")]:
            self.assertFalse(b.observe(s,c,observed_ns=observed,read_end_ns=end,context=b.pilot_authority.context))
            self.assertEqual(await_pilot_safely(b,s,baseline,c,context=b.pilot_authority.context,stop_requested=lambda:False),reason)
        with b.request_lock:
            self.assertFalse(b.observe(s,c,observed_ns=now,read_end_ns=now,context=b.pilot_authority.context))
            start=time.perf_counter()
            self.assertEqual(await_pilot_safely(b,s,baseline,c,context=b.pilot_authority.context,stop_requested=lambda:False),"ADMISSION_BUSY")
            self.assertLess(time.perf_counter()-start,.025)

    def test_valid_same_source_preserves_original_job_deadline_and_retention(self):
        b,s,c,baseline = self.bridge(); offer = self.complete(b,s,c,baseline)
        self.assertIsNone(offer.reply.proposal)
        self.complete(b,s,c,baseline)
        self.assertEqual(b.completed.job.deadline_ns,offer.job.deadline_ns)
        self.assertEqual(b.runner.counters["submitted"],1)
        self.assertEqual(b.budget_receipts[-1]["worker_disposition"],"RETAIN_BASELINE")

    def test_config_change_and_short_timer_do_not_start_replacement_job(self):
        b,s,c,baseline = self.bridge(); offer = self.complete(b,s,c,baseline)
        self.assertEqual(await_pilot_safely(b,s,baseline,replace(c,rage_target=110),
            context=b.pilot_authority.context,stop_requested=lambda:False),"SOURCE_CHANGED")
        short=replace(s,battle=replace(s.battle,turn_time_remaining_seconds=1))
        now=time.perf_counter_ns(); b.observe(short,c,observed_ns=now,read_end_ns=now,context=b.pilot_authority.context)
        self.assertEqual(await_pilot_safely(b,short,baseline,c,context=b.pilot_authority.context,
            stop_requested=lambda:False),"NO_BUDGET")
        self.assertEqual(b.runner.counters["submitted"],1)
        self.assertEqual(b.completed.job.deadline_ns,offer.job.deadline_ns)

    def test_cohort_rejection_is_distinct_from_completed_retention(self):
        b,s,c,baseline = self.bridge()
        changed=replace(s,opponents=tuple(replace(x,attack=x.attack+1) for x in s.opponents))
        now=time.perf_counter_ns(); b.observe(changed,c,observed_ns=now,read_end_ns=now,context=b.pilot_authority.context)
        self.assertEqual(await_pilot_safely(b,changed,baseline,c,context=b.pilot_authority.context,
            stop_requested=lambda:False),"FALLBACK")
        self.assertEqual(b.budget_receipts[-1]["preparation_reason"],"COHORT_OR_CONFIG_CHANGED")
        self.assertEqual(b.runner.counters["submitted"],0)


class HistoricalBindingTests(unittest.TestCase):
    def test_old_native_review_rejects_current_runtime_and_export_cannot_mint_allowance(self):
        from pokiguard_v2.reasoning_calibration_review import verify_review
        from pokiguard_v2.reasoning_calibration import source_fingerprint
        from tools.review_reasoning_calibration import ROOT, export_review
        directory=ROOT/'docs/phase5/artifacts/5d1_operational_launch_p14_v1/review_final'
        data=json.loads((directory/'calibration_review.json').read_text(encoding='utf-8'))
        with self.assertRaises(ValueError):
            verify_review(directory,data,runtime_sha256=source_fingerprint(ROOT),
                host_sha256=data['host_sha256'],game_build_sha256=data['game_build_sha256'],
                policy_json=data['policy_json'],witness=data['proposed_scope_witness'])
        with tempfile.TemporaryDirectory() as name,self.assertRaises(ValueError):
            export_review(Path(name)/'UNREVIEWED_CURRENT_SOURCE')

    def test_exact_runtime_binding_rejects_future_edit_in_same_module(self):
        from tests.reasoning_controller_fixture import before_p16_path
        root=Path(__file__).resolve().parents[1]
        original=Path.read_bytes
        def tampered(path):
            raw=original(path)
            return raw+b'\n# SYNTHETIC_FUTURE_EDIT\n' if path==root/'src/pokiguard_v2/reasoning_pilot.py' else raw
        with patch.object(Path,'read_bytes',tampered),self.assertRaises(AssertionError):
            before_p16_path(root,'tools/basic_auto_bot.py')


if __name__ == "__main__": unittest.main()
