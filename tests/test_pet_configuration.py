from __future__ import annotations

from dataclasses import asdict, fields, FrozenInstanceError, replace
import json
from pathlib import Path
import tempfile
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.basic_policy import BasicPolicyEngine, ManaPriority, PlayStyle, PolicyConfig
from pokiguard_v2.boss_entry import FarmTarget
from pokiguard_v2.desktop_control_plane import DesktopConfig, DesktopControlPlane, LatestCheckpointSummaryProvider
from pokiguard_v2.desktop_farm_controller import DesktopFarmControllerManager
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore, PREFERENCE_SCHEMA, LEGACY_PREFERENCE_SCHEMA
from pokiguard_v2.farm_checkpoint import (
    CHECKPOINT_SCHEMA, LEGACY_CHECKPOINT_SCHEMA, CheckpointError,
    load_checkpoint, write_checkpoint, validate_for_resume,
)
from pokiguard_v2.farm_run import FarmRun
from pokiguard_v2.pet_configuration import (
    MainPetType as Pet, EvolutionTarget as Evo, DamageCardMode as Damage,
    AuditionMode, SkillSource as Source, SkillSourceStatus as Status, GameplayConfig,
    PetSkillFireCondition,
    FarmPolicyUnavailable, loadout_capability, normalize_damage,
    basic_policy_config, legacy_pet_fields, legacy_basic_policy,
    gameplay_config_from_args, requires_attack_card_preparation,
)
from tests.test_basic_policy import combat_state, attack_card
from tests.test_desktop_farm_controller import _Runtime, _BlockingRunner
from tests.test_farm_checkpoint import _payload as historical_payload_fixture
from tools import farm_run, farm_cycle


PET_SKILL_PROFILE = GameplayConfig(
    main_pet=Pet.LEGENDARY,
    evolution=Evo.NONE,
    damage_card=Damage.PET_SKILL,
)
UNIMPLEMENTED_PET_SKILL_PROFILE = replace(
    PET_SKILL_PROFILE,
    evolution=Evo.NORMAL,
)
EVOLUTION_PET_SKILL_PROFILE = GameplayConfig(
    main_pet=Pet.NORMAL,
    evolution=Evo.LEGENDARY,
    damage_card=Damage.PET_SKILL,
)


def _payload(**kwargs):
    return historical_payload_fixture(**{"finalized": "STOPPED_GRACEFULLY", **kwargs})


def resume(payload, config=None):
    return validate_for_resume(payload, target_boss_id=payload.target_boss_id,
        target_boss_name=payload.target_boss_name, **payload.configured_limits,
        gameplay_config=config)


