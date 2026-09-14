"""Read-only IL2CPP singleton resolution for the verified Pokiguard build.

This module deliberately does not initialize IL2CPP metadata, invoke methods, or
write target memory. It only follows global slots and layouts verified in the
local reverse output for this exact GameAssembly.dll.
"""

from __future__ import annotations

import ctypes
from ctypes import wintypes
from dataclasses import dataclass
import os
import struct
from typing import Protocol


POINTER_SIZE = 8
MAX_USER_ADDRESS = 0x00007FFFFFFFFFFF
# Unity 6000.7.0a4 / Pokiguard 1.7.4 live-verified Il2CppClass layout.
# Bounded RPM checks across ManagerQuangTruong, ManagerRoom and WsRoomService
# all resolve their static-field blocks at +0x98; +0xB8 is null in this build.
IL2CPP_CLASS_STATIC_FIELDS_OFFSET = 0x98

# Verified for the current Pokiguard 1.7.4-b4 / metadata 110 build with
# Il2CppInspector output under reverse/reverse_1.7.4-b4 (preferred image base
# 0x180000000). game_location gates attachment by the exact b4 hash.
BOARD_TYPE_INFO_RVA = 0x33558A0
ACTIVE_TYPE_INFO_RVA = 0x3355698
MANAGER_MATCH_TYPE_INFO_RVA = 0x3350170
MATCH_SERVICE_TYPE_INFO_RVA = 0x334A100
CHAT_SERVICE_TYPE_INFO_RVA = 0x3349A90
# Repeated ChatService native bodies initialize this slot immediately before
# ``typeof(ChatMessageDTO)`` / ``il2cpp_codegen_object_new``.
CHAT_MESSAGE_DTO_TYPE_INFO_RVA = 0x335B9A8
HUB_SUSPEND_MANAGER_TYPE_INFO_RVA = 0x3349AD8
MATCH_HOST_TYPE_INFO_RVA = 0x334BB28
MATCH_SCENE_LOADER_TYPE_INFO_RVA = 0x334B8E8
TURN_ANNOUNCER_TYPE_INFO_RVA = 0x3349E00
DOT_TYPE_INFO_RVA = 0x3359050
WS_COMBAT_BATCH_TYPE_INFO_RVA = 0x335F580
BOARD_WS_APPLIER_TYPE_INFO_RVA = 0x3349D48
CARD_UI_TYPE_INFO_RVA = 0x334A080
FUSION_CARD_UI_TYPE_INFO_RVA = 0x3386C78
ACTIVE_PLAYER_STATS_TYPE_INFO_RVA = 0x33415B0
PET_USER_DTO_TYPE_INFO_RVA = 0x336C5A8
CARD_DATA_TYPE_INFO_RVA = 0x3386C80
# Audition V3 roots from the exact b4 Il2CppInspector output.  AuditionStage is
# a managed state object; its first static field owns the current stage.
AUDITION_STAGE_TYPE_INFO_RVA = 0x332D328
AUDITION_CHALLENGE_TYPE_INFO_RVA = 0x332CFB8
# Read-only websocket-dispatch roots verified in the 1.7.4-b4 Inspector output.
# ``ChatService.OnWebSocketMessage`` captures the fully deserialized
# ``ChatMessageDTO`` in this closure before enqueuing its Action on
# ``UnityMainThreadDispatcher``.  These are type-info slots, never absolute
# runtime addresses; the normal module-base + RVA resolver remains mandatory.
CHAT_SERVICE_MESSAGE_CLOSURE_TYPE_INFO_RVA = 0x335BAB8
UNITY_MAIN_THREAD_DISPATCHER_TYPE_INFO_RVA = 0x335BC08
UNITY_PENDING_ACTION_LIST_TYPE_INFO_RVA = 0x33665E0
UNITY_PENDING_ACTION_QUEUE_TYPE_INFO_RVA = 0x3366628

