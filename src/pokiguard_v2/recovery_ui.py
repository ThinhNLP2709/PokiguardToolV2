"""Resolution-independent, fail-closed locators for normal combat exit UI."""

from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum
from typing import Callable

from .unity_ui_layout import transform_for_capture


class RecoveryControl(str, Enum):
    EXIT_BACK = "EXIT_BACK"
    CONFIRM_LEAVE = "CONFIRM_LEAVE"


@dataclass(frozen=True)
class RecoveryUiLocation:
    control: RecoveryControl
    found: bool
    normalized_point: tuple[float, float] | None
    confidence: float
    reason: str
    metrics: dict[str, float | int | str] = field(default_factory=dict)


def _mask_components(
    rgb: bytes,
    width: int,
    height: int,
    box: tuple[float, float, float, float],
    predicate: Callable[[int, int, int], bool],
) -> list[tuple[int, int, int, int, int]]:
    if width < 640 or height < 360 or len(rgb) != width * height * 3:
        return []
    x0 = max(0, min(width - 1, round(box[0] * (width - 1))))
    y0 = max(0, min(height - 1, round(box[1] * (height - 1))))
    x1 = max(x0 + 1, min(width, round(box[2] * width)))
    y1 = max(y0 + 1, min(height, round(box[3] * height)))
    points: set[tuple[int, int]] = set()
    for y in range(y0, y1):
        row = y * width * 3
        for x in range(x0, x1):
            offset = row + x * 3
            if predicate(rgb[offset], rgb[offset + 1], rgb[offset + 2]):
                points.add((x, y))
    components: list[tuple[int, int, int, int, int]] = []
    while points:
        seed = points.pop()
        stack = [seed]
        min_x = max_x = seed[0]
        min_y = max_y = seed[1]
        count = 0
        while stack:
            x, y = stack.pop()
            count += 1
            min_x, max_x = min(min_x, x), max(max_x, x)
            min_y, max_y = min(min_y, y), max(max_y, y)
            for nx, ny in ((x - 1, y), (x + 1, y), (x, y - 1), (x, y + 1)):
                if (nx, ny) in points:
                    points.remove((nx, ny))
                    stack.append((nx, ny))
        components.append((min_x, min_y, max_x + 1, max_y + 1, count))
    return sorted(components, key=lambda item: item[4], reverse=True)


def locate_exit_back(rgb: bytes, width: int, height: int) -> RecoveryUiLocation:
    """Locate the white ``<<`` control in the combat-only top-left ROI."""

    transform = transform_for_capture(rgb, width, height)
    components = _mask_components(
        rgb,
        width,
        height,
        transform.rect((0.010, 0.025, 0.095, 0.120)),
        lambda r, g, b: r >= 225 and g >= 225 and b >= 225 and max(r, g, b) - min(r, g, b) <= 24,
    )
    min_pixels = max(20, round(transform.canvas_area * 0.000035))
    useful = [
        item
        for item in components
        if item[4] >= min_pixels
        and item[2] - item[0] >= max(3, round(transform.canvas_width * 0.003))
        and item[3] - item[1] >= max(5, round(transform.canvas_height * 0.010))
    ]
    total = sum(item[4] for item in useful[:6])
    if len(useful) < 2 or total < min_pixels * 3:
        return RecoveryUiLocation(
            RecoveryControl.EXIT_BACK,
            False,
            None,
            0.0,
            "combat_exit_chevrons_not_proven",
            {"components": len(useful), "whitePixels": total},
        )
    left = min(item[0] for item in useful[:6])
    top = min(item[1] for item in useful[:6])
    right = max(item[2] for item in useful[:6])
    bottom = max(item[3] for item in useful[:6])
    center = ((left + right) / 2 / width, (top + bottom) / 2 / height)
    reference_center = transform.reference_point(center)
    if not (
        0.015 <= reference_center[0] <= 0.085
        and 0.030 <= reference_center[1] <= 0.110
    ):
        return RecoveryUiLocation(
            RecoveryControl.EXIT_BACK,
            False,
            None,
            0.0,
            "chevron_candidate_outside_combat_exit_anchor",
            {"centerX": center[0], "centerY": center[1], "layoutMode": transform.mode},
        )
    confidence = min(0.99, 0.72 + min(0.20, len(useful) * 0.035))
    return RecoveryUiLocation(
        RecoveryControl.EXIT_BACK,
        True,
        center,
        confidence,
        "white_double_chevron_in_combat_exit_roi",
        {"components": len(useful), "whitePixels": total},
    )


