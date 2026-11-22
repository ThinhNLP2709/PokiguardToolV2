"""Pinned, already-seen match folds for raw component v2 and unchanged controls."""
from pathlib import Path
from copy import deepcopy
from collections import Counter
import argparse,hashlib,json,sys
ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2 import damage_baseline,damage_conditional,damage_conditional_v2
from pokiguard_v2.damage_evaluation import (PREDICTION_SCHEMA,TARGET,validate_dataset,partitions_for,
    prediction_request,numeric_stratum,dataset_identity,evaluate)
from pokiguard_v2.reasoning_calibration import source_fingerprint
from tools.prepare_demon_damage_dataset import read_json
from tools.run_conditional_damage import paired
MODULES=dict(baseline=damage_baseline,v1=damage_conditional,v2=damage_conditional_v2)
def sha(p):return hashlib.sha256(p.read_bytes()).hexdigest()
def path(value):
    p=Path(value);p=p if p.is_absolute() else ROOT/p;p=p.resolve()
    if not p.is_relative_to(ROOT):raise ValueError('INPUT_INSIDE_V2_REQUIRED')
    return p
def write(p,v):
    with p.open('x',encoding='utf-8') as f:json.dump(v,f,indent=2,allow_nan=False);f.write('\n')
def _score_dataset(dataset,held_ids):
    if held_ids=={s['sample_id'] for s in dataset['samples']}:return dataset
    result=deepcopy(dataset);result['samples']=[s for s in result['samples'] if s['sample_id'] in held_ids]
    result['summary']=dict(actions=len(result['samples']),matches=len({s['match_id'] for s in result['samples']}),
        source_dataset_sha256=dataset['dataset_sha256'],scope='VALIDATION_MATCHES_ONLY')
    result['dataset_sha256']=dataset_identity(result);return validate_dataset(result)
def run_experiment(entry,out):
    dp=path(entry['dataset_path'])
    if sha(dp)!=entry['dataset_file_sha256']:raise ValueError('PINNED_DATASET_CHANGED')
    data=validate_dataset(read_json(dp));folds=entry['folds'];seen=Counter()
    if not 1<=len(folds)<=256 or len({f['id'] for f in folds})!=len(folds):raise ValueError('DISTINCT_BOUNDED_FOLDS_REQUIRED')
    plans=[]
    for f in folds:
        if not f['id'].replace('_','').isalnum() or len(f['id'])>64:raise ValueError('BOUNDED_FOLD_ID_REQUIRED')
        plan=dict(dataset_sha256=data['dataset_sha256'],matches=f['matches'],independent_holdout=False)
        parts=partitions_for(data,plan)
        if set(parts.values())!={'TRAIN','VALIDATION'}:raise ValueError('EXACT_TRAIN_VALIDATION_FOLDS_REQUIRED')
        seen.update(s['sample_id'] for s in data['samples'] if parts[s['match_id']]=='VALIDATION');plans.append((f['id'],plan))
    expected={s['sample_id'] for s in data['samples'] if s['match_id'] in entry['validation_match_ids']}
    if set(seen)!=expected or any(n!=1 for n in seen.values()):raise ValueError('EACH_DECLARED_ACTION_ONCE_IN_VALIDATION')
    score=_score_dataset(data,expected);score_plan=dict(dataset_sha256=score['dataset_sha256'],matches={s['match_id']:'VALIDATION' for s in score['samples']},independent_holdout=False)
    out.mkdir();write(out/'scored_dataset.json',score);write(out/'scored_plan.json',score_plan)
    all_predictions={n:{m:[] for m in ('reference','guarded')} for n in MODULES};pins={};fold_info=[]
    for fid,plan in plans:
        folder=out/fid;folder.mkdir()
        held=[s for s in data['samples'] if plan['matches'][s['match_id']]=='VALIDATION']
        requests=[dict(request=prediction_request(s),scope_id=numeric_stratum(s)) for s in held];write(folder/'pre_input_requests.json',requests)
        models={}
        for n,module in MODULES.items():
            model=module.fit_exploratory(data,plan,allow_uncalibrated_component_experiment=True)
            module.validate_model(model);models[n]=model;write(folder/(n+'_model.json'),model);pins[fid+':'+n]=sha(folder/(n+'_model.json'))
            for mode in ('reference','guarded'):
                forecasts=[];diagnostics=[]
                for item in requests:
                    result,diag=module.predict(model,item['request'],scope_id=item['scope_id'],mode=mode)
                    forecasts.append(result);diagnostics.append(dict(sample_id=result['sample_id'],**diag))
                write(folder/(n+'_'+mode+'_predictions.json'),forecasts);write(folder/(n+'_'+mode+'_diagnostics.json'),diagnostics)
                write(folder/(n+'_'+mode+'_before_scoring.json'),dict(model_sha256=pins[fid+':'+n],
                    predictions_sha256=sha(folder/(n+'_'+mode+'_predictions.json')),requests_sha256=sha(folder/'pre_input_requests.json'),
                    already_seen_data=True,independent_holdout=False,prospective_prediction_provenance_verified=False))
                all_predictions[n][mode].extend(forecasts)
        fold_info.append(dict(id=fid,training_match_ids=models['v2']['training_match_ids'],validation_match_ids=sorted({s['match_id'] for s in held}),
            v2_training_summary=models['v2']['training_summary'],v2_group_support=[dict(counts=g['sword_counts'],boards=g['unique_training_boards']) for g in models['v2']['parameters']]))
    comparisons={};evaluations={};metrics={}
    # All models and forecasts above are immutable before any scoring below.
    write(out/'all_forecasts_before_scoring.json',dict(model_file_sha256=pins,
        prediction_files_sha256={str(p.relative_to(out)):sha(p) for p in out.glob('*/*_predictions.json')},
        already_seen_data=True,policy_tuned=False,independent_holdout=False))
    for n in MODULES:
        evaluations[n]={};metrics[n]={}
        for mode in ('reference','guarded'):
            predictions=all_predictions[n][mode]
            if len(predictions)!=len(expected) or {p['sample_id'] for p in predictions}!=expected:raise ValueError('HELD_PREDICTION_ACCOUNTING')
            frozen=entry.get('frozen_prediction_controls',{}).get(n,{}).get(mode)
            if frozen is not None:
                p=path(frozen['path'])
                if sha(p)!=frozen['sha256']:raise ValueError('FROZEN_CONTROL_FILE_CHANGED')
                original=read_json(p)['predictions']
                if {p['sample_id']:p for p in predictions}!={p['sample_id']:p for p in original}:raise ValueError('UNCHANGED_CONTROL_PREDICTIONS_DIVERGED')
            artifact=dict(schema=PREDICTION_SCHEMA,dataset_sha256=score['dataset_sha256'],model_id=n.upper()+'_FROZEN_RESEARCH_FOLDS_'+sha(out/'all_forecasts_before_scoring.json'),target=TARGET,predictions=predictions)
            write(out/(n+'_'+mode+'_predictions.json'),artifact)
            report=evaluate(score,artifact,score_plan);write(out/(n+'_'+mode+'_evaluation.json'),report);evaluations[n][mode]=report
            metrics[n][mode]=dict(scored=report['scored'],recorded_targets=report['data_readiness'].get('RECORDED_COMPONENT',0),coverage=report['coverage_of_recorded_component_targets'],
                metrics=report['metrics'],macro_match_mae=report['macro_match_mae'],abstentions=dict(Counter(p['abstention_reason'] for p in predictions if p['point'] is None)))
    for control in ('baseline','v1'):
        comparisons[control]={}
        for mode in ('reference','guarded'):
            comparison=paired(evaluations['v2'][mode],evaluations[control][mode]);write(out/(mode+'_paired_'+control+'.json'),comparison)
            comparisons[control][mode]={k:v for k,v in comparison.items() if k!='rows'}
    summary=dict(id=entry['id'],cohort_id=entry['cohort_id'],purpose=entry['purpose'],models_fitted=len(folds)*3,
        source_dataset_sha256=data['dataset_sha256'],scored_dataset_sha256=score['dataset_sha256'],validation_matches=len(entry['validation_match_ids']),
        scored_actions=len(expected),folds=fold_info,metrics=metrics,paired=comparisons,independent_holdout=False,model_deployed=False)
    write(out/'summary.json',summary)
    if sha(dp)!=entry['dataset_file_sha256']:raise ValueError('INPUT_CHANGED_DURING_EXPERIMENT')
    return summary
