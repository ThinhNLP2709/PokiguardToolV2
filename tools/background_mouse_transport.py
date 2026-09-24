"""Bounded background-mouse transport used only by the Phase 4A.1 probe.

This module is deliberately outside the production package.  It exposes three
typed, one-shot commands and no generic message or arbitrary-coordinate CLI.
Windows queue success is delivery telemetry only; callers must classify the
result with an authoritative game-state acknowledgement.
"""

from __future__ import annotations

import ctypes
from ctypes import wintypes
from dataclasses import asdict, dataclass, is_dataclass
from enum import Enum
import os
import time
from typing import Any, Callable, Protocol

from pokiguard_v2.win32_input import ClientGeometry, CoordinatePlan, WindowBinding


WM_MOUSEMOVE = 0x0200
WM_LBUTTONDOWN = 0x0201
WM_LBUTTONUP = 0x0202
MK_LBUTTON = 0x0001


class ProbeCommand(str, Enum):
    START_SINGLE_CLICK = "START_SINGLE_CLICK"
    BOARD_TWO_CLICK = "BOARD_TWO_CLICK"
    BOARD_DRAG = "BOARD_DRAG"


class TransportStatus(str, Enum):
    QUEUED = "QUEUED"
    UNARMED = "UNARMED"
    WRONG_COMMAND = "WRONG_COMMAND"
    ALREADY_CONSUMED = "ALREADY_CONSUMED"
    WINDOW_INVALID = "WINDOW_INVALID"
    WINDOW_CHANGED = "WINDOW_CHANGED"
    GAME_FOREGROUND = "GAME_FOREGROUND"
    STALE_ACTION = "STALE_ACTION"
    STOPPED = "STOPPED"
    QUEUE_FAILED = "QUEUE_FAILED"
    PARTIAL_INPUT = "PARTIAL_INPUT"


class ProbeOutcome(str, Enum):
    ACCEPTED = "ACCEPTED"
    REJECTED = "REJECTED"
    UNCONFIRMED = "UNCONFIRMED"
    NOT_RUN = "NOT_RUN"
    PARTIAL_INPUT = "PARTIAL_INPUT"


@dataclass(frozen=True)
class SwapPreState:
    match_id: str
    turn: int
    local_username: str
    local_move_sequence: int
    first: tuple[int, int]
    second: tuple[int, int]


def runtime_proves_swap_accepted(pre: SwapPreState, runtime: Any) -> bool:
    """Match the existing production ACK without importing policy objects."""

    current_player = getattr(runtime, "current_player", None)
    local_username = getattr(runtime, "local_username", None)
    local_sequence = getattr(runtime, "local_move_sequence", None)
    if (
        getattr(runtime, "match_id", None) != pre.match_id
        or getattr(runtime, "turn", None) != pre.turn + 1
        or not current_player
        or not local_username
        or local_username.casefold() != pre.local_username.casefold()
        or current_player.casefold() == local_username.casefold()
        or local_sequence != pre.local_move_sequence + 1
        or getattr(runtime, "last_move_sequence", None) != local_sequence
    ):
        return False
    first_row, first_col = pre.first
    second_row, second_col = pre.second
    return (
        getattr(runtime, "last_move_from_col", None),
        getattr(runtime, "last_move_from_row", None),
        getattr(runtime, "last_move_to_col", None),
        getattr(runtime, "last_move_to_row", None),
    ) == (
        first_col,
        7 - first_row,
        second_col,
        7 - second_row,
    )


@dataclass(frozen=True)
class ExactWindowBinding:
    window: WindowBinding
    geometry: ClientGeometry


@dataclass(frozen=True)
class MessageRecord:
    index: int
    name: str
    message: int
    w_param: int
    l_param: int
    client_x: int
    client_y: int
    monotonic_seconds: float
    foreground_hwnd: int | None
    queued: bool
    cleanup: bool = False


