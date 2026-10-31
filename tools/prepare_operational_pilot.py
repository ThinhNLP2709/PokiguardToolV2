"""File-only operational draft. This command cannot accept or activate a pilot."""
import argparse
import hashlib
import json
import math
from pathlib import Path
import shutil
import sys

ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.reasoning_calibration import decode_config, source_fingerprint
from pokiguard_v2.reasoning_calibration_review import document, verify_review
from pokiguard_v2.reasoning_operational import SCHEMA, ORIGIN, host_fingerprint, command_wait_ms
from pokiguard_v2.reasoning_operational_launch import DRAFT_SCHEMA, check_launch_config, operational_policy_json
from pokiguard_v2.reasoning_snapshot import digest, require
from tools.review_reasoning_calibration import ref, write_new
from tools.qualify_reasoning_selection import quantiles


def validate_qualification(directory,q):
    """Recompute summaries from retained raw measurements, including retention."""
    def lines(name,cap):
        path=directory/name;require(path.stat().st_size<=cap,'bounded qualification raw required')
        return [json.loads(s) for s in path.read_text(encoding='utf-8').splitlines()]
    rows=lines('checkpoint_raw.jsonl',16*1024*1024)
    require(len(rows)==30000, 'complete checkpoint measurements required')
    for mode in ('disabled','completed','timeout','error','fallback'):
        items=[r for r in rows if r['path']==mode]
        require([r['index'] for r in items]==list(range(6000))
                and all(r['warmup']==(r['index']<1000) for r in items), 'warmup/measurement sequence changed')
        require(all(type(r[k]) in (int,float) and math.isfinite(r[k]) and r[k]>=0
                    for r in items for k in ('ms','cpu_ms')), 'invalid measured latency/CPU')
        measured=items[1000:];stats=quantiles([r['ms'] for r in measured])
        require(stats==q['selector_paths_ms'][mode]
                and all(stats[k]<=limit for k,limit in zip(('p50','p95','p99','max'),(1.5,3,9,30))),
                'checkpoint summary/threshold changed')
        require(sum(r['cpu_ms'] for r in measured)/5000==q['mean_cpu_ms_per_three_checkpoints'][mode],
                'CPU summary changed')
    cpu=q['mean_cpu_ms_per_three_checkpoints']
    require(max(cpu.values())-cpu['disabled']<=1.5,'CPU allowance exceeded')
    rows=lines('pipeline_raw.jsonl',4*1024*1024)
    require([r['index'] for r in rows]==list(range(6000))
            and all(r['warmup']==(r['index']<1000) for r in rows), 'complete collector measurements required')
    require(all(type(r['ms']) in (int,float) and math.isfinite(r['ms']) and r['ms']>=0 for r in rows),
            'invalid collector measurement')
    stats=quantiles([r['ms'] for r in rows[1000:]])
    require(stats==q['full_timing_pipeline_ms'] and all(stats[k]<=v for k,v in
            zip(('p50','p95','p99','max'),(.5,1,3,10))), 'collector qualification changed')
    require((directory/'stop_raw.json').stat().st_size<=256*1024, 'bounded Stop raw required')
    stop=json.loads((directory/'stop_raw.json').read_text(encoding='utf-8'))
    require(all(type(t) in (int,float) and math.isfinite(t) and t>=0 for t in stop), 'invalid Stop measurement')
    require(len(stop)==1000 and quantiles(stop)==q['stop_ms'] and max(stop)<25, 'Stop qualification changed')
    require(q['stress']['seconds']>=60 and q['stress']['max_queued_records']<=1
            and q['stress']['peak_traced_bytes']<16*1024*1024
            and q['gates']['worker_reaped'] is True, 'bounded stress/cleanup incomplete')
    manifest=json.loads((directory/'source_manifest.json').read_text(encoding='utf-8'))
    require(digest(manifest['files'])==manifest['fingerprint']==q['runtime_sha256'], 'qualification source changed')


