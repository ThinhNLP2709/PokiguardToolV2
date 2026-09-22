"""Read-only IL2CPP boss-lobby graph for the verified Pokiguard build.

Every type-info RVA and field offset below is backed by the local Cpp2IL
DiffableCs/ISIL output.  No method is invoked and target memory is never
written.
"""

from __future__ import annotations

from dataclasses import dataclass
import struct

from .boss_entry import (
    BossCandidate,
    BossLobbyState,
    BossTargetIdentity,
    TargetSelectionState,
)
from .combat_lifecycle import (
    CombatLifecycleObservation,
    CombatLifecycleState,
    MatchHostState,
)
from .combat_cards import ATTACK_ELEMENT_TYPES, CardDataState, read_card_data
from .il2cpp_external import (
    CHAT_SERVICE_SINGLETON,
    IL2CPP_CLASS_STATIC_FIELDS_OFFSET,
    ExternalReadError,
    checked_address,
    is_canonical_user_pointer,
)
from .il2cpp_layout import LayoutValidationError, read_il2cpp_string, read_reference_array
from .native_card_ui import NativeCardUiReader


# Type-info global slots proven by native ``typeof`` use in this build.
MANAGER_QUANG_TRUONG_TYPE_INFO_RVA = 0x334C3A8
MANAGER_ROOM_TYPE_INFO_RVA = 0x334A068
WS_ROOM_SERVICE_TYPE_INFO_RVA = 0x3366060

# ManagerQuangTruong (Assembly-CSharp).
MQT_PANEL_BOSS_OFFSET = 0x108
MQT_PANEL_PVP_OFFSET = 0x110
MQT_PANEL_GIFT_BOX_OFFSET = 0x170
MQT_PANEL_GIFT_RESULT_OFFSET = 0x178
MQT_PANEL_CHINH_PHUC_OFFSET = 0x2C0
MQT_LOADING_PANEL_OFFSET = 0x2D0
MQT_LOADING_ROOM_OFFSET = 0x2D8
MQT_HUB_ONLY_BLOCKERS_OFFSET = 0x388
MQT_PANEL_MASTER_LOBBY_OFFSET = 0x390
MQT_MANAGER_BOSS_OFFSET = 0x3E0

# ManagerChinhPhuc (Assembly-CSharp). The component is resolved from the
# already-owned panelChinhPhuc GameObject, so no heap scan is required.
MANAGER_CHINH_PHUC_PANELS_OFFSET = 0x28
MANAGER_CHINH_PHUC_PANEL_MAIN_OFFSET = 0x38

# ManagerBoss (Assembly-CSharp).
MANAGER_BOSS_PANEL_BOSS_OFFSET = 0x28
MANAGER_BOSS_PANEL_WORLD_OFFSET = 0x30

# UIPanelManager (Assembly-CSharp).  The managed open-order count is the
# read-only counterpart of the final AnyPanelOpen check in IsHubViewActive.
UI_PANEL_MANAGER_TYPE_INFO_RVA = 0x334C508
UI_PANEL_MANAGER_OPEN_ORDER_OFFSET = 0x30

# ManagerRoom (Assembly-CSharp).
MANAGER_ROOM_ROOM_PANEL_OFFSET = 0x20
MANAGER_ROOM_BUTTON_START_OFFSET = 0x28
MANAGER_ROOM_LOADING_OFFSET = 0x30
MANAGER_ROOM_ROOM_DATA_OFFSET = 0x100
MANAGER_ROOM_SELECTED_CARDS_OFFSET = 0x108
MANAGER_ROOM_IS_OPENING_FLOW_OFFSET = 0x130

# RoomDTO.
ROOM_ID_OFFSET = 0x10
ROOM_NAME_OFFSET = 0x28
ROOM_LOCAL_PET_ID_OFFSET = 0x34
ROOM_ENEMY_PET_ID_OFFSET = 0x38
ROOM_ENEMY_PET_LEVEL_OFFSET = 0x3C
ROOM_ENEMY_PET_NAME_OFFSET = 0x40
ROOM_CARDS_OFFSET = 0x58

# WsRoomService.
WS_CURRENT_ROOM_ID_OFFSET = 0x10
WS_CURRENT_ROOM_TYPE_OFFSET = 0x18
WS_OWNER_USERNAME_OFFSET = 0x20
WS_PROPERTIES_OFFSET = 0x38

# ManagerBoss / BossItem / WorldBossDTO.
MANAGER_BOSS_ITEMS_OFFSET = 0x70
BOSS_ITEM_BUTTON_OFFSET = 0x48
BOSS_ITEM_DATA_OFFSET = 0x78
WORLD_BOSS_ID_OFFSET = 0x10
WORLD_BOSS_PET_ID_OFFSET = 0x14
WORLD_BOSS_NAME_OFFSET = 0x18
WORLD_BOSS_STATUS_OFFSET = 0x60
WORLD_BOSS_REMAINING_ATTEMPTS_OFFSET = 0x68

