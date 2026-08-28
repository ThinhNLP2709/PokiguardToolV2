from __future__ import annotations

from dataclasses import replace
from pathlib import Path
from types import SimpleNamespace
import tempfile
import time
import unittest
from unittest.mock import Mock

from pokiguard_v2.desktop_control_plane import (
    CheckpointSummary,
    ControlPlaneSnapshot,
    DesktopConfig,
    RuntimeObservation,
    UiSafetyEvidence,
)
from pokiguard_v2.desktop_farm_controller import (
    ControllerCommandResult,
    DesktopControllerSnapshot,
    DesktopControllerState,
)
from pokiguard_v2.desktop_ui import (
    APP_BUILD,
    APP_TITLE,
    APP_VERSION,
    CloseChoice,
    CloseIntent,
    CloseTransition,
    DesktopCloseCoordinator,
    DesktopApplication,
    DesktopEventLog,
    DesktopShutdownWorker,
    DESKTOP_TAB_TITLES,
    INITIAL_FOCUS_TARGET,
    PREFERENCE_TABLE_ROWS,
    VISIBLE_RUNTIME_ROWS,
    background_click_clears_entry_focus,
    run_limit_text,
    visible_runtime_values,
)


def _snapshot(
    *,
    controller: DesktopControllerSnapshot,
    lifecycle: str = "ACTIVE_COMBAT",
    stale: bool = False,
    health: str = "OK",
) -> ControlPlaneSnapshot:
    return ControlPlaneSnapshot(
        version=1,
        timestamp="2026-08-22T00:00:00.000Z",
        sampled_monotonic=time.monotonic(),
        config=DesktopConfig(),
        runtime=RuntimeObservation(
            True,
            True,
            pid=123,
            architecture="x64",
            lifecycle=lifecycle,
        ),
        checkpoint=CheckpointSummary(False),
        stale=stale,
        health=health,
        last_error=None,
        refresh_attempts=1,
        refresh_successes=1,
        refresh_errors=0,
        read_only=True,
        safety=UiSafetyEvidence(),
        controller=controller,
    )


class _CloseViewModel:
    def __init__(self) -> None:
        self.graceful: list[int] = []
        self.emergency: list[int] = []

    @staticmethod
    def _result(generation: int, reason: str) -> ControllerCommandResult:
        return ControllerCommandResult(
            True,
            reason,
            DesktopControllerState.RUNNING,
            generation,
            "2026-08-22T00:00:00.000Z",
            "run-test",
        )

    def request_graceful_stop(self, generation: int) -> ControllerCommandResult:
        self.graceful.append(generation)
        return self._result(generation, "GRACEFUL_STOP_ACCEPTED")

    def emergency_stop(self, generation: int) -> ControllerCommandResult:
        self.emergency.append(generation)
        return self._result(generation, "EMERGENCY_STOP_ACKNOWLEDGED")