class PetConfigurationTests(unittest.TestCase):
    def test_skill_rush_threshold_default_range_and_mapping(self):
        self.assertIs(
            GameplayConfig().pet_skill_fire_condition,
            PetSkillFireCondition.SWORD_COUNT,
        )
        self.assertEqual(GameplayConfig().pet_skill_fire_value, 10)
        self.assertEqual(
            GameplayConfig.from_dict(GameplayConfig().to_dict()).pet_skill_fire_value,
            10,
        )
        raw = GameplayConfig().to_dict()
        del raw["pet_skill_fire_value"]
        self.assertEqual(GameplayConfig.from_dict(raw).pet_skill_fire_value, 10)
        configured = replace(PET_SKILL_PROFILE, pet_skill_fire_value=17)
        self.assertEqual(basic_policy_config(configured).pet_skill_fire_value, 17)
        for invalid in (-1, 257, True, 10.0, "10"):
            with self.subTest(invalid=invalid):
                with self.assertRaisesRegex(ValueError, "between 0 and 256"):
                    GameplayConfig(pet_skill_fire_value=invalid)

    def test_generic_fire_condition_migrates_old_sword_only_config(self):
        raw = PET_SKILL_PROFILE.to_dict()
        raw.pop("pet_skill_fire_condition")
        raw.pop("pet_skill_fire_value")
        raw["skill_rush_sword_threshold"] = 17
        migrated = GameplayConfig.from_dict(raw)
        self.assertIs(
            migrated.pet_skill_fire_condition,
            PetSkillFireCondition.SWORD_COUNT,
        )
        self.assertEqual(migrated.pet_skill_fire_value, 17)
        self.assertNotIn("skill_rush_sword_threshold", migrated.to_dict())

    def test_skill_cost_ready_has_no_numeric_value(self):
        config = replace(
            PET_SKILL_PROFILE,
            pet_skill_fire_condition=PetSkillFireCondition.SKILL_COST_READY,
            pet_skill_fire_value=None,
        )
        restored = GameplayConfig.from_dict(
            {**config.to_dict(), "pet_skill_fire_value": 42}
        )
        self.assertIs(
            restored.pet_skill_fire_condition,
            PetSkillFireCondition.SKILL_COST_READY,
        )
        self.assertIsNone(restored.pet_skill_fire_value)
        with self.assertRaisesRegex(ValueError, "must be None"):
            replace(config, pet_skill_fire_value=10)

    def test_stable_enum_values(self):
        self.assertEqual([v.value for v in Pet], ["normal", "legendary", "evolved", "mega"])
        self.assertEqual([v.value for v in Evo], ["none", "normal", "legendary", "evolved", "mega"])
        self.assertEqual([v.value for v in Damage], ["default_attack", "pet_skill"])
        self.assertEqual([v.value for v in AuditionMode], ["audition_v3", "audition_v2"])
        self.assertEqual(
            [v.value for v in PetSkillFireCondition],
            [
                "skill_cost_ready",
                "sword_count",
                "mana_gem_count",
                "rage_gem_count",
                "drain_gem_count",
                "shield_gem_count",
            ],
        )

    def test_default_desktop_has_only_new_product_fields(self):
        config = DesktopConfig()
        self.assertEqual((config.main_pet, config.evolution, config.damage_card),
                         (Pet.NORMAL, Evo.NORMAL, Damage.DEFAULT_ATTACK))
        self.assertNotIn("mana_priority", {f.name for f in fields(config)})
        self.assertFalse(hasattr(config, "mana_priority"))
        with self.assertRaises(FrozenInstanceError):
            config.main_pet = Pet.LEGENDARY

    def test_complete_supported_capability_matrix(self):
        cases = (
            (Pet.NORMAL, Evo.NONE, (), Status.NO_SKILL),
            (Pet.NORMAL, Evo.NORMAL, (), Status.NO_SKILL),
            (Pet.NORMAL, Evo.LEGENDARY, (Source.EVOLUTION_TARGET,), Status.EVOLUTION_TARGET_SKILL),
            (Pet.LEGENDARY, Evo.NONE, (Source.MAIN_PET,), Status.MAIN_PET_SKILL),
            (Pet.LEGENDARY, Evo.NORMAL, (Source.MAIN_PET,), Status.MAIN_PET_SKILL),
        )
        for pet, evolution, sources, status in cases:
            with self.subTest(pet=pet, evolution=evolution):
                cap = loadout_capability(pet, evolution)
                self.assertTrue(cap.option_supported)
                self.assertTrue(cap.config_valid)
                self.assertEqual(cap.skill_sources, sources)
                self.assertEqual(cap.source_status, status)
                self.assertEqual(cap.skill_source_count, len(sources))
                self.assertEqual(cap.pet_skill_selectable, bool(sources))

    def test_two_pet_skill_sources_are_rejected_at_configuration_boundary(self):
        cap = loadout_capability(
            Pet.LEGENDARY,
            Evo.LEGENDARY,
            Damage.PET_SKILL,
        )
        self.assertTrue(cap.option_supported)
        self.assertFalse(cap.config_valid)
        self.assertFalse(cap.pet_skill_selectable)
        self.assertEqual(cap.source_status, Status.MULTIPLE_SKILL_SOURCES)
        self.assertEqual(
            cap.blocker_reason,
            "PET_SKILL_SOURCE_SELECTION_UNDEFINED",
        )
        with self.assertRaisesRegex(
            ValueError,
            "PET_SKILL_SOURCE_SELECTION_UNDEFINED",
        ):
            GameplayConfig(
                main_pet=Pet.LEGENDARY,
                evolution=Evo.LEGENDARY,
                damage_card=Damage.PET_SKILL,
            )

    def test_future_option_capability_is_unknown_and_config_rejects(self):
        for name, values in (("main_pet", (Pet.EVOLVED, Pet.MEGA)), ("evolution", (Evo.EVOLVED, Evo.MEGA))):
            for value in values:
                with self.subTest(name=name, value=value):
                    cap = loadout_capability(value if name == "main_pet" else Pet.NORMAL,
                                             value if name == "evolution" else Evo.NORMAL)
                    self.assertFalse(cap.option_supported)
                    self.assertFalse(cap.config_valid)
                    self.assertEqual(cap.source_status, Status.UNKNOWN)
                    with self.assertRaises(ValueError):
                        GameplayConfig(**{name: value})

    def test_impossible_persisted_skill_rejects_and_ui_normalizes(self):
        for evolution in (Evo.NONE, Evo.NORMAL):
            with self.assertRaises(ValueError):
                GameplayConfig(evolution=evolution, damage_card=Damage.PET_SKILL)
            self.assertEqual(normalize_damage(Pet.NORMAL, evolution, Damage.PET_SKILL), Damage.DEFAULT_ATTACK)
        self.assertEqual(normalize_damage(Pet.NORMAL, Evo.LEGENDARY, Damage.PET_SKILL), Damage.PET_SKILL)

    def test_pet_skill_profile_is_runnable_with_v3_default_and_v2_option(self):
        capability = PET_SKILL_PROFILE.capability
        self.assertTrue(capability.option_supported)
        self.assertTrue(capability.config_valid)
        self.assertTrue(capability.pet_skill_selectable)
        self.assertTrue(capability.farm_policy_supported)
        self.assertTrue(capability.desktop_policy_supported)
        self.assertIsNone(capability.desktop_blocker_reason)
        self.assertEqual(PET_SKILL_PROFILE.audition_mode, AuditionMode.V3_TWO_DIRECTION)
        basic_policy_config(PET_SKILL_PROFILE)
        basic_policy_config(replace(
            PET_SKILL_PROFILE,
            audition_mode=AuditionMode.V2_FOUR_DIRECTION,
        ))
        with self.assertRaisesRegex(
            FarmPolicyUnavailable,
            "LEGACY_MANA_PRIORITY_CANNOT_EXPRESS_PET_SKILL",
        ):
            legacy_basic_policy(PET_SKILL_PROFILE)

    def test_multiple_sources_remain_unselected(self):
        capability = loadout_capability(
            Pet.LEGENDARY,
            Evo.LEGENDARY,
            Damage.PET_SKILL,
        )
        self.assertEqual(
            capability.skill_sources,
            (Source.MAIN_PET, Source.EVOLUTION_TARGET),
        )
        self.assertTrue(capability.multiple_skill_sources)
        self.assertFalse(capability.config_valid)

    def test_runtime_mapping_is_limited_to_phase2_defaults_and_exact_pet_skill_profile(self):
        runnable = []
        for pet in (Pet.NORMAL, Pet.LEGENDARY):
            for evolution in (Evo.NONE, Evo.NORMAL, Evo.LEGENDARY):
                for damage in Damage:
                    if not loadout_capability(pet, evolution, damage).config_valid:
                        continue
                    config = GameplayConfig(main_pet=pet, evolution=evolution, damage_card=damage)
                    if config.capability.farm_policy_supported:
                        runnable.append((pet, evolution, damage))
                        basic_policy_config(config)
                        if damage is Damage.DEFAULT_ATTACK:
                            legacy_basic_policy(config)
                    else:
                        with self.assertRaises(FarmPolicyUnavailable):
                            basic_policy_config(config)
        self.assertEqual(
            runnable,
            [
                (Pet.NORMAL, Evo.NONE, Damage.DEFAULT_ATTACK),
                (Pet.NORMAL, Evo.NORMAL, Damage.DEFAULT_ATTACK),
                (Pet.NORMAL, Evo.LEGENDARY, Damage.DEFAULT_ATTACK),
                (Pet.NORMAL, Evo.LEGENDARY, Damage.PET_SKILL),
                (Pet.LEGENDARY, Evo.NONE, Damage.DEFAULT_ATTACK),
                (Pet.LEGENDARY, Evo.NONE, Damage.PET_SKILL),
                (Pet.LEGENDARY, Evo.NORMAL, Damage.DEFAULT_ATTACK),
                (Pet.LEGENDARY, Evo.NORMAL, Damage.PET_SKILL),
            ],
        )

    def test_legacy_policy_configs_and_decisions_match(self):
        states = [combat_state(), combat_state(fusion_used=False),
                  combat_state(mana=600, cards=(attack_card(),)),
                  combat_state(boss_hp=100, cards=(attack_card(),)), combat_state(turn=1)]
        for priority in ManaPriority:
            for style in (PlayStyle.SIMPLE, PlayStyle.CAREFUL):
                config = GameplayConfig(play_style=style, **legacy_pet_fields(priority))
                before = PolicyConfig(play_style=style, mana_priority=priority)
                after = legacy_basic_policy(config)
                self.assertEqual(before, after)
                for state in states:
                    self.assertEqual(BasicPolicyEngine(before).decide(state),
                                     BasicPolicyEngine(after).decide(state))

    def test_canonical_default_profiles_keep_phase2_decisions(self):
        states = [combat_state(), combat_state(fusion_used=False),
                  combat_state(mana=600, cards=(attack_card(),)),
                  combat_state(boss_hp=100, cards=(attack_card(),)), combat_state(turn=1)]
        for priority in ManaPriority:
            for style in (PlayStyle.SIMPLE, PlayStyle.CAREFUL):
                gameplay = GameplayConfig(
                    play_style=style,
                    **legacy_pet_fields(priority),
                )
                canonical = BasicPolicyEngine(basic_policy_config(gameplay))
                legacy = BasicPolicyEngine(legacy_basic_policy(gameplay))
                for state in states:
                    with self.subTest(priority=priority, style=style, turn=state.battle.turn_number):
                        current = canonical.decide(state)
                        previous = legacy.decide(state)
                        self.assertEqual(current.action, previous.action)
                        self.assertEqual(current.move, previous.move)
                        self.assertEqual(
                            current.card_object_address,
                            previous.card_object_address,
                        )
                        self.assertEqual(current.consumes_turn, previous.consumes_turn)
                        self.assertEqual(
                            current.requires_state_reread,
                            previous.requires_state_reread,
                        )

    def test_farm_run_accepts_each_unique_pet_skill_source_profile(self):
        for profile in (
            PET_SKILL_PROFILE,
            UNIMPLEMENTED_PET_SKILL_PROFILE,
            EVOLUTION_PET_SKILL_PROFILE,
        ):
            with self.subTest(profile=profile):
                run = FarmRun(FarmTarget("1289"), gameplay_config=profile)
                self.assertEqual(run.snapshot().gameplay_config, profile)

    def test_pet_skill_profile_never_auto_prepares_ordinary_attack_card(self):
        self.assertFalse(requires_attack_card_preparation(PET_SKILL_PROFILE))
        self.assertTrue(requires_attack_card_preparation(GameplayConfig()))

    def test_farm_snapshot_and_checkpoint_keep_immutable_profile(self):
        profile = GameplayConfig(evolution=Evo.NONE, play_style=PlayStyle.CAREFUL)
        run = FarmRun(FarmTarget("1289"), gameplay_config=profile)
        self.assertEqual(run.snapshot().gameplay_config, profile)
        self.assertEqual(run.checkpoint_payload().gameplay_config, profile)


