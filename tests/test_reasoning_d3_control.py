"""D3 BASIC observation gate: no native process, memory, input or worker."""
import ast
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
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
from pokiguard_v2.gameplay_profile import DamageCardMode, EvolutionTarget, GameMode, MainPetType, PetSkillFireCondition
from pokiguard_v2.reasoning_calibration import BasicCalibrationActivation, D3_CONTROL_PROTOCOL, SCHEMA, check_config
from pokiguard_v2.reasoning_settings import AISettings
from pokiguard_v2.reasoning_snapshot import canonical_json
from tools.prepare_d3_control import activate, prepare

ROOT=Path(__file__).resolve().parents[1]


def config():
    return DesktopConfig(play_style=PlayStyle.DEMON_AEGIS_FARM,main_pet=MainPetType.NORMAL,
        evolution=EvolutionTarget.NONE,damage_card=DamageCardMode.PET_PASSIVE,
        pet_skill_fire_condition=PetSkillFireCondition.SWORD_COUNT,pet_skill_fire_value=4,
        boss_id='1289',boss_name='SYNTHETIC_FIXTURE_ONLY',target_completed_matches=3,max_match_attempts=3)


class D3ControlTests(unittest.TestCase):
    def test_explicit_marker_grants_basic_observation_only(self):
        c=config()
        check_config(c,3,profile_protocol=D3_CONTROL_PROTOCOL)
        for protocol in (None,'D2_SKILL_RUSH_BASIC_CONTROL_V1','UNKNOWN'):
            with self.subTest(protocol=protocol),self.assertRaises(ValueError):
                check_config(c,3,profile_protocol=protocol)

    def test_loadout_threshold_owner_mode_cap_and_transport_drift_rejected(self):
        c=config()
        cases=[dict(play_style=PlayStyle.SIMPLE),dict(main_pet=MainPetType.LEGENDARY),
            dict(evolution=EvolutionTarget.NORMAL),dict(damage_card=DamageCardMode.DEFAULT_ATTACK),
            dict(pet_skill_fire_value=3),dict(pet_skill_fire_value=7),dict(boss_id=None),
            dict(pet_skill_fire_condition=PetSkillFireCondition.SHIELD_GEM_COUNT),
            dict(intelligence=Intelligence.REASONING),dict(ai=AISettings(True)),
            dict(target_completed_matches=2),dict(max_match_attempts=4),
            dict(input_delivery_mode=type(c.input_delivery_mode)('pinned_foreground_lease_beta'))]
        for changes in cases:
            with self.subTest(changes=changes),self.assertRaises(ValueError):
                check_config(replace(c,**changes),3,profile_protocol=D3_CONTROL_PROTOCOL)
        for cap in (True,1,2,4,5,6):
            with self.subTest(cap=cap),self.assertRaises(ValueError):check_config(c,cap,profile_protocol=D3_CONTROL_PROTOCOL)

    def test_legacy_loader_ast_exact_after_removing_only_d3_setup_branch(self):
        previous=ROOT/'docs/phase5/artifacts/5d3_demon_acceptance_20261018/before_source/reasoning_calibration.py'
        # Historical D3 contract: D4 separately proves its exact setup-only
        # successor against these saved, hash-pinned D3 bytes.
        d4=ROOT/'docs/phase5/artifacts/5d4_mega_acceptance_20261018'
        manifest=json.loads((d4/'before_source.json').read_text(encoding='utf-8'))
        self.assertEqual(manifest['fingerprint'],'00b19780f78fae906b84df47d4d67af6f085abc0df834822f4c9c6ce15a09702')
        path=d4/'before_source/src/pokiguard_v2/reasoning_calibration.py'
        self.assertEqual(hashlib.sha256(path.read_bytes()).hexdigest(),manifest['files']['src/pokiguard_v2/reasoning_calibration.py'])
        current=ast.parse(path.read_text(encoding='utf-8'))
        old=ast.parse(previous.read_text(encoding='utf-8'))
        current.body=[n for n in current.body if not (isinstance(n,ast.Assign) and any(isinstance(t,ast.Name) and t.id=='D3_CONTROL_PROTOCOL' for t in n.targets))]
        fn=next(n for n in current.body if isinstance(n,ast.FunctionDef) and n.name=='check_config')
        first=fn.body[0]
        self.assertIsInstance(first,ast.If)
        self.assertIn('D3_CONTROL_PROTOCOL',ast.unparse(first.test))
        fn.body=fn.body[1:]
        self.assertEqual(ast.dump(current,include_attributes=False),ast.dump(old,include_attributes=False))

    def test_draft_is_inert_and_does_not_change_saved_preferences(self):
        with tempfile.TemporaryDirectory() as tmp:
            root=Path(tmp);prefs=root/'prefs.json';DesktopPreferenceStore(prefs).save(DesktopConfig())
            before=prefs.read_bytes();out=root/'draft.json'
            with patch('tools.prepare_d3_control.ROOT',root):
                data=prepare(prefs,root/'FAKE.exe',out)
                self.assertEqual(data['status'],'COHORT_PENDING')
                self.assertFalse(data['accepted']);self.assertFalse(data['input_authority'])
                self.assertFalse(data['request_created']);self.assertFalse(data['claim_created'])
                self.assertEqual(prefs.read_bytes(),before)
                with self.assertRaises(ValueError):activate(out,root/'request.json',authorization='')
                with self.assertRaises(ValueError):activate(out,root/'request.json',authorization='fake-test-only')
                self.assertFalse((root/'request.json').exists())

    def test_draft_source_drift_and_existing_output_rejected(self):
        with tempfile.TemporaryDirectory() as tmp:
            root=Path(tmp);prefs=root/'prefs.json';DesktopPreferenceStore(prefs).save(DesktopConfig())
            out=root/'draft.json'
            with patch('tools.prepare_d3_control.ROOT',root):
                prepare(prefs,root/'FAKE.exe',out,boss_id='1289',boss_name='SYNTHETIC_FIXTURE_ONLY')
                with self.assertRaises(ValueError):prepare(prefs,root/'FAKE.exe',out)
                with patch('tools.prepare_d3_control.source_fingerprint',return_value='DIFFERENT'):
                    with self.assertRaises(ValueError):activate(out,root/'request.json',authorization='fake-test-only')
                self.assertFalse((root/'request.json').exists())

    def test_one_shot_claim_only_installs_existing_swap_timing(self):
        c=config()
        with tempfile.TemporaryDirectory() as tmp:
            root=Path(tmp);exe=root/'FAKE.exe';exe.write_bytes(b'FAKE');path=root/'request.json'
            request=dict(schema=SCHEMA,reasoning_enabled=False,run_id='e'*32,created_at=1000,expires_at=8200,
                config=jsonable(c),total_attempt_cap=3,profile_protocol=D3_CONTROL_PROTOCOL,
                host_sha256='h',source_sha256='s',game_executable=str(exe),game_executable_sha256='e',game_build_sha256='b')
            path.write_text(canonical_json(request),encoding='utf-8');sha=hashlib.sha256(path.read_bytes()).hexdigest()
            with patch('pokiguard_v2.reasoning_calibration.time.time',return_value=1001), \
                 patch('pokiguard_v2.reasoning_calibration.host_fingerprint',return_value='h'), \
                 patch('pokiguard_v2.reasoning_calibration.source_fingerprint',return_value='s'), \
                 patch('pokiguard_v2.reasoning_calibration.validate_supported_game_assembly',return_value='b'), \
                 patch('pokiguard_v2.reasoning_calibration.game_assembly_sha256',return_value='e'), \
                 patch('pokiguard_v2.reasoning_calibration.SwapTimingSession') as session:
                create=lambda:BasicCalibrationActivation(path,sha,root=root,directory=root/'timing',game_executable=lambda:exe)
                a=create();self.assertIsNone(a.session);self.assertFalse(a.claim_path.exists())
                with self.assertRaises(ValueError):a(c)
                with self.assertRaises(ValueError):a.validate_launch(c,object())
                a.claim(c,None);self.assertTrue(a.claim_path.exists())
                with self.assertRaises(ValueError):create()
                with self.assertRaises(ValueError):a.claim(c,None)
                self.assertIs(a(c),session.return_value)
                self.assertNotIn('measure_skills',session.call_args.kwargs)
                self.assertNotIn('selection_adapter',session.call_args.kwargs)
                with self.assertRaises(ValueError):a(c)


if __name__=='__main__':unittest.main()
