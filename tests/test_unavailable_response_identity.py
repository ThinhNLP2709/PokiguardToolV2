"""Missing effects must stay missing while independently scoped gaps stay local."""
from copy import deepcopy
import json
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

from pokiguard_v2.combat_outcome_evidence import RESPONSE_IDENTITY_SCHEMA
from pokiguard_v2.il2cpp_layout import LayoutValidationError
from tests.reasoning_test_paths import reasoning_temp_root
from tests.test_combat_board_evidence import boundary_rows
from tests.test_combat_outcome_evidence import envelope, projected
import tests.test_combat_outcome_evidence as outcome_fixture
from tests.test_outcome_exclusion_scope import rejected_offer
from tools.normalize_boss_transitions import extract
from tools.audit_resource_balances import audit


def unavailable(sequence=7, *, explicit=True):
    raw = envelope(sequence=sequence)
    raw['matchPayload'].pop('combatSteps')
    # projected() deliberately fixes expected sequence9, so supply this fence here.
    from pokiguard_v2.combat_outcome_evidence import project_combat_outcome
    record = project_combat_outcome(raw, expected_match_id='M_SYNTHETIC',
        expected_sequence=sequence, raw_sha256='4' * 64).to_dict()
    if not explicit:
        record.pop('response_identity')
    return dict(event='dispatcher_combat_outcome', matchId='M_SYNTHETIC',
        lifecycleEpoch=1, combatOutcome=record)


def metadata(sequence, status, reason, digest):
    return dict(match_id='M_SYNTHETIC', event_type='MATCH_MOVE_RES', server_sequence=sequence,
        metadata_source='IMMUTABLE_JSON', raw_sha256=digest, json_chars=1000,
        json_read_state='READ', json_read_error=None, conflicting_raw_identity=False,
        projection_status=status, projection_reason=reason, board_fields_offered=False,
        queue_drained=status == 'CAPTURED', reader_binding=dict(trace_id='a' * 24, read_id=sequence,
            read_started_ns=sequence * 10, read_finished_ns=sequence * 10 + 1, decoded_ns=sequence * 10 + 2,
            root=dict(callback_token='b' * 24, dto_token='c' * 24, json_token='d' * 24,
                source='execution_queue', logical_index=0)))


def legacy_rows(sequence=7):
    rows = boundary_rows()
    rows[1].update(matchId='M_SYNTHETIC', lifecycleEpoch=1)
    capture = rows[1]['combatOutcome']; evidence = capture['evidence']
    observations = [metadata(sequence, 'UNAVAILABLE', 'COMBAT_STEPS_ABSENT', '4' * 64),
        metadata(9, 'CAPTURED', capture['reason'], evidence['raw_sha256'])]
    summary = dict(event='auto_controller_summary', sessionCleared=True, activeSession=None,
        pending=None, status='STOPPED', dispatcherTransport=dict(outcome_capture_faults=0,
            dispatcher_read_trace_faults=0, dispatcher_reads=dict(schema='pokiguard.dispatcher_read_trace.v1',
                trace_id='a' * 24, match_id='M_SYNTHETIC', reads_started=100, reads_completed=100,
                obsolete_completions=0, input_authority=False, effect_completeness='UNKNOWN'),
            outcome_capture=dict(schema='pokiguard.combat_capture_diagnostics.v1', record_limit=128,
                dropped_observations=0, unscoped_json_read_errors=[], input_authority=False,
                effect_completeness='UNKNOWN', observations=observations)))
    return rows + [unavailable(sequence, explicit=False), summary]


