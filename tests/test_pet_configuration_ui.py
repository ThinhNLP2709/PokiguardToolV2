"""Real Tk widget/command tests with an offline runtime and no input backend."""
from __future__ import annotations

from dataclasses import asdict, replace
import json
from pathlib import Path
import tempfile
import time
import tkinter as tk
import unittest

from pokiguard_v2.boss_entry import FarmTarget
from pokiguard_v2.desktop_control_plane import (
    DesktopConfig, DesktopControlPlane, LatestCheckpointSummaryProvider,
    SnapshotPoller,
)
from pokiguard_v2.desktop_farm_controller import DesktopFarmControllerManager
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
from pokiguard_v2.desktop_ui import DesktopApplication, DesktopEventLog, DesktopViewModel, PREFERENCE_TABLE_ROWS
from pokiguard_v2.farm_checkpoint import LEGACY_CHECKPOINT_SCHEMA, write_checkpoint
from pokiguard_v2.farm_run import FarmRun
from pokiguard_v2.pet_configuration import (
    DamageCardMode, EvolutionTarget, GameplayConfig, MainPetType,
)
from tests.test_desktop_farm_controller import _BlockingRunner, _Runtime


class PetConfigurationTkTests(unittest.TestCase):
    def setUp(self):
        self.tmp = tempfile.TemporaryDirectory()
        self.directory = Path(self.tmp.name)
        self.root = tk.Tk()
        self.root.withdraw()
        self.runner = _BlockingRunner()
        reset = self.directory / "reset.json"
        reset.write_text("{}")
        self.manager = DesktopFarmControllerManager(self.directory, runner=self.runner, reset_evidence=reset)
        self.plane = DesktopControlPlane(
            _Runtime(), controller=self.manager,
            checkpoint=LatestCheckpointSummaryProvider(self.directory),
        )
        self.plane.refresh()
        self.poller = SnapshotPoller(self.plane, interval_seconds=0.25)
        self.vm = DesktopViewModel(self.plane, self.poller, stale_after_seconds=3)
        self.store = DesktopPreferenceStore(self.directory / "preferences.json")
        self.app = DesktopApplication(self.root, self.vm,
            event_log=DesktopEventLog(self.directory / "events.jsonl"),
            preference_store=self.store, game_location="fixture.exe")
        self.app._render()
        self.root.update_idletasks()

    def tearDown(self):
        self.runner.release.set()
        self.manager.wait(2)
        self.poller.stop(timeout_seconds=2)
        self.plane.close()
        if not self.app._closed:
            for callback in self.root.tk.call("after", "info"):
                self.root.after_cancel(callback)
            self.root.destroy()
        self.app.event_log.close()
        self.tmp.cleanup()

    def button(self, name, value):
        return self.app._pet_option_widgets[name, value]

    def test_canonical_fields_defaults_and_disabled_choices_visible(self):
        self.assertNotIn("ManaPriority", PREFERENCE_TABLE_ROWS)
        for label in ("Pet của tôi", "Tiến hóa", "Thẻ sát thương", "Audition"):
            self.assertIn(label, PREFERENCE_TABLE_ROWS)
        self.assertEqual((self.app.main_pet.get(), self.app.evolution.get(), self.app.damage_card.get()),
                         ("normal", "normal", "default_attack"))
        for name in ("main_pet", "evolution"):
            for value in ("evolved", "mega"):
                button = self.button(name, value)
                self.assertEqual(button.winfo_manager(), "pack")
                self.assertTrue(button.instate(["disabled"]))
                button.invoke()
                self.assertEqual(getattr(self.app, name).get(), "normal")

    def test_pet_skill_updates_and_invalid_selection_normalizes(self):
        skill = self.button("damage_card", "pet_skill")
        self.assertTrue(skill.instate(["disabled"]))
        self.button("main_pet", "legendary").invoke()
        self.assertFalse(skill.instate(["disabled"]))
        skill.invoke()
        self.assertEqual(self.app.damage_card.get(), "pet_skill")
        self.button("main_pet", "normal").invoke()
        self.assertTrue(skill.instate(["disabled"]))
        self.assertEqual(self.app.damage_card.get(), "default_attack")
        self.assertEqual(self.plane.snapshot().config.damage_card, DamageCardMode.DEFAULT_ATTACK)

    def test_evolution_only_skill_and_multiple_source_notice(self):
        self.button("evolution", "legendary").invoke()
        skill = self.button("damage_card", "pet_skill")
        self.assertFalse(skill.instate(["disabled"]))
        skill.invoke()
        self.assertEqual(self.plane.snapshot().config.capability.skill_source_count, 1)
        self.button("main_pet", "legendary").invoke()
        self.assertEqual(self.plane.snapshot().config.capability.skill_source_count, 2)
        self.assertIn("nhiều nguồn", self.app.profile_notice_var.get())

    def test_exact_pet_skill_profile_enables_start(self):
        self.button("main_pet", "legendary").invoke()
        self.button("evolution", "none").invoke()
        self.button("damage_card", "pet_skill").invoke()
        self.app._render()
        self.assertFalse(self.app.start_button.instate(["disabled"]))
        self.assertIn("tương thích", self.app.profile_notice_var.get())
        self.assertEqual(self.manager.snapshot().safety.starts, 0)
        self.assertEqual(self.runner.starts, 0)
        self.assertEqual(self.plane.snapshot().safety.nonzero(), {})

    def test_desktop_start_freezes_exact_pet_skill_profile(self):
        self.button("main_pet", "legendary").invoke()
        self.button("evolution", "none").invoke()
        self.button("damage_card", "pet_skill").invoke()
        self.app._start_farm()

        self.assertTrue(self.runner.entered.wait(1))
        self.assertEqual(self.runner.starts, 1)
        launch = self.runner.launches[0].config
        self.assertEqual(launch.main_pet, MainPetType.LEGENDARY)
        self.assertEqual(launch.evolution, EvolutionTarget.NONE)
        self.assertEqual(launch.damage_card, DamageCardMode.PET_SKILL)
        self.assertEqual(launch.audition_mode.value, "audition_v3")
        self.assertFalse(self.plane.start_farm().accepted)
        self.assertEqual(self.runner.starts, 1)

        self.app.main_pet.set("normal")
        self.app.damage_card.set("default_attack")
        self.app._render()
        self.assertEqual(self.app.main_pet.get(), "legendary")
        self.assertEqual(self.app.damage_card.get(), "pet_skill")
        self.assertEqual(self.runner.launches[0].config, launch)
        self.assertEqual(
            self.manager.snapshot().safety.max_simultaneous_controllers, 1
        )

    def test_future_save_roundtrip_has_no_start_or_resume(self):
        self.button("main_pet", "legendary").invoke()
        self.button("evolution", "none").invoke()
        self.button("damage_card", "pet_skill").invoke()
        self.app.validate_button.invoke()
        restored = self.store.load()
        self.assertTrue(restored.loaded)
        self.assertEqual(restored.config.main_pet, MainPetType.LEGENDARY)
        self.assertEqual(restored.config.evolution, EvolutionTarget.NONE)
        self.assertEqual(restored.config.damage_card, DamageCardMode.PET_SKILL)
        self.assertEqual(self.runner.starts, 0)
        self.assertEqual(self.app.resume_commands_submitted, 0)

    def test_explicit_load_displays_pet_skill_checkpoint_without_auto_resume(self):
        pet_skill = GameplayConfig(
            main_pet=MainPetType.LEGENDARY,
            evolution=EvolutionTarget.NONE,
            damage_card=DamageCardMode.PET_SKILL,
        )
        path = self.directory / "future" / "checkpoint.json"
        write_checkpoint(
            path,
            replace(
                FarmRun(FarmTarget("1289", "Starburst")).checkpoint_payload(),
                gameplay_config=pet_skill,
            ),
        )
        self.plane.refresh()
        self.app.load_checkpoint_preferences_button.invoke()
        self.assertEqual(
            (self.app.main_pet.get(), self.app.evolution.get(), self.app.damage_card.get()),
            ("legendary", "none", "pet_skill"),
        )
        self.assertEqual(self.app.resume_commands_submitted, 0)
        self.assertEqual(self.runner.starts, 0)
        self.app._render()
        self.assertFalse(self.app.start_button.instate(["disabled"]))

    def test_explicit_load_displays_legacy_attack_checkpoint_as_new_fields(self):
        path = self.directory / "legacy" / "checkpoint.json"
        payload = asdict(FarmRun(FarmTarget("1289", "Starburst")).checkpoint_payload())
        payload["schema_version"] = LEGACY_CHECKPOINT_SCHEMA
        payload["gameplay_config"] = {"mana_priority": "attack"}
        path.parent.mkdir()
        path.write_text(json.dumps(payload), encoding="utf-8")
        self.plane.refresh()
        self.app.load_checkpoint_preferences_button.invoke()
        self.assertEqual(
            (self.app.main_pet.get(), self.app.evolution.get(), self.app.damage_card.get()),
            ("normal", "none", "default_attack"),
        )
        self.assertEqual(self.app.resume_commands_submitted, 0)

    def test_settings_lock_until_controller_stops_and_keep_disabled_options(self):
        self.app._start_farm()
        self.assertTrue(self.runner.entered.wait(1))
        for widget in self.app._pet_option_widgets.values():
            self.assertTrue(widget.instate(["disabled"]))
        launch_config = self.runner.launches[0].config
        self.app.main_pet.set("legendary")
        self.assertEqual(self.app.main_pet.get(), "normal")
        self.assertEqual(self.runner.launches[0].config, launch_config)
        with self.assertRaisesRegex(RuntimeError, "CONFIG_LOCKED"):
            self.plane.update_config(replace(launch_config, evolution=EvolutionTarget.NONE))
        self.runner.release.set()
        self.assertTrue(self.manager.wait(2))
        self.plane.refresh()
        self.app._render()
        self.assertFalse(self.button("main_pet", "legendary").instate(["disabled"]))
        self.assertTrue(self.button("main_pet", "mega").instate(["disabled"]))
        self.assertTrue(self.button("damage_card", "pet_skill").instate(["disabled"]))

    def test_preference_labels_fit_normal_width(self):
        self.root.deiconify()
        self.app.notebook.select(1)
        self.root.update_idletasks()
        for button in self.app._pet_option_widgets.values():
            self.assertLessEqual(button.winfo_rootx() + button.winfo_reqwidth(),
                                 self.root.winfo_rootx() + self.root.winfo_width())
        self.root.withdraw()

    def test_single_poller_and_clean_close(self):
        self.assertTrue(self.poller.start())
        self.assertFalse(self.poller.start())
        self.app.close()
        deadline = time.monotonic() + 3
        while not self.app._closed and time.monotonic() < deadline:
            self.root.update()
            time.sleep(0.01)
        self.assertTrue(self.app._closed)
        self.assertFalse(self.poller.alive)
        self.assertFalse(self.manager.snapshot().active)
        self.assertEqual(self.app.handled_ui_errors, 0)


if __name__ == "__main__":
    unittest.main()
