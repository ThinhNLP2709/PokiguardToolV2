"""Authoritative application boundary for the desktop control UI.

The desktop view never owns a FarmRun, input capability, or Win32 input
backend. It consumes immutable snapshots produced by one bounded polling
worker and submits short commands that are revalidated at this boundary.
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
from .desktop_farm_controller import (
    ControllerCommandResult,
    DesktopControllerSnapshot,
    DesktopControllerState,
    DesktopFarmControllerManager,
)
from .win32_input import BoardInputMode


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
    # The desktop draft may be target-unbound while idle.  Start/Resume pins
    # the exact target proven by the current Chinh Phuc room before handing an
    # immutable config to FarmRunner.  This avoids a product dependency on a
    # user-known or hard-coded pet ID.
    boss_id: str | None = None
    boss_name: str | None = None
    target_completed_matches: int = 3
    max_technical_recoveries: int = 1
    max_match_attempts: int = 5
    # Keep this appended so older positional DesktopConfig construction stays
    # source-compatible. The legacy two-click path remains selectable.
    board_input_mode: BoardInputMode = BoardInputMode.DRAG

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
        BoardInputMode(self.board_input_mode)
        if self.normalized_boss_id is not None or self.normalized_boss_name is not None:
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

    def with_target(
        self, boss_id: str | None, boss_name: str | None
    ) -> "DesktopConfig":
        """Return a validated run draft pinned to one runtime-proven target."""

        return replace(self, boss_id=boss_id, boss_name=boss_name)

    def without_target(self) -> "DesktopConfig":
        """Drop the farm-session pet identity while retaining user policy."""

        return replace(self, boss_id=None, boss_name=None)

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
        board_input_mode: str = BoardInputMode.DRAG.value,
    ) -> "DesktopConfig":
        return cls(
            play_style=PlayStyle(play_style),
            mana_priority=ManaPriority(mana_priority),
            intelligence=Intelligence(intelligence),
            board_input_mode=BoardInputMode(board_input_mode),
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
    target_candidates: tuple[tuple[str | None, str | None], ...] = ()
    lobby_branch: str | None = None
    current_room_id: str | None = None


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
    last_safe_lifecycle: str | None = None
    stop_request_state: str | None = None
    stop_reason: str | None = None
    updated_at: float | None = None
    error: str | None = None

    @property
    def resumable_candidate(self) -> bool:
        """Cheap UI hint; canonical resume validation remains in FarmRunner."""

        graceful_lobby_stop = bool(
            self.finalized_status == "STOPPED_GRACEFULLY"
            and self.last_safe_lifecycle == "BOSS_LOBBY"
            and self.stop_reason == "STOPPED_GRACEFULLY"
            and self.stop_request_state == "STOPPED_AT_LOBBY"
        )
        interrupted_at_durable_lobby_boundary = bool(
            self.finalized_status is None
            and self.last_safe_lifecycle == "BOSS_LOBBY"
            and self.stop_reason is None
            and self.stop_request_state == "RUNNING"
        )
        recoverable_legacy_technical_stop = bool(
            self.finalized_status == "SAFE_STOP"
            and self.last_safe_lifecycle == "BOSS_LOBBY"
            and self.stop_reason in {"COMBAT_SAFE_STOP", "RECOVERY_LIMIT_REACHED"}
            and self.stop_request_state == "RUNNING"
        )
        return bool(
            self.available
            and self.path
            and self.completed_matches is not None
            and self.target_completed_matches is not None
            and self.completed_matches < self.target_completed_matches
            and (
                graceful_lobby_stop
                or interrupted_at_durable_lobby_boundary
                or recoverable_legacy_technical_stop
            )
        )


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
class CommandAvailability:
    actionable: bool = False
    reason: str = "INITIALIZING"


@dataclass(frozen=True)
class ControlAvailability:
    """Backend-derived operator guidance; never an authorization boundary."""

    start: CommandAvailability = CommandAvailability()
    resume: CommandAvailability = CommandAvailability()
    graceful_stop: CommandAvailability = CommandAvailability()
    emergency_stop: CommandAvailability = CommandAvailability()
    config_editable: bool = True


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
    controller: DesktopControllerSnapshot
    controls: ControlAvailability = ControlAvailability()


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
        last_safe_lifecycle=payload.last_safe_lifecycle,
        stop_request_state=payload.stop_request_state,
        stop_reason=payload.stop_reason,
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
    """Thread-safe UI application boundary and single command gateway."""

    def __init__(
        self,
        runtime: RuntimeStatusProvider,
        *,
        checkpoint: CheckpointSummaryProvider | None = None,
        config: DesktopConfig | None = None,
        controller: DesktopFarmControllerManager | None = None,
    ) -> None:
        self._runtime = runtime
        self._checkpoint = checkpoint or NullCheckpointSummaryProvider()
        self._controller = controller
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
            controller=(
                controller.snapshot()
                if controller is not None
                else DesktopControllerSnapshot(updated_at=utc_timestamp())
            ),
        )
        self._refresh_controls_locked()

    @staticmethod
    def _ui_safety(controller: DesktopControllerSnapshot) -> UiSafetyEvidence:
        evidence = controller.safety
        return UiSafetyEvidence(
            farm_runner_starts=evidence.starts,
            gameplay_windows_inputs=(
                controller.total_gameplay_inputs
                + controller.total_postmatch_inputs
                + controller.total_recovery_inputs
            ),
            boss_entry_commands=controller.total_lobby_inputs,
            graceful_stop_commands=evidence.graceful_stop_commands,
            emergency_stop_commands=evidence.emergency_stop_commands,
            checkpoint_resume_commands=evidence.resumes,
        )

    def _controller_snapshot(self) -> DesktopControllerSnapshot:
        if self._controller is None:
            return self._snapshot.controller
        return self._controller.snapshot()

    def _publish_controller(self) -> None:
        controller = self._controller_snapshot()
        config = self._snapshot.config
        if self._snapshot.controller.active and not controller.active:
            config = config.without_target()
        self._safety = self._ui_safety(controller)
        self._snapshot = replace(
            self._snapshot,
            version=self._snapshot.version + 1,
            timestamp=utc_timestamp(),
            sampled_monotonic=time.monotonic(),
            controller=controller,
            config=config,
            safety=self._safety,
        )

        self._refresh_controls_locked()

    def _runtime_command_preflight(self, snapshot: ControlPlaneSnapshot) -> str | None:
        runtime = snapshot.runtime
        if self._closed:
            return "CONTROL_PLANE_CLOSED"
        if self._controller is None:
            return "CONTROLLER_UNAVAILABLE"
        if snapshot.controller.active:
            return "CONTROLLER_ALREADY_ACTIVE"
        if snapshot.stale:
            return "STALE_RUNTIME_SNAPSHOT"
        if runtime.game_detected is False:
            return "GAME_NOT_DETECTED"
        if not runtime.attached:
            return "GAME_NOT_ATTACHED"
        architecture = (runtime.architecture or "").strip().lower()
        if architecture not in {"x64", "amd64", "x86_64"}:
            return f"UNSUPPORTED_ARCHITECTURE:{runtime.architecture or 'UNKNOWN'}"
        if snapshot.health != "OK":
            return f"BACKEND_NOT_HEALTHY:{snapshot.health}"
        if runtime.lifecycle != "BOSS_LOBBY":
            return f"START_REQUIRES_BOSS_LOBBY:{runtime.lifecycle}"
        return None

    @staticmethod
    def _pin_current_room_target(
        snapshot: ControlPlaneSnapshot,
    ) -> tuple[DesktopConfig | None, str | None]:
        """Pin the selected target only from an exact current boss room.

        A WORLD_BOSS_LIST observation is deliberately insufficient even when
        it exposes the same pet in its candidate list.  Selecting a map item
        is a distinct automation action and must never be inferred by Start.
        """

        runtime = snapshot.runtime
        if runtime.lobby_branch != "CHINH_PHUC_ROOM":
            return None, "CURRENT_BOSS_ROOM_NOT_PROVEN"
        target_id = runtime.target_id.strip() if runtime.target_id else None
        target_name = runtime.target_name.strip() if runtime.target_name else None
        if target_id is None:
            return None, "CURRENT_ROOM_PET_ID_NOT_PROVEN"
        try:
            if int(target_id) <= 0:
                raise ValueError("pet ID must be positive")
        except ValueError:
            return None, "CURRENT_ROOM_PET_ID_INVALID"

        candidates = {
            (
                candidate_id.strip() if candidate_id else None,
                candidate_name.strip() if candidate_name else None,
            )
            for candidate_id, candidate_name in runtime.target_candidates
        }
        if candidates and (target_id, target_name) not in candidates:
            return None, "CURRENT_ROOM_TARGET_AMBIGUOUS"
        try:
            pinned = snapshot.config.with_target(target_id, target_name)
            FarmTarget(pinned.normalized_boss_id, pinned.normalized_boss_name)
        except (TypeError, ValueError):
            return None, "CURRENT_ROOM_TARGET_INVALID"
        return pinned, None

    def _start_preflight(self, snapshot: ControlPlaneSnapshot) -> str | None:
        reason = self._runtime_command_preflight(snapshot)
        if reason is not None:
            return reason
        pinned, reason = self._pin_current_room_target(snapshot)
        if reason is not None:
            return reason
        assert pinned is not None
        assert self._controller is not None
        return self._controller.launch_rejection_reason(pinned)

    def _resume_preflight(self, snapshot: ControlPlaneSnapshot) -> str | None:
        reason = self._runtime_command_preflight(snapshot)
        if reason is not None:
            return reason
        pinned, reason = self._pin_current_room_target(snapshot)
        if reason is not None:
            return reason
        assert pinned is not None
        checkpoint = snapshot.checkpoint
        if not checkpoint.available or checkpoint.path is None:
            return checkpoint.error or "NO_RESUMABLE_CHECKPOINT"
        assert self._controller is not None
        return self._controller.launch_rejection_reason(
            pinned,
            Path(checkpoint.path),
        )

    @staticmethod
    def _command_availability(reason: str | None) -> CommandAvailability:
        return CommandAvailability(reason is None, reason or "AVAILABLE")

    def _calculate_controls(
        self, snapshot: ControlPlaneSnapshot
    ) -> ControlAvailability:
        controller = snapshot.controller
        if not controller.active:
            graceful_reason = "NO_ACTIVE_CONTROLLER"
            emergency_reason = "NO_ACTIVE_CONTROLLER"
        elif controller.state is DesktopControllerState.EMERGENCY_STOPPING:
            graceful_reason = "EMERGENCY_STOP_ACKNOWLEDGED"
            emergency_reason = "EMERGENCY_STOP_ALREADY_ACKNOWLEDGED"
        else:
            graceful_reason = (
                "GRACEFUL_STOP_PENDING"
                if controller.graceful_stop_requested
                else None
            )
            # Emergency Stop deliberately remains available while graceful
            # stop is pending.
            emergency_reason = None
        return ControlAvailability(
            start=self._command_availability(self._start_preflight(snapshot)),
            resume=self._command_availability(self._resume_preflight(snapshot)),
            graceful_stop=self._command_availability(graceful_reason),
            emergency_stop=self._command_availability(emergency_reason),
            config_editable=not controller.active and not self._closed,
        )

    def _refresh_controls_locked(self) -> None:
        self._snapshot = replace(
            self._snapshot,
            controls=self._calculate_controls(self._snapshot),
        )

    def _rejected_command(self, reason: str) -> ControllerCommandResult:
        controller = self._controller_snapshot()
        return ControllerCommandResult(
            False,
            reason,
            controller.state,
            controller.generation,
            utc_timestamp(),
            controller.farm_run_id,
        )

    def start_farm(self) -> ControllerCommandResult:
        with self._lock:
            if self._closed:
                return self._rejected_command("CONTROL_PLANE_CLOSED")
            reason = self._start_preflight(self._snapshot)
            if reason is not None:
                return self._rejected_command(reason)
            pinned, reason = self._pin_current_room_target(self._snapshot)
            if reason is not None or pinned is None:
                return self._rejected_command(
                    reason or "CURRENT_ROOM_TARGET_NOT_PROVEN"
                )
            self._snapshot = replace(self._snapshot, config=pinned)
            assert self._controller is not None
            result = self._controller.start(
                pinned,
                game_pid=self._snapshot.runtime.pid,
            )
            self._publish_controller()
            return result

    def resume_from_checkpoint(self) -> ControllerCommandResult:
        with self._lock:
            if self._closed:
                return self._rejected_command("CONTROL_PLANE_CLOSED")
            reason = self._resume_preflight(self._snapshot)
            if reason is not None:
                return self._rejected_command(reason)
            checkpoint = self._snapshot.checkpoint
            assert checkpoint.path is not None
            pinned, target_reason = self._pin_current_room_target(self._snapshot)
            if target_reason is not None or pinned is None:
                return self._rejected_command(
                    target_reason or "CURRENT_ROOM_TARGET_NOT_PROVEN"
                )
            self._snapshot = replace(self._snapshot, config=pinned)
            assert self._controller is not None
            result = self._controller.resume(
                pinned,
                Path(checkpoint.path),
                game_pid=self._snapshot.runtime.pid,
            )
            self._publish_controller()
            return result

    def request_graceful_stop(self, generation: int) -> ControllerCommandResult:
        with self._lock:
            if self._controller is None:
                return self._rejected_command("CONTROLLER_UNAVAILABLE")
            result = self._controller.request_graceful_stop(generation)
            self._publish_controller()
            return result

    def restore_game_foreground(self, generation: int) -> ControllerCommandResult:
        with self._lock:
            if self._controller is None:
                return self._rejected_command("CONTROLLER_UNAVAILABLE")
            result = self._controller.restore_game_foreground(generation)
            self._publish_controller()
            return result

    def emergency_stop(self, generation: int) -> ControllerCommandResult:
        with self._lock:
            if self._controller is None:
                return self._rejected_command("CONTROLLER_UNAVAILABLE")
            result = self._controller.emergency_stop(generation)
            self._publish_controller()
            return result

    def snapshot(self) -> ControlPlaneSnapshot:
        with self._lock:
            return self._snapshot

    def update_config(self, config: DesktopConfig) -> ControlPlaneSnapshot:
        if not isinstance(config, DesktopConfig):
            raise TypeError("config must be DesktopConfig")
        with self._lock:
            if self._closed:
                raise RuntimeError("control plane is closed")
            if self._controller_snapshot().active:
                raise RuntimeError("CONFIG_LOCKED_CONTROLLER_ACTIVE")
            self._snapshot = replace(
                self._snapshot,
                version=self._snapshot.version + 1,
                timestamp=utc_timestamp(),
                sampled_monotonic=time.monotonic(),
                config=config,
            )
            self._refresh_controls_locked()
            return self._snapshot

    def refresh(self) -> ControlPlaneSnapshot:
        with self._lock:
            if self._closed:
                return self._snapshot
            previous = self._snapshot
            attempts = previous.refresh_attempts + 1
        try:
            controller = self._controller_snapshot()
            if controller.active:
                lifecycle_map = {
                    "WAIT_INITIAL_BOSS_LOBBY": "BOSS_LOBBY",
                    "RESOLVE_TARGET": "BOSS_LOBBY",
                    "ENTRY_READY": "ENTERING_COMBAT",
                    "ENTRY_PENDING": "ENTERING_COMBAT",
                    "WAIT_OPENING": "ENTERING_COMBAT",
                    "COMBAT_ACTIVE": "ACTIVE_COMBAT",
                    "WAIT_POSTMATCH": "POSTMATCH",
                    "WAIT_BOSS_LOBBY": "RETURNING_TO_LOBBY",
                    "RECOVERY_PENDING": "ACTIVE_COMBAT",
                    "RECOVERY_ACTIVE": "ACTIVE_COMBAT",
                    "RECOVERY_OPENING_READY": "ENTERING_COMBAT",
                }
                runtime = replace(
                    previous.runtime,
                    lifecycle=lifecycle_map.get(
                        controller.run_state or "",
                        previous.runtime.lifecycle,
                    ),
                    match_id=controller.current_match_id,
                    provider_reason="farm_controller_snapshot",
                    error=None,
                )
            else:
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
                controller = self._controller_snapshot()
                config = current.config
                if current.controller.active and not controller.active:
                    config = config.without_target()
                self._safety = self._ui_safety(controller)
                self._snapshot = ControlPlaneSnapshot(
                    version=current.version + 1,
                    timestamp=utc_timestamp(),
                    sampled_monotonic=time.monotonic(),
                    config=config,
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
                    controller=controller,
                )
                self._refresh_controls_locked()
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
                    controller=self._controller_snapshot(),
                )
                self._refresh_controls_locked()
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
    "CommandAvailability",
    "ControlAvailability",
    "ControlPlaneSnapshot",
    "DesktopConfig",
    "DesktopControlPlane",
    "LatestCheckpointSummaryProvider",
    "RuntimeObservation",
    "SnapshotPoller",
    "StaticUnavailableRuntimeProvider",
    "UiSafetyEvidence",
]
