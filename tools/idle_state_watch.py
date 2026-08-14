#!/usr/bin/env python3
"""Read-only watcher for server AFK/idle evidence and adjacent real actions.

The watcher never maintains a gameplay PASS counter.  It records the exact
``idleCount``/``threshold`` carried by current-match server messages when those
managed DTOs are observable, plus durable MatchService/Fusion/CardUI changes
needed to study reset semantics later.
"""

from __future__ import annotations

import argparse
from dataclasses import asdict, dataclass, is_dataclass
from enum import Enum
import json
from pathlib import Path
import struct
import sys
import time
from typing import Any, Iterable, Mapping, Sequence


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.acked_sequences import read_acked_sequences  # noqa: E402
from pokiguard_v2.game_owned_idle import GameOwnedIdleCache  # noqa: E402
from pokiguard_v2.il2cpp_external import (  # noqa: E402
    ACTIVE_SINGLETON,
    ACTIVE_PLAYER_STATS_TYPE_INFO_RVA,
    BOARD_SINGLETON,
    CHAT_SERVICE_SINGLETON,
    CHAT_SERVICE_USERNAME_OFFSET,
    MATCH_SERVICE_CURRENT_MATCH_ID_OFFSET,
    MATCH_SERVICE_CURRENT_TURN_PLAYER_OFFSET,
    MATCH_SERVICE_LAST_MOVE_FROM_COL_OFFSET,
    MATCH_SERVICE_LAST_MOVE_FROM_ROW_OFFSET,
    MATCH_SERVICE_LAST_MOVE_SEQ_NUM_OFFSET,
    MATCH_SERVICE_LAST_MOVE_TO_COL_OFFSET,
    MATCH_SERVICE_LAST_MOVE_TO_ROW_OFFSET,
    MATCH_SERVICE_LOCAL_SEQ_NUM_OFFSET,
    MATCH_SERVICE_SINGLETON,
    MATCH_SERVICE_TURN_NUMBER_OFFSET,
    MATCH_SERVICE_TURN_TIME_REMAINING_SEC_OFFSET,
    ExternalReadError,
    is_canonical_user_pointer,
)
from pokiguard_v2.il2cpp_layout import (  # noqa: E402
    LayoutValidationError,
    read_il2cpp_string,
)
from pokiguard_v2.memory_scan import (  # noqa: E402
    bounded_private_writable_regions,
    regions_containing_addresses,
    scan_aligned_qwords,
)
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
)
from pokiguard_v2.player_stats import read_active_participants  # noqa: E402
from pokiguard_v2.state import GamePhase  # noqa: E402
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.runtime_common import attach_target, default_log_path, hex_pointer  # noqa: E402


# Repeated ChatService native bodies initialize this slot immediately before
# ``typeof(ChatMessageDTO)`` / ``il2cpp_codegen_object_new``.
CHAT_MESSAGE_DTO_TYPE_INFO_RVA = 0x350F660
CHAT_MESSAGE_TYPE_OFFSET = 0x30
CHAT_MESSAGE_USERNAME_OFFSET = 0x18
CHAT_MESSAGE_TIMESTAMP_OFFSET = 0x28
CHAT_MESSAGE_MATCH_ID_OFFSET = 0xB0
CHAT_MESSAGE_SEQ_NUM_OFFSET = 0xB8
CHAT_MESSAGE_PAYLOAD_OFFSET = 0xC8
CHAT_MESSAGE_FROM_COL_OFFSET = 0xD0
CHAT_MESSAGE_FROM_ROW_OFFSET = 0xD8
CHAT_MESSAGE_TO_COL_OFFSET = 0xE0
CHAT_MESSAGE_TO_ROW_OFFSET = 0xE8
CHAT_MESSAGE_CARD_ID_OFFSET = 0xF0
CHAT_MESSAGE_REJECT_REASON_OFFSET = 0x100
CHAT_MESSAGE_SKILL_CARD_ID_OFFSET = 0x108

DICTIONARY_ENTRIES_OFFSET = 0x18
DICTIONARY_COUNT_OFFSET = 0x20
DICTIONARY_FREE_COUNT_OFFSET = 0x28
ARRAY_LENGTH_OFFSET = 0x18
ARRAY_DATA_OFFSET = 0x20
DICTIONARY_ENTRY_SIZE = 0x18
ENTRY_HASH_OFFSET = 0x00
ENTRY_KEY_OFFSET = 0x08
ENTRY_VALUE_OFFSET = 0x10
JOBJECT_PROPERTIES_OFFSET = 0x58
JPROPERTY_COLLECTION_DICTIONARY_OFFSET = 0x18
JPROPERTY_CONTENT_OFFSET = 0x58
JPROPERTY_LIST_TOKEN_OFFSET = 0x10
JVALUE_VALUE_OFFSET = 0x38

SERVER_EVENT_TYPES = frozenset(
    {
        "MATCH_AFK_WARN",
        "MATCH_TURN_END",
        "MATCH_MOVE_RES",
        "MATCH_CARD_USE_RES",
        "MATCH_SKILL_USE_RES",
        "MATCH_FUSION_RES",
        "MATCH_REJECT",
        "FORCE_RESYNC",
        "MATCH_SKILL_CAST",
        "MATCH_START",
        "MATCH_STARTING",
    }
)


