"""File-only typed outcomes for every captured action; no fitting or game IO.

Action joins currently attest the existing SWAP sent/ACK protocol only. Other
responses remain useful typed observations with explicitly unbound actions.
Raw after-key arithmetic is a hypothesis check, never a prospective model.
"""
from collections import Counter,defaultdict
from copy import deepcopy
import argparse,hashlib,json
from pathlib import Path
import sys

ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.combat_outcome_evidence import (
    SCHEMA as CAPTURE_SCHEMA,MAX_STEPS,MAX_OPERATIONS,RESPONSE_TYPES,actor_identity,observed_effect_totals,
)

SCHEMA='pokiguard.action_outcome_observation.v1'
FIELDS={'DAMAGE':('HP',-1),'HEAL':('HP',1),'BLOCK':('SHIELD',-1),
    'SHIELD':('SHIELD',1),'MANA':('MANA',1),'POWER':('POWER',1)}
STAT_FIELDS={'HP':('hp','max_hp'),'MANA':('mana','max_mana'),
    'POWER':('power','max_power'),'SHIELD':('shield',None)}


def integer(value,minimum=-(2**31),maximum=2**31-1):
    return type(value) is int and minimum<=value<=maximum


def text(value,limit=256):
    return type(value) is str and 0<len(value)<=limit and all(ord(c)>=32 for c in value)


def digest(value):return hashlib.sha256(value).hexdigest()
def canonical(value):return json.dumps(value,sort_keys=True,separators=(',',':'))
def hash_value(value):return type(value) is str and len(value)==64 and all(c in '0123456789abcdef' for c in value)
def actor(value):return value=='BOSS' or (type(value) is str and value.startswith('sha256:') and hash_value(value[7:]))


