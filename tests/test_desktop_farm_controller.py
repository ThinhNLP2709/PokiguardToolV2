from __future__ import annotations

from dataclasses import replace
from pathlib import Path
from types import SimpleNamespace
import tempfile
import threading
import time
import unittest
from unittest.mock import patch

from pokiguard_v2.basic_policy import ManaPriority, PlayStyle
from pokiguard_v2.desktop_control_plane import (
    DesktopConfig,
    DesktopControlPlane,
    LatestCheckpointSummaryProvider,
    RuntimeObservation,
)
from pokiguard_v2.desktop_farm_controller import (
    ControllerLaunch,
    DesktopControllerState,
    DesktopFarmControllerManager,
)
from pokiguard_v2.win32_input import FarmControlHotkeyEdges
from pokiguard_v2.farm_checkpoint import (
    CHECKPOINT_SCHEMA,
    CheckpointPayload,
    load_checkpoint,
    write_checkpoint,
)
from pokiguard_v2.farm_run import FarmRunLimits, FarmRunState, FarmRunStopReason


def _source(
    *,
    state: FarmRunState = FarmRunState.COMBAT_ACTIVE,
    stop_reason: FarmRunStopReason | None = None,
    completed: int = 0,
    attempts: int = 1,
) -> SimpleNamespace:
    return SimpleNamespace(
        farm_run_id="fake-run",
        continuation_of=None,
        state=state,
        current_match_id="M_fake" if state is FarmRunState.COMBAT_ACTIVE else None,
        limits=FarmRunLimits(3, 1, 5),
        match_attempts=attempts,
        completed_matches=completed,
        wins=completed,
        losses=0,
        unknown_results=0,
        technical_aborts=0,
        technical_recoveries=0,
        total_gameplay_inputs=completed,
        total_lobby_inputs=attempts,
        total_postmatch_inputs=completed,
        total_recovery_inputs=0,
        graceful_stop_requested_at=("requested" if stop_reason is FarmRunStopReason.STOPPED_GRACEFULLY else None),
        stop_reason=stop_reason,
    )


class _BlockingRunner:
    def __init__(self) -> None:
        self.entered = threading.Event()
        self.release = threading.Event()
        self.starts = 0
        self.launches = []
        self.denied_after_emergency: bool | None = None
        self.graceful_seen = False

    def __call__(self, launch, edges, observer) -> int:
        self.starts += 1
        self.launches.append(launch)
        observer(_source(), "COMBAT")
        self.entered.set()
        self.release.wait(5.0)
        f6, _f9 = edges.take()
        self.graceful_seen = f6 > 0
        if edges.emergency_requested:
            authorized, _result = edges.execute_if_authorized(lambda: "forbidden")
            self.denied_after_emergency = not authorized
            observer(
                _source(
                    state=FarmRunState.SAFE_STOP,
                    stop_reason=FarmRunStopReason.EMERGENCY_STOP,
                ),
                "FINISHED",
            )
        elif self.graceful_seen:
            observer(
                _source(
                    state=FarmRunState.FARM_RUN_COMPLETE,
                    stop_reason=FarmRunStopReason.STOPPED_GRACEFULLY,
                    completed=1,
                ),
                "FINISHED",
            )
        else:
            observer(
                _source(
                    state=FarmRunState.FARM_RUN_COMPLETE,
                    stop_reason=FarmRunStopReason.FARM_TARGET_COMPLETED,
                    completed=3,
                    attempts=3,
                ),
                "FINISHED",
            )
        return 0


class _Runtime:
    def __init__(
        self,
        lifecycle: str = "BOSS_LOBBY",
        *,
        target_id: str = "1289",
        target_name: str = "Starburst",
        lobby_branch: str | None = None,
    ) -> None:
        self.lifecycle = lifecycle
        self.target_id = target_id
        self.target_name = target_name
        self.lobby_branch = (
            lobby_branch
            if lobby_branch is not None
            else ("CHINH_PHUC_ROOM" if lifecycle == "BOSS_LOBBY" else None)
        )

    def read(self) -> RuntimeObservation:
        return RuntimeObservation(
            True,
            True,
            123,
            "x64",
            self.lifecycle,
            target_id=self.target_id,
            target_name=self.target_name,
            target_candidates=((self.target_id, self.target_name),),
            lobby_branch=self.lobby_branch,
            current_room_id=(
                f"room-{self.target_id}"
                if self.lobby_branch == "CHINH_PHUC_ROOM"
                else None
            ),
        )

    def close(self) -> None:
        return None


