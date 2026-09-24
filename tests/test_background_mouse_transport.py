from __future__ import annotations

from pathlib import Path
import sys
from types import SimpleNamespace
import unittest
from unittest.mock import patch


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.win32_input import (  # noqa: E402
    BoardCalibration,
    ClientGeometry,
    WindowBinding,
    map_swap_to_pixels,
)
from tools.background_mouse_transport import (  # noqa: E402
    MK_LBUTTON,
    WM_LBUTTONDOWN,
    WM_LBUTTONUP,
    WM_MOUSEMOVE,
    BoundedBackgroundMouseTransport,
    ExactWindowBinding,
    ProbeCommand,
    ProbeOutcome,
    SwapPreState,
    TransportStatus,
    classify_probe_outcome,
    pack_client_lparam,
    runtime_proves_swap_accepted,
)


class FakeBackgroundBackend:
    def __init__(self) -> None:
        self.pid = 123
        self.title = "PokiguardOnlines"
        self.geometry = ClientGeometry(100, 200, 1280, 720)
        self.visible = True
        self.iconic = False
        self.foreground = 99
        self.cursor = (41, 53)
        self.queue_results: list[bool] = []
        self.messages: list[tuple[int, int, int, int]] = []

    def window_pid(self, _hwnd: int) -> int | None:
        return self.pid

    def window_title(self, _hwnd: int) -> str | None:
        return self.title

    def client_geometry(self, _hwnd: int) -> ClientGeometry | None:
        return self.geometry

    def is_window_visible(self, _hwnd: int) -> bool:
        return self.visible

    def is_iconic(self, _hwnd: int) -> bool:
        return self.iconic

    def foreground_window(self) -> int | None:
        return self.foreground

    def cursor_pos(self) -> tuple[int, int] | None:
        return self.cursor

    def post_message(
        self, hwnd: int, message: int, w_param: int, l_param: int
    ) -> bool:
        self.messages.append((hwnd, message, w_param, l_param))
        return self.queue_results.pop(0) if self.queue_results else True


def exact_binding(backend: FakeBackgroundBackend) -> ExactWindowBinding:
    return ExactWindowBinding(
        WindowBinding(5, backend.pid, backend.title, 1280, 720),
        backend.geometry,
    )


def armed_transport(
    backend: FakeBackgroundBackend,
    command: ProbeCommand,
    **kwargs: object,
) -> BoundedBackgroundMouseTransport:
    transport = BoundedBackgroundMouseTransport(backend, **kwargs)
    transport.arm(command, exact_binding(backend), f"probe:{command.value}")
    return transport


