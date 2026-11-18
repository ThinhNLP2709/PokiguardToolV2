"""Synthetic server-envelope evidence; no target process or damage authority."""
from copy import deepcopy
from dataclasses import replace
import hashlib
import json
from pathlib import Path
from types import SimpleNamespace
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.combat_outcome_evidence import (
    MAX_STEPS, MAX_OPERATIONS, actor_identity, drain_outcomes_safely, export_outcome_safely,
    observed_effect_totals, project_combat_outcome,
)
from pokiguard_v2.dispatcher_chat_roots import DispatcherChatMessageRoot
from pokiguard_v2.il2cpp_layout import LayoutValidationError
from tests.reasoning_test_paths import reasoning_temp_root
from tools.audit_combat_outcomes import audit
from tools.dispatcher_qte_result_tap import DispatcherTransportTap


def envelope(event='MATCH_MOVE_RES', sequence=9):
    return dict(type=event, matchId='M_SYNTHETIC', fromRow=7, fromCol=1, toRow=6, toCol=1,
        matchPayload=dict(srvSeq=sequence, actorUsername='synthetic-player', turnNumber=2,
            board=[[dict(row=r, col=c, tag='vang Dot', multiplier=1) for c in range(8)] for r in range(8)],
            combatSteps=[
                dict(idx=0, kind='DAMAGE', source='synthetic-player', target='__BOSS__',
                     amount=1200, dmgSrc='BOARD_DOT', fullPower=True, after=dict(hp=5000)),
                dict(idx=1, kind='HEAL', source='synthetic-player', target='synthetic-player',
                     amount=350, after=dict(hp=8000)),
                dict(idx=2, kind='DAMAGE', source='synthetic-player', target='__BOSS__',
                     amount=200, dmgSrc='ANOTHER_EFFECT', fullPower=False),
            ], totalDamageDisplay=1400, destroyedByTag={'vang Dot': 3}))


def projected(raw=None):
    raw = envelope() if raw is None else raw
    text = json.dumps(raw)
    return project_combat_outcome(raw, expected_match_id='M_SYNTHETIC', expected_sequence=9,
        raw_sha256=hashlib.sha256(text.encode()).hexdigest())


