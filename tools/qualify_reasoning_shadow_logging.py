"""C1 fixed-rate separate/shared-emulation qualification. Own helper PIDs only."""
from __future__ import annotations

import argparse
import hashlib
import os
from pathlib import Path
import sys
import time

ROOT = Path(__file__).resolve().parents[1]
for path in (ROOT, ROOT / "src"):
    if str(path) not in sys.path:
        sys.path.insert(0, str(path))

from pokiguard_v2.reasoning_diagnostics import BoundedDiagnostics, LogLimits, encode_event
from pokiguard_v2.reasoning_shadow import (LOG_BYTES_PER_SECOND, LOG_EVENTS_PER_SECOND,
                                           MIN_JOB_INTERVAL_NS, SINK_BYTES)
from tools.evaluate_reasoning_runner import dump, metadata, own_process_resources


def qualify(output):
    output.mkdir(parents=True, exist_ok=True)
    report = metadata()
    report["source_hashes"].update({p:hashlib.sha256((ROOT/p).read_bytes()).hexdigest() for p in (
        "src/pokiguard_v2/reasoning_shadow.py", "tools/basic_auto_bot.py",
        "tests/test_reasoning_shadow.py", "tools/qualify_reasoning_shadow_logging.py")})
    report["protocol"] = dict(runs=3, seconds_per_mode=30, mode_order="shared/separate, separate/shared, shared/separate",
        events_per_second=LOG_EVENTS_PER_SECOND, max_job_rate_hz=1_000_000_000/MIN_JOB_INTERVAL_NS,
        byte_rate_cap=LOG_BYTES_PER_SECOND, fixed_payload_bytes=14000,
        comparison="shared B4 writer emulation vs common B4 writer plus separate B4 AI writer",
        accepted_gameplay_writer="UNMODIFIED; emulated common writer is comparison only",
        cpu="sum own+known writer CPU / wall / logical CPUs *100; startup warmup outside window",
        threshold_cpu_delta_pp=1, legacy_b4_stress="STILL_NOT_QUALIFIED; new source has hard job/log rate caps",
        background="No concurrent performance/regression run. System background load uncontrolled.")
    dump(output/"protocol.json", report)
    rows = []
    for repeat in range(3):
        order = ("shared", "separate") if repeat % 2 == 0 else ("separate", "shared")
        for mode in order:
            limits = LogLimits(records=432, bytes=SINK_BYTES)
            common = BoundedDiagnostics(output/f"{repeat}-{mode}-common", stem="shared", limits=limits)
            separate = BoundedDiagnostics(output/f"{repeat}-{mode}-ai", limits=limits) if mode == "separate" else None
            ai = separate or common
            writers = [common] + ([separate] if separate else [])
            try:
                raw_game = encode_event("gameplay.fixture", 1, {}, dict(emulated=True))
                raw_ai = encode_event("reasoning.decision", 1, {}, dict(data="x"*14000))
                if len(raw_ai)*LOG_EVENTS_PER_SECOND > LOG_BYTES_PER_SECOND:
                    raise RuntimeError("fixture exceeds production byte-rate bound")
                common.enqueue(raw_game); ai.enqueue(raw_ai)
                for writer in writers:
                    if not writer.flush(): raise RuntimeError("warmup writer failure")
                pids = [os.getpid()] + [writer.pid for writer in writers]
                before = {pid:own_process_resources(pid) for pid in pids}
                begin = time.perf_counter_ns()
                durations = []
                for index in range(30*LOG_EVENTS_PER_SECOND):
                    target = begin + index*1_000_000_000//LOG_EVENTS_PER_SECOND
                    remaining = (target-time.perf_counter_ns())/1e9
                    if remaining > 0: time.sleep(remaining)
                    common.enqueue(raw_game)
                    start = time.perf_counter_ns()
                    if not ai.enqueue(raw_ai): raise RuntimeError("healthy record dropped")
                    durations.append(time.perf_counter_ns()-start)
                until = begin + 30_000_000_000
                if (remain := (until-time.perf_counter_ns())/1e9) > 0: time.sleep(remain)
                for writer in writers:
                    if not writer.flush(): raise RuntimeError("healthy flush failed")
                wall = time.perf_counter_ns()-begin
                after = {pid:own_process_resources(pid) for pid in pids}
                cpu = sum(after[pid]["cpu_ns"]-before[pid]["cpu_ns"] for pid in pids)
                rows.append(dict(run=repeat, mode=mode, N=len(durations), wall_ns=wall, cpu_ns=cpu,
                    host_cpu_percent=cpu/wall/(os.cpu_count() or 1)*100,
                    enqueues_ns=durations, accounting=[writer.buffer.stats() for writer in writers]))
            finally:
                cleanup = [writer.close() for writer in writers]
                if not all(cleanup): raise RuntimeError("unreaped owned logger")
            print(f"run={repeat} mode={mode} host_cpu={rows[-1]['host_cpu_percent']:.6f}%", flush=True)
    deltas = [next(x["host_cpu_percent"] for x in rows if x["run"]==i and x["mode"]=="separate")-
              next(x["host_cpu_percent"] for x in rows if x["run"]==i and x["mode"]=="shared") for i in range(3)]
    def healthy(stats):
        return (stats["accounting_valid"] and stats["dropped_before_enqueue"]==0 and
                stats["failed_write"]==0 and stats["discarded_after_enqueue"]==0 and
                stats["queued"]==0 and stats["in_writer"]==0)
    report.update(rows=rows, separate_minus_shared_cpu_pp=deltas,
                  all_accounting_healthy=all(healthy(s) for x in rows for s in x["accounting"]),
                  qualified=all(x<=1 for x in deltas) and all(healthy(s) for x in rows for s in x["accounting"]))
    dump(output/"qualification.json", report)
    return report


if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument("--output", type=Path, required=True)
    qualify(parser.parse_args().output)
