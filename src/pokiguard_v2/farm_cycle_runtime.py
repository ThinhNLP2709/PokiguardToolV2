"""Dependency-injected Phase 2D.2 capability adapters and coordinator."""

from __future__ import annotations

from dataclasses import dataclass
from enum import Enum
from typing import Protocol

from .boss_entry import BossLobbyState
from .farm_cycle import (
    EntryPermit,
    FarmCycle,
    FarmCycleStopReason,
    GameplayPermit,
    InputDomain,
    OpeningEvidence,
)
from .state import CombatSessionKey


_ACTION_DOMAINS = {
    "SWAP": InputDomain.GAMEPLAY_SWAP,
    "CAST": InputDomain.GAMEPLAY_CAST,
    "EVOLVE": InputDomain.GAMEPLAY_EVOLVE,
    "PASS": InputDomain.GAMEPLAY_PASS,
}


class FarmEntryCapability:
    """One entry-number-scoped capability used at the real click boundary."""

    def __init__(self, cycle: FarmCycle, entry_number: int) -> None:
        self._cycle = cycle
        self.entry_number = entry_number

    def reserve(self, *, foreground: bool) -> EntryPermit | None:
        return self._cycle.reserve_entry(entry_number=self.entry_number, foreground=foreground)

    def complete(self, permit: EntryPermit, *, sent: bool, detail: str = "") -> bool:
        return self._cycle.complete_entry(permit, sent=sent, detail=detail)

    def cancel(self, permit: EntryPermit, *, detail: str = "") -> bool:
        return self._cycle.cancel_entry(permit, detail=detail)


class FarmGameplayCapability:
    """Session-scoped B5 capability; no instance is created for combat #2."""

    def __init__(self, cycle: FarmCycle, session: CombatSessionKey) -> None:
        self._cycle = cycle
        self.session = session

    def reserve(
        self,
        *,
        action: str,
        session: CombatSessionKey,
        foreground: bool,
    ) -> GameplayPermit | None:
        domain = _ACTION_DOMAINS.get(action.upper())
        if domain is None:
            self._cycle.safe_stop(FarmCycleStopReason.GAMEPLAY_CAPABILITY_DENIED, action=action)
            return None
        return self._cycle.reserve_gameplay(domain, session, foreground=foreground)

    def complete(self, permit: GameplayPermit, *, sent: bool, detail: str = "") -> bool:
        return self._cycle.complete_gameplay(permit, sent=sent, detail=detail)

    def cancel(self, permit: GameplayPermit, *, detail: str = "") -> bool:
        return self._cycle.cancel_gameplay(permit, detail=detail)


class EntryResultKind(str, Enum):
    ACCEPTED = "ACCEPTED"
    SAFE_STOP = "SAFE_STOP"


@dataclass(frozen=True)
class EntryResult:
    kind: EntryResultKind
    session: CombatSessionKey | None = None
    opening: OpeningEvidence | None = None
    reason: str = ""


@dataclass(frozen=True)
class CombatResult:
    lifecycle_ended: bool
    postmatch_observed: bool = False
    safe_stop: bool = False
    reason: str = ""


class EntryPort(Protocol):
    def enter(self, *, entry_number: int, capability: FarmEntryCapability) -> EntryResult: ...


class CombatPort(Protocol):
    def play_one(
        self,
        *,
        session: CombatSessionKey,
        capability: FarmGameplayCapability,
    ) -> CombatResult: ...


class LobbyPort(Protocol):
    def wait_for_lobby(self, *, initial: bool) -> BossLobbyState: ...


class FarmCycleCoordinator:
    """Offline coordinator: two entry calls and one combat call, never more."""

    def __init__(self, cycle: FarmCycle, *, lobby: LobbyPort, entry: EntryPort, combat: CombatPort) -> None:
        self.cycle = cycle
        self._lobby = lobby
        self._entry = entry
        self._combat = combat

    def run(self) -> FarmCycle:
        if not self.cycle.observe_initial_lobby(self._lobby.wait_for_lobby(initial=True)):
            return self.cycle
        if not self._run_entry(1):
            return self.cycle
        session1 = self.cycle.snapshot().session1
        assert session1 is not None
        if not self.cycle.begin_combat1_play(session1):
            return self.cycle
        result = self._combat.play_one(
            session=session1,
            capability=FarmGameplayCapability(self.cycle, session1),
        )
        if not result.lifecycle_ended or result.safe_stop:
            self.cycle.combat1_finished(safe_stop=True, detail=result.reason)
            return self.cycle
        if not self.cycle.combat1_finished(detail=result.reason):
            return self.cycle
        if not result.postmatch_observed or not self.cycle.observe_postmatch():
            self.cycle.safe_stop(FarmCycleStopReason.POSTMATCH_UI_AMBIGUOUS)
            return self.cycle
        if not self.cycle.observe_return_lobby(self._lobby.wait_for_lobby(initial=False)):
            return self.cycle
        self._run_entry(2)
        return self.cycle

    def _run_entry(self, entry_number: int) -> bool:
        if not self.cycle.target_resolved(entry_number=entry_number):
            return False
        result = self._entry.enter(
            entry_number=entry_number,
            capability=FarmEntryCapability(self.cycle, entry_number),
        )
        if result.kind is not EntryResultKind.ACCEPTED or result.session is None or result.opening is None:
            self.cycle.safe_stop(
                FarmCycleStopReason.OPENING_INVARIANT_FAILED,
                entryNumber=entry_number,
                detail=result.reason,
            )
            return False
        if not self.cycle.accept_session(result.session):
            return False
        return self.cycle.accept_opening(result.opening)


__all__ = [
    "CombatPort", "CombatResult", "EntryPort", "EntryResult", "EntryResultKind",
    "FarmCycleCoordinator", "FarmEntryCapability", "FarmGameplayCapability", "LobbyPort",
]