BOARD_WIDTH_OFFSET = 0x88
BOARD_HEIGHT_OFFSET = 0x8C
BOARD_ALL_DOTS_OFFSET = 0x150
BOARD_ACTIVE_OFFSET = 0x168
BOARD_IS_CASCADE_RUNNING_OFFSET = 0x180
BOARD_IS_READY_OFFSET = 0x398
BOARD_CURRENT_STATE_OFFSET = 0x78
BOARD_HAS_DESTROYED_THIS_TURN_OFFSET = 0x125
BOARD_IS_MEGA2_PANEL_OPEN_OFFSET = 0x129
BOARD_IS_PROCESSING_UI_OFFSET = 0x1E0
BOARD_IS_GAME_OVER_OFFSET = 0x2E0
BOARD_IS_USING_LEGEND_CARD_OFFSET = 0x399
BOARD_IS_USING_MEGA_OFFSET = 0x3A0
BOARD_IS_RESUMING_OFFSET = 0x3B8
BOARD_IS_MEGA1_PANEL_OPEN_OFFSET = 0x478
ACTIVE_BOARD_OFFSET = 0x38
MATCH_SERVICE_TURN_NUMBER_OFFSET = 0x40
MATCH_SERVICE_TURN_DURATION_SEC_OFFSET = 0x44
MATCH_SERVICE_CURRENT_MATCH_ID_OFFSET = 0x20
MATCH_SERVICE_CURRENT_TURN_PLAYER_OFFSET = 0x38
MATCH_SERVICE_FUSION_ENABLED_OFFSET = 0x98
MATCH_SERVICE_FUSION_MANA_COST_OFFSET = 0x9C
MATCH_SERVICE_FUSION_STAT_PERCENT_OFFSET = 0xA0
MATCH_SERVICE_LOCAL_FUSION_USED_OFFSET = 0xA4
MATCH_SERVICE_LOCAL_FUSION_LAST_ATTEMPT_TURN_OFFSET = 0xA8
MATCH_SERVICE_LOCAL_FUSION_SELECTED_USER_PET_ID_OFFSET = 0xB0
MATCH_SERVICE_LOCAL_FUSION_SELECTED_PET_ID_OFFSET = 0xB8
MATCH_SERVICE_LOCAL_FUSION_SKILL_CARD_OFFSET = 0xC0
MATCH_SERVICE_LOCAL_FUSION_DROP_REASON_OFFSET = 0xC8
MATCH_SERVICE_TURN_TIME_REMAINING_SEC_OFFSET = 0x190
MATCH_SERVICE_LOCAL_SEQ_NUM_OFFSET = 0x110
MATCH_SERVICE_PENDING_COMBAT_OFFSET = 0x200
MATCH_SERVICE_LAST_REJECT_CARD_ID_OFFSET = 0x2E8
MATCH_SERVICE_HAS_SERVER_CLOCK_OFFSET = 0x1BC
MATCH_SERVICE_CLOCK_PAUSED_OFFSET = 0x1BD
MATCH_SERVICE_CLOCK_PAUSE_REASON_OFFSET = 0x1C0
MATCH_SERVICE_IN_FLIGHT_BATCHES_OFFSET = 0x208
MATCH_SERVICE_MATCH_OVER_OFFSET = 0x243
MATCH_SERVICE_RESYNC_COROUTINE_OFFSET = 0x248
MATCH_SERVICE_LAST_MOVE_FROM_COL_OFFSET = 0x250
MATCH_SERVICE_LAST_MOVE_FROM_ROW_OFFSET = 0x254
MATCH_SERVICE_LAST_MOVE_TO_COL_OFFSET = 0x258
MATCH_SERVICE_LAST_MOVE_TO_ROW_OFFSET = 0x25C
MATCH_SERVICE_LAST_MOVE_SEQ_NUM_OFFSET = 0x260
MATCH_SERVICE_DEFERRED_WINNER_OFFSET = 0x2F8
MATCH_SERVICE_HAS_DEFERRED_GAME_OVER_OFFSET = 0x300
BOARD_RESULT_TITLE_OFFSET = 0x2A8
UNITY_UI_TEXT_VALUE_OFFSET = 0xE8
CHAT_SERVICE_IS_CONNECTED_OFFSET = 0x28
CHAT_SERVICE_USERNAME_OFFSET = 0x30
CHAT_SERVICE_EXPLICIT_DISCONNECT_OFFSET = 0x2D4
CHAT_SERVICE_RECONNECT_COROUTINE_OFFSET = 0x2D8
CHAT_SERVICE_CONNECTING_OFFSET = 0x2E4
MANAGER_MATCH_ACTIVE_OFFSET = 0x130
MANAGER_MATCH_IS_BOSS_BATTLE_OFFSET = 0x138

