"""An unrelated bounded diagnostic gap must not erase earlier boss intervals."""
from copy import deepcopy
import json
from pathlib import Path
import tempfile
import unittest

from pokiguard_v2.combat_board_evidence import retained_board_fields
from pokiguard_v2.combat_outcome_evidence import SCHEMA
from tests.reasoning_test_paths import reasoning_temp_root
from tests.test_combat_board_evidence import boundary_rows, cells
from tools.audit_resource_balances import audit
from tools.normalize_boss_transitions import extract


def rejected_offer(sequence=10):
    fields=retained_board_fields(cells(),match_id='M_SYNTHETIC',lifecycle_epoch=1,
        sequence=sequence,source='TRANSPORT_BOARD',accepted=True)
    return dict(event='dispatcher_board_snapshot_offered',eventType='MATCH_MOVE_RES',
        accepted=True,completeCells=64,matchId='M_SYNTHETIC',lifecycleEpoch=1,srvSeq=sequence,
        **fields,combatOutcome=dict(schema=SCHEMA,status='INVALID',reason='OPERATION_SHAPE_OR_LIMIT',
            evidence=None,input_authority=False,damage_prediction=False,
            post_board_hash=fields['boardEvidence']['board_hash']))


class ExclusionScopeTests(unittest.TestCase):
    def run_rows(self, rows, consumer=extract):
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as directory:
            path=Path(directory)/'combat.jsonl'
            path.write_bytes(('\n'.join(json.dumps(r) if type(r) is dict else r for r in rows)+'\n').encode())
            return consumer(path)

    def test_later_or_earlier_verified_sequence_does_not_poison_interval(self):
        for rows in (boundary_rows()+[rejected_offer()], [rejected_offer(7)]+boundary_rows()):
            case=self.run_rows(rows)
            self.assertEqual(1,len(case['intervals']))
            self.assertEqual(1,len(case['outcome_exclusions']))
            self.assertEqual(0,case['unscoped_outcome_exclusions'])
            self.assertEqual([0],case['intervals'][0]['excluded_outcomes_proven_outside_interval'])
            self.assertFalse(case['intervals'][0]['training_eligible'])
            self.assertEqual('UNKNOWN',case['intervals'][0]['whole_action_completeness'])

    def test_in_range_sequence_blocks_even_if_drain_is_late(self):
        case=self.run_rows(boundary_rows()+[rejected_offer(9)])
        self.assertFalse(case['intervals'])
        self.assertEqual('INVALID_OR_LOCAL_INPUT_IN_BOSS_INTERVAL',case['unbound'][0]['reason'])

    def test_in_range_log_line_blocks_even_if_sequence_is_outside(self):
        rows=boundary_rows();rows.insert(1,rejected_offer())
        self.assertFalse(self.run_rows(rows)['intervals'])

    def test_unavailable_steps_keep_the_gap_but_not_unrelated_intervals(self):
        for sequence,expected in ((7,1),(9,0),(10,1)):
            row=rejected_offer(sequence)
            row['combatOutcome'].update(status='UNAVAILABLE',reason='COMBAT_STEPS_ABSENT')
            case=self.run_rows(boundary_rows()+[row])
            self.assertEqual(expected,len(case['intervals']))
            self.assertEqual(1,len(case['outcome_exclusions']))
            self.assertEqual(0,case['unscoped_outcome_exclusions'])
            self.assertEqual(sequence,case['outcome_exclusion_scopes'][0]['scope']['server_sequence'])
            self.assertEqual(1,len(case['intervals'])+len(case['unbound']))
        rows=boundary_rows();rows.insert(1,row)
        self.assertFalse(self.run_rows(rows)['intervals'])

    def test_unavailable_without_independent_board_scope_is_still_fail_closed(self):
        for mutate in ('drained','hash','accepted','missing_board','unknown_status'):
            row=rejected_offer()
            row['combatOutcome'].update(status='UNAVAILABLE',reason='COMBAT_STEPS_ABSENT')
            if mutate=='drained':row['event']='dispatcher_combat_outcome'
            if mutate=='hash':row['combatOutcome']['post_board_hash']='0'*64
            if mutate=='accepted':row['accepted']=False
            if mutate=='missing_board':row.pop('boardEvidence')
            if mutate=='unknown_status':row['combatOutcome']['status']='OTHER'
            with self.subTest(mutate=mutate):
                case=self.run_rows(boundary_rows()+[row])
                self.assertFalse(case['intervals'])
                self.assertEqual(1,case['unscoped_outcome_exclusions'])

    def test_missing_or_spoofed_scope_remains_fail_closed(self):
        variants=[]
        for key,value in (('accepted',False),('completeCells',True),('lifecycleEpoch',True),
                ('srvSeq',11),('matchId','M_OTHER'),('eventType','OTHER'),('event','dispatcher_combat_outcome')):
            row=rejected_offer();row[key]=value;variants.append(row)
        row=rejected_offer();row['combatOutcome']['post_board_hash']='0'*64;variants.append(row)
        row=json.loads(json.dumps(rejected_offer()));row['boardEvidence']['native_cells'][0][3]=999;variants.append(row)
        row=rejected_offer();row.pop('boardEvidence');variants.append(row)
        for row in variants:
            with self.subTest(row=row):
                case=self.run_rows(boundary_rows()+[row])
                self.assertFalse(case['intervals']);self.assertEqual(1,case['unscoped_outcome_exclusions'])

    def test_unknown_json_or_conflicting_duplicate_is_not_cleared_by_line_order(self):
        case=self.run_rows(boundary_rows()+['{invalid json'])
        self.assertFalse(case['intervals']);self.assertEqual(1,case['unscoped_outcome_exclusions'])
        rows=boundary_rows();other=deepcopy(rows[1])
        other['combatOutcome']['evidence']['steps'][0]['amount']+=1
        case=self.run_rows(rows+[other])
        self.assertFalse(case['intervals']);self.assertTrue(case['outcome_exclusions'])

    def test_resource_consumer_retains_gap_and_audits_only_valid_intervals(self):
        rows=boundary_rows()
        for row in (rows[0],rows[2]):
            state=row['stateEvidence']
            for actor in [state['player'],*state['bosses']]:
                actor.update(mana=10,max_mana=100,power=20,max_power=250)
            state['player'].update(is_local=True,is_boss=False)
            for actor in state['bosses']:actor.update(is_local=False,is_boss=True)
        report=self.run_rows(rows+[rejected_offer()],lambda path:audit([path]))
        self.assertEqual(1,report['summary']['boss_intervals'])
        self.assertEqual(1,len(report['capture_gaps']))
        self.assertEqual(0,report['summary']['training_eligible'])
        with self.assertRaisesRegex(ValueError,'INVALID_COMBAT_EVIDENCE'):
            self.run_rows(rows+['{invalid'],lambda path:audit([path]))


if __name__=='__main__':unittest.main()