class UnavailableIdentityTests(unittest.TestCase):
    def run_rows(self, rows, consumer=extract):
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as directory:
            path = Path(directory) / 'combat.jsonl'
            path.write_text('\n'.join(json.dumps(r) if type(r) is dict else r for r in rows) + '\n', encoding='utf-8')
            return consumer(path)

    def test_absent_empty_rejected_and_malformed_effects_keep_identity_without_effects(self):
        for steps, expected in ((None, 'UNAVAILABLE'), ([], 'UNAVAILABLE'), ('bad', 'INVALID')):
            raw = envelope(); raw['matchPayload']['combatSteps'] = steps
            result = projected(raw).to_dict()
            self.assertEqual(expected, result['status']); self.assertIsNone(result['evidence'])
            identity = result['response_identity']
            self.assertEqual((RESPONSE_IDENTITY_SCHEMA, 'M_SYNTHETIC', 9),
                (identity['schema'], identity['match_id'], identity['server_sequence']))
            self.assertFalse(identity['effect_evidence']); self.assertFalse(identity['input_authority'])
            self.assertNotIn('synthetic-player', json.dumps(result))
        raw = envelope(); raw['rejectReason'] = 'synthetic'
        self.assertEqual('REJECTED', projected(raw).status)
        self.assertIn('response_identity', projected(raw).to_dict())
        self.assertNotIn('response_identity', projected().to_dict())

    def test_failed_match_sequence_or_hash_fence_never_creates_identity(self):
        from pokiguard_v2.combat_outcome_evidence import project_combat_outcome
        for match, sequence, digest in (('OTHER', 9, 'a' * 64), ('M_SYNTHETIC', True, 'a' * 64),
                ('M_SYNTHETIC', 8, 'a' * 64), ('M_SYNTHETIC', 9, 'bad')):
            raw = envelope(); raw['matchPayload'].pop('combatSteps')
            record = project_combat_outcome(raw, expected_match_id=match,
                expected_sequence=sequence, raw_sha256=digest).to_dict()
            self.assertNotIn('response_identity', record)

    def test_new_drained_identity_scopes_outside_but_blocks_inside_sequence(self):
        for sequence, expected in ((7, 1), (9, 0), (10, 1)):
            case = self.run_rows(boundary_rows() + [unavailable(sequence)])
            self.assertEqual(expected, len(case['intervals']))
            self.assertEqual(1, len(case['outcome_exclusions']))
            scope = case['outcome_exclusion_scopes'][0]
            self.assertEqual('EXPLICIT_IMMUTABLE_RESPONSE_IDENTITY', scope['scope_basis'])
            self.assertEqual(sequence, scope['scope']['server_sequence'])
            self.assertEqual(0, case['unscoped_outcome_exclusions'])

    def test_in_interval_emission_blocks_even_with_an_outside_explicit_sequence(self):
        rows = boundary_rows(); rows.insert(1, unavailable())
        self.assertFalse(self.run_rows(rows)['intervals'])

    def test_malformed_or_contradictory_explicit_identity_remains_unscoped(self):
        mutations = [lambda r: r['combatOutcome']['response_identity'].update(server_sequence=True),
            lambda r: r['combatOutcome']['response_identity'].update(raw_sha256='bad'),
            lambda r: r['combatOutcome']['response_identity'].update(source='OTHER'),
            lambda r: r['combatOutcome']['response_identity'].update(effect_evidence=True),
            lambda r: r['combatOutcome']['response_identity'].update(input_authority=True),
            lambda r: r.update(matchId='OTHER'), lambda r: r.update(lifecycleEpoch=True),
            lambda r: r.update(srvSeq=10), lambda r: r.update(eventType='MATCH_CARD_USE_RES')]
        for mutate in mutations:
            row = unavailable(); mutate(row)
            with self.subTest(row=row):
                case = self.run_rows(boundary_rows() + [row])
                self.assertFalse(case['intervals']); self.assertEqual(1, case['unscoped_outcome_exclusions'])

    def test_explicit_identity_must_agree_with_independent_board_scope(self):
        row = rejected_offer(10)
        row['combatOutcome'].update(response_identity=unavailable(7)['combatOutcome']['response_identity'])
        case = self.run_rows(boundary_rows() + [row])
        self.assertFalse(case['intervals']); self.assertEqual(1, case['unscoped_outcome_exclusions'])
        row['combatOutcome']['response_identity']['server_sequence'] = 10
        self.assertEqual(1, len(self.run_rows(boundary_rows() + [row])['intervals']))

    def test_legacy_complete_accounting_recovers_only_outside_scope_not_effects(self):
        case = self.run_rows(legacy_rows())
        self.assertEqual(1, len(case['intervals'])); self.assertEqual(1, len(case['outcome_exclusions']))
        scoped = case['outcome_exclusion_scopes'][0]
        self.assertEqual('UNIQUE_COMPLETE_CAPTURE_METADATA_ACCOUNTING', scoped['scope_basis'])
        self.assertEqual(7, scoped['scope']['server_sequence'])
        self.assertEqual('UNKNOWN', case['intervals'][0]['whole_action_completeness'])
        self.assertFalse(case['intervals'][0]['training_eligible'])

    def test_legacy_inside_scope_or_inside_line_stays_blocked(self):
        # A sequence9 candidate conflicts with the already captured identity.
        self.assertFalse(self.run_rows(legacy_rows(9))['intervals'])
        rows = legacy_rows(); missing = rows.pop(-2); rows.insert(1, missing)
        self.assertFalse(self.run_rows(rows)['intervals'])

    def test_legacy_time_or_nearest_metadata_never_resolves_ambiguous_residuals(self):
        rows = legacy_rows(); rows.insert(-1, unavailable(10, explicit=False))
        rows[-1]['dispatcherTransport']['outcome_capture']['observations'].append(
            metadata(10, 'UNAVAILABLE', 'COMBAT_STEPS_ABSENT', '5' * 64))
        rows[-2]['timestamp'] = '2000-01-01T00:00:00Z'
        case = self.run_rows(rows)
        self.assertFalse(case['intervals']); self.assertEqual(2, case['unscoped_outcome_exclusions'])

    def test_legacy_partial_conflicting_cross_session_or_unclosed_metadata_is_rejected(self):
        mutations = [
            lambda s: s['dispatcherTransport'].update(outcome_capture_faults=1),
            lambda s: s['dispatcherTransport'].update(dispatcher_read_trace_faults=1),
            lambda s: s['dispatcherTransport']['outcome_capture'].update(dropped_observations=1),
            lambda s: s['dispatcherTransport']['outcome_capture'].update(unscoped_json_read_errors=[['ValueError', 1]]),
            lambda s: s['dispatcherTransport']['outcome_capture']['observations'][0].update(conflicting_raw_identity=True),
            lambda s: s['dispatcherTransport']['outcome_capture']['observations'][1].update(raw_sha256='0' * 64),
            lambda s: s['dispatcherTransport']['outcome_capture']['observations'][0].update(reader_binding=None),
            lambda s: s['dispatcherTransport']['outcome_capture']['observations'][0]['reader_binding'].update(trace_id='OTHER'),
            lambda s: s['dispatcherTransport']['outcome_capture']['observations'][0]['reader_binding'].update(decoded_ns=0),
            lambda s: s['dispatcherTransport']['outcome_capture']['observations'][0]['reader_binding'].pop('root'),
            lambda s: s['dispatcherTransport']['dispatcher_reads'].update(match_id='OTHER'),
            lambda s: s['dispatcherTransport']['dispatcher_reads'].update(reads_started=101),
            lambda s: s['dispatcherTransport']['dispatcher_reads'].update(obsolete_completions=1),
            lambda s: s.update(sessionCleared=False), lambda s: s.update(pending={}),
            lambda s: s.update(status='RUNNING')]
        for mutate in mutations:
            rows = legacy_rows(); mutate(rows[-1])
            with self.subTest(mutate=mutate):
                case = self.run_rows(rows)
                self.assertFalse(case['intervals']); self.assertEqual(1, case['unscoped_outcome_exclusions'])
        for mode in ('missing_index', 'duplicate_index', 'duplicate_output', 'other_epoch', 'extra_summary', 'bad_json'):
            rows = legacy_rows(); index = rows[-1]['dispatcherTransport']['outcome_capture']['observations']
            if mode == 'missing_index': index.pop()
            if mode == 'duplicate_index': index.append(deepcopy(index[0]))
            if mode == 'duplicate_output': rows.insert(-1, deepcopy(rows[1]))
            if mode == 'other_epoch': rows[-2]['lifecycleEpoch'] = 2
            if mode == 'extra_summary': rows.append(deepcopy(rows[-1]))
            if mode == 'bad_json': rows.append('{invalid')
            with self.subTest(mode=mode): self.assertFalse(self.run_rows(rows)['intervals'])

    def test_invalid_explicit_identity_cannot_fall_back_to_legacy_metadata(self):
        rows = legacy_rows(); rows[-2]['combatOutcome']['response_identity'] = {}
        self.assertFalse(self.run_rows(rows)['intervals'])

    def test_scoped_gap_is_preserved_by_resource_consumer(self):
        rows = legacy_rows()
        for row in (rows[0], rows[2]):
            state = row['stateEvidence']; state['player'].update(is_local=True, is_boss=False)
            for player in [state['player'], *state['bosses']]:
                player.update(mana=10, max_mana=100, power=20, max_power=250)
            for boss in state['bosses']: boss.update(is_local=False, is_boss=True)
        report = self.run_rows(rows, lambda p: audit([p]))
        self.assertEqual(1, report['summary']['boss_intervals'])
        self.assertEqual(1, len(report['capture_gaps']))

    def test_boardless_unavailable_queue_marks_delivery_with_no_extra_reads(self):
        fixture = outcome_fixture.OutcomeTapTests(); fixture.setUp()
        raw = envelope(); raw['matchPayload'].pop('board'); raw['matchPayload'].pop('combatSteps')
        with patch('tools.dispatcher_qte_result_tap.read_il2cpp_string', return_value=json.dumps(raw)), \
                patch('tools.dispatcher_qte_result_tap.read_server_message', side_effect=LayoutValidationError('gone')), \
                patch('tools.dispatcher_qte_result_tap.read_preparsed_board_snapshot', side_effect=LayoutValidationError('gone')), \
                patch.object(fixture.tap, '_capture_runtime_batches'):
            fixture.tap._capture_once('M_SYNTHETIC')
        before = fixture.tap.results('M_SYNTHETIC')
        (record,) = fixture.tap.drain_combat_outcomes('M_SYNTHETIC')
        self.assertEqual('UNAVAILABLE', record['status']); self.assertIsNone(record['evidence'])
        self.assertEqual(9, record['response_identity']['server_sequence'])
        self.assertTrue(fixture.tap.diagnostics.outcome_capture.observations[0].queue_drained)
        self.assertEqual(before, fixture.tap.results('M_SYNTHETIC'))
        self.assertEqual([], fixture.target.memory.mock_calls)


if __name__ == '__main__':
    unittest.main()