# UnityEngine.Object / UnityEngine.UI.Selectable.
UNITY_OBJECT_CACHED_PTR_OFFSET = 0x10
SELECTABLE_INTERACTABLE_OFFSET = 0xD8
SELECTABLE_GROUPS_ALLOW_INTERACTION_OFFSET = 0xE8

LIST_ITEMS_OFFSET = 0x10
LIST_SIZE_OFFSET = 0x18
LIST_VERSION_OFFSET = 0x1C


@dataclass(frozen=True)
class LobbyCardLoadoutSnapshot:
    """Read-only pre-entry card loadout from both lobby-owned sources.

    These are persistent ``CardData`` records, not live combat ``CardUI``
    instances.  They prove which cards the room intends to carry into the
    next match, but never prove that a combat button exists or is clickable.
    """

    manager_list: int | None
    room_list: int | None
    manager_cards: tuple[CardDataState, ...]
    room_cards: tuple[CardDataState, ...]
    cards: tuple[CardDataState, ...]
    sources_agree: bool | None
    reasons: tuple[str, ...]

    @property
    def card_count(self) -> int:
        return len(self.cards)

    @property
    def attack_card_count(self) -> int:
        return sum(
            card.element_type.upper() in ATTACK_ELEMENT_TYPES for card in self.cards
        )

    @property
    def manager_attack_card_count(self) -> int:
        return sum(
            card.element_type.upper() in ATTACK_ELEMENT_TYPES
            for card in self.manager_cards
        )

    @property
    def room_attack_card_count(self) -> int:
        return sum(
            card.element_type.upper() in ATTACK_ELEMENT_TYPES
            for card in self.room_cards
        )

    @property
    def identity(self) -> tuple[tuple[int, int, str], ...]:
        return tuple(
            sorted(
                (card.data_id, card.card_id, card.element_type.upper())
                for card in self.cards
            )
        )


@dataclass(frozen=True)
class ChinhPhucRoomSnapshot:
    manager_room: int | None
    manager_room_native: int | None
    room_panel: int | None
    button_start: int | None
    button_native: int | None
    button_interactable: bool | None
    button_groups_allow: bool | None
    loading: int | None
    is_opening_flow: bool | None
    room_data: int | None
    card_loadout: LobbyCardLoadoutSnapshot
    room_dto_id: int | None
    room_name: str | None
    local_pet_id: int | None
    enemy_pet_id: int | None
    enemy_pet_level: int | None
    enemy_pet_name: str | None
    ws_room_service: int | None
    current_room_id: str | None
    current_room_type: str | None
    owner_username: str | None
    local_username: str | None
    is_host: bool | None
    properties: int | None
    clean: bool
    reasons: tuple[str, ...]


@dataclass(frozen=True)
class WorldBossListSnapshot:
    manager_quang_truong: int | None
    panel_boss: int | None
    panel_chinh_phuc: int | None
    manager_boss: int | None
    manager_boss_native: int | None
    item_count: int
    clean_for_discovery: bool
    reasons: tuple[str, ...]
    panel_boss_active: bool | None = None
    panel_world_boss: int | None = None
    panel_world_boss_active: bool | None = None
    panel_chinh_phuc_active: bool | None = None
    panel_master_lobby: int | None = None
    panel_master_lobby_active: bool | None = None
    dynamic_panel_count: int | None = None
    clean_for_game_lobby: bool = False
    clean_for_chinh_phuc_map: bool = False
    manager_chinh_phuc: int | None = None
    chinh_phuc_panel_main_active: bool | None = None
    chinh_phuc_panel_count: int | None = None
    chinh_phuc_active_panel_index: int | None = None


@dataclass(frozen=True)
class BossLobbyRuntimeSnapshot:
    state: BossLobbyState
    branch: str | None
    combat_lifecycle: CombatLifecycleObservation
    chinh_phuc: ChinhPhucRoomSnapshot
    world_boss: WorldBossListSnapshot
    candidates: tuple[BossCandidate, ...]
    reasons: tuple[str, ...]


def _read_pointer(resolver: object, base: int, offset: int) -> int | None:
    value = resolver.read_pointer(checked_address(base, offset))
    return value or None


def _read_string(resolver: object, base: int, offset: int) -> str | None:
    pointer = _read_pointer(resolver, base, offset)
    if pointer is None:
        return None
    value = read_il2cpp_string(resolver.memory, pointer, max_length=256)
    return value or None


