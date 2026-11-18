"""Read B15 local skill phases without invoking MatchService methods.

Cpp2IL and native TryGetLocalSkillPhase (RVA 0xACE810) verify these fields.
We require an exact card binding and reject invalid phases rather than using
the game's display clamping or guessing phase one.
"""
from dataclasses import dataclass
import struct

from .il2cpp_external import is_canonical_user_pointer
from .il2cpp_layout import LayoutValidationError
from .player_stats import _read_match_local_snapshot, _read_exact


SNAPSHOT_READ_SIZE = 0x184
SKILL_PHASE_NEXT_OFFSET = 0x15C
SKILL_PHASE_MAX_OFFSET = 0x17C
SKILL_PHASE_CARD_ID_OFFSET = 0x180


@dataclass(frozen=True)
class SkillPhaseObservation:
    card_id: int
    next_phase: int
    maximum: int
    source: str = "MatchService.Players.local.skillPhaseNext/Max/CardId"


def read_local_skill_phase(memory, match_service, local_username, *, local_actor, card_id):
    if type(card_id) is not int or card_id <= 0 or type(local_actor) is not int or local_actor <= 0:
        raise LayoutValidationError("skill phase card/actor identity invalid")
    local = _read_match_local_snapshot(memory, match_service, local_username)
    if local is None:
        return None
    actor, address = local
    if actor != local_actor:
        raise LayoutValidationError("skill phase local actor mismatch")
    raw = _read_exact(memory, address, SNAPSHOT_READ_SIZE)
    if struct.unpack_from("<i", raw, 0x18)[0] != local_actor:
        raise LayoutValidationError("skill phase snapshot actor changed")
    klass = struct.unpack_from("<Q", raw, 0)[0]
    if not is_canonical_user_pointer(klass) or not memory.is_readable(klass, 8):
        raise LayoutValidationError("skill phase snapshot class invalid")
    phase = struct.unpack_from("<i", raw, SKILL_PHASE_NEXT_OFFSET)[0]
    maximum, bound_card = struct.unpack_from("<ii", raw, SKILL_PHASE_MAX_OFFSET)
    if (_read_exact(memory, address, SNAPSHOT_READ_SIZE) != raw
            or _read_match_local_snapshot(memory, match_service, local_username) != local):
        raise LayoutValidationError("skill phase ownership/value changed during read")
    if bound_card != card_id or maximum == 0:
        return None
    if not 2 <= maximum <= 9 or not 1 <= phase <= maximum:
        raise LayoutValidationError("skill phase range invalid")
    return SkillPhaseObservation(card_id, phase, maximum)
