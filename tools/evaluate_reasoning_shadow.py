"""C1 OFFLINE publication-seam timing; no game attach/input or live claims."""
from __future__ import annotations

import argparse
from dataclasses import asdict
import hashlib
import json
import math
from pathlib import Path
import platform
import subprocess
import sys
import time

ROOT = Path(__file__).resolve().parents[1]
for path in (ROOT, ROOT / "src"):
    if str(path) not in sys.path:
        sys.path.insert(0, str(path))

from pokiguard_v2.basic_policy import PlayStyle
from pokiguard_v2.reasoning_shadow import _ObservedLog, attach_shadow_log, create_shadow
from tests.test_reasoning_shadow import MemorySink, ShadowAdapter, publication
from tests import reasoning_worker_fixtures as fault
from tools.basic_auto_bot import _write


class NullLog:
    def __init__(self):
        self.writes = self.flushes = 0

    def write(self, raw):
        self.writes += 1
        return len(raw)

    def flush(self):
        self.flushes += 1


def quantiles(values):
    ordered = sorted(values)
    return {name: ordered[min(len(ordered)-1, math.ceil(q*len(ordered))-1)] / 1e6
            for name, q in (("p50", .5), ("p95", .95), ("p99", .99), ("max", 1))}


def timed_write(log, raw):
    begin = time.perf_counter_ns()
    log.write(raw)
    log.flush()
    return time.perf_counter_ns() - begin


def benchmark(directory):
    directory.mkdir(parents=True, exist_ok=True)
    corpus = [publication(PlayStyle.SIMPLE)]
    modes = ("disabled", "enabled", "busy", "full", "sink_fault", "stopped")
    source_paths = ("src/pokiguard_v2/reasoning_shadow.py", "tools/basic_auto_bot.py",
                    "tests/test_reasoning_shadow.py", "tools/evaluate_reasoning_shadow.py")
    metadata = dict(schema="pokiguard.reasoning.shadow_seam_benchmark.v1",
        scope="ENTIRE_NEW_OBSERVED_LOG_WRITE_ADMISSION_PLUS_UNCHANGED_FLUSH; NOT_CONTROLLER_OR_LIVE_ACCEPTANCE",
        N_per_run=10000, warmup_per_run=1000, runs=3, modes=modes,
        corpus=[dict(profile=x[0].play_style.value, action=x[2].action.value,
                     raw_bytes=len(x[4].encode())) for x in corpus],
        clock=vars(time.get_clock_info("perf_counter")), python=sys.version,
        platform=platform.platform(), head=subprocess.check_output(["git", "rev-parse", "HEAD"], cwd=ROOT,text=True).strip(),
        source_hashes={p:hashlib.sha256((ROOT/p).read_bytes()).hexdigest() for p in source_paths},
        background="No concurrent regression run; background system load not controlled",
        sink="ENABLED: OWNED_B4_SEPARATE_DISK_SINK; PRESSURE_FIXTURES: BOUNDED_MEMORY",
        interleaving="mode order rotates per run; within pair control/mode order alternates")
    # Freeze before collecting any acceptance samples.
    (directory / "protocol.json").write_text(json.dumps(metadata, indent=2)+"\n")
    results = []
    with (directory / "raw.jsonl").open("w", encoding="utf-8", buffering=1) as raw_out:
        for run in range(3):
            for mode in modes[run:] + modes[:run]:
                sink = MemorySink(fail=mode == "sink_fault")
                adapter = (None if mode == "disabled" else
                           create_shadow(enabled=True, directory=directory/f"logs-{run}-{mode}", compute=fault.retain)
                           if mode == "enabled" else ShadowAdapter(diagnostics=sink, compute=fault.retain))
                control, base = NullLog(), NullLog()
                if adapter is None:
                    observed = attach_shadow_log(base, None, corpus[0][0])
                else:
                    observed = attach_shadow_log(base, adapter, corpus[0][0])
                    if mode in {"busy", "full"}:
                        adapter.stop()
                        adapter.thread.join(1)
                        adapter.runner.close()
                        adapter.stopped.clear()  # Offline pressure fixture only, no supervisor.
                        if mode == "busy": adapter.lock.acquire()
                        else: adapter.items.extend([(corpus[0][4], 0, 0)] * 16)
                    if mode == "sink_fault": sink.buffer.disable("OFFLINE known sink fault")
                    if mode == "stopped": adapter.stop()
                controls, actuals, deltas = [], [], []
                try:
                    for index in range(11000):
                        item = corpus[index % len(corpus)]
                        if index % 2:
                            actual = timed_write(observed, item[4])
                            baseline = timed_write(control, item[4])
                        else:
                            baseline = timed_write(control, item[4])
                            actual = timed_write(observed, item[4])
                        warmup = index < 1000
                        raw_out.write(json.dumps(dict(run=run, mode=mode, index=index,
                            profile=item[0].play_style.value, family=item[2].action.value,
                            warmup=warmup, control_ns=baseline, mode_ns=actual,
                            paired_delta_ns=actual-baseline), separators=(",", ":"))+"\n")
                        if not warmup:
                            controls.append(baseline); actuals.append(actual); deltas.append(actual-baseline)
                    limits = (.1, .5, 1, 5) if mode == "disabled" else (.5, 1, 3, 10)
                    delta = quantiles(deltas)
                    families = {}
                    # Same corpus order/size for both paths; families are descriptive.
                    for family in set(x[2].action.value for x in corpus):
                        values = [d for i,d in enumerate(deltas, 1000) if corpus[i % len(corpus)][2].action.value == family]
                        families[family] = dict(N=len(values), paired_delta_ms=quantiles(values))
                    results.append(dict(run=run, mode=mode, N=10000,
                        control_ms=quantiles(controls), mode_ms=quantiles(actuals),
                        paired_delta_ms=delta, quantile_difference_ms={k:quantiles(actuals)[k]-quantiles(controls)[k] for k in delta},
                        families=families, target_pass=all(delta[k] <= v for k,v in zip(("p50","p95","p99","max"),limits)),
                        writes_equal=control.writes == base.writes,
                        flushes_equal=control.flushes == base.flushes,
                        adapter_counters=None if adapter is None else dict(adapter.counts)))
                finally:
                    if adapter is not None:
                        if mode == "busy": adapter.lock.release()
                        adapter.close()
                print(f"run={run} mode={mode} delta_ms={delta} PASS={results[-1]['target_pass']}", flush=True)
    result = dict(metadata=metadata, results=results,
                  all_measured_seam_targets_pass=all(x["target_pass"] for x in results),
                  complete_controller_parity="NOT_MEASURED", live="NOT_RUN")
    (directory / "benchmark.json").write_text(json.dumps(result, indent=2)+"\n")
    return result


if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument("--output", type=Path, default=ROOT / "docs/phase5/artifacts/5c1_shadow_v1/performance")
    benchmark(parser.parse_args().output)
