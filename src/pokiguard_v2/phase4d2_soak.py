"""Offline acceptance analyzer for the Phase 4D.2 reliability soak.

The analyzer consumes immutable FarmRunner artifacts.  It never imports a
controller and never sends game input.  The manifest freezes one source build,
one game build, one gameplay configuration and one pinned-foreground run.
"""

from __future__ import annotations

from collections import Counter
from datetime import datetime, timezone
import json
from pathlib import Path
from typing import Any, Mapping, Sequence

from .phase4d1_benchmark import (
    ARM_B,
    ARM_MODES,
    BenchmarkDataError,
    COMPLETED_RESULTS,
    CRITICAL_COUNTERS,
    _ack_latencies,
    _aggregate_counters,
    _combat_events,
    _event_rows,
    _input_domain_summary,
    _integer,
    _lease_summary,
    _mapping,
    _read_json,
    _read_jsonl,
    _sequence,
    _text,
    _validate_frozen_environment,
    prepare_manifest,
    write_json,
)


MANIFEST_SCHEMA = "pokiguard.phase4d2.manifest.v1"
ANALYSIS_SCHEMA = "pokiguard.phase4d2.analysis.v1"
ANALYZER_VERSION = "2"
SOAK_MODE = ARM_MODES[ARM_B]

SNAPSHOT_SAFETY_COUNTERS = (
    "duplicate_gameplay_input",
    "duplicate_lobby_entry",
    "duplicate_recovery_exit",
    "duplicate_recovery_confirm",
    "duplicate_recovery_reentry",
    "wrong_target",
    "wrong_turn_input",
    "opponent_turn_input",
    "stale_action",
    "stale_session_confusion",
    "postmatch_gameplay_input",
    "lobby_gameplay_input",
    "input_after_farm_stop",
    "duplicate_postmatch_confirm",
    "result_double_count",
    "result_conflict",
)

FORBIDDEN_EVENT_NAMES = frozenset(
    {
        "unexpected_foreground_takeover",
        "foreground_takeover_outside_lease",
        "qte_ownership_conflict",
        "foreground_guard_leak",
        "cursor_restore_failed",
        "topmost_leak",
        "terminal_conflict",
        "orphan_controller",
        "orphan_poller",
        "input_after_stop_ack",
        "unconfirmed_input_retry",
    }
)


def prepare_soak_manifest(
    *,
    workspace: Path,
    app_version: str,
    game_executable: Path,
    game_assembly: Path,
    expected_target: Mapping[str, Any],
    gameplay_config: Mapping[str, Any],
    required_completed_matches: int = 25,
    max_match_attempts: int = 30,
    minimum_focus_takeovers: int = 25,
    minimum_qte_focus_takeovers: int = 5,
) -> dict[str, Any]:
    """Freeze the exact source/game/configuration for one bounded soak."""

    if minimum_focus_takeovers < 0 or minimum_qte_focus_takeovers < 0:
        raise BenchmarkDataError("focus takeover minimums cannot be negative")
    base = prepare_manifest(
        workspace=workspace,
        app_version=app_version,
        game_executable=game_executable,
        game_assembly=game_assembly,
        expected_target=expected_target,
        gameplay_config=gameplay_config,
        required_completed_matches=required_completed_matches,
        max_match_attempts=max_match_attempts,
    )
    return {
        "schema": MANIFEST_SCHEMA,
        "prepared_at": base["prepared_at"],
        "source": base["source"],
        "app_version": base["app_version"],
        "game_build": base["game_build"],
        "expected_target": base["expected_target"],
        "gameplay_config": base["gameplay_config"],
        "accepted_branch": "PINNED_FOREGROUND_EXISTING_INPUT_LEASE",
        "input_delivery_mode": SOAK_MODE,
        "required_completed_matches": required_completed_matches,
        "max_match_attempts": max_match_attempts,
        # Compatibility keys let the existing 4D.1 validators remain reusable.
        "required_completed_matches_per_arm": required_completed_matches,
        "max_match_attempts_per_arm": max_match_attempts,
        "farm_run_id": None,
        "focus_exercise": {
            "minimum_focus_takeovers": minimum_focus_takeovers,
            "minimum_qte_focus_takeovers": minimum_qte_focus_takeovers,
            "plan": (
                "Giữ game hiển thị và được ghim; dùng một cửa sổ khác trong lúc "
                "tool farm. Không minimize, resize hoặc đóng cửa sổ game."
            ),
        },
        "natural_recovery": {
            "required_live_occurrence": False,
            "absent_status": "NOT_OBSERVED",
            "accepted_replay_report": "docs/phase4/phase4c2_report.md",
            "accepted_replay_evidence": "2/2 production re-entry cycle PASS STRONG",
        },
    }


