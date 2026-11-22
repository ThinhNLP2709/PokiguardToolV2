"""Optional B17 operation evidence from the same already-read response JSON.

Crit is an after-response wire observation, never an input feature, forecast,
damage formula, client-default false or a link to a particular combat step.
"""
import json
from .combat_outcome_evidence import RESPONSE_TYPES,MAX_OPERATIONS,_integer,_text,actor_identity

SCHEMA='pokiguard.damage_operation_context.v1'
MAX_BYTES=4096
MAX_RECORDS=32


def encoded(value):return json.dumps(value,sort_keys=True,ensure_ascii=True,separators=(',',':'),allow_nan=False)


def project_damage_operations(envelope,*,expected_match_id,expected_sequence,raw_sha256):
    if (type(envelope) is not dict or envelope.get('matchId')!=expected_match_id or not _text(expected_match_id)
            or envelope.get('type') not in RESPONSE_TYPES or not _integer(expected_sequence,0,10000000)
            or type(envelope.get('matchPayload')) is not dict or type(raw_sha256) is not str
            or len(raw_sha256)!=64 or any(c not in '0123456789abcdef' for c in raw_sha256)):
        return None
    payload=envelope['matchPayload']
    if type(payload.get('srvSeq')) is not int or payload['srvSeq']!=expected_sequence:return None
    ops=payload.get('ops')
    if ops is None:return None
    record=dict(schema=SCHEMA,status='CAPTURED',reason='RAW_OPERATIONS_NOT_STEP_ATTRIBUTION',
        match_id=expected_match_id,server_sequence=expected_sequence,event_type=envelope['type'],raw_sha256=raw_sha256,
        response_actor_identity=actor_identity(payload['actorUsername']) if _text(payload.get('actorUsername')) else None,
        operations=[],scope='SAME_RESPONSE_POST_OPERATION_EVIDENCE_NOT_PRE_INPUT',
        step_attribution='UNKNOWN',calibration_eligible=False,input_authority=False)
    try:
        if type(ops) is not list:raise ValueError('OPERATION_SHAPE_OR_LIMIT')
        if len(ops)>MAX_OPERATIONS:
            record.update(status='OMITTED',reason='OPERATION_SCAN_LIMIT',
                operation_count=len(ops),operation_limit=MAX_OPERATIONS)
            return record
        for index,op in enumerate(ops):
            if type(op) is not dict:raise ValueError('OPERATION_OBJECT')
            kind=op.get('type')
            if kind not in ('STAT_CHANGE','BOSS_HP'):continue
            data=op.get('data')
            if type(data) is not dict:raise ValueError('OPERATION_DATA')
            fields={}
            integers=('delta','newHP') if kind=='BOSS_HP' else ('delta','newValue')
            texts=() if kind=='BOSS_HP' else ('statType','reason','source')
            for key in integers:
                if key in data:
                    if data[key] is not None and not _integer(data[key]):raise ValueError('OPERATION_INTEGER')
                    fields[key]=data[key]
            for key in texts:
                if key in data:
                    if data[key] is not None and not _text(data[key],64):raise ValueError('OPERATION_TEXT')
                    fields[key]=data[key]
            if kind=='STAT_CHANGE' and 'targetUsername' in data:
                fields['target_identity']=None if data['targetUsername'] is None else actor_identity(data['targetUsername'])
            crit=data.get('crit')
            presence=('ABSENT' if 'crit' not in data else 'NULL' if crit is None else 'BOOL' if type(crit) is bool else 'UNVERIFIED_TYPE')
            row=dict(operation_index=index,type=kind,fields=fields,crit_presence=presence,
                crit_value=crit if type(crit) is bool else None)
            if presence=='UNVERIFIED_TYPE':row['crit_raw_type']=type(crit).__name__[:24]
            record['operations'].append(row)
            if len(record['operations'])>MAX_RECORDS:
                record.update(status='OMITTED',reason='OPERATION_RECORD_LIMIT',operations=[]);return record
        if not record['operations']:return None
        if len(encoded(record).encode())>MAX_BYTES:
            record.update(status='OMITTED',reason='OPERATION_CONTEXT_BYTE_LIMIT',operations=[])
    except (ValueError,TypeError,OverflowError,RecursionError) as exc:
        record.update(status='INVALID',reason=str(exc)[:96],operations=[])
    return record
