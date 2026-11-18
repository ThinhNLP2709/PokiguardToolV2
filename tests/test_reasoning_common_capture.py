"""Exact replay capture, bounded diagnostics, and nonfatal observation loss."""
from copy import deepcopy
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import tempfile
import time
import unittest
from unittest.mock import Mock

from pokiguard_v2.reasoning_common_capture import EVENT,decode_snapshot_event,record_snapshot_safely,snapshot_event
from pokiguard_v2.reasoning_common_problem import PROFILES
from pokiguard_v2.reasoning_runner import make_job
from pokiguard_v2.reasoning_snapshot import FrozenJSON
from tests.reasoning_test_paths import reasoning_temp_root
from tests.test_reasoning_common import problem
from tools.extract_common_snapshots import extract


def job(value=None):
    return make_job(problem() if value is None else value,deadline=time.perf_counter_ns()+4_000_000_000,generation=3)


class CommonCaptureTests(unittest.TestCase):
    def test_every_style_preserves_exact_problem_identity_and_facts(self):
        for profile in sorted(PROFILES):
            value=problem(profile);request=job(value)
            raw=snapshot_event(request);record=json.loads(raw)
            self.assertEqual(value,decode_snapshot_event(record))
            self.assertEqual(value.to_dict(),record['payload']['snapshot'])
            self.assertEqual(request.correlation(),record['correlation'])
            self.assertFalse(record['input_authority'])
            self.assertLessEqual(len(raw),32768)

    def test_costs_evolution_choices_and_selected_target_are_not_inferred_or_removed(self):
        value=problem('demon_aegis_farm',settings=dict(demon_target_gem='health'),facts=dict(
            resource_requirements=dict(mana=200,rage=250),evolution=dict(pending=True,mana_cost=120)))
        restored=decode_snapshot_event(json.loads(snapshot_event(job(value))))
        self.assertEqual('health',restored.intent.settings.plain()['demon_target_gem'])
        self.assertEqual(value.facts,restored.facts)
        self.assertEqual(value.effects,restored.effects)

    def test_snapshot_hash_config_source_job_and_scope_tampering_is_rejected(self):
        original=json.loads(snapshot_event(job()))
        changes=[lambda r:r['payload']['snapshot']['facts']['self'].update(hp=1),
            lambda r:r['payload'].update(config_hash='a'*64),
            lambda r:r['correlation']['source'].update(turn=999),
            lambda r:r['correlation'].update(job_generation=True),
            lambda r:r['correlation'].update(job_id=''),
            lambda r:r['payload'].update(scope='NATIVE_ACTION_PERMISSION'),
            lambda r:r.update(input_authority=True)]
        for mutate in changes:
            record=deepcopy(original);mutate(record)
            with self.subTest(mutation=mutate),self.assertRaises(ValueError):decode_snapshot_event(record)

    def test_oversized_problem_is_explicitly_truncated_not_a_partial_replay(self):
        value=problem(facts=dict(oversized_test_note='x'*40000))
        raw=snapshot_event(job(value));record=json.loads(raw)
        self.assertLessEqual(len(raw),32768)
        self.assertTrue(record['payload']['truncated'])
        self.assertNotIn('snapshot',record['payload'])
        with self.assertRaisesRegex(ValueError,'truncated'):decode_snapshot_event(record)

    def test_rejected_queue_and_encoding_or_disk_errors_do_not_escape(self):
        request=job();sink=Mock();sink.enqueue.return_value=True
        self.assertEqual('queued',record_snapshot_safely(sink,request))
        self.assertFalse(sink.enqueue.call_args.kwargs['critical'])
        sink.enqueue.return_value=False
        self.assertEqual('dropped',record_snapshot_safely(sink,request))
        sink.enqueue.side_effect=OSError('synthetic write failure')
        self.assertEqual('error',record_snapshot_safely(sink,request))
        self.assertEqual('error',record_snapshot_safely(sink,object()))

    def test_decoder_requires_all_owner_bindings_and_complete_event(self):
        record=json.loads(snapshot_event(job()))
        for key in ('source','provenance','versions','profile'):
            mutated=deepcopy(record);del mutated['correlation'][key]
            with self.subTest(key=key),self.assertRaises(ValueError):decode_snapshot_event(mutated)

    def test_export_deduplicates_exact_snapshots_and_keeps_actual_line_hashes(self):
        raw=snapshot_event(job());truncated=snapshot_event(job(problem(facts=dict(note='x'*40000))))
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as directory:
            path=Path(directory)/'reasoning.jsonl'
            contents=b'{"event_type":"other"}\n'+raw+raw+truncated+b'{bad json}\n'
            path.write_bytes(contents);output=extract([path])
            self.assertEqual(1,len(output['cases']))
            self.assertEqual(1,output['counts']['duplicate_snapshots'])
            self.assertEqual(1,output['counts']['incomplete_or_invalid_snapshots'])
            self.assertEqual(1,output['counts']['invalid_json_lines'])
            case=output['cases'][0]
            self.assertEqual(2,case['provenance']['line'])
            self.assertEqual(hashlib.sha256(contents).hexdigest(),case['provenance']['file_sha256'])
            self.assertEqual(hashlib.sha256(raw).hexdigest(),case['provenance']['line_sha256'])
            self.assertFalse(output['input_authority'])
            self.assertIn('UNKNOWN',case['delivery_or_native_acceptance'])

    def test_capture_failure_still_allows_real_worker_and_host_completion(self):
        from pokiguard_v2.reasoning_common_selection import CommonSelectionBridge,CONTEXT
        from pokiguard_v2.reasoning_full_actions import publish_context_safely
        from tests.test_reasoning_common_evidence import fixture
        from tests.test_reasoning_common_selection import admission
        from tests.test_reasoning_pilot import MemorySink
        class FailingCaptureSink(MemorySink):
            def enqueue(self,raw,*,critical=False):
                if json.loads(raw).get('event_type')==EVENT:raise OSError('synthetic optional snapshot failure')
                return super().enqueue(raw,critical=critical)
        value=fixture();state,config,base,*_=value
        bridge=CommonSelectionBridge(admission=admission(config),diagnostics=FailingCaptureSink(),enabled=True)
        try:
            now=time.perf_counter_ns();bridge.observe(state,config,observed_ns=now,read_end_ns=now,context=CONTEXT)
            publish_context_safely(bridge,*value)
            result=bridge.await_decision(state,base,config,context=CONTEXT,stop_requested=lambda:False)
            self.assertEqual('COMPLETED',result,bridge.preparation_reason)
            self.assertIsNotNone(bridge.completed)
            self.assertEqual(1,bridge.counts['snapshot_error'])
            self.assertFalse(bridge.disabled)
        finally:self.assertTrue(bridge.close())
        self.assertEqual(bridge.runner.counters['processes'],bridge.runner.counters['reaped'])


if __name__=='__main__':unittest.main()
