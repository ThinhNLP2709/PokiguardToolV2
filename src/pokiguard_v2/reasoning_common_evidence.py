"""Publish common facts from an already supplied controller packet only.

No provider, memory, screenshot, input, QTE or timing measurement is called.
Actual owner/cost/cooldown/PASS evidence stays distinct from tactical settings.
"""
import hashlib
from dataclasses import fields
from functools import lru_cache
from .autonomous_control import AutonomousSource
from .basic_policy import PolicyAction,SkillRushMatchContext
from .board_diagnostics import jsonable
from .game_owned_idle import ResetConfidence
from .gameplay_profile import DamageCardMode
from .pet_skill_shadow import PetSkillCapability,PetSkillCostSource
from .reasoning_action_candidates import current_ht7_source_binding
from .reasoning_common_problem import CommonProblem,CommonIntent,EffectChoice,VERSION
from .reasoning_common_models import AUTO_GEOMETRY,AUTO_DISCOUNT,demon_effect,demon_strategy
from .reasoning_full_actions import pass_authority_view
from .reasoning_mega import current_source_binding as current_mega_source,seal_geometry
from .reasoning_snapshot import Action,FrozenJSON,SourceIdentity,SourceRecord,canonical_json,digest,require
from .state import GameOwnedIdleStatus,GamePhase,GemType


def incumbent_action(decision):
    family={PolicyAction.SWAP:'swap',PolicyAction.PET_SKILL:'pet_skill',PolicyAction.PASS:'pass',
        PolicyAction.CAST:'cast',PolicyAction.EVOLVE:'evolve'}.get(decision.action,'none')
    if family=='swap':return Action(family,decision.move)
    if family=='pet_skill':
        return Action(family,card_source=canonical_json(dict(session=jsonable(decision.skill_session_key),card_id=decision.skill_card_id)))
    if family=='cast':return Action(family,card_source=canonical_json(dict(card_object_address=decision.card_object_address)))
    return Action(family)


def packet(state,config,baseline,capability,history,owner_allowed,pass_owner_allowed=True):
    return (state,config,baseline,capability,history,owner_allowed is True,pass_owner_allowed is True)


@lru_cache(maxsize=64)
def policy_json(config):
    return canonical_json(jsonable(config))


@lru_cache(maxsize=64)
def _capability_hash(view):
    return digest(jsonable(view))


def packet_hash(value):
    # Same established source/capability/history/PASS fields. Cache immutable
    # capability/config serialization only; source and PASS are checked afresh.
    return _packet_hash(value,AutonomousSource.from_state(value[0]).critical_state_hash)


def _packet_hash(value,current_critical_hash):
    """Use a source already recomputed at this checkpoint, not a source cache."""
    state,config,baseline,cap,history,owner,pass_owner=value
    require(cap is None or type(cap) is PetSkillCapability,'untyped capability packet')
    view=None if cap is None else tuple((f.name,getattr(cap,f.name)) for f in fields(cap) if f.name!='observed_at')
    return digest(dict(source=current_critical_hash,
        pass_authority=pass_authority_view(state),capability=_capability_hash(view),history=jsonable(history),
        owner_allowed=owner,pass_owner_allowed=pass_owner,config=policy_json(config)))


def pass_evidence(state,root,owner_allowed):
    b=state.battle
    reset=(b.consecutive_pass_status is GameOwnedIdleStatus.RESET_BASELINE_CONFIRMED
        and b.consecutive_passes is None and b.consecutive_pass_threshold is None
        and b.consecutive_pass_source=='accepted_consuming_reset_baseline'
        and bool(b.consecutive_pass_reset_evidence) and b.consecutive_pass_confidence in (
            ResetConfidence.RESET_CONFIRMED_EXPLICIT.value,ResetConfidence.RESET_CONFIRMED_BY_SERVER_SEQUENCE.value))
    counter=(b.consecutive_pass_status is GameOwnedIdleStatus.PASS_ALLOWED
        and type(b.consecutive_passes) is int and type(b.consecutive_pass_threshold) is int
        and bool(b.consecutive_pass_source) and b.consecutive_pass_threshold>0
        and 0<=b.consecutive_passes<b.consecutive_pass_threshold-1)
    allowed=root and owner_allowed is True and b.is_first_local_turn is False and (reset or counter)
    return EffectChoice(Action('pass'),bool(allowed),
        'CURRENT_PASS_OWNER_AND_SERVER_PROOF' if allowed else 'PASS_OWNER_OR_SERVER_PROOF_UNAVAILABLE',
        (), 'UNCHANGED_BOARD','VERIFIED_FOR_SCOPE',facts=FrozenJSON.of(dict(
            count=b.consecutive_passes,threshold=b.consecutive_pass_threshold,status=b.consecutive_pass_status.value,
            source=b.consecutive_pass_source,confidence=b.consecutive_pass_confidence,
            reset_evidence=b.consecutive_pass_reset_evidence,first_local_turn=b.is_first_local_turn)))


