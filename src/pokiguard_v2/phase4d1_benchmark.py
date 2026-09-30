"""Offline acceptance analyzer for Phase 4D.1.

The module only reads immutable FarmRunner artifacts.  It never imports the
controller or sends game input.  A manifest freezes the source/game/config and
binds exactly one foreground run and one pinned-foreground Beta run.
"""

from __future__ import annotations

from collections import Counter, defaultdict
from datetime import datetime, timezone
import hashlib
import json
import math
from pathlib import Path
from statistics import median, pstdev
import subprocess
from typing import Any, Iterable, Mapping, Sequence


MANIFEST_SCHEMA = "pokiguard.phase4d1.manifest.v1"
DATASET_SCHEMA = "pokiguard.phase4d1.dataset.v1"
ANALYZER_VERSION = "1"
ARM_A = "A_FOREGROUND"
ARM_B = "B_PINNED_FOREGROUND_BETA"
ARM_MODES = {
    ARM_A: "foreground",
    ARM_B: "pinned_foreground_lease_beta",
}
COMPLETED_RESULTS = frozenset({"WIN", "LOSS", "UNKNOWN"})
CRITICAL_COUNTERS = (
    "duplicate_inputs",
    "misclicks",
    "partial_inputs",
    "wrong_turn_inputs",
    "stale_actions",
    "expired_actions",
    "action_response_timeouts",
    "sequence_desync",
    "wrong_third_pass",
    "boss_turn_inputs",
    "postmatch_inputs",
    "lobby_inputs",
    "input_after_combat",
    "local_turn_deadline_safe_stops",
    "pet_skill_zero_input_failures",
    "pet_skill_after_input_failures",
    "pet_skill_turn_resolution_unconfirmed",
    "action_aborted_due_lifecycle",
    "swap_aborted_due_lifecycle",
)


class BenchmarkDataError(ValueError):
    """Raised when Phase 4D.1 evidence is missing or structurally invalid."""


def _mapping(value: Any, label: str) -> Mapping[str, Any]:
    if not isinstance(value, Mapping):
        raise BenchmarkDataError(f"{label} must be an object")
    return value


def _sequence(value: Any, label: str) -> Sequence[Any]:
    if not isinstance(value, list):
        raise BenchmarkDataError(f"{label} must be an array")
    return value


def _text(value: Any, label: str) -> str:
    if not isinstance(value, str) or not value.strip():
        raise BenchmarkDataError(f"{label} must be a non-empty string")
    return value.strip()


def _integer(value: Any, label: str) -> int:
    if isinstance(value, bool) or not isinstance(value, int) or value < 0:
        raise BenchmarkDataError(f"{label} must be a non-negative integer")
    return value


def _read_json(path: Path) -> dict[str, Any]:
    try:
        value = json.loads(path.read_text(encoding="utf-8"))
    except (OSError, json.JSONDecodeError) as exc:
        raise BenchmarkDataError(f"cannot read valid JSON: {path}") from exc
    return dict(_mapping(value, str(path)))


def _read_jsonl(path: Path) -> list[dict[str, Any]]:
    try:
        lines = path.read_text(encoding="utf-8").splitlines()
    except OSError as exc:
        raise BenchmarkDataError(f"cannot read JSONL: {path}") from exc
    result: list[dict[str, Any]] = []
    for index, line in enumerate(lines, start=1):
        if not line.strip():
            continue
        try:
            result.append(dict(_mapping(json.loads(line), f"{path}:{index}")))
        except json.JSONDecodeError as exc:
            raise BenchmarkDataError(f"invalid JSONL at {path}:{index}") from exc
    return result


def _timestamp(value: Any, label: str) -> datetime:
    text = _text(value, label)
    try:
        parsed = datetime.fromisoformat(text.replace("Z", "+00:00"))
    except ValueError as exc:
        raise BenchmarkDataError(f"{label} is not an ISO timestamp") from exc
    if parsed.tzinfo is None:
        raise BenchmarkDataError(f"{label} must include a timezone")
    return parsed


def _duration(start: Any, end: Any) -> float:
    seconds = (_timestamp(end, "end") - _timestamp(start, "start")).total_seconds()
    if seconds < 0:
        raise BenchmarkDataError("negative ACK latency")
    return round(seconds, 3)


