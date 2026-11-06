"""Replay the 132/550 stop: translucent B14 panel, all native inputs fake."""
from dataclasses import replace
import hashlib,importlib.util,importlib.machinery,json,sys,unittest
from pathlib import Path
from types import SimpleNamespace
from unittest.mock import patch

from pokiguard_v2.combat_lifecycle import CombatLifecycleState
from pokiguard_v2.farm_run import MatchResult
from pokiguard_v2.postmatch_ui import locate_result_confirm,prove_stable_result_confirm
from pokiguard_v2.win32_input import ClickPointResult,ClickStatus
from pokiguard_v2.win32_screenshot import read_png_rgb
from tests.test_farm_run import start_run,enter,session
from tests.test_game_update_1749 import painted,scaled
from tools.farm_run import _confirm_postmatch

ROOT=Path(__file__).resolve().parents[1]
FIXTURES=ROOT/'tests/fixtures/petpuzzle_b14_result_20261102_transparency'


class B14TransparencyTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.ready=read_png_rgb(FIXTURES/'ready.png')
        cls.pending=read_png_rgb(FIXTURES/'presentation.png')

    def test_original_native_frame_fails_before_fix_and_succeeds_with_independent_anchors(self):
        name='pokiguard_v2._transparency_before_offline_only'
        path=FIXTURES/'before_postmatch_ui.py.txt'
        spec=importlib.util.spec_from_loader(name,importlib.machinery.SourceFileLoader(name,str(path)));old=importlib.util.module_from_spec(spec)
        sys.modules[name]=old
        try:
            spec.loader.exec_module(old)
            self.assertFalse(old.locate_result_confirm(self.ready.rgb,self.ready.width,self.ready.height).found)
        finally:sys.modules.pop(name,None)
        r=locate_result_confirm(self.ready.rgb,self.ready.width,self.ready.height)
        self.assertTrue(r.found,r)
        self.assertEqual('PETPUZZLE_B14_RESULT',r.metrics['layoutVariant'])
        self.assertEqual('VICTORY_ICE_WINGS',r.metrics['arenaHeaderVariant'])
        self.assertGreaterEqual(r.metrics['arenaPanelLargestPixels'],r.metrics['arenaPanelMinimumPixels'])
        self.assertEqual(1,r.metrics['arenaButtonCandidates'])
        for i in range(4):self.assertGreater(r.metrics[f'arenaGoldCorner{i}Pixels'],500)
        self.assertAlmostEqual(.5,r.normalized_point[0],delta=.006)
        self.assertAlmostEqual(.834375,r.normalized_point[1],delta=.006)

    def test_animation_still_waits_for_ready_button_and_three_frames(self):
        a=locate_result_confirm(self.pending.rgb,self.pending.width,self.pending.height)
        r=locate_result_confirm(self.ready.rgb,self.ready.width,self.ready.height)
        self.assertFalse(a.found);self.assertEqual(0,a.metrics['arenaButtonCandidates'])
        self.assertFalse(prove_stable_result_confirm([a,r,r],required_frames=3).proven)
        self.assertTrue(prove_stable_result_confirm([r]*3,required_frames=3).proven)

    def test_supported_resampled_profiles_keep_the_same_ready_point(self):
        for w,h in ((800,400),(960,480),(1120,560),(1280,640)):
            p=scaled(self.ready,w,h);r=locate_result_confirm(p.rgb,w,h)
            with self.subTest(size=(w,h)):
                self.assertTrue(r.found,r)
                self.assertAlmostEqual(.5,r.normalized_point[0],delta=.006)
                self.assertAlmostEqual(.834375,r.normalized_point[1],delta=.006)

    def test_corners_wings_and_label_remain_mandatory_on_the_failed_frame(self):
        for box in ((.22,.29,.27,.38),(.73,.29,.78,.38),(.22,.90,.27,.98),(.73,.90,.78,.98),
                (.30,.025,.48,.24),(.52,.025,.70,.24)):
            with self.subTest(anchor=box):
                self.assertFalse(locate_result_confirm(painted(self.ready,box,bytes((10,10,10))),1280,640).found)
        self.assertFalse(locate_result_confirm(painted(self.ready,(.42,.81,.58,.87),bytes((70,200,20))),1280,640).found)

    def test_panel_blue_is_still_required_despite_header_corners_and_ready_button(self):
        p=self.ready;rgb=bytearray(p.rgb)
        for y in range(round(.29*p.height),round(.98*p.height)):
            for x in range(round(.22*p.width),round(.78*p.width)):
                o=(y*p.width+x)*3;r,g,b=rgb[o:o+3]
                if b>=110 and g>=60 and b>=r+35:rgb[o:o+3]=bytes((30,30,30))
        self.assertFalse(locate_result_confirm(bytes(rgb),p.width,p.height).found)

    def test_blue_scenery_outside_frame_does_not_widen_the_panel(self):
        rgb=painted(self.ready,(.15,.29,.22,.98),bytes((30,100,220)))
        self.assertTrue(locate_result_confirm(rgb,1280,640).found)

    def test_two_labelled_buttons_are_still_rejected(self):
        p=self.ready;rgb=painted(p,(.255,.79,.40,.88),bytes((70,200,20)))
        rgb=painted(replace(p,rgb=rgb),(.28,.81,.36,.86),bytes((245,245,245)))
        self.assertFalse(locate_result_confirm(rgb,1280,640).found)

    def test_postmatch_owner_replays_pending_then_ready_and_clicks_once(self):
        run=start_run();enter(run,session(1));run.normal_combat_ended(MatchResult.WIN);run.observe_postmatch()
        state=CombatLifecycleState.POSTMATCH;points=[]
        def poll():return SimpleNamespace(combat_lifecycle=SimpleNamespace(state=state),state=None)
        def send(binding,point,**kwargs):
            nonlocal state
            points.append(point);state=CombatLifecycleState.LOBBY
            return ClickPointResult(ClickStatus.SENT)
        executor=SimpleNamespace(window_status=lambda _:SimpleNamespace(valid=True,foreground=True),send_normalized_point=send)
        with patch('tools.farm_run.capture_client_rgb',side_effect=[self.pending]+[self.ready]*4),patch('tools.farm_run.write_png_rgb'):
            confirmed,_,_=_confirm_postmatch(run=run,process=SimpleNamespace(pid=0,is_running=lambda:True),
                provider=SimpleNamespace(poll=poll),binding=object(),executor=executor,directory=Path('unused'),
                interval=.12,ui_timeout=30,hotkeys=SimpleNamespace(poll=lambda:(False,False)),sleeper=lambda _:None)
        self.assertTrue(confirmed);self.assertEqual(1,len(points));self.assertEqual(1,run.snapshot().total_postmatch_inputs)
        self.assertEqual(1,run.snapshot().wins)

    def test_source_and_native_image_provenance_is_hash_pinned(self):
        proof=json.loads((FIXTURES/'provenance.json').read_text('utf-8'))
        self.assertFalse(proof['live_after_fix'])
        for row in proof['images']:
            self.assertEqual(row['sha256'],hashlib.sha256((FIXTURES/row['file']).read_bytes()).hexdigest())
            self.assertEqual((row['width'],row['height']),(1280,640))
        source=proof['source_change']
        self.assertEqual(source['after_sha256'],hashlib.sha256((ROOT/source['path']).read_bytes()).hexdigest())
        self.assertEqual(source['before_sha256'],hashlib.sha256((FIXTURES/'before_postmatch_ui.py.txt').read_bytes()).hexdigest())


if __name__=='__main__':unittest.main()
