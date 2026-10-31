"""Prepare DarkQueen HT7 REASONING2 from its own closed BASIC1. Never opens UI."""
import argparse
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import shutil
import sys

ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.reasoning_calibration import source_files,source_fingerprint,decode_config
from pokiguard_v2.reasoning_d2_targeted import SCHEMA,verify_native,verify_source_boundary
from pokiguard_v2.reasoning_full_actions import VERSION,PROTOCOL,SOURCE_BINDING
from pokiguard_v2.reasoning_operational import command_wait_ms,host_fingerprint
from pokiguard_v2.reasoning_operational_launch import operational_policy_json
from pokiguard_v2.reasoning_calibration_review import PARAMETERS
from pokiguard_v2.reasoning_component_guard import VERSION as GUARD
from pokiguard_v2.reasoning_root_policy import POLICY
from pokiguard_v2.reasoning_snapshot import digest,require
from tools.prepare_d2_reasoning import write,ref,qualify

ART=ROOT/'docs/phase5/artifacts'
CONTROL=ART/'5d2_darkqueen_basic1_live_20261017_1630'
REVIEW=ART/'5d2_darkqueen_reasoning_preparation_20261017'


def copy_native(out):
    """Seal raw native files, including all17 timing records and all attempts."""
    def cp(path,name):
        dst=out/name;dst.parent.mkdir(parents=True,exist_ok=True);shutil.copyfile(path,dst)
        return ref(out,dst)
    caldir=CONTROL/'ui_session/basic_calibration'
    session=json.loads((caldir/'session.json').read_text(encoding='utf-8'))
    farm=Path(session['farm_directory'])
    request=ART/'5d2_pass_authority_closeout_20261017/darkqueen_basic1/request.json'
    records=list(caldir.glob('reasoning.*.jsonl'));require(len(records)==1,'explicit native rotation review required')
    native=dict(request=cp(request,'native/request.json'),session=cp(caldir/'session.json','native/session.json'),
        run=cp(farm/'run.json','native/run.json'),watermarks=cp(caldir/'watermarks.json','native/watermarks.json'),
        records=cp(records[0],'native/records.jsonl'),
        source_manifest=cp(ART/'5d2_pass_authority_closeout_20261017/after_source.json','native/source_manifest.json'),
        combat=cp(farm/'matches/attempt_001/combat.jsonl','native/combat.jsonl'),
        pet_skills=[cp(p,'native/'+p.name) for p in sorted((farm/'matches/attempt_001').glob('pet_skill_*.jsonl'))])
    write(out/'source_manifest.json',dict(fingerprint=source_fingerprint(ROOT),files=source_files(ROOT)))
    case=dict(case_family='HT7_NONTERMINAL_CONTINUATION_WITH_FULL_ACTIONS',
        proposed_total_case_cap=3,basic_attempts_used=1,proposed_reasoning_cap=2,
        preparation_only=True,new_live_activated=False,
        control_ledger=cp(CONTROL/'attempt_ledger.json','native/control_ledger.json'),
        legacy_starburst_ledger=cp(ART/'5d2_skill_rush_v1/reasoning_reserved_one_live_20261017_153458/attempt_ledger.json',
            'native/legacy_starburst_ledger.json'))
    write(out/'case_review.json',case)
    return dict(schema=SCHEMA,runtime_sha256=source_fingerprint(ROOT),native=native,
        source_manifest=ref(out,out/'source_manifest.json'),case_review=ref(out,out/'case_review.json'),
        before_native_loader=cp(REVIEW/'before/src/pokiguard_v2/reasoning_d2_native.py','before_native_loader.py'))


