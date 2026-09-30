"""Pure board geometry for the Demon Aegis passive.

The passive is evaluated only from the current read-only 8x8 board.  A
horizontal Shield match clears every column passing through a matched Shield;
a vertical Shield match clears every corresponding row.  This module proposes
no input and deliberately gives UNKNOWN cells no Sword credit.
"""

from __future__ import annotations

from dataclasses import dataclass
from typing import Iterable, Protocol

from .board_simulator import MoveEvaluation, SimulatedBoard, SwapMove
from .state import BoardState, GemType


Cell = tuple[int, int]


class _GemCell(Protocol):
    gem: GemType
    multiplier: int | None


@dataclass(frozen=True)
class DemonAegisMoveEvaluation:
    """Known passive result for one legal ordinary board move."""

    move: SwapMove
    shield_match_cells: tuple[Cell, ...]
    blast_cells: tuple[Cell, ...]
    sword_cells: int
    sword_effective: int
    next_best_sword_cells: int = 0
    next_best_sword_effective: int = 0

    @property
    def activates_passive(self) -> bool:
        return bool(self.shield_match_cells)


def _candidate_swaps() -> Iterable[SwapMove]:
    for row in range(8):
        for col in range(8):
            if col < 7:
                yield SwapMove((row, col), (row, col + 1))
            if row < 7:
                yield SwapMove((row, col), (row + 1, col))


def _swapped_grid(
    board: BoardState | SimulatedBoard,
    move: SwapMove,
) -> list[list[_GemCell]]:
    source = board.cells if isinstance(board, BoardState) else board
    grid = [list(row) for row in source]
    first_row, first_col = move.first
    second_row, second_col = move.second
    grid[first_row][first_col], grid[second_row][second_col] = (
        grid[second_row][second_col],
        grid[first_row][first_col],
    )
    return grid


def _shield_runs_through(
    grid: list[list[_GemCell]],
    cell: Cell,
) -> tuple[tuple[Cell, ...], tuple[Cell, ...]]:
    row, col = cell
    if grid[row][col].gem is not GemType.SHIELD:
        return (), ()

    left = col
    while left > 0 and grid[row][left - 1].gem is GemType.SHIELD:
        left -= 1
    right = col
    while right < 7 and grid[row][right + 1].gem is GemType.SHIELD:
        right += 1
    horizontal = (
        tuple((row, value) for value in range(left, right + 1))
        if right - left + 1 >= 3
        else ()
    )

    top = row
    while top > 0 and grid[top - 1][col].gem is GemType.SHIELD:
        top -= 1
    bottom = row
    while bottom < 7 and grid[bottom + 1][col].gem is GemType.SHIELD:
        bottom += 1
    vertical = (
        tuple((value, col) for value in range(top, bottom + 1))
        if bottom - top + 1 >= 3
        else ()
    )
    return horizontal, vertical


def _passive_geometry(
    board: BoardState | SimulatedBoard,
    move: SwapMove,
) -> tuple[tuple[Cell, ...], tuple[Cell, ...], int, int]:
    grid = _swapped_grid(board, move)
    horizontal_cells: set[Cell] = set()
    vertical_cells: set[Cell] = set()
    for cell in (move.first, move.second):
        horizontal, vertical = _shield_runs_through(grid, cell)
        horizontal_cells.update(horizontal)
        vertical_cells.update(vertical)
    matched = horizontal_cells | vertical_cells
    if not matched:
        return (), (), 0, 0

    # Each Shield in a horizontal match clears its complete column.  Each
    # Shield in a vertical match clears its complete row.  Cross matches apply
    # both effects; the union prevents double-counting their intersection.
    blast: set[Cell] = set()
    for _row, col in horizontal_cells:
        blast.update((row, col) for row in range(8))
    for row, _col in vertical_cells:
        blast.update((row, col) for col in range(8))

    swords = tuple(
        grid[row][col]
        for row, col in blast
        if grid[row][col].gem is GemType.SWORD
    )
    return (
        tuple(sorted(matched)),
        tuple(sorted(blast)),
        len(swords),
        sum(cell.multiplier or 1 for cell in swords),
    )


def _best_next_activation(board: SimulatedBoard) -> tuple[int, int]:
    best = (0, 0)
    for move in _candidate_swaps():
        first = board[move.first[0]][move.first[1]]
        second = board[move.second[0]][move.second[1]]
        if (
            first.gem is GemType.UNKNOWN
            or second.gem is GemType.UNKNOWN
            or first.gem is second.gem
        ):
            continue
        matched, _blast, sword_cells, sword_effective = _passive_geometry(
            board, move
        )
        if matched:
            best = max(best, (sword_cells, sword_effective))
    return best


def evaluate_demon_aegis_move(
    board: BoardState,
    value: MoveEvaluation,
    *,
    include_next_turn: bool = True,
) -> DemonAegisMoveEvaluation:
    matched, blast, sword_cells, sword_effective = _passive_geometry(
        board, value.move
    )
    next_cells, next_effective = (
        _best_next_activation(value.result)
        if include_next_turn and not matched
        else (0, 0)
    )
    return DemonAegisMoveEvaluation(
        move=value.move,
        shield_match_cells=matched,
        blast_cells=blast,
        sword_cells=sword_cells,
        sword_effective=sword_effective,
        next_best_sword_cells=next_cells,
        next_best_sword_effective=next_effective,
    )


__all__ = ["DemonAegisMoveEvaluation", "evaluate_demon_aegis_move"]
