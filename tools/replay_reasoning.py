#!/usr/bin/env python3
"""File-only Phase 5B.1 import/replay. Never starts the tool or attaches a game."""
from __future__ import annotations

import argparse
import hashlib
from pathlib import Path
import re
import sys
from typing import Any, Sequence

PROJECT_ROOT = Path(__file__).resolve().parents[1]
sys.path.insert(0, str(PROJECT_ROOT / "src"))

from pokiguard_v2.board_simulator import SwapMove, evaluate_all_moves
from pokiguard_v2.reasoning_snapshot import (
    Action, Evidence, FrozenJSON, ReasoningSnapshot, RunIntent, SourceIdentity,
    SourceRecord, canonical_json, integer, require, strict_json_loads,
)
from pokiguard_v2.reasoning_replay import (
    ChosenAction, DATASET_SCHEMA, MAX_DATASET_BYTES, ReplayRecord, load_dataset,
    observation_links, replay_record,
)
from pokiguard_v2.reasoning_telemetry import replay_event


def workspace_path(relative: str) -> Path:
    path = (PROJECT_ROOT / relative).resolve()
    require(path.is_relative_to(PROJECT_ROOT), "path must stay within V2 workspace")
    return path


def file_hash(path: Path) -> str:
    require(path.stat().st_size <= MAX_DATASET_BYTES, "source file too large")
    return hashlib.sha256(path.read_bytes()).hexdigest()


def source_record(path: str, file_sha: str, line: int, raw: str) -> SourceRecord:
    return SourceRecord(path, line, file_sha, hashlib.sha256(raw.encode("utf-8")).hexdigest())


