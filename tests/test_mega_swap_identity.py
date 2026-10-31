"""Regression for the 2026-10-28 native turn143 false policy pause.

The board/multipliers and resource amounts come from the incident. Session,
HP scale and native/input surfaces are explicit offline fixtures.
"""
from dataclasses import replace
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

from pokiguard_v2.autonomous_control import AutonomousActionIdentity
from pokiguard_v2.basic_policy import PolicyAction
from pokiguard_v2.board_simulator import SwapMove
from pokiguard_v2.gameplay_profile import (
    AuditionMode, DamageCardMode, EvolutionTarget, MainPetType,
)
from pokiguard_v2.pet_configuration import GameplayConfig
from pokiguard_v2.state import BoardState, CellState, GemType
from tests.reasoning_controller_fixture import controller_trace
from tests.test_mega_icarus_policy import mega_capability, mega_policy
from tests.test_phase3c1_pet_skill_policy import session_state
from tools import basic_auto_bot as bot


ROWS = (
    'S4 S2 H3 K3 D1 H1 K1 M1',
    'R1 M4 K2 K1 H4 R4 R1 M6',
    'K1 S3 R5 D5 D1 S1 H1 H1',
    'K3 D1 K1 M4 D3 H3 D4 R1',
    'M3 K2 S2 M1 S2 K2 M2 H1',
    'H4 R2 M2 R3 K3 M4 M1 K1',
    'R1 D1 M6 K1 R2 D2 H3 M1',
    'M1 S1 D1 M2 M1 K3 H1 S4',
)
GEMS = dict(S=GemType.SWORD, H=GemType.HEALTH, K=GemType.SHIELD,
            D=GemType.DRAIN, R=GemType.RAGE, M=GemType.MANA)


def incident_state(*, rage=75):
    board = BoardState(tuple(tuple(CellState(r, c, GEMS[token[0]], int(token[1:]))
        for c, token in enumerate(row.split())) for r, row in enumerate(ROWS)))
    state = session_state(mana=5289, rage=rage, boss_hp=2_000_000)
    player = replace(state.player, hp=182, max_hp=1000, max_mana=6000)
    return replace(state, board=board, player=player,
                   participants=(player, *state.opponents), cards=())


def skill_for(state, *, card_id=22):
    return replace(mega_capability(), session_key=state.battle.session_key,
                   skill_card_id=card_id)


def signature(state, decision):
    identity = AutonomousActionIdentity.from_decision(state, decision)
    return identity.action, identity.target


