"""One bounded, explainable chooser across all styles. Never owns game input.

Utilities are structural proxies, not damage or win probabilities. Boss replies
are conditional Sword-first/all ties; refill, boss skills and effect order are
not invented. Settings are references; action eligibility comes from the owner.
"""
from dataclasses import dataclass,replace
import math,time
from .board_simulator import (SwapMove,ResourceResult,SimulatedCell,_CellValue,
    _candidate_swaps,_match_through,_matches_touching,_tallies,_merge_results,_resolve_known_reply,_collapse,_freeze)
from .demon_aegis import _passive_geometry
from .mega_icarus import MEGA_ICARUS_SEAL_CELLS
from .reasoning_common_models import DEMON_RAGE_REFERENCE
from .reasoning_common_problem import CommonProblem,VERSION
from .reasoning_planner import Bound,CandidateScore,FEATURES,order_key
from .reasoning_snapshot import Action,FrozenJSON,canonical_json,require
from .state import GemType

# F/R/D/P/H/B/T/X/L/E; fixed scales, no candidate min/max normalization.
WEIGHTS={
    'simple':(10,3,6,3,3,0,5,2,0,1),
    'careful':(10,3,5,5,3,0,8,4,0,1),
    'dinosaur':(10,3,6,3,3,0,5,2,0,1),
    'skill_rush':(10,7,3,4,4,0,5,3,0,1),
    'demon_aegis_farm':(12,4,6,4,6,0,6,3,0,1),
    'mega_icarus_spam_skill':(10,6,4,5,5,0,7,3,0,1),
    'bu_win':(0,0,0,0,0,10,0,2,0,1),
}


def clip(v):return min(1.,max(0.,v))
def effective(result,gem):return result.effective(GemType(gem))
def unknown(grid):return sum(c.gem is GemType.UNKNOWN for row in grid for c in row)/64


@dataclass(frozen=True)
class CommonLimits:
    duration_ms:float=4000
    roots:int=8
    scenarios:int=32
    nodes:int=18000
    lookahead:bool=True

    def __post_init__(self):
        require(type(self.duration_ms) in (int,float) and math.isfinite(self.duration_ms)
            and 0<=self.duration_ms<=6000,'bounded common budget required')
        require(type(self.roots) is int and 1<=self.roots<=8 and type(self.scenarios) is int
            and 1<=self.scenarios<=32 and type(self.nodes) is int and 1<=self.nodes<=50000,
            'bounded common work required')
        require(type(self.lookahead) is bool,'explicit lookahead flag required')


class Exhausted(Exception):pass


class Work:
    def __init__(self,limits,clock,cancelled,deadline_ns):
        self.limits=limits;self.clock=clock;self.cancelled=cancelled;self.nodes=0
        now=clock();self.deadline=min(now+int(limits.duration_ms*1e6),deadline_ns or 2**63-1)
    def check(self):
        if self.cancelled():raise Exhausted('CANCELLED')
        if self.clock()>=self.deadline:raise Exhausted('DEADLINE')
    def node(self):
        self.check()
        if self.nodes>=self.limits.nodes:raise Exhausted('NODE_CAP')
        self.nodes+=1


@dataclass(frozen=True)
class Step:
    action:Action
    resources:ResourceResult
    after:tuple
    coverage:str
    original_cells:tuple=()
    passive_swords:int=0
    passive_physical:int=0
    ordinary_swords:int=0
    mana_cost:int=0
    rage_cost:int=0
    unresolved_residual:bool=False
    passive_rage:int=0
    heals_self:bool=False


@dataclass(frozen=True)
class CommonDecision:
    snapshot_id:str
    config_hash:str
    baseline:Action
    disposition:str
    reason:str
    proposal:Action|None
    scores:tuple
    diagnostics:FrozenJSON

    def to_dict(self):
        return dict(schema='pokiguard.reasoning.common_decision.v1',version=VERSION,
            snapshot_id=self.snapshot_id,config_hash=self.config_hash,baseline=self.baseline.to_dict(),
            disposition=self.disposition,reason=self.reason,proposal=None if self.proposal is None else self.proposal.to_dict(),
            scores=[s.to_dict() for s in self.scores],diagnostics=self.diagnostics.plain(),input_authority=False)


