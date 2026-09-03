"""Fail-closed visual sanity checks for the two BASIC card controls.

The normalized anchors are the long-running V1 foreground-input calibration.
They are never sufficient by themselves: production callers must additionally
prove either the live CardUI/FusionCardUI state or the exact current
Board.selectedCards/Board.cardsInHand/MatchService-owned standard strip.
"""

from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum

from .unity_ui_layout import transform_for_capture


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


@dataclass(frozen=True)
class RuntimeCardStripLayout:
    """Fail-closed mapping from current CardData pointers to visual slots."""

    resolved: bool
    slot_count: int
    card_slots: tuple[tuple[int, int], ...]
    fusion_slot: int | None
    reason: str

    def slot_for_card_data(self, address: int) -> int | None:
        return next(
            (slot for card_address, slot in self.card_slots if card_address == address),
            None,
        )


# Legacy V1 calibration.  V1 required a four-tile strip (Fusion plus three
# selected cards), so these points are kept only for callers that do not yet
# have authoritative live CardUI cardinality.
_LEGACY_ANCHORS = {
    GameplayControl.EVOLVE: (0.417, 0.824),
    GameplayControl.CAST_ATTACK: (0.474, 0.824),
}

# Unity centres the complete card strip and spaces neighbouring tiles by about
# 5.8% of the client width.  Slot identity is recovered from live Board lists;
# it is never inferred from card type or a fixed loadout.
_CARD_STRIP_CENTER_X = 0.500
_CARD_SLOT_SPACING_X = 0.058
# Keep visual validation centred on the whole tile, but send the actual click
# slightly above its old centre.  Live operator feedback showed that the old
# point sat unnecessarily close to the lower card edge.  A 0.012 normalized
# shift is about 8.5 px at the canonical 710 px client height and remains well
# inside the same validated card control.
_CARD_VISUAL_CENTER_Y = 0.836
_CARD_CLICK_POINT_Y = 0.824


def resolve_runtime_card_strip(
    *,
    selected_card_data_addresses: tuple[int, ...],
    rendered_card_data_addresses: tuple[int, ...],
    cards_in_hand_count: int,
    fusion_expected: bool,
    fusion_skill_card_data_address: int | None,
) -> RuntimeCardStripLayout:
    """Resolve the standard-pet visual strip from current Board lists.

    Live combat and lobby evidence shows Fusion in the leftmost slot followed
    by ordinary ``selectedCards`` in list order.  A pet-specific skill changes
    that layout; support for that variant is intentionally deferred and must
    fail closed instead of guessing a click target.
    """

    selected = tuple(selected_card_data_addresses)
    rendered = tuple(rendered_card_data_addresses)
    skill = fusion_skill_card_data_address
    if not 0 <= cards_in_hand_count <= 16:
        return RuntimeCardStripLayout(False, 0, (), None, "invalid_cards_in_hand_count")
    if any(value <= 0 for value in selected + rendered):
        return RuntimeCardStripLayout(False, 0, (), None, "invalid_card_data_pointer")
    if len(set(selected)) != len(selected) or len(set(rendered)) != len(rendered):
        return RuntimeCardStripLayout(False, 0, (), None, "duplicate_card_data_pointer")
    if skill is not None and skill <= 0:
        return RuntimeCardStripLayout(False, 0, (), None, "invalid_pet_skill_pointer")
    if skill is not None and not fusion_expected:
        return RuntimeCardStripLayout(False, 0, (), None, "pet_skill_without_fusion_pet")
    if skill is not None and skill in selected:
        return RuntimeCardStripLayout(False, 0, (), None, "ambiguous_pet_skill_pointer")
    if skill is not None:
        return RuntimeCardStripLayout(
            False,
            cards_in_hand_count,
            (),
            None,
            "pet_skill_layout_deferred",
        )

    expected_rendered = set(selected)
    if not set(rendered).issubset(expected_rendered):
        return RuntimeCardStripLayout(False, 0, (), None, "unexpected_live_card_data")

    expected_count = len(selected) + int(fusion_expected)
    if cards_in_hand_count != expected_count:
        return RuntimeCardStripLayout(
            False,
            cards_in_hand_count,
            (),
            None,
            "selected_and_rendered_card_count_mismatch",
        )

    slot_count = expected_count
    ordinary_slot_offset = int(fusion_expected)
    card_slots = tuple(
        (address, selected_index + ordinary_slot_offset)
        for selected_index, address in enumerate(selected)
    )
    fusion_slot = 0 if fusion_expected else None
    return RuntimeCardStripLayout(
        True,
        slot_count,
        card_slots,
        fusion_slot,
        "standard_fusion_left_then_selected_cards_order",
    )


