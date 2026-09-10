"""Read current ChatService callbacks from Unity's main-thread dispatcher.

The game deserializes an incoming websocket envelope before it queues a
``ChatService.__c__DisplayClass275_0`` callback.  That closure owns the exact
``ChatMessageDTO`` at ``+0x20``.  Reading the dispatcher's queue/drain buffer is
therefore a small, ownership-backed alternative to a process-wide heap scan.

All reads are external and read-only.  Every mutable container is fenced by a
second shape read; a torn queue/list is rejected rather than partially used.
"""

from __future__ import annotations

from dataclasses import dataclass
import struct
from typing import Protocol

from .il2cpp_external import (
    CHAT_SERVICE_MESSAGE_CLOSURE_TYPE_INFO_RVA,
    IL2CPP_CLASS_STATIC_FIELDS_OFFSET,
    MAX_USER_ADDRESS,
    UNITY_MAIN_THREAD_DISPATCHER_TYPE_INFO_RVA,
    UNITY_PENDING_ACTION_LIST_TYPE_INFO_RVA,
    UNITY_PENDING_ACTION_QUEUE_TYPE_INFO_RVA,
    ExternalReadError,
    MemoryReader,
    is_canonical_user_pointer,
)
from .il2cpp_layout import LayoutValidationError


DISPATCHER_STATIC_INSTANCE_OFFSET = 0x00
DISPATCHER_STATIC_QUEUE_OFFSET = 0x08
DISPATCHER_DRAIN_BUFFER_OFFSET = 0x20

QUEUE_ARRAY_OFFSET = 0x10
QUEUE_HEAD_OFFSET = 0x18
QUEUE_TAIL_OFFSET = 0x1C
QUEUE_SIZE_OFFSET = 0x20
QUEUE_VERSION_OFFSET = 0x24
QUEUE_READ_SIZE = 0x30

LIST_ARRAY_OFFSET = 0x10
LIST_SIZE_OFFSET = 0x18
LIST_VERSION_OFFSET = 0x1C
LIST_READ_SIZE = 0x20

IL2CPP_ARRAY_LENGTH_OFFSET = 0x18
IL2CPP_ARRAY_DATA_OFFSET = 0x20
PENDING_ACTION_STRIDE = 0x10
PENDING_ACTION_DELEGATE_OFFSET = 0x00
PENDING_ACTION_HEAVY_OFFSET = 0x08
DELEGATE_TARGET_OFFSET = 0x20
CLOSURE_MESSAGE_OFFSET = 0x20
CLOSURE_JSON_OFFSET = 0x18
MAX_PENDING_ACTIONS = 256


class TypeInfoResolver(Protocol):
    def resolve_type_info_class(self, type_info_rva: int) -> int | None: ...


@dataclass(frozen=True)
class DispatcherChatMessageRoot:
    message_address: int
    closure_address: int
    action_address: int
    source: str
    logical_index: int
    json_address: int | None = None


@dataclass(frozen=True)
class _PendingAction:
    action_address: int
    source: str
    logical_index: int


def _read_exact(memory: MemoryReader, address: int, size: int, label: str) -> bytes:
    if (
        size <= 0
        or not is_canonical_user_pointer(address)
        or address + size <= address
        or address + size > MAX_USER_ADDRESS + 1
    ):
        raise LayoutValidationError(f"{label} is unreadable")
    try:
        # ``ReadProcessMemory`` itself validates the complete remote range and
        # returns an exact byte count.  Calling ``VirtualQueryEx`` before every
        # one of these tiny high-cadence reads made one sample take nearly a
        # whole 60 Hz frame, defeating the short-lived-root design.  Canonical
        # range validation + exact RPM + stable before/after fences fail closed
        # without that redundant syscall per field.
        value = memory.read(address, size)
    except (ExternalReadError, OSError) as exc:
        raise LayoutValidationError(f"{label} is unreadable: {exc}") from exc
    if len(value) != size:
        raise LayoutValidationError(f"short {label} read")
    return value


def _pointer(raw: bytes, offset: int) -> int:
    return struct.unpack_from("<Q", raw, offset)[0]


def _class_pointer(memory: MemoryReader, address: int, label: str) -> int:
    value = _pointer(_read_exact(memory, address, 8, label), 0)
    if not is_canonical_user_pointer(value):
        raise LayoutValidationError(f"{label} class pointer is invalid")
    return value


def _array_capacity(memory: MemoryReader, array_address: int, label: str) -> int:
    raw = _read_exact(memory, array_address, IL2CPP_ARRAY_DATA_OFFSET, label)
    capacity = struct.unpack_from("<Q", raw, IL2CPP_ARRAY_LENGTH_OFFSET)[0]
    if capacity > MAX_PENDING_ACTIONS:
        raise LayoutValidationError(f"{label} capacity is implausible")
    return int(capacity)


