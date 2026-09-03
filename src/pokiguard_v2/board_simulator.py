"""Deterministic 8x8 simulator and Sword-risk audit for BASIC policy.

The match/collapse core is adapted from PokiguardAuto V1's proven solver
(``swap_match_cells``, ``_collapse`` and ``resolve_known_drop_chain``).  V2
adds explicit multiplier tallies, UNKNOWN refill cells, and explainable danger
metrics.  It never samples or invents a refill gem.
"""

from __future__ import annotations

from collections import Counter
from dataclasses import dataclass
from typing import Iterable

from .state import BoardState, GemType


Cell = tuple[int, int]


@dataclass(frozen=True, order=True)
class SwapMove:
    first: Cell
    second: Cell

    def __post_init__(self) -> None:
        for row, col in (self.first, self.second):
            if not 0 <= row < 8 or not 0 <= col < 8:
                raise ValueError("swap coordinate must be inside the 8x8 board")
        if abs(self.first[0] - self.second[0]) + abs(
            self.first[1] - self.second[1]
        ) != 1:
            raise ValueError("swap cells must be orthogonally adjacent")

    @property
    def horizontal(self) -> bool:
        return self.first[0] == self.second[0]


@dataclass(frozen=True)
class ResourceTally:
    cells: int = 0
    effective: int = 0


@dataclass(frozen=True)
class ResourceResult:
    values: tuple[tuple[GemType, ResourceTally], ...] = ()

    def tally(self, gem: GemType) -> ResourceTally:
        return next((value for key, value in self.values if key is gem), ResourceTally())

    def cells(self, gem: GemType) -> int:
        return self.tally(gem).cells

    def effective(self, gem: GemType) -> int:
        return self.tally(gem).effective

    @property
    def total_cells(self) -> int:
        return sum(value.cells for _gem, value in self.values)

    @property
    def total_effective(self) -> int:
        return sum(value.effective for _gem, value in self.values)


@dataclass(frozen=True)
class SimulatedCell:
    gem: GemType
    multiplier: int | None

    @property
    def known(self) -> bool:
        return self.gem is not GemType.UNKNOWN


SimulatedBoard = tuple[tuple[SimulatedCell, ...], ...]


@dataclass(frozen=True)
class SwordDangerRegion:
    axis: str
    cells: tuple[Cell, ...]
    sword_cells: tuple[Cell, ...]
    gaps: tuple[Cell, ...]
    span: int
    unknown_gap: bool


@dataclass(frozen=True)
class SwordPotential:
    move: SwapMove
    sword_cells: int
    sword_effective: int


@dataclass(frozen=True)
class SwordReply:
    """One deterministic opponent move that collects Sword now or by cascade."""

    move: SwapMove
    sword_cells: int
    sword_effective: int
    direct_sword_effective: int
    cascade_sword_effective: int
    cascade_rounds: int

    @property
    def indirect(self) -> bool:
        return self.direct_sword_effective == 0 and self.cascade_sword_effective > 0


@dataclass(frozen=True)
class SwordHoldLine:
    """Known line: our off-region move -> boss Sword -> our larger Sword."""

    opponent_move: SwapMove
    opponent_sword_effective: int
    followup_sword_effective: int


@dataclass(frozen=True)
class SwordHoldEvaluation:
    move: SwapMove
    opponent_reply_count: int
    favorable_lines: tuple[SwordHoldLine, ...]
    guaranteed_favorable: bool
    opponent_sword_effective_max: int
    followup_sword_effective_min: int


@dataclass(frozen=True)
class UnknownExposure:
    cells: int
    columns: tuple[tuple[int, int], ...]
    max_column_depth: int
    hypothetical_sword_completions: int
    hypothetical_sword_effective_max: int


@dataclass(frozen=True)
class SwordRisk:
    potentials_left: int
    potential_effective_max: int
    opponent_sword_replies: int
    opponent_sword_reply_cells_max: int
    opponent_sword_reply_effective_max: int
    indirect_sword_replies: int
    indirect_sword_effective_max: int
    danger_regions_left: int
    collapse_support_hazard: int
    unknown_sword_completions: int
    unknown_sword_effective_max: int
    danger_score: int
    safe: bool