def _checkpoint(path: Path, config: DesktopConfig) -> None:
    now = time.time()
    write_checkpoint(
        path,
        CheckpointPayload(
            schema_version=CHECKPOINT_SCHEMA,
            farm_run_id="historical-run",
            continuation_of=None,
            checkpoint_seq=2,
            created_at=now,
            updated_at=now,
            target_boss_id=config.normalized_boss_id or "",
            target_boss_name=config.normalized_boss_name or "",
            configured_limits={
                "target_completed_matches": config.target_completed_matches,
                "max_technical_recoveries": config.max_technical_recoveries,
                "max_match_attempts": config.max_match_attempts,
            },
            run_started_at=now,
            match_attempts=1,
            completed_matches=1,
            wins=1,
            losses=0,
            unknown_results=0,
            technical_aborts=0,
            technical_recoveries=0,
            technical_exits=0,
            last_completed_match_id="M_old",
            seen_match_ids=("M_old",),
            action_aggregates={
                "swap_sent": 1,
                "swap_acknowledged": 1,
                "swap_rejected": 0,
                "swap_aborted_state_changed": 0,
                "cast_sent": 0,
                "cast_accepted": 0,
                "cast_rejected": 0,
                "evolve_attempts": 0,
                "evolve_success": 0,
                "evolve_failed": 0,
            },
            pass_totals=0,
            consistency_aggregates={
                "consistent": 1,
                "memory_incomplete": 0,
                "conflicts": 0,
                "strong_terminal_results": 1,
            },
            last_safe_lifecycle="BOSS_LOBBY",
            stop_request_state="STOPPED_AT_LOBBY",
            stop_reason="STOPPED_GRACEFULLY",
            finalized_status="STOPPED_GRACEFULLY",
        ),
    )


class DesktopFarmControllerTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temporary = tempfile.TemporaryDirectory()
        self.root = Path(self.temporary.name)
        reset = self.root / "reset.json"
        reset.write_text("{}", encoding="utf-8")
        self.runner = _BlockingRunner()
        self.manager = DesktopFarmControllerManager(
            self.root,
            runner=self.runner,
            reset_evidence=reset,
            artifacts_root=self.root / "runs",
        )
        self.config = DesktopConfig(
            boss_id="1289",
            boss_name="Starburst",
            target_completed_matches=3,
            max_match_attempts=5,
        )

    def tearDown(self) -> None:
        self.runner.release.set()
        self.manager.wait(2.0)
        self.temporary.cleanup()

    def test_valid_start_is_async_and_double_start_creates_exactly_one(self) -> None:
        started_at = time.monotonic()
        first = self.manager.start(self.config)
        elapsed = time.monotonic() - started_at
        second = self.manager.start(self.config)
        self.assertTrue(first.accepted)
        self.assertLess(elapsed, 0.2)
        self.assertFalse(second.accepted)
        self.assertTrue(self.runner.entered.wait(1.0))
        self.assertEqual(self.runner.starts, 1)
        self.assertEqual(
            self.manager.snapshot().safety.max_simultaneous_controllers, 1
        )

    def test_live_turn_projection_separates_current_and_completed_energy(self) -> None:
        source = _source()
        source.attempts = (
            SimpleNamespace(
                attempt_index=1,
                local_turns=11,
                end_timestamp="complete",
                result=SimpleNamespace(value="WIN"),
            ),
            SimpleNamespace(
                attempt_index=2,
                local_turns=4,
                end_timestamp=None,
                result=SimpleNamespace(value="UNKNOWN"),
            ),
        )

        generation = self.manager.snapshot().generation
        self.manager._observe(generation, source, "COMBAT_LOCAL_TURN_7")
        projected = self.manager.snapshot()

        self.assertEqual(((1, 11),), projected.completed_match_turns)
        self.assertEqual(4, projected.current_match_turns)
        self.assertEqual(15, projected.total_energy_used)

    def test_start_foregrounds_verified_pid_before_runner(self) -> None:
        foregrounded: list[int] = []
        manager = DesktopFarmControllerManager(
            self.root,
            runner=self.runner,
            foreground_handoff=lambda pid: foregrounded.append(pid) or True,
            reset_evidence=self.root / "reset.json",
            artifacts_root=self.root / "runs-focus",
        )
        result = manager.start(self.config, game_pid=4567)
        self.assertTrue(result.accepted)
        self.assertTrue(self.runner.entered.wait(1.0))
        self.assertEqual(foregrounded, [4567])
        self.assertEqual(manager.snapshot().foreground_handoff, "SUCCEEDED")
        self.runner.release.set()
        self.assertTrue(manager.wait(2.0))

    def test_foreground_failure_fails_closed_before_runner(self) -> None:
        manager = DesktopFarmControllerManager(
            self.root,
            runner=self.runner,
            foreground_handoff=lambda _pid: False,
            reset_evidence=self.root / "reset.json",
            artifacts_root=self.root / "runs-focus-fail",
        )
        result = manager.start(self.config, game_pid=4567)
        self.assertTrue(result.accepted)
        self.assertTrue(manager.wait(2.0))
        snapshot = manager.snapshot()
        self.assertEqual(self.runner.starts, 0)
        self.assertEqual(snapshot.state, DesktopControllerState.ERROR)
        self.assertIn("GAME_WINDOW_PREPARATION_FAILED", snapshot.last_error or "")

    def test_graceful_stop_is_idempotent_and_drains_one_match(self) -> None:
        result = self.manager.start(self.config)
        self.assertTrue(self.runner.entered.wait(1.0))
        first = self.manager.request_graceful_stop(result.generation)
        second = self.manager.request_graceful_stop(result.generation)
        self.assertTrue(first.accepted)
        self.assertTrue(second.accepted)
        self.runner.release.set()
        self.assertTrue(self.manager.wait(2.0))
        snapshot = self.manager.snapshot()
        self.assertTrue(self.runner.graceful_seen)
        self.assertEqual(snapshot.completed_matches, 1)
        self.assertEqual(snapshot.match_attempts, 1)
        self.assertEqual(snapshot.safety.graceful_stop_commands, 1)

    def test_graceful_stop_returns_focus_to_current_game_pid(self) -> None:
        foregrounded: list[int] = []
        manager = DesktopFarmControllerManager(
            self.root,
            runner=self.runner,
            foreground_handoff=lambda pid: foregrounded.append(pid) or True,
            reset_evidence=self.root / "reset.json",
            artifacts_root=self.root / "runs-graceful-focus",
        )
        started = manager.start(self.config, game_pid=7654)
        self.assertTrue(self.runner.entered.wait(1.0))
        stopped = manager.request_graceful_stop(started.generation)
        self.assertTrue(stopped.accepted)
        self.assertEqual(stopped.reason, "GRACEFUL_STOP_ACCEPTED")
        self.assertEqual(foregrounded, [7654, 7654])
        self.runner.release.set()
        self.assertTrue(manager.wait(2.0))

    def test_close_dialog_focus_restore_has_no_stop_or_input_side_effect(self) -> None:
        foregrounded: list[int] = []
        manager = DesktopFarmControllerManager(
            self.root,
            runner=self.runner,
            foreground_handoff=lambda pid: foregrounded.append(pid) or True,
            reset_evidence=self.root / "reset.json",
            artifacts_root=self.root / "runs-close-dialog-focus",
        )
        started = manager.start(self.config, game_pid=2468)
        self.assertTrue(self.runner.entered.wait(1.0))
        restored = manager.restore_game_foreground(started.generation)
        self.assertTrue(restored.accepted)
        self.assertEqual(
            restored.reason, "GAME_FOREGROUND_RESTORED_FOR_CLOSE_DIALOG"
        )
        snapshot = manager.snapshot()
        self.assertFalse(snapshot.graceful_stop_requested)
        self.assertIsNone(snapshot.emergency_stop_acknowledged_at)
        self.assertEqual(snapshot.total_gameplay_inputs, 0)
        self.assertEqual(foregrounded, [2468, 2468])
        self.runner.release.set()
        self.assertTrue(manager.wait(2.0))

    def test_stale_close_dialog_focus_restore_is_rejected(self) -> None:
        started = self.manager.start(self.config)
        self.assertTrue(self.runner.entered.wait(1.0))
        restored = self.manager.restore_game_foreground(started.generation - 1)
        self.assertFalse(restored.accepted)
        self.assertEqual(restored.reason, "STALE_CONTROLLER_GENERATION")
        self.runner.release.set()
        self.assertTrue(self.manager.wait(2.0))

    def test_emergency_ack_revokes_future_input_authority(self) -> None:
        result = self.manager.start(self.config)
        self.assertTrue(self.runner.entered.wait(1.0))
        stopped = self.manager.emergency_stop(result.generation)
        self.assertTrue(stopped.accepted)
        self.runner.release.set()
        self.assertTrue(self.manager.wait(2.0))
        snapshot = self.manager.snapshot()
        self.assertTrue(self.runner.denied_after_emergency)
        self.assertEqual(snapshot.safety.autonomous_inputs_after_emergency_ack, 0)
        self.assertEqual(snapshot.state, DesktopControllerState.STOPPED)

    def test_stale_stop_cannot_mutate_new_generation(self) -> None:
        first = self.manager.start(self.config)
        self.runner.release.set()
        self.assertTrue(self.manager.wait(2.0))
        self.runner.release.clear()
        second = self.manager.start(self.config)
        self.assertNotEqual(first.generation, second.generation)
        rejected = self.manager.request_graceful_stop(first.generation)
        self.assertFalse(rejected.accepted)
        self.assertFalse(self.manager.snapshot().graceful_stop_requested)
        self.assertEqual(self.manager.snapshot().safety.wrong_run_command_applications, 0)

    def test_valid_resume_uses_checkpoint_once_and_invalid_is_zero_runner(self) -> None:
        checkpoint = self.root / "history" / "checkpoint.json"
        _checkpoint(checkpoint, self.config)
        accepted = self.manager.resume(self.config, checkpoint)
        self.assertTrue(accepted.accepted)
        self.assertTrue(self.runner.entered.wait(1.0))
        self.assertEqual(self.runner.starts, 1)
        self.assertEqual(self.runner.launches[0].checkpoint_path, checkpoint.resolve())

        self.runner.release.set()
        self.manager.wait(2.0)
        bad = self.root / "bad.json"
        bad.write_text("{broken", encoding="utf-8")
        rejected = self.manager.resume(self.config, bad)
        self.assertFalse(rejected.accepted)
        self.assertEqual(self.runner.starts, 1)

    def test_production_adapter_preserves_basic_policy_and_finite_limits(self) -> None:
        config = DesktopConfig(
            play_style=PlayStyle.CAREFUL,
            mana_priority=ManaPriority.ATTACK,
            boss_id="1289",
            boss_name="Starburst",
            target_completed_matches=4,
            max_technical_recoveries=2,
            max_match_attempts=7,
        )
        with patch("tools.farm_run.run", return_value=0) as run:
            code = self.manager._run_production(  # noqa: SLF001
                ControllerLaunch(config, None),
                FarmControlHotkeyEdges(),
                lambda _snapshot, _phase: None,
            )
        self.assertEqual(code, 0)
        args = run.call_args.args[0]
        self.assertTrue(args.stage_e2_ui)
        self.assertEqual(args.play_style, "careful")
        self.assertEqual(args.mana_priority, "attack")
        self.assertEqual(args.board_input_mode, "drag")
        self.assertEqual(args.target_matches, 4)
        # The legacy CLI field remains parse-compatible but the desktop no
        # longer exposes or forwards a lifetime recovery cap.
        self.assertEqual(args.max_technical_recoveries, 1)
        self.assertEqual(args.max_match_attempts, 7)
        self.assertFalse(args.stop_if_room_ejected)


