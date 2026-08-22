from __future__ import annotations

import json
import math
import os
import tempfile
from dataclasses import dataclass, field
from pathlib import Path
from typing import Any


CHECKPOINT_SCHEMA = "pokiguard.farm_checkpoint.v1"


@dataclass(frozen=True)
class CheckpointPayload:
    schema_version: str
    farm_run_id: str
    continuation_of: str | None
    checkpoint_seq: int
    created_at: float
    updated_at: float
    target_boss_id: str
    target_boss_name: str
    configured_limits: dict[str, int]
    run_started_at: float
    match_attempts: int
    completed_matches: int
    wins: int
    losses: int
    unknown_results: int
    technical_aborts: int
    technical_recoveries: int
    technical_exits: int
    last_completed_match_id: str | None
    seen_match_ids: tuple[str, ...]
    action_aggregates: dict[str, int]
    pass_totals: int
    consistency_aggregates: dict[str, int]
    last_safe_lifecycle: str | None
    stop_request_state: str | None
    stop_reason: str | None
    finalized_status: str | None


ALLOWED_KEYS = frozenset(
    {
        "schema_version",
        "farm_run_id",
        "continuation_of",
        "checkpoint_seq",
        "created_at",
        "updated_at",
        "target_boss_id",
        "target_boss_name",
        "configured_limits",
        "run_started_at",
        "match_attempts",
        "completed_matches",
        "wins",
        "losses",
        "unknown_results",
        "technical_aborts",
        "technical_recoveries",
        "technical_exits",
        "last_completed_match_id",
        "seen_match_ids",
        "action_aggregates",
        "pass_totals",
        "consistency_aggregates",
        "last_safe_lifecycle",
        "stop_request_state",
        "stop_reason",
        "finalized_status",
    }
)


FORBIDDEN_STATE_KEYS = frozenset(
    {
        "board_instance",
        "pending_action",
        "srv_seq",
        "board_hash",
        "idle_state",
        "desync_sticky",
        "card_ui_pointer",
        "fusion_pointer",
        "match_service_pointer",
        "ui_locator_ready",
        "lifecycle_epoch",
    }
)


class CheckpointError(RuntimeError):
    def __init__(self, reason: str, message: str) -> None:
        super().__init__(message)
        self.reason = reason


@dataclass(frozen=True)
class ResumeDecision:
    allowed: bool
    reason: str | None
    historical_counters: dict[str, int]
    seen_match_ids: tuple[str, ...]
    remaining_completed: int
    historical_action_aggregates: dict[str, int] = field(default_factory=dict)
    historical_consistency_aggregates: dict[str, int] = field(default_factory=dict)
    run_started_at: float = 0.0
    last_completed_match_id: str | None = None


def write_checkpoint(path: Path, payload: CheckpointPayload) -> None:
    """Atomic write: temp file in same dir → flush → fsync → os.replace."""
    _validate_payload(payload)
    directory = path.parent
    directory.mkdir(parents=True, exist_ok=True)
    fd, tmp_path = tempfile.mkstemp(prefix="checkpoint_", suffix=".tmp", dir=str(directory))
    try:
        with os.fdopen(fd, "w", encoding="utf-8") as handle:
            json.dump(_payload_to_dict(payload), handle, separators=(",", ":"))
            handle.flush()
            os.fsync(handle.fileno())
        os.replace(tmp_path, str(path))
    except Exception:
        try:
            os.unlink(tmp_path)
        except OSError:
            pass
        raise


