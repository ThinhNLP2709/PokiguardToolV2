from __future__ import annotations

import inspect
from types import SimpleNamespace
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.combat_lifecycle import (
    CombatLifecycleObservation,
    CombatLifecycleSignals,
    CombatLifecycleState,
)
from pokiguard_v2.desktop_control_plane import DesktopControlPlane, RuntimeObservation, SnapshotPoller
from pokiguard_v2.desktop_runtime import ReadOnlyGameStatusProvider
from pokiguard_v2.desktop_ui import DesktopViewModel
from pokiguard_v2.memory_board_provider import ProviderPoll
from pokiguard_v2.state import CombatSessionKey
import pokiguard_v2.desktop_runtime as desktop_runtime_module
import tools.desktop_ui as desktop_ui_tool


class _Target:
    def __init__(self, *, running: bool = True) -> None:
        self.pid = 1234
        self.architecture = "x64"
        self.resolver = object()
        self.running = running
        self.closed = 0

    def is_running(self) -> bool:
        return self.running

    def close(self) -> None:
        self.closed += 1


def _lifecycle(
    state: CombatLifecycleState, *, match_id: str | None = None
) -> CombatLifecycleObservation:
    return CombatLifecycleObservation(
        state,
        CombatLifecycleSignals(match_id=match_id),
        "test",
    )


class ReadOnlyGameStatusProviderTests(unittest.TestCase):
    def test_process_not_running_is_detached(self) -> None:
        provider = ReadOnlyGameStatusProvider(
            Mock(side_effect=RuntimeError("Pokiguard.exe is not running"))
        )
        observation = provider.read()
        self.assertFalse(observation.game_detected)
        self.assertFalse(observation.attached)
        self.assertEqual(observation.lifecycle, "UNAVAILABLE")

    @patch.object(desktop_runtime_module, "MemoryBoardStateProvider")
    def test_active_combat_maps_canonical_lifecycle_and_match(self, provider_class: Mock) -> None:
        target = _Target()
        provider_class.return_value.poll.return_value = ProviderPoll(
            None,
            False,
            "awaiting_stability_confirmation",
            combat_lifecycle=_lifecycle(CombatLifecycleState.ACTIVE, match_id="M_live"),
        )
        runtime = ReadOnlyGameStatusProvider(lambda: target)
        observation = runtime.read()
        self.assertTrue(observation.game_detected)
        self.assertTrue(observation.attached)
        self.assertEqual(observation.lifecycle, "ACTIVE_COMBAT")
        self.assertEqual(observation.match_id, "M_live")
        self.assertEqual(observation.pid, 1234)
        runtime.close()
        self.assertEqual(target.closed, 1)

    @patch.object(desktop_runtime_module, "MemoryBoardStateProvider")
    def test_active_session_key_covers_dto_wait_without_lifecycle_object(
        self, provider_class: Mock
    ) -> None:
        target = _Target()
        provider_class.return_value.poll.return_value = ProviderPoll(
            None,
            False,
            "awaiting_transport_board_capture",
            session_key=CombatSessionKey(2, 0x1234, "M_wait"),
        )
        runtime = ReadOnlyGameStatusProvider(lambda: target)
        observation = runtime.read()
        self.assertEqual(observation.lifecycle, "ACTIVE_COMBAT")
        self.assertEqual(observation.match_id, "M_wait")
        self.assertIsNone(observation.error)
        self.assertIn("active_session_key", observation.provider_reason)

    @patch.object(desktop_runtime_module, "read_boss_lobby_runtime")
    @patch.object(desktop_runtime_module, "MemoryBoardStateProvider")
    def test_lobby_uses_canonical_boss_lobby_reader(
        self, provider_class: Mock, read_lobby: Mock
    ) -> None:
        target = _Target()
        provider_class.return_value.poll.return_value = ProviderPoll(
            None,
            False,
            "lobby",
            combat_lifecycle=_lifecycle(CombatLifecycleState.LOBBY),
        )
        candidate = SimpleNamespace(
            selection=SimpleNamespace(value="SELECTED"),
            identity=SimpleNamespace(boss_id="1289", boss_name="Starburst"),
        )
        read_lobby.return_value = SimpleNamespace(
            state=SimpleNamespace(value="BOSS_LOBBY"),
            branch="CHINH_PHUC_ROOM",
            chinh_phuc=SimpleNamespace(current_room_id="room-1289"),
            reasons=(),
            candidates=(candidate,),
        )
        runtime = ReadOnlyGameStatusProvider(lambda: target)
        observation = runtime.read()
        self.assertEqual(observation.lifecycle, "BOSS_LOBBY")
        self.assertEqual(observation.target_id, "1289")
        self.assertEqual(observation.target_name, "Starburst")
        self.assertEqual(observation.lobby_branch, "CHINH_PHUC_ROOM")
        self.assertEqual(observation.current_room_id, "room-1289")

    @patch.object(desktop_runtime_module, "MemoryBoardStateProvider")
    def test_process_exit_closes_attachment(self, provider_class: Mock) -> None:
        target = _Target(running=False)
        runtime = ReadOnlyGameStatusProvider(lambda: target)
        observation = runtime.read()
        self.assertFalse(observation.attached)
        self.assertEqual(observation.provider_reason, "process_exited")
        self.assertEqual(target.closed, 1)

    def test_runtime_and_cli_import_no_input_or_farm_command_module(self) -> None:
        runtime_source = inspect.getsource(desktop_runtime_module)
        cli_source = inspect.getsource(desktop_ui_tool)
        for forbidden in (
            "win32_input",
            "ForegroundClickExecutor",
            "tools.farm_run",
            "tools.basic_auto_bot",
            "AutomationControllerLease",
        ):
            self.assertNotIn(forbidden, runtime_source)
            self.assertNotIn(forbidden, cli_source)


