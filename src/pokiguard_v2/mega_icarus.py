"""B15 fixed seal geometry, with compatibility helpers for Icarus callers."""

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


MEGA_TREX_SEAL_CELLS: tuple[tuple[int, int], ...] = (
    (0, 2), (0, 3), (0, 4), (0, 5),
    (1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (1, 6),
    (2, 0), (2, 1), (2, 3), (2, 4), (2, 6), (2, 7),
    (3, 1), (3, 2), (3, 3), (3, 4), (3, 5), (3, 6),
    (4, 1), (4, 3), (4, 4), (4, 6),
    (5, 2), (5, 5),
    (6, 3), (6, 4),
)


@dataclass(frozen=True)
class MegaSeal:
    element_type: str
    cells: tuple[tuple[int, int], ...]
    heals_self: bool = False

    @property
    def condition_scope(self) -> str:
        return f"{self.element_type}_SEAL_{len(self.cells)}"


# The attachment gate pins B15. Source of both masks:
# docs/artifacts/b15_mega_seal_expansion_20261107/seal_masks.json.
_B15_SEALS = {
    seal.element_type: seal
    for seal in (
        MegaSeal("MEGA_ICARUS", MEGA_ICARUS_SEAL_CELLS, heals_self=True),
        MegaSeal("MEGA_TREX", MEGA_TREX_SEAL_CELLS),
    )
}
for _seal in _B15_SEALS.values():
    if len(_seal.cells) != 30 or len(set(_seal.cells)) != 30:
        raise RuntimeError(f"{_seal.element_type} seal must contain 30 unique cells")
    if any(not (0 <= row < 8 and 0 <= col < 8) for row, col in _seal.cells):
        raise RuntimeError(f"{_seal.element_type} seal exceeds the 8x8 board")


def mega_seal_for_type(element_type: str | None) -> MegaSeal | None:
    return _B15_SEALS.get(element_type.upper()) if isinstance(element_type, str) else None


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


def gem_for_fire_condition(condition: PetSkillFireCondition | str) -> GemType | None:
    return _CONDITION_GEMS.get(condition) if isinstance(condition, str) else None


def count_seal_gems(
    board: BoardState,
    gem_type: GemType,
    *,
    cells: tuple[tuple[int, int], ...] = MEGA_ICARUS_SEAL_CELLS,
) -> SealGemCount:
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
        for row, col in cells
        if board.cells[row][col].gem is gem_type
    )
    return SealGemCount(
        physical=len(matched),
        effective=sum(cell.multiplier for cell in matched),
    )


def seal_condition_count(
    board: BoardState,
    condition: PetSkillFireCondition,
    *,
    cells: tuple[tuple[int, int], ...] = MEGA_ICARUS_SEAL_CELLS,
) -> SealGemCount:
    """Return seal counts for a board-count fire condition."""

    if not isinstance(condition, PetSkillFireCondition):
        raise TypeError("condition must be PetSkillFireCondition")
    if condition is PetSkillFireCondition.SKILL_COST_READY:
        raise ValueError("skill_cost_ready has no board count")
    return count_seal_gems(board, _CONDITION_GEMS[condition], cells=cells)


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
    "MEGA_TREX_SEAL_CELLS",
    "MegaSeal",
    "SealGemCount",
    "count_seal_gems",
    "gem_for_fire_condition",
    "mega_seal_for_type",
    "mega_icarus_condition_ready",
    "seal_condition_count",
]
