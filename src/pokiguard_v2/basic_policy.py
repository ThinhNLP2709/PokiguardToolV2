"""Explainable Phase 2C.2A BASIC gameplay policy.

This module only proposes actions.  It has no input, click, process-write,
network, or game-method call path.
"""

from __future__ import annotations

from dataclasses import dataclass, replace
from enum import Enum

from .board_simulator import (
    MoveEvaluation,
    SwapMove,
    SwordHoldEvaluation,
    evaluate_all_moves,
    evaluate_sword_hold,
)
from .gameplay_profile import (
    DamageCardMode,
    EvolutionTarget,
    MainPetType,
    PetSkillFireCondition,
)
from .pet_skill_shadow import (
    PetSkillCapability,
    PetSkillCapabilityStatus,
    PetSkillFamily,
)
from .state import (
    BoardState,
    CardState,
    CombatSessionKey,
    GameOwnedIdleStatus,
    GamePhase,
    GameState,
    GemType,
)


PET_SKILL_FIRE_VALUE_DEFAULT = 10
PET_SKILL_FIRE_VALUE_MINIMUM = 0
PET_SKILL_FIRE_VALUE_MAXIMUM = 256
# Narrow source-compatibility aliases for historical analyzers and imports.
SKILL_RUSH_SWORD_THRESHOLD_DEFAULT = PET_SKILL_FIRE_VALUE_DEFAULT
SKILL_RUSH_SWORD_THRESHOLD_MINIMUM = PET_SKILL_FIRE_VALUE_MINIMUM
SKILL_RUSH_SWORD_THRESHOLD_MAXIMUM = PET_SKILL_FIRE_VALUE_MAXIMUM
# Retained as a source-compatibility symbol for historical analyzers. Current
# Skill Rush finishing is ratio-based and does not use an absolute HP shortcut.
SKILL_RUSH_FINISHER_RATIO = 0.30
SKILL_RUSH_SURVIVAL_HP_RATIO = 0.30


class PlayStyle(str, Enum):
    SIMPLE = "simple"
    CAREFUL = "careful"
    SKILL_RUSH = "skill_rush"


class ManaPriority(str, Enum):
    EVOLUTION = "evolution"
    ATTACK = "attack"


class Intelligence(str, Enum):
    BASIC = "basic"
    REASONING = "reasoning"


class PolicyAction(str, Enum):
    EVOLVE = "evolve"
    CAST = "cast"
    PET_SKILL = "pet_skill"
    SWAP = "swap"
    PASS = "pass"
    EXIT_MATCH = "exit_match"
    NONE = "none"


class SkillRushFireTrigger(str, Enum):
    CONDITION_READY = "SKILL_RUSH_FIRE_CONDITION_READY"


class SkillRushSetupFallbackType(str, Enum):
    RELAXED_DISTANCE = "RELAXED_DISTANCE"
    BOARD_TURNOVER = "BOARD_TURNOVER"
    FORCED_PRE_SKILL_SWORD_CONSUMPTION = "FORCED_PRE_SKILL_SWORD_CONSUMPTION"
    MANDATORY_FALLBACK = "MANDATORY_FALLBACK"


class SkillRushFinisherTrigger(str, Enum):
    ABSOLUTE_HP = "ABSOLUTE_HP"
    RELATIVE_HP = "RELATIVE_HP"
    BOTH = "BOTH"
    NONE = "NONE"


class SkillRushFinisherAction(str, Enum):
    SWORD = "SWORD"
    DEFAULT_ATTACK = "DEFAULT_ATTACK"
    SECOND_PET_SKILL = "SECOND_PET_SKILL"
    OTHER_EXISTING_FALLBACK = "OTHER_EXISTING_FALLBACK"


@dataclass(frozen=True)
class SkillRushMatchContext:
    """Non-persistent proof of accepted Pet Skills in one combat session."""

    session_key: CombatSessionKey
    successful_pet_skills: int = 0
    latest_success_source_turn: int | None = None

    def __post_init__(self) -> None:
        if self.successful_pet_skills < 0:
            raise ValueError("successful_pet_skills cannot be negative")
        if self.latest_success_source_turn is not None and self.latest_success_source_turn < 0:
            raise ValueError("latest_success_source_turn cannot be negative")
        if self.successful_pet_skills == 0 and self.latest_success_source_turn is not None:
            raise ValueError("a success source turn requires a successful Pet Skill")
        if self.successful_pet_skills > 0 and self.latest_success_source_turn is None:
            raise ValueError("successful Pet Skill history requires its latest source turn")


@dataclass(frozen=True)
class PolicyConfig:
    play_style: PlayStyle = PlayStyle.SIMPLE
    # Kept only for old direct PolicyConfig fixtures. Canonical production
    # configuration sets this to None and uses the three fields below.
    mana_priority: ManaPriority | None = ManaPriority.EVOLUTION
    intelligence: Intelligence = Intelligence.BASIC
    main_pet: MainPetType = MainPetType.NORMAL
    evolution: EvolutionTarget = EvolutionTarget.NORMAL
    damage_card: DamageCardMode = DamageCardMode.DEFAULT_ATTACK
    minimum_turn_time_seconds: int = 3
    # Affordable EVOLVE is the shared Step-1 branch on every local turn. This
    # is the same inclusive hard input floor as normal gameplay; after its
    # mandatory reread the selected play style still ends the local turn.
    minimum_evolve_time_seconds: int = 1
    # Step 3 finisher: once the boss is at or below this absolute current HP,
    # a Sword-free board casts as soon as one Attack card is affordable.
    # 0 disables the finisher entirely.
    cast_when_boss_hp_below: int = 30_000
    # Step 5 stockpile rule: cast only above this mana so a 320 reserve
    # (two casts) survives the 160 cost.
    cast_mana_stockpile_threshold: int = 480
    # Step 3 Rage floor; reaching it boosts Sword damage.
    rage_target: int = 100
    # Step 4 low-HP thresholds per play style.
    low_hp_ratio_simple: float = 0.30
    low_hp_ratio_careful: float = 0.50
    # Step 5 boss-resource branches.
    boss_high_mana: int = 160
    boss_high_rage: int = 100
    boss_low_resource: int = 50
    # Normal Pet Skill fire condition. Count-based conditions use inclusive >= and
    # a maximum of 63 so every accepted value remains satisfiable on 64 cells.
    pet_skill_fire_condition: PetSkillFireCondition = PetSkillFireCondition.SWORD_COUNT
    pet_skill_fire_value: int | None = PET_SKILL_FIRE_VALUE_DEFAULT

    def __post_init__(self) -> None:
        for name, enum_type in (
            ("play_style", PlayStyle),
            ("intelligence", Intelligence),
            ("main_pet", MainPetType),
            ("evolution", EvolutionTarget),
            ("damage_card", DamageCardMode),
            ("pet_skill_fire_condition", PetSkillFireCondition),
        ):
            if not isinstance(getattr(self, name), enum_type):
                raise ValueError(f"{name} must be {enum_type.__name__}")
        if self.mana_priority is not None and not isinstance(
            self.mana_priority, ManaPriority
        ):
            raise ValueError("mana_priority must be ManaPriority or None")
        if not 0 <= self.minimum_turn_time_seconds <= 14:
            raise ValueError("minimum_turn_time_seconds must be between 0 and 14")
        if not 0 <= self.minimum_evolve_time_seconds <= 14:
            raise ValueError(
                "minimum_evolve_time_seconds must be between 0 and 14"
            )
        if self.cast_when_boss_hp_below < 0:
            raise ValueError("cast_when_boss_hp_below must be >= 0")
        if self.cast_mana_stockpile_threshold < 0:
            raise ValueError("cast_mana_stockpile_threshold must be >= 0")
        if self.rage_target < 0:
            raise ValueError("rage_target must be >= 0")
        for name in ("boss_high_mana", "boss_high_rage", "boss_low_resource"):
            if getattr(self, name) < 0:
                raise ValueError(f"{name} must be >= 0")
        if self.pet_skill_fire_condition.uses_board_count:
            if (
                type(self.pet_skill_fire_value) is not int
                or not PET_SKILL_FIRE_VALUE_MINIMUM
                <= self.pet_skill_fire_value
                <= PET_SKILL_FIRE_VALUE_MAXIMUM
            ):
                raise ValueError(
                    "pet_skill_fire_value must be an integer between 0 and 256 "
                    "for a board-count condition"
                )
        elif self.pet_skill_fire_value is not None:
            raise ValueError(
                "pet_skill_fire_value must be None for skill_cost_ready"
            )
        for name in ("low_hp_ratio_simple", "low_hp_ratio_careful"):
            value = getattr(self, name)
            if not 0.0 <= value <= 1.0:
                raise ValueError(f"{name} must be between 0 and 1")

    @property
    def low_hp_ratio(self) -> float:
        return (
            self.low_hp_ratio_careful
            if self.play_style is PlayStyle.CAREFUL
            else self.low_hp_ratio_simple
        )

    @property
    def pet_skill_profile(self) -> bool:
        skill_sources = int(self.main_pet is MainPetType.LEGENDARY) + int(
            self.evolution is EvolutionTarget.LEGENDARY
        )
        return bool(
            self.damage_card is DamageCardMode.PET_SKILL
            and skill_sources == 1
        )

    @property
    def pet_skill_waits_for_evolution(self) -> bool:
        return bool(
            self.damage_card is DamageCardMode.PET_SKILL
            and self.main_pet is not MainPetType.LEGENDARY
            and self.evolution is EvolutionTarget.LEGENDARY
        )

    @property
    def evolve_enabled(self) -> bool:
        if self.mana_priority is not None:
            return self.mana_priority is ManaPriority.EVOLUTION
        return self.evolution is not EvolutionTarget.NONE


@dataclass(frozen=True)
class CandidateTrace:
    move: SwapMove
    horizontal: bool
    calculable: bool
    direct_resources: tuple[tuple[str, int, int], ...]
    cascade_resources: tuple[tuple[str, int, int], ...]
    total_resources: tuple[tuple[str, int, int], ...]
    known_cascades: int
    longest_match: int
    sword_effective: int
    sword_potentials_left: int
    sword_potential_effective_max: int
    opponent_sword_replies: int
    opponent_sword_reply_cells_max: int
    opponent_sword_reply_effective_max: int
    indirect_sword_replies: int
    indirect_sword_effective_max: int
    sword_danger_regions: int
    collapse_support_hazard: int
    unknown_cells: int
    unknown_max_column_depth: int
    unknown_sword_completions: int
    unknown_sword_effective_max: int
    refill_sword_auto_match_completions: int
    refill_sword_auto_match_effective_max: int
    danger_score: int
    safe: bool
    known_mana_gain: int
    known_rage_gain: int
    requirements_completed_after_move: int
    readiness_progress: float
    hard_survival_status: str
    known_sword_consumed: int
    known_sword_preserved: int
    cleared_non_sword_zero_sword_axes: int
    cleared_non_sword_low_sword_axes: int
    cleared_row_sword_density: tuple[tuple[int, int], ...]
    cleared_column_sword_density: tuple[tuple[int, int], ...]
    cleared_non_sword_min_sword_distance: int | None
    cleared_non_sword_adjacent_to_sword: int
    cleared_non_sword_distance_two_plus: int


