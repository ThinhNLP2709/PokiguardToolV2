"""Build-specific, read-only IL2CPP layout decoders for Pokiguard Phase 2A.

Every offset in this module is backed by the local Cpp2IL C#/ISIL output.  The
rectangular array decoder additionally requires its runtime observations to
match the expected 8x8 invariants before it exposes element pointers.
"""

from __future__ import annotations

from dataclasses import dataclass
import struct

from .il2cpp_external import (
    ExternalReadError,
    MemoryReader,
    checked_address,
    is_canonical_user_pointer,
)


POINTER_SIZE = 8

# Native evidence: Dot.GetAllDots and BoardWsApplier.FindDotPrefabByTag.
IL2CPP_ARRAY_BOUNDS_OFFSET = 0x10
IL2CPP_ARRAY_MAX_LENGTH_OFFSET = 0x18
IL2CPP_ARRAY_DATA_OFFSET = 0x20

# System.String.get_Length/get_Chars in the local mscorlib ISIL.
IL2CPP_STRING_LENGTH_OFFSET = 0x10
IL2CPP_STRING_DATA_OFFSET = 0x14
DEFAULT_STRING_CAP = 128

DOT_COLUMN_OFFSET = 0x20
DOT_ROW_OFFSET = 0x24
DOT_BOARD_OFFSET = 0x48
DOT_MULTIPLIER_OFFSET = 0x88
DOT_ORIGINAL_PREFAB_OFFSET = 0xD8
UNITY_OBJECT_CACHED_PTR_OFFSET = 0x10
DOT_READ_SIZE = 0xF0

BOARD_CELL_COL_OFFSET = 0x10
BOARD_CELL_ROW_OFFSET = 0x14
BOARD_CELL_TAG_OFFSET = 0x18
BOARD_CELL_MULTIPLIER_OFFSET = 0x20
BOARD_CELL_READ_SIZE = 0x24

WS_COMBAT_BATCH_SEQUENCE_OFFSET = 0x10
WS_COMBAT_BATCH_BOARD_OFFSET = 0x38


class LayoutValidationError(ExternalReadError):
    """A readable object did not satisfy the evidenced layout invariants."""


def _read_exact(memory: MemoryReader, address: int, size: int) -> bytes:
    if not is_canonical_user_pointer(address) or size <= 0:
        raise LayoutValidationError("invalid read range")
    if not memory.is_readable(address, size):
        raise LayoutValidationError(f"unreadable range 0x{address:X}+0x{size:X}")
    raw = memory.read(address, size)
    if len(raw) != size:
        raise LayoutValidationError(f"short read at 0x{address:X}")
    return raw


def read_pointer(memory: MemoryReader, address: int) -> int:
    return struct.unpack("<Q", _read_exact(memory, address, 8))[0]


def read_i32(memory: MemoryReader, address: int) -> int:
    return struct.unpack("<i", _read_exact(memory, address, 4))[0]


def read_u64(memory: MemoryReader, address: int) -> int:
    return struct.unpack("<Q", _read_exact(memory, address, 8))[0]


@dataclass(frozen=True)
class ArrayBoundsObservation:
    address: int
    raw_qwords: tuple[int, int, int, int]
    dimension_lengths: tuple[int, int]
    lower_bounds: tuple[int, int]
    padding_words: tuple[int, int]


@dataclass(frozen=True)
class RectangularArrayObservation:
    address: int
    class_pointer: int
    monitor_pointer: int
    bounds_pointer: int
    max_length: int
    raw_qwords_00_through_80: tuple[int, ...]
    bounds: ArrayBoundsObservation | None
    expected_dimensions: tuple[int, int]
    layout_verified: bool
    rejection_reason: str | None
    elements: tuple[int, ...] | None


