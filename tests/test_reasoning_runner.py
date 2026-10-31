from __future__ import annotations

from dataclasses import FrozenInstanceError, replace
import json
from pathlib import Path
import sys
import tempfile
import threading
import time
import unittest

from pokiguard_v2.reasoning_diagnostics import (
    BoundedDiagnostics, DiagnosticBuffer, ErrorSummaries, LogLimits, encode_event,
)
from pokiguard_v2.reasoning_runner import (
    Binding, CircuitBreaker, IsolatedRunner, _validate_reply, create_runner, deadline_ns, make_job,
)
from tools.evaluate_reasoning_planner import snapshot
from pokiguard_v2.state import GemType
from tests import reasoning_worker_fixtures as fault


def wait_for(predicate, timeout=4):
    end = time.perf_counter() + timeout
    while time.perf_counter() < end:
        if predicate():
            return True
        time.sleep(0.002)
    raise AssertionError("offline wait exceeded bound")


def job(s=None, ms=5000):
    return make_job(s or snapshot(), deadline=time.perf_counter_ns() + int(ms * 1e6))


class RunnerTests(unittest.TestCase):
    def runner(self, **kwargs):
        value = IsolatedRunner(**kwargs)
        self.addCleanup(lambda: self.assertTrue(value.close()))
        return value

    def test_disabled_does_not_start_thread_queue_or_process(self):
        before = set(threading.enumerate())
        self.assertIsNone(create_runner(enabled=False))
        self.assertEqual(set(threading.enumerate()), before)

    def test_immutable_job_and_detached_snapshot(self):
        j = job()
        with self.assertRaises(FrozenInstanceError):
            j.generation = 1
        self.assertIsInstance(j.binding, Binding)
        self.assertEqual(json.loads(j.binding.source_json), j.snapshot.source.to_dict())

    def test_invalid_observed_board_and_forged_binding_never_form_jobs(self):
        s = snapshot()
        board = list(s.board)
        row = list(board[0])
        row[0] = (GemType.UNKNOWN.value, None)
        board[0] = tuple(row)
        with self.assertRaises(ValueError):
            job(replace(s, board=tuple(board)))
        j = job(s)
        with self.assertRaises(ValueError):
            replace(j, binding=replace(j.binding, config_hash="0"*64))

    def test_real_r1_worker_matches_completed_planner(self):
        from pokiguard_v2.reasoning_planner import plan
        r, j = self.runner(), job()
        expected = plan(j.snapshot)
        self.assertTrue(r.submit(j))
        wait_for(lambda: r.outcome is not None)
        d = r.disposition(j, current_binding=j.binding)
        self.assertEqual(d.action, expected.proposal or j.snapshot.baseline)
        self.assertEqual(d.used_proposal, expected.proposal is not None)
        self.assertFalse(d.input_authority)
        self.assertTrue(d.existing_preflight_required)
        self.assertTrue(r.close())
        self.assertTrue(all(x["reaped"] and x["reader_reaped"] for x in r.cleanups))

    def test_real_refinement_keeps_r1_and_r2_disabled(self):
        from pokiguard_v2.reasoning_planner import plan
        j = replace(job(), refinement=True)
        r = self.runner()
        self.assertTrue(r.submit(j))
        wait_for(lambda: r.outcome is not None)
        self.assertIsNotNone(r.outcome[0])
        self.assertFalse(r.outcome[0].r2_promotion)
        self.assertEqual(r.disposition(j, current_binding=j.binding).action,
                         plan(j.snapshot).proposal or j.snapshot.baseline)

    def test_decision_attribution_and_final_watermark_are_written_without_input_claim(self):
        with tempfile.TemporaryDirectory() as folder:
            d = BoundedDiagnostics(Path(folder))
            r, j = self.runner(diagnostics=d), job()
            self.assertTrue(r.submit(j))
            wait_for(lambda: r.outcome is not None)
            self.assertIsNotNone(r.outcome[0])
            self.assertTrue(r.close())
            self.assertTrue(d.flush())
            self.assertTrue(d.close())
            records = [json.loads(line) for file in Path(folder).glob('*.jsonl')
                       for line in file.read_text(encoding='utf-8').splitlines()]
            decision = next(x for x in records if x['event_type'] == 'reasoning.decision')
            summary = decision['payload']['summary']
            self.assertEqual(summary['baseline_candidate_id'], j.snapshot.candidate_id(j.snapshot.baseline))
            self.assertLessEqual(len(summary['candidates']), 6)
            self.assertFalse(summary['worker_input_sent'])
            self.assertEqual(summary['controller_input_sent'], 'NOT_PUBLISHED')
            self.assertIsNone(summary['dispatched_candidate_id'])
            self.assertTrue(any(x['event_type'] == 'reasoning.run_summary' for x in records))
            self.assertEqual(d.buffer.stats()['enqueued'], d.buffer.stats()['written'])

    def test_fault_variants_retain_baseline_without_input(self):
        for fn in (fault.crash, fault.corrupt, fault.oversize, fault.nonfinite, fault.mismatch, fault.raises):
            with self.subTest(fault=fn.__name__):
                r, j = self.runner(compute=fn), job()
                self.assertTrue(r.submit(j))
                wait_for(lambda: r.outcome is not None)
                d = r.disposition(j, current_binding=j.binding)
                self.assertEqual(d.action, j.snapshot.baseline)
                self.assertFalse(d.used_proposal)
                self.assertEqual(r.counters["faults"], 1)
                self.assertTrue(r.close())

    def test_hang_deadline_does_not_wait_for_cleanup(self):
        r, j = self.runner(compute=fault.hang), job(ms=250)
        self.assertTrue(r.submit(j))
        d = r.disposition(j, current_binding=j.binding, now_ns=j.deadline_ns)
        self.assertEqual(d.reason, "DEADLINE")
        self.assertEqual(d.action, j.snapshot.baseline)
        wait_for(lambda: r.outcome is not None)
        self.assertTrue(r.close())
        self.assertEqual(r.counters["late"], 1)

    def test_latest_pending_replaces_without_fifo_or_stale_acceptance(self):
        r = self.runner(compute=fault.cooperative)
        first, second, third = job(), job(), job()
        self.assertTrue(r.submit(first))
        wait_for(lambda: r.active_pid is not None)
        self.assertTrue(r.submit(second))
        self.assertTrue(r.submit(third))
        self.assertGreaterEqual(r.counters["replaced_pending"], 1)
        self.assertIsNone(r.disposition(first, current_binding=first.binding).action)
        self.assertIsNone(r.disposition(second, current_binding=second.binding).action)
        self.assertEqual(r.current, third)
        self.assertTrue(r.close())
        self.assertLessEqual(r.counters["processes"], 2)

    def test_duplicate_job_id_does_not_start_retry_or_reset_deadline(self):
        r, j = self.runner(compute=fault.cooperative), job()
        self.assertTrue(r.submit(j))
        self.assertFalse(r.submit(j))
        self.assertEqual(r.counters["submitted"], 1)
        self.assertEqual(r.current.deadline_ns, j.deadline_ns)

    def test_cancel_stop_invalid_state_and_after_input_never_fallback_input(self):
        r, j = self.runner(compute=fault.hang), job()
        r.submit(j)
        self.assertIsNone(r.disposition(j, current_binding=j.binding, state_valid=False).action)
        other = replace(j.binding, config_hash="0" * 64)
        self.assertIsNone(r.disposition(j, current_binding=other).action)
        self.assertIsNone(r.disposition(j, current_binding=j.binding, input_sent=True).action)
        r.invalidate()
        self.assertIsNone(r.disposition(j, current_binding=j.binding).action)
        r.stop()
        self.assertIsNone(r.disposition(j, current_binding=j.binding).action)
        self.assertFalse(r.submit(job()))

    def test_submit_and_disposition_do_not_wait_for_supervisor_lock(self):
        r, j = self.runner(compute=fault.retain), job()
        r.lock.acquire()
        try:
            self.assertFalse(r.submit(j))
            self.assertEqual(r.disposition(j, current_binding=j.binding).reason, "RUNNER_BUSY")
            r.invalidate()
            r.stop()
        finally:
            r.lock.release()

    def test_invalid_clock_does_not_authorize_baseline_or_proposal(self):
        r, j = self.runner(compute=fault.retain), job()
        r.submit(j)
        for stamp in (float("nan"), float("inf"), j.created_ns-1):
            self.assertIsNone(r.disposition(j, current_binding=j.binding, now_ns=stamp).action)

    def test_reply_rejects_unsafe_format_and_mismatched_identity(self):
        j = job()
        wire = dict(job_id=j.job_id, generation=j.generation, binding=vars(j.binding))
        base = fault.retain(wire, None)
        variants = [dict(base, schema="future"), dict(base, input_authority=True),
                    dict(base, r2_promotion=True), dict(base, compute_ns=True),
                    dict(base, generation=j.generation+1), dict(base, reason=3),
                    dict(base, disposition="USE_CANDIDATE"),
                    dict(base, proposal=dict(family="swap", move=[[0, 0], [7, 7]], card_source=None))]
        for raw in variants:
            with self.assertRaises((ValueError, RuntimeError)):
                _validate_reply(json.dumps(raw).encode(), j)


