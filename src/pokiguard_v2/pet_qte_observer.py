"""Read-only Pet Skill/QTE observations for Pokiguard 1.7.4.

This module is deliberately diagnostic-only.  It decodes immutable snapshots
from layouts proven by the local Il2CppInspectorRedux/native output.  It does
not import an input executor, invoke an IL2CPP method, or write target memory.
"""

from __future__ import annotations

from dataclasses import dataclass
from enum import Enum
import math
import struct
from typing import Iterable

from .combat_cards import CardDataState, read_card_data
from .il2cpp_external import ExternalReadError, MemoryReader, is_canonical_user_pointer
from .il2cpp_layout import LayoutValidationError, read_il2cpp_string
from .state import CombatSessionKey


# Active / PetUserDTO (Assembly-CSharp, Pokiguard 1.7.4).
ACTIVE_PLAYER_PET_OFFSET = 0x300
PET_USER_ID_OFFSET = 0x10
PET_USER_USER_ID_OFFSET = 0x14
PET_USER_PET_ID_OFFSET = 0x1C
PET_USER_SKILL_CARD_ID_OFFSET = 0x20
PET_USER_NAME_OFFSET = 0x28
PET_USER_SKILL_CARD_NAME_OFFSET = 0x30
PET_USER_ELEMENT_TYPE_OFFSET = 0x40
PET_USER_LEVEL_OFFSET = 0x50
PET_USER_MAX_LEVEL_OFFSET = 0x54
PET_USER_MANA_SKILL_CARD_OFFSET = 0x70
PET_USER_EVO_STAGE_OFFSET = 0x74
PET_USER_CARD_DATA_OFFSET = 0x90
PET_USER_READ_SIZE = 0x98

# MatchService server-owned current QTE challenge.
MATCH_SERVICE_SERVER_QTE_ARROWS_OFFSET = 0x200
MATCH_SERVICE_SERVER_QTE_DURATION_MS_OFFSET = 0x208
MATCH_SERVICE_SERVER_QTE_WINDOW_OFFSET = 0x20C
MATCH_SERVICE_SERVER_QTE_READ_SIZE = 0x228

# CardUI active Dot/Legend QTE state.
CARD_UI_CARD_DATA_OFFSET = 0x20
CARD_UI_BUTTON_OFFSET = 0x28
CARD_UI_BOARD_OFFSET = 0x30
CARD_UI_ACTIVE_OFFSET = 0x38
CARD_UI_CURRENT_ACTOR_OFFSET = 0x54
CARD_UI_DURATION_OFFSET = 0xB8
CARD_UI_TIMING_TEXT_OFFSET = 0xF0
CARD_UI_CURRENT_ARROWS_OFFSET = 0x138
CARD_UI_DIRECTIONS_OFFSET = 0x140
CARD_UI_CURRENT_INDEX_OFFSET = 0x148
CARD_UI_CORRECT_COUNT_OFFSET = 0x14C
CARD_UI_ACTIVE_FLAG_OFFSET = 0x150
CARD_UI_CURRENT_TIME_VALUE_OFFSET = 0x154
CARD_UI_DAMAGE_MULTIPLIER_OFFSET = 0x158
CARD_UI_FINISHED_OFFSET = 0x170
CARD_UI_PERFECT_START_OFFSET = 0x1A0
CARD_UI_PERFECT_END_OFFSET = 0x1A4
CARD_UI_GOOD_START_1_OFFSET = 0x1A8
CARD_UI_GOOD_END_1_OFFSET = 0x1AC
CARD_UI_GOOD_START_2_OFFSET = 0x1B0
CARD_UI_GOOD_END_2_OFFSET = 0x1B4
CARD_UI_TIMING_BONUS_OFFSET = 0x1B8
CARD_UI_CURRENT_ARROW_SEED_OFFSET = 0x318
CARD_UI_QTE_PRESSES_OFFSET = 0x320
CARD_UI_READ_SIZE = 0x329
UNITY_OBJECT_CACHED_PTR_OFFSET = 0x10
UNITY_UI_TEXT_VALUE_OFFSET = 0xE8
SELECTABLE_INTERACTABLE_OFFSET = 0xD8

# ChatMessageDTO result fields.
CHAT_MESSAGE_TYPE_OFFSET = 0x30
CHAT_MESSAGE_TIMESTAMP_OFFSET = 0x28
CHAT_MESSAGE_MATCH_ID_OFFSET = 0xB0
CHAT_MESSAGE_SKILL_CARD_ID_OFFSET = 0x108
CHAT_MESSAGE_CORRECT_DOT_COUNT_OFFSET = 0x110
CHAT_MESSAGE_TIMING_RESULT_OFFSET = 0x118
CHAT_MESSAGE_DOTS_TO_DESTROY_OFFSET = 0x120
CHAT_MESSAGE_QTE_PRESSES_OFFSET = 0x138
CHAT_MESSAGE_QTE_ELAPSED_MS_OFFSET = 0x140
CHAT_MESSAGE_QTE_RESULT_READ_SIZE = 0x148

MANAGED_LIST_ITEMS_OFFSET = 0x10
MANAGED_LIST_SIZE_OFFSET = 0x18
MANAGED_LIST_VERSION_OFFSET = 0x1C
IL2CPP_ARRAY_LENGTH_OFFSET = 0x18
IL2CPP_ARRAY_DATA_OFFSET = 0x20

CANONICAL_DIRECTIONS = ("nutUp", "nutDown", "nutLeft", "nutRight")
QTE_RESULT_TYPES = frozenset({"MATCH_SKILL_USE_RES"})
DOT_SKILL_ELEMENT_TYPES = frozenset({"ATTACK_LEGEND", "ATTACK_LEGEND_"})


