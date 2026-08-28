"""Read-only Chinh Phuc map target proof and normal-input badge locator.

The game can occasionally return a completed Chinh Phuc match to the island
map instead of the selected ``ManagerRoom``.  The runtime half of this module
associates the configured pet ID with the exact map ``Button`` by walking the
button's ordinary UnityEvent listener graph.  The visual half locates the
runtime-derived hunt-order badge; pixels never decide boss identity.

No game method is called and no target memory or PlayerPrefs value is written.
"""

from __future__ import annotations

from dataclasses import dataclass, field
import os
import struct
from typing import Iterable

from .boss_lobby_runtime import (
    MANAGER_ROOM_BUTTON_START_OFFSET,
    MANAGER_ROOM_TYPE_INFO_RVA,
    SELECTABLE_GROUPS_ALLOW_INTERACTION_OFFSET,
    SELECTABLE_INTERACTABLE_OFFSET,
    UNITY_OBJECT_CACHED_PTR_OFFSET,
    _read_managed_list,
    _static_instance,
)
from .il2cpp_external import ExternalReadError, is_canonical_user_pointer
from .il2cpp_layout import LayoutValidationError, read_il2cpp_string, read_reference_array
from .memory_scan import bounded_private_writable_regions, scan_aligned_qwords


# ManagerChinhPhuc / GroupDTO / PetEnemyDTO, verified in DiffableCs.
MANAGER_CHINH_PHUC_CACHED_DATA_OFFSET = 0x98
GROUP_ID_OFFSET = 0x10
GROUP_NAME_OFFSET = 0x18
GROUP_PETS_OFFSET = 0x20
PET_ID_OFFSET = 0x10
PET_NAME_OFFSET = 0x18
PET_LOCKED_OFFSET = 0x35

# UnityEngine.UI.Button -> ButtonClickedEvent -> runtime UnityAction closure.
BUTTON_ON_CLICK_OFFSET = 0x100
UNITY_EVENT_CALLS_OFFSET = 0x10
INVOKABLE_RUNTIME_CALLS_OFFSET = 0x18
INVOKABLE_DELEGATE_OFFSET = 0x10
DELEGATE_TARGET_OFFSET = 0x20

# ManagerChinhPhuc.<>c__DisplayClass38_0, proven by DiffableCs/ISIL.
PET_CLICK_LOCKED_OFFSET = 0x10
PET_CLICK_LOCKED_ORDER_OFFSET = 0x14
PET_CLICK_REQUIRED_ATTACK_OFFSET = 0x18
PET_CLICK_PET_ID_OFFSET = 0x1C
PET_CLICK_REQUIRED_ATTACK_TEXT_OFFSET = 0x20
PET_CLICK_MANAGER_OFFSET = 0x28

PLAYER_PREFS_PATH = r"Software\Pokiguard\PokiguardOnlines"


@dataclass(frozen=True)
class ChinhPhucPlayerPrefs:
    selected_pet_id: int | None
    selected_group_index: int | None
    active_panel_index: int | None
    return_panel_index: int | None
    source: str
    reasons: tuple[str, ...] = ()


@dataclass(frozen=True)
class ChinhPhucMapTarget:
    pet_id: int
    pet_name: str
    group_id: int
    group_name: str
    group_index: int
    pet_index: int
    hunt_order: int
    button_address: int
    button_native: int
    manager_address: int
    locked: bool
    locked_order: int
    required_attack: int
    required_attack_text: str | None
    prefs: ChinhPhucPlayerPrefs
    clean: bool
    reasons: tuple[str, ...]
    scan_regions: int
    scan_bytes: int
    button_class_hits: int

    @property
    def selection_required(self) -> bool:
        """Whether the exact runtime-proven target differs from the saved pet."""

        return self.prefs.selected_pet_id != self.pet_id


@dataclass(frozen=True)
class HuntBadgeCandidate:
    normalized_point: tuple[float, float]
    normalized_rect: tuple[float, float, float, float]
    digit_score: int
    digit_margin: int
    radial_score: int
    confidence: float


