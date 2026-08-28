"""Read-only ``Active.PlayerStats`` observation with structural validation."""

from __future__ import annotations

from dataclasses import dataclass
import struct

from .il2cpp_external import ExternalReadError, MemoryReader, is_canonical_user_pointer
from .il2cpp_layout import LayoutValidationError, read_il2cpp_string
from .obfuscated_int import decode_obfuscated_int
from .state import ParticipantState


ACTIVE_PLAYER_STATS_MAP_OFFSET = 0x20
ACTIVE_PLAYER_STATS_LIST_OFFSET = 0x28
DICTIONARY_ENTRIES_OFFSET = 0x18
DICTIONARY_COUNT_OFFSET = 0x20
DICTIONARY_FREE_COUNT_OFFSET = 0x28
DICTIONARY_VERSION_OFFSET = 0x2C
DICTIONARY_ENTRY_SIZE = 0x18
DICTIONARY_ENTRY_HASH_OFFSET = 0x00
DICTIONARY_ENTRY_KEY_OFFSET = 0x08
DICTIONARY_ENTRY_VALUE_OFFSET = 0x10
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
MAX_DICTIONARY_SLOTS = 32

# Cpp2IL: MatchService.<Players>k__BackingField is
# Dictionary<string, MatchPlayerSnapshotDTO> at +0xA8.  Active's
# get_LocalActorNumberOrZero() indexes that dictionary with
# ChatService.Username and returns MatchPlayerSnapshotDTO.actorNumber (+0x18).
MATCH_SERVICE_PLAYERS_OFFSET = 0xA8
MATCH_PLAYER_SNAPSHOT_ACTOR_OFFSET = 0x18


@dataclass(frozen=True)
class _DecodedStats:
    address: int
    state: ParticipantState


def read_match_local_actor_number(
    memory: MemoryReader,
    match_service: int,
    local_username: str | None,
) -> int | None:
    """Read the game-owned username -> actor mapping used by ``Active``.

    This mirrors the first, strongest branch of
    ``Active.get_LocalActorNumberOrZero`` without calling game code.  Missing
    or changing data returns ``None``; conflicting/invalid data fails closed.
    """

    if not local_username or not local_username.strip():
        return None
    dictionary = struct.unpack(
        "<Q",
        _read_exact(memory, match_service + MATCH_SERVICE_PLAYERS_OFFSET, 8),
    )[0]
    if not is_canonical_user_pointer(dictionary):
        return None
    header_before = _read_exact(memory, dictionary, 0x30)
    entries = struct.unpack_from(
        "<Q", header_before, DICTIONARY_ENTRIES_OFFSET
    )[0]
    count = struct.unpack_from("<i", header_before, DICTIONARY_COUNT_OFFSET)[0]
    free_count = struct.unpack_from(
        "<i", header_before, DICTIONARY_FREE_COUNT_OFFSET
    )[0]
    version = struct.unpack_from("<i", header_before, DICTIONARY_VERSION_OFFSET)[0]
    if (
        not 0 <= count <= MAX_DICTIONARY_SLOTS
        or not 0 <= free_count <= count
        or version < 0
    ):
        raise LayoutValidationError("MatchService.Players shape is implausible")
    if count == 0:
        return None
    if not is_canonical_user_pointer(entries):
        raise LayoutValidationError("MatchService.Players entries are invalid")
    raw_entries = _read_exact(
        memory,
        entries,
        ARRAY_DATA_OFFSET + count * DICTIONARY_ENTRY_SIZE,
    )
    capacity = struct.unpack_from("<Q", raw_entries, ARRAY_LENGTH_OFFSET)[0]
    if not count <= capacity <= MAX_DICTIONARY_SLOTS * 4:
        raise LayoutValidationError("MatchService.Players capacity is invalid")

    expected = local_username.casefold()
    matches: list[int] = []
    live_entries = 0
    for index in range(count):
        entry = ARRAY_DATA_OFFSET + index * DICTIONARY_ENTRY_SIZE
        hash_code = struct.unpack_from(
            "<i", raw_entries, entry + DICTIONARY_ENTRY_HASH_OFFSET
        )[0]
        if hash_code < 0:
            continue
        live_entries += 1
        key_pointer = struct.unpack_from(
            "<Q", raw_entries, entry + DICTIONARY_ENTRY_KEY_OFFSET
        )[0]
        value_pointer = struct.unpack_from(
            "<Q", raw_entries, entry + DICTIONARY_ENTRY_VALUE_OFFSET
        )[0]
        if not is_canonical_user_pointer(key_pointer) or not is_canonical_user_pointer(
            value_pointer
        ):
            raise LayoutValidationError("MatchService.Players entry is invalid")
        username = read_il2cpp_string(memory, key_pointer, max_length=256)
        if username.casefold() != expected:
            continue
        actor = struct.unpack(
            "<i",
            _read_exact(
                memory,
                value_pointer + MATCH_PLAYER_SNAPSHOT_ACTOR_OFFSET,
                4,
            ),
        )[0]
        if not 1 <= actor <= 999 or actor == WS_BOSS_ACTOR:
            raise LayoutValidationError(
                "MatchService.Players local actor number is implausible"
            )
        matches.append(actor)
    if live_entries != count - free_count:
        raise LayoutValidationError("MatchService.Players live entry count mismatch")
    header_after = _read_exact(memory, dictionary, 0x30)
    if header_after != header_before:
        raise LayoutValidationError("MatchService.Players changed during read")
    if len(matches) > 1 or len(set(matches)) != len(matches):
        raise LayoutValidationError("MatchService.Players local username is ambiguous")
    return matches[0] if matches else None


