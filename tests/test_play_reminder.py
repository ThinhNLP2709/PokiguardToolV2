"""Native ownership + supplied real images + ordinary farm routing; zero live input."""

from contextlib import ExitStack
from dataclasses import replace
from pathlib import Path
import struct
import tempfile
from types import SimpleNamespace as NS
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.boss_entry import (
    BossLobbyState, BossCandidate, BossTargetIdentity, FarmTarget, TargetSelectionState,
)
from pokiguard_v2.boss_lobby_runtime import (
    SELECTABLE_INTERACTABLE_OFFSET, SELECTABLE_GROUPS_ALLOW_INTERACTION_OFFSET,
)
from pokiguard_v2.combat_lifecycle import CombatLifecycleObservation, CombatLifecycleSignals, CombatLifecycleState
from pokiguard_v2.farm_run import FarmInputDomain, FarmRun, FarmRunState, FarmRunStopReason, MatchResult
from pokiguard_v2.native_card_ui import NativeButtonGeometry
from pokiguard_v2.play_reminder import (
    PLAY_REMINDER_TYPE_INFO_RVA, PlayReminderControl, read_play_reminder_control,
    locate_play_reminder_confirm, same_clean_play_reminder,
)
from pokiguard_v2.postmatch_ui import locate_result_confirm
from pokiguard_v2.state import TerminalResult
from pokiguard_v2.win32_input import ClickStatus, ClickPointResult
from pokiguard_v2.win32_screenshot import read_png_rgb
from pokiguard_v2.foreground_lease_transport import LeaseStatus
from tests.test_native_card_ui import NativeFixture
from tests.test_farm_run import start_run, enter, session
from tools import farm_run as live
from tools.farm_cycle import _wait_boss_lobby
from tools.farm_cycle import LobbyWaitResult


ARTIFACT = Path(__file__).resolve().parents[1] / "docs/artifacts/play_reminder_20261022"


def lobby(branch="CHINH_PHUC_ROOM"):
    candidate = BossCandidate(0, BossTargetIdentity("1436", "Lieyun"),
                              TargetSelectionState.SELECTED, True, True)
    return NS(
        state=BossLobbyState.BOSS_LOBBY if branch=="CHINH_PHUC_ROOM" else BossLobbyState.LOBBY_OTHER,
        branch=branch, candidates=(candidate,),
        combat_lifecycle=CombatLifecycleObservation(CombatLifecycleState.LOBBY,
                                                     CombatLifecycleSignals(), "offline"),
        chinh_phuc=NS(current_room_id="1" if branch=="CHINH_PHUC_ROOM" else None,
                      current_room_type="BOSS" if branch=="CHINH_PHUC_ROOM" else None,
                      owner_username="local" if branch=="CHINH_PHUC_ROOM" else None, is_host=branch=="CHINH_PHUC_ROOM"),
        world_boss=NS(clean_for_chinh_phuc_map=True, clean_for_game_lobby=True,
                      manager_chinh_phuc=11, chinh_phuc_active_panel_index=6),
    )


def image_control(name="map_reminder.png"):
    image = read_png_rgb(ARTIFACT/name)
    # Manual annotations of the supplied screenshots. These test visual sanity
    # only; the production rectangle always comes from native Button geometry.
    rect = ((531,419,755,477) if name.startswith("map") else (277,246,402,278))
    rect = tuple(v/(image.width if i%2==0 else image.height) for i,v in enumerate(rect))
    g = NativeButtonGeometry(10,11,12,13,14,True,rect,15,image.width/image.height)
    return image, PlayReminderControl(True,True,1,1,2,3,g)


