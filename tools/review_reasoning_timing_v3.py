"""File-only export/verification/false draft for the frozen P18 successor.

There is no accept, activate, game lookup, observer or claim operation here.
"""
import argparse
import json
from pathlib import Path
import shutil
import sys

ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.reasoning_calibration import source_files, source_fingerprint, decode_config
from pokiguard_v2.reasoning_calibration_review import document
from pokiguard_v2.reasoning_operational import host_fingerprint, command_wait_ms, SCHEMA as REQUEST_SCHEMA, ORIGIN
from pokiguard_v2.reasoning_operational_launch import DRAFT_SCHEMA, check_launch_config, operational_policy_json
from pokiguard_v2.reasoning_timing_review import (SCHEMA, MONITOR, COMMAND, P18_CHANGED, P18_ADDED,
    methods, recompute_review, verify_timing_review, validate_costs)
from pokiguard_v2.reasoning_snapshot import require, digest
from tools.review_reasoning_calibration import ref, write_new


def export_review(out):
    out=out.resolve()
    require(out.is_relative_to(ROOT) and not out.exists(), 'fresh V2 package required')
    out.mkdir(parents=True)
    artifacts=ROOT/'docs/phase5/artifacts'
    p16=artifacts/'5d1_operational_remediation_p16_v1'
    p17=artifacts/'5d1_source_timing_review_p17_v1'
    p18=artifacts/'5d1_source_timing_rebind_p18_v1'
    shutil.copytree(artifacts/'5d1_operational_launch_p14_v1/review_final',out/'base')
    def copy(source,dest):
        target=out/dest;target.parent.mkdir(parents=True,exist_ok=True);shutil.copyfile(source,target)
        return ref(out,target)
    proposal=copy(p17/'review_schema_proposal.json','p17/proposal.json')
    proposed=json.loads((p17/'review_schema_proposal.json').read_text(encoding='utf-8'))
    p16_manifest=copy(p16/'final_test_source_manifest.json','p16/source_manifest.json')
    pairs={}
    for name,expected in proposed['P16_exact_changes'].items():
        pairs[name]={stage:copy(ROOT/item['path'],'p16/'+stage+'/'+name) for stage,item in expected.items()}
    archive=artifacts/'5d1_operational_p15_20261015_v1/closure/raw_archive_manifest.json'
    archive_ref=copy(archive,'p15/raw_archive_manifest.json')
    manifest=json.loads(archive.read_text(encoding='utf-8'))
    p15_files={item['archived']:copy(artifacts/'5d1_operational_p15_20261015_v1'/item['archived'],
                                   'p15/'+item['archived']) for item in manifest['entries']}
    target=source_files(ROOT); current=source_fingerprint(ROOT)
    write_new(out/'target/source_manifest.json',dict(files=target,fingerprint=current,source_count=len(target)))
    target_pairs={};target_methods={}
    for name in sorted(P18_CHANGED|P18_ADDED):
        pair={}
        if name in P18_CHANGED:pair['before']=copy(p18/'before'/name,'target/before/'+name)
        pair['after']=copy(ROOT/name,'target/after/'+name)
        target_pairs[name]=pair;target_methods[name]=methods((ROOT/name).read_bytes())
    base=json.loads((out/'base/calibration_review.json').read_text(encoding='utf-8'))
    data=dict(schema=SCHEMA,reasoning_authority=False,live_acceptance=False,
        native_runtime_sha256=base['native_runtime_sha256'],target_runtime_sha256=current,
        host_sha256=host_fingerprint(),game_build_sha256=base['game_build_sha256'],policy_json=base['policy_json'],
        proposed_scope_witness=base['proposed_scope_witness'],input_parameters=base['input_parameters'],
        native_U_ms=None,transport_age_ms=None,host_unity_alignment_ms=None,
        command_ceiling_version=COMMAND,component_monitor=MONITOR,proposal=proposal,
        addendum=copy(ROOT/'docs/phase5/research/5d1_p17_source_timing_rebind_contract.md','timing_addendum.md'),
        base_review=ref(out,out/'base/calibration_review.json'),p16_manifest=p16_manifest,p16_changes=pairs,
        p15_archive=archive_ref,p15_files=p15_files,target_manifest=ref(out,out/'target/source_manifest.json'),
        target_changes=target_pairs,target_methods=target_methods)
    data['review']=recompute_review(out,data,runtime_sha256=current,host_sha256=data['host_sha256'],
        game_build_sha256=data['game_build_sha256'],policy_json=data['policy_json'],witness=data['proposed_scope_witness'])
    write_new(out/'calibration_review.json',data)
    return data


def verify(path):
    data=json.loads(path.read_text(encoding='utf-8'))
    return verify_timing_review(path.parent,data,runtime_sha256=source_fingerprint(ROOT),host_sha256=host_fingerprint(),
        game_build_sha256=data['game_build_sha256'],policy_json=data['policy_json'],witness=data['proposed_scope_witness'])


