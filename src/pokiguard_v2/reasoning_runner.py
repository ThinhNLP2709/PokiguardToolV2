"""Phase 5B.4 OFFLINE runner. No production wiring, game reads, or input authority.

The host submits/inspects without waiting. A supervisor owns spawn, serialization,
IPC and cleanup. One disposable compute process prevents a hung Python planner
from retaining the controller; at most one active and one latest pending job.
"""
from __future__ import annotations

from collections import deque
from dataclasses import dataclass
import json
import math
import multiprocessing as mp
import threading
import time
import uuid

from .reasoning_diagnostics import ErrorSummaries, encode_event, reap_child


JOB_SCHEMA = "pokiguard.reasoning.job.v1"
REPLY_SCHEMA = "pokiguard.reasoning.reply.v2"
MAX_JOB_BYTES = 256 * 1024
MAX_REPLY_BYTES = 32 * 1024


def deadline_ns(*, observed_ns: int, remaining_ms: float, slice_started_ns: int,
                now_ns: int, reserve_ms: float, uncertainty_ms: float = 150,
                return_margin_ms: float = 100, configured_ms: float = 4000) -> int | None:
    """Pure A3 formula. Caller must supply verified timing/reserve evidence.

    None means no job. This never changes the accepted BASIC timer predicate.
    """
    values = (remaining_ms, reserve_ms, uncertainty_ms, return_margin_ms, configured_ms)
    if (any(type(x) not in (int, float) or not math.isfinite(x) or x < 0 for x in values)
            or any(type(x) is not int or x < 0 for x in (observed_ns, slice_started_ns, now_ns))
            or observed_ns > now_ns or slice_started_ns > now_ns or configured_ms > 6000):
        return None
    limit = min(slice_started_ns + int(configured_ms * 1e6),
                slice_started_ns + 6_000_000_000,
                observed_ns + int((remaining_ms - uncertainty_ms - reserve_ms - return_margin_ms) * 1e6))
    return limit if limit - now_ns >= 50_000_000 else None


@dataclass(frozen=True)
class Binding:
    snapshot_id: str
    config_hash: str
    source_json: str
    profile: str
    clock_domain: str = "host.perf_counter_ns"

    def __post_init__(self):
        from .reasoning_snapshot import PROFILES, SourceIdentity, strict_json_loads
        for value in (self.snapshot_id, self.config_hash):
            if type(value) is not str or len(value) != 64 or any(c not in "0123456789abcdef" for c in value):
                raise ValueError("SHA-256 binding required")
        if type(self.source_json) is not str or len(self.source_json) > 4096:
            raise ValueError("invalid source identity")
        SourceIdentity.from_dict(strict_json_loads(self.source_json))
        if self.profile not in PROFILES or self.clock_domain != "host.perf_counter_ns":
            raise ValueError("unsupported profile/clock domain")


@dataclass(frozen=True)
class RunnerJob:
    job_id: str
    generation: int
    binding: Binding
    snapshot: object
    created_ns: int
    deadline_ns: int
    refinement: bool = False

    def __post_init__(self):
        from .reasoning_snapshot import ReasoningSnapshot, canonical_json
        if (type(self.snapshot) is not ReasoningSnapshot or type(self.binding) is not Binding
                or type(self.generation) is not int or self.generation < 0
                or type(self.job_id) is not str or not 1 <= len(self.job_id) <= 128
                or type(self.created_ns) is not int or type(self.deadline_ns) is not int
                or not 0 < self.deadline_ns - self.created_ns <= 6_000_000_000
                or type(self.refinement) is not bool):
            raise ValueError("invalid immutable job")
        self.snapshot.board_state()
        if (self.binding.snapshot_id != self.snapshot.snapshot_id
                or self.binding.config_hash != self.snapshot.intent.config_hash
                or self.binding.source_json != canonical_json(self.snapshot.source.to_dict())
                or self.binding.profile != self.snapshot.intent.profile):
            raise ValueError("job source/config/snapshot binding mismatch")

    def correlation(self):
        return dict(job_id=self.job_id, job_generation=self.generation,
                    snapshot_id=self.binding.snapshot_id, config_hash=self.binding.config_hash,
                    source=json.loads(self.binding.source_json), profile=self.binding.profile,
                    clock_domain=self.binding.clock_domain,
                    provenance=self.snapshot.provenance.to_dict(),
                    versions=self.snapshot.intent.versions.plain())

    def candidate_id(self, action):
        from .reasoning_snapshot import digest
        return digest(dict(snapshot_id=self.binding.snapshot_id, action=action.to_dict()))