class BudgetAndBreakerTests(unittest.TestCase):
    def test_absolute_budget_age_cap_minimum_and_early_finish(self):
        now = 10_000_000_000
        common = dict(observed_ns=now-800_000_000, slice_started_ns=now, now_ns=now, reserve_ms=1000)
        self.assertEqual(deadline_ns(remaining_ms=12000, **common), now+4_000_000_000)
        self.assertEqual(deadline_ns(remaining_ms=2200, **common), now+150_000_000)
        self.assertIsNone(deadline_ns(remaining_ms=2050, **common))
        self.assertIsNone(deadline_ns(remaining_ms=float("nan"), **common))
        self.assertIsNone(deadline_ns(remaining_ms=12000, configured_ms=6001, **common))
        older = dict(common, slice_started_ns=now-3_000_000_000)
        self.assertEqual(deadline_ns(remaining_ms=12000, **older), now+1_000_000_000)

    def test_three_consecutive_and_five_in_twenty_faults(self):
        b = CircuitBreaker()
        for _ in range(2):
            b.record(True)
            self.assertFalse(b.disabled)
        b.record(True)
        self.assertTrue(b.disabled)
        b = CircuitBreaker()
        for _ in range(4):
            b.record(True)
            b.record(False)
            self.assertFalse(b.disabled)
        b.record(True)
        self.assertTrue(b.disabled)

    def test_rolling_window_and_persistent_failure(self):
        b = CircuitBreaker()
        b.record(True)
        for _ in range(20):
            b.record(False)
        self.assertEqual(sum(b.window), 0)
        b.record(True, "SINK_DISABLED", persistent=True)
        self.assertTrue(b.disabled)
        self.assertEqual(b.reason, "SINK_DISABLED")


