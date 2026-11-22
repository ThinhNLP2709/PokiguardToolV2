"""Offline raw component distribution at exact known Sword counts.

Unknown refill, crit and resource order remain latent outcome variation. A
recorded whole-response component is never divided into a known-sword causal
coefficient. This model has no gameplay, input or calibrated-kill authority.
"""
from collections import Counter,defaultdict
from copy import deepcopy
import math
from .damage_conditional import _context
from .damage_evaluation import TARGET,digest,number,partitions_for,prediction_request,numeric_stratum

SCHEMA='pokiguard.exploratory_conditional_damage.v2'
POLICY=dict(algorithm='EXACT_KNOWN_SWORD_VECTOR_RAW_COMPONENT_NEIGHBORS',version=2,
    minimum_unique_training_boards=3,neighbors=3,include_all_kth_distance_ties=True,maximum_group_rows=512,
    grouping='EXACT_NUMERIC_STRATUM_AND_SWEEP_DIRECT_CASCADE_SWORD_COUNTS',
    context_features=['sweep_swords','direct_swords','cascade_swords','own_power_fill','first_wave_rage',
        'later_known_rage','known_drain','boss_power_fill','boss_mana_fill','own_mana_fill','boss_shield','unknown_refill_cells','known_residual'],
    context_scaling='TRAINING_RANGE_OR_ONE_FOR_CONSTANT_DIMENSION',distance='ROOT_MEAN_SQUARED_SCALED_DIFFERENCE',
    weight='ONE_OVER_ONE_PLUS_DISTANCE_SQUARED',point='LOCAL_WEIGHTED_MEDIAN_RECORDED_COMPONENT_AMOUNT_NO_SWORD_RESCALE',
    interval='LOCAL_RAW_COMPONENT_MIN_MAX_NOT_CALIBRATED_PREDICTION_INTERVAL',
    duplicate_board_weight='NEAREST_CONTEXT_PER_DISTINCT_TRAINING_BOARD',
    joint_guard='DISTANCE_TO_NEAREST_TRAINING_CONTEXT_NOT_ABOVE_MAX_DISTINCT_BOARD_LOO_NEAREST_DISTANCE',
    modes=['reference','guarded'],unknown_later_passive='ABSTAIN',
    latent_effects=['CRIT','UNKNOWN_REFILL','RESOURCE_ORDER','UNOBSERVED_BUFFS'],post_response_features=False,
    exclude_training_rows_by_post_crit_or_post_sword_tags=False,full_power_threshold=None,rage_gain_per_gem=None,per_sword_coefficient=None,
    validation='ALREADY_SEEN_RETROSPECTIVE_MATCH_FOLDS_NOT_INDEPENDENT_HOLDOUT')

def _hash(v):return type(v) is str and len(v)==64 and all(c in '0123456789abcdef' for c in v)
def _distance(a,b,domain):
    return math.sqrt(math.fsum(((x-y)/(d['high']-d['low'] or 1))**2 for x,y,d in zip(a,b,domain,strict=True))/len(domain))
def _group(scope,counts,rows):
    domain=[dict(low=min(r['vector'][i] for r in rows),high=max(r['vector'][i] for r in rows)) for i in range(len(POLICY['context_features']))]
    unique=len({r['board_sha256'] for r in rows})
    radius=(max(min(_distance(a['vector'],b['vector'],domain) for b in rows if b['board_sha256']!=a['board_sha256']) for a in rows) if unique>1 else 0.)
    return dict(scope_id=scope,sword_counts=list(counts),rows=rows,unique_training_boards=unique,domain=domain,joint_radius=radius)