def prepare_draft(review_path,qualification_path,out):
    out=out.resolve()
    require(out.is_relative_to(ROOT) and not out.exists() and not out.is_relative_to(review_path.parent.resolve())
            and not out.is_relative_to(qualification_path.parent.resolve()), 'fresh separate V2 output required')
    result=verify(review_path)
    data=json.loads(review_path.read_text(encoding='utf-8'))
    q=json.loads(qualification_path.read_text(encoding='utf-8'));costs=validate_costs(qualification_path.parent,q)
    shutil.copytree(review_path.parent,out);shutil.copytree(qualification_path.parent,out/'qualification')
    old=ROOT/'docs/phase5/artifacts/5d1_operational_timing_v1'
    shutil.copyfile(ROOT/'docs/phase5/research/5d1_p9_operational_timing_contract.md',out/'contract.md')
    shutil.copyfile(old/'accepted_decision.json',out/'decision.json')
    decision=json.loads((out/'decision.json').read_text(encoding='utf-8'))
    require(decision['contract_sha256']==ref(out,out/'contract.md')['sha256'], 'parent accepted contract changed')
    base=document(out,data['base_review']); native=document(out/'base',base['archive_mapping'][base['roles']['request']])
    config=decode_config(native['config']);check_launch_config(config)
    require(operational_policy_json(config)==data['policy_json'], 'native launch policy changed')
    write_new(out/'selector_allowance.json',dict(scope='OFFLINE_REVIEWED_V3_SELECTOR',
        runtime_sha256=data['target_runtime_sha256'],host_sha256=data['host_sha256'],costs=costs,
        qualification=ref(out,out/'qualification'/qualification_path.name)))
    template=dict(schema=REQUEST_SCHEMA,origin=ORIGIN,created_at=None,expires_at=None,run_id=None,
        runtime_sha256=data['target_runtime_sha256'],host_sha256=data['host_sha256'],game_build_sha256=data['game_build_sha256'],
        game_executable=native['game_executable'],game_executable_sha256=native['game_executable_sha256'],
        full_config=native['config'],full_config_sha256=digest(native['config']),policy_json=data['policy_json'],
        contract=ref(out,out/'contract.md'),decision=ref(out,out/'decision.json'),
        contract_sha256=ref(out,out/'contract.md')['sha256'],decision_sha256=ref(out,out/'decision.json')['sha256'],
        calibration=ref(out,out/review_path.name),selector_allowance=ref(out,out/'selector_allowance.json'),
        timing_addendum=data['addendum'],component_monitor=MONITOR,command_ceiling_version=COMMAND,
        activation='EXPLICIT_BOUNDED_PILOT_REQUEST',activation_review=None,activation_sha256=None,
        total_attempt_cap=3,scope=dict(account_binding='P11_EXACT_ACCOUNT',boss='Starburst1289_lv73_P11',
            loadout='Phoenix_USER_DECLARED_STRUCTURAL_FUSION254767_2102_ATTACK64647'),
        witness=data['proposed_scope_witness'],model=dict(version='5b2.scoped_inputs.v1'),
        input_parameters=data['input_parameters'],max_read_span_ms=100,host_guard_ms=250,
        return_margin_ms=100,budget_ms=config.ai.budget_ms,native_U_ms=None,transport_age_ms=None,host_unity_alignment_ms=None)
    components=dict(controller_tail_ms=result['cost_basis_ms']['H_ms'],final_input_ms=result['cost_basis_ms']['I_ms'],
        selector_extra_ms=costs['selector_extra_ms'],command_wait_ms=command_wait_ms(**data['input_parameters']),host_guard_ms=250)
    draft=dict(schema=DRAFT_SCHEMA,accepted=False,live_acceptance=False,reasoning_authority=False,
        status='OFFLINE_V3_DRAFT_WAITING_INDEPENDENT_BOUNDED_ACTIVATION',request_template=template,
        reserve_components_ms=components,operational_R_descriptive_ms=max(3000,sum(components.values())),
        calibration_samples=26,anchor_samples=20,operational_supplement_samples=7,
        run_id=None,expires_at=None,claim_created=False,override_quota=None,
        normal_outcomes=['RETAIN_BASELINE','VALID_COMPLETED_R1'],limitations=[
            'NATIVE_U_UNKNOWN','SAMPLE_MAXIMA_NOT_FUTURE_BOUNDS','FIRST_EXACT_CLICK_NOT_MEASURED',
            'ACCEPTED_OVERRIDE_NATIVE_LATENCY_NOT_MEASURED','P15_MISSING_16_TIMINGS',
            'STRESS_RECEIPT_ONLY_NO_PER_CYCLE_TRACE','NO_EFFICACY_CLAIM'])
    write_new(out/'pilot_draft.json',draft)
    return draft


def main():
    p=argparse.ArgumentParser(description=__doc__);subs=p.add_subparsers(dest='command',required=True)
    e=subs.add_parser('export');e.add_argument('--out',type=Path,required=True)
    v=subs.add_parser('verify');v.add_argument('path',type=Path)
    d=subs.add_parser('draft');d.add_argument('--review',type=Path,required=True)
    d.add_argument('--qualification',type=Path,required=True);d.add_argument('--out',type=Path,required=True)
    a=p.parse_args()
    if a.command=='export':result=export_review(a.out)
    elif a.command=='verify':result=verify(a.path)
    else:result=prepare_draft(a.review,a.qualification,a.out)
    print(json.dumps(dict(operation=a.command,accepted=False,claim_created=False,
        R_ms=result.get('operational_R_descriptive_ms'))))


if __name__=='__main__':main()
