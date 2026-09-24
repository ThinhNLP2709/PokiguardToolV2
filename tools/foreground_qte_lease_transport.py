"""Bounded pinned-foreground lease for one existing Pet Skill/QTE action.

The accepted Phase 3 PetSkillActionExecutor remains the only owner of card,
direction and Space semantics.  This module owns only the temporary desktop
transport boundary: foreground acquisition, cursor confinement, physical
keyboard suppression and exact restoration.
"""

from __future__ import annotations

import ctypes
from ctypes import wintypes
from dataclasses import asdict, dataclass, is_dataclass
from enum import Enum
import os
from pathlib import Path
import sys
import threading
import time
from typing import Any, Callable, Protocol

PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from tools.background_mouse_transport import ExactWindowBinding


class QteLeaseStatus(str, Enum):
    ACTIVE = "ACTIVE"
    COMPLETE = "COMPLETE"
    UNARMED = "UNARMED"
    ALREADY_CONSUMED = "ALREADY_CONSUMED"
    WINDOW_INVALID = "WINDOW_INVALID"
    WINDOW_CHANGED = "WINDOW_CHANGED"
    STOPPED = "STOPPED"
    STALE_ACTION = "STALE_ACTION"
    USER_BUSY_TIMEOUT = "USER_BUSY_TIMEOUT"
    FOCUS_ACQUIRE_FAILED = "FOCUS_ACQUIRE_FAILED"
    INPUT_GUARD_FAILED = "INPUT_GUARD_FAILED"
    ACTIVE_LEASE_INVALIDATED = "ACTIVE_LEASE_INVALIDATED"
    RELEASE_INCOMPLETE = "RELEASE_INCOMPLETE"


@dataclass(frozen=True)
class QteLeaseAcquireResult:
    status: QteLeaseStatus
    reason: str
    action_identity: str
    foreground_before: int | None
    foreground_after: int | None
    cursor_before: tuple[int, int] | None
    guard_mode: str | None
    idle_wait_seconds: float

    @property
    def acquired(self) -> bool:
        return self.status is QteLeaseStatus.ACTIVE


@dataclass(frozen=True)
class QteLeaseReleaseResult:
    status: QteLeaseStatus
    reason: str
    action_identity: str
    guard_released: bool | None
    focus_restored: bool | None
    cursor_restored: bool | None
    duration_seconds: float

    @property
    def released(self) -> bool:
        return self.status is QteLeaseStatus.COMPLETE


@dataclass(frozen=True)
class QteLeaseMouseReleaseResult:
    status: QteLeaseStatus
    reason: str
    action_identity: str
    mouse_released: bool
    keyboard_guard_active: bool
    cursor_restored: bool | None
    elapsed_seconds: float

    @property
    def released(self) -> bool:
        return self.status is QteLeaseStatus.COMPLETE


class KeyboardGuard(Protocol):
    @property
    def active(self) -> bool: ...
    def acquire(self) -> bool: ...
    def release(self) -> bool: ...


class QteLeaseBackend(Protocol):
    def window_pid(self, hwnd: int) -> int | None: ...
    def window_title(self, hwnd: int) -> str | None: ...
    def client_geometry(self, hwnd: int) -> Any: ...
    def is_window_visible(self, hwnd: int) -> bool: ...
    def is_iconic(self, hwnd: int) -> bool: ...
    def foreground_window(self) -> int | None: ...
    def cursor_pos(self) -> tuple[int, int] | None: ...
    def set_cursor_pos(self, x: int, y: int) -> bool: ...
    def restore_and_foreground(self, hwnd: int) -> bool: ...
    def last_input_age_seconds(self) -> float | None: ...
    def any_pointer_button_pressed(self) -> bool: ...
    def acquire_qte_input_guard(self) -> bool: ...
    def transition_qte_guard_to_keyboard_only(self) -> bool: ...
    def release_qte_input_guard(self) -> bool: ...
    def qte_input_guard_active(self) -> bool: ...


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