class OutcomeProjectionTests(unittest.TestCase):
    def test_b16_operations_retain_all_native_swaps_without_replacing_outer_move(self):
        raw=envelope();raw['matchPayload']['actorUsername']='__BOSS__'
        raw['matchPayload']['ops']=[dict(type='OTHER'),
            dict(type='SWAP',data=dict(fromRow=1,fromCol=2,toRow=1,toCol=3)),
            dict(type='SWAP',data=dict(fromRow=2,fromCol=3,toRow=3,toCol=3))]
        evidence=projected(raw).to_dict()['evidence']
        self.assertEqual('BOSS',evidence['actor_identity'])
        self.assertEqual([7,1,6,1],evidence['wire_swap'])
        self.assertEqual([(1,[1,2,1,3]),(2,[2,3,3,3])],
            [(s['operation_index'],s['native_swap']) for s in evidence['swap_operations']])
        self.assertEqual('UNKNOWN',evidence['swap_operation_decision_binding'])
        self.assertEqual('matchPayload.ops[].data',evidence['swap_operation_source'])
        self.assertIsNone(projected().to_dict()['evidence']['swap_operations'])
        raw['matchPayload']['ops']=[]
        self.assertEqual([],projected(raw).to_dict()['evidence']['swap_operations'])

    def test_operation_missing_boolean_nonadjacent_or_oversized_data_is_not_guessed(self):
        good=dict(fromRow=1,fromCol=2,toRow=1,toCol=3)
        for data in ({},dict(good,toCol=True),dict(good,toCol=5),dict(good,toRow='1'),None):
            raw=envelope();raw['matchPayload']['ops']=[dict(type='SWAP',data=data)]
            with self.subTest(data=data):self.assertEqual('INVALID',projected(raw).status)
        for operations in ({},[None],[dict(type=True)],[dict(type='OTHER')]*(MAX_OPERATIONS+1)):
            raw=envelope();raw['matchPayload']['ops']=operations
            with self.subTest(operations=str(operations)[:32]):self.assertEqual('INVALID',projected(raw).status)

    def test_steal_types_are_retained_and_never_merged_across_resources(self):
        raw=envelope()
        raw['matchPayload']['combatSteps']=[
            dict(idx=0,kind='STEAL',source='synthetic-player',target='__BOSS__',amount=40,stealType='MANA'),
            dict(idx=1,kind='STEAL',source='synthetic-player',target='__BOSS__',amount=60,stealType='POWER')]
        result=projected(raw).to_dict()
        self.assertEqual(['MANA','POWER'],[s['steal_type'] for s in result['evidence']['steps']])
        totals=observed_effect_totals(result)
        self.assertEqual([('MANA',40),('POWER',60)],[(s['steal_type'],s['observed_amount']) for s in totals])
        self.assertIsNone(projected().to_dict()['evidence']['steps'][0]['steal_type'])

    def test_bad_steal_type_only_invalidates_optional_evidence(self):
        for value in (True,123,[],{},'', 'x'*65):
            raw=envelope();raw['matchPayload']['combatSteps'][0]['stealType']=value
            with self.subTest(value=value):self.assertEqual('INVALID',projected(raw).status)

    def test_effect_sources_targets_and_missing_full_power_stay_separate(self):
        capture = projected()
        self.assertEqual('CAPTURED', capture.status)
        record = capture.to_dict()
        evidence = record['evidence']
        self.assertNotIn('synthetic-player', capture.payload_json)
        self.assertEqual(actor_identity('synthetic-player'), evidence['actor_identity'])
        self.assertIsNone(evidence['steps'][1]['full_power'])
        self.assertEqual([7, 1, 6, 1], evidence['wire_swap'])
        totals = observed_effect_totals(record)
        self.assertEqual([1200, 350, 200], [item['observed_amount'] for item in totals])
        self.assertEqual(['BOARD_DOT', None, 'ANOTHER_EFFECT'], [item['damage_source'] for item in totals])
        self.assertFalse(evidence['calibration_eligible'])
        self.assertFalse(record['damage_prediction'])
        self.assertFalse(record['input_authority'])

    def test_hp_difference_or_display_total_alone_is_not_attributed_damage(self):
        for value in (None, []):
            raw = envelope(); raw['matchPayload']['combatSteps'] = value
            result = projected(raw)
            self.assertEqual('UNAVAILABLE', result.status)
            self.assertIsNone(result.payload_json)
            self.assertEqual((), observed_effect_totals(result.to_dict()))

    def test_wrong_match_sequence_actor_and_boolean_amount_are_not_evidence(self):
        cases = []
        raw = envelope(); raw['matchId'] = 'STALE'; cases.append(raw)
        raw = envelope(); raw['matchPayload']['srvSeq'] = True; cases.append(raw)
        raw = envelope(); raw['matchPayload']['srvSeq'] = 10; cases.append(raw)
        raw = envelope(); raw['matchPayload']['actorUsername'] = None; cases.append(raw)
        raw = envelope(); raw['matchPayload']['combatSteps'][0]['amount'] = True; cases.append(raw)
        raw = envelope(); raw['matchPayload']['combatSteps'][0]['fullPower'] = 1; cases.append(raw)
        for raw in cases:
            with self.subTest(raw=cases.index(raw)):
                self.assertEqual('INVALID', projected(raw).status)

    def test_duplicate_or_reordered_steps_are_rejected_and_gaps_stay_explicit(self):
        raw = envelope(); raw['matchPayload']['combatSteps'][1]['idx'] = 0
        self.assertEqual('INVALID', projected(raw).status)
        raw = envelope(); raw['matchPayload']['combatSteps'][2]['idx'] = 4
        record = projected(raw).to_dict()
        self.assertFalse(record['evidence']['index_contiguous'])
        self.assertFalse(record['evidence']['calibration_eligible'])

    def test_excessive_step_count_and_encoded_capture_size_have_no_partial_fit(self):
        raw = envelope(); step = raw['matchPayload']['combatSteps'][0]
        raw['matchPayload']['combatSteps'] = [dict(step, idx=i) for i in range(MAX_STEPS+1)]
        self.assertEqual('STEP_SHAPE_OR_LIMIT', projected(raw).reason)
        raw['matchPayload']['combatSteps'] = [dict(step, idx=i, after={str(j)+'x'*60: j for j in range(32)})
            for i in range(40)]
        result = projected(raw)
        self.assertEqual(('INVALID', 'CAPTURE_SIZE_LIMIT'), (result.status, result.reason))
        self.assertIsNone(result.payload_json)

    def test_rejected_response_cannot_supply_training_samples(self):
        raw = envelope(); raw['matchPayload']['success'] = False
        self.assertEqual('REJECTED', projected(raw).status)
        raw = envelope(); raw['rejectReason'] = 'timeout'
        self.assertEqual('REJECTED', projected(raw).status)

    def test_optional_export_faults_or_wrong_shape_never_escape_to_controller(self):
        tap = SimpleNamespace(combat_outcome_fields=Mock(side_effect=OSError('synthetic disk fault')))
        result = export_outcome_safely(tap, object())
        self.assertEqual('INVALID', result['combatOutcome']['status'])
        self.assertFalse(result['combatOutcome']['input_authority'])
        tap.combat_outcome_fields.return_value = {'selectedAction': 'unsafe'}
        tap.combat_outcome_fields.side_effect = None
        self.assertEqual({}, export_outcome_safely(tap, object()))
        tap.drain_combat_outcomes = Mock(side_effect=RuntimeError('synthetic'))
        (failure,) = drain_outcomes_safely(tap, 'M_SYNTHETIC')
        self.assertEqual('INVALID', failure['status'])
        self.assertFalse(failure['input_authority'])

    def test_offline_audit_distinguishes_legacy_snapshots_from_recorded_effects(self):
        import tempfile
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as directory:
            path = Path(directory)/'combat.jsonl'
            rows = [dict(event='auto_controller_started', config=dict(play_style='demon_aegis_farm')),
                dict(event='policy_decision', player=dict(hp=10), boss=dict(hp=5000)),
                dict(event='dispatcher_board_snapshot_offered', combatOutcome=projected().to_dict()),
                dict(event='dispatcher_board_snapshot_offered', combatOutcome=projected().to_dict())]
            path.write_text(''.join(json.dumps(row)+'\n' for row in rows), encoding='utf-8')
            report = audit([path])
            self.assertEqual(1, report['counts']['batches_with_typed_effects'])
            self.assertEqual(1, report['counts']['duplicate_outcomes'])
            self.assertEqual(0, report['fitted_damage_models'])
            self.assertTrue(report['hp_delta_is_not_damage'])
            self.assertFalse(report['process_attachment'])


