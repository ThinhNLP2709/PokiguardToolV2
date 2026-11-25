"""U4: the transport tap reuses a retained projection of the same immutable response JSON.

Before this, every provider read re-projected every response root it found; with the U2
extras that pushed observation read spans past the 100 ms gate in a live BASIC control.
"""
import unittest
from unittest.mock import patch

import tests.test_combat_outcome_evidence as base
import tools.dispatcher_qte_result_tap as tap_module


class TapProjectionReuseTests(unittest.TestCase):
    setUp = base.OutcomeTapTests.setUp
    capture = base.OutcomeTapTests.capture

    def test_same_response_is_projected_once_across_reads(self):
        real = tap_module.project_combat_outcome
        with patch('tools.dispatcher_qte_result_tap.project_combat_outcome', wraps=real) as spy:
            first = self.capture(base.envelope())
            second = self.capture(base.envelope())
        self.assertEqual(1, spy.call_count)
        self.assertEqual(self.tap.combat_outcome_fields(first), self.tap.combat_outcome_fields(second))
        self.assertEqual([], self.target.memory.mock_calls)

    def test_changed_response_is_projected_again(self):
        real = tap_module.project_combat_outcome
        changed = base.envelope(); changed['matchPayload']['totalDamageDisplay'] = 1401
        with patch('tools.dispatcher_qte_result_tap.project_combat_outcome', wraps=real) as spy:
            self.capture(base.envelope())
            snapshot = self.capture(changed)
        self.assertEqual(2, spy.call_count)
        record = self.tap.combat_outcome_fields(snapshot)['combatOutcome']
        self.assertEqual(1401, record['evidence']['total_damage_display'])


if __name__ == '__main__':
    unittest.main()
