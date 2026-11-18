"""Recorded-board regressions for conditional setup; no game IO or outcomes."""
from dataclasses import replace
import json
from pathlib import Path
import time
import unittest

from pokiguard_v2.board_simulator import SimulatedCell, SwapMove
from pokiguard_v2.reasoning_common_models import DEMON_RAGE_REFERENCE
from pokiguard_v2.reasoning_common_planner import (
    CommonLimits, Exhausted, Work, _future_setup, _replies, _root_step, plan_common,
)
from pokiguard_v2.reasoning_snapshot import Action, FrozenJSON
from pokiguard_v2.state import GemType
from tests.test_reasoning_common import problem


FIXTURE = Path(__file__).parent / 'fixtures/reasoning_setup_sensitivity.json'
FRAGILE = SwapMove((0, 7), (1, 7))
DIRECT = SwapMove((3, 2), (3, 3))


def recorded(*, robust=False, target='shield', transpose=False):
    raw = json.loads(FIXTURE.read_text(encoding='utf-8'))
    if robust:
        raw = raw['robust']
    def rename(gem):
        return target if gem == 'shield' else 'shield' if gem == target else gem
    board = tuple(tuple((rename(g), m) for g, m in row) for row in raw['board'])
    baseline = SwapMove(*(tuple(p) for p in raw['baseline']))
    if transpose:
        board = tuple(zip(*board))
        baseline = transposed(baseline)
    return problem('demon_aegis_farm', board=board, baseline=Action('swap', baseline),
        settings=dict(raw['settings'], demon_target_gem=target), facts=dict(
            self=raw['self'], opponent=raw['opponent'], operator_demon_rage_discount=1,
            demon_strategy=dict(rage_reference=DEMON_RAGE_REFERENCE.plain())))


def transposed(move):
    return SwapMove(*(tuple(reversed(p)) for p in (move.first, move.second)))


def reply_set(value, move, *, scenarios=32, sword_first=True):
    grid = tuple(tuple(SimulatedCell(GemType(g), m) for g, m in row) for row in value.board)
    work = Work(CommonLimits(nodes=50000, scenarios=scenarios), lambda: 0, lambda: False, None)
    root = _root_step(value, grid, move, work)
    assert root is not None and not root.unresolved_residual
    replies, nominal, _ = _replies(root.after, work, sword_first)
    return replies, nominal, work


