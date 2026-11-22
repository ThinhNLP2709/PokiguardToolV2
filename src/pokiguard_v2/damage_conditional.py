"""Offline empirical conditional component model, never a gameplay authority.

Learn local ratios from TRAIN damage labels using pre-input mechanisms only.
No FullPower/crit labels, resource conversion constants or server formula.
An abstention is a model result, not an input decision or controller stop.
"""
from collections import Counter, defaultdict
from copy import deepcopy
import math

from .damage_action_context import describe_action
from .damage_evaluation import (
    TARGET, digest, number, partitions_for, prediction_request, numeric_stratum,
)

SCHEMA = 'pokiguard.exploratory_conditional_damage.v1'
POLICY = dict(
    algorithm='PRE_INPUT_MECHANISM_CONDITIONAL_WEIGHTED_NEIGHBOR_RATIO', version=1,
    minimum_unique_training_boards=3, neighbors=3, include_all_kth_distance_ties=True,
    maximum_group_rows=512,
    grouping='EXACT_NUMERIC_STRATUM_AND_SWEEP_DIRECT_CASCADE_PRESENCE_SIGNATURE',
    context_features=['sweep_swords','direct_swords','cascade_swords','own_power_fill',
        'first_wave_rage','later_known_rage','known_drain','boss_power_fill','boss_mana_fill',
        'own_mana_fill','boss_shield','unknown_refill_cells','known_residual'],
    context_scaling='TRAINING_RANGE_OR_ONE_FOR_CONSTANT_DIMENSION',
    distance='ROOT_MEAN_SQUARED_SCALED_DIFFERENCE',
    weight='ONE_OVER_ONE_PLUS_DISTANCE_SQUARED',
    point='LOCAL_WEIGHTED_MEDIAN_COMPONENT_PER_KNOWN_PREFIX_SWORD',
    interval='LOCAL_EMPIRICAL_RATIO_MIN_MAX_NOT_CALIBRATED_PREDICTION_INTERVAL',
    joint_guard='DISTANCE_TO_NEAREST_TRAINING_CONTEXT_NOT_ABOVE_MAX_TRAIN_LOO_NEAREST_DISTANCE',
    modes=['reference','guarded'], unknown_later_passive='ABSTAIN',
    unknown_crit='NOT_A_FEATURE_OR_FALSE_LABEL', numerical_target=TARGET,
    full_power_threshold=None, rage_gain_per_gem=None,
    validation='ALREADY_SEEN_RETROSPECTIVE_MATCH_FOLDS_NOT_INDEPENDENT_HOLDOUT')


def _hash(value):
    return (type(value) is str and len(value) == 64
            and all(c in '0123456789abcdef' for c in value))


def _fill(current, maximum):
    if current == maximum == 0: return 0.
    if current is None or maximum is None or maximum <= 0: return None
    return current / maximum  # Retain observed over-cap ratios; do not clip/default.


def _context(request):
    descriptor = describe_action(request)
    if not request['input_complete']: return None, 'INCOMPLETE_PRE_INPUT'
    if descriptor['known_prefix'] is None: return None, 'UNKNOWN_MECHANISM_PREFIX'
    prefix = descriptor['known_prefix']
    if prefix['later_passive_unmodeled']: return None, 'UNMODELED_LATER_PASSIVE'
    swords = [descriptor[k] for k in ('first_wave_sweep_effective_swords',
        'first_wave_direct_effective_swords','known_ordinary_cascade_effective_swords')]
    if not sum(swords): return None, 'NO_KNOWN_PREFIX_SWORDS'
    f = request['features']; own = f['self_stats']; boss = f['boss_stats']
    resource = descriptor['pre_resource_context']
    values = [*swords, _fill(own['power'], own['max_power']),
        resource['first_wave_effective_rage'],
        resource['known_prefix_effective_rage'] - resource['first_wave_effective_rage'],
        resource['known_prefix_effective_drain'], _fill(boss['power'], boss['max_power']),
        _fill(boss['mana'], boss['max_mana']), _fill(own['mana'], own['max_mana']),
        boss['shield'], prefix['unresolved_refill_cells'], int(prefix['known_residual_after_first_wave'])]
    if not all(number(v) for v in values): return None, 'NUMERIC_CONTEXT_UNKNOWN'
    return dict(signature=tuple(int(n > 0) for n in swords), vector=values,
        known_swords=sum(swords), board_sha256=digest(f['board'])), None


def _domain(rows):
    return [dict(low=min(r['vector'][i] for r in rows), high=max(r['vector'][i] for r in rows))
            for i in range(len(POLICY['context_features']))]


def _distance(a, b, domain):
    return math.sqrt(math.fsum(((x-y)/(d['high']-d['low'] or 1))**2
        for x, y, d in zip(a, b, domain, strict=True)) / len(domain))


