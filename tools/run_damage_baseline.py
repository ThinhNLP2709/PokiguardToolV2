"""File-only leave-one-match-out exploratory baseline, never model deployment."""
from collections import Counter
from pathlib import Path
import argparse,hashlib,json,sys
ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.damage_baseline import POLICY,fit_exploratory,predict
from pokiguard_v2.damage_evaluation import (TARGET,PREDICTION_SCHEMA,digest,validate_dataset,
    partitions_for,prediction_request,numeric_stratum,input_complete,evaluate)
from tools.prepare_demon_damage_dataset import read_json


def sha(path):return hashlib.sha256(Path(path).read_bytes()).hexdigest()
def save_new(path,value):
    path=Path(path)
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,indent=2,allow_nan=False)


def run(plan_path,output):
    plan_path=Path(plan_path).resolve();plan=read_json(plan_path)
    output=Path(output).resolve()
    if not output.is_relative_to(ROOT) or output.exists():raise ValueError('FRESH_OUTPUT_INSIDE_V2_REQUIRED')
    if (plan.get('schema')!='pokiguard.damage_baseline_experiment.v1' or plan.get('policy')!=POLICY
            or plan.get('data_already_examined') is not True or plan.get('independent_holdout') is not False
            or plan.get('hyperparameter_search') is not False or plan.get('live_inputs') is not False
            or type(plan.get('folds')) is not list or not 2<=len(plan['folds'])<=16):
        raise ValueError('FROZEN_EXPLORATORY_PLAN_REQUIRED')
    p=Path(plan['dataset_path']);p=p if p.is_absolute() else ROOT/p
    if sha(p)!=plan['dataset_file_sha256']:raise ValueError('DATASET_FILE_PIN_MISMATCH')
    dataset=validate_dataset(read_json(p))
    if dataset['dataset_sha256']!=plan['dataset_sha256']:raise ValueError('DATASET_SEMANTIC_PIN_MISMATCH')
    fold_plans=[];validation_counts=Counter()
    for f in plan['folds']:
        fp=dict(dataset_sha256=dataset['dataset_sha256'],matches=f['matches'],independent_holdout=False)
        parts=partitions_for(dataset,fp)
        if set(parts.values())!={'TRAIN','VALIDATION'}:raise ValueError('TRAIN_VALIDATION_MATCHES_REQUIRED')
        validation_counts.update(k for k,v in parts.items() if v=='VALIDATION')
        if type(f['id']) is not str or not f['id'].replace('_','').isalnum() or len(f['id'])>64:
            raise ValueError('BOUNDED_FOLD_ID_REQUIRED')
        fold_plans.append((f['id'],fp))
    if len({f[0] for f in fold_plans})!=len(fold_plans) or validation_counts!={m:1 for m in {s['match_id'] for s in dataset['samples']}}:
        raise ValueError('EACH_MATCH_EXACTLY_ONCE_IN_VALIDATION')
    output.mkdir(parents=True);save_new(output/'frozen_plan.json',plan)
    all_predictions={m:[] for m in POLICY['modes']};fold_results=[];model_pins={}
    for name,fp in fold_plans:
        folder=output/name;folder.mkdir()
        model=fit_exploratory(dataset,fp,allow_uncalibrated_component_experiment=True)
        save_new(folder/'model.json',model);model_pins[name]=sha(folder/'model.json')
        held=[s for s in dataset['samples'] if fp['matches'][s['match_id']]=='VALIDATION']
        assert not set(s['match_id'] for s in held)&set(model['training_match_ids'])
        requests=[dict(request=prediction_request(s),scope_id=numeric_stratum(s)) for s in held]
        save_new(folder/'pre_input_requests.json',requests)
        mode_results={}
        for mode in POLICY['modes']:
            predictions=[];diagnostics=[]
            for item in requests:
                forecast,diagnostic=predict(model,item['request'],scope_id=item['scope_id'],mode=mode)
                predictions.append(forecast);diagnostics.append(dict(sample_id=item['request']['sample_id'],**diagnostic))
            artifact=dict(schema=PREDICTION_SCHEMA,dataset_sha256=dataset['dataset_sha256'],model_id=model['model_sha256']+':'+mode,target=TARGET,predictions=predictions)
            save_new(folder/(mode+'_predictions.json'),artifact)
            save_new(folder/(mode+'_diagnostics.json'),diagnostics)
            # Seal weights and forecasts before reading validation target values for scoring.
            save_new(folder/(mode+'_before_scoring.json'),dict(model_file_sha256=sha(folder/'model.json'),
                prediction_file_sha256=sha(folder/(mode+'_predictions.json')),requests_file_sha256=sha(folder/'pre_input_requests.json'),
                validation_match_ids=sorted({s['match_id'] for s in held}),already_seen_historical_data=True,
                prospective_prediction_provenance_verified=False,independent_holdout=False))
            evaluation=evaluate(dataset,artifact,fp)
            save_new(folder/(mode+'_evaluation.json'),evaluation)
            eligible=sum(s['execution_status']=='ACKNOWLEDGED' and input_complete(s['features'])
                and s['target_observation']['status']=='RECORDED_COMPONENT' for s in held)
            mode_results[mode]=dict(validation_actions=len(held),validation_recorded_targets=eligible,scored=evaluation['scored'],
                coverage=evaluation['scored']/eligible if eligible else None,metrics=evaluation['metrics'],
                abstentions=dict(Counter(p['abstention_reason'] for p in predictions if p['point'] is None)),
                forecasts_outside_training_domain=sum(d['status']=='EXPLORATORY_FORECAST' and bool(d['outside_training_domain']) for d in diagnostics))
            all_predictions[mode].extend(predictions)
        fold_results.append(dict(fold=name,training_match_ids=model['training_match_ids'],
            validation_match_ids=sorted({s['match_id'] for s in held}),training_summary=model['training_summary'],modes=mode_results))
    combined={};combined_plan=dict(dataset_sha256=dataset['dataset_sha256'],matches={s['match_id']:'VALIDATION' for s in dataset['samples']},independent_holdout=False)
    for mode,forecasts in all_predictions.items():
        if len({p['sample_id'] for p in forecasts})!=len(dataset['samples']):raise ValueError('OUT_OF_FOLD_COVERAGE_OR_DUPLICATE')
        artifact=dict(schema=PREDICTION_SCHEMA,dataset_sha256=dataset['dataset_sha256'],model_id='LOMO_'+mode+'_'+digest(model_pins),target=TARGET,predictions=forecasts)
        save_new(output/(mode+'_out_of_fold_predictions.json'),artifact)
        evaluation=evaluate(dataset,artifact,combined_plan);save_new(output/(mode+'_out_of_fold_evaluation.json'),evaluation)
        combined[mode]=dict(scored=evaluation['scored'],recorded_targets=evaluation['data_readiness'].get('RECORDED_COMPONENT',0),
            coverage=evaluation['coverage_of_recorded_component_targets'],metrics=evaluation['metrics'],macro_match_mae=evaluation['macro_match_mae'],
            abstentions=dict(Counter(p['abstention_reason'] for p in forecasts if p['point'] is None)))
    if sha(p)!=plan['dataset_file_sha256']:raise ValueError('DATASET_CHANGED_DURING_EXPERIMENT')
    result=dict(scope='EXPLORATORY_LEAVE_ONE_MATCH_OUT_NOT_INDEPENDENT_OR_SERVER_DAMAGE_MODEL',
        experiment_plan_sha256=sha(plan_path),dataset_sha256=dataset['dataset_sha256'],policy=POLICY,folds=fold_results,
        combined=combined,model_file_sha256=model_pins,models_fitted=len(fold_results),training_scope='LOCAL_EXPLORATORY_COMPONENT_BASELINE_ONLY',
        hyperparameter_search=False,independent_holdout=False,prospective_prediction_provenance_verified=False,
        deployment_eligible=False,gameplay_changed=False,new_game_inputs=0,process_attachment=False,build=False)
    save_new(output/'summary.json',result)
    return result


def main():
    p=argparse.ArgumentParser(__doc__);p.add_argument('--plan',type=Path,required=True);p.add_argument('--out-dir',type=Path,required=True)
    a=p.parse_args();r=run(a.plan,a.out_dir);print(json.dumps(dict(models_fitted=r['models_fitted'],combined=r['combined'],deployment_eligible=False)))


if __name__=='__main__':main()