def assign_soak_run(manifest: Mapping[str, Any], farm_run_id: str) -> dict[str, Any]:
    value = json.loads(json.dumps(manifest))
    if value.get("schema") != MANIFEST_SCHEMA:
        raise BenchmarkDataError("unsupported Phase 4D.2 manifest schema")
    value["farm_run_id"] = _text(farm_run_id, "farm_run_id")
    return value


def _attempt_events(
    events: Sequence[Mapping[str, Any]], name: str, attempt_index: int
) -> list[Mapping[str, Any]]:
    return [
        event
        for event in _event_rows(events, name)
        if event.get("attemptIndex") == attempt_index
    ]


def _takeover(event: Mapping[str, Any], *, qte: bool = False) -> bool:
    count = _integer(event.get("focusRequestCount", 0), "focusRequestCount")
    return count > 0 or (not qte and event.get("gameAlreadyForeground") is False)


def _action_matches_match(event: Mapping[str, Any], match_id: str) -> bool:
    identity = str(event.get("action_identity") or event.get("actionIdentity") or "")
    return bool(match_id) and match_id in identity


def _per_match_rows(
    *,
    attempts: Sequence[Any],
    events: Sequence[Mapping[str, Any]],
) -> tuple[list[dict[str, Any]], list[str]]:
    failures: list[str] = []
    rows: list[dict[str, Any]] = []
    mouse_acquired = _event_rows(events, "foreground_lease_acquired")
    qte_acquired = _event_rows(events, "foreground_qte_lease_acquired")
    for raw in attempts:
        attempt = _mapping(raw, "attempt")
        index = _integer(attempt.get("attempt_index"), "attempt.attempt_index")
        result = str(attempt.get("result") or "")
        match_id = str(attempt.get("match_id") or "")
        completed = result in COMPLETED_RESULTS
        controller = _attempt_events(events, "combat_controller_returned", index)
        entries = _attempt_events(events, "match_entry_result", index)
        audits = _attempt_events(events, "postmatch_ui_audit", index)
        returns = _attempt_events(events, "normal_return_boss_lobby", index)
        perfect = 0
        if controller:
            summary = _mapping(controller[-1].get("summary"), "combat_controller_returned.summary")
            counters = _mapping(summary.get("counters"), "combat_controller_returned.counters")
            perfect = _integer(counters.get("pet_skill_perfect", 0), "pet_skill_perfect")
        match_mouse = [event for event in mouse_acquired if _action_matches_match(event, match_id)]
        match_qte = [event for event in qte_acquired if _action_matches_match(event, match_id)]
        row = {
            "attempt_index": index,
            "match_id": match_id or None,
            "result": result or None,
            "completed": completed,
            "normal_postmatch": attempt.get("normal_postmatch"),
            "result_consistency": attempt.get("result_consistency"),
            "terminal_result_confidence": attempt.get("terminal_result_confidence"),
            "local_turns": attempt.get("local_turns", 0),
            "boss_turns": attempt.get("boss_turns", 0),
            "swap_sent": attempt.get("swap_sent", 0),
            "swap_acknowledged": attempt.get("swap_acknowledged", 0),
            "entry_pass": len(entries) == 1
            and _mapping(entries[0].get("entry"), "match_entry_result.entry").get("status")
            == "PASS",
            "postmatch_consistent": len(audits) == 1
            and audits[0].get("consistency") == "CONSISTENT",
            "return_lobby_ready": len(returns) == 1
            and _mapping(returns[0].get("result"), "normal_return_boss_lobby.result").get("ready")
            is True,
            "pet_skill_perfect": perfect,
            "mouse_leases": len(match_mouse),
            "qte_leases": len(match_qte),
            "focus_takeovers": sum(_takeover(event) for event in match_mouse)
            + sum(_takeover(event, qte=True) for event in match_qte),
            "technical_recovery": attempt.get("technical_recovery") is True,
        }
        rows.append(row)
        if not completed:
            continue
        prefix = f"attempt {index}"
        if not match_id:
            failures.append(f"{prefix}: completed result lacks MatchId")
        if row["normal_postmatch"] is not True:
            failures.append(f"{prefix}: completed result lacks normal postmatch proof")
        if row["result_consistency"] != "CONSISTENT":
            failures.append(f"{prefix}: terminal/UI result is not CONSISTENT")
        if row["terminal_result_confidence"] != "STRONG":
            failures.append(f"{prefix}: terminal result confidence is not STRONG")
        if not row["entry_pass"]:
            failures.append(f"{prefix}: exact entry/opening PASS is missing")
        if not row["postmatch_consistent"]:
            failures.append(f"{prefix}: postmatch UI audit is missing or inconsistent")
        if not row["return_lobby_ready"]:
            failures.append(f"{prefix}: normal return to boss lobby is missing")
        if perfect < 1 or len(match_qte) < 1:
            failures.append(f"{prefix}: Pet Skill PERFECT/QTE lease proof is missing")
        if _integer(attempt.get("swap_sent", 0), "attempt.swap_sent") != _integer(
            attempt.get("swap_acknowledged", 0), "attempt.swap_acknowledged"
        ):
            failures.append(f"{prefix}: swap sent/ACK counts differ")
        for name in (
            "swap_rejected",
            "swap_aborted_state_changed",
            "cast_rejected",
            "evolve_failed",
            "sequence_desync",
        ):
            if _integer(attempt.get(name, 0), f"attempt.{name}"):
                failures.append(f"{prefix}: {name} is non-zero")
    return rows, failures


