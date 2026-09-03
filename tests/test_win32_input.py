from __future__ import annotations

from pathlib import Path
import sys
import threading
import time
import unittest


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.win32_input import (
    AdaptiveSwapPacer,
    BoardCalibration,
    BoardInputMode,
    ClickStatus,
    ClientGeometry,
    CoordinateSafetyError,
    ForegroundClickExecutor,
    FarmControlHotkeyEdges,
    WindowBinding,
    map_swap_to_pixels,
    prepare_bound_window,
    provider_to_solver,
    runtime_to_provider,
    solver_to_screen,
    validate_adjacent_swap,
)


class FakeBackend:
    mouse_button_hold_seconds = 0.075

    def __init__(self) -> None:
        self.geometry = ClientGeometry(100, 200, 1280, 720)
        self.foreground_values = [True] * 10
        self.clicks = 0
        self.button_events: list[str] = []
        self.positions: list[tuple[int, int]] = []
        self.resize_calls: list[tuple[int, int]] = []
        self.restore_calls = 0
        self.pid = 123

    def client_geometry(self, _hwnd: int) -> ClientGeometry | None:
        return self.geometry

    def is_foreground(self, _hwnd: int) -> bool:
        return self.foreground_values.pop(0) if self.foreground_values else True

    def window_pid(self, _hwnd: int) -> int | None:
        return self.pid

    def set_cursor_pos(self, x: int, y: int) -> bool:
        self.positions.append((x, y))
        return True

    def click_mouse(self) -> None:
        self.clicks += 1

    def mouse_left_down(self) -> None:
        self.button_events.append("down")

    def mouse_left_up(self) -> None:
        self.button_events.append("up")

    def virtual_screen(self) -> tuple[int, int, int, int]:
        return 0, 0, 4000, 2000

    def restore_and_foreground(self, _hwnd: int) -> bool:
        self.restore_calls += 1
        self.foreground_values = [True] * 10
        return True

    def resize_client(self, _hwnd: int, width: int, height: int) -> bool:
        self.resize_calls.append((width, height))
        self.geometry = ClientGeometry(
            self.geometry.left,
            self.geometry.top,
            width,
            height,
        )
        return True


class CoordinatePipelineTests(unittest.TestCase):
    def test_runtime_flips_once_then_provider_solver_screen_are_identity(self) -> None:
        runtime = (7, 3)
        provider = runtime_to_provider(runtime)
        solver = provider_to_solver(provider)
        screen = solver_to_screen(solver)
        self.assertEqual(provider, (0, 3))
        self.assertEqual(solver, (0, 3))
        self.assertEqual(screen, (0, 3))

    def test_mapping_matches_v1_executor_formula_and_bounds(self) -> None:
        geometry = ClientGeometry(100, 200, 1280, 720)
        calibration = BoardCalibration()
        plan = map_swap_to_pixels(
            (4, 2),
            (4, 3),
            calibration,
            geometry,
            virtual_screen=(0, 0, 4000, 2000),
        )
        self.assertEqual(
            plan.first.client_x,
            int((calibration.first_center_x + 2 * calibration.step_x) * 1279),
        )
        self.assertEqual(
            plan.first.client_y,
            int((calibration.first_center_y + 4 * calibration.step_y) * 719),
        )
        left, top, right, bottom = plan.board_rect_client
        self.assertTrue(left <= plan.first.client_x <= right)
        self.assertTrue(top <= plan.first.client_y <= bottom)

    def test_non_adjacent_or_out_of_range_swap_fails(self) -> None:
        with self.assertRaises(CoordinateSafetyError):
            validate_adjacent_swap((0, 0), (0, 2))
        with self.assertRaises(CoordinateSafetyError):
            validate_adjacent_swap((-1, 0), (0, 0))


