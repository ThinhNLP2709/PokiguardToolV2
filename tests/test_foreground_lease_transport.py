from __future__ import annotations

from pathlib import Path
import sys
import unittest


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.win32_input import ClientGeometry, WindowBinding  # noqa: E402
from tools.background_mouse_transport import ExactWindowBinding  # noqa: E402
from tools.foreground_lease_transport import (  # noqa: E402
    BoundedForegroundLease,
    LeaseStatus,
    NativeForegroundLeaseBackend,
    PinStatus,
    PinnedWindowSession,
)


class FakeClock:
    def __init__(self) -> None:
        self.value = 100.0

    def monotonic(self) -> float:
        return self.value

    def sleep(self, seconds: float) -> None:
        self.value += seconds


class FakeLeaseBackend:
    def __init__(self) -> None:
        self.pid = 123
        self.title = "PokiguardOnlines"
        self.geometry = ClientGeometry(100, 200, 1280, 640)
        self.visible = True
        self.iconic = False
        self.foreground = 99
        self.cursor = (40, 50)
        self.idle_age = 2.0
        self.input_pressed = False
        self.block_results: list[bool] = []
        self.block_calls: list[bool] = []
        self.topmost = False
        self.pin_ok = True
        self.unpin_ok = True
        self.focus_denied: set[int] = set()
        self.focus_results: list[bool] = []
        self.focus_calls: list[int] = []
        self.cursor_calls: list[tuple[int, int]] = []

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

    def set_cursor_pos(self, x: int, y: int) -> bool:
        self.cursor_calls.append((x, y))
        self.cursor = (x, y)
        return True

    def restore_and_foreground(self, hwnd: int) -> bool:
        self.focus_calls.append(hwnd)
        if self.focus_results:
            granted = self.focus_results.pop(0)
            if granted:
                self.foreground = hwnd
            return granted
        if hwnd in self.focus_denied:
            return False
        self.foreground = hwnd
        return True

    def pin_topmost(self, _hwnd: int) -> bool:
        if self.pin_ok:
            self.topmost = True
        return self.pin_ok

    def unpin_topmost(self, _hwnd: int) -> bool:
        if self.unpin_ok:
            self.topmost = False
        return self.unpin_ok

    def is_topmost(self, _hwnd: int) -> bool:
        return self.topmost

    def last_input_age_seconds(self) -> float | None:
        return self.idle_age

    def any_input_pressed(self) -> bool:
        return self.input_pressed

    def block_user_input(self, blocked: bool) -> bool:
        self.block_calls.append(blocked)
        if self.block_results:
            return self.block_results.pop(0)
        return True


def exact_binding(backend: FakeLeaseBackend) -> ExactWindowBinding:
    return ExactWindowBinding(
        WindowBinding(5, backend.pid, backend.title, 1280, 640),
        backend.geometry,
    )


def armed_lease(
    backend: FakeLeaseBackend,
    clock: FakeClock,
    **kwargs: object,
) -> BoundedForegroundLease:
    lease = BoundedForegroundLease(
        backend,
        sleeper=clock.sleep,
        monotonic=clock.monotonic,
        **kwargs,
    )
    lease.arm(exact_binding(backend), "test:one-action")
    return lease


class PinnedWindowSessionTests(unittest.TestCase):
    def test_pin_and_close_are_no_activate_topmost_lifecycle(self) -> None:
        backend = FakeLeaseBackend()
        session = PinnedWindowSession(backend, exact_binding(backend))

        pinned = session.pin()
        unpinned = session.close()

        self.assertEqual(pinned.status, PinStatus.PINNED)
        self.assertEqual(unpinned.status, PinStatus.UNPINNED)
        self.assertFalse(backend.topmost)
        self.assertEqual(backend.foreground, 99)

    def test_stale_binding_rejects_pin(self) -> None:
        backend = FakeLeaseBackend()
        binding = exact_binding(backend)
        backend.pid = 999

        result = PinnedWindowSession(backend, binding).pin()

        self.assertEqual(result.status, PinStatus.WINDOW_INVALID)
        self.assertFalse(backend.topmost)


