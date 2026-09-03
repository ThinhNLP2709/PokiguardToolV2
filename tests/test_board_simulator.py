from __future__ import annotations

import json
from pathlib import Path
import unittest

from pokiguard_v2.board_simulator import (
    SwordDangerRegion,
    SwapMove,
    _CellValue,
    _collapse_support_hazard,
    _hypothetical_unknown_hazard,
    _known_sword_opportunities,
    board_sword_danger_regions,
    evaluate_all_moves,
    simulate_move,
)
from pokiguard_v2.state import BoardState, CellState, GemType


ROOT = Path(__file__).resolve().parents[1]
FIXTURE = ROOT / "reference" / "phase2c2a_basic_policy_fixture.json"


def fixture_board() -> BoardState:
    value = json.loads(FIXTURE.read_text(encoding="utf-8"))
    return BoardState(
        tuple(
            tuple(
                CellState(
                    row,
                    col,
                    GemType(value["gems"][row][col]),
                    value["multipliers"][row][col],
                )
                for col in range(8)
            )
            for row in range(8)
        )
    )


def cyclic_board() -> BoardState:
    gems = tuple(gem for gem in GemType if gem is not GemType.UNKNOWN)
    return BoardState(
        tuple(
            tuple(CellState(row, col, gems[(row * 2 + col) % len(gems)], 1) for col in range(8))
            for row in range(8)
        )
    )


def retry17_seq19_board() -> BoardState:
    """Runtime-attested board that exposed refill auto-match misclassification."""

    gems = (
        ("rage", "shield", "sword", "drain", "health", "health", "sword", "mana"),
        ("rage", "drain", "sword", "shield", "drain", "rage", "sword", "drain"),
        ("health", "mana", "mana", "health", "mana", "shield", "rage", "drain"),
        ("drain", "drain", "shield", "shield", "health", "shield", "mana", "shield"),
        ("sword", "shield", "mana", "rage", "rage", "sword", "shield", "rage"),
        ("shield", "shield", "mana", "sword", "rage", "mana", "rage", "health"),
        ("drain", "rage", "drain", "sword", "health", "sword", "shield", "mana"),
        ("sword", "rage", "rage", "drain", "health", "drain", "drain", "health"),
    )
    multipliers = (
        (1, 1, 1, 2, 1, 1, 1, 1),
        (1, 1, 1, 1, 1, 1, 1, 1),
        (1, 1, 1, 1, 1, 2, 1, 1),
        (1, 1, 1, 1, 1, 2, 1, 1),
        (1, 1, 1, 1, 1, 1, 1, 1),
        (1, 1, 1, 1, 1, 1, 1, 1),
        (1, 1, 1, 1, 1, 1, 1, 1),
        (1, 1, 1, 1, 1, 1, 1, 1),
    )
    return BoardState(
        tuple(
            tuple(
                CellState(row, col, GemType(gem), multipliers[row][col])
                for col, gem in enumerate(values)
            )
            for row, values in enumerate(gems)
        )
    )


def retry18_seq11_board() -> BoardState:
    gems = (
        ("health", "shield", "rage", "mana", "mana", "shield", "shield", "rage"),
        ("drain", "shield", "sword", "mana", "health", "drain", "shield", "rage"),
        ("rage", "rage", "mana", "shield", "shield", "mana", "mana", "shield"),
        ("health", "drain", "shield", "sword", "health", "drain", "drain", "shield"),
        ("rage", "mana", "sword", "drain", "mana", "health", "shield", "rage"),
        ("drain", "drain", "shield", "mana", "rage", "shield", "health", "mana"),
        ("sword", "drain", "sword", "health", "sword", "shield", "drain", "sword"),
        ("shield", "shield", "mana", "mana", "health", "rage", "sword", "shield"),
    )
    return BoardState(
        tuple(
            tuple(
                CellState(row, col, GemType(gem), 1)
                for col, gem in enumerate(values)
            )
            for row, values in enumerate(gems)
        )
    )


