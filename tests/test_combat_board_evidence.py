"""Actual source-state boundaries are required; no inferred boss before-board."""
from copy import deepcopy
from dataclasses import replace
import json
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

from pokiguard_v2.combat_board_evidence import PublishedStateRecorder, retained_board_fields
from pokiguard_v2.combat_lifecycle import CombatLifecycleState
from pokiguard_v2.il2cpp_layout import BoardCellSnapshot
from pokiguard_v2.live_state import board_state_hash, to_board_state
from pokiguard_v2.state import BattleState, CombatSessionKey, GamePhase, GameState, ParticipantState
from tests.reasoning_test_paths import reasoning_temp_root
from tests.test_combat_outcome_evidence import envelope, projected
from tools.normalize_boss_transitions import checked_retained, checked_state, extract, summarize


def cells():
    tags = ('vang Dot', 'xanhduong Dot', 'do Dot', 'tim Dot', 'xanh Dot', 'trang Dot')
    return tuple(BoardCellSnapshot(0, c, r, 0, tags[(r*8+c) % 6], 1 + (r+c) % 7)
        for r in range(8) for c in range(8))


def state(*, boss=True, sequence=8, turn=2):
    values = cells(); session = CombatSessionKey(1, 0x100000, 'M_SYNTHETIC')
    battle = BattleState(combat_lifecycle=CombatLifecycleState.ACTIVE,
        session_key=session, match_id=session.match_id, board_instance=session.board_instance,
        srv_seq=sequence, turn_number=turn, current_turn_player='__BOSS__' if boss else 'synthetic-player',
        local_username='synthetic-player', is_local_turn=not boss, stable=True, acknowledged=True,
        latest=True, board_hash=board_state_hash(values), sources=('SYNTHETIC_TEST_PROVIDER',),
        is_board_ready=True, is_cascade_running=False, board_is_processing_ui=False,
        board_is_game_over=False, board_modal_open=False, reconnecting=False,
        match_resyncing=False, presentation_busy=False)
    return GameState(GamePhase.COMBAT, 'synthetic', to_board_state(values), battle,
        ParticipantState(1, is_local=True, hp=1000, max_hp=2000),
        opponents=(ParticipantState(2, is_boss=True, hp=2000, max_hp=4000),))


def capture():
    raw = envelope(); raw['matchPayload']['actorUsername'] = '__BOSS__'
    raw['matchPayload']['ops'] = [dict(type='SWAP', data=dict(fromRow=1, fromCol=2, toRow=1, toCol=3))]
    return projected(raw).to_dict()


def boundary_rows():
    recorder = PublishedStateRecorder()
    before = recorder.observe(state())
    after = recorder.observe(state(boss=False, sequence=9, turn=3))
    return [dict(event='combat_state_evidence', **before),
        dict(event='dispatcher_combat_outcome', combatOutcome=capture()),
        dict(event='combat_state_evidence', **after)]


class BoardEvidenceTests(unittest.TestCase):
    def test_native_board_keeps_exact_coordinates_tags_and_hash_without_ack_authority(self):
        field = retained_board_fields(cells(), match_id='M_SYNTHETIC', lifecycle_epoch=1,
            sequence=8, source='MatchService.PendingCombat', accepted=True)['boardEvidence']
        # JSON round-trip is how the offline reader receives this evidence.
        field = json.loads(json.dumps(field))
        checked_retained(field)
        self.assertEqual([0, 0, 'vang Dot', 1], field['native_cells'][0])
        self.assertEqual(board_state_hash(cells()), field['board_hash'])
        self.assertIn('NOT_PROOF_OF_ACK', field['scope'])
        self.assertFalse(field['input_authority'])
        bad = deepcopy(field); bad['native_cells'][0][0] = True
        with self.assertRaises(ValueError):
            checked_retained(bad)
        bad = deepcopy(field); bad['board_hash'] = '0'*64
        with self.assertRaises(ValueError):
            checked_retained(bad)

    def test_failed_offer_and_invalid_or_unowned_boards_add_no_evidence(self):
        for values, source, accepted in ((cells(), 'MatchService.PendingCombat', False),
                (cells()[:63], 'MatchService.PendingCombat', True),
                (cells(), 'RuntimeSequenceMonitor.WsCombatBatch', True),
                ((replace(cells()[0], row=True),)+cells()[1:], 'TRANSPORT_BOARD', True)):
            self.assertEqual({}, retained_board_fields(values, match_id='M_SYNTHETIC',
                lifecycle_epoch=1, sequence=8, source=source, accepted=accepted))

    def test_provider_state_preserves_screen_mapping_resources_and_anonymous_ownership(self):
        record = PublishedStateRecorder().observe(state())['stateEvidence']
        checked_state(record)
        self.assertNotIn('synthetic-player', json.dumps(record))
        self.assertEqual('BOSS', record['actor_identity'])
        self.assertEqual(['rage', 1], record['board'][0][0])  # native row7 col0
        self.assertEqual(1000, record['player']['hp'])
        self.assertEqual(2000, record['bosses'][0]['hp'])
        self.assertFalse(record['training_eligible'])

    def test_unacknowledged_busy_stale_and_unknown_owner_states_do_not_create_before_board(self):
        original = state()
        for changes in (dict(acknowledged=False), dict(latest=False), dict(presentation_busy=True),
                dict(presentation_busy=None), dict(is_cascade_running=True), dict(board_modal_open=True),
                dict(reconnecting=True), dict(current_turn_player='peer'), dict(is_local_turn=True)):
            self.assertEqual({}, PublishedStateRecorder().observe(
                replace(original, battle=replace(original.battle, **changes))))
        self.assertEqual({}, PublishedStateRecorder().observe(None))

    def test_duplicate_cap_and_other_session_do_not_grow_memory_or_recycle_cap(self):
        recorder = PublishedStateRecorder(); original = state()
        with patch('pokiguard_v2.combat_board_evidence.MAX_STATE_RECORDS', 1):
            self.assertTrue(recorder.observe(original))
            self.assertEqual({}, recorder.observe(original))
            changed = replace(original, player=replace(original.player, hp=999))
            self.assertEqual('STATE_RECORD_LIMIT_REACHED', recorder.observe(changed)['stateEvidence']['reason'])
            self.assertEqual({}, recorder.observe(changed))
            session = replace(original.battle.session_key, lifecycle_epoch=2)
            other = replace(original, battle=replace(original.battle, session_key=session))
            self.assertEqual({}, recorder.observe(other))
            self.assertEqual(1, len(recorder._seen))

    def test_recording_errors_are_optional_and_do_not_escape(self):
        with patch('pokiguard_v2.combat_board_evidence.asdict', side_effect=ValueError('synthetic')):
            self.assertEqual({}, PublishedStateRecorder().observe(state()))


