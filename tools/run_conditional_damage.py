"""Frozen retrospective match folds and paired comparisons; no live authority."""
from collections import Counter
from pathlib import Path
import argparse
import hashlib
import json
import sys

ROOT = Path(__file__).resolve().parents[1]
sys.path[:0] = [str(ROOT), str(ROOT/'src')]
from pokiguard_v2.damage_conditional import POLICY, fit_exploratory, predict
from pokiguard_v2.damage_evaluation import (
    PREDICTION_SCHEMA, TARGET, validate_dataset, partitions_for, prediction_request,
    numeric_stratum, evaluate, _metrics,
)
from pokiguard_v2.reasoning_calibration import source_fingerprint
from tools.prepare_demon_damage_dataset import read_json


def sha(path): return hashlib.sha256(Path(path).read_bytes()).hexdigest()


def write(path, value):
    with path.open('x', encoding='utf-8') as f: json.dump(value, f, indent=2, allow_nan=False)


def paired(new, baseline):
    """Compare exactly the same scored target IDs; expose losses of coverage."""
    if new['dataset_sha256'] != baseline['dataset_sha256'] or new['target'] != baseline['target']:
        raise ValueError('PAIRED_DATASET_AND_TARGET_REQUIRED')
    a = {r['sample_id']:r for r in baseline['rows']}; b = {r['sample_id']:r for r in new['rows']}
    ids = sorted(a.keys() & b.keys()); rows = []
    for sid in ids:
        if (a[sid]['observed'], a[sid]['match_id'], a[sid]['numeric_stratum']) != (
                b[sid]['observed'], b[sid]['match_id'], b[sid]['numeric_stratum']):
            raise ValueError('PAIRED_OBSERVATION_OR_SCOPE_CHANGED')
        old_error = abs(a[sid]['point']-a[sid]['observed']); new_error = abs(b[sid]['point']-b[sid]['observed'])
        rows.append(dict(sample_id=sid, match_id=a[sid]['match_id'], observed=a[sid]['observed'],
            baseline_point=a[sid]['point'], conditional_point=b[sid]['point'],
            baseline_absolute_error=old_error, conditional_absolute_error=new_error,
            verdict='IMPROVED' if new_error < old_error else 'WORSENED' if new_error > old_error else 'TIED'))
    return dict(common_targets=len(ids), baseline_common_metrics=_metrics([a[s] for s in ids]),
        conditional_common_metrics=_metrics([b[s] for s in ids]),
        verdicts=dict(Counter(r['verdict'] for r in rows)), rows=rows,
        conditional_only_ids=sorted(b.keys()-a.keys()), baseline_only_ids=sorted(a.keys()-b.keys()),
        comparison_scope='SAME_RECORDED_TARGETS_ONLY_NOT_COUNTERFACTUAL_MOVE_QUALITY_OR_DEPLOYMENT')


def _path(name):
    p = Path(name); p = p if p.is_absolute() else ROOT/p
    if not p.resolve().is_relative_to(ROOT): raise ValueError('INPUT_INSIDE_V2_REQUIRED')
    return p


