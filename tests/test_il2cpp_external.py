from __future__ import annotations

import struct
from pathlib import Path
import sys
import unittest


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.il2cpp_external import (
    ACTIVE_BOARD_OFFSET,
    ACTIVE_SINGLETON,
    BOARD_ACTIVE_OFFSET,
    BOARD_ALL_DOTS_OFFSET,
    BOARD_HEIGHT_OFFSET,
    BOARD_IS_CASCADE_RUNNING_OFFSET,
    BOARD_IS_MEGA1_PANEL_OPEN_OFFSET,
    BOARD_IS_READY_OFFSET,
    BOARD_SINGLETON,
    BOARD_WIDTH_OFFSET,
    IL2CPP_CLASS_STATIC_FIELDS_OFFSET,
    Il2CppExternalResolver,
    checked_address,
    is_canonical_user_pointer,
)
from tools.board_instance_watch import TransitionTracker


class FakeMemory:
    def __init__(self) -> None:
        self.bytes: dict[int, int] = {}

    def map(self, address: int, data: bytes | bytearray) -> None:
        self.bytes.update({address + index: value for index, value in enumerate(data)})

    def read(self, address: int, size: int) -> bytes:
        return bytes(self.bytes[address + index] for index in range(size))

    def is_readable(self, address: int, size: int) -> bool:
        return size > 0 and all(address + index in self.bytes for index in range(size))


def put_pointer(buffer: bytearray, offset: int, value: int) -> None:
    struct.pack_into("<Q", buffer, offset, value)


