"""Scoped Demon R1 minimum: pure existing-geometry comparison, no game IO.

The two certificates are direct operator calibration, not a damage formula or
proof of a terminal result. Unknown passive residual threat/refill/protection
remain intervals. No followup, boss-policy, setup or same-burst order credit.
"""
from dataclasses import replace
import json
import time

from .board_simulator import evaluate_all_moves, simulate_move
from .reasoning_snapshot import Action, Evidence, FrozenJSON, canonical_json, digest, require
from .state import GemType

VERSION = '5d3.demon_minimum.v1'
CONTEXT = 'BOUNDED_D3_DEMON_MINIMUM_SWAP_PILOT'
PROTOCOL = 'D3_DEMON_MINIMUM_CURRENT_NATIVE_V1'
MODEL = dict(version=VERSION, physical_floor=2, baseline_reference=4,
    preexisting_rage=dict(physical_swords=3, rage_points=100), effective_swords=4,
    same_burst='UNSUPPORTED', source='OPERATOR_CALIBRATED_CURRENT_ACCOUNT_LIEYUN77')


def structural_witness(value):
    """Unused cards may publish after opening. No card identity authorizes passive."""
    return dict(account_username_sha256=value['account_username_sha256'], boss=value['boss'],
        loadout=dict(config=value['loadout']['config'], fusion=value['loadout']['fusion']))


def validate_profile(profile, witness):
    require(type(profile) is FrozenJSON, 'immutable Demon profile required')
    data=profile.plain()
    require(set(data)==set(MODEL)|{'account_sha256','player_stats'} and
        {k:data[k] for k in MODEL}==MODEL and
        data['account_sha256']==witness.plain()['account_username_sha256'] and
        type(data['player_stats']) is list and len(data['player_stats'])==4 and
        all(type(x) is int and x>0 for x in data['player_stats']), 'exact scoped Demon minimum required')
    require(witness.plain()['loadout']['config'] == ['normal', 'none', 'pet_passive'],
        'Demon passive loadout required')


def is_demon(authority):
    from .reasoning_operational import OperationalPilotAuthority
    return type(authority) is OperationalPilotAuthority and authority.demon_profile is not None


def bind_snapshot(snapshot, authority):
    validate_profile(authority.demon_profile, authority.witness)
    require(snapshot.intent.profile == 'demon_aegis_farm', 'Demon profile mismatch')
    require(snapshot.intent.settings.plain().get('demon_target_gem','shield') == 'shield',
        'D3 calibration supports Shield target only; retain BASIC for other targets')
    record = snapshot.recorded.plain()
    record['d3_demon'] = dict(profile=authority.demon_profile.plain(), scope=authority.scope.plain())
    return replace(snapshot, recorded=FrozenJSON.of(record))


