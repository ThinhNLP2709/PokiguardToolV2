"""Resolution-independent visual proof for the ChinhPhuc Start control.

Boss identity never comes from pixels.  This locator is used only after the
read-only runtime graph has proven the selected room/target association.
"""

from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum


class BossEntryControl(str, Enum):
    CHINH_PHUC_START = "CHINH_PHUC_START"


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


__all__ = [
    "BossEntryControl",
    "EntryButtonCandidate",
    "EntryUiLocation",
    "find_chinh_phuc_start_candidates",
    "locate_chinh_phuc_start",
]