class ReminderNativeFixture(NativeFixture):
    def __init__(self):
        super().__init__()
        self.modal_root = self.node(None, (-640,-320,1280,640), (0,0,100))
        self.modal_canvas = self.component(self.modal_root, self.canvas_class)
        self.i(self.modal_canvas.native+0x38,0)
        self.board_node = self.node(self.modal_root,(-320,-180,640,360),(0,0,0))
        self.ok_node = self.node(self.board_node,(-110,-30,220,60),(0,-125,0))
        self.ok = self.component(self.ok_node,self.button_class)
        for offset in (SELECTABLE_INTERACTABLE_OFFSET,SELECTABLE_GROUPS_ALLOW_INTERACTION_OFFSET):
            self.memory.map(self.ok.managed+offset,b"\1")
        self.reminder_class = self.klass("PlayReminder","Poki.Health")
        self.instance, self.fields = self.alloc(), self.alloc()
        self.q(self.reminder_class+0x98,self.fields);self.q(self.fields,self.instance)
        self.q(self.instance,self.reminder_class)
        self.q(self.instance+0x30,self.modal_canvas.managed)
        self.q(self.instance+0x48,self.board_node.managed_transform)
        self.i(self.instance+0x24,1)
        self.vtable = self.alloc()
        self.q(self.modal_canvas.native,self.vtable)
        # Getter bytes/field verified in the binary and read-only live Canvas.
        self.getter = self.unity+0xCD630
        self.q(self.vtable+0xc8,self.getter)
        self.memory.map(self.unity+0x114430,bytes.fromhex("488b0148ffa0c8000000"))
        self.memory.map(self.getter,bytes.fromhex("807930000f95c0c3"))
        self.memory.map(self.modal_canvas.native+0x30,b"\1")
        self.resolver = NS(memory=self.memory,game_assembly_base=self.ga,
                           resolve_type_info_class=lambda rva: self.reminder_class if rva==PLAY_REMINDER_TYPE_INFO_RVA else None,
                           read_pointer=lambda a: struct.unpack("<Q",self.memory.read(a,8))[0])
        self.target = NS(memory=self.memory,resolver=self.resolver)


class NativeReminderTests(unittest.TestCase):
    def test_exact_owned_single_button_has_live_geometry(self):
        f=ReminderNativeFixture();c=read_play_reminder_control(f.target)
        self.assertTrue(c.clean,c.reasons);self.assertTrue(c.open)
        self.assertEqual(c.geometry.button,f.ok.managed)
        self.assertEqual(c.geometry.root_transform,f.modal_root.transform)

    def test_null_instance_and_unbuilt_canvas_are_absent(self):
        for null in ("instance","canvas"):
            f=ReminderNativeFixture()
            f.q(f.fields if null=="instance" else f.instance+0x30,0)
            with patch("pokiguard_v2.play_reminder.NativeCardUiReader") as reader:
                c=read_play_reminder_control(f.target)
            self.assertTrue(c.clean);self.assertIs(c.open,False);reader.assert_not_called()

    def test_hidden_canvas_with_active_game_object_is_absent(self):
        f=ReminderNativeFixture();f.memory.map(f.modal_canvas.native+0x30,b"\0")
        c=read_play_reminder_control(f.target)
        self.assertTrue(c.clean,c.reasons);self.assertIs(c.open,False)
        self.assertTrue(f.reader().read_game_object_active(f.modal_root.managed))

    def test_wrong_instance_class_cannot_authorize_input(self):
        f=ReminderNativeFixture();f.q(f.instance,f.go_class)
        self.assertFalse(read_play_reminder_control(f.target).clean)

    def test_bad_canvas_class_and_pointer_and_byte_fail_closed(self):
        for kind in ("class","pointer","enabled","getter","thunk","complex"):
            with self.subTest(kind=kind):
                f=ReminderNativeFixture()
                if kind=="class":f.q(f.modal_canvas.managed,f.go_class)
                if kind=="pointer":f.q(f.instance+0x30,17)
                if kind=="enabled":f.memory.map(f.modal_canvas.native+0x30,b"\xff")
                if kind=="getter":f.q(f.vtable+0xc8,0x20000000000)
                if kind=="thunk":f.memory.map(f.unity+0x114430,bytes(9))
                if kind=="complex":f.memory.map(f.getter,bytes(12))
                c=read_play_reminder_control(f.target)
                self.assertFalse(c.clean);self.assertIsNone(c.open);self.assertTrue(c.reasons)

    def test_ambiguous_button_or_foreign_canvas_cannot_authorize_input(self):
        for kind in ("extra","foreign","disabled","dirty"):
            f=ReminderNativeFixture()
            if kind=="extra":f.component(f.board_node,f.button_class)
            if kind=="foreign":f.q(f.instance+0x30,f.canvas.managed);f.q(f.canvas.native,f.vtable);f.memory.map(f.canvas.native+0x30,b"\1")
            if kind=="disabled":f.memory.map(f.ok.managed+SELECTABLE_INTERACTABLE_OFFSET,b"\0")
            if kind=="dirty":f.memory.map(f.ok_node.transform+0xf9,b"\1")
            c=read_play_reminder_control(f.target)
            self.assertFalse(c.clean,(kind,c));self.assertTrue(c.reasons)

    def test_changed_button_position_is_read_again(self):
        f=ReminderNativeFixture();a=read_play_reminder_control(f.target)
        f.memory.map(f.ok_node.trs,struct.pack("<3f",90,-90,0))
        b=read_play_reminder_control(f.target)
        self.assertTrue(b.clean,b.reasons)
        self.assertNotEqual(a.geometry.viewport_rect,b.geometry.viewport_rect)
        self.assertFalse(same_clean_play_reminder(a,b))

    def test_different_literal_getter_cannot_weaken_native_signature(self):
        f=ReminderNativeFixture()
        for code in ("0fb64140c3", "8a4140c3"):
            f.memory.map(f.getter,bytes.fromhex(code).ljust(12,b"\xcc"))
            self.assertFalse(read_play_reminder_control(f.target).clean)