class DesktopCloseCoordinatorTests(unittest.TestCase):
    def setUp(self) -> None:
        self.vm = _CloseViewModel()
        self.coordinator = DesktopCloseCoordinator(self.vm)
        self.active = DesktopControllerSnapshot(
            generation=7,
            state=DesktopControllerState.RUNNING,
            active=True,
            farm_run_id="run-test",
        )

    def test_active_cancel_sends_no_stop_and_keeps_no_close_intent(self) -> None:
        result = self.coordinator.request(
            CloseChoice.CANCEL, _snapshot(controller=self.active)
        )
        self.assertTrue(result.accepted)
        self.assertEqual([], self.vm.graceful)
        self.assertEqual([], self.vm.emergency)
        self.assertEqual(CloseIntent.NONE, self.coordinator.intent)

    def test_graceful_close_is_exactly_once_and_waits_for_fresh_boss_lobby(self) -> None:
        source = _snapshot(controller=self.active)
        first = self.coordinator.request(CloseChoice.GRACEFUL, source)
        second = self.coordinator.request(CloseChoice.GRACEFUL, source)
        self.assertTrue(first.accepted)
        self.assertTrue(second.accepted)
        self.assertEqual([7], self.vm.graceful)
        self.assertEqual(
            CloseTransition.WAITING,
            self.coordinator.observe(source).transition,
        )
        stopped = replace(
            self.active,
            active=False,
            state=DesktopControllerState.STOPPED,
        )
        stale_lobby = _snapshot(controller=stopped, lifecycle="BOSS_LOBBY", stale=True)
        self.assertEqual(
            CloseTransition.WAITING,
            self.coordinator.observe(stale_lobby).transition,
        )
        fresh_lobby = _snapshot(controller=stopped, lifecycle="BOSS_LOBBY")
        self.assertEqual(
            CloseTransition.READY,
            self.coordinator.observe(fresh_lobby).transition,
        )

    def test_emergency_close_does_not_require_boss_lobby(self) -> None:
        source = _snapshot(controller=self.active)
        self.coordinator.request(CloseChoice.EMERGENCY, source)
        self.assertEqual([7], self.vm.emergency)
        stopped = replace(
            self.active,
            active=False,
            state=DesktopControllerState.STOPPED,
            emergency_stop_acknowledged_at="now",
        )
        combat = _snapshot(controller=stopped, lifecycle="ACTIVE_COMBAT")
        self.assertEqual(
            CloseTransition.READY,
            self.coordinator.observe(combat).transition,
        )

    def test_emergency_escalates_pending_graceful_close(self) -> None:
        source = _snapshot(controller=self.active)
        self.coordinator.request(CloseChoice.GRACEFUL, source)
        self.coordinator.request(CloseChoice.EMERGENCY, source)
        self.assertEqual([7], self.vm.graceful)
        self.assertEqual([7], self.vm.emergency)
        self.assertEqual(
            CloseIntent.AFTER_EMERGENCY_STOP, self.coordinator.intent
        )

    def test_stale_close_intent_cannot_close_new_generation(self) -> None:
        source = _snapshot(controller=self.active)
        self.coordinator.request(CloseChoice.GRACEFUL, source)
        newer = replace(self.active, generation=8, farm_run_id="new-run")
        observation = self.coordinator.observe(_snapshot(controller=newer))
        self.assertEqual(CloseTransition.STALE, observation.transition)
        self.assertEqual(CloseIntent.NONE, self.coordinator.intent)
        self.assertEqual([7], self.vm.graceful)


class DesktopShutdownWorkerTests(unittest.TestCase):
    def test_idle_shutdown_stops_poller_and_closes_plane_off_caller_thread(self) -> None:
        calls: list[tuple[str, str]] = []

        class _Poller:
            def stop(self, *, timeout_seconds: float) -> bool:
                calls.append(("poller", __import__("threading").current_thread().name))
                return timeout_seconds == 30.0

        class _Plane:
            def close(self) -> None:
                calls.append(("plane", __import__("threading").current_thread().name))

        worker = DesktopShutdownWorker(
            SimpleNamespace(poller=_Poller(), control_plane=_Plane())
        )
        self.assertTrue(worker.start())
        self.assertFalse(worker.start())
        deadline = time.monotonic() + 2.0
        while worker.result is None and time.monotonic() < deadline:
            time.sleep(0.01)
        self.assertIsNotNone(worker.result)
        assert worker.result is not None
        self.assertTrue(worker.result.poller_stopped)
        self.assertTrue(worker.result.control_plane_closed)
        self.assertEqual(["poller", "plane"], [name for name, _ in calls])
        self.assertTrue(all(thread == "PokiguardDesktopShutdown" for _, thread in calls))