class QteBindingStatus(str, Enum):
    INACTIVE = "INACTIVE"
    BOUND_CURRENT = "BOUND_CURRENT"
    COMPLETED_CURRENT = "COMPLETED_CURRENT"
    QTE_MISSING = "QTE_MISSING"
    AMBIGUOUS_QTE_CANDIDATES = "AMBIGUOUS_QTE_CANDIDATES"
    UNBOUND_MIDSTREAM = "UNBOUND_MIDSTREAM"
    WRONG_SESSION = "WRONG_SESSION"
    WRONG_OWNER = "WRONG_OWNER"
    WRONG_CARD = "WRONG_CARD"
    SEQUENCE_UNAVAILABLE = "SEQUENCE_UNAVAILABLE"
    UNKNOWN_DIRECTION = "UNKNOWN_DIRECTION"
    INVALID_PROGRESS = "INVALID_PROGRESS"
    INVALID_TIMING = "INVALID_TIMING"
    STALE_OR_CHANGED_QTE = "STALE_OR_CHANGED_QTE"


def _read_exact(memory: MemoryReader, address: int, size: int, label: str) -> bytes:
    if (
        size <= 0
        or not is_canonical_user_pointer(address)
        or not memory.is_readable(address, size)
    ):
        raise LayoutValidationError(f"{label} range is unreadable")
    raw = memory.read(address, size)
    if len(raw) != size:
        raise LayoutValidationError(f"short {label} read")
    return raw


def _pointer(raw: bytes, offset: int) -> int:
    return struct.unpack_from("<Q", raw, offset)[0]


def _bool(raw: bytes, offset: int, label: str) -> bool:
    value = raw[offset]
    if value not in (0, 1):
        raise LayoutValidationError(f"{label} is not an IL2CPP bool")
    return bool(value)


def _optional_string(
    memory: MemoryReader, pointer: int, *, label: str, max_length: int = 256
) -> str | None:
    if pointer == 0:
        return None
    try:
        return read_il2cpp_string(memory, pointer, max_length=max_length)
    except (ExternalReadError, OSError, LayoutValidationError) as exc:
        raise LayoutValidationError(f"invalid {label}: {exc}") from exc


def normalize_qte_direction(raw: str | None) -> str | None:
    """Mirror ``CardUI.NormalizeArrowDir`` from the 1.7.4 native body."""

    if raw is None:
        return None
    value = raw.strip()
    if value[:3].casefold() == "nut":
        value = value[3:]
    return {
        "up": "nutUp",
        "down": "nutDown",
        "left": "nutLeft",
        "right": "nutRight",
    }.get(value.casefold())


def _read_stable_string_list(
    memory: MemoryReader,
    list_pointer: int,
    *,
    label: str,
    max_items: int = 64,
) -> tuple[str, ...]:
    if not is_canonical_user_pointer(list_pointer):
        raise LayoutValidationError(f"{label} list pointer is invalid")
    before = _read_exact(memory, list_pointer, 0x20, f"{label} list")
    items = _pointer(before, MANAGED_LIST_ITEMS_OFFSET)
    size = struct.unpack_from("<i", before, MANAGED_LIST_SIZE_OFFSET)[0]
    version = struct.unpack_from("<i", before, MANAGED_LIST_VERSION_OFFSET)[0]
    if not 0 <= size <= max_items or version < 0:
        raise LayoutValidationError(f"{label} list shape is invalid")
    if size == 0:
        return ()
    array = _read_exact(
        memory,
        items,
        IL2CPP_ARRAY_DATA_OFFSET + size * 8,
        f"{label} backing array",
    )
    capacity = struct.unpack_from("<Q", array, IL2CPP_ARRAY_LENGTH_OFFSET)[0]
    if not size <= capacity <= max_items * 4:
        raise LayoutValidationError(f"{label} backing capacity is invalid")
    pointers = struct.unpack_from(f"<{size}Q", array, IL2CPP_ARRAY_DATA_OFFSET)
    values = tuple(
        read_il2cpp_string(memory, pointer, max_length=64) for pointer in pointers
    )
    if _read_exact(memory, list_pointer, 0x20, f"{label} list") != before:
        raise LayoutValidationError(f"{label} changed during read")
    return values


def _read_stable_list_count(
    memory: MemoryReader,
    list_pointer: int,
    *,
    label: str,
    max_items: int = 64,
) -> int:
    """Read only a managed List shape; element semantics stay unclaimed."""

    before = _read_exact(memory, list_pointer, 0x20, f"{label} list")
    items = _pointer(before, MANAGED_LIST_ITEMS_OFFSET)
    size = struct.unpack_from("<i", before, MANAGED_LIST_SIZE_OFFSET)[0]
    version = struct.unpack_from("<i", before, MANAGED_LIST_VERSION_OFFSET)[0]
    if not 0 <= size <= max_items or version < 0:
        raise LayoutValidationError(f"{label} list shape is invalid")
    if size:
        array = _read_exact(
            memory, items, IL2CPP_ARRAY_DATA_OFFSET, f"{label} backing array"
        )
        capacity = struct.unpack_from("<Q", array, IL2CPP_ARRAY_LENGTH_OFFSET)[0]
        if not size <= capacity <= max_items * 4:
            raise LayoutValidationError(f"{label} backing capacity is invalid")
    if _read_exact(memory, list_pointer, 0x20, f"{label} list") != before:
        raise LayoutValidationError(f"{label} changed during read")
    return size


@dataclass(frozen=True)
class PetSkillSnapshot:
    address: int
    data_id: int
    user_id: int | None
    pet_id: int
    skill_card_id: int | None
    name: str | None
    skill_card_name: str | None
    element_type: str | None
    level: int
    max_level: int
    mana_skill_card: int
    evo_stage: int
    card_data_address: int | None
    card_data: CardDataState | None
    card_identity_matches: bool | None


