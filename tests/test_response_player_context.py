"""Exact response context remains distinct from pre-action/effect-time state."""
from copy import deepcopy
import hashlib
import json
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

from pokiguard_v2.combat_outcome_evidence import observed_effect_totals, project_combat_outcome
from pokiguard_v2.combat_player_context import (MAX_CONTEXT_BYTES, SCOPE, actor_identity,
    encoded, project_player_context, validate_player_context)
from tests.reasoning_test_paths import reasoning_temp_root
from tests.test_combat_outcome_evidence import envelope, projected
from tests import test_combat_outcome_evidence as tap_fixture
from tests.test_action_outcome_normalization import fixture
from tools.bind_response_player_context import bind_file, summarize
from tools.normalize_action_outcomes import extract


def raw_context(event='MATCH_MOVE_RES'):
    raw = envelope(event)
    raw['matchPayload']['players'] = {
        'synthetic-player': dict(username='synthetic-player', actorNumber=1, petId=560,
            petElementType='METAL', petLevel=12, attack=1819, weaknessVsBoss=1.75,
            equipCounterPct=[25]*5, avatarId=101, fusionUsedSuccess=False),
        '__BOSS__': dict(actorNumber=99, petId=1845, petElementType='DARK', hp=5000)}
    return raw


def context(raw):
    return project_player_context(raw, expected_match_id=raw['matchId'],
        expected_sequence=raw['matchPayload']['srvSeq'],
        raw_sha256=hashlib.sha256(json.dumps(raw).encode()).hexdigest())


