from __future__ import annotations

import hashlib
import json
from pathlib import Path
import tempfile
import unittest

from pokiguard_v2.phase4d1_benchmark import (
    ARM_A,
    ARM_B,
    ARM_MODES,
    BenchmarkDataError,
    MANIFEST_SCHEMA,
    analyze_manifest,
    assign_run,
    source_fingerprint,
)


CONFIG = {
    "play_style": "skill_rush",
    "intelligence": "basic",
    "main_pet": "legendary",
    "evolution": "none",
    "damage_card": "pet_skill",
    "audition_mode": "audition_v3",
    "board_input_mode": "two_click",
    "cast_when_boss_hp_below": 30000,
    "cast_mana_stockpile": 480,
    "rage_target": 100,
    "pet_skill_fire_condition": "sword_count",
    "pet_skill_fire_value": 7,
}


def _write_json(path: Path, value: object) -> None:
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(json.dumps(value), encoding="utf-8")


def _sha(path: Path) -> str:
    return hashlib.sha256(path.read_bytes()).hexdigest()


def _counter_payload(*, perfect: int = 1) -> dict[str, int]:
    from pokiguard_v2.phase4d1_benchmark import CRITICAL_COUNTERS

    return {**{name: 0 for name in CRITICAL_COUNTERS}, "pet_skill_perfect": perfect}


