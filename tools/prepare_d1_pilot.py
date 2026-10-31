"""File-only D1 package from completed current BASIC controls; never arms a run."""
import argparse
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import shutil
import sys

ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.reasoning_snapshot import canonical_json,digest,require
from pokiguard_v2.reasoning_calibration import source_files,source_fingerprint,decode_config
from pokiguard_v2.reasoning_operational import host_fingerprint,command_wait_ms
from pokiguard_v2.reasoning_operational_launch import operational_policy_json,DRAFT_SCHEMA
from pokiguard_v2.reasoning_d1_native import SCHEMA,PROTOCOL,SOURCE_POLICY,validate_costs,verify_native,check_config
from pokiguard_v2.reasoning_root_policy import POLICY
from pokiguard_v2.reasoning_config_projection import VERSION
from pokiguard_v2.reasoning_calibration_review import PARAMETERS
from tools.basic_calibration import export,write_new,sha
from tools.review_reasoning_calibration import ref


def prepare(request_path,timing,farm,qualification_path,out):
    out=out.resolve();require(out.is_relative_to(ROOT) and not out.exists(),'fresh separate V2 package required')
    for p in (request_path,timing,farm,qualification_path):
        require(p.resolve().is_relative_to(ROOT) and not out.is_relative_to(p.resolve()),'V2 native input paths required')
    request=json.loads(request_path.read_text(encoding='utf-8'));config=decode_config(request['config']);check_config(config)
    source=source_fingerprint(ROOT);host=host_fingerprint()
    require(request['source_sha256']==source and request['host_sha256']==host,'current native source/host required')
    q=json.loads(qualification_path.read_text(encoding='utf-8'));costs=validate_costs(qualification_path.parent,q)
    require(q['profile']==config.play_style.value,'qualification must match BASIC control profile')
    exported=export(request_path,sha(request_path),timing,farm)
    out.mkdir(parents=True)
    def copy(p,name):
        dest=out/name;dest.parent.mkdir(parents=True,exist_ok=True);shutil.copyfile(p,dest);return ref(out,dest)
    # Keep all native raw inputs unchanged, including invalid/aborted attempts.
    native_inputs={}
    for i,(name,expected) in enumerate(exported['inputs'].items()):
        p=Path(name);require(p.resolve().is_relative_to(ROOT) and sha(p)==expected,'native input pin changed')
        native_inputs[name]=copy(p,'native/'+str(i)+'_'+p.name)
    write_new(out/'native_inputs.json',native_inputs)
    write_new(out/'farm_export.json',exported)
    ledger=[dict(index=i,status='COMPLETED' if a.get('normal_postmatch') else 'ABORTED') for i,a in enumerate(exported['all_attempts'])]
    write_new(out/'attempt_ledger.json',ledger)
    records=[]
    for p in sorted(timing.glob('*.jsonl')):
        records.extend(json.loads(s) for s in p.read_text(encoding='utf-8').splitlines())
    # Merged timing is a derived artifact; the original rotated files remain pinned above.
    records.sort(key=lambda x:x['event_seq'])
    with (out/'timing.jsonl').open('x',encoding='utf-8') as f:
        for row in records:f.write(canonical_json(row)+'\n')
    witnesses=[r['payload']['witness'] for r in records if r['event_type']=='reasoning.swap_timing'
        and r['payload'].get('witness') is not None and r['payload']['witness'].get('loadout',{}).get('cards')]
    require(bool(witnesses),'native full loadout witness missing');witness=witnesses[0]
    write_new(out/'source_manifest.json',dict(files=source_files(ROOT),fingerprint=source))
    cal=dict(schema=SCHEMA,mode='BASIC_CALIBRATION_ONLY',origin='NATIVE_OBSERVATION',runtime_sha256=source,
        host_sha256=host,game_build_sha256=request['game_build_sha256'],policy_json=operational_policy_json(config),
        witness=witness,total_attempt_cap=3,source_manifest=ref(out,out/'source_manifest.json'),
        attempt_ledger=ref(out,out/'attempt_ledger.json'),farm_export=ref(out,out/'farm_export.json'),
        native_request=copy(request_path,'native_request.json'),native_session=copy(timing/'session.json','native_session.json'),
        farm_run=copy(farm/'run.json','farm_run.json'),
        watermarks=copy(timing/'watermarks.json','watermarks.json'),records=ref(out,out/'timing.jsonl'),
        combat_records=[copy(p,'combats/'+str(i)+'.jsonl') for i,p in enumerate(sorted((farm/'matches').glob('*/combat.jsonl')))])
    from types import SimpleNamespace
    binding=SimpleNamespace(runtime_sha256=source,host_sha256=host,verified_build_sha256=request['game_build_sha256'])
    native=verify_native(out,cal,binding,policy_json=cal['policy_json'],witness=witness)
    write_new(out/'calibration.json',cal);write_new(out/'native_review.json',native)
    shutil.copytree(qualification_path.parent,out/'qualification')
    write_new(out/'selector_allowance.json',dict(scope='CURRENT_NATIVE_D1_SELECTOR',runtime_sha256=source,
        host_sha256=host,costs=costs,qualification=ref(out,out/'qualification'/qualification_path.name)))
    parent=ROOT/'docs/phase5/artifacts/5d1_source_timing_rebind_p18_v1/pilot_draft/pilot_draft.json'
    draft=json.loads(parent.read_text(encoding='utf-8'));template=draft['request_template']
    copy(ROOT/'docs/phase5/research/5d1_p9_operational_timing_contract.md','contract.md')
    copy(ROOT/'docs/phase5/artifacts/5d1_operational_timing_v1/accepted_decision.json','decision.json')
    template.update(full_config=request['config'],full_config_sha256=digest(request['config']),
        game_executable=request['game_executable'],game_executable_sha256=request['game_executable_sha256'],
        game_build_sha256=request['game_build_sha256'],runtime_sha256=source,host_sha256=host,
        policy_json=cal['policy_json'],witness=witness,scope=dict(account_binding=witness['account_username_sha256'],
            boss=str(config.boss_id),loadout='CURRENT_NATIVE_STRUCTURAL_WITNESS'),calibration=ref(out,out/'calibration.json'),
        selector_allowance=ref(out,out/'selector_allowance.json'),pilot_protocol=PROTOCOL,root_read_policy=POLICY,
        config_projection_policy=VERSION,source_projection_policy=SOURCE_POLICY,max_read_span_ms=100,
        component_monitor='POST_RETURN_COMPONENTS_V1',command_ceiling_version='TWO_CLICKS_TWO_SETTLES_V1',
        input_parameters=PARAMETERS,contract=ref(out,out/'contract.md'),decision=ref(out,out/'decision.json'),
        budget_ms=config.ai.budget_ms,activation_review=None,activation_sha256=None,run_id=None,created_at=None,expires_at=None)
    # Never carry an old scope-specific root review or timing addendum as current acceptance.
    for key in ('root_policy_contract','timing_addendum'):template.pop(key,None)
    components=dict(controller_tail_ms=native['maxima_ms']['H_ms'],final_input_ms=native['maxima_ms']['I_ms'],
        selector_extra_ms=costs['selector_extra_ms'],command_wait_ms=command_wait_ms(**PARAMETERS),host_guard_ms=250)
    draft.update(status='CURRENT_D1_NATIVE_DRAFT_NOT_ARMED',accepted=False,live_acceptance=False,
        reasoning_authority=False,claim_created=False,input_authority=False,run_id=None,expires_at=None,
        reserve_components_ms=components,operational_R_descriptive_ms=max(3000,sum(components.values())),
        calibration_samples=native['returns'],anchor_samples=native['anchors'],operational_supplement_samples=0,
        limitations=['NATIVE_U_UNKNOWN','SAMPLE_MAXIMA_NOT_FUTURE_BOUNDS','FIRST_EXACT_CLICK_NOT_MEASURED',
            'ACCEPTED_OVERRIDE_NATIVE_LATENCY_NOT_MEASURED','STRESS_RECEIPT_ONLY_NO_PER_CYCLE_TRACE','NO_EFFICACY_CLAIM'],
        native_review=ref(out,out/'native_review.json'))
    write_new(out/'pilot_draft.json',draft);return draft


