"""Bounded fields from the same immutable response, never a carried game state.

B17 ParsePlayersSnapshot prefers non-null players, then playersStateDelta.
Missing fields remain absent. The client merge/default rules are not replayed.
"""
import json
import math

from .combat_outcome_evidence import RESPONSE_TYPES, actor_identity, _integer, _text

SCHEMA = 'pokiguard.response_player_context.v1'
SCOPE = 'RESPONSE_SNAPSHOT_NOT_PRE_ACTION_OR_EFFECT_TIME'
MAX_PLAYERS = 16
MAX_CONTEXT_BYTES = 4096
INTEGER_FIELDS = frozenset(('actorNumber', 'hp', 'hpMax', 'mana', 'manaMax',
    'power', 'powerMax', 'attack', 'shield', 'petId', 'petLevel', 'petStar',
    'petBtLevel', 'petBtMax', 'avatarId', 'fusionBonusHp', 'fusionBonusAttack',
    'fusionBonusMana', 'weaponImageId'))
TEXT_FIELDS = frozenset(('petElementType', 'weaponRarity'))
FIELDS = INTEGER_FIELDS | TEXT_FIELDS | {'weaknessVsBoss', 'equipCounterPct', 'fusionUsedSuccess'}
KEYS = frozenset(('schema', 'status', 'reason', 'match_id', 'server_sequence',
    'event_type', 'raw_sha256', 'payload_key', 'client_mode', 'players', 'scope',
    'field_semantics', 'input_authority', 'calibration_eligible'))


def encoded(value):
    return json.dumps(value, ensure_ascii=True, sort_keys=True, separators=(',', ':'), allow_nan=False)


def valid_hash(value):
    return _text(value, 64) and len(value) == 64 and all(c in '0123456789abcdef' for c in value)


def valid_actor(value):
    return value == 'BOSS' or type(value) is str and value.startswith('sha256:') and valid_hash(value[7:])


def field_value(name, value):
    if value is None: return None  # Explicit wire null; not a numeric default.
    if name in INTEGER_FIELDS and _integer(value): return value
    if (name in TEXT_FIELDS and type(value) is str and len(value) <= 64
            and all(ord(c) >= 32 for c in value)): return value
    if name == 'fusionUsedSuccess' and type(value) is bool: return value
    if name == 'weaknessVsBoss' and type(value) in (int, float) and math.isfinite(value): return value
    if (name == 'equipCounterPct' and type(value) is list and len(value) <= 16
            and all(_integer(v) for v in value)): return list(value)
    raise ValueError('PLAYER_FIELD_TYPE_OR_LIMIT')


def project_player_context(envelope, *, expected_match_id, expected_sequence, raw_sha256):
    """No parsing/IO outside the existing JSON; wrong identities yield no record."""
    if (type(envelope) is not dict or envelope.get('matchId') != expected_match_id
            or not _text(expected_match_id) or envelope.get('type') not in RESPONSE_TYPES
            or type(envelope.get('matchPayload')) is not dict or not valid_hash(raw_sha256)
            or not _integer(expected_sequence, 0, 10000000)):
        return None
    payload = envelope['matchPayload']
    if type(payload.get('srvSeq')) is not int or payload['srvSeq'] != expected_sequence: return None
    key = ('players' if payload.get('players') is not None else
           'playersStateDelta' if payload.get('playersStateDelta') is not None else None)
    if key is None: return None
    record = dict(schema=SCHEMA, status='CAPTURED', reason='RAW_FIELDS_NO_CARRY_FORWARD',
        match_id=expected_match_id, server_sequence=expected_sequence, event_type=envelope['type'],
        raw_sha256=raw_sha256, payload_key=key,
        client_mode='REPLACE_DICTIONARY' if key == 'players' else 'MERGE_PLAYER_DELTA',
        players=[], scope=SCOPE, field_semantics='RAW_DTO_KEYS_NOT_A_DAMAGE_FORMULA',
        input_authority=False, calibration_eligible=False)
    try:
        players = payload[key]
        if type(players) is not dict or len(players) > MAX_PLAYERS:
            raise ValueError('PLAYERS_SHAPE_OR_LIMIT')
        for name, player in players.items():
            if not _text(name) or type(player) is not dict:
                raise ValueError('PLAYER_KEY_OR_OBJECT')
            username = player.get('username')
            if username not in (None, '') and username != name:
                raise ValueError('PLAYER_KEY_USERNAME_CONFLICT')
            fields = {field: field_value(field, player[field]) for field in sorted(FIELDS) if field in player}
            record['players'].append(dict(actor_identity=actor_identity(name), fields=fields))
        record['players'].sort(key=lambda p: p['actor_identity'])
        if not players: record['reason'] = 'EMPTY_MAPPING_NOT_ZERO_PARTICIPANTS'
        if len(encoded(record).encode()) > MAX_CONTEXT_BYTES:
            record.update(status='OMITTED', reason='CONTEXT_BYTE_LIMIT', players=[])
    except (ValueError, TypeError, OverflowError, RecursionError) as exc:
        # Discard only context; preserve the independently validated effects.
        record.update(status='INVALID', reason=str(exc)[:96], players=[])
    return record


def validate_player_context(record, *, match_id, server_sequence, event_type, raw_sha256):
    """File-only validation. No record is upgraded into pre-action evidence."""
    if type(record) is not dict or set(record) != KEYS:
        raise ValueError('CONTEXT_SHAPE')
    if (record['schema'] != SCHEMA or record['scope'] != SCOPE
            or record['field_semantics'] != 'RAW_DTO_KEYS_NOT_A_DAMAGE_FORMULA'
            or record['input_authority'] is not False or record['calibration_eligible'] is not False
            or record['event_type'] not in RESPONSE_TYPES or not valid_hash(record['raw_sha256'])
            or not _text(record['match_id']) or not _integer(record['server_sequence'], 0, 10000000)
            or type(server_sequence) is not int
            or (record['match_id'], record['server_sequence'], record['event_type'], record['raw_sha256'])
                != (match_id, server_sequence, event_type, raw_sha256)):
        raise ValueError('CONTEXT_IDENTITY_OR_SCOPE')
    if (record['payload_key'] not in ('players', 'playersStateDelta')
            or record['client_mode'] != ('REPLACE_DICTIONARY' if record['payload_key'] == 'players' else 'MERGE_PLAYER_DELTA')
            or record['status'] not in ('CAPTURED', 'INVALID', 'OMITTED') or not _text(record['reason'], 96)
            or type(record['players']) is not list or len(record['players']) > MAX_PLAYERS
            or record['status'] != 'CAPTURED' and record['players']
            or len(encoded(record).encode()) > MAX_CONTEXT_BYTES):
        raise ValueError('CONTEXT_STATUS_OR_LIMIT')
    seen = set()
    for player in record['players']:
        if (type(player) is not dict or set(player) != {'actor_identity', 'fields'}
                or not valid_actor(player['actor_identity']) or player['actor_identity'] in seen
                or type(player['fields']) is not dict or not set(player['fields']) <= FIELDS):
            raise ValueError('CONTEXT_PLAYER_SHAPE_OR_IDENTITY')
        seen.add(player['actor_identity'])
        for name, value in player['fields'].items(): field_value(name, value)
    return record
