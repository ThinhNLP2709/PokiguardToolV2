"""Mega protection settings survive UI/FarmRunner and select the intended policy."""

from dataclasses import replace
import json
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

from pokiguard_v2.basic_policy import BasicPolicyEngine, PolicyAction
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.board_simulator import evaluate_all_moves
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.desktop_farm_controller import ControllerLaunch, DesktopFarmControllerManager
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
from pokiguard_v2.gameplay_profile import MegaSelfProtection
from pokiguard_v2.pet_configuration import GameplayConfig, basic_policy_config, gameplay_config_from_args
from pokiguard_v2.reasoning_calibration import decode_config
from pokiguard_v2.reasoning_config_projection import project_config
from pokiguard_v2.win32_input import FarmControlHotkeyEdges
from tests.test_mega_icarus_policy import health_candidate, mega_capability
from tests.test_phase3c1_pet_skill_policy import capability, session_state
from tests.test_phase3c3_skill_rush_policy import candidate, with_player_hp
from tests.reasoning_controller_fixture import controller_trace
from tools import basic_auto_bot, pet_skill_action
from tools import farm_run
from tools.farm_cycle import _combat_args


def mega_config(mode=MegaSelfProtection.HP_BELOW_30):
    return GameplayConfig.from_dict({
        "play_style": "mega_icarus_spam_skill", "main_pet": "mega",
        "evolution": "none", "damage_card": "pet_skill",
        "pet_skill_fire_condition": "sword_count", "pet_skill_fire_value": 64,
        "mega_self_protection": mode.value,
    })