def root_allowed(value):
    state,config,base,cap,history,owner,pass_owner=value
    history_current=type(history) is SkillRushMatchContext and history.session_key==state.battle.session_key
    closed=(history_current and history.latest_success_source_turn is not None
        and (type(state.battle.turn_number) is not int or state.battle.turn_number<=history.latest_success_source_turn))
    return bool(owner and not closed and state.phase is GamePhase.COMBAT and state.battle.is_local_turn is True
        and state.battle.session_key is not None and state.player is not None and state.player.is_local is True
        and type(state.player.hp) is int and state.player.hp>0 and state.board.production_ready)


def skill_evidence(value,root):
    state,config,base,cap,history,owner,pass_owner=value
    known_cap=type(cap) is PetSkillCapability
    card=cap.skill_card_id if known_cap else None
    action=Action('pet_skill',card_source=canonical_json(dict(session=jsonable(state.battle.session_key),card_id=card)))
    reason='SKILL_CAPABILITY_MISSING';model='UNKNOWN';cleared=None;source=None;costs=(None,None)
    if type(cap) is PetSkillCapability:
        costs=(cap.effective_mana_cost,cap.effective_power_cost)
        source=current_ht7_source_binding(cap) or current_mega_source(cap)
        if not root:reason='EXISTING_OWNER_OR_STATE_BLOCKED'
        elif config.damage_card is not DamageCardMode.PET_SKILL:reason='CONFIGURED_DAMAGE_SOURCE_IS_NOT_PET_SKILL'
        elif not cap.current or cap.session_key!=state.battle.session_key:reason='SKILL_SOURCE_NOT_CURRENT'
        elif source is None:reason='SKILL_EFFECT_SOURCE_UNMODELED'
        elif not cap.live_card_present or cap.live_card_actionable is not True:reason='SKILL_NOT_ACTIONABLE'
        elif (cap.card_id!=cap.skill_card_id or cap.effective_mana_cost_source is not PetSkillCostSource.CONDITION_USE
                or cap.effective_power_cost_source is not PetSkillCostSource.POWER):reason='ACTUAL_COST_SOURCE_UNKNOWN'
        elif any(type(n) is not int or n<0 for n in costs) or type(cap.cooldown_turns) is not int:reason='ACTUAL_COST_OR_COOLDOWN_UNKNOWN'
        elif cap.cooldown_turns!=0:reason='SKILL_ON_COOLDOWN'
        elif (type(state.player.mana) is not int or type(state.player.power) is not int
                or state.player.mana<costs[0] or state.player.power<costs[1]):reason='SKILL_RESOURCES_INSUFFICIENT'
        else:
            reason='CURRENT_OWNED_MODELED_SKILL_AVAILABLE'
            if current_ht7_source_binding(cap):
                cleared=tuple((c.row,c.col) for row in state.board.cells for c in row
                    if c.gem in (GemType.SWORD,GemType.RAGE,GemType.HEALTH))
                model='USER_CONDITIONAL_HT7_PERFECT_FIRST_WAVE'
            else:
                cleared=tuple(tuple(p) for p in seal_geometry(state.board)['original_cells'])
                model='USER_CONDITIONAL_MEGA_SEAL_FIRST_WAVE'
    return EffectChoice(action,reason=='CURRENT_OWNED_MODELED_SKILL_AVAILABLE',reason,cleared,model,
        'USER_CALIBRATED' if cleared is not None else 'UNKNOWN',*costs,
        FrozenJSON.of(dict(source_binding=source,skill_card_id=card,
            actionability=cap.live_card_actionable if known_cap else None,
            cooldown=cap.cooldown_turns if known_cap else None,
            actual_costs=dict(mana=costs[0],rage=costs[1]),
            self_heal_present=bool(cleared is not None and known_cap and current_mega_source(cap)),
            self_heal_provenance='USER_DECLARATION_MEGA_ICARUS_HEALS_AMOUNT_UNKNOWN'
                if cleared is not None and known_cap and current_mega_source(cap) else None,
            post_cost_gain_order='UNKNOWN',QTE_executor='UNCHANGED_EXISTING_OWNER')))


def _stats(actor):
    if actor is None:return {}
    return {name:getattr(actor,field) for name,field in (
        ('hp','hp'),('max_hp','max_hp'),('mana','mana'),('max_mana','max_mana'),
        ('rage','power'),('max_rage','max_power'),('shield','shield'),('attack','attack'))}


