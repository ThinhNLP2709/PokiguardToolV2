import ast
from dataclasses import replace
from pathlib import Path
from types import SimpleNamespace
import unittest
from unittest.mock import patch
from tests.game_update_fixture import historical_test_view, before_game_update_path

from pokiguard_v2.reasoning_calibration import check_config, D2_CONTROL_PROTOCOL, D2_TIMING_PROTOCOL
from pokiguard_v2.reasoning_swap_timing import SwapTimingCollector, timing_safely
from tests.test_reasoning_d2_control import control_config
from tests.test_reasoning_pilot import MemorySink

ROOT = Path(__file__).resolve().parents[1]


class SkillTimingTests(unittest.TestCase):
    def collector(self, enabled=True):
        return SwapTimingCollector(sink=MemorySink(), run_id='OFFLINE', measure_skills=enabled)

    def start(self, collector, source='HASH'):
        collector.skill_start(match_id='M_FAKE', turn=7, source_hash=source, skill_card_id=7)

    def test_same_clock_full_primitive_is_upper_completion_not_first_click_measurement(self):
        collector = self.collector()
        collector.decision_interval = dict(decision_exit_ns=100, decision_source_hash='HASH')
        result = SimpleNamespace(kind=SimpleNamespace(value='SUCCESS_PERFECT'), card_clicks=1, space_presses=1)
        with patch('pokiguard_v2.reasoning_swap_timing.time.perf_counter_ns', side_effect=[200, 700, 701]):
            self.start(collector)
            collector.skill_finish(result=result)
        import json
        row = json.loads(collector.sink.buffer.items[0]); p = row['payload']
        self.assertEqual(row['event_type'], 'reasoning.skill_timing')
        self.assertEqual((p['controller_tail_ns'], p['full_primitive_ns'], p['full_tail_ns']), (100, 500, 600))
        self.assertTrue(p['complete_interval_bound'])
        self.assertIsNone(p['first_click_ns'])
        self.assertEqual(p['first_click_status'], 'NOT_MEASURED')
        self.assertEqual(p['card_clicks'], 1)
        self.assertIsNone(collector.decision_interval)

    def test_ordinary_collector_does_not_measure_skills(self):
        collector = self.collector(False)
        self.start(collector); collector.skill_finish(); collector.stop()
        self.assertEqual(collector.sequence, 0)
        self.assertEqual(len(collector.sink.buffer.items), 0)

    def test_missing_or_changed_source_cannot_become_full_native_interval(self):
        import json
        for sample in (None, dict(decision_exit_ns=0, decision_source_hash='OTHER')):
            collector = self.collector(); collector.decision_interval = sample
            self.start(collector); collector.skill_finish()
            p = json.loads(collector.sink.buffer.items[0])['payload']
            self.assertFalse(p['complete_interval_bound'])
            self.assertIsNone(p['controller_tail_ns'])

    def test_stop_mid_skill_retains_incomplete_status_and_never_replays(self):
        import json
        collector = self.collector(); self.start(collector); collector.stop()
        p = json.loads(collector.sink.buffer.items[0])['payload']
        self.assertEqual(p['status'], 'STOP_OR_CONTROLLER_EXIT')
        self.assertIsNone(p['result_kind'])
        self.assertIsNone(p['card_clicks'])
        self.assertTrue(collector.stopped)

    def test_sink_failure_only_disables_measurement(self):
        collector = self.collector()
        self.start(collector)
        with patch.object(collector.sink, 'enqueue', side_effect=OSError('OFFLINE_DISK_FAIL')):
            timing_safely(collector, 'skill_finish')
        self.assertTrue(collector.disabled)
        self.assertEqual(collector.dropped, 1)

    def test_overlap_is_visible_and_bounded(self):
        collector = self.collector(); self.start(collector); self.start(collector)
        self.assertTrue(collector.disabled)
        self.assertEqual(collector.dropped, 1)
        self.assertEqual(collector.fault_reason, 'TIMING_OVERLAPPING_SKILL')

    def test_probe_requires_its_own_marker_and_exactly_one_attempt(self):
        config = replace(control_config(), max_match_attempts=1, target_completed_matches=1,
            pet_skill_fire_value=7)
        check_config(config, 1, profile_protocol=D2_TIMING_PROTOCOL)
        with self.assertRaises(ValueError): check_config(config, 1, profile_protocol=D2_CONTROL_PROTOCOL)
        with self.assertRaises(ValueError): check_config(control_config(), 3, profile_protocol=D2_TIMING_PROTOCOL)
        with self.assertRaises(ValueError): check_config(config, 1)

    @historical_test_view()
    def test_controller_change_is_only_two_optional_timing_blocks_QTE_call_exact(self):
        old = ast.parse((ROOT/'docs/phase5/artifacts/5d2_skill_rush_v1/pre_skill_timing/tools/basic_auto_bot.py').read_text(encoding='utf-8'))
        new = ast.parse(before_game_update_path(ROOT,'tools/basic_auto_bot.py').read_text(encoding='utf-8'))
        from pokiguard_v2.reasoning_d2_native import strip_d2_controller
        new = strip_d2_controller(new)
        class Strip(ast.NodeTransformer):
            count = 0
            def visit_If(self, node):
                if (len(node.body) == 1 and isinstance(node.body[0], ast.Expr)
                        and isinstance(node.body[0].value, ast.Call)):
                    call = node.body[0].value
                    if (isinstance(call.func, ast.Name) and call.func.id == 'timing_safely'
                            and len(call.args) >= 2 and isinstance(call.args[1], ast.Constant)
                            and call.args[1].value in ('skill_start', 'skill_finish')):
                        self.assertion(node)
                        self.count += 1
                        return None
                return self.generic_visit(node)
            def assertion(self, node):
                assert ast.unparse(node.test) == 'swap_timing_adapter is not None'
                assert not node.orelse
        transform = Strip(); reduced = transform.visit(new)
        self.assertEqual(transform.count, 2)
        self.assertEqual(ast.dump(old), ast.dump(reduced))


if __name__ == '__main__':
    unittest.main()