def prepare(out):
    out=out.resolve()
    require(out.is_relative_to(ROOT.resolve()) and not out.exists(),'fresh package inside V2 required')
    out.mkdir(parents=True)
    source=source_fingerprint(ROOT);cal=copy_native(out)
    native=verify_native(out,cal);boundary=verify_source_boundary(out,cal,ROOT)
    require(native['host_sha256']==host_fingerprint(),'current host differs from DarkQueen control')
    write(out/'calibration.json',cal);write(out/'native_review.json',native);write(out/'runtime_boundary.json',boundary)
    q=qualify(out/'qualification');q['raw_costs']=ref(out,out/'qualification/raw_costs.json')
    write(out/'selector_allowance.json',q)
    request=json.loads((out/'native/request.json').read_text(encoding='utf-8'))
    config=replace(decode_config(request['config']),target_completed_matches=2,max_match_attempts=2)
    profile=dict(version=VERSION,account_sha256=native['witness']['account_username_sha256'],pet_id=2035,
        skill_card_id=7,condition='PERFECT_ONLY',resource_conversion=dict(mana=30,rage=20),source_binding=SOURCE_BINDING)
    write(out/'contract.json',dict(scope='D2_DARKQUEEN_TARGETED_OPERATIONAL_FULL_ACTIONS',
        authority='USER_PREPARE_ONLY_2026_10_17_EXISTING_OPERATIONAL_CONTRACT',
        native_U='UNKNOWN',sample_maxima_not_future_bound=True,
        rules=['own DarkQueen native calibration, all17 rows accounted, only terminal pending span excluded',
            'SWAP/PET_SKILL/PASS when valid; completed BASIC retention is normal; no override quota',
            'same immutable state and existing BASIC/owner/preflight/QTE/input/ACK/Stop flow',
            't0 decision budget4s; existing reserves/commanded wait ceiling/shared250ms guard/margin100ms',
            'timeout/error/missing evidence retains valid BASIC before dispatch; no second-input fallback',
            'proposed2attempts includes failed entry/abort; one-shot claim; no restart/extend'],
        action_profile=profile))
    contract=ref(out,out/'contract.json')
    write(out/'decision.json',dict(accepted=True,scope='OFFLINE_IMPLEMENTATION_AND_READINESS_ONLY',
        contract_sha256=contract['sha256'],user_authorization='vậy chuẩn bị đi',live_activation=False))
    template=dict(schema='pokiguard.reasoning.operational_pilot.v1',origin='NATIVE_OPERATIONAL_CALIBRATED',
        pilot_protocol=PROTOCOL,full_config=jsonable(config),full_config_sha256=digest(jsonable(config)),
        policy_json=operational_policy_json(config),runtime_sha256=source,host_sha256=host_fingerprint(),
        game_build_sha256=request['game_build_sha256'],game_executable=request['game_executable'],
        game_executable_sha256=request['game_executable_sha256'],witness=native['witness'],
        scope=dict(account_binding=native['witness']['account_username_sha256'],boss='1170',
            loadout='HT7_2035_CARD7_DARKQUEEN_TARGETED'),model=dict(version='5b2.scoped_inputs.v1'),
        action_profile=profile,calibration=ref(out,out/'calibration.json'),selector_allowance=ref(out,out/'selector_allowance.json'),
        contract=contract,decision=ref(out,out/'decision.json'),contract_sha256=contract['sha256'],
        decision_sha256=ref(out,out/'decision.json')['sha256'],root_read_policy=POLICY,max_read_span_ms=100,
        host_guard_ms=250,return_margin_ms=100,component_monitor='POST_RETURN_COMPONENTS_V1',
        input_parameters=PARAMETERS,budget_ms=4000,component_guard_policy=GUARD,total_attempt_cap=2,
        native_U_ms=None,transport_age_ms=None,host_unity_alignment_ms=None,activation='EXPLICIT_BOUNDED_PILOT_REQUEST')
    components=dict(controller_tail_ms=native['H_ms'],final_input_ms=native['I_ms'],
        selector_extra_ms=q['selector_extra_ms'],command_wait_ms=command_wait_ms(**PARAMETERS),host_guard_ms=250)
    require(source_fingerprint(ROOT)==source,'source changed during qualification')
    draft=dict(status='OFFLINE_PREPARED_DARKQUEEN_REASONING2_NOT_ACTIVATED',accepted=False,
        run_id=None,created_at=None,expires_at=None,input_authority=False,reasoning_attempts_started=0,
        proposed_reasoning_cap=2,basic_already_used=1,proposed_total_case_cap=3,
        original_starburst_cap_exhausted_untouched=True,request_template=template,
        reserve_components=components,reserve_ms=sum(components.values()),
        gate='User keeps DarkQueen110/HT7/Attack and requests this bounded2 live; activate fresh then manual TOOL Start.',
        limitations=['CONDITIONAL_PERFECT_ONLY','NATIVE_REASONING_PASS_NOT_OBSERVED',
            'NATIVE_DARKQUEEN_REASONING_CONTINUATION_NOT_OBSERVED','NO_EFFICACY_OR_FUTURE_LATENCY_GUARANTEE'])
    write(out/'draft.json',draft)
    return draft


if __name__=='__main__':
    parser=argparse.ArgumentParser(description=__doc__);parser.add_argument('--out',type=Path,required=True)
    args=parser.parse_args();result=prepare(args.out)
    print(json.dumps({k:v for k,v in result.items() if k!='request_template'}))
