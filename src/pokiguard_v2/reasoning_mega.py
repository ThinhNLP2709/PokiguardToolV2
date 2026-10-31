"""Mega action comparison over existing immutable state. No IO or input.

Seal opportunities and visible replies are structural proxies. HP damage,
healing, refill, boss cards and post-skill resource order remain UNKNOWN.
"""
from dataclasses import replace

from .basic_policy import PolicyAction, PlayStyle, SkillRushMatchContext
from .board_diagnostics import jsonable
from .board_simulator import (evaluate_all_moves, _candidate_swaps, _copy_grid,
    _collapse, _matches_touching, _tallies, _resolve_known_reply, _freeze)
from .mega_icarus import MEGA_ICARUS_SEAL_CELLS, count_seal_gems
from .pet_skill_shadow import PetSkillCapability, PetSkillFamily, PetSkillTargetMode, PetSkillCostSource
from .reasoning_action_candidates import ActionEvidence, incumbent_action
from .reasoning_snapshot import Action, FrozenJSON, canonical_json, require
from .state import GamePhase, GameOwnedIdleStatus, GemType
from .game_owned_idle import ResetConfidence

VERSION='5d4.mega_full_actions.v1'
PROTOCOL='D4_MEGA_FULL_ACTION_CURRENT_NATIVE_V1'
CONTEXT='BOUNDED_D4_MEGA_FULL_ACTION_PILOT'
SOURCE_BINDING='CURRENT_OWNED_MEGA_CARD_OPTIONAL_VERIFIED_PET_V1'
EXCLUSIONS=['DAMAGE_HP','HEAL_POINTS','REFILL_DISTRIBUTION','BOSS_SKILL_POLICY',
    'COST_GAIN_ORDER','POST_SKILL_BALANCE','GUARANTEED_SURVIVAL']


def is_mega(authority):
    profile=getattr(authority,'action_profile',None)
    return (getattr(authority,'profile',None)=='mega_icarus_spam_skill'
        and type(profile) is FrozenJSON and profile.plain().get('version')==VERSION)


def profile_for(witness):
    return dict(version=VERSION,account_sha256=witness['account_username_sha256'],
        pet_id=2524,skill_card_id=22,source_binding=SOURCE_BINDING,
        condition='ACCEPTED_SEAL_30_KNOWN_GEM_OPPORTUNITIES',
        resource_conversion=dict(mana=30,rage=20))


def validate_profile(value,witness):
    require(type(value) is FrozenJSON and value.plain()==profile_for(witness.plain()),
        'explicit account-bound Mega seal profile required')


def structural_witness(value):
    # No card stripping: the reviewed Mega native hand witness has no optional
    # Attack/HT7 entries. Actual skill ownership is attested separately.
    require(value['loadout']['config']==['normal','mega','pet_skill']
        and value['loadout']['cards']==[], 'exact observed Mega loadout required')
    return value


def current_source_binding(cap):
    if (type(cap) is not PetSkillCapability or not cap.current
        or cap.skill_card_id!=22 or cap.card_id!=22
        or cap.skill_family is not PetSkillFamily.MEGA_ICARUS_CLICK_ONLY
        or cap.target_mode is not PetSkillTargetMode.AUTOMATIC
        or cap.source!='CARD_UI_BUTTON' or not cap.live_card_present
        or any(type(v) is not int or v<=0 for v in
            (cap.card_data_address,cap.live_card_address,cap.live_button_address))):
        return None
    if (cap.pet_id,cap.source_pet_skill_card_id) not in ((None,None),(2524,None),(2524,22)):
        return None
    return 'CURRENT_OWNED_MEGA_CARD_PET_UNKNOWN' if cap.pet_id is None else 'CURRENT_OWNED_MEGA_CARD_AND_VERIFIED_PET'


def root_allowed(state,cap,history,owner_allowed):
    history_current=type(history) is SkillRushMatchContext and history.session_key==state.battle.session_key
    closed=(history_current and history.latest_success_source_turn is not None
        and (type(state.battle.turn_number) is not int or state.battle.turn_number<=history.latest_success_source_turn))
    return bool(owner_allowed is True and history_current and not closed and current_source_binding(cap) is not None
        and cap.session_key==state.battle.session_key and state.phase is GamePhase.COMBAT
        and state.battle.is_local_turn is True and state.player is not None
        and state.player.is_local is True and type(state.player.hp) is int and state.player.hp>0
        and state.board.production_ready)


