"""Foreground-only normal Windows input and verified board coordinate mapping."""

from __future__ import annotations

import ctypes
from ctypes import wintypes
from dataclasses import dataclass
from enum import Enum
import os
import time
from typing import Callable, Protocol


Cell = tuple[int, int]
VK_F8 = 0x77
VK_F9 = 0x78
VK_F10 = 0x79
VK_F7 = 0x76
MOUSEEVENTF_LEFTDOWN = 0x0002
MOUSEEVENTF_LEFTUP = 0x0004


@dataclass(frozen=True)
class ClientGeometry:
    left: int
    top: int
    width: int
    height: int


@dataclass(frozen=True)
class BoardCalibration:
    first_center_x: float = 0.360
    first_center_y: float = 0.150
    step_x: float = 0.0410
    step_y: float = 0.0760

    def normalized_center(self, cell: Cell) -> tuple[float, float]:
        row, col = validate_cell(cell)
        return (
            self.first_center_x + col * self.step_x,
            self.first_center_y + row * self.step_y,
        )

    @property
    def normalized_rect(self) -> tuple[float, float, float, float]:
        return (
            self.first_center_x - self.step_x / 2.0,
            self.first_center_y - self.step_y / 2.0,
            self.first_center_x + 7 * self.step_x + self.step_x / 2.0,
            self.first_center_y + 7 * self.step_y + self.step_y / 2.0,
        )

    def validate(self) -> None:
        left, top, right, bottom = self.normalized_rect
        if self.step_x <= 0 or self.step_y <= 0:
            raise CoordinateSafetyError("board steps must be positive")
        if not (0.0 <= left < right <= 1.0 and 0.0 <= top < bottom <= 1.0):
            raise CoordinateSafetyError("board rectangle is outside the client")


@dataclass(frozen=True)
class PixelPoint:
    client_x: int
    client_y: int
    screen_x: int
    screen_y: int


@dataclass(frozen=True)
class CoordinatePlan:
    first_cell: Cell
    second_cell: Cell
    first: PixelPoint
    second: PixelPoint
    board_rect_client: tuple[int, int, int, int]
    client_geometry: ClientGeometry


class CoordinateSafetyError(ValueError):
    pass


def validate_cell(cell: Cell) -> Cell:
    if len(cell) != 2:
        raise CoordinateSafetyError("cell must contain row and column")
    row, col = cell
    if not isinstance(row, int) or not isinstance(col, int):
        raise CoordinateSafetyError("cell coordinates must be integers")
    if not 0 <= row < 8 or not 0 <= col < 8:
        raise CoordinateSafetyError("cell is outside [0..7]")
    return row, col


def validate_adjacent_swap(first: Cell, second: Cell) -> tuple[Cell, Cell]:
    first = validate_cell(first)
    second = validate_cell(second)
    if first == second:
        raise CoordinateSafetyError("source and target cells are identical")
    distance = abs(first[0] - second[0]) + abs(first[1] - second[1])
    if distance != 1:
        raise CoordinateSafetyError("swap endpoints must have Manhattan distance 1")
    return first, second


def runtime_to_provider(cell: Cell) -> Cell:
    row, col = validate_cell(cell)
    return 7 - row, col


def provider_to_solver(cell: Cell) -> Cell:
    return validate_cell(cell)


def solver_to_screen(cell: Cell) -> Cell:
    return validate_cell(cell)