def _stats(values: Iterable[int | float]) -> dict[str, Any]:
    numbers = [float(value) for value in values]
    if not numbers:
        return {
            "status": "NOT_MEASURED",
            "n": 0,
            "mean": None,
            "median": None,
            "min": None,
            "max": None,
            "stddev": None,
            "total": 0.0,
        }
    if any(not math.isfinite(value) or value < 0 for value in numbers):
        raise BenchmarkDataError("statistics contain invalid values")
    return {
        "status": "MEASURED",
        "n": len(numbers),
        "mean": round(sum(numbers) / len(numbers), 3),
        "median": round(float(median(numbers)), 3),
        "min": round(min(numbers), 3),
        "max": round(max(numbers), 3),
        "stddev": round(float(pstdev(numbers)), 3),
        "total": round(sum(numbers), 3),
    }


def _sha256(path: Path) -> str:
    digest = hashlib.sha256()
    try:
        with path.open("rb") as handle:
            for chunk in iter(lambda: handle.read(1024 * 1024), b""):
                digest.update(chunk)
    except OSError as exc:
        raise BenchmarkDataError(f"cannot hash {path}") from exc
    return digest.hexdigest()


def source_fingerprint(workspace: Path) -> dict[str, Any]:
    """Fingerprint production Python and launch sources in a stable order."""

    files = sorted(
        [*workspace.glob("src/pokiguard_v2/**/*.py"), *workspace.glob("tools/**/*.py")]
        + ([workspace / "run_tool.bat"] if (workspace / "run_tool.bat").is_file() else []),
        key=lambda path: path.relative_to(workspace).as_posix(),
    )
    if not files:
        raise BenchmarkDataError("workspace source fingerprint has no files")
    digest = hashlib.sha256()
    for path in files:
        relative = path.relative_to(workspace).as_posix()
        digest.update(relative.encode("utf-8"))
        digest.update(b"\0")
        digest.update(bytes.fromhex(_sha256(path)))
    return {
        "algorithm": "sha256(path + NUL + file_sha256)",
        "file_count": len(files),
        "fingerprint_sha256": digest.hexdigest(),
        "included_roots": ["src/pokiguard_v2/**/*.py", "tools/**/*.py", "run_tool.bat"],
    }


def _git_value(workspace: Path, *args: str) -> str:
    try:
        result = subprocess.run(
            ["git", *args],
            cwd=workspace,
            check=True,
            capture_output=True,
            text=True,
        )
    except (OSError, subprocess.CalledProcessError) as exc:
        raise BenchmarkDataError(f"git {' '.join(args)} failed") from exc
    return result.stdout.strip()


def prepare_manifest(
    *,
    workspace: Path,
    app_version: str,
    game_executable: Path,
    game_assembly: Path,
    expected_target: Mapping[str, Any],
    gameplay_config: Mapping[str, Any],
    required_completed_matches: int = 5,
    max_match_attempts: int = 8,
) -> dict[str, Any]:
    if required_completed_matches <= 0:
        raise BenchmarkDataError("required_completed_matches must be positive")
    if max_match_attempts < required_completed_matches:
        raise BenchmarkDataError("max_match_attempts cannot be below target")
    target = {
        "boss_id": _text(expected_target.get("boss_id"), "expected_target.boss_id"),
        "boss_name": _text(expected_target.get("boss_name"), "expected_target.boss_name"),
    }
    commit = _git_value(workspace, "rev-parse", "HEAD")
    dirty = bool(_git_value(workspace, "status", "--porcelain"))
    return {
        "schema": MANIFEST_SCHEMA,
        "prepared_at": datetime.now(timezone.utc).isoformat(timespec="milliseconds").replace(
            "+00:00", "Z"
        ),
        "source": {
            "commit": commit,
            "worktree_dirty": dirty,
            **source_fingerprint(workspace),
        },
        "app_version": _text(app_version, "app_version"),
        "game_build": {
            "executable": {
                "path": str(game_executable.resolve()),
                "sha256": _sha256(game_executable),
            },
            "game_assembly": {
                "path": str(game_assembly.resolve()),
                "sha256": _sha256(game_assembly),
            },
        },
        "expected_target": target,
        "gameplay_config": dict(gameplay_config),
        "required_completed_matches_per_arm": required_completed_matches,
        "max_match_attempts_per_arm": max_match_attempts,
        "execution_order": [ARM_A, ARM_B],
        "accepted_branch": "PINNED_FOREGROUND_EXISTING_INPUT_LEASE",
        "focus_schedule": {
            ARM_A: (
                "Giữ game foreground suốt 5 trận; không chuyển focus, không "
                "di chuyển/resize/minimize cửa sổ game."
            ),
            ARM_B: (
                "Game được pin suốt run. Sau khi board trận 1, 3 và 5 xuất hiện, "
                "chuyển focus sang một cửa sổ khác và để tool tự lấy focus trong "
                "action lease kế tiếp; không di chuyển/resize/minimize game."
            ),
        },
        "arms": {
            ARM_A: {"input_delivery_mode": ARM_MODES[ARM_A], "farm_run_id": None},
            ARM_B: {"input_delivery_mode": ARM_MODES[ARM_B], "farm_run_id": None},
        },
    }


