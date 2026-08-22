"""Read-only application boundary for the Phase 2E.1 desktop UI.

The desktop view never owns a FarmRun, input capability, or Win32 input
backend.  It consumes immutable snapshots produced by one bounded polling
worker and may edit only a session-local, canonically validated draft config.
"""

from __future__ import annotations

from dataclasses import dataclass, replace
from datetime import datetime, timezone
from pathlib import Path
import threading
import time
from typing import Callable, Protocol

from .basic_policy import Intelligence, ManaPriority, PlayStyle, PolicyConfig
from .boss_entry import FarmTarget
from .farm_checkpoint import CheckpointError, CheckpointPayload, load_checkpoint
from .farm_run import FarmRunLimits


def utc_timestamp() -> str:
    return datetime.now(timezone.utc).isoformat(timespec="milliseconds").replace(
        "+00:00", "Z"
    )


@dataclass(frozen=True)
class DesktopConfig:
    """Session-local UI draft backed only by accepted canonical models."""

    play_style: PlayStyle = PlayStyle.SIMPLE
    mana_priority: ManaPriority = ManaPriority.EVOLUTION
    intelligence: Intelligence = Intelligence.BASIC
    boss_id: str | None = "1289"
    boss_name: str | None = "Starburst"
    target_completed_matches: int = 3
    max_technical_recoveries: int = 1
    max_match_attempts: int = 5

    def __post_init__(self) -> None:
        if self.intelligence is not Intelligence.BASIC:
            raise ValueError("REASONING is not implemented")
        # Delegate validation to the accepted gameplay/target/run models.  The
        # UI deliberately owns no independent gameplay rules.
        PolicyConfig(
            play_style=self.play_style,
            mana_priority=self.mana_priority,
            intelligence=self.intelligence,
        )
        FarmTarget(self.normalized_boss_id, self.normalized_boss_name)
        FarmRunLimits(
            self.target_completed_matches,
            self.max_technical_recoveries,
            self.max_match_attempts,
        )

    @property
    def normalized_boss_id(self) -> str | None:
        value = self.boss_id.strip() if self.boss_id is not None else ""
        return value or None

    @property
    def normalized_boss_name(self) -> str | None:
        value = self.boss_name.strip() if self.boss_name is not None else ""
        return value or None

    @classmethod
    def from_strings(
        cls,
        *,
        play_style: str,
        mana_priority: str,
        intelligence: str,
        boss_id: str,
        boss_name: str,
        target_completed_matches: str,
        max_technical_recoveries: str,
        max_match_attempts: str,
    ) -> "DesktopConfig":
        return cls(
            play_style=PlayStyle(play_style),
            mana_priority=ManaPriority(mana_priority),
            intelligence=Intelligence(intelligence),
            boss_id=boss_id,
            boss_name=boss_name,
            target_completed_matches=int(target_completed_matches),
            max_technical_recoveries=int(max_technical_recoveries),
            max_match_attempts=int(max_match_attempts),
        )


@dataclass(frozen=True)
class RuntimeObservation:
    """One provider-owned, non-actionable read-only runtime observation."""

    game_detected: bool | None
    attached: bool
    pid: int | None = None
    architecture: str | None = None
    lifecycle: str = "UNKNOWN"
    match_id: str | None = None
    session_key: str | None = None
    target_id: str | None = None
    target_name: str | None = None
    provider_reason: str | None = None
    error: str | None = None


@dataclass(frozen=True)
class CheckpointSummary:
    available: bool
    path: str | None = None
    schema_version: str | None = None
    farm_run_id: str | None = None
    finalized_status: str | None = None
    completed_matches: int | None = None
    target_completed_matches: int | None = None
    wins: int | None = None
    losses: int | None = None
    unknown_results: int | None = None
    updated_at: float | None = None
    error: str | None = None


@dataclass(frozen=True)
class UiSafetyEvidence:
    """Narrow application-boundary counters; Phase 2E.1 has no dispatch API."""

    farm_runner_starts: int = 0
    gameplay_windows_inputs: int = 0
    boss_entry_commands: int = 0
    graceful_stop_commands: int = 0
    emergency_stop_commands: int = 0
    checkpoint_resume_commands: int = 0

    def nonzero(self) -> dict[str, int]:
        return {
            name: value
            for name, value in vars(self).items()
            if value != 0
        }


@dataclass(frozen=True)
class ControlPlaneSnapshot:
    version: int
    timestamp: str
    sampled_monotonic: float
    config: DesktopConfig
    runtime: RuntimeObservation
    checkpoint: CheckpointSummary
    stale: bool
    health: str
    last_error: str | None
    refresh_attempts: int
    refresh_successes: int
    refresh_errors: int
    read_only: bool
    safety: UiSafetyEvidence