class ContextProjectionTests(unittest.TestCase):
    def test_exact_raw_fields_identity_privacy_and_no_pre_action_claim(self):
        raw = raw_context(); original = deepcopy(raw)
        raw['matchPayload']['players']['synthetic-player'].update(displayName='private-label', userId=123,
            avatarLayers='private-layers', arbitrary_unknown='x'*10000)
        record = projected(raw).to_dict(); c = record['player_context']
        validate_player_context(c, **{k:record['evidence'][k] for k in
            ('match_id','server_sequence','event_type','raw_sha256')})
        self.assertEqual('players', c['payload_key'])
        self.assertEqual('REPLACE_DICTIONARY', c['client_mode'])
        self.assertEqual(SCOPE, c['scope'])
        own = next(p for p in c['players'] if p['actor_identity']==actor_identity('synthetic-player'))
        self.assertEqual(1819, own['fields']['attack'])
        self.assertEqual(1.75, own['fields']['weaknessVsBoss'])
        self.assertEqual([25]*5, own['fields']['equipCounterPct'])
        self.assertNotIn('hpMax', own['fields'])
        for value in ('synthetic-player','private-label','private-layers','userId','arbitrary_unknown'):
            self.assertNotIn(value, encoded(c))
        self.assertEqual(original['matchPayload']['combatSteps'], raw['matchPayload']['combatSteps'])
        self.assertFalse(c['calibration_eligible']);self.assertFalse(c['input_authority'])

    def test_delta_is_not_merged_and_non_null_full_mapping_has_client_precedence(self):
        raw = raw_context(); players = raw['matchPayload'].pop('players')
        raw['matchPayload']['playersStateDelta'] = {'synthetic-player': {'mana':0}}
        c = context(raw)
        self.assertEqual('playersStateDelta', c['payload_key'])
        self.assertEqual({'mana':0}, c['players'][0]['fields'])
        self.assertEqual('MERGE_PLAYER_DELTA', c['client_mode'])
        raw['matchPayload']['players'] = None
        self.assertEqual(c['players'], context(raw)['players'])
        raw['matchPayload']['players'] = {}
        self.assertEqual([], context(raw)['players'])
        self.assertEqual('EMPTY_MAPPING_NOT_ZERO_PARTICIPANTS', context(raw)['reason'])
        raw['matchPayload']['players'] = players
        self.assertEqual('players', context(raw)['payload_key'])
        raw['matchPayload']['players'] = []
        self.assertEqual('INVALID', context(raw)['status'])

    def test_missing_null_zero_and_false_remain_distinct(self):
        raw = raw_context()
        raw['matchPayload']['players']={'synthetic-player':dict(attack=0,petId=None,petElementType='',fusionUsedSuccess=False)}
        c = context(raw); fields = c['players'][0]['fields']
        self.assertEqual(dict(attack=0,petId=None,petElementType='',fusionUsedSuccess=False),fields)
        self.assertNotIn('avatarId',fields)
        self.assertEqual(c,validate_player_context(c,match_id=c['match_id'],server_sequence=c['server_sequence'],event_type=c['event_type'],raw_sha256=c['raw_sha256']))

    def test_no_players_or_wrong_match_sequence_or_hash_has_no_context(self):
        raw = envelope();self.assertIsNone(context(raw))
        raw=raw_context()
        for change in (dict(expected_match_id='OTHER'),dict(expected_sequence=True),dict(expected_sequence=11),dict(raw_sha256='bad')):
            args=dict(expected_match_id=raw['matchId'],expected_sequence=9,raw_sha256='a'*64);args.update(change)
            self.assertIsNone(project_player_context(raw,**args))

    def test_malformed_fields_or_limits_do_not_change_effects_or_board_disposition(self):
        for player in (dict(attack=True),dict(attack='1819'),dict(weaknessVsBoss=float('nan')),
                       dict(equipCounterPct=[1]*17),dict(fusionUsedSuccess=1),dict(username='someone-else')):
            raw=raw_context();raw['matchPayload']['players']={'synthetic-player':player}
            actual=projected(raw).to_dict();self.assertEqual('CAPTURED',actual['status'])
            self.assertEqual('INVALID',actual['player_context']['status'])
            expected=deepcopy(raw);expected['matchPayload'].pop('players')
            self.assertEqual(observed_effect_totals(projected(expected).to_dict()),observed_effect_totals(actual))
        raw=raw_context();raw['matchPayload']['players']={str(i):{} for i in range(17)}
        self.assertEqual('INVALID',context(raw)['status'])

    def test_context_and_combined_budgets_preserve_existing_effects_and_presence(self):
        raw=raw_context();base=deepcopy(raw);base['matchPayload'].pop('players')
        previous=projected(base).to_dict();size=len(encoded(previous['evidence']).encode())
        with patch('pokiguard_v2.combat_outcome_evidence.MAX_CAPTURE_BYTES',size):
            capped=projected(raw).to_dict()
        self.assertEqual(previous['evidence']['steps'],capped['evidence']['steps'])
        self.assertNotIn('player_context',capped)
        self.assertEqual('CAPTURED',capped['status'])
        raw['matchPayload']['players']={str(i):dict(petElementType='x'*64,weaponRarity='z'*64,equipCounterPct=[123456789]*16,
            attack=1819,petLevel=12,petId=560,weaknessVsBoss=1.75) for i in range(16)}
        c=context(raw);self.assertEqual('OMITTED',c['status']);self.assertFalse(c['players'])
        self.assertLessEqual(len(encoded(c).encode()),MAX_CONTEXT_BYTES)

    def test_unavailable_context_stays_without_effects_and_rejection_grants_nothing(self):
        raw=raw_context();raw['matchPayload'].pop('combatSteps')
        capture=projected(raw).to_dict()
        self.assertEqual('UNAVAILABLE',capture['status']);self.assertIsNone(capture['evidence'])
        self.assertIn('player_context',capture);self.assertFalse(capture['response_identity']['effect_evidence'])
        raw['matchPayload']['success']=False
        self.assertNotIn('player_context',projected(raw).to_dict())

    def test_context_projection_fault_is_bounded_and_cannot_fail_legacy_capture(self):
        with patch('pokiguard_v2.combat_player_context.project_player_context',side_effect=RuntimeError('secret detail')):
            record=projected(raw_context()).to_dict()
        self.assertEqual('CAPTURED',record['status'])
        self.assertEqual('CONTEXT_RuntimeError',record['rejection_diagnostics']['player_context_error'])
        self.assertNotIn('secret',json.dumps(record))

    def test_same_board_instance_export_adds_no_target_memory_queries(self):
        helper=tap_fixture.OutcomeTapTests();helper.setUp()
        snapshot=helper.capture(raw_context())
        c=helper.tap.combat_outcome_fields(snapshot)['combatOutcome']
        self.assertEqual('CAPTURED',c['player_context']['status'])
        self.assertEqual([],helper.target.memory.mock_calls)
        self.assertEqual(64,len(snapshot.cells));self.assertEqual(0,helper.tap.diagnostics.raw_board_rejections)


