"""Export/verify a file-only P11 review; never creates live activation."""
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
from pokiguard_v2.pet_configuration import basic_policy_config
from pokiguard_v2.reasoning_calibration import decode_config, source_files, source_fingerprint
from pokiguard_v2.reasoning_calibration_review import (SCHEMA, WITNESS, PARAMETERS, CHANGED,
    P13_SOURCE, SUCCESSOR_CHANGED, recompute, verify_review)
from pokiguard_v2.reasoning_snapshot import canonical_json, require

P11=ROOT/'docs/phase5/artifacts/5d1_basic_reserve_p11_starburst_20261015_v1'
P13=ROOT/'docs/phase5/artifacts/5d1_calibration_review_p13_v1'
P14=ROOT/'docs/phase5/artifacts/5d1_operational_launch_p14_v1'


def ref(directory,path):
    return dict(path=path.relative_to(directory).as_posix(),sha256=hashlib.sha256(path.read_bytes()).hexdigest())


def write_new(path,data):
    path.parent.mkdir(parents=True,exist_ok=True)
    with path.open('x',encoding='utf-8') as f: f.write(canonical_json(data)+'\n')
    return ref(path.parent,path)


def export_review(out, *, root=ROOT, p11=P11, p13=P13):
    """Known sealed archive locations only, not v1 absolute-path dereferencing."""
    require(out.resolve().is_relative_to(root.resolve()), 'output must be inside V2')
    out.mkdir(parents=True,exist_ok=False)
    old=json.loads((p11/'basic_calibration_export.json').read_text(encoding='utf-8'))
    archived=json.loads((p11/'native_archive_manifest.json').read_text(encoding='utf-8'))['files']
    lookup={str(root/Path(n)):root/Path(v['archive']) for n,v in archived.items()}
    # Explicit local selection; old strings only select these known bytes.
    for n in ('basic_calibration_request.json','ui_session/basic_calibration/session.json',
              'ui_session/basic_calibration/watermarks.json'):
        lookup[str(p11/Path(n))]=p11/Path(n)
    for path in (p11/'ui_session/basic_calibration').glob('reasoning*.jsonl'): lookup[str(path)]=path
    mapping={}
    def copy_identity(identity,path):
        if identity in mapping: return
        target=out/'raw'/f'{len(mapping):03d}_{path.name}'
        target.parent.mkdir(exist_ok=True);shutil.copyfile(path,target);mapping[identity]=ref(out,target)
    for identity,sha in old['inputs'].items():
        require(identity in lookup,'unknown original identity')
        path=lookup[identity];require(hashlib.sha256(path.read_bytes()).hexdigest()==sha,'original input changed')
        copy_identity(identity,path)
    # Preserve all 22 archived successes/failures and the consumed claims.
    for name,item in archived.items():
        path=root/Path(item['archive'])
        require(hashlib.sha256(path.read_bytes()).hexdigest()==item['sha256'],'native archive changed')
        copy_identity(str(root/Path(name)),path)
    claims=[]
    for run_id in ('bfd50030618547598269a91650606acc',
                   'd9a45e7cc175490c987c9258d5affc1d', '0d63a96d5d3b4392a809f737339192e4'):
        path=root/'logs/basic_calibration_claims'/f'{run_id}.json'
        require(path.is_file(), 'consumed claim missing')
        copy_identity(str(path),path)
        claims.append(str(path))
    original=out/'raw/original_export.json';shutil.copyfile(p11/'basic_calibration_export.json',original)
    roles={}
    for role,suffix in [('request','basic_calibration_request.json'),('session','session.json'),
                        ('watermarks','watermarks.json'),('run','6f600539556e45af9c43acf2859b9012\\run.json')]:
        roles[role]=next(n for n in old['inputs'] if n.endswith(suffix))
    roles['records']=next(n for n in old['inputs'] if 'reasoning.' in n)
    roles['combats']=[n for n in old['inputs'] if n.endswith('combat.jsonl')]
    roles['entries']=[n.replace('combat.jsonl','entry\\entry.json') for n in roles['combats']]
    roles['claims']=claims
    roles['failed_runs']=[n for n in mapping if n.endswith('run.json') and n!=roles['run']]
    manifest=out/'raw/native_archive_manifest.json';shutil.copyfile(p11/'native_archive_manifest.json',manifest)
    native=json.loads((p13/'before_snapshot.json').read_text(encoding='utf-8'))
    current_files=source_files(root);current_sha=source_fingerprint(root)
    successor=current_sha!=P13_SOURCE
    target_files=(json.loads((p13/'final_test_source_manifest.json').read_text(encoding='utf-8'))['files']
                  if successor else current_files)
    changed={}
    for name in sorted(CHANGED):
        pair={}
        after_path=p13/'review_final/sources/after'/name if successor else root/name
        for label,path in [('before',p13/'before'/name),('after',after_path)]:
            dest=out/'sources'/label/name;dest.parent.mkdir(parents=True,exist_ok=True)
            shutil.copyfile(path,dest);pair[label]=ref(out,dest)
        changed[name]=pair
    compat=dict(native_runtime_sha256=native['source_sha256'],target_runtime_sha256=P13_SOURCE,
                native_files=native['source_files'],target_files=target_files,changed=changed,
                historical_acceptance_rebound=False)
    if successor:
        write_new(out/'source_compatibility_p13.json',compat)
        pairs={}
        for name in sorted(SUCCESSOR_CHANGED):
            pair={}
            for label,path in [('before',P14/'before'/name),('after',root/name)]:
                dest=out/'successor'/label/name;dest.parent.mkdir(parents=True,exist_ok=True)
                shutil.copyfile(path,dest);pair[label]=ref(out,dest)
            pairs[name]=pair
        compat=dict(schema='pokiguard.reasoning.calibration_source_successor.v1',
            native_runtime_sha256=native['source_sha256'],base_runtime_sha256=P13_SOURCE,
            target_runtime_sha256=current_sha,target_files=current_files,changed=pairs,
            base_compatibility=ref(out,out/'source_compatibility_p13.json'),historical_acceptance_rebound=False)
    write_new(out/'source_compatibility.json',compat)
    request=json.loads((p11/'basic_calibration_request.json').read_text(encoding='utf-8'))
    config=decode_config(request['config'])
    policy=replace(basic_policy_config(config.gameplay_config),minimum_turn_time_seconds=1,
                   minimum_evolve_time_seconds=1)
    data=dict(schema=SCHEMA,reasoning_authority=False,live_acceptance=False,
        native_runtime_sha256=native['source_sha256'],target_runtime_sha256=compat['target_runtime_sha256'],
        host_sha256=request['host_sha256'],game_build_sha256=request['game_build_sha256'],
        policy_json=canonical_json(jsonable(policy)),proposed_scope_witness=WITNESS,
        max_read_span_ms=100,input_parameters=PARAMETERS,archive_mapping=mapping,
        roles=roles,raw_export=ref(out,original),native_archive_manifest=ref(out,manifest),
        source_compatibility=ref(out,out/'source_compatibility.json'))
    data['review']=recompute(out,data)
    write_new(out/'calibration_review.json',data)
    return data


def main():
    p=argparse.ArgumentParser();subs=p.add_subparsers(dest='command',required=True)
    e=subs.add_parser('export');e.add_argument('--out',type=Path,required=True)
    v=subs.add_parser('verify');v.add_argument('path',type=Path)
    args=p.parse_args()
    if args.command=='export':data=export_review(args.out.resolve())
    else:
        data=json.loads(args.path.read_text(encoding='utf-8'))
        verify_review(args.path.parent,data,runtime_sha256=source_fingerprint(ROOT),
            host_sha256=data['host_sha256'],game_build_sha256=data['game_build_sha256'],
            policy_json=data['policy_json'],witness=data['proposed_scope_witness'])
    print(json.dumps(dict(counts=data['review']['counts'],maxima_ms=data['review']['maxima_ms'],
        reasoning_authority=False,live_acceptance=False)))


if __name__=='__main__': main()
