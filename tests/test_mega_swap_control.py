"""Fresh Mega timing support does not inherit old timing or active-skill proof."""
from copy import deepcopy
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import tempfile
import unittest
from types import SimpleNamespace
from unittest.mock import patch

from pokiguard_v2.basic_policy import PlayStyle
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.gameplay_profile import MainPetType, EvolutionTarget, DamageCardMode, AuditionMode, PetSkillFireCondition
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.reasoning_calibration import check_config, COMMON_MEGA_CONTROL_PROTOCOL, D4_CONTROL_PROTOCOL
from pokiguard_v2.reasoning_common_native import review_bundle
from pokiguard_v2.reasoning_mega_control import mega_swap_witness_key
from pokiguard_v2.reasoning_snapshot import canonical_json
from tests.reasoning_test_paths import reasoning_temp_root
from tests.test_reasoning_common_native import bundle
from tools.prepare_mega_control import prepare_reasoning_run
from tools.qualify_common_reasoning import calibration_projection, reviewed_current_fixture_projection


def config():
    return replace(DesktopConfig(),play_style=PlayStyle.MEGA_ICARUS_SPAM_SKILL,
        main_pet=MainPetType.NORMAL,evolution=EvolutionTarget.MEGA,damage_card=DamageCardMode.PET_SKILL,
        audition_mode=AuditionMode.NO_ACTION,pet_skill_fire_condition=PetSkillFireCondition.SKILL_COST_READY,
        pet_skill_fire_value=None,boss_id='2321',boss_name='No. 11',target_completed_matches=1,max_match_attempts=1)


def mega_bundle(root):
    data,export,unused=bundle(root,absolute=True)
    data['input_families']=['swap']
    def edit(role,change):
        key=data['roles'][role];ref=data['archive'][key];p=root/ref['path']
        obj=json.loads(p.read_text('utf-8'));change(obj)
        raw=canonical_json(obj).encode();p.write_bytes(raw);sha=hashlib.sha256(raw).hexdigest()
        ref['sha256']=export['inputs'][key]=sha
        return sha
    c=jsonable(config())
    witness=dict(account_username_sha256='a'*64,boss=[99,10000,500,250,300],
        loadout=dict(config=['normal','mega','pet_skill'],cards=[[1,2,'sword',0,0,0]],fusion=[5,6]))
    for sample in export['samples']:
        sample['payload']['witness']=witness
        entry=data['archive'][sample['path']];p=root/entry['path']
        lines=p.read_text('utf-8').splitlines();event=json.loads(lines[sample['line']-1])
        event['payload']['witness']=witness;lines[sample['line']-1]=canonical_json(event)
        content=('\n'.join(lines)+'\n').encode();p.write_bytes(content)
        entry['sha256']=export['inputs'][sample['path']]=sample['sha256']=hashlib.sha256(content).hexdigest()
    reqsha=edit('request',lambda obj:obj.update(config=c,total_attempt_cap=1,profile_protocol=COMMON_MEGA_CONTROL_PROTOCOL))
    edit('binding',lambda obj:obj.update(config_json=canonical_json(c),total_attempt_cap=1))
    def change_run(obj):
        obj['snapshot'].update(limits=dict(max_match_attempts=1),attempts=[dict(attempt_index=1)],match_attempts=1,completed_matches=1)
    edit('run',change_run)
    export.update(request_sha256=reqsha,total_attempt_cap=1,all_attempts=[dict(attempt_index=1)],all_attempt_count=1)
    raw=canonical_json(export).encode();(root/data['control_export']['path']).write_bytes(raw)
    data['control_export']['sha256']=hashlib.sha256(raw).hexdigest()
    return data,export


