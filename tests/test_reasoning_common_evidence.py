"""Synthetic existing-controller packets; no reader, game or input access."""
from dataclasses import replace
import time,unittest
from pokiguard_v2.basic_policy import PlayStyle,SkillRushMatchContext,PolicyAction
from pokiguard_v2.reasoning_common_evidence import (packet,packet_hash,build_problem,
    root_allowed,skill_evidence,pass_evidence)
from pokiguard_v2.reasoning_common_problem import PROFILES
from pokiguard_v2.reasoning_snapshot import Action
from pokiguard_v2.state import GameOwnedIdleStatus,GemType
from tests.test_phase3c1_pet_skill_policy import session_state,capability
from tests.test_phase3c3_skill_rush_policy import rush_policy
from tests.test_reasoning_action_candidates import confirmed_reset_view


def fixture():
    state=session_state(mana=250,rage=250)
    state,_=confirmed_reset_view(state)
    state=replace(state,battle=replace(state.battle,
        turn_time_remaining_seconds=14,turn_timer_source='MatchService.server_tick'))
    cap=replace(capability(card_id=7),pet_id=2035,source_pet_skill_card_id=7)
    policy=rush_policy(threshold=7)
    base=policy.decide(state,pet_skill_capability=cap)
    history=SkillRushMatchContext(state.battle.session_key,0,None)
    return packet(state,policy.config,base,cap,history,True)


def build(value,**kw):
    now=time.perf_counter_ns()
    return build_problem(value,run_id='SYNTHETIC_COMMON',generation=1,
        observed_ns=now,read_end_ns=now,**kw)


class CommonEvidenceTests(unittest.TestCase):
    def test_seven_styles_keep_their_actual_identity_and_config(self):
        value=fixture()
        for profile in sorted(PROFILES):
            v=list(value);v[1]=replace(v[1],play_style=PlayStyle(profile))
            result=build(tuple(v))
            self.assertEqual(profile,result.intent.profile)
            self.assertEqual(profile,result.intent.settings.plain()['play_style'])
            self.assertEqual(value[0].board,result.board_state())
            self.assertIsNone(result.facts.plain()['demon_geometry'])
            self.assertEqual(dict(mana=30,rage=20),result.facts.plain()['conversion'])

    def test_effect_independent_of_style_threshold_but_bound_to_actual_capability(self):
        value=fixture();state,config,base,cap,h,owner,passed=value
        for profile in PROFILES:
            cfg=replace(config,play_style=PlayStyle(profile),pet_skill_fire_value=50)
            evidence=skill_evidence(packet(state,cfg,base,cap,h,True),True)
            self.assertTrue(evidence.eligible)
            expected={(c.row,c.col) for row in state.board.cells for c in row
                if c.gem in (GemType.SWORD,GemType.RAGE,GemType.HEALTH)}
            self.assertEqual(expected,set(evidence.cleared))
        for changed in (None,object(),replace(cap,cooldown_turns=1),replace(cap,ownership_current=False),
                replace(cap,session_key=None),replace(cap,live_card_actionable=False),
                replace(cap,skill_card_id=999),replace(cap,effective_mana_cost=None),
                replace(cap,effective_mana_cost=10000)):
            v=list(value);v[3]=changed
            self.assertFalse(skill_evidence(tuple(v),True).eligible)

    def test_pass_third_first_turn_reset_and_owner_are_separate_from_tactics(self):
        state=fixture()[0]
        self.assertTrue(pass_evidence(state,True,True).eligible)
        for count,allowed in ((0,True),(1,True),(2,False),(3,False)):
            s=replace(state,battle=replace(state.battle,consecutive_pass_status=GameOwnedIdleStatus.PASS_ALLOWED,
                consecutive_passes=count,consecutive_pass_threshold=3,consecutive_pass_source='SYNTHETIC_SERVER'))
            self.assertEqual(allowed,pass_evidence(s,True,True).eligible)
        for s,root,owner in ((state,False,True),(state,True,False),
                (replace(state,battle=replace(state.battle,turn_number=1)),True,True),
                (replace(state,battle=replace(state.battle,consecutive_pass_reset_evidence=None)),True,True)):
            self.assertFalse(pass_evidence(s,root,owner).eligible)

    def test_resource_planning_rejects_costs_from_a_previous_skill_session(self):
        value=list(fixture());cap=value[3]
        self.assertEqual({'mana':cap.effective_mana_cost,'rage':cap.effective_power_cost},
                         build(tuple(value)).facts.plain()['resource_requirements'])
        value[3]=replace(cap,session_key=None)
        self.assertEqual({},build(tuple(value)).facts.plain()['resource_requirements'])

    def test_root_fence_and_context_changes_invalidate_without_new_observation(self):
        value=fixture();state,config,base,cap,h,owner,passed=value
        self.assertTrue(root_allowed(value))
        for changed in (packet(state,config,base,cap,h,False),
                packet(state,config,base,cap,SkillRushMatchContext(state.battle.session_key,1,state.battle.turn_number),True),
                packet(replace(state,player=replace(state.player,hp=0)),config,base,cap,h,True)):
            self.assertFalse(root_allowed(changed))
        original=packet_hash(value)
        self.assertEqual(original,packet_hash(packet(state,config,base,replace(cap,observed_at=999),h,True)))
        for changed in (packet(state,replace(config,pet_skill_fire_value=8),base,cap,h,True),
                packet(state,config,base,replace(cap,cooldown_turns=1),h,True),
                packet(state,config,base,cap,h,True,False)):
            self.assertNotEqual(original,packet_hash(changed))

    def test_non_boss_opponent_does_not_acquire_boss_policy(self):
        value=list(fixture());state=value[0]
        value[0]=replace(state,opponents=tuple(replace(p,is_boss=False) for p in state.opponents))
        self.assertEqual('UNKNOWN_ALL_KNOWN_ALTERNATIVES',build(tuple(value)).facts.plain()['boss_policy'])

    def test_opaque_default_attack_keeps_exact_owned_object_identity(self):
        value=list(fixture());value[2]=replace(value[2],action=PolicyAction.CAST,card_object_address=123456)
        result=build(tuple(value))
        self.assertEqual('cast',result.baseline.family)
        self.assertIn('123456',result.baseline.card_source)
        effect=next(e for e in result.effects if e.action.family=='cast')
        self.assertIsNone(effect.cleared)


if __name__=='__main__':unittest.main()
