"""Optional metadata must remain bounded, redacted and outside read authority."""
from dataclasses import asdict, replace, FrozenInstanceError
import json
import struct
import unittest
from unittest.mock import patch, PropertyMock

from pokiguard_v2.dispatcher_chat_roots import DispatcherChatMessageRoot, DispatcherChatRootReader
from pokiguard_v2.dispatcher_read_trace import (
    DispatcherReadTrace, MAX_EVENTS, MAX_EVENT_ROOTS, MAX_ALIAS_EVENTS, MAX_RECENT_READS,
    MAX_PROTECTED_ROOT_EVENTS, MAX_PROTECTED_ERROR_EVENTS,
    TIMING_EVENT_THRESHOLD_NS, error_code,
)
from pokiguard_v2.il2cpp_layout import LayoutValidationError
import tests.test_dispatcher_chat_roots as roots_fixture
import tests.test_combat_outcome_evidence as outcomes


def root(number=0, *, dto=0x280000):
    return DispatcherChatMessageRoot(dto, 0x270000 + number*0x100, 0x260000 + number*0x100,
        'drain_buffer', number, 0x290000 + number*0x100)


def sample(trace, roots=(), error=None):
    ticket = trace.begin()
    trace.complete(ticket, roots=roots, error=error)
    return ticket


