"""Bounded evidence from JSON already read by the combat transport tap.

This module cannot read a process, grant an action, fit damage or predict a kill.
Wire steps are retained without guessing the meaning of arbitrary after keys.
"""
from dataclasses import dataclass, replace
import hashlib
import json
from typing import Any


SCHEMA = 'pokiguard.combat_outcome_evidence.v1'
RESPONSE_IDENTITY_SCHEMA = 'pokiguard.combat_response_identity.v1'
RESPONSE_TYPES = frozenset(('MATCH_MOVE_RES', 'MATCH_CARD_USE_RES', 'MATCH_SKILL_USE_RES'))
MAX_STEPS = 128
MAX_CAPTURE_BYTES = 32768
MAX_RETAINED_CAPTURES = 128
MAX_OPERATIONS = 128


@dataclass(frozen=True)
class CombatOutcomeCapture:
    status: str
    reason: str
    payload_json: str | None = None
    rejection_json: str | None = None
    response_identity_json: str | None = None
    player_context_json: str | None = None
    damage_operations_json: str | None = None
    board_operations_json: str | None = None
    player_extras_json: str | None = None

    def to_dict(self):
        record = dict(schema=SCHEMA, status=self.status, reason=self.reason,
            evidence=None if self.payload_json is None else json.loads(self.payload_json),
            damage_prediction=False, input_authority=False)
        if self.rejection_json is not None:
            record['rejection_diagnostics'] = json.loads(self.rejection_json)
        if self.response_identity_json is not None:
            record['response_identity'] = json.loads(self.response_identity_json)
        if self.player_context_json is not None:
            record['player_context'] = json.loads(self.player_context_json)
        if self.damage_operations_json is not None:
            record['damage_operations'] = json.loads(self.damage_operations_json)
        if self.board_operations_json is not None:
            record['board_operations'] = json.loads(self.board_operations_json)
        if self.player_extras_json is not None:
            record['player_extras'] = json.loads(self.player_extras_json)
        return record


class _OperationProjectionError(ValueError):
    """Bounded shape metadata only; never persist the rejected operations."""
    def __init__(self, reason, operations):
        super().__init__(reason)
        container = {list: 'LIST', dict: 'OBJECT', str: 'STRING', int: 'INTEGER',
            float: 'NUMBER', bool: 'BOOLEAN', type(None): 'NULL'}.get(type(operations), 'OTHER')
        self.rejection_json = json.dumps(dict(operation_container=container,
            operation_count=len(operations) if type(operations) in (list, dict, str) else None,
            operation_limit=MAX_OPERATIONS), separators=(',', ':'))


def _text(value, maximum=256):
    return (type(value) is str and 0 < len(value) <= maximum
            and all(ord(c) >= 32 for c in value))


def _integer(value, minimum=-(2**31), maximum=2**31-1):
    return type(value) is int and minimum <= value <= maximum


def _response_identity(match_id, event, sequence, raw_sha256):
    """Called after the envelope match/sequence fence; no effect attestation."""
    if (not _text(match_id) or event not in RESPONSE_TYPES
            or not _integer(sequence, 0, 10000000)
            or not _text(raw_sha256, 64) or len(raw_sha256) != 64
            or any(c not in '0123456789abcdef' for c in raw_sha256)):
        return None
    return json.dumps(dict(schema=RESPONSE_IDENTITY_SCHEMA, match_id=match_id,
        event_type=event, server_sequence=sequence, raw_sha256=raw_sha256,
        source='EXISTING_IMMUTABLE_JSON_VALIDATED_MATCH_SEQUENCE',
        effect_evidence=False, input_authority=False), separators=(',', ':'))


def actor_identity(value):
    """Preserve exact actor equality without persisting player names."""
    if not _text(value):
        raise ValueError('ACTOR_IDENTITY_MISSING_OR_INVALID')
    return 'BOSS' if value == '__BOSS__' else 'sha256:' + hashlib.sha256(value.encode('utf-8')).hexdigest()