class ScreenshotReminderTests(unittest.TestCase):
    def test_both_supplied_images_pass_exact_owned_button_sanity(self):
        for name in ("map_reminder.png","lobby_reminder.png"):
            image,c=image_control(name)
            found=locate_play_reminder_confirm(image.rgb,image.width,image.height,c)
            self.assertTrue(found.found,(name,found))
            self.assertAlmostEqual(found.normalized_point[0],0.5,delta=0.01)
            self.assertFalse(locate_result_confirm(image.rgb,image.width,image.height).found)

    def test_image_cannot_authorize_input_without_native_identity(self):
        i,c=image_control()
        for invalid in (replace(c,clean=False),replace(c,open=False),replace(c,geometry=None)):
            self.assertFalse(locate_play_reminder_confirm(i.rgb,i.width,i.height,invalid).found)

    def test_wrong_native_rectangle_or_cover_or_aspect_rejected(self):
        i,c=image_control()
        for invalid in (replace(c,geometry=replace(c.geometry,viewport_rect=(.1,.1,.3,.2))),
                        replace(c,geometry=replace(c.geometry,root_aspect=1.7))):
            self.assertFalse(locate_play_reminder_confirm(i.rgb,i.width,i.height,invalid).found)
        self.assertFalse(locate_play_reminder_confirm(bytes(len(i.rgb)),i.width,i.height,c).found)


class ReminderPermitTests(unittest.TestCase):
    def test_outside_states_allowed_without_changing_counters(self):
        for state in (FarmRunState.WAIT_INITIAL_BOSS_LOBBY,FarmRunState.RESOLVE_TARGET,
                      FarmRunState.ENTRY_READY,FarmRunState.WAIT_BOSS_LOBBY):
            r=FarmRun(FarmTarget("1436"));r.state=state
            p=r.reserve_health_reminder_dismiss(identity="native:1",foreground=True,outside_combat=True)
            self.assertIsNotNone(p);self.assertTrue(r.complete_health_reminder_dismiss(p,sent=True))
            s=r.snapshot();self.assertEqual(s.total_lobby_inputs,1)
            self.assertEqual((s.completed_matches,s.match_attempts,s.total_gameplay_inputs,s.total_postmatch_inputs),(0,0,0,0))
            self.assertIs(r.state,state)
            self.assertIsNone(r.reserve_health_reminder_dismiss(identity="native:1",foreground=True,outside_combat=True))
            self.assertIsNotNone(r.reserve_health_reminder_dismiss(identity="native:2",foreground=True,outside_combat=True))

    def test_combat_transition_recovery_stop_and_focus_never_get_permit(self):
        for state in (FarmRunState.COMBAT_ACTIVE,FarmRunState.ENTRY_PENDING,FarmRunState.WAIT_OPENING,
                      FarmRunState.WAIT_POSTMATCH,FarmRunState.RECOVERY_ACTIVE,FarmRunState.SAFE_STOP):
            r=FarmRun(FarmTarget("1436"));r.state=state
            self.assertIsNone(r.reserve_health_reminder_dismiss(identity="x",foreground=True,outside_combat=True))
        for opts in ({"foreground":False,"outside_combat":True}, {"foreground":True,"outside_combat":False}):
            self.assertIsNone(FarmRun(FarmTarget("1436")).reserve_health_reminder_dismiss(identity="x",**opts))