class ReadTraceTests(unittest.TestCase):
    def test_tokens_redact_addresses_and_have_no_input_or_effect_authority(self):
        trace=DispatcherReadTrace();roots=(root(),);sample(trace,roots)
        snapshot=trace.snapshot;member=snapshot.events[0].roots[0]
        for token in (member.callback_token,member.dto_token,member.json_token):
            self.assertEqual(24,len(token));self.assertTrue(all(c in '0123456789abcdef' for c in token))
        encoded=json.dumps(asdict(snapshot))
        for raw in (hex(roots[0].message_address),hex(roots[0].closure_address),hex(roots[0].json_address)):
            self.assertNotIn(raw,encoded)
        self.assertNotIn('combatSteps',encoded);self.assertFalse(snapshot.input_authority)
        self.assertEqual('UNKNOWN',snapshot.effect_completeness)
        self.assertIsNotNone(snapshot.utc_anchor);self.assertIsNotNone(snapshot.monotonic_anchor_ns)

    def test_exact_returned_tuple_and_root_required_for_binding(self):
        trace=DispatcherReadTrace();one=root();roots=(one,);ticket=sample(trace,roots)
        binding=trace.binding(roots,one)
        self.assertEqual(ticket.read_id,binding.read_id)
        self.assertEqual(trace.snapshot.events[0].roots[0],binding.root)
        self.assertLessEqual(binding.read_started_ns,binding.read_finished_ns)
        self.assertLessEqual(binding.read_finished_ns,binding.decoded_ns)
        self.assertIsNone(trace.binding(tuple([one]),one))
        self.assertIsNone(trace.binding(roots,replace(one)))
        self.assertIsNone(trace.binding((),one))

    def test_shared_dto_distinct_callback_json_is_explicit_in_one_read(self):
        trace=DispatcherReadTrace();roots=(root(),root(1));sample(trace,roots)
        event=trace.snapshot.alias_events[0]
        self.assertEqual(1,event.shared_dto_groups)
        self.assertEqual(1,trace.snapshot.shared_dto_read_samples)
        a,b=event.roots
        self.assertEqual(a.dto_token,b.dto_token)
        self.assertNotEqual(a.callback_token,b.callback_token)
        self.assertNotEqual(a.json_token,b.json_token)
        self.assertIn('NOT_OBJECT_LIFETIME',trace.snapshot.token_semantics)

    def test_same_dto_across_separate_reads_is_not_same_read_alias_evidence(self):
        trace=DispatcherReadTrace();sample(trace,(root(),));sample(trace,(root(1),))
        self.assertFalse(trace.snapshot.alias_events)
        self.assertEqual(0,trace.snapshot.shared_dto_read_samples)

    def test_cached_membership_history_compresses_repeated_reads(self):
        trace=DispatcherReadTrace();roots=(root(),)
        with patch('pokiguard_v2.dispatcher_read_trace.time.monotonic_ns',side_effect=iter(range(10000))):
            sample(trace,roots)
            old_events=trace.snapshot.events
            for _ in range(100):sample(trace,roots)
        self.assertIs(old_events,trace.snapshot.events)
        self.assertEqual(101,trace.snapshot.reads_completed)
        self.assertEqual(1,len(trace.snapshot.events))
        with self.assertRaises(FrozenInstanceError):trace.snapshot.events[0].root_count=9

    def test_empty_transition_and_error_are_different_and_do_not_guess_sequence(self):
        trace=DispatcherReadTrace();sample(trace,(root(),));sample(trace,())
        sample(trace,error=LayoutValidationError('dispatcher queue changed during read'))
        snapshot=trace.snapshot
        self.assertEqual(['ROOT_SET','EMPTY','READ_ERROR'],[e.kind for e in snapshot.events])
        self.assertIsNone(snapshot.events[-1].root_count)
        self.assertEqual('QUEUE_TORN',snapshot.last_error_code)
        self.assertEqual(1,snapshot.empty_reads);self.assertEqual(1,snapshot.read_failures)
        self.assertNotIn('server_sequence',json.dumps(asdict(snapshot.events[-1])))

    def test_repeated_error_counts_keep_first_event_and_last_error_time(self):
        trace=DispatcherReadTrace()
        with patch('pokiguard_v2.dispatcher_read_trace.time.monotonic_ns',side_effect=[1,2,3,4]):
            sample(trace,error=LayoutValidationError('dispatcher queue changed during read'))
            sample(trace,error=LayoutValidationError('dispatcher queue changed during read'))
        self.assertEqual(1,len(trace.snapshot.events))
        self.assertEqual(2,trace.snapshot.read_failures);self.assertEqual(4,trace.snapshot.last_error_ns)

    def test_long_gap_is_recorded_even_if_root_set_does_not_change(self):
        trace=DispatcherReadTrace();roots=(root(),);late=TIMING_EVENT_THRESHOLD_NS+100
        with patch('pokiguard_v2.dispatcher_read_trace.time.monotonic_ns',side_effect=[1,2,late,late+1]):
            sample(trace,roots);sample(trace,roots)
        self.assertEqual('READ_TIMING_GAP',trace.snapshot.events[-1].kind)
        self.assertEqual(late-2,trace.snapshot.max_gap_since_previous_end_ns)
        self.assertEqual(late,trace.snapshot.max_gap_ended_at_read_started_ns)

    def test_slow_read_has_timestamps_without_changing_read_policy(self):
        trace=DispatcherReadTrace();sample(trace,())
        with patch('pokiguard_v2.dispatcher_read_trace.time.monotonic_ns',side_effect=[100,100+TIMING_EVENT_THRESHOLD_NS]):
            sample(trace,())
        self.assertEqual('READ_TIMING_GAP',trace.snapshot.events[-1].kind)
        self.assertEqual(100,trace.snapshot.max_read_started_ns)

    def test_events_members_and_alias_history_have_hard_limits(self):
        trace=DispatcherReadTrace()
        with patch('pokiguard_v2.dispatcher_read_trace.time.monotonic_ns',side_effect=iter(range(100000))):
            for n in range(MAX_EVENTS+5):sample(trace,(root(n),root(n+1000)))
        snapshot=trace.snapshot
        self.assertEqual(MAX_EVENTS,len(snapshot.events));self.assertEqual(5,snapshot.dropped_events)
        self.assertEqual(MAX_ALIAS_EVENTS,len(snapshot.alias_events))
        self.assertEqual(MAX_EVENTS+5-MAX_ALIAS_EVENTS,snapshot.dropped_alias_events)
        many=tuple(root(i,dto=0x300000+i*0x100) for i in range(12))+(root(50),root(51))
        sample(trace,many);event=trace.snapshot.events[-1]
        self.assertEqual(MAX_EVENT_ROOTS,len(event.roots))
        self.assertEqual(len(many)-MAX_EVENT_ROOTS,event.omitted_roots)
        self.assertEqual(event.roots[0].dto_token,event.roots[1].dto_token)
        self.assertLess(len(json.dumps(asdict(snapshot))),1024*1024)

    def test_binding_cache_is_bounded_and_evicted_binding_is_unknown(self):
        trace=DispatcherReadTrace();old=(root(),);sample(trace,old)
        for i in range(MAX_RECENT_READS):sample(trace,(root(i+1),))
        self.assertIsNone(trace.binding(old,old[0]))
        self.assertEqual(MAX_RECENT_READS,len(trace._recent))

    def test_timing_and_empty_noise_cannot_evict_early_root_or_error_witness(self):
        trace=DispatcherReadTrace();clock=iter(range(0,10**12,TIMING_EVENT_THRESHOLD_NS+1))
        with patch('pokiguard_v2.dispatcher_read_trace.time.monotonic_ns',side_effect=lambda:next(clock)):
            first=sample(trace,(root(),))
            failure=sample(trace,error=LayoutValidationError('dispatcher queue changed during read'))
            for _ in range(MAX_EVENTS+5):sample(trace,())
        snapshot=trace.snapshot
        self.assertNotIn(first.read_id,[e.read_id for e in snapshot.events])
        self.assertNotIn(failure.read_id,[e.read_id for e in snapshot.events])
        self.assertEqual([first.read_id],[e.read_id for e in snapshot.protected_root_events])
        self.assertEqual([failure.read_id],[e.read_id for e in snapshot.protected_error_events])
        self.assertEqual(0,snapshot.omitted_protected_root_events)
        self.assertEqual(0,snapshot.omitted_protected_error_events)

    def test_root_history_preserves_prefix_and_recent_suffix_with_explicit_gap(self):
        trace=DispatcherReadTrace();count=MAX_PROTECTED_ROOT_EVENTS+17
        with patch('pokiguard_v2.dispatcher_read_trace.time.monotonic_ns',side_effect=iter(range(100000))):
            for n in range(count):sample(trace,(root(n),))
        snapshot=trace.snapshot;half=MAX_PROTECTED_ROOT_EVENTS//2
        ids=[e.read_id for e in snapshot.protected_root_events]
        self.assertEqual(list(range(1,half+1))+list(range(count-half+1,count+1)),ids)
        self.assertEqual(count,snapshot.protected_root_events_observed)
        self.assertEqual(17,snapshot.omitted_protected_root_events)
        self.assertEqual(MAX_PROTECTED_ROOT_EVENTS,len(ids))
        self.assertEqual(len(ids),len(set(ids)))
        self.assertTrue(all(e.kind=='ROOT_SET' for e in snapshot.protected_root_events))
        self.assertIn('NOT_CONTINUOUS',snapshot.protected_history_scope)

    def test_repeated_error_samples_keep_individual_times_and_bounded_prefix_suffix(self):
        trace=DispatcherReadTrace();count=MAX_PROTECTED_ERROR_EVENTS+9
        with patch('pokiguard_v2.dispatcher_read_trace.time.monotonic_ns',side_effect=iter(range(100000))):
            for _ in range(count):sample(trace,error=LayoutValidationError('dispatcher queue changed during read'))
        snapshot=trace.snapshot;half=MAX_PROTECTED_ERROR_EVENTS//2
        self.assertEqual(1,len(snapshot.events))  # Legacy compression is unchanged.
        self.assertEqual(count,snapshot.read_failures)
        self.assertEqual(count,snapshot.protected_error_events_observed)
        self.assertEqual(9,snapshot.omitted_protected_error_events)
        self.assertEqual(list(range(1,half+1))+list(range(count-half+1,count+1)),
            [e.read_id for e in snapshot.protected_error_events])
        self.assertEqual(count*2-1,snapshot.protected_error_events[-1].finished_ns)

    def test_root_noise_does_not_consume_failure_capacity_or_vice_versa(self):
        trace=DispatcherReadTrace()
        with patch('pokiguard_v2.dispatcher_read_trace.time.monotonic_ns',side_effect=iter(range(100000))):
            sample(trace,(root(),));sample(trace,error=ValueError('private'))
            for n in range(MAX_PROTECTED_ROOT_EVENTS+10):sample(trace,(root(n+1),))
        self.assertEqual(1,len(trace.snapshot.protected_error_events))
        self.assertEqual(0,trace.snapshot.omitted_protected_error_events)
        self.assertEqual(1,trace.snapshot.protected_error_events_observed)
        self.assertEqual(MAX_PROTECTED_ROOT_EVENTS,len(trace.snapshot.protected_root_events))

    def test_protected_snapshots_are_cached_and_stable_across_repeated_reads(self):
        trace=DispatcherReadTrace();roots=(root(),)
        with patch('pokiguard_v2.dispatcher_read_trace.time.monotonic_ns',side_effect=iter(range(100000))):
            sample(trace,roots);before=trace.snapshot
            for _ in range(50):sample(trace,roots)
            after=trace.snapshot
        self.assertIs(before.protected_root_events,after.protected_root_events)
        self.assertIs(before.protected_error_events,after.protected_error_events)
        sample(trace,(root(1),))
        self.assertEqual(1,len(before.protected_root_events))
        with self.assertRaises(FrozenInstanceError):before.protected_root_events[0].kind='EMPTY'

    def test_reset_clears_protected_history_and_inflight_ticket_cannot_restore_it(self):
        trace=DispatcherReadTrace();sample(trace,(root(),));sample(trace,error=ValueError('private'))
        ticket=trace.begin();trace.reset('M_NEW');trace.complete(ticket,error=ValueError('private'))
        snapshot=trace.snapshot
        self.assertFalse(snapshot.protected_root_events);self.assertFalse(snapshot.protected_error_events)
        self.assertEqual(0,snapshot.protected_root_events_observed)
        self.assertEqual(0,snapshot.protected_error_events_observed)
        self.assertEqual(1,snapshot.obsolete_completions)

    def test_protected_histories_have_bounded_redacted_serialized_size(self):
        trace=DispatcherReadTrace()
        with patch('pokiguard_v2.dispatcher_read_trace.time.monotonic_ns',side_effect=iter(range(100000))):
            for n in range(MAX_PROTECTED_ROOT_EVENTS+20):
                roots=tuple(root(n*MAX_EVENT_ROOTS+i,dto=0x300000+i*0x100) for i in range(MAX_EVENT_ROOTS))
                sample(trace,roots)
            for _ in range(MAX_PROTECTED_ERROR_EVENTS+10):sample(trace,error=ValueError('private 0x1234'))
        snapshot=trace.snapshot;encoded=json.dumps(asdict(snapshot))
        self.assertLess(len(encoded.encode()),1024*1024)
        self.assertNotIn('private',encoded);self.assertNotIn('0x1234',encoded)
        self.assertFalse(snapshot.input_authority);self.assertEqual('UNKNOWN',snapshot.effect_completeness)

    def test_no_prefix_suffix_overlap_before_protected_capacity_is_full(self):
        trace=DispatcherReadTrace()
        with patch('pokiguard_v2.dispatcher_read_trace.time.monotonic_ns',side_effect=iter(range(100000))):
            for n in range(MAX_PROTECTED_ROOT_EVENTS):sample(trace,(root(n),))
        snapshot=trace.snapshot
        self.assertEqual(list(range(1,MAX_PROTECTED_ROOT_EVENTS+1)),
            [e.read_id for e in snapshot.protected_root_events])
        self.assertEqual(0,snapshot.omitted_protected_root_events)

    def test_reset_changes_tokens_and_rejects_inflight_old_ticket(self):
        trace=DispatcherReadTrace();roots=(root(),);old=sample(trace,roots)
        first=trace.binding(roots,roots[0]);pending=trace.begin()
        trace.reset('M_NEW');trace.complete(pending,roots=roots)
        self.assertEqual(1,trace.snapshot.obsolete_completions)
        self.assertFalse(trace.snapshot.events);self.assertIsNone(trace.binding(roots,roots[0]))
        sample(trace,roots);second=trace.binding(roots,roots[0])
        self.assertNotEqual(old.trace_id,second.trace_id)
        self.assertNotEqual(first.root.dto_token,second.root.dto_token)

    def test_match_context_bind_is_not_a_root_identity_claim(self):
        trace=DispatcherReadTrace();trace.bind_match('M_ONE')
        self.assertEqual('M_ONE',trace.snapshot.match_id)
        self.assertIn('NOT_CONTENT_IDENTITY',trace.snapshot.match_semantics)
        with self.assertRaises(ValueError):trace.bind_match('M_OTHER')

    def test_error_text_is_redacted(self):
        trace=DispatcherReadTrace();sample(trace,error=LayoutValidationError('private account 0x1234'))
        encoded=json.dumps(asdict(trace.snapshot))
        self.assertNotIn('private',encoded);self.assertNotIn('0x1234',encoded)
        self.assertEqual('ROOT_READ_REJECTED',error_code(ValueError('private text')))
        self.assertEqual('QUEUE_READ_REJECTED',error_code(LayoutValidationError('dispatcher queue is unreadable: private')))

    def test_invalid_context_is_bounded_and_never_turned_into_root_authority(self):
        trace=DispatcherReadTrace()
        for value in ('x'*257,'private\nname',True,123,[]):
            trace.reset(value);self.assertIsNone(trace.snapshot.match_id)
            trace.bind_match(value);self.assertIsNone(trace.snapshot.match_id)


