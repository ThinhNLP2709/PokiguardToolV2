"""Replay attempt87's actual missing DTO; normal navigation only, no live IO."""
from contextlib import ExitStack
from copy import deepcopy
import json
from pathlib import Path
from types import SimpleNamespace as NS
import tempfile
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.boss_entry import BossLobbyState, FarmTarget
from pokiguard_v2.combat_lifecycle import CombatLifecycleState
from pokiguard_v2.farm_run import FarmRun, FarmRunState, FarmInputDomain, MatchResult
from pokiguard_v2.foreground_lease_transport import LeaseStatus
from pokiguard_v2.win32_input import ClickPointResult, ClickStatus
from tools import farm_cycle as cycle, farm_run as live
from tools.farm_cycle import LobbyWaitResult
from tests.test_farm_run import enter, session
from tests import test_farm_run as farm_fixture
from tests.test_play_reminder import lobby as healthy_lobby


def recorded_lobby(filename='room_bootstrap_failure_20261024.json'):
    raw=json.loads((Path(__file__).parent/'fixtures'/filename).read_text(encoding='utf-8'))
    def ns(value):
        if isinstance(value,dict):return NS(**{k:ns(v) for k,v in value.items()})
        if isinstance(value,list):return tuple(ns(v) for v in value)
        return value
    l=ns(raw['lobby']);l.state=BossLobbyState(l.state)
    l.combat_lifecycle.state=CombatLifecycleState(l.combat_lifecycle.state)
    return l


class Clock:
    value=0.0
    def now(self):return self.value
    def sleep(self,seconds):self.value+=max(.01,seconds)


class BootstrapCandidateTests(unittest.TestCase):
    def test_exact_recorded_timeout_is_now_a_reentry_source(self):
        l=recorded_lobby()
        self.assertIsNotNone(cycle._failed_chinh_phuc_room_bootstrap_key(l,no_combat_owner=True))
        for reason in ('BOSS_LOBBY_TIMEOUT','ROOM_BOOTSTRAP_FAILED_CANDIDATE'):
            r=LobbyWaitResult(False,l.state,None,reason,l,2)
            self.assertEqual(live._postmatch_reentry_source(r,target_pet_id=1436,current_session=None),'FAILED_ROOM_BOOTSTRAP')
        self.assertIsNone(cycle._failed_chinh_phuc_room_bootstrap_key(l,no_combat_owner=False))

    def test_healthy_foreign_unreadable_and_combat_shapes_are_not_candidates(self):
        for object_name,name,value in (
            ('chinh_phuc','room_data',123),('chinh_phuc','enemy_pet_id',1436),
            ('chinh_phuc','is_host',False),('chinh_phuc','owner_username','another_user'),
            ('chinh_phuc','button_groups_allow',False),('chinh_phuc','is_opening_flow',True),
            ('chinh_phuc','button_native',None),('combat_lifecycle','state',CombatLifecycleState.ACTIVE),
            ('combat_lifecycle','state',CombatLifecycleState.UNKNOWN),
            ('chinh_phuc','reasons',('WsRoomService read error: invalid pointer',)),
        ):
            l=recorded_lobby();setattr(getattr(l,object_name),name,value)
            with self.subTest(name=name,value=value):
                self.assertIsNone(cycle._failed_chinh_phuc_room_bootstrap_key(l,no_combat_owner=True))
        l=recorded_lobby();l.combat_lifecycle.signals.read_errors=('read failed',)
        self.assertIsNone(cycle._failed_chinh_phuc_room_bootstrap_key(l,no_combat_owner=True))

    def wait(self,read,*,f9=False):
        clock=Clock();keys=NS(poll=lambda:(False,f9))
        with patch.object(cycle,'_read_lobby_runtime_with_provider_fallback',side_effect=read),patch.object(cycle.time,'monotonic',clock.now),patch.object(cycle.time,'sleep',clock.sleep):
            result=cycle._wait_boss_lobby(NS(is_running=lambda:True),NS(current_session_key=None),
                    FarmTarget('1436'),90,.5,keys,transient_room_grace_seconds=45)
        return result,clock.value

    def test_wait_allows_existing_rehydration_grace_then_routes_instead_of_timeout(self):
        l=recorded_lobby();result,elapsed=self.wait(lambda *_:l)
        self.assertEqual(result.reason,'ROOM_BOOTSTRAP_FAILED_CANDIDATE')
        self.assertGreaterEqual(result.stable_frames,2)
        self.assertGreaterEqual(elapsed,45);self.assertLess(elapsed,90)

    def test_room_recovering_during_grace_returns_normally_without_reentry(self):
        reads=iter([recorded_lobby()]*3+[healthy_lobby()]*2)
        result,elapsed=self.wait(lambda *_:next(reads))
        self.assertTrue(result.ready);self.assertLess(elapsed,45)

    def test_f9_still_interrupts_wait_without_reentry(self):
        result,elapsed=self.wait(lambda *_:recorded_lobby(),f9=True)
        self.assertEqual(result.reason,'F9_EMERGENCY_STOP');self.assertEqual(elapsed,0)

    def test_failed_room_anchor_cannot_authorize_a_changed_room(self):
        l=recorded_lobby();key=cycle._failed_chinh_phuc_room_bootstrap_key(l,no_combat_owner=True)
        kw=dict(pet_id=1436,current_session=None,first_map_target=None,current_map_target=None,failed_bootstrap_key=key)
        self.assertTrue(live._detached_shell_exit_runtime_proven(l,**kw))
        for name in ('current_room_id','button_start','room_panel','owner_username'):
            changed=deepcopy(l);setattr(changed.chinh_phuc,name,'changed')
            self.assertFalse(live._detached_shell_exit_runtime_proven(changed,**kw))


