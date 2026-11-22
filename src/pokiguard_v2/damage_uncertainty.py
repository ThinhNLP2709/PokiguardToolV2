"""Offline advisory interpretation of empirical damage, never action authority.

An observed component range is not a bound on a future whole action. In
particular, absent pre-input crit/order/refill information cannot be supplied
from the outcome of the action being evaluated.
"""
from copy import deepcopy
from .damage_action_context import describe_action
from .damage_evaluation import number

SCHEMA='pokiguard.damage_uncertainty.v1'
FORECAST_KEYS=frozenset(('sample_id','feature_sha256','point','lower','upper','abstention_reason'))

def _forecast(request,value):
    if value is None:return None
    if (type(value) is not dict or set(value)!=FORECAST_KEYS
        or any(value[k]!=request[k] for k in ('sample_id','feature_sha256'))):
        raise ValueError('FORECAST_PRE_INPUT_IDENTITY')
    if value['point'] is None:
        if (value['lower'] is not None or value['upper'] is not None
            or type(value['abstention_reason']) is not str or not 0<len(value['abstention_reason'])<=128):
            raise ValueError('FORECAST_ABSTENTION')
    elif (any(not number(value[k]) for k in ('point','lower','upper'))
        or not value['lower']<=value['point']<=value['upper'] or value['abstention_reason'] is not None):
        raise ValueError('FORECAST_EMPIRICAL_RANGE')
    return deepcopy(value)

def assess(request,forecast=None):
    """Interpret only the exact label-free request and a separately pinned forecast."""
    descriptor=describe_action(request);reference=_forecast(request,forecast)
    f=request['features'];own=f['self_stats'] or {};boss=f['boss_stats'] or {}
    prefix=descriptor['known_prefix'];context=descriptor['pre_resource_context']
    flags=['SERVER_DAMAGE_FORMULA_UNVERIFIED','PRE_INPUT_CRIT_UNOBSERVED','WHOLE_ACTION_COMPONENT_COVERAGE_UNVERIFIED']
    if boss.get('shield') is None:flags.append('BOSS_SHIELD_UNKNOWN')
    elif boss['shield']>0:flags.append('SHIELD_ABSORPTION_AND_EFFECT_ORDER_UNKNOWN')
    if prefix is None:flags.append('KNOWN_PREFIX_UNAVAILABLE')
    else:
        if prefix['unresolved_refill_cells']:flags.append('REFILL_AND_FURTHER_EFFECTS_UNOBSERVED')
        if prefix['known_residual_after_first_wave']:flags.append('KNOWN_RESIDUAL_EFFECT_ORDER_UNMODELED')
        if prefix['later_passive_unmodeled']:flags.append('LATER_PASSIVE_UNMODELED')
        if prefix['effective']['sword']:
            flags.append('ATTACK_RAGE_SPEND_ORDER_UNKNOWN')
            if prefix['effective']['rage']:flags.append('RAGE_GAIN_VS_ATTACK_ORDER_UNKNOWN')
        if prefix['effective']['drain']:flags.append('DRAIN_RESOURCE_AMOUNT_AND_ORDER_UNKNOWN')
    relation='NO_COMPONENT_ESTIMATE';status='UNESTIMATED'
    if reference is not None:
        status='ABSTAINED' if reference['point'] is None else 'EMPIRICAL_COMPONENT_REFERENCE'
        if status=='ABSTAINED':flags.append('MODEL_ABSTAINED')
        else:
            hp=boss.get('hp')
            if not number(hp) or hp<=0:relation='BOSS_HP_NOT_COMPARABLE'
            elif reference['lower']>=hp:relation='REFERENCE_RANGE_REACHES_HP_NOT_CERTIFIED_KILL'
            elif reference['upper']<hp:relation='REFERENCE_RANGE_BELOW_HP_FURTHER_EFFECTS_UNKNOWN'
            else:relation='REFERENCE_RANGE_OVERLAPS_HP'
    return dict(schema=SCHEMA,sample_id=request['sample_id'],feature_sha256=request['feature_sha256'],status=status,
        reference=reference,reference_semantics='EMPIRICAL_RECORDED_COMPONENT_RANGE_NOT_CALIBRATED_WHOLE_ACTION_BOUNDS',
        hp_relation=relation,uncertainties=flags,mechanism=descriptor,
        pre_resources=dict(self_hp=own.get('hp'),boss_hp=boss.get('hp'),boss_shield=boss.get('shield'),
            self_rage=own.get('power'),boss_rage=boss.get('power'),mana=own.get('mana')),
        certified_damage_lower=None,certified_damage_upper=None,kill_certified=False,survival_certified=False,
        crit_probability=None,net_resource_prediction=False,post_response_used=False,
        runtime_fallback='EXISTING_ADVISER',stop_requested=False,input_authority=False,calibration_eligible=False)

def compare_references(first_request,second_request,first_forecast=None,second_forecast=None):
    """Expose uncertainty for two choices on the same board, without ranking as truth."""
    a=assess(first_request,first_forecast);b=assess(second_request,second_forecast)
    fa,fb=first_request['features'],second_request['features']
    if any(fa[k]!=fb[k] for k in ('board','self_stats','boss_stats','settings')):
        raise ValueError('SAME_BOARD_ACTORS_AND_SETTINGS_REQUIRED')
    ranges='UNAVAILABLE';points='UNAVAILABLE'
    if all(x['status']=='EMPIRICAL_COMPONENT_REFERENCE' for x in (a,b)):
        x,y=a['reference'],b['reference']
        points='FIRST' if x['point']>y['point'] else 'SECOND' if y['point']>x['point'] else 'TIED'
        ranges='FIRST_ABOVE' if x['lower']>y['upper'] else 'SECOND_ABOVE' if y['lower']>x['upper'] else 'OVERLAP'
    return dict(first=a,second=b,empirical_point_preference=points,empirical_range_separation=ranges,
        certain_better_action=None,scope='REFERENCE_SENSITIVITY_ONLY_NOT_COUNTERFACTUAL_OUTCOME',
        actual_refill_injected=False,quality_label=None,runtime_fallback='EXISTING_ADVISER',stop_requested=False,input_authority=False)