# Static-field layouts proven by the corresponding Cpp2IL DiffableCs and ISIL
# files.  These are offsets inside Il2CppClass.static_fields, not absolute
# process addresses.
MATCH_HOST_STATE_STATIC_OFFSET = 0x04
MATCH_HOST_CURRENT_RIG_STATIC_OFFSET = 0x10
MATCH_SCENE_LOADER_IS_LOADING_STATIC_OFFSET = 0x00
MATCH_SCENE_LOADER_IS_UNLOADING_STATIC_OFFSET = 0x01
HUB_SUSPEND_MANAGER_IS_SUSPENDED_STATIC_OFFSET = 0x08
# TurnAnnouncer.IsBlockingInput reads this exact static bool before consulting
# Unity's unscaled clock. The Runner clears it when the proven three-second
# announcement block expires, so an external read of the bool is a conservative
# one-frame-safe reproduction of the game-owned input gate.
TURN_ANNOUNCER_BLOCKING_STATIC_OFFSET = 0x80
TURN_ANNOUNCER_BLOCK_DEADLINE_STATIC_OFFSET = 0x84
BOARD_WS_APPLIER_BOARD_OFFSET = 0x20
BOARD_WS_APPLIER_BOOTSTRAPPED_MATCH_ID_OFFSET = 0x30
BOARD_WS_APPLIER_PENDING_BATCHES_OFFSET = 0x60
BOARD_WS_APPLIER_RENDER_RUNNING_OFFSET = 0x68


class ExternalReadError(RuntimeError):
    """A remote read failed or a value failed closed validation."""


class MemoryReader(Protocol):
    """Small interface used by the resolver and deterministic unit tests."""

    def read(self, address: int, size: int) -> bytes:
        ...

    def is_readable(self, address: int, size: int) -> bool:
        ...


@dataclass(frozen=True)
class SingletonSpec:
    name: str
    type_info_rva: int
    static_field_offset: int


BOARD_SINGLETON = SingletonSpec("Board", BOARD_TYPE_INFO_RVA, 0x10)
ACTIVE_SINGLETON = SingletonSpec("Active", ACTIVE_TYPE_INFO_RVA, 0x00)
MANAGER_MATCH_SINGLETON = SingletonSpec(
    "ManagerMatch", MANAGER_MATCH_TYPE_INFO_RVA, 0x00
)
MATCH_SERVICE_SINGLETON = SingletonSpec(
    "MatchService", MATCH_SERVICE_TYPE_INFO_RVA, 0x00
)
CHAT_SERVICE_SINGLETON = SingletonSpec(
    "ChatService", CHAT_SERVICE_TYPE_INFO_RVA, 0x00
)
# CardUI.<ActiveDotSkillCard>k__BackingField is the first static field.  Its
# native getter at RVA 0x6D4EC0 follows Il2CppClass.static_fields + 0x00.
# It is an observation anchor only; no method on the object is ever invoked.
ACTIVE_DOT_SKILL_CARD = SingletonSpec(
    "CardUI.ActiveDotSkillCard", CARD_UI_TYPE_INFO_RVA, 0x00
)
ACTIVE_AUDITION_STAGE = SingletonSpec(
    "PokiGuard.Audition.AuditionStage.Active",
    AUDITION_STAGE_TYPE_INFO_RVA,
    0x00,
)


@dataclass(frozen=True)
class MemoryRegion:
    """One committed readable VirtualQueryEx region."""

    base: int
    size: int
    protection: int
    memory_type: int
    # ``VirtualQueryEx`` can split one ``VirtualAlloc`` allocation into many
    # regions as protection/commit state changes.  Keeping AllocationBase lets
    # narrowly anchored scanners cover the rest of the *same* allocation
    # without guessing adjacent addresses or widening to the whole process.
    allocation_base: int | None = None

    @property
    def end(self) -> int:
        return self.base + self.size


@dataclass(frozen=True)
class SingletonResolution:
    name: str
    type_info_slot: int
    class_pointer: int | None
    static_fields: int | None
    instance: int | None
    status: str
    detail: str | None = None

    @property
    def resolved(self) -> bool:
        return self.status == "resolved" and self.instance is not None


