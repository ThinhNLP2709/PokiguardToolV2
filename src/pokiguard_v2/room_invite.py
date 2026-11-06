"""Read-only ownership of B14's room Invite Close button; never sends invites."""
from dataclasses import dataclass
import math
from .boss_lobby_runtime import (ROOM_COOP_V2_VIEW_TYPE_INFO_RVA,
    SELECTABLE_INTERACTABLE_OFFSET, SELECTABLE_GROUPS_ALLOW_INTERACTION_OFFSET, _static_instance)
from .native_card_ui import NativeButtonGeometry, NativeCardUiReader
from .il2cpp_external import ExternalReadError
from .il2cpp_layout import LayoutValidationError
from .play_reminder import PlayReminderLocation
from .unity_ui_layout import transform_for_capture


@dataclass(frozen=True)
class RoomInviteControl:
    open: bool | None
    clean: bool
    view: int | None = None
    refs: int | None = None
    panel: int | None = None
    geometry: NativeButtonGeometry | None = None
    reasons: tuple[str, ...] = ()
    generation: int = 0

    @property
    def identity(self):
        return f"invite:{self.view}:{self.refs}:{self.panel}"


def read_room_invite_control(target):
    view = refs = panel = None
    try:
        view = _static_instance(target.resolver, ROOM_COOP_V2_VIEW_TYPE_INFO_RVA, size=0x28)
        if view is None:
            return RoomInviteControl(False, True)
        reader = NativeCardUiReader(target.memory, target.resolver.game_assembly_base)
        refs = reader._pointer(view+0x20, nullable=True)
        if refs is None:
            return RoomInviteControl(False, True, view)
        if reader._class_identity(refs) != ('RoomCoopV2Refs', ''):
            raise ValueError('RoomCoopV2View refs class mismatch')
        panel = reader._pointer(refs+0x258, nullable=True)
        if panel is None or not reader.read_game_object_active(panel):
            return RoomInviteControl(False, True, view, refs, panel)
        button = reader._pointer(refs+0x260)
        if button == reader._pointer(refs+0x38):
            raise ValueError('Invite Close aliases room Start')
        for offset in (SELECTABLE_INTERACTABLE_OFFSET, SELECTABLE_GROUPS_ALLOW_INTERACTION_OFFSET):
            if reader._read(button+offset, 1) != b'\1':
                raise ValueError('Invite Close is not interactable')
        geometry = reader.read_button_geometry(button)
        design = reader._pointer(refs+0x30)
        if reader._class_identity(design) != ('RectTransform', 'UnityEngine'):
            raise ValueError('Room designRoot class mismatch')
        native_design = reader._pointer(design+0x10)
        if reader._managed(native_design) != design:
            raise ValueError('Room designRoot roundtrip mismatch')
        cursor = geometry.transform
        if cursor == native_design:
            raise ValueError('Invite Close cannot be the room designRoot')
        for _ in range(32):
            if cursor == native_design:
                break
            cursor = reader._pointer(cursor+0x70, nullable=True)
            if cursor is None:
                raise ValueError('Invite Close belongs to another room hierarchy')
        else:
            raise ValueError('Invite Close ancestry exceeds bound')
        if not geometry.active or geometry.viewport_rect is None or geometry.root_aspect is None:
            raise ValueError('Invite Close has no active geometry')
        if (reader._pointer(view+0x20) != refs or reader._pointer(refs+0x258) != panel
                or reader._pointer(refs+0x260) != button or not reader.read_game_object_active(panel)):
            raise ValueError('Invite panel changed during ownership read')
        return RoomInviteControl(True, True, view, refs, panel, geometry)
    except (ExternalReadError, LayoutValidationError, OSError, ValueError) as exc:
        return RoomInviteControl(None, False, view, refs, panel, reasons=(str(exc),))


def same_clean_room_invite(a, b):
    if not (a.clean and b.clean and a.open is True and b.open is True
            and (a.view,a.refs,a.panel)==(b.view,b.refs,b.panel)):
        return False
    x,y=a.geometry,b.geometry
    return bool(x is not None and y is not None and x.viewport_rect is not None and y.viewport_rect is not None
        and (x.button,x.native_button,x.root_transform,x.root_aspect)==(y.button,y.native_button,y.root_transform,y.root_aspect)
        and all(abs(i-j)<=.001 for i,j in zip(x.viewport_rect,y.viewport_rect)))


def locate_room_invite_close(rgb, width, height, control):
    invalid=PlayReminderLocation(False,None,None,'invalid_owned_room_invite')
    g=control.geometry
    if not control.clean or control.open is not True or g is None or not g.active or g.viewport_rect is None or g.root_aspect is None:
        return invalid
    if width<640 or height<350 or len(rgb)!=width*height*3:
        return invalid
    t=transform_for_capture(rgb,width,height);l,top,r,bottom=g.viewport_rect
    if (not all(math.isfinite(v) and 0<=v<=1 for v in g.viewport_rect)
            or not .02<=r-l<=.15 or not .03<=bottom-top<=.23
            or abs(g.root_aspect-t.viewport_width/t.viewport_height)>.012):
        return invalid
    rect=t.viewport_rect(g.viewport_rect)
    x0,y0,x1,y1=(round(v*(width if i%2==0 else height)) for i,v in enumerate(rect))
    blue=white=count=0
    for y in range(max(0,y0),min(height,y1),2):
        for x in range(max(0,x0),min(width,x1),2):
            red,green,b=rgb[(y*width+x)*3:(y*width+x)*3+3]
            blue+=b>=100 and green>=60 and b>red*1.15
            white+=min(red,green,b)>=140 and max(red,green,b)-min(red,green,b)<=90
            count+=1
    if count<80 or blue/count<.20 or white/count<.025:
        return PlayReminderLocation(False,None,rect,'owned_invite_close_visual_mismatch')
    return PlayReminderLocation(True,((rect[0]+rect[2])/2,(rect[1]+rect[3])/2),rect,
                               'exact_RoomCoopV2Refs_btnInviteClose')
