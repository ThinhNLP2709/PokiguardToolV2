"""Bounded event serialization only; no sink, writer or background worker in B1."""
from __future__ import annotations

from dataclasses import dataclass
from typing import Any

from .reasoning_replay import RootReplay
from .reasoning_snapshot import (
    FrozenJSON, RunIntent, SourceIdentity, canonical_json, digest, integer, keys, require, strict_json_loads,
)

EVENT_SCHEMA = "pokiguard.reasoning.event.v1"
EVENT_TYPES = frozenset((
    "reasoning.job", "reasoning.decision", "reasoning.fallback", "reasoning.error",
    "reasoning.health", "reasoning.observation_link", "reasoning.run_summary",
))


@dataclass(frozen=True)
class ReasoningEvent:
    event_type: str
    event_seq: int
    source: SourceIdentity
    snapshot_id: str
    config_hash: str
    payload: FrozenJSON
    job_id: str | None = None
    dispatched_action_id: str | None = None

    def __post_init__(self) -> None:
        require(isinstance(self.event_type, str) and self.event_type in EVENT_TYPES,
                "unsupported event type")
        integer(self.event_seq, "event sequence")
        require(isinstance(self.source, SourceIdentity) and isinstance(self.payload, FrozenJSON),
                "event must be immutable")
        require(isinstance(self.snapshot_id, str) and bool(self.snapshot_id) and
                isinstance(self.config_hash, str) and bool(self.config_hash), "event identity required")
        require(isinstance(self.payload.plain(), dict), "event payload must be map")
        for optional in (self.job_id, self.dispatched_action_id):
            require(optional is None or isinstance(optional, str), "invalid optional identity")
        payload = self.payload.plain()
        if self.event_type == "reasoning.decision":
            require(payload.get("mode") == "OFFLINE" and
                    payload.get("disposition") == "REPLAY_ONLY_NO_PROPOSAL" and
                    payload.get("proposal_candidate_id") is None and
                    payload.get("selected_candidate_id") is None,
                    "offline codec cannot publish a production proposal/selection")
            intent = RunIntent.from_dict(payload.get("run_intent"))
            require(intent.config_hash == self.config_hash, "event/config hash mismatch")
            require(isinstance(payload.get("baseline_candidate_id"), str) and
                    payload.get("recorded_chosen_candidate_id") in
                    (None, payload["baseline_candidate_id"]), "event/chosen identity mismatch")
        if "candidate_summaries" in payload:
            from .reasoning_snapshot import CandidateRecord
            summaries = payload["candidate_summaries"]
            require(isinstance(summaries, list) and len(summaries) <= 6,
                    "candidate summary count exceeds cap")
            ids = set()
            for item in summaries:
                candidate = CandidateRecord.from_dict(item)
                require(candidate.snapshot_id == self.snapshot_id and candidate.source == self.source,
                        "event/candidate source mismatch")
                require(candidate.candidate_id not in ids, "duplicate candidate summary")
                if candidate.baseline_member:
                    require(candidate.candidate_id == payload.get("baseline_candidate_id"),
                            "event/baseline identity mismatch")
                ids.add(candidate.candidate_id)

    def to_dict(self) -> dict[str, Any]:
        body = dict(schema=EVENT_SCHEMA, event_type=self.event_type, event_seq=self.event_seq,
                    producer="offline_replay_5b1", source=self.source.to_dict(),
                    snapshot_id=self.snapshot_id, config_hash=self.config_hash,
                    job_id=self.job_id, dispatched_action_id=self.dispatched_action_id,
                    clock=dict(utc=None, monotonic=None, availability="MISSING",
                               reason="OFFLINE_EXPORT_NO_RUNTIME_CLOCK"),
                    payload=self.payload.plain())
        body["event_id"] = digest(body)
        return body

    def dumps(self) -> str:
        text = canonical_json(self.to_dict())
        limit = 16 * 1024 if self.event_type == "reasoning.decision" else 32 * 1024
        require(len(text.encode("utf-8")) <= limit, "event exceeds telemetry byte cap")
        return text

    @classmethod
    def loads(cls, text: str) -> ReasoningEvent:
        value = strict_json_loads(text)
        keys(value, {"schema", "event_id", "event_type", "event_seq", "producer", "source", "snapshot_id",
                     "config_hash", "job_id", "dispatched_action_id", "clock", "payload"})
        require(value["schema"] == EVENT_SCHEMA and value["producer"] == "offline_replay_5b1",
                "unsupported event schema/producer")
        result = cls(value["event_type"], value["event_seq"],
                     SourceIdentity.from_dict(value["source"]), value["snapshot_id"],
                     value["config_hash"], FrozenJSON.of(value["payload"]),
                     value["job_id"], value["dispatched_action_id"])
        require(result.to_dict()["event_id"] == value["event_id"] and
                result.to_dict()["clock"] == value["clock"], "event ID/clock mismatch")
        result.dumps()  # Decoding cannot bypass the same byte cap.
        return result


def replay_event(result: RootReplay, event_seq: int) -> ReasoningEvent:
    snapshot = result.record.snapshot
    baseline_id = snapshot.candidate_id(snapshot.baseline)
    baseline = next((candidate for candidate in result.candidates
                     if candidate.candidate_id == baseline_id), None)
    summaries = [baseline.to_dict()] if baseline else []
    # B1 reports mechanical replay; it neither proposes nor selects a new move.
    payload = dict(
        mode="OFFLINE", run_intent=snapshot.intent.to_dict(),
        snapshot_provenance=snapshot.provenance.to_dict(),
        baseline_candidate_id=baseline_id, proposal_candidate_id=None,
        selected_candidate_id=None,
        recorded_chosen_candidate_id=(result.record.chosen.candidate_id
                                      if result.record.chosen else None),
        disposition="REPLAY_ONLY_NO_PROPOSAL", reason_code=result.status,
        candidate_summaries=summaries, checks=result.checks.plain(),
        work_completed=dict(adjacent_pairs=result.adjacent_pairs, legal_roots=len(result.candidates)),
        timing_status="NOT_MEASURED", job_status="NOT_CREATED",
        native_action_id_status=result.record.chosen.native_action_id.to_dict()
                               if result.record.chosen else None,
    )
    native = result.record.chosen.native_action_id if result.record.chosen else None
    return ReasoningEvent("reasoning.decision", event_seq, snapshot.source,
                          snapshot.snapshot_id, snapshot.intent.config_hash,
                          FrozenJSON.of(payload),
                          dispatched_action_id=native.value.plain()
                          if native and native.availability == "PRESENT" else None)