def choices(state,config,baseline,cap,history,owner_allowed,pass_owner_allowed,*,enumerate_swaps=True):
    require(config.play_style is PlayStyle.MEGA_ICARUS_SPAM_SKILL,'Mega evidence only')
    require(config.pet_skill_fire_condition.value=='sword_count','only reviewed Sword seal objective')
    old=incumbent_action(baseline)
    history_current=type(history) is SkillRushMatchContext and history.session_key==state.battle.session_key
    source=current_source_binding(cap)
    root=root_allowed(state,cap,history,owner_allowed)
    result=[]
    for v in (evaluate_all_moves(state.board) if enumerate_swaps else ()):
        action=Action('swap',v.move)
        result.append(ActionEvidence(action,root,'KNOWN_LEGAL_SWAP' if root else 'MEGA_CONTEXT_NOT_CURRENT',
            action==old,FrozenJSON.of({}),'MEGA_STRUCTURAL_PROXY'))
    counts=count_seal_gems(state.board,GemType.SWORD)
    costs=None if cap is None else dict(mana=cap.effective_mana_cost,rage=cap.effective_power_cost)
    facts=dict(actual_costs=costs,current_mana=None if state.player is None else state.player.mana,
        current_rage=None if state.player is None else state.player.power,source_binding=source,
        advisory_fire_value=config.pet_skill_fire_value,seal_physical=counts.physical,
        seal_effective=counts.effective,condition_scope='MEGA_ICARUS_SEAL_30',
        successful_skills_current_match=history.successful_pet_skills if history_current else None,
        skill_family=None if cap is None else cap.skill_family.value,actual_heal_points='UNKNOWN')
    reason='MEGA_CONTEXT_NOT_CURRENT'
    if root:
        reason='MEGA_CURRENT_CARD_NOT_ACTIONABLE'
        if cap.live_card_actionable is True:
            reason='MEGA_COST_OR_COOLDOWN_UNPROVEN'
            if (cap.effective_mana_cost_source is PetSkillCostSource.CONDITION_USE
                and cap.effective_power_cost_source is PetSkillCostSource.POWER
                and all(type(v) is int and v>=0 for v in costs.values())
                and type(cap.cooldown_turns) is int and cap.cooldown_turns==0):
                reason='MEGA_RESOURCES_INSUFFICIENT'
                if (type(state.player.mana) is int and type(state.player.power) is int
                    and state.player.mana>=costs['mana'] and state.player.power>=costs['rage']):
                    reason='CURRENT_MEGA_SEAL_CLICK_ONLY'
    skill=Action('pet_skill',card_source=canonical_json(dict(session=jsonable(state.battle.session_key),
        card_id=None if cap is None else cap.skill_card_id)))
    result.append(ActionEvidence(skill,reason=='CURRENT_MEGA_SEAL_CLICK_ONLY',reason,
        skill==old,FrozenJSON.of(facts),'SEAL_30_CONDITIONAL_STRUCTURAL_PROXY'))
    b=state.battle
    reset=(b.consecutive_pass_status is GameOwnedIdleStatus.RESET_BASELINE_CONFIRMED
        and b.consecutive_passes is None and b.consecutive_pass_threshold is None
        and b.consecutive_pass_source=='accepted_consuming_reset_baseline'
        and bool(b.consecutive_pass_reset_evidence) and b.consecutive_pass_confidence in
        (ResetConfidence.RESET_CONFIRMED_EXPLICIT.value,ResetConfidence.RESET_CONFIRMED_BY_SERVER_SEQUENCE.value))
    counter=(b.consecutive_pass_status is GameOwnedIdleStatus.PASS_ALLOWED
        and type(b.consecutive_passes) is int and type(b.consecutive_pass_threshold) is int
        and bool(b.consecutive_pass_source) and b.consecutive_pass_threshold>0
        and 0<=b.consecutive_passes<b.consecutive_pass_threshold-1)
    eligible=root and pass_owner_allowed is True and (reset or counter) and b.is_first_local_turn is False
    action=Action('pass')
    result.append(ActionEvidence(action,bool(eligible),'EXISTING_AUTHORITATIVE_PASS' if eligible
        else 'PASS_NOT_AUTHORITATIVELY_ALLOWED',action==old,FrozenJSON.of(dict(
            count=b.consecutive_passes,threshold=b.consecutive_pass_threshold,status=b.consecutive_pass_status.value,
            source=b.consecutive_pass_source,reset_evidence=b.consecutive_pass_reset_evidence,
            confidence=b.consecutive_pass_confidence,automatic_wait_owner=True))))
    return tuple(result)


