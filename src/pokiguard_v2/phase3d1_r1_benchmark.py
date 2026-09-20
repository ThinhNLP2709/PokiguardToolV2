"""Phase 3D.1-R1 remediation and refreshed A/B evidence analyzer."""

from __future__ import annotations

from collections import Counter
import json
from pathlib import Path
from statistics import mean, median
from typing import Any, Mapping, Sequence

from .basic_policy import (
    PET_SKILL_FIRE_VALUE_DEFAULT,
    PET_SKILL_FIRE_VALUE_MAXIMUM,
    PET_SKILL_FIRE_VALUE_MINIMUM,
)
from .gameplay_profile import PetSkillFireCondition

from .phase3d1_benchmark import (
    BenchmarkDataError,
    MODE_A,
    MODE_B,
    _comparison,
    extract_run,
    summarize_mode,
)


MANIFEST_SCHEMA = "pokiguard.phase3d1_r1.manifest.v1"
DATASET_SCHEMA = "pokiguard.phase3d1_r1.dataset.v1"
ANALYZER_VERSION = 1
R1_REMEDIATION = "R1_REMEDIATION"
PHASE_ORDER = (R1_REMEDIATION, MODE_A, MODE_B)
R1_SWORD_THRESHOLD = PET_SKILL_FIRE_VALUE_DEFAULT
SETUP_FALLBACK_TYPES = (
    "RELAXED_DISTANCE",
    "BOARD_TURNOVER",
    "FORCED_PRE_SKILL_SWORD_CONSUMPTION",
    "MANDATORY_FALLBACK",
)


def _read_json(path: Path) -> Mapping[str, Any]:
    try:
        value = json.loads(path.read_text(encoding="utf-8"))
    except (OSError, json.JSONDecodeError) as exc:
        raise BenchmarkDataError(f"cannot read {path}: {exc}") from exc
    if not isinstance(value, Mapping):
        raise BenchmarkDataError(f"{path} must contain a JSON object")
    return value


def _read_jsonl(path: Path) -> list[Mapping[str, Any]]:
    rows: list[Mapping[str, Any]] = []
    try:
        with path.open("r", encoding="utf-8") as source:
            for line_number, raw in enumerate(source, 1):
                if not raw.strip():
                    continue
                value = json.loads(raw)
                if not isinstance(value, Mapping):
                    raise BenchmarkDataError(
                        f"{path}:{line_number} must contain a JSON object"
                    )
                rows.append(value)
    except (OSError, json.JSONDecodeError) as exc:
        raise BenchmarkDataError(f"cannot read {path}: {exc}") from exc
    return rows


def _integer(value: Any, label: str) -> int:
    if isinstance(value, bool) or not isinstance(value, int) or value < 0:
        raise BenchmarkDataError(f"{label} must be a non-negative integer")
    return value


def _mapping(value: Any, label: str) -> Mapping[str, Any]:
    if not isinstance(value, Mapping):
        raise BenchmarkDataError(f"{label} must be an object")
    return value


def _text(value: Any, label: str) -> str:
    if not isinstance(value, str) or not value.strip():
        raise BenchmarkDataError(f"{label} must be non-empty text")
    return value.strip()


def _validate_manifest_policy_spec(
    spec: Mapping[str, Any],
    *,
    phase: str,
    label: str,
) -> None:
    """Require the final R1 threshold contract in every skill-rush run spec."""

    if phase == MODE_A:
        return
    if spec.get("pet_skill_fire_condition") != PetSkillFireCondition.SWORD_COUNT.value:
        raise BenchmarkDataError(f"{label} must record SWORD_COUNT fire condition")
    threshold = _integer(
        spec.get("pet_skill_fire_value"),
        f"{label}.pet_skill_fire_value",
    )
    if threshold != R1_SWORD_THRESHOLD:
        raise BenchmarkDataError(
            f"{label} must record Sword threshold {R1_SWORD_THRESHOLD}"
        )
    if spec.get("pet_skill_fire_semantics") != (
        "known_gem_effective_count >= pet_skill_fire_value"
    ):
        raise BenchmarkDataError(
            f"{label} must record inclusive multiplier-weighted semantics"
        )


