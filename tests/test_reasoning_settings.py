from __future__ import annotations

from dataclasses import FrozenInstanceError, replace
import io
import json
from pathlib import Path
import subprocess
import sys
import tempfile
import threading
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.basic_policy import Intelligence, PlayStyle
from pokiguard_v2.desktop_control_plane import (
    DesktopConfig, DesktopControlPlane, SnapshotPoller, StaticUnavailableRuntimeProvider,
)
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore, PREFERENCE_SCHEMA
from pokiguard_v2.desktop_farm_controller import (
    ControllerLaunch, DesktopFarmControllerManager, DesktopControllerSnapshot,
    DesktopControllerState,
)
from pokiguard_v2.desktop_ui import (
    DesktopApplication, DesktopEventLog, DesktopViewModel, ai_status_text,
    ai_capability_text, DESKTOP_TAB_TITLES,
)
from pokiguard_v2.input_delivery import InputDeliveryMode
from pokiguard_v2.pet_configuration import EvolutionTarget, DamageCardMode
from pokiguard_v2.reasoning_settings import (
    AISettings, AIStatus, FrozenAIIntent, RunShadowSession, prepare_shadow_safely,
)
from pokiguard_v2.reasoning_shadow import ShadowAdapter, attach_shadow_log
from pokiguard_v2.win32_input import FarmControlHotkeyEdges
from tests import reasoning_worker_fixtures as fault
from tests.test_reasoning_shadow import MemorySink, publication
from tests.test_reasoning_runner import wait_for
from tests.test_desktop_farm_controller import _checkpoint


