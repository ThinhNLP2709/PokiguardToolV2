"""Optional server-ordered board operations from the same already-read response.

SWAP/DESTROY/FALL/SPAWN are post-response observations in wire order, never a
refill forecast, planner input or action authority. Absent keys stay absent;
the client defaults (col/row 0, multiplier 1) are not replayed. No process I/O.
"""
import json
from .combat_outcome_evidence import RESPONSE_TYPES, MAX_OPERATIONS, _integer, _text, actor_identity

SCHEMA = 'pokiguard.board_operation_context.v1'
MAX_BYTES = 16384
KEYS = dict(SWAP=('fromRow', 'fromCol', 'toRow', 'toCol'), FALL=('col', 'fromRow', 'toRow'),
    SPAWN=('col', 'row', 'multiplier'), DESTROY=())


def encoded(value):
    return json.dumps(value, sort_keys=True, ensure_ascii=True, separators=(',', ':'), allow_nan=False)


def project_board_operations(envelope, *, expected_match_id, expected_sequence, raw_sha256):
    if (type(envelope) is not dict or envelope.get('matchId') != expected_match_id or not _text(expected_match_id)
            or envelope.get('type') not in RESPONSE_TYPES or not _integer(expected_sequence, 0, 10000000)
            or type(envelope.get('matchPayload')) is not dict or type(raw_sha256) is not str
            or len(raw_sha256) != 64 or any(c not in '0123456789abcdef' for c in raw_sha256)):
        return None
    payload = envelope['matchPayload']
    if type(payload.get('srvSeq')) is not int or payload['srvSeq'] != expected_sequence: return None
    ops = payload.get('ops')
    if ops is None: return None
    record = dict(schema=SCHEMA, status='CAPTURED', reason='SERVER_ORDERED_OPERATIONS_NOT_A_FORECAST',
        match_id=expected_match_id, server_sequence=expected_sequence, event_type=envelope['type'],
        raw_sha256=raw_sha256, operations=[], coordinate_order='NATIVE_COL_ROW',
        response_actor_identity=actor_identity(payload['actorUsername']) if _text(payload.get('actorUsername')) else None,
        source='matchPayload.ops[].data', scope='SAME_RESPONSE_POST_INPUT_EVIDENCE_NOT_PRE_INPUT',
        tag_semantics='RAW_PREFAB_TAG_NOT_GEM_MAPPING', calibration_eligible=False, input_authority=False)
    try:
        if type(ops) is not list: raise ValueError('OPERATION_SHAPE')
        if len(ops) > MAX_OPERATIONS:
            record.update(status='OMITTED', reason='OPERATION_SCAN_LIMIT', operation_count=len(ops),
                operation_limit=MAX_OPERATIONS)
            return record
        for index, op in enumerate(ops):
            if type(op) is not dict: raise ValueError('OPERATION_OBJECT')
            kind = op.get('type')
            if kind not in KEYS: continue
            data = op.get('data')
            if type(data) is not dict: raise ValueError('OPERATION_DATA')
            row = dict(operation_index=index, type=kind)
            for key in KEYS[kind]:
                if key not in data: continue
                value = data[key]
                if value is not None and not _integer(value, 0, 64 if key == 'multiplier' else 7):
                    raise ValueError('OPERATION_INTEGER')
                row[key] = value
            if kind == 'SPAWN' and 'tag' in data:
                if data['tag'] is not None and not _text(data['tag'], 64): raise ValueError('SPAWN_TAG')
                row['tag'] = data['tag']
            if kind == 'DESTROY':
                positions = data.get('positions')
                if (type(positions) is list and len(positions) <= 64 and all(type(p) is list and len(p) >= 2
                        and all(_integer(v, 0, 7) for v in p[:2]) for p in positions)):
                    row.update(positions=[list(p[:2]) for p in positions], positions_status='READ_NATIVE_FIRST_TWO')
                else:
                    row['positions_status'] = 'UNKNOWN_ABSENT' if positions is None else 'UNVERIFIED_FORMAT'
            record['operations'].append(row)
        if not record['operations']: return None
        if len(encoded(record).encode()) > MAX_BYTES:
            record.update(status='OMITTED', reason='OPERATION_CONTEXT_BYTE_LIMIT', operations=[])
    except (ValueError, TypeError, OverflowError, RecursionError) as exc:
        record.update(status='INVALID', reason=str(exc)[:96], operations=[])
    return record
