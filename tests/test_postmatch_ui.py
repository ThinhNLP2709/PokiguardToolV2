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


def current_wide_result_rgb(
    *,
    banner: bool = True,
    button: bool = True,
    second_button: bool = False,
) -> tuple[bytes, int, int]:
    width = 1000
    height = 500
    rgb = bytearray(bytes((28, 55, 80)) * width * height)

    def fill(
        left: int,
        top: int,
        right: int,
        bottom: int,
        color: tuple[int, int, int],
    ) -> None:
        for y in range(top, bottom):
            for x in range(left, right):
                offset = (y * width + x) * 3
                rgb[offset : offset + 3] = bytes(color)

    if banner:
        fill(110, 5, 890, 110, (235, 120, 25))
    if button:
        if second_button:
            fill(360, 435, 440, 472, (25, 145, 230))
            fill(560, 435, 640, 472, (25, 145, 230))
        else:
            fill(455, 435, 545, 472, (25, 145, 230))
    return bytes(rgb), width, height


class PostmatchUiTests(unittest.TestCase):
    def test_locates_current_wide_orange_banner_and_blue_confirm(self) -> None:
        rgb, width, height = current_wide_result_rgb()
        location = locate_result_confirm(rgb, width, height)
        self.assertTrue(location.found, location)
        self.assertEqual(
            location.reason,
            "single_blue_button_below_orange_result_banner",
        )
        self.assertEqual(
            location.metrics["layoutVariant"],
            "POKIGUARD_1_7_4_WIDE_RESULT",
        )
        self.assertAlmostEqual(location.normalized_point[0], 0.5, places=2)  # type: ignore[index]
        self.assertTrue(0.86 <= location.normalized_point[1] <= 0.94)  # type: ignore[index]

    def test_current_wide_result_requires_both_unique_layout_anchors(self) -> None:
        for kwargs in (
            {"banner": False},
            {"button": False},
            {"second_button": True},
        ):
            with self.subTest(kwargs=kwargs):
                rgb, width, height = current_wide_result_rgb(**kwargs)
                self.assertFalse(
                    locate_result_confirm(rgb, width, height).found
                )

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

    def test_late_modal_can_be_proven_after_initial_animation_frames(self) -> None:
        missing = locate_result_confirm(result_modal_rgb(panel=False), WIDTH, HEIGHT)
        visible = locate_result_confirm(result_modal_rgb(), WIDTH, HEIGHT)
        rolling: list[PostmatchUiLocation] = []
        proofs = []
        for location in (missing, missing, missing, visible, visible, visible):
            rolling.append(location)
            rolling = rolling[-3:]
            proofs.append(
                prove_stable_result_confirm(rolling, required_frames=3)
            )

        self.assertFalse(proofs[2].proven)
        self.assertTrue(proofs[-1].proven, proofs[-1])


if __name__ == "__main__":
    unittest.main()
