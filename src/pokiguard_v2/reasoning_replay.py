"""Deterministic file-only replay and chosen-action attribution for Phase 5B.1."""
from __future__ import annotations

from dataclasses import dataclass
import hashlib
from pathlib import Path
from typing import Any, Iterable

from .board_simulator import evaluate_all_moves
from .demon_aegis import evaluate_demon_aegis_move
from .state import GemType
from .reasoning_snapshot import (
    Action, CandidateRecord, Evidence, FrozenJSON, ReasoningSnapshot, SourceIdentity,
    SourceRecord, canonical_json, integer, keys, require, strict_json_loads,
)

RECORD_SCHEMA = "pokiguard.reasoning.replay_record.v1"
DATASET_SCHEMA = "pokiguard.reasoning.dataset.v1"
MAX_DATASET_BYTES = 32 * 1024 * 1024
MAX_DATASET_RECORDS = 512


@dataclass(frozen=True)
class ChosenAction:
    snapshot_id: str
    source: SourceIdentity
    action: Action
    sent_record: SourceRecord
    native_action_id: Evidence

    def __post_init__(self) -> None:
        require(isinstance(self.snapshot_id, str) and bool(self.snapshot_id) and
                isinstance(self.source, SourceIdentity) and isinstance(self.action, Action) and
                isinstance(self.sent_record, SourceRecord) and isinstance(self.native_action_id, Evidence),
                "chosen action must be immutable and typed")
        if self.native_action_id.availability == "PRESENT":
            require(isinstance(self.native_action_id.value.plain(), str), "invalid native action ID")

    @property
    def candidate_id(self) -> str:
        from .reasoning_snapshot import digest
        return digest(dict(snapshot_id=self.snapshot_id, action=self.action.to_dict()))

    def to_dict(self) -> dict[str, Any]:
        return dict(snapshot_id=self.snapshot_id, source=self.source.to_dict(),
                    action=self.action.to_dict(), sent_record=self.sent_record.to_dict(),
                    native_action_id=self.native_action_id.to_dict())

    @classmethod
    def from_dict(cls, value: Any) -> ChosenAction:
        keys(value, {"snapshot_id", "source", "action", "sent_record", "native_action_id"})
        return cls(value["snapshot_id"], SourceIdentity.from_dict(value["source"]),
                   Action.from_dict(value["action"]), SourceRecord.from_dict(value["sent_record"]),
                   Evidence.from_dict(value["native_action_id"]))


@dataclass(frozen=True)
class ReplayRecord:
    snapshot: ReasoningSnapshot
    chosen: ChosenAction | None
    terminal: Evidence
    boss_action: Evidence

    def __post_init__(self) -> None:
        require(isinstance(self.snapshot, ReasoningSnapshot) and
                isinstance(self.terminal, Evidence) and isinstance(self.boss_action, Evidence),
                "invalid replay record")
        if self.chosen is not None:
            require(isinstance(self.chosen, ChosenAction), "invalid chosen action")
            require(self.chosen.source == self.snapshot.source and
                    self.chosen.snapshot_id == self.snapshot.snapshot_id and
                    self.chosen.action.to_dict() == self.snapshot.baseline.to_dict(),
                    "chosen action/source/snapshot mismatch")
            require(self.chosen.sent_record.path == self.snapshot.provenance.path and
                    self.chosen.sent_record.file_sha256 == self.snapshot.provenance.file_sha256 and
                    self.chosen.sent_record.line > self.snapshot.provenance.line,
                    "action_sent provenance mismatch")
        if self.terminal.availability == "PRESENT":
            require(self.chosen is not None, "outcome without observed chosen action")
            require(self.terminal.value.plain() in ("WIN", "LOSS"), "invalid terminal result")

    def to_dict(self) -> dict[str, Any]:
        return dict(schema=RECORD_SCHEMA, snapshot=self.snapshot.to_dict(),
                    chosen=self.chosen.to_dict() if self.chosen else None,
                    terminal=self.terminal.to_dict(), boss_action=self.boss_action.to_dict())

    def dumps(self) -> str:
        return canonical_json(self.to_dict())

    @classmethod
    def loads(cls, text: str) -> ReplayRecord:
        value = strict_json_loads(text)
        keys(value, {"schema", "snapshot", "chosen", "terminal", "boss_action"})
        require(value["schema"] == RECORD_SCHEMA, "unsupported replay schema")
        return cls(ReasoningSnapshot.from_dict(value["snapshot"]),
                   ChosenAction.from_dict(value["chosen"]) if value["chosen"] is not None else None,
                   Evidence.from_dict(value["terminal"]), Evidence.from_dict(value["boss_action"]))


