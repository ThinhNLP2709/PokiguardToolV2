"""K7 (D-U1): G4 early protection on boss threat only before a successful evolution."""
import unittest

import tests.test_galaxy_shadow_sword as g4
from pokiguard_v2.galaxy_shadow_sword import plan_g4


class G4EarlyProtectionTests(unittest.TestCase):
    native = g4.G4BossSkillThreatTests.native

    def test_not_evolved_keeps_early_protection(self):
        state, moves = self.native(11)
        plan = plan_g4(state, moves, reasoning=True, clock=lambda: 0)
        self.assertEqual('PROTECT', plan.step)
        self.assertNotIn('early_protection_allowed', plan.facts)  # old logs keep identical facts

    def test_after_successful_evolution_follows_the_hp_rule(self):
        state, moves = self.native(11)
        plan = plan_g4(state, moves, reasoning=True, evolved=True, clock=lambda: 0)
        self.assertNotEqual('PROTECT', plan.step)
        self.assertFalse(plan.facts['early_protection_allowed'])
        basic = plan_g4(state, moves, reasoning=False, evolved=True, clock=lambda: 0)
        self.assertNotIn('early_protection_allowed', basic.facts)


if __name__ == '__main__':
    unittest.main()
