"""Deterministic, offline Phase 3D.1 benchmark analysis.

The analyzer reads immutable FarmRunner artifacts and never imports or invokes
the gameplay controller.  Its only optional write is the caller-selected compact
JSON/Markdown output path.
"""

from __future__ import annotations

from datetime import datetime
import json
import math
from pathlib import Path
from statistics import median, pstdev
from typing import Any, Iterable, Mapping, Sequence


MANIFEST_SCHEMA = "pokiguard.phase3d1.manifest.v2"
DATASET_SCHEMA = "pokiguard.phase3d1.dataset.v2"
ANALYZER_VERSION = "2"
MODE_A = "A_DEFAULT"
MODE_B = "B_PET_SKILL"
MODES = (MODE_A, MODE_B)
COMPLETED_RESULTS = frozenset({"WIN", "LOSS", "UNKNOWN"})
ALL_RESULTS = COMPLETED_RESULTS | {"TECHNICAL_ABORT", "SAFE_STOP"}
SKILL_RUSH_HP_PREP_RATIO = 0.50
SKILL_RUSH_VERY_LOW_HP_RATIO = 0.30
SKILL_RUSH_SWORD_DENSITY_MINIMUM = 8
POST_SKILL_FINISHER_HP = 30_000
POST_SKILL_FINISHER_RATIO = 0.20
SKILL_FIRE_REASONS = (
    "HP_PREP",
    "SWORD_DENSITY",
    "BOTH",
    "VERY_LOW_HP",
    "SETUP_BLOCKED",
)

EXPECTED_PROFILES: dict[str, dict[str, str]] = {
    MODE_A: {
        "play_style": "simple",
        "main_pet": "normal",
        "evolution": "normal",
        "damage_card": "default_attack",
        "intelligence": "basic",
    },
    MODE_B: {
        "play_style": "skill_rush",
        "main_pet": "legendary",
        "evolution": "none",
        "damage_card": "pet_skill",
        "intelligence": "basic",
    },
}


class BenchmarkDataError(ValueError):
    """Raised when included benchmark evidence is corrupt or incomplete."""


def _mapping(value: Any, label: str) -> Mapping[str, Any]:
    if not isinstance(value, Mapping):
        raise BenchmarkDataError(f"{label} must be an object")
    return value


def _sequence(value: Any, label: str) -> Sequence[Any]:
    if not isinstance(value, list):
        raise BenchmarkDataError(f"{label} must be an array")
    return value


def _required_text(source: Mapping[str, Any], key: str, label: str) -> str:
    value = source.get(key)
    if not isinstance(value, str) or not value.strip():
        raise BenchmarkDataError(f"{label}.{key} must be a non-empty string")
    return value.strip()


def _nonnegative_int(value: Any, label: str) -> int:
    if isinstance(value, bool) or not isinstance(value, int) or value < 0:
        raise BenchmarkDataError(f"{label} must be a non-negative integer")
    return value


def _optional_nonnegative_number(value: Any, label: str) -> float | None:
    if value is None:
        return None
    if isinstance(value, bool) or not isinstance(value, (int, float)):
        raise BenchmarkDataError(f"{label} must be numeric or null")
    number = float(value)
    if not math.isfinite(number) or number < 0:
        raise BenchmarkDataError(f"{label} must be finite and non-negative")
    return number


def parse_timestamp(value: Any, label: str = "timestamp") -> datetime:
    if not isinstance(value, str) or not value.strip():
        raise BenchmarkDataError(f"{label} must be a non-empty ISO timestamp")
    try:
        parsed = datetime.fromisoformat(value.replace("Z", "+00:00"))
    except ValueError as exc:
        raise BenchmarkDataError(f"{label} is invalid: {value!r}") from exc
    if parsed.tzinfo is None:
        raise BenchmarkDataError(f"{label} must include a timezone")
    return parsed


def duration_seconds(start: Any, end: Any) -> float:
    value = (parse_timestamp(end, "end") - parse_timestamp(start, "start")).total_seconds()
    if value < 0:
        raise BenchmarkDataError("duration end precedes start")
    return round(value, 3)


def numeric_stats(values: Iterable[int | float]) -> dict[str, int | float | None]:
    numbers = [float(value) for value in values]
    if not numbers:
        return {
            "n": 0,
            "mean": None,
            "median": None,
            "min": None,
            "max": None,
            "stddev": None,
            "total": 0.0,
        }
    if any(not math.isfinite(value) for value in numbers):
        raise BenchmarkDataError("statistics contain a non-finite value")
    return {
        "n": len(numbers),
        "mean": round(sum(numbers) / len(numbers), 3),
        "median": round(float(median(numbers)), 3),
        "min": round(min(numbers), 3),
        "max": round(max(numbers), 3),
        "stddev": round(float(pstdev(numbers)), 3),
        "total": round(sum(numbers), 3),
    }


def relative_reduction(a_value: int | float | None, b_value: int | float | None) -> dict[str, float | None]:
    """Return A-B; a positive percentage means B used less or was faster."""

    if a_value is None or b_value is None:
        return {"difference_a_minus_b": None, "reduction_pct": None}
    a_number = float(a_value)
    b_number = float(b_value)
    if not math.isfinite(a_number) or not math.isfinite(b_number):
        raise BenchmarkDataError("relative comparison contains a non-finite value")
    difference = round(a_number - b_number, 3)
    percentage = None if a_number == 0 else round(difference / a_number * 100.0, 3)
    return {"difference_a_minus_b": difference, "reduction_pct": percentage}


def classify_skill_fire_reason(
    *,
    current_mana: int,
    current_rage: int,
    required_mana: int,
    required_rage: int,
    boss_hp_ratio: float,
    known_sword_count: int,
    setup_blocked: bool = False,
) -> str | None:
    """Recompute the accepted v1.0.48 fire reason from recorded state.

    Phase 3C.3 was explicitly finalized at eight known Sword.  This helper
    mirrors that accepted repository state; it does not use the superseded
    eleven-Sword threshold found in older benchmark prose.
    """

    values = (
        current_mana,
        current_rage,
        required_mana,
        required_rage,
        known_sword_count,
    )
    if any(isinstance(value, bool) or not isinstance(value, int) or value < 0 for value in values):
        raise BenchmarkDataError("skill-fire resources/counts must be non-negative integers")
    if isinstance(boss_hp_ratio, bool) or not isinstance(boss_hp_ratio, (int, float)):
        raise BenchmarkDataError("skill-fire boss ratio must be numeric")
    ratio = float(boss_hp_ratio)
    if not math.isfinite(ratio) or not 0.0 <= ratio <= 1.0:
        raise BenchmarkDataError("skill-fire boss ratio must be in [0, 1]")
    if current_mana < required_mana or current_rage < required_rage:
        return None
    if ratio <= SKILL_RUSH_VERY_LOW_HP_RATIO:
        return "VERY_LOW_HP"
    hp_ready = ratio < SKILL_RUSH_HP_PREP_RATIO
    sword_ready = known_sword_count >= SKILL_RUSH_SWORD_DENSITY_MINIMUM
    if hp_ready and sword_ready:
        return "BOTH"
    if hp_ready:
        return "HP_PREP"
    if sword_ready:
        return "SWORD_DENSITY"
    if setup_blocked:
        return "SETUP_BLOCKED"
    return None


def classify_post_skill_finisher_trigger(
    boss_hp: int,
    boss_max_hp: int,
) -> str:
    if any(
        isinstance(value, bool) or not isinstance(value, int) or value < 0
        for value in (boss_hp, boss_max_hp)
    ) or boss_max_hp <= 0:
        raise BenchmarkDataError("finisher HP values must be non-negative with max HP > 0")
    absolute = boss_hp < POST_SKILL_FINISHER_HP
    relative = boss_hp / boss_max_hp < POST_SKILL_FINISHER_RATIO
    if absolute and relative:
        return "BOTH"
    if absolute:
        return "ABSOLUTE_HP"
    if relative:
        return "RELATIVE_HP"
    return "NONE"


