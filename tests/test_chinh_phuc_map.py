from __future__ import annotations

import unittest

from pokiguard_v2.chinh_phuc_map import (
    ChinhPhucMapTarget,
    ChinhPhucPlayerPrefs,
    _DIGIT_8_1280X720_ROWS,
    _DIGIT_ROWS,
    _prefixed_dword,
    locate_hunt_order_badge,
)


class ChinhPhucMapTests(unittest.TestCase):
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
