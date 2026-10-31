"""Opt-in immutable producer -> isolated R1 worker -> guarded selector.

Admission retains only frozen state/config references. Preparation, IPC result
packing, diagnostics relay and cleanup belong to the background owner. The
Legacy no-wait mode retains BASIC immediately. The operator-authorized decision
budget mode supplies the controller's BASIC incumbent and waits interruptibly,
without any extra game read/capture/input. Missing or late results retain BASIC.
"""
from __future__ import annotations

from collections import Counter, deque
from dataclasses import replace
import json
import threading
import time
import uuid

from .autonomous_control import AutonomousSource
from .basic_policy import BasicPolicyEngine, PolicyAction, PolicyConfig
from .board_diagnostics import jsonable
from .reasoning_diagnostics import DiagnosticBuffer, LogLimits, encode_event
from .reasoning_operational import is_pilot_authority, authority_deadline, OperationalPilotAuthority
from .reasoning_pilot_contract import PilotAuthority
from .reasoning_planner import MODEL_VERSION, UTILITY_VERSION, FEATURE_VERSION
from .reasoning_runner import IsolatedRunner, Binding, RunnerJob, REPLY_SCHEMA, deadline_ns
from .reasoning_selection import Capability, CompletedProposal, GuardedSelectionAdapter
from .reasoning_shadow import _Relay
from .reasoning_snapshot import (Action, Evidence, FrozenJSON, ReasoningSnapshot,
                                 RunIntent, SourceIdentity, SourceRecord, canonical_json, digest)
from .state import GameState, GamePhase


def snapshot_from_state(state, config, baseline, authority, run_id, generation, observed_ns, read_end_ns):
    """Virtual immutable provenance from an already published state; no reader."""
    source = AutonomousSource.from_state(state)
    identity = SourceIdentity(run_id, canonical_json(jsonable(state.battle.session_key)),
        state.battle.match_id, state.battle.turn_number, state.battle.srv_seq,
        state.battle.board_hash, state.player.actor_number, generation)
    scope = dict(authority.scope.plain(), mode=authority.context, input_authority=False,
                 pilot_authority=authority.identity, binding_strength="OPERATOR_PLUS_STRUCTURAL_WITNESS")
    binding = dict(authority.scope.plain(), profile=authority.profile,
                   session_id=identity.session_id, match_id=identity.match_id)
    board = tuple(tuple((cell.gem.value, cell.multiplier) for cell in row) for row in state.board.cells)
    recorded = dict(controller_source_hash=source.critical_state_hash,
                    observed_ns=observed_ns, read_end_ns=read_end_ns,
                    provenance_kind="IMMUTABLE_EXISTING_PROVIDER_STATE_NOT_EXTRA_READ",
                    game_build_sha256=authority.game_build_sha256,
                    calibration_sha256=authority.calibration_sha256,
                     timing_mode=("OPERATIONAL_PROJECTION" if type(authority) is OperationalPilotAuthority else "STRICT"),
                     native_U_ms=(None if type(authority) is OperationalPilotAuthority else authority.uncertainty_ms))
    from .reasoning_full_actions import is_full_action, incumbent_action
    root_action = incumbent_action(baseline) if is_full_action(authority) else Action('swap',baseline.move)
    sha = digest(dict(source=identity.to_dict(), board=board, recorded=recorded,
        config=jsonable(config), baseline=root_action.to_dict(),
        baseline_reason=baseline.trace.why_selected or "EXISTING_BASIC_INCUMBENT"))
    provenance = SourceRecord("captured/" + sha + ".json", 1, sha, sha)
    observations = []
    origin = "SYNTHETIC_SPEC" if authority.calibration_origin == "OFFLINE_NATIVE_FAKES" else "OBSERVED_SNAPSHOT"
    boss = next(p for p in state.opponents if p.is_boss is True)
    for role, actor in (("self", state.player), ("boss", boss)):
        for name, field, unit in (("hp", "hp", "hp_points"), ("max_hp", "max_hp", "hp_points"),
                ("mana", "mana", "mana_points"), ("max_mana", "max_mana", "mana_points"),
                ("rage", "power", "rage_points"), ("max_rage", "max_power", "rage_points"),
                ("shield", "shield", "shield_points"), ("attack", "attack", "attack_points")):
            observations.append((role + "." + name, Evidence.observed(getattr(actor, field), unit,
                provenance.path, scope=binding, origin=origin)))
    observations.extend((
        ("planner.model", Evidence.observed(authority.model.plain(), "scoped_model", provenance.path,
            origin="SYNTHETIC_SPEC" if origin == "SYNTHETIC_SPEC" else "MODEL_PREDICTION",
            support="CONDITIONAL_MODEL", scope=binding)),
        ("planner.legality", Evidence.observed(dict(owner="ROOT_TURN", swap_allowed=True,
            pass_allowed=False, mandatory=True, blocked=False), "action_capability", provenance.path,
            origin="DERIVED_SOLVER", scope=dict(binding, turn=identity.turn))),
        ("planner.known_boss_threat", Evidence.observed(None, "normalized", provenance.path,
            reason="DAMAGE_AND_BOSS_SKILL_THREAT_UNMODELED")),
        ("timing.observed_monotonic_ms", Evidence.observed(observed_ns / 1e6, "milliseconds", provenance.path)),
        ("timing.input_reserve_ms", Evidence.observed(authority.reserve_ms, "milliseconds", provenance.path,
            origin=origin, scope=binding)),
        ("source.controller_generation", Evidence.observed(generation, "generation", provenance.path))))
    return ReasoningSnapshot(identity, provenance, board,
        RunIntent(authority.profile, FrozenJSON.of(jsonable(config)),
            FrozenJSON.of(dict(utility=UTILITY_VERSION, features=FEATURE_VERSION, model=MODEL_VERSION,
                               bridge="5d1.nonblocking.v1")), FrozenJSON.of(scope)),
        root_action, baseline.trace.why_selected or "EXISTING_BASIC_INCUMBENT",
        tuple(observations), FrozenJSON.of(recorded))