@dataclass(frozen=True)
class MatchRuntime:
    match_id: str | None
    turn: int | None
    current_player: str | None
    local_username: str | None
    remaining: int | None
    local_move_sequence: int | None
    last_move_sequence: int | None
    last_move_from_col: int | None
    last_move_from_row: int | None
    last_move_to_col: int | None
    last_move_to_row: int | None
    highest_acked_sequence: int | None


@dataclass(frozen=True)
class ServerMessage:
    address: int
    event_type: str
    match_id: str
    timestamp: str | None
    username: str | None
    payload_address: int | None
    server_sequence: int | None
    from_col: int | None
    from_row: int | None
    to_col: int | None
    to_row: int | None
    card_id: int | None
    skill_card_id: int | None
    reject_reason: str | None
    idle_count: int | None
    threshold: int | None
    payload_ints: tuple[tuple[str, int], ...]
    payload_bools: tuple[tuple[str, bool], ...]
    payload_strings: tuple[tuple[str, str], ...]

    @property
    def source_turn(self) -> int | None:
        return dict(self.payload_ints).get("turnNumber")


def _jsonable(value: Any) -> Any:
    if is_dataclass(value):
        return _jsonable(asdict(value))
    if isinstance(value, Enum):
        return value.value
    if isinstance(value, dict):
        return {str(key): _jsonable(item) for key, item in value.items()}
    if isinstance(value, (tuple, list)):
        return [_jsonable(item) for item in value]
    return value


def _utc_timestamp() -> str:
    return time.strftime("%Y-%m-%dT%H:%M:%S", time.gmtime()) + (
        f".{int(time.time_ns() / 1_000_000) % 1000:03d}Z"
    )


def _write(log: Any, event: str, **fields: Any) -> None:
    payload = {
        "timestamp": _utc_timestamp(),
        "event": event,
        **fields,
    }
    log.write(json.dumps(_jsonable(payload), ensure_ascii=False, separators=(",", ":")) + "\n")
    # Preserve evidence if the background watcher is interrupted and make the
    # file auditable while combat is still in progress on Windows.
    log.flush()


def _read_pointer(memory: Any, address: int) -> int:
    raw = memory.read(address, 8)
    if len(raw) != 8:
        raise ExternalReadError("short pointer read")
    return struct.unpack("<Q", raw)[0]


def _read_i32(memory: Any, address: int) -> int:
    raw = memory.read(address, 4)
    if len(raw) != 4:
        raise ExternalReadError("short int32 read")
    return struct.unpack("<i", raw)[0]


def _read_i64(memory: Any, address: int) -> int:
    raw = memory.read(address, 8)
    if len(raw) != 8:
        raise ExternalReadError("short int64 read")
    return struct.unpack("<q", raw)[0]


def _read_nullable_i32(memory: Any, address: int) -> int | None:
    raw = memory.read(address, 8)
    if len(raw) != 8:
        raise ExternalReadError("short Nullable<Int32> read")
    has_value = raw[0]
    if has_value not in (0, 1):
        raise LayoutValidationError("Nullable<Int32>.hasValue is invalid")
    return struct.unpack_from("<i", raw, 4)[0] if has_value else None


def _read_nullable_i64(memory: Any, address: int) -> int | None:
    raw = memory.read(address, 16)
    if len(raw) != 16:
        raise ExternalReadError("short Nullable<Int64> read")
    has_value = raw[0]
    if has_value not in (0, 1):
        raise LayoutValidationError("Nullable<Int64>.hasValue is invalid")
    return struct.unpack_from("<q", raw, 8)[0] if has_value else None


def _string_field(memory: Any, instance: int, offset: int) -> str | None:
    pointer = _read_pointer(memory, instance + offset)
    if not is_canonical_user_pointer(pointer):
        return None
    value = read_il2cpp_string(memory, pointer, max_length=512)
    return value or None


def read_dictionary_entries(
    memory: Any, address: int, *, max_entries: int = 128
) -> Mapping[str, int]:
    """Read a Dictionary<string,object> entry table as key -> value pointer."""

    if not is_canonical_user_pointer(address):
        raise LayoutValidationError("dictionary pointer is not canonical")
    entries = _read_pointer(memory, address + DICTIONARY_ENTRIES_OFFSET)
    count = _read_i32(memory, address + DICTIONARY_COUNT_OFFSET)
    free_count = _read_i32(memory, address + DICTIONARY_FREE_COUNT_OFFSET)
    if not 0 <= free_count <= count <= max_entries:
        raise LayoutValidationError("dictionary count/freeCount is invalid")
    if count == 0:
        return {}
    if not is_canonical_user_pointer(entries):
        raise LayoutValidationError("dictionary entries pointer is invalid")
    capacity = _read_i64(memory, entries + ARRAY_LENGTH_OFFSET)
    if not count <= capacity <= max_entries * 4:
        raise LayoutValidationError("dictionary entries array length is invalid")

    output: dict[str, int] = {}
    for index in range(count):
        entry = entries + ARRAY_DATA_OFFSET + index * DICTIONARY_ENTRY_SIZE
        hash_code = _read_i32(memory, entry + ENTRY_HASH_OFFSET)
        if hash_code < 0:
            continue
        key_pointer = _read_pointer(memory, entry + ENTRY_KEY_OFFSET)
        value_pointer = _read_pointer(memory, entry + ENTRY_VALUE_OFFSET)
        if not is_canonical_user_pointer(key_pointer):
            continue
        try:
            key = read_il2cpp_string(memory, key_pointer, max_length=128)
        except (ExternalReadError, OSError, LayoutValidationError):
            continue
        if key and is_canonical_user_pointer(value_pointer):
            output[key] = value_pointer
    return output