def _static_instance(resolver: object, rva: int, *, size: int) -> int | None:
    klass = resolver.resolve_type_info_class(rva)
    if klass is None:
        return None
    fields = resolver.read_pointer(klass + IL2CPP_CLASS_STATIC_FIELDS_OFFSET)
    if not fields or not is_canonical_user_pointer(fields):
        return None
    if not resolver.memory.is_readable(fields, 8):
        raise ExternalReadError("static fields are unreadable")
    instance = resolver.read_pointer(fields)
    if not instance:
        return None
    if not is_canonical_user_pointer(instance) or not resolver.memory.is_readable(
        instance, size
    ):
        raise ExternalReadError("static instance range is invalid")
    if resolver.read_pointer(instance) != klass:
        raise ExternalReadError("static instance class does not match type-info")
    return instance


def _native_pointer(resolver: object, instance: int | None) -> int | None:
    if instance is None:
        return None
    value = _read_pointer(resolver, instance, UNITY_OBJECT_CACHED_PTR_OFFSET)
    if value is None or not is_canonical_user_pointer(value):
        return None
    return value if resolver.memory.is_readable(value, 1) else None


def _read_managed_list(
    resolver: object,
    address: int,
    *,
    max_items: int = 64,
) -> tuple[int, ...]:
    if not is_canonical_user_pointer(address) or not resolver.memory.is_readable(
        address, 0x20
    ):
        raise LayoutValidationError("managed list range is invalid")
    before = resolver.memory.read(address, 0x20)
    items = struct.unpack_from("<Q", before, LIST_ITEMS_OFFSET)[0]
    size = struct.unpack_from("<i", before, LIST_SIZE_OFFSET)[0]
    version = struct.unpack_from("<i", before, LIST_VERSION_OFFSET)[0]
    if size < 0 or size > max_items:
        raise LayoutValidationError(f"managed list size {size} is outside 0..{max_items}")
    if size == 0:
        return ()
    if not items:
        raise LayoutValidationError("managed list items array is null")
    values = read_reference_array(resolver.memory, items, max_length=max_items)
    if size > len(values):
        raise LayoutValidationError("managed list size exceeds backing array")
    after = resolver.memory.read(address, 0x20)
    if (
        struct.unpack_from("<Q", after, LIST_ITEMS_OFFSET)[0] != items
        or struct.unpack_from("<i", after, LIST_SIZE_OFFSET)[0] != size
        or struct.unpack_from("<i", after, LIST_VERSION_OFFSET)[0] != version
    ):
        raise LayoutValidationError("managed list changed during read")
    return tuple(values[:size])


def _read_card_list(
    resolver: object,
    address: int | None,
    *,
    label: str,
) -> tuple[tuple[CardDataState, ...], str | None]:
    if address is None:
        return (), f"{label} is null"
    try:
        pointers = _read_managed_list(resolver, address, max_items=16)
        cards = tuple(read_card_data(resolver.memory, pointer) for pointer in pointers)
    except (ExternalReadError, LayoutValidationError, OSError, ValueError) as exc:
        return (), f"{label} is invalid: {exc}"
    return cards, None


def _read_lobby_card_loadout(
    resolver: object,
    manager_room: int | None,
    room_data: int | None,
) -> LobbyCardLoadoutSnapshot:
    manager_list = room_list = None
    manager_cards: tuple[CardDataState, ...] = ()
    room_cards: tuple[CardDataState, ...] = ()
    reasons: list[str] = []

    try:
        if manager_room is not None:
            manager_list = _read_pointer(
                resolver, manager_room, MANAGER_ROOM_SELECTED_CARDS_OFFSET
            )
        if room_data is not None:
            room_list = _read_pointer(resolver, room_data, ROOM_CARDS_OFFSET)
    except (ExternalReadError, OSError, ValueError) as exc:
        reasons.append(f"card-list pointer read failed: {exc}")

    manager_cards, manager_reason = _read_card_list(
        resolver,
        manager_list,
        label="ManagerRoom.selectedCards",
    )
    room_cards, room_reason = _read_card_list(
        resolver,
        room_list,
        label="RoomDTO.cards",
    )
    if manager_reason is not None:
        reasons.append(manager_reason)
    if room_reason is not None:
        reasons.append(room_reason)

    manager_identity = tuple(
        sorted((card.data_id, card.card_id, card.element_type.upper()) for card in manager_cards)
    )
    room_identity = tuple(
        sorted((card.data_id, card.card_id, card.element_type.upper()) for card in room_cards)
    )
    sources_agree: bool | None = None
    if manager_list is not None and room_list is not None:
        sources_agree = manager_identity == room_identity
        if not sources_agree:
            reasons.append("ManagerRoom.selectedCards and RoomDTO.cards disagree")

    # ManagerRoom.selectedCards is the UI-owned selection that the next combat
    # actually materializes. Live Phase 2D.6 restart evidence proved that a
    # stale RoomDTO can retain four cards while this list is empty and the
    # combat creates zero CardUI objects. Keep RoomDTO as comparison telemetry
    # only; never promote it into a claimed pre-entry live selection.
    cards = manager_cards
    return LobbyCardLoadoutSnapshot(
        manager_list=manager_list,
        room_list=room_list,
        manager_cards=manager_cards,
        room_cards=room_cards,
        cards=cards,
        sources_agree=sources_agree,
        reasons=tuple(reasons),
    )