def locate_confirm_leave(rgb: bytes, width: int, height: int) -> RecoveryUiLocation:
    """Locate the left of two orange buttons in the leave-confirm modal."""

    transform = transform_for_capture(rgb, width, height)
    components = _mask_components(
        rgb,
        width,
        height,
        transform.rect((0.250, 0.500, 0.720, 0.760)),
        lambda r, g, b: r >= 175 and 55 <= g <= 210 and b <= 105 and r >= g + 25,
    )
    min_area = max(120, round(transform.canvas_area * 0.00045))
    candidates = [
        item
        for item in components
        if item[4] >= min_area
        and item[2] - item[0] >= transform.canvas_width * 0.070
        and item[3] - item[1] >= transform.canvas_height * 0.040
        and 0.30
        <= transform.reference_point(((item[0] + item[2]) / 2 / width, 0.0))[0]
        <= 0.70
        and 0.56
        <= transform.reference_point((0.0, (item[1] + item[3]) / 2 / height))[1]
        <= 0.73
    ]
    if len(candidates) != 2:
        return RecoveryUiLocation(
            RecoveryControl.CONFIRM_LEAVE,
            False,
            None,
            0.0,
            "expected_exactly_two_orange_modal_buttons",
            {"orangeComponents": len(candidates)},
        )
    candidates.sort(key=lambda item: item[0])
    left, right = candidates
    left_w, right_w = left[2] - left[0], right[2] - right[0]
    left_h, right_h = left[3] - left[1], right[3] - right[1]
    left_center = ((left[0] + left[2]) / 2, (left[1] + left[3]) / 2)
    right_center = ((right[0] + right[2]) / 2, (right[1] + right[3]) / 2)
    similar = (
        0.65 <= left_w / max(1, right_w) <= 1.35
        and 0.65 <= left_h / max(1, right_h) <= 1.35
        and abs(left_center[1] - right_center[1]) <= transform.canvas_height * 0.035
        and transform.reference_point((left_center[0] / width, 0.0))[0]
        < 0.50
        < transform.reference_point((right_center[0] / width, 0.0))[0]
    )
    if not similar:
        return RecoveryUiLocation(
            RecoveryControl.CONFIRM_LEAVE,
            False,
            None,
            0.0,
            "orange_components_do_not_match_leave_modal_layout",
            {"leftWidth": left_w, "rightWidth": right_w, "verticalDelta": abs(left_center[1] - right_center[1])},
        )
    point = (left_center[0] / width, left_center[1] / height)
    reference_point = transform.reference_point(point)
    if not (
        0.28 <= reference_point[0] <= 0.49
        and 0.54 <= reference_point[1] <= 0.73
    ):
        return RecoveryUiLocation(
            RecoveryControl.CONFIRM_LEAVE,
            False,
            None,
            0.0,
            "confirm_candidate_outside_left_modal_button_anchor",
            {"centerX": point[0], "centerY": point[1]},
        )
    return RecoveryUiLocation(
        RecoveryControl.CONFIRM_LEAVE,
        True,
        point,
        0.96,
        "left_of_two_symmetric_orange_leave_modal_buttons",
        {"orangeComponents": 2, "leftPixels": left[4], "rightPixels": right[4]},
    )


__all__ = [
    "RecoveryControl",
    "RecoveryUiLocation",
    "locate_confirm_leave",
    "locate_exit_back",
]
