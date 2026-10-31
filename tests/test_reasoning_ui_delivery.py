"""Normal UI opt-in, BASIC fallback, and bounded owner lifecycle. No game IO."""
from collections import Counter
from dataclasses import replace
import json
from pathlib import Path
import tempfile,threading,time,unittest
from types import SimpleNamespace
from unittest.mock import Mock,patch

from pokiguard_v2.basic_policy import Intelligence,PlayStyle
from pokiguard_v2.desktop_control_plane import DesktopConfig,DesktopControlPlane,StaticUnavailableRuntimeProvider
from pokiguard_v2.desktop_farm_controller import DesktopFarmControllerManager,ControllerLaunch
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
from pokiguard_v2.win32_input import FarmControlHotkeyEdges,BoardInputMode
from pokiguard_v2.pet_configuration import EvolutionTarget,DamageCardMode,DemonTargetGem
from pokiguard_v2.reasoning_settings import AISettings
from pokiguard_v2.reasoning_ui_scope import ui_reasoning_scope_reason
from pokiguard_v2.reasoning_ui_session import UIReasoningSession,create_ui_reasoning_session

ROOT=Path(__file__).resolve().parents[1]


def config(**kwargs):
    return replace(DesktopConfig(play_style=PlayStyle.DEMON_AEGIS_FARM,evolution=EvolutionTarget.NONE,
        damage_card=DamageCardMode.PET_PASSIVE,pet_skill_fire_value=4,boss_id='1436',boss_name='Lieyun',
        ai=AISettings(False,4000,True)),**kwargs)


def wait(predicate,timeout=5):
    deadline=time.perf_counter()+timeout
    while not predicate():
        if time.perf_counter()>=deadline:raise AssertionError('owner did not finish')
        time.sleep(.005)


