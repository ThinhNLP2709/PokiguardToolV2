"""Temporary missing state/timer must not accuse gear changes or stop gameplay."""
from dataclasses import replace
from types import SimpleNamespace
import time
import unittest
from pokiguard_v2.reasoning_ui_session import UIReasoningSession,_observation_status
from tests.test_reasoning_common_evidence import fixture
from tests.test_reasoning_common_native import authority
from tests.test_reasoning_ui_delivery import config

class UIContextStatusTests(unittest.TestCase):
    def setUp(self):
        self.state,self.policy,*_=fixture();self.authority=authority(self.policy)

    def test_missing_timer_is_waiting_and_never_a_cohort_change(self):
        for timer in (None,'estimated_local'):
            state=replace(self.state,battle=replace(self.state.battle,turn_timer_source=timer))
            self.assertFalse(self.authority.matches(state,self.policy))
            self.assertEqual(('WAITING','UI_REASONING_WAITING_SERVER_TIMER'),_observation_status(self.authority,(state,self.policy)))
        self.assertIsNone(_observation_status(self.authority,(self.state,self.policy)))
        self.assertTrue(self.authority.matches(self.state,self.policy))

    def test_expiry_and_config_are_separate_from_temporary_timer_missing(self):
        state=replace(self.state,battle=replace(self.state.battle,turn_timer_source=None))
        expired=replace(self.authority,valid_until_ns=1)
        self.assertEqual(('UNSUPPORTED','UI_REASONING_PROFILE_EXPIRED'),_observation_status(expired,(state,self.policy)))
        changed=replace(self.policy,pet_skill_fire_value=self.policy.pet_skill_fire_value+1)
        self.assertFalse(self.authority.matches(self.state,changed))
        self.assertEqual(('UNSUPPORTED','UI_REASONING_CONFIG_CHANGED'),_observation_status(self.authority,(state,changed)))
        self.assertEqual(('UNSUPPORTED','UI_REASONING_PROFILE_EXPIRED'),_observation_status(expired,(None,self.policy)))
        self.assertEqual(('UNSUPPORTED','UI_REASONING_CONFIG_CHANGED'),_observation_status(self.authority,(None,changed)))

    def test_unknown_context_and_exception_do_not_accuse_account_or_equipment(self):
        legacy=SimpleNamespace(policy_json=self.authority.policy_json,timer_source='MatchService.server_tick',matches=lambda *_:False)
        self.assertEqual(('UNSUPPORTED','UI_REASONING_CONTEXT_CHANGED'),_observation_status(legacy,(self.state,self.policy)))
        self.assertEqual(('DEGRADED','UI_REASONING_CONTEXT_UNAVAILABLE'),_observation_status(self.authority,(SimpleNamespace(),self.policy)))
        self.assertIsNone(_observation_status(self.authority,None))

    def test_real_observation_without_state_waits_then_recovers_without_worker_fault(self):
        from pokiguard_v2.reasoning_common_selection import CommonSelectionBridge,CONTEXT,observe_common_safely
        from tests.test_reasoning_common_selection import admission
        from tests.test_reasoning_pilot import MemorySink
        bridge=CommonSelectionBridge(admission=admission(self.policy),diagnostics=MemorySink(),enabled=True)
        self.addCleanup(bridge.close)
        bridge.warm_worker=False
        observed=[]
        session=UIReasoningSession(config(),self.authority,directory='unused',observer=lambda s,*_:observed.append(s))
        session.bundle=SimpleNamespace(bridge=bridge)
        for state,expected in ((None,('WAITING','UI_REASONING_WAITING_STATE')),(self.state,None)):
            now=time.perf_counter_ns()
            self.assertTrue(observe_common_safely(bridge,state,self.policy,observed_ns=now,read_end_ns=now,context=CONTEXT))
            self.assertEqual(expected,_observation_status(self.authority,bridge.observation))
            session._publish(*(expected or ('REASONING','UI_REASONING_COMPLETED')))
            self.assertEqual(state is not None,observed[-1].selection_authority)
            self.assertFalse(bridge.disabled);self.assertFalse(bridge.stopped)
            self.assertFalse(session.faulted);self.assertFalse(session.stop_event.is_set())
        self.assertEqual(0,bridge.runner.counters.get('processes',0))

    def test_display_wait_has_no_selection_flag_and_does_not_disable_bridge(self):
        observed=[];session=UIReasoningSession(config(),self.authority,directory='unused',observer=lambda s,*_:observed.append(s))
        bridge=SimpleNamespace(disabled=False,runner=SimpleNamespace(counters={}))
        session.bundle=SimpleNamespace(bridge=bridge)
        for reason in ('UI_REASONING_WAITING_SERVER_TIMER','UI_REASONING_WAITING_STATE'):
            session._publish('WAITING',reason)
            self.assertFalse(observed[-1].selection_authority)
            self.assertFalse(session.faulted);self.assertFalse(bridge.disabled);self.assertFalse(session.stop_event.is_set())
        session._publish('REASONING','UI_REASONING_COMPLETED')
        self.assertTrue(observed[-1].selection_authority)

    def test_ui_text_names_the_actual_missing_evidence(self):
        from pokiguard_v2.desktop_ui import ai_status_text
        from pokiguard_v2.reasoning_settings import AIStatus
        for state,reason,expected in (
            ('WAITING','UI_REASONING_WAITING_SERVER_TIMER','timer'),
            ('WAITING','UI_REASONING_WAITING_STATE','cập nhật bàn'),
            ('UNSUPPORTED','UI_REASONING_PROFILE_EXPIRED','hết hạn'),
            ('UNSUPPORTED','UI_REASONING_CONFIG_CHANGED','Cài đặt lối chơi')):
            text=ai_status_text(AIStatus(state,reason))
            self.assertIn(expected,text);self.assertNotIn('Tài khoản/đồ',text)

if __name__=='__main__':unittest.main()