def read_player_pet_skill(
    memory: MemoryReader,
    active_instance: int,
    *,
    expected_pet_class: int | None = None,
    expected_card_class: int | None = None,
) -> PetSkillSnapshot | None:
    """Read ``Active.playerPets`` and its exact ``PetUserDTO.cardDTO``."""

    owner = _read_exact(
        memory,
        active_instance + ACTIVE_PLAYER_PET_OFFSET,
        8,
        "Active.playerPets",
    )
    pet_address = struct.unpack("<Q", owner)[0]
    if pet_address == 0:
        return None
    before = _read_exact(memory, pet_address, PET_USER_READ_SIZE, "PetUserDTO")
    class_pointer = _pointer(before, 0)
    if expected_pet_class is not None and class_pointer != expected_pet_class:
        raise LayoutValidationError("PetUserDTO class pointer mismatch")
    if not is_canonical_user_pointer(class_pointer):
        raise LayoutValidationError("PetUserDTO class pointer is invalid")

    data_id = struct.unpack_from("<i", before, PET_USER_ID_OFFSET)[0]
    user_has_value = before[PET_USER_USER_ID_OFFSET]
    if user_has_value not in (0, 1):
        raise LayoutValidationError("PetUserDTO.userId Nullable flag is invalid")
    user_id = (
        struct.unpack_from("<i", before, PET_USER_USER_ID_OFFSET + 4)[0]
        if user_has_value
        else None
    )
    pet_id = struct.unpack_from("<i", before, PET_USER_PET_ID_OFFSET)[0]
    skill_card_raw = struct.unpack_from("<i", before, PET_USER_SKILL_CARD_ID_OFFSET)[0]
    level, max_level = struct.unpack_from("<ii", before, PET_USER_LEVEL_OFFSET)
    mana_skill_card = struct.unpack_from(
        "<i", before, PET_USER_MANA_SKILL_CARD_OFFSET
    )[0]
    evo_stage = struct.unpack_from("<i", before, PET_USER_EVO_STAGE_OFFSET)[0]
    card_data_address = _pointer(before, PET_USER_CARD_DATA_OFFSET)
    if (
        data_id < 0
        or pet_id <= 0
        or skill_card_raw < 0
        or not 0 <= level <= 1_000_000
        or not 0 <= max_level <= 1_000_000
        or not 0 <= mana_skill_card <= 1_000_000
        or not 0 <= evo_stage <= 10_000
    ):
        raise LayoutValidationError("PetUserDTO scalar fields are implausible")

    card_data = None
    if card_data_address:
        card_data = read_card_data(memory, card_data_address)
        if expected_card_class is not None:
            raw_class = struct.unpack(
                "<Q", _read_exact(memory, card_data_address, 8, "CardData class")
            )[0]
            if raw_class != expected_card_class:
                raise LayoutValidationError("PetUserDTO.cardDTO class pointer mismatch")
    skill_card_id = skill_card_raw or None
    identity_matches = (
        None
        if skill_card_id is None or card_data is None
        else card_data.card_id == skill_card_id
    )
    if _read_exact(memory, pet_address, PET_USER_READ_SIZE, "PetUserDTO") != before:
        raise LayoutValidationError("PetUserDTO changed during read")
    return PetSkillSnapshot(
        address=pet_address,
        data_id=data_id,
        user_id=user_id,
        pet_id=pet_id,
        skill_card_id=skill_card_id,
        name=_optional_string(memory, _pointer(before, PET_USER_NAME_OFFSET), label="pet name"),
        skill_card_name=_optional_string(
            memory,
            _pointer(before, PET_USER_SKILL_CARD_NAME_OFFSET),
            label="skill-card name",
        ),
        element_type=_optional_string(
            memory,
            _pointer(before, PET_USER_ELEMENT_TYPE_OFFSET),
            label="pet elementType",
            max_length=64,
        ),
        level=level,
        max_level=max_level,
        mana_skill_card=mana_skill_card,
        evo_stage=evo_stage,
        card_data_address=card_data_address or None,
        card_data=card_data,
        card_identity_matches=identity_matches,
    )


@dataclass(frozen=True)
class QteWindowSnapshot:
    duration_ms: int
    perfect_start_ms: int
    perfect_end_ms: int
    good_start_1_ms: int
    good_end_1_ms: int
    good_start_2_ms: int
    good_end_2_ms: int

    @property
    def valid(self) -> bool:
        # Exact MatchService.QteWindow.Valid predicate in 1.7.4.
        return self.duration_ms > 0 and self.perfect_end_ms > self.perfect_start_ms


@dataclass(frozen=True)
class ServerQteChallengeSnapshot:
    match_id: str
    sequence_list_address: int | None
    raw_sequence: tuple[str, ...]
    normalized_sequence: tuple[str | None, ...]
    window: QteWindowSnapshot

    @property
    def sequence_known(self) -> bool:
        return bool(self.raw_sequence) and all(self.normalized_sequence)


def read_server_qte_challenge(
    memory: MemoryReader,
    match_service: int,
    *,
    match_id: str,
) -> ServerQteChallengeSnapshot:
    before = _read_exact(
        memory, match_service, MATCH_SERVICE_SERVER_QTE_READ_SIZE, "MatchService QTE"
    )
    sequence_pointer = _pointer(before, MATCH_SERVICE_SERVER_QTE_ARROWS_OFFSET)
    sequence = (
        _read_stable_string_list(memory, sequence_pointer, label="ServerQteArrows")
        if sequence_pointer
        else ()
    )
    duration_ms = struct.unpack_from(
        "<i", before, MATCH_SERVICE_SERVER_QTE_DURATION_MS_OFFSET
    )[0]
    window_values = struct.unpack_from(
        "<7i", before, MATCH_SERVICE_SERVER_QTE_WINDOW_OFFSET
    )
    if duration_ms != window_values[0]:
        raise LayoutValidationError("ServerQteDurationMs disagrees with ServerQteWindow")
    if any(value < 0 or value > 300_000 for value in window_values):
        raise LayoutValidationError("server QTE timing value is implausible")
    if _read_exact(
        memory, match_service, MATCH_SERVICE_SERVER_QTE_READ_SIZE, "MatchService QTE"
    ) != before:
        raise LayoutValidationError("MatchService QTE changed during read")
    return ServerQteChallengeSnapshot(
        match_id=match_id,
        sequence_list_address=sequence_pointer or None,
        raw_sequence=sequence,
        normalized_sequence=tuple(normalize_qte_direction(value) for value in sequence),
        window=QteWindowSnapshot(*window_values),
    )


