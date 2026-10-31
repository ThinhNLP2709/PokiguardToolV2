"""P27 source-only review/export. No activation loader or native acceptance."""
import argparse
import json
from pathlib import Path
import shutil
import sys

ROOT = Path(__file__).resolve().parents[1]
sys.path[:0] = [str(ROOT), str(ROOT/'src')]
from pokiguard_v2.reasoning_calibration import source_files, source_fingerprint
from pokiguard_v2.reasoning_operational import host_fingerprint
from pokiguard_v2.reasoning_snapshot import digest, require
from pokiguard_v2.reasoning_projection_review import (
    SCHEMA, P21_SOURCE, CHANGED, ADDED, VERSION, verify_review, validate_costs,
)
from tools.review_reasoning_calibration import ref, write_new


def export_review(out):
    out=out.resolve();require(out.is_relative_to(ROOT) and not out.exists(), 'fresh V2 source review required')
    artifacts=ROOT/'docs/phase5/artifacts'
    parent=artifacts/'5d1_root_policy_p21_v1/review_verified'
    frozen=artifacts/'5d1_config_projection_integration_p27_v1/before'
    require(digest(source_files(frozen))==P21_SOURCE, 'exact P21 frozen source required')
    out.mkdir(parents=True);shutil.copytree(parent,out/'parent');shutil.copytree(frozen,out/'parent_source')
    def copy(source,dest):
        target=out/dest;target.parent.mkdir(parents=True,exist_ok=True);shutil.copyfile(source,target)
        return ref(out,target)
    old=json.loads((parent/'calibration_review.json').read_text(encoding='utf-8'))
    files=source_files(ROOT);current=digest(files)
    write_new(out/'parent_manifest.json',dict(files=source_files(frozen),fingerprint=P21_SOURCE))
    write_new(out/'target_manifest.json',dict(files=files,fingerprint=current))
    pairs={}
    for name in sorted(CHANGED|ADDED):
        pair={}
        if name in CHANGED:pair['before']=copy(frozen/name,'changes/before/'+name)
        pair['after']=copy(ROOT/name,'changes/after/'+name);pairs[name]=pair
    p26=artifacts/'5d1_config_serialization_proof_p26_v1'
    data=dict(schema=SCHEMA,accepted=False,live_acceptance=False,input_authority=False,
        config_projection_policy=VERSION,target_runtime_sha256=current,host_sha256=host_fingerprint(),
        game_build_sha256=old['game_build_sha256'],policy_json=old['policy_json'],
        proposed_scope_witness=old['proposed_scope_witness'],native_U_ms=None,transport_age_ms=None,
        host_unity_alignment_ms=None,native_binding='PENDING_H_CONVERSION_BOUNDARY',
        parent_review=ref(out,out/'parent/calibration_review.json'),
        parent_manifest=ref(out,out/'parent_manifest.json'),target_manifest=ref(out,out/'target_manifest.json'),
        changes=pairs,candidate=copy(p26/'harness/config_projection_candidate.py','p26/candidate.py'),
        parity_proof=copy(p26/'parity_proof.json','p26/parity.json'),
        component_cost_proof=copy(p26/'component_recomputation.json','p26/component_cost.json'))
    data['review']=verify_review(out,data,runtime_sha256=current,host_sha256=data['host_sha256'])
    write_new(out/'source_review.json',data);return data


def prepare_draft(review_path,qualification_path,out):
    data=json.loads(review_path.read_text(encoding='utf-8'))
    result=verify_review(review_path.parent,data,runtime_sha256=source_fingerprint(ROOT),host_sha256=host_fingerprint())
    q=json.loads(qualification_path.read_text(encoding='utf-8'))
    validate_costs(qualification_path.parent,q)
    require(result['native_binding']=='ACCEPTED', 'native H source binding pending; no draft or activation')
    # Deliberately no draft creation while this source-only schema is pending.


def main():
    p=argparse.ArgumentParser(description=__doc__);s=p.add_subparsers(dest='command',required=True)
    e=s.add_parser('export');e.add_argument('--out',type=Path,required=True)
    v=s.add_parser('verify');v.add_argument('path',type=Path)
    d=s.add_parser('draft');d.add_argument('--review',type=Path,required=True)
    d.add_argument('--qualification',type=Path,required=True);d.add_argument('--out',type=Path,required=True)
    a=p.parse_args()
    if a.command=='export':result=export_review(a.out)
    elif a.command=='verify':
        data=json.loads(a.path.read_text(encoding='utf-8'))
        result=verify_review(a.path.parent,data,runtime_sha256=source_fingerprint(ROOT),host_sha256=host_fingerprint())
    else:result=prepare_draft(a.review,a.qualification,a.out)
    print(json.dumps(dict(operation=a.command,accepted=False,live=False,native_binding='PENDING_H_CONVERSION_BOUNDARY')))


if __name__=='__main__':main()