class NullableMapCandidateTests(unittest.TestCase):
    def test_recorded_map_timeout_still_routes_back_to_the_same_target(self):
        l=recorded_lobby('postmatch_dto_null_map_20261104.json')
        self.assertTrue(live._is_map_backed_detached_chinh_phuc_room_candidate(l,target_pet_id=1436,no_combat_owner=True))
        result=LobbyWaitResult(False,l.state,None,'BOSS_LOBBY_TIMEOUT',l,2)
        self.assertEqual('CHINH_PHUC_MAP',live._postmatch_reentry_source(result,target_pet_id=1436,current_session=None))
        self.assertIsNone(live._postmatch_reentry_source(result,target_pet_id=1436,current_session=object()))

    def test_unknown_or_foreign_room_is_not_a_null_dto_probe(self):
        for object_name,key,value in (('chinh_phuc','current_room_id','other'),
                ('chinh_phuc','enemy_pet_id',650),('chinh_phuc','owner_username','other'),
                ('chinh_phuc','room_panel',None),('chinh_phuc','manager_room_native',None),
                ('chinh_phuc','is_opening_flow',True),('chinh_phuc','reasons',('invalid pointer read',)),
                ('combat_lifecycle','state',CombatLifecycleState.ACTIVE)):
            l=recorded_lobby('postmatch_dto_null_map_20261104.json');setattr(getattr(l,object_name),key,value)
            with self.subTest(key=key):self.assertFalse(live._is_map_backed_detached_chinh_phuc_room_candidate(l,target_pet_id=1436,no_combat_owner=True))


