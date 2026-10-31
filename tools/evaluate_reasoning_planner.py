"""File-only Phase 5B.2 scenarios, historical dispositions and descriptive timing.

All added costs/effects/identity below are SYNTHETIC_SPEC fixtures, never game
observations. Run with --output-dir pointing to a NEW project-local directory.
"""
from __future__ import annotations

import argparse
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import platform
import random
import statistics
import sys
import time

ROOT = Path(__file__).resolve().parents[1]
sys.path.insert(0, str(ROOT / "src"))

from pokiguard_v2.board_simulator import SwapMove, evaluate_all_moves
from pokiguard_v2.demon_aegis import evaluate_demon_aegis_move
from pokiguard_v2.reasoning_planner import MODEL_VERSION, VERSION_CONFIG, plan
from pokiguard_v2.reasoning_replay import load_dataset
from pokiguard_v2.reasoning_snapshot import Action, Evidence, FrozenJSON, canonical_json, digest

DATASET = ROOT / "docs/phase5/datasets/manifest.json"
TARGET = SwapMove((5, 3), (6, 3))


def evidence(value, unit, scope=None, support="CONDITIONAL_MODEL"):
    return Evidence.observed(value, unit, "5B2_SYNTHETIC_SCENARIO_NOT_GAME_OBSERVATION",
                             origin="SYNTHETIC_SPEC", support=support, scope=scope)


def board_data(kind="reference"):
    if kind == "reference":
        return load_dataset(DATASET)[1][-1].snapshot.board
    gems = ("mana", "health", "drain", "rage", "shield", "sword")
    if kind == "sparse":
        return tuple(tuple((gems[(r * 2 + c) % 6], 1) for c in range(8)) for r in range(8))
    rng = random.Random(5202)
    rows = []
    for r in range(8):
        row = []
        for c in range(8):
            options = list(gems[:3])
            if c >= 2 and row[c - 1][0] == row[c - 2][0]:
                options.remove(row[c - 1][0])
            if r >= 2 and rows[r - 1][c][0] == rows[r - 2][c][0] and rows[r - 1][c][0] in options:
                options.remove(rows[r - 1][c][0])
            row.append((rng.choice(options), 1))
        rows.append(tuple(row))
    return tuple(rows)


def demon_board(swords=3, rage_cells=5, multiplier=1, cross=False):
    fillers = ("mana", "health", "drain")
    cells = [[(fillers[(r * 2 + c) % 3], 1) for c in range(8)] for r in range(8)]
    for r, c in ((6, 1), (6, 2), (5, 3)):
        cells[r][c] = ("shield", 1)
    cells[6][3] = ("mana", 1)
    for r, c in ((0, 1), (1, 2), (2, 3), (3, 1))[:swords]:
        cells[r][c] = ("sword", multiplier)
    for r, c in ((0, 2), (0, 3), (1, 1), (1, 3), (2, 1))[:rage_cells]:
        cells[r][c] = ("rage", 1)
    # A separate legal incumbent remains when the burst contains no Rage.
    cells[7][5] = cells[7][6] = cells[6][7] = ("health", 1)
    cells[7][7] = ("drain", 1)
    if cross:
        # Separate central cross root: (3,3)<->(3,4), so both axes can match.
        for r, c in ((3, 1), (3, 2), (3, 4), (2, 3), (4, 3)):
            cells[r][c] = ("shield", 1)
        cells[3][3] = ("mana", 1)
        cells[5][3] = ("mana", 1)
    return tuple(tuple(row) for row in cells)


