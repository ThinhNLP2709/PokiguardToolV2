"""Immutable, provider-free Phase 5 offline records.

No reader, executor, worker or production adapter lives here. JSON is copied
into canonical immutable text, so caller-owned dictionaries cannot mutate a job.
"""
from __future__ import annotations

from dataclasses import dataclass
import hashlib
import json
import math
from pathlib import PurePosixPath
import re
from typing import Any

from .board_simulator import SwapMove
from .state import BoardState, CellState, GemType, SUPPORTED_CELL_MULTIPLIERS

SNAPSHOT_SCHEMA = "pokiguard.reasoning.snapshot.v1"
CANDIDATE_SCHEMA = "pokiguard.reasoning.candidate.v1"
MAX_RECORD_BYTES = 512 * 1024
PROFILES = frozenset((
    "simple", "careful", "skill_rush", "demon_aegis_farm",
    "mega_icarus_spam_skill", "bu_win",
))
AVAILABILITIES = frozenset(("PRESENT", "MISSING", "UNSUPPORTED", "STALE", "CONFLICT"))
ORIGINS = frozenset((
    "OBSERVED_SNAPSHOT", "DERIVED_SOLVER", "USER_PROVIDED",
    "MODEL_PREDICTION", "SYNTHETIC_SPEC",
))
SUPPORTS = frozenset((
    "VERIFIED_FOR_SCOPE", "USER_CALIBRATED", "CONDITIONAL_MODEL",
    "EMPIRICAL_VALIDATED", "UNKNOWN",
))


def require(condition: bool, message: str) -> None:
    if not condition:
        raise ValueError(message)


def integer(value: Any, name: str, minimum: int = 0) -> int:
    require(type(value) is int and value >= minimum, f"{name}: invalid integer")
    return value


def text_value(value: Any, name: str) -> str:
    require(isinstance(value, str) and bool(value.strip()), f"{name}: required text")
    return value


def keys(value: Any, expected: set[str]) -> None:
    require(isinstance(value, dict) and set(value) == expected, "unexpected/missing fields")


def _json_pairs(pairs: list[tuple[str, Any]]) -> dict[str, Any]:
    result: dict[str, Any] = {}
    for key, value in pairs:
        require(key not in result, f"duplicate JSON key: {key}")
        result[key] = value
    return result


def _bad_constant(value: str) -> None:
    raise ValueError(f"nonfinite JSON: {value}")


def strict_json_loads(value: str) -> Any:
    require(isinstance(value, str), "JSON must be text")
    require(len(value.encode("utf-8")) <= MAX_RECORD_BYTES, "record exceeds byte cap")
    try:
        result = json.loads(value, object_pairs_hook=_json_pairs, parse_constant=_bad_constant)
        _validate_json(result)
        return result
    except (RecursionError, OverflowError) as exc:
        raise ValueError("invalid JSON nesting/number") from exc


def _validate_json(value: Any, depth: int = 0) -> None:
    require(depth <= 32, "JSON nesting exceeds bound")
    if value is None or type(value) in (str, int, bool):
        return
    if type(value) is float:
        require(math.isfinite(value), "nonfinite number")
        return
    if isinstance(value, (list, tuple)):
        for child in value:
            _validate_json(child, depth + 1)
        return
    require(isinstance(value, dict), "unsupported JSON value")
    for key, child in value.items():
        require(type(key) is str, "JSON keys must be strings")
        _validate_json(child, depth + 1)


def canonical_json(value: Any) -> str:
    _validate_json(value)
    result = json.dumps(value, ensure_ascii=False, sort_keys=True, separators=(",", ":"),
                        allow_nan=False)
    require(len(result.encode("utf-8")) <= MAX_RECORD_BYTES, "record exceeds byte cap")
    return result


def digest(value: Any) -> str:
    return hashlib.sha256(canonical_json(value).encode("utf-8")).hexdigest()


@dataclass(frozen=True)
class FrozenJSON:
    text: str

    def __post_init__(self) -> None:
        parsed = strict_json_loads(self.text)
        require(canonical_json(parsed) == self.text, "FrozenJSON must be canonical")

    @classmethod
    def of(cls, value: Any) -> FrozenJSON:
        return cls(canonical_json(value))

    def plain(self) -> Any:
        """Return a detached copy, never the stored mutable source."""
        return strict_json_loads(self.text)


