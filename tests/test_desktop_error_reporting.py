from __future__ import annotations

from dataclasses import replace
import json
from pathlib import Path
import tempfile
import time
import unittest
from unittest.mock import Mock

from pokiguard_v2.desktop_control_plane import (
    CheckpointSummary,
    CommandAvailability,
    ControlAvailability,
    ControlPlaneSnapshot,
    DesktopConfig,
    RuntimeObservation,
    UiSafetyEvidence,
)
from pokiguard_v2.desktop_farm_controller import (
    DesktopControllerSnapshot,
    DesktopControllerState,
)
from pokiguard_v2.desktop_ui import DesktopEventLog, DesktopViewModel
from tools.desktop_ui import _EvidenceSink


def failed_snapshot(error: str | None) -> ControlPlaneSnapshot:
    return ControlPlaneSnapshot(
        version=1,
        timestamp="2026-09-17T08:37:18.358Z",
        sampled_monotonic=time.monotonic(),
        config=DesktopConfig(),
        runtime=RuntimeObservation(True, True, 123, "x64", "BOSS_LOBBY"),
        checkpoint=CheckpointSummary(False),
        stale=False,
        health="OK",
        last_error=None,
        refresh_attempts=1,
        refresh_successes=1,
        refresh_errors=0,
        read_only=True,
        safety=UiSafetyEvidence(),
        controller=DesktopControllerSnapshot(
            generation=1,
            state=DesktopControllerState.ERROR,
            last_error=error,
        ),
        controls=ControlAvailability(
            start=CommandAvailability(True, "READY"),
        ),
    )


class DesktopErrorReportingTests(unittest.TestCase):
    def test_start_failure_is_visible_even_when_runtime_and_start_are_ready(self) -> None:
        error = "RuntimeError: GAME_WINDOW_PREPARATION_FAILED: PID 123"
        snapshot = failed_snapshot(error)
        plane = Mock()
        plane.snapshot.return_value = snapshot
        view = DesktopViewModel(plane, Mock(), stale_after_seconds=6.0)
        presentation = view.presentation()
        self.assertEqual(error, presentation.error)
        self.assertEqual("LỖI BỘ ĐIỀU KHIỂN", presentation.operator_status)
        self.assertIn(error, presentation.operator_guidance)
        self.assertTrue(presentation.snapshot_actionable)

        with tempfile.TemporaryDirectory() as directory:
            path = Path(directory) / "events.jsonl"
            log = DesktopEventLog(path)
            try:
                sink = _EvidenceSink(log)
                sink("snapshot_refreshed", snapshot)
                self.assertIn(error, log.entries()[0].message)
                self.assertEqual(1, sink.summary()["errorRefreshes"])
            finally:
                log.close()
            record = json.loads(path.read_text(encoding="utf-8"))
            self.assertEqual(error, record["controller"]["last_error"])

    def test_changed_error_is_visible_but_unchanged_polls_do_not_flood_log(self) -> None:
        snapshot = failed_snapshot(None)
        error = "FileNotFoundError: missing runtime resource"
        with tempfile.TemporaryDirectory() as directory:
            log = DesktopEventLog(Path(directory) / "events.jsonl")
            try:
                log.poll_event("snapshot_refreshed", snapshot)
                snapshot = replace(
                    snapshot, controller=replace(snapshot.controller, last_error=error)
                )
                log.poll_event("snapshot_refreshed", snapshot)
                log.poll_event("snapshot_refreshed", snapshot)
                self.assertEqual(2, len(log.entries()))
                self.assertIn(error, log.entries()[-1].message)
                self.assertEqual(3, log.stats()["totalJsonlEntries"])
            finally:
                log.close()

    def test_long_error_keeps_cause_in_bounded_display_and_full_jsonl(self) -> None:
        error = "FileNotFoundError: resource not found: " + "x" * 600
        with tempfile.TemporaryDirectory() as directory:
            path = Path(directory) / "events.jsonl"
            log = DesktopEventLog(path)
            try:
                log.poll_event("snapshot_refreshed", failed_snapshot(error))
                message = log.entries()[0].message
                self.assertIn("FileNotFoundError: resource not found", message)
                self.assertLessEqual(len(message), 400)
            finally:
                log.close()
            record = json.loads(path.read_text(encoding="utf-8"))
            self.assertEqual(error, record["controller"]["last_error"])

    def test_new_start_clears_failure_guidance_and_runtime_errors_still_show(self) -> None:
        plane = Mock()
        view = DesktopViewModel(plane, Mock(), stale_after_seconds=6.0)
        snapshot = failed_snapshot("old failure")
        plane.snapshot.return_value = replace(
            snapshot,
            controller=DesktopControllerSnapshot(
                generation=2, state=DesktopControllerState.STARTING, active=True
            ),
        )
        self.assertEqual("KHÔNG CÓ", view.presentation().error)
        self.assertEqual("ĐANG CHẠY", view.presentation().operator_status)
        plane.snapshot.return_value = replace(
            snapshot,
            controller=DesktopControllerSnapshot(),
            stale=True,
            last_error="RuntimeError: process detached",
        )
        self.assertEqual("RuntimeError: process detached", view.presentation().error)
        self.assertEqual("DỮ LIỆU TRẠNG THÁI ĐÃ CŨ", view.presentation().operator_status)


if __name__ == "__main__":
    unittest.main()
