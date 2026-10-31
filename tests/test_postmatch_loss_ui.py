"""Native b12 defeat modal and real postmatch owner with fake input only."""
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

FIXTURES = Path(__file__).resolve().parent/'fixtures/petpuzzle_b12_loss_20261029'


class PostmatchLossUiTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.loss = read_png_rgb(FIXTURES/'loss.png')
        cls.presentation = read_png_rgb(FIXTURES/'presentation.png')

    def test_native_loss_finds_actual_labelled_green_button(self):
        p = self.loss
        location = locate_result_confirm(p.rgb, p.width, p.height)
        self.assertTrue(location.found, location)
        self.assertEqual(location.metrics['arenaHeaderVariant'], 'DEFEAT_PURPLE_CREST')
        self.assertAlmostEqual(location.normalized_point[0], .5, delta=.008)
        self.assertAlmostEqual(location.normalized_point[1], .83, delta=.012)

    def test_transformed_profiles_keep_same_button_geometry(self):
        # These are transformations of one native observation, not four live runs.
        for width,height in ((800,400),(960,480),(1120,560),(1280,640)):
            with self.subTest(profile=(width,height)):
                p = scaled(self.loss,width,height)
                location = locate_result_confirm(p.rgb,width,height)
                self.assertTrue(location.found,location)
                self.assertAlmostEqual(location.normalized_point[0],.5,delta=.008)
                self.assertAlmostEqual(location.normalized_point[1],.83,delta=.012)

    def test_terminal_animation_does_not_authorize_a_click(self):
        p = self.presentation
        self.assertFalse(locate_result_confirm(p.rgb,p.width,p.height).found)

    def test_each_independent_defeat_header_anchor_is_required(self):
        p = self.loss
        for box in ((.30,.025,.43,.18),(.57,.025,.70,.18),
                    (.45,.28,.55,.44),(.44,.18,.56,.26)):
            with self.subTest(anchor=box):
                rgb = painted(p,box,bytes((10,10,10)))
                self.assertFalse(locate_result_confirm(rgb,p.width,p.height).found)

    def test_panel_corner_button_and_ready_label_are_still_required(self):
        p = self.loss
        for box,color in (((.15,.28,.85,.76),bytes((10,10,10))),
                          ((.16,.26,.22,.36),bytes((10,10,10))),
                          ((.40,.77,.60,.90),bytes((10,10,10))),
                          ((.408,.785,.590,.889),bytes((70,200,20)))):
            with self.subTest(box=box):
                self.assertFalse(locate_result_confirm(painted(p,box,color),p.width,p.height).found)

    def test_two_green_buttons_are_still_ambiguous(self):
        p = self.loss
        rgb = painted(p,(.255,.79,.40,.90),bytes((70,200,20)))
        self.assertFalse(locate_result_confirm(rgb,p.width,p.height).found)

    def test_three_stable_native_loss_frames_are_required(self):
        p = self.loss
        location = locate_result_confirm(p.rgb,p.width,p.height)
        self.assertFalse(prove_stable_result_confirm([location],required_frames=3).proven)
        self.assertTrue(prove_stable_result_confirm([location]*3,required_frames=3).proven)

    def test_real_postmatch_owner_waits_animation_then_confirms_loss_once(self):
        run = start_run();enter(run,session(1))
        self.assertTrue(run.normal_combat_ended(MatchResult.LOSS))
        self.assertTrue(run.observe_postmatch())
        lifecycle = CombatLifecycleState.POSTMATCH
        polls = 0
        points = []
        def poll():
            nonlocal polls
            polls += 1
            return SimpleNamespace(combat_lifecycle=SimpleNamespace(state=lifecycle),state=None)
        def send(binding,point,**kwargs):
            nonlocal lifecycle
            points.append(point);lifecycle = CombatLifecycleState.LOBBY
            return ClickPointResult(ClickStatus.SENT)
        provider=SimpleNamespace(poll=poll)
        executor=SimpleNamespace(window_status=lambda _:SimpleNamespace(valid=True,foreground=True),
            send_normalized_point=send)
        p=self.loss;a=self.presentation
        captures=([SimpleNamespace(rgb=a.rgb,width=a.width,height=a.height)]+
            [SimpleNamespace(rgb=p.rgb,width=p.width,height=p.height)]*4)
        sleeps=[]
        with patch('tools.farm_run.capture_client_rgb',side_effect=captures), \
             patch('tools.farm_run.write_png_rgb'):
            confirmed,_,_=_confirm_postmatch(run=run,process=SimpleNamespace(pid=0,is_running=lambda:True),
                provider=provider,binding=object(),executor=executor,directory=Path('unused'),
                interval=.12,ui_timeout=30,hotkeys=SimpleNamespace(poll=lambda:(False,False)),
                sleeper=sleeps.append)
        self.assertTrue(confirmed)
        self.assertEqual(len(points),1)
        self.assertEqual(polls,3)
        self.assertEqual(sleeps,[.12]*3)
        self.assertAlmostEqual(points[0][0],.5,delta=.008)
        self.assertAlmostEqual(points[0][1],.83,delta=.012)
        self.assertEqual(run.snapshot().total_postmatch_inputs,1)
        self.assertEqual(run.snapshot().losses,1)


if __name__=='__main__':
    unittest.main()
