from __future__ import annotations

import struct
from pathlib import Path
import sys
import unittest


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
if str(SRC_ROOT) not in sys.path:
    sys.path.insert(0, str(SRC_ROOT))

from pokiguard_v2.combat_cards import (  # noqa: E402
    BOARD_CARDS_IN_HAND_OFFSET,
    BOARD_SELECTED_CARDS_OFFSET,
    FUSION_CARD_UI_READ_SIZE,
    SELECTABLE_INTERACTABLE_OFFSET,
    read_cards_in_hand_anchors,
    read_selected_card_data_addresses,
    read_combat_card,
    read_fusion_card_ui,
    read_fusion_state,
    validate_fusion_card_ui_hits,
)
from pokiguard_v2.il2cpp_layout import LayoutValidationError  # noqa: E402


class FakeMemory:
    def __init__(self) -> None:
        self.bytes: dict[int, int] = {}

    def map(self, address: int, data: bytes | bytearray) -> None:
        self.bytes.update({address + index: value for index, value in enumerate(data)})

    def read(self, address: int, size: int) -> bytes:
        return bytes(self.bytes[address + index] for index in range(size))

    def is_readable(self, address: int, size: int) -> bool:
        return size > 0 and all(address + index in self.bytes for index in range(size))


def map_string(memory: FakeMemory, address: int, value: str, class_pointer: int) -> None:
    raw = bytearray(0x14 + len(value) * 2)
    struct.pack_into("<Q", raw, 0, class_pointer)
    struct.pack_into("<i", raw, 0x10, len(value))
    raw[0x14:] = value.encode("utf-16-le")
    memory.map(address, raw)