def _operator_accepted_attempts(
    spec: Mapping[str, Any],
    *,
    phase: str,
    label: str,
) -> dict[int, dict[str, str]]:
    """Parse the one explicit historical completion accepted by the user."""

    raw = spec.get("operator_accepted_completions", ())
    if not isinstance(raw, Sequence) or isinstance(raw, (str, bytes)):
        raise BenchmarkDataError(
            f"{label}.operator_accepted_completions must be a list"
        )
    if raw and phase != R1_REMEDIATION:
        raise BenchmarkDataError(
            "operator-accepted completions are allowed only for historical R1"
        )
    parsed: dict[int, dict[str, str]] = {}
    for index, item in enumerate(raw):
        row = _mapping(item, f"{label}.operator_accepted_completions[{index}]")
        attempt_index = _integer(
            row.get("attempt_index"),
            f"{label}.operator_accepted_completions[{index}].attempt_index",
        )
        if attempt_index <= 0 or attempt_index in parsed:
            raise BenchmarkDataError(
                f"{label} has an invalid operator-accepted attempt index"
            )
        parsed[attempt_index] = {
            "end_timestamp": _text(
                row.get("end_timestamp"),
                f"{label}.operator_accepted_completions[{index}].end_timestamp",
            ),
            "reason": _text(
                row.get("reason"),
                f"{label}.operator_accepted_completions[{index}].reason",
            ),
        }
    return parsed


def _fire_condition_valid(record: Mapping[str, Any]) -> bool:
    trigger = record.get("fireTrigger")
    condition = record.get(
        "petSkillFireCondition", PetSkillFireCondition.SWORD_COUNT.value
    )
    # New telemetry separates physical cells from multiplier-weighted value.
    # Historical accepted R1 logs lack the effective field; x1 physical counts
    # remain readable as a compatibility fallback and are never rewritten.
    sword = record.get(
        "selectedKnownGemEffectiveCount",
        record.get(
            "knownSwordEffectiveCount",
            record.get("selectedKnownGemCount", record.get("knownSwordCount")),
        ),
    )
    threshold = record.get(
        "petSkillFireValue", record.get("configuredSwordThreshold")
    )
    if (
        isinstance(threshold, bool)
        or not isinstance(threshold, int)
        or not PET_SKILL_FIRE_VALUE_MINIMUM
        <= threshold
        <= PET_SKILL_FIRE_VALUE_MAXIMUM
    ):
        return False
    resources_ready = record.get("resourcesReady") is True
    requirements = (
        (record.get("currentMana"), record.get("requiredMana")),
        (record.get("currentRage"), record.get("requiredRage")),
    )
    resources_proven = all(
        isinstance(current, int)
        and not isinstance(current, bool)
        and isinstance(required, int)
        and not isinstance(required, bool)
        and current >= required
        for current, required in requirements
    )
    return bool(
        trigger
        in {
            "SKILL_RUSH_FIRE_CONDITION_READY",
            "SKILL_RUSH_SWORD_THRESHOLD_READY",
        }
        and condition == PetSkillFireCondition.SWORD_COUNT.value
        and resources_ready
        and resources_proven
        and isinstance(sword, int)
        and not isinstance(sword, bool)
        and sword >= threshold
        and record.get(
            "selectedFireConditionReady",
            record.get("swordThresholdReady"),
        )
        is True
    )