def snapshot(profile="simple", hp=100, mana=200, rage=0, board=None,
             baseline=None, model_updates=None, legal_updates=None, setting=6):
    base = load_dataset(DATASET)[1][-1].snapshot
    scope = dict(dataset_tier="S", account_binding="SYNTHETIC_ACCOUNT", boss="SYNTHETIC_BOSS",
                 loadout="SYNTHETIC_" + profile, previously_inspected=True)
    intent = replace(base.intent, profile=profile, scope=FrozenJSON.of(scope),
                     settings=FrozenJSON.of(dict(sword_setting=setting, seal_setting=setting,
                                                 skill_threshold=setting)),
                     versions=FrozenJSON.of(dict(utility="5b2.one_step.v1", model=MODEL_VERSION)))
    data = board or board_data()
    source = replace(base.source, run_id="5B2_SYNTHETIC", session_id="5B2_SYNTHETIC_SESSION",
                     match_id="5B2_SYNTHETIC_MATCH", turn=1, board_hash=digest(data))
    current = replace(base, source=source, board=data, intent=intent,
                      baseline=baseline or base.baseline, baseline_reason="SYNTHETIC_INCUMBENT_NOT_A_LIVE_BASIC_DECISION",
                      observations=(), recorded=FrozenJSON.of({}))
    moves = evaluate_all_moves(current.board_state())
    if baseline is None and moves:
        eligible = [v for v in moves if not evaluate_demon_aegis_move(
            current.board_state(), v, include_next_turn=False).activates_passive]
        current = replace(current, baseline=Action("swap", (eligible or list(moves))[0].move))
    model = dict(version=MODEL_VERSION, conversion={"rage": 20, "mana": 30},
                 multiplier_supported=True, requirements={"mana": 0, "rage": 0},
                 protection={g: dict(points_per_effective=0, kind="heal")
                             for g in ("health", "shield", "drain")},
                 execution_costs={canonical_json(Action("swap", v.move).to_dict()): 0 for v in moves})
    model.update(model_updates or {})
    legal = dict(owner="ROOT_TURN", swap_allowed=True, pass_allowed=False, mandatory=True, blocked=False)
    legal.update(legal_updates or {})
    binding = dict(profile=profile, session_id=source.session_id, match_id=source.match_id,
                   **{k: scope[k] for k in ("account_binding", "boss", "loadout")})
    observations = {
        "self.hp": evidence(hp, "hp_points"), "self.max_hp": evidence(100, "hp_points"),
        "self.mana": evidence(mana, "mana_points"), "self.max_mana": evidence(300, "mana_points"),
        "self.rage": evidence(rage, "rage_points"), "self.max_rage": evidence(250, "rage_points"),
        "planner.known_boss_threat": evidence(0, "normalized"),
        "planner.model": evidence(model, "scoped_model", binding),
        "planner.legality": evidence(legal, "action_capability", dict(binding, turn=source.turn)),
    }
    return replace(current, observations=tuple(sorted(observations.items())))


def change(snapshot, name, value, unit=None):
    observations = dict(snapshot.observations)
    old = observations[name]
    observations[name] = evidence(value, unit or old.unit, old.scope.plain(), old.support)
    return replace(snapshot, observations=tuple(sorted(observations.items())))


def card(action, damage, protection, *, cost=100, legal=True, threat=0):
    effects = dict(F=0, R=0, D=damage, P=protection, B=0, T=threat, X=0, E=0)
    return dict(action=action.to_dict(), legal=legal, source_valid=True, consumes_turn=True,
                costs={"mana": cost, "rage": 0}, effects=effects, reference="SYNTHETIC_EFFECT_PROXY_NO_RUNTIME_MODEL")


def certificate(s, *, swords=3, rage=100, mode="preexisting", account=None):
    scope = {k: s.intent.scope.plain()[k] for k in ("account_binding", "boss", "loadout")}
    if account is not None:
        scope["account_binding"] = account
    return dict(id="SYNTHETIC_C-D3-R100-v1", scope=scope, physical_swords=swords,
                rage_points=rage, rage_mode=mode)


def with_model(s, **updates):
    model = s.evidence("planner.model").value.plain()
    model.update(updates)
    return change(s, "planner.model", model)


