"""Sampler metadata must explain gaps without creating effects or authority."""
from dataclasses import asdict,FrozenInstanceError,replace
from collections import deque
import hashlib,json
import threading
from types import SimpleNamespace
import unittest
from unittest.mock import patch

from pokiguard_v2.combat_capture_diagnostics import CaptureTrace
from pokiguard_v2.combat_outcome_evidence import MAX_RETAINED_CAPTURES
from pokiguard_v2.il2cpp_layout import LayoutValidationError
import tests.test_combat_outcome_evidence as outcome_fixture
from tools.dispatcher_qte_result_tap import parse_server_envelope_json

envelope=outcome_fixture.envelope


def observe(trace,*,sequence=9,raw=None,dto=None,digest='a'*64,**changes):
    fields=dict(match_id='M_SYNTHETIC',raw_envelope=envelope(sequence=sequence) if raw is None else raw,
        dto_message=dto,raw_sha256=digest,json_chars=100,json_read_state='READ',json_read_error=None,
        board_parsed=True,projection_status='CAPTURED',projection_reason='RECORDED_SERVER_STEPS_NOT_A_DAMAGE_FORMULA')
    fields.update(changes);trace.observe(**fields)


class TraceTests(unittest.TestCase):
    def test_raw_identity_is_redacted_bounded_metadata_not_raw_effects(self):
        t=CaptureTrace();observe(t);row,=t.snapshot.observations
        self.assertEqual(('M_SYNTHETIC','MATCH_MOVE_RES',9),(row.match_id,row.event_type,row.server_sequence))
        self.assertEqual('IMMUTABLE_JSON',row.metadata_source)
        self.assertEqual('a'*64,row.raw_sha256)
        encoded=json.dumps(asdict(t.snapshot));self.assertNotIn('synthetic-player',encoded)
        self.assertNotIn('combatSteps',encoded);self.assertNotIn('native_positions',encoded)
        self.assertFalse(t.snapshot.input_authority);self.assertEqual('UNKNOWN',t.snapshot.effect_completeness)

    def test_immutable_cached_snapshot_is_not_copied_or_rebuilt_on_read(self):
        t=CaptureTrace();observe(t);snapshot=t.snapshot
        for _ in range(1000):self.assertIs(snapshot,t.snapshot)
        with self.assertRaises(FrozenInstanceError):snapshot.observations[0].queue_drained=True
        t.delivered('M_SYNTHETIC','MATCH_MOVE_RES',9,'BOARD')
        self.assertFalse(snapshot.observations[0].board_fields_offered)
        self.assertTrue(t.snapshot.observations[0].board_fields_offered)
        current=t.snapshot;t.delivered('M_SYNTHETIC','MATCH_MOVE_RES',9,'BOARD');self.assertIs(current,t.snapshot)

    def test_dto_only_read_failure_cannot_invent_an_immutable_hash_or_effect(self):
        t=CaptureTrace();dto=SimpleNamespace(match_id='M_SYNTHETIC',event_type='MATCH_MOVE_RES',server_sequence=12)
        observe(t,raw={},dto=dto,json_read_state='READ_ERROR',json_read_error='LayoutValidationError',
            projection_status=None,projection_reason=None,board_parsed=False)
        row,=t.snapshot.observations
        self.assertEqual(12,row.server_sequence);self.assertEqual('DTO_METADATA_ONLY_NOT_TYPED_EFFECTS',row.metadata_source)
        self.assertIsNone(row.raw_sha256);self.assertIsNone(row.json_chars)
        self.assertEqual('NOT_PROJECTED',row.projection_status)
        self.assertEqual((('LayoutValidationError',1),),t.snapshot.unscoped_json_read_errors)

    def test_wrong_match_or_invalid_sequence_does_not_enter_current_index(self):
        t=CaptureTrace()
        for seq in (True,-1,10000001,'9'):
            raw=envelope();raw['matchPayload']['srvSeq']=seq;observe(t,raw=raw)
        raw=envelope();raw['matchId']='M_OTHER';observe(t,raw=raw)
        self.assertFalse(t.snapshot.observations)

    def test_different_json_and_dto_match_never_attaches_the_wrong_raw_hash(self):
        t=CaptureTrace();raw=envelope();raw['matchId']='M_OTHER'
        dto=SimpleNamespace(match_id='M_SYNTHETIC',event_type='MATCH_MOVE_RES',server_sequence=20)
        observe(t,raw=raw,dto=dto)
        row,=t.snapshot.observations;self.assertEqual(20,row.server_sequence);self.assertIsNone(row.raw_sha256)

    def test_conflicting_immutable_identities_are_explicit_and_cannot_be_laundered_by_dto(self):
        t=CaptureTrace();observe(t);observe(t,digest='b'*64)
        self.assertTrue(t.snapshot.observations[0].conflicting_raw_identity)
        dto=SimpleNamespace(match_id='M_SYNTHETIC',event_type='MATCH_MOVE_RES',server_sequence=9)
        observe(t,raw={},dto=dto)
        self.assertEqual('IMMUTABLE_JSON',t.snapshot.observations[0].metadata_source)
        self.assertTrue(t.snapshot.observations[0].conflicting_raw_identity)

    def test_record_limit_is_hard_and_clear_removes_old_session_metadata(self):
        t=CaptureTrace()
        for seq in range(MAX_RETAINED_CAPTURES+3):observe(t,sequence=seq)
        self.assertEqual(MAX_RETAINED_CAPTURES,len(t.snapshot.observations))
        self.assertEqual(3,t.snapshot.dropped_observations)
        self.assertLess(len(json.dumps(asdict(t.snapshot))),128*1024)
        t.clear();self.assertFalse(t.snapshot.observations);self.assertEqual(0,t.snapshot.dropped_observations)

    def test_unscoped_read_errors_have_no_guessed_response_identity(self):
        t=CaptureTrace();observe(t,raw={},json_read_state='READ_ERROR',json_read_error='OSError')
        self.assertFalse(t.snapshot.observations);self.assertEqual((('OSError',1),),t.snapshot.unscoped_json_read_errors)

    def test_rejection_reason_and_invalid_delivery_are_not_unbounded_user_text(self):
        t=CaptureTrace();observe(t,projection_status='INVALID',projection_reason='private text\n'+('x'*200))
        self.assertIsNone(t.snapshot.observations[0].projection_reason)
        for seq in (True,-1,'9',[]):t.delivered('M_SYNTHETIC','MATCH_MOVE_RES',seq,'QUEUE')
        self.assertFalse(t.snapshot.observations[0].queue_drained)


