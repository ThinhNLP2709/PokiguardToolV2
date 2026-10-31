"""File-only D4 BASIC3 draft and separate explicit activation; no game control."""
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
from pokiguard_v2.gameplay_profile import (AuditionMode,DamageCardMode,EvolutionTarget,
    GameMode,MainPetType,PetSkillFireCondition)
from pokiguard_v2.reasoning_calibration import (D4_CONTROL_PROTOCOL,D4_INPUT_TIMING_PROTOCOL,D4_INPUT_RETRY_PROTOCOL,build_request,check_config,
    decode_config,source_fingerprint,d4_probe_run_id,verify_d4_probe_parent,d4_retry_run_id,verify_d4_retry_parent)
from pokiguard_v2.reasoning_settings import AISettings

SCHEMA='pokiguard.d4.basic_control_draft.v1'


def write_new(path,value):
    path=Path(path).resolve()
    if not path.is_relative_to(ROOT) or path.exists():
        raise ValueError('fresh output inside V2 required')
    path.parent.mkdir(parents=True,exist_ok=True)
    with path.open('x',encoding='utf-8') as stream:
        json.dump(value,stream,ensure_ascii=False,indent=2);stream.write('\n')


def prepare(preferences,game,out,*,probe=False,retry=False,total_cap=6):
    if type(total_cap) is not int or total_cap not in ((6,7,8) if retry else (6,)):
        raise ValueError('only explicit D4 remediation/repeat may propose totalcap7or8')
    if retry:probe=True
    loaded=DesktopPreferenceStore(preferences).load()
    if not loaded.loaded or loaded.warnings:
        raise ValueError('valid saved preferences required; never overwrite them')
    config=replace(loaded.config,play_style=PlayStyle.MEGA_ICARUS_SPAM_SKILL,
        intelligence=Intelligence.BASIC,ai=AISettings(False,4000),game_mode=GameMode.SOLO,
        main_pet=MainPetType.NORMAL,evolution=EvolutionTarget.MEGA,damage_card=DamageCardMode.PET_SKILL,
        audition_mode=AuditionMode.NO_ACTION,pet_skill_fire_condition=PetSkillFireCondition.SWORD_COUNT,
        pet_skill_fire_value=6,boss_id='2346',boss_name='Small Blue',
        target_completed_matches=3,max_match_attempts=3,max_technical_recoveries=1,
        input_delivery_mode=type(loaded.config.input_delivery_mode)('foreground'),
        board_input_mode=type(loaded.config.board_input_mode)('two_click'))
    if probe:config=replace(config,target_completed_matches=1,max_match_attempts=1)
    protocol=D4_INPUT_RETRY_PROTOCOL if retry else D4_INPUT_TIMING_PROTOCOL if probe else D4_CONTROL_PROTOCOL
    check_config(config,config.max_match_attempts,profile_protocol=protocol)
    data=dict(schema=SCHEMA,status='OFFLINE_READY_AWAITING_ROOM_AND_STOP_CONFIRMATION',
        accepted=False,input_authority=False,request_created=False,claim_created=False,
        profile_protocol=protocol,source_sha256=source_fingerprint(ROOT),
        game_executable=str(Path(game).resolve()),config=jsonable(config),
        operator_pet_label='Javan IV -> Mega Icarus',runtime_pet_identity='NOT_OBSERVED',
        planned_basic_attempts=4 if probe else 3,planned_reasoning_attempts=2 if probe else 3,total_case_cap=6,
        operator_reported_previous_wins=23,operator_reported_room_limit=30,
        quota_authority='OPERATOR_REPORT_ONLY_NOT_SERVER_VERIFIED',reasoning_authorized=False,
        reasoning_requires_own_native_review=True,existing_skill_timing_enabled=True,
        readiness='PENDING_USER_CONFIRMS_OLD_FARM_STOPPED_AND_SMALLBLUE220_ROOM',
        configuration_note='6 EFFECTIVE Sword inside the existing 30-cell seal, not full board; no QTE')
    if probe:
        parent=ROOT/'docs/phase5/artifacts/5d4_smallblue_basic3_live_20261018_041121/closure.json'
        native=json.loads(parent.read_text(encoding='utf-8'))
        if (native['farm_run_id']!='941c8bc77a2c4713b6584480bcfa8722'
            or native['source_sha256']!='218d0e6c39a532d9da0c197ccbccceab459289282d087db1545699019f99f1df'
            or native['attempts']!=3 or native['wins']!=3 or native['reasoning_activation'] is not False):
            raise ValueError('exact completed D4 BASIC3 parent required')
        data.update(status='OFFLINE_PROBE_READY_AWAITING_OPERATOR_ALLOCATION_AND_ROOM',
            native_parent=dict(path=parent.relative_to(ROOT).as_posix(),sha256=hashlib.sha256(parent.read_bytes()).hexdigest()),
            previous_attempts_consumed=3,probe_attempt_cap=1,remaining_after_probe=2,
            allocation_status='PROPOSED_WITHIN_EXISTING_CAP_NOT_ACTIVATED',
            timing_protocol='5d4.click_only_input_elapsed.v1')
    if retry:
        failed=ROOT/'docs/phase5/artifacts/5d4_input_probe1_live_20261018_125726/closure.json'
        retry_parent=dict(path=failed.relative_to(ROOT).as_posix(),sha256=hashlib.sha256(failed.read_bytes()).hexdigest())
        data.update(status='OFFLINE_REMEDIATION_READY_AWAITING_OPERATOR_ALLOCATION_AND_ROOM',
            retry_parent=retry_parent,previous_attempts_consumed=4,remaining_after_probe=total_cap-5,
            planned_basic_attempts=5,planned_reasoning_attempts=total_cap-5,total_case_cap=total_cap,
            allocation_status='PROPOSED_REMEDIATION_ALLOCATION_NOT_ACTIVATED')
        if total_cap==8:
            repeated=ROOT/'docs/phase5/artifacts/5d4_input_retry1_live_20261018_140315/closure.json'
            data.update(prior_retry_parent=retry_parent,
                retry_parent=dict(path=repeated.relative_to(ROOT).as_posix(),sha256=hashlib.sha256(repeated.read_bytes()).hexdigest()),
                previous_attempts_consumed=5,planned_basic_attempts=6,planned_reasoning_attempts=2,
                remaining_after_probe=2,allocation_status='EXPLICIT_USER_REPEAT_REQUIRES_SEPARATE_ACTIVATION')
            retry_parent=data['retry_parent']
        verify_d4_retry_parent(dict(data,run_id=d4_retry_run_id(retry_parent['sha256'])),ROOT)
    write_new(out,data)
    return data


