"""Replay the supplied six-win stop with a T-Rex chest and five rewards."""

from dataclasses import replace
import hashlib
import json
from pathlib import Path
from types import SimpleNamespace
import unittest
from unittest.mock import patch

from pokiguard_v2.combat_lifecycle import CombatLifecycleState
from pokiguard_v2.farm_run import FarmRunState, MatchResult
from pokiguard_v2.boss_entry import BossLobbyState
from pokiguard_v2.postmatch_ui import locate_result_confirm, prove_stable_result_confirm
from pokiguard_v2.win32_input import ClickPointResult, ClickStatus
from pokiguard_v2.win32_screenshot import read_png_rgb
from tests.test_farm_run import enter, session, start_run
from tests.test_game_update_1749 import painted, scaled
from tools.farm_run import _confirm_postmatch


FIXTURES = Path(__file__).parent / "fixtures/postmatch_many_rewards_20261112"


class PostmatchManyRewardsTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.ready = read_png_rgb(FIXTURES / "ready.png")
        cls.presentation = read_png_rgb(FIXTURES / "presentation.png")

    def test_chest_rewards_and_pending_animation_across_supported_profiles(self):
        for width, height in ((800, 400), (960, 480), (1120, 560), (1280, 640)):
            with self.subTest(profile=(width, height)):
                ready = scaled(self.ready, width, height)
                location = locate_result_confirm(ready.rgb, width, height)
                self.assertTrue(location.found, location)
                self.assertEqual(location.metrics["layoutVariant"], "PETPUZZLE_B14_RESULT")
                self.assertEqual(location.metrics["arenaHeaderVariant"], "VICTORY_ICE_WINGS")
                self.assertAlmostEqual(location.normalized_point[0], .5, delta=.006)
                self.assertAlmostEqual(location.normalized_point[1], .834, delta=.006)
                pending = scaled(self.presentation, width, height)
                self.assertFalse(locate_result_confirm(pending.rgb, width, height).found)

    def test_reward_occlusion_still_requires_corners_header_and_label(self):
        p = self.ready
        for box in (
            (.22, .29, .27, .38), (.73, .29, .78, .38),
            (.22, .90, .27, .98), (.73, .90, .78, .98),
            (.30, .025, .48, .24), (.52, .025, .70, .24),
            (.40, .77, .60, .90), (.22, .38, .78, .90),
        ):
            with self.subTest(anchor=box):
                self.assertFalse(locate_result_confirm(
                    painted(p, box, bytes((10, 10, 10))), p.width, p.height,
                ).found)
        self.assertFalse(locate_result_confirm(
            painted(p, (.42, .81, .58, .87), bytes((70, 200, 20))), p.width, p.height,
        ).found)
        second = painted(p, (.255, .79, .40, .88), bytes((70, 200, 20)))
        second = painted(replace(p, rgb=second), (.28, .81, .36, .86), bytes((245, 245, 245)))
        self.assertFalse(locate_result_confirm(second, p.width, p.height).found)

    def test_pending_reward_frame_cannot_supply_one_of_three_ready_frames(self):
        p, a = self.ready, self.presentation
        ready = locate_result_confirm(p.rgb, p.width, p.height)
        pending = locate_result_confirm(a.rgb, a.width, a.height)
        self.assertFalse(prove_stable_result_confirm([pending, ready, ready], required_frames=3).proven)
        self.assertTrue(prove_stable_result_confirm([ready] * 3, required_frames=3).proven)

    def test_postmatch_confirms_once_and_permits_the_next_entry(self):
        run = start_run()
        enter(run, session(1))
        self.assertTrue(run.normal_combat_ended(MatchResult.WIN))
        self.assertTrue(run.observe_postmatch())
        lifecycle = CombatLifecycleState.POSTMATCH
        points = []
        frames = iter([self.presentation] + [self.ready] * 4)
        frame_count = 0

        def capture(_pid):
            nonlocal frame_count
            frame_count += 1
            return next(frames)

        def poll():
            return SimpleNamespace(combat_lifecycle=SimpleNamespace(state=lifecycle), state=None)

        def send(_binding, point, **_kwargs):
            nonlocal lifecycle
            self.assertGreaterEqual(frame_count, 4)
            points.append(point)
            lifecycle = CombatLifecycleState.LOBBY
            return ClickPointResult(ClickStatus.SENT)

        executor = SimpleNamespace(
            window_status=lambda _: SimpleNamespace(valid=True, foreground=True),
            send_normalized_point=send,
        )
        with patch("tools.farm_run.capture_client_rgb", side_effect=capture), patch(
            "tools.farm_run.write_png_rgb"
        ):
            confirmed, _, _ = _confirm_postmatch(
                run=run, process=SimpleNamespace(pid=0, is_running=lambda: True),
                provider=SimpleNamespace(poll=poll), binding=object(), executor=executor,
                directory=Path("unused"), interval=.12, ui_timeout=30,
                hotkeys=SimpleNamespace(poll=lambda: (False, False)), sleeper=lambda _: None,
            )
        self.assertTrue(confirmed)
        self.assertEqual(len(points), 1)
        self.assertEqual(run.snapshot().total_postmatch_inputs, 1)
        self.assertEqual(run.wins, 1)
        self.assertTrue(run.observe_return_lobby(BossLobbyState.BOSS_LOBBY))
        self.assertTrue(run.target_resolved(exact=True))
        self.assertEqual(run.state, FarmRunState.ENTRY_READY)

    def test_native_frames_and_original_failed_measurement_are_preserved(self):
        proof = json.loads((FIXTURES / "provenance.json").read_text(encoding="utf-8"))
        self.assertEqual(proof["farm_run_id"], "8cb2cb5d5aff4ebfa9fcd33d59c9ff37")
        self.assertEqual(proof["attempt"], 6)
        failed = proof["observed_failure"]["last_location"]
        self.assertLess(
            failed["metrics"]["arenaPanelLargestPixels"],
            failed["metrics"]["arenaPanelMinimumPixels"],
        )
        for row in proof["images"]:
            self.assertEqual(
                row["sha256"], hashlib.sha256((FIXTURES / row["file"]).read_bytes()).hexdigest(),
            )
