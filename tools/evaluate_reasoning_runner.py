"""B4 file-only measurement: micro timings, isolated faults, resource stability.

Never attaches the game. Only own/known child PIDs are sampled for resources.
"""
from __future__ import annotations

import argparse
from collections import deque
from dataclasses import replace
import ctypes
from ctypes import wintypes
import hashlib
import json
import math
import os
from pathlib import Path
import platform
import sys
import time

ROOT = Path(__file__).resolve().parents[1]
sys.path.insert(0, str(ROOT / "src"))
sys.path.insert(0, str(ROOT))

from pokiguard_v2.reasoning_diagnostics import (
    BoundedDiagnostics, DiagnosticBuffer, LogLimits, encode_event,
)
from pokiguard_v2.reasoning_runner import IsolatedRunner, create_runner, make_job
from tools.evaluate_reasoning_planner import snapshot
from tests import reasoning_worker_fixtures as fault


def quantiles(values):
    ordered = sorted(values)
    return dict(n=len(values), p50=ordered[math.ceil(len(values)*.50)-1],
                p95=ordered[math.ceil(len(values)*.95)-1],
                p99=ordered[math.ceil(len(values)*.99)-1], max=max(values))


def dump(path, value):
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(json.dumps(value, ensure_ascii=False, indent=2, allow_nan=False), encoding="utf-8")


def wait_for(predicate, timeout=6):
    end = time.perf_counter() + timeout
    while time.perf_counter() < end:
        if predicate():
            return
        time.sleep(.002)
    raise RuntimeError("bounded offline wait exhausted")


def make(s, milliseconds=5000):
    return make_job(s, deadline=time.perf_counter_ns()+int(milliseconds*1e6))


def metadata():
    clock = time.get_clock_info("perf_counter")
    paths = ["src/pokiguard_v2/reasoning_runner.py", "src/pokiguard_v2/reasoning_diagnostics.py",
             "tests/reasoning_worker_fixtures.py", "tests/test_reasoning_runner.py",
             "tools/evaluate_reasoning_runner.py"]
    return dict(schema="pokiguard.reasoning.b4_measurement.v1", python=sys.version,
        platform=platform.platform(), logical_cpus=os.cpu_count(), clock=vars(clock),
        monotonic_authority="host", input_authority=False, game_attach=False,
        source_hashes={p:hashlib.sha256((ROOT/p).read_bytes()).hexdigest() for p in paths},
        immutable_snapshot_fixture="tools.evaluate_reasoning_planner.snapshot (SYNTHETIC)")


def timed(fn):
    begin = time.perf_counter_ns()
    fn()
    return (time.perf_counter_ns()-begin)/1e6


