"""C1 advisory observer of the existing controller JSONL publication.

Admission retains an immutable string already encoded by BASIC. Parsing, copying,
hashing, job preparation and diagnostic encoding stay on the observer thread.
There is no reader, executor, selection method, ACK poll, or disk writer here.
The separate factory is rate capped; the legacy synchronous writer is NOT an AI
sink. Deployment/qualification scope is tracked in the C1 report, with C2 gated.
"""
from __future__ import annotations

from collections import OrderedDict, deque
from dataclasses import asdict
from enum import Enum
import hashlib
import json
import threading
import time
import uuid


EVENTS = frozenset(("policy_decision", "action_sent", "action_result",
                   "pet_skill_dispatch_result", "emergency_stop", "user_pause",
                   "auto_controller_summary"))
INPUT_BYTES = 1024 * 1024
RELAY_BYTES = 1024 * 1024
SINK_BYTES = 6 * 1024 * 1024
MIN_JOB_INTERVAL_NS = 1_000_000_000
LOG_EVENTS_PER_SECOND = 8
LOG_BYTES_PER_SECOND = 128 * 1024
_factory_lock = threading.Lock()
_factory_owner = None


def _config_value(value):
    if isinstance(value, Enum):
        return value.value
    if isinstance(value, dict):
        return {key: _config_value(child) for key, child in value.items()}
    if isinstance(value, (list, tuple)):
        return [_config_value(child) for child in value]
    return value


def _action(row):
    from .reasoning_snapshot import Action
    family = row["selectedAction"]
    move = row.get("move")
    # Legacy policy publications omit exact card/skill identity. Never guess it.
    if family != "swap":
        raise ValueError("NON_SWAP_SOURCE_NOT_FULLY_PUBLISHED")
    return Action.from_dict(dict(family=family, move=[move["first"], move["second"]],
                                 card_source=None))


def _root_key(row):
    from .reasoning_snapshot import canonical_json
    session = row["session"]
    if (type(session) is not dict or session.get("match_id") != row["matchId"]
            or type(session.get("lifecycle_epoch")) is not int
            or session["lifecycle_epoch"] <= 0
            or type(session.get("board_instance")) is not int
            or session["board_instance"] <= 0):
        raise ValueError("INVALID_SESSION_BINDING")
    return canonical_json([session, row["turn"], row["srvSeq"], row["boardHash"],
                           row.get("playStyle"), (row.get("player") or {}).get("actor_number"),
                           (row.get("player") or {}).get("is_local"), _action(row).to_dict()])