def map_swap_to_pixels(
    first: Cell,
    second: Cell,
    calibration: BoardCalibration,
    geometry: ClientGeometry,
    *,
    virtual_screen: tuple[int, int, int, int] | None = None,
) -> CoordinatePlan:
    first, second = validate_adjacent_swap(first, second)
    calibration.validate()
    if geometry.width < 640 or geometry.height < 360:
        raise CoordinateSafetyError("game client is below the safe minimum size")

    def point(cell: Cell) -> PixelPoint:
        norm_x, norm_y = calibration.normalized_center(cell)
        if not (0.0 <= norm_x <= 1.0 and 0.0 <= norm_y <= 1.0):
            raise CoordinateSafetyError("cell center is outside the client")
        # This intentionally matches V1's real click path, not overlay rounding.
        client_x = int(norm_x * (geometry.width - 1))
        client_y = int(norm_y * (geometry.height - 1))
        return PixelPoint(
            client_x,
            client_y,
            geometry.left + client_x,
            geometry.top + client_y,
        )

    left_n, top_n, right_n, bottom_n = calibration.normalized_rect
    board_rect = (
        int(left_n * (geometry.width - 1)),
        int(top_n * (geometry.height - 1)),
        int(right_n * (geometry.width - 1)),
        int(bottom_n * (geometry.height - 1)),
    )
    if not (
        0 <= board_rect[0] < board_rect[2] < geometry.width
        and 0 <= board_rect[1] < board_rect[3] < geometry.height
    ):
        raise CoordinateSafetyError("detected board rectangle is outside the client")
    first_point, second_point = point(first), point(second)
    for value in (first_point, second_point):
        if not (
            board_rect[0] <= value.client_x <= board_rect[2]
            and board_rect[1] <= value.client_y <= board_rect[3]
        ):
            raise CoordinateSafetyError("cell center is outside the board rectangle")
    if virtual_screen is not None:
        screen_left, screen_top, screen_right, screen_bottom = virtual_screen
        rect_screen = (
            geometry.left + board_rect[0],
            geometry.top + board_rect[1],
            geometry.left + board_rect[2],
            geometry.top + board_rect[3],
        )
        if not (
            screen_left <= rect_screen[0] < rect_screen[2] < screen_right
            and screen_top <= rect_screen[1] < rect_screen[3] < screen_bottom
        ):
            raise CoordinateSafetyError("board rectangle is not fully visible")
    return CoordinatePlan(
        first,
        second,
        first_point,
        second_point,
        board_rect,
        geometry,
    )


class Win32Backend(Protocol):
    def client_geometry(self, hwnd: int) -> ClientGeometry | None: ...
    def is_foreground(self, hwnd: int) -> bool: ...
    def window_pid(self, hwnd: int) -> int | None: ...
    def set_cursor_pos(self, x: int, y: int) -> bool: ...
    def click_mouse(self) -> None: ...
    def virtual_screen(self) -> tuple[int, int, int, int]: ...


class ClickStatus(str, Enum):
    SENT = "SENT"
    WINDOW_INVALID = "WINDOW_INVALID"
    WINDOW_CHANGED = "WINDOW_CHANGED"
    GAME_NOT_FOREGROUND = "GAME_NOT_FOREGROUND"
    CURSOR_MOVE_FAILED = "CURSOR_MOVE_FAILED"
    PARTIAL_INPUT = "PARTIAL_INPUT"


@dataclass(frozen=True)
class ClickPairResult:
    status: ClickStatus
    sent_clicks: int

    @property
    def sent(self) -> bool:
        return self.status is ClickStatus.SENT and self.sent_clicks == 2


@dataclass(frozen=True)
class ClickPointResult:
    status: ClickStatus

    @property
    def sent(self) -> bool:
        return self.status is ClickStatus.SENT


@dataclass(frozen=True)
class WindowBinding:
    hwnd: int
    pid: int
    title: str
    initial_width: int
    initial_height: int


@dataclass(frozen=True)
class WindowStatus:
    valid: bool
    foreground: bool | None
    geometry: ClientGeometry | None
    reason: str