def mode_b_attack_is_valid_finisher(
    *,
    successful_skill_count: int,
    boss_hp: int,
    boss_max_hp: int,
    action_turn: int,
    latest_skill_source_turn: int | None,
    recorded_trigger: str | None,
) -> bool:
    if successful_skill_count <= 0 or latest_skill_source_turn is None:
        return False
    if action_turn <= latest_skill_source_turn:
        return False
    trigger = classify_post_skill_finisher_trigger(boss_hp, boss_max_hp)
    return trigger != "NONE" and recorded_trigger == trigger


def _read_json(path: Path) -> Mapping[str, Any]:
    try:
        value = json.loads(path.read_text(encoding="utf-8"))
    except (OSError, json.JSONDecodeError) as exc:
        raise BenchmarkDataError(f"cannot read valid JSON from {path}: {exc}") from exc
    return _mapping(value, str(path))


def _read_jsonl(path: Path) -> list[Mapping[str, Any]]:
    try:
        lines = path.read_text(encoding="utf-8").splitlines()
    except OSError as exc:
        raise BenchmarkDataError(f"cannot read {path}: {exc}") from exc
    records: list[Mapping[str, Any]] = []
    for line_number, line in enumerate(lines, 1):
        if not line.strip():
            continue
        try:
            value = json.loads(line)
        except json.JSONDecodeError as exc:
            raise BenchmarkDataError(f"corrupt JSONL at {path}:{line_number}: {exc}") from exc
        records.append(_mapping(value, f"{path}:{line_number}"))
    return records


def _counter(counters: Mapping[str, Any], key: str, label: str) -> int:
    return _nonnegative_int(counters.get(key), f"{label}.{key}")


def _attempt_event(
    events: Sequence[Mapping[str, Any]], event_name: str, attempt_index: int
) -> Mapping[str, Any] | None:
    matches = [
        event
        for event in events
        if event.get("event") == event_name and event.get("attemptIndex") == attempt_index
    ]
    if len(matches) > 1:
        raise BenchmarkDataError(
            f"attempt {attempt_index} has duplicate {event_name} events"
        )
    return matches[0] if matches else None


def _safe_lobby_event(event: Mapping[str, Any]) -> bool:
    if event.get("event") not in {"initial_boss_lobby", "normal_return_boss_lobby"}:
        return False
    result = event.get("result")
    return isinstance(result, Mapping) and result.get("ready") is True


def _cycle_duration(
    events: Sequence[Mapping[str, Any]], attempt_index: int, combat_start: str
) -> float | None:
    end_event = _attempt_event(events, "normal_return_boss_lobby", attempt_index)
    if end_event is None or not _safe_lobby_event(end_event):
        return None
    start_time = parse_timestamp(combat_start, "attempt.start_timestamp")
    candidates = [
        event
        for event in events
        if _safe_lobby_event(event)
        and parse_timestamp(event.get("timestamp"), "safe lobby timestamp") <= start_time
    ]
    if not candidates:
        return None
    start_event = max(
        candidates,
        key=lambda event: parse_timestamp(event.get("timestamp"), "safe lobby timestamp"),
    )
    return duration_seconds(start_event.get("timestamp"), end_event.get("timestamp"))


def _pet_skill_metrics(records: Sequence[Mapping[str, Any]]) -> dict[str, int]:
    dispatches = [record for record in records if record.get("event") == "pet_skill_dispatch_result"]
    totals = {
        "dispatch_results": len(dispatches),
        "accepted": 0,
        "perfect": 0,
        "good": 0,
        "bad": 0,
        "directions_sent": 0,
        "directions_confirmed": 0,
        "wrong_directions": 0,
        "skipped_directions": 0,
        "duplicate_directions": 0,
        "stale_directions": 0,
        "unconfirmed_directions": 0,
        "blind_retries": 0,
        "space_count": 0,
        "duplicate_space": 0,
        "outside_window_space": 0,
    }
    for index, record in enumerate(dispatches, 1):
        result = _mapping(record.get("result") or record.get("summary"), f"pet dispatch {index}")
        card_clicks = _nonnegative_int(result.get("card_clicks"), f"pet dispatch {index}.card_clicks")
        space_presses = _nonnegative_int(result.get("space_presses"), f"pet dispatch {index}.space_presses")
        totals["space_count"] += space_presses
        totals["duplicate_space"] += max(0, space_presses - 1)
        telemetry = _mapping(result.get("telemetry"), f"pet dispatch {index}.telemetry")
        direction = telemetry.get("direction_summary")
        if direction is not None:
            direction_map = _mapping(direction, f"pet dispatch {index}.direction_summary")
            for key in (
                "directions_sent",
                "directions_confirmed",
                "wrong_directions",
                "skipped_directions",
                "duplicate_directions",
                "stale_directions",
                "unconfirmed_directions",
                "blind_retries",
            ):
                totals[key] += _counter(direction_map, key, f"pet dispatch {index}.direction_summary")
        runtime_result = telemetry.get("runtime_result")
        kind = result.get("kind")
        quality = runtime_result if runtime_result in {"PERFECT", "GOOD", "BAD"} else None
        if card_clicks == 1 and space_presses == 1 and quality is not None:
            totals[str(quality).lower()] += 1
        accepted = result.get("state") == "COMPLETE" and card_clicks == 1 and space_presses == 1
        if accepted:
            totals["accepted"] += 1
            accepted_quality = quality or (
                "PERFECT" if kind == "SUCCESS_PERFECT" else None
            )
            if accepted_quality not in {"PERFECT", "GOOD", "BAD"}:
                raise BenchmarkDataError(
                    f"accepted pet dispatch {index} lacks authoritative QTE quality"
                )
            if quality is None:
                totals[str(accepted_quality).lower()] += 1
        if space_presses:
            elapsed = _optional_nonnegative_number(
                telemetry.get("space_send_elapsed"),
                f"pet dispatch {index}.space_send_elapsed",
            )
            perfect_start = _optional_nonnegative_number(
                telemetry.get("perfect_start"), f"pet dispatch {index}.perfect_start"
            )
            perfect_end = _optional_nonnegative_number(
                telemetry.get("perfect_end"), f"pet dispatch {index}.perfect_end"
            )
            outside = (
                elapsed is None
                or perfect_start is None
                or perfect_end is None
                or not perfect_start <= elapsed <= perfect_end
            )
            totals["outside_window_space"] += int(outside)
    return totals


def _combat_summary(records: Sequence[Mapping[str, Any]], label: str) -> Mapping[str, Any]:
    summaries = [record for record in records if record.get("event") == "auto_controller_summary"]
    if len(summaries) != 1:
        raise BenchmarkDataError(f"{label} must contain exactly one auto_controller_summary")
    return summaries[0]


def _policy_audit(records: Sequence[Mapping[str, Any]]) -> dict[str, int]:
    direct_inconsistencies = 0
    indirect_inconsistencies = 0
    for record in records:
        if record.get("event") != "policy_decision" or record.get("selectedAction") != "swap":
            continue
        if record.get("safe") is True:
            direct_inconsistencies += int((record.get("opponentSwordReplies") or 0) > 0)
            indirect_inconsistencies += int((record.get("indirectSwordReplies") or 0) > 0)
    return {
        "safe_swap_with_direct_sword_reply": direct_inconsistencies,
        "safe_swap_with_indirect_sword_reply": indirect_inconsistencies,
    }