def read_small_boxed_int(memory: Any, address: int) -> int:
    """Read a boxed Int32/Int64 only when its payload is in a narrow range."""

    raw = memory.read(address + 0x10, 8)
    if len(raw) != 8:
        raise ExternalReadError("short boxed integer read")
    int64 = struct.unpack("<q", raw)[0]
    int32 = struct.unpack_from("<i", raw)[0]
    if -1 <= int64 <= 1_000_000:
        return int(int64)
    if -1 <= int32 <= 1_000_000:
        return int(int32)
    raise LayoutValidationError("boxed value is not a plausible small integer")


def read_boxed_bool(memory: Any, address: int) -> bool:
    raw = memory.read(address + 0x10, 1)
    if len(raw) != 1 or raw[0] not in (0, 1):
        raise LayoutValidationError("boxed value is not a Boolean")
    return bool(raw[0])


def read_jobject_value_pointers(memory: Any, address: int) -> Mapping[str, int]:
    """Read the value objects behind a small Newtonsoft ``JObject``.

    Cpp2IL proves ``JObject._properties +0x58`` ->
    ``JPropertyKeyedCollection._dictionary +0x18``.  Each dictionary value is a
    ``JProperty`` whose ``_content +0x58`` contains its single JToken at +0x10;
    a scalar ``JValue`` stores the underlying object at +0x38.
    """

    properties = _read_pointer(memory, address + JOBJECT_PROPERTIES_OFFSET)
    if not is_canonical_user_pointer(properties):
        raise LayoutValidationError("JObject properties pointer is invalid")
    dictionary = _read_pointer(
        memory, properties + JPROPERTY_COLLECTION_DICTIONARY_OFFSET
    )
    property_entries = read_dictionary_entries(memory, dictionary, max_entries=32)
    values: dict[str, int] = {}
    for key, jproperty in property_entries.items():
        content = _read_pointer(memory, jproperty + JPROPERTY_CONTENT_OFFSET)
        if not is_canonical_user_pointer(content):
            continue
        token = _read_pointer(memory, content + JPROPERTY_LIST_TOKEN_OFFSET)
        if not is_canonical_user_pointer(token):
            continue
        value = _read_pointer(memory, token + JVALUE_VALUE_OFFSET)
        if is_canonical_user_pointer(value):
            values[key] = value
    return values