class RuntimeStatusProvider(Protocol):
    def read(self) -> RuntimeObservation: ...

    def close(self) -> None: ...


class CheckpointSummaryProvider(Protocol):
    def read_latest(self) -> CheckpointSummary: ...


class NullCheckpointSummaryProvider:
    def read_latest(self) -> CheckpointSummary:
        return CheckpointSummary(False)


class LatestCheckpointSummaryProvider:
    """Read the newest durable checkpoint without restoring or mutating it."""

    def __init__(self, farm_runs_root: Path) -> None:
        self._root = farm_runs_root.resolve()
        self._cached_path: Path | None = None
        self._cached_mtime_ns: int | None = None
        self._cached = CheckpointSummary(False)

    def read_latest(self) -> CheckpointSummary:
        try:
            candidates = tuple(self._root.glob("*/checkpoint.json"))
            if not candidates:
                self._cached_path = None
                self._cached_mtime_ns = None
                self._cached = CheckpointSummary(False)
                return self._cached
            path = max(candidates, key=lambda value: value.stat().st_mtime_ns)
            mtime_ns = path.stat().st_mtime_ns
            if path == self._cached_path and mtime_ns == self._cached_mtime_ns:
                return self._cached
            payload = load_checkpoint(path)
            self._cached = _checkpoint_summary(path, payload)
            self._cached_path = path
            self._cached_mtime_ns = mtime_ns
            return self._cached
        except (CheckpointError, OSError, ValueError) as exc:
            error_path = str(path) if "path" in locals() else None
            self._cached = CheckpointSummary(
                False,
                path=error_path,
                error=f"{getattr(exc, 'reason', 'CHECKPOINT_READ_ERROR')}: {exc}",
            )
            return self._cached


def _checkpoint_summary(path: Path, payload: CheckpointPayload) -> CheckpointSummary:
    return CheckpointSummary(
        True,
        path=str(path.resolve()),
        schema_version=payload.schema_version,
        farm_run_id=payload.farm_run_id,
        finalized_status=payload.finalized_status,
        completed_matches=payload.completed_matches,
        target_completed_matches=payload.configured_limits[
            "target_completed_matches"
        ],
        wins=payload.wins,
        losses=payload.losses,
        unknown_results=payload.unknown_results,
        updated_at=payload.updated_at,
    )


class StaticUnavailableRuntimeProvider:
    """Explicit offline/demo provider. It performs no process operation."""

    def read(self) -> RuntimeObservation:
        return RuntimeObservation(
            game_detected=False,
            attached=False,
            lifecycle="UNAVAILABLE",
            provider_reason="offline_mode",
        )

    def close(self) -> None:
        return None


