"""Prepare one real Mega BASIC swap control before a separate reasoning run.

File-only. No launch, memory access, automatic Start, inherited claims or old
timing rebinding. The reasoning profile cannot be produced before the new run.
"""
from dataclasses import replace
import argparse
import hashlib
import json
from pathlib import Path
import sys

ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
from pokiguard_v2.reasoning_calibration import (
    COMMON_MEGA_CONTROL_PROTOCOL, COMMON_GALAXY_CONTROL_PROTOCOL, build_request, check_config, source_files, source_fingerprint,
)
from pokiguard_v2.reasoning_settings import AISettings
from pokiguard_v2.reasoning_snapshot import require
from tools.prepare_common_runtime import prepare


def write_new(path,data):
    path.parent.mkdir(parents=True,exist_ok=True)
    with path.open('x',encoding='utf-8') as stream:json.dump(data,stream,ensure_ascii=False,indent=2)


def prepare_control(preferences,output,*,game,boss_id,boss_name,prior_basic_fallback_attempts=0):
    output=Path(output).resolve()
    require(output.is_relative_to(ROOT) and not output.exists(),'fresh control directory inside V2 required')
    require(type(prior_basic_fallback_attempts) is int and prior_basic_fallback_attempts>=0,'prior attempts must be retained')
    loaded=DesktopPreferenceStore(preferences).load()
    require(loaded.loaded and not loaded.warnings,'valid explicit Mega preferences required')
    config=replace(loaded.config,ai=AISettings(False,loaded.config.ai.budget_ms,False),
        boss_id=str(boss_id),boss_name=boss_name,target_completed_matches=1,max_match_attempts=1)
    # U4c: Galaxy/G4 use the same one-attempt swap-timing control under their own protocol.
    galaxy=config.play_style.value in ('galaxy','galaxy_shadow_sword')
    protocol=COMMON_GALAXY_CONTROL_PROTOCOL if galaxy else COMMON_MEGA_CONTROL_PROTOCOL
    check_config(config,1,profile_protocol=protocol)
    request=build_request(ROOT,config,game,cohort=('CURRENT_SOURCE_GALAXY_BASIC_SWAP_TIMING1' if galaxy
        else 'CURRENT_SOURCE_MEGA_BASIC_SWAP_TIMING1'),profile_protocol=protocol)
    output.mkdir(parents=True)
    (output/'baseline_basic_auto_bot.py').write_bytes((ROOT/'tools/basic_auto_bot.py').read_bytes())
    write_new(output/'before_source.json',dict(fingerprint=source_fingerprint(ROOT),files=source_files(ROOT)))
    raw=json.loads(Path(preferences).read_text(encoding='utf-8-sig'))
    raw['config'].update(jsonable(config));raw['config']['game_location']=str(game)
    write_new(output/'preferences.json',raw)
    write_new(output/'request.json',request)
    require(source_fingerprint(ROOT)==request['source_sha256'],'source changed during preparation')
    result=dict(schema='pokiguard.mega_swap_control.prepared.v1',status='PREPARED_BASIC_TIMING1_WAITING_OPERATOR',
        source_sha256=request['source_sha256'],request=str(output/'request.json'),
        request_sha256=hashlib.sha256((output/'request.json').read_bytes()).hexdigest(),
        preferences=str(output/'preferences.json'),data_root=str(output/'data'),ui_artifacts=str(output/'ui'),
        target_completed_matches=1,max_match_attempts=1,reasoning_enabled=False,
        profile_protocol=protocol,automatic_start=False,
        proposed_next_reasoning_attempts=5,old_attempts_erased=False,
        prior_basic_fallback_attempts=prior_basic_fallback_attempts,profile_prepared=False,profile_installed=False,
        followup='EXPORT_COMPLETE_NATIVE_CONTROL_THEN_PREPARE_AND_VERIFY_COMMON_AUTHORITY')
    write_new(output/'prepared.json',result)
    return result


def prepare_reasoning_run(export,qualification,output,*,attempt_cap,operator_authorization,d_u1_rules=False,
        play_style=None):
    """The explicit new run limit is independent of the measured BASIC cap."""
    require(type(attempt_cap) is int and 1<=attempt_cap<=5,'explicit reasoning attempt cap 1..5 required')
    require(type(operator_authorization) is str and bool(operator_authorization.strip()),'operator authorization required')
    output=Path(output).resolve()
    result=prepare(export,qualification,output,max_attempts=1)
    path=output/'common.json';data=json.loads(path.read_text(encoding='utf-8'))
    require(data['source_sha256']==source_fingerprint(ROOT),'fresh native control and qualification required')
    data.update(max_attempts=attempt_cap,operator_authorization=operator_authorization,
        attempt_limit_scope='NEW_OPERATOR_REQUEST_NOT_OLD_CONTROL_CLAIM',live_acceptance=False)
    if d_u1_rules is True:data['d_u1_rules']=True  # U4 trial: D-U1 rules for this run only
    if type(play_style) is str:data['play_style']=play_style  # U4c: Galaxy/G4 routing needs the exact style
    path.write_text(json.dumps(data,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
    from pokiguard_v2.reasoning_common_native import review_bundle
    components,samples=review_bundle(output,data)
    return dict(result,components=components,samples=samples,max_attempts=attempt_cap,
        source_sha256=data['source_sha256'],automatic_start=False,installed=False)


def main():
    parser=argparse.ArgumentParser(__doc__)
    parser.add_argument('--preferences',type=Path,required=True);parser.add_argument('--output-dir',type=Path,required=True)
    parser.add_argument('--game',type=Path,required=True);parser.add_argument('--boss-id',required=True)
    parser.add_argument('--boss-name',required=True)
    parser.add_argument('--prior-basic-fallback-attempts',type=int,default=0)
    args=parser.parse_args()
    print(json.dumps(prepare_control(args.preferences,args.output_dir,game=args.game,
        boss_id=args.boss_id,boss_name=args.boss_name,prior_basic_fallback_attempts=args.prior_basic_fallback_attempts)))


if __name__=='__main__':main()
