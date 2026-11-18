"""Pet identity, G1 random/fourth cast and G3 resource-cycle reasoning."""
from dataclasses import replace
import json
from pathlib import Path
import tempfile
from types import SimpleNamespace
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.basic_policy import BasicPolicyEngine, PolicyAction, SkillRushMatchContext
from pokiguard_v2.board_simulator import evaluate_all_moves
from pokiguard_v2.galaxy_profiles import current_profile
from pokiguard_v2.gameplay_profile import MegaSelfProtection
from pokiguard_v2.pet_configuration import basic_policy_config
from pokiguard_v2.reasoning_common_evidence import packet_hash, packet
from tests.test_galaxy import galaxy_config
from tests.test_galaxy_glank import facts, recorded
from tests.test_mega_icarus_policy import health_candidate
from tests.test_phase3c1_pet_skill_policy import capability, session_state
from tests.test_phase3c3_skill_rush_policy import candidate, with_player_hp


SOURCE = "MatchService.Players.local.skillPhaseNext/Max/CardId"


def cap(element="GALAXY_DRAGON_KNIGHT", phase=None, maximum=None):
    return replace(capability(element=element, mana_cost=200, rage_cost=200),
        skill_phase_next=phase, skill_phase_max=maximum,
        skill_phase_source=SOURCE if phase is not None else None)


def policy(*, enabled=True, protection=MegaSelfProtection.NONE):
    return BasicPolicyEngine(basic_policy_config(replace(galaxy_config(), mega_self_protection=protection)),
                             galaxy_reasoning=enabled)


def state(mana=150, rage=150, turn=9):
    s = session_state(mana=mana, rage=rage)
    own = replace(s.player, max_mana=1000, max_power=250)
    return replace(s, player=own, participants=(own, s.opponents[0]),
                   battle=replace(s.battle, turn_number=turn))


def history(s, count=0, last=None):
    return SkillRushMatchContext(s.battle.session_key, count, last)


class GalaxyIdentityTests(unittest.TestCase):
    def test_live_card_identity_selects_each_pet_without_equipped_pet_metadata(self):
        s = state()
        for element, alias in (("GALAXY_RICKY", "G1"), ("GALAXY_2", "G2"), ("GALAXY_DRAGON_KNIGHT", "G3")):
            with self.subTest(alias=alias):
                c = cap(element)
                self.assertIsNone(c.pet_id)
                self.assertEqual(current_profile(c, s.battle.session_key).alias, alias)
        self.assertIsNone(current_profile(cap("GALAXY_CHESS_MASTER"), s.battle.session_key))
        self.assertIsNone(current_profile(cap("MEGA_TREX"), s.battle.session_key))

    def test_wrong_source_or_conflicting_card_never_claims_a_pet(self):
        s = state()
        good = cap()
        for bad in (replace(good, ownership_current=False), replace(good, card_id=999),
                    replace(good, source="PetUserDTO.cardDTO"), replace(good, live_card_present=False),
                    replace(good, session_key=replace(good.session_key, lifecycle_epoch=44))):
            with self.subTest(bad=bad):
                self.assertIsNone(current_profile(bad, s.battle.session_key))

    def test_full_recorded_descriptions_confirm_the_modeled_effects(self):
        records = json.loads((Path(__file__).parent / "fixtures/galaxy_profiles_20261116/descriptions.json").read_text(encoding="utf-8"))
        g1, g3 = records
        for text in ("500 Mana", "200 Nộ", "5% máu", "1 lượt", "mỗi 4 lần", "gấp đôi sát thương"):
            self.assertIn(text, g1["description"])
        for text in ("×170", "×125", "×100", "30%", "42%", "250 Mana", "150 Nộ", "50 Nộ"):
            self.assertIn(text, g3["description"])