def read_chinh_phuc_room(resolver: object) -> tuple[ChinhPhucRoomSnapshot, tuple[BossCandidate, ...]]:
    reasons: list[str] = []
    manager_room = manager_native = None
    room_panel = button = button_native = loading = room_data = None
    button_interactable = button_groups = opening = None
    room_dto_id = local_pet_id = enemy_pet_id = enemy_level = None
    room_name = enemy_name = None
    card_loadout = _read_lobby_card_loadout(resolver, None, None)
    ws = properties = None
    room_id = room_type = owner = local_username = None
    is_host: bool | None = None

    try:
        manager_room = _static_instance(resolver, MANAGER_ROOM_TYPE_INFO_RVA, size=0x150)
        if manager_room is None:
            reasons.append("ManagerRoom.Instance unavailable")
        else:
            manager_native = _native_pointer(resolver, manager_room)
            if manager_native is None:
                reasons.append("ManagerRoom native object is not alive")
            room_panel = _read_pointer(resolver, manager_room, MANAGER_ROOM_ROOM_PANEL_OFFSET)
            button = _read_pointer(resolver, manager_room, MANAGER_ROOM_BUTTON_START_OFFSET)
            loading = _read_pointer(resolver, manager_room, MANAGER_ROOM_LOADING_OFFSET)
            room_data = _read_pointer(resolver, manager_room, MANAGER_ROOM_ROOM_DATA_OFFSET)
            opening = resolver.read_bool(manager_room + MANAGER_ROOM_IS_OPENING_FLOW_OFFSET)
            if button is None or not resolver.memory.is_readable(button, 0xE9):
                reasons.append("ManagerRoom.ButtonStart unavailable")
            else:
                button_native = _native_pointer(resolver, button)
                button_interactable = resolver.read_bool(button + SELECTABLE_INTERACTABLE_OFFSET)
                button_groups = resolver.read_bool(
                    button + SELECTABLE_GROUPS_ALLOW_INTERACTION_OFFSET
                )
                if button_native is None:
                    reasons.append("ButtonStart native object is not alive")
                if button_interactable is not True or button_groups is not True:
                    reasons.append("ButtonStart is not interactable")
            if opening is not False:
                reasons.append("ManagerRoom opening flow already pending")
            if room_data is None or not resolver.memory.is_readable(room_data, 0x58):
                reasons.append("ManagerRoom.roomData unavailable")
            else:
                room_dto_id = resolver.read_i32(room_data + ROOM_ID_OFFSET)
                room_name = _read_string(resolver, room_data, ROOM_NAME_OFFSET)
                local_pet_id = resolver.read_i32(room_data + ROOM_LOCAL_PET_ID_OFFSET)
                enemy_pet_id = resolver.read_i32(room_data + ROOM_ENEMY_PET_ID_OFFSET)
                enemy_level = resolver.read_i32(room_data + ROOM_ENEMY_PET_LEVEL_OFFSET)
                enemy_name = _read_string(resolver, room_data, ROOM_ENEMY_PET_NAME_OFFSET)
                if enemy_pet_id <= 0 or not enemy_name:
                    reasons.append("RoomDTO target identity is invalid")
    except (ExternalReadError, LayoutValidationError, OSError, ValueError) as exc:
        reasons.append(f"ManagerRoom read error: {exc}")

    card_loadout = _read_lobby_card_loadout(resolver, manager_room, room_data)

    try:
        ws = _static_instance(resolver, WS_ROOM_SERVICE_TYPE_INFO_RVA, size=0xD0)
        if ws is None:
            reasons.append("WsRoomService.Instance unavailable")
        else:
            room_id = _read_string(resolver, ws, WS_CURRENT_ROOM_ID_OFFSET)
            room_type = _read_string(resolver, ws, WS_CURRENT_ROOM_TYPE_OFFSET)
            owner = _read_string(resolver, ws, WS_OWNER_USERNAME_OFFSET)
            properties = _read_pointer(resolver, ws, WS_PROPERTIES_OFFSET)
            chat = resolver.resolve_singleton(CHAT_SERVICE_SINGLETON)
            if chat.resolved and chat.instance is not None:
                local_username = _read_string(resolver, chat.instance, 0x30)
            if room_id is None:
                reasons.append("WsRoomService is not in a room")
            if room_type != "ChinhPhuc":
                reasons.append(f"room type is {room_type!r}, expected 'ChinhPhuc'")
            if owner and local_username:
                is_host = owner.casefold() == local_username.casefold()
            else:
                is_host = False
            if is_host is not True:
                reasons.append("local user is not the room host")
            if properties is None:
                reasons.append("current room properties are unavailable")
    except (ExternalReadError, LayoutValidationError, OSError, ValueError) as exc:
        reasons.append(f"WsRoomService read error: {exc}")

    clean = not reasons
    snapshot = ChinhPhucRoomSnapshot(
        manager_room,
        manager_native,
        room_panel,
        button,
        button_native,
        button_interactable,
        button_groups,
        loading,
        opening,
        room_data,
        card_loadout,
        room_dto_id,
        room_name,
        local_pet_id,
        enemy_pet_id,
        enemy_level,
        enemy_name,
        ws,
        room_id,
        room_type,
        owner,
        local_username,
        is_host,
        properties,
        clean,
        tuple(reasons),
    )
    candidates: tuple[BossCandidate, ...] = ()
    if enemy_pet_id is not None and enemy_pet_id > 0 and enemy_name:
        candidates = (
            BossCandidate(
                0,
                BossTargetIdentity(
                    str(enemy_pet_id),
                    enemy_name,
                    room_id=room_id,
                    pet_id=enemy_pet_id,
                    source="ManagerRoom.roomData",
                ),
                TargetSelectionState.SELECTED,
                clean,
                clean,
                entry_control_address=button,
                evidence=(
                    "RoomDTO.enemyPetId@+0x38",
                    "RoomDTO.nameEnemyPetId@+0x40",
                    "ManagerRoom.ButtonStart@+0x28",
                    "WsRoomService.CurrentRoomType='ChinhPhuc'",
                ),
            ),
        )
    return snapshot, candidates


