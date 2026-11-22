"""File-only BASIC/adviser comparison on one immutable pre-action problem.

Collection counts describe the existing solver's modeled horizon, not net
balances, damage, wins, or optimal-action labels. Never insert actual refill.
"""
from pathlib import Path
import argparse
import json
import sys

ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.board_simulator import SimulatedCell
from pokiguard_v2.reasoning_common_planner import (
    CommonLimits, Work, Exhausted, plan_common, _root_step, _extra_step,
    _replies, _refill_sword_hazard,
)
from pokiguard_v2.reasoning_common_problem import CommonProblem
from pokiguard_v2.reasoning_calibration import source_fingerprint
from pokiguard_v2.state import GemType


def project_action(problem,action):
    grid=tuple(tuple(SimulatedCell(GemType(g),m) for g,m in row) for row in problem.board)
    # This larger budget extracts consequences of two fixed choices only. The
    # chooser itself retains CommonLimits(); no extra candidate search/credit.
    work=Work(CommonLimits(nodes=50000),lambda:0,lambda:False,None)
    result=dict(action=action.to_dict(),status='UNKNOWN',input_authority=False,
        damage_prediction=None,net_resource_prediction=None,skill_unlock_prediction=None,
        actual_refill_used=False,favorable_refill_credit=0)
    try:
        if action.family=='swap':
            step=_root_step(problem,grid,action.move,work)
            reason='NO_LEGAL_MODELED_SWAP'
        else:
            choices=[c for c in problem.effects if c.action==action]
            step,reason=_extra_step(problem,grid,choices[0]) if len(choices)==1 else (None,'NO_UNIQUE_MODELED_EFFECT')
        if step is None:return dict(result,reason=reason)
        replies,_,maximum=([],[],None) if step.unresolved_residual else _replies(step.after,work,True)
        hazard=None if step.unresolved_residual else _refill_sword_hazard(step.after,work)
        return dict(result,status='MODELED',coverage=step.coverage,
            known_resources={g.value:dict(physical=step.resources.cells(g),effective=step.resources.effective(g))
                for g in GemType if g is not GemType.UNKNOWN},
            mana_cost=step.mana_cost,rage_cost=step.rage_cost,self_heal_present=step.heals_self,
            passive_physical_swords=step.passive_physical,passive_effective_swords=step.passive_swords,
            unresolved_local_effect=step.unresolved_residual,
            unresolved_refill_cells=sum(not c.known for row in step.after for c in row),
            known_reply_sword_max=maximum,known_reply_count=len(replies),
            known_reply_resource_maxima={g.value:{unit:max((
                r.resources.cells(g) if unit=='physical' else r.resources.effective(g) for r in replies),default=0)
                for unit in ('physical','effective')} for g in GemType if g is not GemType.UNKNOWN}
                if not step.unresolved_residual else None,
            known_reply_maxima_scope='SEPARATE_SINGLE_REPLY_MAXIMA_NOT_SIMULTANEOUS_OR_BOSS_POLICY',
            one_cell_refill_hazard=hazard,after_board_assumption='KNOWN_COLLAPSE_UNKNOWN_REFILL')
    except Exhausted as exc:
        return dict(result,reason='PROJECTION_BUDGET_'+str(exc))


