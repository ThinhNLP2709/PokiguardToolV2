"""Map Unity UI coordinate spaces onto the current game viewport.

Pokiguard 1.7.4 keeps lobby and legacy-modal controls on a height-scaled,
left-anchored 16:9 canvas inside its 2:1 viewport.  Combat cards, the current
postmatch overlay, and the Board DotsArea use the complete viewport instead.
Callers must select the coordinate space proven for their control.
"""

from __future__ import annotations

from dataclasses import dataclass


REFERENCE_WIDTH = 1280
REFERENCE_HEIGHT = 720
REFERENCE_ASPECT = REFERENCE_WIDTH / REFERENCE_HEIGHT
CURRENT_VIEWPORT_ASPECT = 2.0


@dataclass(frozen=True)
class UnityUiTransform:
    client_width: int
    client_height: int
    viewport_left: int
    viewport_top: int
    viewport_width: int
    viewport_height: int
    canvas_left: float
    canvas_top: float
    canvas_width: float
    canvas_height: float
    mode: str

    def point(self, reference: tuple[float, float]) -> tuple[float, float]:
        """Return a client-normalized point from a reference-normalized point."""

        x, y = reference
        if self.mode == "REFERENCE_16_9":
            return x, y
        return (
            (self.canvas_left + x * self.canvas_width) / self.client_width,
            (self.canvas_top + y * self.canvas_height) / self.client_height,
        )

    def rect(
        self, reference: tuple[float, float, float, float]
    ) -> tuple[float, float, float, float]:
        left, top, right, bottom = reference
        mapped_left, mapped_top = self.point((left, top))
        mapped_right, mapped_bottom = self.point((right, bottom))
        return mapped_left, mapped_top, mapped_right, mapped_bottom

    def viewport_point(
        self, reference: tuple[float, float]
    ) -> tuple[float, float]:
        """Map a point against the complete active gameplay viewport."""

        x, y = reference
        return (
            (self.viewport_left + x * self.viewport_width) / self.client_width,
            (self.viewport_top + y * self.viewport_height) / self.client_height,
        )

    def viewport_rect(
        self, reference: tuple[float, float, float, float]
    ) -> tuple[float, float, float, float]:
        left, top, right, bottom = reference
        mapped_left, mapped_top = self.viewport_point((left, top))
        mapped_right, mapped_bottom = self.viewport_point((right, bottom))
        return mapped_left, mapped_top, mapped_right, mapped_bottom

    def reference_point(self, client: tuple[float, float]) -> tuple[float, float]:
        """Return a reference-normalized point from a client-normalized point."""

        x, y = client
        if self.mode == "REFERENCE_16_9":
            return x, y
        return (
            (x * self.client_width - self.canvas_left) / self.canvas_width,
            (y * self.client_height - self.canvas_top) / self.canvas_height,
        )

    @property
    def canvas_area(self) -> float:
        return self.canvas_width * self.canvas_height


def _identity(width: int, height: int) -> UnityUiTransform:
    return UnityUiTransform(
        width,
        height,
        0,
        0,
        width,
        height,
        0.0,
        0.0,
        float(width),
        float(height),
        "REFERENCE_16_9",
    )


def _wide_viewport(
    width: int,
    height: int,
    *,
    viewport_top: int = 0,
    viewport_height: int | None = None,
    mode: str = "POKIGUARD_2_1",
) -> UnityUiTransform:
    active_height = int(viewport_height if viewport_height is not None else height)
    canvas_width = active_height * REFERENCE_ASPECT
    return UnityUiTransform(
        width,
        height,
        0,
        int(viewport_top),
        width,
        active_height,
        0.0,
        float(viewport_top),
        canvas_width,
        float(active_height),
        mode,
    )


def transform_for_client(width: int, height: int) -> UnityUiTransform:
    """Infer layout from a prepared client with no screenshot dependency."""

    if width <= 0 or height <= 0:
        raise ValueError("client dimensions must be positive")
    if width / height >= 1.90:
        return _wide_viewport(width, height)
    return _identity(width, height)


def _row_has_content(rgb: bytes, width: int, y: int) -> bool:
    # Sample enough of the row to reject a true black presentation bar without
    # paying for a full-frame scan on every card proof.
    samples = 0
    non_black = 0
    step = max(1, width // 160)
    row = y * width * 3
    for x in range(0, width, step):
        offset = row + x * 3
        samples += 1
        if max(rgb[offset], rgb[offset + 1], rgb[offset + 2]) > 18:
            non_black += 1
    return non_black >= max(3, round(samples * 0.04))


def transform_for_capture(
    rgb: bytes, width: int, height: int
) -> UnityUiTransform:
    """Infer the 1.7.4 viewport, including the old 1280x720 preflight bars."""

    if width <= 0 or height <= 0 or len(rgb) != width * height * 3:
        raise ValueError("invalid RGB client capture")
    direct = transform_for_client(width, height)
    if direct.mode == "POKIGUARD_2_1":
        return direct

    # Compatibility with evidence captured before the preflight was updated:
    # 1280x720 contains a centered 1280x640 viewport and 40-pixel black bars.
    search_limit = max(1, height // 4)
    top = next(
        (row for row in range(search_limit) if _row_has_content(rgb, width, row)),
        0,
    )
    bottom = next(
        (
            row + 1
            for row in range(height - 1, height - search_limit - 1, -1)
            if _row_has_content(rgb, width, row)
        ),
        height,
    )
    active_height = bottom - top
    bottom_bar = height - bottom
    if (
        top >= 2
        and bottom_bar >= 2
        and abs(top - bottom_bar) <= 3
        and active_height >= 360
        and width / active_height >= 1.90
    ):
        return _wide_viewport(
            width,
            height,
            viewport_top=top,
            viewport_height=active_height,
            mode="POKIGUARD_2_1_LETTERBOXED",
        )
    return direct


__all__ = [
    "CURRENT_VIEWPORT_ASPECT",
    "REFERENCE_ASPECT",
    "REFERENCE_HEIGHT",
    "REFERENCE_WIDTH",
    "UnityUiTransform",
    "transform_for_capture",
    "transform_for_client",
]
