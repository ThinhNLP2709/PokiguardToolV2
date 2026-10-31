"""File-only D3 BASIC3 draft and explicit activation. No game/process/input API."""
import argparse
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import sys

ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.basic_policy import Intelligence, PlayStyle
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
from pokiguard_v2.gameplay_profile import DamageCardMode, EvolutionTarget, GameMode, MainPetType, PetSkillFireCondition
from pokiguard_v2.reasoning_calibration import D3_CONTROL_PROTOCOL, build_request, check_config, decode_config, source_fingerprint
from pokiguard_v2.reasoning_settings import AISettings

SCHEMA='pokiguard.d3.basic_control_draft.v1'


def _write_new(path,data):
    path=Path(path).resolve()
    if not path.is_relative_to(ROOT) or path.exists():
        raise ValueError('fresh output inside V2 required')
    path.parent.mkdir(parents=True,exist_ok=True)
    with path.open('x',encoding='utf-8') as stream:
        json.dump(data,stream,ensure_ascii=False,indent=2);stream.write('\n')


def prepare(preferences,game,out,*,boss_id=None,boss_name=None):
    loaded=DesktopPreferenceStore(preferences).load()
    if not loaded.loaded or loaded.warnings:
        raise ValueError('valid saved preferences required; do not overwrite them')
    config=replace(loaded.config,play_style=PlayStyle.DEMON_AEGIS_FARM,
        intelligence=Intelligence.BASIC,ai=AISettings(False,4000),game_mode=GameMode.SOLO,
        main_pet=MainPetType.NORMAL,evolution=EvolutionTarget.NONE,damage_card=DamageCardMode.PET_PASSIVE,
        pet_skill_fire_condition=PetSkillFireCondition.SWORD_COUNT,pet_skill_fire_value=4,
        target_completed_matches=3,max_match_attempts=3,max_technical_recoveries=1,
        boss_id=boss_id,boss_name=boss_name,
        input_delivery_mode=type(loaded.config.input_delivery_mode)('foreground'),
        board_input_mode=type(loaded.config.board_input_mode)('two_click'))
    if config.normalized_boss_id:check_config(config,3,profile_protocol=D3_CONTROL_PROTOCOL)
    data=dict(schema=SCHEMA,status='COHORT_PENDING' if not config.normalized_boss_id else 'OFFLINE_READY_LIVE_PENDING',
        accepted=False,input_authority=False,request_created=False,claim_created=False,
        profile_protocol=D3_CONTROL_PROTOCOL,source_sha256=source_fingerprint(ROOT),
        game_executable=str(Path(game).resolve()),config=jsonable(config),
        operator_pet_label='Demon Aegis',runtime_pet_identity='NOT_OBSERVED',
        planned_basic_attempts=3,planned_reasoning_attempts=3,total_case_cap=6,
        reasoning_authorized=False,reasoning_requires_own_native_review=True,
        configuration_note='4 PHYSICAL Sword; multiplier only affects effective proxy; no skill/card/QTE change')
    _write_new(out,data)
    return data


def activate(draft,out,*,authorization):
    path=Path(draft).resolve()
    if not path.is_relative_to(ROOT):raise ValueError('draft must stay inside V2')
    data=json.loads(path.read_text(encoding='utf-8'))
    if (data.get('schema')!=SCHEMA or data.get('accepted') is not False
        or data.get('input_authority') is not False or not authorization.strip()
        or data.get('source_sha256')!=source_fingerprint(ROOT)):
        raise ValueError('current frozen D3 draft and direct operator live request required')
    config=decode_config(data['config'])
    check_config(config,3,profile_protocol=D3_CONTROL_PROTOCOL)
    if not config.boss_name:raise ValueError('operator-selected boss name/ID required before activation')
    request=build_request(ROOT,config,data['game_executable'],
        cohort='D3_DEMON_AEGIS_BASIC3_CONTROL',profile_protocol=D3_CONTROL_PROTOCOL)
    request.update(operator_authorization=authorization,operator_pet_label='Demon Aegis',
        total_case_cap=6,planned_basic_attempts=3,planned_reasoning_attempts=3,
        reasoning_requires_separate_accepted_native_review=True)
    _write_new(out,request)
    return request


def main():
    parser=argparse.ArgumentParser(description=__doc__)
    sub=parser.add_subparsers(dest='mode',required=True)
    draft=sub.add_parser('prepare')
    draft.add_argument('--preferences',type=Path,required=True);draft.add_argument('--game',required=True)
    draft.add_argument('--out',type=Path,required=True);draft.add_argument('--boss-id');draft.add_argument('--boss-name')
    live=sub.add_parser('activate');live.add_argument('--draft',type=Path,required=True)
    live.add_argument('--out',type=Path,required=True);live.add_argument('--authorization',required=True)
    args=parser.parse_args()
    if args.mode=='prepare':result=prepare(args.preferences,args.game,args.out,boss_id=args.boss_id,boss_name=args.boss_name)
    else:result=activate(args.draft,args.out,authorization=args.authorization)
    print(json.dumps(dict(status=result.get('status','REQUEST_CREATED'),reasoning_enabled=False,
        claim_created=False,automatic_start=False,sha256=hashlib.sha256(args.out.read_bytes()).hexdigest())))


if __name__=='__main__':main()