def activate(draft,out,*,authorization):
    path=Path(draft).resolve()
    if not path.is_relative_to(ROOT):raise ValueError('V2 draft required')
    data=json.loads(path.read_text(encoding='utf-8'))
    if (data.get('schema')!=SCHEMA or data.get('accepted') is not False
        or data.get('input_authority') is not False or type(authorization) is not str
        or not authorization.strip() or data.get('source_sha256')!=source_fingerprint(ROOT)):
        raise ValueError('current draft and direct room/readiness authorization required')
    protocol=data.get('profile_protocol')
    if protocol not in (D4_CONTROL_PROTOCOL,D4_INPUT_TIMING_PROTOCOL,D4_INPUT_RETRY_PROTOCOL):raise ValueError('unknown D4 protocol')
    config=decode_config(data['config']);check_config(config,config.max_match_attempts,profile_protocol=protocol)
    if protocol==D4_INPUT_TIMING_PROTOCOL:
        parent=data['native_parent'];path=ROOT/parent['path']
        if (not path.resolve().is_relative_to(ROOT) or hashlib.sha256(path.read_bytes()).hexdigest()!=parent['sha256']
            or (data['previous_attempts_consumed'],data['probe_attempt_cap'],data['remaining_after_probe'],data['total_case_cap'])!=(3,1,2,6)):
            raise ValueError('D4 native parent or all-attempt allocation changed')
    if protocol==D4_INPUT_RETRY_PROTOCOL:
        verify_d4_retry_parent(dict(data,run_id=d4_retry_run_id(data['retry_parent']['sha256'])),ROOT)
    cohort=('D4_SMALLBLUE220_JAVAN_TO_MEGA_SEAL6_INPUT_REMEDIATION1' if protocol==D4_INPUT_RETRY_PROTOCOL else
        'D4_SMALLBLUE220_JAVAN_TO_MEGA_SEAL6_INPUT_PROBE1' if protocol==D4_INPUT_TIMING_PROTOCOL else
        'D4_SMALLBLUE220_JAVAN_TO_MEGA_SEAL6_BASIC3')
    request=build_request(ROOT,config,data['game_executable'],cohort=cohort,profile_protocol=protocol)
    request.update(operator_authorization=authorization,operator_pet_label=data['operator_pet_label'],
        total_case_cap=6,planned_basic_attempts=data['planned_basic_attempts'],planned_reasoning_attempts=data['planned_reasoning_attempts'],
        reasoning_requires_separate_accepted_native_review=True,
        condition_scope='MEGA_ICARUS_SEAL_30_EFFECTIVE_UNITS',measure_skills=True)
    if protocol==D4_INPUT_TIMING_PROTOCOL:
        request.update(native_parent=data['native_parent'],previous_attempts_consumed=3,
            probe_attempt_cap=1,remaining_after_probe=2,timing_protocol=data['timing_protocol'])
        request['run_id']=d4_probe_run_id(data['native_parent']['sha256'])
        verify_d4_probe_parent(request,ROOT)
    if protocol==D4_INPUT_RETRY_PROTOCOL:
        request.update(native_parent=data['native_parent'],retry_parent=data['retry_parent'],
            previous_attempts_consumed=data['previous_attempts_consumed'],probe_attempt_cap=1,remaining_after_probe=data['remaining_after_probe'],
            total_case_cap=data['total_case_cap'],
            timing_protocol=data['timing_protocol'],run_id=d4_retry_run_id(data['retry_parent']['sha256']))
        if data['total_case_cap']==8:request['prior_retry_parent']=data['prior_retry_parent']
        verify_d4_retry_parent(request,ROOT)
    write_new(out,request)
    return request


