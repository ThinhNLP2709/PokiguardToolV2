"""Attribution negatives for the file-only skill audit, not gameplay tests."""
from copy import deepcopy
import json
from pathlib import Path
import tempfile
import unittest

from tools.audit_active_skill_inventory import analyze_rows, controller_join, inventory
from tests.reasoning_test_paths import reasoning_temp_root


def fixture():
    session = dict(lifecycle_epoch=1, board_instance=123, match_id="M_test")
    action = dict(value="unique", match_id="M_test", session_key=session,
                  source_turn=3, skill_card_id=99, local_actor=1)
    cap = dict(status="CURRENT", session_key=session, skill_card_id=99,
               skill_family="MEGA_TREX_CLICK_ONLY", element_type="MEGA_TREX",
               ownership_current=True, live_card_present=True, live_card_actionable=True,
               effective_mana_cost=200, effective_power_cost=200,
               effective_mana_cost_source="CONDITION_USE", effective_power_cost_source="POWER")
    result = dict(kind="SUCCESS_NO_ACTION", state="COMPLETE", action_id=action,
                  card_clicks=1, space_presses=0, direction_presses=0,
                  telemetry=dict(resources_before=[500, 250], resources_after=[700, 100],
                                 turn_before=3, turn_after=4, server_response_correlated=False),
                  post_state=dict(battle=dict(session_key=session, match_id="M_test",
                                              turn_number=4, srv_seq=11),
                                  player=dict(is_local=True, is_boss=False, mana=700, power=100)))
    rows = [(1, dict(event="pet_skill_capability_observed", capability=cap)),
            (2, dict(event="pet_skill_no_action_click_sent", actionId=action)),
            (3, dict(event="pet_skill_action_result", result=result))]
    identity = dict(action="pet_skill", source=dict(session=session, srv_seq=10, turn=3),
                    target=[session, 99])
    start = dict(identity=identity, currentMana=500, currentRage=250,
                 requiredMana=200, requiredRage=200)
    end = dict(identity=identity, result=deepcopy(result))
    index = dict(sends=[(10, start)], results=[(20, end)], typed=[], errors=[])
    return deepcopy(rows), deepcopy(index)


