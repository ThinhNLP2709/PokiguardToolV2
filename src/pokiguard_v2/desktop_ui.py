"""Lifecycle-aware Phase 2E.3 Tkinter control surface."""

from __future__ import annotations

from collections import deque
from dataclasses import asdict, dataclass
from enum import Enum
import json
from pathlib import Path
import threading
import time
from typing import Any

from .basic_policy import Intelligence, ManaPriority, PlayStyle
from .desktop_control_plane import (
    ControlPlaneSnapshot,
    DesktopConfig,
    DesktopControlPlane,
    SnapshotPoller,
    utc_timestamp,
)
from .desktop_farm_controller import DesktopControllerState
from .desktop_preferences import (
    DesktopPreferenceStore,
    PreferenceError,
    PreferenceWarning,
)
from .version import APP_BUILD, APP_TITLE, APP_VERSION


VISIBLE_RUNTIME_ROWS = (
    ("Game", "connection"),
    ("Lifecycle", "lifecycle"),
    ("Runtime target", "runtime_target"),
)

DESKTOP_TAB_TITLES = ("Control", "Preferences", "Diagnostics / Log")
PREFERENCE_TABLE_ROWS = ("PlayStyle", "Intelligence", "ManaPriority")
INITIAL_FOCUS_TARGET = "notebook"
BACKGROUND_UNFOCUS_WIDGET_CLASSES = frozenset(
    {"Tk", "TFrame", "TLabelframe", "TLabel", "Frame", "Label"}
)


def background_click_clears_entry_focus(widget_class: str) -> bool:
    """Return whether a pointer click represents non-interactive whitespace."""

    return widget_class in BACKGROUND_UNFOCUS_WIDGET_CLASSES


def run_limit_text(config: DesktopConfig) -> tuple[str, str]:
    """Normalize the two immutable per-run limits for their Entry variables."""

    return str(config.target_completed_matches), str(config.max_match_attempts)