class ForegroundExecutorTests(unittest.TestCase):
    def test_confirmed_ui_point_sends_exactly_one_click(self) -> None:
        backend = FakeBackend()
        executor = ForegroundClickExecutor(backend, sleeper=lambda _value: None)
        binding = WindowBinding(5, 123, "Pokiguard", 1280, 720)
        result = executor.send_normalized_point(binding, (0.40, 0.65))
        self.assertTrue(result.sent)
        self.assertEqual(backend.clicks, 1)
        self.assertEqual(
            backend.positions,
            [(100 + int(0.40 * 1279), 200 + int(0.65 * 719))],
        )


class WindowPreparationTests(unittest.TestCase):
    def test_start_preflight_normalizes_exact_pid_to_canonical_client(self) -> None:
        backend = FakeBackend()
        backend.geometry = ClientGeometry(717, 206, 1181, 617)
        binding = WindowBinding(5, 123, "Pokiguard", 1181, 617)

        prepared = prepare_bound_window(
            binding,
            backend,
            sleeper=lambda _seconds: None,
        )

        self.assertTrue(prepared)
        self.assertEqual(backend.resize_calls, [(1280, 640)])
        self.assertEqual((backend.geometry.width, backend.geometry.height), (1280, 640))
        self.assertGreaterEqual(backend.restore_calls, 2)

    def test_start_preflight_wrong_pid_fails_without_resize(self) -> None:
        backend = FakeBackend()
        backend.pid = 999
        binding = WindowBinding(5, 123, "Pokiguard", 1280, 720)

        self.assertFalse(
            prepare_bound_window(binding, backend, sleeper=lambda _seconds: None)
        )
        self.assertEqual(backend.resize_calls, [])


