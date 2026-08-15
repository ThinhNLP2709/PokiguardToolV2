"""Fail-closed visual proof for the mandatory combat-result confirmation UI."""

from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum
from typing import Sequence

from .recovery_ui import _mask_components


class PostmatchControl(str, Enum):
    RESULT_CONFIRM = "RESULT_CONFIRM"


@dataclass(frozen=True)
class PostmatchUiLocation:
    control: PostmatchControl
    found: bool
    normalized_point: tuple[float, float] | None
    confidence: float
    reason: str
    metrics: dict[str, float | int | str] = field(default_factory=dict)


@dataclass(frozen=True)
class StablePostmatchUi:
    proven: bool
    normalized_point: tuple[float, float] | None
    reason: str
    frames: int
    max_drift: float | None = None


def locate_result_confirm(rgb: bytes, width: int, height: int) -> PostmatchUiLocation:
    """Locate the sole orange ``Đồng ý`` control inside the result-modal layout.

    The caller must independently prove authoritative POSTMATCH lifecycle. This
    locator proves only the visible layout and intentionally rejects the
    two-button leave-confirm modal.
    """

    panel_components = _mask_components(
        rgb,
        width,
        height,
        (0.12, 0.08, 0.88, 0.84),
        lambda r, g, b: b >= 100 and g >= 60 and b >= r + 35,
    )
    panel_min_pixels = max(5_000, round(width * height * 0.12))
    panels = [
        item
        for item in panel_components
        if item[4] >= panel_min_pixels
        and item[2] - item[0] >= width * 0.55
        and item[3] - item[1] >= height * 0.45
        and 0.38 <= (item[0] + item[2]) / 2 / width <= 0.62
        and 0.30 <= (item[1] + item[3]) / 2 / height <= 0.62
    ]
    if len(panels) != 1:
        return PostmatchUiLocation(
            PostmatchControl.RESULT_CONFIRM,
            False,
            None,
            0.0,
            "expected_exactly_one_large_blue_result_panel",
            {"panelCandidates": len(panels)},
        )

    orange_components = _mask_components(
        rgb,
        width,
        height,
        (0.30, 0.74, 0.70, 0.97),
        lambda r, g, b: r >= 180 and 70 <= g <= 230 and b <= 110 and r >= g + 20,
    )
    min_button_pixels = max(500, round(width * height * 0.003))
    button_shapes = [
        item
        for item in orange_components
        if item[4] >= min_button_pixels
        and width * 0.08 <= item[2] - item[0] <= width * 0.20
        and height * 0.04 <= item[3] - item[1] <= height * 0.12
    ]
    if len(button_shapes) != 1:
        return PostmatchUiLocation(
            PostmatchControl.RESULT_CONFIRM,
            False,
            None,
            0.0,
            "expected_exactly_one_orange_result_button",
            {"buttonCandidates": len(button_shapes), "panelPixels": panels[0][4]},
        )

    button = button_shapes[0]
    point = (
        (button[0] + button[2]) / 2 / width,
        (button[1] + button[3]) / 2 / height,
    )
    if not (0.44 <= point[0] <= 0.56 and 0.80 <= point[1] <= 0.94):
        return PostmatchUiLocation(
            PostmatchControl.RESULT_CONFIRM,
            False,
            None,
            0.0,
            "result_button_outside_centered_postmatch_anchor",
            {"centerX": point[0], "centerY": point[1]},
        )
    return PostmatchUiLocation(
        PostmatchControl.RESULT_CONFIRM,
        True,
        point,
        0.98,
        "single_orange_button_below_large_blue_result_panel",
        {
            "panelPixels": panels[0][4],
            "buttonPixels": button[4],
            "buttonWidth": button[2] - button[0],
            "buttonHeight": button[3] - button[1],
        },
    )


def prove_stable_result_confirm(
    locations: Sequence[PostmatchUiLocation],
    *,
    required_frames: int = 2,
    max_normalized_drift: float = 0.012,
) -> StablePostmatchUi:
    if required_frames < 2 or len(locations) < required_frames:
        return StablePostmatchUi(False, None, "insufficient_result_modal_frames", len(locations))
    frames = tuple(locations[-required_frames:])
    if any(
        not item.found
        or item.control is not PostmatchControl.RESULT_CONFIRM
        or item.normalized_point is None
        or item.confidence < 0.95
        for item in frames
    ):
        return StablePostmatchUi(False, None, "result_modal_frame_not_proven", len(frames))
    points = tuple(item.normalized_point for item in frames if item.normalized_point is not None)
    anchor = points[0]
    drift = max(max(abs(point[0] - anchor[0]), abs(point[1] - anchor[1])) for point in points)
    if drift > max_normalized_drift:
        return StablePostmatchUi(False, None, "result_modal_control_moved", len(frames), drift)
    point = (
        sum(value[0] for value in points) / len(points),
        sum(value[1] for value in points) / len(points),
    )
    return StablePostmatchUi(True, point, "stable_result_confirm_control", len(frames), drift)


__all__ = [
    "PostmatchControl",
    "PostmatchUiLocation",
    "StablePostmatchUi",
    "locate_result_confirm",
    "prove_stable_result_confirm",
]
