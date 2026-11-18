from dataclasses import replace
from pathlib import Path
import tempfile
from types import SimpleNamespace
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.basic_policy import BasicPolicyEngine, PlayStyle, PolicyAction
from pokiguard_v2.board_simulator import evaluate_all_moves
from pokiguard_v2.gameplay_profile import AuditionMode, EvolutionTarget, MainPetType, MegaSelfProtection
from pokiguard_v2.pet_configuration import GameplayConfig, basic_policy_config, gameplay_config_from_args
from pokiguard_v2.pet_skill_action import PetSkillActionResultKind
from pokiguard_v2.pet_skill_shadow import PetSkillFamily, current_mega_seal
from pokiguard_v2.reasoning_common_evidence import packet
from pokiguard_v2.reasoning_common_selection import (CommonSelectionBridge, apply_common_action,
    galaxy_strategy_allows)
from pokiguard_v2.reasoning_snapshot import Action
from tests.reasoning_controller_fixture import controller_trace
from tests.test_mega_icarus_click_only import click_only_executor, observation, post_state
from tests.test_mega_icarus_policy import health_candidate, mega_policy
from tests.test_phase3c1_pet_skill_policy import capability, session_state
from tests.test_phase3c3_skill_rush_policy import candidate, with_player_hp
from tests.test_reasoning_common_evidence import build
from tools import basic_auto_bot as bot, pet_skill_action as skill_tool
from tools.farm_run import build_parser


def galaxy_config(main_pet="galaxy", evolution="none"):
    return GameplayConfig.from_dict(dict(play_style="galaxy", main_pet=main_pet,
        evolution=evolution, damage_card="pet_skill"))


