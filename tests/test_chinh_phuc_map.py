from __future__ import annotations

import struct
import unittest

from pokiguard_v2.chinh_phuc_map import (
    CHINH_PHUC_ISLAND_DISPLAY_NAMES,
    ChinhPhucMapTarget,
    ChinhPhucPlayerPrefs,
    _DIGIT_8_1280X720_ROWS,
    _DIGIT_ROWS,
    PET_CLICK_CLOSURE_SIZE,
    PET_CLICK_LOCKED_OFFSET,
    PET_CLICK_LOCKED_ORDER_OFFSET,
    PET_CLICK_MANAGER_OFFSET,
    PET_CLICK_PET_ID_OFFSET,
    PET_CLICK_REQUIRED_ATTACK_OFFSET,
    PET_CLICK_REQUIRED_ATTACK_TEXT_OFFSET,
    _decode_pet_click_closure,
    _find_pet_in_groups,
    _prefixed_dword,
    locate_hunt_order_badge,
)
from tests.test_combat_cards import FakeMemory, map_string


class _Resolver:
    def __init__(self, memory: FakeMemory) -> None:
        self.memory = memory

    def read_pointer(self, address: int) -> int:
        return struct.unpack("<Q", self.memory.read(address, 8))[0]

    def read_i32(self, address: int) -> int:
        return struct.unpack("<i", self.memory.read(address, 4))[0]

    def read_bool(self, address: int) -> bool:
        return bool(self.memory.read(address, 1)[0])


