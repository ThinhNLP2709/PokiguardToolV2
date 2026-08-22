"""Tkinter/ttk desktop shell for Phase 2E.1.

Only session-local draft validation and immutable status rendering are exposed.
There are intentionally no Start, graceful-stop, emergency-stop, resume, boss
entry, postmatch, or gameplay commands in this module.
"""

from __future__ import annotations

from dataclasses import asdict, dataclass
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


@dataclass(frozen=True)
class DesktopUiResult:
    render_ticks: int
    handled_ui_errors: int
    poller_starts: int
    poller_alive_after_close: bool
    final_snapshot: ControlPlaneSnapshot


class DesktopEventLog:
    """Small thread-safe JSONL diagnostic sink; never a gameplay truth source."""

    def __init__(self, path: Path) -> None:
        self.path = path.resolve()
        self.path.parent.mkdir(parents=True, exist_ok=True)
        self._handle = self.path.open("a", encoding="utf-8", buffering=1)
        self._lock = threading.Lock()
        self._closed = False

    def write(self, event: str, **fields: Any) -> None:
        with self._lock:
            if self._closed:
                return
            self._handle.write(
                json.dumps(
                    {"timestamp": utc_timestamp(), "event": event, **fields},
                    ensure_ascii=False,
                    separators=(",", ":"),
                    default=str,
                )
                + "\n"
            )

    def poll_event(
        self, event: str, snapshot: ControlPlaneSnapshot | None
    ) -> None:
        if snapshot is None:
            self.write(event)
            return
        runtime = snapshot.runtime
        self.write(
            event,
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
        )

    def close(self) -> None:
        with self._lock:
            if self._closed:
                return
            self._closed = True
            self._handle.flush()
            self._handle.close()


class DesktopViewModel:
    """Presentation mapping and canonical draft validation, with no commands."""

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
                "PHASE 2E.1 READ-ONLY — no Start, Stop, Resume, boss-entry, "
                "postmatch, or gameplay commands"
            ),
        )