class ReminderControllerTests(unittest.TestCase):
    def setUp(self):
        self.stack=ExitStack();self.addCleanup(self.stack.close)
        self.tmp=self.stack.enter_context(tempfile.TemporaryDirectory())
        self.image,self.control=image_control()
        self.r=FarmRun(FarmTarget("1436"));self.r.state=FarmRunState.WAIT_BOSS_LOBBY
        self.l=lobby();self.provider=NS(current_session_key=None)
        self.executor=Mock();self.executor.window_status.return_value=NS(valid=True,foreground=True)
        self.executor.send_normalized_point.return_value=ClickPointResult(ClickStatus.SENT)
        self.keys=Mock();self.keys.poll.return_value=(False,False)
        def read(_):
            return PlayReminderControl(False,True) if self.executor.send_normalized_point.call_count else self.control
        self.read=self.stack.enter_context(patch.object(live,"read_play_reminder_control",side_effect=read))
        self.capture=self.stack.enter_context(patch.object(live,"capture_client_rgb",return_value=self.image))
        self.stack.enter_context(patch.object(live,"write_png_rgb"))
        self.stack.enter_context(patch.object(live,"write_failure_png_rgb"))
        self.restore=self.stack.enter_context(patch.object(live,"_restore_bound_game_foreground",return_value=True))
        self.fresh=self.stack.enter_context(patch.object(live,"_read_lobby_runtime_with_provider_fallback",side_effect=lambda *_a,**_k:self.l))

    def call(self,**kw):
        return live._dismiss_play_reminder(run=self.r,process=NS(pid=1,is_running=lambda:True),
                provider=self.provider,lobby=self.l,binding=object(),executor=self.executor,
                directory=Path(self.tmp),hotkeys=self.keys,**kw)

    def test_boss_room_dismisses_once_without_entry_or_reward_click(self):
        self.assertEqual(self.call(),"DISMISSED")
        self.executor.send_normalized_point.assert_called_once()
        self.assertEqual([p.domain for p in self.r.input_records],[FarmInputDomain.BOSS_HEALTH_REMINDER_DISMISS])
        self.assertIs(self.r.state,FarmRunState.WAIT_BOSS_LOBBY)
        self.assertEqual(self.call(),"ABSENT")
        self.executor.send_normalized_point.assert_called_once()

    def test_map_dismissal_preserves_immutable_target_and_match_accounting(self):
        self.r=start_run();enter(self.r,session(1))
        self.r.normal_combat_ended(MatchResult.WIN);self.r.observe_postmatch()
        self.l=lobby("CHINH_PHUC_ISLAND");before=(self.r.target,self.r.completed_matches,self.r.match_attempts)
        self.assertEqual(self.call(),"DISMISSED")
        self.assertEqual(before,(self.r.target,self.r.completed_matches,self.r.match_attempts))
        self.assertEqual(self.r.completed_matches,1)

    def test_absent_does_not_capture_focus_or_input(self):
        self.read.side_effect=None;self.read.return_value=PlayReminderControl(False,True)
        self.assertEqual(self.call(),"ABSENT")
        self.capture.assert_not_called();self.restore.assert_not_called()
        self.executor.send_normalized_point.assert_not_called()

    def test_emergency_before_modal_never_clicks(self):
        self.keys.poll.return_value=(False,True)
        self.assertEqual(self.call(),"BLOCKED")
        self.assertIs(self.r.stop_reason,FarmRunStopReason.EMERGENCY_STOP)
        self.executor.send_normalized_point.assert_not_called()

    def test_combat_owner_or_unknown_lifecycle_never_clicks(self):
        for mode in ("owner","unknown","error"):
            self.r=FarmRun(FarmTarget("1436"));self.l=lobby();self.provider.current_session_key=None
            if mode=="owner":self.provider.current_session_key=object()
            if mode=="unknown":self.l.combat_lifecycle=replace(self.l.combat_lifecycle,state=CombatLifecycleState.UNKNOWN)
            if mode=="error":self.l.combat_lifecycle=replace(self.l.combat_lifecycle,signals=CombatLifecycleSignals(read_errors=("bad",)))
            self.assertEqual(self.call(),"DEFERRED")
            self.assertFalse(self.r.stopped)
        self.read.assert_not_called()
        self.capture.assert_not_called();self.restore.assert_not_called()
        self.executor.send_normalized_point.assert_not_called()

    def test_transitional_lifecycles_never_read_popup_statics_or_stop_return(self):
        for state in (CombatLifecycleState.ENTERING,CombatLifecycleState.ACTIVE,
                      CombatLifecycleState.POSTMATCH,CombatLifecycleState.LEAVING):
            with self.subTest(state=state):
                self.l=lobby();self.l.combat_lifecycle=replace(self.l.combat_lifecycle,state=state)
                self.assertEqual(self.call(),"DEFERRED")
                self.assertFalse(self.r.stopped)
        self.read.assert_not_called();self.capture.assert_not_called()
        self.executor.send_normalized_point.assert_not_called()

    def test_attempt71_read_error_during_hub_reload_waits_then_returns_boss_room(self):
        import json
        fixture=Path(__file__).parent/'fixtures/postmatch_leaving_reminder_read_error_20261025.json'
        def ns(value):
            if isinstance(value,dict):return NS(**{k:ns(v) for k,v in value.items()})
            if isinstance(value,list):return tuple(ns(v) for v in value)
            return value
        transitioning=ns(json.loads(fixture.read_text(encoding='utf-8'))['lobby'])
        transitioning.state=BossLobbyState(transitioning.state)
        transitioning.combat_lifecycle.state=CombatLifecycleState(transitioning.combat_lifecycle.state)
        self.l=transitioning
        self.read.side_effect=None
        self.read.return_value=PlayReminderControl(None,False,reasons=('static instance class does not match type-info',))
        self.assertEqual(self.call(),"DEFERRED")
        self.read.assert_not_called();self.assertFalse(self.r.stopped)

        ready=lobby();samples=iter([transitioning,ready,ready])
        def next_lobby(*_a,**_k):
            self.l=next(samples);return self.l
        def popup_read(_):
            self.assertIsNot(self.l,transitioning,'must not inspect torn popup during hub reload')
            return PlayReminderControl(False,True)
        self.read.side_effect=popup_read
        with patch('tools.farm_cycle._read_lobby_runtime_with_provider_fallback',side_effect=next_lobby),patch('tools.farm_cycle.time.sleep'):
            result=_wait_boss_lobby(NS(is_running=lambda:True),self.provider,self.r.target,2,0,self.keys,
                outside_modal_handler=lambda current:self.call())
        self.assertTrue(result.ready);self.assertFalse(self.r.stopped)
        self.assertEqual(self.read.call_count,2)
        self.executor.send_normalized_point.assert_not_called()

    def test_stopped_run_never_reads_or_clicks_health_modal(self):
        self.r.safe_stop(FarmRunStopReason.STOPPED_GRACEFULLY)
        self.assertEqual(self.call(),"BLOCKED")
        self.read.assert_not_called();self.capture.assert_not_called()
        self.executor.send_normalized_point.assert_not_called()

    def test_real_modal_after_transition_is_still_dismissed_once_before_ready(self):
        transitioning=lobby()
        transitioning.combat_lifecycle=replace(transitioning.combat_lifecycle,state=CombatLifecycleState.LEAVING)
        ready=lobby();samples=iter([transitioning,ready,ready,ready])
        def next_lobby(*_a,**_k):
            self.l=next(samples);return self.l
        read_when_ready=self.read.side_effect
        def popup_read(process):
            self.assertIsNot(self.l,transitioning)
            return read_when_ready(process)
        self.read.side_effect=popup_read
        with patch('tools.farm_cycle._read_lobby_runtime_with_provider_fallback',side_effect=next_lobby),patch('tools.farm_cycle.time.sleep'):
            result=_wait_boss_lobby(NS(is_running=lambda:True),self.provider,self.r.target,2,0,self.keys,
                outside_modal_handler=lambda current:self.call())
        self.assertTrue(result.ready);self.assertFalse(self.r.stopped)
        self.executor.send_normalized_point.assert_called_once()
        self.assertEqual([p.domain for p in self.r.input_records],[FarmInputDomain.BOSS_HEALTH_REMINDER_DISMISS])

    def test_existing_exact_room_proof_survives_uninitialized_combat_statics(self):
        self.l.chinh_phuc.clean=True
        self.l.combat_lifecycle=replace(self.l.combat_lifecycle,state=CombatLifecycleState.UNKNOWN)
        self.assertEqual(self.call(),"DISMISSED")
        self.executor.send_normalized_point.assert_called_once()

    def test_stale_server_match_without_local_owner_can_dismiss_in_room(self):
        self.l.combat_lifecycle=replace(self.l.combat_lifecycle,state=CombatLifecycleState.STALE_SERVER_MATCH)
        self.assertEqual(self.call(),"DISMISSED")
        self.executor.send_normalized_point.assert_called_once()

    def test_native_change_before_click_blocks(self):
        changed=replace(self.control,generation=2)
        self.read.side_effect=[self.control,self.control,changed]
        self.assertEqual(self.call(),"BLOCKED");self.executor.send_normalized_point.assert_not_called()

    def test_inflight_native_layout_can_settle_before_single_click(self):
        self.read.side_effect=[PlayReminderControl(None,False,reasons=("dirty rect",)),
                               self.control,self.control,self.control,PlayReminderControl(False,True)]
        with patch.object(live.time,"sleep"):
            self.assertEqual(self.call(),"DISMISSED")
        self.executor.send_normalized_point.assert_called_once()

    def test_permanently_unreadable_modal_is_bounded_without_input(self):
        self.read.side_effect=None
        self.read.return_value=PlayReminderControl(None,False,reasons=("bad ownership",))
        with patch.object(live.time,"monotonic",side_effect=[0,0,3]),patch.object(live.time,"sleep"):
            self.assertEqual(self.call(),"BLOCKED")
        self.executor.send_normalized_point.assert_not_called()

    def test_postmatch_map_then_exact_target_reentry_through_existing_router(self):
        self.r=start_run();enter(self.r,session(1))
        self.r.normal_combat_ended(MatchResult.WIN);self.r.observe_postmatch()
        self.l=lobby("CHINH_PHUC_ISLAND")
        handler=lambda _lobby: self.call()
        with patch("tools.farm_cycle._read_lobby_runtime_with_provider_fallback",return_value=self.l),patch("tools.farm_cycle.time.sleep"):
            uncovered=_wait_boss_lobby(NS(is_running=lambda:True),self.provider,self.r.target,
                    2,0,self.keys,outside_modal_handler=handler)
        self.assertEqual(uncovered.reason,"CHINH_PHUC_MAP_CANDIDATE")
        ready=LobbyWaitResult(True,BossLobbyState.BOSS_LOBBY,None,"BOSS_LOBBY_READY",lobby(),2)
        def select_exact_target(**kw):
            self.assertEqual(kw["target"],self.r.target)
            permit=self.r.reserve_target_select(foreground=True)
            self.assertIsNotNone(permit)
            self.assertTrue(self.r.complete_target_select(permit,sent=True,detail="OFFLINE_TARGET_BUTTON"))
            return ready
        before=len(self.r.input_records)
        with patch.object(live,"_return_from_chinh_phuc_map",side_effect=select_exact_target) as route:
            result=live._recover_postmatch_boss_lobby(run=self.r,process=object(),provider=self.provider,
                   target=self.r.target,initial=uncovered,allow_reentry=True,writer=Mock(),
                   binding=object(),executor=self.executor,directory=Path(self.tmp),interval=0,
                   timeout=2,hotkeys=self.keys,outside_modal_handler=handler)
        self.assertIs(result,ready);route.assert_called_once()
        self.assertEqual(len(self.r.input_records),before+1)
        self.assertEqual((self.r.completed_matches,self.r.match_attempts),(1,1))
        self.assertTrue(self.r.observe_return_lobby(BossLobbyState.BOSS_LOBBY))
        self.assertIs(self.r.state,FarmRunState.RESOLVE_TARGET)

    def test_one_click_that_does_not_close_is_bounded_and_logged(self):
        self.read.side_effect=None;self.read.return_value=self.control
        with patch.object(live.time,"monotonic",side_effect=[0,0,0,0,4]),patch.object(live.time,"sleep"):
            self.assertEqual(self.call(),"BLOCKED")
        self.executor.send_normalized_point.assert_called_once()
        self.assertIs(self.r.stop_reason,FarmRunStopReason.HEALTH_REMINDER_BLOCKED)

    def test_capture_fault_gets_specific_log_and_no_input(self):
        self.capture.side_effect=OSError("capture unavailable")
        self.assertEqual(self.call(),"BLOCKED")
        self.assertIs(self.r.stop_reason,FarmRunStopReason.HEALTH_REMINDER_BLOCKED)
        self.executor.send_normalized_point.assert_not_called()

    def test_pinned_mode_uses_existing_lease_and_fresh_proof(self):
        pin=Mock()
        def execute(**kw):
            okay=kw["preflight"]() and kw["final_pre_takeover_preflight"]() and kw["action"]()
            return NS(action_succeeded=okay,status=LeaseStatus.COMPLETE)
        pin.execute_mouse.side_effect=execute
        self.assertEqual(self.call(pinned_input_session=pin),"DISMISSED")
        self.restore.assert_not_called();pin.execute_mouse.assert_called_once()
        self.executor.send_normalized_point.assert_called_once()

    def test_opening_scale_animation_waits_for_stable_geometry(self):
        animated=replace(self.control,geometry=replace(self.control.geometry,viewport_rect=(.42,.64,.58,.72)))
        self.read.side_effect=[animated,self.control,self.control,self.control,PlayReminderControl(False,True)]
        with patch.object(live.time,"sleep") as sleep:
            self.assertEqual(self.call(),"DISMISSED")
        self.assertEqual(sleep.call_count,2)
        self.executor.send_normalized_point.assert_called_once()

    def test_result_already_outside_uses_handler_not_reward_confirm(self):
        handler=Mock(return_value="DISMISSED")
        self.provider.poll=lambda:NS(combat_lifecycle=self.l.combat_lifecycle)
        result=live._confirm_postmatch(run=self.r,process=NS(pid=1),provider=self.provider,
                  binding=object(),executor=self.executor,directory=Path(self.tmp),interval=.1,
                  ui_timeout=1,hotkeys=self.keys,outside_modal_handler=handler)
        self.assertEqual(result,(True,TerminalResult.UNKNOWN,None))
        handler.assert_called_once();self.executor.send_normalized_point.assert_not_called()


