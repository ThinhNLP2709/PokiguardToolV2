from __future__ import annotations

from dataclasses import replace
import unittest

from pokiguard_v2.basic_policy import (
    BasicPolicyEngine,
    PlayStyle,
    PolicyAction,
    PolicyConfig,
)
from pokiguard_v2.board_simulator import evaluate_all_moves
from pokiguard_v2.gameplay_profile import (
    AuditionMode,
    DamageCardMode,
    EvolutionTarget,
    GameMode,
    MainPetType,
    PetSkillFireCondition,
)
from pokiguard_v2.pet_configuration import (
    GameplayConfig,
    basic_policy_config,
    requires_attack_card_preparation,
)
from pokiguard_v2.win32_input import BoardInputMode
from tests.test_basic_policy import combat_state
from tests.test_board_simulator import fixture_board
from tools.basic_auto_bot import _bu_win_waits_for_teammates
from tools.boss_entry import SharedEntryRuntime


def bu_win_config() -> GameplayConfig:
    return GameplayConfig(
        play_style=PlayStyle.BU_WIN,
        game_mode=GameMode.COOP,
        main_pet=MainPetType.NORMAL,
        evolution=EvolutionTarget.NONE,
        damage_card=DamageCardMode.NONE,
        audition_mode=AuditionMode.NO_ACTION,
        pet_skill_fire_condition=PetSkillFireCondition.SKILL_COST_READY,
        pet_skill_fire_value=None,
    )


class BuWinTests(unittest.TestCase):
    def test_board_input_defaults_to_two_click(self) -> None:
        self.assertIs(GameplayConfig().board_input_mode, BoardInputMode.TWO_CLICK)

    def test_profile_is_fixed_to_coop_regular_pet_without_cards(self) -> None:
        config = bu_win_config()

        self.assertTrue(config.farm_policy_supported)
        self.assertFalse(requires_attack_card_preparation(config))
        policy = basic_policy_config(config)
        self.assertTrue(policy.bu_win_profile)

        with self.assertRaisesRegex(ValueError, "BU_WIN_REQUIRES_COOP"):
            replace(config, game_mode=GameMode.SOLO)
        with self.assertRaisesRegex(ValueError, "BU_WIN_LOADOUT_INVALID"):
            replace(config, evolution=EvolutionTarget.NORMAL)
        with self.assertRaisesRegex(ValueError, "BU_WIN_LOADOUT_INVALID"):
            replace(config, damage_card=DamageCardMode.DEFAULT_ATTACK)

    def test_other_play_styles_reject_coop_and_no_damage_card(self) -> None:
        with self.assertRaisesRegex(ValueError, "COOP_REQUIRES_BU_WIN"):
            GameplayConfig(game_mode=GameMode.COOP)
        with self.assertRaisesRegex(ValueError, "FARM_PROFILE_NOT_IMPLEMENTED"):
            GameplayConfig(damage_card=DamageCardMode.NONE)

    def test_policy_always_selects_a_proven_legal_swap(self) -> None:
        board = fixture_board()
        engine = BasicPolicyEngine(
            PolicyConfig(
                play_style=PlayStyle.BU_WIN,
                mana_priority=None,
                main_pet=MainPetType.NORMAL,
                evolution=EvolutionTarget.NONE,
                damage_card=DamageCardMode.NONE,
                pet_skill_fire_condition=(
                    PetSkillFireCondition.SKILL_COST_READY
                ),
                pet_skill_fire_value=None,
            )
        )
        evaluations = evaluate_all_moves(board)

        decision = engine.decide(combat_state(board=board))

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.trace.policy_step, "BU_WIN_FEED_BOSS")
        self.assertEqual(
            decision.move,
            min(
                evaluations,
                key=lambda value: engine._bu_win_rank(value, board),
            ).move,
        )
        self.assertIn(decision.move, tuple(value.move for value in evaluations))
        self.assertEqual(decision.trace.candidate_count, len(evaluations))

    def test_dead_local_pet_waits_for_teammates_only_in_bu_win(self) -> None:
        alive = combat_state()
        dead = replace(alive, player=replace(alive.player, hp=0))

        self.assertFalse(_bu_win_waits_for_teammates(PlayStyle.BU_WIN.value, alive))
        self.assertTrue(_bu_win_waits_for_teammates(PlayStyle.BU_WIN.value, dead))
        self.assertFalse(_bu_win_waits_for_teammates(PlayStyle.SIMPLE.value, dead))

    def test_coop_entry_runtime_marks_ready_as_non_retryable_toggle(self) -> None:
        runtime = SharedEntryRuntime(
            target=object(),
            provider=object(),
            monitor=object(),
            binding=object(),
            executor=object(),
            backend=object(),
            coop_mode=True,
        )

        self.assertTrue(runtime.coop_mode)


if __name__ == "__main__":
    unittest.main()