class DesktopControlCommandTests(unittest.TestCase):
    def test_start_pins_current_room_target_without_user_known_id(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary)
            reset = root / "reset.json"
            reset.write_text("{}", encoding="utf-8")
            runner = _BlockingRunner()
            manager = DesktopFarmControllerManager(
                root, runner=runner, reset_evidence=reset
            )
            plane = DesktopControlPlane(
                _Runtime(target_id="777", target_name="Runtime Pet"),
                controller=manager,
                # Deliberately stale preference evidence. Start authority must
                # come from the exact room, not this prior-session value.
                config=DesktopConfig(boss_id="1289", boss_name="Starburst"),
            )
            ready = plane.refresh()
            self.assertTrue(ready.controls.start.actionable)
            started = plane.start_farm()
            self.assertTrue(started.accepted)
            self.assertTrue(runner.entered.wait(1.0))
            launch = runner.launches[0]
            self.assertEqual("777", launch.config.normalized_boss_id)
            self.assertEqual("Runtime Pet", launch.config.normalized_boss_name)
            self.assertEqual("777", plane.snapshot().config.normalized_boss_id)
            runner.release.set()
            manager.wait(2.0)
            stopped = plane.refresh()
            self.assertFalse(stopped.controller.active)
            self.assertIsNone(stopped.config.normalized_boss_id)
            self.assertIsNone(stopped.config.normalized_boss_name)
            plane.close()

    def test_world_boss_map_never_becomes_startable_or_selects_a_pet(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary)
            reset = root / "reset.json"
            reset.write_text("{}", encoding="utf-8")
            runner = _BlockingRunner()
            manager = DesktopFarmControllerManager(
                root, runner=runner, reset_evidence=reset
            )
            plane = DesktopControlPlane(
                _Runtime(lobby_branch="WORLD_BOSS_LIST"), controller=manager
            )
            snapshot = plane.refresh()
            self.assertFalse(snapshot.controls.start.actionable)
            self.assertEqual(
                "CURRENT_BOSS_ROOM_NOT_PROVEN", snapshot.controls.start.reason
            )
            rejected = plane.start_farm()
            self.assertFalse(rejected.accepted)
            self.assertEqual(0, runner.starts)
            self.assertEqual(0, plane.snapshot().safety.boss_entry_commands)
            plane.close()

    def test_start_requires_numeric_runtime_pet_id_not_name_only(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary)
            reset = root / "reset.json"
            reset.write_text("{}", encoding="utf-8")
            runner = _BlockingRunner()
            manager = DesktopFarmControllerManager(
                root, runner=runner, reset_evidence=reset
            )
            plane = DesktopControlPlane(
                _Runtime(target_id=None, target_name="Name Only"),
                controller=manager,
            )
            snapshot = plane.refresh()
            self.assertFalse(snapshot.controls.start.actionable)
            self.assertEqual(
                "CURRENT_ROOM_PET_ID_NOT_PROVEN",
                snapshot.controls.start.reason,
            )
            self.assertFalse(plane.start_farm().accepted)
            self.assertEqual(0, runner.starts)
            plane.close()

    def test_start_rejects_non_numeric_runtime_pet_id(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary)
            reset = root / "reset.json"
            reset.write_text("{}", encoding="utf-8")
            runner = _BlockingRunner()
            manager = DesktopFarmControllerManager(
                root, runner=runner, reset_evidence=reset
            )
            plane = DesktopControlPlane(
                _Runtime(target_id="not-an-id", target_name="Bad"),
                controller=manager,
            )
            snapshot = plane.refresh()
            self.assertFalse(snapshot.controls.start.actionable)
            self.assertEqual(
                "CURRENT_ROOM_PET_ID_INVALID", snapshot.controls.start.reason
            )
            self.assertEqual(0, runner.starts)
            plane.close()

    def test_lifecycle_aware_controls_and_active_config_lock_use_backend_truth(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary)
            reset = root / "reset.json"
            reset.write_text("{}", encoding="utf-8")
            runner = _BlockingRunner()
            manager = DesktopFarmControllerManager(
                root, runner=runner, reset_evidence=reset
            )
            plane = DesktopControlPlane(_Runtime(), controller=manager)
            ready = plane.refresh()
            self.assertTrue(ready.controls.start.actionable)
            self.assertFalse(ready.controls.resume.actionable)
            self.assertFalse(ready.controls.graceful_stop.actionable)
            self.assertFalse(ready.controls.emergency_stop.actionable)
            self.assertTrue(ready.controls.config_editable)

            self.assertTrue(plane.start_farm().accepted)
            self.assertTrue(runner.entered.wait(1.0))
            active = plane.refresh()
            self.assertFalse(active.controls.start.actionable)
            self.assertEqual(
                "CONTROLLER_ALREADY_ACTIVE", active.controls.start.reason
            )
            self.assertTrue(active.controls.graceful_stop.actionable)
            self.assertTrue(active.controls.emergency_stop.actionable)
            self.assertFalse(active.controls.config_editable)
            with self.assertRaisesRegex(
                RuntimeError, "CONFIG_LOCKED_CONTROLLER_ACTIVE"
            ):
                plane.update_config(DesktopConfig(target_completed_matches=4))

            self.assertTrue(
                plane.request_graceful_stop(active.controller.generation).accepted
            )
            pending = plane.snapshot()
            self.assertFalse(pending.controls.graceful_stop.actionable)
            self.assertTrue(pending.controls.emergency_stop.actionable)
            runner.release.set()
            manager.wait(2.0)
            plane.close()

    def test_resume_guidance_uses_canonical_checkpoint_validator(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary)
            reset = root / "reset.json"
            reset.write_text("{}", encoding="utf-8")
            config = DesktopConfig(
                boss_id="1289",
                boss_name="Starburst",
                target_completed_matches=3,
                max_match_attempts=5,
            )
            checkpoint_path = root / "runs" / "old" / "checkpoint.json"
            _checkpoint(checkpoint_path, config)
            manager = DesktopFarmControllerManager(
                root,
                runner=_BlockingRunner(),
                reset_evidence=reset,
                artifacts_root=root / "runs",
            )
            plane = DesktopControlPlane(
                _Runtime(),
                controller=manager,
                checkpoint=LatestCheckpointSummaryProvider(root / "runs"),
                config=config,
            )
            resumable = plane.refresh()
            self.assertTrue(resumable.controls.resume.actionable)

            payload = load_checkpoint(checkpoint_path)
            write_checkpoint(
                checkpoint_path,
                replace(
                    payload,
                    finalized_status="COMPLETED",
                    stop_reason="FARM_TARGET_COMPLETED",
                    stop_request_state="RUNNING",
                ),
            )
            completed = plane.refresh()
            self.assertFalse(completed.controls.resume.actionable)
            self.assertIn("INVALID_LAUNCH", completed.controls.resume.reason)
            self.assertFalse(plane.resume_from_checkpoint().accepted)

            write_checkpoint(
                checkpoint_path,
                replace(
                    payload,
                    finalized_status="EMERGENCY_STOPPED",
                    stop_reason="EMERGENCY_STOP",
                    stop_request_state="EMERGENCY_STOPPED",
                ),
            )
            emergency = plane.refresh()
            self.assertFalse(emergency.controls.resume.actionable)
            self.assertIn("INVALID_LAUNCH", emergency.controls.resume.reason)
            plane.close()

    def test_start_requires_fresh_exact_boss_lobby(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary)
            reset = root / "reset.json"
            reset.write_text("{}", encoding="utf-8")
            runner = _BlockingRunner()
            manager = DesktopFarmControllerManager(
                root, runner=runner, reset_evidence=reset
            )
            plane = DesktopControlPlane(
                _Runtime("ACTIVE_COMBAT"), controller=manager
            )
            plane.refresh()
            rejected = plane.start_farm()
            self.assertFalse(rejected.accepted)
            self.assertEqual(runner.starts, 0)
            plane.close()

    def test_resume_uses_latest_canonical_checkpoint_and_no_double_start(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary)
            reset = root / "reset.json"
            reset.write_text("{}", encoding="utf-8")
            config = DesktopConfig(
                boss_id="1289",
                boss_name="Starburst",
                target_completed_matches=3,
                max_match_attempts=5,
            )
            checkpoint = root / "runs" / "old" / "checkpoint.json"
            _checkpoint(checkpoint, config)
            runner = _BlockingRunner()
            manager = DesktopFarmControllerManager(
                root,
                runner=runner,
                reset_evidence=reset,
                artifacts_root=root / "runs",
            )
            plane = DesktopControlPlane(
                _Runtime(),
                controller=manager,
                checkpoint=LatestCheckpointSummaryProvider(root / "runs"),
                config=config,
            )
            plane.refresh()
            resumed = plane.resume_from_checkpoint()
            duplicate = plane.resume_from_checkpoint()
            self.assertTrue(resumed.accepted)
            self.assertFalse(duplicate.accepted)
            self.assertTrue(runner.entered.wait(1.0))
            self.assertEqual(runner.starts, 1)
            self.assertEqual(runner.launches[0].game_pid, 123)
            runner.release.set()
            manager.wait(2.0)
            plane.close()


if __name__ == "__main__":
    unittest.main()
