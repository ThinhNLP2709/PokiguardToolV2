from __future__ import annotations

import ast
from dataclasses import replace
from pathlib import Path
import random
import unittest
from unittest.mock import patch

from pokiguard_v2.board_simulator import SwapMove, evaluate_all_moves
from pokiguard_v2.demon_aegis import evaluate_demon_aegis_move
from pokiguard_v2.reasoning_planner import (
    Bound, Inputs, context_weights, order_key, plan, protection_credit,
    removal_ledger, resource_credit,
)
from pokiguard_v2.reasoning_replay import load_dataset
from pokiguard_v2.reasoning_snapshot import Action, ReasoningSnapshot, canonical_json
from tools.evaluate_reasoning_planner import (
    DATASET, TARGET, card, certificate, change, demon_board, scenarios, snapshot, with_model,
)

ROOT = Path(__file__).resolve().parents[1]


class ReasoningPlannerTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.cases = {name: (s, plan(s), expected, action) for name, s, expected, action in scenarios()}
        cls.simple = snapshot()
        cls.demon = cls.cases["D01_joint_3Sword_5Rage"][0]

    def test_declared_scenario_expectations(self):
        for name, (_, result, expected, action) in self.cases.items():
            with self.subTest(name=name):
                if expected:
                    self.assertEqual(result.disposition, expected)
                if action:
                    self.assertEqual(result.proposal, action)

    def test_all_legal_swaps_and_baseline_included_despite_setting_64(self):
        s = snapshot(setting=64)
        result = plan(s)
        legal = {canonical_json(Action("swap", v.move).to_dict()) for v in evaluate_all_moves(s.board_state())}
        actual = {canonical_json(v.action.to_dict()) for v in result.scores}
        self.assertEqual(legal, actual)
        self.assertTrue(any(v.baseline_member for v in result.scores))
        self.assertGreater(len(actual), 0)

    def test_same_settings_change_actual_choice_with_hp_for_four_profiles(self):
        for profile in ("simple", "careful", "skill_rush", "mega_icarus_spam_skill"):
            high, hi, _, _ = self.cases[profile + ":healthy"]
            low, lo, _, _ = self.cases[profile + ":pressure_before_30"]
            self.assertEqual(high.intent, low.intent)
            self.assertEqual(hi.disposition, "RETAIN_BASELINE")
            self.assertEqual(lo.proposal.card_source, "SYNTHETIC_PROTECT")
            self.assertEqual(low.evidence("self.hp").value.plain(), 40)

    def test_demon_3_sword_5_rage_nominal_scope_not_observed_win(self):
        s, result, _, _ = self.cases["D01_joint_3Sword_5Rage"]
        target = next(v for v in result.scores if v.action.move == TARGET)
        detail = target.details.plain()
        self.assertEqual(result.proposal.move, TARGET)
        self.assertEqual(detail["passive_swords"] if "passive_swords" in detail else
                         detail["ledger"]["passive_swords"], {"physical": 3, "effective": 3})
        self.assertEqual(detail["resources"]["rage"]["physical"], 5)
        self.assertEqual(detail["resources"]["rage"]["gross_points"], 100)
        self.assertEqual(dict(target.features)["F"].low, 1)
        self.assertFalse(detail["certificate"]["observed_win"])
        self.assertFalse(detail["certificate"]["dominance_tier"])
        self.assertEqual(s.intent.settings.plain()["sword_setting"], 4)

    def test_existing_rage_is_separate_from_same_burst_order(self):
        existing = self.cases["D02_existing_Rage"][1]
        unclear = self.cases["D04_effect_order_missing"][1]
        self.assertEqual(existing.proposal.move, TARGET)
        existing_target = next(v for v in existing.scores if v.action.move == TARGET)
        self.assertEqual(existing_target.details.plain()["resources"]["rage"]["physical"], 0)
        target = next(v for v in unclear.scores if v.action.move == TARGET)
        self.assertEqual((dict(target.features)["F"].low, dict(target.features)["F"].high), (0, 1))
        self.assertIsNone(unclear.proposal)

    def test_effect_order_resolves_only_its_scoped_assumption(self):
        s = self.cases["D04_effect_order_missing"][0]
        d = plan(with_model(s, effect_order="GAIN_BEFORE_BURST"))
        self.assertEqual(d.proposal.move, TARGET)

    def test_insufficient_rage_and_wrong_account_do_not_get_sufficiency_credit(self):
        for key in ("D03_insufficient_Rage", "D_scope_mismatch", "D06_oneSword_x3_is_not_3physical"):
            target = next(v for v in self.cases[key][1].scores if v.action.move == TARGET)
            self.assertEqual(dict(target.features)["F"].high, 0)

    def test_union_ledger_no_overlap_or_ordinary_cascade_double_credit(self):
        s = self.cases["D07_cross_union"][0]
        board = s.board_state()
        cross = SwapMove((3, 3), (3, 4))
        value = next(v for v in evaluate_all_moves(board) if v.move == cross)
        passive = evaluate_demon_aegis_move(board, value, include_next_turn=False)
        self.assertEqual(len(passive.blast_cells), 39)  # 24 + 24 - 9.
        ledger = removal_ledger(s, value, passive.blast_cells)
        expected = set(value.clear_rounds[0]) | set(passive.blast_cells)
        self.assertEqual(len(ledger["original_cells"]), len(expected))
        self.assertEqual(sum(v["physical"] for v in ledger["totals"].values()), len(expected))
        self.assertEqual(ledger["coverage"], "FIRST_WAVE_UNION")

    def test_original_ids_follow_collapse_across_cascades(self):
        records = load_dataset(DATASET)[1]
        cascades = 0
        for record in (records[0], records[10], records[-1]):
            s = record.snapshot
            for value in evaluate_all_moves(s.board_state()):
                ledger = removal_ledger(s, value)
                self.assertEqual(len(ledger["original_cells"]), value.total.total_cells)
                cascades += value.cascade_rounds > 0
        self.assertGreater(cascades, 0)

    def test_units_caps_overflow_and_already_ready_do_not_repeat_credit(self):
        s = snapshot(mana=290, rage=245)
        model = s.evidence("planner.model").value.plain()
        model["requirements"] = {"mana": 300, "rage": 250}
        totals = {g: dict(physical=0, effective=0) for g in ("sword", "shield", "health", "drain", "mana", "rage")}
        totals["mana"] = dict(physical=1, effective=3)
        totals["rage"] = dict(physical=5, effective=5)
        r, quantities, gap = resource_credit(Inputs(s), model, totals)
        self.assertEqual(quantities["mana"]["gross_points"], 90)
        self.assertEqual(quantities["mana"]["capped_gain_points"], 10)
        self.assertEqual(quantities["rage"]["gross_points"], 100)
        self.assertEqual(quantities["rage"]["capped_gain_points"], 5)
        self.assertAlmostEqual(r.low, (10 / 300 + 5 / 250) / 2)
        ready = change(change(s, "self.mana", 300), "self.rage", 250)
        r, _, gap = resource_credit(Inputs(ready), model, totals)
        self.assertEqual(r.low, 0)
        self.assertEqual(gap.low, 0)

    def test_two_mana_collected_by_legal_shield_sweep_can_close_60_point_cost(self):
        data = [list(row) for row in demon_board(rage_cells=0)]
        for r in range(8):
            for c in range(8):
                if data[r][c][0] == "mana":
                    data[r][c] = ("health", 1)
        data[0][2] = data[0][3] = ("mana", 1)
        s = snapshot("demon_aegis_farm", mana=0, board=tuple(tuple(row) for row in data),
                     model_updates=dict(requirements={"mana": 60, "rage": 0}))
        d = plan(s)
        target = next(v for v in d.scores if v.action.move == TARGET)
        detail = target.details.plain()["resources"]["mana"]
        self.assertEqual(detail["physical"], 2)
        self.assertEqual(detail["gross_points"], 60)
        self.assertEqual(dict(target.features)["R"].low, 1)

    def test_missing_cap_or_multiplier_conversion_is_not_guessed(self):
        s = self.demon
        missing = change(s, "self.max_rage", None)
        d = plan(missing)
        self.assertNotEqual(d.proposal, Action("swap", TARGET))
        target = next(v for v in d.scores if v.action.move == TARGET)
        self.assertEqual(dict(target.features)["F"].status, "UNSUPPORTED")
        self.assertIn("self.max_rage", d.diagnostics.plain()["missing_inputs"])
        s = self.cases["D06_oneSword_x3_is_not_3physical"][0]
        model = s.evidence("planner.model").value.plain()
        model["multiplier_supported"] = False
        totals = {g: dict(physical=0, effective=0) for g in ("sword", "shield", "health", "drain", "mana", "rage")}
        totals["rage"] = dict(physical=1, effective=3)
        _, values, _ = resource_credit(Inputs(s), model, totals)
        self.assertIsNone(values["rage"]["gross_points"])

    def test_heal_deficit_shared_across_health_and_drain(self):
        s = snapshot(hp=95)
        totals = {g: dict(physical=1, effective=1) for g in ("health", "drain", "shield")}
        totals["shield"] = dict(physical=0, effective=0)
        model = {"protection": {g: dict(points_per_effective=10, kind="heal") for g in ("health", "drain")}}
        p = protection_credit(Inputs(s), model, totals)
        self.assertAlmostEqual(p.low, .05)

    def test_no_unexamined_setup_or_followup_bonus(self):
        for _, d, _, _ in self.cases.values():
            for score in d.scores:
                self.assertEqual(dict(score.features)["H"].high, 0)
                self.assertEqual(dict(score.features)["L"].high, 0)
                self.assertEqual(dict(score.contributions)["H"].high, 0)

    def test_opaque_baseline_never_zero_scored_to_force_swap(self):
        d = self.cases["C05_opaque_baseline_effect"][1]
        self.assertEqual(d.reason, "OPAQUE_OR_UNSCORABLE_BASELINE")
        self.assertFalse(any(c.baseline_member for c in d.scores))
        self.assertIsNone(d.proposal)

    def test_actual_skill_cost_and_source_legality_exclude_invalid_action(self):
        d = self.cases["Mega_insufficient_actual_cost"][1]
        self.assertNotIn("SYNTHETIC_PROTECT", [s.action.card_source for s in d.scores])
        self.assertTrue(d.diagnostics.plain()["excluded_actions"])
        action = Action("pet_skill", card_source="BAD_SOURCE")
        spec = card(action, 1, 1)
        spec["source_valid"] = False
        d = plan(with_model(self.simple, action_models=[spec]))
        self.assertNotIn(action, [s.action for s in d.scores])

    def test_pass_only_with_explicit_permission_and_not_mandatory(self):
        pass_action = Action("pass")
        spec = card(pass_action, 0, 1, cost=0)
        no = plan(with_model(self.simple, action_models=[spec]))
        self.assertNotIn(pass_action, [s.action for s in no.scores])
        legal = self.simple.evidence("planner.legality").value.plain()
        legal.update(pass_allowed=True, mandatory=False)
        yes = plan(with_model(change(self.simple, "planner.legality", legal), action_models=[spec]))
        self.assertIn(pass_action, [s.action for s in yes.scores])

    def test_evolution_pending_and_nonconsuming_actions_remain_existing_owner(self):
        for name in ("P07_continuation_owned_by_existing_flow", "pending_boundary"):
            self.assertEqual(self.cases[name][1].reason, "EXISTING_OWNER_OR_PENDING_BOUNDARY")
        evolve = card(Action("evolve", card_source="SYNTHETIC"), 1, 1)
        d = plan(with_model(self.simple, action_models=[evolve]))
        self.assertNotIn("evolve", [s.action.family for s in d.scores])

    def test_buwin_local_hp_does_not_reverse_team_objective(self):
        low = self.cases["BuWin_local_death_intent"][1]
        high = self.cases["BuWin_healthy_same_intent"][1]
        self.assertEqual(low.proposal, high.proposal)
        self.assertEqual(low.disposition, "PROPOSE_OFFLINE")
        for score in low.scores:
            weights = score.details.plain()["weights"]
            self.assertEqual(weights["P"]["high"], 0)
            self.assertEqual(weights["T"]["high"], 0)
        self.assertIsNone(self.cases["BuWin_missing_team_context"][1].proposal)

    def test_buwin_no_solo_damage_skill_override(self):
        s = snapshot("bu_win", model_updates=dict(team_intent="FEED_BOSS_SWORD_AND_TURNOVER"))
        d = plan(with_model(s, action_models=[card(Action("pet_skill", card_source="SOLO"), 1, 1)]))
        self.assertNotIn("pet_skill", [v.action.family for v in d.scores])

    def test_low_hp_and_no_safe_moves_are_not_blanket_action_bans(self):
        s = snapshot(hp=1)
        values = evaluate_all_moves(s.board_state())
        risky = tuple(replace(v, sword_risk=replace(v.sword_risk, safe=False,
                                                  opponent_sword_reply_effective_max=2)) for v in values)
        with patch("pokiguard_v2.reasoning_planner.evaluate_all_moves", return_value=risky):
            d = plan(s)
        self.assertEqual(len(d.scores), len(values))
        self.assertTrue(all(dict(v.features)["T"].low > 0 for v in d.scores))
        action = Action("pet_skill", card_source="SUPPORTED_RISKY_FINISH")
        effect = card(action, 1, 0, cost=0, threat=.2)
        effect["effects"]["F"] = 1
        d = plan(with_model(s, action_models=[effect]))
        self.assertEqual(d.proposal, action)

    def test_margin_is_separate_from_total_order_and_keeps_baseline(self):
        base, other = Action("pet_skill", card_source="A"), Action("pet_skill", card_source="B")
        s = snapshot(baseline=base, model_updates=dict(action_models=[card(base, .9, 0), card(other, .901, 0)]))
        d = plan(s)
        self.assertEqual(d.reason, "NEAR_TIE_OR_ESSENTIAL_ASSUMPTION_SENSITIVE")
        self.assertIsNone(d.proposal)
        self.assertEqual(d.scores[0].action, other)

    def test_deterministic_json_replay_and_enumeration_order(self):
        s = self.demon
        first = plan(s)
        again = plan(ReasoningSnapshot.loads(s.dumps()))
        self.assertEqual(first.dumps(), again.dumps())
        values = list(evaluate_all_moves(s.board_state()))
        random.Random(11).shuffle(values)
        with patch("pokiguard_v2.reasoning_planner.evaluate_all_moves", return_value=tuple(values)):
            shuffled = plan(s)
        self.assertEqual(first.dumps(), shuffled.dumps())

    def test_bucket_total_order_is_transitive_and_canonical(self):
        d = plan(self.simple)
        keys = [order_key(c, "simple") for c in d.scores]
        self.assertEqual(keys, sorted(keys))
        self.assertEqual(len(keys), len(set(keys)))
        for a, b, c in zip(keys, keys[1:], keys[2:]):
            self.assertLess(a, b)
            self.assertLess(b, c)
            self.assertLess(a, c)

    def test_essential_missing_hp_or_effect_uses_intervals_or_retains(self):
        s = self.cases["mega_icarus_spam_skill:pressure_before_30"][0]
        s = change(s, "self.hp", None)
        d = plan(s)
        self.assertIsNone(d.proposal)
        self.assertEqual(d.diagnostics.plain()["pressure"]["high"], 1)
        self.assertEqual(d.diagnostics.plain()["pressure"]["low"], 0)

    def test_bad_scope_units_conversion_and_invalid_state_dispositions(self):
        bad_scope = dict(self.simple.evidence("planner.model").scope.plain(), session_id="OTHER")
        obs = dict(self.simple.observations)
        obs["planner.model"] = replace(obs["planner.model"], scope=type(obs["planner.model"].scope).of(bad_scope))
        cases = [replace(self.simple, observations=tuple(sorted(obs.items()))),
                 change(self.simple, "self.hp", 20, "rage_points"),
                 with_model(self.simple, conversion={"rage": 30, "mana": 20})]
        cells = [list(row) for row in self.simple.board]
        cells[0][0] = ("unknown", 1)
        cases.append(replace(self.simple, board=tuple(tuple(row) for row in cells)))
        for s in cases:
            d = plan(s)
            self.assertEqual(d.reason, "INVALID_OR_UNSUPPORTED_INPUT")
            self.assertIsNone(d.proposal)
            self.assertTrue(d.diagnostics.plain()["invalid_state_must_fail_closed"])

    def test_incomplete_card_effect_or_scope_cannot_force_comparison(self):
        action = Action("pet_skill", card_source="OPAQUE")
        spec = card(action, 1, 1)
        del spec["effects"]["P"]
        d = plan(with_model(self.simple, action_models=[spec]))
        self.assertEqual(d.reason, "INVALID_OR_UNSUPPORTED_INPUT")
        self.assertIsNone(d.proposal)

    def test_nonfinite_values_rejected_before_scoring(self):
        for value in (float("nan"), float("inf")):
            with self.assertRaises(ValueError):
                Bound.fixed(value)

    def test_missing_measured_execution_cost_is_interval_not_click_count_estimate(self):
        d = plan(with_model(self.simple, execution_costs={}))
        self.assertTrue(all(dict(c.features)["E"].status == "UNSUPPORTED" for c in d.scores))

    def test_continuous_adaptation_no_low_hp_step_function(self):
        for p in (0, .1, .69, .7, .71, 1):
            w = context_weights("mega_icarus_spam_skill", Bound.fixed(p), Bound.fixed(.5), False)
            self.assertAlmostEqual(w["P"].low, 4 * (1 + 2 * p))
            self.assertAlmostEqual(w["R"].low, 7.5)

    def test_historical_replay_missing_capabilities_retains_without_claiming_boss_action(self):
        for r in load_dataset(DATASET)[1]:
            d = plan(r.snapshot)
            self.assertEqual(d.disposition, "RETAIN_BASELINE")
            self.assertEqual(d.reason, "UNSUPPORTED_MODEL_OR_LEGALITY_CONTEXT")

    def test_pure_module_has_no_io_provider_executor_or_runtime_import(self):
        tree = ast.parse((ROOT / "src/pokiguard_v2/reasoning_planner.py").read_text(encoding="utf-8"))
        imports = [node.module for node in ast.walk(tree) if isinstance(node, ast.ImportFrom)]
        self.assertEqual(set(imports), {"__future__", "dataclasses", "typing", "board_simulator",
                                       "demon_aegis", "reasoning_snapshot", "state", "reasoning_full_action_planner",
                                       "reasoning_demon"})
        # D3 added a lazy route into this pure function. Its sibling setup and
        # completed-result validators do not belong to the worker's call path.
        demon = ast.parse((ROOT/'src/pokiguard_v2/reasoning_demon.py').read_text(encoding='utf-8'))
        pure_demon = next(n for n in demon.body if isinstance(n,ast.FunctionDef) and n.name=='plan_demon')
        self.assertEqual({n.module for n in ast.walk(pure_demon) if isinstance(n,ast.ImportFrom)},
            {'reasoning_planner','demon_aegis'})
        self.assertFalse({n.id for n in ast.walk(pure_demon) if isinstance(n,ast.Name)} &
            {'open','sleep','subprocess','ctypes','socket','requests','provider','executor','Path'})
        pure = ast.parse((ROOT / 'src/pokiguard_v2/reasoning_full_action_planner.py').read_text(encoding='utf-8'))
        self.assertEqual({n.module for n in ast.walk(pure) if isinstance(n,ast.ImportFrom)},
            {'reasoning_snapshot','board_simulator','basic_policy','reasoning_planner','state','reasoning_mega'})
        mega = ast.parse((ROOT/'src/pokiguard_v2/reasoning_mega.py').read_text(encoding='utf-8'))
        self.assertFalse({n.id for n in ast.walk(mega) if isinstance(n,ast.Name)} &
            {'open','sleep','subprocess','ctypes','socket','requests','provider','executor','Path'})
        self.assertFalse({n.id for n in ast.walk(pure) if isinstance(n,ast.Name)} &
            {'open','sleep','subprocess','ctypes','socket','requests','provider','executor'})
        names = {n.id for n in ast.walk(tree) if isinstance(n, ast.Name)}
        self.assertFalse(names & {"open", "sleep", "subprocess", "ctypes", "socket", "requests"})


if __name__ == "__main__":
    unittest.main()
