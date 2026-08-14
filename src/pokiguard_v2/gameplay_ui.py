"""Fail-closed visual sanity checks for the two BASIC card controls.

The normalized anchors are the long-running V1 foreground-input calibration.
They are never sufficient by themselves: production callers must also prove
the corresponding current CardUI/FusionCardUI object and its interactable
state from read-only runtime data.
"""

from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum


class GameplayControl(str, Enum):
    EVOLVE = "EVOLVE"
    CAST_ATTACK = "CAST_ATTACK"


@dataclass(frozen=True)
class GameplayUiLocation:
    control: GameplayControl
    found: bool
    normalized_point: tuple[float, float] | None
    confidence: float
    reason: str
    metrics: dict[str, float | int | str] = field(default_factory=dict)


_ANCHORS = {
    GameplayControl.EVOLVE: (0.417, 0.836),
    GameplayControl.CAST_ATTACK: (0.474, 0.836),
}


def _region_metrics(
    rgb: bytes,
    width: int,
    height: int,
    center: tuple[float, float],
) -> dict[str, float | int]:
    cx, cy = center
    x0 = max(0, round((cx - 0.030) * width))
    x1 = min(width, round((cx + 0.030) * width))
    y0 = max(0, round((cy - 0.082) * height))
    y1 = min(height, round((cy + 0.072) * height))
    samples = colorful = bright = dark = warm = 0
    minimum = 255
    maximum = 0
    for y in range(y0, y1, 2):
        row = y * width * 3
        for x in range(x0, x1, 2):
            offset = row + x * 3
            r, g, b = rgb[offset], rgb[offset + 1], rgb[offset + 2]
            hi, lo = max(r, g, b), min(r, g, b)
            samples += 1
            colorful += hi - lo >= 42 and hi >= 72
            bright += hi >= 165
            dark += hi <= 42
            warm += r >= 120 and r >= g + 28 and r >= b + 38
            minimum = min(minimum, lo)
            maximum = max(maximum, hi)
    denominator = max(1, samples)
    return {
        "samples": samples,
        "colorfulRatio": colorful / denominator,
        "brightRatio": bright / denominator,
        "darkRatio": dark / denominator,
        "warmRatio": warm / denominator,
        "dynamicRange": maximum - minimum,
    }


def locate_gameplay_control(
    rgb: bytes,
    width: int,
    height: int,
    control: GameplayControl,
) -> GameplayUiLocation:
    """Validate the expected combat-card tile without doing OCR or clicking."""

    if width < 640 or height < 360 or len(rgb) != width * height * 3:
        return GameplayUiLocation(
            control, False, None, 0.0, "invalid_client_capture"
        )
    point = _ANCHORS[control]
    metrics = _region_metrics(rgb, width, height, point)
    colorful = float(metrics["colorfulRatio"])
    bright = float(metrics["brightRatio"])
    dark = float(metrics["darkRatio"])
    dynamic = int(metrics["dynamicRange"])
    # A blank, covered, loading or heavily dimmed region cannot authorize a
    # click. Attack also needs a visible warm/orange attack-card population.
    if (
        int(metrics["samples"]) < 100
        or dynamic < 100
        or colorful < 0.10
        or bright < 0.025
        or dark > 0.82
    ):
        return GameplayUiLocation(
            control,
            False,
            None,
            0.0,
            "combat_card_tile_visual_not_proven",
            metrics,
        )
    if control is GameplayControl.CAST_ATTACK and float(metrics["warmRatio"]) < 0.045:
        return GameplayUiLocation(
            control,
            False,
            None,
            0.0,
            "attack_card_warm_visual_not_proven",
            metrics,
        )
    confidence = min(
        0.97,
        0.78 + min(0.10, colorful * 0.14) + min(0.08, bright * 0.12),
    )
    return GameplayUiLocation(
        control,
        True,
        point,
        confidence,
        "v1_proven_anchor_plus_current_card_tile_visual",
        metrics,
    )


__all__ = [
    "GameplayControl",
    "GameplayUiLocation",
    "locate_gameplay_control",
]
