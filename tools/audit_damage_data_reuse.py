"""Re-extract pinned old damage samples without relabeling source or loadout.

Replay compatibility, statistical pooling and native input authority are
different decisions. This file-only audit grants the first one only when the
entire sample reproduces. It never alters source scopes, profiles or caps.
"""
from collections import defaultdict
from pathlib import Path
import argparse,hashlib,json,sys
ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.damage_evaluation import digest,validate_dataset
from pokiguard_v2.reasoning_calibration import source_files,source_fingerprint
from tools.prepare_demon_damage_dataset import build,read_json,MANIFEST_SCHEMA

FEATURE_FILES=(
    'tools/prepare_demon_damage_dataset.py','tools/audit_demon_damage_context.py',
    'src/pokiguard_v2/damage_evaluation.py','src/pokiguard_v2/damage_action_context.py',
    'src/pokiguard_v2/board_simulator.py','src/pokiguard_v2/demon_aegis.py',
    'src/pokiguard_v2/state.py')
TARGET_FILES=('tools/prepare_demon_damage_dataset.py','tools/normalize_action_outcomes.py',
    'src/pokiguard_v2/combat_outcome_evidence.py')
PUBLISHER_FILES=('src/pokiguard_v2/autonomous_control.py','src/pokiguard_v2/player_stats.py',
    'src/pokiguard_v2/live_state.py','tools/dispatcher_qte_result_tap.py')
PIPELINE_FILES=tuple(sorted(set(FEATURE_FILES+TARGET_FILES+('tools/audit_damage_data_reuse.py',))))
def sha(p):return hashlib.sha256(p.read_bytes()).hexdigest()
def _hash(v):return type(v) is str and len(v)==64 and all(c in '0123456789abcdef' for c in v)
def _path(v):
    p=Path(v);p=p if p.is_absolute() else ROOT/p;p=p.resolve()
    if not p.is_relative_to(ROOT):raise ValueError('INPUT_INSIDE_V2_REQUIRED')
    return p
def checked_source(snapshot):
    if (type(snapshot) is not dict or type(snapshot.get('files')) is not dict or not 1<=len(snapshot['files'])<=2000
            or not _hash(snapshot.get('source_sha256')) or digest(snapshot['files'])!=snapshot['source_sha256']):
        raise ValueError('SOURCE_MANIFEST_IDENTITY')
    for name,h in snapshot['files'].items():
        if (type(name) is not str or '\\' in name or not name.endswith('.py') or
                Path(name).is_absolute() or '..' in Path(name).parts or name.split('/')[0] not in ('src','tools','tests') or not _hash(h)):
            raise ValueError('SOURCE_FILE_IDENTITY')
    return snapshot
def compare_sources(previous,current):
    previous=checked_source(previous);current=checked_source(current);a=previous['files'];b=current['files']
    changed=sorted(n for n in a.keys()&b.keys() if a[n]!=b[n]);deleted=sorted(a.keys()-b.keys());added=sorted(b.keys()-a.keys())
    def role(names):
        missing=[n for n in names if n not in a or n not in b]
        differences=[n for n in names if n in a and n in b and a[n]!=b[n]]
        return dict(byte_equal=not missing and not differences,missing=missing,changed=differences)
    return dict(previous_source_sha256=previous['source_sha256'],current_source_sha256=current['source_sha256'],
        changed=changed,deleted=deleted,added=added,all_existing_python_byte_equal=not changed and not deleted,
        feature_extractor=role(FEATURE_FILES),target_extractor=role(TARGET_FILES),action_publisher=role(PUBLISHER_FILES),
        scope='STATIC_FILE_IDENTITY_NOT_A_RUNTIME_OR_DISTRIBUTION_CERTIFICATE',
        statistical_pooling_authorized=False,native_timing_reuse_authorized=False,input_authority=False)