class BossIntervalTests(unittest.TestCase):
    def run_rows(self, rows):
        with tempfile.TemporaryDirectory(dir=reasoning_temp_root()) as directory:
            path = Path(directory)/'combat.jsonl'
            path.write_text(''.join(json.dumps(row)+'\n' for row in rows), encoding='utf-8')
            return extract(path)

    def test_single_observed_swap_requires_published_boss_and_next_local_boundaries(self):
        case = self.run_rows(boundary_rows())
        self.assertFalse(case['excluded']); self.assertFalse(case['unbound'])
        interval, = case['intervals']
        self.assertEqual([[6, 2], [6, 3]], interval['screen_swap'])
        self.assertEqual('BOSS', interval['before']['actor_identity'])
        self.assertEqual(9, interval['after']['server_sequence'])
        self.assertFalse(interval['training_eligible']); self.assertIsNone(interval['optimal_move_label'])
        self.assertEqual(1, summarize([case])['observed_intervals'])
        self.assertEqual(0, summarize([case])['models_fitted'])

    def test_async_outcome_drain_after_boundary_and_identical_duplicates_are_deduplicated(self):
        rows = boundary_rows()
        case = self.run_rows([rows[0], rows[0], rows[2], rows[1], rows[1]])
        self.assertEqual(1, len(case['intervals']))

    def test_our_action_board_last_move_and_post_board_alone_cannot_be_boss_before_board(self):
        rows = boundary_rows()[1:]
        rows.insert(0, dict(event='action_sent', boardSnapshot=state().board.board,
            lastMove=[1, 2, 1, 3]))
        # Enum values serialize as strings; this old local snapshot still has no boss ownership.
        case = self.run_rows(rows)
        self.assertFalse(case['intervals'])
        self.assertEqual('MISSING_PUBLISHED_BOSS_BOUNDARIES', case['unbound'][0]['reason'])

    def test_missing_post_wrong_epoch_owner_turn_or_sequence_never_join(self):
        for key, value in (('lifecycle_epoch', 2), ('local_identity', 'sha256:'+'0'*64),
                ('turn', 4), ('server_sequence', 10), ('board_instance', 0x200000)):
            rows = boundary_rows(); rows[2]['stateEvidence'][key] = value
            self.assertFalse(self.run_rows(rows)['intervals'])
        self.assertFalse(self.run_rows(boundary_rows()[:2])['intervals'])

    def test_boolean_coordinates_tampered_hash_unknown_gems_or_missing_ack_are_rejected(self):
        for key, value in (('semantic_board_sha256', '0'*64), ('acknowledged', False)):
            rows = boundary_rows(); rows[0]['stateEvidence'][key] = value
            case = self.run_rows(rows)
            self.assertTrue(case['excluded']); self.assertFalse(case['intervals'])
        rows = boundary_rows(); rows[0]['stateEvidence']['board'][0][0] = ['unknown', 1]
        self.assertTrue(self.run_rows(rows)['excluded'])

    def test_multiple_swaps_actions_local_input_and_ambiguous_preboards_are_not_labels(self):
        rows = boundary_rows()
        rows[1]['combatOutcome']['evidence']['swap_operations'].append(
            dict(type='SWAP', operation_index=1, native_swap=[2, 3, 3, 3]))
        self.assertEqual('NOT_EXACTLY_ONE_CAPTURED_BOSS_SWAP', self.run_rows(rows)['unbound'][0]['reason'])
        rows = boundary_rows()
        rows.insert(1, dict(event='action_sent'))
        self.assertFalse(self.run_rows(rows)['intervals'])
        rows = boundary_rows(); other = deepcopy(rows[0]); other['stateEvidence']['player']['hp'] = 500
        rows.insert(1, other)
        self.assertEqual('AMBIGUOUS_PUBLISHED_BOSS_BOUNDARIES', self.run_rows(rows)['unbound'][0]['reason'])
        rows = boundary_rows(); other = deepcopy(rows[1]); e = other['combatOutcome']['evidence']
        e['server_sequence'] = 9; e['event_type'] = 'MATCH_CARD_USE_RES'
        rows.insert(1, other)
        self.assertEqual('MULTIPLE_CAPTURED_ACTIONS_IN_INTERVAL', self.run_rows(rows)['unbound'][0]['reason'])


if __name__ == '__main__':
    unittest.main()