def imported_record(row: dict[str, Any], sent: dict[str, Any], provenance: SourceRecord,
                    sent_provenance: SourceRecord, scope: dict[str, Any],
                    returned: dict[str, Any] | None = None) -> ReplayRecord:
    require(row["event"] == "policy_decision" and sent["event"] == "action_sent",
            "wrong legacy event type")
    require(row.get("boardSnapshotOrder") ==
            "screen_rows_top_to_bottom_columns_left_to_right", "unknown board coordinate order")
    for key in ("session", "matchId", "turn", "srvSeq", "boardHash", "move", "selectedAction",
                "boardSnapshot", "playStyle"):
        require(row.get(key) == sent.get(key), f"action_sent source mismatch: {key}")
    require(row["selectedAction"] == "swap" and row["playStyle"] == "demon_aegis_farm",
            "incident importer supports Demon swap only")
    session = row["session"]
    require(session["match_id"] == row["matchId"], "legacy session mismatch")
    epoch = integer(session["lifecycle_epoch"], "session epoch", 1)
    run_id = provenance.path.split("/")[2]
    ref = f"{provenance.path}:{provenance.line}"
    actor_id = row.get("player", {}).get("actor_number")
    source = SourceIdentity(run_id, f"{run_id}:epoch:{epoch}:match:{row['matchId']}",
                            row["matchId"], row["turn"], row.get("srvSeq"),
                            row["boardHash"], actor_id, None)
    move = row["move"]
    action = Action.from_dict(dict(family="swap", move=[move["first"], move["second"]],
                                   card_source=None))
    observations = {}
    for role, source_name in (("self", "player"), ("boss", "boss")):
        actor = row.get(source_name) or {}
        for name, source_field, unit in (
            ("hp", "hp", "hp_points"), ("max_hp", "max_hp", "hp_points"),
            ("mana", "mana", "mana_points"), ("max_mana", "max_mana", "mana_points"),
            ("rage", "power", "rage_points"), ("max_rage", "max_power", "rage_points"),
            ("shield", "shield", "shield_points"), ("attack", "attack", "attack_points"),
        ):
            observations[f"{role}.{name}"] = Evidence.observed(actor.get(source_field), unit, ref)
    remaining = row.get("timerRemaining")
    require(remaining is None or type(remaining) in (int, float), "invalid legacy timer")
    observations["timing.remaining_ms"] = Evidence.observed(
        remaining * 1000 if remaining is not None else None, "milliseconds", ref)
    observations["timing.recorded_timestamp"] = Evidence.observed(
        row.get("timestamp"), "legacy_timestamp_domain_unverified", ref)
    for name, unit, reason in (
        ("timing.observed_monotonic_ms", "milliseconds", "LEGACY_CLOCK_DOMAIN_NOT_RECORDED"),
        ("source.controller_generation", "generation", "NOT_RECORDED"),
        ("identity.account_binding", "identity", "NOT_PUBLISHED"),
        ("gate.stop", "boolean", "NOT_ARCHIVED"),
        ("gate.pending", "boolean", "NOT_ARCHIVED"),
        ("capability.effect_order", "effect_order", "NOT_VALIDATED"),
    ):
        observations[name] = Evidence.observed(None, unit, ref, reason=reason)
    trace = row.get("trace") or {}
    observations["gate.pass_status"] = Evidence.observed(trace.get("skip_status"), "status", ref)
    for name, unit in (("skill_actionable", "boolean"), ("required_mana", "mana_points"),
                       ("required_rage", "rage_points")):
        observations[f"capability.trace_{name}"] = Evidence.observed(
            trace.get(name), unit, ref, support="UNKNOWN",
            scope={"published_policy_trace_only": True, "not_authority": True})
    why = trace.get("why_selected") or row["policyStep"]
    forecast = re.search(r"nextBestBlastSwordCells=(\d+)", why)
    owner = None
    if returned is not None:
        prior = returned.get("priorAction") or {}
        prior_source = prior.get("source") or {}
        require(prior_source.get("session") == session and
                prior_source.get("turn") == row["turn"] and
                prior_source.get("board_hash") == row["boardHash"],
                "LOCAL_TURN_RETURNED source-owner mismatch")
        runtime = returned.get("runtime") or {}
        require(runtime.get("match_id") == row["matchId"] and
                runtime.get("turn") > row["turn"], "invalid returned local observation")
        if all(type(runtime.get(key)) is int and 0 <= runtime[key] < 8 for key in (
            "last_move_from_row", "last_move_from_col", "last_move_to_row", "last_move_to_col",
        )):
            native = Action("swap", SwapMove(
                (7 - runtime["last_move_from_row"], runtime["last_move_from_col"]),
                (7 - runtime["last_move_to_row"], runtime["last_move_to_col"])))
            owner = "LOCAL_ROOT" if native.to_dict() == action.to_dict() else "UNKNOWN"
    observations["legacy.last_move_owner"] = Evidence.observed(
        owner, "owner_classification", ref, origin="DERIVED_SOLVER",
        reason="NO_BOUND_RETURN_RECORD", scope={"boss_move_not_observed": True})
    intent_scope = dict(dataset_tier="H", previously_inspected=True,
                        runtime_binary_fingerprint="UNKNOWN_FROM_REVIEWED_LOGS",
                        boss=scope["boss"], log_date=scope["logDate"],
                        account_binding="NOT_PUBLISHED", evidence_origin="OBSERVED_SNAPSHOT")
    intent = RunIntent("demon_aegis_farm", FrozenJSON.of(
        {"recorded_sword_setting": scope["swordSetting"], "intelligence": "basic",
         "other_settings": "NOT_ARCHIVED"}),
        FrozenJSON.of({"feature_schema": "v1", "utility": "NOT_IMPLEMENTED",
                       "model": "NONE", "calibration": "NOT_VALIDATED_IN_B1"}),
        FrozenJSON.of(intent_scope))
    snapshot = ReasoningSnapshot(
        source, provenance, tuple(tuple(tuple(cell) for cell in r) for r in row["boardSnapshot"]),
        intent, action, why, tuple(sorted(observations.items())),
        FrozenJSON.of(dict(ordinary_resources=row["resources"],
                           pre_boss_forecast_sword_cells=int(forecast[1]) if forecast else None,
                           policy_step=row["policyStep"])))
    native_id = Evidence.observed(None, "action_id", sent_provenance.path,
                                  reason="NO_NATIVE_ACTION_ID_IN_ARCHIVED_EVENT")
    chosen = ChosenAction(snapshot.snapshot_id, source, action, sent_provenance, native_id)
    return ReplayRecord(snapshot, chosen,
                        Evidence.observed(None, "terminal_result", ref,
                                          reason="TERMINAL_ATTRIBUTION_NOT_ARCHIVED_IN_THIS_DATASET"),
                        Evidence.observed(None, "boss_swap", ref,
                                          reason="NOT_RECORDED; LAST_MOVE_IS_LOCAL_OR_UNKNOWN"))


