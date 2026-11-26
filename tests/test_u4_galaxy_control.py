"""U4c: Galaxy/G4 BASIC swap-timing control protocol and common-core routing per play style."""
from dataclasses import replace
from pathlib import Path
from types import SimpleNamespace
import json
import tempfile
import unittest

from pokiguard_v2.reasoning_calibration import COMMON_GALAXY_CONTROL_PROTOCOL, check_config
from pokiguard_v2.reasoning_ui_session import _common_profile_for_style
from tests.reasoning_test_paths import reasoning_temp_root
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore


class GalaxyControlTests(unittest.TestCase):
    def control(self, **changes):
        # A real saved Mega session config, switched to the G4 passive route (Galaxy, no evolution).
        src = Path(__file__).resolve().parents[1] / 'docs/phase5/artifacts/mega_restart_timing_20261124_165628/preferences.json'
        data = json.loads(src.read_text(encoding='utf-8-sig'))
        data['config'].update(play_style='galaxy_shadow_sword', main_pet='galaxy', evolution='none',
                              damage_card='pet_passive', pet_skill_fire_condition='auto_combo', pet_skill_fire_value=None)
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as d:
            path = Path(d) / 'preferences.json'
            path.write_text(json.dumps(data), encoding='utf-8')
            loaded = DesktopPreferenceStore(path).load()
        self.assertFalse(loaded.warnings)
        return replace(loaded.config, boss_id='2321', boss_name='No. 11', **changes)

    def test_one_attempt_basic_g4_control_is_accepted(self):
        check_config(self.control(), 1, profile_protocol=COMMON_GALAXY_CONTROL_PROTOCOL)

    def test_two_attempts_are_rejected(self):
        with self.assertRaises(ValueError):
            check_config(self.control(target_completed_matches=2, max_match_attempts=2), 2,
                         profile_protocol=COMMON_GALAXY_CONTROL_PROTOCOL)

    def test_routing_needs_a_profile_for_the_exact_style(self):
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as d:
            paths = SimpleNamespace(data_root=Path(d))
            self.assertFalse(_common_profile_for_style(paths, 'galaxy_shadow_sword'))
            profile = Path(d) / 'preferences/reasoning_acceptance/common.json'
            profile.parent.mkdir(parents=True)
            profile.write_text(json.dumps(dict(play_style='mega_icarus_spam_skill')), encoding='utf-8')
            self.assertFalse(_common_profile_for_style(paths, 'galaxy_shadow_sword'))
            profile.write_text(json.dumps(dict(play_style='galaxy_shadow_sword')), encoding='utf-8')
            self.assertTrue(_common_profile_for_style(paths, 'galaxy_shadow_sword'))


if __name__ == '__main__':
    unittest.main()
