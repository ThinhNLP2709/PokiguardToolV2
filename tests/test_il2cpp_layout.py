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

from pokiguard_v2.il2cpp_external import MemoryRegion
from pokiguard_v2.il2cpp_layout import (
    LayoutValidationError,
    all_dots_index,
    observe_rectangular_reference_array,
    read_board_cell_jagged_array,
    read_il2cpp_string,
)
from pokiguard_v2.memory_scan import (
    bounded_private_writable_regions,
    regions_containing_addresses,
    regions_sharing_anchor_allocations,
    scan_aligned_qwords,
    validate_dot_pointer_hits,
)
from tools.board_memory_watch import gem_for_tag
from tools.live_cell_state_watch import (
    read_board_ws_candidate,
    read_pending_queue,
)


class FakeMemory:
    def __init__(self) -> None:
        self.bytes: dict[int, int] = {}

    def map(self, address: int, data: bytes | bytearray) -> None:
        self.bytes.update({address + index: value for index, value in enumerate(data)})

    def read(self, address: int, size: int) -> bytes:
        return bytes(self.bytes[address + index] for index in range(size))

    def is_readable(self, address: int, size: int) -> bool:
        return size > 0 and all(address + index in self.bytes for index in range(size))


def managed_array(class_pointer: int, values: list[int], bounds: int = 0) -> bytes:
    raw = bytearray(0x20 + len(values) * 8)
    struct.pack_into("<4Q", raw, 0, class_pointer, 0, bounds, len(values))
    if values:
        struct.pack_into(f"<{len(values)}Q", raw, 0x20, *values)
    return bytes(raw)


