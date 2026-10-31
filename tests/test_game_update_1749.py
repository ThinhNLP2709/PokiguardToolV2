"""1.7.4.9 compatibility evidence: independent Inspector and operator frames."""
from __future__ import annotations

import ast
import json
from pathlib import Path
import unittest
from unittest.mock import patch
from tests.game_update_fixture import historical_test_view, before_b10_path

from pokiguard_v2.boss_entry_ui import (
    locate_chinh_phuc_start, locate_detached_chinh_phuc_room_shell_exit,
)
from pokiguard_v2.postmatch_ui import locate_result_confirm, prove_stable_result_confirm
from pokiguard_v2.win32_screenshot import PngRgbImage, read_png_rgb


ROOT = Path(__file__).resolve().parents[1]
FIXTURES = ROOT/'tests/fixtures/petpuzzle_1_7_4_9'
EVIDENCE = ROOT/'docs/artifacts/game_1_7_4_9_20261020'


def historical_constant(module, name):
    # Compare the original 1.7.4.9 implementation with its own Inspector,
    # through an exact audited test view; current b10 is tested separately.
    path = before_b10_path(ROOT,'src/pokiguard_v2/'+module)
    tree = ast.parse(path.read_text('utf-8'))
    node = next(n for n in tree.body if isinstance(n,ast.Assign)
                and any(isinstance(t,ast.Name) and t.id == name for t in n.targets))
    return ast.literal_eval(node.value)