class SamplerIntegrationTests(unittest.TestCase):
    def setUp(self):self.f=outcome_fixture.OutcomeTapTests();self.f.setUp()

    def test_exact_board_export_marks_only_that_retained_response_without_new_reads(self):
        board=self.f.capture(envelope());row,=self.f.tap.diagnostics.outcome_capture.observations
        self.assertEqual('CAPTURED',row.projection_status);self.assertTrue(row.board_parsed)
        self.assertFalse(row.board_fields_offered)
        self.assertEqual({},self.f.tap.combat_outcome_fields(replace(board)))
        record=self.f.tap.combat_outcome_fields(board)['combatOutcome']
        self.assertEqual('CAPTURED',record['status'])
        self.assertTrue(self.f.tap.diagnostics.outcome_capture.observations[0].board_fields_offered)
        self.assertEqual([],self.f.target.memory.mock_calls)

    def test_read_failure_with_valid_dto_is_indexed_without_reconstructing_combat_steps(self):
        dto=parse_server_envelope_json(json.dumps(envelope()),expected_match_id='M_SYNTHETIC',message_address=self.f.root.message_address)
        with patch('tools.dispatcher_qte_result_tap.read_il2cpp_string',side_effect=LayoutValidationError('private failure text')), \
                patch('tools.dispatcher_qte_result_tap.read_server_message',return_value=dto), \
                patch.object(self.f.tap,'_capture_runtime_batches'):
            self.f.tap._capture_once('M_SYNTHETIC')
        row,=self.f.tap.diagnostics.outcome_capture.observations
        self.assertEqual('READ_ERROR',row.json_read_state)
        self.assertEqual('DTO_METADATA_ONLY_NOT_TYPED_EFFECTS',row.metadata_source)
        self.assertFalse(self.f.tap.drain_combat_outcomes('M_SYNTHETIC'))
        self.assertEqual((dto,),self.f.tap.messages('M_SYNTHETIC'))
        self.assertEqual([],self.f.target.memory.mock_calls)

    def test_boardless_response_has_its_own_drained_marker_and_no_board_authority(self):
        raw=envelope();del raw['matchPayload']['board']
        with patch('tools.dispatcher_qte_result_tap.read_il2cpp_string',return_value=json.dumps(raw)), \
                patch('tools.dispatcher_qte_result_tap.read_server_message',side_effect=LayoutValidationError('gone')), \
                patch('tools.dispatcher_qte_result_tap.read_preparsed_board_snapshot',side_effect=LayoutValidationError('no board')), \
                patch.object(self.f.tap,'_capture_runtime_batches'):
            self.f.tap._capture_once('M_SYNTHETIC')
        before,=self.f.tap.diagnostics.outcome_capture.observations;self.assertFalse(before.board_parsed)
        record,=self.f.tap.drain_combat_outcomes('M_SYNTHETIC')
        self.assertFalse(record['input_authority']);self.assertFalse(record['evidence']['accepted_board_attached'])
        self.assertTrue(self.f.tap.diagnostics.outcome_capture.observations[0].queue_drained)
        self.assertEqual([],self.f.target.memory.mock_calls)

    def test_diagnostic_observer_and_delivery_faults_never_reject_a_board(self):
        with patch.object(self.f.tap._capture_trace,'observe',side_effect=RuntimeError('synthetic trace fault')):
            board=self.f.capture(envelope())
        self.assertEqual(1,self.f.tap.diagnostics.outcome_capture_faults)
        with patch.object(self.f.tap._capture_trace,'delivered',side_effect=RuntimeError('synthetic trace fault')):
            record=self.f.tap.combat_outcome_fields(board)['combatOutcome']
        self.assertEqual('CAPTURED',record['status']);self.assertEqual(64,len(board.cells))
        self.assertEqual(2,self.f.tap.diagnostics.outcome_capture_faults)
        self.assertEqual([],self.f.target.memory.mock_calls)

    def test_concurrent_boardless_drain_cannot_precede_its_metadata_observation(self):
        raw=envelope();del raw['matchPayload']['board']
        published=threading.Event();drained=threading.Event();errors=[]
        class PublishedQueue(deque):
            def append(queue,item):
                super().append(item);published.set()
        self.f.tap._pending_combat_outcomes=PublishedQueue()
        original=self.f.tap._trace_capture
        def interleave(**metadata):
            if published.is_set():
                if not drained.wait(2):raise AssertionError('consumer did not drain')
            original(**metadata)
        def producer():
            try:self.f.tap._capture_once('M_SYNTHETIC')
            except BaseException as exc:errors.append(exc)
        with patch('tools.dispatcher_qte_result_tap.read_il2cpp_string',return_value=json.dumps(raw)), \
                patch('tools.dispatcher_qte_result_tap.read_server_message',side_effect=LayoutValidationError('gone')), \
                patch('tools.dispatcher_qte_result_tap.read_preparsed_board_snapshot',side_effect=LayoutValidationError('no board')), \
                patch.object(self.f.tap,'_capture_runtime_batches'), \
                patch.object(self.f.tap,'_trace_capture',side_effect=interleave):
            worker=threading.Thread(target=producer,daemon=True);worker.start()
            try:
                self.assertTrue(published.wait(2))
                record,=self.f.tap.drain_combat_outcomes('M_SYNTHETIC')
                self.assertEqual('CAPTURED',record['status'])
            finally:
                drained.set();worker.join(2)
        self.assertFalse(worker.is_alive());self.assertEqual([],errors)
        self.assertTrue(self.f.tap.diagnostics.outcome_capture.observations[0].queue_drained)
        self.assertEqual([],self.f.target.memory.mock_calls)

    def test_session_reset_does_not_retain_another_match_trace(self):
        self.f.capture(envelope());self.assertTrue(self.f.tap.diagnostics.outcome_capture.observations)
        with patch('tools.dispatcher_qte_result_tap.threading.Thread'),patch.object(self.f.tap,'_capture_once'):
            self.f.tap.arm('M_OTHER')
        self.assertFalse(self.f.tap.diagnostics.outcome_capture.observations)


if __name__=='__main__':unittest.main()
