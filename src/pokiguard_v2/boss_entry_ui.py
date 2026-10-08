"""Resolution-independent visual proof for the ChinhPhuc Start control.

Boss identity never comes from pixels.  This locator is used only after the
read-only runtime graph has proven the selected room/target association.
"""

from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum

from .unity_ui_layout import transform_for_capture


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
    transform = transform_for_capture(rgb, width, height)
    search = transform.rect((0.40, 0.745, 0.86, 0.91))
    x0, x1 = round(width * search[0]), round(width * search[2])
    y0, y1 = round(height * search[1]), round(height * search[3])
    cell = max(3, round(min(transform.canvas_width, transform.canvas_height) / 180))
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
        center = (
            (normalized[0] + normalized[2]) / 2,
            (normalized[1] + normalized[3]) / 2,
        )
        reference_left, reference_top = transform.reference_point(
            (normalized[0], normalized[1])
        )
        reference_right, reference_bottom = transform.reference_point(
            (normalized[2], normalized[3])
        )
        reference_center = transform.reference_point(center)
        span_x = reference_right - reference_left
        span_y = reference_bottom - reference_top
        if not (
            0.10 <= span_x <= 0.33
            and 0.055 <= span_y <= 0.17
            and 0.52 <= reference_center[0] <= 0.76
            and 0.785 <= reference_center[1] <= 0.855
        ):
            continue
        cyan_pixels = sum(counts[key] for key in source_cells)
        warm_or_white = 0
        for y in range(top, bottom):
            for x in range(left, right):
                if _warm_or_white(*_pixel(rgb, width, x, y)):
                    warm_or_white += 1
        minimum_cyan = max(160, round(transform.canvas_area * 0.00045))
        minimum_text = max(50, round(transform.canvas_area * 0.00010))
        if cyan_pixels < minimum_cyan or warm_or_white < minimum_text:
            continue
        anchor_error = abs(reference_center[0] - 0.645) + abs(reference_center[1] - 0.82)
        confidence = min(
            0.99,
            0.82
            + min(0.09, cyan_pixels / max(1, transform.canvas_area) * 25)
            + min(0.06, warm_or_white / max(1, transform.canvas_area) * 35)
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
    *,
    expected_rect: tuple[float, float, float, float] | None = None,
) -> EntryUiLocation:
    if expected_rect is not None:
        if width < 640 or height < 360 or len(rgb) != width * height * 3:
            return EntryUiLocation(
                BossEntryControl.CHINH_PHUC_START,
                False,
                None,
                None,
                0.0,
                "invalid_capture",
                (),
                {"candidateCount": 0},
            )
        left, top, right, bottom = expected_rect
        rect_width = right - left
        rect_height = bottom - top
        if not (
            0.0 <= left < right <= 1.0
            and 0.0 <= top < bottom <= 1.0
            and 0.06 <= rect_width <= 0.60
            and 0.035 <= rect_height <= 0.30
        ):
            return EntryUiLocation(
                BossEntryControl.CHINH_PHUC_START,
                False,
                None,
                None,
                0.0,
                "runtime_start_rect_invalid",
                (),
                {"candidateCount": 0},
            )
        x0 = max(0, min(width - 1, round(left * width)))
        x1 = max(x0 + 1, min(width, round(right * width)))
        y0 = max(0, min(height - 1, round(top * height)))
        y1 = max(y0 + 1, min(height, round(bottom * height)))
        cyan_pixels = 0
        decorated_pixels = 0
        warm_or_white_pixels = 0
        for y in range(y0, y1):
            for x in range(x0, x1):
                pixel = _pixel(rgb, width, x, y)
                cyan_pixels += int(_cyan(*pixel))
                decorated_pixels += int(
                    max(pixel) >= 150 and max(pixel) - min(pixel) >= 60
                )
                warm_or_white_pixels += int(_warm_or_white(*pixel))
        area = (x1 - x0) * (y1 - y0)
        minimum_decorated = max(24, round(area * 0.008))
        minimum_text = max(12, round(area * 0.003))
        if (
            decorated_pixels < minimum_decorated
            or warm_or_white_pixels < minimum_text
        ):
            return EntryUiLocation(
                BossEntryControl.CHINH_PHUC_START,
                False,
                None,
                None,
                0.0,
                "runtime_start_rect_visual_mismatch",
                (),
                {
                    "candidateCount": 0,
                    "cyanPixels": cyan_pixels,
                    "decoratedPixels": decorated_pixels,
                    "warmOrWhitePixels": warm_or_white_pixels,
                    "minimumDecoratedPixels": minimum_decorated,
                    "minimumWarmOrWhitePixels": minimum_text,
                },
            )
        center = ((left + right) / 2.0, (top + bottom) / 2.0)
        confidence = min(
            0.99,
            0.94
            + min(0.03, decorated_pixels / max(1, area) * 0.30)
            + min(0.02, warm_or_white_pixels / max(1, area) * 0.35),
        )
        candidate = EntryButtonCandidate(
            expected_rect,
            center,
            cyan_pixels,
            warm_or_white_pixels,
            confidence,
        )
        return EntryUiLocation(
            BossEntryControl.CHINH_PHUC_START,
            True,
            center,
            expected_rect,
            confidence,
            "runtime_owned_start_rect_with_visual_signature",
            (candidate,),
            {
                "candidateCount": 1,
                "cyanPixels": cyan_pixels,
                "decoratedPixels": decorated_pixels,
                "warmOrWhitePixels": warm_or_white_pixels,
                "geometrySource": "ManagerRoom.ButtonStart",
            },
        )
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
    *,
    expected_start_rect: tuple[float, float, float, float] | None = None,
) -> EntryUiLocation:
    """Locate the normal close control of a detached Chinh Phuc room shell.

    The circular ``X`` also exists on the real island map, so it is never
    sufficient by itself.  This proof first requires the unique lower-room
    Start/Ready control, then locates one cyan circular close control with a
    substantial white cross/highlight.  The legacy room places that control
    on the reference-canvas left; the current room shell places it on the
    full-viewport right.  Runtime room ownership and target identity are
    checked separately by ``farm_run``.
    """

    start = locate_chinh_phuc_start(
        rgb,
        width,
        height,
        expected_rect=expected_start_rect,
    )
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
    transform = transform_for_capture(rgb, width, height)
    layouts = (
        (
            "TOP_LEFT_REFERENCE",
            transform.rect((0.045, 0.005, 0.175, 0.16)),
            (0.070, 0.135, 0.035, 0.105),
            "REFERENCE",
        ),
        (
            "TOP_RIGHT_VIEWPORT",
            transform.viewport_rect((0.90, 0.0, 1.0, 0.17)),
            (0.935, 0.995, 0.025, 0.125),
            "VIEWPORT",
        ),
    )
    located: list[tuple[EntryButtonCandidate, str]] = []
    for layout, search_box, center_bounds, coordinate_space in layouts:
        components = _cyan_components(rgb, width, height, search_box)
        for left, top, right, bottom, cyan_pixels in components:
            rect = (left / width, top / height, right / width, bottom / height)
            center = ((rect[0] + rect[2]) / 2, (rect[1] + rect[3]) / 2)
            if coordinate_space == "REFERENCE":
                space_left, space_top = transform.reference_point(
                    (rect[0], rect[1])
                )
                space_right, space_bottom = transform.reference_point(
                    (rect[2], rect[3])
                )
                space_center = transform.reference_point(center)
            else:
                space_left = (
                    rect[0] * width - transform.viewport_left
                ) / transform.viewport_width
                space_right = (
                    rect[2] * width - transform.viewport_left
                ) / transform.viewport_width
                space_top = (
                    rect[1] * height - transform.viewport_top
                ) / transform.viewport_height
                space_bottom = (
                    rect[3] * height - transform.viewport_top
                ) / transform.viewport_height
                space_center = (
                    (center[0] * width - transform.viewport_left)
                    / transform.viewport_width,
                    (center[1] * height - transform.viewport_top)
                    / transform.viewport_height,
                )
            span_x = space_right - space_left
            span_y = space_bottom - space_top
            min_x, max_x, min_y, max_y = center_bounds
            if not (
                0.035 <= span_x <= 0.085
                and 0.065 <= span_y <= 0.140
                and min_x <= space_center[0] <= max_x
                and min_y <= space_center[1] <= max_y
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
            minimum_cyan = max(240, round(transform.canvas_area * 0.0008))
            minimum_white = max(90, round(transform.canvas_area * 0.0002))
            if cyan_pixels < minimum_cyan or white_pixels < minimum_white:
                continue
            confidence = min(
                0.99,
                0.88
                + min(0.06, cyan_pixels / max(1, transform.canvas_area) * 30)
                + min(0.04, white_pixels / max(1, transform.canvas_area) * 45),
            )
            located.append(
                (
                    EntryButtonCandidate(
                        rect, center, cyan_pixels, white_pixels, confidence
                    ),
                    layout,
                )
            )
    candidates = [candidate for candidate, _layout in located]
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
    candidate, layout = located[0]
    layout_reason = (
        "top_left" if layout == "TOP_LEFT_REFERENCE" else "top_right"
    )
    return EntryUiLocation(
        BossEntryControl.CHINH_PHUC_ROOM_SHELL_EXIT,
        True,
        candidate.normalized_point,
        candidate.normalized_rect,
        candidate.confidence,
        f"single_room_start_plus_{layout_reason}_circular_exit",
        (candidate,),
        {
            "candidateCount": 1,
            "cyanPixels": candidate.cyan_pixels,
            "whitePixels": candidate.warm_or_white_pixels,
            "startReason": start.reason,
            "exitLayout": layout,
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

    # Keep the proven card/UI calibration. Live 1.7.4 evidence shows this
    # canvas remains height-scaled and left-anchored in the 2:1 viewport. The
    # full-width combat DotsArea uses its own mapping in win32_input instead.
    transform = transform_for_capture(rgb, width, height)
    center_x = 0.284 + 0.072 * attack_card_index
    reference_rect = (center_x - 0.030, 0.715, center_x + 0.030, 0.860)
    left_n, top_n, right_n, bottom_n = transform.rect(reference_rect)
    _, header_bottom_n = transform.point((center_x, 0.760))
    click_point = transform.point((center_x, 0.790))
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
        "layoutMode": transform.mode,
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
        click_point,
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
