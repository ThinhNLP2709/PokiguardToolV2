"""Pure helpers for canonical live BoardCellDTO snapshots.

The memory watcher keeps raw runtime values in its JSONL output.  This module
only converts a snapshot to the provider-neutral model after every coordinate,
tag, and currently evidenced multiplier value validates.
"""

from __future__ import annotations

from collections import Counter
import hashlib
import json
from typing import Iterable, Protocol

from .state import BoardState, CellState, GemType


class CellLike(Protocol):
    row: int
    col: int
    tag: str
    multiplier: int


TAG_TO_GEM = {
    "vang": GemType.SWORD,
    "xanhduong": GemType.MANA,
    "do": GemType.RAGE,
    "tim": GemType.SHIELD,
    "xanh": GemType.HEALTH,
    "trang": GemType.DRAIN,
}

# Phase 2A post-match DTO evidence observed all four values.  Phase 2A.5's
# production acceptance additionally requires live DTO/Dot correlation.
EVIDENCED_MULTIPLIERS = frozenset({1, 2, 3, 4})


def runtime_row_to_screen_row(runtime_row: int) -> int:
    """Map bottom-origin game coordinates to V1's top-origin board rows."""

    if not 0 <= runtime_row < 8:
        raise ValueError("runtime row must be inside the 8x8 board")
    return 7 - runtime_row


def screen_row_to_runtime_row(screen_row: int) -> int:
    """Inverse of :func:`runtime_row_to_screen_row`."""

    if not 0 <= screen_row < 8:
        raise ValueError("screen row must be inside the 8x8 board")
    return 7 - screen_row


def dto_rejection_reasons(cells: Iterable[CellLike]) -> tuple[str, ...]:
    """Return exact fail-closed reasons for the DTO-only acceptance contract."""

    values = tuple(cells)
    reasons: list[str] = []
    if len(values) != 64:
        reasons.append(f"cell_count:{len(values)}")
    coordinates = [(int(cell.row), int(cell.col)) for cell in values]
    outside = sorted(
        coordinate
        for coordinate in coordinates
        if not 0 <= coordinate[0] < 8 or not 0 <= coordinate[1] < 8
    )
    if outside:
        reasons.append(f"coordinates_out_of_range:{outside}")
    counts = Counter(coordinates)
    duplicates = sorted(coordinate for coordinate, count in counts.items() if count > 1)
    if duplicates:
        reasons.append(f"duplicate_coordinates:{duplicates}")
    expected = {(row, col) for row in range(8) for col in range(8)}
    missing = sorted(expected - set(coordinates))
    if missing:
        reasons.append(f"missing_coordinates:{missing}")
    unknown = sorted(
        (int(cell.row), int(cell.col), str(cell.tag))
        for cell in values
        if gem_for_tag(cell.tag) is GemType.UNKNOWN
    )
    if unknown:
        reasons.append(f"unknown_tags:{unknown}")
    invalid_multipliers = sorted(
        (int(cell.row), int(cell.col), int(cell.multiplier))
        for cell in values
        if int(cell.multiplier) not in EVIDENCED_MULTIPLIERS
    )
    if invalid_multipliers:
        reasons.append(f"invalid_multipliers:{invalid_multipliers}")
    return tuple(reasons)


def normalize_tag(tag: str) -> str:
    normalized = "".join(
        character for character in tag.casefold() if character.isalnum()
    )
    return normalized[:-3] if normalized.endswith("dot") else normalized


def gem_for_tag(tag: str | None) -> GemType:
    if tag is None:
        return GemType.UNKNOWN
    return TAG_TO_GEM.get(normalize_tag(tag), GemType.UNKNOWN)


def canonical_cell_values(cells: Iterable[CellLike]) -> tuple[tuple[int, int, str, int], ...]:
    values = tuple(
        sorted(
            (
                int(cell.row),
                int(cell.col),
                str(cell.tag),
                int(cell.multiplier),
            )
            for cell in cells
        )
    )
    coordinates = {(row, col) for row, col, _tag, _multiplier in values}
    if len(values) != 64 or coordinates != {
        (row, col) for row in range(8) for col in range(8)
    }:
        raise ValueError("snapshot must contain every 8x8 coordinate exactly once")
    return values


def board_state_hash(cells: Iterable[CellLike]) -> str:
    """SHA-256 over canonical row/col/tag/raw-multiplier values."""

    values = canonical_cell_values(cells)
    payload = json.dumps(values, ensure_ascii=False, separators=(",", ":"))
    return hashlib.sha256(payload.encode("utf-8")).hexdigest()


def multiplier_distribution(cells: Iterable[CellLike]) -> dict[int, int]:
    return dict(sorted(Counter(int(cell.multiplier) for cell in cells).items()))


def to_board_state(cells: Iterable[CellLike]) -> BoardState:
    values = canonical_cell_values(cells)
    by_coordinate = {
        (row, col): (tag, multiplier)
        for row, col, tag, multiplier in values
    }
    grid: list[tuple[CellState, ...]] = []
    for row in range(8):
        row_values: list[CellState] = []
        for col in range(8):
            runtime_row = runtime_row_to_screen_row(row)
            tag, multiplier = by_coordinate[(runtime_row, col)]
            gem = gem_for_tag(tag)
            if gem is GemType.UNKNOWN:
                raise ValueError(f"unknown gem tag at ({row},{col}): {tag!r}")
            if multiplier not in EVIDENCED_MULTIPLIERS:
                raise ValueError(
                    f"unverified multiplier at ({row},{col}): {multiplier}"
                )
            row_values.append(CellState(row, col, gem, multiplier))
        grid.append(tuple(row_values))
    return BoardState(tuple(grid))


class StableSnapshotGate:
    """Require the same fully validated server/render pair twice in a row."""

    def __init__(self, required_confirmations: int = 2) -> None:
        if required_confirmations < 2:
            raise ValueError("at least two confirmations are required")
        self.required_confirmations = required_confirmations
        self._key: tuple[object, ...] | None = None
        self._count = 0

    def observe(self, key: tuple[object, ...], signals_valid: bool) -> tuple[bool, int]:
        if not signals_valid:
            self._key = None
            self._count = 0
            return False, 0
        if key == self._key:
            self._count += 1
        else:
            self._key = key
            self._count = 1
        return self._count >= self.required_confirmations, self._count