class SetupSensitivityTests(unittest.TestCase):
    def test_recorded_fragile_setup_yields_to_immediate_three_sword_match(self):
        value = recorded()
        result = plan_common(value, clock=lambda: 0)
        self.assertEqual(DIRECT, result.proposal.move)
        fragile = next(s for s in result.scores if s.action.move == FRAGILE)
        direct = next(s for s in result.scores if s.action.move == DIRECT)
        bound = dict(fragile.features)['H']
        self.assertEqual((0, .5), (bound.low, bound.high))
        self.assertEqual(3, direct.details.plain()['normal_sword_effective'])
        self.assertEqual(dict(fragile.features)['T'], dict(direct.features)['T'])
        self.assertFalse(direct.details.plain()['automatic_kill_claim'])
        self.assertFalse(result.to_dict()['input_authority'])

    def test_all_targets_and_transposed_boards_do_not_certify_fragile_setup(self):
        for target in ('shield', 'health', 'mana', 'drain', 'rage'):
            for transpose in (False, True):
                with self.subTest(target=target, transpose=transpose):
                    value = recorded(target=target, transpose=transpose)
                    move = transposed(FRAGILE) if transpose else FRAGILE
                    replies, nominal, work = reply_set(value, move)
                    bound, info = _future_setup(value, replies, nominal, work, {})
                    if transpose:
                        # Gravity stays vertical: transposing a captured board
                        # changes cascades and already exposes a nominal denial.
                        self.assertEqual((0, 0), (bound.low, bound.high))
                        self.assertEqual(0, info['post_boss_setup_floor'])
                        continue
                    self.assertEqual((0, .5), (bound.low, bound.high))
                    witness = next(r for r in replies if r.action.to_dict() == info['setup_denial_witness'])
                    self.assertNotIn(witness.action, {r.action for r in nominal})
                    self.assertLess(witness.resources.effective(GemType.SWORD),
                                    nominal[0].resources.effective(GemType.SWORD))
                    self.assertTrue(info['setup_policy_sensitive'])
                    self.assertEqual(0, info['favorable_refill_credit'])

    def test_unknown_boss_policy_uses_all_known_replies_without_conditional_bonus(self):
        value = recorded()
        facts = value.facts.plain(); facts['boss_policy'] = 'UNKNOWN'
        value = replace(value, facts=FrozenJSON.of(facts))
        replies, nominal, work = reply_set(value, FRAGILE, sword_first=False)
        bound, info = _future_setup(value, replies, nominal, work, {})
        self.assertEqual((0, 0), (bound.low, bound.high))
        self.assertEqual(len(replies), info['nominal_examined'])
        self.assertEqual(0, info['alternative_total'])

    def test_alternative_budget_cannot_turn_unexamined_policy_into_guaranteed_setup(self):
        value = recorded()
        replies, nominal, work = reply_set(value, FRAGILE, scenarios=3)
        bound, info = _future_setup(value, replies, nominal, work, {})
        self.assertEqual((0, .5), (bound.low, bound.high))
        self.assertEqual(3, info['nominal_examined'])
        self.assertEqual(0, info['alternative_examined'])
        self.assertNotIn('setup_denial_witness', info)
        self.assertEqual('BOUNDED_SEARCH_UNKNOWN_FLOOR', info['alternative_status'])

    def test_partial_nominal_search_cannot_award_any_future_credit(self):
        value = recorded()
        replies, nominal, work = reply_set(value, FRAGILE, scenarios=2)
        bound, info = _future_setup(value, replies, nominal, work, {})
        self.assertIsNone(bound)
        self.assertEqual(0, info['nominal_examined'])
        self.assertEqual('PARTIAL_NOMINAL_TIES_NO_FUTURE_CREDIT', info['status'])

    def test_preparation_that_survives_all_known_replies_keeps_its_credit(self):
        value = recorded(robust=True)
        replies, nominal, work = reply_set(value, value.baseline.move)
        bound, info = _future_setup(value, replies, nominal, work, {})
        self.assertEqual((.25, .25), (bound.low, bound.high))
        self.assertEqual(len(replies), info['nominal_examined'] + info['alternative_examined'])
        self.assertFalse(info['setup_policy_sensitive'])

    def test_setup_cache_reuses_only_this_search_and_still_obeys_cancellation(self):
        value = recorded()
        replies, nominal, work = reply_set(value, FRAGILE)
        cache = {}
        first = _future_setup(value, replies, nominal, work, cache)
        nodes = work.nodes
        self.assertEqual(first, _future_setup(value, replies, nominal, work, cache))
        self.assertEqual(nodes, work.nodes)
        work.cancelled = lambda: True
        with self.assertRaises(Exhausted):
            _future_setup(value, replies, nominal, work, cache)

    def test_isolated_worker_serializes_and_validates_the_recorded_immediate_attack(self):
        from pokiguard_v2.reasoning_runner import make_job
        from pokiguard_v2.reasoning_warm_runner import WarmIsolatedRunner
        value = recorded()
        runner = WarmIsolatedRunner()
        try:
            job = make_job(value, deadline=time.perf_counter_ns()+4_000_000_000)
            self.assertTrue(runner.submit(job))
            until = time.perf_counter()+5
            while runner.outcome is None and time.perf_counter()<until:
                time.sleep(.005)
            self.assertIsNotNone(runner.outcome)
            # WarmIsolatedRunner publishes a parsed, validated Reply.
            reply, reason = runner.outcome
            self.assertIsNotNone(reply, reason)
            self.assertEqual(DIRECT, reply.proposal.move)
            disposition = runner.disposition(job, current_binding=job.binding)
            self.assertEqual(DIRECT, disposition.action.move)
            self.assertFalse(disposition.input_authority)
            self.assertEqual('LOOKAHEAD_COMPLETE',
                json.loads(reply.summary_json)['common_diagnostics']['stage'])
        finally:
            self.assertTrue(runner.close())
        self.assertEqual(runner.counters['processes'], runner.counters['reaped'])


if __name__ == '__main__':
    unittest.main()
