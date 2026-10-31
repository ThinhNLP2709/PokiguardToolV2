"""Phase 5B.3 file-only model diagnostics, historical controls and ablation."""
from __future__ import annotations

import argparse
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import platform
import sys
import time

ROOT = Path(__file__).resolve().parents[1]
sys.path.insert(0, str(ROOT / "src"))
sys.path.insert(0, str(ROOT))

from pokiguard_v2.board_simulator import SwapMove, evaluate_all_moves
from pokiguard_v2.demon_aegis import evaluate_demon_aegis_move
from pokiguard_v2.reasoning_planner import plan
from pokiguard_v2.reasoning_refinement import (
    CAPABILITY_VERSION, CONFIG, Limits, Work, analyze_root, refine, trace_known_root,
)
from pokiguard_v2.reasoning_replay import load_dataset
from pokiguard_v2.reasoning_snapshot import Action, FrozenJSON, canonical_json, digest
from pokiguard_v2.state import GemType
from tools.evaluate_reasoning_planner import (
    DATASET, board_data, evidence, quantiles, snapshot, with_model,
)

FIXTURE = ROOT / "docs/phase5/datasets/5b3_synthetic_boards_v1.json"


def scoped(s):
    scope = dict(s.intent.scope.plain(), game_build="SYNTHETIC")
    intent = replace(s.intent, scope=FrozenJSON.of(scope))
    binding = dict(profile=intent.profile, session_id=s.source.session_id,
                   match_id=s.source.match_id, boss=scope["boss"], game_build="SYNTHETIC")
    obs = dict(s.observations)
    obs["planner.refinement"] = evidence(dict(version=CAPABILITY_VERSION,
        boss_policy="MAX_EFFECTIVE_SWORD_ALL_TIES", own_turn_access=True), "reply_capability", binding)
    return replace(s, intent=intent, observations=tuple(sorted(obs.items())))


def cases():
    records = load_dataset(DATASET)[1]
    raw = json.loads(FIXTURE.read_text(encoding="utf-8"))
    result = []
    for label, data in raw["cases"].items():
        board = tuple(tuple(tuple(c) for c in row) for row in data["board"])
        move = SwapMove(*(tuple(c) for c in data["root"]))
        s = scoped(snapshot("demon_aegis_farm", board=board, baseline=Action("swap", move), setting=4))
        result.append((label, s, dict(origin="SYNTHETIC_SPEC", seed=data["seed"], board_index=data["board_index"])))
    for label, match, turn, move in (
        ("bait_healthy", "M_bdaf6d3b", 21, SwapMove((0, 2), (0, 3))),
        ("secondary_priority_unknown", "M_7d274339", 1, SwapMove((6, 1), (7, 1))),
    ):
        source = next(r.snapshot for r in records if r.snapshot.source.match_id == match and r.snapshot.source.turn == turn)
        s = scoped(snapshot("demon_aegis_farm", board=source.board,
                            baseline=Action("swap", move), hp=100, setting=4))
        # Synthetic sufficiency is a model sensitivity fixture, never new game calibration.
        from tools.evaluate_reasoning_planner import certificate
        s = with_model(s, demon_certificates=[certificate(s, swords=4, rage=0)])
        meta = dict(origin="SYNTHETIC_CONTEXT_ON_ARCHIVED_GEOMETRY", source_snapshot_id=source.snapshot_id)
        result.append((label, s, meta))
        if label == "bait_healthy":
            from tools.evaluate_reasoning_planner import change
            result.append(("bait_low_hp", change(s, "self.hp", 10), meta))
    for profile in ("simple", "careful", "mega_icarus_spam_skill"):
        result.append((profile + "_reference", scoped(snapshot(profile, board=board_data())), dict(origin="SYNTHETIC_SPEC")))
    return result


def focused_analysis(s, limits=Limits(nodes=12000), turn_access=True):
    r1 = plan(s)
    root = next(c for c in r1.scores if c.baseline_member)
    work = Work(limits, lambda: 0, lambda: False)
    return analyze_root(s, root, work, True, turn_access, s.evidence("planner.model").value.plain())


def historical_evidence():
    records = load_dataset(DATASET)[1]
    traces, references, chains = [], 0, []
    by_turn = {(r.snapshot.source.match_id, r.snapshot.source.turn): r for r in records}
    for record in records:
        s = record.snapshot
        trace = trace_known_root(s).plain()
        analysis = trace.get("analysis", {})
        forecast = s.recorded.plain().get("pre_boss_forecast_sword_cells")
        if forecast is not None:
            found = analysis.get("pre_boss_setup_diagnostic", {}).get("passive_swords_max")
            references += found == forecast
            trace["recorded_pre_boss_forecast"] = forecast
            trace["forecast_match"] = found == forecast
        traces.append(trace)
        following = by_turn.get((s.source.match_id, s.source.turn+2))
        if following and record.chosen:
            board = following.snapshot.board_state()
            values = evaluate_all_moves(board)
            count = max((evaluate_demon_aegis_move(board, v, include_next_turn=False).sword_cells
                         for v in values if v.total.cells(GemType.SWORD) == 0), default=0)
            chains.append(dict(match_id=s.source.match_id, turn=s.source.turn,
                next_turn=following.snapshot.source.turn, recorded_forecast=forecast,
                actual_next_local_passive_swords=count, cause="UNKNOWN_BOSS_REFILL_EFFECT",
                actual_boss_action="MISSING", alternative_outcome="NOT_OBSERVED"))
    return dict(traces=traces, applicable_forecasts_matched=references,
                applicable_forecasts=sum(r.snapshot.recorded.plain().get("pre_boss_forecast_sword_cells") is not None for r in records),
                chosen_to_next_local_chains=chains,
                source_owner_local_root=sum(r.snapshot.evidence("legacy.last_move_owner").value.plain() == "LOCAL_ROOT" for r in records),
                observed_boss_actions=sum(r.boss_action.availability == "PRESENT" for r in records),
                alternative_outcomes="NOT_OBSERVED", utility_or_r2_usable=False)


