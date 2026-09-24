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
from tools.foreground_qte_lease_transport import (  # noqa: E402
    BoundedForegroundQteLease,
    NativeQteLeaseBackend,
    QteLeaseStatus,
)


class FakeClock:
    def __init__(self) -> None:
        self.value = 100.0

    def monotonic(self) -> float:
        return self.value

    def sleep(self, seconds: float) -> None:
        self.value += seconds


class FakeQteBackend:
    def __init__(self) -> None:
        self.pid = 123
        self.title = "PokiguardOnlines"
        self.geometry = ClientGeometry(100, 200, 1280, 640)
        self.visible = True
        self.iconic = False
        self.foreground = 99
        self.cursor = (40, 50)
        self.idle_age = 2.0
        self.pointer_pressed = False
        self.guard_acquire_ok = True
        self.guard_release_ok = True
        self.guard_transition_ok = True
        self.guard_active = False
        self.qte_input_guard_mode = "CURSOR_CONFINE"
        self.focus_calls: list[int] = []
        self.focus_failures_remaining = 0
        self.cursor_calls: list[tuple[int, int]] = []
        self.guard_calls: list[str] = []

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
        if self.focus_failures_remaining > 0:
            self.focus_failures_remaining -= 1
            return False
        self.foreground = hwnd
        return True

    def last_input_age_seconds(self) -> float | None:
        return self.idle_age

    def any_pointer_button_pressed(self) -> bool:
        return self.pointer_pressed

    def acquire_qte_input_guard(self) -> bool:
        self.guard_calls.append("acquire")
        if self.guard_acquire_ok:
            self.guard_active = True
        return self.guard_acquire_ok

    def release_qte_input_guard(self) -> bool:
        self.guard_calls.append("release")
        if self.guard_release_ok:
            self.guard_active = False
        return self.guard_release_ok

    def transition_qte_guard_to_keyboard_only(self) -> bool:
        self.guard_calls.append("mouse_to_keyboard")
        transitioned = self.guard_transition_ok and self.guard_active
        if transitioned:
            self.qte_input_guard_mode = "KEYBOARD_HOOK"
        return transitioned

    def qte_input_guard_active(self) -> bool:
        return self.guard_active


def exact_binding(backend: FakeQteBackend) -> ExactWindowBinding:
    return ExactWindowBinding(
        WindowBinding(5, backend.pid, backend.title, 1280, 640),
        backend.geometry,
    )


def armed(
    backend: FakeQteBackend,
    clock: FakeClock,
    **kwargs: object,
) -> BoundedForegroundQteLease:
    lease = BoundedForegroundQteLease(
        backend,
        sleeper=clock.sleep,
        monotonic=clock.monotonic,
        **kwargs,
    )
    lease.arm(exact_binding(backend), "qte:test")
    return lease


