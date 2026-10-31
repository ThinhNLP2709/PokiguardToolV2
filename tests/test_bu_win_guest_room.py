"""Offline guest-room authorization, death waiting and team-result regression."""

from dataclasses import asdict, replace
from types import SimpleNamespace
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.basic_policy import BasicPolicyEngine, PolicyAction
from pokiguard_v2.boss_entry import BossLobbyState, FarmTarget, resolve_target
from pokiguard_v2.desktop_control_plane import DesktopConfig, DesktopControlPlane
from pokiguard_v2.farm_run import FarmRun, FarmRunState, FarmRunStopReason
from pokiguard_v2.pet_configuration import basic_policy_config
from pokiguard_v2.state import TerminalResult
from pokiguard_v2.terminal_result import capture_terminal_snapshot
from tests.test_basic_policy import combat_state
from tests.test_boss_entry import candidate
from tests.test_bu_win import bu_win_config
from tests.test_terminal_result import active_state, enter_run, participant_pair, session
from tools.boss_entry import _coop_wait_room_changed, _entry_preflight_runtime_valid
from tools.farm_cycle import _wait_boss_lobby
from tools.farm_run import _run_recovery


def room_lobby(room_id="Coop_guest", owner="host", is_host=False):
    return SimpleNamespace(
        state=BossLobbyState.BOSS_LOBBY,
        branch="CHINH_PHUC_ROOM",
        candidates=(candidate(0, "1289", "Starburst"),),
        chinh_phuc=SimpleNamespace(
            current_room_id=room_id, owner_username=owner, is_host=is_host
        ),
    )


