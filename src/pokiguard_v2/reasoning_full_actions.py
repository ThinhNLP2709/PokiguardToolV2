"""D2 conditional HT7 action comparison. Pure snapshots, no reader or executor.

Only an independently loaded D2 authority enables this path. Quantities are
structural opportunity proxies; Perfect is conditional and residual refill,
damage, healing and boss policy remain unknown. Unknown intervals are retained.
"""
from dataclasses import replace
import json
import math

from .autonomous_control import AutonomousSource
from .basic_policy import PolicyAction, PolicyDecision, _candidate_trace
from .board_diagnostics import jsonable
from .board_simulator import evaluate_all_moves, simulate_move
from .reasoning_action_candidates import (action_candidates, incumbent_action,
    ht7_perfect_first_wave, current_ht7_source_binding)
from .reasoning_snapshot import Action, FrozenJSON, Evidence, canonical_json, digest, require

from .reasoning_full_action_planner import VERSION, plan_full_actions
PROTOCOL = 'D2_HT7_FULL_ACTION_CURRENT_NATIVE_V1'
CONTEXT = 'BOUNDED_D2_HT7_FULL_ACTION_PILOT'
SOURCE_BINDING = 'CURRENT_OWNED_HT7_CARD_WITH_OPTIONAL_PET_V1'


class UnrepresentedBaseline(ValueError):
    """Expected missing comparison evidence; never grants action authority."""
    def __init__(self, baseline, choices):
        super().__init__('baseline not legally represented')
        self.details = FrozenJSON.of(dict(baseline=baseline.to_dict(),
            actions=[dict(family=c.action.family, eligible=c.eligible,
                baseline_member=c.baseline_member, reason=c.reason)
                for c in choices if c.baseline_member or c.action.family != 'swap']))


def is_full_action(authority):
    return getattr(authority, 'action_profile', None) is not None


def structural_witness(value):
    """D2 native observed only this exact optional synthesized hand entry.

    Actual skill ownership/cost/actionability come from the separate current
    capability; removing another card, duplicates or another shape is forbidden.
    """
    result=json.loads(canonical_json(value))
    if result['loadout']['config']==['normal','mega','pet_skill']:
        from .reasoning_mega import structural_witness as mega_witness
        return mega_witness(result)
    cards=result['loadout']['cards']
    optional=[0,7,'ATTACK_LEGEND_',0,0,0]
    require(cards.count(optional)<=1,'duplicate synthesized skill witness')
    result['loadout']['cards']=[card for card in cards if card!=optional]
    return result


def validate_profile(value, witness):
    require(type(value) is FrozenJSON, 'immutable D2 profile required')
    from .reasoning_mega import VERSION as MEGA_VERSION,validate_profile as validate_mega
    if value.plain().get('version')==MEGA_VERSION:
        return validate_mega(value,witness)
    require(value.plain() == dict(version=VERSION,
        account_sha256=witness.plain()['account_username_sha256'], pet_id=2035,
        skill_card_id=7, condition='PERFECT_ONLY', resource_conversion=dict(mana=30, rage=20),
        source_binding=SOURCE_BINDING),
        'explicit account-bound HT7 conditional calibration required')


def context_packet(state, config, baseline, capability, history, owner_allowed, pass_owner_allowed=True):
    """Reference-only admission on controller; enumeration happens off-thread."""
    return (state, config, baseline, capability, history, owner_allowed is True, pass_owner_allowed is True)


def pass_authority_view(state):
    battle = state.battle
    # Common autonomous identity intentionally omits this policy view. Bind it
    # locally so a completed comparison cannot outlive a PASS permission/proof
    # change on an otherwise identical board at ROOT, FRESH or FINAL.
    return dict(status=battle.consecutive_pass_status.value,
        count=battle.consecutive_passes, threshold=battle.consecutive_pass_threshold,
        source=battle.consecutive_pass_source, reset_evidence=battle.consecutive_pass_reset_evidence,
        confidence=battle.consecutive_pass_confidence, first_local_turn=battle.is_first_local_turn)


def context_hash(packet):
    state, config, baseline, cap, history, allowed, pass_allowed = packet
    data = None if cap is None else jsonable(cap)
    if data is not None:
        data.pop('observed_at', None)  # Fresh observation time is not card identity.
    return digest(dict(source=AutonomousSource.from_state(state).critical_state_hash,
        pass_authority=pass_authority_view(state),
        capability=data, history=jsonable(history), owner_allowed=allowed, pass_owner_allowed=pass_allowed))