class GalaxyCycleTests(unittest.TestCase):
    def test_g1_keeps_immediate_cast_without_guessing_rng_or_healing(self):
        s = state(200, 200)
        with patch("pokiguard_v2.basic_policy.evaluate_all_moves", side_effect=AssertionError("ready skill should not scan board")):
            result = policy().decide(s, pet_skill_capability=cap("GALAXY_RICKY"))
        self.assertIs(result.action, PolicyAction.PET_SKILL)
        f = facts(result)
        self.assertEqual(f["pet_alias"], "G1")
        self.assertEqual(f["random_outcome"], "UNKNOWN")
        self.assertEqual(f["random_probabilities"], "UNKNOWN")
        self.assertEqual(f["guaranteed_heal"], 0)
        self.assertEqual(f["guaranteed_stun_turns"], 0)
        self.assertEqual(f["guaranteed_mana_refund"], 0)

    def test_g1_fourth_cast_can_be_runtime_published_without_history(self):
        s = state(200, 200)
        result = policy().decide(s, pet_skill_capability=cap("GALAXY_RICKY", 4, 4))
        self.assertEqual(result.trace.policy_step, "GALAXY_G1_FIRE_FOURTH")
        self.assertTrue(facts(result)["doubled_fourth"])
        self.assertEqual(facts(result)["phase_support"], "CURRENT_RUNTIME_CARD_PHASE")

    def test_g1_history_is_an_explicit_estimate_and_proposals_do_not_advance_it(self):
        s = state(200, 200, turn=1)
        p = policy()
        first = p.decide(s, pet_skill_capability=cap("GALAXY_RICKY"), skill_rush_match_context=history(s))
        self.assertEqual(facts(first)["next_phase"], 1)
        self.assertEqual(first, p.decide(s, pet_skill_capability=cap("GALAXY_RICKY"), skill_rush_match_context=history(s)))
        later = replace(s, battle=replace(s.battle, turn_number=9))
        fourth = p.decide(later, pet_skill_capability=cap("GALAXY_RICKY"), skill_rush_match_context=history(later, 3, 7))
        self.assertEqual(facts(fourth)["next_phase"], 4)
        self.assertEqual(facts(fourth)["phase_support"], "TOOL_HISTORY_ESTIMATE_FROM_OBSERVED_OPENING")

    def test_midmatch_or_pet_change_does_not_guess_phase_one_or_share_counts(self):
        s = state(200, 200)
        p = policy()
        unknown = p.decide(s, pet_skill_capability=cap(), skill_rush_match_context=history(s, 2, 7))
        self.assertIsNone(facts(unknown)["next_phase"])
        opening = replace(s, battle=replace(s.battle, turn_number=1))
        p = policy()
        p.decide(opening, pet_skill_capability=cap("GALAXY_RICKY"), skill_rush_match_context=history(opening))
        switched = p.decide(s, pet_skill_capability=cap(), skill_rush_match_context=history(s, 3, 7))
        self.assertIsNone(facts(switched)["next_phase"])
        self.assertEqual(facts(switched)["pet_alias"], "G3")

    def test_g3_runtime_phase_overrides_history_and_exposes_the_correct_effect(self):
        s = state(200, 200)
        for phase, mana, rage in ((1, 250, 0), (2, 0, 150), (3, 150, 50)):
            with self.subTest(phase=phase):
                result = policy().decide(s, pet_skill_capability=cap(phase=phase, maximum=3),
                                         skill_rush_match_context=history(s, 5, 7))
                self.assertIs(result.action, PolicyAction.PET_SKILL)
                f = facts(result)
                self.assertEqual(f["next_phase"], phase)
                self.assertEqual(f["declared_stage"]["mana_refund"], mana)
                self.assertEqual(f["declared_stage"]["rage_refund"], rage)
                self.assertEqual(f["stored_mark_damage"], "UNKNOWN")
                self.assertEqual(f["active_buff_remaining"], "UNKNOWN")

    def test_g3_each_phase_selects_resources_for_its_next_cycle_bottleneck(self):
        s = state()
        bases = evaluate_all_moves(s.board)
        mana, rage = candidate(bases[0], mana=3), candidate(bases[1], rage=3)
        for phase, expected in ((1, rage.move), (2, mana.move), (3, rage.move)):
            with self.subTest(phase=phase), patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(mana, rage)):
                result = policy().decide(s, pet_skill_capability=cap(phase=phase, maximum=3))
                self.assertEqual(result.move, expected)
                self.assertEqual(result.trace.policy_step, "GALAXY_G3_RESOURCE_CYCLE")

    def test_g3_current_unlock_has_priority_over_future_refund_preferences(self):
        s = state(mana=200, rage=199)
        bases = evaluate_all_moves(s.board)
        mana, rage = candidate(bases[0], mana=7), candidate(bases[1], rage=3)
        with patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(mana, rage)):
            result = policy().decide(s, pet_skill_capability=cap(phase=2, maximum=3))
        self.assertEqual(result.move, rage.move)

    def test_future_refunds_never_make_a_skill_affordable_early(self):
        for element, phase, maximum in (("GALAXY_RICKY", 4, 4), ("GALAXY_DRAGON_KNIGHT", 1, 3),
                                        ("GALAXY_DRAGON_KNIGHT", 2, 3), ("GALAXY_DRAGON_KNIGHT", 3, 3)):
            for mana, rage in ((199, 200), (200, 199)):
                with self.subTest(element=element, phase=phase, mana=mana, rage=rage):
                    result = policy().decide(state(mana, rage), pet_skill_capability=cap(element, phase, maximum))
                    self.assertIsNot(result.action, PolicyAction.PET_SKILL)
                    self.assertEqual(facts(result)["current_cost_credit_from_refund"], 0)

    def test_bad_phase_cannot_override_or_be_replaced_by_a_false_history_claim(self):
        p = policy()
        s = state(200, 200, turn=1)
        p.decide(s, pet_skill_capability=cap(), skill_rush_match_context=history(s))
        later = replace(s, battle=replace(s.battle, turn_number=7))
        for bad in (cap(phase=4, maximum=3), cap(phase=2, maximum=4),
                    replace(cap(phase=2, maximum=3), skill_phase_source="OLD_SESSION")):
            with self.subTest(bad=bad):
                result = p.decide(later, pet_skill_capability=bad, skill_rush_match_context=history(later, 2, 5))
                self.assertIsNone(facts(result)["next_phase"])
                self.assertIsNone(facts(result)["declared_stage"])

    def test_resource_tactics_preserve_rage_and_still_protect_when_skill_is_not_ready(self):
        s = state(mana=200, rage=100)
        s = with_player_hp(s, hp=20)
        bases = evaluate_all_moves(s.board)
        sword, health = candidate(bases[0], sword=9), health_candidate(bases[1])
        for element in ("GALAXY_RICKY", "GALAXY_DRAGON_KNIGHT"):
            with self.subTest(element=element), patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(sword, health)):
                result = policy(protection=MegaSelfProtection.HP_BELOW_30).decide(s, pet_skill_capability=cap(element))
            self.assertEqual(result.move, health.move)

    def test_g1_fourth_cast_allows_only_bounded_resource_risk_without_a_kill_claim(self):
        s = with_player_hp(state(mana=200, rage=100), hp=45)
        boss = replace(s.opponents[0], attack=1)
        s = replace(s, opponents=(boss,))
        bases = evaluate_all_moves(s.board)
        rage, health = candidate(bases[0], rage=3, direct_replies=1), health_candidate(bases[1])
        with patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(rage, health)):
            ordinary = policy().decide(s, pet_skill_capability=cap("GALAXY_RICKY", 3, 4))
            fourth = policy().decide(s, pet_skill_capability=cap("GALAXY_RICKY", 4, 4))
            dangerous = policy().decide(replace(s, opponents=(replace(boss, attack=10000),)),
                                         pet_skill_capability=cap("GALAXY_RICKY", 4, 4))
        self.assertEqual(ordinary.move, health.move)
        self.assertEqual(fourth.move, rage.move)
        self.assertEqual(dangerous.move, health.move)
        self.assertEqual(facts(fourth)["guaranteed_heal"], 0)

    def test_no_galaxy_changes_when_reasoning_is_off_and_known_wins_still_fire(self):
        for pet, element, turn in (("g1", "GALAXY_RICKY", 17), ("g3", "GALAXY_DRAGON_KNIGHT", 13)):
            s = recorded(turn, pet=pet)
            with self.subTest(pet=pet):
                self.assertEqual(policy(enabled=False).decide(s, pet_skill_capability=cap(element)).trace.policy_step, "GALAXY_FIRE")
                self.assertIs(policy().decide(s, pet_skill_capability=cap(element)).action, PolicyAction.PET_SKILL)

    def test_phase_changes_invalidate_the_reasoning_packet_hash(self):
        s = state(200, 200)
        p = policy(enabled=False)
        c = cap(phase=1, maximum=3)
        baseline = p.decide(s, pet_skill_capability=c)
        before = packet_hash(packet(s, p.config, baseline, c, None, True))
        after = packet_hash(packet(s, p.config, baseline, replace(c, skill_phase_next=2), None, True))
        self.assertNotEqual(before, after)


