"""Foreground-only normal Windows input and verified board coordinate mapping."""

from __future__ import annotations

import ctypes
from ctypes import wintypes
from dataclasses import dataclass
from enum import Enum
import os
import threading
import time
from typing import Callable, Protocol

Cell = tuple[int, int]
VK_F7 = 0x76
VK_F8 = 0x77
VK_F9 = 0x78
VK_F10 = 0x79
VK_F6 = 0x75
MOUSEEVENTF_LEFTDOWN = 0x0002
MOUSEEVENTF_LEFTUP = 0x0004
KEYEVENTF_EXTENDEDKEY = 0x0001
KEYEVENTF_KEYUP = 0x0002
MAPVK_VK_TO_VSC = 0
QTE_DIRECTION_KEY_HOLD_SECONDS = 0.04
SW_RESTORE = 9
SWP_NOZORDER = 0x0004
SWP_NOACTIVATE = 0x0010
CANONICAL_CLIENT_WIDTH = 1280
CANONICAL_CLIENT_HEIGHT = 640
DEFAULT_SWAP_CLICK_DELAY_SECONDS = 0.35
DEFAULT_SWAP_CURSOR_SETTLE_SECONDS = 0.06
NATIVE_MOUSE_BUTTON_HOLD_SECONDS = 0.075
DEFAULT_SWAP_DRAG_DURATION_SECONDS = 0.10
DEFAULT_SWAP_DRAG_STEPS = 3
DEFAULT_SWAP_DRAG_OVERSHOOT_FRACTION = 0.35


class BoardInputMode(str, Enum):
    """Normal game input gesture used only for adjacent board swaps."""

    TWO_CLICK = "two_click"
    DRAG = "drag"


@dataclass(frozen=True)
class ClientGeometry:
    left: int
    top: int
    width: int
    height: int


@dataclass(frozen=True)
class BoardCalibration:
    first_center_x: float = 0.3620
    first_center_y: float = 0.1625
    step_x: float = 0.0393
    step_y: float = 0.0787

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
    def mouse_left_down(self) -> None: ...
    def mouse_left_up(self) -> None: ...
    def virtual_screen(self) -> tuple[int, int, int, int]: ...
    def restore_and_foreground(self, hwnd: int) -> bool: ...
    def resize_client(self, hwnd: int, width: int, height: int) -> bool: ...


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
    inter_click_delay_seconds: float | None = None
    pacing_mode: str | None = None
    pacing_reason: str | None = None
    lag_score: int | None = None
    cursor_settle_seconds: float | None = None
    mouse_button_hold_seconds: float | None = None
    input_mode: str = BoardInputMode.TWO_CLICK.value
    drag_duration_seconds: float | None = None
    drag_steps: int | None = None
    drag_overshoot_pixels: int | None = None

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


@dataclass(frozen=True)
class SwapPacingDecision:
    """Auditable delay selected for one ordinary two-click SWAP."""

    delay_seconds: float
    mode: str
    reason: str
    lag_score: int
    consecutive_fast_acknowledgements: int
    timer_clamped: bool = False