def assign_run(manifest: Mapping[str, Any], arm: str, farm_run_id: str) -> dict[str, Any]:
    if arm not in ARM_MODES:
        raise BenchmarkDataError(f"unsupported arm: {arm}")
    run_id = _text(farm_run_id, "farm_run_id")
    value = json.loads(json.dumps(manifest))
    if value.get("schema") != MANIFEST_SCHEMA:
        raise BenchmarkDataError("unsupported Phase 4D.1 manifest schema")
    arms = _mapping(value.get("arms"), "manifest.arms")
    arm_spec = dict(_mapping(arms.get(arm), f"manifest.arms.{arm}"))
    arm_spec["farm_run_id"] = run_id
    value["arms"][arm] = arm_spec
    return value


def _event_rows(events: Sequence[Mapping[str, Any]], name: str) -> list[Mapping[str, Any]]:
    return [event for event in events if event.get("event") == name]


def _combat_events(run_directory: Path, attempts: Sequence[Any]) -> list[dict[str, Any]]:
    rows: list[dict[str, Any]] = []
    for raw in attempts:
        attempt = _mapping(raw, "attempt")
        index = _integer(attempt.get("attempt_index"), "attempt.attempt_index")
        path = run_directory / "matches" / f"attempt_{index:03d}" / "combat.jsonl"
        if path.is_file():
            rows.extend(_read_jsonl(path))
    return rows


def _aggregate_counters(events: Sequence[Mapping[str, Any]]) -> dict[str, int]:
    totals = {name: 0 for name in CRITICAL_COUNTERS}
    for event in _event_rows(events, "combat_controller_returned"):
        summary = _mapping(event.get("summary"), "combat_controller_returned.summary")
        counters = _mapping(summary.get("counters"), "combat_controller_returned.counters")
        for name in totals:
            totals[name] += _integer(counters.get(name, 0), f"counters.{name}")
    return totals


def _ack_latencies(
    snapshot: Mapping[str, Any],
    events: Sequence[Mapping[str, Any]],
    combat_events: Sequence[Mapping[str, Any]],
) -> dict[str, Any]:
    by_domain: dict[str, list[float]] = defaultdict(list)
    inputs = [
        _mapping(row, "input_record")
        for row in _sequence(snapshot.get("input_records"), "snapshot.input_records")
        if _mapping(row, "input_record").get("sent") is True
    ]

    def pair(domain: str, acknowledgements: Sequence[Mapping[str, Any]]) -> None:
        sent = [row for row in inputs if row.get("domain") == domain]
        for left, right in zip(sent, acknowledgements):
            by_domain[domain].append(_duration(left.get("timestamp"), right.get("timestamp")))

    pair(
        "BOSS_ENTRY",
        [
            event
            for event in _event_rows(events, "match_entry_result")
            if _mapping(event.get("entry"), "match_entry_result.entry").get("status") == "PASS"
        ],
    )
    pair(
        "POSTMATCH_CONFIRM",
        [
            event
            for event in _event_rows(events, "postmatch_ui_audit")
            if event.get("consistency") == "CONSISTENT"
        ],
    )
    pair(
        "BOSS_TARGET_SELECT",
        [
            event
            for event in _event_rows(events, "chinh_phuc_map_return")
            if _mapping(event.get("result"), "chinh_phuc_map_return.result").get("ready") is True
        ],
    )

    sent_actions: dict[str, list[Mapping[str, Any]]] = defaultdict(list)
    ack_actions: dict[str, list[Mapping[str, Any]]] = defaultdict(list)
    for event in combat_events:
        if event.get("event") == "action_sent":
            sent_actions[str(event.get("action") or "")].append(event)
        elif event.get("event") == "action_result" and str(event.get("result") or "").endswith(
            ("ACKNOWLEDGED", "ACCEPTED", "SUCCESS")
        ):
            action = _mapping(event.get("action"), "action_result.action")
            identity = _mapping(action.get("identity"), "action_result.identity")
            name = str(identity.get("action") or "").upper()
            ack_actions[name].append(event)
    for action, domain in (
        ("SWAP", "GAMEPLAY_SWAP"),
        ("CAST", "GAMEPLAY_CAST"),
        ("EVOLVE", "GAMEPLAY_EVOLVE"),
    ):
        for left, right in zip(sent_actions[action], ack_actions[action]):
            by_domain[domain].append(_duration(left.get("timestamp"), right.get("timestamp")))

    skill_starts = _event_rows(combat_events, "pet_skill_dispatch_started")
    skill_results = [
        event
        for event in _event_rows(combat_events, "pet_skill_dispatch_result")
        if str(_mapping(event.get("result"), "pet_skill_dispatch_result.result").get("kind") or "").startswith(
            "SUCCESS_"
        )
    ]
    for left, right in zip(skill_starts, skill_results):
        by_domain["GAMEPLAY_PET_SKILL"].append(
            _duration(left.get("timestamp"), right.get("timestamp"))
        )
    return {domain: _stats(values) for domain, values in sorted(by_domain.items())}


