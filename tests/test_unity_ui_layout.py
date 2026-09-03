from __future__ import annotations

import unittest

from pokiguard_v2.boss_entry_ui import locate_chinh_phuc_attack_card_toggle
from pokiguard_v2.gameplay_ui import GameplayControl, locate_gameplay_control
from pokiguard_v2.postmatch_ui import locate_result_confirm
from pokiguard_v2.recovery_ui import locate_confirm_leave
from pokiguard_v2.unity_ui_layout import (
    transform_for_capture,
    transform_for_client,
)
from pokiguard_v2.win32_input import (
    BoardCalibration,
    ClientGeometry,
    map_swap_to_pixels,
)


def _fill(
    rgb: bytearray,
    width: int,
    height: int,
    rect: tuple[float, float, float, float],
    color: tuple[int, int, int],
) -> None:
    left = max(0, round(rect[0] * width))
    top = max(0, round(rect[1] * height))
    right = min(width, round(rect[2] * width))
    bottom = min(height, round(rect[3] * height))
    for y in range(top, bottom):
        for x in range(left, right):
            offset = (y * width + x) * 3
            rgb[offset : offset + 3] = bytes(color)


class UnityUiLayoutTests(unittest.TestCase):
    def test_current_ui_canvas_is_height_scaled_and_left_anchored(self) -> None:
        transform = transform_for_client(1280, 640)
        self.assertEqual(transform.mode, "POKIGUARD_2_1")
        self.assertAlmostEqual(transform.point((0.5, 0.5))[0], 4 / 9)
        self.assertAlmostEqual(transform.point((0.5, 0.5))[1], 0.5)

    def test_live_174_board_evidence_keeps_rightmost_column_on_board(self) -> None:
        """Regression for the first live 1.7.4 swap (2026-09-01 attempt 001).

        The opening screenshot placed column 7 near client x=815.  The old
        height-scaled transform sent x=732 (column 5), so a solver-legal Shield
        match was clicked as a non-match.  The accepted calibration must keep
        the rightmost click inside the observed column-7 tile.
        """

        geometry = ClientGeometry(425, 178, 1280, 640)
        plan = map_swap_to_pixels(
            (0, 7),
            (1, 7),
            BoardCalibration(),
            geometry,
        )
        self.assertEqual(plan.first.client_x, 814)
        self.assertEqual(plan.first.client_x, plan.second.client_x)

    def test_live_174_lower_board_centres_match_attempt_001_evidence(self) -> None:
        """The second live retry selected col 5 across screen rows 6 and 7."""

        plan = map_swap_to_pixels(
            (6, 5),
            (7, 5),
            BoardCalibration(),
            ClientGeometry(609, 285, 1280, 640),
        )
        self.assertEqual(
            (plan.first.client_x, plan.first.client_y),
            (714, 405),
        )
        self.assertEqual(
            (plan.second.client_x, plan.second.client_y),
            (714, 455),
        )

    def test_legacy_preflight_letterbox_is_detected_from_pixels(self) -> None:
        width, height = 1280, 720
        rgb = bytearray(width * height * 3)
        _fill(rgb, width, height, (0.0, 40 / 720, 1.0, 680 / 720), (20, 80, 140))
        transform = transform_for_capture(bytes(rgb), width, height)
        self.assertEqual(transform.mode, "POKIGUARD_2_1_LETTERBOXED")
        self.assertEqual(transform.viewport_top, 40)
        self.assertEqual(transform.viewport_height, 640)

    def test_lobby_attack_visual_uses_current_canvas_position(self) -> None:
        width, height = 1280, 640
        rgb = bytearray(bytes((18, 52, 105)) * width * height)
        transform = transform_for_client(width, height)
        center_x = 0.284 + 0.072 * 3
        _fill(
            rgb,
            width,
            height,
            transform.rect((center_x - 0.030, 0.715, center_x + 0.030, 0.760)),
            (30, 175, 225),
        )
        _fill(
            rgb,
            width,
            height,
            transform.rect((center_x - 0.030, 0.760, center_x + 0.030, 0.860)),
            (225, 105, 35),
        )
        _fill(
            rgb,
            width,
            height,
            transform.rect((center_x - 0.012, 0.775, center_x + 0.003, 0.845)),
            (45, 35, 25),
        )
        location = locate_chinh_phuc_attack_card_toggle(
            bytes(rgb),
            width,
            height,
            room_card_count=4,
            attack_card_index=3,
        )
        self.assertTrue(location.found, location)
        self.assertAlmostEqual(location.normalized_point[0], 4 / 9, places=3)  # type: ignore[index]
        self.assertEqual(location.metrics["layoutMode"], "POKIGUARD_2_1")

    def test_combat_card_visual_and_click_use_complete_current_viewport(self) -> None:
        width, height = 1280, 640
        rgb = bytearray(bytes((18, 52, 105)) * width * height)
        transform = transform_for_client(width, height)
        reference_x = 0.500 + 0.058 / 2
        _fill(
            rgb,
            width,
            height,
            transform.viewport_rect(
                (reference_x - 0.030, 0.754, reference_x + 0.030, 0.908)
            ),
            (230, 80, 30),
        )
        location = locate_gameplay_control(
            bytes(rgb),
            width,
            height,
            GameplayControl.CAST_ATTACK,
            slot_index=1,
            slot_count=2,
        )
        self.assertTrue(location.found, location)
        self.assertAlmostEqual(
            location.normalized_point[0],  # type: ignore[index]
            transform.viewport_point((reference_x, 0.824))[0],
        )
        self.assertEqual(location.metrics["layoutSpace"], "FULL_VIEWPORT")

    def test_board_mapping_bypasses_narrow_ui_canvas_transform(self) -> None:
        geometry = ClientGeometry(10, 20, 1280, 640)
        plan = map_swap_to_pixels(
            (0, 0),
            (0, 1),
            BoardCalibration(),
            geometry,
        )
        self.assertEqual(plan.first.client_x, int(0.3620 * 1279))
        self.assertEqual(plan.first.client_y, int(0.1625 * 639))

    def test_recovery_and_postmatch_locators_accept_scaled_current_canvas(self) -> None:
        width, height = 1280, 640
        transform = transform_for_client(width, height)

        recovery = bytearray(bytes((20, 80, 130)) * width * height)
        _fill(recovery, width, height, transform.rect((0.32, 0.60, 0.45, 0.675)), (230, 120, 25))
        _fill(recovery, width, height, transform.rect((0.55, 0.60, 0.68, 0.675)), (230, 120, 25))
        self.assertTrue(locate_confirm_leave(bytes(recovery), width, height).found)

        result = bytearray(width * height * 3)
        _fill(result, width, height, transform.rect((0.175, 0.10, 0.825, 0.78)), (20, 120, 180))
        _fill(result, width, height, transform.rect((0.44, 0.84, 0.56, 0.92)), (245, 150, 20))
        located = locate_result_confirm(bytes(result), width, height)
        self.assertTrue(located.found, located)


if __name__ == "__main__":
    unittest.main()
