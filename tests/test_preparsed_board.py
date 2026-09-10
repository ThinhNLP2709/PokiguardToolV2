"""b2 transport boards: preBoard ownership, sequence fallback and torn reads."""
from dataclasses import replace
import struct
import unittest
from unittest.mock import patch

from pokiguard_v2.il2cpp_layout import LayoutValidationError
from pokiguard_v2.opening_snapshot import read_match_payload_board_snapshot
from tests.test_opening_snapshot import SnapshotBuilder


class PreparsedBoardTests(unittest.TestCase):
    def setUp(self):
        self.b = b = SnapshotBuilder()
        self.message_class = b.alloc()
        self.message = b.alloc(0x408)

        def array(values):
            raw = bytearray(0x20 + 8 * len(values))
            struct.pack_into("<Q", raw, 0, b.array_class)
            struct.pack_into("<Q", raw, 0x18, len(values))
            struct.pack_into(f"<{len(values)}Q", raw, 0x20, *values)
            p = b.alloc(len(raw))
            b.memory.map(p, raw)
            return p

        rows = []
        self.cells = []
        for row in range(8):
            cells = []
            for col in range(8):
                p = b.alloc(0x24)
                b.memory.map(p + 0x10, struct.pack("<iiQi", col, row, b.string("trang Dot"), 1))
                cells.append(p)
                self.cells.append(p)
            rows.append(array(cells))
        self.board = array(rows)
        self.payload = b.dictionary({"srvSeq": b.boxed(14)})
        b.memory.map(self.message, struct.pack("<Q", self.message_class))
        b.memory.map(self.message + 0x30, struct.pack("<Q", b.string("MATCH_MOVE_RES")))
        b.memory.map(self.message + 0xB0, struct.pack("<Q", b.string("M_b2")))
        b.memory.map(self.message + 0xB8, struct.pack("<B7xq", 1, 3))
        b.memory.map(self.message + 0xC8, struct.pack("<Q", self.payload))
        b.memory.map(self.message + 0x3C8, struct.pack("<QB", self.board, 1))

    def read(self, **overrides):
        args = dict(
            match_id="M_b2", message_address=self.message,
            payload_address=self.payload, classes=self.b.classes,
            event_type="MATCH_MOVE_RES", expected_message_class=self.message_class,
        )
        args.update(overrides)
        return read_match_payload_board_snapshot(self.b.memory, **args)

    def set_payload(self, entries):
        self.payload = self.b.dictionary(entries)
        self.b.memory.map(self.message + 0xC8, struct.pack("<Q", self.payload))

    def test_ready_preboard_survives_missing_json_board_with_exact_server_seq(self):
        result = self.read()
        self.assertEqual(result.sequence, 14)  # seqNum=3 is the client counter
        self.assertEqual(result.board_source, "preBoard")
        self.assertEqual(len(result.cells), 64)
        self.assertEqual(result.board_token_address, self.board)

    def test_nullable_seq_num_is_fallback_only_when_srv_seq_is_absent(self):
        self.set_payload({})
        self.assertEqual(self.read().sequence, 3)

    def test_json_board_also_supports_nullable_sequence_fallback(self):
        _, board = self.b.payload()
        self.set_payload({"board": board})
        self.b.memory.map(self.message + 0x3D0, b"\x00")
        self.assertEqual(self.read().sequence, 3)
        self.assertEqual(self.read().board_source, "matchPayload.board")

    def test_absent_or_invalid_sequence_fails_closed(self):
        for seq in (None, -1, 10_000_001):
            with self.subTest(seq=seq):
                self.set_payload({})
                self.b.memory.map(self.message + 0xB8, struct.pack("<B7xq", seq is not None, seq or 0))
                with self.assertRaises(LayoutValidationError):
                    self.read()

    def test_unready_or_invalid_preboard_cannot_authorize_board(self):
        for pointer, flag in ((self.board, 0), (self.board, 2), (0, 1), (0xDEAD, 1)):
            with self.subTest(pointer=pointer, flag=flag):
                self.b.memory.map(self.message + 0x3C8, struct.pack("<QB", pointer, flag))
                with self.assertRaises(LayoutValidationError):
                    self.read()

    def test_duplicate_coordinate_is_rejected(self):
        self.b.memory.map(self.cells[1] + 0x10, struct.pack("<ii", 0, 0))
        with self.assertRaises(LayoutValidationError):
            self.read()

    def test_wrong_class_match_event_or_payload_is_rejected(self):
        for args in (
            {"expected_message_class": self.message_class + 0x100},
            {"match_id": "M_other"}, {"event_type": "MATCH_SKILL_USE_RES"},
            {"payload_address": self.payload + 0x100},
        ):
            with self.subTest(args=args), self.assertRaises(LayoutValidationError):
                self.read(**args)

    def test_preboard_replaced_during_read_is_rejected(self):
        from pokiguard_v2.il2cpp_layout import read_board_cell_jagged_array

        def mutate(memory, pointer):
            result = read_board_cell_jagged_array(memory, pointer)
            memory.map(self.message + 0x3C8, struct.pack("<Q", 0))
            return result

        with patch("pokiguard_v2.opening_snapshot.read_board_cell_jagged_array", side_effect=mutate):
            with self.assertRaisesRegex(LayoutValidationError, "changed during read"):
                self.read()

    def test_preboard_is_session_bound_and_still_requires_render_ack(self):
        from pokiguard_v2.memory_board_provider import MemoryBoardStateProvider, ProviderMetrics
        from pokiguard_v2.state import CombatSessionKey
        provider = MemoryBoardStateProvider.__new__(MemoryBoardStateProvider)
        provider.metrics = ProviderMetrics()
        provider._session_key = CombatSessionKey(1, 0x20000000000, "M_b2")
        provider._tracked = {}
        provider._sources = {}
        provider._owner_attested = set()
        provider._transport_attested = set()
        provider._ack_attested = set()
        snapshot = self.read()
        self.assertTrue(provider.offer_transport_board_snapshot(snapshot, event_type="MATCH_MOVE_RES"))
        self.assertFalse(provider._ack_attested)
        self.assertIn("ChatMessageDTO.MATCH_MOVE_RES.preBoard", next(iter(provider._sources.values())))
        self.assertFalse(provider.offer_transport_board_snapshot(replace(snapshot, match_id="M_other"), event_type="MATCH_MOVE_RES"))
