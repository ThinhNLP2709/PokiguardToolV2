"""Offline regressions for renamed-product prefs and post-result room loss."""

from __future__ import annotations

from contextlib import nullcontext
import json
from pathlib import Path
from types import SimpleNamespace
import tempfile
import unittest
from unittest.mock import MagicMock, patch

import pokiguard_v2.chinh_phuc_map as chinh_map
from pokiguard_v2.boss_entry import BossLobbyState, FarmTarget
from pokiguard_v2.combat_lifecycle import CombatLifecycleState
from pokiguard_v2.farm_run import MatchResult
from tools.farm_cycle import LobbyWaitResult
from tools.farm_run import (
    _detached_shell_exit_runtime_proven,
    _postmatch_reentry_source,
    _recover_postmatch_boss_lobby,
)
from tests import test_farm_run as farm_fixtures
from tests.test_farm_run import enter, session, start_run


CURRENT_KEY = r"Software\Pet Puzzle\Pet Puzzle"
LEGACY_KEY = r"Software\Pokiguard\PokiguardOnlines"


class _Registry:
    HKEY_CURRENT_USER = object()
    KEY_READ = 0x20019

    def __init__(self, keys: dict[str, list[tuple[str, int]]]) -> None:
        self.keys = keys
        self.opened: list[str] = []

    def OpenKey(self, hive, path, reserved, access):
        assert hive is self.HKEY_CURRENT_USER and reserved == 0 and access == self.KEY_READ
        self.opened.append(path)
        if path not in self.keys:
            raise FileNotFoundError(2, "The system cannot find the file specified")
        return nullcontext(path)

    def EnumValue(self, path, index):
        try:
            name, value = self.keys[path][index]
        except IndexError:
            raise OSError(259, "No more data") from None
        return name, value, 4


def _selection(pet: int) -> list[tuple[str, int]]:
    return [
        ("SelectedPetId_h3126844256", pet),
        ("SelectedGroupIndex_h1677977261", 6),
        ("ActivePanelIndex_h123", 6),
    ]


class ProductPlayerPrefsTests(unittest.TestCase):
    def setUp(self) -> None:
        self.directory = tempfile.TemporaryDirectory()
        self.addCleanup(self.directory.cleanup)
        root = Path(self.directory.name)
        self.executable = root / "PetPuzzle-1.7.4.exe"
        self.info = root / "PetPuzzle-1.7.4_Data" / "app.info"
        self.info.parent.mkdir()
        self.info.write_text("Pet Puzzle\nPet Puzzle\n", encoding="utf-8")
        self.target = SimpleNamespace(
            game_executable=self.executable,
            game_assembly=SimpleNamespace(path=root / "GameAssembly.dll"),
        )

    def read(self, registry: _Registry):
        with patch.dict("sys.modules", {"winreg": registry}), patch.object(
            chinh_map, "os", SimpleNamespace(name="nt")
        ):
            return chinh_map.read_chinh_phuc_player_prefs(self.target)

    def test_fresh_pet_puzzle_install_does_not_need_old_registry(self) -> None:
        registry = _Registry({CURRENT_KEY: _selection(1436)})
        prefs = self.read(registry)
        self.assertEqual(prefs.selected_pet_id, 1436)
        self.assertEqual(prefs.source, CURRENT_KEY)
        self.assertEqual(prefs.reasons, ())
        self.assertEqual(registry.opened, [CURRENT_KEY])

    def test_old_selection_cannot_override_current_product(self) -> None:
        registry = _Registry({CURRENT_KEY: _selection(1436), LEGACY_KEY: _selection(650)})
        self.assertEqual(self.read(registry).selected_pet_id, 1436)
        self.assertEqual(registry.opened, [CURRENT_KEY])

    def test_missing_current_key_does_not_borrow_old_product_selection(self) -> None:
        registry = _Registry({LEGACY_KEY: _selection(650)})
        prefs = self.read(registry)
        self.assertIsNone(prefs.selected_pet_id)
        self.assertEqual(prefs.source, CURRENT_KEY)
        self.assertIn("PlayerPrefs read failed", prefs.reasons[0])
        self.assertEqual(registry.opened, [CURRENT_KEY])

    def test_legacy_product_is_supported_only_when_install_metadata_names_it(self) -> None:
        self.info.write_text("Pokiguard\nPokiguardOnlines\n", encoding="utf-8")
        registry = _Registry({CURRENT_KEY: _selection(1436), LEGACY_KEY: _selection(650)})
        self.assertEqual(self.read(registry).selected_pet_id, 650)
        self.assertEqual(registry.opened, [LEGACY_KEY])

    def test_exact_executable_metadata_wins_over_other_data_folders(self) -> None:
        other = self.info.parent.parent / "Pokiguard-1.7.4_Data"
        other.mkdir()
        (other / "app.info").write_text("Pokiguard\nPokiguardOnlines\n", encoding="utf-8")
        registry = _Registry({CURRENT_KEY: _selection(1436), LEGACY_KEY: _selection(650)})
        self.assertEqual(self.read(registry).selected_pet_id, 1436)
        del self.target.game_executable
        prefs = self.read(registry)
        self.assertEqual(prefs.source, "UNRESOLVED")
        self.assertIn("ambiguous", prefs.reasons[0])
        self.assertEqual(registry.opened, [CURRENT_KEY])

    def test_unreadable_or_invalid_metadata_does_not_guess_registry(self) -> None:
        registry = _Registry({LEGACY_KEY: _selection(650)})
        for content in (None, "Pet Puzzle\n", "Pet Puzzle\nBad\\Product\n"):
            with self.subTest(content=content):
                if content is None:
                    self.info.unlink()
                else:
                    self.info.write_text(content, encoding="utf-8")
                prefs = self.read(registry)
                self.assertEqual(prefs.source, "UNRESOLVED")
                self.assertTrue(prefs.reasons)
        self.assertEqual(registry.opened, [])