def import_incident(archive_path: Path) -> tuple[list[ReplayRecord], dict[str, Any]]:
    require(archive_path.is_relative_to(PROJECT_ROOT), "archive outside workspace")
    archive = strict_json_loads(archive_path.read_text(encoding="utf-8"))
    require(archive.get("schema") == "pokiguard.incident_evidence.v1",
            "unsupported incident archive")
    scope = archive["scope"]
    records = []
    by_location = {}
    sources = []
    for match in archive["existingCoreReplay"]["matches"]:
        relative = match["source"]
        path = workspace_path(relative)
        sha = file_hash(path)
        require(sha == match["sourceSha256"], "historical source hash mismatch")
        lines = path.read_text(encoding="utf-8").splitlines()
        rows = [strict_json_loads(line) for line in lines]
        expected_lines = {row["line"] for row in match["rows"]}
        require(expected_lines == {i + 1 for i, row in enumerate(rows)
                                   if row.get("event") == "policy_decision"},
                "timeline is incomplete or has extra decisions")
        for line_number in sorted(expected_lines):
            row = rows[line_number - 1]
            require(row.get("matchId") == match["matchId"], "timeline match mismatch")
            stop = next((i for i in range(line_number, len(rows))
                         if rows[i].get("event") == "policy_decision"), len(rows))
            after = [(i, rows[i]) for i in range(line_number, stop)]
            sent = [(i, r) for i, r in after if r.get("event") == "action_sent"]
            require(len(sent) == 1, "missing/ambiguous action_sent")
            returned = [r for _, r in after if r.get("event") == "turn_transition" and
                        r.get("kind") == "LOCAL_TURN_RETURNED"]
            require(len(returned) <= 1, "ambiguous returned observation")
            sent_index, sent_row = sent[0]
            record = imported_record(
                row, sent_row, source_record(relative, sha, line_number, lines[line_number - 1]),
                source_record(relative, sha, sent_index + 1, lines[sent_index]), scope,
                returned[0] if returned else None)
            records.append(record)
            by_location[(relative, line_number)] = record
        sources.append(dict(path=relative, sha256=sha, records=len(expected_lines)))
    for archived in archive["archivedSnapshots"]:
        record = by_location[(archived["source"], archived["sourceLine"])]
        snapshot = record.snapshot
        require(snapshot.provenance.file_sha256 == archived["sourceFileSha256"] and
                snapshot.source.match_id == archived["matchId"] and
                snapshot.source.turn == archived["turn"] and
                snapshot.source.board_hash == archived["boardHash"] and
                snapshot.to_dict()["board"] == archived["board"] and
                snapshot.baseline.to_dict() == Action.from_dict(dict(
                    family="swap", move=[archived["selectedMove"]["first"],
                                         archived["selectedMove"]["second"]],
                    card_source=None)).to_dict(), "archived snapshot/source mismatch")
    sources.append(dict(path=archive_path.relative_to(PROJECT_ROOT).as_posix(),
                        sha256=file_hash(archive_path), archived_snapshots=10))
    return records, dict(sources=sources, matched_archived_snapshots=len(archive["archivedSnapshots"]))


def synthetic_record() -> ReplayRecord:
    relative = "reference/phase2c2a_basic_policy_fixture.json"
    path = workspace_path(relative)
    payload = strict_json_loads(path.read_text(encoding="utf-8"))
    ref = SourceRecord(relative, 1, file_hash(path), file_hash(path))
    from pokiguard_v2.state import BoardState, CellState, GemType
    board = BoardState(tuple(tuple(CellState(r, c, GemType(payload["gems"][r][c]),
                                            payload["multipliers"][r][c])
                                  for c in range(8)) for r in range(8)))
    move = evaluate_all_moves(board)[0]
    source = SourceIdentity("synthetic_fixture", "synthetic_fixture_session",
                            "synthetic_fixture_match", 1, None, "synthetic:" + file_hash(path),
                            None, None)
    intent = RunIntent("simple", FrozenJSON.of({"settings": "NOT_DEFINED; MECHANICS_ONLY"}),
                       FrozenJSON.of({"utility": "NOT_IMPLEMENTED", "model": "NONE"}),
                       FrozenJSON.of(dict(dataset_tier="S", previously_inspected=True,
                                          evidence_origin="SYNTHETIC_SPEC")))
    snapshot = ReasoningSnapshot(
        source, ref, tuple(tuple((cell.gem.value, cell.multiplier) for cell in row)
                           for row in board.cells), intent, Action("swap", move.move),
        "SYNTHETIC_MECHANICAL_ROOT; NOT_A_BASIC_ENGINE_DECISION", (),
        FrozenJSON.of({"ordinary_resources": None, "pre_boss_forecast_sword_cells": None}))
    missing = Evidence.observed(None, "terminal_result", relative, origin="SYNTHETIC_SPEC",
                                reason="SYNTHETIC_HAS_NO_GAME_OUTCOME")
    return ReplayRecord(snapshot, None, missing, Evidence.observed(
        None, "boss_swap", relative, origin="SYNTHETIC_SPEC", reason="SYNTHETIC_HAS_NO_BOSS_ACTION"))


