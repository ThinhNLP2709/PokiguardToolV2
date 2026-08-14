from __future__ import annotations

import struct
import unittest

from pokiguard_v2.il2cpp_layout import LayoutValidationError
from pokiguard_v2.memory_board_provider import (
    MemoryBoardStateProvider,
    ProviderMetrics,
)
from pokiguard_v2.opening_snapshot import (
    NewtonsoftClasses,
    OpeningBoardSnapshot,
    read_match_payload_board_snapshot,
    read_match_start_opening_snapshot,
)
from pokiguard_v2.state import CombatSessionKey


class FakeMemory:
    def __init__(self) -> None:
        self.bytes: dict[int, int] = {}

    def map(self, address: int, data: bytes | bytearray) -> None:
        self.bytes.update(
            {address + index: value for index, value in enumerate(data)}
        )

    def read(self, address: int, size: int) -> bytes:
        return bytes(self.bytes[address + index] for index in range(size))

    def is_readable(self, address: int, size: int) -> bool:
        return size > 0 and all(
            address + index in self.bytes for index in range(size)
        )


class SnapshotBuilder:
    BASE = 0x0000020000000000

    def __init__(self) -> None:
        self.memory = FakeMemory()
        self.next = self.BASE
        self.classes = NewtonsoftClasses(
            self.alloc(8), self.alloc(8), self.alloc(8), self.alloc(8)
        )
        self.array_class = self.alloc(8)
        self.string_class = self.alloc(8)
        self.box_class = self.alloc(8)
        self.key_strings = {
            key: self.string(key)
            for key in ("board", "srvSeq", "col", "row", "tag", "multiplier")
        }

    def alloc(self, size: int = 0x100) -> int:
        address = self.next
        self.next += max(0x100, (size + 0xFF) & ~0xFF)
        self.memory.map(address, bytearray(size))
        return address

    def string(self, value: str) -> int:
        raw = bytearray(0x14 + len(value) * 2)
        struct.pack_into("<Q", raw, 0, getattr(self, "string_class", self.BASE))
        struct.pack_into("<i", raw, 0x10, len(value))
        raw[0x14:] = value.encode("utf-16-le")
        address = self.alloc(len(raw))
        self.memory.map(address, raw)
        return address

    def boxed(self, value: int) -> int:
        raw = bytearray(0x18)
        struct.pack_into("<Q", raw, 0, self.box_class)
        struct.pack_into("<q", raw, 0x10, value)
        address = self.alloc(len(raw))
        self.memory.map(address, raw)
        return address

    def jvalue(self, token_type: int, value: int) -> int:
        raw = bytearray(0x40)
        struct.pack_into("<Q", raw, 0, self.classes.jvalue)
        struct.pack_into("<i", raw, 0x30, token_type)
        struct.pack_into("<Q", raw, 0x38, value)
        address = self.alloc(len(raw))
        self.memory.map(address, raw)
        return address

    def jproperty(self, token: int) -> int:
        content = self.alloc(0x18)
        content_raw = bytearray(0x18)
        struct.pack_into("<Q", content_raw, 0x10, token)
        self.memory.map(content, content_raw)
        raw = bytearray(0x60)
        struct.pack_into("<Q", raw, 0, self.classes.jproperty)
        struct.pack_into("<Q", raw, 0x58, content)
        address = self.alloc(len(raw))
        self.memory.map(address, raw)
        return address

    def dictionary(self, values: dict[str, int]) -> int:
        entries = bytearray(0x20 + len(values) * 0x18)
        struct.pack_into("<Q", entries, 0, self.array_class)
        struct.pack_into("<Q", entries, 0x18, len(values))
        for index, (key, value) in enumerate(values.items()):
            offset = 0x20 + index * 0x18
            struct.pack_into("<i", entries, offset, index + 1)
            struct.pack_into("<Q", entries, offset + 0x08, self.key_strings[key])
            struct.pack_into("<Q", entries, offset + 0x10, value)
        entries_address = self.alloc(len(entries))
        self.memory.map(entries_address, entries)
        raw = bytearray(0x30)
        struct.pack_into("<Q", raw, 0, self.box_class)
        struct.pack_into("<Q", raw, 0x18, entries_address)
        struct.pack_into("<i", raw, 0x20, len(values))
        struct.pack_into("<i", raw, 0x28, 0)
        address = self.alloc(len(raw))
        self.memory.map(address, raw)
        return address

    def jobject(self, values: dict[str, int]) -> int:
        properties = {
            key: self.jproperty(token) for key, token in values.items()
        }
        dictionary = self.dictionary(properties)
        collection = bytearray(0x20)
        struct.pack_into("<Q", collection, 0, self.box_class)
        struct.pack_into("<Q", collection, 0x18, dictionary)
        collection_address = self.alloc(len(collection))
        self.memory.map(collection_address, collection)
        raw = bytearray(0x60)
        struct.pack_into("<Q", raw, 0, self.classes.jobject)
        struct.pack_into("<Q", raw, 0x58, collection_address)
        address = self.alloc(len(raw))
        self.memory.map(address, raw)
        return address

    def jarray(self, values: list[int]) -> int:
        items = bytearray(0x20 + len(values) * 8)
        struct.pack_into("<Q", items, 0, self.array_class)
        struct.pack_into("<Q", items, 0x18, len(values))
        if values:
            struct.pack_into(f"<{len(values)}Q", items, 0x20, *values)
        items_address = self.alloc(len(items))
        self.memory.map(items_address, items)
        list_raw = bytearray(0x20)
        struct.pack_into("<Q", list_raw, 0, self.box_class)
        struct.pack_into("<Q", list_raw, 0x10, items_address)
        struct.pack_into("<i", list_raw, 0x18, len(values))
        struct.pack_into("<i", list_raw, 0x1C, 1)
        list_address = self.alloc(len(list_raw))
        self.memory.map(list_address, list_raw)
        raw = bytearray(0x60)
        struct.pack_into("<Q", raw, 0, self.classes.jarray)
        struct.pack_into("<Q", raw, 0x58, list_address)
        address = self.alloc(len(raw))
        self.memory.map(address, raw)
        return address

    def payload(self, *, row_count: int = 8, sequence: int = 3) -> tuple[int, int]:
        rows = []
        tags = ("vang Dot", "xanhduong Dot", "do Dot", "tim Dot", "xanh Dot", "trang Dot")
        for row in range(row_count):
            cells = []
            for col in range(8):
                values = {
                    "col": self.jvalue(6, self.boxed(col)),
                    "row": self.jvalue(6, self.boxed(row)),
                    "tag": self.jvalue(8, self.string(tags[(row + col) % len(tags)])),
                    "multiplier": self.jvalue(6, self.boxed(1 + (row + col) % 4)),
                }
                cells.append(self.jobject(values))
            rows.append(self.jarray(cells))
        board = self.jarray(rows)
        payload = self.dictionary(
            {"board": board, "srvSeq": self.boxed(sequence)}
        )
        return payload, board


