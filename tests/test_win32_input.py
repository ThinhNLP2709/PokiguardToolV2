from __future__ import annotations

from pathlib import Path
import sys
import unittest


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.win32_input import (
    BoardCalibration,
    ClickStatus,
    ClientGeometry,
    CoordinateSafetyError,
    ForegroundClickExecutor,
    WindowBinding,
    map_swap_to_pixels,
    provider_to_solver,
    runtime_to_provider,
    solver_to_screen,
    validate_adjacent_swap,
)


class FakeBackend:
    def __init__(self) -> None:
        self.geometry = ClientGeometry(100, 200, 1280, 720)
        self.foreground_values = [True] * 10
        self.clicks = 0
        self.positions: list[tuple[int, int]] = []

    def client_geometry(self, _hwnd: int) -> ClientGeometry | None:
        return self.geometry

    def is_foreground(self, _hwnd: int) -> bool:
        return self.foreground_values.pop(0) if self.foreground_values else True

    def window_pid(self, _hwnd: int) -> int | None:
        return 123

    def set_cursor_pos(self, x: int, y: int) -> bool:
        self.positions.append((x, y))
        return True

    def click_mouse(self) -> None:
        self.clicks += 1

    def virtual_screen(self) -> tuple[int, int, int, int]:
        return 0, 0, 4000, 2000


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
        plan = map_swap_to_pixels(
            (4, 2),
            (4, 3),
            BoardCalibration(),
            geometry,
            virtual_screen=(0, 0, 4000, 2000),
        )
        self.assertEqual(plan.first.client_x, int((0.360 + 2 * 0.041) * 1279))
        self.assertEqual(plan.first.client_y, int((0.150 + 4 * 0.076) * 719))
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


if __name__ == "__main__":
    unittest.main()