@dataclass(frozen=True)
class MoveEvaluation:
    move: SwapMove
    direct: ResourceResult
    cascade: ResourceResult
    total: ResourceResult
    cascade_rounds: int
    longest_match: int
    clear_rounds: tuple[tuple[Cell, ...], ...]
    result: SimulatedBoard
    known_result: bool
    unknown_exposure: UnknownExposure
    sword_potentials: tuple[SwordPotential, ...]
    sword_replies: tuple[SwordReply, ...]
    sword_danger_regions: tuple[SwordDangerRegion, ...]
    sword_risk: SwordRisk
    calculable: bool

    @property
    def horizontal(self) -> bool:
        return self.move.horizontal

    @property
    def sword_effective(self) -> int:
        return self.total.effective(GemType.SWORD)


@dataclass(frozen=True)
class _CellValue:
    gem: GemType
    multiplier: int | None


Grid = list[list[_CellValue]]


def _candidate_swaps() -> Iterable[SwapMove]:
    for row in range(8):
        for col in range(8):
            if col < 7:
                yield SwapMove((row, col), (row, col + 1))
            if row < 7:
                yield SwapMove((row, col), (row + 1, col))


def _copy_grid(board: BoardState) -> Grid:
    return [
        [_CellValue(cell.gem, cell.multiplier) for cell in row]
        for row in board.cells
    ]


def _match_through(grid: Grid, cell: Cell) -> set[Cell]:
    row, col = cell
    gem = grid[row][col].gem
    if gem is GemType.UNKNOWN:
        return set()
    result: set[Cell] = set()
    left = col
    while left > 0 and grid[row][left - 1].gem is gem:
        left -= 1
    right = col
    while right < 7 and grid[row][right + 1].gem is gem:
        right += 1
    if right - left + 1 >= 3:
        result.update((row, current) for current in range(left, right + 1))
    top = row
    while top > 0 and grid[top - 1][col].gem is gem:
        top -= 1
    bottom = row
    while bottom < 7 and grid[bottom + 1][col].gem is gem:
        bottom += 1
    if bottom - top + 1 >= 3:
        result.update((current, col) for current in range(top, bottom + 1))
    return result


def _scan_runs(grid: Grid) -> list[tuple[set[Cell], int]]:
    runs: list[tuple[set[Cell], int]] = []
    for row in range(8):
        col = 0
        while col < 8:
            gem = grid[row][col].gem
            end = col + 1
            while gem is not GemType.UNKNOWN and end < 8 and grid[row][end].gem is gem:
                end += 1
            if gem is not GemType.UNKNOWN and end - col >= 3:
                runs.append(({(row, value) for value in range(col, end)}, end - col))
            col = end
    for col in range(8):
        row = 0
        while row < 8:
            gem = grid[row][col].gem
            end = row + 1
            while gem is not GemType.UNKNOWN and end < 8 and grid[end][col].gem is gem:
                end += 1
            if gem is not GemType.UNKNOWN and end - row >= 3:
                runs.append(({(value, col) for value in range(row, end)}, end - row))
            row = end
    return runs


def _matches_touching(grid: Grid, displaced: set[Cell]) -> tuple[set[Cell], int]:
    relevant = [run for run in _scan_runs(grid) if run[0] & displaced]
    matched: set[Cell] = set()
    longest = 0
    for cells, length in relevant:
        matched.update(cells)
        longest = max(longest, length)
    return matched, longest


def _tallies(grid: Grid, cells: Iterable[Cell]) -> ResourceResult:
    raw: Counter[GemType] = Counter()
    effective: Counter[GemType] = Counter()
    for row, col in cells:
        value = grid[row][col]
        if value.gem is GemType.UNKNOWN:
            continue
        raw[value.gem] += 1
        effective[value.gem] += value.multiplier or 1
    return ResourceResult(
        tuple(
            (gem, ResourceTally(raw[gem], effective[gem]))
            for gem in GemType
            if gem is not GemType.UNKNOWN and raw[gem]
        )
    )


def _merge_results(*values: ResourceResult) -> ResourceResult:
    raw: Counter[GemType] = Counter()
    effective: Counter[GemType] = Counter()
    for result in values:
        for gem, tally in result.values:
            raw[gem] += tally.cells
            effective[gem] += tally.effective
    return ResourceResult(
        tuple(
            (gem, ResourceTally(raw[gem], effective[gem]))
            for gem in GemType
            if gem is not GemType.UNKNOWN and raw[gem]
        )
    )