def prepare_controls(preferences,game,boss_id,boss_name,profile,out):
    from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
    from pokiguard_v2.basic_policy import PlayStyle,Intelligence
    from pokiguard_v2.reasoning_settings import AISettings
    from pokiguard_v2.reasoning_calibration import build_request
    from pokiguard_v2.gameplay_profile import MainPetType,EvolutionTarget,DamageCardMode,GameMode
    loaded=DesktopPreferenceStore(preferences).load()
    require(loaded.loaded and not loaded.warnings,'valid existing preferences required')
    config=replace(loaded.config,play_style=PlayStyle(profile),intelligence=Intelligence.BASIC,
        ai=AISettings(False),game_mode=GameMode.SOLO,boss_id=boss_id,boss_name=boss_name,
        main_pet=MainPetType.NORMAL,evolution=EvolutionTarget.NORMAL,damage_card=DamageCardMode.DEFAULT_ATTACK,
        target_completed_matches=3,max_match_attempts=3)
    check_config(config)
    request=build_request(ROOT,config,game,cohort='D1_CURRENT_'+profile+'_BASIC_CONTROL',seconds=7200)
    write_new(out,request);return request


def main():
    p=argparse.ArgumentParser(description=__doc__);s=p.add_subparsers(dest='command',required=True)
    controls=s.add_parser('controls')
    for name in ('preferences','out'):controls.add_argument('--'+name,type=Path,required=True)
    for name in ('game','boss-id','boss-name'):controls.add_argument('--'+name,required=True)
    controls.add_argument('--profile',choices=['simple','careful'],required=True)
    package=s.add_parser('package')
    for name in ('request','timing','farm','qualification','out'):package.add_argument('--'+name,type=Path,required=True)
    a=p.parse_args()
    if a.command=='controls':
        d=prepare_controls(a.preferences,a.game,a.boss_id,a.boss_name,a.profile,a.out)
        print(json.dumps(dict(request_created=True,reasoning_enabled=False,claim_created=False,sha256=sha(a.out))))
    else:
        d=prepare(a.request,a.timing,a.farm,a.qualification,a.out)
        print(json.dumps(dict(accepted=False,live=False,claim_created=False,status=d['status'])))


if __name__=='__main__':main()