class GalaxyTests(unittest.TestCase):
    def test_cli_defaults_and_loadout_round_trip(self):
        args = build_parser().parse_args(["--stage-b2-farm", "--play-style", "galaxy", "--main-pet", "normal",
                                         "--evolution-target", "galaxy", "--damage-card", "pet_skill"])
        config = gameplay_config_from_args(args)
        self.assertIs(config.main_pet, MainPetType.NORMAL)
        self.assertIs(config.evolution, EvolutionTarget.GALAXY)
        self.assertIs(config.audition_mode, AuditionMode.NO_ACTION)
        self.assertIsNone(config.pet_skill_fire_value)
        self.assertEqual(config, GameplayConfig.from_dict(config.to_dict()))
        self.assertTrue(basic_policy_config(config).pet_skill_waits_for_evolution)
        with self.assertRaisesRegex(ValueError, "GALAXY_LOADOUT_INVALID"):
            galaxy_config("galaxy", "galaxy")
        with self.assertRaisesRegex(ValueError, "GALAXY_REQUIRES_RESOURCE_READY"):
            GameplayConfig.from_dict(dict(config.to_dict(), pet_skill_fire_condition="sword_count",
                                          pet_skill_fire_value=4))

    def test_current_galaxy_click_only_card_has_no_seal(self):
        policy = BasicPolicyEngine(basic_policy_config(galaxy_config()))
        state = session_state(mana=200, rage=150)
        for element in ("GALAXY_2", "GALAXY_RICKY", "GALAXY_CHESS_MASTER", "GALAXY_DRAGON_KNIGHT"):
            with self.subTest(element=element):
                cap = capability(element=element, mana_cost=200, rage_cost=150)
                self.assertIs(cap.skill_family, PetSkillFamily.GALAXY_CLICK_ONLY)
                self.assertIsNone(current_mega_seal(cap, state.battle.session_key))
                with patch("pokiguard_v2.basic_policy.evaluate_all_moves", side_effect=AssertionError):
                    decision = policy.decide(state, pet_skill_capability=cap)
                self.assertIs(decision.action, PolicyAction.PET_SKILL)
                self.assertEqual(decision.trace.fire_condition_scope, "RESOURCE_ONLY")
                self.assertIsNone(decision.trace.selected_fire_gem_type)

    def test_galaxy_checks_both_costs_and_current_live_card(self):
        cap = capability(element="GALAXY_RICKY", mana_cost=200, rage_cost=150)
        policy = BasicPolicyEngine(basic_policy_config(galaxy_config()))
        for mana, rage, card in (
            (199, 150, cap), (200, 149, cap),
            (200, 150, replace(cap, live_card_actionable=False)),
            (200, 150, replace(cap, ownership_current=False)),
            (200, 150, capability(element="MEGA_TREX")),
            (200, 150, None),
        ):
            decision = policy.decide(session_state(mana=mana, rage=rage), pet_skill_capability=card)
            self.assertIs(decision.action, PolicyAction.SWAP)
        self.assertIs(policy.decide(session_state(mana=200, rage=0), pet_skill_capability=
            capability(element="GALAXY_RICKY", mana_cost=200, rage_cost=0)).action, PolicyAction.PET_SKILL)

    def test_galaxy_evolution_is_prioritized_before_skill(self):
        state = session_state(mana=250, rage=250)
        cap = capability(element="GALAXY_RICKY")
        policy = BasicPolicyEngine(basic_policy_config(galaxy_config("normal", "galaxy")))
        self.assertIsNot(policy.decide(state, pet_skill_capability=cap).action, PolicyAction.PET_SKILL)
        ready = replace(state, fusion=replace(state.fusion, available=True, used=False, mana_cost=120))
        self.assertIs(policy.decide(ready, pet_skill_capability=cap).action, PolicyAction.EVOLVE)
        evolved = replace(state, fusion=replace(state.fusion, used=True))
        self.assertIs(policy.decide(evolved, pet_skill_capability=cap).action, PolicyAction.PET_SKILL)

    def test_galaxy_charges_on_safe_move_and_denies_sword_at_critical_hp(self):
        state = session_state(mana=200, rage=120)
        cap = capability(element="GALAXY_RICKY", mana_cost=200, rage_cost=150)
        policy = BasicPolicyEngine(basic_policy_config(galaxy_config()))
        moves = evaluate_all_moves(state.board)
        sword = candidate(moves[0], sword=6)
        recharge = candidate(moves[1], rage=3)
        with patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(sword, recharge)):
            decision = policy.decide(state, pet_skill_capability=cap)
            survival = policy.decide(with_player_hp(state, hp=20), pet_skill_capability=cap)
        self.assertEqual(decision.trace.policy_step, "GALAXY_RESOURCE_PROGRESS")
        self.assertEqual(decision.move, recharge.move)
        self.assertEqual(survival.trace.policy_step, "GALAXY_SURVIVAL_SWORD")
        self.assertEqual(survival.move, sword.move)

    def test_galaxy_action_confirms_without_a_board_change(self):
        action, mouse, backend, directions = click_only_executor(galaxy_card=True)
        after = post_state()
        after.battle.turn_number = 11
        before = observation(0.0, seal_type="GALAXY_2", board_dedup_key=after.dedup_key)
        action.begin(before, monotonic_now=0.0)
        action.step(replace(before, sampled_monotonic=0.05), monotonic_now=0.05)
        action.step(replace(before, sampled_monotonic=0.1, post_state=after, post_state_fresh=True), monotonic_now=0.1)
        self.assertIs(action.result.kind, PetSkillActionResultKind.SUCCESS_NO_ACTION)
        self.assertEqual(len(mouse.points), 1)
        self.assertEqual(backend.keys, [])
        directions.arm.assert_not_called()

    def test_resource_stage_matches_mega_without_consuming_sword(self):
        from pokiguard_v2.gameplay_profile import PetSkillFireCondition
        galaxy = BasicPolicyEngine(basic_policy_config(galaxy_config()))
        mega = mega_policy(condition=PetSkillFireCondition.SKILL_COST_READY)
        state = session_state(mana=100, rage=100)
        bases = evaluate_all_moves(state.board)
        for moves in (
            (candidate(bases[0], sword=6), candidate(bases[1], mana=4, direct_replies=1)),
            (candidate(bases[0], sword=3, rage=5), candidate(bases[1], mana=3)),
            (candidate(bases[0], drain=3), candidate(bases[1], rage=4, direct_replies=1)),
            (candidate(bases[0], drain=3), candidate(bases[1], shield=3)),
        ):
            with self.subTest(moves=moves), patch(
                "pokiguard_v2.basic_policy.evaluate_all_moves", return_value=moves,
            ):
                g = galaxy.decide(state, pet_skill_capability=capability(
                    element="GALAXY_DRAGON_KNIGHT", mana_cost=200, rage_cost=200))
                m = mega.decide(state, pet_skill_capability=capability(
                    element="MEGA_TREX", mana_cost=200, rage_cost=200))
            self.assertEqual(g.action, m.action)
            self.assertEqual(g.move, m.move)
            self.assertEqual(g.trace.policy_step, m.trace.policy_step.replace("MEGA_ICARUS", "GALAXY"))
            self.assertEqual(g.trace.selected_candidate.known_sword_consumed, 0)

    def test_galaxy_protection_respects_none_ten_and_thirty_percent(self):
        bases = evaluate_all_moves(session_state(mana=100, rage=200).board)
        mana, health = candidate(bases[0], mana=5), health_candidate(bases[1])
        cap = capability(element="GALAXY_DRAGON_KNIGHT", mana_cost=200, rage_cost=200)
        for mode, hp, defend in (
            (MegaSelfProtection.HP_BELOW_30, 30, True),
            (MegaSelfProtection.HP_BELOW_30, 31, False),
            (MegaSelfProtection.HP_BELOW_10, 10, True),
            (MegaSelfProtection.HP_BELOW_10, 11, False),
            (MegaSelfProtection.HP_BELOW_10, 20, False),
            (MegaSelfProtection.NONE, 1, False),
        ):
            config = replace(galaxy_config(), mega_self_protection=mode)
            policy = BasicPolicyEngine(basic_policy_config(config))
            with self.subTest(mode=mode, hp=hp), patch(
                "pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(mana, health),
            ):
                result = policy.decide(with_player_hp(session_state(mana=100, rage=200), hp=hp),
                                       pet_skill_capability=cap)
            self.assertEqual(result.move, health.move if defend else mana.move)
            self.assertEqual(result.trace.policy_step.startswith("GALAXY_SURVIVAL"), defend)

    def test_ready_galaxy_fires_even_at_critical_hp_without_board_evaluation(self):
        cap = capability(element="GALAXY_DRAGON_KNIGHT", mana_cost=200, rage_cost=200)
        for mode in MegaSelfProtection:
            policy = BasicPolicyEngine(basic_policy_config(replace(galaxy_config(), mega_self_protection=mode)))
            with self.subTest(mode=mode), patch(
                "pokiguard_v2.basic_policy.evaluate_all_moves", side_effect=AssertionError,
            ):
                result = policy.decide(with_player_hp(session_state(mana=200, rage=200), hp=1),
                                       pet_skill_capability=cap)
            self.assertIs(result.action, PolicyAction.PET_SKILL)
            self.assertEqual(result.trace.policy_step, "GALAXY_FIRE")

    def test_unavailable_card_keeps_resource_strategy_and_unknown_costs(self):
        state = session_state(mana=230, rage=250)
        bases = evaluate_all_moves(state.board)
        sword, mana = candidate(bases[0], sword=6), candidate(bases[1], mana=4)
        policy = BasicPolicyEngine(basic_policy_config(galaxy_config()))
        with patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(sword, mana)):
            result = policy.decide(state, pet_skill_capability=None)
        self.assertEqual(result.trace.policy_step, "GALAXY_RESOURCE_PROGRESS")
        self.assertEqual(result.move, mana.move)
        self.assertIsNone(result.trace.required_mana)
        self.assertIsNone(result.trace.required_rage)
        self.assertIsNone(result.trace.skill_ready)

    def test_reasoning_keeps_skill_resource_and_protection_priorities(self):
        config = basic_policy_config(galaxy_config())
        state = session_state(mana=100, rage=100)
        cap = capability(element="GALAXY_DRAGON_KNIGHT", mana_cost=200, rage_cost=200)
        moves = evaluate_all_moves(state.board)
        values = (candidate(moves[0], sword=6), candidate(moves[1], mana=3),
                  candidate(moves[2], rage=3), health_candidate(moves[3]),
                  candidate(moves[4], mana=4, direct_replies=1))
        with patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=values):
            baseline = BasicPolicyEngine(config).decide(state, pet_skill_capability=cap)
        context = packet(state, config, baseline, cap, None, True)
        for index, allowed in ((0, False), (1, True), (2, True), (3, False), (4, False)):
            action = Action('swap', values[index].move)
            proposed = apply_common_action(baseline, action, state, context, baseline.trace.candidates[index])
            with self.subTest(index=index):
                self.assertEqual(galaxy_strategy_allows(config, baseline, proposed), allowed)
                bridge = CommonSelectionBridge.__new__(CommonSelectionBridge)
                bridge.completed = SimpleNamespace(reply=SimpleNamespace(proposal=action),
                    candidate_trace=baseline.trace.candidates[index])
                bridge.action_context = context
                bridge._reason = Mock(return_value='VALID_COMPLETED_COMMON')
                bridge._record = Mock(return_value=True)
                selected = bridge.select(state, baseline, config, now_ns=1, input_allowed=True, context='FAKE')
                self.assertEqual(selected.receipt is not None, allowed)
                if not allowed:
                    self.assertIs(selected.decision, baseline)
        with patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=values):
            survival = BasicPolicyEngine(config).decide(with_player_hp(state, hp=20), pet_skill_capability=cap)
        self.assertFalse(galaxy_strategy_allows(config, survival, proposed))
        ready = BasicPolicyEngine(config).decide(session_state(mana=200, rage=200), pet_skill_capability=cap)
        self.assertFalse(galaxy_strategy_allows(config, ready, proposed))

    def test_geometry_timeout_uses_fresh_board_once_without_retrying_skill(self):
        config = galaxy_config()
        state = session_state(mana=400, rage=250)
        construct_runtime = bot.SharedCombatRuntime
        permit_calls = []

        def runtime(*args, **kwargs):
            capability = SimpleNamespace(
                reserve=lambda **event: permit_calls.append(event['action']) or object(),
                abandon_gameplay_preflight=lambda *_, **__: True,
                complete=lambda *_, **__: True,
            )
            return replace(construct_runtime(*args, **kwargs), gameplay_capability=capability)

        def skill(provider, current, resolver):
            return replace(capability(element="GALAXY_RICKY"), session_key=current.battle.session_key)

        skipped = SimpleNamespace(result=None, summary=None, no_action_geometry_skipped=True)
        with tempfile.TemporaryDirectory() as folder, \
             patch.object(bot, 'SharedCombatRuntime', side_effect=runtime), \
             patch.object(bot, '_current_pet_skill_capability', side_effect=skill), \
             patch.object(skill_tool, 'run_embedded_policy_action', return_value=skipped) as dispatch:
            _, native, rows = controller_trace(
                Path(folder) / 'combat.jsonl', profile=config.play_style.value,
                initial_combat=state, gameplay_config=config, case='pet_skill_geometry_fallback',
            )
        dispatch.assert_called_once()
        self.assertEqual(dispatch.call_args.kwargs['expected_source_turn'], 14)
        self.assertEqual(permit_calls, ['pet_skill', 'swap'])
        self.assertEqual(native.count('FAKE_NORMAL_INPUT'), 1)
        self.assertEqual(native.count('executor.ack'), 1)
        self.assertEqual(sum(row['event'] == 'pet_skill_geometry_board_fallback' for row in rows), 1)

    def test_galaxy_preflight_rejects_mega_and_card_type_changes(self):
        action, mouse, _, _ = click_only_executor(galaxy_card=True)
        action.begin(observation(0.0, seal_type="GALAXY_2"), monotonic_now=0.0)
        action.step(observation(0.05, seal_type="GALAXY_RICKY"), monotonic_now=0.05)
        self.assertEqual(action.result.reason, "FINAL_CARD_GALAXY_CARD_TYPE_CHANGED")
        self.assertEqual(mouse.points, [])
        action, mouse, _, _ = click_only_executor(galaxy_card=True)
        action.begin(observation(0.0), monotonic_now=0.0)
        self.assertEqual(action.result.reason, "CURRENT_GALAXY_CARD_UNVERIFIED")
        self.assertEqual(mouse.points, [])

    def test_reasoning_uses_costs_without_claiming_skill_damage(self):
        config = basic_policy_config(galaxy_config())
        cap = capability(element="GALAXY_2", mana_cost=200, rage_cost=150)
        state = session_state(mana=190, rage=150)
        decision = BasicPolicyEngine(config).decide(state, pet_skill_capability=cap)
        problem = build(packet(state, config, decision, cap, None, True))
        self.assertEqual(problem.intent.profile, PlayStyle.GALAXY.value)
        self.assertEqual(problem.facts.plain()['resource_requirements'], {'mana': 200, 'rage': 150})
        skill = next(effect for effect in problem.effects if effect.action.family == 'pet_skill')
        self.assertFalse(skill.eligible)
        self.assertIsNone(skill.cleared)
        self.assertNotIn('mega_seal_type', problem.facts.plain())
