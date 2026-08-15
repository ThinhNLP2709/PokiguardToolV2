"""Pure Phase 2D.2 bounded farm-cycle safety model.

The model owns the two-entry/one-combat capability boundary. Live adapters
reserve immediately before an input boundary and report the actual result
immediately afterwards. A reservation is never counted as an input.
"""

from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum
import re
from typing import Any
from uuid import uuid4

from .boss_entry import BossLobbyState, FarmTarget
from .state import CombatSessionKey


class FarmCycleState(str, Enum):
    WAIT_INITIAL_BOSS_LOBBY = "WAIT_INITIAL_BOSS_LOBBY"
    ENTRY1_RESOLVE_TARGET = "ENTRY1_RESOLVE_TARGET"
    ENTRY1_READY = "ENTRY1_READY"
    ENTRY1_PENDING = "ENTRY1_PENDING"
    COMBAT1_WAIT_OPENING = "COMBAT1_WAIT_OPENING"
    COMBAT1_ACTIVE = "COMBAT1_ACTIVE"
    WAIT_POSTMATCH = "WAIT_POSTMATCH"
    WAIT_RETURN_BOSS_LOBBY = "WAIT_RETURN_BOSS_LOBBY"
    ENTRY2_RESOLVE_TARGET = "ENTRY2_RESOLVE_TARGET"
    ENTRY2_READY = "ENTRY2_READY"
    ENTRY2_PENDING = "ENTRY2_PENDING"
    COMBAT2_WAIT_OPENING = "COMBAT2_WAIT_OPENING"
    FARM_CYCLE_COMPLETE = "FARM_CYCLE_COMPLETE"
    SAFE_STOP = "SAFE_STOP"
    ERROR = "ERROR"


class FarmCycleStopReason(str, Enum):
    FARM_START_STATE_INVALID = "FARM_START_STATE_INVALID"
    TARGET_MISSING = "TARGET_MISSING"
    TARGET_AMBIGUOUS = "TARGET_AMBIGUOUS"
    TARGET_NOT_AVAILABLE = "TARGET_NOT_AVAILABLE"
    FOREGROUND_LOST = "FOREGROUND_LOST"
    ENTRY_LIMIT_VIOLATION = "FARM_ENTRY_LIMIT_VIOLATION"
    ENTRY_CAPABILITY_DENIED = "ENTRY_CAPABILITY_DENIED"
    ENTRY_INPUT_FAILED = "ENTRY_INPUT_FAILED"
    GAMEPLAY_CAPABILITY_DENIED = "GAMEPLAY_CAPABILITY_DENIED"
    SESSION_LIMIT_EXCEEDED = "SESSION_LIMIT_EXCEEDED"
    NEW_SESSION_NOT_PROVEN_NEW = "NEW_SESSION_NOT_PROVEN_NEW"
    OPENING_INVARIANT_FAILED = "OPENING_ACCEPTANCE_INVARIANT_FAILED"
    OPENING_ACTION_DEADLINE = "OPENING_ACTION_DEADLINE"
    COMBAT_SAFE_STOP = "COMBAT1_SAFE_STOP"
    COMBAT_SUMMARY_INVALID = "COMBAT1_SUMMARY_INVALID"
    POSTMATCH_UI_AMBIGUOUS = "POSTMATCH_UI_AMBIGUOUS"
    RETURN_LOBBY_TIMEOUT = "RETURN_LOBBY_TIMEOUT"
    STAGE_TIMEOUT = "FARM_STAGE_TIMEOUT"
    EMERGENCY_STOP = "F9_EMERGENCY_STOP"
    RETURNED_BOSS_LOBBY_READY = "RETURNED_BOSS_LOBBY_READY"
    SECOND_COMBAT_OPENING_READY = "SECOND_COMBAT_OPENING_READY"
    INTERNAL_INVARIANT = "FARM_INTERNAL_INVARIANT"


class InputDomain(str, Enum):
    BOSS_TARGET_SELECT = "BOSS_TARGET_SELECT"
    BOSS_ENTRY = "BOSS_ENTRY"
    POSTMATCH_UI = "POSTMATCH_UI"
    GAMEPLAY_SWAP = "GAMEPLAY_SWAP"
    GAMEPLAY_CAST = "GAMEPLAY_CAST"
    GAMEPLAY_EVOLVE = "GAMEPLAY_EVOLVE"
    GAMEPLAY_PASS = "GAMEPLAY_PASS"
    RECOVERY_UI = "RECOVERY_UI"

    @property
    def gameplay(self) -> bool:
        return self.value.startswith("GAMEPLAY_")


