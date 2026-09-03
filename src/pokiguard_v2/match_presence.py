"""Validated read-only observation of ``Board._leftActorNumbers``.

The game updates this durable ``HashSet<int>`` from its player-left handler.
It is therefore stronger evidence that a combat participant has left than the
older ``MatchService.Players`` snapshot, which can remain stale after a
disconnect/ejection.
"""

from __future__ import annotations

from dataclasses import dataclass
import struct
from typing import Any

from .il2cpp_external import is_canonical_user_pointer
from .il2cpp_layout import LayoutValidationError


BOARD_LEFT_ACTOR_NUMBERS_OFFSET = 0x2C0
HASHSET_BUCKETS_OFFSET = 0x10
HASHSET_SLOTS_OFFSET = 0x18
HASHSET_COUNT_OFFSET = 0x20
HASHSET_LAST_INDEX_OFFSET = 0x24
HASHSET_FREE_LIST_OFFSET = 0x28
HASHSET_VERSION_OFFSET = 0x38
ARRAY_LENGTH_OFFSET = 0x18
ARRAY_DATA_OFFSET = 0x20
INT32_SLOT_SIZE = 0x0C
MAX_MATCH_ACTORS = 32


@dataclass(frozen=True)
class LeftActorSnapshot:
    hashset_address: int
    count: int
    last_index: int
    version: int
    actor_numbers: tuple[int, ...]


def _read_exact(memory: Any, address: int, size: int) -> bytes:
    if not is_canonical_user_pointer(address) or not memory.is_readable(address, size):
        raise LayoutValidationError("left-actor HashSet range is unreadable")
    raw = memory.read(address, size)
    if len(raw) != size:
        raise LayoutValidationError("short left-actor HashSet read")
    return raw


def read_left_actor_numbers(memory: Any, board_instance: int) -> LeftActorSnapshot:
    """Read ``Board._leftActorNumbers`` and fail closed on any torn layout."""

    pointer_raw = _read_exact(
        memory,
        board_instance + BOARD_LEFT_ACTOR_NUMBERS_OFFSET,
        8,
    )
    pointer = struct.unpack("<Q", pointer_raw)[0]
    before = _read_exact(memory, pointer, 0x40)
    buckets, slots = struct.unpack_from("<QQ", before, HASHSET_BUCKETS_OFFSET)
    count, last_index, free_list = struct.unpack_from(
        "<iii", before, HASHSET_COUNT_OFFSET
    )
    version = struct.unpack_from("<i", before, HASHSET_VERSION_OFFSET)[0]
    if not 0 <= count <= MAX_MATCH_ACTORS:
        raise LayoutValidationError("left-actor HashSet count is implausible")
    if not 0 <= last_index <= MAX_MATCH_ACTORS:
        raise LayoutValidationError("left-actor HashSet lastIndex is implausible")
    if count > last_index or not -1 <= free_list < max(1, last_index):
        raise LayoutValidationError("left-actor HashSet counters are inconsistent")

    if count == 0:
        after = _read_exact(memory, pointer, 0x40)
        if before != after:
            raise LayoutValidationError("left-actor HashSet changed during read")
        return LeftActorSnapshot(pointer, 0, last_index, version, ())

    if not (
        is_canonical_user_pointer(buckets)
        and memory.is_readable(buckets, ARRAY_DATA_OFFSET)
        and is_canonical_user_pointer(slots)
        and memory.is_readable(slots, ARRAY_DATA_OFFSET)
    ):
        raise LayoutValidationError("left-actor HashSet arrays are invalid")
    slot_header = _read_exact(memory, slots, ARRAY_DATA_OFFSET)
    slot_class, _monitor, bounds, capacity = struct.unpack("<4Q", slot_header)
    if (
        not is_canonical_user_pointer(slot_class)
        or not memory.is_readable(slot_class, 8)
        or bounds != 0
        or not last_index <= capacity <= MAX_MATCH_ACTORS * 4
    ):
        raise LayoutValidationError("left-actor slot array shape is invalid")

    raw_slots = _read_exact(
        memory,
        slots + ARRAY_DATA_OFFSET,
        last_index * INT32_SLOT_SIZE,
    )
    values: list[int] = []
    occupied = 0
    for index in range(last_index):
        hash_code, next_index, actor_number = struct.unpack_from(
            "<iii", raw_slots, index * INT32_SLOT_SIZE
        )
        if hash_code < 0:
            continue
        occupied += 1
        if (
            not 1 <= actor_number <= 999
            or next_index < -1
            or next_index >= last_index
        ):
            raise LayoutValidationError("left-actor HashSet slot failed validation")
        values.append(actor_number)
    if occupied != count or len(set(values)) != count:
        raise LayoutValidationError("left-actor HashSet count/uniqueness mismatch")

    after = _read_exact(memory, pointer, 0x40)
    after_count, after_last_index = struct.unpack_from(
        "<ii", after, HASHSET_COUNT_OFFSET
    )
    after_version = struct.unpack_from("<i", after, HASHSET_VERSION_OFFSET)[0]
    if (count, last_index, version) != (
        after_count,
        after_last_index,
        after_version,
    ):
        raise LayoutValidationError("left-actor HashSet changed during read")
    return LeftActorSnapshot(
        pointer,
        count,
        last_index,
        version,
        tuple(sorted(values)),
    )