@dataclass(frozen=True)
class Evidence:
    value: FrozenJSON
    unit: str
    availability: str
    origin: str
    support: str
    source_ref: str
    scope: FrozenJSON
    assumptions: tuple[str, ...] = ()
    reason: str | None = None

    def __post_init__(self) -> None:
        require(isinstance(self.value, FrozenJSON) and isinstance(self.scope, FrozenJSON),
                "evidence JSON must be immutable")
        require(isinstance(self.availability, str) and self.availability in AVAILABILITIES,
                "unknown availability")
        require(isinstance(self.origin, str) and self.origin in ORIGINS and
                isinstance(self.support, str) and self.support in SUPPORTS, "unknown evidence category")
        text_value(self.unit, "unit")
        text_value(self.source_ref, "source_ref")
        require(type(self.assumptions) is tuple and
                all(isinstance(x, str) for x in self.assumptions), "immutable assumptions required")
        if self.availability == "PRESENT":
            require(self.value.plain() is not None, "PRESENT cannot contain null")
        else:
            text_value(self.reason, "unavailable reason")
        if self.availability in ("MISSING", "UNSUPPORTED"):
            require(self.value.plain() is None, "missing/unsupported cannot carry guessed value")

    @classmethod
    def observed(cls, value: Any, unit: str, source: str, *,
                 origin: str = "OBSERVED_SNAPSHOT", support: str = "VERIFIED_FOR_SCOPE",
                 scope: Any = None, reason: str = "NOT_RECORDED") -> Evidence:
        return cls(FrozenJSON.of(value), unit, "MISSING" if value is None else "PRESENT",
                   origin, "UNKNOWN" if value is None else support, source,
                   FrozenJSON.of(scope), (), reason if value is None else None)

    def to_dict(self) -> dict[str, Any]:
        return dict(value=self.value.plain(), unit=self.unit, availability=self.availability,
                    origin=self.origin, support=self.support, source_ref=self.source_ref,
                    scope=self.scope.plain(), assumptions=list(self.assumptions), reason=self.reason)

    @classmethod
    def from_dict(cls, value: Any) -> Evidence:
        keys(value, {"value", "unit", "availability", "origin", "support", "source_ref",
                     "scope", "assumptions", "reason"})
        require(isinstance(value["assumptions"], list), "assumptions must be an array")
        return cls(FrozenJSON.of(value["value"]), value["unit"], value["availability"],
                   value["origin"], value["support"], value["source_ref"],
                   FrozenJSON.of(value["scope"]), tuple(value["assumptions"]), value["reason"])


@dataclass(frozen=True)
class SourceIdentity:
    run_id: str
    session_id: str
    match_id: str
    turn: int
    srv_seq: int | None
    board_hash: str
    actor_id: int | None
    controller_generation: int | None

    def __post_init__(self) -> None:
        for name in ("run_id", "session_id", "match_id", "board_hash"):
            text_value(getattr(self, name), name)
        integer(self.turn, "turn")
        for name in ("srv_seq", "actor_id", "controller_generation"):
            if getattr(self, name) is not None:
                integer(getattr(self, name), name)

    def to_dict(self) -> dict[str, Any]:
        return dict(vars(self))

    @classmethod
    def from_dict(cls, value: Any) -> SourceIdentity:
        keys(value, set(cls.__dataclass_fields__))
        return cls(**value)


@dataclass(frozen=True)
class SourceRecord:
    path: str
    line: int
    file_sha256: str
    record_sha256: str

    def __post_init__(self) -> None:
        text_value(self.path, "source path")
        path = PurePosixPath(self.path)
        require(not path.is_absolute() and ".." not in path.parts and
                "\\" not in self.path and ":" not in self.path, "source path must be relative")
        integer(self.line, "source line", 1)
        for name in ("file_sha256", "record_sha256"):
            require(isinstance(getattr(self, name), str) and
                    re.fullmatch(r"[0-9a-f]{64}", getattr(self, name)) is not None,
                    f"invalid {name}")

    def to_dict(self) -> dict[str, Any]:
        return dict(vars(self))

    @classmethod
    def from_dict(cls, value: Any) -> SourceRecord:
        keys(value, set(cls.__dataclass_fields__))
        return cls(**value)