class Il2CppLayoutTests(unittest.TestCase):
    CLASS = 0x0000020000000000
    ARRAY = 0x0000021000000000
    BOUNDS = 0x0000022000000000

    def make_rectangular_array(self, max_length: int = 64) -> FakeMemory:
        memory = FakeMemory()
        memory.map(self.CLASS, bytearray(8))
        bounds = bytearray(0x20)
        struct.pack_into("<Q", bounds, 0x00, 8)
        struct.pack_into("<i", bounds, 0x08, 0)
        struct.pack_into("<Q", bounds, 0x10, 8)
        struct.pack_into("<i", bounds, 0x18, 0)
        memory.map(self.BOUNDS, bounds)
        elements = [0x0000030000000000 + index * 0x100 for index in range(64)]
        raw = bytearray(0x20 + 64 * 8)
        struct.pack_into(
            "<4Q", raw, 0, self.CLASS, 0, self.BOUNDS, max_length
        )
        struct.pack_into("<64Q", raw, 0x20, *elements)
        memory.map(self.ARRAY, raw)
        for pointer in elements:
            memory.map(pointer, bytearray(0x18))
        return memory

    def test_rectangular_array_is_exposed_only_after_full_validation(self) -> None:
        observation = observe_rectangular_reference_array(
            self.make_rectangular_array(), self.ARRAY
        )
        self.assertTrue(observation.layout_verified)
        self.assertEqual(observation.max_length, 64)
        self.assertEqual(observation.bounds.dimension_lengths, (8, 8))
        self.assertEqual(observation.bounds.lower_bounds, (0, 0))
        self.assertEqual(len(observation.elements or ()), 64)
        self.assertEqual(len(observation.raw_qwords_00_through_80), 17)

    def test_wrong_max_length_fails_closed_without_elements(self) -> None:
        observation = observe_rectangular_reference_array(
            self.make_rectangular_array(max_length=63), self.ARRAY
        )
        self.assertFalse(observation.layout_verified)
        self.assertIsNone(observation.elements)
        self.assertIn("max_length", observation.rejection_reason or "")

    def test_native_index_order_is_column_major_then_row(self) -> None:
        self.assertEqual(all_dots_index(0, 7), 7)
        self.assertEqual(all_dots_index(1, 0), 8)
        self.assertEqual(all_dots_index(7, 7), 63)

    def test_bounded_utf16_string(self) -> None:
        memory = FakeMemory()
        string_pointer = 0x0000023000000000
        memory.map(self.CLASS, bytearray(8))
        text = "xanhduong"
        raw = bytearray(0x14 + len(text) * 2)
        struct.pack_into("<Q", raw, 0, self.CLASS)
        struct.pack_into("<i", raw, 0x10, len(text))
        raw[0x14:] = text.encode("utf-16-le")
        memory.map(string_pointer, raw)
        self.assertEqual(read_il2cpp_string(memory, string_pointer), text)
        with self.assertRaises(LayoutValidationError):
            read_il2cpp_string(memory, string_pointer, max_length=4)

    def test_complete_board_cell_jagged_array(self) -> None:
        memory = FakeMemory()
        memory.map(self.CLASS, bytearray(8))
        outer_address = 0x0000024000000000
        inner_addresses = [0x0000024100000000 + col * 0x1000 for col in range(8)]
        memory.map(outer_address, managed_array(self.CLASS, inner_addresses))
        for col, inner_address in enumerate(inner_addresses):
            cell_addresses: list[int] = []
            for row in range(8):
                cell = 0x0000025000000000 + (col * 8 + row) * 0x100
                string_pointer = 0x0000026000000000 + (col * 8 + row) * 0x100
                tag = "vang" if (col + row) % 2 == 0 else "xanh"
                string_raw = bytearray(0x14 + len(tag) * 2)
                struct.pack_into("<Q", string_raw, 0, self.CLASS)
                struct.pack_into("<i", string_raw, 0x10, len(tag))
                string_raw[0x14:] = tag.encode("utf-16-le")
                memory.map(string_pointer, string_raw)
                cell_raw = bytearray(0x24)
                struct.pack_into("<Q", cell_raw, 0, self.CLASS)
                struct.pack_into("<iiQ", cell_raw, 0x10, col, row, string_pointer)
                struct.pack_into("<i", cell_raw, 0x20, 1)
                memory.map(cell, cell_raw)
                cell_addresses.append(cell)
            memory.map(inner_address, managed_array(self.CLASS, cell_addresses))
        cells = read_board_cell_jagged_array(memory, outer_address)
        self.assertEqual(len(cells), 64)
        self.assertEqual((cells[0].row, cells[0].col), (0, 0))
        self.assertEqual((cells[-1].row, cells[-1].col), (7, 7))

    def test_exact_tag_mapping_has_no_fuzzy_fallback(self) -> None:
        self.assertEqual(gem_for_tag("xanhduong"), "MANA")
        self.assertEqual(gem_for_tag("xanhduong Dot"), "MANA")
        self.assertEqual(gem_for_tag("trang Dot"), "DRAIN")
        self.assertEqual(gem_for_tag("Vang"), "SWORD")
        self.assertIsNone(gem_for_tag("blue"))
        self.assertIsNone(gem_for_tag(None))


