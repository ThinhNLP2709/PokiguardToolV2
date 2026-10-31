from __future__ import annotations
from tests.game_update_fixture import historical_test_view

from dataclasses import replace
import json
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

from pokiguard_v2.basic_policy import BasicPolicyEngine, PlayStyle, PolicyAction
from pokiguard_v2.board_diagnostics import analyze_game_state, game_state_from_payload
from pokiguard_v2.gameplay_profile import (AuditionMode, DamageCardMode, EvolutionTarget,
                                         GameMode, MainPetType, PetSkillFireCondition)
from pokiguard_v2.pet_configuration import basic_policy_config
from pokiguard_v2.state import GameOwnedIdleStatus
from tests.test_bu_win import bu_win_config
from tools.basic_auto_bot import _must_pause_for_no_safe_move


def observed_bu_win_state():
    payload = json.loads((Path(__file__).parent / "fixtures/bu_win_no_safe_move_20261013.json").read_text(encoding="utf-8"))
    state = game_state_from_payload(payload)
    # The diagnostic JSON represents enum values as strings. Restore the
    # enum used by the live controller without changing its observed value.
    return replace(state, battle=replace(
        state.battle,
        consecutive_pass_status=GameOwnedIdleStatus(state.battle.consecutive_pass_status),
    ))


class BuWinSwordRiskGuardTests(unittest.TestCase):
    def test_observed_4_of_7_stop_has_legal_feed_move_despite_zero_safe_moves(self):
        state = observed_bu_win_state()
        engine = BasicPolicyEngine(basic_policy_config(bu_win_config()))
        analysis = analyze_game_state(state, policy_engine=engine)
        decision = engine.decide(state)
        self.assertEqual((state.battle.turn_number, state.battle.srv_seq), (3, 8))
        self.assertEqual(analysis.legal_match_producing_moves, 9)
        self.assertEqual(analysis.safe_move_count, 0)
        self.assertFalse(state.battle.is_first_local_turn)
        self.assertEqual(state.player.hp, 4388)
        self.assertIs(decision.action, PolicyAction.SWAP)
        self.assertEqual(decision.trace.policy_step, "BU_WIN_FEED_BOSS")
        self.assertEqual((decision.move.first, decision.move.second), ((0, 7), (1, 7)))
        selected = next(c for c in decision.trace.candidates if c.move == decision.move)
        self.assertEqual(selected.known_sword_consumed, 0)
        self.assertEqual(selected.opponent_sword_reply_effective_max, 4)
        self.assertFalse(_must_pause_for_no_safe_move(
            decision, legal_move_count=analysis.legal_match_producing_moves,
            safe_move_count=analysis.safe_move_count,
            first_local_turn=state.battle.is_first_local_turn,
        ))

    def test_exemption_requires_exact_bu_win_swap_branch_and_move(self):
        decision = BasicPolicyEngine(basic_policy_config(bu_win_config())).decide(observed_bu_win_state())
        variants = (
            replace(decision, trace=replace(decision.trace, play_style=PlayStyle.SIMPLE.value)),
            replace(decision, trace=replace(decision.trace, policy_step="STEP_3_RAGE")),
            replace(decision, move=None),
            replace(decision, action=PolicyAction.NONE, move=None),
        )
        for candidate in variants:
            with self.subTest(action=candidate.action, step=candidate.trace.policy_step, style=candidate.trace.play_style):
                self.assertTrue(_must_pause_for_no_safe_move(
                    candidate, legal_move_count=9, safe_move_count=0, first_local_turn=False,
                ))

    def controller_case(self, case="normal", *, dead=False):
        from tests.reasoning_controller_fixture import controller_trace
        from tools import basic_auto_bot as bot
        state = observed_bu_win_state()
        if dead:
            state = replace(state, player=replace(state.player, hp=0))
        original_parser = bot.build_parser

        def canonical_coop_parser():
            parser = original_parser()
            parser.set_defaults(
                game_mode=GameMode.COOP.value, main_pet=MainPetType.NORMAL.value,
                evolution_target=EvolutionTarget.NONE.value,
                damage_card=DamageCardMode.NONE.value,
                audition_mode=AuditionMode.NO_ACTION.value,
                pet_skill_fire_condition=PetSkillFireCondition.SKILL_COST_READY.value,
                pet_skill_fire_value=None,
                minimum_action_time=3,
            )
            return parser

        with tempfile.TemporaryDirectory() as temp, patch.object(bot, "build_parser", side_effect=canonical_coop_parser):
            return controller_trace(
                Path(temp) / "combat.jsonl", initial_combat=state,
                profile=PlayStyle.BU_WIN.value, case=case,
            )

    def test_real_controller_reaches_existing_normal_input_and_ack_on_observed_board(self):
        _result, calls, rows = self.controller_case()
        self.assertEqual(calls.count("FAKE_NORMAL_INPUT"), 1)
        self.assertEqual(calls.count("executor.ack"), 1)
        self.assertTrue(any(r["event"] == "policy_decision" and
                            r["trace"]["policy_step"] == "BU_WIN_FEED_BOSS" for r in rows))
        self.assertFalse(any(r.get("reason") == "POLICY_NO_SAFE_MOVE" for r in rows))
        sent = next(r for r in rows if r["event"] == "action_sent")
        self.assertEqual(sent["identity"]["target"], [[0, 7], [1, 7]])

    def test_bu_win_risk_exemption_keeps_freshness_turn_deadline_and_stop_guards(self):
        for case in ("stale", "wrong_turn", "reserve_fresh", "reserve_final", "stop", "stop_after_fresh", "stop_before_input"):
            with self.subTest(case=case):
                _result, calls, _rows = self.controller_case(case)
                self.assertNotIn("FAKE_NORMAL_INPUT", calls)

    def test_dead_pet_remains_blocked_without_input(self):
        _result, calls, rows = self.controller_case(dead=True)
        self.assertNotIn("FAKE_NORMAL_INPUT", calls)
        self.assertTrue(any(r["event"] == "action_gate_blocked" and
                            r["reason"] == "PLAYER_DEAD" for r in rows))

    @historical_test_view()
    def test_source_binding_rejects_future_controller_changes(self):
        from tests.reasoning_controller_fixture import assert_c3_source_compatibility
        from tools.qualify_reasoning_selection import controller_ast_audit
        target = Path(__file__).resolve().parents[1] / "tools/basic_auto_bot.py"
        original_read = Path.read_bytes
        assert_c3_source_compatibility(self)
        self.assertTrue(controller_ast_audit()["pass_bu_win_side_fix"])

        def changed_bytes(path):
            raw = original_read(path)
            return raw + b"\n# unreviewed controller change\n" if path == target else raw

        with patch.object(Path, "read_bytes", changed_bytes):
            with self.assertRaises(AssertionError):
                assert_c3_source_compatibility(self)
            audit = controller_ast_audit()
            self.assertFalse(audit["pass_bu_win_side_fix"])
            self.assertFalse(audit["pass_ast"])


if __name__ == "__main__":
    unittest.main()
