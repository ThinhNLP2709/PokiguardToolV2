from __future__ import annotations

import ast
import json
from pathlib import Path
import tempfile
import unittest

from pokiguard_v2.phase3d1_benchmark import (
    BenchmarkDataError,
    MODE_A,
    MODE_B,
    classify_post_skill_finisher_trigger,
    classify_skill_fire_reason,
    duration_seconds,
    extract_run,
    mode_b_attack_is_valid_finisher,
    numeric_stats,
    relative_reduction,
    summarize_mode,
)


COUNTER_DEFAULTS = {
    "pet_skill_attempts": 0,
    "pet_skill_perfect": 0,
    "pet_skill_zero_input_failures": 0,
    "pet_skill_after_input_failures": 0,
    "pet_skill_turn_resolution_unconfirmed": 0,
    "pet_skill_same_source_followups": 0,
    "swap_sent": 1,
    "swap_acknowledged": 1,
    "swap_rejected": 0,
    "cast_sent": 0,
    "evolve_attempts": 0,
    "pass_gameplay_inputs": 0,
    "local_turns_observed": 1,
    "attack_priority_evolve_violations": 0,
}

SAFETY_DEFAULTS = {
    "duplicate": 0,
    "misclick": 0,
    "partialInput": 0,
    "wrongTurn": 0,
    "staleAction": 0,
    "bossTurnInput": 0,
    "postmatchInput": 0,
    "lobbyInput": 0,
    "inputAfterCombat": 0,
}


def _profile(mode: str) -> dict[str, str]:
    if mode == MODE_A:
        return {
            "play_style": "simple",
            "main_pet": "normal",
            "evolution": "normal",
            "damage_card": "default_attack",
            "intelligence": "basic",
        }
    return {
        "play_style": "skill_rush",
        "main_pet": "legendary",
        "evolution": "none",
        "damage_card": "pet_skill",
        "intelligence": "basic",
    }


def _write_jsonl(path: Path, records: list[dict[str, object]]) -> None:
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(
        "".join(json.dumps(record) + "\n" for record in records), encoding="utf-8"
    )


