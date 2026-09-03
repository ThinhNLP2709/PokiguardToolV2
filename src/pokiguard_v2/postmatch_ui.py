"""Fail-closed visual proof for the mandatory combat-result confirmation UI."""

from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum
from typing import Sequence

from .recovery_ui import _mask_components
from .unity_ui_layout import transform_for_capture


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


def _viewport_rect(
    transform: object,
    rect: tuple[float, float, float, float],
) -> tuple[float, float, float, float]:
    """Map a full-viewport normalized rect, independent of the narrow UI canvas."""

    left, top, right, bottom = rect
    return (
        (transform.viewport_left + left * transform.viewport_width)
        / transform.client_width,
        (transform.viewport_top + top * transform.viewport_height)
        / transform.client_height,
        (transform.viewport_left + right * transform.viewport_width)
        / transform.client_width,
        (transform.viewport_top + bottom * transform.viewport_height)
        / transform.client_height,
    )


def _viewport_point(
    transform: object,
    client_point: tuple[float, float],
) -> tuple[float, float]:
    x, y = client_point
    return (
        (x * transform.client_width - transform.viewport_left)
        / transform.viewport_width,
        (y * transform.client_height - transform.viewport_top)
        / transform.viewport_height,
    )


def _locate_current_wide_result(
    rgb: bytes,
    width: int,
    height: int,
    transform: object,
) -> PostmatchUiLocation | None:
    """Recognize the 1.7.4 full-viewport result banner and blue confirm.

    Unlike card/lobby controls, this overlay spans the whole 2:1 gameplay
    viewport.  The proof deliberately requires both the unique large orange
    winner banner and one unique centered blue button; either feature alone is
    insufficient to grant input.
    """

    if not str(transform.mode).startswith("POKIGUARD_2_1"):
        return None

    banner_components = _mask_components(
        rgb,
        width,
        height,
        _viewport_rect(transform, (0.05, 0.0, 0.95, 0.35)),
        lambda r, g, b: (
            r >= 180
            and 55 <= g <= 210
            and b <= 100
            and r >= g + 30
        ),
    )
    viewport_area = transform.viewport_width * transform.viewport_height
    banner_min_pixels = max(8_000, round(viewport_area * 0.04))
    banners = [
        item
        for item in banner_components
        if item[4] >= banner_min_pixels
        and item[2] - item[0] >= transform.viewport_width * 0.60
        and item[3] - item[1] >= transform.viewport_height * 0.12
    ]

    blue_components = _mask_components(
        rgb,
        width,
        height,
        _viewport_rect(transform, (0.35, 0.82, 0.65, 0.97)),
        lambda r, g, b: b >= 140 and g >= 80 and b >= r + 35,
    )
    button_min_pixels = max(750, round(viewport_area * 0.0015))
    buttons = [
        item
        for item in blue_components
        if item[4] >= button_min_pixels
        and transform.viewport_width * 0.07
        <= item[2] - item[0]
        <= transform.viewport_width * 0.16
        and transform.viewport_height * 0.035
        <= item[3] - item[1]
        <= transform.viewport_height * 0.10
    ]
    if len(banners) != 1 or len(buttons) != 1:
        return None

    banner = banners[0]
    button = buttons[0]
    banner_point = (
        (banner[0] + banner[2]) / 2 / width,
        (banner[1] + banner[3]) / 2 / height,
    )
    button_point = (
        (button[0] + button[2]) / 2 / width,
        (button[1] + button[3]) / 2 / height,
    )
    banner_viewport = _viewport_point(transform, banner_point)
    button_viewport = _viewport_point(transform, button_point)
    if not (
        0.42 <= banner_viewport[0] <= 0.58
        and 0.05 <= banner_viewport[1] <= 0.20
        and 0.46 <= button_viewport[0] <= 0.54
        and 0.86 <= button_viewport[1] <= 0.94
    ):
        return None

    return PostmatchUiLocation(
        PostmatchControl.RESULT_CONFIRM,
        True,
        button_point,
        0.99,
        "single_blue_button_below_orange_result_banner",
        {
            "layoutVariant": "POKIGUARD_1_7_4_WIDE_RESULT",
            "bannerPixels": banner[4],
            "bannerWidth": banner[2] - banner[0],
            "bannerHeight": banner[3] - banner[1],
            "buttonPixels": button[4],
            "buttonWidth": button[2] - button[0],
            "buttonHeight": button[3] - button[1],
        },
    )


def locate_result_confirm(rgb: bytes, width: int, height: int) -> PostmatchUiLocation:
    """Locate the sole orange ``Đồng ý`` control inside the result-modal layout.

    The caller must independently prove authoritative POSTMATCH lifecycle. This
    locator proves only the visible layout and intentionally rejects the
    two-button leave-confirm modal.
    """

    transform = transform_for_capture(rgb, width, height)
    current_wide = _locate_current_wide_result(
        rgb,
        width,
        height,
        transform,
    )
    if current_wide is not None:
        return current_wide

    panel_components = _mask_components(
        rgb,
        width,
        height,
        transform.rect((0.12, 0.08, 0.88, 0.84)),
        lambda r, g, b: b >= 100 and g >= 60 and b >= r + 35,
    )
    panel_min_pixels = max(5_000, round(transform.canvas_area * 0.12))
    panels = [
        item
        for item in panel_components
        if item[4] >= panel_min_pixels
        and item[2] - item[0] >= transform.canvas_width * 0.55
        and item[3] - item[1] >= transform.canvas_height * 0.45
        and 0.38
        <= transform.reference_point(((item[0] + item[2]) / 2 / width, 0.0))[0]
        <= 0.62
        and 0.30
        <= transform.reference_point((0.0, (item[1] + item[3]) / 2 / height))[1]
        <= 0.62
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
        transform.rect((0.30, 0.74, 0.70, 0.97)),
        lambda r, g, b: r >= 180 and 70 <= g <= 230 and b <= 110 and r >= g + 20,
    )
    min_button_pixels = max(500, round(transform.canvas_area * 0.003))
    button_shapes = [
        item
        for item in orange_components
        if item[4] >= min_button_pixels
        and transform.canvas_width * 0.08
        <= item[2] - item[0]
        <= transform.canvas_width * 0.20
        and transform.canvas_height * 0.04
        <= item[3] - item[1]
        <= transform.canvas_height * 0.12
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
    reference_point = transform.reference_point(point)
    if not (
        0.44 <= reference_point[0] <= 0.56
        and 0.80 <= reference_point[1] <= 0.94
    ):
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