def bind_snapshot(snapshot, packet, authority):
    from .reasoning_mega import is_mega,bind_snapshot as bind_mega
    if is_mega(authority):return bind_mega(snapshot,packet,authority)
    state, config, baseline, cap, history, allowed, pass_allowed = packet
    require(incumbent_action(baseline) == snapshot.baseline, 'incumbent family changed')
    choices = action_candidates(state, config, baseline, capability=cap,
        history=history, owner_allowed=allowed, pass_owner_allowed=pass_allowed,
        allow_current_ht7_card_source=True)
    geometry = None
    if cap is not None and cap.current and current_ht7_source_binding(cap) is not None:
        geometry = ht7_perfect_first_wave(state, cap,
            account_sha256=authority.action_profile.plain()['account_sha256'],
            allow_current_ht7_card_source=True).plain()
    if not any(c.eligible and c.baseline_member for c in choices):
        raise UnrepresentedBaseline(snapshot.baseline, choices)
    context = dict(version=VERSION, context_hash=context_hash(packet),
        choices=[dict(action=c.action.to_dict(), eligible=c.eligible, reason=c.reason,
            baseline_member=c.baseline_member, facts=c.facts.plain(), comparison=c.comparison)
            for c in choices], perfect_geometry=geometry,
        resource_conversion=authority.action_profile.plain()['resource_conversion'],
        past_success_count=next(c.facts.plain()['successful_skills_current_match'] for c in choices if c.action.family=='pet_skill'),
        exclusions=['DAMAGE_HP', 'HEAL_POINTS', 'REFILL_DISTRIBUTION',
            'BOSS_SKILL_POLICY', 'COST_GAIN_ORDER', 'POST_SKILL_BALANCE'])
    recorded = dict(snapshot.recorded.plain(), d2_actions=context)
    versions = dict(snapshot.intent.versions.plain(), full_actions=VERSION)
    pass_allowed=any(c.action.family=='pass' and c.eligible for c in choices)
    observations=tuple((name,replace(e,value=FrozenJSON.of(dict(owner='ROOT_TURN',
        swap_allowed=allowed,pass_allowed=pass_allowed,mandatory=not pass_allowed,blocked=not allowed)))
        if name=='planner.legality' else e) for name,e in snapshot.observations)
    return replace(snapshot, recorded=FrozenJSON.of(recorded), observations=observations,
        intent=replace(snapshot.intent, versions=FrozenJSON.of(versions)))


def current_action_allowed(action, packet):
    state, config, baseline, cap, history, allowed, pass_allowed = packet
    if config.play_style.value=='mega_icarus_spam_skill':
        from .reasoning_mega import action_allowed
        return action_allowed(action,packet)
    if not allowed:
        return False
    if action.family == 'swap':
        return state.board.production_ready and state.battle.is_local_turn is True
    return any(c.eligible and c.action == action for c in action_candidates(state, config, baseline,
        capability=cap, history=history, owner_allowed=allowed, enumerate_swaps=False,
        pass_owner_allowed=pass_allowed, allow_current_ht7_card_source=True))


def apply_action(baseline, action, state, packet, candidate=None):
    require(current_action_allowed(action, packet), 'current family authority missing')
    cap = packet[3]
    family = {'swap':PolicyAction.SWAP,'pet_skill':PolicyAction.PET_SKILL,'pass':PolicyAction.PASS}[action.family]
    mega=packet[1].play_style.value=='mega_icarus_spam_skill'
    trace = replace(baseline.trace, selected_action=family,
        policy_step=('REASONING_D4_' if mega else 'REASONING_D2_')+action.family.upper(), selected_candidate=candidate,
        why_selected='Bound conditional full-action proxy improvement; tactical threshold advisory',
        blocker=None, skill_fire_trigger=('REASONING_D4_SEAL_PROXY' if mega else 'REASONING_D2_CONDITIONAL') if family is PolicyAction.PET_SKILL else None,
        required_mana=None if cap is None else cap.effective_mana_cost,
        required_rage=None if cap is None else cap.effective_power_cost,
        current_mana=state.player.mana, current_rage=state.player.power,
        pet_skill_candidate=family is PolicyAction.PET_SKILL,
        skipped_current_sword_for_resource=False,
        selected_move_left_direct_boss_sword=bool(candidate and candidate.opponent_sword_replies),
        selected_move_left_indirect_boss_sword=bool(candidate and candidate.indirect_sword_replies))
    return PolicyDecision(family, trace, move=action.move,
        skill_card_id=(cap.skill_card_id if family is PolicyAction.PET_SKILL else None),
        skill_session_key=(state.battle.session_key if family is PolicyAction.PET_SKILL else None),
        consumes_turn=family is not PolicyAction.PASS, requires_state_reread=True)