class PetPreferenceMigrationTests(unittest.TestCase):
    def setUp(self):
        self.tmp = tempfile.TemporaryDirectory()
        self.addCleanup(self.tmp.cleanup)
        self.path = Path(self.tmp.name) / "preferences.json"
        self.store = DesktopPreferenceStore(self.path)

    def seed(self, profile=DesktopConfig()):
        self.store.save(profile, game_location=r"D:\pc\Pokiguard-1.7.4.exe")
        return json.loads(self.path.read_text(encoding="utf-8"))

    def write(self, raw):
        self.path.write_text(json.dumps(raw), encoding="utf-8")

    def test_both_legacy_migrations_save_canonical_and_are_idempotent(self):
        for priority, evolution in (("evolution", Evo.NORMAL), ("attack", Evo.NONE)):
            raw = self.seed()
            raw["schema"] = LEGACY_PREFERENCE_SCHEMA
            for name in ("main_pet", "evolution", "damage_card"):
                del raw["config"][name]
            raw["config"]["mana_priority"] = priority
            self.write(raw)
            first = self.store.load()
            self.assertTrue(first.loaded)
            self.assertEqual(first.config.evolution, evolution)
            self.assertEqual(first.config.main_pet, Pet.NORMAL)
            self.assertEqual(first.config.damage_card, Damage.DEFAULT_ATTACK)
            self.store.save(first.config, game_location=first.game_location)
            encoded = json.loads(self.path.read_text(encoding="utf-8"))
            self.assertEqual(encoded["schema"], PREFERENCE_SCHEMA)
            self.assertNotIn("mana_priority", encoded["config"])
            self.assertEqual(self.store.load(), first)

    def test_new_schema_future_profile_wins_over_stale_legacy(self):
        raw = self.seed(DesktopConfig().with_gameplay_config(PET_SKILL_PROFILE))
        raw["config"]["mana_priority"] = "evolution"
        self.write(raw)
        loaded = self.store.load()
        self.assertTrue(loaded.loaded)
        self.assertEqual(loaded.config.gameplay_config, PET_SKILL_PROFILE)

    def test_current_preferences_missing_threshold_migrate_to_default(self):
        raw = self.seed(replace(DesktopConfig(), pet_skill_fire_value=17))
        del raw["config"]["pet_skill_fire_value"]
        self.write(raw)
        loaded = self.store.load()
        self.assertTrue(loaded.loaded)
        self.assertEqual(loaded.config.pet_skill_fire_value, 10)

    def test_old_schema_cannot_infer_new_skill_intent(self):
        raw = self.seed(DesktopConfig().with_gameplay_config(PET_SKILL_PROFILE))
        raw["schema"] = LEGACY_PREFERENCE_SCHEMA
        raw["config"]["mana_priority"] = "attack"
        self.write(raw)
        self.assertEqual(self.store.load().config.gameplay_config, GameplayConfig(evolution=Evo.NONE))

    def test_corrupt_enums_missing_fields_and_disabled_values_fall_back(self):
        for name, value in (("main_pet", "bad"), ("main_pet", "evolved"),
                            ("evolution", "mega"), ("damage_card", "bad"),
                            ("damage_card", "pet_skill")):
            raw = self.seed()
            raw["config"][name] = value
            self.write(raw)
            result = self.store.load()
            self.assertFalse(result.loaded)
            self.assertEqual(result.config, DesktopConfig())
            self.assertEqual(len(result.warnings), 1)
        raw = self.seed()
        del raw["config"]["damage_card"]
        self.write(raw)
        self.assertFalse(self.store.load().loaded)

    def test_malformed_legacy_value_never_activates_skill(self):
        raw = self.seed()
        raw["schema"] = LEGACY_PREFERENCE_SCHEMA
        raw["config"]["mana_priority"] = "skill"
        self.write(raw)
        self.assertFalse(self.store.load().loaded)
        self.assertEqual(self.store.load().config, DesktopConfig())