def _binding_problem(
    backend: QteLeaseBackend,
    binding: ExactWindowBinding,
) -> QteLeaseStatus | None:
    window = binding.window
    if (
        backend.window_pid(window.hwnd) != window.pid
        or backend.window_title(window.hwnd) != window.title
        or not backend.is_window_visible(window.hwnd)
        or backend.is_iconic(window.hwnd)
    ):
        return QteLeaseStatus.WINDOW_INVALID
    geometry = backend.client_geometry(window.hwnd)
    if geometry is None:
        return QteLeaseStatus.WINDOW_INVALID
    if geometry != binding.geometry:
        return QteLeaseStatus.WINDOW_CHANGED
    return None


class BoundedForegroundQteLease:
    """One arm owns only the physical input needed by each action stage."""

    def __init__(
        self,
        backend: QteLeaseBackend,
        *,
        sleeper: Callable[[float], None] = time.sleep,
        monotonic: Callable[[], float] = time.monotonic,
        stop_requested: Callable[[], bool] = lambda: False,
        event_sink: Callable[[str, dict[str, Any]], None] | None = None,
        required_idle_seconds: float = 0.20,
        idle_timeout_seconds: float = 0.75,
        poll_interval_seconds: float = 0.025,
        focus_timeout_seconds: float = 0.75,
        focus_settle_seconds: float = 0.20,
        focus_request_attempts: int = 3,
        maximum_duration_seconds: float = 20.0,
    ) -> None:
        if not 0.10 <= required_idle_seconds <= 2.0:
            raise ValueError("required_idle_seconds must be between 0.10 and 2.0")
        if not required_idle_seconds <= idle_timeout_seconds <= 5.0:
            raise ValueError("idle_timeout_seconds is outside the bounded range")
        if not 0.01 <= poll_interval_seconds <= 0.25:
            raise ValueError("poll_interval_seconds must be between 0.01 and 0.25")
        if not 0.10 <= focus_timeout_seconds <= 2.0:
            raise ValueError("focus_timeout_seconds must be between 0.10 and 2.0")
        if not 0.0 <= focus_settle_seconds <= 1.0:
            raise ValueError("focus_settle_seconds must be between 0 and 1.0")
        if not 1 <= focus_request_attempts <= 5:
            raise ValueError("focus_request_attempts must be between 1 and 5")
        if not 3.0 <= maximum_duration_seconds <= 30.0:
            raise ValueError("maximum_duration_seconds must be between 3 and 30")
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
        self.focus_request_attempts = int(focus_request_attempts)
        self.maximum_duration_seconds = float(maximum_duration_seconds)
        self._armed: tuple[ExactWindowBinding, str] | None = None
        self._consumed = False
        self._active = False
        self._foreground_before: int | None = None
        self._cursor_before: tuple[int, int] | None = None
        self._started_at: float | None = None
        self._mouse_released_for_qte = False
        self._cursor_restored_during_qte: bool | None = None
        self._identity = ""
        self._lock = threading.RLock()

    @property
    def active(self) -> bool:
        with self._lock:
            return self._active

    @property
    def consumed(self) -> bool:
        with self._lock:
            return self._consumed

    def arm(self, binding: ExactWindowBinding, action_identity: str) -> None:
        with self._lock:
            if self._armed is not None or self._consumed or self._active:
                raise RuntimeError("this QTE lease has already been armed")
            if not action_identity.strip():
                raise ValueError("action_identity is required")
            failure = _binding_problem(self.backend, binding)
            if failure is not None:
                raise RuntimeError(f"cannot arm QTE lease: {failure.value}")
            self._armed = (binding, action_identity)
            self._retained_binding = binding
            self.event_sink(
                "foreground_qte_lease_armed",
                {"actionIdentity": action_identity, "hwnd": binding.window.hwnd},
            )

    def acquire(self, *, preflight: Callable[[], bool]) -> QteLeaseAcquireResult:
        with self._lock:
            if self._active:
                return self._acquire_result(
                    QteLeaseStatus.ACTIVE,
                    "QTE lease is already active",
                    self._identity,
                    self._foreground_before,
                    self.backend.foreground_window(),
                    self._cursor_before,
                    0.0,
                )
            if self._consumed:
                return self._acquire_result(
                    QteLeaseStatus.ALREADY_CONSUMED,
                    "QTE lease authority was already consumed",
                )
            if self._armed is None:
                return self._acquire_result(
                    QteLeaseStatus.UNARMED,
                    "QTE lease is not armed",
                )
            binding, identity = self._armed
            self._consumed = True
            self._armed = None
            self._identity = identity

        failure = _binding_problem(self.backend, binding)
        if failure is not None:
            return self._acquire_result(failure, "exact game window changed", identity)
        if self.stop_requested():
            return self._acquire_result(QteLeaseStatus.STOPPED, "stop requested", identity)
        if not self._safe_preflight(preflight):
            return self._acquire_result(
                QteLeaseStatus.STALE_ACTION,
                "QTE acquire preflight rejected",
                identity,
            )

        wait_started = self.monotonic()
        idle_age: float | None = None
        while True:
            if self.stop_requested():
                return self._acquire_result(
                    QteLeaseStatus.STOPPED,
                    "stop requested while waiting for mouse release",
                    identity,
                    idle_wait=max(0.0, self.monotonic() - wait_started),
                )
            idle_age = self.backend.last_input_age_seconds()
            if (
                idle_age is not None
                and idle_age >= self.required_idle_seconds
                and not self.backend.any_pointer_button_pressed()
            ):
                break
            elapsed = max(0.0, self.monotonic() - wait_started)
            if elapsed >= self.idle_timeout_seconds:
                if not self.backend.any_pointer_button_pressed():
                    self.event_sink(
                        "foreground_qte_lease_courtesy_timeout",
                        {
                            "actionIdentity": identity,
                            "idleAgeSeconds": idle_age,
                            "idleWaitSeconds": elapsed,
                        },
                    )
                    break
                return self._acquire_result(
                    QteLeaseStatus.USER_BUSY_TIMEOUT,
                    "a physical mouse button remained held",
                    identity,
                    idle_wait=elapsed,
                )
            self.sleeper(self.poll_interval_seconds)

        idle_wait = max(0.0, self.monotonic() - wait_started)
        failure = _binding_problem(self.backend, binding)
        if failure is not None:
            return self._acquire_result(
                failure,
                "exact game window changed while waiting",
                identity,
                idle_wait=idle_wait,
            )
        if not self._safe_preflight(preflight):
            return self._acquire_result(
                QteLeaseStatus.STALE_ACTION,
                "QTE acquire preflight became stale",
                identity,
                idle_wait=idle_wait,
            )

        foreground_before = self.backend.foreground_window()
        cursor_before = self.backend.cursor_pos()
        requested = foreground_before == binding.window.hwnd
        attempts = 0
        if not requested:
            deadline = self.monotonic() + self.focus_timeout_seconds
            attempt_window = self.focus_timeout_seconds / self.focus_request_attempts
            while (
                self.backend.foreground_window() != binding.window.hwnd
                and self.monotonic() < deadline
                and attempts < self.focus_request_attempts
                and not self.stop_requested()
            ):
                attempts += 1
                requested = bool(
                    self.backend.restore_and_foreground(binding.window.hwnd)
                ) or requested
                attempt_deadline = min(deadline, self.monotonic() + attempt_window)
                while (
                    self.backend.foreground_window() != binding.window.hwnd
                    and self.monotonic() < attempt_deadline
                    and not self.stop_requested()
                ):
                    self.sleeper(self.poll_interval_seconds)
        foreground_after = self.backend.foreground_window()
        if not requested or foreground_after != binding.window.hwnd:
            return self._acquire_result(
                QteLeaseStatus.FOCUS_ACQUIRE_FAILED,
                "Windows did not grant foreground ownership",
                identity,
                foreground_before,
                foreground_after,
                cursor_before,
                idle_wait,
            )

        guard_acquired = self.backend.acquire_qte_input_guard()
        if not guard_acquired:
            self._restore_focus(foreground_before, binding.window.hwnd)
            return self._acquire_result(
                QteLeaseStatus.INPUT_GUARD_FAILED,
                "bounded QTE physical-input guard was not acquired",
                identity,
                foreground_before,
                self.backend.foreground_window(),
                cursor_before,
                idle_wait,
            )

        # From this point the wrapper owns physical input.  Mark the session
        # active before the final settle so every rejection can use the same
        # release path and cannot strand a partially acquired guard.
        with self._lock:
            self._active = True
            self._foreground_before = foreground_before
            self._cursor_before = cursor_before
            self._started_at = self.monotonic()
            self._mouse_released_for_qte = False
            self._cursor_restored_during_qte = None

        if self.focus_settle_seconds:
            self.sleeper(self.focus_settle_seconds)
        failure = _binding_problem(self.backend, binding)
        valid = bool(
            failure is None
            and not self.stop_requested()
            and self.backend.foreground_window() == binding.window.hwnd
            and self.backend.qte_input_guard_active()
            and self._safe_preflight(preflight)
        )
        if not valid:
            cleanup = self.release("ACQUIRE_VALIDATION_FAILED")
            return self._acquire_result(
                (
                    QteLeaseStatus.STALE_ACTION
                    if cleanup.released
                    else QteLeaseStatus.RELEASE_INCOMPLETE
                ),
                (
                    "QTE state/window/guard changed during acquisition"
                    if cleanup.released
                    else "QTE acquire failed and physical-input release was incomplete"
                ),
                identity,
                foreground_before,
                self.backend.foreground_window(),
                cursor_before,
                idle_wait,
            )
        result = self._acquire_result(
            QteLeaseStatus.ACTIVE,
            "foreground and QTE physical-input authority acquired",
            identity,
            foreground_before,
            foreground_after,
            cursor_before,
            idle_wait,
        )
        self.event_sink(
            "foreground_qte_lease_acquired",
            {
                **jsonable(result),
                "focusRequestCount": attempts,
                "maximumDurationSeconds": self.maximum_duration_seconds,
            },
        )
        return result

    def validate_active(self) -> bool:
        with self._lock:
            if not self._active or self._started_at is None:
                return False
            binding = self._current_binding()
            expired = self.monotonic() - self._started_at > self.maximum_duration_seconds
        return bool(
            not expired
            and not self.stop_requested()
            and binding is not None
            and _binding_problem(self.backend, binding) is None
            and self.backend.foreground_window() == binding.window.hwnd
            and self.backend.qte_input_guard_active()
        )

    def release_mouse_for_keyboard_phase(
        self,
        reason: str = "CURRENT_QTE_BOUND",
    ) -> QteLeaseMouseReleaseResult:
        """Return mouse authority after the card click and retain keyboard only."""

        with self._lock:
            started = self._started_at or self.monotonic()
            if not self._active:
                result = QteLeaseMouseReleaseResult(
                    QteLeaseStatus.RELEASE_INCOMPLETE,
                    f"{reason}: QTE lease is not active",
                    self._identity,
                    False,
                    False,
                    None,
                    max(0.0, self.monotonic() - started),
                )
                self.event_sink(
                    "foreground_qte_mouse_released_for_keyboard",
                    jsonable(result),
                )
                return result
            if self._mouse_released_for_qte:
                result = QteLeaseMouseReleaseResult(
                    QteLeaseStatus.COMPLETE,
                    f"{reason}: mouse authority was already released",
                    self._identity,
                    True,
                    self.backend.qte_input_guard_active(),
                    self._cursor_restored_during_qte,
                    max(0.0, self.monotonic() - started),
                )
                self.event_sink(
                    "foreground_qte_mouse_released_for_keyboard",
                    jsonable(result),
                )
                return result

            transitioned = bool(
                self.backend.transition_qte_guard_to_keyboard_only()
            )
            if not transitioned or not self.backend.qte_input_guard_active():
                result = QteLeaseMouseReleaseResult(
                    QteLeaseStatus.RELEASE_INCOMPLETE,
                    f"{reason}: mouse-to-keyboard guard transition failed",
                    self._identity,
                    False,
                    False,
                    None,
                    max(0.0, self.monotonic() - started),
                )
                self.event_sink(
                    "foreground_qte_mouse_released_for_keyboard",
                    jsonable(result),
                )
                return result

            cursor_restored = self._restore_cursor(self._cursor_before)
            self._cursor_restored_during_qte = cursor_restored
            self._mouse_released_for_qte = cursor_restored is not False
            complete = self._mouse_released_for_qte
            result = QteLeaseMouseReleaseResult(
                QteLeaseStatus.COMPLETE if complete else QteLeaseStatus.RELEASE_INCOMPLETE,
                reason if complete else f"{reason}: cursor restoration failed",
                self._identity,
                True,
                True,
                cursor_restored,
                max(0.0, self.monotonic() - started),
            )
            self.event_sink(
                "foreground_qte_mouse_released_for_keyboard",
                jsonable(result),
            )
            return result

    def release(self, reason: str = "QTE_TERMINAL") -> QteLeaseReleaseResult:
        with self._lock:
            if not self._active:
                result = QteLeaseReleaseResult(
                    QteLeaseStatus.COMPLETE,
                    "QTE lease was not active",
                    self._identity,
                    None,
                    None,
                    None,
                    0.0,
                )
                self.event_sink("foreground_qte_lease_released", jsonable(result))
                return result
            binding = self._current_binding()
            foreground_before = self._foreground_before
            cursor_before = self._cursor_before
            started = self._started_at or self.monotonic()
            guard_released = bool(self.backend.release_qte_input_guard())
            if not guard_released:
                result = QteLeaseReleaseResult(
                    QteLeaseStatus.RELEASE_INCOMPLETE,
                    f"{reason}: physical-input guard did not release",
                    self._identity,
                    False,
                    None,
                    None,
                    max(0.0, self.monotonic() - started),
                )
                self.event_sink("foreground_qte_lease_released", jsonable(result))
                return result
            self._active = False
            cursor_restored = (
                self._cursor_restored_during_qte
                if self._mouse_released_for_qte
                else self._restore_cursor(cursor_before)
            )
            focus_restored = self._restore_focus(
                foreground_before,
                binding.window.hwnd if binding is not None else None,
            )
            duration = max(0.0, self.monotonic() - started)
            # Focus restoration is best effort: Windows may reject a valid
            # request even though the pinned game action and all physical-input
            # cleanup completed. Cursor restoration remains mandatory.
            complete = cursor_restored is not False
            release_reason = (
                reason
                if focus_restored is not False
                else f"{reason}: focus restoration unavailable (best effort)"
            )
            result = QteLeaseReleaseResult(
                QteLeaseStatus.COMPLETE if complete else QteLeaseStatus.RELEASE_INCOMPLETE,
                release_reason if complete else f"{reason}: cursor restoration incomplete",
                self._identity,
                True,
                focus_restored,
                cursor_restored,
                duration,
            )
            self.event_sink("foreground_qte_lease_released", jsonable(result))
            return result

    def _current_binding(self) -> ExactWindowBinding | None:
        # The consumed binding is retained through the exact immutable window
        # members already held by the backend-facing release path.
        return getattr(self, "_retained_binding", None)

    def _safe_preflight(self, preflight: Callable[[], bool]) -> bool:
        try:
            return bool(preflight())
        except Exception:
            return False

    def _restore_cursor(
        self, cursor: tuple[int, int] | None
    ) -> bool | None:
        if cursor is None:
            return None
        return bool(self.backend.set_cursor_pos(cursor[0], cursor[1]))

    def _restore_focus(
        self,
        previous: int | None,
        game_hwnd: int | None,
    ) -> bool | None:
        current = self.backend.foreground_window()
        if previous is None or game_hwnd is None:
            return None
        if previous == game_hwnd:
            return current == game_hwnd
        if current == previous:
            return True
        if current not in (None, game_hwnd):
            return None

        deadline = self.monotonic() + self.focus_timeout_seconds
        attempt_window = self.focus_timeout_seconds / self.focus_request_attempts
        attempts = 0
        requested_any = False
        while (
            attempts < self.focus_request_attempts
            and self.monotonic() < deadline
            and not self.stop_requested()
        ):
            current = self.backend.foreground_window()
            if current == previous:
                break
            if current not in (None, game_hwnd):
                # Respect a different user-selected foreground window.
                return None
            attempts += 1
            requested_any = bool(
                self.backend.restore_and_foreground(previous)
            ) or requested_any
            attempt_deadline = min(deadline, self.monotonic() + attempt_window)
            while (
                self.backend.foreground_window() != previous
                and self.monotonic() < attempt_deadline
                and not self.stop_requested()
            ):
                current = self.backend.foreground_window()
                if current not in (None, game_hwnd):
                    break
                self.sleeper(self.poll_interval_seconds)

        restored = self.backend.foreground_window() == previous
        self.event_sink(
            "foreground_qte_focus_restore",
            {
                "actionIdentity": self._identity,
                "targetHwnd": previous,
                "attempts": attempts,
                "requested": requested_any,
                "restored": restored,
                "foregroundAfter": self.backend.foreground_window(),
            },
        )
        return restored

    def _acquire_result(
        self,
        status: QteLeaseStatus,
        reason: str,
        identity: str = "",
        foreground_before: int | None = None,
        foreground_after: int | None = None,
        cursor_before: tuple[int, int] | None = None,
        idle_wait: float = 0.0,
    ) -> QteLeaseAcquireResult:
        result = QteLeaseAcquireResult(
            status,
            reason,
            identity,
            foreground_before,
            foreground_after,
            cursor_before,
            getattr(self.backend, "qte_input_guard_mode", None),
            idle_wait,
        )
        self.event_sink("foreground_qte_lease_acquire_finished", jsonable(result))
        return result