class BoundedForegroundQteLeaseTests(unittest.TestCase):
    def test_acquire_holds_session_then_release_restores_desktop(self) -> None:
        backend = FakeQteBackend()
        clock = FakeClock()
        events: list[tuple[str, dict]] = []
        lease = armed(
            backend,
            clock,
            event_sink=lambda event, fields: events.append((event, fields)),
        )

        acquired = lease.acquire(preflight=lambda: True)
        self.assertTrue(acquired.acquired)
        self.assertTrue(lease.active)
        self.assertEqual(backend.foreground, 5)
        self.assertTrue(backend.guard_active)

        backend.cursor = (700, 500)
        released = lease.release("QTE_PERFECT")

        self.assertTrue(released.released)
        self.assertFalse(lease.active)
        self.assertFalse(backend.guard_active)
        self.assertEqual(backend.cursor, (40, 50))
        self.assertEqual(backend.foreground, 99)
        self.assertEqual(backend.guard_calls, ["acquire", "release"])
        self.assertEqual(events[-1][0], "foreground_qte_lease_released")

    def test_qte_binding_returns_mouse_immediately_and_final_release_does_not_yank_it(self) -> None:
        backend = FakeQteBackend()
        clock = FakeClock()
        lease = armed(backend, clock)
        self.assertTrue(lease.acquire(preflight=lambda: True).acquired)
        backend.cursor = (700, 500)

        mouse = lease.release_mouse_for_keyboard_phase()

        self.assertTrue(mouse.released)
        self.assertTrue(mouse.mouse_released)
        self.assertTrue(mouse.keyboard_guard_active)
        self.assertEqual(backend.cursor, (40, 50))
        backend.cursor = (900, 600)
        released = lease.release("QTE_PERFECT")
        self.assertTrue(released.released)
        self.assertEqual(backend.cursor, (900, 600))
        self.assertEqual(
            backend.guard_calls,
            ["acquire", "mouse_to_keyboard", "release"],
        )

    def test_mouse_to_keyboard_transition_failure_keeps_full_guard_for_cleanup(self) -> None:
        backend = FakeQteBackend()
        backend.guard_transition_ok = False
        clock = FakeClock()
        lease = armed(backend, clock)
        self.assertTrue(lease.acquire(preflight=lambda: True).acquired)

        mouse = lease.release_mouse_for_keyboard_phase()

        self.assertFalse(mouse.released)
        self.assertTrue(lease.active)
        self.assertTrue(backend.guard_active)
        self.assertTrue(lease.release("FAIL_CLOSED").released)

    def test_focus_restore_retries_within_bound_after_one_windows_rejection(self) -> None:
        backend = FakeQteBackend()
        clock = FakeClock()
        events: list[tuple[str, dict]] = []
        lease = armed(
            backend,
            clock,
            event_sink=lambda event, fields: events.append((event, fields)),
            focus_timeout_seconds=0.75,
            focus_request_attempts=3,
        )
        self.assertTrue(lease.acquire(preflight=lambda: True).acquired)
        self.assertTrue(lease.release_mouse_for_keyboard_phase().released)
        backend.focus_failures_remaining = 1

        released = lease.release("QTE_PERFECT")

        self.assertTrue(released.released)
        self.assertEqual(backend.foreground, 99)
        self.assertEqual(backend.focus_calls[-2:], [99, 99])
        focus_event = next(
            fields
            for event, fields in events
            if event == "foreground_qte_focus_restore"
        )
        self.assertEqual(focus_event["attempts"], 2)
        self.assertTrue(focus_event["restored"])

    def test_focus_restore_is_best_effort_when_cursor_and_guard_release_cleanly(self) -> None:
        backend = FakeQteBackend()
        clock = FakeClock()
        lease = armed(
            backend,
            clock,
            focus_timeout_seconds=0.75,
            focus_request_attempts=3,
        )
        self.assertTrue(lease.acquire(preflight=lambda: True).acquired)
        self.assertTrue(lease.release_mouse_for_keyboard_phase().released)
        backend.focus_failures_remaining = 10

        released = lease.release("QTE_PERFECT")

        self.assertTrue(released.released)
        self.assertFalse(released.focus_restored)
        self.assertTrue(released.cursor_restored)
        self.assertFalse(backend.guard_active)
        self.assertEqual(backend.foreground, 5)

    def test_guard_failure_sends_no_authority_and_restores_focus(self) -> None:
        backend = FakeQteBackend()
        backend.guard_acquire_ok = False
        clock = FakeClock()
        lease = armed(backend, clock)

        result = lease.acquire(preflight=lambda: True)

        self.assertEqual(result.status, QteLeaseStatus.INPUT_GUARD_FAILED)
        self.assertFalse(lease.active)
        self.assertEqual(backend.foreground, 99)
        self.assertEqual(backend.guard_calls, ["acquire"])

    def test_stale_preflight_consumes_arm_without_focus_or_guard(self) -> None:
        backend = FakeQteBackend()
        clock = FakeClock()
        lease = armed(backend, clock)

        result = lease.acquire(preflight=lambda: False)

        self.assertEqual(result.status, QteLeaseStatus.STALE_ACTION)
        self.assertTrue(lease.consumed)
        self.assertFalse(lease.active)
        self.assertEqual(backend.focus_calls, [])
        self.assertEqual(backend.guard_calls, [])

    def test_held_mouse_times_out_without_focus_takeover(self) -> None:
        backend = FakeQteBackend()
        backend.pointer_pressed = True
        backend.idle_age = 0.0
        clock = FakeClock()
        lease = armed(backend, clock, idle_timeout_seconds=0.25)

        result = lease.acquire(preflight=lambda: True)

        self.assertEqual(result.status, QteLeaseStatus.USER_BUSY_TIMEOUT)
        self.assertEqual(backend.focus_calls, [])
        self.assertEqual(backend.guard_calls, [])

    def test_active_validation_fails_if_focus_or_guard_is_lost(self) -> None:
        backend = FakeQteBackend()
        clock = FakeClock()
        lease = armed(backend, clock)
        self.assertTrue(lease.acquire(preflight=lambda: True).acquired)
        self.assertTrue(lease.validate_active())

        backend.foreground = 88
        self.assertFalse(lease.validate_active())
        backend.foreground = 5
        backend.guard_active = False
        self.assertFalse(lease.validate_active())
        lease.release("TEST_CLEANUP")

    def test_duration_is_bounded(self) -> None:
        backend = FakeQteBackend()
        clock = FakeClock()
        lease = armed(backend, clock, maximum_duration_seconds=3.0)
        self.assertTrue(lease.acquire(preflight=lambda: True).acquired)

        clock.value += 3.1

        self.assertFalse(lease.validate_active())
        self.assertTrue(lease.release("TIMEOUT").released)

    def test_failed_guard_release_keeps_lease_active_for_finally_retry(self) -> None:
        backend = FakeQteBackend()
        clock = FakeClock()
        lease = armed(backend, clock)
        self.assertTrue(lease.acquire(preflight=lambda: True).acquired)
        backend.guard_release_ok = False

        first = lease.release("FIRST")

        self.assertEqual(first.status, QteLeaseStatus.RELEASE_INCOMPLETE)
        self.assertTrue(lease.active)
        self.assertEqual(backend.focus_calls, [5])
        backend.guard_release_ok = True
        second = lease.release("FINALLY_RETRY")
        self.assertTrue(second.released)
        self.assertFalse(lease.active)
        self.assertEqual(backend.foreground, 99)


