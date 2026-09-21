"""Bounded, read-only Unity ownership/geometry for the 1.7.4-b4 card strip.

No heap scan and no engine invocation. Offsets below are native-code verified,
not Cpp2IL managed-field offsets; see docs/phase3b3_native_card_evidence.md.
Every native layout is enabled only after matching the relevant code bytes.
"""

from __future__ import annotations

from dataclasses import dataclass
import math
import struct

from .combat_cards import BOARD_CARD_CONTAINER_OFFSET, read_cards_in_hand_anchors
from .il2cpp_layout import (
    BoardCellSnapshot,
    LayoutValidationError,
    is_canonical_user_pointer,
    read_il2cpp_string,
)


# Component.get_gameObject_Injected cache -> verified UnityPlayer function RVA.
_COMPONENT_GO_ICALL = 0x355F678
_COMPONENT_GO_RVA = 0x1067390
_NATIVE_SIGNATURES = (
    (0x1067396, "488b5928"),  # Component -> GameObject +28
    (0x1068897, "488b5638488b4e2848c1e20448035628483bca"),
    (0x10688BE, "4883c110483bca75edeb22488b5908"),  # 16-byte entries, ptr +8
    (0x10688D2, "488b7b20"),  # component scripting handle
    (0x1069C46, "837938007427488b4128488b5808"),  # first component = Transform
    (0x179BE86, "80794fff488bd9740d80794f000f95c0"),  # active cache (FF unknown)
    (0x1078CC9, "0f1083c0000000"),  # RectTransform cached rect
    (0x1440E2E, "488b4170"),  # parent
    (0x1440E4E, "48635860418bd285db7e1e488b4050"),  # parent's children
    (0x1078FA0, "498b7840488b1f"),  # Transform access handle
    (0x1078FD8, "8b4708488b5c2440488d1440488b074803d2488b48200f1004d1"),
    (0x107922E, "0f1044d110"),  # quaternion in 48-byte TRS at +10
    (0x107934E, "0f1044d120"),  # scale in TRS at +20
    (0xB5AB16, "4883b90803000000"),  # Canvas parent canvas
    (0xB5AB4E, "8b4338"),  # Canvas renderMode
)
_UNMARSHAL_SIGNATURE = (
    0x10971EF,
    "4885db7433f6c301740d488bcbe8bfe416ff488bd8eb03488b1b",
)


class NativeGeometryBusyError(LayoutValidationError):
    """A read overlapped a Unity layout/job update; it cannot authorize input."""


@dataclass(frozen=True)
class NativeCardEntry:
    game_object: int
    native_game_object: int
    transform: int
    card_ui_addresses: tuple[int, ...]
    active: bool
    # Viewport normalized, origin top-left. None for inactive objects.
    viewport_rect: tuple[float, float, float, float] | None
    root_transform: int | None
    root_aspect: float | None


@dataclass(frozen=True)
class NativeCardHand:
    board: int
    container: int
    entries: tuple[NativeCardEntry, ...]

    @property
    def visible(self) -> tuple[NativeCardEntry, ...]:
        return tuple(sorted(
            (entry for entry in self.entries if entry.active),
            key=lambda entry: entry.viewport_rect[0],
        ))

    @property
    def card_ui_addresses(self) -> tuple[int, ...]:
        return tuple(address for entry in self.visible for address in entry.card_ui_addresses)

    def entry_for_card(self, card_ui: int) -> NativeCardEntry | None:
        found = tuple(entry for entry in self.visible if card_ui in entry.card_ui_addresses)
        return found[0] if len(found) == 1 else None

    def slot_for_card(self, card_ui: int) -> int | None:
        return next((index for index, entry in enumerate(self.visible)
                     if card_ui in entry.card_ui_addresses), None)


@dataclass(frozen=True)
class NativeDotBoard:
    """Current Board-owned Dot identities read without a heap scan."""

    board: int
    game_objects: tuple[int, ...]
    dot_addresses: tuple[int, ...]
    cells: tuple[BoardCellSnapshot, ...]


