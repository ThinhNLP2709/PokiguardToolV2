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
        # Pokiguard 1.7.4 live 1280x640 DotsArea evidence: grid boundaries
        # x=438..840 and y=79..481, with about 50.25 px between centres.
        "board_first_center_x": 0.3620,
        "board_first_center_y": 0.1625,
        "board_step_x": 0.0393,
        "board_step_y": 0.0787,
    }
)


def production_input_calibration() -> dict[str, Any]:
    """Return an isolated mutable copy for legacy Namespace consumers."""

    return dict(PRODUCTION_INPUT_CALIBRATION)


__all__ = ["PRODUCTION_INPUT_CALIBRATION", "production_input_calibration"]