class BootstrapRouteTests(unittest.TestCase):
    def setUp(self):
        self.stack=ExitStack();self.addCleanup(self.stack.close)
        self.directory=Path(self.stack.enter_context(tempfile.TemporaryDirectory()))
        self.l=recorded_lobby();self.provider=NS(current_session_key=None)
        self.run=FarmRun(FarmTarget('1436','Lieyun'))
        self.run.observe_initial_lobby(BossLobbyState.BOSS_LOBBY);enter(self.run,session(1))
        self.run.normal_combat_ended(MatchResult.WIN);self.run.observe_postmatch()
        permit=self.run.reserve_postmatch(foreground=True)
        self.assertIsNotNone(permit);self.assertTrue(self.run.complete_postmatch(permit,sent=True))
        self.initial=LobbyWaitResult(False,self.l.state,None,'ROOM_BOOTSTRAP_FAILED_CANDIDATE',self.l,2)
        self.clock=Clock();self.clicks=[];self.stage='shell'
        self.native=farm_fixture.DetachedShellExitRuntimeTests.target(pet_id=1436,selected_pet_id=1436)
        self.map=deepcopy(self.l);self.map.chinh_phuc.current_room_id=None
        self.map.chinh_phuc.current_room_type=None;self.map.chinh_phuc.owner_username=None
        self.map.chinh_phuc.is_host=False
        self.map.world_boss.manager_chinh_phuc=self.native.manager_address
        self.map.world_boss.chinh_phuc_active_panel_index=self.native.group_index
        self.ready=LobbyWaitResult(True,BossLobbyState.BOSS_LOBBY,None,'BOSS_LOBBY_READY',healthy_lobby(),2)
        self.executor=NS(window_status=lambda _:NS(valid=True,foreground=True),
                         move_normalized_point=lambda *_:ClickStatus.SENT,
                         send_normalized_point=self.send)
        self.shell=NS(found=True,normalized_point=(.95,.07))
        self.capture=NS(width=1280,height=640,rgb=b'')
        self.restore=self.stack.enter_context(patch.object(live,'_restore_bound_game_foreground',return_value=True))
        self.stack.enter_context(patch.object(live.time,'monotonic',self.clock.now))
        self.stack.enter_context(patch.object(live.time,'sleep',self.clock.sleep))
        self.read=self.stack.enter_context(patch.object(live,'_read_lobby_runtime_with_provider_fallback',side_effect=self.read_lobby))
        self.rect=self.stack.enter_context(patch.object(live,'_runtime_room_start_rect',return_value=(.7,.8,.9,.9)))
        self.stack.enter_context(patch.object(live,'capture_client_rgb',return_value=self.capture))
        self.locator=self.stack.enter_context(patch.object(live,'locate_detached_chinh_phuc_room_shell_exit',return_value=self.shell))
        self.stack.enter_context(patch.object(live,'_stable_visual_proof',side_effect=lambda a,b,c,d:b.found and d.found))
        self.stack.enter_context(patch.object(live,'locate_confirm_leave',return_value=NS(found=False)))
        self.stack.enter_context(patch.object(live,'read_hub_chinh_phuc_control',return_value=None))
        self.discover=self.stack.enter_context(patch.object(live,'_discover_chinh_phuc_map_target_for_lobby',side_effect=self.discover_map))
        self.stack.enter_context(patch.object(live,'write_png_rgb'))
        self.wait=self.stack.enter_context(patch.object(live,'_wait_boss_lobby',
            side_effect=lambda *_a,**_k:self.ready if self.stage=='map' else self.initial))

    def read_lobby(self,*_):return self.l if self.stage=='shell' else self.map

    def discover_map(self,process,pet_id,lobby,**kw):
        self.assertNotEqual(self.stage,'shell','must close failed room before scanning/selecting map')
        self.assertEqual(pet_id,1436)
        return self.native

    def send(self,binding,point):
        self.clicks.append(point)
        if point==self.shell.normalized_point:self.stage='map'
        return ClickPointResult(ClickStatus.SENT)

    def call(self,**kwargs):
        return live._recover_postmatch_boss_lobby(run=self.run,process=NS(pid=1,is_running=lambda:True),
            provider=self.provider,target=self.run.target,initial=self.initial,allow_reentry=True,
            writer=Mock(),binding=object(),executor=self.executor,directory=self.directory,
            interval=.1,timeout=2,hotkeys=NS(poll=lambda:(False,False)),**kwargs)

    def test_confirmed_result_closes_failed_room_then_selects_exact_target_and_returns(self):
        before=(self.run.completed_matches,self.run.match_attempts,self.run.technical_recoveries)
        self.assertIs(self.call(),self.ready)
        self.assertEqual(self.clicks,[self.shell.normalized_point,self.native.viewport_point])
        self.assertEqual(before,(self.run.completed_matches,self.run.match_attempts,self.run.technical_recoveries))
        self.assertEqual([r.domain for r in self.run.input_records if r.sent][-2:],
                         [FarmInputDomain.BOSS_ROOM_SHELL_EXIT,FarmInputDomain.BOSS_TARGET_SELECT])
        self.assertTrue(self.run.observe_return_lobby(BossLobbyState.BOSS_LOBBY))
        self.assertIs(self.run.state,FarmRunState.RESOLVE_TARGET)

    def test_pinned_mode_uses_same_fresh_room_and_target_proofs(self):
        pin=Mock()
        def lease(**kw):
            okay=kw['preflight']() and (kw['final_pre_takeover_preflight'] is None or kw['final_pre_takeover_preflight']()) and kw['action']()
            return NS(action_succeeded=okay,status=LeaseStatus.COMPLETE)
        pin.execute_mouse.side_effect=lease
        self.assertIs(self.call(pinned_input_session=pin),self.ready)
        self.assertEqual(len(self.clicks),2);self.restore.assert_not_called()

    def test_external_user_attempt9_timeout_now_reenters_in_pinned_mode(self):
        # Independent machine: different room, account and native addresses,
        # same missing-bootstrap shape. Do not copy the old room's identity.
        self.l=recorded_lobby('room_bootstrap_failure_external_user_20261024.json')
        self.initial=LobbyWaitResult(False,self.l.state,None,'BOSS_LOBBY_TIMEOUT',self.l,0)
        pin=Mock()
        def lease(**kw):
            okay=kw['preflight']() and (kw['final_pre_takeover_preflight'] is None or kw['final_pre_takeover_preflight']()) and kw['action']()
            return NS(action_succeeded=okay,status=LeaseStatus.COMPLETE)
        pin.execute_mouse.side_effect=lease
        before=(self.run.completed_matches,self.run.match_attempts,self.run.target)
        self.assertIs(self.call(pinned_input_session=pin),self.ready)
        self.assertEqual(self.clicks,[self.shell.normalized_point,self.native.viewport_point])
        self.assertEqual(before,(self.run.completed_matches,self.run.match_attempts,self.run.target))
        self.assertEqual(self.l.chinh_phuc.current_room_id,'Coop_252354')

    def enable_leave_modal(self,*,change_room=False):
        confirm_point=(.40,.56);hits=[]
        self.read.side_effect=lambda *_:self.map if self.stage=='map' else self.l
        def send(binding,point):
            self.clicks.append(point)
            if point==self.shell.normalized_point:self.stage='confirm'
            elif point==confirm_point:self.stage='map'
            return ClickPointResult(ClickStatus.SENT)
        self.executor.send_normalized_point=send
        def modal(*_):
            if self.stage=='confirm':
                hits.append(1)
                if change_room and len(hits)==3:self.l.chinh_phuc.current_room_id='Coop_other'
                return NS(found=True,normalized_point=confirm_point)
            return NS(found=False)
        self.stack.enter_context(patch.object(live,'locate_confirm_leave',side_effect=modal))
        return confirm_point

    def test_failed_room_exit_with_leave_modal_confirms_once_then_reenters(self):
        point=self.enable_leave_modal()
        self.assertIs(self.call(),self.ready)
        self.assertEqual(self.clicks,[self.shell.normalized_point,point,self.native.viewport_point])
        domains=[r.domain for r in self.run.input_records if r.sent]
        self.assertEqual(domains[-3:],[FarmInputDomain.BOSS_ROOM_SHELL_EXIT,
            FarmInputDomain.BOSS_ROOM_SHELL_CONFIRM,FarmInputDomain.BOSS_TARGET_SELECT])

    def test_room_changes_before_leave_confirmation_never_confirms_another_room(self):
        self.enable_leave_modal(change_room=True)
        self.call();self.assertEqual(self.clicks,[self.shell.normalized_point])
        self.discover.assert_not_called()

    def test_native_geometry_or_room_visual_missing_never_clicks(self):
        self.rect.return_value=None
        self.call();self.assertEqual(self.clicks,[]);self.discover.assert_not_called()
        self.rect.return_value=(.7,.8,.9,.9);self.locator.return_value=NS(found=False)
        self.call();self.assertEqual(self.clicks,[]);self.discover.assert_not_called()

    def test_room_rehydrates_before_atomic_preflight_never_closes_healthy_room(self):
        self.read.side_effect=lambda *_:healthy_lobby()
        self.wait.side_effect=None;self.wait.return_value=self.ready
        self.assertIs(self.call(),self.ready)
        self.assertEqual(self.clicks,[]);self.discover.assert_not_called()

    def test_missing_reward_confirmation_never_authorizes_exit(self):
        self.run.input_records=[r for r in self.run.input_records if r.domain is not FarmInputDomain.POSTMATCH_CONFIRM]
        self.call();self.assertEqual(self.clicks,[]);self.restore.assert_not_called()

    def test_foreign_target_argument_never_authorizes_failed_room_exit(self):
        result=live._return_from_chinh_phuc_map(run=self.run,process=NS(pid=1,is_running=lambda:True),
            provider=self.provider,target=FarmTarget('650','other'),initial=self.initial,
            binding=object(),executor=self.executor,directory=self.directory,interval=.1,
            timeout=2,hotkeys=NS(poll=lambda:(False,False)))
        self.assertIsNone(result);self.assertEqual(self.clicks,[]);self.restore.assert_not_called()

    def test_blocked_health_popup_never_clicks_through_to_room_exit(self):
        self.call(outside_modal_handler=lambda _:'BLOCKED')
        self.assertEqual(self.clicks,[]);self.locator.assert_not_called()

    def test_changed_map_target_after_exit_never_selects_another_boss(self):
        wrong=deepcopy(self.native);wrong.pet_id=650
        self.discover.side_effect=None;self.discover.return_value=wrong
        self.call();self.assertEqual(self.clicks,[self.shell.normalized_point])

    def test_health_popup_handler_is_called_before_room_proof(self):
        calls=[]
        def modal(_):
            calls.append('modal')
            if len(calls)==1:
                self.assertEqual(self.locator.call_count,0)
                return 'DISMISSED'
            return 'ABSENT'
        self.assertIs(self.call(outside_modal_handler=modal),self.ready)
        self.assertGreaterEqual(len(calls),2)
        self.assertEqual(len(self.clicks),2)

    def test_popup_or_reconnection_exposes_map_and_uses_remaining_reentry_pass(self):
        calls=[]
        def modal(_):
            calls.append('modal');self.stage='map'
            return 'DISMISSED' if len(calls)==1 else 'ABSENT'
        exposed=LobbyWaitResult(False,self.map.state,None,'CHINH_PHUC_MAP_CANDIDATE',self.map,2)
        self.wait.side_effect=[exposed,self.ready]
        self.assertIs(self.call(outside_modal_handler=modal),self.ready)
        self.assertEqual(self.clicks,[self.native.viewport_point])
        self.assertEqual((self.run.completed_matches,self.run.match_attempts),(1,1))

    def use_recorded_dto_null_map(self):
        self.l=recorded_lobby('postmatch_dto_null_map_20261104.json')
        self.native=farm_fixture.DetachedShellExitRuntimeTests.target(pet_id=1436,selected_pet_id=1436,
            manager_address=self.l.world_boss.manager_chinh_phuc)
        self.native.group_index=self.l.world_boss.chinh_phuc_active_panel_index
        self.map=deepcopy(self.l)
        self.discover.side_effect=lambda *_a,**_k:self.native
        self.initial=LobbyWaitResult(False,self.l.state,None,'CHINH_PHUC_MAP_CANDIDATE',self.l,2)
        self.wait.side_effect=None;self.wait.return_value=self.ready

    def test_recorded_390_null_dto_probes_visible_shell_before_cached_map_click(self):
        self.use_recorded_dto_null_map()
        self.assertIs(self.call(),self.ready)
        self.assertEqual(self.clicks,[self.shell.normalized_point,self.native.viewport_point])
        self.assertEqual((self.run.completed_matches,self.run.match_attempts),(1,1))

    def test_same_null_dto_on_real_map_does_not_authorize_a_shell_exit(self):
        self.use_recorded_dto_null_map();self.locator.return_value=NS(found=False)
        self.assertIs(self.call(),self.ready)
        self.assertEqual(self.clicks,[self.native.viewport_point])
        self.assertLess(self.clock.value,5)

    def test_foreground_target_is_rechecked_immediately_before_click(self):
        self.use_recorded_dto_null_map();self.locator.return_value=NS(found=False)
        calls=[];wrong=deepcopy(self.native);wrong.pet_id=650
        def discover(*_a,**_k):
            calls.append(1);return self.native if len(calls)<4 else wrong
        self.discover.side_effect=discover
        self.call();self.assertEqual(self.clicks,[])
        self.assertFalse(any(x.domain is FarmInputDomain.BOSS_TARGET_SELECT for x in self.run.input_records))

    def test_map_target_missing_for_one_atomic_read_reenters_once(self):
        self.use_recorded_dto_null_map()
        self.locator.return_value = NS(found=False)
        # Two stable target reads, then the recorded B15 atomic read miss.
        self.discover.side_effect = [self.native, self.native, None, self.native, self.native]
        self.assertIs(self.call(), self.ready)
        self.assertEqual(self.clicks, [self.native.viewport_point])
        self.assertEqual(self.discover.call_count, 5)
        selected = [e for e in self.run.events if e.event == "chinh_phuc_map_target_selected"]
        self.assertEqual(len(selected), 1)
        self.assertEqual(selected[0].detail["atomicRuntimeProbes"], 2)

    def test_missing_atomic_map_target_stops_after_bounded_reads(self):
        self.use_recorded_dto_null_map()
        self.locator.return_value = NS(found=False)
        self.wait.return_value = self.initial
        self.discover.side_effect = [self.native, self.native, None, None, None, None]
        self.assertFalse(self.call().ready)
        self.assertEqual(self.discover.call_count, 6)
        self.assertEqual(self.clicks, [])

    def test_atomic_map_retry_rejects_a_readable_button_change(self):
        self.use_recorded_dto_null_map()
        self.locator.return_value = NS(found=False)
        self.wait.return_value = self.initial
        changed = deepcopy(self.native)
        changed.button_address += 8
        self.discover.side_effect = [self.native, self.native, None, changed]
        self.assertFalse(self.call().ready)
        self.assertEqual(self.discover.call_count, 4)
        self.assertEqual(self.clicks, [])

    def test_health_modal_is_rechecked_during_optional_shell_probe(self):
        self.use_recorded_dto_null_map();calls=[]
        def modal(_):
            calls.append(1)
            return 'BLOCKED' if len(calls)>2 else 'ABSENT'
        self.call(outside_modal_handler=modal)
        self.assertGreater(len(calls),2);self.assertEqual(self.clicks,[])

    def test_late_room_reconnect_after_map_preflight_does_not_become_timeout(self):
        self.use_recorded_dto_null_map()
        with patch.object(live,'_return_from_chinh_phuc_map',return_value=None):
            result=self.call()
        self.assertIs(result,self.ready);self.assertEqual(self.clicks,[])
        self.assertFalse(self.run.stopped)

    def test_return_timeout_persists_one_failure_image_without_changing_outcome(self):
        from pokiguard_v2.play_reminder import PlayReminderControl
        with patch.object(live,'_return_from_chinh_phuc_map',return_value=self.initial),patch.object(live,'read_play_reminder_control',return_value=PlayReminderControl(False,True)),patch.object(live,'write_failure_png_rgb') as save:
            result=self.call()
        self.assertIs(result,self.initial);save.assert_called_once()
        self.assertEqual(save.call_args.args[0].name,'return_lobby_failure.png')
        self.assertEqual(self.clicks,[])



if __name__=='__main__':unittest.main()