class AdaptiveSwapPacer:
    """Increase click separation only after evidence of a degraded client.

    Pokiguard does not expose a verified ping/FPS field in the read-only
    runtime.  Recovery/re-entry, exact SWAP outcome timeouts and slow accepted
    transitions are therefore used as conservative delivery-health signals.
    The normal 0.35-second path remains responsive, while the severe path spans
    several rendered frames even when the client temporarily falls to 3-4 FPS.
    """

    _LEVEL_DELAYS = (0.0, 0.60, 1.00, 1.50)
    _LEVEL_MODES = (
        "NORMAL",
        "CAUTIOUS",
        "RECOVERY_DEGRADED",
        "SEVERE_LAG",
    )

    def __init__(
        self,
        *,
        base_delay_seconds: float = DEFAULT_SWAP_CLICK_DELAY_SECONDS,
        maximum_delay_seconds: float = 1.50,
        slow_ack_seconds: float = 8.0,
        fast_ack_seconds: float = 4.0,
        clean_acknowledgements_to_decay: int = 8,
    ) -> None:
        if not 0.05 <= base_delay_seconds <= 1.0:
            raise ValueError("base click delay must be between 0.05 and 1.0 seconds")
        if not base_delay_seconds <= maximum_delay_seconds <= 2.0:
            raise ValueError("maximum click delay must be between base and 2.0 seconds")
        if not 0.0 < fast_ack_seconds < slow_ack_seconds:
            raise ValueError("fast ACK threshold must be below slow ACK threshold")
        if clean_acknowledgements_to_decay < 1:
            raise ValueError("clean ACK decay threshold must be positive")
        self.base_delay_seconds = float(base_delay_seconds)
        self.maximum_delay_seconds = float(maximum_delay_seconds)
        self.slow_ack_seconds = float(slow_ack_seconds)
        self.fast_ack_seconds = float(fast_ack_seconds)
        self.clean_acknowledgements_to_decay = int(
            clean_acknowledgements_to_decay
        )
        self._lag_score = 0
        self._consecutive_fast_acknowledgements = 0
        self._reason = "NO_DEGRADED_SIGNAL"
        self._lock = threading.Lock()

    def arm_recovery(self, reason: str = "RECOVERY_OR_REENTRY") -> None:
        """Keep the next recovered session slow until delivery proves stable."""

        with self._lock:
            self._lag_score = max(self._lag_score, 2)
            self._consecutive_fast_acknowledgements = 0
            self._reason = str(reason or "RECOVERY_OR_REENTRY")

    def observe_unconfirmed(self, reason: str = "SWAP_OUTCOME_UNCONFIRMED") -> None:
        with self._lock:
            self._lag_score = 3
            self._consecutive_fast_acknowledgements = 0
            self._reason = str(reason or "SWAP_OUTCOME_UNCONFIRMED")

    def observe_acknowledged(self, latency_seconds: float) -> None:
        latency = max(0.0, float(latency_seconds))
        with self._lock:
            if latency >= self.slow_ack_seconds:
                self._lag_score = max(self._lag_score, 2)
                self._consecutive_fast_acknowledgements = 0
                self._reason = "SLOW_ACCEPTED_SWAP"
                return
            if latency > self.fast_ack_seconds:
                self._consecutive_fast_acknowledgements = 0
                self._reason = "ACK_NOT_FAST_ENOUGH_TO_DECAY"
                return
            self._consecutive_fast_acknowledgements += 1
            if (
                self._lag_score > 0
                and self._consecutive_fast_acknowledgements
                >= self.clean_acknowledgements_to_decay
            ):
                self._lag_score -= 1
                self._consecutive_fast_acknowledgements = 0
                self._reason = "SUSTAINED_FAST_ACK_DECAY"

    def decision(
        self, *, remaining_seconds: float | None = None
    ) -> SwapPacingDecision:
        with self._lock:
            score = self._lag_score
            clean = self._consecutive_fast_acknowledgements
            reason = self._reason
        requested = max(
            self.base_delay_seconds,
            self._LEVEL_DELAYS[score],
        )
        requested = min(requested, self.maximum_delay_seconds)
        delay = requested
        timer_clamped = False
        if remaining_seconds is not None:
            # Preserve at least 1.25 seconds for the second click to be pumped
            # by the game. The integer server timer is conservative and may
            # already be part-way through its displayed second.
            timer_budget = max(
                self.base_delay_seconds,
                float(remaining_seconds) - 1.25,
            )
            if timer_budget < delay:
                delay = timer_budget
                timer_clamped = True
        return SwapPacingDecision(
            delay_seconds=round(delay, 3),
            mode=self._LEVEL_MODES[score],
            reason=reason,
            lag_score=score,
            consecutive_fast_acknowledgements=clean,
            timer_clamped=timer_clamped,
        )


