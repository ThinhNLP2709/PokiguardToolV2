import struct
import unittest

from pokiguard_v2.dispatcher_chat_roots import DispatcherChatRootReader
from pokiguard_v2.il2cpp_external import (
    CHAT_SERVICE_MESSAGE_CLOSURE_TYPE_INFO_RVA,
    IL2CPP_CLASS_STATIC_FIELDS_OFFSET,
    UNITY_MAIN_THREAD_DISPATCHER_TYPE_INFO_RVA,
    UNITY_PENDING_ACTION_LIST_TYPE_INFO_RVA,
    UNITY_PENDING_ACTION_QUEUE_TYPE_INFO_RVA,
)
from pokiguard_v2.il2cpp_layout import LayoutValidationError


class FakeMemory:
    def __init__(self):
        self.blocks = {}

    def map(self, address, data):
        self.blocks[address] = bytes(data)

    def read(self, address, size):
        for base, data in self.blocks.items():
            if base <= address and address + size <= base + len(data):
                start = address - base
                return data[start : start + size]
        raise OSError(f"unmapped read 0x{address:X}+{size}")

    def is_readable(self, address, size):
        try:
            self.read(address, size)
            return True
        except OSError:
            return False


class FakeResolver:
    def __init__(self, values):
        self.values = values

    def resolve_type_info_class(self, rva):
        return self.values.get(rva)


class MutatingMemory(FakeMemory):
    def __init__(self, watched, replacement):
        super().__init__()
        self.watched = watched
        self.replacement = bytes(replacement)
        self.reads = 0

    def read(self, address, size):
        result = super().read(address, size)
        if address == self.watched:
            self.reads += 1
            if self.reads == 1:
                self.map(self.watched, self.replacement)
        return result


