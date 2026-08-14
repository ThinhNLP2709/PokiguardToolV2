from __future__ import annotations

from pathlib import Path
import struct
import sys
import unittest


SRC = Path(__file__).resolve().parents[1] / "src"
if str(SRC) not in sys.path:
    sys.path.insert(0, str(SRC))

from pokiguard_v2.obfuscated_int import encode_for_test
from pokiguard_v2.player_stats import read_active_participants


class FakeMemory:
    def __init__(self) -> None:
        self.bytes: dict[int, int] = {}

    def map(self, address: int, data: bytes | bytearray) -> None:
        self.bytes.update({address + index: value for index, value in enumerate(data)})

    def read(self, address: int, size: int) -> bytes:
        return bytes(self.bytes[address + index] for index in range(size))

    def is_readable(self, address: int, size: int) -> bool:
        return size > 0 and all(address + index in self.bytes for index in range(size))


BASE = 0x0000021000000000


def stats_object(actor: int, hp: int, maximum: int, class_pointer: int) -> bytes:
    raw = bytearray(0xA8)
    struct.pack_into("<Q", raw, 0, class_pointer)
    struct.pack_into("<i", raw, 0x10, actor)
    values = (hp, maximum, 160, 320, 45, 100, 250, 12)
    for index, value in enumerate(values):
        raw[0x14 + index * 0x10 : 0x24 + index * 0x10] = encode_for_test(
            value,
            key_a=0x12345678 + index,
            key_b=-123456789 + index,
            noise=index,
        )
    return bytes(raw)


def memory_with_actors(actors: tuple[int, ...]) -> tuple[FakeMemory, int]:
    memory = FakeMemory()
    active = BASE
    list_pointer = BASE + 0x1000
    array = BASE + 0x2000
    class_pointer = BASE + 0x3000
    memory.map(class_pointer, bytes(8))
    memory.map(active + 0x28, struct.pack("<Q", list_pointer))
    list_raw = bytearray(0x20)
    struct.pack_into("<Q", list_raw, 0x10, array)
    struct.pack_into("<ii", list_raw, 0x18, len(actors), 7)
    memory.map(list_pointer, list_raw)
    pointers = tuple(BASE + 0x4000 + index * 0x1000 for index in range(len(actors)))
    array_raw = bytearray(0x20 + len(pointers) * 8)
    struct.pack_into("<Q", array_raw, 0x18, len(pointers))
    struct.pack_into(f"<{len(pointers)}Q", array_raw, 0x20, *pointers)
    memory.map(array, array_raw)
    for pointer, actor in zip(pointers, actors):
        memory.map(pointer, stats_object(actor, 900 if actor != 99 else 9000, 1000 if actor != 99 else 10000, class_pointer))
    return memory, active


class PlayerStatsTests(unittest.TestCase):
    def test_decodes_single_player_and_boss(self) -> None:
        memory, active = memory_with_actors((7, 99))
        values = read_active_participants(memory, active, expected_class=BASE + 0x3000)
        player = next(value for value in values if value.actor_number == 7)
        boss = next(value for value in values if value.actor_number == 99)
        self.assertTrue(player.is_local)
        self.assertEqual((player.hp, player.max_hp, player.mana), (900, 1000, 160))
        self.assertTrue(boss.is_boss)
        self.assertFalse(boss.is_local)

    def test_coop_does_not_guess_local_ownership(self) -> None:
        memory, active = memory_with_actors((7, 8, 99))
        values = read_active_participants(memory, active, expected_class=BASE + 0x3000)
        self.assertTrue(all(value.is_local is None for value in values))


if __name__ == "__main__":
    unittest.main()