@dataclass(frozen=True)
class CardUiQteSnapshot:
    address: int
    card_data_address: int
    button_address: int | None
    button_interactable: bool | None
    button_validated: bool
    board_instance: int
    active_instance: int
    actor_number: int
    duration_seconds: float
    current_index: int
    correct_count: int
    active: bool
    current_time_value: float
    damage_multiplier: float
    finished: bool
    displayed_timing_text: str | None
    displayed_timing_result: str | None
    current_arrows_list_address: int | None
    current_arrow_count: int | None
    perfect_start_seconds: float
    perfect_end_seconds: float
    good_start_1_seconds: float
    good_end_1_seconds: float
    good_start_2_seconds: float
    good_end_2_seconds: float
    timing_bonus: int
    current_arrow_seed: int
    qte_presses_list_address: int | None
    qte_presses: tuple[str, ...]

    @property
    def elapsed_seconds(self) -> float:
        return self.duration_seconds * (1.0 - self.current_time_value)

    @property
    def qte_elapsed_ms(self) -> int:
        elapsed = round(self.elapsed_seconds * 1000.0)
        maximum = round(self.duration_seconds * 1000.0)
        return max(0, min(elapsed, maximum))

    @property
    def timing_window_valid(self) -> bool:
        return (
            math.isfinite(self.duration_seconds)
            and self.duration_seconds > 0
            and math.isfinite(self.perfect_start_seconds)
            and math.isfinite(self.perfect_end_seconds)
            and self.perfect_end_seconds > self.perfect_start_seconds
        )


def _card_ui_qte_consistency_signature(raw: bytes) -> tuple[bytes, ...]:
    """Return only ownership, identity, progress and timing bytes.

    ``CardUI.currentTimeValue`` changes every rendered frame while a QTE is
    active.  Comparing the complete object before/after the dependent list
    reads therefore rejects otherwise coherent snapshots.  Exclude that one
    expected clock field (and unrelated animation/UI state), while retaining
    every field used to bind a generation or acknowledge direction progress.
    """

    return (
        raw[0x00:0x08],  # managed class
        raw[0x10:0x18],  # Unity native object
        raw[0x20:0x40],  # card/button/Board/Active ownership
        raw[CARD_UI_CURRENT_ACTOR_OFFSET : CARD_UI_CURRENT_ACTOR_OFFSET + 4],
        raw[CARD_UI_DURATION_OFFSET : CARD_UI_DURATION_OFFSET + 4],
        raw[CARD_UI_TIMING_TEXT_OFFSET : CARD_UI_TIMING_TEXT_OFFSET + 8],
        raw[CARD_UI_CURRENT_ARROWS_OFFSET : CARD_UI_ACTIVE_FLAG_OFFSET + 1],
        raw[CARD_UI_DAMAGE_MULTIPLIER_OFFSET : CARD_UI_DAMAGE_MULTIPLIER_OFFSET + 4],
        raw[CARD_UI_FINISHED_OFFSET : CARD_UI_FINISHED_OFFSET + 1],
        raw[CARD_UI_PERFECT_START_OFFSET : CARD_UI_TIMING_BONUS_OFFSET + 4],
        raw[CARD_UI_CURRENT_ARROW_SEED_OFFSET : CARD_UI_QTE_PRESSES_OFFSET + 8],
    )


