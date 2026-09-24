"""Bounded same-desktop foreground lease for the Phase 4A.1-R2 probe.

The game stays visible as a topmost window.  One explicitly armed lease waits
for a short courtesy window, foregrounds the exact game HWND when necessary,
runs one typed action under an optional bounded physical-input lock, and then
conditionally restores the previous foreground window and cursor.

This is not background input.  It deliberately uses the existing accepted
foreground input path and never injects code or writes game memory.
"""

from __future__ import annotations

import ctypes
from ctypes import wintypes
from dataclasses import asdict, dataclass, is_dataclass
from enum import Enum
import os
import time
from typing import Any, Callable, Protocol

from pokiguard_v2.win32_input import ClientGeometry, WindowBinding
from tools.background_mouse_transport import ExactWindowBinding


class LeaseStatus(str, Enum):
    COMPLETE = "COMPLETE"
    UNARMED = "UNARMED"
    ALREADY_CONSUMED = "ALREADY_CONSUMED"
    WINDOW_INVALID = "WINDOW_INVALID"
    WINDOW_CHANGED = "WINDOW_CHANGED"
    GAME_ALREADY_FOREGROUND = "GAME_ALREADY_FOREGROUND"
    USER_BUSY_TIMEOUT = "USER_BUSY_TIMEOUT"
    STALE_ACTION = "STALE_ACTION"
    STOPPED = "STOPPED"
    FOCUS_ACQUIRE_FAILED = "FOCUS_ACQUIRE_FAILED"
    EXCLUSIVE_INPUT_FAILED = "EXCLUSIVE_INPUT_FAILED"
    ACTION_FAILED = "ACTION_FAILED"
    ACTION_EXCEPTION = "ACTION_EXCEPTION"
    USER_TAKEOVER_DURING_ACTION = "USER_TAKEOVER_DURING_ACTION"
    RELEASE_INCOMPLETE = "RELEASE_INCOMPLETE"


class PinStatus(str, Enum):
    PINNED = "PINNED"
    WINDOW_INVALID = "WINDOW_INVALID"
    WINDOW_CHANGED = "WINDOW_CHANGED"
    PIN_FAILED = "PIN_FAILED"
    NOT_PINNED = "NOT_PINNED"
    UNPINNED = "UNPINNED"
    UNPIN_FAILED = "UNPIN_FAILED"


@dataclass(frozen=True)
class PinResult:
    status: PinStatus
    reason: str

    @property
    def pinned(self) -> bool:
        return self.status is PinStatus.PINNED


@dataclass(frozen=True)
class LeaseResult:
    action_identity: str
    status: LeaseStatus
    reason: str
    action_attempted: bool
    action_succeeded: bool
    foreground_before: int | None
    foreground_after_acquire: int | None
    foreground_after_action: int | None
    foreground_final: int | None
    cursor_before: tuple[int, int] | None
    cursor_after_action: tuple[int, int] | None
    cursor_final: tuple[int, int] | None
    focus_restored: bool | None
    cursor_restored: bool | None
    user_took_focus: bool
    user_moved_cursor: bool
    idle_age_seconds: float | None
    idle_wait_seconds: float
    lease_duration_seconds: float


class ForegroundLeaseBackend(Protocol):
    def window_pid(self, hwnd: int) -> int | None: ...
    def window_title(self, hwnd: int) -> str | None: ...
    def client_geometry(self, hwnd: int) -> ClientGeometry | None: ...
    def is_window_visible(self, hwnd: int) -> bool: ...
    def is_iconic(self, hwnd: int) -> bool: ...
    def foreground_window(self) -> int | None: ...
    def cursor_pos(self) -> tuple[int, int] | None: ...
    def set_cursor_pos(self, x: int, y: int) -> bool: ...
    def restore_and_foreground(self, hwnd: int) -> bool: ...
    def pin_topmost(self, hwnd: int) -> bool: ...
    def unpin_topmost(self, hwnd: int) -> bool: ...
    def is_topmost(self, hwnd: int) -> bool: ...
    def last_input_age_seconds(self) -> float | None: ...
    def any_input_pressed(self) -> bool: ...
    def block_user_input(self, blocked: bool) -> bool: ...


def jsonable(value: Any) -> Any:
    if is_dataclass(value):
        return jsonable(asdict(value))
    if isinstance(value, Enum):
        return value.value
    if isinstance(value, dict):
        return {str(key): jsonable(item) for key, item in value.items()}
    if isinstance(value, (tuple, list)):
        return [jsonable(item) for item in value]
    return value


def _binding_failure(
    backend: ForegroundLeaseBackend,
    binding: ExactWindowBinding,
) -> LeaseStatus | None:
    hwnd = binding.window.hwnd
    if (
        backend.window_pid(hwnd) != binding.window.pid
        or not backend.is_window_visible(hwnd)
        or backend.is_iconic(hwnd)
    ):
        return LeaseStatus.WINDOW_INVALID
    if backend.window_title(hwnd) != binding.window.title:
        return LeaseStatus.WINDOW_CHANGED
    if backend.client_geometry(hwnd) != binding.geometry:
        return LeaseStatus.WINDOW_CHANGED
    return None


