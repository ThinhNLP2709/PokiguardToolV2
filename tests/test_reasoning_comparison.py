from tests.game_update_fixture import historical_test_view
"""E1 assignment/ownership/flow checks. Native IO is never called."""
import ast
from dataclasses import replace
import json
from pathlib import Path
import tempfile
import unittest
from unittest.mock import Mock

from pokiguard_v2.reasoning_comparison import PROTOCOL, ComparisonSession, assignment, check_config
from pokiguard_v2.reasoning_calibration import decode_config

ROOT=Path(__file__).resolve().parents[1]


def manifest():
    return dict(schema='pokiguard.e1.comparison_manifest.v1',protocol=PROTOCOL,total_attempt_cap=20,
        attempts_per_arm=10,no_automatic_extension=True,failed_entry_abort_included=True,
        assignment=[dict(slot=i*2+j+1,block=i+1,arm=a)
                    for i in range(10) for j,a in enumerate(
                        ('BASIC','REASONING') if i<5 else ('REASONING','BASIC'))])


class ComparisonTests(unittest.TestCase):
    def core(self,directory):
        c=Mock();c.directory=Path(directory);c.faulted=False
        c.prepare_options.return_value={'selection_adapter':object(),'swap_timing_adapter':object()}
        return c

    def test_balanced_whole_match_order_rejects_reassignment_or_extra_slot(self):
        m=manifest();arms=assignment(m)
        self.assertEqual((arms.count('BASIC'),arms.count('REASONING')),(10,10))
        for mutate in [lambda d:d['assignment'][0].update(arm='REASONING'),
                       lambda d:d['assignment'][0].update(block=2),
                       lambda d:d.update(total_attempt_cap=21),
                       lambda d:d.update(failed_entry_abort_included=False),
                       lambda d:d.update(no_automatic_extension=False)]:
            bad=json.loads(json.dumps(m));mutate(bad)
            with self.assertRaises(ValueError):assignment(bad)

    def test_basic_no_core_bind_worker_or_adapters_all_twenty_and_stop(self):
        with tempfile.TemporaryDirectory() as d:
            core=self.core(d);s=ComparisonSession(core,assignment(manifest()))
            self.assertEqual(s.prepare_options(),{})
            s.bind_run('SYNTHETIC_E1',d)
            self.assertEqual(s.prepare_options(),{})
            core.bind_run.assert_not_called();core.prepare_options.assert_not_called()
            self.assertIn('selection_adapter',s.prepare_options())
            for arm in s.arms[2:]:
                out=s.prepare_options()
                self.assertEqual(bool(out),arm=='REASONING')
            self.assertEqual(core.bind_run.call_count,1)
            self.assertEqual(core.prepare_options.call_count,10)
            with self.assertRaises(ValueError):s.prepare_options()
            s.stop();s.finalizer.join(1)
            self.assertFalse(s.finalizer.is_alive())
            self.assertEqual(len(json.loads((Path(d)/'comparison_receipt.json').read_text())['prepares']),20)
            self.assertEqual(s.prepare_options(),{})
            s.stop();core.stop.assert_called_once()

    def test_reasoning_missing_or_exception_stays_assigned_reasoning_and_basic_runs(self):
        with tempfile.TemporaryDirectory() as d:
            core=self.core(d);core.prepare_options.side_effect=RuntimeError('SYNTHETIC')
            s=ComparisonSession(core,assignment(manifest()));s.bind_run('SYNTHETIC_E1',d)
            s.prepare_options();self.assertEqual(s.prepare_options(),{})
            self.assertEqual(s.prepares[1]['arm'],'REASONING')
            self.assertEqual(s.prepares[1]['setup_fault'],'RuntimeError')
            self.assertEqual(s.prepare_options(),{})
            self.assertEqual(s.prepares[2]['arm'],'BASIC')
            s.stop();s.finalizer.join(1)

    def test_stop_during_lazy_core_binding_hands_no_adapter_to_combat(self):
        with tempfile.TemporaryDirectory() as d:
            core=self.core(d);s=ComparisonSession(core,assignment(manifest()))
            s.bind_run('SYNTHETIC_E1',d);s.prepare_options()
            core.bind_run.side_effect=lambda *args:s.stop()
            self.assertEqual(s.prepare_options(),{})
            core.prepare_options.assert_not_called();s.finalizer.join(1)

    def test_no_recovery_resume_or_cohort_config_relaxation(self):
        raw=json.loads((ROOT/'docs/phase5/artifacts/5d3_multiplier20_20261018/package/request.json').read_text())
        c=replace(decode_config(dict(raw['full_config'],demon_target_gem='shield')),max_technical_recoveries=0)
        check_config(c)
        for kw in [dict(max_technical_recoveries=1),dict(max_match_attempts=21),
                   dict(target_completed_matches=10),dict(pet_skill_fire_value=3),dict(boss_id='2346')]:
            with self.assertRaises(ValueError):check_config(replace(c,**kw))

    @historical_test_view()
    def test_shared_runtime_and_existing_launch_paths_only_admission_changed(self):
        # This assertion concerns E1 on b6. Independently pin the reviewed
        # UI/build successor, then inspect its exact saved E1 predecessor.
        from tests.game_update_fixture import before_game_update_path
        before=ROOT/'docs/phase5/artifacts/5e1_comparison_20261019/before_source.json'
        old=json.loads(before.read_text())['files']
        import hashlib
        changed={'src/pokiguard_v2/reasoning_operational.py',
                 'src/pokiguard_v2/reasoning_operational_launch.py',
                 'tests/test_reasoning_mega_native.py','tests/reasoning_controller_fixture.py',
                 'tests/test_reasoning_root_policy.py','tests/test_reasoning_mega_timing.py',
                 'tests/test_reasoning_readiness.py'}
        for name,h in old.items():
            if name not in changed:
                self.assertEqual(hashlib.sha256(before_game_update_path(ROOT,name).read_bytes()).hexdigest(),h,name)
        frozen=ROOT/'docs/phase5/artifacts/5e1_comparison_20261019/before_source'
        expected={'src/pokiguard_v2/reasoning_operational.py':{'load_operational_authority'},
                  'src/pokiguard_v2/reasoning_operational_launch.py':
                      {'OperationalPilotLaunch.__init__','OperationalPilotLaunch.claim'},
                  'tests/test_reasoning_mega_native.py':
                      {'MegaNativeTests.test_frozen_native_controller_reader_executor_and_basic_are_exact'},
                  'tests/reasoning_controller_fixture.py':{'before_shared_guard_path'},
                  'tests/test_reasoning_root_policy.py':
                      {'RootPolicyTests.test_legacy_identity_and100_boundary_are_preserved'},
                  'tests/test_reasoning_mega_timing.py':
                      {'InputTimingTests.test_real_session_options_wrapper_writer_and_watermark_roundtrip_without_game'},
                  'tests/test_reasoning_readiness.py':
                      {'TimingExportTests.test_real_timing_writer_flushes_off_stop_and_exports_watermark'}}
        def functions(path):
            out={}
            for n in ast.parse(path.read_text(encoding='utf-8')).body:
                if isinstance(n,ast.FunctionDef):out[n.name]=ast.dump(n,include_attributes=False)
                elif isinstance(n,ast.ClassDef):
                    for f in n.body:
                        if isinstance(f,ast.FunctionDef):out[n.name+'.'+f.name]=ast.dump(f,include_attributes=False)
            return out
        for name,allowed in expected.items():
            a,b=functions(frozen/name),functions(before_game_update_path(ROOT,name))
            self.assertEqual(set(a),set(b))
            self.assertEqual({k for k in a if a[k]!=b[k]},allowed)


if __name__=='__main__':unittest.main()
