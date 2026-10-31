"""Offline input replay against an independently annotated real combat frame."""
from __future__ import annotations

import hashlib
import itertools
import json
from pathlib import Path
import unittest
from unittest.mock import patch

from pokiguard_v2.game_window_size import GameWindowSizeProfile
from pokiguard_v2.runtime_calibration import production_input_calibration
from pokiguard_v2.win32_input import (
    BoardCalibration, ClientGeometry, map_swap_to_pixels,
)
from tests.game_update_fixture import historical_test_view, before_game_update_path

FIXTURES = Path(__file__).parent / 'fixtures/petpuzzle_1_7_4_9'


class BoardMapping1749Tests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.frame = json.loads((FIXTURES/'combat_geometry.json').read_text())

    def test_frame_is_original_client_capture(self):
        raw = (FIXTURES/'combat_opening.png').read_bytes()
        self.assertEqual(hashlib.sha256(raw).hexdigest(), self.frame['image_sha256'])
        self.assertEqual(self.frame['client_size'], [1280, 640])

    def test_defaults_and_production_controller_use_same_calibration(self):
        values = production_input_calibration()
        self.assertEqual(BoardCalibration(), BoardCalibration(
            values['board_first_center_x'], values['board_first_center_y'],
            values['board_step_x'], values['board_step_y'],
        ))

    @patch('pokiguard_v2.win32_input.random.uniform', return_value=0.0)
    def test_all_centres_match_visible_gems(self, _random):
        for row, col in itertools.product(range(8), repeat=2):
            other = (row, col+1 if col < 7 else col-1)
            plan = map_swap_to_pixels((row, col), other, BoardCalibration(),
                                      ClientGeometry(0, 0, 1280, 640))
            self.assertAlmostEqual(plan.first.client_x, self.frame['x_centres'][col], delta=2)
            self.assertAlmostEqual(plan.first.client_y, self.frame['y_centres'][row], delta=2)

    def test_all_112_swaps_keep_ten_percent_jitter_inside_own_gems_on_all_profiles(self):
        swaps = []
        for row, col in itertools.product(range(8), repeat=2):
            if col < 7: swaps.append(((row,col),(row,col+1)))
            if row < 7: swaps.append(((row,col),(row+1,col)))
        self.assertEqual(len(swaps), 112)
        for profile in GameWindowSizeProfile:
            width, height = profile.dimensions
            # Includes a game window on a monitor left of the primary monitor.
            for left, top in ((565,189), (-1280,80)):
                geometry = ClientGeometry(left, top, width, height)
                for first, second in swaps:
                    for jx, jy in itertools.product((-.1,.1), repeat=2):
                        with patch('pokiguard_v2.win32_input.random.uniform',
                                   side_effect=(jx,jy,-jx,-jy)) as random:
                            plan = map_swap_to_pixels(first, second, BoardCalibration(), geometry,
                                virtual_screen=(-2000,0,4000,2000))
                        self.assertEqual(random.call_count, 4)
                        self.assertTrue(all(c.args == (-.1,.1) for c in random.call_args_list))
                        for cell, point in ((first,plan.first),(second,plan.second)):
                            row, col = cell
                            # Independent frame annotations, including their raster tolerance.
                            x = self.frame['x_centres'][col]*(width-1)/1279
                            y = self.frame['y_centres'][row]*(height-1)/639
                            self.assertLessEqual(abs(point.client_x-x), 8*(width-1)/1279+1)
                            self.assertLessEqual(abs(point.client_y-y), 8*(height-1)/639+1)
                            self.assertEqual(point.screen_x, left+point.client_x)
                            self.assertEqual(point.screen_y, top+point.client_y)

    @patch('pokiguard_v2.win32_input.random.uniform', return_value=0.0)
    def test_failed_opening_move_now_hits_intended_rows(self, _random):
        geometry = ClientGeometry(565,189,1280,640)
        # Saved B1 log: intended (0,1)->(1,1), actual first point (520,96).
        # y=96 lies in row 1 on the new board, not the intended row 0.
        self.assertGreater(96, (self.frame['y_centres'][0]+self.frame['y_centres'][1])/2)
        fixed = map_swap_to_pixels((0,1),(1,1),BoardCalibration(),geometry)
        self.assertAlmostEqual(fixed.first.client_x, 490, delta=2)
        self.assertAlmostEqual(fixed.first.client_y, 60, delta=2)
        self.assertAlmostEqual(fixed.second.client_x, 490, delta=2)
        self.assertAlmostEqual(fixed.second.client_y, 119, delta=2)

    @historical_test_view()
    def test_historical_test_view_pins_mapping_successor_predecessor_and_manifest(self):
        root = Path(__file__).resolve().parents[1]
        name = 'src/pokiguard_v2/runtime_calibration.py'
        directory = root/'docs/artifacts/game_1_7_4_9_20261020/board_mapping_fix_20261021'
        saved = before_game_update_path(root, name)
        self.assertEqual(saved, directory/'before'/name)
        read = Path.read_bytes
        for target in (root/name, saved, directory/'historical_fixture_manifest.json'):
            def changed(path):
                data = read(path)
                return data+b'\n# unreviewed edit\n' if path == target else data
            with patch.object(Path,'read_bytes',changed), self.assertRaises(AssertionError):
                before_game_update_path(root, name)


if __name__ == '__main__':
    unittest.main()