class PostmatchRoomRecoveryTests(unittest.TestCase):
    def test_vm_attempt50_evidence_allows_exit_despite_missing_registry(self) -> None:
        fixture = Path(__file__).parent / "fixtures" / "vm_empty_room_attempt50_20261009.json"
        evidence = json.loads(fixture.read_text(encoding="utf-8"))

        def namespace(value):
            return (SimpleNamespace(**{key: namespace(item) for key, item in value.items()})
                    if isinstance(value, dict) else value)

        lobby = namespace(evidence["lobby"])
        lobby.state = BossLobbyState(lobby.state)
        lobby.combat_lifecycle.state = CombatLifecycleState(lobby.combat_lifecycle.state)
        runtime = chinh_map.ChinhPhucMapTarget(**{
            **evidence["runtime"],
            "prefs": chinh_map.ChinhPhucPlayerPrefs(**evidence["runtime"]["prefs"]),
        })
        self.assertIsNone(runtime.prefs.selected_pet_id)
        self.assertTrue(evidence["first_shell_exit"]["found"])
        self.assertTrue(evidence["second_shell_exit"]["found"])
        self.assertTrue(_detached_shell_exit_runtime_proven(
            lobby, pet_id=evidence["target_pet_id"], current_session=None,
            first_map_target=runtime, current_map_target=None, allow_map_backed_shell=True,
        ))
        initial = LobbyWaitResult(False, lobby.state, None, evidence["reason"], lobby, 2)
        self.assertEqual(_postmatch_reentry_source(
            initial, target_pet_id=evidence["target_pet_id"], current_session=None,
        ), "CHINH_PHUC_MAP")

    def setUp(self) -> None:
        self.run = start_run()
        enter(self.run, session(1))
        self.assertTrue(self.run.normal_combat_ended(MatchResult.WIN))
        self.assertTrue(self.run.observe_postmatch())
        self.provider = SimpleNamespace(current_session_key=None)
        self.writer = MagicMock()
        self.ready = LobbyWaitResult(
            True, BossLobbyState.BOSS_LOBBY, None, "BOSS_LOBBY_READY",
            farm_fixtures.ChinhPhucMapSnapshotTests.lobby(
                state=BossLobbyState.BOSS_LOBBY, branch="CHINH_PHUC_ROOM",
                current_room_id="Coop_123", current_room_type="ChinhPhuc",
                owner_username="local", is_host=True,
            ), 2,
        )

    @staticmethod
    def missing(source: str) -> LobbyWaitResult:
        if source == "DETACHED_ROOM_SHELL":
            lobby = farm_fixtures.DetachedShellExitRuntimeTests.lobby()
            reason = "DETACHED_ROOM_SHELL_CANDIDATE"
        else:
            branch = {
                "GENERAL_HUB": "GAME_LOBBY",
                "CHINH_PHUC_MAP": "CHINH_PHUC_MAP",
                "CHINH_PHUC_ISLAND": "CHINH_PHUC_ISLAND",
                "WORLD_BOSS_LIST": "WORLD_BOSS_LIST",
            }[source]
            lobby = farm_fixtures.ChinhPhucMapSnapshotTests.lobby(
                state=(BossLobbyState.BOSS_LOBBY if source == "WORLD_BOSS_LIST"
                       else BossLobbyState.LOBBY_OTHER),
                branch=branch, clean_for_chinh_phuc_map=True,
            )
            lobby.world_boss.clean_for_game_lobby = source == "GENERAL_HUB"
            reason = (
                "GENERAL_HUB_CANDIDATE" if source == "GENERAL_HUB" else
                "TARGET_MISSING" if source == "WORLD_BOSS_LIST" else
                "CHINH_PHUC_MAP_CANDIDATE"
            )
        return LobbyWaitResult(False, lobby.state, None, reason, lobby, 2)

    def recover(self, initial, *, allow_reentry=True):
        return _recover_postmatch_boss_lobby(
            run=self.run, process=object(), provider=self.provider,
            target=FarmTarget(boss_id="1289", boss_name="Starburst"),
            initial=initial, allow_reentry=allow_reentry, writer=self.writer,
            binding=object(), executor=object(), directory=Path("unused"),
            interval=0.1, timeout=90.0, hotkeys=object(),
        )

    def test_all_settled_non_room_destinations_reenter_same_pinned_boss(self) -> None:
        for source in ("GENERAL_HUB", "CHINH_PHUC_MAP", "CHINH_PHUC_ISLAND",
                       "WORLD_BOSS_LIST", "DETACHED_ROOM_SHELL"):
            with self.subTest(source=source), patch(
                "tools.farm_run._return_from_chinh_phuc_map", return_value=self.ready
            ) as route:
                before = (self.run.completed_matches, self.run.match_attempts)
                observed = self.recover(self.missing(source))
                self.assertIs(observed, self.ready)
                route.assert_called_once()
                self.assertEqual(route.call_args.kwargs["target"].boss_id, "1289")
                self.assertEqual(before, (self.run.completed_matches, self.run.match_attempts))
        self.assertEqual(sum(c.args[0] == "postmatch_boss_room_missing"
                             for c in self.writer.event.call_args_list), 5)

    def test_healthy_room_and_current_room_only_mode_do_not_navigate(self) -> None:
        with patch("tools.farm_run._return_from_chinh_phuc_map") as route:
            self.assertIs(self.recover(self.ready), self.ready)
            missing = self.missing("GENERAL_HUB")
            self.assertIs(self.recover(missing, allow_reentry=False), missing)
        route.assert_not_called()

    def test_active_owner_or_unknown_transition_does_not_authorize_reentry(self) -> None:
        for source in ("GENERAL_HUB", "CHINH_PHUC_MAP", "WORLD_BOSS_LIST", "DETACHED_ROOM_SHELL"):
            for lifecycle in (CombatLifecycleState.ACTIVE, CombatLifecycleState.UNKNOWN):
                initial = self.missing(source)
                initial.lobby.combat_lifecycle.state = lifecycle
                with self.subTest(source=source, lifecycle=lifecycle), patch(
                    "tools.farm_run._return_from_chinh_phuc_map"
                ) as route:
                    self.assertIs(self.recover(initial), initial)
                    route.assert_not_called()
        self.provider.current_session_key = object()
        with patch("tools.farm_run._return_from_chinh_phuc_map") as route:
            initial = self.missing("GENERAL_HUB")
            self.assertIs(self.recover(initial), initial)
            route.assert_not_called()

    def test_map_then_room_shell_recovery_uses_two_bounded_passes(self) -> None:
        initial = self.missing("CHINH_PHUC_MAP")
        shell = self.missing("DETACHED_ROOM_SHELL")
        with patch("tools.farm_run._return_from_chinh_phuc_map",
                   side_effect=[shell, self.ready]) as route:
            self.assertIs(self.recover(initial), self.ready)
        self.assertEqual(route.call_count, 2)
        self.assertIs(route.call_args_list[1].kwargs["initial"], shell)

    def test_failed_or_repeated_reentry_does_not_loop_forever(self) -> None:
        initial = self.missing("GENERAL_HUB")
        for result, expected_calls in ((None, 1), (initial, 2)):
            with self.subTest(result=result), patch(
                "tools.farm_run._return_from_chinh_phuc_map", return_value=result
            ) as route:
                self.assertIs(self.recover(initial), initial)
                self.assertEqual(route.call_count, expected_calls)


if __name__ == "__main__":
    unittest.main()
