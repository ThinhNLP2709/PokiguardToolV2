from types import SimpleNamespace
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.dispatcher_chat_roots import DispatcherChatMessageRoot
from pokiguard_v2.il2cpp_layout import LayoutValidationError
from tools.dispatcher_qte_result_tap import (
    DispatcherQteResultTap,
    parse_skill_result_envelope_json,
)


class DispatcherQteResultTapTests(unittest.TestCase):
    def target(self):
        resolver = Mock()
        resolver.resolve_type_info_class.return_value = 0x123000
        return SimpleNamespace(memory=Mock(), resolver=resolver)

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
    def test_other_chat_event_is_seen_but_not_published(self, decode):
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
        self.assertEqual(tap.diagnostics.candidate_messages, 1)

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
        self.assertEqual(tap.diagnostics.decoded_raw_boards, 1)

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
