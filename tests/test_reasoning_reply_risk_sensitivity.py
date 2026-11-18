"""Known-cell reply-policy sensitivity; no claimed server damage or win result."""
from dataclasses import replace
import json
from pathlib import Path
import unittest

from pokiguard_v2.board_simulator import SimulatedCell, SwapMove
from pokiguard_v2.reasoning_common_planner import CommonLimits, Work, _features, _root_step, _replies, _score
from pokiguard_v2.reasoning_common_problem import CommonProblem, PROFILES
from pokiguard_v2.reasoning_common_tactics import evaluate_context
from pokiguard_v2.reasoning_snapshot import Action, FrozenJSON
from pokiguard_v2.state import GemType
from tests.test_reasoning_strategy_intent import context, step


FIXTURE = Path(__file__).parent/'fixtures/reasoning_reply_risk_sensitivity.json'


def recorded(index=0):
    case = json.loads(FIXTURE.read_text(encoding='utf-8'))['cases'][index]
    value = CommonProblem.from_dict(case['problem'])
    grid = tuple(tuple(SimulatedCell(GemType(g), m) for g, m in row) for row in value.board)
    work = Work(CommonLimits(nodes=50000), lambda: 0, lambda: False, None)
    root = _root_step(value, grid, SwapMove(*(tuple(p) for p in case['root'])), work)
    replies, nominal, maximum = _replies(root.after, work, True)
    return value, root, replies, nominal, maximum, case


def score(value, root, replies, maximum):
    f, w, d = _features(value, root, replies, maximum)
    return _score(value, root, f, w, d)