class CombatCardTests(unittest.TestCase):
    BASE = 0x0000020000000000

    def test_cards_in_hand_are_stable_region_anchors_only(self) -> None:
        memory = FakeMemory()
        board = self.BASE
        card_list = self.BASE + 0x1000
        items = self.BASE + 0x2000
        game_objects = (self.BASE + 0x3000, self.BASE + 0x4000)
        board_raw = bytearray(BOARD_CARDS_IN_HAND_OFFSET + 8)
        struct.pack_into("<Q", board_raw, BOARD_CARDS_IN_HAND_OFFSET, card_list)
        memory.map(board, board_raw)
        list_raw = bytearray(0x20)
        struct.pack_into("<Qii", list_raw, 0x10, items, len(game_objects), 7)
        memory.map(card_list, list_raw)
        array_raw = bytearray(0x20 + len(game_objects) * 8)
        struct.pack_into("<Q", array_raw, 0x18, len(game_objects))
        struct.pack_into("<2Q", array_raw, 0x20, *game_objects)
        memory.map(items, array_raw)
        for value in game_objects:
            memory.map(value, bytearray(0x18))

        self.assertEqual(
            read_cards_in_hand_anchors(memory, board), game_objects
        )

        struct.pack_into("<i", list_raw, 0x18, 17)
        memory.map(card_list, list_raw)
        with self.assertRaises(LayoutValidationError):
            read_cards_in_hand_anchors(memory, board)

    def test_selected_cards_preserve_stable_card_data_creation_order(self) -> None:
        memory = FakeMemory()
        board = self.BASE
        selected_list = self.BASE + 0x5000
        items = self.BASE + 0x6000
        card_data = (self.BASE + 0x7000, self.BASE + 0x8000, self.BASE + 0x9000)
        board_raw = bytearray(BOARD_SELECTED_CARDS_OFFSET + 8)
        struct.pack_into("<Q", board_raw, BOARD_SELECTED_CARDS_OFFSET, selected_list)
        memory.map(board, board_raw)
        list_raw = bytearray(0x20)
        struct.pack_into("<Qii", list_raw, 0x10, items, len(card_data), 3)
        memory.map(selected_list, list_raw)
        array_raw = bytearray(0x20 + len(card_data) * 8)
        struct.pack_into("<Q", array_raw, 0x18, len(card_data))
        struct.pack_into("<3Q", array_raw, 0x20, *card_data)
        memory.map(items, array_raw)
        for value in card_data:
            memory.map(value, bytearray(0x9C))

        self.assertEqual(
            read_selected_card_data_addresses(memory, board),
            card_data,
        )

    def test_fusion_success_and_turn_lock_are_direct_fields(self) -> None:
        memory = FakeMemory()
        service = self.BASE
        skill_card = self.BASE + 0x1000
        drop_reason = self.BASE + 0x2000
        string_class = self.BASE + 0x3000
        raw = bytearray(0x88)
        struct.pack_into("<i", raw, 0x40, 19)
        raw[0x54] = 1
        struct.pack_into("<ii", raw, 0x58, 25, 30)
        raw[0x60] = 1
        struct.pack_into("<i", raw, 0x64, 19)
        struct.pack_into("<qqQ", raw, 0x68, 101, 202, skill_card)
        struct.pack_into("<Q", raw, 0x80, drop_reason)
        memory.map(service, raw)
        memory.map(skill_card, bytearray(0x20))
        memory.map(string_class, bytearray(8))
        map_string(memory, drop_reason, "server_drop", string_class)

        state = read_fusion_state(memory, service)
        self.assertTrue(state.used_successfully)
        self.assertTrue(state.locked_this_turn)
        self.assertFalse(state.candidate_available)
        self.assertEqual((state.mana_cost, state.stat_percent), (25, 30))
        self.assertEqual(state.drop_reason, "server_drop")

    def test_fusion_ui_requires_live_button_and_reads_interactable(self) -> None:
        memory = FakeMemory()
        ui = self.BASE + 0x11000
        ui_class = self.BASE + 0x12000
        ui_native = self.BASE + 0x13000
        button = self.BASE + 0x14000
        button_native = self.BASE + 0x15000
        for pointer in (ui_class, ui_native, button_native):
            memory.map(pointer, bytearray(8))
        button_raw = bytearray(SELECTABLE_INTERACTABLE_OFFSET + 1)
        struct.pack_into("<Q", button_raw, 0x10, button_native)
        button_raw[SELECTABLE_INTERACTABLE_OFFSET] = 1
        memory.map(button, button_raw)
        ui_raw = bytearray(FUSION_CARD_UI_READ_SIZE)
        struct.pack_into("<Q", ui_raw, 0, ui_class)
        struct.pack_into("<Q", ui_raw, 0x10, ui_native)
        struct.pack_into("<Q", ui_raw, 0x58, button)
        struct.pack_into("<f", ui_raw, 0x60, 123.5)
        struct.pack_into("<q", ui_raw, 0x68, 218166)
        memory.map(ui, ui_raw)

        state = read_fusion_card_ui(memory, ui, expected_class=ui_class)
        self.assertTrue(state.interactable)
        self.assertEqual(state.bound_pet_id, 218166)
        self.assertEqual(
            tuple(
                item.address
                for item in validate_fusion_card_ui_hits(
                    memory,
                    (ui,),
                    expected_class=ui_class,
                    expected_bound_pet_ids=(218166,),
                )
            ),
            (ui,),
        )
        self.assertEqual(
            validate_fusion_card_ui_hits(
                memory,
                (ui,),
                expected_class=ui_class,
                expected_bound_pet_ids=(1845,),
            ),
            (),
        )

        button_raw[SELECTABLE_INTERACTABLE_OFFSET] = 0
        memory.map(button, button_raw)
        self.assertFalse(
            read_fusion_card_ui(memory, ui, expected_class=ui_class).interactable
        )

    def test_attack_card_uses_current_board_active_and_ui_interactable(self) -> None:
        memory = FakeMemory()
        card_ui = self.BASE + 0x2000
        card_class = self.BASE + 0x3000
        card_data = self.BASE + 0x4000
        button = self.BASE + 0x5000
        board = self.BASE + 0x6000
        active = self.BASE + 0x7000
        native = self.BASE + 0x8000
        string_class = self.BASE + 0x9000
        name = self.BASE + 0xA000
        element = self.BASE + 0xB000
        skill = self.BASE + 0xC000
        data_class = self.BASE + 0xD000
        description = self.BASE + 0xE000

        for pointer in (card_class, native, string_class, data_class):
            memory.map(pointer, bytearray(8))
        map_string(memory, name, "Chuong", string_class)
        map_string(memory, description, "Exact test metadata", string_class)
        map_string(memory, element, "ATTACK", string_class)
        map_string(memory, skill, "DOT_SKILL", string_class)

        data_raw = bytearray(0x9C)
        struct.pack_into("<Q", data_raw, 0, data_class)
        struct.pack_into("<qq", data_raw, 0x10, 9001, 73)
        struct.pack_into("<Q", data_raw, 0x20, name)
        struct.pack_into("<Q", data_raw, 0x28, description)
        struct.pack_into("<Q", data_raw, 0x30, element)
        struct.pack_into("<Q", data_raw, 0x78, skill)
        struct.pack_into("<iii", data_raw, 0x80, 20, 0, 1)
        data_raw[0x8C] = 1
        memory.map(card_data, data_raw)

        button_raw = bytearray(SELECTABLE_INTERACTABLE_OFFSET + 1)
        button_raw[SELECTABLE_INTERACTABLE_OFFSET] = 1
        memory.map(button, button_raw)

        ui_raw = bytearray(0x79)
        struct.pack_into("<Q", ui_raw, 0, card_class)
        struct.pack_into("<Q", ui_raw, 0x10, native)
        struct.pack_into("<QQQQ", ui_raw, 0x20, card_data, button, board, active)
        ui_raw[0x41] = 1
        struct.pack_into("<i", ui_raw, 0x44, 12)
        memory.map(card_ui, ui_raw)

        card_data_cache = {}
        state = read_combat_card(
            memory,
            card_ui,
            expected_class=card_class,
            expected_board=board,
            expected_active=active,
            card_data_cache=card_data_cache,
        )
        self.assertTrue(state.is_attack_card)
        self.assertTrue(state.ui_interactable)
        self.assertTrue(state.has_used_this_turn)
        self.assertEqual((state.card_id, state.last_turn_used), (73, 12))
        self.assertEqual(state.description, "Exact test metadata")

        # Immutable CardData strings/costs are decoded once per combat while
        # live CardUI flags/Button state continue to be read every time.
        struct.pack_into("<Q", data_raw, 0x30, 0)
        memory.map(card_data, data_raw)
        button_raw[SELECTABLE_INTERACTABLE_OFFSET] = 0
        memory.map(button, button_raw)
        cached = read_combat_card(
            memory,
            card_ui,
            expected_class=card_class,
            expected_board=board,
            expected_active=active,
            card_data_cache=card_data_cache,
        )
        self.assertEqual(cached.element_type, "ATTACK")
        self.assertFalse(cached.ui_interactable)

        with self.assertRaises(LayoutValidationError):
            read_combat_card(
                memory,
                card_ui,
                expected_class=card_class,
                expected_board=board + 8,
                expected_active=active,
            )


if __name__ == "__main__":
    unittest.main()
