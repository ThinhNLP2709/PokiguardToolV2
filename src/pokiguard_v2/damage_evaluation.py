"""Offline recorded-component benchmark contract, with no game/model authority.

Predictions see pre-input fields only. Missing effects and HP-zero cases never
become zero/exact damage targets. No fitting, process access or input path.
"""
from collections import Counter, defaultdict
from copy import deepcopy
import hashlib
import json
import math
from .state import SUPPORTED_CELL_MULTIPLIERS

DATASET_SCHEMA = 'pokiguard.pre_action_damage_dataset.v1'
FEATURE_SCHEMA = 'pokiguard.pre_action_damage_features.v1'
PREDICTION_SCHEMA = 'pokiguard.damage_component_predictions.v1'
TARGET = 'RECORDED_LOCAL_TO_BOSS_DAMAGE_COMPONENT_SUM'
STATS = frozenset(('hp','max_hp','mana','max_mana','power','max_power','attack','shield'))
SETTINGS = frozenset(('play_style','main_pet','evolution_target','damage_card','demon_target_gem'))
FEATURE_KEYS = frozenset(('schema','board','move','self_stats','boss_stats','settings','first_wave'))
PARTITIONS = frozenset(('DEVELOPMENT','TRAIN','VALIDATION','TEST'))
GEMS = frozenset(('sword','health','mana','drain','shield','rage'))


def canonical(v):
    return json.dumps(v,sort_keys=True,ensure_ascii=True,separators=(',',':'),allow_nan=False)


def digest(v): return hashlib.sha256(canonical(v).encode()).hexdigest()


def number(v): return type(v) in (int,float) and 0 <= v <= 10**15 and math.isfinite(v)


def validate_features(f):
    if type(f) is not dict or set(f)!=FEATURE_KEYS or f['schema']!=FEATURE_SCHEMA:
        raise ValueError('PRE_INPUT_FEATURE_SCHEMA')
    for key in ('self_stats','boss_stats'):
        v=f[key]
        if v is not None and (type(v) is not dict or set(v)!=STATS or any(
                x is not None and (type(x) is not int or not 0<=x<=2**31-1) for x in v.values())):
            raise ValueError('PRE_INPUT_STATS_FIELDS')
    if type(f['settings']) is not dict or set(f['settings'])!=SETTINGS or any(
            v is not None and (type(v) is not str or len(v)>64) for v in f['settings'].values()):
        raise ValueError('PRE_INPUT_SETTINGS_FIELDS')
    b=f['board']
    if b is not None and (type(b) is not list or len(b)!=8 or any(type(r) is not list or len(r)!=8 or any(
            type(c) is not list or len(c)!=2 or c[0] not in GEMS or type(c[1]) is not int or c[1] not in SUPPORTED_CELL_MULTIPLIERS
            for c in r) for r in b)):
        raise ValueError('PRE_INPUT_BOARD_FIELDS')
    m=f['move']
    if (type(m) is not list or len(m)!=2 or any(type(p) is not list or len(p)!=2 or any(
            type(v) is not int or not 0<=v<8 for v in p) for p in m) or sum(abs(a-b) for a,b in zip(*m))!=1):
        raise ValueError('PRE_INPUT_MOVE_FIELDS')
    w=f['first_wave']
    if type(w) is not dict or w.get('status') not in ('KNOWN','UNKNOWN'):
        raise ValueError('PRE_INPUT_WAVE_FIELDS')
    if w['status']=='UNKNOWN':
        if set(w)!={'status','reason'} or type(w['reason']) is not str or len(w['reason'])>96:
            raise ValueError('PRE_INPUT_UNKNOWN_WAVE')
    else:
        if (set(w)!={'status','passive_triggered','physical','effective','scope'}
                or type(w['passive_triggered']) is not bool or w['scope']!='FIRST_WAVE_ONLY_NO_REFILL_OR_CASCADE'):
            raise ValueError('PRE_INPUT_WAVE_SCOPE')
        for key in ('physical','effective'):
            if type(w[key]) is not dict or set(w[key])!=GEMS or any(type(n) is not int or not 0<=n<=64*max(SUPPORTED_CELL_MULTIPLIERS) for n in w[key].values()):
                raise ValueError('PRE_INPUT_RESOURCE_FIELDS')
        if (sum(w['physical'].values())>64 or any(not w['physical'][g]<=w['effective'][g]<=max(SUPPORTED_CELL_MULTIPLIERS)*w['physical'][g] for g in GEMS)):
            raise ValueError('PRE_INPUT_RESOURCE_BOUNDS')
    return f