def _skill_rush_metrics(
    records: Sequence[Mapping[str, Any]],
    summary: Mapping[str, Any],
    pet: Mapping[str, int],
    label: str,
) -> dict[str, Any]:
    decisions: list[Mapping[str, Any]] = []
    fire_records: list[dict[str, Any]] = []
    for index, record in enumerate(records, 1):
        if record.get("event") != "policy_decision":
            continue
        trace = _mapping(record.get("trace"), f"{label}.policy_decision[{index}].trace")
        decisions.append(trace)
        if trace.get("selected_action") != "pet_skill":
            continue
        current_mana = _nonnegative_int(
            trace.get("current_mana"), f"{label}.skill_fire.current_mana"
        )
        current_rage = _nonnegative_int(
            trace.get("current_rage"), f"{label}.skill_fire.current_rage"
        )
        required_mana = _nonnegative_int(
            trace.get("required_mana"), f"{label}.skill_fire.required_mana"
        )
        required_rage = _nonnegative_int(
            trace.get("required_rage"), f"{label}.skill_fire.required_rage"
        )
        known_sword = _nonnegative_int(
            trace.get("known_sword_count"), f"{label}.skill_fire.known_sword_count"
        )
        boss_hp = _nonnegative_int(trace.get("boss_hp"), f"{label}.skill_fire.boss_hp")
        boss_max_hp = _nonnegative_int(
            trace.get("boss_max_hp"), f"{label}.skill_fire.boss_max_hp"
        )
        ratio = _optional_nonnegative_number(
            trace.get("boss_hp_ratio"), f"{label}.skill_fire.boss_hp_ratio"
        )
        if ratio is None or ratio > 1.0 or boss_max_hp <= 0:
            raise BenchmarkDataError(f"{label} skill fire lacks valid boss HP/ratio")
        recorded = trace.get("skill_fire_trigger")
        if recorded not in SKILL_FIRE_REASONS:
            raise BenchmarkDataError(f"{label} has unsupported skill-fire reason {recorded!r}")
        setup_blocked_proven = False
        if recorded == "SETUP_BLOCKED":
            raw_failures = trace.get("failed_higher_priority_branches")
            failures = raw_failures if isinstance(raw_failures, list) else []
            setup_blocked_proven = any(
                isinstance(item, str)
                and "no legal direct clear is at least two orthogonal cells" in item
                for item in failures
            )
            why_selected = trace.get("why_selected")
            setup_blocked_proven = setup_blocked_proven and (
                isinstance(why_selected, str)
                and "no legal direct setup clear" in why_selected
                and "distance-two isolated" in why_selected
            )
            if not setup_blocked_proven:
                raise BenchmarkDataError(
                    f"{label} SETUP_BLOCKED fire lacks deterministic setup-block proof"
                )
        expected = classify_skill_fire_reason(
            current_mana=current_mana,
            current_rage=current_rage,
            required_mana=required_mana,
            required_rage=required_rage,
            boss_hp_ratio=ratio,
            known_sword_count=known_sword,
            setup_blocked=setup_blocked_proven,
        )
        fire_records.append(
            {
                "turn": _nonnegative_int(
                    trace.get("turn_number"), f"{label}.skill_fire.turn_number"
                ),
                "boss_hp": boss_hp,
                "boss_max_hp": boss_max_hp,
                "boss_hp_ratio": round(ratio, 6),
                "known_sword_count": known_sword,
                "current_mana": current_mana,
                "current_rage": current_rage,
                "required_mana": required_mana,
                "required_rage": required_rage,
                "reason": recorded,
                "expected_reason": expected,
                "valid": recorded == expected,
                "setup_blocked_proven": setup_blocked_proven,
                "successful_skills_before": _nonnegative_int(
                    trace.get("pet_skill_success_count_current_match", 0),
                    f"{label}.skill_fire.successful_skills_before",
                ),
            }
        )

    accepted_source_turns: list[int] = []
    for index, record in enumerate(records, 1):
        if record.get("event") != "pet_skill_dispatch_result":
            continue
        result = _mapping(record.get("result") or record.get("summary"), f"{label}.pet_dispatch[{index}]")
        if result.get("state") != "COMPLETE":
            continue
        action_id = _mapping(result.get("action_id"), f"{label}.pet_dispatch[{index}].action_id")
        accepted_source_turns.append(
            _nonnegative_int(
                action_id.get("source_turn"), f"{label}.pet_dispatch[{index}].source_turn"
            )
        )

    resolution_records = [
        record for record in records if record.get("event") == "pet_skill_turn_resolved"
    ]
    immediate_kills = sum(record.get("immediateSkillKill") is True for record in resolution_records)
    first_skill_use = int(pet["accepted"] > 0)
    first_skill_kill = int(bool(resolution_records) and resolution_records[0].get("immediateSkillKill") is True)

    fire_summary = _mapping(summary.get("skillRushFireReasons"), f"{label}.skillRushFireReasons")
    fire_counts = {
        reason: _nonnegative_int(fire_summary.get(reason), f"{label}.skillRushFireReasons.{reason}")
        for reason in SKILL_FIRE_REASONS
    }
    observed_fire_counts = {
        reason: sum(record["reason"] == reason for record in fire_records)
        for reason in SKILL_FIRE_REASONS
    }
    if fire_counts != observed_fire_counts:
        raise BenchmarkDataError(f"{label} skill-fire summary disagrees with decisions")

    finisher_summary = _mapping(
        summary.get("skillRushPostSkillFinisher"), f"{label}.skillRushPostSkillFinisher"
    )
    finisher_counts = {
        key: _nonnegative_int(finisher_summary.get(key), f"{label}.finisher.{key}")
        for key in ("DEFAULT_ATTACK", "SWORD", "SECOND_PET_SKILL")
    }

    valid_finisher_attacks = 0
    invalid_attacks = 0
    pre_first_skill_attacks = 0
    valid_finisher_swords = 0
    first_post_skill_state: dict[str, Any] | None = None
    for trace in decisions:
        action = trace.get("selected_action")
        turn = trace.get("turn_number")
        if isinstance(turn, bool) or not isinstance(turn, int) or turn < 0:
            raise BenchmarkDataError(f"{label} policy decision lacks a valid turn")
        success_count = _nonnegative_int(
            trace.get("pet_skill_success_count_current_match", 0),
            f"{label}.policy.successful_skills",
        )
        if success_count > 0 and first_post_skill_state is None:
            first_post_skill_state = {
                "boss_hp": trace.get("boss_hp"),
                "boss_max_hp": trace.get("boss_max_hp"),
                "boss_hp_ratio": trace.get("boss_hp_ratio"),
                "finisher_trigger": trace.get("finisher_trigger"),
                "next_action": trace.get("finisher_action") or trace.get("policy_step"),
            }
        if action == "cast":
            prior_turns = [source for source in accepted_source_turns if source < turn]
            latest_source = max(prior_turns) if prior_turns else None
            boss_hp = trace.get("boss_hp")
            boss_max_hp = trace.get("boss_max_hp")
            valid = (
                isinstance(boss_hp, int)
                and not isinstance(boss_hp, bool)
                and isinstance(boss_max_hp, int)
                and not isinstance(boss_max_hp, bool)
                and trace.get("policy_step") == "SKILL_RUSH_POST_SKILL_FINISHER_ATTACK"
                and trace.get("finisher_action") == "DEFAULT_ATTACK"
                and trace.get("post_skill_finisher_ready") is True
                and mode_b_attack_is_valid_finisher(
                    successful_skill_count=success_count,
                    boss_hp=boss_hp,
                    boss_max_hp=boss_max_hp,
                    action_turn=turn,
                    latest_skill_source_turn=latest_source,
                    recorded_trigger=trace.get("finisher_trigger"),
                )
            )
            valid_finisher_attacks += int(valid)
            invalid_attacks += int(not valid)
            pre_first_skill_attacks += int(success_count == 0)
        if (
            action == "swap"
            and trace.get("policy_step") == "SKILL_RUSH_POST_SKILL_FINISHER_SWORD"
            and trace.get("finisher_action") == "SWORD"
            and trace.get("post_skill_finisher_ready") is True
        ):
            valid_finisher_swords += 1

    if valid_finisher_attacks != finisher_counts["DEFAULT_ATTACK"]:
        raise BenchmarkDataError(f"{label} finisher-Attack summary disagrees with decisions")
    if valid_finisher_swords != finisher_counts["SWORD"]:
        raise BenchmarkDataError(f"{label} finisher-Sword summary disagrees with decisions")
    if immediate_kills != _nonnegative_int(
        summary.get("petSkillImmediateKills"), f"{label}.petSkillImmediateKills"
    ):
        raise BenchmarkDataError(f"{label} immediate-kill summary disagrees with resolutions")

    branches = _mapping(summary.get("policyBranchCoverage"), f"{label}.policyBranchCoverage")
    branch_counts = {
        str(key): _nonnegative_int(value, f"{label}.policyBranchCoverage.{key}")
        for key, value in branches.items()
    }
    skill_rush_leakage = sum(
        count
        for branch, count in branch_counts.items()
        if branch.startswith("SKILL_RUSH_") or branch == "PET_SKILL"
    )
    first_fire = fire_records[0] if fire_records else None
    return {
        "fire_records": fire_records,
        "fire_reason_counts": fire_counts,
        "invalid_fire_reasons": sum(not record["valid"] for record in fire_records),
        "first_skill_use": first_skill_use,
        "first_skill_kill": first_skill_kill,
        "survived_first_skill": int(first_skill_use and not first_skill_kill),
        "first_skill_fire": first_fire,
        "immediate_kills": immediate_kills,
        "valid_finisher_attacks": valid_finisher_attacks,
        "invalid_attacks": invalid_attacks,
        "pre_first_skill_attacks": pre_first_skill_attacks,
        "valid_finisher_swords": valid_finisher_swords,
        "second_pet_skill": finisher_counts["SECOND_PET_SKILL"],
        "first_post_skill_state": first_post_skill_state,
        "early_boss_prep_sword": _nonnegative_int(
            summary.get("skillRushEarlyBossPrepSword"), f"{label}.skillRushEarlyBossPrepSword"
        ),
        "skipped_current_sword_for_resource": _nonnegative_int(
            summary.get("skippedCurrentSwordForResource"),
            f"{label}.skippedCurrentSwordForResource",
        ),
        "left_direct_boss_sword": _nonnegative_int(
            summary.get("selectedMoveLeftDirectBossSword"),
            f"{label}.selectedMoveLeftDirectBossSword",
        ),
        "left_indirect_boss_sword": _nonnegative_int(
            summary.get("selectedMoveLeftIndirectBossSword"),
            f"{label}.selectedMoveLeftIndirectBossSword",
        ),
        "branch_counts": branch_counts,
        "skill_rush_branch_leakage": skill_rush_leakage,
    }