def _hub_surface_flags(
    *,
    master_lobby_active: bool | None,
    panel_boss_active: bool | None,
    panel_world_boss_active: bool | None,
    panel_chinh_phuc_active: bool | None,
    other_blockers: tuple[bool, ...],
    extra_blockers: tuple[bool, ...],
    dynamic_panel_count: int | None,
) -> tuple[bool, bool, bool]:
    """Classify the three evidenced hub surfaces without guessing a target."""

    no_dynamic_panel = dynamic_panel_count == 0
    ordinary_blockers_clear = all(value is False for value in other_blockers)
    extra_blockers_clear = all(value is False for value in extra_blockers)
    world_boss_visible = bool(
        master_lobby_active is True
        and panel_boss_active is True
        and panel_world_boss_active is True
        and panel_chinh_phuc_active is False
    )
    chinh_phuc_map_visible = bool(
        master_lobby_active is True
        and panel_chinh_phuc_active is True
        and panel_boss_active is False
        and ordinary_blockers_clear
        and extra_blockers_clear
        and no_dynamic_panel
    )
    game_lobby_visible = bool(
        master_lobby_active is True
        and panel_boss_active is False
        and panel_chinh_phuc_active is False
        and ordinary_blockers_clear
        and extra_blockers_clear
        and no_dynamic_panel
    )
    return world_boss_visible, chinh_phuc_map_visible, game_lobby_visible