def snapshot_from_publication(raw: str, config_json: str, run_id: str, config_version=None):
    """Off-path conversion. Virtual single-record provenance is exportable.

    The SHA is of that exact one-record UTF-8 source, not of a growing log file.
    Missing model, controller generation, observation age and input reserve are
    explicit UNKNOWN. A policy proposal is not a final-preflight certificate.
    """
    from .reasoning_snapshot import (Evidence, FrozenJSON, ReasoningSnapshot,
                                     RunIntent, SourceIdentity, SourceRecord,
                                     require, strict_json_loads)
    row = strict_json_loads(raw)
    require(row.get("event") == "policy_decision", "not a policy publication")
    require(row.get("boardSnapshotOrder") ==
            "screen_rows_top_to_bottom_columns_left_to_right", "unknown coordinates")
    _root_key(row)
    config = strict_json_loads(config_json)
    require(row["playStyle"] == config["play_style"], "run profile conflict")
    player = row.get("player") or {}
    require(player.get("is_local") is True and type(player.get("actor_number")) is int,
            "LOCAL_ACTOR_NOT_PUBLISHED")
    session_text = FrozenJSON.of(row["session"]).text
    source = SourceIdentity(run_id, session_text, row["matchId"], row["turn"],
                            row["srvSeq"], row["boardHash"], player["actor_number"], None)
    record_sha = hashlib.sha256(raw.encode("utf-8")).hexdigest()
    provenance = SourceRecord(f"published/{record_sha}.jsonl", 1, record_sha, record_sha)
    ref = provenance.path + ":1"
    observations = []
    for role, field in (("self", "player"), ("boss", "boss")):
        actor = row.get(field) or {}
        for name, field_name, unit in (
            ("hp", "hp", "hp_points"), ("max_hp", "max_hp", "hp_points"),
            ("mana", "mana", "mana_points"), ("max_mana", "max_mana", "mana_points"),
            ("rage", "power", "rage_points"), ("max_rage", "max_power", "rage_points"),
            ("shield", "shield", "shield_points"), ("attack", "attack", "attack_points"),
        ):
            observations.append((f"{role}.{name}", Evidence.observed(actor.get(field_name), unit, ref)))
    for name, unit, reason in (
        ("planner.model", "scoped_model", "RUNTIME_MODEL_NOT_BOUND"),
        ("planner.legality", "action_capability", "FINAL_PREFLIGHT_NOT_PUBLISHED_AT_ROOT"),
        ("timing.observed_monotonic_ms", "milliseconds", "OBSERVATION_AGE_NOT_PUBLISHED"),
        ("timing.input_reserve_ms", "milliseconds", "NOT_CALIBRATED"),
        ("source.controller_generation", "generation", "NOT_PUBLISHED"),
    ):
        observations.append((name, Evidence.observed(None, unit, ref, reason=reason)))
    snapshot = ReasoningSnapshot(source, provenance,
        tuple(tuple(tuple(cell) for cell in line) for line in row["boardSnapshot"]),
        RunIntent(config["play_style"], FrozenJSON.of(config),
                  FrozenJSON.of(dict(adapter="5c1.v1", snapshot="v1", model="UNBOUND",
                                     **({} if config_version is None else
                                        {"ai_run_intent": "v1", "run_config_sha256": config_version}))),
                  FrozenJSON.of(dict(dataset_tier="O", mode="SHADOW_ONLY",
                                     account_binding="NOT_PUBLISHED", input_authority=False))),
        _action(row), (row.get("trace") or {}).get("why_selected") or "PUBLISHED_BASIC_INCUMBENT",
        tuple(observations), FrozenJSON.of(dict(
            publication_timestamp=row.get("timestamp"), timer_remaining=row.get("timerRemaining"),
            budget_scope="SHADOW_PROCESSING_CAP_ONLY_NOT_GAME_INPUT_DEADLINE")))
    snapshot.board_state()
    return snapshot


class _Relay:
    """One runner producer, one adapter consumer. Combined buffers <=8MiB."""
    def __init__(self, sink):
        self.buffer = sink.buffer
        self.lock = threading.Lock()
        self.items = deque()
        self.bytes = self.dropped = 0
        self.inflight = 0

    def enqueue(self, raw, *, critical=False):
        if not self.lock.acquire(False):
            self.dropped += 1
            return False
        try:
            if len(self.items) + self.inflight >= 64 or self.bytes + len(raw) > RELAY_BYTES:
                self.dropped += 1
                return False
            self.items.append((raw, critical))
            self.bytes += len(raw)
            return True
        finally:
            self.lock.release()

    def take(self):
        with self.lock:
            if not self.items:
                return None
            raw, critical = self.items.popleft()
            self.inflight += 1
            return raw, critical

    def finish(self, raw):
        with self.lock:
            self.inflight -= 1
            self.bytes -= len(raw)