class NativeLeaseTelemetryTests(unittest.TestCase):
    def test_cursor_and_foreground_delegate_calls_are_counted(self) -> None:
        class Delegate:
            def set_cursor_pos(self, _x: int, _y: int) -> bool:
                return True

            def restore_and_foreground(self, _hwnd: int) -> bool:
                return True

        backend = NativeForegroundLeaseBackend(Delegate())

        self.assertTrue(backend.set_cursor_pos(10, 20))
        self.assertTrue(backend.restore_and_foreground(5))

        self.assertEqual(backend.cursor_set_requests, 1)
        self.assertEqual(backend.foreground_requests, 1)

    def test_direct_focus_failure_uses_one_provided_bridge_callback(self) -> None:
        class Delegate:
            def restore_and_foreground(self, _hwnd: int) -> bool:
                return False

        bridge_calls: list[int] = []
        backend = NativeForegroundLeaseBackend(
            Delegate(),
            foreground_bridge=lambda hwnd: bridge_calls.append(hwnd) or True,
        )

        self.assertTrue(backend.restore_and_foreground(5))

        self.assertEqual(bridge_calls, [5])
        self.assertEqual(backend.foreground_requests, 1)
        self.assertEqual(backend.focus_bridge_attempts, 1)
        self.assertEqual(backend.focus_bridge_successes, 1)

    def test_cursor_confine_fallback_tracks_executor_points_and_restores(self) -> None:
        class Delegate:
            mouse_button_hold_seconds = 0.05

            def __init__(self) -> None:
                self.cursor_calls: list[tuple[int, int]] = []

            def set_cursor_pos(self, x: int, y: int) -> bool:
                self.cursor_calls.append((x, y))
                return True

        delegate = Delegate()
        clip_calls: list[tuple[int, int, int, int] | None] = []
        backend = NativeForegroundLeaseBackend(
            delegate,
            block_input_call=lambda _blocked: False,
            get_clip_rect=lambda: (0, 0, 1920, 1080),
            set_clip_rect=lambda rect: clip_calls.append(rect) or True,
        )
        backend.cursor_pos = lambda: (40, 50)  # type: ignore[method-assign]

        self.assertTrue(backend.block_user_input(True))
        self.assertEqual(backend.input_guard_mode, "CURSOR_CONFINE")
        self.assertTrue(backend.set_cursor_pos(700, 600))
        self.assertTrue(backend.block_user_input(False))

        self.assertEqual(
            clip_calls,
            [(40, 50, 41, 51), (700, 600, 701, 601), (0, 0, 1920, 1080)],
        )
        self.assertEqual(delegate.cursor_calls, [(700, 600)])
        self.assertIsNone(backend.input_guard_mode)
        self.assertEqual(backend.last_input_guard_mode, "CURSOR_CONFINE")

    def test_cursor_confine_fallback_fails_closed_without_saved_clip(self) -> None:
        class Delegate:
            pass

        backend = NativeForegroundLeaseBackend(
            Delegate(),
            block_input_call=lambda _blocked: False,
            get_clip_rect=lambda: None,
            set_clip_rect=lambda _rect: True,
        )
        backend.cursor_pos = lambda: (40, 50)  # type: ignore[method-assign]

        self.assertFalse(backend.block_user_input(True))
        self.assertIsNone(backend.input_guard_mode)