def retry24_seq20_board() -> BoardState:
    """Runtime-attested board behind the post-Fusion no-safe-move beep."""

    gems = (
        ("sword", "mana", "mana", "sword", "shield", "sword", "drain", "shield"),
        ("drain", "drain", "mana", "mana", "shield", "rage", "drain", "sword"),
        ("drain", "sword", "shield", "drain", "health", "sword", "rage", "drain"),
        ("mana", "rage", "drain", "sword", "drain", "health", "mana", "drain"),
        ("drain", "sword", "rage", "sword", "mana", "shield", "health", "mana"),
        ("sword", "mana", "drain", "mana", "health", "drain", "rage", "shield"),
        ("rage", "shield", "shield", "health", "shield", "shield", "health", "drain"),
        ("sword", "drain", "shield", "drain", "rage", "mana", "drain", "mana"),
    )
    multipliers = (
        (1, 1, 1, 2, 1, 2, 1, 1),
        (1, 1, 1, 1, 2, 1, 1, 1),
        (1, 1, 1, 1, 1, 1, 1, 1),
        (1, 1, 1, 2, 1, 1, 1, 1),
        (1, 1, 1, 1, 1, 1, 1, 1),
        (1, 1, 1, 1, 1, 1, 1, 1),
        (1, 1, 1, 1, 1, 1, 1, 1),
        (1, 1, 1, 1, 1, 1, 1, 1),
    )
    return BoardState(
        tuple(
            tuple(
                CellState(row, col, GemType(gem), multipliers[row][col])
                for col, gem in enumerate(values)
            )
            for row, values in enumerate(gems)
        )
    )


