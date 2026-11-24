"""Optional skill diagnostics from state/JSON already owned by the controller.

No game reads, action permission, waits, retries or damage predictions. The
context is from the controller's fresh checkpoint, not the final click reread.
"""
from dataclasses import asdict
from enum import Enum
import hashlib
import json

from .combat_outcome_evidence import actor_identity

SCHEMA = 'pokiguard.skill_action_context.v1'
MAX_CONTEXT_BYTES = 4096


def _plain(value):
    return value.value if isinstance(value, Enum) else value


def _stats(participant):
    if participant is None:
        return None
    fields = ('actor_number', 'is_local', 'is_boss', 'hp', 'max_hp', 'mana',
              'max_mana', 'power', 'max_power', 'attack', 'shield')
    return {k: getattr(participant, k) for k in fields}


def context_fields_safely(identity, state, capability, config):
    """Missing diagnostics cannot veto an input or change an existing owner."""
    try:
        source = identity.source
        card_id = capability.skill_card_id
        if (identity.action.value != 'pet_skill' or not capability.current
                or capability.session_key != source.session
                or identity.target != (source.session, card_id)
                or state.battle.session_key != source.session
                or state.battle.srv_seq != source.srv_seq
                or state.battle.turn_number != source.turn
                or state.battle.board_hash != source.board_hash
                or state.battle.current_turn_player != source.current_turn_player):
            raise ValueError('SOURCE_CARD_OR_CHECKPOINT_MISMATCH')
        src = asdict(source)
        who = actor_identity(src.pop('current_turn_player'))
        src['actor_identity'] = who
        bosses = [p for p in state.participants if p.is_boss is True]
        record = dict(schema=SCHEMA, status='RECORDED', source=src, skill_card_id=card_id,
            family=capability.skill_family.value, element_type=capability.element_type,
            costs=dict(mana=capability.effective_mana_cost, rage=capability.effective_power_cost,
                mana_source=capability.effective_mana_cost_source.value,
                rage_source=capability.effective_power_cost_source.value),
            phase=dict(next=capability.skill_phase_next, maximum=capability.skill_phase_max,
                       source=capability.skill_phase_source),
            player=_stats(state.player), boss=_stats(bosses[0]) if len(bosses) == 1 else None,
            settings={k: _plain(getattr(config, k)) for k in (
                'play_style', 'main_pet', 'evolution', 'pet_skill_fire_condition',
                'pet_skill_fire_value', 'mega_self_protection')},
            scope='CONTROLLER_FRESH_CHECKPOINT_NOT_FINAL_CLICK_REREAD',
            input_authority=False, calibration_eligible=False, prediction=None)
        raw = json.dumps(record, sort_keys=True, separators=(',', ':'), ensure_ascii=True)
        record['context_sha256'] = hashlib.sha256(raw.encode()).hexdigest()
        if len(json.dumps(record, ensure_ascii=True, separators=(',', ':')).encode()) > MAX_CONTEXT_BYTES:
            raise ValueError('CONTEXT_BYTE_LIMIT')
        return dict(skillActionContext=record)
    except Exception as exc:
        detail = str(exc) if type(exc) is ValueError and str(exc) in {
            'SOURCE_CARD_OR_CHECKPOINT_MISMATCH', 'CONTEXT_BYTE_LIMIT',
            'ACTOR_IDENTITY_MISSING_OR_INVALID',
        } else type(exc).__name__
        return dict(skillActionContext=dict(schema=SCHEMA, status='UNAVAILABLE',
            reason='SKILL_CONTEXT_' + detail, input_authority=False,
            calibration_eligible=False, prediction=None))


def emit_retained_skill_outcomes_safely(tap, identity, emit):
    """Snapshot at most two retained records without consuming the tap queue."""
    try:
        source = identity.source
        records = tap.skill_outcome_snapshot(source.session.match_id, source.srv_seq)
        if type(records) is not tuple or len(records) > 2:
            raise ValueError('SKILL_EXPORT_SHAPE_OR_LIMIT')
        for record in records:
            emit('pet_skill_retained_outcome', matchId=source.session.match_id,
                 sourceTurn=source.turn, sourceSrvSeq=source.srv_seq,
                 sourceSession=asdict(source.session),
                 combatOutcome=record, inputAuthority=False,
                 captureScope='RETAINED_JSON_WITHOUT_ACTION_ACK_OR_BOARD_ATTESTATION')
        emit('pet_skill_capture_checkpoint', status='CHECKED', matchId=source.session.match_id,
             sourceTurn=source.turn, sourceSrvSeq=source.srv_seq, retainedRecords=len(records),
             reason='RETAINED_RECORDS_ONLY_NOT_COMPLETE_EFFECT_COVERAGE', inputAuthority=False)
        return True
    except Exception as exc:
        try:
            emit('pet_skill_capture_checkpoint', status='UNAVAILABLE',
                 reason='SKILL_EXPORT_' + type(exc).__name__, inputAuthority=False)
        except Exception:
            pass
        return False
