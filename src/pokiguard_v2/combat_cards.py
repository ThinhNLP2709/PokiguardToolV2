"""Fail-closed read-only views of Fusion and ordinary combat-card UI state.

These layouts are build-specific and come from the local Cpp2IL output.  The
module never invokes ``CanUseCard`` or any game method.  For ordinary cards it
reads the ``Button.interactable`` value which ``CardUI.UpdateCardVisual`` sets
from ``CanUseCard`` every frame.
"""

from __future__ import annotations

from dataclasses import dataclass
import math
import struct
from typing import Iterable

from .il2cpp_external import (
    MATCH_SERVICE_FUSION_ENABLED_OFFSET,
    MATCH_SERVICE_FUSION_MANA_COST_OFFSET,
    MATCH_SERVICE_FUSION_STAT_PERCENT_OFFSET,
    MATCH_SERVICE_LOCAL_FUSION_LAST_ATTEMPT_TURN_OFFSET,
    MATCH_SERVICE_LOCAL_FUSION_DROP_REASON_OFFSET,
    MATCH_SERVICE_LOCAL_FUSION_SELECTED_PET_ID_OFFSET,
    MATCH_SERVICE_LOCAL_FUSION_SELECTED_USER_PET_ID_OFFSET,
    MATCH_SERVICE_LOCAL_FUSION_SKILL_CARD_OFFSET,
    MATCH_SERVICE_LOCAL_FUSION_USED_OFFSET,
    MATCH_SERVICE_TURN_NUMBER_OFFSET,
    ExternalReadError,
    MemoryReader,
    is_canonical_user_pointer,
)
from .il2cpp_layout import LayoutValidationError, read_il2cpp_string


UNITY_OBJECT_CACHED_PTR_OFFSET = 0x10

CARD_UI_CARD_DATA_OFFSET = 0x20
CARD_UI_BUTTON_OFFSET = 0x28
CARD_UI_BOARD_OFFSET = 0x30
CARD_UI_ACTIVE_OFFSET = 0x38
CARD_UI_HAS_USED_THIS_MATCH_OFFSET = 0x40
CARD_UI_HAS_USED_THIS_TURN_OFFSET = 0x41
CARD_UI_LAST_TURN_USED_OFFSET = 0x44
CARD_UI_ACTION_PENDING_OFFSET = 0x48
CARD_UI_IS_PLACEHOLDER_OFFSET = 0x78
CARD_UI_READ_SIZE = 0x79

CARD_DATA_ID_OFFSET = 0x10
CARD_DATA_CARD_ID_OFFSET = 0x18
CARD_DATA_NAME_OFFSET = 0x20
CARD_DATA_DESCRIPTION_OFFSET = 0x28
CARD_DATA_ELEMENT_TYPE_OFFSET = 0x30
CARD_DATA_VALUE_OFFSET = 0x38
CARD_DATA_MAX_LEVEL_OFFSET = 0x3C
CARD_DATA_COUNT_OFFSET = 0x40
CARD_DATA_LEVEL_OFFSET = 0x44
CARD_DATA_CONDITION_USE_OFFSET = 0x48
CARD_DATA_POWER_OFFSET = 0x50
CARD_DATA_GREEN_OFFSET = 0x58
CARD_DATA_BLUE_OFFSET = 0x5C
CARD_DATA_RED_OFFSET = 0x60
CARD_DATA_YELLOW_OFFSET = 0x64
CARD_DATA_WHITE_OFFSET = 0x68
CARD_DATA_PURPLE_OFFSET = 0x6C
CARD_DATA_DAMAGE_MULTIPLIER_OFFSET = 0x70
CARD_DATA_SKILL_TYPE_OFFSET = 0x78
CARD_DATA_MANA_COST_OFFSET = 0x80
CARD_DATA_POWER_COST_OFFSET = 0x84
CARD_DATA_COOLDOWN_TURNS_OFFSET = 0x88
CARD_DATA_NEED_PERFECTION_OFFSET = 0x8C
CARD_DATA_EAT_PERFECT_OFFSET = 0x90
CARD_DATA_EAT_GOOD_OFFSET = 0x94
CARD_DATA_EAT_BAD_OFFSET = 0x98
CARD_DATA_READ_SIZE = 0x9C

SELECTABLE_INTERACTABLE_OFFSET = 0xD8

FUSION_CARD_UI_BUTTON_OFFSET = 0x58
FUSION_CARD_UI_NEXT_REFRESH_AT_OFFSET = 0x60
FUSION_CARD_UI_BOUND_PET_ID_OFFSET = 0x68
FUSION_CARD_UI_READ_SIZE = 0x70