class ShadowAdapter:
    """Experimental injected-sink seam, NEVER a controller/input owner.

    Construct outside run/action/Stop handlers. bind_config occurs once at setup.
    stop() is signal-only; close() is an offline/owner cleanup method.
    """
    def __init__(self, *, diagnostics, compute=None, run_id=None, budget_ms=4000,
                 config_version=None, status_callback=None):
        from .reasoning_runner import IsolatedRunner
        from .reasoning_diagnostics import ErrorSummaries
        if (diagnostics is None or diagnostics.buffer.limits.bytes > SINK_BYTES
                or diagnostics.buffer.limits.records > 432):
            raise ValueError("QUALIFIED_BOUNDED_SINK_REQUIRED_MAX_6MIB_432_RECORDS")
        if type(budget_ms) is not int or not 50 <= budget_ms <= 6000:
            raise ValueError("invalid shadow processing cap")
        self.sink = diagnostics
        self.relay = _Relay(diagnostics)
        self.runner = IsolatedRunner(diagnostics=self.relay, **({} if compute is None else {"compute": compute}))
        self.run_id = run_id or uuid.uuid4().hex
        self.budget_ms = budget_ms
        self.config_version = config_version
        self.status_callback = status_callback
        self.status_reason = "WAITING_PUBLICATION"
        self.status_suggestion = ""
        self.status_next_ns = 0
        self.status_signature = None
        self.owns_sink = False
        self.next_job_ns = 0
        self.log_window_ns = time.perf_counter_ns()
        self.log_window_events = self.log_window_bytes = 0
        self.config_json = None
        self.lock = threading.Lock()
        self.wake = threading.Event()
        self.stopped = threading.Event()
        self.items = deque()
        self.bytes = 0
        self.inflight = 0
        self.roots = OrderedDict()
        self.identities = OrderedDict()
        self.sequence = self.generation = 0
        self.counts = dict(eligible=0, admitted=0, dropped=0, ignored=0,
                           prepared=0, unsupported=0, faults=0, dispatched=0,
                           outcomes=0, unknown_attribution=0, log_dropped=0,
                           high_bytes=0, high_records=0, discarded=0)
        self.counts.update(rate_limited=0, log_rate_limited=0)
        self.last_fault = None
        self.errors = ErrorSummaries(self._emit)
        self.thread = threading.Thread(target=self._serve, name="reasoning-shadow", daemon=True)
        self.thread.start()

    def bind_config(self, config):
        from .reasoning_snapshot import canonical_json
        if self.config_json is not None:
            raise ValueError("run config already frozen")
        self.config_json = canonical_json(_config_value(asdict(config)))

    def observe_line(self, raw):
        """Host path: bounded immutable string reference + try-lock, no parsing."""
        if self.stopped.is_set():
            return False
        # _write emits timestamp/event first. Never scan the whole candidate trace.
        prefix = raw[:160]
        event = next((event for event in EVENTS if f'"event":"{event}"' in prefix), None)
        if event is None:
            self.counts["ignored"] += 1
            return False
        if event in {"emergency_stop", "user_pause", "auto_controller_summary"}:
            self.stop()
            return False
        self.counts["eligible"] += 1
        charge = len(raw) * 4  # Conservative UTF-8 bound, no encoding on host.
        if charge > INPUT_BYTES or not self.lock.acquire(False):
            self.counts["dropped"] += 1
            return False
        try:
            if (self.stopped.is_set() or len(self.items) + self.inflight >= 16
                    or self.bytes + charge > INPUT_BYTES):
                self.counts["dropped"] += 1
                return False
            self.items.append((raw, time.perf_counter_ns(), charge))
            self.bytes += charge
            self.counts["admitted"] += 1
            self.counts["high_records"] = max(self.counts["high_records"], len(self.items) + self.inflight)
            self.counts["high_bytes"] = max(self.counts["high_bytes"], self.bytes)
            self.wake.set()
            return True
        finally:
            self.lock.release()

    def _emit(self, event, correlation, payload, critical=False):
        from .reasoning_diagnostics import encode_event
        self.sequence += 1
        if self.status_callback is not None and event in {
                "reasoning.decision", "reasoning.fallback", "reasoning.shadow_skip"}:
            self.status_reason = str(payload.get("reason", "UNKNOWN"))[:256]
            proposal = payload.get("proposal_action")
            self.status_suggestion = "" if proposal is None else json.dumps(proposal, separators=(",", ":"))[:256]
        try:
            raw = encode_event(event, self.sequence, {"run_id": self.run_id, **correlation},
                dict(payload, adapter_mode="SHADOW_ONLY", selection_authority=False))
            body = json.loads(raw)
            body["producer"] = "shadow_adapter_5c1"
            raw = (json.dumps(body, ensure_ascii=False, separators=(",", ":"), allow_nan=False) + "\n").encode()
            now = time.perf_counter_ns()
            if now - self.log_window_ns >= 1_000_000_000:
                self.log_window_ns = now
                self.log_window_events = self.log_window_bytes = 0
            if (self.log_window_events >= LOG_EVENTS_PER_SECOND or
                    self.log_window_bytes + len(raw) > LOG_BYTES_PER_SECOND):
                self.counts["log_rate_limited"] += 1
                accepted = False
            else:
                self.log_window_events += 1
                self.log_window_bytes += len(raw)
                accepted = self.sink.enqueue(raw, critical=critical)
        except Exception as exc:
            accepted = False
            self.last_fault = "SINK_" + type(exc).__name__
        if not accepted:
            self.counts["log_dropped"] += 1
            self.runner.invalidate()
            self.runner.stop()

    def _handle(self, raw, received_ns):
        from .reasoning_snapshot import canonical_json, strict_json_loads
        from .reasoning_runner import make_job
        row = strict_json_loads(raw)
        event = row["event"]
        if event == "policy_decision":
            key = _root_key(row)
            if key in self.roots:
                return
            if self.sink.buffer.disabled or self.runner.stop_event.is_set():
                self.counts["unsupported"] += 1
                self.last_fault = "DIAGNOSTICS_DEGRADED"
                return
            now = time.perf_counter_ns()
            if now < self.next_job_ns:
                self.counts["rate_limited"] += 1
                self.status_reason = "SHADOW_RATE_LIMITED"
                self.runner.invalidate()
                return
            snapshot = snapshot_from_publication(raw, self.config_json, self.run_id, self.config_version)
            deadline = received_ns + self.budget_ms * 1_000_000
            if time.perf_counter_ns() >= deadline - 50_000_000 or self.stopped.is_set():
                self._emit("reasoning.shadow_skip", {}, dict(reason="ADMISSION_EXPIRED"))
                return
            self.generation += 1
            self.next_job_ns = now + MIN_JOB_INTERVAL_NS
            job = make_job(snapshot, deadline=deadline, generation=self.generation)
            self.roots[key] = job
            if len(self.roots) > 64:
                self.roots.popitem(last=False)
            self.counts["prepared"] += 1
            self.runner.submit(job)
            return
        identity = row.get("identity")
        if identity is None and isinstance(row.get("action"), dict):
            identity = row["action"].get("identity")
        identity_key = canonical_json(identity) if identity is not None else None
        if event == "action_sent":
            key = _root_key(row)
            job = self.roots.get(key)
            # Compare source + actual identity action/target, never selectedAction alone.
            source = (identity or {}).get("source") or {}
            matches = (job is not None and identity is not None
                and source.get("session") == row["session"]
                and source.get("turn") == row["turn"]
                and source.get("srv_seq") == row["srvSeq"]
                and source.get("board_hash") == row["boardHash"]
                and identity.get("action") == "swap"
                and sorted(identity.get("target", [])) == job.snapshot.baseline.to_dict()["move"]
                and row.get("boardSnapshot") == [[list(cell) for cell in line] for line in job.snapshot.board]
                and row.get("action") == "SWAP")
            if not matches:
                self.counts["unknown_attribution"] += 1
                self._emit("reasoning.shadow_dispatch", {}, dict(attribution="UNKNOWN", reason="NO_EXACT_ROOT_IDENTITY"))
                return
            self.identities[identity_key] = job
            if len(self.identities) > 64:
                self.identities.popitem(last=False)
            self.counts["dispatched"] += 1
            self._emit("reasoning.shadow_dispatch", job.correlation(), dict(
                dispatched_candidate_id=job.candidate_id(job.snapshot.baseline),
                controller_input_sent=True, dispatch_identity=identity,
                binding_scope="PUBLISHED_BOARD_ACTOR_PROFILE_ACTION; ROOT_CRITICAL_HASH_NOT_PUBLISHED",
                ack="UNKNOWN", terminal="UNKNOWN", replacement_input=False))
        elif event in {"action_result", "pet_skill_dispatch_result"}:
            job = self.identities.get(identity_key) if identity_key else None
            self.counts["outcomes" if job is not None else "unknown_attribution"] += 1
            self._emit("reasoning.shadow_outcome", {} if job is None else job.correlation(), dict(
                attribution="EXACT_DISPATCH_IDENTITY" if job else "UNKNOWN",
                result=row.get("result"), evidence_origin="EXISTING_CONTROLLER_EVENT",
                terminal="UNKNOWN", boss_action="UNKNOWN", counterfactual_outcome="UNKNOWN"))

    def _publish_status(self, *, final=False):
        # Background watermark only: no new thread/poll, locks, disk reads or UI wait.
        if self.status_callback is None:
            return
        now = time.perf_counter_ns()
        if not final and now < self.status_next_ns:
            return
        self.status_next_ns = now + 1_000_000_000
        b = self.sink.buffer
        degraded = bool(b.disabled or self.counts["log_dropped"] or self.relay.dropped
                        or self.counts["dropped"] or self.counts["faults"]
                        or self.runner.counters["faults"] or self.runner.counters["log_dropped"])
        state = ("STOPPED" if final else "DEGRADED" if degraded else
                 "UNSUPPORTED" if self.last_fault else "SHADOW")
        values = dict(state=state, reason=str(b.failure or self.last_fault or self.status_reason)[:256],
                      suggestion=self.status_suggestion, dropped=(self.counts["dropped"] +
                      self.counts["log_dropped"] + self.relay.dropped +
                      b.failed_write + b.discarded), written=b.written,
                      queued=len(b.items) + b.in_writer,
                      faults=self.counts["faults"] + self.runner.counters["faults"],
                      unsupported=self.counts["unsupported"], skipped=self.counts["rate_limited"],
                      accounting_valid=False)
        signature = tuple(values.items())
        if signature == self.status_signature:
            return
        try:
            if self.status_callback(values) is not False:
                self.status_signature = signature
        except Exception:
            # Display callback faults cannot poison the solver or logging pipeline.
            self.status_callback = None

    def _serve(self):
        from .reasoning_snapshot import strict_json_loads
        while not self.stopped.is_set():
            self.wake.wait(0.005)
            self.wake.clear()
            item = None
            with self.lock:
                if self.items:
                    raw, received_ns, charge = self.items.popleft()
                    self.inflight += 1
                    # In-flight text remains charged while parsing/preparing.
                    item = raw, received_ns, charge
            if item is not None:
                try:
                    self._handle(item[0], item[1])
                except ValueError as exc:
                    self.counts["unsupported"] += 1
                    self.last_fault = str(exc)[:512]
                    self.errors.record("shadow_publication", exc, dict(run_id=self.run_id))
                except Exception as exc:
                    self.counts["faults"] += 1
                    self.last_fault = type(exc).__name__
                    self.runner.invalidate()
                    self.errors.record("shadow_adapter", exc, dict(run_id=self.run_id))
                finally:
                    with self.lock:
                        self.inflight -= 1
                        self.bytes -= item[2]
            while (record := self.relay.take()) is not None:
                try:
                    row = strict_json_loads(record[0].decode())
                    self._emit(row["event_type"], row["correlation"], row["payload"], record[1])
                except Exception:
                    self.counts["log_dropped"] += 1
                    self.runner.invalidate()
                    self.runner.stop()
                finally:
                    self.relay.finish(record[0])
            self._publish_status()
        with self.lock:
            self.counts["discarded"] += len(self.items)
            self.items.clear()
            self.bytes = 0
        if self.owns_sink:
            # Cleanup happens on this thread, never in the controller Stop path.
            self.runner.close()
            while (record := self.relay.take()) is not None:
                try:
                    row = strict_json_loads(record[0].decode())
                    self._emit(row["event_type"], row["correlation"], row["payload"], record[1])
                except Exception:
                    self.counts["log_dropped"] += 1
                finally:
                    self.relay.finish(record[0])
            self.sink.flush(timeout=.10)
            if not self.sink.close():
                self.counts["faults"] += 1
                self.last_fault = "LOG_CLEANUP_UNCONFIRMED"
        self._publish_status(final=True)

    def stop(self):
        self.stopped.set()
        self.runner.stop()
        self.wake.set()

    def close(self, timeout=1.5):
        """Cleanup only; never called by run(), input or Stop handlers."""
        self.stop()
        self.thread.join(timeout)
        reaped = self.runner.close(timeout)
        if not self.thread.is_alive():
            with self.relay.lock:
                self.counts["discarded"] += len(self.relay.items)
                self.relay.items.clear()
                self.relay.bytes = 0
        return (reaped and not self.thread.is_alive() and
                (not self.owns_sink or (self.sink.reaped and not self.sink.thread.is_alive())))