def _make_run(
    root: Path,
    *,
    run_id: str,
    mode: str,
    result: str = "WIN",
    no_attempt: bool = False,
    energy_delta: float | None = None,
) -> tuple[Path, dict[str, float]]:
    directory = root / run_id
    directory.mkdir(parents=True)
    attempts: list[dict[str, object]] = []
    input_records: list[dict[str, object]] = []
    events: list[dict[str, object]] = [
        {
            "timestamp": "2026-09-15T00:00:00.000Z",
            "event": "initial_boss_lobby",
            "result": {"ready": True},
        }
    ]
    technical = result == "TECHNICAL_ABORT"
    completed = result in {"WIN", "LOSS", "UNKNOWN"}
    counters = dict(COUNTER_DEFAULTS)
    combat_records: list[dict[str, object]] = []
    if not no_attempt:
        if mode == MODE_B and completed:
            counters["pet_skill_attempts"] = 1
            counters["pet_skill_perfect"] = 1
            counters["local_turns_observed"] = 2
            combat_records.append(
                {
                    "event": "policy_decision",
                    "selectedAction": "pet_skill",
                    "trace": {
                        "selected_action": "pet_skill",
                        "policy_step": "STEP_1_PET_SKILL",
                        "turn_number": 3,
                        "boss_hp": 75_000,
                        "boss_max_hp": 100_000,
                        "boss_hp_ratio": 0.75,
                        "known_sword_count": 8,
                        "current_mana": 200,
                        "current_rage": 200,
                        "required_mana": 200,
                        "required_rage": 200,
                        "skill_fire_trigger": "SWORD_DENSITY",
                        "pet_skill_success_count_current_match": 0,
                        "post_skill_finisher_ready": False,
                        "finisher_trigger": "NONE",
                        "finisher_action": None,
                    },
                }
            )
            combat_records.append(
                {
                    "event": "pet_skill_dispatch_result",
                    "result": {
                        "kind": "SUCCESS_PERFECT",
                        "state": "COMPLETE",
                        "card_clicks": 1,
                        "space_presses": 1,
                        "action_id": {"source_turn": 3},
                        "telemetry": {
                            "runtime_result": "PERFECT",
                            "space_send_elapsed": 3.1,
                            "perfect_start": 3.0,
                            "perfect_end": 3.3,
                            "direction_summary": {
                                "directions_sent": 2,
                                "directions_confirmed": 2,
                                "wrong_directions": 0,
                                "skipped_directions": 0,
                                "duplicate_directions": 0,
                                "stale_directions": 0,
                                "unconfirmed_directions": 0,
                                "blind_retries": 0,
                            },
                        },
                    },
                }
            )
            combat_records.append(
                {
                    "event": "pet_skill_turn_resolved",
                    "sourceTurn": 3,
                    "gameplayInputSent": False,
                    "immediateSkillKill": True,
                }
            )
        attempts.append(
            {
                "attempt_index": 1,
                "match_id": "M_1",
                "start_timestamp": "2026-09-15T00:00:05.000Z",
                "end_timestamp": "2026-09-15T00:00:15.000Z",
                "result": result,
                "local_turns": counters["local_turns_observed"],
                "swap_sent": 1,
                "swap_acknowledged": 1,
                "swap_rejected": 0,
                "cast_sent": 0,
                "evolve_attempts": 0,
                "pass_count": 0,
                "normal_postmatch": completed,
                "technical_recovery": technical,
                "terminal_snapshot": (
                    {"match_id": "M_1", "result": result} if completed else None
                ),
                "result_consistency": "CONSISTENT",
                "duration_seconds": 10.0,
            }
        )
        events.append(
            {
                "timestamp": "2026-09-15T00:00:05.000Z",
                "event": "match_entry_result",
                "attemptIndex": 1,
            }
        )
        if completed:
            events.append(
                {
                    "timestamp": "2026-09-15T00:00:20.000Z",
                    "event": "normal_return_boss_lobby",
                    "attemptIndex": 1,
                    "result": {"ready": True},
                }
            )
        input_records.append({"sent": True})
        combat_records.append(
            {
                "event": "auto_controller_summary",
                "counters": counters,
                "safetyTelemetry": dict(SAFETY_DEFAULTS),
                "policyBranchCoverage": (
                    {"PET_SKILL": 1} if mode == MODE_B and completed else {"SWORD": 1}
                ),
                "petSkillImmediateKills": int(mode == MODE_B and completed),
                "skillRushFireReasons": {
                    "HP_PREP": 0,
                    "SWORD_DENSITY": int(mode == MODE_B and completed),
                    "BOTH": 0,
                    "VERY_LOW_HP": 0,
                    "SETUP_BLOCKED": 0,
                },
                "skillRushEarlyBossPrepSword": 0,
                "skillRushPostSkillFinisher": {
                    "DEFAULT_ATTACK": 0,
                    "SWORD": 0,
                    "SECOND_PET_SKILL": 0,
                },
                "skippedCurrentSwordForResource": 0,
                "selectedMoveLeftDirectBossSword": 0,
                "selectedMoveLeftIndirectBossSword": 0,
                "passExecuted": 0,
            }
        )
        _write_jsonl(directory / "matches" / "attempt_001" / "combat.jsonl", combat_records)
    snapshot = {
        "farm_run_id": run_id,
        "target": {"boss_id": "1289", "boss_name": "Starburst"},
        "gameplay_config": _profile(mode),
        "start_timestamp": "2026-09-15T00:00:00.000Z",
        "end_timestamp": "2026-09-15T00:00:20.000Z",
        "state": "FARM_RUN_COMPLETE",
        "stop_reason": "ENTRY_TIMEOUT" if no_attempt else "FARM_TARGET_COMPLETED",
        "limits": {"target_completed_matches": 1, "max_match_attempts": 2},
        "attempts": attempts,
        "match_attempts": len(attempts),
        "completed_matches": int(completed and not no_attempt),
        "wins": int(result == "WIN" and not no_attempt),
        "losses": int(result == "LOSS" and not no_attempt),
        "unknown_results": int(result == "UNKNOWN" and not no_attempt),
        "technical_aborts": int(technical and not no_attempt),
        "technical_recoveries": int(technical and not no_attempt),
        "input_records": input_records,
    }
    (directory / "run.json").write_text(
        json.dumps({"schema": "pokiguard.farm_run.v2", "snapshot": snapshot}),
        encoding="utf-8",
    )
    _write_jsonl(directory / "events.jsonl", events)
    energy = {"M_1": energy_delta} if energy_delta is not None else {}
    return directory, energy