class AISettingsTests(unittest.TestCase):
    def test_defaults_and_strict_bounded_budget(self):
        self.assertEqual(AISettings(), AISettings.from_dict(None))
        self.assertFalse(DesktopConfig().ai.shadow_enabled)
        for cap in (50, 4000, 6000):
            self.assertEqual(cap, AISettings.from_strings("true", str(cap)).budget_ms)
        for value in (49, 6001, -1, 0, True, 4000.0, "4000", None):
            with self.subTest(value=value), self.assertRaises(ValueError):
                AISettings(budget_ms=value)
        for value in ("", "4s", "４０００", "4000.0", "-1", " 4000"):
            with self.subTest(value=value), self.assertRaises(ValueError):
                AISettings.from_strings("true", value)
        for value in (1, "true", None):
            with self.subTest(value=value), self.assertRaises(ValueError):
                AISettings(shadow_enabled=value)
        with self.assertRaises(ValueError):
            AISettings.from_dict({"schema": "future"})

    def test_old_v2_preferences_add_defaults_without_changing_gameplay(self):
        with tempfile.TemporaryDirectory() as temp:
            store = DesktopPreferenceStore(Path(temp) / "prefs.json")
            config = DesktopConfig(play_style=PlayStyle.CAREFUL, evolution=EvolutionTarget.NONE,
                                   pet_skill_fire_value=17, rage_target=140,
                                   input_delivery_mode=InputDeliveryMode.PINNED_FOREGROUND_LEASE_BETA)
            store.save(config)
            raw = json.loads(store.path.read_text())
            raw["schema"] = "pokiguard.desktop_preferences.v2"
            raw["config"].pop("ai")
            store.path.write_text(json.dumps(raw))
            loaded = store.load(defaults=replace(config, ai=AISettings(True, 6000)))
            self.assertTrue(loaded.loaded)
            self.assertEqual(config.gameplay_config, loaded.config.gameplay_config)
            self.assertEqual(config.input_delivery_mode, loaded.config.input_delivery_mode)
            self.assertEqual(AISettings(), loaded.config.ai)
            self.assertEqual((), loaded.warnings)
            self.assertEqual("pokiguard.desktop_preferences.v2", json.loads(store.path.read_text())["schema"])
            store.save(loaded.config)
            self.assertEqual(PREFERENCE_SCHEMA, json.loads(store.path.read_text())["schema"])

    def test_v3_ai_roundtrip_and_no_gameplay_checkpoint_schema_change(self):
        with tempfile.TemporaryDirectory() as temp:
            config = DesktopConfig(ai=AISettings(True, 6000), boss_id="1289", boss_name="Starburst")
            store = DesktopPreferenceStore(Path(temp) / "prefs.json")
            store.save(config)
            loaded = store.load()
            self.assertTrue(loaded.loaded)
            self.assertEqual(config.ai, loaded.config.ai)
            self.assertIs(loaded.config.intelligence, Intelligence.BASIC)
            self.assertNotIn("ai", config.gameplay_config.to_dict())
            path = Path(temp) / "checkpoint.json"
            _checkpoint(path, config)
            self.assertNotIn('"ai"', path.read_text())
            manager = DesktopFarmControllerManager(Path(temp), runner=lambda *_: 0)
            manager._validate_launch(ControllerLaunch(config, path))

    def test_invalid_ai_only_degrades_ai_preserving_old_profile(self):
        with tempfile.TemporaryDirectory() as temp:
            store = DesktopPreferenceStore(Path(temp) / "prefs.json")
            config = DesktopConfig(play_style=PlayStyle.CAREFUL, pet_skill_fire_value=17)
            store.save(config)
            raw = json.loads(store.path.read_text())
            for ai in ({"shadow_enabled": "true"}, {"budget_ms": 6001}, {"budget_ms": True},
                       {"schema": "future"}, [], "invalid"):
                raw["config"]["ai"] = ai
                store.path.write_text(json.dumps(raw))
                loaded = store.load()
                self.assertTrue(loaded.loaded)
                self.assertEqual(config.gameplay_config, loaded.config.gameplay_config)
                self.assertEqual(AISettings(), loaded.config.ai)
                self.assertEqual("PREFERENCE_AI_INVALID", loaded.warnings[0].reason)

    def test_frozen_intent_detached_versioned_and_tactical_settings_preserved(self):
        config = DesktopConfig(ai=AISettings(True, 4000), pet_skill_fire_value=4)
        intent = FrozenAIIntent.freeze(config)
        with self.assertRaises(FrozenInstanceError):
            config.ai.budget_ms = 6000
        with self.assertRaises(FrozenInstanceError):
            intent.config_id = "new"
        parsed = json.loads(intent.config_json)
        parsed["config"]["pet_skill_fire_value"] = 3
        self.assertEqual(4, json.loads(intent.config_json)["config"]["pet_skill_fire_value"])
        self.assertEqual(intent.config_id, FrozenAIIntent.freeze(config).config_id)
        self.assertNotEqual(intent.config_id, FrozenAIIntent.freeze(replace(config, pet_skill_fire_value=3)).config_id)
        self.assertNotEqual(intent.config_id, FrozenAIIntent.freeze(replace(config, ai=AISettings(True, 6000))).config_id)

    def test_selection_remains_rejected_even_with_opt_in_shadow(self):
        with self.assertRaisesRegex(ValueError, "REASONING is not implemented"):
            DesktopConfig(intelligence=Intelligence.REASONING, ai=AISettings(True))

    def test_disabled_production_path_has_no_shadow_import_thread_or_session(self):
        program = '''
import sys, threading, tempfile
from pathlib import Path
from unittest.mock import patch
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.desktop_farm_controller import DesktopFarmControllerManager, ControllerLaunch
from pokiguard_v2.win32_input import FarmControlHotkeyEdges
with tempfile.TemporaryDirectory() as temp:
    manager = DesktopFarmControllerManager(Path(temp), runner=lambda *_: 0)
    before = set(threading.enumerate())
    with patch("tools.farm_run.run", return_value=7) as run:
        assert manager._run_production(ControllerLaunch(DesktopConfig(boss_id="1289"), None), FarmControlHotkeyEdges(), lambda *_: None) == 7
        assert "shadow_session" not in run.call_args.kwargs
    assert set(threading.enumerate()) == before
    for module in ("reasoning_shadow", "reasoning_runner", "reasoning_diagnostics", "reasoning_planner"):
        assert "pokiguard_v2." + module not in sys.modules, module
'''
        result = subprocess.run([sys.executable, "-c", program], capture_output=True, text=True)
        self.assertEqual(0, result.returncode, result.stderr)


class RunShadowSettingsTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory()
        self.addCleanup(self.temp.cleanup)
        self.directory = Path(self.temp.name)
        self.events = []
        self.config = DesktopConfig(ai=AISettings(True), boss_id="1289")

    def session(self, config=None, factory=None, observer=None):
        return RunShadowSession(config or self.config, directory=self.directory,
                                observer=observer or (lambda value, phase: self.events.append((value, phase))),
                                factory=factory)

    def test_new_combat_reuses_frozen_config_and_rejects_old_status(self):
        factory = Mock(side_effect=[Mock(), Mock()])
        session = self.session(factory=factory)
        first = session.prepare()
        callback = factory.call_args.kwargs["status_callback"]
        first_config_id = factory.call_args.kwargs["config_version"]
        self.assertEqual(4000, factory.call_args.kwargs["budget_ms"])
        session.prepare()
        first.stop.assert_called_once()
        self.assertEqual(first_config_id, factory.call_args.kwargs["config_version"])
        before = len(self.events)
        self.assertFalse(callback(dict(state="DEGRADED", reason="OLD")))
        self.assertEqual(before, len(self.events))
        session.stop()
        self.assertIsNone(session.prepare())

    def test_coop_unsupported_creates_no_worker_but_baseline_loadout_valid(self):
        from pokiguard_v2.gameplay_profile import GameMode, AuditionMode
        config = replace(self.config, play_style=PlayStyle.BU_WIN, game_mode=GameMode.COOP,
                         evolution=EvolutionTarget.NONE, damage_card=DamageCardMode.NONE,
                         audition_mode=AuditionMode.NO_ACTION)
        config.gameplay_config.require_farm_policy()
        factory = Mock()
        self.assertIsNone(self.session(config, factory).prepare())
        factory.assert_not_called()
        self.assertEqual("COOP_SHADOW_NOT_ACCEPTED", self.events[-1][0].reason)

    def test_factory_failure_and_unavailable_are_isolated(self):
        for factory in (Mock(return_value=None), Mock(side_effect=OSError("denied"))):
            self.assertIsNone(self.session(factory=factory).prepare())
            self.assertEqual("DEGRADED", self.events[-1][0].state)
        self.assertIsNone(prepare_shadow_safely(Mock(prepare=Mock(side_effect=RuntimeError()))))

    def test_observer_and_stop_faults_are_isolated(self):
        adapter = Mock(stop=Mock(side_effect=RuntimeError("stop failure")))
        session = self.session(factory=Mock(return_value=adapter), observer=Mock(side_effect=OSError()))
        self.assertIs(adapter, session.prepare())
        session.stop()
        self.assertTrue(session.stopped)

    def test_adapter_status_is_off_admission_and_carries_config_version(self):
        config, _, _, _, raw = publication()
        adapter = ShadowAdapter(diagnostics=MemorySink(), compute=fault.retain,
                                config_version="a" * 64,
                                status_callback=lambda value: self.events.append((value, threading.current_thread().name)))
        self.addCleanup(lambda: self.assertTrue(adapter.close()))
        attach_shadow_log(io.StringIO(), adapter, config).write(raw)
        wait_for(lambda: adapter.counts["prepared"] == 1)
        job = next(iter(adapter.roots.values()))
        self.assertEqual("a" * 64, job.snapshot.intent.versions.plain()["run_config_sha256"])
        wait_for(lambda: bool(self.events))
        self.assertTrue(all(name == "reasoning-shadow" for _, name in self.events))
        self.assertTrue(all(value["accounting_valid"] is False for value, _ in self.events))

    def test_missing_evidence_and_dropped_diagnostics_are_visible(self):
        config, _, _, _, raw = publication()
        sink = MemorySink(fail=True)
        adapter = ShadowAdapter(diagnostics=sink, compute=fault.retain,
                                status_callback=lambda value: self.events.append(value))
        self.addCleanup(lambda: self.assertTrue(adapter.close()))
        row = json.loads(raw)
        row["selectedAction"] = "pet_skill"
        attach_shadow_log(io.StringIO(), adapter, config).write(json.dumps(row, separators=(",", ":")))
        wait_for(lambda: any(e["state"] == "DEGRADED" and e["dropped"] > 0 for e in self.events))
        self.assertGreater(self.events[-1]["unsupported"], 0)
        self.assertEqual("SINK_OSError", self.events[-1]["reason"])

    def test_blocked_status_listener_does_not_block_basic_write_or_stop(self):
        entered, release = threading.Event(), threading.Event()
        def listener(_):
            entered.set()
            release.wait(5)
        adapter = ShadowAdapter(diagnostics=MemorySink(), compute=fault.retain,
                                status_callback=listener)
        self.addCleanup(lambda: self.assertTrue(adapter.close()))
        self.addCleanup(release.set)
        self.assertTrue(entered.wait(2))
        config, _, _, _, raw = publication()
        common = io.StringIO()
        log = attach_shadow_log(common, adapter, config)
        done = threading.Event()
        writer = threading.Thread(target=lambda: (log.write(raw), log.flush(), adapter.stop(), done.set()))
        writer.start()
        self.assertTrue(done.wait(.5), "BASIC/Stop waited for status callback")
        writer.join()
        self.assertEqual(raw, common.getvalue())

    def test_callback_exception_only_disables_status_reporting(self):
        adapter = ShadowAdapter(diagnostics=MemorySink(), compute=fault.retain,
                                status_callback=Mock(side_effect=RuntimeError("display")))
        self.addCleanup(lambda: self.assertTrue(adapter.close()))
        wait_for(lambda: adapter.status_callback is None)
        self.assertFalse(adapter.stopped.is_set())
        config, _, _, _, raw = publication()
        attach_shadow_log(io.StringIO(), adapter, config).write(raw)
        wait_for(lambda: adapter.counts["prepared"] == 1)

    def test_production_adapter_freezes_config_then_signal_only_teardown(self):
        manager = DesktopFarmControllerManager(self.directory, runner=lambda *_: 0)
        session = None
        def farm(args, **kwargs):
            nonlocal session
            session = kwargs["shadow_session"]
            self.assertEqual(self.config.ai, session.intent.settings)
            self.assertEqual(self.directory / "logs/farm_runs/reasoning", session.directory)
            self.assertFalse(session.stopped)
            self.assertFalse(hasattr(args, "shadow_session"))
            return 7
        with patch("tools.farm_run.run", side_effect=farm):
            result = manager._run_production(ControllerLaunch(self.config, None),
                                             FarmControlHotkeyEdges(), lambda *_: None)
        self.assertEqual(7, result)
        self.assertTrue(session.stopped)

    def test_start_freezes_ai_until_controller_stops_and_old_status_cannot_revive(self):
        entered, release = threading.Event(), threading.Event()
        seen = []
        def runner(launch, edges, observer):
            seen.append(launch.config)
            entered.set()
            release.wait(5)
            return 0
        evidence = self.directory / "reset.json"
        evidence.write_text("{}")
        manager = DesktopFarmControllerManager(self.directory, runner=runner, reset_evidence=evidence)
        self.addCleanup(lambda: manager.wait(2))
        self.addCleanup(release.set)
        result = manager.start(self.config)
        self.assertTrue(result.accepted)
        self.assertTrue(entered.wait(2))
        plane = DesktopControlPlane(StaticUnavailableRuntimeProvider(), config=self.config, controller=manager)
        changed = replace(self.config, ai=AISettings(False, 6000))
        with self.assertRaisesRegex(RuntimeError, "CONFIG_LOCKED"):
            plane.update_config(changed)
        self.assertEqual(AISettings(True, 4000), seen[0].ai)
        self.assertTrue(manager.emergency_stop(result.generation).accepted)
        self.assertTrue(manager.snapshot().active)
        release.set()
        self.assertTrue(manager.wait(2))
        self.assertEqual("STOPPED", manager.snapshot().ai_status.state)
        self.assertFalse(manager._observe(result.generation, AIStatus("SHADOW"), "AI_STATUS"))
        plane.update_config(changed)
        self.assertEqual(changed.ai, plane.snapshot().config.ai)

    def test_resume_uses_fresh_ai_intent_without_changing_checkpoint_validation(self):
        evidence = self.directory / "reset.json"
        evidence.write_text("{}")
        checkpoint = self.directory / "checkpoint.json"
        _checkpoint(checkpoint, self.config)
        changed = replace(self.config, ai=AISettings(True, 6000))
        seen = []
        manager = DesktopFarmControllerManager(self.directory, runner=lambda launch, *_: seen.append(launch) or 0,
                                               reset_evidence=evidence)
        result = manager.resume(changed, checkpoint)
        self.assertTrue(result.accepted)
        self.assertTrue(manager.wait(2))
        self.assertEqual(changed.ai, seen[0].config.ai)
        self.assertEqual(checkpoint, seen[0].checkpoint_path)
        self.assertEqual("STOPPED", manager.snapshot().ai_status.state)

    def test_farm_optional_forwarding_does_not_add_baseline_argument(self):
        from tools import farm_run
        args = farm_run.build_parser().parse_args([
            "--stage-e2-ui", "--boss-id", "1289", "--new-run"])
        sentinel = object()
        with patch.object(farm_run, "_validate_args"), patch.object(farm_run, "_run_live", return_value=9) as run:
            self.assertEqual(9, farm_run.run(args))
            self.assertNotIn("shadow_session", run.call_args.kwargs)
            self.assertEqual(9, farm_run.run(args, shadow_session=sentinel))
            self.assertIs(sentinel, run.call_args.kwargs["shadow_session"])

    def test_setup_config_error_falls_back_to_unmodified_farm_call(self):
        manager = DesktopFarmControllerManager(self.directory, runner=lambda *_: 0)
        with patch("pokiguard_v2.reasoning_settings.RunShadowSession", side_effect=ValueError()), \
             patch("tools.farm_run.run", return_value=3) as farm:
            self.assertEqual(3, manager._run_production(ControllerLaunch(self.config, None),
                                                       FarmControlHotkeyEdges(), lambda *_: None))
        self.assertNotIn("shadow_session", farm.call_args.kwargs)

    def test_owned_native_logger_config_correlation_and_status_follow_existing_publication(self):
        session = self.session()
        adapter = session.prepare()
        self.assertIsNotNone(adapter)
        self.addCleanup(lambda: self.assertTrue(adapter.close()))
        config, _, _, _, raw = publication()
        common = io.StringIO()
        attach_shadow_log(common, adapter, config).write(raw)
        wait_for(lambda: adapter.runner.counters["completed"] == 1)
        wait_for(lambda: any(s.written > 0 for s, _ in self.events))
        self.assertEqual(raw, common.getvalue())
        self.assertTrue(all(s.config_id == session.intent.config_id for s, _ in self.events))
        adapter.sink.buffer.disable("OFFLINE_INJECTED_DISK_FAULT")
        wait_for(lambda: any(s.state == "DEGRADED" and s.reason == "OFFLINE_INJECTED_DISK_FAULT"
                            for s, _ in self.events))
        session.stop()
        self.assertTrue(adapter.close())
        rows = [json.loads(line) for path in self.directory.glob("reasoning.*.jsonl")
                for line in path.read_text(encoding="utf-8").splitlines()]
        self.assertTrue(rows)
        self.assertIn(session.intent.config_id, json.dumps(rows))
        self.assertTrue(all(row["input_authority"] is False for row in rows))

    def test_manager_filters_generation_old_combat_and_late_after_stop(self):
        manager = DesktopFarmControllerManager(self.directory, runner=lambda *_: 0)
        manager._snapshot = DesktopControllerSnapshot(generation=3, active=True)
        current = AIStatus("SHADOW", "RUNTIME_MODEL_NOT_BOUND", "x", 2)
        self.assertTrue(manager._observe(3, current, "AI_STATUS"))
        for generation, value in ((2, current), (3, replace(current, observation=1)),
                                  (3, replace(current, selection_authority=True))):
            self.assertFalse(manager._observe(generation, value, "AI_STATUS"))
        self.assertEqual(current, manager.snapshot().ai_status)
        manager._snapshot = replace(manager.snapshot(), active=False)
        self.assertFalse(manager._observe(3, current, "AI_STATUS"))

    def test_status_lock_busy_returns_without_waiting(self):
        manager = DesktopFarmControllerManager(self.directory, runner=lambda *_: 0)
        ready, release, done = threading.Event(), threading.Event(), threading.Event()
        def hold():
            with manager._lock:
                ready.set()
                release.wait(3)
        thread = threading.Thread(target=hold)
        thread.start()
        self.addCleanup(thread.join)
        self.addCleanup(release.set)
        self.assertTrue(ready.wait(1))
        self.assertFalse(manager._observe(1, AIStatus(), "AI_STATUS"))