class DiagnosticsTests(unittest.TestCase):
    def test_bounded_count_bytes_priority_and_accounting(self):
        b = DiagnosticBuffer(LogLimits(records=4, bytes=100, reserved_records=1,
            reserved_bytes=20, event_bytes=50))
        for _ in range(3):
            self.assertTrue(b.enqueue(b"x\n"))
        self.assertFalse(b.enqueue(b"x\n"))
        self.assertTrue(b.enqueue(b"x\n", critical=True))
        self.assertFalse(b.enqueue(b"x\n", critical=True))
        self.assertFalse(b.enqueue(b"x" * 51+b"\n"))
        raw = b.take()
        b.finish(raw, written=True)
        b.disable("INJECTED")
        self.assertTrue(b.stats()["accounting_valid"])
        self.assertEqual(b.stats()["written"], 1)
        self.assertEqual(b.stats()["discarded_after_enqueue"], 3)

    def test_byte_cap_includes_inflight_record(self):
        b = DiagnosticBuffer(LogLimits(records=10, bytes=20, reserved_records=0,
            reserved_bytes=0, event_bytes=20))
        self.assertTrue(b.enqueue(b"123456789\n"))
        raw = b.take()
        self.assertTrue(b.enqueue(b"123456789\n"))
        self.assertFalse(b.enqueue(b"x\n"))
        b.finish(raw, failed=True)
        self.assertTrue(b.stats()["accounting_valid"])

    def test_lock_busy_is_counted_and_nonblocking(self):
        b = DiagnosticBuffer()
        b.lock.acquire()
        try:
            self.assertFalse(b.enqueue(b"{}\n"))
        finally:
            b.lock.release()
        self.assertEqual(b.stats()["lock_busy"], 1)
        self.assertTrue(b.stats()["accounting_valid"])

    def test_oversize_event_is_valid_truncated_json_not_cut_json(self):
        raw = encode_event("reasoning.decision", 1, {}, dict(tree="x"*100000))
        value = json.loads(raw)
        self.assertTrue(value["payload"]["truncated"])
        self.assertLessEqual(len(raw), 16384)

    def test_error_first_stack_repeat_summary_and_cardinality(self):
        emitted, now = [], [0]
        errors = ErrorSummaries(lambda *args: emitted.append(args), clock=lambda: now[0])
        exc = ValueError("injected")
        for _ in range(1000):
            errors.record("same", exc, dict(job_id="j", source="s"))
        self.assertEqual(len(emitted), 1)
        self.assertIn("stack", emitted[0][2])
        self.assertEqual(errors.aggregated, 999)
        now[0] = 31
        errors.record("same", exc, {})
        self.assertNotIn("stack", emitted[-1][2])
        for i in range(100):
            errors.record(str(i), exc, {})
        self.assertEqual(len(errors.signatures), 64)
        self.assertGreater(errors.overflow, 0)

    def test_real_writer_rotation_retention_and_ack_accounting(self):
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder)
            old = root / "reasoning.000.jsonl"
            old.write_text("{}\n")
            import os
            os.utime(old, (1, 1))
            d = BoundedDiagnostics(root, limits=LogLimits(file_bytes=32768, files=2))
            try:
                raw = b'{"padding":"'+b"x"*15900+b'"}\n'
                for _ in range(10):
                    self.assertTrue(d.enqueue(raw))
                self.assertTrue(d.flush())
                self.assertFalse(old.exists())
                self.assertLessEqual(len(list(root.glob("reasoning.*.jsonl"))), 2)
                self.assertTrue(all(p.stat().st_size <= 32768 for p in root.glob("*.jsonl")))
                self.assertEqual(d.buffer.stats()["written"], 10)
            finally:
                self.assertTrue(d.close())
            self.assertTrue(d.buffer.stats()["accounting_valid"])

    def test_write_failures_and_hang_cleanup_are_bounded(self):
        for fn in (fault.log_denied, fault.log_disk_full, fault.log_hang, fault.log_crash):
            with self.subTest(fault=fn.__name__), tempfile.TemporaryDirectory() as folder:
                d = BoundedDiagnostics(Path(folder), writer_target=fn)
                self.assertTrue(d.enqueue(b"{}\n"))
                if fn is not fault.log_hang:
                    wait_for(lambda: d.buffer.disabled)
                    self.assertEqual(d.buffer.stats()["written"], 0)
                    self.assertEqual(d.buffer.stats()["failed_write"], 1)
                self.assertTrue(d.close())
                self.assertTrue(d.buffer.stats()["accounting_valid"])

    def test_full_diagnostic_queue_retains_baseline_and_reports_loss(self):
        with tempfile.TemporaryDirectory() as folder:
            d = BoundedDiagnostics(Path(folder), writer_target=fault.log_hang,
                limits=LogLimits(records=1, reserved_records=0))
            r = IsolatedRunner(diagnostics=d, compute=fault.retain)
            try:
                first, second = job(), job()
                r.submit(first)
                wait_for(lambda: r.outcome is not None)
                wait_for(lambda: r.active_job is None)
                r.submit(second)
                wait_for(lambda: r.outcome is not None)
                self.assertEqual(r.disposition(second, current_binding=second.binding).action, second.snapshot.baseline)
                self.assertEqual(r.outcome[1], "LOG_QUEUE_DEGRADED")
                self.assertGreater(d.buffer.stats()["dropped_before_enqueue"], 0)
            finally:
                self.assertTrue(r.close())
                self.assertTrue(d.close())

    def test_known_sink_failure_returns_baseline_and_disables_reasoning(self):
        with tempfile.TemporaryDirectory() as folder:
            d = BoundedDiagnostics(Path(folder), writer_target=fault.log_denied)
            r = IsolatedRunner(diagnostics=d, compute=fault.retain)
            j = job()
            try:
                self.assertTrue(r.submit(j))
                wait_for(lambda: d.buffer.disabled)
                self.assertEqual(r.disposition(j, current_binding=j.binding).action, j.snapshot.baseline)
                self.assertEqual(r.disposition(j, current_binding=j.binding).reason, "LOG_SINK_DEGRADED")
            finally:
                self.assertTrue(r.close())
                self.assertTrue(d.close())

    def test_actual_writer_startup_error_preserves_reason_without_retry(self):
        with tempfile.TemporaryDirectory() as folder:
            blocked = Path(folder)/"not-a-directory"
            blocked.write_text("fixture")
            d = BoundedDiagnostics(blocked)
            try:
                wait_for(lambda: d.buffer.disabled)
                self.assertIn("FileExistsError", d.buffer.failure)
                self.assertEqual(d.buffer.stats()["written"], 0)
            finally:
                self.assertTrue(d.close())


if __name__ == "__main__":
    unittest.main()
