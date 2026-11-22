"""Exploratory offline component baseline. Never imported by gameplay.

Ratios describe recorded components, not server damage, kill chances or
calibrated prediction intervals. Every fitted artifact remains nondeployable.
"""
from collections import Counter,defaultdict
from copy import deepcopy
from statistics import median

from .damage_evaluation import (TARGET,digest,number,validate_features,input_complete,
    partitions_for,prediction_request,numeric_stratum)

SCHEMA='pokiguard.exploratory_damage_baseline.v1'
POLICY=dict(algorithm='MEDIAN_RECORDED_COMPONENT_PER_FIRST_WAVE_EFFECTIVE_SWORD',minimum_group_samples=3,
    domain_features=['effective_swords','pre_power','boss_shield'],
    interval='EMPIRICAL_TRAINING_RATIO_MIN_MAX_NOT_COVERAGE_GUARANTEE',
    grouping='EXACT_NUMERIC_STRATUM_AND_DIRECT_VS_DECLARED_PASSIVE',modes=['reference','guarded'])


def _hash(v):
    return type(v) is str and len(v)==64 and all(c in '0123456789abcdef' for c in v)


def _domain(f):
    return dict(effective_swords=f['first_wave']['effective']['sword'],
        pre_power=f['self_stats']['power'],boss_shield=f['boss_stats']['shield'])


def _regime(f):
    return 'DECLARED_PASSIVE_FIRST_WAVE' if f['first_wave']['passive_triggered'] else 'DIRECT_FIRST_WAVE'


def fit_exploratory(dataset,plan,*,allow_uncalibrated_component_experiment=False):
    """Use TRAIN labels only; keep all original calibration flags unchanged."""
    if allow_uncalibrated_component_experiment is not True:
        raise ValueError('EXPLICIT_OFFLINE_COMPONENT_EXPERIMENT_REQUIRED')
    parts=partitions_for(dataset,plan)
    training=[s for s in dataset['samples'] if parts[s['match_id']]=='TRAIN']
    if not training or not any(v=='VALIDATION' for v in parts.values()):
        raise ValueError('SEPARATE_TRAIN_AND_VALIDATION_MATCHES_REQUIRED')
    grouped=defaultdict(list);skips=Counter();payload=[]
    for s in training:
        request=prediction_request(s);f=request['features']
        if s['execution_status']!='ACKNOWLEDGED':skips['NO_EXACT_ACK']+=1;continue
        if not input_complete(f):skips['INCOMPLETE_PRE_INPUT']+=1;continue
        label=s['target_observation']
        if label.get('kind')!=TARGET:raise ValueError('RECORDED_COMPONENT_TARGET_REQUIRED')
        if label['status']!='RECORDED_COMPONENT':skips[label['status']]+=1;continue
        if not number(label['amount']):raise ValueError('FINITE_RECORDED_COMPONENT_REQUIRED')
        d=_domain(f)
        if not d['effective_swords']:skips['NO_KNOWN_FIRST_WAVE_SWORDS']+=1;continue
        sid=numeric_stratum(s);regime=_regime(f)
        row=dict(sample_id=s['sample_id'],feature_sha256=s['feature_sha256'],scope_id=sid,regime=regime,
            domain=d,amount=label['amount'],ratio=label['amount']/d['effective_swords'])
        grouped[sid,regime].append(row);payload.append(row)
    groups=[]
    for (sid,regime),rows in sorted(grouped.items()):
        ratios=[r['ratio'] for r in rows]
        groups.append(dict(scope_id=sid,regime=regime,n=len(rows),ratio_median=median(ratios),
            ratio_min=min(ratios),ratio_max=max(ratios),
            domain={k:dict(low=min(r['domain'][k] for r in rows),high=max(r['domain'][k] for r in rows)) for k in POLICY['domain_features']},
            sample_ids=sorted(r['sample_id'] for r in rows)))
    model=dict(schema=SCHEMA,target=TARGET,dataset_sha256=dataset['dataset_sha256'],policy=deepcopy(POLICY),
        training_match_ids=sorted({s['match_id'] for s in training}),
        training_action_ids=sorted(s['sample_id'] for s in training),training_payload_sha256=digest(sorted(payload,key=lambda r:r['sample_id'])),
        parameters=groups,training_summary=dict(actions=len(training),component_samples=len(payload),skipped=dict(skips)),
        fitting_scope='EXPLORATORY_RECORDED_COMPONENT_ONLY_NOT_APPROVED_CALIBRATION',
        calibration_eligible=False,deployment_eligible=False,input_authority=False)
    model['model_sha256']=digest(model)
    return model