class ForegroundExecutorContinuationTests(unittest.TestCase):
    def test_ui_hover_probe_moves_without_clicking(self) -> None:
        backend = FakeBackend()
        executor = ForegroundClickExecutor(backend, sleeper=lambda _value: None)
        binding = WindowBinding(5, 123, "Pokiguard", 1280, 720)
        status = executor.move_normalized_point(binding, (0.04, 0.095))
        self.assertEqual(status, ClickStatus.SENT)
        self.assertEqual(backend.clicks, 0)
        self.assertEqual(len(backend.positions), 1)

    def test_exactly_two_clicks_are_sent(self) -> None:
        backend = FakeBackend()
        executor = ForegroundClickExecutor(backend, sleeper=lambda _value: None)
        binding = WindowBinding(5, 123, "Pokiguard", 1280, 720)
        plan = map_swap_to_pixels(
            (4, 2), (4, 3), BoardCalibration(), backend.geometry
        )
        result = executor.send_swap(binding, plan)
        self.assertTrue(result.sent)
        self.assertEqual(backend.clicks, 2)
        self.assertEqual(backend.positions, [
            (plan.first.screen_x, plan.first.screen_y),
            (plan.second.screen_x, plan.second.screen_y),
        ])

    def test_drag_flicks_quickly_and_releases_past_second_gem_centre(self) -> None:
        backend = FakeBackend()
        delays: list[float] = []
        executor = ForegroundClickExecutor(
            backend,
            input_mode=BoardInputMode.DRAG,
            drag_duration_seconds=0.09,
            drag_steps=3,
            drag_overshoot_fraction=0.35,
            sleeper=delays.append,
        )
        binding = WindowBinding(5, 123, "Pokiguard", 1280, 720)
        plan = map_swap_to_pixels(
            (4, 2), (4, 3), BoardCalibration(), backend.geometry
        )

        result = executor.send_swap(binding, plan, remaining_seconds=12)

        self.assertTrue(result.sent)
        self.assertEqual(result.input_mode, "drag")
        self.assertEqual(result.drag_duration_seconds, 0.09)
        self.assertEqual(result.drag_steps, 3)
        self.assertEqual(result.inter_click_delay_seconds, None)
        self.assertEqual(backend.clicks, 0)
        self.assertEqual(backend.button_events, ["down", "up"])
        self.assertEqual(backend.positions[0], (plan.first.screen_x, plan.first.screen_y))
        expected_overshoot = round(
            (plan.second.screen_x - plan.first.screen_x) * 0.35
        )
        self.assertEqual(result.drag_overshoot_pixels, abs(expected_overshoot))
        self.assertEqual(
            backend.positions[-1],
            (plan.second.screen_x + expected_overshoot, plan.second.screen_y),
        )
        self.assertEqual(delays[0], 0.06)
        self.assertEqual(len(delays), 4)
        for delay in delays[1:]:
            self.assertAlmostEqual(delay, 0.03)

    def test_drag_flick_duration_is_not_stretched_by_lag_pacing(self) -> None:
        backend = FakeBackend()
        delays: list[float] = []
        executor = ForegroundClickExecutor(
            backend,
            input_mode="drag",
            drag_duration_seconds=0.10,
            drag_steps=2,
            sleeper=delays.append,
        )
        executor.note_swap_unconfirmed()
        binding = WindowBinding(5, 123, "Pokiguard", 1280, 720)
        plan = map_swap_to_pixels(
            (4, 2), (4, 3), BoardCalibration(), backend.geometry
        )

        result = executor.send_swap(binding, plan)

        self.assertEqual(result.pacing_mode, "SEVERE_LAG")
        self.assertEqual(result.drag_duration_seconds, 0.10)
        self.assertEqual(delays, [0.06, 0.05, 0.05])

    def test_drag_overshoot_stays_inside_board_in_all_edge_directions(self) -> None:
        binding = WindowBinding(5, 123, "Pokiguard", 1280, 720)
        for first, second in (
            ((0, 1), (0, 0)),
            ((0, 6), (0, 7)),
            ((1, 0), (0, 0)),
            ((6, 0), (7, 0)),
        ):
            with self.subTest(first=first, second=second):
                backend = FakeBackend()
                executor = ForegroundClickExecutor(
                    backend,
                    input_mode="drag",
                    sleeper=lambda _value: None,
                )
                plan = map_swap_to_pixels(
                    first, second, BoardCalibration(), backend.geometry
                )

                result = executor.send_swap(binding, plan)

                self.assertTrue(result.sent)
                end_x, end_y = backend.positions[-1]
                left, top, right, bottom = plan.board_rect_client
                self.assertLessEqual(backend.geometry.left + left, end_x)
                self.assertLessEqual(end_x, backend.geometry.left + right)
                self.assertLessEqual(backend.geometry.top + top, end_y)
                self.assertLessEqual(end_y, backend.geometry.top + bottom)

    def test_drag_focus_loss_after_down_always_releases_and_is_partial(self) -> None:
        backend = FakeBackend()
        # Initial status, pre-down check, then the first drag-step status.
        backend.foreground_values = [True, True, False]
        executor = ForegroundClickExecutor(
            backend,
            input_mode="drag",
            drag_steps=3,
            sleeper=lambda _value: None,
        )
        binding = WindowBinding(5, 123, "Pokiguard", 1280, 720)
        plan = map_swap_to_pixels(
            (4, 2), (4, 3), BoardCalibration(), backend.geometry
        )

        result = executor.send_swap(binding, plan)

        self.assertEqual(result.status, ClickStatus.PARTIAL_INPUT)
        self.assertEqual(result.sent_clicks, 1)
        self.assertEqual(backend.button_events, ["down", "up"])

    def test_swap_pacing_is_normal_until_recovery_or_delivery_failure(self) -> None:
        backend = FakeBackend()
        delays: list[float] = []
        executor = ForegroundClickExecutor(backend, sleeper=delays.append)
        binding = WindowBinding(5, 123, "Pokiguard", 1280, 720)
        plan = map_swap_to_pixels(
            (4, 2), (4, 3), BoardCalibration(), backend.geometry
        )

        normal = executor.send_swap(binding, plan, remaining_seconds=12)
        executor.arm_recovery_swap_pacing()
        recovered = executor.send_swap(binding, plan, remaining_seconds=12)
        executor.note_swap_unconfirmed()
        severe = executor.send_swap(binding, plan, remaining_seconds=12)

        self.assertEqual(
            delays,
            [
                0.06,
                0.35,
                0.06,
                0.06,
                1.0,
                0.06,
                0.06,
                1.5,
                0.06,
            ],
        )
        self.assertEqual(normal.cursor_settle_seconds, 0.06)
        self.assertEqual(normal.mouse_button_hold_seconds, 0.075)
        self.assertEqual(normal.pacing_mode, "NORMAL")
        self.assertEqual(recovered.pacing_mode, "RECOVERY_DEGRADED")
        self.assertEqual(severe.pacing_mode, "SEVERE_LAG")
        self.assertEqual(severe.lag_score, 3)

    def test_sustained_fast_acknowledgements_decay_one_level_only(self) -> None:
        pacer = AdaptiveSwapPacer()
        pacer.observe_unconfirmed()

        for _ in range(8):
            pacer.observe_acknowledged(2.5)

        decision = pacer.decision(remaining_seconds=12)
        self.assertEqual(decision.lag_score, 2)
        self.assertEqual(decision.delay_seconds, 1.0)
        self.assertEqual(decision.reason, "SUSTAINED_FAST_ACK_DECAY")

    def test_adaptive_delay_is_clamped_to_keep_second_click_before_deadline(self) -> None:
        pacer = AdaptiveSwapPacer()
        pacer.observe_unconfirmed()

        decision = pacer.decision(remaining_seconds=2.0)

        self.assertTrue(decision.timer_clamped)
        self.assertEqual(decision.delay_seconds, 0.75)
        self.assertEqual(decision.mode, "SEVERE_LAG")

    def test_focus_loss_before_second_click_never_clicks_desktop(self) -> None:
        backend = FakeBackend()
        # status/foreground + pre-mouse foreground for first, then second status false
        backend.foreground_values = [True, True, False]
        executor = ForegroundClickExecutor(backend, sleeper=lambda _value: None)
        binding = WindowBinding(5, 123, "Pokiguard", 1280, 720)
        plan = map_swap_to_pixels(
            (4, 2), (4, 3), BoardCalibration(), backend.geometry
        )
        result = executor.send_swap(binding, plan)
        self.assertEqual(result.status, ClickStatus.PARTIAL_INPUT)
        self.assertEqual(result.sent_clicks, 1)
        self.assertEqual(backend.clicks, 1)


