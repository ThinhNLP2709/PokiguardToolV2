from __future__ import annotations

from dataclasses import replace
import unittest
from unittest.mock import patch

from pokiguard_v2.basic_policy import (
    BasicPolicyEngine,
    PlayStyle,
    PolicyAction,
    PolicyConfig,
)
from pokiguard_v2.gameplay_profile import (
    DamageCardMode,
    EvolutionTarget,
    MainPetType,
    PetSkillFireCondition,
)
from pokiguard_v2.mega_icarus import MEGA_ICARUS_SEAL_CELLS
from pokiguard_v2.pet_skill_shadow import (
    PetSkillFamily,
    pet_skill_family,
    resolve_pet_skill_cost,
)
from pokiguard_v2.state import BoardState, CellState, GemType
from pokiguard_v2.state import GameOwnedIdleStatus
from tests.test_phase3c1_pet_skill_policy import capability, card_data, session_state
from tests.test_phase3c3_skill_rush_policy import (
    board_from_names,
    candidate,
    with_player_hp,
)
from pokiguard_v2.board_simulator import (
    ResourceResult,
    ResourceTally,
    evaluate_all_moves,
)
from tools.basic_auto_bot import Counters, _record_policy_observation


def mega_policy(
    *,
    main_pet: MainPetType = MainPetType.MEGA,
    evolution: EvolutionTarget = EvolutionTarget.NONE,
    threshold: int = 10,
    condition: PetSkillFireCondition = PetSkillFireCondition.SWORD_COUNT,
) -> BasicPolicyEngine:
    return BasicPolicyEngine(
        PolicyConfig(
            play_style=PlayStyle.MEGA_ICARUS_SPAM_SKILL,
            mana_priority=None,
            main_pet=main_pet,
            evolution=evolution,
            damage_card=DamageCardMode.PET_SKILL,
            pet_skill_fire_condition=condition,
            pet_skill_fire_value=(
                None
                if condition is PetSkillFireCondition.SKILL_COST_READY
                else threshold
            ),
        )
    )


def mega_capability(*, mana: int = 200, rage: int = 150):
    return replace(
        capability(mana_cost=mana, rage_cost=max(rage, 1)),
        element_type="MEGA1",
        skill_type="MEGA",
        effective_mana_cost=mana,
        effective_power_cost=rage,
        raw_condition_use=mana,
        raw_power=rage,
        need_perfection=False,
        skill_family=PetSkillFamily.MEGA_ICARUS_CLICK_ONLY,
    )


def board_with_seal_gems(
    base: BoardState,
    *,
    inside: int,
    outside: int = 0,
    gem: GemType = GemType.SWORD,
    inside_multipliers: tuple[int, ...] = (),
) -> BoardState:
    seal = tuple(MEGA_ICARUS_SEAL_CELLS)
    outside_cells = tuple(
        (row, col)
        for row in range(8)
        for col in range(8)
        if (row, col) not in set(seal)
    )
    selected = set(seal[:inside]) | set(outside_cells[:outside])
    multiplier_by_cell = {
        cell: inside_multipliers[index]
        for index, cell in enumerate(seal[:inside])
        if index < len(inside_multipliers)
    }
    return BoardState(
        tuple(
            tuple(
                CellState(
                    row,
                    col,
                    (
                        gem
                        if (row, col) in selected
                        else GemType.HEALTH
                        if base.cells[row][col].gem is GemType.SWORD
                        else base.cells[row][col].gem
                    ),
                    multiplier_by_cell.get((row, col), 1),
                )
                for col in range(8)
            )
            for row in range(8)
        )
    )


LIVE_LOSS_TURN_77_ROWS = (
    ("mana", "health", "mana", "drain", "rage", "drain", "mana", "health"),
    ("shield", "sword", "sword", "health", "drain", "mana", "health", "sword"),
    ("rage", "sword", "rage", "sword", "sword", "drain", "rage", "sword"),
    ("shield", "mana", "rage", "rage", "health", "sword", "mana", "drain"),
    ("health", "mana", "shield", "shield", "health", "health", "shield", "shield"),
    ("mana", "drain", "health", "rage", "shield", "drain", "drain", "mana"),
    ("shield", "drain", "mana", "mana", "rage", "sword", "rage", "mana"),
    ("rage", "shield", "shield", "sword", "health", "shield", "shield", "health"),
)