@dataclass(frozen=True)
class RunIntent:
    profile: str
    settings: FrozenJSON
    versions: FrozenJSON
    scope: FrozenJSON

    def __post_init__(self) -> None:
        require(isinstance(self.profile, str) and self.profile in PROFILES, "unsupported PlayStyle")
        for name in ("settings", "versions", "scope"):
            require(isinstance(getattr(self, name), FrozenJSON) and
                    isinstance(getattr(self, name).plain(), dict), f"{name}: expected immutable map")

    @property
    def config_hash(self) -> str:
        return digest(self.to_dict())

    def to_dict(self) -> dict[str, Any]:
        return dict(profile=self.profile, settings=self.settings.plain(),
                    versions=self.versions.plain(), scope=self.scope.plain())

    @classmethod
    def from_dict(cls, value: Any) -> RunIntent:
        keys(value, {"profile", "settings", "versions", "scope"})
        return cls(value["profile"], *(FrozenJSON.of(value[key])
                                      for key in ("settings", "versions", "scope")))


@dataclass(frozen=True)
class Action:
    family: str
    move: SwapMove | None = None
    card_source: str | None = None

    def __post_init__(self) -> None:
        require(isinstance(self.family, str) and self.family in ("swap", "cast", "pet_skill", "evolve", "pass", "none",
                                "exit_match"), "unknown action family")
        if self.family == "swap":
            require(isinstance(self.move, SwapMove), "swap requires coordinates")
            for point in (self.move.first, self.move.second):
                require(type(point) is tuple and len(point) == 2 and
                        all(type(x) is int for x in point), "immutable integer coordinates required")
        else:
            require(self.move is None, "non-swap cannot contain move")
        require(self.card_source is None or isinstance(self.card_source, str), "invalid card source")

    def to_dict(self) -> dict[str, Any]:
        # Canonical endpoints identify an action; this is not an executor script.
        points = sorted((self.move.first, self.move.second)) if self.move else None
        return dict(family=self.family, move=[list(x) for x in points] if points else None,
                    card_source=self.card_source)

    @classmethod
    def from_dict(cls, value: Any) -> Action:
        keys(value, {"family", "move", "card_source"})
        move = value["move"]
        if move is not None:
            require(isinstance(move, list) and len(move) == 2 and
                    all(isinstance(p, list) and len(p) == 2 and
                        all(type(x) is int for x in p) for p in move), "invalid move")
            move = SwapMove(tuple(move[0]), tuple(move[1]))
        return cls(value["family"], move, value["card_source"])


BoardData = tuple[tuple[tuple[str, int | None], ...], ...]


