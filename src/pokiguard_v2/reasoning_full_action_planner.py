"""Pure D2 conditional action utility. No runtime adapter, IO or authority."""
from .reasoning_snapshot import Action, FrozenJSON, canonical_json, require
from .board_simulator import evaluate_all_moves
from .basic_policy import _candidate_trace

VERSION = '5d2.ht7_full_actions.v2'


def plan_full_actions(snapshot):
    """All legal swaps plus legal skill/PASS; robust gap, never an override quota."""
    from .reasoning_mega import VERSION as MEGA_VERSION,plan as plan_mega
    if snapshot.recorded.plain()['d2_actions']['version']==MEGA_VERSION:return plan_mega(snapshot)
    from .reasoning_planner import (Bound, PlannerDecision, FEATURES, clip,
        score_candidate, order_key)
    ctx = snapshot.recorded.plain()['d2_actions']
    require(ctx['version'] == VERSION and snapshot.intent.profile == 'skill_rush', 'D2 snapshot required')
    board = snapshot.board_state()
    values = evaluate_all_moves(board)
    by_move = {canonical_json(Action('swap', v.move).to_dict()): v for v in values}
    self_hp = snapshot.evidence('self.hp').value.plain()
    max_hp = snapshot.evidence('self.max_hp').value.plain()
    require(type(self_hp) is int and type(max_hp) is int and 0 < self_hp <= max_hp, 'current HP required')
    pressure = 1 - self_hp / max_hp
    # Versioned structural proxy weights, not calibrated HP/damage coefficients.
    post = ctx['past_success_count'] > 0
    weights = {k: Bound.fixed(v) for k, v in zip(FEATURES,
        (0, 2 if post else 5, 6 if post else 2, 3+5*pressure, 0, 0,
         4+4*pressure, 3, 0, 1))}
    scores = []
    excluded = []
    for choice in ctx['choices']:
        action = Action.from_dict(choice['action'])
        if not choice['eligible']:
            excluded.append(dict(action=action.to_dict(), reason=choice['reason']))
            continue
        f = {name: Bound.fixed(0) for name in FEATURES}
        facts = choice['facts']
        details = dict(assumptions=[], settings_are_advisory=True, actual_damage_survival='UNKNOWN',
            action_scope=VERSION, future_credit=0, observed_win=False,
            excluded_effects=ctx['exclusions'])
        if action.family == 'swap':
            v = by_move.get(canonical_json(action.to_dict()))
            require(v is not None, 'candidate not a legal existing-solver move')
            trace = _candidate_trace(v, board=board)
            totals = {name: effective for name, physical, effective in trace.total_resources}
            f['D'] = Bound.fixed(clip(totals.get('sword', 0)/8), 'SWORD_OPPORTUNITY_NOT_HP_DAMAGE')
            f['P'] = Bound.fixed(clip(sum(totals.get(g, 0) for g in ('health','shield','drain'))/8),
                'PROTECTION_GEM_OPPORTUNITY_NOT_HEAL_OR_SURVIVAL')
            f['T'] = Bound.fixed(clip(trace.opponent_sword_reply_effective_max/8),
                'KNOWN_SWORD_REPLY_PROXY_BOSS_POLICY_UNKNOWN')
            f['X'] = Bound.fixed(clip(trace.unknown_cells/64 + .25*bool(trace.unknown_sword_completions)),
                'UNKNOWN_EXPOSURE_NOT_REFILL_PROBABILITY')
            skill_facts = next(c['facts'] for c in ctx['choices'] if c['action']['family']=='pet_skill')
            costs = skill_facts['actual_costs']
            if costs is None or any(type(costs.get(k)) is not int or costs[k] < 0 for k in ('mana','rage')):
                f['R'] = Bound.missing('ACTUAL_SKILL_COST_UNKNOWN')
            else:
                progress = []
                for resource, current in (('mana', skill_facts['current_mana']), ('rage', skill_facts['current_rage'])):
                    if type(current) is not int:
                        progress = None
                        break
                    missing = max(0, costs[resource]-current)
                    gain = totals.get(resource,0)*ctx['resource_conversion'][resource]
                    progress.append(min(missing,gain)/max(1,costs[resource]))
                f['R'] = (Bound.missing('CURRENT_RESOURCE_UNKNOWN') if progress is None else
                    Bound.fixed(sum(progress)/2, 'SCOPED_20_RAGE_30_MANA_CAPPED_DEFICIT_PROGRESS'))
            f['E'] = Bound.fixed(.4, 'TWO_CLICK_EXECUTION_DEMAND_PROXY')
            details.update(resources=totals, boss_reply_count=len(v.sword_replies),
                ledger=dict(totals=totals, coverage='EXISTING_SOLVER_KNOWN_CASCADES'),
                boss_reply_coverage='VISIBLE_SWORD_REPLIES_ONLY')
        elif action.family == 'pet_skill':
            geometry = ctx['perfect_geometry']
            if geometry is None:
                return PlannerDecision(snapshot.snapshot_id, snapshot.intent.config_hash, snapshot.baseline,
                    'RETAIN_BASELINE', 'OPAQUE_SKILL_COMPARISON', None, (), FrozenJSON.of(dict(version=VERSION)))
            counts = geometry['quantities']
            f['D'] = Bound.fixed(clip(counts['sword']['effective']/8), 'CONDITIONAL_PERFECT_SWORD_OPPORTUNITY')
            f['P'] = Bound.fixed(clip(counts['health']['effective']/8),
                'CONDITIONAL_PERFECT_HEALTH_GEMS_NOT_HEAL_POINTS')
            # T has the same visible-original-cell coverage as ordinary swaps.
            # Conditional Perfect removes every original Sword. Refills remain
            # UNKNOWN and are penalized separately by X, never called risk0.
            f['T'] = Bound.fixed(0, 'CONDITIONAL_NO_ORIGINAL_SWORD_SURVIVES_REFILL_THREAT_UNKNOWN')
            f['X'] = Bound.fixed(len(geometry['original_cells'])/64, 'CONDITIONAL_REMOVAL_REFILL_EXPOSURE')
            f['E'] = Bound.fixed(1, 'EXISTING_QTE_EXECUTION_DEMAND_PROXY')
            details.update(assumptions=['PERFECT_ONLY_NOT_GUARANTEED', 'USER_CALIBRATED_FIRST_WAVE'],
                actual_post_skill_threat='UNKNOWN_REFILL_AND_BOSS_POLICY',
                ledger=dict(totals=counts, original_cells=geometry['original_cells'],
                    coverage='CONDITIONAL_FIRST_WAVE_ONLY'), costs=facts['actual_costs'])
        elif action.family == 'pass':
            # Boss starts on the unchanged current board; its available direct
            # Sword matches are the direct results of the existing legal moves.
            from .state import GemType
            current_sword = max((v.total.effective(GemType.SWORD) for v in values), default=0)
            f['T'] = Bound.fixed(clip(current_sword/8), 'UNCHANGED_BOARD_SWORD_OPPORTUNITY_FOR_BOSS')
            details.update(assumptions=['ZERO_INPUT_EXISTING_AUTHORITATIVE_PASS_OWNER',
                'BOSS_SKILL_AND_REFILL_POLICY_UNKNOWN'], pass_authority=facts)
        else:
            raise ValueError('unsupported action family')
        # Every family shares unmodeled damage/boss-skill limitations. T is a
        # visible board proxy; no candidate is certified lethal or safe.
        details['weights'] = {k:v.to_dict() for k,v in weights.items()}
        scores.append(score_candidate(snapshot, snapshot.snapshot_id, action, f, weights, details, 1))
    ordered = tuple(sorted(scores, key=lambda c:order_key(c,'skill_rush')))
    base = next((s for s in ordered if s.baseline_member), None)
    reason, proposal = 'OPAQUE_OR_UNSCORABLE_BASELINE', None
    if base is not None:
        reason = 'BASELINE_TOP_IN_TOTAL_ORDER'
        if ordered and not ordered[0].baseline_member:
            reason = 'NEAR_TIE_OR_ESSENTIAL_ASSUMPTION_SENSITIVE'
            if ordered[0].utility.low-base.utility.high >= .05:
                reason, proposal = 'D2_ROBUST_CONDITIONAL_PROXY_IMPROVEMENT', ordered[0].action
    return PlannerDecision(snapshot.snapshot_id, snapshot.intent.config_hash, snapshot.baseline,
        'PROPOSE_OFFLINE' if proposal else 'RETAIN_BASELINE', reason, proposal, ordered,
        FrozenJSON.of(dict(version=VERSION, excluded_actions=excluded, conditional_perfect=True,
            no_override_quota=True, no_damage_or_win_guarantee=True, input_authority=False)))