def observe_rectangular_reference_array(
    memory: MemoryReader,
    address: int,
    expected_dimensions: tuple[int, int] = (8, 8),
) -> RectangularArrayObservation:
    """Observe and conditionally decode a rectangular reference array.

    Elements are returned only after class/header pointers, max_length, both
    dimension lengths, and zero lower bounds all validate.  This prevents a
    generic IL2CPP layout assumption from silently becoming runtime evidence.
    """

    if len(expected_dimensions) != 2 or any(value <= 0 for value in expected_dimensions):
        raise ValueError("expected_dimensions must contain two positive lengths")
    raw_header = _read_exact(memory, address, 0x88)
    raw_qwords = struct.unpack("<17Q", raw_header)
    class_pointer, monitor_pointer, bounds_pointer, max_length = raw_qwords[:4]
    reasons: list[str] = []
    bounds: ArrayBoundsObservation | None = None

    if not is_canonical_user_pointer(class_pointer) or not memory.is_readable(
        class_pointer, 8
    ):
        reasons.append("array class pointer is invalid")
    if bounds_pointer == 0:
        reasons.append("rectangular array bounds pointer is null")
    elif not is_canonical_user_pointer(bounds_pointer):
        reasons.append("bounds pointer is non-canonical")
    else:
        bounds_raw = _read_exact(memory, bounds_pointer, 0x20)
        bounds_qwords = struct.unpack("<4Q", bounds_raw)
        dimension_lengths = (bounds_qwords[0], bounds_qwords[2])
        lower_bounds = (
            struct.unpack_from("<i", bounds_raw, 0x08)[0],
            struct.unpack_from("<i", bounds_raw, 0x18)[0],
        )
        padding_words = (
            struct.unpack_from("<I", bounds_raw, 0x0C)[0],
            struct.unpack_from("<I", bounds_raw, 0x1C)[0],
        )
        bounds = ArrayBoundsObservation(
            bounds_pointer,
            bounds_qwords,
            dimension_lengths,
            lower_bounds,
            padding_words,
        )
        if dimension_lengths != expected_dimensions:
            reasons.append(
                f"bounds dimensions are {dimension_lengths}, expected {expected_dimensions}"
            )
        if lower_bounds != (0, 0):
            reasons.append(f"non-zero lower bounds {lower_bounds}")
        if padding_words != (0, 0):
            reasons.append(f"non-zero bounds padding {padding_words}")

    expected_count = expected_dimensions[0] * expected_dimensions[1]
    if max_length != expected_count:
        reasons.append(f"max_length is {max_length}, expected {expected_count}")

    elements: tuple[int, ...] | None = None
    if not reasons:
        data_address = checked_address(address, IL2CPP_ARRAY_DATA_OFFSET)
        data = _read_exact(memory, data_address, expected_count * POINTER_SIZE)
        elements = struct.unpack(f"<{expected_count}Q", data)
        for index, pointer in enumerate(elements):
            if pointer and (
                not is_canonical_user_pointer(pointer)
                or not memory.is_readable(pointer, 0x18)
            ):
                reasons.append(f"element {index} is not a readable object pointer")
                elements = None
                break

    return RectangularArrayObservation(
        address,
        class_pointer,
        monitor_pointer,
        bounds_pointer,
        max_length,
        raw_qwords,
        bounds,
        expected_dimensions,
        not reasons,
        "; ".join(reasons) if reasons else None,
        elements,
    )


def read_reference_array(
    memory: MemoryReader,
    address: int,
    *,
    max_length: int = 128,
) -> tuple[int, ...]:
    """Read a one-dimensional managed reference array with a strict cap."""

    if max_length <= 0:
        raise ValueError("max_length cap must be positive")
    header = _read_exact(memory, address, IL2CPP_ARRAY_DATA_OFFSET)
    class_pointer, _monitor, _bounds, length = struct.unpack("<4Q", header)
    if not is_canonical_user_pointer(class_pointer) or not memory.is_readable(
        class_pointer, 8
    ):
        raise LayoutValidationError("reference array class pointer is invalid")
    if length > max_length:
        raise LayoutValidationError(f"reference array length {length} exceeds cap")
    if length == 0:
        return ()
    raw = _read_exact(memory, address + IL2CPP_ARRAY_DATA_OFFSET, length * 8)
    return struct.unpack(f"<{length}Q", raw)