@dataclass(frozen=True)
class HuntBadgeLocation:
    found: bool
    hunt_order: int
    normalized_point: tuple[float, float] | None
    normalized_rect: tuple[float, float, float, float] | None
    confidence: float
    reason: str
    candidates: tuple[HuntBadgeCandidate, ...] = ()
    metrics: dict[str, int | float | str] = field(default_factory=dict)


def _read_pointer(resolver: object, address: int) -> int | None:
    value = resolver.read_pointer(address)
    if not value or not is_canonical_user_pointer(value):
        return None
    return value


def _read_string_pointer(resolver: object, address: int) -> str | None:
    pointer = _read_pointer(resolver, address)
    if pointer is None:
        return None
    value = read_il2cpp_string(resolver.memory, pointer, max_length=256)
    return value or None


def _prefixed_dword(values: Iterable[tuple[str, object]], prefix: str) -> int | None:
    matches: list[int] = []
    for name, value in values:
        if name == prefix or name.startswith(prefix + "_h"):
            if isinstance(value, int):
                matches.append(value & 0xFFFFFFFF)
    return matches[0] if len(set(matches)) == 1 else None


def read_chinh_phuc_player_prefs() -> ChinhPhucPlayerPrefs:
    """Read only the PlayerPrefs keys evidenced by ManagerQuangTruong ISIL."""

    if os.name != "nt":
        return ChinhPhucPlayerPrefs(None, None, None, None, PLAYER_PREFS_PATH, ("not Windows",))
    import winreg  # Windows-only stdlib

    reasons: list[str] = []
    try:
        with winreg.OpenKey(winreg.HKEY_CURRENT_USER, PLAYER_PREFS_PATH, 0, winreg.KEY_READ) as key:
            values: list[tuple[str, object]] = []
            index = 0
            while True:
                try:
                    name, value, _kind = winreg.EnumValue(key, index)
                except OSError:
                    break
                values.append((name, value))
                index += 1
    except OSError as exc:
        return ChinhPhucPlayerPrefs(
            None,
            None,
            None,
            None,
            PLAYER_PREFS_PATH,
            (f"PlayerPrefs read failed: {exc}",),
        )

    selected_pet = _prefixed_dword(values, "SelectedPetId")
    selected_group = _prefixed_dword(values, "SelectedGroupIndex")
    active_panel = _prefixed_dword(values, "ActivePanelIndex")
    return_panel = _prefixed_dword(values, "ReturnToPanelIndex")
    if selected_pet is None:
        reasons.append("SelectedPetId unavailable or ambiguous")
    if selected_group is None:
        reasons.append("SelectedGroupIndex unavailable or ambiguous")
    if active_panel is None:
        reasons.append("ActivePanelIndex unavailable or ambiguous")
    if return_panel == 0xFFFFFFFF:
        return_panel = None
    return ChinhPhucPlayerPrefs(
        selected_pet,
        selected_group,
        active_panel,
        return_panel,
        PLAYER_PREFS_PATH,
        tuple(reasons),
    )


def _find_pet_in_cached_groups(
    resolver: object,
    manager: int,
    target_pet_id: int,
) -> tuple[int, int, int, str, str, bool] | None:
    cached = _read_pointer(resolver, manager + MANAGER_CHINH_PHUC_CACHED_DATA_OFFSET)
    if cached is None:
        return None
    groups = _read_managed_list(resolver, cached, max_items=64)
    matches: list[tuple[int, int, int, str, str, bool]] = []
    for group_index, group in enumerate(groups):
        if not group or not resolver.memory.is_readable(group, 0x28):
            continue
        group_id = resolver.read_i32(group + GROUP_ID_OFFSET)
        group_name = _read_string_pointer(resolver, group + GROUP_NAME_OFFSET) or ""
        pets_array = _read_pointer(resolver, group + GROUP_PETS_OFFSET)
        if pets_array is None:
            continue
        pets = read_reference_array(resolver.memory, pets_array, max_length=256)
        for pet_index, pet in enumerate(pets):
            if not pet or not resolver.memory.is_readable(pet, 0x36):
                continue
            if resolver.read_i32(pet + PET_ID_OFFSET) != target_pet_id:
                continue
            pet_name = _read_string_pointer(resolver, pet + PET_NAME_OFFSET) or ""
            locked = resolver.read_bool(pet + PET_LOCKED_OFFSET)
            matches.append(
                (group_index, pet_index, group_id, group_name, pet_name, locked)
            )
    return matches[0] if len(matches) == 1 else None