@dataclass(frozen=True)
class TransportResult:
    command: ProbeCommand
    action_identity: str
    status: TransportStatus
    records: tuple[MessageRecord, ...]
    reason: str
    cursor_before: tuple[int, int] | None
    cursor_after: tuple[int, int] | None
    foreground_before: int | None
    foreground_after: int | None

    @property
    def fully_queued(self) -> bool:
        return self.status is TransportStatus.QUEUED

    @property
    def cursor_unchanged(self) -> bool | None:
        if self.cursor_before is None or self.cursor_after is None:
            return None
        return self.cursor_before == self.cursor_after


class BackgroundMouseBackend(Protocol):
    def window_pid(self, hwnd: int) -> int | None: ...
    def window_title(self, hwnd: int) -> str | None: ...
    def client_geometry(self, hwnd: int) -> ClientGeometry | None: ...
    def is_window_visible(self, hwnd: int) -> bool: ...
    def is_iconic(self, hwnd: int) -> bool: ...
    def foreground_window(self) -> int | None: ...
    def cursor_pos(self) -> tuple[int, int] | None: ...
    def post_message(self, hwnd: int, message: int, w_param: int, l_param: int) -> bool: ...


def pack_client_lparam(x: int, y: int) -> int:
    """Pack non-negative client coordinates exactly as MAKELPARAM does."""

    if not isinstance(x, int) or not isinstance(y, int):
        raise TypeError("client coordinates must be integers")
    if not 0 <= x <= 0xFFFF or not 0 <= y <= 0xFFFF:
        raise ValueError("client coordinates are outside the 16-bit LPARAM range")
    return (y << 16) | x


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


def classify_probe_outcome(
    transport: TransportResult,
    *,
    authoritative_ack: bool | None,
    explicit_reject: bool = False,
) -> ProbeOutcome:
    """Keep queue delivery separate from game acceptance."""

    if transport.status is TransportStatus.PARTIAL_INPUT:
        return ProbeOutcome.PARTIAL_INPUT
    if transport.status is not TransportStatus.QUEUED:
        return ProbeOutcome.NOT_RUN
    if authoritative_ack is True:
        return ProbeOutcome.ACCEPTED
    if explicit_reject:
        return ProbeOutcome.REJECTED
    return ProbeOutcome.UNCONFIRMED


