"""Reconcile closed published resource intervals; no process/game IO or fitting.

Reported flow arithmetic is a retrospective hypothesis check. Neither a raw
``after`` key nor a zero residual certifies prospective transfer semantics.
"""
from collections import Counter
import argparse
import hashlib
import json
from pathlib import Path
import sys

ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from tools.normalize_boss_transitions import extract, checked_state
from tools.normalize_action_outcomes import integer
from pokiguard_v2.combat_outcome_evidence import MAX_STEPS,actor_identity
from pokiguard_v2.reasoning_common_capture import decode_snapshot_event
from pokiguard_v2.reasoning_common_planner import _root_step,CommonLimits,Work
from pokiguard_v2.board_simulator import SimulatedCell,SwapMove
from pokiguard_v2.state import GemType


def reconcile_resources(before,after,steps):
    """Both participants, ordered captured steps, no hidden tick/spend formula."""
    b=checked_state(before);a=checked_state(after)
    if (any(b[k]!=a[k] for k in ('match_id','lifecycle_epoch','board_instance','local_identity'))
            or a['turn']!=b['turn']+1 or a['server_sequence']<=b['server_sequence']
            or b['actor_identity']!='BOSS' or a['actor_identity']!=a['local_identity']):
        raise ValueError('RESOURCE_INTERVAL_IDENTITY_OR_BOUNDARIES')
    if type(steps) is not list or not 0<len(steps)<=MAX_STEPS:
        raise ValueError('RESOURCE_STEPS_SHAPE')
    who=b['local_identity'];previous=-1;gaps=[]
    for s in steps:
        if (type(s) is not dict or not integer(s.get('idx'),0) or s['idx']<=previous
                or not integer(s.get('amount')) or type(s.get('kind')) is not str
                or s.get('source') not in ('BOSS',who) or s.get('target') not in ('BOSS',who)):
            raise ValueError('RESOURCE_STEP_FIELDS_OR_ORDER')
        previous=s['idx']
        if s['amount']<0:gaps.append('SIGNED_AMOUNT_UNMODELED')
        if s['kind']=='STEAL' and (s.get('steal_type') not in ('MANA','POWER','HP') or s['source']==s['target']):
            gaps.append('TRANSFER_TYPE_OR_PARTICIPANTS_UNKNOWN')
        if s['kind'] not in ('MANA','POWER','STEAL','DAMAGE','BLOCK','HEAL','SHIELD'):
            gaps.append('OTHER_EFFECT_SEMANTICS_UNKNOWN')
    if len(b.get('bosses',()))!=1 or len(a.get('bosses',()))!=1:
        raise ValueError('ONE_BOSS_REQUIRED')
    rows=[]
    for identity,bs,end in [('BOSS',b['bosses'][0],a['bosses'][0]),(who,b['player'],a['player'])]:
        boss=identity=='BOSS'
        if (type(bs) is not dict or type(end) is not dict
                or any(s.get('is_boss') is not boss or s.get('is_local') is not (not boss) for s in (bs,end))
                or bs.get('actor_number')!=end.get('actor_number')):
            raise ValueError('RESOURCE_PARTICIPANT_IDENTITY')
        for wire,key in [('MANA','mana'),('POWER','power')]:
            values=[bs.get(key),end.get(key),bs.get('max_'+key),end.get('max_'+key)]
            if not all(integer(v,0) for v in values) or values[2]!=values[3] or max(values[:2])>values[2]:
                raise ValueError('RESOURCE_STATS_OR_CAPACITY')
            direct=sum(s['amount'] for s in steps if s['kind']==wire and s['target']==identity)
            received=sum(s['amount'] for s in steps if s['kind']=='STEAL' and s.get('steal_type')==wire and s['source']==identity)
            lost=sum(s['amount'] for s in steps if s['kind']=='STEAL' and s.get('steal_type')==wire and s['target']==identity)
            delta=end[key]-bs[key];flow=direct+received-lost
            rows.append(dict(role='BOSS' if identity=='BOSS' else 'LOCAL',resource=wire,before=bs[key],after=end[key],
                capacity=values[2],reported_direct=direct,reported_received=received,reported_lost=lost,
                reported_flow_delta=flow,observed_delta=delta,unexplained_delta=None if gaps else delta-flow,
                status='UNKNOWN_EFFECT_SEMANTICS' if gaps else 'REPORTED_FLOW_RECONCILES' if delta==flow else 'UNEXPLAINED_CHANGE',
                at_capacity=end[key]==values[2]))
    return dict(match_id=b['match_id'],source_turn=b['turn'],source_sequence=b['server_sequence'],
        after_sequence=a['server_sequence'],resources=rows,limits=sorted(set(gaps))+[
            'WHOLE_ACTION_COMPLETENESS_UNKNOWN','AFTER_KEY_OWNERSHIP_NOT_PROMOTED','NOT_A_SERVER_RESOURCE_FORMULA'],
        training_eligible=False,prediction=None)