def audit_setup_records(
    records: Sequence[Mapping[str, Any]],
    *,
    label: str,
) -> dict[str, Any]:
    """Audit one combat log's R1 setup telemetry and fire authorization."""

    setup = [
        row
        for row in records
        if row.get("event") in {"skill_rush_setup_blocked", "skill_rush_setup_relaxed"}
    ]
    summaries = [row for row in records if row.get("event") == "auto_controller_summary"]
    if len(summaries) != 1:
        raise BenchmarkDataError(f"{label} requires exactly one controller summary")
    summary = summaries[0]
    blocked_summary = _integer(
        summary.get("skillRushSetupBlockedStates"),
        f"{label}.skillRushSetupBlockedStates",
    )
    relaxed_summary = _integer(
        summary.get("skillRushSetupRelaxedActions"),
        f"{label}.skillRushSetupRelaxedActions",
    )
    premature_summary = _integer(
        summary.get("skillRushPrematureBlockedSkills"),
        f"{label}.skillRushPrematureBlockedSkills",
    )
    fallback_summary = _mapping(
        summary.get("skillRushSetupFallbacks"),
        f"{label}.skillRushSetupFallbacks",
    )
    fire_summary = _mapping(
        summary.get("skillRushFireReasons"),
        f"{label}.skillRushFireReasons",
    )
    if _integer(fire_summary.get("SETUP_BLOCKED"), f"{label}.SETUP_BLOCKED") != 0:
        raise BenchmarkDataError(f"{label} contains a legacy SETUP_BLOCKED skill fire")
    if premature_summary != 0:
        raise BenchmarkDataError(f"{label} contains a premature blocked skill")
    configured_condition = summary.get(
        "petSkillFireCondition", PetSkillFireCondition.SWORD_COUNT.value
    )
    if configured_condition != PetSkillFireCondition.SWORD_COUNT.value:
        raise BenchmarkDataError(f"{label} must use SWORD_COUNT")
    configured_threshold = _integer(
        summary.get("petSkillFireValue", summary.get("skillRushSwordThreshold")),
        f"{label}.petSkillFireValue",
    )
    if configured_threshold != R1_SWORD_THRESHOLD:
        raise BenchmarkDataError(
            f"{label} must use R1 Sword threshold {R1_SWORD_THRESHOLD}"
        )
    intentional_consumptions = _integer(
        summary.get("skillRushIntentionalPreSkillSwordConsumptions"),
        f"{label}.skillRushIntentionalPreSkillSwordConsumptions",
    )
    forced_consumptions = _integer(
        summary.get("skillRushForcedPreSkillSwordConsumptions"),
        f"{label}.skillRushForcedPreSkillSwordConsumptions",
    )
    if intentional_consumptions != 0:
        raise BenchmarkDataError(
            f"{label} contains intentional pre-skill Sword consumption"
        )

    fallback_counts: Counter[str] = Counter()
    normalized: list[dict[str, Any]] = []
    relaxed_events = 0
    for index, row in enumerate(setup):
        event_label = f"{label}.setup[{index}]"
        preferred = _integer(
            row.get("preferredCandidateCount"),
            f"{event_label}.preferredCandidateCount",
        )
        relaxed = _integer(
            row.get("relaxedCandidateCount"),
            f"{event_label}.relaxedCandidateCount",
        )
        if preferred != 0:
            raise BenchmarkDataError(f"{event_label} is not actually setup-blocked")
        if row.get("fireTrigger") is not None:
            raise BenchmarkDataError(f"{event_label} retained a skill-fire trigger")
        if row.get("event") == "skill_rush_setup_blocked":
            if str(row.get("selectedAction")) != "pass":
                raise BenchmarkDataError(
                    f"{event_label} blocked setup did not select authoritative PASS"
                )
            if row.get("setupFallbackType") is not None:
                raise BenchmarkDataError(
                    f"{event_label} PASS unexpectedly records a SWAP fallback"
                )
            normalized.append(
                {
                    "match_id": row.get("matchId"),
                    "turn": row.get("sourceTurn"),
                    "boss_hp": row.get("bossHp"),
                    "boss_max_hp": row.get("bossMaxHp"),
                    "boss_hp_ratio": row.get("bossHpRatio"),
                    "known_sword_count": row.get("knownSwordCount"),
                    "known_sword_effective_count": row.get(
                        "knownSwordEffectiveCount", row.get("knownSwordCount")
                    ),
                    "current_mana": row.get("currentMana"),
                    "current_rage": row.get("currentRage"),
                    "required_mana": row.get("requiredMana"),
                    "required_rage": row.get("requiredRage"),
                    "preferred_candidate_count": preferred,
                    "relaxed_candidate_count": relaxed,
                    "minimum_available_sword_distance": row.get(
                        "minimumAvailableSwordDistance"
                    ),
                    "sword_consumed": 0,
                    "sword_preserved": None,
                    "sparse_turnover_reason": None,
                    "sparse_turnover_score": None,
                    "fallback_type": None,
                    "selected_move": None,
                    "selected_action": "pass",
                }
            )
            continue
        relaxed_events += 1
        fallback = _text(row.get("setupFallbackType"), f"{event_label}.fallback")
        if fallback not in SETUP_FALLBACK_TYPES:
            raise BenchmarkDataError(f"{event_label} has unsupported fallback {fallback}")
        if str(row.get("selectedAction")) != "swap":
            raise BenchmarkDataError(f"{event_label} did not select a board SWAP")
        consumed = _integer(
            row.get("knownSwordConsumed"),
            f"{event_label}.knownSwordConsumed",
        )
        if fallback == "FORCED_PRE_SKILL_SWORD_CONSUMPTION":
            if consumed == 0:
                raise BenchmarkDataError(
                    f"{event_label} forced Sword fallback consumed no Sword"
                )
        elif consumed != 0:
            raise BenchmarkDataError(
                f"{event_label} consumed Sword without the forced fallback"
            )
        fallback_counts[fallback] += 1
        normalized.append(
            {
                "match_id": row.get("matchId"),
                "turn": row.get("sourceTurn"),
                "boss_hp": row.get("bossHp"),
                "boss_max_hp": row.get("bossMaxHp"),
                "boss_hp_ratio": row.get("bossHpRatio"),
                "known_sword_count": row.get("knownSwordCount"),
                "known_sword_effective_count": row.get(
                    "knownSwordEffectiveCount", row.get("knownSwordCount")
                ),
                "current_mana": row.get("currentMana"),
                "current_rage": row.get("currentRage"),
                "required_mana": row.get("requiredMana"),
                "required_rage": row.get("requiredRage"),
                "preferred_candidate_count": preferred,
                "relaxed_candidate_count": relaxed,
                "minimum_available_sword_distance": row.get(
                    "minimumAvailableSwordDistance"
                ),
                "sword_consumed": consumed,
                "sword_preserved": row.get("knownSwordPreserved"),
                "sparse_turnover_reason": row.get("sparseTurnoverReason"),
                "sparse_turnover_score": row.get("sparseTurnoverScore"),
                "fallback_type": fallback,
                "selected_move": row.get("selectedMove"),
                "selected_action": "swap",
            }
        )

    if blocked_summary != len(setup) or relaxed_summary != relaxed_events:
        raise BenchmarkDataError(f"{label} setup event/summary accounting differs")
    for fallback in SETUP_FALLBACK_TYPES:
        recorded = _integer(
            fallback_summary.get(fallback),
            f"{label}.skillRushSetupFallbacks.{fallback}",
        )
        if recorded != fallback_counts[fallback]:
            raise BenchmarkDataError(f"{label} {fallback} accounting differs")
    if (
        forced_consumptions
        != fallback_counts["FORCED_PRE_SKILL_SWORD_CONSUMPTION"]
    ):
        raise BenchmarkDataError(f"{label} forced Sword accounting differs")

    skill_fires = [
        row for row in records if row.get("event") == "pet_skill_action_proposed"
    ]
    for index, fire in enumerate(skill_fires):
        if not _fire_condition_valid(fire):
            raise BenchmarkDataError(
                f"{label}.skillFire[{index}] lacks an authoritative R1 fire condition"
            )
        if not isinstance(fire.get("firstSkillUsedThisMatch"), bool):
            raise BenchmarkDataError(
                f"{label}.skillFire[{index}] lacks current-match skill history"
            )
    fire_key = (
        "SKILL_RUSH_FIRE_CONDITION_READY"
        if "SKILL_RUSH_FIRE_CONDITION_READY" in fire_summary
        else "SKILL_RUSH_SWORD_THRESHOLD_READY"
    )
    threshold_fires = _integer(
        fire_summary.get(fire_key),
        f"{label}.{fire_key}",
    )
    if threshold_fires != len(skill_fires):
        raise BenchmarkDataError(f"{label} skill fire/summary accounting differs")
    fire_sword_cells = [
        int(row.get("knownSwordCellCount", row["knownSwordCount"]))
        for row in skill_fires
        if row.get("firstSkillUsedThisMatch") is False
    ]
    fire_sword_effective = [
        int(row.get("knownSwordEffectiveCount", row["knownSwordCount"]))
        for row in skill_fires
        if row.get("firstSkillUsedThisMatch") is False
    ]
    return {
        "setup_blocked": len(setup),
        "false_fire_condition_blocked_states": len(setup),
        "premature_skills": 0,
        "fallback_counts": {
            name: fallback_counts[name] for name in SETUP_FALLBACK_TYPES
        },
        "records": normalized,
        "skill_fires": len(skill_fires),
        "skill_fire_sword_counts": fire_sword_effective,
        "skill_fire_sword_cell_counts": fire_sword_cells,
        "skill_fire_sword_effective_counts": fire_sword_effective,
        "configured_sword_threshold": configured_threshold,
        "forced_pre_skill_sword_consumptions": forced_consumptions,
        "intentional_pre_skill_sword_consumptions": intentional_consumptions,
    }