class ForegroundClickExecutor:
    """Send a selected normal swap gesture without focusing/restoring a window."""

    def __init__(
        self,
        backend: Win32Backend,
        *,
        click_delay_seconds: float = DEFAULT_SWAP_CLICK_DELAY_SECONDS,
        cursor_settle_seconds: float = DEFAULT_SWAP_CURSOR_SETTLE_SECONDS,
        input_mode: BoardInputMode | str = BoardInputMode.TWO_CLICK,
        drag_duration_seconds: float = DEFAULT_SWAP_DRAG_DURATION_SECONDS,
        drag_steps: int = DEFAULT_SWAP_DRAG_STEPS,
        drag_overshoot_fraction: float = DEFAULT_SWAP_DRAG_OVERSHOOT_FRACTION,
        sleeper: Callable[[float], None] = time.sleep,
        swap_pacer: AdaptiveSwapPacer | None = None,
    ) -> None:
        if not 0.05 <= click_delay_seconds <= 1.0:
            raise ValueError("click delay must be between 0.05 and 1.0 seconds")
        if not 0.0 <= cursor_settle_seconds <= 0.25:
            raise ValueError("cursor settle must be between 0 and 0.25 seconds")
        if not 0.05 <= drag_duration_seconds <= 0.25:
            raise ValueError("drag duration must be between 0.05 and 0.25 seconds")
        if not 2 <= drag_steps <= 20:
            raise ValueError("drag steps must be between 2 and 20")
        if not 0.10 <= drag_overshoot_fraction <= 0.45:
            raise ValueError("drag overshoot must be between 0.10 and 0.45 cells")
        self.backend = backend
        self.click_delay_seconds = click_delay_seconds
        self.cursor_settle_seconds = cursor_settle_seconds
        self.input_mode = BoardInputMode(input_mode)
        self.drag_duration_seconds = float(drag_duration_seconds)
        self.drag_steps = int(drag_steps)
        self.drag_overshoot_fraction = float(drag_overshoot_fraction)
        self.sleeper = sleeper
        self.swap_pacer = swap_pacer or AdaptiveSwapPacer(
            base_delay_seconds=click_delay_seconds
        )

    def arm_recovery_swap_pacing(
        self, reason: str = "RECOVERY_OR_REENTRY"
    ) -> None:
        self.swap_pacer.arm_recovery(reason)

    def note_swap_acknowledged(self, latency_seconds: float) -> None:
        self.swap_pacer.observe_acknowledged(latency_seconds)

    def note_swap_unconfirmed(
        self, reason: str = "SWAP_OUTCOME_UNCONFIRMED"
    ) -> None:
        self.swap_pacer.observe_unconfirmed(reason)

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
        self,
        binding: WindowBinding,
        expected: ClientGeometry,
        point: PixelPoint,
        *,
        settle_cursor: bool = False,
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
        # Unity's legacy mouse path samples cursor/button state on rendered
        # frames.  SetCursorPos succeeding only proves the OS cursor moved; it
        # does not prove the game has sampled that position yet.  The 1.7.4
        # client dropped a correct tile-centre pair with the former immediate
        # mouse pulse, so board swaps deliberately span several 60-FPS frames.
        if settle_cursor and self.cursor_settle_seconds > 0:
            self.sleeper(self.cursor_settle_seconds)
        if not self.backend.is_foreground(binding.hwnd):
            return ClickStatus.GAME_NOT_FOREGROUND
        self.backend.click_mouse()
        return ClickStatus.SENT

    def send_swap(
        self,
        binding: WindowBinding,
        plan: CoordinatePlan,
        *,
        remaining_seconds: float | None = None,
    ) -> ClickPairResult:
        pacing = self.swap_pacer.decision(remaining_seconds=remaining_seconds)
        if self.input_mode is BoardInputMode.DRAG:
            return self._send_drag(binding, plan, pacing)
        first = self._send_one(
            binding,
            plan.client_geometry,
            plan.first,
            settle_cursor=True,
        )
        if first is not ClickStatus.SENT:
            return ClickPairResult(
                first,
                0,
                pacing.delay_seconds,
                pacing.mode,
                pacing.reason,
                pacing.lag_score,
                self.cursor_settle_seconds,
                getattr(self.backend, "mouse_button_hold_seconds", None),
                BoardInputMode.TWO_CLICK.value,
            )
        self.sleeper(pacing.delay_seconds)
        second = self._send_one(
            binding,
            plan.client_geometry,
            plan.second,
            settle_cursor=True,
        )
        if second is not ClickStatus.SENT:
            return ClickPairResult(
                ClickStatus.PARTIAL_INPUT,
                1,
                pacing.delay_seconds,
                pacing.mode,
                pacing.reason,
                pacing.lag_score,
                self.cursor_settle_seconds,
                getattr(self.backend, "mouse_button_hold_seconds", None),
                BoardInputMode.TWO_CLICK.value,
            )
        return ClickPairResult(
            ClickStatus.SENT,
            2,
            pacing.delay_seconds,
            pacing.mode,
            pacing.reason,
            pacing.lag_score,
            self.cursor_settle_seconds,
            getattr(self.backend, "mouse_button_hold_seconds", None),
            BoardInputMode.TWO_CLICK.value,
        )

    def _send_drag(
        self,
        binding: WindowBinding,
        plan: CoordinatePlan,
        pacing: SwapPacingDecision,
    ) -> ClickPairResult:
        """Flick from the first gem and release beyond the second gem's centre.

        ``Dot.OnMouseUp`` compares the press/release displacement with
        ``swipeResit``; the accepted gesture is directional rather than tied to
        the target centre.  Live evidence showed that a slow six-step traverse
        left the first gem tap-selected, while a quick manual flick (including
        an overshoot) was accepted.  Keep the gesture short and release inside
        the far half of the adjacent target cell.  Every intermediate move
        revalidates the exact HWND/PID, client geometry and foreground, and
        LEFTUP is unconditional after a successful LEFTDOWN.
        """

        # Drag must remain a flick even after an unrelated unconfirmed action;
        # adaptive two-click pacing must not stretch it back into the live-
        # rejected slow gesture.  Adjacent cell centres provide the cell step.
        duration = self.drag_duration_seconds
        delta_x = plan.second.screen_x - plan.first.screen_x
        delta_y = plan.second.screen_y - plan.first.screen_y
        overshoot_x = round(delta_x * self.drag_overshoot_fraction)
        overshoot_y = round(delta_y * self.drag_overshoot_fraction)
        end_x = plan.second.screen_x + overshoot_x
        end_y = plan.second.screen_y + overshoot_y
        board_left, board_top, board_right, board_bottom = plan.board_rect_client
        board_screen = (
            plan.client_geometry.left + board_left,
            plan.client_geometry.top + board_top,
            plan.client_geometry.left + board_right,
            plan.client_geometry.top + board_bottom,
        )
        if not (
            board_screen[0] <= end_x <= board_screen[2]
            and board_screen[1] <= end_y <= board_screen[3]
        ):
            # This should be impossible for an adjacent centre plus <0.5 cell,
            # but fail closed if a future calibration violates that invariant.
            return ClickPairResult(
                status=ClickStatus.WINDOW_CHANGED,
                sent_clicks=0,
                pacing_mode=pacing.mode,
                pacing_reason="DRAG_ENDPOINT_OUTSIDE_BOARD",
                lag_score=pacing.lag_score,
                cursor_settle_seconds=self.cursor_settle_seconds,
                input_mode=BoardInputMode.DRAG.value,
                drag_duration_seconds=round(duration, 3),
                drag_steps=self.drag_steps,
                drag_overshoot_pixels=max(abs(overshoot_x), abs(overshoot_y)),
            )
        drag_distance_x = end_x - plan.first.screen_x
        drag_distance_y = end_y - plan.first.screen_y
        overshoot_pixels = max(abs(overshoot_x), abs(overshoot_y))

        def result(status: ClickStatus, sent_endpoints: int) -> ClickPairResult:
            return ClickPairResult(
                status=status,
                sent_clicks=sent_endpoints,
                inter_click_delay_seconds=None,
                pacing_mode=pacing.mode,
                pacing_reason=pacing.reason,
                lag_score=pacing.lag_score,
                cursor_settle_seconds=self.cursor_settle_seconds,
                mouse_button_hold_seconds=None,
                input_mode=BoardInputMode.DRAG.value,
                drag_duration_seconds=round(duration, 3),
                drag_steps=self.drag_steps,
                drag_overshoot_pixels=overshoot_pixels,
            )

        status = self.window_status(binding)
        if not status.valid or status.geometry is None:
            return result(ClickStatus.WINDOW_INVALID, 0)
        if status.geometry != plan.client_geometry:
            return result(ClickStatus.WINDOW_CHANGED, 0)
        if status.foreground is not True:
            return result(ClickStatus.GAME_NOT_FOREGROUND, 0)
        if not self.backend.set_cursor_pos(plan.first.screen_x, plan.first.screen_y):
            return result(ClickStatus.CURSOR_MOVE_FAILED, 0)
        if self.cursor_settle_seconds > 0:
            self.sleeper(self.cursor_settle_seconds)
        if not self.backend.is_foreground(binding.hwnd):
            return result(ClickStatus.GAME_NOT_FOREGROUND, 0)

        self.backend.mouse_left_down()
        completed = False
        failure = ClickStatus.PARTIAL_INPUT
        try:
            step_delay = duration / self.drag_steps
            for index in range(1, self.drag_steps + 1):
                current = self.window_status(binding)
                if not current.valid or current.geometry is None:
                    failure = ClickStatus.PARTIAL_INPUT
                    break
                if current.geometry != plan.client_geometry:
                    failure = ClickStatus.PARTIAL_INPUT
                    break
                if current.foreground is not True:
                    failure = ClickStatus.PARTIAL_INPUT
                    break
                fraction = index / self.drag_steps
                screen_x = round(
                    plan.first.screen_x
                    + drag_distance_x * fraction
                )
                screen_y = round(
                    plan.first.screen_y
                    + drag_distance_y * fraction
                )
                if not self.backend.set_cursor_pos(screen_x, screen_y):
                    failure = ClickStatus.PARTIAL_INPUT
                    break
                self.sleeper(step_delay)
            else:
                # Keep the release point beyond the target centre; moving back
                # first would erase the extra displacement sampled by Unity.
                if not self.backend.set_cursor_pos(end_x, end_y):
                    failure = ClickStatus.PARTIAL_INPUT
                elif not self.backend.is_foreground(binding.hwnd):
                    failure = ClickStatus.PARTIAL_INPUT
                else:
                    completed = True
        finally:
            self.backend.mouse_left_up()
        if not completed:
            return result(failure, 1)
        return result(ClickStatus.SENT, 2)

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
    _user32.ShowWindow.argtypes = [wintypes.HWND, ctypes.c_int]
    _user32.ShowWindow.restype = wintypes.BOOL
    _user32.BringWindowToTop.argtypes = [wintypes.HWND]
    _user32.BringWindowToTop.restype = wintypes.BOOL
    _user32.SetForegroundWindow.argtypes = [wintypes.HWND]
    _user32.SetForegroundWindow.restype = wintypes.BOOL
    _user32.GetClientRect.argtypes = [
        wintypes.HWND,
        ctypes.POINTER(_RECT),
    ]
    _user32.GetClientRect.restype = wintypes.BOOL
    _user32.GetWindowRect.argtypes = [
        wintypes.HWND,
        ctypes.POINTER(_RECT),
    ]
    _user32.GetWindowRect.restype = wintypes.BOOL
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
    _user32.keybd_event.argtypes = [
        wintypes.BYTE,
        wintypes.BYTE,
        wintypes.DWORD,
        wintypes.WPARAM,
    ]
    _user32.keybd_event.restype = None
    _user32.MapVirtualKeyW.argtypes = [wintypes.UINT, wintypes.UINT]
    _user32.MapVirtualKeyW.restype = wintypes.UINT


