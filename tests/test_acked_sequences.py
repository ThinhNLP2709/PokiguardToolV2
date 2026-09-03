from __future__ import annotations

import struct
from pathlib import Path
import sys
import unittest


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.acked_sequences import read_acked_sequences
from pokiguard_v2.il2cpp_layout import LayoutValidationError


class FakeMemory:
    def __init__(self) -> None:
        self.bytes: dict[int, int] = {}

    def map(self, address: int, data: bytes | bytearray) -> None:
        self.bytes.update(
            {address + index: value for index, value in enumerate(data)}
        )

    def read(self, address: int, size: int) -> bytes:
        return bytes(self.bytes[address + index] for index in range(size))

    def is_readable(self, address: int, size: int) -> bool:
        return size > 0 and all(
            address + index in self.bytes for index in range(size)
        )


class AckedSequenceTests(unittest.TestCase):
    MATCH = 0x0000020000000000
    SET = 0x0000021000000000
    BUCKETS = 0x0000022000000000
    SLOTS = 0x0000023000000000
    CLASS = 0x0000024000000000

    def make_memory(self, values: tuple[int, ...]) -> FakeMemory:
        memory = FakeMemory()
        match = bytearray(0x1A0)
        struct.pack_into("<Q", match, 0x198, self.SET)
        memory.map(self.MATCH, match)
        capacity = max(3, len(values) + 2)
        hashset = bytearray(0x40)
        struct.pack_into("<QQ", hashset, 0x10, self.BUCKETS, self.SLOTS)
        struct.pack_into("<iii", hashset, 0x20, len(values), len(values), -1)
        struct.pack_into("<i", hashset, 0x38, 7)
        memory.map(self.SET, hashset)
        buckets = bytearray(0x20 + capacity * 4)
        struct.pack_into("<4Q", buckets, 0, self.CLASS, 0, 0, capacity)
        memory.map(self.BUCKETS, buckets)
        slots = bytearray(0x20 + capacity * 0x10)
        struct.pack_into("<4Q", slots, 0, self.CLASS, 0, 0, capacity)
        for index, value in enumerate(values):
            struct.pack_into("<iiq", slots, 0x20 + index * 0x10, value, -1, value)
        memory.map(self.SLOTS, slots)
        memory.map(self.CLASS, bytearray(8))
        return memory

    def test_decodes_runtime_proven_int64_slots(self) -> None:
        result = read_acked_sequences(self.make_memory((5, 9, 13)), self.MATCH)
        self.assertEqual(result.sequences, (5, 9, 13))
        self.assertEqual(result.highest, 13)
        self.assertEqual(result.count, 3)

    def test_duplicate_values_fail_closed(self) -> None:
        with self.assertRaises(LayoutValidationError):
            read_acked_sequences(self.make_memory((5, 5)), self.MATCH)

    def test_empty_set_is_valid(self) -> None:
        result = read_acked_sequences(self.make_memory(()), self.MATCH)
        self.assertEqual(result.sequences, ())
        self.assertIsNone(result.highest)


if __name__ == "__main__":
    unittest.main()