def _collapse(grid: Grid, cleared: set[Cell]) -> set[Cell]:
    displaced: set[Cell] = set()
    for col in range(8):
        survivors = [(row, grid[row][col]) for row in range(8) if (row, col) not in cleared]
        missing = 8 - len(survivors)
        column = [_CellValue(GemType.UNKNOWN, None) for _ in range(missing)]
        for index, (source_row, value) in enumerate(survivors):
            target_row = missing + index
            column.append(value)
            if target_row != source_row:
                displaced.add((target_row, col))
        for row, value in enumerate(column):
            grid[row][col] = value
    return displaced


def _freeze(grid: Grid) -> SimulatedBoard:
    return tuple(
        tuple(SimulatedCell(value.gem, value.multiplier) for value in row)
        for row in grid
    )


def _danger_regions(grid: Grid) -> tuple[SwordDangerRegion, ...]:
    regions: dict[tuple[str, tuple[Cell, ...]], SwordDangerRegion] = {}
    lines: list[tuple[str, list[Cell]]] = []
    lines.extend(("row", [(row, col) for col in range(8)]) for row in range(8))
    lines.extend(("column", [(row, col) for row in range(8)]) for col in range(8))
    for axis, line in lines:
        sword_indexes = [index for index, (row, col) in enumerate(line) if grid[row][col].gem is GemType.SWORD]
        for first_index, first in enumerate(sword_indexes):
            for second in sword_indexes[first_index + 1 :]:
                distance = second - first
                if not 1 <= distance <= 3:
                    continue
                cells = tuple(line[index] for index in range(first, second + 1))
                swords = tuple(
                    cell for cell in cells if grid[cell[0]][cell[1]].gem is GemType.SWORD
                )
                gaps = tuple(cell for cell in cells if cell not in swords)
                if not gaps:
                    continue
                region = SwordDangerRegion(
                    axis=axis,
                    cells=cells,
                    sword_cells=swords,
                    gaps=gaps,
                    span=distance,
                    unknown_gap=any(
                        grid[row][col].gem is GemType.UNKNOWN for row, col in gaps
                    ),
                )
                regions[(axis, cells)] = region
    return tuple(regions[key] for key in sorted(regions))


def _resolve_known_reply(
    source: Grid,
    move: SwapMove,
) -> tuple[ResourceResult, ResourceResult, int, Grid] | None:
    """Resolve one opponent move without inventing any off-board refill."""

    grid = [list(row) for row in source]
    first = grid[move.first[0]][move.first[1]]
    second = grid[move.second[0]][move.second[1]]
    if (
        first.gem is GemType.UNKNOWN
        or second.gem is GemType.UNKNOWN
        or first.gem is second.gem
    ):
        return None
    grid[move.first[0]][move.first[1]], grid[move.second[0]][move.second[1]] = (
        second,
        first,
    )
    current = _match_through(grid, move.first) | _match_through(grid, move.second)
    if not current:
        return None

    direct = _tallies(grid, current)
    cascade_results: list[ResourceResult] = []
    clear_rounds = 0
    while current:
        if clear_rounds:
            cascade_results.append(_tallies(grid, current))
        displaced = _collapse(grid, current)
        current, _longest = _matches_touching(grid, displaced)
        clear_rounds += 1
    return (
        direct,
        _merge_results(*cascade_results),
        max(0, clear_rounds - 1),
        grid,
    )


def _known_sword_opportunities(
    grid: Grid,
) -> tuple[tuple[SwordPotential, ...], tuple[SwordReply, ...]]:
    """Find direct and indirect deterministic Sword replies for the opponent."""

    potentials: list[SwordPotential] = []
    replies: list[SwordReply] = []
    for move in _candidate_swaps():
        resolved = _resolve_known_reply(grid, move)
        if resolved is None:
            continue
        direct, cascade, cascade_rounds, _result_grid = resolved
        direct_cells = direct.cells(GemType.SWORD)
        direct_effective = direct.effective(GemType.SWORD)
        cascade_cells = cascade.cells(GemType.SWORD)
        cascade_effective = cascade.effective(GemType.SWORD)
        if direct_cells:
            potentials.append(SwordPotential(move, direct_cells, direct_effective))
        if direct_cells or cascade_cells:
            replies.append(
                SwordReply(
                    move=move,
                    sword_cells=direct_cells + cascade_cells,
                    sword_effective=direct_effective + cascade_effective,
                    direct_sword_effective=direct_effective,
                    cascade_sword_effective=cascade_effective,
                    cascade_rounds=cascade_rounds,
                )
            )
    return tuple(potentials), tuple(replies)