@dataclass(frozen=True)
class BoardRuntimeState:
    board_instance: int
    width: int
    height: int
    all_dots: int | None
    active: int | None
    is_cascade_running: bool
    is_board_ready: bool
    current_state: int
    has_destroyed_this_turn: bool
    is_processing_ui: bool
    is_game_over: bool
    is_mega2_panel_open: bool
    is_mega1_panel_open: bool
    is_using_legend_card: bool
    is_using_mega: bool
    is_resuming: bool
    active_singleton: int | None
    active_board: int | None
    active_back_reference: bool | None
    board_active_matches_singleton: bool | None
    accepted: bool
    rejection_reason: str | None


def is_canonical_user_pointer(value: int) -> bool:
    """Return whether *value* can be a canonical Windows x64 user pointer."""

    return 0x10000 <= value <= MAX_USER_ADDRESS


def checked_address(base: int, offset: int) -> int:
    if not is_canonical_user_pointer(base):
        raise ExternalReadError(f"invalid base pointer 0x{base:X}")
    if offset < 0:
        raise ExternalReadError("negative offsets are not allowed")
    result = base + offset
    if result < base or result > MAX_USER_ADDRESS:
        raise ExternalReadError("address calculation overflowed user address space")
    return result


class Il2CppExternalResolver:
    """Resolve verified singleton slots without calling into the game."""

    def __init__(
        self,
        memory: MemoryReader,
        game_assembly_base: int,
        game_assembly_size: int,
    ) -> None:
        if not is_canonical_user_pointer(game_assembly_base):
            raise ValueError("invalid GameAssembly base")
        if game_assembly_size <= 0:
            raise ValueError("invalid GameAssembly size")
        module_end = game_assembly_base + game_assembly_size
        if module_end <= game_assembly_base or module_end > MAX_USER_ADDRESS + 1:
            raise ValueError("GameAssembly range overflows user address space")
        self.memory = memory
        self.game_assembly_base = game_assembly_base
        self.game_assembly_size = game_assembly_size
        self.game_assembly_end = module_end

    def _read_pointer(self, address: int) -> int:
        if not self.memory.is_readable(address, POINTER_SIZE):
            raise ExternalReadError(f"unreadable pointer address 0x{address:X}")
        raw = self.memory.read(address, POINTER_SIZE)
        if len(raw) != POINTER_SIZE:
            raise ExternalReadError(f"short pointer read at 0x{address:X}")
        return struct.unpack("<Q", raw)[0]

    def _read_i32(self, address: int) -> int:
        if not self.memory.is_readable(address, 4):
            raise ExternalReadError(f"unreadable int32 address 0x{address:X}")
        raw = self.memory.read(address, 4)
        if len(raw) != 4:
            raise ExternalReadError(f"short int32 read at 0x{address:X}")
        return struct.unpack("<i", raw)[0]

    def _read_i64(self, address: int) -> int:
        if not self.memory.is_readable(address, 8):
            raise ExternalReadError(f"unreadable int64 address 0x{address:X}")
        raw = self.memory.read(address, 8)
        if len(raw) != 8:
            raise ExternalReadError(f"short int64 read at 0x{address:X}")
        return struct.unpack("<q", raw)[0]

    def _read_bool(self, address: int) -> bool:
        if not self.memory.is_readable(address, 1):
            raise ExternalReadError(f"unreadable bool address 0x{address:X}")
        raw = self.memory.read(address, 1)
        if len(raw) != 1 or raw[0] not in (0, 1):
            value = raw[0] if raw else None
            raise ExternalReadError(f"invalid bool value {value!r} at 0x{address:X}")
        return bool(raw[0])

    def resolve_singleton(self, spec: SingletonSpec) -> SingletonResolution:
        slot = self.game_assembly_base + spec.type_info_rva
        if not self.game_assembly_base <= slot <= self.game_assembly_end - POINTER_SIZE:
            return SingletonResolution(
                spec.name, slot, None, None, None, "anchor_outside_module"
            )

        try:
            class_pointer = self._read_pointer(slot)
            if class_pointer == 0:
                return SingletonResolution(
                    spec.name, slot, None, None, None, "type_info_uninitialized"
                )
            # Before il2cpp_codegen_initialize_runtime_metadata runs, this slot may
            # contain an encoded metadata usage rather than an Il2CppClass pointer.
            if not is_canonical_user_pointer(class_pointer) or not self.memory.is_readable(
                class_pointer, IL2CPP_CLASS_STATIC_FIELDS_OFFSET + POINTER_SIZE
            ):
                return SingletonResolution(
                    spec.name,
                    slot,
                    class_pointer,
                    None,
                    None,
                    "type_info_uninitialized_or_invalid",
                )

            static_fields_address = checked_address(
                class_pointer, IL2CPP_CLASS_STATIC_FIELDS_OFFSET
            )
            static_fields = self._read_pointer(static_fields_address)
            if static_fields == 0:
                return SingletonResolution(
                    spec.name,
                    slot,
                    class_pointer,
                    None,
                    None,
                    "static_fields_null",
                )
            required_size = spec.static_field_offset + POINTER_SIZE
            if not is_canonical_user_pointer(static_fields) or not self.memory.is_readable(
                static_fields, required_size
            ):
                return SingletonResolution(
                    spec.name,
                    slot,
                    class_pointer,
                    static_fields,
                    None,
                    "static_fields_invalid",
                )

            instance = self._read_pointer(
                checked_address(static_fields, spec.static_field_offset)
            )
            if instance == 0:
                return SingletonResolution(
                    spec.name,
                    slot,
                    class_pointer,
                    static_fields,
                    None,
                    "instance_null",
                )
            if not is_canonical_user_pointer(instance) or not self.memory.is_readable(
                instance, 0x10
            ):
                return SingletonResolution(
                    spec.name,
                    slot,
                    class_pointer,
                    static_fields,
                    instance,
                    "instance_invalid",
                )
            return SingletonResolution(
                spec.name, slot, class_pointer, static_fields, instance, "resolved"
            )
        except (ExternalReadError, OSError) as exc:
            return SingletonResolution(
                spec.name,
                slot,
                locals().get("class_pointer"),
                locals().get("static_fields"),
                None,
                "read_error",
                str(exc),
            )

    def resolve_known_singletons(self) -> dict[str, SingletonResolution]:
        return {
            spec.name: self.resolve_singleton(spec)
            for spec in (
                BOARD_SINGLETON,
                ACTIVE_SINGLETON,
                MANAGER_MATCH_SINGLETON,
                MATCH_SERVICE_SINGLETON,
                CHAT_SERVICE_SINGLETON,
            )
        }

    def read_pointer(self, address: int) -> int:
        """Read a validated target pointer without relaxing fail-closed checks."""

        return self._read_pointer(address)

    def read_i32(self, address: int) -> int:
        """Read a validated signed int32 from the target."""

        return self._read_i32(address)

    def read_i64(self, address: int) -> int:
        """Read a validated signed int64 from the target."""

        return self._read_i64(address)

    def read_bool(self, address: int) -> bool:
        """Read a target bool that must be encoded as exactly zero or one."""

        return self._read_bool(address)

    def resolve_type_info_class(self, type_info_rva: int) -> int | None:
        """Resolve a verified build-specific type-info global slot.

        A NULL or still-encoded metadata usage is reported as unavailable.  No
        target method is invoked to force initialization.
        """

        slot = self.game_assembly_base + type_info_rva
        if not self.game_assembly_base <= slot <= self.game_assembly_end - POINTER_SIZE:
            raise ExternalReadError("type-info anchor is outside GameAssembly")
        value = self._read_pointer(slot)
        if value == 0:
            return None
        if not is_canonical_user_pointer(value) or not self.memory.is_readable(value, 8):
            return None
        return value

    def read_board(
        self,
        board_instance: int,
        active_singleton: int | None = None,
    ) -> BoardRuntimeState:
        if not is_canonical_user_pointer(board_instance) or not self.memory.is_readable(
            board_instance, BOARD_IS_MEGA1_PANEL_OPEN_OFFSET + 1
        ):
            raise ExternalReadError("Board instance range is not readable")

        width = self._read_i32(checked_address(board_instance, BOARD_WIDTH_OFFSET))
        height = self._read_i32(checked_address(board_instance, BOARD_HEIGHT_OFFSET))
        all_dots_value = self._read_pointer(
            checked_address(board_instance, BOARD_ALL_DOTS_OFFSET)
        )
        active_value = self._read_pointer(
            checked_address(board_instance, BOARD_ACTIVE_OFFSET)
        )
        cascade = self._read_bool(
            checked_address(board_instance, BOARD_IS_CASCADE_RUNNING_OFFSET)
        )
        ready = self._read_bool(checked_address(board_instance, BOARD_IS_READY_OFFSET))
        current_state = self._read_i32(
            checked_address(board_instance, BOARD_CURRENT_STATE_OFFSET)
        )
        has_destroyed = self._read_bool(
            checked_address(board_instance, BOARD_HAS_DESTROYED_THIS_TURN_OFFSET)
        )
        processing_ui = self._read_bool(
            checked_address(board_instance, BOARD_IS_PROCESSING_UI_OFFSET)
        )
        game_over = self._read_bool(
            checked_address(board_instance, BOARD_IS_GAME_OVER_OFFSET)
        )
        mega2_panel = self._read_bool(
            checked_address(board_instance, BOARD_IS_MEGA2_PANEL_OPEN_OFFSET)
        )
        mega1_panel = self._read_bool(
            checked_address(board_instance, BOARD_IS_MEGA1_PANEL_OPEN_OFFSET)
        )
        using_legend = self._read_bool(
            checked_address(board_instance, BOARD_IS_USING_LEGEND_CARD_OFFSET)
        )
        using_mega = self._read_bool(
            checked_address(board_instance, BOARD_IS_USING_MEGA_OFFSET)
        )
        resuming = self._read_bool(
            checked_address(board_instance, BOARD_IS_RESUMING_OFFSET)
        )

        all_dots = all_dots_value or None
        active = active_value or None
        active_board: int | None = None
        active_back_reference: bool | None = None
        board_active_matches: bool | None = None

        if active_singleton is not None:
            if not is_canonical_user_pointer(active_singleton) or not self.memory.is_readable(
                active_singleton, ACTIVE_BOARD_OFFSET + POINTER_SIZE
            ):
                raise ExternalReadError("Active singleton range is not readable")
            active_board_value = self._read_pointer(
                checked_address(active_singleton, ACTIVE_BOARD_OFFSET)
            )
            active_board = active_board_value or None
            active_back_reference = active_board == board_instance
            if active is not None:
                board_active_matches = active == active_singleton

        reasons: list[str] = []
        if width != 8 or height != 8:
            reasons.append(f"unexpected dimensions {width}x{height}")
        if current_state not in (0, 1):
            reasons.append(f"invalid Board.currentState {current_state}")
        if all_dots is None:
            reasons.append("allDots is null")
        elif not is_canonical_user_pointer(all_dots) or not self.memory.is_readable(
            all_dots, 0x20
        ):
            reasons.append("allDots is not a readable managed-array candidate")
        if active_back_reference is False:
            reasons.append("Active.board does not point back to Board")
        if board_active_matches is False:
            reasons.append("Board.active does not match Active.Instance")

        return BoardRuntimeState(
            board_instance=board_instance,
            width=width,
            height=height,
            all_dots=all_dots,
            active=active,
            is_cascade_running=cascade,
            is_board_ready=ready,
            current_state=current_state,
            has_destroyed_this_turn=has_destroyed,
            is_processing_ui=processing_ui,
            is_game_over=game_over,
            is_mega2_panel_open=mega2_panel,
            is_mega1_panel_open=mega1_panel,
            is_using_legend_card=using_legend,
            is_using_mega=using_mega,
            is_resuming=resuming,
            active_singleton=active_singleton,
            active_board=active_board,
            active_back_reference=active_back_reference,
            board_active_matches_singleton=board_active_matches,
            accepted=not reasons,
            rejection_reason="; ".join(reasons) if reasons else None,
        )