def load_checkpoint(path: Path) -> CheckpointPayload:
    if not path.exists():
        raise CheckpointError("CHECKPOINT_MISSING", f"checkpoint not found: {path}")
    try:
        raw = json.loads(path.read_text(encoding="utf-8"))
    except (ValueError, UnicodeDecodeError) as exc:
        raise CheckpointError("CHECKPOINT_INVALID", f"malformed JSON: {exc}") from exc
    if not isinstance(raw, dict):
        raise CheckpointError("CHECKPOINT_INVALID", "checkpoint root is not an object")
    forbidden = set(raw.keys()) & FORBIDDEN_STATE_KEYS
    if forbidden:
        raise CheckpointError(
            "CHECKPOINT_INVALID",
            f"forbidden gameplay state keys present: {sorted(forbidden)}",
        )
    missing = ALLOWED_KEYS - set(raw.keys())
    if missing:
        raise CheckpointError(
            "CHECKPOINT_INVALID",
            f"missing required keys: {sorted(missing)}",
        )
    extra = set(raw.keys()) - ALLOWED_KEYS
    if extra:
        raise CheckpointError(
            "CHECKPOINT_INVALID",
            f"unexpected keys: {sorted(extra)}",
        )
    schema = str(raw.get("schema_version", ""))
    if schema != CHECKPOINT_SCHEMA:
        raise CheckpointError(
            "CHECKPOINT_SCHEMA_UNSUPPORTED",
            f"unsupported schema {schema!r}; expected {CHECKPOINT_SCHEMA}",
        )
    _validate_raw_payload_types(raw)
    try:
        payload = _dict_to_payload(raw)
    except (TypeError, ValueError) as exc:
        raise CheckpointError(
            "CHECKPOINT_INVALID", f"checkpoint value conversion failed: {exc}"
        ) from exc
    _validate_payload(payload)
    return payload


def validate_for_resume(
    payload: CheckpointPayload,
    *,
    target_boss_id: str,
    target_boss_name: str,
    target_completed_matches: int,
    max_technical_recoveries: int,
    max_match_attempts: int,
) -> ResumeDecision:
    if payload.finalized_status == "COMPLETED":
        return ResumeDecision(False, "CHECKPOINT_ALREADY_COMPLETED", {}, (), 0)

    graceful_lobby_stop = bool(
        payload.finalized_status == "STOPPED_GRACEFULLY"
        and payload.last_safe_lifecycle == "BOSS_LOBBY"
        and payload.stop_reason == "STOPPED_GRACEFULLY"
        and payload.stop_request_state == "STOPPED_AT_LOBBY"
    )
    interrupted_at_durable_lobby_boundary = bool(
        payload.finalized_status is None
        and payload.last_safe_lifecycle == "BOSS_LOBBY"
        and payload.stop_reason is None
        and payload.stop_request_state == "RUNNING"
    )
    if not (graceful_lobby_stop or interrupted_at_durable_lobby_boundary):
        return ResumeDecision(False, "CHECKPOINT_NOT_RESUMABLE", {}, (), 0)
    if (
        payload.target_boss_id != target_boss_id
        or payload.target_boss_name != target_boss_name
        or payload.configured_limits.get("target_completed_matches") != target_completed_matches
        or payload.configured_limits.get("max_technical_recoveries") != max_technical_recoveries
        or payload.configured_limits.get("max_match_attempts") != max_match_attempts
    ):
        return ResumeDecision(False, "CHECKPOINT_CONFIG_MISMATCH", {}, (), 0)
    if payload.completed_matches >= target_completed_matches:
        return ResumeDecision(False, "CHECKPOINT_ALREADY_COMPLETED", {}, (), 0)
    counters = {
        "match_attempts": payload.match_attempts,
        "completed_matches": payload.completed_matches,
        "wins": payload.wins,
        "losses": payload.losses,
        "unknown_results": payload.unknown_results,
        "technical_aborts": payload.technical_aborts,
        "technical_recoveries": payload.technical_recoveries,
        "technical_exits": payload.technical_exits,
        "pass_totals": payload.pass_totals,
    }
    remaining = target_completed_matches - payload.completed_matches
    return ResumeDecision(
        True,
        None,
        counters,
        payload.seen_match_ids,
        remaining,
        historical_action_aggregates=dict(payload.action_aggregates),
        historical_consistency_aggregates=dict(payload.consistency_aggregates),
        run_started_at=payload.run_started_at,
        last_completed_match_id=payload.last_completed_match_id,
    )


