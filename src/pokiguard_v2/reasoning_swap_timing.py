"""Explicit BASIC-only calibration telemetry; never an input authority.

Return time is an upper bound on completion of the required second click. No
executor/pacing changes or extra game reads. All disk work belongs to the
existing bounded writer process, never action or Stop.
"""
from __future__ import annotations

from dataclasses import dataclass
from pathlib import Path
import time
import threading
import uuid

from .reasoning_diagnostics import encode_event, BoundedDiagnostics, LogLimits


@dataclass(frozen=True)
class SwapTimingRequest:
    run_id: str
    config_json: str
    total_attempt_cap: int = 3

    def __post_init__(self):
        if not self.run_id or type(self.total_attempt_cap) is not int or not 1 <= self.total_attempt_cap <= 5:
            raise ValueError("bounded calibration request required")


class SwapTimingCollector:
    def __init__(self, *, sink, run_id=None, sequence=0, operational_authority=None, on_fault=None,
                 component_monitor=False, measure_skills=False):
        if type(measure_skills) is not bool or (measure_skills and operational_authority is not None
                and getattr(operational_authority, 'action_profile', None) is None):
            raise ValueError('skill timing is explicit BASIC observation only')
        if type(component_monitor) is not bool or (component_monitor and operational_authority is None):
            raise ValueError("component monitor needs validated operational authority")
        self.sink = sink
        self.run_id = run_id or uuid.uuid4().hex
        self.sequence = sequence
        self.stopped = self.disabled = False
        self.dropped = 0
        self.pending = None  # One fixed-size interval, not an unbounded sample list.
        self.measure_skills = measure_skills
        self.skill_interval = None
        self.observation = self.decision_interval = None
        self.authority, self.on_fault = operational_authority, on_fault
        self.fault_reason = None
        self.component_monitor = component_monitor
        if component_monitor:
            a = operational_authority
            c = a.reserve_components.plain()
            self.operational_metadata = dict(contract_sha256=a.contract_sha256, decision_sha256=a.decision_sha256,
                authority_sha256=a.identity, reserve_ms=a.reserve_ms, reserve_components=c,
                timing_mode="OPERATIONAL_PROJECTION")
            self.component_limits = dict(controller_tail=int(round((c["controller_tail_ms"] + c["selector_extra_ms"])*1e6)),
                final_input=int(round((c["final_input_ms"] + c["command_wait_ms"])*1e6)),
                aggregate=int(round(a.reserve_ms*1e6)))
            if a.root_read_policy is not None:
                self.operational_metadata["root_read_policy"] = a.root_read_policy.plain()

    def _fault(self, reason):
        if self.component_monitor and self.fault_reason is not None:
            return  # One first fault, identical to the existing session receipt.
        self.disabled = True
        self.fault_reason = reason
        if self.on_fault is not None:
            self.on_fault(reason)

    def observe_start(self):
        self.observation = dict(observed_ns=time.perf_counter_ns())

    def observe_end(self, *, state):
        if self.observation is not None:
            self.observation.update(observation_read_end_ns=time.perf_counter_ns(),
                raw_remaining_seconds=None if state is None else state.battle.turn_time_remaining_seconds)

    def decision(self, *, state, config, input_parameters=None, selection=None, budget=None):
        if self.stopped or self.disabled: return
        if self.decision_interval is not None:
            self._abandoned("SUPERSEDED_BEFORE_PREFLIGHT")
        from .autonomous_control import AutonomousSource
        self.decision_interval = dict(self.observation or {}, decision_exit_ns=time.perf_counter_ns(),
            decision_source_hash=AutonomousSource.from_state(state).critical_state_hash,
            input_parameters=input_parameters, selection=selection, budget=budget,
            fresh_checkpoint_ns=None, final_checkpoint_ns=None)
        if self.authority is not None and input_parameters != self.authority.input_parameters.plain():
            self._fault("INPUT_PARAMETERS_CHANGED")

    def checkpoint(self, *, name):
        if self.decision_interval is not None and name in ("fresh", "final"):
            self.decision_interval[name + "_checkpoint_ns"] = time.perf_counter_ns()

    def _abandoned(self, status):
        sample, self.decision_interval = self.decision_interval, None
        if sample is None: return
        self.sequence += 1
        raw = encode_event("reasoning.decision_timing", self.sequence,
            dict(run_id=self.run_id, mode="BASIC_CALIBRATION_ONLY" if self.authority is None else "OPERATIONAL_PILOT"),
            dict(sample, status=status, input_authority=False, native_U_ms=None, operational_fault=self.fault_reason))
        if not self.sink.enqueue(raw, critical=True):
            self.dropped += 1
            self._fault("TIMING_LOG_FAILURE")

    def start(self, *, state, config, input_mode, source_hash):
        if self.stopped or self.disabled:
            return
        from .reasoning_pilot_contract import runtime_witness
        from .board_diagnostics import jsonable
        from .reasoning_snapshot import digest
        from .autonomous_control import AutonomousSource
        try: witness = runtime_witness(state, config).plain()
        except ValueError: witness = None
        if self.component_monitor and self.authority.config_projection_policy is not None:
            from .reasoning_config_projection import project_config
            from .reasoning_source_projection import project_source
        self.pending = dict(match_id=state.battle.match_id, turn=state.battle.turn_number,
            autonomous_source=(project_source(AutonomousSource.from_state(state))
                if self.component_monitor and self.authority.config_projection_policy is not None
                else jsonable(AutonomousSource.from_state(state))),
            input_mode=input_mode, witness=witness, policy_sha256=digest(
                project_config(config) if self.component_monitor and self.authority.config_projection_policy is not None
                else jsonable(config)),
            timer_source=state.battle.turn_timer_source,
            source_hash=source_hash, preflight_start_ns=time.perf_counter_ns())
        if self.decision_interval is not None:
            self.pending.update(self.decision_interval)
            if self.decision_interval["decision_source_hash"] != source_hash:
                self.pending["decision_exit_ns"] = None
                if self.authority is not None: self._fault("DECISION_SOURCE_CHANGED")

    def preflight(self, *, remaining, failure, read_end_ns):
        if self.pending is None:
            return
        self.pending.update(read_end_ns=read_end_ns, validation_end_ns=time.perf_counter_ns(), remaining=remaining,
                            preflight_failure=failure)
        if failure is not None:
            self.finish(result=None, status="PREFLIGHT_REJECTED")

    def finish(self, *, result, status="RETURNED"):
        sample, self.pending = self.pending, None
        self.decision_interval = None
        if sample is None or self.stopped:
            return
        ended = time.perf_counter_ns()
        self.sequence += 1
        start = sample.get("preflight_start_ns")
        payload = dict(sample, executor_return_ns=ended,
            elapsed_upper_bound_ns=(None if self.component_monitor and type(start) is not int else ended-start),
            status=status, sent_clicks=None if result is None else result.sent_clicks,
            click_status=None if result is None else getattr(getattr(result, 'status', None), 'value', None),
            board_input_mode=None if result is None else getattr(result, 'input_mode', None),
            required_input_completed=bool(result is not None and result.sent_clicks == 2),
            required_input_end_kind="EXECUTOR_RETURN_UPPER_BOUND_NOT_EXACT_CLICK_TIMESTAMP",
            clock="host.perf_counter_ns",
            clock_uncertainty_ms=None, native_timer_bound="UNBOUND", input_authority=False,
            operational_fault=self.fault_reason)
        decision_exit = sample.get("decision_exit_ns")
        if self.component_monitor and (type(decision_exit) is not int or type(start) is not int):
            decision_exit = None
        payload.update(controller_tail_ns=None if decision_exit is None else start-decision_exit,
            full_tail_ns=None if decision_exit is None else ended-decision_exit,
            first_input_ns=None, first_input_status="NOT_MEASURED", native_U_ms=None)
        if self.authority is not None:
            a = self.authority
            if self.component_monitor:
                payload.update(self.operational_metadata)
            else:
                payload.update(contract_sha256=a.contract_sha256, decision_sha256=a.decision_sha256,
                    authority_sha256=a.identity, reserve_ms=a.reserve_ms, reserve_components=a.reserve_components.plain(),
                    timing_mode="OPERATIONAL_PROJECTION")
            if self.component_monitor:
                self._monitor_components(payload, sample, ended)
            elif (decision_exit is None or not decision_exit <= sample["preflight_start_ns"] <= ended
                    or (ended-decision_exit)/1e6 > a.reserve_ms):
                payload["reserve_overrun"] = True
                self._fault("RESERVE_OVERRUN_OR_UNBOUND")
        raw = encode_event("reasoning.swap_timing", self.sequence,
                           dict(run_id=self.run_id, mode="BASIC_CALIBRATION_ONLY" if self.authority is None else "OPERATIONAL_PILOT"), payload)
        if not self.sink.enqueue(raw, critical=True):
            self._fault("TIMING_LOG_FAILURE")
            self.dropped += 1

    def _monitor_components(self, payload, sample, ended):
        """Post-return AI breaker only; no reads, input, replay or ACK changes."""
        limits = self.component_limits
        times = [sample.get(k) for k in ("decision_exit_ns", "preflight_start_ns",
                                        "read_end_ns", "validation_end_ns")] + [ended]
        valid = all(type(t) is int and t >= 0 for t in times) and times == sorted(times)
        flags = dict(invalid_interval=not valid, controller_tail=False, final_input=False, aggregate=False)
        if valid:
            flags.update(controller_tail=times[1]-times[0] > limits["controller_tail"],
                         final_input=times[-1]-times[1] > limits["final_input"],
                         aggregate=times[-1]-times[0] > limits["aggregate"])
        reason = next(("TIMING_" + name.upper() for name, flagged in flags.items() if flagged), None)
        policy=getattr(self.authority,'component_guard_policy',None)
        if policy is not None:
            from .reasoning_component_guard import VERSION,debit_guard
            if policy!=VERSION:raise ValueError('unknown component guard policy')
            guard=None
            if valid:
                guard=debit_guard(times[1]-times[0],times[-1]-times[1],
                    limits['controller_tail'],limits['final_input'],
                    int(round(self.authority.reserve_components.plain()['host_guard_ms']*1e6)))
            payload['component_guard']=guard
            payload['component_guard_policy']=VERSION
            reason=('TIMING_INVALID_INTERVAL' if not valid else 'TIMING_AGGREGATE' if flags['aggregate']
                    else 'TIMING_SHARED_GUARD_EXHAUSTED' if guard['exhausted'] else None)
        if reason is not None:
            self._fault(reason)
        payload.update(component_monitor="POST_RETURN_COMPONENTS_V1", component_limits_ns=limits,
                       component_overruns=flags, component_fault=reason,
                       reserve_overrun=flags["invalid_interval"] or flags["aggregate"],
                       operational_fault=self.fault_reason)

    def skill_start(self, *, match_id, turn, source_hash, skill_card_id):
        if not self.measure_skills or self.stopped or self.disabled:
            return
        if self.skill_interval is not None:
            self.dropped += 1
            self._fault('TIMING_OVERLAPPING_SKILL')
            return
        sample, self.decision_interval = self.decision_interval, None
        self.skill_interval = dict(sample or {}, primitive_start_ns=time.perf_counter_ns(),
            match_id=match_id, turn=turn, source_hash=source_hash, skill_card_id=skill_card_id)

    def skill_finish(self, *, result=None, status='RETURNED'):
        sample, self.skill_interval = self.skill_interval, None
        if sample is None:
            return
        end = time.perf_counter_ns()
        start, decision = sample['primitive_start_ns'], sample.get('decision_exit_ns')
        bound = (type(decision) is int and 0 <= decision <= start <= end
            and sample.get('decision_source_hash') == sample['source_hash'])
        sample.update(executor_return_ns=end, status=status,
            clock='host.perf_counter_ns', complete_interval_bound=bound,
            controller_tail_ns=start-decision if bound else None,
            full_primitive_ns=end-start, full_tail_ns=end-decision if bound else None,
            result_kind=None if result is None else result.kind.value,
            card_clicks=None if result is None else result.card_clicks,
            space_presses=None if result is None else result.space_presses,
            first_click_ns=None, first_click_status='NOT_MEASURED',
            coverage='WHOLE_EXISTING_PRIMITIVE_UPPER_COMPLETION_NOT_NEW_QTE_FLOW',
            input_authority=False)
        if self.authority is not None:
            monitored_input_ns=sample['full_primitive_ns']
            from .reasoning_mega import is_mega
            if is_mega(self.authority):
                from .reasoning_mega_timing import required_input_ns
                monitored_input_ns=required_input_ns(sample)
                sample.update(required_input_ns=monitored_input_ns,
                    reserve_coverage='MEGA_REQUIRED_CLICK_PADDED_ELAPSED_READONLY_RECORDED_SEPARATELY')
                if monitored_input_ns is None:self._fault('D4_SKILL_REQUIRED_INPUT_UNPROVEN')
            monitored_valid=bound and monitored_input_ns is not None
            if (not monitored_valid or status != 'RETURNED'
                    or sample['controller_tail_ns']+monitored_input_ns > self.authority.reserve_ms*1e6):
                self._fault('D2_SKILL_TIMING_INVALID_OR_RESERVE_EXCEEDED')
            if monitored_valid and self.authority.component_guard_policy is not None:
                from .reasoning_component_guard import debit_guard, VERSION
                components=self.authority.reserve_components.plain()
                guard=debit_guard(sample['controller_tail_ns'],monitored_input_ns,
                    int(round((components['controller_tail_ms']+components['selector_extra_ms'])*1e6)),
                    int(round((components['final_input_ms']+components['command_wait_ms'])*1e6)),
                    int(round(components['host_guard_ms']*1e6)))
                if guard['exhausted']:self._fault('D2_SKILL_SHARED_GUARD_EXHAUSTED')
                sample.update(component_guard=guard,component_guard_policy=VERSION)
            sample.update(operational_fault=self.fault_reason, timing_mode='OPERATIONAL_PROJECTION',
                reserve_ms=self.authority.reserve_ms)
        self.sequence += 1
        raw = encode_event('reasoning.skill_timing', self.sequence,
            dict(run_id=self.run_id, mode=('BASIC_CALIBRATION_ONLY' if self.authority is None else 'OPERATIONAL_PILOT')), sample)
        if not self.sink.enqueue(raw, critical=True):
            self.dropped += 1
            self._fault('TIMING_LOG_FAILURE')

    def stop(self):
        try:
            if self.skill_interval is not None:
                self.skill_finish(status='STOP_OR_CONTROLLER_EXIT')
            if self.pending is not None:
                self.finish(result=None, status="STOP_OR_CONTROLLER_EXIT")
            else:
                self._abandoned("STOP_OR_CONTROLLER_EXIT")
        except Exception:
            self._fault("TIMING_EXCEPTION")
            self.dropped += 1
        finally:
            self.stopped = True
            self.pending = None