class _SimpleRuntime:
    def read(self) -> RuntimeObservation:
        return RuntimeObservation(True, True, 1, "x64", "BOSS_LOBBY")

    def close(self) -> None:
        return None


class DesktopViewModelTests(unittest.TestCase):
    def test_control_commands_delegate_once_without_running_backend_inline(self) -> None:
        plane = Mock()
        plane.start_farm.return_value = "start"
        plane.request_graceful_stop.return_value = "graceful"
        plane.restore_game_foreground.return_value = "foreground"
        plane.emergency_stop.return_value = "emergency"
        plane.resume_from_checkpoint.return_value = "resume"
        poller = Mock()
        view_model = DesktopViewModel(plane, poller, stale_after_seconds=3.0)
        self.assertEqual(view_model.start_farm(), "start")
        self.assertEqual(view_model.request_graceful_stop(7), "graceful")
        self.assertEqual(view_model.restore_game_foreground(7), "foreground")
        self.assertEqual(view_model.emergency_stop(7), "emergency")
        self.assertEqual(view_model.resume_from_checkpoint(), "resume")
        plane.start_farm.assert_called_once_with()
        plane.request_graceful_stop.assert_called_once_with(7)
        plane.restore_game_foreground.assert_called_once_with(7)
        plane.emergency_stop.assert_called_once_with(7)
        plane.resume_from_checkpoint.assert_called_once_with()

    def test_stale_snapshot_is_explicitly_non_actionable(self) -> None:
        plane = DesktopControlPlane(_SimpleRuntime())
        plane.refresh()
        poller = SnapshotPoller(plane, interval_seconds=1.0)
        view_model = DesktopViewModel(plane, poller, stale_after_seconds=2.0)
        snapshot = plane.snapshot()
        presentation = view_model.presentation(
            now_monotonic=snapshot.sampled_monotonic + 3.0
        )
        self.assertIn("STALE / NON-ACTIONABLE", presentation.lifecycle)
        self.assertIn("READ-ONLY", presentation.read_only_notice)
        self.assertFalse(presentation.snapshot_actionable)
        self.assertEqual("STALE_RUNTIME_SNAPSHOT", presentation.operator_status)

    def test_editing_draft_does_not_poll_or_dispatch(self) -> None:
        runtime = Mock(spec=["read", "close"])
        runtime.read.return_value = RuntimeObservation(False, False)
        plane = DesktopControlPlane(runtime)
        poller = SnapshotPoller(plane, interval_seconds=1.0)
        view_model = DesktopViewModel(plane, poller, stale_after_seconds=3.0)
        config = view_model.apply_draft(
            play_style="careful",
            mana_priority="attack",
            intelligence="basic",
            boss_id="1289",
            boss_name="Starburst",
            target_completed_matches="5",
            max_technical_recoveries="1",
            max_match_attempts="8",
        )
        self.assertEqual(config.target_completed_matches, 5)
        runtime.read.assert_not_called()
        self.assertEqual(plane.snapshot().safety.nonzero(), {})

    def test_cli_exposes_only_read_only_options(self) -> None:
        parser = desktop_ui_tool.build_parser()
        destinations = {action.dest for action in parser._actions}
        for forbidden in (
            "start",
            "resume",
            "graceful_stop",
            "emergency_stop",
            "boss_entry",
        ):
            self.assertNotIn(forbidden, destinations)
        args = parser.parse_args(["--offline", "--smoke-seconds", "1"])
        self.assertTrue(args.offline)

    def test_smoke_gate_rejects_handled_render_errors(self) -> None:
        healthy = SimpleNamespace(
            render_ticks=5,
            handled_ui_errors=0,
            poller_alive_after_close=False,
        )
        render_error = SimpleNamespace(
            render_ticks=0,
            handled_ui_errors=5,
            poller_alive_after_close=False,
        )
        self.assertTrue(desktop_ui_tool.smoke_result_is_healthy(healthy))
        self.assertFalse(desktop_ui_tool.smoke_result_is_healthy(render_error))
        self.assertFalse(desktop_ui_tool.smoke_result_is_healthy(None))


if __name__ == "__main__":
    unittest.main()
