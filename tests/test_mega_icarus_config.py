from __future__ import annotations

from dataclasses import replace
from pathlib import Path
from tempfile import TemporaryDirectory
import unittest

from pokiguard_v2.basic_policy import PlayStyle
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
from pokiguard_v2.farm_checkpoint import load_checkpoint, write_checkpoint
from pokiguard_v2.gameplay_profile import (
    AuditionMode,
    DamageCardMode,
    EvolutionTarget,
    MainPetType,
    PetSkillFireCondition,
)
from pokiguard_v2.mega_icarus import (
    MEGA_ICARUS_SEAL_CELLS,
    count_seal_gems,
    mega_icarus_condition_ready,
    seal_condition_count,
)
from pokiguard_v2.pet_configuration import (
    GameplayConfig,
    SkillSource,
    gameplay_config_from_args,
)
from pokiguard_v2.state import BoardState, CellState, GemType
from tests.test_farm_checkpoint import _payload
from tools.farm_run import build_parser


STYLE = PlayStyle.MEGA_ICARUS_SPAM_SKILL


def mega_config(**changes: object) -> GameplayConfig:
    values = {
        "play_style": STYLE,
        "main_pet": MainPetType.MEGA,
        "evolution": EvolutionTarget.NONE,
        "damage_card": DamageCardMode.PET_SKILL,
        "audition_mode": AuditionMode.NO_ACTION,
        "pet_skill_fire_condition": PetSkillFireCondition.SWORD_COUNT,
        "pet_skill_fire_value": 10,
    }
    values.update(changes)
    return GameplayConfig(**values)


def board_with(
    gem: GemType,
    inside: int,
    *,
    outside: int = 0,
    inside_multiplier: int = 1,
    unknown_inside: int = 0,
) -> BoardState:
    seal = set(MEGA_ICARUS_SEAL_CELLS)
    inside_cells = list(MEGA_ICARUS_SEAL_CELLS)
    outside_cells = [
        (row, col)
        for row in range(8)
        for col in range(8)
        if (row, col) not in seal
    ]
    selected_inside = set(inside_cells[:inside])
    selected_outside = set(outside_cells[:outside])
    unknown = set(inside_cells[inside:inside + unknown_inside])
    cells = []
    for row in range(8):
        values = []
        for col in range(8):
            coordinate = (row, col)
            cell_gem = (
                gem if coordinate in selected_inside or coordinate in selected_outside
                else GemType.UNKNOWN if coordinate in unknown
                else GemType.HEALTH
            )
            multiplier = inside_multiplier if coordinate in selected_inside else 1
            values.append(CellState(row, col, cell_gem, multiplier))
        cells.append(tuple(values))
    return BoardState(tuple(cells))


class MegaIcarusSealContractTests(unittest.TestCase):
    def test_exact_user_supplied_mask_is_zero_based_unique_and_bounded(self) -> None:
        expected = (
            (0, 4),
            (1, 2), (1, 3), (1, 5),
            (2, 0), (2, 2), (2, 4), (2, 5), (2, 6),
            (3, 1), (3, 2), (3, 3), (3, 4), (3, 5), (3, 6), (3, 7),
            (4, 2), (4, 3), (4, 4), (4, 5), (4, 6),
            (5, 1), (5, 2), (5, 3), (5, 4), (5, 5),
            (6, 1), (6, 2), (6, 3), (6, 5),
        )
        self.assertEqual(MEGA_ICARUS_SEAL_CELLS, expected)
        self.assertEqual(len(MEGA_ICARUS_SEAL_CELLS), 30)
        self.assertEqual(len(set(MEGA_ICARUS_SEAL_CELLS)), 30)
        self.assertTrue(all(0 <= row < 8 and 0 <= col < 8 for row, col in expected))

    def test_only_effective_value_inside_seal_can_satisfy_threshold(self) -> None:
        outside_only = board_with(GemType.SWORD, 0, outside=20)
        nine_plus_outside = board_with(GemType.SWORD, 9, outside=20)
        ten_inside = board_with(GemType.SWORD, 10)

        self.assertFalse(mega_icarus_condition_ready(
            outside_only, PetSkillFireCondition.SWORD_COUNT, 10,
            skill_cost_ready=False,
        ))
        self.assertFalse(mega_icarus_condition_ready(
            nine_plus_outside, PetSkillFireCondition.SWORD_COUNT, 10,
            skill_cost_ready=False,
        ))
        self.assertTrue(mega_icarus_condition_ready(
            ten_inside, PetSkillFireCondition.SWORD_COUNT, 10,
            skill_cost_ready=False,
        ))

    def test_multiplier_contributes_to_readiness_and_unknown_never_has_credit(self) -> None:
        weighted = board_with(
            GemType.SWORD,
            9,
            inside_multiplier=3,
            unknown_inside=5,
        )
        count = count_seal_gems(weighted, GemType.SWORD)
        self.assertEqual(count.physical, 9)
        self.assertEqual(count.effective, 27)
        self.assertTrue(mega_icarus_condition_ready(
            weighted, PetSkillFireCondition.SWORD_COUNT, 10,
            skill_cost_ready=True,
        ))
        self.assertEqual(count_seal_gems(weighted, GemType.UNKNOWN).physical, 0)

    def test_every_existing_count_condition_uses_the_same_seal(self) -> None:
        mapping = {
            PetSkillFireCondition.SWORD_COUNT: GemType.SWORD,
            PetSkillFireCondition.MANA_GEM_COUNT: GemType.MANA,
            PetSkillFireCondition.RAGE_GEM_COUNT: GemType.RAGE,
            PetSkillFireCondition.DRAIN_GEM_COUNT: GemType.DRAIN,
            PetSkillFireCondition.SHIELD_GEM_COUNT: GemType.SHIELD,
        }
        for condition, gem in mapping.items():
            with self.subTest(condition=condition):
                board = board_with(gem, 4, outside=20, inside_multiplier=2)
                self.assertEqual(seal_condition_count(board, condition).physical, 4)
                self.assertTrue(mega_icarus_condition_ready(
                    board, condition, 8, skill_cost_ready=False,
                ))
                self.assertFalse(mega_icarus_condition_ready(
                    board, condition, 9, skill_cost_ready=False,
                ))

    def test_skill_cost_ready_is_independent_of_board_and_threshold(self) -> None:
        self.assertTrue(mega_icarus_condition_ready(
            None, PetSkillFireCondition.SKILL_COST_READY, None,
            skill_cost_ready=True,
        ))
        self.assertFalse(mega_icarus_condition_ready(
            None, PetSkillFireCondition.SKILL_COST_READY, 999,
            skill_cost_ready=False,
        ))


