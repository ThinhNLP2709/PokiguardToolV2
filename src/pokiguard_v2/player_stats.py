"""Read-only ``Active.PlayerStats`` observation with structural validation."""

from __future__ import annotations

import struct

from .il2cpp_external import ExternalReadError, MemoryReader, is_canonical_user_pointer
from .il2cpp_layout import LayoutValidationError
from .obfuscated_int import decode_obfuscated_int
from .state import ParticipantState


ACTIVE_PLAYER_STATS_LIST_OFFSET = 0x28
LIST_ITEMS_OFFSET = 0x10
LIST_SIZE_OFFSET = 0x18
LIST_VERSION_OFFSET = 0x1C
ARRAY_LENGTH_OFFSET = 0x18
ARRAY_DATA_OFFSET = 0x20

PLAYER_STATS_ACTOR_OFFSET = 0x10
PLAYER_STATS_CURRENT_HP_OFFSET = 0x14
PLAYER_STATS_MAX_HP_OFFSET = 0x24
PLAYER_STATS_CURRENT_MANA_OFFSET = 0x34
PLAYER_STATS_MAX_MANA_OFFSET = 0x44
PLAYER_STATS_CURRENT_POWER_OFFSET = 0x54
PLAYER_STATS_MAX_POWER_OFFSET = 0x64
PLAYER_STATS_ATTACK_OFFSET = 0x74
PLAYER_STATS_SHIELD_OFFSET = 0x84
PLAYER_STATS_READ_SIZE = 0xA8

WS_BOSS_ACTOR = 99
MAX_PARTICIPANTS = 16


def _read_exact(memory: MemoryReader, address: int, size: int) -> bytes:
    if not is_canonical_user_pointer(address) or not memory.is_readable(address, size):
        raise LayoutValidationError("player-stats range is unreadable")
    raw = memory.read(address, size)
    if len(raw) != size:
        raise LayoutValidationError("short player-stats read")
    return raw


def _read_stats_object(
    memory: MemoryReader, address: int, expected_class: int
) -> ParticipantState:
    raw = _read_exact(memory, address, PLAYER_STATS_READ_SIZE)
    class_pointer = struct.unpack_from("<Q", raw, 0)[0]
    if class_pointer != expected_class:
        raise LayoutValidationError("Active.PlayerStats class pointer mismatch")
    actor = struct.unpack_from("<i", raw, PLAYER_STATS_ACTOR_OFFSET)[0]
    if not 1 <= actor <= 999:
        raise LayoutValidationError("Active.PlayerStats actorNumber is implausible")
    values = {
        "hp": decode_obfuscated_int(raw, PLAYER_STATS_CURRENT_HP_OFFSET),
        "max_hp": decode_obfuscated_int(raw, PLAYER_STATS_MAX_HP_OFFSET),
        "mana": decode_obfuscated_int(raw, PLAYER_STATS_CURRENT_MANA_OFFSET),
        "max_mana": decode_obfuscated_int(raw, PLAYER_STATS_MAX_MANA_OFFSET),
        "power": decode_obfuscated_int(raw, PLAYER_STATS_CURRENT_POWER_OFFSET),
        "max_power": decode_obfuscated_int(raw, PLAYER_STATS_MAX_POWER_OFFSET),
        "attack": decode_obfuscated_int(raw, PLAYER_STATS_ATTACK_OFFSET),
        "shield": decode_obfuscated_int(raw, PLAYER_STATS_SHIELD_OFFSET),
    }
    if (
        values["max_hp"] <= 0
        or values["max_mana"] < 0
        or values["max_power"] < 0
        or any(
            values[name] < 0
            for name in ("hp", "mana", "power", "attack", "shield")
        )
        or values["hp"] > values["max_hp"]
        or (values["max_mana"] and values["mana"] > values["max_mana"])
        or (values["max_power"] and values["power"] > values["max_power"])
    ):
        raise LayoutValidationError("decoded Active.PlayerStats values are implausible")
    return ParticipantState(
        actor_number=actor,
        is_boss=actor == WS_BOSS_ACTOR,
        source="Active.playerStatsList/ObfuscatedInt.Value",
        **values,
    )


def read_active_participants(
    memory: MemoryReader, active_instance: int, *, expected_class: int
) -> tuple[ParticipantState, ...]:
    """Decode a stable List<PlayerStats>; ownership stays unknown in co-op."""

    try:
        list_pointer = struct.unpack(
            "<Q",
            _read_exact(memory, active_instance + ACTIVE_PLAYER_STATS_LIST_OFFSET, 8),
        )[0]
        header_before = _read_exact(memory, list_pointer, 0x20)
        items = struct.unpack_from("<Q", header_before, LIST_ITEMS_OFFSET)[0]
        size = struct.unpack_from("<i", header_before, LIST_SIZE_OFFSET)[0]
        version = struct.unpack_from("<i", header_before, LIST_VERSION_OFFSET)[0]
        if not 1 <= size <= MAX_PARTICIPANTS or version < 0:
            raise LayoutValidationError("Active.playerStatsList shape is implausible")
        array_header = _read_exact(memory, items, ARRAY_DATA_OFFSET + size * 8)
        capacity = struct.unpack_from("<Q", array_header, ARRAY_LENGTH_OFFSET)[0]
        if not size <= capacity <= 128:
            raise LayoutValidationError("Active.playerStatsList backing array is invalid")
        pointers = struct.unpack_from(f"<{size}Q", array_header, ARRAY_DATA_OFFSET)
        if len(set(pointers)) != size or any(
            not is_canonical_user_pointer(pointer) for pointer in pointers
        ):
            raise LayoutValidationError("Active.playerStatsList entries are invalid")
        values = tuple(
            _read_stats_object(memory, pointer, expected_class) for pointer in pointers
        )
        header_after = _read_exact(memory, list_pointer, 0x20)
        if header_after != header_before:
            raise LayoutValidationError("Active.playerStatsList changed during read")
        actors = {value.actor_number for value in values}
        if len(actors) != len(values):
            raise LayoutValidationError("duplicate Active.PlayerStats actorNumber")
    except (KeyError, struct.error, ExternalReadError, OSError) as exc:
        raise LayoutValidationError(f"cannot decode Active.playerStatsList: {exc}") from exc

    non_boss = [value for value in values if value.actor_number != WS_BOSS_ACTOR]
    local_actor = non_boss[0].actor_number if len(non_boss) == 1 else None
    return tuple(
        ParticipantState(
            actor_number=value.actor_number,
            is_local=(
                value.actor_number == local_actor if local_actor is not None else None
            ),
            is_boss=value.is_boss,
            hp=value.hp,
            max_hp=value.max_hp,
            mana=value.mana,
            max_mana=value.max_mana,
            power=value.power,
            max_power=value.max_power,
            attack=value.attack,
            shield=value.shield,
            source=value.source,
        )
        for value in values
    )