class MegaSelfProtectionTests(unittest.TestCase):
    def test_legacy_settings_default_to_thirty_and_invalid_values_are_rejected(self):
        raw = mega_config().to_dict()
        raw.pop("mega_self_protection")
        self.assertIs(GameplayConfig.from_dict(raw).mega_self_protection, MegaSelfProtection.HP_BELOW_30)
        for value in ("hp_below_20", "", 10, None):
            with self.subTest(value=value), self.assertRaises(ValueError):
                GameplayConfig.from_dict({**raw, "mega_self_protection": value})
        desktop = jsonable(DesktopConfig())
        desktop.pop("mega_self_protection")
        self.assertIs(decode_config(desktop).mega_self_protection, MegaSelfProtection.HP_BELOW_30)

    def test_icarus_heal_override_uses_selected_threshold_including_its_boundary(self):
        for mode, hp, expected in (
            (MegaSelfProtection.HP_BELOW_30, 30, True),
            (MegaSelfProtection.HP_BELOW_30, 31, False),
            (MegaSelfProtection.HP_BELOW_10, 10, True),
            (MegaSelfProtection.HP_BELOW_10, 11, False),
            (MegaSelfProtection.HP_BELOW_10, 20, False),
            (MegaSelfProtection.NONE, 1, False),
        ):
            with self.subTest(mode=mode, hp=hp):
                state = with_player_hp(session_state(mana=250, rage=250), hp=hp)
                decision = BasicPolicyEngine(basic_policy_config(mega_config(mode))).decide(
                    state, pet_skill_capability=mega_capability(),
                )
                self.assertEqual(decision.trace.policy_step == "MEGA_ICARUS_SURVIVAL_SKILL", expected)
                if expected:
                    self.assertIs(decision.action, PolicyAction.PET_SKILL)
                else:
                    self.assertIs(decision.action, PolicyAction.SWAP)
                    self.assertFalse(decision.trace.policy_step.startswith("MEGA_ICARUS_SURVIVAL"))

    def test_none_and_ten_percent_prioritize_mana_at_twenty_percent_hp(self):
        state = with_player_hp(session_state(mana=100, rage=250), hp=20)
        moves = evaluate_all_moves(state.board)
        mana = candidate(moves[0], mana=5)
        health = health_candidate(moves[1])
        for mode, expected in (
            (MegaSelfProtection.HP_BELOW_30, health.move),
            (MegaSelfProtection.HP_BELOW_10, mana.move),
            (MegaSelfProtection.NONE, mana.move),
        ):
            with self.subTest(mode=mode), patch(
                "pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(mana, health)
            ):
                decision = BasicPolicyEngine(basic_policy_config(mega_config(mode))).decide(
                    state, pet_skill_capability=mega_capability(mana=200),
                )
                self.assertIs(decision.action, PolicyAction.SWAP)
                self.assertEqual(decision.move, expected)

    def test_preferences_round_trip_and_old_preferences_keep_thirty_percent(self):
        with tempfile.TemporaryDirectory() as folder:
            store = DesktopPreferenceStore(Path(folder) / "preferences.json")
            for mode in MegaSelfProtection:
                config = DesktopConfig().with_gameplay_config(mega_config(mode))
                store.save(config)
                loaded = store.load()
                self.assertTrue(loaded.loaded)
                self.assertEqual(loaded.config.gameplay_config, config.gameplay_config)
            raw = json.loads(store.path.read_text(encoding="utf-8"))
            raw["config"].pop("mega_self_protection")
            store.path.write_text(json.dumps(raw), encoding="utf-8")
            self.assertIs(store.load().config.mega_self_protection, MegaSelfProtection.HP_BELOW_30)

    def test_trex_survival_sword_priority_respects_the_same_setting(self):
        state = with_player_hp(session_state(mana=100, rage=250), hp=20)
        moves = evaluate_all_moves(state.board)
        mana, sword = candidate(moves[0], mana=5), candidate(moves[1], sword=6)
        for mode, expected in (
            (MegaSelfProtection.HP_BELOW_30, sword.move),
            (MegaSelfProtection.HP_BELOW_10, mana.move),
            (MegaSelfProtection.NONE, mana.move),
        ):
            with self.subTest(mode=mode), patch(
                "pokiguard_v2.basic_policy.evaluate_all_moves", return_value=(mana, sword)
            ):
                decision = BasicPolicyEngine(basic_policy_config(mega_config(mode))).decide(
                    state, pet_skill_capability=capability(element="MEGA_TREX", mana_cost=200),
                )
                self.assertEqual(decision.move, expected)

    def test_combat_controller_uses_setting_instead_of_old_emergency_skill(self):
        def current_skill(_provider, current, _resolver):
            return replace(mega_capability(), session_key=current.battle.session_key)

        with tempfile.TemporaryDirectory() as folder:
            for mode in (MegaSelfProtection.NONE, MegaSelfProtection.HP_BELOW_10):
                with self.subTest(mode=mode), patch.object(
                    basic_auto_bot, "_current_pet_skill_capability", side_effect=current_skill
                ), patch.object(
                    pet_skill_action, "run_embedded_policy_action",
                    side_effect=AssertionError("unexpected emergency skill"),
                ):
                    _, calls, rows = controller_trace(
                        Path(folder) / f"{mode.value}.jsonl",
                        profile="mega_icarus_spam_skill", gameplay_config=mega_config(mode),
                        initial_combat=with_player_hp(session_state(mana=250, rage=250), hp=20),
                    )
                self.assertEqual(calls.count("FAKE_NORMAL_INPUT"), 1)
                self.assertEqual(calls.count("executor.ack"), 1)
                started = next(row for row in rows if row["event"] == "auto_controller_started")
                self.assertEqual(started["config"]["mega_self_protection"], mode.value)

    def test_desktop_to_farm_and_combat_preserves_every_selection(self):
        with tempfile.TemporaryDirectory() as folder:
            manager = DesktopFarmControllerManager(Path(folder))
            for mode in MegaSelfProtection:
                config = replace(
                    DesktopConfig().with_gameplay_config(mega_config(mode)),
                    boss_id="332", boss_name="Thunderfort",
                )
                with self.subTest(mode=mode), patch.object(farm_run, "run", return_value=0) as run:
                    manager._run_production(
                        ControllerLaunch(config, None), FarmControlHotkeyEdges(), lambda *_: None,
                    )
                args = run.call_args.args[0]
                self.assertIs(gameplay_config_from_args(args).mega_self_protection, mode)
                combat = _combat_args(args, Path(folder) / "combat.jsonl")
                self.assertEqual(combat.mega_self_protection, mode.value)
                projected = project_config(basic_policy_config(config.gameplay_config))
                self.assertEqual(projected["mega_self_protection"], mode.value)


if __name__ == "__main__":
    unittest.main()
