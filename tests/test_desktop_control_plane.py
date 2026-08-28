from __future__ import annotations

import tempfile
import threading
import time
from dataclasses import replace
from pathlib import Path
import unittest

from pokiguard_v2.basic_policy import Intelligence, ManaPriority, PlayStyle
from pokiguard_v2.desktop_control_plane import (
    DesktopConfig,
    DesktopControlPlane,
    LatestCheckpointSummaryProvider,
    RuntimeObservation,
    SnapshotPoller,
)
from pokiguard_v2.farm_checkpoint import (
    CHECKPOINT_SCHEMA,
    CheckpointPayload,
    write_checkpoint,
)


class _Runtime:
    def __init__(self, values: list[RuntimeObservation | Exception]) -> None:
        self.values = values
        self.reads = 0
        self.closes = 0

    def read(self) -> RuntimeObservation:
        value = self.values[min(self.reads, len(self.values) - 1)]
        self.reads += 1
        if isinstance(value, Exception):
            raise value
        return value

    def close(self) -> None:
        self.closes += 1


class _BlockingRuntime:
    def __init__(self) -> None:
        self.entered = threading.Event()
        self.release = threading.Event()
        self.closes = 0

    def read(self) -> RuntimeObservation:
        self.entered.set()
        self.release.wait(5.0)
        return RuntimeObservation(True, True, 123, "x64", "BOSS_LOBBY")

    def close(self) -> None:
        self.closes += 1


def _checkpoint_payload() -> CheckpointPayload:
    now = time.time()
    return CheckpointPayload(
        schema_version=CHECKPOINT_SCHEMA,
        farm_run_id="ui-summary-run",
        continuation_of=None,
        checkpoint_seq=1,
        created_at=now,
        updated_at=now,
        target_boss_id="1289",
        target_boss_name="Starburst",
        configured_limits={
            "target_completed_matches": 3,
            "max_technical_recoveries": 1,
            "max_match_attempts": 5,
        },
        run_started_at=now,
        match_attempts=0,
        completed_matches=0,
        wins=0,
        losses=0,
        unknown_results=0,
        technical_aborts=0,
        technical_recoveries=0,
        technical_exits=0,
        last_completed_match_id=None,
        seen_match_ids=(),
        action_aggregates={
            "swap_sent": 0,
            "swap_acknowledged": 0,
            "swap_rejected": 0,
            "swap_aborted_state_changed": 0,
            "cast_sent": 0,
            "cast_accepted": 0,
            "cast_rejected": 0,
            "evolve_attempts": 0,
            "evolve_success": 0,
            "evolve_failed": 0,
        },
        pass_totals=0,
        consistency_aggregates={
            "consistent": 0,
            "memory_incomplete": 0,
            "conflicts": 0,
            "strong_terminal_results": 0,
        },
        last_safe_lifecycle="BOSS_LOBBY",
        stop_request_state="RUNNING",
        stop_reason=None,
        finalized_status=None,
    )


class DesktopConfigTests(unittest.TestCase):
    def test_supported_canonical_values_validate(self) -> None:
        config = DesktopConfig(
            PlayStyle.CAREFUL,
            ManaPriority.ATTACK,
            Intelligence.BASIC,
            "1289",
            "Starburst",
            25,
            3,
            32,
        )
        self.assertEqual(config.normalized_boss_id, "1289")
        self.assertEqual(config.target_completed_matches, 25)

    def test_reasoning_is_rejected(self) -> None:
        with self.assertRaisesRegex(ValueError, "REASONING"):
            DesktopConfig(intelligence=Intelligence.REASONING)

    def test_target_and_finite_limits_reuse_canonical_validation(self) -> None:
        unbound = DesktopConfig(boss_id=" ", boss_name="")
        self.assertIsNone(unbound.normalized_boss_id)
        self.assertIsNone(unbound.normalized_boss_name)
        with self.assertRaisesRegex(ValueError, "cannot exceed"):
            DesktopConfig(target_completed_matches=6, max_match_attempts=5)
        with self.assertRaisesRegex(ValueError, "positive"):
            DesktopConfig(target_completed_matches=0)

    def test_string_mapping_has_no_ui_only_values(self) -> None:
        config = DesktopConfig.from_strings(
            play_style="simple",
            mana_priority="evolution",
            intelligence="basic",
            boss_id="1289",
            boss_name="Starburst",
            target_completed_matches="3",
            max_technical_recoveries="1",
            max_match_attempts="5",
        )
        self.assertIs(config.play_style, PlayStyle.SIMPLE)
        with self.assertRaises(ValueError):
            DesktopConfig.from_strings(
                play_style="invented",
                mana_priority="evolution",
                intelligence="basic",
                boss_id="1289",
                boss_name="Starburst",
                target_completed_matches="3",
                max_technical_recoveries="1",
                max_match_attempts="5",
            )