class DispatcherChatRootReaderTests(unittest.TestCase):
    DISPATCHER_CLASS = 0x100000
    QUEUE_CLASS = 0x110000
    LIST_CLASS = 0x120000
    CLOSURE_CLASS = 0x130000
    STATIC = 0x200000
    INSTANCE = 0x210000
    QUEUE = 0x220000
    DRAIN = 0x230000
    QUEUE_ARRAY = 0x240000
    DRAIN_ARRAY = 0x250000
    ACTION_A = 0x260000
    ACTION_B = 0x261000
    CLOSURE_A = 0x270000
    CLOSURE_B = 0x271000
    MESSAGE_A = 0x280000
    MESSAGE_B = 0x281000
    JSON_A = 0x290000
    JSON_B = 0x291000

    def fixture(self, memory=None):
        memory = memory or FakeMemory()
        classes = {
            UNITY_MAIN_THREAD_DISPATCHER_TYPE_INFO_RVA: self.DISPATCHER_CLASS,
            UNITY_PENDING_ACTION_QUEUE_TYPE_INFO_RVA: self.QUEUE_CLASS,
            UNITY_PENDING_ACTION_LIST_TYPE_INFO_RVA: self.LIST_CLASS,
            CHAT_SERVICE_MESSAGE_CLOSURE_TYPE_INFO_RVA: self.CLOSURE_CLASS,
        }
        dispatcher = bytearray(IL2CPP_CLASS_STATIC_FIELDS_OFFSET + 8)
        struct.pack_into("<Q", dispatcher, IL2CPP_CLASS_STATIC_FIELDS_OFFSET, self.STATIC)
        memory.map(self.DISPATCHER_CLASS, dispatcher)
        static = bytearray(0x18)
        struct.pack_into("<QQ", static, 0, self.INSTANCE, self.QUEUE)
        memory.map(self.STATIC, static)
        instance = bytearray(0x28)
        struct.pack_into("<QQ", instance, 0, self.DISPATCHER_CLASS, 0)
        struct.pack_into("<Q", instance, 0x20, self.DRAIN)
        memory.map(self.INSTANCE, instance)

        queue = bytearray(0x30)
        struct.pack_into("<Q", queue, 0, self.QUEUE_CLASS)
        struct.pack_into("<Q", queue, 0x10, self.QUEUE_ARRAY)
        # Wrapped queue: capacity 4, head 3, one item, tail 0.
        struct.pack_into("<iiiii", queue, 0x18, 3, 0, 1, 8, 0)
        memory.map(self.QUEUE, queue)
        queue_array = bytearray(0x20 + 4 * 0x10)
        struct.pack_into("<Q", queue_array, 0x18, 4)
        struct.pack_into("<Q", queue_array, 0x20 + 3 * 0x10, self.ACTION_A)
        queue_array[0x20 + 3 * 0x10 + 8] = 1
        memory.map(self.QUEUE_ARRAY, queue_array)

        drain = bytearray(0x20)
        struct.pack_into("<Q", drain, 0, self.LIST_CLASS)
        struct.pack_into("<Q", drain, 0x10, self.DRAIN_ARRAY)
        struct.pack_into("<ii", drain, 0x18, 1, 4)
        memory.map(self.DRAIN, drain)
        drain_array = bytearray(0x20 + 2 * 0x10)
        struct.pack_into("<Q", drain_array, 0x18, 2)
        struct.pack_into("<Q", drain_array, 0x20, self.ACTION_B)
        memory.map(self.DRAIN_ARRAY, drain_array)

        for action, closure, message, json_address in (
            (self.ACTION_A, self.CLOSURE_A, self.MESSAGE_A, self.JSON_A),
            (self.ACTION_B, self.CLOSURE_B, self.MESSAGE_B, self.JSON_B),
        ):
            delegate = bytearray(0x28)
            struct.pack_into("<Q", delegate, 0, 0x190000)
            struct.pack_into("<Q", delegate, 0x20, closure)
            memory.map(action, delegate)
            target = bytearray(0x28)
            struct.pack_into("<Q", target, 0, self.CLOSURE_CLASS)
            struct.pack_into("<Q", target, 0x18, json_address)
            struct.pack_into("<Q", target, 0x20, message)
            memory.map(closure, target)
            memory.map(message, bytearray(8))
        return memory, DispatcherChatRootReader(memory, FakeResolver(classes))

    def test_reads_exact_queue_and_drain_closure_messages(self):
        _, reader = self.fixture()
        roots = reader.read()
        self.assertEqual(
            {(item.message_address, item.source) for item in roots},
            {
                (self.MESSAGE_A, "execution_queue"),
                (self.MESSAGE_B, "drain_buffer"),
            },
        )
        self.assertEqual(roots[0].logical_index, 0)
        self.assertEqual(
            {item.message_address: item.json_address for item in roots},
            {self.MESSAGE_A: self.JSON_A, self.MESSAGE_B: self.JSON_B},
        )

    def test_non_chat_action_is_ignored(self):
        memory, reader = self.fixture()
        target = bytearray(0x28)
        struct.pack_into("<Q", target, 0, 0xDEAD00)
        struct.pack_into("<Q", target, 0x20, self.MESSAGE_A)
        memory.map(self.CLOSURE_A, target)
        roots = reader.read()
        self.assertEqual([item.message_address for item in roots], [self.MESSAGE_B])

    def test_torn_queue_fails_closed(self):
        original = bytearray(0x30)
        replacement = bytearray(original)
        # The fixture overwrites this block; mutate its eventual first read by
        # changing the stable version afterward.
        memory, reader = self.fixture()
        current = bytearray(memory.blocks[self.QUEUE])
        changed = bytearray(current)
        struct.pack_into("<i", changed, 0x24, 9)
        mutating = MutatingMemory(self.QUEUE, changed)
        for address, block in memory.blocks.items():
            mutating.map(address, block)
        reader = DispatcherChatRootReader(mutating, reader._resolver)
        with self.assertRaisesRegex(LayoutValidationError, "queue changed"):
            reader.read()

    def test_missing_type_info_is_rejected(self):
        memory, _ = self.fixture()
        reader = DispatcherChatRootReader(memory, FakeResolver({}))
        with self.assertRaisesRegex(LayoutValidationError, "type-info"):
            reader.read()


if __name__ == "__main__":
    unittest.main()