def discover_chinh_phuc_map_target(
    target: object,
    target_pet_id: int,
    *,
    max_region_mib: int = 8,
    chunk_mib: int = 2,
) -> ChinhPhucMapTarget | None:
    """Resolve one exact pet map Button from read-only managed-object evidence."""

    if target_pet_id <= 0:
        raise ValueError("target_pet_id must be positive")
    resolver = target.resolver
    manager_room = _static_instance(resolver, MANAGER_ROOM_TYPE_INFO_RVA, size=0x150)
    if manager_room is None:
        return None
    start_button = _read_pointer(resolver, manager_room + MANAGER_ROOM_BUTTON_START_OFFSET)
    if start_button is None:
        return None
    button_class = _read_pointer(resolver, start_button)
    if button_class is None:
        return None

    regions = bounded_private_writable_regions(
        target.memory.iter_readable_regions(),
        max_region_size=max_region_mib * 1024 * 1024,
    )
    scan = scan_aligned_qwords(
        target.memory,
        regions,
        {"button_class": button_class},
        chunk_size=chunk_mib * 1024 * 1024,
        max_matches_per_needle=10_000,
    )
    exact: list[tuple[int, int, int, int, int, str | None, int]] = []
    for button in scan.matches["button_class"]:
        try:
            on_click = _read_pointer(resolver, button + BUTTON_ON_CLICK_OFFSET)
            calls = (
                _read_pointer(resolver, on_click + UNITY_EVENT_CALLS_OFFSET)
                if on_click is not None
                else None
            )
            runtime_calls = (
                _read_pointer(resolver, calls + INVOKABLE_RUNTIME_CALLS_OFFSET)
                if calls is not None
                else None
            )
            if runtime_calls is None:
                continue
            for invokable in _read_managed_list(resolver, runtime_calls, max_items=32):
                delegate = _read_pointer(resolver, invokable + INVOKABLE_DELEGATE_OFFSET)
                closure = (
                    _read_pointer(resolver, delegate + DELEGATE_TARGET_OFFSET)
                    if delegate is not None
                    else None
                )
                if closure is None or not resolver.memory.is_readable(closure, 0x30):
                    continue
                raw = resolver.memory.read(closure, 0x30)
                pet_id = struct.unpack_from("<i", raw, PET_CLICK_PET_ID_OFFSET)[0]
                if pet_id != target_pet_id:
                    continue
                locked = raw[PET_CLICK_LOCKED_OFFSET]
                locked_order = struct.unpack_from("<i", raw, PET_CLICK_LOCKED_ORDER_OFFSET)[0]
                required_attack = struct.unpack_from(
                    "<i", raw, PET_CLICK_REQUIRED_ATTACK_OFFSET
                )[0]
                text_pointer = struct.unpack_from(
                    "<Q", raw, PET_CLICK_REQUIRED_ATTACK_TEXT_OFFSET
                )[0]
                manager = struct.unpack_from("<Q", raw, PET_CLICK_MANAGER_OFFSET)[0]
                if (
                    locked not in (0, 1)
                    or not is_canonical_user_pointer(manager)
                    or not resolver.memory.is_readable(manager, 0xC0)
                ):
                    continue
                native = _read_pointer(resolver, button + UNITY_OBJECT_CACHED_PTR_OFFSET)
                if native is None or not resolver.memory.is_readable(native, 1):
                    continue
                interactable = resolver.read_bool(button + SELECTABLE_INTERACTABLE_OFFSET)
                groups_allow = resolver.read_bool(
                    button + SELECTABLE_GROUPS_ALLOW_INTERACTION_OFFSET
                )
                if not interactable or not groups_allow:
                    continue
                required_text = None
                if text_pointer and is_canonical_user_pointer(text_pointer):
                    required_text = read_il2cpp_string(
                        resolver.memory, text_pointer, max_length=64
                    ) or None
                exact.append(
                    (
                        button,
                        native,
                        manager,
                        locked_order,
                        required_attack,
                        required_text,
                        locked,
                    )
                )
        except (ExternalReadError, LayoutValidationError, OSError, ValueError):
            continue
    unique = {item[0]: item for item in exact}
    if len(unique) != 1:
        return None
    button, native, manager, locked_order, required_attack, required_text, locked_raw = next(
        iter(unique.values())
    )
    try:
        pet = _find_pet_in_cached_groups(resolver, manager, target_pet_id)
    except (ExternalReadError, LayoutValidationError, OSError, ValueError):
        return None
    if pet is None:
        return None
    group_index, pet_index, group_id, group_name, pet_name, dto_locked = pet
    prefs = read_chinh_phuc_player_prefs()
    reasons = list(prefs.reasons)
    # A different SelectedPetId is the normal reason this exact target button
    # needs to be clicked. It is informational, not a broken association.
    # PlayerPrefs availability/ambiguity remains fail-closed through
    # ``prefs.reasons`` and the group/panel checks below.
    if prefs.selected_group_index != group_index:
        reasons.append("SelectedGroupIndex does not match target cached-data group")
    if prefs.active_panel_index != group_index:
        reasons.append("ActivePanelIndex does not match target cached-data group")
    if prefs.return_panel_index is not None and prefs.return_panel_index != group_index:
        reasons.append("ReturnToPanelIndex does not match target cached-data group")
    if bool(locked_raw) != dto_locked:
        reasons.append("click closure and PetEnemyDTO locked state disagree")
    if locked_raw:
        reasons.append("target pet is locked")
    return ChinhPhucMapTarget(
        target_pet_id,
        pet_name,
        group_id,
        group_name,
        group_index,
        pet_index,
        pet_index + 1,
        button,
        native,
        manager,
        bool(locked_raw),
        locked_order,
        required_attack,
        required_text,
        prefs,
        not reasons,
        tuple(reasons),
        scan.regions_visited,
        scan.bytes_read,
        len(scan.matches["button_class"]),
    )


