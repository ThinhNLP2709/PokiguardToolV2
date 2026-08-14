from __future__ import annotations

from dataclasses import replace
import unittest
from unittest.mock import patch

from pokiguard_v2.basic_policy import (
    BasicPolicyEngine,
    Intelligence,
    ManaPriority,
    PlayStyle,
    PolicyAction,
    PolicyConfig,
)
from pokiguard_v2.combat_lifecycle import CombatLifecycleState
from pokiguard_v2.board_simulator import (
    ResourceResult,
    ResourceTally,
    SwapMove,
    evaluate_all_moves,
)
from pokiguard_v2.state import (
    BattleState,
    BoardState,
    CardState,
    CellState,
    FusionState,
    GamePhase,
    GameOwnedIdleStatus,
    GameState,
    GemType,
    ParticipantState,
)
from tests.test_board_simulator import (
    cyclic_board,
    fixture_board,
    retry17_seq19_board,
    retry18_seq11_board,
)


def attack_card() -> CardState:
    return CardState(
        object_address=0x20000001000,
        data_address=0x20000002000,
        data_id=64647,
        card_id=4,
        name="Tấn công",
        description="Tấn công",
        element_type="ATTACK",
        skill_type="",
        interactable=True,
        has_used_this_match=False,
        has_used_this_turn=False,
        last_turn_used=-1,
        action_pending=False,
        is_placeholder=False,
        mana_cost=0,
        power_cost=0,
        cooldown_turns=0,
        need_perfection=False,
        condition_use=160,
    )


def combat_state(
    *,
    board: BoardState | None = None,
    mana: int = 241,
    rage: int = 95,
    fusion_used: bool = True,
    fusion_available: bool | None = None,
    fusion_locked: bool = False,
    cards: tuple[CardState, ...] = (),
    turn: int = 14,
) -> GameState:
    player = ParticipantState(
        actor_number=1,
        is_local=True,
        is_boss=False,
        hp=48247,
        max_hp=105228,
        mana=mana,
        max_mana=1741,
        power=rage,
        max_power=250,
    )
    boss = ParticipantState(
        actor_number=99,
        is_local=False,
        is_boss=True,
        hp=39602,
        max_hp=84180,
        mana=0,
        max_mana=445,
        power=150,
        max_power=250,
    )
    return GameState(
        GamePhase.COMBAT,
        "2026-08-12T01:44:23.853Z",
        board=board or fixture_board(),
        battle=BattleState(
            combat_lifecycle=CombatLifecycleState.ACTIVE,
            board_instance=0x20000000000,
            srv_seq=14,
            turn_number=turn,
            current_turn_player="happi",
            stable=True,
            board_hash="fixture",
            is_local_turn=True,
            client_move_allowed=True,
            turn_duration_seconds=14,
            turn_time_remaining_seconds=12,
            turn_timer_source="fixture.visible_timer",
            consecutive_passes=None,
            consecutive_pass_threshold=3,
            consecutive_pass_source=None,
        ),
        player=player,
        opponents=(boss,),
        participants=(player, boss),
        cards=cards,
        fusion=FusionState(
            enabled=True,
            available=(not fusion_used) if fusion_available is None else fusion_available,
            used=fusion_used,
            locked_this_turn=fusion_locked,
            mana_cost=160,
            ui_address=0x20000003000,
            ui_interactable=True,
        ),
    )


def no_sword_or_mana_board() -> BoardState:
    replacements = {
        GemType.SWORD: GemType.DRAIN,
        GemType.MANA: GemType.DRAIN,
    }
    source = fixture_board()
    return BoardState(
        tuple(
            tuple(
                CellState(
                    row,
                    col,
                    replacements.get(cell.gem, cell.gem),
                    cell.multiplier,
                )
                for col, cell in enumerate(values)
            )
            for row, values in enumerate(source.cells)
        )
    )