if os.name == "nt":
    _user32 = ctypes.WinDLL("user32", use_last_error=True)
    _kernel32 = ctypes.WinDLL("kernel32", use_last_error=True)
    _LRESULT = ctypes.c_ssize_t
    _HOOKPROC = ctypes.WINFUNCTYPE(
        _LRESULT, ctypes.c_int, wintypes.WPARAM, wintypes.LPARAM
    )

    class _KBDLLHOOKSTRUCT(ctypes.Structure):
        _fields_ = [
            ("vkCode", wintypes.DWORD),
            ("scanCode", wintypes.DWORD),
            ("flags", wintypes.DWORD),
            ("time", wintypes.DWORD),
            ("dwExtraInfo", ctypes.c_void_p),
        ]

    _user32.SetWindowsHookExW.argtypes = [
        ctypes.c_int,
        _HOOKPROC,
        wintypes.HINSTANCE,
        wintypes.DWORD,
    ]
    _user32.SetWindowsHookExW.restype = wintypes.HHOOK
    _user32.CallNextHookEx.argtypes = [
        wintypes.HHOOK,
        ctypes.c_int,
        wintypes.WPARAM,
        wintypes.LPARAM,
    ]
    _user32.CallNextHookEx.restype = _LRESULT
    _user32.UnhookWindowsHookEx.argtypes = [wintypes.HHOOK]
    _user32.UnhookWindowsHookEx.restype = wintypes.BOOL
    _user32.GetMessageW.argtypes = [
        ctypes.POINTER(wintypes.MSG),
        wintypes.HWND,
        wintypes.UINT,
        wintypes.UINT,
    ]
    _user32.GetMessageW.restype = wintypes.BOOL
    _user32.PostThreadMessageW.argtypes = [
        wintypes.DWORD,
        wintypes.UINT,
        wintypes.WPARAM,
        wintypes.LPARAM,
    ]
    _user32.PostThreadMessageW.restype = wintypes.BOOL
    _kernel32.GetModuleHandleW.argtypes = [wintypes.LPCWSTR]
    _kernel32.GetModuleHandleW.restype = wintypes.HMODULE
    _kernel32.GetCurrentThreadId.restype = wintypes.DWORD


