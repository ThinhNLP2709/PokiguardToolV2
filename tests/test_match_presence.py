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

from pokiguard_v2.il2cpp_layout import LayoutValidationError
from pokiguard_v2.match_presence import read_left_actor_numbers


class FakeMemory:
    def __init__(self) -> None:
        self.bytes: dict[int, int] = {}

    def map(self, address: int, data: bytes | bytearray) -> None:
        self.bytes.update({address + i: value for i, value in enumerate(data)})

    def read(self, address: int, size: int) -> bytes:
        return bytes(self.bytes[address + i] for i in range(size))

    def is_readable(self, address: int, size: int) -> bool:
        return size > 0 and all(address + i in self.bytes for i in range(size))


class MatchPresenceTests(unittest.TestCase):
    BOARD = 0x0000020000000000
    SET = 0x0000021000000000
    BUCKETS = 0x0000022000000000
    SLOTS = 0x0000023000000000
    CLASS = 0x0000024000000000

    def make_memory(self, values: tuple[int, ...]) -> FakeMemory:
        memory = FakeMemory()
        board = bytearray(0x2B8)
        struct.pack_into("<Q", board, 0x2B0, self.SET)
        memory.map(self.BOARD, board)
        capacity = max(3, len(values) + 2)
        hashset = bytearray(0x40)
        struct.pack_into("<QQ", hashset, 0x10, self.BUCKETS, self.SLOTS)
        struct.pack_into("<iii", hashset, 0x20, len(values), len(values), -1)
        struct.pack_into("<i", hashset, 0x38, 11)
        memory.map(self.SET, hashset)
        buckets = bytearray(0x20 + capacity * 4)
        struct.pack_into("<4Q", buckets, 0, self.CLASS, 0, 0, capacity)
        memory.map(self.BUCKETS, buckets)
        slots = bytearray(0x20 + capacity * 0x0C)
        struct.pack_into("<4Q", slots, 0, self.CLASS, 0, 0, capacity)
        for index, value in enumerate(values):
            struct.pack_into("<iii", slots, 0x20 + index * 0x0C, value, -1, value)
        memory.map(self.SLOTS, slots)
        memory.map(self.CLASS, bytearray(8))
        return memory

    def test_decodes_local_actor_left_signal(self) -> None:
        result = read_left_actor_numbers(self.make_memory((1,)), self.BOARD)
        self.assertEqual(result.actor_numbers, (1,))
        self.assertEqual(result.count, 1)

    def test_empty_set_is_valid(self) -> None:
        result = read_left_actor_numbers(self.make_memory(()), self.BOARD)
        self.assertEqual(result.actor_numbers, ())

    def test_duplicate_actor_numbers_fail_closed(self) -> None:
        with self.assertRaises(LayoutValidationError):
            read_left_actor_numbers(self.make_memory((1, 1)), self.BOARD)

    def test_implausible_actor_number_fails_closed(self) -> None:
        with self.assertRaises(LayoutValidationError):
            read_left_actor_numbers(self.make_memory((0,)), self.BOARD)


if __name__ == "__main__":
    unittest.main()