class ActiveSkillInventoryTests(unittest.TestCase):
    def test_exact_join_is_observation_not_server_effect_training(self):
        rows, idx = fixture()
        r = analyze_rows(rows)[0]
        self.assertTrue(r["logged_click_card_cost_join"])
        self.assertTrue(r["resource_endpoint_consistent"])
        self.assertEqual(r["resource_net_delta"], [200, -150])
        self.assertTrue(controller_join(r, idx)["controller_join_verified"])
        self.assertFalse(r["server_effect_binding_verified"])
        self.assertFalse(r["damage_training_eligible"])

    def test_success_label_with_zero_click_is_not_a_cast(self):
        rows, _ = fixture()
        rows.pop(1)
        rows[-1][1]["result"]["card_clicks"] = 0
        self.assertFalse(analyze_rows(rows)[0]["logged_click_card_cost_join"])

    def test_other_action_click_cannot_be_borrowed(self):
        rows, _ = fixture()
        rows[1][1]["actionId"] = dict(rows[1][1]["actionId"], value="other")
        self.assertFalse(analyze_rows(rows)[0]["exact_logged_click"])

    def test_duplicate_clicks_are_not_unique(self):
        rows, _ = fixture()
        rows.insert(2, (2, deepcopy(rows[1][1])))
        self.assertFalse(analyze_rows(rows)[0]["logged_click_card_cost_join"])

    def test_capability_after_click_is_not_pre_action_evidence(self):
        rows, _ = fixture()
        rows[0] = (2.5, rows[0][1])
        rows.sort(key=lambda item: item[0])
        self.assertFalse(analyze_rows(rows)[0]["capability_current"])

    def test_invalidated_latest_capability_cannot_reuse_old_current(self):
        rows, _ = fixture()
        stale = deepcopy(rows[0][1])
        stale["capability"].update(status="UNKNOWN", ownership_current=False)
        rows.insert(1, (1.5, stale))
        self.assertFalse(analyze_rows(rows)[0]["capability_current"])

    def test_changed_card_cannot_reuse_old_card_capability(self):
        rows, _ = fixture()
        other = deepcopy(rows[0][1])
        other["capability"]["skill_card_id"] = 100
        rows.insert(1, (1.5, other))
        self.assertFalse(analyze_rows(rows)[0]["capability_current"])

    def test_foreign_session_is_not_current(self):
        rows, _ = fixture()
        rows[0][1]["capability"]["session_key"] = dict(match_id="M_other")
        self.assertFalse(analyze_rows(rows)[0]["capability_current"])

    def test_missing_or_boolean_cost_is_not_free(self):
        for value in (None, True, -1):
            rows, _ = fixture()
            rows[0][1]["capability"]["effective_mana_cost"] = value
            self.assertFalse(analyze_rows(rows)[0]["logged_click_card_cost_join"])

    def test_unknown_cost_source_cannot_attest_cost(self):
        rows, _ = fixture()
        rows[0][1]["capability"]["effective_mana_cost_source"] = "UNKNOWN"
        self.assertFalse(analyze_rows(rows)[0]["logged_click_card_cost_join"])

    def test_unchanged_turn_is_not_a_resolved_resource_endpoint(self):
        rows, _ = fixture()
        result = rows[-1][1]["result"]
        result["telemetry"]["turn_after"] = 3
        result["post_state"]["battle"]["turn_number"] = 3
        r = analyze_rows(rows)[0]
        self.assertTrue(r["logged_click_card_cost_join"])
        self.assertFalse(r["resource_endpoint_consistent"])

    def test_terminal_missing_turn_is_not_filled_from_next_match(self):
        rows, _ = fixture()
        rows[-1][1]["result"]["post_state"]["battle"] = dict(match_id="M_next")
        self.assertFalse(analyze_rows(rows)[0]["resource_endpoint_consistent"])

    def test_endpoint_stats_must_match_telemetry(self):
        rows, _ = fixture()
        rows[-1][1]["result"]["post_state"]["player"]["mana"] = 600
        self.assertFalse(analyze_rows(rows)[0]["resource_endpoint_consistent"])

    def test_controller_result_requires_exact_action_id(self):
        rows, idx = fixture()
        idx["results"][0][1]["result"]["action_id"]["value"] = "other"
        self.assertFalse(controller_join(analyze_rows(rows)[0], idx)["controller_join_verified"])

    def test_controller_result_requires_same_cost_and_resources(self):
        for field in ("requiredMana", "currentMana"):
            rows, idx = fixture()
            idx["sends"][0][1][field] += 1
            self.assertFalse(controller_join(analyze_rows(rows)[0], idx)["controller_join_verified"])

    def test_controller_duplicate_results_fail_closed(self):
        rows, idx = fixture()
        idx["results"].append((21, deepcopy(idx["results"][0][1])))
        self.assertFalse(controller_join(analyze_rows(rows)[0], idx)["controller_join_verified"])

    def test_zero_input_retry_is_separate_from_later_success(self):
        rows, idx = fixture()
        first = deepcopy(idx["results"][0][1])
        first["result"].update(kind="INVALIDATED", card_clicks=0)
        first["result"]["action_id"]["value"] = "zero_input_attempt"
        idx["sends"].insert(0, (5, deepcopy(idx["sends"][0][1])))
        idx["results"].insert(0, (8, first))
        joined = controller_join(analyze_rows(rows)[0], idx)
        self.assertTrue(joined["controller_join_verified"])
        self.assertEqual(joined["controller_start_line"], 10)
        self.assertEqual(joined["previous_same_source_result_line"], 8)

    def test_malformed_telemetry_cannot_crash_or_attest_endpoint(self):
        rows, _ = fixture()
        rows[-1][1]["result"]["telemetry"] = "invalid"
        self.assertFalse(analyze_rows(rows)[0]["resource_endpoint_consistent"])

    def test_later_turn_endpoint_cannot_include_boss_action(self):
        rows, _ = fixture()
        result = rows[-1][1]["result"]
        result["telemetry"]["turn_after"] = 5
        result["post_state"]["battle"]["turn_number"] = 5
        self.assertFalse(analyze_rows(rows)[0]["resource_endpoint_consistent"])

    def test_server_metadata_is_not_typed_effect_binding(self):
        rows, idx = fixture()
        idx["skill_response_metadata"] = [(15, dict(event_type="MATCH_SKILL_USE_RES",
                                                    server_sequence=11, accepted=True))]
        r = controller_join(analyze_rows(rows)[0], idx)
        self.assertEqual(r["skill_response_metadata_candidates"], 1)
        self.assertFalse(r["metadata_only_response_is_effect_binding"])

    def test_byte_identical_archives_count_once(self):
        rows, _ = fixture()
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as folder:
            root = Path(folder)
            for name in ("one", "two"):
                target = root / name / "pet_skill_M_test_turn3.jsonl"
                target.parent.mkdir()
                target.write_text("\n".join(json.dumps(d) for _, d in rows), encoding="utf-8")
            result = inventory([root])
            self.assertEqual(result["input_file_count"], 2)
            self.assertEqual(result["duplicate_file_copies"], 1)
            self.assertEqual(len(result["records"]), 1)

    def test_distinct_files_same_action_are_quarantined(self):
        rows, _ = fixture()
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as folder:
            root = Path(folder)
            for name in ("one", "two"):
                target = root / name / "pet_skill_M_test_turn3.jsonl"
                target.parent.mkdir()
                data = deepcopy(rows)
                data[-1][1]["timestamp"] = name
                target.write_text("\n".join(json.dumps(d) for _, d in data), encoding="utf-8")
            result = inventory([root])
            self.assertEqual(len(result["conflicting_action_groups"]), 1)
            self.assertFalse(any(r["logged_click_card_cost_join"] for r in result["records"]))


if __name__ == "__main__":
    unittest.main()