def _ordinary(grid,move,work):
    work.node();a=grid[move.first[0]][move.first[1]];b=grid[move.second[0]][move.second[1]]
    if not a.known or not b.known or a.gem is b.gem:return None
    resolved=_resolve_known_reply([[_CellValue(c.gem,c.multiplier) for c in row] for row in grid],move)
    work.check()
    if resolved is None:return None
    direct,cascade,rounds,after=resolved
    return Step(Action('swap',move),_merge_results(direct,cascade),_freeze(after),
        'EXISTING_SOLVER_KNOWN_CASCADES_NO_REFILL')


def _root_step(problem,grid,move,work):
    ordinary=_ordinary(grid,move,work)
    if ordinary is None:return None
    if problem.intent.profile!='demon_aegis_farm':return ordinary
    facts=problem.facts.plain()
    if facts.get('demon_geometry')!='USER_DECLARED_PERPENDICULAR':
        return replace(ordinary,coverage='DEMON_PASSIVE_EFFECT_UNKNOWN')
    target=GemType(problem.intent.settings.plain().get('demon_target_gem','shield'))
    require(target in (GemType.SHIELD,GemType.HEALTH,GemType.MANA,GemType.DRAIN,GemType.RAGE),
        'unsupported Demon target')
    matched,blast,physical,swords=_passive_geometry(grid,move,target)
    if not matched:return replace(ordinary,ordinary_swords=ordinary.resources.effective(GemType.SWORD),
        unresolved_residual=ordinary.resources.cells(target)>0)
    swapped=[[_CellValue(c.gem,c.multiplier) for c in row] for row in grid]
    a,b=move.first,move.second
    swapped[a[0]][a[1]],swapped[b[0]][b[1]]=swapped[b[0]][b[1]],swapped[a[0]][a[1]]
    direct=_match_through(swapped,a)|_match_through(swapped,b)
    cells=set(blast)|direct
    resources=_tallies(swapped,cells)
    ordinary_swords=_tallies(swapped,direct-set(blast)).effective(GemType.SWORD)
    passive_rage=_tallies(swapped,set(blast)).effective(GemType.RAGE)
    displaced=_collapse(swapped,cells)
    residual=bool(_matches_touching(swapped,displaced)[0])
    return Step(ordinary.action,resources,_freeze(swapped),'CONDITIONAL_PASSIVE_FIRST_WAVE_ONLY',
        tuple(sorted(cells)),swords,physical,ordinary_swords,unresolved_residual=residual,
        passive_rage=passive_rage)


def _extra_step(problem,grid,choice):
    if not choice.eligible:return None,choice.reason
    if choice.cleared is None or choice.support=='UNKNOWN':return None,'ACTION_EFFECT_UNMODELED'
    own=problem.facts.plain().get('self',{})
    for resource,cost in (('mana',choice.mana_cost),('rage',choice.rage_cost)):
        if type(cost) is not int:return None,'ACTUAL_ACTION_COST_OR_BALANCE_UNKNOWN'
        if cost==0:continue
        if type(own.get(resource)) is not int:return None,'ACTUAL_ACTION_COST_OR_BALANCE_UNKNOWN'
        if own[resource]<cost:return None,'ACTUAL_ACTION_RESOURCES_INSUFFICIENT'
    copied=[[_CellValue(c.gem,c.multiplier) for c in row] for row in grid]
    resources=_tallies(copied,choice.cleared)
    residual=False
    if choice.cleared:
        displaced=_collapse(copied,set(choice.cleared))
        residual=bool(_matches_touching(copied,displaced)[0])
    return Step(choice.action,resources,_freeze(copied),choice.model,choice.cleared,
        mana_cost=choice.mana_cost,rage_cost=choice.rage_cost,unresolved_residual=residual,
        heals_self=choice.facts.plain().get('self_heal_present') is True),None


def _reference(problem):
    settings=problem.intent.settings.plain()
    value=settings.get('pet_skill_fire_value')
    return value if type(value) is int and value>0 else None