@dataclass(frozen=True)
class DecisionTrace:
    selected_action: PolicyAction
    policy_step: str
    candidate_count: int
    why_selected: str
    failed_higher_priority_branches: tuple[str, ...]
    candidates: tuple[CandidateTrace, ...]
    selected_candidate: CandidateTrace | None
    skip_count: int | None
    skip_threshold: int | None
    skip_source: str | None
    skip_status: GameOwnedIdleStatus
    first_local_turn: bool | None
    turn_number: int | None
    turn_time_remaining_seconds: int | None
    turn_timer_source: str | None
    play_style: str
    profile: tuple[str, str, str]
    skill_capability_status: str | None
    skill_family: str | None
    required_mana: int | None
    required_rage: int | None
    current_mana: int | None
    current_rage: int | None
    missing_mana: int | None
    missing_rage: int | None
    skill_ready: bool | None
    skill_actionable: bool | None
    pet_skill_candidate: bool
    skipped_current_sword_for_resource: bool
    selected_move_left_direct_boss_sword: bool
    selected_move_left_indirect_boss_sword: bool
    boss_hp: int | None
    boss_max_hp: int | None
    boss_hp_ratio: float | None
    known_sword_count: int | None
    known_sword_effective_count: int | None
    pet_skill_fire_condition: str
    pet_skill_fire_value: int | None
    selected_fire_gem_type: str | None
    selected_known_gem_count: int | None
    selected_known_gem_effective_count: int | None
    selected_fire_condition_ready: bool | None
    # Backward-compatible derived Sword diagnostics for historical readers.
    configured_sword_threshold: int | None
    sword_threshold_ready: bool | None
    skill_fire_trigger: str | None
    pet_skill_success_count_current_match: int
    post_skill_boss_hp: int | None
    post_skill_boss_hp_ratio: float | None
    post_skill_finisher_ready: bool
    finisher_trigger: str
    finisher_action: str | None
    setup_blocked: bool = False
    preferred_setup_candidate_count: int = 0
    relaxed_setup_candidate_count: int = 0
    minimum_available_sword_distance: int | None = None
    sword_consumed_by_relaxed_move: int | None = None
    setup_fallback_type: str | None = None
    blocker: str | None = None


@dataclass(frozen=True)
class PolicyDecision:
    action: PolicyAction
    trace: DecisionTrace
    move: SwapMove | None = None
    card_object_address: int | None = None
    skill_card_id: int | None = None
    skill_session_key: object | None = None
    consumes_turn: bool = False
    requires_state_reread: bool = False


@dataclass(frozen=True)
class PetSkillPolicyContext:
    capability_status: str | None
    family: str | None
    required_mana: int | None
    required_rage: int | None
    current_mana: int | None
    current_rage: int | None
    missing_mana: int | None
    missing_rage: int | None
    ready: bool | None
    actionable: bool | None
    candidate: bool


@dataclass(frozen=True)
class SkillRushPolicyContext:
    boss_hp: int | None = None
    boss_max_hp: int | None = None
    boss_hp_ratio: float | None = None
    known_sword_count: int | None = None
    known_sword_effective_count: int | None = None
    pet_skill_fire_condition: PetSkillFireCondition = PetSkillFireCondition.SWORD_COUNT
    pet_skill_fire_value: int | None = PET_SKILL_FIRE_VALUE_DEFAULT
    selected_fire_gem_type: GemType | None = GemType.SWORD
    selected_known_gem_count: int | None = None
    selected_known_gem_effective_count: int | None = None
    selected_fire_condition_ready: bool | None = None
    configured_sword_threshold: int | None = None
    sword_threshold_ready: bool | None = None
    fire_trigger: SkillRushFireTrigger | None = None
    successful_pet_skills: int = 0
    post_skill_finisher_ready: bool = False
    finisher_trigger: SkillRushFinisherTrigger = SkillRushFinisherTrigger.NONE
    finisher_action: SkillRushFinisherAction | None = None
    setup_blocked: bool = False
    preferred_setup_candidate_count: int = 0
    relaxed_setup_candidate_count: int = 0
    minimum_available_sword_distance: int | None = None
    sword_consumed_by_relaxed_move: int | None = None
    setup_fallback_type: SkillRushSetupFallbackType | None = None


_FIRE_CONDITION_GEM_TYPE = {
    PetSkillFireCondition.SWORD_COUNT: GemType.SWORD,
    PetSkillFireCondition.MANA_GEM_COUNT: GemType.MANA,
    PetSkillFireCondition.RAGE_GEM_COUNT: GemType.RAGE,
    PetSkillFireCondition.DRAIN_GEM_COUNT: GemType.DRAIN,
    PetSkillFireCondition.SHIELD_GEM_COUNT: GemType.SHIELD,
}


def _known_gem_cell_count(board: BoardState, gem_type: GemType) -> int:
    return sum(
        cell.gem is gem_type
        for row in board.cells
        for cell in row
    )


def _known_gem_effective_count(board: BoardState, gem_type: GemType) -> int:
    """Return known board value with x2/x3/x4 multipliers included."""

    return sum(
        cell.multiplier
        for row in board.cells
        for cell in row
        if cell.gem is gem_type
    )


def _known_gem_count(board: BoardState, gem_type: GemType) -> int:
    """Return the physical number of known cells for compatibility telemetry."""

    return _known_gem_cell_count(board, gem_type)


def _known_sword_count(board: BoardState) -> int:
    return _known_gem_count(board, GemType.SWORD)


def _known_sword_effective_count(board: BoardState) -> int:
    return _known_gem_effective_count(board, GemType.SWORD)


def _known_result_sword_count(value: MoveEvaluation) -> int:
    return _known_result_gem_count(value, GemType.SWORD)


def _known_result_gem_count(
    value: MoveEvaluation,
    gem_type: GemType,
) -> int:
    return sum(
        cell.gem is gem_type
        for row in value.result
        for cell in row
    )


def _known_result_gem_effective_count(
    value: MoveEvaluation,
    gem_type: GemType,
) -> int:
    return sum(
        cell.multiplier or 1
        for row in value.result
        for cell in row
        if cell.gem is gem_type
    )


def _skill_rush_board_metrics(
    board: BoardState | None,
    value: MoveEvaluation,
) -> tuple[
    int,
    int,
    int,
    int,
    tuple[tuple[int, int], ...],
    tuple[tuple[int, int], ...],
    int | None,
    int,
    int,
]:
    """Measure only known board effects; UNKNOWN refill receives no credit."""

    consumed = value.total.cells(GemType.SWORD)
    preserved = _known_result_sword_count(value)
    if board is None or not value.clear_rounds:
        return consumed, preserved, 0, 0, (), (), None, 0, 0

    row_density = tuple(
        sum(cell.gem is GemType.SWORD for cell in row)
        for row in board.cells
    )
    column_density = tuple(
        sum(board.cells[row][col].gem is GemType.SWORD for row in range(8))
        for col in range(8)
    )

    # The first clear round is the only one whose cell identities can be tied
    # exactly to the current authoritative board. Later known cascades occur
    # after gravity and are already represented in the result/preservation
    # counts; they are not relabelled using stale pre-collapse coordinates.
    direct_cells = value.clear_rounds[0]
    swapped_gems = {
        value.move.first: board.cells[value.move.second[0]][value.move.second[1]].gem,
        value.move.second: board.cells[value.move.first[0]][value.move.first[1]].gem,
    }
    post_swap_swords = tuple(
        (row, col)
        for row in range(8)
        for col in range(8)
        if swapped_gems.get((row, col), board.cells[row][col].gem)
        is GemType.SWORD
    )
    non_sword_cells = tuple(
        (row, col)
        for row, col in direct_cells
        if swapped_gems.get((row, col), board.cells[row][col].gem)
        not in {GemType.SWORD, GemType.UNKNOWN}
    )
    zero_axes = sum(
        int(row_density[row] == 0) + int(column_density[col] == 0)
        for row, col in non_sword_cells
    )
    low_axes = sum(
        int(row_density[row] <= 1) + int(column_density[col] <= 1)
        for row, col in non_sword_cells
    )
    rows = tuple(sorted({row for row, _col in non_sword_cells}))
    columns = tuple(sorted({col for _row, col in non_sword_cells}))
    sword_distances = tuple(
        min(
            (
                abs(row - sword_row) + abs(col - sword_col)
                for sword_row, sword_col in post_swap_swords
            ),
            default=15,
        )
        for row, col in non_sword_cells
    )
    return (
        consumed,
        preserved,
        zero_axes,
        low_axes,
        tuple((row, row_density[row]) for row in rows),
        tuple((col, column_density[col]) for col in columns),
        min(sword_distances, default=None),
        sum(distance < 2 for distance in sword_distances),
        sum(distance >= 2 for distance in sword_distances),
    )


def _resource_trace(value: MoveEvaluation, attribute: str) -> tuple[tuple[str, int, int], ...]:
    result = getattr(value, attribute)
    return tuple(
        (gem.value, tally.cells, tally.effective)
        for gem, tally in result.values
    )


def _candidate_trace(
    value: MoveEvaluation,
    *,
    board: BoardState | None = None,
    required_mana: int | None = None,
    required_rage: int | None = None,
    missing_mana: int | None = None,
    missing_rage: int | None = None,
) -> CandidateTrace:
    risk = value.sword_risk
    exposure = value.unknown_exposure
    mana_gain = value.total.effective(GemType.MANA)
    rage_gain = value.total.effective(GemType.RAGE)
    completed = 0
    progress = 0.0
    if required_mana and missing_mana is not None and missing_mana > 0:
        completed += int(mana_gain >= missing_mana)
        progress += min(mana_gain, missing_mana) / required_mana
    if required_rage and missing_rage is not None and missing_rage > 0:
        completed += int(rage_gain >= missing_rage)
        progress += min(rage_gain, missing_rage) / required_rage
    (
        known_sword_consumed,
        known_sword_preserved,
        zero_sword_axes,
        low_sword_axes,
        row_sword_density,
        column_sword_density,
        min_sword_distance,
        adjacent_to_sword,
        distance_two_plus,
    ) = _skill_rush_board_metrics(board, value)
    return CandidateTrace(
        move=value.move,
        horizontal=value.horizontal,
        calculable=value.calculable,
        direct_resources=_resource_trace(value, "direct"),
        cascade_resources=_resource_trace(value, "cascade"),
        total_resources=_resource_trace(value, "total"),
        known_cascades=value.cascade_rounds,
        longest_match=value.longest_match,
        sword_effective=value.sword_effective,
        sword_potentials_left=risk.potentials_left,
        sword_potential_effective_max=risk.potential_effective_max,
        opponent_sword_replies=risk.opponent_sword_replies,
        opponent_sword_reply_cells_max=risk.opponent_sword_reply_cells_max,
        opponent_sword_reply_effective_max=(
            risk.opponent_sword_reply_effective_max
        ),
        indirect_sword_replies=risk.indirect_sword_replies,
        indirect_sword_effective_max=risk.indirect_sword_effective_max,
        sword_danger_regions=risk.danger_regions_left,
        collapse_support_hazard=risk.collapse_support_hazard,
        unknown_cells=exposure.cells,
        unknown_max_column_depth=exposure.max_column_depth,
        unknown_sword_completions=exposure.hypothetical_sword_completions,
        unknown_sword_effective_max=exposure.hypothetical_sword_effective_max,
        refill_sword_auto_match_completions=(
            exposure.refill_sword_auto_match_completions
        ),
        refill_sword_auto_match_effective_max=(
            exposure.refill_sword_auto_match_effective_max
        ),
        danger_score=risk.danger_score,
        safe=risk.safe,
        known_mana_gain=mana_gain,
        known_rage_gain=rage_gain,
        requirements_completed_after_move=completed,
        readiness_progress=progress,
        # The current simulator proves board outcomes and Sword replies, but it
        # has no authoritative damage-to-HP model.  Preserve that boundary in
        # every candidate instead of relabeling strategic risk as lethal/safe.
        hard_survival_status="UNKNOWN_NO_LETHALITY_MODEL",
        known_sword_consumed=known_sword_consumed,
        known_sword_preserved=known_sword_preserved,
        cleared_non_sword_zero_sword_axes=zero_sword_axes,
        cleared_non_sword_low_sword_axes=low_sword_axes,
        cleared_row_sword_density=row_sword_density,
        cleared_column_sword_density=column_sword_density,
        cleared_non_sword_min_sword_distance=min_sword_distance,
        cleared_non_sword_adjacent_to_sword=adjacent_to_sword,
        cleared_non_sword_distance_two_plus=distance_two_plus,
    )


def _attack_cost(card: CardState) -> int:
    if card.mana_cost > 0:
        return card.mana_cost
    if card.condition_use is not None and card.condition_use > 0:
        return int(card.condition_use)
    # CAST is never proposed from a guessed default. The live card must expose
    # its actual positive cost through CardData.manaCost or conditionUse.
    return 2**63 - 1


def _boss(state: GameState):
    return next(
        (opponent for opponent in state.opponents if opponent.is_boss is True),
        state.opponents[0] if state.opponents else None,
    )