@dataclass(frozen=True)
class NativeButtonGeometry:
    """Exact live Unity ``Button`` ownership and screen-space geometry."""

    button: int
    native_button: int
    game_object: int
    native_game_object: int
    transform: int
    active: bool
    viewport_rect: tuple[float, float, float, float] | None
    root_transform: int | None
    root_aspect: float | None


class NativeCardUiReader:
    """Direct ownership walk, limited to <=16 cards, <=64 components/node."""

    def __init__(self, memory, game_assembly_base: int) -> None:
        self.memory = memory
        self.game_assembly_base = game_assembly_base
        function = self._pointer(game_assembly_base + _COMPONENT_GO_ICALL)
        unity_base = function - _COMPONENT_GO_RVA
        if not is_canonical_user_pointer(unity_base) or self._read(unity_base, 2) != b"MZ":
            raise LayoutValidationError("native_card_ui: UnityPlayer binding unavailable")
        for rva, code in _NATIVE_SIGNATURES:
            expected = bytes.fromhex(code)
            if self._read(unity_base + rva, len(expected)) != expected:
                raise LayoutValidationError(f"native_card_ui: native signature mismatch {rva:#x}")
        rva, code = _UNMARSHAL_SIGNATURE
        if self._read(game_assembly_base + rva, len(bytes.fromhex(code))) != bytes.fromhex(code):
            raise LayoutValidationError("native_card_ui: scripting handle layout mismatch")
        self.unity_base = unity_base
        self._class_names: dict[int, tuple[str, str]] = {}
        self._nodes: dict[int, tuple] = {}
        self._canvas_paths: dict[int, tuple[tuple, int]] = {}
        self._geometry_chunks: dict[tuple[int, int], bytes] = {}

    def _remember(self, address: int, size: int) -> bytes:
        value = self._read(address, size)
        previous = self._geometry_chunks.setdefault((address, size), value)
        if previous != value:
            raise NativeGeometryBusyError("native_card_ui: geometry changed during walk")
        return value

    def _read(self, address: int, size: int) -> bytes:
        if not is_canonical_user_pointer(address) or not self.memory.is_readable(address, size):
            raise LayoutValidationError("native_card_ui: unreadable range")
        raw = self.memory.read(address, size)
        if len(raw) != size:
            raise LayoutValidationError("native_card_ui: short read")
        return raw

    def _pointer(self, address: int, *, nullable: bool = False) -> int:
        value = struct.unpack("<Q", self._read(address, 8))[0]
        if nullable and value == 0:
            return 0
        if not is_canonical_user_pointer(value):
            raise LayoutValidationError("native_card_ui: invalid pointer")
        return value

    def _managed(self, native: int, *, optional: bool = False) -> int | None:
        # UnmarshalUnityObject<T> at GA+10971EF: even handle is pointer-to-object;
        # odd handle requires an engine GC-handle resolver. Never invoke it.
        # A tagged GC handle can be a small integer, not a user-space address.
        # Inspect its tag BEFORE treating an even handle as a pointer.
        handle = struct.unpack("<Q", self._read(native + 0x20, 8))[0]
        if not handle or handle & 1:
            if optional:
                return None
            raise LayoutValidationError("native_card_ui: unavailable/unsupported scripting handle")
        managed = self._pointer(handle, nullable=optional)
        if not managed and optional:
            return None
        if self._pointer(managed + 0x10) != native:
            raise LayoutValidationError("native_card_ui: managed/native roundtrip mismatch")
        return managed

    def _class_identity(self, managed: int) -> tuple[str, str]:
        klass = self._pointer(managed)
        if klass in self._class_names:
            return self._class_names[klass]
        values = []
        for offset in (0x10, 0x18):
            address = self._pointer(klass + offset)
            raw = bytearray()
            for index in range(96):
                byte = self._read(address + index, 1)
                if byte == b"\0":
                    break
                raw.extend(byte)
            else:
                raise LayoutValidationError("native_card_ui: invalid class name")
            values.append(raw.decode("ascii"))
        self._class_names[klass] = tuple(values)
        return tuple(values)

    def _components(self, game_object: int) -> tuple[int, ...]:
        raw = self._read(game_object + 0x28, 0x18)
        storage = struct.unpack_from("<Q", raw)[0]
        count = struct.unpack_from("<Q", raw, 0x10)[0]
        if not 1 <= count <= 64:
            raise LayoutValidationError("native_card_ui: component count out of bounds")
        values = self._read(storage, count * 16)
        result = tuple(struct.unpack_from("<Q", values, i * 16 + 8)[0] for i in range(count))
        if len(set(result)) != len(result):
            raise LayoutValidationError("native_card_ui: duplicate component")
        for component in result:
            if self._pointer(component + 0x28) != game_object:
                raise LayoutValidationError("native_card_ui: component owner mismatch")
        if self._read(game_object + 0x28, 0x18) != raw or self._read(storage, count * 16) != values:
            raise LayoutValidationError("native_card_ui: component list changed")
        return result

    def _active(self, game_object: int) -> bool:
        value = self._read(game_object + 0x4F, 1)[0]
        if value not in (0, 1):
            raise LayoutValidationError("native_card_ui: activeInHierarchy cache unknown")
        return bool(value)

    def _dot_sample(
        self, dot: int
    ) -> tuple[int, int, int, int, int, int, int, int, int, int, int]:
        """Read only the b4 fields that define one settled Dot identity."""

        # One bounded object read avoids nine extra ReadProcessMemory calls per
        # sample while preserving the same fail-closed field validation.
        raw = self._read(dot, 0x132)
        class_pointer = struct.unpack_from("<Q", raw, 0)[0]
        native_component = struct.unpack_from("<Q", raw, 0x10)[0]
        column, row = struct.unpack_from("<ii", raw, 0x20)
        board = struct.unpack_from("<Q", raw, 0x48)[0]
        multiplier = struct.unpack_from("<i", raw, 0x88)[0]
        is_falling = raw[0xB0]
        is_prediction = raw[0xE0]
        squashing = raw[0xFC]
        pool_tag = struct.unpack_from("<Q", raw, 0x100)[0]
        render_hidden = raw[0x131]
        for name, value in (
            ("class", class_pointer),
            ("native component", native_component),
            ("Board", board),
            ("PoolTag", pool_tag),
        ):
            if not is_canonical_user_pointer(value):
                raise LayoutValidationError(
                    f"native_card_ui: Dot {name} pointer is invalid"
                )
        for name, value in (
            ("isFalling", is_falling),
            ("isPredictionSwap", is_prediction),
            ("squashing", squashing),
            ("RenderHidden", render_hidden),
        ):
            if value not in (0, 1):
                raise LayoutValidationError(
                    f"native_card_ui: Dot.{name} is not a valid bool"
                )
        return (
            class_pointer,
            native_component,
            column,
            row,
            board,
            multiplier,
            is_falling,
            is_prediction,
            squashing,
            pool_tag,
            render_hidden,
        )

    def read_dot_board(
        self,
        board: int,
        game_objects: tuple[int, ...],
        dot_class: int,
    ) -> NativeDotBoard:
        """Walk ``Board.allDots -> GameObject components -> Dot`` exactly.

        Pokiguard 1.7.4-b4 writes the spawn tag to ``Dot.PoolTag +0x100`` and
        keeps column, row, multiplier and Board ownership on that same managed
        component. Every wrapper/native/component relationship and every Dot
        identity field is sampled again after all 64 cells have been decoded.
        """

        if not is_canonical_user_pointer(board) or not is_canonical_user_pointer(
            dot_class
        ):
            raise LayoutValidationError("native_card_ui: invalid Dot board/class")
        if len(game_objects) != 64 or len(set(game_objects)) != 64:
            raise LayoutValidationError(
                "native_card_ui: Board.allDots does not contain 64 unique objects"
            )

        records = []
        cells = []
        for game_object in game_objects:
            native_game_object = self._pointer(game_object + 0x10)
            if self._managed(native_game_object) != game_object:
                raise LayoutValidationError(
                    "native_card_ui: Dot GameObject roundtrip mismatch"
                )
            if not self._active(native_game_object):
                raise LayoutValidationError(
                    "native_card_ui: Board.allDots contains an inactive object"
                )
            components = self._components(native_game_object)
            candidates = []
            for component in components:
                managed = self._managed(component, optional=True)
                if managed is not None and self._pointer(managed) == dot_class:
                    candidates.append((component, managed))
            if len(candidates) != 1:
                raise LayoutValidationError(
                    "native_card_ui: Dot component is missing or ambiguous"
                )
            native_component, dot = candidates[0]
            sample = self._dot_sample(dot)
            (
                _class_pointer,
                observed_native_component,
                column,
                row,
                observed_board,
                multiplier,
                is_falling,
                is_prediction,
                squashing,
                pool_tag,
                render_hidden,
            ) = sample
            if observed_native_component != native_component:
                raise LayoutValidationError(
                    "native_card_ui: Dot component roundtrip mismatch"
                )
            if observed_board != board:
                raise LayoutValidationError("native_card_ui: foreign Dot Board owner")
            if not 0 <= column < 8 or not 0 <= row < 8:
                raise LayoutValidationError(
                    "native_card_ui: Dot coordinates are outside the 8x8 board"
                )
            if multiplier not in (1, 2, 3, 4):
                raise LayoutValidationError(
                    "native_card_ui: Dot multiplier is outside the supported domain"
                )
            if is_falling or is_prediction or squashing or render_hidden:
                raise NativeGeometryBusyError(
                    "native_card_ui: Dot board is still moving/rendering"
                )
            tag = read_il2cpp_string(self.memory, pool_tag, max_length=64)
            if not tag or any(ord(character) < 0x20 for character in tag):
                raise LayoutValidationError("native_card_ui: Dot.PoolTag is invalid")
            cells.append(
                BoardCellSnapshot(dot, column, row, pool_tag, tag, multiplier)
            )
            records.append(
                (
                    game_object,
                    native_game_object,
                    components,
                    native_component,
                    dot,
                    sample,
                )
            )

        coordinates = {(cell.row, cell.col) for cell in cells}
        dot_addresses = tuple(cell.address for cell in cells)
        if len(coordinates) != 64 or len(set(dot_addresses)) != 64:
            raise LayoutValidationError(
                "native_card_ui: Dot coordinates/components are not unique"
            )

        for (
            game_object,
            native_game_object,
            components,
            native_component,
            dot,
            sample,
        ) in records:
            if (
                self._pointer(game_object + 0x10) != native_game_object
                or self._managed(native_game_object) != game_object
                or not self._active(native_game_object)
                or self._components(native_game_object) != components
                or self._managed(native_component) != dot
                or self._dot_sample(dot) != sample
            ):
                raise NativeGeometryBusyError(
                    "native_card_ui: Dot board changed during ownership walk"
                )
        return NativeDotBoard(
            board,
            game_objects,
            dot_addresses,
            tuple(sorted(cells, key=lambda cell: (cell.row, cell.col))),
        )

    def _node(self, transform: int):
        if transform in self._nodes:
            return self._nodes[transform]
        managed = self._managed(transform)
        if self._class_identity(managed) != ("RectTransform", "UnityEngine"):
            raise LayoutValidationError("native_card_ui: non-RectTransform geometry")
        owner = self._pointer(transform + 0x28)
        if self._components(owner)[0] != transform or not self._active(owner):
            raise LayoutValidationError("native_card_ui: inactive/foreign transform")
        raw_rect = self._remember(transform + 0xC0, 16)
        rect = struct.unpack("<4f", raw_rect)
        # Getter refreshes dirty layout; external readers cannot call it.
        if self._remember(transform + 0xF9, 1) != b"\0":
            raise NativeGeometryBusyError("native_card_ui: dirty rect")
        access = self._pointer(transform + 0x40)
        access_raw = self._remember(access, 12)
        data, index = struct.unpack("<Qi", access_raw)
        if not 0 <= index < 1_000_000:
            raise LayoutValidationError("native_card_ui: invalid transform index")
        # Native getter checks the whole opaque job field against zero. It is
        # not a pointer to dereference, and busy geometry is never published.
        if self._read(data, 8) != bytes(8):
            raise NativeGeometryBusyError("native_card_ui: transform job pending")
        array = self._pointer(data + 0x20)
        raw_trs = self._remember(array + index * 48, 48)
        self._remember(data, 8)  # pending-job fence stays clear for whole walk
        self._remember(data + 0x20, 8)
        self._remember(transform + 0x40, 8)
        self._remember(transform + 0x70, 8)
        trs = struct.unpack("<12f", raw_trs)
        if not all(math.isfinite(x) for x in rect + trs) or min(rect[2:]) <= 0:
            raise LayoutValidationError("native_card_ui: invalid rect/TRS")
        if any(abs(trs[i]) > 0.0001 for i in (4, 5, 6)) or abs(abs(trs[7]) - 1) > 0.0001:
            raise LayoutValidationError("native_card_ui: rotated UI unsupported")
        if any(not 0 < trs[i] <= 100 for i in (8, 9, 10)):
            raise LayoutValidationError("native_card_ui: invalid UI scale")
        parent = self._pointer(transform + 0x70, nullable=True)
        if parent:
            count = struct.unpack("<i", self._read(parent + 0x60, 4))[0]
            if not 1 <= count <= 256:
                raise LayoutValidationError("native_card_ui: child count invalid")
            children = self._read(self._pointer(parent + 0x50), count * 8)
            if struct.unpack(f"<{count}Q", children).count(transform) != 1:
                raise LayoutValidationError("native_card_ui: parent/child roundtrip mismatch")
        # Do not publish a mixture from an in-flight layout/job update.
        if (self._read(transform + 0xC0, 16) != raw_rect
                or self._read(access, 12) != access_raw
                or self._read(array + index * 48, 48) != raw_trs
                or self._read(data, 8) != bytes(8)):
            raise NativeGeometryBusyError("native_card_ui: geometry changed during read")
        result = (rect, trs, parent, owner)
        self._nodes[transform] = result
        return result

    def _viewport_rect(self, transform: int):
        nodes = []
        visited = set()
        current = transform
        root_canvas = None
        for _ in range(16):
            if current in visited:
                raise LayoutValidationError("native_card_ui: transform cycle")
            visited.add(current)
            cached = self._canvas_paths.get(current)
            if cached is not None:
                path, root_canvas = cached
                if len(nodes) + len(path) > 16 or any(item[0] in visited - {current} for item in path):
                    raise LayoutValidationError("native_card_ui: invalid cached Canvas path")
                nodes.extend(path)
                break
            node = self._node(current)
            nodes.append((current, node))
            # A screen-space root Canvas may itself have a non-UI scene
            # Transform parent. Canvas.get_renderMode follows +308 to the
            # root Canvas, not Transform.parent until NULL (UP+B631F0).
            # Stop in that Canvas's LOCAL space, before its camera/world TRS.
            canvases = []
            for component in self._components(node[3]):
                managed = self._managed(component, optional=True)
                if managed and self._class_identity(managed) == ("Canvas", "UnityEngine"):
                    canvases.append(component)
            if len(canvases) > 1:
                raise LayoutValidationError("native_card_ui: Canvas not unique")
            if canvases:
                parent_canvas = self._pointer(canvases[0] + 0x308, nullable=True)
                self._remember(canvases[0] + 0x308, 8)
                if not parent_canvas:
                    root_canvas = canvases[0]
                    break
            current = node[2]
            if not current:
                break
        else:
            raise LayoutValidationError("native_card_ui: hierarchy exceeds bound")
        root, (root_rect, _, _, root_go) = nodes[-1]
        if root_canvas is None:
            raise LayoutValidationError("native_card_ui: root Canvas not found")
        # All cards share their parent Canvas chain. Reuse that chain only
        # INSIDE this one read_hand call. Its parent/TRS/rect/Canvas fences
        # remain reread at the end, so an in-flight change rejects the hand.
        for index, (node_transform, _) in enumerate(nodes):
            self._canvas_paths[node_transform] = (tuple(nodes[index:]), root_canvas)
        mode = struct.unpack("<i", self._remember(root_canvas + 0x38, 4))[0]
        if mode not in (0, 1):
            raise LayoutValidationError("native_card_ui: unsupported Canvas mode/root")
        x, y, w, h = nodes[0][1][0]
        for _, (_, trs, _, _) in nodes[:-1]:
            if abs(trs[2]) > 0.0001:
                raise LayoutValidationError("native_card_ui: out-of-plane UI unsupported")
            x, y = x * trs[8] + trs[0], y * trs[9] + trs[1]
            w, h = w * trs[8], h * trs[9]
        rx, ry, rw, rh = root_rect
        result = ((x - rx) / rw, 1 - (y + h - ry) / rh,
                  (x + w - rx) / rw, 1 - (y - ry) / rh)
        if not all(0 <= v <= 1 for v in result) or not (result[0] < result[2] and result[1] < result[3]):
            raise LayoutValidationError("native_card_ui: card outside root Canvas")
        return result, root, rw / rh

    def read_hand(self, board: int, card_ui_class: int) -> NativeCardHand:
        self._nodes.clear()  # geometry must never survive into another poll
        self._canvas_paths.clear()
        self._geometry_chunks.clear()
        objects = read_cards_in_hand_anchors(self.memory, board)
        if not 1 <= len(objects) <= 16 or len(set(objects)) != len(objects):
            raise LayoutValidationError("native_card_ui: invalid hand")
        container_wrapper = self._pointer(board + BOARD_CARD_CONTAINER_OFFSET)
        container = self._pointer(container_wrapper + 0x10)
        if self._managed(container) != container_wrapper:
            raise LayoutValidationError("native_card_ui: container roundtrip mismatch")
        entries = []
        for game_object in objects:
            native = self._pointer(game_object + 0x10)
            if self._managed(native) != game_object:
                raise LayoutValidationError("native_card_ui: GameObject roundtrip mismatch")
            components = self._components(native)
            transform = components[0]
            if self._pointer(transform + 0x70) != container:
                raise LayoutValidationError("native_card_ui: card outside Board.cardContainer")
            active = self._active(native)
            addresses = []
            for component in components:
                managed = self._managed(component, optional=True)
                if managed and self._pointer(managed) == card_ui_class:
                    addresses.append(managed)
            rect, root, aspect = self._viewport_rect(transform) if active else (None, None, None)
            entries.append(NativeCardEntry(game_object, native, transform, tuple(addresses), active, rect, root, aspect))
        hand = NativeCardHand(board, container, tuple(entries))
        visible = hand.visible
        if not visible or len({entry.root_transform for entry in visible}) != 1:
            raise LayoutValidationError("native_card_ui: card Canvas mismatch/empty strip")
        # Only a non-overlapping horizontal card strip has a slot interpretation.
        for left, right in zip(visible, visible[1:]):
            if (left.viewport_rect[2] > right.viewport_rect[0] + 0.002
                    or abs(left.viewport_rect[1] - right.viewport_rect[1]) > 0.01):
                raise LayoutValidationError("native_card_ui: ambiguous/animating card strip")
        if read_cards_in_hand_anchors(self.memory, board) != objects:
            raise LayoutValidationError("native_card_ui: hand changed during read")
        for entry in entries:
            if (self._active(entry.native_game_object) != entry.active
                    or self._pointer(entry.game_object + 0x10) != entry.native_game_object
                    or self._managed(entry.native_game_object) != entry.game_object):
                raise LayoutValidationError("native_card_ui: owner changed during read")
        if self._pointer(board + BOARD_CARD_CONTAINER_OFFSET) != container_wrapper:
            raise LayoutValidationError("native_card_ui: container changed during read")
        for (address, size), value in self._geometry_chunks.items():
            if self._read(address, size) != value:
                raise NativeGeometryBusyError("native_card_ui: geometry changed during walk")
        return hand

    def read_game_object_active(self, game_object: int) -> bool:
        """Validate one managed ``GameObject`` and read its active cache."""

        if self._class_identity(game_object) != ("GameObject", "UnityEngine"):
            raise LayoutValidationError("native_card_ui: object is not a GameObject")
        native = self._pointer(game_object + 0x10)
        if self._managed(native) != game_object:
            raise LayoutValidationError(
                "native_card_ui: GameObject managed/native roundtrip mismatch"
            )
        return self._active(native)

    def read_button_geometry(
        self,
        button: int,
        *,
        max_translation_jitter: float = 0.0,
    ) -> NativeButtonGeometry:
        """Resolve one managed Unity UI Button to its live clickable rectangle.

        The walk uses the same native signatures, ownership roundtrips, active
        cache, RectTransform hierarchy and geometry fences as card controls.
        It is intentionally generic so lobby navigation can click an exact
        manager-owned Button without a resolution-specific coordinate.
        """

        self._nodes.clear()
        self._canvas_paths.clear()
        self._geometry_chunks.clear()
        if self._class_identity(button) != ("Button", "UnityEngine.UI"):
            raise LayoutValidationError("native_card_ui: object is not a Button")
        native_button = self._pointer(button + 0x10)
        if self._managed(native_button) != button:
            raise LayoutValidationError(
                "native_card_ui: Button managed/native roundtrip mismatch"
            )
        native_game_object = self._pointer(native_button + 0x28)
        game_object = self._managed(native_game_object)
        if self._class_identity(game_object) != ("GameObject", "UnityEngine"):
            raise LayoutValidationError("native_card_ui: Button owner is not a GameObject")
        components = self._components(native_game_object)
        if native_button not in components:
            raise LayoutValidationError("native_card_ui: Button owner mismatch")
        transform = components[0]
        active = self._active(native_game_object)
        rect, root, aspect = (
            self._viewport_rect(transform) if active else (None, None, None)
        )
        if (
            self._pointer(button + 0x10) != native_button
            or self._managed(native_button) != button
            or self._pointer(native_button + 0x28) != native_game_object
            or self._managed(native_game_object) != game_object
            or self._components(native_game_object) != components
            or self._active(native_game_object) != active
        ):
            raise NativeGeometryBusyError(
                "native_card_ui: Button ownership changed during read"
            )
        for (address, size), value in self._geometry_chunks.items():
            current = self._read(address, size)
            if current == value:
                continue
            # Some hub buttons have a permanent sub-pixel idle bob.  Their
            # native 48-byte TRS translation can therefore advance between
            # the ownership walk and its final fence even though the owner,
            # rotation, scale and clickable rectangle remain valid.  Callers
            # must opt in with a small bound; card/gameplay geometry stays
            # byte-for-byte strict by default.
            bounded_translation = False
            if max_translation_jitter > 0.0 and size == 48:
                before_trs = struct.unpack("<12f", value)
                after_trs = struct.unpack("<12f", current)
                bounded_translation = bool(
                    all(
                        abs(before_trs[index] - after_trs[index])
                        <= max_translation_jitter
                        for index in (0, 1, 2)
                    )
                    and all(
                        before_trs[index] == after_trs[index]
                        for index in range(3, 12)
                    )
                )
            if not bounded_translation:
                raise NativeGeometryBusyError(
                    "native_card_ui: Button geometry changed during read"
                )
        return NativeButtonGeometry(
            button,
            native_button,
            game_object,
            native_game_object,
            transform,
            active,
            rect,
            root,
            aspect,
        )

    def validate_button_owner(self, card_ui: int, button: int, entry: NativeCardEntry) -> None:
        for managed in (card_ui, button):
            native = self._pointer(managed + 0x10)
            if (self._managed(native) != managed
                    or self._pointer(native + 0x28) != entry.native_game_object
                    or native not in self._components(entry.native_game_object)):
                raise LayoutValidationError("native_card_ui: CardUI/Button ownership mismatch")
        if not self._active(entry.native_game_object):
            raise LayoutValidationError("native_card_ui: card inactive")