class ForegroundClickExecutor:
    """Send two V1-style clicks without ever focusing or restoring a window."""

    def __init__(
        self,
        backend: Win32Backend,
        *,
        click_delay_seconds: float = 0.25,
        sleeper: Callable[[float], None] = time.sleep,
    ) -> None:
        if not 0.05 <= click_delay_seconds <= 1.0:
            raise ValueError("click delay must be between 0.05 and 1.0 seconds")
        self.backend = backend
        self.click_delay_seconds = click_delay_seconds
        self.sleeper = sleeper

    def window_status(self, binding: WindowBinding) -> WindowStatus:
        if self.backend.window_pid(binding.hwnd) != binding.pid:
            return WindowStatus(False, None, None, "window_pid_changed")
        geometry = self.backend.client_geometry(binding.hwnd)
        if geometry is None:
            return WindowStatus(False, None, None, "client_unavailable")
        if (
            geometry.width != binding.initial_width
            or geometry.height != binding.initial_height
        ):
            return WindowStatus(False, None, geometry, "window_size_changed")
        return WindowStatus(
            True,
            self.backend.is_foreground(binding.hwnd),
            geometry,
            "ok",
        )

    def _send_one(
        self, binding: WindowBinding, expected: ClientGeometry, point: PixelPoint
    ) -> ClickStatus:
        status = self.window_status(binding)
        if not status.valid or status.geometry is None:
            return ClickStatus.WINDOW_INVALID
        if status.geometry != expected:
            return ClickStatus.WINDOW_CHANGED
        if status.foreground is not True:
            return ClickStatus.GAME_NOT_FOREGROUND
        if not self.backend.set_cursor_pos(point.screen_x, point.screen_y):
            return ClickStatus.CURSOR_MOVE_FAILED
        if not self.backend.is_foreground(binding.hwnd):
            return ClickStatus.GAME_NOT_FOREGROUND
        self.backend.click_mouse()
        return ClickStatus.SENT

    def send_swap(
        self, binding: WindowBinding, plan: CoordinatePlan
    ) -> ClickPairResult:
        first = self._send_one(binding, plan.client_geometry, plan.first)
        if first is not ClickStatus.SENT:
            return ClickPairResult(first, 0)
        self.sleeper(self.click_delay_seconds)
        second = self._send_one(binding, plan.client_geometry, plan.second)
        if second is not ClickStatus.SENT:
            return ClickPairResult(ClickStatus.PARTIAL_INPUT, 1)
        return ClickPairResult(ClickStatus.SENT, 2)

    def send_normalized_point(
        self,
        binding: WindowBinding,
        normalized_point: tuple[float, float],
    ) -> ClickPointResult:
        """Send one confirmed UI click after foreground/geometry revalidation."""

        x, y = normalized_point
        if not (0.0 <= x <= 1.0 and 0.0 <= y <= 1.0):
            raise CoordinateSafetyError("normalized UI point is outside the client")
        status = self.window_status(binding)
        if not status.valid or status.geometry is None:
            return ClickPointResult(ClickStatus.WINDOW_INVALID)
        geometry = status.geometry
        client_x = int(x * (geometry.width - 1))
        client_y = int(y * (geometry.height - 1))
        point = PixelPoint(
            client_x,
            client_y,
            geometry.left + client_x,
            geometry.top + client_y,
        )
        return ClickPointResult(self._send_one(binding, geometry, point))

    def move_normalized_point(
        self,
        binding: WindowBinding,
        normalized_point: tuple[float, float],
    ) -> ClickStatus:
        """Move only (no mouse button event) after window/focus validation."""

        x, y = normalized_point
        if not (0.0 <= x <= 1.0 and 0.0 <= y <= 1.0):
            raise CoordinateSafetyError("normalized UI point is outside the client")
        status = self.window_status(binding)
        if not status.valid or status.geometry is None:
            return ClickStatus.WINDOW_INVALID
        if status.foreground is not True:
            return ClickStatus.GAME_NOT_FOREGROUND
        geometry = status.geometry
        screen_x = geometry.left + int(x * (geometry.width - 1))
        screen_y = geometry.top + int(y * (geometry.height - 1))
        if not self.backend.set_cursor_pos(screen_x, screen_y):
            return ClickStatus.CURSOR_MOVE_FAILED
        return ClickStatus.SENT


