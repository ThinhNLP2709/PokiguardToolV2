"""Settings -> preferences -> production args/executor, without game input."""
from dataclasses import replace
from dataclasses import asdict
import importlib.util
import random
import sys
import json
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch,Mock

from pokiguard_v2.input_randomization import InputRandomization
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
from pokiguard_v2.desktop_farm_controller import DesktopFarmControllerManager,ControllerLaunch
from pokiguard_v2.win32_input import (
    BoardCalibration,ForegroundClickExecutor,WindowBinding,map_swap_to_pixels,
    FarmControlHotkeyEdges,CoordinateSafetyError,
)
from tests.test_win32_input import FakeBackend


ROOT=Path(__file__).resolve().parents[1]


class InputRandomizationTests(unittest.TestCase):
    def test_finite_bounds_and_pair_validation(self):
        for name,value in (
            ('reaction_max_seconds',1.01),('inter_click_max_seconds',1.51),
            ('coordinate_max_percent',10.01),('reaction_min_seconds',-1),
            ('coordinate_max_percent',float('nan')),('reaction_max_seconds',float('inf')),
            ('reaction_min_seconds',True),('inter_click_min_seconds','0'),
        ):
            with self.subTest(name=name,value=value),self.assertRaises(ValueError):
                InputRandomization(**{name:value})
        with self.assertRaises(ValueError):
            InputRandomization(reaction_min_seconds=.8,reaction_max_seconds=.2)

    def test_max_zero_disables_random_even_with_retained_positive_min(self):
        settings=InputRandomization(1,0,1.5,0,0)
        backend=FakeBackend();sleeps=[]
        executor=ForegroundClickExecutor(backend,randomization=settings,sleeper=sleeps.append)
        with patch('pokiguard_v2.win32_input.random.uniform',side_effect=AssertionError('RNG must be OFF')):
            plan=map_swap_to_pixels((1,1),(1,2),BoardCalibration(),backend.geometry,
                                    coordinate_jitter_fraction=settings.coordinate_fraction)
            result=executor.send_swap(WindowBinding(5,123,'offline',1280,720),plan)
        self.assertTrue(result.sent);self.assertEqual(backend.clicks,2)
        self.assertEqual(result.inter_click_delay_seconds,.35)
        self.assertAlmostEqual(sum(sleeps),.35+2*.06)

    def test_configured_ranges_reach_executor_and_reasoned_skips_both(self):
        settings=InputRandomization(.2,.4,.3,.5,0)
        for reasoned in (False,True):
            backend=FakeBackend();sleeps=[]
            executor=ForegroundClickExecutor(backend,randomization=settings,sleeper=sleeps.append)
            plan=map_swap_to_pixels((1,1),(1,2),BoardCalibration(),backend.geometry,coordinate_jitter_fraction=0)
            with patch('pokiguard_v2.win32_input.random.uniform',side_effect=lambda a,b:(a+b)/2) as rng:
                result=executor.send_swap(WindowBinding(5,123,'offline',1280,720),plan,reasoned=reasoned)
            self.assertTrue(result.sent)
            self.assertAlmostEqual(result.inter_click_delay_seconds,.35 if reasoned else .75)
            self.assertAlmostEqual(sum(sleeps),.47 if reasoned else 1.17)
            if reasoned:rng.assert_not_called()
            else:self.assertEqual([c.args for c in rng.call_args_list],[(.2,.4),(.3,.5)])

    def test_timer_and_tap_selection_caps_remain_in_force(self):
        backend=FakeBackend();executor=ForegroundClickExecutor(backend,sleeper=lambda _:None)
        plan=map_swap_to_pixels((1,1),(1,2),BoardCalibration(),backend.geometry,coordinate_jitter_fraction=0)
        with patch('pokiguard_v2.win32_input.random.uniform',side_effect=lambda a,b:b):
            result=executor.send_swap(WindowBinding(5,123,'offline',1280,720),plan,remaining_seconds=2)
        self.assertLessEqual(result.inter_click_delay_seconds,.75)

    def test_coordinate_limit_uses_cell_size_and_zero_means_center(self):
        backend=FakeBackend();calibration=BoardCalibration()
        with patch('pokiguard_v2.win32_input.random.uniform',side_effect=lambda a,b:b):
            center=map_swap_to_pixels((0,0),(0,1),calibration,backend.geometry,coordinate_jitter_fraction=0)
            offset=map_swap_to_pixels((0,0),(0,1),calibration,backend.geometry,coordinate_jitter_fraction=.05)
        self.assertLessEqual(abs(offset.first.client_x-center.first.client_x),4)
        self.assertLessEqual(abs(offset.first.client_y-center.first.client_y),4)
        for bad in (-.01,.11,float('nan'),True):
            with self.assertRaises(CoordinateSafetyError):
                map_swap_to_pixels((0,0),(0,1),calibration,backend.geometry,coordinate_jitter_fraction=bad)

    def test_preference_roundtrip_old_default_and_invalid_optional_block(self):
        custom=InputRandomization(.1,.2,.2,.4,5)
        with tempfile.TemporaryDirectory() as folder:
            p=Path(folder)/'prefs.json';store=DesktopPreferenceStore(p)
            c=replace(DesktopConfig(),input_randomization=custom,target_completed_matches=17,max_match_attempts=20)
            store.save(c)
            self.assertEqual(store.load().config.input_randomization,custom)
            raw=json.loads(p.read_text(encoding='utf-8'));del raw['config']['input_randomization']
            p.write_text(json.dumps(raw),encoding='utf-8')
            self.assertEqual(store.load().config.input_randomization,InputRandomization())
            raw['config']['input_randomization']={'reaction_max_seconds':float('nan')}
            p.write_text(json.dumps(raw),encoding='utf-8');loaded=store.load()
            self.assertTrue(loaded.loaded);self.assertEqual(loaded.config.target_completed_matches,17)
            self.assertEqual(loaded.config.input_randomization,InputRandomization())
            self.assertEqual(loaded.warnings[0].reason,'PREFERENCE_RANDOMIZATION_INVALID')

    def test_desktop_to_production_cli_preserves_settings_and_gameplay(self):
        custom=InputRandomization(.1,.3,.4,.8,2)
        with tempfile.TemporaryDirectory() as folder:
            manager=DesktopFarmControllerManager(Path(folder))
            c=replace(DesktopConfig(),boss_id='1436',input_randomization=custom)
            with patch('tools.farm_run.run',return_value=0) as run:
                self.assertEqual(manager._run_production(ControllerLaunch(c,None),FarmControlHotkeyEdges(),lambda *a:None),0)
            args=run.call_args.args[0]
            self.assertEqual(args.input_randomization,custom)
            self.assertNotIn('input_randomization',c.gameplay_config.to_dict())

    def test_decimal_comma_and_invalid_json_are_validated(self):
        self.assertEqual(InputRandomization.from_strings(reaction_min_seconds='0,2').reaction_min_seconds,.2)
        with self.assertRaises(ValueError):InputRandomization.from_json('{"unknown":0}')

    def test_farm_pinned_executor_retains_custom_and_disabled_settings(self):
        from tests.test_pinned_board_input import session, FakeClock, FakeBackend as LeaseBackend
        mouse=session(LeaseBackend(),FakeClock())
        for settings in (InputRandomization(.2,.6,.3,.7,5),InputRandomization(0,0,0,0,0)):
            source=ForegroundClickExecutor(FakeBackend(),randomization=settings)
            bound=mouse.bind_executor(source)
            self.assertIs(bound.randomization,settings)
            self.assertIs(bound.swap_pacer,source.swap_pacer)

    def test_canonical_timing_config_binds_randomization_without_accepting_old_requests(self):
        from pokiguard_v2.reasoning_calibration import decode_config
        from pokiguard_v2.board_diagnostics import jsonable
        c=replace(DesktopConfig(),input_randomization=InputRandomization(.1,.3,.4,.8,2))
        raw=jsonable(c)
        self.assertEqual(decode_config(raw),c)
        old=dict(raw);old.pop('input_randomization')
        with self.assertRaises(ValueError):decode_config(old)

    def test_defaults_preserve_recorded_mapper_and_executor_rng_and_waits(self):
        path=ROOT/'docs/artifacts/input_randomization_settings_20261024/before/src/pokiguard_v2/win32_input.py'
        spec=importlib.util.spec_from_file_location('pokiguard_v2._before_random_input',path)
        old=importlib.util.module_from_spec(spec);sys.modules[spec.name]=old;spec.loader.exec_module(old)
        from pokiguard_v2 import win32_input as current
        saved=random.getstate()
        try:
            for reasoned,remaining in ((False,None),(False,2),(True,None)):
                records=[]
                for module in (old,current):
                    random.seed(61424);backend=FakeBackend();sleeps=[]
                    plan=module.map_swap_to_pixels((4,2),(4,3),module.BoardCalibration(),backend.geometry)
                    executor=module.ForegroundClickExecutor(backend,sleeper=sleeps.append)
                    result=executor.send_swap(module.WindowBinding(5,123,'offline',1280,720),
                                              plan,remaining_seconds=remaining,reasoned=reasoned)
                    records.append((asdict(plan),asdict(result),sleeps,backend.positions,random.getstate()))
                self.assertEqual(records[0],records[1])
        finally:
            random.setstate(saved);sys.modules.pop(spec.name,None)