def classify_pair(basic,reasoning):
    """Conservative mechanical screen, never an optimal-action certificate."""
    if basic['action']==reasoning['action']:
        return dict(category='SAME_ACTION',benefits=[],costs=[],unknowns=['ACTUAL_FUTURE_UNOBSERVED'])
    gaps=['ACTUAL_REFILL_UNOBSERVED','NET_MANA_RAGE_AND_DRAIN_EFFECT_UNKNOWN','DAMAGE_AND_KILL_UNKNOWN']
    if any(a['status']!='MODELED' for a in (basic,reasoning)):
        return dict(category='INSUFFICIENT_DATA',benefits=[],costs=[],unknowns=gaps+['UNMODELED_ACTION'])
    benefits=[];costs=[]
    def delta(name,a,b,smaller=False):
        if a==b:return
        (benefits if (b<a if smaller else b>a) else costs).append(dict(dimension=name,basic=a,reasoning=b))
    for gem in basic['known_resources']:
        for unit in ('physical','effective'):
            delta('collection.'+gem+'.'+unit,basic['known_resources'][gem][unit],reasoning['known_resources'][gem][unit])
    for name in ('mana_cost','rage_cost','unresolved_refill_cells'):
        delta(name,basic[name],reasoning[name],True)
    if basic['known_reply_sword_max'] is not None and reasoning['known_reply_sword_max'] is not None:
        delta('known_reply_sword_max',basic['known_reply_sword_max'],reasoning['known_reply_sword_max'],True)
    if basic.get('known_reply_resource_maxima') is not None and reasoning.get('known_reply_resource_maxima') is not None:
        for gem in basic['known_reply_resource_maxima']:
            for unit in ('physical','effective'):
                delta('known_reply_collection.'+gem+'.'+unit,basic['known_reply_resource_maxima'][gem][unit],
                    reasoning['known_reply_resource_maxima'][gem][unit],True)
    for name in ('effective_swords','completion_sites'):
        delta('one_cell_refill_hazard.'+name,(basic['one_cell_refill_hazard'] or {}).get(name,0),
            (reasoning['one_cell_refill_hazard'] or {}).get(name,0),True)
    if (basic['coverage']!=reasoning['coverage'] or any(a['unresolved_local_effect'] for a in (basic,reasoning))
            or any(a['action']['family']!='swap' for a in (basic,reasoning))
            or any(a['coverage']=='DEMON_PASSIVE_EFFECT_UNKNOWN' for a in (basic,reasoning))):
        category='INSUFFICIENT_DATA';gaps.append('INCOMPARABLE_HORIZON_OR_UNRESOLVED_EFFECT')
    elif benefits and costs:category='TRADEOFF'
    elif benefits:category='CONDITIONAL_MECHANICAL_ADVANTAGE'
    elif costs:category='REVIEW_IMMEDIATE_COST_WITHOUT_MEASURED_GAIN'
    else:category='NO_KNOWN_MECHANICAL_SEPARATION'
    return dict(category=category,benefits=benefits,costs=costs,unknowns=gaps,
        count_gain_is_not_net_benefit=True,setup_or_strategy_may_explain_immediate_cost=True,
        known_reply_zero_is_not_post_refill_safety=True)


def compare(problem):
    if type(problem) is not CommonProblem:raise ValueError('IMMUTABLE_COMMON_PROBLEM_REQUIRED')
    before=problem.to_dict()
    decision=plan_common(problem,clock=lambda:0)
    selected=decision.proposal or decision.baseline
    if decision.snapshot_id!=problem.snapshot_id or decision.baseline!=problem.baseline:
        raise ValueError('DECISION_SOURCE_MISMATCH')
    basic=project_action(problem,problem.baseline)
    reasoning=basic if selected==problem.baseline else project_action(problem,selected)
    chosen_score=next((s for s in decision.scores if s.action==selected),None)
    base_score=next((s for s in decision.scores if s.action==problem.baseline),None)
    if before!=problem.to_dict():raise ValueError('SOURCE_MUTATED')
    return dict(snapshot_id=problem.snapshot_id,profile=problem.intent.profile,source=problem.source.to_dict(),
        config_hash=problem.intent.config_hash,pre_action_facts=problem.facts.plain(),
        basic=basic,reasoning=reasoning,comparison=classify_pair(basic,reasoning),
        decision_reason=decision.reason,decision_diagnostics=decision.diagnostics.plain(),
        explanation=dict(basic=None if base_score is None else base_score.details.plain(),
            reasoning=None if chosen_score is None else chosen_score.details.plain()),
        same_pre_action_board_facts_settings=True,global_optimum_claim=False,quality_label=None,
        internal_utility_used_as_quality_label=False,win_or_turn_count_used_as_quality_label=False,
        observed_future_injected=False,training_eligible=False,input_authority=False)


def main():
    parser=argparse.ArgumentParser(__doc__)
    parser.add_argument('--problem',type=Path,required=True,help='One CommonProblem JSON')
    parser.add_argument('--out',type=Path,required=True)
    args=parser.parse_args();raw=args.problem.read_bytes()
    if len(raw)>2*1024*1024:raise ValueError('BOUNDED_PROBLEM_REQUIRED')
    source=source_fingerprint(ROOT)
    result=compare(CommonProblem.from_dict(json.loads(raw)))
    if source!=source_fingerprint(ROOT):raise ValueError('SOURCE_CHANGED_DURING_REPLAY')
    out=args.out.resolve()
    if not out.is_relative_to(ROOT):raise ValueError('OUTPUT_INSIDE_V2_REQUIRED')
    out.parent.mkdir(parents=True,exist_ok=True)
    with out.open('x',encoding='utf-8') as stream:json.dump(dict(source_sha256=source,case=result),stream,indent=2)
    print(json.dumps(result['comparison']))


if __name__=='__main__':main()