class ReminderWaitRoutingTests(unittest.TestCase):
    def wait(self,room,handler):
        with patch("tools.farm_cycle._read_lobby_runtime_with_provider_fallback",return_value=room),patch("tools.farm_cycle.time.sleep"):
            return _wait_boss_lobby(NS(is_running=lambda:True),NS(current_session_key=None),
                    FarmTarget("1436"),2,.0,NS(poll=lambda:(False,False)),outside_modal_handler=handler)

    def test_modal_dismissal_forces_fresh_room_stability_before_ready(self):
        handler=Mock(side_effect=["DISMISSED","ABSENT","ABSENT"])
        result=self.wait(lobby(),handler)
        self.assertTrue(result.ready,result);self.assertEqual(handler.call_count,3)

    def test_modal_on_map_returns_existing_map_route_after_close(self):
        handler=Mock(side_effect=["DISMISSED","ABSENT","ABSENT"])
        result=self.wait(lobby("CHINH_PHUC_ISLAND"),handler)
        self.assertFalse(result.ready);self.assertEqual(result.reason,"CHINH_PHUC_MAP_CANDIDATE")
        self.assertEqual(handler.call_count,3)

    def test_blocked_modal_cannot_report_room_ready(self):
        result=self.wait(lobby(),Mock(return_value="BLOCKED"))
        self.assertFalse(result.ready);self.assertEqual(result.reason,"HEALTH_REMINDER_BLOCKED")


if __name__ == "__main__":
    unittest.main()