class PinnedWindowSession:
    """Keep the exact game window topmost without activating it."""

    def __init__(
        self,
        backend: ForegroundLeaseBackend,
        binding: ExactWindowBinding,
        *,
        event_sink: Callable[[str, dict[str, Any]], None] | None = None,
    ) -> None:
        self.backend = backend
        self.binding = binding
        self.event_sink = event_sink or (lambda _event, _fields: None)
        self._pinned = False

    def pin(self) -> PinResult:
        failure = _binding_failure(self.backend, self.binding)
        if failure is not None:
            status = (
                PinStatus.WINDOW_INVALID
                if failure is LeaseStatus.WINDOW_INVALID
                else PinStatus.WINDOW_CHANGED
            )
            result = PinResult(status, failure.value)
        elif not self.backend.pin_topmost(self.binding.window.hwnd):
            result = PinResult(PinStatus.PIN_FAILED, "SetWindowPos(HWND_TOPMOST) failed")
        elif not self.backend.is_topmost(self.binding.window.hwnd):
            result = PinResult(PinStatus.PIN_FAILED, "window is not topmost after request")
        else:
            self._pinned = True
            result = PinResult(PinStatus.PINNED, "exact game window pinned without activation")
        self.event_sink("foreground_lease_pin", jsonable(result))
        return result

    def close(self) -> PinResult:
        if not self._pinned:
            result = PinResult(PinStatus.NOT_PINNED, "session did not own a topmost pin")
        elif not self.backend.unpin_topmost(self.binding.window.hwnd):
            result = PinResult(PinStatus.UNPIN_FAILED, "SetWindowPos(HWND_NOTOPMOST) failed")
        elif self.backend.is_topmost(self.binding.window.hwnd):
            result = PinResult(PinStatus.UNPIN_FAILED, "window remains topmost after request")
        else:
            self._pinned = False
            result = PinResult(PinStatus.UNPINNED, "topmost pin released")
        self.event_sink("foreground_lease_unpin", jsonable(result))
        return result

    def __enter__(self) -> "PinnedWindowSession":
        result = self.pin()
        if not result.pinned:
            raise RuntimeError(result.reason)
        return self

    def __exit__(self, _exc_type: Any, _exc: Any, _traceback: Any) -> None:
        self.close()