def _profile_for_mode(snapshot: Mapping[str, Any], mode: str, label: str) -> Mapping[str, Any]:
    profile = _mapping(snapshot.get("gameplay_config"), f"{label}.gameplay_config")
    expected = EXPECTED_PROFILES[mode]
    observed = {key: profile.get(key) for key in expected}
    if observed != expected:
        raise BenchmarkDataError(
            f"{label} profile mismatch for {mode}: expected {expected}, got {observed}"
        )
    return profile


def _extract_attempt(
    *,
    mode: str,
    farm_run_id: str,
    attempt: Mapping[str, Any],
    events: Sequence[Mapping[str, Any]],
    combat_records: Sequence[Mapping[str, Any]],
    energy_delta: float | None,
    excluded: bool,
    exclusion_reason: str | None,
) -> dict[str, Any]:
    label = f"{farm_run_id} attempt"
    attempt_index = _nonnegative_int(attempt.get("attempt_index"), f"{label}.attempt_index")
    if attempt_index <= 0:
        raise BenchmarkDataError(f"{label}.attempt_index must be positive")
    match_id = _required_text(attempt, "match_id", label)
    result = _required_text(attempt, "result", label)
    if result not in ALL_RESULTS:
        raise BenchmarkDataError(f"{label}.result is unsupported: {result}")
    completed = result in COMPLETED_RESULTS
    start_timestamp = _required_text(attempt, "start_timestamp", label)
    entry_event = _attempt_event(events, "match_entry_result", attempt_index)
    if entry_event is None:
        raise BenchmarkDataError(f"{label} lacks match_entry_result")
    if abs(duration_seconds(start_timestamp, entry_event.get("timestamp"))) > 0.002:
        raise BenchmarkDataError(f"{label} opening timestamp disagrees with match_entry_result")
    end_timestamp = attempt.get("end_timestamp")
    recorded_duration = _optional_nonnegative_number(
        attempt.get("duration_seconds"), f"{label}.duration_seconds"
    )
    if end_timestamp is None or recorded_duration is None:
        raise BenchmarkDataError(f"{label} is missing terminal timestamp/duration")
    calculated_duration = duration_seconds(start_timestamp, end_timestamp)
    if abs(calculated_duration - recorded_duration) > 0.002:
        raise BenchmarkDataError(f"{label} duration does not match its timestamps")
    if completed:
        if attempt.get("normal_postmatch") is not True:
            raise BenchmarkDataError(f"{label} completed without normal postmatch proof")
        terminal = _mapping(attempt.get("terminal_snapshot"), f"{label}.terminal_snapshot")
        if terminal.get("match_id") != match_id or terminal.get("result") != result:
            raise BenchmarkDataError(f"{label} terminal snapshot disagrees with result")

    summary = _combat_summary(combat_records, label)
    counters = _mapping(summary.get("counters"), f"{label}.counters")
    pet = _pet_skill_metrics(combat_records)
    rush = _skill_rush_metrics(combat_records, summary, pet, label)
    policy = _policy_audit(combat_records)
    swap_sent = _nonnegative_int(attempt.get("swap_sent"), f"{label}.swap_sent")
    swap_ack = _nonnegative_int(attempt.get("swap_acknowledged"), f"{label}.swap_acknowledged")
    swap_reject = _nonnegative_int(attempt.get("swap_rejected"), f"{label}.swap_rejected")
    ordinary_cast = _nonnegative_int(attempt.get("cast_sent"), f"{label}.cast_sent")
    evolve = _nonnegative_int(attempt.get("evolve_attempts"), f"{label}.evolve_attempts")
    pass_count = _nonnegative_int(attempt.get("pass_count"), f"{label}.pass_count")
    local_turns = _nonnegative_int(attempt.get("local_turns"), f"{label}.local_turns")
    pet_attempts = _counter(counters, "pet_skill_attempts", f"{label}.counters")
    if pet_attempts < pet["accepted"]:
        raise BenchmarkDataError(f"{label} accepted Pet Skills exceed attempts")
    if pet["perfect"] != _counter(counters, "pet_skill_perfect", f"{label}.counters"):
        raise BenchmarkDataError(f"{label} Pet Skill Perfect counters disagree")
    for attempt_key, counter_key, observed in (
        ("swap_sent", "swap_sent", swap_sent),
        ("swap_acknowledged", "swap_acknowledged", swap_ack),
        ("swap_rejected", "swap_rejected", swap_reject),
        ("cast_sent", "cast_sent", ordinary_cast),
        ("evolve_attempts", "evolve_attempts", evolve),
        ("local_turns", "local_turns_observed", local_turns),
    ):
        counter_value = _counter(counters, counter_key, f"{label}.counters")
        if counter_value != observed:
            raise BenchmarkDataError(
                f"{label} {attempt_key}={observed} disagrees with summary {counter_key}={counter_value}"
            )
    pass_executed = _nonnegative_int(
        summary.get("passExecuted"), f"{label}.passExecuted"
    )
    if pass_executed != pass_count:
        raise BenchmarkDataError(
            f"{label} pass_count={pass_count} disagrees with summary "
            f"passExecuted={pass_executed}"
        )

    safety = _mapping(summary.get("safetyTelemetry"), f"{label}.safetyTelemetry")
    safety_counts = {
        key: _counter(safety, key, f"{label}.safetyTelemetry")
        for key in (
            "duplicate",
            "misclick",
            "partialInput",
            "wrongTurn",
            "staleAction",
            "bossTurnInput",
            "postmatchInput",
            "lobbyInput",
            "inputAfterCombat",
        )
    }
    contract_violations = 0
    if mode == MODE_A:
        contract_violations += pet_attempts + pet["accepted"]
        contract_violations += rush["skill_rush_branch_leakage"]
    else:
        if ordinary_cast != rush["valid_finisher_attacks"] + rush["invalid_attacks"]:
            raise BenchmarkDataError(f"{label} ordinary CAST count disagrees with policy decisions")
        contract_violations += evolve + rush["invalid_attacks"]
        contract_violations += max(0, pet["accepted"] - pet["perfect"])
        contract_violations += (
            pet["wrong_directions"]
            + pet["skipped_directions"]
            + pet["duplicate_directions"]
            + pet["stale_directions"]
            + pet["unconfirmed_directions"]
            + pet["blind_retries"]
            + pet["duplicate_space"]
            + pet["outside_window_space"]
        )
        contract_violations += _counter(
            counters, "pet_skill_same_source_followups", f"{label}.counters"
        )
        contract_violations += _counter(
            counters, "pet_skill_zero_input_failures", f"{label}.counters"
        )
        contract_violations += _counter(
            counters, "pet_skill_after_input_failures", f"{label}.counters"
        )
        contract_violations += _counter(
            counters, "pet_skill_turn_resolution_unconfirmed", f"{label}.counters"
        )
        contract_violations += rush["invalid_fire_reasons"]
    contract_violations += sum(safety_counts.values())
    contract_violations += _counter(
        counters, "attack_priority_evolve_violations", f"{label}.counters"
    )
    contract_violations += sum(policy.values())
    contract_violations += int(attempt.get("result_consistency") == "RESULT_CONFLICT")

    farm_cycle = _cycle_duration(events, attempt_index, start_timestamp) if completed else None
    return {
        "mode": mode,
        "farm_run_id": farm_run_id,
        "attempt_index": attempt_index,
        "match_id": match_id,
        "result": result,
        "completed": completed,
        "combat_start_at": start_timestamp,
        "terminal_at": end_timestamp,
        "combat_duration_s": calculated_duration,
        "farm_cycle_duration_s": farm_cycle,
        "local_turns": local_turns,
        "swap_sent": swap_sent,
        "swap_ack": swap_ack,
        "swap_reject": swap_reject,
        "evolve": evolve,
        "ordinary_cast": ordinary_cast,
        "pet_skill_attempts": pet_attempts,
        "pet_skill_accepted": pet["accepted"],
        "pass": pass_count,
        "major_gameplay_actions": (
            swap_sent + evolve + ordinary_cast + pet_attempts + pass_count
        ),
        "pet_skill_perfect": pet["perfect"],
        "pet_skill_good": pet["good"],
        "pet_skill_bad": pet["bad"],
        "first_pet_skill_use": rush["first_skill_use"],
        "first_pet_skill_kill": rush["first_skill_kill"],
        "survived_first_pet_skill": rush["survived_first_skill"],
        "first_skill_fire": rush["first_skill_fire"],
        "skill_fire_records": rush["fire_records"],
        "skill_fire_reason_counts": rush["fire_reason_counts"],
        "post_skill_finisher": bool(
            rush["valid_finisher_attacks"] or rush["valid_finisher_swords"]
        ),
        "finisher_type": (
            "DEFAULT_ATTACK"
            if rush["valid_finisher_attacks"]
            else "SWORD" if rush["valid_finisher_swords"] else None
        ),
        "valid_post_skill_finisher_attack": rush["valid_finisher_attacks"],
        "invalid_mode_b_attack": rush["invalid_attacks"] if mode == MODE_B else 0,
        "ordinary_attack_before_first_skill": (
            rush["pre_first_skill_attacks"] if mode == MODE_B else 0
        ),
        "finisher_sword": rush["valid_finisher_swords"],
        "second_pet_skill": rush["second_pet_skill"],
        "first_post_skill_state": rush["first_post_skill_state"],
        "early_boss_prep_sword": rush["early_boss_prep_sword"],
        "skipped_current_sword_for_resource": rush[
            "skipped_current_sword_for_resource"
        ],
        "selected_move_left_direct_boss_sword": rush["left_direct_boss_sword"],
        "selected_move_left_indirect_boss_sword": rush[
            "left_indirect_boss_sword"
        ],
        "policy_branch_counts": rush["branch_counts"],
        "skill_rush_branch_leakage": rush["skill_rush_branch_leakage"],
        "pet_skill_zero_input_failures": _counter(
            counters, "pet_skill_zero_input_failures", f"{label}.counters"
        ),
        "qte_directions_sent": pet["directions_sent"],
        "qte_directions_confirmed": pet["directions_confirmed"],
        "qte_wrong": pet["wrong_directions"],
        "qte_skipped": pet["skipped_directions"],
        "qte_duplicate": pet["duplicate_directions"],
        "qte_stale": pet["stale_directions"],
        "qte_unconfirmed": pet["unconfirmed_directions"],
        "qte_blind_retries": pet["blind_retries"],
        "space_count": pet["space_count"],
        "duplicate_space": pet["duplicate_space"],
        "outside_window_space": pet["outside_window_space"],
        "technical_abort": result == "TECHNICAL_ABORT",
        "recovery": bool(attempt.get("technical_recovery")),
        "energy_delta": energy_delta,
        "safety_counters": safety_counts,
        "sword_policy_audit": policy,
        "critical_safety_violations": contract_violations,
        "excluded": excluded,
        "exclusion_reason": exclusion_reason,
    }


