"""Shared battle-context values, not server damage/healing predictions.

Only the already captured packet is used. Styles change objectives; resource
saturation, opponent replies, affordability and missingness share one model.
"""
import math
from .state import GemType
from .reasoning_snapshot import require


def clip(value):return min(1.,max(0.,value))
def number(value):return type(value) in (int,float) and math.isfinite(value)
def fill(value,maximum,default=None):
    return clip(value/maximum) if number(value) and value>=0 and number(maximum) and maximum>0 else default


def resource_goal(name,own,requirements,evolution,settings):
    capacity=own.get('max_'+name);cost=requirements.get(name)
    if name=='mana' and evolution.get('pending'):
        return (evolution['mana_cost'],'EVOLUTION_COST') if number(evolution.get('mana_cost')) else (None,'EVOLUTION_COST_UNKNOWN')
    if not number(capacity) or capacity<0:return None,'CAPACITY_UNKNOWN'
    if number(cost) and cost==0:return 0,'NO_COST_FOR_CURRENT_SKILL'
    if name=='rage':
        reference=settings.get('rage_target',100)
        reference=reference if number(reference) and reference>0 else 100
        if number(cost) and cost>0:
            return min(capacity,max(reference,2*cost)),'RAGE_AND_NEXT_SKILL_CYCLE'
        return min(capacity,reference),'RAGE_REFERENCE'
    if number(cost) and cost>0:
        return min(capacity,2*cost),'SKILL_AND_NEXT_CYCLE_RESERVE'
    return capacity,'AVAILABLE_STORAGE'


def skill_resource_readiness(requirements, own, gains):
    costs = tuple(requirements.get(name) for name in ('mana', 'rage'))
    if not all(number(cost) and cost >= 0 for cost in costs) or not any(costs):
        return None
    ratios = []
    for name, cost in zip(('mana', 'rage'), costs):
        if cost == 0:
            continue
        balance = own.get(name)
        gain = gains.get(name, 0)
        if not number(balance) or balance < 0 or not number(gain):
            return None
        ratios.append(clip((balance + gain) / cost))
    return min(ratios)


def _reply_risk(reply, boss, rates, own_mana_fill, boss_rage_fill, boss_hp_fill, advantage):
    resources = reply.resources
    sword = clip(resources.effective(GemType.SWORD)/8*(1+.75*boss_rage_fill+.5*advantage))
    drain = clip(resources.effective(GemType.DRAIN)/8)*own_mana_fill
    health = clip(resources.effective(GemType.HEALTH)/8)*(1-boss_hp_fill if boss_hp_fill is not None else 1.)
    progress = 0.
    missing = []
    for name in ('mana', 'rage'):
        units = resources.effective(GemType(name))
        if not units:
            continue
        current, capacity, rate = boss.get(name), boss.get('max_'+name), rates.get(name)
        goal = min(capacity, 100) if name=='rage' and number(capacity) else capacity
        if number(current) and number(goal) and goal>0 and number(rate):
            progress += min(max(0,goal-current),units*rate)/goal
        else:
            missing.append('BOSS_RESOURCE_PROGRESS_UNKNOWN_'+name)
    return dict(sword=sword, drain=drain, resource_progress=progress, health=health,
        threat=clip(sword+.45*drain+.25*progress+.15*health)), missing