class ControlPlaneSnapshotTests(unittest.TestCase):
    def test_attached_lobby_maps_to_immutable_read_only_snapshot(self) -> None:
        runtime = _Runtime(
            [
                RuntimeObservation(
                    True,
                    True,
                    99,
                    "x64",
                    "BOSS_LOBBY",
                    target_id="1289",
                    target_name="Starburst",
                    provider_reason="clean",
                )
            ]
        )
        plane = DesktopControlPlane(runtime)
        snapshot = plane.refresh()
        self.assertEqual(snapshot.health, "OK")
        self.assertFalse(snapshot.stale)
        self.assertTrue(snapshot.read_only)
        self.assertEqual(snapshot.runtime.lifecycle, "BOSS_LOBBY")
        self.assertEqual(snapshot.safety.nonzero(), {})

    def test_detached_process_is_neutral_and_non_actionable(self) -> None:
        plane = DesktopControlPlane(
            _Runtime([RuntimeObservation(False, False, lifecycle="UNAVAILABLE")])
        )
        snapshot = plane.refresh()
        self.assertEqual(snapshot.health, "DETACHED")
        self.assertFalse(snapshot.runtime.attached)
        self.assertEqual(snapshot.safety.gameplay_windows_inputs, 0)

    def test_provider_exception_preserves_display_but_marks_stale_detached(self) -> None:
        runtime = _Runtime(
            [
                RuntimeObservation(
                    True, True, 42, "x64", "ACTIVE_COMBAT", match_id="M_one"
                ),
                RuntimeError("temporary read failure"),
            ]
        )
        plane = DesktopControlPlane(runtime)
        first = plane.refresh()
        second = plane.refresh()
        self.assertEqual(first.runtime.lifecycle, "ACTIVE_COMBAT")
        self.assertEqual(second.runtime.lifecycle, "ACTIVE_COMBAT")
        self.assertFalse(second.runtime.attached)
        self.assertTrue(second.stale)
        self.assertEqual(second.health, "ERROR")
        self.assertIn("temporary read failure", second.last_error or "")

    def test_draft_update_only_changes_config_without_dispatch(self) -> None:
        runtime = _Runtime([RuntimeObservation(False, False)])
        plane = DesktopControlPlane(runtime)
        config = DesktopConfig(play_style=PlayStyle.CAREFUL)
        updated = plane.update_config(config)
        self.assertIs(updated.config.play_style, PlayStyle.CAREFUL)
        self.assertEqual(runtime.reads, 0)
        self.assertTrue(hasattr(plane, "start_farm"))
        self.assertTrue(hasattr(plane, "request_graceful_stop"))
        self.assertTrue(hasattr(plane, "restore_game_foreground"))
        self.assertTrue(hasattr(plane, "emergency_stop"))
        self.assertTrue(hasattr(plane, "resume_from_checkpoint"))
        self.assertEqual(updated.safety.nonzero(), {})

    def test_close_is_idempotent(self) -> None:
        runtime = _Runtime([RuntimeObservation(False, False)])
        plane = DesktopControlPlane(runtime)
        plane.close()
        plane.close()
        self.assertEqual(runtime.closes, 1)