class BoundedForegroundLease:
    """One arm permits one foreground takeover and one typed action."""

    def __init__(
        self,
        backend: ForegroundLeaseBackend,
        *,
        sleeper: Callable[[float], None] = time.sleep,
        monotonic: Callable[[], float] = time.monotonic,
        stop_requested: Callable[[], bool] = lambda: False,
        event_sink: Callable[[str, dict[str, Any]], None] | None = None,
        required_idle_seconds: float = 0.45,
        idle_timeout_seconds: float = 8.0,
        poll_interval_seconds: float = 0.05,
        focus_timeout_seconds: float = 0.75,
        focus_settle_seconds: float = 0.08,
        cursor_tolerance_pixels: int = 3,
        allow_takeover_after_idle_timeout: bool = False,
        allow_already_foreground: bool = False,
        held_input_pressed: Callable[[], bool] | None = None,
        focus_request_attempts: int = 1,
        require_exclusive_input: bool = False,
        exclusive_input_attempts: int = 1,
        exclusive_input_retry_seconds: float = 0.05,
        post_action_settle_seconds: float = 0.0,
    ) -> None:
        if not 0.20 <= required_idle_seconds <= 2.0:
            raise ValueError("required_idle_seconds must be between 0.20 and 2.0")
        if not required_idle_seconds <= idle_timeout_seconds <= 30.0:
            raise ValueError("idle_timeout_seconds is outside the bounded range")
        if not 0.01 <= poll_interval_seconds <= 0.25:
            raise ValueError("poll_interval_seconds must be between 0.01 and 0.25")
        if not 0.10 <= focus_timeout_seconds <= 2.0:
            raise ValueError("focus_timeout_seconds must be between 0.10 and 2.0")
        if not 0.0 <= focus_settle_seconds <= 1.0:
            raise ValueError("focus_settle_seconds must be between 0 and 1.0")
        if not 0 <= cursor_tolerance_pixels <= 12:
            raise ValueError("cursor_tolerance_pixels must be between 0 and 12")
        if not 1 <= focus_request_attempts <= 5:
            raise ValueError("focus_request_attempts must be between 1 and 5")
        if not 1 <= exclusive_input_attempts <= 5:
            raise ValueError("exclusive_input_attempts must be between 1 and 5")
        if not 0.01 <= exclusive_input_retry_seconds <= 0.25:
            raise ValueError(
                "exclusive_input_retry_seconds must be between 0.01 and 0.25"
            )
        if not 0.0 <= post_action_settle_seconds <= 0.50:
            raise ValueError("post_action_settle_seconds must be between 0 and 0.50")
        self.backend = backend
        self.sleeper = sleeper
        self.monotonic = monotonic
        self.stop_requested = stop_requested
        self.event_sink = event_sink or (lambda _event, _fields: None)
        self.required_idle_seconds = float(required_idle_seconds)
        self.idle_timeout_seconds = float(idle_timeout_seconds)
        self.poll_interval_seconds = float(poll_interval_seconds)
        self.focus_timeout_seconds = float(focus_timeout_seconds)
        self.focus_settle_seconds = float(focus_settle_seconds)
        self.cursor_tolerance_pixels = int(cursor_tolerance_pixels)
        self.allow_takeover_after_idle_timeout = bool(
            allow_takeover_after_idle_timeout
        )
        self.allow_already_foreground = bool(allow_already_foreground)
        self.held_input_pressed = held_input_pressed or backend.any_input_pressed
        self.focus_request_attempts = int(focus_request_attempts)
        self.require_exclusive_input = bool(require_exclusive_input)
        self.exclusive_input_attempts = int(exclusive_input_attempts)
        self.exclusive_input_retry_seconds = float(exclusive_input_retry_seconds)
        self.post_action_settle_seconds = float(post_action_settle_seconds)
        self._armed: tuple[ExactWindowBinding, str] | None = None
        self._consumed = False

    def arm(self, binding: ExactWindowBinding, action_identity: str) -> None:
        if self._armed is not None or self._consumed:
            raise RuntimeError("this foreground lease has already been armed")
        if not action_identity.strip():
            raise ValueError("action_identity is required")
        failure = _binding_failure(self.backend, binding)
        if failure is not None:
            raise RuntimeError(f"cannot arm: {failure.value}")
        self._armed = (binding, action_identity)
        self.event_sink(
            "foreground_lease_armed",
            {"actionIdentity": action_identity, "hwnd": binding.window.hwnd},
        )

    def execute(
        self,
        action: Callable[[], bool],
        *,
        preflight: Callable[[], bool],
        expected_cursor_after: tuple[int, int] | None,
    ) -> LeaseResult:
        if self._consumed:
            return self._early_result(
                LeaseStatus.ALREADY_CONSUMED,
                "the one-shot lease was already consumed",
            )
        if self._armed is None:
            return self._early_result(LeaseStatus.UNARMED, "lease is not armed")
        binding, identity = self._armed
        self._consumed = True
        self._armed = None

        failure = _binding_failure(self.backend, binding)
        if failure is not None:
            return self._early_result(failure, "exact game window changed", identity)
        if self.stop_requested():
            return self._early_result(LeaseStatus.STOPPED, "stop requested", identity)
        if not self._safe_preflight(preflight):
            return self._early_result(
                LeaseStatus.STALE_ACTION, "action preflight rejected", identity
            )

        wait_started = self.monotonic()
        idle_age: float | None = None
        courtesy_timeout_takeover = False
        while True:
            if self.stop_requested():
                return self._early_result(
                    LeaseStatus.STOPPED,
                    "stop requested while waiting for user idle",
                    identity,
                    idle_wait_seconds=max(0.0, self.monotonic() - wait_started),
                )
            idle_age = self.backend.last_input_age_seconds()
            if (
                idle_age is not None
                and idle_age >= self.required_idle_seconds
                and not self.held_input_pressed()
            ):
                break
            elapsed = max(0.0, self.monotonic() - wait_started)
            if elapsed >= self.idle_timeout_seconds:
                if (
                    self.allow_takeover_after_idle_timeout
                    and not self.held_input_pressed()
                ):
                    courtesy_timeout_takeover = True
                    self.event_sink(
                        "foreground_lease_courtesy_timeout",
                        {
                            "actionIdentity": identity,
                            "idleAgeSeconds": idle_age,
                            "idleWaitSeconds": elapsed,
                            "takeoverAllowed": True,
                        },
                    )
                    break
                return self._early_result(
                    LeaseStatus.USER_BUSY_TIMEOUT,
                    "user did not become idle inside the bounded wait",
                    identity,
                    idle_age_seconds=idle_age,
                    idle_wait_seconds=elapsed,
                )
            self.sleeper(self.poll_interval_seconds)

        idle_wait = max(0.0, self.monotonic() - wait_started)
        failure = _binding_failure(self.backend, binding)
        if failure is not None:
            return self._early_result(
                failure,
                "exact game window changed while waiting for idle",
                identity,
                idle_age_seconds=idle_age,
                idle_wait_seconds=idle_wait,
            )
        if not self._safe_preflight(preflight):
            return self._early_result(
                LeaseStatus.STALE_ACTION,
                "action became stale while waiting for idle",
                identity,
                idle_age_seconds=idle_age,
                idle_wait_seconds=idle_wait,
            )

        foreground_before = self.backend.foreground_window()
        cursor_before = self.backend.cursor_pos()
        game_already_foreground = foreground_before == binding.window.hwnd
        if game_already_foreground and not self.allow_already_foreground:
            return self._result(
                identity,
                LeaseStatus.GAME_ALREADY_FOREGROUND,
                "lease requires a real foreground handoff",
                False,
                False,
                foreground_before,
                foreground_before,
                foreground_before,
                foreground_before,
                cursor_before,
                cursor_before,
                cursor_before,
                None,
                None,
                False,
                False,
                idle_age,
                idle_wait,
                0.0,
            )

        lease_started = self.monotonic()
        requested = True
        focus_request_count = 0
        if not game_already_foreground:
            focus_deadline = self.monotonic() + self.focus_timeout_seconds
            requested = False
            attempt_window = self.focus_timeout_seconds / self.focus_request_attempts
            while (
                self.backend.foreground_window() != binding.window.hwnd
                and self.monotonic() < focus_deadline
                and not self.stop_requested()
                and focus_request_count < self.focus_request_attempts
            ):
                focus_request_count += 1
                requested = bool(
                    self.backend.restore_and_foreground(binding.window.hwnd)
                ) or requested
                attempt_deadline = min(
                    focus_deadline,
                    self.monotonic() + attempt_window,
                )
                while (
                    self.backend.foreground_window() != binding.window.hwnd
                    and self.monotonic() < attempt_deadline
                    and not self.stop_requested()
                ):
                    self.sleeper(self.poll_interval_seconds)
        foreground_after_acquire = self.backend.foreground_window()
        if not requested or foreground_after_acquire != binding.window.hwnd:
            return self._result(
                identity,
                LeaseStatus.FOCUS_ACQUIRE_FAILED,
                "Windows did not grant foreground ownership",
                False,
                False,
                foreground_before,
                foreground_after_acquire,
                foreground_after_acquire,
                foreground_after_acquire,
                cursor_before,
                self.backend.cursor_pos(),
                self.backend.cursor_pos(),
                None,
                None,
                False,
                False,
                idle_age,
                idle_wait,
                max(0.0, self.monotonic() - lease_started),
            )

        self.event_sink(
            "foreground_lease_acquired",
            {
                "actionIdentity": identity,
                "foregroundBefore": foreground_before,
                "foregroundGame": foreground_after_acquire,
                "gameAlreadyForeground": game_already_foreground,
                "focusRequestCount": focus_request_count,
                "focusSettleSeconds": self.focus_settle_seconds,
                "focusBridgeAttempts": getattr(
                    self.backend, "focus_bridge_attempts", None
                ),
                "focusBridgeSuccesses": getattr(
                    self.backend, "focus_bridge_successes", None
                ),
            },
        )
        action_attempted = False
        action_succeeded = False
        action_exception: Exception | None = None
        exclusive_input_acquired = False
        exclusive_input_released: bool | None = None
        exclusive_attempt_count = 0
        if self.require_exclusive_input:
            while exclusive_attempt_count < self.exclusive_input_attempts:
                exclusive_attempt_count += 1
                if self.backend.block_user_input(True):
                    exclusive_input_acquired = True
                    break
                if exclusive_attempt_count < self.exclusive_input_attempts:
                    self.sleeper(self.exclusive_input_retry_seconds)
            self.event_sink(
                "foreground_lease_exclusive_input_acquire",
                {
                    "actionIdentity": identity,
                    "attempts": exclusive_attempt_count,
                    "acquired": exclusive_input_acquired,
                    "mode": getattr(self.backend, "input_guard_mode", None),
                    "blockInputError": getattr(
                        self.backend, "block_input_error", None
                    ),
                },
            )
        if self.focus_settle_seconds:
            self.sleeper(self.focus_settle_seconds)
        post_focus_idle_age = self.backend.last_input_age_seconds()
        if self.require_exclusive_input and not exclusive_input_acquired:
            reason = "bounded physical-input lock was not acquired"
            pre_action_status = LeaseStatus.EXCLUSIVE_INPUT_FAILED
        elif self.stop_requested():
            reason = "stop requested after focus acquisition and before input"
            pre_action_status = LeaseStatus.STOPPED
        elif (
            not self.require_exclusive_input
            and (
                self.held_input_pressed()
                or (
                    not courtesy_timeout_takeover
                    and (
                        post_focus_idle_age is None
                        or post_focus_idle_age < self.required_idle_seconds
                    )
                )
            )
        ):
            reason = "new user input detected after focus acquisition"
            pre_action_status = LeaseStatus.USER_TAKEOVER_DURING_ACTION
        elif (
            _binding_failure(self.backend, binding) is not None
            or self.backend.foreground_window() != binding.window.hwnd
            or not self._safe_preflight(preflight)
        ):
            reason = "post-focus preflight rejected before input"
            pre_action_status = LeaseStatus.STALE_ACTION
        else:
            action_attempted = True
            reason = "typed foreground action returned failure"
            pre_action_status = LeaseStatus.ACTION_FAILED
            try:
                self.event_sink(
                    "foreground_lease_action_begin",
                    {"actionIdentity": identity},
                )
                action_succeeded = bool(action())
                self.event_sink(
                    "foreground_lease_action_end",
                    {
                        "actionIdentity": identity,
                        "actionSucceeded": action_succeeded,
                    },
                )
            except Exception as exc:  # log bounded metadata, then release
                action_exception = exc

        if action_succeeded and self.post_action_settle_seconds:
            # Unity samples legacy mouse state on rendered frames. Keep the
            # second endpoint, focus and cursor guard stable briefly after the
            # final mouse-up so returning the user's cursor cannot race the
            # game's deferred click processing during the opening turn.
            self.event_sink(
                "foreground_lease_post_action_settle",
                {
                    "actionIdentity": identity,
                    "seconds": self.post_action_settle_seconds,
                },
            )
            self.sleeper(self.post_action_settle_seconds)

        if exclusive_input_acquired:
            exclusive_input_released = False
            release_attempts = 0
            while release_attempts < 5:
                release_attempts += 1
                if self.backend.block_user_input(False):
                    exclusive_input_released = True
                    break
                if release_attempts < 5:
                    self.sleeper(self.exclusive_input_retry_seconds)
            self.event_sink(
                "foreground_lease_exclusive_input_release",
                {
                    "actionIdentity": identity,
                    "attempts": release_attempts,
                    "released": exclusive_input_released,
                    "mode": getattr(self.backend, "last_input_guard_mode", None),
                },
            )

        foreground_after_action = self.backend.foreground_window()
        cursor_after_action = self.backend.cursor_pos()
        user_took_focus = foreground_after_action not in (
            None,
            binding.window.hwnd,
        )
        user_moved_cursor = bool(
            action_attempted
            and expected_cursor_after is not None
            and cursor_after_action is not None
            and not self._cursor_near(cursor_after_action, expected_cursor_after)
        )

        focus_restored: bool | None = None
        if (
            foreground_after_action == binding.window.hwnd
            and foreground_before
            and foreground_before != binding.window.hwnd
        ):
            restore_requested = self.backend.restore_and_foreground(foreground_before)
            restore_deadline = self.monotonic() + self.focus_timeout_seconds
            while self.monotonic() < restore_deadline:
                current_foreground = self.backend.foreground_window()
                if current_foreground == foreground_before:
                    break
                if current_foreground not in (None, binding.window.hwnd):
                    # A third window now owns focus; treat it as a fresh user
                    # choice and never overwrite it.
                    break
                self.sleeper(self.poll_interval_seconds)
            focus_restored = self.backend.foreground_window() == foreground_before
            self.event_sink(
                "foreground_lease_focus_release",
                {
                    "actionIdentity": identity,
                    "requested": restore_requested,
                    "targetHwnd": foreground_before,
                    "restored": focus_restored,
                    "foregroundAfter": self.backend.foreground_window(),
                    "focusBridgeAttempts": getattr(
                        self.backend, "focus_bridge_attempts", None
                    ),
                    "focusBridgeSuccesses": getattr(
                        self.backend, "focus_bridge_successes", None
                    ),
                },
            )
        elif (
            foreground_before == binding.window.hwnd
            and foreground_after_action == binding.window.hwnd
        ):
            focus_restored = True
        elif user_took_focus:
            # The user selected a window while the lease was active.  Respect
            # that selection instead of forcing the stale previous window.
            focus_restored = None

        cursor_restored: bool | None = None
        if (
            action_attempted
            and cursor_before is not None
            and cursor_after_action is not None
            and expected_cursor_after is not None
        ):
            if self._cursor_near(cursor_after_action, expected_cursor_after):
                cursor_restored = bool(
                    self.backend.set_cursor_pos(cursor_before[0], cursor_before[1])
                )
            else:
                # A different cursor position is treated as user ownership.
                cursor_restored = None

        foreground_final = self.backend.foreground_window()
        cursor_final = self.backend.cursor_pos()
        duration = max(0.0, self.monotonic() - lease_started)

        if action_exception is not None:
            status = LeaseStatus.ACTION_EXCEPTION
            reason = f"action raised {type(action_exception).__name__}"
        elif user_took_focus or user_moved_cursor:
            status = LeaseStatus.USER_TAKEOVER_DURING_ACTION
            reason = "user input took ownership while the lease was active"
        elif not action_attempted:
            status = pre_action_status
        elif not action_succeeded:
            status = LeaseStatus.ACTION_FAILED
        elif exclusive_input_released is False:
            status = LeaseStatus.RELEASE_INCOMPLETE
            reason = "action completed but physical-input lock did not release"
        elif focus_restored is False or cursor_restored is False:
            status = LeaseStatus.RELEASE_INCOMPLETE
            reason = "action completed but focus or cursor restoration failed"
        else:
            status = LeaseStatus.COMPLETE
            reason = "one foreground action completed and lease was released"

        return self._result(
            identity,
            status,
            reason,
            action_attempted,
            action_succeeded,
            foreground_before,
            foreground_after_acquire,
            foreground_after_action,
            foreground_final,
            cursor_before,
            cursor_after_action,
            cursor_final,
            focus_restored,
            cursor_restored,
            user_took_focus,
            user_moved_cursor,
            post_focus_idle_age,
            idle_wait,
            duration,
        )

    def _safe_preflight(self, preflight: Callable[[], bool]) -> bool:
        try:
            return bool(preflight())
        except Exception:
            return False

    def _cursor_near(
        self,
        current: tuple[int, int],
        expected: tuple[int, int],
    ) -> bool:
        return (
            abs(current[0] - expected[0]) <= self.cursor_tolerance_pixels
            and abs(current[1] - expected[1]) <= self.cursor_tolerance_pixels
        )

    def _early_result(
        self,
        status: LeaseStatus,
        reason: str,
        identity: str = "",
        *,
        idle_age_seconds: float | None = None,
        idle_wait_seconds: float = 0.0,
    ) -> LeaseResult:
        foreground = self.backend.foreground_window()
        cursor = self.backend.cursor_pos()
        return self._result(
            identity,
            status,
            reason,
            False,
            False,
            foreground,
            foreground,
            foreground,
            foreground,
            cursor,
            cursor,
            cursor,
            None,
            None,
            False,
            False,
            idle_age_seconds,
            idle_wait_seconds,
            0.0,
        )

    def _result(self, *args: Any) -> LeaseResult:
        result = LeaseResult(*args)
        self.event_sink("foreground_lease_finished", jsonable(result))
        return result


