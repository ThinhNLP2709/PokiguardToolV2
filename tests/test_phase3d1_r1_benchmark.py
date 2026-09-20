from __future__ import annotations

import unittest

from pokiguard_v2.phase3d1_benchmark import BenchmarkDataError
from pokiguard_v2.phase3d1_r1_benchmark import (
    MODE_B,
    R1_REMEDIATION,
    R1_SWORD_THRESHOLD,
    _operator_accepted_attempts,
    _validate_manifest_policy_spec,
    audit_setup_records,
    render_markdown_summary,
)


def summary(
    *,
    blocked: int = 1,
    relaxed: int = 1,
    premature: int = 0,
    legacy_fire: int = 0,
    threshold_fires: int = 0,
    fallback: str | None = "RELAXED_DISTANCE",
    forced: int = 0,
    intentional: int = 0,
) -> dict[str, object]:
    fallbacks = {
        "RELAXED_DISTANCE": 0,
        "BOARD_TURNOVER": 0,
        "FORCED_PRE_SKILL_SWORD_CONSUMPTION": 0,
        "MANDATORY_FALLBACK": 0,
    }
    if relaxed and fallback is not None:
        fallbacks[fallback] = relaxed
    return {
        "event": "auto_controller_summary",
        "petSkillFireCondition": "sword_count",
        "petSkillFireValue": 10,
        "skillRushSetupBlockedStates": blocked,
        "skillRushSetupRelaxedActions": relaxed,
        "skillRushPrematureBlockedSkills": premature,
        "skillRushSetupFallbacks": fallbacks,
        "skillRushForcedPreSkillSwordConsumptions": forced,
        "skillRushIntentionalPreSkillSwordConsumptions": intentional,
        "skillRushFireReasons": {
            "SKILL_RUSH_FIRE_CONDITION_READY": threshold_fires,
            "SETUP_BLOCKED": legacy_fire,
        },
    }


def relaxed_event(
    *,
    fallback: str = "RELAXED_DISTANCE",
    consumed: int = 0,
) -> dict[str, object]:
    return {
        "event": "skill_rush_setup_relaxed",
        "matchId": "M_fixture",
        "sourceTurn": 15,
        "bossHp": 69_276,
        "bossMaxHp": 84_180,
        "bossHpRatio": 69_276 / 84_180,
        "knownSwordCount": 4,
        "configuredSwordThreshold": 10,
        "swordThresholdReady": False,
        "resourcesReady": True,
        "firstSkillUsedThisMatch": False,
        "currentMana": 270,
        "currentRage": 250,
        "requiredMana": 200,
        "requiredRage": 200,
        "preferredCandidateCount": 0,
        "relaxedCandidateCount": 1,
        "minimumAvailableSwordDistance": 1,
        "swordConsumedByRelaxedMove": consumed,
        "knownSwordConsumed": consumed,
        "knownSwordPreserved": 4 - consumed,
        "sparseTurnoverReason": fallback,
        "setupFallbackType": fallback,
        "selectedAction": "swap",
        "selectedMove": {"first": [3, 3], "second": [3, 4]},
        "fireTrigger": None,
    }


def setup_pass_event() -> dict[str, object]:
    return {
        **relaxed_event(),
        "event": "skill_rush_setup_blocked",
        "setupFallbackType": None,
        "sparseTurnoverReason": None,
        "knownSwordConsumed": None,
        "knownSwordPreserved": None,
        "selectedAction": "pass",
        "selectedMove": None,
    }


def fire_event(
    *,
    swords: int = 11,
    effective_swords: int | None = None,
    threshold: int = 10,
) -> dict[str, object]:
    effective = swords if effective_swords is None else effective_swords
    return {
        "event": "pet_skill_action_proposed",
        "fireTrigger": "SKILL_RUSH_FIRE_CONDITION_READY",
        "bossHpRatio": 0.99,
        "knownSwordCount": swords,
        "knownSwordCellCount": swords,
        "knownSwordEffectiveCount": effective,
        "petSkillFireCondition": "sword_count",
        "petSkillFireValue": threshold,
        "selectedFireGemType": "sword",
        "selectedKnownGemCount": swords,
        "selectedKnownGemCellCount": swords,
        "selectedKnownGemEffectiveCount": effective,
        "selectedFireConditionReady": effective >= threshold,
        "resourcesReady": True,
        "firstSkillUsedThisMatch": False,
        "currentMana": 250,
        "requiredMana": 200,
        "currentRage": 225,
        "requiredRage": 200,
    }