@dataclass(frozen=True)
class ReasoningSnapshot:
    source: SourceIdentity
    provenance: SourceRecord
    board: BoardData
    intent: RunIntent
    baseline: Action
    baseline_reason: str
    observations: tuple[tuple[str, Evidence], ...]
    recorded: FrozenJSON

    def __post_init__(self) -> None:
        require(isinstance(self.source, SourceIdentity) and isinstance(self.provenance, SourceRecord)
                and isinstance(self.intent, RunIntent) and isinstance(self.baseline, Action),
                "typed source/config/baseline required")
        require(type(self.board) is tuple and len(self.board) == 8, "board must be 8x8")
        for row in self.board:
            require(type(row) is tuple and len(row) == 8, "board must be immutable 8x8")
            for cell in row:
                require(type(cell) is tuple and len(cell) == 2, "invalid cell")
                GemType(cell[0])
                require(cell[1] is None or (type(cell[1]) is int and
                        cell[1] in SUPPORTED_CELL_MULTIPLIERS), "invalid multiplier")
        text_value(self.baseline_reason, "baseline reason")
        require(type(self.observations) is tuple and all(
            type(pair) is tuple and len(pair) == 2 and isinstance(pair[0], str) and
            isinstance(pair[1], Evidence) for pair in self.observations), "immutable observations")
        require(len(dict(self.observations)) == len(self.observations), "duplicate observation")
        require(isinstance(self.recorded, FrozenJSON), "immutable recorded fields required")
        recorded = self.recorded.plain()
        require(isinstance(recorded, dict), "recorded fields must be a map")
        resources = recorded.get("ordinary_resources")
        if resources is not None:
            require(isinstance(resources, list), "invalid reference resources")
            seen = set()
            for item in resources:
                require(isinstance(item, list) and len(item) == 3 and
                        isinstance(item[0], str) and item[0] not in seen,
                        "invalid/duplicate reference resource")
                GemType(item[0])
                seen.add(item[0])
                integer(item[1], "reference physical cells")
                integer(item[2], "reference effective units")
        if recorded.get("pre_boss_forecast_sword_cells") is not None:
            integer(recorded["pre_boss_forecast_sword_cells"], "reference forecast")

    def evidence(self, name: str) -> Evidence:
        found = dict(self.observations).get(name)
        if found is not None:
            return found
        return Evidence.observed(None, "unknown", self.snapshot_id, reason="NOT_PUBLISHED")

    def board_state(self) -> BoardState:
        require(all(g != GemType.UNKNOWN.value and m is not None
                    for row in self.board for g, m in row), "observed board incomplete: fail closed")
        return BoardState(tuple(tuple(CellState(r, c, GemType(g), m)
                                     for c, (g, m) in enumerate(row))
                                for r, row in enumerate(self.board)))

    @property
    def snapshot_id(self) -> str:
        return digest(self.to_dict())

    def candidate_id(self, action: Action) -> str:
        return digest(dict(snapshot_id=self.snapshot_id, action=action.to_dict()))

    def to_dict(self) -> dict[str, Any]:
        return dict(schema=SNAPSHOT_SCHEMA, source=self.source.to_dict(),
                    provenance=self.provenance.to_dict(),
                    board=[[list(cell) for cell in row] for row in self.board],
                    intent=self.intent.to_dict(), baseline=self.baseline.to_dict(),
                    baseline_reason=self.baseline_reason,
                    observations={key: value.to_dict() for key, value in self.observations},
                    recorded=self.recorded.plain())

    @classmethod
    def from_dict(cls, value: Any) -> ReasoningSnapshot:
        keys(value, {"schema", "source", "provenance", "board", "intent", "baseline",
                     "baseline_reason", "observations", "recorded"})
        require(value["schema"] == SNAPSHOT_SCHEMA, "unsupported snapshot schema")
        board = value["board"]
        require(isinstance(board, list) and len(board) == 8 and
                all(isinstance(row, list) and len(row) == 8 and all(
                    isinstance(cell, list) and len(cell) == 2 for cell in row)
                    for row in board), "invalid board shape")
        require(isinstance(value["observations"], dict), "observations must be map")
        return cls(SourceIdentity.from_dict(value["source"]), SourceRecord.from_dict(value["provenance"]),
                   tuple(tuple(tuple(cell) for cell in row) for row in board),
                   RunIntent.from_dict(value["intent"]), Action.from_dict(value["baseline"]),
                   value["baseline_reason"],
                   tuple((key, Evidence.from_dict(val)) for key, val in sorted(value["observations"].items())),
                   FrozenJSON.of(value["recorded"]))

    def dumps(self) -> str:
        return canonical_json(self.to_dict())

    @classmethod
    def loads(cls, text: str) -> ReasoningSnapshot:
        return cls.from_dict(strict_json_loads(text))


@dataclass(frozen=True)
class CandidateRecord:
    snapshot_id: str
    source: SourceIdentity
    action: Action
    baseline_member: bool
    features: tuple[tuple[str, Evidence], ...]

    def __post_init__(self) -> None:
        text_value(self.snapshot_id, "snapshot id")
        require(isinstance(self.source, SourceIdentity) and isinstance(self.action, Action)
                and type(self.baseline_member) is bool, "invalid candidate identity")
        require(type(self.features) is tuple and all(
            type(pair) is tuple and len(pair) == 2 and isinstance(pair[0], str) and
            isinstance(pair[1], Evidence) for pair in self.features), "immutable features")
        require(len(dict(self.features)) == len(self.features), "duplicate feature")

    @property
    def candidate_id(self) -> str:
        return digest(dict(snapshot_id=self.snapshot_id, action=self.action.to_dict()))

    def to_dict(self) -> dict[str, Any]:
        return dict(schema=CANDIDATE_SCHEMA, snapshot_id=self.snapshot_id, source=self.source.to_dict(),
                    candidate_id=self.candidate_id, action=self.action.to_dict(),
                    baseline_member=self.baseline_member,
                    features={key: val.to_dict() for key, val in self.features})

    @classmethod
    def from_dict(cls, value: Any) -> CandidateRecord:
        keys(value, {"schema", "snapshot_id", "source", "candidate_id", "action",
                     "baseline_member", "features"})
        require(value["schema"] == CANDIDATE_SCHEMA and isinstance(value["features"], dict),
                "invalid candidate schema/features")
        result = cls(value["snapshot_id"], SourceIdentity.from_dict(value["source"]),
                     Action.from_dict(value["action"]), value["baseline_member"],
                     tuple((key, Evidence.from_dict(val)) for key, val in sorted(value["features"].items())))
        require(result.candidate_id == value["candidate_id"], "candidate identity mismatch")
        return result