def input_complete(f):
    validate_features(f)
    return (f['board'] is not None and f['first_wave']['status']=='KNOWN'
        and all(f[k] is not None and all(v is not None for v in f[k].values()) for k in ('self_stats','boss_stats')))


def prediction_request(sample):
    """The entire model-facing contract: no labels, wire flags or post context."""
    f=validate_features(sample['features'])
    if digest(f)!=sample['feature_sha256']: raise ValueError('FEATURE_HASH_MISMATCH')
    return dict(sample_id=sample['sample_id'],feature_sha256=sample['feature_sha256'],
        features=deepcopy(f),input_complete=input_complete(f),target=TARGET)


def dataset_identity(dataset):
    return digest({k:v for k,v in dataset.items() if k!='dataset_sha256'})


def validate_dataset(dataset):
    if (type(dataset) is not dict or dataset.get('schema')!=DATASET_SCHEMA
            or dataset.get('target')!=TARGET or dataset.get('dataset_sha256')!=dataset_identity(dataset)
            or type(dataset.get('samples')) is not list or len(dataset['samples'])>100000
            or dataset.get('input_authority') is not False or dataset.get('training_eligible') is not False):
        raise ValueError('DATASET_IDENTITY_OR_SCOPE')
    seen=set()
    for s in dataset['samples']:
        if s['sample_id'] in seen: raise ValueError('DUPLICATE_DATASET_SAMPLE')
        seen.add(s['sample_id']);prediction_request(s)
    return dataset


def partitions_for(dataset,plan):
    validate_dataset(dataset)
    matches={s['match_id'] for s in dataset['samples']}
    if (type(plan) is not dict or set(plan)!={'dataset_sha256','matches','independent_holdout'}
            or plan['dataset_sha256']!=dataset['dataset_sha256'] or type(plan['matches']) is not dict
            or set(plan['matches'])!=matches or any(v not in PARTITIONS for v in plan['matches'].values())
            or type(plan['independent_holdout']) is not bool):
        raise ValueError('EXACT_MATCH_PARTITION_PLAN_REQUIRED')
    board_partitions=defaultdict(set)
    for s in dataset['samples']:
        part=plan['matches'][s['match_id']]
        if part=='TEST' and s['seen_in_research'] is not False:
            raise ValueError('ALREADY_SEEN_MATCH_IS_NOT_INDEPENDENT_HOLDOUT')
        # Even a different move on the same pre-input board cannot cross splits.
        if s['features']['board'] is not None:
            board_partitions[digest(s['features']['board'])].add(part)
    if any(len(v)>1 for v in board_partitions.values()):
        raise ValueError('PRE_INPUT_BOARD_LEAKAGE_ACROSS_PARTITIONS')
    if plan['independent_holdout'] and ('TEST' not in plan['matches'].values()
            or any(s['seen_in_research'] is not False for s in dataset['samples'] if plan['matches'][s['match_id']]=='TEST')):
        raise ValueError('INDEPENDENT_HOLDOUT_NOT_ESTABLISHED')
    return dict(plan['matches'])


def _metrics(rows):
    if not rows:return dict(n=0,mae=None,rmse=None,mean_signed_error=None,p95_absolute_error=None,
        interval_coverage=None,mean_interval_width=None,overprediction_rate=None)
    errors=[r['point']-r['observed'] for r in rows];absolute=sorted(abs(e) for e in errors);n=len(rows)
    return dict(n=n,mae=sum(absolute)/n,rmse=math.sqrt(sum(e*e for e in errors)/n),
        mean_signed_error=sum(errors)/n,p95_absolute_error=absolute[max(0,math.ceil(.95*n)-1)],
        interval_coverage=sum(r['lower']<=r['observed']<=r['upper'] for r in rows)/n,
        mean_interval_width=sum(r['upper']-r['lower'] for r in rows)/n,overprediction_rate=sum(e>0 for e in errors)/n)


def numeric_stratum(sample):
    """Explicit build/account/settings/numeric signature, not a gear certificate."""
    f=sample['features'];scope=sample['scope']
    return digest(dict(game_build_sha256=scope['game_build_sha256'],source_sha256=scope['source_sha256'],
        account_sha256=scope['account_sha256'],cohort_id=sample['cohort_id'],settings=f['settings'],
        stats={who:None if f[who] is None else {k:f[who][k] for k in ('max_hp','max_mana','max_power','attack')}
            for who in ('self_stats','boss_stats')}))