def read_il2cpp_string(
    memory: MemoryReader,
    pointer: int,
    *,
    max_length: int = DEFAULT_STRING_CAP,
) -> str:
    """Read one bounded IL2CPP UTF-16 string from the verified local layout."""

    if max_length <= 0:
        raise ValueError("max_length must be positive")
    header = _read_exact(memory, pointer, IL2CPP_STRING_DATA_OFFSET)
    class_pointer = struct.unpack_from("<Q", header, 0)[0]
    length = struct.unpack_from("<i", header, IL2CPP_STRING_LENGTH_OFFSET)[0]
    if not is_canonical_user_pointer(class_pointer) or not memory.is_readable(
        class_pointer, 8
    ):
        raise LayoutValidationError("string class pointer is invalid")
    if length < 0 or length > max_length:
        raise LayoutValidationError(
            f"string length {length} is outside allowed range 0..{max_length}"
        )
    if length == 0:
        return ""
    payload = _read_exact(memory, pointer + IL2CPP_STRING_DATA_OFFSET, length * 2)
    try:
        return payload.decode("utf-16-le", errors="strict")
    except UnicodeDecodeError as exc:
        raise LayoutValidationError("invalid UTF-16 string payload") from exc


@dataclass(frozen=True)
class DotSnapshot:
    address: int
    class_pointer: int
    cached_native_pointer: int
    column: int
    row: int
    board_pointer: int
    multiplier: int
    original_prefab: int


def read_dot(
    memory: MemoryReader,
    address: int,
    *,
    expected_board: int,
    expected_class: int | None,
) -> DotSnapshot:
    raw = _read_exact(memory, address, DOT_READ_SIZE)
    class_pointer = struct.unpack_from("<Q", raw, 0)[0]
    cached_native = struct.unpack_from("<Q", raw, UNITY_OBJECT_CACHED_PTR_OFFSET)[0]
    column = struct.unpack_from("<i", raw, DOT_COLUMN_OFFSET)[0]
    row = struct.unpack_from("<i", raw, DOT_ROW_OFFSET)[0]
    board_pointer = struct.unpack_from("<Q", raw, DOT_BOARD_OFFSET)[0]
    multiplier = struct.unpack_from("<i", raw, DOT_MULTIPLIER_OFFSET)[0]
    original_prefab = struct.unpack_from("<Q", raw, DOT_ORIGINAL_PREFAB_OFFSET)[0]

    if expected_class is not None and class_pointer != expected_class:
        raise LayoutValidationError("candidate class does not equal Dot Il2CppClass")
    if board_pointer != expected_board:
        raise LayoutValidationError("Dot._board does not equal Board.Instance")
    if not 0 <= column < 8 or not 0 <= row < 8:
        raise LayoutValidationError(f"Dot coordinates out of range: ({column},{row})")
    if not is_canonical_user_pointer(cached_native):
        raise LayoutValidationError("UnityEngine.Object.m_CachedPtr is invalid")
    if not is_canonical_user_pointer(original_prefab) or not memory.is_readable(
        original_prefab, 0x18
    ):
        raise LayoutValidationError("Dot.originalPrefab is not a readable object")
    return DotSnapshot(
        address,
        class_pointer,
        cached_native,
        column,
        row,
        board_pointer,
        multiplier,
        original_prefab,
    )


@dataclass(frozen=True)
class BoardCellSnapshot:
    address: int
    col: int
    row: int
    tag_pointer: int
    tag: str
    multiplier: int