def _input_domain_summary(
    snapshot: Mapping[str, Any], events: Sequence[Mapping[str, Any]], counters: Mapping[str, int]
) -> dict[str, Any]:
    records = [
        _mapping(row, "input_record")
        for row in _sequence(snapshot.get("input_records"), "snapshot.input_records")
    ]
    sent = Counter(str(row.get("domain") or "UNKNOWN") for row in records if row.get("sent") is True)
    queued = Counter(str(row.get("domain") or "UNKNOWN") for row in records)
    ack = Counter(
        {
            "GAMEPLAY_SWAP": _integer(
                snapshot.get("total_swap_acknowledged", 0), "total_swap_acknowledged"
            ),
            "GAMEPLAY_CAST": _integer(
                snapshot.get("total_cast_accepted", 0), "total_cast_accepted"
            ),
            "GAMEPLAY_EVOLVE": _integer(
                snapshot.get("total_evolve_success", 0), "total_evolve_success"
            ),
            "GAMEPLAY_PET_SKILL": _integer(
                counters.get("pet_skill_perfect", 0), "pet_skill_perfect"
            ),
            "BOSS_ENTRY": sum(
                1
                for event in _event_rows(events, "match_entry_result")
                if _mapping(event.get("entry"), "match_entry_result.entry").get("status") == "PASS"
            ),
            "POSTMATCH_CONFIRM": sum(
                1
                for event in _event_rows(events, "postmatch_ui_audit")
                if event.get("consistency") == "CONSISTENT"
            ),
            "BOSS_TARGET_SELECT": sum(
                1
                for event in _event_rows(events, "chinh_phuc_map_return")
                if _mapping(event.get("result"), "chinh_phuc_map_return.result").get("ready")
                is True
            ),
        }
    )
    domains = sorted(set(queued) | set(ack))
    return {
        domain: {
            "queued": queued[domain],
            "sent": sent[domain],
            "acknowledged": ack[domain],
            "unconfirmed": max(sent[domain] - ack[domain], 0),
        }
        for domain in domains
        if queued[domain] or ack[domain]
    }