def extract_run(
    run_directory: Path,
    *,
    mode: str,
    expected_boss: Mapping[str, Any],
    excluded: bool = False,
    exclusion_reason: str | None = None,
    energy_deltas: Mapping[str, Any] | None = None,
) -> dict[str, Any]:
    """Extract one FarmRunner run without changing any source artifact."""

    if mode not in MODES:
        raise BenchmarkDataError(f"unsupported mode: {mode}")
    if excluded and (not isinstance(exclusion_reason, str) or not exclusion_reason.strip()):
        raise BenchmarkDataError("excluded run requires an explicit exclusion_reason")
    if not excluded and exclusion_reason is not None:
        raise BenchmarkDataError("included run cannot have an exclusion_reason")
    raw = _read_json(run_directory / "run.json")
    if raw.get("schema") != "pokiguard.farm_run.v2":
        raise BenchmarkDataError(f"{run_directory} has unsupported FarmRun schema")
    snapshot = _mapping(raw.get("snapshot"), f"{run_directory}.snapshot")
    farm_run_id = _required_text(snapshot, "farm_run_id", f"{run_directory}.snapshot")
    if farm_run_id != run_directory.name:
        raise BenchmarkDataError("FarmRunId does not match its artifact directory")
    target = _mapping(snapshot.get("target"), f"{farm_run_id}.target")
    expected_id = str(expected_boss.get("boss_id") or "").strip()
    expected_name = str(expected_boss.get("boss_name") or "").strip()
    if str(target.get("boss_id") or "").strip() != expected_id or str(
        target.get("boss_name") or ""
    ).strip() != expected_name:
        raise BenchmarkDataError(f"{farm_run_id} boss target does not match manifest")
    _profile_for_mode(snapshot, mode, farm_run_id)
    events = _read_jsonl(run_directory / "events.jsonl")
    attempts = _sequence(snapshot.get("attempts"), f"{farm_run_id}.attempts")
    match_attempts = _nonnegative_int(
        snapshot.get("match_attempts"), f"{farm_run_id}.match_attempts"
    )
    if len(attempts) != match_attempts:
        raise BenchmarkDataError(
            f"{farm_run_id} exposes {len(attempts)} rows for {match_attempts} attempts"
        )
    energy_map = energy_deltas or {}
    if not isinstance(energy_map, Mapping):
        raise BenchmarkDataError(f"{farm_run_id}.energy_deltas_by_match_id must be an object")
    rows: list[dict[str, Any]] = []
    for attempt in attempts:
        attempt_map = _mapping(attempt, f"{farm_run_id}.attempt")
        attempt_index = _nonnegative_int(
            attempt_map.get("attempt_index"), f"{farm_run_id}.attempt_index"
        )
        if attempt_index <= 0:
            raise BenchmarkDataError(f"{farm_run_id}.attempt_index must be positive")
        match_id = attempt_map.get("match_id")
        delta = _optional_nonnegative_number(
            energy_map.get(match_id), f"{farm_run_id}.energy_delta[{match_id}]"
        )
        combat_path = run_directory / "matches" / f"attempt_{attempt_index:03d}" / "combat.jsonl"
        rows.append(
            _extract_attempt(
                mode=mode,
                farm_run_id=farm_run_id,
                attempt=attempt_map,
                events=events,
                combat_records=_read_jsonl(combat_path),
                energy_delta=delta,
                excluded=excluded,
                exclusion_reason=exclusion_reason.strip() if exclusion_reason else None,
            )
        )
    completed_rows = [row for row in rows if row["completed"]]
    completed_matches = _nonnegative_int(
        snapshot.get("completed_matches"), f"{farm_run_id}.completed_matches"
    )
    if len(completed_rows) != completed_matches:
        raise BenchmarkDataError(f"{farm_run_id} completed-match accounting is inconsistent")
    if len({row["attempt_index"] for row in rows}) != len(rows):
        raise BenchmarkDataError(f"{farm_run_id} contains duplicate attempt indices")
    wins = _nonnegative_int(snapshot.get("wins"), f"{farm_run_id}.wins")
    losses = _nonnegative_int(snapshot.get("losses"), f"{farm_run_id}.losses")
    unknown = _nonnegative_int(
        snapshot.get("unknown_results"), f"{farm_run_id}.unknown_results"
    )
    if wins + losses + unknown != completed_matches:
        raise BenchmarkDataError(f"{farm_run_id} W/L/U accounting is inconsistent")
    technical_aborts = _nonnegative_int(
        snapshot.get("technical_aborts"), f"{farm_run_id}.technical_aborts"
    )
    if technical_aborts != sum(row["technical_abort"] for row in rows):
        raise BenchmarkDataError(f"{farm_run_id} technical-abort accounting is inconsistent")
    sent_inputs = sum(
        int(record.get("sent") is True)
        for record in _sequence(snapshot.get("input_records"), f"{farm_run_id}.input_records")
        if isinstance(record, Mapping)
    )
    pre_entry_failure = None
    if match_attempts == 0:
        pre_entry_failure = {
            "mode": mode,
            "farm_run_id": farm_run_id,
            "stop_reason": snapshot.get("stop_reason"),
            "zero_input": sent_inputs == 0,
            "sent_inputs": sent_inputs,
            "excluded": excluded,
            "exclusion_reason": exclusion_reason,
        }
    return {
        "mode": mode,
        "farm_run_id": farm_run_id,
        "boss": dict(target),
        "profile": dict(snapshot["gameplay_config"]),
        "wall_clock_start": _required_text(snapshot, "start_timestamp", farm_run_id),
        "wall_clock_end": (
            _required_text(snapshot, "end_timestamp", farm_run_id)
            if not excluded
            else snapshot.get("end_timestamp")
        ),
        "state": snapshot.get("state"),
        "stop_reason": snapshot.get("stop_reason"),
        "target_completed_matches": _nonnegative_int(
            _mapping(snapshot.get("limits"), f"{farm_run_id}.limits").get(
                "target_completed_matches"
            ),
            f"{farm_run_id}.target_completed_matches",
        ),
        "max_match_attempts": _nonnegative_int(
            _mapping(snapshot.get("limits"), f"{farm_run_id}.limits").get(
                "max_match_attempts"
            ),
            f"{farm_run_id}.max_match_attempts",
        ),
        "attempts": match_attempts,
        "completed": completed_matches,
        "wins": wins,
        "losses": losses,
        "unknown": unknown,
        "technical_aborts": technical_aborts,
        "technical_recoveries": _nonnegative_int(
            snapshot.get("technical_recoveries"), f"{farm_run_id}.technical_recoveries"
        ),
        "rows": rows,
        "pre_entry_failure": pre_entry_failure,
        "excluded": excluded,
        "exclusion_reason": exclusion_reason,
    }


