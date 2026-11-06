"""Prepare a separate BASIC-only common-Demon cohort; never opens or starts a game.

Draft creation grants no live authority. Activation needs the operator's current
bounded live instruction and uses the existing one-Start calibration gate.
"""
import argparse,hashlib,json
from dataclasses import replace
from pathlib import Path
import sys
ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.basic_policy import Intelligence,PlayStyle
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
from pokiguard_v2.gameplay_profile import DamageCardMode,EvolutionTarget,GameMode,MainPetType,PetSkillFireCondition,DemonTargetGem
from pokiguard_v2.reasoning_calibration import (COMMON_DEMON_CONTROL_PROTOCOL,build_request,check_config,decode_config,source_fingerprint)
from pokiguard_v2.reasoning_common_models import DEMON_DECLARATION
from pokiguard_v2.reasoning_settings import AISettings
from pokiguard_v2.reasoning_snapshot import require,strict_json_loads

SCHEMA='pokiguard.common_demon.basic_control_draft.v1'


def write_new(path,data):
    path=Path(path).resolve()
    require(path.is_relative_to(ROOT) and not path.exists(),'fresh output inside V2 required')
    path.parent.mkdir(parents=True,exist_ok=True)
    with path.open('x',encoding='utf-8') as output:json.dump(data,output,ensure_ascii=False,indent=2)


def prepare(preferences,out,*,target,pet_label,boss_id,boss_name,threshold=4,attempts=3):
    loaded=DesktopPreferenceStore(preferences).load()
    require(loaded.loaded and not loaded.warnings,'valid saved preferences required')
    require(type(pet_label) is str and 0<len(pet_label)<=128 and type(boss_name) is str and bool(boss_name),'operator cohort labels required')
    config=replace(loaded.config,play_style=PlayStyle.DEMON_AEGIS_FARM,intelligence=Intelligence.BASIC,
        ai=AISettings(False,4000),game_mode=GameMode.SOLO,main_pet=MainPetType.NORMAL,
        evolution=EvolutionTarget.NONE,damage_card=DamageCardMode.PET_PASSIVE,
        pet_skill_fire_condition=PetSkillFireCondition.SWORD_COUNT,pet_skill_fire_value=threshold,
        demon_target_gem=DemonTargetGem(target),target_completed_matches=attempts,max_match_attempts=attempts,
        max_technical_recoveries=1,boss_id=str(boss_id),boss_name=boss_name,
        input_delivery_mode=type(loaded.config.input_delivery_mode)('foreground'),
        board_input_mode=type(loaded.config.board_input_mode)('two_click'),
        game_window_size_profile=type(loaded.config.game_window_size_profile)('original_1280x640'))
    check_config(config,attempts,profile_protocol=COMMON_DEMON_CONTROL_PROTOCOL)
    data=dict(schema=SCHEMA,status='OFFLINE_READY_LIVE_NOT_AUTHORIZED',accepted=False,input_authority=False,
        request_created=False,claim_created=False,source_sha256=source_fingerprint(ROOT),config=jsonable(config),
        profile_protocol=COMMON_DEMON_CONTROL_PROTOCOL,operator_pet_label=pet_label,
        runtime_pet_identity='NOT_OBSERVED',declaration=DEMON_DECLARATION.plain(),
        planned_basic_attempts=attempts,planned_reasoning_attempts=attempts,total_case_cap=attempts*2,
        reasoning_authorized=False,reasoning_requires_separate_runtime_review=True,
        scope='FRESH_CONFIGURED_TARGET_COHORT_NOT_OLD_SHIELD_ACCEPTANCE',
        sword_unit='EFFECTIVE_INCLUDING_MULTIPLIERS',automatic_start=False)
    write_new(out,data)
    return data


def activate(draft,out,*,game,authorization):
    path=Path(draft).resolve()
    require(path.is_relative_to(ROOT) and path.is_file() and path.stat().st_size<=128*1024,'bounded draft inside V2 required')
    data=strict_json_loads(path.read_text('utf-8'))
    require(data['schema']==SCHEMA and data['accepted'] is False and data['input_authority'] is False
        and data['request_created'] is False and data['claim_created'] is False
        and data['source_sha256']==source_fingerprint(ROOT)
        and data['declaration']==DEMON_DECLARATION.plain(),'unmodified current-source draft required')
    require(type(authorization) is str and 0<len(authorization.strip())<=2000,'current explicit live instruction required')
    config=decode_config(data['config']);cap=data['planned_basic_attempts']
    check_config(config,cap,profile_protocol=COMMON_DEMON_CONTROL_PROTOCOL)
    require(data['planned_reasoning_attempts']==cap and data['total_case_cap']==cap*2,'bounded case plan changed')
    request=build_request(ROOT,config,game,cohort='COMMON_DEMON_'+config.demon_target_gem.value.upper()+'_BASIC_CONTROL',
        profile_protocol=COMMON_DEMON_CONTROL_PROTOCOL)
    request.update(operator_authorization=authorization,operator_pet_label=data['operator_pet_label'],
        total_case_cap=data['total_case_cap'],planned_basic_attempts=cap,planned_reasoning_attempts=cap,
        declaration=data['declaration'],reasoning_requires_separate_runtime_review=True)
    write_new(out,request)
    return request


def main():
    parser=argparse.ArgumentParser(description=__doc__);sub=parser.add_subparsers(dest='mode',required=True)
    draft=sub.add_parser('prepare');draft.add_argument('--preferences',type=Path,required=True)
    draft.add_argument('--out',type=Path,required=True);draft.add_argument('--target',choices=tuple(t.value for t in DemonTargetGem),required=True)
    draft.add_argument('--pet',required=True);draft.add_argument('--boss-id',required=True);draft.add_argument('--boss-name',required=True)
    draft.add_argument('--threshold',type=int,default=4);draft.add_argument('--attempts',type=int,default=3)
    live=sub.add_parser('activate');live.add_argument('--draft',type=Path,required=True);live.add_argument('--out',type=Path,required=True)
    live.add_argument('--game',required=True);live.add_argument('--authorization',required=True)
    args=parser.parse_args()
    data=(prepare(args.preferences,args.out,target=args.target,pet_label=args.pet,boss_id=args.boss_id,
        boss_name=args.boss_name,threshold=args.threshold,attempts=args.attempts) if args.mode=='prepare'
        else activate(args.draft,args.out,game=args.game,authorization=args.authorization))
    print(json.dumps(dict(status=data.get('status','REQUEST_CREATED'),reasoning_enabled=False,automatic_start=False,
        sha256=hashlib.sha256(args.out.read_bytes()).hexdigest())))


if __name__=='__main__':main()