class MegaSwapIdentityTests(unittest.TestCase):
    def test_incident_same_swap_target_preserves_skill_diagnostics(self):
        state = incident_state()
        policy = mega_policy(threshold=6)
        missing = policy.decide(state, pet_skill_capability=None)
        known = policy.decide(state, pet_skill_capability=skill_for(state))
        self.assertIs(missing.action, PolicyAction.SWAP)
        self.assertIs(known.action, PolicyAction.SWAP)
        self.assertEqual(missing.move, SwapMove((2, 5), (3, 5)))
        self.assertEqual(known.move, missing.move)
        self.assertEqual(known.trace.required_mana, 200)
        self.assertEqual(known.trace.required_rage, 150)
        self.assertEqual(known.trace.missing_rage, 75)
        self.assertFalse(known.trace.skill_ready)
        self.assertEqual(signature(state, missing), signature(state, known))
        self.assertEqual(known.skill_card_id, 22)
        self.assertEqual(known.skill_session_key, state.battle.session_key)

    def test_actual_pet_skill_keeps_card_and_session_identity(self):
        state = incident_state(rage=150)
        policy = mega_policy(threshold=6)
        first = policy.decide(state, pet_skill_capability=skill_for(state))
        second = policy.decide(state, pet_skill_capability=skill_for(state, card_id=23))
        self.assertIs(first.action, PolicyAction.PET_SKILL)
        self.assertEqual(first.skill_card_id, 22)
        self.assertEqual(first.skill_session_key, state.battle.session_key)
        self.assertNotEqual(signature(state, first), signature(state, second))

    def test_skill_becoming_affordable_still_changes_action(self):
        state = incident_state(rage=150)
        policy = mega_policy(threshold=6)
        missing = policy.decide(state, pet_skill_capability=None)
        ready = policy.decide(state, pet_skill_capability=skill_for(state))
        self.assertIs(missing.action, PolicyAction.SWAP)
        self.assertIs(ready.action, PolicyAction.PET_SKILL)
        self.assertNotEqual(signature(state, missing), signature(state, ready))

    def test_foreign_session_still_cannot_propose_skill(self):
        state = incident_state(rage=150)
        cap = skill_for(state)
        cap = replace(cap, session_key=replace(cap.session_key, match_id='OTHER'))
        decision = mega_policy(threshold=6).decide(state, pet_skill_capability=cap)
        self.assertIsNot(decision.action, PolicyAction.PET_SKILL)

    def test_changed_swap_target_is_still_a_different_input(self):
        state = incident_state()
        decision = mega_policy(threshold=6).decide(state)
        changed = replace(decision, move=SwapMove((0, 4), (1, 4)))
        self.assertNotEqual(signature(state, decision), signature(state, changed))

    def test_changed_cast_card_is_still_a_different_input(self):
        state = incident_state()
        decision = mega_policy(threshold=6).decide(state)
        first = replace(decision, action=PolicyAction.CAST, move=None,
                        card_object_address=100)
        second = replace(first, card_object_address=200)
        self.assertNotEqual(signature(state, first), signature(state, second))

    def test_real_controller_still_cancels_if_fresh_policy_selects_skill(self):
        calls = 0
        def observe(provider, state, capability_provider):
            nonlocal calls
            calls += 1
            return skill_for(state) if calls > 1 else None
        with tempfile.TemporaryDirectory() as name, patch.object(
                bot, '_current_pet_skill_capability', side_effect=observe):
            _, native, rows = controller_trace(Path(name)/'combat.jsonl',
                profile=bot.PlayStyle.MEGA_ICARUS_SPAM_SKILL.value,
                initial_combat=incident_state(rage=150), gameplay_config=self.config())
        self.assertNotIn('FAKE_NORMAL_INPUT', native)
        cancelled = next(row for row in rows
            if row.get('reason')=='POLICY_CHANGED_ON_FRESH_REREAD')
        self.assertEqual(cancelled['originalDecision']['action'], 'swap')
        self.assertEqual(cancelled['freshDecision']['action'], 'pet_skill')

    def test_real_controller_sends_and_acks_same_swap_when_capability_appears(self):
        self.check_controller(capability_initially_present=False)

    def test_real_controller_sends_and_acks_same_swap_when_capability_disappears(self):
        self.check_controller(capability_initially_present=True)

    def check_controller(self, *, capability_initially_present):
        calls = 0
        def observe(provider, state, capability_provider):
            nonlocal calls
            calls += 1
            present = (calls == 1) if capability_initially_present else (calls > 1)
            return skill_for(state) if present else None
        config = self.config()
        with tempfile.TemporaryDirectory() as name, patch.object(
                bot, '_current_pet_skill_capability', side_effect=observe):
            _, native, rows = controller_trace(Path(name)/'combat.jsonl',
                profile=config.play_style.value, initial_combat=incident_state(),
                gameplay_config=config)
        self.assertGreaterEqual(calls, 2)
        self.assertEqual(native.count('FAKE_NORMAL_INPUT'), 1)
        self.assertEqual(native.count('executor.ack'), 1)
        reasons = {row.get('reason') for row in rows}
        self.assertNotIn('NONDETERMINISTIC_POLICY_FOR_SAME_SOURCE', reasons)
        self.assertNotIn('POLICY_CHANGED_ON_FRESH_REREAD', reasons)
        sent = next(row for row in rows if row['event']=='action_sent')
        self.assertEqual(sent['identity']['target'], [[2, 5], [3, 5]])
        summary = next(row for row in rows if row['event']=='auto_controller_summary')
        self.assertEqual(summary['counters']['swap_sent'], 1)
        self.assertEqual(summary['counters']['swap_acknowledged'], 1)
        self.assertEqual(summary['counters']['duplicate_inputs'], 0)

    @staticmethod
    def config():
        return GameplayConfig(play_style=bot.PlayStyle.MEGA_ICARUS_SPAM_SKILL,
            main_pet=MainPetType.MEGA, evolution=EvolutionTarget.NONE,
            damage_card=DamageCardMode.PET_SKILL, audition_mode=AuditionMode.NO_ACTION,
            pet_skill_fire_value=6)


if __name__ == '__main__':
    unittest.main()
