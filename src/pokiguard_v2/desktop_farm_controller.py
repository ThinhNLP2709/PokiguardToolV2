"""Single-owner asynchronous FarmRunner controller for the desktop UI.

The manager is the only Phase 2E.2 component allowed to create a FarmRunner.
UI commands merely latch the already accepted F6/F9 control semantics; they
never touch FarmRun state or send Windows input directly.
"""

from __future__ import annotations

from dataclasses import dataclass, replace
from enum import Enum
from pathlib import Path
import threading
import time
from typing import Any, Callable

from .basic_policy import Intelligence, PolicyConfig
from .boss_entry import FarmTarget
from .controller_lease import AutomationControllerLease
from .farm_checkpoint import CheckpointError, load_checkpoint, validate_for_resume
from .farm_run import FarmRunLimits
from .win32_input import FarmControlHotkeyEdges, foreground_process_window


def _timestamp() -> str:
    from datetime import datetime, timezone

    return datetime.now(timezone.utc).isoformat(timespec="milliseconds").replace(
        "+00:00", "Z"
    )


class DesktopControllerState(str, Enum):
    IDLE = "IDLE"
    STARTING = "STARTING"
    RUNNING = "RUNNING"
    GRACEFUL_STOP_REQUESTED = "GRACEFUL_STOP_REQUESTED"
    EMERGENCY_STOPPING = "EMERGENCY_STOPPING"
    STOPPED = "STOPPED"
    ERROR = "ERROR"


@dataclass(frozen=True)
class ControllerCommandResult:
    accepted: bool
    reason: str
    controller_state: DesktopControllerState
    generation: int
    timestamp: str
    farm_run_id: str | None = None


@dataclass(frozen=True)
class ControllerSafetyEvidence:
    starts: int = 0
    resumes: int = 0
    graceful_stop_commands: int = 0
    emergency_stop_commands: int = 0
    duplicate_start_rejections: int = 0
    stale_command_rejections: int = 0
    wrong_run_command_applications: int = 0
    max_simultaneous_controllers: int = 0
    autonomous_inputs_after_emergency_ack: int = 0


@dataclass(frozen=True)
class DesktopControllerSnapshot:
    generation: int = 0
    state: DesktopControllerState = DesktopControllerState.IDLE
    active: bool = False
    farm_run_id: str | None = None
    continuation_of: str | None = None
    run_state: str | None = None
    phase: str | None = None
    current_match_id: str | None = None
    target_completed_matches: int = 0
    match_attempts: int = 0
    completed_matches: int = 0
    wins: int = 0
    losses: int = 0
    unknown_results: int = 0
    technical_aborts: int = 0
    technical_recoveries: int = 0
    total_gameplay_inputs: int = 0
    total_lobby_inputs: int = 0
    total_postmatch_inputs: int = 0
    total_recovery_inputs: int = 0
    graceful_stop_requested: bool = False
    emergency_stop_acknowledged_at: str | None = None
    checkpoint_path: str | None = None
    last_stop_reason: str | None = None
    last_error: str | None = None
    exit_code: int | None = None
    foreground_handoff: str = "NOT_REQUESTED"
    updated_at: str = ""
    safety: ControllerSafetyEvidence = ControllerSafetyEvidence()


@dataclass(frozen=True)
class ControllerLaunch:
    config: Any
    checkpoint_path: Path | None
    game_pid: int | None = None


Runner = Callable[
    [ControllerLaunch, FarmControlHotkeyEdges, Callable[[Any, str], None]], int
]


