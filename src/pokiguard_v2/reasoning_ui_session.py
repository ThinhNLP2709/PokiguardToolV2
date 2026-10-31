"""Normal UI reasoning owner: one active bridge, bounded run-wide diagnostics.

Only existing combat setup receives options. Action/Stop never flush, join,
read game state, or wait for a successor to clean up. This is independent of
historical one-shot pilot claims and does not reopen their attempt ledgers.
"""
from collections import Counter,deque
from dataclasses import dataclass
import json
from pathlib import Path
import threading
import time
import uuid

from .reasoning_settings import AIStatus,FrozenAIIntent


@dataclass(frozen=True)
class _Combat:
    index:int
    bridge:object
    collector:object


class UIReasoningSession:
    def __init__(self,config,authority,*,directory,observer,bridge_factory=None,sink_factory=None):
        self.config=config;self.authority=authority;self.directory=Path(directory);self.observer=observer
        self.intent=FrozenAIIntent.freeze(config);self.run_id=uuid.uuid4().hex
        self.bridge_factory=bridge_factory;self.sink_factory=sink_factory
        self.lock=threading.Lock();self.stop_event=threading.Event();self.closed=threading.Event()
        self.bundle=None;self.sink=None;self.finalizer=None;self.bound=False;self.faulted=False;self.first_fault=None
        self.serial=0;self.sequence=0;self.prepare_calls=0;self.totals=Counter();self.retired=deque(maxlen=32)
        self.last_status=None;self.last_publish=0.0
        self.cleanup_ok=None

    def _publish(self,state,reason,*,force=False):
        try:
            stats=self.sink.buffer.stats() if self.sink is not None else {}
            active=self.bundle
            completed=self.totals['completed']+(active.bridge.runner.counters.get('completed',0) if active else 0)
            status=AIStatus(state,reason,self.intent.config_id,completed,
                suggestion='Đã suy luận xong' if completed else '',
                dropped=sum(stats.get(k,0) for k in ('dropped_before_enqueue','failed_write','discarded_after_enqueue')),
                written=stats.get('written',0),queued=stats.get('queued',0),faults=int(self.faulted),
                accounting_valid=stats.get('accounting_valid',False),
                selection_authority=not self.faulted and not self.stop_event.is_set()
                    and state not in ('UNSUPPORTED','DEGRADED','STOPPED'))
            if force or status!=self.last_status:
                self.last_status=status;self.observer(status,'AI_STATUS')
        except Exception:
            pass  # A display observer has no authority over gameplay.

    def _fault(self,reason):
        if not self.faulted:self.first_fault=str(reason)[:160]
        self.faulted=True
        bundle=self.bundle
        if bundle is not None:
            bundle.bridge.disabled=True
            bundle.bridge.result_ready.set()
        self._publish('DEGRADED',self.first_fault or 'UI_REASONING_UNAVAILABLE',force=True)

    def bind_run(self,farm_run_id,directory):
        try:
            self._bind_run(farm_run_id,directory)
        except Exception as exc:
            self._fault('UI_REASONING_BIND_'+type(exc).__name__)
            self.stop()
            raise

    def _bind_run(self,farm_run_id,directory):
        if self.bound or self.stop_event.is_set():raise ValueError('UI reasoning already bound/stopped')
        from .reasoning_diagnostics import BoundedDiagnostics,LogLimits
        self.directory.mkdir(parents=True,exist_ok=False)
        binding=dict(schema='pokiguard.ui_reasoning.session.v1',run_id=self.run_id,
            farm_run_id=farm_run_id,farm_directory=str(Path(directory).resolve()),
            config_id=self.intent.config_id,profile='DEMON_SHIELD_LIEYUN77',native_U_ms=None,
            runtime_sha256=self.authority.runtime_sha256,calibration_sha256=self.authority.calibration_sha256,
            max_live_bridges=1,receipt_history_limit=32,input_authority=False)
        (self.directory/'session.json').write_text(json.dumps(binding,indent=2),encoding='utf-8')
        factory=self.sink_factory or BoundedDiagnostics
        self.sink=factory(self.directory,limits=LogLimits(records=432,bytes=6*1024*1024))
        self.bound=True
        self.finalizer=threading.Thread(target=self._supervise,name='ui-reasoning-lifecycle',daemon=True)
        self.finalizer.start();self._publish('WAITING','UI_REASONING_WAITING_COMBAT',force=True)

    def prepare_options(self):
        if self.stop_event.is_set() or self.faulted or not self.bound:return {}
        if not self.lock.acquire(False):return {}
        try:
            self.prepare_calls+=1
            if self.stop_event.is_set() or self.faulted:return {}
            if time.perf_counter_ns()>=self.authority.valid_until_ns:
                self._fault('UI_REASONING_EXPIRED_BASIC');return {}
            if self.bundle is not None:
                if self.bundle.bridge.stopped:
                    self._publish('WAITING','UI_REASONING_CLEANUP_PENDING');return {}
                self._fault('UI_REASONING_PREVIOUS_COMBAT_ACTIVE');return {}
            if self.sink.buffer.disabled:
                self._fault('UI_REASONING_DIAGNOSTICS_UNAVAILABLE');return {}
            if self.serial>=self.config.max_match_attempts:
                self._fault('UI_REASONING_RESOURCE_LIMIT');return {}
            from .reasoning_pilot import create_pilot_bridge
            from .reasoning_swap_timing import SwapTimingCollector
            factory=self.bridge_factory or create_pilot_bridge
            combat_run_id=f'{self.run_id}:{self.serial+1}'
            bridge=factory(enabled=True,authority=self.authority,
                verified_build_sha256=self.authority.game_build_sha256,diagnostics=self.sink,
                run_id=combat_run_id,warm_worker=True,decision_budget=True)
            if bridge is None:
                self._publish('DEGRADED','UI_REASONING_WORKER_UNAVAILABLE');return {}
            collector=SwapTimingCollector(sink=bridge.timing_diagnostics,run_id=combat_run_id,
                sequence=self.sequence,operational_authority=self.authority,
                on_fault=self._fault,component_monitor=True)
            self.serial+=1;self.bundle=_Combat(self.serial,bridge,collector)
            if self.stop_event.is_set():
                collector.stop();bridge.stop();return {}
            self._publish('REASONING','UI_REASONING_READY',force=True)
            return dict(selection_adapter=bridge,swap_timing_adapter=collector)
        except Exception as exc:
            self._fault('UI_REASONING_SETUP_'+type(exc).__name__);return {}
        finally:self.lock.release()

    def stop(self):
        self.stop_event.set()
        bundle=self.bundle
        if bundle is not None:
            try:bundle.collector.stop()
            except Exception:pass
            try:bundle.bridge.stop()
            except Exception:pass
        if self.finalizer is None:
            if self.sink is not None:self.sink.stop()
            self.cleanup_ok=self.sink is None
            self.closed.set()

    def wait_closed(self,timeout=5.0):
        """Only the background UI shutdown owner/tests may call this."""
        if self.finalizer is None and self.sink is not None:
            self.cleanup_ok=self.sink.close(timeout)
        return self.closed.wait(timeout) and self.cleanup_ok is True

    def _retire(self,bundle):
        # Called with the lifecycle lock, exclusively off action/Stop threads.
        bridge=bundle.bridge
        ended=bridge.close(1.3);flushed=self.sink.flush(2.0)
        stats=self.sink.buffer.stats();counts=dict(bridge.runner.counters)
        healthy=(ended and flushed and bundle.collector.stopped and not bridge.disabled and not bundle.collector.disabled
            and bundle.collector.dropped==0 and stats.get('accounting_valid')
            and stats['eligible']==stats['written']
            and all(stats[k]==0 for k in ('dropped_before_enqueue','failed_write','discarded_after_enqueue','queued','in_writer')))
        self.sequence=bundle.collector.sequence
        self.totals.update(counts)
        self.retired.append(dict(combat_index=bundle.index,combat_run_id=f'{self.run_id}:{bundle.index}',
            bridge_closed=ended,flushed=flushed,
            healthy=bool(healthy),worker_counts=counts,selection_counts=dict(bridge.counts),
            collector_sequence=self.sequence,collector_dropped=bundle.collector.dropped))
        if not healthy:self._fault('UI_REASONING_CLEANUP_UNCONFIRMED')
        # No successor exists and the former producer is dead. Transfer the
        # single-producer sink only after full drain, while setup is excluded.
        if healthy:
            with self.sink.buffer.lock:
                if self.sink.buffer.producing:raise RuntimeError('diagnostic producer still active')
                self.sink.buffer.producer=None
        self.bundle=None

    def _supervise(self):
        receipt={}
        try:
            while not self.stop_event.wait(.02):
                if self.lock.acquire(False):
                    try:
                        bundle=self.bundle
                        if bundle is not None and bundle.bridge.disabled and not self.faulted:
                            self._fault('UI_REASONING_WORKER_OR_SELECTION_FAULT')
                        if (bundle is not None and bundle.bridge.stopped and bundle.collector.stopped
                                and not bundle.bridge.thread.is_alive()):
                            self._retire(bundle)
                    finally:self.lock.release()
                if self.faulted and self.bundle is None:break
                if time.monotonic()-self.last_publish>=.5:
                    self.last_publish=time.monotonic()
                    observation=self.bundle.bridge.observation if self.bundle else None
                    try:mismatch=observation is not None and not self.authority.matches(observation[0],observation[1])
                    except Exception:mismatch=True
                    self._publish('DEGRADED' if self.faulted else 'UNSUPPORTED' if mismatch else 'REASONING' if self.bundle else 'WAITING',
                        self.first_fault if self.faulted else
                        'UI_REASONING_COHORT_CHANGED' if mismatch else
                        'UI_REASONING_COMPLETED' if self.bundle and self.bundle.bridge.runner.counters.get('completed',0)
                        else 'UI_REASONING_WAITING_TURN')
            with self.lock:
                if self.bundle is not None:self._retire(self.bundle)
            receipt['flushed']=self.sink.flush(2.0)
        except Exception as exc:
            self._fault('UI_REASONING_FINALIZER_'+type(exc).__name__)
            receipt['error']=type(exc).__name__
        finally:
            try:
                self.sink.stop();receipt['closed']=self.sink.close(1.3)
                receipt['stats']=self.sink.buffer.stats()
            except Exception as exc:receipt['cleanup_error']=type(exc).__name__
            receipt.update(schema='pokiguard.ui_reasoning.watermarks.v1',run_id=self.run_id,
                faulted=self.faulted,first_fault=self.first_fault,sequence=self.sequence,
                combats_created=self.serial,worker_counts=dict(self.totals),
                recent_combats=list(self.retired),history_truncated=self.serial>len(self.retired),
                bounded_history=32,input_authority=False,native_U_ms=None)
            try:(self.directory/'watermarks.json').write_text(json.dumps(receipt,indent=2),encoding='utf-8')
            except Exception:pass  # Missing receipt is unconfirmed durability.
            self.cleanup_ok=bool(receipt.get('closed') and self.bundle is None
                and self.totals['processes']==self.totals['reaped'])
            self._publish('DEGRADED' if self.faulted else 'STOPPED',
                self.first_fault if self.faulted else 'UI_REASONING_STOPPED',force=True)
            self.closed.set()


def create_ui_reasoning_session(config,*,paths,game_executable,directory,observer,profile_loader=None):
    if not config.ai.reasoning_enabled:return None
    from .reasoning_ui_scope import ui_reasoning_scope_reason
    reason=ui_reasoning_scope_reason(config,require_target=True)
    try:
        if reason is not None:raise ValueError(reason)
        from .reasoning_ui_profile import load_ui_authority
        authority=(profile_loader or load_ui_authority)(config,paths=paths,game_executable=game_executable)
        return UIReasoningSession(config,authority,directory=directory,observer=observer)
    except Exception as exc:
        reason=str(exc) if str(exc).startswith('UI_REASONING_') else 'UI_REASONING_PROFILE_'+type(exc).__name__
        try:observer(AIStatus('UNSUPPORTED' if isinstance(exc,(ValueError,FileNotFoundError)) else 'DEGRADED',reason[:160]),'AI_STATUS')
        except Exception:pass
        return None
