from __future__ import annotations

from dataclasses import dataclass
from pathlib import Path
import sys
import unittest


SRC = Path(__file__).resolve().parents[1] / "src"
if str(SRC) not in sys.path:
    sys.path.insert(0, str(SRC))

from pokiguard_v2.live_state import (
    StableSnapshotGate,
    board_state_hash,
    gem_for_tag,
    multiplier_distribution,
    runtime_row_to_screen_row,
    to_board_state,
)
from pokiguard_v2.state import GemType


@dataclass(frozen=True)
class CellFixture:
    row: int
    col: int
    tag: str
    multiplier: int


def cells() -> tuple[CellFixture, ...]:
    tags = ("vang Dot", "xanhduong Dot", "do Dot", "tim Dot", "xanh Dot", "trang Dot")
    return tuple(
        CellFixture(row, col, tags[(row * 8 + col) % len(tags)], 1 + (col % 4))
        for row in range(8)
        for col in range(8)
    )


class LiveStateTests(unittest.TestCase):
    def test_hash_is_coordinate_canonical_and_includes_multiplier(self) -> None:
        values = cells()
        first = board_state_hash(values)
        self.assertEqual(first, board_state_hash(reversed(values)))
        changed = list(values)
        changed[0] = CellFixture(0, 0, changed[0].tag, 2)
        self.assertNotEqual(first, board_state_hash(changed))

    def test_exact_tag_and_multiplier_model(self) -> None:
        state = to_board_state(cells())
        self.assertTrue(state.production_ready)
        # Runtime row 0 is the visual bottom; the provider/solver model is
        # screen-oriented with row 0 at the visual top.
        self.assertEqual(state.cells[0][0].gem_type, GemType.RAGE)
        self.assertEqual(state.cells[7][0].gem_type, GemType.SWORD)
        self.assertEqual(state.multipliers[0], (1, 2, 3, 4, 1, 2, 3, 4))
        self.assertEqual(multiplier_distribution(cells()), {1: 16, 2: 16, 3: 16, 4: 16})
        self.assertEqual(gem_for_tag("blue"), GemType.UNKNOWN)

    def test_runtime_rows_are_flipped_at_solver_boundary(self) -> None:
        self.assertEqual(runtime_row_to_screen_row(0), 7)
        self.assertEqual(runtime_row_to_screen_row(7), 0)
        with self.assertRaises(ValueError):
            runtime_row_to_screen_row(8)

    def test_unverified_multiplier_fails_closed(self) -> None:
        values = list(cells())
        values[0] = CellFixture(0, 0, "vang Dot", 0)
        with self.assertRaises(ValueError):
            to_board_state(values)

    def test_stable_gate_requires_consecutive_valid_pairs(self) -> None:
        gate = StableSnapshotGate()
        self.assertEqual(gate.observe(("hash-a", 1), True), (False, 1))
        self.assertEqual(gate.observe(("hash-a", 1), True), (True, 2))
        self.assertEqual(gate.observe(("hash-a", 1), False), (False, 0))
        self.assertEqual(gate.observe(("hash-b", 2), True), (False, 1))


if __name__ == "__main__":
    unittest.main()