def graceful_button_text(controller: DesktopControllerSnapshot) -> str:
    """Show pending text only while a controller still owns active work.

    ``graceful_stop_requested`` remains true in the terminal snapshot as
    durable run evidence.  That history must not leave the operator control
    looking pending after the controller reaches its safe stopped boundary.
    """

    if controller.active and controller.graceful_stop_requested:
        return "Stopping after current match..."
    return "Stop After Current Match"


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
        for key in ("reason", "lifecycle", "error", "farmRunId", "summary"):
            value = fields.get(key)
            if value not in (None, ""):
                parts.append(f"{key}={value}")
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
                f"{runtime.lifecycle}; controller={controller.state.value}; "
                f"completed={controller.completed_matches}; "
                f"attempts={controller.match_attempts}"
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
            "AVAILABLE": "Ready.",
            "INITIALIZING": "Initializing runtime status.",
            "CONTROL_PLANE_CLOSED": "The desktop controller is closing.",
            "CONTROLLER_UNAVAILABLE": "Farm controller is unavailable.",
            "CONTROLLER_ALREADY_ACTIVE": "A bounded farm run is already active.",
            "STALE_RUNTIME_SNAPSHOT": "Runtime snapshot is stale; waiting for a fresh read.",
            "GAME_NOT_DETECTED": "Pokiguard is not running.",
            "GAME_NOT_ATTACHED": "Waiting for read-only game attachment.",
            "UNSUPPORTED_ARCHITECTURE": "The detected game architecture is unsupported.",
            "BACKEND_NOT_HEALTHY": "Backend health is not actionable.",
            "START_REQUIRES_BOSS_LOBBY": "Waiting for the exact BOSS_LOBBY.",
            "CURRENT_BOSS_ROOM_NOT_PROVEN": (
                "Open the exact pet boss room first; the world boss map is not actionable."
            ),
            "CURRENT_ROOM_TARGET_NOT_PROVEN": (
                "Waiting for the selected room's exact pet identity."
            ),
            "CURRENT_ROOM_TARGET_AMBIGUOUS": (
                "Current room target evidence is ambiguous; Start remains blocked."
            ),
            "CURRENT_ROOM_TARGET_INVALID": (
                "Current room target identity is invalid; Start remains blocked."
            ),
            "NO_RESUMABLE_CHECKPOINT": "No resumable checkpoint is available.",
            "NO_ACTIVE_CONTROLLER": "No active FarmRunner owns automation.",
            "GRACEFUL_STOP_PENDING": "Stopping after the current match.",
            "EMERGENCY_STOP_ACKNOWLEDGED": "Emergency Stop is already acknowledged.",
            "EMERGENCY_STOP_ALREADY_ACKNOWLEDGED": "Emergency Stop is already acknowledged.",
        }
        if code == "INVALID_LAUNCH":
            return "Configuration/checkpoint is not valid for this run."
        return messages.get(code, reason)

    def presentation(self, *, now_monotonic: float | None = None) -> DesktopPresentation:
        snapshot = self.control_plane.snapshot()
        runtime = snapshot.runtime
        now = time.monotonic() if now_monotonic is None else now_monotonic
        age = max(0.0, now - snapshot.sampled_monotonic)
        stale = snapshot.stale or age > self.stale_after_seconds

        detected = (
            "DETECTED"
            if runtime.game_detected is True
            else "NOT DETECTED"
            if runtime.game_detected is False
            else "UNKNOWN"
        )
        attachment = "ATTACHED (READ-ONLY)" if runtime.attached else "NOT ATTACHED"
        process = (
            f"PID {runtime.pid} / {runtime.architecture or 'UNKNOWN'}"
            if runtime.pid is not None
            else "UNAVAILABLE"
        )
        lifecycle = runtime.lifecycle or "UNKNOWN"
        if stale:
            lifecycle = f"{lifecycle} (STALE / NON-ACTIONABLE)"
        runtime_target = (
            " / ".join(
                value
                for value in (runtime.target_name, runtime.target_id)
                if value
            )
            or "UNKNOWN"
        )
        if runtime.lobby_branch:
            runtime_target = f"{runtime_target} [{runtime.lobby_branch}]"
        checkpoint = snapshot.checkpoint
        if checkpoint.available:
            checkpoint_text = (
                f"{checkpoint.finalized_status or 'UNFINALIZED'} — "
                f"{checkpoint.completed_matches}/{checkpoint.target_completed_matches} "
                f"(W/L/U {checkpoint.wins}/{checkpoint.losses}/"
                f"{checkpoint.unknown_results}) — {checkpoint.farm_run_id}"
            )
        elif checkpoint.error:
            checkpoint_text = f"UNAVAILABLE — {checkpoint.error}"
        else:
            checkpoint_text = "NONE"
        health = "STALE" if stale and snapshot.health == "OK" else snapshot.health
        controller = snapshot.controller
        controller_text = (
            f"{controller.state.value} — Completed "
            f"{controller.completed_matches}/{controller.target_completed_matches} — "
            f"Attempts {controller.match_attempts}\n"
            f"W/L/U {controller.wins}/{controller.losses}/{controller.unknown_results} — "
            f"Run {controller.farm_run_id or 'PENDING'}"
        )
        controls = snapshot.controls
        if controller.active:
            if controller.state is DesktopControllerState.EMERGENCY_STOPPING:
                operator_status = "EMERGENCY STOPPING"
                operator_guidance = "Automation authority has been revoked; waiting for STOPPED."
            elif controller.graceful_stop_requested:
                operator_status = "GRACEFUL STOP PENDING"
                operator_guidance = "The current match will finish; no next match will start."
            else:
                operator_status = "RUNNING"
                operator_guidance = "Bounded FarmRunner is active. Configuration is locked."
        elif stale:
            operator_status = "STALE_RUNTIME_SNAPSHOT"
            operator_guidance = "Runtime snapshot is stale; all launch actions are disabled."
        elif controls.start.actionable:
            operator_status = "READY"
            operator_guidance = (
                "Exact current pet room and valid bounded configuration are ready; "
                "Start will pin this room target."
            )
        else:
            operator_status = controls.start.reason.split(":", 1)[0]
            operator_guidance = self.reason_text(controls.start.reason)
        return DesktopPresentation(
            connection=detected,
            attachment=attachment,
            process=process,
            lifecycle=lifecycle,
            match_id=runtime.match_id or "UNKNOWN",
            session=runtime.session_key or "UNAVAILABLE",
            runtime_target=runtime_target,
            checkpoint=checkpoint_text,
            health=health,
            error=snapshot.last_error or "NONE",
            refreshed=f"{snapshot.timestamp} (age {age:.1f}s, version {snapshot.version})",
            read_only_notice=(
                "PHASE 2E.3 — READ-ONLY game memory; all actions use the "
                "accepted bounded FarmRunner and normal foreground input"
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
        auto_close_seconds: float = 0.0,
    ) -> None:
        import tkinter as tk
        from tkinter import ttk

        self.root = root
        self.view_model = view_model
        self.event_log = event_log
        self.preference_store = preference_store
        self.preference_warnings = preference_warnings
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
        diagnostics_outer = ttk.Frame(notebook, padding=14)
        for page, tab_title in zip(
            (outer, preferences_outer, diagnostics_outer),
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

        self.operator_status_var = tk.StringVar(value="INITIALIZING")
        self.operator_guidance_var = tk.StringVar(
            value="Waiting for backend snapshot."
        )
        operator_frame = ttk.LabelFrame(outer, text="Operator State", padding=10)
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

        runtime_frame = ttk.LabelFrame(outer, text="Connection / Runtime Status", padding=10)
        runtime_frame.pack(fill=tk.X, pady=(0, 10))
        self.status_vars: dict[str, Any] = {}
        for row, (label, key) in enumerate(VISIBLE_RUNTIME_ROWS):
            ttk.Label(runtime_frame, text=f"{label}:").grid(
                row=row, column=0, sticky=tk.NW, padx=(0, 8), pady=2
            )
            variable = tk.StringVar(value="UNKNOWN")
            self.status_vars[key] = variable
            ttk.Label(runtime_frame, textvariable=variable, wraplength=350).grid(
                row=row, column=1, sticky=tk.NW, pady=2
            )
        runtime_frame.columnconfigure(1, weight=1)

        config = view_model.control_plane.snapshot().config
        self.play_style = tk.StringVar(value=config.play_style.value)
        self.mana_priority = tk.StringVar(value=config.mana_priority.value)
        self.intelligence = tk.StringVar(value=Intelligence.BASIC.value)
        self.boss_id = tk.StringVar(value=config.normalized_boss_id or "")
        self.boss_name = tk.StringVar(value=config.normalized_boss_name or "")
        self.target_matches = tk.StringVar(value=str(config.target_completed_matches))
        self.max_attempts = tk.StringVar(value=str(config.max_match_attempts))
        self._config_widgets: list[tuple[Any, str]] = []

        preferences_frame = ttk.LabelFrame(
            preferences_outer, text="Gameplay Preferences", padding=12
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
        ) -> None:
            ttk.Label(preferences_frame, text=f"{label}:").grid(
                row=row,
                column=0,
                sticky=tk.W,
                padx=(0, 12),
                pady=5,
            )
            widget.grid(row=row, column=1, sticky=tk.EW, pady=5)
            self._config_widgets.append((widget, editable_state))

        preference_field(
            row=0,
            label="PlayStyle",
            widget=ttk.Combobox(
                preferences_frame,
                textvariable=self.play_style,
                values=tuple(value.value for value in PlayStyle),
                state="readonly",
            ),
            editable_state="readonly",
        )
        preference_field(
            row=1,
            label="Intelligence",
            widget=ttk.Combobox(
                preferences_frame,
                textvariable=self.intelligence,
                values=(Intelligence.BASIC.value,),
                state="disabled",
            ),
            editable_state="disabled",
        )
        preference_field(
            row=2,
            label="ManaPriority",
            widget=ttk.Combobox(
                preferences_frame,
                textvariable=self.mana_priority,
                values=tuple(value.value for value in ManaPriority),
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
            text="Validate & Save Preferences",
            command=self._validate_draft,
        )
        self.validate_button.grid(
            row=3, column=0, columnspan=2, sticky=tk.W, pady=(10, 2)
        )

        control_frame = ttk.LabelFrame(
            outer, text="Bounded FarmRunner Control", padding=10
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
            label="Target matches",
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
            label="Max attempts",
            widget_factory=lambda cell: ttk.Entry(
                cell, textvariable=self.max_attempts
            ),
            editable_state="normal",
            padx=(5, 0),
        )

        self.controller_var = tk.StringVar(value="IDLE")
        self.command_feedback = tk.StringVar(value="No command submitted.")
        self.control_reason_var = tk.StringVar(value="Waiting for backend state.")
        self.start_button = ttk.Button(
            control_frame, text="Start", command=self._start_farm
        )
        self.graceful_button = ttk.Button(
            control_frame,
            text="Stop After Current Match",
            command=self._graceful_stop,
        )
        self.emergency_button = ttk.Button(
            control_frame,
            text="Emergency Stop — Immediate",
            command=self._emergency_stop,
        )
        self.resume_button = ttk.Button(
            control_frame,
            text="Resume Checkpoint",
            command=self._resume_checkpoint,
        )
        for row, column, button in (
            (1, 0, self.start_button),
            (1, 1, self.graceful_button),
            (2, 0, self.emergency_button),
            (2, 1, self.resume_button),
        ):
            button.grid(row=row, column=column, padx=(0, 6), pady=2, sticky=tk.W)

        run_status_frame = ttk.LabelFrame(control_frame, text="Run Status", padding=8)
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
            outer, text="Run / Checkpoint", padding=10
        )
        checkpoint_frame.pack(fill=tk.X, pady=(0, 10))
        self.checkpoint_var = tk.StringVar(value="NONE")
        ttk.Label(
            checkpoint_frame,
            textvariable=self.checkpoint_var,
            wraplength=410,
        ).pack(anchor=tk.W)

        health_frame = ttk.LabelFrame(
            diagnostics_outer, text="Backend Health", padding=10
        )
        health_frame.pack(fill=tk.X, pady=(0, 10))
        self.health_var = tk.StringVar(value="INITIALIZING")
        self.error_var = tk.StringVar(value="NONE")
        self.refreshed_var = tk.StringVar(value="NOT POLLED")
        for label, variable in (
            ("Health", self.health_var),
            ("Latest error", self.error_var),
            ("Snapshot", self.refreshed_var),
        ):
            ttk.Label(health_frame, text=f"{label}:").pack(anchor=tk.W)
            ttk.Label(health_frame, textvariable=variable, wraplength=410).pack(
                anchor=tk.W, pady=(0, 5)
            )

        log_frame = ttk.LabelFrame(
            diagnostics_outer,
            text=(
                "Operator Log "
                f"(newest {event_log.max_display_entries}, diagnostic only)"
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
                operatorMessage=f"Preferences fallback: {warning.reason}",
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
        self._set_config_editable(False)
        self.start_button.configure(state="disabled")
        self.resume_button.configure(state="disabled")
        self.notebook.focus_set()
        self.event_log.write(
            "accepted_run_limits_locked",
            targetCompletedMatches=config.target_completed_matches,
            maxMatchAttempts=config.max_match_attempts,
            operatorMessage=(
                "Accepted run limits locked until the controller stops."
            ),
        )

    def _persist_preferences(self, config: DesktopConfig) -> str | None:
        if self.preference_store is None:
            return None
        try:
            self.preference_store.save(config)
            self.event_log.write(
                "preferences_saved",
                path=str(self.preference_store.path),
                operatorMessage="Supported operator preferences saved.",
            )
            return None
        except (PreferenceError, OSError, TypeError, ValueError) as exc:
            reason = getattr(exc, "reason", "PREFERENCE_SAVE_FAILED")
            self.event_log.write(
                "preference_save_warning",
                reason=reason,
                error=f"{type(exc).__name__}: {exc}",
                operatorMessage=f"Preferences were not saved: {reason}",
            )
            return str(reason)

    def _validate_draft(self) -> None:
        try:
            config = self.view_model.apply_draft(**self._draft_fields())
            warning = self._persist_preferences(config)
            self.command_feedback.set(
                f"Preferences saved — matches={config.target_completed_matches}."
                + (f" Warning: {warning}." if warning else "")
            )
            self.event_log.write(
                "draft_config_validated",
                config=asdict(config),
                operatorMessage="Configuration validated through canonical models.",
            )
        except Exception as exc:  # expected validation feedback, not UI failure
            self.command_feedback.set(f"Preferences invalid — {exc}")
            self.event_log.write(
                "draft_config_rejected", error=f"{type(exc).__name__}: {exc}"
            )

    def _draft_fields(self) -> dict[str, str]:
        return {
            "play_style": self.play_style.get(),
            "mana_priority": self.mana_priority.get(),
            "intelligence": self.intelligence.get(),
            "boss_id": self.boss_id.get(),
            "boss_name": self.boss_name.get(),
            "target_completed_matches": self.target_matches.get(),
            # Kept only for backward-compatible DesktopConfig parsing. It is
            # not an operator setting and no longer limits recovery.
            "max_technical_recoveries": str(
                self.view_model.control_plane.snapshot().config.max_technical_recoveries
            ),
            "max_match_attempts": self.max_attempts.get(),
        }

    def _publish_command(self, command: str, result: Any) -> None:
        self.command_feedback.set(
            f"{command}: {'ACCEPTED' if result.accepted else 'REJECTED'} — "
            f"{result.reason} — generation {result.generation}"
        )
        self.event_log.write(
            command,
            result=asdict(result),
            reason=result.reason,
            operatorMessage=(
                f"{command}: {'accepted' if result.accepted else 'rejected'} "
                f"({result.reason})"
            ),
        )

    def _start_farm(self) -> None:
        try:
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
            self.command_feedback.set(f"Start rejected — {exc}")
            self.event_log.write("start_farm_rejected", error=str(exc))

    def _resume_checkpoint(self) -> None:
        try:
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
            self.command_feedback.set(f"Resume rejected — {exc}")
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
        dialog.title("FarmRunner is active")
        dialog.resizable(False, False)
        dialog.transient(self.root)
        dialog.protocol(
            "WM_DELETE_WINDOW", lambda: self._choose_close(CloseChoice.CANCEL)
        )
        frame = ttk.Frame(dialog, padding=16)
        frame.pack(fill=tk.BOTH, expand=True)
        ttk.Label(
            frame,
            text="Automation is still active. Choose an explicit safe close action.",
            wraplength=390,
            font=("Segoe UI", 10, "bold"),
        ).pack(anchor=tk.W, pady=(0, 12))
        ttk.Button(
            frame,
            text="Cancel / Keep Running",
            command=lambda: self._choose_close(CloseChoice.CANCEL),
        ).pack(fill=tk.X, pady=3)
        ttk.Button(
            frame,
            text="Stop After Current Match & Close",
            command=lambda: self._choose_close(CloseChoice.GRACEFUL),
        ).pack(fill=tk.X, pady=3)
        ttk.Button(
            frame,
            text="Emergency Stop & Close — Immediate",
            command=lambda: self._choose_close(CloseChoice.EMERGENCY),
        ).pack(fill=tk.X, pady=3)
        ttk.Label(
            frame,
            text=(
                "Emergency Stop revokes tool input immediately; it does not exit "
                "the game or guarantee BOSS_LOBBY."
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
                "Close chooser is visible; game focus restored while awaiting choice."
                if result.accepted
                else "Close chooser is visible; game focus could not be restored."
            ),
        )

    def _choose_close(self, choice: CloseChoice) -> None:
        snapshot = self.view_model.control_plane.snapshot()
        if choice is CloseChoice.CANCEL:
            request = self._close_coordinator.request(choice, snapshot)
            self._destroy_close_dialog()
            self.command_feedback.set("Close cancelled; FarmRunner keeps running.")
            self.event_log.write(
                "ui_close_cancelled",
                reason=request.reason,
                operatorMessage="Close cancelled; active FarmRunner retained.",
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
                f"{request.intent.value}: waiting asynchronously for controller STOPPED."
            )
            self.event_log.write(
                "deferred_close_accepted",
                reason=request.reason,
                generation=self._close_coordinator.generation,
                intent=request.intent.value,
                operatorMessage=f"Deferred close accepted: {request.intent.value}.",
            )
        else:
            self.command_feedback.set(f"Close action rejected — {request.reason}")

    def _begin_shutdown(self, reason: str) -> None:
        if self._shutdown_started or self._closed:
            return
        self._shutdown_started = True
        self._destroy_close_dialog()
        self.command_feedback.set("Closing UI resources asynchronously...")
        self.event_log.write(
            "ui_shutdown_started",
            reason=reason,
            closeIntent=self._close_coordinator.intent.value,
            operatorMessage=f"UI shutdown started: {reason}.",
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
                operatorMessage="Duplicate shutdown request ignored.",
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
                f"Shutdown failed safely; UI remains open — {result.error}"
            )
            self.event_log.write(
                "ui_shutdown_failed",
                error=result.error,
                operatorMessage="UI shutdown failed safely; window retained.",
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
            operatorMessage="Desktop UI closed cleanly; game process untouched.",
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
            config_editable = controls.config_editable and not close_pending
            self._set_config_editable(config_editable)
            start_actionable = bool(
                controls.start.actionable
                and presentation.snapshot_actionable
                and draft_valid
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
                reason_text = f"Deferred close pending: {self._close_coordinator.intent.value}"
            elif not presentation.snapshot_actionable:
                reason_text = "Runtime snapshot is stale; controls are non-actionable."
            elif not draft_valid:
                reason_text = f"Invalid configuration: {draft_error}"
            elif start_actionable:
                reason_text = (
                    "Start available: exact current pet room will be pinned; "
                    "bounded recovery may re-enter only this pet if ejected."
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
                    f"Deferred close cancelled safely — {close_observation.reason}"
                )
                self.event_log.write(
                    "deferred_close_cancelled_safely",
                    reason=close_observation.reason,
                    operatorMessage=(
                        "Deferred close cancelled because controller ownership/state changed."
                    ),
                )
            self.render_ticks += 1
        except Exception as exc:  # keep Tk event loop alive and visibly safe
            self.handled_ui_errors += 1
            self.health_var.set("UI RENDER ERROR — NON-ACTIONABLE")
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
            operatorMessage="Desktop UI launched; no farm command was dispatched.",
        )
        if not self.view_model.poller.start():
            raise RuntimeError("desktop poller refused its single start")
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
                    f"Deferred close already pending: {self._close_coordinator.intent.value}"
                )
                return
            self.command_feedback.set(
                "FarmRunner is active; choose an explicit safe close action."
            )
            self.event_log.write(
                "ui_close_choice_requested",
                generation=controller.generation,
                state=controller.state.value,
                operatorMessage="Close requested while FarmRunner is active.",
            )
            self._show_close_dialog()
            return
        self.event_log.write(
            "ui_idle_close_requested",
            operatorMessage="Idle UI close requested; game process will remain untouched.",
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
    "create_root",
]