def _radius(rows, domain):
    if len(rows) < 2: return 0.
    return max(min(_distance(a['vector'], b['vector'], domain)
        for j, b in enumerate(rows) if i != j) for i, a in enumerate(rows))


def _group(scope_id, signature, rows):
    domain = _domain(rows)
    return dict(scope_id=scope_id, signature=list(signature), rows=rows,
        unique_training_boards=len({r['board_sha256'] for r in rows}),
        domain=domain, joint_radius=_radius(rows, domain))


def fit_exploratory(dataset, plan, *, allow_uncalibrated_component_experiment=False):
    if allow_uncalibrated_component_experiment is not True:
        raise ValueError('EXPLICIT_OFFLINE_COMPONENT_EXPERIMENT_REQUIRED')
    parts = partitions_for(dataset, plan)
    training = [s for s in dataset['samples'] if parts[s['match_id']] == 'TRAIN']
    if not training or 'VALIDATION' not in parts.values():
        raise ValueError('SEPARATE_TRAIN_AND_VALIDATION_MATCHES_REQUIRED')
    grouped = defaultdict(list); skipped = Counter(); payload = []
    for sample in training:
        request = prediction_request(sample)
        if sample['execution_status'] != 'ACKNOWLEDGED': skipped['NO_EXACT_ACK'] += 1; continue
        label = sample['target_observation']
        if label.get('kind') != TARGET: raise ValueError('RECORDED_COMPONENT_TARGET_REQUIRED')
        if label['status'] != 'RECORDED_COMPONENT': skipped[label['status']] += 1; continue
        if not number(label['amount']): raise ValueError('FINITE_COMPONENT_REQUIRED')
        context, reason = _context(request)
        if context is None: skipped[reason] += 1; continue
        scope = numeric_stratum(sample)
        row = dict(sample_id=sample['sample_id'], feature_sha256=sample['feature_sha256'],
            board_sha256=context['board_sha256'], vector=context['vector'],
            amount=label['amount'], known_swords=context['known_swords'],
            ratio=label['amount']/context['known_swords'])
        grouped[scope, context['signature']].append(row)
        payload.append(dict(scope_id=scope, signature=list(context['signature']), **row))
        if len(grouped[scope, context['signature']]) > POLICY['maximum_group_rows']:
            raise ValueError('CONDITIONAL_GROUP_ROW_LIMIT')
    groups = [_group(scope, signature, sorted(rows, key=lambda r:r['sample_id']))
              for (scope, signature), rows in sorted(grouped.items())]
    model = dict(schema=SCHEMA, target=TARGET, policy=deepcopy(POLICY),
        dataset_sha256=dataset['dataset_sha256'],
        training_match_ids=sorted({s['match_id'] for s in training}),
        training_action_ids=sorted(s['sample_id'] for s in training),
        training_board_sha256s=sorted({digest(s['features']['board']) for s in training
                                     if s['features']['board'] is not None}),
        training_payload_sha256=digest(sorted(payload, key=lambda r:r['sample_id'])),
        parameters=groups, training_summary=dict(actions=len(training),
            component_samples=len(payload), skipped=dict(skipped)),
        fitting_scope='EXPLORATORY_RECORDED_COMPONENT_NOT_CALIBRATION_OR_SERVER_FORMULA',
        calibration_eligible=False, deployment_eligible=False, input_authority=False)
    model['model_sha256'] = digest(model)
    return model


def validate_model(model):
    if (type(model) is not dict or model.get('schema') != SCHEMA or model.get('target') != TARGET
            or model.get('policy') != POLICY or not _hash(model.get('dataset_sha256'))
            or model.get('model_sha256') != digest({k:v for k,v in model.items() if k != 'model_sha256'})
            or any(model.get(k) is not False for k in ('calibration_eligible','deployment_eligible','input_authority'))
            or type(model.get('parameters')) is not list or len(model['parameters']) > 1024
            or type(model.get('training_action_ids')) is not list
            or type(model.get('training_board_sha256s')) is not list):
        raise ValueError('CONDITIONAL_MODEL_IDENTITY_OR_SCOPE')
    seen = set(); all_samples = set()
    for g in model['parameters']:
        if (type(g) is not dict or not _hash(g.get('scope_id')) or type(g.get('signature')) is not list
                or len(g['signature']) != 3 or not any(g['signature'])
                or any(type(v) is not int or v not in (0,1) for v in g['signature'])
                or type(g.get('rows')) is not list or not 1 <= len(g['rows']) <= POLICY['maximum_group_rows']):
            raise ValueError('CONDITIONAL_GROUP_SHAPE')
        key = g['scope_id'], tuple(g['signature'])
        if key in seen: raise ValueError('DUPLICATE_CONDITIONAL_GROUP')
        seen.add(key)
        for r in g['rows']:
            if (type(r) is not dict or not _hash(r.get('sample_id')) or r['sample_id'] in all_samples
                    or r['sample_id'] not in model['training_action_ids']
                    or not _hash(r.get('feature_sha256')) or not _hash(r.get('board_sha256'))
                    or r['board_sha256'] not in model['training_board_sha256s']
                    or type(r.get('vector')) is not list or len(r['vector']) != len(POLICY['context_features'])
                    or not all(number(v) for v in r['vector']) or not number(r.get('amount'))
                    or not number(r.get('known_swords')) or r['known_swords'] <= 0
                    or sum(r['vector'][:3]) != r['known_swords']
                    or [int(v > 0) for v in r['vector'][:3]] != g['signature']
                    or not number(r.get('ratio')) or r['ratio'] != r['amount']/r['known_swords']):
                raise ValueError('CONDITIONAL_TRAINING_ROW')
            all_samples.add(r['sample_id'])
        if _group(g['scope_id'], g['signature'], g['rows']) != g:
            raise ValueError('CONDITIONAL_SUPPORT_DERIVATION')
    return model