def read_world_boss_list(resolver: object) -> tuple[WorldBossListSnapshot, tuple[BossCandidate, ...]]:
    reasons: list[str] = []
    manager_qt = panel_boss = panel_chinh = manager_boss = manager_native = None
    panel_world = panel_master = None
    panel_boss_active = panel_world_active = panel_chinh_active = None
    panel_master_active = None
    manager_chinh = None
    chinh_panel_main_active = None
    chinh_panel_count: int | None = None
    chinh_active_panel_index: int | None = None
    dynamic_panel_count: int | None = None
    world_surface = chinh_surface = game_lobby_surface = False
    candidates: list[BossCandidate] = []
    try:
        manager_qt = _static_instance(
            resolver, MANAGER_QUANG_TRUONG_TYPE_INFO_RVA, size=0x410
        )
        if manager_qt is None:
            reasons.append("ManagerQuangTruong.Instance unavailable")
        else:
            reader = NativeCardUiReader(
                resolver.memory,
                resolver.game_assembly_base,
            )
            panel_boss = _read_pointer(resolver, manager_qt, MQT_PANEL_BOSS_OFFSET)
            panel_chinh = _read_pointer(
                resolver, manager_qt, MQT_PANEL_CHINH_PHUC_OFFSET
            )
            panel_master = _read_pointer(
                resolver, manager_qt, MQT_PANEL_MASTER_LOBBY_OFFSET
            )
            if panel_boss is None or panel_chinh is None or panel_master is None:
                reasons.append("ManagerQuangTruong hub panels are incomplete")
            panel_boss_active = (
                reader.read_game_object_active(panel_boss)
                if panel_boss is not None
                else None
            )
            panel_chinh_active = (
                reader.read_game_object_active(panel_chinh)
                if panel_chinh is not None
                else None
            )
            panel_master_active = (
                reader.read_game_object_active(panel_master)
                if panel_master is not None
                else None
            )

            if panel_chinh is not None and panel_chinh_active is True:
                try:
                    manager_chinh = reader.read_game_object_component(
                        panel_chinh,
                        "ManagerChinhPhuc",
                    )
                    panel_main = _read_pointer(
                        resolver,
                        manager_chinh,
                        MANAGER_CHINH_PHUC_PANEL_MAIN_OFFSET,
                    )
                    panels_address = _read_pointer(
                        resolver,
                        manager_chinh,
                        MANAGER_CHINH_PHUC_PANELS_OFFSET,
                    )
                    if panel_main is None or panels_address is None:
                        reasons.append("ManagerChinhPhuc panel graph is incomplete")
                    else:
                        chinh_panel_main_active = reader.read_game_object_active(
                            panel_main
                        )
                        panels = read_reference_array(
                            resolver.memory,
                            panels_address,
                            max_length=64,
                        )
                        chinh_panel_count = len(panels)
                        active_panels = tuple(
                            index
                            for index, panel in enumerate(panels)
                            if panel and reader.read_game_object_active(panel)
                        )
                        if len(active_panels) == 1:
                            chinh_active_panel_index = active_panels[0]
                        elif len(active_panels) > 1:
                            reasons.append(
                                "ManagerChinhPhuc has multiple active island panels"
                            )
                except (
                    ExternalReadError,
                    LayoutValidationError,
                    OSError,
                    ValueError,
                ) as exc:
                    reasons.append(f"ManagerChinhPhuc panel read error: {exc}")

            other_blockers: list[bool] = []
            for offset in (
                MQT_PANEL_PVP_OFFSET,
                MQT_PANEL_GIFT_BOX_OFFSET,
                MQT_PANEL_GIFT_RESULT_OFFSET,
                MQT_LOADING_PANEL_OFFSET,
                MQT_LOADING_ROOM_OFFSET,
            ):
                blocker = _read_pointer(resolver, manager_qt, offset)
                other_blockers.append(
                    reader.read_game_object_active(blocker)
                    if blocker is not None
                    else False
                )

            extra_blockers: list[bool] = []
            blocker_array = _read_pointer(
                resolver,
                manager_qt,
                MQT_HUB_ONLY_BLOCKERS_OFFSET,
            )
            if blocker_array is not None:
                for blocker in read_reference_array(
                    resolver.memory,
                    blocker_array,
                    max_length=64,
                ):
                    extra_blockers.append(
                        reader.read_game_object_active(blocker)
                        if blocker
                        else False
                    )

            panel_manager = _static_instance(
                resolver,
                UI_PANEL_MANAGER_TYPE_INFO_RVA,
                size=0x50,
            )
            dynamic_panel_count = 0
            if panel_manager is not None:
                open_order = _read_pointer(
                    resolver,
                    panel_manager,
                    UI_PANEL_MANAGER_OPEN_ORDER_OFFSET,
                )
                if open_order is not None:
                    dynamic_panel_count = len(
                        _read_managed_list(resolver, open_order, max_items=64)
                    )

            manager_boss = _read_pointer(resolver, manager_qt, MQT_MANAGER_BOSS_OFFSET)
            if manager_boss is None:
                reasons.append("ManagerQuangTruong._managerBoss is null")
            elif not resolver.memory.is_readable(manager_boss, 0x80):
                reasons.append("ManagerBoss range is unreadable")
            else:
                manager_native = _native_pointer(resolver, manager_boss)
                if manager_native is None:
                    reasons.append("ManagerBoss native object is not alive")
                manager_panel_boss = _read_pointer(
                    resolver,
                    manager_boss,
                    MANAGER_BOSS_PANEL_BOSS_OFFSET,
                )
                panel_world = _read_pointer(
                    resolver,
                    manager_boss,
                    MANAGER_BOSS_PANEL_WORLD_OFFSET,
                )
                if manager_panel_boss != panel_boss:
                    reasons.append(
                        "ManagerBoss.panelBoss disagrees with ManagerQuangTruong.panelBoss"
                    )
                    panel_boss_active = None
                panel_world_active = (
                    reader.read_game_object_active(panel_world)
                    if panel_world is not None
                    else None
                )
                boss_items = _read_pointer(resolver, manager_boss, MANAGER_BOSS_ITEMS_OFFSET)
                if boss_items is None:
                    reasons.append("ManagerBoss.bossItems is null")
                else:
                    for index, item in enumerate(
                        _read_managed_list(resolver, boss_items, max_items=64)
                    ):
                        if not item or not resolver.memory.is_readable(item, 0x80):
                            continue
                        data = _read_pointer(resolver, item, BOSS_ITEM_DATA_OFFSET)
                        button = _read_pointer(resolver, item, BOSS_ITEM_BUTTON_OFFSET)
                        if data is None or not resolver.memory.is_readable(data, 0x6C):
                            continue
                        boss_id = resolver.read_i32(data + WORLD_BOSS_ID_OFFSET)
                        pet_id = resolver.read_i32(data + WORLD_BOSS_PET_ID_OFFSET)
                        name = _read_string(resolver, data, WORLD_BOSS_NAME_OFFSET)
                        status = _read_string(resolver, data, WORLD_BOSS_STATUS_OFFSET)
                        attempts = resolver.read_i32(
                            data + WORLD_BOSS_REMAINING_ATTEMPTS_OFFSET
                        )
                        button_native = _native_pointer(resolver, button)
                        interactable = groups = False
                        if button and resolver.memory.is_readable(button, 0xE9):
                            interactable = resolver.read_bool(
                                button + SELECTABLE_INTERACTABLE_OFFSET
                            )
                            groups = resolver.read_bool(
                                button + SELECTABLE_GROUPS_ALLOW_INTERACTION_OFFSET
                            )
                        active = status == "ACTIVE"
                        available = bool(
                            boss_id > 0
                            and pet_id > 0
                            and name
                            and active
                            and attempts > 0
                            and button_native
                            and interactable
                            and groups
                        )
                        candidates.append(
                            BossCandidate(
                                index,
                                BossTargetIdentity(
                                    str(boss_id),
                                    name,
                                    pet_id=pet_id,
                                    source="BossItem.bossData",
                                ),
                                TargetSelectionState.DIRECT_ENTRY_OWNER,
                                available,
                                active,
                                entry_control_address=button,
                                evidence=(
                                    "BossItem.bossData@+0x78",
                                    "WorldBossDTO.id@+0x10",
                                    "WorldBossDTO.bossName@+0x18",
                                    "BossItem.btnFight@+0x48",
                                ),
                            )
                        )
                    if not candidates:
                        reasons.append("ManagerBoss has no valid BossItem candidates")

            (
                world_surface,
                chinh_surface,
                game_lobby_surface,
            ) = _hub_surface_flags(
                master_lobby_active=panel_master_active,
                panel_boss_active=panel_boss_active,
                panel_world_boss_active=panel_world_active,
                panel_chinh_phuc_active=panel_chinh_active,
                other_blockers=tuple(other_blockers),
                extra_blockers=tuple(extra_blockers),
                dynamic_panel_count=dynamic_panel_count,
            )
    except (ExternalReadError, LayoutValidationError, OSError, ValueError) as exc:
        reasons.append(f"WorldBoss read error: {exc}")
    snapshot = WorldBossListSnapshot(
        manager_quang_truong=manager_qt,
        panel_boss=panel_boss,
        panel_chinh_phuc=panel_chinh,
        manager_boss=manager_boss,
        manager_boss_native=manager_native,
        item_count=len(candidates),
        clean_for_discovery=bool(
            manager_boss
            and manager_native
            and candidates
            and world_surface
        ),
        reasons=tuple(reasons),
        panel_boss_active=panel_boss_active,
        panel_world_boss=panel_world,
        panel_world_boss_active=panel_world_active,
        panel_chinh_phuc_active=panel_chinh_active,
        panel_master_lobby=panel_master,
        panel_master_lobby_active=panel_master_active,
        dynamic_panel_count=dynamic_panel_count,
        clean_for_game_lobby=game_lobby_surface,
        clean_for_chinh_phuc_map=chinh_surface,
        manager_chinh_phuc=manager_chinh,
        chinh_phuc_panel_main_active=chinh_panel_main_active,
        chinh_phuc_panel_count=chinh_panel_count,
        chinh_phuc_active_panel_index=chinh_active_panel_index,
    )
    return snapshot, tuple(candidates)