class OfflineAIUiTests(unittest.TestCase):
    def setUp(self):
        import tkinter as tk
        self.temp = tempfile.TemporaryDirectory()
        self.addCleanup(self.temp.cleanup)
        self.root = tk.Tk()
        self.root.withdraw()
        self.addCleanup(self.root.destroy)
        self.plane = DesktopControlPlane(StaticUnavailableRuntimeProvider())
        self.poller = SnapshotPoller(self.plane)
        self.vm = DesktopViewModel(self.plane, self.poller, stale_after_seconds=3)
        self.log = DesktopEventLog(Path(self.temp.name) / "ui.jsonl")
        self.addCleanup(self.log.close)
        self.app = DesktopApplication(self.root, self.vm, event_log=self.log)
        self.root.update_idletasks()  # Drain this interpreter's own ThemeChanged/focus idle callbacks.

    def test_actual_tab_gate_defaults_save_and_no_poller_started(self):
        self.assertEqual(DESKTOP_TAB_TITLES, tuple(self.app.notebook.tab(t, "text") for t in self.app.notebook.tabs()))
        self.assertIn("disabled", self.app.ai_reasoning_widget.state())
        self.assertFalse(self.app.ai_shadow_enabled.get())
        self.assertEqual("4000", self.app.ai_budget_ms.get())
        self.assertEqual(0, self.poller.starts)
        self.app.ai_shadow_enabled.set(True)
        self.app.ai_budget_ms.set("6000")
        self.app._save_ai_settings()
        self.assertEqual(AISettings(True, 6000), self.plane.snapshot().config.ai)
        self.assertEqual(0, self.poller.starts)

    def test_actual_ui_invalid_budget_preserves_config(self):
        self.app.ai_shadow_enabled.set(True)
        self.app.ai_budget_ms.set("6001")
        self.app._save_ai_settings()
        self.assertEqual(AISettings(), self.plane.snapshot().config.ai)
        self.assertIn("Chưa lưu", self.app.ai_feedback_var.get())

    def test_ai_save_does_not_apply_window_size_or_modify_gameplay_draft(self):
        before = self.plane.snapshot().config.gameplay_config
        self.app.game_window_size_changed = Mock(side_effect=AssertionError("no window operation"))
        self.app.ai_shadow_enabled.set(True)
        self.app.ai_budget_ms.set("4000")
        self.app._save_ai_settings()
        self.app.game_window_size_changed.assert_not_called()
        self.assertEqual(before, self.plane.snapshot().config.gameplay_config)

    def test_ai_page_fits_default_height(self):
        self.root.update_idletasks()
        page = self.root.nametowidget(self.app.notebook.tabs()[2])
        self.assertLessEqual(page.winfo_reqheight(), 780)

    def test_actual_ui_active_config_lock_and_reenable_after_stop(self):
        config = replace(self.plane.snapshot().config, ai=AISettings(True, 6000))
        self.app._lock_accepted_run_config(config)
        self.assertIn("disabled", self.app.ai_shadow_widget.state())
        self.assertIn("disabled", self.app.ai_budget_widget.state())
        self.assertIn("disabled", self.app.ai_save_widget.state())
        self.assertEqual("6000", self.app.ai_budget_ms.get())
        self.app._set_config_editable(True)
        self.assertNotIn("disabled", self.app.ai_shadow_widget.state())
        self.assertIn("disabled", self.app.ai_reasoning_widget.state())

    def test_cached_status_stop_degraded_and_unsupported_text(self):
        status = AIStatus("DEGRADED", "DISK_FULL", written=2, dropped=3)
        self.assertIn("đã ghi 2; bỏ 3", ai_status_text(status))
        self.assertIn("Quyền chọn nước: Cơ bản", ai_status_text(status))
        self.assertIn("ĐÃ DỪNG", ai_status_text(replace(status, state="STOPPED")))
        self.assertIn("không tạo worker", ai_capability_text(PlayStyle.BU_WIN))
        self.assertNotIn("xác suất", ai_status_text(status))


if __name__ == "__main__":
    unittest.main()