def publish_context_safely(adapter, state, config, baseline, capability, history, owner_allowed, pass_owner_allowed=True):
    if not is_full_action(getattr(adapter,'pilot_authority',None)):
        return
    try:
        adapter.action_context = context_packet(state, config, baseline, capability, history, owner_allowed, pass_owner_allowed)
    except Exception:
        adapter.disabled = True
        try:
            adapter._record('D2_CONTEXT_FAILURE', 'CONTEXT', __import__('time').perf_counter_ns())
        except Exception:
            pass


def prepare_completed(cls, *, job, raw_reply, state, config, capability, completed_ns):
    """Off-controller validation: recompute the entire small, pure comparison.

    Never trust worker-supplied utility, cost, family, legality or attribution.
    This duplication is included in D2 qualification and the same deadline.
    """
    from .reasoning_runner import _validate_reply, _decision_summary
    from .reasoning_operational import authority_deadline, authority_margin
    reply = _validate_reply(raw_reply, job)
    a = capability.pilot_authority
    packet = capability.action_context
    require(is_full_action(a) and packet is not None, 'full-action capability required')
    snapshot = job.snapshot
    source = AutonomousSource.from_state(state)
    from .reasoning_mega import is_mega
    expected_profile='mega_icarus_spam_skill' if is_mega(a) else 'skill_rush'
    require(a.matches(state, config) and capability.profile == config.play_style.value == expected_profile, 'full-action cohort changed')
    require(snapshot.intent.settings.text == canonical_json(jsonable(config)) == a.policy_json,
        'D2 policy not bound')
    require(snapshot.board_state() == state.board and snapshot.source.match_id == state.battle.match_id
        and snapshot.source.session_id == canonical_json(jsonable(state.battle.session_key))
        and snapshot.source.turn == state.battle.turn_number and snapshot.source.srv_seq == state.battle.srv_seq
        and snapshot.source.board_hash == state.battle.board_hash
        and snapshot.source.actor_id == state.player.actor_number
        and snapshot.source.controller_generation == job.generation
        and snapshot.recorded.plain()['controller_source_hash'] == source.critical_state_hash,
        'D2 source not bound')
    scope = snapshot.intent.scope.plain()
    require(scope.get('mode') == a.context and scope.get('pilot_authority') == a.identity
        and scope.get('input_authority') is False, 'D2 scope not bound')
    require(snapshot.baseline == incumbent_action(packet[2])
        and packet[1] == config
        and context_hash(packet) == snapshot.recorded.plain()['d2_actions']['context_hash']
        and pass_authority_view(packet[0]) == pass_authority_view(state)
        and AutonomousSource.from_state(packet[0]) == source, 'D2 action context changed')
    rebound=bind_snapshot(snapshot,packet,a)
    require(rebound.recorded == snapshot.recorded and rebound.observations == snapshot.observations
        and snapshot.evidence('planner.model').value == a.model, 'D2 derived eligibility/effect geometry changed')
    for name, field in (('hp','hp'),('max_hp','max_hp'),('mana','mana'),('rage','power')):
        require(snapshot.evidence('self.'+name).value.plain() == getattr(state.player,field), 'D2 stats changed')
    expected = plan_full_actions(snapshot)
    require(reply.proposal == expected.proposal and reply.reason == expected.reason
        and json.loads(reply.summary_json) == _decision_summary(snapshot,expected,None), 'worker comparison not reproducible')
    limit = authority_deadline(a, observed_ns=capability.observed_ns,
        remaining_ms=capability.remaining_ms, slice_started_ns=job.created_ns, now_ns=job.created_ns)
    require(type(completed_ns) is int and capability.observed_ns <= job.created_ns <= completed_ns < job.deadline_ns
        and limit is not None and job.deadline_ns <= limit, 'D2 completed outside deadline')
    trace = None
    if reply.proposal is not None:
        require(current_action_allowed(reply.proposal,packet), 'D2 proposal not eligible')
        if reply.proposal.family == 'swap':
            evaluation = simulate_move(state.board,reply.proposal.move)
            require(evaluation is not None,'D2 swap illegal')
            trace = _candidate_trace(evaluation,board=state.board)
    dispatch_limit = capability.observed_ns + int((capability.remaining_ms-capability.reserve_ms-authority_margin(a))*1e6)
    return cls(job,reply,source,canonical_json(jsonable(config)),capability,completed_ns,dispatch_limit,trace)