def _demon_rage_goal(facts, reference, rage, sweep_rage):
    discount = facts.get('operator_demon_rage_discount')
    if type(discount) is not int or discount <= 0:
        return reference, 'UNKNOWN_NO_CREDIT'
    reduced = max(2, reference-discount)
    if type(rage) is int and rage >= 100:
        return reduced, 'UNKNOWN_NO_CREDIT'
    declaration = facts.get('demon_strategy',{}).get('rage_reference')
    capacity = facts.get('self',{}).get('max_rage')
    rate = facts.get('conversion',{}).get('rage')
    if (declaration != DEMON_RAGE_REFERENCE.plain() or type(rage) is not int or rage < 0
            or type(capacity) is not int or capacity < 100 or rate != 20 or sweep_rage <= 0):
        return reference, 'UNKNOWN_NO_CREDIT'
    if rage+sweep_rage*rate >= 100:
        return reduced, 'USER_DECLARED_NOMINAL_REFERENCE_ONLY'
    return reference, 'KNOWN_RAGE_BELOW_REFERENCE'


def _sweep_rage(grid, move, blast):
    # The blast uses post-swap coordinates. Attribute the two moved cells to
    # their original gems without copying or mutating the board.
    moved = {move.first:move.second, move.second:move.first}
    total = 0
    for point in blast:
        r,c = moved.get(point,point)
        cell = grid[r][c]
        if cell.gem is GemType.RAGE:
            total += cell.multiplier or 1
    return total


def _setup(problem,grid,work):
    profile=problem.intent.profile;reference=_reference(problem)
    if profile=='demon_aegis_farm':
        facts=problem.facts.plain()
        if facts.get('demon_geometry')!='USER_DECLARED_PERPENDICULAR' or reference is None:return None
        target=GemType(problem.intent.settings.plain().get('demon_target_gem','shield'));best=0.
        for move in _candidate_swaps():
            work.node();a=grid[move.first[0]][move.first[1]];b=grid[move.second[0]][move.second[1]]
            if not a.known or not b.known or a.gem is b.gem:continue
            matched,blast,physical,swords=_passive_geometry(grid,move,target)
            if matched and physical>=2:
                # Future balances are unknown after our move and the reply.
                # Only this future sweep's own known Rage can meet the goal.
                goal,_=_demon_rage_goal(facts,reference,0,_sweep_rage(grid,move,blast))
                best=max(best,clip(swords/goal))
                if best==1.:break
        return best
    if profile=='mega_icarus_spam_skill':
        if reference is None or problem.intent.settings.plain().get('pet_skill_fire_condition','sword_count')!='sword_count':return None
        return clip(sum(grid[r][c].multiplier or 1 for r,c in MEGA_ICARUS_SEAL_CELLS
            if grid[r][c].gem is GemType.SWORD)/reference)
    if profile=='skill_rush':
        if reference is None:return None
        condition=problem.intent.settings.plain().get('pet_skill_fire_condition','sword_count')
        name={'sword_count':'sword','mana_gem_count':'mana','rage_gem_count':'rage',
            'drain_gem_count':'drain','shield_gem_count':'shield'}.get(condition)
        if name is None:return None
        return clip(sum(c.multiplier or 1 for row in grid for c in row if c.gem.value==name)/reference)
    # Other styles value the next known offensive opportunity, not an invented skill.
    best=0.
    for move in _candidate_swaps():
        step=_ordinary(grid,move,work)
        if step is not None:best=max(best,clip(step.resources.effective(GemType.SWORD)/8))
    return best


def _replies(grid,work,sword_first):
    replies=[]
    for move in _candidate_swaps():
        step=_ordinary(grid,move,work)
        if step is not None:replies.append(step)
    maximum=max((s.resources.effective(GemType.SWORD) for s in replies),default=0)
    nominal=[s for s in replies if s.resources.effective(GemType.SWORD)==maximum] if maximum and sword_first else replies
    return replies,nominal,maximum


