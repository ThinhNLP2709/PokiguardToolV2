from __future__ import annotations

import json
import tempfile
import unittest
from pathlib import Path
from unittest.mock import patch

from pokiguard_v2.boss_entry import BossLobbyState, FarmTarget
from pokiguard_v2.farm_checkpoint import CHECKPOINT_SCHEMA
from pokiguard_v2.farm_run import (
    FarmRun,
    FarmRunArtifactWriter,
    FarmRunState,
    FarmRunStopReason,
)
from tools.farm_run import (
    _ControllerMemorySampler,
    _ContextualFarmHotkeys,
    _checkpoint_path,
    _persist_checkpoint,
    build_parser,
    _validate_args,
)


BASE = [
    "--boss-id",
    "1289",
    "--reset-evidence",
    "README.md",
]


def parse(argv: list[str]):
    return build_parser().parse_args(argv)


class InfiniteFarmingProhibitedTests(unittest.TestCase):
    """Phase 2D.6 must expose no way to request an unbounded run."""

    def test_no_infinite_flags_exist(self) -> None:
        parser = build_parser()
        options: set[str] = set()
        for action in parser._actions:  # noqa: SLF001 - deliberate CLI audit
            options.update(action.option_strings)
        for forbidden in ("--forever", "--infinite", "--unlimited", "--endless"):
            self.assertNotIn(forbidden, options)

    def test_zero_target_rejected(self) -> None:
        args = parse(
            ["--stage-d6-b3-soak", "--new-run", "--target-matches", "0", *BASE]
        )
        with self.assertRaises(ValueError):
            _validate_args(args)

    def test_negative_target_rejected(self) -> None:
        args = parse(
            ["--stage-d6-b3-soak", "--new-run", "--target-matches", "-1", *BASE]
        )
        with self.assertRaises(ValueError):
            _validate_args(args)


class ResumeGatingTests(unittest.TestCase):
    def test_live_stage_requires_explicit_new_run_or_resume(self) -> None:
        args = parse(["--stage-d6-b1-graceful", "--target-matches", "3", *BASE])
        with self.assertRaises(ValueError) as ctx:
            _validate_args(args)
        self.assertIn("auto-resume is never performed", str(ctx.exception))

    def test_new_run_alone_is_accepted(self) -> None:
        args = parse(
            [
                "--stage-d6-b1-graceful",
                "--new-run",
                "--target-matches",
                "3",
                "--max-match-attempts",
                "5",
                *BASE,
            ]
        )
        limits = _validate_args(args)
        self.assertEqual(limits.target_completed_matches, 3)

    def test_resume_requires_existing_file(self) -> None:
        args = parse(
            [
                "--stage-d6-b2-resume",
                "--resume",
                "does_not_exist.json",
                "--target-matches",
                "5",
                "--max-match-attempts",
                "8",
                *BASE,
            ]
        )
        with self.assertRaises(FileNotFoundError):
            _validate_args(args)

    def test_resume_rejected_for_non_d6_stage(self) -> None:
        with tempfile.TemporaryDirectory() as tmp:
            path = Path(tmp) / "checkpoint.json"
            path.write_text("{}", encoding="utf-8")
            args = parse(
                [
                    "--stage-d5-b2-soak",
                    "--resume",
                    str(path),
                    "--target-matches",
                    "5",
                    "--max-match-attempts",
                    "8",
                    *BASE,
                ]
            )
            with self.assertRaises(ValueError) as ctx:
                _validate_args(args)
            self.assertIn("only valid for Phase 2D.6", str(ctx.exception))

    def test_new_run_and_resume_are_mutually_exclusive(self) -> None:
        with self.assertRaises(SystemExit):
            parse(
                [
                    "--stage-d6-b2-resume",
                    "--new-run",
                    "--resume",
                    "x.json",
                    *BASE,
                ]
            )


