from __future__ import annotations

import struct
import unittest
from types import SimpleNamespace

from pokiguard_v2.native_card_ui import (
    NativeCardUiReader, NativeGeometryBusyError, _COMPONENT_GO_ICALL, _COMPONENT_GO_RVA,
    _NATIVE_SIGNATURES, _UNMARSHAL_SIGNATURE,
)
from pokiguard_v2.combat_cards import (
    BOARD_CARD_CONTAINER_OFFSET,
    BOARD_CARDS_IN_HAND_OFFSET,
)
from pokiguard_v2.il2cpp_layout import LayoutValidationError
from pokiguard_v2.gameplay_ui import locate_native_pet_skill_control
from tests.test_combat_cards import FakeMemory


class NativeFixture:
    def __init__(self):
        self.memory = FakeMemory()
        self.next = 0x20000000000
        self.ga, self.unity = 0x180000000, 0x7FFC00000000
        self.q(self.ga + _COMPONENT_GO_ICALL, self.unity + _COMPONENT_GO_RVA)
        self.memory.map(self.unity, b"MZ")
        for rva, code in _NATIVE_SIGNATURES:
            self.memory.map(self.unity + rva, bytes.fromhex(code))
        rva, code = _UNMARSHAL_SIGNATURE
        self.memory.map(self.ga + rva, bytes.fromhex(code))
        self.go_class = self.klass("GameObject", "UnityEngine")
        self.rect_class = self.klass("RectTransform", "UnityEngine")
        self.canvas_class = self.klass("Canvas", "UnityEngine")
        self.card_class = self.klass("CardUI", "")
        self.button_class = self.klass("Button", "UnityEngine.UI")
        self.root = self.node(None, (-600, -300, 1200, 600), (0, 0, 100))
        self.canvas = self.component(self.root, self.canvas_class)
        self.i(self.canvas.native + 0x38, 1)  # screen-space camera Canvas
        self.container = self.node(self.root, (-150, -33, 300, 66), (0, -220, 0))
        self.cards = []
        for index in range(5):
            node = self.node(self.container, (-25, -32.5, 50, 65), (-100 + index * 50, 0, 0))
            node.card = self.component(node, self.card_class)
            node.button = self.component(node, self.button_class)
            self.cards.append(node)
        self.board = self.alloc()
        self.q(
            self.board + BOARD_CARD_CONTAINER_OFFSET,
            self.container.managed_transform,
        )
        self.list = self.alloc()
        self.array = self.alloc()
        self.q(self.board + BOARD_CARDS_IN_HAND_OFFSET, self.list)
        self.q(self.list + 0x10, self.array)
        self.i(self.list + 0x18, 5)
        self.i(self.list + 0x1C, 1)
        self.q(self.array + 0x18, 5)
        # Owner list is deliberately shuffled: it is not visual/sibling order.
        for index, card in enumerate(reversed(self.cards)):
            self.q(self.array + 0x20 + index * 8, card.managed)

    def alloc(self):
        value = self.next
        self.next += 0x1000
        self.memory.map(value, bytes(0x400))
        return value

    def q(self, address, value):
        self.memory.map(address, struct.pack("<Q", value))

    def i(self, address, value):
        self.memory.map(address, struct.pack("<i", value))

    def klass(self, name, namespace):
        result = self.alloc()
        for offset, value in ((0x10, name), (0x18, namespace)):
            pointer = self.alloc()
            self.memory.map(pointer, value.encode() + b"\0")
            self.q(result + offset, pointer)
        return result

    def string(self, value):
        result = self.alloc()
        string_class = self.alloc()
        self.q(result, string_class)
        self.i(result + 0x10, len(value))
        self.memory.map(result + 0x14, value.encode("utf-16-le"))
        return result

    def wrapper(self, native, klass):
        managed, handle = self.alloc(), self.alloc()
        self.q(managed, klass)
        self.q(managed + 0x10, native)
        self.q(native + 0x20, handle)
        self.q(handle, managed)
        return managed

    def component(self, node, klass):
        native = self.alloc()
        managed = self.wrapper(native, klass)
        self.q(native + 0x28, node.native)
        node.components.append(native)
        self.q(node.native + 0x38, len(node.components))
        self.q(node.storage + (len(node.components) - 1) * 16 + 8, native)
        return SimpleNamespace(native=native, managed=managed)

    def node(self, parent, rect, pos):
        native = self.alloc()
        node = SimpleNamespace(native=native, components=[], children=[], storage=self.alloc())
        node.managed = self.wrapper(native, self.go_class)
        self.memory.map(native + 0x4F, b"\1")
        self.q(native + 0x28, node.storage)
        transform = self.component(node, self.rect_class)
        node.transform, node.managed_transform = transform.native, transform.managed
        self.memory.map(node.transform + 0xC0, struct.pack("<4f", *rect))
        access, data, trs = self.alloc(), self.alloc(), self.alloc()
        node.trs, node.data = trs, data
        self.q(node.transform + 0x40, access)
        self.q(access, data)
        self.q(data + 0x20, trs)
        self.memory.map(trs, struct.pack("<12f", *pos, 0, 0, 0, 0, 1, 1, 1, 1, 0))
        node.child_array = self.alloc()
        self.q(node.transform + 0x50, node.child_array)
        if parent:
            self.q(node.transform + 0x70, parent.transform)
            parent.children.append(node.transform)
            self.i(parent.transform + 0x60, len(parent.children))
            self.q(parent.child_array + 8 * (len(parent.children) - 1), node.transform)
        return node

    def reader(self):
        return NativeCardUiReader(self.memory, self.ga)

    def dot_board(self):
        dot_class = self.klass("Dot", "")
        tags = ("Vang", "XanhDuong", "Do", "Tim", "Xanh", "Trang")
        nodes, dots = [], []
        for row in range(8):
            for column in range(8):
                node = self.node(None, (-1, -1, 2, 2), (0, 0, 0))
                dot = self.component(node, dot_class)
                self.i(dot.managed + 0x20, column)
                self.i(dot.managed + 0x24, row)
                self.q(dot.managed + 0x48, self.board)
                self.i(dot.managed + 0x88, 1 + (row + column) % 4)
                self.q(dot.managed + 0x100, self.string(tags[(row * 8 + column) % len(tags)]))
                nodes.append(node)
                dots.append(dot)
        return dot_class, nodes, dots


