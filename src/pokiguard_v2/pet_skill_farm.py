"""Single-owner FarmRunner dispatch semantics for one Pet Skill proposal."""

from __future__ import annotations

from dataclasses import dataclass
from enum import Enum
import threading
from typing import Any, Callable, Hashable

from .pet_skill_action import PetSkillActionResult


class PetSkillDispatchState(str, Enum):
    ZERO_INPUT_FRESH_STATE_REQUIRED = "ZERO_INPUT_FRESH_STATE_REQUIRED"
    PET_SKILL_RESOLVING = "PET_SKILL_RESOLVING"
    PET_SKILL_UNCERTAIN_RESOLVING = "PET_SKILL_UNCERTAIN_RESOLVING"
    SOURCE_TURN_ALREADY_CLOSED = "SOURCE_TURN_ALREADY_CLOSED"
    LEASE_DENIED = "LEASE_DENIED"


@dataclass(frozen=True)
class PetSkillDispatchOutcome:
    state: PetSkillDispatchState
    result: PetSkillActionResult | None
    input_sent: bool
    lease_acquired: bool
    lease_resolved: bool
    source_turn_closed: bool
    allow_same_turn_fallback: bool
    fresh_state_required: bool


class PetSkillFarmDispatcher:
    """Serialize one primitive call and permanently fence any touched turn."""

    def __init__(self) -> None:
        self._lock = threading.Lock()
        self._closed_sources: set[Hashable] = set()
        self._active = 0
        self.max_simultaneous = 0
        self.primitive_calls = 0

    def dispatch(
        self,
        *,
        source: Hashable,
        acquire: Callable[[], Any | None],
        primitive: Callable[[], PetSkillActionResult | None],
        complete: Callable[[Any, bool, str], bool],
        abandon: Callable[[Any, str], bool],
    ) -> PetSkillDispatchOutcome:
        with self._lock:
            if source in self._closed_sources:
                return PetSkillDispatchOutcome(
                    PetSkillDispatchState.SOURCE_TURN_ALREADY_CLOSED,
                    None,
                    False,
                    False,
                    True,
                    True,
                    False,
                    False,
                )
            permit = acquire()
            if permit is None:
                return PetSkillDispatchOutcome(
                    PetSkillDispatchState.LEASE_DENIED,
                    None,
                    False,
                    False,
                    False,
                    False,
                    False,
                    False,
                )
            self._active += 1
            self.max_simultaneous = max(self.max_simultaneous, self._active)
            try:
                self.primitive_calls += 1
                result = primitive()
            finally:
                self._active -= 1

            input_sent = bool(result is not None and result.card_clicks > 0)
            if not input_sent:
                resolved = abandon(
                    permit,
                    "PET_SKILL zero-input result; fresh state required",
                )
                return PetSkillDispatchOutcome(
                    PetSkillDispatchState.ZERO_INPUT_FRESH_STATE_REQUIRED,
                    result,
                    False,
                    True,
                    resolved,
                    False,
                    False,
                    True,
                )

            resolved = complete(
                permit,
                True,
                f"PET_SKILL:{result.kind.value};cardClicks={result.card_clicks}",
            )
            self._closed_sources.add(source)
            return PetSkillDispatchOutcome(
                (
                    PetSkillDispatchState.PET_SKILL_RESOLVING
                    if result.success
                    else PetSkillDispatchState.PET_SKILL_UNCERTAIN_RESOLVING
                ),
                result,
                True,
                True,
                resolved,
                True,
                False,
                False,
            )

    def later_turn_allowed(self, source: Hashable) -> bool:
        return source not in self._closed_sources


__all__ = [
    "PetSkillDispatchOutcome",
    "PetSkillDispatchState",
    "PetSkillFarmDispatcher",
]
