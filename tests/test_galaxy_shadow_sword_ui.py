"""Offline Tk settings and immutable accepted G4 intent; no game/poller IO."""
from pathlib import Path
import tempfile
import tkinter as tk
import unittest

from pokiguard_v2.basic_policy import PlayStyle
from pokiguard_v2.desktop_control_plane import DesktopControlPlane,StaticUnavailableRuntimeProvider
from pokiguard_v2.desktop_ui import DesktopApplication,DesktopEventLog,DesktopViewModel,SnapshotPoller
from pokiguard_v2.pet_configuration import PLAY_STYLE_LABELS,PET_SKILL_FIRE_CONDITION_LABELS
from pokiguard_v2.gameplay_profile import PetSkillFireCondition
from tests.reasoning_test_paths import reasoning_temp_root


class G4UITests(unittest.TestCase):
    def setUp(self):
        self.temp=tempfile.TemporaryDirectory(dir=reasoning_temp_root())
        self.root=tk.Tk();self.root.withdraw()
        self.plane=DesktopControlPlane(StaticUnavailableRuntimeProvider())
        self.poller=SnapshotPoller(self.plane)
        self.vm=DesktopViewModel(self.plane,self.poller,stale_after_seconds=3)
        self.log=DesktopEventLog(Path(self.temp.name)/'ui.jsonl')
        self.app=DesktopApplication(self.root,self.vm,event_log=self.log)
        self.root.update_idletasks()

    def tearDown(self):
        self.poller.stop();self.log.close()
        for token in self.root.tk.call('after','info'):
            self.root.after_cancel(token)
        self.root.destroy();self.temp.cleanup()

    def test_select_style_normalizes_loadout_hides_target_and_never_exposes_active_skill(self):
        self.app.play_style.set(PLAY_STYLE_LABELS[PlayStyle.GALAXY_SHADOW_SWORD])
        self.root.update_idletasks()
        cfg=self.plane.snapshot().config
        self.assertEqual('galaxy',cfg.main_pet.value);self.assertEqual('none',cfg.evolution.value)
        self.assertEqual('pet_passive',cfg.damage_card.value);self.assertEqual('none',cfg.audition_mode.value)
        self.assertIsNone(cfg.pet_skill_fire_value)
        self.assertEqual((PET_SKILL_FIRE_CONDITION_LABELS[PetSkillFireCondition.AUTO_COMBO],),
            tuple(self.app.pet_skill_fire_condition_widget['values']))
        self.assertTrue(self.app.pet_skill_fire_value_widget.instate(['disabled']))
        self.assertEqual('',self.app.pet_skill_fire_label.winfo_manager())
        self.assertEqual('',self.app.pet_skill_fire_cell.winfo_manager())
        self.assertEqual('',self.app.demon_target_gem_widget.winfo_manager())
        self.assertEqual('',self.app.audition_widget.winfo_manager())
        self.assertEqual('',self.app.mega_self_protection_widget.winfo_manager())
        for (kind,value),widget in self.app._pet_option_widgets.items():
            if kind=='main_pet':
                self.assertEqual(value not in ('normal','galaxy'),widget.instate(['disabled']))
            if kind=='evolution':
                self.assertEqual(value not in ('none','normal'),widget.instate(['disabled']))
            if kind=='damage_card' and value!='pet_passive':
                self.assertTrue(widget.instate(['disabled']))
        self.assertEqual(0,self.poller.starts)

    def test_g4_both_evolution_routes_keep_passive_implicit_and_restore_other_style_fields(self):
        self.app.play_style.set(PLAY_STYLE_LABELS[PlayStyle.GALAXY_SHADOW_SWORD])
        self.app.main_pet.set('normal');self.root.update_idletasks()
        cfg=self.plane.snapshot().config
        self.assertEqual(('normal','galaxy'),(cfg.main_pet.value,cfg.evolution.value))
        self.assertEqual('pet_passive',cfg.damage_card.value);cfg.require_farm_policy()
        self.app.main_pet.set('galaxy');self.app.evolution.set('normal');self.root.update_idletasks()
        cfg=self.plane.snapshot().config
        self.assertEqual(('galaxy','normal'),(cfg.main_pet.value,cfg.evolution.value))
        self.assertEqual('',self.app.pet_skill_fire_cell.winfo_manager());cfg.require_farm_policy()
        self.app.play_style.set(PLAY_STYLE_LABELS[PlayStyle.DEMON_AEGIS_FARM]);self.root.update_idletasks()
        self.assertEqual('grid',self.app.pet_skill_fire_cell.winfo_manager())
        self.assertEqual('grid',self.app.pet_skill_fire_label.winfo_manager())

    def test_reasoning_is_selected_in_options_and_switching_styles_restores_their_contract(self):
        self.app.play_style.set(PLAY_STYLE_LABELS[PlayStyle.GALAXY_SHADOW_SWORD])
        self.app.intelligence.set('Suy luận');self.app._intelligence_selected();self.app._validate_draft()
        self.assertTrue(self.plane.snapshot().config.ai.reasoning_enabled)
        for style in (PlayStyle.DEMON_AEGIS_FARM,PlayStyle.GALAXY,PlayStyle.SIMPLE,PlayStyle.GALAXY_SHADOW_SWORD):
            self.app.play_style.set(PLAY_STYLE_LABELS[PlayStyle.GALAXY_SHADOW_SWORD])
            self.app.play_style.set(PLAY_STYLE_LABELS[style]);self.root.update_idletasks()
            cfg=self.plane.snapshot().config
            self.assertIs(style,cfg.play_style);cfg.gameplay_config.require_farm_policy()
            if style is not PlayStyle.GALAXY_SHADOW_SWORD:
                self.assertNotIn(PET_SKILL_FIRE_CONDITION_LABELS[PetSkillFireCondition.AUTO_COMBO],
                    tuple(self.app.pet_skill_fire_condition_widget['values']))


if __name__=='__main__':unittest.main()
