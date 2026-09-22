from __future__ import annotations

from dataclasses import replace
import unittest
from unittest.mock import patch

from pokiguard_v2.basic_policy import BasicPolicyEngine, PolicyAction, PolicyConfig
from pokiguard_v2.board_simulator import (
    ResourceResult,
    ResourceTally,
    evaluate_all_moves,
)
from pokiguard_v2.combat_cards import CardDataState
from pokiguard_v2.gameplay_profile import DamageCardMode, EvolutionTarget, MainPetType
from pokiguard_v2.pet_configuration import GameplayConfig
from pokiguard_v2.pet_skill_shadow import (
    LivePetSkillCard,
    PetSkillCapability,
    PetSkillCapabilityProvider,
    PetSkillCapabilityStatus,
    PetSkillFamily,
)
from pokiguard_v2.state import (
    BoardState,
    CellState,
    CombatSessionKey,
    GameOwnedIdleStatus,
    GemType,
)
from tests.test_basic_policy import attack_card, combat_state


SESSION = CombatSessionKey(7, 0x20000000000, "M_PHASE3C1")


def skill_policy() -> BasicPolicyEngine:
    return BasicPolicyEngine(
        PolicyConfig(
            mana_priority=None,
            main_pet=MainPetType.LEGENDARY,
            evolution=EvolutionTarget.NONE,
            damage_card=DamageCardMode.PET_SKILL,
        )
    )


def session_state(*, mana: int, rage: int, boss_hp: int = 84_180):
    state = combat_state(
        mana=mana,
        rage=rage,
        fusion_used=False,
        fusion_available=False,
        cards=(attack_card(),),
        turn=7,
        boss_hp=boss_hp,
    )
    return replace(
        state,
        battle=replace(
            state.battle,
            session_key=SESSION,
            match_id=SESSION.match_id,
        ),
    )


def card_data(
    *,
    element: str = "ATTACK_LEGEND_",
    mana_cost: int = 200,
    rage_cost: int = 200,
    card_id: int = 120,
) -> CardDataState:
    return CardDataState(
        address=0x21000000000,
        data_id=77120,
        card_id=card_id,
        name="Huyền Thoại",
        description="Pet Skill",
        element_type=element,
        skill_type="DOT_QTE",
        value=0,
        max_level=1,
        count=1,
        level=1,
        condition_use=mana_cost,
        power=rage_cost,
        green=0,
        blue=0,
        red=0,
        yellow=0,
        white=0,
        purple=0,
        damage_multiplier=1.0,
        mana_cost=0,
        power_cost=0,
        cooldown_turns=0,
        need_perfection=True,
        eat_perfect=7,
        eat_good=5,
        eat_bad=3,
    )


def capability(
    *,
    element: str = "ATTACK_LEGEND_",
    mana_cost: int = 200,
    rage_cost: int = 200,
    card_id: int = 120,
) -> PetSkillCapability:
    card = card_data(
        element=element,
        mana_cost=mana_cost,
        rage_cost=rage_cost,
        card_id=card_id,
    )
    return PetSkillCapabilityProvider().observe(
        observed_at=1.0,
        current_session=SESSION,
        source_pet=None,
        candidates=(
            LivePetSkillCard(
                session_key=SESSION,
                card_data=card,
                card_ui_address=0x22000000000,
                board_instance=SESSION.board_instance,
                active_instance=0x23000000000,
                button_address=0x24000000000,
                button_interactable=True,
                button_validated=True,
                source="CARD_UI_BUTTON",
            ),
        ),
    )


def no_sword_board(state) -> BoardState:
    return BoardState(
        tuple(
            tuple(
                CellState(
                    cell.row,
                    cell.col,
                    GemType.HEALTH if cell.gem is GemType.SWORD else cell.gem,
                    cell.multiplier,
                )
                for cell in row
            )
            for row in state.board.cells
        )
    )


def without_skill_resources(state) -> BoardState:
    replacements = {
        GemType.SWORD: GemType.HEALTH,
        GemType.MANA: GemType.HEALTH,
        GemType.RAGE: GemType.HEALTH,
    }
    return BoardState(
        tuple(
            tuple(
                CellState(
                    cell.row,
                    cell.col,
                    replacements.get(cell.gem, cell.gem),
                    cell.multiplier,
                )
                for cell in row
            )
            for row in state.board.cells
        )
    )