class DesktopControlPlane:
    """Thread-safe snapshot owner with no gameplay command surface."""

    def __init__(
        self,
        runtime: RuntimeStatusProvider,
        *,
        checkpoint: CheckpointSummaryProvider | None = None,
        config: DesktopConfig | None = None,
    ) -> None:
        self._runtime = runtime
        self._checkpoint = checkpoint or NullCheckpointSummaryProvider()
        self._lock = threading.RLock()
        self._closed = False
        self._safety = UiSafetyEvidence()
        initial_runtime = RuntimeObservation(
            game_detected=None,
            attached=False,
            lifecycle="UNKNOWN",
            provider_reason="not_polled",
        )
        self._snapshot = ControlPlaneSnapshot(
            version=0,
            timestamp=utc_timestamp(),
            sampled_monotonic=time.monotonic(),
            config=config or DesktopConfig(),
            runtime=initial_runtime,
            checkpoint=CheckpointSummary(False),
            stale=True,
            health="INITIALIZING",
            last_error=None,
            refresh_attempts=0,
            refresh_successes=0,
            refresh_errors=0,
            read_only=True,
            safety=self._safety,
        )

    def snapshot(self) -> ControlPlaneSnapshot:
        with self._lock:
            return self._snapshot

    def update_config(self, config: DesktopConfig) -> ControlPlaneSnapshot:
        if not isinstance(config, DesktopConfig):
            raise TypeError("config must be DesktopConfig")
        with self._lock:
            if self._closed:
                raise RuntimeError("control plane is closed")
            self._snapshot = replace(
                self._snapshot,
                version=self._snapshot.version + 1,
                timestamp=utc_timestamp(),
                sampled_monotonic=time.monotonic(),
                config=config,
            )
            return self._snapshot

    def refresh(self) -> ControlPlaneSnapshot:
        with self._lock:
            if self._closed:
                return self._snapshot
            previous = self._snapshot
            attempts = previous.refresh_attempts + 1
        try:
            runtime = self._runtime.read()
            checkpoint = self._checkpoint.read_latest()
            error = runtime.error or checkpoint.error
            stale = bool(error)
            if runtime.attached:
                health = "STALE" if stale else "OK"
            elif runtime.game_detected is False:
                health = "DETACHED"
            else:
                health = "UNAVAILABLE" if error else "DETACHED"
            with self._lock:
                current = self._snapshot
                self._snapshot = ControlPlaneSnapshot(
                    version=current.version + 1,
                    timestamp=utc_timestamp(),
                    sampled_monotonic=time.monotonic(),
                    config=current.config,
                    runtime=runtime,
                    checkpoint=checkpoint,
                    stale=stale,
                    health=health,
                    last_error=error,
                    refresh_attempts=attempts,
                    refresh_successes=current.refresh_successes + 1,
                    refresh_errors=current.refresh_errors + (1 if error else 0),
                    read_only=True,
                    safety=self._safety,
                )
                return self._snapshot
        except Exception as exc:  # noqa: BLE001 - UI must survive provider faults
            with self._lock:
                current = self._snapshot
                prior_runtime = current.runtime
                # Keep prior presentation for diagnostics, but explicitly mark
                # it detached/stale so it can never look actionable/current.
                stale_runtime = replace(
                    prior_runtime,
                    attached=False,
                    error=f"{type(exc).__name__}: {exc}",
                )
                self._snapshot = ControlPlaneSnapshot(
                    version=current.version + 1,
                    timestamp=utc_timestamp(),
                    sampled_monotonic=time.monotonic(),
                    config=current.config,
                    runtime=stale_runtime,
                    checkpoint=current.checkpoint,
                    stale=True,
                    health="ERROR",
                    last_error=stale_runtime.error,
                    refresh_attempts=attempts,
                    refresh_successes=current.refresh_successes,
                    refresh_errors=current.refresh_errors + 1,
                    read_only=True,
                    safety=self._safety,
                )
                return self._snapshot

    def close(self) -> None:
        with self._lock:
            if self._closed:
                return
            self._closed = True
        self._runtime.close()


class SnapshotPoller:
    """Exactly one reusable worker; no thread is spawned per refresh."""

    def __init__(
        self,
        control_plane: DesktopControlPlane,
        *,
        interval_seconds: float = 2.0,
        event_sink: Callable[[str, ControlPlaneSnapshot | None], None] | None = None,
    ) -> None:
        if not 0.25 <= interval_seconds <= 60.0:
            raise ValueError("interval_seconds must be between 0.25 and 60")
        self._control_plane = control_plane
        self._interval = float(interval_seconds)
        self._event_sink = event_sink
        self._stop = threading.Event()
        self._thread: threading.Thread | None = None
        self._lock = threading.Lock()
        self._starts = 0

    @property
    def starts(self) -> int:
        return self._starts

    @property
    def alive(self) -> bool:
        thread = self._thread
        return bool(thread is not None and thread.is_alive())

    def start(self) -> bool:
        with self._lock:
            if self._thread is not None and self._thread.is_alive():
                return False
            if self._starts > 0:
                return False
            self._starts += 1
            self._stop.clear()
            self._thread = threading.Thread(
                target=self._run,
                name="PokiguardDesktopReadOnlyPoller",
                daemon=True,
            )
            self._thread.start()
            return True

    def _emit(self, event: str, snapshot: ControlPlaneSnapshot | None) -> None:
        if self._event_sink is None:
            return
        try:
            self._event_sink(event, snapshot)
        except Exception:
            # Diagnostics can never terminate the polling boundary.
            return

    def _run(self) -> None:
        self._emit("poller_started", None)
        while not self._stop.is_set():
            snapshot = self._control_plane.refresh()
            self._emit("snapshot_refreshed", snapshot)
            if self._stop.wait(self._interval):
                break
        self._emit("poller_stopped", self._control_plane.snapshot())

    def stop(self, *, timeout_seconds: float = 30.0) -> bool:
        self._stop.set()
        thread = self._thread
        if thread is None:
            return True
        thread.join(timeout_seconds)
        return not thread.is_alive()


__all__ = [
    "CheckpointSummary",
    "ControlPlaneSnapshot",
    "DesktopConfig",
    "DesktopControlPlane",
    "LatestCheckpointSummaryProvider",
    "RuntimeObservation",
    "SnapshotPoller",
    "StaticUnavailableRuntimeProvider",
    "UiSafetyEvidence",
]