def _validate_nonnegative_counts(name: str, values: dict[str, Any]) -> None:
    if not isinstance(values, dict):
        raise CheckpointError("CHECKPOINT_INVALID", f"{name} must be an object")
    for key, value in values.items():
        if (
            not isinstance(key, str)
            or not key
            or isinstance(value, bool)
            or not isinstance(value, int)
            or value < 0
        ):
            raise CheckpointError(
                "CHECKPOINT_INVALID",
                f"{name} contains an invalid nonnegative counter: {key!r}={value!r}",
            )


def _validate_raw_payload_types(raw: dict[str, Any]) -> None:
    """Reject JSON type coercion (notably bool→int) before conversion."""

    integer_fields = {
        "checkpoint_seq",
        "match_attempts",
        "completed_matches",
        "wins",
        "losses",
        "unknown_results",
        "technical_aborts",
        "technical_recoveries",
        "technical_exits",
        "pass_totals",
    }
    for name in integer_fields:
        value = raw.get(name)
        if isinstance(value, bool) or not isinstance(value, int):
            raise CheckpointError(
                "CHECKPOINT_INVALID", f"{name} must be an integer"
            )
    for name in ("created_at", "updated_at", "run_started_at"):
        value = raw.get(name)
        if (
            isinstance(value, bool)
            or not isinstance(value, (int, float))
            or not math.isfinite(float(value))
        ):
            raise CheckpointError(
                "CHECKPOINT_INVALID", f"{name} must be a finite number"
            )
    for name in ("schema_version", "farm_run_id", "target_boss_id", "target_boss_name"):
        if not isinstance(raw.get(name), str):
            raise CheckpointError(
                "CHECKPOINT_INVALID", f"{name} must be a string"
            )
    for name in (
        "continuation_of",
        "last_completed_match_id",
        "last_safe_lifecycle",
        "stop_request_state",
        "stop_reason",
        "finalized_status",
    ):
        value = raw.get(name)
        if value is not None and not isinstance(value, str):
            raise CheckpointError(
                "CHECKPOINT_INVALID", f"{name} must be a string or null"
            )
    if not isinstance(raw.get("seen_match_ids"), list) or any(
        not isinstance(item, str) for item in raw["seen_match_ids"]
    ):
        raise CheckpointError(
            "CHECKPOINT_INVALID", "seen_match_ids must be an array of strings"
        )
    for name in ("configured_limits", "action_aggregates", "consistency_aggregates"):
        if not isinstance(raw.get(name), dict):
            raise CheckpointError("CHECKPOINT_INVALID", f"{name} must be an object")