class BoundedOperatorLogTests(unittest.TestCase):
    def test_ring_and_display_snapshot_never_exceed_exact_500_entry_bound(self) -> None:
        with tempfile.TemporaryDirectory() as directory:
            log = DesktopEventLog(Path(directory) / "events.jsonl")
            for index in range(1_337):
                log.write("synthetic_operator_event", reason=str(index))
            entries = log.entries()
            stats = log.stats()
            self.assertEqual(500, len(entries))
            self.assertEqual(500, stats["configuredBound"])
            self.assertEqual(500, stats["maxObservedEntries"])
            self.assertEqual(1_337, stats["totalEntries"])
            self.assertEqual("837", entries[0].message.split("=", 1)[1])
            self.assertEqual("1336", entries[-1].message.split("=", 1)[1])
            log.close()


class CompactPresentationContractTests(unittest.TestCase):
    def test_pre_mvp_title_uses_incrementing_build_suffix(self) -> None:
        self.assertEqual(13, APP_BUILD)
        self.assertEqual("v1.0.0+13", APP_VERSION)
        self.assertEqual("Pokiguard Tool V2 - v1.0.0+13", APP_TITLE)

    def test_control_preferences_and_diagnostics_tab_order(self) -> None:
        self.assertEqual(
            ("Control", "Preferences", "Diagnostics / Log"),
            DESKTOP_TAB_TITLES,
        )
        self.assertEqual(
            ("PlayStyle", "Intelligence", "ManaPriority"),
            PREFERENCE_TABLE_ROWS,
        )
        self.assertEqual("notebook", INITIAL_FOCUS_TARGET)

    def test_blank_surface_clears_focus_but_controls_keep_their_click(self) -> None:
        for widget_class in ("Tk", "TFrame", "TLabelframe", "TLabel"):
            self.assertTrue(background_click_clears_entry_focus(widget_class))
        for widget_class in ("TEntry", "TCombobox", "TButton", "Text", "TNotebook"):
            self.assertFalse(background_click_clears_entry_focus(widget_class))

    def test_run_limit_text_uses_validated_canonical_values(self) -> None:
        config = DesktopConfig(target_completed_matches=25, max_match_attempts=32)
        self.assertEqual(("25", "32"), run_limit_text(config))

    def test_accepted_run_immediately_locks_normalized_limits(self) -> None:
        app = SimpleNamespace(
            _locked_run_limits=None,
            target_matches=Mock(),
            max_attempts=Mock(),
            _set_config_editable=Mock(),
            start_button=Mock(),
            resume_button=Mock(),
            notebook=Mock(),
            event_log=Mock(),
        )
        config = DesktopConfig(target_completed_matches=25, max_match_attempts=32)
        DesktopApplication._lock_accepted_run_config(app, config)
        self.assertEqual(("25", "32"), app._locked_run_limits)
        app.target_matches.set.assert_called_once_with("25")
        app.max_attempts.set.assert_called_once_with("32")
        app._set_config_editable.assert_called_once_with(False)
        app.start_button.configure.assert_called_once_with(state="disabled")
        app.resume_button.configure.assert_called_once_with(state="disabled")
        app.notebook.focus_set.assert_called_once_with()

    def test_control_tab_hides_low_value_runtime_identity_rows(self) -> None:
        self.assertEqual(
            (
                ("Game", "connection"),
                ("Lifecycle", "lifecycle"),
                ("Runtime target", "runtime_target"),
            ),
            VISIBLE_RUNTIME_ROWS,
        )
        visible_keys = {key for _, key in VISIBLE_RUNTIME_ROWS}
        self.assertTrue(
            {"attachment", "process", "session", "match_id"}.isdisjoint(visible_keys)
        )

    def test_compact_runtime_render_never_reads_hidden_widget_keys(self) -> None:
        presentation = SimpleNamespace(
            connection="DETECTED",
            lifecycle="BOSS_LOBBY",
            runtime_target="Starburst",
        )
        self.assertEqual(
            (
                ("connection", "DETECTED"),
                ("lifecycle", "BOSS_LOBBY"),
                ("runtime_target", "Starburst"),
            ),
            visible_runtime_values(presentation),
        )


if __name__ == "__main__":
    unittest.main()