def _integer_map(value, *, nonnegative=False):
    if value is None:
        return None
    if type(value) is not dict or len(value) > 32:
        raise ValueError('MAP_SHAPE_OR_LIMIT')
    if any(not _text(k, 64) or not _integer(v, 0 if nonnegative else -(2**31)) for k, v in value.items()):
        raise ValueError('MAP_FIELD_TYPE')
    return dict(value)


def _swap_operations(payload):
    """B16 ParseOps/ApplySwap path; raw operations are never action authority.

    Preserve every SWAP with its operation index, rather than selecting one
    as the actor's decision. Missing keys are unknown, never the client's
    numeric fallback of zero. This projection adds no process reads.
    """
    if 'ops' not in payload or payload['ops'] is None:
        return None
    operations = payload['ops']
    if type(operations) is not list:
        raise _OperationProjectionError('OPERATION_SHAPE', operations)
    if len(operations) > MAX_OPERATIONS:
        raise _OperationProjectionError('OPERATION_LIMIT', operations)
    swaps = []
    for index, operation in enumerate(operations):
        if type(operation) is not dict or not _text(operation.get('type'), 64):
            raise ValueError('OPERATION_TYPE')
        if operation['type'] != 'SWAP':
            continue
        data = operation.get('data')
        if type(data) is not dict:
            raise ValueError('SWAP_OPERATION_DATA')
        coordinates = [data.get(k) for k in ('fromRow', 'fromCol', 'toRow', 'toCol')]
        if (not all(_integer(v, 0, 7) for v in coordinates)
                or abs(coordinates[0]-coordinates[2])+abs(coordinates[1]-coordinates[3]) != 1):
            raise ValueError('SWAP_OPERATION_COORDINATES')
        swaps.append(dict(operation_index=index, type='SWAP', native_swap=coordinates))
    return swaps


def _resource_operations(payload):
    """B17 verified STAT_CHANGE and DESTROY inputs, ordered evidence only.

    The game defaults absent integer inputs to zero; diagnostics must preserve
    absence as unknown. DESTROY supplies native [col,row] positions, not tags,
    multipliers, a Sword count or the complete refill trajectory.
    """
    operations=payload.get('ops')
    if operations is None:return None
    # _swap_operations already validates the shared list/type/operation bound.
    result=[]
    for index,operation in enumerate(operations):
        kind=operation['type']
        if kind not in ('STAT_CHANGE','DESTROY'):continue
        data=operation.get('data')
        if type(data) is not dict:raise ValueError('RESOURCE_OPERATION_DATA')
        if kind=='STAT_CHANGE':
            target=data.get('targetUsername');stat=data.get('statType')
            if target is not None and not _text(target):raise ValueError('STAT_TARGET_TYPE')
            if stat is not None and not _text(stat,64):raise ValueError('STAT_TYPE')
            delta,value=data.get('delta'),data.get('newValue')
            if any(v is not None and not _integer(v) for v in (delta,value)):
                raise ValueError('STAT_INTEGER_TYPE')
            reason,source=data.get('reason'),data.get('source')
            if any(v is not None and not _text(v,64) for v in (reason,source)):
                raise ValueError('STAT_REASON_TYPE')
            result.append(dict(operation_index=index,type=kind,
                target=None if target is None else actor_identity(target),stat_type=stat,
                delta=delta,new_value=value,reason=reason,source_label=source))
        else:
            positions=data.get('positions')
            known=(type(positions) is list and len(positions)<=64
                and all(type(p) is list and len(p)>=2 and all(_integer(v,0,7) for v in p[:2]) for p in positions))
            # The verified client consumes only indexes 0/1. Do not assign
            # semantics to trailing values, or discard valid combat/stat
            # evidence because this optional coordinate projection is unknown.
            shape=None if positions is None else dict(container=type(positions).__name__,
                count=len(positions) if type(positions) in (list,dict,str) else None,
                first_item=type(positions[0]).__name__ if type(positions) is list and positions else None,
                first_arity=len(positions[0]) if type(positions) is list and positions and type(positions[0]) is list else None)
            result.append(dict(operation_index=index,type=kind,
                native_positions=[list(p[:2]) for p in positions] if known else None,
                positions_status='READ_NATIVE_FIRST_TWO' if known else 'UNKNOWN_ABSENT' if positions is None else 'UNVERIFIED_FORMAT',
                position_shape=shape,unmodeled_trailing_values=any(len(p)>2 for p in positions) if known else None,
                position_order='COL_ROW',tag_multiplier_binding='UNKNOWN'))
    return result


