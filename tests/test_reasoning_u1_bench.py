"""U1 same-board corpus: pinned, labelled, file-only and reproducible."""
from collections import Counter
import json
from pathlib import Path
import unittest

from pokiguard_v2.reasoning_common_problem import PROFILES
from tools import reasoning_u1_bench as u1

MANIFEST = Path(__file__).resolve().parents[1] / 'docs/opus/artifacts/u1_20261124/corpus_manifest.json'


class U1BenchTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.corpus = u1.portable_corpus()
        cls.cases = cls.corpus['cases']
        cls.groups = {}
        for case in cls.cases:
            cls.groups.setdefault((case['cohort'], case['kind']), []).append(case)

    def test_portable_corpus_matches_handoff_counts(self):
        self.assertEqual(192, len({c['case_id'] for c in self.cases}))
        self.assertEqual(88, len(self.groups[('ICARUS', 'SWAP_PAIR')]))
        self.assertEqual(14, len(self.groups[('ICARUS', 'SKILL_PRESTATE')]))
        self.assertEqual({'G1': 21, 'G2': 16, 'G3': 22, 'TREX': 10, 'G4': 9},
            {k: len(self.groups[(k, 'SWAP_PAIR')]) for k in ('G1', 'G2', 'G3', 'TREX', 'G4')})

    def test_native_proposals_and_branch_replays_stay_separate(self):
        kinds = {(c['cohort'], c['baseline']['kind'], c['native']['kind']) for c in self.cases if c['kind'] == 'SWAP_PAIR'}
        self.assertEqual({('ICARUS', 'NATIVE_BASIC_INCUMBENT', 'NATIVE_COMMON_WORKER_SENT'),
            ('TREX', 'NATIVE_BASIC_INCUMBENT', 'NATIVE_COMMON_WORKER_SENT'),
            ('G1', 'PRODUCTION_RESOURCE_BRANCH_REPLAY', 'NATIVE_GALAXY_PER_PET_SENT'),
            ('G2', 'PRODUCTION_RESOURCE_BRANCH_REPLAY', 'NATIVE_GALAXY_PER_PET_SENT'),
            ('G3', 'PRODUCTION_RESOURCE_BRANCH_REPLAY', 'NATIVE_GALAXY_PER_PET_SENT'),
            ('G4', 'PRODUCTION_PLAN_G4_REASONING_FALSE_REPLAY', 'NATIVE_PLAN_G4_REASONING_SENT')}, kinds)

    def test_g4_keeps_own_schema_and_terminal_non_acks(self):
        g4 = self.groups[('G4', 'SWAP_PAIR')]
        self.assertNotIn('galaxy_shadow_sword', PROFILES)
        self.assertTrue(all(c['schema'] == 'G4_NATIVE_V1' and c['profile'] == 'galaxy_shadow_sword' for c in g4))
        self.assertEqual(Counter(ACK=6, TERMINAL_NO_PROTOCOL_ACK=3), Counter(c['native']['execution'] for c in g4))
        for case in g4:
            result = u1.run_g4(case)
            self.assertTrue(all(result['parity'][k] for k in ('basic_replay_equals_recorded',
                'native_replay_equals_sent', 'native_facts_equal_logged')))
            self.assertIsNone(result['arms']['common'])

    def test_no_training_quality_or_refill_labels(self):
        for case in self.cases:
            self.assertEqual(u1.LABELS, case['labels'])
        self.assertFalse(u1.LABELS['training_eligible'] or u1.LABELS['independent_holdout'])
        self.assertIsNone(u1.LABELS['quality_label'])

    def test_current_common_replay_reproduces_native_mega_choice(self):
        sample = self.groups[('TREX', 'SWAP_PAIR')] + self.groups[('ICARUS', 'SWAP_PAIR')][:6]
        for case in sample:
            first, second = u1.run_common(case), u1.run_common(case)
            self.assertEqual(u1.canon(first), u1.canon(second))
            self.assertTrue(first['parity']['common_equals_native'])

    def test_opaque_galaxy_skill_is_retained_not_scored(self):
        for cohort in ('G1', 'G2', 'G3', 'G2_BASIC'):
            for case in self.groups[(cohort, 'SKILL_PRESTATE')]:
                result = u1.run_common(case)
                self.assertEqual('COMMON_OPAQUE_OR_UNREPRESENTED_INCUMBENT', result['common']['reason'])
                self.assertEqual('UNKNOWN', result['arms']['basic']['status'])

    def test_frozen_portable_corpus_sha(self):
        if not MANIFEST.is_file():
            self.skipTest('U1 manifest not frozen in this checkout')
        frozen = json.loads(MANIFEST.read_text(encoding='utf-8'))
        portable = next(c for c in frozen['corpora'] if c['tier'] == 'PORTABLE')
        self.assertEqual(portable['sha256'], u1.sha_bytes(u1.dump_bytes(self.corpus)))
        self.assertEqual(portable['cases'], len(self.cases))


if __name__ == '__main__':
    unittest.main()