def main():
    p=argparse.ArgumentParser(description=__doc__);sub=p.add_subparsers(dest='mode',required=True)
    a=sub.add_parser('prepare');a.add_argument('--preferences',type=Path,required=True)
    a.add_argument('--game',required=True);a.add_argument('--out',type=Path,required=True)
    a.add_argument('--probe',action='store_true',help='Inert one-BASIC input timing probe; proposes 4 BASIC +2 REASONING within cap6')
    a.add_argument('--retry',action='store_true',help='Inert measurement remediation; proposes 5 BASIC +1 REASONING within cap6')
    a.add_argument('--total-cap',type=int,default=6,help='Remediation/repeat only: inert cap6/7/8 proposal; needs separate direct authorization to activate')
    a=sub.add_parser('activate');a.add_argument('--draft',type=Path,required=True)
    a.add_argument('--out',type=Path,required=True);a.add_argument('--authorization',required=True)
    args=p.parse_args()
    result=(prepare(args.preferences,args.game,args.out,probe=args.probe,retry=args.retry,total_cap=args.total_cap) if args.mode=='prepare'
        else activate(args.draft,args.out,authorization=args.authorization))
    print(json.dumps(dict(status=result.get('status','REQUEST_CREATED'),reasoning_enabled=False,
        claim_created=False,automatic_start=False,attempt_cap=result.get('total_attempt_cap',result['config']['max_match_attempts']),sha256=hashlib.sha256(args.out.read_bytes()).hexdigest())))


if __name__=='__main__':main()
