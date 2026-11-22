"""Offline resource endpoints and delivered STAT_CHANGE order, never a formula.

Combat steps and UI operations are two views of effects. Do not add them
together or interleave their independent indexes. Affordability is not input
authority, cooldown, current ownership, or proof a skill can be used next turn.
"""
from collections import Counter
from pathlib import Path
import argparse
import hashlib
import json
import sys

ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from tools.normalize_action_outcomes import extract,integer
from tools.normalize_boss_transitions import checked_state,outcome_exclusion_scopes,exclusion_affects_interval
from pokiguard_v2.reasoning_common_tactics import skill_resource_readiness
from pokiguard_v2.reasoning_common_problem import CommonProblem

RESOURCES=(('MANA','mana'),('POWER','power'))


def affordability(requirements,own):
    if type(requirements) is not dict or type(own) is not dict:
        return dict(status='UNKNOWN',affordable=None,reason='COSTS_OR_BALANCES_MISSING')
    if any(not integer(requirements.get(k),0) for k in ('mana','rage')):
        return dict(status='UNKNOWN',affordable=None,reason='BOTH_COSTS_REQUIRED')
    if any(not integer(own.get(k),0) for k in ('mana','rage')):
        return dict(status='UNKNOWN',affordable=None,reason='BOTH_BALANCES_REQUIRED')
    return dict(status='RESOURCE_AFFORDABILITY_ONLY',
        affordable=all(own[k]>=requirements[k] for k in ('mana','rage')),
        shortfall={k:max(0,requirements[k]-own[k]) for k in ('mana','rage')},input_authority=False)


def audit_snapshot(problem):
    if type(problem) is not CommonProblem:raise ValueError('IMMUTABLE_COMMON_PROBLEM_REQUIRED')
    facts=problem.facts.plain();requirements=facts.get('resource_requirements');own=facts.get('self',{})
    check=affordability(requirements,own)
    readiness=skill_resource_readiness(requirements or {},own,{})
    # Free skills need no resource-progress score; owner eligibility remains
    # separate. Otherwise readiness=1 must agree with both observed balances.
    if (check['affordable'] is not None and any((requirements or {}).values())
            and ((readiness==1)!=check['affordable'])):raise ValueError('READINESS_AFFORDABILITY_CONTRADICTION')
    effects=[e for e in problem.effects if e.action.family=='pet_skill']
    contradictions=[]
    for effect in effects:
        costs=dict(mana=effect.mana_cost,rage=effect.rage_cost)
        actual=affordability(costs,own)
        if effect.eligible and actual['affordable'] is False:
            contradictions.append('ELIGIBLE_SKILL_WITH_INSUFFICIENT_ACTUAL_RESOURCES')
        if check['affordable'] is not None and all(integer(v,0) for v in costs.values()) and costs!=requirements:
            contradictions.append('REQUIREMENT_AND_EFFECT_COST_MISMATCH')
    return dict(snapshot_id=problem.snapshot_id,profile=problem.intent.profile,
        provenance=problem.provenance.to_dict(),requirements=requirements,own=own,
        resource_check=check,readiness_before=readiness,pet_skill_effects=len(effects),
        eligible_pet_skill_effects=sum(e.eligible for e in effects),contradictions=contradictions,
        next_turn_skill_usable=None,training_eligible=False,input_authority=False)


def participant_stats(state,identity):
    if len(state.get('bosses',()))!=1:raise ValueError('ONE_BOSS_REQUIRED')
    local=identity==state['local_identity']
    if identity not in ('BOSS',state['local_identity']):raise ValueError('PARTICIPANT_IDENTITY')
    value=state['player'] if local else state['bosses'][0]
    if (type(value) is not dict or value.get('is_local') is not local
            or value.get('is_boss') is not (not local) or not integer(value.get('actor_number'),0)):
        raise ValueError('PARTICIPANT_ROLE')
    for _,key in RESOURCES:
        if (not integer(value.get(key),0) or not integer(value.get('max_'+key),0)
                or value[key]>value['max_'+key]):raise ValueError('RESOURCE_VALUE_OR_CAPACITY')
    return value