def _project_combat_effects(envelope: Any, *, expected_match_id: str,
                           expected_sequence: int, raw_sha256: str,
                           board_attested: bool = True) -> CombatOutcomeCapture:
    """Fail closed for evidence only; malformed diagnostics never reject a board."""
    response_identity = None
    try:
        if type(envelope) is not dict or envelope.get('matchId') != expected_match_id or not expected_match_id:
            raise ValueError('MATCH_ID_MISMATCH')
        event = envelope.get('type')
        if event not in RESPONSE_TYPES:
            return CombatOutcomeCapture('NOT_APPLICABLE', 'NOT_COMBAT_RESPONSE')
        payload = envelope.get('matchPayload')
        if type(payload) is not dict:
            raise ValueError('PAYLOAD_SHAPE')
        sequence = payload.get('srvSeq')
        if (not _integer(sequence, 0, 10000000) or type(expected_sequence) is not int
                or sequence != expected_sequence):
            raise ValueError('SEQUENCE_MISMATCH')
        response_identity = _response_identity(expected_match_id, event, sequence, raw_sha256)
        if (envelope.get('rejectReason') not in (None, '') or payload.get('rejected') is True
                or payload.get('success') is False or payload.get('accepted') is False):
            return CombatOutcomeCapture('REJECTED', 'SERVER_REJECTED_RESPONSE',
                response_identity_json=response_identity)
        for key in ('rejected', 'success', 'accepted'):
            if key in payload and type(payload[key]) is not bool:
                raise ValueError('RESPONSE_STATUS_TYPE')
        steps = payload.get('combatSteps')
        if steps is None:
            return CombatOutcomeCapture('UNAVAILABLE', 'COMBAT_STEPS_ABSENT',
                response_identity_json=response_identity)
        if type(steps) is not list or len(steps) > MAX_STEPS:
            raise ValueError('STEP_SHAPE_OR_LIMIT')
        if not steps:
            return CombatOutcomeCapture('UNAVAILABLE', 'EMPTY_COMBAT_STEPS_NOT_ZERO_DAMAGE',
                response_identity_json=response_identity)
        if (not _text(raw_sha256, 64) or len(raw_sha256) != 64
                or any(c not in '0123456789abcdef' for c in raw_sha256)):
            raise ValueError('RAW_IDENTITY_INVALID')
        actor = actor_identity(payload.get('actorUsername'))
        clean = []
        indices = []
        for step in steps:
            if type(step) is not dict:
                raise ValueError('STEP_NOT_OBJECT')
            kind, amount, idx = step.get('kind'), step.get('amount'), step.get('idx')
            if not _text(kind, 32) or not _integer(amount) or not _integer(idx, 0):
                raise ValueError('STEP_FIELD_TYPE')
            if indices and idx <= indices[-1]:
                raise ValueError('STEP_INDEX_DUPLICATE_OR_REORDERED')
            indices.append(idx)
            damage_source = step.get('dmgSrc')
            if damage_source is not None and not _text(damage_source, 64):
                raise ValueError('DAMAGE_SOURCE_TYPE')
            full_power = step.get('fullPower')
            if full_power is not None and type(full_power) is not bool:
                raise ValueError('FULL_POWER_TYPE')
            steal_type = step.get('stealType')
            if steal_type is not None and not _text(steal_type, 64):
                raise ValueError('STEAL_TYPE')
            clean.append(dict(idx=idx, kind=kind, amount=amount,
                source=actor_identity(step.get('source')), target=actor_identity(step.get('target')),
                damage_source=damage_source, full_power=full_power, steal_type=steal_type,
                after=_integer_map(step.get('after'))))
        total = payload.get('totalDamageDisplay')
        if total is not None and not _integer(total, 0):
            raise ValueError('DISPLAY_TOTAL_TYPE')
        turn = payload.get('turnNumber')
        # The wire turn can describe the next actor: never relabel it as our source turn.
        turn = turn if _integer(turn, 1) else None
        card_ids = {}
        for key in ('cardId', 'skillCardId'):
            value = envelope.get(key)
            if value is not None and not _integer(value, 0):
                raise ValueError('CARD_ID_TYPE')
            card_ids[key] = value
        coordinates = tuple(envelope.get(k) for k in ('fromRow', 'fromCol', 'toRow', 'toCol'))
        swap = (list(coordinates) if all(_integer(v, 0, 7) for v in coordinates)
                and abs(coordinates[0]-coordinates[2])+abs(coordinates[1]-coordinates[3]) == 1 else None)
        operation_projection = None
        try:
            swap_operations = _swap_operations(payload)
            resource_operations = _resource_operations(payload)
        except _OperationProjectionError as exc:
            if str(exc) != 'OPERATION_LIMIT':
                raise
            # Operations and combatSteps are independent wire projections.
            # A long optional list must not discard valid typed combatSteps.
            # Do not scan a prefix or claim that uninspected operations are
            # complete/valid. Keep the old scan, index and byte limits.
            swap_operations = resource_operations = None
            operation_projection = dict(status='OMITTED', reason='OPERATION_LIMIT',
                operation_count=len(payload['ops']), operation_limit=MAX_OPERATIONS,
                complete=False)
        projected = dict(match_id=expected_match_id, server_sequence=sequence, event_type=event,
            wire_turn=turn, actor_identity=actor, raw_sha256=raw_sha256, steps=clean,
            wire_swap=swap, wire_swap_order='NATIVE_FROM_ROW_COL_TO_ROW_COL', card_ids=card_ids,
            swap_operations=swap_operations,
            swap_operation_source='matchPayload.ops[].data',
            swap_operation_decision_binding='UNKNOWN',
            resource_operations=resource_operations,
            resource_operation_source='matchPayload.ops[].data',
            resource_operation_semantics='RAW_ORDERED_OBSERVATION_NOT_A_PREDICTION',
            index_contiguous=all(b == a+1 for a, b in zip(indices, indices[1:])),
            total_damage_display=total, destroyed_by_tag=_integer_map(payload.get('destroyedByTag'), nonnegative=True),
            accepted_board_attached=board_attested is True,
            provenance=('EXISTING_IMMUTABLE_JSON_AND_EXACT_ACCEPTED_BOARD_INSTANCE' if board_attested is True
                else 'EXISTING_IMMUTABLE_RESPONSE_WITHOUT_BOARD_ATTESTATION'),
            complete_server_effect_coverage='UNKNOWN', after_semantics='RAW_KEYS_NOT_INTERPRETED',
            prospective_damage_model=False, calibration_eligible=False)
        if operation_projection is not None:
            projected['operation_projection'] = operation_projection
        encoded = json.dumps(projected, ensure_ascii=True, sort_keys=True, separators=(',', ':'))
        if len(encoded.encode('utf-8')) > MAX_CAPTURE_BYTES:
            raise ValueError('CAPTURE_SIZE_LIMIT')
        # Preserve wire absence separately from JSON null and false. This is
        # optional metadata: it must not evict valid legacy effect evidence
        # when that evidence already fills the existing byte budget.
        with_presence = dict(projected, steps=[dict(clean_step,
            full_power_presence=('ABSENT' if 'fullPower' not in raw_step else
                'NULL' if raw_step['fullPower'] is None else 'VALUE'))
            for clean_step, raw_step in zip(clean, steps)])
        presence_encoded = json.dumps(with_presence, ensure_ascii=True, sort_keys=True, separators=(',', ':'))
        if len(presence_encoded.encode('utf-8')) <= MAX_CAPTURE_BYTES:
            encoded = presence_encoded
        return CombatOutcomeCapture('CAPTURED', 'RECORDED_SERVER_STEPS_NOT_A_DAMAGE_FORMULA', encoded)
    except (ValueError, TypeError, OverflowError, RecursionError) as exc:
        return CombatOutcomeCapture('INVALID', str(exc)[:96], rejection_json=(
            exc.rejection_json if isinstance(exc, _OperationProjectionError) else None),
            response_identity_json=response_identity)