def _pending_actions_from_array(
    memory: MemoryReader,
    array_address: int,
    indices: tuple[int, ...],
    *,
    source: str,
) -> tuple[_PendingAction, ...]:
    if not indices:
        return ()
    last = max(indices)
    raw = _read_exact(
        memory,
        array_address,
        IL2CPP_ARRAY_DATA_OFFSET + (last + 1) * PENDING_ACTION_STRIDE,
        f"{source} backing array",
    )
    values: list[_PendingAction] = []
    for logical_index, physical_index in enumerate(indices):
        offset = IL2CPP_ARRAY_DATA_OFFSET + physical_index * PENDING_ACTION_STRIDE
        action = _pointer(raw, offset + PENDING_ACTION_DELEGATE_OFFSET)
        heavy = raw[offset + PENDING_ACTION_HEAVY_OFFSET]
        if heavy not in (0, 1):
            raise LayoutValidationError(f"{source} PendingAction.Heavy is invalid")
        if action == 0:
            continue
        if not is_canonical_user_pointer(action):
            raise LayoutValidationError(f"{source} Action pointer is invalid")
        values.append(_PendingAction(action, source, logical_index))
    return tuple(values)


def _read_queue(
    memory: MemoryReader,
    address: int,
    *,
    expected_class: int,
) -> tuple[_PendingAction, ...]:
    before = _read_exact(memory, address, QUEUE_READ_SIZE, "dispatcher queue")
    if _pointer(before, 0) != expected_class:
        raise LayoutValidationError("dispatcher queue class mismatch")
    array = _pointer(before, QUEUE_ARRAY_OFFSET)
    head = struct.unpack_from("<i", before, QUEUE_HEAD_OFFSET)[0]
    tail = struct.unpack_from("<i", before, QUEUE_TAIL_OFFSET)[0]
    size = struct.unpack_from("<i", before, QUEUE_SIZE_OFFSET)[0]
    version = struct.unpack_from("<i", before, QUEUE_VERSION_OFFSET)[0]
    if size == 0:
        if head < 0 or tail < 0 or version < 0:
            raise LayoutValidationError("dispatcher queue empty shape is invalid")
        if _read_exact(memory, address, QUEUE_READ_SIZE, "dispatcher queue") != before:
            raise LayoutValidationError("dispatcher queue changed during read")
        return ()
    capacity = _array_capacity(memory, array, "dispatcher queue array")
    if (
        capacity <= 0
        or not 0 <= size <= capacity
        or not 0 <= head < capacity
        or not 0 <= tail < capacity
        or tail != (head + size) % capacity
        or version < 0
    ):
        raise LayoutValidationError("dispatcher queue shape is invalid")
    indices = tuple((head + item) % capacity for item in range(size))
    values = _pending_actions_from_array(
        memory, array, indices, source="execution_queue"
    )
    if _read_exact(memory, address, QUEUE_READ_SIZE, "dispatcher queue") != before:
        raise LayoutValidationError("dispatcher queue changed during read")
    return values


def _read_list(
    memory: MemoryReader,
    address: int,
    *,
    expected_class: int,
) -> tuple[_PendingAction, ...]:
    before = _read_exact(memory, address, LIST_READ_SIZE, "dispatcher drain list")
    if _pointer(before, 0) != expected_class:
        raise LayoutValidationError("dispatcher drain list class mismatch")
    array = _pointer(before, LIST_ARRAY_OFFSET)
    size = struct.unpack_from("<i", before, LIST_SIZE_OFFSET)[0]
    version = struct.unpack_from("<i", before, LIST_VERSION_OFFSET)[0]
    if size == 0:
        if version < 0:
            raise LayoutValidationError("dispatcher drain list version is invalid")
        if _read_exact(memory, address, LIST_READ_SIZE, "dispatcher drain list") != before:
            raise LayoutValidationError("dispatcher drain list changed during read")
        return ()
    capacity = _array_capacity(memory, array, "dispatcher drain array")
    if not 0 <= size <= capacity or version < 0:
        raise LayoutValidationError("dispatcher drain list shape is invalid")
    values = _pending_actions_from_array(
        memory, array, tuple(range(size)), source="drain_buffer"
    )
    if _read_exact(memory, address, LIST_READ_SIZE, "dispatcher drain list") != before:
        raise LayoutValidationError("dispatcher drain list changed during read")
    return values