def _features(problem,step,replies,maximum):
    facts=problem.facts.plain();own=facts.get('self',{});other=facts.get('opponent',{})
    hp,cap=own.get('hp'),own.get('max_hp')
    pressure=clip(1-hp/cap) if type(hp) is int and type(cap) is int and cap>0 else 1.
    profile=problem.intent.profile;settings=problem.intent.settings.plain()
    from .reasoning_common_tactics import evaluate_context,fill
    context,context_details,unknown_features=evaluate_context(problem,step,replies,maximum)
    missing=list(context_details['missing'])
    # Known direct Sword matches are offense too; the passive is one route.
    sword=effective(step.resources,'sword')
    f=dict(F=0.,R=context['R'],D=clip(sword/8),P=context['P'],H=0.,B=clip(maximum/8),
        T=context['T'],X=unknown(step.after),L=context['L'],E=context['E'])
    if profile!='bu_win':f['B']=0.
    if profile=='demon_aegis_farm':
        if step.coverage=='DEMON_PASSIVE_EFFECT_UNKNOWN':missing.append('DEMON_PASSIVE_EFFECT_UNKNOWN')
        reference=_reference(problem)
        # Nominal objective only. This is not a damage/terminal certificate.
        if reference is not None and step.passive_physical>=2:
            sweep_rage=step.passive_rage if step.coverage=='CONDITIONAL_PASSIVE_FIRST_WAVE_ONLY' else 0
            nominal_reference,same_burst=_demon_rage_goal(facts,reference,own.get('rage'),sweep_rage)
            from .reasoning_common_tactics import demon_damage_reference
            damage_target,damage_context=demon_damage_reference(facts,step,reference)
            if damage_target is not None:nominal_reference=damage_target
            f['F']=float(step.passive_swords>=nominal_reference)
            if damage_target is not None and f['F']:
                # Once the scoped nominal goal is met, extra Sword is not extra finish credit.
                f['D']=clip(min(step.passive_swords,damage_target)/8)
        else:
            nominal_reference=None;same_burst='PHYSICAL_SWORD_FLOOR_OR_REFERENCE_MISSING'
            damage_context=dict(status='PHYSICAL_SWORD_FLOOR_OR_REFERENCE_MISSING',kill_certified=False)
    weights=dict(zip(FEATURES,WEIGHTS[profile]))
    if profile in ('skill_rush','mega_icarus_spam_skill'):weights['L']=2.
    boss_fraction=context_details['boss_hp_fraction']
    if boss_fraction is not None:weights['L']*=1+(1-boss_fraction)
    rage_fraction=fill(own.get('rage'),100,0.)
    known_pressure=pressure if context_details['self_hp_fraction'] is not None else 0.
    urgency=(1-boss_fraction)*(.5+known_pressure) if boss_fraction is not None else 0.
    offense_weight=1.+.5*rage_fraction+urgency if profile!='bu_win' else 1.
    weights['D']*=offense_weight
    if step.unresolved_residual:
        # These branches have not reached the opponent's turn. Keep the known
        # first-wave ledger, but do not score an imagined boss response or
        # suppress the incumbent's unmodeled additional resource/effect value.
        missing.append('LOCAL_EFFECT_RESIDUAL_ORDER_UNMODELED')
        unknown_features.update(('F','R','D','B','T'))
        if step.heals_self:
            # The declared healing opportunity does not require predicting the refill.
            # Its HP amount and survival result remain unknown.
            f['P']=context_details['protection_proxy']['self_heal_opportunity']
        else:unknown_features.add('P')
    if profile!='bu_win':
        weights['P']*=1+2*pressure;weights['T']*=1+pressure
    if (profile=='skill_rush' and facts.get('past_skill_successes',0)>0
            and context_details['skill_resource_readiness']['before']==1):
        weights['R']=3;weights['D']=7
    details=dict(resources={g.value:dict(physical=step.resources.cells(g),effective=step.resources.effective(g))
            for g in GemType if g is not GemType.UNKNOWN},
        ledger=dict(original_cells=[list(p) for p in step.original_cells],coverage=step.coverage),
        pressure_proxy=pressure,pressure_evidence='SELF_HP_DEFICIT_PROXY' if type(cap) is int and cap>0 else 'MAX_HP_UNKNOWN_CONSERVATIVE_CONTEXT',
        unknown_effects=missing+['REFILL_DISTRIBUTION','DAMAGE_SURVIVAL','BOSS_SKILL_POLICY'],
        boss_reply_count=len(replies),boss_reply_coverage=('LOCAL_EFFECT_RESIDUAL_UNRESOLVED' if step.unresolved_residual else
            'KNOWN_ORDINARY_MAX_EFFECTIVE_SWORD_CONDITIONAL' if facts.get('boss_policy')=='USER_CONDITIONAL_MAX_EFFECTIVE_SWORD'
            else 'POLICY_UNKNOWN_ALL_KNOWN_ORDINARY_ALTERNATIVES'),
        settings_are_advisory=True,observed_win=False,geometry_coverage=step.coverage,
        passive_sword_effective=step.passive_swords,passive_sword_physical=step.passive_physical,
        normal_sword_effective=step.ordinary_swords,costs=dict(mana=step.mana_cost,rage=step.rage_cost),
        unknown_features=sorted(unknown_features),
        tactical_context=context_details,
        offensive_opportunity=dict(effective_swords=sword,rage_reference_fraction=rage_fraction,
            boss_hp_fraction=boss_fraction,self_hp_pressure=known_pressure,urgency=urgency,
            weight_multiplier=offense_weight,kind='CONTEXTUAL_ATTACK_OPPORTUNITY_NOT_DAMAGE',
            estimated_damage=None,kill_certified=False),
        utility_kind='STRUCTURAL_PROXY_NOT_HP_DAMAGE_OR_WIN_PROBABILITY')
    if profile=='demon_aegis_farm':
        details['nominal_sword_reference']=nominal_reference
        details['same_burst_rage_sufficiency']=same_burst
        details['passive_rage_effective']=step.passive_rage
        details['strategy_provenance']=facts.get('demon_strategy')
        details['automatic_kill_claim']=False
        details['effect_provenance']=facts.get('demon_effect')
        details['damage_context']=damage_context
    return f,weights,details