class Phase3D1R1BenchmarkTests(unittest.TestCase):
    def test_markdown_renders_inclusive_threshold(self) -> None:
        rendered = render_markdown_summary(
            {
                "source_commit": "abc",
                "app_version": "v1",
                "validation": {
                    "stage": "COMPLETE",
                    "energy": "NOT_MEASURED",
                },
                "summaries": {},
                "setup_audits": {
                    MODE_B: {
                        "setup_blocked": 0,
                        "premature_skills": 0,
                        "configured_sword_threshold": 10,
                        "first_skill_sword_count": {},
                        "forced_pre_skill_sword_consumptions": 0,
                        "intentional_pre_skill_sword_consumptions": 0,
                        "fallback_counts": {},
                    }
                },
            }
        )
        self.assertIn("Sword threshold: `>= 10`", rendered)

    def test_operator_accepted_completion_is_explicit_and_historical_only(self) -> None:
        spec = {
            "operator_accepted_completions": [
                {
                    "attempt_index": 5,
                    "end_timestamp": "2026-09-17T10:10:32.279Z",
                    "reason": "User explicitly accepted the completed combat.",
                }
            ]
        }
        parsed = _operator_accepted_attempts(
            spec,
            phase=R1_REMEDIATION,
            label="run",
        )
        self.assertEqual(parsed[5]["end_timestamp"], "2026-09-17T10:10:32.279Z")

        with self.assertRaisesRegex(BenchmarkDataError, "historical R1"):
            _operator_accepted_attempts(spec, phase=MODE_B, label="run")

    def test_manifest_records_threshold_and_inclusive_semantics(self) -> None:
        valid = {
            "pet_skill_fire_condition": "sword_count",
            "pet_skill_fire_value": 10,
            "pet_skill_fire_semantics": (
                "known_gem_effective_count >= pet_skill_fire_value"
            ),
        }
        _validate_manifest_policy_spec(valid, phase="B_PET_SKILL", label="run")
        _validate_manifest_policy_spec({}, phase="A_DEFAULT", label="run")
        for invalid in (
            {**valid, "pet_skill_fire_value": 11},
            {**valid, "pet_skill_fire_semantics": "known_gem_count >= pet_skill_fire_value"},
            {},
        ):
            with self.subTest(invalid=invalid):
                with self.assertRaises(BenchmarkDataError):
                    _validate_manifest_policy_spec(
                        invalid,
                        phase="B_PET_SKILL",
                        label="run",
                    )

    def test_exact_blocked_fixture_is_recorded_as_relaxed_not_skill(self) -> None:
        audit = audit_setup_records([relaxed_event(), summary()], label="fixture")
        self.assertEqual(audit["setup_blocked"], 1)
        self.assertEqual(audit["premature_skills"], 0)
        self.assertEqual(audit["fallback_counts"]["RELAXED_DISTANCE"], 1)
        self.assertEqual(audit["records"][0]["known_sword_count"], 4)

    def test_setup_blocked_authoritative_pass_is_audited_without_swap_fallback(self) -> None:
        audit = audit_setup_records(
            [
                setup_pass_event(),
                summary(blocked=1, relaxed=0, fallback=None),
            ],
            label="fixture",
        )
        self.assertEqual(audit["setup_blocked"], 1)
        self.assertEqual(audit["records"][0]["selected_action"], "pass")
        self.assertIsNone(audit["records"][0]["fallback_type"])

    def test_legacy_setup_blocked_fire_is_rejected(self) -> None:
        with self.assertRaisesRegex(BenchmarkDataError, "legacy SETUP_BLOCKED"):
            audit_setup_records(
                [relaxed_event(), summary(legacy_fire=1)], label="fixture"
            )

    def test_inclusive_threshold_accepts_equal_boundary_and_rejects_hp_shortcut(self) -> None:
        audit = audit_setup_records(
            [fire_event(swords=10), summary(blocked=0, relaxed=0, threshold_fires=1)],
            label="fixture",
        )
        self.assertEqual(audit["skill_fire_sword_counts"], [10])

        for fire in ({**fire_event(swords=4), "fireTrigger": "HP_PREP"},):
            with self.subTest(fire=fire):
                with self.assertRaisesRegex(BenchmarkDataError, "authoritative"):
                    audit_setup_records(
                        [fire, summary(blocked=0, relaxed=0, threshold_fires=1)],
                        label="fixture",
                    )

    def test_more_than_configured_threshold_with_resources_remains_valid(self) -> None:
        audit = audit_setup_records(
            [fire_event(swords=11), summary(blocked=0, relaxed=0, threshold_fires=1)],
            label="fixture",
        )
        self.assertEqual(R1_SWORD_THRESHOLD, 10)
        self.assertEqual(audit["skill_fires"], 1)
        self.assertEqual(audit["skill_fire_sword_counts"], [11])

    def test_multiplier_weighted_threshold_accepts_nine_cells_twelve_effective(self) -> None:
        audit = audit_setup_records(
            [
                fire_event(swords=9, effective_swords=12),
                summary(blocked=0, relaxed=0, threshold_fires=1),
            ],
            label="fixture",
        )

        self.assertEqual(audit["skill_fire_sword_cell_counts"], [9])
        self.assertEqual(audit["skill_fire_sword_effective_counts"], [12])
        self.assertEqual(audit["skill_fire_sword_counts"], [12])

    def test_accepted_r1_legacy_telemetry_remains_equivalent(self) -> None:
        fire = {
            **fire_event(swords=11),
            "fireTrigger": "SKILL_RUSH_SWORD_THRESHOLD_READY",
            "configuredSwordThreshold": 10,
            "swordThresholdReady": True,
        }
        for field in (
            "petSkillFireCondition",
            "petSkillFireValue",
            "selectedFireGemType",
            "selectedKnownGemCount",
            "selectedKnownGemCellCount",
            "selectedKnownGemEffectiveCount",
            "selectedFireConditionReady",
            "knownSwordCellCount",
            "knownSwordEffectiveCount",
        ):
            fire.pop(field)
        legacy_summary = summary(blocked=0, relaxed=0, threshold_fires=1)
        legacy_summary["skillRushFireReasons"] = {
            "SKILL_RUSH_SWORD_THRESHOLD_READY": 1,
            "SETUP_BLOCKED": 0,
        }
        legacy_summary.pop("petSkillFireCondition")
        legacy_summary.pop("petSkillFireValue")
        legacy_summary["skillRushSwordThreshold"] = 10

        audit = audit_setup_records([fire, legacy_summary], label="accepted-r1")

        self.assertEqual(audit["skill_fires"], 1)
        self.assertEqual(audit["skill_fire_sword_counts"], [11])

    def test_resources_are_required_even_above_threshold(self) -> None:
        fire = {**fire_event(), "resourcesReady": False}
        with self.assertRaisesRegex(BenchmarkDataError, "authoritative"):
            audit_setup_records(
                [fire, summary(blocked=0, relaxed=0, threshold_fires=1)],
                label="fixture",
            )

    def test_forced_consumption_requires_explicit_reason_and_accounting(self) -> None:
        forced = relaxed_event(
            fallback="FORCED_PRE_SKILL_SWORD_CONSUMPTION", consumed=3
        )
        audit = audit_setup_records(
            [
                forced,
                summary(
                    fallback="FORCED_PRE_SKILL_SWORD_CONSUMPTION",
                    forced=1,
                ),
            ],
            label="fixture",
        )
        self.assertEqual(audit["forced_pre_skill_sword_consumptions"], 1)

    def test_nonforced_sword_consumption_and_intentional_counter_are_rejected(self) -> None:
        with self.assertRaisesRegex(BenchmarkDataError, "without the forced"):
            audit_setup_records(
                [relaxed_event(consumed=1), summary()], label="fixture"
            )
        with self.assertRaisesRegex(BenchmarkDataError, "intentional"):
            audit_setup_records(
                [relaxed_event(), summary(intentional=1)], label="fixture"
            )

    def test_setup_event_and_summary_must_match(self) -> None:
        with self.assertRaisesRegex(BenchmarkDataError, "accounting differs"):
            audit_setup_records(
                [relaxed_event(), summary(blocked=2, relaxed=2)],
                label="fixture",
            )


if __name__ == "__main__":
    unittest.main()