class NativeCardUiTests(unittest.TestCase):
    def setUp(self):
        self.fixture = NativeFixture()
        self.reader = self.fixture.reader()

    def hand(self):
        return self.reader.read_hand(self.fixture.board, self.fixture.card_class)

    def test_exact_board_dot_components_are_decoded_without_heap_scan(self):
        dot_class, nodes, dots = self.fixture.dot_board()
        result = self.reader.read_dot_board(
            self.fixture.board,
            tuple(node.managed for node in nodes),
            dot_class,
        )
        self.assertEqual(len(result.cells), 64)
        self.assertEqual(
            {(cell.row, cell.col) for cell in result.cells},
            {(row, col) for row in range(8) for col in range(8)},
        )
        self.assertEqual(set(result.dot_addresses), {dot.managed for dot in dots})

    def test_moving_dot_board_is_rejected(self):
        dot_class, nodes, dots = self.fixture.dot_board()
        self.fixture.memory.map(dots[17].managed + 0xB0, b"\1")
        with self.assertRaisesRegex(NativeGeometryBusyError, "still moving"):
            self.reader.read_dot_board(
                self.fixture.board,
                tuple(node.managed for node in nodes),
                dot_class,
            )

    def test_dot_mutation_during_second_sample_is_rejected(self):
        dot_class, nodes, dots = self.fixture.dot_board()
        original = self.reader._dot_sample
        calls = 0

        def mutate_after_first_board(dot):
            nonlocal calls
            result = original(dot)
            calls += 1
            if calls == 64:
                self.fixture.i(dots[0].managed + 0x88, 4)
            return result

        self.reader._dot_sample = mutate_after_first_board
        with self.assertRaisesRegex(NativeGeometryBusyError, "changed during"):
            self.reader.read_dot_board(
                self.fixture.board,
                tuple(node.managed for node in nodes),
                dot_class,
            )

    def test_owned_handles_find_new_card_without_any_region_scan(self):
        f = self.fixture
        hand = self.hand()
        self.assertEqual(len(hand.entries), 5)
        self.assertEqual(len(hand.visible), 5)
        self.assertEqual(hand.slot_for_card(f.cards[4].card.managed), 4)
        self.assertEqual(hand.slot_for_card(f.cards[0].card.managed), 0)
        entry = hand.entry_for_card(f.cards[4].card.managed)
        self.assertEqual(entry.root_transform, f.root.transform)
        self.assertAlmostEqual(entry.viewport_rect[0], 675 / 1200)
        self.assertAlmostEqual(entry.viewport_rect[1], 487.5 / 600)
        self.reader.validate_button_owner(f.cards[4].card.managed, f.cards[4].button.managed, entry)

    def test_inactive_fusion_is_excluded_only_with_runtime_active_proof(self):
        self.fixture.memory.map(self.fixture.cards[0].native + 0x4F, b"\0")
        hand = self.hand()
        self.assertEqual(len(hand.entries), 5)
        self.assertEqual(len(hand.visible), 4)
        self.assertEqual(hand.slot_for_card(self.fixture.cards[4].card.managed), 3)

    def test_same_reader_discovers_card_replaced_after_evolution(self):
        before = self.hand()
        f = self.fixture
        old = f.cards[4].card
        # New managed wrapper in another allocation, same native component.
        new = f.wrapper(old.native, f.card_class)
        after = self.hand()
        self.assertIn(old.managed, before.card_ui_addresses)
        self.assertNotIn(old.managed, after.card_ui_addresses)
        self.assertIn(new, after.card_ui_addresses)

    def test_unknown_active_is_not_hidden_or_visible(self):
        self.fixture.memory.map(self.fixture.cards[0].native + 0x4F, b"\xff")
        with self.assertRaisesRegex(LayoutValidationError, "activeInHierarchy"):
            self.hand()

    def test_destroyed_managed_wrapper_is_rejected(self):
        self.fixture.q(self.fixture.cards[4].managed + 0x10, 0)
        with self.assertRaises(LayoutValidationError):
            self.hand()

    def test_foreign_button_is_rejected(self):
        hand = self.hand()
        f = self.fixture
        with self.assertRaisesRegex(LayoutValidationError, "ownership mismatch"):
            self.reader.validate_button_owner(f.cards[4].card.managed, f.cards[0].button.managed,
                                              hand.entry_for_card(f.cards[4].card.managed))

    def test_wrong_container_is_rejected(self):
        self.fixture.q(self.fixture.cards[4].transform + 0x70, self.fixture.root.transform)
        with self.assertRaisesRegex(LayoutValidationError, "cardContainer"):
            self.hand()

    def test_dirty_rect_is_rejected(self):
        self.fixture.memory.map(self.fixture.cards[3].transform + 0xF9, b"\1")
        with self.assertRaisesRegex(LayoutValidationError, "dirty rect"):
            self.hand()

    def test_pending_transform_job_is_rejected(self):
        self.fixture.q(self.fixture.cards[4].data, 0x123456)
        with self.assertRaisesRegex(LayoutValidationError, "job pending"):
            self.hand()

    def test_pending_job_field_is_opaque_not_a_dereferenceable_pointer(self):
        self.fixture.q(self.fixture.cards[4].data, 0xFFFFFFFFFFFFFFFF)
        with self.assertRaisesRegex(NativeGeometryBusyError, "job pending"):
            self.hand()

    def test_invalid_transform_index_is_not_transient_geometry(self):
        f = self.fixture
        access = struct.unpack("<Q", f.memory.read(f.cards[4].transform + 0x40, 8))[0]
        f.i(access + 8, -1)
        with self.assertRaisesRegex(LayoutValidationError, "invalid transform index") as raised:
            self.hand()
        self.assertNotIsInstance(raised.exception, NativeGeometryBusyError)

    def test_new_whole_read_after_busy_rechecks_geometry_and_drops_partial_cache(self):
        f = self.fixture
        f.memory.map(f.container.transform + 0xF9, b"\1")
        with self.assertRaises(NativeGeometryBusyError):
            self.hand()
        f.memory.map(f.container.transform + 0xF9, b"\0")
        f.memory.map(f.container.trs, struct.pack("<f", 10))
        hand = self.hand()
        self.assertAlmostEqual(hand.entry_for_card(f.cards[4].card.managed).viewport_rect[0], 685 / 1200)

    def test_overlapping_layout_is_not_guessed(self):
        self.fixture.memory.map(self.fixture.cards[4].trs, struct.pack("<f", 50))
        with self.assertRaisesRegex(LayoutValidationError, "ambiguous/animating"):
            self.hand()

    def test_signature_mismatch_disables_native_layout(self):
        self.fixture.memory.map(self.fixture.unity + _NATIVE_SIGNATURES[0][0], b"\0")
        with self.assertRaisesRegex(LayoutValidationError, "signature mismatch"):
            self.fixture.reader()

    def test_world_space_canvas_not_projected_as_screen_space(self):
        self.fixture.i(self.fixture.canvas.native + 0x38, 2)
        with self.assertRaisesRegex(LayoutValidationError, "Canvas mode"):
            self.hand()

    def test_screen_space_root_canvas_can_have_plain_scene_transform_parent(self):
        f = self.fixture
        scene = f.node(None, (-1, -1, 2, 2), (10, 20, 30))
        f.q(scene.managed_transform, f.klass("Transform", "UnityEngine"))
        f.q(f.root.transform + 0x70, scene.transform)
        f.i(scene.transform + 0x60, 1)
        f.q(scene.child_array, f.root.transform)
        hand = self.hand()
        self.assertEqual(len(hand.visible), 5)
        self.assertTrue(all(entry.root_transform == f.root.transform for entry in hand.visible))

    def test_nested_canvas_uses_effective_root_canvas_not_its_raw_mode(self):
        f = self.fixture
        nested = f.component(f.container, f.canvas_class)
        f.i(nested.native + 0x38, 2)  # ignored when a parent Canvas is present
        f.q(nested.native + 0x308, f.canvas.native)
        self.assertEqual(len(self.hand().visible), 5)

    def test_retry4_live_combat_hierarchy_projects_exact_skill_rectangle(self):
        # 2026-09-04 M_bfb931a0 read-only trace. Synthetic addresses only.
        # Combat's root Canvas has a plain scene Transform parent; nested
        # Canvas raw mode is 2 but its effective root mode is screen-space 1.
        f = self.fixture
        scene = f.node(None, (-1, -1, 2, 2), (0, 0, 0))
        f.q(scene.managed_transform, f.klass("Transform", "UnityEngine"))
        root = f.node(scene, (-448.0903015, -224.0451508, 896.180603, 448.0903015), (0, 10, 90))
        canvas = f.component(root, f.canvas_class)
        f.i(canvas.native + 0x38, 1)

        def scale(node, value):
            f.memory.map(node.trs + 0x20, struct.pack("<3f", value, value, value))

        scale(root, .02231693)  # world/camera TRS must NOT enter projection
        level4 = f.node(root, (-448.09106, -224.090148, 896.18213, 448.180298), (.0007324, -.00134277, 0))
        level3 = f.node(level4, (-408.09106, -204.210144, 816.18213, 408.420288), (.0012207, -.00085449, 0))
        scale(level3, 1.0982604)
        nested = f.component(level3, f.canvas_class)
        f.i(nested.native + 0x38, 2)
        f.q(nested.native + 0x308, canvas.native)
        level2 = f.node(level3, (-439.18106, -108.589996, 878.36212, 217.17999), (-.076416, 101.910095, 0))
        scale(level2, .930616)
        container = f.node(level2, (-144.965, -38.100006, 289.92999, 76.200012), (1.335, -265.720001, 0))
        scale(container, .994999885)
        f.q(
            f.board + BOARD_CARD_CONTAINER_OFFSET,
            container.managed_transform,
        )
        cards = []
        for i in range(5):
            card = f.node(container, (-25, -32.5, 50, 65), (-100 + i * 50, 5.600006, 0))
            card.card = f.component(card, f.card_class)
            card.button = f.component(card, f.button_class)
            cards.append(card)
            f.q(f.array + 0x20 + i * 8, card.managed)
        hand = self.hand()
        entry = hand.entry_for_card(cards[4].card.managed)
        self.assertEqual(entry.root_transform, root.transform)
        self.assertAlmostEqual(entry.root_aspect, 2)
        for actual, expected in zip(entry.viewport_rect, (.5865379147, .7698431177, .6432758262, .9173616877)):
            self.assertAlmostEqual(actual, expected, places=6)
        self.reader.validate_button_owner(cards[4].card.managed, cards[4].button.managed, entry)

    def test_odd_engine_handle_is_not_guessed(self):
        self.fixture.q(self.fixture.cards[4].native + 0x20, 0x20000000101)
        with self.assertRaisesRegex(LayoutValidationError, "unsupported scripting handle"):
            self.hand()

    def test_unrelated_tagged_component_does_not_hide_current_cardui(self):
        f = self.fixture
        unrelated = f.component(f.cards[4], f.button_class)
        f.q(unrelated.native + 0x20, 3)
        self.assertIn(f.cards[4].card.managed, self.hand().card_ui_addresses)

    def test_out_of_plane_rect_is_not_projected_as_flat_ui(self):
        f = self.fixture
        f.memory.map(f.cards[4].trs + 8, struct.pack("<f", 2))
        with self.assertRaisesRegex(LayoutValidationError, "out-of-plane"):
            self.hand()

    def test_geometry_cache_is_cleared_per_read(self):
        first = self.hand().visible[4].viewport_rect
        f = self.fixture
        f.memory.map(f.container.trs, struct.pack("<f", 10))
        second = self.hand().visible[4].viewport_rect
        self.assertAlmostEqual(second[0] - first[0], 10 / 1200)

    def test_shared_canvas_ownership_walk_is_not_repeated_for_every_card(self):
        f = self.fixture
        original = self.reader._components
        root_calls = []

        def counted(owner):
            if owner == f.root.native:
                root_calls.append(owner)
            return original(owner)

        self.reader._components = counted
        self.hand()
        # One RectTransform owner check + one Canvas enumeration, not five
        # independent Canvas enumerations for the five sibling cards.
        self.assertEqual(len(root_calls), 2)

    def test_cached_canvas_path_still_rejects_parent_change_during_hand_read(self):
        f = self.fixture
        original = self.reader._viewport_rect
        calls = 0

        def changing(transform):
            nonlocal calls
            result = original(transform)
            calls += 1
            if calls == 5:
                f.q(f.container.transform + 0x70, f.cards[0].transform)
            return result

        self.reader._viewport_rect = changing
        with self.assertRaisesRegex(LayoutValidationError, "geometry changed"):
            self.hand()

    def test_canvas_path_cache_does_not_survive_next_hand_read(self):
        self.hand()
        f = self.fixture
        # Remove the Canvas component from the current root GO. Prior path
        # data must not authorize a new hand read without a current Canvas.
        f.q(f.root.native + 0x38, 1)
        with self.assertRaisesRegex(LayoutValidationError, "root Canvas not found"):
            self.hand()

    def test_native_click_uses_rectangle_not_historical_slot(self):
        width, height = 800, 400
        rgb = bytes((240, 80, 5)) * width * height
        result = locate_native_pet_skill_control(rgb, width, height, (.7, .75, .76, .9), root_aspect=2)
        self.assertTrue(result.found)
        self.assertEqual(result.normalized_point, (.73, .81))
        mismatch = locate_native_pet_skill_control(rgb, width, height, (.7, .75, .76, .9), root_aspect=1.6)
        self.assertFalse(mismatch.found)

    def test_layout_change_after_first_card_invalidates_whole_hand(self):
        f = self.fixture
        original = self.reader._viewport_rect
        calls = 0

        def changing(transform):
            nonlocal calls
            result = original(transform)
            calls += 1
            if calls == 5:
                f.memory.map(f.container.trs, struct.pack("<f", 5))
            return result

        self.reader._viewport_rect = changing
        with self.assertRaisesRegex(LayoutValidationError, "geometry changed"):
            self.hand()


if __name__ == "__main__":
    unittest.main()