def local_known_gains(path,problems):
    """Exact before-action adviser/input join; after stays retrospective only."""
    rows=[json.loads(l) for l in path.read_text(encoding='utf-8-sig').splitlines() if l.strip()]
    states=[(n,checked_state(r['stateEvidence'])) for n,r in enumerate(rows) if 'stateEvidence' in r]
    sends=[(n,r) for n,r in enumerate(rows) if r.get('event')=='action_sent']
    result=[];excluded=[]
    for index,(line,row) in enumerate(sends):
        if row.get('selectedAction')!='swap':continue
        s=row['identity']['source'];session=s['session'];match=session['match_id'];turn=s['turn']
        matches=[p for p in problems if p.source.match_id==match and p.source.turn==turn
            and p.source.srv_seq==s['srv_seq'] and p.source.board_hash==s['board_hash']
            and json.loads(p.source.session_id)==session
            and p.facts.plain().get('controller_source_hash')==s['critical_state_hash']]
        if len(matches)!=1:
            excluded.append(dict(match_id=match,turn=turn,reason='NO_UNIQUE_EXACT_ADVISER_SOURCE'));continue
        p=matches[0];upper=sends[index+1][0] if index+1<len(sends) else len(rows)
        choices=[state for n,state in states if line<n<upper and state['match_id']==match
            and state['lifecycle_epoch']==session['lifecycle_epoch'] and state['board_instance']==session['board_instance']
            and state['local_identity']==actor_identity(s['current_turn_player'])
            and state['turn']==turn+1 and state['actor_identity']=='BOSS' and state['server_sequence']>s['srv_seq']]
        unique={json.dumps(t,sort_keys=True):t for t in choices}
        if len(unique)!=1:
            excluded.append(dict(match_id=match,turn=turn,reason='NO_UNIQUE_PUBLISHED_POST_LOCAL_STATE'));continue
        if not any(r.get('event')=='action_result' and r.get('result')=='SWAP_ACKNOWLEDGED'
                and r.get('action',{}).get('identity')==row['identity'] for r in rows):
            excluded.append(dict(match_id=match,turn=turn,reason='NO_EXACT_SWAP_ACK'));continue
        state=next(iter(unique.values()))
        grid=tuple(tuple(SimulatedCell(GemType(g),m) for g,m in r) for r in p.board)
        root=_root_step(p,grid,SwapMove(*(tuple(v) for v in row['identity']['target'])),
            Work(CommonLimits(nodes=50000),lambda:0,lambda:False,None))
        if root is None:raise ValueError('RECORDED_SWAP_NOT_LEGAL')
        facts=p.facts.plain();gains={k:root.resources.effective(GemType(k))*facts['conversion'][k] for k in ('mana','rage')}
        before={k:facts['self'][k] for k in ('mana','rage')};after=dict(mana=state['player']['mana'],rage=state['player']['power'])
        gross={k:min(facts['self']['max_'+k],before[k]+gains[k]) for k in gains}
        result.append(dict(match_id=match,source_turn=turn,source_snapshot_id=p.snapshot_id,source_sequence=s['srv_seq'],
            before=before,declared_known_gain=gains,conditional_gross=gross,observed_after=after,
            swords=root.resources.effective(GemType.SWORD),root_coverage=root.coverage,
            unknown_cells=sum(not c.known for r in root.after for c in r),
            gross_matches_observed={k:gross[k]==after[k] for k in gains},
            observed_values_used_for_selection=False,training_eligible=False))
    return result,excluded