class ReaderIntegrationTests(unittest.TestCase):
    def fixture(self):
        f=roots_fixture.DispatcherChatRootReaderTests();memory,reader=f.fixture()
        return f,memory,reader

    def test_enabled_and_disabled_trace_have_identical_root_read_queries(self):
        outputs=[]
        for enabled in (False,True):
            f,memory,reader=self.fixture();queries=[];read=memory.read
            def recording(address,size):queries.append((address,size));return read(address,size)
            memory.read=recording;trace=DispatcherReadTrace() if enabled else None
            reader=DispatcherChatRootReader(memory,reader._resolver,trace=trace)
            outputs.append((reader.read(),queries))
        self.assertEqual(outputs[0],outputs[1])

    def test_observer_begin_or_complete_fault_does_not_reject_valid_roots(self):
        for method in ('begin','complete'):
            f,memory,reader=self.fixture();trace=DispatcherReadTrace()
            reader=DispatcherChatRootReader(memory,reader._resolver,trace=trace)
            with patch.object(trace,method,side_effect=RuntimeError('synthetic diagnostic fault')):
                self.assertEqual(2,len(reader.read()))
            self.assertEqual(1,reader.trace_faults)

    def test_torn_read_still_raises_original_error_and_records_timestamp(self):
        f,memory,reader=self.fixture();block=bytearray(memory.blocks[f.QUEUE]);struct.pack_into('<i',block,0x24,9)
        mutated=roots_fixture.MutatingMemory(f.QUEUE,block)
        for address,data in memory.blocks.items():mutated.map(address,data)
        trace=DispatcherReadTrace();reader=DispatcherChatRootReader(mutated,reader._resolver,trace=trace)
        with self.assertRaisesRegex(LayoutValidationError,'queue changed'):reader.read()
        self.assertEqual('QUEUE_TORN',trace.snapshot.events[0].error_code)
        self.assertLessEqual(trace.snapshot.events[0].started_ns,trace.snapshot.events[0].finished_ns)

    def test_observer_fault_cannot_hide_a_torn_read_exception(self):
        f,memory,reader=self.fixture();trace=DispatcherReadTrace()
        memory.blocks.pop(f.QUEUE)
        reader=DispatcherChatRootReader(memory,reader._resolver,trace=trace)
        with patch.object(trace,'complete',side_effect=RuntimeError('synthetic')):
            with self.assertRaises(LayoutValidationError):reader.read()
        self.assertEqual(1,reader.trace_faults)

    def test_shared_dto_root_binding_reaches_typed_capture_and_summary(self):
        f,memory,reader=self.fixture();block=bytearray(memory.blocks[f.CLOSURE_B])
        struct.pack_into('<Q',block,0x20,f.MESSAGE_A);memory.map(f.CLOSURE_B,block)
        fixture=outcomes.OutcomeTapTests();fixture.setUp();trace=fixture.tap._root_read_trace
        fixture.tap._reader=DispatcherChatRootReader(memory,reader._resolver,trace=trace)
        payloads={f.JSON_A:json.dumps(outcomes.envelope(sequence=9)),f.JSON_B:json.dumps(outcomes.envelope(sequence=11))}
        with patch('tools.dispatcher_qte_result_tap.read_il2cpp_string',side_effect=lambda _,address,**kw:payloads[address]), \
                patch('tools.dispatcher_qte_result_tap.read_server_message',side_effect=LayoutValidationError('unavailable')), \
                patch.object(fixture.tap,'_capture_runtime_batches'):
            fixture.tap._capture_once('M_SYNTHETIC')
        diagnostics=fixture.tap.diagnostics
        self.assertEqual(1,diagnostics.dispatcher_reads.shared_dto_read_samples)
        a,b=diagnostics.outcome_capture.observations
        self.assertEqual((9,11),(a.server_sequence,b.server_sequence))
        self.assertEqual(a.reader_binding.read_id,b.reader_binding.read_id)
        self.assertEqual(a.reader_binding.root.dto_token,b.reader_binding.root.dto_token)
        self.assertNotEqual(a.reader_binding.root.callback_token,b.reader_binding.root.callback_token)
        self.assertEqual(diagnostics.dispatcher_reads.trace_id,a.reader_binding.trace_id)
        self.assertEqual(0,diagnostics.dispatcher_read_trace_faults)
        self.assertEqual([],fixture.target.memory.mock_calls)

    def test_snapshot_or_binding_fault_does_not_change_board_delivery(self):
        fixture=outcomes.OutcomeTapTests();fixture.setUp()
        with patch.object(fixture.tap._root_read_trace,'binding',side_effect=RuntimeError('synthetic')):
            board=fixture.capture(outcomes.envelope())
        self.assertEqual('CAPTURED',fixture.tap.combat_outcome_fields(board)['combatOutcome']['status'])
        with patch.object(DispatcherReadTrace,'snapshot',new_callable=PropertyMock,side_effect=RuntimeError('synthetic')):
            self.assertFalse(fixture.tap.diagnostics.dispatcher_reads.input_authority)
        self.assertEqual(2,fixture.tap.diagnostics.dispatcher_read_trace_faults)


if __name__=='__main__':unittest.main()