def prepare_draft(calibration_path,qualification_path,out,*,root=ROOT):
    require(out.resolve().is_relative_to(root.resolve()), 'draft output must stay inside V2')
    require(not out.resolve().is_relative_to(calibration_path.parent.resolve())
            and not out.resolve().is_relative_to(qualification_path.parent.resolve()),
            'output must be separate from immutable input packages')
    require(calibration_path.stat().st_size<=512*1024 and qualification_path.stat().st_size<=512*1024,
            'bounded calibration/qualification required')
    require(not (calibration_path.parent/'qualification').exists()
            and not (calibration_path.parent/'selector_allowance.json').exists(),
            'fresh unqualified review export required; preserve existing packages')
    data=json.loads(calibration_path.read_text(encoding='utf-8'))
    current=source_fingerprint(root);host=host_fingerprint()
    result=verify_review(calibration_path.parent,data,runtime_sha256=current,host_sha256=host,
        game_build_sha256=data['game_build_sha256'],policy_json=data['policy_json'],witness=data['proposed_scope_witness'])
    q=json.loads(qualification_path.read_text(encoding='utf-8'))
    require(q['pass_all'] is True and all(q['gates'].values()) and q['runtime_sha256']==current
            and q['host_sha256']==host, 'fresh final-source qualification required')
    validate_qualification(qualification_path.parent,q)
    require(all(q['selector_paths_ms'][mode]['n']==5000 for mode in
                ('disabled','completed','timeout','error','fallback')), 'complete measured paths required')
    native=document(calibration_path.parent,data['archive_mapping'][data['roles']['request']])
    config=decode_config(native['config']);check_launch_config(config)
    require(operational_policy_json(config)==data['policy_json'], 'production policy mismatch')
    out.mkdir(parents=True,exist_ok=False)
    # Byte-exact archive, compatibility and source copies; refs remain bounded.
    for path in calibration_path.parent.iterdir():
        dest=out/path.name
        if path.is_dir():shutil.copytree(path,dest)
        else:shutil.copyfile(path,dest)
    shutil.copytree(qualification_path.parent,out/'qualification')
    paths={k:q['selector_paths_ms'][k]['max'] for k in ('completed','timeout','error','fallback')}
    write_new(out/'selector_allowance.json',dict(scope='OFFLINE_OPERATIONAL_SELECTOR',
        runtime_sha256=current,host_sha256=host,paths=paths,
        qualification=ref(out,out/'qualification'/qualification_path.name),
        completed_scope='NORMAL_COMPLETED_RETENTION; NO_OVERRIDE_QUOTA',
        raw_provenance={n:hashlib.sha256((out/'qualification'/n).read_bytes()).hexdigest()
            for n in ('checkpoint_raw.jsonl','pipeline_raw.jsonl','stop_raw.json','source_manifest.json')}))
    old=root/'docs/phase5/artifacts/5d1_operational_timing_v1'
    acceptance=json.loads((old/'accepted_decision.json').read_text(encoding='utf-8'))
    # Keep original accepted contract bytes, not a re-authored approval.
    contract=root/'docs/phase5/research/5d1_p9_operational_timing_contract.md'
    shutil.copyfile(contract,out/'contract.md');shutil.copyfile(old/'accepted_decision.json',out/'decision.json')
    require(acceptance['contract_sha256']==ref(out,out/'contract.md')['sha256'], 'accepted contract changed')
    template=dict(schema=SCHEMA,origin=ORIGIN,created_at=None,expires_at=None,run_id=None,
        runtime_sha256=current,host_sha256=host,game_build_sha256=data['game_build_sha256'],
        game_executable=native['game_executable'],game_executable_sha256=native['game_executable_sha256'],
        full_config=native['config'],full_config_sha256=digest(native['config']),policy_json=data['policy_json'],
        contract=ref(out,out/'contract.md'),decision=ref(out,out/'decision.json'),
        contract_sha256=ref(out,out/'contract.md')['sha256'],decision_sha256=ref(out,out/'decision.json')['sha256'],
        calibration=ref(out,out/calibration_path.name),selector_allowance=ref(out,out/'selector_allowance.json'),
        activation='EXPLICIT_BOUNDED_PILOT_REQUEST',activation_review=None,activation_sha256=None,
        total_attempt_cap=3,scope=dict(account_binding='P11_EXACT_ACCOUNT',boss='Starburst1289_lv73_P11',
            loadout='Phoenix_USER_DECLARED_STRUCTURAL_FUSION254767_2102_ATTACK64647'),
        witness=data['proposed_scope_witness'],model=dict(version='5b2.scoped_inputs.v1'),
        input_parameters=data['input_parameters'],max_read_span_ms=100,host_guard_ms=250,
        return_margin_ms=100,budget_ms=config.ai.budget_ms,
        native_U_ms=None,transport_age_ms=None,host_unity_alignment_ms=None)
    components=dict(controller_tail_ms=result['maxima_ms']['H_ms'],final_input_ms=result['maxima_ms']['I_ms'],
        selector_extra_ms=max(paths.values()),command_wait_ms=command_wait_ms(**data['input_parameters']),host_guard_ms=250)
    draft=dict(schema=DRAFT_SCHEMA,accepted=False,live_acceptance=False,reasoning_authority=False,
        status='OFFLINE_DRAFT_WAITING_INDEPENDENT_BOUNDED_ACTIVATION',request_template=template,
        run_id=None,expires_at=None,claim_created=False,
        normal_outcomes=['RETAIN_BASELINE','VALID_COMPLETED_R1'],override_quota=None,
        reserve_components_ms=components,operational_R_descriptive_ms=max(3000,sum(components.values())),
        calibration_samples=26,anchor_samples=20,
        limitations=['NATIVE_U_UNKNOWN','SAMPLE_MAXIMA_NOT_FUTURE_BOUNDS',
            'COMPLETED_OVERRIDE_BRANCH_NOT_MEASURED','NO_EFFICACY_CLAIM'])
    write_new(out/'pilot_draft.json',draft)
    return draft


def main():
    p=argparse.ArgumentParser(description=__doc__)
    p.add_argument('--calibration',type=Path,required=True)
    p.add_argument('--qualification',type=Path,required=True)
    p.add_argument('--out',type=Path,required=True)
    args=p.parse_args();d=prepare_draft(args.calibration,args.qualification,args.out.resolve())
    print(json.dumps(dict(accepted=d['accepted'],claim_created=False,R_ms=d['operational_R_descriptive_ms'],override_quota=None)))


if __name__=='__main__':main()
