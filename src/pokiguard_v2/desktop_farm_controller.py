"""Single-owner asynchronous FarmRunner controller for the desktop UI.

The manager is the only desktop component allowed to create a FarmRunner.
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

from .basic_policy import Intelligence, PlayStyle
from .reasoning_settings import AIStatus
from .pet_configuration import FarmPolicyUnavailable
from .boss_entry import FarmTarget
from .controller_lease import AutomationControllerLease
from .farm_checkpoint import CheckpointError, load_checkpoint, validate_for_resume
from .farm_run import FarmRunLimits
from .input_delivery import InputDeliveryMode
from .game_window_size import GameWindowSizeProfile
from .win32_input import (
    BoardInputMode,
    FarmControlHotkeyEdges,
    foreground_process_window,
    prepare_process_window,
)


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
    last_stop_detail: str | None = None
    last_error: str | None = None
    exit_code: int | None = None
    foreground_handoff: str = "NOT_REQUESTED"
    # One local server turn consumes one farm energy. EVOLVE followed by SWAP
    # on the same turn is intentionally counted once.
    completed_match_turns: tuple[tuple[int, int], ...] = ()
    current_match_turns: int = 0
    total_energy_used: int = 0
    updated_at: str = ""
    ai_status: AIStatus = AIStatus()
    safety: ControllerSafetyEvidence = ControllerSafetyEvidence()


@dataclass(frozen=True)
class ControllerLaunch:
    config: Any
    checkpoint_path: Path | None
    game_pid: int | None = None
    expected_match_id: str | None = None


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
        window_prepare: Callable[[int, int, int], bool] | None = None,
        reset_evidence: Path | None = None,
        artifacts_root: Path | None = None,
        data_root: Path | None = None,
        reasoning_session_factory: Callable | None = None,
        calibration_gate: Any | None = None,
    ) -> None:
        self.project_root = project_root.resolve()
        self._reasoning_session_factory = reasoning_session_factory
        self._calibration_gate = calibration_gate
        self._ui_reasoning_session = None
        self.data_root = (data_root or self.project_root).resolve()
        self.reset_evidence = (
            reset_evidence
            or self.data_root / "logs" / "phase2c2c_reset_capabilities.json"
        ).resolve()
        self.artifacts_root = (
            artifacts_root or self.data_root / "logs" / "farm_runs"
        ).resolve()
        self._runner = runner or self._run_production
        # Production owns the focus handoff. Tests with an injected runner stay
        # hermetic unless they explicitly inject a foreground implementation.
        injected_focus = foreground_handoff or (lambda _pid: True)
        self._foreground_handoff = (
            foreground_process_window if runner is None and foreground_handoff is None
            else injected_focus
        )
        # Desktop Start owns one stronger, zero-input preflight: restore the
        # exact game PID and normalize its client to the selected profile
        # calibration before FarmRunner binds the HWND.  Tests with an injected
        # runner retain their historical foreground callback unless they opt in
        # to a distinct preparation implementation.
        if window_prepare is not None:
            self._window_prepare = window_prepare
        elif runner is None:
            self._window_prepare = lambda pid, width, height: prepare_process_window(
                pid,
                client_width=width,
                client_height=height,
            )
        else:
            self._window_prepare = lambda pid, _width, _height: injected_focus(pid)
        self._lock = threading.RLock()
        self._thread: threading.Thread | None = None
        self._edges: FarmControlHotkeyEdges | None = None
        self._game_pid: int | None = None
        self._active_count = 0
        self._snapshot = DesktopControllerSnapshot(updated_at=_timestamp())

    def snapshot(self) -> DesktopControllerSnapshot:
        with self._lock:
            return self._snapshot

    def prepare_game_window(
        self,
        pid: int,
        profile: GameWindowSizeProfile,
    ) -> bool:
        """Apply one validated client-size profile through controller authority."""

        if not isinstance(pid, int) or pid <= 0:
            raise ValueError("pid must be a positive integer")
        if not isinstance(profile, GameWindowSizeProfile):
            raise TypeError("profile must be GameWindowSizeProfile")
        with self._lock:
            if self._snapshot.active:
                raise RuntimeError("CONFIG_LOCKED_CONTROLLER_ACTIVE")
        return bool(self._window_prepare(pid, profile.width, profile.height))

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
        config.gameplay_config.require_farm_policy()
        BoardInputMode(config.board_input_mode)
        InputDeliveryMode(config.input_delivery_mode)
        if config.play_style is PlayStyle.DINOSAUR:
            if launch.checkpoint_path is not None:
                raise ValueError("DINOSAUR_CURRENT_COMBAT_ONLY")
            if not launch.expected_match_id or not launch.expected_match_id.strip():
                raise ValueError("CURRENT_COMBAT_MATCH_ID_NOT_PROVEN")
            if config.target_completed_matches != 1 or config.max_match_attempts != 1:
                raise ValueError("DINOSAUR_CURRENT_COMBAT_ONLY")
            return
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
            gameplay_config=config.gameplay_config,
            input_delivery_mode=config.input_delivery_mode,
        )
        if not decision.allowed:
            raise CheckpointError(
                decision.reason or "CHECKPOINT_NOT_RESUMABLE",
                "checkpoint is not resumable with the current UI configuration",
            )

    def start(self, config: Any, *, game_pid: int | None = None,
              expected_match_id: str | None = None) -> ControllerCommandResult:
        return self._start(ControllerLaunch(config, None, game_pid, expected_match_id))

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

    def launch_rejection_reason(
        self,
        config: Any,
        checkpoint_path: Path | None = None,
        *, expected_match_id: str | None = None,
    ) -> str | None:
        """Run the same canonical launch validation used by the command path."""

        try:
            self._validate_launch(
                ControllerLaunch(
                    config,
                    checkpoint_path.resolve() if checkpoint_path is not None else None,
                    expected_match_id=expected_match_id,
                )
            )
            if not self.reset_evidence.is_file():
                raise FileNotFoundError(
                    f"reset evidence not found: {self.reset_evidence}"
                )
            if self._calibration_gate is not None:
                self._calibration_gate.validate_launch(config, checkpoint_path)
        except (FarmPolicyUnavailable, CheckpointError) as exc:
            return exc.reason
        except (FileNotFoundError, TypeError, ValueError) as exc:
            return f"INVALID_LAUNCH: {exc}"
        return None

    def _start(self, launch: ControllerLaunch) -> ControllerCommandResult:
        reason = self.launch_rejection_reason(
            launch.config,
            launch.checkpoint_path,
            expected_match_id=launch.expected_match_id,
        )
        if reason is not None:
            with self._lock:
                return self._result(False, reason)

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
            if self._calibration_gate is not None:
                try:
                    self._calibration_gate.claim(launch.config, launch.checkpoint_path)
                except Exception as exc:
                    return self._result(False, f"CALIBRATION_REJECTED: {type(exc).__name__}: {exc}")
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
                ai_status=(AIStatus("WAITING", "WAITING_COMBAT_SETUP")
                           if launch.config.ai.shadow_enabled else AIStatus()),
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
                window_width = launch.config.game_window_size_profile.width
                window_height = launch.config.game_window_size_profile.height
                if not self._window_prepare(
                    launch.game_pid,
                    window_width,
                    window_height,
                ):
                    raise RuntimeError(
                        f"GAME_WINDOW_PREPARATION_FAILED: PID {launch.game_pid}; "
                        "expected foreground client "
                        f"{window_width}x{window_height}"
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
                self.data_root / "logs" / ".automation_controller.lock"
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
                ai_status=(replace(self._snapshot.ai_status, state="STOPPED",selection_authority=False)
                           if launch.config.ai.shadow_enabled or launch.config.ai.reasoning_enabled else AIStatus()),
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

        if phase == "AI_STATUS":
            # Observer-thread display update only. Never wait behind a UI/Stop lock.
            if type(source) is not AIStatus or not self._lock.acquire(False):
                return False
            try:
                if generation != self._snapshot.generation or not self._snapshot.active:
                    return False
                session = self._ui_reasoning_session
                if source.selection_authority and (session is None or
                        source.config_id != session.intent.config_id or
                        not source.reason.startswith('UI_REASONING_')):
                    return False
                if source.observation < self._snapshot.ai_status.observation:
                    return False
                self._snapshot = replace(self._snapshot, ai_status=source)
                return True
            finally:
                self._lock.release()

        with self._lock:
            if generation != self._snapshot.generation:
                return
            state = self._snapshot.state
            if state is DesktopControllerState.STARTING:
                state = DesktopControllerState.RUNNING
            source_attempts = tuple(getattr(source, "attempts", ()))
            completed_match_turns = tuple(
                (int(attempt.attempt_index), int(attempt.local_turns))
                for attempt in source_attempts
                if attempt.end_timestamp is not None
                and attempt.result.value in {"WIN", "LOSS", "UNKNOWN"}
            )
            current_attempt = next(
                (
                    attempt
                    for attempt in reversed(source_attempts)
                    if attempt.end_timestamp is None
                    and source.current_match_id is not None
                ),
                None,
            )
            current_match_turns = (
                int(current_attempt.local_turns)
                if current_attempt is not None
                else 0
            )
            stop_detail = None
            if source.stop_reason is not None:
                for event in reversed(getattr(source, "events", ())):
                    entry = event.detail.get("entry", {})
                    if isinstance(entry, dict) and entry.get("stopReason"):
                        stop_detail = str(entry["stopReason"])
                        break
                    if (getattr(getattr(source, "gameplay_config", None), "play_style", None)
                            is PlayStyle.DINOSAUR and isinstance(event.detail.get("detail"), str)):
                        stop_detail = event.detail["detail"]
                        break
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
                ) if getattr(getattr(source, "gameplay_config", None), "play_style", None)
                    is not PlayStyle.DINOSAUR else None,
                last_stop_reason=(
                    source.stop_reason.value if source.stop_reason is not None else None
                ),
                last_stop_detail=stop_detail,
                completed_match_turns=completed_match_turns,
                current_match_turns=current_match_turns,
                total_energy_used=sum(
                    turns for _attempt_index, turns in completed_match_turns
                ) + current_match_turns,
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

    def restore_game_foreground(self, generation: int) -> ControllerCommandResult:
        """Return focus after opening an active-run operator dialog.

        This is deliberately not an input capability and does not alter the
        FarmRun or its stop edges. It only prevents a desktop modal from
        consuming the remainder of the current local turn while the operator
        chooses Cancel, graceful close, or emergency close.
        """

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
            if not self._snapshot.active:
                return self._result(False, "NO_ACTIVE_CONTROLLER")
            game_pid = self._game_pid
            if game_pid is None:
                return self._result(False, "GAME_PID_UNAVAILABLE")

        focused = bool(self._foreground_handoff(game_pid))
        with self._lock:
            if generation != self._snapshot.generation:
                return self._result(False, "STALE_CONTROLLER_GENERATION")
            self._snapshot = replace(
                self._snapshot,
                foreground_handoff=("SUCCEEDED" if focused else "FAILED"),
                last_error=(
                    self._snapshot.last_error
                    if focused
                    else "GAME_FOREGROUND_HANDOFF_FAILED_FOR_CLOSE_DIALOG"
                ),
                updated_at=_timestamp(),
            )
            return self._result(
                focused,
                (
                    "GAME_FOREGROUND_RESTORED_FOR_CLOSE_DIALOG"
                    if focused
                    else "GAME_FOREGROUND_HANDOFF_FAILED_FOR_CLOSE_DIALOG"
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

    def wait_reasoning_cleanup(self, timeout_seconds: float = 5.0) -> bool:
        """Background UI shutdown only; Stop/action paths never call this."""
        session = self._ui_reasoning_session
        return session is None or session.wait_closed(timeout_seconds)

    def _run_production(
        self,
        launch: ControllerLaunch,
        edges: FarmControlHotkeyEdges,
        observer: Callable[[Any, str], None],
    ) -> int:
        launch.config.gameplay_config.require_farm_policy()
        if launch.config.play_style is PlayStyle.DINOSAUR:
            from tools.dinosaur_run import run as run_dinosaur
            return run_dinosaur(
                launch.config, expected_match_id=launch.expected_match_id,
                expected_pid=launch.game_pid, reset_evidence=self.reset_evidence,
                artifacts_root=self.artifacts_root, control_edges=edges,
                observer=observer,
            )
        from tools import farm_run as farm_run_tool

        config = launch.config
        argv = [
            "--stage-e2-ui",
            "--boss-id",
            config.normalized_boss_id or "",
            "--target-matches",
            str(config.target_completed_matches),
            "--max-match-attempts",
            str(config.max_match_attempts),
            "--play-style",
            config.play_style.value,
            "--game-mode",
            config.game_mode.value,
            "--main-pet",
            config.main_pet.value,
            "--evolution-target",
            config.evolution.value,
            "--damage-card",
            config.damage_card.value,
            "--audition-mode",
            config.audition_mode.value,
            "--cast-when-boss-hp-below",
            str(config.cast_when_boss_hp_below),
            "--cast-mana-stockpile",
            str(config.cast_mana_stockpile),
            "--rage-target",
            str(config.rage_target),
            "--pet-skill-fire-condition",
            config.pet_skill_fire_condition.value,
            "--demon-target-gem",
            config.demon_target_gem.value,
            "--board-input-mode",
            config.board_input_mode.value,
            "--input-delivery-mode",
            config.input_delivery_mode.value,
            "--reset-evidence",
            str(self.reset_evidence),
            "--artifacts",
            str(self.artifacts_root),
        ]
        if config.pet_skill_fire_value is not None:
            argv.extend(
                ["--pet-skill-fire-value", str(config.pet_skill_fire_value)]
            )
        from .input_randomization import InputRandomization
        if config.input_randomization != InputRandomization():
            import json
            argv.extend(['--input-randomization',json.dumps(config.input_randomization.to_dict())])
        if not config.tool_sound_enabled:
            argv.append("--no-beep")
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
        if self._reasoning_session_factory is not None:
            reasoning_session = None
            try:
                reasoning_session = self._reasoning_session_factory(config)
            except Exception as exc:
                try:
                    observer(AIStatus("DEGRADED", f"PILOT_SETUP_{type(exc).__name__}"), "AI_STATUS")
                except Exception:
                    pass
            if reasoning_session is not None:
                try:
                    return farm_run_tool.run(args, control_edges=edges, observer=observer,
                                             reasoning_session=reasoning_session)
                finally:
                    try:
                        reasoning_session.stop()  # Signal only, never wait/drain here.
                    except Exception:
                        pass
        if config.ai.reasoning_enabled:
            # Normal UI opt-in is separate from historical one-shot pilots.
            # Any setup/profile fault still invokes this exact BASIC FarmRunner.
            session = None
            if self._reasoning_session_factory is None:
                try:
                    previous = self._ui_reasoning_session
                    if previous is not None and (not previous.closed.is_set() or previous.cleanup_ok is not True):
                        observer(AIStatus('DEGRADED', 'UI_REASONING_CLEANUP_PENDING'), 'AI_STATUS')
                    else:
                        from .app_paths import current_app_paths
                        from .reasoning_ui_session import create_ui_reasoning_session
                        from tools.runtime_common import configured_game_executable
                        import uuid
                        selection = configured_game_executable()
                        if selection is None:
                            observer(AIStatus('UNSUPPORTED', 'UI_REASONING_GAME_LOCATION_REQUIRED'), 'AI_STATUS')
                        else:
                            paths = replace(current_app_paths(),source_root=self.project_root,data_root=self.data_root)
                            session = create_ui_reasoning_session(config,paths=paths,
                                game_executable=selection.executable,
                                directory=self.artifacts_root/'reasoning'/('ui_'+uuid.uuid4().hex),observer=observer)
                            self._ui_reasoning_session = session
                except Exception as exc:
                    try:
                        observer(AIStatus('DEGRADED', 'UI_REASONING_SETUP_'+type(exc).__name__), 'AI_STATUS')
                    except Exception:
                        pass
            if session is None:
                return farm_run_tool.run(args,control_edges=edges,observer=observer)
            try:
                return farm_run_tool.run(args,control_edges=edges,observer=observer,reasoning_session=session)
            finally:
                try:
                    session.stop()
                except Exception:
                    pass
        if not config.ai.shadow_enabled:
            return farm_run_tool.run(args, control_edges=edges, observer=observer)
        session = None
        try:
            from .reasoning_settings import RunShadowSession
            session = RunShadowSession(config, directory=self.artifacts_root / "reasoning",
                                       observer=observer)
        except Exception as exc:
            try:
                observer(AIStatus("DEGRADED", f"SHADOW_CONFIG_{type(exc).__name__}"), "AI_STATUS")
            except Exception:
                pass
        if session is None:
            return farm_run_tool.run(args, control_edges=edges, observer=observer)
        try:
            return farm_run_tool.run(args, control_edges=edges, observer=observer,
                                     shadow_session=session)
        finally:
            session.stop()  # Signal only; never drain/join on FarmRunner teardown.


__all__ = [
    "ControllerCommandResult",
    "ControllerSafetyEvidence",
    "DesktopControllerSnapshot",
    "DesktopControllerState",
    "DesktopFarmControllerManager",
]
