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
        "click_delay_seconds": 0.25,
        "board_first_center_x": 0.357,
        "board_first_center_y": 0.146,
        "board_step_x": 0.0410,
        "board_step_y": 0.0725,
    }
)


def production_input_calibration() -> dict[str, Any]:
    """Return an isolated mutable copy for legacy Namespace consumers."""

    return dict(PRODUCTION_INPUT_CALIBRATION)


__all__ = ["PRODUCTION_INPUT_CALIBRATION", "production_input_calibration"]