def _project_outcome_with_players(envelope: Any, *, expected_match_id: str,
                           expected_sequence: int, raw_sha256: str,
                           board_attested: bool = True) -> CombatOutcomeCapture:
    """Optional context cannot invalidate or evict existing effect evidence."""
    capture = _project_combat_effects(envelope, expected_match_id=expected_match_id,
        expected_sequence=expected_sequence, raw_sha256=raw_sha256, board_attested=board_attested)
    if capture.status not in ('CAPTURED', 'UNAVAILABLE'):
        return capture
    try:
        from .combat_player_context import encoded, project_player_context
        context = project_player_context(envelope, expected_match_id=expected_match_id,
            expected_sequence=expected_sequence, raw_sha256=raw_sha256)
        if context is None: return capture
        raw = encoded(context)
        size = len((capture.payload_json or '').encode('utf-8')) + len(raw.encode('utf-8'))
        if size > MAX_CAPTURE_BYTES:
            context.update(status='OMITTED', reason='COMBINED_CAPTURE_BYTE_LIMIT', players=[])
            raw = encoded(context)
            if len((capture.payload_json or '').encode('utf-8')) + len(raw.encode('utf-8')) > MAX_CAPTURE_BYTES:
                return capture
        return replace(capture, player_context_json=raw)
    except Exception as exc:
        # Bounded diagnostic error only, never arbitrary exception text or a
        # changed effect/board disposition. Absence still means UNKNOWN.
        reason = 'CONTEXT_' + type(exc).__name__[:64]
        rejection = json.dumps(dict(player_context_error=reason), separators=(',', ':'))
        if len((capture.payload_json or '').encode('utf-8')) + len(rejection.encode()) <= MAX_CAPTURE_BYTES:
            return replace(capture, rejection_json=rejection)
        return capture


