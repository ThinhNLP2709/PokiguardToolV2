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
    def __init__(self, lifecycle: str = "BOSS_LOBBY") -> None:
        self.lifecycle = lifecycle

    def read(self) -> RuntimeObservation:
        return RuntimeObservation(True, True, 123, "x64", self.lifecycle)

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
        self.config = DesktopConfig(target_completed_matches=3, max_match_attempts=5)

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
        self.assertIn("GAME_FOREGROUND_HANDOFF_FAILED", snapshot.last_error or "")

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
        self.assertEqual(args.target_matches, 4)
        self.assertEqual(args.max_technical_recoveries, 2)
        self.assertEqual(args.max_match_attempts, 7)


class DesktopControlCommandTests(unittest.TestCase):
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
            config = DesktopConfig(target_completed_matches=3, max_match_attempts=5)
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