def build_problem(value,*,run_id,generation,observed_ns,read_end_ns,demon_geometry=AUTO_GEOMETRY,
                  conversion=None,operator_demon_rage_discount=AUTO_DISCOUNT,demon_damage_model=None):
    state,config,baseline,cap,history,owner,pass_owner=value
    require(type(observed_ns) is int and type(read_end_ns) is int and 0<=observed_ns<=read_end_ns,
        'invalid observation interval')
    require(state.player is not None and state.battle.session_key is not None,'current local identity required')
    source=AutonomousSource.from_state(state);action=incumbent_action(baseline)
    identity=SourceIdentity(run_id,canonical_json(jsonable(state.battle.session_key)),state.battle.match_id,
        state.battle.turn_number,state.battle.srv_seq,state.battle.board_hash,state.player.actor_number,generation)
    root=root_allowed(value)
    boss=next((p for p in state.opponents if p.is_boss is True),None)
    opponent=boss or next(iter(state.opponents),None)
    current_history=type(history) is SkillRushMatchContext and history.session_key==state.battle.session_key
    geometry,effect_evidence=demon_effect(config,demon_geometry)
    rates,discount,strategy=demon_strategy(config,geometry,conversion,operator_demon_rage_discount)
    effects=[skill_evidence(value,root),pass_evidence(state,root,pass_owner)]
    if action.family=='cast':effects.append(EffectChoice(action,root,'INCUMBENT_CAST_EFFECT_UNMODELED',None,'UNKNOWN','UNKNOWN'))
    requirements={}
    if (config.damage_card is DamageCardMode.PET_SKILL and type(cap) is PetSkillCapability
            and cap.current and cap.session_key == state.battle.session_key
            and cap.skill_card_id is not None and cap.card_id == cap.skill_card_id):
        if (cap.effective_mana_cost_source is PetSkillCostSource.CONDITION_USE
                and type(cap.effective_mana_cost) is int and cap.effective_mana_cost >= 0):
            requirements['mana']=cap.effective_mana_cost
        if (cap.effective_power_cost_source is PetSkillCostSource.POWER
                and type(cap.effective_power_cost) is int and cap.effective_power_cost >= 0):
            requirements['rage']=cap.effective_power_cost
    fusion=state.fusion
    evolution=dict(pending=bool(config.evolution.value!='none' and fusion is not None and fusion.enabled and not fusion.used),
        mana_cost=None if fusion is None else fusion.mana_cost,source='EXISTING_FUSION_STATE')
    facts=dict(root_allowed=root,pending=False,self=_stats(state.player),opponent=_stats(opponent),
        conversion=rates,resource_requirements=requirements,demon_strategy=strategy,evolution=evolution,
        demon_damage_model=demon_damage_model,damage_session=canonical_json(jsonable(state.battle.session_key)),
        demon_geometry=geometry,demon_effect=effect_evidence,operator_demon_rage_discount=discount,
        past_skill_successes=history.successful_pet_skills if current_history else 0,
        boss_policy='USER_CONDITIONAL_MAX_EFFECTIVE_SWORD' if boss is not None else 'UNKNOWN_ALL_KNOWN_ALTERNATIVES',
        context_hash=packet_hash(value),controller_source_hash=source.critical_state_hash,
        observed_ns=observed_ns,read_end_ns=read_end_ns,
        raw_remaining_seconds=state.battle.turn_time_remaining_seconds,timer_source=state.battle.turn_timer_source,
        account_sha256=None if state.battle.local_username is None else hashlib.sha256(
            state.battle.local_username.casefold().encode()).hexdigest(),
        provenance='EXISTING_STATE_AND_OWNER_PACKET_ONLY_NO_EXTRA_READ')
    board=tuple(tuple((c.gem.value,c.multiplier) for c in row) for row in state.board.cells)
    intent=CommonIntent(config.play_style.value,FrozenJSON.of(jsonable(config)),
        FrozenJSON.of(dict(engine=VERSION)),FrozenJSON.of(dict(kind='COMMON_STRUCTURAL_MODEL_NOT_DAMAGE_AUTHORITY')))
    key=digest(dict(source=identity.to_dict(),board=board,config=intent.to_dict(),baseline=action.to_dict(),facts=facts))
    return CommonProblem(identity,SourceRecord('captured/common/'+key+'.json',1,key,key),intent,board,action,
        baseline.trace.why_selected or 'EXISTING_BASIC_INCUMBENT',FrozenJSON.of(facts),tuple(effects))