def validate_candidate(snapshot: ReasoningSnapshot, candidate: CandidateRecord) -> None:
    require(candidate.source == snapshot.source and
            candidate.snapshot_id == snapshot.snapshot_id, "candidate source mismatch")
    require(candidate.baseline_member ==
            (candidate.action.to_dict() == snapshot.baseline.to_dict()), "baseline membership mismatch")


def outcome_for(record: ReplayRecord, candidate: CandidateRecord) -> Evidence:
    validate_candidate(record.snapshot, candidate)
    if record.chosen is None or candidate.candidate_id != record.chosen.candidate_id:
        return Evidence.observed(None, "terminal_result", record.snapshot.snapshot_id,
                                 reason="UNCHOSEN_COUNTERFACTUAL_HAS_NO_OBSERVED_OUTCOME")
    return record.terminal


@dataclass(frozen=True)
class RootReplay:
    record: ReplayRecord
    candidates: tuple[CandidateRecord, ...]
    checks: FrozenJSON
    status: str
    adjacent_pairs: int = 112

    def summary(self) -> dict[str, Any]:
        snapshot = self.record.snapshot
        return dict(snapshot_id=snapshot.snapshot_id, source=snapshot.source.to_dict(),
                    status=self.status, adjacent_pairs=self.adjacent_pairs, legal_candidates=len(self.candidates),
                    baseline_candidate_id=snapshot.candidate_id(snapshot.baseline),
                    checks=self.checks.plain(), observed_terminal=self.record.terminal.to_dict())