def evaluate_context(problem,step,replies,maximum):
    facts=problem.facts.plain();own=facts.get('self',{});boss=facts.get('opponent',{})
    settings=problem.intent.settings.plain();profile=problem.intent.profile
    rates=facts.get('conversion',{});needs=facts.get('resource_requirements',{})
    evolution=facts.get('evolution',{})
    hp_fill=fill(own.get('hp'),own.get('max_hp'));pressure=1-hp_fill if hp_fill is not None else 1.
    boss_hp_fill=fill(boss.get('hp'),boss.get('max_hp'))
    own_mana_fill=fill(own.get('mana'),own.get('max_mana'),1.)
    boss_mana_fill=fill(boss.get('mana'),boss.get('max_mana'))
    boss_rage_fill=fill(boss.get('rage'),100,1.)
    missing=[];unknown_features=set();progress={};resource_details={};wastes=[]
    for name in ('mana','rage'):
        current=own.get(name);rate=rates.get(name);units=step.resources.effective(GemType(name))
        goal,origin=resource_goal(name,own,needs,evolution,settings)
        item=dict(current=current,capacity=own.get('max_'+name),goal=goal,goal_origin=origin,
            effective_gems=units,useful_gain=None,progress=0.,saturated=False)
        if step.action.family=='pet_skill':
            # The skill can consume and produce resources in the same action.
            # Its net balance is not part of the observed first-wave ledger.
            item['gain_status']='POST_SKILL_ORDER_UNKNOWN_NO_CREDIT';progress[name]=0.
        elif number(goal) and goal>=0 and number(current) and current>=goal:
            item.update(useful_gain=0,progress=0.,saturated=True);progress[name]=0.
            if units:wastes.append(1.)
        elif not units:
            progress[name]=0.;item['useful_gain']=0
        elif not (number(goal) and goal>0 and number(current) and current>=0 and number(rate) and rate>=0):
            missing.append('RESOURCE_CONVERSION_OR_REQUIREMENT_UNKNOWN_'+name);unknown_features.add('R')
            progress[name]=0.
        else:
            potential=units*rate;useful=min(max(0,goal-current),potential)
            value=useful/goal
            item.update(useful_gain=useful,progress=value);progress[name]=value
            if potential:wastes.append(1-useful/potential)
        resource_details[name]=item
    readiness_before=skill_resource_readiness(needs,own,{})
    readiness_after=(None if step.action.family=='pet_skill' else skill_resource_readiness(
        needs,own,{name:item['useful_gain'] for name,item in resource_details.items()}))
    if (not evolution.get('pending') and readiness_after is not None and readiness_after<1):
        for name,item in resource_details.items():
            gain = item['useful_gain']
            if not gain:
                continue
            towards_cast = min(gain, max(0,needs[name]-item['current']))
            # Extra reserves still matter, with lower priority while the next
            # cast lacks either resource.
            progress[name] = (towards_cast+.25*(gain-towards_cast))/item['goal']
            item['progress'] = progress[name]
    mana_weight=2. if evolution.get('pending') else 1.5 if profile=='skill_rush' else 1.
    rage_weight=.5 if evolution.get('pending') else 1.
    unlock_bonus=.125 if (not evolution.get('pending') and readiness_before is not None
        and readiness_before<1 and readiness_after==1) else 0.
    resource_value=clip((mana_weight*progress['mana']+rage_weight*progress['rage'])/2+unlock_bonus)

    # Sword-first is conditional on the user's boss policy. Keep every tie.
    nominal=([r for r in replies if r.resources.effective(GemType.SWORD)==maximum]
        if maximum and facts.get('boss_policy')=='USER_CONDITIONAL_MAX_EFFECTIVE_SWORD' else replies)
    own_attack=own.get('attack');boss_attack=boss.get('attack')
    advantage=(boss_attack/(own_attack+boss_attack) if number(own_attack) and own_attack>0
        and number(boss_attack) and boss_attack>=0 else 1.)
    sword_threat=clip(maximum/8*(1+.75*boss_rage_fill+.5*advantage))
    reply_risks=[]
    for reply in nominal:
        risk, gaps=_reply_risk(reply,boss,rates,own_mana_fill,boss_rage_fill,boss_hp_fill,advantage)
        reply_risks.append(risk)
        if gaps:
            missing.extend(gap for gap in gaps if gap not in missing);unknown_features.add('T')
    if not nominal and any(c.gem is GemType.UNKNOWN for row in step.after for c in row):
        missing.append('NO_KNOWN_REPLY_WITH_UNRESOLVED_REFILL');unknown_features.add('T')
    worst_reply=max(reply_risks,key=lambda risk:risk['threat'],default=dict(
        sword=0.,drain=0.,resource_progress=0.,health=0.,threat=0.))

    health=clip(step.resources.effective(GemType.HEALTH)/6)*pressure
    existing_shield=fill(own.get('shield'),own.get('max_hp'),0.)
    shield=clip(step.resources.effective(GemType.SHIELD)/6)*max(pressure,sword_threat)*(1-existing_shield)
    drain_units=step.resources.effective(GemType.DRAIN)
    if boss.get('mana')==0:drain=0.
    elif boss_mana_fill is not None:
        drain=clip(drain_units/6)*boss_mana_fill*(.35+.65*own_mana_fill)
    elif drain_units:
        drain=0.;unknown_features.add('P');missing.append('DRAIN_BENEFIT_OPPONENT_BALANCE_UNKNOWN')
    else:drain=0.
    heal_opportunity=pressure if step.heals_self else 0.
    protection=clip(max(health,heal_opportunity)+.5*shield+.5*drain)
    commitment=[]
    for name,cost in (('mana',step.mana_cost),('rage',step.rage_cost)):
        current=own.get(name)
        if cost and number(current) and current>0:commitment.append(clip(cost/current))
    input_effort=(0. if step.action.family=='pass' else .35 if step.action.family=='pet_skill' else .12)
    if step.resources.effective(GemType.HEALTH) and hp_fill==1 and not step.heals_self:wastes.append(1.)
    details=dict(resource_value=resource_details,objective_phase='EVOLUTION_PREPARATION' if evolution.get('pending') else
        'SKILL_CYCLE' if needs else 'RESOURCE_AND_SWORD_OPPORTUNITY',
        self_hp_fraction=hp_fill,boss_hp_fraction=boss_hp_fill,boss_mana_fraction=boss_mana_fill,
        boss_rage_reference_fraction=boss_rage_fill,boss_rage_capacity_fraction=fill(boss.get('rage'),boss.get('max_rage')),
        boss_attack_advantage_proxy=advantage,
        protection_proxy=dict(health=health,shield=shield,drain=drain,self_heal_opportunity=heal_opportunity),
        boss_reply_proxy=dict(**worst_reply,replies_examined=len(nominal),aggregation='WORST_SINGLE_REPLY'),
        skill_resource_readiness=dict(before=readiness_before,after=readiness_after,unlock_bonus=unlock_bonus),
        self_heal_amount='UNKNOWN' if step.heals_self else 'NOT_APPLICABLE',
        action_effort_kind='INPUT_AND_WASTED_RESOURCE_PROXY_NOT_ACTUAL_ENERGY',
        post_skill_resource_order='UNKNOWN_NOT_CREDITED',missing=missing)
    return dict(R=resource_value,P=protection,T=worst_reply['threat'],L=sum(commitment)/2,
        E=clip(input_effort+.4*(sum(wastes)/len(wastes) if wastes else 0))),details,unknown_features