class Phase3c1PetSkillPolicyTests(unittest.TestCase):
    def test_affordable_evolution_precedes_ready_main_pet_skill(self) -> None:
        engine = BasicPolicyEngine(
            PolicyConfig(
                mana_priority=None,
                main_pet=MainPetType.LEGENDARY,
                evolution=EvolutionTarget.NORMAL,
                damage_card=DamageCardMode.PET_SKILL,
            )
        )
        state = session_state(mana=250, rage=250)
        state = replace(
            state,
            fusion=replace(
                state.fusion,
                available=True,
                used=False,
                mana_cost=120,
            ),
        )

        decision = engine.decide(state, pet_skill_capability=capability())

        self.assertEqual(decision.action, PolicyAction.EVOLVE)
        self.assertEqual(decision.trace.policy_step, "STEP_1_EVOLVE")
        self.assertTrue(decision.requires_state_reread)

    def test_legendary_evolution_skill_waits_for_fusion_then_keeps_skill_rule(self) -> None:
        engine = BasicPolicyEngine(
            PolicyConfig(
                mana_priority=None,
                main_pet=MainPetType.NORMAL,
                evolution=EvolutionTarget.LEGENDARY,
                damage_card=DamageCardMode.PET_SKILL,
            )
        )
        before = session_state(mana=0, rage=0)
        before = replace(before, board=no_sword_board(before))
        before_decision = engine.decide(before, pet_skill_capability=None)
        self.assertEqual(before_decision.action, PolicyAction.SWAP)
        self.assertEqual(
            before_decision.trace.required_mana,
            before.fusion.mana_cost,
        )
        self.assertEqual(before_decision.trace.missing_mana, before.fusion.mana_cost)
        self.assertEqual(before_decision.trace.required_rage, 0)
        self.assertEqual(before_decision.trace.missing_rage, 0)
        self.assertTrue(
            any(
                "accumulate resources and evolve" in reason
                for reason in before_decision.trace.failed_higher_priority_branches
            )
        )

        after = session_state(mana=250, rage=250)
        after = replace(
            after,
            fusion=replace(after.fusion, used=True, available=False),
        )
        after_decision = engine.decide(
            after,
            pet_skill_capability=capability(),
        )
        self.assertEqual(after_decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(after_decision.trace.policy_step, "STEP_1_PET_SKILL")

    def test_live_resource_telemetry_uses_policy_decision_identity(self) -> None:
        from tools.basic_auto_bot import _pet_skill_resource_progress_fields

        state = session_state(mana=210, rage=70)
        state = replace(state, board=no_sword_board(state))
        decision = skill_policy().decide(
            state,
            pet_skill_capability=capability(),
        )

        self.assertEqual(decision.trace.policy_step, "STEP_3_PET_SKILL_RESOURCE")
        self.assertEqual(
            _pet_skill_resource_progress_fields(decision)["skillCardId"],
            120,
        )

    def test_exact_profile_is_enabled_after_audition_v3_integration(self) -> None:
        config = GameplayConfig(
            main_pet=MainPetType.LEGENDARY,
            evolution=EvolutionTarget.NONE,
            damage_card=DamageCardMode.PET_SKILL,
        )
        self.assertTrue(config.capability.farm_policy_supported)
        self.assertIsNone(config.capability.blocker_reason)
        self.assertEqual(config.capability.skill_source_count, 1)

    def test_ready_boundaries_propose_distinct_consuming_action(self) -> None:
        engine = skill_policy()
        current = capability()
        for mana, rage, ready in (
            (200, 200, True),
            (199, 200, False),
            (200, 199, False),
            (250, 250, True),
        ):
            with self.subTest(mana=mana, rage=rage):
                decision = engine.decide(
                    session_state(mana=mana, rage=rage),
                    pet_skill_capability=current,
                )
                self.assertEqual(
                    decision.action is PolicyAction.PET_SKILL,
                    ready,
                )
                if ready:
                    self.assertTrue(decision.consumes_turn)
                    self.assertEqual(decision.skill_card_id, 120)
                    self.assertEqual(decision.skill_session_key, SESSION)

    def test_no_evolve_or_default_cast_even_at_low_boss_hp(self) -> None:
        cases = (
            (1000, 199, 1, False),
            (0, 0, 84_180, False),
            (250, 250, 1, True),
        )
        for mana, rage, boss_hp, mandatory in cases:
            with self.subTest(
                mana=mana,
                rage=rage,
                boss_hp=boss_hp,
                mandatory=mandatory,
            ):
                state = session_state(mana=mana, rage=rage, boss_hp=boss_hp)
                state = replace(
                    state,
                    board=no_sword_board(state),
                    battle=replace(
                        state.battle,
                        consecutive_pass_status=(
                            GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION
                            if mandatory
                            else GameOwnedIdleStatus.UNKNOWN
                        ),
                    ),
                )
                decision = skill_policy().decide(
                    state,
                    pet_skill_capability=capability(),
                )
                self.assertNotIn(
                    decision.action,
                    {PolicyAction.EVOLVE, PolicyAction.CAST},
                )
                self.assertIn("PET_SKILL", decision.trace.policy_step)

    def test_only_current_deficit_receives_readiness_credit(self) -> None:
        state = session_state(mana=210, rage=70)
        state = replace(state, board=no_sword_board(state))
        decision = skill_policy().decide(
            state,
            pet_skill_capability=capability(),
        )
        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.trace.policy_step, "STEP_3_PET_SKILL_RESOURCE")
        self.assertEqual(decision.trace.missing_mana, 0)
        self.assertEqual(decision.trace.missing_rage, 130)
        assert decision.trace.selected_candidate is not None
        selected = decision.trace.selected_candidate
        self.assertEqual(selected.known_mana_gain >= 0, True)
        self.assertGreater(selected.known_rage_gain, 0)
        self.assertGreater(selected.readiness_progress, 0.0)

        mana_state = session_state(mana=70, rage=210)
        base = evaluate_all_moves(mana_state.board)[0]
        mana_gain = ResourceResult(((GemType.MANA, ResourceTally(4, 4)),))
        mana_candidate = replace(
            base,
            direct=mana_gain,
            cascade=ResourceResult(),
            total=mana_gain,
            sword_risk=replace(base.sword_risk, safe=True),
        )
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(mana_candidate,),
        ):
            mana_decision = skill_policy().decide(
                mana_state,
                pet_skill_capability=capability(),
            )
        assert mana_decision.trace.selected_candidate is not None
        self.assertGreater(
            mana_decision.trace.selected_candidate.known_mana_gain,
            0,
        )
        self.assertEqual(mana_decision.trace.missing_rage, 0)

    def test_both_deficits_prefer_candidate_completing_both(self) -> None:
        state = session_state(mana=195, rage=195)
        bases = evaluate_all_moves(state.board)[:3]

        def candidate(index: int, mana: int, rage: int):
            result = ResourceResult(
                tuple(
                    (gem, ResourceTally(value, value))
                    for gem, value in (
                        (GemType.MANA, mana),
                        (GemType.RAGE, rage),
                    )
                    if value
                )
            )
            return replace(
                bases[index],
                direct=result,
                cascade=ResourceResult(),
                total=result,
                sword_risk=replace(bases[index].sword_risk, safe=True),
            )

        mana_only = candidate(0, 8, 0)
        rage_only = candidate(1, 0, 8)
        both = candidate(2, 5, 5)
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(mana_only, rage_only, both),
        ):
            decision = skill_policy().decide(
                state,
                pet_skill_capability=capability(),
            )
        self.assertEqual(decision.move, both.move)
        assert decision.trace.selected_candidate is not None
        self.assertEqual(
            decision.trace.selected_candidate.requirements_completed_after_move,
            2,
        )

    def test_unknown_refill_gets_no_readiness_credit(self) -> None:
        state = session_state(mana=190, rage=200)
        bases = evaluate_all_moves(state.board)[:2]
        known = ResourceResult(((GemType.MANA, ResourceTally(3, 3)),))
        known_candidate = replace(
            bases[0],
            direct=known,
            cascade=ResourceResult(),
            total=known,
            sword_risk=replace(bases[0].sword_risk, safe=True),
        )
        unknown_candidate = replace(
            bases[1],
            direct=ResourceResult(),
            cascade=ResourceResult(),
            total=ResourceResult(),
            calculable=False,
            sword_risk=replace(bases[1].sword_risk, safe=True),
        )
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(unknown_candidate, known_candidate),
        ):
            decision = skill_policy().decide(
                state,
                pet_skill_capability=capability(),
            )
        self.assertEqual(decision.move, known_candidate.move)
        self.assertNotIn(
            unknown_candidate.move,
            tuple(item.move for item in decision.trace.candidates),
        )

    def test_missing_ambiguous_stale_and_unsupported_fail_closed(self) -> None:
        state = session_state(mana=250, rage=250)
        current = capability()
        cases = (
            (None, "PET_SKILL_CAPABILITY_UNAVAILABLE"),
            (
                replace(current, status=PetSkillCapabilityStatus.AMBIGUOUS),
                "PET_SKILL_CAPABILITY_AMBIGUOUS",
            ),
            (
                replace(current, status=PetSkillCapabilityStatus.STALE),
                "PET_SKILL_CAPABILITY_UNAVAILABLE",
            ),
            (
                replace(current, skill_family=PetSkillFamily.DOT_QTE_OTHER),
                "PET_SKILL_FAMILY_UNSUPPORTED",
            ),
        )
        for observed, blocker in cases:
            with self.subTest(blocker=blocker):
                decision = skill_policy().decide(
                    state,
                    pet_skill_capability=observed,
                )
                self.assertEqual(decision.action, PolicyAction.NONE)
                self.assertEqual(decision.trace.blocker, blocker)

    def test_ht2_cost_fixture_remains_200_150_but_family_is_blocked(self) -> None:
        ht2 = capability(
            element="ATTACK_LEGEND",
            mana_cost=200,
            rage_cost=150,
            card_id=22,
        )
        self.assertEqual(ht2.effective_mana_cost, 200)
        self.assertEqual(ht2.effective_power_cost, 150)
        decision = skill_policy().decide(
            session_state(mana=250, rage=250),
            pet_skill_capability=ht2,
        )
        self.assertEqual(decision.trace.blocker, "PET_SKILL_FAMILY_UNSUPPORTED")

    def test_sword_stays_highest_board_objective_and_unsafe_resource_is_rejected(self) -> None:
        state = session_state(mana=0, rage=0)
        evaluations = evaluate_all_moves(state.board)
        sword = next(value for value in evaluations if value.sword_effective > 0)
        unsafe_resource = next(
            value for value in evaluations if value.move != sword.move
        )
        mana = ResourceResult(((GemType.MANA, ResourceTally(4, 4)),))
        unsafe_resource = replace(
            unsafe_resource,
            direct=mana,
            cascade=ResourceResult(),
            total=mana,
            sword_risk=replace(unsafe_resource.sword_risk, safe=False),
        )
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(unsafe_resource, sword),
        ):
            decision = skill_policy().decide(
                state,
                pet_skill_capability=capability(),
            )
        self.assertEqual(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.trace.policy_step, "STEP_2_SWORD")
        self.assertEqual(decision.move, sword.move)

    def test_health_drain_and_shield_branches_remain_reachable(self) -> None:
        state = session_state(mana=199, rage=199)
        state = replace(state, board=without_skill_resources(state))
        low_player = replace(state.player, hp=10_000)
        low_boss_resources = replace(state.opponents[0], mana=0, power=10)
        health_state = replace(
            state,
            player=low_player,
            opponents=(low_boss_resources,),
            participants=(low_player, low_boss_resources),
        )
        health = skill_policy().decide(
            health_state,
            pet_skill_capability=capability(),
        )
        self.assertEqual(health.trace.policy_step, "STEP_4_HEALTH")

        high_boss_resources = replace(state.opponents[0], mana=200, power=150)
        drain_state = replace(
            state,
            opponents=(high_boss_resources,),
            participants=(state.player, high_boss_resources),
        )
        drain = skill_policy().decide(
            drain_state,
            pet_skill_capability=capability(),
        )
        self.assertEqual(drain.trace.policy_step, "STEP_5_DRAIN")

        shield_state = replace(
            state,
            opponents=(low_boss_resources,),
            participants=(state.player, low_boss_resources),
        )
        shield = skill_policy().decide(
            shield_state,
            pet_skill_capability=capability(),
        )
        self.assertEqual(shield.trace.policy_step, "STEP_5_SHIELD")

    def test_pass_and_mandatory_consuming_action_keep_canonical_rules(self) -> None:
        state = session_state(mana=199, rage=199)
        candidate = next(
            value
            for value in evaluate_all_moves(state.board)
            if value.sword_effective == 0
        )
        unsafe = replace(
            candidate,
            direct=replace(candidate.direct, values=()),
            cascade=replace(candidate.cascade, values=()),
            total=replace(candidate.total, values=()),
            sword_risk=replace(candidate.sword_risk, safe=False),
        )
        allowed = replace(
            state,
            battle=replace(
                state.battle,
                consecutive_pass_status=GameOwnedIdleStatus.PASS_ALLOWED,
            ),
        )
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(unsafe,),
        ):
            passed = skill_policy().decide(
                allowed,
                pet_skill_capability=capability(),
            )
        self.assertEqual(passed.action, PolicyAction.PASS)

        mandatory = replace(
            allowed,
            battle=replace(
                allowed.battle,
                consecutive_pass_status=(
                    GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION
                ),
            ),
        )
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(unsafe,),
        ):
            forced = skill_policy().decide(
                mandatory,
                pet_skill_capability=capability(),
            )
        self.assertEqual(forced.action, PolicyAction.SWAP)
        self.assertEqual(forced.trace.policy_step, "STEP_7_MANDATORY")
        self.assertTrue(forced.consumes_turn)

        first = replace(
            allowed,
            battle=replace(allowed.battle, turn_number=1),
        )
        with patch(
            "pokiguard_v2.basic_policy.evaluate_all_moves",
            return_value=(unsafe,),
        ):
            first_decision = skill_policy().decide(
                first,
                pet_skill_capability=capability(),
            )
        self.assertNotEqual(first_decision.action, PolicyAction.PASS)


if __name__ == "__main__":
    unittest.main()