def read_boss_lobby_runtime(
    resolver: object,
    combat_lifecycle: CombatLifecycleObservation,
) -> BossLobbyRuntimeSnapshot:
    chinh, chinh_candidates = read_chinh_phuc_room(resolver)
    world, world_candidates = read_world_boss_list(resolver)
    lifecycle = combat_lifecycle.state
    branch: str | None = None
    reasons: list[str] = []
    if lifecycle is CombatLifecycleState.ENTERING:
        state = BossLobbyState.ENTERING_COMBAT
    elif lifecycle is CombatLifecycleState.ACTIVE:
        state = BossLobbyState.ACTIVE_COMBAT
    elif lifecycle is CombatLifecycleState.POSTMATCH:
        state = BossLobbyState.POSTMATCH
    elif lifecycle in {
        CombatLifecycleState.LOBBY,
        CombatLifecycleState.STALE_SERVER_MATCH,
    }:
        if chinh.clean:
            state = BossLobbyState.BOSS_LOBBY
            branch = "CHINH_PHUC_ROOM"
            if lifecycle is CombatLifecycleState.STALE_SERVER_MATCH:
                reasons.append("stale server match ignored; clean local ChinhPhuc room proven")
        elif world.clean_for_discovery:
            state = BossLobbyState.BOSS_LOBBY
            branch = "WORLD_BOSS_LIST"
            reasons.append(
                "visible World Boss panel and discovery graph proven; "
                "visual entry control still required"
            )
        elif getattr(world, "clean_for_chinh_phuc_map", False):
            state = BossLobbyState.LOBBY_OTHER
            if getattr(world, "chinh_phuc_active_panel_index", None) is not None:
                branch = "CHINH_PHUC_ISLAND"
                reasons.append("visible Chinh Phuc island panel proven")
            else:
                branch = "CHINH_PHUC_MAP"
                reasons.append("visible Chinh Phuc island map proven")
        elif getattr(world, "clean_for_game_lobby", False):
            state = BossLobbyState.LOBBY_OTHER
            branch = "GAME_LOBBY"
            reasons.append("general game lobby proven")
        else:
            state = BossLobbyState.LOBBY_OTHER
            reasons.extend(chinh.reasons)
            reasons.extend(world.reasons)
    elif (
        lifecycle is CombatLifecycleState.UNKNOWN
        and chinh.clean
        and _unknown_lifecycle_has_no_positive_combat(combat_lifecycle)
    ):
        # MatchHost/MatchSceneLoader/HubSuspendManager are static classes. Their
        # ``Il2CppClass.static_fields`` pointers may legitimately be null until
        # the game initializes those classes, so their absence cannot prove the
        # normal LOBBY lifecycle.  The exact ChinhPhuc room graph is a separate,
        # stronger positive proof.  Accept it only when every room invariant is
        # clean and no combat/transition signal or read error contradicts it.
        state = BossLobbyState.BOSS_LOBBY
        branch = "CHINH_PHUC_ROOM"
        reasons.append(
            "exact ChinhPhuc room proven while combat static classes are uninitialized"
        )
    else:
        state = BossLobbyState.UNKNOWN
        reasons.append(f"base lifecycle is {lifecycle.value}")
        if lifecycle is CombatLifecycleState.UNKNOWN:
            reasons.extend(chinh.reasons)
    if branch == "CHINH_PHUC_ROOM":
        candidates = chinh_candidates
    elif branch == "WORLD_BOSS_LIST":
        candidates = world_candidates
    else:
        candidates = ()
    return BossLobbyRuntimeSnapshot(
        state,
        branch,
        combat_lifecycle,
        chinh,
        world,
        candidates,
        tuple(reasons),
    )


def _unknown_lifecycle_has_no_positive_combat(
    lifecycle: CombatLifecycleObservation,
) -> bool:
    """Permit exact-room recovery only when UNKNOWN has no combat evidence."""

    signals = lifecycle.signals
    return bool(
        not signals.read_errors
        and signals.match_host_state in {None, MatchHostState.IDLE}
        and signals.current_rig is None
        and signals.current_rig_native is None
        and signals.current_rig_alive is not True
        and signals.scene_loading is not True
        and signals.scene_unloading is not True
        and signals.hub_suspended is not True
        and signals.board_instance is None
        # Active/ManagerMatch singleton references can survive scene teardown.
        # Without a Board, rig, transition or suspended hub they are stale
        # ownership telemetry rather than positive live-combat evidence.
    )


__all__ = [
    "BossLobbyRuntimeSnapshot",
    "ChinhPhucRoomSnapshot",
    "MANAGER_QUANG_TRUONG_TYPE_INFO_RVA",
    "MANAGER_ROOM_TYPE_INFO_RVA",
    "WS_ROOM_SERVICE_TYPE_INFO_RVA",
    "WorldBossListSnapshot",
    "read_boss_lobby_runtime",
    "read_chinh_phuc_room",
    "read_world_boss_list",
]