# Binary bright-pixel templates of the game's ``number_A_*`` sprites after an
# 8x12 normalization.  They classify the displayed hunt-order badge only;
# target identity and panel ownership are independently proved above.
_DIGIT_ROWS: dict[int, tuple[str, ...]] = {
    2: ("...#####", "..#.#..#", "..#.##.#", "..##.#.#", "..###.#.", "....###.", "...###..", "..###...", "..###...", ".#####..", "######..", "######.."),
    3: ("..######", "..#.##.#", "..####.#", ".#####.#", "..###..#", "...####.", "...####.", ".######.", ".##.###.", "#######.", "#######.", "######.."),
    4: (".....###", ".....#.#", "....#.#.", "...#.##.", "...#.###", "..######", ".#######", ".#######", "########", "########", "#######.", "...####."),
    5: ("..######", "..#....#", "..######", ".###....", ".#.####.", ".######.", ".######.", ".##.###.", "###.###.", "#######.", "#######.", "######.."),
    6: ("...#####", "..#....#", "..#.##.#", "..##.#.#", ".#.#.##.", ".######.", ".######.", ".######.", ".##.###.", "#######.", "#######.", "######.."),
    7: (".#######", ".#.....#", ".#.##..#", "#####.#.", ".###..#.", "...#.#..", "..####..", "..###...", ".####...", ".###....", "####....", "###....."),
    8: ("...#####", "..#....#", "..####.#", ".###.#.#", ".#.###.#", ".######.", ".######.", ".######.", ".##.###.", "#######.", "#######.", "######.."),
    9: ("..######", "..#....#", ".#.###.#", ".#.#.#.#", ".#.#####", ".######.", ".######.", ".######.", "#######.", "#######.", "######..", "######.."),
}
_DIGIT_BITS = {
    digit: tuple(character == "#" for row in rows for character in row)
    for digit, rows in _DIGIT_ROWS.items()
}

