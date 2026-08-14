from __future__ import annotations

import struct
import unittest

from tools.idle_state_watch import (
    ServerMessage,
    _server_response_status,
    read_dictionary_entries,
    read_jobject_value_pointers,
    read_small_boxed_int,
)


class FakeMemory:
    def __init__(self) -> None:
        self.bytes: dict[int, int] = {}

    def map(self, address: int, value: bytes | bytearray) -> None:
        self.bytes.update({address + index: byte for index, byte in enumerate(value)})

    def read(self, address: int, size: int) -> bytes:
        return bytes(self.bytes[address + index] for index in range(size))

    def is_readable(self, address: int, size: int) -> bool:
        return size > 0 and all(address + index in self.bytes for index in range(size))


def il2cpp_string(value: str, class_pointer: int) -> bytes:
    encoded = value.encode("utf-16-le")
    raw = bytearray(0x14 + len(encoded))
    struct.pack_into("<Q", raw, 0, class_pointer)
    struct.pack_into("<i", raw, 0x10, len(value))
    raw[0x14:] = encoded
    return bytes(raw)


class IdleStateWatchTests(unittest.TestCase):
    def message(self, **changes):
        values = dict(
            address=0x20000000000,
            event_type="MATCH_CARD_USE_RES",
            match_id="M_test",
            timestamp=None,
            username="happi",
            payload_address=None,
            server_sequence=7,
            from_col=None,
            from_row=None,
            to_col=None,
            to_row=None,
            card_id=4,
            skill_card_id=None,
            reject_reason=None,
            idle_count=None,
            threshold=None,
            payload_ints=(),
            payload_bools=(),
            payload_strings=(),
        )
        values.update(changes)
        return ServerMessage(**values)

    def test_server_response_status_does_not_invent_acceptance(self) -> None:
        unknown = self.message()
        self.assertIn("NEEDS_STATE_CORRELATION", _server_response_status(unknown))
        accepted = self.message(payload_bools=(("success", True),))
        self.assertEqual(_server_response_status(accepted), "SERVER_ACCEPTED_EXPLICIT")
        rejected = self.message(reject_reason="NO_MANA")
        self.assertEqual(_server_response_status(rejected), "SERVER_REJECTED")

    def test_reads_idle_dictionary_without_maintaining_a_counter(self) -> None:
        memory = FakeMemory()
        dictionary = 0x20000000000
        entries = 0x20000001000
        idle_key = 0x20000002000
        threshold_key = 0x20000003000
        idle_value = 0x20000004000
        threshold_value = 0x20000005000
        string_class = 0x20000006000

        dictionary_raw = bytearray(0x30)
        struct.pack_into("<Q", dictionary_raw, 0x18, entries)
        struct.pack_into("<i", dictionary_raw, 0x20, 2)
        struct.pack_into("<i", dictionary_raw, 0x28, 0)
        memory.map(dictionary, dictionary_raw)

        entries_raw = bytearray(0x20 + 2 * 0x18)
        struct.pack_into("<q", entries_raw, 0x18, 2)
        struct.pack_into("<iiQQ", entries_raw, 0x20, 1, -1, idle_key, idle_value)
        struct.pack_into(
            "<iiQQ", entries_raw, 0x38, 2, -1, threshold_key, threshold_value
        )
        memory.map(entries, entries_raw)
        memory.map(string_class, bytearray(8))
        memory.map(idle_key, il2cpp_string("idleCount", string_class))
        memory.map(threshold_key, il2cpp_string("threshold", string_class))
        memory.map(idle_value, bytearray(0x10) + struct.pack("<q", 2))
        memory.map(threshold_value, bytearray(0x10) + struct.pack("<q", 3))

        parsed = read_dictionary_entries(memory, dictionary)
        self.assertEqual(read_small_boxed_int(memory, parsed["idleCount"]), 2)
        self.assertEqual(read_small_boxed_int(memory, parsed["threshold"]), 3)

    def test_reads_nested_turn_end_afk_jobject_layout(self) -> None:
        memory = FakeMemory()
        jobject = 0x20000100000
        properties = 0x20000101000
        dictionary = 0x20000102000
        entries = 0x20000103000
        key = 0x20000104000
        jproperty = 0x20000105000
        content = 0x20000106000
        token = 0x20000107000
        boxed = 0x20000108000
        string_class = 0x20000109000

        memory.map(jobject, bytearray(0x58) + struct.pack("<Q", properties))
        memory.map(properties, bytearray(0x18) + struct.pack("<Q", dictionary))
        dictionary_raw = bytearray(0x30)
        struct.pack_into("<Q", dictionary_raw, 0x18, entries)
        struct.pack_into("<i", dictionary_raw, 0x20, 1)
        memory.map(dictionary, dictionary_raw)
        entries_raw = bytearray(0x20 + 0x18)
        struct.pack_into("<q", entries_raw, 0x18, 1)
        struct.pack_into("<iiQQ", entries_raw, 0x20, 1, -1, key, jproperty)
        memory.map(entries, entries_raw)
        memory.map(string_class, bytearray(8))
        memory.map(key, il2cpp_string("idleCount", string_class))
        memory.map(jproperty, bytearray(0x58) + struct.pack("<Q", content))
        memory.map(content, bytearray(0x10) + struct.pack("<Q", token))
        memory.map(token, bytearray(0x38) + struct.pack("<Q", boxed))
        memory.map(boxed, bytearray(0x10) + struct.pack("<q", 2))

        values = read_jobject_value_pointers(memory, jobject)
        self.assertEqual(read_small_boxed_int(memory, values["idleCount"]), 2)


if __name__ == "__main__":
    unittest.main()