def _seal_count(grid):
    return sum(grid[r][c].multiplier for r,c in MEGA_ICARUS_SEAL_CELLS if grid[r][c].gem is GemType.SWORD)


def reply_view(grid):
    """All known legal replies; all maximum-Sword ties and adverse others kept."""
    replies=[]
    for move in _candidate_swaps():
        resolved=_resolve_known_reply([list(row) for row in grid],move)
        if resolved is not None:
            direct,cascade,rounds,after=resolved
            replies.append(dict(move=[list(move.first),list(move.second)],
                sword=direct.effective(GemType.SWORD)+cascade.effective(GemType.SWORD),
                seal=_seal_count(after)))
    maximum=max((r['sword'] for r in replies),default=0)
    nominal=[r for r in replies if r['sword']==maximum] if maximum else replies
    return dict(known_sword_reply_max=maximum,known_legal_reply_count=len(replies),
        nominal_tie_count=len(nominal),nominal_policy='MAX_EFFECTIVE_SWORD_WORKING_MODEL_SECONDARY_UNKNOWN',
        nominal_seal_floor=min((r['seal'] for r in nominal),default=_seal_count(grid)),
        adverse_seal_floor=min((r['seal'] for r in replies),default=_seal_count(grid)),
        coverage='ALL_KNOWN_LEGAL_REPLIES_NO_REFILL_OR_BOSS_CARD_POLICY')


def seal_geometry(board):
    grid=_copy_grid(board);first=_tallies(grid,MEGA_ICARUS_SEAL_CELLS)
    displaced=_collapse(grid,set(MEGA_ICARUS_SEAL_CELLS));current,_=_matches_touching(grid,displaced)
    # Only deterministic known collapses; no favorable refill or HP credit.
    rounds=0
    while current:
        displaced=_collapse(grid,current);current,_=_matches_touching(grid,displaced);rounds+=1
        require(rounds<=21,'known collapse failed to converge')
    return dict(original_cells=[list(c) for c in MEGA_ICARUS_SEAL_CELLS],
        quantities={g.value:dict(physical=first.cells(g),effective=first.effective(g)) for g in GemType if g is not GemType.UNKNOWN},
        post_reply=reply_view(grid),unknown_cells=sum(c.gem is GemType.UNKNOWN for row in grid for c in row),
        remaining_known_seal=_seal_count(grid),known_cascade_rounds=rounds,
        effect_scope='ACCEPTED_SEAL_30_FIRST_WAVE_ONLY_NO_CASCADE_RESOURCE_CREDIT',
        scope=dict(version=VERSION,geometry='EXISTING_MEGA_ICARUS_SEAL_CELLS',cells=30,
            damage='UNKNOWN',healing='UNKNOWN',post_skill_balance='UNKNOWN'))


def bind_snapshot(snapshot,packet,authority):
    from .reasoning_full_actions import context_hash,UnrepresentedBaseline
    state,config,baseline,cap,history,allowed,pass_allowed=packet
    require(incumbent_action(baseline)==snapshot.baseline,'Mega incumbent changed')
    actions=choices(state,config,baseline,cap,history,allowed,pass_allowed)
    if not any(c.eligible and c.baseline_member for c in actions):raise UnrepresentedBaseline(snapshot.baseline,actions)
    context=dict(version=VERSION,context_hash=context_hash(packet),
        choices=[dict(action=c.action.to_dict(),eligible=c.eligible,reason=c.reason,
            baseline_member=c.baseline_member,facts=c.facts.plain()) for c in actions],
        seal_geometry=seal_geometry(state.board),exclusions=EXCLUSIONS,
        resource_conversion=authority.action_profile.plain()['resource_conversion'],
        advisory_seal_target=config.pet_skill_fire_value,conditional_perfect=False)
    recorded=dict(snapshot.recorded.plain(),d2_actions=context)
    observations=tuple((name,replace(e,value=FrozenJSON.of(dict(owner='ROOT_TURN',swap_allowed=allowed,
        pass_allowed=any(c.eligible and c.action.family=='pass' for c in actions),mandatory=not pass_allowed,
        blocked=not allowed))) if name=='planner.legality' else e) for name,e in snapshot.observations)
    return replace(snapshot,recorded=FrozenJSON.of(recorded),observations=observations,
        intent=replace(snapshot.intent,versions=FrozenJSON.of(dict(snapshot.intent.versions.plain(),full_actions=VERSION))))


