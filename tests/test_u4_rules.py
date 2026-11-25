"""U4b: D-U1 rule layer is OFF by default; ON enforces K6/K4 without touching skill timing or Demon."""
import unittest

from tools import reasoning_u1_bench as u1
from tools.compare_same_state_decisions import project_action
from pokiguard_v2.reasoning_common_problem import CommonProblem
from pokiguard_v2.reasoning_common_planner import CommonLimits, plan_common


def case(cohort, match, turn, kind='SWAP_PAIR'):
    for c in u1.portable_corpus()['cases']:
        s = c['problem'].get('source', {}) if c['schema'] == 'COMMON_PROBLEM_V1' else {}
        if c['cohort'] == cohort and c['kind'] == kind and s.get('match_id') == match and s.get('turn') == turn:
            return CommonProblem.from_dict(c['problem'])
    raise AssertionError('case missing')


def sword(problem, decision):
    action = decision.proposal or decision.baseline
    return u1.compact(project_action(problem, action))['effective']['sword']


class U4RuleTests(unittest.TestCase):
    def test_rules_flag_is_explicit_and_off_by_default(self):
        self.assertFalse(CommonLimits().rules)
        with self.assertRaises(Exception):
            CommonLimits(rules='yes')

    def test_k6_blocks_sword_at_rage_115_only_when_on(self):
        problem = case('ICARUS', 'M_9c305403', 13)  # Rage 115: native R ate 5 Swords (FULL_POWER -100)
        off = plan_common(problem, clock=lambda: 0)
        on = plan_common(problem, CommonLimits(rules=True), clock=lambda: 0)
        self.assertGreater(sword(problem, off), 0)
        self.assertEqual(0, sword(problem, on))
        self.assertNotIn('rules', off.diagnostics.plain())
        self.assertEqual('D_U1', on.diagnostics.plain()['rules'])

    def test_skill_incumbent_is_not_replaced_by_sword_swap(self):
        problem = case('ICARUS', 'M_416b699b', 43, 'SKILL_PRESTATE')
        on = plan_common(problem, CommonLimits(rules=True), clock=lambda: 0)
        self.assertIsNone(on.proposal)


    def test_profile_trial_flag_in_facts_matches_limits_flag(self):
        from dataclasses import replace
        from pokiguard_v2.reasoning_common_problem import FrozenJSON
        problem = case('ICARUS', 'M_9c305403', 13)
        flagged = replace(problem, facts=FrozenJSON.of(dict(problem.facts.plain(), d_u1_rules=True)))
        by_facts = plan_common(flagged, clock=lambda: 0)
        by_limits = plan_common(problem, CommonLimits(rules=True), clock=lambda: 0)
        self.assertEqual(by_limits.proposal, by_facts.proposal)
        self.assertEqual(0, sword(flagged, by_facts))

    def test_trial_flag_needs_common_authority_and_matching_digest(self):
        from pokiguard_v2.reasoning_ui_session import _profile_trial_rules
        self.assertIs(False, _profile_trial_rules(None, object()))

if __name__ == '__main__':
    unittest.main()
