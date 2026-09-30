from __future__ import annotations

from dataclasses import replace
from pathlib import Path
from types import SimpleNamespace
import unittest

from pokiguard_v2.basic_policy import (
    BasicPolicyEngine,
    PlayStyle,
    PolicyAction,
    PolicyConfig,
)
from pokiguard_v2.board_simulator import SwapMove, simulate_move
from pokiguard_v2.demon_aegis import evaluate_demon_aegis_move
from pokiguard_v2.gameplay_profile import (
    DamageCardMode,
    EvolutionTarget,
    MainPetType,
    PetSkillFireCondition,
)
from pokiguard_v2.pet_configuration import GameplayConfig
from pokiguard_v2.state import BoardState, CellState, GemType
from tests.test_basic_policy import combat_state
from tools.farm_cycle import _combat_args
from tools.farm_run import build_parser as build_farm_parser


TARGET_MOVE = SwapMove((5, 3), (6, 3))
VERTICAL_TARGET_MOVE = SwapMove((3, 5), (3, 6))


def passive_board() -> BoardState:
    """Stable board with one horizontal Shield trigger and three blast Swords."""

    fillers = (GemType.MANA, GemType.RAGE, GemType.HEALTH, GemType.DRAIN)
    values = [
        [fillers[(row * 2 + col) % len(fillers)] for col in range(8)]
        for row in range(8)
    ]
    multipliers = [[1 for _col in range(8)] for _row in range(8)]
    values[6][1] = GemType.SHIELD
    values[6][2] = GemType.SHIELD
    values[6][3] = GemType.MANA
    values[5][3] = GemType.SHIELD
    for multiplier, (row, col) in enumerate(((0, 1), (1, 2), (2, 3)), 1):
        values[row][col] = GemType.SWORD
        multipliers[row][col] = multiplier
    return BoardState(
        tuple(
            tuple(
                CellState(row, col, values[row][col], multipliers[row][col])
                for col in range(8)
            )
            for row in range(8)
        )
    )


def vertical_passive_board() -> BoardState:
    fillers = (GemType.MANA, GemType.RAGE, GemType.HEALTH, GemType.DRAIN)
    values = [
        [fillers[(row * 2 + col) % len(fillers)] for col in range(8)]
        for row in range(8)
    ]
    values[1][6] = GemType.SHIELD
    values[2][6] = GemType.SHIELD
    values[3][6] = GemType.MANA
    values[3][5] = GemType.SHIELD
    for row, col in ((1, 0), (2, 2), (3, 7)):
        values[row][col] = GemType.SWORD
    return BoardState(
        tuple(
            tuple(CellState(row, col, values[row][col], 1) for col in range(8))
            for row in range(8)
        )
    )


def demon_policy(*, threshold: int = 3) -> BasicPolicyEngine:
    return BasicPolicyEngine(
        PolicyConfig(
            play_style=PlayStyle.DEMON_AEGIS_FARM,
            mana_priority=None,
            main_pet=MainPetType.NORMAL,
            evolution=EvolutionTarget.NONE,
            damage_card=DamageCardMode.PET_PASSIVE,
            pet_skill_fire_condition=PetSkillFireCondition.SWORD_COUNT,
            pet_skill_fire_value=threshold,
        )
    )


