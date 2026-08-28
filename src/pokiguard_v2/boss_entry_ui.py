"""Resolution-independent visual proof for the ChinhPhuc Start control.

Boss identity never comes from pixels.  This locator is used only after the
read-only runtime graph has proven the selected room/target association.
"""

from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum


class BossEntryControl(str, Enum):
    CHINH_PHUC_START = "CHINH_PHUC_START"
    CHINH_PHUC_ROOM_SHELL_EXIT = "CHINH_PHUC_ROOM_SHELL_EXIT"
    CHINH_PHUC_ATTACK_CARD_TOGGLE = "CHINH_PHUC_ATTACK_CARD_TOGGLE"


@dataclass(frozen=True)
class EntryButtonCandidate:
    normalized_rect: tuple[float, float, float, float]
    normalized_point: tuple[float, float]
    cyan_pixels: int
    warm_or_white_pixels: int
    confidence: float


@dataclass(frozen=True)
class EntryUiLocation:
    control: BossEntryControl
    found: bool
    normalized_point: tuple[float, float] | None
    normalized_rect: tuple[float, float, float, float] | None
    confidence: float
    reason: str
    candidates: tuple[EntryButtonCandidate, ...] = ()
    metrics: dict[str, float | int | str] = field(default_factory=dict)


def _pixel(rgb: bytes, width: int, x: int, y: int) -> tuple[int, int, int]:
    offset = (y * width + x) * 3
    return rgb[offset], rgb[offset + 1], rgb[offset + 2]


def _cyan(r: int, g: int, b: int) -> bool:
    return g >= 180 and b >= 200 and r <= 150 and b >= r + 45


def _warm_or_white(r: int, g: int, b: int) -> bool:
    white = r >= 220 and g >= 220 and b >= 205
    warm = r >= 220 and 85 <= g <= 215 and b <= 150 and r >= g + 20
    return white or warm


