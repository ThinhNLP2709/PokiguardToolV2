"""Read-only ownership proof for b12's Poki.Health.PlayReminder.

IsOpen reads Canvas.enabled, NOT GameObject.activeSelf. Hide only disables
that Canvas. No engine method is invoked here. See the native evidence in
docs/play_reminder_20261022.md.
"""

from __future__ import annotations

from dataclasses import dataclass
import math
import struct

from .boss_lobby_runtime import (
    SELECTABLE_GROUPS_ALLOW_INTERACTION_OFFSET,
    SELECTABLE_INTERACTABLE_OFFSET,
    _static_instance,
)
from .il2cpp_external import ExternalReadError
from .il2cpp_layout import LayoutValidationError
from .native_card_ui import NativeButtonGeometry, NativeCardUiReader
from .unity_ui_layout import transform_for_capture


PLAY_REMINDER_TYPE_INFO_RVA = 0x3DD5B50
CANVAS_OFFSET = 0x30
BOARD_OFFSET = 0x48
REMINDER_COUNT_OFFSET = 0x24
# Behaviour.get_enabled_Injected's native thunk: mov rax,[rcx]; jmp [rax+C8].
_ENABLED_VIRTUAL_SLOT = 0xC8
_CANVAS_ENABLED_GETTER_RVA = 0xCD630
_CANVAS_ENABLED_GETTER_CODE = bytes.fromhex("807930000f95c0c3")


@dataclass(frozen=True)
class PlayReminderControl:
    open: bool | None
    clean: bool
    instance: int | None = None
    generation: int | None = None
    canvas: int | None = None
    board: int | None = None
    geometry: NativeButtonGeometry | None = None
    reasons: tuple[str, ...] = ()

    @property
    def identity(self) -> str:
        return f"{self.instance}:{self.generation}"


@dataclass(frozen=True)
class PlayReminderLocation:
    found: bool
    normalized_point: tuple[float, float] | None
    normalized_rect: tuple[float, float, float, float] | None
    reason: str


def _canvas_enabled(reader: NativeCardUiReader, canvas: int) -> bool:
    """Follow and verify the observed Canvas virtual getter before reading +30.

    Read-only observation of LoginScreen._backCanvas and disk disassembly agree:
    UnityPlayer+CD630 = cmp byte [rcx+30],0; setne al; ret.
    """
    if reader._class_identity(canvas) != ("Canvas", "UnityEngine"):
        raise LayoutValidationError("PlayReminder._canvas is not a Canvas")
    native = reader._pointer(canvas + 0x10)
    if reader._managed(native) != canvas:
        raise LayoutValidationError("PlayReminder Canvas roundtrip mismatch")
    thunk = reader.unity_base + 0x114430
    if reader._read(thunk, 10) != bytes.fromhex("488b0148ffa0c8000000"):
        raise LayoutValidationError("Behaviour enabled virtual thunk changed")
    vtable = reader._pointer(native)
    getter = reader._pointer(vtable + _ENABLED_VIRTUAL_SLOT)
    if (getter != reader.unity_base + _CANVAS_ENABLED_GETTER_RVA
            or reader._read(getter, len(_CANVAS_ENABLED_GETTER_CODE)) != _CANVAS_ENABLED_GETTER_CODE):
        raise LayoutValidationError("Canvas enabled virtual getter changed")
    value = reader._read(native + 0x30, 1)
    if value not in (b"\0", b"\1"):
        raise LayoutValidationError("Canvas enabled byte is invalid")
    return value == b"\1"