def audit_setup_run(run_directory: Path) -> dict[str, Any]:
    raw = _read_json(run_directory / "run.json")
    snapshot = _mapping(raw.get("snapshot"), f"{run_directory}.snapshot")
    attempts = snapshot.get("attempts")
    if not isinstance(attempts, Sequence) or isinstance(attempts, (str, bytes)):
        raise BenchmarkDataError(f"{run_directory}.attempts must be a list")
    audits = []
    for attempt in attempts:
        attempt_map = _mapping(attempt, f"{run_directory}.attempt")
        index = _integer(attempt_map.get("attempt_index"), "attempt_index")
        path = run_directory / "matches" / f"attempt_{index:03d}" / "combat.jsonl"
        audits.append(audit_setup_records(_read_jsonl(path), label=str(path)))
    counts: Counter[str] = Counter()
    records: list[dict[str, Any]] = []
    fire_sword_cells: list[int] = []
    fire_sword_effective: list[int] = []
    for audit in audits:
        counts.update(audit["fallback_counts"])
        records.extend(audit["records"])
        fire_sword_cells.extend(audit["skill_fire_sword_cell_counts"])
        fire_sword_effective.extend(audit["skill_fire_sword_effective_counts"])
    return {
        "setup_blocked": sum(item["setup_blocked"] for item in audits),
        "false_fire_condition_blocked_states": sum(
            item["false_fire_condition_blocked_states"] for item in audits
        ),
        "premature_skills": sum(item["premature_skills"] for item in audits),
        "fallback_counts": {name: counts[name] for name in SETUP_FALLBACK_TYPES},
        "records": records,
        "skill_fires": sum(item["skill_fires"] for item in audits),
        "skill_fire_sword_counts": fire_sword_effective,
        "skill_fire_sword_cell_counts": fire_sword_cells,
        "skill_fire_sword_effective_counts": fire_sword_effective,
        "forced_pre_skill_sword_consumptions": sum(
            item["forced_pre_skill_sword_consumptions"] for item in audits
        ),
        "intentional_pre_skill_sword_consumptions": sum(
            item["intentional_pre_skill_sword_consumptions"] for item in audits
        ),
    }


