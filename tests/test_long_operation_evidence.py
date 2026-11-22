"""Long optional ops do not evict independent typed effects; no target process."""
from copy import deepcopy
import json,tempfile,unittest
from unittest.mock import patch
from pathlib import Path

from pokiguard_v2.combat_outcome_evidence import MAX_OPERATIONS,MAX_CAPTURE_BYTES,observed_effect_totals
from tests.test_combat_outcome_evidence import envelope,projected
from tests import test_combat_outcome_evidence as outcome_fixture
from tests.test_response_player_context import raw_context
from tests.reasoning_test_paths import reasoning_temp_root
from tools.normalize_action_outcomes import checked,extract

def long_raw(count=176):
    raw=raw_context()
    raw['matchPayload']['ops']=[dict(type='UNKNOWN_ANIMATION',data=dict(private='never persisted')) for _ in range(count)]
    raw['matchPayload']['ops'][0]=dict(type='SWAP',data=dict(fromRow=1,fromCol=1,toRow=1,toCol=2))
    raw['matchPayload']['ops'][-1]=dict(type='STAT_CHANGE',data=dict(statType='POWER',delta=5,newValue=200,crit=True))
    return raw

class LongOperationEvidenceTests(unittest.TestCase):
    def test_176_ops_keep_effects_identity_players_and_omit_all_operation_details(self):
        raw=long_raw();before=deepcopy(raw);record=projected(raw).to_dict()
        short=deepcopy(raw);short['matchPayload'].pop('ops');reference=projected(short).to_dict()
        self.assertEqual('CAPTURED',record['status'])
        self.assertEqual(reference['evidence']['steps'],record['evidence']['steps'])
        self.assertEqual(observed_effect_totals(reference),observed_effect_totals(record))
        e=record['evidence'];self.assertIsNone(e['swap_operations']);self.assertIsNone(e['resource_operations'])
        self.assertEqual(dict(status='OMITTED',reason='OPERATION_LIMIT',operation_count=176,operation_limit=128,complete=False),e['operation_projection'])
        self.assertEqual(('OMITTED','OPERATION_SCAN_LIMIT',[]),(record['damage_operations']['status'],record['damage_operations']['reason'],record['damage_operations']['operations']))
        self.assertEqual(176,record['damage_operations']['operation_count'])
        self.assertEqual('CAPTURED',record['player_context']['status'])
        self.assertEqual(before,raw);self.assertNotIn('never persisted',json.dumps(record));self.assertNotIn('crit_value',json.dumps(record))
        self.assertLessEqual(sum(len(json.dumps(record[k],sort_keys=True,separators=(',',':')).encode()) for k in ('evidence','player_context','damage_operations')),MAX_CAPTURE_BYTES)
        self.assertEqual(e,checked(record));self.assertFalse(e['prospective_damage_model']);self.assertFalse(record['input_authority'])

    def test_scan_limit_is_unchanged_and_no_prefix_or_tail_is_examined(self):
        self.assertEqual(128,MAX_OPERATIONS)
        raw=envelope();raw['matchPayload']['ops']=[dict(type='OTHER') for _ in range(MAX_OPERATIONS)]
        self.assertNotIn('operation_projection',projected(raw).to_dict()['evidence'])
        raw['matchPayload']['ops']=[None]*(MAX_OPERATIONS+1)
        # All operations are explicitly uninspected, rather than accepted as valid.
        r=projected(raw).to_dict();self.assertEqual('CAPTURED',r['status'])
        self.assertFalse(r['evidence']['operation_projection']['complete'])
        self.assertIsNone(r['evidence']['resource_operations'])

    def test_long_ops_do_not_relax_step_shape_byte_identity_or_rejection_fences(self):
        for mutate in (lambda r:r['matchPayload']['combatSteps'][0].update(amount=True),
                       lambda r:r.update(matchId='OTHER'),
                       lambda r:r['matchPayload'].update(srvSeq=8)):
            raw=long_raw();mutate(raw);self.assertEqual('INVALID',projected(raw).status)
        raw=long_raw();raw['matchPayload']['success']=False;self.assertEqual('REJECTED',projected(raw).status)
        raw=long_raw();raw['matchPayload']['combatSteps']=None;self.assertEqual('UNAVAILABLE',projected(raw).status)
        raw=long_raw();raw['matchPayload']['ops']={};self.assertEqual('INVALID',projected(raw).status)
        with patch('pokiguard_v2.combat_outcome_evidence.MAX_CAPTURE_BYTES',100):
            self.assertEqual('CAPTURE_SIZE_LIMIT',projected(long_raw()).reason)

    def test_omission_metadata_cannot_claim_partial_operations_or_relaxed_limits(self):
        record=projected(long_raw()).to_dict()
        for change in (dict(operation_limit=176),dict(operation_limit=128.0),dict(operation_count=True),dict(operation_count=128),dict(complete=True),dict(status='CAPTURED')):
            bad=deepcopy(record);bad['evidence']['operation_projection'].update(change)
            with self.assertRaisesRegex(ValueError,'OPERATION_OMISSION_PROVENANCE'):checked(bad)
        for field in ('resource_operations','swap_operations'):
            bad=deepcopy(record);bad['evidence'][field]=[]
            with self.assertRaisesRegex(ValueError,'OPERATION_OMISSION_PROVENANCE'):checked(bad)

    def test_export_normalization_retains_omission_provenance_and_typed_steps(self):
        record=projected(long_raw()).to_dict()
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as d:
            p=Path(d)/'combat.jsonl';p.write_text(json.dumps(dict(event='dispatcher_combat_outcome',combatOutcome=record))+'\n',encoding='utf-8')
            result=extract(p)
        self.assertFalse(result['excluded']);self.assertEqual(1,len(result['observations']))
        o=result['observations'][0];self.assertEqual(record['evidence']['operation_projection'],o['operation_projection'])
        self.assertIn('OPTIONAL_OPERATIONS_OMITTED_LIMIT',o['observation_limits'])
        self.assertEqual(record['evidence']['steps'],o['steps']);self.assertFalse(o['training_eligible']);self.assertFalse(o['input_authority'])

    def test_board_export_for_all_response_families_adds_no_memory_reads(self):
        for event in ('MATCH_MOVE_RES','MATCH_CARD_USE_RES','MATCH_SKILL_USE_RES'):
            raw=long_raw();raw['type']=event;helper=outcome_fixture.OutcomeTapTests();helper.setUp();snapshot=helper.capture(raw)
            record=helper.tap.combat_outcome_fields(snapshot)['combatOutcome']
            self.assertEqual('CAPTURED',record['status']);self.assertEqual(64,len(snapshot.cells))
            self.assertEqual([],helper.target.memory.mock_calls);self.assertEqual(0,helper.tap.diagnostics.raw_board_rejections)

if __name__=='__main__':unittest.main()
