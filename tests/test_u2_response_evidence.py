"""U2 evidence-only projections: same JSON, ordered, bounded, never evicting old evidence."""
import json
from pathlib import Path
import unittest

from pokiguard_v2.combat_outcome_evidence import MAX_CAPTURE_BYTES, project_combat_outcome
from pokiguard_v2.board_operation_context import project_board_operations
from pokiguard_v2.response_player_extras import FIELDS, project_player_extras

RAW = 'a' * 64


def envelope(ops=None, players=None):
    payload = dict(srvSeq=7, actorUsername='me', combatSteps=[dict(idx=0, kind='DAMAGE', amount=5,
        source='me', target='__BOSS__')])
    if ops is not None: payload['ops'] = ops
    if players is not None: payload['playersStateDelta'] = players
    return dict(type='MATCH_MOVE_RES', matchId='M_1', matchPayload=payload)


OPS = [dict(type='SWAP', data=dict(fromRow=1, fromCol=2, toRow=1, toCol=3)),
       dict(type='DESTROY', data=dict(positions=[[2, 1], [3, 1], [4, 1]])),
       dict(type='STAT_CHANGE', data=dict(targetUsername='me', statType='MANA', delta=30, newValue=30)),
       dict(type='FALL', data=dict(col=2, fromRow=2, toRow=1)),
       dict(type='SPAWN', data=dict(col=2, row=7, tag='Sword', multiplier=2)),
       dict(type='SPAWN', data=dict(col=3, row=7, tag='Mana'))]


class U2ResponseEvidenceTests(unittest.TestCase):
    def test_board_operations_keep_wire_order_and_absence(self):
        record = project_board_operations(envelope(OPS), expected_match_id='M_1', expected_sequence=7, raw_sha256=RAW)
        self.assertEqual('CAPTURED', record['status'])
        self.assertEqual([0, 1, 3, 4, 5], [o['operation_index'] for o in record['operations']])
        self.assertEqual(['SWAP', 'DESTROY', 'FALL', 'SPAWN', 'SPAWN'], [o['type'] for o in record['operations']])
        self.assertEqual(2, record['operations'][3]['multiplier'])
        self.assertNotIn('multiplier', record['operations'][4])  # client default 1 is not replayed
        self.assertFalse(record['input_authority'])

    def test_bad_operation_marks_only_this_record_invalid(self):
        bad = OPS + [dict(type='SPAWN', data=dict(col=9, row=7, tag='Sword'))]
        record = project_board_operations(envelope(bad), expected_match_id='M_1', expected_sequence=7, raw_sha256=RAW)
        self.assertEqual(('INVALID', []), (record['status'], record['operations']))

    def test_operation_limit_is_omitted_not_truncated(self):
        fall = dict(type='FALL', data=dict(col=0, fromRow=1, toRow=0))
        big_boss_turn = project_board_operations(envelope([fall] * 168), expected_match_id='M_1',
            expected_sequence=7, raw_sha256=RAW)
        self.assertEqual(('CAPTURED', 168), (big_boss_turn['status'], len(big_boss_turn['operations'])))
        record = project_board_operations(envelope([fall] * 257), expected_match_id='M_1', expected_sequence=7,
            raw_sha256=RAW)
        self.assertEqual(('OMITTED', [], 256), (record['status'], record['operations'], record['operation_limit']))

    def test_player_extras_list_absent_fields(self):
        players = {'me': dict(hp=10, skillCooldownLeft=2, cardCooldownLeft={'7': 1}, dotDropPct=[10, 20],
            luckyDotTag='Sword', level=14)}
        record = project_player_extras(envelope(players=players), expected_match_id='M_1', expected_sequence=7,
            raw_sha256=RAW)
        player = record['players'][0]
        self.assertEqual(dict(skillCooldownLeft=2, cardCooldownLeft={'7': 1}, dotDropPct=[10, 20],
            luckyDotTag='Sword', level=14), player['fields'])
        self.assertEqual(sorted(set(FIELDS) - set(player['fields'])), sorted(player['absent']))
        self.assertTrue(player['actor_identity'].startswith('sha256:'))

    def test_bad_extra_field_marks_only_extras_invalid(self):
        players = {'me': dict(hp=10, hpMax=20, skillStacks='bad')}
        record = project_player_extras(envelope(players=players), expected_match_id='M_1', expected_sequence=7,
            raw_sha256=RAW)
        self.assertEqual(('INVALID', []), (record['status'], record['players']))

    def test_wired_extras_never_evict_or_change_prior_evidence(self):
        players = {'me': dict(hp=10, hpMax=20, skillCooldownLeft=1)}
        good = project_combat_outcome(envelope(OPS, players), expected_match_id='M_1', expected_sequence=7,
            raw_sha256=RAW).to_dict()
        bad_ops = OPS + [dict(type='SPAWN', data=dict(col=9, row=7, tag='Sword'))]
        bad = project_combat_outcome(envelope(bad_ops, {'me': dict(hp=10, hpMax=20, skillStacks='bad')}),
            expected_match_id='M_1', expected_sequence=7, raw_sha256=RAW).to_dict()
        self.assertEqual('CAPTURED', good['board_operations']['status'])
        self.assertEqual('CAPTURED', good['player_extras']['status'])
        self.assertEqual(('INVALID', 'INVALID'), (bad['board_operations']['status'], bad['player_extras']['status']))
        self.assertEqual('CAPTURED', bad['status'])
        self.assertEqual('CAPTURED', bad['player_context']['status'])
        self.assertEqual(good['evidence']['steps'], bad['evidence']['steps'])
        self.assertLessEqual(len(json.dumps(good['evidence']).encode()), MAX_CAPTURE_BYTES)

    def test_boss_identity_fact_is_pinned_target_or_unknown(self):
        from pokiguard_v2.reasoning_common_evidence import boss_identity_fact
        good = dict(pet_id=2321, name='No. 11', island=None, level=None, source='PINNED_FARM_TARGET_CONFIG')
        self.assertEqual(good, boss_identity_fact(good))
        unknown = boss_identity_fact(None)
        self.assertEqual(('UNKNOWN_NOT_PROVIDED', None), (unknown['source'], unknown['pet_id']))
        for bad in (dict(good, pet_id='2321'), dict(good, level=-1), dict(good, extra=1), dict(good, name='')):
            self.assertEqual(unknown, boss_identity_fact(bad))

    def test_boss_identity_is_an_allowed_admission_model_only(self):
        source = Path(__file__).resolve().parents[1] / 'src/pokiguard_v2/reasoning_common_selection.py'
        text = source.read_text(encoding='utf-8')
        self.assertIn("'demon_damage_model','boss_identity'", text)
        planner = (source.parent / 'reasoning_common_planner.py').read_text(encoding='utf-8')
        tactics = (source.parent / 'reasoning_common_tactics.py').read_text(encoding='utf-8')
        self.assertNotIn('boss_identity', planner + tactics)

if __name__ == '__main__':
    unittest.main()