def summarize_mode(mode: str, runs: Sequence[Mapping[str, Any]]) -> dict[str, Any]:
    included = [run for run in runs if run.get("mode") == mode and not run.get("excluded")]
    rows = [row for run in included for row in run.get("rows", []) if not row.get("excluded")]
    completed = [row for row in rows if row.get("completed")]
    attempts = sum(int(run.get("attempts", 0)) for run in included)
    completed_count = len(completed)
    energy_values = [row.get("energy_delta") for row in completed]
    energy_complete = bool(completed) and all(value is not None for value in energy_values)
    cycle_values = [row["farm_cycle_duration_s"] for row in completed if row["farm_cycle_duration_s"] is not None]
    pet_accepted = sum(row["pet_skill_accepted"] for row in completed)
    pet_perfect = sum(row["pet_skill_perfect"] for row in completed)
    first_skill_uses = sum(row["first_pet_skill_use"] for row in completed)
    first_skill_kills = sum(row["first_pet_skill_kill"] for row in completed)
    first_fires = [
        row["first_skill_fire"] for row in completed if row["first_skill_fire"] is not None
    ]
    fire_reason_counts = {
        reason: sum(row["skill_fire_reason_counts"][reason] for row in completed)
        for reason in SKILL_FIRE_REASONS
    }
    branch_counts: dict[str, int] = {}
    for row in completed:
        for branch, count in row["policy_branch_counts"].items():
            branch_counts[branch] = branch_counts.get(branch, 0) + count
    return {
        "mode": mode,
        "farm_run_ids": [run["farm_run_id"] for run in included],
        "n": completed_count,
        "attempts": attempts,
        "wins": sum(row["result"] == "WIN" for row in completed),
        "losses": sum(row["result"] == "LOSS" for row in completed),
        "unknown": sum(row["result"] == "UNKNOWN" for row in completed),
        "technical_aborts": sum(int(run.get("technical_aborts", 0)) for run in included),
        "technical_recoveries": sum(
            int(run.get("technical_recoveries", 0)) for run in included
        ),
        "attempts_per_completion": (
            round(attempts / completed_count, 3) if completed_count else None
        ),
        "completion_rate_pct": (
            round(completed_count / attempts * 100.0, 3) if attempts else None
        ),
        "combat_duration_s": numeric_stats(row["combat_duration_s"] for row in completed),
        "farm_cycle_duration_s": {
            "status": "MEASURED" if len(cycle_values) == completed_count and completed_count else "NOT_MEASURED",
            **numeric_stats(cycle_values),
        },
        "local_turns": numeric_stats(row["local_turns"] for row in completed),
        "swap_sent": numeric_stats(row["swap_sent"] for row in completed),
        "major_gameplay_actions": numeric_stats(
            row["major_gameplay_actions"] for row in completed
        ),
        "evolve": numeric_stats(row["evolve"] for row in completed),
        "ordinary_cast": numeric_stats(row["ordinary_cast"] for row in completed),
        "pet_skill_attempts": numeric_stats(
            row["pet_skill_attempts"] for row in completed
        ),
        "pet_skill_accepted": pet_accepted,
        "pet_skill_perfect": pet_perfect,
        "pet_skill_good": sum(row["pet_skill_good"] for row in completed),
        "pet_skill_bad": sum(row["pet_skill_bad"] for row in completed),
        "pet_skill_perfect_rate_pct": (
            round(pet_perfect / pet_accepted * 100.0, 3) if pet_accepted else None
        ),
        "first_pet_skill_uses": first_skill_uses,
        "first_pet_skill_kills": first_skill_kills,
        "first_skill_kill_rate_pct": (
            round(first_skill_kills / first_skill_uses * 100.0, 3)
            if first_skill_uses
            else None
        ),
        "survived_first_pet_skill": sum(
            row["survived_first_pet_skill"] for row in completed
        ),
        "post_skill_finisher_count": sum(
            row["post_skill_finisher"] for row in completed
        ),
        "finisher_attack_count": sum(
            row["valid_post_skill_finisher_attack"] for row in completed
        ),
        "finisher_sword_count": sum(row["finisher_sword"] for row in completed),
        "second_pet_skill_count": sum(row["second_pet_skill"] for row in completed),
        "ordinary_attack_before_first_skill": sum(
            row["ordinary_attack_before_first_skill"] for row in completed
        ),
        "invalid_mode_b_attack": sum(row["invalid_mode_b_attack"] for row in completed),
        "skill_fire_reason_counts": fire_reason_counts,
        "first_skill_boss_hp_ratio": numeric_stats(
            fire["boss_hp_ratio"] for fire in first_fires
        ),
        "first_skill_known_sword_count": numeric_stats(
            fire["known_sword_count"] for fire in first_fires
        ),
        "hp_prep_reached_at_first_skill": sum(
            fire["boss_hp_ratio"] < SKILL_RUSH_HP_PREP_RATIO for fire in first_fires
        ),
        "sword_density_reached_at_first_skill": sum(
            fire["known_sword_count"] >= SKILL_RUSH_SWORD_DENSITY_MINIMUM
            for fire in first_fires
        ),
        "early_boss_prep_sword": sum(row["early_boss_prep_sword"] for row in completed),
        "skipped_current_sword_for_resource": sum(
            row["skipped_current_sword_for_resource"] for row in completed
        ),
        "selected_move_left_direct_boss_sword": sum(
            row["selected_move_left_direct_boss_sword"] for row in completed
        ),
        "selected_move_left_indirect_boss_sword": sum(
            row["selected_move_left_indirect_boss_sword"] for row in completed
        ),
        "policy_branch_counts": branch_counts,
        "skill_rush_branch_leakage": sum(
            row["skill_rush_branch_leakage"] for row in completed
        ),
        "pass": numeric_stats(row["pass"] for row in completed),
        "qte": {
            key: sum(row[key] for row in completed)
            for key in (
                "qte_directions_sent",
                "qte_directions_confirmed",
                "qte_wrong",
                "qte_skipped",
                "qte_duplicate",
                "qte_stale",
                "qte_unconfirmed",
                "qte_blind_retries",
                "space_count",
                "duplicate_space",
                "outside_window_space",
            )
        },
        "energy": {
            "status": "MEASURED" if energy_complete else "NOT_MEASURED",
            **numeric_stats(value for value in energy_values if value is not None),
        },
        "critical_safety_violations": sum(
            row["critical_safety_violations"] for row in rows
        ),
        "pre_entry_failures": sum(
            run.get("pre_entry_failure") is not None for run in included
        ),
    }