if os.name == "nt":
    _user32 = ctypes.WinDLL("user32", use_last_error=True)
    _kernel32 = ctypes.WinDLL("kernel32", use_last_error=True)

    class _POINT(ctypes.Structure):
        _fields_ = [("x", wintypes.LONG), ("y", wintypes.LONG)]

    class _LASTINPUTINFO(ctypes.Structure):
        _fields_ = [("cbSize", wintypes.UINT), ("dwTime", wintypes.DWORD)]

    _user32.IsWindow.argtypes = [wintypes.HWND]
    _user32.IsWindow.restype = wintypes.BOOL
    _user32.IsWindowVisible.argtypes = [wintypes.HWND]
    _user32.IsWindowVisible.restype = wintypes.BOOL
    _user32.IsIconic.argtypes = [wintypes.HWND]
    _user32.IsIconic.restype = wintypes.BOOL
    _user32.GetForegroundWindow.restype = wintypes.HWND
    _user32.GetCursorPos.argtypes = [ctypes.POINTER(_POINT)]
    _user32.GetCursorPos.restype = wintypes.BOOL
    _user32.GetWindowThreadProcessId.argtypes = [
        wintypes.HWND,
        ctypes.POINTER(wintypes.DWORD),
    ]
    _user32.GetWindowThreadProcessId.restype = wintypes.DWORD
    _user32.GetWindowTextLengthW.argtypes = [wintypes.HWND]
    _user32.GetWindowTextLengthW.restype = ctypes.c_int
    _user32.GetWindowTextW.argtypes = [wintypes.HWND, wintypes.LPWSTR, ctypes.c_int]
    _user32.GetWindowTextW.restype = ctypes.c_int
    _user32.SetWindowPos.argtypes = [
        wintypes.HWND,
        wintypes.HWND,
        ctypes.c_int,
        ctypes.c_int,
        ctypes.c_int,
        ctypes.c_int,
        wintypes.UINT,
    ]
    _user32.SetWindowPos.restype = wintypes.BOOL
    _user32.GetWindowLongW.argtypes = [wintypes.HWND, ctypes.c_int]
    _user32.GetWindowLongW.restype = wintypes.LONG
    _user32.GetLastInputInfo.argtypes = [ctypes.POINTER(_LASTINPUTINFO)]
    _user32.GetLastInputInfo.restype = wintypes.BOOL
    _user32.GetAsyncKeyState.argtypes = [ctypes.c_int]
    _user32.GetAsyncKeyState.restype = wintypes.SHORT
    _user32.BlockInput.argtypes = [wintypes.BOOL]
    _user32.BlockInput.restype = wintypes.BOOL
    _user32.GetClipCursor.argtypes = [ctypes.POINTER(wintypes.RECT)]
    _user32.GetClipCursor.restype = wintypes.BOOL
    _user32.ClipCursor.argtypes = [ctypes.POINTER(wintypes.RECT)]
    _user32.ClipCursor.restype = wintypes.BOOL
    _user32.BringWindowToTop.argtypes = [wintypes.HWND]
    _user32.BringWindowToTop.restype = wintypes.BOOL
    _user32.SetForegroundWindow.argtypes = [wintypes.HWND]
    _user32.SetForegroundWindow.restype = wintypes.BOOL
    _user32.AttachThreadInput.argtypes = [
        wintypes.DWORD,
        wintypes.DWORD,
        wintypes.BOOL,
    ]
    _user32.AttachThreadInput.restype = wintypes.BOOL
    _kernel32.GetTickCount.restype = wintypes.DWORD
    _kernel32.GetCurrentThreadId.restype = wintypes.DWORD