class PilotSelectionBridge(GuardedSelectionAdapter):
    def __init__(self, *, authority, diagnostics, verified_build_sha256, enabled=False, run_id=None,
                 warm_worker=False, decision_budget=False):
        if not is_pilot_authority(authority) or verified_build_sha256 != authority.game_build_sha256:
            raise ValueError("explicit scoped authority and independently supplied build required")
        if (type(diagnostics.buffer) is not DiagnosticBuffer or diagnostics.buffer.limits.records > 432
                or diagnostics.buffer.limits.bytes > 6 * 1024 * 1024):
            raise ValueError("qualified capped sink required")
        local = DiagnosticBuffer(LogLimits(records=64, bytes=128 * 1024,
                                           reserved_bytes=16 * 1024))
        super().__init__(diagnostics=local, enabled=enabled, pilot_authority=authority)
        self.sink, self.relay = diagnostics, _Relay(diagnostics)
        # Independent controller producer, drained only by this bridge owner.
        # The disk sink continues to have exactly one producer thread.
        self.timing_diagnostics = (DiagnosticBuffer(LogLimits(records=64, bytes=128*1024,
            reserved_bytes=16*1024)) if type(authority) is OperationalPilotAuthority else None)
        self.warm_worker = warm_worker
        self.decision_budget = decision_budget
        self.observation = None
        self.action_context = None  # Immutable references supplied at existing decision/fresh seams.
        self.last_admission = None  # One bounded receipt, no state copy/hash here.
        self.preparation_reason = None
        self.result_ready = threading.Event()
        self.budget_receipts = deque(maxlen=64)
        if warm_worker:
            from .reasoning_warm_runner import WarmIsolatedRunner
            self.runner = WarmIsolatedRunner(diagnostics=self.relay)
        else:
            self.runner = IsolatedRunner(diagnostics=self.relay)
        self.run_id = run_id or uuid.uuid4().hex
        self.request_lock = threading.Lock()
        self.request = self.active = None
        self.seen_source = None
        self.wake, self.shutdown = threading.Event(), threading.Event()
        self.bridge_counts = Counter()
        self.generation = 0
        self.next_job_ns = 0
        self.last_snapshot = None
        self.completed_history = []  # One bounded, small timing receipt, never snapshot copies.
        self.checkpoints = deque(maxlen=64)
        self.preparation = deque(maxlen=64)
        self.cleanup_ok = None
        self.owns_sink = False
        self.defer_sink_stop = False  # Optional session finalizer owns durable close.
        self._log_window = self._log_events = self._log_bytes = self._bridge_seq = 0
        self.thread = threading.Thread(target=self._serve, name="reasoning-pilot-owner", daemon=True)
        self.thread.start()

    def controller_context(self, *, target_pid, shared_runtime):
        a = self.pilot_authority
        if a.calibration_origin == "OFFLINE_NATIVE_FAKES":
            return a.context if target_pid == 0 and shared_runtime else "PRODUCTION_GATED"
        return a.context if type(target_pid) is int and target_pid > 0 else "PRODUCTION_GATED"

    def _record(self, reason, checkpoint, now_ns):
        self.checkpoints.append(dict(checkpoint=checkpoint, now_ns=now_ns, reason=reason))
        return super()._record(reason, checkpoint, now_ns)

    def observe(self, state, config, *, observed_ns, read_end_ns, context):
        """Try-lock admission only. No copy/hash/solver/worker wait on controller."""
        def rejected(reason):
            self.last_admission = dict(reason=reason, observed_ns=observed_ns, read_end_ns=read_end_ns)
            if (type(self.pilot_authority) is OperationalPilotAuthority
                    and self.pilot_authority.root_read_policy is not None):
                self.last_admission["root_read_policy"] = self.pilot_authority.root_read_policy.plain()
            self.bridge_counts[reason] += 1
            return False
        if (not self.enabled or self.stopped or self.disabled or context != self.pilot_authority.context
                or type(state) is not GameState or state.phase is not GamePhase.COMBAT
                or type(config) is not PolicyConfig
                or config.play_style.value != self.pilot_authority.profile):
            self.bridge_counts["admission_skipped"] += 1
            return rejected("ADMISSION_UNSUPPORTED_OR_UNAVAILABLE")
        if (type(observed_ns) is not int or type(read_end_ns) is not int
                or not 0 <= observed_ns <= read_end_ns):
            self.bridge_counts["observation_clock_or_span_invalid"] += 1
            return rejected("OBSERVATION_CLOCK_INVALID")
        root_cap = (self.pilot_authority.max_root_poll_span_ms
                    if type(self.pilot_authority) is OperationalPilotAuthority
                    else self.pilot_authority.max_read_span_ms)
        if read_end_ns - observed_ns > root_cap * 1e6:
            self.bridge_counts["observation_clock_or_span_invalid"] += 1
            return rejected("OBSERVATION_READ_SPAN_EXCEEDED")
        if not self.request_lock.acquire(False):
            self.bridge_counts["admission_busy"] += 1
            return rejected("ADMISSION_BUSY")
        try:
            self.bridge_counts["replaced_pending"] += self.request is not None
            self.request = (state, config, observed_ns, read_end_ns)
            self.observation = self.request
            self.last_admission = dict(reason="ADMITTED", observed_ns=observed_ns, read_end_ns=read_end_ns)
            if self.decision_budget:
                self.request = None  # The controller supplies its existing BASIC incumbent.
            self.bridge_counts["admitted"] += 1
            self.wake.set()
            return True
        finally:
            self.request_lock.release()

    def _reason(self, offer, state, baseline, config, now_ns, input_allowed, context,
                final=False, final_remaining_seconds=None):
        # A rejected current observation must not reuse an older completed
        # offer, even when its board/source happens to be identical. No lock or
        # extra snapshot read on any of the existing three checkpoints.
        if (self.last_admission is not None and self.last_admission["reason"] != "ADMITTED"
                and input_allowed and self.enabled and not self.stopped and not self.disabled
                and not self.diagnostics.disabled and context == self.pilot_authority.context):
            return self.last_admission["reason"]
        return super()._reason(offer, state, baseline, config, now_ns, input_allowed, context,
                               final, final_remaining_seconds)

    def await_decision(self, state, baseline, config, *, context, stop_requested):
        """Opt-in decision slice only. No native reads, capture, input or deadline reset.

        The operator explicitly authorized a bounded interruptible wait on
        2026-10-12. Ordinary BASIC and shadow never call this method.
        """
        from .reasoning_full_actions import is_full_action, incumbent_action
        d2 = is_full_action(self.pilot_authority)
        if (not self.decision_budget or not self.enabled or self.stopped or self.disabled
                or context != self.pilot_authority.context or (incumbent_action(baseline) is None if d2
                    else baseline.action is not PolicyAction.SWAP)):
            return 'SKIPPED'
        if self.last_admission is not None and self.last_admission["reason"] != "ADMITTED":
            return self.last_admission["reason"]
        if not self.request_lock.acquire(False):
            return 'BUSY'
        try:
            observation = self.observation
            if observation is None:
                return 'NO_OBSERVATION'
            observed_state, observed_config, observed_ns, read_end_ns = observation
            if (AutonomousSource.from_state(observed_state) != AutonomousSource.from_state(state)
                    or observed_config != config):
                return 'SOURCE_CHANGED'
            a = self.pilot_authority
            started = time.perf_counter_ns()
            limit = authority_deadline(a, observed_ns=observed_ns,
                remaining_ms=state.battle.turn_time_remaining_seconds*1000,
                slice_started_ns=read_end_ns, now_ns=started)
            if limit is None:
                return 'NO_BUDGET'
            self.result_ready.clear()
            self.preparation_reason = None
            self.request = ((state, config, observed_ns, read_end_ns, baseline, self.action_context) if d2
                else (state, config, observed_ns, read_end_ns, baseline))
            self.wake.set()
        finally:
            self.request_lock.release()
        reason = 'DEADLINE'
        self.bridge_counts['decision_wait_started'] += 1
        while time.perf_counter_ns() < limit:
            if stop_requested():
                self.stop()
                reason = 'STOPPED'
                break
            if self.stopped or self.disabled or self.sink.buffer.disabled or self.runner.breaker.disabled:
                reason = 'UNAVAILABLE'
                break
            if self.result_ready.is_set():
                reason = 'COMPLETED' if self.completed is not None else 'FALLBACK'
                break
            self.result_ready.wait(min(.005, max(0, (limit-time.perf_counter_ns())/1e9)))
        self.budget_receipts.append(dict(started_ns=started, ended_ns=time.perf_counter_ns(),
            deadline_ns=limit, reason=reason, incumbent='EXISTING_CONTROLLER_BASIC',
            observed_ns=observed_ns, read_end_ns=read_end_ns,
            raw_remaining_ms=state.battle.turn_time_remaining_seconds*1000,
            preparation_reason=self.preparation_reason,
            worker_reason=None if self.completed is None else self.completed.reply.reason,
            worker_disposition=None if self.completed is None else self.completed.reply.disposition))
        return reason

    def stop(self):
        super().stop()
        self.shutdown.set()
        self.runner.stop()
        self.result_ready.set()
        self.wake.set()  # No child cleanup, disk flush or join here.

    def close(self, timeout=3):
        self.stop()
        self.thread.join(timeout)  # Owner/test cleanup only, never action/Stop.
        return not self.thread.is_alive() and self.cleanup_ok is True

    def _prepare(self, request):
        started_ns = time.perf_counter_ns()
        state, config, observed_ns, read_end_ns = request[:4]
        a = self.pilot_authority
        if not a.matches(state, config):
            self.preparation_reason = "COHORT_OR_CONFIG_CHANGED"
            self.completed = self.active = None
            self.runner.invalidate()
            self.bridge_counts["cohort_or_config_changed"] += 1
            return
        source = AutonomousSource.from_state(state)
        if self.seen_source == source:
            self.preparation_reason = "SAME_SOURCE_NO_DEADLINE_RESET"
            self.bridge_counts["same_source_no_deadline_reset"] += 1
            return
        self.seen_source = source
        self.completed = self.active = None
        self.runner.invalidate()
        if time.perf_counter_ns() < self.next_job_ns:
            self.preparation_reason = "JOB_RATE_LIMITED"
            self.bridge_counts["job_rate_limited"] += 1
            return
        # Budget mode reuses the exact controller incumbent. Legacy no-wait mode
        # computes a provisional one that must match the controller's BASIC.
        baseline = request[4] if len(request) >= 5 else BasicPolicyEngine(config).decide(state)
        incumbent_ns = time.perf_counter_ns()
        from .reasoning_full_actions import is_full_action, incumbent_action, bind_snapshot
        d2 = is_full_action(a)
        if (incumbent_action(baseline) is None if d2 else baseline.action is not PolicyAction.SWAP):
            self.preparation_reason = "BASELINE_FAMILY_UNSUPPORTED"
            self.bridge_counts["baseline_family_unsupported"] += 1
            return
        now = time.perf_counter_ns()
        limit = authority_deadline(a, observed_ns=observed_ns,
            remaining_ms=state.battle.turn_time_remaining_seconds * 1000,
            slice_started_ns=read_end_ns, now_ns=now)
        if limit is None:
            self.preparation_reason = "NO_PROCESSING_BUDGET"
            self.bridge_counts["no_processing_budget"] += 1
            return
        self.generation += 1
        snap = snapshot_from_state(state, config, baseline, a, self.run_id,
                                   self.generation, observed_ns, read_end_ns)
        from .reasoning_demon import is_demon, bind_snapshot as bind_demon_snapshot
        if is_demon(a):
            snap = bind_demon_snapshot(snap,a)
        packet = None
        if d2:
            packet = request[5]
            if packet is None:
                self.preparation_reason = 'D2_CONTEXT_MISSING'
                return
            from .reasoning_full_actions import UnrepresentedBaseline
            try:
                snap = bind_snapshot(snap, packet, a)
            except UnrepresentedBaseline as exc:
                # Missing evidence belongs to this source/job. The existing
                # BASIC owner/preflight still decides whether it may execute.
                self.preparation_reason = 'D2_BASELINE_EVIDENCE_UNAVAILABLE'
                self.bridge_counts['d2_baseline_evidence_unavailable'] += 1
                self._bridge_seq += 1
                self._forward(encode_event('reasoning.preparation_fallback', self._bridge_seq,
                    dict(run_id=self.run_id, source=jsonable(source)),
                    dict(reason=self.preparation_reason, evidence=exc.details.plain(),
                        input_authority=False)), False)
                return
        job = RunnerJob(uuid.uuid4().hex, self.generation,
            Binding(snap.snapshot_id, snap.intent.config_hash, canonical_json(snap.source.to_dict()), a.profile),
            snap, read_end_ns, limit)
        capability = Capability(a.profile, digest(a.model.plain()), a.scope.text,
            a.reserve_ms, observed_ns, state.battle.turn_time_remaining_seconds * 1000,
            context=a.context, pilot_authority=a, action_context=packet)
        self.last_snapshot = snap
        if self.runner.submit(job):
            self.preparation_reason = "SUBMITTED"
            self.active = (job, source, state, config, capability)
            self.next_job_ns = now + 1_000_000_000
            self.bridge_counts["jobs_submitted"] += 1
            self.preparation.append(dict(observed_ns=observed_ns, read_end_ns=read_end_ns,
                prepare_started_ns=started_ns, incumbent_ready_ns=incumbent_ns,
                submitted_ns=time.perf_counter_ns(), job_id=job.job_id, deadline_ns=limit))

    def _complete(self):
        active = self.active
        if active is None or self.completed is not None:
            return
        job, source, state, config, capability = active
        outcome = None
        if self.runner.lock.acquire(False):
            try:
                if (self.runner.current is job and not self.runner.invalidated.is_set()
                        and not self.runner.stop_event.is_set() and not self.runner.breaker.disabled):
                    outcome = self.runner.outcome
            finally:
                self.runner.lock.release()
        if outcome is None:
            return
        reply, reason = outcome
        if reply is None:
            self.preparation_reason = "WORKER_" + reason
            self.active = None
            self.bridge_counts["worker_fallback"] += 1
            self.result_ready.set()
            return
        raw = canonical_json(dict(schema=REPLY_SCHEMA, job_id=job.job_id, generation=job.generation,
            binding=vars(job.binding), disposition=reply.disposition, reason=reply.reason,
            proposal=None if reply.proposal is None else reply.proposal.to_dict(), compute_ns=reply.compute_ns,
            input_authority=False, r2_promotion=False, summary=json.loads(reply.summary_json))).encode()
        offer = CompletedProposal.prepare(job=job, raw_reply=raw, state=state, config=config,
            capability=capability, completed_ns=time.perf_counter_ns())
        now = time.perf_counter_ns()
        if self.stopped or self.disabled or self.sink.buffer.disabled or now >= job.deadline_ns:
            self.bridge_counts["completed_discarded"] += 1
            self.active = None
            return
        self.completed = replace(offer, completed_ns=now)
        self.completed_history[:] = [dict(admitted_ns=job.created_ns, completed_ns=now,
            elapsed_ns=now-job.created_ns, generation=job.generation, reason=reply.reason,
            proposal=reply.proposal is not None)]
        self.bridge_counts["completed_published"] += 1
        self.result_ready.set()

    def _forward(self, raw, critical=False):
        now = time.perf_counter_ns()
        window = now // 1_000_000_000
        if window != self._log_window:
            self._log_window, self._log_events, self._log_bytes = window, 0, 0
        if self._log_events >= 8 or self._log_bytes + len(raw) > 128 * 1024:
            self.bridge_counts["diagnostic_rate_limited"] += 1
            self.disabled = True
            return False
        self._log_events += 1
        self._log_bytes += len(raw)
        try:
            accepted = self.sink.enqueue(raw, critical=critical)
        except Exception:
            accepted = False
            self.bridge_counts["sink_exception"] += 1
        if not accepted:
            self.disabled = True
            self.bridge_counts["sink_failure"] += 1
            return False
        self.bridge_counts["relayed_not_durable"] += 1
        return True

    def _drain(self):
        if self.timing_diagnostics is not None:
            raw = self.timing_diagnostics.take()
            if raw is not None:
                self._forward(raw, True)
                self.timing_diagnostics.finish(raw)
        item = self.relay.take()
        if item is not None:
            raw, critical = item
            self._forward(raw, critical)
            self.relay.finish(raw)
        raw = self.diagnostics.take()
        if raw is not None:
            self._forward(raw, True)
            self.diagnostics.finish(raw)  # Transfer only; durable watermark belongs to sink.

    def _serve(self):
        try:
            while not self.shutdown.is_set():
                self.wake.wait(.002)
                self.wake.clear()
                with self.request_lock:
                    request, self.request = self.request, None
                if self.sink.buffer.disabled or self.runner.breaker.disabled:
                    self.disabled = True
                self._drain()
                if not self.disabled:
                    if request is not None:
                        self._prepare(request)
                        if self.active is None or self.completed is not None:
                            self.result_ready.set()
                    self._complete()
        except Exception as exc:
            self.disabled = True
            self.result_ready.set()
            self.bridge_counts["bridge_exception"] += 1
            try:
                self._bridge_seq += 1
                self._forward(encode_event("reasoning.pilot_error", self._bridge_seq,
                    dict(run_id=self.run_id, authority=self.pilot_authority.identity),
                    dict(exception_type=type(exc).__name__, message=str(exc)[:500],
                         context=self.pilot_authority.context)), True)
            except Exception:
                self.bridge_counts["exception_diagnostic_failure"] += 1
        finally:
            self.runner.stop()
            self.cleanup_ok = self.runner.close(1.3)
            try:
                for _ in range(64):
                    self._drain()
            finally:
                if self.owns_sink and not self.defer_sink_stop:
                    self.sink.stop()