# Unity rasterizes the same number_A_8 sprite differently at the canonical
# 1280x720 client used by the desktop UI than in the earlier 1280x710 live
# calibration.  Keep both evidence-backed variants; target identity still
# comes from the read-only Button closure and cached PetEnemyDTO, never pixels.
_DIGIT_8_1280X720_ROWS = (
    "...#####",
    "..#....#",
    "..####.#",
    "..##.#.#",
    ".#.#.###",
    ".##.#.#.",
    ".######.",
    ".######.",
    "###.###.",
    "###.###.",
    "#######.",
    "######..",
)
_DIGIT_VARIANTS = {
    digit: (
        bits,
        *(
            (
                tuple(
                    character == "#"
                    for row in _DIGIT_8_1280X720_ROWS
                    for character in row
                ),
            )
            if digit == 8
            else ()
        ),
    )
    for digit, bits in _DIGIT_BITS.items()
}


def _pixel(rgb: bytes, width: int, x: int, y: int) -> tuple[int, int, int]:
    offset = (y * width + x) * 3
    return rgb[offset], rgb[offset + 1], rgb[offset + 2]


def _badge_brown(pixel: tuple[int, int, int]) -> bool:
    red, green, blue = pixel
    return 25 <= red <= 150 and 4 <= green <= 85 and blue <= 35 and red > green


def _digit_bright(pixel: tuple[int, int, int]) -> bool:
    red, green, blue = pixel
    return red > 180 and green > 75 and blue < 100 and red * 10 > green * 11


def _digit_feature(
    rgb: bytes,
    width: int,
    height: int,
    center_x: int,
    center_y: int,
    scale: float,
) -> tuple[tuple[bool, ...], tuple[int, int, int, int], int] | None:
    half_width = max(18, round(22 * scale))
    half_height = max(21, round(25 * scale))
    points: list[tuple[int, int]] = []
    for y in range(max(0, center_y - half_height), min(height, center_y + half_height + 1)):
        for x in range(max(0, center_x - half_width), min(width, center_x + half_width + 1)):
            if _digit_bright(_pixel(rgb, width, x, y)):
                points.append((x, y))
    if len(points) < max(60, round(100 * scale * scale)):
        return None
    left = min(point[0] for point in points)
    right = max(point[0] for point in points)
    top = min(point[1] for point in points)
    bottom = max(point[1] for point in points)
    box_width = right - left + 1
    box_height = bottom - top + 1
    if not (
        max(9, round(12 * scale)) <= box_width <= round(30 * scale) + 4
        and max(18, round(24 * scale)) <= box_height <= round(38 * scale) + 4
    ):
        return None
    feature: list[bool] = []
    for grid_y in range(12):
        y0 = top + box_height * grid_y // 12
        y1 = top + box_height * (grid_y + 1) // 12
        for grid_x in range(8):
            x0 = left + box_width * grid_x // 8
            x1 = left + box_width * (grid_x + 1) // 8
            total = max(1, (x1 - x0) * (y1 - y0))
            bright = sum(
                _digit_bright(_pixel(rgb, width, x, y))
                for y in range(y0, y1)
                for x in range(x0, x1)
            )
            feature.append(bright / total >= 0.25)
    return tuple(feature), (left, top, right, bottom), len(points)