def _comparison(a: Mapping[str, Any], b: Mapping[str, Any]) -> dict[str, Any]:
    def stat(metric: str, field: str) -> dict[str, float | None]:
        return relative_reduction(a[metric][field], b[metric][field])

    cycle_measured = (
        a["farm_cycle_duration_s"]["status"] == "MEASURED"
        and b["farm_cycle_duration_s"]["status"] == "MEASURED"
    )
    energy_measured = a["energy"]["status"] == "MEASURED" and b["energy"]["status"] == "MEASURED"
    return {
        "direction": "positive difference/reduction means B used less or was faster",
        "mean_combat_duration_s": stat("combat_duration_s", "mean"),
        "median_combat_duration_s": stat("combat_duration_s", "median"),
        "mean_farm_cycle_duration_s": (
            stat("farm_cycle_duration_s", "mean") if cycle_measured else None
        ),
        "median_farm_cycle_duration_s": (
            stat("farm_cycle_duration_s", "median") if cycle_measured else None
        ),
        "mean_swap_sent": stat("swap_sent", "mean"),
        "median_swap_sent": stat("swap_sent", "median"),
        "mean_major_gameplay_actions": stat("major_gameplay_actions", "mean"),
        "attempts_per_completion": relative_reduction(
            a["attempts_per_completion"], b["attempts_per_completion"]
        ),
        "mean_energy_delta": (
            relative_reduction(a["energy"]["mean"], b["energy"]["mean"])
            if energy_measured
            else None
        ),
    }


def analyze_manifest(manifest_path: Path, logs_root: Path) -> dict[str, Any]:
    manifest = _read_json(manifest_path)
    if manifest.get("schema") != MANIFEST_SCHEMA:
        raise BenchmarkDataError("unsupported Phase 3D.1 manifest schema")
    source_commit = _required_text(manifest, "benchmark_source_commit", "manifest")
    app_version = _required_text(manifest, "app_version", "manifest")
    expected_boss = _mapping(manifest.get("expected_boss"), "manifest.expected_boss")
    _required_text(expected_boss, "boss_id", "manifest.expected_boss")
    _required_text(expected_boss, "boss_name", "manifest.expected_boss")
    specs = _sequence(manifest.get("runs"), "manifest.runs")
    order = _sequence(manifest.get("execution_order"), "manifest.execution_order")
    run_ids = [
        _required_text(_mapping(spec, f"manifest.runs[{index}]"), "farm_run_id", f"manifest.runs[{index}]")
        for index, spec in enumerate(specs)
    ]
    if len(set(run_ids)) != len(run_ids):
        raise BenchmarkDataError("manifest contains duplicate FarmRunIds")
    if list(order) != run_ids:
        raise BenchmarkDataError("execution_order must list every run once in actual order")
    energy_metric = _mapping(manifest.get("energy_metric"), "manifest.energy_metric")
    energy_status = _required_text(energy_metric, "status", "manifest.energy_metric")
    if energy_status not in {"MEASURED", "NOT_MEASURED"}:
        raise BenchmarkDataError("energy status must be MEASURED or NOT_MEASURED")
    runs: list[dict[str, Any]] = []
    excluded_runs: list[dict[str, Any]] = []
    for index, raw_spec in enumerate(specs):
        spec = _mapping(raw_spec, f"manifest.runs[{index}]")
        mode = _required_text(spec, "mode", f"manifest.runs[{index}]")
        if mode not in MODES:
            raise BenchmarkDataError(f"unsupported mode: {mode}")
        run_id = run_ids[index]
        excluded = spec.get("excluded", False)
        if not isinstance(excluded, bool):
            raise BenchmarkDataError(f"manifest.runs[{index}].excluded must be boolean")
        reason = spec.get("exclusion_reason")
        energy_deltas = spec.get("energy_deltas_by_match_id", {})
        if energy_status == "NOT_MEASURED" and energy_deltas:
            raise BenchmarkDataError("energy deltas supplied while energy is NOT_MEASURED")
        try:
            run = extract_run(
                logs_root / run_id,
                mode=mode,
                expected_boss=expected_boss,
                excluded=excluded,
                exclusion_reason=reason,
                energy_deltas=energy_deltas,
            )
        except BenchmarkDataError as exc:
            if not excluded:
                raise
            if not isinstance(reason, str) or not reason.strip():
                raise BenchmarkDataError("excluded run requires an explicit reason") from exc
            excluded_runs.append(
                {
                    "mode": mode,
                    "farm_run_id": run_id,
                    "reason": reason.strip(),
                    "parse_error": str(exc),
                }
            )
            continue
        runs.append(run)
        if excluded:
            excluded_runs.append(
                {
                    "mode": mode,
                    "farm_run_id": run_id,
                    "reason": str(reason).strip(),
                    "parse_error": None,
                }
            )
    summaries = {mode: summarize_mode(mode, runs) for mode in MODES}
    if energy_status == "MEASURED":
        incomplete_energy = [
            mode
            for mode, summary in summaries.items()
            if summary["n"] and summary["energy"]["status"] != "MEASURED"
        ]
        if incomplete_energy:
            raise BenchmarkDataError(
                "authoritative energy deltas are incomplete for "
                + ", ".join(incomplete_energy)
            )
    rows = [row for run in runs for row in run["rows"]]
    pre_entry = [
        run["pre_entry_failure"]
        for run in runs
        if run.get("pre_entry_failure") is not None
    ]
    return {
        "schema": DATASET_SCHEMA,
        "analyzer_version": ANALYZER_VERSION,
        "benchmark_source_commit": source_commit,
        "app_version": app_version,
        "boss": dict(expected_boss),
        "execution_order": list(order),
        "measurement": {
            "combat_duration": "accepted match opening timestamp to FarmRunner terminal accounting timestamp",
            "farm_cycle_duration": "latest proven safe boss lobby before entry to proven safe boss lobby after result",
            "major_gameplay_actions_formula": "SWAP_sent + EVOLVE_attempts + ordinary_CAST_sent + PET_SKILL_attempts + PASS",
            "energy": dict(energy_metric),
            "frozen_mode_b_policy": {
                "hp_prep_ratio_strictly_below": SKILL_RUSH_HP_PREP_RATIO,
                "known_sword_minimum": SKILL_RUSH_SWORD_DENSITY_MINIMUM,
                "very_low_hp_ratio_at_or_below": SKILL_RUSH_VERY_LOW_HP_RATIO,
                "post_skill_finisher_hp_strictly_below": POST_SKILL_FINISHER_HP,
                "post_skill_finisher_ratio_strictly_below": POST_SKILL_FINISHER_RATIO,
            },
        },
        "runs": runs,
        "matches": rows,
        "pre_entry_failures": pre_entry,
        "excluded_runs": excluded_runs,
        "modes": summaries,
        "comparison": _comparison(summaries[MODE_A], summaries[MODE_B]),
        "validation": {
            "same_source_commit_declared": True,
            "same_app_version_declared": True,
            "same_boss_verified": True,
            "result_accounting_consistent": all(
                summary["wins"] + summary["losses"] + summary["unknown"] == summary["n"]
                for summary in summaries.values()
            ),
            "critical_safety_violations": sum(
                summary["critical_safety_violations"] for summary in summaries.values()
            ),
            "minimum_sample_met": all(
                summaries[mode]["n"] >= 5 for mode in MODES
            ),
            "pass_strong_sample_met": all(
                summaries[mode]["n"] == 10 for mode in MODES
            ),
        },
    }


