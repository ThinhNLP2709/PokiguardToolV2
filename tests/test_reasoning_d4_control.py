"""D4 observation admission; fake native surfaces, never process/input access."""
import ast
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import tempfile
from types import SimpleNamespace
import unittest
from unittest.mock import patch

from pokiguard_v2.basic_policy import Intelligence,PlayStyle
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
from pokiguard_v2.gameplay_profile import (AuditionMode,DamageCardMode,EvolutionTarget,
    GameMode,MainPetType,PetSkillFireCondition)
from pokiguard_v2.reasoning_calibration import BasicCalibrationActivation,D4_CONTROL_PROTOCOL,SCHEMA,check_config
from pokiguard_v2.reasoning_settings import AISettings
from pokiguard_v2.reasoning_snapshot import canonical_json
from pokiguard_v2.reasoning_swap_timing import SwapTimingCollector
from tests.test_reasoning_pilot import MemorySink
from tools.prepare_d4_control import prepare,activate

ROOT=Path(__file__).resolve().parents[1]
FROZEN=ROOT/'docs/phase5/artifacts/5d4_mega_acceptance_20261018'


def config():
    return DesktopConfig(play_style=PlayStyle.MEGA_ICARUS_SPAM_SKILL,
        main_pet=MainPetType.NORMAL,evolution=EvolutionTarget.MEGA,damage_card=DamageCardMode.PET_SKILL,
        audition_mode=AuditionMode.NO_ACTION,pet_skill_fire_condition=PetSkillFireCondition.SWORD_COUNT,
        pet_skill_fire_value=6,boss_id='2346',boss_name='Small Blue',target_completed_matches=3,max_match_attempts=3)