def make_job(snapshot, *, deadline: int, generation=0, refinement=False) -> RunnerJob:
    """Offline immutable preparation; hashing cost is measured separately from enqueue."""
    from .reasoning_snapshot import canonical_json
    binding = Binding(snapshot.snapshot_id, snapshot.intent.config_hash,
                      canonical_json(snapshot.source.to_dict()), snapshot.intent.profile)
    return RunnerJob(uuid.uuid4().hex, generation, binding, snapshot,
                     time.perf_counter_ns(), deadline, refinement)


@dataclass(frozen=True)
class Reply:
    proposal: object | None
    disposition: str
    reason: str
    compute_ns: int
    summary_json: str = "{}"
    r2_promotion: bool = False


@dataclass(frozen=True)
class Disposition:
    action: object | None
    reason: str
    used_proposal: bool = False
    input_authority: bool = False
    existing_preflight_required: bool = True


class CircuitBreaker:
    def __init__(self):
        self.window = deque(maxlen=20)
        self.consecutive = 0
        self.disabled = False
        self.reason = None

    def record(self, fault: bool, reason="", *, persistent=False):
        self.window.append(bool(fault))
        self.consecutive = self.consecutive + 1 if fault else 0
        if persistent or self.consecutive >= 3 or sum(self.window) >= 5:
            self.disabled, self.reason = True, reason or "FAULT_THRESHOLD"


def _decision_summary(snapshot, result, refinement):
    """Compact attribution, never a dispatched-action or survival claim."""
    from .reasoning_snapshot import digest
    baseline_id = snapshot.candidate_id(snapshot.baseline)
    proposal_id = None if result.proposal is None else snapshot.candidate_id(result.proposal)
    chosen = []
    for cid in (baseline_id, proposal_id, *(x.candidate_id for x in result.scores[:3])):
        if cid is not None and cid not in chosen:
            chosen.append(cid)
    by_id = {x.candidate_id:x for x in result.scores}
    candidates = []
    for cid in chosen:
        score = by_id.get(cid)
        if score is None:
            candidates.append(dict(candidate_id=cid, action=snapshot.baseline.to_dict(),
                                   status="BASELINE_NOT_SCORED", utility=None))
            continue
        details = score.details.plain()
        ledger = details.get("ledger", {})
        candidates.append(dict(candidate_id=cid, action=score.action.to_dict(),
            status="R1_PROXY_ONLY", utility=score.utility.to_dict(), bucket=score.bucket,
            evidence_rank=score.evidence_rank,
            features={k:v.to_dict() for k,v in score.features},
            contributions={k:[v.low,v.high] for k,v in score.contributions},
            ledger=dict(digest=digest(ledger), totals=ledger.get("totals"),
                        dedup_cells=len(ledger.get("original_cells", [])), coverage=ledger.get("coverage")),
            resources=details.get("resources"), certificate=details.get("certificate"),
            boss_reply_count=details.get("boss_reply_count"),
            boss_reply_coverage=details.get("boss_reply_coverage"),
            future_setup="NOT_PROMOTED", actual_damage_survival="UNSUPPORTED"))
    summary = dict(baseline_candidate_id=baseline_id, proposed_candidate_id=proposal_id,
        dispatched_candidate_id=None, evaluated_count=len(result.scores), candidates=candidates,
        omitted_candidate_summaries=max(0,len(result.scores)-len(candidates)),
        refinement=refinement, controller_input_sent="NOT_PUBLISHED", worker_input_sent=False,
        dispatch_preflight_ack="NOT_MEASURED", mode="OFFLINE_ONLY")
    d2 = snapshot.recorded.plain().get('d2_actions')
    if d2 is not None:
        summary.update(action_scope=d2['version'], conditional_perfect=d2.get('conditional_perfect',True),
            effects_excluded=d2['exclusions'], settings_are_advisory=True,
            family_eligibility=[dict(family=c['action']['family'],eligible=c['eligible'],reason=c['reason'])
                for c in d2['choices'] if c['action']['family']!='swap'])
        geometry = d2.get('perfect_geometry')
        if geometry is None:geometry=d2.get('seal_geometry')
        summary['skill_model_source'] = None if geometry is None else geometry['scope']
    # Keep baseline/proposal attribution if alternatives exceed the event budget.
    while len(json.dumps(summary, separators=(",", ":")).encode()) > 12000 and len(candidates) > 2:
        candidates.pop()
        summary["omitted_candidate_summaries"] += 1
    return summary