def read_card_ui_qte(
    memory: MemoryReader,
    address: int,
    *,
    expected_class: int,
    expected_board: int,
    expected_active: int,
    expected_card_data: int | None,
    require_button: bool = False,
) -> CardUiQteSnapshot:
    before = _read_exact(memory, address, CARD_UI_READ_SIZE, "CardUI QTE")
    if _pointer(before, 0) != expected_class:
        raise LayoutValidationError("CardUI class pointer mismatch")
    native_pointer = _pointer(before, UNITY_OBJECT_CACHED_PTR_OFFSET)
    if not is_canonical_user_pointer(native_pointer) or not memory.is_readable(
        native_pointer, 1
    ):
        raise LayoutValidationError("CardUI native object is invalid")
    card_data = _pointer(before, CARD_UI_CARD_DATA_OFFSET)
    button = _pointer(before, CARD_UI_BUTTON_OFFSET)
    board = _pointer(before, CARD_UI_BOARD_OFFSET)
    active = _pointer(before, CARD_UI_ACTIVE_OFFSET)
    if board != expected_board or active != expected_active:
        raise LayoutValidationError("CardUI does not belong to current Board/Active")
    if expected_card_data is not None and card_data != expected_card_data:
        raise LayoutValidationError("CardUI does not own the current pet skill CardData")
    button_interactable = None
    button_validated = False
    if button:
        if not is_canonical_user_pointer(button) or not memory.is_readable(
            button, SELECTABLE_INTERACTABLE_OFFSET + 1
        ):
            raise LayoutValidationError("CardUI Button pointer is invalid")
        interactable_raw = memory.read(button + SELECTABLE_INTERACTABLE_OFFSET, 1)
        if len(interactable_raw) != 1 or interactable_raw[0] not in (0, 1):
            raise LayoutValidationError("Button.m_Interactable is not an IL2CPP bool")
        button_interactable = bool(interactable_raw[0])
        button_validated = True
    elif require_button:
        raise LayoutValidationError("CardUI Button is required for live-card ownership")
    actor = struct.unpack_from("<i", before, CARD_UI_CURRENT_ACTOR_OFFSET)[0]
    duration = struct.unpack_from("<f", before, CARD_UI_DURATION_OFFSET)[0]
    index, correct = struct.unpack_from("<ii", before, CARD_UI_CURRENT_INDEX_OFFSET)
    active_flag = _bool(before, CARD_UI_ACTIVE_FLAG_OFFSET, "CardUI.isDotSkillActive")
    current_time = struct.unpack_from("<f", before, CARD_UI_CURRENT_TIME_VALUE_OFFSET)[0]
    multiplier = struct.unpack_from("<f", before, CARD_UI_DAMAGE_MULTIPLIER_OFFSET)[0]
    finished = _bool(before, CARD_UI_FINISHED_OFFSET, "CardUI.hasFinishedDotSkill")
    timing_text_object = _pointer(before, CARD_UI_TIMING_TEXT_OFFSET)
    displayed_timing_text = None
    if timing_text_object:
        text_object = _read_exact(
            memory,
            timing_text_object,
            UNITY_UI_TEXT_VALUE_OFFSET + 8,
            "CardUI.timingText",
        )
        displayed_timing_text = _optional_string(
            memory,
            _pointer(text_object, UNITY_UI_TEXT_VALUE_OFFSET),
            label="CardUI.timingText.m_Text",
            max_length=64,
        )
    timing = struct.unpack_from("<6f", before, CARD_UI_PERFECT_START_OFFSET)
    timing_bonus = struct.unpack_from("<i", before, CARD_UI_TIMING_BONUS_OFFSET)[0]
    seed = struct.unpack_from("<i", before, CARD_UI_CURRENT_ARROW_SEED_OFFSET)[0]
    presses_pointer = _pointer(before, CARD_UI_QTE_PRESSES_OFFSET)
    presses = (
        _read_stable_string_list(memory, presses_pointer, label="CardUI.qtePresses")
        if presses_pointer
        else ()
    )
    current_arrows_pointer = _pointer(before, CARD_UI_CURRENT_ARROWS_OFFSET)
    current_arrow_count = (
        _read_stable_list_count(
            memory, current_arrows_pointer, label="CardUI.currentArrows"
        )
        if current_arrows_pointer
        else None
    )
    scalars = (duration, current_time, multiplier, *timing)
    if (
        actor < 0
        or not -1 <= index <= 64
        or not 0 <= correct <= 64
        or any(not math.isfinite(value) for value in scalars)
        or not -0.05 <= current_time <= 1.05
    ):
        raise LayoutValidationError("CardUI QTE scalar fields are implausible")
    after = _read_exact(memory, address, CARD_UI_READ_SIZE, "CardUI QTE")
    if _card_ui_qte_consistency_signature(after) != _card_ui_qte_consistency_signature(
        before
    ):
        raise LayoutValidationError("CardUI QTE changed during read")
    return CardUiQteSnapshot(
        address=address,
        card_data_address=card_data,
        button_address=button or None,
        button_interactable=button_interactable,
        button_validated=button_validated,
        board_instance=board,
        active_instance=active,
        actor_number=actor,
        duration_seconds=duration,
        current_index=index,
        correct_count=correct,
        active=active_flag,
        current_time_value=max(0.0, min(current_time, 1.0)),
        damage_multiplier=multiplier,
        finished=finished,
        displayed_timing_text=displayed_timing_text,
        displayed_timing_result=normalize_displayed_timing_result(
            displayed_timing_text
        ),
        current_arrows_list_address=current_arrows_pointer or None,
        current_arrow_count=current_arrow_count,
        perfect_start_seconds=timing[0],
        perfect_end_seconds=timing[1],
        good_start_1_seconds=timing[2],
        good_end_1_seconds=timing[3],
        good_start_2_seconds=timing[4],
        good_end_2_seconds=timing[5],
        timing_bonus=timing_bonus,
        current_arrow_seed=seed,
        qte_presses_list_address=presses_pointer or None,
        qte_presses=presses,
    )


def normalize_displayed_timing_result(value: str | None) -> str | None:
    """Normalize only the three result words rendered by ``CardUI``.

    The raw text is retained in :class:`CardUiQteSnapshot`; this helper merely
    makes comparisons insensitive to case, whitespace and the optional
    exclamation mark used by the current localization.
    """

    if value is None:
        return None
    normalized = value.strip().upper().replace(" ", "")
    if "PERFECT" in normalized:
        return "PERFECT!"
    if "GOOD" in normalized:
        return "GOOD!"
    if "BAD" in normalized:
        return "BAD"
    return None


def read_qte_card_data(
    memory: MemoryReader,
    qte: CardUiQteSnapshot,
    *,
    expected_card_class: int | None = None,
) -> CardDataState:
    """Decode the card owned by the current QTE ``CardUI``.

    ``Active.playerPets`` remains the unevolved source pet in live combat.  The
    Legendary skill card is materialized only after a successful evolution, so
    the active QTE ``CardUI.cardData`` is the authoritative runtime owner for
    this boundary.  Class and native QTE-family checks keep the fallback closed.
    """

    address = qte.card_data_address
    if not is_canonical_user_pointer(address):
        raise LayoutValidationError("active QTE CardData pointer is invalid")
    raw_class = struct.unpack(
        "<Q", _read_exact(memory, address, 8, "active QTE CardData class")
    )[0]
    if expected_card_class is not None and raw_class != expected_card_class:
        raise LayoutValidationError("active QTE CardData class pointer mismatch")
    card = read_card_data(memory, address)
    if card.element_type.upper() not in DOT_SKILL_ELEMENT_TYPES:
        raise LayoutValidationError("active CardUI is not a proven Dot/Legend QTE card")
    return card