def _validate_finished_run(run: Mapping[str, Any], *, label: str) -> None:
    if run.get("state") != "FARM_RUN_COMPLETE":
        raise BenchmarkDataError(f"{label} did not finish FARM_RUN_COMPLETE")
    if run.get("stop_reason") != "FARM_TARGET_COMPLETED":
        raise BenchmarkDataError(f"{label} did not stop at its exact target")
    if run.get("completed") != run.get("target_completed_matches"):
        raise BenchmarkDataError(f"{label} target boundary is inconsistent")


def _validate_summary(
    phase: str,
    summary: Mapping[str, Any],
    *,
    expected_completed: int,
    allowed_operator_accepted_unknown: int = 0,
) -> None:
    if summary.get("n") != expected_completed:
        raise BenchmarkDataError(
            f"{phase} requires exactly {expected_completed} completed matches"
        )
    if summary.get("critical_safety_violations") != 0:
        raise BenchmarkDataError(f"{phase} contains technical safety violations")
    if summary.get("unknown") != allowed_operator_accepted_unknown:
        raise BenchmarkDataError(f"{phase} contains unapproved UNKNOWN results")
    if phase == MODE_A:
        if summary.get("pet_skill_accepted") != 0:
            raise BenchmarkDataError("Mode A contains Pet Skill input")
        if summary.get("skill_rush_branch_leakage") != 0:
            raise BenchmarkDataError("Mode A contains SKILL_RUSH leakage")
        return
    accepted = _integer(summary.get("pet_skill_accepted"), f"{phase}.petSkill")
    perfect = _integer(summary.get("pet_skill_perfect"), f"{phase}.perfect")
    if accepted < expected_completed or accepted != perfect:
        raise BenchmarkDataError(f"{phase} requires every accepted Pet Skill PERFECT")
    if summary.get("evolve", {}).get("total") != 0:
        raise BenchmarkDataError(f"{phase} contains EVOLVE")
    if summary.get("ordinary_attack_before_first_skill") != 0:
        raise BenchmarkDataError(f"{phase} contains a pre-first-skill Attack")