def _known_sword_potentials(grid: Grid) -> tuple[SwordPotential, ...]:
    """Backward-compatible direct-potential view used by older diagnostics."""

    return _known_sword_opportunities(grid)[0]


def evaluate_sword_hold(move: MoveEvaluation) -> SwordHoldEvaluation:
    """Prove the user-approved intentional Sword-hold exception.

    The candidate itself must collect no Sword.  For every deterministic Sword
    reply available to the boss, replay that exact reply and require the known
    settled board to offer us strictly more effective Sword on the following
    move.  UNKNOWN never matches, so this function does not invent refill.
    """

    if move.sword_effective > 0 or not move.sword_replies:
        return SwordHoldEvaluation(move.move, 0, (), False, 0, 0)
    source = [
        [_CellValue(cell.gem, cell.multiplier) for cell in row]
        for row in move.result
    ]
    lines: list[SwordHoldLine] = []
    for reply in move.sword_replies:
        resolved = _resolve_known_reply(source, reply.move)
        if resolved is None:
            continue
        _direct, _cascade, _rounds, reply_result = resolved
        _potentials, followups = _known_sword_opportunities(reply_result)
        followup_max = max(
            (value.sword_effective for value in followups), default=0
        )
        if followup_max > reply.sword_effective:
            lines.append(
                SwordHoldLine(
                    opponent_move=reply.move,
                    opponent_sword_effective=reply.sword_effective,
                    followup_sword_effective=followup_max,
                )
            )
    guaranteed = len(lines) == len(move.sword_replies)
    return SwordHoldEvaluation(
        move=move.move,
        opponent_reply_count=len(move.sword_replies),
        favorable_lines=tuple(lines),
        guaranteed_favorable=guaranteed,
        opponent_sword_effective_max=max(
            (value.sword_effective for value in move.sword_replies), default=0
        ),
        followup_sword_effective_min=(
            min((value.followup_sword_effective for value in lines), default=0)
            if guaranteed
            else 0
        ),
    )


def _hypothetical_unknown_hazard(grid: Grid) -> tuple[int, int]:
    """Count Sword swap potential involving an UNKNOWN refill slot.

    A hypothetical refill Sword that immediately completes a match is part of
    the current move's automatic cascade.  It cannot remain on the settled
    board for the opponent, so it is not a leftover Sword hazard.  There is a
    second, distinct risk: the refill may be a non-Sword and an adjacent known
    Sword may then be swapped *into* that slot to complete a known match.  Test
    both shapes without inventing the refill's actual gem.
    """

    completions = 0
    effective_max = 0
    for row in range(8):
        for col in range(8):
            if grid[row][col].gem is not GemType.UNKNOWN:
                continue
            previous = grid[row][col]
            hypothetical = _CellValue(GemType.SWORD, 1)
            grid[row][col] = hypothetical
            matched = _match_through(grid, (row, col))
            exposure = 0
            if not matched:
                for neighbour in (
                    (row - 1, col),
                    (row + 1, col),
                    (row, col - 1),
                    (row, col + 1),
                ):
                    n_row, n_col = neighbour
                    if not 0 <= n_row < 8 or not 0 <= n_col < 8:
                        continue
                    other = grid[n_row][n_col]
                    if other.gem in (GemType.UNKNOWN, GemType.SWORD):
                        continue
                    grid[row][col], grid[n_row][n_col] = other, hypothetical
                    candidate = _match_through(grid, neighbour)
                    exposure = sum(
                        grid[r][c].multiplier or 1
                        for r, c in candidate
                        if grid[r][c].gem is GemType.SWORD
                    )
                    grid[row][col], grid[n_row][n_col] = hypothetical, other
                    if exposure:
                        break
            # If ``matched`` is non-empty, the refill would auto-clear before
            # the opponent receives a settled board.  It can still be a legal
            # destination for an adjacent known Sword when the actual refill
            # is any non-Sword.  This is the exact shape produced when one
            # row-2 clear drops a known top-row Sword beside two known Swords.
            grid[row][col] = previous
            for neighbour in (
                (row - 1, col),
                (row + 1, col),
                (row, col - 1),
                (row, col + 1),
            ):
                n_row, n_col = neighbour
                if not 0 <= n_row < 8 or not 0 <= n_col < 8:
                    continue
                known_sword = grid[n_row][n_col]
                if known_sword.gem is not GemType.SWORD:
                    continue
                grid[row][col] = known_sword
                grid[n_row][n_col] = previous
                candidate = _match_through(grid, (row, col))
                known_into_unknown = sum(
                    grid[r][c].multiplier or 1
                    for r, c in candidate
                    if grid[r][c].gem is GemType.SWORD
                )
                grid[row][col] = previous
                grid[n_row][n_col] = known_sword
                exposure = max(exposure, known_into_unknown)
            if exposure:
                completions += 1
                effective_max = max(effective_max, exposure)
    return completions, effective_max