class BasicPolicyTests(unittest.TestCase):
    def test_retry18_board_uses_safe_shield_instead_of_false_no_safe_move(self) -> None:
        state = combat_state(
            board=retry18_seq11_board(),
            mana=140,
            rage=75,
            fusion_used=False,
            fusion_available=True,
            turn=5,
        )
        boss = replace(state.opponents[0], mana=0, power=10)
        state = replace(state, opponents=(boss,), participants=(state.player, boss))

        decision = BasicPolicyEngine().decide(state)

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.trace.policy_step, "STEP_5_SHIELD")
        self.assertEqual(decision.move, SwapMove((4, 6), (4, 7)))
        self.assertTrue(decision.trace.selected_candidate.safe)

    def test_retry17_board_uses_safe_mana_instead_of_false_no_safe_move(self) -> None:
        decision = BasicPolicyEngine().decide(
            combat_state(
                board=retry17_seq19_board(),
                mana=0,
                rage=25,
                fusion_used=False,
                fusion_available=True,
                turn=9,
            )
        )

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.trace.policy_step, "STEP_3_MANA")
        self.assertEqual(decision.move, SwapMove((2, 3), (2, 4)))
        self.assertTrue(decision.trace.selected_candidate.safe)

    def test_evolution_is_first_and_requires_reread(self) -> None:
        decision = BasicPolicyEngine(
            PolicyConfig(mana_priority=ManaPriority.EVOLUTION)
        ).decide(combat_state(fusion_used=False))
        self.assertEqual(decision.action, PolicyAction.EVOLVE)
        self.assertFalse(decision.consumes_turn)
        self.assertTrue(decision.requires_state_reread)
        self.assertEqual(decision.trace.policy_step, "STEP_1_EVOLVE")

    def test_evolution_requires_live_interactable_ui(self) -> None:
        state = combat_state(fusion_used=False)
        state = replace(
            state,
            fusion=replace(state.fusion, ui_interactable=None),
        )
        decision = BasicPolicyEngine().decide(state)
        self.assertNotEqual(decision.action, PolicyAction.EVOLVE)
        self.assertTrue(
            any(
                "FusionCardUI is not proven interactable" in reason
                for reason in decision.trace.failed_higher_priority_branches
            )
        )

    def test_evolution_requires_actual_positive_runtime_cost(self) -> None:
        state = combat_state(fusion_used=False)
        state = replace(state, fusion=replace(state.fusion, mana_cost=None))
        decision = BasicPolicyEngine().decide(state)
        self.assertNotEqual(decision.action, PolicyAction.EVOLVE)
        self.assertTrue(
            any(
                "actual positive evolution cost UNKNOWN" in reason
                for reason in decision.trace.failed_higher_priority_branches
            )
        )

    def test_failed_evolution_cannot_retry_while_same_turn_is_locked(self) -> None:
        decision = BasicPolicyEngine(
            PolicyConfig(mana_priority=ManaPriority.EVOLUTION)
        ).decide(
            combat_state(
                fusion_used=False,
                fusion_available=False,
                fusion_locked=True,
            )
        )
        self.assertNotEqual(decision.action, PolicyAction.EVOLVE)
        self.assertTrue(
            any(
                "fusion is not currently available" in reason
                for reason in decision.trace.failed_higher_priority_branches
            )
        )

    def test_failed_evolution_can_be_proposed_again_on_actionable_next_turn(self) -> None:
        decision = BasicPolicyEngine(
            PolicyConfig(mana_priority=ManaPriority.EVOLUTION)
        ).decide(
            combat_state(
                turn=16,
                fusion_used=False,
                fusion_available=True,
                fusion_locked=False,
            )
        )
        self.assertEqual(decision.action, PolicyAction.EVOLVE)

    def test_evolution_stops_after_success_or_when_mana_is_insufficient(self) -> None:
        engine = BasicPolicyEngine(PolicyConfig(mana_priority=ManaPriority.EVOLUTION))
        self.assertNotEqual(
            engine.decide(combat_state(fusion_used=True)).action,
            PolicyAction.EVOLVE,
        )
        self.assertNotEqual(
            engine.decide(combat_state(fusion_used=False, mana=159)).action,
            PolicyAction.EVOLVE,
        )

    def test_attack_priority_disables_evolution_and_screenshot_selects_indirect_sword(self) -> None:
        decision = BasicPolicyEngine(
            PolicyConfig(mana_priority=ManaPriority.ATTACK)
        ).decide(combat_state(fusion_used=False))
        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.move, SwapMove((6, 5), (6, 6)))
        self.assertEqual(decision.trace.policy_step, "STEP_2_SWORD")
        assert decision.trace.selected_candidate is not None
        self.assertEqual(decision.trace.selected_candidate.sword_effective, 6)

    def test_attack_priority_never_evolves_with_full_fusion_eligibility(self) -> None:
        engine = BasicPolicyEngine(
            PolicyConfig(mana_priority=ManaPriority.ATTACK)
        )
        for mana in (160, 480, 481, 1000):
            with self.subTest(mana=mana):
                decision = engine.decide(
                    combat_state(
                        mana=mana,
                        fusion_used=False,
                        fusion_available=True,
                        fusion_locked=False,
                    )
                )
                self.assertIsNot(decision.action, PolicyAction.EVOLVE)
                self.assertTrue(
                    any(
                        "disabled for the entire match" in reason
                        for reason in decision.trace.failed_higher_priority_branches
                    )
                )

    def test_equivalent_sword_moves_prefer_the_one_with_rage(self) -> None:
        state = combat_state(fusion_used=True)
        evaluations = evaluate_all_moves(state.board)  # type: ignore[arg-type]
        base = next(value for value in evaluations if value.sword_effective > 0)
        sword_only_result = ResourceResult(
            ((GemType.SWORD, ResourceTally(3, 3)),)
        )
        sword_rage_result = ResourceResult(
            (
                (GemType.SWORD, ResourceTally(3, 3)),
                (GemType.RAGE, ResourceTally(3, 3)),
            )
        )
        sword_only = replace(
            base,
            direct=sword_only_result,
            cascade=ResourceResult(),
            total=sword_only_result,
        )
        sword_with_rage = replace(
            evaluations[-1],
            direct=sword_rage_result,
            cascade=ResourceResult(),
            total=sword_rage_result,
            cascade_rounds=sword_only.cascade_rounds,
            sword_risk=sword_only.sword_risk,
            calculable=sword_only.calculable,
        )

        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(sword_only, sword_with_rage),
        ):
            decision = BasicPolicyEngine().decide(state)

        self.assertEqual(decision.trace.policy_step, "STEP_2_SWORD")
        self.assertEqual(decision.move, sword_with_rage.move)

    def test_cast_above_480_leaves_320_reserve(self) -> None:
        decision = BasicPolicyEngine().decide(
            combat_state(
                board=no_sword_or_mana_board(),
                mana=481,
                rage=100,
                cards=(attack_card(),),
            )
        )
        self.assertEqual(decision.action, PolicyAction.CAST)
        self.assertTrue(decision.consumes_turn)
        self.assertEqual(decision.card_object_address, attack_card().object_address)

    def test_cast_threshold_is_strictly_greater_than_480(self) -> None:
        decision = BasicPolicyEngine(
            PolicyConfig(mana_priority=ManaPriority.ATTACK)
        ).decide(
            combat_state(
                board=no_sword_or_mana_board(),
                mana=480,
                rage=100,
                cards=(attack_card(),),
            )
        )
        self.assertIsNot(decision.action, PolicyAction.CAST)
        self.assertTrue(
            any(
                "not greater than 480" in reason
                for reason in decision.trace.failed_higher_priority_branches
            )
        )

    def test_only_safe_drain_is_used_even_when_boss_resources_are_low(self) -> None:
        board = no_sword_or_mana_board()
        state = combat_state(board=board, rage=135)
        boss = replace(state.opponents[0], mana=0, power=15)
        state = replace(state, opponents=(boss,), participants=(state.player, boss))
        only_safe_drain = next(
            value
            for value in evaluate_all_moves(board)
            if value.sword_risk.safe
            and value.total.effective(GemType.DRAIN) > 0
            and value.total.effective(GemType.SHIELD) == 0
            and value.total.effective(GemType.RAGE) == 0
            and value.total.effective(GemType.HEALTH) == 0
        )

        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(only_safe_drain,),
        ):
            decision = BasicPolicyEngine().decide(state)

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.move, only_safe_drain.move)
        self.assertEqual(decision.trace.policy_step, "STEP_5_DRAIN_ONLY_SAFE")

    def test_intermediate_boss_resources_choose_safe_shield_over_drain(self) -> None:
        board = no_sword_or_mana_board()
        state = combat_state(board=board, rage=100)
        boss = replace(state.opponents[0], mana=84, power=72)
        state = replace(state, opponents=(boss,), participants=(state.player, boss))
        evaluations = evaluate_all_moves(board)
        shield = next(
            value
            for value in evaluations
            if value.sword_risk.safe
            and value.total.effective(GemType.SHIELD) > 0
        )
        drain = next(
            value
            for value in evaluations
            if value.sword_risk.safe
            and value.total.effective(GemType.DRAIN) > 0
            and value.total.effective(GemType.SHIELD) == 0
        )

        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(drain, shield),
        ):
            decision = BasicPolicyEngine().decide(state)

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.move, shield.move)
        self.assertEqual(
            decision.trace.policy_step,
            "STEP_5_SHIELD_INTERMEDIATE",
        )

    def test_health_only_safe_fallback_prefers_calculable_move(self) -> None:
        state = combat_state(rage=100)
        boss = replace(state.opponents[0], mana=0, power=20)
        state = replace(state, opponents=(boss,), participants=(state.player, boss))
        bases = evaluate_all_moves(state.board)  # type: ignore[arg-type]
        health = ResourceResult(((GemType.HEALTH, ResourceTally(3, 3)),))
        unpredictable = replace(
            bases[0],
            direct=health,
            cascade=ResourceResult(),
            total=health,
            sword_risk=replace(bases[0].sword_risk, safe=True),
            calculable=False,
        )
        calculable = replace(
            bases[1],
            direct=health,
            cascade=ResourceResult(),
            total=health,
            sword_risk=replace(bases[1].sword_risk, safe=True),
            calculable=True,
        )

        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(unpredictable, calculable),
        ):
            decision = BasicPolicyEngine().decide(state)

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.move, calculable.move)
        self.assertEqual(decision.trace.policy_step, "STEP_5_HEALTH_ONLY_SAFE")

    def test_mixed_safe_resource_uses_general_safe_fallback(self) -> None:
        state = combat_state(rage=100)
        boss = replace(state.opponents[0], mana=84, power=72)
        state = replace(state, opponents=(boss,), participants=(state.player, boss))
        bases = evaluate_all_moves(state.board)  # type: ignore[arg-type]
        health = ResourceResult(((GemType.HEALTH, ResourceTally(3, 3)),))
        mixed = ResourceResult(
            (
                (GemType.HEALTH, ResourceTally(3, 3)),
                (GemType.DRAIN, ResourceTally(3, 3)),
            )
        )
        health_only = replace(
            bases[0],
            direct=health,
            cascade=ResourceResult(),
            total=health,
            sword_risk=replace(bases[0].sword_risk, safe=True),
        )
        health_and_drain = replace(
            bases[1],
            direct=mixed,
            cascade=ResourceResult(),
            total=mixed,
            sword_risk=replace(bases[1].sword_risk, safe=True),
        )

        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(health_only, health_and_drain),
        ):
            decision = BasicPolicyEngine().decide(state)

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertIn(decision.move, (health_only.move, health_and_drain.move))
        self.assertEqual(decision.trace.policy_step, "STEP_5_SAFE_FALLBACK")

    def test_safe_rage_above_tactical_threshold_is_used_before_pass(self) -> None:
        state = combat_state(rage=185, mana=105)
        boss = replace(state.opponents[0], mana=0, power=44)
        state = replace(state, opponents=(boss,), participants=(state.player, boss))
        bases = evaluate_all_moves(state.board)  # type: ignore[arg-type]
        rage = ResourceResult(((GemType.RAGE, ResourceTally(3, 3)),))
        candidates = tuple(
            replace(
                base,
                direct=rage,
                cascade=ResourceResult(),
                total=rage,
                sword_risk=replace(base.sword_risk, safe=True),
            )
            for base in bases[:2]
        )

        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=candidates,
        ):
            decision = BasicPolicyEngine().decide(state)

        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertIn(decision.move, tuple(value.move for value in candidates))
        self.assertEqual(decision.trace.policy_step, "STEP_5_SAFE_FALLBACK")

    def test_deadlocked_board_proposes_exit_without_executing(self) -> None:
        decision = BasicPolicyEngine().decide(combat_state(board=cyclic_board()))
        self.assertEqual(decision.action, PolicyAction.EXIT_MATCH)
        self.assertFalse(decision.consumes_turn)
        self.assertEqual(decision.trace.blocker, "EXIT_IS_PROPOSAL_ONLY")

    def test_unknown_game_owned_skip_state_blocks_pass(self) -> None:
        state = combat_state(rage=100)
        candidate = next(
            value
            for value in evaluate_all_moves(state.board)  # type: ignore[arg-type]
            if value.sword_effective == 0
        )
        unsafe = replace(candidate, sword_risk=replace(candidate.sword_risk, safe=False))
        with patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(unsafe,)):
            decision = BasicPolicyEngine().decide(state)
        self.assertEqual(decision.action, PolicyAction.NONE)
        self.assertEqual(decision.trace.blocker, "GAME_OWNED_SKIP_STATE_UNKNOWN")

    def test_game_owned_skip_state_can_allow_pass(self) -> None:
        state = combat_state(rage=100)
        state = replace(
            state,
            battle=replace(
                state.battle,
                consecutive_passes=1,
                consecutive_pass_threshold=3,
                consecutive_pass_source="test.game_owned",
            ),
        )
        candidate = next(
            value
            for value in evaluate_all_moves(state.board)  # type: ignore[arg-type]
            if value.sword_effective == 0
        )
        unsafe = replace(candidate, sword_risk=replace(candidate.sword_risk, safe=False))
        with patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(unsafe,)):
            decision = BasicPolicyEngine().decide(state)
        self.assertEqual(decision.action, PolicyAction.PASS)
        self.assertEqual(decision.trace.policy_step, "STEP_6_PASS")

    def test_non_numeric_confirmed_reset_baseline_allows_pass(self) -> None:
        state = combat_state(rage=100)
        state = replace(
            state,
            battle=replace(
                state.battle,
                consecutive_passes=None,
                consecutive_pass_threshold=None,
                consecutive_pass_source="accepted_consuming_reset_baseline",
                consecutive_pass_status=(
                    GameOwnedIdleStatus.RESET_BASELINE_CONFIRMED
                ),
                consecutive_pass_reset_evidence="swap:turn=3",
                consecutive_pass_confidence=(
                    "reset_confirmed_by_server_sequence"
                ),
            ),
        )
        candidate = next(
            value
            for value in evaluate_all_moves(state.board)  # type: ignore[arg-type]
            if value.sword_effective == 0
        )
        unsafe = replace(candidate, sword_risk=replace(candidate.sword_risk, safe=False))
        with patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(unsafe,)):
            decision = BasicPolicyEngine().decide(state)
        self.assertEqual(decision.action, PolicyAction.PASS)
        self.assertIsNone(decision.trace.skip_count)

    def test_explicit_forbidden_status_forces_mandatory_without_hardcoded_two(self) -> None:
        state = combat_state(rage=100)
        state = replace(
            state,
            battle=replace(
                state.battle,
                consecutive_passes=4,
                consecutive_pass_threshold=5,
                consecutive_pass_source="server.payload",
                consecutive_pass_status=(
                    GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION
                ),
            ),
        )
        candidate = next(
            value
            for value in evaluate_all_moves(state.board)  # type: ignore[arg-type]
            if value.sword_effective == 0
        )
        unsafe = replace(candidate, sword_risk=replace(candidate.sword_risk, safe=False))
        with patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(unsafe,)):
            decision = BasicPolicyEngine().decide(state)
        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.trace.policy_step, "STEP_7_MANDATORY")

    def test_two_game_owned_passes_force_mandatory_swap(self) -> None:
        state = combat_state(rage=100)
        state = replace(
            state,
            battle=replace(
                state.battle,
                consecutive_passes=2,
                consecutive_pass_threshold=3,
                consecutive_pass_source="test.game_owned",
            ),
        )
        candidate = next(
            value
            for value in evaluate_all_moves(state.board)  # type: ignore[arg-type]
            if value.sword_effective == 0
        )
        unsafe = replace(candidate, sword_risk=replace(candidate.sword_risk, safe=False))
        with patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(unsafe,)):
            decision = BasicPolicyEngine().decide(state)
        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.trace.policy_step, "STEP_7_MANDATORY")

    def test_first_turn_comes_from_runtime_turn_number(self) -> None:
        state = combat_state(rage=100, turn=1)
        self.assertTrue(state.battle.first_local_turn)
        self.assertTrue(state.battle.is_first_local_turn)
        later = replace(state, battle=replace(state.battle, turn_number=3))
        self.assertFalse(later.battle.first_local_turn)

    def test_first_runtime_turn_forbids_pass(self) -> None:
        state = combat_state(rage=100, turn=1)
        state = replace(
            state,
            battle=replace(
                state.battle,
                consecutive_passes=1,
                consecutive_pass_threshold=3,
                consecutive_pass_source="test.game_owned",
            ),
        )
        candidate = next(
            value
            for value in evaluate_all_moves(state.board)  # type: ignore[arg-type]
            if value.sword_effective == 0
        )
        unsafe = replace(candidate, sword_risk=replace(candidate.sword_risk, safe=False))
        with patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(unsafe,)):
            decision = BasicPolicyEngine().decide(state)
        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.trace.policy_step, "STEP_7_MANDATORY")

    def test_timer_safety_gate_does_not_invent_deadline_move(self) -> None:
        state = combat_state()
        state = replace(
            state,
            battle=replace(state.battle, turn_time_remaining_seconds=3),
        )
        decision = BasicPolicyEngine().decide(state)
        self.assertEqual(decision.action, PolicyAction.NONE)
        self.assertEqual(decision.trace.blocker, "TURN_TIMER_SAFETY_MARGIN")

    def test_reasoning_is_formalized_but_not_implemented(self) -> None:
        decision = BasicPolicyEngine(
            PolicyConfig(
                play_style=PlayStyle.CAREFUL,
                intelligence=Intelligence.REASONING,
            )
        ).decide(combat_state())
        self.assertEqual(decision.action, PolicyAction.NONE)
        self.assertEqual(decision.trace.blocker, "REASONING_NOT_IMPLEMENTED")


if __name__ == "__main__":
    unittest.main()
