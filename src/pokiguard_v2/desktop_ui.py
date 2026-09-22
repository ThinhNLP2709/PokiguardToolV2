"""Lifecycle-aware Phase 2E.3 Tkinter control surface."""

from __future__ import annotations

from collections import deque
from dataclasses import asdict, dataclass
from enum import Enum
import json
from pathlib import Path
import threading
import time
from typing import Any, Callable

from .basic_policy import (
    Intelligence,
    PET_SKILL_FIRE_VALUE_DEFAULT,
    PET_SKILL_FIRE_VALUE_MAXIMUM,
    PET_SKILL_FIRE_VALUE_MINIMUM,
    PlayStyle,
)
from .pet_configuration import (
    AuditionMode, MainPetType, EvolutionTarget, DamageCardMode, MAIN_PET_LABELS,
    EVOLUTION_LABELS, DAMAGE_LABELS, AUDITION_LABELS, PLAY_STYLE_LABELS,
    PET_SKILL_FIRE_CONDITION_LABELS, PetSkillFireCondition,
    SUPPORTED_MAIN_PETS, SUPPORTED_EVOLUTIONS,
    loadout_capability, normalize_damage,
)
from .desktop_control_plane import (
    ControlPlaneSnapshot,
    DesktopConfig,
    DesktopControlPlane,
    SnapshotPoller,
    utc_timestamp,
)
from .desktop_farm_controller import (
    DesktopControllerSnapshot,
    DesktopControllerState,
)
from .desktop_preferences import (
    DesktopPreferenceStore,
    PreferenceError,
    PreferenceWarning,
)
from .version import APP_BUILD, APP_TITLE, APP_VERSION
from .win32_input import BoardInputMode


VISIBLE_RUNTIME_ROWS = (
    ("Trò chơi", "connection"),
    ("Trạng thái", "lifecycle"),
    ("Mục tiêu hiện tại", "runtime_target"),
)

DESKTOP_TAB_TITLES = ("Điều khiển", "Tùy chọn", "Cài đặt", "Chẩn đoán / Nhật ký")
PREFERENCE_TABLE_ROWS = (
    "Lối chơi",
    "Độ thông minh",
    "Pet của tôi",
    "Tiến hóa",
    "Thẻ sát thương",
    "Điều kiện ra skill",
    "Kiểu thử thách",
    "Cách đi bàn cờ",
)
SETTINGS_TABLE_ROWS = ("Tệp chạy trò chơi",)
INITIAL_FOCUS_TARGET = "notebook"
BACKGROUND_UNFOCUS_WIDGET_CLASSES = frozenset(
    {"Tk", "TFrame", "TLabelframe", "TLabel", "Frame", "Label"}
)

INTELLIGENCE_LABELS = {
    Intelligence.BASIC: "Cơ bản",
    Intelligence.REASONING: "Suy luận",
}
BOARD_INPUT_LABELS = {
    BoardInputMode.TWO_CLICK: "Hai lần nhấp",
    BoardInputMode.DRAG: "Kéo thả",
}

LIFECYCLE_LABELS = {
    "UNAVAILABLE": "KHÔNG KHẢ DỤNG",
    "UNKNOWN": "CHƯA XÁC ĐỊNH",
    "BOSS_LOBBY": "PHÒNG CHỜ BOSS",
    "ACTIVE_COMBAT": "ĐANG CHIẾN ĐẤU",
    "POSTMATCH": "SAU TRẬN",
    "LOBBY_OTHER": "SẢNH KHÁC",
}

LOBBY_BRANCH_LABELS = {
    "CHINH_PHUC_ROOM": "PHÒNG CHINH PHỤC",
}

CONTROLLER_STATE_LABELS = {
    "IDLE": "ĐANG RẢNH",
    "STARTING": "ĐANG KHỞI ĐỘNG",
    "RUNNING": "ĐANG CHẠY",
    "GRACEFUL_STOP_REQUESTED": "CHỜ DỪNG SAU TRẬN",
    "EMERGENCY_STOPPING": "ĐANG DỪNG KHẨN CẤP",
    "STOPPED": "ĐÃ DỪNG",
    "ERROR": "LỖI",
}

FINAL_STATUS_LABELS = {
    "COMPLETED": "HOÀN TẤT",
    "STOPPED_GRACEFULLY": "ĐÃ DỪNG AN TOÀN",
    "SAFE_STOP": "DỪNG AN TOÀN",
}

CLOSE_INTENT_LABELS = {
    "NONE": "KHÔNG CÓ",
    "AFTER_GRACEFUL_STOP": "ĐÓNG SAU KHI DỪNG AN TOÀN",
    "AFTER_EMERGENCY_STOP": "ĐÓNG SAU KHI DỪNG KHẨN CẤP",
}


def background_click_clears_entry_focus(widget_class: str) -> bool:
    """Return whether a pointer click represents non-interactive whitespace."""

    return widget_class in BACKGROUND_UNFOCUS_WIDGET_CLASSES


def decimal_digits_or_empty(value: str) -> bool:
    """Allow temporary empty edits and ASCII decimal digits only."""

    return value == "" or (value.isascii() and value.isdigit())


def run_limit_text(config: DesktopConfig) -> tuple[str, str]:
    """Normalize the two immutable per-run limits for their Entry variables."""

    return str(config.target_completed_matches), str(config.max_match_attempts)


def play_style_from_display(value: str) -> PlayStyle:
    """Map a visible label back to its stable serialized PlayStyle value."""

    for style, label in PLAY_STYLE_LABELS.items():
        if value == label:
            return style
    return PlayStyle(value)


def pet_skill_fire_condition_from_display(value: str) -> PetSkillFireCondition:
    """Map the exact Vietnamese dropdown label to its stable machine value."""

    for condition, label in PET_SKILL_FIRE_CONDITION_LABELS.items():
        if value == label:
            return condition
    return PetSkillFireCondition(value)


def audition_mode_from_display(value: str) -> AuditionMode:
    """Map the Vietnamese Audition label to its stable serialized value."""

    for mode, label in AUDITION_LABELS.items():
        if value == label:
            return mode
    return AuditionMode(value)


def intelligence_from_display(value: str) -> Intelligence:
    """Map the Vietnamese intelligence label to its stable serialized value."""

    for intelligence, label in INTELLIGENCE_LABELS.items():
        if value == label:
            return intelligence
    return Intelligence(value)


def board_input_mode_from_display(value: str) -> BoardInputMode:
    """Map the Vietnamese board-input label to its stable serialized value."""

    for mode, label in BOARD_INPUT_LABELS.items():
        if value == label:
            return mode
    return BoardInputMode(value)


def lifecycle_text(value: str | None) -> str:
    """Translate a runtime lifecycle for display without changing telemetry."""

    raw = value or "UNKNOWN"
    return LIFECYCLE_LABELS.get(raw, raw)


def controller_state_text(value: str) -> str:
    """Translate a controller state for display without changing its enum."""

    return CONTROLLER_STATE_LABELS.get(value, value)


def match_energy_text(controller: DesktopControllerSnapshot) -> str:
    """Compact per-match local-turn/energy accounting for the Control tab."""

    values = controller.completed_match_turns
    if values:
        visible = values[-8:]
        prefix = "… " if len(values) > len(visible) else ""
        per_match = ", ".join(
            f"#{attempt_index}: {turns}" for attempt_index, turns in visible
        )
        completed = f"Lượt / năng lượng các trận đã xong: {prefix}{per_match}"
    else:
        completed = "Lượt / năng lượng các trận đã xong: chưa có trận hoàn tất"
    current = (
        f"Lượt / năng lượng trận hiện tại: {controller.current_match_turns}"
        if controller.current_match_turns > 0
        else "Lượt / năng lượng trận hiện tại: —"
    )
    return (
        f"{completed}\n{current}\n"
        f"Tổng năng lượng: {controller.total_energy_used}"
    )


def graceful_button_text(controller: DesktopControllerSnapshot) -> str:
    """Show pending text only while a controller still owns active work.

    ``graceful_stop_requested`` remains true in the terminal snapshot as
    durable run evidence.  That history must not leave the operator control
    looking pending after the controller reaches its safe stopped boundary.
    """

    if controller.active and controller.graceful_stop_requested:
        return "Đang chờ dừng sau trận hiện tại..."
    return "Dừng sau trận hiện tại"


@dataclass(frozen=True)
class DesktopPresentation:
    connection: str
    attachment: str
    process: str
    lifecycle: str
    match_id: str
    session: str
    runtime_target: str
    checkpoint: str
    health: str
    error: str
    refreshed: str
    read_only_notice: str
    controller: str
    operator_status: str
    operator_guidance: str
    snapshot_actionable: bool


def visible_runtime_values(presentation: DesktopPresentation) -> tuple[tuple[str, str], ...]:
    """Return only values backed by widgets in the compact runtime panel."""

    return tuple(
        (key, getattr(presentation, key)) for _, key in VISIBLE_RUNTIME_ROWS
    )


@dataclass(frozen=True)
class DesktopUiResult:
    render_ticks: int
    handled_ui_errors: int
    poller_starts: int
    poller_alive_after_close: bool
    final_snapshot: ControlPlaneSnapshot
    operator_log_bound: int
    operator_log_max_observed: int
    operator_log_total_entries: int
    close_intent: str


@dataclass(frozen=True)
class OperatorLogEntry:
    sequence: int
    timestamp: str
    event: str
    message: str


