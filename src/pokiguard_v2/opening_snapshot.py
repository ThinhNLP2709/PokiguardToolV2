"""Strict read-only decoder for the authoritative ``MATCH_START`` board.

The server puts the opening grid in
``ChatMessageDTO.matchPayload["board"]``.  Cpp2IL proves that both
``BoardWsApplier.LoadBoardFromSnapshotCore`` and
``MatchService.ParseCombatBatch`` convert this value through ``JArray`` to
``BoardCellDTO[][]``.  The opening snapshot is not inserted into
``_ackedSeqs`` by the game, so this transport object is the only server-owned
opening witness.

Every layout used here is backed by the local Cpp2IL C#/ISIL output.  The
decoder accepts only exact Newtonsoft runtime classes, an exact 8x8 shape,
the four required cell properties and the already-evidenced board semantics.
It performs no process writes or game method calls.
"""

from __future__ import annotations

from dataclasses import dataclass
import struct
from typing import Any, Mapping

from .il2cpp_external import ExternalReadError, is_canonical_user_pointer
from .il2cpp_layout import BoardCellSnapshot, LayoutValidationError, read_il2cpp_string
from .live_state import dto_rejection_reasons


# Metadata-usage slots referenced as typeof(...) by the local Newtonsoft.Json
# native bodies.  These are build RVAs, never ASLR-dependent addresses.
JARRAY_TYPE_INFO_RVA = 0x2C47B68
JOBJECT_TYPE_INFO_RVA = 0x2C47D68
JPROPERTY_TYPE_INFO_RVA = 0x2C47EC0
JVALUE_TYPE_INFO_RVA = 0x2C48578

JARRAY_VALUES_OFFSET = 0x58
LIST_ITEMS_OFFSET = 0x10
LIST_SIZE_OFFSET = 0x18
LIST_VERSION_OFFSET = 0x1C
ARRAY_LENGTH_OFFSET = 0x18
ARRAY_DATA_OFFSET = 0x20

JOBJECT_PROPERTIES_OFFSET = 0x58
JPROPERTY_COLLECTION_DICTIONARY_OFFSET = 0x18
JPROPERTY_CONTENT_OFFSET = 0x58
JPROPERTY_LIST_TOKEN_OFFSET = 0x10
JVALUE_TYPE_OFFSET = 0x30
JVALUE_VALUE_OFFSET = 0x38

DICTIONARY_ENTRIES_OFFSET = 0x18
DICTIONARY_COUNT_OFFSET = 0x20
DICTIONARY_FREE_COUNT_OFFSET = 0x28
DICTIONARY_ENTRY_SIZE = 0x18
ENTRY_HASH_OFFSET = 0x00
ENTRY_KEY_OFFSET = 0x08
ENTRY_VALUE_OFFSET = 0x10

JTOKEN_INTEGER = 6
JTOKEN_STRING = 8
MAX_SERVER_SEQUENCE = 10_000_000


@dataclass(frozen=True)
class NewtonsoftClasses:
    jarray: int
    jobject: int
    jproperty: int
    jvalue: int

    def __post_init__(self) -> None:
        for name, pointer in (
            ("JArray", self.jarray),
            ("JObject", self.jobject),
            ("JProperty", self.jproperty),
            ("JValue", self.jvalue),
        ):
            if not is_canonical_user_pointer(pointer):
                raise ValueError(f"{name} class pointer is invalid")


@dataclass(frozen=True)
class OpeningBoardSnapshot:
    match_id: str
    message_address: int
    payload_address: int
    board_token_address: int
    sequence: int
    cells: tuple[BoardCellSnapshot, ...]

    def __post_init__(self) -> None:
        if not self.match_id.strip():
            raise ValueError("opening snapshot match_id is required")
        if not 0 <= self.sequence <= MAX_SERVER_SEQUENCE:
            raise ValueError("MATCH_START opening snapshot sequence is outside bounds")
        if dto_rejection_reasons(self.cells):
            raise ValueError("opening snapshot cells failed canonical board validation")