def classify_qte_timing(
    *,
    element_type: str | None,
    correct_count: int,
    elapsed_seconds: float,
    perfect_start_seconds: float,
    perfect_end_seconds: float,
    good_start_1_seconds: float,
    good_end_1_seconds: float,
    good_start_2_seconds: float,
    good_end_2_seconds: float,
) -> str | None:
    """Mirror ``CardUI.GetLastTimingResult``; return ``None`` if unprovable."""

    values = (
        elapsed_seconds,
        perfect_start_seconds,
        perfect_end_seconds,
        good_start_1_seconds,
        good_end_1_seconds,
        good_start_2_seconds,
        good_end_2_seconds,
    )
    if (
        correct_count < 0
        or any(not math.isfinite(value) for value in values)
        or perfect_end_seconds <= perfect_start_seconds
    ):
        return None
    perfect = perfect_start_seconds <= elapsed_seconds <= perfect_end_seconds
    if (element_type or "").upper() == "ATTACK_LEGEND_":
        if correct_count < 7:
            return "BAD"
        return "PERFECT!" if perfect else "GOOD!"
    if perfect:
        return "PERFECT!"
    good = (
        good_start_1_seconds <= elapsed_seconds < good_end_1_seconds
        or good_start_2_seconds < elapsed_seconds <= good_end_2_seconds
    )
    return "GOOD!" if good else "BAD"


@dataclass(frozen=True)
class QteResultSnapshot:
    address: int
    event_type: str
    timestamp: str | None
    match_id: str
    skill_card_id: int | None
    correct_count: int | None
    timing_result: str | None
    dots_to_destroy: int | None
    qte_presses: tuple[str, ...]
    qte_elapsed_ms: int | None


@dataclass(frozen=True)
class QteResponseCorrelation:
    current: bool
    provenance: str
    reason: str


def correlate_qte_response_envelope(
    observation: BoundQteObservation,
    *,
    event_type: str,
    match_id: str,
    skill_card_id: int | None,
    reject_reason: str | None,
    payload_bools: Iterable[tuple[str, bool]],
    server_timestamp_epoch: float | None,
    completion_epoch: float,
    observed_epoch: float,
    maximum_response_delay_seconds: float = 15.0,
) -> QteResponseCorrelation:
    """Correlate the generic 1.7.4 skill-response envelope conservatively.

    Live 1.7.4 evidence shows ``MATCH_SKILL_USE_RES`` is handled through the
    generic response-envelope path and may leave all QTE-specific DTO fields
    null.  An envelope without ``skillCardId`` is accepted only when it has the
    exact current MatchId and a server timestamp within the one completed QTE's
    short observation window.  This rejects old managed response objects while
    preserving explicit reject/success flags when the server supplies them.
    """

    identity = observation.identity
    qte = observation.qte
    if (
        identity is None
        or qte is None
        or observation.status is not QteBindingStatus.COMPLETED_CURRENT
    ):
        return QteResponseCorrelation(False, "NONE", "QTE is not completed/current")
    if event_type not in QTE_RESULT_TYPES:
        return QteResponseCorrelation(False, "NONE", "response type is not skill-use")
    if match_id != identity.session_key.match_id:
        return QteResponseCorrelation(False, "NONE", "response MatchId is stale")

    flags = dict(payload_bools)
    if reject_reason or flags.get("rejected") is True:
        return QteResponseCorrelation(False, "EXPLICIT_REJECT", "server rejected skill")
    if flags.get("success") is False or flags.get("accepted") is False:
        return QteResponseCorrelation(False, "EXPLICIT_REJECT", "server reported failure")
    if skill_card_id is not None and skill_card_id != identity.skill_card_id:
        return QteResponseCorrelation(False, "NONE", "response skillCardId differs")
    if not math.isfinite(completion_epoch) or not math.isfinite(observed_epoch):
        return QteResponseCorrelation(False, "NONE", "observer timestamps are invalid")
    if observed_epoch < completion_epoch:
        return QteResponseCorrelation(False, "NONE", "response predates completion")
    if observed_epoch - completion_epoch > maximum_response_delay_seconds:
        return QteResponseCorrelation(False, "NONE", "response observation is too late")

    if skill_card_id is not None:
        return QteResponseCorrelation(
            True,
            "EXACT_SESSION_CARD",
            "current MatchId and explicit skillCardId agree",
        )
    if server_timestamp_epoch is None or not math.isfinite(server_timestamp_epoch):
        return QteResponseCorrelation(
            False,
            "NONE",
            "generic response lacks a usable server timestamp",
        )
    # The game timestamp is local wall time without a timezone suffix in the
    # observed 1.7.4 build.  Permit small scheduling/clock rounding skew only.
    if not completion_epoch - 2.0 <= server_timestamp_epoch <= observed_epoch + 2.0:
        return QteResponseCorrelation(False, "NONE", "generic response is stale")
    return QteResponseCorrelation(
        True,
        "CURRENT_ENVELOPE_TEMPORAL_SESSION",
        "unique completed QTE, exact MatchId and bounded response timestamp agree",
    )


def _nullable_i32(raw: bytes, offset: int, label: str) -> int | None:
    flag = raw[offset]
    if flag not in (0, 1):
        raise LayoutValidationError(f"{label} Nullable flag is invalid")
    return struct.unpack_from("<i", raw, offset + 4)[0] if flag else None