class DesktopEventLog:
    """JSONL evidence plus a bounded thread-safe operator-visible ring."""

    def __init__(self, path: Path, *, max_display_entries: int = 500) -> None:
        if not 10 <= max_display_entries <= 5_000:
            raise ValueError("max_display_entries must be between 10 and 5000")
        self.path = path.resolve()
        self.path.parent.mkdir(parents=True, exist_ok=True)
        self._handle = self.path.open("a", encoding="utf-8", buffering=1)
        self._lock = threading.Lock()
        self._closed = False
        self._max_display_entries = int(max_display_entries)
        self._entries: deque[OperatorLogEntry] = deque(
            maxlen=self._max_display_entries
        )
        self._next_sequence = 1
        self._total_entries = 0
        self._jsonl_entries = 0
        self._max_observed_entries = 0
        self._last_poll_signature: tuple[Any, ...] | None = None

    @property
    def max_display_entries(self) -> int:
        return self._max_display_entries

    @staticmethod
    def _operator_message(event: str, fields: dict[str, Any]) -> str:
        explicit = fields.get("operatorMessage")
        if explicit:
            return str(explicit)[:400]
        parts: list[str] = []
        labels = {
            "reason": "lý do",
            "lifecycle": "trạng thái",
            "error": "lỗi",
            "farmRunId": "mã lượt chạy",
            "summary": "tóm tắt",
        }
        for key in ("reason", "lifecycle", "error", "farmRunId", "summary"):
            value = fields.get(key)
            if value not in (None, ""):
                parts.append(f"{labels[key]}={value}")
        return ("; ".join(parts) or event)[:400]

    def write(self, event: str, **fields: Any) -> None:
        with self._lock:
            if self._closed:
                return
            operator_visible = bool(fields.pop("_operator_visible", True))
            timestamp = utc_timestamp()
            self._handle.write(
                json.dumps(
                    {"timestamp": timestamp, "event": event, **fields},
                    ensure_ascii=False,
                    separators=(",", ":"),
                    default=str,
                )
                + "\n"
            )
            self._jsonl_entries += 1
            if not operator_visible:
                return
            entry = OperatorLogEntry(
                self._next_sequence,
                timestamp,
                event,
                self._operator_message(event, fields),
            )
            self._next_sequence += 1
            self._total_entries += 1
            self._entries.append(entry)
            self._max_observed_entries = max(
                self._max_observed_entries, len(self._entries)
            )

    def entries(self) -> tuple[OperatorLogEntry, ...]:
        with self._lock:
            return tuple(self._entries)

    def stats(self) -> dict[str, int]:
        with self._lock:
            return {
                "configuredBound": self._max_display_entries,
                "currentEntries": len(self._entries),
                "maxObservedEntries": self._max_observed_entries,
                "totalEntries": self._total_entries,
                "totalJsonlEntries": self._jsonl_entries,
            }

    def poll_event(
        self, event: str, snapshot: ControlPlaneSnapshot | None
    ) -> None:
        if snapshot is None:
            self.write(event)
            return
        runtime = snapshot.runtime
        controller = snapshot.controller
        signature = (
            runtime.game_detected,
            runtime.attached,
            runtime.pid,
            runtime.lifecycle,
            snapshot.health,
            snapshot.last_error,
            controller.generation,
            controller.state.value,
            controller.active,
            controller.completed_matches,
            controller.match_attempts,
            controller.last_stop_reason,
            controller.last_error,
        )
        with self._lock:
            operator_visible = signature != self._last_poll_signature
            self._last_poll_signature = signature
        self.write(
            event,
            _operator_visible=operator_visible,
            snapshotVersion=snapshot.version,
            health=snapshot.health,
            stale=snapshot.stale,
            gameDetected=runtime.game_detected,
            attached=runtime.attached,
            pid=runtime.pid,
            lifecycle=runtime.lifecycle,
            matchId=runtime.match_id,
            providerReason=runtime.provider_reason,
            error=snapshot.last_error,
            safety=asdict(snapshot.safety),
            controller=asdict(snapshot.controller),
            operatorMessage=(
                # Put the cause first so the bounded operator log cannot hide
                # a startup failure behind a healthy read-only runtime summary.
                (
                    f"lỗiBộĐiềuKhiển={controller.last_error}; "
                    if controller.last_error else ""
                )
                + (f"lỗi={snapshot.last_error}; " if snapshot.last_error else "")
                + f"{lifecycle_text(runtime.lifecycle)}; "
                f"bộ điều khiển={controller_state_text(controller.state.value)}; "
                f"hoàn thành={controller.completed_matches}; "
                f"lần thử={controller.match_attempts}"
            ),
        )

    def close(self) -> None:
        with self._lock:
            if self._closed:
                return
            self._closed = True
            self._handle.flush()
            self._handle.close()


class CloseChoice(str, Enum):
    CANCEL = "CANCEL"
    GRACEFUL = "GRACEFUL"
    EMERGENCY = "EMERGENCY"


class CloseIntent(str, Enum):
    NONE = "NONE"
    AFTER_GRACEFUL_STOP = "AFTER_GRACEFUL_STOP"
    AFTER_EMERGENCY_STOP = "AFTER_EMERGENCY_STOP"


class CloseTransition(str, Enum):
    NONE = "NONE"
    WAITING = "WAITING"
    READY = "READY"
    CANCELLED = "CANCELLED"
    STALE = "STALE"
    FAILED = "FAILED"


@dataclass(frozen=True)
class CloseRequestResult:
    accepted: bool
    reason: str
    intent: CloseIntent
    command_result: Any | None = None


@dataclass(frozen=True)
class CloseObservation:
    transition: CloseTransition
    reason: str


class DesktopCloseCoordinator:
    """Generation-owned deferred-close state with no Tkinter dependency."""

    def __init__(self, view_model: "DesktopViewModel") -> None:
        self._view_model = view_model
        self._intent = CloseIntent.NONE
        self._generation: int | None = None

    @property
    def intent(self) -> CloseIntent:
        return self._intent

    @property
    def generation(self) -> int | None:
        return self._generation

    def request(
        self,
        choice: CloseChoice,
        snapshot: ControlPlaneSnapshot,
    ) -> CloseRequestResult:
        if choice is CloseChoice.CANCEL:
            self._intent = CloseIntent.NONE
            self._generation = None
            return CloseRequestResult(True, "CLOSE_CANCELLED", self._intent)
        if self._intent is not CloseIntent.NONE:
            if not (
                choice is CloseChoice.EMERGENCY
                and self._intent is CloseIntent.AFTER_GRACEFUL_STOP
            ):
                return CloseRequestResult(
                    True,
                    "CLOSE_INTENT_ALREADY_PENDING",
                    self._intent,
                )
        if not snapshot.controller.active:
            return CloseRequestResult(True, "IDLE_CLOSE_READY", CloseIntent.NONE)
        generation = snapshot.controller.generation
        if choice is CloseChoice.GRACEFUL:
            result = self._view_model.request_graceful_stop(generation)
            intent = CloseIntent.AFTER_GRACEFUL_STOP
        else:
            result = self._view_model.emergency_stop(generation)
            intent = CloseIntent.AFTER_EMERGENCY_STOP
        if result.accepted:
            self._intent = intent
            self._generation = generation
        return CloseRequestResult(result.accepted, result.reason, self._intent, result)

    def observe(self, snapshot: ControlPlaneSnapshot) -> CloseObservation:
        if self._intent is CloseIntent.NONE:
            return CloseObservation(CloseTransition.NONE, "NO_CLOSE_INTENT")
        if snapshot.controller.generation != self._generation:
            self._intent = CloseIntent.NONE
            self._generation = None
            return CloseObservation(
                CloseTransition.STALE, "STALE_CLOSE_INTENT_GENERATION"
            )
        if snapshot.controller.active:
            return CloseObservation(CloseTransition.WAITING, self._intent.value)
        if snapshot.controller.state is DesktopControllerState.ERROR:
            self._intent = CloseIntent.NONE
            self._generation = None
            return CloseObservation(
                CloseTransition.FAILED, "CONTROLLER_ERROR_DURING_DEFERRED_CLOSE"
            )
        if self._intent is CloseIntent.AFTER_EMERGENCY_STOP:
            return CloseObservation(CloseTransition.READY, "EMERGENCY_STOPPED")
        if (
            not snapshot.stale
            and snapshot.health == "OK"
            and snapshot.runtime.lifecycle == "BOSS_LOBBY"
        ):
            return CloseObservation(CloseTransition.READY, "GRACEFUL_LOBBY_STOPPED")
        return CloseObservation(
            CloseTransition.WAITING, "WAITING_FOR_CONFIRMED_BOSS_LOBBY"
        )


@dataclass(frozen=True)
class ShutdownResult:
    poller_stopped: bool
    control_plane_closed: bool
    error: str | None = None


class DesktopShutdownWorker:
    """Stop UI-owned resources off the Tk event thread."""

    def __init__(self, view_model: "DesktopViewModel") -> None:
        self._view_model = view_model
        self._thread: threading.Thread | None = None
        self._lock = threading.Lock()
        self._result: ShutdownResult | None = None

    @property
    def result(self) -> ShutdownResult | None:
        with self._lock:
            return self._result

    @property
    def alive(self) -> bool:
        thread = self._thread
        return bool(thread is not None and thread.is_alive())

    def start(self) -> bool:
        with self._lock:
            if self._thread is not None:
                return False
            self._thread = threading.Thread(
                target=self._run,
                name="PokiguardDesktopShutdown",
                daemon=True,
            )
            self._thread.start()
            return True

    def _run(self) -> None:
        try:
            stopped = self._view_model.poller.stop(timeout_seconds=30.0)
            if not stopped:
                result = ShutdownResult(
                    False, False, "POLLING_WORKER_STOP_TIMEOUT"
                )
            else:
                self._view_model.control_plane.close()
                result = ShutdownResult(True, True)
        except Exception as exc:  # noqa: BLE001 - must publish shutdown failure
            result = ShutdownResult(
                False,
                False,
                f"{type(exc).__name__}: {exc}",
            )
        with self._lock:
            self._result = result