def _score(problem,step,features,weights,details):
    bounds={k:Bound.missing('COMMON_REQUIRED_EFFECT_INPUT_UNKNOWN') if k in details.get('unknown_features',())
        else Bound.fixed(features[k],'COMMON_STRUCTURAL_PROXY') for k in FEATURES}
    contributions={k:Bound(-bounds[k].high*weights[k],-bounds[k].low*weights[k],'BOUNDED') if k in ('T','X','L','E')
        else Bound(bounds[k].low*weights[k],bounds[k].high*weights[k],'BOUNDED') for k in FEATURES}
    return CandidateScore(problem.candidate_id(step.action),step.action,step.action==problem.baseline,
        tuple(bounds.items()),tuple(contributions.items()),
        Bound(sum(v.low for v in contributions.values()),sum(v.high for v in contributions.values()),
            'BOUNDED','COMMON_CONDITIONAL_MODEL_UTILITY'),1,FrozenJSON.of(details))


def plan_common(problem,limits=CommonLimits(),*,clock=time.perf_counter_ns,cancelled=lambda:False,deadline_ns=None):
    require(type(problem) is CommonProblem,'immutable common problem required')
    work=Work(limits,clock,cancelled,deadline_ns);steps=[];scored=[];excluded=[];stage='ROOT'
    def finish(reason,chosen=None,diag=None):
        ordered=tuple(sorted(scored,key=lambda c:order_key(c,problem.intent.profile)))
        return CommonDecision(problem.snapshot_id,problem.intent.config_hash,problem.baseline,
            'PROPOSE_OFFLINE' if chosen is not None else 'RETAIN_BASELINE',reason,chosen,ordered,
            FrozenJSON.of(dict(version=VERSION,stage=stage,nodes=work.nodes,adjacent_pairs=112,
                legal_swaps=sum(s.action.family=='swap' for s in steps),excluded_actions=excluded,
                input_authority=False,global_optimum_claim=False,**(diag or {}))))
    facts=problem.facts.plain()
    if facts.get('root_allowed') is not True or facts.get('pending') is True:
        return finish('COMMON_EXISTING_OWNER_OR_PENDING')
    if problem.intent.profile=='demon_aegis_farm' and facts.get('demon_geometry')!='USER_DECLARED_PERPENDICULAR':
        return finish('COMMON_DEMON_GEOMETRY_UNCONFIRMED')
    if problem.baseline.family not in ('swap','pet_skill','cast','pass'):
        return finish('COMMON_BASELINE_EXISTING_ACTION_OWNER')
    grid=tuple(tuple(SimulatedCell(GemType(g),m) for g,m in row) for row in problem.board)
    root_scores=[]
    try:
        for move in _candidate_swaps():
            step=_root_step(problem,grid,move,work)
            if step is not None:steps.append(step)
        for choice in problem.effects:
            work.node();step,reason=_extra_step(problem,grid,choice)
            if step is None:excluded.append(dict(action=choice.action.to_dict(),reason=reason))
            else:steps.append(step)
        if not any(s.action==problem.baseline for s in steps):return finish('COMMON_OPAQUE_OR_UNREPRESENTED_INCUMBENT')
        for step in steps:
            replies,nominal,maximum=([],[],0) if step.unresolved_residual else _replies(step.after,work,
                facts.get('boss_policy')=='USER_CONDITIONAL_MAX_EFFECTIVE_SWORD')
            features,weights,details=_features(problem,step,replies,maximum)
            score=_score(problem,step,features,weights,details)
            root_scores.append((score,step,nominal,features,weights,details))
        scored[:]=[r[0] for r in root_scores]
        stage='ONE_STEP_COMPLETE'
        def choose():
            ordered=sorted(scored,key=lambda c:order_key(c,problem.intent.profile))
            base=next(c for c in ordered if c.baseline_member)
            best=ordered[0]
            return best.action if not best.baseline_member and best.utility.low-base.utility.high>=.05 else None
        one_step=choose()
        if not limits.lookahead:return finish('COMMON_ONE_STEP_IMPROVEMENT' if one_step else 'COMMON_COMPLETED_RETENTION',one_step)
        ranked=sorted(root_scores,key=lambda r:order_key(r[0],problem.intent.profile))
        baseline=next(r for r in ranked if r[0].baseline_member)
        roots=[baseline]+[r for r in ranked if not r[0].baseline_member][:limits.roots-1]
        refinements=[]
        stage='LOOKAHEAD'
        for score,step,nominal,features,weights,details in roots:
            work.check()
            info=dict(pre_boss_diagnostic=None,nominal_total=len(nominal),nominal_examined=0,
                status='UNSUPPORTED_NO_KNOWN_REPLY',favorable_refill_credit=0)
            revised=dict(features)
            if nominal and len(nominal)<=limits.scenarios:
                quality=[]
                for reply in nominal:
                    work.check();value=_setup(problem,reply.after,work)
                    if value is None:break
                    quality.append(value);info['nominal_examined']+=1
                if len(quality)==len(nominal):
                    revised['H']=min(quality)*.5
                    info.update(status='COMPLETED_ALL_NOMINAL_TIES',post_boss_setup_floor=min(quality))
            elif len(nominal)>limits.scenarios:
                info['status']='PARTIAL_NOMINAL_TIES_NO_FUTURE_CREDIT'
            refinements.append(_score(problem,step,revised,weights,dict(details,lookahead=info)))
        # Commit only a complete, comparable shortlist containing the incumbent.
        if any(s.details.plain()['lookahead']['status']!='COMPLETED_ALL_NOMINAL_TIES' for s in refinements):
            stage='ONE_STEP_COMPLETE'
            return finish('COMMON_FUTURE_INCOMPLETE_USE_COMPLETED_R1',one_step)
        scored[:]=refinements;stage='LOOKAHEAD_COMPLETE';selected=choose()
        return finish('COMMON_BOUNDED_IMPROVEMENT' if selected else 'COMMON_COMPLETED_RETENTION',selected,
            dict(lookahead_roots=len(roots),unexamined_root_candidates=len(root_scores)-len(roots)))
    except Exhausted as exc:
        # Partial root work cannot select; partial future work cannot replace R1.
        if stage=='LOOKAHEAD':
            scored[:]=[r[0] for r in root_scores];stage='ONE_STEP_COMPLETE'
            return finish('COMMON_LOOKAHEAD_'+str(exc)+'_USE_COMPLETED_R1',one_step)
        scored.clear();return finish('COMMON_'+str(exc)+'_RETAIN_INCUMBENT')


def action_is_eligible(problem,action):
    """Off-controller reply validation; never grants existing-owner permission."""
    if type(problem) is not CommonProblem or type(action) is not Action:return False
    facts=problem.facts.plain()
    if facts.get('root_allowed') is not True or facts.get('pending') is True:return False
    if problem.intent.profile=='demon_aegis_farm' and facts.get('demon_geometry')!='USER_DECLARED_PERPENDICULAR':return False
    grid=tuple(tuple(SimulatedCell(GemType(g),m) for g,m in row) for row in problem.board)
    if action.family=='swap':
        work=Work(CommonLimits(lookahead=False),lambda:0,lambda:False,None)
        return _root_step(problem,grid,action.move,work) is not None
    choice=next((c for c in problem.effects if c.action==action),None)
    return choice is not None and _extra_step(problem,grid,choice)[0] is not None
