from types import SimpleNamespace
import struct
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.dispatcher_chat_roots import DispatcherChatMessageRoot
from pokiguard_v2.il2cpp_layout import LayoutValidationError
from pokiguard_v2.il2cpp_layout import BoardCellSnapshot, CombatBatchSnapshot
from pokiguard_v2.memory_board_provider import BoardWsObservation, QueueObservation
from tools.dispatcher_qte_result_tap import (
    DispatcherQteResultTap,
    DispatcherTransportTap,
    parse_server_envelope_json,
    parse_skill_result_envelope_json,
)


class DispatcherQteResultTapTests(unittest.TestCase):
    def target(self):
        resolver = Mock()
        resolver.resolve_type_info_class.return_value = 0x123000
        return SimpleNamespace(memory=Mock(), resolver=resolver)

    @staticmethod
    def complete_batch(sequence: int = 14) -> CombatBatchSnapshot:
        cells = tuple(
            BoardCellSnapshot(
                0x700000 + row * 0x800 + col * 0x80,
                col,
                row,
                0x900000,
                "vang Dot",
                1,
            )
            for row in range(8)
            for col in range(8)
        )
        return CombatBatchSnapshot(0x400000, sequence, 0x600000, cells)

    @patch("tools.dispatcher_qte_result_tap.read_server_message")
    def test_retains_only_exact_current_skill_response(self, decode):
        target = self.target()
        tap = DispatcherQteResultTap(target)
        tap._reader = Mock()
        tap._reader.read.return_value = (
            DispatcherChatMessageRoot(0x200000, 0x210000, 0x220000, "execution_queue", 0),
        )
        message = SimpleNamespace(
            address=0x200000,
            match_id="M_A",
            event_type="MATCH_SKILL_USE_RES",
        )
        decode.return_value = message

        tap._capture_once("M_A")
        tap._capture_once("M_A")

        self.assertEqual(tap.results("M_A"), (message,))
        self.assertEqual(decode.call_count, 1)
        self.assertEqual(tap.diagnostics.decoded_skill_results, 1)

    @patch("tools.dispatcher_qte_result_tap.parse_transport_board_envelope_json")
    @patch("tools.dispatcher_qte_result_tap.read_il2cpp_string")
    @patch("tools.dispatcher_qte_result_tap.read_server_message")
    def test_retains_strict_board_from_callback_owned_raw_json(
        self, decode, read_string, parse_json
    ):
        target = self.target()
        tap = DispatcherQteResultTap(target)
        tap._reader = Mock()
        tap._reader.read.return_value = (
            DispatcherChatMessageRoot(
                0x200000,
                0x210000,
                0x220000,
                "execution_queue",
                0,
                json_address=0x230000,
            ),
        )
        message = SimpleNamespace(
            address=0x200000,
            match_id="M_A",
            event_type="MATCH_SKILL_USE_RES",
        )
        snapshot = SimpleNamespace(match_id="M_A", message_address=0x200000)
        decode.return_value = message
        read_string.return_value = (
            '{"type":"MATCH_SKILL_USE_RES","matchId":"M_A",'
            '"matchPayload":{"srvSeq":44,"board":[]}}'
        )
        parse_json.return_value = snapshot

        tap._capture_once("M_A")

        self.assertIs(tap.board_snapshot("M_A", 0x200000), snapshot)
        self.assertEqual(tap.diagnostics.decoded_raw_boards, 1)
        parse_json.assert_called_once_with(
            read_string.return_value,
            expected_match_id="M_A",
            expected_event_type="MATCH_SKILL_USE_RES",
            message_address=0x200000,
            json_address=0x230000,
        )

    @patch("tools.dispatcher_qte_result_tap.read_server_message")
    def test_other_chat_event_is_available_to_basic_but_not_qte_results(self, decode):
        target = self.target()
        tap = DispatcherQteResultTap(target)
        tap._reader = Mock()
        tap._reader.read.return_value = (
            DispatcherChatMessageRoot(0x200000, 0x210000, 0x220000, "drain_buffer", 0),
        )
        decode.return_value = SimpleNamespace(
            address=0x200000,
            match_id="M_A",
            event_type="MATCH_MOVE_RES",
        )
        tap._capture_once("M_A")
        self.assertEqual(tap.results("M_A"), ())
        self.assertEqual(tap.messages("M_A"), (decode.return_value,))
        self.assertEqual(tap.diagnostics.candidate_messages, 1)

    def test_strict_raw_afk_envelope_preserves_idle_evidence(self):
        message = parse_server_envelope_json(
            '{"type":"MATCH_AFK_WARN","matchId":"M_A",'
            '"timestamp":"2026-09-11T01:00:00",'
            '"matchPayload":{"srvSeq":22,"idleCount":2,"threshold":3}}',
            expected_match_id="M_A",
            message_address=0x200000,
        )

        self.assertEqual(message.event_type, "MATCH_AFK_WARN")
        self.assertEqual(message.match_id, "M_A")
        self.assertEqual(message.idle_count, 2)
        self.assertEqual(message.threshold, 3)
        self.assertEqual(message.server_sequence, 22)
        self.assertEqual(dict(message.payload_ints)["srvSeq"], 22)

    def test_payload_sequence_overrides_unrelated_outer_envelope_counter(self):
        message = parse_server_envelope_json(
            '{"type":"MATCH_MOVE_RES","matchId":"M_A","seqNum":2,'
            '"matchPayload":{"srvSeq":61}}',
            expected_match_id="M_A",
            message_address=0x200000,
        )

        self.assertEqual(message.server_sequence, 61)

    def test_generic_parser_rejects_stale_or_unrelated_callbacks(self):
        for raw in (
            '{"type":"LOBBY_JOINED","matchId":"M_A"}',
            '{"type":"MATCH_MOVE_RES","matchId":"M_OLD"}',
        ):
            with self.subTest(raw=raw):
                with self.assertRaises(LayoutValidationError):
                    parse_server_envelope_json(
                        raw,
                        expected_match_id="M_A",
                        message_address=0x200000,
                    )

    def test_strict_raw_skill_result_preserves_correlation_fields(self):
        message = parse_skill_result_envelope_json(
            '{"type":"MATCH_SKILL_USE_RES","matchId":"M_A",'
            '"timestamp":"2026-09-08T22:00:00","skillCardId":7,'
            '"qteChallengeId":81,"matchPayload":{"srvSeq":146,'
            '"success":true,"actorUsername":"local",'
            '"timingResult":"PERFECT"}}',
            expected_match_id="M_A",
            message_address=0x200000,
        )

        self.assertEqual(message.event_type, "MATCH_SKILL_USE_RES")
        self.assertEqual(message.match_id, "M_A")
        self.assertEqual(message.timestamp, "2026-09-08T22:00:00")
        self.assertEqual(message.skill_card_id, 7)
        self.assertEqual(message.qte_challenge_id, 81)
        self.assertEqual(dict(message.payload_ints)["srvSeq"], 146)
        self.assertTrue(dict(message.payload_bools)["success"])
        self.assertEqual(dict(message.payload_strings)["timingResult"], "PERFECT")
        self.assertIsNone(message.payload_address)

    def test_raw_skill_result_rejects_other_match_or_event(self):
        for raw in (
            '{"type":"MATCH_MOVE_RES","matchId":"M_A"}',
            '{"type":"MATCH_SKILL_USE_RES","matchId":"M_OLD"}',
        ):
            with self.subTest(raw=raw):
                with self.assertRaises(LayoutValidationError):
                    parse_skill_result_envelope_json(
                        raw,
                        expected_match_id="M_A",
                        message_address=0x200000,
                    )

    @patch("tools.dispatcher_qte_result_tap.parse_transport_board_envelope_json")
    @patch("tools.dispatcher_qte_result_tap.read_il2cpp_string")
    @patch("tools.dispatcher_qte_result_tap.read_server_message")
    def test_raw_callback_retains_result_when_mutable_dto_is_unreadable(
        self, decode, read_string, parse_board
    ):
        target = self.target()
        tap = DispatcherQteResultTap(target)
        tap._reader = Mock()
        tap._reader.read.return_value = (
            DispatcherChatMessageRoot(
                0x200000,
                0x210000,
                0x220000,
                "execution_queue",
                0,
                json_address=0x230000,
            ),
        )
        decode.side_effect = LayoutValidationError("mutable DTO already cleared")
        read_string.return_value = (
            '{"type":"MATCH_SKILL_USE_RES","matchId":"M_A",'
            '"timestamp":"2026-09-08T22:00:00",'
            '"matchPayload":{"srvSeq":146,"success":true}}'
        )
        parse_board.side_effect = LayoutValidationError("board omitted")

        tap._capture_once("M_A")

        results = tap.results("M_A")
        self.assertEqual(len(results), 1)
        self.assertEqual(results[0].event_type, "MATCH_SKILL_USE_RES")
        self.assertEqual(tap.diagnostics.decoded_skill_results, 1)
        self.assertEqual(tap.diagnostics.decoded_raw_results, 1)
        self.assertEqual(tap.diagnostics.raw_board_rejections, 1)

    @patch("tools.dispatcher_qte_result_tap.parse_transport_board_envelope_json")
    @patch("tools.dispatcher_qte_result_tap.read_il2cpp_string")
    @patch("tools.dispatcher_qte_result_tap.read_server_message")
    def test_retains_later_current_move_board_for_post_skill_reread(
        self, decode, read_string, parse_board
    ):
        target = self.target()
        tap = DispatcherQteResultTap(target)
        tap._reader = Mock()
        tap._reader.read.return_value = (
            DispatcherChatMessageRoot(
                0x200000,
                0x210000,
                0x220000,
                "drain_buffer",
                0,
                json_address=0x230000,
            ),
        )
        decode.return_value = SimpleNamespace(
            address=0x200000,
            match_id="M_A",
            event_type="MATCH_MOVE_RES",
        )
        read_string.return_value = (
            '{"type":"MATCH_MOVE_RES","matchId":"M_A",'
            '"matchPayload":{"srvSeq":147,"board":[]}}'
        )
        snapshot = SimpleNamespace(match_id="M_A", sequence=147)
        parse_board.return_value = snapshot

        tap._capture_once("M_A")

        self.assertEqual(
            tap.transport_board_snapshots("M_A"),
            (("MATCH_MOVE_RES", snapshot),),
        )
        self.assertEqual(tap.results("M_A"), ())
        self.assertEqual(len(tap.messages("M_A")), 1)
        self.assertEqual(tap.messages("M_A")[0].event_type, "MATCH_MOVE_RES")
        self.assertEqual(tap.diagnostics.decoded_raw_boards, 1)
        self.assertEqual(tap.diagnostics.decoded_dto_boards, 0)
        self.assertEqual(tap.diagnostics.retained_board_snapshots, 1)

    @patch("tools.dispatcher_qte_result_tap.read_match_payload_board_snapshot")
    @patch("tools.dispatcher_qte_result_tap.parse_transport_board_envelope_json")
    @patch("tools.dispatcher_qte_result_tap.read_il2cpp_string")
    @patch("tools.dispatcher_qte_result_tap.read_server_message")
    def test_dto_payload_recovers_board_when_updated_raw_shape_is_rejected(
        self, decode, read_string, parse_raw_board, read_dto_board
    ):
        target = self.target()
        tap = DispatcherQteResultTap(target)
        tap._reader = Mock()
        tap._reader.read.return_value = (
            DispatcherChatMessageRoot(
                0x200000,
                0x210000,
                0x220000,
                "drain_buffer",
                0,
                json_address=0x230000,
            ),
        )
        decode.return_value = SimpleNamespace(
            address=0x200000,
            match_id="M_A",
            event_type="MATCH_MOVE_RES",
            server_sequence=50,
            payload_address=0x240000,
        )
        read_string.return_value = (
            '{"type":"MATCH_MOVE_RES","matchId":"M_A",'
            '"matchPayload":{"srvSeq":50,"board":{"updated":true}}}'
        )
        parse_raw_board.side_effect = LayoutValidationError("updated raw board shape")
        snapshot = SimpleNamespace(match_id="M_A", sequence=50)
        read_dto_board.return_value = snapshot

        tap._capture_once("M_A")

        self.assertEqual(
            tap.transport_board_snapshots("M_A"),
            (("MATCH_MOVE_RES", snapshot),),
        )
        self.assertEqual(tap.diagnostics.decoded_raw_boards, 0)
        self.assertEqual(tap.diagnostics.decoded_dto_boards, 1)
        self.assertEqual(tap.diagnostics.retained_board_snapshots, 1)
        self.assertEqual(tap.diagnostics.raw_board_rejections, 1)
        self.assertIn("dto=recovered", tap.diagnostics.board_rejection_reasons[0])
        read_dto_board.assert_called_once()

    @patch("tools.dispatcher_qte_result_tap.read_match_payload_board_snapshot")
    @patch("tools.dispatcher_qte_result_tap.read_preparsed_board_snapshot")
    @patch("tools.dispatcher_qte_result_tap.parse_transport_board_envelope_json")
    @patch("tools.dispatcher_qte_result_tap.read_il2cpp_string")
    @patch("tools.dispatcher_qte_result_tap.read_server_message")
    def test_b2_preboard_recovers_updated_raw_board_before_payload_fallback(
        self, decode, read_string, parse_raw_board, read_preboard, read_dto_board
    ):
        target = self.target()
        tap = DispatcherQteResultTap(target)
        tap._reader = Mock()
        tap._reader.read.return_value = (
            DispatcherChatMessageRoot(
                0x200000,
                0x210000,
                0x220000,
                "drain_buffer",
                0,
                json_address=0x230000,
            ),
        )
        decode.return_value = SimpleNamespace(
            address=0x200000,
            match_id="M_A",
            event_type="MATCH_MOVE_RES",
            server_sequence=7,
            payload_address=0x240000,
        )
        read_string.return_value = (
            '{"type":"MATCH_MOVE_RES","matchId":"M_A",'
            '"matchPayload":{"srvSeq":18,"board":{"compact":true}}}'
        )
        parse_raw_board.side_effect = LayoutValidationError("updated raw board shape")
        snapshot = SimpleNamespace(match_id="M_A", sequence=18)
        read_preboard.return_value = snapshot

        tap._capture_once("M_A")

        self.assertEqual(
            tap.transport_board_snapshots("M_A"),
            (("MATCH_MOVE_RES", snapshot),),
        )
        self.assertEqual(tap.diagnostics.decoded_preparsed_boards, 1)
        self.assertEqual(tap.diagnostics.decoded_dto_boards, 0)
        read_preboard.assert_called_once_with(
            target.memory,
            match_id="M_A",
            message_address=0x200000,
            expected_message_class=0x123000,
            event_type="MATCH_MOVE_RES",
            sequence=18,
        )
        read_dto_board.assert_not_called()
        self.assertIn(
            "preBoard=recovered", tap.diagnostics.board_rejection_reasons[0]
        )

    @patch("tools.dispatcher_qte_result_tap.read_combat_batch")
    @patch("tools.dispatcher_qte_result_tap.read_il2cpp_string")
    def test_retains_stable_matchservice_pending_batch(
        self, read_string, read_batch
    ):
        target = self.target()
        target.resolver.resolve_singleton.return_value = SimpleNamespace(
            instance=0x300000
        )
        target.memory.read.side_effect = lambda address, _size: (
            struct.pack("<Q", 0x400000)
            if address == 0x300000 + 0x1A8
            else struct.pack("<Q", 0x500000)
        )
        read_string.return_value = "M_A"
        read_batch.return_value = self.complete_batch()
        tap = DispatcherQteResultTap(target)

        tap._capture_match_service_pending("M_A")
        tap._capture_match_service_pending("M_A")

        retained = tap.runtime_batches("M_A")
        self.assertEqual(retained, (("MatchService.PendingCombat", read_batch.return_value),))
        self.assertEqual(tap.diagnostics.decoded_pending_batches, 1)
        self.assertEqual(tap.diagnostics.retained_runtime_batches, 1)

    @patch("tools.dispatcher_qte_result_tap.read_combat_batch")
    @patch("tools.dispatcher_qte_result_tap.read_pending_queue")
    @patch("tools.dispatcher_qte_result_tap.read_board_ws_candidate")
    def test_retains_only_stable_exact_match_board_ws_queue(
        self, read_owner, read_queue, read_batch
    ):
        target = self.target()
        tap = DispatcherQteResultTap(target)
        tap.configure_runtime_owners(
            board_instance=0x310000,
            board_ws_addresses=(0x320000,),
        )
        tap._board_ws_class = 0x123000
        tap._batch_class = 0x124000
        read_owner.return_value = BoardWsObservation(
            0x320000, 0x330000, False, "M_A"
        )
        read_queue.return_value = QueueObservation(
            0x330000, 4, 0, 1, 1, 8, (0x400000,)
        )
        read_batch.return_value = self.complete_batch()

        tap._capture_board_ws_queues("M_A")

        self.assertEqual(
            tap.runtime_batches("M_A"),
            (("BoardWsApplier._pendingBatches", read_batch.return_value),),
        )
        self.assertEqual(tap.diagnostics.decoded_owner_queue_batches, 1)
        self.assertEqual(read_owner.call_count, 2)
        self.assertEqual(read_queue.call_count, 2)

    @patch("tools.dispatcher_qte_result_tap.read_combat_batch")
    @patch("tools.dispatcher_qte_result_tap.read_pending_queue")
    @patch("tools.dispatcher_qte_result_tap.read_board_ws_candidate")
    def test_rejects_board_ws_queue_that_changes_during_capture(
        self, read_owner, read_queue, read_batch
    ):
        target = self.target()
        tap = DispatcherQteResultTap(target)
        tap.configure_runtime_owners(
            board_instance=0x310000,
            board_ws_addresses=(0x320000,),
        )
        tap._board_ws_class = 0x123000
        tap._batch_class = 0x124000
        read_owner.return_value = BoardWsObservation(
            0x320000, 0x330000, False, "M_A"
        )
        read_queue.side_effect = (
            QueueObservation(0x330000, 4, 0, 1, 1, 8, (0x400000,)),
            QueueObservation(0x330000, 4, 1, 1, 0, 9, ()),
        )
        read_batch.return_value = self.complete_batch()

        tap._capture_board_ws_queues("M_A")

        self.assertEqual(tap.runtime_batches("M_A"), ())
        self.assertEqual(tap.diagnostics.decoded_owner_queue_batches, 0)

    def test_transport_name_is_compatible_with_existing_qte_name(self):
        self.assertIs(DispatcherTransportTap, DispatcherQteResultTap)

    def test_arm_switches_session_and_stop_is_clean(self):
        tap = DispatcherQteResultTap(self.target(), interval_seconds=0.005)
        tap._capture_once = Mock()
        tap.arm("M_A")
        self.assertEqual(tap.diagnostics.armed_match_id, "M_A")
        tap.arm("M_B")
        self.assertEqual(tap.diagnostics.armed_match_id, "M_B")
        tap.stop()
        self.assertFalse(tap._thread.is_alive())

    def test_invalid_interval_or_match_fails_closed(self):
        with self.assertRaises(ValueError):
            DispatcherQteResultTap(self.target(), interval_seconds=0.1)
        tap = DispatcherQteResultTap(self.target())
        with self.assertRaises(ValueError):
            tap.arm("")


if __name__ == "__main__":
    unittest.main()
