"""Accepted normal-input calibration used by the production V2 controller.

These values were previously loaded incidentally from the read-only V1
checkout.  Keeping the accepted V2 runtime boundary here makes the packaged
application standalone without changing solver or input behavior.
"""

from __future__ import annotations

from types import MappingProxyType
from typing import Any, Mapping


PRODUCTION_INPUT_CALIBRATION: Mapping[str, Any] = MappingProxyType(
    {
        # 1.7.4 live evidence showed that correct tile-centre cursor movement
        # can still be dropped by Unity when the two button pulses are packed
        # too tightly.  Keep the complete pair comfortably below one second,
        # but allow the first tap to be rendered before selecting its neighbour.
        "click_delay_seconds": 0.35,
        "cursor_settle_seconds": 0.06,
        # PetPuzzle 1.7.4.9 MatchHudV2, canonical 1280x640 client:
        # opening-frame centres are approximately (430.5, 59.5), with
        # 59.75 px pitch. Board.ComputeEvenGridCellLayout/GetCellBaseWorldPosition
        # confirm an even 8x8 grid; these are client pixels, not world units.
        # Divide by w-1/h-1 to match map_swap_to_pixels, including its scaling.
        # Evidence: docs/artifacts/game_1_7_4_9_20261020/board_mapping_fix_20261021/.
        "board_first_center_x": 430.5 / 1279,
        "board_first_center_y": 59.5 / 639,
        "board_step_x": 59.75 / 1279,
        "board_step_y": 59.75 / 639,
    }
)


def production_input_calibration() -> dict[str, Any]:
    """Return an isolated mutable copy for legacy Namespace consumers."""

    return dict(PRODUCTION_INPUT_CALIBRATION)


__all__ = ["PRODUCTION_INPUT_CALIBRATION", "production_input_calibration"]