def locate_hunt_order_badge(
    rgb: bytes,
    width: int,
    height: int,
    hunt_order: int,
) -> HuntBadgeLocation:
    """Locate one visible single-digit badge from a runtime-derived order."""

    if width < 640 or height < 360 or len(rgb) != width * height * 3:
        return HuntBadgeLocation(False, hunt_order, None, None, 0.0, "invalid_client_capture")
    if hunt_order not in _DIGIT_BITS:
        return HuntBadgeLocation(
            False,
            hunt_order,
            None,
            None,
            0.0,
            "hunt_order_visual_template_unsupported",
            metrics={"supportedMinimum": 2, "supportedMaximum": 9},
        )
    scale = min(width / 1280.0, height / 710.0)
    step = max(1, round(2 * scale))
    offsets = tuple(
        (round(dx * scale), round(dy * scale))
        for dx, dy in (
            (-20, 0),
            (20, 0),
            (0, -20),
            (0, 20),
            (-14, -14),
            (14, -14),
            (-14, 14),
            (14, 14),
        )
    )
    raw_candidates: list[tuple[int, int, int]] = []
    margin = max(abs(value) for offset in offsets for value in offset) + 2
    for y in range(max(margin, round(height * 0.10)), height - margin, step):
        for x in range(margin, width - margin, step):
            radial = sum(
                _badge_brown(_pixel(rgb, width, x + dx, y + dy))
                for dx, dy in offsets
            )
            if radial >= 7:
                raw_candidates.append((radial, x, y))

    centers: list[tuple[int, int, int]] = []
    minimum_distance = max(20, round(30 * scale))
    for radial, x, y in sorted(raw_candidates, key=lambda item: (-item[0], item[2], item[1])):
        if any(
            (x - existing_x) ** 2 + (y - existing_y) ** 2 < minimum_distance**2
            for _score, existing_x, existing_y in centers
        ):
            continue
        centers.append((radial, x, y))

    accepted: list[HuntBadgeCandidate] = []
    for radial, x, y in centers:
        feature = _digit_feature(rgb, width, height, x, y, scale)
        if feature is None:
            continue
        bits, bounds, _bright_count = feature
        scores = sorted(
            (
                min(
                    sum(left != right for left, right in zip(bits, template))
                    for template in templates
                ),
                digit,
            )
            for digit, templates in _DIGIT_VARIANTS.items()
        )
        best_score, best_digit = scores[0]
        target_score = next(score for score, digit in scores if digit == hunt_order)
        next_score = min(score for score, digit in scores if digit != hunt_order)
        digit_margin = next_score - target_score
        if best_digit != hunt_order or target_score > 8 or digit_margin < 3:
            continue
        left, top, right, bottom = bounds
        center_x = (left + right) / 2
        center_y = (top + bottom) / 2
        radius = max(20, round(27 * scale))
        rect = (
            max(0.0, (center_x - radius) / width),
            max(0.0, (center_y - radius) / height),
            min(1.0, (center_x + radius) / width),
            min(1.0, (center_y + radius) / height),
        )
        confidence = min(
            0.99,
            0.90
            + 0.01 * min(5, digit_margin)
            + 0.005 * max(0, radial - 7)
            - 0.01 * target_score,
        )
        accepted.append(
            HuntBadgeCandidate(
                (center_x / width, center_y / height),
                rect,
                target_score,
                digit_margin,
                radial,
                confidence,
            )
        )
    accepted = sorted(
        accepted,
        key=lambda candidate: (
            candidate.digit_score,
            -candidate.digit_margin,
            candidate.normalized_point,
        ),
    )
    if len(accepted) != 1:
        return HuntBadgeLocation(
            False,
            hunt_order,
            None,
            None,
            0.0,
            "hunt_order_badge_missing" if not accepted else "hunt_order_badge_ambiguous",
            tuple(accepted),
            {
                "rawRadialCandidates": len(raw_candidates),
                "clusteredCenters": len(centers),
                "acceptedCandidates": len(accepted),
            },
        )
    candidate = accepted[0]
    return HuntBadgeLocation(
        True,
        hunt_order,
        candidate.normalized_point,
        candidate.normalized_rect,
        candidate.confidence,
        "single_runtime_derived_hunt_order_badge",
        (candidate,),
        {
            "rawRadialCandidates": len(raw_candidates),
            "clusteredCenters": len(centers),
            "acceptedCandidates": 1,
            "digitScore": candidate.digit_score,
            "digitMargin": candidate.digit_margin,
        },
    )


__all__ = [
    "ChinhPhucMapTarget",
    "ChinhPhucPlayerPrefs",
    "HuntBadgeCandidate",
    "HuntBadgeLocation",
    "discover_chinh_phuc_map_target",
    "locate_hunt_order_badge",
    "read_chinh_phuc_player_prefs",
]
