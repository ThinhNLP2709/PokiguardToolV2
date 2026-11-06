"""User-supplied B14 defeat screenshot; cropped/resampled offline only."""
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

FIXTURES = Path(__file__).resolve().parent / 'fixtures/petpuzzle_b14_result_20261101'


class PostmatchB14DefeatTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.loss = read_png_rgb(FIXTURES / 'defeat.png')

    def test_supplied_defeat_has_exact_header_and_button(self):
        p = self.loss
        r = locate_result_confirm(p.rgb, p.width, p.height)
        self.assertTrue(r.found, r)
        self.assertEqual(r.metrics['layoutVariant'], 'PETPUZZLE_B14_RESULT')
        self.assertEqual(r.metrics['arenaHeaderVariant'], 'DEFEAT_PURPLE_CREST')
        self.assertAlmostEqual(r.normalized_point[0], .5, delta=.006)
        self.assertAlmostEqual(r.normalized_point[1], .841, delta=.008)

    def test_transformed_supported_profiles_preserve_defeat_proof(self):
        for width, height in ((800, 400), (960, 480), (1120, 560), (1280, 640)):
            with self.subTest(profile=(width, height)):
                p = scaled(self.loss, width, height)
                r = locate_result_confirm(p.rgb, width, height)
                self.assertTrue(r.found, r)
                self.assertEqual(r.metrics['arenaHeaderVariant'], 'DEFEAT_PURPLE_CREST')
                self.assertAlmostEqual(r.normalized_point[0], .5, delta=.006)
                self.assertAlmostEqual(r.normalized_point[1], .841, delta=.008)

    def test_each_horn_crest_and_title_are_independently_required(self):
        p = self.loss
        for box in ((.30, .025, .43, .18), (.57, .025, .70, .18),
                    (.45, .20, .55, .36), (.44, .15, .56, .24)):
            with self.subTest(anchor=box):
                rgb = painted(p, box, bytes((10, 10, 10)))
                self.assertFalse(locate_result_confirm(rgb, p.width, p.height).found)

    def test_each_gold_corner_remains_required_for_defeat(self):
        p = self.loss
        for box in ((.22, .29, .27, .38), (.73, .29, .78, .38),
                    (.22, .90, .27, .98), (.73, .90, .78, .98)):
            with self.subTest(corner=box):
                rgb = painted(p, box, bytes((10, 10, 10)))
                self.assertFalse(locate_result_confirm(rgb, p.width, p.height).found)

    def test_missing_button_or_label_does_not_authorize_input(self):
        p = self.loss
        for box, color in (((.40, .77, .60, .91), bytes((20, 45, 95))),
                           ((.42, .81, .58, .88), bytes((70, 200, 20)))):
            with self.subTest(box=box):
                rgb = painted(p, box, color)
                self.assertFalse(locate_result_confirm(rgb, p.width, p.height).found)

    def test_two_labelled_green_buttons_remain_ambiguous(self):
        p = self.loss
        rgb = painted(p, (.255, .79, .40, .88), bytes((70, 200, 20)))
        rgb = painted(replace(p, rgb=rgb), (.28, .81, .36, .86), bytes((245, 245, 245)))
        self.assertFalse(locate_result_confirm(rgb, p.width, p.height).found)

    def test_actual_postmatch_owner_waits_and_confirms_loss_once(self):
        p = self.loss
        pending = replace(p, rgb=painted(p, (.40, .77, .60, .91), bytes((20, 45, 95))))
        r = locate_result_confirm(p.rgb, p.width, p.height)
        a = locate_result_confirm(pending.rgb, p.width, p.height)
        self.assertFalse(prove_stable_result_confirm([a, r, r], required_frames=3).proven)
        run = start_run()
        enter(run, session(1))
        self.assertTrue(run.normal_combat_ended(MatchResult.LOSS))
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
        with patch('tools.farm_run.capture_client_rgb', side_effect=[pending] + [p] * 4), \
             patch('tools.farm_run.write_png_rgb'):
            confirmed, _, _ = _confirm_postmatch(
                run=run, process=SimpleNamespace(pid=0, is_running=lambda: True),
                provider=SimpleNamespace(poll=poll), binding=object(), executor=executor,
                directory=Path('unused'), interval=.12, ui_timeout=30,
                hotkeys=SimpleNamespace(poll=lambda: (False, False)), sleeper=lambda _: None)
        self.assertTrue(confirmed)
        self.assertEqual(len(points), 1)
        self.assertAlmostEqual(points[0][0], .5, delta=.006)
        self.assertAlmostEqual(points[0][1], .841, delta=.008)
        self.assertEqual(run.snapshot().total_postmatch_inputs, 1)
        self.assertEqual(run.snapshot().losses, 1)
        self.assertEqual(run.snapshot().wins, 0)

    def test_original_and_crop_provenance_are_explicit_and_hash_pinned(self):
        proof = json.loads((FIXTURES / 'defeat_provenance.json').read_text('utf-8'))
        self.assertEqual(proof['origin'], 'USER_SUPPLIED_SCREENSHOT_NOT_TOOL_NATIVE_CAPTURE')
        self.assertEqual(hashlib.sha256((FIXTURES / 'defeat_window.png').read_bytes()).hexdigest(), proof['original_sha256'])
        self.assertEqual(hashlib.sha256((FIXTURES / 'defeat.png').read_bytes()).hexdigest(), proof['crop_sha256'])
        self.assertEqual([self.loss.width, self.loss.height], proof['crop_dimensions'])


if __name__ == '__main__':
    unittest.main()
