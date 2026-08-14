from __future__ import annotations

from pathlib import Path
import sys
import unittest


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
if str(SRC_ROOT) not in sys.path:
    sys.path.insert(0, str(SRC_ROOT))

from pokiguard_v2.recovery_ui import locate_confirm_leave, locate_exit_back
from tools.sequence_recovery import _live_exit_calibration


def canvas(width: int = 1000, height: int = 600) -> tuple[bytearray, int, int]:
    return bytearray((20, 80, 130) * (width * height)), width, height


def rect(
    rgb: bytearray,
    width: int,
    x0: int,
    y0: int,
    x1: int,
    y1: int,
    color: tuple[int, int, int],
) -> None:
    for y in range(y0, y1):
        for x in range(x0, x1):
            offset = (y * width + x) * 3
            rgb[offset : offset + 3] = bytes(color)


class RecoveryUiLocatorTests(unittest.TestCase):
    def test_live_calibration_is_exact_dimension_scoped(self) -> None:
        accepted = _live_exit_calibration(pid=2184, width=1294, height=696)
        self.assertIsNotNone(accepted)
        self.assertTrue(accepted.found)
        self.assertIsNone(
            _live_exit_calibration(pid=2184, width=1280, height=720)
        )

    def test_exit_requires_multiple_white_chevron_components(self) -> None:
        rgb, width, height = canvas()
        for box in ((25, 28, 34, 55), (39, 28, 48, 55), (53, 28, 62, 55)):
            rect(rgb, width, *box, (250, 250, 250))
        found = locate_exit_back(bytes(rgb), width, height)
        self.assertTrue(found.found)
        blank, _, _ = canvas()
        self.assertFalse(locate_exit_back(bytes(blank), width, height).found)

    def test_confirm_requires_exact_symmetric_orange_pair(self) -> None:
        rgb, width, height = canvas()
        rect(rgb, width, 320, 360, 450, 405, (230, 120, 25))
        rect(rgb, width, 550, 360, 680, 405, (230, 120, 25))
        found = locate_confirm_leave(bytes(rgb), width, height)
        self.assertTrue(found.found)
        rect(rgb, width, 460, 360, 540, 405, (230, 120, 25))
        self.assertFalse(locate_confirm_leave(bytes(rgb), width, height).found)


if __name__ == "__main__":
    unittest.main()
