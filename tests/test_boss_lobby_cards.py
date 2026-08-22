from __future__ import annotations

import struct
from pathlib import Path
import sys
import unittest


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
if str(SRC_ROOT) not in sys.path:
    sys.path.insert(0, str(SRC_ROOT))

from pokiguard_v2.boss_lobby_runtime import (  # noqa: E402
    MANAGER_ROOM_SELECTED_CARDS_OFFSET,
    ROOM_CARDS_OFFSET,
    _read_lobby_card_loadout,
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


class FakeResolver:
    def __init__(self, memory: FakeMemory) -> None:
        self.memory = memory

    def read_pointer(self, address: int) -> int:
        return struct.unpack("<Q", self.memory.read(address, 8))[0]


def map_string(memory: FakeMemory, address: int, value: str, klass: int) -> None:
    raw = bytearray(0x14 + len(value) * 2)
    struct.pack_into("<Q", raw, 0, klass)
    struct.pack_into("<i", raw, 0x10, len(value))
    raw[0x14:] = value.encode("utf-16-le")
    memory.map(address, raw)


def map_card_data(
    memory: FakeMemory,
    address: int,
    *,
    klass: int,
    string_klass: int,
    data_id: int,
    card_id: int,
    name: str,
    element_type: str,
) -> None:
    name_address = address + 0x1000
    element_address = address + 0x2000
    map_string(memory, name_address, name, string_klass)
    map_string(memory, element_address, element_type, string_klass)
    raw = bytearray(0x9C)
    struct.pack_into("<Q", raw, 0, klass)
    struct.pack_into("<qq", raw, 0x10, data_id, card_id)
    struct.pack_into("<Q", raw, 0x20, name_address)
    struct.pack_into("<Q", raw, 0x30, element_address)
    struct.pack_into("<q", raw, 0x48, 160)
    struct.pack_into("<i", raw, 0x80, 160)
    memory.map(address, raw)


def map_list(
    memory: FakeMemory,
    list_address: int,
    array_address: int,
    values: tuple[int, ...],
    *,
    array_class: int,
) -> None:
    raw_list = bytearray(0x20)
    struct.pack_into("<Q", raw_list, 0x10, array_address)
    struct.pack_into("<ii", raw_list, 0x18, len(values), 7)
    memory.map(list_address, raw_list)
    raw_array = bytearray(0x20 + len(values) * 8)
    struct.pack_into("<Q", raw_array, 0, array_class)
    struct.pack_into("<Q", raw_array, 0x18, len(values))
    if values:
        struct.pack_into(f"<{len(values)}Q", raw_array, 0x20, *values)
    memory.map(array_address, raw_array)


class BossLobbyCardTests(unittest.TestCase):
    BASE = 0x0000021000000000

    def test_preentry_loadout_reads_both_sources_and_finds_attack(self) -> None:
        memory = FakeMemory()
        resolver = FakeResolver(memory)
        manager = self.BASE
        room = self.BASE + 0x1000
        manager_list = self.BASE + 0x2000
        room_list = self.BASE + 0x3000
        manager_array = self.BASE + 0x4000
        room_array = self.BASE + 0x5000
        data_class = self.BASE + 0x6000
        string_class = self.BASE + 0x7000
        array_class = self.BASE + 0x8000
        cards = (
            self.BASE + 0x10000,
            self.BASE + 0x20000,
            self.BASE + 0x30000,
        )
        for pointer in (data_class, string_class, array_class):
            memory.map(pointer, bytearray(8))
        for index, (name, element) in enumerate(
            (("Tan cong", "ATTACK"), ("Ho tro", "BUFF"), ("Khien", "SHIELD"))
        ):
            map_card_data(
                memory,
                cards[index],
                klass=data_class,
                string_klass=string_class,
                data_id=9000 + index,
                card_id=70 + index,
                name=name,
                element_type=element,
            )
        manager_raw = bytearray(0x110)
        struct.pack_into("<Q", manager_raw, MANAGER_ROOM_SELECTED_CARDS_OFFSET, manager_list)
        memory.map(manager, manager_raw)
        room_raw = bytearray(0x58)
        struct.pack_into("<Q", room_raw, ROOM_CARDS_OFFSET, room_list)
        memory.map(room, room_raw)
        map_list(memory, manager_list, manager_array, cards, array_class=array_class)
        map_list(memory, room_list, room_array, cards, array_class=array_class)

        loadout = _read_lobby_card_loadout(resolver, manager, room)

        self.assertEqual(loadout.card_count, 3)
        self.assertEqual(loadout.attack_card_count, 1)
        self.assertTrue(loadout.sources_agree)
        self.assertEqual(len(loadout.identity), 3)
        self.assertEqual(loadout.reasons, ())

        # A process/lobby reset can empty the UI-owned selection while the
        # RoomDTO retains its prior loadout. The stale RoomDTO must remain
        # telemetry and must not be promoted to a live next-combat claim.
        map_list(memory, manager_list, manager_array, (), array_class=array_class)
        stale = _read_lobby_card_loadout(resolver, manager, room)
        self.assertEqual(stale.card_count, 0)
        self.assertEqual(stale.attack_card_count, 0)
        self.assertEqual(stale.manager_attack_card_count, 0)
        self.assertEqual(stale.room_attack_card_count, 1)
        self.assertFalse(stale.sources_agree)


if __name__ == "__main__":
    unittest.main()