def checked(record):
    if (type(record) is not dict or record.get('schema')!=CAPTURE_SCHEMA
            or record.get('status')!='CAPTURED' or record.get('input_authority') is not False):
        raise ValueError('NOT_CAPTURED_OBSERVATION')
    e=deepcopy(record.get('evidence'))
    if (type(e) is not dict or not text(e.get('match_id')) or not integer(e.get('server_sequence'),0,10000000)
            or e.get('event_type') not in RESPONSE_TYPES or not actor(e.get('actor_identity'))
            or not hash_value(e.get('raw_sha256'))):raise ValueError('OUTCOME_IDENTITY')
    steps=e.get('steps')
    if type(steps) is not list or not 0<len(steps)<=MAX_STEPS:raise ValueError('STEPS_SHAPE')
    previous=-1
    for step in steps:
        if (type(step) is not dict or not integer(step.get('idx'),0) or step['idx']<=previous
                or not text(step.get('kind'),32) or not integer(step.get('amount'))
                or not actor(step.get('source')) or not actor(step.get('target'))):raise ValueError('STEP_FIELDS_OR_ORDER')
        previous=step['idx']
        for name in ('damage_source','steal_type'):
            if step.get(name) is not None and not text(step[name],64):raise ValueError('STEP_OPTIONAL_TYPE')
            step.setdefault(name,None)
        if step.get('full_power') is not None and type(step['full_power']) is not bool:raise ValueError('STEP_OPTIONAL_TYPE')
        if 'full_power_presence' in step:
            presence=step['full_power_presence']
            if (presence not in ('ABSENT','NULL','VALUE')
                    or presence=='VALUE' and type(step.get('full_power')) is not bool
                    or presence in ('ABSENT','NULL') and step.get('full_power') is not None):
                raise ValueError('FULL_POWER_PRESENCE_CONFLICT')
        step.setdefault('full_power',None)
        after=step.get('after')
        if after is not None and (type(after) is not dict or len(after)>32 or any(
                not text(k,64) or not integer(v) for k,v in after.items())):raise ValueError('AFTER_FIELDS')
        step.setdefault('after',None)
    wire=e.get('wire_swap')
    if wire is not None and (type(wire) is not list or len(wire)!=4 or any(not integer(v,0,7) for v in wire)
            or abs(wire[0]-wire[2])+abs(wire[1]-wire[3])!=1):raise ValueError('WIRE_MOVE_DOMAIN')
    operations=e.get('swap_operations')
    if operations is not None:
        if (type(operations) is not list or len(operations)>MAX_OPERATIONS
                or e.get('swap_operation_source')!='matchPayload.ops[].data'
                or e.get('swap_operation_decision_binding')!='UNKNOWN'):
            raise ValueError('SWAP_OPERATION_PROVENANCE')
        previous=-1
        for operation in operations:
            if type(operation) is not dict:raise ValueError('SWAP_OPERATION_FIELDS')
            index=operation.get('operation_index');move=operation.get('native_swap')
            if (not integer(index,0,MAX_OPERATIONS-1) or index<=previous or operation.get('type')!='SWAP'
                    or type(move) is not list or len(move)!=4 or any(not integer(v,0,7) for v in move)
                    or abs(move[0]-move[2])+abs(move[1]-move[3])!=1):
                raise ValueError('SWAP_OPERATION_FIELDS')
            previous=index
    resource_ops=e.get('resource_operations')
    projection=e.get('operation_projection')
    if projection is not None:
        if (type(projection) is not dict or set(projection)!={
                'status','reason','operation_count','operation_limit','complete'}
                or projection['status']!='OMITTED' or projection['reason']!='OPERATION_LIMIT'
                or type(projection['operation_limit']) is not int or projection['operation_limit']!=MAX_OPERATIONS
                or not integer(projection['operation_count'],MAX_OPERATIONS+1)
                or projection['complete'] is not False
                or operations is not None or resource_ops is not None):
            raise ValueError('OPERATION_OMISSION_PROVENANCE')
    if resource_ops is not None:
        if (type(resource_ops) is not list or len(resource_ops)>MAX_OPERATIONS
                or e.get('resource_operation_source')!='matchPayload.ops[].data'
                or e.get('resource_operation_semantics')!='RAW_ORDERED_OBSERVATION_NOT_A_PREDICTION'):
            raise ValueError('RESOURCE_OPERATION_PROVENANCE')
        previous=-1
        for operation in resource_ops:
            if type(operation) is not dict:raise ValueError('RESOURCE_OPERATION_FIELDS')
            index=operation.get('operation_index');kind=operation.get('type')
            if not integer(index,0,MAX_OPERATIONS-1) or index<=previous:
                raise ValueError('RESOURCE_OPERATION_ORDER')
            previous=index
            if kind=='STAT_CHANGE':
                target=operation.get('target')
                if target is not None and not actor(target):raise ValueError('STAT_TARGET_IDENTITY')
                for key in ('stat_type','reason','source_label'):
                    if operation.get(key) is not None and not text(operation[key],64):raise ValueError('STAT_TEXT')
                if any(operation.get(k) is not None and not integer(operation[k]) for k in ('delta','new_value')):
                    raise ValueError('STAT_INTEGER')
            elif kind=='DESTROY':
                positions=operation.get('native_positions')
                if (operation.get('position_order')!='COL_ROW' or operation.get('tag_multiplier_binding')!='UNKNOWN'
                        or positions is not None and (type(positions) is not list or len(positions)>64
                        or any(type(p) is not list or len(p)!=2 or any(not integer(v,0,7) for v in p) for p in positions))):
                    raise ValueError('DESTROY_POSITION_DOMAIN')
                status=operation.get('positions_status')
                if status is not None:
                    if (status not in ('READ_NATIVE_FIRST_TWO','UNKNOWN_ABSENT','UNVERIFIED_FORMAT')
                            or (positions is not None)!=(status=='READ_NATIVE_FIRST_TWO')):
                        raise ValueError('DESTROY_POSITION_STATUS')
                    trailing=operation.get('unmodeled_trailing_values')
                    if trailing is not None and type(trailing) is not bool:raise ValueError('DESTROY_TRAILING_STATUS')
                    shape=operation.get('position_shape')
                    if shape is not None and (type(shape) is not dict or set(shape)!={'container','count','first_item','first_arity'}
                            or not text(shape['container'],32) or shape['first_item'] is not None and not text(shape['first_item'],32)
                            or any(shape[k] is not None and not integer(shape[k],0) for k in ('count','first_arity'))):
                        raise ValueError('DESTROY_POSITION_SHAPE')
            else:raise ValueError('RESOURCE_OPERATION_KIND')
    return e


def source_of(sent):
    identity=sent.get('identity');s=identity.get('source') if type(identity) is dict else None
    if type(s) is not dict or type(s.get('session')) is not dict:raise ValueError('ACTION_SOURCE_MISSING')
    if (not text(s['session'].get('match_id')) or not integer(s.get('srv_seq'),0)
            or not integer(s.get('turn'),1) or not text(s.get('current_turn_player'))
            or not hash_value(s.get('board_hash')) or not hash_value(s.get('critical_state_hash'))):
        raise ValueError('ACTION_SOURCE_FIELDS')
    if sent.get('matchId')!=s['session']['match_id'] or sent.get('boardHash')!=s['board_hash']:
        raise ValueError('ACTION_SOURCE_MISMATCH')
    return s


