"""Read the runtime-verified ``HashSet<long> MatchService._ackedSeqs``.

Cpp2IL proves that `SendAnimAck` inserts a positive server sequence into this
set, and `ApplyMatchInitFromMessage` clears it for every new match.  The layout
below is also proved by System.Core HashSet ISIL and was runtime-validated on
the target build (49 values decoded exactly after a completed match).
"""

from __future__ import annotations

from dataclasses import dataclass
import struct
from typing import Any

from .il2cpp_external import is_canonical_user_pointer
from .il2cpp_layout import LayoutValidationError


MATCH_SERVICE_ACKED_SEQS_OFFSET = 0x180
HASHSET_BUCKETS_OFFSET = 0x10
HASHSET_SLOTS_OFFSET = 0x18
HASHSET_COUNT_OFFSET = 0x20
HASHSET_LAST_INDEX_OFFSET = 0x24
HASHSET_FREE_LIST_OFFSET = 0x28
HASHSET_VERSION_OFFSET = 0x38
ARRAY_DATA_OFFSET = 0x20
INT64_SLOT_SIZE = 0x10
MAX_ACKED_SEQUENCES = 128


@dataclass(frozen=True)
class AckedSequenceSnapshot:
    hashset_address: int
    count: int
    last_index: int
    version: int
    sequences: tuple[int, ...]

    @property
    def highest(self) -> int | None:
        return max(self.sequences, default=None)


def read_acked_sequences(memory: Any, match_service: int) -> AckedSequenceSnapshot:
    pointer = struct.unpack(
        "<Q",
        memory.read(match_service + MATCH_SERVICE_ACKED_SEQS_OFFSET, 8),
    )[0]
    if not is_canonical_user_pointer(pointer) or not memory.is_readable(pointer, 0x40):
        raise LayoutValidationError("MatchService._ackedSeqs is not readable")

    before = memory.read(pointer, 0x40)
    buckets, slots = struct.unpack_from("<QQ", before, HASHSET_BUCKETS_OFFSET)
    count, last_index, free_list = struct.unpack_from(
        "<iii", before, HASHSET_COUNT_OFFSET
    )
    version = struct.unpack_from("<i", before, HASHSET_VERSION_OFFSET)[0]
    if not 0 <= count <= MAX_ACKED_SEQUENCES:
        raise LayoutValidationError("acked sequence count is implausible")
    if not 0 <= last_index <= MAX_ACKED_SEQUENCES:
        raise LayoutValidationError("acked sequence lastIndex is implausible")
    if count > last_index or not -1 <= free_list < max(1, last_index):
        raise LayoutValidationError("acked sequence HashSet counters are inconsistent")
    if count == 0:
        after = memory.read(pointer, 0x40)
        if before != after:
            raise LayoutValidationError("acked sequence HashSet changed during read")
        return AckedSequenceSnapshot(pointer, 0, last_index, version, ())
    if (
        not is_canonical_user_pointer(buckets)
        or not memory.is_readable(buckets, 0x20)
        or not is_canonical_user_pointer(slots)
        or not memory.is_readable(slots, 0x20)
    ):
        raise LayoutValidationError("acked sequence HashSet arrays are invalid")
    slots_header = memory.read(slots, 0x20)
    slots_class, _monitor, bounds, capacity = struct.unpack("<4Q", slots_header)
    if (
        not is_canonical_user_pointer(slots_class)
        or not memory.is_readable(slots_class, 8)
        or bounds != 0
        or not last_index <= capacity <= 256
    ):
        raise LayoutValidationError("acked sequence slot array shape is invalid")

    raw_slots = memory.read(slots + ARRAY_DATA_OFFSET, last_index * INT64_SLOT_SIZE)
    values: list[int] = []
    occupied = 0
    for index in range(last_index):
        hash_code, next_index, value = struct.unpack_from(
            "<iiq", raw_slots, index * INT64_SLOT_SIZE
        )
        if hash_code < 0:
            continue
        occupied += 1
        if value <= 0 or next_index < -1 or next_index >= last_index:
            raise LayoutValidationError("acked sequence slot failed validation")
        values.append(value)
    if occupied != count or len(set(values)) != count:
        raise LayoutValidationError("acked sequence set count/uniqueness mismatch")
    after = memory.read(pointer, 0x40)
    after_count, after_last_index = struct.unpack_from(
        "<ii", after, HASHSET_COUNT_OFFSET
    )
    after_version = struct.unpack_from("<i", after, HASHSET_VERSION_OFFSET)[0]
    if (count, last_index, version) != (
        after_count,
        after_last_index,
        after_version,
    ):
        raise LayoutValidationError("acked sequence HashSet changed during read")
    return AckedSequenceSnapshot(
        pointer, count, last_index, version, tuple(sorted(values))
    )
