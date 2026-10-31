"""Real modal/gem frames and exceptional evidence; no live IO/input."""

from pathlib import Path
import tempfile
from types import SimpleNamespace as NS
import unittest
from unittest.mock import patch

from pokiguard_v2.native_card_ui import NativeButtonGeometry
from pokiguard_v2.play_reminder import PlayReminderControl, locate_play_reminder_confirm
from pokiguard_v2.recovery_ui import locate_confirm_leave
from pokiguard_v2.win32_screenshot import (
    read_png_rgb, configure_diagnostic_image_writes, diagnostic_image_writes_enabled,
)
from tools import basic_auto_bot as bot
from tests.reasoning_controller_fixture import controller_trace


ROOT = Path(__file__).resolve().parents[1]
FIXTURE = ROOT/'tests/fixtures/recovery_ui'


class LeaveModalGuardTests(unittest.TestCase):
    def controller_with_frame(self, folder, capture):
        def hook(_stage, _polls):
            # controller_trace already owns/restores these two patches. Set
            # their values after fixture setup so the real controller uses
            # the real image locator instead of its default no-modal stub.
            bot.capture_client_rgb=lambda _pid: capture
            bot.locate_confirm_leave=locate_confirm_leave
        return controller_trace(Path(folder)/'combat.jsonl',checkpoint_hook=hook)

    def test_actual_controller_withholds_swap_and_retains_the_exact_blocking_frame(self):
        capture=read_png_rgb(FIXTURE/'confirm_leave_1280x640.png')
        with tempfile.TemporaryDirectory() as folder:
            _result,calls,rows=self.controller_with_frame(folder,capture)
            blocked=[r for r in rows if r.get('reason')=='LEAVE_MODAL_VISIBLE_BEFORE_GAMEPLAY_CLICK']
            self.assertEqual(len(blocked),1)
            self.assertTrue(blocked[0]['diagnosticImage']['saved'])
            self.assertNotIn('executor.send_swap',calls)
            self.assertFalse(any(r['event']=='action_sent' for r in rows))
            saved=read_png_rgb(Path(folder)/'leave_modal_swap.png')
            self.assertEqual(saved.rgb,capture.rgb)

    def test_actual_controller_disk_full_still_withholds_swap(self):
        capture=read_png_rgb(FIXTURE/'confirm_leave_1280x640.png')
        with tempfile.TemporaryDirectory() as folder, patch.object(
            bot,'write_failure_png_rgb',side_effect=OSError('disk full')
        ):
            _result,calls,rows=self.controller_with_frame(folder,capture)
            blocked=[r for r in rows if r.get('reason')=='LEAVE_MODAL_VISIBLE_BEFORE_GAMEPLAY_CLICK']
            self.assertEqual(len(blocked),1)
            self.assertFalse(blocked[0]['diagnosticImage']['saved'])
            self.assertFalse(any(r['event']=='action_sent' for r in rows))

    def test_actual_controller_ordinary_board_keeps_swap_path_without_failure_writes(self):
        capture=read_png_rgb(ROOT/'tests/fixtures/petpuzzle_1_7_4_9/combat_opening.png')
        with tempfile.TemporaryDirectory() as folder, patch.object(bot,'write_failure_png_rgb') as writer:
            _result,calls,rows=self.controller_with_frame(folder,capture)
            self.assertTrue(any(r['event']=='action_sent' for r in rows))
            self.assertFalse(any(r.get('reason')=='LEAVE_MODAL_VISIBLE_BEFORE_GAMEPLAY_CLICK' for r in rows))
            writer.assert_not_called()

    def test_real_leave_dialog_keeps_both_button_labels_and_modal_guard(self):
        c=read_png_rgb(FIXTURE/'confirm_leave_1280x640.png')
        result=locate_confirm_leave(c.rgb,c.width,c.height)
        self.assertTrue(result.found,result)
        self.assertGreaterEqual(result.metrics['leftLabelComponents'],3)
        self.assertGreaterEqual(result.metrics['rightLabelComponents'],3)
        self.assertGreater(result.metrics['leftFill'],0.7)
        self.assertTrue(0.38<result.normalized_point[0]<0.43)

    def test_ordinary_board_and_health_reminder_are_not_exit_dialogs(self):
        for p in (ROOT/'tests/fixtures/petpuzzle_1_7_4_9/combat_opening.png',
                  FIXTURE/'health_370_minutes.png'):
            c=read_png_rgb(p)
            self.assertFalse(locate_confirm_leave(c.rgb,c.width,c.height).found,p)

    def test_real_370_minute_reminder_is_accepted_without_reading_its_minutes(self):
        c=read_png_rgb(FIXTURE/'health_370_minutes.png')
        # Annotation is for this supplied full-window image only. Native
        # Button geometry, never these pixel coordinates, supplies live bounds.
        rect=(530/c.width,441/c.height,754/c.width,500/c.height)
        geometry=NativeButtonGeometry(10,11,12,13,14,True,rect,15,c.width/c.height)
        control=PlayReminderControl(True,True,1,2,2,3,geometry)
        result=locate_play_reminder_confirm(c.rgb,c.width,c.height,control)
        self.assertTrue(result.found,result)

    def test_failure_frame_persists_when_routine_images_are_disabled_and_is_bounded(self):
        previous=diagnostic_image_writes_enabled()
        c=read_png_rgb(FIXTURE/'confirm_leave_1280x640.png')
        try:
            configure_diagnostic_image_writes(enabled=False)
            with tempfile.TemporaryDirectory() as folder:
                log=Path(folder)/'combat.jsonl'
                for _ in range(2):
                    for stage in ('swap','cast','card_final'):
                        result=bot._leave_modal_failure_image(c,log,stage)
                        self.assertTrue(result['saved'],result)
                images=list(Path(folder).glob('*.png'))
                self.assertEqual(len(images),3)
                restored=read_png_rgb(images[0])
                self.assertEqual(restored.rgb,c.rgb)
        finally:
            configure_diagnostic_image_writes(enabled=previous)

    def test_disk_failure_reports_unsaved_evidence_without_raising(self):
        c=NS(rgb=b'\0'*12,width=2,height=2)
        with patch.object(bot,'write_failure_png_rgb',side_effect=OSError('disk full')):
            result=bot._leave_modal_failure_image(c,'combat.jsonl','swap')
        self.assertFalse(result['saved'])
        self.assertEqual(result['errorType'],'OSError')
        self.assertIn('disk full',result['error'])

    def test_invalid_evidence_stage_cannot_create_unbounded_paths(self):
        with patch.object(bot,'write_failure_png_rgb') as writer:
            for stage in ('other','../other'):
                result=bot._leave_modal_failure_image(NS(),'combat.jsonl',stage)
                self.assertFalse(result['saved'])
        writer.assert_not_called()


if __name__=='__main__':
    unittest.main()
