"""Read-only proof for returning from the general hub to Chinh Phuc.

Identity and geometry come from the exact ``ManagerQuangTruong``-owned Unity
objects.  This module never invokes a game method and never writes target
memory; callers may use the proven point only through normal foreground input.
"""

from __future__ import annotations

from dataclasses import dataclass
import math

from .boss_lobby_runtime import (
    MANAGER_QUANG_TRUONG_TYPE_INFO_RVA,
    SELECTABLE_GROUPS_ALLOW_INTERACTION_OFFSET,
    SELECTABLE_INTERACTABLE_OFFSET,
    _native_pointer,
    _read_pointer,
    _static_instance,
)
from .il2cpp_external import ExternalReadError
from .il2cpp_layout import LayoutValidationError
from .native_card_ui import NativeButtonGeometry, NativeCardUiReader
from .unity_ui_layout import transform_for_capture


# Pokiguard 1.7.4-b4 ManagerQuangTruong, verified in the local Cpp2IL output.
MQT_PANEL_CHINH_PHUC_OFFSET = 0x2C0
MQT_BUTTON_CHINH_PHUC_OFFSET = 0x2C8


@dataclass(frozen=True)
class HubChinhPhucControl:
    manager_quang_truong: int | None
    panel_chinh_phuc: int | None
    panel_native: int | None
    panel_active: bool | None
    button_chinh_phuc: int | None
    button_native: int | None
    button_active: bool | None
    button_interactable: bool | None
    button_groups_allow: bool | None
    viewport_rect: tuple[float, float, float, float] | None
    root_transform: int | None
    root_aspect: float | None
    clean: bool
    reasons: tuple[str, ...]

    @property
    def viewport_point(self) -> tuple[float, float] | None:
        if self.viewport_rect is None:
            return None
        left, top, right, bottom = self.viewport_rect
        return ((left + right) / 2.0, (top + bottom) / 2.0)


@dataclass(frozen=True)
class HubControlLocation:
    found: bool
    normalized_point: tuple[float, float] | None
    normalized_rect: tuple[float, float, float, float] | None
    reason: str
    metrics: dict[str, float | int | str]


def read_hub_chinh_phuc_control(target: object) -> HubChinhPhucControl:
    """Prove the closed Chinh Phuc panel and its exact live hub Button."""

    manager = panel = panel_native = button = button_native = None
    panel_active = button_active = interactable = groups_allow = None
    geometry: NativeButtonGeometry | None = None
    reasons: list[str] = []
    resolver = target.resolver
    try:
        manager = _static_instance(
            resolver, MANAGER_QUANG_TRUONG_TYPE_INFO_RVA, size=0x3E0
        )
        if manager is None:
            reasons.append("ManagerQuangTruong.Instance unavailable")
        else:
            panel = _read_pointer(resolver, manager, MQT_PANEL_CHINH_PHUC_OFFSET)
            button = _read_pointer(resolver, manager, MQT_BUTTON_CHINH_PHUC_OFFSET)
            if panel is None:
                reasons.append("ManagerQuangTruong.panelChinhPhuc is null")
            if button is None:
                reasons.append("ManagerQuangTruong.btnChinhPhuc is null")
            reader = NativeCardUiReader(
                target.memory, resolver.game_assembly_base
            )
            if panel is not None:
                panel_native = _native_pointer(resolver, panel)
                if panel_native is None:
                    reasons.append("Chinh Phuc panel native object is not alive")
                else:
                    panel_active = reader.read_game_object_active(panel)
                    if panel_active:
                        reasons.append("Chinh Phuc panel is already active")
            if button is not None:
                if not resolver.memory.is_readable(
                    button, SELECTABLE_GROUPS_ALLOW_INTERACTION_OFFSET + 1
                ):
                    reasons.append("Chinh Phuc Button range is unreadable")
                else:
                    interactable = resolver.read_bool(
                        button + SELECTABLE_INTERACTABLE_OFFSET
                    )
                    groups_allow = resolver.read_bool(
                        button + SELECTABLE_GROUPS_ALLOW_INTERACTION_OFFSET
                    )
                    if not interactable:
                        reasons.append("Chinh Phuc Button is not interactable")
                    if not groups_allow:
                        reasons.append("Chinh Phuc Button CanvasGroup blocks interaction")
                    # The hub CTA has a continuous idle bob in b4.  The live
                    # trace moved only its native TRS translation by 0.29 px
                    # during one ownership walk; keep every ownership and
                    # rotation/scale fence strict while accepting at most one
                    # pixel of that visual animation.
                    geometry = reader.read_button_geometry(
                        button, max_translation_jitter=1.0
                    )
                    button_native = geometry.native_button
                    button_active = geometry.active
                    if not button_active:
                        reasons.append("Chinh Phuc Button is inactive")
                    if geometry.viewport_rect is None or geometry.root_aspect is None:
                        reasons.append("Chinh Phuc Button has no live viewport geometry")
    except (ExternalReadError, LayoutValidationError, OSError, ValueError) as exc:
        reasons.append(f"hub Chinh Phuc read error: {exc}")
    return HubChinhPhucControl(
        manager,
        panel,
        panel_native,
        panel_active,
        button,
        button_native,
        button_active,
        interactable,
        groups_allow,
        geometry.viewport_rect if geometry is not None else None,
        geometry.root_transform if geometry is not None else None,
        geometry.root_aspect if geometry is not None else None,
        not reasons,
        tuple(reasons),
    )