class _ObservedLog:
    def __init__(self, log, adapter):
        self.log, self.adapter = log, adapter

    def write(self, raw):
        result = self.log.write(raw)  # Established gameplay log semantics first.
        try:
            self.adapter.observe_line(raw)
        except Exception:
            # Even an unexpected adapter admission fault cannot abort combat.
            try:
                self.adapter.stop()
            except Exception:
                pass
        return result

    def flush(self):
        return self.log.flush()


def attach_shadow_log(log, adapter, config):
    """Setup-only; disabled returns the original handle with no AI allocation."""
    if adapter is None:
        return log
    try:
        adapter.bind_config(config)
        return _ObservedLog(log, adapter)
    except Exception:
        try:
            adapter.stop()
        except Exception:
            pass
        return log


def stop_shadow_safely(adapter):
    try:
        adapter.stop()
    except Exception:
        pass


def create_shadow(*, enabled=False, diagnostics=None, directory=None, **kwargs):
    """Explicit opt-in only. Owned separate sink is tested at the hard rate caps.

    C2 owns exposing/freezing this setting. No default creation, imports,
    file access, worker, or queue when disabled; no mutation of the common log.
    """
    if not enabled or (diagnostics is None and directory is None):
        return None
    global _factory_owner
    owned = diagnostics is None
    if owned and not _factory_lock.acquire(False):
        return None
    try:
        if owned:
            previous = _factory_owner
            if previous is not None and (previous.thread.is_alive() or
                    previous.runner.thread.is_alive() or previous.sink.thread.is_alive() or
                    previous.runner.counters["processes"] != previous.runner.counters["reaped"] or
                    not previous.sink.reaped):
                return None  # Skip AI rather than overlap or delay BASIC during cleanup.
            from .reasoning_diagnostics import BoundedDiagnostics, LogLimits
            diagnostics = BoundedDiagnostics(directory, limits=LogLimits(records=432, bytes=SINK_BYTES))
        adapter = ShadowAdapter(diagnostics=diagnostics, **kwargs)
        adapter.owns_sink = owned
        if owned:
            _factory_owner = adapter  # Bounded one-owner ledger; keep unconfirmed cleanup fail-closed.
        return adapter
    except Exception:
        if owned and diagnostics is not None:
            diagnostics.stop()
        return None
    finally:
        if owned:
            _factory_lock.release()
