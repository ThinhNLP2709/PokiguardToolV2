"""Optional B17 MatchPlayerSnapshotDTO fields from the same already-read response.

Fields follow reverse B17 (TypeDefIndex 631): cooldown, stack, phase, drop,
luck, fusion pity and level. A missing key is listed as absent (UNKNOWN), never
a client default. Meanings stay UNKNOWN until verified; no planner input.
"""
import json
from .combat_outcome_evidence import RESPONSE_TYPES, actor_identity, _integer, _text

SCHEMA = 'pokiguard.response_player_extras.v1'
MAX_PLAYERS = 16
MAX_BYTES = 4096
INTEGER_FIELDS = ('level', 'fusionLastAttemptTurn', 'fusionPityFails', 'fusionPityPercent',
    'skillCooldownCardId', 'skillCooldownLeft', 'skillStacks', 'skillStackMax', 'skillStackPct',
    'skillPhaseNext', 'skillPhaseMax', 'skillPhaseCardId', 'luckPct')
FIELDS = INTEGER_FIELDS + ('cardCooldownLeft', 'dotDropPct', 'luckyDotTag')


def encoded(value):
    return json.dumps(value, ensure_ascii=True, sort_keys=True, separators=(',', ':'), allow_nan=False)


def _value(name, value):
    if value is None: return None  # Explicit wire null, not a numeric default.
    if name in INTEGER_FIELDS and _integer(value): return value
    if name == 'luckyDotTag' and type(value) is str and len(value) <= 64 and all(ord(c) >= 32 for c in value):
        return value
    if name == 'dotDropPct' and type(value) is list and len(value) <= 16 and all(_integer(v) for v in value):
        return list(value)
    if (name == 'cardCooldownLeft' and type(value) is dict and len(value) <= 32
            and all(type(k) is str and 0 < len(k) <= 12 and k.lstrip('-').isdigit() and _integer(v)
                for k, v in value.items())):
        return {k: value[k] for k in sorted(value, key=int)}
    raise ValueError('PLAYER_EXTRA_FIELD_TYPE_OR_LIMIT')


def project_player_extras(envelope, *, expected_match_id, expected_sequence, raw_sha256):
    if (type(envelope) is not dict or envelope.get('matchId') != expected_match_id or not _text(expected_match_id)
            or envelope.get('type') not in RESPONSE_TYPES or type(envelope.get('matchPayload')) is not dict
            or type(raw_sha256) is not str or len(raw_sha256) != 64
            or any(c not in '0123456789abcdef' for c in raw_sha256) or not _integer(expected_sequence, 0, 10000000)):
        return None
    payload = envelope['matchPayload']
    if type(payload.get('srvSeq')) is not int or payload['srvSeq'] != expected_sequence: return None
    key = ('players' if payload.get('players') is not None else
           'playersStateDelta' if payload.get('playersStateDelta') is not None else None)
    if key is None: return None
    record = dict(schema=SCHEMA, status='CAPTURED', reason='RAW_B17_DTO_FIELDS_ABSENT_IS_UNKNOWN',
        match_id=expected_match_id, server_sequence=expected_sequence, event_type=envelope['type'],
        raw_sha256=raw_sha256, payload_key=key, players=[],
        scope='RESPONSE_SNAPSHOT_NOT_PRE_ACTION_OR_EFFECT_TIME', field_semantics='RAW_DTO_KEYS_NOT_INTERPRETED',
        input_authority=False, calibration_eligible=False)
    try:
        players = payload[key]
        if type(players) is not dict or len(players) > MAX_PLAYERS: raise ValueError('PLAYERS_SHAPE_OR_LIMIT')
        for name, player in players.items():
            if not _text(name) or type(player) is not dict: raise ValueError('PLAYER_KEY_OR_OBJECT')
            row = dict(actor_identity=actor_identity(name),
                fields={f: _value(f, player[f]) for f in FIELDS if f in player})
            absent = [f for f in FIELDS if f not in player]
            if absent: row['absent'] = absent
            record['players'].append(row)
        record['players'].sort(key=lambda p: p['actor_identity'])
        if len(encoded(record).encode()) > MAX_BYTES:
            record.update(status='OMITTED', reason='CONTEXT_BYTE_LIMIT', players=[])
    except (ValueError, TypeError, OverflowError, RecursionError) as exc:
        record.update(status='INVALID', reason=str(exc)[:96], players=[])
    return record