class NativeForegroundLeaseBackend:
    """Native shell operations plus the accepted foreground input backend."""

    HWND_TOPMOST = wintypes.HWND(-1) if os.name == "nt" else -1
    HWND_NOTOPMOST = wintypes.HWND(-2) if os.name == "nt" else -2
    SWP_NOSIZE = 0x0001
    SWP_NOMOVE = 0x0002
    SWP_NOACTIVATE = 0x0010
    GWL_EXSTYLE = -20
    WS_EX_TOPMOST = 0x00000008

    def __init__(
        self,
        input_backend: Any,
        *,
        foreground_bridge: Callable[[int], bool] | None = None,
        block_input_call: Callable[[bool], bool] | None = None,
        get_clip_rect: Callable[[], tuple[int, int, int, int] | None] | None = None,
        set_clip_rect: Callable[[tuple[int, int, int, int] | None], bool]
        | None = None,
    ) -> None:
        if os.name != "nt":
            raise OSError("foreground lease transport is Windows-only")
        self.input_backend = input_backend
        self._foreground_bridge = foreground_bridge or self._thread_input_foreground
        self._block_input_call = block_input_call or self._native_block_input
        self._get_clip_rect = get_clip_rect or self._native_get_clip_rect
        self._set_clip_rect = set_clip_rect or self._native_set_clip_rect
        self._cursor_set_requests = 0
        self._foreground_requests = 0
        self._focus_bridge_attempts = 0
        self._focus_bridge_successes = 0
        self._input_guard_mode: str | None = None
        self._last_input_guard_mode: str | None = None
        self._saved_clip_rect: tuple[int, int, int, int] | None = None
        self._block_input_error: int | None = None

    def window_pid(self, hwnd: int) -> int | None:
        if not _user32.IsWindow(hwnd):
            return None
        value = wintypes.DWORD()
        _user32.GetWindowThreadProcessId(hwnd, ctypes.byref(value))
        return int(value.value) or None

    def window_title(self, hwnd: int) -> str | None:
        if not _user32.IsWindow(hwnd):
            return None
        length = int(_user32.GetWindowTextLengthW(hwnd))
        buffer = ctypes.create_unicode_buffer(length + 1)
        _user32.GetWindowTextW(hwnd, buffer, length + 1)
        return buffer.value

    def client_geometry(self, hwnd: int) -> ClientGeometry | None:
        return self.input_backend.client_geometry(hwnd)

    def is_window_visible(self, hwnd: int) -> bool:
        return bool(_user32.IsWindow(hwnd) and _user32.IsWindowVisible(hwnd))

    def is_iconic(self, hwnd: int) -> bool:
        return bool(_user32.IsIconic(hwnd))

    def foreground_window(self) -> int | None:
        value = _user32.GetForegroundWindow()
        return int(value) if value else None

    def cursor_pos(self) -> tuple[int, int] | None:
        point = _POINT()
        if not _user32.GetCursorPos(ctypes.byref(point)):
            return None
        return int(point.x), int(point.y)

    def set_cursor_pos(self, x: int, y: int) -> bool:
        self._cursor_set_requests += 1
        if self._input_guard_mode == "CURSOR_CONFINE":
            if not self._set_clip_rect((int(x), int(y), int(x) + 1, int(y) + 1)):
                return False
        return bool(self.input_backend.set_cursor_pos(x, y))

    def is_foreground(self, hwnd: int) -> bool:
        return self.foreground_window() == int(hwnd)

    @property
    def mouse_button_hold_seconds(self) -> float | None:
        return getattr(self.input_backend, "mouse_button_hold_seconds", None)

    def click_mouse(self) -> None:
        self.input_backend.click_mouse()

    def mouse_left_down(self) -> None:
        self.input_backend.mouse_left_down()

    def mouse_left_up(self) -> None:
        self.input_backend.mouse_left_up()

    def restore_and_foreground(self, hwnd: int) -> bool:
        self._foreground_requests += 1
        if self.input_backend.restore_and_foreground(hwnd):
            return True
        self._focus_bridge_attempts += 1
        bridged = bool(self._foreground_bridge(hwnd))
        if bridged:
            self._focus_bridge_successes += 1
        return bridged

    @property
    def cursor_set_requests(self) -> int:
        return self._cursor_set_requests

    @property
    def foreground_requests(self) -> int:
        return self._foreground_requests

    @property
    def focus_bridge_attempts(self) -> int:
        return self._focus_bridge_attempts

    @property
    def focus_bridge_successes(self) -> int:
        return self._focus_bridge_successes

    @property
    def input_guard_mode(self) -> str | None:
        return self._input_guard_mode

    @property
    def last_input_guard_mode(self) -> str | None:
        return self._last_input_guard_mode

    @property
    def block_input_error(self) -> int | None:
        return self._block_input_error

    def _thread_input_foreground(self, hwnd: int) -> bool:
        """Bounded SetForegroundWindow fallback using temporary queue attach.

        Windows may reject a direct foreground request when another process
        owns the last-input grant.  Temporarily attaching the calling thread's
        input queue to the foreground and target threads permits the explicit
        same-desktop handoff.  Every successful attach is detached in reverse
        order before this method returns.
        """

        if (
            not hwnd
            or not _user32.IsWindow(hwnd)
            or not _user32.IsWindowVisible(hwnd)
        ):
            return False
        foreground = _user32.GetForegroundWindow()
        if foreground and int(foreground) == int(hwnd):
            return True
        current_thread = int(_kernel32.GetCurrentThreadId())
        target_thread = int(_user32.GetWindowThreadProcessId(hwnd, None))
        foreground_thread = (
            int(_user32.GetWindowThreadProcessId(foreground, None))
            if foreground
            else 0
        )
        if not current_thread or not target_thread:
            return False

        attached: list[int] = []
        try:
            for thread_id in (foreground_thread, target_thread):
                if not thread_id or thread_id == current_thread or thread_id in attached:
                    continue
                if not _user32.AttachThreadInput(current_thread, thread_id, True):
                    return False
                attached.append(thread_id)
            _user32.BringWindowToTop(hwnd)
            requested = bool(_user32.SetForegroundWindow(hwnd))
            current = _user32.GetForegroundWindow()
            return requested or bool(current and int(current) == int(hwnd))
        finally:
            for thread_id in reversed(attached):
                _user32.AttachThreadInput(current_thread, thread_id, False)

    def pin_topmost(self, hwnd: int) -> bool:
        return bool(
            _user32.SetWindowPos(
                hwnd,
                self.HWND_TOPMOST,
                0,
                0,
                0,
                0,
                self.SWP_NOMOVE | self.SWP_NOSIZE | self.SWP_NOACTIVATE,
            )
        )

    def unpin_topmost(self, hwnd: int) -> bool:
        return bool(
            _user32.SetWindowPos(
                hwnd,
                self.HWND_NOTOPMOST,
                0,
                0,
                0,
                0,
                self.SWP_NOMOVE | self.SWP_NOSIZE | self.SWP_NOACTIVATE,
            )
        )

    def is_topmost(self, hwnd: int) -> bool:
        if not _user32.IsWindow(hwnd):
            return False
        return bool(int(_user32.GetWindowLongW(hwnd, self.GWL_EXSTYLE)) & self.WS_EX_TOPMOST)

    def last_input_age_seconds(self) -> float | None:
        info = _LASTINPUTINFO(ctypes.sizeof(_LASTINPUTINFO), 0)
        if not _user32.GetLastInputInfo(ctypes.byref(info)):
            return None
        # DWORD wrap is intentional and matches unsigned GetTickCount math.
        age_ms = (int(_kernel32.GetTickCount()) - int(info.dwTime)) & 0xFFFFFFFF
        return age_ms / 1000.0

    def any_input_pressed(self) -> bool:
        # High bit means physically down.  Iterating all virtual-key values is
        # bounded and prevents takeover while the user is holding a mouse or
        # keyboard key; it does not suppress or consume that input.
        return any(int(_user32.GetAsyncKeyState(vk)) & 0x8000 for vk in range(1, 256))

    def any_pointer_button_pressed(self) -> bool:
        # Mouse leases may interrupt typing, but must never synthesize a click
        # while a physical mouse button is down because that can turn the
        # intended two-click swap into a drag or mixed-button gesture.
        return any(
            int(_user32.GetAsyncKeyState(vk)) & 0x8000
            for vk in (0x01, 0x02, 0x04, 0x05, 0x06)
        )

    def block_user_input(self, blocked: bool) -> bool:
        if blocked:
            if self._input_guard_mode is not None:
                return True
            ctypes.set_last_error(0)
            if self._block_input_call(True):
                self._input_guard_mode = "BLOCK_INPUT"
                self._last_input_guard_mode = "BLOCK_INPUT"
                self._block_input_error = None
                return True

            # BlockInput commonly requires a higher integrity level than the
            # desktop tool has.  For a board swap, confining the cursor to the
            # executor-controlled point is sufficient to prevent a physical
            # drag from competing with the accepted two-click path.  The
            # executor advances the one-pixel rectangle before each synthetic
            # cursor move.  Preserve the previous desktop clip exactly.
            self._block_input_error = int(ctypes.get_last_error())
            previous = self._get_clip_rect()
            cursor = self.cursor_pos()
            if cursor is None or previous is None:
                return False
            if not self._set_clip_rect(
                (cursor[0], cursor[1], cursor[0] + 1, cursor[1] + 1)
            ):
                return False
            self._saved_clip_rect = previous
            self._input_guard_mode = "CURSOR_CONFINE"
            self._last_input_guard_mode = "CURSOR_CONFINE"
            return True

        mode = self._input_guard_mode
        if mode is None:
            return True
        released = False
        if mode == "BLOCK_INPUT":
            released = bool(self._block_input_call(False))
        elif mode == "CURSOR_CONFINE":
            previous = self._saved_clip_rect
            released = bool(
                previous is not None
                and self._set_clip_rect(previous)
            )
        if released:
            self._input_guard_mode = None
            self._saved_clip_rect = None
        return released

    @staticmethod
    def _native_block_input(blocked: bool) -> bool:
        return bool(_user32.BlockInput(bool(blocked)))

    @staticmethod
    def _native_get_clip_rect() -> tuple[int, int, int, int] | None:
        rect = wintypes.RECT()
        if not _user32.GetClipCursor(ctypes.byref(rect)):
            return None
        return int(rect.left), int(rect.top), int(rect.right), int(rect.bottom)

    @staticmethod
    def _native_set_clip_rect(
        rect: tuple[int, int, int, int] | None,
    ) -> bool:
        if rect is None:
            return bool(_user32.ClipCursor(None))
        native = wintypes.RECT(*map(int, rect))
        return bool(_user32.ClipCursor(ctypes.byref(native)))


__all__ = [
    "BoundedForegroundLease",
    "ForegroundLeaseBackend",
    "LeaseResult",
    "LeaseStatus",
    "NativeForegroundLeaseBackend",
    "PinResult",
    "PinStatus",
    "PinnedWindowSession",
    "jsonable",
]