def _lease_summary(events: Sequence[Mapping[str, Any]], arm: str) -> tuple[dict[str, Any], list[str]]:
    failures: list[str] = []
    mouse_acquired = _event_rows(events, "foreground_lease_acquired")
    mouse_finished = _event_rows(events, "foreground_lease_finished")
    qte_acquired = _event_rows(events, "foreground_qte_lease_acquired")
    qte_released = _event_rows(events, "foreground_qte_lease_released")
    pinned_started = _event_rows(events, "pinned_input_session_started")
    pinned_closed = _event_rows(events, "pinned_input_session_closed")
    if arm == ARM_A:
        if mouse_acquired or mouse_finished or qte_acquired or qte_released or pinned_started:
            failures.append("foreground arm unexpectedly used pinned foreground lease telemetry")
    else:
        if len(pinned_started) != 1:
            failures.append("Beta arm must have exactly one pinned session start")
        if len(pinned_closed) != 1 or any(
            _mapping(event.get("result"), "pinned_input_session_closed.result").get("status")
            != "UNPINNED"
            for event in pinned_closed
        ):
            failures.append("Beta pinned session did not unpin cleanly")
        if len(mouse_acquired) != len(mouse_finished):
            failures.append("mouse lease acquire/release counts differ")
        if len(qte_acquired) != len(qte_released):
            failures.append("QTE lease acquire/release counts differ")
        acquired_ids = Counter(str(event.get("actionIdentity") or "") for event in mouse_acquired)
        finished_ids = Counter(str(event.get("action_identity") or "") for event in mouse_finished)
        if acquired_ids != finished_ids or "" in acquired_ids:
            failures.append("mouse lease action identities are incomplete or mismatched")
        qte_acquired_ids = Counter(str(event.get("action_identity") or "") for event in qte_acquired)
        qte_released_ids = Counter(str(event.get("action_identity") or "") for event in qte_released)
        if qte_acquired_ids != qte_released_ids or "" in qte_acquired_ids:
            failures.append("QTE lease action identities are incomplete or mismatched")
        for event in mouse_finished:
            if not (
                event.get("status") == "COMPLETE"
                and event.get("action_attempted") is True
                and event.get("action_succeeded") is True
                and event.get("focus_restored") is True
                and event.get("cursor_restored") is True
                and event.get("user_moved_cursor") is False
            ):
                failures.append("mouse lease has failed action/focus/cursor cleanup")
                break
        for event in qte_released:
            if not (
                event.get("status") == "COMPLETE"
                and event.get("guard_released") is True
                and event.get("focus_restored") is True
                and event.get("cursor_restored") is True
            ):
                failures.append("QTE lease cleanup is incomplete")
                break
    takeover_count = sum(
        1
        for event in mouse_acquired
        if event.get("gameAlreadyForeground") is False
        or _integer(event.get("focusRequestCount", 0), "focusRequestCount") > 0
    ) + sum(
        1
        for event in qte_acquired
        if _integer(event.get("focusRequestCount", 0), "focusRequestCount") > 0
    )
    return (
        {
            "mouse_leases": len(mouse_acquired),
            "qte_leases": len(qte_acquired),
            "focus_takeovers": takeover_count,
            "mouse_duration_seconds": _stats(
                event.get("lease_duration_seconds", 0.0) for event in mouse_finished
            ),
            "qte_duration_seconds": _stats(
                event.get("duration_seconds", 0.0) for event in qte_released
            ),
            "cursor_restored_count": sum(
                event.get("cursor_restored") is True for event in mouse_finished
            ),
            "focus_restored_count": sum(
                event.get("focus_restored") is True for event in mouse_finished
            ),
            "user_cursor_movement_count": sum(
                event.get("user_moved_cursor") is True for event in mouse_finished
            ),
            "pinned_session_started": len(pinned_started),
            "pinned_session_closed": len(pinned_closed),
        },
        failures,
    )