def _snapshot_safety(snapshot: Mapping[str, Any]) -> tuple[dict[str, int], list[str]]:
    safety = _mapping(snapshot.get("safety"), "snapshot.safety")
    values = {
        name: _integer(safety.get(name, 0), f"snapshot.safety.{name}")
        for name in SNAPSHOT_SAFETY_COUNTERS
    }
    failures = [
        f"snapshot safety counter {name} is non-zero"
        for name, value in values.items()
        if value
    ]
    return values, failures


def _binding_and_pin_summary(
    events: Sequence[Mapping[str, Any]],
) -> tuple[dict[str, Any], list[str]]:
    failures: list[str] = []
    starts = _event_rows(events, "pinned_input_session_started")
    executors = _event_rows(events, "pinned_input_executor_bound")
    pins = _event_rows(events, "foreground_lease_pin")
    unpins = _event_rows(events, "foreground_lease_unpin")
    hwnd: int | None = None
    pid: int | None = None
    title: str | None = None
    geometry: dict[str, Any] | None = None
    if len(starts) != 1:
        failures.append("exact pinned session binding is missing or duplicated")
    else:
        binding = _mapping(starts[0].get("exactBinding"), "pinned exactBinding")
        window = _mapping(binding.get("window"), "pinned exactBinding.window")
        raw_geometry = _mapping(binding.get("geometry"), "pinned exactBinding.geometry")
        hwnd = _integer(window.get("hwnd"), "pinned hwnd")
        pid = _integer(window.get("pid"), "pinned pid")
        title = _text(window.get("title"), "pinned title")
        geometry = dict(raw_geometry)
        if hwnd <= 0 or pid <= 0:
            failures.append("pinned HWND/PID is not positive")
        if _integer(raw_geometry.get("width"), "pinned width") <= 0 or _integer(
            raw_geometry.get("height"), "pinned height"
        ) <= 0:
            failures.append("pinned client geometry is invalid")
    if len(executors) != 1 or executors[0].get("backend") != "NativeForegroundLeaseBackend":
        failures.append("pinned native executor binding is missing or inconsistent")
    if len(pins) != 1 or pins[0].get("status") != "PINNED":
        failures.append("topmost pin proof is missing or inconsistent")
    if len(unpins) != 1 or unpins[0].get("status") != "UNPINNED":
        failures.append("topmost unpin proof is missing or inconsistent")
    if hwnd is not None:
        for event in _event_rows(events, "foreground_lease_acquired"):
            if event.get("foregroundGame") != hwnd:
                failures.append("mouse lease acquired a HWND different from exact binding")
                break
        for event in _event_rows(events, "foreground_lease_finished"):
            if event.get("foreground_after_acquire") != hwnd or event.get(
                "foreground_after_action"
            ) != hwnd:
                failures.append("mouse lease action ran outside the exact bound HWND")
                break
        for event in _event_rows(events, "foreground_qte_lease_acquired"):
            if event.get("foreground_after") != hwnd:
                failures.append("QTE lease acquired a HWND different from exact binding")
                break
    return (
        {
            "hwnd": hwnd,
            "pid": pid,
            "title": title,
            "geometry": geometry,
            "executor_backend": executors[0].get("backend") if len(executors) == 1 else None,
            "pin_count": len(pins),
            "unpin_count": len(unpins),
        },
        failures,
    )