class CheckpointSummaryTests(unittest.TestCase):
    def test_latest_valid_checkpoint_is_read_only_summary(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary)
            path = root / "run" / "checkpoint.json"
            write_checkpoint(path, _checkpoint_payload())
            provider = LatestCheckpointSummaryProvider(root)
            summary = provider.read_latest()
            self.assertTrue(summary.available)
            self.assertTrue(summary.resumable_candidate)
            self.assertEqual(summary.farm_run_id, "ui-summary-run")
            self.assertEqual(summary.target_completed_matches, 3)
            self.assertEqual(path.read_text(encoding="utf-8").count("farm_run_id"), 1)

    def test_malformed_latest_checkpoint_fails_closed(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            path = Path(temporary) / "run" / "checkpoint.json"
            path.parent.mkdir()
            path.write_text("{broken", encoding="utf-8")
            summary = LatestCheckpointSummaryProvider(Path(temporary)).read_latest()
            self.assertFalse(summary.available)
            self.assertFalse(summary.resumable_candidate)
            self.assertIn("CHECKPOINT_INVALID", summary.error or "")

    def test_completed_checkpoint_is_not_a_resume_candidate(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary)
            path = root / "run" / "checkpoint.json"
            payload = _checkpoint_payload()
            payload = replace(
                payload,
                match_attempts=3,
                completed_matches=3,
                wins=3,
                last_completed_match_id="match-3",
                seen_match_ids=("match-1", "match-2", "match-3"),
                finalized_status="COMPLETED",
            )
            write_checkpoint(path, payload)
            summary = LatestCheckpointSummaryProvider(root).read_latest()
            self.assertTrue(summary.available)
            self.assertFalse(summary.resumable_candidate)

    def test_emergency_checkpoint_is_not_a_resume_candidate(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary)
            path = root / "run" / "checkpoint.json"
            payload = replace(
                _checkpoint_payload(),
                last_safe_lifecycle="ACTIVE_COMBAT",
                stop_request_state="EMERGENCY_STOPPED",
                stop_reason="F9_EMERGENCY_STOP",
                finalized_status="EMERGENCY_STOPPED",
            )
            write_checkpoint(path, payload)
            summary = LatestCheckpointSummaryProvider(root).read_latest()
            self.assertTrue(summary.available)
            self.assertFalse(summary.resumable_candidate)

    def test_graceful_lobby_checkpoint_is_a_resume_candidate(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary)
            path = root / "run" / "checkpoint.json"
            payload = replace(
                _checkpoint_payload(),
                stop_request_state="STOPPED_AT_LOBBY",
                stop_reason="STOPPED_GRACEFULLY",
                finalized_status="STOPPED_GRACEFULLY",
            )
            write_checkpoint(path, payload)
            summary = LatestCheckpointSummaryProvider(root).read_latest()
            self.assertTrue(summary.resumable_candidate)

    def test_legacy_recovery_cap_safe_stop_is_a_resume_candidate_hint(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary)
            path = root / "run" / "checkpoint.json"
            payload = replace(
                _checkpoint_payload(),
                match_attempts=1,
                seen_match_ids=("match-stuck",),
                stop_request_state="RUNNING",
                stop_reason="COMBAT_SAFE_STOP",
                finalized_status="SAFE_STOP",
            )
            write_checkpoint(path, payload)
            summary = LatestCheckpointSummaryProvider(root).read_latest()
            self.assertTrue(summary.resumable_candidate)


class SnapshotPollerTests(unittest.TestCase):
    def test_exactly_one_worker_and_clean_stop(self) -> None:
        runtime = _Runtime([RuntimeObservation(False, False, lifecycle="UNAVAILABLE")])
        plane = DesktopControlPlane(runtime)
        poller = SnapshotPoller(plane, interval_seconds=0.25)
        self.assertTrue(poller.start())
        self.assertFalse(poller.start())
        deadline = time.monotonic() + 2.0
        while runtime.reads == 0 and time.monotonic() < deadline:
            time.sleep(0.01)
        self.assertGreaterEqual(runtime.reads, 1)
        self.assertTrue(poller.stop(timeout_seconds=2.0))
        self.assertFalse(poller.alive)
        self.assertEqual(poller.starts, 1)
        plane.close()

    def test_slow_read_does_not_block_snapshot_consumer_thread(self) -> None:
        runtime = _BlockingRuntime()
        plane = DesktopControlPlane(runtime)
        poller = SnapshotPoller(plane, interval_seconds=0.25)
        poller.start()
        self.assertTrue(runtime.entered.wait(1.0))
        started = time.monotonic()
        snapshot = plane.snapshot()
        elapsed = time.monotonic() - started
        self.assertLess(elapsed, 0.05)
        self.assertEqual(snapshot.health, "INITIALIZING")
        runtime.release.set()
        self.assertTrue(poller.stop(timeout_seconds=2.0))
        plane.close()

    def test_poll_exceptions_do_not_kill_worker(self) -> None:
        runtime = _Runtime(
            [RuntimeError("first"), RuntimeObservation(False, False, lifecycle="UNAVAILABLE")]
        )
        plane = DesktopControlPlane(runtime)
        poller = SnapshotPoller(plane, interval_seconds=0.25)
        poller.start()
        deadline = time.monotonic() + 2.0
        while runtime.reads < 2 and time.monotonic() < deadline:
            time.sleep(0.02)
        self.assertGreaterEqual(runtime.reads, 2)
        self.assertTrue(poller.alive)
        self.assertTrue(poller.stop(timeout_seconds=2.0))
        plane.close()


if __name__ == "__main__":
    unittest.main()
