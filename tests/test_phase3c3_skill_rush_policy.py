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
    _known_sword_count,
)
from pokiguard_v2.board_simulator import ResourceResult, ResourceTally, evaluate_all_moves
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
from pokiguard_v2.gameplay_profile import DamageCardMode, EvolutionTarget, MainPetType
from pokiguard_v2.pet_configuration import (
    FarmPolicyUnavailable,
    GameplayConfig,
    PLAY_STYLE_LABELS,
    basic_policy_config,
)
from pokiguard_v2.state import BoardState, CellState, CombatSessionKey, GemType
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


def rush_policy() -> BasicPolicyEngine:
    return BasicPolicyEngine(
        PolicyConfig(
            play_style=PlayStyle.SKILL_RUSH,
            mana_priority=None,
            main_pet=MainPetType.LEGENDARY,
            evolution=EvolutionTarget.NONE,
            damage_card=DamageCardMode.PET_SKILL,
        )
    )


def candidate(
    base,
    *,
    mana: int = 0,
    rage: int = 0,
    sword: int = 0,
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
                    cell.multiplier,
                )
                for col, cell in enumerate(values)
            )
            for row, values in enumerate(state.board.cells)
        )
    )


def board_from_names(rows: tuple[tuple[str, ...], ...]) -> BoardState:
    return BoardState(
        tuple(
            tuple(
                CellState(row, col, GemType(gem), 1)
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


class Phase3c3SkillRushPolicyTests(unittest.TestCase):
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
        )
        with tempfile.TemporaryDirectory() as temporary:
            path = Path(temporary) / "preferences.json"
            store = DesktopPreferenceStore(path)
            store.save(config, game_location="fixture.exe")
            self.assertIn('"play_style": "skill_rush"', path.read_text(encoding="utf-8"))
            restored = store.load()
        self.assertTrue(restored.loaded)
        self.assertIs(restored.config.play_style, PlayStyle.SKILL_RUSH)

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

    def test_direct_and_indirect_sword_reply_are_allowed_strategic_risk(self) -> None:
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

        self.assertEqual(rushed.move, risky_progress.move)
        self.assertTrue(rushed.trace.selected_move_left_direct_boss_sword)
        self.assertTrue(rushed.trace.selected_move_left_indirect_boss_sword)
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
        state = replace(state, board=board_with_swords(state, 4))
        ready = rush_policy().decide(state, pet_skill_capability=capability())
        self.assertEqual(ready.action, PolicyAction.PET_SKILL)
        self.assertEqual(ready.trace.policy_step, "STEP_1_PET_SKILL")
        self.assertEqual(ready.trace.skill_fire_trigger, "HP_PREP")

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
            (45_000, 100_000, 5, PolicyAction.PET_SKILL, "HP_PREP"),
            (75_000, 100_000, 12, PolicyAction.PET_SKILL, "SWORD_DENSITY"),
            (75_000, 100_000, 5, PolicyAction.SWAP, None),
            (30_000, 100_000, 5, PolicyAction.PET_SKILL, "VERY_LOW_HP"),
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

    def test_hp_prep_is_complete_below_fifty_without_waiting_for_density(self) -> None:
        state = boss_state(hp=48_000, maximum=100_000)
        state = replace(state, board=board_with_swords(state, 4))
        decision = rush_policy().decide(state, pet_skill_capability=capability())
        self.assertEqual(decision.action, PolicyAction.PET_SKILL)
        self.assertTrue(decision.trace.hp_prep_ready)
        self.assertFalse(decision.trace.sword_density_ready)
        self.assertEqual(decision.trace.skill_fire_trigger, "HP_PREP")

    def test_revised_sword_density_floor_is_eight_and_unknown_counts_zero(self) -> None:
        state = boss_state(hp=75_000, maximum=100_000)
        seven_rows = [list(row) for row in FAILED_B1_TURN_13_ROWS]
        seven_rows[0][7] = "health"
        seven_board = board_from_names(tuple(tuple(row) for row in seven_rows))
        eight_board = board_from_names(FAILED_B1_TURN_13_ROWS)
        seven = replace(state, board=seven_board)
        eight = replace(state, board=eight_board)
        unknown_board = board_with_swords(state, 7, unknown_after=True)

        seven_decision = rush_policy().decide(seven, pet_skill_capability=capability())
        eight_decision = rush_policy().decide(eight, pet_skill_capability=capability())

        self.assertEqual(seven_decision.trace.known_sword_count, 7)
        self.assertEqual(_known_sword_count(unknown_board), 7)
        self.assertFalse(seven_decision.trace.sword_density_ready)
        self.assertIsNot(seven_decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(eight_decision.trace.known_sword_count, 8)
        self.assertTrue(eight_decision.trace.sword_density_ready)
        self.assertEqual(eight_decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(eight_decision.trace.skill_fire_trigger, "SWORD_DENSITY")

    def test_failed_b1_turn_13_fires_at_eight_sword(self) -> None:
        state = boss_state(hp=60_552, maximum=84_180)
        state = replace(state, board=board_from_names(FAILED_B1_TURN_13_ROWS))

        decision = rush_policy().decide(state, pet_skill_capability=capability())

        self.assertEqual(decision.trace.known_sword_count, 8)
        self.assertEqual(decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(decision.trace.skill_fire_trigger, "SWORD_DENSITY")

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

    def test_failed_b1_turn_27_fires_at_ten_sword_instead_of_more_setup(self) -> None:
        state = boss_state(hp=61_690, maximum=84_180, mana=215, rage=250)
        state = replace(state, board=board_from_names(FAILED_B1_TURN_27_ROWS))

        decision = rush_policy().decide(state, pet_skill_capability=capability())

        self.assertEqual(decision.trace.known_sword_count, 10)
        self.assertEqual(decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(decision.trace.skill_fire_trigger, "SWORD_DENSITY")

    def test_ready_setup_fires_instead_of_clearing_adjacent_when_isolated_pool_empty(self) -> None:
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
        self.assertEqual(decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(decision.trace.skill_fire_trigger, "SETUP_BLOCKED")
        counters = Counters()
        _record_policy_observation(
            counters,
            set(),
            state=state,
            decision=decision,
        )
        self.assertEqual(counters.skill_rush_setup_blocked_fires, 1)
        self.assertTrue(
            any(
                "no legal direct clear is at least two orthogonal cells" in item
                for item in decision.trace.failed_higher_priority_branches
            )
        )

    def test_missing_resource_dominates_high_sword_and_hp_prep(self) -> None:
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

    def test_one_ordinary_three_sword_move_is_early_hp_prep(self) -> None:
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
        self.assertEqual(
            decision.trace.policy_step,
            "SKILL_RUSH_EARLY_BOSS_PREP_SWORD",
        )
        self.assertEqual(decision.move, sword.move)

    def test_after_hp_prep_ready_setup_preserves_sword(self) -> None:
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

    def test_post_skill_finisher_absolute_relative_and_not_low_boundaries(self) -> None:
        context = SkillRushMatchContext(SESSION, 1, 5)
        cases = (
            (25_000, 200_000, True, "BOTH"),
            (40_000, 250_000, True, "RELATIVE_HP"),
            (60_000, 200_000, False, "NONE"),
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

    def test_post_skill_finisher_thresholds_are_strict(self) -> None:
        context = SkillRushMatchContext(SESSION, 1, 5)
        for hp, maximum in ((30_000, 100_000), (40_000, 200_000)):
            with self.subTest(hp=hp, maximum=maximum):
                state = boss_state(
                    hp=hp,
                    maximum=maximum,
                    mana=0,
                    rage=0,
                )
                decision = rush_policy().decide(
                    state,
                    pet_skill_capability=capability(),
                    skill_rush_match_context=context,
                )
                self.assertFalse(decision.trace.post_skill_finisher_ready)
                self.assertEqual(decision.trace.finisher_trigger, "NONE")
                self.assertIsNot(decision.action, PolicyAction.CAST)

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
        state = boss_state(hp=60_000, maximum=200_000)
        decision = rush_policy().decide(
            state,
            pet_skill_capability=capability(),
            skill_rush_match_context=SkillRushMatchContext(SESSION, 1, 5),
        )
        self.assertEqual(decision.action, PolicyAction.PET_SKILL)
        self.assertFalse(decision.trace.post_skill_finisher_ready)
        self.assertEqual(decision.trace.finisher_action, "SECOND_PET_SKILL")

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

    def test_telemetry_counters_separate_allowed_risk_from_safety(self) -> None:
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
        self.assertEqual(branch, "SKILL_RUSH_RESOURCE_PROGRESS")
        self.assertEqual(counters.skipped_current_sword_for_resource, 1)
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
        )
        combat = _combat_args(args, Path("combat.jsonl"))
        self.assertEqual(combat.play_style, "skill_rush")
        self.assertEqual(combat.main_pet, "legendary")
        self.assertEqual(combat.evolution_target, "none")
        self.assertEqual(combat.damage_card, "pet_skill")
        self.assertEqual(combat.pass_acceptance_stage, "B3")


if __name__ == "__main__":
    unittest.main()
