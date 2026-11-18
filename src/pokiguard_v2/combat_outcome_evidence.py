"""Bounded evidence from JSON already read by the combat transport tap.

This module cannot read a process, grant an action, fit damage or predict a kill.
Wire steps are retained without guessing the meaning of arbitrary after keys.
"""
from dataclasses import dataclass
import hashlib
import json
from typing import Any


SCHEMA = 'pokiguard.combat_outcome_evidence.v1'
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

    def to_dict(self):
        return dict(schema=SCHEMA, status=self.status, reason=self.reason,
            evidence=None if self.payload_json is None else json.loads(self.payload_json),
            damage_prediction=False, input_authority=False)


def _text(value, maximum=256):
    return (type(value) is str and 0 < len(value) <= maximum
            and all(ord(c) >= 32 for c in value))


def _integer(value, minimum=-(2**31), maximum=2**31-1):
    return type(value) is int and minimum <= value <= maximum


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
    if type(operations) is not list or len(operations) > MAX_OPERATIONS:
        raise ValueError('OPERATION_SHAPE_OR_LIMIT')
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


def project_combat_outcome(envelope: Any, *, expected_match_id: str,
                           expected_sequence: int, raw_sha256: str,
                           board_attested: bool = True) -> CombatOutcomeCapture:
    """Fail closed for evidence only; malformed diagnostics never reject a board."""
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
        if (envelope.get('rejectReason') not in (None, '') or payload.get('rejected') is True
                or payload.get('success') is False or payload.get('accepted') is False):
            return CombatOutcomeCapture('REJECTED', 'SERVER_REJECTED_RESPONSE')
        for key in ('rejected', 'success', 'accepted'):
            if key in payload and type(payload[key]) is not bool:
                raise ValueError('RESPONSE_STATUS_TYPE')
        steps = payload.get('combatSteps')
        if steps is None:
            return CombatOutcomeCapture('UNAVAILABLE', 'COMBAT_STEPS_ABSENT')
        if type(steps) is not list or len(steps) > MAX_STEPS:
            raise ValueError('STEP_SHAPE_OR_LIMIT')
        if not steps:
            return CombatOutcomeCapture('UNAVAILABLE', 'EMPTY_COMBAT_STEPS_NOT_ZERO_DAMAGE')
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
        projected = dict(match_id=expected_match_id, server_sequence=sequence, event_type=event,
            wire_turn=turn, actor_identity=actor, raw_sha256=raw_sha256, steps=clean,
            wire_swap=swap, wire_swap_order='NATIVE_FROM_ROW_COL_TO_ROW_COL', card_ids=card_ids,
            swap_operations=_swap_operations(payload),
            swap_operation_source='matchPayload.ops[].data',
            swap_operation_decision_binding='UNKNOWN',
            index_contiguous=all(b == a+1 for a, b in zip(indices, indices[1:])),
            total_damage_display=total, destroyed_by_tag=_integer_map(payload.get('destroyedByTag'), nonnegative=True),
            accepted_board_attached=board_attested is True,
            provenance=('EXISTING_IMMUTABLE_JSON_AND_EXACT_ACCEPTED_BOARD_INSTANCE' if board_attested is True
                else 'EXISTING_IMMUTABLE_RESPONSE_WITHOUT_BOARD_ATTESTATION'),
            complete_server_effect_coverage='UNKNOWN', after_semantics='RAW_KEYS_NOT_INTERPRETED',
            prospective_damage_model=False, calibration_eligible=False)
        encoded = json.dumps(projected, ensure_ascii=True, sort_keys=True, separators=(',', ':'))
        if len(encoded.encode('utf-8')) > MAX_CAPTURE_BYTES:
            raise ValueError('CAPTURE_SIZE_LIMIT')
        return CombatOutcomeCapture('CAPTURED', 'RECORDED_SERVER_STEPS_NOT_A_DAMAGE_FORMULA', encoded)
    except (ValueError, TypeError, OverflowError, RecursionError) as exc:
        return CombatOutcomeCapture('INVALID', str(exc)[:96])


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
