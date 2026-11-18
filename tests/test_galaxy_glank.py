"""G2 tactical behavior, actual loss-board replay and normal input checkpoints."""
from dataclasses import replace
import json
from pathlib import Path
import tempfile
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.basic_policy import BasicPolicyEngine, PolicyAction, SkillRushMatchContext
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.desktop_ui import ai_status_text
from pokiguard_v2.gameplay_profile import MegaSelfProtection
from pokiguard_v2.galaxy_glank import shield_count
from pokiguard_v2.pet_configuration import basic_policy_config
from pokiguard_v2.reasoning_galaxy import GalaxyReasoningSession
from pokiguard_v2.reasoning_settings import AISettings
from pokiguard_v2.reasoning_swap_timing import prepare_reasoning_options_safely
from pokiguard_v2.reasoning_ui_session import create_ui_reasoning_session
from pokiguard_v2.state import GameOwnedIdleStatus
from tests.test_galaxy import galaxy_config
from tests.test_mega_icarus_policy import health_candidate
from tests.test_phase3c1_pet_skill_policy import capability, session_state
from tests.test_phase3c3_skill_rush_policy import board_from_names, candidate, with_idle_status, with_player_hp


FIXTURE = Path(__file__).parent / "fixtures/galaxy_glank_20261115/replay.json"
CASES = json.loads(FIXTURE.read_text(encoding="utf-8"))["cases"]


def replay_state(case):
    source = case["board"]
    board = board_from_names(tuple(tuple(c[0] for c in row) for row in source),
                             multipliers=tuple(tuple(c[1] for c in row) for row in source))
    state = session_state(mana=case["player"]["mana"], rage=case["player"]["power"], boss_hp=case["boss"]["hp"])
    own, boss = replace(state.player, **case["player"]), replace(state.opponents[0], **case["boss"])
    return replace(state, board=board, player=own, opponents=(boss,), participants=(own, boss),
                   battle=replace(state.battle, turn_number=case["turn"], srv_seq=case["srv_seq"]))


def recorded(turn, pet="g2"):
    return replay_state(next(c for c in CASES if c["pet"] == pet and c["turn"] == turn))


def cap(element="GALAXY_2"):
    return capability(element=element, mana_cost=200, rage_cost=200)


def engine(*, enabled=True, protection=MegaSelfProtection.HP_BELOW_30):
    return BasicPolicyEngine(basic_policy_config(replace(galaxy_config(), mega_self_protection=protection)),
                             galaxy_reasoning=enabled)


def facts(decision):
    return json.loads(decision.trace.why_selected.split(": ", 1)[1])