def benchmark(out):
    """3 interleaved runs x10k, 1k separate warmup; paired raw values retained.

    Enqueue is deliberately saturated stress, not healthy workload. Copy/hash
    preparation is off-path and measured separately, not hidden in shadow proof.
    """
    s = snapshot()
    records = []
    summary = metadata()
    summary["protocol"] = dict(runs=3, measured=10000, warmup=1000,
        modes=["disabled", "submit", "shared", "separate", "lock_busy", "queue_full"],
        raw_units="milliseconds", overload="explicit saturated enqueue; drop counters expected",
        integration_shadow_slo="NOT_MEASURED; prepared-job submit only")
    for repeat in range(3):
        order = ["disabled", "submit", "shared", "separate", "lock_busy", "queue_full"]
        order = order[repeat:] + order[:repeat]
        for mode in order:
            print(f"benchmark run={repeat} mode={mode}", flush=True)
            d = None
            r = None
            b = None
            prep = []
            try:
                if mode in {"shared", "separate"}:
                    d = BoundedDiagnostics(out/"logs"/f"{repeat}-{mode}", stem="shared" if mode == "shared" else "reasoning")
                    b = d.buffer
                elif mode in {"lock_busy", "queue_full"}:
                    b = DiagnosticBuffer()
                if mode == "lock_busy":
                    b.lock.acquire()
                if mode == "queue_full":
                    for _ in range(512):
                        b.enqueue(b"{}\n", critical=True)
                if mode == "submit":
                    r = IsolatedRunner(compute=fault.cooperative)
                raw = encode_event("reasoning.decision", 1, {}, dict(mode="OFFLINE", disposition="RETAIN_BASELINE"))
                rows = []
                # Chunk preparation keeps every prebuilt job within its absolute deadline.
                for chunk in range(110):
                    jobs = []
                    if r is not None:
                        for _ in range(100):
                            start = time.perf_counter_ns()
                            jobs.append(make(s))
                            prep.append((time.perf_counter_ns()-start)/1e6)
                    for i in range(100):
                        control = lambda: s.baseline
                        if mode == "disabled":
                            operation = lambda: (create_runner(enabled=False), s.baseline)
                        elif mode == "submit":
                            operation = lambda: (r.submit(jobs[i]), s.baseline)
                        else:
                            operation = lambda: b.enqueue(raw)
                        if (chunk+i) % 2:
                            value, baseline = timed(operation), timed(control)
                        else:
                            baseline, value = timed(control), timed(operation)
                        row = dict(run=repeat, mode=mode, warmup=chunk < 10,
                                   control_ms=baseline, value_ms=value, delta_ms=value-baseline)
                        rows.append(row)
                records.extend(rows)
                measured = [x for x in rows if not x["warmup"]]
                item = dict(value=quantiles([x["value_ms"] for x in measured]),
                            paired_delta=quantiles([x["delta_ms"] for x in measured]))
                if prep:
                    item["prepare_ms"] = quantiles(prep)
                if b is not None and mode != "lock_busy":
                    if d is not None:
                        d.flush()
                    item["accounting"] = b.stats()
                summary.setdefault("runs", []).append(dict(run=repeat, mode=mode, **item))
            finally:
                if mode == "lock_busy" and b is not None:
                    b.lock.release()
                if r is not None and not r.close():
                    raise RuntimeError("runner cleanup failed")
                if d is not None and not d.close():
                    raise RuntimeError("logger cleanup failed")
    with (out/"micro_raw.jsonl").open("w", encoding="utf-8") as output:
        for row in records:
            output.write(json.dumps(row, separators=(",", ":"))+"\n")
    # Real planner: serialization + process start + IPC/compute + validation.
    r = IsolatedRunner()
    try:
        for _ in range(30):
            j = make(s)
            r.submit(j)
            wait_for(lambda: r.outcome is not None)
            if r.outcome[0] is None:
                raise RuntimeError("positive planner control failed: " + str(r.outcome))
            wait_for(lambda: r.active_job is None)
        summary["real_runner_raw_ns"] = list(r.timings)
        summary["real_runner_ms"] = {key:quantiles([row[key]/1e6 for row in r.timings])
            for key in ("serialize_ns", "spawn_ns", "startup_ns", "compute_ns", "ipc_and_compute_ns", "validation_ns", "total_ns")}
    finally:
        if not r.close():
            raise RuntimeError("real runner cleanup failed")
    dump(out/"benchmark.json", summary)