def replay_dataset(dataset):
    validate_dataset(dataset)
    if not dataset['samples']:raise ValueError('NONEMPTY_PINNED_DATASET_REQUIRED')
    originals={s['sample_id']:s for s in dataset['samples']};groups=defaultdict(list)
    for s in dataset['samples']:
        refs=s.get('provenance')
        if type(refs) is not list or not refs:raise ValueError('PINNED_RAW_PROVENANCE_REQUIRED')
        for ref in refs:
            p=_path(ref['path'])
            if not p.is_file() or not _hash(ref.get('sha256')) or sha(p)!=ref['sha256']:raise ValueError('PINNED_RAW_CHANGED_OR_MISSING')
            groups[p].append((s,ref))
    manifest=dict(schema=MANIFEST_SCHEMA,cases=[]);pins={}
    for i,(p,records) in enumerate(sorted(groups.items(),key=lambda item:str(item[0]))):
        declarations={digest(dict(match_id=s['match_id'],scope=s['scope'],cohort_id=s['cohort_id'],seen_in_research=s['seen_in_research'])) for s,_ in records}
        if len(declarations)!=1:raise ValueError('AMBIGUOUS_COMBAT_SCOPE_DECLARATION')
        s,ref=records[0];pins[str(p)]=ref['sha256']
        manifest['cases'].append(dict(name='REPLAY_'+str(i),combat_path=str(p),combat_sha256=ref['sha256'],match_id=s['match_id'],
            source_sha256=s['scope']['source_sha256'],game_build_sha256=s['scope']['game_build_sha256'],account_sha256=s['scope']['account_sha256'],
            cohort_id=s['cohort_id'],seen_in_research=s['seen_in_research']))
    rebuilt=build(manifest);candidates={s['sample_id']:s for s in rebuilt['samples']}
    def compare(sid,keys):return sid in candidates and all(originals[sid].get(k)==candidates[sid].get(k) for k in keys)
    def semantic(s):return {k:v for k,v in s.items() if k!='provenance'}
    shared=sorted(set(originals)&set(candidates))
    pre=sum(compare(sid,('features','feature_sha256','input_complete')) for sid in originals)
    target=sum(compare(sid,('target_observation','execution_status')) for sid in originals)
    scopes=sum(compare(sid,('scope','cohort_id','group_id','match_id','seen_in_research')) for sid in originals)
    exact=sum(semantic(originals[sid])==semantic(candidates[sid]) and
        sorted(originals[sid]['provenance'],key=digest)==sorted(candidates[sid]['provenance'],key=digest) for sid in shared)
    all_equal=len(originals)==len(candidates)==exact
    for p,h in pins.items():
        if sha(Path(p))!=h:raise ValueError('RAW_CHANGED_DURING_REPLAY')
    return dict(schema='pokiguard.damage_data_replay_review.v1',dataset_sha256=dataset['dataset_sha256'],
        replay_manifest_sha256=digest(manifest),actions=len(originals),raw_files=len(pins),pre_input_exact=pre,targets_and_execution_exact=target,
        original_scopes_exact=scopes,entire_samples_exact=exact,missing_ids=sorted(set(originals)-set(candidates)),unexpected_ids=sorted(set(candidates)-set(originals)),
        replay_compatible=all_equal,statistical_pooling_authorized=False,source_rewritten=False,cohort_rewritten=False,seen_flags_rewritten=False,
        scope_identity_status='PRESERVED_DECLARATIONS_NOT_RUNTIME_ATTESTATION',historical_seen_status_attested=False,
        model_deployed=False,input_authority=False,raw_inputs_sha256=pins,
        reuse_scope='SAME_PINNED_RAW_REPLAY_AND_RESEARCH_WITH_ORIGINAL_GROUPS_ONLY')
def audit(dataset_paths,snapshot_paths):
    datasets=sorted({_path(p) for p in dataset_paths});snapshots=sorted({_path(p) for p in snapshot_paths})
    if not 1<=len(datasets)<=64 or len(snapshots)>128:raise ValueError('BOUNDED_REUSE_REVIEW_REQUIRED')
    current=dict(source_sha256=source_fingerprint(ROOT),files=source_files(ROOT))
    pipeline={name:sha(ROOT/name) for name in PIPELINE_FILES};results=[];pins={};ids=set();matches=set();targets=0
    for p in datasets:
        pins[str(p)]=sha(p);dataset=validate_dataset(read_json(p));review=replay_dataset(dataset);review['dataset_path']=str(p);results.append(review)
        overlap=ids&{s['sample_id'] for s in dataset['samples']}
        if overlap:raise ValueError('DUPLICATE_PRIMARY_ACTIONS_ACROSS_DATASETS')
        ids.update(s['sample_id'] for s in dataset['samples']);matches.update(s['match_id'] for s in dataset['samples'])
        targets+=sum(s['target_observation']['status']=='RECORDED_COMPONENT' for s in dataset['samples'])
    comparisons=[]
    for p in snapshots:
        pins[str(p)]=sha(p);old=checked_source(read_json(p));comparisons.append(dict(manifest_path=str(p),**compare_sources(old,current)))
    for p,h in pins.items():
        if sha(Path(p))!=h:raise ValueError('INPUT_CHANGED_DURING_REVIEW')
    if source_fingerprint(ROOT)!=current['source_sha256']:raise ValueError('SOURCE_CHANGED_DURING_REVIEW')
    return dict(schema='pokiguard.damage_data_reuse_audit.v1',status='PASS' if all(r['replay_compatible'] for r in results) else 'REPLAY_DIFFERENCE_REQUIRES_REVIEW',
        source_sha256=current['source_sha256'],replay_pipeline_sha256=digest(pipeline),replay_pipeline_files=pipeline,
        pipeline_scope='RECORDED_RAW_EXTRACTION_ONLY_NOT_NATIVE_SOURCE_OR_RUNTIME_AUTHORITY',dataset_reviews=results,source_reviews=comparisons,
        unique_actions=len(ids),unique_matches=len(matches),recorded_targets=targets,source_snapshots=len(comparisons),
        statistical_pooling_authorized=False,loadout_equivalence='UNKNOWN_NOT_INFERRED_FROM_ATTACK_OR_HP',
        input_sha256=pins,new_models_fitted=0,new_live_attempts=0,new_game_inputs=0,process_attachment=False,old_profiles_rebound=False,old_caps_reopened=False,build=False)
def main():
    p=argparse.ArgumentParser(__doc__);p.add_argument('--dataset',type=Path,action='append',required=True);p.add_argument('--snapshot',type=Path,action='append',default=[]);p.add_argument('--out',type=Path,required=True);a=p.parse_args()
    out=_path(a.out);out.parent.mkdir(parents=True,exist_ok=True);result=audit(a.dataset,a.snapshot)
    with out.open('x',encoding='utf-8') as f:json.dump(result,f,indent=2);f.write('\n')
    print(json.dumps({k:result[k] for k in ('status','source_sha256','replay_pipeline_sha256','unique_actions','unique_matches','recorded_targets','source_snapshots')}))
    if result['status']!='PASS':raise SystemExit(1)
if __name__=='__main__':main()