if os.name == "nt":
    _user32 = ctypes.WinDLL("user32", use_last_error=True)
    _user32.GetForegroundWindow.restype = wintypes.HWND
    _user32.GetWindowThreadProcessId.argtypes = [
        wintypes.HWND,
        ctypes.POINTER(wintypes.DWORD),
    ]
    _user32.GetWindowThreadProcessId.restype = wintypes.DWORD
    _user32.SetCursorPos.argtypes = [ctypes.c_int, ctypes.c_int]
    _user32.SetCursorPos.restype = wintypes.BOOL
    _user32.GetAsyncKeyState.argtypes = [ctypes.c_int]
    _user32.GetAsyncKeyState.restype = wintypes.SHORT
    _user32.mouse_event.argtypes = [
        wintypes.DWORD,
        wintypes.DWORD,
        wintypes.DWORD,
        wintypes.DWORD,
        ctypes.c_size_t,
    ]
    _user32.mouse_event.restype = None
    try:
        _user32.SetProcessDPIAware()
    except OSError:
        pass

    class _POINT(ctypes.Structure):
        _fields_ = [("x", wintypes.LONG), ("y", wintypes.LONG)]

    class _RECT(ctypes.Structure):
        _fields_ = [
            ("left", wintypes.LONG),
            ("top", wintypes.LONG),
            ("right", wintypes.LONG),
            ("bottom", wintypes.LONG),
        ]

    # Explicit HWND signatures are important in a 64-bit Python process.  The
    # ctypes default is c_int, which can truncate handles when argtypes are not
    # declared.
    _user32.IsWindow.argtypes = [wintypes.HWND]
    _user32.IsWindow.restype = wintypes.BOOL
    _user32.IsWindowVisible.argtypes = [wintypes.HWND]
    _user32.IsWindowVisible.restype = wintypes.BOOL
    _user32.IsIconic.argtypes = [wintypes.HWND]
    _user32.IsIconic.restype = wintypes.BOOL
    _user32.GetClientRect.argtypes = [
        wintypes.HWND,
        ctypes.POINTER(_RECT),
    ]
    _user32.GetClientRect.restype = wintypes.BOOL
    _user32.ClientToScreen.argtypes = [
        wintypes.HWND,
        ctypes.POINTER(_POINT),
    ]
    _user32.ClientToScreen.restype = wintypes.BOOL
    _user32.GetSystemMetrics.argtypes = [ctypes.c_int]
    _user32.GetSystemMetrics.restype = ctypes.c_int
    _user32.GetWindowTextLengthW.argtypes = [wintypes.HWND]
    _user32.GetWindowTextLengthW.restype = ctypes.c_int
    _user32.GetWindowTextW.argtypes = [
        wintypes.HWND,
        wintypes.LPWSTR,
        ctypes.c_int,
    ]
    _user32.GetWindowTextW.restype = ctypes.c_int
    _user32.EnumWindows.argtypes = [ctypes.c_void_p, wintypes.LPARAM]
    _user32.EnumWindows.restype = wintypes.BOOL


class NativeWin32Backend:
    def __init__(self) -> None:
        if os.name != "nt":
            raise OSError("normal Windows input is Windows-only")

    def client_geometry(self, hwnd: int) -> ClientGeometry | None:
        if not _user32.IsWindow(hwnd) or not _user32.IsWindowVisible(hwnd):
            return None
        if _user32.IsIconic(hwnd):
            return None
        rect = _RECT()
        point = _POINT(0, 0)
        if not _user32.GetClientRect(hwnd, ctypes.byref(rect)):
            return None
        if not _user32.ClientToScreen(hwnd, ctypes.byref(point)):
            return None
        width = int(rect.right - rect.left)
        height = int(rect.bottom - rect.top)
        if width <= 0 or height <= 0:
            return None
        return ClientGeometry(int(point.x), int(point.y), width, height)

    def is_foreground(self, hwnd: int) -> bool:
        return bool(hwnd) and int(_user32.GetForegroundWindow()) == int(hwnd)

    def window_pid(self, hwnd: int) -> int | None:
        if not _user32.IsWindow(hwnd):
            return None
        value = wintypes.DWORD()
        _user32.GetWindowThreadProcessId(hwnd, ctypes.byref(value))
        return int(value.value) or None

    def set_cursor_pos(self, x: int, y: int) -> bool:
        return bool(_user32.SetCursorPos(x, y))

    def click_mouse(self) -> None:
        _user32.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
        time.sleep(0.025)
        _user32.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

    def virtual_screen(self) -> tuple[int, int, int, int]:
        left = int(_user32.GetSystemMetrics(76))
        top = int(_user32.GetSystemMetrics(77))
        width = int(_user32.GetSystemMetrics(78))
        height = int(_user32.GetSystemMetrics(79))
        return left, top, left + width, top + height


def find_window_for_pid(pid: int, backend: NativeWin32Backend) -> WindowBinding:
    if pid <= 0:
        raise ValueError("PID must be positive")
    matches: list[tuple[int, str, ClientGeometry]] = []
    callback_type = ctypes.WINFUNCTYPE(wintypes.BOOL, wintypes.HWND, wintypes.LPARAM)

    @callback_type
    def callback(hwnd: int, _lparam: int) -> bool:
        if backend.window_pid(int(hwnd)) != pid:
            return True
        geometry = backend.client_geometry(int(hwnd))
        if geometry is None:
            return True
        length = int(_user32.GetWindowTextLengthW(hwnd))
        buffer = ctypes.create_unicode_buffer(length + 1)
        _user32.GetWindowTextW(hwnd, buffer, length + 1)
        if buffer.value:
            matches.append((int(hwnd), buffer.value, geometry))
        return True

    if not _user32.EnumWindows(callback, 0):
        raise ctypes.WinError(ctypes.get_last_error())
    if not matches:
        raise RuntimeError(f"no visible client window belongs to PID {pid}")
    hwnd, title, geometry = max(
        matches, key=lambda item: item[2].width * item[2].height
    )
    return WindowBinding(hwnd, pid, title, geometry.width, geometry.height)


