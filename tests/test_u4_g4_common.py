"""U4c: G4 (galaxy_shadow_sword) runs on the common core via the existing G4 tactics."""
from dataclasses import replace
import unittest

from tools import reasoning_u1_bench as u1
from tools.compare_same_state_decisions import project_action
from pokiguard_v2.reasoning_common_problem import CommonIntent, CommonProblem, FrozenJSON
from pokiguard_v2.reasoning_common_planner import CommonLimits, _g4_choice, plan_common


def g4_problems(limit=10):
    for c in u1.portable_corpus()['cases']:
        if c['kind'] == 'SWAP_PAIR' and c['problem'].get('intent', {}).get('profile') == 'galaxy':
            p = CommonProblem.from_dict(c['problem'])
            i = p.intent
            intent = CommonIntent('galaxy_shadow_sword', FrozenJSON.of(dict(i.settings.plain(), play_style='galaxy_shadow_sword')),
                                  i.versions, i.scope)
            yield replace(p, intent=intent)
            limit -= 1
            if limit == 0: return


class G4CommonTests(unittest.TestCase):
    def test_common_g4_follows_g4_tactics_and_k4(self):
        seen = 0
        for p in g4_problems():
            d = plan_common(p, CommonLimits(rules=True), clock=lambda: 0)
            self.assertIn(d.reason, ('COMMON_G4_TACTIC', 'COMMON_G4_RETAIN'))
            self.assertEqual('G4_TACTIC_COMPLETE', d.diagnostics.plain()['stage'])
            chosen, _ = _g4_choice(p, p.facts.plain(), lambda: 0)
            if d.reason == 'COMMON_G4_TACTIC':
                self.assertEqual(chosen, d.proposal)
                c, b = u1.compact(project_action(p, d.proposal)), u1.compact(project_action(p, p.baseline))
                self.assertLessEqual(c['known_reply_sword_max'], b['known_reply_sword_max'])
            seen += 1
        self.assertGreater(seen, 0)


if __name__ == '__main__':
    unittest.main()