class FarmControlAuthorityTests(unittest.TestCase):
    def test_emergency_ack_waits_for_started_atomic_input_then_denies_future(self) -> None:
        edges = FarmControlHotkeyEdges()
        input_started = threading.Event()
        release_input = threading.Event()
        input_finished = threading.Event()

        def operation() -> str:
            input_started.set()
            release_input.wait(2.0)
            input_finished.set()
            return "sent"

        worker = threading.Thread(target=lambda: edges.execute_if_authorized(operation))
        worker.start()
        self.assertTrue(input_started.wait(1.0))

        acknowledged = threading.Event()
        stopper = threading.Thread(
            target=lambda: (edges.request_emergency_stop(), acknowledged.set())
        )
        stopper.start()
        time.sleep(0.02)
        self.assertFalse(acknowledged.is_set())
        release_input.set()
        self.assertTrue(input_finished.wait(1.0))
        self.assertTrue(acknowledged.wait(1.0))
        worker.join(1.0)
        stopper.join(1.0)

        authorized, result = edges.execute_if_authorized(lambda: "forbidden")
        self.assertFalse(authorized)
        self.assertIsNone(result)
        self.assertEqual(edges.authorized_operations_started, 1)
        self.assertEqual(edges.authorized_operations_after_emergency_ack, 0)


if __name__ == "__main__":
    unittest.main()