def replay_record(record: ReplayRecord) -> RootReplay:
    snapshot = record.snapshot
    try:
        board = snapshot.board_state()
    except ValueError as exc:
        return RootReplay(record, (), FrozenJSON.of({"reason": str(exc)}), "UNSUPPORTED", 0)
    moves = evaluate_all_moves(board)
    candidates = []
    selected = None
    for move in moves:
        action = Action("swap", move.move)
        is_baseline = action.to_dict() == snapshot.baseline.to_dict()
        if is_baseline:
            selected = move
        ordinary = {gem.value: {"physical": move.total.cells(gem),
                                "effective": move.total.effective(gem)}
                    for gem in GemType if gem is not GemType.UNKNOWN}
        source = snapshot.snapshot_id
        scope = {"transition": "known ordinary root; refill UNKNOWN; not observed damage"}
        features = [
            ("legality", Evidence.observed(True, "match_producing_swap", source,
                                           origin="DERIVED_SOLVER", scope=scope)),
            ("ordinary_resources", Evidence.observed(ordinary, "physical_and_effective_separate", source,
                                                       origin="DERIVED_SOLVER", support="CONDITIONAL_MODEL",
                                                       scope=scope)),
            ("unknown_exposure", Evidence.observed(move.unknown_exposure.cells, "physical_cells", source,
                                                    origin="DERIVED_SOLVER", support="CONDITIONAL_MODEL")),
            ("clear_rounds_round_local", Evidence.observed(
                [[list(cell) for cell in cells] for cells in move.clear_rounds],
                "round_local_coordinates_not_original_cell_ids", source, origin="DERIVED_SOLVER",
                support="CONDITIONAL_MODEL")),
            ("rage_gain", Evidence.observed(None, "rage_points", source,
                                            reason="CONVERSION_APPLICABILITY_DEFERRED_TO_B2_B3")),
            ("mana_gain", Evidence.observed(None, "mana_points", source,
                                            reason="CONVERSION_APPLICABILITY_DEFERRED_TO_B2_B3")),
            ("post_boss_setup", Evidence.observed(None, "physical_sword_cells", source,
                                                  reason="BOSS_REFILL_MODEL_NOT_IMPLEMENTED")),
            ("utility", Evidence.observed(None, "utility_score", source,
                                          reason="PLANNER_NOT_IMPLEMENTED_IN_B1")),
        ]
        if snapshot.intent.profile == "demon_aegis_farm":
            target_gem = GemType(snapshot.intent.settings.plain().get("demon_target_gem", "shield"))
            passive = evaluate_demon_aegis_move(board, move, include_next_turn=False, target_gem=target_gem)
            features.append(("shield_sweep", Evidence.observed(
                dict(matched=[list(x) for x in passive.target_match_cells],
                     region_union=[list(x) for x in passive.blast_cells],
                     sword_physical=passive.sword_cells, sword_effective=passive.sword_effective),
                "passive_geometry_separate_from_ordinary_totals", source,
                origin="DERIVED_SOLVER", support="CONDITIONAL_MODEL",
                scope={"no_joint_resource_sum": True, "damage_order": "UNKNOWN"})))
        candidate = CandidateRecord(source, snapshot.source, action, is_baseline, tuple(features))
        validate_candidate(snapshot, candidate)
        candidates.append(candidate)

    recorded = snapshot.recorded.plain()
    require(isinstance(recorded, dict), "recorded reference must be map")
    checks: dict[str, Any] = {"baseline_legal": selected is not None,
                              "resources_match": None, "forecast_match": None}
    if selected is not None:
        expected = recorded.get("ordinary_resources")
        if expected is not None:
            actual = [[gem.value, tally.cells, tally.effective]
                      for gem, tally in selected.total.values]
            # Source ordering is not a semantic difference.
            checks["resources_match"] = sorted(actual) == sorted(expected)
        forecast = recorded.get("pre_boss_forecast_sword_cells")
        if forecast is not None:
            integer(forecast, "forecast")
            require(snapshot.intent.profile == "demon_aegis_farm", "unsupported forecast reference")
            passive = evaluate_demon_aegis_move(board, selected,
                target_gem=GemType(snapshot.intent.settings.plain().get("demon_target_gem", "shield")))
            checks["forecast_match"] = passive.next_best_sword_cells == forecast
            checks["pre_boss_forecast_sword_cells"] = passive.next_best_sword_cells
    status = ("MATCH" if selected is not None and
              all(value is not False for key, value in checks.items() if key.endswith("_match"))
              else "MISMATCH")
    if snapshot.baseline.family != "swap":
        status = "UNSUPPORTED"
        checks["reason"] = "BASELINE_EFFECT_OPAQUE_NON_SWAP"
    return RootReplay(record, tuple(candidates), FrozenJSON.of(checks), status)


def link_next_observation(current: ReplayRecord, following: ReplayRecord) -> FrozenJSON:
    a, b = current.snapshot, following.snapshot
    require((a.source.run_id, a.source.session_id, a.source.match_id, a.source.actor_id) ==
            (b.source.run_id, b.source.session_id, b.source.match_id, b.source.actor_id),
            "cross-session/match/actor observation link")
    require(b.source.turn > a.source.turn, "next observation must be a fresh later turn")
    require(current.chosen is not None, "observation cannot be attributed to unchosen root")
    return FrozenJSON.of(dict(
        source_snapshot_id=a.snapshot_id, observed_next_snapshot_id=b.snapshot_id,
        chosen_candidate_id=current.chosen.candidate_id,
        observed_next_source=b.source.to_dict(), turn_gap=b.source.turn - a.source.turn,
        attribution="CHOSEN_ROOT_TO_LATER_LOCAL_STATE; BOSS_CAUSE_UNKNOWN",
        terminal=current.terminal.to_dict(), boss_action=current.boss_action.to_dict(),
    ))


