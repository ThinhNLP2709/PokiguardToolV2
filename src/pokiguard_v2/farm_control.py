from __future__ import annotations

from dataclasses import dataclass
from enum import Enum


class FarmControlState(Enum):
    """Run-level stop-control axis, orthogonal to per-match FarmRunState."""

    RUNNING = "RUNNING"
    STOP_REQUESTED = "STOP_REQUESTED"
    DRAINING_CURRENT_MATCH = "DRAINING_CURRENT_MATCH"
    DRAINING_POSTMATCH = "DRAINING_POSTMATCH"
    STOPPED_AT_LOBBY = "STOPPED_AT_LOBBY"
    EMERGENCY_STOPPED = "EMERGENCY_STOPPED"


@dataclass(frozen=True)
class GracefulStopRequest:
    requested_at: float
    farm_state: str
    lifecycle: str
    match_id: str | None


@dataclass(frozen=True)
class GracefulStopSnapshot:
    state: FarmControlState
    request: GracefulStopRequest | None
    entry_irrevocably_sent: bool
    duplicate_requests: int
    recovery_reentry_suppressed: bool


class GracefulStopController:
    """Edge-triggered graceful stop. F9 emergency remains handled separately."""

    def __init__(self, timestamp: float) -> None:
        self._state = FarmControlState.RUNNING
        self._request: GracefulStopRequest | None = None
        self._entry_irrevocable = False
        self._duplicate_requests = 0
        self._recovery_reentry_suppressed = False
        self._timestamp = timestamp

    @property
    def state(self) -> FarmControlState:
        return self._state

    @property
    def request(self) -> GracefulStopRequest | None:
        return self._request

    @property
    def stopped(self) -> bool:
        return self._state in (
            FarmControlState.STOPPED_AT_LOBBY,
            FarmControlState.EMERGENCY_STOPPED,
        )

    def request_graceful_stop(
        self,
        *,
        timestamp: float,
        farm_state: str,
        lifecycle: str,
        match_id: str | None,
    ) -> bool:
        """One physical press produces exactly one logical STOP_REQUESTED."""
        if self._state is not FarmControlState.RUNNING:
            self._duplicate_requests += 1
            return False
        self._request = GracefulStopRequest(
            requested_at=timestamp,
            farm_state=farm_state,
            lifecycle=lifecycle,
            match_id=match_id,
        )
        self._timestamp = timestamp
        self._state = FarmControlState.STOP_REQUESTED
        return True

    def emergency_stop(self, *, timestamp: float) -> None:
        self._timestamp = timestamp
        self._state = FarmControlState.EMERGENCY_STOPPED

    def mark_entry_irrevocable(self) -> None:
        """Entry input already sent: its match becomes the draining current match."""
        self._entry_irrevocable = True

    def clear_entry_irrevocable(self) -> None:
        """Irrevocable entry has fully drained; future entries subject to gate."""
        self._entry_irrevocable = False

    def entry_allowed(self) -> bool:
        """Hard gate: no new boss entry once a graceful stop is live.

        The irrevocable flag only exempts the specific entry whose input was
        already sent before the stop request arrived.  It does NOT grant a
        blanket pass for subsequent matches — cleared once the draining match
        returns to the lobby.
        """
        if self._state is FarmControlState.RUNNING:
            return True
        # A stop is active; only the in-flight irrevocable entry may proceed.
        return self._entry_irrevocable and self._state in (
            FarmControlState.STOP_REQUESTED,
            FarmControlState.DRAINING_CURRENT_MATCH,
            FarmControlState.DRAINING_POSTMATCH,
        )

    def mark_draining_current_match(self) -> None:
        if self._state is FarmControlState.STOP_REQUESTED:
            self._state = FarmControlState.DRAINING_CURRENT_MATCH

    def mark_draining_postmatch(self) -> None:
        if self._state in (
            FarmControlState.STOP_REQUESTED,
            FarmControlState.DRAINING_CURRENT_MATCH,
        ):
            self._state = FarmControlState.DRAINING_POSTMATCH

    def suppress_recovery_reentry(self) -> None:
        """STOP_REQUESTED forbids starting a fresh match through recovery."""
        self._recovery_reentry_suppressed = True

    def stop_at_lobby(self) -> None:
        if not self.stopped:
            self._entry_irrevocable = False
            self._state = FarmControlState.STOPPED_AT_LOBBY

    def snapshot(self) -> GracefulStopSnapshot:
        return GracefulStopSnapshot(
            state=self._state,
            request=self._request,
            entry_irrevocably_sent=self._entry_irrevocable,
            duplicate_requests=self._duplicate_requests,
            recovery_reentry_suppressed=self._recovery_reentry_suppressed,
        )