def scaled(image: PngRgbImage, width: int, height: int) -> PngRgbImage:
    # Dependency-free nearest sampling; these are transformed test fixtures,
    # not independent live observations on those window profiles.
    rows = []
    for y in range(height):
        row = bytearray()
        for x in range(width):
            i = ((y*image.height//height)*image.width+x*image.width//width)*3
            row.extend(image.rgb[i:i+3])
        rows.append(row)
    return PngRgbImage(width, height, b''.join(rows))


def painted(image: PngRgbImage, box: tuple[float, float, float, float], color: bytes) -> bytes:
    result = bytearray(image.rgb)
    left, top, right, bottom = box
    x0, x1 = round(left*image.width), round(right*image.width)
    for y in range(round(top*image.height), round(bottom*image.height)):
        result[(y*image.width+x0)*3:(y*image.width+x1)*3] = color*(x1-x0)
    return bytes(result)


class GameUpdate1749VisualTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls) -> None:
        cls.victory = read_png_rgb(FIXTURES/'victory.png')
        cls.lobby = read_png_rgb(FIXTURES/'boss_lobby.png')

    def test_real_victory_and_scaled_profiles(self) -> None:
        for width, height in ((1281, 637), (800, 400), (960, 480), (1120, 560), (1280, 640)):
            with self.subTest(profile=(width, height)):
                image = scaled(self.victory, width, height)
                found = locate_result_confirm(image.rgb, width, height)
                self.assertTrue(found.found, found)
                self.assertEqual(found.metrics['layoutVariant'], 'PETPUZZLE_1_7_4_9_ARENA_RESULT')
                self.assertAlmostEqual(found.normalized_point[0], .498, delta=.006)
                self.assertAlmostEqual(found.normalized_point[1], .837, delta=.006)
                self.assertFalse(prove_stable_result_confirm([found]).proven)
                self.assertTrue(prove_stable_result_confirm([found, found]).proven)

    def test_other_real_screens_do_not_authorize_result_click(self) -> None:
        for name in ('boss_lobby', 'boss_map', 'island_map', 'main_lobby'):
            with self.subTest(screen=name):
                p = read_png_rgb(FIXTURES/(name+'.png'))
                self.assertFalse(locate_result_confirm(p.rgb, p.width, p.height).found)

    def test_animation_missing_label_panel_or_independent_art_fails_closed(self) -> None:
        p = self.victory
        for box, color in (
            ((.408,.785,.590,.889), bytes((70,200,20))),  # unlabelled button
            ((.15,.26,.85,.75), bytes((10,10,10))),      # no result body
            ((.30,.025,.48,.24), bytes((10,10,10))),    # missing wing
            ((.16,.26,.22,.36), bytes((10,10,10))),     # missing gold corner
            ((.41,.78,.59,.90), bytes((10,10,10))),     # no button
        ):
            with self.subTest(box=box):
                self.assertFalse(locate_result_confirm(painted(p, box, color), p.width, p.height).found)

    def test_two_green_confirmations_are_ambiguous(self) -> None:
        p = self.victory
        rgb = painted(p, (.255,.79,.40,.90), bytes((70,200,20)))
        self.assertFalse(locate_result_confirm(rgb, p.width, p.height).found)

    def test_new_red_start_uses_supplied_runtime_rectangle(self) -> None:
        p = self.lobby
        # A fixture-only annotation of the visible button, never a runtime
        # coordinate. Production gets this from ManagerRoom.ButtonStart.
        rect = (.715,.83,.91,.90)
        found = locate_chinh_phuc_start(p.rgb, p.width, p.height, expected_rect=rect)
        self.assertTrue(found.found, found)
        self.assertEqual(found.metrics['geometrySource'], 'ManagerRoom.ButtonStart')
        exit_location = locate_detached_chinh_phuc_room_shell_exit(
            p.rgb, p.width, p.height, expected_start_rect=rect,
        )
        self.assertTrue(exit_location.found, exit_location)
        self.assertGreater(exit_location.normalized_point[0], .94)


class GameUpdate1749LayoutTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls) -> None:
        cls.audit = json.loads((EVIDENCE/'static_audit.json').read_text(encoding='utf-8'))

    @historical_test_view()
    def test_read_offsets_match_inspector_field_identity(self) -> None:
        from tools.audit_game_update import fields
        for row in self.audit['offset_candidates']:
            with self.subTest(module=row['module'], field=row['field']):
                path = ROOT/'reverse/reverse_1.7.4.9/cs/Assembly-CSharp'/(row['class']+'.cs')
                expected = fields(path)[row['field']]
                self.assertEqual(historical_constant(row['module'],row['constant']),expected['offset'])
                self.assertEqual(expected['type'],row['old_type'])

    @historical_test_view()
    def test_typeinfo_uses_exact_inspector_symbol_and_type(self) -> None:
        from tools.audit_game_update import address_map
        new = address_map(ROOT/'reverse/reverse_1.7.4.9')
        symbols = {tuple(x[k] for k in ('name','type','dotNetType')):x for x in new['typeInfoPointers']}
        for row in self.audit['typeinfo']:
            with self.subTest(constant=row['constant']):
                if row['constant']=='CHAT_SERVICE_MESSAGE_CLOSURE_TYPE_INFO_RVA':
                    key=('_ZN8TypeInfo11ChatService22__c__DisplayClass321_0E',
                         'struct ChatService_c_DisplayClass321_0__Class *','__c__DisplayClass321_0')
                else:
                    key=tuple(row['symbol'][k] for k in ('name','type','dotNetType'))
                self.assertEqual(historical_constant(row['module'],row['constant']),int(symbols[key]['virtualAddress'],16)-0x180000000)

    def test_only_migrated_gameassembly_is_allowed(self) -> None:
        from pokiguard_v2.game_location import SUPPORTED_GAME_ASSEMBLY_SHA256
        # The b10 tables must never admit the historical 1.7.4.9 binary.
        self.assertNotIn('4a8925cebbcc9004a4954dad8f04cadf01cf759ff418f84528053552e0cf156b',
                         SUPPORTED_GAME_ASSEMBLY_SHA256)
        self.assertNotIn('72d10a43fbfdab705e2db7caca1cc2b998b0b8581d56946dc545d87c720ec063',
                         SUPPORTED_GAME_ASSEMBLY_SHA256)

    @historical_test_view()
    def test_historical_fixture_view_pins_both_sides_and_rejects_tampering(self) -> None:
        from tests.game_update_fixture import before_game_update_path
        name='src/pokiguard_v2/postmatch_ui.py'
        saved=before_game_update_path(ROOT,name)
        self.assertEqual(saved,EVIDENCE/'before'/name)
        read=Path.read_bytes
        for target in (ROOT/name,saved,EVIDENCE/'historical_fixture_manifest.json'):
            with self.subTest(target=target):
                def changed(path):
                    data=read(path)
                    return data+b'\n# unreviewed modification\n' if path==target else data
                with patch.object(Path,'read_bytes',changed),self.assertRaises(AssertionError):
                    before_game_update_path(ROOT,name)

    def test_default_qualifier_still_rejects_current_source_as_old_acceptance(self) -> None:
        from tests.game_update_fixture import before_game_update_path
        from tests.reasoning_controller_fixture import assert_c3_source_compatibility
        self.assertEqual(before_game_update_path(ROOT,'src/pokiguard_v2/postmatch_ui.py'),
                         ROOT/'src/pokiguard_v2/postmatch_ui.py')
        # The controller alone is unchanged and may pass its AST sub-audit.
        # Qualification must still fail the complete current source binding.
        with self.assertRaises(AssertionError):
            assert_c3_source_compatibility(unittest.TestCase())


if __name__ == '__main__':
    unittest.main()