class DesktopFarmControllerManager:
    """Own exactly one asynchronous controlled FarmRunner generation."""

    def __init__(
        self,
        project_root: Path,
        *,
        runner: Runner | None = None,
        foreground_handoff: Callable[[int], bool] | None = None,
        reset_evidence: Path | None = None,
        artifacts_root: Path | None = None,
    ) -> None:
        self.project_root = project_root.resolve()
        self.reset_evidence = (
            reset_evidence
            or self.project_root / "logs" / "phase2c2c_reset_capabilities.json"
        ).resolve()
        self.artifacts_root = (
            artifacts_root or self.project_root / "logs" / "farm_runs"
        ).resolve()
        self._runner = runner or self._run_production
        # Production owns the focus handoff. Tests with an injected runner stay
        # hermetic unless they explicitly inject a foreground implementation.
        self._foreground_handoff = foreground_handoff or (
            foreground_process_window if runner is None else (lambda _pid: True)
        )
        self._lock = threading.RLock()
        self._thread: threading.Thread | None = None
        self._edges: FarmControlHotkeyEdges | None = None
        self._game_pid: int | None = None
        self._active_count = 0
        self._snapshot = DesktopControllerSnapshot(updated_at=_timestamp())

    def snapshot(self) -> DesktopControllerSnapshot:
        with self._lock:
            return self._snapshot

    def _result(self, accepted: bool, reason: str) -> ControllerCommandResult:
        snapshot = self._snapshot
        return ControllerCommandResult(
            accepted,
            reason,
            snapshot.state,
            snapshot.generation,
            _timestamp(),
            snapshot.farm_run_id,
        )

    @staticmethod
    def _validate_launch(launch: ControllerLaunch) -> None:
        config = launch.config
        if config.intelligence is not Intelligence.BASIC:
            raise ValueError("REASONING is not implemented")
        PolicyConfig(
            play_style=config.play_style,
            mana_priority=config.mana_priority,
            intelligence=config.intelligence,
        )
        target = FarmTarget(
            config.normalized_boss_id,
            config.normalized_boss_name,
        )
        limits = FarmRunLimits(
            config.target_completed_matches,
            config.max_technical_recoveries,
            config.max_match_attempts,
        )
        if launch.checkpoint_path is None:
            return
        payload = load_checkpoint(launch.checkpoint_path)
        decision = validate_for_resume(
            payload,
            target_boss_id=str(target.boss_id or ""),
            target_boss_name=str(target.boss_name or ""),
            target_completed_matches=limits.target_completed_matches,
            max_technical_recoveries=limits.max_technical_recoveries,
            max_match_attempts=limits.max_match_attempts,
        )
        if not decision.allowed:
            raise CheckpointError(
                decision.reason or "CHECKPOINT_NOT_RESUMABLE",
                "checkpoint is not resumable with the current UI configuration",
            )

    def start(self, config: Any, *, game_pid: int | None = None) -> ControllerCommandResult:
        return self._start(ControllerLaunch(config, None, game_pid))

    def resume(
        self,
        config: Any,
        checkpoint_path: Path,
        *,
        game_pid: int | None = None,
    ) -> ControllerCommandResult:
        return self._start(
            ControllerLaunch(config, checkpoint_path.resolve(), game_pid)
        )

    def _start(self, launch: ControllerLaunch) -> ControllerCommandResult:
        try:
            self._validate_launch(launch)
            if not self.reset_evidence.is_file():
                raise FileNotFoundError(
                    f"reset evidence not found: {self.reset_evidence}"
                )
        except (CheckpointError, FileNotFoundError, TypeError, ValueError) as exc:
            with self._lock:
                return self._result(False, f"INVALID_LAUNCH: {exc}")

        with self._lock:
            if self._snapshot.active:
                safety = replace(
                    self._snapshot.safety,
                    duplicate_start_rejections=(
                        self._snapshot.safety.duplicate_start_rejections + 1
                    ),
                )
                self._snapshot = replace(self._snapshot, safety=safety)
                return self._result(False, "CONTROLLER_ALREADY_ACTIVE")
            generation = self._snapshot.generation + 1
            edges = FarmControlHotkeyEdges()
            safety = replace(
                self._snapshot.safety,
                starts=self._snapshot.safety.starts + 1,
                resumes=(
                    self._snapshot.safety.resumes
                    + (1 if launch.checkpoint_path is not None else 0)
                ),
                max_simultaneous_controllers=max(
                    self._snapshot.safety.max_simultaneous_controllers,
                    self._active_count + 1,
                ),
            )
            self._active_count += 1
            self._edges = edges
            self._game_pid = launch.game_pid
            self._snapshot = DesktopControllerSnapshot(
                generation=generation,
                state=DesktopControllerState.STARTING,
                active=True,
                target_completed_matches=launch.config.target_completed_matches,
                checkpoint_path=(
                    str(launch.checkpoint_path)
                    if launch.checkpoint_path is not None
                    else None
                ),
                foreground_handoff=(
                    "PENDING" if launch.game_pid is not None else "NOT_REQUESTED"
                ),
                updated_at=_timestamp(),
                safety=safety,
            )
            thread = threading.Thread(
                target=self._worker,
                args=(generation, launch, edges),
                name=f"PokiguardFarmController-{generation}",
                daemon=True,
            )
            self._thread = thread
            thread.start()
            return self._result(True, "START_ACCEPTED")

    def _worker(
        self,
        generation: int,
        launch: ControllerLaunch,
        edges: FarmControlHotkeyEdges,
    ) -> None:
        exit_code: int | None = None
        error: str | None = None
        try:
            if launch.game_pid is not None:
                if not self._foreground_handoff(launch.game_pid):
                    raise RuntimeError(
                        f"GAME_FOREGROUND_HANDOFF_FAILED: PID {launch.game_pid}"
                    )
                with self._lock:
                    if self._snapshot.generation != generation:
                        return
                    self._snapshot = replace(
                        self._snapshot,
                        foreground_handoff="SUCCEEDED",
                        updated_at=_timestamp(),
                    )
            with AutomationControllerLease(
                self.project_root / "logs" / ".automation_controller.lock"
            ):
                exit_code = self._runner(
                    launch,
                    edges,
                    lambda snapshot, phase: self._observe(
                        generation, snapshot, phase
                    ),
                )
        except Exception as exc:  # noqa: BLE001 - controller must publish failure
            error = f"{type(exc).__name__}: {exc}"
        with self._lock:
            if self._snapshot.generation != generation:
                return
            self._active_count = max(0, self._active_count - 1)
            self._game_pid = None
            safety = replace(
                self._snapshot.safety,
                autonomous_inputs_after_emergency_ack=(
                    edges.authorized_operations_after_emergency_ack
                ),
            )
            self._snapshot = replace(
                self._snapshot,
                state=(
                    DesktopControllerState.ERROR
                    if error is not None
                    else DesktopControllerState.STOPPED
                ),
                active=False,
                exit_code=exit_code,
                last_error=error,
                emergency_stop_acknowledged_at=(
                    self._snapshot.emergency_stop_acknowledged_at
                    or (
                        _timestamp()
                        if edges.emergency_ack_monotonic is not None
                        else None
                    )
                ),
                updated_at=_timestamp(),
                safety=safety,
            )

    def _observe(self, generation: int, source: Any, phase: str) -> None:
        """Immediately copy backend primitives; never retain mutable run data."""

        with self._lock:
            if generation != self._snapshot.generation:
                return
            state = self._snapshot.state
            if state is DesktopControllerState.STARTING:
                state = DesktopControllerState.RUNNING
            self._snapshot = replace(
                self._snapshot,
                state=state,
                farm_run_id=str(source.farm_run_id),
                continuation_of=source.continuation_of,
                run_state=source.state.value,
                phase=phase,
                current_match_id=source.current_match_id,
                target_completed_matches=source.limits.target_completed_matches,
                match_attempts=int(source.match_attempts),
                completed_matches=int(source.completed_matches),
                wins=int(source.wins),
                losses=int(source.losses),
                unknown_results=int(source.unknown_results),
                technical_aborts=int(source.technical_aborts),
                technical_recoveries=int(source.technical_recoveries),
                total_gameplay_inputs=int(source.total_gameplay_inputs),
                total_lobby_inputs=int(source.total_lobby_inputs),
                total_postmatch_inputs=int(source.total_postmatch_inputs),
                total_recovery_inputs=int(source.total_recovery_inputs),
                graceful_stop_requested=(
                    source.graceful_stop_requested_at is not None
                ),
                checkpoint_path=str(
                    self.artifacts_root / str(source.farm_run_id) / "checkpoint.json"
                ),
                last_stop_reason=(
                    source.stop_reason.value if source.stop_reason is not None else None
                ),
                updated_at=_timestamp(),
            )

    def request_graceful_stop(self, generation: int) -> ControllerCommandResult:
        with self._lock:
            if generation != self._snapshot.generation:
                safety = replace(
                    self._snapshot.safety,
                    stale_command_rejections=(
                        self._snapshot.safety.stale_command_rejections + 1
                    ),
                )
                self._snapshot = replace(self._snapshot, safety=safety)
                return self._result(False, "STALE_CONTROLLER_GENERATION")
            if not self._snapshot.active or self._edges is None:
                return self._result(False, "NO_ACTIVE_CONTROLLER")
            if self._snapshot.graceful_stop_requested:
                return self._result(True, "GRACEFUL_STOP_ALREADY_REQUESTED")
            self._edges.request_graceful_stop()
            safety = replace(
                self._snapshot.safety,
                graceful_stop_commands=self._snapshot.safety.graceful_stop_commands
                + 1,
            )
            self._snapshot = replace(
                self._snapshot,
                state=DesktopControllerState.GRACEFUL_STOP_REQUESTED,
                graceful_stop_requested=True,
                updated_at=_timestamp(),
                safety=safety,
            )
            game_pid = self._game_pid

        # Clicking the desktop UI temporarily owns foreground. A graceful stop
        # still has to finish the current combat, so hand focus straight back
        # within the same short command submission. Emergency Stop deliberately
        # does not do this because it revokes all future automation authority.
        focused = bool(
            game_pid is None or self._foreground_handoff(game_pid)
        )
        with self._lock:
            if generation != self._snapshot.generation:
                return self._result(False, "STALE_CONTROLLER_GENERATION")
            if not focused:
                self._snapshot = replace(
                    self._snapshot,
                    last_error="GAME_FOREGROUND_HANDOFF_FAILED_AFTER_GRACEFUL_STOP",
                    updated_at=_timestamp(),
                )
            return self._result(
                True,
                (
                    "GRACEFUL_STOP_ACCEPTED"
                    if focused
                    else "GRACEFUL_STOP_ACCEPTED_FOREGROUND_FAILED"
                ),
            )

    def emergency_stop(self, generation: int) -> ControllerCommandResult:
        with self._lock:
            if generation != self._snapshot.generation:
                safety = replace(
                    self._snapshot.safety,
                    stale_command_rejections=(
                        self._snapshot.safety.stale_command_rejections + 1
                    ),
                )
                self._snapshot = replace(self._snapshot, safety=safety)
                return self._result(False, "STALE_CONTROLLER_GENERATION")
            if not self._snapshot.active or self._edges is None:
                return self._result(False, "NO_ACTIVE_CONTROLLER")
            if self._snapshot.state is DesktopControllerState.EMERGENCY_STOPPING:
                return self._result(True, "EMERGENCY_STOP_ALREADY_ACKNOWLEDGED")
            edges = self._edges

        # This may briefly wait for one already-started atomic input to finish.
        # It never waits for the FarmRunner thread and therefore does not freeze
        # the Tk event loop for a whole controller lifecycle.
        edges.request_emergency_stop()
        with self._lock:
            if generation != self._snapshot.generation:
                return self._result(False, "STALE_CONTROLLER_GENERATION")
            safety = replace(
                self._snapshot.safety,
                emergency_stop_commands=self._snapshot.safety.emergency_stop_commands
                + 1,
            )
            self._snapshot = replace(
                self._snapshot,
                state=(
                    DesktopControllerState.EMERGENCY_STOPPING
                    if self._snapshot.active
                    else self._snapshot.state
                ),
                emergency_stop_acknowledged_at=_timestamp(),
                updated_at=_timestamp(),
                safety=safety,
            )
            return self._result(True, "EMERGENCY_STOP_ACKNOWLEDGED")

    def wait(self, timeout_seconds: float) -> bool:
        thread = self._thread
        if thread is None:
            return True
        thread.join(timeout_seconds)
        return not thread.is_alive()

    def _run_production(
        self,
        launch: ControllerLaunch,
        edges: FarmControlHotkeyEdges,
        observer: Callable[[Any, str], None],
    ) -> int:
        from tools import farm_run as farm_run_tool

        config = launch.config
        argv = [
            "--stage-e2-ui",
            "--boss-id",
            config.normalized_boss_id or "",
            "--target-matches",
            str(config.target_completed_matches),
            "--max-technical-recoveries",
            str(config.max_technical_recoveries),
            "--max-match-attempts",
            str(config.max_match_attempts),
            "--play-style",
            config.play_style.value,
            "--mana-priority",
            config.mana_priority.value,
            "--reset-evidence",
            str(self.reset_evidence),
            "--artifacts",
            str(self.artifacts_root),
        ]
        if config.normalized_boss_id is None:
            argv[1:3] = ["--boss-name", config.normalized_boss_name or ""]
        argv.extend(
            [
                "--resume",
                str(launch.checkpoint_path),
            ]
            if launch.checkpoint_path is not None
            else ["--new-run"]
        )
        args = farm_run_tool.build_parser().parse_args(argv)
        # The CLI target flags are mutually exclusive for humans, but the UI's
        # canonical target retains both identity components for checkpoint
        # equality and exact runtime resolution.
        args.boss_id = config.normalized_boss_id
        args.boss_name = config.normalized_boss_name
        return farm_run_tool.run(args, control_edges=edges, observer=observer)


__all__ = [
    "ControllerCommandResult",
    "ControllerSafetyEvidence",
    "DesktopControllerSnapshot",
    "DesktopControllerState",
    "DesktopFarmControllerManager",
]