def bind(e,line,sends,results,responses):
    empty=dict(status='UNBOUND',reason='NO_VERIFIED_ACTION_SOURCE',acknowledged=False,source=None)
    if e['actor_identity']=='BOSS':return dict(empty,reason='BOSS_MOVE_NOT_IDENTIFIED'),None
    if e['event_type']!='MATCH_MOVE_RES':return dict(empty,reason='CARD_SKILL_SENT_ACK_BINDING_NOT_VERIFIED'),None
    candidates=[]
    for i,(n,sent) in enumerate(sends):
        try:s=source_of(sent)
        except (ValueError,KeyError,TypeError):continue
        next_line=sends[i+1][0] if i+1<len(sends) else 2**63
        if not (n<line<next_line and s['session']['match_id']==e['match_id']
                and actor_identity(s['current_turn_player'])==e['actor_identity']
                and s['srv_seq']<e['server_sequence']):continue
        upper=None
        if i+1<len(sends):
            try:upper=source_of(sends[i+1][1])['srv_seq']
            except (ValueError,KeyError,TypeError):continue
            if not s['srv_seq']<e['server_sequence']<=upper:continue
        identity=sent['identity'];target=identity.get('target')
        if (identity.get('action')!='swap' or sent.get('selectedAction')!='swap'
                or type(target) is not list or len(target)!=2
                or any(type(p) is not list or len(p)!=2 or any(not integer(v,0,7) for v in p) for p in target)
                or sum(abs(a-b) for a,b in zip(*target))!=1):continue
        same_source=[other for _,other in sends if type(other.get('identity')) is dict
            and other['identity'].get('source')==s]
        if len(same_source)!=1:return dict(empty,reason='AMBIGUOUS_SOURCE_ACTION'),None
        peers=[ev for ln,ev in responses if n<ln<next_line and ev['match_id']==e['match_id']
            and ev['actor_identity']==e['actor_identity'] and ev['event_type']==e['event_type']
            and s['srv_seq']<ev['server_sequence'] and (upper is None or ev['server_sequence']<=upper)]
        if len(peers)!=1:return dict(empty,reason='AMBIGUOUS_RESPONSE_WINDOW'),None
        candidates.append((n,sent,s))
    if len(candidates)!=1:return dict(empty,reason='AMBIGUOUS_ACTION' if candidates else empty['reason']),None
    n,sent,s=candidates[0]
    acknowledged=any(r.get('result')=='SWAP_ACKNOWLEDGED'
        and type(r.get('action')) is dict and r['action'].get('identity')==sent['identity'] for _,r in results)
    sanitized=dict(s);sanitized.pop('current_turn_player');sanitized['actor_identity']=e['actor_identity']
    return dict(status='EXACT_SWAP_SENT_ACK' if acknowledged else 'SENT_WITHOUT_EXACT_ACK',
        reason='UNIQUE_ACTOR_SEQUENCE_AND_LINE_INTERVAL_NOT_WIRE_ECHO',acknowledged=acknowledged,
        source=sanitized,action=dict(family='swap',target=sent['identity']['target']),action_line=n),sent


