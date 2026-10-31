from __future__ import annotations

from dataclasses import asdict, replace
import io
import json
from pathlib import Path
import subprocess
import sys
import tempfile
import threading
import time
import unittest
from unittest.mock import patch

from pokiguard_v2.autonomous_control import AutonomousActionIdentity
from pokiguard_v2.basic_policy import BasicPolicyEngine, PlayStyle, PolicyAction, PolicyConfig
from pokiguard_v2.board_diagnostics import analyze_game_state
from pokiguard_v2.reasoning_diagnostics import DiagnosticBuffer, LogLimits
from pokiguard_v2.reasoning_shadow import (
    ShadowAdapter, _ObservedLog, attach_shadow_log, create_shadow,
    snapshot_from_publication, stop_shadow_safely,
)
from pokiguard_v2.state import CombatSessionKey
from tests import reasoning_worker_fixtures as fault
from tests.test_basic_policy import combat_state
from tests.test_reasoning_runner import wait_for
from tools.basic_auto_bot import _decision_fields, _jsonable, _write


class MemorySink:
    """OFFLINE ONLY: retained records, no claim of durable writes/shared backend."""
    def __init__(self, *, fail=False, limits=None):
        self.buffer = DiagnosticBuffer(limits or LogLimits(records=432, bytes=6*1024*1024))
        self.fail = fail

    def enqueue(self, raw, *, critical=False):
        if self.fail:
            raise OSError("OFFLINE injected disk failure")
        return self.buffer.enqueue(raw, critical=critical)

    def records(self):
        with self.buffer.lock:
            return [json.loads(raw) for raw in self.buffer.items]


def publication(profile=PlayStyle.SIMPLE, *, turn=14):
    base = combat_state(turn=turn)
    state = replace(base, battle=replace(base.battle,
        session_key=CombatSessionKey(1, base.battle.board_instance, "C1_OFFLINE_MATCH"),
        match_id="C1_OFFLINE_MATCH"))
    config = PolicyConfig(play_style=profile)
    policy = BasicPolicyEngine(config)
    analysis = analyze_game_state(state, policy_engine=policy)
    decision = policy.decide(state)
    fields = _decision_fields(state, decision, analysis)
    stream = io.StringIO()
    _write(stream, "policy_decision", **fields, trace=decision.trace)
    return config, state, decision, fields, stream.getvalue()


def sent_row(state, decision, fields):
    stream = io.StringIO()
    _write(stream, "action_sent", action=decision.action.value.upper(),
           identity=AutonomousActionIdentity.from_decision(state, decision), **fields)
    return stream.getvalue()


