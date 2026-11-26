"""D-U3: contribution export keeps only farm-run JSON logs with account names hashed."""
import json
from pathlib import Path
import tempfile
import unittest
import zipfile

from pokiguard_v2.contribution_export import DRIVE_URL, export_contribution
from tests.reasoning_test_paths import reasoning_temp_root


class ContributionExportTests(unittest.TestCase):
    def test_names_hashed_as_keys_and_values_and_manifest_written(self):
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as d:
            root = Path(d) / 'farm_runs' / 'run1' / 'matches' / 'attempt_001'
            root.mkdir(parents=True)
            row = dict(event='combat_outcome', actorUsername='alice', playersStateDelta={'alice': dict(hp=5), 'bob': dict(hp=7)},
                       targetUsername='bob', path=str(Path.home() / 'x.txt'))
            (root / 'combat.jsonl').write_text(json.dumps(row) + '\n{broken\n', encoding='utf-8')
            (Path(d) / 'farm_runs' / 'run1' / 'notes.txt').write_text('alice', encoding='utf-8')
            out = export_contribution(Path(d) / 'farm_runs', Path(d) / 'exports', now=0)
            with zipfile.ZipFile(out) as z:
                names = set(z.namelist())
                self.assertEqual({'farm_runs/run1/matches/attempt_001/combat.jsonl', 'manifest.json'}, names)
                text = z.read('farm_runs/run1/matches/attempt_001/combat.jsonl').decode('utf-8')
                manifest = json.loads(z.read('manifest.json'))
        self.assertNotIn('alice', text)
        self.assertNotIn('bob', text)
        self.assertNotIn(Path.home().name, text)
        self.assertEqual(1, len(text.strip().splitlines()))  # the broken line is dropped
        self.assertEqual(2, manifest['hashed_account_names'])
        self.assertTrue(DRIVE_URL.startswith('https://drive.google.com/'))


if __name__ == '__main__':
    unittest.main()