def _ratio(current: int | None, maximum: int | None) -> float | None:
    if current is None or maximum is None or maximum <= 0:
        return None
    return max(0.0, min(1.0, current / maximum))


def _skill_rush_fire_trigger(
    *,
    selected_condition_ready: bool,
) -> SkillRushFireTrigger | None:
    if selected_condition_ready:
        return SkillRushFireTrigger.CONDITION_READY
    return None


class BasicPolicyEngine:
    """Apply the user-specified BASIC rules in their exact priority order."""

    def __init__(self, config: PolicyConfig | None = None) -> None:
        self.config = config or PolicyConfig()
        self._skill_trace = PetSkillPolicyContext(
            None, None, None, None, None, None, None, None, None, None, False
        )
        self._skill_rush_trace = SkillRushPolicyContext()

    def _decision(
        self,
        state: GameState,
        action: PolicyAction,
        step: str,
        why: str,
        failures: list[str],
        evaluations: tuple[MoveEvaluation, ...],
        *,
        selected: MoveEvaluation | None = None,
        card: CardState | None = None,
        skill: PetSkillCapability | None = None,
        blocker: str | None = None,
        candidate_count: int | None = None,
    ) -> PolicyDecision:
        skill_trace = self._skill_trace
        trace_kwargs = dict(
            required_mana=skill_trace.required_mana,
            required_rage=skill_trace.required_rage,
            missing_mana=skill_trace.missing_mana,
            missing_rage=skill_trace.missing_rage,
        )
        candidates = tuple(
            _candidate_trace(value, board=state.board, **trace_kwargs)
            for value in evaluations
        )
        selected_trace = (
            _candidate_trace(selected, board=state.board, **trace_kwargs)
            if selected is not None
            else None
        )
        rush_trace = self._skill_rush_trace
        skill_rush_resource = step == "SKILL_RUSH_RESOURCE_PROGRESS"
        skipped_current_sword = bool(
            skill_rush_resource
            and selected is not None
            and any(
                value.sword_effective > selected.sword_effective
                for value in evaluations
            )
        )
        trace = DecisionTrace(
            selected_action=action,
            policy_step=step,
            candidate_count=(
                candidate_count if candidate_count is not None else len(evaluations)
            ),
            why_selected=why,
            failed_higher_priority_branches=tuple(failures),
            candidates=candidates,
            selected_candidate=selected_trace,
            skip_count=state.battle.consecutive_passes,
            skip_threshold=state.battle.consecutive_pass_threshold,
            skip_source=state.battle.consecutive_pass_source,
            skip_status=state.battle.consecutive_pass_status,
            first_local_turn=state.battle.is_first_local_turn,
            turn_number=state.battle.turn_number,
            turn_time_remaining_seconds=state.battle.turn_time_remaining_seconds,
            turn_timer_source=state.battle.turn_timer_source,
            play_style=self.config.play_style.value,
            profile=(
                self.config.main_pet.value,
                self.config.evolution.value,
                self.config.damage_card.value,
            ),
            skill_capability_status=skill_trace.capability_status,
            skill_family=skill_trace.family,
            required_mana=skill_trace.required_mana,
            required_rage=skill_trace.required_rage,
            current_mana=skill_trace.current_mana,
            current_rage=skill_trace.current_rage,
            missing_mana=skill_trace.missing_mana,
            missing_rage=skill_trace.missing_rage,
            skill_ready=skill_trace.ready,
            skill_actionable=skill_trace.actionable,
            pet_skill_candidate=skill_trace.candidate,
            skipped_current_sword_for_resource=skipped_current_sword,
            selected_move_left_direct_boss_sword=bool(
                selected_trace is not None
                and selected_trace.opponent_sword_replies > 0
            ),
            selected_move_left_indirect_boss_sword=bool(
                selected_trace is not None
                and selected_trace.indirect_sword_replies > 0
            ),
            boss_hp=rush_trace.boss_hp,
            boss_max_hp=rush_trace.boss_max_hp,
            boss_hp_ratio=rush_trace.boss_hp_ratio,
            known_sword_count=rush_trace.known_sword_count,
            known_sword_effective_count=(
                rush_trace.known_sword_effective_count
            ),
            pet_skill_fire_condition=rush_trace.pet_skill_fire_condition.value,
            pet_skill_fire_value=rush_trace.pet_skill_fire_value,
            selected_fire_gem_type=(
                rush_trace.selected_fire_gem_type.value
                if rush_trace.selected_fire_gem_type is not None
                else None
            ),
            selected_known_gem_count=rush_trace.selected_known_gem_count,
            selected_known_gem_effective_count=(
                rush_trace.selected_known_gem_effective_count
            ),
            selected_fire_condition_ready=(
                rush_trace.selected_fire_condition_ready
            ),
            configured_sword_threshold=rush_trace.configured_sword_threshold,
            sword_threshold_ready=rush_trace.sword_threshold_ready,
            skill_fire_trigger=(
                rush_trace.fire_trigger.value
                if rush_trace.fire_trigger is not None
                else None
            ),
            pet_skill_success_count_current_match=(
                rush_trace.successful_pet_skills
            ),
            post_skill_boss_hp=(
                rush_trace.boss_hp
                if rush_trace.successful_pet_skills > 0
                else None
            ),
            post_skill_boss_hp_ratio=(
                rush_trace.boss_hp_ratio
                if rush_trace.successful_pet_skills > 0
                else None
            ),
            post_skill_finisher_ready=rush_trace.post_skill_finisher_ready,
            finisher_trigger=rush_trace.finisher_trigger.value,
            finisher_action=(
                rush_trace.finisher_action.value
                if rush_trace.finisher_action is not None
                else None
            ),
            setup_blocked=rush_trace.setup_blocked,
            preferred_setup_candidate_count=(
                rush_trace.preferred_setup_candidate_count
            ),
            relaxed_setup_candidate_count=(
                rush_trace.relaxed_setup_candidate_count
            ),
            minimum_available_sword_distance=(
                rush_trace.minimum_available_sword_distance
            ),
            sword_consumed_by_relaxed_move=(
                rush_trace.sword_consumed_by_relaxed_move
            ),
            setup_fallback_type=(
                rush_trace.setup_fallback_type.value
                if rush_trace.setup_fallback_type is not None
                else None
            ),
            blocker=blocker,
        )
        return PolicyDecision(
            action=action,
            trace=trace,
            move=selected.move if selected is not None else None,
            card_object_address=card.object_address if card is not None else None,
            skill_card_id=skill.skill_card_id if skill is not None else None,
            skill_session_key=skill.session_key if skill is not None else None,
            consumes_turn=action in {
                PolicyAction.CAST,
                PolicyAction.PET_SKILL,
                PolicyAction.SWAP,
                PolicyAction.PASS,
            },
            requires_state_reread=action is PolicyAction.EVOLVE,
        )

    @staticmethod
    def _sword_rank(value: MoveEvaluation) -> tuple[object, ...]:
        risk = value.sword_risk
        return (
            risk.opponent_sword_reply_effective_max > 0,
            -value.sword_effective,
            -value.total.effective(GemType.RAGE),
            -value.cascade_rounds,
            -value.total.total_effective,
            risk.danger_score,
            value.unknown_exposure.cells,
            not value.horizontal,
            not value.calculable,
            value.move,
        )

    @staticmethod
    def _resource_rank(value: MoveEvaluation, gem: GemType) -> tuple[object, ...]:
        return (
            -value.total.effective(gem),
            value.sword_risk.danger_score,
            -value.cascade_rounds,
            value.unknown_exposure.cells,
            not value.horizontal,
            not value.calculable,
            value.move,
        )

    def _pet_skill_resource_rank(self, value: MoveEvaluation) -> tuple[object, ...]:
        context = self._skill_trace
        trace = _candidate_trace(
            value,
            required_mana=context.required_mana,
            required_rage=context.required_rage,
            missing_mana=context.missing_mana,
            missing_rage=context.missing_rage,
        )
        return (
            -trace.requirements_completed_after_move,
            -trace.readiness_progress,
            value.sword_risk.danger_score,
            -value.cascade_rounds,
            value.unknown_exposure.cells,
            not value.horizontal,
            not value.calculable,
            value.move,
        )

    def _skill_rush_resource_rank(
        self,
        value: MoveEvaluation,
        board: BoardState,
    ) -> tuple[object, ...]:
        """Rank current deficits first, then preserve known Sword on ties."""

        context = self._skill_trace
        trace = _candidate_trace(
            value,
            board=board,
            required_mana=context.required_mana,
            required_rage=context.required_rage,
            missing_mana=context.missing_mana,
            missing_rage=context.missing_rage,
        )
        return (
            -trace.requirements_completed_after_move,
            -trace.readiness_progress,
            trace.known_sword_consumed,
            -trace.known_sword_preserved,
            not value.calculable,
            value.unknown_exposure.cells,
            -trace.cleared_non_sword_zero_sword_axes,
            -trace.cleared_non_sword_low_sword_axes,
            -value.cascade_rounds,
            -(value.total.total_effective - value.sword_effective),
            value.sword_risk.danger_score,
            not value.horizontal,
            value.move,
        )

    @staticmethod
    def _skill_rush_setup_rank(
        value: MoveEvaluation,
        board: BoardState,
    ) -> tuple[object, ...]:
        """Preserve Sword and turn over known non-Sword cells in sparse axes."""

        trace = _candidate_trace(value, board=board)
        drain = value.total.effective(GemType.DRAIN)
        shield = value.total.effective(GemType.SHIELD)
        return (
            trace.known_sword_consumed,
            -trace.known_sword_preserved,
            trace.refill_sword_auto_match_effective_max,
            trace.refill_sword_auto_match_completions,
            value.sword_risk.opponent_sword_reply_effective_max,
            value.sword_risk.opponent_sword_replies,
            value.sword_risk.potential_effective_max,
            value.sword_risk.potentials_left,
            value.sword_risk.danger_regions_left,
            value.sword_risk.collapse_support_hazard,
            drain <= 0,
            -drain,
            shield <= 0,
            -shield,
            trace.cleared_non_sword_adjacent_to_sword,
            -(
                trace.cleared_non_sword_min_sword_distance
                if trace.cleared_non_sword_min_sword_distance is not None
                else 15
            ),
            -trace.cleared_non_sword_distance_two_plus,
            not value.calculable,
            value.unknown_exposure.cells,
            -trace.cleared_non_sword_zero_sword_axes,
            -trace.cleared_non_sword_low_sword_axes,
            -value.cascade_rounds,
            -(value.total.total_effective - value.sword_effective),
            not value.sword_risk.safe,
            value.sword_risk.danger_score,
            not value.horizontal,
            value.move,
        )

    @classmethod
    def _skill_rush_support_rank(
        cls,
        value: MoveEvaluation,
        board: BoardState,
    ) -> tuple[object, ...]:
        """Prefer safe Drain, then Shield, after current skill deficits."""

        trace = _candidate_trace(value, board=board)
        drain = value.total.effective(GemType.DRAIN)
        shield = value.total.effective(GemType.SHIELD)
        return (
            trace.known_sword_consumed,
            drain <= 0,
            -drain,
            shield <= 0,
            -shield,
            *cls._skill_rush_setup_rank(value, board),
        )

    @classmethod
    def _skill_rush_condition_setup_rank(
        cls,
        value: MoveEvaluation,
        board: BoardState,
        fire_gem_type: GemType | None,
    ) -> tuple[object, ...]:
        """Keep the configured count gem before applying ordinary setup ties."""

        return (
            (
                -_known_result_gem_effective_count(value, fire_gem_type)
                if fire_gem_type is not None
                else 0
            ),
            *cls._skill_rush_setup_rank(value, board),
        )

    @classmethod
    def _skill_rush_unsafe_fallback_rank(
        cls,
        value: MoveEvaluation,
        board: BoardState,
    ) -> tuple[object, ...]:
        """Minimize proven Sword replies when no Sword-safe action exists."""

        risk = value.sword_risk
        return (
            risk.opponent_sword_reply_effective_max,
            risk.indirect_sword_effective_max,
            risk.opponent_sword_replies + risk.indirect_sword_replies,
            value.unknown_exposure.refill_sword_auto_match_effective_max,
            value.unknown_exposure.refill_sword_auto_match_completions,
            risk.unknown_sword_effective_max,
            risk.unknown_sword_completions,
            risk.danger_score,
            *cls._skill_rush_support_rank(value, board),
        )

    @staticmethod
    def _mandatory_rank(value: MoveEvaluation) -> tuple[object, ...]:
        return (
            value.sword_risk.danger_score,
            value.sword_risk.opponent_sword_reply_effective_max,
            value.sword_risk.opponent_sword_replies,
            -value.total.effective(GemType.SHIELD),
            value.unknown_exposure.cells,
            -value.total.total_effective,
            not value.horizontal,
            not value.calculable,
            value.move,
        )

    @staticmethod
    def _health_only_fallback_rank(value: MoveEvaluation) -> tuple[object, ...]:
        """Prefer the most predictable move when Health is the sole safe resource."""

        return (
            not value.calculable,
            not value.horizontal,
            -value.total.effective(GemType.HEALTH),
            value.sword_risk.danger_score,
            -value.cascade_rounds,
            value.unknown_exposure.cells,
            value.move,
        )

    @staticmethod
    def _sword_hold_rank(
        value: MoveEvaluation,
        hold: SwordHoldEvaluation,
    ) -> tuple[object, ...]:
        """Prefer the smallest gift and strongest guaranteed known follow-up."""

        return (
            hold.opponent_sword_effective_max,
            -hold.followup_sword_effective_min,
            value.unknown_exposure.cells,
            not value.horizontal,
            not value.calculable,
            value.move,
        )

    def _evolution_priority_decision(
        self,
        state: GameState,
        failures: list[str],
        no_candidates: tuple[MoveEvaluation, ...],
        player_mana: int | None,
    ) -> PolicyDecision | None:
        """Apply the shared non-consuming Evolution branch before play style.

        A successful EVOLVE forces a fresh state read, after which the same
        local turn continues through the configured play style.  Therefore
        first-turn, low-boss-HP and pass-limit states do not outrank an
        affordable selected Evolution card.
        """

        if not self.config.evolve_enabled:
            failures.append(
                "STEP_1_EVOLVE: disabled for the entire match by "
                + (
                    "ManaPriority.ATTACK"
                    if self.config.mana_priority is ManaPriority.ATTACK
                    else "canonical Evolution setting"
                )
            )
            return None
        if (
            state.battle.turn_time_remaining_seconds
            < self.config.minimum_evolve_time_seconds
        ):
            failures.append(
                "STEP_1_EVOLVE: deferred because timer "
                f"{state.battle.turn_time_remaining_seconds}s is below the "
                f"{self.config.minimum_evolve_time_seconds}s same-turn "
                "response/follow-up floor"
            )
            return None
        fusion = state.fusion
        if fusion is None:
            failures.append("STEP_1_EVOLVE: FusionState UNKNOWN")
            return None
        if not (
            (fusion.selected_user_pet_id or 0) > 0
            or (fusion.selected_pet_id or 0) > 0
        ):
            failures.append(
                "STEP_1_EVOLVE: no evolution pet is selected; continue in "
                "board-only mode"
            )
            return None
        if fusion.used:
            failures.append("STEP_1_EVOLVE: fusion already succeeded")
            return None
        if not fusion.interaction_authorized:
            failures.append(
                "STEP_1_EVOLVE: neither live FusionCardUI nor the exact "
                "MatchService/Board card strip authorizes a visual-gated click"
            )
            return None
        if (
            fusion.ui_slot is None
            or fusion.ui_slot_count is None
            or not 0 <= fusion.ui_slot < fusion.ui_slot_count
        ):
            failures.append(
                "STEP_1_EVOLVE: runtime Fusion card slot is not proven; "
                "continue with board play"
            )
            return None
        if not fusion.enabled or not fusion.available or fusion.locked_this_turn:
            failures.append("STEP_1_EVOLVE: fusion is not currently available")
            return None
        if player_mana is None:
            failures.append("STEP_1_EVOLVE: player mana UNKNOWN")
            return None
        if fusion.mana_cost is None or fusion.mana_cost <= 0:
            failures.append(
                "STEP_1_EVOLVE: actual positive evolution cost UNKNOWN"
            )
            return None
        if player_mana < fusion.mana_cost:
            failures.append(
                f"STEP_1_EVOLVE: mana {player_mana} below evolution cost "
                f"{fusion.mana_cost}"
            )
            return None
        return self._decision(
            state,
            PolicyAction.EVOLVE,
            "STEP_1_EVOLVE",
            (
                "Evolution priority, not fused, and mana "
                f"{player_mana} >= {fusion.mana_cost}; re-read after proposal"
            ),
            failures,
            no_candidates,
            candidate_count=1,
        )

    def decide(
        self,
        state: GameState,
        *,
        pet_skill_capability: PetSkillCapability | None = None,
        skill_rush_match_context: SkillRushMatchContext | None = None,
    ) -> PolicyDecision:
        failures: list[str] = []
        no_candidates: tuple[MoveEvaluation, ...] = ()
        player = state.player
        player_mana = player.mana if player is not None else None
        player_rage = player.power if player is not None else None
        skill_source_pending_evolution = bool(
            self.config.pet_skill_waits_for_evolution
            and (state.fusion is None or not state.fusion.used)
        )
        # A Legendary evolution does not expose its Pet Skill card until the
        # non-consuming Evolution action succeeds.  Before that transition,
        # use only the proven runtime Fusion cost as the current Mana deficit;
        # do not require or accidentally execute an unrelated/stale skill card.
        capability = (
            None if skill_source_pending_evolution else pet_skill_capability
        )
        required_mana = (
            state.fusion.mana_cost
            if (
                skill_source_pending_evolution
                and state.fusion is not None
                and state.fusion.mana_cost is not None
                and state.fusion.mana_cost > 0
            )
            else capability.effective_mana_cost if capability else None
        )
        required_rage = (
            0
            if skill_source_pending_evolution and required_mana is not None
            else capability.effective_power_cost if capability else None
        )
        missing_mana = (
            max(0, required_mana - player_mana)
            if required_mana is not None and player_mana is not None
            else None
        )
        missing_rage = (
            max(0, required_rage - player_rage)
            if required_rage is not None and player_rage is not None
            else None
        )
        ready = (
            missing_mana == 0 and missing_rage == 0
            if missing_mana is not None and missing_rage is not None
            else None
        )
        self._skill_trace = PetSkillPolicyContext(
            capability.status.value if capability is not None else None,
            capability.skill_family.value if capability is not None else None,
            required_mana,
            required_rage,
            player_mana,
            player_rage,
            missing_mana,
            missing_rage,
            ready,
            capability.live_card_actionable if capability is not None else None,
            False,
        )
        self._skill_rush_trace = SkillRushPolicyContext()
        if self.config.intelligence is not Intelligence.BASIC:
            return self._decision(
                state,
                PolicyAction.NONE,
                "CONFIG",
                "REASONING is represented but intentionally not implemented in Phase 2C.2A",
                failures,
                no_candidates,
                blocker="REASONING_NOT_IMPLEMENTED",
            )
        if (
            self.config.play_style is PlayStyle.SKILL_RUSH
            and not self.config.pet_skill_profile
        ):
            return self._decision(
                state,
                PolicyAction.NONE,
                "CONFIG",
                "SKILL_RUSH requires BASIC with exactly one Pet Skill source",
                failures,
                no_candidates,
                blocker="SKILL_RUSH_PROFILE_NOT_IMPLEMENTED",
            )
        if state.phase is not GamePhase.COMBAT or state.board is None:
            return self._decision(
                state,
                PolicyAction.NONE,
                "ACTIONABILITY_GATE",
                "No stable combat board is published",
                failures,
                no_candidates,
                blocker="NOT_STABLE_COMBAT",
            )
        if state.battle.is_local_turn is not True or state.battle.client_move_allowed is not True:
            return self._decision(
                state,
                PolicyAction.NONE,
                "ACTIONABILITY_GATE",
                "Runtime move permission does not prove an actionable local turn",
                failures,
                no_candidates,
                blocker="LOCAL_TURN_NOT_ACTIONABLE",
            )
        if (
            state.battle.turn_duration_seconds is None
            or state.battle.turn_time_remaining_seconds is None
            or state.battle.turn_timer_source is None
        ):
            return self._decision(
                state,
                PolicyAction.NONE,
                "ACTIONABILITY_GATE",
                "Turn timer is UNKNOWN; policy fails closed",
                failures,
                no_candidates,
                blocker="TURN_TIMER_UNKNOWN",
            )
        # The configured floor is inclusive. The server timer is an integer
        # tick, so treating the exact floor as expired silently adds a second
        # to the operator-approved limit.
        if state.battle.turn_time_remaining_seconds < self.config.minimum_turn_time_seconds:
            return self._decision(
                state,
                PolicyAction.NONE,
                "ACTIONABILITY_GATE",
                "Latest server timer tick is inside the configured safety margin",
                failures,
                no_candidates,
                blocker="TURN_TIMER_SAFETY_MARGIN",
            )

        evolution_decision = self._evolution_priority_decision(
            state,
            failures,
            no_candidates,
            player_mana,
        )
        if evolution_decision is not None:
            return evolution_decision

        boss = _boss(state)
        boss_hp_current = boss.hp if boss is not None else None
        boss_max_hp = boss.max_hp if boss is not None else None
        boss_hp_ratio = _ratio(boss_hp_current, boss_max_hp)
        player_hp_ratio = (
            _ratio(player.hp, player.max_hp) if player is not None else None
        )
        known_sword_count = _known_sword_count(state.board)
        known_sword_effective_count = _known_sword_effective_count(state.board)
        rush_history_current = bool(
            self.config.play_style is PlayStyle.SKILL_RUSH
            and skill_rush_match_context is not None
            and state.battle.session_key is not None
            and skill_rush_match_context.session_key == state.battle.session_key
        )
        successful_pet_skills = (
            skill_rush_match_context.successful_pet_skills
            if rush_history_current and skill_rush_match_context is not None
            else 0
        )
        latest_skill_turn = (
            skill_rush_match_context.latest_success_source_turn
            if rush_history_current and skill_rush_match_context is not None
            else None
        )
        fire_condition = self.config.pet_skill_fire_condition
        fire_gem_type = _FIRE_CONDITION_GEM_TYPE.get(fire_condition)
        selected_known_gem_count = (
            _known_gem_count(state.board, fire_gem_type)
            if fire_gem_type is not None
            else None
        )
        selected_known_gem_effective_count = (
            _known_gem_effective_count(state.board, fire_gem_type)
            if fire_gem_type is not None
            else None
        )
        selected_fire_condition_ready = (
            ready
            if fire_condition is PetSkillFireCondition.SKILL_COST_READY
            else bool(
                selected_known_gem_effective_count is not None
                and self.config.pet_skill_fire_value is not None
                and selected_known_gem_effective_count
                >= self.config.pet_skill_fire_value
            )
        )
        configured_sword_threshold = (
            self.config.pet_skill_fire_value
            if fire_condition is PetSkillFireCondition.SWORD_COUNT
            else None
        )
        sword_threshold_ready = (
            selected_fire_condition_ready
            if fire_condition is PetSkillFireCondition.SWORD_COUNT
            else None
        )
        relative_finisher = bool(
            successful_pet_skills > 0
            and boss_hp_current is not None
            and boss_hp_current > 0
            and boss_hp_ratio is not None
            and boss_hp_ratio <= SKILL_RUSH_FINISHER_RATIO
        )
        finisher_trigger = (
            SkillRushFinisherTrigger.RELATIVE_HP
            if relative_finisher
            else SkillRushFinisherTrigger.NONE
        )
        self._skill_rush_trace = SkillRushPolicyContext(
            boss_hp=boss_hp_current,
            boss_max_hp=boss_max_hp,
            boss_hp_ratio=boss_hp_ratio,
            known_sword_count=known_sword_count,
            known_sword_effective_count=known_sword_effective_count,
            pet_skill_fire_condition=fire_condition,
            pet_skill_fire_value=self.config.pet_skill_fire_value,
            selected_fire_gem_type=fire_gem_type,
            selected_known_gem_count=selected_known_gem_count,
            selected_known_gem_effective_count=(
                selected_known_gem_effective_count
            ),
            selected_fire_condition_ready=selected_fire_condition_ready,
            configured_sword_threshold=configured_sword_threshold,
            sword_threshold_ready=sword_threshold_ready,
            successful_pet_skills=successful_pet_skills,
            post_skill_finisher_ready=relative_finisher,
            finisher_trigger=finisher_trigger,
        )
        if (
            self.config.play_style is PlayStyle.SKILL_RUSH
            and successful_pet_skills > 0
            and latest_skill_turn is not None
            and (
                state.battle.turn_number is None
                or state.battle.turn_number <= latest_skill_turn
            )
        ):
            return self._decision(
                state,
                PolicyAction.NONE,
                "SKILL_RUSH_SOURCE_TURN_CLOSED",
                "A successful current-match Pet Skill closes its source turn; wait for a later authoritative local turn",
                failures,
                no_candidates,
                blocker="PET_SKILL_SOURCE_TURN_UNRESOLVED",
            )
        finisher_threshold = self.config.cast_when_boss_hp_below
        low_boss_hp_mode = bool(
            finisher_threshold > 0
            and boss_hp_current is not None
            and boss_hp_current <= finisher_threshold
        )

        idle_status = state.battle.consecutive_pass_status
        # Compatibility for deterministic fixtures that predate the explicit
        # status field.  The numeric values still originate in the fixture's
        # game-owned payload; no value is synthesized here.
        if (
            idle_status is GameOwnedIdleStatus.UNKNOWN
            and state.battle.consecutive_passes is not None
            and state.battle.consecutive_pass_threshold is not None
            and state.battle.consecutive_pass_source is not None
        ):
            idle_status = (
                GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION
                if state.battle.consecutive_passes
                >= state.battle.consecutive_pass_threshold - 1
                else GameOwnedIdleStatus.PASS_ALLOWED
            )
        mandatory = bool(
            state.battle.is_first_local_turn is True
            or idle_status
            is GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION
        )
        skill_rush_pass_allowed = bool(
            not mandatory
            and idle_status
            in {
                GameOwnedIdleStatus.RESET_BASELINE_CONFIRMED,
                GameOwnedIdleStatus.PASS_ALLOWED,
            }
        )

        rush_fire_trigger: SkillRushFireTrigger | None = None
        skill_waiting_for_evolution = skill_source_pending_evolution
        if (
            self.config.damage_card is DamageCardMode.PET_SKILL
            and skill_waiting_for_evolution
        ):
            failures.append(
                "STEP_1_PET_SKILL: configured skill source is the Evolution "
                "target; accumulate resources and evolve before requiring its card"
            )
        elif self.config.damage_card is DamageCardMode.PET_SKILL:
            if not self.config.pet_skill_profile:
                return self._decision(
                    state,
                    PolicyAction.NONE,
                    "STEP_1_PET_SKILL",
                    "Pet Skill configuration does not resolve exactly one source",
                    failures,
                    no_candidates,
                    blocker="PET_SKILL_PROFILE_UNSUPPORTED",
                )
            if capability is None:
                return self._decision(
                    state,
                    PolicyAction.NONE,
                    "STEP_1_PET_SKILL",
                    "Current-session Pet Skill capability is unavailable",
                    failures,
                    no_candidates,
                    blocker="PET_SKILL_CAPABILITY_UNAVAILABLE",
                )
            if capability.status is PetSkillCapabilityStatus.AMBIGUOUS:
                return self._decision(
                    state,
                    PolicyAction.NONE,
                    "STEP_1_PET_SKILL",
                    "More than one current Pet Skill source is present",
                    failures,
                    no_candidates,
                    blocker="PET_SKILL_CAPABILITY_AMBIGUOUS",
                )
            if (
                not capability.current
                or capability.session_key != state.battle.session_key
            ):
                return self._decision(
                    state,
                    PolicyAction.NONE,
                    "STEP_1_PET_SKILL",
                    "Pet Skill capability is missing, stale, or not owned by this session",
                    failures,
                    no_candidates,
                    blocker="PET_SKILL_CAPABILITY_UNAVAILABLE",
                )
            if capability.skill_family is not PetSkillFamily.AUTOMATIC_DOT_DESTRUCTION:
                return self._decision(
                    state,
                    PolicyAction.NONE,
                    "STEP_1_PET_SKILL",
                    "Current Pet Skill family is not accepted for automatic execution",
                    failures,
                    no_candidates,
                    blocker="PET_SKILL_FAMILY_UNSUPPORTED",
                )
            if (
                required_mana is None
                or required_mana <= 0
                or required_rage is None
                or required_rage <= 0
            ):
                return self._decision(
                    state,
                    PolicyAction.NONE,
                    "STEP_1_PET_SKILL",
                    "Current Pet Skill effective Mana/Rage requirements are unknown",
                    failures,
                    no_candidates,
                    blocker="PET_SKILL_COST_UNKNOWN",
                )
            if player_mana is None or player_rage is None:
                return self._decision(
                    state,
                    PolicyAction.NONE,
                    "STEP_1_PET_SKILL",
                    "Current player Mana/Rage is unknown",
                    failures,
                    no_candidates,
                    blocker="PET_SKILL_RESOURCE_STATE_UNKNOWN",
                )
            if capability.live_card_actionable is None:
                return self._decision(
                    state,
                    PolicyAction.NONE,
                    "STEP_1_PET_SKILL",
                    "Current Pet Skill CardUI actionability is unknown",
                    failures,
                    no_candidates,
                    blocker="PET_SKILL_ACTIONABILITY_UNKNOWN",
                )
            if (
                ready
                and capability.live_card_actionable
                and self.config.play_style is not PlayStyle.SKILL_RUSH
            ):
                self._skill_trace = PetSkillPolicyContext(
                    **{**self._skill_trace.__dict__, "candidate": True}
                )
                return self._decision(
                    state,
                    PolicyAction.PET_SKILL,
                    "STEP_1_PET_SKILL",
                    (
                        f"Current skill {capability.skill_card_id} is actionable and "
                        f"Mana/Rage {player_mana}/{player_rage} satisfy "
                        f"{required_mana}/{required_rage}"
                    ),
                    failures,
                    no_candidates,
                    skill=capability,
                    candidate_count=1,
                )
            if self.config.play_style is PlayStyle.SKILL_RUSH and ready:
                failures.append(
                    "STEP_1_PET_SKILL: SKILL_RUSH readiness is known; defer to "
                    "the configured normal Pet Skill fire condition"
                )
            else:
                failures.append(
                    "STEP_1_PET_SKILL: current capability is known but not ready/actionable; "
                    f"missing Mana/Rage={missing_mana}/{missing_rage}, "
                    f"actionable={capability.live_card_actionable}"
                )

        if (
            self.config.play_style is PlayStyle.SKILL_RUSH
            and self.config.pet_skill_profile
        ):
            rush_fire_trigger = _skill_rush_fire_trigger(
                selected_condition_ready=selected_fire_condition_ready,
            )
            if self._skill_rush_trace.post_skill_finisher_ready and player_mana is not None:
                pre_board_attack_cards = tuple(
                    card
                    for card in state.cards
                    if card.is_attack
                    and card.interactable
                    and not card.action_pending
                    and not card.has_used_this_turn
                    and card.ui_slot is not None
                    and card.ui_slot_count is not None
                    and 0 <= card.ui_slot < card.ui_slot_count
                    and player_mana >= _attack_cost(card)
                )
                if pre_board_attack_cards:
                    card = min(
                        pre_board_attack_cards,
                        key=lambda value: (value.card_id, value.object_address),
                    )
                    self._skill_rush_trace = replace(
                        self._skill_rush_trace,
                        finisher_action=SkillRushFinisherAction.DEFAULT_ATTACK,
                    )
                    return self._decision(
                        state,
                        PolicyAction.CAST,
                        "SKILL_RUSH_POST_SKILL_FINISHER_ATTACK",
                        (
                            "A successful Pet Skill belongs to this match and fresh "
                            f"boss HP {boss_hp_current}/{boss_max_hp} is inside the "
                            f"{self._skill_rush_trace.finisher_trigger.value} finisher range"
                        ),
                        failures,
                        no_candidates,
                        card=card,
                        candidate_count=len(pre_board_attack_cards),
                    )

            if (
                not self._skill_rush_trace.post_skill_finisher_ready
                and ready
                and capability is not None
                and capability.live_card_actionable
                and rush_fire_trigger is not None
            ):
                self._skill_trace = replace(self._skill_trace, candidate=True)
                self._skill_rush_trace = replace(
                    self._skill_rush_trace,
                    fire_trigger=rush_fire_trigger,
                    finisher_action=(
                        SkillRushFinisherAction.SECOND_PET_SKILL
                        if successful_pet_skills > 0
                        else None
                    ),
                )
                return self._decision(
                    state,
                    PolicyAction.PET_SKILL,
                    "STEP_1_PET_SKILL",
                    (
                        f"Current skill {capability.skill_card_id} is actionable; "
                        f"Mana/Rage {player_mana}/{player_rage} satisfy "
                        f"{required_mana}/{required_rage}; final SKILL_RUSH fire "
                        f"trigger={rush_fire_trigger.value}, condition={fire_condition.value}, "
                        f"selectedGem={fire_gem_type.value if fire_gem_type else None}, "
                        f"knownEffectiveCount={selected_known_gem_effective_count}, "
                        f"knownCellCount={selected_known_gem_count}, "
                        f"configuredValue={self.config.pet_skill_fire_value}"
                    ),
                    failures,
                    no_candidates,
                    skill=capability,
                    candidate_count=1,
                )

        evaluations = evaluate_all_moves(state.board)
        if not evaluations:
            if (
                self.config.play_style is PlayStyle.SKILL_RUSH
                and self._skill_rush_trace.post_skill_finisher_ready
                and ready
                and capability is not None
                and capability.live_card_actionable
                and rush_fire_trigger is not None
            ):
                self._skill_trace = replace(self._skill_trace, candidate=True)
                self._skill_rush_trace = replace(
                    self._skill_rush_trace,
                    fire_trigger=rush_fire_trigger,
                    finisher_action=SkillRushFinisherAction.SECOND_PET_SKILL,
                )
                return self._decision(
                    state,
                    PolicyAction.PET_SKILL,
                    "STEP_1_PET_SKILL",
                    "No ordinary post-skill finisher exists on the dead board; a ready second Pet Skill remains legal",
                    failures,
                    evaluations,
                    skill=capability,
                    candidate_count=1,
                )
            return self._decision(
                state,
                PolicyAction.EXIT_MATCH,
                "NO_LEGAL_MOVE_BUG",
                "Exhaustive scan of all 112 adjacent pairs found zero match-producing swaps",
                failures,
                evaluations,
                blocker="EXIT_IS_PROPOSAL_ONLY",
            )

        if (
            self.config.play_style is PlayStyle.SKILL_RUSH
            and self.config.pet_skill_profile
        ):
            rush_attack_cards = tuple(
                card
                for card in state.cards
                if card.is_attack
                and card.interactable
                and not card.action_pending
                and not card.has_used_this_turn
                and card.ui_slot is not None
                and card.ui_slot_count is not None
                and 0 <= card.ui_slot < card.ui_slot_count
            )
            finisher_ready = self._skill_rush_trace.post_skill_finisher_ready
            if finisher_ready and player_mana is not None:
                usable_attacks = tuple(
                    card
                    for card in rush_attack_cards
                    if player_mana >= _attack_cost(card)
                )
                if usable_attacks:
                    card = min(
                        usable_attacks,
                        key=lambda value: (value.card_id, value.object_address),
                    )
                    self._skill_rush_trace = replace(
                        self._skill_rush_trace,
                        finisher_action=SkillRushFinisherAction.DEFAULT_ATTACK,
                    )
                    return self._decision(
                        state,
                        PolicyAction.CAST,
                        "SKILL_RUSH_POST_SKILL_FINISHER_ATTACK",
                        (
                            "A successful Pet Skill belongs to this match and fresh "
                            f"boss HP {boss_hp_current}/{boss_max_hp} is inside the "
                            f"{self._skill_rush_trace.finisher_trigger.value} finisher range"
                        ),
                        failures,
                        evaluations,
                        card=card,
                        candidate_count=len(usable_attacks),
                    )
                failures.append(
                    "SKILL_RUSH_POST_SKILL_FINISHER_ATTACK: no affordable actionable ordinary Attack card"
                )
            elif finisher_ready:
                failures.append(
                    "SKILL_RUSH_POST_SKILL_FINISHER_ATTACK: player Mana UNKNOWN"
                )

            if finisher_ready:
                finisher_sword_moves = tuple(
                    value for value in evaluations if value.sword_effective > 0
                )
                if finisher_sword_moves:
                    selected = min(finisher_sword_moves, key=self._sword_rank)
                    self._skill_rush_trace = replace(
                        self._skill_rush_trace,
                        finisher_action=SkillRushFinisherAction.SWORD,
                    )
                    return self._decision(
                        state,
                        PolicyAction.SWAP,
                        "SKILL_RUSH_POST_SKILL_FINISHER_SWORD",
                        (
                            "No affordable ordinary Attack is available; selected "
                            "deterministic Sword damage in the proven post-skill "
                            f"{self._skill_rush_trace.finisher_trigger.value} range"
                        ),
                        failures,
                        finisher_sword_moves,
                        selected=selected,
                        skill=capability,
                    )
                failures.append(
                    "SKILL_RUSH_POST_SKILL_FINISHER_SWORD: no deterministic Sword damage move"
                )

            if (
                ready
                and capability is not None
                and capability.live_card_actionable
                and rush_fire_trigger is not None
            ):
                self._skill_trace = replace(self._skill_trace, candidate=True)
                self._skill_rush_trace = replace(
                    self._skill_rush_trace,
                    fire_trigger=rush_fire_trigger,
                    finisher_action=(
                        SkillRushFinisherAction.SECOND_PET_SKILL
                        if successful_pet_skills > 0
                        else None
                    ),
                )
                return self._decision(
                    state,
                    PolicyAction.PET_SKILL,
                    "STEP_1_PET_SKILL",
                    (
                        f"Current skill {capability.skill_card_id} is actionable; "
                        f"Mana/Rage {player_mana}/{player_rage} satisfy "
                        f"{required_mana}/{required_rage}; final SKILL_RUSH fire "
                        f"condition={rush_fire_trigger.value}, bossRatio={boss_hp_ratio}, "
                        f"knownSwordEffective={known_sword_effective_count}, "
                        f"knownSwordCells={known_sword_count}"
                    ),
                    failures,
                    evaluations,
                    skill=capability,
                    candidate_count=1,
                )

            if missing_mana or missing_rage:
                resource_traces = tuple(
                    (value, _candidate_trace(value, board=state.board))
                    for value in evaluations
                )
                # Skill Rush never spends Sword before a qualifying Pet Skill.
                # The strategy may accept a boss Sword reply while healthy, but
                # it may not convert our own prepared Sword into damage.
                non_sword_moves = tuple(
                    value
                    for value, trace in resource_traces
                    if trace.known_sword_consumed == 0
                )
                safe_non_sword_moves = tuple(
                    value for value in non_sword_moves if value.sword_risk.safe
                )

                def advances_missing_resource(value: MoveEvaluation) -> bool:
                    return bool(
                        (
                            bool(missing_mana)
                            and value.total.effective(GemType.MANA) > 0
                        )
                        or (
                            bool(missing_rage)
                            and value.total.effective(GemType.RAGE) > 0
                        )
                    )

                safe_progress_moves = tuple(
                    value
                    for value in safe_non_sword_moves
                    if advances_missing_resource(value)
                )
                progress_moves = tuple(
                    value
                    for value in non_sword_moves
                    if advances_missing_resource(value)
                )
                safe_drain_moves = tuple(
                    value
                    for value in safe_non_sword_moves
                    if value.total.effective(GemType.DRAIN) > 0
                )
                safe_shield_moves = tuple(
                    value
                    for value in safe_non_sword_moves
                    if value.total.effective(GemType.SHIELD) > 0
                )
                safe_health_moves = tuple(
                    value
                    for value in safe_non_sword_moves
                    if value.total.effective(GemType.HEALTH) > 0
                )
                healthy = bool(
                    player_hp_ratio is not None
                    and player_hp_ratio > SKILL_RUSH_SURVIVAL_HP_RATIO
                )

                if safe_progress_moves:
                    selected = min(
                        safe_progress_moves,
                        key=lambda value: self._skill_rush_resource_rank(
                            value, state.board
                        ),
                    )
                    step = "SKILL_RUSH_RESOURCE_PROGRESS"
                    why = (
                        "Selected the best Sword-preserving, Sword-safe Mana/Rage "
                        "progress toward the current Pet Skill deficits"
                    )
                elif healthy and progress_moves:
                    selected = min(
                        progress_moves,
                        key=lambda value: self._skill_rush_resource_rank(
                            value, state.board
                        ),
                    )
                    step = "SKILL_RUSH_RESOURCE_RISK_ACCEPTED"
                    why = (
                        "No Sword-safe Mana/Rage progress exists, but player HP is "
                        "above 30%; prioritized a Sword-preserving move for the "
                        "missing skill resource before Drain, Shield or turnover"
                    )
                elif safe_drain_moves:
                    selected = min(
                        safe_drain_moves,
                        key=lambda value: self._skill_rush_support_rank(
                            value, state.board
                        ),
                    )
                    step = "SKILL_RUSH_LEGAL_FALLBACK"
                    why = (
                        "No safe Mana/Rage progress exists; selected safe Drain to "
                        "protect resources and deny the same support to the boss"
                    )
                elif safe_shield_moves:
                    selected = min(
                        safe_shield_moves,
                        key=lambda value: self._skill_rush_support_rank(
                            value, state.board
                        ),
                    )
                    step = "SKILL_RUSH_LEGAL_FALLBACK"
                    why = (
                        "No safe Mana/Rage or Drain exists; selected safe Shield "
                        "to protect accumulated resources"
                    )
                elif safe_non_sword_moves:
                    safe_pool = (
                        safe_health_moves
                        if player_hp_ratio is None
                        or player_hp_ratio <= SKILL_RUSH_SURVIVAL_HP_RATIO
                        else safe_non_sword_moves
                    )
                    selected = min(
                        safe_pool or safe_non_sword_moves,
                        key=lambda value: self._skill_rush_support_rank(
                            value, state.board
                        ),
                    )
                    step = "SKILL_RUSH_LEGAL_FALLBACK"
                    why = (
                        "Explicit resource and protection priorities are empty; "
                        "selected a Sword-preserving safe board action"
                    )
                else:
                    risky_progress_moves = progress_moves
                    risky_drain_moves = tuple(
                        value
                        for value in non_sword_moves
                        if value.total.effective(GemType.DRAIN) > 0
                    )
                    risky_shield_moves = tuple(
                        value
                        for value in non_sword_moves
                        if value.total.effective(GemType.SHIELD) > 0
                    )
                    risky_health_moves = tuple(
                        value
                        for value in non_sword_moves
                        if value.total.effective(GemType.HEALTH) > 0
                    )
                    if healthy and non_sword_moves:
                        risky_pool = (
                            risky_progress_moves
                            or risky_drain_moves
                            or risky_shield_moves
                            or non_sword_moves
                        )
                        selected = min(
                            risky_pool,
                            key=lambda value: self._skill_rush_unsafe_fallback_rank(
                                value, state.board
                            ),
                        )
                        step = "SKILL_RUSH_RESOURCE_RISK_ACCEPTED"
                        why = (
                            "No Sword-safe action exists and player HP is above 30%; "
                            "accepted the lowest-risk non-Sword action in Mana/Rage, "
                            "Drain, Shield, turnover order before considering PASS"
                        )
                    else:
                        survival_pool = risky_shield_moves or risky_health_moves
                        if survival_pool:
                            selected = min(
                                survival_pool,
                                key=lambda value: self._skill_rush_unsafe_fallback_rank(
                                    value, state.board
                                ),
                            )
                            step = "SKILL_RUSH_SURVIVAL_RISK_ACCEPTED"
                            why = (
                                "No Sword-safe action exists and player HP is at or "
                                "below 30% (or unknown); selected Shield then Health "
                                "before the last-resort PASS"
                            )
                        elif skill_rush_pass_allowed:
                            return self._decision(
                                state,
                                PolicyAction.PASS,
                                "SKILL_RUSH_RESOURCE_PASS",
                                (
                                    "No safe resource/protection action and no "
                                    "Shield/Health survival action exists; used the "
                                    "last-resort authoritative PASS"
                                ),
                                failures,
                                evaluations,
                                skill=capability,
                            )
                        elif non_sword_moves:
                            selected = min(
                                non_sword_moves,
                                key=lambda value: self._skill_rush_unsafe_fallback_rank(
                                    value, state.board
                                ),
                            )
                            step = "SKILL_RUSH_RESOURCE_MANDATORY"
                            why = (
                                "PASS is prohibited; selected the lowest-risk "
                                "non-Sword action to prevent a third consecutive idle"
                            )
                        elif skill_rush_pass_allowed:
                            return self._decision(
                                state,
                                PolicyAction.PASS,
                                "SKILL_RUSH_RESOURCE_PASS",
                                (
                                    "Every legal move consumes Sword; used the "
                                    "last-resort authoritative PASS"
                                ),
                                failures,
                                evaluations,
                                skill=capability,
                            )
                        else:
                            return self._decision(
                                state,
                                PolicyAction.NONE,
                                "SKILL_RUSH_SWORD_PRESERVATION_BLOCKED",
                                (
                                    "Every legal move consumes known Sword and PASS "
                                    "is unavailable; fail closed"
                                ),
                                failures,
                                evaluations,
                                skill=capability,
                                blocker="SKILL_RUSH_ONLY_SWORD_MOVES",
                            )

                selected_trace = _candidate_trace(
                    selected,
                    board=state.board,
                    required_mana=required_mana,
                    required_rage=required_rage,
                    missing_mana=missing_mana,
                    missing_rage=missing_rage,
                )
                if selected_trace.known_sword_consumed != 0:
                    raise AssertionError("Skill Rush resource stage consumed Sword")
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    step,
                    (
                        f"{why}; playerHpRatio={player_hp_ratio}, "
                        f"knownSwordConsumed={selected_trace.known_sword_consumed}, "
                        f"resourceProgress={selected_trace.readiness_progress:.6f}"
                    ),
                    failures,
                    evaluations,
                    selected=selected,
                    skill=capability,
                )

            if ready and rush_fire_trigger is None:
                failures.append(
                    "STEP_1_PET_SKILL: resources ready but selected fire condition "
                    f"{fire_condition.value} is false; selectedGem="
                    f"{fire_gem_type.value if fire_gem_type else None}, "
                    f"knownEffectiveCount={selected_known_gem_effective_count}, "
                    f"knownCellCount={selected_known_gem_count}, "
                    f"configuredValue={self.config.pet_skill_fire_value}"
                )
            elif ready and capability is not None and not capability.live_card_actionable:
                failures.append(
                    "STEP_1_PET_SKILL: fire condition is ready but current Pet Skill CardUI is not actionable"
                )

            setup_traces = tuple(
                (value, _candidate_trace(value, board=state.board))
                for value in evaluations
            )
            # Count-based setup preserves both Sword (an absolute Skill Rush
            # prohibition) and the configured condition gem. skill_cost_ready
            # never reaches this branch once resources/actionability are ready.
            condition_preserving_setup = tuple(
                (value, trace)
                for value, trace in setup_traces
                if trace.known_sword_consumed == 0
                and (
                    fire_gem_type is None
                    or value.total.cells(fire_gem_type) == 0
                )
            )
            isolated_setup_moves = tuple(
                value
                for value, trace in condition_preserving_setup
                if value.sword_risk.safe
                and trace.refill_sword_auto_match_completions == 0
                and trace.cleared_non_sword_min_sword_distance is not None
                and trace.cleared_non_sword_min_sword_distance >= 2
            )
            relaxed_setup_moves = tuple(
                value
                for value, _trace in condition_preserving_setup
                if value not in isolated_setup_moves
            )
            available_distances = tuple(
                trace.cleared_non_sword_min_sword_distance
                for _value, trace in condition_preserving_setup
                if trace.cleared_non_sword_min_sword_distance is not None
            )
            setup_blocked = not isolated_setup_moves
            if setup_blocked:
                self._skill_rush_trace = replace(
                    self._skill_rush_trace,
                    setup_blocked=True,
                    preferred_setup_candidate_count=0,
                    relaxed_setup_candidate_count=len(relaxed_setup_moves),
                    minimum_available_sword_distance=(
                        min(available_distances) if available_distances else None
                    ),
                )
                failures.append(
                    "SKILL_RUSH_SETUP_BLOCKED: no Sword-safe direct clear preserves "
                    "all known Sword and the configured condition gem without a "
                    "refill Sword auto-match at distance two or greater"
                )
            else:
                self._skill_rush_trace = replace(
                    self._skill_rush_trace,
                    preferred_setup_candidate_count=len(isolated_setup_moves),
                    relaxed_setup_candidate_count=len(relaxed_setup_moves),
                    minimum_available_sword_distance=(
                        min(available_distances) if available_distances else None
                    ),
                )

            if isolated_setup_moves:
                selected = min(
                    isolated_setup_moves,
                    key=lambda value: self._skill_rush_condition_setup_rank(
                        value, state.board, fire_gem_type
                    ),
                )
                policy_step = "SKILL_RUSH_BOARD_SETUP"
                why = (
                    "Selected a proven Sword-safe, Sword-preserving setup at least "
                    "two cells from known Sword while preserving the configured "
                    "condition gem"
                )
            else:
                safe_distance_relaxed_moves = tuple(
                    value
                    for value, trace in condition_preserving_setup
                    if value.sword_risk.safe
                    and trace.refill_sword_auto_match_completions == 0
                    and trace.cleared_non_sword_min_sword_distance is not None
                    and trace.cleared_non_sword_min_sword_distance >= 1
                )
                safe_board_turnover_moves = tuple(
                    value
                    for value, trace in condition_preserving_setup
                    if value.sword_risk.safe
                    and trace.refill_sword_auto_match_completions == 0
                    and value not in safe_distance_relaxed_moves
                )
                if safe_distance_relaxed_moves:
                    selected = min(
                        safe_distance_relaxed_moves,
                        key=lambda value: self._skill_rush_condition_setup_rank(
                            value, state.board, fire_gem_type
                        ),
                    )
                    fallback_type = SkillRushSetupFallbackType.RELAXED_DISTANCE
                elif safe_board_turnover_moves:
                    selected = min(
                        safe_board_turnover_moves,
                        key=lambda value: self._skill_rush_condition_setup_rank(
                            value, state.board, fire_gem_type
                        ),
                    )
                    fallback_type = SkillRushSetupFallbackType.BOARD_TURNOVER
                else:
                    preserving_moves = tuple(
                        value for value, _trace in condition_preserving_setup
                    )
                    if skill_rush_pass_allowed:
                        return self._decision(
                            state,
                            PolicyAction.PASS,
                            "SKILL_RUSH_SETUP_PASS",
                            (
                                "The configured board threshold is not ready and no "
                                "safe setup preserves Sword plus the selected condition "
                                "gem; used an authoritatively allowed PASS"
                            ),
                            failures,
                            evaluations,
                            skill=capability,
                        )
                    if not preserving_moves:
                        return self._decision(
                            state,
                            PolicyAction.NONE,
                            "SKILL_RUSH_SWORD_PRESERVATION_BLOCKED",
                            (
                                "Every legal move consumes Sword or the configured "
                                "condition gem, and PASS is unavailable; fail closed"
                            ),
                            failures,
                            evaluations,
                            skill=capability,
                            blocker="SKILL_RUSH_ONLY_SETUP_CONSUMING_MOVES",
                        )
                    selected = min(
                        preserving_moves,
                        key=lambda value: self._skill_rush_unsafe_fallback_rank(
                            value, state.board
                        ),
                    )
                    selected_trace = _candidate_trace(selected, board=state.board)
                    fallback_type = SkillRushSetupFallbackType.MANDATORY_FALLBACK
                selected_trace = _candidate_trace(selected, board=state.board)
                if selected_trace.known_sword_consumed != 0:
                    raise AssertionError("Skill Rush setup consumed Sword")
                if (
                    fire_gem_type is not None
                    and selected.total.cells(fire_gem_type) != 0
                ):
                    raise AssertionError(
                        "Skill Rush setup consumed the configured condition gem"
                    )
                self._skill_rush_trace = replace(
                    self._skill_rush_trace,
                    sword_consumed_by_relaxed_move=(
                        selected_trace.known_sword_consumed
                    ),
                    setup_fallback_type=fallback_type,
                )
                policy_step = "SKILL_RUSH_SETUP_RELAXED"
                why = (
                    "Preferred Sword-safe distance-two setup is blocked; "
                    f"selected deterministic {fallback_type.value} board action, "
                    f"minimumAvailableSwordDistance={self._skill_rush_trace.minimum_available_sword_distance}, "
                    f"knownSwordConsumed={selected_trace.known_sword_consumed}; "
                    f"knownSwordPreserved={selected_trace.known_sword_preserved}; "
                    f"swordSafe={selected.sword_risk.safe}; Pet Skill still requires "
                    "resources plus the configured current-board condition"
                )
            if finisher_ready:
                self._skill_rush_trace = replace(
                    self._skill_rush_trace,
                    finisher_action=SkillRushFinisherAction.OTHER_EXISTING_FALLBACK,
                )
            return self._decision(
                state,
                PolicyAction.SWAP,
                policy_step,
                why,
                failures,
                evaluations,
                selected=selected,
                skill=capability,
            )

        # STEP 2: deterministic Sword collection includes known cascades.
        sword_moves = tuple(value for value in evaluations if value.sword_effective > 0)
        deferred_unique_sword: MoveEvaluation | None = None
        sword_hold_moves: tuple[tuple[MoveEvaluation, SwordHoldEvaluation], ...] = ()
        if sword_moves:
            only_sword = sword_moves[0] if len(sword_moves) == 1 else None
            if (
                only_sword is not None
                and only_sword.sword_risk.opponent_sword_reply_effective_max
                > only_sword.sword_effective
            ):
                deferred_unique_sword = only_sword
                failures.append(
                    "STEP_2_SWORD: deferred the only Sword move because its "
                    "known opponent reply collects more effective Sword "
                    f"({only_sword.sword_risk.opponent_sword_reply_effective_max} "
                    f"> {only_sword.sword_effective}); continue through the "
                    "normal safe policy, authoritative PASS, or the narrowly "
                    "proven off-region Sword-hold exception"
                )
            else:
                selected = min(sword_moves, key=self._sword_rank)
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    "STEP_2_SWORD",
                    "A deterministic Sword result exists; selected by no direct/indirect opponent Sword reply, effective Sword, combo, danger, then UNKNOWN exposure",
                    failures,
                    sword_moves,
                    selected=selected,
                )
        if deferred_unique_sword is None:
            failures.append(
                "STEP_2_SWORD: no legal move collects Sword directly or by known cascade"
            )

        safe_moves = tuple(value for value in evaluations if value.sword_risk.safe)

        if self.config.pet_skill_profile and (missing_mana or missing_rage):
            progress_moves = tuple(
                value
                for value in safe_moves
                if (
                    (bool(missing_mana) and value.total.effective(GemType.MANA) > 0)
                    or (bool(missing_rage) and value.total.effective(GemType.RAGE) > 0)
                )
            )
            if progress_moves:
                selected = min(progress_moves, key=self._pet_skill_resource_rank)
                selected_trace = _candidate_trace(
                    selected,
                    required_mana=required_mana,
                    required_rage=required_rage,
                    missing_mana=missing_mana,
                    missing_rage=missing_rage,
                )
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    "STEP_3_PET_SKILL_RESOURCE",
                    (
                        "Selected a Sword-safe deterministic move toward current "
                        f"skill deficits; completes={selected_trace.requirements_completed_after_move}, "
                        f"progress={selected_trace.readiness_progress:.6f}"
                    ),
                    failures,
                    progress_moves,
                    selected=selected,
                    skill=capability,
                )
            failures.append(
                "STEP_3_PET_SKILL_RESOURCE: no Sword-safe deterministic move advances "
                "a current missing requirement"
            )

        attack_cards = tuple(
            card
            for card in state.cards
            if card.is_attack
            and card.interactable
            and not card.action_pending
            and not card.has_used_this_turn
            and card.ui_slot is not None
            and card.ui_slot_count is not None
            and 0 <= card.ui_slot < card.ui_slot_count
        )

        # STEP 3 FINISHER: a Sword-free board with the boss at or below the
        # configured absolute HP casts as soon as one Attack card is
        # affordable.  This deliberately ignores the 480 stockpile rule — the
        # point is to close out the match instead of hoarding mana.
        if self.config.pet_skill_profile:
            failures.append("STEP_3_FINISH_CAST: prohibited by DamageCard.PET_SKILL")
        elif finisher_threshold <= 0:
            failures.append("STEP_3_FINISH_CAST: finisher disabled by configuration")
        elif boss_hp_current is None:
            failures.append("STEP_3_FINISH_CAST: boss HP UNKNOWN")
        elif boss_hp_current > finisher_threshold:
            failures.append(
                f"STEP_3_FINISH_CAST: boss HP {boss_hp_current} above finisher threshold {finisher_threshold}"
            )
        elif player_mana is None:
            failures.append("STEP_3_FINISH_CAST: player mana UNKNOWN")
        else:
            usable = tuple(card for card in attack_cards if player_mana >= _attack_cost(card))
            if usable:
                card = min(usable, key=lambda value: (value.card_id, value.object_address))
                return self._decision(
                    state,
                    PolicyAction.CAST,
                    "STEP_3_FINISH_CAST",
                    (
                        f"No Sword on board and boss HP {boss_hp_current} <= {finisher_threshold}; "
                        f"finisher CAST with mana {player_mana}"
                    ),
                    failures,
                    evaluations,
                    card=card,
                    candidate_count=len(usable),
                )
            failures.append(
                "STEP_3_FINISH_CAST: finisher HP condition met but no affordable usable Attack card"
            )

        # LOW-BOSS-HP MODE: after Sword and an immediately affordable CAST,
        # accumulate safe Mana before considering Rage.  This is deliberately
        # scoped to the configurable finisher threshold; normal combat keeps
        # the original Rage-before-Mana policy below.
        mana_moves = tuple(
            value for value in safe_moves if value.total.effective(GemType.MANA) > 0
        )
        if low_boss_hp_mode and not self.config.pet_skill_profile:
            if mana_moves:
                selected = min(
                    mana_moves,
                    key=lambda value: self._resource_rank(value, GemType.MANA),
                )
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    "STEP_3_LOW_BOSS_MANA",
                    (
                        f"Boss HP {boss_hp_current} <= {finisher_threshold}; "
                        "no affordable CAST is proven, so selected safe Mana"
                    ),
                    failures,
                    mana_moves,
                    selected=selected,
                )
            failures.append(
                "STEP_3_LOW_BOSS_MANA: low-boss-HP mode has no safe Mana move"
            )

        # STEP 3: outside low-boss-HP mode, safe Rage below the configured
        # target remains ahead of safe Mana.  With no low-boss Mana move, Rage
        # is still a legal fallback rather than forcing an unsafe move/PASS.
        rage_target = self.config.rage_target
        if self.config.pet_skill_profile:
            failures.append("STEP_3_RAGE: replaced by current Pet Skill deficits")
        elif player is None or player.power is None:
            failures.append("STEP_3_RAGE: player Rage UNKNOWN")
        elif player.power < rage_target:
            rage_moves = tuple(
                value for value in safe_moves if value.total.effective(GemType.RAGE) > 0
            )
            if rage_moves:
                selected = min(rage_moves, key=lambda value: self._resource_rank(value, GemType.RAGE))
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    "STEP_3_RAGE",
                    f"Player Rage {player.power} < {rage_target} and a safe Rage move exists",
                    failures,
                    rage_moves,
                    selected=selected,
                )
            failures.append(f"STEP_3_RAGE: Rage below {rage_target} but no safe Rage move")
        else:
            failures.append(f"STEP_3_RAGE: player Rage {player.power} is already >= {rage_target}")

        if mana_moves and not self.config.pet_skill_profile:
            selected = min(mana_moves, key=lambda value: self._resource_rank(value, GemType.MANA))
            return self._decision(
                state,
                PolicyAction.SWAP,
                "STEP_3_MANA",
                "No safe Rage priority applies; selected a safe Mana move",
                failures,
                mana_moves,
                selected=selected,
            )
        failures.append(
            "STEP_3_MANA: replaced by current Pet Skill deficits"
            if self.config.pet_skill_profile
            else "STEP_3_MANA: no safe Mana move"
        )

        # STEP 4: health threshold depends on configured play style.
        my_hp = _ratio(player.hp, player.max_hp) if player is not None else None
        boss_hp = _ratio(boss.hp, boss.max_hp) if boss is not None else None
        health_threshold = self.config.low_hp_ratio
        if my_hp is None or boss_hp is None:
            failures.append("STEP_4_HEALTH: HP ratio UNKNOWN")
        elif boss_hp > 0.50 and my_hp < health_threshold:
            health_moves = tuple(
                value for value in safe_moves if value.total.effective(GemType.HEALTH) > 0
            )
            if health_moves:
                selected = min(
                    health_moves,
                    key=lambda value: self._resource_rank(value, GemType.HEALTH),
                )
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    "STEP_4_HEALTH",
                    f"Boss HP {boss_hp:.3f} > 0.5 and player HP {my_hp:.3f} < {health_threshold:.2f}",
                    failures,
                    health_moves,
                    selected=selected,
                )
            failures.append("STEP_4_HEALTH: low HP condition met but no safe Health move")
        else:
            failures.append("STEP_4_HEALTH: configured HP condition is not met")

        # STEP 5: CAST above the stockpile threshold, then exact high/low
        # boss-resource branches.  `attack_cards` was resolved before STEP 3.
        stockpile = self.config.cast_mana_stockpile_threshold
        if self.config.pet_skill_profile:
            failures.append("STEP_5_CAST: prohibited by DamageCard.PET_SKILL")
        elif player_mana is not None and player_mana > stockpile:
            usable = tuple(card for card in attack_cards if player_mana >= _attack_cost(card))
            if usable:
                card = min(usable, key=lambda value: (value.card_id, value.object_address))
                return self._decision(
                    state,
                    PolicyAction.CAST,
                    "STEP_5_CAST",
                    f"Player mana {player_mana} > {stockpile}; CAST preserves the configured reserve",
                    failures,
                    evaluations,
                    card=card,
                    candidate_count=len(usable),
                )
            failures.append(f"STEP_5_CAST: mana >{stockpile} but no proven usable Attack card")
        else:
            failures.append(
                f"STEP_5_CAST: player mana is UNKNOWN or not greater than {stockpile}"
            )

        boss_mana = boss.mana if boss is not None else None
        boss_rage = boss.power if boss is not None else None
        high_mana = self.config.boss_high_mana
        high_rage = self.config.boss_high_rage
        low_resource = self.config.boss_low_resource
        drain_moves = tuple(
            value for value in safe_moves if value.total.effective(GemType.DRAIN) > 0
        )
        shield_moves = tuple(
            value for value in safe_moves if value.total.effective(GemType.SHIELD) > 0
        )
        if (
            boss_mana is not None
            and boss_rage is not None
            and boss_mana > high_mana
            and boss_rage > high_rage
        ):
            if drain_moves:
                selected = min(
                    drain_moves,
                    key=lambda value: self._resource_rank(value, GemType.DRAIN),
                )
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    "STEP_5_DRAIN",
                    f"Boss mana {boss_mana} > {high_mana} and Rage {boss_rage} > {high_rage}",
                    failures,
                    drain_moves,
                    selected=selected,
                )
            failures.append("STEP_5_DRAIN: high boss resources but no safe Drain move")
        elif (
            boss_mana is not None
            and boss_rage is not None
            and boss_mana < low_resource
            and boss_rage < low_resource
        ):
            if shield_moves:
                selected = min(
                    shield_moves,
                    key=lambda value: self._resource_rank(value, GemType.SHIELD),
                )
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    "STEP_5_SHIELD",
                    f"Boss mana {boss_mana} and Rage {boss_rage} are both below {low_resource}",
                    failures,
                    shield_moves,
                    selected=selected,
                )
            failures.append("STEP_5_SHIELD: low boss resources but no safe Shield move")
        elif boss_mana is None or boss_rage is None:
            failures.append("STEP_5_RESOURCE: boss Mana/Rage UNKNOWN")
        else:
            # The user permits Drain at this stage only for the explicit high-
            # resource branch above, or when Drain is literally the sole safe
            # move (handled below).  Therefore an available safe Shield is the
            # protective choice for an intermediate boss-resource state.
            if shield_moves:
                selected = min(
                    shield_moves,
                    key=lambda value: self._resource_rank(value, GemType.SHIELD),
                )
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    "STEP_5_SHIELD_INTERMEDIATE",
                    f"Boss resources ({boss_mana}, {boss_rage}) are not high enough for Drain; selected safe Shield",
                    failures,
                    shield_moves,
                    selected=selected,
                )
            failures.append(
                f"STEP_5_RESOURCE: intermediate boss resources ({boss_mana}, {boss_rage}) and no safe Shield move"
            )

        # User rule: Drain is normally resource-dependent, but it is still
        # mandatory when it is literally the only Sword-safe move remaining.
        if len(safe_moves) == 1:
            only_safe = safe_moves[0]
            if only_safe.total.effective(GemType.DRAIN) > 0:
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    "STEP_5_DRAIN_ONLY_SAFE",
                    "Drain is the only Sword-safe move on the board",
                    failures,
                    safe_moves,
                    selected=only_safe,
                )

        # A low-resource boss normally asks for Shield, but a board may offer
        # no safe Shield/Mana/Rage/Drain move at all.  If every remaining safe
        # candidate is exclusively a Health result, taking the predictable
        # Health move follows the user's rule that PASS is reserved for a
        # board without a safe move.  This is intentionally not a general
        # resource fallback.
        non_health_resources = (
            GemType.SWORD,
            GemType.MANA,
            GemType.RAGE,
            GemType.SHIELD,
            GemType.DRAIN,
        )
        if safe_moves and all(
            value.total.effective(GemType.HEALTH) > 0
            and all(
                value.total.effective(gem) == 0
                for gem in non_health_resources
            )
            for value in safe_moves
        ):
            selected = min(safe_moves, key=self._health_only_fallback_rank)
            return self._decision(
                state,
                PolicyAction.SWAP,
                "STEP_5_HEALTH_ONLY_SAFE",
                "Health is the only safe resource result on the board; selected the most calculable safe Health move",
                failures,
                safe_moves,
                selected=selected,
            )

        # STEP 6/7: PASS requires durable game-owned evidence. Mandatory always wins.
        if mandatory:
            # Sword-hold analysis is intentionally lazy: ordinary safe policy
            # must win first, and replaying two additional plies is unnecessary
            # on the common path.  The exception is relevant here only when no
            # genuinely safe move exists and PASS is prohibited.
            if deferred_unique_sword is not None and not safe_moves:
                sword_hold_moves = tuple(
                    (value, hold)
                    for value in evaluations
                    if value.sword_effective == 0
                    and (hold := evaluate_sword_hold(value)).guaranteed_favorable
                )
            if sword_hold_moves:
                selected, hold = min(
                    sword_hold_moves,
                    key=lambda item: self._sword_hold_rank(item[0], item[1]),
                )
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    "STEP_7_MANDATORY_SWORD_HOLD",
                    (
                        "PASS is prohibited; selected a proven off-region move "
                        f"that gives at most {hold.opponent_sword_effective_max} "
                        "effective Sword and guarantees at least "
                        f"{hold.followup_sword_effective_min} effective Sword "
                        "on our known follow-up"
                    ),
                    failures,
                    tuple(value for value, _hold in sword_hold_moves),
                    selected=selected,
                )
            selected = min(evaluations, key=self._mandatory_rank)
            return self._decision(
                state,
                PolicyAction.SWAP,
                "STEP_7_MANDATORY",
                "First runtime local turn or two game-owned consecutive passes prohibits PASS; chose minimum Sword risk with Shield tie-break",
                failures,
                evaluations,
                selected=selected,
            )
        # The user permits PASS only when no Sword-safe move remains.  All
        # explicit resource priorities above have already been exhausted, so
        # retain progress with the lowest-risk safe move instead of inventing
        # an undefined/pause state.  This commonly covers safe Rage after the
        # tactical 100-Rage threshold has already been reached.
        if safe_moves:
            selected = min(safe_moves, key=self._mandatory_rank)
            return self._decision(
                state,
                PolicyAction.SWAP,
                "STEP_5_SAFE_FALLBACK",
                "Explicit resource priorities were exhausted; selected the minimum-risk safe move because PASS requires zero safe moves",
                failures,
                safe_moves,
                selected=selected,
            )
        if not safe_moves:
            skip_count = state.battle.consecutive_passes
            threshold = state.battle.consecutive_pass_threshold
            source = state.battle.consecutive_pass_source
            if idle_status in {
                GameOwnedIdleStatus.RESET_BASELINE_CONFIRMED,
                GameOwnedIdleStatus.PASS_ALLOWED,
            }:
                if idle_status is GameOwnedIdleStatus.RESET_BASELINE_CONFIRMED:
                    evidence = (
                        state.battle.consecutive_pass_reset_evidence
                        or "accepted consuming action"
                    )
                    why = (
                        "No safe move and a production-ready reset baseline "
                        f"is confirmed by {evidence}; PASS is allowed without "
                        "inventing idleCount=0"
                    )
                else:
                    why = (
                        f"No safe move and game-owned {source} reports "
                        f"{skip_count}/{threshold}; PASS is allowed"
                    )
                return self._decision(
                    state,
                    PolicyAction.PASS,
                    "STEP_6_PASS",
                    why,
                    failures,
                    evaluations,
                )
            if deferred_unique_sword is not None:
                sword_hold_moves = tuple(
                    (value, hold)
                    for value in evaluations
                    if value.sword_effective == 0
                    and (hold := evaluate_sword_hold(value)).guaranteed_favorable
                )
            if sword_hold_moves:
                selected, hold = min(
                    sword_hold_moves,
                    key=lambda item: self._sword_hold_rank(item[0], item[1]),
                )
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    "STEP_2_SWORD_HOLD",
                    (
                        "Authoritative PASS is unavailable; selected a proven "
                        "off-region Sword-hold line where every known boss "
                        f"Sword reply gives at most {hold.opponent_sword_effective_max} "
                        "and leaves at least "
                        f"{hold.followup_sword_effective_min} effective Sword "
                        "for our following move"
                    ),
                    failures,
                    tuple(value for value, _hold in sword_hold_moves),
                    selected=selected,
                )
            if idle_status is GameOwnedIdleStatus.UNKNOWN:
                return self._decision(
                    state,
                    PolicyAction.NONE,
                    "STEP_6_PASS",
                    "No safe move, but the game-owned consecutive-pass state is UNKNOWN",
                    failures,
                    evaluations,
                    blocker="GAME_OWNED_SKIP_STATE_UNKNOWN",
                )
            if idle_status is not GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION:
                raise AssertionError("unexpected game-owned idle status")
            selected = min(evaluations, key=self._mandatory_rank)
            return self._decision(
                state,
                PolicyAction.SWAP,
                "STEP_7_MANDATORY",
                f"Game-owned {source} reports {skip_count}/{threshold}; PASS prohibited",
                failures,
                evaluations,
                selected=selected,
            )

        raise AssertionError("safe-move fallback must make STEP 6 exhaustive")