if os.name == "nt":
    MEM_COMMIT = 0x1000
    PAGE_NOACCESS = 0x01
    PAGE_GUARD = 0x100
    READABLE_PAGE_TYPES = {
        0x02,  # PAGE_READONLY
        0x04,  # PAGE_READWRITE
        0x08,  # PAGE_WRITECOPY
        0x20,  # PAGE_EXECUTE_READ
        0x40,  # PAGE_EXECUTE_READWRITE
        0x80,  # PAGE_EXECUTE_WRITECOPY
    }

    class MEMORY_BASIC_INFORMATION(ctypes.Structure):
        _fields_ = [
            ("BaseAddress", wintypes.LPVOID),
            ("AllocationBase", wintypes.LPVOID),
            ("AllocationProtect", wintypes.DWORD),
            ("PartitionId", wintypes.WORD),
            ("RegionSize", ctypes.c_size_t),
            ("State", wintypes.DWORD),
            ("Protect", wintypes.DWORD),
            ("Type", wintypes.DWORD),
        ]

    _kernel32 = ctypes.WinDLL("kernel32", use_last_error=True)
    _kernel32.ReadProcessMemory.argtypes = [
        wintypes.HANDLE,
        wintypes.LPCVOID,
        wintypes.LPVOID,
        ctypes.c_size_t,
        ctypes.POINTER(ctypes.c_size_t),
    ]
    _kernel32.ReadProcessMemory.restype = wintypes.BOOL
    _kernel32.VirtualQueryEx.argtypes = [
        wintypes.HANDLE,
        wintypes.LPCVOID,
        ctypes.POINTER(MEMORY_BASIC_INFORMATION),
        ctypes.c_size_t,
    ]
    _kernel32.VirtualQueryEx.restype = ctypes.c_size_t