def validate_model(model):
    if (type(model) is not dict or model.get('schema')!=SCHEMA or model.get('target')!=TARGET
            or model.get('policy')!=POLICY or not _hash(model.get('dataset_sha256'))
            or model.get('model_sha256')!=digest({k:v for k,v in model.items() if k!='model_sha256'})
            or any(model.get(k) is not False for k in ('calibration_eligible','deployment_eligible','input_authority'))
            or type(model.get('parameters')) is not list or len(model['parameters'])>1024):
        raise ValueError('EXPLORATORY_MODEL_IDENTITY_OR_SCOPE')
    seen=set()
    for g in model['parameters']:
        key=g['scope_id'],g['regime']
        if (key in seen or not _hash(g['scope_id']) or g['regime'] not in ('DIRECT_FIRST_WAVE','DECLARED_PASSIVE_FIRST_WAVE')
                or type(g['n']) is not int or not 1<=g['n']<=100000 or len(g['sample_ids'])!=g['n']
                or len(set(g['sample_ids']))!=g['n'] or not set(g['sample_ids'])<=set(model['training_action_ids'])
                or any(not number(g[k]) for k in ('ratio_median','ratio_min','ratio_max'))
                or not g['ratio_min']<=g['ratio_median']<=g['ratio_max'] or set(g['domain'])!=set(POLICY['domain_features'])):
            raise ValueError('EXPLORATORY_MODEL_PARAMETERS')
        seen.add(key)
        for d in g['domain'].values():
            if type(d) is not dict or set(d)!={'low','high'} or not number(d['low']) or not number(d['high']) or d['low']>d['high']:
                raise ValueError('EXPLORATORY_MODEL_SUPPORT')
    return model


def predict(model,request,*,scope_id,mode='guarded'):
    """No observation labels accepted. Scope is a setup gate, not a feature."""
    validate_model(model)
    if (type(request) is not dict or set(request)!={'sample_id','feature_sha256','features','input_complete','target'}
            or request['target']!=TARGET or not _hash(request['sample_id']) or not _hash(request['feature_sha256'])
            or not _hash(scope_id) or mode not in POLICY['modes']):
        raise ValueError('PRE_INPUT_REQUEST_OR_MODE')
    f=validate_features(request['features'])
    if digest(f)!=request['feature_sha256'] or request['input_complete'] is not input_complete(f):
        raise ValueError('PRE_INPUT_FEATURE_IDENTITY')
    result=dict(sample_id=request['sample_id'],feature_sha256=request['feature_sha256'],point=None,lower=None,upper=None,abstention_reason=None)
    diagnostic=dict(mode=mode,model_sha256=model['model_sha256'],scope_id=scope_id,
        interval_semantics=POLICY['interval'],outside_training_domain=[],calibration_eligible=False,
        deployment_eligible=False,input_authority=False)
    def abstain(reason):
        result['abstention_reason']=reason
        return result,dict(diagnostic,status='ABSTAINED',reason=reason)
    if request['sample_id'] in model['training_action_ids']:return abstain('IN_SAMPLE_REQUEST_NOT_VALIDATION')
    if not input_complete(f):return abstain('INCOMPLETE_PRE_INPUT')
    d=_domain(f)
    if not d['effective_swords']:return abstain('NO_KNOWN_FIRST_WAVE_SWORDS')
    groups=[g for g in model['parameters'] if g['scope_id']==scope_id and g['regime']==_regime(f)]
    if not groups:return abstain('UNSEEN_SCOPE_OR_REGIME')
    g=groups[0];diagnostic['training_samples']=g['n']
    if g['n']<POLICY['minimum_group_samples']:return abstain('INSUFFICIENT_TRAINING_COMPONENTS')
    outside=[k for k in POLICY['domain_features'] if not g['domain'][k]['low']<=d[k]<=g['domain'][k]['high']]
    diagnostic['outside_training_domain']=outside
    if mode=='guarded' and outside:return abstain('OUTSIDE_TRAINING_DOMAIN')
    p=d['effective_swords']
    forecast=dict(point=g['ratio_median']*p,lower=g['ratio_min']*p,upper=g['ratio_max']*p)
    if any(not number(v) for v in forecast.values()):return abstain('FORECAST_NUMERIC_BOUND')
    result.update(**forecast)
    return result,dict(diagnostic,status='EXPLORATORY_FORECAST',reason='EMPIRICAL_COMPONENT_REFERENCE_ONLY',domain_guard_applied=mode=='guarded')