def demon_damage_reference(facts,step,reference):
    """A scoped nominal estimate can lower OR raise the setting reference.

    Nothing derives elemental advantage from HP/ATK or from the settings.
    A missing context stays explicit. No nominal estimate certifies a kill.
    """
    model=facts.get('demon_damage_model');own=facts.get('self',{});boss=facts.get('opponent',{})
    result=dict(status='ELEMENT_AND_DAMAGE_CONTEXT_UNAVAILABLE',estimated_damage=None,
        kill_certified=False,configured_reference=reference)
    if model is None:return None,result
    require(type(model) is dict,'damage context must be an object')
    if step.action.family!='swap' or step.coverage!='CONDITIONAL_PASSIVE_FIRST_WAVE_ONLY':
        result['status']='NOT_CURRENT_DEMON_PASSIVE_SWEEP';return None,result
    expected={'kind','session','account_sha256','player_stats','opponent_stats','counter_confirmed','nominal_two_sword_damage'}
    require(set(model)==expected and model['kind']=='USER_SCOPED_DEMON_NOMINAL_DAMAGE'
        and type(model['counter_confirmed']) is bool
        and number(model['nominal_two_sword_damage']) and model['nominal_two_sword_damage']>0,'invalid scoped Demon model')
    signature=lambda actor:[actor.get(k) for k in ('max_hp','max_mana','max_rage','attack')]
    require(type(model['account_sha256']) is str and len(model['account_sha256'])==64
        and type(model['session']) is str and bool(model['session'])
        and all(type(model[k]) is list and len(model[k])==4 and all(number(n) and n>=0 for n in model[k])
            for k in ('player_stats','opponent_stats')),'complete scoped damage identity required')
    if (model['session']!=facts.get('damage_session') or model['account_sha256']!=facts.get('account_sha256')
            or model['player_stats']!=signature(own) or model['opponent_stats']!=signature(boss)
            or model['counter_confirmed'] is not True):
        result['status']='SCOPED_DAMAGE_CONTEXT_MISMATCH';return None,result
    rage=own.get('rage');rate=facts.get('conversion',{}).get('rage')
    available=rage+(step.passive_rage*rate if number(rate) else 0) if number(rage) else None
    if number(rage) and rage<100 and (not number(own.get('max_rage')) or own['max_rage']<100):available=None
    if not number(available) or available<100:
        result['status']='RAGE_CONDITION_NOT_REACHED';return None,result
    hp=boss.get('hp')
    if not number(hp) or hp<=0:result['status']='BOSS_HP_UNKNOWN';return None,result
    per_sword=model['nominal_two_sword_damage']/2
    target=max(2,math.ceil(hp/per_sword))
    result.update(status='USER_SCOPED_NOMINAL_ESTIMATE',estimated_damage=step.passive_swords*per_sword,
        nominal_swords_for_current_hp=target,provenance='USER_ESTIMATE_NOT_SERVER_DAMAGE_FORMULA')
    return target,result
