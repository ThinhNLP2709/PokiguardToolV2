"""Native pre-state replay, ordered effect semantics, and future-leak guards."""
from collections import Counter
from copy import deepcopy
import hashlib
import json
from pathlib import Path
import unittest

from pokiguard_v2.reasoning_common_problem import CommonProblem
from pokiguard_v2.reasoning_common_planner import plan_common
from pokiguard_v2.reasoning_skill_receipts import skill_receipt
from tools.prepare_icarus_core_evidence import pre_problem, sensitivity

FIXTURE = Path(__file__).parent/'fixtures/icarus_core_20261124/cases.json'


def fixture():
    return json.loads(FIXTURE.read_text(encoding='utf-8'))['cases']


def rehash(context):
    context.pop('context_sha256', None)
    context['context_sha256'] = hashlib.sha256(json.dumps(context, sort_keys=True,
        separators=(',', ':'),ensure_ascii=True).encode()).hexdigest()


def problem(case):
    return pre_problem(case['candidate'],case['pre_rows'],run_id='fixture_icarus',
        relative_path=case['source_reference']['combat_path'],file_sha256='a'*64)[0]


def receipt(case, association='CLIENT_CARD_WINDOW'):
    return skill_receipt(case['candidate']['context'],case['capture']['evidence'],
        association=association,response_players=case['capture'].get('player_context')).plain()