class PetCheckpointTests(unittest.TestCase):
    def setUp(self):
        self.tmp = tempfile.TemporaryDirectory()
        self.addCleanup(self.tmp.cleanup)
        self.root = Path(self.tmp.name)
        self.path = self.root / "history" / "checkpoint.json"

    def write_raw(self, raw):
        self.path.parent.mkdir(exist_ok=True)
        self.path.write_text(json.dumps(raw), encoding="utf-8")

    def test_legacy_config_checkpoint_migrates_only_profile(self):
        for priority in ManaPriority:
            original = _payload(completed=1, wins=1, seen=("M_a",))
            raw = asdict(original)
            raw["schema_version"] = LEGACY_CHECKPOINT_SCHEMA
            raw["gameplay_config"] = {"mana_priority": priority.value}
            self.write_raw(raw)
            before_bytes = self.path.read_bytes()
            loaded = load_checkpoint(self.path)
            expected = GameplayConfig(**legacy_pet_fields(priority))
            self.assertEqual(loaded.gameplay_config, expected)
            decision = resume(loaded, expected)
            self.assertTrue(decision.allowed)
            run = FarmRun(FarmTarget("1289", "Starburst"), resume=decision)
            self.assertEqual(run.snapshot().completed_matches, 1)
            self.assertEqual(run.snapshot().unique_match_ids, ("M_a",))
            for field in fields(original):
                if field.name not in {"schema_version", "gameplay_config"}:
                    self.assertEqual(getattr(loaded, field.name), getattr(original, field.name))
            self.assertEqual(before_bytes, self.path.read_bytes())
            self.assertEqual(LatestCheckpointSummaryProvider(self.root).read_latest().gameplay_config, expected)

    def test_actual_v1_shape_resolves_bound_sibling_startup_logs(self):
        raw = asdict(_payload(completed=1, wins=1, seen=("M_a",)))
        raw["schema_version"] = LEGACY_CHECKPOINT_SCHEMA
        del raw["gameplay_config"]
        self.write_raw(raw)
        snapshot = {"farm_run_id": "test_run", "unique_match_ids": ["M_a"],
                    "target": {"boss_id": "1289", "boss_name": "Starburst"},
                    "attempts": [{"attempt_index": 1, "match_id": "M_a"}]}
        (self.path.parent / "run.json").write_text(json.dumps({"snapshot": snapshot}))
        log = self.path.parent / "matches" / "attempt_001" / "combat.jsonl"
        log.parent.mkdir(parents=True)
        for priority in ManaPriority:
            log.write_text(json.dumps({"event": "auto_controller_started", "config": {
                "play_style": "careful", "mana_priority": priority.value,
                "board_input_mode": "two_click"}}) + "\n")
            recovered = load_checkpoint(self.path)
            self.assertEqual(legacy_basic_policy(recovered.gameplay_config).mana_priority, priority)
            self.assertTrue(resume(recovered, recovered.gameplay_config).allowed)
        snapshot["farm_run_id"] = "unrelated"
        (self.path.parent / "run.json").write_text(json.dumps({"snapshot": snapshot}))
        self.assertIsNone(load_checkpoint(self.path).gameplay_config)

    def test_configless_legacy_history_readable_but_not_guessed(self):
        raw = asdict(_payload(completed=1, wins=1, seen=("M_a",)))
        raw["schema_version"] = LEGACY_CHECKPOINT_SCHEMA
        del raw["gameplay_config"]
        self.write_raw(raw)
        loaded = load_checkpoint(self.path)
        self.assertEqual(loaded.wins, 1)
        self.assertEqual(resume(loaded, GameplayConfig()).reason, "CHECKPOINT_PROFILE_UNKNOWN")

    def test_pet_skill_checkpoint_roundtrip_resumes_only_with_exact_profile(self):
        profile = replace(
            PET_SKILL_PROFILE,
            pet_skill_fire_condition=PetSkillFireCondition.MANA_GEM_COUNT,
            pet_skill_fire_value=8,
        )
        payload = replace(_payload(), gameplay_config=profile)
        write_checkpoint(self.path, payload)
        loaded = load_checkpoint(self.path)
        self.assertEqual(loaded, payload)
        self.assertFalse(resume(loaded, GameplayConfig()).allowed)
        self.assertFalse(resume(loaded, PET_SKILL_PROFILE).allowed)
        decision = resume(loaded, profile)
        self.assertTrue(decision.allowed)
        self.assertIsNone(decision.reason)

    def test_skill_cost_checkpoint_roundtrip_has_no_numeric_value(self):
        profile = replace(
            PET_SKILL_PROFILE,
            pet_skill_fire_condition=PetSkillFireCondition.SKILL_COST_READY,
            pet_skill_fire_value=None,
        )
        payload = replace(_payload(), gameplay_config=profile)
        write_checkpoint(self.path, payload)

        loaded = load_checkpoint(self.path)

        self.assertEqual(loaded.gameplay_config, profile)
        self.assertIsNone(loaded.gameplay_config.pet_skill_fire_value)
        self.assertTrue(resume(loaded, profile).allowed)

    def test_current_checkpoint_missing_threshold_migrates_to_default(self):
        raw = asdict(replace(_payload(), gameplay_config=PET_SKILL_PROFILE))
        del raw["gameplay_config"]["pet_skill_fire_value"]
        self.write_raw(raw)
        loaded = load_checkpoint(self.path)
        self.assertEqual(loaded.gameplay_config.pet_skill_fire_value, 10)

    def test_sword_only_checkpoint_key_migrates_to_generic_fields(self):
        raw = asdict(replace(_payload(), gameplay_config=PET_SKILL_PROFILE))
        raw["gameplay_config"].pop("pet_skill_fire_condition")
        raw["gameplay_config"].pop("pet_skill_fire_value")
        raw["gameplay_config"]["skill_rush_sword_threshold"] = 15
        self.write_raw(raw)

        loaded = load_checkpoint(self.path)

        self.assertIs(
            loaded.gameplay_config.pet_skill_fire_condition,
            PetSkillFireCondition.SWORD_COUNT,
        )
        self.assertEqual(loaded.gameplay_config.pet_skill_fire_value, 15)

    def test_invalid_generic_checkpoint_condition_or_value_is_rejected(self):
        for field, value in (
            ("pet_skill_fire_condition", "future_condition"),
            ("pet_skill_fire_value", 257),
        ):
            with self.subTest(field=field):
                raw = asdict(
                    replace(_payload(), gameplay_config=PET_SKILL_PROFILE)
                )
                raw["gameplay_config"][field] = value
                self.write_raw(raw)
                with self.assertRaises(CheckpointError):
                    load_checkpoint(self.path)

    def test_profile_mismatch_cannot_change_historical_behavior(self):
        payload = replace(_payload(), gameplay_config=GameplayConfig(evolution=Evo.NONE))
        self.assertEqual(resume(payload, GameplayConfig()).reason, "CHECKPOINT_CONFIG_MISMATCH")

    def test_missing_new_config_or_corrupt_enum_is_rejected(self):
        for invalid in (None, {"main_pet": "invented"}):
            raw = asdict(_payload())
            if invalid is None:
                del raw["gameplay_config"]
            else:
                raw["gameplay_config"] = invalid
            self.write_raw(raw)
            with self.assertRaises(CheckpointError):
                load_checkpoint(self.path)

    def test_completed_and_emergency_still_nonresumable(self):
        self.assertEqual(resume(_payload(finalized="COMPLETED")).reason, "CHECKPOINT_ALREADY_COMPLETED")
        self.assertFalse(resume(_payload(finalized="EMERGENCY_STOP")).allowed)