class IntentAndFallbackTests(unittest.TestCase):
    def test_old_settings_stay_basic_and_roundtrip_new_intent(self):
        self.assertFalse(AISettings.from_dict(None).reasoning_enabled)
        self.assertNotIn('reasoning_enabled',AISettings().to_dict())
        cfg=config()
        self.assertIs(cfg.intelligence,Intelligence.BASIC)
        with tempfile.TemporaryDirectory() as d:
            store=DesktopPreferenceStore(Path(d)/'prefs.json');store.save(cfg)
            loaded=store.load()
            self.assertTrue(loaded.loaded);self.assertTrue(loaded.config.ai.reasoning_enabled)
            self.assertIs(loaded.config.intelligence,Intelligence.BASIC)
            self.assertEqual(cfg.gameplay_config,loaded.config.gameplay_config)

    def test_invalid_intent_type_does_not_silently_enable(self):
        for value in ('true',1,None):
            with self.subTest(value=value),self.assertRaises(ValueError):AISettings(reasoning_enabled=value)

    def test_legacy_native_config_decodes_without_rewriting_original_bytes(self):
        from pokiguard_v2.board_diagnostics import jsonable
        from pokiguard_v2.reasoning_calibration import decode_config
        raw=jsonable(config(ai=AISettings()));raw['ai'].pop('reasoning_enabled')
        before=json.dumps(raw,sort_keys=True)
        self.assertFalse(decode_config(raw).ai.reasoning_enabled)
        self.assertEqual(before,json.dumps(raw,sort_keys=True))
        raw['ai']['reasoning_enabled']='false'
        with self.assertRaises(ValueError):decode_config(raw)
        raw['ai']['reasoning_enabled']=True
        self.assertTrue(decode_config(raw).ai.reasoning_enabled)

    def test_scope_and_lower_random_budget_keep_native_reserve_domain(self):
        cfg=config();self.assertIsNone(ui_reasoning_scope_reason(cfg,require_target=True))
        from pokiguard_v2.input_randomization import InputRandomization
        self.assertIsNone(ui_reasoning_scope_reason(replace(cfg,input_randomization=InputRandomization(
            reaction_max_seconds=0,inter_click_max_seconds=0,coordinate_max_percent=0))))
        for changed in (replace(cfg,boss_id='1289'),replace(cfg,pet_skill_fire_value=3),
            replace(cfg,demon_target_gem=DemonTargetGem.HEALTH),replace(cfg,ai=AISettings(True,4000,True)),
            replace(cfg,board_input_mode=BoardInputMode.DRAG)):
            with self.subTest(changed=changed):self.assertIsNotNone(ui_reasoning_scope_reason(changed,require_target=True))

    def test_disabled_does_not_load_profile_or_allocate(self):
        loader=Mock(side_effect=AssertionError('disabled must not load'))
        self.assertIsNone(create_ui_reasoning_session(DesktopConfig(),paths=None,game_executable=None,
            directory=Path('unused'),observer=Mock(),profile_loader=loader))
        loader.assert_not_called()

    def test_other_target_or_missing_profile_falls_back_without_worker(self):
        events=[];loader=Mock(side_effect=ValueError('UI_REASONING_PROFILE_MISSING'))
        for cfg in (config(boss_id='1289'),config()):
            self.assertIsNone(create_ui_reasoning_session(cfg,paths=None,game_executable=None,
                directory=Path('unused'),observer=lambda status,*_:events.append(status),profile_loader=loader))
        self.assertEqual(1,loader.call_count)
        self.assertEqual(['UI_REASONING_TARGET_UNSUPPORTED','UI_REASONING_PROFILE_MISSING'],[s.reason for s in events])

    def test_normal_controller_runs_same_basic_arguments_on_setup_failure(self):
        with tempfile.TemporaryDirectory() as d:
            manager=DesktopFarmControllerManager(Path(d),runner=lambda *_:0)
            results=[]
            def farm(args,**kwargs):
                self.assertNotIn('reasoning_session',kwargs);self.assertNotIn('shadow_session',kwargs)
                self.assertEqual('demon_aegis_farm',args.play_style)
                results.append(vars(args).copy());return 7
            with (patch('tools.farm_run.run',side_effect=farm),patch('tools.runtime_common.configured_game_executable',return_value=SimpleNamespace(executable=Path(d)/'fake.exe')),
                patch('pokiguard_v2.reasoning_ui_session.create_ui_reasoning_session',side_effect=OSError('synthetic'))):
                self.assertEqual(7,manager._run_production(ControllerLaunch(config(),None),FarmControlHotkeyEdges(),lambda *_:None))
                self.assertEqual(7,manager._run_production(ControllerLaunch(config(ai=AISettings()),None),FarmControlHotkeyEdges(),lambda *_:None))
            self.assertEqual(results[0],results[1])

    def test_controller_does_not_let_display_failure_stop_basic(self):
        with tempfile.TemporaryDirectory() as d:
            manager=DesktopFarmControllerManager(Path(d),runner=lambda *_:0)
            with patch('tools.farm_run.run',return_value=9) as farm,patch('tools.runtime_common.configured_game_executable',return_value=None):
                result=manager._run_production(ControllerLaunch(config(),None),FarmControlHotkeyEdges(),Mock(side_effect=RuntimeError('display')))
            self.assertEqual(9,result);farm.assert_called_once()

    def test_controller_stops_new_session_once_without_blocking(self):
        with tempfile.TemporaryDirectory() as d:
            manager=DesktopFarmControllerManager(Path(d),runner=lambda *_:0);session=Mock()
            with (patch('tools.runtime_common.configured_game_executable',return_value=SimpleNamespace(executable=Path(d)/'fake.exe')),
                patch('pokiguard_v2.reasoning_ui_session.create_ui_reasoning_session',return_value=session),patch('tools.farm_run.run',return_value=3) as farm):
                self.assertEqual(3,manager._run_production(ControllerLaunch(config(),None),FarmControlHotkeyEdges(),Mock()))
            self.assertIs(farm.call_args.kwargs['reasoning_session'],session)
            session.stop.assert_called_once();session.wait_closed.assert_not_called()

    def test_manager_accepts_only_current_ui_session_status(self):
        from pokiguard_v2.desktop_farm_controller import DesktopControllerSnapshot
        from pokiguard_v2.reasoning_settings import AIStatus,FrozenAIIntent
        with tempfile.TemporaryDirectory() as d:
            manager=DesktopFarmControllerManager(Path(d),runner=lambda *_:0)
            manager._snapshot=DesktopControllerSnapshot(generation=4,active=True)
            intent=FrozenAIIntent.freeze(config())
            status=AIStatus('REASONING','UI_REASONING_READY',intent.config_id,selection_authority=True)
            self.assertFalse(manager._observe(4,status,'AI_STATUS'))
            manager._ui_reasoning_session=SimpleNamespace(intent=intent)
            self.assertTrue(manager._observe(4,status,'AI_STATUS'))
            self.assertFalse(manager._observe(3,status,'AI_STATUS'))
            self.assertFalse(manager._observe(4,replace(status,config_id='stale'),'AI_STATUS'))
            manager._snapshot=replace(manager.snapshot(),active=False)
            self.assertFalse(manager._observe(4,status,'AI_STATUS'))


class BoundedLifecycleTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        from tests.test_reasoning_demon import fixture
        cls.authority=fixture()[3]

    def setUp(self):
        self.temp=tempfile.TemporaryDirectory();self.addCleanup(self.temp.cleanup)
        self.directory=Path(self.temp.name);self.active=0;self.peak=0
        from pokiguard_v2.reasoning_diagnostics import DiagnosticBuffer
        class Sink:
            def __init__(self,directory,*,limits):self.buffer=DiagnosticBuffer(limits)
            def flush(self,*_):return True
            def stop(self):pass
            def close(self,*_):return True
        self.sink_factory=Sink

    def factory(self,**kwargs):
        from pokiguard_v2.reasoning_diagnostics import DiagnosticBuffer,LogLimits
        self.active+=1;self.peak=max(self.peak,self.active)
        bridge=SimpleNamespace(stopped=False,disabled=False,counts=Counter(),observation=None,
            result_ready=threading.Event(),timing_diagnostics=DiagnosticBuffer(LogLimits()),
            runner=SimpleNamespace(counters=Counter(processes=1,reaped=0)),thread=SimpleNamespace(is_alive=lambda:False))
        def stop():bridge.stopped=True
        def close(*_):
            stop();bridge.runner.counters['reaped']=1;self.active-=1;return True
        bridge.stop=stop;bridge.close=close
        return bridge

    def session(self,**kwargs):
        session=UIReasoningSession(config(max_match_attempts=250),self.authority,directory=self.directory/'ui',
            observer=Mock(),bridge_factory=self.factory,sink_factory=self.sink_factory,**kwargs)
        self.addCleanup(lambda:session.wait_closed(5));self.addCleanup(session.stop)
        session.bind_run('SYNTHETIC_FARM',self.directory/'farm');return session

    def test_200_combats_keep_one_bridge_and_32_receipts(self):
        session=self.session()
        for _ in range(200):
            options=session.prepare_options();self.assertIn('selection_adapter',options)
            options['swap_timing_adapter'].stop();options['selection_adapter'].stop()
            wait(lambda:session.bundle is None)
        session.stop();self.assertTrue(session.wait_closed(5))
        receipt=json.loads((session.directory/'watermarks.json').read_text())
        self.assertEqual(1,self.peak);self.assertEqual(0,self.active)
        self.assertEqual(200,receipt['combats_created']);self.assertEqual(32,len(receipt['recent_combats']))
        self.assertEqual(200,receipt['worker_counts']['reaped']);self.assertTrue(receipt['history_truncated'])
        self.assertFalse(receipt['faulted'])

    def test_stop_does_not_call_blocking_sink_methods(self):
        session=self.session()
        with (patch.object(session.sink,'flush',side_effect=AssertionError('Stop caller')),
            patch.object(session.sink,'close',side_effect=AssertionError('Stop caller'))):
            # Hold the lifecycle owner briefly so only the Stop caller is measured.
            with session.lock:
                start=time.perf_counter();session.stop();elapsed=time.perf_counter()-start
                self.assertLess(elapsed,.025)
        self.assertTrue(session.wait_closed(5))

    def test_bind_failure_is_visible_and_cannot_abort_basic(self):
        session=UIReasoningSession(config(),self.authority,directory=self.directory,observer=Mock())
        with self.assertRaises(FileExistsError):session.bind_run('SYNTHETIC',self.directory/'farm')
        self.assertTrue(session.faulted);self.assertEqual({},session.prepare_options())
        self.assertTrue(session.wait_closed(.1))

    def test_previous_active_or_bad_cleanup_disables_only_ai(self):
        session=self.session();options=session.prepare_options()
        self.assertEqual({},session.prepare_options());self.assertTrue(session.faulted)
        options['swap_timing_adapter'].stop();options['selection_adapter'].stop()
        session.stop();self.assertTrue(session.wait_closed(5))