def audit_interval(before,after,observation):
    b=checked_state(before);a=checked_state(after)
    if (any(b[k]!=a[k] for k in ('match_id','lifecycle_epoch','board_instance','local_identity'))
            or b['actor_identity']!=observation['actor_identity'] or a['actor_identity']==b['actor_identity']
            or a['turn']!=b['turn']+1 or a['server_sequence']!=observation['server_sequence']
            or observation['match_id']!=b['match_id'] or b['server_sequence']>=a['server_sequence']):
        raise ValueError('RESOURCE_INTERVAL_IDENTITY')
    operations=observation.get('resource_operations')
    result=[]
    for identity in ('BOSS',b['local_identity']):
        initial=participant_stats(b,identity);end=participant_stats(a,identity)
        if initial['actor_number']!=end['actor_number']:raise ValueError('PARTICIPANT_CHANGED')
        for stat,key in RESOURCES:
            cap=initial['max_'+key]
            if cap!=end['max_'+key]:raise ValueError('RESOURCE_CAPACITY_CHANGED')
            current=initial[key];checks=[];missing=False;reported=0;updates=0
            previous_index=-1
            for op in operations or []:
                if not integer(op.get('operation_index'),0) or op['operation_index']<=previous_index:
                    raise ValueError('RESOURCE_OPERATION_ORDER')
                previous_index=op['operation_index']
                if op['type']!='STAT_CHANGE':continue
                if (op.get('stat_type') in ('MANA','POWER') and op.get('target') is not None
                        and op['target'] not in ('BOSS',b['local_identity'])):
                    raise ValueError('UNKNOWN_RESOURCE_PARTICIPANT')
                if op.get('target') is None or op.get('stat_type') is None:
                    current=None;missing=True;continue
                if op['target']!=identity or op['stat_type']!=stat:continue
                delta,value=op.get('delta'),op.get('new_value');updates+=1
                if delta is not None and not integer(delta):raise ValueError('STAT_DELTA_TYPE')
                if value is not None and not integer(value,0):raise ValueError('STAT_VALUE_TYPE')
                if value is not None and value>cap:raise ValueError('STAT_VALUE_ABOVE_PUBLISHED_CAPACITY')
                expected=None if current is None or delta is None else current+delta
                status=('UNKNOWN_BASELINE_OR_DELTA' if expected is None or value is None else
                    'EXACT_REPORTED_DELTA' if expected==value else
                    'CAP_OR_FLOOR_PATTERN_OBSERVED' if max(0,min(cap,expected))==value else
                    'UNEXPLAINED_REPORTED_DELTA')
                checks.append(dict(operation_index=op['operation_index'],before=current,reported_delta=delta,
                    new_value=value,status=status,reason=op.get('reason'),source_label=op.get('source_label')))
                if delta is not None:reported+=delta
                else:missing=True
                current=value
            final_status=('TRACE_ABSENT' if operations is None else 'TRACE_FIELD_UNKNOWN' if missing else
                'LAST_STAT_EQUALS_ENDPOINT' if updates and current==end[key] else
                'LAST_STAT_DIFFERS_FROM_ENDPOINT' if updates else 'NO_RESOURCE_UPDATE_CAPTURED')
            result.append(dict(role='LOCAL' if identity==b['local_identity'] else 'BOSS',resource=stat,
                before=initial[key],after=end[key],capacity=cap,observed_delta=end[key]-initial[key],
                reported_stat_delta_sum=reported if not missing and operations is not None else None,
                checks=checks,last_stat_value=current if updates else None,endpoint_status=final_status,
                stat_operation_count=updates))
    return dict(match_id=b['match_id'],actor_role='BOSS' if observation['actor_identity']=='BOSS' else 'LOCAL',
        source_turn=b['turn'],source_sequence=b['server_sequence'],after_sequence=a['server_sequence'],
        raw_response_sha256=observation['provenance']['raw_response_sha256'],resources=result,
        whole_action_completeness='UNKNOWN',server_resource_formula=None,
        training_eligible=False,input_authority=False)


