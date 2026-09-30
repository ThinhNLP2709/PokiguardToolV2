from __future__ import annotations

import hashlib
import json
from pathlib import Path
import tempfile
import unittest

from pokiguard_v2.phase4d1_benchmark import CRITICAL_COUNTERS, source_fingerprint
from pokiguard_v2.phase4d2_soak import (
    MANIFEST_SCHEMA,
    SNAPSHOT_SAFETY_COUNTERS,
    SOAK_MODE,
    analyze_soak_manifest,
    assign_soak_run,
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


def _counters() -> dict[str, int]:
    return {**{name: 0 for name in CRITICAL_COUNTERS}, "pet_skill_perfect": 1}


class Phase4D2SoakTests(unittest.TestCase):
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
        self.run_id = "soak_run"
        self.logs = self.root / "logs"
        self.manifest = {
            "schema": MANIFEST_SCHEMA,
            "prepared_at": "2026-09-30T00:00:00.000Z",
            "source": {"commit": "a" * 40, "worktree_dirty": True, **source_fingerprint(self.root)},
            "app_version": "v1.1.0",
            "game_build": {
                "executable": {"path": str(self.game), "sha256": _sha(self.game)},
                "game_assembly": {"path": str(self.assembly), "sha256": _sha(self.assembly)},
            },
            "expected_target": {"boss_id": "1289", "boss_name": "Starburst"},
            "gameplay_config": CONFIG,
            "accepted_branch": "PINNED_FOREGROUND_EXISTING_INPUT_LEASE",
            "input_delivery_mode": SOAK_MODE,
            "required_completed_matches": 25,
            "max_match_attempts": 32,
            "required_completed_matches_per_arm": 25,
            "max_match_attempts_per_arm": 32,
            "farm_run_id": self.run_id,
            "focus_exercise": {
                "minimum_focus_takeovers": 25,
                "minimum_qte_focus_takeovers": 5,
                "plan": "test",
            },
            "natural_recovery": {
                "required_live_occurrence": False,
                "absent_status": "NOT_OBSERVED",
                "accepted_replay_report": "docs/phase4/phase4c2_report.md",
                "accepted_replay_evidence": "2/2 PASS STRONG",
            },
        }
        self.manifest_path = self.root / "manifest.json"
        _write_json(self.manifest_path, self.manifest)
        self._make_run()

    def tearDown(self) -> None:
        self.temp.cleanup()

    def _make_run(self) -> None:
        directory = self.logs / self.run_id
        directory.mkdir(parents=True)
        attempts: list[dict[str, object]] = []
        inputs: list[dict[str, object]] = []
        events: list[dict[str, object]] = [
            {
                "timestamp": "2026-09-30T00:00:00.000Z",
                "event": "farm_run_started",
                "inputDeliveryMode": SOAK_MODE,
            },
            {
                "timestamp": "2026-09-30T00:00:00.001Z",
                "event": "foreground_lease_pin",
                "status": "PINNED",
            },
            {
                "timestamp": "2026-09-30T00:00:00.002Z",
                "event": "pinned_input_session_started",
                "exactBinding": {
                    "window": {"hwnd": 100, "pid": 200, "title": "PokiguardOnlines"},
                    "geometry": {"left": 10, "top": 20, "width": 800, "height": 400},
                },
            },
            {
                "timestamp": "2026-09-30T00:00:00.003Z",
                "event": "pinned_input_executor_bound",
                "backend": "NativeForegroundLeaseBackend",
            },
        ]
        for index in range(1, 26):
            match_id = f"M_{index:02d}"
            minute = index % 60
            attempts.append(
                {
                    "attempt_index": index,
                    "match_id": match_id,
                    "result": "WIN",
                    "normal_postmatch": True,
                    "technical_recovery": False,
                    "terminal_result_confidence": "STRONG",
                    "result_consistency": "CONSISTENT",
                    "local_turns": 6,
                    "boss_turns": 5,
                    "swap_sent": 5,
                    "swap_acknowledged": 5,
                    "swap_rejected": 0,
                    "swap_aborted_state_changed": 0,
                    "cast_rejected": 0,
                    "evolve_failed": 0,
                    "sequence_desync": 0,
                }
            )
            for domain, second in (
                ("BOSS_ENTRY", 0),
                ("GAMEPLAY_SWAP", 2),
                ("GAMEPLAY_PET_SKILL", 5),
                ("POSTMATCH_CONFIRM", 9),
            ):
                inputs.append(
                    {
                        "domain": domain,
                        "attempt_index": index,
                        "sent": True,
                        "timestamp": f"2026-09-30T00:{minute:02d}:{second:02d}.000Z",
                    }
                )
            events.extend(
                [
                    {
                        "timestamp": f"2026-09-30T00:{minute:02d}:01.000Z",
                        "event": "match_entry_result",
                        "attemptIndex": index,
                        "entry": {"status": "PASS"},
                    },
                    {
                        "timestamp": f"2026-09-30T00:{minute:02d}:09.100Z",
                        "event": "postmatch_ui_audit",
                        "attemptIndex": index,
                        "consistency": "CONSISTENT",
                    },
                    {
                        "timestamp": f"2026-09-30T00:{minute:02d}:10.000Z",
                        "event": "normal_return_boss_lobby",
                        "attemptIndex": index,
                        "result": {"ready": True},
                    },
                    {
                        "timestamp": f"2026-09-30T00:{minute:02d}:08.000Z",
                        "event": "combat_controller_returned",
                        "attemptIndex": index,
                        "summary": {"counters": _counters()},
                    },
                ]
            )
            mouse_id = f"SWAP:{match_id}:1"
            qte_id = f"PET_SKILL_QTE:{match_id}:11:7"
            events.extend(
                [
                    {
                        "timestamp": f"2026-09-30T00:{minute:02d}:02.000Z",
                        "event": "foreground_lease_acquired",
                        "actionIdentity": mouse_id,
                        "foregroundGame": 100,
                        "gameAlreadyForeground": False,
                        "focusRequestCount": 1,
                    },
                    {
                        "timestamp": f"2026-09-30T00:{minute:02d}:02.500Z",
                        "event": "foreground_lease_finished",
                        "action_identity": mouse_id,
                        "status": "COMPLETE",
                        "action_attempted": True,
                        "action_succeeded": True,
                        "foreground_after_acquire": 100,
                        "foreground_after_action": 100,
                        "focus_restored": True,
                        "cursor_restored": True,
                        "user_moved_cursor": False,
                        "lease_duration_seconds": 0.5,
                    },
                    {
                        "timestamp": f"2026-09-30T00:{minute:02d}:05.000Z",
                        "event": "foreground_qte_lease_acquired",
                        "action_identity": qte_id,
                        "foreground_after": 100,
                        "focusRequestCount": 1 if index <= 5 else 0,
                    },
                    {
                        "timestamp": f"2026-09-30T00:{minute:02d}:07.000Z",
                        "event": "foreground_qte_lease_released",
                        "action_identity": qte_id,
                        "status": "COMPLETE",
                        "guard_released": True,
                        "focus_restored": True,
                        "cursor_restored": True,
                        "duration_seconds": 2.0,
                    },
                ]
            )
        events.append(
            {
                "timestamp": "2026-09-30T00:58:59.000Z",
                "event": "foreground_lease_unpin",
                "status": "UNPINNED",
            }
        )
        events.append(
            {
                "timestamp": "2026-09-30T00:59:00.000Z",
                "event": "pinned_input_session_closed",
                "result": {"status": "UNPINNED"},
            }
        )
        snapshot = {
            "farm_run_id": self.run_id,
            "target": {"boss_id": "1289", "boss_name": "Starburst"},
            "limits": {
                "target_completed_matches": 25,
                "max_technical_recoveries": 7,
                "max_match_attempts": 32,
            },
            "state": "FARM_RUN_COMPLETE",
            "match_attempts": 25,
            "completed_matches": 25,
            "wins": 25,
            "losses": 0,
            "unknown_results": 0,
            "technical_aborts": 0,
            "technical_recoveries": 0,
            "technical_exits": 0,
            "safe_stops": 0,
            "attempts": attempts,
            "input_records": inputs,
            "total_swap_acknowledged": 25,
            "total_cast_accepted": 0,
            "total_evolve_success": 0,
            "gameplay_config": CONFIG,
            "input_delivery_mode": SOAK_MODE,
            "stop_reason": "FARM_TARGET_COMPLETED",
            "safety": {name: 0 for name in SNAPSHOT_SAFETY_COUNTERS},
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
                "emergencyControl": {"authorizedInputOperationsAfterAcknowledgement": 0},
                "finalInvariant": "PHASE2E2_UI_BOUNDED_COMPLETED",
                "controllerMemory": {
                    "available": True,
                    "interpretation": "no observed unbounded growth during this bounded soak",
                },
            },
        )
        _write_json(
            directory / "checkpoint.json",
            {
                "input_delivery_mode": SOAK_MODE,
                "gameplay_config": CONFIG,
                "last_safe_lifecycle": "BOSS_LOBBY",
                "stop_reason": "FARM_TARGET_COMPLETED",
                "finalized_status": "COMPLETED",
            },
        )
        (directory / "events.jsonl").write_text(
            "\n".join(json.dumps(event) for event in events) + "\n", encoding="utf-8"
        )

    def _analysis(self) -> dict[str, object]:
        return analyze_soak_manifest(self.manifest_path, self.logs, workspace=self.root)

    def test_clean_25_match_soak_passes_strong(self) -> None:
        analysis = self._analysis()
        self.assertTrue(analysis["acceptance"]["pass_strong"])
        self.assertEqual(analysis["run"]["completed"], 25)
        self.assertEqual(analysis["focus_and_cleanup"]["focus_takeovers"], 30)
        self.assertEqual(analysis["recovery_coverage"]["status"], "NOT_OBSERVED")

    def test_natural_reentry_is_recorded_without_becoming_mandatory(self) -> None:
        path = self.logs / self.run_id / "events.jsonl"
        with path.open("a", encoding="utf-8") as handle:
            handle.write(json.dumps({"event": "chinh_phuc_map_return", "result": {"ready": True}}) + "\n")
        analysis = self._analysis()
        self.assertTrue(analysis["acceptance"]["pass_strong"])
        self.assertEqual(analysis["recovery_coverage"]["status"], "OBSERVED")
        self.assertEqual(analysis["recovery_coverage"]["navigation_reentries"], 1)

    def test_extra_attempt_after_target_fails(self) -> None:
        path = self.logs / self.run_id / "run.json"
        run = json.loads(path.read_text())
        run["snapshot"]["match_attempts"] = 26
        run["snapshot"]["attempts"].append({"attempt_index": 26, "result": "SAFE_STOP"})
        _write_json(path, run)
        analysis = self._analysis()
        self.assertFalse(analysis["acceptance"]["pass_strong"])
        self.assertTrue(any("extra attempt" in row for row in analysis["acceptance"]["failures"]))

    def test_snapshot_safety_counter_fails(self) -> None:
        path = self.logs / self.run_id / "run.json"
        run = json.loads(path.read_text())
        run["snapshot"]["safety"]["wrong_turn_input"] = 1
        _write_json(path, run)
        analysis = self._analysis()
        self.assertFalse(analysis["acceptance"]["pass_strong"])
        self.assertTrue(any("wrong_turn_input" in row for row in analysis["acceptance"]["failures"]))

    def test_missing_per_match_qte_proof_fails(self) -> None:
        path = self.logs / self.run_id / "events.jsonl"
        events = [json.loads(line) for line in path.read_text().splitlines()]
        for event in events:
            if event.get("event") == "combat_controller_returned" and event.get("attemptIndex") == 1:
                event["summary"]["counters"]["pet_skill_perfect"] = 0
        events = [
            event
            for event in events
            if not (
                event.get("event") in {"foreground_qte_lease_acquired", "foreground_qte_lease_released"}
                and "M_01" in str(event.get("action_identity") or "")
            )
        ]
        path.write_text("\n".join(json.dumps(event) for event in events) + "\n")
        analysis = self._analysis()
        self.assertFalse(analysis["acceptance"]["pass_strong"])
        self.assertTrue(any("PERFECT/QTE" in row for row in analysis["acceptance"]["failures"]))

    def test_focus_exercise_minimum_fails(self) -> None:
        path = self.logs / self.run_id / "events.jsonl"
        events = [json.loads(line) for line in path.read_text().splitlines()]
        for event in events:
            if event.get("event") in {"foreground_lease_acquired", "foreground_qte_lease_acquired"}:
                event["focusRequestCount"] = 0
                event["gameAlreadyForeground"] = True
        path.write_text("\n".join(json.dumps(event) for event in events) + "\n")
        analysis = self._analysis()
        self.assertFalse(analysis["acceptance"]["pass_strong"])
        self.assertTrue(any("focus takeover exercise" in row for row in analysis["acceptance"]["failures"]))

    def test_safe_preinput_policy_reread_accounts_for_expired_action(self) -> None:
        path = self.logs / self.run_id / "events.jsonl"
        events = [json.loads(line) for line in path.read_text().splitlines()]
        summary = next(
            event["summary"]
            for event in events
            if event.get("event") == "combat_controller_returned"
        )
        summary["counters"]["expired_actions"] = 1
        path.write_text("\n".join(json.dumps(event) for event in events) + "\n")
        combat = self.logs / self.run_id / "matches" / "attempt_001" / "combat.jsonl"
        combat.parent.mkdir(parents=True, exist_ok=True)
        combat.write_text(
            json.dumps(
                {
                    "event": "action_result",
                    "result": "ACTION_ABORTED_STATE_CHANGED",
                    "reason": "POLICY_CHANGED_ON_FRESH_REREAD",
                    "identity": {"action": "swap"},
                }
            )
            + "\n",
            encoding="utf-8",
        )

        analysis = self._analysis()

        self.assertTrue(analysis["acceptance"]["pass_strong"])
        self.assertEqual(analysis["critical_counters"]["expired_actions"], 1)
        self.assertEqual(analysis["effective_critical_counters"]["expired_actions"], 0)
        self.assertEqual(analysis["expiration_accounting"]["safe_preinput_replans"], 1)

    def test_unaccounted_expired_action_remains_critical(self) -> None:
        path = self.logs / self.run_id / "events.jsonl"
        events = [json.loads(line) for line in path.read_text().splitlines()]
        summary = next(
            event["summary"]
            for event in events
            if event.get("event") == "combat_controller_returned"
        )
        summary["counters"]["expired_actions"] = 1
        path.write_text("\n".join(json.dumps(event) for event in events) + "\n")

        analysis = self._analysis()

        self.assertFalse(analysis["acceptance"]["pass_strong"])
        self.assertEqual(analysis["effective_critical_counters"]["expired_actions"], 1)
        self.assertTrue(
            any("critical combat counter" in row for row in analysis["acceptance"]["failures"])
        )

    def test_lease_cleanup_failure_fails(self) -> None:
        path = self.logs / self.run_id / "events.jsonl"
        events = [json.loads(line) for line in path.read_text().splitlines()]
        release = next(event for event in events if event.get("event") == "foreground_qte_lease_released")
        release["guard_released"] = False
        path.write_text("\n".join(json.dumps(event) for event in events) + "\n")
        analysis = self._analysis()
        self.assertFalse(analysis["acceptance"]["pass_strong"])
        self.assertTrue(any("cleanup" in row for row in analysis["acceptance"]["failures"]))

    def test_wrong_hwnd_during_lease_fails(self) -> None:
        path = self.logs / self.run_id / "events.jsonl"
        events = [json.loads(line) for line in path.read_text().splitlines()]
        acquired = next(event for event in events if event.get("event") == "foreground_lease_acquired")
        acquired["foregroundGame"] = 999
        path.write_text("\n".join(json.dumps(event) for event in events) + "\n")
        analysis = self._analysis()
        self.assertFalse(analysis["acceptance"]["pass_strong"])
        self.assertTrue(any("different from exact binding" in row for row in analysis["acceptance"]["failures"]))

    def test_mode_and_config_are_immutable(self) -> None:
        path = self.logs / self.run_id / "checkpoint.json"
        checkpoint = json.loads(path.read_text())
        checkpoint["input_delivery_mode"] = "foreground"
        checkpoint["gameplay_config"]["pet_skill_fire_value"] = 8
        _write_json(path, checkpoint)
        analysis = self._analysis()
        self.assertFalse(analysis["acceptance"]["pass_strong"])
        self.assertTrue(any("mode differs" in row for row in analysis["acceptance"]["failures"]))
        self.assertTrue(any("configuration differs" in row for row in analysis["acceptance"]["failures"]))

    def test_source_change_is_detected(self) -> None:
        (self.root / "tools" / "runner.py").write_text("print('changed')\n")
        analysis = self._analysis()
        self.assertFalse(analysis["acceptance"]["pass_strong"])
        self.assertIn(
            "current production source fingerprint differs from manifest",
            analysis["acceptance"]["failures"],
        )

    def test_assign_run_preserves_manifest(self) -> None:
        updated = assign_soak_run(self.manifest, "replacement")
        self.assertEqual(updated["farm_run_id"], "replacement")
        self.assertEqual(updated["required_completed_matches"], 25)


if __name__ == "__main__":
    unittest.main()
