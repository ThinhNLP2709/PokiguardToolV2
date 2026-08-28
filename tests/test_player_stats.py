from __future__ import annotations

from pathlib import Path
import struct
import sys
import unittest


SRC = Path(__file__).resolve().parents[1] / "src"
if str(SRC) not in sys.path:
    sys.path.insert(0, str(SRC))

from pokiguard_v2.obfuscated_int import encode_for_test
from pokiguard_v2.il2cpp_layout import LayoutValidationError
from pokiguard_v2.player_stats import (
    read_active_participants,
    read_match_local_actor_number,
)


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


def install_stats_map(
    memory: FakeMemory,
    active: int,
    entries: tuple[tuple[int, int], ...],
    *,
    version: int = 11,
) -> None:
    dictionary = BASE + 0x9000
    entries_array = BASE + 0xA000
    memory.map(active + 0x20, struct.pack("<Q", dictionary))
    header = bytearray(0x30)
    struct.pack_into("<Q", header, 0x18, entries_array)
    struct.pack_into("<i", header, 0x20, len(entries))
    struct.pack_into("<i", header, 0x28, 0)
    struct.pack_into("<i", header, 0x2C, version)
    memory.map(dictionary, header)
    raw = bytearray(0x20 + len(entries) * 0x18)
    struct.pack_into("<Q", raw, 0x18, len(entries))
    for index, (actor, pointer) in enumerate(entries):
        offset = 0x20 + index * 0x18
        struct.pack_into("<ii", raw, offset, actor, -1)
        struct.pack_into("<i", raw, offset + 0x08, actor)
        struct.pack_into("<Q", raw, offset + 0x10, pointer)
    memory.map(entries_array, raw)


def il2cpp_string(value: str) -> bytes:
    encoded = value.encode("utf-16-le")
    raw = bytearray(0x14 + len(encoded))
    struct.pack_into("<Q", raw, 0, BASE + 0x1F000)
    struct.pack_into("<i", raw, 0x10, len(value))
    raw[0x14:] = encoded
    return bytes(raw)


def install_match_players(
    memory: FakeMemory,
    match_service: int,
    entries: tuple[tuple[str, int], ...],
) -> None:
    dictionary = BASE + 0xC000
    entries_array = BASE + 0xD000
    memory.map(BASE + 0x1F000, bytes(8))
    memory.map(match_service + 0xA8, struct.pack("<Q", dictionary))
    header = bytearray(0x30)
    struct.pack_into("<Q", header, 0x18, entries_array)
    struct.pack_into("<i", header, 0x20, len(entries))
    struct.pack_into("<i", header, 0x28, 0)
    struct.pack_into("<i", header, 0x2C, 3)
    memory.map(dictionary, header)
    raw = bytearray(0x20 + len(entries) * 0x18)
    struct.pack_into("<Q", raw, 0x18, len(entries))
    for index, (username, actor) in enumerate(entries):
        key = BASE + 0xE000 + index * 0x100
        snapshot = BASE + 0xF000 + index * 0x100
        memory.map(key, il2cpp_string(username))
        memory.map(snapshot + 0x18, struct.pack("<i", actor))
        offset = 0x20 + index * 0x18
        struct.pack_into("<iiQQ", raw, offset, index + 1, -1, key, snapshot)
    memory.map(entries_array, raw)


class PlayerStatsTests(unittest.TestCase):
    def test_match_players_resolves_local_actor_with_fusion_pet_present(self) -> None:
        memory = FakeMemory()
        match_service = BASE + 0xB000
        install_match_players(
            memory,
            match_service,
            (("happi", 1), ("fusion-pet", 2), ("Starburst", 99)),
        )

        self.assertEqual(
            read_match_local_actor_number(memory, match_service, "HAPPI"),
            1,
        )

    def test_match_players_unknown_username_does_not_guess_actor(self) -> None:
        memory = FakeMemory()
        match_service = BASE + 0xB000
        install_match_players(memory, match_service, (("happi", 1),))

        self.assertIsNone(
            read_match_local_actor_number(memory, match_service, "other")
        )

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

    def test_map_recovers_local_when_inspector_list_retains_only_boss(self) -> None:
        memory, active = memory_with_actors((99,))
        boss_pointer = BASE + 0x4000
        player_pointer = BASE + 0x5000
        memory.map(
            player_pointer,
            stats_object(7, 900, 1000, BASE + 0x3000),
        )
        install_stats_map(
            memory,
            active,
            ((7, player_pointer), (99, boss_pointer)),
        )

        values = read_active_participants(
            memory, active, expected_class=BASE + 0x3000
        )

        self.assertEqual({value.actor_number for value in values}, {7, 99})
        player = next(value for value in values if value.actor_number == 7)
        self.assertTrue(player.is_local)
        self.assertEqual(player.source, "Active.playerStatsMap/ObfuscatedInt.Value")

    def test_consistent_map_is_primary_over_inspector_list(self) -> None:
        memory, active = memory_with_actors((7, 99))
        install_stats_map(
            memory,
            active,
            ((7, BASE + 0x4000), (99, BASE + 0x5000)),
        )

        values = read_active_participants(
            memory, active, expected_class=BASE + 0x3000
        )

        self.assertTrue(
            all(
                value.source == "Active.playerStatsMap/ObfuscatedInt.Value"
                for value in values
            )
        )

    def test_map_list_pointer_conflict_fails_closed(self) -> None:
        memory, active = memory_with_actors((7, 99))
        replacement = BASE + 0xB000
        memory.map(replacement, stats_object(7, 900, 1000, BASE + 0x3000))
        install_stats_map(
            memory,
            active,
            ((7, replacement), (99, BASE + 0x5000)),
        )

        with self.assertRaisesRegex(LayoutValidationError, "pointer conflict"):
            read_active_participants(
                memory, active, expected_class=BASE + 0x3000
            )

    def test_declared_invalid_map_does_not_fall_back_to_list(self) -> None:
        memory, active = memory_with_actors((7, 99))
        # Key 8 points at an actor-7 object: a current map conflict, not an
        # excuse to reuse the serialized inspector list.
        install_stats_map(
            memory,
            active,
            ((8, BASE + 0x4000), (99, BASE + 0x5000)),
        )

        with self.assertRaisesRegex(
            LayoutValidationError, "declared Active.playerStatsMap"
        ):
            read_active_participants(
                memory, active, expected_class=BASE + 0x3000
            )

    def test_explicit_local_actor_keeps_coop_ownership_unambiguous(self) -> None:
        memory, active = memory_with_actors((7, 8, 99))

        values = read_active_participants(
            memory,
            active,
            expected_class=BASE + 0x3000,
            local_actor_number=8,
        )

        self.assertTrue(next(value for value in values if value.actor_number == 8).is_local)
        self.assertFalse(next(value for value in values if value.actor_number == 7).is_local)


if __name__ == "__main__":
    unittest.main()