def raw_ledger(e,sent):
    """Check arithmetic against raw target-after keys without declaring semantics."""
    values={};caps={};out=[]
    if sent is not None:
        who=actor_identity(sent['identity']['source']['current_turn_player'])
        for identity,name in ((who,'player'),('BOSS','boss')):
            stats=sent.get(name,{})
            if type(stats) is not dict:continue
            if name=='player' and not (stats.get('is_local') is True and stats.get('is_boss') is False):continue
            if name=='boss' and not (stats.get('is_boss') is True and stats.get('is_local') is False):continue
            for field,(value_name,cap_name) in STAT_FIELDS.items():
                v=stats.get(value_name);cap=stats.get(cap_name)
                values[identity,field]=v if integer(v,0) else None
                caps[identity,field]=cap if integer(cap,0) else None
    for step in e['steps']:
        after=step.get('after') or {};kind=step['kind'];target=step['target'];amount=step['amount']
        item=dict(idx=step['idx'],kind=kind,source=step['source'],target=target,reported_amount=amount,
            raw_after=step['after'],status='UNINTERPRETED',check='RAW_TARGET_AFTER_KEY_ARITHMETIC_HYPOTHESIS')
        if kind not in FIELDS:
            # STEAL can describe the receiver or sender; do not assign its
            # after value to either actor or carry stale balances through it.
            for identity in (step['source'],target):
                for field in STAT_FIELDS:values[identity,field]=None
            item['reason']='TRANSFER_AFTER_SEMANTICS_UNKNOWN' if kind=='STEAL' else 'EFFECT_SEMANTICS_UNKNOWN'
            out.append(item);continue
        field,sign=FIELDS[kind];before=values.get((target,field));end=after.get(field);cap=caps.get((target,field))
        end=end if integer(end,0) else None
        item.update(field=field,before=before,after=end,capacity=cap,observed_delta=None)
        if end is None:
            values[target,field]=None;item.update(status='UNKNOWN',reason='RAW_AFTER_KEY_MISSING')
        elif before is None:
            values[target,field]=end;item.update(status='UNKNOWN',reason='BASELINE_UNKNOWN')
        else:
            delta=end-before;expected=sign*amount
            item['observed_delta']=delta
            if amount<0:item.update(status='UNKNOWN',reason='SIGNED_EFFECT_SEMANTICS_UNKNOWN')
            elif delta==expected:item.update(status='EXACT_RAW_DELTA_MATCH',reason='NO_PROSPECTIVE_CREDIT')
            elif sign>0 and cap is not None and before<=cap and before+amount>cap and end==cap:
                item.update(status='CAP_PATTERN_OBSERVED',reason='CLAMP_SEMANTICS_NOT_VERIFIED')
            elif sign<0 and amount>before and end==0:
                item.update(status='ZERO_FLOOR_PATTERN_OBSERVED',reason='TERMINAL_OR_CENSORING_NOT_AN_EXACT_DELTA')
            else:item.update(status='RAW_DELTA_MISMATCH',reason='ORDER_CAP_OR_COMPLETE_EFFECT_COVERAGE_UNKNOWN')
            values[target,field]=end
        out.append(item)
    return out