@dataclass(frozen=True)
class FarmCycleId:
    value: str

    @classmethod
    def create(cls) -> "FarmCycleId":
        return cls(uuid4().hex)


@dataclass(frozen=True)
class OpeningEvidence:
    session: CombatSessionKey
    match_id: str
    board_hash: str
    complete_cells: int
    unique_coordinates: int
    source: str
    first_local_turn: bool
    local_move_sequence: int | None
    stable_confirmations: int
    production_ready: bool = True
    gem_types_valid: bool = True
    multipliers_valid: bool = True
    fresh_dto: bool = True
    timer_safe: bool = True

    def valid(self) -> bool:
        return (
            self.session.match_id == self.match_id
            and re.fullmatch(r"[0-9a-fA-F]{64}", self.board_hash) is not None
            and self.complete_cells == 64
            and self.unique_coordinates == 64
            and self.source == "ChatMessageDTO.MATCH_START.matchPayload.board"
            and self.first_local_turn
            and self.local_move_sequence == 0
            and self.stable_confirmations >= 2
            and self.production_ready
            and self.gem_types_valid
            and self.multipliers_valid
            and self.fresh_dto
            and self.timer_safe
        )


@dataclass(frozen=True)
class InputRecord:
    domain: InputDomain
    session: CombatSessionKey | None
    sent: bool
    state: FarmCycleState
    detail: str = ""


@dataclass(frozen=True)
class EntryPermit:
    token: str
    entry_number: int


@dataclass(frozen=True)
class GameplayPermit:
    token: str
    domain: InputDomain
    session: CombatSessionKey


@dataclass(frozen=True)
class PostmatchPermit:
    token: str


@dataclass(frozen=True)
class FarmCycleEvent:
    index: int
    event: str
    state: FarmCycleState
    detail: dict[str, Any] = field(default_factory=dict)


@dataclass(frozen=True)
class FarmCycleSnapshot:
    cycle_id: FarmCycleId
    target: FarmTarget
    state: FarmCycleState
    entry_inputs_total: int
    combat_sessions_seen: int
    combat_sessions_played: int
    session1: CombatSessionKey | None
    session2: CombatSessionKey | None
    stop_reason: FarmCycleStopReason | None
    input_records: tuple[InputRecord, ...]
    events: tuple[FarmCycleEvent, ...]