LIVE_LOSS_TURN_77_MULTIPLIERS = (
    (1, 1, 2, 4, 1, 2, 3, 1),
    (1, 1, 1, 1, 4, 1, 6, 2),
    (3, 1, 3, 1, 2, 2, 1, 1),
    (1, 3, 1, 1, 6, 1, 7, 4),
    (1, 4, 3, 4, 2, 4, 2, 2),
    (1, 2, 1, 1, 1, 1, 3, 1),
    (2, 4, 1, 1, 1, 1, 1, 1),
    (2, 4, 7, 1, 2, 1, 1, 1),
)


def with_boss_mana(state, mana: int):
    boss = replace(state.opponents[0], mana=mana)
    participants = tuple(
        boss if participant.is_boss else participant
        for participant in state.participants
    )
    return replace(state, opponents=(boss,), participants=participants)


def health_candidate(base, *, effective: int = 3):
    health = ResourceResult(
        ((GemType.HEALTH, ResourceTally(3, effective)),)
    )
    return replace(
        base,
        direct=health,
        cascade=ResourceResult(),
        total=health,
    )


class MegaIcarusPolicyTests(unittest.TestCase):
    def test_live_loss_turn_77_ready_skill_precedes_sword_survival(self) -> None:
        state = session_state(mana=3292, rage=177, boss_hp=2_683_851)
        state = replace(
            with_player_hp(state, hp=20_729, maximum=219_152),
            board=board_from_names(
                LIVE_LOSS_TURN_77_ROWS,
                multipliers=LIVE_LOSS_TURN_77_MULTIPLIERS,
            ),
        )
        state = with_boss_mana(state, 298)

        decision = mega_policy(threshold=6).decide(
            state,
            pet_skill_capability=mega_capability(),
        )

        self.assertIs(decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(
            decision.trace.policy_step,
            "MEGA_ICARUS_SURVIVAL_SKILL",
        )

    def test_critical_hp_uses_health_when_skill_not_ready_and_no_sword(self) -> None:
        state = with_player_hp(session_state(mana=50, rage=50), hp=20)
        state = with_boss_mana(state, 50)
        bases = evaluate_all_moves(state.board)
        health = health_candidate(bases[0], effective=7)
        mana = candidate(bases[1], mana=5)

        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(mana, health),
        ):
            decision = mega_policy(threshold=10).decide(
                state,
                pet_skill_capability=mega_capability(),
            )

        self.assertIs(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.move, health.move)
        self.assertEqual(
            decision.trace.policy_step,
            "MEGA_ICARUS_SURVIVAL_HEALTH",
        )

    def test_critical_hp_uses_clean_sword_instead_of_larger_reply_leaving_sword(
        self,
    ) -> None:
        state = with_player_hp(session_state(mana=50, rage=50), hp=20)
        bases = evaluate_all_moves(state.board)
        larger_but_leaves_sword = candidate(
            bases[0], sword=12, direct_replies=1
        )
        smaller_and_clean = candidate(bases[1], sword=3)

        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(larger_but_leaves_sword, smaller_and_clean),
        ):
            decision = mega_policy(threshold=10).decide(
                state,
                pet_skill_capability=mega_capability(),
            )

        self.assertIs(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.move, smaller_and_clean.move)
        self.assertEqual(decision.trace.policy_step, "MEGA_ICARUS_SURVIVAL_SWORD")
        self.assertEqual(
            decision.trace.selected_candidate.opponent_sword_replies, 0
        )

    def test_critical_hp_breaks_all_sword_replies_when_every_sword_match_leaves_one(
        self,
    ) -> None:
        state = with_player_hp(session_state(mana=50, rage=50), hp=20)
        bases = evaluate_all_moves(state.board)
        first_sword = candidate(bases[0], sword=12, direct_replies=1)
        second_sword = candidate(bases[1], sword=7, direct_replies=1)
        breaker = candidate(bases[2], shield=3)

        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(first_sword, second_sword, breaker),
        ):
            decision = mega_policy(threshold=10).decide(
                state,
                pet_skill_capability=mega_capability(),
            )

        self.assertIs(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.move, breaker.move)
        self.assertEqual(
            decision.trace.policy_step,
            "MEGA_ICARUS_SURVIVAL_SWORD_BREAK",
        )
        self.assertEqual(
            decision.trace.selected_candidate.opponent_sword_replies, 0
        )

    def test_critical_hp_safe_fallback_prefers_shield_before_drain(self) -> None:
        state = with_player_hp(session_state(mana=50, rage=50), hp=20)
        bases = evaluate_all_moves(state.board)
        drain = candidate(bases[0], drain=9)
        shield = candidate(bases[1], shield=3)
        safe_other = candidate(bases[2], mana=9)

        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(drain, shield, safe_other),
        ):
            decision = mega_policy(threshold=10).decide(
                state,
                pet_skill_capability=mega_capability(),
            )

        self.assertIs(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.move, shield.move)
        self.assertEqual(
            decision.trace.policy_step,
            "MEGA_ICARUS_SURVIVAL_SHIELD",
        )

    def test_critical_hp_fires_ready_skill_without_seal_threshold(self) -> None:
        state = with_player_hp(session_state(mana=250, rage=250), hp=20)
        state = with_boss_mana(state, 50)
        base = evaluate_all_moves(state.board)[0]
        mana = candidate(base, mana=5)

        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(mana,),
        ):
            decision = mega_policy(threshold=64).decide(
                state,
                pet_skill_capability=mega_capability(),
            )

        self.assertIs(decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(
            decision.trace.policy_step,
            "MEGA_ICARUS_SURVIVAL_SKILL",
        )
        self.assertEqual(
            decision.trace.skill_fire_trigger,
            "MEGA_ICARUS_SURVIVAL_HEAL",
        )
        self.assertFalse(decision.trace.selected_fire_condition_ready)

        counters = Counters()
        branch = _record_policy_observation(
            counters,
            set(),
            state=state,
            decision=decision,
        )
        self.assertEqual(branch, "MEGA_ICARUS_SURVIVAL_SKILL")
        self.assertEqual(counters.mega_icarus_survival_skill_fires, 1)
        self.assertEqual(counters.skill_rush_fire_condition_fires, 0)

    def test_critical_hp_skips_health_when_boss_has_no_mana_and_uses_skill(self) -> None:
        state = with_player_hp(session_state(mana=250, rage=250), hp=20)
        state = with_boss_mana(state, 0)
        health = health_candidate(evaluate_all_moves(state.board)[0])

        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(health,),
        ):
            decision = mega_policy(threshold=64).decide(
                state,
                pet_skill_capability=mega_capability(),
            )

        self.assertIs(decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(
            decision.trace.policy_step,
            "MEGA_ICARUS_SURVIVAL_SKILL",
        )

    def test_survival_branch_does_not_replace_ready_evolution(self) -> None:
        state = with_player_hp(session_state(mana=250, rage=250), hp=20)
        state = replace(
            state,
            fusion=replace(state.fusion, available=True, used=False, mana_cost=120),
        )

        decision = mega_policy(evolution=EvolutionTarget.NORMAL).decide(
            state,
            pet_skill_capability=mega_capability(),
        )

        self.assertIs(decision.action, PolicyAction.EVOLVE)

    def test_mega1_live_cost_keeps_zero_rage_as_known(self) -> None:
        family, _target = pet_skill_family("MEGA1")
        cost = resolve_pet_skill_cost(
            card_data(element="MEGA1", mana_cost=200, rage_cost=0)
        )
        self.assertIs(family, PetSkillFamily.MEGA_ICARUS_CLICK_ONLY)
        self.assertEqual(cost.effective_mana_cost, 200)
        self.assertEqual(cost.effective_power_cost, 0)

    def test_global_ten_but_only_nine_in_seal_does_not_fire(self) -> None:
        state = session_state(mana=250, rage=250)
        state = replace(
            state,
            board=board_with_seal_gems(state.board, inside=9, outside=1),
        )
        decision = mega_policy().decide(
            state, pet_skill_capability=mega_capability()
        )
        self.assertIsNot(decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(decision.trace.selected_known_gem_count, 9)
        self.assertEqual(decision.trace.fire_condition_scope, "MEGA_ICARUS_SEAL_30")

    def test_ten_effective_gems_in_seal_fire_immediately(self) -> None:
        state = session_state(mana=250, rage=250)
        state = replace(
            state,
            board=board_with_seal_gems(state.board, inside=10),
        )
        decision = mega_policy().decide(
            state, pet_skill_capability=mega_capability()
        )
        self.assertIs(decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(decision.trace.policy_step, "MEGA_ICARUS_FIRE")
        self.assertEqual(decision.trace.selected_known_gem_count, 10)
        self.assertEqual(decision.trace.skill_source, "MAIN_PET")

    def test_multipliers_count_toward_seal_threshold(self) -> None:
        state = session_state(mana=250, rage=250)
        state = replace(
            state,
            board=board_with_seal_gems(
                state.board,
                inside=8,
                inside_multipliers=(2, 2, 1, 1, 1, 1, 1, 1),
            ),
        )
        decision = mega_policy().decide(
            state, pet_skill_capability=mega_capability()
        )
        self.assertIs(decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(decision.trace.selected_known_gem_count, 8)
        self.assertEqual(decision.trace.selected_known_gem_effective_count, 10)

    def test_zero_live_rage_requirement_is_known_and_ready(self) -> None:
        state = session_state(mana=200, rage=0)
        state = replace(
            state,
            board=board_with_seal_gems(state.board, inside=10),
        )
        decision = mega_policy().decide(
            state, pet_skill_capability=mega_capability(rage=0)
        )
        self.assertIs(decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(decision.trace.required_rage, 0)
        self.assertEqual(decision.trace.missing_rage, 0)

    def test_missing_resource_progress_beats_drain_and_shield(self) -> None:
        state = session_state(mana=0, rage=150)
        state = replace(
            state,
            board=board_with_seal_gems(state.board, inside=10),
        )
        base = evaluate_all_moves(state.board)[0]
        mana_move = candidate(base, mana=3)
        drain_move = candidate(replace(base, move=evaluate_all_moves(state.board)[1].move), drain=3)
        shield_move = candidate(replace(base, move=evaluate_all_moves(state.board)[2].move), shield=3)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(shield_move, drain_move, mana_move),
        ):
            decision = mega_policy().decide(
                state, pet_skill_capability=mega_capability()
            )
        self.assertIs(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.move, mana_move.move)
        self.assertEqual(decision.trace.policy_step, "MEGA_ICARUS_RESOURCE_PROGRESS")

    def test_missing_rage_uses_live_rage_progress(self) -> None:
        state = session_state(mana=200, rage=0)
        state = replace(
            state,
            board=board_with_seal_gems(state.board, inside=10),
        )
        bases = evaluate_all_moves(state.board)
        rage_move = candidate(bases[0], rage=3)
        drain_move = candidate(bases[1], drain=3)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(drain_move, rage_move),
        ):
            decision = mega_policy().decide(
                state, pet_skill_capability=mega_capability()
            )
        self.assertEqual(decision.move, rage_move.move)
        self.assertEqual(decision.trace.missing_rage, 150)


    def test_drain_beats_shield_when_no_resource_progress_exists(self) -> None:
        state = session_state(mana=0, rage=150)
        state = replace(
            state,
            board=board_with_seal_gems(state.board, inside=10),
        )
        bases = evaluate_all_moves(state.board)
        drain_move = candidate(bases[0], drain=3)
        shield_move = candidate(bases[1], shield=3)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(shield_move, drain_move),
        ):
            decision = mega_policy().decide(
                state, pet_skill_capability=mega_capability()
            )
        self.assertEqual(decision.move, drain_move.move)
        self.assertEqual(decision.trace.policy_step, "MEGA_ICARUS_LEGAL_FALLBACK")

    def test_sword_only_resource_board_uses_only_bounded_pass(self) -> None:
        state = session_state(mana=0, rage=0)
        state = replace(
            state,
            board=board_with_seal_gems(state.board, inside=10),
            battle=replace(
                state.battle,
                consecutive_passes=1,
                consecutive_pass_threshold=3,
                consecutive_pass_source="PlayerData.countSkipTurn",
                consecutive_pass_status=GameOwnedIdleStatus.PASS_ALLOWED,
            ),
        )
        base = evaluate_all_moves(state.board)[0]
        sword_only = candidate(base, sword=3)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(sword_only,),
        ):
            allowed = mega_policy().decide(
                state, pet_skill_capability=mega_capability()
            )
        self.assertIs(allowed.action, PolicyAction.PASS)
        self.assertEqual(allowed.trace.policy_step, "MEGA_ICARUS_RESOURCE_PASS")

        mandatory_state = replace(
            state,
            battle=replace(
                state.battle,
                consecutive_passes=2,
                consecutive_pass_status=(
                    GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION
                ),
            ),
        )
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(sword_only,),
        ):
            blocked = mega_policy().decide(
                mandatory_state, pet_skill_capability=mega_capability()
            )
        self.assertIs(blocked.action, PolicyAction.NONE)
        self.assertEqual(blocked.trace.blocker, "MEGA_ICARUS_ONLY_SWORD_MOVES")

    def test_setup_ranks_effective_seal_count_before_physical_count(self) -> None:
        state = session_state(mana=250, rage=250)
        state = replace(
            state,
            board=board_with_seal_gems(state.board, inside=5),
        )
        bases = evaluate_all_moves(state.board)
        physical_result = board_with_seal_gems(state.board, inside=9).cells
        effective_result = board_with_seal_gems(
            state.board,
            inside=7,
            inside_multipliers=(2, 2, 2, 1, 1, 1, 1),
        ).cells
        physical_move = candidate(replace(bases[0], result=physical_result))
        effective_move = candidate(replace(bases[1], result=effective_result))
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(physical_move, effective_move),
        ):
            decision = mega_policy().decide(
                state, pet_skill_capability=mega_capability()
            )
        self.assertEqual(decision.move, effective_move.move)
        self.assertEqual(decision.trace.policy_step, "MEGA_ICARUS_BOARD_SETUP")

    def test_setup_prefers_no_boss_sword_reply_over_larger_seal_gain(self) -> None:
        state = session_state(mana=250, rage=250)
        state = replace(
            state,
            board=board_with_seal_gems(state.board, inside=5),
        )
        bases = evaluate_all_moves(state.board)
        safe_result = board_with_seal_gems(state.board, inside=7).cells
        risky_result = board_with_seal_gems(
            state.board,
            inside=8,
            inside_multipliers=(2, 2, 1, 1, 1, 1, 1, 1),
        ).cells
        safe_move = candidate(replace(bases[0], result=safe_result))
        risky_move = candidate(
            replace(bases[1], result=risky_result),
            direct_replies=1,
        )
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(risky_move, safe_move),
        ):
            decision = mega_policy().decide(
                state, pet_skill_capability=mega_capability()
            )
        self.assertEqual(decision.move, safe_move.move)
        self.assertIn("setupSafety=SWORD_SAFE", decision.trace.why_selected)

    def test_setup_minimizes_boss_effective_sword_when_all_moves_are_risky(self) -> None:
        state = session_state(mana=250, rage=250)
        state = replace(
            state,
            board=board_with_seal_gems(state.board, inside=5),
        )
        bases = evaluate_all_moves(state.board)
        low_result = board_with_seal_gems(state.board, inside=6).cells
        high_result = board_with_seal_gems(
            state.board,
            inside=8,
            inside_multipliers=(2, 2, 1, 1, 1, 1, 1, 1),
        ).cells
        low_risk = candidate(
            replace(bases[0], result=low_result), direct_replies=1
        )
        high_risk = candidate(
            replace(bases[1], result=high_result), direct_replies=1
        )
        low_risk = replace(
            low_risk,
            sword_risk=replace(
                low_risk.sword_risk,
                opponent_sword_reply_effective_max=3,
            ),
        )
        high_risk = replace(
            high_risk,
            sword_risk=replace(
                high_risk.sword_risk,
                opponent_sword_reply_effective_max=8,
            ),
        )
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(high_risk, low_risk),
        ):
            decision = mega_policy().decide(
                state, pet_skill_capability=mega_capability()
            )
        self.assertEqual(decision.move, low_risk.move)
        self.assertIn(
            "setupSafety=MINIMUM_BOSS_SWORD_REPLY",
            decision.trace.why_selected,
        )

    def test_setup_passes_when_risky_move_is_worse_than_unchanged_board(self) -> None:
        state = session_state(mana=250, rage=250)
        state = replace(
            state,
            board=board_with_seal_gems(state.board, inside=7),
            battle=replace(
                state.battle,
                turn_number=3,
                consecutive_passes=1,
                consecutive_pass_threshold=3,
                consecutive_pass_source="PlayerData.countSkipTurn",
                consecutive_pass_status=GameOwnedIdleStatus.PASS_ALLOWED,
            ),
        )
        base = evaluate_all_moves(state.board)[0]
        projected_ten = board_with_seal_gems(state.board, inside=10).cells
        risky = candidate(
            replace(base, result=projected_ten),
            direct_replies=1,
        )
        risky = replace(
            risky,
            sword_risk=replace(
                risky.sword_risk,
                opponent_sword_reply_effective_max=5,
            ),
        )
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(risky,),
        ):
            decision = mega_policy().decide(
                state, pet_skill_capability=mega_capability()
            )
        self.assertIs(decision.action, PolicyAction.PASS)
        self.assertEqual(decision.trace.policy_step, "MEGA_ICARUS_SETUP_PASS")
        self.assertIn("selectedSealFloor=5", decision.trace.why_selected)
        self.assertIn("passSealFloor=7", decision.trace.why_selected)

    def test_setup_passes_when_safe_move_loses_seal_progress(self) -> None:
        state = session_state(mana=250, rage=250)
        state = replace(
            state,
            board=board_with_seal_gems(state.board, inside=7),
            battle=replace(
                state.battle,
                turn_number=3,
                consecutive_passes=0,
                consecutive_pass_threshold=3,
                consecutive_pass_source="PlayerData.countSkipTurn",
                consecutive_pass_status=GameOwnedIdleStatus.PASS_ALLOWED,
            ),
        )
        base = evaluate_all_moves(state.board)[0]
        reduced_result = board_with_seal_gems(state.board, inside=6).cells
        safe_but_regressive = candidate(
            replace(base, result=reduced_result),
        )
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(safe_but_regressive,),
        ):
            decision = mega_policy().decide(
                state, pet_skill_capability=mega_capability()
            )
        self.assertIs(decision.action, PolicyAction.PASS)
        self.assertEqual(decision.trace.policy_step, "MEGA_ICARUS_SETUP_PASS")
        self.assertIn("selectedSetupSafety=SWORD_SAFE", decision.trace.why_selected)
        self.assertIn("selectedSealFloor=6", decision.trace.why_selected)
        self.assertIn("passSealFloor=7", decision.trace.why_selected)

    def test_setup_swaps_when_it_preserves_more_than_pass(self) -> None:
        state = session_state(mana=250, rage=250)
        state = replace(
            state,
            board=board_with_seal_gems(state.board, inside=8),
            battle=replace(
                state.battle,
                turn_number=3,
                consecutive_passes=1,
                consecutive_pass_threshold=3,
                consecutive_pass_source="PlayerData.countSkipTurn",
                consecutive_pass_status=GameOwnedIdleStatus.PASS_ALLOWED,
            ),
        )
        bases = evaluate_all_moves(state.board)
        selected_result = board_with_seal_gems(state.board, inside=9).cells
        selected = candidate(
            replace(bases[0], result=selected_result),
            direct_replies=1,
        )
        selected = replace(
            selected,
            sword_risk=replace(
                selected.sword_risk,
                opponent_sword_reply_effective_max=4,
            ),
        )
        pass_result = board_with_seal_gems(state.board, inside=3).cells
        current_sword_move = candidate(
            replace(bases[1], result=pass_result),
            sword=5,
        )
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(selected, current_sword_move),
        ):
            decision = mega_policy().decide(
                state, pet_skill_capability=mega_capability()
            )
        self.assertIs(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.move, selected.move)
        self.assertIn("passSealFloor=3", decision.trace.why_selected)

    def test_setup_never_uses_a_third_consecutive_pass(self) -> None:
        state = session_state(mana=250, rage=250)
        state = replace(
            state,
            board=board_with_seal_gems(state.board, inside=7),
            battle=replace(
                state.battle,
                turn_number=3,
                consecutive_passes=2,
                consecutive_pass_threshold=3,
                consecutive_pass_source="PlayerData.countSkipTurn",
                consecutive_pass_status=(
                    GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION
                ),
            ),
        )
        base = evaluate_all_moves(state.board)[0]
        projected_ten = board_with_seal_gems(state.board, inside=10).cells
        risky = candidate(
            replace(base, result=projected_ten),
            direct_replies=1,
        )
        risky = replace(
            risky,
            sword_risk=replace(
                risky.sword_risk,
                opponent_sword_reply_effective_max=5,
            ),
        )
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(risky,),
        ):
            decision = mega_policy().decide(
                state, pet_skill_capability=mega_capability()
            )
        self.assertIs(decision.action, PolicyAction.SWAP)

    def test_equal_safe_setup_prefers_turnover_inside_seal(self) -> None:
        state = session_state(mana=250, rage=250)
        state = replace(
            state,
            board=board_with_seal_gems(state.board, inside=5),
        )
        bases = evaluate_all_moves(state.board)
        result = board_with_seal_gems(state.board, inside=6).cells
        outside = candidate(
            replace(
                bases[0],
                result=result,
                clear_rounds=(((0, 0), (0, 1), (0, 2)),),
            )
        )
        inside = candidate(
            replace(
                bases[0],
                move=bases[1].move,
                result=result,
                clear_rounds=(((3, 2), (3, 3), (3, 4)),),
            )
        )
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(outside, inside),
        ):
            decision = mega_policy().decide(
                state, pet_skill_capability=mega_capability()
            )
        self.assertEqual(decision.move, inside.move)
        self.assertIn("sealGravityAffected=", decision.trace.why_selected)

    def test_all_three_loadouts_keep_evolution_and_source_contract(self) -> None:
        main = session_state(mana=250, rage=250)
        main = replace(
            main,
            board=board_with_seal_gems(main.board, inside=10),
            fusion=replace(main.fusion, available=False, used=False),
        )
        direct = mega_policy().decide(
            main, pet_skill_capability=mega_capability()
        )
        self.assertIs(direct.action, PolicyAction.PET_SKILL)

        mega_plus_normal = replace(
            main,
            fusion=replace(main.fusion, available=True, used=False, mana_cost=120),
        )
        evolve_main = mega_policy(evolution=EvolutionTarget.NORMAL).decide(
            mega_plus_normal, pet_skill_capability=mega_capability()
        )
        self.assertIs(evolve_main.action, PolicyAction.EVOLVE)

        normal_plus_mega = replace(
            main,
            fusion=replace(main.fusion, available=True, used=False, mana_cost=120),
        )
        evolve_source = mega_policy(
            main_pet=MainPetType.NORMAL,
            evolution=EvolutionTarget.MEGA,
        ).decide(normal_plus_mega, pet_skill_capability=None)
        self.assertIs(evolve_source.action, PolicyAction.EVOLVE)

        after = replace(normal_plus_mega, fusion=replace(normal_plus_mega.fusion, used=True))
        after_decision = mega_policy(
            main_pet=MainPetType.NORMAL,
            evolution=EvolutionTarget.MEGA,
        ).decide(after, pet_skill_capability=mega_capability())
        self.assertIs(after_decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(after_decision.trace.skill_source, "EVOLUTION_TARGET")

    def test_surviving_boss_repeats_skill_cycle_without_finisher(self) -> None:
        state = session_state(mana=250, rage=250, boss_hp=10_000)
        state = replace(
            state,
            board=board_with_seal_gems(state.board, inside=10),
        )
        decision = mega_policy().decide(
            state, pet_skill_capability=mega_capability()
        )
        self.assertIs(decision.action, PolicyAction.PET_SKILL)
        self.assertIsNone(decision.trace.finisher_action)
        self.assertFalse(decision.trace.post_skill_finisher_ready)

        depleted = replace(
            state,
            player=replace(state.player, mana=0, power=0),
            participants=tuple(
                replace(item, mana=0, power=0) if item.is_local else item
                for item in state.participants
            ),
        )
        bases = evaluate_all_moves(depleted.board)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(candidate(bases[0], mana=3),),
        ):
            next_cycle = mega_policy().decide(
                depleted, pet_skill_capability=mega_capability()
            )
        self.assertIs(next_cycle.action, PolicyAction.SWAP)
        self.assertTrue(next_cycle.trace.policy_step.startswith("MEGA_ICARUS_RESOURCE"))


if __name__ == "__main__":
    unittest.main()