def plan_demon(snapshot):
    from .reasoning_planner import (Bound, CandidateScore, FEATURES, Inputs, PlannerDecision,
        order_key, removal_ledger)
    from .demon_aegis import evaluate_demon_aegis_move
    require(snapshot.intent.settings.plain().get('demon_target_gem','shield') == 'shield',
        'D3 calibration supports Shield target only; retain BASIC for other targets')
    record = snapshot.recorded.plain()['d3_demon']
    profile = record['profile']
    require(set(profile) == set(MODEL) | {'account_sha256','player_stats'} and
        {k:profile[k] for k in MODEL} == MODEL, 'Demon model drift')
    require(snapshot.intent.profile == 'demon_aegis_farm' and snapshot.baseline.family == 'swap',
        'Demon minimum compares ordinary SWAP incumbents only')
    scope = record['scope']
    require(set(scope) == {'account_binding', 'boss', 'loadout'} and
        all(type(v) is str and v not in ('', 'UNKNOWN', 'NOT_PUBLISHED') for v in scope.values()) and
        all(snapshot.intent.scope.plain().get(k) == v for k,v in scope.items()), 'Demon cohort mismatch')
    require(scope['account_binding'] == profile['account_sha256'], 'Demon account calibration mismatch')
    inputs = Inputs(snapshot)
    legal = inputs.value('planner.legality', 'action_capability')
    model = inputs.value('planner.model', 'scoped_model')
    require(model == {'version':'5b2.scoped_inputs.v1'} and legal == dict(owner='ROOT_TURN',
        swap_allowed=True, pass_allowed=False, mandatory=True, blocked=False), 'unsupported Demon owner/model')
    hp = inputs.stat('self.hp', 'hp_points'); cap = inputs.stat('self.max_hp', 'hp_points')
    rage = inputs.stat('self.rage', 'rage_points')
    require([inputs.stat('self.'+k,unit) for k,unit in (
        ('max_hp','hp_points'),('max_mana','mana_points'),('max_rage','rage_points'),('attack','attack_points'))]
        == profile['player_stats'], 'Demon account/loadout stat calibration changed')
    require(hp is not None and cap is not None and cap > 0 and 0 <= hp <= cap, 'Demon HP unavailable')
    require(rage is None or rage <= profile['player_stats'][2], 'Demon Rage exceeds observed cap')
    pressure = 1-hp/cap  # HP context only, never a boss damage/threat estimate.
    weights = dict(F=12, R=0, D=2, P=3*(1+2*pressure), H=0, B=0,
        T=2*(1+2*pressure), X=2*(1+pressure), L=0, E=0)
    board = snapshot.board_state()
    values = evaluate_all_moves(board)
    scores = []
    for value in values:
        passive = evaluate_demon_aegis_move(board, value, include_next_turn=False)
        action = Action('swap', value.move)
        # Keep the incumbent represented even if it is a mandatory legacy escape.
        # An alternative may never match/cascade Sword normally in this scope.
        ordinary_sword = value.total.cells(GemType.SWORD)
        eligible = ordinary_sword == 0 or action == snapshot.baseline
        ledger = removal_ledger(snapshot, value, passive.blast_cells)
        ledger['passive_swords'] = dict(physical=passive.sword_cells, effective=passive.sword_effective)
        certs = []
        if passive.activates_passive and passive.sword_cells >= profile['physical_floor'] and not ordinary_sword:
            if passive.sword_effective >= profile['effective_swords']:
                certs.append('OPERATOR_EFFECTIVE4_PHYSICAL_FLOOR2')
            if rage is not None and rage >= 100 and passive.sword_cells >= 3:
                certs.append('OPERATOR_PREEXISTING_RAGE100_PHYSICAL3')
        altered = passive.activates_passive
        unknown = Bound.missing('PASSIVE_RESIDUAL_AND_REFILL_UNKNOWN')
        protection = any(ledger['totals'][g]['effective'] for g in ('shield','health','drain'))
        features = dict(F=Bound.fixed(int(bool(certs)), 'OPERATOR_NOMINAL_SUFFICIENCY_NOT_OBSERVED_WIN'),
            R=Bound.fixed(0, 'NO_ACTIVE_SKILL_RESOURCE_REQUIREMENT_IN_MINIMUM_SCOPE'),
            D=Bound.fixed(min(1, ledger['totals']['sword']['effective']/8), 'KNOWN_SWORD_UNITS_NOT_HP_DAMAGE'),
            P=Bound.missing('PROTECTION_CONVERSION_UNKNOWN') if protection else Bound.fixed(0),
            H=Bound.fixed(0, 'NO_POST_BOSS_SETUP_CREDIT'), B=Bound.fixed(0, 'NO_BAIT_CREDIT'),
            T=unknown if altered else Bound.fixed(min(1,value.sword_risk.opponent_sword_reply_effective_max/8)),
            X=unknown if altered else Bound.fixed(min(1,value.unknown_exposure.cells/64+
                .25*bool(value.unknown_exposure.hypothetical_sword_completions))),
            L=Bound.fixed(0, 'NO_FUTURE_CONTEST_CREDIT'),
            E=Bound.fixed(0, 'COMMON_SWAP_EXECUTOR_COST_CANCELS_NOT_ZERO_LATENCY'))
        contributions = {}
        for name in FEATURES:
            f = features[name]; lo,hi=f.low*weights[name],f.high*weights[name]
            if name in ('T','X','L','E'): lo,hi=-hi,-lo
            contributions[name] = Bound(lo,hi,f.status,f.reason)
        lo = sum(v.low for v in contributions.values()); hi = sum(v.high for v in contributions.values())
        scores.append(CandidateScore(snapshot.candidate_id(action), action, action == snapshot.baseline,
            tuple(features.items()), tuple(contributions.items()),
            Bound(lo,hi,'PRESENT' if lo == hi else 'BOUNDED','D3_SCOPED_NOMINAL_R1_NOT_WIN_PROBABILITY'),
            0, FrozenJSON.of(dict(ledger=ledger, resources=dict(rage_before=rage),
                certificate=dict(ids=certs,support='USER_CALIBRATED',observed_win=False,
                    dominance_tier=False,same_burst_order='UNKNOWN_NO_CREDIT'),
                eligible=eligible, weights=weights, setting_is_eligibility_gate=False,
                boss_reply_coverage='PASSIVE_RESIDUAL_UNKNOWN' if altered else 'ORDINARY_KNOWN_PROXY',
                physical_swords=passive.sword_cells,effective_swords=passive.sword_effective,
                no_future_credit=True, calibration_version=VERSION))))
    ordered = tuple(sorted(scores,key=lambda c: order_key(c,'demon_aegis_farm')))
    baseline = next((c for c in ordered if c.baseline_member),None)
    valid = [c for c in ordered if c.details.plain()['eligible'] and
        c.details.plain()['certificate']['ids']]
    proposal = None; reason = 'D3_NO_CERTIFIED_IMPROVEMENT_RETAIN_BASIC'
    gap = None
    if baseline is not None and valid:
        best = valid[0]
        gap = best.utility.low-baseline.utility.high
        if best.baseline_member:
            reason = 'D3_BASELINE_ALREADY_BEST'
        elif gap >= .05:
            proposal=best.action;reason='D3_SCOPED_SUFFICIENCY_PROXY_IMPROVEMENT'
        else:
            reason='D3_UNCERTAINTY_OR_PRESSURE_RETAINS_BASIC'
    return PlannerDecision(snapshot.snapshot_id,snapshot.intent.config_hash,snapshot.baseline,
        'PROPOSE_OFFLINE' if proposal else 'RETAIN_BASELINE',reason,proposal,ordered,FrozenJSON.of(dict(
            mode='OFFLINE_ONLY',input_authority=False,profile_version=VERSION,robust_gap=gap,
            physical_count_not_effective_count=True,settings_are_advisory=True,
            sufficiency_support='USER_CALIBRATED',actual_alternative_damage='UNKNOWN',
            setup_bait_and_same_burst='NOT_ACCEPTED_BY_MINIMUM_SCOPE')))