def observation_links(records: Iterable[ReplayRecord]) -> tuple[FrozenJSON, ...]:
    groups: dict[tuple[Any, ...], list[ReplayRecord]] = {}
    for record in records:
        source = record.snapshot.source
        groups.setdefault((source.run_id, source.session_id, source.match_id, source.actor_id),
                          []).append(record)
    links = []
    for group in groups.values():
        ordered = sorted(group, key=lambda r: r.snapshot.source.turn)
        for current, following in zip(ordered, ordered[1:]):
            if current.chosen is not None:
                links.append(link_next_observation(current, following))
    return tuple(links)


def load_dataset(manifest_path: Path) -> tuple[FrozenJSON, tuple[ReplayRecord, ...]]:
    require(manifest_path.stat().st_size <= MAX_DATASET_BYTES, "manifest too large")
    manifest = strict_json_loads(manifest_path.read_text(encoding="utf-8"))
    keys(manifest, {"schema", "name", "entries", "sources", "coverage", "limitations"})
    require(manifest["schema"] == DATASET_SCHEMA and isinstance(manifest["entries"], list),
            "unsupported dataset manifest")
    records = []
    assignments: dict[tuple[Any, ...], str] = {}
    ids: set[str] = set()
    turns: set[tuple[Any, ...]] = set()
    total_bytes = 0
    for entry in manifest["entries"]:
        keys(entry, {"path", "sha256", "records", "tier", "split"})
        require(entry["tier"] in ("S", "H", "O", "L") and
                entry["split"] in ("regression", "development", "validation", "holdout"),
                "invalid dataset tier/split")
        relative = Path(entry["path"])
        require(not relative.is_absolute() and ".." not in relative.parts, "unsafe dataset path")
        path = (manifest_path.parent / relative).resolve()
        require(path.is_relative_to(manifest_path.parent.resolve()), "dataset escapes manifest root")
        total_bytes += path.stat().st_size
        require(total_bytes <= MAX_DATASET_BYTES, "dataset exceeds byte cap")
        data = path.read_bytes()
        require(hashlib.sha256(data).hexdigest() == entry["sha256"], "dataset SHA256 mismatch")
        lines = data.decode("utf-8").splitlines()
        require(len(lines) == integer(entry["records"], "record count", 1), "record count mismatch")
        for line in lines:
            record = ReplayRecord.loads(line)
            snapshot = record.snapshot
            require(snapshot.snapshot_id not in ids, "duplicate snapshot/continuation")
            ids.add(snapshot.snapshot_id)
            source = snapshot.source
            scope = snapshot.intent.scope.plain()
            require(scope.get("dataset_tier") == entry["tier"], "dataset tier/provenance mismatch")
            require(not (scope.get("previously_inspected") is True and
                         entry["split"] in ("validation", "holdout")),
                    "previously inspected record cannot be independent holdout/validation")
            turn_key = (source.run_id, source.session_id, source.match_id, source.turn)
            require(turn_key not in turns, "ambiguous duplicate turn")
            turns.add(turn_key)
            for key in (("match", source.match_id), ("session", source.run_id, source.session_id)):
                require(key not in assignments or assignments[key] == entry["split"],
                        "same match/session leaked across dataset split")
                assignments[key] = entry["split"]
            records.append(record)
            require(len(records) <= MAX_DATASET_RECORDS, "dataset exceeds record cap")
    require(bool(records), "empty dataset")
    observation_links(records)  # Validate chronology before any result is returned.
    return FrozenJSON.of(manifest), tuple(records)