def _extract_run(
    *, run_directory: Path, arm: str, manifest: Mapping[str, Any]
) -> dict[str, Any]:
    raw = _read_json(run_directory / "run.json")
    checkpoint = _read_json(run_directory / "checkpoint.json")
    events = _read_jsonl(run_directory / "events.jsonl")
    if raw.get("schema") != "pokiguard.farm_run.v2":
        raise BenchmarkDataError(f"{run_directory.name}: unsupported run schema")
    snapshot = _mapping(raw.get("snapshot"), f"{run_directory.name}.snapshot")
    run_id = _text(snapshot.get("farm_run_id"), "snapshot.farm_run_id")
    if run_id != run_directory.name:
        raise BenchmarkDataError("FarmRunId does not match artifact directory")
    failures: list[str] = []
    expected_mode = ARM_MODES[arm]
    if snapshot.get("input_delivery_mode") != expected_mode:
        failures.append("snapshot input delivery mode differs from manifest arm")
    if checkpoint.get("input_delivery_mode") != expected_mode:
        failures.append("checkpoint input delivery mode differs from manifest arm")
    starts = _event_rows(events, "farm_run_started")
    if len(starts) != 1 or starts[0].get("inputDeliveryMode") != expected_mode:
        failures.append("farm_run_started mode is missing or inconsistent")
    expected_target = _mapping(manifest.get("expected_target"), "manifest.expected_target")
    if dict(_mapping(snapshot.get("target"), "snapshot.target")) != dict(expected_target):
        failures.append("boss target differs from manifest")
    expected_config = dict(_mapping(manifest.get("gameplay_config"), "manifest.gameplay_config"))
    if dict(_mapping(snapshot.get("gameplay_config"), "snapshot.gameplay_config")) != expected_config:
        failures.append("gameplay configuration differs from manifest")
    if dict(_mapping(checkpoint.get("gameplay_config"), "checkpoint.gameplay_config")) != expected_config:
        failures.append("checkpoint gameplay configuration differs from manifest")
    required = _integer(
        manifest.get("required_completed_matches_per_arm"),
        "manifest.required_completed_matches_per_arm",
    )
    attempts = _integer(snapshot.get("match_attempts"), "snapshot.match_attempts")
    completed = _integer(snapshot.get("completed_matches"), "snapshot.completed_matches")
    wins = _integer(snapshot.get("wins"), "snapshot.wins")
    losses = _integer(snapshot.get("losses"), "snapshot.losses")
    unknown = _integer(snapshot.get("unknown_results"), "snapshot.unknown_results")
    attempt_rows = _sequence(snapshot.get("attempts"), "snapshot.attempts")
    if len(attempt_rows) != attempts:
        failures.append("attempt row count differs from match_attempts")
    if completed != required:
        failures.append(f"completed {completed}, expected exactly {required}")
    if attempts != completed:
        failures.append("extra or incomplete match attempt observed")
    if wins + losses + unknown != completed:
        failures.append("W/L/U accounting differs from completed matches")
    if unknown:
        failures.append("unexplained UNKNOWN match result observed")
    if any(_mapping(row, "attempt").get("result") not in COMPLETED_RESULTS for row in attempt_rows):
        failures.append("technical abort or safe-stop attempt is present")
    expected_limits = {
        "target_completed_matches": required,
        "max_match_attempts": _integer(
            manifest.get("max_match_attempts_per_arm"),
            "manifest.max_match_attempts_per_arm",
        ),
    }
    limits = _mapping(snapshot.get("limits"), "snapshot.limits")
    for key, value in expected_limits.items():
        if limits.get(key) != value:
            failures.append(f"configured limit {key} differs from manifest")
    if snapshot.get("state") != "FARM_RUN_COMPLETE":
        failures.append("final FarmRunner state is not FARM_RUN_COMPLETE")
    if snapshot.get("stop_reason") != "FARM_TARGET_COMPLETED":
        failures.append("FarmRunner stop reason is not FARM_TARGET_COMPLETED")
    if checkpoint.get("finalized_status") != "COMPLETED":
        failures.append("checkpoint is not finalized COMPLETED")
    if checkpoint.get("stop_reason") != "FARM_TARGET_COMPLETED":
        failures.append("checkpoint stop reason is not FARM_TARGET_COMPLETED")
    if checkpoint.get("last_safe_lifecycle") != "BOSS_LOBBY":
        failures.append("checkpoint did not finish at BOSS_LOBBY")
    if raw.get("finalLifecycle") != "BOSS_LOBBY":
        failures.append("run artifact did not finish at BOSS_LOBBY")
    if raw.get("unexpectedError") is not None:
        failures.append("run artifact contains unexpectedError")
    for key in ("memoryWrites", "directGameCalls", "networkManipulation"):
        if raw.get(key) is not False:
            failures.append(f"run safety flag {key} is not false")
    counters = _aggregate_counters(events)
    # Keep successful Pet Skill ACK telemetry next to safety counters.
    counters["pet_skill_perfect"] = sum(
        _integer(
            _mapping(
                _mapping(event.get("summary"), "combat_controller_returned.summary").get("counters"),
                "combat_controller_returned.counters",
            ).get("pet_skill_perfect", 0),
            "pet_skill_perfect",
        )
        for event in _event_rows(events, "combat_controller_returned")
    )
    nonzero_critical = {name: counters[name] for name in CRITICAL_COUNTERS if counters[name]}
    if nonzero_critical:
        failures.append("critical safety counter is non-zero")
    domains = _input_domain_summary(snapshot, events, counters)
    unconfirmed = {name: row["unconfirmed"] for name, row in domains.items() if row["unconfirmed"]}
    if unconfirmed:
        failures.append("sent input lacks authoritative ACK")
    lease, lease_failures = _lease_summary(events, arm)
    failures.extend(lease_failures)
    combat_events = _combat_events(run_directory, attempt_rows)
    return {
        "arm": arm,
        "input_delivery_mode": expected_mode,
        "farm_run_id": run_id,
        "start_timestamp": snapshot.get("start_timestamp"),
        "end_timestamp": snapshot.get("end_timestamp"),
        "duration_seconds": snapshot.get("duration_seconds"),
        "completed": completed,
        "attempts": attempts,
        "wins": wins,
        "losses": losses,
        "unknown": unknown,
        "technical_aborts": snapshot.get("technical_aborts", 0),
        "technical_recoveries": snapshot.get("technical_recoveries", 0),
        "technical_exits": snapshot.get("technical_exits", 0),
        "safe_stops": snapshot.get("safe_stops", 0),
        "inputs_by_domain": domains,
        "ack_latency_seconds": _ack_latencies(snapshot, events, combat_events),
        "critical_counters": {name: counters[name] for name in CRITICAL_COUNTERS},
        "nonzero_critical_counters": nonzero_critical,
        "focus_and_cleanup": lease,
        "final_controller_state": snapshot.get("control_state"),
        "final_lifecycle": raw.get("finalLifecycle"),
        "stop_reason": snapshot.get("stop_reason"),
        "checkpoint_finalized_status": checkpoint.get("finalized_status"),
        "acceptance_failures": failures,
        "pass": not failures,
    }


