"""Version-only admission must not loosen gameplay or activate missing profiles."""
from pathlib import Path
import hashlib,unittest
from pokiguard_v2.reasoning_ui_profile import UI_METADATA_130,verify_ui_source_files

ROOT=Path(__file__).resolve().parents[1]


class Release130Tests(unittest.TestCase):
    def test_exact_reviewed_label_files_are_pinned(self):
        for name,expected in UI_METADATA_130.items():
            self.assertEqual(expected,hashlib.sha256((ROOT/name).read_bytes()).hexdigest(),name)

    def test_label_successor_does_not_allow_other_core_edits(self):
        base={'src/pokiguard_v2/basic_policy.py':'accepted',**{n:'old' for n in UI_METADATA_130}}
        current={**base,**UI_METADATA_130}
        verify_ui_source_files(base,current)
        for name in current:
            bad=dict(current);bad[name]='tampered'
            with self.subTest(name=name),self.assertRaises(ValueError):verify_ui_source_files(base,bad)
        missing=dict(current);missing.pop('src/pokiguard_v2/basic_policy.py')
        with self.assertRaises(ValueError):verify_ui_source_files(base,missing)


if __name__=='__main__':unittest.main()