class OutcomeTapTests(unittest.TestCase):
    def setUp(self):
        self.target = SimpleNamespace(memory=Mock(), resolver=Mock())
        self.target.resolver.resolve_type_info_class.return_value = 0x123000
        self.tap = DispatcherTransportTap(self.target)
        self.tap._reader = Mock()
        self.root = DispatcherChatMessageRoot(0x200000, 0x210000, 0x220000, 'drain_buffer',
            0, json_address=0x230000)
        self.tap._reader.read.return_value = (self.root,)

    def capture(self, raw):
        with patch('tools.dispatcher_qte_result_tap.read_il2cpp_string', return_value=json.dumps(raw)), \
                patch('tools.dispatcher_qte_result_tap.read_server_message', side_effect=LayoutValidationError('DTO gone')), \
                patch.object(self.tap, '_capture_runtime_batches'):
            self.tap._capture_once('M_SYNTHETIC')
        return self.tap.transport_board_snapshots('M_SYNTHETIC')[-1][1]

    def test_move_card_and_skill_share_exact_board_identity_without_extra_memory_reads(self):
        for event in ('MATCH_MOVE_RES', 'MATCH_CARD_USE_RES', 'MATCH_SKILL_USE_RES'):
            snapshot = self.capture(envelope(event))
            record = self.tap.combat_outcome_fields(snapshot)['combatOutcome']
            self.assertEqual('CAPTURED', record['status'])
            self.assertEqual(event, record['evidence']['event_type'])
            self.assertEqual(64, len(snapshot.cells))
            self.assertEqual({}, self.tap.combat_outcome_fields(replace(snapshot)))
        self.assertEqual([], self.target.memory.mock_calls)

    def test_bad_steps_and_projection_fault_do_not_reject_the_valid_board(self):
        raw = envelope(); raw['matchPayload']['combatSteps'][0]['amount'] = 'not an integer'
        snapshot = self.capture(raw)
        self.assertEqual('INVALID', self.tap.combat_outcome_fields(snapshot)['combatOutcome']['status'])
        with patch('tools.dispatcher_qte_result_tap.project_combat_outcome', side_effect=RuntimeError('synthetic')):
            snapshot = self.capture(envelope(sequence=10))
        self.assertEqual('INVALID', self.tap.combat_outcome_fields(snapshot)['combatOutcome']['status'])
        self.assertEqual(0, self.tap.diagnostics.raw_board_rejections)
        self.assertEqual(64, len(snapshot.cells))

    def test_invalid_optional_operation_does_not_reject_board_or_add_memory_reads(self):
        raw=envelope();raw['matchPayload']['ops']=[dict(type='SWAP',data={})]
        snapshot=self.capture(raw)
        self.assertEqual(64,len(snapshot.cells))
        self.assertEqual('INVALID',self.tap.combat_outcome_fields(snapshot)['combatOutcome']['status'])
        self.assertEqual(0,self.tap.diagnostics.raw_board_rejections)
        self.assertEqual([],self.target.memory.mock_calls)

    def test_reused_callback_address_cannot_attach_old_evidence_to_new_board(self):
        old = self.capture(envelope())
        new = self.capture(envelope(sequence=10))
        self.assertEqual({}, self.tap.combat_outcome_fields(old))
        self.assertEqual(10, self.tap.combat_outcome_fields(new)['combatOutcome']['evidence']['server_sequence'])

    def test_retention_cap_and_rearming_preserve_board_delivery_and_clear_old_evidence(self):
        with patch('tools.dispatcher_qte_result_tap.MAX_RETAINED_CAPTURES', 1):
            self.capture(envelope())
            self.tap._reader.read.return_value = (replace(self.root, message_address=0x300000),)
            snapshot = self.capture(envelope(sequence=10))
            self.assertEqual(2, len(self.tap.transport_board_snapshots('M_SYNTHETIC')))
            record = self.tap.combat_outcome_fields(snapshot)['combatOutcome']
            self.assertEqual('CAPTURE_LIMIT_REACHED', record['reason'])
        self.tap._reader.read.return_value = ()
        with patch('tools.dispatcher_qte_result_tap.threading.Thread'), patch.object(self.tap, '_capture_once'):
            self.tap.arm('ANOTHER_MATCH')
        self.assertEqual({}, self.tap._combat_outcomes)
        self.assertEqual({}, self.tap.combat_outcome_fields(snapshot))

    def test_galaxy_skill_without_board_is_retained_only_as_unattested_diagnostics(self):
        raw = envelope('MATCH_SKILL_USE_RES'); del raw['matchPayload']['board']
        with patch('tools.dispatcher_qte_result_tap.read_il2cpp_string', return_value=json.dumps(raw)), \
                patch('tools.dispatcher_qte_result_tap.read_server_message', side_effect=LayoutValidationError('DTO gone')), \
                patch('tools.dispatcher_qte_result_tap.read_preparsed_board_snapshot', side_effect=LayoutValidationError('no board')), \
                patch.object(self.tap, '_capture_runtime_batches'):
            self.tap._capture_once('M_SYNTHETIC')
        self.assertEqual((), self.tap.transport_board_snapshots('M_SYNTHETIC'))
        results_before = self.tap.results('M_SYNTHETIC')
        self.assertEqual(1, len(results_before))
        self.assertEqual((), self.tap.drain_combat_outcomes('WRONG_MATCH'))
        (record,) = drain_outcomes_safely(self.tap, 'M_SYNTHETIC')
        self.assertEqual('CAPTURED', record['status'])
        self.assertFalse(record['evidence']['accepted_board_attached'])
        self.assertFalse(record['evidence']['calibration_eligible'])
        self.assertEqual((), self.tap.drain_combat_outcomes('M_SYNTHETIC'))
        self.assertEqual(results_before, self.tap.results('M_SYNTHETIC'))
        self.assertEqual([], self.target.memory.mock_calls)

    def test_boardless_queue_has_a_hard_limit_and_bounded_drain(self):
        from pokiguard_v2.combat_outcome_evidence import CombatOutcomeCapture
        capture = CombatOutcomeCapture('UNAVAILABLE', 'SYNTHETIC')
        self.tap._pending_combat_outcomes.extend([('M_SYNTHETIC', capture)]*4)
        self.assertEqual(2, len(self.tap.drain_combat_outcomes('M_SYNTHETIC')))
        self.assertEqual(2, len(self.tap._pending_combat_outcomes))
        self.tap._dropped_combat_outcomes = 1
        records = self.tap.drain_combat_outcomes('M_SYNTHETIC')
        self.assertEqual(2, len(records))
        self.assertEqual('CAPTURE_QUEUE_OR_RECORD_LIMIT_REACHED', records[0]['reason'])


if __name__ == '__main__':
    unittest.main()