class NativeLowLevelKeyboardGuard:
    """Suppress physical keys while allowing injected QTE keys and F9 stop."""

    WH_KEYBOARD_LL = 13
    HC_ACTION = 0
    LLKHF_INJECTED = 0x10
    WM_KEYDOWN = 0x0100
    WM_KEYUP = 0x0101
    WM_SYSKEYDOWN = 0x0104
    WM_SYSKEYUP = 0x0105
    WM_QUIT = 0x0012
    VK_F9 = 0x78

    def __init__(self, *, startup_timeout_seconds: float = 1.0) -> None:
        if os.name != "nt":
            raise OSError("low-level keyboard guard is Windows-only")
        self.startup_timeout_seconds = float(startup_timeout_seconds)
        self._ready = threading.Event()
        self._done = threading.Event()
        self._thread: threading.Thread | None = None
        self._thread_id = 0
        self._hook = None
        self._callback = None
        self._installed = False

    @property
    def active(self) -> bool:
        return bool(
            self._installed
            and self._hook
            and self._thread is not None
            and self._thread.is_alive()
            and not self._done.is_set()
        )

    def acquire(self) -> bool:
        if self.active:
            return True
        self._ready.clear()
        self._done.clear()
        self._installed = False
        self._thread = threading.Thread(
            target=self._message_loop,
            name="PokiguardPhase4QteKeyboardGuard",
            daemon=True,
        )
        self._thread.start()
        if not self._ready.wait(self.startup_timeout_seconds):
            return False
        return self.active

    def release(self) -> bool:
        thread = self._thread
        if thread is None:
            return True
        if self._thread_id:
            _user32.PostThreadMessageW(self._thread_id, self.WM_QUIT, 0, 0)
        thread.join(timeout=self.startup_timeout_seconds)
        if thread.is_alive() and self._hook:
            _user32.UnhookWindowsHookEx(self._hook)
            thread.join(timeout=self.startup_timeout_seconds)
        return not thread.is_alive() and not self.active

    def _message_loop(self) -> None:
        self._thread_id = int(_kernel32.GetCurrentThreadId())

        @_HOOKPROC
        def callback(code: int, w_param: int, l_param: int) -> int:
            if code >= self.HC_ACTION and int(w_param) in {
                self.WM_KEYDOWN,
                self.WM_KEYUP,
                self.WM_SYSKEYDOWN,
                self.WM_SYSKEYUP,
            }:
                event = ctypes.cast(
                    l_param, ctypes.POINTER(_KBDLLHOOKSTRUCT)
                ).contents
                injected = bool(int(event.flags) & self.LLKHF_INJECTED)
                if not injected and int(event.vkCode) != self.VK_F9:
                    return 1
            return int(_user32.CallNextHookEx(self._hook, code, w_param, l_param))

        self._callback = callback
        module = _kernel32.GetModuleHandleW(None)
        self._hook = _user32.SetWindowsHookExW(
            self.WH_KEYBOARD_LL,
            callback,
            module,
            0,
        )
        self._installed = bool(self._hook)
        self._ready.set()
        if not self._installed:
            self._done.set()
            return
        try:
            message = wintypes.MSG()
            while _user32.GetMessageW(ctypes.byref(message), None, 0, 0) > 0:
                pass
        finally:
            if self._hook:
                _user32.UnhookWindowsHookEx(self._hook)
            self._hook = None
            self._installed = False
            self._done.set()