def _project_with_damage(envelope: Any, *, expected_match_id: str,
                         expected_sequence: int, raw_sha256: str,
                         board_attested: bool = True) -> CombatOutcomeCapture:
    """Optional crit/HP-op metadata never evicts old effects or player context."""
    capture = _project_outcome_with_players(envelope, expected_match_id=expected_match_id,
        expected_sequence=expected_sequence, raw_sha256=raw_sha256, board_attested=board_attested)
    if capture.status not in ('CAPTURED', 'UNAVAILABLE'): return capture
    try:
        from .damage_operation_context import project_damage_operations, encoded
        context = project_damage_operations(envelope, expected_match_id=expected_match_id,
            expected_sequence=expected_sequence, raw_sha256=raw_sha256)
        if context is None: return capture
        raw = encoded(context)
        prior_size = len((capture.payload_json or '').encode()) + len((capture.player_context_json or '').encode())
        if prior_size + len(raw.encode()) > MAX_CAPTURE_BYTES:
            context.update(status='OMITTED',reason='COMBINED_CAPTURE_BYTE_LIMIT',operations=[])
            raw = encoded(context)
            if prior_size + len(raw.encode()) > MAX_CAPTURE_BYTES: return capture
        return replace(capture, damage_operations_json=raw)
    except Exception as exc:
        # Diagnostic-only failure, no altered board/effect status or input.
        if capture.payload_json is not None or capture.response_identity_json is not None:
            record=dict(schema='pokiguard.damage_operation_context.v1',status='INVALID',
                reason='OPTIONAL_PROJECTION_'+type(exc).__name__[:48],match_id=expected_match_id,
                server_sequence=expected_sequence,event_type=envelope.get('type'),raw_sha256=raw_sha256,
                response_actor_identity=None,
                operations=[],scope='SAME_RESPONSE_POST_OPERATION_EVIDENCE_NOT_PRE_INPUT',
                step_attribution='UNKNOWN',calibration_eligible=False,input_authority=False)
            raw=json.dumps(record,sort_keys=True,separators=(',',':'))
            size=len((capture.payload_json or '').encode())+len((capture.player_context_json or '').encode())
            if size+len(raw.encode())<=MAX_CAPTURE_BYTES:
                return replace(capture,damage_operations_json=raw)
        return capture