class DesktopViewModel:
    """Presentation mapping and short control-plane command submissions."""

    def __init__(
        self,
        control_plane: DesktopControlPlane,
        poller: SnapshotPoller,
        *,
        stale_after_seconds: float,
    ) -> None:
        if stale_after_seconds <= 0:
            raise ValueError("stale_after_seconds must be positive")
        self.control_plane = control_plane
        self.poller = poller
        self.stale_after_seconds = stale_after_seconds

    def apply_draft(self, **fields: str) -> DesktopConfig:
        config = DesktopConfig.from_strings(**fields)
        self.control_plane.update_config(config)
        return config

    def start_farm(self) -> Any:
        return self.control_plane.start_farm()

    def request_graceful_stop(self, generation: int) -> Any:
        return self.control_plane.request_graceful_stop(generation)

    def restore_game_foreground(self, generation: int) -> Any:
        return self.control_plane.restore_game_foreground(generation)

    def emergency_stop(self, generation: int) -> Any:
        return self.control_plane.emergency_stop(generation)

    def resume_from_checkpoint(self) -> Any:
        return self.control_plane.resume_from_checkpoint()

    @staticmethod
    def reason_text(reason: str) -> str:
        code = reason.split(":", 1)[0]
        messages = {
            "PET_SKILL_POLICY_NOT_IMPLEMENTED": "Thẻ skill của pet: chưa có tích hợp gameplay để tự động farm.",
            "PET_SKILL_POLICY_PROFILE_NOT_IMPLEMENTED": "Thẻ skill của pet: cấu hình này chưa có tích hợp gameplay để tự động farm.",
            "PET_SKILL_DESKTOP_INTEGRATION_PENDING": "Thẻ skill của pet: backend đã sẵn sàng, Desktop chưa có tích hợp để tự động farm.",
            "PET_SKILL_AUDITION_V3_NOT_IMPLEMENTED": "Thẻ skill của pet: Audition V3 chưa có tích hợp gameplay an toàn cho bản game hiện tại.",
            "PET_SKILL_SOURCE_SELECTION_UNDEFINED": "Có nhiều nguồn skill pet; quy tắc chọn nguồn chưa được xác định.",
            "SKILL_RUSH_PROFILE_NOT_IMPLEMENTED": "Chịu đấm ăn xôi chỉ hỗ trợ Huyền thoại / Không tiến hóa / Thẻ skill của pet / Cơ bản.",
            "FARM_PROFILE_NOT_IMPLEMENTED": "Cấu hình pet hợp lệ; lối chơi tự động cho cấu hình này chưa được hỗ trợ.",
            "CHECKPOINT_PROFILE_UNKNOWN": "Checkpoint cũ thiếu bằng chứng cấu hình; chưa thể tiếp tục an toàn.",
            "CHECKPOINT_CONFIG_MISMATCH": "Chọn cấu hình và giới hạn giống checkpoint để tiếp tục.",
            "AVAILABLE": "Sẵn sàng.",
            "INITIALIZING": "Đang khởi tạo trạng thái hệ thống.",
            "CONTROL_PLANE_CLOSED": "Bộ điều khiển Desktop đang đóng.",
            "CONTROLLER_UNAVAILABLE": "Bộ điều khiển farm không khả dụng.",
            "CONTROLLER_ALREADY_ACTIVE": "Một lượt farm có giới hạn đang chạy.",
            "STALE_RUNTIME_SNAPSHOT": "Ảnh trạng thái đã cũ; đang chờ dữ liệu mới.",
            "GAME_NOT_DETECTED": "Pokiguard chưa chạy.",
            "GAME_NOT_ATTACHED": "Đang chờ kết nối chỉ đọc với trò chơi.",
            "UNSUPPORTED_ARCHITECTURE": "Kiến trúc của trò chơi không được hỗ trợ.",
            "BACKEND_NOT_HEALTHY": "Hệ thống nền chưa ở trạng thái có thể thao tác.",
            "START_REQUIRES_BOSS_LOBBY": "Đang chờ đúng phòng chờ boss.",
            "CURRENT_BOSS_ROOM_NOT_PROVEN": (
                "Hãy mở đúng phòng boss của pet; bản đồ boss chưa thể thao tác."
            ),
            "CURRENT_ROOM_TARGET_NOT_PROVEN": (
                "Đang chờ xác định chính xác pet của phòng đã chọn."
            ),
            "CURRENT_ROOM_TARGET_AMBIGUOUS": (
                "Dữ liệu mục tiêu của phòng hiện tại chưa rõ; chưa thể bắt đầu."
            ),
            "CURRENT_ROOM_TARGET_INVALID": (
                "Danh tính mục tiêu của phòng hiện tại không hợp lệ; chưa thể bắt đầu."
            ),
            "NO_RESUMABLE_CHECKPOINT": "Không có checkpoint hợp lệ để tiếp tục.",
            "NO_ACTIVE_CONTROLLER": "Không có FarmRunner đang nắm quyền tự động.",
            "GRACEFUL_STOP_PENDING": "Sẽ dừng sau trận hiện tại.",
            "EMERGENCY_STOP_ACKNOWLEDGED": "Lệnh dừng khẩn cấp đã được xác nhận.",
            "EMERGENCY_STOP_ALREADY_ACKNOWLEDGED": "Lệnh dừng khẩn cấp đã được xác nhận.",
            "START_ACCEPTED": "Đã chấp nhận bắt đầu lượt farm.",
            "RESUME_ACCEPTED": "Đã chấp nhận tiếp tục từ checkpoint.",
            "GRACEFUL_STOP_ACCEPTED": "Đã chấp nhận dừng sau trận hiện tại.",
            "EMERGENCY_STOP_ACCEPTED": "Đã chấp nhận dừng khẩn cấp.",
        }
        if code == "INVALID_LAUNCH":
            return "Cấu hình hoặc checkpoint không hợp lệ cho lượt chạy này."
        return messages.get(code, reason)

    def presentation(self, *, now_monotonic: float | None = None) -> DesktopPresentation:
        snapshot = self.control_plane.snapshot()
        runtime = snapshot.runtime
        now = time.monotonic() if now_monotonic is None else now_monotonic
        age = max(0.0, now - snapshot.sampled_monotonic)
        stale = snapshot.stale or age > self.stale_after_seconds

        detected = (
            "ĐÃ PHÁT HIỆN"
            if runtime.game_detected is True
            else "CHƯA PHÁT HIỆN"
            if runtime.game_detected is False
            else "CHƯA XÁC ĐỊNH"
        )
        attachment = "ĐÃ KẾT NỐI (CHỈ ĐỌC)" if runtime.attached else "CHƯA KẾT NỐI"
        process = (
            f"PID {runtime.pid} / {runtime.architecture or 'CHƯA XÁC ĐỊNH'}"
            if runtime.pid is not None
            else "KHÔNG KHẢ DỤNG"
        )
        lifecycle = lifecycle_text(runtime.lifecycle)
        if stale:
            lifecycle = f"{lifecycle} (DỮ LIỆU CŨ / KHÔNG THỂ THAO TÁC)"
        runtime_target = (
            " / ".join(
                value
                for value in (runtime.target_name, runtime.target_id)
                if value
            )
            or "CHƯA XÁC ĐỊNH"
        )
        if runtime.lobby_branch:
            branch = LOBBY_BRANCH_LABELS.get(runtime.lobby_branch, runtime.lobby_branch)
            runtime_target = f"{runtime_target} [{branch}]"
        checkpoint = snapshot.checkpoint
        if checkpoint.available:
            final_status = (
                FINAL_STATUS_LABELS.get(
                    checkpoint.finalized_status,
                    checkpoint.finalized_status,
                )
                if checkpoint.finalized_status
                else "CHƯA HOÀN TẤT"
            )
            checkpoint_text = (
                f"{final_status} — "
                f"{checkpoint.completed_matches}/{checkpoint.target_completed_matches} "
                f"(Thắng/Thua/Chưa rõ {checkpoint.wins}/{checkpoint.losses}/"
                f"{checkpoint.unknown_results}) — {checkpoint.farm_run_id}"
            )
            if checkpoint.gameplay_config is not None:
                saved = checkpoint.gameplay_config
                checkpoint_text += (
                    f"\n{MAIN_PET_LABELS[saved.main_pet]} / {EVOLUTION_LABELS[saved.evolution]}"
                    f" / {DAMAGE_LABELS[saved.damage_card]}"
                )
            else:
                checkpoint_text += "\nCấu hình lịch sử: CHƯA XÁC ĐỊNH"
        elif checkpoint.error:
            checkpoint_text = f"KHÔNG KHẢ DỤNG — {checkpoint.error}"
        else:
            checkpoint_text = "KHÔNG CÓ"
        health = (
            "DỮ LIỆU CŨ"
            if stale and snapshot.health == "OK"
            else "TỐT"
            if snapshot.health == "OK"
            else snapshot.health
        )
        controller = snapshot.controller
        controller_text = (
            f"{controller_state_text(controller.state.value)} — Hoàn thành "
            f"{controller.completed_matches}/{controller.target_completed_matches} — "
            f"Lần thử {controller.match_attempts}\n"
            f"Thắng/Thua/Chưa rõ {controller.wins}/{controller.losses}/{controller.unknown_results} — "
            f"Lượt chạy {controller.farm_run_id or 'ĐANG CHỜ'}\n"
            f"{match_energy_text(controller)}"
        )
        controls = snapshot.controls
        if controller.active:
            if controller.state is DesktopControllerState.EMERGENCY_STOPPING:
                operator_status = "ĐANG DỪNG KHẨN CẤP"
                operator_guidance = "Quyền tự động đã bị thu hồi; đang chờ bộ điều khiển dừng hẳn."
            elif controller.graceful_stop_requested:
                operator_status = "CHỜ DỪNG SAU TRẬN"
                operator_guidance = "Trận hiện tại sẽ hoàn tất; không bắt đầu trận kế tiếp."
            else:
                operator_status = "ĐANG CHẠY"
                operator_guidance = "FarmRunner có giới hạn đang hoạt động. Cấu hình đã được khóa."
        elif controller.state is DesktopControllerState.ERROR:
            operator_status = "LỖI BỘ ĐIỀU KHIỂN"
            operator_guidance = controller.last_error or (
                "FarmRunner đã dừng do lỗi; hãy xem Chẩn đoán / Nhật ký."
            )
        elif stale:
            operator_status = "DỮ LIỆU TRẠNG THÁI ĐÃ CŨ"
            operator_guidance = "Dữ liệu trạng thái đã cũ; mọi thao tác khởi chạy đều bị khóa."
        elif controls.start.actionable:
            operator_status = "SẴN SÀNG"
            operator_guidance = (
                "Đúng phòng pet hiện tại và cấu hình có giới hạn đã sẵn sàng; "
                "Bắt đầu sẽ ghim mục tiêu của phòng này."
            )
        else:
            operator_status = "CHƯA SẴN SÀNG"
            operator_guidance = self.reason_text(controls.start.reason)
        return DesktopPresentation(
            connection=detected,
            attachment=attachment,
            process=process,
            lifecycle=lifecycle,
            match_id=runtime.match_id or "CHƯA XÁC ĐỊNH",
            session=runtime.session_key or "KHÔNG KHẢ DỤNG",
            runtime_target=runtime_target,
            checkpoint=checkpoint_text,
            health=health,
            error=controller.last_error or snapshot.last_error or "KHÔNG CÓ",
            refreshed=f"{snapshot.timestamp} (cách đây {age:.1f} giây, phiên bản {snapshot.version})",
            read_only_notice=(
                "CHỈ ĐỌC bộ nhớ trò chơi; mọi thao tác dùng FarmRunner có giới hạn "
                "đã được chấp nhận và input cửa sổ nền trước thông thường"
            ),
            controller=controller_text,
            operator_status=operator_status,
            operator_guidance=operator_guidance,
            snapshot_actionable=not stale,
        )