class BoundedBackgroundMouseTransport:
    """One explicit arm permits exactly one typed message sequence."""

    def __init__(
        self,
        backend: BackgroundMouseBackend,
        *,
        sleeper: Callable[[float], None] = time.sleep,
        monotonic: Callable[[], float] = time.monotonic,
        stop_requested: Callable[[], bool] = lambda: False,
        event_sink: Callable[[str, dict[str, Any]], None] | None = None,
        click_hold_seconds: float = 0.025,
        two_click_delay_seconds: float = 0.35,
        drag_duration_seconds: float = 0.10,
        drag_steps: int = 3,
        drag_overshoot_fraction: float = 0.35,
    ) -> None:
        if not 0.01 <= click_hold_seconds <= 0.15:
            raise ValueError("click_hold_seconds is outside the bounded range")
        if not 0.05 <= two_click_delay_seconds <= 2.0:
            raise ValueError("two_click_delay_seconds is outside the bounded range")
        if not 0.03 <= drag_duration_seconds <= 0.50:
            raise ValueError("drag_duration_seconds is outside the bounded range")
        if not 1 <= drag_steps <= 12:
            raise ValueError("drag_steps is outside the bounded range")
        if not 0.0 <= drag_overshoot_fraction < 0.5:
            raise ValueError("drag_overshoot_fraction must be in [0, 0.5)")
        self.backend = backend
        self.sleeper = sleeper
        self.monotonic = monotonic
        self.stop_requested = stop_requested
        self.event_sink = event_sink or (lambda _event, _fields: None)
        self.click_hold_seconds = float(click_hold_seconds)
        self.two_click_delay_seconds = float(two_click_delay_seconds)
        self.drag_duration_seconds = float(drag_duration_seconds)
        self.drag_steps = int(drag_steps)
        self.drag_overshoot_fraction = float(drag_overshoot_fraction)
        self._armed: tuple[ProbeCommand, ExactWindowBinding, str] | None = None
        self._consumed = False

    def arm(
        self,
        command: ProbeCommand,
        binding: ExactWindowBinding,
        action_identity: str,
    ) -> None:
        if self._armed is not None or self._consumed:
            raise RuntimeError("this transport instance has already been armed")
        if not action_identity.strip():
            raise ValueError("action_identity is required")
        failure = self._binding_failure(binding)
        if failure is not None:
            raise RuntimeError(f"cannot arm: {failure.value}")
        self._armed = (command, binding, action_identity)
        self.event_sink(
            "background_transport_armed",
            {"command": command.value, "actionIdentity": action_identity},
        )

    def send_start_single_click(
        self,
        normalized_point: tuple[float, float],
        *,
        preflight: Callable[[], bool],
    ) -> TransportResult:
        command = ProbeCommand.START_SINGLE_CLICK
        prepared = self._begin(command)
        if isinstance(prepared, TransportResult):
            return prepared
        binding, identity, records, cursor_before, foreground_before = prepared
        x, y = normalized_point
        if not (0.0 <= x <= 1.0 and 0.0 <= y <= 1.0):
            raise ValueError("normalized Start point is outside the client")
        point = (
            int(x * (binding.geometry.width - 1)),
            int(y * (binding.geometry.height - 1)),
        )
        return self._send_click_sequence(
            command,
            binding,
            identity,
            records,
            cursor_before,
            foreground_before,
            (point,),
            preflight,
        )

    def send_board_two_click(
        self,
        plan: CoordinatePlan,
        *,
        preflight: Callable[[], bool],
    ) -> TransportResult:
        command = ProbeCommand.BOARD_TWO_CLICK
        prepared = self._begin(command)
        if isinstance(prepared, TransportResult):
            return prepared
        binding, identity, records, cursor_before, foreground_before = prepared
        self._validate_plan(binding, plan)
        return self._send_click_sequence(
            command,
            binding,
            identity,
            records,
            cursor_before,
            foreground_before,
            (
                (plan.first.client_x, plan.first.client_y),
                (plan.second.client_x, plan.second.client_y),
            ),
            preflight,
            inter_click_delay=self.two_click_delay_seconds,
        )

    def send_board_drag(
        self,
        plan: CoordinatePlan,
        *,
        preflight: Callable[[], bool],
    ) -> TransportResult:
        command = ProbeCommand.BOARD_DRAG
        prepared = self._begin(command)
        if isinstance(prepared, TransportResult):
            return prepared
        binding, identity, records, cursor_before, foreground_before = prepared
        self._validate_plan(binding, plan)
        start = (plan.first.client_x, plan.first.client_y)
        delta_x = plan.second.client_x - start[0]
        delta_y = plan.second.client_y - start[1]
        end = (
            plan.second.client_x + round(delta_x * self.drag_overshoot_fraction),
            plan.second.client_y + round(delta_y * self.drag_overshoot_fraction),
        )
        left, top, right, bottom = plan.board_rect_client
        if not (left <= end[0] <= right and top <= end[1] <= bottom):
            return self._finish(
                command, identity, TransportStatus.WINDOW_CHANGED, records,
                "drag endpoint is outside the proven board rectangle",
                cursor_before, foreground_before,
            )

        failure = self._pre_message_failure(binding, preflight)
        if failure is not None:
            return self._finish(
                command, identity, failure, records, "drag preflight failed",
                cursor_before, foreground_before,
            )
        if not self._post(binding, "WM_MOUSEMOVE", WM_MOUSEMOVE, 0, start, records):
            return self._finish(
                command, identity, TransportStatus.QUEUE_FAILED, records,
                "initial move was not queued", cursor_before, foreground_before,
            )
        failure = self._pre_message_failure(binding, preflight)
        if failure is not None:
            return self._finish(
                command, identity, TransportStatus.PARTIAL_INPUT, records,
                f"pre-DOWN validation failed: {failure.value}",
                cursor_before, foreground_before,
            )
        if not self._post(
            binding, "WM_LBUTTONDOWN", WM_LBUTTONDOWN, MK_LBUTTON, start, records
        ):
            return self._finish(
                command, identity, TransportStatus.PARTIAL_INPUT, records,
                "DOWN was not queued after initial move", cursor_before, foreground_before,
            )

        completed = False
        failure_reason = "drag sequence did not complete"
        step_delay = self.drag_duration_seconds / self.drag_steps
        try:
            for index in range(1, self.drag_steps + 1):
                failure = self._pre_message_failure(binding, preflight)
                if failure is not None:
                    failure_reason = f"drag stopped before step {index}: {failure.value}"
                    break
                fraction = index / self.drag_steps
                point = (
                    round(start[0] + (plan.second.client_x - start[0]) * fraction),
                    round(start[1] + (plan.second.client_y - start[1]) * fraction),
                )
                if not self._post(
                    binding, "WM_MOUSEMOVE_HELD", WM_MOUSEMOVE, MK_LBUTTON,
                    point, records,
                ):
                    failure_reason = f"held move {index} was not queued"
                    break
                self.sleeper(step_delay)
            else:
                failure = self._pre_message_failure(binding, preflight)
                if failure is not None:
                    failure_reason = f"drag stopped before overshoot: {failure.value}"
                elif not self._post(
                    binding,
                    "WM_MOUSEMOVE_HELD_OVERSHOOT",
                    WM_MOUSEMOVE,
                    MK_LBUTTON,
                    end,
                    records,
                ):
                    failure_reason = "held overshoot move was not queued"
                else:
                    completed = True
        finally:
            # Cleanup deliberately bypasses stop/stale preflight.  Once DOWN
            # was queued, releasing the same bound HWND is mandatory.
            cleanup_point = (
                (records[-1].client_x, records[-1].client_y)
                if records else start
            )
            cleanup_ok = self._post(
                binding,
                "WM_LBUTTONUP_CLEANUP",
                WM_LBUTTONUP,
                0,
                cleanup_point,
                records,
                cleanup=True,
            )
            if not cleanup_ok:
                completed = False
                failure_reason = "mandatory UP cleanup was not queued"
        status = TransportStatus.QUEUED if completed else TransportStatus.PARTIAL_INPUT
        return self._finish(
            command, identity, status, records,
            "complete drag queued" if completed else failure_reason,
            cursor_before, foreground_before,
        )

    def _begin(
        self, command: ProbeCommand
    ) -> tuple[
        ExactWindowBinding,
        str,
        list[MessageRecord],
        tuple[int, int] | None,
        int | None,
    ] | TransportResult:
        if self._armed is None:
            status = (
                TransportStatus.ALREADY_CONSUMED
                if self._consumed else TransportStatus.UNARMED
            )
            return TransportResult(
                command, "", status, (), status.value,
                self.backend.cursor_pos(), self.backend.cursor_pos(),
                self.backend.foreground_window(), self.backend.foreground_window(),
            )
        armed_command, binding, identity = self._armed
        if armed_command is not command:
            return TransportResult(
                command, identity, TransportStatus.WRONG_COMMAND, (),
                f"armed for {armed_command.value}",
                self.backend.cursor_pos(), self.backend.cursor_pos(),
                self.backend.foreground_window(), self.backend.foreground_window(),
            )
        self._armed = None
        self._consumed = True
        return (
            binding,
            identity,
            [],
            self.backend.cursor_pos(),
            self.backend.foreground_window(),
        )

    def _send_click_sequence(
        self,
        command: ProbeCommand,
        binding: ExactWindowBinding,
        identity: str,
        records: list[MessageRecord],
        cursor_before: tuple[int, int] | None,
        foreground_before: int | None,
        points: tuple[tuple[int, int], ...],
        preflight: Callable[[], bool],
        *,
        inter_click_delay: float | None = None,
    ) -> TransportResult:
        for click_index, point in enumerate(points):
            if click_index and inter_click_delay is not None:
                self.sleeper(inter_click_delay)
            click_started = False
            for name, message, w_param in (
                ("WM_MOUSEMOVE", WM_MOUSEMOVE, 0),
                ("WM_LBUTTONDOWN", WM_LBUTTONDOWN, MK_LBUTTON),
                ("WM_LBUTTONUP", WM_LBUTTONUP, 0),
            ):
                failure = self._pre_message_failure(binding, preflight)
                if failure is not None:
                    if click_started:
                        self._post(
                            binding, "WM_LBUTTONUP_CLEANUP", WM_LBUTTONUP, 0,
                            point, records, cleanup=True,
                        )
                    partial = bool(records)
                    return self._finish(
                        command,
                        identity,
                        TransportStatus.PARTIAL_INPUT if partial else failure,
                        records,
                        f"validation before {name} failed: {failure.value}",
                        cursor_before,
                        foreground_before,
                    )
                queued = self._post(
                    binding, name, message, w_param, point, records
                )
                if message == WM_LBUTTONDOWN and queued:
                    click_started = True
                    # Match the V1 Beta candidate exactly: keep DOWN queued
                    # across a bounded 25 ms window before UP.  An immediate
                    # DOWN/UP pair can be consumed in the same Unity frame and
                    # does not test the audited background-click hypothesis.
                    self.sleeper(self.click_hold_seconds)
                if not queued:
                    if click_started:
                        self._post(
                            binding, "WM_LBUTTONUP_CLEANUP", WM_LBUTTONUP, 0,
                            point, records, cleanup=True,
                        )
                    return self._finish(
                        command,
                        identity,
                        (
                            TransportStatus.PARTIAL_INPUT
                            if records[:-1] else TransportStatus.QUEUE_FAILED
                        ),
                        records,
                        f"{name} was not queued",
                        cursor_before,
                        foreground_before,
                    )
                if message == WM_LBUTTONUP:
                    click_started = False
        return self._finish(
            command, identity, TransportStatus.QUEUED, records,
            "complete typed sequence queued", cursor_before, foreground_before,
        )

    def _pre_message_failure(
        self,
        binding: ExactWindowBinding,
        preflight: Callable[[], bool],
    ) -> TransportStatus | None:
        if self.stop_requested():
            return TransportStatus.STOPPED
        binding_failure = self._binding_failure(binding)
        if binding_failure is not None:
            return binding_failure
        try:
            if not preflight():
                return TransportStatus.STALE_ACTION
        except Exception:
            return TransportStatus.STALE_ACTION
        return None

    def _binding_failure(
        self, binding: ExactWindowBinding
    ) -> TransportStatus | None:
        hwnd = binding.window.hwnd
        if (
            self.backend.window_pid(hwnd) != binding.window.pid
            or not self.backend.is_window_visible(hwnd)
            or self.backend.is_iconic(hwnd)
        ):
            return TransportStatus.WINDOW_INVALID
        if self.backend.window_title(hwnd) != binding.window.title:
            return TransportStatus.WINDOW_CHANGED
        if self.backend.client_geometry(hwnd) != binding.geometry:
            return TransportStatus.WINDOW_CHANGED
        if self.backend.foreground_window() == hwnd:
            return TransportStatus.GAME_FOREGROUND
        return None

    @staticmethod
    def _validate_plan(binding: ExactWindowBinding, plan: CoordinatePlan) -> None:
        if plan.client_geometry != binding.geometry:
            raise ValueError("coordinate plan geometry differs from exact binding")
        for point in (plan.first, plan.second):
            if not (
                0 <= point.client_x < binding.geometry.width
                and 0 <= point.client_y < binding.geometry.height
            ):
                raise ValueError("coordinate plan point is outside the client")

    def _post(
        self,
        binding: ExactWindowBinding,
        name: str,
        message: int,
        w_param: int,
        point: tuple[int, int],
        records: list[MessageRecord],
        *,
        cleanup: bool = False,
    ) -> bool:
        x, y = point
        l_param = pack_client_lparam(x, y)
        queued = bool(
            self.backend.post_message(
                binding.window.hwnd, message, w_param, l_param
            )
        )
        record = MessageRecord(
            len(records), name, message, w_param, l_param, x, y,
            self.monotonic(), self.backend.foreground_window(), queued, cleanup,
        )
        records.append(record)
        self.event_sink("background_mouse_message", jsonable(record))
        return queued

    def _finish(
        self,
        command: ProbeCommand,
        identity: str,
        status: TransportStatus,
        records: list[MessageRecord],
        reason: str,
        cursor_before: tuple[int, int] | None,
        foreground_before: int | None,
    ) -> TransportResult:
        result = TransportResult(
            command,
            identity,
            status,
            tuple(records),
            reason,
            cursor_before,
            self.backend.cursor_pos(),
            foreground_before,
            self.backend.foreground_window(),
        )
        self.event_sink("background_transport_finished", jsonable(result))
        return result