class NativeQteLeaseBackend:
    """Own mouse for the card click, then keyboard only for the QTE."""

    def __init__(
        self,
        foreground_backend: Any,
        *,
        keyboard_guard: KeyboardGuard | None = None,
    ) -> None:
        self.foreground_backend = foreground_backend
        self.keyboard_guard = keyboard_guard or NativeLowLevelKeyboardGuard()
        self._qte_guard_mode: str | None = None

    def __getattr__(self, name: str) -> Any:
        return getattr(self.foreground_backend, name)

    @property
    def qte_input_guard_mode(self) -> str | None:
        return self._qte_guard_mode

    def acquire_qte_input_guard(self) -> bool:
        if self.qte_input_guard_active():
            return True
        if not self.foreground_backend.block_user_input(True):
            return False
        mode = self.foreground_backend.input_guard_mode
        if mode == "BLOCK_INPUT":
            self._qte_guard_mode = "BLOCK_INPUT"
            return True
        if mode == "CURSOR_CONFINE":
            self._qte_guard_mode = "CURSOR_CONFINE"
            return True
        self.foreground_backend.block_user_input(False)
        self._qte_guard_mode = None
        return False

    def transition_qte_guard_to_keyboard_only(self) -> bool:
        mode = self._qte_guard_mode
        if mode == "KEYBOARD_HOOK":
            return self.keyboard_guard.active
        if mode not in {"BLOCK_INPUT", "CURSOR_CONFINE"}:
            return False
        if not self.keyboard_guard.acquire():
            return False
        mouse_released = bool(self.foreground_backend.block_user_input(False))
        if not mouse_released:
            self.keyboard_guard.release()
            return False
        self._qte_guard_mode = "KEYBOARD_HOOK"
        return True

    def release_qte_input_guard(self) -> bool:
        mode = self._qte_guard_mode
        if mode is None:
            return True
        if mode == "KEYBOARD_HOOK":
            released = bool(self.keyboard_guard.release())
        else:
            released = bool(self.foreground_backend.block_user_input(False))
        if released:
            self._qte_guard_mode = None
            return True
        return False

    def qte_input_guard_active(self) -> bool:
        mode = self._qte_guard_mode
        if mode == "BLOCK_INPUT":
            return self.foreground_backend.input_guard_mode == "BLOCK_INPUT"
        if mode == "CURSOR_CONFINE":
            return self.foreground_backend.input_guard_mode == "CURSOR_CONFINE"
        if mode == "KEYBOARD_HOOK":
            return bool(
                self.foreground_backend.input_guard_mode is None
                and self.keyboard_guard.active
            )
        return False

    def press_virtual_key(self, virtual_key: int) -> bool:
        if self._qte_guard_mode != "KEYBOARD_HOOK" or not self.qte_input_guard_active():
            return False
        return bool(
            self.foreground_backend.input_backend.press_virtual_key(virtual_key)
        )


__all__ = [
    "BoundedForegroundQteLease",
    "KeyboardGuard",
    "NativeLowLevelKeyboardGuard",
    "NativeQteLeaseBackend",
    "QteLeaseAcquireResult",
    "QteLeaseBackend",
    "QteLeaseMouseReleaseResult",
    "QteLeaseReleaseResult",
    "QteLeaseStatus",
    "jsonable",
]