def _recovery_coverage(
    snapshot: Mapping[str, Any], events: Sequence[Mapping[str, Any]], manifest: Mapping[str, Any]
) -> dict[str, Any]:
    map_rows = [
        event
        for event in _event_rows(events, "chinh_phuc_map_return")
        if _mapping(event.get("result"), "chinh_phuc_map_return.result").get("ready") is True
    ]
    technical = _integer(snapshot.get("technical_recoveries", 0), "technical_recoveries")
    observed = len(map_rows) + technical > 0
    replay = _mapping(manifest.get("natural_recovery"), "manifest.natural_recovery")
    return {
        "status": "OBSERVED" if observed else str(replay.get("absent_status") or "NOT_OBSERVED"),
        "navigation_reentries": len(map_rows),
        "technical_recoveries": technical,
        "accepted_replay_report": replay.get("accepted_replay_report"),
        "accepted_replay_evidence": replay.get("accepted_replay_evidence"),
    }


def _expiration_accounting(
    reported_expired_actions: int,
    combat_events: Sequence[Mapping[str, Any]],
) -> dict[str, int]:
    """Separate safe pre-input replans from expired physical actions.

    The controller increments ``expired_actions`` when its mandatory fresh
    reread selects a different policy decision.  That is an intentional
    zero-input cancellation, not a stale or partial input.  Phase 4D.2 accepts
    only the exact audited form and leaves every unmatched expiration critical.
    """

    safe_preinput_replans = sum(
        1
        for event in combat_events
        if event.get("event") == "action_result"
        and event.get("result") == "ACTION_ABORTED_STATE_CHANGED"
        and event.get("reason") == "POLICY_CHANGED_ON_FRESH_REREAD"
        and event.get("inputSent") is not True
        and _mapping(event.get("identity"), "expired action identity").get("action")
        == "swap"
    )
    accounted = min(reported_expired_actions, safe_preinput_replans)
    return {
        "reported_expired_actions": reported_expired_actions,
        "safe_preinput_replans": safe_preinput_replans,
        "accounted_safe_preinput_replans": accounted,
        "unaccounted_expired_actions": max(0, reported_expired_actions - accounted),
    }


