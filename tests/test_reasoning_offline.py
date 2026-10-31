from __future__ import annotations

import ast
from dataclasses import FrozenInstanceError, replace
import hashlib
from pathlib import Path
import sys
import tempfile
import unittest

ROOT = Path(__file__).resolve().parents[1]
sys.path.insert(0, str(ROOT / "src"))

from pokiguard_v2.reasoning_snapshot import (
    Action, CandidateRecord, Evidence, FrozenJSON, ReasoningSnapshot, SourceIdentity,
    canonical_json, strict_json_loads,
)
from pokiguard_v2.reasoning_replay import (
    ReplayRecord, link_next_observation, load_dataset, observation_links,
    outcome_for, replay_record, validate_candidate,
)
from pokiguard_v2.reasoning_telemetry import ReasoningEvent, replay_event
from tools.replay_reasoning import imported_record

DATASET = ROOT / "docs" / "phase5" / "datasets" / "manifest.json"


class ReasoningOfflineTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls) -> None:
        cls.manifest, cls.records = load_dataset(DATASET)
        cls.results = tuple(replay_record(record) for record in cls.records)
        cls.record = cls.records[0]
        cls.result = cls.results[0]

    def test_snapshot_and_candidate_roundtrip(self) -> None:
        for record, result in zip(self.records, self.results):
            snapshot = ReasoningSnapshot.loads(record.snapshot.dumps())
            self.assertEqual(snapshot.snapshot_id, record.snapshot.snapshot_id)
            self.assertEqual(snapshot.dumps(), record.snapshot.dumps())
            self.assertEqual(ReplayRecord.loads(record.dumps()).dumps(), record.dumps())
            for candidate in result.candidates:
                restored = CandidateRecord.from_dict(candidate.to_dict())
                self.assertEqual(restored.to_dict(), candidate.to_dict())

    def test_replay_and_event_determinism(self) -> None:
        again = replay_record(ReplayRecord.loads(self.record.dumps()))
        self.assertEqual([c.to_dict() for c in again.candidates],
                         [c.to_dict() for c in self.result.candidates])
        event = replay_event(self.result, 1)
        self.assertEqual(event.dumps(), replay_event(again, 1).dumps())
        self.assertEqual(ReasoningEvent.loads(event.dumps()).dumps(), event.dumps())

    def test_deep_config_and_snapshot_immutability(self) -> None:
        mutable = {"nested": {"values": [1, 2]}}
        frozen = FrozenJSON.of(mutable)
        mutable["nested"]["values"][0] = 999
        detached = frozen.plain()
        detached["nested"]["values"].append(3)
        self.assertEqual(frozen.plain(), {"nested": {"values": [1, 2]}})
        with self.assertRaises(FrozenInstanceError):
            self.record.snapshot.intent.profile = "bu_win"
        payload = self.record.snapshot.to_dict()
        payload["board"][0][0][0] = "unknown"
        self.assertNotEqual(payload["board"], self.record.snapshot.to_dict()["board"])

    def test_missing_values_are_not_zero(self) -> None:
        snapshot = self.record.snapshot
        self.assertEqual(snapshot.evidence("self.rage").value.plain(), 0)
        self.assertEqual(snapshot.evidence("self.rage").availability, "PRESENT")
        for name in ("identity.account_binding", "gate.pending", "timing.observed_monotonic_ms",
                     "not_published"):
            value = snapshot.evidence(name)
            self.assertIsNone(value.value.plain())
            self.assertEqual(value.availability, "MISSING")
        with self.assertRaises(ValueError):
            replace(snapshot.evidence("self.hp"), value=FrozenJSON.of(None))

    def test_json_rejects_nonfinite_duplicate_deep_and_oversize(self) -> None:
        for invalid in ('{"a":1,"a":2}', '{"a":NaN}', '{"a":1e999}',
                        "[" * 40 + "0" + "]" * 40):
            with self.subTest(invalid=invalid[:30]), self.assertRaises(ValueError):
                strict_json_loads(invalid)
        with self.assertRaises(ValueError):
            FrozenJSON.of({"bad": float("inf")})
        with self.assertRaises(ValueError):
            strict_json_loads('"' + "ộ" * 200_000 + '"')

    def test_malformed_schema_shape_multiplier_and_field_types(self) -> None:
        snapshot = self.record.snapshot
        for mutate in (
            lambda p: p.update(schema="v999"),
            lambda p: p.update(unexpected=True),
            lambda p: p["board"].pop(),
            lambda p: p["board"][0].__setitem__(0, ["mana", 8]),
            lambda p: p["board"][0].__setitem__(0, ["mana", True]),
            lambda p: p["source"].update(turn=True),
            lambda p: p["baseline"].update(move=[[0, 0], [0, 2]]),
            lambda p: p["recorded"].update(ordinary_resources=[["mana", -1, 3]]),
        ):
            payload = snapshot.to_dict()
            mutate(payload)
            with self.assertRaises(ValueError):
                ReasoningSnapshot.from_dict(payload)

    def test_all_proven_multiplier_tiers_roundtrip(self) -> None:
        for multiplier in range(1, 8):
            payload = self.record.snapshot.to_dict()
            payload["board"][0][0][1] = multiplier
            restored = ReasoningSnapshot.from_dict(payload)
            self.assertEqual(restored.board_state().cells[0][0].multiplier, multiplier)

    def test_incomplete_observed_board_fails_closed_without_work(self) -> None:
        for gem, multiplier in (("unknown", 1), ("mana", None)):
            payload = self.record.snapshot.to_dict()
            payload["board"][0][0] = [gem, multiplier]
            snapshot = ReasoningSnapshot.from_dict(payload)
            record = replace(self.record, snapshot=snapshot, chosen=None)
            result = replay_record(record)
            self.assertEqual(result.status, "UNSUPPORTED")
            self.assertEqual(result.candidates, ())
            self.assertEqual(replay_event(result, 0).payload.plain()["work_completed"]["adjacent_pairs"], 0)

    def test_chosen_action_source_and_candidate_identity_rejection(self) -> None:
        for name, value in (("run_id", "other"), ("session_id", "other"), ("match_id", "other"),
                            ("turn", 999), ("srv_seq", 999), ("board_hash", "other"),
                            ("actor_id", 2), ("controller_generation", 42)):
            source = replace(self.record.snapshot.source, **{name: value})
            with self.subTest(field=name), self.assertRaises(ValueError):
                replace(self.record, chosen=replace(self.record.chosen, source=source))
            candidate = replace(self.result.candidates[0], source=source)
            with self.subTest(field=name), self.assertRaises(ValueError):
                validate_candidate(self.record.snapshot, candidate)
        payload = self.result.candidates[0].to_dict()
        payload["candidate_id"] = "forged"
        with self.assertRaises(ValueError):
            CandidateRecord.from_dict(payload)
        with self.assertRaises(ValueError):
            replace(self.record, chosen=replace(self.record.chosen, snapshot_id="other"))

    def test_only_observed_chosen_action_can_have_outcome(self) -> None:
        synthetic_terminal = Evidence.observed("WIN", "terminal_result", "test-only",
                                               origin="SYNTHETIC_SPEC")
        record = replace(self.record, terminal=synthetic_terminal)
        baseline = next(c for c in self.result.candidates if c.baseline_member)
        other = next(c for c in self.result.candidates if not c.baseline_member)
        self.assertEqual(outcome_for(record, baseline).value.plain(), "WIN")
        self.assertEqual(outcome_for(record, other).availability, "MISSING")
        with self.assertRaises(ValueError):
            replace(record, chosen=None)
        self.assertTrue(all(r.terminal.availability == "MISSING" for r in self.records))

    def test_unknown_or_opaque_baseline_is_not_scored_as_zero(self) -> None:
        snapshot = replace(self.record.snapshot, baseline=Action("pet_skill", card_source="UNKNOWN"))
        record = replace(self.record, snapshot=snapshot, chosen=None)
        result = replay_record(record)
        self.assertEqual(result.status, "UNSUPPORTED")
        self.assertTrue(all(not c.baseline_member for c in result.candidates))
        self.assertIsNone(replay_event(result, 0).payload.plain()["proposal_candidate_id"])

    def test_event_bounds_and_correlation(self) -> None:
        event = replay_event(self.result, 0)
        self.assertLessEqual(len(event.dumps().encode("utf-8")), 16 * 1024)
        payload = event.to_dict()
        payload["source"]["match_id"] = "wrong"
        with self.assertRaises(ValueError):
            ReasoningEvent.loads(canonical_json(payload))
        payload = event.payload.plain()
        payload["candidate_summaries"] *= 7
        with self.assertRaises(ValueError):
            replace(event, payload=FrozenJSON.of(payload))
        oversized = event.payload.plain()
        oversized["detail"] = "ộ" * 6000
        huge = replace(event, payload=FrozenJSON.of(oversized))
        with self.assertRaises(ValueError):
            huge.dumps()
        self.assertIsNone(event.job_id)
        self.assertIsNone(event.dispatched_action_id)
        self.assertEqual(event.payload.plain()["disposition"], "REPLAY_ONLY_NO_PROPOSAL")

    def test_event_rejects_config_chosen_and_production_selection_mismatch(self) -> None:
        event = replay_event(self.result, 0)
        with self.assertRaises(ValueError):
            replace(event, config_hash="wrong")
        for key, value in (("recorded_chosen_candidate_id", "wrong"),
                           ("baseline_candidate_id", "wrong"),
                           ("selected_candidate_id", "wrong"), ("mode", "LIVE")):
            payload = event.payload.plain()
            payload[key] = value
            with self.subTest(field=key), self.assertRaises(ValueError):
                replace(event, payload=FrozenJSON.of(payload))
        payload = event.to_dict()
        payload["event_id"] = "forged"
        with self.assertRaisesRegex(ValueError, "event ID"):
            ReasoningEvent.loads(canonical_json(payload))
        payload = event.to_dict()
        payload["clock"]["utc"] = "invented"
        with self.assertRaises(ValueError):
            ReasoningEvent.loads(canonical_json(payload))

    def test_historical_mechanics_regression_and_full_chain(self) -> None:
        historical = self.results[:26]
        self.assertEqual(len(self.records), 27)
        self.assertEqual(len({r.record.snapshot.source.match_id for r in historical}), 3)
        self.assertTrue(all(r.status == "MATCH" for r in self.results))
        self.assertEqual(sum(r.checks.plain()["resources_match"] is True for r in historical), 26)
        self.assertEqual(sum(r.checks.plain()["forecast_match"] is True for r in historical), 23)
        self.assertEqual(sum(r.checks.plain()["forecast_match"] is None for r in historical), 3)
        turns = [r.record.snapshot.source.turn for r in historical
                 if r.record.snapshot.source.match_id == "M_7d274339"]
        self.assertEqual(turns, list(range(1, 20, 2)))
        self.assertEqual(len(observation_links(self.records)), 23)

    def test_archived_ten_snapshots_match_normalized_source(self) -> None:
        archive = strict_json_loads((ROOT / "docs/phase5/research/artifacts/"
                                    "demon_shield_incident_evidence_20261009.json").read_text("utf-8"))
        normalized = {(r.snapshot.provenance.path, r.snapshot.provenance.line): r.snapshot
                      for r in self.records}
        for archived in archive["archivedSnapshots"]:
            snapshot = normalized[archived["source"], archived["sourceLine"]]
            self.assertEqual(snapshot.to_dict()["board"], archived["board"])
            self.assertEqual(snapshot.provenance.file_sha256, archived["sourceFileSha256"])
            self.assertEqual(snapshot.source.board_hash, archived["boardHash"])

    def test_dsi_lost_and_retained_setup_controls(self) -> None:
        by_turn = {r.record.snapshot.source.turn: r for r in self.results
                   if r.record.snapshot.source.match_id == "M_7d274339"}
        for before, after, expected in ((3, 5, 3), (13, 15, 4), (17, 19, 4)):
            self.assertEqual(by_turn[before].checks.plain()["pre_boss_forecast_sword_cells"], expected)
            following = by_turn[after]
            # Match the documented BASIC passive comparison scope only.
            passive = [dict(c.features)["shield_sweep"].value.plain()["sword_physical"]
                       for c in following.candidates
                       if dict(c.features)["ordinary_resources"].value.plain()["sword"]["physical"] == 0]
            self.assertEqual(max(passive), 4 if after == 19 else 0)
        owners = [r.snapshot.evidence("legacy.last_move_owner").value.plain()
                  for r in self.records[:26]]
        self.assertEqual(owners.count("LOCAL_ROOT"), 23)
        self.assertTrue(all(r.boss_action.availability == "MISSING" for r in self.records))

    def test_next_observation_rejects_cross_match_actor_and_past(self) -> None:
        current, following = self.records[:2]
        link = link_next_observation(current, following).plain()
        self.assertEqual(link["turn_gap"], 2)
        for name, value in (("match_id", "other"), ("session_id", "other"), ("actor_id", 2),
                            ("turn", current.snapshot.source.turn)):
            snapshot = replace(following.snapshot,
                               source=replace(following.snapshot.source, **{name: value}))
            with self.assertRaises(ValueError):
                link_next_observation(current, replace(following, snapshot=snapshot, chosen=None))

    def test_importer_rejects_wrong_action_source_and_coordinate_domain(self) -> None:
        snapshot = self.record.snapshot
        source = snapshot.source
        row = dict(event="policy_decision", session={"match_id": source.match_id,
                   "lifecycle_epoch": 142}, matchId=source.match_id, turn=source.turn,
                   srvSeq=source.srv_seq, boardHash=source.board_hash,
                   boardSnapshotOrder="screen_rows_top_to_bottom_columns_left_to_right",
                   boardSnapshot=snapshot.to_dict()["board"], playStyle="demon_aegis_farm",
                   selectedAction="swap", move={"first": list(snapshot.baseline.move.first),
                   "second": list(snapshot.baseline.move.second)}, resources=[["mana", 3, 3]],
                   policyStep="SETUP")
        sent = dict(row, event="action_sent", boardHash="wrong")
        with self.assertRaises(ValueError):
            imported_record(row, sent, snapshot.provenance, self.record.chosen.sent_record,
                            {"boss": "fixture", "logDate": "fixture", "swordSetting": 3})
        row["boardSnapshotOrder"] = "native_bottom_up"
        with self.assertRaises(ValueError):
            imported_record(row, dict(row, event="action_sent"), snapshot.provenance,
                            self.record.chosen.sent_record,
                            {"boss": "fixture", "logDate": "fixture", "swordSetting": 3})

    def _temporary_dataset(self, entries):
        temporary_root = (ROOT / "temp").resolve()
        self.assertTrue(temporary_root.is_relative_to(ROOT))
        temporary_root.mkdir(exist_ok=True)
        context = tempfile.TemporaryDirectory(prefix="phase5b1_", dir=temporary_root)
        self.addCleanup(context.cleanup)
        folder = Path(context.name)
        self.assertTrue(folder.resolve().is_relative_to(temporary_root))
        manifest = self.manifest.plain()
        manifest["entries"] = []
        for index, (records, split, tier) in enumerate(entries):
            filename = f"records{index}.jsonl"
            content = ("\n".join(r.dumps() for r in records) + "\n").encode("utf-8")
            (folder / filename).write_bytes(content)
            manifest["entries"].append(dict(path=filename, sha256=hashlib.sha256(content).hexdigest(),
                                             records=len(records), split=split, tier=tier))
        path = folder / "manifest.json"
        path.write_text(canonical_json(manifest), encoding="utf-8")
        return path

    def test_dataset_hash_corruption_and_duplicate_continuation_rejected(self) -> None:
        path = self._temporary_dataset([([self.record], "development", "H")])
        (path.parent / "records0.jsonl").write_text("corrupt\n", encoding="utf-8")
        with self.assertRaisesRegex(ValueError, "SHA256"):
            load_dataset(path)
        path = self._temporary_dataset([([self.record, self.record], "development", "H")])
        with self.assertRaisesRegex(ValueError, "duplicate snapshot"):
            load_dataset(path)

    def test_dataset_no_same_match_or_session_leak_and_no_inspected_holdout(self) -> None:
        a, b = self.records[:2]
        path = self._temporary_dataset([([a], "development", "H"), ([b], "regression", "H")])
        with self.assertRaisesRegex(ValueError, "leaked"):
            load_dataset(path)
        path = self._temporary_dataset([([a], "holdout", "H")])
        with self.assertRaisesRegex(ValueError, "previously inspected"):
            load_dataset(path)

    def test_dataset_tier_mismatch_and_path_escape_rejected(self) -> None:
        path = self._temporary_dataset([([self.record], "development", "L")])
        with self.assertRaisesRegex(ValueError, "tier/provenance"):
            load_dataset(path)
        manifest = strict_json_loads(path.read_text("utf-8"))
        manifest["entries"][0]["path"] = "../escaped.jsonl"
        path.write_text(canonical_json(manifest), encoding="utf-8")
        with self.assertRaisesRegex(ValueError, "unsafe"):
            load_dataset(path)

    def test_new_modules_have_no_production_io_authority_imports(self) -> None:
        forbidden = ("farm_runner", "live_state", "memory", "capture", "executor",
                     "input_delivery", "ctypes", "subprocess", "socket")
        for name in ("reasoning_snapshot.py", "reasoning_replay.py", "reasoning_telemetry.py"):
            tree = ast.parse((ROOT / "src/pokiguard_v2" / name).read_text("utf-8"))
            imports = []
            for node in ast.walk(tree):
                if isinstance(node, ast.Import):
                    imports.extend(alias.name for alias in node.names)
                elif isinstance(node, ast.ImportFrom):
                    imports.append(node.module or "")
            self.assertFalse([module for module in imports
                              if any(part in module for part in forbidden)], name)


if __name__ == "__main__":
    unittest.main()