class FarmCycle:
    """State and capability ledger for exactly two entries and one combat."""

    def __init__(self, target: FarmTarget, *, cycle_id: FarmCycleId | None = None) -> None:
        self._cycle_id = cycle_id or FarmCycleId.create()
        self._target = target
        self._state = FarmCycleState.WAIT_INITIAL_BOSS_LOBBY
        self._entry_inputs_total = 0
        self._combat_sessions_seen = 0
        self._combat_sessions_played = 0
        self._session1: CombatSessionKey | None = None
        self._session2: CombatSessionKey | None = None
        self._gameplay_session: CombatSessionKey | None = None
        self._entry_sent = False
        self._pending_entry: EntryPermit | None = None
        self._pending_gameplay: GameplayPermit | None = None
        self._pending_postmatch: PostmatchPermit | None = None
        self._stop_reason: FarmCycleStopReason | None = None
        self._records: list[InputRecord] = []
        self._events: list[FarmCycleEvent] = []
        self._event("farm_cycle_started", target=target)

    @property
    def state(self) -> FarmCycleState:
        return self._state

    @property
    def target(self) -> FarmTarget:
        return self._target

    @property
    def cycle_id(self) -> FarmCycleId:
        return self._cycle_id

    @property
    def stopped(self) -> bool:
        return self._state in {
            FarmCycleState.FARM_CYCLE_COMPLETE,
            FarmCycleState.SAFE_STOP,
            FarmCycleState.ERROR,
        }

    def snapshot(self) -> FarmCycleSnapshot:
        return FarmCycleSnapshot(
            self._cycle_id, self._target, self._state, self._entry_inputs_total,
            self._combat_sessions_seen, self._combat_sessions_played, self._session1,
            self._session2, self._stop_reason, tuple(self._records), tuple(self._events),
        )

    def observe_initial_lobby(self, lobby: BossLobbyState) -> bool:
        if self._state is not FarmCycleState.WAIT_INITIAL_BOSS_LOBBY:
            return self._reject("initial_lobby_out_of_order")
        if lobby is not BossLobbyState.BOSS_LOBBY:
            self.safe_stop(FarmCycleStopReason.FARM_START_STATE_INVALID, lobby=lobby.value)
            return False
        self._transition(FarmCycleState.ENTRY1_RESOLVE_TARGET, "initial_boss_lobby_ready")
        return True

    def target_resolved(self, *, entry_number: int) -> bool:
        expected = {1: FarmCycleState.ENTRY1_RESOLVE_TARGET, 2: FarmCycleState.ENTRY2_RESOLVE_TARGET}.get(entry_number)
        ready = {1: FarmCycleState.ENTRY1_READY, 2: FarmCycleState.ENTRY2_READY}.get(entry_number)
        if expected is None or ready is None or self._state is not expected:
            return self._reject("target_resolution_out_of_order", entryNumber=entry_number)
        self._transition(ready, "farm_target_resolved", entryNumber=entry_number)
        return True

    def reserve_entry(self, *, entry_number: int, foreground: bool) -> EntryPermit | None:
        expected = {1: FarmCycleState.ENTRY1_READY, 2: FarmCycleState.ENTRY2_READY}.get(entry_number)
        pending = {1: FarmCycleState.ENTRY1_PENDING, 2: FarmCycleState.ENTRY2_PENDING}.get(entry_number)
        if expected is None or pending is None:
            self.safe_stop(FarmCycleStopReason.ENTRY_LIMIT_VIOLATION, entryNumber=entry_number)
            self._reject("entry_out_of_order", entryNumber=entry_number)
            return None
        if self._state is not expected:
            if self._state in {FarmCycleState.ENTRY1_PENDING, FarmCycleState.ENTRY2_PENDING}:
                self.safe_stop(FarmCycleStopReason.ENTRY_CAPABILITY_DENIED, entryNumber=entry_number)
            self._reject("entry_out_of_order", entryNumber=entry_number)
            return None
        if self._pending_entry is not None or self._entry_sent:
            self.safe_stop(FarmCycleStopReason.ENTRY_CAPABILITY_DENIED, entryNumber=entry_number)
            return None
        if not foreground:
            self.safe_stop(FarmCycleStopReason.FOREGROUND_LOST, entryNumber=entry_number)
            return None
        if self._entry_inputs_total >= 2 or entry_number != self._entry_inputs_total + 1:
            self.safe_stop(FarmCycleStopReason.ENTRY_LIMIT_VIOLATION, entryNumber=entry_number)
            return None
        permit = EntryPermit(uuid4().hex, entry_number)
        self._pending_entry = permit
        self._transition(pending, "entry_input_reserved", entryNumber=entry_number)
        return permit

    def complete_entry(self, permit: EntryPermit, *, sent: bool, detail: str = "") -> bool:
        if permit != self._pending_entry:
            self.safe_stop(FarmCycleStopReason.ENTRY_CAPABILITY_DENIED, detail="unknown entry permit")
            return False
        self._pending_entry = None
        if not sent:
            self.safe_stop(FarmCycleStopReason.ENTRY_INPUT_FAILED, entryNumber=permit.entry_number, detail=detail)
            return False
        self._entry_inputs_total += 1
        self._entry_sent = True
        self._records.append(InputRecord(InputDomain.BOSS_ENTRY, None, True, self._state, detail))
        self._event("entry_input_sent", entryNumber=permit.entry_number, detail=detail)
        return True

    def cancel_entry(self, permit: EntryPermit, *, detail: str = "") -> bool:
        return self.complete_entry(permit, sent=False, detail=detail)

    def accept_session(self, session: CombatSessionKey) -> bool:
        if self._state is FarmCycleState.ENTRY1_PENDING:
            ordinal = 1
        elif self._state is FarmCycleState.ENTRY2_PENDING:
            ordinal = 2
        else:
            return self._reject("session_out_of_order", session=session)
        if not self._entry_sent or self._pending_entry is not None:
            self.safe_stop(FarmCycleStopReason.INTERNAL_INVARIANT, detail="session before sent entry")
            return False
        if ordinal == 2 and (self._session1 is None or session == self._session1 or session.match_id == self._session1.match_id):
            self.safe_stop(FarmCycleStopReason.NEW_SESSION_NOT_PROVEN_NEW, session=session)
            return False
        if self._combat_sessions_seen >= 2:
            self.safe_stop(FarmCycleStopReason.SESSION_LIMIT_EXCEEDED, session=session)
            return False
        self._combat_sessions_seen += 1
        self._entry_sent = False
        if ordinal == 1:
            self._session1 = session
            self._transition(FarmCycleState.COMBAT1_WAIT_OPENING, "new_session_confirmed", session=session)
        else:
            self._session2 = session
            self._transition(FarmCycleState.COMBAT2_WAIT_OPENING, "new_session_confirmed", session=session)
        return True

    def accept_opening(self, opening: OpeningEvidence) -> bool:
        if self._state is FarmCycleState.COMBAT1_WAIT_OPENING:
            expected_session = self._session1
        elif self._state is FarmCycleState.COMBAT2_WAIT_OPENING:
            expected_session = self._session2
        else:
            expected_session = None
        if expected_session is None or opening.session != expected_session or not opening.valid():
            self.safe_stop(FarmCycleStopReason.OPENING_INVARIANT_FAILED, opening=opening)
            return False
        if self._state is FarmCycleState.COMBAT1_WAIT_OPENING:
            self._transition(FarmCycleState.COMBAT1_ACTIVE, "combat1_opening_ready", opening=opening)
            return True
        self._gameplay_session = None
        self._transition(FarmCycleState.FARM_CYCLE_COMPLETE, "combat2_opening_ready", opening=opening)
        self._stop_reason = FarmCycleStopReason.SECOND_COMBAT_OPENING_READY
        self._event("farm_hard_stop", reason=self._stop_reason.value)
        return True

    def begin_combat1_play(self, session: CombatSessionKey) -> bool:
        if self._state is not FarmCycleState.COMBAT1_ACTIVE or session != self._session1 or self._combat_sessions_played != 0:
            self.safe_stop(FarmCycleStopReason.GAMEPLAY_CAPABILITY_DENIED, session=session)
            return False
        self._combat_sessions_played = 1
        self._gameplay_session = session
        self._event("gameplay_capability_granted", session=session)
        return True

    def reserve_gameplay(self, domain: InputDomain, session: CombatSessionKey, *, foreground: bool) -> GameplayPermit | None:
        if not domain.gameplay:
            self._reject("non_gameplay_domain", domain=domain.value)
            return None
        if (
            self._state is not FarmCycleState.COMBAT1_ACTIVE
            or session != self._session1
            or session != self._gameplay_session
            or self._combat_sessions_played != 1
            or self._pending_gameplay is not None
        ):
            self.safe_stop(FarmCycleStopReason.GAMEPLAY_CAPABILITY_DENIED, domain=domain.value, session=session)
            return None
        if not foreground:
            self.safe_stop(FarmCycleStopReason.FOREGROUND_LOST, domain=domain.value)
            return None
        permit = GameplayPermit(uuid4().hex, domain, session)
        self._pending_gameplay = permit
        self._event("gameplay_reserved", domain=domain.value, session=session)
        return permit

    def complete_gameplay(self, permit: GameplayPermit, *, sent: bool, detail: str = "") -> bool:
        if permit != self._pending_gameplay:
            self.safe_stop(FarmCycleStopReason.GAMEPLAY_CAPABILITY_DENIED, detail="unknown gameplay permit")
            return False
        self._pending_gameplay = None
        if permit.domain is InputDomain.GAMEPLAY_PASS and sent:
            self.safe_stop(FarmCycleStopReason.INTERNAL_INVARIANT, detail="PASS cannot send Windows input")
            return False
        self._records.append(InputRecord(permit.domain, permit.session, sent, self._state, detail))
        self._event("gameplay_completed", domain=permit.domain.value, session=permit.session, sent=sent, detail=detail)
        if permit.domain is not InputDomain.GAMEPLAY_PASS and not sent:
            self.safe_stop(
                FarmCycleStopReason.GAMEPLAY_CAPABILITY_DENIED,
                domain=permit.domain.value,
                detail=detail or "executor reported zero Windows input",
            )
            return False
        return True

    def cancel_gameplay(self, permit: GameplayPermit, *, detail: str = "") -> bool:
        if permit != self._pending_gameplay:
            self.safe_stop(FarmCycleStopReason.GAMEPLAY_CAPABILITY_DENIED, detail="unknown gameplay permit")
            return False
        self._pending_gameplay = None
        self._event(
            "gameplay_cancelled_before_action",
            domain=permit.domain.value,
            session=permit.session,
            detail=detail,
        )
        self.safe_stop(
            FarmCycleStopReason.GAMEPLAY_CAPABILITY_DENIED,
            domain=permit.domain.value,
            detail=detail,
        )
        return False

    def combat1_finished(self, *, safe_stop: bool = False, detail: str = "") -> bool:
        if self._state is not FarmCycleState.COMBAT1_ACTIVE:
            return self._reject("combat_finish_out_of_order")
        if self._pending_gameplay is not None:
            self.safe_stop(FarmCycleStopReason.INTERNAL_INVARIANT, detail="pending gameplay capability at combat end")
            return False
        self._gameplay_session = None
        if safe_stop:
            self.safe_stop(FarmCycleStopReason.COMBAT_SAFE_STOP, detail=detail)
            return False
        self._transition(FarmCycleState.WAIT_POSTMATCH, "combat1_lifecycle_ended", detail=detail)
        return True

    def observe_postmatch(self) -> bool:
        if self._state is not FarmCycleState.WAIT_POSTMATCH:
            return self._reject("postmatch_out_of_order")
        self._transition(FarmCycleState.WAIT_RETURN_BOSS_LOBBY, "postmatch_observed")
        return True

    def reserve_postmatch_input(self, *, foreground: bool) -> PostmatchPermit | None:
        prior_inputs = sum(1 for record in self._records if record.domain is InputDomain.POSTMATCH_UI)
        if (
            self._state is not FarmCycleState.WAIT_RETURN_BOSS_LOBBY
            or self._pending_postmatch is not None
            or prior_inputs != 0
        ):
            self.safe_stop(FarmCycleStopReason.POSTMATCH_UI_AMBIGUOUS, detail="postmatch capability denied")
            return None
        if not foreground:
            self.safe_stop(FarmCycleStopReason.FOREGROUND_LOST, domain=InputDomain.POSTMATCH_UI.value)
            return None
        permit = PostmatchPermit(uuid4().hex)
        self._pending_postmatch = permit
        self._event("postmatch_input_reserved")
        return permit

    def complete_postmatch_input(
        self,
        permit: PostmatchPermit,
        *,
        sent: bool,
        detail: str = "",
    ) -> bool:
        if permit != self._pending_postmatch:
            self.safe_stop(FarmCycleStopReason.POSTMATCH_UI_AMBIGUOUS, detail="unknown postmatch permit")
            return False
        self._pending_postmatch = None
        self._records.append(
            InputRecord(InputDomain.POSTMATCH_UI, None, sent, self._state, detail)
        )
        self._event("postmatch_input_completed", sent=sent, detail=detail)
        if not sent:
            self.safe_stop(FarmCycleStopReason.POSTMATCH_UI_AMBIGUOUS, detail=detail or "postmatch click not sent")
            return False
        return True

    def observe_return_lobby(self, lobby: BossLobbyState) -> bool:
        if self._state is not FarmCycleState.WAIT_RETURN_BOSS_LOBBY:
            return self._reject("return_lobby_out_of_order")
        if lobby is not BossLobbyState.BOSS_LOBBY:
            self.safe_stop(FarmCycleStopReason.RETURN_LOBBY_TIMEOUT, lobby=lobby.value)
            return False
        self._transition(FarmCycleState.ENTRY2_RESOLVE_TARGET, "return_boss_lobby_ready")
        return True

    def complete_after_return_lobby(self, lobby: BossLobbyState) -> bool:
        """Accept one bounded combat and stop before reserving entry #2."""

        if self._state is not FarmCycleState.WAIT_RETURN_BOSS_LOBBY:
            return self._reject("single_cycle_return_lobby_out_of_order")
        if lobby is not BossLobbyState.BOSS_LOBBY:
            self.safe_stop(FarmCycleStopReason.RETURN_LOBBY_TIMEOUT, lobby=lobby.value)
            return False
        self._transition(
            FarmCycleState.FARM_CYCLE_COMPLETE,
            "single_cycle_return_boss_lobby_ready",
        )
        self._stop_reason = FarmCycleStopReason.RETURNED_BOSS_LOBBY_READY
        self._event("farm_hard_stop", reason=self._stop_reason.value)
        return True

    def safe_stop(self, reason: FarmCycleStopReason, **detail: Any) -> None:
        if self.stopped:
            return
        self._gameplay_session = None
        self._pending_entry = None
        self._pending_gameplay = None
        self._pending_postmatch = None
        self._stop_reason = reason
        self._transition(FarmCycleState.SAFE_STOP, "farm_safe_stop", reason=reason.value, **detail)

    def _transition(self, state: FarmCycleState, event: str, **detail: Any) -> None:
        old = self._state
        self._state = state
        self._event("farm_state_transition", oldState=old.value, newState=state.value, transitionEvent=event, **detail)

    def _event(self, event: str, **detail: Any) -> None:
        self._events.append(FarmCycleEvent(len(self._events) + 1, event, self._state, detail))

    def _reject(self, event: str, **detail: Any) -> bool:
        self._event("farm_rejected_operation", operation=event, **detail)
        return False


__all__ = [
    "EntryPermit", "FarmCycle", "FarmCycleEvent", "FarmCycleId", "FarmCycleSnapshot",
    "FarmCycleState", "FarmCycleStopReason", "GameplayPermit", "InputDomain", "PostmatchPermit",
    "InputRecord", "OpeningEvidence",
]