class DesktopApplication:
    """Minimal ttk window whose event thread only renders cached snapshots."""

    def __init__(
        self,
        root: Any,
        view_model: DesktopViewModel,
        *,
        event_log: DesktopEventLog,
        preference_store: DesktopPreferenceStore | None = None,
        preference_warnings: tuple[PreferenceWarning, ...] = (),
        game_location: str = "",
        game_executable: str = "",
        game_location_changed: Callable[[str], Any] | None = None,
        auto_close_seconds: float = 0.0,
    ) -> None:
        import tkinter as tk
        from tkinter import ttk

        self.root = root
        self.view_model = view_model
        self.event_log = event_log
        self.preference_store = preference_store
        self.preference_warnings = preference_warnings
        self.game_location_changed = game_location_changed
        self.auto_close_seconds = max(0.0, float(auto_close_seconds))
        self.render_ticks = 0
        self.handled_ui_errors = 0
        self.poller_alive_after_close = False
        self._closed = False
        self._shutdown_started = False
        self._render_after: str | None = None
        self._auto_close_after: str | None = None
        self._shutdown_after: str | None = None
        self._close_dialog: Any | None = None
        self._last_operator_log_sequence = 0
        self._config_editable: bool | None = None
        self._locked_run_limits: tuple[str, str] | None = None
        self._close_coordinator = DesktopCloseCoordinator(view_model)
        self._shutdown_worker = DesktopShutdownWorker(view_model)
        self.start_commands_submitted = 0
        self.resume_commands_submitted = 0
        self.graceful_commands_submitted = 0
        self.emergency_commands_submitted = 0

        root.title(APP_TITLE)
        root.geometry("520x780")
        root.minsize(460, 680)
        root.protocol("WM_DELETE_WINDOW", self.close)

        notebook = ttk.Notebook(root)
        notebook.pack(fill=tk.BOTH, expand=True)
        outer = ttk.Frame(notebook, padding=14)
        preferences_outer = ttk.Frame(notebook, padding=14)
        settings_outer = ttk.Frame(notebook, padding=14)
        diagnostics_outer = ttk.Frame(notebook, padding=14)
        for page, tab_title in zip(
            (outer, preferences_outer, settings_outer, diagnostics_outer),
            DESKTOP_TAB_TITLES,
        ):
            notebook.add(page, text=tab_title)
        self.notebook = notebook
        root.bind("<Button-1>", self._handle_background_click, add="+")

        title = ttk.Label(
            outer,
            text=APP_TITLE,
            font=("Segoe UI", 18, "bold"),
        )
        title.pack(anchor=tk.W)
        self.notice_var = tk.StringVar()
        ttk.Label(
            outer,
            textvariable=self.notice_var,
            foreground="#8a4b08",
            wraplength=470,
        ).pack(anchor=tk.W, pady=(0, 10))

        self.operator_status_var = tk.StringVar(value="ĐANG KHỞI TẠO")
        self.operator_guidance_var = tk.StringVar(
            value="Đang chờ dữ liệu trạng thái từ hệ thống nền."
        )
        operator_frame = ttk.LabelFrame(outer, text="Trạng thái vận hành", padding=10)
        operator_frame.pack(fill=tk.X, pady=(0, 10))
        ttk.Label(
            operator_frame,
            textvariable=self.operator_status_var,
            font=("Segoe UI", 10, "bold"),
        ).pack(anchor=tk.W)
        ttk.Label(
            operator_frame,
            textvariable=self.operator_guidance_var,
            wraplength=410,
        ).pack(anchor=tk.W)

        runtime_frame = ttk.LabelFrame(outer, text="Kết nối / Trạng thái hiện tại", padding=10)
        runtime_frame.pack(fill=tk.X, pady=(0, 10))
        self.status_vars: dict[str, Any] = {}
        for row, (label, key) in enumerate(VISIBLE_RUNTIME_ROWS):
            ttk.Label(runtime_frame, text=f"{label}:").grid(
                row=row, column=0, sticky=tk.NW, padx=(0, 8), pady=2
            )
            variable = tk.StringVar(value="CHƯA XÁC ĐỊNH")
            self.status_vars[key] = variable
            ttk.Label(runtime_frame, textvariable=variable, wraplength=350).grid(
                row=row, column=1, sticky=tk.NW, pady=2
            )
        runtime_frame.columnconfigure(1, weight=1)

        config = view_model.control_plane.snapshot().config
        self.play_style = tk.StringVar(value=PLAY_STYLE_LABELS[config.play_style])
        self.main_pet = tk.StringVar(value=config.main_pet.value)
        self.evolution = tk.StringVar(value=config.evolution.value)
        self.damage_card = tk.StringVar(value=config.damage_card.value)
        self.audition_mode = tk.StringVar(value=AUDITION_LABELS[config.audition_mode])
        self.pet_skill_fire_condition = tk.StringVar(
            value=PET_SKILL_FIRE_CONDITION_LABELS[
                config.pet_skill_fire_condition
            ]
        )
        self.pet_skill_fire_value = tk.StringVar(
            value=(
                ""
                if config.pet_skill_fire_value is None
                else str(config.pet_skill_fire_value)
            )
        )
        self._last_valid_pet_skill_fire_value = (
            config.pet_skill_fire_value
            if config.pet_skill_fire_value is not None
            else PET_SKILL_FIRE_VALUE_DEFAULT
        )
        self._updating_pet_fields = False
        self._updating_fire_fields = False
        self._updating_play_style = False
        self._pet_option_widgets: dict[tuple[str, str], Any] = {}
        self.profile_notice_var = tk.StringVar()
        self.intelligence = tk.StringVar(value=INTELLIGENCE_LABELS[Intelligence.BASIC])
        self.board_input_mode = tk.StringVar(value=BOARD_INPUT_LABELS[config.board_input_mode])
        self.boss_id = tk.StringVar(value=config.normalized_boss_id or "")
        self.boss_name = tk.StringVar(value=config.normalized_boss_name or "")
        self.target_matches = tk.StringVar(value=str(config.target_completed_matches))
        self.max_attempts = tk.StringVar(value=str(config.max_match_attempts))
        self.game_location = tk.StringVar(value=game_location)
        self.game_executable_var = tk.StringVar(
            value=game_executable or "CHƯA XÁC ĐỊNH"
        )
        self._config_widgets: list[tuple[Any, str]] = []

        preferences_frame = ttk.LabelFrame(
            preferences_outer, text="Tùy chọn cách chơi", padding=12
        )
        preferences_frame.pack(fill=tk.X)
        preferences_frame.columnconfigure(0, weight=3)
        preferences_frame.columnconfigure(1, weight=7)

        def preference_field(
            *,
            row: int,
            label: str,
            widget: Any,
            editable_state: str,
        ) -> tuple[Any, Any]:
            label_widget = ttk.Label(preferences_frame, text=f"{label}:")
            label_widget.grid(
                row=row,
                column=0,
                sticky=tk.W,
                padx=(0, 12),
                pady=5,
            )
            widget.grid(row=row, column=1, sticky=tk.EW, pady=5)
            self._config_widgets.append((widget, editable_state))
            return label_widget, widget

        preference_field(
            row=0,
            label="Lối chơi",
            widget=ttk.Combobox(
                preferences_frame,
                textvariable=self.play_style,
                values=tuple(PLAY_STYLE_LABELS[value] for value in PlayStyle),
                state="readonly",
            ),
            editable_state="readonly",
        )
        preference_field(
            row=1,
            label="Độ thông minh",
            widget=ttk.Combobox(
                preferences_frame,
                textvariable=self.intelligence,
                values=(INTELLIGENCE_LABELS[Intelligence.BASIC],),
                state="disabled",
            ),
            editable_state="disabled",
        )
        for row, label, name, variable, labels, supported in (
            (2, "Pet của tôi", "main_pet", self.main_pet, MAIN_PET_LABELS, SUPPORTED_MAIN_PETS),
            (3, "Tiến hóa", "evolution", self.evolution, EVOLUTION_LABELS, SUPPORTED_EVOLUTIONS),
            (4, "Thẻ sát thương", "damage_card", self.damage_card, DAMAGE_LABELS, frozenset(DamageCardMode)),
        ):
            ttk.Label(preferences_frame, text=f"{label}:").grid(
                row=row, column=0, sticky=tk.NW, padx=(0, 12), pady=5)
            options = ttk.Frame(preferences_frame)
            options.grid(row=row, column=1, sticky=tk.EW, pady=5)
            for value, caption in labels.items():
                state = "normal" if value in supported else "disabled"
                button = ttk.Radiobutton(options, text=caption, variable=variable,
                                         value=value.value, state=state)
                button.pack(anchor=tk.W)
                self._pet_option_widgets[name, value.value] = button
                self._config_widgets.append((button, state))
        self.pet_skill_fire_label = ttk.Label(
            preferences_frame, text="Điều kiện ra skill:"
        )
        self.pet_skill_fire_label.grid(
            row=5, column=0, sticky=tk.W, padx=(0, 12), pady=5
        )
        self.pet_skill_fire_cell = ttk.Frame(preferences_frame)
        self.pet_skill_fire_cell.grid(row=5, column=1, sticky=tk.EW, pady=5)
        self.pet_skill_fire_cell.columnconfigure(0, weight=3)
        self.pet_skill_fire_cell.columnconfigure(1, weight=1)
        self.pet_skill_fire_condition_widget = ttk.Combobox(
            self.pet_skill_fire_cell,
            textvariable=self.pet_skill_fire_condition,
            values=tuple(PET_SKILL_FIRE_CONDITION_LABELS.values()),
            state="readonly",
        )
        self.pet_skill_fire_condition_widget.grid(
            row=0, column=0, sticky=tk.EW, padx=(0, 6)
        )
        self.pet_skill_fire_value_widget = ttk.Entry(
            self.pet_skill_fire_cell,
            textvariable=self.pet_skill_fire_value,
            validate="key",
            validatecommand=(root.register(decimal_digits_or_empty), "%P"),
        )
        self.pet_skill_fire_value_widget.grid(
            row=0, column=1, sticky=tk.EW, padx=(6, 0)
        )
        self._config_widgets.extend(
            (
                (self.pet_skill_fire_condition_widget, "readonly"),
                (self.pet_skill_fire_value_widget, "normal"),
            )
        )
        self.audition_label, self.audition_widget = preference_field(
            row=6,
            label="Kiểu thử thách",
            widget=ttk.Combobox(
                preferences_frame,
                textvariable=self.audition_mode,
                values=tuple(AUDITION_LABELS[value] for value in AuditionMode),
                state="readonly",
            ),
            editable_state="readonly",
        )
        self.audition_help = ttk.Label(
            preferences_frame,
            text=(
                f"{AUDITION_LABELS[AuditionMode.V3_TWO_DIRECTION]}; "
                f"{AUDITION_LABELS[AuditionMode.V2_FOUR_DIRECTION]}."
            ),
            wraplength=390,
        )
        self.audition_help.grid(
            row=7, column=0, columnspan=2, sticky=tk.W, pady=(0, 5)
        )
        preference_field(
            row=8,
            label="Cách đi bàn cờ",
            widget=ttk.Combobox(
                preferences_frame,
                textvariable=self.board_input_mode,
                values=tuple(BOARD_INPUT_LABELS[value] for value in BoardInputMode),
                state="readonly",
            ),
            editable_state="readonly",
        )

        def horizontal_field(
            parent: Any,
            *,
            row: int,
            column: int,
            label: str,
            widget_factory: Any,
            editable_state: str,
            padx: tuple[int, int] = (0, 0),
        ) -> Any:
            cell = ttk.Frame(parent)
            cell.grid(
                row=row,
                column=column,
                sticky=tk.EW,
                padx=padx,
                pady=2,
            )
            # A field is one compact cluster: the label keeps its natural
            # width and the control consumes the remaining cluster width.
            # Only sibling clusters in the outer row are split 50/50.
            cell.columnconfigure(1, weight=1)
            ttk.Label(cell, text=f"{label}:").grid(
                row=0, column=0, sticky=tk.W, padx=(0, 5)
            )
            widget = widget_factory(cell)
            widget.grid(row=0, column=1, sticky=tk.EW, padx=(5, 0))
            self._config_widgets.append((widget, editable_state))
            return widget

        self.validate_button = ttk.Button(
            preferences_frame,
            text="Kiểm tra và lưu tùy chọn",
            command=self._validate_draft,
        )
        self.validate_button.grid(
            row=9, column=0, columnspan=2, sticky=tk.W, pady=(10, 2)
        )
        ttk.Label(preferences_frame, textvariable=self.profile_notice_var,
                  wraplength=390).grid(row=10, column=0, columnspan=2, sticky=tk.W, pady=5)
        self.load_checkpoint_preferences_button = ttk.Button(
            preferences_frame, text="Nạp tùy chọn từ checkpoint", command=self._load_checkpoint_preferences)
        self.load_checkpoint_preferences_button.grid(row=11, column=0, columnspan=2, sticky=tk.W, pady=5)
        self._config_widgets.append((self.load_checkpoint_preferences_button, "normal"))
        for variable in (self.main_pet, self.evolution, self.damage_card):
            variable.trace_add("write", self._pet_selection_changed)
        self.pet_skill_fire_condition.trace_add(
            "write", self._pet_skill_fire_condition_changed
        )
        self.pet_skill_fire_value.trace_add(
            "write", self._pet_skill_fire_value_changed
        )
        self.play_style.trace_add("write", self._play_style_changed)
        self._sync_pet_options()

        settings_frame = ttk.LabelFrame(
            settings_outer, text="Cài đặt trò chơi", padding=12
        )
        settings_frame.pack(fill=tk.X)
        settings_frame.columnconfigure(1, weight=1)
        ttk.Label(settings_frame, text="Tệp chạy trò chơi:").grid(
            row=0, column=0, sticky=tk.W, padx=(0, 12), pady=5
        )
        self.game_location_entry = ttk.Entry(
            settings_frame, textvariable=self.game_location
        )
        self.game_location_entry.grid(row=0, column=1, sticky=tk.EW, pady=5)
        self.game_location_folder_button = ttk.Button(
            settings_frame,
            text="Chọn tệp...",
            command=self._choose_game_executable,
        )
        self.game_location_folder_button.grid(
            row=0, column=2, sticky=tk.E, padx=(8, 0), pady=5
        )
        self.game_location_apply_button = ttk.Button(
            settings_frame,
            text="Áp dụng và lưu",
            command=self._save_game_location,
        )
        self.game_location_apply_button.grid(
            row=1, column=1, sticky=tk.W, pady=(8, 4)
        )
        ttk.Label(settings_frame, text="Đã chọn:").grid(
            row=2, column=0, sticky=tk.NW, padx=(0, 12), pady=5
        )
        ttk.Label(
            settings_frame,
            textvariable=self.game_executable_var,
            wraplength=330,
        ).grid(row=2, column=1, columnspan=2, sticky=tk.W, pady=5)
        self._config_widgets.extend(
            (
                (self.game_location_entry, "normal"),
                (self.game_location_folder_button, "normal"),
                (self.game_location_apply_button, "normal"),
            )
        )

        control_frame = ttk.LabelFrame(
            outer, text="Điều khiển FarmRunner có giới hạn", padding=10
        )
        control_frame.pack(fill=tk.X, pady=(0, 10))
        control_frame.columnconfigure(0, weight=1, uniform="control")
        control_frame.columnconfigure(1, weight=1, uniform="control")

        limits_row = ttk.Frame(control_frame)
        limits_row.grid(row=0, column=0, columnspan=2, sticky=tk.EW, pady=(0, 8))
        limits_row.columnconfigure(0, weight=1, uniform="limits")
        limits_row.columnconfigure(1, weight=1, uniform="limits")
        horizontal_field(
            limits_row,
            row=0,
            column=0,
            label="Số trận mục tiêu",
            widget_factory=lambda cell: ttk.Entry(
                cell, textvariable=self.target_matches
            ),
            editable_state="normal",
            padx=(0, 5),
        )
        horizontal_field(
            limits_row,
            row=0,
            column=1,
            label="Số lần thử tối đa",
            widget_factory=lambda cell: ttk.Entry(
                cell, textvariable=self.max_attempts
            ),
            editable_state="normal",
            padx=(5, 0),
        )

        self.controller_var = tk.StringVar(value="ĐANG RẢNH")
        self.command_feedback = tk.StringVar(value="Chưa gửi lệnh nào.")
        self.control_reason_var = tk.StringVar(value="Đang chờ trạng thái hệ thống nền.")
        self.start_button = ttk.Button(
            control_frame, text="Bắt đầu", command=self._start_farm
        )
        self.graceful_button = ttk.Button(
            control_frame,
            text="Dừng sau trận hiện tại",
            command=self._graceful_stop,
        )
        self.emergency_button = ttk.Button(
            control_frame,
            text="Dừng khẩn cấp — Ngay lập tức",
            command=self._emergency_stop,
        )
        self.resume_button = ttk.Button(
            control_frame,
            text="Tiếp tục từ checkpoint",
            command=self._resume_checkpoint,
        )
        for row, column, button in (
            (1, 0, self.start_button),
            (1, 1, self.graceful_button),
            (2, 0, self.emergency_button),
            (2, 1, self.resume_button),
        ):
            button.grid(row=row, column=column, padx=(0, 6), pady=2, sticky=tk.W)

        run_status_frame = ttk.LabelFrame(control_frame, text="Trạng thái lượt chạy", padding=8)
        run_status_frame.grid(
            row=3, column=0, columnspan=2, sticky=tk.EW, pady=(8, 0)
        )
        ttk.Label(
            run_status_frame,
            textvariable=self.controller_var,
            wraplength=410,
            justify=tk.LEFT,
        ).pack(anchor=tk.W)
        ttk.Label(
            control_frame,
            textvariable=self.command_feedback,
            wraplength=410,
        ).grid(row=4, column=0, columnspan=2, sticky=tk.W, pady=(6, 0))
        ttk.Label(
            control_frame,
            textvariable=self.control_reason_var,
            foreground="#8a4b08",
            wraplength=410,
        ).grid(row=5, column=0, columnspan=2, sticky=tk.W, pady=(4, 0))

        checkpoint_frame = ttk.LabelFrame(
            outer, text="Lượt chạy / Checkpoint", padding=10
        )
        checkpoint_frame.pack(fill=tk.X, pady=(0, 10))
        self.checkpoint_var = tk.StringVar(value="KHÔNG CÓ")
        ttk.Label(
            checkpoint_frame,
            textvariable=self.checkpoint_var,
            wraplength=410,
        ).pack(anchor=tk.W)

        health_frame = ttk.LabelFrame(
            diagnostics_outer, text="Tình trạng hệ thống nền", padding=10
        )
        health_frame.pack(fill=tk.X, pady=(0, 10))
        self.health_var = tk.StringVar(value="ĐANG KHỞI TẠO")
        self.error_var = tk.StringVar(value="KHÔNG CÓ")
        self.refreshed_var = tk.StringVar(value="CHƯA ĐỌC")
        for label, variable in (
            ("Tình trạng", self.health_var),
            ("Lỗi gần nhất", self.error_var),
            ("Ảnh trạng thái", self.refreshed_var),
        ):
            ttk.Label(health_frame, text=f"{label}:").pack(anchor=tk.W)
            ttk.Label(health_frame, textvariable=variable, wraplength=410).pack(
                anchor=tk.W, pady=(0, 5)
            )

        log_frame = ttk.LabelFrame(
            diagnostics_outer,
            text=(
                "Nhật ký vận hành "
                f"({event_log.max_display_entries} mục mới nhất, chỉ dùng chẩn đoán)"
            ),
            padding=8,
        )
        log_frame.pack(fill=tk.BOTH, expand=True)
        self.operator_log_text = tk.Text(
            log_frame,
            height=7,
            wrap=tk.WORD,
            state=tk.DISABLED,
            font=("Consolas", 8),
        )
        scrollbar = ttk.Scrollbar(
            log_frame,
            orient=tk.VERTICAL,
            command=self.operator_log_text.yview,
        )
        self.operator_log_text.configure(yscrollcommand=scrollbar.set)
        self.operator_log_text.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        scrollbar.pack(side=tk.RIGHT, fill=tk.Y)

        for warning in preference_warnings:
            self.event_log.write(
                "preference_load_warning",
                reason=warning.reason,
                error=warning.message,
                operatorMessage=f"Đã dùng tùy chọn dự phòng: {warning.reason}",
            )

        # Keep initial activation neutral. Entry widgets remain mouse-editable,
        # but Target matches must not receive an unsolicited caret/selection.
        root.after_idle(notebook.focus_set)

    def _handle_background_click(self, event: Any) -> None:
        """Move focus off Entry/Combobox only when true background is clicked."""

        try:
            widget_class = str(event.widget.winfo_class())
        except Exception:
            return
        if background_click_clears_entry_focus(widget_class):
            self.notebook.focus_set()

    def _lock_accepted_run_config(self, config: DesktopConfig) -> None:
        """Freeze the exact launch limits immediately after Start/Resume accepts."""

        self._locked_run_limits = run_limit_text(config)
        self.target_matches.set(self._locked_run_limits[0])
        self.max_attempts.set(self._locked_run_limits[1])
        # The production application owns all three variables.  The compact
        # presentation-contract fixture intentionally supplies only the run
        # limit and pet fields that it asserts.
        if hasattr(self, "play_style"):
            self.play_style.set(PLAY_STYLE_LABELS[config.play_style])
        if hasattr(self, "intelligence"):
            self.intelligence.set(INTELLIGENCE_LABELS[config.intelligence])
        if hasattr(self, "board_input_mode"):
            self.board_input_mode.set(BOARD_INPUT_LABELS[config.board_input_mode])
        self._display_pet_config(config)
        self._set_config_editable(False)
        self.start_button.configure(state="disabled")
        self.resume_button.configure(state="disabled")
        self.notebook.focus_set()
        self.event_log.write(
            "accepted_run_limits_locked",
            targetCompletedMatches=config.target_completed_matches,
            maxMatchAttempts=config.max_match_attempts,
            operatorMessage=(
                "Giới hạn lượt chạy đã được khóa cho tới khi bộ điều khiển dừng."
            ),
        )

    def _persist_preferences(self, config: DesktopConfig) -> str | None:
        if self.preference_store is None:
            return None
        try:
            self.preference_store.save(
                config,
                game_location=self.game_location.get(),
            )
            self.event_log.write(
                "preferences_saved",
                path=str(self.preference_store.path),
                operatorMessage="Đã lưu các tùy chọn vận hành được hỗ trợ.",
            )
            return None
        except (PreferenceError, OSError, TypeError, ValueError) as exc:
            reason = getattr(exc, "reason", "PREFERENCE_SAVE_FAILED")
            self.event_log.write(
                "preference_save_warning",
                reason=reason,
                error=f"{type(exc).__name__}: {exc}",
                operatorMessage=f"Không lưu được tùy chọn: {reason}",
            )
            return str(reason)

    def _apply_game_location(self, *, persist: bool) -> Any:
        raw = self.game_location.get().strip()
        if self.game_location_changed is None:
            if not raw:
                raise ValueError("cần chọn vị trí trò chơi")
            resolved: Any = raw
        else:
            resolved = self.game_location_changed(raw)
        executable = getattr(resolved, "executable", resolved)
        location = getattr(resolved, "location", raw)
        self.game_location.set(str(executable))
        self.game_executable_var.set(str(executable))
        warning = None
        if persist:
            warning = self._persist_preferences(
                self.view_model.control_plane.snapshot().config
            )
        self.event_log.write(
            "game_location_applied",
            location=str(location),
            executable=str(executable),
            operatorMessage=f"Đã chọn tệp chạy trò chơi: {executable}",
        )
        if warning:
            raise PreferenceError(warning, "không lưu được vị trí trò chơi")
        return resolved

    def _save_game_location(self) -> None:
        try:
            resolved = self._apply_game_location(persist=True)
            self.command_feedback.set(
                f"Đã lưu vị trí trò chơi — {getattr(resolved, 'executable', resolved)}"
            )
        except Exception as exc:
            reason = getattr(exc, "reason", "GAME_LOCATION_INVALID")
            self.command_feedback.set(f"Vị trí trò chơi không hợp lệ — {exc}")
            self.event_log.write(
                "game_location_rejected",
                reason=reason,
                error=f"{type(exc).__name__}: {exc}",
            )

    def _choose_game_executable(self) -> None:
        from tkinter import filedialog

        current = self.game_location.get().strip()
        current_path = Path(current) if current else None
        initial_directory = None
        initial_file = None
        if current_path is not None:
            if current_path.is_file():
                initial_directory = str(current_path.parent)
                initial_file = current_path.name
            elif current_path.is_dir():
                initial_directory = str(current_path)
        selected = filedialog.askopenfilename(
            parent=self.root,
            title="Chọn tệp chạy trò chơi Pokiguard",
            initialdir=initial_directory,
            initialfile=initial_file,
            filetypes=(
                ("Tệp chạy Pokiguard", "Pokiguard-*.exe"),
                ("Tệp thực thi", "*.exe"),
            ),
        )
        if not selected:
            return
        self.game_location.set(selected)
        self._save_game_location()

    def _validate_draft(self) -> None:
        try:
            config = self.view_model.apply_draft(**self._draft_fields())
            warning = self._persist_preferences(config)
            self.command_feedback.set(
                f"Đã lưu tùy chọn — số trận={config.target_completed_matches}."
                + (f" Cảnh báo: {warning}." if warning else "")
            )
            self.event_log.write(
                "draft_config_validated",
                config=asdict(config),
                operatorMessage="Cấu hình đã được kiểm tra bằng mô hình chuẩn.",
            )
        except Exception as exc:  # expected validation feedback, not UI failure
            self.command_feedback.set(f"Tùy chọn không hợp lệ — {exc}")
            self.event_log.write(
                "draft_config_rejected", error=f"{type(exc).__name__}: {exc}"
            )

    def _draft_fields(self) -> dict[str, str]:
        return {
            "play_style": play_style_from_display(self.play_style.get()).value,
            "main_pet": self.main_pet.get(),
            "evolution": self.evolution.get(),
            "damage_card": self.damage_card.get(),
            "audition_mode": audition_mode_from_display(
                self.audition_mode.get()
            ).value,
            "pet_skill_fire_condition": (
                pet_skill_fire_condition_from_display(
                    self.pet_skill_fire_condition.get()
                ).value
            ),
            "pet_skill_fire_value": self.pet_skill_fire_value.get(),
            "intelligence": intelligence_from_display(
                self.intelligence.get()
            ).value,
            "board_input_mode": board_input_mode_from_display(
                self.board_input_mode.get()
            ).value,
            "boss_id": self.boss_id.get(),
            "boss_name": self.boss_name.get(),
            "target_completed_matches": self.target_matches.get(),
            # Kept only for backward-compatible DesktopConfig parsing. It is
            # not an operator setting and no longer limits recovery.
            "max_technical_recoveries": str(
                self.view_model.control_plane.snapshot().config.max_technical_recoveries
            ),
            "max_match_attempts": self.max_attempts.get(),
            **{name: str(getattr(self.view_model.control_plane.snapshot().config, name))
               for name in ("cast_when_boss_hp_below", "cast_mana_stockpile", "rage_target")},
        }

    def _display_pet_config(self, config: DesktopConfig) -> None:
        self._updating_pet_fields = True
        self._updating_fire_fields = True
        try:
            for name in ("main_pet", "evolution", "damage_card"):
                getattr(self, name).set(getattr(config, name).value)
            self.audition_mode.set(AUDITION_LABELS[config.audition_mode])
            self.pet_skill_fire_condition.set(
                PET_SKILL_FIRE_CONDITION_LABELS[
                    config.pet_skill_fire_condition
                ]
            )
            if config.pet_skill_fire_value is not None:
                self._last_valid_pet_skill_fire_value = config.pet_skill_fire_value
                self.pet_skill_fire_value.set(str(config.pet_skill_fire_value))
            else:
                self.pet_skill_fire_value.set("")
        finally:
            self._updating_pet_fields = False
            self._updating_fire_fields = False
        self._sync_pet_skill_fields()

    def _load_checkpoint_preferences(self) -> None:
        try:
            config = self.view_model.control_plane.load_checkpoint_preferences()
            self._display_pet_config(config)
            self.play_style.set(PLAY_STYLE_LABELS[config.play_style])
            self.intelligence.set(INTELLIGENCE_LABELS[config.intelligence])
            self.board_input_mode.set(BOARD_INPUT_LABELS[config.board_input_mode])
            self.target_matches.set(str(config.target_completed_matches))
            self.max_attempts.set(str(config.max_match_attempts))
            self._sync_pet_options()
            self.command_feedback.set("Đã nạp tùy chọn từ checkpoint; cần bấm Tiếp tục bằng một lệnh riêng.")
            self.event_log.write("checkpoint_preferences_loaded", config=asdict(config))
        except Exception as exc:
            self.command_feedback.set(f"Không thể nạp tùy chọn từ checkpoint — {exc}")
            self.event_log.write("checkpoint_preferences_rejected", error=str(exc))

    def _sync_pet_options(self) -> None:
        # Restore/disable the condition value and publish row visibility before
        # parsing the full draft.  A count condition may have an empty Entry
        # while the Pet Skill row is hidden; selecting Pet Skill must restore
        # its last valid value before canonical validation runs.
        self._sync_pet_skill_fields()
        capability = loadout_capability(MainPetType(self.main_pet.get()),
                                       EvolutionTarget(self.evolution.get()),
                                       DamageCardMode(self.damage_card.get()))
        profile = DesktopConfig.from_strings(**self._draft_fields())
        blocker = profile.farm_policy_blocker_reason
        editable = self._config_editable is not False
        self._pet_option_widgets["damage_card", "pet_skill"].configure(
            state="normal" if editable and capability.pet_skill_selectable else "disabled")
        self.profile_notice_var.set(
            self.view_model.reason_text(blocker)
            if blocker else "Cấu hình tương thích với lối chơi Cơ bản hiện tại.")
        self._sync_pet_skill_fields()

    def _sync_pet_skill_fields(self) -> None:
        """Apply Pet-Skill-only visibility and condition-dependent value state."""

        if not hasattr(self, "pet_skill_fire_cell"):
            return
        visible = self.damage_card.get() == DamageCardMode.PET_SKILL.value
        for widget in (
            self.pet_skill_fire_label,
            self.pet_skill_fire_cell,
            self.audition_label,
            self.audition_widget,
            self.audition_help,
        ):
            if visible:
                widget.grid()
            else:
                widget.grid_remove()

        try:
            condition = pet_skill_fire_condition_from_display(
                self.pet_skill_fire_condition.get()
            )
        except ValueError:
            condition = PetSkillFireCondition.SWORD_COUNT
        if condition is PetSkillFireCondition.SKILL_COST_READY:
            raw = self.pet_skill_fire_value.get()
            if raw.isascii() and raw.isdigit():
                numeric = int(raw)
                if (
                    PET_SKILL_FIRE_VALUE_MINIMUM
                    <= numeric
                    <= PET_SKILL_FIRE_VALUE_MAXIMUM
                ):
                    self._last_valid_pet_skill_fire_value = numeric
            if raw:
                self.pet_skill_fire_value.set("")
            self.pet_skill_fire_value_widget.configure(state="disabled")
        else:
            if not self.pet_skill_fire_value.get():
                self.pet_skill_fire_value.set(
                    str(self._last_valid_pet_skill_fire_value)
                )
            self.pet_skill_fire_value_widget.configure(
                state=(
                    "normal"
                    if self._config_editable is not False
                    else "disabled"
                )
            )

    def _pet_skill_fire_condition_changed(self, *_args: Any) -> None:
        if self._updating_fire_fields:
            return
        snapshot = self.view_model.control_plane.snapshot()
        if snapshot.controller.active:
            self._display_pet_config(snapshot.config)
            return
        self._sync_pet_skill_fields()
        try:
            self.view_model.apply_draft(**self._draft_fields())
        except (TypeError, ValueError):
            return

    def _pet_skill_fire_value_changed(self, *_args: Any) -> None:
        if self._updating_fire_fields:
            return
        raw = self.pet_skill_fire_value.get()
        if raw.isascii() and raw.isdigit():
            numeric = int(raw)
            if (
                PET_SKILL_FIRE_VALUE_MINIMUM
                <= numeric
                <= PET_SKILL_FIRE_VALUE_MAXIMUM
            ):
                self._last_valid_pet_skill_fire_value = numeric

    def _pet_selection_changed(self, *_args: Any) -> None:
        if self._updating_pet_fields:
            return
        snapshot = self.view_model.control_plane.snapshot()
        if snapshot.controller.active:
            self._display_pet_config(snapshot.config)
            return
        try:
            normalized = normalize_damage(MainPetType(self.main_pet.get()),
                                          EvolutionTarget(self.evolution.get()),
                                          DamageCardMode(self.damage_card.get()))
            if self.damage_card.get() != normalized.value:
                self._updating_pet_fields = True
                self.damage_card.set(normalized.value)
                self._updating_pet_fields = False
            self._sync_pet_options()
            self.view_model.apply_draft(**self._draft_fields())
        except (TypeError, ValueError):
            # Other draft fields may be mid-edit. Start parses everything again.
            return

    def _play_style_changed(self, *_args: Any) -> None:
        if self._updating_play_style:
            return
        snapshot = self.view_model.control_plane.snapshot()
        if snapshot.controller.active:
            self._updating_play_style = True
            try:
                self.play_style.set(PLAY_STYLE_LABELS[snapshot.config.play_style])
            finally:
                self._updating_play_style = False
            return
        try:
            self._sync_pet_options()
            self.view_model.apply_draft(**self._draft_fields())
        except (TypeError, ValueError):
            return

    def _publish_command(self, command: str, result: Any) -> None:
        command_label = {
            "start_farm": "Bắt đầu farm",
            "resume_from_checkpoint": "Tiếp tục từ checkpoint",
            "request_graceful_stop": "Dừng sau trận hiện tại",
            "emergency_stop": "Dừng khẩn cấp",
            "close_after_graceful_stop": "Dừng sau trận rồi đóng",
            "close_after_emergency_stop": "Dừng khẩn cấp rồi đóng",
        }.get(command, command)
        reason_label = self.view_model.reason_text(result.reason)
        self.command_feedback.set(
            f"{command_label}: {'ĐÃ CHẤP NHẬN' if result.accepted else 'BỊ TỪ CHỐI'} — "
            f"{reason_label} — thế hệ {result.generation}"
        )
        self.event_log.write(
            command,
            result=asdict(result),
            reason=result.reason,
            operatorMessage=(
                f"{command_label}: {'đã chấp nhận' if result.accepted else 'bị từ chối'} "
                f"({result.reason})"
            ),
        )

    def _start_farm(self) -> None:
        try:
            self._apply_game_location(persist=False)
            config = self.view_model.apply_draft(**self._draft_fields())
            self._persist_preferences(config)
            self.start_commands_submitted += 1
            result = self.view_model.start_farm()
            self._publish_command("start_farm", result)
            if result.accepted:
                pinned = self.view_model.control_plane.snapshot().config
                self._lock_accepted_run_config(pinned)
                self.boss_id.set(pinned.normalized_boss_id or "")
                self.boss_name.set(pinned.normalized_boss_name or "")
                self._persist_preferences(pinned)
        except Exception as exc:
            self.command_feedback.set(f"Không thể bắt đầu — {exc}")
            self.event_log.write("start_farm_rejected", error=str(exc))

    def _resume_checkpoint(self) -> None:
        try:
            self._apply_game_location(persist=False)
            config = self.view_model.apply_draft(**self._draft_fields())
            self._persist_preferences(config)
            self.resume_commands_submitted += 1
            result = self.view_model.resume_from_checkpoint()
            self._publish_command(
                "resume_from_checkpoint",
                result,
            )
            if result.accepted:
                pinned = self.view_model.control_plane.snapshot().config
                self._lock_accepted_run_config(pinned)
                self.boss_id.set(pinned.normalized_boss_id or "")
                self.boss_name.set(pinned.normalized_boss_name or "")
                self._persist_preferences(pinned)
        except Exception as exc:
            self.command_feedback.set(f"Không thể tiếp tục — {exc}")
            self.event_log.write("resume_checkpoint_rejected", error=str(exc))

    def _graceful_stop(self) -> None:
        generation = self.view_model.control_plane.snapshot().controller.generation
        self.graceful_commands_submitted += 1
        self._publish_command(
            "request_graceful_stop",
            self.view_model.request_graceful_stop(generation),
        )

    def _emergency_stop(self) -> None:
        snapshot = self.view_model.control_plane.snapshot()
        self.emergency_commands_submitted += 1
        if self._close_coordinator.intent is CloseIntent.AFTER_GRACEFUL_STOP:
            request = self._close_coordinator.request(CloseChoice.EMERGENCY, snapshot)
            if request.command_result is not None:
                self._publish_command("emergency_stop", request.command_result)
            return
        self._publish_command(
            "emergency_stop",
            self.view_model.emergency_stop(snapshot.controller.generation),
        )

    def _draft_validity(self) -> tuple[bool, str | None]:
        try:
            DesktopConfig.from_strings(**self._draft_fields())
            return True, None
        except (TypeError, ValueError) as exc:
            return False, str(exc)

    def _set_config_editable(self, editable: bool) -> None:
        if self._config_editable is editable:
            return
        self._config_editable = editable
        for widget, editable_state in self._config_widgets:
            widget.configure(state=editable_state if editable else "disabled")
        self.validate_button.configure(state="normal" if editable else "disabled")
        self._sync_pet_options()

    def _render_operator_log(self) -> None:
        import tkinter as tk

        entries = self.event_log.entries()
        latest = entries[-1].sequence if entries else 0
        if latest == self._last_operator_log_sequence:
            return
        self._last_operator_log_sequence = latest
        lines = [
            f"{entry.timestamp[11:23]} {entry.event}: {entry.message}"
            for entry in entries
        ]
        self.operator_log_text.configure(state=tk.NORMAL)
        self.operator_log_text.delete("1.0", tk.END)
        if lines:
            self.operator_log_text.insert(tk.END, "\n".join(lines) + "\n")
            self.operator_log_text.see(tk.END)
        self.operator_log_text.configure(state=tk.DISABLED)

    def _destroy_close_dialog(self) -> None:
        dialog = self._close_dialog
        self._close_dialog = None
        if dialog is not None:
            try:
                dialog.grab_release()
            except Exception:
                pass
            try:
                dialog.destroy()
            except Exception:
                pass

    def _show_close_dialog(self) -> None:
        import tkinter as tk
        from tkinter import ttk

        if self._close_dialog is not None:
            try:
                self._close_dialog.lift()
            except Exception:
                pass
            return
        dialog = tk.Toplevel(self.root)
        self._close_dialog = dialog
        dialog.title("FarmRunner đang hoạt động")
        dialog.resizable(False, False)
        dialog.transient(self.root)
        dialog.protocol(
            "WM_DELETE_WINDOW", lambda: self._choose_close(CloseChoice.CANCEL)
        )
        frame = ttk.Frame(dialog, padding=16)
        frame.pack(fill=tk.BOTH, expand=True)
        ttk.Label(
            frame,
            text="Tự động vẫn đang chạy. Hãy chọn cách đóng an toàn.",
            wraplength=390,
            font=("Segoe UI", 10, "bold"),
        ).pack(anchor=tk.W, pady=(0, 12))
        ttk.Button(
            frame,
            text="Hủy / Tiếp tục chạy",
            command=lambda: self._choose_close(CloseChoice.CANCEL),
        ).pack(fill=tk.X, pady=3)
        ttk.Button(
            frame,
            text="Dừng sau trận hiện tại rồi đóng",
            command=lambda: self._choose_close(CloseChoice.GRACEFUL),
        ).pack(fill=tk.X, pady=3)
        ttk.Button(
            frame,
            text="Dừng khẩn cấp và đóng — Ngay lập tức",
            command=lambda: self._choose_close(CloseChoice.EMERGENCY),
        ).pack(fill=tk.X, pady=3)
        ttk.Label(
            frame,
            text=(
                "Dừng khẩn cấp thu hồi quyền input của công cụ ngay lập tức; "
                "lệnh này không thoát trận và không bảo đảm trở về phòng chờ boss."
            ),
            foreground="#a00000",
            wraplength=390,
        ).pack(anchor=tk.W, pady=(10, 0))
        dialog.grab_set()
        dialog.lift()
        try:
            dialog.attributes("-topmost", True)
        except Exception:
            pass

        # Merely opening the active-run close chooser must not steal an entire
        # 14-second local turn. Keep the modal visible/grabbed, but immediately
        # return focus to the owned game process. Choosing graceful close
        # performs the same handoff again after latching the stop request.
        snapshot = self.view_model.control_plane.snapshot()
        result = self.view_model.restore_game_foreground(
            snapshot.controller.generation
        )
        self.event_log.write(
            "close_dialog_foreground_handoff",
            accepted=result.accepted,
            reason=result.reason,
            generation=snapshot.controller.generation,
            operatorMessage=(
                "Hộp chọn cách đóng đang hiển thị; đã trả tiêu điểm về trò chơi trong khi chờ lựa chọn."
                if result.accepted
                else "Hộp chọn cách đóng đang hiển thị; không thể trả tiêu điểm về trò chơi."
            ),
        )

    def _choose_close(self, choice: CloseChoice) -> None:
        snapshot = self.view_model.control_plane.snapshot()
        if choice is CloseChoice.CANCEL:
            request = self._close_coordinator.request(choice, snapshot)
            self._destroy_close_dialog()
            self.command_feedback.set("Đã hủy đóng; FarmRunner tiếp tục chạy.")
            self.event_log.write(
                "ui_close_cancelled",
                reason=request.reason,
                operatorMessage="Đã hủy đóng; giữ nguyên FarmRunner đang hoạt động.",
            )
            return
        if choice is CloseChoice.GRACEFUL:
            self.graceful_commands_submitted += 1
            command_name = "close_after_graceful_stop"
        else:
            self.emergency_commands_submitted += 1
            command_name = "close_after_emergency_stop"
        request = self._close_coordinator.request(choice, snapshot)
        self._destroy_close_dialog()
        if request.command_result is not None:
            self._publish_command(command_name, request.command_result)
        if request.accepted:
            self.command_feedback.set(
                f"{CLOSE_INTENT_LABELS[request.intent.value]}: "
                "đang chờ bộ điều khiển dừng bất đồng bộ."
            )
            self.event_log.write(
                "deferred_close_accepted",
                reason=request.reason,
                generation=self._close_coordinator.generation,
                intent=request.intent.value,
                operatorMessage=f"Đã chấp nhận yêu cầu đóng trì hoãn: {request.intent.value}.",
            )
        else:
            self.command_feedback.set(f"Thao tác đóng bị từ chối — {request.reason}")

    def _begin_shutdown(self, reason: str) -> None:
        if self._shutdown_started or self._closed:
            return
        self._shutdown_started = True
        self._destroy_close_dialog()
        self.command_feedback.set("Đang đóng tài nguyên giao diện bất đồng bộ...")
        self.event_log.write(
            "ui_shutdown_started",
            reason=reason,
            closeIntent=self._close_coordinator.intent.value,
            operatorMessage=f"Đã bắt đầu đóng giao diện: {reason}.",
        )
        if self._auto_close_after is not None:
            try:
                self.root.after_cancel(self._auto_close_after)
            except Exception:
                pass
            self._auto_close_after = None
        if not self._shutdown_worker.start():
            self.event_log.write(
                "ui_shutdown_duplicate_ignored",
                operatorMessage="Đã bỏ qua yêu cầu đóng bị lặp.",
            )
        self._shutdown_after = self.root.after(50, self._check_shutdown)

    def _check_shutdown(self) -> None:
        result = self._shutdown_worker.result
        if result is None:
            self._shutdown_after = self.root.after(50, self._check_shutdown)
            return
        self.poller_alive_after_close = not result.poller_stopped
        if not result.poller_stopped or not result.control_plane_closed:
            self._shutdown_started = False
            self._shutdown_worker = DesktopShutdownWorker(self.view_model)
            self.command_feedback.set(
                f"Đóng an toàn không thành công; giao diện vẫn mở — {result.error}"
            )
            self.event_log.write(
                "ui_shutdown_failed",
                error=result.error,
                operatorMessage="Đóng giao diện an toàn không thành công; cửa sổ được giữ lại.",
            )
            self._render_after = self.root.after(0, self._render)
            return
        self._closed = True
        self.event_log.write(
            "ui_closed",
            pollerStopped=True,
            pollerAliveAfterClose=False,
            renderTicks=self.render_ticks,
            handledUiErrors=self.handled_ui_errors,
            safety=asdict(self.view_model.control_plane.snapshot().safety),
            operatorMessage="Giao diện Desktop đã đóng sạch; tiến trình trò chơi không bị tác động.",
        )
        self.root.destroy()

    def _render(self) -> None:
        if self._closed or self._shutdown_started:
            return
        try:
            presentation = self.view_model.presentation()
            self.notice_var.set(presentation.read_only_notice)
            self.operator_status_var.set(presentation.operator_status)
            self.operator_guidance_var.set(presentation.operator_guidance)
            for key, value in visible_runtime_values(presentation):
                self.status_vars[key].set(value)
            self.checkpoint_var.set(presentation.checkpoint)
            self.controller_var.set(presentation.controller)
            self.health_var.set(presentation.health)
            self.error_var.set(presentation.error)
            self.refreshed_var.set(presentation.refreshed)
            snapshot = self.view_model.control_plane.snapshot()
            controls = snapshot.controls
            close_pending = self._close_coordinator.intent is not CloseIntent.NONE
            if snapshot.controller.active and self._locked_run_limits is not None:
                # A disabled widget is already operator-immutable. Reasserting
                # the accepted values also prevents any programmatic StringVar
                # drift while this controller generation owns the run.
                self.target_matches.set(self._locked_run_limits[0])
                self.max_attempts.set(self._locked_run_limits[1])
                self._display_pet_config(snapshot.config)
            elif not snapshot.controller.active:
                self._locked_run_limits = None
            if (
                not snapshot.controller.active
                and snapshot.runtime.lobby_branch == "CHINH_PHUC_ROOM"
                and (
                    snapshot.runtime.target_id is not None
                    or snapshot.runtime.target_name is not None
                )
            ):
                self.boss_id.set(snapshot.runtime.target_id or "")
                self.boss_name.set(snapshot.runtime.target_name or "")
            elif not snapshot.controller.active:
                # A previously persisted target is historical display data,
                # never authority on the world boss map.  Blank it in the
                # editable draft until an exact current room is proven.
                self.boss_id.set("")
                self.boss_name.set("")
            draft_valid, draft_error = self._draft_validity()
            profile_reason = None
            if draft_valid:
                profile_reason = DesktopConfig.from_strings(
                    **self._draft_fields()
                ).farm_policy_blocker_reason
            config_editable = controls.config_editable and not close_pending
            self._set_config_editable(config_editable)
            start_actionable = bool(
                controls.start.actionable
                and presentation.snapshot_actionable
                and draft_valid
                and profile_reason is None
                and not close_pending
            )
            self.start_button.configure(
                state="normal" if start_actionable else "disabled"
            )
            self.resume_button.configure(
                state=(
                    "normal"
                    if controls.resume.actionable
                    and presentation.snapshot_actionable
                    and draft_valid
                    and profile_reason is None
                    and not close_pending
                    else "disabled"
                )
            )
            self.graceful_button.configure(
                state=(
                    "normal"
                    if controls.graceful_stop.actionable and not close_pending
                    else "disabled"
                ),
                text=graceful_button_text(snapshot.controller),
            )
            self.emergency_button.configure(
                state="normal" if controls.emergency_stop.actionable else "disabled"
            )
            if close_pending:
                reason_text = (
                    "Đang chờ đóng trì hoãn: "
                    f"{CLOSE_INTENT_LABELS[self._close_coordinator.intent.value]}"
                )
            elif not presentation.snapshot_actionable:
                reason_text = "Dữ liệu trạng thái đã cũ; các nút điều khiển bị khóa."
            elif not draft_valid:
                reason_text = f"Cấu hình không hợp lệ: {draft_error}"
            elif profile_reason:
                reason_text = self.view_model.reason_text(profile_reason)
            elif start_actionable:
                reason_text = (
                    "Có thể bắt đầu: phòng pet hiện tại sẽ được ghim; "
                    "khôi phục có giới hạn chỉ được vào lại đúng pet này nếu bị đẩy ra."
                )
            else:
                reason_text = self.view_model.reason_text(controls.start.reason)
            self.control_reason_var.set(reason_text)
            self._render_operator_log()

            close_observation = self._close_coordinator.observe(snapshot)
            if close_observation.transition is CloseTransition.READY:
                self._begin_shutdown(close_observation.reason)
            elif close_observation.transition in {
                CloseTransition.STALE,
                CloseTransition.FAILED,
            }:
                self.command_feedback.set(
                    f"Đã hủy đóng trì hoãn một cách an toàn — {close_observation.reason}"
                )
                self.event_log.write(
                    "deferred_close_cancelled_safely",
                    reason=close_observation.reason,
                    operatorMessage=(
                        "Đã hủy đóng trì hoãn vì quyền sở hữu hoặc trạng thái bộ điều khiển thay đổi."
                    ),
                )
            self.render_ticks += 1
        except Exception as exc:  # keep Tk event loop alive and visibly safe
            self.handled_ui_errors += 1
            self.health_var.set("LỖI HIỂN THỊ GIAO DIỆN — KHÔNG THỂ THAO TÁC")
            self.error_var.set(f"{type(exc).__name__}: {exc}")
            self.event_log.write(
                "ui_render_error", error=f"{type(exc).__name__}: {exc}"
            )
        if not self._shutdown_started:
            self._render_after = self.root.after(200, self._render)

    def run(self) -> DesktopUiResult:
        self.event_log.write(
            "ui_launched",
            framework="tkinter/ttk",
            readOnlyMemory=True,
            farmRunnerCommandsAvailable=True,
            automaticStart=False,
            automaticResume=False,
            operatorMessage="Giao diện Desktop đã mở; chưa gửi lệnh farm nào.",
        )
        if not self.view_model.poller.start():
            raise RuntimeError("bộ đọc trạng thái Desktop từ chối lần khởi động duy nhất")
        self.event_log.write("control_plane_initialized", pollerStarts=1)
        self._render_after = self.root.after(0, self._render)
        if self.auto_close_seconds > 0:
            self._auto_close_after = self.root.after(
                int(self.auto_close_seconds * 1000), self.close
            )
        self.root.mainloop()
        log_stats = self.event_log.stats()
        return DesktopUiResult(
            render_ticks=self.render_ticks,
            handled_ui_errors=self.handled_ui_errors,
            poller_starts=self.view_model.poller.starts,
            poller_alive_after_close=self.poller_alive_after_close,
            final_snapshot=self.view_model.control_plane.snapshot(),
            operator_log_bound=log_stats["configuredBound"],
            operator_log_max_observed=log_stats["maxObservedEntries"],
            operator_log_total_entries=log_stats["totalEntries"],
            close_intent=self._close_coordinator.intent.value,
        )

    def close(self) -> None:
        if self._closed or self._shutdown_started:
            return
        snapshot = self.view_model.control_plane.snapshot()
        controller = snapshot.controller
        if controller.active:
            if self._close_coordinator.intent is not CloseIntent.NONE:
                self.command_feedback.set(
                    "Đã có yêu cầu đóng trì hoãn: "
                    f"{CLOSE_INTENT_LABELS[self._close_coordinator.intent.value]}"
                )
                return
            self.command_feedback.set(
                "FarmRunner đang hoạt động; hãy chọn cách đóng an toàn."
            )
            self.event_log.write(
                "ui_close_choice_requested",
                generation=controller.generation,
                state=controller.state.value,
                operatorMessage="Đã yêu cầu đóng khi FarmRunner đang hoạt động.",
            )
            self._show_close_dialog()
            return
        self.event_log.write(
            "ui_idle_close_requested",
            operatorMessage="Đã yêu cầu đóng giao diện đang rảnh; tiến trình trò chơi được giữ nguyên.",
        )
        self._begin_shutdown("IDLE_CLOSE")


def create_root() -> Any:
    import tkinter as tk

    return tk.Tk()


__all__ = [
    "CloseChoice",
    "CloseIntent",
    "CloseObservation",
    "CloseRequestResult",
    "CloseTransition",
    "DesktopApplication",
    "DesktopCloseCoordinator",
    "DesktopEventLog",
    "DesktopPresentation",
    "DesktopShutdownWorker",
    "DesktopUiResult",
    "DesktopViewModel",
    "OperatorLogEntry",
    "ShutdownResult",
    "decimal_digits_or_empty",
    "create_root",
]