def action_allowed(action,packet):
    s,c,b,cap,h,allowed,pass_allowed=packet
    if not allowed:return False
    if action.family=='swap':
        # Legality was exhaustively recomputed off-thread; cheap current-context
        # checks remain on ROOT/FRESH/FINAL, never another search/read.
        return root_allowed(s,cap,h,allowed)
    return any(v.eligible and v.action==action for v in choices(s,c,b,cap,h,allowed,pass_allowed,enumerate_swaps=False))


def plan(snapshot):
    from .reasoning_planner import Bound,PlannerDecision,FEATURES,clip,score_candidate,order_key
    ctx=snapshot.recorded.plain()['d2_actions'];require(ctx['version']==VERSION,'Mega context required')
    require(snapshot.intent.profile=='mega_icarus_spam_skill','Mega intent required')
    hp=snapshot.evidence('self.hp').value.plain();maximum=snapshot.evidence('self.max_hp').value.plain()
    require(type(hp) is int and type(maximum) is int and 0<hp<=maximum,'current HP required')
    board=snapshot.board_state();values=evaluate_all_moves(board)
    by_move={canonical_json(Action('swap',v.move).to_dict()):v for v in values}
    threat=clip(max((v.sword_effective for v in values),default=0)/8)
    hp_deficit=1-hp/maximum
    pressure_lo=clip(hp_deficit+.15*threat);pressure_hi=pressure_lo
    boss_load_lo=boss_load_hi=0
    for name,capname,scale in (('rage','max_rage',.15),('mana','max_mana',.10)):
        v=snapshot.evidence('boss.'+name).value.plain();cap=snapshot.evidence('boss.'+capname).value.plain()
        if type(v) is int and type(cap) is int and v>=0 and cap>0:
            pressure_lo+=scale*clip(v/cap);pressure_hi+=scale*clip(v/cap)
            boss_load_lo+=clip(v/cap)/2;boss_load_hi+=clip(v/cap)/2
        else:
            pressure_hi+=scale;boss_load_hi+=.5
    pressure_lo,pressure_hi=clip(pressure_lo),clip(pressure_hi)
    weights={k:Bound.fixed(0) for k in FEATURES}
    weights.update(R=Bound.fixed(4),D=Bound.fixed(2),P=Bound(2+8*pressure_lo,2+8*pressure_hi,'BOUNDED','CONTINUOUS_HP_AND_VISIBLE_RESOURCE_PRESSURE_PROXY'),
        H=Bound(5-2.5*pressure_hi,5-2.5*pressure_lo,'BOUNDED','ADVISORY_SEAL_SETUP_OPPORTUNITY'),
        T=Bound(5+6*pressure_lo,5+6*pressure_hi,'BOUNDED','VISIBLE_SWORD_REPLY_PRESSURE_NOT_DAMAGE'),X=Bound.fixed(3),L=Bound.fixed(1),E=Bound.fixed(1))
    skillfacts=next(c['facts'] for c in ctx['choices'] if c['action']['family']=='pet_skill')
    target=ctx['advisory_seal_target'];require(type(target) is int and target>0,'positive advisory seal target required')
    scores=[];excluded=[]
    for choice in ctx['choices']:
        action=Action.from_dict(choice['action'])
        if not choice['eligible']:
            excluded.append(dict(action=action.to_dict(),reason=choice['reason']));continue
        f={k:Bound.fixed(0) for k in FEATURES};details=dict(action_scope=VERSION,settings_are_advisory=True,
            actual_damage_survival='UNKNOWN',actual_heal_points='UNKNOWN',future_credit=0,
            pressure_interval=[pressure_lo,pressure_hi],no_hard_hp_cutoff=True,excluded_effects=EXCLUSIONS)
        if action.family=='swap':
            v=by_move.get(canonical_json(action.to_dict()));require(v is not None,'illegal Mega swap')
            totals={g.value:v.total.effective(g) for g in GemType if g is not GemType.UNKNOWN}
            view=reply_view(v.result);unknown=v.unknown_exposure.cells;seal=_seal_count(v.result)
            costs=skillfacts['actual_costs'];progress=[]
            for name,current in (('mana',skillfacts['current_mana']),('rage',skillfacts['current_rage'])):
                cost=None if costs is None else costs[name]
                if type(cost) is not int or type(current) is not int or min(cost,current)<0:progress=None;break
                progress.append(min(max(0,cost-current),totals[name]*ctx['resource_conversion'][name])/max(1,cost))
            f['R']=Bound.missing('ACTUAL_RESOURCE_DEFICIT_UNPROVEN') if progress is None else Bound.fixed(sum(progress)/2)
            f['E']=Bound.fixed(.4,'TWO_CLICK_EXECUTION_DEMAND')
            details.update(ledger=dict(totals=totals,coverage='EXISTING_SOLVER_KNOWN_CASCADES'),resources=totals)
        elif action.family=='pet_skill':
            geometry=ctx['seal_geometry'];totals={g:v['effective'] for g,v in geometry['quantities'].items()}
            view=geometry['post_reply'];unknown=geometry['unknown_cells'];seal=geometry['remaining_known_seal']
            f['E']=Bound.fixed(.2,'EXISTING_SINGLE_CLICK_NO_QTE')
            f['L']=Bound.fixed(sum(min(1,skillfacts['actual_costs'][name]/max(1,skillfacts['current_'+name]))
                for name in ('mana','rage'))/2,'CURRENT_RESOURCE_COMMITMENT_NOT_NET_POST_SKILL_BALANCE')
            details.update(ledger=dict(totals=geometry['quantities'],original_cells=geometry['original_cells'],
                coverage=geometry['effect_scope']),costs=skillfacts['actual_costs'],
                assumptions=['EXISTING_SEAL_GEOMETRY','KNOWN_COLLAPSE_CONDITIONAL_REFILL_UNKNOWN'],
                post_skill_resource_balance='UNKNOWN_NOT_CREDITED')
        elif action.family=='pass':
            totals={};view=reply_view(_copy_grid(board));unknown=0;seal=count_seal_gems(board,GemType.SWORD).effective
            details.update(pass_authority=choice['facts'],assumptions=['EXISTING_ZERO_INPUT_AUTHORITATIVE_PASS_OWNER'])
        else:raise ValueError('unsupported Mega family')
        f['D']=Bound.fixed(clip(totals.get('sword',0)/8),'KNOWN_SWORD_GEM_OPPORTUNITY_NOT_DAMAGE')
        support=totals.get('health',0)*hp_deficit+.75*totals.get('shield',0)
        f['P']=Bound(clip((support+totals.get('drain',0)*boss_load_lo)/8),
            clip((support+totals.get('drain',0)*boss_load_hi)/8),'BOUNDED',
            'DEFICIT_WEIGHTED_SUPPORT_GEM_OPPORTUNITY_NOT_HEAL_OR_SURVIVAL')
        f['T']=Bound.fixed(clip(view['known_sword_reply_max']/8),'KNOWN_REPLY_PROXY_REFILL_AND_CARDS_UNKNOWN')
        f['X']=Bound.fixed(clip(unknown/64),'UNKNOWN_REFILL_EXPOSURE_NOT_PROBABILITY')
        f['H']=Bound.fixed(clip(view['adverse_seal_floor']/target),'KNOWN_ADVERSE_REPLY_SEAL_OPPORTUNITY_NOT_GUARANTEED_FOLLOWUP')
        details.update(reply=view,boss_reply_count=view['known_legal_reply_count'],boss_reply_coverage=view['coverage'],
            seal_before=count_seal_gems(board,GemType.SWORD).effective,seal_after_known=seal,
            advisory_seal_target=target,weights={k:v.to_dict() for k,v in weights.items()})
        scores.append(score_candidate(snapshot,snapshot.snapshot_id,action,f,weights,details,1))
    ordered=tuple(sorted(scores,key=lambda s:order_key(s,'mega_icarus_spam_skill')))
    base=next((s for s in ordered if s.baseline_member),None);reason='OPAQUE_OR_UNSCORABLE_BASELINE';proposal=None
    if base is not None:
        reason='BASELINE_TOP_IN_TOTAL_ORDER'
        if ordered and not ordered[0].baseline_member:
            reason='NEAR_TIE_OR_ESSENTIAL_ASSUMPTION_SENSITIVE'
            if ordered[0].utility.low-base.utility.high>=.05:reason,proposal='D4_ROBUST_SEAL_PRESSURE_PROXY_IMPROVEMENT',ordered[0].action
    return PlannerDecision(snapshot.snapshot_id,snapshot.intent.config_hash,snapshot.baseline,
        'PROPOSE_OFFLINE' if proposal else 'RETAIN_BASELINE',reason,proposal,ordered,
        FrozenJSON.of(dict(version=VERSION,excluded_actions=excluded,no_override_quota=True,
            no_damage_or_survival_guarantee=True,input_authority=False)))