def evaluate(dataset,predictions,plan):
    """Score externally supplied component predictions, never invent forecasts."""
    parts=partitions_for(dataset,plan)
    if (type(predictions) is not dict or set(predictions)!={'schema','dataset_sha256','model_id','target','predictions'}
            or predictions['schema']!=PREDICTION_SCHEMA or predictions['dataset_sha256']!=dataset['dataset_sha256']
            or predictions['target']!=TARGET or type(predictions['model_id']) is not str or not 0<len(predictions['model_id'])<=128
            or type(predictions['predictions']) is not list or len(predictions['predictions'])>100000):
        raise ValueError('PREDICTION_DATASET_OR_TARGET_MISMATCH')
    samples={s['sample_id']:s for s in dataset['samples']};seen=set();skipped=Counter();rows=[]
    for p in predictions['predictions']:
        if type(p) is not dict or set(p)!={'sample_id','feature_sha256','point','lower','upper','abstention_reason'}:
            raise ValueError('PREDICTION_FIELDS')
        sid=p['sample_id']
        if sid not in samples or sid in seen:raise ValueError('UNKNOWN_OR_DUPLICATE_PREDICTION_SAMPLE')
        seen.add(sid);s=samples[sid]
        if p['feature_sha256']!=s['feature_sha256']:raise ValueError('PREDICTION_FEATURE_MISMATCH')
        if p['point'] is None:
            if p['lower'] is not None or p['upper'] is not None or type(p['abstention_reason']) is not str or not 0<len(p['abstention_reason'])<=128:
                raise ValueError('ABSTENTION_FIELDS')
            skipped['MODEL_ABSTAINED']+=1;continue
        if (any(not number(p[k]) for k in ('point','lower','upper')) or not p['lower']<=p['point']<=p['upper']
                or p['abstention_reason'] is not None):raise ValueError('FINITE_ORDERED_NONNEGATIVE_PREDICTION_REQUIRED')
        label=s['target_observation']
        if s['execution_status']!='ACKNOWLEDGED':skipped['NO_EXACT_ACK']+=1;continue
        if not input_complete(s['features']):skipped['INCOMPLETE_PRE_INPUT_FEATURES']+=1;continue
        if label['status']!='RECORDED_COMPONENT':skipped[label['status']]+=1;continue
        if not number(label['amount']):raise ValueError('INVALID_COMPONENT_TARGET')
        rows.append(dict(sample_id=sid,match_id=s['match_id'],cohort_id=s['cohort_id'],partition=parts[s['match_id']],
            numeric_stratum=numeric_stratum(s),game_build_sha256=s['scope']['game_build_sha256'],
            regime='DECLARED_PASSIVE_FIRST_WAVE' if s['features']['first_wave']['passive_triggered'] else 'DIRECT_FIRST_WAVE',
            observed=label['amount'],point=p['point'],lower=p['lower'],upper=p['upper']))
    skipped['NO_PREDICTION_SUPPLIED']=len(samples)-len(seen)
    groups=defaultdict(list)
    for row in rows:groups[row['partition'],row['numeric_stratum'],row['regime']].append(row)
    by_match=defaultdict(list)
    for row in rows:by_match[row['match_id']].append(row)
    readiness=Counter('NO_EXACT_ACK' if s['execution_status']!='ACKNOWLEDGED' else
        'INCOMPLETE_PRE_INPUT_FEATURES' if not input_complete(s['features']) else s['target_observation']['status']
        for s in samples.values())
    return dict(scope='RETROSPECTIVE_RECORDED_COMPONENT_METRICS_NOT_WHOLE_ACTION_OR_KILL_VALIDATION',
        dataset_sha256=dataset['dataset_sha256'],model_id=predictions['model_id'],target=TARGET,
        total_actions=len(samples),acknowledged_actions=sum(s['execution_status']=='ACKNOWLEDGED' for s in samples.values()),
        supplied_predictions=len(seen),scored=len(rows),scored_matches=len({r['match_id'] for r in rows}),
        data_readiness=dict(readiness),coverage_of_recorded_component_targets=(len(rows)/readiness['RECORDED_COMPONENT'] if readiness['RECORDED_COMPONENT'] else None),
        skipped=dict(skipped),metrics=_metrics(rows),macro_match_mae=(sum(_metrics(v)['mae'] for v in by_match.values())/len(by_match) if by_match else None),
        groups=[dict(partition=p,numeric_stratum=c,regime=r,metrics=_metrics(v))
            for (p,c,r),v in sorted(groups.items())],rows=rows,
        grouping_scope='BUILD_ACCOUNT_SETTINGS_NUMERIC_STRATUM_NOT_COMPLETE_LOADOUT_CERTIFICATE',
        independent_holdout=False,independent_holdout_declared=plan['independent_holdout'],
        prospective_prediction_provenance_verified=False,
        training=False,models_fitted=0,calibration_eligible=False,deployment_eligible=False,input_authority=False)
