"""Optional warm isolated worker. No game reader or input; no caller waits.

The inherited public submit/disposition/Stop contract stays unchanged. A single
supervisor owns bounded IPC, deadline enforcement and child reaping. Healthy
pure jobs reuse one child; faults invalidate that child before any further job.
"""
from __future__ import annotations

import json
import queue
import threading
import time

from .reasoning_diagnostics import reap_child
from .reasoning_runner import (IsolatedRunner, JOB_SCHEMA, MAX_JOB_BYTES,
                               MAX_REPLY_BYTES, _reply_for, _validate_reply)


def _warm_worker(connection, cancel, compute):
    try:
        from .reasoning_snapshot import strict_json_loads
        from . import reasoning_planner  # Complete child imports before READY.
        connection.send_bytes(b"READY")
        while True:
            raw = connection.recv_bytes(MAX_JOB_BYTES)
            wire = strict_json_loads(raw.decode())
            if wire["schema"] != JOB_SCHEMA:
                raise ValueError("unsupported warm job")
            result = compute(wire, cancel)
            encoded = result if type(result) is bytes else json.dumps(
                result, separators=(",", ":"), allow_nan=False).encode()
            if len(encoded) > MAX_REPLY_BYTES:
                raise ValueError("oversize warm reply")
            connection.send_bytes(encoded)
    except EOFError:
        pass
    except Exception as exc:
        import traceback
        error = dict(schema="pokiguard.reasoning.worker_error.v1", exception=type(exc).__name__,
                     message=str(exc)[:2000], stack=traceback.format_exc(limit=12)[-16000:])
        try:
            connection.send_bytes(json.dumps(error, separators=(",", ":")).encode())
        except (OSError, EOFError):
            pass
    finally:
        connection.close()


