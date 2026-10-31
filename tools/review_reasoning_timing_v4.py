"""File-only successor review/export/false draft. Never starts or claims a run."""
import argparse
from copy import deepcopy
import json
from pathlib import Path
import shutil
import sys

ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.reasoning_calibration import source_files, source_fingerprint
from pokiguard_v2.reasoning_snapshot import require, digest
from pokiguard_v2.reasoning_operational import host_fingerprint, command_wait_ms
from pokiguard_v2.reasoning_calibration_review import document
from pokiguard_v2.reasoning_root_policy import (SCHEMA,POLICY,P18_SOURCE,CHANGED,ADDED,
    verify_review,validate_costs)
from tools.review_reasoning_calibration import ref,write_new


def export_review(out):
    out=out.resolve();require(out.is_relative_to(ROOT) and not out.exists(),'fresh separate V2 package required')
    artifacts=ROOT/'docs/phase5/artifacts'
    parent=artifacts/'5d1_source_timing_rebind_p18_v1/review_final'
    frozen=artifacts/'5d1_root_policy_p21_v1/before'
    require(digest(source_files(frozen))==P18_SOURCE,'exact P18 source snapshot required')
    out.mkdir(parents=True);shutil.copytree(parent,out/'parent');shutil.copytree(frozen,out/'parent_source')
    def copy(source,dest):
        target=out/dest;target.parent.mkdir(parents=True,exist_ok=True);shutil.copyfile(source,target)
        return ref(out,target)
    p18=json.loads((parent/'calibration_review.json').read_text(encoding='utf-8'))
    target=source_files(ROOT);current=digest(target)
    write_new(out/'target_manifest.json',dict(files=target,fingerprint=current))
    pairs={}
    for name in sorted(CHANGED|ADDED):
        pair={}
        if name in CHANGED:pair['before']=copy(frozen/name,'changes/before/'+name)
        pair['after']=copy(ROOT/name,'changes/after/'+name);pairs[name]=pair
    group=artifacts/'5d1_successor_p19_20261015_v1'
    raw=group/'closure/raw';prefix='docs/phase5/artifacts/5d1_successor_p19_20261015_v1/closure/raw/'
    pilot='docs/phase5/artifacts/5d1_successor_p19_20261015_v1/retry_01/ui_session/operational_pilot'
    farm='logs/farm_runs/454ffc5e816d4c23937fc0c6fec5fe87'
    roles={'run':farm+'/run.json','watermarks':pilot+'/watermarks.json'}
    for i in range(3):
        roles[f'reasoning{i}']=next((raw/pilot/f'combat_{i}').glob('*.jsonl')).relative_to(raw).as_posix()
        roles[f'combat{i}']=farm+f'/matches/attempt_{i+1:03d}/combat.jsonl'
    p19={key:dict(copy(raw/name,'p19/'+key+Path(name).suffix),original=prefix+name) for key,name in roles.items()}
    data=dict(schema=SCHEMA,reasoning_authority=False,live_acceptance=False,root_read_policy=POLICY,
        target_runtime_sha256=current,host_sha256=host_fingerprint(),game_build_sha256=p18['game_build_sha256'],
        policy_json=p18['policy_json'],proposed_scope_witness=p18['proposed_scope_witness'],input_parameters=p18['input_parameters'],
        component_monitor=p18['component_monitor'],command_ceiling_version=p18['command_ceiling_version'],
        native_U_ms=None,transport_age_ms=None,host_unity_alignment_ms=None,
        parent_review=ref(out,out/'parent/calibration_review.json'),
        parent_manifest=ref(out,out/'parent/target/source_manifest.json'),target_manifest=ref(out,out/'target_manifest.json'),
        changes=pairs,p19_files=p19,p19_manifest=copy(group/'final_artifact_manifest.json','p19_manifest.json'),
        root_policy_contract=copy(ROOT/'docs/phase5/research/5d1_p20_root_admission_policy_review.md','root_policy_contract.md'))
    data['review']=verify_review(out,data,runtime_sha256=current,host_sha256=data['host_sha256'],
        game_build_sha256=data['game_build_sha256'],policy_json=data['policy_json'],witness=data['proposed_scope_witness'])
    write_new(out/'calibration_review.json',data);return data