class ToggleUITests(unittest.TestCase):
    def setUp(self):
        from tests.test_reasoning_settings import OfflineAIUiTests
        OfflineAIUiTests.setUp(self)

    def test_supported_radio_save_and_reload_keep_gameplay_basic(self):
        cfg=config(ai=AISettings())
        from pokiguard_v2.desktop_ui import PLAY_STYLE_LABELS
        self.app.play_style.set(PLAY_STYLE_LABELS[cfg.play_style])
        self.plane.update_config(cfg);self.app._display_pet_config(cfg);self.app._display_ai_config(cfg)
        self.app._render()
        self.assertNotIn('disabled',self.app.ai_reasoning_widget.state())
        self.app.ai_shadow_enabled.set(True);self.app.ai_reasoning_widget.invoke();self.app._save_ai_settings()
        saved=self.plane.snapshot().config
        self.assertTrue(saved.ai.reasoning_enabled);self.assertFalse(saved.ai.shadow_enabled)
        self.assertIs(saved.intelligence,Intelligence.BASIC)
        self.assertEqual('true',self.app._draft_fields()['ai_reasoning_enabled'])
        self.app._display_ai_config(saved)
        self.assertEqual('Suy luận',self.app.intelligence.get())
        self.app.ai_basic_widget.invoke();self.app._save_ai_settings()
        self.assertFalse(self.plane.snapshot().config.ai.reasoning_enabled)

    def test_other_gem_and_active_run_lock_radio(self):
        cfg=config(demon_target_gem=DemonTargetGem.HEALTH,ai=AISettings())
        from pokiguard_v2.desktop_ui import PLAY_STYLE_LABELS
        self.app.play_style.set(PLAY_STYLE_LABELS[cfg.play_style])
        self.plane.update_config(cfg);self.app._display_pet_config(cfg);self.app._display_ai_config(cfg);self.app._render()
        self.assertIn('disabled',self.app.ai_reasoning_widget.state())
        self.app._lock_accepted_run_config(config())
        self.assertIn('disabled',self.app.ai_reasoning_widget.state())
        self.assertIn('disabled',self.app.ai_basic_widget.state())