def _read_exact(memory: Any, address: int, size: int) -> bytes:
    if (
        size <= 0
        or not is_canonical_user_pointer(address)
        or not memory.is_readable(address, size)
    ):
        raise LayoutValidationError("opening snapshot read range is invalid")
    raw = memory.read(address, size)
    if len(raw) != size:
        raise ExternalReadError("short opening snapshot read")
    return raw


def _pointer(memory: Any, address: int) -> int:
    return struct.unpack("<Q", _read_exact(memory, address, 8))[0]


def _i32(memory: Any, address: int) -> int:
    return struct.unpack("<i", _read_exact(memory, address, 4))[0]


def _exact_class(memory: Any, address: int, expected: int, label: str) -> None:
    if _pointer(memory, address) != expected:
        raise LayoutValidationError(f"{label} runtime class mismatch")


def _read_jarray(
    memory: Any,
    address: int,
    *,
    expected_class: int,
    expected_count: int,
) -> tuple[int, ...]:
    """Decode ``JArray._values : List<JToken>`` with exact size bounds."""

    _exact_class(memory, address, expected_class, "JArray")
    values = _pointer(memory, address + JARRAY_VALUES_OFFSET)
    if not is_canonical_user_pointer(values):
        raise LayoutValidationError("JArray values list is invalid")
    list_header = _read_exact(memory, values, 0x20)
    items = struct.unpack_from("<Q", list_header, LIST_ITEMS_OFFSET)[0]
    size = struct.unpack_from("<i", list_header, LIST_SIZE_OFFSET)[0]
    version = struct.unpack_from("<i", list_header, LIST_VERSION_OFFSET)[0]
    if size != expected_count or version < 0:
        raise LayoutValidationError(
            f"JArray size/version is {size}/{version}, expected {expected_count}/nonnegative"
        )
    if not is_canonical_user_pointer(items):
        raise LayoutValidationError("JArray backing array is invalid")
    array_header = _read_exact(memory, items, ARRAY_DATA_OFFSET)
    array_class, _monitor, bounds, capacity = struct.unpack("<4Q", array_header)
    if (
        not is_canonical_user_pointer(array_class)
        or bounds != 0
        or not expected_count <= capacity <= 128
    ):
        raise LayoutValidationError("JArray backing array shape is invalid")
    raw = _read_exact(memory, items + ARRAY_DATA_OFFSET, expected_count * 8)
    pointers = struct.unpack(f"<{expected_count}Q", raw)
    if any(not is_canonical_user_pointer(pointer) for pointer in pointers):
        raise LayoutValidationError("JArray contains a null/non-canonical token")
    return pointers


def _read_dictionary_entries(
    memory: Any, address: int, *, max_entries: int = 16
) -> Mapping[str, int]:
    if not is_canonical_user_pointer(address):
        raise LayoutValidationError("JObject dictionary pointer is invalid")
    entries = _pointer(memory, address + DICTIONARY_ENTRIES_OFFSET)
    count = _i32(memory, address + DICTIONARY_COUNT_OFFSET)
    free_count = _i32(memory, address + DICTIONARY_FREE_COUNT_OFFSET)
    if not 0 <= free_count <= count <= max_entries:
        raise LayoutValidationError("JObject dictionary count/freeCount is invalid")
    if not is_canonical_user_pointer(entries):
        raise LayoutValidationError("JObject dictionary entries are invalid")
    capacity = struct.unpack(
        "<Q", _read_exact(memory, entries + ARRAY_LENGTH_OFFSET, 8)
    )[0]
    if not count <= capacity <= max_entries * 4:
        raise LayoutValidationError("JObject dictionary capacity is invalid")
    output: dict[str, int] = {}
    for index in range(count):
        entry = entries + ARRAY_DATA_OFFSET + index * DICTIONARY_ENTRY_SIZE
        if _i32(memory, entry + ENTRY_HASH_OFFSET) < 0:
            continue
        key_pointer = _pointer(memory, entry + ENTRY_KEY_OFFSET)
        value_pointer = _pointer(memory, entry + ENTRY_VALUE_OFFSET)
        if not (
            is_canonical_user_pointer(key_pointer)
            and is_canonical_user_pointer(value_pointer)
        ):
            raise LayoutValidationError("JObject dictionary entry pointer is invalid")
        key = read_il2cpp_string(memory, key_pointer, max_length=64)
        if not key or key in output:
            raise LayoutValidationError("JObject property key is empty/duplicated")
        output[key] = value_pointer
    return output