class NativeWin32Backend:
    mouse_button_hold_seconds = NATIVE_MOUSE_BUTTON_HOLD_SECONDS

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
        # GetForegroundWindow returns a NULL HWND — surfaced by ctypes as None —
        # whenever no window currently holds focus (a real, transient state
        # during alt-tab or while a menu is closing).  That is simply "not
        # foreground", not an error.
        foreground = _user32.GetForegroundWindow()
        return bool(hwnd) and foreground is not None and int(foreground) == int(hwnd)

    def restore_and_foreground(self, hwnd: int) -> bool:
        """Restore and foreground one already validated game window.

        This is a focus handoff only.  It sends no mouse/keyboard input and is
        intentionally separate from :class:`ForegroundClickExecutor`.
        """

        if not hwnd or not _user32.IsWindow(hwnd) or not _user32.IsWindowVisible(hwnd):
            return False
        if _user32.IsIconic(hwnd):
            _user32.ShowWindow(hwnd, SW_RESTORE)
            time.sleep(0.15)
        _user32.BringWindowToTop(hwnd)
        requested = bool(_user32.SetForegroundWindow(hwnd))
        return requested or self.is_foreground(hwnd)

    def resize_client(self, hwnd: int, width: int, height: int) -> bool:
        """Resize one validated normal window to an exact client size.

        The outer-frame delta is measured from the live window instead of
        guessed from a hard-coded border style.  The resulting outer rectangle
        is clamped to the virtual desktop, and the caller must independently
        reread ``client_geometry`` before trusting the result.
        """

        if (
            not hwnd
            or width <= 0
            or height <= 0
            or not _user32.IsWindow(hwnd)
            or not _user32.IsWindowVisible(hwnd)
        ):
            return False
        current = self.client_geometry(hwnd)
        if current is None:
            return False
        outer = _RECT()
        if not _user32.GetWindowRect(hwnd, ctypes.byref(outer)):
            return False
        outer_width = int(outer.right - outer.left)
        outer_height = int(outer.bottom - outer.top)
        target_outer_width = outer_width + int(width) - current.width
        target_outer_height = outer_height + int(height) - current.height
        screen_left, screen_top, screen_right, screen_bottom = self.virtual_screen()
        if (
            target_outer_width <= 0
            or target_outer_height <= 0
            or target_outer_width > screen_right - screen_left
            or target_outer_height > screen_bottom - screen_top
        ):
            return False
        left = min(
            max(int(outer.left), screen_left),
            screen_right - target_outer_width,
        )
        top = min(
            max(int(outer.top), screen_top),
            screen_bottom - target_outer_height,
        )
        return bool(
            _user32.SetWindowPos(
                hwnd,
                None,
                left,
                top,
                target_outer_width,
                target_outer_height,
                SWP_NOZORDER | SWP_NOACTIVATE,
            )
        )

    def window_pid(self, hwnd: int) -> int | None:
        if not _user32.IsWindow(hwnd):
            return None
        value = wintypes.DWORD()
        _user32.GetWindowThreadProcessId(hwnd, ctypes.byref(value))
        return int(value.value) or None

    def set_cursor_pos(self, x: int, y: int) -> bool:
        return bool(_user32.SetCursorPos(x, y))

    def click_mouse(self) -> None:
        self.mouse_left_down()
        # Hold across multiple rendered frames. A 25 ms pulse could begin and
        # end between Unity input samples on the 1.7.4 client even though the
        # cursor visibly reached the intended gem.
        time.sleep(self.mouse_button_hold_seconds)
        self.mouse_left_up()

    def mouse_left_down(self) -> None:
        _user32.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)

    def mouse_left_up(self) -> None:
        _user32.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

    def press_virtual_key(self, virtual_key: int) -> bool:
        """Emit one discrete normal Windows key press.

        This is an internal OS primitive.  Phase-specific callers must expose
        a narrower typed boundary; in particular the QTE direction executor
        maps only the four proven arrow directions to this method.

        The 1.7.4 ``CardUI.GetDirectionFromInput`` native body calls legacy
        ``UnityEngine.Input.GetKeyDown`` for Arrow/WASD pairs.  Live evidence
        showed that both virtual-key and scan-code ``SendInput`` events were
        reported as sent by Windows but never advanced CardUI's authoritative
        QTE index.  Use the matching legacy Windows keyboard synthesis path;
        RAM progress remains the only acceptance acknowledgement.
        """

        if not 1 <= int(virtual_key) <= 0xFE:
            raise ValueError("virtual_key is outside the Windows VK range")
        scan_code = int(
            _user32.MapVirtualKeyW(int(virtual_key), MAPVK_VK_TO_VSC)
        ) & 0xFF
        if scan_code == 0:
            return False
        flags = KEYEVENTF_EXTENDEDKEY if int(virtual_key) in (0x25, 0x26, 0x27, 0x28) else 0
        _user32.keybd_event(int(virtual_key), scan_code, flags, 0)
        # Keep the single logical press down across multiple rendered frames.
        time.sleep(QTE_DIRECTION_KEY_HOLD_SECONDS)
        _user32.keybd_event(
            int(virtual_key),
            scan_code,
            flags | KEYEVENTF_KEYUP,
            0,
        )
        return True

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


