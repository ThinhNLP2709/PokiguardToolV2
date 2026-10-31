"""D2 observation setup only. Native/process/input/worker surfaces are fakes."""
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

from pokiguard_v2.basic_policy import Intelligence, PlayStyle
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.gameplay_profile import DamageCardMode, EvolutionTarget, MainPetType
from pokiguard_v2.reasoning_calibration import (
    BasicCalibrationActivation, D2_CONTROL_PROTOCOL, SCHEMA, check_config,
)
from pokiguard_v2.reasoning_settings import AISettings
from pokiguard_v2.reasoning_snapshot import canonical_json


def control_config():
    return DesktopConfig(play_style=PlayStyle.SKILL_RUSH,
        main_pet=MainPetType.LEGENDARY, evolution=EvolutionTarget.NONE,
        damage_card=DamageCardMode.PET_SKILL, boss_id='1289', boss_name='Starburst',
        target_completed_matches=3, max_match_attempts=3)


class D2ControlTests(unittest.TestCase):
    def test_explicit_marker_opens_only_basic_observation(self):
        config = control_config()
        with self.assertRaises(ValueError):
            check_config(config, 3)
        check_config(config, 3, profile_protocol=D2_CONTROL_PROTOCOL)
        with self.assertRaises(ValueError):
            check_config(config, 3, profile_protocol='UNKNOWN')

    def test_invalid_loadout_mode_cap_and_ai_cannot_get_control_authority(self):
        base = control_config()
        cases = [dict(main_pet=MainPetType.NORMAL), dict(evolution=EvolutionTarget.NORMAL),
            dict(damage_card=DamageCardMode.DEFAULT_ATTACK), dict(boss_id=None),
            dict(play_style=PlayStyle.SIMPLE), dict(intelligence=Intelligence.REASONING),
            dict(ai=AISettings(True)), dict(max_match_attempts=4),
            dict(target_completed_matches=2),
            dict(input_delivery_mode=type(base.input_delivery_mode)('pinned_foreground_lease_beta'))]
        for changes in cases:
            with self.subTest(changes=changes), self.assertRaises(ValueError):
                check_config(replace(base, **changes), 3, profile_protocol=D2_CONTROL_PROTOCOL)
        for cap in (True, 1, 2, 4, 5):
            with self.subTest(cap=cap), self.assertRaises(ValueError):
                check_config(base, cap, profile_protocol=D2_CONTROL_PROTOCOL)

    def test_legacy_simple_careful_scope_is_unchanged(self):
        for profile in (PlayStyle.SIMPLE, PlayStyle.CAREFUL):
            base = DesktopConfig(play_style=profile, main_pet=MainPetType.NORMAL,
                evolution=EvolutionTarget.NORMAL, damage_card=DamageCardMode.DEFAULT_ATTACK,
                boss_id='1289', target_completed_matches=3, max_match_attempts=3)
            check_config(base, 3)
            with self.assertRaises(ValueError):
                check_config(base, 3, profile_protocol=D2_CONTROL_PROTOCOL)

    def test_start_claim_is_one_shot_and_never_supplies_selection_adapter(self):
        config = control_config()
        with tempfile.TemporaryDirectory() as tmp:
            root = Path(tmp); exe = root / 'game.exe'; exe.write_bytes(b'FAKE')
            path = root / 'request.json'
            request = dict(schema=SCHEMA, reasoning_enabled=False, run_id='d'*32,
                created_at=1000, expires_at=8200, config=jsonable(config),
                total_attempt_cap=3, profile_protocol=D2_CONTROL_PROTOCOL,
                host_sha256='h', source_sha256='s', game_executable=str(exe),
                game_executable_sha256='e', game_build_sha256='b')
            path.write_text(canonical_json(request), encoding='utf-8')
            digest = hashlib.sha256(path.read_bytes()).hexdigest()
            with patch('pokiguard_v2.reasoning_calibration.time.time', return_value=1001), \
                 patch('pokiguard_v2.reasoning_calibration.host_fingerprint', return_value='h'), \
                 patch('pokiguard_v2.reasoning_calibration.source_fingerprint', return_value='s'), \
                 patch('pokiguard_v2.reasoning_calibration.validate_supported_game_assembly', return_value='b'), \
                 patch('pokiguard_v2.reasoning_calibration.game_assembly_sha256', return_value='e'), \
                 patch('pokiguard_v2.reasoning_calibration.SwapTimingSession') as session:
                create = lambda: BasicCalibrationActivation(path, digest, root=root,
                    directory=root/'timing', game_executable=lambda: exe)
                activation = create()
                self.assertFalse(activation.claim_path.exists())
                self.assertIsNone(activation.session)
                with self.assertRaises(ValueError): activation(config)
                with self.assertRaises(ValueError): activation.validate_launch(config, object())
                with self.assertRaises(ValueError):
                    activation.validate_launch(replace(config, pet_skill_fire_value=11), None)
                activation.claim(config, None)
                self.assertTrue(activation.claim_path.exists())
                with self.assertRaises(ValueError): create()
                with self.assertRaises(ValueError): activation.claim(config, None)
                self.assertIs(activation(config), session.return_value)
                session.assert_called_once()
                self.assertFalse(request['reasoning_enabled'])
                with self.assertRaises(ValueError): activation(config)


if __name__ == '__main__':
    unittest.main()
