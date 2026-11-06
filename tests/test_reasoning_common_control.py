"""Common target BASIC control draft, no game API or live authorization."""
from dataclasses import replace
from pathlib import Path
import tempfile,unittest
from unittest.mock import patch
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
from pokiguard_v2.reasoning_calibration import check_config,COMMON_DEMON_CONTROL_PROTOCOL,D3_CONTROL_PROTOCOL
from pokiguard_v2.reasoning_common_models import DEMON_TARGETS,DEMON_DECLARATION
from pokiguard_v2.reasoning_settings import AISettings
from pokiguard_v2.gameplay_profile import DemonTargetGem
from tools.prepare_common_control import prepare,activate
from tests.test_reasoning_d3_control import config
from tools.qualify_common_reasoning import calibration_projection


class CommonControlTests(unittest.TestCase):
    def test_five_targets_have_a_separate_basic_only_protocol(self):
        for target in DEMON_TARGETS:
            c=replace(config(),demon_target_gem=DemonTargetGem(target))
            check_config(c,3,profile_protocol=COMMON_DEMON_CONTROL_PROTOCOL)
            if target!='shield':
                with self.assertRaises(ValueError):check_config(c,3,profile_protocol=D3_CONTROL_PROTOCOL)
        self.assertTrue(calibration_projection())

    def test_shadow_reasoning_config_and_cap_drift_rejected(self):
        c=config()
        for changed in (replace(c,ai=AISettings(False,4000,True)),replace(c,ai=AISettings(True)),
                replace(c,target_completed_matches=1),replace(c,pet_skill_fire_value=1)):
            with self.assertRaises(ValueError):check_config(changed,3,profile_protocol=COMMON_DEMON_CONTROL_PROTOCOL)
        for cap in (0,True,4,5):
            with self.assertRaises(ValueError):check_config(c,cap,profile_protocol=COMMON_DEMON_CONTROL_PROTOCOL)

    def test_health_draft_is_inert_and_does_not_touch_saved_preferences(self):
        with tempfile.TemporaryDirectory() as directory:
            root=Path(directory);prefs=root/'preferences.json';DesktopPreferenceStore(prefs).save(DesktopConfig())
            before=prefs.read_bytes()
            with patch('tools.prepare_common_control.ROOT',root):
                draft=prepare(prefs,root/'draft.json',target='health',pet_label='Demon Sagui',
                    boss_id='1436',boss_name='Lieyun LV77')
                self.assertEqual('health',draft['config']['demon_target_gem'])
                self.assertEqual('Demon Sagui',draft['operator_pet_label'])
                self.assertEqual(DEMON_DECLARATION.plain(),draft['declaration'])
                self.assertEqual((3,3,6),(draft['planned_basic_attempts'],draft['planned_reasoning_attempts'],draft['total_case_cap']))
                self.assertFalse(draft['accepted']);self.assertFalse(draft['input_authority'])
                self.assertFalse(draft['claim_created']);self.assertFalse(draft['automatic_start'])
                self.assertEqual(before,prefs.read_bytes())
                with patch('tools.prepare_common_control.build_request') as builder:
                    with self.assertRaises(ValueError):activate(root/'draft.json',root/'request.json',game='FAKE.exe',authorization='')
                    builder.assert_not_called()
                with self.assertRaises(ValueError):prepare(prefs,root/'draft.json',target='health',pet_label='Demon Sagui',
                    boss_id='1436',boss_name='Lieyun LV77')


if __name__=='__main__':unittest.main()
