"""Offline shared/separate writer CPU comparison with emulated gameplay records."""
from __future__ import annotations
import argparse
import os
from pathlib import Path
import sys
import time

ROOT = Path(__file__).resolve().parents[1]
sys.path.insert(0, str(ROOT/"src"))
sys.path.insert(0, str(ROOT))
from pokiguard_v2.reasoning_diagnostics import BoundedDiagnostics, encode_event
from tools.evaluate_reasoning_runner import dump, metadata, own_process_resources


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("--out", type=Path, required=True)
    parser.add_argument("--seconds", type=int, default=10)
    args = parser.parse_args()
    args.out.mkdir(parents=True, exist_ok=True)
    report = metadata()
    report["protocol"] = dict(runs=3, seconds=args.seconds, target_pair_interval_seconds=.002,
        comparison="one shared writer vs gameplay writer + separate AI writer",
        scope="EMULATED off-path sinks; actual accepted gameplay writer remains unwired",
        cpu="sum own+known logger process CPU time / wall time / logical CPUs *100",
        sampling="saturated synthetic pair stream; losses counted, no healthy zero-loss claim")
    rows = []
    for repeat in range(3):
        for mode in (("shared", "separate") if repeat % 2 == 0 else ("separate", "shared")):
            common = BoundedDiagnostics(args.out/f"{repeat}-{mode}-common", stem="shared")
            separate = BoundedDiagnostics(args.out/f"{repeat}-{mode}-reasoning") if mode == "separate" else None
            ai = separate or common
            writers = [common] + ([separate] if separate else [])
            try:
                raw_game = encode_event("gameplay.fixture", 1, {}, dict(emulated=True))
                raw_ai = encode_event("reasoning.decision", 1, {}, dict(mode="OFFLINE", disposition="RETAIN_BASELINE"))
                common.enqueue(raw_game)
                ai.enqueue(raw_ai)
                for writer in writers:
                    if not writer.flush():
                        raise RuntimeError("CPU probe writer warmup failed")
                pids = [os.getpid()] + [writer.pid for writer in writers]
                before = {pid:own_process_resources(pid) for pid in pids}
                start = time.perf_counter_ns()
                count = 0
                while time.perf_counter_ns()-start < args.seconds*1e9:
                    common.enqueue(raw_game)
                    ai.enqueue(raw_ai)
                    count += 1
                    time.sleep(.002)
                for writer in writers:
                    writer.flush()
                wall = time.perf_counter_ns()-start
                after = {pid:own_process_resources(pid) for pid in pids}
                cpu_ns = sum(after[pid]["cpu_ns"]-before[pid]["cpu_ns"] for pid in pids)
                row = dict(run=repeat, mode=mode, pairs=count, wall_ns=wall,
                    cpu_ns=cpu_ns, host_cpu_percent=cpu_ns/wall/(os.cpu_count() or 1)*100,
                    accounting=[writer.buffer.stats() for writer in writers])
                rows.append(row)
                print(f"CPU probe run={repeat} mode={mode} percent={row['host_cpu_percent']:.4f}", flush=True)
            finally:
                for writer in writers:
                    if not writer.close():
                        raise RuntimeError("CPU probe orphan writer")
    report["runs"] = rows
    report["separate_minus_shared_cpu_pp"] = [
        next(r["host_cpu_percent"] for r in rows if r["run"] == i and r["mode"] == "separate")-
        next(r["host_cpu_percent"] for r in rows if r["run"] == i and r["mode"] == "shared") for i in range(3)]
    dump(args.out/"cpu.json", report)


if __name__ == "__main__":
    main()
