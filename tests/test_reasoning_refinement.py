from __future__ import annotations

import ast
from dataclasses import replace
from pathlib import Path
import unittest
from unittest.mock import patch

from pokiguard_v2.board_simulator import (
    SimulatedCell, evaluate_all_moves, resolve_known_swap_result,
)
from pokiguard_v2.reasoning_planner import Bound, plan
from pokiguard_v2.reasoning_refinement import (
    Exhausted, Limits, Work, aggregate, analyze_root, best_followup, branch_score,
    choose_roots, enumerate_known, nominal_replies, refine, trace_known_root,
    transition, updated_balances,
)
from pokiguard_v2.reasoning_replay import load_dataset
from pokiguard_v2.reasoning_snapshot import Action, FrozenJSON, ReasoningSnapshot, canonical_json
from pokiguard_v2.state import GemType
from tools.evaluate_reasoning_planner import DATASET, change, scenarios, snapshot, with_model
from tools.evaluate_reasoning_refinement import cases, focused_analysis, historical_evidence, scoped

ROOT = Path(__file__).resolve().parents[1]


class RefinementTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.cases = {name: s for name, s, _ in cases()}
        cls.r1 = {name: plan(s) for name, s in cls.cases.items()}
        cls.focused = {name: focused_analysis(s) for name, s in cls.cases.items()}
        cls.history = historical_evidence()

    def test_positive_sword_ties_all_retained_and_not_best_tie(self):
        a = self.focused["positive_sword_tie"]
        nominal = [s for s in a["scenarios"] if s["kind"] == "NOMINAL"]
        self.assertEqual(a["nominal_replies_total"], 3)
        self.assertEqual(a["nominal_replies_examined"], 3)
        self.assertEqual({s["boss_sword_effective"] for s in nominal}, {4})
        self.assertEqual(sorted(s["followup"]["passive_swords_max"] for s in nominal), [0, 0, 5])
        self.assertEqual(a["known_retained_swords_min"], 0)
        self.assertEqual(a["aggregate"]["nominal"]["low"], min(s["utility"]["low"] for s in nominal))

    def test_secondary_priority_unknown_keeps_shield_taking_alternative(self):
        a = self.focused["secondary_priority_unknown"]
        nominal = [s for s in a["scenarios"] if s["kind"] == "NOMINAL"]
        self.assertEqual(a["known_replies_total"], 5)
        self.assertEqual(len(nominal), 5)
        self.assertTrue(all(s["boss_sword_effective"] == 0 for s in nominal))
        self.assertTrue(any(s["boss_shield_physical"] > 0 for s in nominal))
        self.assertEqual(a["known_retained_swords_min"], 0)

    def test_max_effective_policy_is_not_max_physical(self):
        s = self.cases["effective_vs_physical"]
        b = tuple(tuple(SimulatedCell(GemType(g), m) for g,m in row) for row in s.board)
        w = Work(Limits(nodes=5000), lambda: 0, lambda: False)
        root = transition(b, s.baseline.move, w)
        replies = enumerate_known(root.after, w)
        nominal = nominal_replies(replies, True)
        self.assertEqual(len(nominal), 3)
        self.assertEqual({r.resources.effective(GemType.SWORD) for r in nominal}, {7})
        self.assertGreater(max(r.resources.cells(GemType.SWORD) for r in replies),
                           max(r.resources.cells(GemType.SWORD) for r in nominal))

    def test_bait_is_eligible_but_threat_cost_increases_with_pressure(self):
        healthy, low = self.focused["bait_healthy"], self.focused["bait_low_hp"]
        for a in (healthy, low):
            self.assertEqual(a["nominal_replies_total"], 1)
            self.assertEqual(a["known_retained_swords_min"], 4)
            self.assertEqual(a["pre_boss_setup_diagnostic"]["passive_swords_max"], 6)
            n = next(s for s in a["scenarios"] if s["kind"] == "NOMINAL")
            self.assertEqual(n["boss_sword_effective"], 6)
        self.assertLess(low["aggregate"]["nominal"]["low"], healthy["aggregate"]["nominal"]["low"])
        self.assertGreater(low["aggregate"]["lambda_bounds"]["low"], healthy["aggregate"]["lambda_bounds"]["low"])

    def test_unknown_stress_never_instantiates_favorable_gems(self):
        a = self.focused["positive_sword_tie"]
        stress = [s for s in a["scenarios"] if s["kind"] == "DEPENDENCY_KNOCKOUT"]
        self.assertEqual(len(stress), 2)
        self.assertGreater(a["root_unknown_cells"], 1)
        for s in stress:
            self.assertFalse(s["refill_instantiated"])
            self.assertFalse(s["reachable_world_proven"])
            self.assertEqual(s["favorable_refill_credit"], 0)
        self.assertFalse(a["aggregate"]["global_worst_case"])
        self.assertIsNone(a["aggregate"]["probability"])

    def test_aggregate_is_examined_stress_penalty_not_full_world_bound(self):
        a = aggregate([Bound.fixed(4), Bound.fixed(6)], [Bound.fixed(0)], Bound.fixed(0), False)
        self.assertEqual(a["nominal"]["low"], 4)
        self.assertEqual(a["final"]["low"], 3)
        self.assertFalse(a["global_worst_case"])

    def test_partial_nominal_ties_never_get_committed_future_utility(self):
        a = focused_analysis(self.cases["positive_sword_tie"], Limits(scenarios=1, nodes=5000))
        self.assertEqual(a["unexamined_nominal"], 2)
        self.assertFalse(a["completed"])
        self.assertIsNone(a["aggregate"])
        self.assertFalse(a["r2_guarantee"])

    def test_zero_scenario_budget_is_explicit_partial(self):
        a = focused_analysis(self.cases["positive_sword_tie"], Limits(scenarios=0, nodes=5000))
        self.assertFalse(a["completed"])
        self.assertEqual(a["nominal_replies_examined"], 0)

    def test_baseline_outside_top_score_always_in_refinement_set(self):
        s = self.cases["positive_sword_tie"]
        r1 = self.r1["positive_sword_tie"]
        self.assertNotEqual(r1.scores[0].action, s.baseline)
        roots = choose_roots(s, r1, 1)
        self.assertEqual(roots[0].action, s.baseline)
        r = refine(s, r1, Limits(roots=1), clock=lambda: 0).diagnostics.plain()
        self.assertEqual(r["chosen_root_ids"], [roots[0].candidate_id])
        self.assertGreater(r["unrefined_roots"], 0)

    def test_node_cap_discards_partial_root_and_retains_completed_r1(self):
        s = self.cases["simple_reference"]
        r1 = self.r1["simple_reference"]
        r = refine(s, r1, Limits(nodes=3), clock=lambda: 0)
        d = r.diagnostics.plain()
        self.assertEqual(d["nodes"], 3)
        self.assertEqual(d["stop_reason"], "NODE_CAP")
        self.assertEqual(d["analyses"], [])
        self.assertTrue(d["failure"]["partial_root_discarded"])
        self.assertIs(r.incumbent, r1)
        self.assertIsNone(r.research_candidate)

    def test_completed_root_survives_later_interruption_without_partial_proposal(self):
        s = self.cases["simple_reference"]
        n = self.focused["simple_reference"]["nodes"]
        r = refine(s, self.r1["simple_reference"], Limits(roots=2, nodes=n+1), clock=lambda: 0)
        d = r.diagnostics.plain()
        self.assertEqual(d["roots_completed"], 1)
        self.assertEqual(d["stop_reason"], "NODE_CAP")
        self.assertTrue(d["failure"]["partial_root_discarded"])
        self.assertIsNone(r.research_candidate)

    def test_pre_cancel_does_no_compute(self):
        s = self.cases["simple_reference"]
        r = refine(s, self.r1["simple_reference"], cancelled=lambda: True, clock=lambda: 0)
        self.assertEqual(r.diagnostics.plain()["stop_reason"], "CANCELLED")
        self.assertEqual(r.diagnostics.plain()["nodes"], 0)

    def test_cancel_during_search_discards_incomplete_branch(self):
        ticks = 0
        def cancel():
            nonlocal ticks
            ticks += 1
            return ticks >= 60
        s = self.cases["simple_reference"]
        r = refine(s, self.r1["simple_reference"], cancelled=cancel, clock=lambda: 0)
        self.assertEqual(r.diagnostics.plain()["stop_reason"], "CANCELLED")
        self.assertFalse(r.diagnostics.plain()["incomplete_root_results_exposed"])
        self.assertIsNone(r.research_candidate)

    def test_absolute_deadline_does_not_reset(self):
        s = self.cases["simple_reference"]
        r = refine(s, self.r1["simple_reference"], Limits(deadline_ms=100), clock=lambda: 100)
        d = r.diagnostics.plain()
        self.assertEqual(d["stop_reason"], "DEADLINE")
        self.assertEqual(d["nodes"], 0)
        self.assertEqual(d["deadline_resets"], 0)

    def test_primitive_finishing_after_deadline_is_discarded(self):
        now = [0]
        w = Work(Limits(deadline_ms=10), lambda: now[0], lambda: False)
        s = self.cases["simple_reference"]
        board = tuple(tuple(SimulatedCell(GemType(g), m) for g,m in row) for row in s.board)
        from pokiguard_v2.board_simulator import _resolve_known_reply
        def late(*args):
            value = _resolve_known_reply(*args)
            now[0] = 10
            return value
        with patch("pokiguard_v2.reasoning_refinement._resolve_known_reply", side_effect=late):
            with self.assertRaises(Exhausted):
                transition(board, s.baseline.move, w)
        self.assertEqual(w.stop, "DEADLINE")

    def test_limits_finite_and_strict(self):
        for args in (dict(nodes=True), dict(nodes=-1), dict(roots=9), dict(scenarios=33),
                     dict(duration_ms=6001), dict(duration_ms=float("nan"))):
            with self.subTest(args=args), self.assertRaises(ValueError):
                Limits(**args)

    def test_unsupported_no_reply_never_invents_pass_or_future(self):
        s = self.cases["simple_reference"]
        r1 = self.r1["simple_reference"]
        root = next(c for c in r1.scores if c.baseline_member)
        with patch("pokiguard_v2.reasoning_refinement.enumerate_known", return_value=()):
            a = analyze_root(s, root, Work(Limits(), lambda: 0, lambda: False), True, True, s.evidence("planner.model").value.plain())
        self.assertEqual(a["status"], "UNSUPPORTED_NO_KNOWN_REPLY_NO_INVENTED_PASS")
        self.assertFalse(a["completed"])

    def test_passive_root_residual_not_misrepresented_as_ordinary(self):
        s = next(s for n,s,_,_ in scenarios() if n == "D01_joint_3Sword_5Rage")
        r1 = plan(s)
        chosen = next(c for c in r1.scores if c.action == r1.proposal)
        a = analyze_root(s, chosen, Work(Limits(), lambda: 0, lambda: False), True, True, s.evidence("planner.model").value.plain())
        self.assertEqual(a["status"], "UNSUPPORTED_PASSIVE_ROOT_RESIDUAL")
        self.assertFalse(a["completed"])
        self.assertEqual(a["nodes"], 0)

    def test_opaque_card_baseline_stays_r1(self):
        s = snapshot("mega_icarus_spam_skill", baseline=Action("pet_skill", card_source="OPAQUE"))
        r1 = plan(s)
        r = refine(s, r1, clock=lambda: 0)
        self.assertIs(r.incumbent, r1)
        self.assertIsNone(r.research_candidate)
        self.assertFalse(r.to_dict()["r2_promotion"])

    def test_scope_conflict_returns_completed_incumbent_with_reason(self):
        s = self.cases["positive_sword_tie"]
        obs = dict(s.observations)
        ev = obs["planner.refinement"]
        obs["planner.refinement"] = replace(ev, scope=FrozenJSON.of(dict(ev.scope.plain(), boss="OTHER")))
        s = replace(s, observations=tuple(sorted(obs.items())))
        r1 = plan(s)
        r = refine(s, r1, clock=lambda: 0)
        self.assertIn("scope conflict", r.diagnostics.plain()["failure"]["error"])
        self.assertIs(r.incumbent, r1)

    def test_stale_snapshot_or_config_rejected(self):
        s = self.cases["positive_sword_tie"]
        r1 = self.r1["positive_sword_tie"]
        changed = change(s, "self.hp", 50)
        r = refine(changed, r1, clock=lambda: 0)
        self.assertIn("mismatch", r.diagnostics.plain()["failure"]["error"])
        self.assertIsNone(r.research_candidate)
        self.assertFalse(r.incumbent_usable)
        self.assertEqual(r.to_dict()["disposition"], "DISCARD_UNBOUND_INCUMBENT")
        self.assertIsNone(r.to_dict()["incumbent_proposal"])

    def test_duplicate_or_forged_candidate_membership_rejected(self):
        s = self.cases["simple_reference"]
        r1 = self.r1["simple_reference"]
        for invalid in (replace(r1, scores=r1.scores+(r1.scores[0],)),
                        replace(r1, scores=(replace(r1.scores[0], baseline_member=not r1.scores[0].baseline_member),)+r1.scores[1:])):
            r = refine(s, invalid, clock=lambda: 0)
            self.assertFalse(r.incumbent_usable)
            self.assertEqual(r.diagnostics.plain()["nodes"], 0)

    def test_invalid_observed_board_does_not_bypass_fail_closed_via_incumbent(self):
        s = self.cases["positive_sword_tie"]
        rows = [list(row) for row in s.board]
        rows[0][0] = ("unknown", 1)
        invalid = replace(s, board=tuple(tuple(row) for row in rows))
        r1 = replace(self.r1["positive_sword_tie"], snapshot_id=invalid.snapshot_id, scores=())
        r = refine(invalid, r1, clock=lambda: 0)
        self.assertFalse(r.incumbent_usable)
        self.assertIsNone(r.to_dict()["incumbent_proposal"])

    def test_unknown_turn_access_has_zero_lower_future_credit(self):
        s = self.cases["bait_healthy"]
        a = focused_analysis(s, turn_access=False)
        for branch in a["scenarios"]:
            if "followup" in branch:
                self.assertEqual(branch["followup"]["h"]["low"], 0)
                self.assertFalse(branch["followup"]["guarantee"])

    def test_followup_discount_once_and_no_full_second_utility(self):
        s = self.cases["bait_healthy"]
        root = next(c for c in self.r1["bait_healthy"].scores if c.baseline_member)
        future = dict(h=Bound.fixed(.5).to_dict())
        c = branch_score(s, root, future, .75, .5)
        self.assertEqual(dict(c.contributions)["H"].low, .5 * root.details.plain()["weights"]["H"]["low"])
        self.assertEqual(dict(c.features)["R"], dict(root.features)["R"])
        self.assertEqual(dict(c.features)["L"].low, 0)

    def test_root_resource_gain_is_not_credited_as_followup_gain_again(self):
        s = with_model(snapshot(mana=0), requirements={"mana": 60, "rage": 0})
        r1 = plan(s)
        root = max(r1.scores, key=lambda c: c.details.plain()["resources"]["mana"]["capped_gain_points"] or 0)
        future = updated_balances(s, root)
        amount = root.details.plain()["resources"]["mana"]
        self.assertEqual(future.evidence("self.mana").value.plain(), amount["current_points"]+amount["capped_gain_points"])
        self.assertEqual(future.evidence("self.hp").availability, "MISSING")

    def test_historical_ordinary_transitions_match_reused_public_solver(self):
        for r in load_dataset(DATASET)[1]:
            s = r.snapshot
            if s.baseline.family != "swap":
                continue
            board = tuple(tuple(SimulatedCell(GemType(g), m) for g,m in row) for row in s.board)
            t = transition(board, s.baseline.move, Work(Limits(), lambda: 0, lambda: False))
            value = next(v for v in evaluate_all_moves(s.board_state()) if v.move == s.baseline.move)
            self.assertEqual(t.resources, value.total)
            self.assertEqual(t.after, resolve_known_swap_result(board, s.baseline.move))

    def test_historical_forecast_references_match_without_boss_attribution(self):
        h = self.history
        self.assertEqual(h["applicable_forecasts_matched"], 23)
        self.assertEqual(h["applicable_forecasts"], 23)
        self.assertEqual(h["source_owner_local_root"], 23)
        self.assertEqual(h["observed_boss_actions"], 0)
        self.assertFalse(h["utility_or_r2_usable"])

    def test_incident_loss_and_retained_controls_remain_distinct(self):
        pairs = {(x["match_id"],x["turn"]):x for x in self.history["chosen_to_next_local_chains"]}
        for match,turn in (("M_7d274339",3),("M_7d274339",13),("M_bdaf6d3b",13),("M_632f0563",1)):
            self.assertEqual(pairs[match,turn]["actual_next_local_passive_swords"], 0)
            self.assertEqual(pairs[match,turn]["cause"], "UNKNOWN_BOSS_REFILL_EFFECT")
        self.assertEqual(pairs["M_7d274339",17]["actual_next_local_passive_swords"],4)
        self.assertEqual(pairs["M_632f0563",5]["actual_next_local_passive_swords"],3)

    def test_deterministic_work_budget_and_snapshot_replay(self):
        s = self.cases["positive_sword_tie"]
        r1 = self.r1["positive_sword_tie"]
        a = refine(s,r1,clock=lambda:0).to_dict()
        restored = ReasoningSnapshot.loads(s.dumps())
        b = refine(restored,plan(restored),clock=lambda:0).to_dict()
        self.assertEqual(canonical_json(a),canonical_json(b))

    def test_r2_promotion_and_input_authority_remain_false(self):
        for name,s in self.cases.items():
            r = refine(s,self.r1[name],clock=lambda:0)
            self.assertFalse(r.to_dict()["input_authority"])
            self.assertFalse(r.to_dict()["r2_promotion"])
            self.assertEqual(r.to_dict()["disposition"],"RETAIN_COMPLETED_R1")

    def test_historical_geometry_trace_has_no_utility_or_fake_actual_boss(self):
        trace = self.history["traces"][0]
        self.assertFalse(trace["utility_usable"])
        self.assertEqual(trace["boss_action"],"MISSING")
        for s in trace["analysis"]["scenarios"]:
            self.assertIsNone(s["utility"])
            if "observed_boss_action" in s:
                self.assertFalse(s["observed_boss_action"])

    def test_component_imports_no_io_provider_capture_or_executor(self):
        tree=ast.parse((ROOT/"src/pokiguard_v2/reasoning_refinement.py").read_text(encoding="utf-8"))
        imports={n.module for n in ast.walk(tree) if isinstance(n,ast.ImportFrom)}
        self.assertEqual(imports,{"__future__","dataclasses","typing","board_simulator","demon_aegis",
                                  "reasoning_planner","reasoning_snapshot","state"})
        names={n.id for n in ast.walk(tree) if isinstance(n,ast.Name)}
        self.assertFalse(names & {"open","subprocess","ctypes","socket","requests"})


if __name__ == "__main__":
    unittest.main()