def fault_trials(out):
    s = snapshot()
    result = metadata()
    rows = []
    for fn in (fault.retain, fault.crash, fault.corrupt, fault.oversize, fault.nonfinite,
               fault.mismatch, fault.raises, fault.hang, fault.cooperative):
        print("fault variant="+fn.__name__, flush=True)
        for trial in range(30):
            r = IsolatedRunner(compute=fn)
            j = make(s, 350 if fn in (fault.hang, fault.cooperative) else 5000)
            try:
                r.submit(j)
                wait_for(lambda: r.outcome is not None)
                before = time.perf_counter_ns()
                d = r.disposition(j, current_binding=j.binding)
                disposition_ns = time.perf_counter_ns()-before
                if d.action != s.baseline or d.used_proposal or d.input_authority:
                    raise RuntimeError("fault escaped baseline boundary")
                after = r.disposition(j, current_binding=j.binding, input_sent=True)
                invalid = r.disposition(j, current_binding=None)
                if after.action is not None or invalid.action is not None:
                    raise RuntimeError("fault escaped ownership/source guard")
            finally:
                before = time.perf_counter_ns()
                reaped = r.close()
                cleanup_ns = time.perf_counter_ns()-before
                if not reaped:
                    raise RuntimeError("orphan compute worker")
            rows.append(dict(variant=fn.__name__, trial=trial, disposition_ns=disposition_ns,
                cleanup_ns=cleanup_ns, counters=dict(r.counters), cleanup=list(r.cleanups),
                reason=d.reason, after_input_action=None, invalid_source_action=None))
    for trial in range(100):
        logging_full = None
        if trial % 5 == 0:
            logging_full = BoundedDiagnostics(out/"stop_full_logs", writer_target=fault.log_hang)
            for _ in range(512):
                logging_full.enqueue(b"{}\n", critical=True)
        fn = fault.hang if trial % 3 else fault.cooperative
        r = IsolatedRunner(compute=fn)
        j = make(s)
        r.submit(j)
        if trial % 4:
            wait_for(lambda: r.active_pid is not None)
        if trial % 2:
            r.submit(make(s))
        before = time.perf_counter_ns()
        r.stop()
        if logging_full is not None:
            logging_full.stop()
        stop_ns = time.perf_counter_ns()-before
        if r.disposition(j, current_binding=j.binding).action is not None or not r.close():
            raise RuntimeError("Stop boundary failed")
        rows.append(dict(variant="stop", trial=trial, stop_ns=stop_ns,
                         counters=dict(r.counters), cleanup=list(r.cleanups)))
        if logging_full is not None and not logging_full.close():
            raise RuntimeError("orphan logfull writer at Stop")
    for fn in (fault.log_denied, fault.log_disk_full, fault.log_hang, fault.log_crash):
        for trial in range(30):
            d = BoundedDiagnostics(out/"fault_logs"/fn.__name__, writer_target=fn)
            d.enqueue(b"{}\n")
            if fn is not fault.log_hang:
                wait_for(lambda: d.buffer.disabled)
            before = time.perf_counter_ns()
            d.stop()
            stop_ns = time.perf_counter_ns()-before
            before = time.perf_counter_ns()
            reaped = d.close()
            cleanup_ns = time.perf_counter_ns()-before
            stats = d.buffer.stats()
            if not reaped or not stats["accounting_valid"] or stats["written"]:
                raise RuntimeError("diagnostic fault/cleanup accounting failed")
            rows.append(dict(variant=fn.__name__, trial=trial, stop_ns=stop_ns,
                             cleanup_ns=cleanup_ns, accounting=stats))
    result["trials"] = rows
    result["fault_disposition_ms"] = quantiles([x["disposition_ns"]/1e6 for x in rows if "disposition_ns" in x])
    result["stop_ms"] = quantiles([x["stop_ns"]/1e6 for x in rows if "stop_ns" in x])
    result["cleanup_ms"] = quantiles([x["cleanup_ns"]/1e6 for x in rows if "cleanup_ns" in x])
    result["all_reaped"] = True
    dump(out/"faults.json", result)


class ProcessMemory(ctypes.Structure):
    _fields_ = [("cb", wintypes.DWORD), ("PageFaultCount", wintypes.DWORD)] + [
        (name, ctypes.c_size_t) for name in ("PeakWorkingSetSize", "WorkingSetSize", "QuotaPeakPagedPoolUsage",
        "QuotaPagedPoolUsage", "QuotaPeakNonPagedPoolUsage", "QuotaNonPagedPoolUsage", "PagefileUsage",
        "PeakPagefileUsage", "PrivateUsage")]


def own_process_resources(pid):
    # The caller supplies only this harness PID or its own worker PID, never a game PID.
    kernel = ctypes.WinDLL("kernel32", use_last_error=True)
    psapi = ctypes.WinDLL("psapi", use_last_error=True)
    kernel.OpenProcess.argtypes = (wintypes.DWORD, wintypes.BOOL, wintypes.DWORD)
    kernel.OpenProcess.restype = wintypes.HANDLE
    kernel.CloseHandle.argtypes = (wintypes.HANDLE,)
    psapi.GetProcessMemoryInfo.argtypes = (wintypes.HANDLE, ctypes.POINTER(ProcessMemory), wintypes.DWORD)
    kernel.GetProcessTimes.argtypes = (wintypes.HANDLE,) + (ctypes.POINTER(wintypes.FILETIME),)*4
    handle = kernel.OpenProcess(0x0400 | 0x0010, False, pid)
    if not handle:
        return None
    try:
        memory = ProcessMemory()
        memory.cb = ctypes.sizeof(memory)
        values = [wintypes.FILETIME() for _ in range(4)]
        if not psapi.GetProcessMemoryInfo(handle, ctypes.byref(memory), memory.cb):
            return None
        kernel.GetProcessTimes(handle, *(ctypes.byref(v) for v in values))
        ticks = sum((v.dwHighDateTime << 32) + v.dwLowDateTime for v in values[2:])
        return dict(private_bytes=memory.PrivateUsage, working_bytes=memory.WorkingSetSize,
                    cpu_ns=ticks*100, pid=pid)
    finally:
        kernel.CloseHandle(handle)