def prepare_completed(cls, *, job, raw_reply, state, config, capability, completed_ns):
    """Background result validation; recompute the exact pure result, never input."""
    from .autonomous_control import AutonomousSource
    from .basic_policy import _candidate_trace
    from .board_diagnostics import jsonable
    from .reasoning_operational import authority_deadline, authority_margin
    from .reasoning_runner import _validate_reply, _decision_summary
    authority = capability.pilot_authority
    require(is_demon(authority) and authority.matches(state,config), 'Demon authority/cohort changed')
    snapshot = job.snapshot
    source = AutonomousSource.from_state(state)
    require(snapshot.board_state() == state.board and snapshot.intent.settings.text == canonical_json(jsonable(config))
        and snapshot.recorded.plain()['controller_source_hash'] == source.critical_state_hash
        and snapshot.source.session_id == canonical_json(jsonable(state.battle.session_key))
        and snapshot.source.match_id == state.battle.match_id and snapshot.source.turn == state.battle.turn_number
        and snapshot.source.srv_seq == state.battle.srv_seq and snapshot.source.board_hash == state.battle.board_hash
        and snapshot.source.actor_id == state.player.actor_number and snapshot.source.controller_generation == job.generation
        and snapshot.intent.scope.plain().get('pilot_authority') == authority.identity
        and snapshot.intent.scope.plain().get('mode') == authority.context
        and snapshot.intent.scope.plain().get('input_authority') is False, 'Demon source/config mismatch')
    require(snapshot.recorded.plain()['d3_demon'] == dict(profile=authority.demon_profile.plain(),
        scope=authority.scope.plain()), 'Demon certificate/profile not bound')
    for name,field in (('hp','hp'),('max_hp','max_hp'),('rage','power'),('max_mana','max_mana'),
            ('max_rage','max_power'),('attack','attack')):
        require(snapshot.evidence('self.'+name).value.plain() == getattr(state.player,field), 'Demon stat mismatch')
    for name in ('planner.model','planner.legality'):
        ev=snapshot.evidence(name); binding=ev.scope.plain()
        require(ev.availability == 'PRESENT' and all(binding.get(k)==v for k,v in authority.scope.plain().items())
            and binding.get('profile')==authority.profile and binding.get('session_id')==snapshot.source.session_id
            and binding.get('match_id')==snapshot.source.match_id,'Demon effect scope mismatch')
    require(snapshot.evidence('planner.legality').scope.plain().get('turn')==snapshot.source.turn,
        'Demon legality turn mismatch')
    require(type(completed_ns) is int and capability.observed_ns <= job.created_ns <= completed_ns < job.deadline_ns,
        'Demon completed deadline invalid')
    require(capability.observed_ns==snapshot.recorded.plain()['observed_ns']
        and capability.remaining_ms==state.battle.turn_time_remaining_seconds*1000
        and capability.observed_ns<=snapshot.recorded.plain()['read_end_ns']<=job.created_ns,
        'Demon original observation budget changed')
    limit=authority_deadline(authority,observed_ns=capability.observed_ns,remaining_ms=capability.remaining_ms,
        slice_started_ns=job.created_ns,now_ns=job.created_ns)
    require(limit is not None and job.deadline_ns <= limit,'Demon job exceeds original budget')
    reply=_validate_reply(raw_reply,job)
    result=plan_demon(snapshot)
    require(reply.proposal==result.proposal and reply.reason==result.reason and
        json.loads(reply.summary_json)==_decision_summary(snapshot,result,None), 'Demon worker result mismatch')
    trace=None
    if reply.proposal is not None:
        value=simulate_move(state.board,reply.proposal.move)
        require(value is not None and value.total.cells(GemType.SWORD)==0,'Demon illegal/direct Sword alternative')
        trace=_candidate_trace(value,board=state.board)
    dispatch_limit=capability.observed_ns+int((capability.remaining_ms-capability.reserve_ms-authority_margin(authority))*1e6)
    return cls(job,reply,source,canonical_json(jsonable(config)),capability,completed_ns,dispatch_limit,trace)