_factory_lock = threading.Lock()
_factory_owner = None


def create_pilot_bridge(*, enabled=False, authority=None, verified_build_sha256=None,
                        directory=None, diagnostics=None, run_id=None, warm_worker=True, decision_budget=True):
    """No creation when disabled. Invalid/missing calibration keeps BASIC."""
    if enabled is not True or not is_pilot_authority(authority):
        return None
    if authority.game_build_sha256 != verified_build_sha256:
        return None
    if not _factory_lock.acquire(False):
        return None
    global _factory_owner
    sink = None
    try:
        if _factory_owner is not None and (_factory_owner.thread.is_alive()
                or _factory_owner.cleanup_ok is not True
                or (_factory_owner.owns_sink and (_factory_owner.sink.thread.is_alive()
                                                  or not _factory_owner.sink.reaped))):
            return None
        owned = diagnostics is None
        if owned:
            if directory is None:
                return None
            from .reasoning_diagnostics import BoundedDiagnostics
            sink = BoundedDiagnostics(directory, limits=LogLimits(records=432, bytes=6*1024*1024))
        else:
            sink = diagnostics
        bridge = PilotSelectionBridge(authority=authority, diagnostics=sink,
            verified_build_sha256=verified_build_sha256, enabled=True, run_id=run_id,
            warm_worker=warm_worker, decision_budget=decision_budget)
        bridge.owns_sink = owned
        _factory_owner = bridge
        return bridge
    except Exception:
        if diagnostics is None and sink is not None:
            sink.stop()
        return None
    finally:
        _factory_lock.release()


def observe_pilot_safely(adapter, state, config, **kwargs):
    if type(adapter) is not PilotSelectionBridge:
        return
    try:
        adapter.observe(state, config, **kwargs)
    except Exception:
        adapter.disabled = True
        adapter.bridge_counts["admission_exception"] += 1


def await_pilot_safely(adapter, state, baseline, config, **kwargs):
    operational = (type(adapter) is PilotSelectionBridge
                   and type(adapter.pilot_authority) is OperationalPilotAuthority)
    before = adapter.bridge_counts['decision_wait_started'] if operational else None
    started = time.perf_counter_ns() if operational else None
    fault = False
    try:
        result = adapter.await_decision(state, baseline, config, **kwargs)
    except Exception:
        fault = True
        adapter.disabled = True
        adapter.bridge_counts['budget_exception'] += 1
        result = 'FALLBACK'
    if operational and (before == adapter.bridge_counts['decision_wait_started'] or fault):
        adapter.budget_receipts.append(dict(started_ns=started, ended_ns=time.perf_counter_ns(),
            deadline_ns=None, reason=result, incumbent='EXISTING_CONTROLLER_BASIC',
            admission=adapter.last_admission))
    return result