class ProfileReviewTests(unittest.TestCase):
    """Isolated synthetic enrollment exercises the retained native proof parser.

    Zero selector costs are test data only. Never installed for live use.
    """
    @classmethod
    def setUpClass(cls):
        from contextlib import redirect_stdout
        import io,hashlib
        from pokiguard_v2.app_paths import resolve_app_paths
        from pokiguard_v2.reasoning_calibration import source_files
        from pokiguard_v2.reasoning_snapshot import digest
        from pokiguard_v2.reasoning_operational import host_fingerprint
        from tools.prepare_ui_reasoning import main
        cls.temp=tempfile.TemporaryDirectory(prefix='offline-profile-',
            dir=ROOT/'docs/phase5/artifacts/ui_reasoning_delivery_20261031')
        cls.addClassCleanup(cls.temp.cleanup);cls.root=Path(cls.temp.name)
        raw=cls.root/'raw_costs.json';raw.write_text(json.dumps([0]*100))
        q=dict(status='PASS',source_sha256=digest(source_files(ROOT)),host_sha256=host_fingerprint(),
            worker_roundtrip_pass=True,controller_byte_exact=True,cycles=100,loss=0,selector_extra_ms=0,
            origin='SYNTHETIC_GAME_STATE_REAL_LOCAL_WORKER_NO_NATIVE_INPUT',
            raw_costs=dict(path=raw.name,sha256=hashlib.sha256(raw.read_bytes()).hexdigest()))
        qpath=cls.root/'qualification.json';qpath.write_text(json.dumps(q))
        cls.paths=resolve_app_paths(environ={'POKIGUARD_V2_DATA_ROOT':str(cls.root/'data')})
        cls.profile=cls.paths.data_root/'preferences/reasoning_acceptance/acceptance.json'
        with redirect_stdout(io.StringIO()):main(['--out',str(cls.profile.parent),'--qualification',str(qpath)])
        cls.exe=cls.root/'test-only.exe';cls.exe.write_bytes(b'ISOLATED_TEST_GAME_NOT_REAL')
        data=json.loads(cls.profile.read_text());data['game_executable_sha256']=hashlib.sha256(cls.exe.read_bytes()).hexdigest()
        cls.original=json.dumps(data).encode();cls.profile.write_bytes(cls.original)

    def setUp(self):
        self.profile.write_bytes(self.original)
        self.exe.write_bytes(b'ISOLATED_TEST_GAME_NOT_REAL')
        data=json.loads(self.original)
        self.validate=patch('pokiguard_v2.game_location.validate_supported_game_assembly',return_value=data['game_build_sha256'])
        self.validate.start();self.addCleanup(self.validate.stop)

    def load(self,cfg=None):
        from pokiguard_v2.reasoning_ui_profile import load_ui_authority
        return load_ui_authority(cfg or config(),paths=self.paths,game_executable=self.exe)

    def test_original_native_proofs_bind_current_deployment_and_budget(self):
        authority=self.load(config(ai=AISettings(False,6000,True)))
        self.assertEqual(4000,authority.budget_ms)
        self.assertEqual([99,117463,488,250,379],authority.witness.plain()['boss'])
        self.assertEqual([109491,2771,250,1819],authority.demon_profile.plain()['player_stats'])
        self.assertGreater(authority.reserve_ms,5800)
        self.assertEqual(50,self.load(config(ai=AISettings(False,50,True))).budget_ms)

    def test_missing_or_tampered_profile_fails_closed(self):
        self.profile.unlink()
        with self.assertRaisesRegex(ValueError,'PROFILE_MISSING'):self.load()
        for key,value,message in (('source_sha256','0'*64,'DEPLOYMENT_CHANGED'),
            ('package',{'synthetic':True},'DEPLOYMENT_CHANGED'),('host_sha256','0'*64,'HOST_CHANGED'),
            ('game_build_sha256','0'*64,'GAME_CHANGED'),('contract_sha256','0'*64,'CONTRACT_CHANGED')):
            data=json.loads(self.original);data[key]=value;self.profile.write_text(json.dumps(data))
            with self.subTest(key=key),self.assertRaisesRegex(ValueError,message):self.load()

    def test_changed_raw_native_evidence_is_rejected(self):
        data=json.loads(self.original);path=self.profile.parent/data['basic2_review']['path']
        original=path.read_bytes();self.addCleanup(path.write_bytes,original)
        path.write_bytes(original+b' ')
        with self.assertRaises(ValueError):self.load()

    def test_qualification_or_core_change_cannot_self_approve(self):
        import hashlib
        from pokiguard_v2.reasoning_ui_profile import runtime_source_identity
        data=json.loads(self.original);path=self.profile.parent/data['qualification']['path']
        original=path.read_bytes();self.addCleanup(path.write_bytes,original)
        q=json.loads(original);q['worker_roundtrip_pass']=False
        path.write_text(json.dumps(q));data['qualification']['sha256']=hashlib.sha256(path.read_bytes()).hexdigest()
        self.profile.write_text(json.dumps(data))
        with self.assertRaisesRegex(ValueError,'QUALIFICATION_INVALID'):self.load()
        self.profile.write_bytes(self.original)
        source,files,package=runtime_source_identity(self.paths);files['src/pokiguard_v2/basic_policy.py']='0'*64
        with patch('pokiguard_v2.reasoning_ui_profile.runtime_source_identity',return_value=(source,files,package)):
            with self.assertRaisesRegex(ValueError,'GAMEPLAY_CORE_CHANGED'):self.load()

    def test_game_file_or_unsupported_config_falls_back(self):
        self.exe.write_bytes(b'CHANGED_TEST_BUILD')
        with self.assertRaisesRegex(ValueError,'GAME_CHANGED'):self.load()
        with self.assertRaisesRegex(ValueError,'CONFIG_UNSUPPORTED'):self.load(config(pet_skill_fire_value=3))