class BoardSimulatorTests(unittest.TestCase):
    @staticmethod
    def _hazard_grid() -> list[list[_CellValue]]:
        gems = (
            GemType.MANA,
            GemType.RAGE,
            GemType.SHIELD,
            GemType.HEALTH,
            GemType.DRAIN,
        )
        return [
            [_CellValue(gems[(row * 2 + col) % len(gems)], 1) for col in range(8)]
            for row in range(8)
        ]

    def test_refill_sword_auto_match_is_current_cascade_not_opponent_hazard(self) -> None:
        grid = self._hazard_grid()
        grid[0][0] = _CellValue(GemType.UNKNOWN, None)
        grid[1][0] = _CellValue(GemType.SWORD, 1)
        grid[2][0] = _CellValue(GemType.SWORD, 1)

        self.assertEqual(_hypothetical_unknown_hazard(grid), (0, 0))

    def test_settled_refill_sword_swap_potential_remains_a_hazard(self) -> None:
        grid = self._hazard_grid()
        grid[0][0] = _CellValue(GemType.UNKNOWN, None)
        grid[1][0] = _CellValue(GemType.MANA, 1)
        grid[1][1] = _CellValue(GemType.SWORD, 1)
        grid[1][2] = _CellValue(GemType.SWORD, 1)

        self.assertEqual(_hypothetical_unknown_hazard(grid), (1, 3))

    def test_known_sword_can_move_into_non_sword_refill_slot(self) -> None:
        grid = self._hazard_grid()
        grid[0][0] = _CellValue(GemType.SWORD, 1)
        grid[0][1] = _CellValue(GemType.UNKNOWN, None)
        grid[1][1] = _CellValue(GemType.SWORD, 1)
        grid[2][1] = _CellValue(GemType.SWORD, 1)

        # If the real refill at (0, 1) is not Sword, the boss can move the
        # already-known Sword at (0, 0) into it and complete the vertical 3.
        self.assertEqual(_hypothetical_unknown_hazard(grid), (1, 3))

    def test_row_two_rage_clear_reproduces_reported_sword_drop_hazard(self) -> None:
        grid = self._hazard_grid()
        for row, col in ((0, 0), (0, 1), (2, 1), (2, 2)):
            grid[row][col] = _CellValue(GemType.SWORD, 1)
        grid[2][3] = _CellValue(GemType.SHIELD, 1)
        grid[1][1] = _CellValue(GemType.RAGE, 1)
        grid[1][2] = _CellValue(GemType.RAGE, 1)
        grid[1][3] = _CellValue(GemType.MANA, 1)
        grid[1][4] = _CellValue(GemType.RAGE, 1)
        board = BoardState(
            tuple(
                tuple(
                    CellState(row, col, value.gem, value.multiplier)
                    for col, value in enumerate(values)
                )
                for row, values in enumerate(grid)
            )
        )

        selected = simulate_move(board, SwapMove((1, 3), (1, 4)))

        self.assertIsNotNone(selected)
        assert selected is not None
        self.assertEqual(selected.direct.effective(GemType.RAGE), 3)
        self.assertEqual(selected.clear_rounds, (((1, 1), (1, 2), (1, 3)),))
        self.assertEqual(selected.result[0][0].gem, GemType.SWORD)
        self.assertEqual(selected.result[0][1].gem, GemType.UNKNOWN)
        self.assertEqual(selected.result[1][1].gem, GemType.SWORD)
        self.assertEqual(selected.result[2][1].gem, GemType.SWORD)
        # The settled-board UNKNOWN-slot analysis, not the broad support
        # heuristic, proves this one-row collapse hazard.
        self.assertEqual(selected.sword_risk.collapse_support_hazard, 0)
        self.assertEqual(selected.sword_risk.unknown_sword_completions, 1)
        self.assertEqual(selected.sword_risk.unknown_sword_effective_max, 3)
        self.assertFalse(selected.sword_risk.safe)

    def test_opponent_non_sword_match_with_known_sword_cascade_is_a_reply(self) -> None:
        grid = self._hazard_grid()
        grid[0][0] = _CellValue(GemType.SWORD, 1)
        grid[1][0] = _CellValue(GemType.SWORD, 2)
        grid[2][0] = _CellValue(GemType.MANA, 1)
        grid[3][0] = _CellValue(GemType.SWORD, 3)
        grid[2][1] = _CellValue(GemType.MANA, 1)
        grid[2][2] = _CellValue(GemType.RAGE, 1)
        grid[3][2] = _CellValue(GemType.MANA, 1)

        potentials, replies = _known_sword_opportunities(grid)
        move = SwapMove((2, 2), (3, 2))
        reply = next(value for value in replies if value.move == move)

        self.assertFalse(any(value.move == move for value in potentials))
        self.assertTrue(reply.indirect)
        self.assertEqual(reply.direct_sword_effective, 0)
        self.assertEqual(reply.cascade_sword_effective, 6)
        self.assertEqual(reply.sword_cells, 3)
        self.assertGreaterEqual(reply.cascade_rounds, 1)

    def test_retry17_mana_move_is_safe_after_current_turn_auto_cascade(self) -> None:
        selected = next(
            value
            for value in evaluate_all_moves(retry17_seq19_board())
            if value.move == SwapMove((2, 3), (2, 4))
        )

        self.assertEqual(selected.total.effective(GemType.MANA), 3)
        self.assertEqual(selected.sword_risk.potential_effective_max, 0)
        self.assertEqual(selected.sword_risk.collapse_support_hazard, 0)
        self.assertEqual(selected.sword_risk.unknown_sword_completions, 0)
        self.assertTrue(selected.sword_risk.safe)

    def test_clear_above_lower_sword_region_does_not_invent_collapse_hazard(self) -> None:
        region = SwordDangerRegion(
            axis="row",
            cells=((6, 4), (6, 5), (6, 6), (6, 7)),
            sword_cells=((6, 4), (6, 7)),
            gaps=((6, 5), (6, 6)),
            span=3,
            unknown_gap=False,
        )

        self.assertEqual(
            _collapse_support_hazard(
                (region,),
                (((2, 7), (3, 7), (4, 7)),),
            ),
            0,
        )

    def test_clear_through_sword_gap_retains_collapse_hazard(self) -> None:
        region = SwordDangerRegion(
            axis="row",
            cells=((6, 4), (6, 5), (6, 6), (6, 7)),
            sword_cells=((6, 4), (6, 7)),
            gaps=((6, 5), (6, 6)),
            span=3,
            unknown_gap=False,
        )

        self.assertEqual(
            _collapse_support_hazard(
                (region,),
                (((4, 6), (5, 6), (6, 6)),),
            ),
            2,
        )

    def test_retry18_lowest_risk_shield_move_is_directionally_safe(self) -> None:
        selected = next(
            value
            for value in evaluate_all_moves(retry18_seq11_board())
            if value.move == SwapMove((4, 6), (4, 7))
        )

        self.assertEqual(selected.total.effective(GemType.SHIELD), 3)
        self.assertEqual(selected.sword_risk.potential_effective_max, 0)
        self.assertEqual(selected.sword_risk.collapse_support_hazard, 0)
        self.assertTrue(selected.sword_risk.safe)

    def test_top_area_clear_with_unknown_refill_is_not_promoted_safe(self) -> None:
        selected = next(
            value
            for value in evaluate_all_moves(retry18_seq11_board())
            if value.move == SwapMove((1, 6), (1, 7))
        )

        self.assertFalse(selected.calculable)
        self.assertEqual(selected.sword_risk.opponent_sword_replies, 0)
        self.assertEqual(selected.sword_risk.unknown_sword_completions, 0)
        self.assertEqual(selected.unknown_exposure.cells, 3)
        self.assertFalse(selected.sword_risk.safe)

    def test_retry24_calculable_horizontal_shield_move_is_bounded_safe(self) -> None:
        selected = next(
            value
            for value in evaluate_all_moves(retry24_seq20_board())
            if value.move == SwapMove((6, 2), (6, 3))
        )

        self.assertTrue(selected.horizontal)
        self.assertTrue(selected.calculable)
        self.assertEqual(selected.total.effective(GemType.SHIELD), 3)
        self.assertEqual(selected.sword_risk.potential_effective_max, 0)
        self.assertEqual(selected.sword_risk.collapse_support_hazard, 0)
        self.assertEqual(selected.unknown_exposure.max_column_depth, 1)
        self.assertGreater(selected.sword_risk.unknown_sword_effective_max, 0)
        self.assertTrue(selected.sword_risk.safe)

    def test_retry24_vertical_sword_hazard_remains_unsafe(self) -> None:
        selected = next(
            value
            for value in evaluate_all_moves(retry24_seq20_board())
            if value.move == SwapMove((0, 1), (1, 1))
        )

        self.assertFalse(selected.horizontal)
        self.assertGreater(selected.sword_risk.potential_effective_max, 0)
        self.assertFalse(selected.sword_risk.safe)

    def test_screenshot_indirect_sword_cascade_preserves_multipliers(self) -> None:
        moves = evaluate_all_moves(fixture_board())
        selected = next(
            move for move in moves if move.move == SwapMove((6, 5), (6, 6))
        )
        self.assertEqual(selected.direct.effective(GemType.RAGE), 3)
        self.assertEqual(selected.cascade.effective(GemType.RAGE), 7)
        self.assertEqual(selected.cascade.effective(GemType.SWORD), 6)
        self.assertEqual(selected.total.effective(GemType.RAGE), 10)
        self.assertEqual(selected.sword_effective, 6)
        self.assertEqual(selected.cascade_rounds, 1)
        self.assertFalse(selected.known_result)
        self.assertEqual(selected.unknown_exposure.cells, 10)

    def test_indirect_sword_move_beats_naive_direct_sword_on_fixture(self) -> None:
        moves = evaluate_all_moves(fixture_board())
        indirect = next(
            move for move in moves if move.move == SwapMove((6, 5), (6, 6))
        )
        direct = [
            move
            for move in moves
            if move.direct.effective(GemType.SWORD) > 0
            and move.cascade.effective(GemType.SWORD) == 0
        ]
        self.assertTrue(direct)
        self.assertGreater(
            indirect.sword_effective,
            max(move.sword_effective for move in direct),
        )

    def test_exhaustive_solver_proves_cyclic_deadlock(self) -> None:
        self.assertEqual(evaluate_all_moves(cyclic_board()), ())

    def test_generalized_gapped_sword_region(self) -> None:
        board = cyclic_board()
        rows = [list(row) for row in board.cells]
        rows[2][1] = CellState(2, 1, GemType.SWORD, 3)
        rows[2][2] = CellState(2, 2, GemType.MANA, 1)
        rows[2][3] = CellState(2, 3, GemType.SWORD, 1)
        regions = board_sword_danger_regions(BoardState(tuple(tuple(row) for row in rows)))
        self.assertTrue(
            any(
                region.axis == "row"
                and region.sword_cells == ((2, 1), (2, 3))
                and region.gaps == ((2, 2),)
                for region in regions
            )
        )

    def test_all_outputs_keep_known_multiplier_or_explicit_unknown(self) -> None:
        for move in evaluate_all_moves(fixture_board()):
            for row in move.result:
                for cell in row:
                    if cell.gem is GemType.UNKNOWN:
                        self.assertIsNone(cell.multiplier)
                    else:
                        self.assertIn(cell.multiplier, (1, 2, 3, 4))


if __name__ == "__main__":
    unittest.main()