class MegaIcarusConfigurationTests(unittest.TestCase):
    def test_exact_three_loadouts_are_accepted_with_one_mega_source(self) -> None:
        accepted = (
            (MainPetType.MEGA, EvolutionTarget.NONE, SkillSource.MAIN_PET),
            (MainPetType.MEGA, EvolutionTarget.NORMAL, SkillSource.MAIN_PET),
            (MainPetType.NORMAL, EvolutionTarget.MEGA, SkillSource.EVOLUTION_TARGET),
        )
        for main_pet, evolution, source in accepted:
            with self.subTest(main_pet=main_pet, evolution=evolution):
                config = mega_config(main_pet=main_pet, evolution=evolution)
                self.assertTrue(config.capability.config_valid)
                self.assertEqual(config.capability.skill_sources, (source,))
                self.assertIsNone(config.farm_policy_blocker_reason)
                self.assertTrue(config.farm_policy_supported)

    def test_other_loadouts_and_fixed_fields_have_specific_blockers(self) -> None:
        invalid_loadouts = (
            (MainPetType.NORMAL, EvolutionTarget.NONE),
            (MainPetType.NORMAL, EvolutionTarget.NORMAL),
            (MainPetType.MEGA, EvolutionTarget.MEGA),
            (MainPetType.LEGENDARY, EvolutionTarget.MEGA),
        )
        for main_pet, evolution in invalid_loadouts:
            with self.subTest(main_pet=main_pet, evolution=evolution):
                with self.assertRaisesRegex(ValueError, "MEGA_ICARUS_LOADOUT_INVALID"):
                    mega_config(main_pet=main_pet, evolution=evolution)
        with self.assertRaisesRegex(ValueError, "MEGA_ICARUS_REQUIRES_PET_SKILL"):
            mega_config(damage_card=DamageCardMode.DEFAULT_ATTACK)
        with self.assertRaisesRegex(ValueError, "MEGA_ICARUS_REQUIRES_NO_ACTION"):
            mega_config(audition_mode=AuditionMode.V3_TWO_DIRECTION)

    def test_mega_and_no_action_do_not_leak_to_old_styles(self) -> None:
        with self.assertRaisesRegex(ValueError, "PET_OPTION_UNSUPPORTED"):
            GameplayConfig(
                play_style=PlayStyle.SIMPLE,
                main_pet=MainPetType.MEGA,
                evolution=EvolutionTarget.NONE,
                damage_card=DamageCardMode.PET_SKILL,
            )
        with self.assertRaisesRegex(ValueError, "NO_ACTION_REQUIRES_MEGA_ICARUS"):
            replace(GameplayConfig(), audition_mode=AuditionMode.NO_ACTION)
        for mode in (
            AuditionMode.V3_TWO_DIRECTION,
            AuditionMode.V2_FOUR_DIRECTION,
        ):
            old = replace(
                GameplayConfig(
                    main_pet=MainPetType.LEGENDARY,
                    evolution=EvolutionTarget.NONE,
                    damage_card=DamageCardMode.PET_SKILL,
                ),
                audition_mode=mode,
            )
            self.assertEqual(GameplayConfig.from_dict(old.to_dict()), old)

    def test_serialization_cli_preferences_and_checkpoint_round_trip(self) -> None:
        config = mega_config(
            main_pet=MainPetType.NORMAL,
            evolution=EvolutionTarget.MEGA,
            pet_skill_fire_condition=PetSkillFireCondition.DRAIN_GEM_COUNT,
            pet_skill_fire_value=12,
        )
        self.assertEqual(GameplayConfig.from_dict(config.to_dict()), config)

        args = build_parser().parse_args([
            "--stage-a-replay",
            "--play-style", STYLE.value,
            "--main-pet", MainPetType.NORMAL.value,
            "--evolution-target", EvolutionTarget.MEGA.value,
            "--damage-card", DamageCardMode.PET_SKILL.value,
            "--audition-mode", AuditionMode.NO_ACTION.value,
            "--pet-skill-fire-condition", PetSkillFireCondition.DRAIN_GEM_COUNT.value,
            "--pet-skill-fire-value", "12",
        ])
        self.assertEqual(gameplay_config_from_args(args), config)

        with TemporaryDirectory() as temporary:
            root = Path(temporary)
            desktop = DesktopConfig().with_gameplay_config(config)
            store = DesktopPreferenceStore(root / "preferences.json")
            store.save(desktop)
            self.assertEqual(store.load().config.gameplay_config, config)

            checkpoint = root / "checkpoint.json"
            write_checkpoint(
                checkpoint,
                replace(_payload(), gameplay_config=config),
            )
            self.assertEqual(load_checkpoint(checkpoint).gameplay_config, config)


if __name__ == "__main__":
    unittest.main()