def predict(model, request, *, scope_id, mode='guarded'):
    validate_model(model)
    if not _hash(scope_id) or mode not in POLICY['modes']:
        raise ValueError('CONDITIONAL_SCOPE_OR_MODE')
    context, reason = _context(request)
    result = dict(sample_id=request['sample_id'], feature_sha256=request['feature_sha256'],
        point=None, lower=None, upper=None, abstention_reason=None)
    diagnostic = dict(mode=mode, model_sha256=model['model_sha256'], scope_id=scope_id,
        outside_training_domain=[], interval_semantics=POLICY['interval'],
        full_power_prediction=None, critical_prediction=None, whole_action_complete=False,
        calibration_eligible=False, deployment_eligible=False, input_authority=False)
    def abstain(why):
        result['abstention_reason'] = why
        return result, dict(diagnostic, status='ABSTAINED', reason=why)
    if request['sample_id'] in model['training_action_ids']:
        return abstain('IN_SAMPLE_REQUEST_NOT_VALIDATION')
    if context is None: return abstain(reason)
    if context['board_sha256'] in model['training_board_sha256s']:
        return abstain('TRAINING_BOARD_NOT_VALIDATION')
    groups = [g for g in model['parameters'] if g['scope_id'] == scope_id
              and g['signature'] == list(context['signature'])]
    if not groups: return abstain('UNSEEN_SCOPE_OR_MECHANISM')
    group = groups[0]
    diagnostic.update(training_rows=len(group['rows']),
        unique_training_boards=group['unique_training_boards'], signature=group['signature'])
    if group['unique_training_boards'] < POLICY['minimum_unique_training_boards']:
        return abstain('INSUFFICIENT_UNIQUE_TRAINING_BOARDS')
    distances = sorted((_distance(context['vector'], r['vector'], group['domain']), r['sample_id'], r)
                       for r in group['rows'])
    outside = [name for name, value, domain in zip(POLICY['context_features'], context['vector'], group['domain'], strict=True)
               if not domain['low'] <= value <= domain['high']]
    nearest = distances[0][0]; joint_outside = nearest > group['joint_radius']
    diagnostic.update(outside_training_domain=outside, nearest_distance=nearest,
        joint_radius=group['joint_radius'], joint_context_outside=joint_outside)
    if mode == 'guarded' and outside: return abstain('OUTSIDE_TRAINING_CONTEXT')
    if mode == 'guarded' and joint_outside: return abstain('JOINT_CONTEXT_UNSUPPORTED')
    cutoff = distances[min(POLICY['neighbors'], len(distances))-1][0]
    neighbors = [(r['ratio'], 1/(1+d*d), sid, d) for d, sid, r in distances if d <= cutoff]
    total_weight = math.fsum(n[1] for n in neighbors); running = 0.; ratio = None
    for value, weight, _, _ in sorted(neighbors):
        running += weight
        if running >= total_weight/2:
            ratio = value; break
    forecast = dict(point=ratio*context['known_swords'],
        lower=min(n[0] for n in neighbors)*context['known_swords'],
        upper=max(n[0] for n in neighbors)*context['known_swords'])
    if not all(number(v) for v in forecast.values()): return abstain('FORECAST_NUMERIC_BOUND')
    result.update(**forecast)
    diagnostic.update(neighbors=len(neighbors), neighbor_sample_ids=[n[2] for n in neighbors],
        neighbor_distances=[n[3] for n in neighbors], known_prefix_swords=context['known_swords'],
        effective_neighbor_count=total_weight**2/math.fsum(n[1]**2 for n in neighbors),
        domain_guard_applied=mode == 'guarded')
    return result, dict(diagnostic, status='EXPLORATORY_FORECAST', reason='CONDITIONAL_COMPONENT_REFERENCE_ONLY')