def verify(path):
    data=json.loads(path.read_text(encoding='utf-8'));require('review' in data,'declared review required')
    return verify_review(path.parent,data,runtime_sha256=source_fingerprint(ROOT),host_sha256=host_fingerprint(),
        game_build_sha256=data['game_build_sha256'],policy_json=data['policy_json'],witness=data['proposed_scope_witness'])


def prepare_draft(review_path,qualification_path,out):
    out=out.resolve();require(out.is_relative_to(ROOT) and not out.exists()
        and not out.is_relative_to(review_path.parent.resolve())
        and not out.is_relative_to(qualification_path.parent.resolve()),'fresh separate draft required')
    result=verify(review_path);data=json.loads(review_path.read_text(encoding='utf-8'))
    q=json.loads(qualification_path.read_text(encoding='utf-8'));costs=validate_costs(qualification_path.parent,q)
    shutil.copytree(review_path.parent,out);shutil.copytree(qualification_path.parent,out/'qualification')
    old=ROOT/'docs/phase5/artifacts/5d1_source_timing_rebind_p18_v1/pilot_draft/pilot_draft.json'
    draft=deepcopy(json.loads(old.read_text(encoding='utf-8')));template=draft['request_template']
    shutil.copyfile(ROOT/'docs/phase5/research/5d1_p9_operational_timing_contract.md',out/'contract.md')
    shutil.copyfile(ROOT/'docs/phase5/artifacts/5d1_operational_timing_v1/accepted_decision.json',out/'decision.json')
    write_new(out/'selector_allowance.json',dict(scope='OFFLINE_REVIEWED_V4_SELECTOR',
        runtime_sha256=data['target_runtime_sha256'],host_sha256=data['host_sha256'],root_read_policy=POLICY,
        costs=costs,qualification=ref(out,out/'qualification'/qualification_path.name)))
    template.update(runtime_sha256=data['target_runtime_sha256'],host_sha256=data['host_sha256'],
        calibration=ref(out,out/review_path.name),selector_allowance=ref(out,out/'selector_allowance.json'),
        timing_addendum=ref(out,out/'parent/timing_addendum.md'),root_read_policy=POLICY,
        root_policy_contract=ref(out,out/'root_policy_contract.md'))
    require(template['max_read_span_ms']==100 and template['run_id'] is None
        and template['expires_at'] is None and template['activation_review'] is None,'false legacy template changed')
    components=dict(controller_tail_ms=result['cost_basis_ms']['H_ms'],final_input_ms=result['cost_basis_ms']['I_ms'],
        selector_extra_ms=costs['selector_extra_ms'],command_wait_ms=command_wait_ms(**data['input_parameters']),host_guard_ms=250)
    draft.update(status='OFFLINE_V4_DRAFT_WAITING_INDEPENDENT_BOUNDED_ACTIVATION',root_read_policy=POLICY,
        input_authority=False,reserve_components_ms=components,
        operational_R_descriptive_ms=max(3000,sum(components.values())),p19_supplement_samples=30)
    write_new(out/'pilot_draft.json',draft);return draft


def main():
    p=argparse.ArgumentParser(description=__doc__);subs=p.add_subparsers(dest='command',required=True)
    e=subs.add_parser('export');e.add_argument('--out',type=Path,required=True)
    v=subs.add_parser('verify');v.add_argument('path',type=Path)
    d=subs.add_parser('draft');d.add_argument('--review',type=Path,required=True)
    d.add_argument('--qualification',type=Path,required=True);d.add_argument('--out',type=Path,required=True)
    args=p.parse_args()
    if args.command=='export':result=export_review(args.out)
    elif args.command=='verify':result=verify(args.path)
    else:result=prepare_draft(args.review,args.qualification,args.out)
    print(json.dumps(dict(operation=args.command,accepted=False,claim_created=False,
        R_ms=result.get('operational_R_descriptive_ms'))))


if __name__=='__main__':main()