def same_clean_hub_chinh_phuc_control(
    first: HubChinhPhucControl | None,
    second: HubChinhPhucControl | None,
) -> bool:
    """Require two stable identity/geometry samples before a hub click."""

    if first is None or second is None or not first.clean or not second.clean:
        return False
    if (
        first.manager_quang_truong != second.manager_quang_truong
        or first.panel_chinh_phuc != second.panel_chinh_phuc
        or first.panel_native != second.panel_native
        or first.button_chinh_phuc != second.button_chinh_phuc
        or first.button_native != second.button_native
        or first.root_transform != second.root_transform
        or first.panel_active is not False
        or second.panel_active is not False
        or first.button_active is not True
        or second.button_active is not True
        or first.viewport_rect is None
        or second.viewport_rect is None
        or first.root_aspect is None
        or second.root_aspect is None
        or abs(first.root_aspect - second.root_aspect) > 0.002
    ):
        return False
    return all(
        abs(left - right) <= 0.003
        for left, right in zip(first.viewport_rect, second.viewport_rect)
    )


def locate_hub_chinh_phuc_control(
    rgb: bytes,
    width: int,
    height: int,
    control: HubChinhPhucControl,
) -> HubControlLocation:
    """Map native Canvas geometry to the captured client and sanity-check it."""

    if (
        not control.clean
        or control.viewport_rect is None
        or control.root_aspect is None
        or width < 640
        or height < 360
        or len(rgb) != width * height * 3
    ):
        return HubControlLocation(False, None, None, "invalid_hub_control", {})
    transform = transform_for_capture(rgb, width, height)
    rect = control.viewport_rect
    left, top, right, bottom = rect
    viewport_aspect = transform.viewport_width / transform.viewport_height
    if (
        not math.isfinite(control.root_aspect)
        or abs(control.root_aspect - viewport_aspect) > 0.01
        or not all(0.0 <= value <= 1.0 for value in rect)
        or not 0.015 <= right - left <= 0.30
        or not 0.02 <= bottom - top <= 0.35
    ):
        return HubControlLocation(
            False,
            None,
            None,
            "native_hub_canvas_mismatch",
            {"rootAspect": control.root_aspect, "viewportAspect": viewport_aspect},
        )
    mapped = transform.viewport_rect(rect)
    x0 = max(0, min(width - 1, round(mapped[0] * width)))
    y0 = max(0, min(height - 1, round(mapped[1] * height)))
    x1 = max(x0 + 1, min(width, round(mapped[2] * width)))
    y1 = max(y0 + 1, min(height, round(mapped[3] * height)))
    samples = (x1 - x0) * (y1 - y0)
    bright = colorful = 0
    minimum = 255
    maximum = 0
    for y in range(y0, y1):
        for x in range(x0, x1):
            offset = (y * width + x) * 3
            red, green, blue = rgb[offset : offset + 3]
            high, low = max(red, green, blue), min(red, green, blue)
            minimum = min(minimum, low)
            maximum = max(maximum, high)
            bright += int(high >= 155)
            colorful += int(high - low >= 45)
    metrics: dict[str, float | int | str] = {
        "samples": samples,
        "dynamicRange": maximum - minimum,
        "brightRatio": bright / max(1, samples),
        "colorfulRatio": colorful / max(1, samples),
        "layoutMode": transform.mode,
    }
    if (
        samples < 300
        or maximum - minimum < 70
        or bright / max(1, samples) < 0.015
        or colorful / max(1, samples) < 0.025
    ):
        return HubControlLocation(
            False, None, mapped, "native_hub_visual_sanity_failed", metrics
        )
    point = ((mapped[0] + mapped[2]) / 2.0, (mapped[1] + mapped[3]) / 2.0)
    return HubControlLocation(
        True, point, mapped, "exact_manager_button_native_geometry", metrics
    )


__all__ = [
    "HubChinhPhucControl",
    "HubControlLocation",
    "locate_hub_chinh_phuc_control",
    "read_hub_chinh_phuc_control",
    "same_clean_hub_chinh_phuc_control",
]
