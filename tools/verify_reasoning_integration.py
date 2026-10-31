"""C3 offline integration evidence. Never attaches a game or sends native input.

Times the complete existing publication builder/serializer/writer plus optional
admission, not a pre-encoded enqueue. Unchanged reads/solver/input time is not
invented: source preservation and the regression suite cover those boundaries.
"""
from __future__ import annotations

import argparse
import hashlib
import json
import os
from pathlib import Path
import platform
import sys
import time

ROOT = Path(__file__).resolve().parents[1]
for entry in (ROOT, ROOT / "src"):
    if str(entry) not in sys.path:
        sys.path.insert(0, str(entry))

from pokiguard_v2.basic_policy import PlayStyle
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.desktop_farm_controller import (
    DesktopFarmControllerManager, DesktopControllerSnapshot, DesktopControllerState,
)
from pokiguard_v2.reasoning_settings import AISettings, RunShadowSession
from pokiguard_v2.reasoning_shadow import ShadowAdapter, attach_shadow_log
from tests.test_reasoning_shadow import MemorySink, publication
from tests import reasoning_worker_fixtures as fault
from tools.basic_auto_bot import _decision_fields, _write


def dump(path, value):
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(json.dumps(value, ensure_ascii=False, indent=2, allow_nan=False) + "\n", encoding="utf-8")


def quantiles(values):
    import math
    ordered = sorted(values)
    return {name: ordered[math.ceil(len(ordered)*q)-1] / 1e6
            for name, q in (("p50", .5), ("p95", .95), ("p99", .99), ("max", 1))}


class CountingLog:
    """Deterministic gameplay sink; native AI disk sink remains real in shadow."""
    def __init__(self):
        self.writes = self.flushes = 0
        self.digest = hashlib.sha256()

    def write(self, raw):
        self.writes += 1
        # Timestamp is the only volatile gameplay field in this frozen corpus.
        self.digest.update(raw[raw.find(',"event"'):].encode("utf-8"))
        return len(raw)

    def flush(self):
        self.flushes += 1


def make_session(out, **kwargs):
    manager = DesktopFarmControllerManager(ROOT, runner=lambda *_: 0)
    manager._snapshot = DesktopControllerSnapshot(generation=1, active=True,
                                                  state=DesktopControllerState.RUNNING)
    session = RunShadowSession(DesktopConfig(ai=AISettings(True, 4000)), directory=out,
        observer=lambda value, phase: manager._observe(1, value, phase), **kwargs)
    return session, manager


def freeze(out, mode):
    paths = sorted(p for base in ("src", "tools", "tests")
                   for p in (ROOT/base).rglob("*.py"))
    files = {p.relative_to(ROOT).as_posix(): hashlib.sha256(p.read_bytes()).hexdigest() for p in paths}
    metadata = dict(schema="pokiguard.reasoning.c3_integration.v1", mode=mode,
        python=sys.version, platform=platform.platform(), logical_cpus=os.cpu_count(),
        clock=vars(time.get_clock_info("perf_counter")), input_authority=False, game_attach=False,
        source_files=files, source_fingerprint=hashlib.sha256(json.dumps(files,sort_keys=True).encode()).hexdigest())
    dump(out / (mode+"_source.json"), metadata)
    return metadata


def publish(log, item):
    config, state, decision, _, _, analysis = item
    # The immutable state and BASIC analysis/decision are shared between the
    # paired paths. Those untouched computations are not claimed as measured.
    fields = _decision_fields(state, decision, analysis)
    _write(log, "policy_decision", **fields, trace=decision.trace)


def corpus():
    from pokiguard_v2.basic_policy import BasicPolicyEngine
    from pokiguard_v2.board_diagnostics import analyze_game_state
    return [(*item, analyze_game_state(item[1], policy_engine=BasicPolicyEngine(item[0])))
            for item in (publication(p) for p in PlayStyle)]


