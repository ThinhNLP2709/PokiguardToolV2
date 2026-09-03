"""Read-only runtime adapter used by the Phase 2E.1 control plane.

This module imports no Windows input component.  Its only game-process
authority comes from the injected attachment factory, which must use the
accepted QUERY_INFORMATION + VM_READ access mask.
"""

from __future__ import annotations

import threading
from typing import Any, Callable

from .boss_entry import BossLobbyState
from .boss_lobby_runtime import read_boss_lobby_runtime
from .combat_lifecycle import CombatLifecycleState
from .desktop_control_plane import RuntimeObservation
from .memory_board_provider import MemoryBoardStateProvider, MemoryProviderConfig


_LIFECYCLE_DISPLAY = {
    CombatLifecycleState.ENTERING: "ENTERING_COMBAT",
    CombatLifecycleState.ACTIVE: "ACTIVE_COMBAT",
    CombatLifecycleState.LEAVING: "LEAVING_COMBAT",
    CombatLifecycleState.POSTMATCH: "POSTMATCH",
    CombatLifecycleState.STALE_SERVER_MATCH: "STALE_SERVER_MATCH",
    CombatLifecycleState.LOBBY: "LOBBY_OTHER",
    CombatLifecycleState.UNKNOWN: "UNKNOWN",
}