class DispatcherChatRootReader:
    """Resolve and traverse exact current dispatcher-owned chat callbacks."""

    def __init__(self, memory: MemoryReader, resolver: TypeInfoResolver) -> None:
        self._memory = memory
        self._resolver = resolver
        self._resolved: tuple[int, int, int, int, int] | None = None

    def _resolve(self) -> tuple[int, int, int, int, int]:
        if self._resolved is not None:
            return self._resolved
        dispatcher_class = self._resolver.resolve_type_info_class(
            UNITY_MAIN_THREAD_DISPATCHER_TYPE_INFO_RVA
        )
        queue_class = self._resolver.resolve_type_info_class(
            UNITY_PENDING_ACTION_QUEUE_TYPE_INFO_RVA
        )
        list_class = self._resolver.resolve_type_info_class(
            UNITY_PENDING_ACTION_LIST_TYPE_INFO_RVA
        )
        closure_class = self._resolver.resolve_type_info_class(
            CHAT_SERVICE_MESSAGE_CLOSURE_TYPE_INFO_RVA
        )
        if None in (dispatcher_class, queue_class, list_class, closure_class):
            raise LayoutValidationError("dispatcher type-info is unavailable")
        class_raw = _read_exact(
            self._memory,
            int(dispatcher_class),
            IL2CPP_CLASS_STATIC_FIELDS_OFFSET + 8,
            "UnityMainThreadDispatcher class",
        )
        static_fields = _pointer(class_raw, IL2CPP_CLASS_STATIC_FIELDS_OFFSET)
        if not is_canonical_user_pointer(static_fields):
            raise LayoutValidationError("dispatcher static-fields pointer is invalid")
        self._resolved = (
            int(dispatcher_class),
            int(queue_class),
            int(list_class),
            int(closure_class),
            static_fields,
        )
        return self._resolved

    def read(self) -> tuple[DispatcherChatMessageRoot, ...]:
        (
            dispatcher_class,
            queue_class,
            list_class,
            closure_class,
            static_fields,
        ) = self._resolve()
        static_before = _read_exact(
            self._memory, static_fields, 0x18, "UnityMainThreadDispatcher static fields"
        )
        instance = _pointer(static_before, DISPATCHER_STATIC_INSTANCE_OFFSET)
        queue = _pointer(static_before, DISPATCHER_STATIC_QUEUE_OFFSET)

        actions: list[_PendingAction] = []
        if queue:
            actions.extend(
                _read_queue(self._memory, queue, expected_class=int(queue_class))
            )
        if instance:
            if _class_pointer(self._memory, instance, "dispatcher instance") != dispatcher_class:
                raise LayoutValidationError("dispatcher instance class mismatch")
            drain = _pointer(
                _read_exact(
                    self._memory,
                    instance + DISPATCHER_DRAIN_BUFFER_OFFSET,
                    8,
                    "dispatcher drain buffer field",
                ),
                0,
            )
            if drain:
                actions.extend(
                    _read_list(self._memory, drain, expected_class=int(list_class))
                )
        if (
            _read_exact(
                self._memory,
                static_fields,
                0x18,
                "UnityMainThreadDispatcher static fields",
            )
            != static_before
        ):
            raise LayoutValidationError("dispatcher roots changed during read")

        roots: dict[int, DispatcherChatMessageRoot] = {}
        for item in actions:
            action = _read_exact(
                self._memory,
                item.action_address,
                DELEGATE_TARGET_OFFSET + 8,
                f"{item.source} Action",
            )
            target = _pointer(action, DELEGATE_TARGET_OFFSET)
            if not is_canonical_user_pointer(target):
                continue
            closure_before = _read_exact(
                self._memory,
                target,
                CLOSURE_MESSAGE_OFFSET + 8,
                "ChatService callback closure",
            )
            if _pointer(closure_before, 0) != closure_class:
                continue
            message = _pointer(closure_before, CLOSURE_MESSAGE_OFFSET)
            if not is_canonical_user_pointer(message):
                continue
            json_pointer = _pointer(closure_before, CLOSURE_JSON_OFFSET)
            json_address = (
                json_pointer if is_canonical_user_pointer(json_pointer) else None
            )
            if (
                _read_exact(
                    self._memory,
                    target,
                    CLOSURE_MESSAGE_OFFSET + 8,
                    "ChatService callback closure",
                )
                != closure_before
            ):
                raise LayoutValidationError("ChatService callback changed during read")
            roots.setdefault(
                message,
                DispatcherChatMessageRoot(
                    message_address=message,
                    closure_address=target,
                    action_address=item.action_address,
                    source=item.source,
                    logical_index=item.logical_index,
                    json_address=json_address,
                ),
            )
        return tuple(roots.values())


__all__ = ["DispatcherChatMessageRoot", "DispatcherChatRootReader"]