def _reply_for(wire, cancel):
    """Child-only imports. R2 remains diagnostics and cannot change the R1 proposal."""
    from .reasoning_snapshot import ReasoningSnapshot
    from .reasoning_planner import plan
    start = time.perf_counter_ns()
    snapshot = ReasoningSnapshot.from_dict(wire["snapshot"])
    binding = wire["binding"]
    from .reasoning_snapshot import canonical_json
    if (snapshot.snapshot_id != binding["snapshot_id"] or snapshot.intent.config_hash != binding["config_hash"]
            or canonical_json(snapshot.source.to_dict()) != binding["source_json"]
            or snapshot.intent.profile != binding["profile"] or binding["clock_domain"] != "host.perf_counter_ns"):
        raise ValueError("snapshot/config binding mismatch")
    result = plan(snapshot)
    refinement = None
    if wire["refinement"] and not cancel.is_set():
        from .reasoning_refinement import Limits, refine
        local_deadline = time.perf_counter_ns() / 1e6 + max(0, wire["budget_ns"] - (time.perf_counter_ns() - start)) / 1e6
        refined = refine(snapshot, result, Limits(deadline_ms=local_deadline),
                         clock=lambda: time.perf_counter_ns()/1e6, cancelled=cancel.is_set)
        refinement = dict(incumbent_usable=refined.incumbent_usable,
                          r2_promotion=False, status=refined.diagnostics.plain().get("reason"))
        if not refined.incumbent_usable:
            raise ValueError("unbound refinement incumbent")
    return dict(schema=REPLY_SCHEMA, job_id=wire["job_id"], generation=wire["generation"],
                binding=binding, disposition="USE_CANDIDATE" if result.proposal is not None else "RETAIN_BASELINE", reason=result.reason,
                proposal=None if result.proposal is None else result.proposal.to_dict(),
                compute_ns=time.perf_counter_ns() - start, input_authority=False,
                r2_promotion=False, summary=_decision_summary(snapshot, result, refinement))


def _worker(connection, cancel, raw: bytes, compute):
    try:
        from .reasoning_snapshot import strict_json_loads
        wire = strict_json_loads(raw.decode())
        if wire["schema"] != JOB_SCHEMA:
            raise ValueError("unsupported job schema")
        connection.send_bytes(b"READY")
        result = compute(wire, cancel)
        encoded = result if type(result) is bytes else json.dumps(result, separators=(",", ":"), allow_nan=False).encode()
        connection.send_bytes(encoded)
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