# Exact strings tested by CardUI.IsAttackCard in this build.
ATTACK_ELEMENT_TYPES = frozenset(
    {"ATTACK", "ATTACK_LEGEND", "ATTACK_LEGEND_", "MEGA1"}
)


def _bool(raw: bytes, offset: int, label: str) -> bool:
    value = raw[offset]
    if value not in (0, 1):
        raise LayoutValidationError(f"{label} is not an IL2CPP bool")
    return bool(value)


def _pointer(raw: bytes, offset: int) -> int:
    return struct.unpack_from("<Q", raw, offset)[0]


def _optional_string(
    memory: MemoryReader, pointer: int, *, label: str, max_length: int
) -> str | None:
    if pointer == 0:
        return None
    try:
        return read_il2cpp_string(memory, pointer, max_length=max_length)
    except (ExternalReadError, OSError, LayoutValidationError) as exc:
        raise LayoutValidationError(f"invalid {label}: {exc}") from exc


@dataclass(frozen=True)
class FusionState:
    match_service: int
    turn_number: int
    enabled: bool
    mana_cost: int
    stat_percent: int
    used_successfully: bool
    last_attempt_turn: int
    locked_this_turn: bool
    selected_user_pet_id: int
    selected_pet_id: int
    skill_card: int | None
    drop_reason: str | None

    @property
    def candidate_available(self) -> bool:
        """A conservative policy candidate, not a complete click decision.

        Local mana, ownership/current turn and visible UI still need to agree.
        """

        return self.enabled and not self.used_successfully and not self.locked_this_turn


@dataclass(frozen=True)
class FusionUiState:
    """Validated live ``FusionCardUI`` wrapper and its Unity Button state."""

    address: int
    button: int
    interactable: bool
    next_refresh_at: float
    bound_pet_id: int


@dataclass(frozen=True)
class CombatCardState:
    address: int
    card_data: int
    button: int
    data_id: int
    card_id: int
    name: str | None
    description: str | None
    element_type: str
    skill_type: str | None
    value: int
    max_level: int
    count: int
    level: int
    condition_use: int
    power: int
    green: int
    blue: int
    red: int
    yellow: int
    white: int
    purple: int
    damage_multiplier: float
    mana_cost: int
    power_cost: int
    cooldown_turns: int
    need_perfection: bool
    eat_perfect: int
    eat_good: int
    eat_bad: int
    has_used_this_match: bool
    has_used_this_turn: bool
    last_turn_used: int
    action_pending: bool
    is_placeholder: bool
    ui_interactable: bool

    @property
    def is_attack_card(self) -> bool:
        return self.element_type.upper() in ATTACK_ELEMENT_TYPES


@dataclass(frozen=True)
class CardDataState:
    address: int
    data_id: int
    card_id: int
    name: str | None
    description: str | None
    element_type: str
    skill_type: str | None
    value: int
    max_level: int
    count: int
    level: int
    condition_use: int
    power: int
    green: int
    blue: int
    red: int
    yellow: int
    white: int
    purple: int
    damage_multiplier: float
    mana_cost: int
    power_cost: int
    cooldown_turns: int
    need_perfection: bool
    eat_perfect: int
    eat_good: int
    eat_bad: int