class Il2CppExternalResolverTests(unittest.TestCase):
    MODULE_BASE = 0x0000000180000000
    MODULE_SIZE = 0x04000000
    CLASS = 0x0000020000000000
    STATIC_FIELDS = 0x0000021000000000
    BOARD = 0x0000022000000000
    ACTIVE = 0x0000023000000000
    ALL_DOTS = 0x0000024000000000

    def make_resolver(self, memory: FakeMemory) -> Il2CppExternalResolver:
        return Il2CppExternalResolver(memory, self.MODULE_BASE, self.MODULE_SIZE)

    def map_singleton(
        self,
        memory: FakeMemory,
        type_info_rva: int,
        field_offset: int,
        class_pointer: int,
        static_fields: int,
        instance: int,
    ) -> None:
        memory.map(self.MODULE_BASE + type_info_rva, struct.pack("<Q", class_pointer))
        class_data = bytearray(IL2CPP_CLASS_STATIC_FIELDS_OFFSET + 8)
        put_pointer(class_data, IL2CPP_CLASS_STATIC_FIELDS_OFFSET, static_fields)
        memory.map(class_pointer, class_data)
        static_data = bytearray(field_offset + 8)
        put_pointer(static_data, field_offset, instance)
        memory.map(static_fields, static_data)
        memory.map(instance, bytearray(0x10))

    def test_pointer_validation_and_checked_add(self) -> None:
        self.assertTrue(is_canonical_user_pointer(self.CLASS))
        self.assertFalse(is_canonical_user_pointer(0x1234))
        self.assertEqual(checked_address(self.CLASS, 0xB8), self.CLASS + 0xB8)

    def test_resolves_board_through_verified_static_chain(self) -> None:
        memory = FakeMemory()
        self.map_singleton(
            memory,
            BOARD_SINGLETON.type_info_rva,
            BOARD_SINGLETON.static_field_offset,
            self.CLASS,
            self.STATIC_FIELDS,
            self.BOARD,
        )
        result = self.make_resolver(memory).resolve_singleton(BOARD_SINGLETON)
        self.assertEqual(result.status, "resolved")
        self.assertEqual(result.class_pointer, self.CLASS)
        self.assertEqual(result.static_fields, self.STATIC_FIELDS)
        self.assertEqual(result.instance, self.BOARD)

    def test_rejects_encoded_or_uninitialized_type_info_value(self) -> None:
        memory = FakeMemory()
        memory.map(
            self.MODULE_BASE + BOARD_SINGLETON.type_info_rva,
            struct.pack("<Q", 0x1234),
        )
        result = self.make_resolver(memory).resolve_singleton(BOARD_SINGLETON)
        self.assertEqual(result.status, "type_info_uninitialized_or_invalid")
        self.assertIsNone(result.instance)

    def test_reads_and_cross_checks_valid_board(self) -> None:
        memory = FakeMemory()
        board_data = bytearray(BOARD_IS_MEGA1_PANEL_OPEN_OFFSET + 1)
        struct.pack_into("<i", board_data, BOARD_WIDTH_OFFSET, 8)
        struct.pack_into("<i", board_data, BOARD_HEIGHT_OFFSET, 8)
        put_pointer(board_data, BOARD_ALL_DOTS_OFFSET, self.ALL_DOTS)
        put_pointer(board_data, BOARD_ACTIVE_OFFSET, self.ACTIVE)
        board_data[BOARD_IS_CASCADE_RUNNING_OFFSET] = 0
        board_data[BOARD_IS_READY_OFFSET] = 1
        memory.map(self.BOARD, board_data)
        memory.map(self.ALL_DOTS, bytearray(0x20))
        active_data = bytearray(ACTIVE_BOARD_OFFSET + 8)
        put_pointer(active_data, ACTIVE_BOARD_OFFSET, self.BOARD)
        memory.map(self.ACTIVE, active_data)

        state = self.make_resolver(memory).read_board(self.BOARD, self.ACTIVE)
        self.assertTrue(state.accepted)
        self.assertEqual((state.width, state.height), (8, 8))
        self.assertTrue(state.active_back_reference)
        self.assertTrue(state.board_active_matches_singleton)

    def test_rejects_active_back_reference_mismatch(self) -> None:
        memory = FakeMemory()
        board_data = bytearray(BOARD_IS_MEGA1_PANEL_OPEN_OFFSET + 1)
        struct.pack_into("<i", board_data, BOARD_WIDTH_OFFSET, 8)
        struct.pack_into("<i", board_data, BOARD_HEIGHT_OFFSET, 8)
        put_pointer(board_data, BOARD_ALL_DOTS_OFFSET, self.ALL_DOTS)
        put_pointer(board_data, BOARD_ACTIVE_OFFSET, self.ACTIVE)
        memory.map(self.BOARD, board_data)
        memory.map(self.ALL_DOTS, bytearray(0x20))
        active_data = bytearray(ACTIVE_BOARD_OFFSET + 8)
        put_pointer(active_data, ACTIVE_BOARD_OFFSET, self.BOARD + 0x1000)
        memory.map(self.ACTIVE, active_data)

        state = self.make_resolver(memory).read_board(self.BOARD, self.ACTIVE)
        self.assertFalse(state.accepted)
        self.assertIn("does not point back", state.rejection_reason or "")


class TransitionTrackerTests(unittest.TestCase):
    @staticmethod
    def sample(board: dict[str, object] | None) -> dict[str, object]:
        return {
            "singletons": {"Board": {"status": "resolved" if board else "instance_null"}},
            "board": board,
            "board_error": None,
        }

    def test_logs_only_transitions_and_board_state_changes(self) -> None:
        tracker = TransitionTracker()
        absent = self.sample(None)
        self.assertEqual(tracker.classify(absent), "board_absent")
        self.assertIsNone(tracker.classify(absent))

        board = {"board_instance": "0x1", "accepted": True, "isBoardReady": False}
        self.assertEqual(tracker.classify(self.sample(board)), "board_found")
        self.assertIsNone(tracker.classify(self.sample(board)))

        changed = dict(board, isBoardReady=True)
        self.assertEqual(tracker.classify(self.sample(changed)), "board_state")
        self.assertEqual(tracker.classify(absent), "board_lost")


if __name__ == "__main__":
    unittest.main()
