"""B14 native result/presentation fixtures; all executor inputs are fake."""
from dataclasses import replace
import hashlib
import json
from pathlib import Path
from types import SimpleNamespace
import unittest
from unittest.mock import patch

from pokiguard_v2.combat_lifecycle import CombatLifecycleState
from pokiguard_v2.farm_run import MatchResult
from pokiguard_v2.postmatch_ui import locate_result_confirm, prove_stable_result_confirm
from pokiguard_v2.win32_input import ClickPointResult, ClickStatus
from pokiguard_v2.win32_screenshot import read_png_rgb
from tests.test_farm_run import start_run, enter, session
from tests.test_game_update_1749 import painted, scaled
from tools.farm_run import _confirm_postmatch

ROOT = Path(__file__).resolve().parents[1]
FIXTURES = ROOT / 'tests/fixtures/petpuzzle_b14_result_20261101'


class PostmatchB14UiTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.victory = read_png_rgb(FIXTURES / 'victory.png')
        cls.presentation = read_png_rgb(FIXTURES / 'presentation.png')

    def test_native_ready_button_and_presentation_are_distinguished(self):
        p, a = self.victory, self.presentation
        ready = locate_result_confirm(p.rgb, p.width, p.height)
        pending = locate_result_confirm(a.rgb, a.width, a.height)
        self.assertTrue(ready.found, ready)
        self.assertEqual(ready.metrics['layoutVariant'], 'PETPUZZLE_B14_RESULT')
        self.assertEqual(ready.metrics['arenaHeaderVariant'], 'VICTORY_ICE_WINGS')
        self.assertAlmostEqual(ready.normalized_point[0], .5, delta=.006)
        self.assertAlmostEqual(ready.normalized_point[1], .834, delta=.006)
        self.assertFalse(pending.found)
        self.assertFalse(prove_stable_result_confirm([pending, ready, ready], required_frames=3).proven)
        self.assertTrue(prove_stable_result_confirm([ready] * 3, required_frames=3).proven)

    def test_scaled_profiles_preserve_ready_vs_animation_proof(self):
        # Resampling one native observation is regression, not four live tests.
        for width, height in ((800, 400), (960, 480), (1120, 560), (1280, 640)):
            with self.subTest(profile=(width, height)):
                p, a = scaled(self.victory, width, height), scaled(self.presentation, width, height)
                ready = locate_result_confirm(p.rgb, width, height)
                self.assertTrue(ready.found, ready)
                self.assertEqual(ready.metrics['layoutVariant'], 'PETPUZZLE_B14_RESULT')
                self.assertAlmostEqual(ready.normalized_point[0], .5, delta=.006)
                self.assertAlmostEqual(ready.normalized_point[1], .834, delta=.006)
                self.assertFalse(locate_result_confirm(a.rgb, width, height).found)

    def test_each_new_gold_corner_remains_mandatory(self):
        p = self.victory
        for box in ((.22, .29, .27, .38), (.73, .29, .78, .38),
                    (.22, .90, .27, .98), (.73, .90, .78, .98)):
            with self.subTest(corner=box):
                rgb = painted(p, box, bytes((10, 10, 10)))
                self.assertFalse(locate_result_confirm(rgb, p.width, p.height).found)

    def test_each_wing_and_blue_panel_remain_mandatory(self):
        p = self.victory
        for box in ((.30, .025, .48, .24), (.52, .025, .70, .24), (.15, .25, .85, .78)):
            with self.subTest(anchor=box):
                rgb = painted(p, box, bytes((10, 10, 10)))
                self.assertFalse(locate_result_confirm(rgb, p.width, p.height).found)

    def test_green_button_without_ready_label_is_not_clickable(self):
        p = self.victory
        rgb = painted(p, (.42, .81, .58, .87), bytes((70, 200, 20)))
        self.assertFalse(locate_result_confirm(rgb, p.width, p.height).found)

    def test_two_labelled_green_buttons_remain_ambiguous(self):
        p = self.victory
        rgb = painted(p, (.255, .79, .40, .88), bytes((70, 200, 20)))
        rgb = painted(replace(p, rgb=rgb), (.28, .81, .36, .86), bytes((245, 245, 245)))
        self.assertFalse(locate_result_confirm(rgb, p.width, p.height).found)

    def test_other_real_dialogs_and_boss_lobby_are_not_result_buttons(self):
        for relative in ('recovery_ui/health_370_minutes.png',
                         'recovery_ui/confirm_leave_1280x640.png',
                         'petpuzzle_1_7_4_9/boss_lobby.png'):
            with self.subTest(frame=relative):
                p = read_png_rgb(ROOT / 'tests/fixtures' / relative)
                self.assertFalse(locate_result_confirm(p.rgb, p.width, p.height).found)

    def test_real_postmatch_owner_waits_then_confirms_exactly_once(self):
        run = start_run()
        enter(run, session(1))
        self.assertTrue(run.normal_combat_ended(MatchResult.WIN))
        self.assertTrue(run.observe_postmatch())
        lifecycle = CombatLifecycleState.POSTMATCH
        points = []
        def poll():
            return SimpleNamespace(combat_lifecycle=SimpleNamespace(state=lifecycle), state=None)
        def send(binding, point, **kwargs):
            nonlocal lifecycle
            points.append(point)
            lifecycle = CombatLifecycleState.LOBBY
            return ClickPointResult(ClickStatus.SENT)
        executor = SimpleNamespace(window_status=lambda _: SimpleNamespace(valid=True, foreground=True),
                                   send_normalized_point=send)
        captures = [self.presentation] + [self.victory] * 4
        with patch('tools.farm_run.capture_client_rgb', side_effect=captures), \
             patch('tools.farm_run.write_png_rgb'):
            confirmed, _, _ = _confirm_postmatch(
                run=run, process=SimpleNamespace(pid=0, is_running=lambda: True),
                provider=SimpleNamespace(poll=poll), binding=object(), executor=executor,
                directory=Path('unused'), interval=.12, ui_timeout=30,
                hotkeys=SimpleNamespace(poll=lambda: (False, False)), sleeper=lambda _: None)
        self.assertTrue(confirmed)
        self.assertEqual(len(points), 1)
        self.assertAlmostEqual(points[0][0], .5, delta=.006)
        self.assertAlmostEqual(points[0][1], .834, delta=.006)
        self.assertEqual(run.snapshot().total_postmatch_inputs, 1)
        self.assertEqual(run.snapshot().wins, 1)

    def test_native_fixture_and_reviewed_source_hashes_are_pinned(self):
        proof = json.loads((FIXTURES / 'provenance.json').read_text('utf-8'))
        for row in proof['images']:
            self.assertEqual(hashlib.sha256((FIXTURES / row['file']).read_bytes()).hexdigest(), row['sha256'])
        source = proof['source_change']
        followup = proof.get('followup_source_change')
        if followup is not None:
            self.assertEqual(followup['before_sha256'], source['after_sha256'])
            source = followup
        # Retain original win/loss proof bytes; the transparency regression is
        # a separately reviewed successor, with an exact hash chain.
        successor = json.loads((ROOT / 'tests/fixtures/petpuzzle_b14_result_20261102_transparency/provenance.json').read_text('utf-8'))['source_change']
        self.assertEqual(source['after_sha256'], successor['before_sha256'])
        self.assertEqual(hashlib.sha256((ROOT / successor['path']).read_bytes()).hexdigest(), successor['after_sha256'])


if __name__ == '__main__':
    unittest.main()