class Win32RemoteMemory:
    """Read and validate committed target memory through an existing handle."""

    def __init__(self, process_handle: int) -> None:
        if os.name != "nt":
            raise OSError("Win32RemoteMemory is Windows-only")
        if not process_handle:
            raise ValueError("invalid process handle")
        self.process_handle = process_handle

    def read(self, address: int, size: int) -> bytes:
        if not is_canonical_user_pointer(address) or size <= 0:
            raise ExternalReadError("invalid remote read range")
        buffer = (ctypes.c_ubyte * size)()
        bytes_read = ctypes.c_size_t()
        if not _kernel32.ReadProcessMemory(
            self.process_handle,
            ctypes.c_void_p(address),
            buffer,
            size,
            ctypes.byref(bytes_read),
        ):
            raise ctypes.WinError(ctypes.get_last_error())
        if bytes_read.value != size:
            raise ExternalReadError(
                f"short ReadProcessMemory at 0x{address:X}: {bytes_read.value}/{size}"
            )
        return bytes(buffer)

    def is_readable(self, address: int, size: int) -> bool:
        if not is_canonical_user_pointer(address) or size <= 0:
            return False
        end = address + size
        if end <= address or end > MAX_USER_ADDRESS + 1:
            return False

        current = address
        while current < end:
            info = MEMORY_BASIC_INFORMATION()
            result = _kernel32.VirtualQueryEx(
                self.process_handle,
                ctypes.c_void_p(current),
                ctypes.byref(info),
                ctypes.sizeof(info),
            )
            if result != ctypes.sizeof(info):
                return False
            base = ctypes.cast(info.BaseAddress, ctypes.c_void_p).value or 0
            region_end = base + int(info.RegionSize)
            protection = int(info.Protect)
            basic_protection = protection & 0xFF
            if (
                info.State != MEM_COMMIT
                or protection & (PAGE_NOACCESS | PAGE_GUARD)
                or basic_protection not in READABLE_PAGE_TYPES
                or region_end <= current
            ):
                return False
            current = min(region_end, end)
        return True

    def iter_readable_regions(
        self,
        start: int = 0x10000,
        end: int = MAX_USER_ADDRESS + 1,
    ):
        """Yield committed readable regions without touching their contents."""

        if start < 0x10000 or end <= start or end > MAX_USER_ADDRESS + 1:
            raise ValueError("invalid VirtualQueryEx range")
        current = start
        while current < end:
            info = MEMORY_BASIC_INFORMATION()
            result = _kernel32.VirtualQueryEx(
                self.process_handle,
                ctypes.c_void_p(current),
                ctypes.byref(info),
                ctypes.sizeof(info),
            )
            if result == 0:
                break
            base = ctypes.cast(info.BaseAddress, ctypes.c_void_p).value or current
            size = int(info.RegionSize)
            region_end = base + size
            protection = int(info.Protect)
            basic_protection = protection & 0xFF
            if (
                size > 0
                and info.State == MEM_COMMIT
                and not protection & (PAGE_NOACCESS | PAGE_GUARD)
                and basic_protection in READABLE_PAGE_TYPES
            ):
                clipped_base = max(base, start)
                clipped_end = min(region_end, end)
                if clipped_end > clipped_base:
                    yield MemoryRegion(
                        clipped_base,
                        clipped_end - clipped_base,
                        protection,
                        int(info.Type),
                        ctypes.cast(info.AllocationBase, ctypes.c_void_p).value,
                    )
            if region_end <= current:
                break
            current = region_end