def read_server_message(
    memory: Any,
    address: int,
    *,
    expected_class: int,
    expected_match_id: str,
) -> ServerMessage:
    if _read_pointer(memory, address) != expected_class:
        raise LayoutValidationError("ChatMessageDTO class mismatch")
    event_type = _string_field(memory, address, CHAT_MESSAGE_TYPE_OFFSET)
    match_id = _string_field(memory, address, CHAT_MESSAGE_MATCH_ID_OFFSET)
    if event_type not in SERVER_EVENT_TYPES or match_id != expected_match_id:
        raise LayoutValidationError("message does not belong to the current match")
    timestamp = _string_field(memory, address, CHAT_MESSAGE_TIMESTAMP_OFFSET)
    username = _string_field(memory, address, CHAT_MESSAGE_USERNAME_OFFSET)
    server_sequence = _read_nullable_i64(memory, address + CHAT_MESSAGE_SEQ_NUM_OFFSET)
    from_col = _read_nullable_i32(memory, address + CHAT_MESSAGE_FROM_COL_OFFSET)
    from_row = _read_nullable_i32(memory, address + CHAT_MESSAGE_FROM_ROW_OFFSET)
    to_col = _read_nullable_i32(memory, address + CHAT_MESSAGE_TO_COL_OFFSET)
    to_row = _read_nullable_i32(memory, address + CHAT_MESSAGE_TO_ROW_OFFSET)
    card_id = _read_nullable_i32(memory, address + CHAT_MESSAGE_CARD_ID_OFFSET)
    skill_card_id = _read_nullable_i32(
        memory, address + CHAT_MESSAGE_SKILL_CARD_ID_OFFSET
    )
    reject_reason = _string_field(memory, address, CHAT_MESSAGE_REJECT_REASON_OFFSET)
    payload = _read_pointer(memory, address + CHAT_MESSAGE_PAYLOAD_OFFSET)
    payload_address = payload if is_canonical_user_pointer(payload) else None
    ints: dict[str, int] = {}
    bools: dict[str, bool] = {}
    strings: dict[str, str] = {}
    if payload_address is not None:
        try:
            entries = read_dictionary_entries(memory, payload_address)
            for key in (
                "idleCount",
                "threshold",
                "turnNumber",
                "turnDurationSec",
                "turnTimeRemainingSec",
                "cardId",
                "skillCardId",
                "mana",
                "manaCur",
                "manaMax",
                "code",
                "errorCode",
            ):
                value_address = entries.get(key)
                if value_address is None:
                    continue
                try:
                    ints[key] = read_small_boxed_int(memory, value_address)
                except (ExternalReadError, OSError, LayoutValidationError):
                    continue
            for key in ("rejected", "success", "accepted"):
                value_address = entries.get(key)
                if value_address is None:
                    continue
                try:
                    bools[key] = read_boxed_bool(memory, value_address)
                except (ExternalReadError, OSError, LayoutValidationError):
                    continue
            for key in (
                "username",
                "actorUsername",
                "ownerUsername",
                "currentTurnPlayer",
                "action",
                "kind",
                "reason",
                "message",
                "error",
            ):
                value_address = entries.get(key)
                if value_address is None:
                    continue
                try:
                    value = read_il2cpp_string(memory, value_address, max_length=256)
                    if value:
                        strings[key] = value
                except (ExternalReadError, OSError, LayoutValidationError):
                    continue
            afk_warn = entries.get("afkWarn")
            if afk_warn is not None:
                nested = read_jobject_value_pointers(memory, afk_warn)
                for key in ("idleCount", "threshold"):
                    if key in nested:
                        try:
                            ints[key] = read_small_boxed_int(memory, nested[key])
                        except (ExternalReadError, OSError, LayoutValidationError):
                            pass
                if "username" in nested:
                    try:
                        nested_username = read_il2cpp_string(
                            memory, nested["username"], max_length=256
                        )
                        if nested_username:
                            username = nested_username
                    except (ExternalReadError, OSError, LayoutValidationError):
                        pass
        except (ExternalReadError, OSError, LayoutValidationError):
            pass
    return ServerMessage(
        address=address,
        event_type=event_type,
        match_id=match_id,
        timestamp=timestamp,
        username=username,
        payload_address=payload_address,
        server_sequence=server_sequence,
        from_col=from_col,
        from_row=from_row,
        to_col=to_col,
        to_row=to_row,
        card_id=card_id,
        skill_card_id=skill_card_id,
        reject_reason=reject_reason,
        idle_count=ints.get("idleCount"),
        threshold=ints.get("threshold"),
        payload_ints=tuple(sorted(ints.items())),
        payload_bools=tuple(sorted(bools.items())),
        payload_strings=tuple(sorted(strings.items())),
    )


def read_match_runtime(target: Any) -> tuple[int | None, MatchRuntime]:
    resolution = target.resolver.resolve_singleton(MATCH_SERVICE_SINGLETON)
    match_service = resolution.instance if resolution.resolved else None
    if match_service is None:
        return None, MatchRuntime(
            None, None, None, None, None, None, None,
            None, None, None, None, None,
        )
    memory = target.memory
    match_id = _string_field(memory, match_service, MATCH_SERVICE_CURRENT_MATCH_ID_OFFSET)
    current_player = _string_field(
        memory, match_service, MATCH_SERVICE_CURRENT_TURN_PLAYER_OFFSET
    )
    turn = _read_i32(memory, match_service + MATCH_SERVICE_TURN_NUMBER_OFFSET)
    remaining = _read_i32(
        memory, match_service + MATCH_SERVICE_TURN_TIME_REMAINING_SEC_OFFSET
    )
    local_seq = _read_i64(memory, match_service + MATCH_SERVICE_LOCAL_SEQ_NUM_OFFSET)
    move_seq = _read_i64(memory, match_service + MATCH_SERVICE_LAST_MOVE_SEQ_NUM_OFFSET)
    from_col = _read_i32(memory, match_service + MATCH_SERVICE_LAST_MOVE_FROM_COL_OFFSET)
    from_row = _read_i32(memory, match_service + MATCH_SERVICE_LAST_MOVE_FROM_ROW_OFFSET)
    to_col = _read_i32(memory, match_service + MATCH_SERVICE_LAST_MOVE_TO_COL_OFFSET)
    to_row = _read_i32(memory, match_service + MATCH_SERVICE_LAST_MOVE_TO_ROW_OFFSET)
    if not 0 <= turn <= 1_000_000 or not 0 <= remaining <= 300:
        raise LayoutValidationError("MatchService turn/timer is invalid")
    if not 0 <= local_seq <= 10_000_000:
        raise LayoutValidationError("MatchService local move sequence is invalid")
    # A new match can publish CurrentMatchId/turn before the prior LastMove*
    # fields have been reset. Keep the lifecycle sample and fail only this
    # optional telemetry field closed instead of losing the entire early turn.
    last_move_valid = -1 <= move_seq <= local_seq
    if move_seq > 0 and any(
        not 0 <= value < 8 for value in (from_col, from_row, to_col, to_row)
    ):
        last_move_valid = False
    if not last_move_valid:
        move_seq = None
        from_col = from_row = to_col = to_row = None

    try:
        highest_acked = read_acked_sequences(memory, match_service).highest
    except (ExternalReadError, OSError, LayoutValidationError):
        highest_acked = None

    local_username = None
    chat = target.resolver.resolve_singleton(CHAT_SERVICE_SINGLETON)
    if chat.resolved and chat.instance is not None:
        local_username = _string_field(
            memory, chat.instance, CHAT_SERVICE_USERNAME_OFFSET
        )
    return match_service, MatchRuntime(
        match_id,
        turn,
        current_player,
        local_username,
        remaining,
        local_seq,
        move_seq,
        from_col if move_seq is not None and move_seq > 0 else None,
        from_row if move_seq is not None and move_seq > 0 else None,
        to_col if move_seq is not None and move_seq > 0 else None,
        to_row if move_seq is not None and move_seq > 0 else None,
        highest_acked,
    )