def extract(path):
    path=Path(path)
    if path.stat().st_size>64*1024*1024:raise ValueError('BOUNDED_COMBAT_FILE_REQUIRED')
    raw=path.read_bytes()
    if len(raw)>64*1024*1024:raise ValueError('BOUNDED_COMBAT_FILE_REQUIRED')
    lines=raw.decode('utf-8-sig').splitlines();parsed=[];excluded=[]
    for n,line in enumerate(lines,1):
        if not line.strip():continue
        try:
            if len(line.encode('utf-8'))>2*1024*1024:raise ValueError('LINE_TOO_LARGE')
            row=json.loads(line)
            if type(row) is not dict:raise ValueError('ROW_NOT_OBJECT')
            parsed.append((n,row))
        except ValueError as exc:excluded.append(dict(line=n,reason=str(exc)[:100]))
    sends=[(n,r) for n,r in parsed if r.get('event')=='action_sent']
    results=[(n,r) for n,r in parsed if r.get('event')=='action_result']
    groups=defaultdict(list)
    for n,row in parsed:
        if 'combatOutcome' not in row:continue
        try:e=checked(row['combatOutcome'])
        except (ValueError,TypeError,KeyError) as exc:
            excluded.append(dict(line=n,reason=str(exc)[:100]));continue
        groups[e['match_id'],e['server_sequence'],e['event_type'],e['actor_identity']].append((n,e))
    observations=[];duplicates=0
    responses=[group[0] for group in groups.values()]
    for identity,group in groups.items():
        # Same raw message can be offered through both diagnostic paths.
        # Optional membership may fit one path's byte budget but not another.
        # Absence of this metadata cannot turn identical effects into conflict.
        compare=lambda e:{k:([{a:b for a,b in s.items() if a!='full_power_presence'} for s in v]
            if k=='steps' else v) for k,v in e.items() if k not in ('accepted_board_attached','provenance')}
        if len({canonical(compare(e)) for _,e in group})!=1:
            excluded.append(dict(lines=[n for n,_ in group],reason='CONFLICTING_OUTCOME_IDENTITY'));continue
        memberships=[{e['steps'][i]['full_power_presence'] for _,e in group
            if 'full_power_presence' in e['steps'][i]} for i in range(len(group[0][1]['steps']))]
        if any(len(values)>1 for values in memberships):
            excluded.append(dict(lines=[n for n,_ in group],reason='CONFLICTING_OUTCOME_IDENTITY'));continue
        duplicates+=len(group)-1;n,e=group[0]
        for step,values in zip(e['steps'],memberships):
            if values:step['full_power_presence']=next(iter(values))
        binding,sent=bind(e,n,sends,results,responses)
        notes=['WHOLE_ACTION_COMPLETENESS_UNKNOWN','DAMAGE_BUFF_CRIT_AND_ELEMENT_CONTEXT_UNKNOWN',
            'NO_COUNTERFACTUAL_OUTCOMES','NOT_A_PREDICTIVE_MODEL']
        if not binding['acknowledged']:notes.append('NO_EXACT_ACTION_ACK')
        if any(s['kind']=='STEAL' and s.get('steal_type') is None for s in e['steps']):notes.append('STEAL_TYPE_MISSING')
        if [s['idx'] for s in e['steps']]!=list(range(len(e['steps']))):notes.append('INCOMPLETE_STEP_INDEX')
        terminal=sorted({s['target'] for s in e['steps'] if s['kind']=='DAMAGE' and (s.get('after') or {}).get('HP')==0})
        if terminal:notes.append('ZERO_HP_CENSORED')
        if e.get('swap_operations') is None:notes.append('SWAP_OPERATION_DATA_NOT_CAPTURED')
        elif e['swap_operations']:notes.append('SWAP_OPERATION_DECISION_BINDING_UNKNOWN')
        if e.get('operation_projection') is not None:notes.append('OPTIONAL_OPERATIONS_OMITTED_LIMIT')
        observations.append(dict(schema=SCHEMA,match_id=e['match_id'],server_sequence=e['server_sequence'],
            event_type=e['event_type'],actor_identity=e['actor_identity'],action_binding=binding,
            wire_swap=e.get('wire_swap'),wire_coordinate_semantics='RAW_NATIVE_UNVERIFIED_VIEW_MAPPING',
            swap_operations=e.get('swap_operations'),
            swap_operation_source=e.get('swap_operation_source'),swap_operation_decision_binding='UNKNOWN',
            resource_operations=e.get('resource_operations'),resource_operation_source=e.get('resource_operation_source'),
            resource_operation_semantics=e.get('resource_operation_semantics'),
            card_ids=e.get('card_ids'),destroyed_by_tag=e.get('destroyed_by_tag'),steps=e['steps'],
            effect_totals=list(observed_effect_totals(dict(schema=CAPTURE_SCHEMA,status='CAPTURED',evidence=e))),
            raw_ledger=raw_ledger(e,sent),zero_hp_targets=terminal,
            provenance=dict(combat_sha256=digest(raw),outcome_lines=[i for i,_ in group],
                line_sha256=digest(lines[n-1].encode('utf-8')),raw_response_sha256=e['raw_sha256']),
            observation_limits=notes,calibration_eligible=False,training_eligible=False,
            prediction=None,input_authority=False))
        if e.get('operation_projection') is not None:
            observations[-1]['operation_projection']=e['operation_projection']
    return dict(path=str(path),sha256=digest(raw),observations=observations,excluded=excluded,
        duplicate_outcomes=duplicates)


def summarize(cases):
    observations=[r for case in cases for r in case['observations']]
    return dict(schema='pokiguard.action_outcome_corpus.v1',files=len(cases),observations=len(observations),
        by_response=dict(Counter(r['event_type'] for r in observations)),
        by_action_binding=dict(Counter(r['action_binding']['status'] for r in observations)),
        effects=dict(Counter(s['kind'] for r in observations for s in r['steps'])),
        ledger_checks=dict(Counter(s['status'] for r in observations for s in r['raw_ledger'])),
        limits=dict(Counter(v for r in observations for v in r['observation_limits'])),
        excluded=dict(Counter(r['reason'] for c in cases for r in c['excluded'])),
        duplicates=sum(c['duplicate_outcomes'] for c in cases),models_fitted=0,training_eligible=0,
        input_authority=False,process_attachment=False,windows_input=False)


def main():
    p=argparse.ArgumentParser(__doc__);p.add_argument('--combat',type=Path,action='append',required=True)
    p.add_argument('--out',type=Path,required=True);args=p.parse_args()
    cases=[extract(path) for path in sorted(set(args.combat))];summary=summarize(cases)
    path=args.out.resolve()
    if not path.is_relative_to(ROOT):raise ValueError('OUTPUT_INSIDE_V2_REQUIRED')
    path.parent.mkdir(parents=True,exist_ok=True)
    with path.open('x',encoding='utf-8') as out:json.dump(dict(summary=summary,cases=cases),out,indent=2)
    print(json.dumps(summary))


if __name__=='__main__':main()
