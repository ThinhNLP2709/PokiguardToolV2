"""Pure-data Mega Icarus seal geometry and readiness contract.

This module does not select moves or emit input.  It only projects one
provider-neutral board onto the 30 cells destroyed by Mega Icarus.
"""

from __future__ import annotations

from dataclasses import dataclass

from .gameplay_profile import PetSkillFireCondition
from .state import BoardState, GemType


MEGA_ICARUS_SEAL_CELLS: tuple[tuple[int, int], ...] = (
    (0, 4),
    (1, 2), (1, 3), (1, 5),
    (2, 0), (2, 2), (2, 4), (2, 5), (2, 6),
    (3, 1), (3, 2), (3, 3), (3, 4), (3, 5), (3, 6), (3, 7),
    (4, 2), (4, 3), (4, 4), (4, 5), (4, 6),
    (5, 1), (5, 2), (5, 3), (5, 4), (5, 5),
    (6, 1), (6, 2), (6, 3), (6, 5),
)


def _validate_seal_cells() -> None:
    if len(MEGA_ICARUS_SEAL_CELLS) != 30:
        raise RuntimeError("Mega Icarus seal must contain exactly 30 cells")
    if len(set(MEGA_ICARUS_SEAL_CELLS)) != len(MEGA_ICARUS_SEAL_CELLS):
        raise RuntimeError("Mega Icarus seal cells must be unique")
    if any(not (0 <= row < 8 and 0 <= col < 8)
           for row, col in MEGA_ICARUS_SEAL_CELLS):
        raise RuntimeError("Mega Icarus seal cells must be inside the 8x8 board")


_validate_seal_cells()
MEGA_ICARUS_SEAL_CELL_SET = frozenset(MEGA_ICARUS_SEAL_CELLS)


@dataclass(frozen=True)
class SealGemCount:
    """Physical cells plus the multiplier-weighted readiness count."""

    physical: int
    effective: int


_CONDITION_GEMS = {
    PetSkillFireCondition.SWORD_COUNT: GemType.SWORD,
    PetSkillFireCondition.MANA_GEM_COUNT: GemType.MANA,
    PetSkillFireCondition.RAGE_GEM_COUNT: GemType.RAGE,
    PetSkillFireCondition.DRAIN_GEM_COUNT: GemType.DRAIN,
    PetSkillFireCondition.SHIELD_GEM_COUNT: GemType.SHIELD,
}


def count_seal_gems(board: BoardState, gem_type: GemType) -> SealGemCount:
    """Count one known gem type inside the fixed seal only.

    ``effective`` is authoritative for readiness so x2/x3 gems contribute
    their full value. ``physical`` remains observable telemetry. UNKNOWN is
    deliberately worth zero credit.
    """

    if not isinstance(board, BoardState):
        raise TypeError("board must be BoardState")
    if not isinstance(gem_type, GemType):
        raise TypeError("gem_type must be GemType")
    if gem_type is GemType.UNKNOWN:
        return SealGemCount(0, 0)
    matched = tuple(
        board.cells[row][col]
        for row, col in MEGA_ICARUS_SEAL_CELLS
        if board.cells[row][col].gem is gem_type
        and board.cells[row][col].gem is not GemType.UNKNOWN
    )
    return SealGemCount(
        physical=len(matched),
        effective=sum(cell.multiplier for cell in matched),
    )


def seal_condition_count(
    board: BoardState,
    condition: PetSkillFireCondition,
) -> SealGemCount:
    """Return seal counts for a board-count fire condition."""

    if not isinstance(condition, PetSkillFireCondition):
        raise TypeError("condition must be PetSkillFireCondition")
    if condition is PetSkillFireCondition.SKILL_COST_READY:
        raise ValueError("skill_cost_ready has no board count")
    return count_seal_gems(board, _CONDITION_GEMS[condition])


def mega_icarus_condition_ready(
    board: BoardState | None,
    condition: PetSkillFireCondition,
    threshold: int | None,
    *,
    skill_cost_ready: bool,
) -> bool:
    """Evaluate the configured condition without policy or input side effects."""

    if not isinstance(condition, PetSkillFireCondition):
        raise TypeError("condition must be PetSkillFireCondition")
    if condition is PetSkillFireCondition.SKILL_COST_READY:
        return bool(skill_cost_ready)
    if not isinstance(board, BoardState):
        raise TypeError("board must be BoardState for a board-count condition")
    if type(threshold) is not int or threshold < 0:
        raise ValueError("threshold must be a nonnegative integer")
    # The configured threshold is inclusive and multiplier-weighted.
    return seal_condition_count(board, condition).effective >= threshold


__all__ = [
    "MEGA_ICARUS_SEAL_CELLS",
    "MEGA_ICARUS_SEAL_CELL_SET",
    "SealGemCount",
    "count_seal_gems",
    "mega_icarus_condition_ready",
    "seal_condition_count",
]