class BackgroundMouseTransportTests(unittest.TestCase):
    def test_lparam_packs_exact_client_coordinates(self) -> None:
        self.assertEqual(pack_client_lparam(0x1234, 0x5678), 0x56781234)
        with self.assertRaises(ValueError):
            pack_client_lparam(-1, 0)
        with self.assertRaises(ValueError):
            pack_client_lparam(0, 0x10000)

    def test_unarmed_transport_is_zero_input(self) -> None:
        backend = FakeBackgroundBackend()
        transport = BoundedBackgroundMouseTransport(backend)

        result = transport.send_start_single_click((0.5, 0.5), preflight=lambda: True)

        self.assertEqual(result.status, TransportStatus.UNARMED)
        self.assertEqual(backend.messages, [])

    def test_single_click_has_exact_order_client_lparam_and_no_cursor_move(self) -> None:
        backend = FakeBackgroundBackend()
        events: list[tuple[str, dict[str, object]]] = []
        transport = armed_transport(
            backend,
            ProbeCommand.START_SINGLE_CLICK,
            event_sink=lambda event, fields: events.append((event, fields)),
        )

        result = transport.send_start_single_click((0.25, 0.75), preflight=lambda: True)

        point = (int(0.25 * 1279), int(0.75 * 719))
        packed = pack_client_lparam(*point)
        self.assertEqual(result.status, TransportStatus.QUEUED)
        self.assertEqual(
            backend.messages,
            [
                (5, WM_MOUSEMOVE, 0, packed),
                (5, WM_LBUTTONDOWN, MK_LBUTTON, packed),
                (5, WM_LBUTTONUP, 0, packed),
            ],
        )
        self.assertTrue(result.cursor_unchanged)
        self.assertEqual([record.name for record in result.records], [
            "WM_MOUSEMOVE", "WM_LBUTTONDOWN", "WM_LBUTTONUP"
        ])
        self.assertEqual(len([event for event, _fields in events if event == "background_mouse_message"]), 3)

    @patch("pokiguard_v2.win32_input.random.uniform", return_value=0.0)
    def test_two_click_order_and_separation(self, _random: object) -> None:
        backend = FakeBackgroundBackend()
        sleeps: list[float] = []
        transport = armed_transport(
            backend,
            ProbeCommand.BOARD_TWO_CLICK,
            sleeper=sleeps.append,
            two_click_delay_seconds=0.42,
        )
        plan = map_swap_to_pixels(
            (4, 2), (4, 3), BoardCalibration(), backend.geometry
        )

        result = transport.send_board_two_click(plan, preflight=lambda: True)

        self.assertEqual(result.status, TransportStatus.QUEUED)
        self.assertEqual(sleeps, [0.025, 0.42, 0.025])
        self.assertEqual(
            [message for _hwnd, message, _wparam, _lparam in backend.messages],
            [
                WM_MOUSEMOVE, WM_LBUTTONDOWN, WM_LBUTTONUP,
                WM_MOUSEMOVE, WM_LBUTTONDOWN, WM_LBUTTONUP,
            ],
        )
        self.assertEqual(
            [wparam for _hwnd, _message, wparam, _lparam in backend.messages],
            [0, MK_LBUTTON, 0, 0, MK_LBUTTON, 0],
        )

    @patch("pokiguard_v2.win32_input.random.uniform", return_value=0.0)
    def test_stop_between_clicks_is_partial_and_never_retries(self, _random: object) -> None:
        backend = FakeBackgroundBackend()
        transport = armed_transport(
            backend,
            ProbeCommand.BOARD_TWO_CLICK,
            sleeper=lambda _seconds: None,
            stop_requested=lambda: len(backend.messages) >= 3,
        )
        plan = map_swap_to_pixels(
            (4, 2), (4, 3), BoardCalibration(), backend.geometry
        )

        first = transport.send_board_two_click(plan, preflight=lambda: True)
        second = transport.send_board_two_click(plan, preflight=lambda: True)

        self.assertEqual(first.status, TransportStatus.PARTIAL_INPUT)
        self.assertEqual(len(backend.messages), 3)
        self.assertEqual(second.status, TransportStatus.ALREADY_CONSUMED)
        self.assertEqual(len(backend.messages), 3)

    @patch("pokiguard_v2.win32_input.random.uniform", return_value=0.0)
    def test_drag_uses_held_moves_and_unconditional_up_after_stop(self, _random: object) -> None:
        backend = FakeBackgroundBackend()
        transport = armed_transport(
            backend,
            ProbeCommand.BOARD_DRAG,
            sleeper=lambda _seconds: None,
            stop_requested=lambda: len(backend.messages) >= 2,
            drag_steps=3,
        )
        plan = map_swap_to_pixels(
            (4, 2), (4, 3), BoardCalibration(), backend.geometry
        )

        result = transport.send_board_drag(plan, preflight=lambda: True)

        self.assertEqual(result.status, TransportStatus.PARTIAL_INPUT)
        self.assertEqual(
            [message for _hwnd, message, _wparam, _lparam in backend.messages],
            [WM_MOUSEMOVE, WM_LBUTTONDOWN, WM_LBUTTONUP],
        )
        self.assertTrue(result.records[-1].cleanup)

    @patch("pokiguard_v2.win32_input.random.uniform", return_value=0.0)
    def test_complete_drag_moves_with_mk_lbutton_then_releases(self, _random: object) -> None:
        backend = FakeBackgroundBackend()
        transport = armed_transport(
            backend,
            ProbeCommand.BOARD_DRAG,
            sleeper=lambda _seconds: None,
            drag_steps=3,
        )
        plan = map_swap_to_pixels(
            (4, 2), (4, 3), BoardCalibration(), backend.geometry
        )

        result = transport.send_board_drag(plan, preflight=lambda: True)

        self.assertEqual(result.status, TransportStatus.QUEUED)
        self.assertEqual(backend.messages[0][1:3], (WM_MOUSEMOVE, 0))
        self.assertEqual(backend.messages[1][1:3], (WM_LBUTTONDOWN, MK_LBUTTON))
        for message in backend.messages[2:-1]:
            self.assertEqual(message[1:3], (WM_MOUSEMOVE, MK_LBUTTON))
        self.assertEqual(len(backend.messages[2:-1]), 4)
        self.assertEqual(
            result.records[-2].name, "WM_MOUSEMOVE_HELD_OVERSHOOT"
        )
        self.assertEqual(backend.messages[-1][1:3], (WM_LBUTTONUP, 0))
        self.assertTrue(result.records[-1].cleanup)

    @patch("pokiguard_v2.win32_input.random.uniform", return_value=0.0)
    def test_drag_queue_failure_after_down_still_attempts_up(self, _random: object) -> None:
        backend = FakeBackgroundBackend()
        backend.queue_results = [True, True, False, True]
        transport = armed_transport(
            backend,
            ProbeCommand.BOARD_DRAG,
            sleeper=lambda _seconds: None,
            drag_steps=2,
        )
        plan = map_swap_to_pixels(
            (4, 2), (4, 3), BoardCalibration(), backend.geometry
        )

        result = transport.send_board_drag(plan, preflight=lambda: True)

        self.assertEqual(result.status, TransportStatus.PARTIAL_INPUT)
        self.assertEqual(backend.messages[-1][1], WM_LBUTTONUP)
        self.assertTrue(result.records[-1].queued)
        self.assertTrue(result.records[-1].cleanup)

    def test_single_click_holds_down_for_v1_bounded_interval(self) -> None:
        backend = FakeBackgroundBackend()
        sleeps: list[float] = []
        transport = armed_transport(
            backend,
            ProbeCommand.START_SINGLE_CLICK,
            sleeper=sleeps.append,
            click_hold_seconds=0.025,
        )

        result = transport.send_start_single_click(
            (0.5, 0.5), preflight=lambda: True
        )

        self.assertEqual(result.status, TransportStatus.QUEUED)
        self.assertEqual(sleeps, [0.025])
        self.assertEqual(
            [message for _hwnd, message, _wparam, _lparam in backend.messages],
            [WM_MOUSEMOVE, WM_LBUTTONDOWN, WM_LBUTTONUP],
        )

    def test_wrong_pid_geometry_minimized_and_foreground_are_rejected_before_arm(self) -> None:
        for field, value in (
            ("pid", 999),
            ("title", "Other window"),
            ("geometry", ClientGeometry(100, 200, 1279, 720)),
            ("iconic", True),
            ("foreground", 5),
        ):
            with self.subTest(field=field):
                backend = FakeBackgroundBackend()
                binding = exact_binding(backend)
                setattr(backend, field, value)
                transport = BoundedBackgroundMouseTransport(backend)
                with self.assertRaises(RuntimeError):
                    transport.arm(
                        ProbeCommand.START_SINGLE_CLICK, binding, "exact-start"
                    )
                self.assertEqual(backend.messages, [])

    def test_geometry_change_after_arm_stops_before_input(self) -> None:
        backend = FakeBackgroundBackend()
        transport = armed_transport(backend, ProbeCommand.START_SINGLE_CLICK)
        backend.geometry = ClientGeometry(100, 200, 1281, 720)

        result = transport.send_start_single_click((0.5, 0.5), preflight=lambda: True)

        self.assertEqual(result.status, TransportStatus.WINDOW_CHANGED)
        self.assertEqual(backend.messages, [])

    def test_stale_action_preflight_is_zero_input(self) -> None:
        backend = FakeBackgroundBackend()
        transport = armed_transport(backend, ProbeCommand.START_SINGLE_CLICK)

        result = transport.send_start_single_click(
            (0.5, 0.5), preflight=lambda: False
        )

        self.assertEqual(result.status, TransportStatus.STALE_ACTION)
        self.assertEqual(backend.messages, [])

    def test_click_failure_after_down_always_queues_cleanup_up(self) -> None:
        backend = FakeBackgroundBackend()
        backend.queue_results = [True, True, False, True]
        transport = armed_transport(backend, ProbeCommand.START_SINGLE_CLICK)

        result = transport.send_start_single_click(
            (0.5, 0.5), preflight=lambda: True
        )

        self.assertEqual(result.status, TransportStatus.PARTIAL_INPUT)
        self.assertEqual(
            [message for _hwnd, message, _wparam, _lparam in backend.messages],
            [WM_MOUSEMOVE, WM_LBUTTONDOWN, WM_LBUTTONUP, WM_LBUTTONUP],
        )
        self.assertFalse(result.records[-2].queued)
        self.assertTrue(result.records[-1].cleanup)
        self.assertTrue(result.records[-1].queued)

    def test_postmessage_false_is_not_acceptance(self) -> None:
        backend = FakeBackgroundBackend()
        backend.queue_results = [False]
        transport = armed_transport(backend, ProbeCommand.START_SINGLE_CLICK)

        result = transport.send_start_single_click((0.5, 0.5), preflight=lambda: True)

        self.assertEqual(result.status, TransportStatus.QUEUE_FAILED)
        self.assertEqual(
            classify_probe_outcome(result, authoritative_ack=True),
            ProbeOutcome.NOT_RUN,
        )

    def test_queued_without_ack_is_unconfirmed_and_never_promoted(self) -> None:
        backend = FakeBackgroundBackend()
        transport = armed_transport(backend, ProbeCommand.START_SINGLE_CLICK)

        result = transport.send_start_single_click((0.5, 0.5), preflight=lambda: True)

        self.assertEqual(result.status, TransportStatus.QUEUED)
        self.assertEqual(
            classify_probe_outcome(result, authoritative_ack=None),
            ProbeOutcome.UNCONFIRMED,
        )
        self.assertEqual(
            classify_probe_outcome(result, authoritative_ack=False, explicit_reject=True),
            ProbeOutcome.REJECTED,
        )

    def test_swap_ack_requires_exact_turn_sequence_owner_and_runtime_coordinates(self) -> None:
        pre = SwapPreState("match-1", 6, "local", 3, (4, 2), (4, 3))
        runtime = SimpleNamespace(
            match_id="match-1",
            turn=7,
            current_player="boss",
            local_username="local",
            local_move_sequence=4,
            last_move_sequence=4,
            last_move_from_col=2,
            last_move_from_row=3,
            last_move_to_col=3,
            last_move_to_row=3,
        )
        self.assertTrue(runtime_proves_swap_accepted(pre, runtime))
        for field, value in (
            ("turn", 6),
            ("current_player", "LOCAL"),
            ("local_move_sequence", 5),
            ("last_move_to_col", 4),
        ):
            with self.subTest(field=field):
                changed = SimpleNamespace(**vars(runtime))
                setattr(changed, field, value)
                self.assertFalse(runtime_proves_swap_accepted(pre, changed))


if __name__ == "__main__":
    unittest.main()