def find_chinh_phuc_start_candidates(
    rgb: bytes,
    width: int,
    height: int,
) -> tuple[EntryButtonCandidate, ...]:
    """Return every lower-center cyan Start-button candidate.

    The ornamental border is fragmented, so pixels are grouped on a
    resolution-scaled coarse grid and dilated by one grid cell.  Candidate
    coordinates always come from the observed pixels, never a fixed click.
    """

    if width < 640 or height < 360 or len(rgb) != width * height * 3:
        return ()
    x0, x1 = round(width * 0.40), round(width * 0.86)
    y0, y1 = round(height * 0.745), round(height * 0.91)
    cell = max(3, round(min(width, height) / 180))
    counts: dict[tuple[int, int], int] = {}
    for y in range(y0, y1):
        for x in range(x0, x1):
            if _cyan(*_pixel(rgb, width, x, y)):
                key = (x // cell, y // cell)
                counts[key] = counts.get(key, 0) + 1
    minimum_cell_pixels = max(2, cell)
    occupied = {
        key for key, count in counts.items() if count >= minimum_cell_pixels
    }
    expanded: set[tuple[int, int]] = set()
    for gx, gy in occupied:
        for dx in (-1, 0, 1):
            for dy in (-1, 0, 1):
                expanded.add((gx + dx, gy + dy))

    groups: list[set[tuple[int, int]]] = []
    while expanded:
        seed = expanded.pop()
        group = {seed}
        stack = [seed]
        while stack:
            gx, gy = stack.pop()
            for adjacent in (
                (gx - 1, gy),
                (gx + 1, gy),
                (gx, gy - 1),
                (gx, gy + 1),
            ):
                if adjacent in expanded:
                    expanded.remove(adjacent)
                    group.add(adjacent)
                    stack.append(adjacent)
        groups.append(group)

    candidates: list[EntryButtonCandidate] = []
    for group in groups:
        source_cells = occupied.intersection(group)
        if not source_cells:
            continue
        gx_values = [value[0] for value in source_cells]
        gy_values = [value[1] for value in source_cells]
        left = max(x0, min(gx_values) * cell)
        top = max(y0, min(gy_values) * cell)
        right = min(x1, (max(gx_values) + 1) * cell)
        bottom = min(y1, (max(gy_values) + 1) * cell)
        normalized = (left / width, top / height, right / width, bottom / height)
        span_x = normalized[2] - normalized[0]
        span_y = normalized[3] - normalized[1]
        center = (
            (normalized[0] + normalized[2]) / 2,
            (normalized[1] + normalized[3]) / 2,
        )
        if not (
            0.10 <= span_x <= 0.33
            and 0.055 <= span_y <= 0.17
            and 0.52 <= center[0] <= 0.76
            and 0.785 <= center[1] <= 0.855
        ):
            continue
        cyan_pixels = sum(counts[key] for key in source_cells)
        warm_or_white = 0
        for y in range(top, bottom):
            for x in range(left, right):
                if _warm_or_white(*_pixel(rgb, width, x, y)):
                    warm_or_white += 1
        minimum_cyan = max(160, round(width * height * 0.00045))
        minimum_text = max(50, round(width * height * 0.00010))
        if cyan_pixels < minimum_cyan or warm_or_white < minimum_text:
            continue
        anchor_error = abs(center[0] - 0.645) + abs(center[1] - 0.82)
        confidence = min(
            0.99,
            0.82
            + min(0.09, cyan_pixels / max(1, width * height) * 25)
            + min(0.06, warm_or_white / max(1, width * height) * 35)
            - min(0.10, anchor_error * 0.40),
        )
        candidates.append(
            EntryButtonCandidate(
                normalized,
                center,
                cyan_pixels,
                warm_or_white,
                confidence,
            )
        )
    return tuple(
        sorted(
            candidates,
            key=lambda candidate: (
                candidate.normalized_point[0],
                candidate.normalized_point[1],
            ),
        )
    )


def locate_chinh_phuc_start(
    rgb: bytes,
    width: int,
    height: int,
) -> EntryUiLocation:
    candidates = find_chinh_phuc_start_candidates(rgb, width, height)
    if not candidates:
        return EntryUiLocation(
            BossEntryControl.CHINH_PHUC_START,
            False,
            None,
            None,
            0.0,
            "start_button_missing",
            (),
            {"candidateCount": 0},
        )
    if len(candidates) != 1:
        return EntryUiLocation(
            BossEntryControl.CHINH_PHUC_START,
            False,
            None,
            None,
            0.0,
            "start_button_ambiguous",
            candidates,
            {"candidateCount": len(candidates)},
        )
    candidate = candidates[0]
    return EntryUiLocation(
        BossEntryControl.CHINH_PHUC_START,
        True,
        candidate.normalized_point,
        candidate.normalized_rect,
        candidate.confidence,
        "single_lower_center_cyan_start_control",
        candidates,
        {
            "candidateCount": 1,
            "cyanPixels": candidate.cyan_pixels,
            "warmOrWhitePixels": candidate.warm_or_white_pixels,
        },
    )


def _cyan_components(
    rgb: bytes,
    width: int,
    height: int,
    box: tuple[float, float, float, float],
) -> tuple[tuple[int, int, int, int, int], ...]:
    """Return four-connected cyan components inside one bounded ROI."""

    x0, x1 = round(width * box[0]), round(width * box[2])
    y0, y1 = round(height * box[1]), round(height * box[3])
    points: set[tuple[int, int]] = set()
    for y in range(y0, y1):
        for x in range(x0, x1):
            red, green, blue = _pixel(rgb, width, x, y)
            if green >= 150 and blue >= 180 and blue >= red + 20:
                points.add((x, y))
    components: list[tuple[int, int, int, int, int]] = []
    while points:
        seed = points.pop()
        stack = [seed]
        left = right = seed[0]
        top = bottom = seed[1]
        count = 0
        while stack:
            x, y = stack.pop()
            count += 1
            left, right = min(left, x), max(right, x)
            top, bottom = min(top, y), max(bottom, y)
            for neighbour in ((x - 1, y), (x + 1, y), (x, y - 1), (x, y + 1)):
                if neighbour in points:
                    points.remove(neighbour)
                    stack.append(neighbour)
        components.append((left, top, right + 1, bottom + 1, count))
    return tuple(sorted(components, key=lambda item: item[4], reverse=True))


def locate_detached_chinh_phuc_room_shell_exit(
    rgb: bytes,
    width: int,
    height: int,
) -> EntryUiLocation:
    """Locate the normal close control of a detached Chinh Phuc room shell.

    The circular ``X`` also exists on the real island map, so it is never
    sufficient by itself.  This proof first requires the unique lower-room
    cyan Start/Ready control, then locates one cyan circular close control in
    the top-left ROI with a substantial white cross/highlight.  Runtime room
    ownership and target identity are checked separately by ``farm_run``.
    """

    start = locate_chinh_phuc_start(rgb, width, height)
    if not start.found:
        return EntryUiLocation(
            BossEntryControl.CHINH_PHUC_ROOM_SHELL_EXIT,
            False,
            None,
            None,
            0.0,
            "room_shell_start_control_missing",
            metrics={"startReason": start.reason},
        )
    components = _cyan_components(rgb, width, height, (0.045, 0.005, 0.175, 0.16))
    candidates: list[EntryButtonCandidate] = []
    for left, top, right, bottom, cyan_pixels in components:
        rect = (left / width, top / height, right / width, bottom / height)
        span_x = rect[2] - rect[0]
        span_y = rect[3] - rect[1]
        center = ((rect[0] + rect[2]) / 2, (rect[1] + rect[3]) / 2)
        if not (
            0.040 <= span_x <= 0.085
            and 0.070 <= span_y <= 0.135
            and 0.070 <= center[0] <= 0.135
            and 0.035 <= center[1] <= 0.105
        ):
            continue
        white_pixels = 0
        for y in range(top, bottom):
            for x in range(left, right):
                red, green, blue = _pixel(rgb, width, x, y)
                if (
                    red >= 205
                    and green >= 205
                    and blue >= 205
                    and max(red, green, blue) - min(red, green, blue) <= 50
                ):
                    white_pixels += 1
        minimum_cyan = max(240, round(width * height * 0.0008))
        minimum_white = max(90, round(width * height * 0.0002))
        if cyan_pixels < minimum_cyan or white_pixels < minimum_white:
            continue
        confidence = min(
            0.99,
            0.88
            + min(0.06, cyan_pixels / max(1, width * height) * 30)
            + min(0.04, white_pixels / max(1, width * height) * 45),
        )
        candidates.append(
            EntryButtonCandidate(rect, center, cyan_pixels, white_pixels, confidence)
        )
    if len(candidates) != 1:
        return EntryUiLocation(
            BossEntryControl.CHINH_PHUC_ROOM_SHELL_EXIT,
            False,
            None,
            None,
            0.0,
            "room_shell_exit_missing" if not candidates else "room_shell_exit_ambiguous",
            tuple(candidates),
            {"candidateCount": len(candidates), "startReason": start.reason},
        )
    candidate = candidates[0]
    return EntryUiLocation(
        BossEntryControl.CHINH_PHUC_ROOM_SHELL_EXIT,
        True,
        candidate.normalized_point,
        candidate.normalized_rect,
        candidate.confidence,
        "single_room_start_plus_top_left_circular_exit",
        (candidate,),
        {
            "candidateCount": 1,
            "cyanPixels": candidate.cyan_pixels,
            "whitePixels": candidate.warm_or_white_pixels,
            "startReason": start.reason,
        },
    )


def locate_chinh_phuc_attack_card_toggle(
    rgb: bytes,
    width: int,
    height: int,
    *,
    room_card_count: int,
    attack_card_index: int,
) -> EntryUiLocation:
    """Prove the runtime-indexed ordinary Attack-card Toggle in the room row.

    Cpp2IL proves that ``DisplayCardsForSelection`` creates/registers Toggles
    in ``RoomDTO.cards`` order.  Runtime supplies the unique Attack index; the
    pixels only prove that the corresponding visible slot has the Attack
    card's cyan cost header, warm body and dark attack silhouette.  Pixels
    never choose a card identity.
    """

    control = BossEntryControl.CHINH_PHUC_ATTACK_CARD_TOGGLE
    if (
        width < 640
        or height < 360
        or len(rgb) != width * height * 3
        or room_card_count <= 0
        or room_card_count > 4
        or attack_card_index < 0
        or attack_card_index >= room_card_count
    ):
        return EntryUiLocation(
            control,
            False,
            None,
            None,
            0.0,
            "attack_card_layout_unsupported",
            metrics={
                "roomCardCount": room_card_count,
                "attackCardIndex": attack_card_index,
            },
        )

    # Canonical room layout is normalized by Desktop Start before FarmRunner
    # binds the HWND. Ordinary CardData toggles begin after the fusion/pet slot
    # and retain this fixed LayoutGroup spacing for one through four cards.
    center_x = 0.284 + 0.072 * attack_card_index
    left_n, right_n = center_x - 0.030, center_x + 0.030
    top_n, header_bottom_n, bottom_n = 0.715, 0.760, 0.860
    left, right = round(width * left_n), round(width * right_n)
    top = round(height * top_n)
    header_bottom = round(height * header_bottom_n)
    bottom = round(height * bottom_n)
    top_cyan = body_warm = body_dark = 0
    for y in range(top, bottom):
        for x in range(left, right):
            red, green, blue = _pixel(rgb, width, x, y)
            cyan = green >= 120 and blue >= 150 and blue >= red + 25
            warm = (
                red >= 170
                and 45 <= green <= 190
                and blue <= 115
                and red >= green + 25
                and red >= blue + 55
            )
            dark = red <= 90 and green <= 85 and blue <= 80
            if y < header_bottom:
                top_cyan += int(cyan)
            else:
                body_warm += int(warm)
                body_dark += int(dark)

    header_area = max(1, (right - left) * (header_bottom - top))
    body_area = max(1, (right - left) * (bottom - header_bottom))
    cyan_ratio = top_cyan / header_area
    warm_ratio = body_warm / body_area
    dark_ratio = body_dark / body_area
    metrics: dict[str, float | int | str] = {
        "roomCardCount": room_card_count,
        "attackCardIndex": attack_card_index,
        "topCyanPixels": top_cyan,
        "bodyWarmPixels": body_warm,
        "bodyDarkPixels": body_dark,
        "topCyanRatio": cyan_ratio,
        "bodyWarmRatio": warm_ratio,
        "bodyDarkRatio": dark_ratio,
    }
    if cyan_ratio < 0.10 or warm_ratio < 0.10 or dark_ratio < 0.025:
        return EntryUiLocation(
            control,
            False,
            None,
            (left_n, top_n, right_n, bottom_n),
            0.0,
            "runtime_attack_slot_visual_proof_failed",
            metrics=metrics,
        )
    confidence = min(
        0.99,
        0.82
        + min(0.07, cyan_ratio * 0.15)
        + min(0.06, warm_ratio * 0.18)
        + min(0.04, dark_ratio * 0.35),
    )
    return EntryUiLocation(
        control,
        True,
        (center_x, 0.79),
        (left_n, top_n, right_n, bottom_n),
        confidence,
        "unique_runtime_indexed_attack_toggle_visual_proof",
        metrics=metrics,
    )


__all__ = [
    "BossEntryControl",
    "EntryButtonCandidate",
    "EntryUiLocation",
    "find_chinh_phuc_start_candidates",
    "locate_chinh_phuc_start",
    "locate_detached_chinh_phuc_room_shell_exit",
]
