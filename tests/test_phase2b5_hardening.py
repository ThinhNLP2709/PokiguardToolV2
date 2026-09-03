from __future__ import annotations

from dataclasses import dataclass
import unittest

from pokiguard_v2.audit_overlay import BoardGeometry, screen_move_to_runtime
from pokiguard_v2.live_state import (
    dto_rejection_reasons,
    runtime_row_to_screen_row,
    screen_row_to_runtime_row,
)
from pokiguard_v2.memory_board_provider import sequence_rejection_reason
from pokiguard_v2.state import CombatSessionKey


@dataclass(frozen=True)
class Cell:
    row: int
    col: int
    tag: str = "vang"
    multiplier: int = 1


def complete_cells() -> list[Cell]:
    return [Cell(row, col) for row in range(8) for col in range(8)]


class DtoAcceptanceTests(unittest.TestCase):
    def test_exact_complete_board_is_accepted(self) -> None:
        self.assertEqual(dto_rejection_reasons(complete_cells()), ())

    def test_duplicate_missing_unknown_and_multiplier_are_reported(self) -> None:
        cells = complete_cells()
        cells[-1] = Cell(0, 0, "mystery", 9)
        reasons = dto_rejection_reasons(cells)
        self.assertTrue(any(reason.startswith("duplicate_coordinates") for reason in reasons))
        self.assertTrue(any(reason.startswith("missing_coordinates") for reason in reasons))
        self.assertTrue(any(reason.startswith("unknown_tags") for reason in reasons))
        self.assertTrue(any(reason.startswith("invalid_multipliers") for reason in reasons))


class CombatSessionTests(unittest.TestCase):
    def test_epoch_prevents_board_address_reuse_from_aliasing_sessions(self) -> None:
        first = CombatSessionKey(1, 0x12340000, "match-a")
        restarted = CombatSessionKey(2, 0x12340000, "match-b")
        self.assertNotEqual(first, restarted)

    def test_sequence_rules_are_scoped_after_session_reset(self) -> None:
        self.assertEqual(sequence_rejection_reason(10, "a", 9, "b"), "stale_sequence")
        self.assertEqual(
            sequence_rejection_reason(10, "a", 10, "b"),
            "sequence_hash_changed",
        )
        self.assertEqual(
            sequence_rejection_reason(10, "a", 10, "a"),
            "duplicate_sequence",
        )
        self.assertIsNone(sequence_rejection_reason(10, "a", 11, "b"))
        self.assertIsNone(sequence_rejection_reason(None, None, 1, "new-session"))


class OrientationAndOverlayTests(unittest.TestCase):
    def test_row_conversion_is_an_inverse_for_all_rows(self) -> None:
        for row in range(8):
            self.assertEqual(
                screen_row_to_runtime_row(runtime_row_to_screen_row(row)), row
            )

    def test_solver_move_logs_screen_and_runtime_coordinates(self) -> None:
        self.assertEqual(
            screen_move_to_runtime((0, 2), (1, 2)),
            {
                "fromScreen": {"row": 0, "col": 2},
                "toScreen": {"row": 1, "col": 2},
                "fromRuntime": {"row": 7, "col": 2},
                "toRuntime": {"row": 6, "col": 2},
            },
        )

    def test_geometry_uses_top_origin_screen_rows(self) -> None:
        geometry = BoardGeometry()
        top = geometry.center(1000, 1000, 0, 0)
        bottom = geometry.center(1000, 1000, 7, 0)
        self.assertEqual(top, (362, 162))
        self.assertGreater(bottom[1], top[1])


if __name__ == "__main__":
    unittest.main()