def write_json(path: Path, payload: Mapping[str, Any]) -> None:
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(json.dumps(payload, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")


def _display(value: Any, suffix: str = "") -> str:
    if value is None:
        return "NOT_MEASURED"
    if isinstance(value, float):
        return f"{value:.3f}{suffix}"
    return f"{value}{suffix}"


def render_markdown_summary(analysis: Mapping[str, Any]) -> str:
    a = analysis["modes"][MODE_A]
    b = analysis["modes"][MODE_B]
    comparison = analysis["comparison"]
    rows = [
        ("Completed matches", a["n"], b["n"], a["n"] - b["n"], None),
        ("Attempts", a["attempts"], b["attempts"], a["attempts"] - b["attempts"], None),
        ("Wins", a["wins"], b["wins"], a["wins"] - b["wins"], None),
        ("Losses", a["losses"], b["losses"], a["losses"] - b["losses"], None),
        ("Unknown", a["unknown"], b["unknown"], a["unknown"] - b["unknown"], None),
        (
            "Mean combat duration (s)",
            a["combat_duration_s"]["mean"],
            b["combat_duration_s"]["mean"],
            comparison["mean_combat_duration_s"]["difference_a_minus_b"],
            comparison["mean_combat_duration_s"]["reduction_pct"],
        ),
        (
            "Median combat duration (s)",
            a["combat_duration_s"]["median"],
            b["combat_duration_s"]["median"],
            comparison["median_combat_duration_s"]["difference_a_minus_b"],
            comparison["median_combat_duration_s"]["reduction_pct"],
        ),
        (
            "Mean farm-cycle duration (s)",
            a["farm_cycle_duration_s"]["mean"],
            b["farm_cycle_duration_s"]["mean"],
            (comparison["mean_farm_cycle_duration_s"] or {}).get("difference_a_minus_b"),
            (comparison["mean_farm_cycle_duration_s"] or {}).get("reduction_pct"),
        ),
        (
            "Median farm-cycle duration (s)",
            a["farm_cycle_duration_s"]["median"],
            b["farm_cycle_duration_s"]["median"],
            (comparison["median_farm_cycle_duration_s"] or {}).get("difference_a_minus_b"),
            (comparison["median_farm_cycle_duration_s"] or {}).get("reduction_pct"),
        ),
        (
            "Mean SWAP sent",
            a["swap_sent"]["mean"],
            b["swap_sent"]["mean"],
            comparison["mean_swap_sent"]["difference_a_minus_b"],
            comparison["mean_swap_sent"]["reduction_pct"],
        ),
        (
            "Median SWAP sent",
            a["swap_sent"]["median"],
            b["swap_sent"]["median"],
            comparison["median_swap_sent"]["difference_a_minus_b"],
            comparison["median_swap_sent"]["reduction_pct"],
        ),
        (
            "Mean major gameplay actions",
            a["major_gameplay_actions"]["mean"],
            b["major_gameplay_actions"]["mean"],
            comparison["mean_major_gameplay_actions"]["difference_a_minus_b"],
            comparison["mean_major_gameplay_actions"]["reduction_pct"],
        ),
        ("EVOLVE total", a["evolve"]["total"], b["evolve"]["total"], None, None),
        ("Ordinary Attack total", a["ordinary_cast"]["total"], b["ordinary_cast"]["total"], None, None),
        ("Pet Skill accepted", a["pet_skill_accepted"], b["pet_skill_accepted"], None, None),
        ("First Pet Skill kills / uses", f"{a['first_pet_skill_kills']}/{a['first_pet_skill_uses']}", f"{b['first_pet_skill_kills']}/{b['first_pet_skill_uses']}", None, None),
        ("Post-skill finishers", a["post_skill_finisher_count"], b["post_skill_finisher_count"], None, None),
        ("Second Pet Skill", a["second_pet_skill_count"], b["second_pet_skill_count"], None, None),
        ("PASS total", a["pass"]["total"], b["pass"]["total"], None, None),
        ("Technical aborts", a["technical_aborts"], b["technical_aborts"], None, None),
        ("Recoveries", a["technical_recoveries"], b["technical_recoveries"], None, None),
    ]
    lines = [
        "| Metric | A Default | B Pet Skill | Difference (A-B) | Reduction |",
        "|---|---:|---:|---:|---:|",
    ]
    for metric, a_value, b_value, difference, percentage in rows:
        lines.append(
            f"| {metric} | {_display(a_value)} | {_display(b_value)} | "
            f"{_display(difference)} | {_display(percentage, '%')} |"
        )
    return "\n".join(lines) + "\n"


__all__ = [
    "ANALYZER_VERSION",
    "BenchmarkDataError",
    "DATASET_SCHEMA",
    "EXPECTED_PROFILES",
    "MANIFEST_SCHEMA",
    "MODE_A",
    "MODE_B",
    "classify_post_skill_finisher_trigger",
    "classify_skill_fire_reason",
    "mode_b_attack_is_valid_finisher",
    "analyze_manifest",
    "duration_seconds",
    "extract_run",
    "numeric_stats",
    "relative_reduction",
    "render_markdown_summary",
    "write_json",
]
