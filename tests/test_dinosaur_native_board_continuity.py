"""Poll the real provider across sparse-ops ACKs with fake read-only memory.

Reproduces external run e11a...: native board accepted at turn33/move9/ACK67,
one stability confirmation, then rejected on the next poll without a full DTO.
No Windows process, input, heap discovery or game invocation is involved.
"""
from contextlib import ExitStack
from dataclasses import replace
from types import SimpleNamespace as NS
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2 import memory_board_provider as module
from pokiguard_v2.acked_sequences import AckedSequenceSnapshot
from pokiguard_v2.combat_lifecycle import (
    CombatLifecycleObservation, CombatLifecycleSignals, CombatLifecycleState,
)
from pokiguard_v2.il2cpp_layout import BoardCellSnapshot, CombatBatchSnapshot, LayoutValidationError
from pokiguard_v2.memory_board_provider import (
    ActionRuntimeSignals, MemoryBoardStateProvider, MemoryProviderConfig,
    TurnTimerObservation,
)
from pokiguard_v2.state import CombatSessionKey, ParticipantState


class DinosaurNativeContinuityTests(unittest.TestCase):
    def make_provider(self, *, active_start=True):
        self.stack = ExitStack()
        self.addCleanup(self.stack.close)
        self.turn = 33
        self.match_id = 'SYNTHETIC_DINO'
        self.board = NS(board_instance=0x200001000, active=0x200002000,
            all_dots=0x200003000, is_board_ready=True, is_cascade_running=False,
            current_state=1, has_destroyed_this_turn=False, is_processing_ui=False,
            is_game_over=False, is_mega1_panel_open=False, is_mega2_panel_open=False,
            is_using_legend_card=False, is_using_mega=False, is_resuming=False)
        self.action = ActionRuntimeSignals('LOCAL', True, False, False, False,
            False, 0, False, None, False, False, 9, 2, 6, 3, 6, 9)
        self.ack = AckedSequenceSnapshot(0x200004000, 2, 2, 1, (65, 67))
        self.owner = NS(address=0x200005000, bootstrapped_match_id=self.match_id,
                        render_running=False, queue=0x200006000, prefab_by_tag={})
        self.queue = NS(size=0, batch_addresses=())
        self.array = NS(layout_verified=True, elements=tuple(0x200010000+i*0x100 for i in range(64)))
        self.cells = tuple(BoardCellSnapshot(0x200020000+i*0x100, i%8, i//8,
                          0x200030000, ('vang','xanhduong','do','tim','xanh','trang')[(i//8+i%8)%6]+' Dot', 1)
                          for i in range(64))
        target = NS(memory=Mock(), resolver=Mock(), is_running=lambda: True)
        target.resolver.resolve_type_info_class.return_value = 0x200040000
        target.resolver.read_bool.return_value = False
        def fixed(name, **kw):
            return self.stack.enter_context(patch.object(module, name, **kw))
        fixed('read_combat_lifecycle', side_effect=lambda *a, **kw:
            CombatLifecycleObservation(CombatLifecycleState.ACTIVE,
                CombatLifecycleSignals(current_rig=0x200050000,match_id=self.match_id), 'synthetic owned combat'))
        fixed('observe_rectangular_reference_array', side_effect=lambda *a, **kw:self.array)
        fixed('read_selected_card_data_addresses', return_value=())
        fixed('read_cards_in_hand_anchors', return_value=())
        fixed('read_board_ws_candidate', side_effect=lambda *a, **kw:self.owner)
        fixed('read_pending_queue', side_effect=lambda *a, **kw:self.queue)
        fixed('read_acked_sequences', side_effect=lambda *a, **kw:self.ack)
        fixed('validate_combat_card_hits', return_value=())
        fixed('validate_fusion_card_ui_hits', return_value=())
        fixed('read_left_actor_numbers', return_value=NS(actor_numbers=()))
        self.stack.enter_context(patch.object(MemoryBoardStateProvider,'_resolve_board',side_effect=lambda:self.board))
        p=MemoryBoardStateProvider(target, MemoryProviderConfig(require_lobby_start=False,
            active_combat_start=active_start, allow_ack_heap_scan=False, enable_dot_audit=False))
        p._lobby_baseline_ready=True
        p._resolve_match_service=Mock(return_value=0x200060000)
        p._read_string_field=Mock(side_effect=lambda *a:self.match_id)
        p._read_match_state=Mock(side_effect=lambda *a:(self.match_id,self.turn,'LOCAL',None,None))
        p._read_action_signals=Mock(side_effect=lambda *a:self.action)
        p._read_turn_timer=Mock(return_value=TurnTimerObservation(15,14))
        p._participants=Mock(return_value=(ParticipantState(actor_number=1,is_local=True),))
        p._refresh_local_actor_number=Mock()
        p._local_actor_number=1
        p._publish_non_board_fusion_transition=Mock(return_value=None)
        p._scan=Mock(side_effect=AssertionError('unexpected heap scan'))
        p._scan_ack_heap=Mock(side_effect=AssertionError('unexpected ACK heap scan'))
        p._retain_validated_learned_regions=Mock()
        self.session=CombatSessionKey(1,self.board.board_instance,self.match_id)
        p._lifecycle_tracker=NS(observe=lambda *a:self.session)
        p._session_key=self.session
        p._current_board=self.board.board_instance
        p._board_ws_addresses={self.owner.address}
        p._last_accepted_seq=65
        p._last_accepted_turn=31
        p._last_accepted_local_move_sequence=9
        old=p._register(CombatBatchSnapshot(0x200070000,65,0x200071000,self.cells),'ChatMessageDTO.MATCH_MOVE_RES.matchPayload.board')
        p._transport_attested.add(old)
        p._ack_attested.add(old)
        p._last_accepted_hash=old[2]
        self.reader=Mock()
        self.reader.read_dot_board.side_effect=lambda *a:NS(cells=self.cells)
        p._native_card_reader=self.reader
        return p

    def test_sparse_ops_native_board_survives_second_poll_and_publishes_once(self):
        p=self.make_provider()
        first=p.poll()
        self.assertEqual(first.reason,'awaiting_stability_confirmation')
        self.assertEqual(first.confirmations,1)
        self.assertIsNone(first.state)
        second=p.poll()
        self.assertTrue(second.publish,second.reason)
        self.assertEqual(second.state.battle.srv_seq,67)
        self.assertEqual(second.state.battle.turn_number,33)
        self.assertEqual(second.confirmations,2)
        third=p.poll()
        self.assertFalse(third.publish)
        self.assertEqual(third.reason,'duplicate_state')
        self.assertEqual(self.reader.read_dot_board.call_count,1)
        p._scan.assert_not_called()
        p._scan_ack_heap.assert_not_called()

    def test_standard_provider_retains_existing_sparse_ops_behavior(self):
        p=self.make_provider(active_start=False)
        self.assertEqual(p.poll().confirmations,1)
        second=p.poll()
        self.assertTrue(second.publish,second.reason)
        self.assertEqual(second.state.battle.srv_seq,67)

    def test_turn_change_requires_a_new_native_capture(self):
        p=self.make_provider()
        self.assertEqual(p.poll().confirmations,1)
        self.turn=35
        self.reader.read_dot_board.side_effect=LayoutValidationError('new generation unavailable')
        next_poll=p.poll()
        self.assertFalse(next_poll.publish)
        self.assertIsNone(next_poll.state)
        self.assertEqual(p._last_accepted_seq,65)
        self.assertEqual(self.reader.read_dot_board.call_count,2)

    def test_local_move_change_requires_a_new_native_capture(self):
        p=self.make_provider()
        self.assertEqual(p.poll().confirmations,1)
        self.action=replace(self.action,local_move_sequence=10,last_move_sequence=10)
        self.reader.read_dot_board.side_effect=LayoutValidationError('new move unavailable')
        next_poll=p.poll()
        self.assertFalse(next_poll.publish)
        self.assertIsNone(next_poll.state)
        self.assertEqual(self.reader.read_dot_board.call_count,2)

    def test_ack_race_during_second_sample_cannot_publish(self):
        p=self.make_provider()
        self.assertEqual(p.poll().confirmations,1)
        changed=replace(self.ack,sequences=(65,67,68),count=3,last_index=3,version=2)
        module.read_acked_sequences.side_effect=[self.ack,changed]
        next_poll=p.poll()
        self.assertFalse(next_poll.publish)
        self.assertIsNone(next_poll.state)
        self.assertEqual(next_poll.reason,'board_flags_or_session_changed')

    def test_render_busy_after_native_capture_still_blocks(self):
        p=self.make_provider()
        self.assertEqual(p.poll().confirmations,1)
        self.owner.render_running=True
        next_poll=p.poll()
        self.assertFalse(next_poll.publish)
        self.assertEqual(next_poll.reason,'presentation_busy_or_batch_pending')

    def test_unbound_heap_batch_cannot_become_native_witness(self):
        p=self.make_provider()
        identity=p._register(CombatBatchSnapshot(0x200080000,67,0x200081000,self.cells),'SYNTHETIC_UNBOUND_HEAP')
        p._runtime_heap_attested.add(identity)
        p._ack_attested.add(identity)
        self.reader.read_dot_board.side_effect=LayoutValidationError('native owner unavailable')
        for _ in range(2):
            observed=p.poll()
            self.assertFalse(observed.publish)
            self.assertIsNone(observed.state)
        self.assertFalse(p._live_board_attested)
        p._scan_ack_heap.assert_not_called()

    def test_cached_native_identity_must_still_exist_in_tracked_data(self):
        p=self.make_provider()
        self.assertEqual(p.poll().confirmations,1)
        identity=next(iter(p._live_board_attested))
        del p._tracked[identity]
        observed=p.poll()
        self.assertFalse(observed.publish)
        self.assertIsNone(observed.state)

    def test_full_transport_dto_retains_priority_over_native_fallback(self):
        p=self.make_provider()
        self.assertEqual(p.poll().confirmations,1)
        cells=tuple(replace(c,tag='xanhduong Dot') for c in self.cells)
        identity=p._register(CombatBatchSnapshot(0x200090000,67,0x200091000,cells),
                             'ChatMessageDTO.MATCH_MOVE_RES.matchPayload.board')
        p._transport_attested.add(identity)
        # The newly observed board gets its own two samples; neither candidate
        # is allowed to borrow the other's first confirmation.
        self.assertEqual(p.poll().confirmations,1)
        observed=p.poll()
        self.assertTrue(observed.publish,observed.reason)
        self.assertEqual(observed.state.battle.board_hash,identity[2])
        self.assertEqual(self.reader.read_dot_board.call_count,1)

    def test_session_change_drops_all_cached_native_witnesses(self):
        p=self.make_provider()
        self.assertEqual(p.poll().confirmations,1)
        self.assertTrue(p._live_board_attested)
        p._reset_lifecycle(self.board.board_instance,'SYNTHETIC_OTHER',
                           CombatSessionKey(2,self.board.board_instance,'SYNTHETIC_OTHER'))
        self.assertFalse(p._live_board_attested)
        self.assertFalse(p._live_board_generations)

    def test_removed_ack_cannot_retain_the_native_watermark(self):
        p=self.make_provider()
        self.assertEqual(p.poll().confirmations,1)
        self.ack=replace(self.ack,sequences=(65,),count=1,last_index=1,version=2)
        observed=p.poll()
        self.assertFalse(observed.publish)
        if observed.state is not None:
            self.assertNotEqual(observed.state.battle.srv_seq,67)

    def test_cached_native_does_not_advance_an_isolated_recovery_ack_epoch(self):
        p=self.make_provider()
        self.assertEqual(p.poll().confirmations,1)
        p._recovery_ack_epoch_session=self.session
        p._recovery_ack_baseline_highest=100
        self.ack=replace(self.ack,sequences=(65,67,100),count=3,last_index=3,version=2)
        observed=p.poll()
        self.assertTrue(p._recovery_ack_isolated)
        self.assertEqual(p._recovery_ack_effective_highest,65)
        self.assertFalse(observed.publish)
        if observed.state is not None:
            self.assertNotEqual(observed.state.battle.srv_seq,67)


if __name__=='__main__':
    unittest.main()