class FakeKeyboardGuard:
    def __init__(self, acquire_ok: bool = True, release_ok: bool = True) -> None:
        self.acquire_ok = acquire_ok
        self.release_ok = release_ok
        self._active = False
        self.calls: list[str] = []

    @property
    def active(self) -> bool:
        return self._active

    def acquire(self) -> bool:
        self.calls.append("acquire")
        if self.acquire_ok:
            self._active = True
        return self.acquire_ok

    def release(self) -> bool:
        self.calls.append("release")
        if self.release_ok:
            self._active = False
        return self.release_ok


class FakeForegroundBackend:
    def __init__(self, mode: str) -> None:
        self.input_guard_mode: str | None = None
        self.requested_mode = mode
        self.block_calls: list[bool] = []
        self.keys: list[int] = []
        self.input_backend = self

    def block_user_input(self, blocked: bool) -> bool:
        self.block_calls.append(blocked)
        if blocked:
            self.input_guard_mode = self.requested_mode
        else:
            self.input_guard_mode = None
        return True

    def press_virtual_key(self, virtual_key: int) -> bool:
        self.keys.append(virtual_key)
        return True


class NativeQteLeaseBackendTests(unittest.TestCase):
    def test_cursor_confine_transitions_to_keyboard_only_before_injected_key(self) -> None:
        foreground = FakeForegroundBackend("CURSOR_CONFINE")
        keyboard = FakeKeyboardGuard()
        backend = NativeQteLeaseBackend(foreground, keyboard_guard=keyboard)

        self.assertTrue(backend.acquire_qte_input_guard())
        self.assertEqual(backend.qte_input_guard_mode, "CURSOR_CONFINE")
        self.assertFalse(backend.press_virtual_key(0x25))
        self.assertTrue(backend.transition_qte_guard_to_keyboard_only())
        self.assertEqual(backend.qte_input_guard_mode, "KEYBOARD_HOOK")
        self.assertTrue(backend.press_virtual_key(0x25))
        self.assertEqual(foreground.keys, [0x25])
        self.assertTrue(backend.release_qte_input_guard())
        self.assertEqual(keyboard.calls, ["acquire", "release"])
        self.assertEqual(foreground.block_calls, [True, False])

    def test_keyboard_hook_failure_keeps_cursor_guard_until_fail_closed_release(self) -> None:
        foreground = FakeForegroundBackend("CURSOR_CONFINE")
        keyboard = FakeKeyboardGuard(acquire_ok=False)
        backend = NativeQteLeaseBackend(foreground, keyboard_guard=keyboard)

        self.assertTrue(backend.acquire_qte_input_guard())
        self.assertFalse(backend.transition_qte_guard_to_keyboard_only())

        self.assertEqual(foreground.input_guard_mode, "CURSOR_CONFINE")
        self.assertEqual(foreground.block_calls, [True])
        self.assertFalse(backend.press_virtual_key(0x27))
        self.assertTrue(backend.release_qte_input_guard())
        self.assertEqual(foreground.block_calls, [True, False])

    def test_block_input_mode_transitions_to_keyboard_hook_then_unblocks_mouse(self) -> None:
        foreground = FakeForegroundBackend("BLOCK_INPUT")
        keyboard = FakeKeyboardGuard()
        backend = NativeQteLeaseBackend(foreground, keyboard_guard=keyboard)

        self.assertTrue(backend.acquire_qte_input_guard())
        self.assertEqual(backend.qte_input_guard_mode, "BLOCK_INPUT")
        self.assertEqual(keyboard.calls, [])
        self.assertTrue(backend.transition_qte_guard_to_keyboard_only())
        self.assertEqual(backend.qte_input_guard_mode, "KEYBOARD_HOOK")
        self.assertEqual(foreground.block_calls, [True, False])
        self.assertEqual(keyboard.calls, ["acquire"])
        self.assertTrue(backend.release_qte_input_guard())
        self.assertEqual(keyboard.calls, ["acquire", "release"])


if __name__ == "__main__":
    unittest.main()
