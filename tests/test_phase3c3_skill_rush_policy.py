from __future__ import annotations

from dataclasses import replace
from pathlib import Path
from types import SimpleNamespace
import tempfile
import unittest
from unittest.mock import patch

from pokiguard_v2.basic_policy import (
    BasicPolicyEngine,
    PlayStyle,
    PolicyAction,
    PolicyConfig,
    SkillRushMatchContext,
    _known_gem_count,
    _known_sword_count,
)
from pokiguard_v2.board_simulator import ResourceResult, ResourceTally, evaluate_all_moves
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
from pokiguard_v2.gameplay_profile import (
    DamageCardMode,
    EvolutionTarget,
    MainPetType,
    PetSkillFireCondition,
)
from pokiguard_v2.pet_configuration import (
    FarmPolicyUnavailable,
    GameplayConfig,
    PLAY_STYLE_LABELS,
    basic_policy_config,
)
from pokiguard_v2.state import (
    BoardState,
    CellState,
    CombatSessionKey,
    GameOwnedIdleStatus,
    GemType,
)
from tests.test_phase3c1_pet_skill_policy import (
    SESSION,
    capability,
    session_state,
    skill_policy,
)
from tools.basic_auto_bot import (
    Counters,
    _current_skill_rush_match_context,
    _record_policy_observation,
)
from tools.farm_cycle import _combat_args
from tools.farm_run import build_parser as build_farm_parser


def rush_policy(
    *,
    threshold: int = 10,
    condition: PetSkillFireCondition = PetSkillFireCondition.SWORD_COUNT,
) -> BasicPolicyEngine:
    return BasicPolicyEngine(
        PolicyConfig(
            play_style=PlayStyle.SKILL_RUSH,
            mana_priority=None,
            main_pet=MainPetType.LEGENDARY,
            evolution=EvolutionTarget.NONE,
            damage_card=DamageCardMode.PET_SKILL,
            pet_skill_fire_condition=condition,
            pet_skill_fire_value=(
                None
                if condition is PetSkillFireCondition.SKILL_COST_READY
                else threshold
            ),
        )
    )


def candidate(
    base,
    *,
    mana: int = 0,
    rage: int = 0,
    sword: int = 0,
    drain: int = 0,
    shield: int = 0,
    direct_replies: int = 0,
    indirect_replies: int = 0,
    calculable: bool = True,
):
    resources = ResourceResult(
        tuple(
            (gem, ResourceTally(value, value))
            for gem, value in (
                (GemType.MANA, mana),
                (GemType.RAGE, rage),
                (GemType.SWORD, sword),
                (GemType.DRAIN, drain),
                (GemType.SHIELD, shield),
            )
            if value
        )
    )
    risky = direct_replies > 0 or indirect_replies > 0
    return replace(
        base,
        direct=resources,
        cascade=ResourceResult(),
        total=resources,
        calculable=calculable,
        sword_risk=replace(
            base.sword_risk,
            opponent_sword_replies=direct_replies,
            opponent_sword_reply_cells_max=3 if direct_replies else 0,
            opponent_sword_reply_effective_max=3 if direct_replies else 0,
            indirect_sword_replies=indirect_replies,
            indirect_sword_effective_max=3 if indirect_replies else 0,
            danger_score=10 if risky else 0,
            safe=not risky,
        ),
    )


def boss_state(*, hp: int, maximum: int, mana: int = 200, rage: int = 200):
    state = session_state(mana=mana, rage=rage, boss_hp=hp)
    boss = replace(state.opponents[0], hp=hp, max_hp=maximum)
    return replace(state, opponents=(boss,), participants=(state.player, boss))


def with_idle_status(
    state,
    status: GameOwnedIdleStatus,
    *,
    count: int,
):
    return replace(
        state,
        battle=replace(
            state.battle,
            consecutive_passes=count,
            consecutive_pass_threshold=3,
            consecutive_pass_source="PlayerData.countSkipTurn",
            consecutive_pass_status=status,
            consecutive_pass_reset_evidence=(
                "accepted consuming action"
                if status is GameOwnedIdleStatus.RESET_BASELINE_CONFIRMED
                else None
            ),
        ),
    )


def with_player_hp(state, *, hp: int, maximum: int = 100):
    player = replace(state.player, hp=hp, max_hp=maximum)
    participants = tuple(
        player if participant.is_local else participant
        for participant in state.participants
    )
    return replace(state, player=player, participants=participants)


def board_with_swords(state, count: int, *, unknown_after: bool = False) -> BoardState:
    positions = [(row, col) for row in range(8) for col in range(8)]
    swords = set(positions[:count])
    unknown = positions[count] if unknown_after else None
    return BoardState(
        tuple(
            tuple(
                CellState(
                    row,
                    col,
                    (
                        GemType.SWORD
                        if (row, col) in swords
                        else GemType.UNKNOWN
                        if (row, col) == unknown
                        else GemType.HEALTH
                        if cell.gem is GemType.SWORD
                        else cell.gem
                    ),
                    1,
                )
                for col, cell in enumerate(values)
            )
            for row, values in enumerate(state.board.cells)
        )
    )


def board_with_gem_count(
    state,
    gem_type: GemType,
    count: int,
    *,
    unknown_after: bool = False,
) -> BoardState:
    positions = [(row, col) for row in range(8) for col in range(8)]
    selected = set(positions[:count])
    unknown = positions[count] if unknown_after and count < 64 else None
    return BoardState(
        tuple(
            tuple(
                CellState(
                    row,
                    col,
                    (
                        gem_type
                        if (row, col) in selected
                        else GemType.UNKNOWN
                        if (row, col) == unknown
                        else GemType.HEALTH
                    ),
                    1,
                )
                for col, cell in enumerate(values)
            )
            for row, values in enumerate(state.board.cells)
        )
    )


def board_from_names(
    rows: tuple[tuple[str, ...], ...],
    *,
    multipliers: tuple[tuple[int, ...], ...] | None = None,
) -> BoardState:
    return BoardState(
        tuple(
            tuple(
                CellState(
                    row,
                    col,
                    GemType(gem),
                    multipliers[row][col] if multipliers is not None else 1,
                )
                for col, gem in enumerate(values)
            )
            for row, values in enumerate(rows)
        )
    )


FAILED_B1_TURN_27_ROWS = (
    ("mana", "mana", "shield", "drain", "mana", "rage", "drain", "shield"),
    ("rage", "mana", "sword", "health", "mana", "mana", "shield", "sword"),
    ("sword", "drain", "health", "sword", "drain", "sword", "mana", "mana"),
    ("drain", "shield", "rage", "mana", "rage", "drain", "shield", "shield"),
    ("shield", "mana", "sword", "mana", "shield", "sword", "mana", "mana"),
    ("mana", "drain", "health", "health", "mana", "shield", "rage", "shield"),
    ("rage", "shield", "mana", "drain", "sword", "drain", "shield", "drain"),
    ("sword", "health", "rage", "sword", "rage", "mana", "health", "health"),
)

FAILED_B1_TURN_13_ROWS = (
    ("health", "sword", "mana", "drain", "sword", "drain", "shield", "sword"),
    ("sword", "shield", "health", "mana", "shield", "health", "drain", "mana"),
    ("drain", "drain", "shield", "health", "shield", "sword", "health", "shield"),
    ("rage", "rage", "health", "health", "drain", "shield", "mana", "health"),
    ("mana", "drain", "shield", "drain", "mana", "drain", "rage", "mana"),
    ("rage", "drain", "health", "shield", "sword", "shield", "drain", "shield"),
    ("health", "health", "rage", "drain", "rage", "drain", "shield", "drain"),
    ("sword", "health", "drain", "sword", "shield", "mana", "health", "health"),
)


# Exact turn-13 board from FarmRun ba0b3666517d4739ac59e25cb42d1583.
# Mana/Rage were already ready, but the old setup rank selected the vertical
# Shield clear in column 6. Its three-cell refill can place an UNKNOWN Sword at
# (row 1, column 6), immediately joining the known Sword pair at columns 7-8.
REPORTED_TOP_SWORD_PAIR_SETUP_ROWS = (
    ("health", "sword", "mana", "drain", "shield", "drain", "sword", "sword"),
    ("drain", "rage", "sword", "mana", "mana", "shield", "drain", "health"),
    ("rage", "mana", "drain", "shield", "rage", "shield", "mana", "rage"),
    ("drain", "rage", "health", "sword", "drain", "health", "health", "shield"),
    ("mana", "sword", "shield", "rage", "rage", "shield", "shield", "rage"),
    ("drain", "shield", "rage", "health", "health", "rage", "drain", "mana"),
    ("health", "sword", "drain", "shield", "mana", "sword", "health", "mana"),
    ("health", "mana", "shield", "drain", "mana", "mana", "drain", "shield"),
)

