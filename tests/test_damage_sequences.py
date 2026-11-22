"""Optional raw crit evidence and shield/wave audit; all inputs are synthetic."""
from copy import deepcopy
import hashlib,json
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

from pokiguard_v2.combat_outcome_evidence import project_combat_outcome,_project_outcome_with_players
from pokiguard_v2.damage_operation_context import project_damage_operations,MAX_BYTES
from tests.test_response_player_context import raw_context
from tests.test_combat_outcome_evidence import projected
from tests import test_combat_outcome_evidence as tap_fixture
from tests import test_damage_dataset as dataset_fixture
from tests.reasoning_test_paths import reasoning_temp_root
from tools.prepare_demon_damage_dataset import build
from tools.audit_damage_sequences import audit,analyze
from tools.normalize_action_outcomes import extract


def raw(crit='ABSENT'):
    r=raw_context();data=dict(newHP=100,delta=-100)
    if crit!='ABSENT':data['crit']=crit
    r['matchPayload']['ops']=[dict(type='BOSS_HP',data=data),dict(type='STAT_CHANGE',data=dict(
        targetUsername='synthetic-player',statType='HP',delta=-1,newValue=99,crit=False))]
    return r


class OperationContextTests(unittest.TestCase):
    def test_true_false_null_absent_and_unverified_types_are_distinct(self):
        for value,presence,expected in (('ABSENT','ABSENT',None),(None,'NULL',None),(True,'BOOL',True),(False,'BOOL',False),('true','UNVERIFIED_TYPE',None),(1,'UNVERIFIED_TYPE',None)):
            r=raw(value);c=projected(r).to_dict()['damage_operations'];op=c['operations'][0]
            self.assertEqual(presence,op['crit_presence']);self.assertIs(expected,op['crit_value'])
            self.assertFalse(c['calibration_eligible']);self.assertFalse(c['input_authority'])
            self.assertEqual('UNKNOWN',c['step_attribution']);self.assertNotIn('crit_raw_type',op) if presence!='UNVERIFIED_TYPE' else None

    def test_raw_known_fields_only_actor_hashing_and_no_source_mutation(self):
        r=raw(True);r['matchPayload']['ops'][0]['data'].update(unknown='private',sourceUsername='private-user')
        before=deepcopy(r);c=projected(r).to_dict()['damage_operations']
        self.assertEqual(before,r);self.assertNotIn('private',json.dumps(c));self.assertNotIn('synthetic-player',json.dumps(c))
        self.assertEqual(dict(delta=-100,newHP=100),c['operations'][0]['fields'])
        self.assertTrue(c['operations'][1]['fields']['target_identity'].startswith('sha256:'))

    def test_response_identity_fences_and_absent_ops_do_not_create_metadata(self):
        r=raw();args=dict(expected_match_id=r['matchId'],expected_sequence=9,raw_sha256='a'*64)
        for changed in (dict(expected_match_id='OTHER'),dict(expected_sequence=True),dict(expected_sequence=8),dict(raw_sha256='bad')):
            a=dict(args);a.update(changed);self.assertIsNone(project_damage_operations(r,**a))
        for ops in (None,[],[dict(type='SOME_UI_OP',data={})]):
            r['matchPayload']['ops']=ops;self.assertIsNone(project_damage_operations(r,**args))

    def test_unavailable_stays_without_effects_and_rejected_response_gets_no_metadata(self):
        r=raw(True);r['matchPayload'].pop('combatSteps');c=projected(r).to_dict()
        self.assertEqual('UNAVAILABLE',c['status']);self.assertIsNone(c['evidence']);self.assertEqual('BOOL',c['damage_operations']['operations'][0]['crit_presence'])
        r=raw(True);r['matchPayload']['success']=False;c=projected(r).to_dict()
        self.assertEqual('REJECTED',c['status']);self.assertNotIn('damage_operations',c)

    def test_optional_invalid_numeric_or_unknown_crit_type_cannot_reject_effects(self):
        for v in (True,'100',2**40):
            r=raw();r['matchPayload']['ops'][0]['data']['newHP']=v
            c=projected(r).to_dict();self.assertEqual('CAPTURED',c['status']);self.assertEqual('INVALID',c['damage_operations']['status'])
        r=raw();r['matchPayload']['ops'][0]['data']['crit']={'private':'value'}
        c=projected(r).to_dict();self.assertEqual('CAPTURED',c['status']);self.assertEqual('UNVERIFIED_TYPE',c['damage_operations']['operations'][0]['crit_presence'])
        self.assertNotIn('private',json.dumps(c['damage_operations']))

    def test_metadata_limits_and_combined_budget_do_not_evict_effects_or_player_context(self):
        r=raw();r['matchPayload']['ops']=[dict(type='BOSS_HP',data={}) for _ in range(33)]
        c=projected(r).to_dict();self.assertEqual('OMITTED',c['damage_operations']['status']);self.assertFalse(c['damage_operations']['operations'])
        self.assertLessEqual(len(json.dumps(c['damage_operations']).encode()),MAX_BYTES)
        r=raw(True);args=dict(expected_match_id=r['matchId'],expected_sequence=9,raw_sha256=hashlib.sha256(json.dumps(r).encode()).hexdigest())
        base=_project_outcome_with_players(r,**args);limit=len(base.payload_json.encode())+len(base.player_context_json.encode())
        with patch('pokiguard_v2.combat_outcome_evidence.MAX_CAPTURE_BYTES',limit):
            c=project_combat_outcome(r,**args).to_dict()
        self.assertEqual(base.to_dict(),c)

    def test_fault_is_bounded_and_does_not_disclose_exception_text_or_change_old_capture(self):
        r=raw();base=projected(r).to_dict()
        with patch('pokiguard_v2.damage_operation_context.project_damage_operations',side_effect=RuntimeError('private-sensitive')):
            c=projected(r).to_dict()
        self.assertEqual('CAPTURED',c['status']);self.assertEqual('INVALID',c['damage_operations']['status'])
        self.assertEqual('OPTIONAL_PROJECTION_RuntimeError',c['damage_operations']['reason']);self.assertNotIn('private-sensitive',json.dumps(c))
        self.assertEqual({k:v for k,v in base.items() if k!='damage_operations'},{k:v for k,v in c.items() if k!='damage_operations'})

    def test_all_three_response_types_and_board_export_add_no_target_queries(self):
        for event in ('MATCH_MOVE_RES','MATCH_CARD_USE_RES','MATCH_SKILL_USE_RES'):
            r=raw(True);r['type']=event;self.assertEqual('CAPTURED',projected(r).to_dict()['damage_operations']['status'])
        helper=tap_fixture.OutcomeTapTests();helper.setUp();snapshot=helper.capture(raw(True))
        c=helper.tap.combat_outcome_fields(snapshot)['combatOutcome'];self.assertEqual('CAPTURED',c['damage_operations']['status'])
        self.assertEqual([],helper.target.memory.mock_calls);self.assertEqual(64,len(snapshot.cells))