def soak(out, seconds):
    if os.name != "nt":
        raise RuntimeError("this frozen resource protocol targets Windows")
    data = metadata()
    data["protocol"] = dict(seconds=seconds, interval_seconds=2, warmup_seconds=30, memory_sample="own/known child private bytes",
        source_timer="SYNTHETIC; no live reserve calibration", claim="offline component only")
    baseline = own_process_resources(os.getpid())
    data["baseline"] = baseline
    s = snapshot()
    d = BoundedDiagnostics(out/"logs")
    r = IsolatedRunner(diagnostics=d)
    start = time.perf_counter()
    completed = 0
    first = []
    last = deque(maxlen=150)
    peak_main = peak_total = baseline["private_bytes"]
    raw_output = (out/"soak_raw.jsonl").open("w", encoding="utf-8")
    try:
        while time.perf_counter()-start < seconds:
            j = make(s)
            r.submit(j)
            samples = []
            while r.outcome is None:
                if time.perf_counter_ns() >= j.deadline_ns + 1_000_000_000:
                    raise RuntimeError("soak worker failed to settle")
                resources = [own_process_resources(pid) for pid in (os.getpid(), d.pid, r.active_pid) if pid]
                samples.append([v for v in resources if v is not None])
                time.sleep(.02)
            if r.outcome[0] is None:
                raise RuntimeError("healthy soak fallback: " + str(r.outcome))
            wait_for(lambda: r.active_job is None)
            d.flush()
            elapsed = time.perf_counter()-start
            own = own_process_resources(os.getpid())
            stats = d.buffer.stats()
            if stats["dropped_before_enqueue"] or stats["failed_write"] or not stats["accounting_valid"]:
                raise RuntimeError("healthy diagnostics loss")
            row = dict(elapsed_s=elapsed, main=own, resources=samples, accounting=stats,
                       processes=r.counters["processes"], reaped=r.counters["reaped"])
            raw_output.write(json.dumps(row, separators=(",", ":"))+"\n")
            completed += 1
            peak_main = max(peak_main,own["private_bytes"])
            peak_total = max([peak_total]+[sum(v["private_bytes"] for v in sample) for sample in samples])
            if 30 < elapsed <= 330:
                first.append(own["private_bytes"])
            if elapsed >= seconds-300:
                last.append(own["private_bytes"])
            if completed % 30 == 0:
                raw_output.flush()
                dump(out/"soak_progress.json", dict(elapsed_s=elapsed, jobs=completed,
                     main_private_bytes=own["private_bytes"], queue_high_bytes=stats["high_bytes"]))
                print(f"resource soak {elapsed:.1f}/{seconds}s jobs={completed}", flush=True)
            time.sleep(max(0, min(start+completed*2, start+seconds)-time.perf_counter()))
    finally:
        data["runner_cleanup"] = r.close()
        data["final_flush"] = d.flush()  # offline cleanup, never Stop/action path
        data["logger_cleanup"] = d.close()
        raw_output.close()
    data["elapsed_s"] = time.perf_counter()-start
    final_main = own_process_resources(os.getpid())
    data["main_host_cpu_percent_upper_bound"] = (
        (final_main["cpu_ns"]-baseline["cpu_ns"])/1e9/data["elapsed_s"]/(os.cpu_count() or 1)*100)
    data["main_cpu_scope"] = "absolute harness main CPU; conservative upper bound on added CPU, not paired integration"
    data["jobs"] = completed
    data["raw_resource_rows"] = "soak_raw.jsonl"
    data["observer_retention"] = "streamed raw rows; bounded first/last windows, no whole-history RAM retention"
    data["final_accounting"] = d.buffer.stats()
    data["counters"] = dict(r.counters)
    if first and last:
        data["retained_growth_bytes"] = sorted(last)[len(last)//2]-sorted(first)[len(first)//2]
    data["peak_sampled_added_private_bytes"] = peak_total-baseline["private_bytes"]
    data["peak_main_added_private_bytes"] = peak_main-baseline["private_bytes"]
    dump(out/"soak.json", data)


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("mode", choices=("benchmark", "faults", "soak"))
    parser.add_argument("--out", type=Path, required=True)
    parser.add_argument("--seconds", type=int, default=1800)
    args = parser.parse_args()
    args.out.mkdir(parents=True, exist_ok=True)
    if args.mode == "benchmark":
        benchmark(args.out)
    elif args.mode == "faults":
        fault_trials(args.out)
    else:
        soak(args.out, args.seconds)


if __name__ == "__main__":
    main()