REPORTED_TOP_SWORD_PAIR_SETUP_MULTIPLIERS = (
    (1, 1, 1, 1, 2, 1, 1, 1),
    (1, 1, 1, 2, 1, 1, 1, 3),
    (1, 1, 1, 1, 2, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
    (1, 1, 1, 4, 1, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
    (1, 1, 2, 1, 1, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
)


PHASE3D1_SETUP_BLOCKED_ROWS = (
    ("drain", "shield", "mana", "mana", "health", "rage", "rage", "mana"),
    ("mana", "health", "drain", "health", "drain", "rage", "mana", "drain"),
    ("shield", "sword", "drain", "shield", "shield", "mana", "drain", "shield"),
    ("health", "rage", "health", "shield", "drain", "health", "shield", "health"),
    ("sword", "shield", "health", "drain", "rage", "mana", "sword", "rage"),
    ("shield", "drain", "mana", "drain", "shield", "health", "mana", "shield"),
    ("health", "health", "shield", "sword", "mana", "drain", "rage", "drain"),
    ("health", "mana", "shield", "shield", "mana", "drain", "shield", "drain"),
)


# Exact screen-oriented boards from the stopped Mode-B run
# 26fbc39c62ca469e89c779ee5d2e7f2b.  The former policy selected an unsafe
# Mana/Rage move on turn 1 and an unsafe distance-two setup move on turn 13.
FAILED_MODE_B_TURN_1_ROWS = (
    ("rage", "rage", "shield", "drain", "mana", "health", "drain", "rage"),
    ("shield", "drain", "shield", "health", "mana", "shield", "mana", "mana"),
    ("sword", "health", "rage", "mana", "drain", "rage", "rage", "shield"),
    ("mana", "sword", "health", "mana", "health", "drain", "shield", "drain"),
    ("sword", "drain", "health", "shield", "health", "rage", "rage", "drain"),
    ("sword", "drain", "mana", "sword", "sword", "shield", "mana", "health"),
    ("shield", "rage", "drain", "rage", "rage", "mana", "rage", "drain"),
    ("shield", "sword", "rage", "mana", "mana", "shield", "drain", "drain"),
)

FAILED_MODE_B_TURN_13_ROWS = (
    ("shield", "drain", "sword", "mana", "mana", "health", "health", "rage"),
    ("drain", "shield", "health", "drain", "mana", "sword", "drain", "sword"),
    ("mana", "shield", "drain", "drain", "sword", "drain", "rage", "rage"),
    ("shield", "sword", "mana", "health", "sword", "shield", "health", "mana"),
    ("health", "drain", "rage", "shield", "mana", "rage", "shield", "shield"),
    ("shield", "drain", "rage", "shield", "sword", "rage", "drain", "drain"),
    ("sword", "rage", "health", "health", "sword", "shield", "mana", "health"),
    ("rage", "drain", "mana", "drain", "mana", "drain", "mana", "drain"),
)

# Exact turn-13 board from smoke FarmRun b9a40538eda54da595b0d4b76fae1f41.
# The old no-safe fallback excluded Sword-consuming moves before comparing
# opponent reply risk and therefore left the boss a better Sword opportunity.
SMOKE_MODE_B_TURN_13_ROWS = (
    ("shield", "rage", "health", "rage", "shield", "sword", "drain", "health"),
    ("shield", "shield", "mana", "health", "sword", "drain", "drain", "health"),
    ("rage", "health", "shield", "rage", "health", "drain", "sword", "sword"),
    ("drain", "shield", "sword", "drain", "shield", "sword", "shield", "mana"),
    ("drain", "rage", "sword", "rage", "drain", "rage", "mana", "drain"),
    ("mana", "mana", "shield", "drain", "sword", "health", "rage", "health"),
    ("rage", "shield", "drain", "sword", "sword", "mana", "shield", "health"),
    ("mana", "drain", "health", "health", "drain", "mana", "shield", "mana"),
)

SMOKE_MODE_B_TURN_13_MULTIPLIERS = (
    (2, 1, 1, 1, 3, 2, 1, 1),
    (1, 1, 1, 1, 1, 2, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
    (1, 1, 1, 2, 1, 2, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
)


# Exact pre-skill boards from FarmRun e4dbca0f44ea46cca5afac3984766dda.
# The stopped run proved that the inclusive fire threshold was correct, but
# the former fallback consumed Sword at turns 13 and 17 while Rage >= 100.
LATEST_LIVE_TURN_13_ROWS = (
    ("sword", "sword", "mana", "sword", "shield", "shield", "drain", "rage"),
    ("drain", "mana", "mana", "drain", "sword", "rage", "rage", "mana"),
    ("mana", "rage", "sword", "mana", "mana", "drain", "shield", "sword"),
    ("shield", "shield", "rage", "sword", "health", "shield", "rage", "shield"),
    ("drain", "drain", "mana", "rage", "sword", "mana", "health", "drain"),
    ("mana", "sword", "rage", "shield", "shield", "drain", "health", "rage"),
    ("sword", "health", "health", "drain", "sword", "sword", "drain", "mana"),
    ("mana", "drain", "shield", "shield", "drain", "mana", "shield", "shield"),
)

LATEST_LIVE_TURN_13_MULTIPLIERS = (
    (1, 1, 1, 2, 1, 2, 1, 1),
    (1, 2, 1, 1, 1, 1, 1, 1),
    (1, 2, 1, 1, 2, 1, 1, 1),
    (1, 3, 3, 1, 2, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
)

LATEST_LIVE_TURN_17_ROWS = (
    ("shield", "mana", "shield", "rage", "mana", "rage", "drain", "rage"),
    ("sword", "mana", "drain", "drain", "sword", "rage", "rage", "mana"),
    ("drain", "rage", "mana", "drain", "sword", "drain", "shield", "sword"),
    ("mana", "rage", "sword", "sword", "health", "shield", "rage", "shield"),
    ("shield", "shield", "drain", "mana", "sword", "mana", "health", "drain"),
    ("drain", "drain", "mana", "shield", "shield", "drain", "health", "rage"),
    ("mana", "health", "health", "drain", "sword", "sword", "drain", "mana"),
    ("mana", "drain", "shield", "shield", "drain", "mana", "shield", "shield"),
)

LATEST_LIVE_TURN_17_MULTIPLIERS = (
    (1, 3, 4, 3, 4, 2, 1, 1),
    (4, 1, 1, 1, 2, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
    (1, 2, 2, 1, 2, 1, 1, 1),
    (1, 3, 1, 1, 1, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
)

# Exact turn-15 board from FarmRun 03ceea93d6254ed1a4f4dac54562e85a.
# It has 9 physical Sword cells but 12 effective Sword after x3/x2. The old
# physical-cell comparison spent one extra turn on Shield before firing.
WEIGHTED_FIRE_TURN_15_ROWS = (
    ("drain", "sword", "rage", "shield", "rage", "drain", "rage", "sword"),
    ("mana", "rage", "sword", "rage", "drain", "rage", "mana", "shield"),
    ("drain", "shield", "health", "health", "sword", "shield", "drain", "sword"),
    ("rage", "drain", "rage", "shield", "mana", "health", "health", "rage"),
    ("rage", "shield", "mana", "shield", "drain", "shield", "drain", "health"),
    ("health", "drain", "shield", "rage", "mana", "sword", "shield", "shield"),
    ("drain", "sword", "health", "sword", "drain", "shield", "mana", "drain"),
    ("sword", "health", "mana", "drain", "shield", "health", "health", "mana"),
)

WEIGHTED_FIRE_TURN_15_MULTIPLIERS = (
    (1, 3, 1, 1, 3, 1, 1, 1),
    (1, 1, 1, 3, 3, 1, 4, 2),
    (1, 1, 1, 2, 1, 1, 4, 2),
    (1, 2, 2, 2, 1, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
    (1, 1, 2, 1, 1, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
)

# Exact turn-15 board from stopped FarmRun 420227ce72734e28a0fa4a89e0827f7f,
# attempt 3. The old ordering selected safe Shield at (6,3)<->(6,4) while
# Mana was still 90/200. The healthy resource stage must instead take the
# Sword-preserving Mana clear at (0,4)<->(0,5), even though it carries refill
# Sword risk.
HEALTHY_RESOURCE_PRIORITY_TURN_15_ROWS = (
    ("rage", "shield", "mana", "sword", "mana", "shield", "mana", "mana"),
    ("mana", "health", "health", "shield", "sword", "rage", "sword", "drain"),
    ("drain", "shield", "sword", "rage", "mana", "health", "shield", "health"),
    ("sword", "health", "health", "rage", "sword", "sword", "drain", "shield"),
    ("shield", "sword", "health", "mana", "shield", "rage", "rage", "drain"),
    ("rage", "health", "mana", "drain", "rage", "shield", "health", "shield"),
    ("rage", "rage", "shield", "shield", "sword", "shield", "shield", "mana"),
    ("sword", "shield", "mana", "drain", "shield", "drain", "rage", "health"),
)

HEALTHY_RESOURCE_PRIORITY_TURN_15_MULTIPLIERS = (
    (2, 3, 2, 2, 1, 1, 1, 1),
    (3, 1, 1, 1, 1, 2, 1, 1),
    (1, 2, 1, 1, 1, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
    (1, 1, 3, 1, 1, 1, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
    (1, 1, 1, 1, 1, 2, 1, 1),
    (1, 1, 1, 1, 1, 1, 1, 1),
)


class Phase3c3SkillRushPolicyTests(unittest.TestCase):
    def test_generic_board_count_fire_condition_matrix_is_inclusive(self) -> None:
        cases = (
            (PetSkillFireCondition.SWORD_COUNT, GemType.SWORD),
            (PetSkillFireCondition.MANA_GEM_COUNT, GemType.MANA),
            (PetSkillFireCondition.RAGE_GEM_COUNT, GemType.RAGE),
            (PetSkillFireCondition.DRAIN_GEM_COUNT, GemType.DRAIN),
            (PetSkillFireCondition.SHIELD_GEM_COUNT, GemType.SHIELD),
        )
        base = session_state(mana=200, rage=200)
        for condition, gem_type in cases:
            with self.subTest(condition=condition, count=9):
                state = replace(base, board=board_with_gem_count(base, gem_type, 9))
                decision = rush_policy(condition=condition).decide(
                    state, pet_skill_capability=capability()
                )
                self.assertIsNot(decision.action, PolicyAction.PET_SKILL)
                self.assertEqual(decision.trace.selected_known_gem_count, 9)
                self.assertFalse(decision.trace.selected_fire_condition_ready)
            with self.subTest(condition=condition, count=10):
                state = replace(base, board=board_with_gem_count(base, gem_type, 10))
                decision = rush_policy(condition=condition).decide(
                    state, pet_skill_capability=capability()
                )
                self.assertIs(decision.action, PolicyAction.PET_SKILL)
                self.assertEqual(decision.trace.selected_fire_gem_type, gem_type.value)
                self.assertEqual(decision.trace.selected_known_gem_count, 10)
                self.assertTrue(decision.trace.selected_fire_condition_ready)
                self.assertEqual(
                    decision.trace.skill_fire_trigger,
                    "SKILL_RUSH_FIRE_CONDITION_READY",
                )
            with self.subTest(condition=condition, unknown=True):
                board = board_with_gem_count(
                    base, gem_type, 9, unknown_after=True
                )
                self.assertFalse(board.production_ready)
                self.assertEqual(_known_gem_count(board, gem_type), 9)

    def test_generic_fire_conditions_include_x2_x3_x4_effective_value(self) -> None:
        cases = (
            (PetSkillFireCondition.SWORD_COUNT, GemType.SWORD),
            (PetSkillFireCondition.MANA_GEM_COUNT, GemType.MANA),
            (PetSkillFireCondition.RAGE_GEM_COUNT, GemType.RAGE),
            (PetSkillFireCondition.DRAIN_GEM_COUNT, GemType.DRAIN),
            (PetSkillFireCondition.SHIELD_GEM_COUNT, GemType.SHIELD),
        )
        base = session_state(mana=200, rage=200)
        for condition, gem_type in cases:
            with self.subTest(condition=condition):
                board = board_with_gem_count(base, gem_type, 8)
                weighted = BoardState(
                    tuple(
                        tuple(
                            replace(cell, multiplier=3)
                            if (cell.row, cell.col) == (0, 0)
                            else cell
                            for cell in row
                        )
                        for row in board.cells
                    )
                )
                decision = rush_policy(condition=condition).decide(
                    replace(base, board=weighted),
                    pet_skill_capability=capability(),
                )

                self.assertEqual(decision.trace.selected_known_gem_count, 8)
                self.assertEqual(
                    decision.trace.selected_known_gem_effective_count,
                    10,
                )
                self.assertTrue(decision.trace.selected_fire_condition_ready)
                self.assertIs(decision.action, PolicyAction.PET_SKILL)

    def test_live_turn_15_fires_at_nine_sword_cells_twelve_effective(self) -> None:
        state = boss_state(
            hp=62_014,
            maximum=84_180,
            mana=270,
            rage=250,
        )
        state = replace(
            state,
            board=board_from_names(
                WEIGHTED_FIRE_TURN_15_ROWS,
                multipliers=WEIGHTED_FIRE_TURN_15_MULTIPLIERS,
            ),
        )

        decision = rush_policy().decide(
            state,
            pet_skill_capability=capability(),
        )

        self.assertEqual(decision.trace.known_sword_count, 9)
        self.assertEqual(decision.trace.known_sword_effective_count, 12)
        self.assertEqual(decision.trace.selected_known_gem_count, 9)
        self.assertEqual(decision.trace.selected_known_gem_effective_count, 12)
        self.assertTrue(decision.trace.sword_threshold_ready)
        self.assertIs(decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(decision.trace.policy_step, "STEP_1_PET_SKILL")

    def test_every_count_condition_still_requires_runtime_skill_resources(self) -> None:
        cases = (
            (PetSkillFireCondition.SWORD_COUNT, GemType.SWORD),
            (PetSkillFireCondition.MANA_GEM_COUNT, GemType.MANA),
            (PetSkillFireCondition.RAGE_GEM_COUNT, GemType.RAGE),
            (PetSkillFireCondition.DRAIN_GEM_COUNT, GemType.DRAIN),
            (PetSkillFireCondition.SHIELD_GEM_COUNT, GemType.SHIELD),
        )
        base = session_state(mana=199, rage=200)
        for condition, gem_type in cases:
            with self.subTest(condition=condition):
                state = replace(base, board=board_with_gem_count(base, gem_type, 10))
                decision = rush_policy(condition=condition).decide(
                    state, pet_skill_capability=capability()
                )
                self.assertIsNot(decision.action, PolicyAction.PET_SKILL)
                self.assertFalse(decision.trace.skill_ready)
                self.assertTrue(decision.trace.selected_fire_condition_ready)

    def test_skill_cost_ready_uses_authoritative_runtime_cost_without_value(self) -> None:
        insufficient = session_state(mana=199, rage=200)
        decision = rush_policy(
            condition=PetSkillFireCondition.SKILL_COST_READY
        ).decide(insufficient, pet_skill_capability=capability())
        self.assertIsNot(decision.action, PolicyAction.PET_SKILL)
        self.assertFalse(decision.trace.selected_fire_condition_ready)
        self.assertIsNone(decision.trace.pet_skill_fire_value)
        self.assertIsNone(decision.trace.selected_fire_gem_type)

        exact = session_state(mana=200, rage=200)
        decision = rush_policy(
            condition=PetSkillFireCondition.SKILL_COST_READY
        ).decide(exact, pet_skill_capability=capability())
        self.assertIs(decision.action, PolicyAction.PET_SKILL)
        self.assertTrue(decision.trace.selected_fire_condition_ready)
        self.assertIsNone(decision.trace.selected_known_gem_count)

    def test_stable_identity_label_default_and_profile_gate(self) -> None:
        self.assertEqual(PlayStyle.SKILL_RUSH.value, "skill_rush")
        self.assertEqual(
            PLAY_STYLE_LABELS[PlayStyle.SKILL_RUSH],
            "Chịu đấm ăn xôi",
        )
        self.assertIs(GameplayConfig().play_style, PlayStyle.SIMPLE)

        for unsupported in (
            GameplayConfig(play_style=PlayStyle.SKILL_RUSH),
            GameplayConfig(
                play_style=PlayStyle.SKILL_RUSH,
                main_pet=MainPetType.LEGENDARY,
                evolution=EvolutionTarget.NORMAL,
                damage_card=DamageCardMode.DEFAULT_ATTACK,
            ),
        ):
            self.assertEqual(
                unsupported.farm_policy_blocker_reason,
                "SKILL_RUSH_PROFILE_NOT_IMPLEMENTED",
            )
            with self.assertRaisesRegex(
                FarmPolicyUnavailable,
                "SKILL_RUSH_PROFILE_NOT_IMPLEMENTED",
            ):
                basic_policy_config(unsupported)

        supported = GameplayConfig(
            play_style=PlayStyle.SKILL_RUSH,
            main_pet=MainPetType.LEGENDARY,
            evolution=EvolutionTarget.NONE,
            damage_card=DamageCardMode.PET_SKILL,
        )
        self.assertTrue(supported.farm_policy_supported)
        self.assertIsNone(supported.farm_policy_blocker_reason)
        self.assertIs(basic_policy_config(supported).play_style, PlayStyle.SKILL_RUSH)

    def test_preferences_persist_machine_value_without_starting(self) -> None:
        config = DesktopConfig(
            play_style=PlayStyle.SKILL_RUSH,
            main_pet=MainPetType.LEGENDARY,
            evolution=EvolutionTarget.NONE,
            damage_card=DamageCardMode.PET_SKILL,
            pet_skill_fire_value=17,
        )
        with tempfile.TemporaryDirectory() as temporary:
            path = Path(temporary) / "preferences.json"
            store = DesktopPreferenceStore(path)
            store.save(config, game_location="fixture.exe")
            self.assertIn('"play_style": "skill_rush"', path.read_text(encoding="utf-8"))
            restored = store.load()
        self.assertTrue(restored.loaded)
        self.assertIs(restored.config.play_style, PlayStyle.SKILL_RUSH)
        self.assertEqual(restored.config.pet_skill_fire_value, 17)

    def test_resource_progress_skips_available_sword_only_in_rush(self) -> None:
        state = session_state(mana=0, rage=0)
        bases = evaluate_all_moves(state.board)[:2]
        sword = candidate(bases[0], sword=8)
        mana = candidate(bases[1], mana=3)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(sword, mana),
        ):
            rushed = rush_policy().decide(state, pet_skill_capability=capability())
            standard = skill_policy().decide(state, pet_skill_capability=capability())

        self.assertEqual(rushed.trace.policy_step, "SKILL_RUSH_RESOURCE_PROGRESS")
        self.assertEqual(rushed.move, mana.move)
        self.assertTrue(rushed.trace.skipped_current_sword_for_resource)
        self.assertEqual(standard.trace.policy_step, "STEP_2_SWORD")
        self.assertEqual(standard.move, sword.move)

    def test_safe_progress_rejects_direct_and_indirect_sword_reply(self) -> None:
        state = session_state(mana=0, rage=0)
        bases = evaluate_all_moves(state.board)[:2]
        risky_progress = candidate(
            bases[0],
            mana=6,
            rage=6,
            direct_replies=1,
            indirect_replies=1,
        )
        safe_progress = candidate(bases[1], mana=2, rage=2)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(risky_progress, safe_progress),
        ):
            rushed = rush_policy().decide(state, pet_skill_capability=capability())
            standard = skill_policy().decide(state, pet_skill_capability=capability())

        self.assertEqual(rushed.move, safe_progress.move)
        self.assertFalse(rushed.trace.selected_move_left_direct_boss_sword)
        self.assertFalse(rushed.trace.selected_move_left_indirect_boss_sword)
        self.assertEqual(
            rushed.trace.selected_candidate.hard_survival_status,
            "UNKNOWN_NO_LETHALITY_MODEL",
        )
        self.assertEqual(standard.move, safe_progress.move)

    def test_full_resource_has_zero_credit_and_requirement_close_wins(self) -> None:
        state = session_state(mana=220, rage=170)
        bases = evaluate_all_moves(state.board)[:3]
        overcollect_mana = candidate(bases[0], mana=20)
        partial_rage = candidate(bases[1], rage=25)
        close_rage = candidate(bases[2], rage=30)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(overcollect_mana, partial_rage, close_rage),
        ):
            decision = rush_policy().decide(state, pet_skill_capability=capability())

        self.assertEqual(decision.move, close_rage.move)
        traces = {item.move: item for item in decision.trace.candidates}
        self.assertEqual(traces[overcollect_mana.move].readiness_progress, 0.0)
        self.assertEqual(traces[overcollect_mana.move].requirements_completed_after_move, 0)
        self.assertEqual(traces[close_rage.move].requirements_completed_after_move, 1)

    def test_equal_readiness_preserves_existing_sword(self) -> None:
        state = session_state(mana=0, rage=0)
        bases = evaluate_all_moves(state.board)[:2]
        no_sword = candidate(bases[0], mana=4)
        opportunistic_sword = candidate(bases[1], mana=4, sword=3)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(no_sword, opportunistic_sword),
        ):
            decision = rush_policy().decide(state, pet_skill_capability=capability())
        self.assertEqual(decision.move, no_sword.move)
        self.assertTrue(decision.trace.skipped_current_sword_for_resource)

    def test_multi_resource_progress_counts_both_and_unknown_gets_no_bonus(self) -> None:
        state = session_state(mana=190, rage=190)
        bases = evaluate_all_moves(state.board)[:3]
        mana_only = candidate(bases[0], mana=10)
        both = candidate(bases[1], mana=10, rage=10)
        unknown = candidate(bases[2], calculable=False)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(unknown, mana_only, both),
        ):
            decision = rush_policy().decide(state, pet_skill_capability=capability())

        self.assertEqual(decision.move, both.move)
        self.assertEqual(
            decision.trace.selected_candidate.requirements_completed_after_move,
            2,
        )
        traces = {item.move: item for item in decision.trace.candidates}
        self.assertEqual(traces[unknown.move].readiness_progress, 0.0)

    def test_ready_skill_requires_final_fire_condition_and_technical_gates_remain_hard(self) -> None:
        state = boss_state(hp=40_000, maximum=100_000)
        state = replace(state, board=board_with_swords(state, 11))
        ready = rush_policy().decide(state, pet_skill_capability=capability())
        self.assertEqual(ready.action, PolicyAction.PET_SKILL)
        self.assertEqual(ready.trace.policy_step, "STEP_1_PET_SKILL")
        self.assertEqual(
            ready.trace.skill_fire_trigger,
            "SKILL_RUSH_FIRE_CONDITION_READY",
        )

        blocked_state = replace(
            state,
            battle=replace(state.battle, is_local_turn=False, client_move_allowed=False),
        )
        blocked = rush_policy().decide(
            blocked_state,
            pet_skill_capability=capability(),
        )
        self.assertEqual(blocked.action, PolicyAction.NONE)
        self.assertEqual(blocked.trace.blocker, "LOCAL_TURN_NOT_ACTIONABLE")

    def test_final_pre_skill_fire_matrix(self) -> None:
        cases = (
            (45_000, 100_000, 5, PolicyAction.SWAP, None),
            (75_000, 100_000, 12, PolicyAction.PET_SKILL, "SKILL_RUSH_FIRE_CONDITION_READY"),
            (75_000, 100_000, 5, PolicyAction.SWAP, None),
            (1, 100_000, 5, PolicyAction.SWAP, None),
        )
        for hp, maximum, swords, action, trigger in cases:
            with self.subTest(hp=hp, swords=swords):
                state = boss_state(hp=hp, maximum=maximum)
                state = replace(state, board=board_with_swords(state, swords))
                decision = rush_policy().decide(
                    state,
                    pet_skill_capability=capability(),
                )
                self.assertEqual(decision.action, action)
                self.assertEqual(decision.trace.skill_fire_trigger, trigger)
                self.assertEqual(decision.trace.known_sword_count, swords)

    def test_low_boss_hp_never_shortcuts_first_skill_threshold(self) -> None:
        state = boss_state(hp=1, maximum=100_000)
        state = replace(state, board=board_with_swords(state, 4))
        decision = rush_policy().decide(state, pet_skill_capability=capability())
        self.assertIsNot(decision.action, PolicyAction.PET_SKILL)
        self.assertFalse(decision.trace.sword_threshold_ready)
        self.assertIsNone(decision.trace.skill_fire_trigger)

    def test_configured_threshold_is_inclusive_and_unknown_counts_zero(self) -> None:
        state = boss_state(hp=75_000, maximum=100_000)
        ten = replace(state, board=board_with_swords(state, 10))
        eleven = replace(state, board=board_with_swords(state, 11))
        unknown_board = board_with_swords(state, 10, unknown_after=True)

        ten_decision = rush_policy().decide(ten, pet_skill_capability=capability())
        eleven_decision = rush_policy().decide(
            eleven, pet_skill_capability=capability()
        )

        self.assertEqual(ten_decision.trace.known_sword_count, 10)
        self.assertEqual(_known_sword_count(unknown_board), 10)
        self.assertTrue(ten_decision.trace.sword_threshold_ready)
        self.assertEqual(ten_decision.trace.configured_sword_threshold, 10)
        self.assertEqual(ten_decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(eleven_decision.trace.known_sword_count, 11)
        self.assertTrue(eleven_decision.trace.sword_threshold_ready)
        self.assertEqual(eleven_decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(
            eleven_decision.trace.skill_fire_trigger,
            "SKILL_RUSH_FIRE_CONDITION_READY",
        )

        fifteen = replace(state, board=board_with_swords(state, 15))
        sixteen = replace(state, board=board_with_swords(state, 16))
        self.assertEqual(
            rush_policy(threshold=15).decide(
                fifteen, pet_skill_capability=capability()
            ).action,
            PolicyAction.PET_SKILL,
        )
        self.assertEqual(
            rush_policy(threshold=15).decide(
                sixteen, pet_skill_capability=capability()
            ).action,
            PolicyAction.PET_SKILL,
        )

    def test_failed_b1_turn_13_no_longer_fires_at_eight_sword(self) -> None:
        state = boss_state(hp=60_552, maximum=84_180)
        state = replace(state, board=board_from_names(FAILED_B1_TURN_13_ROWS))

        decision = rush_policy().decide(state, pet_skill_capability=capability())

        self.assertEqual(decision.trace.known_sword_count, 8)
        self.assertIsNot(decision.action, PolicyAction.PET_SKILL)
        self.assertIsNone(decision.trace.skill_fire_trigger)

    def test_ready_setup_uses_clear_at_least_two_cells_from_sword(self) -> None:
        rows = [list(row) for row in FAILED_B1_TURN_13_ROWS]
        rows[0][7] = "health"
        state = boss_state(hp=60_552, maximum=84_180)
        state = replace(
            state,
            board=board_from_names(tuple(tuple(row) for row in rows)),
        )

        decision = rush_policy().decide(state, pet_skill_capability=capability())

        self.assertEqual(decision.trace.policy_step, "SKILL_RUSH_BOARD_SETUP")
        self.assertEqual(decision.trace.known_sword_count, 7)
        self.assertIsNotNone(decision.trace.selected_candidate)
        selected = decision.trace.selected_candidate
        assert selected is not None
        self.assertEqual(selected.known_sword_consumed, 0)
        self.assertEqual(selected.cleared_non_sword_adjacent_to_sword, 0)
        self.assertGreaterEqual(selected.cleared_non_sword_min_sword_distance or 0, 2)

    def test_ready_setup_avoids_refill_into_top_sword_pair_while_pass_allowed(self) -> None:
        state = boss_state(hp=60_552, maximum=84_180, mana=360, rage=225)
        state = replace(
            state,
            board=board_from_names(
                REPORTED_TOP_SWORD_PAIR_SETUP_ROWS,
                multipliers=REPORTED_TOP_SWORD_PAIR_SETUP_MULTIPLIERS,
            ),
        )
        state = with_idle_status(
            state,
            GameOwnedIdleStatus.RESET_BASELINE_CONFIRMED,
            count=0,
        )

        decision = rush_policy().decide(state, pet_skill_capability=capability())

        self.assertEqual(decision.action, PolicyAction.PASS)
        self.assertEqual(decision.trace.policy_step, "SKILL_RUSH_SETUP_PASS")
        self.assertTrue(decision.trace.setup_blocked)

    def test_ready_setup_refill_pair_risk_is_soft_when_pass_is_forbidden(self) -> None:
        state = boss_state(hp=60_552, maximum=84_180, mana=360, rage=225)
        state = replace(
            state,
            board=board_from_names(
                REPORTED_TOP_SWORD_PAIR_SETUP_ROWS,
                multipliers=REPORTED_TOP_SWORD_PAIR_SETUP_MULTIPLIERS,
            ),
        )
        state = with_idle_status(
            state,
            GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION,
            count=2,
        )

        decision = rush_policy().decide(state, pet_skill_capability=capability())

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.trace.policy_step, "SKILL_RUSH_SETUP_RELAXED")
        self.assertNotEqual(decision.move.first, (3, 5))
        self.assertIsNotNone(decision.trace.selected_candidate)
        selected = decision.trace.selected_candidate
        assert selected is not None
        self.assertEqual(selected.known_sword_consumed, 0)
        self.assertEqual(selected.refill_sword_auto_match_completions, 0)

    def test_failed_b1_turn_27_fires_at_inclusive_ten_sword(self) -> None:
        state = boss_state(hp=61_690, maximum=84_180, mana=215, rage=250)
        state = replace(state, board=board_from_names(FAILED_B1_TURN_27_ROWS))

        decision = rush_policy().decide(state, pet_skill_capability=capability())

        self.assertEqual(decision.trace.known_sword_count, 10)
        self.assertIs(decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(
            decision.trace.skill_fire_trigger,
            "SKILL_RUSH_FIRE_CONDITION_READY",
        )

    def test_ready_setup_relaxes_distance_when_isolated_pool_empty(self) -> None:
        rows = [list(row) for row in FAILED_B1_TURN_27_ROWS]
        rows[1][2] = "health"
        rows[1][7] = "health"
        rows[2][0] = "health"
        state = boss_state(hp=61_690, maximum=84_180, mana=215, rage=250)
        state = replace(
            state,
            board=board_from_names(tuple(tuple(row) for row in rows)),
        )

        decision = rush_policy().decide(state, pet_skill_capability=capability())

        self.assertEqual(decision.trace.known_sword_count, 7)
        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.trace.policy_step, "SKILL_RUSH_SETUP_RELAXED")
        self.assertIsNone(decision.trace.skill_fire_trigger)
        self.assertTrue(decision.trace.setup_blocked)
        self.assertEqual(decision.trace.preferred_setup_candidate_count, 0)
        self.assertGreater(decision.trace.relaxed_setup_candidate_count, 0)
        self.assertIn(
            decision.trace.setup_fallback_type,
            {"RELAXED_DISTANCE", "BOARD_TURNOVER"},
        )
        counters = Counters()
        _record_policy_observation(
            counters,
            set(),
            state=state,
            decision=decision,
        )
        self.assertEqual(counters.skill_rush_setup_blocked_fires, 0)
        self.assertEqual(counters.skill_rush_setup_blocked_states, 1)
        self.assertEqual(counters.skill_rush_setup_relaxed_actions, 1)
        self.assertEqual(counters.skill_rush_premature_blocked_skills, 0)
        self.assertTrue(
            any(
                "SKILL_RUSH_SETUP_BLOCKED" in item
                for item in decision.trace.failed_higher_priority_branches
            )
        )

    def test_exact_phase3d1_82_percent_four_sword_case_relaxes_instead_of_firing(self) -> None:
        state = boss_state(
            hp=69_276,
            maximum=84_180,
            mana=270,
            rage=250,
        )
        state = replace(state, board=board_from_names(PHASE3D1_SETUP_BLOCKED_ROWS))

        decision = rush_policy().decide(state, pet_skill_capability=capability())

        self.assertEqual(decision.trace.known_sword_count, 4)
        self.assertFalse(decision.trace.sword_threshold_ready)
        self.assertEqual(decision.trace.configured_sword_threshold, 10)
        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.move.first, (3, 3))
        self.assertEqual(decision.move.second, (3, 4))
        self.assertEqual(decision.trace.policy_step, "SKILL_RUSH_SETUP_RELAXED")
        self.assertTrue(decision.trace.setup_blocked)
        self.assertEqual(decision.trace.preferred_setup_candidate_count, 0)
        self.assertEqual(decision.trace.relaxed_setup_candidate_count, 1)
        self.assertEqual(decision.trace.minimum_available_sword_distance, 1)
        self.assertEqual(decision.trace.sword_consumed_by_relaxed_move, 0)
        self.assertEqual(decision.trace.setup_fallback_type, "RELAXED_DISTANCE")
        self.assertIsNone(decision.trace.skill_fire_trigger)

    def test_setup_never_consumes_sword_even_below_one_hundred_rage(self) -> None:
        state = boss_state(hp=82_000, maximum=100_000, rage=99)
        base = evaluate_all_moves(state.board)[0]
        prep_sword = candidate(base, sword=3)
        metrics = (3, 1, 0, 0, (), (), None, 0, 0)
        with (
            patch(
                "pokiguard_v2.basic_policy.evaluate_all_moves",
                return_value=(prep_sword,),
            ),
            patch(
                "pokiguard_v2.basic_policy._skill_rush_board_metrics",
                return_value=metrics,
            ),
        ):
            decision = rush_policy(threshold=256).decide(
                state,
                pet_skill_capability=capability(rage_cost=99),
            )

        self.assertEqual(decision.action, PolicyAction.NONE)
        self.assertEqual(
            decision.trace.policy_step,
            "SKILL_RUSH_SWORD_PRESERVATION_BLOCKED",
        )
        self.assertEqual(
            decision.trace.blocker,
            "SKILL_RUSH_ONLY_SETUP_CONSUMING_MOVES",
        )
        self.assertIsNone(decision.trace.skill_fire_trigger)

    def test_setup_passes_instead_of_consuming_sword_at_any_rage(self) -> None:
        state = boss_state(hp=82_000, maximum=100_000, rage=99)
        state = with_idle_status(
            state,
            GameOwnedIdleStatus.PASS_ALLOWED,
            count=1,
        )
        bases = evaluate_all_moves(state.board)[:2]
        first = candidate(bases[0])
        second = candidate(bases[1])
        by_move = {
            first.move: (2, 2, 0, 0, (), (), None, 0, 0),
            second.move: (1, 3, 0, 0, (), (), None, 0, 0),
        }

        def metrics(_board, value):
            return by_move[value.move]

        with (
            patch(
                "pokiguard_v2.basic_policy.evaluate_all_moves",
                return_value=(first, second),
            ),
            patch(
                "pokiguard_v2.basic_policy._skill_rush_board_metrics",
                side_effect=metrics,
            ),
        ):
            decision = rush_policy(threshold=256).decide(
                state,
                pet_skill_capability=capability(rage_cost=99),
            )

        self.assertEqual(decision.action, PolicyAction.PASS)
        self.assertEqual(decision.trace.policy_step, "SKILL_RUSH_SETUP_PASS")
        self.assertIsNone(decision.move)

    def test_setup_blocked_uses_deterministic_board_turnover(self) -> None:
        state = boss_state(hp=82_000, maximum=100_000)
        bases = evaluate_all_moves(state.board)[:2]
        first = candidate(bases[0])
        second = candidate(bases[1])
        metrics = (0, 4, 0, 0, (), (), None, 0, 0)
        with (
            patch(
                "pokiguard_v2.basic_policy.evaluate_all_moves",
                return_value=(second, first),
            ),
            patch(
                "pokiguard_v2.basic_policy._skill_rush_board_metrics",
                return_value=metrics,
            ),
        ):
            decision = rush_policy(threshold=256).decide(
                state,
                pet_skill_capability=capability(),
            )
        with (
            patch(
                "pokiguard_v2.basic_policy.evaluate_all_moves",
                return_value=(first, second),
            ),
            patch(
                "pokiguard_v2.basic_policy._skill_rush_board_metrics",
                return_value=metrics,
            ),
        ):
            repeated = rush_policy(threshold=256).decide(
                state,
                pet_skill_capability=capability(),
            )

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.move, repeated.move)
        self.assertEqual(decision.trace.setup_fallback_type, "BOARD_TURNOVER")
        self.assertIsNone(decision.trace.skill_fire_trigger)

    def test_only_threshold_fire_condition_wins_without_setup_block_authorization(self) -> None:
        low_hp_not_ready = replace(
            boss_state(hp=45_000, maximum=100_000),
            board=board_from_names(PHASE3D1_SETUP_BLOCKED_ROWS),
        )
        threshold_ready = replace(
            boss_state(hp=80_000, maximum=100_000),
            board=board_with_swords(boss_state(hp=80_000, maximum=100_000), 10),
        )

        low_hp_decision = rush_policy().decide(
            low_hp_not_ready,
            pet_skill_capability=capability(),
        )
        threshold_decision = rush_policy().decide(
            threshold_ready,
            pet_skill_capability=capability(),
        )

        self.assertIsNot(low_hp_decision.action, PolicyAction.PET_SKILL)
        self.assertIsNone(low_hp_decision.trace.skill_fire_trigger)
        self.assertEqual(threshold_decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(
            threshold_decision.trace.skill_fire_trigger,
            "SKILL_RUSH_FIRE_CONDITION_READY",
        )
        self.assertFalse(threshold_decision.trace.setup_blocked)

    def test_missing_resource_dominates_high_sword_and_low_hp(self) -> None:
        state = boss_state(
            hp=45_000,
            maximum=100_000,
            mana=200,
            rage=100,
        )
        state = replace(state, board=board_with_swords(state, 12))
        bases = evaluate_all_moves(session_state(mana=0, rage=0).board)[:2]
        sword = candidate(bases[0], sword=3)
        rage = candidate(bases[1], rage=20)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(sword, rage),
        ):
            decision = rush_policy().decide(
                state,
                pet_skill_capability=capability(),
            )
        self.assertEqual(decision.trace.policy_step, "SKILL_RUSH_RESOURCE_PROGRESS")
        self.assertEqual(decision.move, rage.move)
        self.assertIsNone(decision.trace.skill_fire_trigger)

    def test_live_mode_b_healthy_resource_stage_accepts_non_sword_risk(self) -> None:
        state = boss_state(hp=84_180, maximum=84_180, mana=0, rage=0)
        state = replace(state, board=board_from_names(FAILED_MODE_B_TURN_1_ROWS))

        decision = rush_policy().decide(
            state,
            pet_skill_capability=capability(),
        )

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertFalse(decision.trace.selected_candidate.safe)
        self.assertEqual(decision.trace.selected_candidate.known_sword_consumed, 0)
        self.assertEqual(
            decision.trace.policy_step,
            "SKILL_RUSH_RESOURCE_RISK_ACCEPTED",
        )

    def test_live_mode_b_setup_never_spends_sword_at_tactical_rage(self) -> None:
        state = boss_state(hp=70_000, maximum=84_180, mana=270, rage=250)
        state = replace(state, board=board_from_names(FAILED_MODE_B_TURN_13_ROWS))

        decision = rush_policy().decide(
            state,
            pet_skill_capability=capability(),
        )

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.trace.selected_candidate.known_sword_consumed, 0)
        self.assertEqual(
            decision.trace.setup_fallback_type,
            "MANDATORY_FALLBACK",
        )

    def test_smoke_turn_13_equal_threshold_fires_immediately(self) -> None:
        state = boss_state(hp=46_355, maximum=84_180, mana=270, rage=250)
        state = replace(
            state,
            board=board_from_names(
                SMOKE_MODE_B_TURN_13_ROWS,
                multipliers=SMOKE_MODE_B_TURN_13_MULTIPLIERS,
            ),
        )

        decision = rush_policy(threshold=10).decide(
            state,
            pet_skill_capability=capability(),
        )

        self.assertEqual(decision.trace.known_sword_count, 10)
        self.assertTrue(decision.trace.selected_fire_condition_ready)
        self.assertEqual(decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(
            decision.trace.skill_fire_trigger,
            "SKILL_RUSH_FIRE_CONDITION_READY",
        )

    def test_smoke_turn_13_no_safe_setup_passes_instead_of_spending_sword(self) -> None:
        state = boss_state(hp=46_355, maximum=84_180, mana=270, rage=250)
        state = replace(
            state,
            board=board_from_names(
                SMOKE_MODE_B_TURN_13_ROWS,
                multipliers=SMOKE_MODE_B_TURN_13_MULTIPLIERS,
            ),
        )
        state = with_idle_status(
            state,
            GameOwnedIdleStatus.RESET_BASELINE_CONFIRMED,
            count=0,
        )

        decision = rush_policy(threshold=13).decide(
            state,
            pet_skill_capability=capability(),
        )

        self.assertEqual(decision.action, PolicyAction.PASS)
        self.assertEqual(decision.trace.policy_step, "SKILL_RUSH_SETUP_PASS")
        self.assertIsNone(decision.trace.selected_candidate)
        self.assertTrue(decision.trace.setup_blocked)

    def test_smoke_turn_13_resource_branch_never_self_consumes_sword(self) -> None:
        state = boss_state(hp=46_355, maximum=84_180, mana=0, rage=0)
        state = replace(
            state,
            board=board_from_names(
                SMOKE_MODE_B_TURN_13_ROWS,
                multipliers=SMOKE_MODE_B_TURN_13_MULTIPLIERS,
            ),
        )

        decision = rush_policy(threshold=10).decide(
            state,
            pet_skill_capability=capability(),
        )

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(
            decision.trace.policy_step,
            "SKILL_RUSH_RESOURCE_RISK_ACCEPTED",
        )
        selected = decision.trace.selected_candidate
        assert selected is not None
        self.assertEqual(selected.known_sword_consumed, 0)

    def test_safe_mana_rage_progress_precedes_drain_and_shield(self) -> None:
        state = boss_state(hp=75_000, maximum=100_000, mana=0, rage=0)
        state = replace(state, board=board_with_swords(state, 0))
        bases = evaluate_all_moves(state.board)[:3]
        mana = candidate(bases[0], mana=3)
        drain = candidate(bases[1], drain=5)
        shield = candidate(bases[2], shield=5)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(shield, drain, mana),
        ):
            decision = rush_policy().decide(
                state,
                pet_skill_capability=capability(),
            )

        self.assertEqual(decision.trace.policy_step, "SKILL_RUSH_RESOURCE_PROGRESS")
        self.assertEqual(decision.move, mana.move)

    def test_healthy_unsafe_resource_progress_precedes_safe_drain_and_shield(self) -> None:
        state = boss_state(hp=75_000, maximum=100_000, mana=0, rage=0)
        state = replace(state, board=board_with_swords(state, 0))
        bases = evaluate_all_moves(state.board)[:3]
        unsafe_mana = candidate(bases[0], mana=6, direct_replies=1)
        drain = candidate(bases[1], drain=3)
        shield = candidate(bases[2], shield=5)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(unsafe_mana, shield, drain),
        ):
            decision = rush_policy().decide(
                state,
                pet_skill_capability=capability(),
            )

        self.assertEqual(
            decision.trace.policy_step,
            "SKILL_RUSH_RESOURCE_RISK_ACCEPTED",
        )
        self.assertEqual(decision.move, unsafe_mana.move)
        self.assertFalse(decision.trace.selected_candidate.safe)

    def test_latest_live_healthy_player_takes_mana_before_safe_shield(self) -> None:
        state = boss_state(
            hp=75_000,
            maximum=100_000,
            mana=90,
            rage=250,
        )
        state = replace(
            state,
            board=board_from_names(
                HEALTHY_RESOURCE_PRIORITY_TURN_15_ROWS,
                multipliers=HEALTHY_RESOURCE_PRIORITY_TURN_15_MULTIPLIERS,
            ),
        )

        decision = rush_policy().decide(
            state,
            pet_skill_capability=capability(),
        )

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(
            decision.trace.policy_step,
            "SKILL_RUSH_RESOURCE_RISK_ACCEPTED",
        )
        self.assertEqual(decision.move.first, (0, 4))
        self.assertEqual(decision.move.second, (0, 5))
        selected = decision.trace.selected_candidate
        assert selected is not None
        self.assertGreater(selected.known_mana_gain, 0)
        self.assertEqual(selected.known_sword_consumed, 0)
        self.assertFalse(selected.safe)

    def test_low_hp_safe_shield_precedes_unsafe_resource_progress(self) -> None:
        state = boss_state(hp=75_000, maximum=100_000, mana=0, rage=0)
        state = with_player_hp(state, hp=20)
        state = replace(state, board=board_with_swords(state, 0))
        bases = evaluate_all_moves(state.board)[:2]
        unsafe_mana = candidate(bases[0], mana=6, direct_replies=1)
        safe_shield = candidate(bases[1], shield=5)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(unsafe_mana, safe_shield),
        ):
            decision = rush_policy().decide(
                state,
                pet_skill_capability=capability(),
            )

        self.assertEqual(decision.trace.policy_step, "SKILL_RUSH_LEGAL_FALLBACK")
        self.assertEqual(decision.move, safe_shield.move)
        self.assertTrue(decision.trace.selected_candidate.safe)

    def test_low_hp_prefers_shield_then_health_before_last_resort_pass(self) -> None:
        state = boss_state(hp=75_000, maximum=100_000, mana=0, rage=0)
        state = with_player_hp(state, hp=20)
        state = with_idle_status(
            state,
            GameOwnedIdleStatus.PASS_ALLOWED,
            count=1,
        )
        bases = evaluate_all_moves(state.board)[:3]
        mana = candidate(bases[0], mana=6, direct_replies=1)
        health = candidate(bases[1], direct_replies=1)
        shield = candidate(bases[2], shield=3, direct_replies=1)
        health = replace(
            health,
            direct=ResourceResult(((GemType.HEALTH, ResourceTally(3, 3)),)),
            total=ResourceResult(((GemType.HEALTH, ResourceTally(3, 3)),)),
        )
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(mana, health, shield),
        ):
            decision = rush_policy().decide(
                state,
                pet_skill_capability=capability(),
            )

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.move, shield.move)
        self.assertEqual(
            decision.trace.policy_step,
            "SKILL_RUSH_SURVIVAL_RISK_ACCEPTED",
        )
        self.assertEqual(decision.trace.selected_candidate.known_sword_consumed, 0)

    def test_low_hp_uses_pass_only_after_survival_options_are_empty(self) -> None:
        state = boss_state(hp=75_000, maximum=100_000, mana=0, rage=0)
        state = with_player_hp(state, hp=20)
        state = with_idle_status(
            state,
            GameOwnedIdleStatus.PASS_ALLOWED,
            count=1,
        )
        base = evaluate_all_moves(state.board)[0]
        mana = candidate(base, mana=6, direct_replies=1)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(mana,),
        ):
            decision = rush_policy().decide(
                state,
                pet_skill_capability=capability(),
            )

        self.assertEqual(decision.action, PolicyAction.PASS)
        self.assertEqual(decision.trace.policy_step, "SKILL_RUSH_RESOURCE_PASS")

    def test_low_hp_mandatory_turn_uses_non_sword_instead_of_third_pass(self) -> None:
        state = boss_state(hp=75_000, maximum=100_000, mana=0, rage=0)
        state = with_player_hp(state, hp=20)
        state = with_idle_status(
            state,
            GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION,
            count=2,
        )
        base = evaluate_all_moves(state.board)[0]
        mana = candidate(base, mana=6, direct_replies=1)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(mana,),
        ):
            decision = rush_policy().decide(
                state,
                pet_skill_capability=capability(),
            )

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.trace.policy_step, "SKILL_RUSH_RESOURCE_MANDATORY")
        self.assertEqual(decision.trace.selected_candidate.known_sword_consumed, 0)

    def test_ready_setup_prefers_safe_drain_then_safe_shield(self) -> None:
        state = boss_state(hp=75_000, maximum=100_000)
        state = replace(state, board=board_with_swords(state, 0))
        bases = evaluate_all_moves(state.board)[:3]
        ordinary = candidate(bases[0])
        drain = candidate(bases[1], drain=3)
        shield = candidate(bases[2], shield=5)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(ordinary, shield, drain),
        ):
            decision = rush_policy().decide(
                state,
                pet_skill_capability=capability(),
            )

        self.assertEqual(decision.move, drain.move)
        self.assertTrue(decision.trace.selected_candidate.safe)

    def test_setup_preserves_the_selected_generic_condition_gem(self) -> None:
        state = boss_state(hp=75_000, maximum=100_000)
        bases = evaluate_all_moves(state.board)[:2]
        consumes_selected_drain = candidate(bases[0], drain=3)
        preserves_selected_drain = candidate(bases[1])
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(consumes_selected_drain, preserves_selected_drain),
        ):
            decision = rush_policy(
                threshold=63,
                condition=PetSkillFireCondition.DRAIN_GEM_COUNT,
            ).decide(
                state,
                pet_skill_capability=capability(),
            )

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.move, preserves_selected_drain.move)
        self.assertEqual(
            decision.trace.selected_fire_gem_type,
            GemType.DRAIN.value,
        )
        self.assertEqual(
            decision.trace.selected_candidate.known_sword_consumed,
            0,
        )

    def test_resource_stage_never_consumes_sword_at_zero_rage(self) -> None:
        state = boss_state(hp=75_000, maximum=100_000, mana=0, rage=0)
        state = with_idle_status(
            state,
            GameOwnedIdleStatus.PASS_ALLOWED,
            count=1,
        )
        base = evaluate_all_moves(state.board)[0]
        sword = candidate(base, sword=3)
        with (
            patch(
                "pokiguard_v2.basic_policy.evaluate_all_moves",
                return_value=(sword,),
            ),
            patch(
                "pokiguard_v2.basic_policy._skill_rush_board_metrics",
                return_value=(3, 1, 0, 0, (), (), None, 0, 0),
            ),
        ):
            decision = rush_policy().decide(
                state,
                pet_skill_capability=capability(),
            )

        self.assertEqual(decision.action, PolicyAction.PASS)
        self.assertIsNone(decision.move)

    def test_only_sword_move_fails_closed_during_setup(self) -> None:
        state = boss_state(hp=75_000, maximum=100_000)
        state = replace(state, board=board_with_swords(state, 5))
        base = evaluate_all_moves(session_state(mana=0, rage=0).board)[0]
        sword = candidate(base, sword=3)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(sword,),
        ):
            decision = rush_policy().decide(
                state,
                pet_skill_capability=capability(),
            )
        self.assertEqual(decision.action, PolicyAction.NONE)
        self.assertEqual(
            decision.trace.policy_step,
            "SKILL_RUSH_SWORD_PRESERVATION_BLOCKED",
        )
        self.assertEqual(
            decision.trace.blocker,
            "SKILL_RUSH_ONLY_SETUP_CONSUMING_MOVES",
        )
        self.assertIsNone(decision.move)

    def test_resource_progress_preserves_sword_regardless_of_boss_hp(self) -> None:
        state = boss_state(hp=49_000, maximum=100_000, mana=0, rage=0)
        bases = evaluate_all_moves(state.board)[:2]
        consumes_sword = candidate(bases[0], mana=4, sword=4)
        preserves_sword = candidate(bases[1], mana=4)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(consumes_sword, preserves_sword),
        ):
            decision = rush_policy().decide(
                state,
                pet_skill_capability=capability(),
            )
        self.assertEqual(decision.move, preserves_sword.move)
        self.assertEqual(decision.trace.selected_candidate.known_sword_consumed, 0)

    def test_nonprogress_non_sword_move_beats_resource_move_that_consumes_sword(self) -> None:
        state = boss_state(hp=75_000, maximum=100_000, mana=0, rage=0)
        bases = evaluate_all_moves(state.board)[:2]
        consuming_progress = candidate(bases[0], mana=20, sword=3)
        preserving_turnover = candidate(bases[1])
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(consuming_progress, preserving_turnover),
        ):
            decision = rush_policy().decide(
                state,
                pet_skill_capability=capability(),
            )
        self.assertEqual(decision.move, preserving_turnover.move)
        self.assertEqual(decision.trace.selected_candidate.known_sword_consumed, 0)
        self.assertEqual(decision.trace.policy_step, "SKILL_RUSH_LEGAL_FALLBACK")

    def test_latest_live_turn_13_healthy_player_takes_mana_before_pass(self) -> None:
        state = boss_state(
            hp=60_000,
            maximum=84_180,
            mana=170,
            rage=235,
        )
        state = replace(
            state,
            board=board_from_names(
                LATEST_LIVE_TURN_13_ROWS,
                multipliers=LATEST_LIVE_TURN_13_MULTIPLIERS,
            ),
        )
        state = with_idle_status(
            state,
            GameOwnedIdleStatus.RESET_BASELINE_CONFIRMED,
            count=0,
        )

        decision = rush_policy().decide(
            state,
            pet_skill_capability=capability(),
        )

        self.assertEqual(decision.trace.known_sword_count, 12)
        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(
            decision.trace.policy_step,
            "SKILL_RUSH_RESOURCE_RISK_ACCEPTED",
        )
        selected = decision.trace.selected_candidate
        assert selected is not None
        self.assertEqual(selected.known_sword_consumed, 0)
        self.assertGreater(selected.known_mana_gain, 0)

    def test_latest_live_turn_13_mandatory_action_keeps_sword_and_prioritizes_mana(self) -> None:
        state = boss_state(
            hp=60_000,
            maximum=84_180,
            mana=170,
            rage=235,
        )
        state = replace(
            state,
            board=board_from_names(
                LATEST_LIVE_TURN_13_ROWS,
                multipliers=LATEST_LIVE_TURN_13_MULTIPLIERS,
            ),
        )
        state = with_idle_status(
            state,
            GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION,
            count=2,
        )

        decision = rush_policy().decide(
            state,
            pet_skill_capability=capability(),
        )

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(
            decision.trace.policy_step,
            "SKILL_RUSH_RESOURCE_RISK_ACCEPTED",
        )
        selected = decision.trace.selected_candidate
        assert selected is not None
        self.assertEqual(selected.known_sword_consumed, 0)
        self.assertGreater(selected.known_mana_gain, 0)

    def test_latest_live_turn_17_healthy_player_accepts_resource_risk_before_pass(self) -> None:
        state = boss_state(
            hp=58_000,
            maximum=84_180,
            mana=170,
            rage=165,
        )
        state = replace(
            state,
            board=board_from_names(
                LATEST_LIVE_TURN_17_ROWS,
                multipliers=LATEST_LIVE_TURN_17_MULTIPLIERS,
            ),
        )
        state = with_idle_status(
            state,
            GameOwnedIdleStatus.PASS_ALLOWED,
            count=1,
        )

        decision = rush_policy().decide(
            state,
            pet_skill_capability=capability(),
        )

        self.assertEqual(decision.trace.known_sword_count, 9)
        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(
            decision.trace.policy_step,
            "SKILL_RUSH_RESOURCE_RISK_ACCEPTED",
        )
        selected = decision.trace.selected_candidate
        assert selected is not None
        self.assertEqual(selected.known_sword_consumed, 0)
        self.assertTrue(selected.known_mana_gain > 0 or selected.known_rage_gain > 0)

    def test_latest_live_turn_17_mandatory_action_never_eats_sword(self) -> None:
        state = boss_state(
            hp=58_000,
            maximum=84_180,
            mana=170,
            rage=165,
        )
        state = replace(
            state,
            board=board_from_names(
                LATEST_LIVE_TURN_17_ROWS,
                multipliers=LATEST_LIVE_TURN_17_MULTIPLIERS,
            ),
        )
        state = with_idle_status(
            state,
            GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION,
            count=2,
        )

        decision = rush_policy().decide(
            state,
            pet_skill_capability=capability(),
        )

        self.assertEqual(decision.action, PolicyAction.SWAP)
        selected = decision.trace.selected_candidate
        assert selected is not None
        self.assertEqual(selected.known_sword_consumed, 0)
        self.assertTrue(selected.known_mana_gain > 0 or selected.known_rage_gain > 0)

    def test_post_skill_finisher_uses_thirty_percent_boss_ratio(self) -> None:
        context = SkillRushMatchContext(SESSION, 1, 5)
        cases = (
            (25_000, 200_000, True, "RELATIVE_HP"),
            (75_000, 250_000, True, "RELATIVE_HP"),
            (76_000, 250_000, False, "NONE"),
        )
        for hp, maximum, ready, trigger in cases:
            with self.subTest(hp=hp, maximum=maximum):
                state = boss_state(
                    hp=hp,
                    maximum=maximum,
                    mana=0 if not ready else 200,
                    rage=0 if not ready else 200,
                )
                decision = rush_policy().decide(
                    state,
                    pet_skill_capability=capability(),
                    skill_rush_match_context=context,
                )
                self.assertEqual(decision.trace.post_skill_finisher_ready, ready)
                self.assertEqual(decision.trace.finisher_trigger, trigger)
                if ready:
                    self.assertEqual(decision.action, PolicyAction.CAST)
                    self.assertEqual(
                        decision.trace.policy_step,
                        "SKILL_RUSH_POST_SKILL_FINISHER_ATTACK",
                    )
                else:
                    self.assertIsNot(decision.action, PolicyAction.CAST)

    def test_post_skill_finisher_boundary_is_inclusive(self) -> None:
        context = SkillRushMatchContext(SESSION, 1, 5)
        for hp, maximum, ready in (
            (30_000, 100_000, True),
            (30_001, 100_000, False),
        ):
            with self.subTest(hp=hp, maximum=maximum):
                state = boss_state(
                    hp=hp,
                    maximum=maximum,
                    mana=200 if ready else 0,
                    rage=200 if ready else 0,
                )
                decision = rush_policy().decide(
                    state,
                    pet_skill_capability=capability(),
                    skill_rush_match_context=context,
                )
                self.assertEqual(decision.trace.post_skill_finisher_ready, ready)
                self.assertEqual(
                    decision.trace.finisher_trigger,
                    "RELATIVE_HP" if ready else "NONE",
                )

    def test_sword_sparse_turnover_breaks_equivalent_setup_tie(self) -> None:
        state = boss_state(hp=75_000, maximum=100_000)
        setup_board = BoardState(
            tuple(
                tuple(
                    CellState(
                        row,
                        col,
                        (
                            GemType.SWORD
                            if (row, col) == (0, 7)
                            else GemType.HEALTH
                            if cell.gem is GemType.SWORD
                            else cell.gem
                        ),
                        cell.multiplier,
                    )
                    for col, cell in enumerate(values)
                )
                for row, values in enumerate(state.board.cells)
            )
        )
        state = replace(state, board=setup_board)
        bases = evaluate_all_moves(setup_board)[:2]
        common = dict(
            direct=ResourceResult(),
            cascade=ResourceResult(),
            total=ResourceResult(),
            result=bases[0].result,
            calculable=True,
            cascade_rounds=0,
            unknown_exposure=bases[0].unknown_exposure,
            sword_risk=bases[0].sword_risk,
        )
        dense = replace(
            bases[0],
            clear_rounds=(((0, 2), (0, 3), (0, 4)),),
            **common,
        )
        sparse = replace(
            bases[1],
            clear_rounds=(((3, 0), (3, 1), (3, 2)),),
            **common,
        )
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(dense, sparse),
        ):
            decision = rush_policy().decide(
                state,
                pet_skill_capability=capability(),
            )
        self.assertEqual(decision.trace.policy_step, "SKILL_RUSH_BOARD_SETUP")
        self.assertEqual(decision.move, sparse.move)
        self.assertGreater(
            decision.trace.selected_candidate.cleared_non_sword_zero_sword_axes,
            0,
        )

    def test_low_boss_without_current_match_skill_does_not_unlock_attack(self) -> None:
        state = boss_state(
            hp=20_000,
            maximum=200_000,
            mana=0,
            rage=0,
        )
        decision = rush_policy().decide(state, pet_skill_capability=capability())
        self.assertFalse(decision.trace.post_skill_finisher_ready)
        self.assertIsNot(decision.action, PolicyAction.CAST)

    def test_same_source_turn_after_perfect_is_fully_closed(self) -> None:
        state = boss_state(hp=20_000, maximum=200_000)
        context = SkillRushMatchContext(SESSION, 1, 7)
        decision = rush_policy().decide(
            state,
            pet_skill_capability=capability(),
            skill_rush_match_context=context,
        )
        self.assertEqual(decision.action, PolicyAction.NONE)
        self.assertEqual(decision.trace.blocker, "PET_SKILL_SOURCE_TURN_UNRESOLVED")

    def test_later_local_turn_attack_and_sword_finishers(self) -> None:
        context = SkillRushMatchContext(SESSION, 1, 5)
        state = boss_state(hp=25_000, maximum=200_000)
        attack = rush_policy().decide(
            state,
            pet_skill_capability=capability(),
            skill_rush_match_context=context,
        )
        self.assertEqual(attack.action, PolicyAction.CAST)

        no_attack = replace(state, cards=())
        sword = candidate(evaluate_all_moves(no_attack.board)[0], sword=3)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(sword,),
        ):
            sword_decision = rush_policy().decide(
                no_attack,
                pet_skill_capability=capability(),
                skill_rush_match_context=context,
            )
        self.assertEqual(sword_decision.action, PolicyAction.SWAP)
        self.assertEqual(
            sword_decision.trace.policy_step,
            "SKILL_RUSH_POST_SKILL_FINISHER_SWORD",
        )

    def test_second_pet_skill_remains_possible_above_finisher_threshold(self) -> None:
        state = boss_state(hp=62_000, maximum=200_000)
        state = replace(state, board=board_with_swords(state, 11))
        decision = rush_policy().decide(
            state,
            pet_skill_capability=capability(),
            skill_rush_match_context=SkillRushMatchContext(SESSION, 1, 5),
        )
        self.assertEqual(decision.action, PolicyAction.PET_SKILL)
        self.assertFalse(decision.trace.post_skill_finisher_ready)
        self.assertEqual(decision.trace.finisher_action, "SECOND_PET_SKILL")

    def test_second_pet_skill_uses_the_same_inclusive_threshold(self) -> None:
        state = boss_state(hp=62_000, maximum=200_000)
        state = replace(state, board=board_with_swords(state, 10))
        decision = rush_policy().decide(
            state,
            pet_skill_capability=capability(),
            skill_rush_match_context=SkillRushMatchContext(SESSION, 1, 5),
        )
        self.assertIs(decision.action, PolicyAction.PET_SKILL)
        self.assertTrue(decision.trace.sword_threshold_ready)

    def test_stale_previous_match_success_cannot_unlock_finisher(self) -> None:
        state = boss_state(hp=20_000, maximum=200_000, mana=0, rage=0)
        previous = CombatSessionKey(6, 0x20000000001, "PREVIOUS_MATCH")
        decision = rush_policy().decide(
            state,
            pet_skill_capability=capability(),
            skill_rush_match_context=SkillRushMatchContext(previous, 1, 5),
        )
        self.assertEqual(decision.trace.pet_skill_success_count_current_match, 0)
        self.assertFalse(decision.trace.post_skill_finisher_ready)
        self.assertIsNot(decision.action, PolicyAction.CAST)

    def test_match_context_does_not_change_default_playstyle(self) -> None:
        state = boss_state(hp=20_000, maximum=200_000)
        standard = BasicPolicyEngine()
        baseline = standard.decide(state)
        with_history = standard.decide(
            state,
            skill_rush_match_context=SkillRushMatchContext(SESSION, 1, 5),
        )
        self.assertEqual(with_history.action, baseline.action)
        self.assertEqual(with_history.move, baseline.move)
        self.assertEqual(with_history.trace.policy_step, baseline.trace.policy_step)
        self.assertEqual(with_history.trace.pet_skill_success_count_current_match, 0)

    def test_threshold_has_zero_effect_on_default_profile(self) -> None:
        state = session_state(mana=600, rage=200)
        decisions = tuple(
            BasicPolicyEngine(
                PolicyConfig(pet_skill_fire_value=threshold)
            ).decide(state)
            for threshold in (0, 10, 256)
        )
        baseline = decisions[0]
        for decision in decisions[1:]:
            self.assertEqual(decision.action, baseline.action)
            self.assertEqual(decision.move, baseline.move)
            self.assertEqual(decision.trace.policy_step, baseline.trace.policy_step)

    def test_runtime_context_projection_is_exact_session_scoped(self) -> None:
        state = session_state(mana=200, rage=200)
        previous = CombatSessionKey(6, 0x20000000001, "PREVIOUS_MATCH")
        history = {previous: [5], SESSION: [7, 11]}
        context = _current_skill_rush_match_context(state, history)
        self.assertEqual(context, SkillRushMatchContext(SESSION, 2, 11))

        new_session = CombatSessionKey(8, 0x20000000002, "NEXT_MATCH")
        next_state = replace(
            state,
            battle=replace(
                state.battle,
                session_key=new_session,
                match_id=new_session.match_id,
                board_instance=new_session.board_instance,
            ),
        )
        self.assertEqual(
            _current_skill_rush_match_context(next_state, history),
            SkillRushMatchContext(new_session, 0, None),
        )

    def test_no_progress_uses_legal_fallback_instead_of_inventing_progress(self) -> None:
        state = session_state(mana=0, rage=0)
        bases = evaluate_all_moves(state.board)[:2]
        known = candidate(bases[0], sword=3)
        unknown = candidate(bases[1], calculable=False)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(unknown, known),
        ):
            decision = rush_policy().decide(state, pet_skill_capability=capability())
        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.trace.policy_step, "SKILL_RUSH_LEGAL_FALLBACK")
        self.assertEqual(decision.move, unknown.move)

    def test_telemetry_records_healthy_non_sword_risk_acceptance(self) -> None:
        state = session_state(mana=0, rage=0)
        bases = evaluate_all_moves(state.board)[:2]
        sword = candidate(bases[0], sword=8)
        progress = candidate(
            bases[1],
            mana=4,
            direct_replies=1,
            indirect_replies=1,
        )
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(sword, progress),
        ):
            decision = rush_policy().decide(state, pet_skill_capability=capability())
        counters = Counters()
        branch = _record_policy_observation(
            counters,
            set(),
            state=state,
            decision=decision,
        )
        self.assertEqual(branch, "SKILL_RUSH_RESOURCE_RISK_ACCEPTED")
        self.assertEqual(counters.skipped_current_sword_for_resource, 0)
        self.assertEqual(counters.selected_move_left_direct_boss_sword, 1)
        self.assertEqual(counters.selected_move_left_indirect_boss_sword, 1)
        self.assertEqual(counters.wrong_turn_inputs, 0)

    def test_farmrunner_passes_immutable_skill_rush_value_to_combat(self) -> None:
        play_style_action = next(
            action
            for action in build_farm_parser()._actions
            if action.dest == "play_style"
        )
        self.assertIn("skill_rush", play_style_action.choices)
        args = SimpleNamespace(
            play_style="skill_rush",
            main_pet="legendary",
            evolution_target="none",
            damage_card="pet_skill",
            audition_mode="audition_v3",
            board_input_mode="two_click",
            mana_priority=None,
            interval=0.12,
            max_total_input_actions=100,
            combat_timeout=1800.0,
            return_lobby_timeout=30.0,
            no_beep=True,
            max_region_mib=8,
            ack_heap_region_mib=16,
            chunk_mib=2,
            reset_evidence=Path("reset.json"),
            pass_acceptance_stage=None,
            cast_when_boss_hp_below=30_000,
            cast_mana_stockpile=480,
            rage_target=100,
            pet_skill_fire_value=17,
        )
        combat = _combat_args(args, Path("combat.jsonl"))
        self.assertEqual(combat.play_style, "skill_rush")
        self.assertEqual(combat.main_pet, "legendary")
        self.assertEqual(combat.evolution_target, "none")
        self.assertEqual(combat.damage_card, "pet_skill")
        self.assertEqual(combat.pet_skill_fire_value, 17)
        self.assertEqual(combat.pass_acceptance_stage, "B3")


if __name__ == "__main__":
    unittest.main()