def read_board_cell(memory: MemoryReader, address: int) -> BoardCellSnapshot:
    raw = _read_exact(memory, address, BOARD_CELL_READ_SIZE)
    col = struct.unpack_from("<i", raw, BOARD_CELL_COL_OFFSET)[0]
    row = struct.unpack_from("<i", raw, BOARD_CELL_ROW_OFFSET)[0]
    tag_pointer = struct.unpack_from("<Q", raw, BOARD_CELL_TAG_OFFSET)[0]
    multiplier = struct.unpack_from("<i", raw, BOARD_CELL_MULTIPLIER_OFFSET)[0]
    if not 0 <= col < 8 or not 0 <= row < 8:
        raise LayoutValidationError(f"BoardCellDTO coordinates out of range: ({col},{row})")
    if tag_pointer == 0:
        raise LayoutValidationError("BoardCellDTO.tag is null")
    tag = read_il2cpp_string(memory, tag_pointer, max_length=64)
    if not tag or any(ord(character) < 0x20 for character in tag):
        raise LayoutValidationError("BoardCellDTO.tag is empty or contains control data")
    return BoardCellSnapshot(address, col, row, tag_pointer, tag, multiplier)


def read_board_cell_jagged_array(
    memory: MemoryReader,
    address: int,
) -> tuple[BoardCellSnapshot, ...]:
    """Decode a structurally complete BoardCellDTO[8][8] snapshot."""

    outer = read_reference_array(memory, address, max_length=8)
    if len(outer) != 8:
        raise LayoutValidationError(f"outer board array length is {len(outer)}, expected 8")
    cells: list[BoardCellSnapshot] = []
    for outer_index, inner_pointer in enumerate(outer):
        if not is_canonical_user_pointer(inner_pointer):
            raise LayoutValidationError(f"inner array {outer_index} is null/invalid")
        inner = read_reference_array(memory, inner_pointer, max_length=8)
        if len(inner) != 8:
            raise LayoutValidationError(
                f"inner board array {outer_index} length is {len(inner)}, expected 8"
            )
        for cell_pointer in inner:
            if not is_canonical_user_pointer(cell_pointer):
                raise LayoutValidationError("BoardCellDTO pointer is null/invalid")
            cells.append(read_board_cell(memory, cell_pointer))
    coordinates = {(cell.row, cell.col) for cell in cells}
    if len(cells) != 64 or len(coordinates) != 64:
        raise LayoutValidationError(
            f"snapshot has {len(cells)} cells and {len(coordinates)} unique coordinates"
        )
    return tuple(sorted(cells, key=lambda cell: (cell.row, cell.col)))


@dataclass(frozen=True)
class CombatBatchSnapshot:
    address: int
    sequence: int
    board_array: int
    cells: tuple[BoardCellSnapshot, ...]


def read_combat_batch(
    memory: MemoryReader,
    address: int,
    *,
    expected_class: int,
) -> CombatBatchSnapshot:
    raw = _read_exact(memory, address, WS_COMBAT_BATCH_BOARD_OFFSET + 8)
    class_pointer = struct.unpack_from("<Q", raw, 0)[0]
    sequence = struct.unpack_from("<q", raw, WS_COMBAT_BATCH_SEQUENCE_OFFSET)[0]
    board_array = struct.unpack_from("<Q", raw, WS_COMBAT_BATCH_BOARD_OFFSET)[0]
    if class_pointer != expected_class:
        raise LayoutValidationError("candidate is not a WsCombatBatch object")
    if sequence < 0:
        raise LayoutValidationError("WsCombatBatch.srvSeq is negative")
    if not is_canonical_user_pointer(board_array):
        raise LayoutValidationError("WsCombatBatch.board is null/invalid")
    cells = read_board_cell_jagged_array(memory, board_array)
    return CombatBatchSnapshot(address, sequence, board_array, cells)


def all_dots_index(column: int, row: int, second_dimension_length: int = 8) -> int:
    """Index proven by native Dot.GetAllDots: col * secondLength + row."""

    if not 0 <= column < 8 or not 0 <= row < 8:
        raise ValueError("board coordinate out of range")
    if second_dimension_length != 8:
        raise ValueError("unexpected second dimension length")
    return column * second_dimension_length + row