class DamageSequenceTests(unittest.TestCase):
    def run_rows(self,records,mutate=None):
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as d:
            p=Path(d)/'combat.jsonl';p.write_text('\n'.join(json.dumps(x) for x in records)+'\n',encoding='utf-8');original=p.read_bytes()
            case=dataset_fixture.manifest_case(p,records);manifest=dict(schema=dataset_fixture.MANIFEST_SCHEMA,cases=[case])
            sample=build(manifest)['samples'][0];obs=extract(p)['observations'][0]
            if mutate:mutate(sample,obs)
            result=analyze(sample,obs);self.assertEqual(original,p.read_bytes())
            return result

    def block_rows(self):
        a=dataset_fixture.rows(amount=80);e=a[2]['combatOutcome']['evidence'];actor=e['actor_identity']
        e['steps']=[dict(idx=0,kind='BLOCK',amount=20,source=actor,target='BOSS',after={'SHIELD':10},damage_source=None,full_power=None,steal_type=None),
            dict(idx=1,kind='BLOCK',amount=10,source=actor,target='BOSS',after={'SHIELD':0},damage_source=None,full_power=None,steal_type=None),
            dict(idx=2,kind='DAMAGE',amount=80,source=actor,target='BOSS',after={'HP':1920},damage_source=None,full_power=True,steal_type=None)]
        a[1]['boss']['shield']=30
        e['resource_operations']=[dict(type='STAT_CHANGE',operation_index=i,target='BOSS',stat_type='SHIELD',delta=-amount,new_value=end,reason=None,source_label='BLOCK') for i,amount,end in ((5,20,10),(7,10,0))]
        e['resource_operation_source']='matchPayload.ops[].data';e['resource_operation_semantics']='RAW_ORDERED_OBSERVATION_NOT_A_PREDICTION'
        return a

    def test_shield_ledger_and_numeric_pair_do_not_rewrite_training_target(self):
        r=self.run_rows(self.block_rows())
        self.assertEqual([30,10],[x['before'] for x in r['shield_raw_ledger']]);self.assertTrue(r['aligned_order_consistent'])
        self.assertEqual(90,r['damage_components'][0]['arithmetic_hp_plus_adjacent_block'])
        self.assertEqual('ADJACENCY_ONLY_NOT_A_VERIFIED_ATTACK_COMPONENT_PAIR',r['damage_components'][0]['attribution_status'])
        self.assertFalse(r['training_target_rewritten']);self.assertFalse(r['before_action_features_added'])

    def test_repeated_signatures_missing_operations_and_mixed_source_never_force_alignment(self):
        a=self.block_rows();e=a[2]['combatOutcome']['evidence'];duplicate=deepcopy(e['resource_operations'][1]);duplicate['operation_index']=9;e['resource_operations'].append(duplicate)
        r=self.run_rows(a);self.assertFalse(r['aligned_order_consistent']);self.assertEqual('AMBIGUOUS_OR_MISSING',r['block_stat_alignments'][1]['status'])
        a=self.block_rows();a[2]['combatOutcome']['evidence']['resource_operations']=None
        r=self.run_rows(a);self.assertFalse(r['aligned_order_consistent'])
        a=self.block_rows();a[2]['combatOutcome']['evidence']['steps'][1]['source']='BOSS'
        r=self.run_rows(a);self.assertIsNone(r['damage_components'][0]['adjacent_block_amount'])

    def test_multiple_destroy_operations_and_tag_mismatch_stay_post_response_only(self):
        a=self.block_rows();e=a[2]['combatOutcome']['evidence'];e['resource_operations']=[]
        for i in range(3):e['resource_operations'].append(dict(type='DESTROY',operation_index=i,native_positions=[[1,2]],position_order='COL_ROW',tag_multiplier_binding='UNKNOWN'))
        e['destroyed_by_tag']={'vang Dot':99}
        r=self.run_rows(a);self.assertTrue(r['multiple_destroy_operations_observed']);self.assertEqual(3,len(r['destroy_operations']))
        self.assertEqual('DIFFERS_FROM_FIRST_WAVE',r['tag_comparison']);self.assertFalse(r['before_action_features_added'])

    def test_adjacent_wrong_target_gap_and_hash_mismatch_do_not_create_damage_pair(self):
        a=self.block_rows();a[2]['combatOutcome']['evidence']['steps'][1]['idx']=2;a[2]['combatOutcome']['evidence']['steps'][2]['idx']=4
        self.assertIsNone(self.run_rows(a)['damage_components'][0]['adjacent_block_amount'])
        with self.assertRaisesRegex(ValueError,'RAW_HASH'):
            self.run_rows(self.block_rows(),lambda s,o:o['provenance'].update(raw_response_sha256='f'*64))


if __name__=='__main__':unittest.main()
