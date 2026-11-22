"""B17 ordered diagnostics: no new reads, input, formulas or fallback zeros."""
from copy import deepcopy
import json,tempfile,unittest
from pathlib import Path

from pokiguard_v2.combat_outcome_evidence import observed_effect_totals
from tools.normalize_action_outcomes import checked,extract
from tests.reasoning_test_paths import reasoning_temp_root
import tests.test_combat_outcome_evidence as fixture


def message():
    raw=fixture.envelope()
    raw['matchPayload']['ops']=[
        dict(type='STAT_CHANGE',data=dict(targetUsername='synthetic-player',statType='POWER',delta=5,newValue=85,reason='TURN_START')),
        dict(type='SWAP',data=dict(fromRow=1,fromCol=2,toRow=1,toCol=3)),
        dict(type='DESTROY',data=dict(positions=[[2,1],[3,1],[4,1]])),
        dict(type='UNMODELED_OPERATION'),
        dict(type='STAT_CHANGE',data=dict(targetUsername='__BOSS__',statType='POWER',delta=-100,newValue=0,source='SYNTHETIC_REASON'))]
    return raw


class OrderedResourceEvidenceTests(unittest.TestCase):
    def test_trace_preserves_order_axes_actor_and_exact_zero(self):
        e=fixture.projected(message()).to_dict()['evidence'];ops=e['resource_operations']
        self.assertEqual([0,2,4],[o['operation_index'] for o in ops])
        self.assertEqual([1],[s['operation_index'] for s in e['swap_operations']])
        self.assertEqual('sha256:',ops[0]['target'][:7]);self.assertEqual(5,ops[0]['delta'])
        self.assertEqual('BOSS',ops[2]['target']);self.assertEqual(0,ops[2]['new_value'])
        self.assertEqual(-100,ops[2]['delta'])
        self.assertEqual('COL_ROW',ops[1]['position_order'])
        self.assertEqual([[2,1],[3,1],[4,1]],ops[1]['native_positions'])
        self.assertEqual('UNKNOWN',ops[1]['tag_multiplier_binding'])
        self.assertNotIn('sword_count',ops[1]);self.assertNotIn('physical_swords',ops[1])

    def test_missing_stat_fields_stay_none_and_missing_positions_differ_from_empty(self):
        raw=fixture.envelope();raw['matchPayload']['ops']=[dict(type='STAT_CHANGE',data={}),
            dict(type='DESTROY',data={}),dict(type='DESTROY',data=dict(positions=[]))]
        ops=fixture.projected(raw).to_dict()['evidence']['resource_operations']
        self.assertTrue(all(ops[0][k] is None for k in ('target','stat_type','delta','new_value','reason','source_label')))
        self.assertIsNone(ops[1]['native_positions']);self.assertEqual([],ops[2]['native_positions'])

    def test_legacy_absent_trace_and_present_empty_trace_are_distinct(self):
        self.assertIsNone(fixture.projected().to_dict()['evidence']['resource_operations'])
        raw=fixture.envelope();raw['matchPayload']['ops']=[]
        self.assertEqual([],fixture.projected(raw).to_dict()['evidence']['resource_operations'])

    def test_source_json_is_not_mutated_and_user_target_is_redacted(self):
        raw=message();old=deepcopy(raw);record=fixture.projected(raw).to_dict()
        self.assertEqual(raw,old)
        self.assertNotIn('synthetic-player',json.dumps(record['evidence']['resource_operations']))
        self.assertFalse(record['input_authority']);self.assertFalse(record['evidence']['calibration_eligible'])
        self.assertEqual('UNKNOWN',record['evidence']['complete_server_effect_coverage'])

    def test_duplicate_coordinates_are_not_deduplicated_or_relabelled_as_swords(self):
        raw=fixture.envelope();raw['matchPayload']['ops']=[dict(type='DESTROY',data=dict(positions=[[2,3],[2,3]]))]
        op=fixture.projected(raw).to_dict()['evidence']['resource_operations'][0]
        self.assertEqual([[2,3],[2,3]],op['native_positions']);self.assertEqual('UNKNOWN',op['tag_multiplier_binding'])

    def test_unknown_stat_name_is_raw_evidence_not_a_prediction(self):
        raw=fixture.envelope();raw['matchPayload']['ops']=[dict(type='STAT_CHANGE',data=dict(statType='FUTURE_STAT',newValue=0))]
        e=fixture.projected(raw).to_dict()['evidence']
        self.assertEqual('FUTURE_STAT',e['resource_operations'][0]['stat_type'])
        self.assertFalse(e['prospective_damage_model']);self.assertIn('NOT_A_PREDICTION',e['resource_operation_semantics'])

    def test_invalid_optional_data_fails_only_diagnostic_capture(self):
        operations=[dict(type='STAT_CHANGE',data=None),dict(type='STAT_CHANGE',data=dict(delta=True)),
            dict(type='STAT_CHANGE',data=dict(newValue='0')),dict(type='STAT_CHANGE',data=dict(targetUsername='')),
            dict(type='STAT_CHANGE',data=dict(reason='bad\nreason'))]
        for op in operations:
            raw=fixture.envelope();raw['matchPayload']['ops']=[op];result=fixture.projected(raw)
            with self.subTest(op=op):
                self.assertEqual('INVALID',result.status);self.assertIsNone(result.payload_json)

    def test_unverified_destroy_format_preserves_stats_and_combat_steps_as_unknown(self):
        for positions in ([[8,0]],[[True,0]],['0,1'],[[0,1]]*65,{'unknown':'shape'}):
            raw=message();raw['matchPayload']['ops'][2]['data']['positions']=positions
            record=fixture.projected(raw).to_dict();self.assertEqual('CAPTURED',record['status'])
            ops=record['evidence']['resource_operations'];self.assertEqual(5,ops[0]['delta'])
            self.assertIsNone(ops[1]['native_positions']);self.assertEqual('UNVERIFIED_FORMAT',ops[1]['positions_status'])
            self.assertEqual(3,len(record['evidence']['steps']));checked(record)

    def test_native_coordinate_prefix_never_infers_tag_or_multiplier_from_tail(self):
        raw=message();raw['matchPayload']['ops'][2]['data']['positions']=[[2,1,'unmodeled',7],[3,1,{'future':'unknown'}]]
        record=fixture.projected(raw).to_dict();op=record['evidence']['resource_operations'][1]
        self.assertEqual([[2,1],[3,1]],op['native_positions']);self.assertTrue(op['unmodeled_trailing_values'])
        self.assertEqual('UNKNOWN',op['tag_multiplier_binding']);self.assertEqual(4,op['position_shape']['first_arity'])
        checked(record)

    def test_trace_stays_inside_existing_capture_size_limit(self):
        raw=fixture.envelope();raw['matchPayload']['ops']=[dict(type='DESTROY',data=dict(positions=[[0,1]]*64)) for _ in range(128)]
        result=fixture.projected(raw)
        self.assertEqual(('INVALID','CAPTURE_SIZE_LIMIT'),(result.status,result.reason))
        self.assertIsNone(result.payload_json)

    def test_normalizer_round_trip_keeps_trace_but_grants_no_training_or_formula(self):
        record=fixture.projected(message()).to_dict();checked(record)
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as folder:
            path=Path(folder)/'combat.jsonl';path.write_text(json.dumps(dict(event='dispatcher_board_snapshot_offered',combatOutcome=record))+'\n',encoding='utf-8')
            case=extract(path)
        self.assertFalse(case['excluded']);self.assertEqual(1,len(case['observations']))
        obs=case['observations'][0]
        self.assertEqual(record['evidence']['resource_operations'],obs['resource_operations'])
        self.assertFalse(obs['training_eligible']);self.assertFalse(obs['input_authority']);self.assertIsNone(obs['prediction'])

    def test_normalizer_rejects_forged_identity_order_domain_or_semantics(self):
        for kind in ('target','order','positions','semantics'):
            record=fixture.projected(message()).to_dict();e=record['evidence'];ops=e['resource_operations']
            if kind=='target':ops[0]['target']='raw-username'
            elif kind=='order':ops[1]['operation_index']=ops[0]['operation_index']
            elif kind=='positions':ops[1]['position_order']='ROW_COL'
            else:e['resource_operation_semantics']='PREDICTED_FUTURE_RAGE'
            with self.subTest(kind=kind),self.assertRaises(ValueError):checked(record)

    def test_trace_does_not_change_reported_effect_totals(self):
        a=fixture.projected(message()).to_dict();b=fixture.projected().to_dict()
        self.assertEqual(observed_effect_totals(a),observed_effect_totals(b))

    def test_existing_tap_keeps_board_and_adds_no_memory_reads_for_valid_or_invalid_trace(self):
        for invalid in (False,True):
            tap_case=fixture.OutcomeTapTests();tap_case.setUp();raw=message()
            if invalid:raw['matchPayload']['ops'][0]['data']['delta']=True
            board=tap_case.capture(raw);record=tap_case.tap.combat_outcome_fields(board)['combatOutcome']
            with self.subTest(invalid=invalid):
                self.assertEqual(64,len(board.cells));self.assertEqual(0,tap_case.tap.diagnostics.raw_board_rejections)
                self.assertEqual([],tap_case.target.memory.mock_calls)
                self.assertEqual('INVALID' if invalid else 'CAPTURED',record['status'])


if __name__=='__main__':unittest.main()