def _collapse_support_hazard(
    initial_regions: tuple[SwordDangerRegion, ...],
    clear_rounds: tuple[tuple[Cell, ...], ...],
) -> int:
    cleared_rows_by_column: dict[int, list[int]] = {}
    for round_cells in clear_rounds:
        for row, col in round_cells:
            cleared_rows_by_column.setdefault(col, []).append(row)
    cleared_per_column: Counter[int] = Counter(
        {col: len(rows) for col, rows in cleared_rows_by_column.items()}
    )
    concentrated = {col for col, count in cleared_per_column.items() if count >= 2}
    if not concentrated:
        return 0

    def collapse_reaches(cell: Cell, *, adjacent: bool = False) -> bool:
        """Whether gravity in a cleared column can affect this screen cell.

        Screen row zero is the top.  A clear moves only cells above it down;
        it cannot move a Sword/danger gap that is below every cleared cell.
        """

        row, col = cell
        return any(
            (clear_col != col if adjacent else clear_col == col)
            and (not adjacent or abs(clear_col - col) == 1)
            and any(clear_row >= row for clear_row in cleared_rows_by_column[clear_col])
            for clear_col in concentrated
        )

    hazard = 0
    for region in initial_regions:
        if any(collapse_reaches(cell) for cell in region.gaps):
            hazard += 2
        elif any(collapse_reaches(cell) for cell in region.cells):
            hazard += 1
        elif any(collapse_reaches(cell, adjacent=True) for cell in region.cells):
            hazard += 1
    return hazard