def run_cohort(entry, output):
    dataset_path = _path(entry['dataset_path']); plan_path = _path(entry['baseline_plan_path'])
    if sha(dataset_path) != entry['dataset_file_sha256'] or sha(plan_path) != entry['baseline_plan_sha256']:
        raise ValueError('PINNED_DATASET_OR_BASELINE_PLAN_CHANGED')
    for name, expected in entry['baseline_pins'].items():
        if sha(_path(name)) != expected: raise ValueError('BASELINE_ARTIFACT_CHANGED')
    dataset = validate_dataset(read_json(dataset_path)); base_plan = read_json(plan_path)
    if dataset['dataset_sha256'] != base_plan['dataset_sha256']: raise ValueError('BASELINE_DATASET_MISMATCH')
    folds = []; seen = Counter()
    for fold in base_plan['folds']:
        plan = dict(dataset_sha256=dataset['dataset_sha256'], matches=fold['matches'], independent_holdout=False)
        parts = partitions_for(dataset, plan)
        if set(parts.values()) != {'TRAIN','VALIDATION'}: raise ValueError('EXACT_TRAIN_VALIDATION_FOLDS_REQUIRED')
        if not fold['id'].replace('_','').isalnum(): raise ValueError('BOUNDED_FOLD_ID_REQUIRED')
        folds.append((fold['id'], plan)); seen.update(m for m, p in parts.items() if p == 'VALIDATION')
    if len(set(f[0] for f in folds)) != len(folds) or seen != {s['match_id']:1 for s in dataset['samples']}:
        raise ValueError('EACH_MATCH_EXACTLY_ONCE_IN_VALIDATION')
    output.mkdir(); all_predictions = {m:[] for m in POLICY['modes']}; model_pins = {}; fold_summaries = []
    for name, plan in folds:
        folder = output/name; folder.mkdir()
        model = fit_exploratory(dataset, plan, allow_uncalibrated_component_experiment=True)
        write(folder/'model.json', model); model_pins[name] = sha(folder/'model.json')
        held = [s for s in dataset['samples'] if plan['matches'][s['match_id']] == 'VALIDATION']
        if set(s['match_id'] for s in held) & set(model['training_match_ids']): raise ValueError('TRAIN_VALIDATION_OVERLAP')
        requests = [dict(request=prediction_request(s), scope_id=numeric_stratum(s)) for s in held]
        write(folder/'pre_input_requests.json', requests); modes = {}
        for mode in POLICY['modes']:
            forecasts = []; diagnostics = []
            for item in requests:
                result, diagnostic = predict(model, item['request'], scope_id=item['scope_id'], mode=mode)
                forecasts.append(result); diagnostics.append(dict(sample_id=item['request']['sample_id'], **diagnostic))
            predictions = dict(schema=PREDICTION_SCHEMA, dataset_sha256=dataset['dataset_sha256'],
                model_id=model['model_sha256']+':'+mode, target=TARGET, predictions=forecasts)
            write(folder/(mode+'_predictions.json'), predictions); write(folder/(mode+'_diagnostics.json'), diagnostics)
            write(folder/(mode+'_before_scoring.json'), dict(model_sha256=model_pins[name],
                predictions_sha256=sha(folder/(mode+'_predictions.json')),
                requests_sha256=sha(folder/'pre_input_requests.json'), already_seen_data=True,
                independent_holdout=False, prospective_prediction_provenance_verified=False))
            evaluation = evaluate(dataset, predictions, plan)
            write(folder/(mode+'_evaluation.json'), evaluation); all_predictions[mode].extend(forecasts)
            modes[mode] = dict(scored=evaluation['scored'], metrics=evaluation['metrics'],
                abstentions=dict(Counter(p['abstention_reason'] for p in forecasts if p['point'] is None)))
        fold_summaries.append(dict(fold=name, training_matches=model['training_match_ids'],
            validation_matches=sorted({s['match_id'] for s in held}), training_summary=model['training_summary'], modes=modes))
    combined_plan = dict(dataset_sha256=dataset['dataset_sha256'],
        matches={s['match_id']:'VALIDATION' for s in dataset['samples']}, independent_holdout=False)
    summaries = {}; base_dir = _path(entry['baseline_directory'])
    for mode, forecasts in all_predictions.items():
        if len({p['sample_id'] for p in forecasts}) != len(dataset['samples']): raise ValueError('OUT_OF_FOLD_COVERAGE')
        artifact = dict(schema=PREDICTION_SCHEMA, dataset_sha256=dataset['dataset_sha256'],
            model_id='CONDITIONAL_LOMO_'+mode+'_'+sha(output/folds[0][0]/'model.json'), target=TARGET, predictions=forecasts)
        write(output/(mode+'_out_of_fold_predictions.json'), artifact)
        evaluation = evaluate(dataset, artifact, combined_plan)
        write(output/(mode+'_out_of_fold_evaluation.json'), evaluation)
        frozen_base = read_json(base_dir/(mode+'_out_of_fold_evaluation.json'))
        recomputed_base = evaluate(dataset, read_json(base_dir/(mode+'_out_of_fold_predictions.json')), combined_plan)
        if frozen_base != recomputed_base: raise ValueError('FROZEN_BASELINE_EVALUATION_NOT_REPRODUCIBLE')
        comparison = paired(evaluation, frozen_base); write(output/(mode+'_paired.json'), comparison)
        summaries[mode] = dict(scored=evaluation['scored'], recorded_targets=evaluation['data_readiness'].get('RECORDED_COMPONENT',0),
            coverage=evaluation['coverage_of_recorded_component_targets'], metrics=evaluation['metrics'],
            abstentions=dict(Counter(p['abstention_reason'] for p in forecasts if p['point'] is None)),
            baseline_scored=frozen_base['scored'], paired={k:v for k,v in comparison.items() if k != 'rows'})
    if sha(dataset_path) != entry['dataset_file_sha256']: raise ValueError('DATASET_CHANGED_DURING_FIT')
    result = dict(cohort_id=entry['cohort_id'], dataset_sha256=dataset['dataset_sha256'], models_fitted=len(folds),
        actions=len(dataset['samples']), matches=len(combined_plan['matches']), folds=fold_summaries,
        modes=summaries, model_pins=model_pins, calibration_eligible=False, deployment_eligible=False)
    write(output/'summary.json', result)
    return result