def run(plan_path,out):
    plan_path=path(plan_path);out=path(out)
    if out.exists():raise ValueError('FRESH_OUTPUT_INSIDE_V2_REQUIRED')
    plan=read_json(plan_path);policy=plan_path.parent/'policy_frozen.json'
    if (plan.get('schema')!='pokiguard.component_v2_experiment.v1' or plan.get('policy')!=damage_conditional_v2.POLICY
            or read_json(policy)!=damage_conditional_v2.POLICY or sha(policy)!=plan.get('policy_file_sha256')
            or plan.get('data_already_examined') is not True or plan.get('independent_holdout') is not False
            or plan.get('hyperparameter_search') is not False or plan.get('live_inputs') is not False
            or type(plan.get('experiments')) is not list or not 1<=len(plan['experiments'])<=64):raise ValueError('FROZEN_SEEN_DATA_PLAN_REQUIRED')
    entries=plan['experiments']
    if len({e['id'] for e in entries})!=len(entries) or any(not e['id'].replace('_','').isalnum() or len(e['id'])>64 for e in entries):raise ValueError('DISTINCT_BOUNDED_EXPERIMENT_IDS')
    source=source_fingerprint(ROOT)
    if source!=plan.get('source_sha256'):raise ValueError('FROZEN_EXPERIMENT_SOURCE_CHANGED')
    out.mkdir();write(out/'frozen_plan.json',plan);write(out/'policy_frozen.json',damage_conditional_v2.POLICY)
    results=[]
    for entry in entries:
        result=run_experiment(entry,out/entry['id']);results.append(result)
        print(json.dumps(dict(experiment=entry['id'],v2_scored={m:v['scored'] for m,v in result['metrics']['v2'].items()})),flush=True)
    if source_fingerprint(ROOT)!=source:raise ValueError('SOURCE_CHANGED_DURING_EXPERIMENT')
    summary=dict(status='COMPLETED_COMPONENT_V2_RESEARCH_NOT_DEPLOYMENT',source_sha256=source,experiment_plan_sha256=sha(plan_path),
        experiments=results,models_fitted=sum(r['models_fitted'] for r in results),pooled_mae=None,
        data_already_examined=True,independent_holdout=False,hyperparameter_search=False,model_deployed=False,
        new_live_attempts=0,new_game_inputs=0,process_attachment=False,build=False)
    write(out/'summary.json',summary);return summary
def main():
    p=argparse.ArgumentParser(__doc__);p.add_argument('--plan',type=Path,required=True);p.add_argument('--out',type=Path,required=True);a=p.parse_args()
    result=run(a.plan,a.out);print(json.dumps({k:v for k,v in result.items() if k!='experiments'}))
if __name__=='__main__':main()