class ContextBindingTests(unittest.TestCase):
    def rows(self,*,ack=True,steps=True):
        sent,_=fixture();who=sent['identity']['source']['current_turn_player']
        raw=raw_context();raw['matchId']=sent['matchId']
        raw['matchPayload']['srvSeq']=sent['identity']['source']['srv_seq']+2
        raw['matchPayload']['actorUsername']=who
        raw['matchPayload']['players'][who]=raw['matchPayload']['players'].pop('synthetic-player')
        raw['matchPayload']['players'][who]['username']=who
        for s in raw['matchPayload']['combatSteps']:
            for field in ('source','target'):
                if s[field]=='synthetic-player':s[field]=who
        if not steps:raw['matchPayload'].pop('combatSteps')
        capture=project_combat_outcome(raw,expected_match_id=raw['matchId'],expected_sequence=raw['matchPayload']['srvSeq'],
            raw_sha256=hashlib.sha256(json.dumps(raw).encode()).hexdigest()).to_dict()
        rows=[sent,dict(event='dispatcher_combat_outcome',combatOutcome=capture)]
        if ack:rows.append(dict(event='action_result',result='SWAP_ACKNOWLEDGED',action=dict(identity=sent['identity'])))
        return rows

    def run_rows(self,rows):
        original=deepcopy(rows)
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as folder:
            path=Path(folder)/'combat.jsonl'
            raw=('\n'+'\n'.join(json.dumps(r) for r in rows)+'\n').encode();path.write_bytes(raw)
            result=bind_file(path);normal=extract(path)
            self.assertEqual(raw,path.read_bytes())
        self.assertEqual(original,rows)
        return result,normal

    def test_exact_response_and_ack_bind_but_never_supply_pre_action_or_effect_time_state(self):
        rows=self.rows();result,normal=self.run_rows(rows);self.assertFalse(result['excluded'])
        b=result['context_bindings'][0]
        self.assertEqual('EXACT_SWAP_SENT_ACK',b['action_binding']['status'])
        self.assertEqual(normal['observations'][0]['action_binding'],b['action_binding'])
        self.assertEqual(560,b['response_actor_context']['fields']['petId'])
        self.assertTrue(any(p['actor_identity']=='BOSS' for p in b['response_target_context']))
        self.assertIsNone(b['pre_action_context']);self.assertIsNone(b['effect_time_context'])
        self.assertFalse(b['calibration_eligible']);self.assertIsNone(b['prediction'])
        totals=summarize([result,deepcopy(result)]);self.assertEqual(1,totals['unique_response_contexts'])

    def test_unavailable_or_no_ack_context_is_not_promoted_to_an_acknowledged_move(self):
        for options,expected in ((dict(ack=False),'SENT_WITHOUT_EXACT_ACK'),(dict(steps=False),'UNBOUND')):
            result,_=self.run_rows(self.rows(**options));b=result['context_bindings'][0]
            self.assertEqual(expected,b['action_binding']['status']);self.assertFalse(b['action_binding']['acknowledged'])

    def test_wrong_hash_sequence_actor_shape_or_scope_is_quarantined_without_losing_effects(self):
        for mutate in (lambda c:c.update(raw_sha256='f'*64),lambda c:c.update(server_sequence=1),
                       lambda c:c.update(scope='PRE_ACTION'),lambda c:c['players'][0].update(actor_identity='raw-name')):
            rows=self.rows();mutate(rows[1]['combatOutcome']['player_context'])
            result,normal=self.run_rows(rows)
            self.assertFalse(result['context_bindings']);self.assertTrue(result['excluded'])
            self.assertEqual(1,len(normal['observations']))

    def test_duplicate_missing_context_does_not_conflict_but_two_captured_views_do(self):
        rows=self.rows();duplicate=deepcopy(rows[1]);duplicate['combatOutcome'].pop('player_context')
        result,normal=self.run_rows(rows+[duplicate]);self.assertEqual(1,len(result['context_bindings']))
        self.assertEqual(1,len(normal['observations']))
        duplicate=deepcopy(rows[1]);duplicate['combatOutcome']['player_context']['players'][0]['fields']['petId']=999
        result,normal=self.run_rows(rows+[duplicate]);self.assertFalse(result['context_bindings'])
        self.assertEqual('CONFLICTING_RESPONSE_CONTEXT',result['excluded'][0]['reason'])
        self.assertEqual(1,len(normal['observations']))

    def test_legacy_or_initial_probe_record_does_not_get_carried_into_later_moves(self):
        rows=self.rows();rows[1]['combatOutcome'].pop('player_context')
        rows.insert(0,dict(runtime_context=dict(pet_id=560,match_id=rows[0]['matchId'])))
        result,normal=self.run_rows(rows)
        self.assertFalse(result['context_bindings']);self.assertEqual(1,len(normal['observations']))

    def test_two_responses_in_one_input_window_do_not_invent_a_unique_action_context(self):
        rows=self.rows();second=deepcopy(rows[1]);c=second['combatOutcome'];c['evidence']['server_sequence']+=2
        c['player_context']['server_sequence']+=2
        result,_=self.run_rows(rows+[second])
        self.assertEqual(2,len(result['context_bindings']))
        self.assertTrue(all(b['action_binding']['status']=='UNBOUND' for b in result['context_bindings']))


if __name__=='__main__':unittest.main()