def analyze_soak_manifest(
    manifest_path: Path, logs_root: Path, *, workspace: Path | None = None
) -> dict[str, Any]:
    manifest = _read_json(manifest_path)
    if manifest.get("schema") != MANIFEST_SCHEMA:
        raise BenchmarkDataError("unsupported Phase 4D.2 manifest schema")
    if manifest.get("input_delivery_mode") != SOAK_MODE:
        raise BenchmarkDataError("manifest does not select pinned foreground Beta")
    run_id = _text(manifest.get("farm_run_id"), "manifest.farm_run_id")
    run_directory = logs_root / run_id
    raw = _read_json(run_directory / "run.json")
    checkpoint = _read_json(run_directory / "checkpoint.json")
    events = _read_jsonl(run_directory / "events.jsonl")
    if raw.get("schema") != "pokiguard.farm_run.v2":
        raise BenchmarkDataError("unsupported FarmRunner artifact schema")
    snapshot = _mapping(raw.get("snapshot"), "run.snapshot")
    if snapshot.get("farm_run_id") != run_id:
        raise BenchmarkDataError("FarmRunId does not match artifact directory")

    environment, failures = _validate_frozen_environment(manifest, workspace)
    if snapshot.get("input_delivery_mode") != SOAK_MODE:
        failures.append("snapshot input delivery mode differs from manifest")
    if checkpoint.get("input_delivery_mode") != SOAK_MODE:
        failures.append("checkpoint input delivery mode differs from manifest")
    starts = _event_rows(events, "farm_run_started")
    if len(starts) != 1 or starts[0].get("inputDeliveryMode") != SOAK_MODE:
        failures.append("farm_run_started mode is missing or inconsistent")
    expected_target = dict(_mapping(manifest.get("expected_target"), "manifest.expected_target"))
    expected_config = dict(_mapping(manifest.get("gameplay_config"), "manifest.gameplay_config"))
    if dict(_mapping(snapshot.get("target"), "snapshot.target")) != expected_target:
        failures.append("boss target differs from manifest")
    if dict(_mapping(snapshot.get("gameplay_config"), "snapshot.gameplay_config")) != expected_config:
        failures.append("gameplay configuration differs from manifest")
    if dict(_mapping(checkpoint.get("gameplay_config"), "checkpoint.gameplay_config")) != expected_config:
        failures.append("checkpoint gameplay configuration differs from manifest")

    required = _integer(manifest.get("required_completed_matches"), "required_completed_matches")
    maximum = _integer(manifest.get("max_match_attempts"), "max_match_attempts")
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
    if attempts > maximum:
        failures.append(f"attempts {attempts} exceed maximum {maximum}")
    if wins + losses + unknown != completed:
        failures.append("W/L/U accounting differs from completed matches")
    if unknown:
        failures.append("unexplained UNKNOWN match result observed")
    completed_positions = [
        offset
        for offset, row in enumerate(attempt_rows)
        if _mapping(row, "attempt").get("result") in COMPLETED_RESULTS
    ]
    if len(completed_positions) != completed:
        failures.append("completed attempt rows differ from completed_matches")
    if completed_positions and completed_positions[-1] != len(attempt_rows) - 1:
        failures.append("extra attempt exists after the target completed match")
    indices = [_integer(_mapping(row, "attempt").get("attempt_index"), "attempt_index") for row in attempt_rows]
    if indices != list(range(1, len(indices) + 1)):
        failures.append("attempt indices are not unique and sequential")
    limits = _mapping(snapshot.get("limits"), "snapshot.limits")
    if limits.get("target_completed_matches") != required:
        failures.append("configured target differs from manifest")
    if limits.get("max_match_attempts") != maximum:
        failures.append("configured maximum attempts differs from manifest")

    for condition, reason in (
        (snapshot.get("state") == "FARM_RUN_COMPLETE", "final FarmRunner state is not FARM_RUN_COMPLETE"),
        (snapshot.get("stop_reason") == "FARM_TARGET_COMPLETED", "FarmRunner stop reason is not FARM_TARGET_COMPLETED"),
        (checkpoint.get("finalized_status") == "COMPLETED", "checkpoint is not finalized COMPLETED"),
        (checkpoint.get("stop_reason") == "FARM_TARGET_COMPLETED", "checkpoint stop reason is not FARM_TARGET_COMPLETED"),
        (checkpoint.get("last_safe_lifecycle") == "BOSS_LOBBY", "checkpoint did not finish at BOSS_LOBBY"),
        (raw.get("finalLifecycle") == "BOSS_LOBBY", "run artifact did not finish at BOSS_LOBBY"),
        (raw.get("unexpectedError") is None, "run artifact contains unexpectedError"),
    ):
        if not condition:
            failures.append(reason)
    for key in ("memoryWrites", "directGameCalls", "networkManipulation"):
        if raw.get(key) is not False:
            failures.append(f"run safety flag {key} is not false")

    counters = _aggregate_counters(events)
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
    combat_events = _combat_events(run_directory, attempt_rows)
    expiration_accounting = _expiration_accounting(
        counters["expired_actions"], combat_events
    )
    effective_critical = {
        name: (
            expiration_accounting["unaccounted_expired_actions"]
            if name == "expired_actions"
            else counters[name]
        )
        for name in CRITICAL_COUNTERS
    }
    nonzero_critical = {
        name: value for name, value in effective_critical.items() if value
    }
    if nonzero_critical:
        failures.append("critical combat counter is non-zero")
    safety, safety_failures = _snapshot_safety(snapshot)
    failures.extend(safety_failures)
    domains = _input_domain_summary(snapshot, events, counters)
    if any(row["unconfirmed"] for row in domains.values()):
        failures.append("sent input lacks authoritative ACK")

    lease, lease_failures = _lease_summary(events, ARM_B)
    failures.extend(lease_failures)
    binding, binding_failures = _binding_and_pin_summary(events)
    failures.extend(binding_failures)
    qte_takeovers = sum(
        _takeover(event, qte=True)
        for event in _event_rows(events, "foreground_qte_lease_acquired")
    )
    exercise = _mapping(manifest.get("focus_exercise"), "manifest.focus_exercise")
    minimum_all = _integer(exercise.get("minimum_focus_takeovers"), "minimum_focus_takeovers")
    minimum_qte = _integer(
        exercise.get("minimum_qte_focus_takeovers"), "minimum_qte_focus_takeovers"
    )
    if lease["focus_takeovers"] < minimum_all:
        failures.append("focus takeover exercise minimum was not reached")
    if qte_takeovers < minimum_qte:
        failures.append("QTE focus takeover exercise minimum was not reached")
    forbidden = Counter(
        str(event.get("event")) for event in events if event.get("event") in FORBIDDEN_EVENT_NAMES
    )
    if forbidden:
        failures.append("forbidden focus/input/terminal event was emitted")

    emergency = _mapping(raw.get("emergencyControl"), "run.emergencyControl")
    after_ack = _integer(
        emergency.get("authorizedInputOperationsAfterAcknowledgement", 0),
        "authorizedInputOperationsAfterAcknowledgement",
    )
    if after_ack:
        failures.append("authorized input occurred after emergency stop acknowledgement")
    if raw.get("finalInvariant") != "PHASE2E2_UI_BOUNDED_COMPLETED":
        failures.append("final invariant is not the bounded completed state")
    memory = _mapping(raw.get("controllerMemory"), "run.controllerMemory")
    if (
        memory.get("available") is not True
        or "unbounded" in str(memory.get("interpretation") or "").lower()
        and "no observed" not in str(memory.get("interpretation") or "").lower()
    ):
        failures.append("controller memory evidence is unavailable or indicates unbounded growth")

    per_match, match_failures = _per_match_rows(attempts=attempt_rows, events=events)
    failures.extend(match_failures)
    recovery = _recovery_coverage(snapshot, events, manifest)
    pass_strong = not failures
    return {
        "schema": ANALYSIS_SCHEMA,
        "analyzer_version": ANALYZER_VERSION,
        "analyzed_at": datetime.now(timezone.utc).isoformat(timespec="milliseconds").replace(
            "+00:00", "Z"
        ),
        "manifest": str(manifest_path.resolve()),
        "farm_run_id": run_id,
        "source": dict(_mapping(manifest.get("source"), "manifest.source")),
        "app_version": manifest.get("app_version"),
        "game_build": dict(_mapping(manifest.get("game_build"), "manifest.game_build")),
        "expected_target": expected_target,
        "gameplay_config": expected_config,
        "input_delivery_mode": SOAK_MODE,
        "required_completed_matches": required,
        "max_match_attempts": maximum,
        "environment_validation": environment,
        "run": {
            "completed": completed,
            "attempts": attempts,
            "wins": wins,
            "losses": losses,
            "unknown": unknown,
            "technical_aborts": snapshot.get("technical_aborts", 0),
            "technical_recoveries": snapshot.get("technical_recoveries", 0),
            "technical_exits": snapshot.get("technical_exits", 0),
            "safe_stops": snapshot.get("safe_stops", 0),
            "final_lifecycle": raw.get("finalLifecycle"),
            "stop_reason": snapshot.get("stop_reason"),
            "checkpoint_finalized_status": checkpoint.get("finalized_status"),
            "emergency_input_after_ack": after_ack,
        },
        "per_match": per_match,
        "inputs_by_domain": domains,
        "ack_latency_seconds": _ack_latencies(snapshot, events, combat_events),
        "critical_counters": {name: counters[name] for name in CRITICAL_COUNTERS},
        "effective_critical_counters": effective_critical,
        "expiration_accounting": expiration_accounting,
        "snapshot_safety_counters": safety,
        "forbidden_event_counts": dict(forbidden),
        "focus_and_cleanup": {
            **lease,
            "qte_focus_takeovers": qte_takeovers,
            "exact_binding": binding,
        },
        "recovery_coverage": recovery,
        "acceptance": {
            "result": "PASS_STRONG" if pass_strong else "FAIL",
            "pass_strong": pass_strong,
            "failures": failures,
        },
    }