class GlankTacticsTests(unittest.TestCase):
    def test_every_recorded_g2_swap_preserves_sword_when_rage_is_nonzero(self):
        policy = engine()
        for case in CASES:
            if case["pet"] != "g2":
                continue
            with self.subTest(turn=case["turn"]):
                state = replay_state(case)
                decision = policy.decide(state, pet_skill_capability=cap())
                self.assertTrue(decision.trace.policy_step.startswith("GALAXY_G2_"))
                if decision.action is PolicyAction.SWAP and state.player.power > 0:
                    self.assertEqual(decision.trace.selected_candidate.sword_effective, 0)
                    self.assertEqual(decision.trace.selected_candidate.known_sword_consumed, 0)
                self.assertEqual(facts(decision)["refill_credit"], 0)

    def test_recorded_resource_choice_avoids_consuming_three_shields(self):
        decision = engine().decide(recorded(3), pet_skill_capability=cap())
        self.assertEqual(decision.trace.policy_step, "GALAXY_G2_RESOURCE_PROGRESS")
        self.assertEqual(decision.trace.selected_candidate.known_sword_consumed, 0)
        self.assertFalse(any(gem == "shield" for gem, *_ in decision.trace.selected_candidate.total_resources))

    def test_fourteen_shields_count_as_seventeen_effective_from_verified_client_rule(self):
        decision = engine().decide(recorded(13), pet_skill_capability=cap())
        self.assertIs(decision.action, PolicyAction.PET_SKILL)
        self.assertEqual(decision.trace.policy_step, "GALAXY_G2_FIRE_SHIELDS")
        self.assertEqual(facts(decision)["shield_cells"], 14)
        self.assertEqual(facts(decision)["shield_effective"], 17)
        self.assertEqual(facts(decision)["nominal_skill_damage"], 510_000)
        self.assertEqual(facts(decision)["active_reduction_remaining"], "UNKNOWN")
        self.assertEqual(facts(decision)["passive_armor_remaining"], "UNKNOWN")

    def test_sparse_healthy_board_sets_up_once_and_repeated_preflights_are_identical(self):
        policy, state = engine(), recorded(27)
        decision = policy.decide(state, pet_skill_capability=cap())
        self.assertEqual(decision.trace.policy_step, "GALAXY_G2_SETUP_SHIELDS")
        self.assertEqual(decision.trace.selected_candidate.sword_effective, 0)
        self.assertEqual(decision, policy.decide(state, pet_skill_capability=cap()))
        self.assertLessEqual(facts(decision)["setup_candidates_examined"], 8)
        self.assertEqual(facts(decision)["known_shields_after"], shield_count(state.board.cells))
        later = replace(state, battle=replace(state.battle, turn_number=29))
        ready = policy.decide(later, pet_skill_capability=cap())
        self.assertEqual(ready.trace.policy_step, "GALAXY_G2_FIRE_WAIT_LIMIT")
        self.assertEqual(ready, policy.decide(later, pet_skill_capability=cap()))

    def test_same_physical_shield_count_with_higher_multipliers_changes_skill_value(self):
        state = recorded(27)
        cells = [list(row) for row in state.board.cells]
        first = next((r, c) for r, row in enumerate(cells) for c, cell in enumerate(row) if cell.gem.value == "shield")
        r, c = first
        cells[r][c] = replace(cells[r][c], multiplier=cells[r][c].multiplier + 6)
        stronger = replace(state, board=replace(state.board, cells=tuple(tuple(row) for row in cells)))
        self.assertEqual(shield_count(state.board.cells), shield_count(stronger.board.cells))
        self.assertEqual(engine().decide(state, pet_skill_capability=cap()).trace.policy_step, "GALAXY_G2_SETUP_SHIELDS")
        self.assertEqual(engine().decide(stronger, pet_skill_capability=cap()).trace.policy_step, "GALAXY_G2_FIRE_SHIELDS")

    def test_skill_does_not_wait_if_known_boss_reply_can_reduce_all_setup_shield_floors(self):
        from pokiguard_v2.board_simulator import ResourceResult, _CellValue
        from pokiguard_v2.state import GemType
        state = recorded(27)
        without_shields = [[_CellValue(GemType.HEALTH, 1) for _ in range(8)] for _ in range(8)]
        with patch("pokiguard_v2.galaxy_glank._resolve_known_reply",
                   return_value=(ResourceResult(), ResourceResult(), 0, without_shields)):
            decision = engine().decide(state, pet_skill_capability=cap())
        self.assertEqual(decision.trace.policy_step, "GALAXY_G2_FIRE_SHIELDS_AT_RISK")

    def test_new_confirmed_skill_cycle_and_new_session_reset_the_wait_limit(self):
        policy, state = engine(), recorded(27)
        policy.decide(state, pet_skill_capability=cap())
        later = replace(state, battle=replace(state.battle, turn_number=35))
        history = SkillRushMatchContext(state.battle.session_key, 1, 29)
        decision = policy.decide(later, pet_skill_capability=cap(), skill_rush_match_context=history)
        self.assertEqual(decision.trace.policy_step, "GALAXY_G2_SETUP_SHIELDS")
        other_session = replace(state.battle.session_key, lifecycle_epoch=2, match_id="OTHER")
        other = replace(state, battle=replace(state.battle, session_key=other_session, match_id="OTHER"))
        self.assertEqual(policy.decide(other, pet_skill_capability=replace(cap(), session_key=other_session)).trace.policy_step,
                         "GALAXY_G2_SETUP_SHIELDS")

    def test_low_hp_does_not_wait_for_more_shields_even_with_protection_off(self):
        for turn in (47, 59):
            with self.subTest(turn=turn):
                decision = engine(protection=MegaSelfProtection.NONE).decide(recorded(turn), pet_skill_capability=cap())
                self.assertIs(decision.action, PolicyAction.PET_SKILL)
                self.assertEqual(decision.trace.policy_step, "GALAXY_G2_FIRE_PROTECTION")

    def test_large_known_sword_pressure_casts_protection_while_healthy(self):
        state = replace(recorded(27), board=recorded(15).board)
        boss = replace(state.opponents[0], attack=100_000)
        state = replace(state, opponents=(boss,), participants=(state.player, boss))
        decision = engine().decide(state, pet_skill_capability=cap())
        self.assertEqual(decision.trace.policy_step, "GALAXY_G2_FIRE_PROTECTION")

    def test_ready_nominal_finisher_is_labeled_without_certifying_a_kill(self):
        state = recorded(27)
        boss = replace(state.opponents[0], hp=100_000)
        decision = engine().decide(replace(state, opponents=(boss,)), pet_skill_capability=cap())
        self.assertEqual(decision.trace.policy_step, "GALAXY_G2_FIRE_NOMINAL_FINISH")
        self.assertIs(facts(decision)["kill_certified"], False)

    def test_ready_skill_does_not_defer_when_all_setup_moves_are_risky(self):
        from pokiguard_v2.board_simulator import evaluate_all_moves
        state = recorded(27)
        moves = tuple(replace(m, sword_risk=replace(m.sword_risk, safe=False)) for m in evaluate_all_moves(state.board))
        with patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=moves):
            decision = engine().decide(state, pet_skill_capability=cap())
        self.assertEqual(decision.trace.policy_step, "GALAXY_G2_FIRE_NO_SAFE_SETUP")

    def test_sword_is_available_only_at_exact_zero_rage(self):
        from pokiguard_v2.board_simulator import evaluate_all_moves
        state = session_state(mana=100, rage=0)
        bases = evaluate_all_moves(state.board)
        sword, health = candidate(bases[0], sword=6), health_candidate(bases[1])
        for rage, expected in ((0, sword.move), (1, health.move), (199, health.move)):
            with self.subTest(rage=rage), patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(sword, health)):
                decision = engine(protection=MegaSelfProtection.NONE).decide(
                    replace(state, player=replace(state.player, power=rage)), pet_skill_capability=cap())
            self.assertEqual(decision.move, expected)
        critical = with_player_hp(replace(state, player=replace(state.player, power=100)), hp=10)
        with patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(sword, health)):
            self.assertEqual(engine().decide(critical, pet_skill_capability=cap()).move, health.move)

    def test_only_sword_moves_with_positive_rage_use_only_authoritative_pass(self):
        from pokiguard_v2.board_simulator import evaluate_all_moves
        state = session_state(mana=100, rage=100)
        sword = candidate(evaluate_all_moves(state.board)[0], sword=6)
        state = with_idle_status(state, GameOwnedIdleStatus.PASS_ALLOWED, count=0)
        with patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(sword,)):
            self.assertIs(engine().decide(state, pet_skill_capability=cap()).action, PolicyAction.PASS)
            mandatory = with_idle_status(state, GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION, count=2)
            blocked = engine().decide(mandatory, pet_skill_capability=cap())
            self.assertIs(blocked.action, PolicyAction.NONE)
            self.assertEqual(blocked.trace.blocker, "GALAXY_G2_SWORD_WOULD_SPEND_RAGE")

    def test_resource_charge_prefers_shield_preserving_progress(self):
        from pokiguard_v2.board_simulator import evaluate_all_moves
        state = session_state(mana=200, rage=100)
        bases = evaluate_all_moves(state.board)
        consuming = candidate(bases[0], rage=5, shield=3)
        preserving = candidate(bases[1], rage=3)
        with patch("pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(consuming, preserving)):
            self.assertEqual(engine().decide(state, pet_skill_capability=cap()).move, preserving.move)

    def test_resource_and_turn_gates_still_precede_g2_tactics(self):
        state = recorded(13)
        for mana, rage in ((199, 200), (200, 199)):
            own = replace(state.player, mana=mana, power=rage)
            self.assertIsNot(engine().decide(replace(state, player=own), pet_skill_capability=cap()).action,
                             PolicyAction.PET_SKILL)
        bad = replace(state, battle=replace(state.battle, client_move_allowed=False))
        self.assertIs(engine().decide(bad, pet_skill_capability=cap()).action, PolicyAction.NONE)
        unknown_rage = replace(state, player=replace(state.player, power=None))
        unknown = engine().decide(unknown_rage, pet_skill_capability=cap())
        self.assertIs(unknown.action, PolicyAction.NONE)
        self.assertEqual(unknown.trace.blocker, "GALAXY_G2_SKILL_STATE_UNKNOWN")
        self.assertIsNot(engine().decide(state, pet_skill_capability=replace(cap(), ownership_current=False)).action,
                         PolicyAction.PET_SKILL)

    def test_g1_g3_keep_immediate_fire_and_basic_g2_keeps_its_existing_behavior(self):
        for pet, element in (("g1", "GALAXY_RICKY"), ("g3", "GALAXY_DRAGON_KNIGHT")):
            case = next(c for c in CASES if c["pet"] == pet)
            state = replay_state(case)
            self.assertIs(engine(enabled=False).decide(state, pet_skill_capability=cap(element)).action, PolicyAction.PET_SKILL)
            result = engine().decide(state, pet_skill_capability=cap(element))
            self.assertIs(result.action, PolicyAction.PET_SKILL)
            self.assertEqual(facts(result)["pet_alias"], pet.upper())
        self.assertEqual(engine(enabled=False).decide(recorded(27), pet_skill_capability=cap()).trace.policy_step,
                         "GALAXY_FIRE")


class GalaxyReasoningDeliveryTests(unittest.TestCase):
    def config(self):
        return replace(DesktopConfig().with_gameplay_config(galaxy_config()), ai=AISettings(False, 4000, True))

    def test_ui_opt_in_reaches_the_scoped_tactics_without_loading_the_common_profile(self):
        with tempfile.TemporaryDirectory() as temp:
            observed = []
            with patch("pokiguard_v2.reasoning_ui_profile.load_session_authority", side_effect=AssertionError("common worker profile")):
                session = create_ui_reasoning_session(self.config(), paths=None, game_executable=None,
                    directory=Path(temp) / "reasoning", observer=lambda status, *_: observed.append(status))
            self.assertIsInstance(session, GalaxyReasoningSession)
            self.assertEqual(session.prepare_options(), {})
            session.bind_run("OFFLINE_GALAXY", Path(temp) / "farm")
            self.assertEqual(prepare_reasoning_options_safely(session), {"galaxy_reasoning": True})
            self.assertIn("G2", ai_status_text(observed[-1]))
            session.stop()
            self.assertTrue(session.wait_closed(.01))
            self.assertEqual(prepare_reasoning_options_safely(session), {})
            self.assertFalse(observed[-1].selection_authority)

    def test_disabled_and_invalid_option_cannot_enable_g2(self):
        cfg = replace(self.config(), ai=AISettings())
        self.assertIsNone(create_ui_reasoning_session(cfg, paths=None, game_executable=None,
            directory=Path("unused"), observer=Mock()))
        fake = Mock()
        fake.prepare_options.return_value = {"galaxy_reasoning": "true"}
        self.assertEqual(prepare_reasoning_options_safely(fake), {})

    def test_real_controller_rechecks_the_g2_move_and_sends_one_normal_swap(self):
        from tests.reasoning_controller_fixture import controller_trace
        from tools import basic_auto_bot as bot
        run = bot.run
        def opted_in(*args, **kwargs):
            return run(*args, **kwargs, galaxy_reasoning=True)
        def current(_provider, state, _resolver):
            return replace(cap(), session_key=state.battle.session_key)
        with tempfile.TemporaryDirectory() as temp, patch.object(bot, "run", side_effect=opted_in), \
             patch.object(bot, "_current_pet_skill_capability", side_effect=current):
            _, calls, rows = controller_trace(Path(temp) / "combat.jsonl", profile="galaxy",
                initial_combat=recorded(3), gameplay_config=galaxy_config())
        self.assertEqual(calls.count("FAKE_NORMAL_INPUT"), 1)
        self.assertEqual(calls.count("executor.ack"), 1)
        self.assertTrue(next(r for r in rows if r["event"] == "auto_controller_started")["galaxyReasoningEnabled"])
        decision = next(r for r in rows if r["event"] == "policy_decision")
        self.assertEqual(decision["policyStep"], "GALAXY_G2_RESOURCE_PROGRESS")
        self.assertEqual(decision["swordResult"], 0)


if __name__ == "__main__":
    unittest.main()