def foreground_process_window(
    pid: int, backend: NativeWin32Backend | None = None
) -> bool:
    """Best-effort focus handoff to the largest visible window owned by PID."""

    active_backend = backend or NativeWin32Backend()
    binding = find_window_for_pid(pid, active_backend)
    return active_backend.restore_and_foreground(binding.hwnd)


def prepare_bound_window(
    binding: WindowBinding,
    backend: Win32Backend,
    *,
    client_width: int = CANONICAL_CLIENT_WIDTH,
    client_height: int = CANONICAL_CLIENT_HEIGHT,
    sleeper: Callable[[float], None] = time.sleep,
) -> bool:
    """Foreground and normalize one already PID-bound game window.

    This is the desktop Start preflight.  It sends no keyboard or mouse input.
    Success means the exact HWND still belongs to the exact PID, is foreground,
    and has the canonical 2:1 client size after a fresh read. Two bounded resize
    corrections tolerate a one-pixel non-client/DPI rounding adjustment.
    """

    if (
        client_width < 640
        or client_height < 360
        or backend.window_pid(binding.hwnd) != binding.pid
        or not backend.restore_and_foreground(binding.hwnd)
    ):
        return False
    for _attempt in range(2):
        geometry = backend.client_geometry(binding.hwnd)
        if geometry is None or backend.window_pid(binding.hwnd) != binding.pid:
            return False
        if (geometry.width, geometry.height) == (client_width, client_height):
            break
        if not backend.resize_client(binding.hwnd, client_width, client_height):
            return False
        sleeper(0.12)
    geometry = backend.client_geometry(binding.hwnd)
    if (
        geometry is None
        or backend.window_pid(binding.hwnd) != binding.pid
        or (geometry.width, geometry.height) != (client_width, client_height)
    ):
        return False
    if not backend.restore_and_foreground(binding.hwnd):
        return False
    sleeper(0.08)
    final = backend.client_geometry(binding.hwnd)
    return bool(
        final is not None
        and backend.window_pid(binding.hwnd) == binding.pid
        and (final.width, final.height) == (client_width, client_height)
        and backend.is_foreground(binding.hwnd)
    )


