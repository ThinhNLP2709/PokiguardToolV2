"""Offline skill observations for the common core; never prospective effects.

Amounts remain attached to ordered server steps or raw stat operations. A
matching ledger does not establish a damage/refund formula or permit an action.
No runtime planner imports this module.
"""
from copy import deepcopy
import hashlib
import json

from .reasoning_snapshot import FrozenJSON, require
from .combat_outcome_evidence import MAX_STEPS, MAX_OPERATIONS

SCHEMA = 'pokiguard.reasoning.skill_receipt.v1'
STATS = {'HP': ('hp', 'max_hp'), 'MANA': ('mana', 'max_mana'),
         'POWER': ('power', 'max_power'), 'SHIELD': ('shield', None)}


def number(v):
    return type(v) is int


def actor(v):
    return v == 'BOSS' or (type(v) is str and len(v) == 71 and v.startswith('sha256:')
                           and all(c in '0123456789abcdef' for c in v[7:]))


def validate_pre_context(context):
    require(type(context) is dict and context.get('schema') == 'pokiguard.skill_action_context.v1'
            and context.get('status') == 'RECORDED', 'RECORDED_SKILL_CONTEXT_REQUIRED')
    raw = deepcopy(context)
    claimed = raw.pop('context_sha256', None)
    actual = hashlib.sha256(json.dumps(raw, sort_keys=True, separators=(',', ':'), ensure_ascii=True).encode()).hexdigest()
    require(claimed == actual and context.get('input_authority') is False
            and context.get('calibration_eligible') is False, 'SKILL_CONTEXT_CHECKSUM_OR_SCOPE')
    src = context.get('source')
    require(type(src) is dict and type(src.get('session')) is dict and actor(src.get('actor_identity'))
            and src['actor_identity'] != 'BOSS' and number(src.get('srv_seq'))
            and src['srv_seq'] >= 0, 'SKILL_SOURCE_IDENTITY')
    return context


def _ledger(context, evidence):
    """Replay STAT_CHANGE arithmetic only; caps are patterns, not assumptions."""
    local = context['source']['actor_identity']
    values, capacities, starts = {}, {}, {}
    for who, key in ((local, 'player'), ('BOSS', 'boss')):
        stats = context.get(key)
        if type(stats) is not dict:
            continue
        if ((who == local and (stats.get('is_local') is not True or stats.get('is_boss') is not False))
                or who == 'BOSS' and stats.get('is_boss') is not True):
            continue
        for stat, (field, cap) in STATS.items():
            value, maximum = stats.get(field), stats.get(cap) if cap else None
            values[who, stat] = value if number(value) and value >= 0 else None
            starts[who, stat] = values[who, stat]
            capacities[who, stat] = maximum if number(maximum) and maximum >= 0 else None
    operations = evidence.get('resource_operations')
    if operations is None:
        return dict(status='UNKNOWN', reason='ORDERED_RESOURCE_OPERATIONS_MISSING', entries=[], endpoints=[])
    require(type(operations) is list and len(operations) <= MAX_OPERATIONS, 'OPERATION_LIMIT')
    entries, previous = [], -1
    for op in operations:
        require(type(op) is dict and number(op.get('operation_index'))
                and op['operation_index'] > previous, 'OPERATION_ORDER')
        previous = op['operation_index']
        if op.get('type') != 'STAT_CHANGE':
            continue
        who, stat = op.get('target'), op.get('stat_type')
        require(who is None or actor(who), 'OPERATION_TARGET')
        delta, end = op.get('delta'), op.get('new_value')
        require(delta is None or number(delta), 'OPERATION_DELTA')
        require(end is None or number(end), 'OPERATION_AFTER')
        before, cap = values.get((who, stat)), capacities.get((who, stat))
        actual = end-before if number(before) and number(end) else None
        if actual is None or delta is None:
            status = 'UNKNOWN'
        elif actual == delta:
            status = 'EXACT_RAW_ARITHMETIC'
        elif (number(cap) and 0 <= before <= cap and delta > 0
              and before+delta > cap and end == cap):
            status = 'CAP_PATTERN_OBSERVED'
        elif delta < 0 and before+delta < 0 and end == 0:
            status = 'FLOOR_PATTERN_OBSERVED'
        else:
            status = 'MISMATCH_UNMODELED_OR_MISSING_CHANGES'
        entries.append(dict(operation_index=previous, target=who, stat=stat, before=before,
            reported_delta=delta, observed_after=end, observed_delta=actual, capacity=cap,
            status=status, reason=op.get('reason'), source_label=op.get('source_label')))
        values[who, stat] = end if number(end) and end >= 0 else None
    endpoints = [dict(actor=who, stat=stat, before=start, after=values.get((who, stat)),
        observed_net=(values[who, stat]-start if number(start) and number(values.get((who, stat))) else None))
        for (who, stat), start in sorted(starts.items())]
    return dict(status='ORDERED_RAW_ARITHMETIC_ONLY', entries=entries, endpoints=endpoints,
                complete_effect_coverage='UNKNOWN')


