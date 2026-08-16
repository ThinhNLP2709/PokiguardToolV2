from __future__ import annotations

from pathlib import Path
from types import SimpleNamespace
import unittest

from pokiguard_v2.boss_entry import (
    BossCandidate,
    BossTargetIdentity,
    FarmTarget,
    TargetResolutionStatus,
    TargetSelectionState,
    normalize_exact_name,
    resolve_target,
)
from pokiguard_v2.boss_entry_ui import locate_chinh_phuc_start
from pokiguard_v2.win32_screenshot import read_png_rgb
from tools.boss_entry import _jsonable, _retryable_board_messages


V1_SCREENSHOTS = Path(r"D:\PokiguardAuto\GameScreenShoot")


def candidate(index: int, boss_id: str, name: str) -> BossCandidate:
    return BossCandidate(
        index,
        BossTargetIdentity(
            boss_id,
            name,
            room_id="Coop_fixture",
            pet_id=int(boss_id),
            source="fixture",
        ),
        TargetSelectionState.SELECTED,
        True,
        True,
        entry_control_address=0x100000 + index * 0x100,
    )


def synthetic_button_image(
    rects: tuple[tuple[float, float, float, float], ...],
    *,
    width: int = 960,
    height: int = 540,
) -> bytes:
    rgb = bytearray(bytes((18, 52, 105)) * width * height)

    def set_pixel(x: int, y: int, color: tuple[int, int, int]) -> None:
        offset = (y * width + x) * 3
        rgb[offset : offset + 3] = bytes(color)

    for left_n, top_n, right_n, bottom_n in rects:
        left, right = round(left_n * width), round(right_n * width)
        top, bottom = round(top_n * height), round(bottom_n * height)
        thickness = 6
        for y in range(top, bottom):
            for x in range(left, right):
                if (
                    x < left + thickness
                    or x >= right - thickness
                    or y < top + thickness
                    or y >= bottom - thickness
                ):
                    set_pixel(x, y, (28, 225, 250))
        text_left, text_right = left + (right - left) // 4, right - (right - left) // 4
        text_top = (top + bottom) // 2 - 5
        for y in range(text_top, text_top + 10):
            for x in range(text_left, text_right):
                set_pixel(x, y, (250, 170, 45))
    return bytes(rgb)


class BossEntryLoggingTests(unittest.TestCase):
    def test_binary_capture_is_summarized_instead_of_serialized(self) -> None:
        self.assertEqual(_jsonable(b"rgb"), {"byteLength": 3})
        self.assertEqual(_jsonable(bytearray(b"rgba")), {"byteLength": 4})

    def test_incomplete_board_dto_remains_retryable_until_decode_succeeds(self) -> None:
        start = SimpleNamespace(
            address=0x1000,
            event_type="MATCH_START",
            payload_address=0x2000,
        )
        move = SimpleNamespace(
            address=0x3000,
            event_type="MATCH_MOVE_RES",
            payload_address=0x4000,
        )
        unrelated = SimpleNamespace(
            address=0x5000,
            event_type="MATCH_TURN_END",
            payload_address=0x6000,
        )
        observation = SimpleNamespace(board_messages=(start, move, unrelated))

        first = _retryable_board_messages(observation, set())
        self.assertEqual(first, (start, move))
        # A failed decode does not mutate the successful-address set, so the
        # same still-live MATCH_START pointer must be retried next scan.
        self.assertEqual(_retryable_board_messages(observation, set()), first)
        self.assertEqual(
            _retryable_board_messages(observation, {start.address}),
            (move,),
        )


class BossTargetResolutionTests(unittest.TestCase):
    def test_single_exact_id_target(self) -> None:
        result = resolve_target(
            FarmTarget(boss_id="1289"),
            (candidate(0, "1289", "Starburst"), candidate(1, "1300", "Other")),
        )
        self.assertEqual(result.status, TargetResolutionStatus.RESOLVED)
        self.assertEqual(result.candidate.identity.boss_name, "Starburst")

    def test_target_missing(self) -> None:
        result = resolve_target(
            FarmTarget(boss_name="Starburst"),
            (candidate(0, "1300", "Other"),),
        )
        self.assertEqual(result.status, TargetResolutionStatus.MISSING)
        self.assertIsNone(result.candidate)

    def test_multiple_exact_matches_are_ambiguous(self) -> None:
        result = resolve_target(
            FarmTarget(boss_id="1289"),
            (candidate(0, "1289", "Starburst"), candidate(1, "1289", "Clone")),
        )
        self.assertEqual(result.status, TargetResolutionStatus.AMBIGUOUS)
        self.assertEqual(len(result.matches), 2)

    def test_name_normalization_is_exact_nfc_casefold_only(self) -> None:
        self.assertEqual(normalize_exact_name("  TIẾN HÓA  "), "tiến hóa")
        result = resolve_target(
            FarmTarget(boss_name="STARburst"),
            (candidate(0, "1289", "Starburst"),),
        )
        self.assertEqual(result.status, TargetResolutionStatus.RESOLVED)
        fuzzy = resolve_target(
            FarmTarget(boss_name="Star burst"),
            (candidate(0, "1289", "Starburst"),),
        )
        self.assertEqual(fuzzy.status, TargetResolutionStatus.MISSING)


class BossEntryButtonLocatorTests(unittest.TestCase):
    def test_correct_single_button(self) -> None:
        width, height = 960, 540
        rgb = synthetic_button_image(((0.54, 0.76, 0.75, 0.86),))
        located = locate_chinh_phuc_start(rgb, width, height)
        self.assertTrue(located.found)
        self.assertEqual(located.metrics["candidateCount"], 1)
        self.assertGreaterEqual(located.confidence, 0.80)

    def test_button_missing(self) -> None:
        width, height = 960, 540
        rgb = synthetic_button_image(())
        located = locate_chinh_phuc_start(rgb, width, height)
        self.assertFalse(located.found)
        self.assertEqual(located.reason, "start_button_missing")

    def test_button_ambiguous(self) -> None:
        width, height = 960, 540
        rgb = synthetic_button_image(
            ((0.47, 0.77, 0.61, 0.85), (0.66, 0.77, 0.80, 0.85))
        )
        located = locate_chinh_phuc_start(rgb, width, height)
        self.assertFalse(located.found)
        self.assertEqual(located.reason, "start_button_ambiguous")
        self.assertEqual(len(located.candidates), 2)

    @unittest.skipUnless(
        (V1_SCREENSHOTS / "waiting_room.png").exists(),
        "read-only PokiguardAuto reference is unavailable",
    )
    def test_v1_waiting_room_reference(self) -> None:
        image = read_png_rgb(V1_SCREENSHOTS / "waiting_room.png")
        located = locate_chinh_phuc_start(image.rgb, image.width, image.height)
        self.assertTrue(located.found)
        self.assertGreaterEqual(located.confidence, 0.90)

    @unittest.skipUnless(
        (V1_SCREENSHOTS / "waiting_room_with_selected_support_card.png").exists(),
        "read-only PokiguardAuto reference is unavailable",
    )
    def test_v1_selected_card_waiting_room_reference(self) -> None:
        image = read_png_rgb(
            V1_SCREENSHOTS / "waiting_room_with_selected_support_card.png"
        )
        located = locate_chinh_phuc_start(image.rgb, image.width, image.height)
        self.assertTrue(located.found)
        self.assertGreaterEqual(located.confidence, 0.90)


if __name__ == "__main__":
    unittest.main()