def audit_file(path):
    path=Path(path);case=extract(path)
    # extract() already bounds the file/line sizes and validates the outcomes.
    raw=path.read_bytes()
    if hashlib.sha256(raw).hexdigest()!=case['sha256']:raise ValueError('COMBAT_CHANGED_DURING_AUDIT')
    rows=[];states=[];invalid=[]
    for line,text in enumerate(raw.decode('utf-8-sig').splitlines(),1):
        if not text.strip():continue
        try:
            row=json.loads(text)
            if type(row) is not dict:raise ValueError('ROW_NOT_OBJECT')
            rows.append((line,row))
            if 'stateEvidence' in row:states.append((line,checked_state(row['stateEvidence'])))
        except (ValueError,TypeError,KeyError) as exc:invalid.append(dict(line=line,reason=str(exc)[:96]))
    scopes=outcome_exclusion_scopes(case['excluded'],rows)
    intervals=[];excluded=[]
    for obs in case['observations']:
        record=dict(sequence=obs['server_sequence'],raw_response_sha256=obs['provenance']['raw_response_sha256'])
        candidates=[]
        for bn,b in states:
            if b['match_id']!=obs['match_id'] or b['actor_identity']!=obs['actor_identity'] or b['server_sequence']>=obs['server_sequence']:continue
            for an,a in states:
                if (an>bn and all(a[k]==b[k] for k in ('match_id','lifecycle_epoch','board_instance','local_identity'))
                        and a['turn']==b['turn']+1 and a['actor_identity']!=b['actor_identity']
                        and a['server_sequence']==obs['server_sequence']):candidates.append((bn,b,an,a))
        unique={json.dumps([b,a],sort_keys=True):(bn,b,an,a) for bn,b,an,a in candidates}
        if len(unique)!=1:
            excluded.append(dict(record,reason='NO_UNIQUE_PUBLISHED_RESOURCE_BOUNDARIES'));continue
        bn,b,an,a=next(iter(unique.values()))
        if (any(exclusion_affects_interval(s,bn,b,an,a) for s in scopes)
                or any(bn<=s['line']<=an for s in invalid)):
            excluded.append(dict(record,reason='INVALID_EVIDENCE_IN_RESOURCE_INTERVAL'));continue
        peers=[r for r in case['observations'] if r is not obs and r['match_id']==b['match_id']
            and b['server_sequence']<r['server_sequence']<=a['server_sequence']]
        if peers:
            excluded.append(dict(record,reason='MULTIPLE_RESPONSES_IN_RESOURCE_INTERVAL'));continue
        if obs['actor_identity']!='BOSS':
            binding=obs['action_binding'];source=binding.get('source') or {};session=source.get('session') or {}
            if (binding['status']!='EXACT_SWAP_SENT_ACK' or source.get('srv_seq')!=b['server_sequence']
                    or source.get('turn')!=b['turn'] or source.get('board_hash')!=b['board_hash']
                    or any(session.get(k)!=b[k] for k in ('match_id','lifecycle_epoch','board_instance'))):
                excluded.append(dict(record,reason='NO_EXACT_LOCAL_SWAP_ACK_BOUNDARY'));continue
        elif any(bn<n<an and r.get('event')=='action_sent' for n,r in rows):
            excluded.append(dict(record,reason='LOCAL_INPUT_DURING_BOSS_INTERVAL'));continue
        try:
            result=audit_interval(b,a,obs);result.update(before_line=bn,after_line=an)
            intervals.append(result)
        except (ValueError,TypeError,KeyError) as exc:excluded.append(dict(record,reason=str(exc)[:96]))
    return dict(path=str(path),sha256=case['sha256'],observations=len(case['observations']),intervals=intervals,
        excluded=excluded,capture_exclusions=case['excluded'],invalid_states=invalid,
        bound_only_for_observation=True,training_eligible=False)


def summarize(cases):
    intervals=[r for c in cases for r in c['intervals']]
    resources=[r for i in intervals for r in i['resources']]
    checks=[r for resource in resources for r in resource['checks']]
    return dict(files=len(cases),observations=sum(c['observations'] for c in cases),intervals=len(intervals),
        by_actor=dict(Counter(r['actor_role'] for r in intervals)),
        endpoints=dict(Counter(r['endpoint_status'] for r in resources)),
        delta_checks=dict(Counter(r['status'] for r in checks)),
        full_power_updates=sum(r['reason']=='FULL_POWER' for r in checks),
        excluded=dict(Counter(r['reason'] for c in cases for r in c['excluded'])),
        capture_exclusions=sum(len(c['capture_exclusions']) for c in cases),
        models_fitted=0,training_eligible=0,process_attachment=False,windows_input=False)


def main():
    p=argparse.ArgumentParser(__doc__);p.add_argument('--combat',type=Path,action='append',required=True)
    p.add_argument('--out',type=Path,required=True);args=p.parse_args()
    out=args.out.resolve()
    if not out.is_relative_to(ROOT):raise ValueError('OUTPUT_INSIDE_V2_REQUIRED')
    cases=[audit_file(path) for path in sorted(set(args.combat))];summary=summarize(cases)
    out.parent.mkdir(parents=True,exist_ok=True)
    with out.open('x',encoding='utf-8') as stream:json.dump(dict(summary=summary,cases=cases),stream,indent=2)
    print(json.dumps(summary))


if __name__=='__main__':main()
