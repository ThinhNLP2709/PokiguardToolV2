"""Pure coordinate/label helpers for the Phase 2B.5 visual audit."""

from __future__ import annotations

from dataclasses import dataclass

from .live_state import runtime_row_to_screen_row, screen_row_to_runtime_row


@dataclass(frozen=True)
class BoardGeometry:
    """Normalized game-client geometry inherited from the verified V1 setup."""

    first_center_x: float = 0.360
    first_center_y: float = 0.150
    step_x: float = 0.0410
    step_y: float = 0.0760

    def __post_init__(self) -> None:
        values = (
            self.first_center_x,
            self.first_center_y,
            self.step_x,
            self.step_y,
        )
        if any(not 0.0 < value < 1.0 for value in values):
            raise ValueError("normalized board geometry values must be inside (0,1)")
        if self.first_center_x + 7 * self.step_x >= 1.0:
            raise ValueError("board x geometry leaves the client area")
        if self.first_center_y + 7 * self.step_y >= 1.0:
            raise ValueError("board y geometry leaves the client area")

    def center(self, width: int, height: int, screen_row: int, col: int) -> tuple[int, int]:
        if width <= 0 or height <= 0:
            raise ValueError("client size must be positive")
        if not 0 <= screen_row < 8 or not 0 <= col < 8:
            raise ValueError("cell coordinate must be inside the 8x8 board")
        return (
            round((self.first_center_x + col * self.step_x) * width),
            round((self.first_center_y + screen_row * self.step_y) * height),
        )

    def half_cell(self, width: int, height: int) -> tuple[int, int]:
        if width <= 0 or height <= 0:
            raise ValueError("client size must be positive")
        return max(1, round(self.step_x * width / 2)), max(
            1, round(self.step_y * height / 2)
        )


def screen_move_to_runtime(
    first: tuple[int, int] | None,
    second: tuple[int, int] | None,
) -> dict[str, dict[str, int]] | None:
    """Represent a solver move in both coordinate systems without clicking."""

    if first is None or second is None:
        return None
    first_row, first_col = first
    second_row, second_col = second
    return {
        "fromScreen": {"row": first_row, "col": first_col},
        "toScreen": {"row": second_row, "col": second_col},
        "fromRuntime": {
            "row": screen_row_to_runtime_row(first_row),
            "col": first_col,
        },
        "toRuntime": {
            "row": screen_row_to_runtime_row(second_row),
            "col": second_col,
        },
    }


__all__ = [
    "BoardGeometry",
    "runtime_row_to_screen_row",
    "screen_row_to_runtime_row",
    "screen_move_to_runtime",
]