def _validate_payload(payload: CheckpointPayload) -> None:
    """Reject internally inconsistent history before it can authorize input."""

    scalar_counts = {
        "checkpoint_seq": payload.checkpoint_seq,
        "match_attempts": payload.match_attempts,
        "completed_matches": payload.completed_matches,
        "wins": payload.wins,
        "losses": payload.losses,
        "unknown_results": payload.unknown_results,
        "technical_aborts": payload.technical_aborts,
        "technical_recoveries": payload.technical_recoveries,
        "technical_exits": payload.technical_exits,
        "pass_totals": payload.pass_totals,
    }
    _validate_nonnegative_counts("checkpoint counters", scalar_counts)
    if payload.checkpoint_seq < 1:
        raise CheckpointError("CHECKPOINT_INVALID", "checkpoint_seq must be >= 1")
    if not payload.farm_run_id.strip():
        raise CheckpointError("CHECKPOINT_INVALID", "farm_run_id cannot be blank")
    if not payload.target_boss_id.strip() and not payload.target_boss_name.strip():
        raise CheckpointError("CHECKPOINT_INVALID", "target boss identity is empty")
    if (
        payload.created_at <= 0
        or payload.updated_at < payload.created_at
        or payload.run_started_at <= 0
    ):
        raise CheckpointError("CHECKPOINT_INVALID", "checkpoint timestamps are inconsistent")
    if (
        payload.wins + payload.losses + payload.unknown_results
        != payload.completed_matches
    ):
        raise CheckpointError(
            "CHECKPOINT_INVALID", "completed result accounting is inconsistent"
        )
    if payload.completed_matches + payload.technical_aborts > payload.match_attempts:
        raise CheckpointError(
            "CHECKPOINT_INVALID", "attempt accounting is internally impossible"
        )
    if payload.technical_exits > payload.technical_aborts:
        raise CheckpointError(
            "CHECKPOINT_INVALID", "technical_exits exceeds technical_aborts"
        )
    expected_limits = {
        "target_completed_matches",
        "max_technical_recoveries",
        "max_match_attempts",
    }
    if set(payload.configured_limits) != expected_limits:
        raise CheckpointError(
            "CHECKPOINT_INVALID", "configured_limits has an unexpected shape"
        )
    _validate_nonnegative_counts("configured_limits", payload.configured_limits)
    if (
        payload.configured_limits["target_completed_matches"] < 1
        or payload.configured_limits["max_match_attempts"] < 1
        or payload.configured_limits["max_match_attempts"]
        < payload.configured_limits["target_completed_matches"]
        or payload.technical_recoveries
        > payload.configured_limits["max_technical_recoveries"]
        or payload.match_attempts > payload.configured_limits["max_match_attempts"]
    ):
        raise CheckpointError("CHECKPOINT_INVALID", "configured limits are inconsistent")
    if any(not value.strip() for value in payload.seen_match_ids):
        raise CheckpointError("CHECKPOINT_INVALID", "seen_match_ids contains a blank ID")
    if len(set(payload.seen_match_ids)) != len(payload.seen_match_ids):
        raise CheckpointError("CHECKPOINT_INVALID", "seen_match_ids contains duplicates")
    if len(payload.seen_match_ids) != payload.match_attempts:
        raise CheckpointError(
            "CHECKPOINT_INVALID", "seen MatchId count does not match match_attempts"
        )
    if (
        payload.last_completed_match_id is not None
        and payload.last_completed_match_id not in payload.seen_match_ids
    ):
        raise CheckpointError(
            "CHECKPOINT_INVALID", "last completed MatchId is not in history"
        )
    if (payload.completed_matches > 0) != (
        payload.last_completed_match_id is not None
    ):
        raise CheckpointError(
            "CHECKPOINT_INVALID",
            "last completed MatchId does not match completed match history",
        )
    _validate_nonnegative_counts("action_aggregates", payload.action_aggregates)
    _validate_nonnegative_counts(
        "consistency_aggregates", payload.consistency_aggregates
    )
    required_action_keys = {
        "swap_sent",
        "swap_acknowledged",
        "swap_rejected",
        "swap_aborted_state_changed",
        "cast_sent",
        "cast_accepted",
        "cast_rejected",
        "evolve_attempts",
        "evolve_success",
        "evolve_failed",
    }
    required_consistency_keys = {
        "consistent",
        "memory_incomplete",
        "conflicts",
        "strong_terminal_results",
    }
    if set(payload.action_aggregates) != required_action_keys:
        raise CheckpointError(
            "CHECKPOINT_INVALID", "action_aggregates has an unexpected shape"
        )
    if set(payload.consistency_aggregates) != required_consistency_keys:
        raise CheckpointError(
            "CHECKPOINT_INVALID", "consistency_aggregates has an unexpected shape"
        )
    if (
        payload.action_aggregates["swap_acknowledged"]
        > payload.action_aggregates["swap_sent"]
        or payload.action_aggregates["swap_aborted_state_changed"]
        > payload.action_aggregates["swap_sent"]
        or payload.action_aggregates["cast_accepted"]
        + payload.action_aggregates["cast_rejected"]
        > payload.action_aggregates["cast_sent"]
        or payload.action_aggregates["evolve_success"]
        + payload.action_aggregates["evolve_failed"]
        > payload.action_aggregates["evolve_attempts"]
    ):
        raise CheckpointError(
            "CHECKPOINT_INVALID", "action aggregates are internally inconsistent"
        )
    if (
        payload.consistency_aggregates["consistent"]
        + payload.consistency_aggregates["memory_incomplete"]
        + payload.consistency_aggregates["conflicts"]
        > payload.completed_matches
    ):
        raise CheckpointError(
            "CHECKPOINT_INVALID", "result consistency counts exceed completed matches"
        )
    if payload.consistency_aggregates["strong_terminal_results"] > payload.completed_matches:
        raise CheckpointError(
            "CHECKPOINT_INVALID", "strong result count exceeds completed matches"
        )