class StageBoundTests(unittest.TestCase):
    def test_negative_gameplay_thresholds_fail_before_live_start(self) -> None:
        for option in (
            "--cast-when-boss-hp-below",
            "--cast-mana-stockpile",
            "--rage-target",
        ):
            with self.subTest(option=option):
                args = parse(
                    [
                        "--stage-d6-b1-graceful",
                        "--new-run",
                        "--target-matches",
                        "3",
                        option,
                        "-1",
                        *BASE,
                    ]
                )
                with self.assertRaises(ValueError):
                    _validate_args(args)

    def test_live_d6_requires_existing_reset_evidence(self) -> None:
        args = parse(
            [
                "--stage-d6-b1-graceful",
                "--new-run",
                "--target-matches",
                "3",
                "--boss-id",
                "1289",
            ]
        )
        with self.assertRaisesRegex(FileNotFoundError, "reset-evidence"):
            _validate_args(args)

    def test_b1_requires_target_above_one(self) -> None:
        args = parse(
            ["--stage-d6-b1-graceful", "--new-run", "--target-matches", "1", *BASE]
        )
        with self.assertRaises(ValueError):
            _validate_args(args)

    def test_b3_requires_at_least_five(self) -> None:
        args = parse(
            [
                "--stage-d6-b3-soak",
                "--new-run",
                "--target-matches",
                "3",
                "--max-match-attempts",
                "9",
                *BASE,
            ]
        )
        with self.assertRaises(ValueError):
            _validate_args(args)

    def test_b3_long_soak_defaults_accepted(self) -> None:
        args = parse(
            [
                "--stage-d6-b3-soak",
                "--new-run",
                "--target-matches",
                "25",
                "--max-technical-recoveries",
                "3",
                "--max-match-attempts",
                "32",
                *BASE,
            ]
        )
        limits = _validate_args(args)
        self.assertEqual(limits.target_completed_matches, 25)
        self.assertEqual(limits.max_technical_recoveries, 3)
        self.assertEqual(limits.max_match_attempts, 32)

    def test_offline_stage_needs_no_boss_target(self) -> None:
        args = parse(["--stage-d6-a-control"])
        limits = _validate_args(args)
        self.assertGreater(limits.target_completed_matches, 0)


class MemorySamplerTests(unittest.TestCase):
    def test_report_is_honest_when_unavailable(self) -> None:
        sampler = _ControllerMemorySampler()
        sampler._available = False  # noqa: SLF001 - simulate non-Windows
        sampler.sample()
        self.assertEqual(sampler.report(), {"available": False})

    def test_samples_are_bounded(self) -> None:
        sampler = _ControllerMemorySampler()
        if sampler._working_set_bytes() is None:  # noqa: SLF001
            self.skipTest("working set telemetry unavailable on this platform")
        for _ in range(sampler._max_samples + 50):  # noqa: SLF001
            sampler.sample()
        self.assertLessEqual(len(sampler.samples), sampler._max_samples)  # noqa: SLF001
        report = sampler.report()
        self.assertTrue(report["available"])
        self.assertIn("bounded soak", report["interpretation"])
        # Never claims a general leak-free proof.
        self.assertNotIn("no leak", report["interpretation"].lower())


class CheckpointPathTests(unittest.TestCase):
    def test_checkpoint_path_is_inside_run_directory(self) -> None:
        with tempfile.TemporaryDirectory() as tmp:
            directory = Path(tmp)
            self.assertEqual(
                _checkpoint_path(directory), directory / "checkpoint.json"
            )

    def test_checkpoint_write_failure_safe_stops_before_farming(self) -> None:
        run = FarmRun(FarmTarget("1289", None))
        self.assertTrue(run.observe_initial_lobby(BossLobbyState.BOSS_LOBBY))
        with tempfile.TemporaryDirectory() as tmp:
            writer = FarmRunArtifactWriter.create(Path(tmp), run.farm_run_id)
            with patch(
                "tools.farm_run.write_checkpoint",
                side_effect=OSError("disk unavailable"),
            ):
                self.assertFalse(_persist_checkpoint(run, writer))
        self.assertEqual(run.stop_reason, FarmRunStopReason.CHECKPOINT_INVALID)


class ContextualHotkeyTests(unittest.TestCase):
    def test_take_registers_edge_even_when_native_take_discovers_it(self) -> None:
        class Edges:
            def __init__(self) -> None:
                self.calls = 0
                self.latched = 0

            def poll(self):
                self.calls += 1
                edge = self.calls == 2
                if edge:
                    self.latched += 1
                return edge, False

            def take(self):
                self.poll()
                value = self.latched
                self.latched = 0
                return value, 0

        class Run:
            state = FarmRunState.COMBAT_ACTIVE
            current_session = type("Session", (), {"match_id": "M_live"})()
            match_attempts = 1
            completed_matches = 0

            def __init__(self) -> None:
                self.requests = []

            def graceful_stop_request(self, *, lifecycle, match_id):
                self.requests.append((lifecycle, match_id))
                return True

        run = Run()
        hotkeys = _ContextualFarmHotkeys(Edges(), lambda: run)
        self.assertEqual(hotkeys.take(), (1, 0))
        self.assertEqual(run.requests, [("ACTIVE_COMBAT", "M_live")])
        self.assertEqual(hotkeys.total_f6_edges, 1)
        self.assertTrue(hotkeys.take_presses()[0]["registeredWithRun"])


if __name__ == "__main__":
    unittest.main()