class ReadOnlyGameStatusProvider:
    """Attach, poll and detach without constructing an input-capable object."""

    def __init__(
        self,
        attach_factory: Callable[[], Any],
        *,
        provider_config: MemoryProviderConfig | None = None,
    ) -> None:
        self._attach_factory = attach_factory
        self._provider_config = provider_config or MemoryProviderConfig(
            require_lobby_start=False
        )
        self._target: Any | None = None
        self._provider: MemoryBoardStateProvider | None = None
        self._lock = threading.RLock()

    def _detach(self) -> None:
        target, self._target = self._target, None
        self._provider = None
        if target is not None:
            try:
                target.close()
            except Exception:
                pass

    def _ensure_attached(self) -> RuntimeObservation | None:
        if self._target is not None and self._provider is not None:
            return None
        try:
            target = self._attach_factory()
        except Exception as exc:  # noqa: BLE001 - detached is a UI state
            message = str(exc)
            not_running = "not running" in message.casefold()
            detected = getattr(exc, "game_detected", None)
            incompatible = detected is True
            return RuntimeObservation(
                game_detected=(
                    True if incompatible else False if not_running else None
                ),
                attached=False,
                pid=getattr(exc, "pid", None),
                architecture=getattr(exc, "architecture", None),
                lifecycle="INCOMPATIBLE_BUILD" if incompatible else "UNAVAILABLE",
                provider_reason=(
                    "game_build_incompatible" if incompatible else "attach_failed"
                ),
                error=f"{type(exc).__name__}: {message}",
            )

        # Process discovery/attachment and IL2CPP-layout compatibility are two
        # different facts.  A game update can leave the exact configured
        # process readable while invalidating every previously verified RVA.
        # Keep reporting the process as detected in that case, but fail closed
        # and never expose the stale provider as an actionable attachment.
        if not target.is_running():
            try:
                target.close()
            except Exception:
                pass
            return RuntimeObservation(
                game_detected=False,
                attached=False,
                lifecycle="UNAVAILABLE",
                provider_reason="process_exited",
            )
        try:
            provider = MemoryBoardStateProvider(target, self._provider_config)
        except Exception as exc:  # noqa: BLE001 - incompatible build is UI state
            try:
                target.close()
            except Exception:
                pass
            return RuntimeObservation(
                game_detected=True,
                attached=False,
                pid=int(target.pid),
                architecture=str(target.architecture),
                lifecycle="INCOMPATIBLE_BUILD",
                provider_reason="memory_provider_incompatible",
                error=f"{type(exc).__name__}: {exc}",
            )
        self._target = target
        self._provider = provider
        return None

    def read(self) -> RuntimeObservation:
        with self._lock:
            return self._read_unlocked()

    def _read_unlocked(self) -> RuntimeObservation:
        unavailable = self._ensure_attached()
        if unavailable is not None:
            return unavailable
        assert self._target is not None and self._provider is not None
        if not self._target.is_running():
            self._detach()
            return RuntimeObservation(
                game_detected=False,
                attached=False,
                lifecycle="UNAVAILABLE",
                provider_reason="process_exited",
            )

        try:
            poll = self._provider.poll()
        except Exception as exc:  # noqa: BLE001 - next poll may reattach safely
            self._detach()
            return RuntimeObservation(
                game_detected=None,
                attached=False,
                lifecycle="UNKNOWN",
                provider_reason="provider_exception",
                error=f"{type(exc).__name__}: {exc}",
            )

        if poll.reason == "process_exited":
            self._detach()
            return RuntimeObservation(
                game_detected=False,
                attached=False,
                lifecycle="UNAVAILABLE",
                provider_reason=poll.reason,
            )

        lifecycle_observation = poll.combat_lifecycle
        lifecycle = "UNKNOWN"
        match_id = None
        target_id = target_name = None
        target_candidates: tuple[tuple[str | None, str | None], ...] = ()
        lobby_branch = None
        current_room_id = None
        reason = poll.reason
        error = None
        if lifecycle_observation is not None:
            lifecycle_state = lifecycle_observation.state
            match_id = lifecycle_observation.signals.match_id
            lifecycle = _LIFECYCLE_DISPLAY[lifecycle_state]
            if lifecycle_state in {
                CombatLifecycleState.LOBBY,
                CombatLifecycleState.STALE_SERVER_MATCH,
                CombatLifecycleState.UNKNOWN,
            }:
                try:
                    lobby = read_boss_lobby_runtime(
                        self._target.resolver, lifecycle_observation
                    )
                    lifecycle = lobby.state.value
                    lobby_branch = lobby.branch
                    current_room_id = lobby.chinh_phuc.current_room_id
                    reason = "; ".join(lobby.reasons) or poll.reason
                    target_candidates = tuple(
                        (
                            candidate.identity.boss_id,
                            candidate.identity.boss_name,
                        )
                        for candidate in lobby.candidates
                    )
                    selected = next(
                        (
                            candidate
                            for candidate in lobby.candidates
                            if candidate.selection.value == "SELECTED"
                        ),
                        lobby.candidates[0] if lobby.candidates else None,
                    )
                    if selected is not None:
                        target_id = selected.identity.boss_id
                        target_name = selected.identity.boss_name
                except Exception as exc:  # noqa: BLE001 - lifecycle stays safe
                    lifecycle = (
                        BossLobbyState.UNKNOWN.value
                        if lifecycle_state
                        in {
                            CombatLifecycleState.STALE_SERVER_MATCH,
                            CombatLifecycleState.UNKNOWN,
                        }
                        else "LOBBY_OTHER"
                    )
                    error = f"{type(exc).__name__}: {exc}"
                    reason = "lobby_status_read_failed"
        elif poll.session_key is not None:
            # MemoryBoardStateProvider issues a CombatSessionKey only after
            # its authoritative lifecycle tracker has positively classified
            # ACTIVE.  Several bounded DTO-wait branches retain that key but
            # intentionally omit the full lifecycle observation.  Preserve
            # the proven ACTIVE status for the desktop observer instead of
            # turning normal capture waits into a UI backend error.
            lifecycle = "ACTIVE_COMBAT"
            match_id = poll.session_key.match_id
            reason = f"{poll.reason}; active_session_key"
        else:
            error = f"runtime lifecycle unavailable: {poll.reason}"

        state = poll.state
        session = poll.session_key
        if session is None and state is not None:
            session = state.battle.session_key
        if match_id is None and state is not None:
            match_id = state.battle.match_id
        session_text = None
        if session is not None:
            session_text = (
                f"epoch={session.lifecycle_epoch};"
                f"board=0x{session.board_instance:016X};"
                f"match={session.match_id}"
            )

        return RuntimeObservation(
            game_detected=True,
            attached=True,
            pid=int(self._target.pid),
            architecture=str(self._target.architecture),
            lifecycle=lifecycle,
            match_id=match_id,
            session_key=session_text,
            target_id=target_id,
            target_name=target_name,
            provider_reason=reason,
            error=error,
            target_candidates=target_candidates,
            lobby_branch=lobby_branch,
            current_room_id=current_room_id,
        )

    def close(self) -> None:
        with self._lock:
            self._detach()

    def reset_attachment(self) -> None:
        """Drop a read-only handle after the configured install changes."""

        with self._lock:
            self._detach()


__all__ = ["ReadOnlyGameStatusProvider"]