def timing_safely(adapter, method, **kwargs):
    if type(adapter) is not SwapTimingCollector:
        if adapter is None:
            return
        from .reasoning_mega_timing import MegaClickTimingCollector
        if type(adapter) is not MegaClickTimingCollector:
            return
    try:
        getattr(adapter, method)(**kwargs)
    except Exception:
        adapter._fault("TIMING_EXCEPTION")
        adapter.dropped += 1


def operational_preflight_failure(adapter, *, read_end_ns, input_parameters):
    """Veto using host data at the existing preflight, without a new game read."""
    if type(adapter) is not SwapTimingCollector:
        from .reasoning_mega_timing import MegaClickTimingCollector
        if type(adapter) is not MegaClickTimingCollector:return None
    if adapter.authority is None:
        return None
    reason = None
    try:
        a = adapter.authority
        if adapter.disabled or adapter.stopped or adapter.pending is None:
            reason = "OPERATIONAL_TIMING_UNAVAILABLE"
        elif input_parameters != a.input_parameters.plain():
            reason = "OPERATIONAL_INPUT_PARAMETERS_CHANGED"
        elif not 0 <= read_end_ns - adapter.pending['preflight_start_ns'] <= a.max_read_span_ms*1e6:
            reason = "OPERATIONAL_READ_SPAN_EXCEEDED"
    except Exception:
        reason = "OPERATIONAL_TIMING_UNAVAILABLE"
    if reason is not None: adapter._fault(reason)
    return reason


