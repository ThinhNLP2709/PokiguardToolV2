from tests.game_update_fixture import historical_test_view
"""Additional C3 full-controller parity; never accesses game or native input."""
from contextlib import ExitStack
import hashlib
import json
from pathlib import Path
import tempfile
import time
import unittest
from unittest.mock import patch

from pokiguard_v2.reasoning_shadow import ShadowAdapter, attach_shadow_log
from tests import reasoning_worker_fixtures as fault
from tests.reasoning_controller_fixture import controller_trace
from tests.test_reasoning_shadow import MemorySink, publication
from tests.test_reasoning_integration import evidence, stopped_controller


class ReasoningAcceptanceTests(unittest.TestCase):
    def test_actual_controller_swap_ack_stale_wrong_turn_and_pending_parity(self):
        with tempfile.TemporaryDirectory() as temp:
            directory=Path(temp)
            for case in ('normal','stale','wrong_turn','pending'):
                with self.subTest(case=case):
                    baseline=controller_trace(directory/f'{case}-off.jsonl',case=case)
                    adapter=ShadowAdapter(diagnostics=MemorySink(),compute=fault.hang)
                    try:
                        actual=controller_trace(directory/f'{case}-shadow.jsonl',adapter,case)
                        self.assertEqual(baseline,actual)
                        self.assertEqual(actual[0],0)
                        self.assertEqual(actual[1].count('FAKE_NORMAL_INPUT'),int(case in ('normal','pending')))
                        self.assertEqual(actual[1].count('executor.ack'),int(case=='normal'))
                        self.assertEqual(actual[2][-1]['stopReason'],'EMERGENCY_STOP')
                        results=[r for r in actual[2] if r['event']=='action_result']
                        if case=='normal':
                            self.assertTrue(any(r.get('evidence')=='EXACT_MATCHSERVICE_LOCAL_SEQUENCE_LAST_MOVE_AND_OPPONENT_TURN' for r in results))
                        if case=='wrong_turn':
                            self.assertTrue(any(r.get('reason')=='FINAL_SWAP_DIRECT_RUNTIME_PREFLIGHT_REJECTED' and
                                r.get('preflightFailure')=='TURN_NOT_LOCAL' for r in results))
                        if case=='stale':
                            self.assertNotIn('capture.modal',actual[1])
                            self.assertGreater(actual[2][-1]['counters']['expired_actions'],0)
                        if case=='pending':
                            self.assertTrue(any(r.get('reason')=='EMERGENCY_STOP' for r in results))
                        evidence('full_controller_trace',case=case,gameplay_log_parity=True,
                            calls=actual[1],rows=actual[2],native_input=False)
                    finally:self.assertTrue(adapter.close(2))

    @historical_test_view()
    def test_c3_sources_preserved_except_documented_rotation_and_audit(self):
        from tests.reasoning_controller_fixture import assert_c3_source_compatibility
        assert_c3_source_compatibility(self)

    def test_rotation_stamp_with_frozen_backwards_and_existing_names(self):
        from pokiguard_v2.reasoning_diagnostics import _next_log_stamp
        self.assertEqual(_next_log_stamp([],previous=100,now=100,stem='reasoning'),101)
        self.assertEqual(_next_log_stamp([],previous=100,now=1,stem='reasoning'),101)
        paths=[Path('reasoning.00000000000000001099.jsonl'),Path('reasoning.abc.jsonl')]
        self.assertEqual(_next_log_stamp(paths,previous=10,now=100,stem='reasoning'),1100)

    def test_native_rotation_under_frozen_clock_30_trials(self):
        from pokiguard_v2.reasoning_diagnostics import BoundedDiagnostics,LogLimits
        from tests.reasoning_controller_fixture import frozen_rotation_writer
        for trial in range(30):
            with tempfile.TemporaryDirectory() as temp:
                directory=Path(temp)
                old=directory/f'reasoning.{1_791_650_000_000_000_000:020d}.jsonl'
                old.write_bytes(b'{}\n')
                writer=BoundedDiagnostics(directory,writer_target=frozen_rotation_writer,
                    limits=LogLimits(file_bytes=32768,files=2))
                try:
                    for index in range(10):
                        raw=(json.dumps(dict(padding='x'*15900,index=index),separators=(',',':'))+'\n').encode()
                        self.assertTrue(writer.enqueue(raw))
                    self.assertTrue(writer.flush(),writer.buffer.stats())
                    stats=writer.buffer.stats()
                    self.assertEqual(stats['written'],10)
                    files=sorted(directory.glob('reasoning.*.jsonl'))
                    self.assertEqual(len(files),2)
                    retained=[json.loads(line)['index'] for path in files for line in path.read_text(encoding='utf-8').splitlines()]
                    self.assertEqual(retained,[6,7,8,9])
                    evidence('frozen_clock_rotation',trial=trial,stats=stats,all_written=True)
                finally:self.assertTrue(writer.close())

    def test_admission_exception_fallback_latency_30_trials_each(self):
        import io
        config,_,_,_,raw=publication()
        for variant in ('admission_raises','stop_also_raises'):
            for trial in range(30):
                def fail(*_):raise OSError('OFFLINE admission fault')
                from types import SimpleNamespace
                adapter=SimpleNamespace(bind_config=lambda _:None,observe_line=fail,
                    stop=fail if variant=='stop_also_raises' else lambda:None)
                base=io.StringIO();observed=attach_shadow_log(base,adapter,config)
                start=time.perf_counter_ns();observed.write(raw);elapsed=time.perf_counter_ns()-start
                self.assertEqual(base.getvalue(),raw)
                evidence('known_fault_fallback',variant=variant,trial=trial,elapsed_ns=elapsed,parity=True)

    def test_actual_controller_stop_signal_latency_100_trials(self):
        with tempfile.TemporaryDirectory() as temp:
            directory=Path(temp)
            for trial in range(100):
                adapter=ShadowAdapter(diagnostics=MemorySink(),compute=fault.hang)
                original=adapter.stop;timings=[]
                def measured_stop():
                    start=time.perf_counter_ns()
                    try:return original()
                    finally:timings.append(time.perf_counter_ns()-start)
                try:
                    with patch.object(adapter,'stop',measured_stop):
                        result,_,rows,_=stopped_controller(directory/f'{trial}.jsonl',adapter,pending=bool(trial%2))
                    self.assertEqual(result,0);self.assertTrue(timings)
                    self.assertEqual(rows[-1]['totalInputs'],0)
                    evidence('controller_stop_signal',trial=trial,pending=bool(trial%2),
                        elapsed_ns=max(timings),timings_ns=timings,wait_for_cleanup_on_host=False)
                finally:self.assertTrue(adapter.close(2))


if __name__=='__main__':unittest.main()