def run(plan_path, output):
    plan_path = Path(plan_path).resolve(); output = Path(output).resolve()
    if not output.is_relative_to(ROOT) or output.exists(): raise ValueError('FRESH_OUTPUT_INSIDE_V2_REQUIRED')
    plan = read_json(plan_path); policy_path = plan_path.parent/'policy_frozen.json'
    if (plan.get('schema') != 'pokiguard.conditional_damage_experiment.v1' or plan.get('policy') != POLICY
            or sha(policy_path) != plan.get('policy_file_sha256') or read_json(policy_path)['policy'] != POLICY
            or plan.get('data_already_examined') is not True or plan.get('independent_holdout') is not False
            or plan.get('hyperparameter_search') is not False or plan.get('live_inputs') is not False
            or type(plan.get('experiments')) is not list or not 1 <= len(plan['experiments']) <= 32):
        raise ValueError('FROZEN_EXPLORATORY_EXPERIMENT_REQUIRED')
    ids = [e['id'] for e in plan['experiments']]
    if len(set(ids)) != len(ids) or any(not i.replace('_','').isalnum() for i in ids):
        raise ValueError('UNIQUE_SAFE_EXPERIMENT_IDS_REQUIRED')
    source = source_fingerprint(ROOT); output.mkdir(); write(output/'frozen_plan.json', plan)
    results = []
    for entry in plan['experiments']:
        result = run_cohort(entry, output/entry['id']); results.append(result)
        print(json.dumps(dict(cohort=entry['cohort_id'], models=result['models_fitted'],
            scored={mode:value['scored'] for mode,value in result['modes'].items()})), flush=True)
    if source_fingerprint(ROOT) != source: raise ValueError('SOURCE_CHANGED_DURING_EXPERIMENT')
    result = dict(status='COMPLETED_EXPLORATORY_CONDITIONAL_MODEL_NOT_DEPLOYMENT', source_sha256=source,
        experiment_plan_sha256=sha(plan_path), policy=POLICY, cohorts=results,
        models_fitted=sum(r['models_fitted'] for r in results), matches=sum(r['matches'] for r in results),
        recorded_targets=sum(r['modes']['reference']['recorded_targets'] for r in results),
        scored_counts={m:sum(r['modes'][m]['scored'] for r in results) for m in POLICY['modes']},
        baseline_scored_counts={m:sum(r['modes'][m]['baseline_scored'] for r in results) for m in POLICY['modes']},
        pooled_metrics=None, quality_scope='PER_COHORT_PAIRED_RECORDED_COMPONENTS_NOT_INDEPENDENT_HOLDOUT',
        hyperparameter_search=False, independent_holdout=False, model_deployed=False, gameplay_changed=False,
        new_live_attempts=0, new_game_inputs=0, process_attachment=False, build=False)
    write(output/'summary.json', result)
    return result


def main():
    p = argparse.ArgumentParser(__doc__); p.add_argument('--plan', type=Path, required=True); p.add_argument('--out-dir', type=Path, required=True)
    args = p.parse_args(); result = run(args.plan, args.out_dir)
    print(json.dumps({k:v for k,v in result.items() if k not in ('cohorts','policy')}))


if __name__ == '__main__': main()