def analyze_manifest(manifest_path: Path, logs_root: Path) -> dict[str, Any]:
    manifest = _read_json(manifest_path)
    if manifest.get("schema") != MANIFEST_SCHEMA:
        raise BenchmarkDataError("unsupported Phase 3D.1-R1 manifest schema")
    source_commit = _text(manifest.get("source_commit"), "manifest.source_commit")
    app_version = _text(manifest.get("app_version"), "manifest.app_version")
    expected_boss = _mapping(manifest.get("expected_boss"), "manifest.expected_boss")
    _text(expected_boss.get("boss_id"), "manifest.expected_boss.boss_id")
    _text(expected_boss.get("boss_name"), "manifest.expected_boss.boss_name")
    specs = manifest.get("runs")
    if not isinstance(specs, Sequence) or isinstance(specs, (str, bytes)):
        raise BenchmarkDataError("manifest.runs must be a list")
    execution_order = manifest.get("execution_order")
    if not isinstance(execution_order, Sequence) or isinstance(
        execution_order, (str, bytes)
    ):
        raise BenchmarkDataError("manifest.execution_order must be a list")
    run_ids = [
        _text(_mapping(spec, f"manifest.runs[{index}]").get("farm_run_id"), "farm_run_id")
        for index, spec in enumerate(specs)
    ]
    if list(execution_order) != run_ids or len(set(run_ids)) != len(run_ids):
        raise BenchmarkDataError("execution_order must list every unique run once")
    phases = [
        _text(_mapping(spec, f"manifest.runs[{index}]").get("phase"), "phase")
        for index, spec in enumerate(specs)
    ]
    collapsed = tuple(dict.fromkeys(phases))
    if collapsed != PHASE_ORDER[: len(collapsed)] or any(
        phase not in PHASE_ORDER for phase in phases
    ):
        raise BenchmarkDataError("run phases must follow R1, A, then B")

    runs_by_phase: dict[str, list[dict[str, Any]]] = {phase: [] for phase in PHASE_ORDER}
    operator_acceptances_by_phase: Counter[str] = Counter()
    setup_by_phase: dict[str, list[dict[str, Any]]] = {
        R1_REMEDIATION: [],
        MODE_B: [],
    }
    for index, raw_spec in enumerate(specs):
        spec = _mapping(raw_spec, f"manifest.runs[{index}]")
        if spec.get("excluded"):
            raise BenchmarkDataError("R1 benchmark does not discard or exclude runs")
        phase = phases[index]
        _validate_manifest_policy_spec(
            spec,
            phase=phase,
            label=f"manifest.runs[{index}]",
        )
        accepted_attempts = _operator_accepted_attempts(
            spec,
            phase=phase,
            label=f"manifest.runs[{index}]",
        )
        mode = MODE_A if phase == MODE_A else MODE_B
        run_dir = logs_root / run_ids[index]
        run = extract_run(
            run_dir,
            mode=mode,
            expected_boss=expected_boss,
            operator_accepted_attempts=accepted_attempts,
        )
        _validate_finished_run(run, label=run_ids[index])
        runs_by_phase[phase].append(run)
        operator_acceptances_by_phase[phase] += len(accepted_attempts)
        if phase in setup_by_phase:
            setup_by_phase[phase].append(audit_setup_run(run_dir))

    summaries: dict[str, Any] = {}
    expected_counts = {R1_REMEDIATION: 5, MODE_A: 10, MODE_B: 10}
    for phase in PHASE_ORDER:
        phase_runs = runs_by_phase[phase]
        if not phase_runs:
            continue
        mode = MODE_A if phase == MODE_A else MODE_B
        summary = summarize_mode(mode, phase_runs)
        summary["phase"] = phase
        summary["operator_accepted_completions"] = operator_acceptances_by_phase[
            phase
        ]
        if phase != MODE_A:
            for obsolete in (
                "hp_prep_reached_at_first_skill",
                "sword_density_reached_at_first_skill",
                "early_boss_prep_sword",
            ):
                summary.pop(obsolete, None)
        _validate_summary(
            phase,
            summary,
            expected_completed=expected_counts[phase],
            allowed_operator_accepted_unknown=operator_acceptances_by_phase[
                phase
            ],
        )
        summaries[phase] = summary

    setup_audits: dict[str, Any] = {}
    for phase, audits in setup_by_phase.items():
        if not audits:
            continue
        counts: Counter[str] = Counter()
        records: list[dict[str, Any]] = []
        fire_sword_cells: list[int] = []
        fire_sword_effective: list[int] = []
        for audit in audits:
            counts.update(audit["fallback_counts"])
            records.extend(audit["records"])
            fire_sword_cells.extend(audit["skill_fire_sword_cell_counts"])
            fire_sword_effective.extend(
                audit["skill_fire_sword_effective_counts"]
            )
        setup_audits[phase] = {
            "setup_blocked": sum(item["setup_blocked"] for item in audits),
            "false_fire_condition_blocked_states": sum(
                item["false_fire_condition_blocked_states"] for item in audits
            ),
            "premature_skills": sum(item["premature_skills"] for item in audits),
            "fallback_counts": {name: counts[name] for name in SETUP_FALLBACK_TYPES},
            "records": records,
            "pet_skill_fire_condition": PetSkillFireCondition.SWORD_COUNT.value,
            "pet_skill_fire_value": R1_SWORD_THRESHOLD,
            "configured_sword_threshold": R1_SWORD_THRESHOLD,
            "inclusive_semantics": (
                "known_gem_effective_count >= pet_skill_fire_value"
            ),
            "skill_fire_sword_counts": fire_sword_effective,
            "skill_fire_sword_cell_counts": fire_sword_cells,
            "skill_fire_sword_effective_counts": fire_sword_effective,
            "first_skill_sword_count": {
                "mean": (
                    round(mean(fire_sword_effective), 3)
                    if fire_sword_effective
                    else None
                ),
                "median": (
                    round(median(fire_sword_effective), 3)
                    if fire_sword_effective
                    else None
                ),
                "min": min(fire_sword_effective) if fire_sword_effective else None,
                "max": max(fire_sword_effective) if fire_sword_effective else None,
            },
            "forced_pre_skill_sword_consumptions": sum(
                item["forced_pre_skill_sword_consumptions"] for item in audits
            ),
            "intentional_pre_skill_sword_consumptions": sum(
                item["intentional_pre_skill_sword_consumptions"] for item in audits
            ),
        }

    complete = all(phase in summaries for phase in PHASE_ORDER)
    comparison = (
        _comparison(summaries[MODE_A], summaries[MODE_B]) if complete else None
    )
    all_rows = [
        row
        for phase in PHASE_ORDER
        for run in runs_by_phase[phase]
        for row in run.get("rows", ())
    ]
    return {
        "schema": DATASET_SCHEMA,
        "analyzer_version": ANALYZER_VERSION,
        "source_commit": source_commit,
        "app_version": app_version,
        "boss": dict(expected_boss),
        "execution_order": list(execution_order),
        "historical_pre_remediation": {
            "commit": "37c922ec2812d8082fa7748219ffffbe2326af06",
            "mode_b_mean_combat_s": 127.056,
            "mode_b_combat_reduction_pct": 43.233,
            "pooled_with_refresh": False,
        },
        "policy": {
            "pet_skill_fire_condition": PetSkillFireCondition.SWORD_COUNT.value,
            "pet_skill_fire_value": R1_SWORD_THRESHOLD,
            "inclusive_semantics": (
                "known_gem_effective_count >= pet_skill_fire_value"
            ),
            "pre_first_skill_boss_hp_authorizes_skill": False,
            "setup_blocked_authorizes_skill": False,
            "post_skill_finisher_ratio_inclusive_at_or_below": 0.30,
        },
        "runs": {phase: runs_by_phase[phase] for phase in PHASE_ORDER},
        "matches": all_rows,
        "summaries": summaries,
        "setup_audits": setup_audits,
        "comparison": comparison,
        "validation": {
            "stage": "COMPLETE" if complete else collapsed[-1] if collapsed else "EMPTY",
            "complete": complete,
            "result_accounting_consistent": all(
                summary["wins"] + summary["losses"] + summary["unknown"]
                == summary["n"]
                for summary in summaries.values()
            ),
            "critical_safety_violations": sum(
                summary["critical_safety_violations"]
                for summary in summaries.values()
            ),
            "premature_blocked_skills": sum(
                audit["premature_skills"] for audit in setup_audits.values()
            ),
            "intentional_pre_skill_sword_consumptions": sum(
                audit["intentional_pre_skill_sword_consumptions"]
                for audit in setup_audits.values()
            ),
            "exact_target_boundaries": True,
            "energy": "NOT_MEASURED",
        },
    }