class GalaxyControllerTests(unittest.TestCase):
    def test_g1_g3_tactics_use_existing_normal_input_and_ack_checkpoints(self):
        from tests.reasoning_controller_fixture import controller_trace
        from tools import basic_auto_bot as bot
        run = bot.run
        def enabled(*args, **kwargs):
            return run(*args, **kwargs, galaxy_reasoning=True)
        for element, phase, maximum, alias in (("GALAXY_RICKY", 4, 4, "G1"),
                                                ("GALAXY_DRAGON_KNIGHT", 2, 3, "G3")):
            def current(_provider, observed, _resolver):
                return replace(cap(element, phase, maximum), session_key=observed.battle.session_key)
            with self.subTest(alias=alias), tempfile.TemporaryDirectory() as folder, \
                 patch.object(bot, "run", side_effect=enabled), \
                 patch.object(bot, "_current_pet_skill_capability", side_effect=current):
                _, calls, rows = controller_trace(Path(folder) / "combat.jsonl", profile="galaxy",
                    initial_combat=state(), gameplay_config=galaxy_config())
            self.assertEqual(calls.count("FAKE_NORMAL_INPUT"), 1)
            self.assertEqual(calls.count("executor.ack"), 1)
            decision = next(r for r in rows if r["event"] == "policy_decision")
            details = json.loads(decision["trace"]["why_selected"].split(": ", 1)[1])
            self.assertEqual(details["pet_alias"], alias)
            self.assertEqual(details["next_phase"], phase)

    def test_changed_runtime_phase_cancels_the_previous_move_on_fresh_reread(self):
        from tests.reasoning_controller_fixture import controller_trace
        from tools import basic_auto_bot as bot
        run = bot.run
        def enabled(*args, **kwargs):
            return run(*args, **kwargs, galaxy_reasoning=True)
        discoveries = 0
        def current(_provider, observed, _resolver):
            nonlocal discoveries
            discoveries += 1
            return replace(cap(phase=1 if discoveries == 1 else 2, maximum=3),
                           session_key=observed.battle.session_key)
        s = state()
        bases = evaluate_all_moves(s.board)
        mana, rage = candidate(bases[0], mana=3), candidate(bases[1], rage=3)
        with tempfile.TemporaryDirectory() as folder, patch.object(bot, "run", side_effect=enabled), \
             patch.object(bot, "_current_pet_skill_capability", side_effect=current), \
             patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(mana, rage)):
            _, _, rows = controller_trace(Path(folder) / "combat.jsonl", profile="galaxy",
                initial_combat=s, gameplay_config=galaxy_config())
        self.assertTrue(any(r["event"] == "action_result" and r.get("reason") == "POLICY_CHANGED_ON_FRESH_REREAD"
                            for r in rows))


if __name__ == "__main__":
    unittest.main()