def prepare_process_window(
    pid: int,
    backend: NativeWin32Backend | None = None,
) -> bool:
    """Prepare the largest visible exact-PID game window for desktop Start."""

    active_backend = backend or NativeWin32Backend()
    binding = find_window_for_pid(pid, active_backend)
    return prepare_bound_window(binding, active_backend)


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


class FarmControlHotkeyEdges:
    """F6 requests graceful stop (finish current match); F9 emergency stops.

    The GetAsyncKeyState 0x1 "pressed since last call" bit is cleared by the
    read itself, so it only survives until the next call *anywhere in this
    process*.  A farm run polls this object from several places (the farm
    boundary, the postmatch wait, the return-to-lobby wait), which means a
    press seen by one caller would be destroyed before the caller that acts on
    it ever runs.  Edges are therefore latched into durable counters here and
    consumed explicitly with take(); poll() only feeds the latch.
    """

    def __init__(self) -> None:
        self._f6_down = False
        self._f9_down = False
        self._f6_count = 0
        self._f9_count = 0
        self._programmatic_f6_unseen = 0
        self._programmatic_f9_unseen = 0
        self._emergency_requested = False
        self._emergency_ack_monotonic: float | None = None
        self._authorized_operations_started = 0
        self._authorized_operations_after_emergency_ack = 0
        self._lock = threading.Lock()

    @property
    def emergency_requested(self) -> bool:
        """Sticky controller-authority revocation for final input gates."""

        with self._lock:
            return self._emergency_requested

    @property
    def emergency_ack_monotonic(self) -> float | None:
        with self._lock:
            return self._emergency_ack_monotonic

    @property
    def authorized_operations_started(self) -> int:
        with self._lock:
            return self._authorized_operations_started

    @property
    def authorized_operations_after_emergency_ack(self) -> int:
        with self._lock:
            return self._authorized_operations_after_emergency_ack

    def request_graceful_stop(self) -> None:
        """Latch one programmatic F6-equivalent command without key input."""

        with self._lock:
            self._f6_count += 1
            self._programmatic_f6_unseen = 1

    def request_emergency_stop(self) -> None:
        """Latch F9-equivalent authority revocation without sending a key."""

        with self._lock:
            self._f9_count += 1
            self._programmatic_f9_unseen = 1
            self._emergency_requested = True
            self._emergency_ack_monotonic = (
                self._emergency_ack_monotonic or time.monotonic()
            )

    def execute_if_authorized(self, operation: Callable[[], object]) -> tuple[bool, object | None]:
        """Serialize emergency acknowledgement against one atomic input send.

        If an input already owns the lock, the emergency request is
        acknowledged only after that send returns.  Once the request has been
        acknowledged, no later operation can begin through this gate.
        """

        with self._lock:
            if self._emergency_requested:
                return False, None
            self._authorized_operations_started += 1
            return True, operation()

    def poll(self) -> tuple[bool, bool]:
        """Read the keyboard and latch any edge.  Safe to call at any rate."""
        if os.name != "nt":
            return False, False
        f6_raw = int(_user32.GetAsyncKeyState(VK_F6)) & 0xFFFF
        f9_raw = int(_user32.GetAsyncKeyState(VK_F9)) & 0xFFFF
        f6_down = bool(f6_raw & 0x8000)
        f9_down = bool(f9_raw & 0x8000)
        f6_edge = bool(f6_raw & 0x1) or (f6_down and not self._f6_down)
        f9_edge = bool(f9_raw & 0x1) or (f9_down and not self._f9_down)
        self._f6_down, self._f9_down = f6_down, f9_down
        with self._lock:
            programmatic_f6 = self._programmatic_f6_unseen > 0
            programmatic_f9 = self._programmatic_f9_unseen > 0
            if programmatic_f6:
                self._programmatic_f6_unseen -= 1
            if programmatic_f9:
                self._programmatic_f9_unseen -= 1
            if f6_edge:
                self._f6_count += 1
            if f9_edge:
                self._f9_count += 1
                self._emergency_requested = True
                self._emergency_ack_monotonic = (
                    self._emergency_ack_monotonic or time.monotonic()
                )
        return f6_edge or programmatic_f6, f9_edge or programmatic_f9

    def take(self) -> tuple[int, int]:
        """Poll once, then consume and return counts since last take."""
        self.poll()
        with self._lock:
            f6, f9 = self._f6_count, self._f9_count
            self._f6_count = self._f9_count = 0
        return f6, f9


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