class RealWorkerHandoffTests(unittest.TestCase):
    def test_two_real_workers_share_one_sink_without_wrong_producer_or_leak(self):
        from tests.test_reasoning_demon import fixture,PARAMS
        from pokiguard_v2.reasoning_pilot import await_pilot_safely
        from pokiguard_v2.reasoning_selection import select_safely
        from pokiguard_v2.autonomous_control import AutonomousSource
        from pokiguard_v2.win32_input import ClickStatus
        s,c,b,a,_=fixture(9,baseline=True)
        with tempfile.TemporaryDirectory() as d:
            session=UIReasoningSession(config(),a,directory=Path(d)/'ui',observer=Mock())
            try:
                session.bind_run('SYNTHETIC_TWO_COMBATS',Path(d)/'farm')
                for index in range(2):
                    options=session.prepare_options();self.assertIn('selection_adapter',options)
                    bridge,collector=options['selection_adapter'],options['swap_timing_adapter']
                    self.assertEqual(f'{session.run_id}:{index+1}',bridge.run_id)
                    collector.observe_start();collector.observe_end(state=s)
                    now=time.perf_counter_ns()
                    self.assertTrue(bridge.observe(s,c,observed_ns=now,read_end_ns=now,context=a.context))
                    self.assertEqual('COMPLETED',await_pilot_safely(bridge,s,b,c,context=a.context,stop_requested=lambda:False))
                    chosen=select_safely(bridge,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
                    self.assertIs(chosen.receipt,bridge.completed)
                    collector.decision(state=s,config=c,input_parameters=PARAMS)
                    collector.start(state=s,config=c,input_mode='foreground',source_hash=AutonomousSource.from_state(s).critical_state_hash)
                    collector.preflight(remaining=12,failure=None,read_end_ns=time.perf_counter_ns())
                    collector.finish(result=SimpleNamespace(sent_clicks=2,input_mode='two_click',status=ClickStatus.SENT))
                    collector.stop();bridge.stop()
                    wait(lambda:session.bundle is None)
                    self.assertFalse(session.faulted,session.first_fault)
                session.stop();self.assertTrue(session.wait_closed(5))
                receipt=json.loads((session.directory/'watermarks.json').read_text())
                self.assertEqual(2,receipt['worker_counts']['processes'])
                self.assertEqual(2,receipt['worker_counts']['reaped'])
                self.assertEqual(2,receipt['worker_counts']['completed'])
                self.assertEqual(0,receipt['stats']['wrong_producer'])
                self.assertEqual(receipt['stats']['eligible'],receipt['stats']['written'])
                self.assertEqual(2,receipt['sequence'])
                self.assertTrue(all(v['healthy'] for v in receipt['recent_combats']))
            finally:
                session.stop();self.assertTrue(session.wait_closed(5))


if __name__=='__main__':unittest.main()