class InputRandomizationUiTests(unittest.TestCase):
    def test_hidden_tk_save_lock_and_layout_without_game_or_start(self):
        import tkinter as tk
        from pokiguard_v2.desktop_ui import DesktopApplication,DesktopViewModel,DesktopEventLog
        from pokiguard_v2.desktop_control_plane import DesktopControlPlane,SnapshotPoller,StaticUnavailableRuntimeProvider
        root=tk.Tk();root.withdraw()
        with tempfile.TemporaryDirectory() as folder:
            plane=DesktopControlPlane(StaticUnavailableRuntimeProvider())
            poller=SnapshotPoller(plane)
            log=DesktopEventLog(Path(folder)/'ui.jsonl');store=DesktopPreferenceStore(Path(folder)/'prefs.json')
            try:
                app=DesktopApplication(root,DesktopViewModel(plane,poller,stale_after_seconds=5),
                                       event_log=log,preference_store=store)
                app.notebook.select(3);root.update_idletasks()
                self.assertEqual(len(app.randomization_widgets),5)
                app.randomization_vars['reaction_min_seconds'].set('0,2')
                app.randomization_vars['reaction_max_seconds'].set('0')
                app.randomization_vars['coordinate_max_percent'].set('0')
                app._save_input_randomization()
                loaded=store.load();self.assertTrue(loaded.loaded)
                self.assertEqual(loaded.config.input_randomization.reaction_min_seconds,.2)
                self.assertEqual(loaded.config.input_randomization.reaction_max_seconds,0)
                self.assertEqual(loaded.config.input_randomization.coordinate_max_percent,0)
                app._set_config_editable(False)
                self.assertTrue(all(str(w.cget('state'))=='disabled' for w in app.randomization_widgets))
                self.assertEqual(str(app.randomization_save.cget('state')),'disabled')
                self.assertLess(app.randomization_save.master.master.winfo_reqheight(),760)
                self.assertLessEqual(app.randomization_save.master.winfo_reqwidth(),440)
                self.assertEqual(poller.starts,0)
            finally:
                for token in root.tk.call('after','info'):root.after_cancel(token)
                plane.close();log.close();root.destroy()


if __name__=='__main__':unittest.main()
