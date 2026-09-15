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
    duration_seconds,
    extract_run,
    numeric_stats,
    relative_reduction,
    summarize_mode,
)


COUNTER_DEFAULTS = {
    "pet_skill_attempts": 0,
    "pet_skill_perfect": 0,
    "pet_skill_zero_input_failures": 0,
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
            "main_pet": "normal",
            "evolution": "normal",
            "damage_card": "default_attack",
            "intelligence": "basic",
        }
    return {
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
                    "event": "pet_skill_dispatch_result",
                    "result": {
                        "kind": "SUCCESS_PERFECT",
                        "state": "COMPLETE",
                        "card_clicks": 1,
                        "space_presses": 1,
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