class BuWinGuestRoomTests(unittest.TestCase):
    def test_desktop_guest_room_requires_bu_win_coop(self):
        plane = SimpleNamespace(_closed=False, _controller=object())
        snapshot = SimpleNamespace(
            runtime=SimpleNamespace(
                game_detected=True, attached=True, architecture="x64",
                lifecycle="BOSS_LOBBY", room_is_host=False,
            ),
            controller=SimpleNamespace(active=False), stale=False, health="OK",
            config=DesktopConfig(),
        )
        self.assertEqual(
            DesktopControlPlane._runtime_command_preflight(plane, snapshot),
            "GUEST_ROOM_REQUIRES_BU_WIN_COOP",
        )
        snapshot.config = DesktopConfig(**asdict(bu_win_config()))
        self.assertIsNone(
            DesktopControlPlane._runtime_command_preflight(plane, snapshot)
        )

    def test_preflight_rejects_host_migration_before_ready_click(self):
        lobby = room_lobby()
        resolution = resolve_target(FarmTarget(boss_id="1289"), lobby.candidates)
        ready = SimpleNamespace(lobby=room_lobby(), resolution=resolution)
        self.assertTrue(_entry_preflight_runtime_valid(lobby, resolution, ready))
        lobby.chinh_phuc.owner_username = "another-host"
        self.assertFalse(_entry_preflight_runtime_valid(lobby, resolution, ready))
        self.assertTrue(_coop_wait_room_changed(lobby, ready.lobby))
        lobby.chinh_phuc.owner_username = "host"
        lobby.chinh_phuc.is_host = True
        self.assertTrue(_coop_wait_room_changed(lobby, ready.lobby))

    def test_lobby_return_is_bound_to_same_room_and_owner(self):
        for room_id, owner, expected_ready in (
            ("Coop_guest", "host", True),
            ("Coop_new", "host", False),
            ("Coop_guest", "another-host", False),
        ):
            with self.subTest(room_id=room_id, owner=owner), patch(
                "tools.farm_cycle._read_lobby_runtime_with_provider_fallback",
                return_value=room_lobby(room_id, owner),
            ) as reader, patch("tools.farm_cycle.time.sleep"):
                result = _wait_boss_lobby(
                    SimpleNamespace(is_running=lambda: True),
                    SimpleNamespace(current_session_key=None),
                    FarmTarget(boss_id="1289"), 1, 0,
                    SimpleNamespace(poll=lambda: (False, False)),
                    allow_guest_room=True, expected_room_id="Coop_guest",
                    expected_room_owner="host",
                )
                self.assertEqual(result.ready, expected_ready)
                if not expected_ready:
                    self.assertEqual(result.reason, "COOP_ROOM_CHANGED")
                self.assertTrue(reader.call_args.kwargs["allow_guest_room"])

    def test_dead_pet_never_produces_gameplay_action(self):
        state = combat_state()
        dead = replace(state, player=replace(state.player, hp=0))
        engine = BasicPolicyEngine(basic_policy_config(bu_win_config()))
        decision = engine.decide(dead)
        self.assertIs(decision.action, PolicyAction.NONE)
        self.assertEqual(decision.trace.policy_step, "BU_WIN_WAIT_TEAMMATES")

    def test_local_death_cannot_manufacture_team_loss(self):
        key = session()
        snapshot = capture_terminal_snapshot(
            session_key=key, timestamp="test", coop_mode=True,
            active_state=active_state(key, 0, 200), captured_before_cleanup=True,
        )
        self.assertIs(snapshot.result, TerminalResult.UNKNOWN)
        boss_win = capture_terminal_snapshot(
            session_key=key, timestamp="test", coop_mode=True,
            terminal_winner="BOSS", captured_before_cleanup=True,
        )
        self.assertIs(boss_win.result, TerminalResult.LOSS)

    def test_unknown_team_winner_does_not_invent_victory(self):
        key = session()
        unknown = capture_terminal_snapshot(
            session_key=key, timestamp="test", coop_mode=True,
            active_state=active_state(key, 0, 200),
            terminal_winner="unverified-teammate-name",
            captured_before_cleanup=True,
        )
        self.assertIs(unknown.result, TerminalResult.UNKNOWN)
        conflict = capture_terminal_snapshot(
            session_key=key, timestamp="test", coop_mode=True,
            terminal_participants=participant_pair(0, 0),
            terminal_winner="BOSS", captured_before_cleanup=True,
        )
        self.assertIs(conflict.result, TerminalResult.UNKNOWN)
        self.assertIn("TERMINAL_MEMORY_CONFLICT", conflict.evidence_sources)

    def test_dead_pet_team_victory_counts_and_allows_next_round(self):
        key = session()
        run = FarmRun(FarmTarget(boss_id="1289"), gameplay_config=bu_win_config())
        self.assertTrue(run.observe_initial_lobby(BossLobbyState.BOSS_LOBBY))
        enter_run(run, key)
        terminal = capture_terminal_snapshot(
            session_key=key, timestamp="test", coop_mode=True,
            terminal_participants=participant_pair(0, 0),
            active_state=active_state(key, 0, 100), captured_before_cleanup=True,
        )
        self.assertIs(terminal.result, TerminalResult.WIN)
        self.assertTrue(run.normal_combat_ended(terminal))
        self.assertEqual(run.wins, 1)
        self.assertEqual(run.losses, 0)
        self.assertTrue(run.observe_postmatch())
        self.assertTrue(run.observe_return_lobby(BossLobbyState.BOSS_LOBBY))
        self.assertIs(run.state, FarmRunState.RESOLVE_TARGET)
        enter_run(run, session(2))
        self.assertIs(run.state, FarmRunState.COMBAT_ACTIVE)

    def test_coop_technical_failure_does_not_exit_and_recreate_room(self):
        run = FarmRun(FarmTarget(boss_id="1289"), gameplay_config=bu_win_config())
        writer = Mock()
        with patch("tools.farm_run.technical_recovery.run_armed_live_recovery") as recover:
            self.assertFalse(_run_recovery(
                run=run, args=SimpleNamespace(), runtime=object(),
                coordinator=object(), failure_state=None, writer=writer,
                test_only=False,
            ))
        recover.assert_not_called()
        self.assertIs(run.stop_reason, FarmRunStopReason.COMBAT_SAFE_STOP)


if __name__ == "__main__":
    unittest.main()