class MegaSwapControlTests(unittest.TestCase):
    def test_current_config_is_an_explicit_one_basic_swap_control(self):
        check_config(config(),1,profile_protocol=COMMON_MEGA_CONTROL_PROTOCOL)

    def test_reasoning_or_shadow_cannot_run_as_a_basic_measurement(self):
        c=config()
        for ai in (replace(c.ai,reasoning_enabled=True),replace(c.ai,shadow_enabled=True)):
            with self.assertRaises(ValueError):check_config(replace(c,ai=ai),1,profile_protocol=COMMON_MEGA_CONTROL_PROTOCOL)

    def test_only_one_attempt_and_exact_completed_target_are_allowed(self):
        for cap,targets,attempts in ((2,2,2),(1,2,1),(1,1,2),(True,1,1)):
            with self.subTest(cap=cap,targets=targets,attempts=attempts),self.assertRaises(ValueError):
                check_config(replace(config(),target_completed_matches=targets,max_match_attempts=attempts),cap,profile_protocol=COMMON_MEGA_CONTROL_PROTOCOL)

    def test_legacy_d4_smallblue_scope_is_not_relaxed(self):
        with self.assertRaisesRegex(ValueError,'SmallBlue'):check_config(config(),3,profile_protocol=D4_CONTROL_PROTOCOL)

    def test_other_profile_pet_route_input_and_missing_target_reject(self):
        c=config()
        changes=(dict(play_style=PlayStyle.GALAXY),dict(main_pet=MainPetType.MEGA),
            dict(evolution=EvolutionTarget.NONE),dict(boss_id=''),
            dict(board_input_mode=type(c.board_input_mode)('drag')))
        for change in changes:
            with self.subTest(change=change),self.assertRaises(ValueError):
                check_config(replace(c,**change),1,profile_protocol=COMMON_MEGA_CONTROL_PROTOCOL)

    def test_unmeasured_randomization_rejects(self):
        c=SimpleNamespace(**vars(config()))
        c.normalized_boss_id='2321'
        c.input_randomization=SimpleNamespace(reaction_max_seconds=1,inter_click_max_seconds=2,coordinate_max_percent=10)
        with self.assertRaisesRegex(ValueError,'randomization'):check_config(c,1,profile_protocol=COMMON_MEGA_CONTROL_PROTOCOL)

    def test_legacy_calibration_ast_and_reviewed_harness_are_still_verified(self):
        self.assertTrue(calibration_projection())
        self.assertTrue(reviewed_current_fixture_projection())

    def test_real_native_bundle_checks_are_shared_without_invented_skill_timing(self):
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as temp:
            root=Path(temp);data,export=mega_bundle(root)
            components,samples=review_bundle(root,data)
            self.assertEqual(1,samples)
            self.assertGreater(components['final_input_ms'],0)
            self.assertEqual(['swap'],data['input_families'])

    def test_evolution_card_changes_do_not_fabricate_a_mixed_account(self):
        before=dict(account_username_sha256='a'*64,boss=[99,10000,500,250,300],
            loadout=dict(config=['normal','mega','pet_skill'],cards=[[1,2,'sword',0,0,0]],fusion=None))
        after=deepcopy(before);after['loadout'].update(cards=[[8,22,'MEGA_ICARUS',200,150,0]],fusion=[5,6])
        self.assertEqual(mega_swap_witness_key(before,config()),mega_swap_witness_key(after,config()))
        changed=deepcopy(after);changed['account_username_sha256']='b'*64
        self.assertNotEqual(mega_swap_witness_key(before,config()),mega_swap_witness_key(changed,config()))
        changed=deepcopy(after);changed['boss'][1]+=1
        self.assertNotEqual(mega_swap_witness_key(before,config()),mega_swap_witness_key(changed,config()))
        changed=deepcopy(after);changed['loadout']['config'][0]='galaxy'
        with self.assertRaises(ValueError):mega_swap_witness_key(changed,config())

    def test_control_pins_and_ledger_are_not_skipped_for_new_protocol(self):
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as temp:
            root=Path(temp);data,export=mega_bundle(root)
            path=root/data['archive'][data['roles']['request']]['path']
            path.write_text('{}',encoding='utf-8')
            with self.assertRaises(ValueError):review_bundle(root,data)

    def test_five_new_attempts_do_not_rewrite_the_one_attempt_basic_ledger(self):
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as temp:
            root=Path(temp);raw=root/'raw';raw.mkdir();data,export=mega_bundle(raw)
            export_path=raw/data['control_export']['path'];qpath=raw/data['qualification']['path']
            with patch('tools.prepare_common_runtime.source_fingerprint',return_value=data['source_sha256']), \
                 patch('tools.prepare_mega_control.source_fingerprint',return_value=data['source_sha256']):
                result=prepare_reasoning_run(export_path,qpath,root/'reasoning',attempt_cap=5,operator_authorization='User requested five reasoning attempts again after the BASIC fallback.')
            self.assertEqual(5,result['max_attempts']);self.assertFalse(result['automatic_start'])
            current=json.loads((root/'reasoning/common.json').read_text('utf-8'))
            self.assertEqual(5,current['max_attempts']);self.assertFalse(current['installed'])
            request=json.loads((root/'reasoning'/current['archive'][current['roles']['request']]['path']).read_text('utf-8'))
            self.assertEqual(1,request['total_attempt_cap']);self.assertFalse(request['reasoning_enabled'])
            self.assertEqual(['swap'],current['input_families'])

    def test_caps_or_authorization_cannot_be_implicit(self):
        for cap,authorization in ((6,'yes'),(True,'yes'),(0,'yes'),(5,'')):
            with self.subTest(cap=cap),self.assertRaises(ValueError):
                prepare_reasoning_run(Path('missing'),Path('missing'),Path('unused'),attempt_cap=cap,operator_authorization=authorization)


if __name__=='__main__':unittest.main()