def _regions(target: Any, max_region_mib: int) -> tuple[Any, ...]:
    return bounded_private_writable_regions(
        target.memory.iter_readable_regions(),
        max_region_size=max_region_mib * 1024 * 1024,
    )


def _session_id(board_instance: int, match_id: str) -> str:
    return f"board={hex_pointer(board_instance)}|match={match_id}"


def _read_board_observation(target: Any) -> tuple[int | None, Any | None]:
    resolution = target.resolver.resolve_singleton(BOARD_SINGLETON)
    if not resolution.resolved or resolution.instance is None:
        return None, None
    try:
        active_resolution = target.resolver.resolve_singleton(ACTIVE_SINGLETON)
        active = (
            active_resolution.instance if active_resolution.resolved else None
        )
        state = target.resolver.read_board(resolution.instance, active)
    except (ExternalReadError, OSError, LayoutValidationError):
        return resolution.instance, None
    return resolution.instance, state


def _read_participants(
    target: Any, board_state: Any | None, player_stats_class: int | None
) -> tuple[Any, ...]:
    if (
        board_state is None
        or not board_state.accepted
        or board_state.active is None
        or player_stats_class is None
    ):
        return ()
    try:
        return read_active_participants(
            target.memory,
            board_state.active,
            expected_class=player_stats_class,
        )
    except (ExternalReadError, OSError, LayoutValidationError, ValueError):
        return ()


def _server_response_status(message: ServerMessage) -> str | None:
    if message.event_type not in {"MATCH_CARD_USE_RES", "MATCH_SKILL_USE_RES"}:
        return None
    bools = dict(message.payload_bools)
    if message.reject_reason or bools.get("rejected") is True or bools.get("success") is False:
        return "SERVER_REJECTED"
    if bools.get("success") is True or bools.get("accepted") is True:
        return "SERVER_ACCEPTED_EXPLICIT"
    return "SERVER_RESPONSE_OBSERVED_ACCEPTANCE_NEEDS_STATE_CORRELATION"


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--watch", action="store_true", help="watch lobby -> combat")
    parser.add_argument("--log", type=Path, help="JSONL output path")
    parser.add_argument("--interval", type=float, default=0.20)
    parser.add_argument("--full-rescan-interval", type=int, default=12)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument("--matches", type=int, default=1)
    parser.add_argument("--timeout", type=float, default=0.0)
    parser.add_argument(
        "--allow-combat-start",
        action="store_true",
        help=(
            "recovery telemetry only: allow attaching during an existing combat; "
            "production provider publication remains unavailable until a lobby baseline"
        ),
    )
    return parser