class ChinhPhucMapTests(unittest.TestCase):
    BASE = 0x0000020000000000

    @staticmethod
    def _target(selected_pet_id: int | None) -> ChinhPhucMapTarget:
        prefs = ChinhPhucPlayerPrefs(
            selected_pet_id,
            5,
            5,
            None,
            "fixture",
        )
        return ChinhPhucMapTarget(
            1289,
            "Starburst",
            5,
            "group",
            5,
            7,
            8,
            0x1000,
            0x2000,
            0x3000,
            False,
            0,
            0,
            None,
            prefs,
            True,
            (),
            1,
            4096,
            8,
        )

    def test_selected_pet_mismatch_means_selection_required_not_bad_target(self) -> None:
        different = self._target(1823)
        selected = self._target(1289)

        self.assertTrue(different.clean)
        self.assertTrue(different.selection_required)
        self.assertFalse(selected.selection_required)

    def test_b4_pet_click_closure_uses_shifted_post_island_message_fields(self) -> None:
        memory = FakeMemory()
        closure = 0x20000001000
        manager = 0x20000002000
        raw = bytearray(PET_CLICK_CLOSURE_SIZE)
        raw[PET_CLICK_LOCKED_OFFSET] = 0
        struct.pack_into("<i", raw, PET_CLICK_LOCKED_ORDER_OFFSET, 17)
        struct.pack_into("<i", raw, PET_CLICK_REQUIRED_ATTACK_OFFSET, 50_000)
        struct.pack_into("<i", raw, PET_CLICK_PET_ID_OFFSET, 1289)
        struct.pack_into("<Q", raw, PET_CLICK_REQUIRED_ATTACK_TEXT_OFFSET, 0)
        struct.pack_into("<Q", raw, PET_CLICK_MANAGER_OFFSET, manager)
        # A legacy-layout decoy at +0x1C must not become the b4 pet ID.
        struct.pack_into("<i", raw, 0x1C, 9999)
        memory.map(closure, bytes(raw))
        memory.map(manager, bytes(0xC0))

        resolver = type("Resolver", (), {"memory": memory})()
        decoded = _decode_pet_click_closure(resolver, closure)

        self.assertEqual(decoded, (False, 17, 50_000, None, manager))
        self.assertEqual(
            struct.unpack_from("<i", memory.read(closure, PET_CLICK_CLOSURE_SIZE), PET_CLICK_PET_ID_OFFSET)[0],
            1289,
        )

    def test_prefixed_dword_accepts_unity_hashed_key_and_rejects_ambiguity(self) -> None:
        self.assertEqual(
            _prefixed_dword(
                (("SelectedPetId_h238112", 1289), ("Unrelated", 5)),
                "SelectedPetId",
            ),
            1289,
        )
        self.assertIsNone(
            _prefixed_dword(
                (("SelectedPetId", 1289), ("SelectedPetId_h1", 1290)),
                "SelectedPetId",
            )
        )

    def test_server_group_id_resolves_verified_display_level_and_island(self) -> None:
        memory = FakeMemory()
        groups = self.BASE + 0x1000
        group_items = self.BASE + 0x2000
        group = self.BASE + 0x3000
        pets = self.BASE + 0x4000
        pet = self.BASE + 0x5000
        group_name = self.BASE + 0x6000
        pet_name = self.BASE + 0x7000
        array_class = self.BASE + 0x8000
        string_class = self.BASE + 0x9000
        memory.map(array_class, bytes(8))
        memory.map(string_class, bytes(8))

        list_raw = bytearray(0x20)
        struct.pack_into("<Qii", list_raw, 0x10, group_items, 1, 4)
        memory.map(groups, list_raw)
        group_items_raw = bytearray(0x28)
        struct.pack_into("<Q", group_items_raw, 0, array_class)
        struct.pack_into("<Q", group_items_raw, 0x18, 1)
        struct.pack_into("<Q", group_items_raw, 0x20, group)
        memory.map(group_items, group_items_raw)

        group_raw = bytearray(0x38)
        struct.pack_into("<i", group_raw, 0x10, 6)
        struct.pack_into("<Q", group_raw, 0x18, group_name)
        struct.pack_into("<Q", group_raw, 0x20, pets)
        memory.map(group, group_raw)
        map_string(memory, group_name, "Tam giới Tinh", string_class)

        pets_raw = bytearray(0x28)
        struct.pack_into("<Q", pets_raw, 0, array_class)
        struct.pack_into("<Q", pets_raw, 0x18, 1)
        struct.pack_into("<Q", pets_raw, 0x20, pet)
        memory.map(pets, pets_raw)
        pet_raw = bytearray(0x50)
        struct.pack_into("<i", pet_raw, 0x10, 1289)
        struct.pack_into("<Q", pet_raw, 0x18, pet_name)
        struct.pack_into("<i", pet_raw, 0x20, 10)
        struct.pack_into("<i", pet_raw, 0x24, 73)
        pet_raw[0x35] = 0
        memory.map(pet, pet_raw)
        map_string(memory, pet_name, "Starburst", string_class)

        metadata = _find_pet_in_groups(_Resolver(memory), groups, 1289)

        self.assertIsNotNone(metadata)
        assert metadata is not None
        self.assertEqual(metadata.boss_level, 10)
        self.assertEqual(metadata.boss_display_level, 73)
        self.assertEqual(metadata.group_id, 6)
        self.assertEqual(metadata.group_name, "Tam giới Tinh")
        self.assertEqual(metadata.island_name, "Đảo rồng")
        self.assertEqual(CHINH_PHUC_ISLAND_DISPLAY_NAMES[18], "Đảo Liên Minh")

    def test_badge_locator_fails_closed_for_invalid_or_unsupported_capture(self) -> None:
        invalid = locate_hunt_order_badge(b"", 1280, 710, 8)
        self.assertFalse(invalid.found)
        self.assertEqual(invalid.reason, "invalid_client_capture")

        rgb = bytes(640 * 360 * 3)
        unsupported = locate_hunt_order_badge(rgb, 640, 360, 10)
        self.assertFalse(unsupported.found)
        self.assertEqual(
            unsupported.reason, "hunt_order_visual_template_unsupported"
        )

    def test_badge_locator_accepts_one_clear_runtime_derived_order(self) -> None:
        width, height = 1280, 710
        pixels = bytearray(width * height * 3)
        center_x, center_y = 640, 354

        def paint(x: int, y: int, color: tuple[int, int, int]) -> None:
            offset = (y * width + x) * 3
            pixels[offset : offset + 3] = bytes(color)

        # Brown radial signature of the game's hunt-order medallion.
        for delta_x, delta_y in (
            (-20, 0),
            (20, 0),
            (0, -20),
            (0, 20),
            (-14, -14),
            (14, -14),
            (-14, 14),
            (14, 14),
        ):
            for y in range(center_y + delta_y - 2, center_y + delta_y + 3):
                for x in range(center_x + delta_x - 2, center_x + delta_x + 3):
                    paint(x, y, (100, 45, 10))

        # Render the normalized number_A_8 evidence at 3x scale.
        left, top = center_x - 12, center_y - 18
        for row, bits in enumerate(_DIGIT_ROWS[8]):
            for column, bit in enumerate(bits):
                if bit != "#":
                    continue
                for y in range(top + row * 3, top + (row + 1) * 3):
                    for x in range(left + column * 3, left + (column + 1) * 3):
                        paint(x, y, (255, 170, 20))

        located = locate_hunt_order_badge(bytes(pixels), width, height, 8)
        self.assertTrue(located.found, located)
        self.assertEqual(located.reason, "single_runtime_derived_hunt_order_badge")
        self.assertIsNotNone(located.normalized_point)
        point = located.normalized_point
        self.assertAlmostEqual(point[0], center_x / width, delta=0.01)  # type: ignore[index]
        self.assertAlmostEqual(point[1], center_y / height, delta=0.01)  # type: ignore[index]

    def test_badge_locator_accepts_live_1280x720_digit_eight_variant(self) -> None:
        width, height = 1280, 720
        pixels = bytearray(width * height * 3)
        center_x, center_y = 640, 360

        def paint(x: int, y: int, color: tuple[int, int, int]) -> None:
            offset = (y * width + x) * 3
            pixels[offset : offset + 3] = bytes(color)

        for delta_x, delta_y in (
            (-20, 0),
            (20, 0),
            (0, -20),
            (0, 20),
            (-14, -14),
            (14, -14),
            (-14, 14),
            (14, 14),
        ):
            for y in range(center_y + delta_y - 2, center_y + delta_y + 3):
                for x in range(center_x + delta_x - 2, center_x + delta_x + 3):
                    paint(x, y, (100, 45, 10))

        left, top = center_x - 12, center_y - 18
        for row, bits in enumerate(_DIGIT_8_1280X720_ROWS):
            for column, bit in enumerate(bits):
                if bit != "#":
                    continue
                for y in range(top + row * 3, top + (row + 1) * 3):
                    for x in range(left + column * 3, left + (column + 1) * 3):
                        paint(x, y, (255, 170, 20))

        located = locate_hunt_order_badge(bytes(pixels), width, height, 8)
        self.assertTrue(located.found, located)
        self.assertEqual(located.metrics["digitScore"], 0)


if __name__ == "__main__":
    unittest.main()