def audit(combats,reasoning_logs=()):
    problems=[];inputs={};boss=[];local=[];excluded=[];capture_gaps=[]
    for path in reasoning_logs:
        raw=path.read_bytes()
        if len(raw)>64*1024*1024:raise ValueError('BOUNDED_REASONING_LOG_REQUIRED')
        inputs[str(path)]=hashlib.sha256(raw).hexdigest()
        for line in raw.decode('utf-8-sig').splitlines():
            if not line.strip():continue
            if len(line.encode('utf-8'))>2*1024*1024:raise ValueError('BOUNDED_REASONING_LINE_REQUIRED')
            e=json.loads(line)
            if e.get('event_type')=='reasoning.common_snapshot':problems.append(decode_snapshot_event(e))
    for path in combats:
        case=extract(path)
        if case['excluded'] or case['unscoped_outcome_exclusions']:raise ValueError('INVALID_COMBAT_EVIDENCE')
        # extract() has already excluded any interval intersecting these gaps,
        # including late records with an in-range sequence. Retain the gaps.
        if case['outcome_exclusions']:
            capture_gaps.append(dict(source_log=str(path), exclusions=case['outcome_exclusions'],
                scopes=case['outcome_exclusion_scopes'], unbound=case['unbound']))
        inputs[str(path)]=case['sha256']
        for interval in case['intervals']:
            record=reconcile_resources(interval['before'],interval['after'],interval['effects'])
            record.update(source_log=str(path),raw_response_sha256=interval['raw_response_sha256'])
            boss.append(record)
        if problems:
            owned=[p for p in problems if any(p.source.match_id==s['match_id'] for s in case['intervals'])]
            if owned:
                a,b=local_known_gains(path,owned);local.extend(a);excluded.extend(b)
    summary=dict(boss_intervals=len(boss),local_intervals=len(local),
        boss_resource_checks=dict(Counter(r['status'] for i in boss for r in i['resources'])),
        residual_patterns=[dict(role=k[0],resource=k[1],unexplained_delta=k[2],count=v)
            for k,v in Counter((r['role'],r['resource'],r['unexplained_delta']) for i in boss for r in i['resources']).items()],
        local_gross_matches={k:sum(i['gross_matches_observed'][k] for i in local) for k in ('mana','rage')},
        local_attack_with_known_rage_gain=sum(i['swords']>0 and i['declared_known_gain']['rage']>0 for i in local),
        local_attack_gross_rage_mismatch=sum(i['swords']>0 and i['declared_known_gain']['rage']>0
            and not i['gross_matches_observed']['rage'] for i in local),
        local_excluded=dict(Counter(r['reason'] for r in excluded)),models_fitted=0,training_eligible=0)
    return dict(schema='pokiguard.resource_balance_audit.v1',summary=summary,boss_intervals=boss,
        local_intervals=local,local_excluded=excluded,capture_gaps=capture_gaps,inputs=inputs,process_attachment=False,
        windows_input=False,prospective_after_values_injected=False,server_formula=None)


def main():
    parser=argparse.ArgumentParser(__doc__)
    parser.add_argument('--combat',type=Path,action='append',required=True)
    parser.add_argument('--reasoning-log',type=Path,action='append',default=[])
    parser.add_argument('--out',type=Path,required=True)
    args=parser.parse_args();out=args.out.resolve()
    if not out.is_relative_to(ROOT):raise ValueError('OUTPUT_INSIDE_V2_REQUIRED')
    result=audit(sorted(set(args.combat)),sorted(set(args.reasoning_log)))
    out.parent.mkdir(parents=True,exist_ok=True)
    with out.open('x',encoding='utf-8') as stream:json.dump(result,stream,indent=2)
    print(json.dumps(result['summary']))

if __name__=='__main__':main()
