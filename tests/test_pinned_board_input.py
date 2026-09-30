from __future__ import annotations

from pathlib import Path
import sys
import unittest


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.foreground_lease_transport import LeaseStatus, PinStatus
from pokiguard_v2.input_delivery import (
    ExactWindowBinding,
    InputDeliveryConfig,
    InputDeliveryDomain,
    InputDeliveryMode,
)
from pokiguard_v2.pinned_board_input import (
    PinnedBoardLeaseSettings,
    PinnedForegroundBoardSession,
    PinnedForegroundMouseSession,
    PinnedQteLeaseSettings,
)
from pokiguard_v2.win32_input import (
    BoardInputMode,
    ClientGeometry,
    ForegroundClickExecutor,
    WindowBinding,
)


class FakeClock:
    def __init__(self) -> None:
        self.value = 10.0

    def monotonic(self) -> float:
        return self.value

    def sleep(self, seconds: float) -> None:
        self.value += seconds


class FakeBackend:
    def __init__(self) -> None:
        self.pid = 123
        self.title = "PokiguardOnlines"
        self.geometry = ClientGeometry(100, 200, 1280, 640)
        self.foreground = 99
        self.cursor = (40, 50)
        self.topmost = False
        self.block_calls: list[bool] = []
        self.focus_calls: list[int] = []

    def window_pid(self, _hwnd: int) -> int | None:
        return self.pid

    def window_title(self, _hwnd: int) -> str | None:
        return self.title

    def client_geometry(self, _hwnd: int) -> ClientGeometry | None:
        return self.geometry

    def is_window_visible(self, _hwnd: int) -> bool:
        return True

    def is_iconic(self, _hwnd: int) -> bool:
        return False

    def foreground_window(self) -> int | None:
        return self.foreground

    def cursor_pos(self) -> tuple[int, int] | None:
        return self.cursor

    def set_cursor_pos(self, x: int, y: int) -> bool:
        self.cursor = (x, y)
        return True

    def restore_and_foreground(self, hwnd: int) -> bool:
        self.focus_calls.append(hwnd)
        self.foreground = hwnd
        return True

    def pin_topmost(self, _hwnd: int) -> bool:
        self.topmost = True
        return True

    def unpin_topmost(self, _hwnd: int) -> bool:
        self.topmost = False
        return True

    def is_topmost(self, _hwnd: int) -> bool:
        return self.topmost

    def last_input_age_seconds(self) -> float | None:
        return 2.0

    def any_input_pressed(self) -> bool:
        return False

    def any_pointer_button_pressed(self) -> bool:
        return False

    def block_user_input(self, blocked: bool) -> bool:
        self.block_calls.append(blocked)
        return True


def binding(backend: FakeBackend) -> ExactWindowBinding:
    return ExactWindowBinding(
        WindowBinding(5, backend.pid, backend.title, 1280, 640),
        backend.geometry,
    )


def session(
    backend: FakeBackend,
    clock: FakeClock,
    *,
    stopped=lambda: False,
) -> PinnedForegroundBoardSession:
    return PinnedForegroundBoardSession(
        config=InputDeliveryConfig(
            InputDeliveryMode.PINNED_FOREGROUND_LEASE_BETA
        ),
        binding=binding(backend),
        backend=backend,
        stop_requested=stopped,
        settings=PinnedBoardLeaseSettings(
            required_idle_seconds=0.20,
            idle_timeout_seconds=0.20,
            focus_settle_seconds=0.0,
            post_action_settle_seconds=0.0,
        ),
        sleeper=clock.sleep,
        monotonic=clock.monotonic,
    )


