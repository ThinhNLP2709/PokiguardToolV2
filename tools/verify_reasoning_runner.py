"""B4 reproducible boundary timings, artifact gates and source preservation audit."""
from __future__ import annotations
import argparse
import hashlib
import json
import os
from pathlib import Path
import subprocess
import sys
import time

ROOT = Path(__file__).resolve().parents[1]
sys.path.insert(0, str(ROOT/"src"))
sys.path.insert(0, str(ROOT))
from pokiguard_v2.reasoning_runner import IsolatedRunner, _reply_for, _validate_reply, make_job
from tools.evaluate_reasoning_planner import snapshot
from tools.evaluate_reasoning_runner import dump, metadata, quantiles, timed, wait_for
from tests import reasoning_worker_fixtures as fault


def boundaries(out):
    s = snapshot()
    report = metadata()
    report["protocol"] = dict(runs=3, measured=10000, warmup=1000,
        scopes=["wire_validation", "ready_advisory_selection", "known_fault_disposition", "idempotent_stop"],
        excluded="provider, actual action preflight/execution/ACK; no production parity claim")
    records = []
    for repeat in range(3):
        for mode in ("wire_validation", "ready_advisory_selection", "known_fault_disposition", "idempotent_stop"):
            j = make_job(s, deadline=time.perf_counter_ns()+5_000_000_000)
            r = None
            try:
                if mode == "wire_validation":
                    wire = dict(job_id=j.job_id, generation=j.generation, binding=vars(j.binding),
                        snapshot=j.snapshot.to_dict(), budget_ns=4_000_000_000, refinement=False)
                    import threading
                    raw = json.dumps(_reply_for(wire, threading.Event()), separators=(",", ":")).encode()
                    operation = lambda: _validate_reply(raw, j)
                else:
                    r = IsolatedRunner(compute=fault.raises) if mode == "known_fault_disposition" else IsolatedRunner()
                    r.submit(j)
                    wait_for(lambda: r.outcome is not None)
                    if mode == "idempotent_stop":
                        r.stop()
                        operation = r.stop
                    else:
                        operation = lambda: r.disposition(j, current_binding=j.binding)
                rows = []
                for i in range(11000):
                    control = lambda: s.baseline
                    if i % 2:
                        value, baseline = timed(operation), timed(control)
                    else:
                        baseline, value = timed(control), timed(operation)
                    rows.append(dict(run=repeat, mode=mode, warmup=i < 1000, value_ms=value,
                                     control_ms=baseline, delta_ms=value-baseline))
                if mode in {"ready_advisory_selection", "known_fault_disposition"}:
                    expected = mode == "ready_advisory_selection"
                    if r.disposition(j, current_binding=j.binding).used_proposal != expected:
                        raise RuntimeError("measurement did not remain on declared ready/fault branch")
                records.extend(rows)
                measured = [x for x in rows if not x["warmup"]]
                report.setdefault("runs", []).append(dict(run=repeat, mode=mode,
                    value=quantiles([x["value_ms"] for x in measured]),
                    paired_delta=quantiles([x["delta_ms"] for x in measured])))
            finally:
                if r is not None and not r.close():
                    raise RuntimeError("boundary measurement orphan")
    with (out/"boundary_raw.jsonl").open("w", encoding="utf-8") as output:
        for row in records:
            output.write(json.dumps(row, separators=(",", ":"))+"\n")
    dump(out/"boundary.json", report)


