"""Pure Phase 2D.1 boss-target and one-shot entry models.

This module contains no process access and no input path.  Runtime readers and
the command-line controller consume these deterministic, unit-testable rules.
"""

from __future__ import annotations

from dataclasses import dataclass
from enum import Enum
import hashlib
import json
import unicodedata


class BossLobbyState(str, Enum):
    BOSS_LOBBY = "BOSS_LOBBY"
    LOBBY_OTHER = "LOBBY_OTHER"
    ENTERING_COMBAT = "ENTERING_COMBAT"
    ACTIVE_COMBAT = "ACTIVE_COMBAT"
    POSTMATCH = "POSTMATCH"
    UNKNOWN = "UNKNOWN"


class BossEntryState(str, Enum):
    WAIT_BOSS_LOBBY = "WAIT_BOSS_LOBBY"
    RESOLVE_TARGET = "RESOLVE_TARGET"
    SELECT_TARGET_IF_NEEDED = "SELECT_TARGET_IF_NEEDED"
    VERIFY_TARGET_SELECTED = "VERIFY_TARGET_SELECTED"
    ENSURE_REQUIRED_CARDS = "ENSURE_REQUIRED_CARDS"
    LOCATE_ENTER_BUTTON = "LOCATE_ENTER_BUTTON"
    READY_TO_ENTER = "READY_TO_ENTER"
    ENTER_CLICK_SENT = "ENTER_CLICK_SENT"
    WAIT_ENTERING_COMBAT = "WAIT_ENTERING_COMBAT"
    WAIT_NEW_SESSION = "WAIT_NEW_SESSION"
    WAIT_OPENING_BOARD = "WAIT_OPENING_BOARD"
    ENTRY_CONFIRMED = "ENTRY_CONFIRMED"
    STOP = "STOP"


class TargetResolutionStatus(str, Enum):
    RESOLVED = "TARGET_RESOLVED"
    MISSING = "TARGET_MISSING"
    AMBIGUOUS = "TARGET_AMBIGUOUS"
    INVALID_CONFIG = "TARGET_CONFIG_INVALID"


class TargetSelectionState(str, Enum):
    SELECTED = "SELECTED"
    DIRECT_ENTRY_OWNER = "DIRECT_ENTRY_OWNER"
    NOT_SELECTED = "NOT_SELECTED"
    UNKNOWN = "UNKNOWN"


@dataclass(frozen=True)
class FarmTarget:
    boss_id: str | None = None
    boss_name: str | None = None

    def __post_init__(self) -> None:
        if self.boss_id is not None and not self.boss_id.strip():
            raise ValueError("boss_id cannot be blank")
        if self.boss_name is not None and not self.boss_name.strip():
            raise ValueError("boss_name cannot be blank")
        if self.boss_id is None and self.boss_name is None:
            raise ValueError("an exact boss_id or boss_name is required")


@dataclass(frozen=True)
class BossTargetIdentity:
    boss_id: str | None
    boss_name: str | None
    room_id: str | None = None
    pet_id: int | None = None
    source: str = "UNKNOWN"

    def stable_key(self) -> tuple[str | None, str | None, str | None, int | None, str]:
        return (
            self.boss_id.strip() if self.boss_id else None,
            normalize_exact_name(self.boss_name) if self.boss_name else None,
            self.room_id,
            self.pet_id,
            self.source,
        )


@dataclass(frozen=True)
class BossCandidate:
    index: int
    identity: BossTargetIdentity
    selection: TargetSelectionState
    available: bool
    active: bool | None
    entry_control_address: int | None = None
    screen_rect: tuple[float, float, float, float] | None = None
    evidence: tuple[str, ...] = ()


@dataclass(frozen=True)
class TargetResolution:
    status: TargetResolutionStatus
    target: FarmTarget
    candidate: BossCandidate | None
    matches: tuple[BossCandidate, ...]
    reason: str

    @property
    def resolved(self) -> bool:
        return self.status is TargetResolutionStatus.RESOLVED and self.candidate is not None


@dataclass(frozen=True)
class EntryAttemptIdentity:
    lobby_epoch: int
    target_key: tuple[str | None, str | None, str | None, int | None, str]
    selection: TargetSelectionState
    button_detected_at: str
    button_signature: str

    def digest(self) -> str:
        payload = json.dumps(
            {
                "lobbyEpoch": self.lobby_epoch,
                "target": self.target_key,
                "selection": self.selection.value,
                "buttonDetectedAt": self.button_detected_at,
                "buttonSignature": self.button_signature,
            },
            ensure_ascii=False,
            sort_keys=True,
            separators=(",", ":"),
        ).encode("utf-8")
        return hashlib.sha256(payload).hexdigest()


def normalize_exact_name(value: str) -> str:
    """Safe exact-name normalization: trim, NFC and Unicode case-fold only."""

    return unicodedata.normalize("NFC", value.strip()).casefold()


def resolve_target(
    target: FarmTarget,
    candidates: tuple[BossCandidate, ...] | list[BossCandidate],
) -> TargetResolution:
    """Resolve exactly one target; ID takes precedence when configured."""

    candidates = tuple(candidates)
    if target.boss_id is not None:
        wanted = target.boss_id.strip()
        matches = tuple(
            candidate
            for candidate in candidates
            if candidate.identity.boss_id is not None
            and candidate.identity.boss_id.strip() == wanted
        )
        rule = "exact_id"
    else:
        wanted_name = normalize_exact_name(target.boss_name or "")
        matches = tuple(
            candidate
            for candidate in candidates
            if candidate.identity.boss_name is not None
            and normalize_exact_name(candidate.identity.boss_name) == wanted_name
        )
        rule = "exact_normalized_name"

    if not matches:
        return TargetResolution(
            TargetResolutionStatus.MISSING,
            target,
            None,
            (),
            f"no candidate matched by {rule}",
        )
    if len(matches) != 1:
        return TargetResolution(
            TargetResolutionStatus.AMBIGUOUS,
            target,
            None,
            matches,
            f"{len(matches)} candidates matched by {rule}",
        )
    return TargetResolution(
        TargetResolutionStatus.RESOLVED,
        target,
        matches[0],
        matches,
        rule,
    )


def entry_button_signature(
    *,
    control: str,
    normalized_rect: tuple[float, float, float, float],
    normalized_point: tuple[float, float],
    client_size: tuple[int, int],
) -> str:
    """Hash stable locator structure, not animated pixels.

    Quantization tolerates one-pixel/color animation changes while still
    invalidating a moved or replaced control.
    """

    payload = {
        "control": control,
        "rect": [round(value, 3) for value in normalized_rect],
        "point": [round(value, 3) for value in normalized_point],
        "clientSize": list(client_size),
    }
    return hashlib.sha256(
        json.dumps(payload, sort_keys=True, separators=(",", ":")).encode("ascii")
    ).hexdigest()


__all__ = [
    "BossCandidate",
    "BossEntryState",
    "BossLobbyState",
    "BossTargetIdentity",
    "EntryAttemptIdentity",
    "FarmTarget",
    "TargetResolution",
    "TargetResolutionStatus",
    "TargetSelectionState",
    "entry_button_signature",
    "normalize_exact_name",
    "resolve_target",
]
