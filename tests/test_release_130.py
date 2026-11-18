"""Version-only admission must not loosen gameplay or activate missing profiles."""
from pathlib import Path
import hashlib,unittest
from pokiguard_v2.reasoning_ui_profile import UI_METADATA_130,verify_ui_source_files

ROOT=Path(__file__).resolve().parents[1]


class Release130Tests(unittest.TestCase):
    def test_exact_reviewed_label_files_are_pinned(self):
        for name,expected in UI_METADATA_130.items():
            # Keep the historical 1.3.0 approval pinned to its original bytes.
            # A newer release label must not rewrite the old profile's acceptance identity.
            original=ROOT/'docs/artifacts/rebuild_v1_3_1_20261105/before'/name
            self.assertEqual(expected,hashlib.sha256(original.read_bytes()).hexdigest(),name)

    def test_label_successor_does_not_allow_other_core_edits(self):
        base={'src/pokiguard_v2/basic_policy.py':'accepted',**{n:'old' for n in UI_METADATA_130}}
        current={**base,**UI_METADATA_130}
        verify_ui_source_files(base,current)
        for name in current:
            bad=dict(current);bad[name]='tampered'
            with self.subTest(name=name),self.assertRaises(ValueError):verify_ui_source_files(base,bad)
        missing=dict(current);missing.pop('src/pokiguard_v2/basic_policy.py')
        with self.assertRaises(ValueError):verify_ui_source_files(base,missing)


class CurrentReleaseTests(unittest.TestCase):
    def test_current_label_and_old_130_proof_does_not_upgrade(self):
        from pokiguard_v2.version import APP_VERSION,APP_TITLE,SEMANTIC_VERSION
        self.assertEqual(SEMANTIC_VERSION,'1.3.6')
        self.assertEqual(APP_VERSION,'v1.3.6')
        self.assertEqual(APP_TITLE,'Tool PokiguardV2 - v1.3.6')
        old={n:h for n,h in UI_METADATA_130.items()}
        current={n:hashlib.sha256((ROOT/n).read_bytes()).hexdigest() for n in old}
        self.assertEqual(set(old),{n for n in current if current[n]!=old[n]})
        with self.assertRaisesRegex(ValueError,'VERSION_METADATA_CHANGED'):
            verify_ui_source_files(old,current)


if __name__=='__main__':unittest.main()