def _validate_reply(raw: bytes, job: RunnerJob) -> Reply:
    from .reasoning_snapshot import Action, strict_json_loads
    if len(raw) > MAX_REPLY_BYTES:
        raise ValueError("oversize reply")
    value = strict_json_loads(raw.decode())
    if isinstance(value, dict) and value.get("schema") == "pokiguard.reasoning.worker_error.v1":
        raise RuntimeError(json.dumps(value, ensure_ascii=False))
    expected = {"schema", "job_id", "generation", "binding", "disposition", "reason", "proposal",
                "compute_ns", "input_authority", "r2_promotion", "summary"}
    if (type(value) is not dict or set(value) != expected or value["schema"] != REPLY_SCHEMA
            or value["job_id"] != job.job_id or type(value["generation"]) is not int or value["generation"] != job.generation
            or value["binding"] != vars(job.binding) or value["input_authority"] is not False
            or value["r2_promotion"] is not False or type(value["compute_ns"]) is not int
            or value["compute_ns"] < 0 or type(value["reason"]) is not str
            or len(value["reason"]) > 2048 or type(value["summary"]) is not dict
            or value["disposition"] not in {"USE_CANDIDATE", "RETAIN_BASELINE"}):
        raise ValueError("malformed or mismatched worker reply")
    action = None if value["proposal"] is None else Action.from_dict(value["proposal"])
    if (value["disposition"] == "USE_CANDIDATE") != (action is not None):
        raise ValueError("inconsistent proposal disposition")
    if action is not None:
        from .reasoning_full_action_planner import VERSION as full_action_version
        from .reasoning_mega import VERSION as mega_action_version
        action_version=job.snapshot.recorded.plain().get('d2_actions', {}).get('version')
        if action.family not in {"swap", "cast", "pet_skill"} and not (
                action.family == 'pass' and (action_version==full_action_version or
                    (action_version==mega_action_version and job.binding.profile=='mega_icarus_spam_skill'))):
            raise ValueError("unsupported proposal family")
        if action.move and (any(not 0 <= n < 8 for p in (action.move.first, action.move.second) for n in p)
                            or sum(abs(a-b) for a, b in zip(action.move.first, action.move.second)) != 1):
            raise ValueError("invalid proposal coordinates")
    summary = value["summary"]
    if summary:
        if (summary.get("baseline_candidate_id") != job.candidate_id(job.snapshot.baseline)
                or summary.get("proposed_candidate_id") != (None if action is None else job.candidate_id(action))
                or summary.get("dispatched_candidate_id") is not None
                or summary.get("worker_input_sent") is not False
                or summary.get("controller_input_sent") != "NOT_PUBLISHED" or summary.get("mode") != "OFFLINE_ONLY"
                or type(summary.get("candidates")) is not list or len(summary["candidates"]) > 6):
            raise ValueError("invalid decision attribution")
        for candidate in summary["candidates"]:
            if (type(candidate) is not dict or candidate.get("candidate_id") !=
                    job.candidate_id(Action.from_dict(candidate.get("action")))):
                raise ValueError("candidate attribution mismatch")
    elif action is not None:
        raise ValueError("proposal missing decision attribution")
    return Reply(action, value["disposition"], value["reason"], value["compute_ns"],
                 json.dumps(summary, separators=(",", ":"), allow_nan=False))