class MemoryScanTests(unittest.TestCase):
    def test_bounded_scan_envelope_excludes_large_or_non_private_regions(self) -> None:
        regions = [
            MemoryRegion(0x10000, 0x1000, 0x04, 0x20000),
            MemoryRegion(0x20000, 9 * 1024 * 1024, 0x04, 0x20000),
            MemoryRegion(0x30000, 0x1000, 0x02, 0x20000),
            MemoryRegion(0x40000, 0x1000, 0x04, 0x1000000),
        ]
        self.assertEqual(bounded_private_writable_regions(regions), (regions[0],))

    def test_learns_only_regions_that_contain_actual_hits(self) -> None:
        regions = (
            MemoryRegion(0x10000, 0x1000, 0x04, 0x20000),
            MemoryRegion(0x20000, 0x2000, 0x04, 0x20000),
            MemoryRegion(0x40000, 0x1000, 0x04, 0x20000),
        )
        learned = regions_containing_addresses(
            regions, (0x10000, 0x20FFF, 0x99999)
        )
        self.assertEqual(learned, (regions[0], regions[1]))

    def test_anchor_allocation_includes_split_regions_without_guessing_neighbors(self) -> None:
        regions = (
            MemoryRegion(0x10000, 0x1000, 0x04, 0x20000, 0x10000),
            MemoryRegion(0x13000, 0x2000, 0x04, 0x20000, 0x10000),
            MemoryRegion(0x20000, 0x1000, 0x04, 0x20000, 0x20000),
        )
        selected = regions_sharing_anchor_allocations(regions, (0x10500,))
        self.assertEqual(selected, (regions[0], regions[1]))

    def test_anchor_allocation_falls_back_to_direct_region_without_metadata(self) -> None:
        regions = (
            MemoryRegion(0x10000, 0x1000, 0x04, 0x20000),
            MemoryRegion(0x13000, 0x2000, 0x04, 0x20000),
        )
        selected = regions_sharing_anchor_allocations(regions, (0x10500,))
        self.assertEqual(selected, (regions[0],))

    def test_aligned_qword_scan_and_dot_validation(self) -> None:
        memory = FakeMemory()
        base = 0x0000040000000000
        board = 0x0000041000000000
        dot_class = 0x0000042000000000
        dot = base + 0x200
        region_raw = bytearray(0x1000)
        struct.pack_into("<Q", region_raw, 0x248, board)
        memory.map(base, region_raw)
        dot_raw = bytearray(0xF0)
        struct.pack_into("<Q", dot_raw, 0, dot_class)
        struct.pack_into("<Q", dot_raw, 0x10, 0x0000043000000000)
        struct.pack_into("<ii", dot_raw, 0x20, 3, 4)
        struct.pack_into("<Q", dot_raw, 0x48, board)
        struct.pack_into("<i", dot_raw, 0x88, 2)
        prefab = 0x0000044000000000
        struct.pack_into("<Q", dot_raw, 0xD8, prefab)
        memory.map(dot, dot_raw)
        memory.map(prefab, bytearray(0x18))

        scan = scan_aligned_qwords(
            memory,
            [MemoryRegion(base, 0x1000, 0x04, 0x20000)],
            {"board": board},
            chunk_size=4096,
        )
        result = validate_dot_pointer_hits(
            memory,
            scan.matches["board"],
            board_pointer=board,
            dot_class=dot_class,
        )
        self.assertEqual(len(result.candidates), 1)
        self.assertEqual((result.candidates[0].row, result.candidates[0].column), (4, 3))
        self.assertEqual(len(result.missing_coordinates), 63)

    def test_runtime_validated_board_ws_queue_layout(self) -> None:
        memory = FakeMemory()
        board_ws = 0x0000050000000000
        board_ws_class = 0x0000051000000000
        board = 0x0000052000000000
        queue = 0x0000053000000000
        queue_class = 0x0000054000000000
        array = 0x0000055000000000
        array_class = 0x0000056000000000
        batch = 0x0000057000000000
        for pointer in (board_ws_class, queue_class, array_class):
            memory.map(pointer, bytearray(8))

        ws_raw = bytearray(0x59)
        struct.pack_into("<Q", ws_raw, 0, board_ws_class)
        struct.pack_into("<Q", ws_raw, 0x10, 0x0000058000000000)
        struct.pack_into("<Q", ws_raw, 0x20, board)
        struct.pack_into("<Q", ws_raw, 0x50, queue)
        ws_raw[0x58] = 1
        memory.map(board_ws, ws_raw)

        queue_raw = bytearray(0x30)
        struct.pack_into("<Q", queue_raw, 0, queue_class)
        struct.pack_into("<Q", queue_raw, 0x10, array)
        struct.pack_into("<iiii", queue_raw, 0x18, 1, 2, 1, 5)
        memory.map(queue, queue_raw)

        array_raw = bytearray(0x20 + 4 * 0x18)
        struct.pack_into("<4Q", array_raw, 0, array_class, 0, 0, 4)
        struct.pack_into("<Q", array_raw, 0x20 + 0x18 + 0x08, batch)
        memory.map(array, array_raw)

        owner = read_board_ws_candidate(
            memory,
            board_ws,
            expected_class=board_ws_class,
            expected_board=board,
        )
        observed = read_pending_queue(memory, owner.queue)
        self.assertTrue(owner.render_running)
        self.assertEqual(observed.batch_addresses, (batch,))
        self.assertEqual((observed.head, observed.tail, observed.size), (1, 2, 1))


if __name__ == "__main__":
    unittest.main()