def _validate_frozen_environment(
    manifest: Mapping[str, Any], workspace: Path | None
) -> tuple[dict[str, Any], list[str]]:
    failures: list[str] = []
    source = _mapping(manifest.get("source"), "manifest.source")
    result: dict[str, Any] = {
        "declared_source_fingerprint": source.get("fingerprint_sha256"),
        "current_source_fingerprint": None,
        "source_matches": None,
        "game_files_match": {},
    }
    if workspace is not None:
        current = source_fingerprint(workspace)
        result["current_source_fingerprint"] = current["fingerprint_sha256"]
        result["source_matches"] = current["fingerprint_sha256"] == source.get(
            "fingerprint_sha256"
        )
        if not result["source_matches"]:
            failures.append("current production source fingerprint differs from manifest")
    game = _mapping(manifest.get("game_build"), "manifest.game_build")
    for label in ("executable", "game_assembly"):
        spec = _mapping(game.get(label), f"manifest.game_build.{label}")
        path = Path(_text(spec.get("path"), f"game_build.{label}.path"))
        expected = _text(spec.get("sha256"), f"game_build.{label}.sha256")
        actual = _sha256(path)
        matches = actual.lower() == expected.lower()
        result["game_files_match"][label] = {
            "path": str(path),
            "expected_sha256": expected,
            "actual_sha256": actual,
            "matches": matches,
        }
        if not matches:
            failures.append(f"current {label} hash differs from manifest")
    return result, failures


def analyze_manifest(
    manifest_path: Path, logs_root: Path, *, workspace: Path | None = None
) -> dict[str, Any]:
    manifest = _read_json(manifest_path)
    if manifest.get("schema") != MANIFEST_SCHEMA:
        raise BenchmarkDataError("unsupported Phase 4D.1 manifest schema")
    order = list(_sequence(manifest.get("execution_order"), "manifest.execution_order"))
    if order != [ARM_A, ARM_B]:
        raise BenchmarkDataError("execution_order must be A_FOREGROUND then B_PINNED_FOREGROUND_BETA")
    arms = _mapping(manifest.get("arms"), "manifest.arms")
    run_ids: list[str] = []
    runs: dict[str, Any] = {}
    environment, failures = _validate_frozen_environment(manifest, workspace)
    for arm in order:
        spec = _mapping(arms.get(arm), f"manifest.arms.{arm}")
        if spec.get("input_delivery_mode") != ARM_MODES[arm]:
            raise BenchmarkDataError(f"manifest mode is invalid for {arm}")
        run_id = _text(spec.get("farm_run_id"), f"manifest.arms.{arm}.farm_run_id")
        run_ids.append(run_id)
        runs[arm] = _extract_run(
            run_directory=logs_root / run_id, arm=arm, manifest=manifest
        )
        failures.extend(f"{arm}: {reason}" for reason in runs[arm]["acceptance_failures"])
    if len(set(run_ids)) != 2:
        raise BenchmarkDataError("A and B must bind different FarmRunIds")
    pass_strong = not failures and all(runs[arm]["pass"] for arm in order)
    return {
        "schema": DATASET_SCHEMA,
        "analyzer_version": ANALYZER_VERSION,
        "analyzed_at": datetime.now(timezone.utc).isoformat(timespec="milliseconds").replace(
            "+00:00", "Z"
        ),
        "manifest": str(manifest_path.resolve()),
        "source": dict(_mapping(manifest.get("source"), "manifest.source")),
        "app_version": manifest.get("app_version"),
        "game_build": dict(_mapping(manifest.get("game_build"), "manifest.game_build")),
        "expected_target": dict(
            _mapping(manifest.get("expected_target"), "manifest.expected_target")
        ),
        "gameplay_config": dict(
            _mapping(manifest.get("gameplay_config"), "manifest.gameplay_config")
        ),
        "required_completed_matches_per_arm": manifest.get(
            "required_completed_matches_per_arm"
        ),
        "execution_order": order,
        "environment_validation": environment,
        "arms": runs,
        "acceptance": {
            "result": "PASS_STRONG" if pass_strong else "FAIL",
            "pass_strong": pass_strong,
            "failures": failures,
        },
    }