class IsolatedRunner:
    def __init__(self, *, diagnostics=None, compute=_reply_for):
        self.lock = threading.Lock()
        self.wake = threading.Event()
        self.stop_event = threading.Event()
        self.invalidated = threading.Event()
        self.context = mp.get_context("spawn")
        self.diagnostics, self.compute = diagnostics, compute
        self.pending = self.current = self.outcome = None
        self.active_job = self.active_process = None
        self.active_pid = None
        self.breaker = CircuitBreaker()
        self.counters = dict(submitted=0, replaced_pending=0, superseded=0, completed=0,
                             faults=0, late=0, rejected=0, processes=0, reaped=0,
                             stale_discarded=0, log_dropped=0)
        self.timings = deque(maxlen=1024)
        self.cleanups = deque(maxlen=1024)
        self.error_sequence = 0
        self.errors = ErrorSummaries(self._emit)
        self.thread = threading.Thread(target=self._serve, name="reasoning-supervisor", daemon=True)
        self.thread.start()

    def submit(self, job: RunnerJob) -> bool:
        if type(job) is not RunnerJob:
            return False
        if not self.lock.acquire(blocking=False):
            return False
        try:
            if self.stop_event.is_set() or self.breaker.disabled or time.perf_counter_ns() >= job.deadline_ns:
                self.counters["rejected"] += 1
                return False
            if self.current is not None and self.current.job_id == job.job_id:
                self.counters["rejected"] += 1
                return False
            self.counters["replaced_pending"] += self.pending is not None
            self.pending, self.current, self.outcome = job, job, None
            self.invalidated.clear()
            self.counters["submitted"] += 1
            self.wake.set()
            return True
        finally:
            self.lock.release()

    def disposition(self, job: RunnerJob, *, current_binding: Binding | None,
                    state_valid=True, input_sent=False, now_ns=None) -> Disposition:
        # All output is advisory; caller retains its existing preflight/ACK owner.
        if input_sent is not False:
            return Disposition(None, "INPUT_ALREADY_SENT")
        if state_valid is not True or current_binding != job.binding:
            return Disposition(None, "SOURCE_OR_STATE_INVALID")
        if self.stop_event.is_set():
            return Disposition(None, "STOPPED")
        if self.invalidated.is_set():
            return Disposition(None, "INVALIDATED")
        now = time.perf_counter_ns() if now_ns is None else now_ns
        if type(now) is not int or now < job.created_ns:
            return Disposition(None, "CLOCK_INVALID")
        fallback = job.snapshot.baseline
        if not self.lock.acquire(blocking=False):
            return Disposition(fallback, "RUNNER_BUSY")
        try:
            if self.current is None or self.current.job_id != job.job_id:
                return Disposition(None, "JOB_SUPERSEDED_OR_NOT_SUBMITTED")
            if self.diagnostics is not None and self.diagnostics.buffer.disabled:
                return Disposition(fallback, "LOG_SINK_DEGRADED")
            if self.breaker.disabled:
                return Disposition(fallback, self.breaker.reason or "BREAKER_OPEN")
            if now >= job.deadline_ns:
                return Disposition(fallback, "DEADLINE")
            if self.outcome is None:
                return Disposition(fallback, "NOT_READY")
            reply, reason = self.outcome
            if reply is None:
                return Disposition(fallback, reason)
            return Disposition(reply.proposal if reply.proposal is not None else fallback,
                               reply.reason, reply.proposal is not None)
        finally:
            self.lock.release()

    def invalidate(self):
        self.invalidated.set()
        self.wake.set()

    def stop(self):
        self.stop_event.set()
        self.wake.set()

    def close(self, timeout=1.3):
        self.stop()
        self.thread.join(timeout)
        return not self.thread.is_alive() and self.counters["processes"] == self.counters["reaped"]

    def _emit(self, event, correlation, payload, critical=False):
        if self.diagnostics is None:
            return True
        self.error_sequence += 1
        try:
            raw = encode_event(event, self.error_sequence, correlation, payload)
            if not self.diagnostics.enqueue(raw, critical=critical):
                self.counters["log_dropped"] += 1
                return False
            return True
        except Exception:
            self.counters["log_dropped"] += 1
            return False

    def _publish(self, job, reply, reason, fault=False):
        logged = self._emit("reasoning.fallback" if reply is None else "reasoning.decision", job.correlation(),
                   dict(reason=reason, disposition=None if reply is None else reply.disposition,
                        compute_ns=None if reply is None else reply.compute_ns,
                        baseline_action=job.snapshot.baseline.to_dict(),
                        baseline_candidate_id=job.candidate_id(job.snapshot.baseline),
                        proposal_action=None if reply is None or reply.proposal is None else reply.proposal.to_dict(),
                        summary=None if reply is None else json.loads(reply.summary_json),
                        worker_input_sent=False, controller_input_sent="NOT_PUBLISHED",
                        mode="OFFLINE_ONLY", r2_promotion=False), reply is None)
        if not logged:
            reply, reason, fault = None, "LOG_QUEUE_DEGRADED", True
        with self.lock:
            if self.current is None or self.current.job_id != job.job_id or self.stop_event.is_set() or self.invalidated.is_set():
                self.counters["stale_discarded"] += 1
                return
            self.outcome = (reply, reason)
            if fault:
                self.counters["faults"] += 1
                self.breaker.record(True, reason)
            elif reply is not None:
                self.counters["completed"] += 1
                self.breaker.record(False)

    def _still_current(self, job):
        with self.lock:
            return not self.stop_event.is_set() and not self.invalidated.is_set() and self.current is not None and self.current.job_id == job.job_id

    def _execute(self, job):
        parent, child = self.context.Pipe(duplex=False)
        process = None
        cancel = self.context.Event()
        begin = time.perf_counter_ns()
        received_box = []
        started_box = []
        reader = None

        def receive():
            try:
                first = parent.recv_bytes(MAX_REPLY_BYTES)
                if first != b"READY":
                    raise ValueError("worker handshake corrupt")
                started_box.append(time.perf_counter_ns())
                received_box.append((parent.recv_bytes(MAX_REPLY_BYTES), None, time.perf_counter_ns()))
            except Exception as exc:
                received_box.append((None, exc, time.perf_counter_ns()))
        try:
            raw = json.dumps(dict(schema=JOB_SCHEMA, job_id=job.job_id, generation=job.generation,
                binding=vars(job.binding), snapshot=job.snapshot.to_dict(), refinement=job.refinement,
                budget_ns=max(0, job.deadline_ns - time.perf_counter_ns())),
                separators=(",", ":"), allow_nan=False).encode()
            serialized = time.perf_counter_ns()
            if len(raw) > MAX_JOB_BYTES:
                raise ValueError("oversize job")
            if not self._still_current(job):
                return
            process = self.context.Process(target=_worker, args=(child, cancel, raw, self.compute), daemon=True)
            process.start()
            child.close()
            self.active_process = process
            self.active_pid = process.pid
            self.counters["processes"] += 1
            spawned = time.perf_counter_ns()
            reader = threading.Thread(target=receive, name="reasoning-ipc", daemon=True)
            reader.start()
            while True:
                if not self._still_current(job):
                    self.counters["superseded"] += 1
                    self._emit("reasoning.discard", job.correlation(), dict(reason="STOP_CANCEL_OR_SUPERSEDED"), True)
                    return
                if self.diagnostics is not None and self.diagnostics.buffer.disabled:
                    with self.lock:
                        self.breaker.record(True, "LOG_SINK_DEGRADED", persistent=True)
                    self._publish(job, None, "LOG_SINK_DEGRADED")
                    return
                now = time.perf_counter_ns()
                if now >= job.deadline_ns:
                    self.counters["late"] += 1
                    self._publish(job, None, "DEADLINE", True)
                    return
                if received_box:
                    received, error, arrived = received_box[0]
                    if error is not None:
                        raise error
                    reply = _validate_reply(received, job)
                    validated = time.perf_counter_ns()
                    if validated >= job.deadline_ns:
                        self.counters["late"] += 1
                        self._publish(job, None, "DEADLINE", True)
                    else:
                        self._publish(job, reply, reply.reason)
                    self.timings.append(dict(serialize_ns=serialized-begin, spawn_ns=spawned-serialized,
                        ipc_and_compute_ns=arrived-spawned, validation_ns=validated-arrived,
                        compute_ns=reply.compute_ns, total_ns=validated-begin, job_bytes=len(raw),
                        reply_bytes=len(received), startup_ns=(started_box[0]-spawned) if started_box else None))
                    return
                self.stop_event.wait(0.002)
        except Exception as exc:
            # Publish first: baseline never waits for error encoding or cleanup.
            self._publish(job, None, type(exc).__name__, True)
            self.errors.record("worker_boundary", exc, job.correlation())
        finally:
            child.close()
            if process is not None and process.pid is not None:
                cleanup_started = time.perf_counter_ns()
                cancel.set()  # interprocess synchronization stays off host/Stop path
                process.join(0.10)
                cooperative = not process.is_alive()
                reaped = reap_child(process)
                if reaped:
                    self.counters["reaped"] += 1
                    process.close()
                else:
                    with self.lock:
                        self.breaker.record(True, "CLEANUP_UNCONFIRMED", persistent=True)
                if reader is not None:
                    reader.join(0.1)
                    if reader.is_alive():
                        with self.lock:
                            self.breaker.record(True, "IPC_CLEANUP_UNCONFIRMED", persistent=True)
                self.cleanups.append(dict(duration_ns=time.perf_counter_ns()-cleanup_started,
                                          cooperative=cooperative, reaped=reaped,
                                          reader_reaped=reader is None or not reader.is_alive()))
            parent.close()
            self.active_process = None
            self.active_pid = None

    def _serve(self):
        last_health = time.perf_counter()
        while not self.stop_event.is_set():
            self.wake.wait(0.005)
            self.wake.clear()
            with self.lock:
                job = self.pending
                self.pending = None
            if job is None:
                continue
            self.active_job = job
            if self.diagnostics is not None and self.diagnostics.buffer.disabled:
                with self.lock:
                    self.breaker.record(True, "LOG_SINK_DEGRADED", persistent=True)
                self._publish(job, None, "LOG_SINK_DEGRADED")
            elif not self.breaker.disabled:
                self._execute(job)
            self.active_job = None
            if time.perf_counter() - last_health >= 5:
                self._emit("reasoning.health", job.correlation(), dict(counters=dict(self.counters),
                    aggregated_occurrences=self.errors.aggregated, overflow_faults=self.errors.overflow), True)
                last_health = time.perf_counter()
        # Best effort outside Stop: no synchronous disk/drain on the caller.
        self._emit("reasoning.run_summary", {} if self.current is None else self.current.correlation(),
            dict(counters=dict(self.counters), errors=list(self.errors.signatures.values()),
                 aggregated_occurrences=self.errors.aggregated, overflow_faults=self.errors.overflow,
                 log_watermark=None if self.diagnostics is None else self.diagnostics.buffer.stats(),
                 worker_input_sent=False, mode="OFFLINE_ONLY"), True)


def create_runner(*, enabled: bool, **kwargs):
    """Disabled creates no worker, supervisor, queue or model import."""
    return IsolatedRunner(**kwargs) if enabled else None
