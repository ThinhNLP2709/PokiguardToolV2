from dataclasses import FrozenInstanceError, replace
import hashlib
import unittest

from pokiguard_v2.basic_policy import SkillRushMatchContext
from pokiguard_v2.reasoning_action_candidates import (
    action_candidates, evidence_digest, ht7_perfect_first_wave,
)
from pokiguard_v2.state import GameOwnedIdleStatus
from pokiguard_v2.game_owned_idle import (
    AcceptedActivityKind, GameOwnedIdleCache, ResetCapability, ResetConfidence,
    apply_idle_readiness_to_state,
)
from tests.test_phase3c1_pet_skill_policy import SESSION, capability, session_state
from tests.test_phase3c3_skill_rush_policy import rush_policy, board_with_swords, with_idle_status


def confirmed_reset_view(state, *, kind=AcceptedActivityKind.SWAP):
    """Synthetic accepted activity through the actual cache and policy mapper."""
    cache = GameOwnedIdleCache(seeded_capabilities=(ResetCapability(
        kind=kind, confirmations=2, required_confirmations=2,
        confidence=ResetConfidence.RESET_CONFIRMED_BY_SERVER_SEQUENCE,
        proof_identities=(('synthetic-proof-1',), ('synthetic-proof-2',))),))
    session = repr(state.battle.session_key)
    cache.observe_accepted_activity(session_id=session, kind=kind,
        source_message_type=('MATCH_MOVE_RES' if kind is AcceptedActivityKind.SWAP
            else 'MATCH_SKILL_USE_RES'),
        source_srv_seq=None, source_turn=state.battle.turn_number - 2,
        source_timestamp=None, observed_timestamp='SYNTHETIC_ACCEPTANCE')
    readiness = cache.pass_readiness(current_session_id=session,
        local_username=state.battle.local_username, current_turn=state.battle.turn_number,
        is_local_turn=state.battle.is_local_turn, lifecycle_active=True,
        is_first_local_turn=state.battle.is_first_local_turn)
    return apply_idle_readiness_to_state(state, readiness), cache