class DesktopApplication:
    """Minimal ttk window whose event thread only renders cached snapshots."""

    def __init__(
        self,
        root: Any,
        view_model: DesktopViewModel,
        *,
        event_log: DesktopEventLog,
        auto_close_seconds: float = 0.0,
    ) -> None:
        import tkinter as tk
        from tkinter import ttk

        self.root = root
        self.view_model = view_model
        self.event_log = event_log
        self.auto_close_seconds = max(0.0, float(auto_close_seconds))
        self.render_ticks = 0
        self.handled_ui_errors = 0
        self.poller_alive_after_close = False
        self._closed = False
        self._render_after: str | None = None
        self._auto_close_after: str | None = None

        root.title("PokiguardToolV2 — Read-Only Control UI")
        root.geometry("780x640")
        root.minsize(700, 560)
        root.protocol("WM_DELETE_WINDOW", self.close)

        outer = ttk.Frame(root, padding=14)
        outer.pack(fill=tk.BOTH, expand=True)

        title = ttk.Label(
            outer,
            text="PokiguardToolV2",
            font=("Segoe UI", 18, "bold"),
        )
        title.pack(anchor=tk.W)
        self.notice_var = tk.StringVar()
        ttk.Label(outer, textvariable=self.notice_var, foreground="#8a4b08").pack(
            anchor=tk.W, pady=(0, 10)
        )

        runtime_frame = ttk.LabelFrame(outer, text="Connection / Runtime Status", padding=10)
        runtime_frame.pack(fill=tk.X, pady=(0, 10))
        self.status_vars: dict[str, Any] = {}
        runtime_rows = (
            ("Game", "connection"),
            ("Attachment", "attachment"),
            ("Process", "process"),
            ("Lifecycle", "lifecycle"),
            ("MatchId", "match_id"),
            ("Session", "session"),
            ("Runtime target", "runtime_target"),
        )
        for row, (label, key) in enumerate(runtime_rows):
            ttk.Label(runtime_frame, text=f"{label}:").grid(
                row=row, column=0, sticky=tk.NW, padx=(0, 8), pady=2
            )
            variable = tk.StringVar(value="UNKNOWN")
            self.status_vars[key] = variable
            ttk.Label(runtime_frame, textvariable=variable, wraplength=610).grid(
                row=row, column=1, sticky=tk.NW, pady=2
            )
        runtime_frame.columnconfigure(1, weight=1)

        config_frame = ttk.LabelFrame(
            outer, text="BASIC Configuration Draft (session only)", padding=10
        )
        config_frame.pack(fill=tk.X, pady=(0, 10))
        config = view_model.control_plane.snapshot().config
        self.play_style = tk.StringVar(value=config.play_style.value)
        self.mana_priority = tk.StringVar(value=config.mana_priority.value)
        self.intelligence = tk.StringVar(value=Intelligence.BASIC.value)
        self.boss_id = tk.StringVar(value=config.normalized_boss_id or "")
        self.boss_name = tk.StringVar(value=config.normalized_boss_name or "")
        self.target_matches = tk.StringVar(value=str(config.target_completed_matches))
        self.max_recoveries = tk.StringVar(value=str(config.max_technical_recoveries))
        self.max_attempts = tk.StringVar(value=str(config.max_match_attempts))
        self.config_feedback = tk.StringVar(value="Draft is not persisted and cannot start farming.")

        fields = (
            (
                "PlayStyle",
                ttk.Combobox(
                    config_frame,
                    textvariable=self.play_style,
                    values=tuple(value.value for value in PlayStyle),
                    state="readonly",
                ),
            ),
            (
                "ManaPriority",
                ttk.Combobox(
                    config_frame,
                    textvariable=self.mana_priority,
                    values=tuple(value.value for value in ManaPriority),
                    state="readonly",
                ),
            ),
            (
                "Intelligence",
                ttk.Combobox(
                    config_frame,
                    textvariable=self.intelligence,
                    values=(Intelligence.BASIC.value,),
                    state="disabled",
                ),
            ),
            ("Target boss ID", ttk.Entry(config_frame, textvariable=self.boss_id)),
            ("Target boss name", ttk.Entry(config_frame, textvariable=self.boss_name)),
            ("Target matches", ttk.Entry(config_frame, textvariable=self.target_matches)),
            ("Max recoveries", ttk.Entry(config_frame, textvariable=self.max_recoveries)),
            ("Max attempts", ttk.Entry(config_frame, textvariable=self.max_attempts)),
        )
        for row, (label, widget) in enumerate(fields):
            ttk.Label(config_frame, text=f"{label}:").grid(
                row=row, column=0, sticky=tk.W, padx=(0, 8), pady=2
            )
            widget.grid(row=row, column=1, sticky=tk.EW, pady=2)
        config_frame.columnconfigure(1, weight=1)
        ttk.Button(
            config_frame,
            text="Validate Draft (no gameplay action)",
            command=self._validate_draft,
        ).grid(row=len(fields), column=0, columnspan=2, sticky=tk.W, pady=(8, 2))
        ttk.Label(
            config_frame,
            textvariable=self.config_feedback,
            wraplength=640,
        ).grid(row=len(fields) + 1, column=0, columnspan=2, sticky=tk.W)

        checkpoint_frame = ttk.LabelFrame(
            outer, text="Read-Only Run / Checkpoint", padding=10
        )
        checkpoint_frame.pack(fill=tk.X, pady=(0, 10))
        self.checkpoint_var = tk.StringVar(value="NONE")
        ttk.Label(
            checkpoint_frame,
            textvariable=self.checkpoint_var,
            wraplength=700,
        ).pack(anchor=tk.W)

        health_frame = ttk.LabelFrame(outer, text="Backend Health", padding=10)
        health_frame.pack(fill=tk.BOTH, expand=True)
        self.health_var = tk.StringVar(value="INITIALIZING")
        self.error_var = tk.StringVar(value="NONE")
        self.refreshed_var = tk.StringVar(value="NOT POLLED")
        for label, variable in (
            ("Health", self.health_var),
            ("Latest error", self.error_var),
            ("Snapshot", self.refreshed_var),
        ):
            ttk.Label(health_frame, text=f"{label}:").pack(anchor=tk.W)
            ttk.Label(health_frame, textvariable=variable, wraplength=700).pack(
                anchor=tk.W, pady=(0, 5)
            )

    def _validate_draft(self) -> None:
        try:
            config = self.view_model.apply_draft(
                play_style=self.play_style.get(),
                mana_priority=self.mana_priority.get(),
                intelligence=self.intelligence.get(),
                boss_id=self.boss_id.get(),
                boss_name=self.boss_name.get(),
                target_completed_matches=self.target_matches.get(),
                max_technical_recoveries=self.max_recoveries.get(),
                max_match_attempts=self.max_attempts.get(),
            )
            self.config_feedback.set(
                "VALID session draft — read-only; no FarmRunner command was generated. "
                f"Target={config.normalized_boss_name or config.normalized_boss_id}, "
                f"matches={config.target_completed_matches}."
            )
            self.event_log.write("draft_config_validated", config=asdict(config))
        except Exception as exc:  # expected validation feedback, not UI failure
            self.config_feedback.set(f"INVALID draft — {exc}")
            self.event_log.write(
                "draft_config_rejected", error=f"{type(exc).__name__}: {exc}"
            )

    def _render(self) -> None:
        if self._closed:
            return
        try:
            presentation = self.view_model.presentation()
            self.notice_var.set(presentation.read_only_notice)
            for key in (
                "connection",
                "attachment",
                "process",
                "lifecycle",
                "match_id",
                "session",
                "runtime_target",
            ):
                self.status_vars[key].set(getattr(presentation, key))
            self.checkpoint_var.set(presentation.checkpoint)
            self.health_var.set(presentation.health)
            self.error_var.set(presentation.error)
            self.refreshed_var.set(presentation.refreshed)
            self.render_ticks += 1
        except Exception as exc:  # keep Tk event loop alive and visibly safe
            self.handled_ui_errors += 1
            self.health_var.set("UI RENDER ERROR — NON-ACTIONABLE")
            self.error_var.set(f"{type(exc).__name__}: {exc}")
            self.event_log.write(
                "ui_render_error", error=f"{type(exc).__name__}: {exc}"
            )
        self._render_after = self.root.after(200, self._render)

    def run(self) -> DesktopUiResult:
        self.event_log.write(
            "ui_launched",
            framework="tkinter/ttk",
            readOnly=True,
            farmRunnerCommandsAvailable=False,
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
        return DesktopUiResult(
            render_ticks=self.render_ticks,
            handled_ui_errors=self.handled_ui_errors,
            poller_starts=self.view_model.poller.starts,
            poller_alive_after_close=self.poller_alive_after_close,
            final_snapshot=self.view_model.control_plane.snapshot(),
        )

    def close(self) -> None:
        if self._closed:
            return
        self._closed = True
        self.event_log.write("ui_close_requested")
        if self._render_after is not None:
            try:
                self.root.after_cancel(self._render_after)
            except Exception:
                pass
        if self._auto_close_after is not None:
            try:
                self.root.after_cancel(self._auto_close_after)
            except Exception:
                pass
        stopped = self.view_model.poller.stop(timeout_seconds=30.0)
        self.poller_alive_after_close = not stopped
        self.view_model.control_plane.close()
        self.event_log.write(
            "ui_closed",
            pollerStopped=stopped,
            pollerAliveAfterClose=self.poller_alive_after_close,
            renderTicks=self.render_ticks,
            handledUiErrors=self.handled_ui_errors,
            safety=asdict(self.view_model.control_plane.snapshot().safety),
        )
        self.root.destroy()


def create_root() -> Any:
    import tkinter as tk

    return tk.Tk()


__all__ = [
    "DesktopApplication",
    "DesktopEventLog",
    "DesktopPresentation",
    "DesktopUiResult",
    "DesktopViewModel",
    "create_root",
]