class WarmIsolatedRunner(IsolatedRunner):
    """Opt-in alternative, leaving the accepted disposable runner untouched."""
    def __init__(self, *, diagnostics=None, compute=_reply_for):
        self.ready = threading.Event()
        self.ready_ns = self.startup_ns = None
        self.connection = self.reader = self.sender = None
        self.inbox = queue.Queue(maxsize=1)
        self.ipc_errors = []  # At most one reader and one sender failure per child.
        self.child_compute = None
        self._child_reaped = False
        super().__init__(diagnostics=diagnostics, compute=compute)

    def _drop_child(self):
        self.ready.clear()
        process = self.active_process
        if process is None:
            return True
        started = time.perf_counter_ns()
        reaped = self._child_reaped or reap_child(process)
        if reaped and not self._child_reaped and process.pid is not None:
            self.counters["reaped"] += 1
        self._child_reaped = reaped
        reader_ok = sender_ok = True
        for name in ("reader", "sender"):
            thread = getattr(self, name)
            if thread is not None:
                thread.join(.1)
                if name == "reader": reader_ok = not thread.is_alive()
                else: sender_ok = not thread.is_alive()
        if self.connection is not None:
            self.connection.close()
        ok = reaped and reader_ok and sender_ok
        if not ok:
            with self.lock:
                self.breaker.record(True, "WARM_CLEANUP_UNCONFIRMED", persistent=True)
        self.cleanups.append(dict(duration_ns=time.perf_counter_ns()-started,
            reaped=reaped, reader_reaped=reader_ok, sender_reaped=sender_ok))
        if ok:
            process.close()
            self.active_process = self.active_pid = self.connection = None
            self.reader = self.sender = None
            self.child_compute = None
        return ok

    def _start_child(self):
        if self.active_process is not None:
            if self.child_compute is self.compute and self.ready.is_set():
                return True
            if not self._drop_child():
                return False
        startup_begin = time.perf_counter_ns()
        parent, child = self.context.Pipe(duplex=True)
        self.inbox = queue.Queue(maxsize=1)
        self.ipc_errors = []
        inbox, errors = self.inbox, self.ipc_errors
        process = self.context.Process(target=_warm_worker,
            args=(child, self.context.Event(), self.compute), daemon=True)
        self.connection, self.active_process = parent, process
        self.child_compute = self.compute
        self._child_reaped = False
        try:
            process.start()
        finally:
            child.close()
        self.active_pid = process.pid
        self.counters["processes"] += 1
        def receive():
            try:
                while True:
                    raw = parent.recv_bytes(MAX_REPLY_BYTES)
                    inbox.put_nowait((raw, time.perf_counter_ns()))
            except Exception as exc:
                errors.append(exc)
        self.reader = threading.Thread(target=receive, name="reasoning-warm-ipc", daemon=True)
        self.reader.start()
        limit = time.perf_counter_ns() + 3_000_000_000
        while not self.stop_event.is_set() and time.perf_counter_ns() < limit:
            try:
                raw, _ = inbox.get_nowait()
            except queue.Empty:
                if errors: raise errors[0]
                self.stop_event.wait(.002)
                continue
            if raw != b"READY":
                raise ValueError("warm handshake corrupt")
            self.ready_ns = time.perf_counter_ns()
            self.startup_ns = self.ready_ns - startup_begin
            self.ready.set()
            return True
        return False

    def _execute_warm(self, job):
        begin = time.perf_counter_ns()
        if not self._still_current(job):
            return
        if begin >= job.deadline_ns:
            self.counters["late"] += 1
            self._publish(job, None, "DEADLINE", True)
            return
        raw = json.dumps(dict(schema=JOB_SCHEMA, job_id=job.job_id, generation=job.generation,
            binding=vars(job.binding), snapshot=job.snapshot.to_dict(), refinement=job.refinement,
            budget_ns=max(0, job.deadline_ns-time.perf_counter_ns())),
            separators=(",", ":"), allow_nan=False).encode()
        serialized = time.perf_counter_ns()
        if len(raw) > MAX_JOB_BYTES: raise ValueError("oversize warm job")
        if not self.inbox.empty(): raise ValueError("unsolicited warm reply")
        sent = threading.Event()
        connection, errors = self.connection, self.ipc_errors
        def send():
            try:
                connection.send_bytes(raw)
                sent.set()
            except Exception as exc:
                errors.append(exc)
        self.sender = threading.Thread(target=send, name="reasoning-warm-send", daemon=True)
        self.sender.start()  # Even a blocked send cannot retain the supervisor/Stop.
        while True:
            if not self._still_current(job):
                self.counters["superseded"] += 1
                self._drop_child()
                return
            if self.diagnostics is not None and self.diagnostics.buffer.disabled:
                self.breaker.record(True, "LOG_SINK_DEGRADED", persistent=True)
                self._publish(job, None, "LOG_SINK_DEGRADED")
                self._drop_child()
                return
            if time.perf_counter_ns() >= job.deadline_ns:
                self.counters["late"] += 1
                self._publish(job, None, "DEADLINE", True)
                self._drop_child()
                return
            try:
                received, arrived = self.inbox.get_nowait()
            except queue.Empty:
                if errors: raise errors[0]
                self.stop_event.wait(.002)
                continue
            reply = _validate_reply(received, job)
            validated = time.perf_counter_ns()
            if not sent.is_set() or validated >= job.deadline_ns:
                self.counters["late"] += 1
                self._publish(job, None, "DEADLINE", True)
                self._drop_child()
            else:
                self._publish(job, reply, reply.reason)
            self.timings.append(dict(serialize_ns=serialized-begin, spawn_ns=0,
                ipc_and_compute_ns=arrived-serialized, validation_ns=validated-arrived,
                compute_ns=reply.compute_ns, total_ns=validated-begin,
                job_bytes=len(raw), reply_bytes=len(received), startup_ns=self.startup_ns,
                execute_started_ns=begin, serialized_ns=serialized,
                arrived_ns=arrived, validated_ns=validated, worker_ready_ns=self.ready_ns))
            if self.sender is not None:
                self.sender.join(.1)  # Supervisor only; healthy sender has returned.
            return

    def _serve(self):
        initial = True
        try:
            while not self.stop_event.is_set():
                self.wake.wait(.002)
                self.wake.clear()
                with self.lock:
                    job, self.pending = self.pending, None
                if self.breaker.disabled:
                    continue
                if initial or job is not None:
                    initial = False
                    try:
                        if not self._start_child():
                            self._drop_child()
                            continue
                        if job is not None:
                            self.active_job = job
                            self._execute_warm(job)
                    except Exception as exc:
                        if job is not None:
                            self._publish(job, None, type(exc).__name__, True)
                            self.errors.record("warm_worker_boundary", exc, job.correlation())
                        else:
                            self.breaker.record(True, "WARM_STARTUP_FAILED", persistent=True)
                        self._drop_child()
                    finally:
                        self.active_job = None
        finally:
            self._drop_child()
            self._emit("reasoning.run_summary", {}, dict(counters=dict(self.counters),
                worker_input_sent=False, mode="OFFLINE_ONLY", warm=True), True)