class DemonAegisFarmTests(unittest.TestCase):
    def test_horizontal_shield_match_clears_three_full_columns(self) -> None:
        board = passive_board()
        value = simulate_move(board, TARGET_MOVE)
        self.assertIsNotNone(value)
        passive = evaluate_demon_aegis_move(
            board,
            value,
            include_next_turn=False,
        )

        self.assertEqual(
            passive.shield_match_cells,
            ((6, 1), (6, 2), (6, 3)),
        )
        self.assertEqual(len(passive.blast_cells), 24)
        self.assertEqual({col for _row, col in passive.blast_cells}, {1, 2, 3})
        self.assertEqual(passive.sword_cells, 3)
        self.assertEqual(passive.sword_effective, 6)

    def test_policy_fires_passive_at_inclusive_three_sword_threshold(self) -> None:
        board = passive_board()
        decision = demon_policy().decide(combat_state(board=board))

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.move, TARGET_MOVE)
        self.assertEqual(decision.trace.policy_step, "DEMON_AEGIS_PASSIVE_FIRE")
        self.assertIn("blastSwordCells=3 >= 3", decision.trace.why_selected)

    def test_vertical_shield_match_clears_three_full_rows(self) -> None:
        board = vertical_passive_board()
        value = simulate_move(board, VERTICAL_TARGET_MOVE)
        self.assertIsNotNone(value)
        passive = evaluate_demon_aegis_move(
            board,
            value,
            include_next_turn=False,
        )

        self.assertEqual(
            passive.shield_match_cells,
            ((1, 6), (2, 6), (3, 6)),
        )
        self.assertEqual(len(passive.blast_cells), 24)
        self.assertEqual({row for row, _col in passive.blast_cells}, {1, 2, 3})
        self.assertEqual(passive.sword_cells, 3)

    def test_policy_never_selects_an_ordinary_sword_match(self) -> None:
        board = passive_board()
        decision = demon_policy(threshold=4).decide(combat_state(board=board))

        self.assertEqual(decision.action, PolicyAction.SWAP)
        selected = next(
            value
            for value in (simulate_move(board, decision.move),)
            if value is not None
        )
        self.assertEqual(selected.total.cells(GemType.SWORD), 0)
        self.assertNotEqual(decision.trace.policy_step, "DEMON_AEGIS_PASSIVE_FIRE")

    def test_profile_is_fixed_to_regular_pet_none_and_passive(self) -> None:
        accepted = GameplayConfig(
            play_style=PlayStyle.DEMON_AEGIS_FARM,
            main_pet=MainPetType.NORMAL,
            evolution=EvolutionTarget.NONE,
            damage_card=DamageCardMode.PET_PASSIVE,
            pet_skill_fire_condition=PetSkillFireCondition.SWORD_COUNT,
            pet_skill_fire_value=3,
        )
        self.assertTrue(accepted.farm_policy_supported)

        for changes in (
            {"main_pet": MainPetType.LEGENDARY},
            {"evolution": EvolutionTarget.NORMAL},
            {"damage_card": DamageCardMode.DEFAULT_ATTACK},
            {"pet_skill_fire_condition": PetSkillFireCondition.SHIELD_GEM_COUNT},
        ):
            with self.subTest(changes=changes):
                try:
                    invalid = replace(accepted, **changes)
                except ValueError:
                    continue
                self.assertEqual(
                    invalid.farm_policy_blocker_reason,
                    "DEMON_AEGIS_PROFILE_NOT_IMPLEMENTED",
                )

    def test_pet_passive_is_rejected_outside_demon_aegis_style(self) -> None:
        config = GameplayConfig(
            play_style=PlayStyle.SIMPLE,
            main_pet=MainPetType.NORMAL,
            evolution=EvolutionTarget.NONE,
            damage_card=DamageCardMode.PET_PASSIVE,
        )
        self.assertEqual(
            config.farm_policy_blocker_reason,
            "PET_PASSIVE_REQUIRES_DEMON_AEGIS_FARM",
        )

    def test_farmrunner_passes_demon_profile_to_combat_without_qte_card_mode(self) -> None:
        play_style_action = next(
            action
            for action in build_farm_parser()._actions
            if action.dest == "play_style"
        )
        self.assertIn(PlayStyle.DEMON_AEGIS_FARM.value, play_style_action.choices)
        args = SimpleNamespace(
            play_style=PlayStyle.DEMON_AEGIS_FARM.value,
            main_pet=MainPetType.NORMAL.value,
            evolution_target=EvolutionTarget.NONE.value,
            damage_card=DamageCardMode.PET_PASSIVE.value,
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
            pet_skill_fire_condition=PetSkillFireCondition.SWORD_COUNT.value,
            pet_skill_fire_value=3,
        )

        combat = _combat_args(args, Path("combat.jsonl"))
        self.assertEqual(combat.play_style, PlayStyle.DEMON_AEGIS_FARM.value)
        self.assertEqual(combat.main_pet, MainPetType.NORMAL.value)
        self.assertEqual(combat.evolution_target, EvolutionTarget.NONE.value)
        self.assertEqual(combat.damage_card, DamageCardMode.PET_PASSIVE.value)
        self.assertEqual(combat.pet_skill_fire_value, 3)
        self.assertEqual(combat.pass_acceptance_stage, "B3")


if __name__ == "__main__":
    unittest.main()