class OpeningSnapshotTests(unittest.TestCase):
    def test_exact_match_start_jarray_decodes_64_cells(self) -> None:
        builder = SnapshotBuilder()
        payload, board = builder.payload()
        snapshot = read_match_start_opening_snapshot(
            builder.memory,
            match_id="M_test",
            message_address=0x0000030000000000,
            payload_address=payload,
            classes=builder.classes,
        )
        self.assertEqual(snapshot.board_token_address, board)
        self.assertEqual(snapshot.sequence, 3)
        self.assertEqual(len(snapshot.cells), 64)
        self.assertEqual((snapshot.cells[0].row, snapshot.cells[0].col), (0, 0))
        self.assertEqual((snapshot.cells[-1].row, snapshot.cells[-1].col), (7, 7))

    def test_exact_match_move_response_jarray_decodes_64_cells(self) -> None:
        builder = SnapshotBuilder()
        payload, board = builder.payload(sequence=9)

        snapshot = read_match_payload_board_snapshot(
            builder.memory,
            match_id="M_test",
            message_address=0x0000030000001000,
            payload_address=payload,
            classes=builder.classes,
            event_type="MATCH_MOVE_RES",
        )

        self.assertEqual(snapshot.board_token_address, board)
        self.assertEqual(snapshot.sequence, 9)
        self.assertEqual(len(snapshot.cells), 64)

    def test_non_board_transport_event_fails_closed(self) -> None:
        builder = SnapshotBuilder()
        payload, _board = builder.payload(sequence=9)

        with self.assertRaises(LayoutValidationError):
            read_match_payload_board_snapshot(
                builder.memory,
                match_id="M_test",
                message_address=0x0000030000001000,
                payload_address=payload,
                classes=builder.classes,
                event_type="MATCH_CARD_USE_RES",
            )

    def test_non_8x8_outer_array_fails_closed(self) -> None:
        builder = SnapshotBuilder()
        payload, _board = builder.payload(row_count=7)
        with self.assertRaises(LayoutValidationError):
            read_match_start_opening_snapshot(
                builder.memory,
                match_id="M_test",
                message_address=0x0000030000000000,
                payload_address=payload,
                classes=builder.classes,
            )

    def test_negative_server_sequence_fails_closed(self) -> None:
        builder = SnapshotBuilder()
        _payload, board = builder.payload()
        negative = builder.dictionary(
            {"board": board, "srvSeq": builder.boxed(-1)}
        )
        with self.assertRaises(LayoutValidationError):
            read_match_start_opening_snapshot(
                builder.memory,
                match_id="M_test",
                message_address=0x0000030000000000,
                payload_address=negative,
                classes=builder.classes,
            )

    def test_same_board_duplicate_retains_newest_transport_sequence(self) -> None:
        builder = SnapshotBuilder()
        payload, _board = builder.payload(sequence=1)
        first = read_match_start_opening_snapshot(
            builder.memory,
            match_id="M_test",
            message_address=0x0000030000000000,
            payload_address=payload,
            classes=builder.classes,
        )
        newer = OpeningBoardSnapshot(
            match_id=first.match_id,
            message_address=first.message_address + 0x100,
            payload_address=first.payload_address + 0x100,
            board_token_address=first.board_token_address + 0x100,
            sequence=3,
            cells=first.cells,
        )
        older = OpeningBoardSnapshot(
            match_id=first.match_id,
            message_address=first.message_address + 0x200,
            payload_address=first.payload_address + 0x200,
            board_token_address=first.board_token_address + 0x200,
            sequence=2,
            cells=first.cells,
        )
        provider = object.__new__(MemoryBoardStateProvider)
        provider.metrics = ProviderMetrics()
        provider._session_key = CombatSessionKey(1, 0x200000, "M_test")
        provider._opening_snapshot = None

        self.assertTrue(provider.offer_opening_snapshot(first))
        self.assertTrue(provider.offer_opening_snapshot(newer))
        self.assertTrue(provider.offer_opening_snapshot(older))
        self.assertEqual(provider._opening_snapshot.sequence, 3)
        self.assertEqual(provider.metrics.opening_snapshots_accepted, 1)
        self.assertEqual(provider.metrics.opening_snapshot_rejections, 0)

    def test_move_response_snapshot_is_session_bound_but_not_self_acked(self) -> None:
        builder = SnapshotBuilder()
        payload, _board = builder.payload(sequence=9)
        snapshot = read_match_payload_board_snapshot(
            builder.memory,
            match_id="M_test",
            message_address=0x0000030000001000,
            payload_address=payload,
            classes=builder.classes,
            event_type="MATCH_MOVE_RES",
        )
        provider = object.__new__(MemoryBoardStateProvider)
        provider._session_key = CombatSessionKey(1, 0x200000, "M_test")
        provider._tracked = {}
        provider._sources = {}
        provider._owner_attested = set()
        provider._transport_attested = set()
        provider._ack_attested = set()
        provider.metrics = ProviderMetrics()

        self.assertTrue(
            provider.offer_transport_board_snapshot(
                snapshot, event_type="MATCH_MOVE_RES"
            )
        )
        self.assertEqual(len(provider._tracked), 1)
        self.assertEqual(provider._transport_attested, set(provider._tracked))
        self.assertEqual(provider._ack_attested, set())

        wrong_match = OpeningBoardSnapshot(
            match_id="M_other",
            message_address=snapshot.message_address + 0x100,
            payload_address=snapshot.payload_address,
            board_token_address=snapshot.board_token_address,
            sequence=snapshot.sequence,
            cells=snapshot.cells,
        )
        self.assertFalse(
            provider.offer_transport_board_snapshot(
                wrong_match, event_type="MATCH_MOVE_RES"
            )
        )
        self.assertFalse(
            provider.offer_transport_board_snapshot(
                snapshot, event_type="MATCH_CARD_USE_RES"
            )
        )


if __name__ == "__main__":
    unittest.main()