def read_qte_result_message(
    memory: MemoryReader,
    address: int,
    *,
    expected_class: int,
    expected_match_id: str,
) -> QteResultSnapshot:
    before = _read_exact(
        memory, address, CHAT_MESSAGE_QTE_RESULT_READ_SIZE, "QTE result DTO"
    )
    if _pointer(before, 0) != expected_class:
        raise LayoutValidationError("ChatMessageDTO class pointer mismatch")
    event_type = _optional_string(
        memory, _pointer(before, CHAT_MESSAGE_TYPE_OFFSET), label="message type"
    )
    match_id = _optional_string(
        memory, _pointer(before, CHAT_MESSAGE_MATCH_ID_OFFSET), label="message matchId"
    )
    if event_type not in QTE_RESULT_TYPES or match_id != expected_match_id:
        raise LayoutValidationError("QTE result does not belong to current match")
    presses_pointer = _pointer(before, CHAT_MESSAGE_QTE_PRESSES_OFFSET)
    presses = (
        _read_stable_string_list(memory, presses_pointer, label="result qtePresses")
        if presses_pointer
        else ()
    )
    result = QteResultSnapshot(
        address=address,
        event_type=event_type,
        timestamp=_optional_string(
            memory, _pointer(before, CHAT_MESSAGE_TIMESTAMP_OFFSET), label="timestamp"
        ),
        match_id=match_id,
        skill_card_id=_nullable_i32(
            before, CHAT_MESSAGE_SKILL_CARD_ID_OFFSET, "skillCardId"
        ),
        correct_count=_nullable_i32(
            before, CHAT_MESSAGE_CORRECT_DOT_COUNT_OFFSET, "correctDotCount"
        ),
        timing_result=_optional_string(
            memory,
            _pointer(before, CHAT_MESSAGE_TIMING_RESULT_OFFSET),
            label="timingResult",
            max_length=64,
        ),
        dots_to_destroy=_nullable_i32(
            before, CHAT_MESSAGE_DOTS_TO_DESTROY_OFFSET, "dotsToDestroy"
        ),
        qte_presses=presses,
        qte_elapsed_ms=_nullable_i32(
            before, CHAT_MESSAGE_QTE_ELAPSED_MS_OFFSET, "qteElapsedMs"
        ),
    )
    if _read_exact(
        memory, address, CHAT_MESSAGE_QTE_RESULT_READ_SIZE, "QTE result DTO"
    ) != before:
        raise LayoutValidationError("QTE result DTO changed during read")
    return result


@dataclass(frozen=True)
class QteBindingContext:
    session_key: CombatSessionKey
    local_actor_number: int
    skill_card_id: int
    card_data_address: int
    turn_number: int
    player_mana: int | None = None
    player_power: int | None = None


@dataclass(frozen=True)
class QteGenerationIdentity:
    session_key: CombatSessionKey
    local_actor_number: int
    skill_card_id: int
    turn_number: int
    card_ui_address: int
    server_sequence_list_address: int
    current_arrows_list_address: int
    current_arrow_seed: int
    observer_generation: int


@dataclass(frozen=True)
class BoundQteObservation:
    status: QteBindingStatus
    reason: str
    identity: QteGenerationIdentity | None
    qte: CardUiQteSnapshot | None
    challenge: ServerQteChallengeSnapshot | None
    normalized_sequence: tuple[str, ...] = ()
    predicted_timing_result: str | None = None

    @property
    def current(self) -> bool:
        return self.status in {
            QteBindingStatus.BOUND_CURRENT,
            QteBindingStatus.COMPLETED_CURRENT,
        }


def select_single_qte_candidate(
    candidates: Iterable[CardUiQteSnapshot],
) -> tuple[CardUiQteSnapshot | None, QteBindingStatus | None]:
    values = tuple(candidates)
    if not values:
        return None, QteBindingStatus.QTE_MISSING
    if len(values) != 1:
        return None, QteBindingStatus.AMBIGUOUS_QTE_CANDIDATES
    return values[0], None