def write_json(path: Path, payload: Mapping[str, Any]) -> None:
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(
        json.dumps(payload, ensure_ascii=False, indent=2) + "\n",
        encoding="utf-8",
    )


def render_markdown_summary(analysis: Mapping[str, Any]) -> str:
    lines = [
        "# Phase 3D.1-R1 analysis",
        "",
        f"- Source: `{analysis['source_commit']}` / `{analysis['app_version']}`",
        f"- Stage: `{analysis['validation']['stage']}`",
        f"- Energy: `{analysis['validation']['energy']}`",
        "",
    ]
    for phase in PHASE_ORDER:
        summary = analysis.get("summaries", {}).get(phase)
        if not summary:
            continue
        lines.extend(
            [
                f"## {phase}",
                "",
                f"- completed: {summary['n']}",
                f"- attempts: {summary['attempts']}",
                f"- W/L/U: {summary['wins']}/{summary['losses']}/{summary['unknown']}",
                f"- mean combat: {summary['combat_duration_s']['mean']} s",
                f"- mean cycle: {summary['farm_cycle_duration_s']['mean']} s",
                "",
            ]
        )
    for phase, audit in analysis.get("setup_audits", {}).items():
        lines.extend(
            [
                f"## {phase} setup audit",
                "",
                f"- SETUP_BLOCKED: {audit['setup_blocked']}",
                f"- premature skills: {audit['premature_skills']}",
                f"- Sword threshold: `>= {audit['configured_sword_threshold']}`",
                f"- first/second skill Sword counts: `{audit['first_skill_sword_count']}`",
                f"- forced pre-skill Sword consumption: {audit['forced_pre_skill_sword_consumptions']}",
                f"- intentional pre-skill Sword consumption: {audit['intentional_pre_skill_sword_consumptions']}",
                f"- fallbacks: `{json.dumps(audit['fallback_counts'], sort_keys=True)}`",
                "",
            ]
        )
    return "\n".join(lines).rstrip() + "\n"


__all__ = [
    "ANALYZER_VERSION",
    "DATASET_SCHEMA",
    "MANIFEST_SCHEMA",
    "PHASE_ORDER",
    "R1_REMEDIATION",
    "R1_SWORD_THRESHOLD",
    "SETUP_FALLBACK_TYPES",
    "_validate_manifest_policy_spec",
    "analyze_manifest",
    "audit_setup_records",
    "audit_setup_run",
    "render_markdown_summary",
    "write_json",
]
