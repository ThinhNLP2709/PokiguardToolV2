"""Versioned, non-authoritative operator preferences for the desktop UI.

Preferences contain only supported UI draft values.  They never contain farm
ownership, checkpoint history, executable combat state, or an auto-start flag.
"""

from __future__ import annotations

from dataclasses import dataclass
import json
import os
from pathlib import Path
import tempfile
from typing import Any

from .desktop_control_plane import DesktopConfig, utc_timestamp


PREFERENCE_SCHEMA = "pokiguard.desktop_preferences.v1"


class PreferenceError(RuntimeError):
    def __init__(self, reason: str, message: str) -> None:
        super().__init__(message)
        self.reason = reason


@dataclass(frozen=True)
class PreferenceWarning:
    reason: str
    message: str


@dataclass(frozen=True)
class PreferenceLoadResult:
    config: DesktopConfig
    loaded: bool
    warnings: tuple[PreferenceWarning, ...] = ()


class DesktopPreferenceStore:
    """Atomic JSON storage kept deliberately separate from farm checkpoints."""

    def __init__(self, path: Path) -> None:
        self.path = path.resolve()

    def load(self, *, defaults: DesktopConfig | None = None) -> PreferenceLoadResult:
        safe_defaults = defaults or DesktopConfig()
        if not self.path.is_file():
            return PreferenceLoadResult(safe_defaults, False)
        try:
            raw = json.loads(self.path.read_text(encoding="utf-8"))
            if not isinstance(raw, dict):
                raise PreferenceError(
                    "PREFERENCE_ROOT_INVALID", "preference root must be an object"
                )
            if raw.get("schema") != PREFERENCE_SCHEMA:
                raise PreferenceError(
                    "PREFERENCE_SCHEMA_UNSUPPORTED",
                    f"unsupported preference schema: {raw.get('schema')!r}",
                )
            config_raw = raw.get("config")
            if not isinstance(config_raw, dict):
                raise PreferenceError(
                    "PREFERENCE_CONFIG_INVALID", "preference config must be an object"
                )
            config = DesktopConfig.from_strings(
                play_style=str(config_raw.get("play_style", "")),
                mana_priority=str(config_raw.get("mana_priority", "")),
                intelligence=str(config_raw.get("intelligence", "")),
                # Target identity is farm-session authority and is never
                # restored from preferences, including older v1 files.
                boss_id="",
                boss_name="",
                target_completed_matches=str(
                    config_raw.get("target_completed_matches", "")
                ),
                # Legacy preference accepted but no longer exposed/enforced.
                max_technical_recoveries=str(
                    config_raw.get("max_technical_recoveries", 1)
                ),
                max_match_attempts=str(config_raw.get("max_match_attempts", "")),
            ).without_target()
            return PreferenceLoadResult(config, True)
        except (json.JSONDecodeError, OSError, PreferenceError, TypeError, ValueError) as exc:
            reason = getattr(exc, "reason", "PREFERENCE_LOAD_INVALID")
            warning = PreferenceWarning(reason, f"{type(exc).__name__}: {exc}")
            return PreferenceLoadResult(safe_defaults, False, (warning,))

    def save(self, config: DesktopConfig) -> None:
        if not isinstance(config, DesktopConfig):
            raise TypeError("config must be DesktopConfig")
        payload: dict[str, Any] = {
            "schema": PREFERENCE_SCHEMA,
            "saved_at": utc_timestamp(),
            "config": {
                "play_style": config.play_style.value,
                "mana_priority": config.mana_priority.value,
                "intelligence": config.intelligence.value,
                "boss_id": None,
                "boss_name": None,
                "target_completed_matches": config.target_completed_matches,
                "max_match_attempts": config.max_match_attempts,
            },
        }
        self.path.parent.mkdir(parents=True, exist_ok=True)
        temporary: Path | None = None
        try:
            with tempfile.NamedTemporaryFile(
                "w",
                encoding="utf-8",
                dir=self.path.parent,
                prefix=f".{self.path.name}.",
                suffix=".tmp",
                delete=False,
            ) as handle:
                temporary = Path(handle.name)
                json.dump(payload, handle, ensure_ascii=False, indent=2)
                handle.write("\n")
                handle.flush()
                os.fsync(handle.fileno())
            os.replace(temporary, self.path)
        except (OSError, TypeError, ValueError) as exc:
            if temporary is not None:
                try:
                    temporary.unlink(missing_ok=True)
                except OSError:
                    pass
            raise PreferenceError(
                "PREFERENCE_SAVE_FAILED", f"could not save preferences: {exc}"
            ) from exc


__all__ = [
    "DesktopPreferenceStore",
    "PREFERENCE_SCHEMA",
    "PreferenceError",
    "PreferenceLoadResult",
    "PreferenceWarning",
]