def _read_exact(memory: MemoryReader, address: int, size: int) -> bytes:
    if not is_canonical_user_pointer(address) or not memory.is_readable(address, size):
        raise LayoutValidationError("player-stats range is unreadable")
    raw = memory.read(address, size)
    if len(raw) != size:
        raise LayoutValidationError("short player-stats read")
    return raw


def _read_stats_object(
    memory: MemoryReader,
    address: int,
    expected_class: int,
    *,
    source: str,
) -> _DecodedStats:
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
    return _DecodedStats(
        address=address,
        state=ParticipantState(
            actor_number=actor,
            is_boss=actor == WS_BOSS_ACTOR,
            source=source,
            **values,
        ),
    )


def _read_stats_list(
    memory: MemoryReader, active_instance: int, expected_class: int
) -> tuple[_DecodedStats, ...]:
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
        _read_stats_object(
            memory,
            pointer,
            expected_class,
            source="Active.playerStatsList/ObfuscatedInt.Value",
        )
        for pointer in pointers
    )
    header_after = _read_exact(memory, list_pointer, 0x20)
    if header_after != header_before:
        raise LayoutValidationError("Active.playerStatsList changed during read")
    actors = {value.state.actor_number for value in values}
    if len(actors) != len(values):
        raise LayoutValidationError("duplicate Active.PlayerStats actorNumber")
    return values


def _read_stats_map(
    memory: MemoryReader, active_instance: int, expected_class: int
) -> tuple[_DecodedStats, ...]:
    """Read the game-owned actor lookup used by ``Active`` itself.

    Cpp2IL confirms ``Active.playerStatsMap`` as
    ``Dictionary<int, Active.PlayerStats>`` at ``+0x20``.  Unlike the
    serialized inspector list, this is the lookup used by combat code.  The
    dictionary and every value are read-only and structurally validated.
    """

    dictionary = struct.unpack(
        "<Q", _read_exact(memory, active_instance + ACTIVE_PLAYER_STATS_MAP_OFFSET, 8)
    )[0]
    header_before = _read_exact(memory, dictionary, 0x30)
    entries = struct.unpack_from(
        "<Q", header_before, DICTIONARY_ENTRIES_OFFSET
    )[0]
    count = struct.unpack_from("<i", header_before, DICTIONARY_COUNT_OFFSET)[0]
    free_count = struct.unpack_from(
        "<i", header_before, DICTIONARY_FREE_COUNT_OFFSET
    )[0]
    version = struct.unpack_from("<i", header_before, DICTIONARY_VERSION_OFFSET)[0]
    if (
        not 1 <= count <= MAX_DICTIONARY_SLOTS
        or not 0 <= free_count < count
        or not 1 <= count - free_count <= MAX_PARTICIPANTS
        or version < 0
    ):
        raise LayoutValidationError("Active.playerStatsMap shape is implausible")
    if not is_canonical_user_pointer(entries):
        raise LayoutValidationError("Active.playerStatsMap entries are invalid")
    raw_entries = _read_exact(
        memory,
        entries,
        ARRAY_DATA_OFFSET + count * DICTIONARY_ENTRY_SIZE,
    )
    capacity = struct.unpack_from("<Q", raw_entries, ARRAY_LENGTH_OFFSET)[0]
    if not count <= capacity <= MAX_DICTIONARY_SLOTS * 4:
        raise LayoutValidationError("Active.playerStatsMap capacity is invalid")

    values: list[_DecodedStats] = []
    actors: set[int] = set()
    pointers: set[int] = set()
    for index in range(count):
        entry = ARRAY_DATA_OFFSET + index * DICTIONARY_ENTRY_SIZE
        hash_code = struct.unpack_from(
            "<i", raw_entries, entry + DICTIONARY_ENTRY_HASH_OFFSET
        )[0]
        if hash_code < 0:
            continue
        actor = struct.unpack_from(
            "<i", raw_entries, entry + DICTIONARY_ENTRY_KEY_OFFSET
        )[0]
        pointer = struct.unpack_from(
            "<Q", raw_entries, entry + DICTIONARY_ENTRY_VALUE_OFFSET
        )[0]
        if (
            not 1 <= actor <= 999
            or actor in actors
            or pointer in pointers
            or not is_canonical_user_pointer(pointer)
        ):
            raise LayoutValidationError("Active.playerStatsMap entry is invalid")
        decoded = _read_stats_object(
            memory,
            pointer,
            expected_class,
            source="Active.playerStatsMap/ObfuscatedInt.Value",
        )
        if decoded.state.actor_number != actor:
            raise LayoutValidationError(
                "Active.playerStatsMap key/actorNumber mismatch"
            )
        actors.add(actor)
        pointers.add(pointer)
        values.append(decoded)
    if len(values) != count - free_count:
        raise LayoutValidationError("Active.playerStatsMap live entry count mismatch")
    header_after = _read_exact(memory, dictionary, 0x30)
    if header_after != header_before:
        raise LayoutValidationError("Active.playerStatsMap changed during read")
    return tuple(values)