def write_dataset(archive: Path, output: Path) -> Path:
    output = output.resolve()
    require(output.is_relative_to(PROJECT_ROOT / "docs" / "phase5" / "datasets"),
            "dataset export must stay under docs/phase5/datasets")
    names = ("demon_historical_v1.jsonl", "synthetic_mechanics_v1.jsonl", "manifest.json")
    require(not any((output / name).exists() for name in names), "refuse to overwrite dataset")
    historical, provenance = import_incident(archive.resolve())
    synthetic = synthetic_record()
    groups = [(names[0], historical, "H", "development"),
              (names[1], [synthetic], "S", "regression")]
    encoded = [(name, ("\n".join(record.dumps() for record in records) + "\n").encode("utf-8"),
                len(records), tier, split) for name, records, tier, split in groups]
    manifest = dict(schema=DATASET_SCHEMA, name="5b1_incident_and_mechanics_v1",
                    entries=[dict(path=name, sha256=hashlib.sha256(data).hexdigest(),
                                  records=count, tier=tier, split=split)
                             for name, data, count, tier, split in encoded],
                    sources=provenance["sources"] + [synthetic.snapshot.provenance.to_dict()],
                    coverage=dict(historical_matches=len({r.snapshot.source.match_id for r in historical}),
                                  historical_roots=len(historical),
                                  archived_snapshots_matched=provenance["matched_archived_snapshots"],
                                  synthetic_mechanics=1, independent_holdout=0,
                                  core_hashes={name: file_hash(PROJECT_ROOT / "src" / "pokiguard_v2" / name)
                                               for name in ("board_simulator.py", "demon_aegis.py")}),
                    limitations=[
                        "Development incidents already inspected; no efficacy holdout.",
                        "No exact boss swap/refill/damage attribution; no counterfactual outcomes.",
                        "Legacy binary/config/monotonic clock not fully bound.",
                        "50 A2 designs not utility/refinement-tested in B1.",
                        "Synthetic root is mechanics-only, not BASIC engine parity.",
                    ])
    output.mkdir(parents=True, exist_ok=True)
    for name, data, _, _, _ in encoded:
        with (output / name).open("xb") as stream:
            stream.write(data)
    with (output / names[2]).open("x", encoding="utf-8", newline="\n") as stream:
        stream.write(canonical_json(manifest) + "\n")
    return output / names[2]


def main(argv: Sequence[str] | None = None) -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    commands = parser.add_subparsers(dest="command", required=True)
    importer = commands.add_parser("import-incident")
    importer.add_argument("--archive", type=Path, required=True)
    importer.add_argument("--output-dir", type=Path, required=True)
    replay = commands.add_parser("replay")
    replay.add_argument("manifest", type=Path)
    replay.add_argument("--output-events", type=Path)
    args = parser.parse_args(argv)
    try:
        if args.command == "import-incident":
            path = write_dataset(args.archive.resolve(), args.output_dir)
            print(canonical_json({"manifest": str(path), "mode": "OFFLINE_ONLY"}))
            return 0
        manifest, records = load_dataset(args.manifest.resolve())
        results = [replay_record(record) for record in records]
        events = [replay_event(result, i).dumps() for i, result in enumerate(results)]
        if args.output_events:
            target = args.output_events.resolve()
            require(target.is_relative_to(PROJECT_ROOT / "docs" / "phase5" / "datasets"),
                    "event export must stay within offline datasets")
            with target.open("x", encoding="utf-8", newline="\n") as stream:
                stream.write("\n".join(events) + "\n")
        print(canonical_json(dict(
            mode="OFFLINE_ONLY", records=len(records),
            statuses={status: sum(r.status == status for r in results)
                      for status in ("MATCH", "MISMATCH", "UNSUPPORTED")},
            resources_matched=sum(r.checks.plain().get("resources_match") is True for r in results),
            forecasts_matched=sum(r.checks.plain().get("forecast_match") is True for r in results),
            forecasts_not_applicable=sum(r.checks.plain().get("forecast_match") is None for r in results),
            links=len(observation_links(records)), event_records=len(events),
            dataset_name=manifest.plain()["name"],
        )))
        return 0 if all(result.status == "MATCH" for result in results) else 1
    except (OSError, ValueError, KeyError, TypeError, IndexError) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