class ShadowTests(unittest.TestCase):
    def adapter(self, *, compute=fault.retain, sink=None, **kwargs):
        sink = sink or MemorySink()
        adapter = ShadowAdapter(diagnostics=sink, compute=compute,
                                run_id="C1_OFFLINE_RUN", **kwargs)
        self.addCleanup(lambda: self.assertTrue(adapter.close()))
        return adapter, sink

    def test_disabled_has_no_queue_worker_or_threads(self):
        before = set(threading.enumerate())
        log = io.StringIO()
        self.assertIs(attach_shadow_log(log, None, PolicyConfig()), log)
        self.assertIsNone(create_shadow())
        self.assertIsNone(create_shadow(enabled=True))  # Unsupported backend fails closed.
        self.assertEqual(set(threading.enumerate()), before)

    def test_disabled_controller_import_does_not_import_reasoning(self):
        program = "import tools.basic_auto_bot,sys; assert not any(k.startswith('pokiguard_v2.reasoning_') for k in sys.modules)"
        result = subprocess.run([sys.executable, "-c", program], capture_output=True, text=True)
        self.assertEqual(result.returncode, 0, result.stderr)

    def test_immutable_publication_and_config_detached_from_caller(self):
        config, _, _, _, raw = publication()
        adapter, _ = self.adapter()
        adapter.bind_config(config)
        snap = snapshot_from_publication(raw, adapter.config_json, adapter.run_id)
        self.assertEqual(snap.intent.settings.plain()["rage_target"], config.rage_target)
        row = json.loads(raw)
        row["boardSnapshot"][0][0][0] = "UNKNOWN"
        self.assertNotEqual(snap.board[0][0][0], "UNKNOWN")
        with self.assertRaises(ValueError):
            adapter.bind_config(replace(config, rage_target=0))
        self.assertEqual(snap.evidence("planner.model").availability, "MISSING")
        self.assertIsNone(snap.source.controller_generation)

    def test_no_heavy_preparation_on_host_write(self):
        config, _, _, _, raw = publication()
        adapter, _ = self.adapter()
        adapter.bind_config(config)
        seen = []
        original = snapshot_from_publication
        def instrument(*args):
            seen.append(threading.current_thread().name)
            return original(*args)
        with patch("pokiguard_v2.reasoning_shadow.snapshot_from_publication", side_effect=instrument):
            _ObservedLog(io.StringIO(), adapter).write(raw)
            wait_for(lambda: adapter.counts["prepared"] == 1)
        self.assertEqual(seen, ["reasoning-shadow"])

    def test_actual_dispatch_and_existing_ack_link_to_baseline_only(self):
        config, state, decision, fields, raw = publication()
        self.assertIs(decision.action, PolicyAction.SWAP)
        adapter, sink = self.adapter()
        adapter.bind_config(config)
        log = _ObservedLog(io.StringIO(), adapter)
        log.write(raw)
        log.write(sent_row(state, decision, fields))
        identity = AutonomousActionIdentity.from_decision(state, decision)
        _write(log, "action_result", result="SWAP_ACKNOWLEDGED", action={"identity": identity})
        wait_for(lambda: adapter.counts["outcomes"] == 1)
        dispatch = next(x for x in sink.records() if x["event_type"] == "reasoning.shadow_dispatch")
        job = next(iter(adapter.roots.values()))
        self.assertEqual(dispatch["payload"]["dispatched_candidate_id"], job.candidate_id(job.snapshot.baseline))
        self.assertFalse(dispatch["payload"]["replacement_input"])
        self.assertFalse(dispatch["input_authority"])
        outcome = next(x for x in sink.records() if x["event_type"] == "reasoning.shadow_outcome")
        self.assertEqual(outcome["payload"]["attribution"], "EXACT_DISPATCH_IDENTITY")
        self.assertEqual(outcome["payload"]["counterfactual_outcome"], "UNKNOWN")

    def test_missing_and_conflicting_dispatch_identity_remain_unknown(self):
        for conflict in ("source", "target", "board", "actor", "profile", "missing"):
            with self.subTest(conflict=conflict):
                config, state, decision, fields, raw = publication()
                adapter, sink = self.adapter()
                adapter.bind_config(config)
                adapter.observe_line(raw)
                row = json.loads(sent_row(state, decision, fields))
                if conflict == "source":
                    row["identity"]["source"]["turn"] += 1
                elif conflict == "target":
                    row["identity"]["target"] = [[0, 0], [0, 1]]
                elif conflict == "board":
                    row["boardSnapshot"][0][0][0] = "rage"
                elif conflict == "actor":
                    row["player"]["actor_number"] += 1
                elif conflict == "profile":
                    row["playStyle"] = "careful"
                else:
                    row["identity"] = None
                adapter.observe_line(json.dumps(row, separators=(",", ":")) + "\n")
                wait_for(lambda: adapter.counts["unknown_attribution"] == 1)
                self.assertEqual(adapter.counts["dispatched"], 0)

    def test_pending_or_unattributed_result_cannot_create_job_or_dispatch(self):
        adapter, sink = self.adapter()
        adapter.bind_config(PolicyConfig())
        _write(_ObservedLog(io.StringIO(), adapter), "action_result", result="WAITING", pending={})
        wait_for(lambda: adapter.counts["unknown_attribution"] == 1)
        self.assertEqual(adapter.runner.counters["submitted"], 0)

    def test_non_swap_and_missing_owner_never_invent_capability(self):
        for change in ("family", "owner", "session", "coordinates", "profile"):
            with self.subTest(change=change):
                config, _, _, _, raw = publication()
                adapter, sink = self.adapter()
                adapter.bind_config(config)
                row = json.loads(raw)
                if change == "family": row["selectedAction"] = "pet_skill"
                elif change == "owner": row["player"]["is_local"] = None
                elif change == "session": row["session"]["match_id"] = "OTHER"
                elif change == "coordinates": row["boardSnapshotOrder"] = "unknown"
                else: row["playStyle"] = "careful"
                adapter.observe_line(json.dumps(row, separators=(",", ":")) + "\n")
                wait_for(lambda: adapter.counts["unsupported"] == 1)
                self.assertEqual(adapter.runner.counters["submitted"], 0)
                wait_for(lambda: any(x["event_type"] == "reasoning.error" for x in sink.records()))
                error = next(x for x in sink.records() if x["event_type"] == "reasoning.error")
                self.assertIn("stack", error["payload"])
                self.assertEqual(adapter.counts["log_dropped"], 0)

    def test_full_queue_and_busy_lock_are_nonwaiting(self):
        config, _, _, _, raw = publication()
        adapter, _ = self.adapter()
        adapter.bind_config(config)
        with adapter.lock:
            self.assertFalse(adapter.observe_line(raw))
        adapter.stop()
        adapter.thread.join(1)
        adapter.runner.close()
        adapter.stopped.clear()  # Offline queue pressure fixture, no consumer.
        adapter.items.extend([(raw, 0, 0)] * 16)
        self.assertFalse(adapter.observe_line(raw))
        self.assertGreaterEqual(adapter.counts["dropped"], 2)
        self.assertLessEqual(adapter.counts["high_bytes"], 1024*1024)

    def test_oversized_publication_dropped_before_parsing(self):
        adapter, _ = self.adapter()
        adapter.bind_config(PolicyConfig())
        raw = '{"event":"policy_decision","data":"' + "x" * (1024*1024) + '"}\n'
        self.assertFalse(adapter.observe_line(raw))
        self.assertEqual(adapter.counts["dropped"], 1)

    def test_all_pipeline_queues_include_inflight_and_fit_combined_caps(self):
        from pokiguard_v2.reasoning_shadow import _Relay
        sink = MemorySink()
        relay = _Relay(sink)
        raw = b"{}\n"
        for _ in range(64):
            self.assertTrue(relay.enqueue(raw))
        record = relay.take()
        self.assertEqual(relay.bytes, 64 * len(raw))
        self.assertFalse(relay.enqueue(raw))
        relay.finish(record[0])
        self.assertTrue(relay.enqueue(raw))
        self.assertEqual(sink.buffer.limits.records + 64 + 16, 512)
        self.assertEqual(sink.buffer.limits.bytes + 2*1024*1024, 8*1024*1024)
        with self.assertRaises(ValueError):
            ShadowAdapter(diagnostics=MemorySink(limits=LogLimits()))

    def test_duplicate_publication_is_not_recomputed(self):
        config, _, _, _, raw = publication()
        adapter, _ = self.adapter()
        adapter.bind_config(config)
        adapter.observe_line(raw)
        adapter.observe_line(raw)
        wait_for(lambda: adapter.counts["prepared"] == 1)
        time.sleep(.02)
        self.assertEqual(adapter.runner.counters["submitted"], 1)

    def test_worker_faults_and_late_reply_never_change_basic_records(self):
        for compute, budget in ((fault.crash, 4000), (fault.corrupt, 4000), (fault.hang, 80)):
            with self.subTest(compute=compute.__name__):
                config, _, _, _, raw = publication()
                adapter, sink = self.adapter(compute=compute, budget_ms=budget)
                log = attach_shadow_log(io.StringIO(), adapter, config)
                log.write(raw)
                wait_for(lambda: adapter.runner.outcome is not None)
                self.assertEqual(log.log.getvalue(), raw)
                self.assertIsNone(adapter.runner.outcome[0])
                self.assertTrue(adapter.close())

    def test_fresh_source_supersedes_hung_job_without_replacing_input(self):
        config, state, decision, fields, raw = publication(turn=14)
        adapter, sink = self.adapter(compute=fault.hang)
        log = attach_shadow_log(io.StringIO(), adapter, config)
        log.write(raw)
        wait_for(lambda: adapter.runner.active_pid is not None)
        first = adapter.runner.current
        following = publication(turn=16)
        time.sleep(1.02)  # Explicit 1Hz production admission cap.
        log.write(following[4])
        wait_for(lambda: adapter.runner.current != first)
        self.assertEqual(adapter.runner.current.snapshot.source.turn, 16)
        # A delayed existing ACK still links to its historical dispatched root.
        log.write(sent_row(state, decision, fields))
        wait_for(lambda: adapter.counts["dispatched"] == 1)
        self.assertNotEqual(adapter.runner.current.job_id, first.job_id)
        self.assertFalse(hasattr(adapter, "select"))
        self.assertFalse(hasattr(adapter, "execute"))
        self.assertTrue(adapter.close())

    def test_new_fresh_turn_inside_rate_cap_invalidates_without_wait_or_new_job(self):
        config, _, _, _, raw = publication(turn=14)
        adapter, _ = self.adapter(compute=fault.hang)
        adapter.bind_config(config)
        adapter.observe_line(raw)
        wait_for(lambda: adapter.counts["prepared"] == 1)
        adapter.observe_line(publication(turn=16)[4])
        wait_for(lambda: adapter.counts["rate_limited"] == 1)
        self.assertEqual(adapter.counts["prepared"], 1)
        self.assertTrue(adapter.runner.invalidated.is_set())

    def test_owned_separate_sink_writes_correlated_events_without_touching_basic_log(self):
        with tempfile.TemporaryDirectory() as directory:
            adapter = create_shadow(enabled=True, directory=Path(directory), compute=fault.retain,
                                    run_id="C1_FACTORY_OFFLINE")
            self.assertIsNotNone(adapter)
            config, state, decision, fields, raw = publication()
            log = attach_shadow_log(io.StringIO(), adapter, config)
            log.write(raw)
            sent = sent_row(state, decision, fields)
            log.write(sent)
            wait_for(lambda: adapter.runner.outcome is not None)
            wait_for(lambda: adapter.sink.buffer.stats()["written"] >= 2)
            self.assertEqual(log.log.getvalue(), raw + sent)
            adapter.stop()
            self.assertTrue(adapter.close(timeout=3))
            self.assertTrue(adapter.sink.reaped)
            self.assertTrue(adapter.sink.buffer.stats()["accounting_valid"])
            records = [json.loads(line) for p in Path(directory).glob("*.jsonl") for line in p.read_text(encoding="utf-8").splitlines()]
            self.assertTrue(any(x["event_type"] == "reasoning.shadow_dispatch" for x in records))
            self.assertTrue(all(x["input_authority"] is False for x in records))

    def test_log_rate_exhaustion_stops_only_ai_and_counts_loss(self):
        from pokiguard_v2.reasoning_diagnostics import encode_event
        adapter, sink = self.adapter()
        for index in range(9):
            self.assertTrue(adapter.relay.enqueue(encode_event("reasoning.fixture", index, {}, {})))
        wait_for(lambda: adapter.counts["log_rate_limited"] >= 1)
        self.assertTrue(adapter.runner.stop_event.is_set())
        self.assertLessEqual(adapter.log_window_bytes, 128*1024)
        self.assertLessEqual(adapter.log_window_events, 8)

    def test_factory_skips_overlapping_owner_without_starting_another_writer(self):
        with tempfile.TemporaryDirectory() as directory:
            first = create_shadow(enabled=True, directory=Path(directory)/"first", compute=fault.retain)
            self.assertIsNotNone(first)
            try:
                self.assertIsNone(create_shadow(enabled=True, directory=Path(directory)/"second"))
                self.assertFalse((Path(directory)/"second").exists())
            finally:
                first.stop()
                self.assertTrue(first.close(timeout=3))
            first.runner.counters["processes"] = 1  # OFFLINE unconfirmed-cleanup state.
            self.assertIsNone(create_shadow(enabled=True, directory=Path(directory)/"second"))
            first.runner.counters["processes"] = 0
            second = create_shadow(enabled=True, directory=Path(directory)/"second", compute=fault.retain)
            self.assertIsNotNone(second)
            second.stop()
            self.assertTrue(second.close(timeout=3))

    def test_real_disk_faults_preserve_basic_bytes_and_signal_only_stop(self):
        from pokiguard_v2.reasoning_diagnostics import BoundedDiagnostics
        for target in (fault.log_denied, fault.log_disk_full, fault.log_hang, fault.log_crash):
            with self.subTest(target=target.__name__), tempfile.TemporaryDirectory() as directory:
                sink = BoundedDiagnostics(Path(directory), limits=LogLimits(records=432, bytes=6*1024*1024), writer_target=target)
                adapter = ShadowAdapter(diagnostics=sink, compute=fault.retain)
                config, _, _, _, raw = publication()
                wrapped = attach_shadow_log(io.StringIO(), adapter, config)
                try:
                    wrapped.write(raw)
                    if target is fault.log_hang:
                        wait_for(lambda: sink.buffer.stats()["in_writer"] == 1)
                    else:
                        wait_for(lambda: sink.buffer.disabled)
                    adapter.stop()
                    self.assertEqual(wrapped.log.getvalue(), raw)
                finally:
                    self.assertTrue(adapter.close(timeout=3))
                    self.assertTrue(sink.close())
                    self.assertTrue(sink.buffer.stats()["accounting_valid"])

    def test_real_r1_retains_unknown_context_without_fabricated_model(self):
        config, _, _, _, raw = publication()
        adapter, sink = self.adapter(compute=None)
        adapter.bind_config(config)
        adapter.observe_line(raw)
        wait_for(lambda: adapter.runner.outcome is not None)
        self.assertEqual(adapter.runner.outcome[1], "UNSUPPORTED_MODEL_OR_LEGALITY_CONTEXT")
        self.assertIsNone(adapter.runner.outcome[0].proposal)

    def test_sink_exception_degrades_only_ai(self):
        config, _, _, _, raw = publication()
        adapter, _ = self.adapter(sink=MemorySink(fail=True))
        adapter.bind_config(config)
        adapter.observe_line(raw)
        wait_for(lambda: adapter.counts["log_dropped"] > 0)
        self.assertTrue(adapter.runner.stop_event.is_set())
        self.assertEqual(adapter.last_fault, "SINK_OSError")

    def test_stop_is_signal_only_with_active_hung_worker(self):
        config, _, _, _, raw = publication()
        adapter, _ = self.adapter(compute=fault.hang)
        adapter.bind_config(config)
        adapter.observe_line(raw)
        wait_for(lambda: adapter.runner.active_pid is not None)
        with patch.object(adapter.runner, "close", side_effect=AssertionError("join on Stop")):
            adapter.stop()
        self.assertFalse(adapter.observe_line(raw))
        self.assertTrue(adapter.close())
        self.assertEqual(adapter.runner.counters["processes"], adapter.runner.counters["reaped"])

    def test_pause_summary_and_emergency_stop_revoke_admission(self):
        for event in ("user_pause", "emergency_stop", "auto_controller_summary"):
            adapter, _ = self.adapter()
            _write(_ObservedLog(io.StringIO(), adapter), event)
            self.assertTrue(adapter.stopped.is_set())

    def test_observer_faults_cannot_mask_original_logging_or_cleanup(self):
        class Broken:
            def bind_config(self, _): pass
            def observe_line(self, _): raise RuntimeError("observer")
            def stop(self): raise RuntimeError("stop")
        log = io.StringIO()
        wrapped = attach_shadow_log(log, Broken(), PolicyConfig())
        _write(wrapped, "policy_decision", test=True)
        self.assertIn('"test":true', log.getvalue())
        stop_shadow_safely(Broken())
        class BadBind(Broken):
            def bind_config(self, _): raise RuntimeError("bind")
        self.assertIs(attach_shadow_log(log, BadBind(), PolicyConfig()), log)

    def test_baseline_sink_failure_retains_accepted_exception_semantics(self):
        class FailedLog:
            def write(self, raw): raise OSError("existing log failure")
        adapter, _ = self.adapter()
        with self.assertRaisesRegex(OSError, "existing log failure"):
            _ObservedLog(FailedLog(), adapter).write("x")
        self.assertEqual(adapter.counts["admitted"], 0)

    def test_boundary_sequence_and_policy_parity_for_all_profiles(self):
        # Deliberately a seam harness, not a substitute for whole-controller C3/live acceptance.
        for profile in PlayStyle:
            with self.subTest(profile=profile.value):
                config, state, decision, fields, _ = publication(profile)
                control, observed = io.StringIO(), io.StringIO()
                adapter, _ = self.adapter()
                wrapped = attach_shadow_log(observed, adapter, config)
                traces = []
                def sequence(log):
                    trace = ["published_provider_state", "existing_capture"]
                    selected = BasicPolicyEngine(config).decide(state)
                    trace.append(("BASIC", selected))
                    _write(log, "policy_decision", **fields, trace=selected.trace)
                    trace.extend(("existing_preflight", "existing_executor", "existing_ACK", "existing_pending_owner"))
                    _write(log, "action_result", result="HARNESS_UNKNOWN", identity=None)
                    return trace
                with patch("tools.basic_auto_bot.utc_timestamp", return_value="C1_FIXED_TIME"):
                    traces.extend((sequence(control), sequence(wrapped)))
                self.assertEqual(traces[0], traces[1])
                self.assertEqual(control.getvalue(), observed.getvalue())
                self.assertEqual(traces[0].count("published_provider_state"), 1)
                self.assertEqual(traces[0].count("existing_capture"), 1)


if __name__ == "__main__":
    unittest.main()