def fit_exploratory(dataset,plan,*,allow_uncalibrated_component_experiment=False):
    if allow_uncalibrated_component_experiment is not True:raise ValueError('EXPLICIT_OFFLINE_COMPONENT_EXPERIMENT_REQUIRED')
    parts=partitions_for(dataset,plan);training=[s for s in dataset['samples'] if parts[s['match_id']]=='TRAIN']
    if not training or 'VALIDATION' not in parts.values():raise ValueError('SEPARATE_TRAIN_AND_VALIDATION_MATCHES_REQUIRED')
    groups=defaultdict(list);skipped=Counter();payload=[]
    for s in training:
        request=prediction_request(s)
        if s['execution_status']!='ACKNOWLEDGED':skipped['NO_EXACT_ACK']+=1;continue
        label=s['target_observation']
        if label.get('kind')!=TARGET:raise ValueError('RECORDED_COMPONENT_TARGET_REQUIRED')
        if label['status']!='RECORDED_COMPONENT':skipped[label['status']]+=1;continue
        if not number(label['amount']):raise ValueError('FINITE_COMPONENT_REQUIRED')
        context,reason=_context(request)
        if context is None:skipped[reason]+=1;continue
        scope=numeric_stratum(s);counts=tuple(context['vector'][:3])
        row=dict(sample_id=s['sample_id'],feature_sha256=s['feature_sha256'],board_sha256=context['board_sha256'],
            vector=context['vector'],amount=label['amount'])
        groups[scope,counts].append(row);payload.append(dict(scope_id=scope,sword_counts=list(counts),**row))
        if len(groups[scope,counts])>POLICY['maximum_group_rows']:raise ValueError('COMPONENT_GROUP_ROW_LIMIT')
    parameters=[_group(scope,counts,sorted(rows,key=lambda r:r['sample_id'])) for (scope,counts),rows in sorted(groups.items())]
    model=dict(schema=SCHEMA,target=TARGET,policy=deepcopy(POLICY),dataset_sha256=dataset['dataset_sha256'],
        training_match_ids=sorted({s['match_id'] for s in training}),training_action_ids=sorted(s['sample_id'] for s in training),
        training_board_sha256s=sorted({digest(s['features']['board']) for s in training if s['features']['board'] is not None}),
        training_payload_sha256=digest(sorted(payload,key=lambda r:r['sample_id'])),parameters=parameters,
        training_summary=dict(actions=len(training),component_samples=len(payload),skipped=dict(skipped)),
        fitting_scope='EXPLORATORY_RECORDED_COMPONENT_DISTRIBUTION_NOT_CAUSAL_DAMAGE_OR_KILL',
        calibration_eligible=False,deployment_eligible=False,input_authority=False)
    model['model_sha256']=digest(model);return model

def validate_model(model):
    if (type(model) is not dict or model.get('schema')!=SCHEMA or model.get('target')!=TARGET or model.get('policy')!=POLICY
            or not _hash(model.get('dataset_sha256')) or model.get('model_sha256')!=digest({k:v for k,v in model.items() if k!='model_sha256'})
            or any(model.get(k) is not False for k in ('calibration_eligible','deployment_eligible','input_authority'))
            or type(model.get('parameters')) is not list or len(model['parameters'])>1024
            or any(type(model.get(k)) is not list or len(model[k])>100000 or any(not _hash(v) for v in model[k]) for k in ('training_action_ids','training_board_sha256s'))):
        raise ValueError('COMPONENT_MODEL_IDENTITY_OR_SCOPE')
    seen=set();samples=set()
    for g in model['parameters']:
        counts=g.get('sword_counts') if type(g) is dict else None
        if (type(g) is not dict or not _hash(g.get('scope_id')) or type(counts) is not list or len(counts)!=3
                or any(type(n) is not int or not 0<=n<=2**31-1 for n in counts) or not sum(counts)
                or type(g.get('rows')) is not list or not 1<=len(g['rows'])<=POLICY['maximum_group_rows']):
            raise ValueError('COMPONENT_GROUP_SHAPE')
        key=g['scope_id'],tuple(counts)
        if key in seen:raise ValueError('DUPLICATE_COMPONENT_GROUP')
        seen.add(key)
        for r in g['rows']:
            if (type(r) is not dict or set(r)!={'sample_id','feature_sha256','board_sha256','vector','amount'}
                    or not _hash(r.get('sample_id')) or r['sample_id'] in samples or r['sample_id'] not in model['training_action_ids']
                    or not _hash(r.get('feature_sha256')) or not _hash(r.get('board_sha256')) or r['board_sha256'] not in model['training_board_sha256s']
                    or type(r.get('vector')) is not list or len(r['vector'])!=len(POLICY['context_features'])
                    or not all(number(v) for v in r['vector']) or any(type(v) is not int for v in r['vector'][:3])
                    or r['vector'][:3]!=counts or not number(r.get('amount'))):
                raise ValueError('COMPONENT_TRAINING_ROW')
            samples.add(r['sample_id'])
        if _group(g['scope_id'],counts,g['rows'])!=g:raise ValueError('COMPONENT_SUPPORT_DERIVATION')
    return model