def main():
    parser = argparse.ArgumentParser(__doc__)
    parser.add_argument("--output-dir", type=Path, required=True)
    parser.add_argument("--samples", type=int, default=10)
    args = parser.parse_args()
    target = args.output_dir.resolve()
    if target.exists() or not target.is_relative_to(ROOT / "docs/phase5/artifacts"):
        parser.error("use a NEW directory under docs/phase5/artifacts")
    if not 5 <= args.samples <= 50:
        parser.error("samples must be 5..50 per stratum")
    target.mkdir(parents=True)
    suite = cases()
    inputs, outputs, benchmarks = [], [], []
    for name, s, meta in suite:
        r1 = plan(s)
        r2 = refine(s, r1, clock=lambda: 0)
        inputs.append(dict(case=name, snapshot=s.to_dict(), provenance=meta))
        outputs.append(dict(case=name, r1=r1.to_dict(), refinement=r2.to_dict(),
                            focused=focused_analysis(s), synthetic_clock_for_work_replay=True))
        # Real wall-clock benchmark, separate from deterministic work replay.
        durations_r1, durations_r2 = [], []
        refine(s, r1)
        stops = {}
        for _ in range(args.samples):
            start = time.perf_counter_ns()
            base = plan(s)
            middle = time.perf_counter_ns()
            result = refine(s, base)
            end = time.perf_counter_ns()
            durations_r1.append((middle-start)/1e6)
            durations_r2.append((end-middle)/1e6)
            reason = result.diagnostics.plain()["stop_reason"] or "COMPLETED_OR_UNSUPPORTED"
            stops[reason] = stops.get(reason, 0)+1
        benchmarks.append(dict(case=name, profile=s.intent.profile,
                               r1_ms=durations_r1, refinement_ms=durations_r2,
                               r1_summary=quantiles(durations_r1), refinement_summary=quantiles(durations_r2),
                               stop_reasons=stops, samples=args.samples))
    historical = historical_evidence()
    for filename, records in (("inputs.jsonl", inputs), ("ablations.jsonl", outputs)):
        (target/filename).write_text("\n".join(canonical_json(r) for r in records)+"\n", encoding="utf-8")
    (target/"historical_geometry.json").write_text(json.dumps(historical, indent=2)+"\n", encoding="utf-8")
    files = ("src/pokiguard_v2/reasoning_refinement.py", "tools/evaluate_reasoning_refinement.py",
             "tests/test_reasoning_refinement.py", "docs/phase5/datasets/5b3_synthetic_boards_v1.json")
    hashes = {p: hashlib.sha256((ROOT/p).read_bytes()).hexdigest() for p in files}
    b2 = json.loads((ROOT/"docs/phase5/artifacts/5b2_adaptive_utility_v1/verification.json").read_text(encoding="utf-8"))
    dependencies = dict(b2["source_files"], **b2["dependency_files"])
    preserved = {p: hashlib.sha256((ROOT/p).read_bytes()).hexdigest() == h for p,h in dependencies.items()}
    verification = dict(schema="pokiguard.reasoning.b3_verification.v1", config=CONFIG.plain(),
                        source_files=hashes, source_fingerprint=digest(hashes), b2_dependencies_preserved=preserved,
                        benchmark=benchmarks, runtime=platform.python_version(), platform=platform.platform(),
                        refinement_timing="includes clock/checks/structural analysis/result packing; excludes R1/file IO/host flow",
                        root_budget="R1 already complete; 8 roots/32 scenarios/12000 nodes/4000ms default, max6000ms",
                        r2_promotion=False, production_wiring=False, live=False,
                        alternative_outcomes="NOT_OBSERVED", deadline_e2e_proven=False)
    (target/"verification.json").write_text(json.dumps(verification, indent=2)+"\n", encoding="utf-8")
    manifest = {p.name:hashlib.sha256(p.read_bytes()).hexdigest() for p in sorted(target.iterdir())}
    (target/"manifest.json").write_text(json.dumps(dict(files=manifest), indent=2)+"\n", encoding="utf-8")
    print(json.dumps(dict(output=str(target),cases=len(suite),samples=len(suite)*args.samples,
                         historical_records=len(historical["traces"]),matched_forecasts=historical["applicable_forecasts_matched"],
                         source_fingerprint=verification["source_fingerprint"])))
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