class PinnedForegroundBoardSessionTests(unittest.TestCase):
    def test_pure_origin_move_between_actions_rebases_next_mouse_lease(self) -> None:
        backend = FakeBackend()
        clock = FakeClock()
        events: list[tuple[str, dict]] = []
        board = PinnedForegroundBoardSession(
            config=InputDeliveryConfig(
                InputDeliveryMode.PINNED_FOREGROUND_LEASE_BETA
            ),
            binding=binding(backend),
            backend=backend,
            stop_requested=lambda: False,
            event_sink=lambda event, fields: events.append((event, fields)),
            settings=PinnedBoardLeaseSettings(
                required_idle_seconds=0.20,
                idle_timeout_seconds=0.20,
                focus_settle_seconds=0.0,
                post_action_settle_seconds=0.0,
            ),
            sleeper=clock.sleep,
            monotonic=clock.monotonic,
        )
        self.assertEqual(board.start().status, PinStatus.PINNED)
        backend.geometry = ClientGeometry(253, 31, 1280, 640)

        result = board.execute_swap(
            action_identity="match:1:swap:after-move",
            action=lambda: True,
            preflight=lambda: True,
            expected_cursor_after=backend.cursor,
        )

        self.assertEqual(result.status, LeaseStatus.COMPLETE)
        self.assertEqual(board.binding.geometry, backend.geometry)
        self.assertEqual(board._pin.binding.geometry, backend.geometry)
        rebase = next(
            fields
            for event, fields in events
            if event == "pinned_window_origin_rebased"
        )
        self.assertEqual(rebase["boundary"], "mouse:board_swap")
        self.assertEqual((rebase["deltaX"], rebase["deltaY"]), (153, -169))

    def test_normalized_mapping_rebases_before_calculating_screen_point(self) -> None:
        backend = FakeBackend()
        clock = FakeClock()
        board = session(backend, clock)
        board.start()
        backend.geometry = ClientGeometry(253, 31, 1280, 640)

        point = board.expected_cursor_for_normalized_point((0.5, 0.5))

        self.assertEqual(
            point,
            (253 + int(0.5 * 1279), 31 + int(0.5 * 639)),
        )
        self.assertEqual(board.binding.geometry, backend.geometry)

    def test_resize_between_actions_remains_fail_closed_and_unconsumed(self) -> None:
        backend = FakeBackend()
        clock = FakeClock()
        board = session(backend, clock)
        board.start()
        backend.geometry = ClientGeometry(100, 200, 1279, 640)
        actions = 0

        def action() -> bool:
            nonlocal actions
            actions += 1
            return True

        with self.assertRaisesRegex(RuntimeError, "WINDOW_CHANGED"):
            board.execute_swap(
                action_identity="match:1:swap:resize",
                action=action,
                preflight=lambda: True,
                expected_cursor_after=backend.cursor,
            )
        self.assertEqual(actions, 0)

        backend.geometry = ClientGeometry(100, 200, 1280, 640)
        result = board.execute_swap(
            action_identity="match:1:swap:resize",
            action=action,
            preflight=lambda: True,
            expected_cursor_after=backend.cursor,
        )
        self.assertEqual(result.status, LeaseStatus.COMPLETE)
        self.assertEqual(actions, 1)

    def test_pure_origin_move_rebases_before_qte_lease_is_armed(self) -> None:
        backend = FakeBackend()
        clock = FakeClock()
        mouse = session(backend, clock)
        mouse.start()
        backend.geometry = ClientGeometry(240, 80, 1280, 640)

        action = mouse.create_qte_lease(
            action_identity="qte:match-1:turn-3:card-120"
        )

        self.assertEqual(action.authority.binding.geometry, backend.geometry)
        self.assertEqual(mouse.binding.geometry, backend.geometry)

    def test_bound_executor_routes_cursor_moves_through_lease_backend(self) -> None:
        lease_backend = FakeBackend()
        source_backend = FakeBackend()
        clock = FakeClock()
        mouse = session(lease_backend, clock)
        source = ForegroundClickExecutor(
            source_backend,
            click_delay_seconds=0.42,
            cursor_settle_seconds=0.08,
            input_mode=BoardInputMode.DRAG,
        )

        bound = mouse.bind_executor(source)

        self.assertIs(bound.backend, lease_backend)
        self.assertIsNot(bound.backend, source_backend)
        self.assertEqual(bound.click_delay_seconds, source.click_delay_seconds)
        self.assertEqual(
            bound.cursor_settle_seconds,
            source.cursor_settle_seconds,
        )
        self.assertEqual(bound.input_mode, source.input_mode)
        self.assertIs(bound.swap_pacer, source.swap_pacer)

    def test_shared_mouse_session_accepts_each_non_qte_production_domain(self) -> None:
        backend = FakeBackend()
        clock = FakeClock()
        mouse = PinnedForegroundMouseSession(
            config=InputDeliveryConfig(
                InputDeliveryMode.PINNED_FOREGROUND_LEASE_BETA
            ),
            binding=binding(backend),
            backend=backend,
            stop_requested=lambda: False,
            settings=PinnedBoardLeaseSettings(
                required_idle_seconds=0.20,
                idle_timeout_seconds=0.20,
                focus_settle_seconds=0.0,
                post_action_settle_seconds=0.0,
            ),
            sleeper=clock.sleep,
            monotonic=clock.monotonic,
        )
        mouse.start()
        domains = (
            InputDeliveryDomain.BOSS_ENTRY,
            InputDeliveryDomain.BOARD_SWAP,
            InputDeliveryDomain.UI_CARD,
            InputDeliveryDomain.POSTMATCH_CONFIRM,
            InputDeliveryDomain.NAVIGATION_RECOVERY,
        )
        for index, domain in enumerate(domains):
            result = mouse.execute_mouse(
                domain=domain,
                action_identity=f"{domain.value}:{index}",
                action=lambda: True,
                preflight=lambda: True,
                expected_cursor_after=backend.cursor,
            )
            self.assertEqual(result.status, LeaseStatus.COMPLETE)

    def test_shared_mouse_session_rejects_qte_keyboard_domain(self) -> None:
        backend = FakeBackend()
        clock = FakeClock()
        mouse = session(backend, clock)
        mouse.start()
        with self.assertRaisesRegex(RuntimeError, "requires a mouse lease"):
            mouse.execute_mouse(
                domain=InputDeliveryDomain.PET_SKILL_QTE,
                action_identity="qte:must-stay-separate",
                action=lambda: True,
                preflight=lambda: True,
                expected_cursor_after=backend.cursor,
            )

    def test_shared_session_prepares_one_typed_qte_lease_without_unpinning(self) -> None:
        backend = FakeBackend()
        clock = FakeClock()
        mouse = session(backend, clock)
        mouse.start()

        action = mouse.create_qte_lease(
            action_identity="qte:match-1:turn-3:card-120",
            settings=PinnedQteLeaseSettings(
                required_idle_seconds=0.10,
                idle_timeout_seconds=0.10,
                focus_settle_seconds=0.0,
            ),
        )

        self.assertEqual(
            action.authority.domain,
            InputDeliveryDomain.PET_SKILL_QTE,
        )
        self.assertFalse(action.lease.active)
        self.assertTrue(backend.topmost)
        with self.assertRaisesRegex(RuntimeError, "already leased"):
            mouse.create_qte_lease(
                action_identity="qte:match-1:turn-3:card-120"
            )

    def test_qte_lease_requires_active_exact_topmost_session(self) -> None:
        backend = FakeBackend()
        clock = FakeClock()
        mouse = session(backend, clock)
        with self.assertRaisesRegex(RuntimeError, "not active"):
            mouse.create_qte_lease(action_identity="qte:not-started")
        mouse.start()
        backend.topmost = False
        with self.assertRaisesRegex(RuntimeError, "lost its topmost pin"):
            mouse.create_qte_lease(action_identity="qte:not-topmost")

    def test_normalized_cursor_mapping_uses_bound_client_geometry(self) -> None:
        backend = FakeBackend()
        clock = FakeClock()
        mouse = session(backend, clock)
        self.assertEqual(
            mouse.expected_cursor_for_normalized_point((0.5, 0.5)),
            (100 + int(0.5 * 1279), 200 + int(0.5 * 639)),
        )

    def test_foreground_mode_cannot_construct_beta_session(self) -> None:
        backend = FakeBackend()
        with self.assertRaisesRegex(ValueError, "beta delivery mode"):
            PinnedForegroundBoardSession(
                config=InputDeliveryConfig(),
                binding=binding(backend),
                backend=backend,
                stop_requested=lambda: False,
            )

    def test_one_swap_pins_takes_focus_guards_and_restores(self) -> None:
        backend = FakeBackend()
        clock = FakeClock()
        board = session(backend, clock)
        self.assertEqual(board.start().status, PinStatus.PINNED)
        preflights = 0

        def preflight() -> bool:
            nonlocal preflights
            preflights += 1
            return True

        def action() -> bool:
            backend.cursor = (700, 600)
            return True

        result = board.execute_swap(
            action_identity="match:1:swap:a",
            action=action,
            preflight=preflight,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.COMPLETE)
        self.assertGreaterEqual(preflights, 3)
        self.assertEqual(backend.block_calls, [True, False])
        self.assertEqual(backend.focus_calls, [5, 99])
        self.assertEqual(backend.cursor, (40, 50))
        self.assertEqual(board.close().status, PinStatus.UNPINNED)

    def test_pre_input_focus_takeover_is_retried_without_duplicate_action(self) -> None:
        backend = FakeBackend()
        clock = FakeClock()
        events: list[tuple[str, dict]] = []
        settle_calls = 0

        def sleeper(seconds: float) -> None:
            nonlocal settle_calls
            clock.sleep(seconds)
            if seconds == 0.40:
                settle_calls += 1
                if settle_calls == 1:
                    backend.foreground = 77

        board = PinnedForegroundBoardSession(
            config=InputDeliveryConfig(
                InputDeliveryMode.PINNED_FOREGROUND_LEASE_BETA
            ),
            binding=binding(backend),
            backend=backend,
            stop_requested=lambda: False,
            event_sink=lambda event, fields: events.append((event, fields)),
            settings=PinnedBoardLeaseSettings(
                required_idle_seconds=0.20,
                idle_timeout_seconds=0.20,
                focus_settle_seconds=0.40,
                post_action_settle_seconds=0.0,
                focus_takeover_attempts=3,
            ),
            sleeper=sleeper,
            monotonic=clock.monotonic,
        )
        board.start()
        actions = 0

        def action() -> bool:
            nonlocal actions
            actions += 1
            backend.cursor = (700, 600)
            return True

        result = board.execute_swap(
            action_identity="match:1:swap:focus-collision",
            action=action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.COMPLETE)
        self.assertEqual(actions, 1)
        self.assertEqual(backend.block_calls, [True, False, True, False])
        retries = [
            fields
            for event, fields in events
            if event == "pinned_mouse_focus_takeover_retry"
        ]
        self.assertEqual(len(retries), 1)
        self.assertEqual(retries[0]["attempt"], 1)
        self.assertEqual(retries[0]["nextAttempt"], 2)
        self.assertFalse(retries[0]["inputSent"])

    def test_post_focus_stale_preflight_sends_zero_and_releases_guard(self) -> None:
        backend = FakeBackend()
        clock = FakeClock()
        board = session(backend, clock)
        board.start()
        answers = iter((True, True, False))
        actions = 0

        def action() -> bool:
            nonlocal actions
            actions += 1
            return True

        result = board.execute_swap(
            action_identity="match:1:swap:stale",
            action=action,
            preflight=lambda: next(answers),
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.STALE_ACTION)
        self.assertEqual(actions, 0)
        self.assertEqual(backend.block_calls, [True, False])

    def test_stop_before_lease_is_zero_input(self) -> None:
        backend = FakeBackend()
        clock = FakeClock()
        board = session(backend, clock, stopped=lambda: True)
        board.start()
        actions = 0

        def action() -> bool:
            nonlocal actions
            actions += 1
            return True

        result = board.execute_swap(
            action_identity="match:1:swap:stop",
            action=action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )
        self.assertEqual(result.status, LeaseStatus.STOPPED)
        self.assertEqual(actions, 0)
        self.assertEqual(backend.focus_calls, [])

    def test_partial_action_fails_closed_and_cleans_up(self) -> None:
        backend = FakeBackend()
        clock = FakeClock()
        board = session(backend, clock)
        board.start()

        def action() -> bool:
            backend.cursor = (700, 600)
            return False

        result = board.execute_swap(
            action_identity="match:1:swap:partial",
            action=action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )
        self.assertEqual(result.status, LeaseStatus.ACTION_FAILED)
        self.assertEqual(backend.block_calls, [True, False])
        self.assertEqual(backend.cursor, (40, 50))

    def test_same_action_identity_cannot_be_rearmed(self) -> None:
        backend = FakeBackend()
        clock = FakeClock()
        board = session(backend, clock)
        board.start()

        def failed_action() -> bool:
            backend.cursor = (700, 600)
            return False

        first = board.execute_swap(
            action_identity="match:1:swap:once",
            action=failed_action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )
        self.assertEqual(first.status, LeaseStatus.ACTION_FAILED)
        with self.assertRaisesRegex(RuntimeError, "already leased"):
            board.execute_swap(
                action_identity="match:1:swap:once",
                action=lambda: True,
                preflight=lambda: True,
                expected_cursor_after=(700, 600),
            )

    def test_geometry_drift_rejects_pin(self) -> None:
        backend = FakeBackend()
        clock = FakeClock()
        board = session(backend, clock)
        backend.geometry = ClientGeometry(100, 200, 1279, 640)
        self.assertEqual(board.start().status, PinStatus.WINDOW_CHANGED)
        self.assertFalse(board.active)


if __name__ == "__main__":
    unittest.main()