def predict(model,request,*,scope_id,mode='guarded'):
    validate_model(model)
    if not _hash(scope_id) or mode not in POLICY['modes']:raise ValueError('COMPONENT_SCOPE_OR_MODE')
    context,reason=_context(request)
    result=dict(sample_id=request['sample_id'],feature_sha256=request['feature_sha256'],point=None,lower=None,upper=None,abstention_reason=None)
    diag=dict(mode=mode,model_sha256=model['model_sha256'],scope_id=scope_id,interval_semantics=POLICY['interval'],
        latent_effects=deepcopy(POLICY['latent_effects']),outside_training_domain=[],per_sword_coefficient=None,
        sword_rescale_applied=False,whole_action_complete=False,full_power_prediction=None,critical_prediction=None,
        calibration_eligible=False,deployment_eligible=False,input_authority=False)
    def abstain(why):
        result['abstention_reason']=why;return result,dict(diag,status='ABSTAINED',reason=why)
    if request['sample_id'] in model['training_action_ids']:return abstain('IN_SAMPLE_REQUEST_NOT_VALIDATION')
    if context is None:return abstain(reason)
    if context['board_sha256'] in model['training_board_sha256s']:return abstain('TRAINING_BOARD_NOT_VALIDATION')
    counts=context['vector'][:3]
    groups=[g for g in model['parameters'] if g['scope_id']==scope_id and g['sword_counts']==counts]
    if not groups:return abstain('UNSEEN_SCOPE_OR_SWORD_VECTOR')
    g=groups[0];diag.update(training_rows=len(g['rows']),unique_training_boards=g['unique_training_boards'],sword_counts=counts)
    if g['unique_training_boards']<POLICY['minimum_unique_training_boards']:return abstain('INSUFFICIENT_UNIQUE_TRAINING_BOARDS')
    # One board cannot dominate the empirical distribution via repeated moves.
    by_board={}
    for row in g['rows']:
        candidate=(_distance(context['vector'],row['vector'],g['domain']),row['sample_id'],row)
        key=row['board_sha256']
        if key not in by_board or candidate[:2]<by_board[key][:2]:by_board[key]=candidate
    distances=sorted(by_board.values());nearest=distances[0][0]
    outside=[name for name,value,d in zip(POLICY['context_features'],context['vector'],g['domain'],strict=True) if not d['low']<=value<=d['high']]
    diag.update(outside_training_domain=outside,nearest_distance=nearest,joint_radius=g['joint_radius'],joint_context_outside=nearest>g['joint_radius'])
    if mode=='guarded' and outside:return abstain('OUTSIDE_TRAINING_CONTEXT')
    if mode=='guarded' and nearest>g['joint_radius']:return abstain('JOINT_CONTEXT_UNSUPPORTED')
    cutoff=distances[min(POLICY['neighbors'],len(distances))-1][0]
    neighbors=[(r['amount'],1/(1+d*d),sid,d) for d,sid,r in distances if d<=cutoff]
    total=math.fsum(n[1] for n in neighbors);running=0.;point=None
    for value,weight,_,_ in sorted(neighbors):
        running+=weight
        if running>=total/2:point=value;break
    result.update(point=point,lower=min(n[0] for n in neighbors),upper=max(n[0] for n in neighbors))
    diag.update(neighbors=len(neighbors),neighbor_sample_ids=[n[2] for n in neighbors],neighbor_distances=[n[3] for n in neighbors],
        effective_neighbor_count=total**2/math.fsum(n[1]**2 for n in neighbors),domain_guard_applied=mode=='guarded')
    return result,dict(diag,status='EXPLORATORY_FORECAST',reason='RAW_COMPONENT_DISTRIBUTION_REFERENCE_ONLY')