def skill_receipt(context, evidence, *, association, response_players=None):
    """Create immutable retrospective facts, with confidence preserved by role."""
    validate_pre_context(context)
    source = context['source']
    require(type(evidence) is dict and evidence.get('event_type') == 'MATCH_SKILL_USE_RES'
            and evidence.get('match_id') == source['session']['match_id']
            and evidence.get('actor_identity') == source['actor_identity']
            and number(evidence.get('server_sequence'))
            and evidence['server_sequence'] > source['srv_seq'], 'SKILL_RESPONSE_IDENTITY')
    require(association in ('CLIENT_CARD_WINDOW', 'WIRE_CARD_OBSERVED_WINDOW', 'UNBOUND'),
            'EXPLICIT_ASSOCIATION_SCOPE_REQUIRED')
    if association == 'WIRE_CARD_OBSERVED_WINDOW':
        ids = evidence.get('card_ids') or {}
        require(type(ids.get('skillCardId')) is int and ids['skillCardId'] == context.get('skill_card_id'),
                'EXPLICIT_WIRE_CARD_ID_REQUIRED')
    steps = evidence.get('steps')
    require(type(steps) is list and 0 < len(steps) <= MAX_STEPS, 'BOUNDED_ORDERED_STEPS_REQUIRED')
    previous = -1
    for step in steps:
        require(type(step) is dict and number(step.get('idx')) and step['idx'] > previous
                and type(step.get('kind')) is str and number(step.get('amount'))
                and actor(step.get('source')) and actor(step.get('target')), 'STEP_IDENTITY_ORDER_OR_AMOUNT')
        previous = step['idx']
    ledger = _ledger(context, evidence)
    local = source['actor_identity']
    heals = []
    for step in steps:
        if step['target'] != local or step['kind'] not in ('HEAL', 'LIFESTEAL'):
            continue
        # Keep the two streams separate. Optional operation labels corroborate
        # the observed source; they never relabel a step or define a formula.
        matches = [op for op in ledger['entries'] if op['target'] == local and op['stat'] == 'HP'
                   and op['reported_delta'] == step['amount']
                   and op['observed_after'] == (step.get('after') or {}).get('HP')]
        heals.append(dict(step_index=step['idx'], kind=step['kind'], reported_amount=step['amount'],
            raw_after=deepcopy(step.get('after')), operation_source_labels=sorted({
                op['source_label'] for op in matches if type(op['source_label']) is str}),
            formula=None, source_attribution='SAME_RESPONSE_LABEL_NOT_INTRINSIC_PET_SKILL_PROOF'))
    costs = context.get('costs') or {}
    first_destroy = min((op['operation_index'] for op in evidence.get('resource_operations') or []
                         if op.get('type') == 'DESTROY'), default=None)
    cost_checks = {}
    for stat, field in (('MANA', 'mana'), ('POWER', 'rage')):
        cost = costs.get(field)
        prefix = [op for op in ledger['entries'] if op['target'] == local and op['stat'] == stat
                  and first_destroy is not None and op['operation_index'] < first_destroy]
        ok = (number(cost) and cost > 0 and len(prefix) == 1
              and prefix[0]['reported_delta'] == -cost and prefix[0]['status'] == 'EXACT_RAW_ARITHMETIC')
        cost_checks[field] = dict(context_cost=cost, status='EXACT_PRE_DESTROY_DEBIT' if ok else 'UNKNOWN',
                                 operation_index=prefix[0]['operation_index'] if ok else None)
    full_power = [dict(operation_index=op['operation_index'], reported_delta=op['reported_delta'],
                       observed_delta=op['observed_delta'], after=op['observed_after'], status=op['status'])
                  for op in ledger['entries'] if op['target'] == local and op['stat'] == 'POWER'
                  and op['reason'] == 'FULL_POWER']
    endpoints = []
    if response_players is not None:
        require(type(response_players) is dict and response_players.get('input_authority') is False
                and response_players.get('calibration_eligible') is False
                and all(response_players.get(k) == evidence.get(k) for k in
                    ('match_id', 'server_sequence', 'event_type', 'raw_sha256')), 'RESPONSE_PLAYERS_IDENTITY')
        for player in response_players.get('players', []):
            if player.get('actor_identity') != local:
                continue
            for endpoint in ledger['endpoints']:
                if endpoint['actor'] != local:
                    continue
                wire = player['fields'].get({'HP':'hp', 'MANA':'mana', 'POWER':'power', 'SHIELD':'shield'}[endpoint['stat']])
                endpoints.append(dict(stat=endpoint['stat'], ledger_after=endpoint['after'], response_after=wire,
                    status='EXACT' if number(wire) and wire == endpoint['after'] else 'UNKNOWN_OR_MISMATCH'))
    return FrozenJSON.of(dict(schema=SCHEMA, match_id=evidence['match_id'],
        response_sequence=evidence['server_sequence'], response_raw_sha256=evidence['raw_sha256'],
        source=deepcopy(source), association=association, wire_card_identity='UNKNOWN' if association!='WIRE_CARD_OBSERVED_WINDOW' else 'EXPLICIT',
        association_verified_by_module=False,
        association_provenance='CALLER_BINDER_SCOPE_NOT_NEW_CARD_OR_ACK_ATTESTATION',
        pre_to_response_arithmetic_scope='UNBOUND_CANDIDATE_HYPOTHESIS' if association=='UNBOUND'
            else 'CONDITIONAL_OBSERVED_CLIENT_WINDOW_NOT_UNIVERSAL_RULE',
        ordered_effects=deepcopy(steps), resource_ledger=ledger, cost_debits=cost_checks,
        full_power_operations=full_power, healing_components=heals, response_endpoint_checks=endpoints,
        observed_batch_damage=sum(s['amount'] for s in steps if s['kind']=='DAMAGE' and s['target']=='BOSS'),
        pure_skill_damage=None, damage_model=None, healing_model=None, effect_time_state=None,
        prospective_use=False, input_authority=False, training_eligible=False, calibration_eligible=False,
        limitations=['SAME_RESPONSE_COMPONENTS_NOT_PURE_PET_DAMAGE', 'HEAL_AND_LIFESTEAL_SEPARATE',
                     'NET_BALANCE_NOT_COST_OR_GROSS_GAIN', 'CLIENT_CARD_NOT_WIRE_CARD',
                     'CAP_AND_FULL_POWER_ARE_OBSERVED_NOT_UNIVERSAL_RULES', 'COUNTERFACTUAL_OUTCOMES_UNKNOWN']))