def render_markdown_summary(analysis: Mapping[str, Any]) -> str:
    acceptance = _mapping(analysis.get("acceptance"), "analysis.acceptance")
    run = _mapping(analysis.get("run"), "analysis.run")
    focus = _mapping(analysis.get("focus_and_cleanup"), "analysis.focus_and_cleanup")
    recovery = _mapping(analysis.get("recovery_coverage"), "analysis.recovery_coverage")
    lines = [
        "# Phase 4D.2 — Pinned Foreground Reliability Soak",
        "",
        f"Result: **{acceptance.get('result')}**",
        "",
        f"- FarmRunId: `{analysis.get('farm_run_id')}`",
        f"- Mode: `{analysis.get('input_delivery_mode')}`",
        f"- Completed/attempts: `{run.get('completed')}/{run.get('attempts')}`",
        f"- W/L/U: `{run.get('wins')}/{run.get('losses')}/{run.get('unknown')}`",
        f"- Final: `{run.get('stop_reason')}` / `{run.get('final_lifecycle')}`",
        f"- Focus takeovers: `{focus.get('focus_takeovers')}`; QTE: `{focus.get('qte_focus_takeovers')}`",
        f"- Natural recovery: `{recovery.get('status')}`; map re-entry `{recovery.get('navigation_reentries')}`; technical `{recovery.get('technical_recoveries')}`",
        "",
        "## Per-match evidence",
        "",
        "| # | Result | Turns local/boss | Swap sent/ACK | Skill PERFECT | Mouse/QTE lease | Focus takeover |",
        "|---:|---|---:|---:|---:|---:|---:|",
    ]
    for raw in _sequence(analysis.get("per_match"), "analysis.per_match"):
        row = _mapping(raw, "per_match")
        lines.append(
            f"| {row.get('attempt_index')} | {row.get('result')} | "
            f"{row.get('local_turns')}/{row.get('boss_turns')} | "
            f"{row.get('swap_sent')}/{row.get('swap_acknowledged')} | "
            f"{row.get('pet_skill_perfect')} | {row.get('mouse_leases')}/{row.get('qte_leases')} | "
            f"{row.get('focus_takeovers')} |"
        )
    lines.extend(["", "## Input/ACK by domain", "", "| Domain | Sent | ACK | Unconfirmed |", "|---|---:|---:|---:|"])
    for domain, raw in sorted(_mapping(analysis.get("inputs_by_domain"), "inputs_by_domain").items()):
        row = _mapping(raw, f"inputs_by_domain.{domain}")
        lines.append(
            f"| {domain} | {row.get('sent')} | {row.get('acknowledged')} | {row.get('unconfirmed')} |"
        )
    failures = acceptance.get("failures") or []
    lines.extend(["", "## Acceptance failures", ""])
    lines.extend([f"- {failure}" for failure in failures] or ["- None"])
    return "\n".join(lines) + "\n"


__all__ = [
    "ANALYSIS_SCHEMA",
    "ANALYZER_VERSION",
    "FORBIDDEN_EVENT_NAMES",
    "MANIFEST_SCHEMA",
    "SNAPSHOT_SAFETY_COUNTERS",
    "SOAK_MODE",
    "analyze_soak_manifest",
    "assign_soak_run",
    "prepare_soak_manifest",
    "render_markdown_summary",
    "write_json",
]