def _read_jobject_tokens(
    memory: Any,
    address: int,
    *,
    classes: NewtonsoftClasses,
) -> Mapping[str, int]:
    _exact_class(memory, address, classes.jobject, "JObject")
    properties = _pointer(memory, address + JOBJECT_PROPERTIES_OFFSET)
    if not is_canonical_user_pointer(properties):
        raise LayoutValidationError("JObject properties pointer is invalid")
    dictionary = _pointer(
        memory, properties + JPROPERTY_COLLECTION_DICTIONARY_OFFSET
    )
    entries = _read_dictionary_entries(memory, dictionary, max_entries=64)
    output: dict[str, int] = {}
    for key, jproperty in entries.items():
        _exact_class(memory, jproperty, classes.jproperty, "JProperty")
        content = _pointer(memory, jproperty + JPROPERTY_CONTENT_OFFSET)
        if not is_canonical_user_pointer(content):
            raise LayoutValidationError("JProperty content pointer is invalid")
        token = _pointer(memory, content + JPROPERTY_LIST_TOKEN_OFFSET)
        if not is_canonical_user_pointer(token):
            raise LayoutValidationError("JProperty value token is invalid")
        output[key] = token
    return output


def _read_jvalue_object(
    memory: Any,
    token: int,
    *,
    classes: NewtonsoftClasses,
    token_type: int,
) -> int:
    _exact_class(memory, token, classes.jvalue, "JValue")
    observed_type = _i32(memory, token + JVALUE_TYPE_OFFSET)
    if observed_type != token_type:
        raise LayoutValidationError(
            f"JValue type is {observed_type}, expected {token_type}"
        )
    value = _pointer(memory, token + JVALUE_VALUE_OFFSET)
    if not is_canonical_user_pointer(value):
        raise LayoutValidationError("JValue payload is null/non-canonical")
    return value


def _read_boxed_integer(
    memory: Any, address: int, *, minimum: int, maximum: int
) -> int:
    raw = _read_exact(memory, address + 0x10, 8)
    int64 = struct.unpack("<q", raw)[0]
    int32 = struct.unpack_from("<i", raw)[0]
    candidates = {value for value in (int64, int32) if minimum <= value <= maximum}
    if len(candidates) != 1:
        raise LayoutValidationError("boxed integer is invalid/ambiguous")
    return candidates.pop()


def _read_cell(
    memory: Any,
    address: int,
    *,
    classes: NewtonsoftClasses,
) -> BoardCellSnapshot:
    tokens = _read_jobject_tokens(memory, address, classes=classes)
    required = {"col", "row", "tag", "multiplier"}
    if not required.issubset(tokens):
        raise LayoutValidationError(
            f"opening cell is missing properties {sorted(required - set(tokens))}"
        )

    def small_integer(name: str, minimum: int, maximum: int) -> int:
        boxed = _read_jvalue_object(
            memory, tokens[name], classes=classes, token_type=JTOKEN_INTEGER
        )
        try:
            return _read_boxed_integer(
                memory, boxed, minimum=minimum, maximum=maximum
            )
        except LayoutValidationError as exc:
            raise LayoutValidationError(f"{name} {exc}") from exc

    col = small_integer("col", 0, 7)
    row = small_integer("row", 0, 7)
    multiplier = small_integer("multiplier", 1, 4)
    tag_object = _read_jvalue_object(
        memory, tokens["tag"], classes=classes, token_type=JTOKEN_STRING
    )
    tag = read_il2cpp_string(memory, tag_object, max_length=64)
    if not tag or any(ord(character) < 0x20 for character in tag):
        raise LayoutValidationError("opening cell tag is empty/contains control data")
    return BoardCellSnapshot(address, col, row, tag_object, tag, multiplier)