def read_active_participants(
    memory: MemoryReader,
    active_instance: int,
    *,
    expected_class: int,
    local_actor_number: int | None = None,
) -> tuple[ParticipantState, ...]:
    """Decode current participants, preferring the game-owned actor map.

    ``playerStatsList`` is a serialized inspector view and was live-observed
    retaining only the boss after many combats.  ``playerStatsMap`` is the
    combat lookup used by ``Active`` and is therefore primary.  The list is
    retained as a validated fallback and an overlapping pointer-consistency
    check.  No value from a previous call/session is cached here.
    """

    map_values: tuple[_DecodedStats, ...] = ()
    list_values: tuple[_DecodedStats, ...] = ()
    map_error: Exception | None = None
    list_error: Exception | None = None
    map_declared = False
    try:
        map_pointer = struct.unpack(
            "<Q",
            _read_exact(
                memory, active_instance + ACTIVE_PLAYER_STATS_MAP_OFFSET, 8
            ),
        )[0]
        map_declared = is_canonical_user_pointer(map_pointer)
    except (KeyError, struct.error, ExternalReadError, OSError, LayoutValidationError):
        pass
    try:
        map_values = _read_stats_map(memory, active_instance, expected_class)
    except (
        KeyError,
        struct.error,
        ExternalReadError,
        OSError,
        LayoutValidationError,
    ) as exc:
        map_error = exc
    if map_declared and map_error is not None:
        # Once Active publishes a real map object, a malformed/changing map is
        # current-state uncertainty.  Falling back to an inspector list in
        # that case could resurrect a partial/stale participant set.
        raise LayoutValidationError(
            f"cannot decode declared Active.playerStatsMap: {map_error}"
        ) from map_error
    try:
        list_values = _read_stats_list(memory, active_instance, expected_class)
    except (
        KeyError,
        struct.error,
        ExternalReadError,
        OSError,
        LayoutValidationError,
    ) as exc:
        list_error = exc

    if map_values and list_values:
        map_by_actor = {value.state.actor_number: value for value in map_values}
        for listed in list_values:
            mapped = map_by_actor.get(listed.state.actor_number)
            if mapped is not None and mapped.address != listed.address:
                raise LayoutValidationError(
                    "Active playerStatsMap/list pointer conflict"
                )
    selected = map_values or list_values
    if not selected:
        raise LayoutValidationError(
            "cannot decode current Active participants: "
            f"map={map_error}; list={list_error}"
        )

    if local_actor_number is not None and not (
        1 <= local_actor_number <= 999 and local_actor_number != WS_BOSS_ACTOR
    ):
        raise LayoutValidationError("explicit local actor number is implausible")
    non_boss = [
        value.state for value in selected if value.state.actor_number != WS_BOSS_ACTOR
    ]
    local_actor = (
        local_actor_number
        if local_actor_number is not None
        else (non_boss[0].actor_number if len(non_boss) == 1 else None)
    )
    return tuple(
        ParticipantState(
            actor_number=value.state.actor_number,
            is_local=(
                value.state.actor_number == local_actor
                if local_actor is not None
                else None
            ),
            is_boss=value.state.is_boss,
            hp=value.state.hp,
            max_hp=value.state.max_hp,
            mana=value.state.mana,
            max_mana=value.state.max_mana,
            power=value.state.power,
            max_power=value.state.max_power,
            attack=value.state.attack,
            shield=value.state.shield,
            source=value.state.source,
        )
        for value in selected
    )