class PetLaunchGateTests(unittest.TestCase):
    def test_cli_removes_redundant_evolved_choices(self):
        parser = farm_run.build_parser()
        actions = {action.dest: action for action in parser._actions}
        self.assertNotIn("evolved", actions["main_pet"].choices)
        self.assertNotIn("evolved", actions["evolution_target"].choices)
        self.assertIn("mega", actions["main_pet"].choices)
        self.assertIn("mega", actions["evolution_target"].choices)

    def test_dual_pet_skill_profile_rejects_before_controller_construction(self):
        with self.assertRaisesRegex(
            ValueError,
            "PET_SKILL_SOURCE_SELECTION_UNDEFINED",
        ):
            GameplayConfig(
                main_pet=Pet.LEGENDARY,
                evolution=Evo.LEGENDARY,
                damage_card=Damage.PET_SKILL,
            )

    def test_valid_default_cannot_resume_future_checkpoint(self):
        with tempfile.TemporaryDirectory() as tmp:
            root = Path(tmp)
            evidence = root / "reset.json"
            evidence.write_text("{}")
            checkpoint = root / "checkpoint.json"
            write_checkpoint(
                checkpoint,
                replace(_payload(), gameplay_config=PET_SKILL_PROFILE),
            )
            runner = Mock()
            manager = DesktopFarmControllerManager(root, runner=runner, reset_evidence=evidence)
            config = DesktopConfig(boss_id="1289", boss_name="Starburst", target_completed_matches=5, max_match_attempts=8)
            self.assertFalse(manager.resume(config, checkpoint).accepted)
            runner.assert_not_called()

    def test_canonical_cli_and_deprecated_alias_map_identically(self):
        parser = farm_run.build_parser()
        for priority, evolution in (("evolution", "normal"), ("attack", "none")):
            old = parser.parse_args(["--stage-a-replay", "--mana-priority", priority])
            new = parser.parse_args(["--stage-a-replay", "--main-pet", "normal", "--evolution-target", evolution, "--damage-card", "default_attack"])
            self.assertEqual(gameplay_config_from_args(old), gameplay_config_from_args(new))
            self.assertEqual(farm_cycle._combat_args(new, Path("test.jsonl")).mana_priority, priority)

    def test_cli_conflicting_flags_reject_even_if_equivalent(self):
        for flag, value in (("--main-pet", "normal"), ("--evolution-target", "normal"), ("--damage-card", "default_attack")):
            args = farm_run.build_parser().parse_args(["--stage-a-replay", "--mana-priority", "evolution", flag, value])
            with self.assertRaisesRegex(ValueError, "conflicts"):
                farm_run._validate_args(args)

    def test_unique_main_pet_skill_with_normal_evolution_cli_is_supported(self):
        args = farm_run.build_parser().parse_args(["--stage-a-replay", "--boss-id", "1289",
            "--main-pet", "legendary", "--evolution-target", "normal", "--damage-card", "pet_skill"])
        config = gameplay_config_from_args(args)
        self.assertTrue(config.farm_policy_supported)
        self.assertEqual(config.capability.skill_source_count, 1)
        self.assertEqual(
            farm_cycle._combat_args(args, Path("test.jsonl")).evolution_target,
            "normal",
        )


if __name__ == "__main__":
    unittest.main()
