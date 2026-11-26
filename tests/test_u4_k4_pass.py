"""K4 also covers a PASS proposal that leaves more known Sword for the boss than BASIC (26/11 live trial)."""
from types import SimpleNamespace
import unittest

from pokiguard_v2.reasoning_common_planner import _rule_blocked
from pokiguard_v2.reasoning_common_problem import Action


class Res:
    def effective(self, gem):
        return 0


def row(family, baseline, left, move=None):
    action = Action.from_dict(dict(family=family, move=move, card_source=None))
    return (SimpleNamespace(baseline_member=baseline), SimpleNamespace(action=action, resources=Res()), left)


class K4PassTests(unittest.TestCase):
    def test_pass_leaving_more_sword_is_blocked(self):
        problem = SimpleNamespace(intent=SimpleNamespace(profile='mega_icarus_spam_skill'))
        facts = dict(self=dict(rage=50, max_rage=250))
        base, passing, safe = row('swap', True, 7, [[0, 0], [0, 1]]), row('pass', False, 11), row('swap', False, 3, [[1, 0], [1, 1]])
        blocked, why = _rule_blocked(problem, facts, [base, passing, safe])
        self.assertIn(passing[1].action, blocked)
        self.assertNotIn(safe[1].action, blocked)
        self.assertEqual({'K4': 1}, why)


if __name__ == '__main__':
    unittest.main()