class SwapTimingSession:
    """One explicit run, with existing FarmRun all-attempt cap unchanged."""
    def __init__(self, request, *, config, directory: Path, measure_skills=False):
        from .basic_policy import Intelligence
        from .board_diagnostics import jsonable
        from .reasoning_snapshot import canonical_json
        if (type(request) is not SwapTimingRequest or config.intelligence is not Intelligence.BASIC
                or config.ai.shadow_enabled or config.max_match_attempts != request.total_attempt_cap
                or config.target_completed_matches > request.total_attempt_cap
                or canonical_json(jsonable(config)) != request.config_json):
            raise ValueError("explicit frozen BASIC-only calibration cohort/cap required")
        self.request = request
        self.measure_skills = measure_skills
        self.directory = Path(directory)
        self.binding = None
        self.finalizer = None
        self.finalize_requested = threading.Event()
        self.prior_dropped = 0
        self.stopped = False
        self.sink = BoundedDiagnostics(directory, limits=LogLimits(records=432, bytes=6*1024*1024))
        self.collector = SwapTimingCollector(sink=self.sink, run_id=request.run_id,
            measure_skills=measure_skills)

    def bind_run(self, farm_run_id, directory):
        """Setup-only ledger link; never called from an action or Stop."""
        import json
        if self.binding is not None:
            raise ValueError('one FarmRun per calibration session')
        self.binding = dict(run_id=self.request.run_id, farm_run_id=farm_run_id,
            farm_directory=str(Path(directory).resolve()), config_json=self.request.config_json,
            total_attempt_cap=self.request.total_attempt_cap, input_authority=False)
        self.directory.mkdir(parents=True, exist_ok=True)
        with (self.directory / 'session.json').open('x', encoding='utf-8') as output:
            json.dump(self.binding, output, ensure_ascii=False, indent=2)
        self.finalizer = threading.Thread(target=self._finalize, name='reasoning-timing-finalize', daemon=True)
        self.finalizer.start()

    def _finalize(self):
        """Bounded durability receipt off the controller/Stop caller."""
        import json
        self.finalize_requested.wait()
        receipt = dict(run_id=self.request.run_id, flushed=False, closed=False)
        try:
            receipt['flushed'] = self.sink.flush(.5)
            receipt['before_close'] = self.sink.buffer.stats()
        except Exception as exc:
            receipt['error'] = type(exc).__name__
        finally:
            try:
                self.sink.stop()
                receipt['closed'] = self.sink.close(1.3)
                receipt['after_close'] = self.sink.buffer.stats()
            except Exception as exc:
                receipt['cleanup_error'] = type(exc).__name__
        receipt.update(sequence=self.collector.sequence,
            collector_dropped=self.prior_dropped+self.collector.dropped,
            collector_disabled=self.collector.disabled)
        try:
            with (self.directory / 'watermarks.json').open('x', encoding='utf-8') as output:
                json.dump(receipt, output, indent=2)
        except Exception:
            pass  # Missing receipt is unconfirmed durability, never accepted.

    def prepare_options(self):
        if self.stopped:
            return {}
        if self.collector.stopped:
            previous_sequence = self.collector.sequence
            self.prior_dropped += self.collector.dropped
            self.collector = SwapTimingCollector(sink=self.sink, run_id=self.request.run_id,
                measure_skills=self.measure_skills)
            self.collector.sequence = previous_sequence
        return dict(swap_timing_adapter=self.collector)

    def stop(self):
        self.stopped = True
        self.collector.stop()
        if self.finalizer is None:
            self.sink.stop()
        else:
            self.finalize_requested.set()  # No flush/join/disk on Stop.


def prepare_reasoning_options_safely(session):
    try:
        options = session.prepare_options()
        return options if type(options) is dict and set(options) <= {
            "selection_adapter", "swap_timing_adapter"} else {}
    except Exception:
        return {}