class MegaControlTests(unittest.TestCase):
    def test_own_protocol_does_not_grant_reasoning_or_another_profile(self):
        c=config();check_config(c,3,profile_protocol=D4_CONTROL_PROTOCOL)
        for marker in (None,'D2_SKILL_RUSH_BASIC_CONTROL_V1','D3_DEMON_AEGIS_BASIC_CONTROL_V1','UNKNOWN'):
            with self.subTest(marker=marker),self.assertRaises(ValueError):check_config(c,3,profile_protocol=marker)
        with self.assertRaises(ValueError):
            check_config(replace(c,play_style=PlayStyle.SIMPLE),3,profile_protocol=D4_CONTROL_PROTOCOL)

    def test_exact_cohort_cost_source_mode_threshold_and_cap_required(self):
        c=config()
        for change in (dict(main_pet=MainPetType.MEGA),dict(evolution=EvolutionTarget.NONE),
                dict(damage_card=DamageCardMode.DEFAULT_ATTACK),dict(audition_mode=AuditionMode.V3_TWO_DIRECTION),
                dict(pet_skill_fire_value=5),dict(pet_skill_fire_value=7),dict(boss_id='1289'),
                dict(pet_skill_fire_condition=PetSkillFireCondition.MANA_GEM_COUNT),
                dict(intelligence=Intelligence.REASONING),dict(ai=AISettings(True)),
                dict(game_mode=GameMode.COOP),dict(target_completed_matches=2),dict(max_match_attempts=4),
                dict(input_delivery_mode=type(c.input_delivery_mode)('pinned_foreground_lease_beta'))):
            with self.subTest(change=change),self.assertRaises(ValueError):
                check_config(replace(c,**change),3,profile_protocol=D4_CONTROL_PROTOCOL)
        for cap in (True,1,2,4,6,20):
            with self.subTest(cap=cap),self.assertRaises(ValueError):check_config(c,cap,profile_protocol=D4_CONTROL_PROTOCOL)

    def test_draft_is_inert_preserves_preferences_and_reserves_only_three_controls(self):
        with tempfile.TemporaryDirectory() as name:
            root=Path(name);prefs=root/'prefs.json';DesktopPreferenceStore(prefs).save(DesktopConfig())
            before=prefs.read_bytes();out=root/'draft.json'
            with patch('tools.prepare_d4_control.ROOT',root):
                data=prepare(prefs,root/'FAKE.exe',out)
                self.assertFalse(data['accepted']);self.assertFalse(data['input_authority'])
                self.assertFalse(data['request_created']);self.assertFalse(data['claim_created'])
                self.assertEqual(data['total_case_cap'],6)
                self.assertEqual(data['planned_basic_attempts'],3)
                self.assertEqual(data['planned_reasoning_attempts'],3)
                self.assertEqual(data['config'],jsonable(config()))
                self.assertEqual(before,prefs.read_bytes())
                self.assertFalse(data['reasoning_authorized'])

    def test_activation_requires_new_readiness_and_unchanged_source(self):
        with tempfile.TemporaryDirectory() as name:
            root=Path(name);prefs=root/'prefs.json';DesktopPreferenceStore(prefs).save(DesktopConfig())
            out=root/'draft.json'
            with patch('tools.prepare_d4_control.ROOT',root):
                prepare(prefs,root/'FAKE.exe',out)
                with self.assertRaises(ValueError):activate(out,root/'request.json',authorization='')
                with patch('tools.prepare_d4_control.source_fingerprint',return_value='CHANGED'):
                    with self.assertRaises(ValueError):activate(out,root/'request.json',authorization='SYNTHETIC')
                with self.assertRaises(ValueError):prepare(prefs,root/'FAKE.exe',out)
                self.assertFalse((root/'request.json').exists())

    def test_one_shot_claim_enables_only_existing_skill_and_swap_timing(self):
        c=config()
        with tempfile.TemporaryDirectory() as name:
            root=Path(name);exe=root/'FAKE.exe';exe.write_bytes(b'FAKE');path=root/'request.json'
            request=dict(schema=SCHEMA,reasoning_enabled=False,run_id='d'*32,created_at=1000,expires_at=8200,
                config=jsonable(c),total_attempt_cap=3,profile_protocol=D4_CONTROL_PROTOCOL,
                host_sha256='h',source_sha256='s',game_executable=str(exe),game_executable_sha256='e',game_build_sha256='b')
            path.write_text(canonical_json(request),encoding='utf-8');sha=hashlib.sha256(path.read_bytes()).hexdigest()
            with patch('pokiguard_v2.reasoning_calibration.time.time',return_value=1001), \
                 patch('pokiguard_v2.reasoning_calibration.host_fingerprint',return_value='h'), \
                 patch('pokiguard_v2.reasoning_calibration.source_fingerprint',return_value='s'), \
                 patch('pokiguard_v2.reasoning_calibration.validate_supported_game_assembly',return_value='b'), \
                 patch('pokiguard_v2.reasoning_calibration.game_assembly_sha256',return_value='e'), \
                 patch('pokiguard_v2.reasoning_calibration.SwapTimingSession') as session:
                create=lambda:BasicCalibrationActivation(path,sha,root=root,directory=root/'timing',game_executable=lambda:exe)
                a=create();self.assertFalse(a.claim_path.exists());self.assertIsNone(a.session)
                with self.assertRaises(ValueError):a(c)
                a.claim(c,None);self.assertIs(a(c),session.return_value)
                self.assertTrue(session.call_args.kwargs['measure_skills'])
                self.assertNotIn('selection_adapter',session.call_args.kwargs)
                with self.assertRaises(ValueError):create()
                with self.assertRaises(ValueError):a(c)

    def test_existing_collector_records_click_only_without_any_qte_input(self):
        sink=MemorySink();collector=SwapTimingCollector(sink=sink,measure_skills=True)
        collector.decision_interval=dict(decision_exit_ns=100,decision_source_hash='SYNTHETIC')
        result=SimpleNamespace(kind=SimpleNamespace(value='SUCCESS_CLICK_ONLY'),card_clicks=1,space_presses=0)
        with patch('pokiguard_v2.reasoning_swap_timing.time.perf_counter_ns',side_effect=[200,700,701]):
            collector.skill_start(match_id='SYNTHETIC',turn=3,source_hash='SYNTHETIC',skill_card_id=1)
            collector.skill_finish(result=result)
        event=json.loads(sink.buffer.items[0]);p=event['payload']
        self.assertEqual(event['event_type'],'reasoning.skill_timing')
        self.assertTrue(p['complete_interval_bound'])
        self.assertEqual((p['full_primitive_ns'],p['full_tail_ns'],p['card_clicks'],p['space_presses']),(500,600,1,0))
        self.assertIsNone(p['first_click_ns'])

    def test_remove_only_d4_setup_branch_to_recover_exact_previous_ast(self):
        old=ast.parse((FROZEN/'before_source/src/pokiguard_v2/reasoning_calibration.py').read_text('utf-8'))
        native=ROOT/'docs/phase5/artifacts/5d4_smallblue_basic3_live_20261018_041121'
        manifest=json.loads((native/'native_source_manifest.json').read_text('utf-8'))
        self.assertEqual(manifest['fingerprint'],'218d0e6c39a532d9da0c197ccbccceab459289282d087db1545699019f99f1df')
        path=native/'native_source/src/pokiguard_v2/reasoning_calibration.py'
        self.assertEqual(hashlib.sha256(path.read_bytes()).hexdigest(),manifest['files']['src/pokiguard_v2/reasoning_calibration.py'])
        new=ast.parse(path.read_text('utf-8'))
        new.body=[n for n in new.body if not (isinstance(n,ast.Assign) and any(
            isinstance(t,ast.Name) and t.id=='D4_CONTROL_PROTOCOL' for t in n.targets))]
        fn=next(n for n in new.body if isinstance(n,ast.FunctionDef) and n.name=='check_config')
        branch=fn.body[1];self.assertIsInstance(branch,ast.If)
        self.assertEqual(ast.unparse(branch.test),'profile_protocol == D4_CONTROL_PROTOCOL')
        fn.body.pop(1)
        count=0
        for node in ast.walk(new):
            if isinstance(node,ast.Tuple):
                removed=[n for n in node.elts if isinstance(n,ast.Name) and n.id=='D4_CONTROL_PROTOCOL']
                if removed:node.elts=[n for n in node.elts if n not in removed];count+=len(removed)
        self.assertEqual(count,1)
        self.assertEqual(ast.dump(new,include_attributes=False),ast.dump(old,include_attributes=False))

    def test_all_runtime_decision_reader_capture_and_input_files_frozen(self):
        before=json.loads((FROZEN/'before_source.json').read_text('utf-8'))
        self.assertEqual(before['fingerprint'],'00b19780f78fae906b84df47d4d67af6f085abc0df834822f4c9c6ce15a09702')
        allowed={'src/pokiguard_v2/reasoning_calibration.py','tests/reasoning_controller_fixture.py',
            'tests/test_reasoning_d3_control.py','tests/test_reasoning_demon.py','tests/test_reasoning_planner.py'}
        for name,sha in before['files'].items():
            if name not in allowed:
                # Historical330 is immutable; the successor has its own exact boundary test.
                path=ROOT/'docs/phase5/artifacts/5d4_smallblue_basic3_live_20261018_041121/native_source'/name
                self.assertEqual(hashlib.sha256(path.read_bytes()).hexdigest(),sha,name)


if __name__=='__main__':unittest.main()