def read_play_reminder_control(target: object) -> PlayReminderControl:
    instance = canvas = board = generation = None
    try:
        resolver = target.resolver
        instance = _static_instance(resolver, PLAY_REMINDER_TYPE_INFO_RVA, size=0x58)
        if instance is None:
            return PlayReminderControl(False, True)
        canvas = resolver.read_pointer(instance + CANVAS_OFFSET)
        if not canvas:
            return PlayReminderControl(False, True, instance=instance)
        reader = NativeCardUiReader(target.memory, resolver.game_assembly_base)
        if not _canvas_enabled(reader, canvas):
            return PlayReminderControl(False, True, instance=instance, canvas=canvas)
        generation = struct.unpack("<i", reader._read(instance + REMINDER_COUNT_OFFSET, 4))[0]
        if not 0 <= generation <= 1_000_000:
            raise LayoutValidationError("PlayReminder count is invalid")
        board = reader._pointer(instance + BOARD_OFFSET)
        if reader._class_identity(board) != ("RectTransform", "UnityEngine"):
            raise LayoutValidationError("PlayReminder._board is not a RectTransform")
        native_board = reader._pointer(board + 0x10)
        if reader._managed(native_board) != board:
            raise LayoutValidationError("PlayReminder board roundtrip mismatch")
        owner = reader._pointer(native_board + 0x28)
        buttons = reader.read_game_object_descendant_buttons(reader._managed(owner), max_nodes=128)
        if len(buttons) != 1:
            raise LayoutValidationError("PlayReminder board does not own exactly one Button")
        button = buttons[0]
        for offset in (SELECTABLE_INTERACTABLE_OFFSET, SELECTABLE_GROUPS_ALLOW_INTERACTION_OFFSET):
            if reader._read(button + offset, 1) != b"\1":
                raise LayoutValidationError("PlayReminder Button is not interactable")
        geometry = reader.read_button_geometry(button)
        canvas_native = reader._pointer(canvas + 0x10)
        canvas_owner = reader._pointer(canvas_native + 0x28)
        cursor = geometry.transform
        for _ in range(32):
            if reader._pointer(cursor + 0x28) == canvas_owner:
                break
            cursor = reader._pointer(cursor + 0x70, nullable=True)
            if not cursor:
                raise LayoutValidationError("PlayReminder Button belongs to another Canvas")
        else:
            raise LayoutValidationError("PlayReminder Canvas ancestry exceeds bound")
        if not geometry.active or geometry.viewport_rect is None or geometry.root_aspect is None:
            raise LayoutValidationError("PlayReminder Button has no active geometry")
        # Reject Canvas hide/rebuild during this ownership walk.
        if (resolver.read_pointer(instance + CANVAS_OFFSET) != canvas
                or resolver.read_pointer(instance + BOARD_OFFSET) != board
                or struct.unpack("<i", reader._read(instance + REMINDER_COUNT_OFFSET, 4))[0] != generation
                or not _canvas_enabled(reader, canvas)):
            raise LayoutValidationError("PlayReminder changed during read")
        return PlayReminderControl(True, True, instance, generation, canvas, board, geometry)
    except (ExternalReadError, LayoutValidationError, OSError, ValueError) as exc:
        return PlayReminderControl(None, False, instance, generation, canvas, board,
                                   reasons=(str(exc),))


def same_clean_play_reminder(a: PlayReminderControl, b: PlayReminderControl) -> bool:
    if not (a.clean and b.clean and a.open is True and b.open is True):
        return False
    if (a.instance, a.generation, a.canvas, a.board) != (b.instance, b.generation, b.canvas, b.board):
        return False
    x, y = a.geometry, b.geometry
    if x is None or y is None or (x.button, x.native_button, x.root_transform) != (
        y.button, y.native_button, y.root_transform
    ) or x.viewport_rect is None or y.viewport_rect is None:
        return False
    return x.root_aspect == y.root_aspect and all(
        abs(i-j) <= 0.001 for i, j in zip(x.viewport_rect, y.viewport_rect)
    )


def locate_play_reminder_confirm(rgb: bytes, width: int, height: int,
                                 control: PlayReminderControl) -> PlayReminderLocation:
    """Sanity check the exact native Button; never search for generic green CTAs."""
    invalid = PlayReminderLocation(False, None, None, "invalid_play_reminder")
    g = control.geometry
    if (not control.clean or control.open is not True or g is None or not g.active
            or g.viewport_rect is None or g.root_aspect is None or width < 640
            or height < 350 or len(rgb) != width*height*3):
        return invalid
    t = transform_for_capture(rgb, width, height)
    l, top, r, bottom = g.viewport_rect
    if (not all(math.isfinite(x) and 0 <= x <= 1 for x in g.viewport_rect)
            or not 0.08 <= r-l <= 0.35 or not 0.04 <= bottom-top <= 0.18
            or abs(g.root_aspect-t.viewport_width/t.viewport_height) > 0.012):
        return invalid
    rect = t.viewport_rect(g.viewport_rect)
    x0, y0, x1, y1 = round(rect[0]*width), round(rect[1]*height), round(rect[2]*width), round(rect[3]*height)
    green = white = count = 0
    for y in range(max(0,y0),min(height,y1),2):
        for x in range(max(0,x0),min(width,x1),2):
            red, gr, blue = rgb[(y*width+x)*3:(y*width+x)*3+3]
            green += gr >= 110 and gr > red*1.25 and gr > blue*1.2
            white += min(red,gr,blue) >= 160 and max(red,gr,blue)-min(red,gr,blue) <= 65
            count += 1
    if count < 100 or green/count < 0.40 or white/count < 0.008:
        return PlayReminderLocation(False, None, rect, "play_reminder_button_visual_mismatch")
    return PlayReminderLocation(True, ((rect[0]+rect[2])/2,(rect[1]+rect[3])/2),
                                rect, "exact_PlayReminder_board_Button")
