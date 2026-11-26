"""D-U4: before evolution (Mana below cost) the rules switch puts Mana first; off, nothing changes."""
from dataclasses import replace
import unittest

from tools import reasoning_u1_bench as u1
from tools.compare_same_state_decisions import project_action
from pokiguard_v2.board_simulator import _candidate_swaps
from pokiguard_v2.reasoning_common_problem import Action, CommonProblem, FrozenJSON
from pokiguard_v2.reasoning_common_planner import CommonLimits, _evolution_need, _seal_swords, plan_common


def mana_cases():
    for c in u1.portable_corpus()['cases']:
        if c['cohort'] == 'ICARUS' and c['kind'] == 'SWAP_PAIR':
            yield CommonProblem.from_dict(c['problem'])


def pre_evolution(problem):
    facts = problem.facts.plain()
    own = facts['self']
    facts['evolution'] = dict(pending=True, mana_cost=own['mana'] + 300, source='TEST')
    return replace(problem, facts=FrozenJSON.of(facts))


def collects_mana(problem, action):
    p = u1.compact(project_action(problem, action))
    return p is not None and p.get('status') == 'MODELED' and p['effective']['mana'] > 0


class PreEvolutionTests(unittest.TestCase):
    def test_need_detection(self):
        self.assertTrue(_evolution_need(dict(evolution=dict(pending=True, mana_cost=200), self=dict(mana=50))))
        self.assertFalse(_evolution_need(dict(evolution=dict(pending=True, mana_cost=200), self=dict(mana=250))))
        self.assertFalse(_evolution_need(dict(evolution=dict(pending=False, mana_cost=200), self=dict(mana=50))))

    def test_mana_first_when_rules_on(self):
        checked = 0
        for problem in list(mana_cases())[:12]:
            flagged = pre_evolution(problem)
            if not any(collects_mana(flagged, Action.from_dict(dict(family='swap', move=[list(m.first), list(m.second)],
                    card_source=None))) for m in _candidate_swaps()):
                continue
            on = plan_common(flagged, CommonLimits(rules=True), clock=lambda: 0)
            chosen = on.proposal or on.baseline
            self.assertTrue(collects_mana(flagged, chosen), problem.source.turn)
            self.assertEqual('PRE_EVOLUTION_MANA_FIRST', on.diagnostics.plain()['d_u4'])
            off = plan_common(flagged, clock=lambda: 0)
            self.assertNotIn('d_u4', off.diagnostics.plain())
            checked += 1
        self.assertGreater(checked, 0)

    def test_seal_sword_count(self):
        grid = [[('sword', 2) if (r, c) == (0, 0) else ('mana', 1) for c in range(8)] for r in range(8)]
        self.assertEqual(2, _seal_swords(grid, [(0, 0), (0, 1)]))


if __name__ == '__main__':
    unittest.main()