def write_json(path: Path, payload: Mapping[str, Any]) -> None:
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(json.dumps(payload, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")


def render_markdown_summary(analysis: Mapping[str, Any]) -> str:
    arms = _mapping(analysis.get("arms"), "analysis.arms")
    lines = [
        "# Phase 4D.1 — Foreground vs Pinned Foreground Beta A/B",
        "",
        f"Result: **{_mapping(analysis.get('acceptance'), 'acceptance').get('result')}**",
        "",
        "| Metric | A foreground | B pinned foreground Beta |",
        "|---|---:|---:|",
    ]
    a = _mapping(arms.get(ARM_A), ARM_A)
    b = _mapping(arms.get(ARM_B), ARM_B)
    for label, key in (
        ("FarmRunId", "farm_run_id"),
        ("Completed", "completed"),
        ("Attempts", "attempts"),
        ("W/L/U", None),
        ("Technical recoveries", "technical_recoveries"),
        ("Critical counter total", None),
        ("Focus takeovers", None),
        ("Mouse lease duration total (s)", None),
        ("QTE lease duration total (s)", None),
        ("Final lifecycle", "final_lifecycle"),
    ):
        if label == "W/L/U":
            av = f"{a['wins']}/{a['losses']}/{a['unknown']}"
            bv = f"{b['wins']}/{b['losses']}/{b['unknown']}"
        elif label == "Critical counter total":
            av = sum(a["critical_counters"].values())
            bv = sum(b["critical_counters"].values())
        elif label == "Focus takeovers":
            av = a["focus_and_cleanup"]["focus_takeovers"]
            bv = b["focus_and_cleanup"]["focus_takeovers"]
        elif label == "Mouse lease duration total (s)":
            av = a["focus_and_cleanup"]["mouse_duration_seconds"]["total"]
            bv = b["focus_and_cleanup"]["mouse_duration_seconds"]["total"]
        elif label == "QTE lease duration total (s)":
            av = a["focus_and_cleanup"]["qte_duration_seconds"]["total"]
            bv = b["focus_and_cleanup"]["qte_duration_seconds"]["total"]
        else:
            av, bv = a.get(key), b.get(key)
        lines.append(f"| {label} | {av} | {bv} |")
    lines.extend(["", "## Input/ACK by domain", ""])
    domains = sorted(set(a["inputs_by_domain"]) | set(b["inputs_by_domain"]))
    lines.extend(
        [
            "| Domain | A sent/ACK/unconfirmed | B sent/ACK/unconfirmed |",
            "|---|---:|---:|",
        ]
    )
    for domain in domains:
        def value(run: Mapping[str, Any]) -> str:
            row = run["inputs_by_domain"].get(
                domain, {"sent": 0, "acknowledged": 0, "unconfirmed": 0}
            )
            return f"{row['sent']}/{row['acknowledged']}/{row['unconfirmed']}"

        lines.append(f"| {domain} | {value(a)} | {value(b)} |")
    failures = _mapping(analysis.get("acceptance"), "acceptance").get("failures") or []
    lines.extend(["", "## Acceptance failures", ""])
    lines.extend([f"- {failure}" for failure in failures] or ["- None"])
    return "\n".join(lines) + "\n"


__all__ = [
    "ANALYZER_VERSION",
    "ARM_A",
    "ARM_B",
    "ARM_MODES",
    "BenchmarkDataError",
    "CRITICAL_COUNTERS",
    "DATASET_SCHEMA",
    "MANIFEST_SCHEMA",
    "analyze_manifest",
    "assign_run",
    "prepare_manifest",
    "render_markdown_summary",
    "source_fingerprint",
    "write_json",
]