class Phase3D1BenchmarkTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temporary = tempfile.TemporaryDirectory()
        self.root = Path(self.temporary.name)
        self.boss = {"boss_id": "1289", "boss_name": "Starburst"}

    def tearDown(self) -> None:
        self.temporary.cleanup()

    def test_duration_extraction(self) -> None:
        self.assertEqual(
            12.345,
            duration_seconds(
                "2026-09-15T00:00:00.000Z", "2026-09-15T00:00:12.345Z"
            ),
        )

    def test_valid_completed_row_and_cycle(self) -> None:
        directory, energy = _make_run(
            self.root, run_id="run-a", mode=MODE_A, energy_delta=3
        )
        run = extract_run(
            directory,
            mode=MODE_A,
            expected_boss=self.boss,
            energy_deltas=energy,
        )
        row = run["rows"][0]
        self.assertTrue(row["completed"])
        self.assertEqual(10.0, row["combat_duration_s"])
        self.assertEqual(20.0, row["farm_cycle_duration_s"])
        self.assertEqual(1, row["major_gameplay_actions"])
        self.assertEqual(3.0, row["energy_delta"])

    def test_valid_pass_count_uses_executed_pass_not_safety_counter(self) -> None:
        directory, _ = _make_run(self.root, run_id="run-pass", mode=MODE_A)
        raw = json.loads((directory / "run.json").read_text(encoding="utf-8"))
        raw["snapshot"]["attempts"][0]["pass_count"] = 2
        (directory / "run.json").write_text(json.dumps(raw), encoding="utf-8")

        combat_path = directory / "matches" / "attempt_001" / "combat.jsonl"
        combat = [
            json.loads(line)
            for line in combat_path.read_text(encoding="utf-8").splitlines()
            if line.strip()
        ]
        combat[-1]["passExecuted"] = 2
        combat[-1]["counters"]["pass_gameplay_inputs"] = 0
        _write_jsonl(combat_path, combat)

        run = extract_run(directory, mode=MODE_A, expected_boss=self.boss)
        row = run["rows"][0]
        self.assertEqual(2, row["pass"])
        self.assertEqual(3, row["major_gameplay_actions"])

    def test_technical_abort_row_is_visible_and_not_completed(self) -> None:
        directory, _ = _make_run(
            self.root, run_id="run-abort", mode=MODE_A, result="TECHNICAL_ABORT"
        )
        run = extract_run(directory, mode=MODE_A, expected_boss=self.boss)
        row = run["rows"][0]
        self.assertTrue(row["technical_abort"])
        self.assertFalse(row["completed"])
        self.assertIsNone(row["farm_cycle_duration_s"])
        self.assertEqual(1, run["technical_aborts"])

    def test_zero_input_pre_entry_failure_is_separate(self) -> None:
        directory, _ = _make_run(
            self.root, run_id="run-pre", mode=MODE_A, no_attempt=True
        )
        run = extract_run(directory, mode=MODE_A, expected_boss=self.boss)
        self.assertEqual([], run["rows"])
        self.assertTrue(run["pre_entry_failure"]["zero_input"])
        self.assertEqual(0, run["attempts"])

    def test_exclusion_requires_explicit_reason(self) -> None:
        directory, _ = _make_run(self.root, run_id="run-ex", mode=MODE_A)
        with self.assertRaises(BenchmarkDataError):
            extract_run(
                directory,
                mode=MODE_A,
                expected_boss=self.boss,
                excluded=True,
            )

    def test_exclusion_with_explicit_reason_remains_visible(self) -> None:
        directory, _ = _make_run(self.root, run_id="run-ex-ok", mode=MODE_A)
        run = extract_run(
            directory,
            mode=MODE_A,
            expected_boss=self.boss,
            excluded=True,
            exclusion_reason="operator manually interfered",
        )
        self.assertTrue(run["excluded"])
        self.assertTrue(run["rows"][0]["excluded"])
        self.assertEqual(
            "operator manually interfered", run["rows"][0]["exclusion_reason"]
        )

    def test_statistics_use_population_stddev(self) -> None:
        stats = numeric_stats([1, 2, 3, 4])
        self.assertEqual(2.5, stats["mean"])
        self.assertEqual(2.5, stats["median"])
        self.assertEqual(1.0, stats["min"])
        self.assertEqual(4.0, stats["max"])
        self.assertEqual(1.118, stats["stddev"])

    def test_relative_reduction_and_divide_by_zero(self) -> None:
        self.assertEqual(
            {"difference_a_minus_b": 2.0, "reduction_pct": 20.0},
            relative_reduction(10, 8),
        )
        self.assertEqual(
            {"difference_a_minus_b": -2.0, "reduction_pct": None},
            relative_reduction(0, 2),
        )

    def test_final_skill_fire_reason_classification(self) -> None:
        common = {
            "current_mana": 200,
            "current_rage": 200,
            "required_mana": 200,
            "required_rage": 200,
        }
        self.assertEqual(
            "HP_PREP",
            classify_skill_fire_reason(
                **common, boss_hp_ratio=0.45, known_sword_count=5
            ),
        )
        self.assertEqual(
            "SWORD_DENSITY",
            classify_skill_fire_reason(
                **common, boss_hp_ratio=0.75, known_sword_count=8
            ),
        )
        self.assertEqual(
            "BOTH",
            classify_skill_fire_reason(
                **common, boss_hp_ratio=0.45, known_sword_count=12
            ),
        )
        self.assertEqual(
            "VERY_LOW_HP",
            classify_skill_fire_reason(
                **common, boss_hp_ratio=0.30, known_sword_count=12
            ),
        )
        self.assertEqual(
            "SETUP_BLOCKED",
            classify_skill_fire_reason(
                **common,
                boss_hp_ratio=0.75,
                known_sword_count=7,
                setup_blocked=True,
            ),
        )
        self.assertIsNone(
            classify_skill_fire_reason(
                **{**common, "current_rage": 199},
                boss_hp_ratio=0.45,
                known_sword_count=12,
            )
        )

    def test_setup_blocked_fire_requires_decision_evidence(self) -> None:
        directory, _ = _make_run(self.root, run_id="run-setup-blocked", mode=MODE_B)
        combat_path = directory / "matches" / "attempt_001" / "combat.jsonl"
        combat = [
            json.loads(line)
            for line in combat_path.read_text(encoding="utf-8").splitlines()
            if line.strip()
        ]
        trace = combat[0]["trace"]
        trace.update(
            {
                "boss_hp": 80_000,
                "boss_hp_ratio": 0.8,
                "known_sword_count": 4,
                "skill_fire_trigger": "SETUP_BLOCKED",
                "why_selected": (
                    "Current skill is actionable and resources are ready, but no legal "
                    "direct setup clear is distance-two isolated from known Sword"
                ),
                "failed_higher_priority_branches": [
                    "SKILL_RUSH_BOARD_SETUP: no legal direct clear is at least two "
                    "orthogonal cells from every known Sword"
                ],
            }
        )
        summary = combat[-1]
        summary["skillRushFireReasons"]["SWORD_DENSITY"] = 0
        summary["skillRushFireReasons"]["SETUP_BLOCKED"] = 1
        _write_jsonl(combat_path, combat)

        run = extract_run(directory, mode=MODE_B, expected_boss=self.boss)
        fire = run["rows"][0]["first_skill_fire"]
        self.assertEqual("SETUP_BLOCKED", fire["reason"])
        self.assertTrue(fire["setup_blocked_proven"])

        trace.pop("failed_higher_priority_branches")
        _write_jsonl(combat_path, combat)
        with self.assertRaisesRegex(BenchmarkDataError, "setup-block proof"):
            extract_run(directory, mode=MODE_B, expected_boss=self.boss)

    def test_final_r1_fire_uses_effective_count_and_inclusive_threshold(self) -> None:
        directory, _ = _make_run(self.root, run_id="run-r1-effective", mode=MODE_B)
        combat_path = directory / "matches" / "attempt_001" / "combat.jsonl"
        combat = [
            json.loads(line)
            for line in combat_path.read_text(encoding="utf-8").splitlines()
            if line.strip()
        ]
        trace = combat[0]["trace"]
        trace.update(
            {
                "known_sword_count": 9,
                "known_sword_effective_count": 12,
                "selected_known_gem_count": 9,
                "selected_known_gem_effective_count": 12,
                "pet_skill_fire_value": 12,
                "selected_fire_condition_ready": True,
                "skill_fire_trigger": "SKILL_RUSH_FIRE_CONDITION_READY",
            }
        )
        summary = combat[-1]
        summary["skillRushFireReasons"] = {
            "SKILL_RUSH_FIRE_CONDITION_READY": 1,
            "SETUP_BLOCKED": 0,
        }
        _write_jsonl(combat_path, combat)

        run = extract_run(directory, mode=MODE_B, expected_boss=self.boss)
        fire = run["rows"][0]["first_skill_fire"]
        self.assertTrue(fire["valid"])
        self.assertEqual(9, fire["selected_known_gem_cell_count"])
        self.assertEqual(12, fire["selected_known_gem_effective_count"])

    def test_post_skill_finisher_trigger_strict_boundaries(self) -> None:
        self.assertEqual("BOTH", classify_post_skill_finisher_trigger(25_000, 200_000))
        self.assertEqual(
            "RELATIVE_HP", classify_post_skill_finisher_trigger(40_000, 250_000)
        )
        self.assertEqual("NONE", classify_post_skill_finisher_trigger(60_000, 200_000))
        self.assertEqual("NONE", classify_post_skill_finisher_trigger(30_000, 100_000))

    def test_mode_b_attack_classification(self) -> None:
        self.assertFalse(
            mode_b_attack_is_valid_finisher(
                successful_skill_count=0,
                boss_hp=25_000,
                boss_max_hp=200_000,
                action_turn=19,
                latest_skill_source_turn=None,
                recorded_trigger="BOTH",
            )
        )
        self.assertTrue(
            mode_b_attack_is_valid_finisher(
                successful_skill_count=1,
                boss_hp=25_000,
                boss_max_hp=200_000,
                action_turn=19,
                latest_skill_source_turn=17,
                recorded_trigger="BOTH",
            )
        )
        self.assertFalse(
            mode_b_attack_is_valid_finisher(
                successful_skill_count=1,
                boss_hp=60_000,
                boss_max_hp=200_000,
                action_turn=19,
                latest_skill_source_turn=17,
                recorded_trigger="NONE",
            )
        )
        self.assertFalse(
            mode_b_attack_is_valid_finisher(
                successful_skill_count=1,
                boss_hp=25_000,
                boss_max_hp=200_000,
                action_turn=17,
                latest_skill_source_turn=17,
                recorded_trigger="BOTH",
            )
        )

    def test_attempts_per_completion_and_energy_states(self) -> None:
        a_dir, _ = _make_run(self.root, run_id="run-null", mode=MODE_A)
        b_dir, energy = _make_run(
            self.root, run_id="run-energy", mode=MODE_B, energy_delta=7
        )
        a = extract_run(a_dir, mode=MODE_A, expected_boss=self.boss)
        b = extract_run(
            b_dir, mode=MODE_B, expected_boss=self.boss, energy_deltas=energy
        )
        a_summary = summarize_mode(MODE_A, [a])
        b_summary = summarize_mode(MODE_B, [b])
        self.assertEqual(1.0, a_summary["attempts_per_completion"])
        self.assertEqual("NOT_MEASURED", a_summary["energy"]["status"])
        self.assertEqual("MEASURED", b_summary["energy"]["status"])
        self.assertEqual(7.0, b_summary["energy"]["mean"])
        self.assertEqual(1, b_summary["first_pet_skill_uses"])
        self.assertEqual(1, b_summary["first_pet_skill_kills"])
        self.assertEqual(100.0, b_summary["first_skill_kill_rate_pct"])
        self.assertEqual(1, b_summary["skill_fire_reason_counts"]["SWORD_DENSITY"])

    def test_corrupt_or_incomplete_attempt_fails_closed(self) -> None:
        directory, _ = _make_run(self.root, run_id="run-bad", mode=MODE_A)
        raw = json.loads((directory / "run.json").read_text(encoding="utf-8"))
        raw["snapshot"]["attempts"][0]["duration_seconds"] = None
        (directory / "run.json").write_text(json.dumps(raw), encoding="utf-8")
        with self.assertRaises(BenchmarkDataError):
            extract_run(directory, mode=MODE_A, expected_boss=self.boss)

    def test_analyzer_has_no_runtime_gameplay_imports(self) -> None:
        source_path = Path(__file__).parents[1] / "src" / "pokiguard_v2" / "phase3d1_benchmark.py"
        tree = ast.parse(source_path.read_text(encoding="utf-8"))
        imported = {
            alias.name
            for node in ast.walk(tree)
            if isinstance(node, ast.Import)
            for alias in node.names
        }
        imported.update(
            node.module or ""
            for node in ast.walk(tree)
            if isinstance(node, ast.ImportFrom)
        )
        forbidden = {
            "pokiguard_v2.basic_policy",
            "pokiguard_v2.farm_run",
            "pokiguard_v2.pet_skill_action",
            "pokiguard_v2.win32_input",
        }
        self.assertTrue(forbidden.isdisjoint(imported))


if __name__ == "__main__":
    unittest.main()