class QteSessionTracker:
    """Bind only an inactive→active edge inside one exact combat session."""

    def __init__(self) -> None:
        self._session_key: CombatSessionKey | None = None
        self._saw_inactive = False
        self._generation = 0
        self._identity: QteGenerationIdentity | None = None

    @property
    def identity(self) -> QteGenerationIdentity | None:
        return self._identity

    def invalidate(self) -> None:
        self._session_key = None
        self._saw_inactive = False
        self._identity = None

    def note_inactive(self, session_key: CombatSessionKey) -> None:
        """Record a current-session inactive edge without requiring card identity.

        This is needed before evolution: the source pet has no skill card yet,
        while the absence of ``CardUI.ActiveDotSkillCard`` is still a valid and
        important freshness witness for the later runtime card.
        """

        if self._session_key != session_key:
            self._session_key = session_key
        # A proven null ActiveDotSkillCard is the lifecycle boundary between
        # generations.  Retaining the preceding identity here made the next
        # QTE look like a mutated stale object instead of a fresh generation.
        self._identity = None
        self._saw_inactive = True

    def observe(
        self,
        context: QteBindingContext,
        candidates: Iterable[CardUiQteSnapshot],
        challenge: ServerQteChallengeSnapshot | None,
        *,
        element_type: str | None,
    ) -> BoundQteObservation:
        values = tuple(candidates)
        if self._session_key != context.session_key:
            self._session_key = context.session_key
            self._saw_inactive = not values or all(not value.active for value in values)
            self._identity = None

        qte, selection_error = select_single_qte_candidate(values)
        if selection_error is QteBindingStatus.AMBIGUOUS_QTE_CANDIDATES:
            self._identity = None
            return BoundQteObservation(
                selection_error, "more than one current QTE candidate", None, None, challenge
            )
        if qte is None or not qte.active:
            self._saw_inactive = True
            self._identity = None
            return BoundQteObservation(
                QteBindingStatus.INACTIVE,
                "current session has an inactive QTE baseline",
                None,
                qte,
                challenge,
            )
        if not self._saw_inactive:
            return BoundQteObservation(
                QteBindingStatus.UNBOUND_MIDSTREAM,
                "active QTE was first observed without a current-session inactive baseline",
                None,
                qte,
                challenge,
            )
        if (
            qte.board_instance != context.session_key.board_instance
            or qte.actor_number != context.local_actor_number
        ):
            return BoundQteObservation(
                QteBindingStatus.WRONG_OWNER,
                "QTE Board/actor does not match current combat ownership",
                None,
                qte,
                challenge,
            )
        if qte.card_data_address != context.card_data_address:
            return BoundQteObservation(
                QteBindingStatus.WRONG_CARD,
                "QTE CardData does not equal the current pet skill card",
                None,
                qte,
                challenge,
            )
        if challenge is None or challenge.match_id != context.session_key.match_id:
            return BoundQteObservation(
                QteBindingStatus.WRONG_SESSION,
                "server QTE challenge is absent or belongs to another MatchId",
                None,
                qte,
                challenge,
            )
        if not challenge.raw_sequence:
            return BoundQteObservation(
                QteBindingStatus.SEQUENCE_UNAVAILABLE,
                "current server challenge has no direction sequence",
                None,
                qte,
                challenge,
            )
        if not challenge.sequence_known:
            return BoundQteObservation(
                QteBindingStatus.UNKNOWN_DIRECTION,
                "server challenge contains an unrecognized direction",
                None,
                qte,
                challenge,
            )
        sequence = tuple(value for value in challenge.normalized_sequence if value)
        if qte.current_arrow_count is None or qte.current_arrow_count != len(sequence):
            return BoundQteObservation(
                QteBindingStatus.SEQUENCE_UNAVAILABLE,
                "currentArrows count does not attest the server sequence length",
                None,
                qte,
                challenge,
                sequence,
            )
        if not 0 <= qte.current_index <= len(sequence) or qte.correct_count > 64:
            return BoundQteObservation(
                QteBindingStatus.INVALID_PROGRESS,
                "QTE currentIndex/correctCount is outside validated bounds",
                None,
                qte,
                challenge,
            )
        if not challenge.window.valid or not qte.timing_window_valid:
            return BoundQteObservation(
                QteBindingStatus.INVALID_TIMING,
                "QTE Perfect interval is absent or inverted",
                None,
                qte,
                challenge,
                sequence,
            )
        server_seconds = tuple(
            value / 1000.0
            for value in (
                challenge.window.duration_ms,
                challenge.window.perfect_start_ms,
                challenge.window.perfect_end_ms,
                challenge.window.good_start_1_ms,
                challenge.window.good_end_1_ms,
                challenge.window.good_start_2_ms,
                challenge.window.good_end_2_ms,
            )
        )
        card_ui_seconds = (
            qte.duration_seconds,
            qte.perfect_start_seconds,
            qte.perfect_end_seconds,
            qte.good_start_1_seconds,
            qte.good_end_1_seconds,
            qte.good_start_2_seconds,
            qte.good_end_2_seconds,
        )
        if any(
            abs(server - current) > 0.002
            for server, current in zip(server_seconds, card_ui_seconds)
        ):
            return BoundQteObservation(
                QteBindingStatus.INVALID_TIMING,
                "CardUI timing window does not equal the current server window",
                None,
                qte,
                challenge,
                sequence,
            )
        if self._identity is None:
            self._generation += 1
            self._identity = QteGenerationIdentity(
                session_key=context.session_key,
                local_actor_number=context.local_actor_number,
                skill_card_id=context.skill_card_id,
                turn_number=context.turn_number,
                card_ui_address=qte.address,
                server_sequence_list_address=challenge.sequence_list_address or 0,
                current_arrows_list_address=qte.current_arrows_list_address or 0,
                current_arrow_seed=qte.current_arrow_seed,
                observer_generation=self._generation,
            )
        elif (
            self._identity.card_ui_address != qte.address
            or self._identity.server_sequence_list_address
            != (challenge.sequence_list_address or 0)
            or self._identity.current_arrows_list_address
            != (qte.current_arrows_list_address or 0)
            or self._identity.skill_card_id != context.skill_card_id
        ):
            stale = self._identity
            self._identity = None
            return BoundQteObservation(
                QteBindingStatus.STALE_OR_CHANGED_QTE,
                f"QTE identity changed after bind (old generation {stale.observer_generation})",
                None,
                qte,
                challenge,
                sequence,
            )
        result = classify_qte_timing(
            element_type=element_type,
            correct_count=qte.correct_count,
            elapsed_seconds=qte.elapsed_seconds,
            perfect_start_seconds=qte.perfect_start_seconds,
            perfect_end_seconds=qte.perfect_end_seconds,
            good_start_1_seconds=qte.good_start_1_seconds,
            good_end_1_seconds=qte.good_end_1_seconds,
            good_start_2_seconds=qte.good_start_2_seconds,
            good_end_2_seconds=qte.good_end_2_seconds,
        )
        status = (
            QteBindingStatus.COMPLETED_CURRENT
            if qte.finished
            else QteBindingStatus.BOUND_CURRENT
        )
        return BoundQteObservation(
            status,
            "inactive edge, current ownership, card and server challenge agree",
            self._identity,
            qte,
            challenge,
            sequence,
            result,
        )


def correlate_qte_result(
    observation: BoundQteObservation,
    result: QteResultSnapshot,
) -> bool:
    """Exact current-result correlation; never match an old MatchId/card/presses."""

    identity = observation.identity
    qte = observation.qte
    if identity is None or qte is None or not observation.current:
        return False
    if (
        result.match_id != identity.session_key.match_id
        or result.skill_card_id != identity.skill_card_id
        or result.correct_count != qte.correct_count
        or result.qte_elapsed_ms != qte.qte_elapsed_ms
        or result.qte_presses != qte.qte_presses
    ):
        return False
    return result.timing_result == observation.predicted_timing_result