class ActionEvidenceTests(unittest.TestCase):
    def setUp(self):
        self.state = session_state(mana=200, rage=200)
        self.state = replace(self.state, battle=replace(self.state.battle,
            local_username='D2_SYNTHETIC_ACCOUNT'))
        self.cap = replace(capability(), source_pet_skill_card_id=120)
        self.engine = rush_policy(threshold=64)

    def choices(self, state=None, cap=None, **kwargs):
        state = self.state if state is None else state
        cap = self.cap if cap is None else cap
        baseline = self.engine.decide(state, pet_skill_capability=cap)
        return action_candidates(state, self.engine.config, baseline,
            capability=cap, owner_allowed=True, **kwargs)

    def skill(self, choices):
        return next(c for c in choices if c.action.family == 'pet_skill')

    def pass_choice(self, choices):
        return next(c for c in choices if c.action.family == 'pass')

    def test_three_families_and_threshold_never_authorizes_or_excludes_skill(self):
        choices = self.choices()
        self.assertEqual({c.action.family for c in choices}, {'swap', 'pet_skill', 'pass'})
        skill = self.skill(choices)
        self.assertTrue(skill.eligible)
        self.assertFalse(skill.facts.plain()['advisory_condition_ready'])
        self.assertEqual(skill.facts.plain()['current_skill_effect'], 'UNKNOWN')
        self.assertEqual(skill.comparison, 'EFFECT_MODEL_REQUIRED')

    def test_insufficient_actual_resource_disables_only_skill(self):
        state = replace(self.state, player=replace(self.state.player, mana=199))
        choices = self.choices(state)
        self.assertEqual(self.skill(choices).reason, 'SKILL_RESOURCES_INSUFFICIENT')
        self.assertTrue(any(c.eligible for c in choices if c.action.family == 'swap'))

    def test_stale_other_session_missing_cost_cooldown_and_card_each_fail_closed(self):
        cases = [replace(self.cap, session_key=replace(SESSION, match_id='OTHER')),
            replace(self.cap, ownership_current=False),
            replace(self.cap, effective_mana_cost=None),
            replace(self.cap, cooldown_turns=1), replace(self.cap, live_card_actionable=False),
            replace(self.cap, source_pet_skill_card_id=999)]
        for cap in cases:
            with self.subTest(cap=cap):
                self.assertFalse(self.skill(self.choices(cap=cap)).eligible)

    def test_pending_or_same_source_skill_turn_closes_all_families(self):
        history = SkillRushMatchContext(SESSION, 1, self.state.battle.turn_number)
        for kwargs in (dict(pending=True), dict(history=history)):
            with self.subTest(kwargs=kwargs):
                self.assertFalse(any(c.eligible for c in self.choices(**kwargs)))

    def test_foreign_history_does_not_close_current_turn(self):
        history = SkillRushMatchContext(replace(SESSION, match_id='OTHER'), 1, 999)
        self.assertTrue(self.skill(self.choices(history=history)).eligible)
        self.assertEqual(self.skill(self.choices(history=history)).facts.plain()['successful_skills_current_match'], 0)

    def test_pass_requires_authoritative_status_counter_and_nonopening_turn(self):
        allowed = with_idle_status(self.state, GameOwnedIdleStatus.PASS_ALLOWED, count=0)
        allowed = replace(allowed, battle=replace(allowed.battle, turn_number=7))
        self.assertTrue(self.pass_choice(self.choices(allowed)).eligible)
        for state in (replace(allowed, battle=replace(allowed.battle, turn_number=1)),
                with_idle_status(allowed, GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION, count=2),
                replace(allowed, battle=replace(allowed.battle, consecutive_pass_source=None)),
                replace(allowed, battle=replace(allowed.battle, consecutive_pass_status=GameOwnedIdleStatus.UNKNOWN))):
            with self.subTest(state=state):
                self.assertFalse(self.pass_choice(self.choices(state)).eligible)

    def test_real_cache_non_numeric_reset_permission_is_represented(self):
        for kind in (AcceptedActivityKind.SWAP, AcceptedActivityKind.CAST):
            with self.subTest(kind=kind):
                state, cache = confirmed_reset_view(self.state, kind=kind)
                self.assertTrue(cache.reset_baseline.capability.production_ready)
                self.assertIsNone(state.battle.consecutive_passes)
                self.assertIsNone(state.battle.consecutive_pass_threshold)
                choice = self.pass_choice(self.choices(state))
                self.assertTrue(choice.eligible)
                self.assertEqual(choice.facts.plain()['authority_kind'], 'CONFIRMED_CONSUMING_RESET')
                self.assertIsNone(choice.facts.plain()['count'])
                self.assertEqual(choice.facts.plain()['reset_evidence'],
                    state.battle.consecutive_pass_reset_evidence)

    def test_reset_permission_missing_or_conflicting_proof_fails_closed(self):
        state, _ = confirmed_reset_view(self.state)
        for change in (dict(consecutive_pass_source=None),
                dict(consecutive_pass_source='LOCAL_ASSUMPTION'),
                dict(consecutive_pass_reset_evidence=None),
                dict(consecutive_pass_confidence=None),
                dict(consecutive_pass_confidence='reset_strongly_inferred'),
                dict(consecutive_pass_confidence='reset_unknown'),
                dict(consecutive_passes=0, consecutive_pass_threshold=3),
                dict(consecutive_passes=0), dict(consecutive_pass_threshold=3),
                dict(consecutive_pass_status=GameOwnedIdleStatus.UNKNOWN),
                dict(consecutive_pass_status=GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION),
                dict(turn_number=1)):
            with self.subTest(change=change):
                changed = replace(state, battle=replace(state.battle, **change))
                self.assertFalse(self.pass_choice(self.choices(changed)).eligible)
        self.assertFalse(self.pass_choice(self.choices(state, pass_owner_allowed=False)).eligible)

    def test_real_cache_session_change_cannot_supply_old_reset_permission(self):
        state, cache = confirmed_reset_view(self.state)
        readiness = cache.pass_readiness(current_session_id='OTHER_SESSION',
            local_username=state.battle.local_username, current_turn=state.battle.turn_number,
            is_local_turn=True, lifecycle_active=True, is_first_local_turn=False)
        changed = apply_idle_readiness_to_state(state, readiness)
        self.assertIs(changed.battle.consecutive_pass_status, GameOwnedIdleStatus.UNKNOWN)
        self.assertIsNone(changed.battle.consecutive_pass_reset_evidence)
        self.assertFalse(self.pass_choice(self.choices(changed)).eligible)

    def test_counter_permission_still_needs_actual_pair_below_mandatory_limit(self):
        state = with_idle_status(self.state, GameOwnedIdleStatus.PASS_ALLOWED, count=1)
        self.assertTrue(self.pass_choice(self.choices(state)).eligible)
        for change in (dict(consecutive_passes=None), dict(consecutive_pass_threshold=None),
                dict(consecutive_passes=2), dict(consecutive_passes=True)):
            with self.subTest(change=change):
                self.assertFalse(self.pass_choice(self.choices(
                    replace(state, battle=replace(state.battle, **change)))).eligible)

    def test_owner_permission_and_immutability_and_determinism(self):
        baseline = self.engine.decide(self.state, pet_skill_capability=self.cap)
        blocked = action_candidates(self.state, self.engine.config, baseline, capability=self.cap)
        self.assertFalse(any(c.eligible for c in blocked))
        choices = self.choices()
        self.assertEqual(evidence_digest(choices), evidence_digest(self.choices()))
        with self.assertRaises(FrozenInstanceError):
            choices[0].eligible = True

    def test_ht7_first_wave_removes_only_sword_rage_health_and_keeps_unknown_effects(self):
        state = replace(self.state, board=board_with_swords(self.state, 7))
        cap = replace(self.cap, pet_id=2035, skill_card_id=7, source_pet_skill_card_id=7)
        account = hashlib.sha256(state.battle.local_username.casefold().encode()).hexdigest()
        model = ht7_perfect_first_wave(state, cap, account_sha256=account).plain()
        self.assertEqual(set(model['quantities']), {'sword', 'rage', 'health'})
        self.assertEqual(model['quantities']['sword'], {'physical':7, 'effective':7})
        self.assertEqual(model['origin'], 'USER_CALIBRATED')
        self.assertFalse(model['observed_result'])
        self.assertIn('COST_GAIN_ORDER', model['excluded'])
        self.assertEqual(set(map(tuple, model['original_cells'])),
            {(c.row,c.col) for row in state.board.cells for c in row
             if c.gem.value in ('sword','rage','health')})

    def test_wrong_account_pet_card_or_session_cannot_reuse_user_calibration(self):
        account = hashlib.sha256(self.state.battle.local_username.casefold().encode()).hexdigest()
        cap = replace(self.cap, pet_id=2035, skill_card_id=7, source_pet_skill_card_id=7)
        for bad in (replace(cap, pet_id=2036), replace(cap, skill_card_id=8),
                replace(cap, session_key=replace(SESSION, match_id='OTHER'))):
            with self.subTest(bad=bad), self.assertRaises(ValueError):
                ht7_perfect_first_wave(self.state, bad, account_sha256=account)
        with self.assertRaises(ValueError):
            ht7_perfect_first_wave(self.state, cap, account_sha256='0'*64)

    def test_threshold_counts_multiplier_effective_units(self):
        state = replace(self.state, board=board_with_swords(self.state, 3))
        cells = tuple(tuple(replace(c, multiplier=3) if c.gem.value=='sword' else c for c in row)
            for row in state.board.cells)
        state = replace(state, board=replace(state.board, cells=cells))
        engine = rush_policy(threshold=7)
        baseline = engine.decide(state, pet_skill_capability=self.cap)
        skill = self.skill(action_candidates(state, engine.config, baseline,
            capability=self.cap, owner_allowed=True))
        self.assertEqual(skill.facts.plain()['known_condition_effective_count'], 9)
        self.assertTrue(skill.facts.plain()['advisory_condition_ready'])


if __name__ == '__main__':
    unittest.main()