def scenarios():
    result = []
    attack, protect = Action("pet_skill", card_source="SYNTHETIC_ATTACK"), Action("pet_skill", card_source="SYNTHETIC_PROTECT")
    for profile, damage, protection in (("simple", .7, .5), ("careful", .7, .25),
                                       ("skill_rush", .5, .25), ("mega_icarus_spam_skill", .65, .35)):
        actions = [card(attack, 1, 0), card(protect, damage, protection)]
        for hp, label in ((100, "healthy"), (40, "pressure_before_30")):
            s = snapshot(profile, hp=hp, baseline=attack, model_updates=dict(action_models=actions))
            result.append((profile + ":" + label, s,
                           "RETAIN_BASELINE" if hp == 100 else "PROPOSE_OFFLINE",
                           None if hp == 100 else protect))
    for mode, rage, label in (("joint_calibrated", 0, "D01_joint_3Sword_5Rage"),
                              ("preexisting", 100, "D02_existing_Rage"),
                              ("preexisting", 0, "D03_insufficient_Rage"),
                              ("after_gain", 60, "D04_effect_order_missing")):
        rage_cells = 0 if mode == "preexisting" else 2 if mode == "after_gain" else 5
        s = snapshot("demon_aegis_farm", board=demon_board(rage_cells=rage_cells), rage=rage, setting=4)
        s = with_model(s, demon_certificates=[certificate(s, mode=mode)])
        expected = "PROPOSE_OFFLINE" if mode == "joint_calibrated" or rage == 100 else "RETAIN_BASELINE"
        result.append((label, s, expected, Action("swap", TARGET) if expected == "PROPOSE_OFFLINE" else None))
    s = snapshot("demon_aegis_farm", board=demon_board(swords=4), setting=4)
    s = with_model(s, demon_certificates=[certificate(s, swords=4, rage=0)])
    result.append(("D05_scoped_4Sword", s, "PROPOSE_OFFLINE", None))
    s = snapshot("demon_aegis_farm", board=demon_board(swords=1, multiplier=3), rage=100, setting=4)
    s = with_model(s, demon_certificates=[certificate(s)])
    result.append(("D06_oneSword_x3_is_not_3physical", s, "RETAIN_BASELINE", None))
    s = snapshot("demon_aegis_farm", board=demon_board(cross=True), rage=100, setting=4)
    s = with_model(s, demon_certificates=[certificate(s)])
    result.append(("D07_cross_union", s, "PROPOSE_OFFLINE", None))
    s = snapshot("demon_aegis_farm", board=demon_board(), rage=100, setting=4)
    result.append(("D_scope_mismatch", with_model(s, demon_certificates=[certificate(s, account="OTHER")]), "PROPOSE_OFFLINE", None))
    s = snapshot("mega_icarus_spam_skill", hp=40, mana=0, baseline=attack,
                 model_updates=dict(action_models=[card(attack, 1, 0, cost=0), card(protect, .65, .35)]))
    result.append(("Mega_insufficient_actual_cost", s, "RETAIN_BASELINE", None))
    s = snapshot("mega_icarus_spam_skill", hp=40, baseline=attack)
    result.append(("C05_opaque_baseline_effect", s, "RETAIN_BASELINE", None))
    s = snapshot("bu_win", hp=1, model_updates=dict(team_intent="FEED_BOSS_SWORD_AND_TURNOVER"))
    scores = plan(s).scores
    if scores:
        lowest = min(scores, key=lambda c: c.utility.low)
        s = replace(s, baseline=lowest.action)
    result.extend((label, change(s, "self.hp", hp), "PROPOSE_OFFLINE", None)
                  for label, hp in (("BuWin_local_death_intent", 1), ("BuWin_healthy_same_intent", 100)))
    s = snapshot("bu_win", hp=1)
    result.append(("BuWin_missing_team_context", s, "RETAIN_BASELINE", None))
    s = snapshot(legal_updates=dict(owner="EVOLUTION_CONTINUATION"))
    result.append(("P07_continuation_owned_by_existing_flow", s, "RETAIN_BASELINE", None))
    s = snapshot(legal_updates=dict(blocked=True))
    result.append(("pending_boundary", s, "RETAIN_BASELINE", None))
    s = snapshot(board=board_data("sparse"), baseline=Action("pass"))
    result.append(("no_legal_root_does_not_invent_PASS", s, "RETAIN_BASELINE", None))
    return result


def quantiles(values):
    ordered = sorted(values)
    def q(p):
        index = (len(ordered) - 1) * p
        a, b = int(index), min(int(index) + 1, len(ordered) - 1)
        return ordered[a] + (ordered[b] - ordered[a]) * (index - a)
    return dict(n=len(values), p50_ms=statistics.median(values), p95_ms=q(.95),
                p99_ms=q(.99), max_ms=max(values), quantiles="linear_interpolation_descriptive_small_n")