class BoundedForegroundLeaseTests(unittest.TestCase):
    def test_unarmed_is_zero_input(self) -> None:
        backend = FakeLeaseBackend()
        clock = FakeClock()
        called = 0

        def action() -> bool:
            nonlocal called
            called += 1
            return True

        result = BoundedForegroundLease(
            backend,
            sleeper=clock.sleep,
            monotonic=clock.monotonic,
        ).execute(action, preflight=lambda: True, expected_cursor_after=(500, 500))

        self.assertEqual(result.status, LeaseStatus.UNARMED)
        self.assertEqual(called, 0)
        self.assertEqual(backend.focus_calls, [])

    def test_successful_lease_executes_once_then_restores_focus_and_cursor(self) -> None:
        backend = FakeLeaseBackend()
        clock = FakeClock()
        lease = armed_lease(backend, clock)
        called = 0

        def action() -> bool:
            nonlocal called
            called += 1
            backend.cursor = (700, 600)
            return True

        result = lease.execute(
            action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )
        second = lease.execute(
            action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.COMPLETE)
        self.assertTrue(result.action_succeeded)
        self.assertEqual(called, 1)
        self.assertEqual(backend.focus_calls, [5, 99])
        self.assertEqual(backend.cursor, (40, 50))
        self.assertTrue(result.focus_restored)
        self.assertTrue(result.cursor_restored)
        self.assertEqual(second.status, LeaseStatus.ALREADY_CONSUMED)

    def test_busy_user_timeout_sends_no_action_or_focus_request(self) -> None:
        backend = FakeLeaseBackend()
        backend.idle_age = 0.0
        backend.input_pressed = True
        clock = FakeClock()
        lease = armed_lease(
            backend,
            clock,
            required_idle_seconds=0.20,
            idle_timeout_seconds=0.20,
            poll_interval_seconds=0.05,
        )
        called = 0

        def action() -> bool:
            nonlocal called
            called += 1
            return True

        result = lease.execute(
            action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.USER_BUSY_TIMEOUT)
        self.assertEqual(called, 0)
        self.assertEqual(backend.focus_calls, [])

    def test_courtesy_timeout_can_take_over_when_no_input_is_held(self) -> None:
        backend = FakeLeaseBackend()
        backend.idle_age = 0.0
        clock = FakeClock()
        events: list[str] = []
        lease = armed_lease(
            backend,
            clock,
            required_idle_seconds=0.20,
            idle_timeout_seconds=0.20,
            poll_interval_seconds=0.05,
            focus_settle_seconds=0.0,
            allow_takeover_after_idle_timeout=True,
            event_sink=lambda event, _fields: events.append(event),
        )

        def action() -> bool:
            backend.cursor = (700, 600)
            return True

        result = lease.execute(
            action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.COMPLETE)
        self.assertIn("foreground_lease_courtesy_timeout", events)
        self.assertEqual(backend.focus_calls, [5, 99])

    def test_courtesy_timeout_never_takes_over_while_input_is_held(self) -> None:
        backend = FakeLeaseBackend()
        backend.idle_age = 0.0
        backend.input_pressed = True
        clock = FakeClock()
        lease = armed_lease(
            backend,
            clock,
            required_idle_seconds=0.20,
            idle_timeout_seconds=0.20,
            poll_interval_seconds=0.05,
            allow_takeover_after_idle_timeout=True,
        )

        result = lease.execute(
            lambda: True,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.USER_BUSY_TIMEOUT)
        self.assertEqual(backend.focus_calls, [])

    def test_courtesy_mouse_lease_ignores_held_keyboard_state(self) -> None:
        backend = FakeLeaseBackend()
        backend.idle_age = 0.0
        backend.input_pressed = True
        clock = FakeClock()
        lease = armed_lease(
            backend,
            clock,
            required_idle_seconds=0.20,
            idle_timeout_seconds=0.20,
            poll_interval_seconds=0.05,
            focus_settle_seconds=0.0,
            allow_takeover_after_idle_timeout=True,
            held_input_pressed=lambda: False,
        )

        def action() -> bool:
            backend.cursor = (700, 600)
            return True

        result = lease.execute(
            action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.COMPLETE)
        self.assertEqual(backend.focus_calls, [5, 99])

    def test_already_foreground_can_execute_without_focus_handoff(self) -> None:
        backend = FakeLeaseBackend()
        backend.foreground = 5
        clock = FakeClock()
        lease = armed_lease(
            backend,
            clock,
            focus_settle_seconds=0.0,
            allow_already_foreground=True,
        )

        def action() -> bool:
            backend.cursor = (700, 600)
            return True

        result = lease.execute(
            action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.COMPLETE)
        self.assertEqual(backend.focus_calls, [])
        self.assertTrue(result.focus_restored)
        self.assertEqual(backend.cursor, (40, 50))

    def test_focus_acquisition_retries_inside_one_bounded_lease(self) -> None:
        backend = FakeLeaseBackend()
        backend.focus_results = [False, True]
        clock = FakeClock()
        lease = armed_lease(
            backend,
            clock,
            focus_timeout_seconds=0.40,
            focus_request_attempts=2,
            focus_settle_seconds=0.0,
        )

        def action() -> bool:
            backend.cursor = (700, 600)
            return True

        result = lease.execute(
            action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.COMPLETE)
        self.assertEqual(backend.focus_calls, [5, 5, 99])

    def test_exclusive_input_wraps_action_and_releases_in_finally(self) -> None:
        backend = FakeLeaseBackend()
        clock = FakeClock()
        lease = armed_lease(
            backend,
            clock,
            focus_settle_seconds=0.0,
            require_exclusive_input=True,
        )

        def action() -> bool:
            self.assertEqual(backend.block_calls, [True])
            backend.cursor = (700, 600)
            return True

        result = lease.execute(
            action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.COMPLETE)
        self.assertEqual(backend.block_calls, [True, False])

    def test_post_action_settle_holds_guard_before_release(self) -> None:
        backend = FakeLeaseBackend()
        clock = FakeClock()
        events: list[tuple[str, dict[str, object]]] = []
        lease = armed_lease(
            backend,
            clock,
            focus_settle_seconds=0.0,
            require_exclusive_input=True,
            post_action_settle_seconds=0.20,
            event_sink=lambda event, fields: events.append((event, fields)),
        )

        def action() -> bool:
            self.assertEqual(backend.block_calls, [True])
            backend.cursor = (700, 600)
            return True

        before = clock.value
        result = lease.execute(
            action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.COMPLETE)
        self.assertGreaterEqual(clock.value - before, 0.20)
        self.assertEqual(backend.block_calls, [True, False])
        names = [event for event, _fields in events]
        self.assertLess(
            names.index("foreground_lease_post_action_settle"),
            names.index("foreground_lease_exclusive_input_release"),
        )

    def test_exclusive_input_failure_is_zero_action(self) -> None:
        backend = FakeLeaseBackend()
        backend.block_results = [False, False, False]
        clock = FakeClock()
        calls = 0
        lease = armed_lease(
            backend,
            clock,
            focus_settle_seconds=0.0,
            require_exclusive_input=True,
            exclusive_input_attempts=3,
        )

        def action() -> bool:
            nonlocal calls
            calls += 1
            return True

        result = lease.execute(
            action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.EXCLUSIVE_INPUT_FAILED)
        self.assertEqual(calls, 0)
        self.assertEqual(backend.block_calls, [True, True, True])

    def test_exclusive_input_releases_when_action_raises(self) -> None:
        backend = FakeLeaseBackend()
        clock = FakeClock()
        lease = armed_lease(
            backend,
            clock,
            focus_settle_seconds=0.0,
            require_exclusive_input=True,
        )

        def action() -> bool:
            raise RuntimeError("boom")

        result = lease.execute(
            action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.ACTION_EXCEPTION)
        self.assertEqual(backend.block_calls, [True, False])

    def test_exclusive_lock_replaces_post_focus_user_takeover_abort(self) -> None:
        backend = FakeLeaseBackend()
        clock = FakeClock()
        held_reads = 0

        def held_input() -> bool:
            nonlocal held_reads
            held_reads += 1
            return held_reads > 1

        lease = armed_lease(
            backend,
            clock,
            focus_settle_seconds=0.40,
            require_exclusive_input=True,
            held_input_pressed=held_input,
        )

        def action() -> bool:
            backend.cursor = (700, 600)
            return True

        result = lease.execute(
            action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.COMPLETE)
        self.assertEqual(held_reads, 1)
        self.assertEqual(backend.block_calls, [True, False])

    def test_focus_refusal_sends_zero_action(self) -> None:
        backend = FakeLeaseBackend()
        backend.focus_denied.add(5)
        clock = FakeClock()
        lease = armed_lease(backend, clock)
        called = 0

        def action() -> bool:
            nonlocal called
            called += 1
            return True

        result = lease.execute(
            action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.FOCUS_ACQUIRE_FAILED)
        self.assertEqual(called, 0)
        self.assertEqual(backend.focus_calls, [5])

    def test_stale_post_focus_preflight_releases_without_action(self) -> None:
        backend = FakeLeaseBackend()
        clock = FakeClock()
        lease = armed_lease(backend, clock)
        preflight_calls = 0
        action_calls = 0

        def preflight() -> bool:
            nonlocal preflight_calls
            preflight_calls += 1
            return preflight_calls < 3

        def action() -> bool:
            nonlocal action_calls
            action_calls += 1
            return True

        result = lease.execute(
            action,
            preflight=preflight,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.STALE_ACTION)
        self.assertEqual(action_calls, 0)
        self.assertEqual(backend.foreground, 99)
        self.assertTrue(result.focus_restored)

    def test_new_user_input_after_focus_acquire_releases_without_action(self) -> None:
        backend = FakeLeaseBackend()
        clock = FakeClock()
        lease = armed_lease(backend, clock)
        idle_reads = 0
        action_calls = 0

        def last_input_age() -> float:
            nonlocal idle_reads
            idle_reads += 1
            return 2.0 if idle_reads == 1 else 0.01

        backend.last_input_age_seconds = last_input_age  # type: ignore[method-assign]

        def action() -> bool:
            nonlocal action_calls
            action_calls += 1
            return True

        result = lease.execute(
            action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.USER_TAKEOVER_DURING_ACTION)
        self.assertEqual(action_calls, 0)
        self.assertEqual(backend.foreground, 99)
        self.assertTrue(result.focus_restored)

    def test_user_focus_takeover_is_not_overwritten(self) -> None:
        backend = FakeLeaseBackend()
        clock = FakeClock()
        lease = armed_lease(backend, clock)

        def action() -> bool:
            backend.cursor = (700, 600)
            backend.foreground = 77
            return True

        result = lease.execute(
            action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.USER_TAKEOVER_DURING_ACTION)
        self.assertTrue(result.user_took_focus)
        self.assertEqual(backend.foreground, 77)
        self.assertEqual(backend.focus_calls, [5])
        self.assertEqual(backend.cursor, (40, 50))

    def test_user_cursor_takeover_is_not_snapped_back(self) -> None:
        backend = FakeLeaseBackend()
        clock = FakeClock()
        lease = armed_lease(backend, clock)

        def action() -> bool:
            backend.cursor = (900, 700)
            return True

        result = lease.execute(
            action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.USER_TAKEOVER_DURING_ACTION)
        self.assertTrue(result.user_moved_cursor)
        self.assertIsNone(result.cursor_restored)
        self.assertEqual(backend.cursor, (900, 700))
        self.assertEqual(backend.foreground, 99)

    def test_action_exception_still_releases_owned_focus(self) -> None:
        backend = FakeLeaseBackend()
        clock = FakeClock()
        lease = armed_lease(backend, clock)

        def action() -> bool:
            backend.cursor = (700, 600)
            raise RuntimeError("boom")

        result = lease.execute(
            action,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.ACTION_EXCEPTION)
        self.assertEqual(backend.foreground, 99)
        self.assertEqual(backend.cursor, (40, 50))

    def test_changed_geometry_after_arm_stops_before_focus(self) -> None:
        backend = FakeLeaseBackend()
        clock = FakeClock()
        lease = armed_lease(backend, clock)
        backend.geometry = ClientGeometry(100, 200, 1279, 640)

        result = lease.execute(
            lambda: True,
            preflight=lambda: True,
            expected_cursor_after=(700, 600),
        )

        self.assertEqual(result.status, LeaseStatus.WINDOW_CHANGED)
        self.assertEqual(backend.focus_calls, [])


if __name__ == "__main__":
    unittest.main()