def read_card_data(memory: MemoryReader, card_data: int) -> CardDataState:
    if not is_canonical_user_pointer(card_data) or not memory.is_readable(
        card_data, CARD_DATA_READ_SIZE
    ):
        raise LayoutValidationError("CardData pointer is invalid")
    data = memory.read(card_data, CARD_DATA_READ_SIZE)
    class_pointer = _pointer(data, 0)
    if not is_canonical_user_pointer(class_pointer) or not memory.is_readable(
        class_pointer, 8
    ):
        raise LayoutValidationError("CardData class pointer is invalid")
    data_id = struct.unpack_from("<q", data, CARD_DATA_ID_OFFSET)[0]
    card_id = struct.unpack_from("<q", data, CARD_DATA_CARD_ID_OFFSET)[0]
    element_type = _optional_string(
        memory,
        _pointer(data, CARD_DATA_ELEMENT_TYPE_OFFSET),
        label="elementTypeCard",
        max_length=64,
    )
    if not element_type:
        raise LayoutValidationError("CardData.elementTypeCard is empty")
    name = _optional_string(
        memory, _pointer(data, CARD_DATA_NAME_OFFSET), label="card name", max_length=256
    )
    description = _optional_string(
        memory,
        _pointer(data, CARD_DATA_DESCRIPTION_OFFSET),
        label="card description",
        max_length=2048,
    )
    skill_type = _optional_string(
        memory,
        _pointer(data, CARD_DATA_SKILL_TYPE_OFFSET),
        label="skillType",
        max_length=128,
    )
    value, max_level, count, level = struct.unpack_from(
        "<4i", data, CARD_DATA_VALUE_OFFSET
    )
    condition_use, power = struct.unpack_from(
        "<2q", data, CARD_DATA_CONDITION_USE_OFFSET
    )
    green, blue, red, yellow, white, purple = struct.unpack_from(
        "<6i", data, CARD_DATA_GREEN_OFFSET
    )
    damage_multiplier = struct.unpack_from(
        "<f", data, CARD_DATA_DAMAGE_MULTIPLIER_OFFSET
    )[0]
    mana_cost, power_cost, cooldown = struct.unpack_from(
        "<iii", data, CARD_DATA_MANA_COST_OFFSET
    )
    need_perfection = _bool(
        data, CARD_DATA_NEED_PERFECTION_OFFSET, "CardData.needPerfection"
    )
    eat_perfect, eat_good, eat_bad = struct.unpack_from(
        "<3i", data, CARD_DATA_EAT_PERFECT_OFFSET
    )
    if not 0 < card_id <= 0x7FFFFFFF or data_id < 0:
        raise LayoutValidationError("CardData identifiers are implausible")
    if not all(0 <= item <= 1_000_000 for item in (mana_cost, power_cost)):
        raise LayoutValidationError("CardData resource cost is implausible")
    if not 0 <= cooldown <= 10_000:
        raise LayoutValidationError("CardData cooldown is implausible")
    if not math.isfinite(damage_multiplier) or abs(damage_multiplier) > 1_000_000:
        raise LayoutValidationError("CardData.damageMultiplier is implausible")
    return CardDataState(
        address=card_data,
        data_id=data_id,
        card_id=card_id,
        name=name,
        description=description,
        element_type=element_type,
        skill_type=skill_type,
        value=value,
        max_level=max_level,
        count=count,
        level=level,
        condition_use=condition_use,
        power=power,
        green=green,
        blue=blue,
        red=red,
        yellow=yellow,
        white=white,
        purple=purple,
        damage_multiplier=damage_multiplier,
        mana_cost=mana_cost,
        power_cost=power_cost,
        cooldown_turns=cooldown,
        need_perfection=need_perfection,
        eat_perfect=eat_perfect,
        eat_good=eat_good,
        eat_bad=eat_bad,
    )


def read_fusion_state(memory: MemoryReader, match_service: int) -> FusionState:
    if not is_canonical_user_pointer(match_service) or not memory.is_readable(
        match_service, MATCH_SERVICE_LOCAL_FUSION_DROP_REASON_OFFSET + 8
    ):
        raise LayoutValidationError("MatchService Fusion range is unreadable")
    raw = memory.read(
        match_service,
        MATCH_SERVICE_LOCAL_FUSION_DROP_REASON_OFFSET + 8,
    )
    turn = struct.unpack_from("<i", raw, MATCH_SERVICE_TURN_NUMBER_OFFSET)[0]
    enabled = _bool(raw, MATCH_SERVICE_FUSION_ENABLED_OFFSET, "FusionEnabled")
    mana_cost = struct.unpack_from(
        "<i", raw, MATCH_SERVICE_FUSION_MANA_COST_OFFSET
    )[0]
    stat_percent = struct.unpack_from(
        "<i", raw, MATCH_SERVICE_FUSION_STAT_PERCENT_OFFSET
    )[0]
    used = _bool(
        raw, MATCH_SERVICE_LOCAL_FUSION_USED_OFFSET, "LocalFusionUsed"
    )
    last_attempt = struct.unpack_from(
        "<i", raw, MATCH_SERVICE_LOCAL_FUSION_LAST_ATTEMPT_TURN_OFFSET
    )[0]
    selected_user_pet = struct.unpack_from(
        "<q", raw, MATCH_SERVICE_LOCAL_FUSION_SELECTED_USER_PET_ID_OFFSET
    )[0]
    selected_pet = struct.unpack_from(
        "<q", raw, MATCH_SERVICE_LOCAL_FUSION_SELECTED_PET_ID_OFFSET
    )[0]
    skill_card_value = _pointer(raw, MATCH_SERVICE_LOCAL_FUSION_SKILL_CARD_OFFSET)
    drop_reason_pointer = _pointer(
        raw, MATCH_SERVICE_LOCAL_FUSION_DROP_REASON_OFFSET
    )
    if not 0 <= turn <= 1_000_000:
        raise LayoutValidationError("Fusion turn number is implausible")
    if not 0 <= mana_cost <= 1_000_000 or not 0 <= stat_percent <= 100_000:
        raise LayoutValidationError("Fusion configuration is implausible")
    if not -1 <= last_attempt <= 1_000_000:
        raise LayoutValidationError("Fusion last-attempt turn is implausible")
    if skill_card_value and (
        not is_canonical_user_pointer(skill_card_value)
        or not memory.is_readable(skill_card_value, 0x20)
    ):
        raise LayoutValidationError("Fusion skill-card pointer is invalid")
    drop_reason = _optional_string(
        memory,
        drop_reason_pointer,
        label="LocalFusionDropReason",
        max_length=512,
    )
    return FusionState(
        match_service=match_service,
        turn_number=turn,
        enabled=enabled,
        mana_cost=mana_cost,
        stat_percent=stat_percent,
        used_successfully=used,
        last_attempt_turn=last_attempt,
        locked_this_turn=last_attempt > 0 and last_attempt == turn,
        selected_user_pet_id=selected_user_pet,
        selected_pet_id=selected_pet,
        skill_card=skill_card_value or None,
        drop_reason=drop_reason,
    )