def _attached_bytes(capture):
    return sum(len((v or '').encode()) for v in (capture.payload_json, capture.player_context_json,
        capture.damage_operations_json, capture.board_operations_json, capture.player_extras_json))


def project_combat_outcome(envelope: Any, *, expected_match_id: str,
                           expected_sequence: int, raw_sha256: str,
                           board_attested: bool = True) -> CombatOutcomeCapture:
    """U2 board/player extras are last and optional: never evict prior evidence."""
    capture = _project_with_damage(envelope, expected_match_id=expected_match_id,
        expected_sequence=expected_sequence, raw_sha256=raw_sha256, board_attested=board_attested)
    if capture.status not in ('CAPTURED', 'UNAVAILABLE'): return capture
    from .board_operation_context import project_board_operations
    from .response_player_extras import project_player_extras
    for field, key, project in (('board_operations_json', 'operations', project_board_operations),
                                ('player_extras_json', 'players', project_player_extras)):
        try:
            context = project(envelope, expected_match_id=expected_match_id,
                expected_sequence=expected_sequence, raw_sha256=raw_sha256)
            if context is None: continue
            raw = json.dumps(context, sort_keys=True, ensure_ascii=True, separators=(',', ':'), allow_nan=False)
            if _attached_bytes(capture) + len(raw.encode()) > MAX_CAPTURE_BYTES:
                context.update(status='OMITTED', reason='COMBINED_CAPTURE_BYTE_LIMIT', **{key: []})
                raw = json.dumps(context, sort_keys=True, ensure_ascii=True, separators=(',', ':'), allow_nan=False)
                if _attached_bytes(capture) + len(raw.encode()) > MAX_CAPTURE_BYTES: continue
            capture = replace(capture, **{field: raw})
        except Exception:
            continue  # Diagnostic-only: evidence is lost, board/effect status and input are unchanged.
    return capture


def observed_effect_totals(record):
    """Group recorded amounts; never turn HP deltas into attributed damage."""
    if type(record) is not dict or record.get('schema') != SCHEMA or record.get('status') != 'CAPTURED':
        return ()
    evidence = record.get('evidence')
    if type(evidence) is not dict or type(evidence.get('steps')) is not list:
        return ()
    steps = evidence['steps']
    if not 0 < len(steps) <= MAX_STEPS:
        return ()
    totals = {}
    for step in steps:
        if (type(step) is not dict or not _text(step.get('kind'), 32)
                or not _integer(step.get('amount')) or not _text(step.get('source'))
                or not _text(step.get('target'))):
            return ()
        damage_source, full_power = step.get('damage_source'), step.get('full_power')
        steal_type = step.get('steal_type')
        if ((damage_source is not None and not _text(damage_source, 64))
                or (full_power is not None and type(full_power) is not bool)
                or (steal_type is not None and not _text(steal_type, 64))):
            return ()
        key = (step['kind'], step['source'], step['target'], damage_source, full_power, steal_type)
        totals[key] = totals.get(key, 0) + step['amount']
    return tuple(dict(kind=k[0], source=k[1], target=k[2], damage_source=k[3],
        full_power=k[4], steal_type=k[5], observed_amount=value) for k, value in totals.items())


def export_outcome_safely(tap, snapshot):
    """Optional log fields cannot interrupt the existing controller path."""
    try:
        project = getattr(tap, 'combat_outcome_fields', None)
        fields = project(snapshot) if callable(project) else None
        return fields if type(fields) is dict and set(fields) == {'combatOutcome'} else {}
    except Exception as exc:
        return dict(combatOutcome=CombatOutcomeCapture('INVALID', 'EXPORT_' + type(exc).__name__).to_dict())


def drain_outcomes_safely(tap, match_id):
    """At most two boardless response records per existing controller checkpoint."""
    try:
        drain = getattr(tap, 'drain_combat_outcomes', None)
        records = drain(match_id) if callable(drain) else ()
        if type(records) is not tuple or len(records) > 2 or any(type(r) is not dict for r in records):
            return ()
        return records
    except Exception as exc:
        return (CombatOutcomeCapture('INVALID', 'DRAIN_' + type(exc).__name__).to_dict(),)