def run(args: argparse.Namespace) -> int:
    if not args.watch:
        raise ValueError("idle watcher must be started with --watch")
    if not 0.05 <= args.interval <= 5:
        raise ValueError("--interval must be between 0.05 and 5 seconds")
    if args.full_rescan_interval < 2:
        raise ValueError("--full-rescan-interval must be at least two")
    if not 1 <= args.max_region_mib <= 32 or not 1 <= args.chunk_mib <= 16:
        raise ValueError("region/chunk MiB is outside the safe bounded range")
    if args.matches < 0 or args.timeout < 0:
        raise ValueError("matches/timeout cannot be negative")

    log_path = (args.log or default_log_path("idle_state_watch")).resolve()
    log_path.parent.mkdir(parents=True, exist_ok=True)
    with attach_target() as target, log_path.open(
        "a", encoding="utf-8", buffering=1
    ) as log:
        started = time.monotonic()
        provider = MemoryBoardStateProvider(
            target,
            MemoryProviderConfig(
                max_region_mib=args.max_region_mib,
                chunk_mib=args.chunk_mib,
                full_rescan_interval=max(args.full_rescan_interval, 2),
                require_lobby_start=not args.allow_combat_start,
            ),
        )
        dto_class = target.resolver.resolve_type_info_class(
            CHAT_MESSAGE_DTO_TYPE_INFO_RVA
        )
        player_stats_class = target.resolver.resolve_type_info_class(
            ACTIVE_PLAYER_STATS_TYPE_INFO_RVA
        )
        idle_cache = GameOwnedIdleCache()
        learned_regions: set[Any] = set()
        seen_messages: set[tuple[str, str | None, int]] = set()
        previous_match_id: str | None = None
        previous_runtime: MatchRuntime | None = None
        previous_fusion: Any = None
        previous_cards: tuple[Any, ...] = ()
        previous_player_mana: int | None = None
        previous_board_instance: int | None = None
        active_session_id: str | None = None
        previous_turn_signature: tuple[int | None, str | None] | None = None
        seen_valid_batches: set[tuple[int, int, str]] = set()
        seen_acked_batches: set[tuple[int, int, str]] = set()
        first_stable_logged = False
        first_local_turn_logged = False
        completed = 0
        scans = 0
        authoritative_idle_messages = 0
        _write(
            log,
            "idle_state_watch_started",
            pid=target.pid,
            architecture=target.architecture,
            gameassemblyBase=hex_pointer(target.game_assembly.base),
            access=["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"],
            noInput=True,
            chatMessageClass=hex_pointer(dto_class),
            authoritativeSources=["MATCH_AFK_WARN", "MATCH_TURN_END.afkWarn"],
            cacheRule="replace_from_exact_server_payload_only; never local increment/reset",
            productionPassReadiness=(
                "CONDITIONAL_FOR_FRESH_MATCH_TURN_END_IDLE; "
                "END_TO_END_PROVIDER_INTEGRATION_DISABLED"
            ),
            recoveryCombatStart=bool(args.allow_combat_start),
        )
        print(f"Idle watcher ready (READ-ONLY / NO INPUT), log: {log_path}", flush=True)

        while target.is_running():
            if args.timeout and time.monotonic() - started >= args.timeout:
                break
            try:
                provider_poll = provider.poll()
            except (ExternalReadError, OSError, LayoutValidationError, RuntimeError) as exc:
                provider_poll = None
                _write(log, "provider_poll_error", detail=str(exc))
            try:
                match_service, runtime = read_match_runtime(target)
            except (ExternalReadError, OSError, LayoutValidationError) as exc:
                _write(log, "runtime_read_error", detail=str(exc))
                time.sleep(args.interval)
                continue

            board_instance, board_observation = _read_board_observation(target)
            if board_instance != previous_board_instance:
                _write(
                    log,
                    "board_instance_changed",
                    before=hex_pointer(previous_board_instance),
                    after=hex_pointer(board_instance),
                    matchId=runtime.match_id,
                    turn=runtime.turn,
                    currentTurnPlayer=runtime.current_player,
                    localUsername=runtime.local_username,
                    srvSeq=runtime.highest_acked_sequence,
                    accepted=(
                        board_observation.accepted
                        if board_observation is not None
                        else None
                    ),
                )
                previous_board_instance = board_instance

            if runtime.match_id != previous_match_id:
                if previous_match_id is not None and runtime.match_id is None:
                    ended_session = active_session_id or previous_match_id
                    idle_cache.end_session(ended_session)
                    completed += 1
                    _write(
                        log,
                        "combat_ended",
                        matchId=previous_match_id,
                        session=ended_session,
                        idleState=idle_cache.state,
                    )
                if runtime.match_id is not None:
                    if board_instance is None:
                        session = f"board=UNKNOWN|match={runtime.match_id}"
                    else:
                        session = _session_id(board_instance, runtime.match_id)
                    idle_cache.begin_session(session)
                    active_session_id = session
                    _write(
                        log,
                        "match_runtime_started",
                        matchId=runtime.match_id,
                        session=session,
                        runtime=runtime,
                        source="MatchService.CurrentMatchId",
                    )
                    seen_messages.clear()
                    seen_valid_batches.clear()
                    seen_acked_batches.clear()
                    first_stable_logged = False
                    first_local_turn_logged = False
                previous_match_id = runtime.match_id
                if runtime.match_id is None:
                    active_session_id = None
                previous_runtime = runtime
                previous_fusion = None
                previous_cards = ()
                previous_player_mana = None
                previous_turn_signature = None
                if args.matches and completed >= args.matches:
                    break

            current_session = None
            if runtime.match_id is not None:
                current_session = active_session_id

            turn_signature = (runtime.turn, runtime.current_player)
            if (
                current_session is not None
                and previous_turn_signature is not None
                and turn_signature != previous_turn_signature
            ):
                idle_cache.mark_current_state_unproven(
                    current_session, "turn_or_current_player_transition_without_reset_payload"
                )
                _write(
                    log,
                    "turn_runtime_changed",
                    session=current_session,
                    matchId=runtime.match_id,
                    before={
                        "turn": previous_turn_signature[0],
                        "currentTurnPlayer": previous_turn_signature[1],
                    },
                    after={
                        "turn": runtime.turn,
                        "currentTurnPlayer": runtime.current_player,
                    },
                    localUsername=runtime.local_username,
                    srvSeq=runtime.highest_acked_sequence,
                    idleState=idle_cache.state,
                )
            if runtime.match_id is not None:
                previous_turn_signature = turn_signature

            if runtime.match_id is not None and previous_runtime is not None:
                if runtime.last_move_sequence != previous_runtime.last_move_sequence:
                    if current_session is not None:
                        idle_cache.mark_current_state_unproven(
                            current_session, "client_swap_request_or_move_transition"
                        )
                    _write(
                        log,
                        "last_move_changed",
                        session=current_session,
                        matchId=runtime.match_id,
                        turn=runtime.turn,
                        currentPlayer=runtime.current_player,
                        localUsername=runtime.local_username,
                        srvSeq=runtime.highest_acked_sequence,
                        remaining=runtime.remaining,
                        before=previous_runtime.last_move_sequence,
                        after=runtime.last_move_sequence,
                        LastMoveFromCol=runtime.last_move_from_col,
                        LastMoveFromRow=runtime.last_move_from_row,
                        LastMoveToCol=runtime.last_move_to_col,
                        LastMoveToRow=runtime.last_move_to_row,
                        LastMoveSeqNum=runtime.last_move_sequence,
                        localSeqNum=runtime.local_move_sequence,
                        action="SWAP_CLIENT_REQUEST",
                        acceptance="not_authoritative_until_response/board transition correlation",
                        idleState=idle_cache.state,
                    )
            previous_runtime = runtime

            if runtime.match_id is None or match_service is None:
                time.sleep(args.interval)
                continue

            scans += 1
            if dto_class is None:
                dto_class = target.resolver.resolve_type_info_class(
                    CHAT_MESSAGE_DTO_TYPE_INFO_RVA
                )
            if player_stats_class is None:
                player_stats_class = target.resolver.resolve_type_info_class(
                    ACTIVE_PLAYER_STATS_TYPE_INFO_RVA
                )

            diagnostics = provider.scan_diagnostics
            for tracked in diagnostics.get("trackedBatches", ()):
                key = (
                    int(tracked["address"]),
                    int(tracked["srvSeq"]),
                    str(tracked["boardHash"]),
                )
                if key not in seen_valid_batches:
                    seen_valid_batches.add(key)
                    _write(
                        log,
                        "valid_ws_combat_batch_observed",
                        session=current_session,
                        matchId=runtime.match_id,
                        turn=runtime.turn,
                        currentTurnPlayer=runtime.current_player,
                        localUsername=runtime.local_username,
                        batch=tracked,
                        firstValidBatch=len(seen_valid_batches) == 1,
                    )
                if tracked.get("ackAttested") and key not in seen_acked_batches:
                    seen_acked_batches.add(key)
                    _write(
                        log,
                        "acked_ws_combat_batch_observed",
                        session=current_session,
                        matchId=runtime.match_id,
                        turn=runtime.turn,
                        currentTurnPlayer=runtime.current_player,
                        localUsername=runtime.local_username,
                        batch=tracked,
                        highestAckedSequence=diagnostics.get(
                            "highestAckedSequence"
                        ),
                        firstAckedBatch=len(seen_acked_batches) == 1,
                    )
            if (
                provider_poll is not None
                and provider_poll.publish
                and provider_poll.state is not None
                and provider_poll.state.phase is GamePhase.COMBAT
                and not first_stable_logged
            ):
                state = provider_poll.state
                first_stable_logged = True
                _write(
                    log,
                    "first_stable_board_published",
                    session=current_session,
                    matchId=runtime.match_id,
                    turn=state.battle.turn_number,
                    currentTurnPlayer=state.battle.current_turn_player,
                    localUsername=state.battle.local_username,
                    srvSeq=state.battle.srv_seq,
                    boardHash=state.battle.board_hash,
                    confirmations=provider_poll.confirmations,
                    reason=provider_poll.reason,
                )

            local_turn = (
                runtime.local_username is not None
                and runtime.current_player is not None
                and runtime.local_username.casefold()
                == runtime.current_player.casefold()
            )
            first_local_signal = local_turn and runtime.turn in (0, 1)
            if first_local_signal and not first_local_turn_logged:
                first_local_turn_logged = True
                _write(
                    log,
                    "first_local_turn_runtime_signal",
                    session=current_session,
                    matchId=runtime.match_id,
                    turn=runtime.turn,
                    currentTurnPlayer=runtime.current_player,
                    localUsername=runtime.local_username,
                    isLocalTurn=True,
                    isFirstLocalTurn=True,
                    srvSeq=runtime.highest_acked_sequence,
                    boardInstance=hex_pointer(board_instance),
                    source=[
                        "MatchService.TurnNumber",
                        "MatchService.CurrentTurnPlayer",
                        "ChatService.username",
                    ],
                    productionStableAtObservation=(
                        provider_poll.publish
                        if provider_poll is not None
                        else False
                    ),
                )

            if dto_class is None:
                time.sleep(args.interval)
                continue

            all_regions = _regions(target, args.max_region_mib)
            full = not learned_regions or scans % args.full_rescan_interval == 0
            selected_regions: Iterable[Any] = (
                all_regions if full else tuple(sorted(learned_regions, key=lambda x: x.base))
            )
            scan = scan_aligned_qwords(
                target.memory,
                selected_regions,
                {"chat_message": int(dto_class)},
                chunk_size=args.chunk_mib * 1024 * 1024,
            )
            for hits in scan.matches.values():
                learned_regions.update(regions_containing_addresses(all_regions, hits))

            for address in scan.matches["chat_message"]:
                try:
                    message = read_server_message(
                        target.memory,
                        address,
                        expected_class=int(dto_class),
                        expected_match_id=runtime.match_id,
                    )
                except (ExternalReadError, OSError, LayoutValidationError):
                    continue
                identity = (message.event_type, message.timestamp, message.address)
                if identity in seen_messages:
                    continue
                seen_messages.add(identity)
                authoritative_idle = (
                    message.event_type in {"MATCH_AFK_WARN", "MATCH_TURN_END"}
                    and message.username is not None
                    and message.idle_count is not None
                    and message.threshold is not None
                )
                if authoritative_idle:
                    authoritative_idle_messages += 1
                    idle_state = idle_cache.observe_server_payload(
                        session_id=current_session or runtime.match_id,
                        username=message.username or "",
                        idle_count=message.idle_count or 0,
                        threshold=message.threshold or 0,
                        source_message_type=message.event_type,
                        source_srv_seq=message.server_sequence,
                        source_turn=message.source_turn,
                        source_timestamp=message.timestamp,
                        observed_timestamp=_utc_timestamp(),
                    )
                else:
                    idle_state = idle_cache.state
                readiness = idle_cache.pass_readiness(
                    current_session_id=current_session,
                    local_username=runtime.local_username,
                    current_turn=runtime.turn,
                    is_local_turn=local_turn,
                )
                _write(
                    log,
                    "server_match_message",
                    session=current_session,
                    matchId=runtime.match_id,
                    turn=runtime.turn,
                    currentPlayer=runtime.current_player,
                    localUsername=runtime.local_username,
                    srvSeq=runtime.highest_acked_sequence,
                    remaining=runtime.remaining,
                    message=message,
                    responseStatus=_server_response_status(message),
                    authoritativeIdle=authoritative_idle,
                    gameOwnedIdleState=idle_state,
                    passReadiness=readiness,
                )

            participants = _read_participants(
                target, board_observation, player_stats_class
            )
            local_player = next(
                (participant for participant in participants if participant.is_local is True),
                None,
            )
            player_mana = local_player.mana if local_player is not None else None

            fusion = provider.observed_fusion
            if fusion is not None and fusion != previous_fusion:
                if previous_fusion is not None and current_session is not None:
                    idle_cache.mark_current_state_unproven(
                        current_session, "fusion_state_transition_reset_semantics_unknown"
                    )
                _write(
                    log,
                    "fusion_state_changed",
                    session=current_session,
                    matchId=runtime.match_id,
                    turn=runtime.turn,
                    currentPlayer=runtime.current_player,
                    localUsername=runtime.local_username,
                    srvSeq=runtime.highest_acked_sequence,
                    remaining=runtime.remaining,
                    before=previous_fusion,
                    fusion=fusion,
                    action="EVOLVE_STATE",
                    consumesTurn=False,
                    playerMana=player_mana,
                    idleState=idle_cache.state,
                )
                previous_fusion = fusion

            cards = provider.observed_cards
            if cards and cards != previous_cards:
                previous_by_address = {
                    card.object_address: card for card in previous_cards
                }
                used_transitions = []
                for card in cards:
                    prior = previous_by_address.get(card.object_address)
                    if (
                        prior is not None
                        and not prior.has_used_this_turn
                        and card.has_used_this_turn
                    ):
                        used_transitions.append({"before": prior, "after": card})
                if used_transitions and current_session is not None:
                    idle_cache.mark_current_state_unproven(
                        current_session, "card_use_transition_reset_semantics_unknown"
                    )
                _write(
                    log,
                    "card_state_changed",
                    session=current_session,
                    matchId=runtime.match_id,
                    turn=runtime.turn,
                    currentPlayer=runtime.current_player,
                    localUsername=runtime.local_username,
                    srvSeq=runtime.highest_acked_sequence,
                    remaining=runtime.remaining,
                    currentPlayerMana=player_mana,
                    previousPlayerMana=previous_player_mana,
                    cards=cards,
                    usedTransitions=used_transitions,
                    attackCards=[card for card in cards if card.is_attack],
                    idleState=idle_cache.state,
                    evidence=(
                        "CardUI current Board/Active ownership + game-computed interactable; "
                        "acceptance requires server response/turn correlation"
                    ),
                )
                previous_cards = cards
            previous_player_mana = player_mana

            time.sleep(args.interval)

        _write(
            log,
            "idle_state_watch_summary",
            completedMatches=completed,
            scans=scans,
            authoritativeMessages=authoritative_idle_messages,
            firstLocalTurnCaptured=first_local_turn_logged,
            firstStableBoardCaptured=first_stable_logged,
            validBatchesObserved=len(seen_valid_batches),
            ackedBatchesObserved=len(seen_acked_batches),
            latestIdleState=idle_cache.state,
            providerMetrics=provider.metrics,
            passReadiness=idle_cache.pass_readiness(
                current_session_id=active_session_id,
                local_username=(previous_runtime.local_username if previous_runtime else None),
                current_turn=(previous_runtime.turn if previous_runtime else None),
                is_local_turn=(
                    previous_runtime is not None
                    and previous_runtime.local_username is not None
                    and previous_runtime.current_player is not None
                    and previous_runtime.local_username.casefold()
                    == previous_runtime.current_player.casefold()
                ),
            ),
            noInput=True,
        )
        print(f"Idle watcher stopped; matches={completed}; log: {log_path}", flush=True)
        return 0


def main(argv: Sequence[str] | None = None) -> int:
    try:
        return run(build_parser().parse_args(argv))
    except KeyboardInterrupt:
        print("Idle watcher stopped by user.")
        return 130
    except (
        FileNotFoundError,
        OSError,
        ProcessProbeError,
        RuntimeError,
        ValueError,
    ) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