class HotkeyEdges:
    """Edge-trigger F8 confirmation and F9 emergency stop."""

    def __init__(self) -> None:
        self._f8_down = False
        self._f9_down = False

    def poll(self) -> tuple[bool, bool]:
        if os.name != "nt":
            return False, False
        f8_raw = int(_user32.GetAsyncKeyState(VK_F8)) & 0xFFFF
        f9_raw = int(_user32.GetAsyncKeyState(VK_F9)) & 0xFFFF
        f8_down = bool(f8_raw & 0x8000)
        f9_down = bool(f9_raw & 0x8000)
        # The low bit preserves a short press that occurred during a memory scan.
        f8_edge = bool(f8_raw & 0x1) or (f8_down and not self._f8_down)
        f9_edge = bool(f9_raw & 0x1) or (f9_down and not self._f9_down)
        self._f8_down, self._f9_down = f8_down, f9_down
        return f8_edge, f9_edge


class RecoveryHotkeyEdges:
    """F10 advances exactly one recovery UI step; F9 always stops."""

    def __init__(self) -> None:
        self._f10_down = False
        self._f9_down = False

    def poll(self) -> tuple[bool, bool]:
        if os.name != "nt":
            return False, False
        f10_raw = int(_user32.GetAsyncKeyState(VK_F10)) & 0xFFFF
        f9_raw = int(_user32.GetAsyncKeyState(VK_F9)) & 0xFFFF
        f10_down = bool(f10_raw & 0x8000)
        f9_down = bool(f9_raw & 0x8000)
        f10_edge = bool(f10_raw & 0x1) or (f10_down and not self._f10_down)
        f9_edge = bool(f9_raw & 0x1) or (f9_down and not self._f9_down)
        self._f10_down, self._f9_down = f10_down, f9_down
        return f10_edge, f9_edge


class AutoHotkeyEdges:
    """F7 toggles pause/resume, F10 advances recovery, F9 stops."""

    def __init__(self) -> None:
        self._f7_down = False
        self._f9_down = False
        self._f10_down = False

    def poll(self) -> tuple[bool, bool, bool]:
        if os.name != "nt":
            return False, False, False
        values = {
            "f7": int(_user32.GetAsyncKeyState(VK_F7)) & 0xFFFF,
            "f9": int(_user32.GetAsyncKeyState(VK_F9)) & 0xFFFF,
            "f10": int(_user32.GetAsyncKeyState(VK_F10)) & 0xFFFF,
        }
        f7_down = bool(values["f7"] & 0x8000)
        f9_down = bool(values["f9"] & 0x8000)
        f10_down = bool(values["f10"] & 0x8000)
        f7_edge = bool(values["f7"] & 0x1) or (f7_down and not self._f7_down)
        f9_edge = bool(values["f9"] & 0x1) or (f9_down and not self._f9_down)
        f10_edge = bool(values["f10"] & 0x1) or (f10_down and not self._f10_down)
        self._f7_down, self._f9_down, self._f10_down = (
            f7_down,
            f9_down,
            f10_down,
        )
        return f7_edge, f10_edge, f9_edge

    def emergency_stop_requested(self) -> bool:
        """Recheck F9 between slow reads and the first gameplay input."""

        if os.name != "nt":
            return False
        value = int(_user32.GetAsyncKeyState(VK_F9)) & 0xFFFF
        down = bool(value & 0x8000)
        edge = bool(value & 0x1) or (down and not self._f9_down)
        self._f9_down = down
        return edge

    def pause_toggle_requested(self) -> bool:
        """Recheck F7 before input so pause cannot race a slow state read."""

        if os.name != "nt":
            return False
        value = int(_user32.GetAsyncKeyState(VK_F7)) & 0xFFFF
        down = bool(value & 0x8000)
        edge = bool(value & 0x1) or (down and not self._f7_down)
        self._f7_down = down
        return edge