def _layout_anchor(
    control: GameplayControl,
    slot_index: int | None,
    slot_count: int | None,
) -> tuple[float, float] | None:
    if slot_index is None and slot_count is None:
        return _LEGACY_ANCHORS[control]
    if (
        slot_index is None
        or slot_count is None
        or not 1 <= slot_count <= 16
        or not 0 <= slot_index < slot_count
    ):
        return None
    first_x = _CARD_STRIP_CENTER_X - (
        _CARD_SLOT_SPACING_X * (slot_count - 1) / 2.0
    )
    return (first_x + slot_index * _CARD_SLOT_SPACING_X, _CARD_CLICK_POINT_Y)


def _region_metrics(
    rgb: bytes,
    width: int,
    height: int,
    box: tuple[float, float, float, float],
) -> dict[str, float | int]:
    left, top, right, bottom = box
    x0 = max(0, round(left * width))
    x1 = min(width, round(right * width))
    y0 = max(0, round(top * height))
    y1 = min(height, round(bottom * height))
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
    *,
    slot_index: int | None = None,
    slot_count: int | None = None,
) -> GameplayUiLocation:
    """Validate the expected combat-card tile without doing OCR or clicking."""

    if width < 640 or height < 360 or len(rgb) != width * height * 3:
        return GameplayUiLocation(
            control, False, None, 0.0, "invalid_client_capture"
        )
    reference_point = _layout_anchor(control, slot_index, slot_count)
    if reference_point is None:
        return GameplayUiLocation(
            control,
            False,
            None,
            0.0,
            "invalid_runtime_card_layout",
            {
                "slotIndex": slot_index if slot_index is not None else -1,
                "slotCount": slot_count if slot_count is not None else -1,
            },
        )
    # Detection intentionally remains on the accepted visual centre.  Only
    # the authorized click point moves upward; this avoids weakening the
    # colorful/warm tile proof when the button artwork has a dark top edge.
    transform = transform_for_capture(rgb, width, height)
    reference_visual_box = (
        reference_point[0] - 0.030,
        _CARD_VISUAL_CENTER_Y - 0.082,
        reference_point[0] + 0.030,
        _CARD_VISUAL_CENTER_Y + 0.072,
    )
    # Live 1.7.4 1280x640 evidence proves that the combat-card strip is
    # centered over the complete gameplay viewport.  Applying the separate
    # left-anchored 16:9 lobby canvas maps slot 1 onto slot 0 (Attack onto
    # Fusion) and can pass a false warm-color proof on Fusion artwork.
    if transform.mode.startswith("POKIGUARD_2_1"):
        visual_box = transform.viewport_rect(reference_visual_box)
        point = transform.viewport_point(reference_point)
        layout_space = "FULL_VIEWPORT"
    else:
        visual_box = transform.rect(reference_visual_box)
        point = transform.point(reference_point)
        layout_space = "REFERENCE_16_9"
    metrics = _region_metrics(rgb, width, height, visual_box)
    metrics["visualCenterY"] = _CARD_VISUAL_CENTER_Y
    metrics["clickCenterY"] = point[1]
    metrics["slotIndex"] = slot_index if slot_index is not None else "legacy"
    metrics["slotCount"] = slot_count if slot_count is not None else "legacy"
    metrics["layoutMode"] = transform.mode
    metrics["layoutSpace"] = layout_space
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
        (
            "runtime_card_slot_layout_plus_current_card_tile_visual"
            if slot_index is not None
            else "v1_proven_anchor_plus_current_card_tile_visual"
        ),
        metrics,
    )


__all__ = [
    "GameplayControl",
    "GameplayUiLocation",
    "RuntimeCardStripLayout",
    "locate_gameplay_control",
    "resolve_runtime_card_strip",
]