class Phase4D1BenchmarkTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temp = tempfile.TemporaryDirectory()
        self.root = Path(self.temp.name)
        (self.root / "src" / "pokiguard_v2").mkdir(parents=True)
        (self.root / "tools").mkdir()
        (self.root / "src" / "pokiguard_v2" / "runtime.py").write_text("VALUE = 1\n")
        (self.root / "tools" / "runner.py").write_text("print('ok')\n")
        (self.root / "run_tool.bat").write_text("@echo off\n")
        self.game = self.root / "game.exe"
        self.assembly = self.root / "GameAssembly.dll"
        self.game.write_bytes(b"game")
        self.assembly.write_bytes(b"assembly")
        source = source_fingerprint(self.root)
        self.manifest = {
            "schema": MANIFEST_SCHEMA,
            "prepared_at": "2026-09-29T00:00:00.000Z",
            "source": {"commit": "a" * 40, "worktree_dirty": True, **source},
            "app_version": "v1.1.0",
            "game_build": {
                "executable": {"path": str(self.game), "sha256": _sha(self.game)},
                "game_assembly": {
                    "path": str(self.assembly),
                    "sha256": _sha(self.assembly),
                },
            },
            "expected_target": {"boss_id": "1289", "boss_name": "Starburst"},
            "gameplay_config": CONFIG,
            "required_completed_matches_per_arm": 5,
            "max_match_attempts_per_arm": 8,
            "execution_order": [ARM_A, ARM_B],
            "accepted_branch": "PINNED_FOREGROUND_EXISTING_INPUT_LEASE",
            "focus_schedule": {},
            "arms": {
                ARM_A: {"input_delivery_mode": ARM_MODES[ARM_A], "farm_run_id": "run_a"},
                ARM_B: {"input_delivery_mode": ARM_MODES[ARM_B], "farm_run_id": "run_b"},
            },
        }
        self.logs = self.root / "logs"
        self._make_run("run_a", ARM_A)
        self._make_run("run_b", ARM_B)
        self.manifest_path = self.root / "manifest.json"
        _write_json(self.manifest_path, self.manifest)

    def tearDown(self) -> None:
        self.temp.cleanup()

    def _make_run(self, run_id: str, arm: str) -> None:
        mode = ARM_MODES[arm]
        directory = self.logs / run_id
        directory.mkdir(parents=True)
        attempts = []
        input_records = []
        events: list[dict[str, object]] = [
            {
                "timestamp": "2026-09-29T00:00:00.000Z",
                "event": "farm_run_started",
                "inputDeliveryMode": mode,
            }
        ]
        for index in range(1, 6):
            attempts.append(
                {
                    "attempt_index": index,
                    "match_id": f"M_{index}",
                    "result": "WIN",
                    "start_timestamp": f"2026-09-29T00:0{index}:00.000Z",
                    "end_timestamp": f"2026-09-29T00:0{index}:10.000Z",
                }
            )
            for domain, offset in (
                ("BOSS_ENTRY", "00.000"),
                ("GAMEPLAY_SWAP", "02.000"),
                ("GAMEPLAY_PET_SKILL", "05.000"),
                ("POSTMATCH_CONFIRM", "09.000"),
            ):
                input_records.append(
                    {
                        "domain": domain,
                        "attempt_index": index,
                        "sent": True,
                        "timestamp": f"2026-09-29T00:0{index}:{offset}Z",
                        "detail": "SENT",
                    }
                )
            events.extend(
                [
                    {
                        "timestamp": f"2026-09-29T00:0{index}:01.000Z",
                        "event": "match_entry_result",
                        "entry": {"status": "PASS"},
                    },
                    {
                        "timestamp": f"2026-09-29T00:0{index}:09.100Z",
                        "event": "postmatch_ui_audit",
                        "consistency": "CONSISTENT",
                    },
                    {
                        "timestamp": f"2026-09-29T00:0{index}:10.000Z",
                        "event": "combat_controller_returned",
                        "summary": {"counters": _counter_payload()},
                    },
                ]
            )
        if arm == ARM_B:
            events.insert(
                1,
                {
                    "timestamp": "2026-09-29T00:00:00.010Z",
                    "event": "pinned_input_session_started",
                },
            )
            for index in range(1, 6):
                action_id = f"SWAP:M_{index}:1"
                events.extend(
                    [
                        {
                            "timestamp": f"2026-09-29T00:0{index}:02.000Z",
                            "event": "foreground_lease_acquired",
                            "actionIdentity": action_id,
                            "gameAlreadyForeground": index != 2,
                            "focusRequestCount": 1 if index == 2 else 0,
                        },
                        {
                            "timestamp": f"2026-09-29T00:0{index}:02.500Z",
                            "event": "foreground_lease_finished",
                            "action_identity": action_id,
                            "status": "COMPLETE",
                            "action_attempted": True,
                            "action_succeeded": True,
                            "focus_restored": True,
                            "cursor_restored": True,
                            "user_moved_cursor": False,
                            "lease_duration_seconds": 0.5,
                        },
                        {
                            "timestamp": f"2026-09-29T00:0{index}:05.000Z",
                            "event": "foreground_qte_lease_acquired",
                            "action_identity": f"QTE:M_{index}",
                            "focusRequestCount": 0,
                        },
                        {
                            "timestamp": f"2026-09-29T00:0{index}:06.000Z",
                            "event": "foreground_qte_lease_released",
                            "action_identity": f"QTE:M_{index}",
                            "status": "COMPLETE",
                            "guard_released": True,
                            "focus_restored": True,
                            "cursor_restored": True,
                            "duration_seconds": 1.0,
                        },
                    ]
                )
            events.append(
                {
                    "timestamp": "2026-09-29T00:06:00.000Z",
                    "event": "pinned_input_session_closed",
                    "result": {"status": "UNPINNED"},
                }
            )
        snapshot = {
            "farm_run_id": run_id,
            "target": {"boss_id": "1289", "boss_name": "Starburst"},
            "limits": {
                "target_completed_matches": 5,
                "max_technical_recoveries": 1,
                "max_match_attempts": 8,
            },
            "state": "FARM_RUN_COMPLETE",
            "match_attempts": 5,
            "completed_matches": 5,
            "wins": 5,
            "losses": 0,
            "unknown_results": 0,
            "technical_aborts": 0,
            "technical_recoveries": 0,
            "technical_exits": 0,
            "safe_stops": 0,
            "attempts": attempts,
            "input_records": input_records,
            "total_swap_acknowledged": 5,
            "total_cast_accepted": 0,
            "total_evolve_success": 0,
            "gameplay_config": CONFIG,
            "input_delivery_mode": mode,
            "start_timestamp": "2026-09-29T00:00:00.000Z",
            "end_timestamp": "2026-09-29T00:06:00.000Z",
            "duration_seconds": 360.0,
            "control_state": "RUNNING",
            "stop_reason": "FARM_TARGET_COMPLETED",
        }
        _write_json(
            directory / "run.json",
            {
                "schema": "pokiguard.farm_run.v2",
                "snapshot": snapshot,
                "finalLifecycle": "BOSS_LOBBY",
                "unexpectedError": None,
                "memoryWrites": False,
                "directGameCalls": False,
                "networkManipulation": False,
            },
        )
        _write_json(
            directory / "checkpoint.json",
            {
                "schema_version": "pokiguard.farm_checkpoint.v3",
                "input_delivery_mode": mode,
                "gameplay_config": CONFIG,
                "last_safe_lifecycle": "BOSS_LOBBY",
                "stop_reason": "FARM_TARGET_COMPLETED",
                "finalized_status": "COMPLETED",
            },
        )
        (directory / "events.jsonl").write_text(
            "\n".join(json.dumps(event) for event in events) + "\n", encoding="utf-8"
        )

    def _analyze(self) -> dict[str, object]:
        return analyze_manifest(self.manifest_path, self.logs, workspace=self.root)

    def test_clean_controlled_pair_passes_strong(self) -> None:
        analysis = self._analyze()
        self.assertTrue(analysis["acceptance"]["pass_strong"])
        self.assertEqual(analysis["arms"][ARM_A]["attempts"], 5)
        self.assertEqual(analysis["arms"][ARM_B]["focus_and_cleanup"]["focus_takeovers"], 1)
        self.assertEqual(
            analysis["arms"][ARM_B]["inputs_by_domain"]["GAMEPLAY_SWAP"]["unconfirmed"],
            0,
        )

    def test_mode_mismatch_fails_acceptance(self) -> None:
        path = self.logs / "run_b" / "checkpoint.json"
        checkpoint = json.loads(path.read_text())
        checkpoint["input_delivery_mode"] = "foreground"
        _write_json(path, checkpoint)
        analysis = self._analyze()
        self.assertFalse(analysis["acceptance"]["pass_strong"])
        self.assertIn(
            "B_PINNED_FOREGROUND_BETA: checkpoint input delivery mode differs from manifest arm",
            analysis["acceptance"]["failures"],
        )

    def test_gameplay_config_mismatch_fails_acceptance(self) -> None:
        path = self.logs / "run_b" / "run.json"
        run = json.loads(path.read_text())
        run["snapshot"]["gameplay_config"]["pet_skill_fire_value"] = 8
        _write_json(path, run)
        analysis = self._analyze()
        self.assertFalse(analysis["acceptance"]["pass_strong"])
        self.assertTrue(any("configuration differs" in row for row in analysis["acceptance"]["failures"]))

    def test_extra_attempt_fails_acceptance(self) -> None:
        path = self.logs / "run_a" / "run.json"
        run = json.loads(path.read_text())
        run["snapshot"]["match_attempts"] = 6
        run["snapshot"]["attempts"].append(
            {"attempt_index": 6, "match_id": "M_6", "result": "SAFE_STOP"}
        )
        _write_json(path, run)
        analysis = self._analyze()
        self.assertFalse(analysis["acceptance"]["pass_strong"])
        self.assertTrue(any("extra or incomplete" in row for row in analysis["acceptance"]["failures"]))

    def test_beta_cleanup_failure_fails_acceptance(self) -> None:
        path = self.logs / "run_b" / "events.jsonl"
        events = [json.loads(line) for line in path.read_text().splitlines()]
        finished = next(event for event in events if event["event"] == "foreground_lease_finished")
        finished["cursor_restored"] = False
        path.write_text("\n".join(json.dumps(event) for event in events) + "\n")
        analysis = self._analyze()
        self.assertFalse(analysis["acceptance"]["pass_strong"])
        self.assertTrue(any("cleanup" in row for row in analysis["acceptance"]["failures"]))

    def test_foreground_arm_cannot_use_beta_lease(self) -> None:
        path = self.logs / "run_a" / "events.jsonl"
        with path.open("a", encoding="utf-8") as handle:
            handle.write(json.dumps({"event": "foreground_lease_acquired", "actionIdentity": "bad"}) + "\n")
        analysis = self._analyze()
        self.assertFalse(analysis["acceptance"]["pass_strong"])
        self.assertTrue(any("unexpectedly used" in row for row in analysis["acceptance"]["failures"]))

    def test_pending_run_id_is_rejected(self) -> None:
        self.manifest["arms"][ARM_A]["farm_run_id"] = None
        _write_json(self.manifest_path, self.manifest)
        with self.assertRaises(BenchmarkDataError):
            self._analyze()

    def test_assign_run_preserves_other_arm(self) -> None:
        updated = assign_run(self.manifest, ARM_A, "replacement")
        self.assertEqual(updated["arms"][ARM_A]["farm_run_id"], "replacement")
        self.assertEqual(updated["arms"][ARM_B]["farm_run_id"], "run_b")

    def test_source_change_is_detected(self) -> None:
        (self.root / "tools" / "runner.py").write_text("print('changed')\n")
        analysis = self._analyze()
        self.assertFalse(analysis["acceptance"]["pass_strong"])
        self.assertIn(
            "current production source fingerprint differs from manifest",
            analysis["acceptance"]["failures"],
        )


if __name__ == "__main__":
    unittest.main()