def main():
    parser = argparse.ArgumentParser(__doc__)
    parser.add_argument("--output-dir", type=Path, required=True)
    parser.add_argument("--samples", type=int, default=30)
    args = parser.parse_args()
    if not 5 <= args.samples <= 100:
        parser.error("samples must be 5..100 per profile/board stratum")
    target = args.output_dir.resolve()
    if not target.is_relative_to(ROOT / "docs/phase5/artifacts") or target.exists():
        parser.error("output-dir must be NEW under docs/phase5/artifacts")
    target.mkdir(parents=True)
    cases = scenarios()
    decisions, coverage = [], []
    for name, s, expected, action in cases:
        decision = plan(s)
        ok = (expected is None or decision.disposition == expected) and (action is None or decision.proposal == action)
        coverage.append(dict(case=name, snapshot_id=s.snapshot_id, expected_disposition=expected,
                             disposition=decision.disposition, reason=decision.reason, check=ok,
                             evidence_tier="SYNTHETIC_SPEC", observed_win=False))
        decisions.append(dict(case=name, decision=decision.to_dict()))
    (target / "scenario_inputs.jsonl").write_text("\n".join(canonical_json(dict(case=n, snapshot=s.to_dict()))
                                                          for n, s, _, _ in cases) + "\n", encoding="utf-8")
    (target / "scenario_scores.jsonl").write_text("\n".join(canonical_json(d) for d in decisions) + "\n", encoding="utf-8")
    _, historical = load_dataset(DATASET)
    replay = [dict(snapshot_id=r.snapshot.snapshot_id, disposition=(d := plan(r.snapshot)).disposition,
                   reason=d.reason, recorded_chosen_action=r.chosen.action.to_dict() if r.chosen else None,
                   alternative_outcomes="NOT_OBSERVED") for r in historical]
    profiles = ("simple", "careful", "skill_rush", "demon_aegis_farm", "mega_icarus_spam_skill", "bu_win")
    timings = []
    for profile in profiles:
        for board_kind in ("sparse", "reference", "dense_three_gems"):
            s = snapshot(profile, board=board_data(board_kind),
                         model_updates=dict(team_intent="FEED_BOSS_SWORD_AND_TURNOVER"))
            plan(s)  # One excluded warmup per stratum. No serialization/file IO timed.
            durations = []
            for _ in range(args.samples):
                start = time.perf_counter_ns()
                plan(s)
                durations.append((time.perf_counter_ns() - start) / 1e6)
            timings.append(dict(profile=profile, board=board_kind,
                                legal_swaps=len(evaluate_all_moves(s.board_state())),
                                measurements_ms=durations, **quantiles(durations)))
    files = ("src/pokiguard_v2/reasoning_planner.py", "tools/evaluate_reasoning_planner.py",
             "tests/test_reasoning_planner.py")
    hashes = {p: hashlib.sha256((ROOT / p).read_bytes()).hexdigest() for p in files}
    b1 = json.loads((ROOT / "docs/phase5/datasets/5b1_verification.json").read_text(encoding="utf-8"))
    preserved = {p: hashlib.sha256((ROOT / p).read_bytes()).hexdigest() == h
                 for p, h in b1["file_sha256"].items()}
    dependencies = {p: hashlib.sha256((ROOT / p).read_bytes()).hexdigest() for p in
                    ("src/pokiguard_v2/board_simulator.py", "src/pokiguard_v2/demon_aegis.py",
                     "src/pokiguard_v2/state.py", "src/pokiguard_v2/reasoning_snapshot.py",
                     "src/pokiguard_v2/reasoning_replay.py", "docs/phase5/datasets/manifest.json")}
    report = dict(schema="pokiguard.reasoning.b2_verification.v1", config=VERSION_CONFIG.plain(),
                  source_files=hashes, source_fingerprint=digest(hashes),
                  dependency_files=dependencies, b1_files_preserved=preserved,
                  scenarios=coverage, historical_dispositions=replay,
                  benchmark=dict(runtime=platform.python_version(), platform=platform.platform(),
                                 clock="perf_counter_ns", includes="pure plan including simulator and immutable explanation",
                                 excludes="file IO/decision serialization/provider/capture/preflight/input/worker/log sink",
                                 end_to_end_deadline_proven=False, strata=timings),
                  all_expected_checks_pass=all(c["check"] for c in coverage),
                  production_wiring=False, live_input=False)
    (target / "verification.json").write_text(json.dumps(report, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    artifacts = {p.name: hashlib.sha256(p.read_bytes()).hexdigest() for p in sorted(target.iterdir())}
    (target / "manifest.json").write_text(json.dumps(dict(schema="pokiguard.reasoning.b2_artifacts.v1", files=artifacts), indent=2) + "\n", encoding="utf-8")
    print(json.dumps(dict(output=str(target), scenarios=len(cases), expected_checks_pass=report["all_expected_checks_pass"],
                          historical=len(replay), benchmark_samples=18 * args.samples,
                          source_fingerprint=report["source_fingerprint"])))
    return 0 if report["all_expected_checks_pass"] else 1


if __name__ == "__main__":
    raise SystemExit(main())