class IcarusCoreEvidenceTests(unittest.TestCase):
    def test_seven_real_inputs_roundtrip_existing_common_problem(self):
        for case in fixture():
            value=problem(case)
            self.assertEqual(value,CommonProblem.from_dict(value.to_dict()))
            self.assertEqual('pet_skill',value.baseline.family)
            self.assertEqual(30,len(value.effects[0].cleared))
            self.assertEqual((200,150),(value.effects[0].mana_cost,value.effects[0].rage_cost))
            self.assertIsNone(value.facts.plain()['skill_damage_model'])
            self.assertNotIn('observed_receipt',value.facts.plain())

    def test_common_planner_keeps_all_seven_incumbents_without_learning_from_win(self):
        for case in fixture():
            value=problem(case)
            choice=plan_common(value,clock=lambda:0)
            self.assertEqual(value.baseline,choice.proposal or choice.baseline)
            self.assertIn('INCOMPLETE',choice.reason)
            self.assertIsNone(value.facts.plain().get('win_label'))

    def test_future_damage_heal_refill_and_outcome_poison_leave_inputs_and_decision_exact(self):
        for case in fixture():
            before=problem(case)
            poisoned=deepcopy(case)
            poisoned['capture']['evidence']['steps'][0]['amount']=999999999
            poisoned['capture']['evidence']['steps'][-1]['amount']=1
            poisoned['capture']['player_context']['players'][0]['fields']['hp']=1
            poisoned['capture']['evidence']['refill']=[['sword',7]]*64
            poisoned['future_win_label']=False
            after=problem(poisoned)
            self.assertEqual(before.snapshot_id,after.snapshot_id)
            self.assertEqual(plan_common(before,clock=lambda:0),plan_common(after,clock=lambda:0))

    def test_changed_pre_board_card_context_and_cost_fail_instead_of_borrowing_future(self):
        for name in ('board','card','cost','owner','identity'):
            case=deepcopy(fixture()[0])
            if name=='board':
                case['pre_rows'][0][1]['stateEvidence']['board'][0][0]=['mana',1]
            elif name=='card':
                case['candidate']['context']['skill_card_id']=9999
                rehash(case['candidate']['context'])
            elif name=='cost':
                case['candidate']['context']['costs']['mana']=201
                rehash(case['candidate']['context'])
            elif name=='owner':
                case['pre_rows'][1][1]['trace']['skill_actionable']=False
            else:
                case['candidate']['context']['source']['turn']+=1
                rehash(case['candidate']['context'])
            with self.assertRaises(ValueError,msg=name):problem(case)

    def test_native_ordered_costs_caps_and_response_endpoints(self):
        counts=Counter()
        for case in fixture():
            r=receipt(case)
            self.assertTrue(all(x['status']=='EXACT_PRE_DESTROY_DEBIT' for x in r['cost_debits'].values()))
            self.assertTrue(all(x['status']=='EXACT' for x in r['response_endpoint_checks']))
            self.assertEqual(4,len(r['response_endpoint_checks']))
            self.assertEqual(1,len(r['full_power_operations']))
            self.assertEqual(-100,r['full_power_operations'][0]['reported_delta'])
            counts.update(x['status'] for x in r['resource_ledger']['entries'])
        self.assertEqual({'EXACT_RAW_ARITHMETIC':63,'CAP_PATTERN_OBSERVED':10},dict(counts))

    def test_heal_and_fusion_lifesteal_are_separate_and_neither_is_a_formula(self):
        for case in fixture():
            r=receipt(case)
            self.assertEqual(['HEAL','LIFESTEAL'],[x['kind'] for x in r['healing_components']])
            self.assertEqual(['FUSION_LIFESTEAL'],r['healing_components'][1]['operation_source_labels'])
            self.assertIsNone(r['healing_model'])
            self.assertIsNone(r['pure_skill_damage'])
            self.assertFalse(r['training_eligible'])

    def test_unbound_terminal_candidate_arithmetic_is_not_card_binding(self):
        r=receipt(fixture()[1],association='UNBOUND')
        self.assertEqual('UNBOUND',r['association'])
        self.assertEqual('UNBOUND_CANDIDATE_HYPOTHESIS',r['pre_to_response_arithmetic_scope'])
        self.assertEqual('UNKNOWN',r['wire_card_identity'])
        self.assertFalse(r['association_verified_by_module'])
        self.assertFalse(r['prospective_use'])

    def test_wire_card_scope_requires_explicit_matching_wire_id(self):
        with self.assertRaisesRegex(ValueError,'EXPLICIT_WIRE_CARD'):
            receipt(fixture()[0],association='WIRE_CARD_OBSERVED_WINDOW')

    def test_packet_and_response_context_mismatch_do_not_cross_sessions(self):
        for name in ('match','actor','sequence','players'):
            case=deepcopy(fixture()[0])
            if name=='match':case['capture']['evidence']['match_id']='other'
            elif name=='actor':case['capture']['evidence']['actor_identity']='BOSS'
            elif name=='sequence':case['capture']['evidence']['server_sequence']=0
            else:case['capture']['player_context']['raw_sha256']='a'*64
            with self.assertRaises(ValueError,msg=name):receipt(case)

    def test_boolean_delta_duplicate_operation_and_step_order_are_rejected(self):
        for name in ('bool','op','step'):
            case=deepcopy(fixture()[0])
            if name=='bool':case['capture']['evidence']['resource_operations'][0]['delta']=True
            elif name=='op':case['capture']['evidence']['resource_operations'][1]['operation_index']=0
            else:case['capture']['evidence']['steps'][1]['idx']=0
            with self.assertRaises(ValueError,msg=name):receipt(case)

    def test_missing_operation_stream_remains_unknown_not_zero_resources(self):
        case=deepcopy(fixture()[0]);case['capture']['evidence']['resource_operations']=None
        r=receipt(case)
        self.assertEqual('UNKNOWN',r['resource_ledger']['status'])
        self.assertTrue(all(x['status']=='UNKNOWN' for x in r['cost_debits'].values()))

    def test_reported_gain_clamped_to_cap_keeps_both_gross_and_net(self):
        r=receipt(fixture()[0])
        op=next(x for x in r['resource_ledger']['entries'] if x['stat']=='POWER' and x['reported_delta']==260)
        self.assertEqual(150,op['observed_delta'])
        self.assertEqual('CAP_PATTERN_OBSERVED',op['status'])
        self.assertNotEqual(op['observed_delta'],op['reported_delta'])

    def test_receipt_is_immutable_and_does_not_mutate_source(self):
        case=fixture()[0];original=deepcopy(case)
        r=skill_receipt(case['candidate']['context'],case['capture']['evidence'],association='CLIENT_CARD_WINDOW')
        altered=r.plain();altered['ordered_effects'][0]['amount']=0
        self.assertNotEqual(altered,r.plain())
        self.assertEqual(case,original)

    def test_unknown_lifesteal_source_is_not_assigned_to_icarus_or_fusion(self):
        case=deepcopy(fixture()[0])
        for op in case['capture']['evidence']['resource_operations']:
            op['source_label']=None
        result=receipt(case)
        self.assertEqual([],result['healing_components'][1]['operation_source_labels'])
        self.assertIsNone(result['healing_components'][1]['formula'])

    def test_cost_debit_after_destroy_is_not_attested_as_pre_skill_cost(self):
        case=deepcopy(fixture()[0])
        destroy=next(x for x in case['capture']['evidence']['resource_operations'] if x['type']=='DESTROY')
        destroy['operation_index']=-1
        operations=case['capture']['evidence']['resource_operations']
        case['capture']['evidence']['resource_operations']=sorted(operations,key=lambda x:x['operation_index'])
        # Invalid order/index does not create an alternative cost explanation.
        with self.assertRaises(ValueError):receipt(case)

    def test_missing_player_context_does_not_become_zero_hp_endpoint(self):
        case=fixture()[0]
        result=skill_receipt(case['candidate']['context'],case['capture']['evidence'],
                             association='CLIENT_CARD_WINDOW').plain()
        self.assertEqual([],result['response_endpoint_checks'])
        self.assertIsNone(result['effect_time_state'])

    def test_mismatching_stat_change_is_flagged_not_fitted_to_an_endpoint(self):
        case=deepcopy(fixture()[0])
        case['capture']['evidence']['resource_operations'][0]['new_value']=99
        r=receipt(case)
        self.assertEqual('MISMATCH_UNMODELED_OR_MISSING_CHANGES',r['resource_ledger']['entries'][0]['status'])
        self.assertEqual('UNKNOWN',r['cost_debits']['rage']['status'])
        self.assertIsNone(r['damage_model'])

    def test_trex_does_not_inherit_icarus_seal_or_healing_evidence(self):
        case=deepcopy(fixture()[0])
        case['candidate']['context'].update(family='MEGA_TREX_CLICK_ONLY',element_type='MEGA_TREX')
        rehash(case['candidate']['context'])
        with self.assertRaisesRegex(ValueError,'ICARUS_PRE_ACTION_CARD'):
            problem(case)

    def test_same_board_synthetic_pressure_changes_qualitative_heal_not_formula(self):
        rows={r['label']:r for r in sensitivity(problem(fixture()[0]))}
        low,full=rows['self_hp_25_percent'],rows['self_hp_full']
        self.assertAlmostEqual(.75,low['protection_proxy']['self_heal_opportunity'],delta=0.00001)
        self.assertEqual(0,full['protection_proxy']['self_heal_opportunity'])
        for row in rows.values():
            self.assertTrue(row['board_unchanged'])
            self.assertEqual('SYNTHETIC_SAME_BOARD_SENSITIVITY',row['origin'])
            self.assertIsNone(row['actual_game_outcome'])
            self.assertIsNone(row['damage_prediction'])

    def test_skill_not_modeled_when_either_actual_resource_is_insufficient(self):
        for case in fixture():
            rows={r['label']:r for r in sensitivity(problem(case))}
            for label in ('mana_below_cost','rage_below_cost'):
                self.assertEqual('UNKNOWN',rows[label]['effect_projection_status'])
                self.assertEqual('ACTUAL_ACTION_RESOURCES_INSUFFICIENT',rows[label]['effect_projection_reason'])
                self.assertFalse(rows[label]['action_authority'])


if __name__=='__main__':unittest.main()