class ReplyRiskSensitivityTests(unittest.TestCase):
    def test_recorded_lower_sword_reply_widens_the_threat_interval(self):
        for index in (0, 1):
            value, root, replies, nominal, maximum, case = recorded(index)
            result = score(value, root, replies, maximum)
            bound = dict(result.features)['T']
            details = result.details.plain()['tactical_context']
            sensitivity = details['boss_reply_sensitivity']
            self.assertGreater(bound.high, bound.low)
            self.assertEqual(details['boss_reply_proxy']['threat'], bound.low)
            self.assertEqual(sensitivity['high'], bound.high)
            self.assertEqual(case['witness'], sensitivity['alternative_witness']['move'])
            witness = next(r for r in replies if r.action.to_dict() == sensitivity['alternative_witness'])
            self.assertLess(witness.resources.effective(GemType.SWORD), maximum)
            self.assertNotIn(witness, nominal)
            self.assertFalse(result.to_dict().get('input_authority', False))

    def test_known_risk_extension_only_lowers_the_conservative_utility_endpoint(self):
        value, root, replies, nominal, maximum, _ = recorded()
        all_score = score(value, root, replies, maximum)
        nominal_score = score(value, root, nominal, maximum)
        self.assertLess(all_score.utility.low, nominal_score.utility.low)
        self.assertEqual(all_score.utility.high, nominal_score.utility.high)
        contributions = dict(all_score.contributions)['T']
        self.assertLess(contributions.low, contributions.high)

    def test_unknown_policy_has_no_conditional_point_optimism(self):
        value, root, replies, _, maximum, _ = recorded()
        value = replace(value, facts=FrozenJSON.of(dict(value.facts.plain(), boss_policy='UNKNOWN')))
        result = score(value, root, replies, maximum)
        bound = dict(result.features)['T']
        self.assertEqual(bound.low, bound.high)
        self.assertEqual(len(replies), result.details.plain()['tactical_context']['boss_reply_sensitivity']['nominal_replies'])

    def test_reply_order_does_not_change_risk_or_utility(self):
        value, root, replies, _, maximum, _ = recorded(1)
        a = score(value, root, replies, maximum)
        b = score(value, root, list(reversed(replies)), maximum)
        self.assertEqual(a.utility, b.utility)
        self.assertEqual(dict(a.features)['T'], dict(b.features)['T'])

    def test_missing_alternative_resource_conversion_is_unknown_not_zero(self):
        value, root, replies, _, maximum, _ = recorded()
        value = replace(value, facts=FrozenJSON.of(dict(value.facts.plain(), conversion={})))
        result = score(value, root, replies, maximum)
        bound = dict(result.features)['T']
        self.assertEqual((0, 1, 'UNSUPPORTED'), (bound.low, bound.high, bound.status))
        self.assertTrue(any('BOSS_RESOURCE_PROGRESS_UNKNOWN' in item for item in result.details.plain()['unknown_effects']))

    def test_residual_effect_or_unresolved_refill_is_never_a_certified_risk(self):
        value, root, replies, _, maximum, _ = recorded()
        result = score(value, replace(root, unresolved_residual=True), replies, maximum)
        self.assertEqual('UNSUPPORTED', dict(result.features)['T'].status)
        grid = ((SimulatedCell(GemType.UNKNOWN, None), *root.after[0][1:]), *root.after[1:])
        result = score(value, replace(root, after=grid), [], 0)
        self.assertEqual('UNSUPPORTED', dict(result.features)['T'].status)

    def test_all_styles_and_active_action_families_share_reply_sensitivity(self):
        for profile in sorted(PROFILES):
            value = context(profile)
            facts = value.facts.plain(); facts['opponent'].update(mana=0, rage=0)
            value = replace(value, facts=FrozenJSON.of(facts))
            nominal = replace(step(value, sword=3), action=Action('swap', SwapMove((0, 0), (0, 1))))
            alternative = replace(step(value, sword=2, mana=8, rage=8), action=Action('swap', SwapMove((1, 0), (1, 1))))
            for family in ('swap', 'pet_skill', 'pass'):
                with self.subTest(profile=profile, family=family):
                    _, details, _ = evaluate_context(value, step(value, family=family), [nominal, alternative], 3)
                    sensitivity = details['boss_reply_sensitivity']
                    self.assertGreater(sensitivity['high'], sensitivity['low'])
                    self.assertIn('NOT_PROBABILITY_OR_DAMAGE', sensitivity['kind'])

    def test_worst_reply_is_one_complete_move_not_combined_effect_maxima(self):
        value = context('careful')
        facts = value.facts.plain(); facts['opponent'].update(mana=0, rage=0, hp=50000)
        value = replace(value, facts=FrozenJSON.of(facts))
        replies = [replace(step(value, sword=2, drain=3), action=Action('swap', SwapMove((0, 0), (0, 1)))),
            replace(step(value, sword=1, health=5, mana=3), action=Action('swap', SwapMove((1, 0), (1, 1))))]
        _, details, _ = evaluate_context(value, step(value), replies, 2)
        one = [evaluate_context(value, step(value), [r], r.resources.effective(GemType.SWORD))[1]['boss_reply_proxy']
            for r in replies]
        alternative = details['boss_reply_sensitivity']['alternative_proxy']
        self.assertEqual(max(row['threat'] for row in one), alternative['threat'])
        self.assertTrue(any(all(row[k] == alternative[k] for k in ('sword', 'drain', 'health', 'resource_progress')) for row in one))

    def test_all_nominal_ties_keep_the_previous_point_bound(self):
        value, root, replies, nominal, maximum, _ = recorded()
        result = score(value, root, nominal, maximum)
        bound = dict(result.features)['T']
        self.assertEqual(bound.low, bound.high)
        self.assertFalse(result.details.plain()['tactical_context']['boss_reply_sensitivity']['policy_sensitive'])

    def test_bounded_worker_summary_keeps_the_specific_alternative_witness(self):
        from pokiguard_v2.reasoning_common_planner import CommonDecision
        from pokiguard_v2.reasoning_runner import _decision_summary
        value, root, replies, _, maximum, _ = recorded()
        value = replace(value, baseline=root.action)
        candidate = score(value, root, replies, maximum)
        decision = CommonDecision(value.snapshot_id, value.intent.config_hash, value.baseline,
            'RETAIN_BASELINE', 'TEST_RECORDED_SENSITIVITY', None, (candidate,), FrozenJSON.of(dict(stage='ONE_STEP_COMPLETE')))
        summary = _decision_summary(value, decision, None)
        item = summary['candidates'][0]['tactical_context']['reply_sensitivity']
        self.assertTrue(item['policy_sensitive'])
        self.assertIsNotNone(item['alternative_witness'])
        self.assertEqual(dict(candidate.features)['T'].high, item['high'])
        self.assertLessEqual(len(json.dumps(summary, separators=(',', ':')).encode()), 12000)
        self.assertFalse(summary['worker_input_sent'])
        self.assertIsNone(summary['dispatched_candidate_id'])


if __name__ == '__main__':
    unittest.main()
