"""Explicit frozen offline probe. No game discovery/read/capture/input API."""
import json
from pathlib import Path
import time

def _crash(wire, cancel):
    raise RuntimeError('SYNTHETIC_PACKAGE_CRASH')

def _corrupt(wire, cancel):
    return b'{'

def _hang(wire, cancel):
    time.sleep(60)

def _check(value):
    if not value:
        raise AssertionError('packaged acceptance check failed')

def run(paths):
    from .reasoning_snapshot import ReasoningSnapshot
    from .reasoning_runner import make_job, create_runner
    from .reasoning_warm_runner import WarmIsolatedRunner
    from .reasoning_diagnostics import BoundedDiagnostics, DiagnosticBuffer, LogLimits, encode_event
    from .reasoning_planner import plan
    start = time.perf_counter_ns()
    _check(create_runner(enabled=False) is None)
    snap = ReasoningSnapshot.from_dict(json.loads((paths.package_root / 'resources/package_probe.json').read_text(encoding='utf-8')))
    expected = plan(snap)
    out = paths.startup_logs / 'reasoning_probe'
    out.mkdir(exist_ok=False)
    sink = BoundedDiagnostics(out / 'healthy')
    runner = WarmIsolatedRunner(diagnostics=sink)
    cases = []

    def wait(test, seconds=8):
        limit = time.monotonic() + seconds
        while not test():
            if time.monotonic() >= limit:
                raise AssertionError('packaged probe timeout')
            time.sleep(0.003)
    try:
        for generation in (1, 2):
            job = make_job(snap, deadline=time.perf_counter_ns() + 5000000000, generation=generation)
            _check(runner.submit(job))
            wait(lambda: runner.outcome is not None)
            result = runner.disposition(job, current_binding=job.binding)
            _check(result.action == (expected.proposal or snap.baseline) and (not result.input_authority))
            cases.append(dict(case='warm_healthy', generation=generation, reason=result.reason))
        _check(runner.close() and sink.flush())
        healthy = sink.buffer.stats()
        _check(sink.close())
        _check(healthy['written'] > 0 and healthy['accounting_valid'] and (not healthy['dropped_before_enqueue']))
        _check(runner.counters['processes'] == runner.counters['reaped'] == 1)
    except Exception:
        (out / 'failure.json').write_text(json.dumps(dict(counters=runner.counters, breaker=runner.breaker.reason, ipc_errors=[str(e) for e in runner.ipc_errors], errors=list(runner.errors.signatures.values()), writer=sink.buffer.stats()), indent=2), encoding='utf-8')
        raise
    finally:
        runner.close()
        sink.close()
    for name, compute in (('crash', _crash), ('corrupt', _corrupt), ('hang', _hang)):
        worker = WarmIsolatedRunner(compute=compute)
        try:
            job = make_job(snap, deadline=time.perf_counter_ns() + 5000000000)
            _check(worker.submit(job))
            if name == 'hang':
                wait(lambda: worker.active_pid is not None and worker.ready.is_set())
                result = worker.disposition(job, current_binding=job.binding, now_ns=job.deadline_ns)
            else:
                wait(lambda: worker.outcome is not None)
                result = worker.disposition(job, current_binding=job.binding)
            _check(result.action == snap.baseline and (not result.input_authority))
            stop_start = time.perf_counter_ns()
            worker.stop()
            stop_ms = (time.perf_counter_ns() - stop_start) / 1000000.0
            _check(worker.close())
            cases.append(dict(case=name, baseline_preserved=True, stop_ms=stop_ms, cleanup=True))
        finally:
            worker.close()
    dead = BoundedDiagnostics(out / 'disabled_sink')
    dead.buffer.disable('SYNTHETIC_DISK_FAILURE')
    _check(not dead.enqueue(encode_event('reasoning.fallback', 1, {}, dict(reason='SYNTHETIC')), critical=True))
    _check(dead.close())
    limits=LogLimits(records=8,bytes=8192,reserved_records=1,reserved_bytes=512,
        event_bytes=768,file_bytes=1536,files=2)
    rotating=BoundedDiagnostics(out/'rotation',limits=limits)
    try:
        for n in range(20):
            _check(rotating.enqueue(encode_event('reasoning.probe',n+1,{},dict(pad='x'*160)),critical=True))
            _check(rotating.flush())
        rotation_stats=rotating.buffer.stats();_check(rotating.close())
        logs=list((out/'rotation').glob('*.jsonl'))
        _check(0<len(logs)<=2 and all(p.stat().st_size<=limits.file_bytes for p in logs))
        _check(rotation_stats['written']==20 and rotation_stats['dropped_before_enqueue']==0)
    finally:rotating.close()
    queue=DiagnosticBuffer(LogLimits(records=2,bytes=4096,reserved_records=0,reserved_bytes=0,
        event_bytes=768,file_bytes=1536,files=2))
    event=encode_event('reasoning.probe',1,{},dict(reason='SYNTHETIC_QUEUE_FULL'))
    _check(queue.enqueue(event));_check(queue.enqueue(event));_check(not queue.enqueue(event))
    blocker=out/'not_a_directory';blocker.write_text('SYNTHETIC_WRITER_PATH_FAILURE',encoding='utf-8')
    failed=BoundedDiagnostics(blocker)
    try:
        wait(lambda:failed.buffer.disabled)
        _check(not failed.enqueue(event,critical=True))
        _check(failed.close())
    finally:failed.close()
    result = dict(status='PASS', cases=cases, healthy_counts=dict(runner.counters), healthy_log=healthy,
        rotation_files=len(logs),rotation_written=rotation_stats['written'],queue_full_rejected=True,
        actual_writer_path_failure_detected=True,disabled_sink_nonblocking=True, disabled_worker_none=True,
        processAttachment=False, windowsInput=False, gameCaptures=False, elapsed_ms=(time.perf_counter_ns() - start) / 1000000.0)
    (paths.startup_logs / 'packaged_reasoning_self_check.json').write_text(json.dumps(result, indent=2), encoding='utf-8')
    return 0
