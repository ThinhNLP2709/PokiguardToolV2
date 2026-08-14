"""Audit artifact writer for first sequence-desync detection."""

from __future__ import annotations

from dataclasses import dataclass
from datetime import datetime, timezone
import json
from pathlib import Path
import re
from typing import Any, Callable, Iterable, Mapping

from .board_diagnostics import game_state_payload
from .sequence_desync import SequenceDesyncState, sequence_jsonable
from .state import GameState


ScreenshotWriter = Callable[[Path], Mapping[str, Any] | None]


@dataclass(frozen=True)
class SequenceDesyncArtifact:
    directory: Path
    state_json: Path
    board_json: Path
    screenshot: Path
    recent_events_json: Path


def _directory_name(timestamp: str, match_id: str | None) -> str:
    cleaned = re.sub(r"[^0-9A-Za-z_-]+", "_", timestamp).strip("_")
    if not cleaned:
        cleaned = datetime.now(timezone.utc).strftime("%Y%m%d_%H%M%S_%f")
    match = re.sub(r"[^0-9A-Za-z_-]+", "_", match_id or "unknown_match")
    return f"{cleaned}_{match}"


def write_sequence_desync_artifact(
    root: Path,
    *,
    desync: SequenceDesyncState,
    state: GameState,
    recent_events: Iterable[Mapping[str, Any]],
    screenshot_writer: ScreenshotWriter,
    correlation: Mapping[str, Any] | None = None,
) -> SequenceDesyncArtifact:
    if not desync.detected or not desync.terminal_for_session:
        raise ValueError("sequence artifact requires terminal desync state")
    if state.board is None:
        raise ValueError("sequence artifact requires the last valid 64-cell board")
    if state.battle.match_id != desync.match_id:
        raise ValueError("artifact board belongs to a different match")
    if screenshot_writer is None:
        raise ValueError("sequence artifact requires screenshot capture")

    directory = root / _directory_name(desync.first_seen_at or "", desync.match_id)
    directory.mkdir(parents=True, exist_ok=False)
    state_path = directory / "state.json"
    board_path = directory / "board.json"
    screenshot_path = directory / "screenshot.png"
    events_path = directory / "recent_events.json"

    screenshot_metadata = screenshot_writer(screenshot_path)
    if not screenshot_path.is_file() or screenshot_path.stat().st_size == 0:
        raise RuntimeError("screenshot writer did not create screenshot.png")
    state_payload = {
        "schema": "pokiguard.sequence_desync.v1",
        "desync": desync,
        "screenshot": screenshot_metadata,
        "fusionCorrelation": dict(correlation or {}),
        "causalityClaim": None,
        "protocolRepairAttempted": False,
    }
    state_path.write_text(
        json.dumps(sequence_jsonable(state_payload), ensure_ascii=False, indent=2),
        encoding="utf-8",
    )
    board_path.write_text(
        json.dumps(game_state_payload(state), ensure_ascii=False, indent=2),
        encoding="utf-8",
    )
    events_path.write_text(
        json.dumps(
            {
                "schema": "pokiguard.sequence_events.v1",
                "events": sequence_jsonable(tuple(recent_events)),
            },
            ensure_ascii=False,
            indent=2,
        ),
        encoding="utf-8",
    )
    return SequenceDesyncArtifact(
        directory,
        state_path,
        board_path,
        screenshot_path,
        events_path,
    )


__all__ = ["SequenceDesyncArtifact", "write_sequence_desync_artifact"]
