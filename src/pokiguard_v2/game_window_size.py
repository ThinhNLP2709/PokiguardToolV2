"""Supported client-size profiles for the Pokiguard game window."""

from __future__ import annotations

from enum import Enum


class GameWindowSizeProfile(str, Enum):
    """Stable preference values for bounded, aspect-safe game client sizes."""

    COMPACT = "compact_800x400"
    SMALL = "small_960x480"
    MEDIUM = "medium_1120x560"
    ORIGINAL = "original_1280x640"

    @property
    def dimensions(self) -> tuple[int, int]:
        return GAME_WINDOW_SIZE_DIMENSIONS[self]

    @property
    def width(self) -> int:
        return self.dimensions[0]

    @property
    def height(self) -> int:
        return self.dimensions[1]


GAME_WINDOW_SIZE_DIMENSIONS = {
    GameWindowSizeProfile.COMPACT: (800, 400),
    GameWindowSizeProfile.SMALL: (960, 480),
    GameWindowSizeProfile.MEDIUM: (1120, 560),
    GameWindowSizeProfile.ORIGINAL: (1280, 640),
}

DEFAULT_GAME_WINDOW_SIZE_PROFILE = GameWindowSizeProfile.ORIGINAL


__all__ = [
    "DEFAULT_GAME_WINDOW_SIZE_PROFILE",
    "GAME_WINDOW_SIZE_DIMENSIONS",
    "GameWindowSizeProfile",
]