def _payload_to_dict(payload: CheckpointPayload) -> dict[str, Any]:
    return {
        "schema_version": payload.schema_version,
        "farm_run_id": payload.farm_run_id,
        "continuation_of": payload.continuation_of,
        "checkpoint_seq": payload.checkpoint_seq,
        "created_at": payload.created_at,
        "updated_at": payload.updated_at,
        "target_boss_id": payload.target_boss_id,
        "target_boss_name": payload.target_boss_name,
        "configured_limits": dict(payload.configured_limits),
        "run_started_at": payload.run_started_at,
        "match_attempts": payload.match_attempts,
        "completed_matches": payload.completed_matches,
        "wins": payload.wins,
        "losses": payload.losses,
        "unknown_results": payload.unknown_results,
        "technical_aborts": payload.technical_aborts,
        "technical_recoveries": payload.technical_recoveries,
        "technical_exits": payload.technical_exits,
        "last_completed_match_id": payload.last_completed_match_id,
        "seen_match_ids": list(payload.seen_match_ids),
        "action_aggregates": dict(payload.action_aggregates),
        "pass_totals": payload.pass_totals,
        "consistency_aggregates": dict(payload.consistency_aggregates),
        "last_safe_lifecycle": payload.last_safe_lifecycle,
        "stop_request_state": payload.stop_request_state,
        "stop_reason": payload.stop_reason,
        "finalized_status": payload.finalized_status,
    }


def _dict_to_payload(raw: dict[str, Any]) -> CheckpointPayload:
    return CheckpointPayload(
        schema_version=str(raw["schema_version"]),
        farm_run_id=str(raw["farm_run_id"]),
        continuation_of=(str(raw["continuation_of"]) if raw.get("continuation_of") else None),
        checkpoint_seq=int(raw["checkpoint_seq"]),
        created_at=float(raw["created_at"]),
        updated_at=float(raw["updated_at"]),
        target_boss_id=str(raw["target_boss_id"]),
        target_boss_name=str(raw["target_boss_name"]),
        configured_limits=dict(raw["configured_limits"]),
        run_started_at=float(raw["run_started_at"]),
        match_attempts=int(raw["match_attempts"]),
        completed_matches=int(raw["completed_matches"]),
        wins=int(raw["wins"]),
        losses=int(raw["losses"]),
        unknown_results=int(raw["unknown_results"]),
        technical_aborts=int(raw["technical_aborts"]),
        technical_recoveries=int(raw["technical_recoveries"]),
        technical_exits=int(raw["technical_exits"]),
        last_completed_match_id=(
            str(raw["last_completed_match_id"]) if raw.get("last_completed_match_id") else None
        ),
        seen_match_ids=tuple(str(x) for x in raw["seen_match_ids"]),
        action_aggregates=dict(raw["action_aggregates"]),
        pass_totals=int(raw["pass_totals"]),
        consistency_aggregates=dict(raw["consistency_aggregates"]),
        last_safe_lifecycle=(
            str(raw["last_safe_lifecycle"]) if raw.get("last_safe_lifecycle") else None
        ),
        stop_request_state=(
            str(raw["stop_request_state"]) if raw.get("stop_request_state") else None
        ),
        stop_reason=str(raw["stop_reason"]) if raw.get("stop_reason") else None,
        finalized_status=(
            str(raw["finalized_status"]) if raw.get("finalized_status") else None
        ),
    )