def read_opening_board_jarray(
    memory: Any,
    address: int,
    *,
    classes: NewtonsoftClasses,
) -> tuple[BoardCellSnapshot, ...]:
    """Decode a strict JSON ``BoardCellDTO[8][8]`` representation."""

    rows = _read_jarray(
        memory, address, expected_class=classes.jarray, expected_count=8
    )
    cells: list[BoardCellSnapshot] = []
    for row_token in rows:
        cell_tokens = _read_jarray(
            memory, row_token, expected_class=classes.jarray, expected_count=8
        )
        cells.extend(
            _read_cell(memory, token, classes=classes) for token in cell_tokens
        )
    ordered = tuple(sorted(cells, key=lambda cell: (cell.row, cell.col)))
    reasons = dto_rejection_reasons(ordered)
    if reasons:
        raise LayoutValidationError(
            "opening board semantic validation failed: " + ";".join(reasons)
        )
    return ordered


def read_match_payload_board_snapshot(
    memory: Any,
    *,
    match_id: str,
    message_address: int,
    payload_address: int,
    classes: NewtonsoftClasses,
    event_type: str,
) -> OpeningBoardSnapshot:
    """Decode a current-match transport payload's exact board witness.

    The caller has already validated the enclosing ``ChatMessageDTO`` class,
    event type and match id. This function independently requires a supported
    board-bearing event, a nonnegative boxed ``srvSeq`` and the board key
    before it exposes cells.
    """

    if not match_id.strip():
        raise LayoutValidationError("transport board match id is empty")
    if event_type not in {"MATCH_START", "MATCH_MOVE_RES"}:
        raise LayoutValidationError(
            f"unsupported transport board event: {event_type}"
        )
    entries = _read_dictionary_entries(memory, payload_address, max_entries=64)
    board_token = entries.get("board")
    sequence_box = entries.get("srvSeq")
    if board_token is None or sequence_box is None:
        raise LayoutValidationError(
            f"{event_type} payload lacks board/srvSeq"
        )
    # Live evidence shows MATCH_START uses a positive transport sequence (3 in
    # the 2026-08-13 verification run) even though it has no _ackedSeqs entry.
    # Do not conflate that independent transport sequence with LocalSeqNum=0.
    sequence = _read_boxed_integer(
        memory,
        sequence_box,
        minimum=0,
        maximum=MAX_SERVER_SEQUENCE,
    )
    cells = read_opening_board_jarray(memory, board_token, classes=classes)
    return OpeningBoardSnapshot(
        match_id=match_id,
        message_address=message_address,
        payload_address=payload_address,
        board_token_address=board_token,
        sequence=sequence,
        cells=cells,
    )


def read_match_start_opening_snapshot(
    memory: Any,
    *,
    match_id: str,
    message_address: int,
    payload_address: int,
    classes: NewtonsoftClasses,
) -> OpeningBoardSnapshot:
    """Decode the exact ``MATCH_START.matchPayload`` opening witness."""

    return read_match_payload_board_snapshot(
        memory,
        match_id=match_id,
        message_address=message_address,
        payload_address=payload_address,
        classes=classes,
        event_type="MATCH_START",
    )


__all__ = [
    "JARRAY_TYPE_INFO_RVA",
    "JOBJECT_TYPE_INFO_RVA",
    "JPROPERTY_TYPE_INFO_RVA",
    "JVALUE_TYPE_INFO_RVA",
    "NewtonsoftClasses",
    "OpeningBoardSnapshot",
    "read_opening_board_jarray",
    "read_match_payload_board_snapshot",
    "read_match_start_opening_snapshot",
]