if os.name == "nt":
    _user32 = ctypes.WinDLL("user32", use_last_error=True)
    _user32.PostMessageW.argtypes = [
        wintypes.HWND, wintypes.UINT, wintypes.WPARAM, wintypes.LPARAM
    ]
    _user32.PostMessageW.restype = wintypes.BOOL
    _user32.GetForegroundWindow.restype = wintypes.HWND
    _user32.GetCursorPos.argtypes = [ctypes.c_void_p]
    _user32.GetCursorPos.restype = wintypes.BOOL
    _user32.IsWindow.argtypes = [wintypes.HWND]
    _user32.IsWindow.restype = wintypes.BOOL
    _user32.IsWindowVisible.argtypes = [wintypes.HWND]
    _user32.IsWindowVisible.restype = wintypes.BOOL
    _user32.IsIconic.argtypes = [wintypes.HWND]
    _user32.IsIconic.restype = wintypes.BOOL
    _user32.GetWindowThreadProcessId.argtypes = [
        wintypes.HWND, ctypes.POINTER(wintypes.DWORD)
    ]
    _user32.GetWindowThreadProcessId.restype = wintypes.DWORD
    _user32.GetWindowTextLengthW.argtypes = [wintypes.HWND]
    _user32.GetWindowTextLengthW.restype = ctypes.c_int
    _user32.GetWindowTextW.argtypes = [wintypes.HWND, wintypes.LPWSTR, ctypes.c_int]
    _user32.GetWindowTextW.restype = ctypes.c_int

    class _POINT(ctypes.Structure):
        _fields_ = [("x", wintypes.LONG), ("y", wintypes.LONG)]


class NativeBackgroundMouseBackend:
    """Small PostMessageW backend; it never moves the system cursor."""

    def __init__(self, geometry_backend: Any) -> None:
        if os.name != "nt":
            raise OSError("background mouse probe is Windows-only")
        self.geometry_backend = geometry_backend

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
        return self.geometry_backend.client_geometry(hwnd)

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

    def post_message(self, hwnd: int, message: int, w_param: int, l_param: int) -> bool:
        return bool(_user32.PostMessageW(hwnd, message, w_param, l_param))


__all__ = [
    "BoundedBackgroundMouseTransport",
    "ExactWindowBinding",
    "MessageRecord",
    "NativeBackgroundMouseBackend",
    "ProbeCommand",
    "ProbeOutcome",
    "SwapPreState",
    "TransportResult",
    "TransportStatus",
    "classify_probe_outcome",
    "pack_client_lparam",
    "runtime_proves_swap_accepted",
]