def read_fusion_card_ui(
    memory: MemoryReader,
    address: int,
    *,
    expected_class: int,
) -> FusionUiState:
    """Read one live FusionCardUI without invoking Unity/game methods."""

    if not is_canonical_user_pointer(address) or not memory.is_readable(
        address, FUSION_CARD_UI_READ_SIZE
    ):
        raise LayoutValidationError("FusionCardUI range is unreadable")
    raw = memory.read(address, FUSION_CARD_UI_READ_SIZE)
    if _pointer(raw, 0) != expected_class:
        raise LayoutValidationError("FusionCardUI class mismatch")
    cached_pointer = _pointer(raw, UNITY_OBJECT_CACHED_PTR_OFFSET)
    button = _pointer(raw, FUSION_CARD_UI_BUTTON_OFFSET)
    for label, pointer, size in (
        ("FusionCardUI native object", cached_pointer, 8),
        ("Fusion Button", button, SELECTABLE_INTERACTABLE_OFFSET + 1),
    ):
        if not is_canonical_user_pointer(pointer) or not memory.is_readable(
            pointer, size
        ):
            raise LayoutValidationError(f"{label} pointer is invalid")
    button_cached_pointer = struct.unpack(
        "<Q", memory.read(button + UNITY_OBJECT_CACHED_PTR_OFFSET, 8)
    )[0]
    if not is_canonical_user_pointer(button_cached_pointer) or not memory.is_readable(
        button_cached_pointer, 8
    ):
        raise LayoutValidationError("Fusion Button native object is invalid")
    interactable_raw = memory.read(button + SELECTABLE_INTERACTABLE_OFFSET, 1)[0]
    if interactable_raw not in (0, 1):
        raise LayoutValidationError("Fusion Button interactable is not a bool")
    next_refresh_at = struct.unpack_from(
        "<f", raw, FUSION_CARD_UI_NEXT_REFRESH_AT_OFFSET
    )[0]
    bound_pet_id = struct.unpack_from(
        "<q", raw, FUSION_CARD_UI_BOUND_PET_ID_OFFSET
    )[0]
    if not math.isfinite(next_refresh_at) or abs(next_refresh_at) > 1_000_000_000:
        raise LayoutValidationError("FusionCardUI refresh time is implausible")
    if not -1 <= bound_pet_id <= 10**15:
        raise LayoutValidationError("FusionCardUI bound pet id is implausible")
    return FusionUiState(
        address=address,
        button=button,
        interactable=bool(interactable_raw),
        next_refresh_at=next_refresh_at,
        bound_pet_id=bound_pet_id,
    )


def validate_fusion_card_ui_hits(
    memory: MemoryReader,
    class_pointer_hits: Iterable[int],
    *,
    expected_class: int,
) -> tuple[FusionUiState, ...]:
    values: dict[int, FusionUiState] = {}
    for address in class_pointer_hits:
        try:
            value = read_fusion_card_ui(
                memory, address, expected_class=expected_class
            )
        except (ExternalReadError, OSError, LayoutValidationError):
            continue
        values[address] = value
    return tuple(sorted(values.values(), key=lambda item: item.address))


