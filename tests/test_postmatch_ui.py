"""Offline visual-safety tests for the combat result modal."""

from __future__ import annotations

import unittest

from pokiguard_v2.postmatch_ui import (
    PostmatchUiLocation,
    locate_result_confirm,
    prove_stable_result_confirm,
)


WIDTH = 800
HEIGHT = 450


def result_modal_rgb(*, second_button: bool = False, panel: bool = True) -> bytes:
    rgb = bytearray(WIDTH * HEIGHT * 3)

    def fill(left: int, top: int, right: int, bottom: int, color: tuple[int, int, int]) -> None:
        for y in range(top, bottom):
            for x in range(left, right):
                offset = (y * WIDTH + x) * 3
                rgb[offset : offset + 3] = bytes(color)

    if panel:
        fill(140, 45, 680, 350, (20, 120, 180))
    fill(350, 375, 450, 415, (245, 150, 20))
    if second_button:
        fill(245, 375, 330, 415, (245, 150, 20))
    return bytes(rgb)


class PostmatchUiTests(unittest.TestCase):
    def test_locates_single_result_confirmation_below_large_blue_panel(self) -> None:
        location = locate_result_confirm(result_modal_rgb(), WIDTH, HEIGHT)
        self.assertTrue(location.found, location)
        self.assertIsNotNone(location.normalized_point)
        assert location.normalized_point is not None
        self.assertAlmostEqual(location.normalized_point[0], 0.5, places=2)
        self.assertTrue(0.80 <= location.normalized_point[1] <= 0.94)

    def test_rejects_button_without_result_panel(self) -> None:
        location = locate_result_confirm(result_modal_rgb(panel=False), WIDTH, HEIGHT)
        self.assertFalse(location.found)
        self.assertEqual(location.reason, "expected_exactly_one_large_blue_result_panel")

    def test_rejects_ambiguous_two_button_layout(self) -> None:
        location = locate_result_confirm(result_modal_rgb(second_button=True), WIDTH, HEIGHT)
        self.assertFalse(location.found)
        self.assertEqual(location.reason, "expected_exactly_one_orange_result_button")

    def test_stability_requires_multiple_matching_high_confidence_frames(self) -> None:
        location = locate_result_confirm(result_modal_rgb(), WIDTH, HEIGHT)
        proof = prove_stable_result_confirm([location, location, location], required_frames=3)
        self.assertTrue(proof.proven, proof)

        moved = PostmatchUiLocation(
            location.control,
            True,
            (0.58, 0.88),
            location.confidence,
            location.reason,
        )
        rejected = prove_stable_result_confirm([location, moved], required_frames=2)
        self.assertFalse(rejected.proven)
        self.assertEqual(rejected.reason, "result_modal_control_moved")


if __name__ == "__main__":
    unittest.main()
