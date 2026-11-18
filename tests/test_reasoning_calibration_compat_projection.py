"""File-only migration review; never manufactures native timing/attempt proof."""
from dataclasses import fields
from pathlib import Path
import subprocess
import unittest
from unittest.mock import patch

from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.reasoning_calibration import decode_config
from tools.qualify_common_reasoning import CHECKPOINT,calibration_ast_projection,calibration_projection,sha,LEGACY_MEGA_DEFAULT_REVIEW_SHA


ROOT=Path(__file__).resolve().parents[1]


class CalibrationCompatibilityProjectionTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        name='src/pokiguard_v2/reasoning_calibration.py'
        cls.previous=subprocess.check_output(['git','show',CHECKPOINT+':'+name],cwd=ROOT)
        cls.current=(ROOT/name).read_bytes()

    def test_exact_reviewed_file_has_full_ast_parity_after_the_specific_migration(self):
        self.assertEqual(LEGACY_MEGA_DEFAULT_REVIEW_SHA,sha(self.current))
        self.assertTrue(calibration_ast_projection(self.previous,self.current))
        self.assertTrue(calibration_projection())

    def test_unreviewed_changes_inside_or_outside_decoder_still_fail(self):
        text=self.current.decode('utf-8')
        mutations=[text.replace("'mega_self_protection' not in raw","'other_missing_field' not in raw",1),
            text.replace('mega_self_protection=default.mega_self_protection.value',"mega_self_protection='hp_below_30'",1),
            text.replace('complete canonical DesktopConfig required','unreviewed decoder edit',1),
            text+'\nUNREVIEWED_TIMING_CHANGE = True\n',
            text.replace('common Demon control requires BASIC-only','changed control requirements',1)]
        for changed in mutations:
            self.assertNotEqual(text,changed)
            with self.subTest(sha=sha(changed.encode())):
                self.assertFalse(calibration_ast_projection(self.previous,changed.encode()))

    def test_changed_default_or_forged_review_hash_cannot_project(self):
        class ChangedDefault:
            class mega_self_protection:
                value='none'
        with patch('pokiguard_v2.desktop_control_plane.DesktopConfig',ChangedDefault):
            self.assertFalse(calibration_ast_projection(self.previous,self.current))
        with patch('tools.qualify_common_reasoning.LEGACY_MEGA_DEFAULT_REVIEW_SHA','0'*64):
            self.assertFalse(calibration_ast_projection(self.previous,self.current))

    def test_legacy_decode_only_backfills_the_one_legacy_30_percent_setting(self):
        config=DesktopConfig();raw=jsonable(config)
        self.assertEqual({f.name for f in fields(config)},set(raw))
        del raw['mega_self_protection']
        restored=decode_config(raw)
        self.assertEqual(config,restored)
        self.assertEqual('hp_below_30',restored.mega_self_protection.value)

    def test_missing_other_fields_unknown_fields_and_invalid_explicit_values_reject(self):
        for change in ('missing','unknown','invalid'):
            raw=jsonable(DesktopConfig());del raw['mega_self_protection']
            if change=='missing':del raw['max_match_attempts']
            elif change=='unknown':raw['UNREVIEWED_EXTRA']=1
            else:raw['mega_self_protection']='UNREVIEWED_ENUM'
            with self.subTest(change=change),self.assertRaises(ValueError):decode_config(raw)

    def test_explicit_current_choices_are_preserved_instead_of_backfilled(self):
        for choice in ('none','hp_below_30','hp_below_10'):
            raw=jsonable(DesktopConfig());raw['mega_self_protection']=choice
            with self.subTest(choice=choice):
                self.assertEqual(choice,decode_config(raw).mega_self_protection.value)


if __name__=='__main__':unittest.main()