def read_combat_card(
    memory: MemoryReader,
    address: int,
    *,
    expected_class: int,
    expected_board: int,
    expected_active: int,
) -> CombatCardState:
    if not is_canonical_user_pointer(address) or not memory.is_readable(
        address, CARD_UI_READ_SIZE
    ):
        raise LayoutValidationError("CardUI range is unreadable")
    raw = memory.read(address, CARD_UI_READ_SIZE)
    if _pointer(raw, 0) != expected_class:
        raise LayoutValidationError("CardUI class mismatch")
    cached_pointer = _pointer(raw, UNITY_OBJECT_CACHED_PTR_OFFSET)
    card_data = _pointer(raw, CARD_UI_CARD_DATA_OFFSET)
    button = _pointer(raw, CARD_UI_BUTTON_OFFSET)
    if _pointer(raw, CARD_UI_BOARD_OFFSET) != expected_board:
        raise LayoutValidationError("CardUI does not belong to current Board")
    if _pointer(raw, CARD_UI_ACTIVE_OFFSET) != expected_active:
        raise LayoutValidationError("CardUI does not belong to current Active")
    for label, pointer, size in (
        ("CardUI native object", cached_pointer, 8),
        ("CardData", card_data, CARD_DATA_READ_SIZE),
        ("Button", button, SELECTABLE_INTERACTABLE_OFFSET + 1),
    ):
        if not is_canonical_user_pointer(pointer) or not memory.is_readable(pointer, size):
            raise LayoutValidationError(f"{label} pointer is invalid")

    card = read_card_data(memory, card_data)

    interactable_raw = memory.read(button + SELECTABLE_INTERACTABLE_OFFSET, 1)
    if interactable_raw[0] not in (0, 1):
        raise LayoutValidationError("Button.m_Interactable is not an IL2CPP bool")
    last_turn_used = struct.unpack_from("<i", raw, CARD_UI_LAST_TURN_USED_OFFSET)[0]
    if not -1 <= last_turn_used <= 1_000_000:
        raise LayoutValidationError("CardUI.lastTurnUsed is implausible")
    return CombatCardState(
        address=address,
        card_data=card_data,
        button=button,
        data_id=card.data_id,
        card_id=card.card_id,
        name=card.name,
        description=card.description,
        element_type=card.element_type,
        skill_type=card.skill_type,
        value=card.value,
        max_level=card.max_level,
        count=card.count,
        level=card.level,
        condition_use=card.condition_use,
        power=card.power,
        green=card.green,
        blue=card.blue,
        red=card.red,
        yellow=card.yellow,
        white=card.white,
        purple=card.purple,
        damage_multiplier=card.damage_multiplier,
        mana_cost=card.mana_cost,
        power_cost=card.power_cost,
        cooldown_turns=card.cooldown_turns,
        need_perfection=card.need_perfection,
        eat_perfect=card.eat_perfect,
        eat_good=card.eat_good,
        eat_bad=card.eat_bad,
        has_used_this_match=_bool(
            raw, CARD_UI_HAS_USED_THIS_MATCH_OFFSET, "hasUsedThisMatch"
        ),
        has_used_this_turn=_bool(
            raw, CARD_UI_HAS_USED_THIS_TURN_OFFSET, "hasUsedThisTurn"
        ),
        last_turn_used=last_turn_used,
        action_pending=_bool(raw, CARD_UI_ACTION_PENDING_OFFSET, "isActionPending"),
        is_placeholder=_bool(raw, CARD_UI_IS_PLACEHOLDER_OFFSET, "isPlaceholder"),
        ui_interactable=bool(interactable_raw[0]),
    )


def validate_combat_card_hits(
    memory: MemoryReader,
    class_pointer_hits: Iterable[int],
    *,
    expected_class: int,
    expected_board: int,
    expected_active: int,
) -> tuple[CombatCardState, ...]:
    cards: dict[int, CombatCardState] = {}
    for address in class_pointer_hits:
        try:
            card = read_combat_card(
                memory,
                address,
                expected_class=expected_class,
                expected_board=expected_board,
                expected_active=expected_active,
            )
        except (ExternalReadError, OSError, LayoutValidationError):
            continue
        cards[address] = card
    return tuple(sorted(cards.values(), key=lambda card: (card.card_id, card.address)))