def benchmark(out):
    data = freeze(out, "benchmark")
    items = corpus()
    modes = ("disabled", "shadow", "sink_fault", "stopped")
    data["protocol"] = dict(runs=3, measured_per_run_per_mode=10000, warmup=1000,
        scope="ALL_NEW_COMBAT_CRITICAL_PATH: existing decision-fields + JSON codec + gameplay write/flush + optional shadow admission",
        excludes="unchanged provider/solver/capture/input; no fabricated whole-game wall time",
        sink="paired deterministic gameplay digest sink; SHADOW real owned native separate AI sink; fault memory fixture",
        corpus=[dict(profile=x[0].play_style.value, family=x[2].action.value, bytes=len(x[4].encode())) for x in items],
        order="rotate modes each run; alternate control/mode within pair; same frozen state/decision",
        no_outlier_removal=True, no_concurrent_tests=True,
        limits_ms=dict(disabled=[.1,.5,1,5], shadow=[.5,1,3,10]),
        family_gates="every run and profile/family independently; nearest rank; raw max retained",
        resources="separate 30min integrated stream only after latency gate passes")
    dump(out/"protocol.json", data)
    results = []
    with (out/"raw.jsonl").open("w", encoding="utf-8", buffering=1) as raw:
        for run in range(3):
            for mode in modes[run:] + modes[:run]:
                session = manager = adapter = None
                if mode == "shadow":
                    session, manager = make_session(out/f"logs-{run}-{mode}")
                    adapter = session.prepare()
                    if adapter is None:
                        raise RuntimeError("native shadow setup unavailable")
                elif mode != "disabled":
                    sink = MemorySink()
                    if mode == "sink_fault":
                        sink.buffer.disable("C3 declared known fault")
                    adapter = ShadowAdapter(diagnostics=sink, compute=fault.retain)
                    if mode == "stopped": adapter.stop()
                control, actual = CountingLog(), CountingLog()
                # Bind once, as the actual combat controller does. Profile
                # conflicts in this overload corpus must remain AI-only.
                observed = attach_shadow_log(actual, adapter, items[0][0])
                rows = []
                try:
                    for index in range(11000):
                        item = items[index % len(items)]
                        def measure(log):
                            start = time.perf_counter_ns()
                            publish(log, item)
                            return time.perf_counter_ns()-start
                        if index % 2:
                            a, c = measure(observed), measure(control)
                        else:
                            c, a = measure(control), measure(observed)
                        row = dict(run=run, mode=mode, index=index, warmup=index<1000,
                            profile=item[0].play_style.value, family=item[2].action.value,
                            control_ns=c, mode_ns=a, paired_delta_ns=a-c)
                        raw.write(json.dumps(row,separators=(",",":"))+"\n")
                        if index >= 1000: rows.append(row)
                    limits = data["protocol"]["limits_ms"]["disabled" if mode == "disabled" else "shadow"]
                    families = []
                    for p in PlayStyle:
                        group = [r for r in rows if r["profile"] == p.value]
                        q = quantiles([r["paired_delta_ns"] for r in group])
                        families.append(dict(profile=p.value, family=group[0]["family"], N=len(group), paired_delta_ms=q,
                                             passed=all(v<=limit for v,limit in zip(q.values(),limits))))
                    c = quantiles([r["control_ns"] for r in rows])
                    a = quantiles([r["mode_ns"] for r in rows])
                    d = quantiles([r["paired_delta_ns"] for r in rows])
                    parity = (control.writes, control.flushes, control.digest.hexdigest()) == (actual.writes,actual.flushes,actual.digest.hexdigest())
                    result = dict(run=run,mode=mode,N=len(rows),control_ms=c,mode_ms=a,paired_delta_ms=d,
                        quantile_difference_ms={k:a[k]-c[k] for k in a}, families=families,
                        gameplay_writes=actual.writes,gameplay_flushes=actual.flushes,gameplay_digest_parity=parity,
                        adapter_counts=None if adapter is None else dict(adapter.counts),
                        passed=parity and all(v<=limit for v,limit in zip(d.values(),limits)) and all(g["passed"] for g in families))
                    results.append(result)
                    print(f"run={run} mode={mode} delta={d} PASS={result['passed']}",flush=True)
                finally:
                    if session is not None: session.stop()
                    if adapter is not None and not adapter.close(2):
                        raise RuntimeError("unreaped shadow observer/child")
    data["results"] = results
    data["passed"] = all(r["passed"] for r in results)
    data["live"] = "NOT_RUN"
    dump(out/"benchmark.json",data)


def main():
    parser=argparse.ArgumentParser()
    parser.add_argument("mode",choices=("benchmark",))
    parser.add_argument("--out",type=Path,required=True)
    args=parser.parse_args();args.out.mkdir(parents=True,exist_ok=True)
    benchmark(args.out)


if __name__=="__main__":main()