def verify(out):
    benchmark = json.loads((out/"performance/benchmark.json").read_text())
    boundary = json.loads((out/"boundaries/boundary.json").read_text())
    faults = json.loads((out/"faults/faults.json").read_text())
    resource = json.loads((out/"resources/soak.json").read_text())
    cpu = json.loads((out/"log_cpu/cpu.json").read_text())
    report = dict(schema="pokiguard.reasoning.b4_verification.v1", gates={})
    gates = report["gates"]
    limits = dict(disabled=(.1,.5,1,5), submit=(.5,1,3,10), shared=(.05,.1,.2,2),
        separate=(.05,.1,.2,2), lock_busy=(.05,.1,.2,2), queue_full=(.05,.1,.2,2),
        wire_validation=(1,2,5,20), ready_advisory_selection=(1,2,5,20),
        known_fault_disposition=(1,5,10,25), idempotent_stop=(5,5,10,25))
    for data in (benchmark,boundary):
        for item in data["runs"]:
            name = item["mode"]
            q = item["value"]
            gates[f"{name}.run{item['run']}"] = q["n"] == 10000 and all(
                q[key] <= limit for key,limit in zip(("p50","p95","p99","max"),limits[name]))
    raw = [json.loads(line) for line in (out/"performance/micro_raw.jsonl").read_text().splitlines()]
    delta_rows = []
    for repeat in range(3):
        a = [x["value_ms"] for x in raw if x["run"] == repeat and x["mode"] == "separate" and not x["warmup"]]
        b = [x["value_ms"] for x in raw if x["run"] == repeat and x["mode"] == "shared" and not x["warmup"]]
        q = quantiles([x-y for x,y in zip(a,b)])
        delta_rows.append(dict(run=repeat, **q))
        gates[f"separate_minus_shared.run{repeat}"] = all(
            q[key] <= limit for key,limit in zip(("p50","p95","p99","max"),(.1,.5,1,5)))
    report["paired_same_logical_record_delta_ms"] = delta_rows
    separate_cpu_pass = all(x <= 1 for x in cpu["separate_minus_shared_cpu_pp"])
    separate_qualified = separate_cpu_pass and all(
        v for k,v in gates.items() if k.startswith("separate_minus_shared") or k.startswith("separate.run"))
    report["separate_sink_qualified"] = separate_qualified
    report["separate_cpu_delta_pass"] = separate_cpu_pass
    report["offline_sink_choice"] = "SHARED_NAMESPACE_FILTER"
    report["sink_policy"] = "A3 default shared; prior separate CPU qualification failed, no retry-to-promote"
    # A3 explicitly permits shared when separate fails qualification. Keep every
    # failed separate observation visible; it is not a required shared-backend gate.
    report["separate_qualification_gates"] = {
        k:gates.pop(k) for k in list(gates) if k.startswith("separate_minus_shared") or k.startswith("separate.run")}
    gates["fault_trials"] = len(faults["trials"]) == 490 and faults["all_reaped"]
    gates["fault_baseline_max"] = faults["fault_disposition_ms"]["max"] <= 25
    gates["stop_max"] = faults["stop_ms"]["max"] <= 25
    gates["cleanup_max"] = faults["cleanup_ms"]["max"] <= 1000
    gates["resource_30_minutes"] = resource["elapsed_s"] >= 1800
    gates["main_memory_cap"] = resource["peak_main_added_private_bytes"] <= 32*1024*1024
    gates["total_memory_cap"] = resource["peak_sampled_added_private_bytes"] <= 256*1024*1024
    gates["retained_growth"] = resource["retained_growth_bytes"] <= 8*1024*1024
    gates["main_cpu_cap"] = resource["main_host_cpu_percent_upper_bound"] <= 5
    stats = resource["final_accounting"]
    gates["healthy_logs"] = stats["accounting_valid"] and not (
        stats["dropped_before_enqueue"]+stats["failed_write"]+stats["discarded_after_enqueue"])
    gates["queue_caps"] = stats["high_bytes"] <= 8*1024*1024 and stats["high_records"] <= 512
    gates["final_summary_flushed"] = resource["final_flush"]
    gates["resource_cleanup"] = resource["runner_cleanup"] and resource["logger_cleanup"]
    preserved = json.loads((out/"preserved_sources_before.json").read_text())
    changed = [p for p,h in preserved.items() if hashlib.sha256((ROOT/p).read_bytes()).hexdigest() != h]
    gates["preserved_preexisting_python_sources"] = not changed
    report["preserved_files"] = len(preserved)
    report["changed_preexisting_sources"] = changed
    probe = '''import ctypes,sys,json
psapi=ctypes.WinDLL('psapi')
psapi.GetProcessMemoryInfo.argtypes=(ctypes.c_void_p,ctypes.c_void_p,ctypes.c_ulong)
def private():
    buf=ctypes.create_string_buffer(8+9*ctypes.sizeof(ctypes.c_size_t))
    if not psapi.GetProcessMemoryInfo(ctypes.c_void_p(-1),buf,len(buf)): raise RuntimeError('memory probe failed')
    return int.from_bytes(buf.raw[-ctypes.sizeof(ctypes.c_size_t):],'little')
# A3 requires added memory relative to accepted BASIC, not bare Python startup.
import pokiguard_v2.basic_policy
before=private()
from pokiguard_v2.reasoning_runner import create_runner
import threading,multiprocessing as m
assert create_runner(enabled=False) is None
assert 'pokiguard_v2.reasoning_snapshot' not in sys.modules
assert 'pokiguard_v2.reasoning_planner' not in sys.modules
assert 'pokiguard_v2.reasoning_refinement' not in sys.modules
assert len(threading.enumerate())==1 and not m.active_children()
print(json.dumps(dict(disabled_no_worker_queue_or_model=True,added_private_bytes=private()-before)))
'''
    completed = subprocess.run([sys.executable,"-c",probe], cwd=ROOT,
        env=dict(os.environ,PYTHONPATH=str(ROOT/"src")), capture_output=True,text=True)
    gates["disabled_import_probe"] = completed.returncode == 0
    report["disabled_probe"] = completed.stdout+completed.stderr
    report["disabled_probe_result"] = json.loads(completed.stdout) if completed.returncode == 0 else {}
    report["disabled_probe_control"] = "fresh process with accepted BasicPolicy imported before AI; no game/provider/input calls"
    gates["disabled_memory_cap"] = report["disabled_probe_result"].get("added_private_bytes",float('inf')) <= 8*1024*1024
    report["all_gates_pass"] = all(gates.values())
    report["production_flow_parity"] = "NOT_IMPLEMENTED_NOT_MEASURED"
    report["source_hashes"] = {p:hashlib.sha256((ROOT/p).read_bytes()).hexdigest() for p in (
        "src/pokiguard_v2/reasoning_runner.py", "src/pokiguard_v2/reasoning_diagnostics.py",
        "tests/reasoning_worker_fixtures.py", "tests/test_reasoning_runner.py",
        "tools/evaluate_reasoning_runner.py", "tools/evaluate_reasoning_log_cpu.py",
        "tools/verify_reasoning_runner.py")}
    report["source_fingerprint"] = hashlib.sha256(json.dumps(report["source_hashes"],sort_keys=True).encode()).hexdigest()
    for index,data in enumerate((benchmark,boundary,faults,resource,cpu)):
        for p,h in data["source_hashes"].items():
            gates[f"measurement_source.{index}."+p] = report["source_hashes"][p] == h
    report["all_gates_pass"] = all(gates.values())
    dump(out/"verification.json", report)
    print(json.dumps(dict(all_gates_pass=report["all_gates_pass"],
                         failed=[k for k,v in gates.items() if not v],
                         source_fingerprint=report["source_fingerprint"])))


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("mode", choices=("boundaries","verify"))
    parser.add_argument("--out", type=Path, required=True)
    args = parser.parse_args()
    args.out.mkdir(parents=True, exist_ok=True)
    boundaries(args.out) if args.mode == "boundaries" else verify(args.out)


if __name__ == "__main__":
    main()