def simulate_move(
    board: BoardState,
    move: SwapMove,
    *,
    initial_regions: tuple[SwordDangerRegion, ...] | None = None,
) -> MoveEvaluation | None:
    grid = _copy_grid(board)
    first = grid[move.first[0]][move.first[1]]
    second = grid[move.second[0]][move.second[1]]
    if first.gem is second.gem:
        return None
    grid[move.first[0]][move.first[1]], grid[move.second[0]][move.second[1]] = (
        second,
        first,
    )
    matched = _match_through(grid, move.first) | _match_through(grid, move.second)
    if not matched:
        return None

    direct = _tallies(grid, matched)
    cascade_results: list[ResourceResult] = []
    clear_rounds: list[tuple[Cell, ...]] = []
    longest = 0
    current = matched
    round_index = 0
    while current:
        cells = tuple(sorted(current))
        clear_rounds.append(cells)
        longest = max(longest, max((len(run[0]) for run in _scan_runs(grid) if run[0] & current), default=3))
        if round_index:
            cascade_results.append(_tallies(grid, current))
        displaced = _collapse(grid, current)
        current, chain_longest = _matches_touching(grid, displaced)
        longest = max(longest, chain_longest)
        round_index += 1

    cascade = _merge_results(*cascade_results)
    total = _merge_results(direct, cascade)
    result = _freeze(grid)
    unknown_by_column: Counter[int] = Counter(
        col
        for row in range(8)
        for col in range(8)
        if grid[row][col].gem is GemType.UNKNOWN
    )
    unknown_completions, unknown_effective = _hypothetical_unknown_hazard(grid)
    exposure = UnknownExposure(
        cells=sum(unknown_by_column.values()),
        columns=tuple(sorted(unknown_by_column.items())),
        max_column_depth=max(unknown_by_column.values(), default=0),
        hypothetical_sword_completions=unknown_completions,
        hypothetical_sword_effective_max=unknown_effective,
    )
    potentials, replies = _known_sword_opportunities(grid)
    regions = _danger_regions(grid)
    before_regions = initial_regions if initial_regions is not None else _danger_regions(_copy_grid(board))
    support_hazard = _collapse_support_hazard(before_regions, tuple(clear_rounds))
    potential_max = max((value.sword_effective for value in potentials), default=0)
    reply_cells_max = max((value.sword_cells for value in replies), default=0)
    reply_effective_max = max((value.sword_effective for value in replies), default=0)
    indirect_replies = tuple(value for value in replies if value.indirect)
    indirect_effective_max = max(
        (value.sword_effective for value in indirect_replies), default=0
    )
    danger_score = (
        reply_effective_max * 100
        + len(replies) * 20
        + unknown_effective * 30
        + unknown_completions * 10
        + support_hazard * 25
        + max(0, exposure.max_column_depth - 1) * 5
    )
    # A calculable low-board horizontal clear that exposes only one new cell
    # per affected column is bounded by the 64 known cells in the user's BASIC
    # model.  Keep the hypothetical refill risk in danger_score for ranking,
    # but do not turn that possibility alone into a forced PASS.  Vertical
    # clears and deeper/multi-layer refills remain fail-closed.
    calculable = min(row for row, _col in clear_rounds[0]) >= 2
    bounded_horizontal_refill = bool(
        move.horizontal
        and calculable
        and exposure.max_column_depth <= 1
    )
    safe = bool(
        # User rule: a resource move is safe only when its direct clear starts
        # at screen row 3 or lower. A top-area clear necessarily depends on
        # off-board refill before its post-collapse Sword shape is knowable;
        # absence of one hypothetical UNKNOWN-Sword completion is not proof of
        # safety. Sword collection itself remains a separate higher-priority
        # branch and mandatory turns retain their least-risk fallback.
        calculable
        and reply_effective_max == 0
        and support_hazard == 0
        and (unknown_effective == 0 or bounded_horizontal_refill)
    )
    risk = SwordRisk(
        potentials_left=len(potentials),
        potential_effective_max=potential_max,
        opponent_sword_replies=len(replies),
        opponent_sword_reply_cells_max=reply_cells_max,
        opponent_sword_reply_effective_max=reply_effective_max,
        indirect_sword_replies=len(indirect_replies),
        indirect_sword_effective_max=indirect_effective_max,
        danger_regions_left=len(regions),
        collapse_support_hazard=support_hazard,
        unknown_sword_completions=unknown_completions,
        unknown_sword_effective_max=unknown_effective,
        danger_score=danger_score,
        safe=safe,
    )
    return MoveEvaluation(
        move=move,
        direct=direct,
        cascade=cascade,
        total=total,
        cascade_rounds=max(0, len(clear_rounds) - 1),
        longest_match=longest,
        clear_rounds=tuple(clear_rounds),
        result=result,
        known_result=exposure.cells == 0,
        unknown_exposure=exposure,
        sword_potentials=potentials,
        sword_replies=replies,
        sword_danger_regions=regions,
        sword_risk=risk,
        # User terminology is one-based: row 3 downward => screen row >= 2.
        calculable=calculable,
    )


def evaluate_all_moves(board: BoardState) -> tuple[MoveEvaluation, ...]:
    """Exhaustively evaluate all 112 adjacent pairs, returning legal swaps."""

    initial_regions = _danger_regions(_copy_grid(board))
    values = [
        result
        for move in _candidate_swaps()
        if (result := simulate_move(board, move, initial_regions=initial_regions))
        is not None
    ]
    return tuple(values)


def board_sword_danger_regions(board: BoardState) -> tuple[SwordDangerRegion, ...]:
    return _danger_regions(_copy_grid(board))
