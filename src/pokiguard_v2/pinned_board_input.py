"""Pinned-foreground delivery for the existing production board executor.

The class in this module owns only the desktop transport boundary.  The
caller still owns policy, the exact swap proposal, FarmRunner capability,
the final runtime preflight and the authoritative board acknowledgement.
"""

from __future__ import annotations

from dataclasses import dataclass
import time
from typing import Any, Callable

from .foreground_lease_transport import (
    BoundedForegroundLease,
    ForegroundLeaseBackend,
    LeaseResult,
    LeaseStatus,
    PinResult,
    PinStatus,
    PinnedWindowSession,
    _binding_failure,
)
from .foreground_qte_lease_transport import (
    BoundedForegroundQteLease,
    NativeQteLeaseBackend,
)
from .input_delivery import (
    ExactWindowBinding,
    InputDeliveryAuthority,
    InputDeliveryConfig,
    InputDeliveryDomain,
    InputDeliveryMode,
    InputLeaseKind,
)
from .win32_input import ForegroundClickExecutor


@dataclass(frozen=True)
class PinnedBoardLeaseSettings:
    """Live-proven bounded timing used only around one board swap."""

    required_idle_seconds: float = 0.25
    idle_timeout_seconds: float = 0.75
    focus_settle_seconds: float = 0.40
    post_action_settle_seconds: float = 0.20
    focus_request_attempts: int = 3
    exclusive_input_attempts: int = 3
    focus_takeover_attempts: int = 3


@dataclass(frozen=True)
class PinnedQteLeaseSettings:
    """Live-proven bounds for one card-click then keyboard-only QTE."""

    required_idle_seconds: float = 0.10
    idle_timeout_seconds: float = 0.10
    focus_settle_seconds: float = 0.20
    focus_request_attempts: int = 3
    focus_takeover_attempts: int = 3
    maximum_duration_seconds: float = 20.0


@dataclass(frozen=True)
class PinnedQteLeaseAction:
    """Prepared transport for the existing Pet Skill action executor."""

    backend: NativeQteLeaseBackend
    lease: BoundedForegroundQteLease
    authority: InputDeliveryAuthority


class PinnedForegroundMouseSession:
    """Pin one exact game HWND and issue one-shot typed mouse leases.

    Policy/capability ownership stays with the caller.  This object only owns
    the desktop pin and guarantees that one action identity can acquire at
    most one bounded mouse lease across the production mouse domains.
    """

    def __init__(
        self,
        *,
        config: InputDeliveryConfig,
        binding: ExactWindowBinding,
        backend: ForegroundLeaseBackend,
        stop_requested: Callable[[], bool],
        event_sink: Callable[[str, dict[str, Any]], None] | None = None,
        settings: PinnedBoardLeaseSettings | None = None,
        sleeper: Callable[[float], None] | None = None,
        monotonic: Callable[[], float] | None = None,
    ) -> None:
        if config.mode is not InputDeliveryMode.PINNED_FOREGROUND_LEASE_BETA:
            raise ValueError("pinned mouse session requires the beta delivery mode")
        self.config = config
        self.binding = binding
        self.backend = backend
        self.stop_requested = stop_requested
        self.event_sink = event_sink or (lambda _event, _fields: None)
        self.settings = settings or PinnedBoardLeaseSettings()
        self.sleeper = sleeper
        self.monotonic = monotonic
        self._pin = PinnedWindowSession(
            backend,
            binding,
            event_sink=self.event_sink,
        )
        self._active = False
        self._used_action_identities: set[str] = set()

    def _refresh_moved_window_at_action_boundary(self, boundary: str) -> None:
        """Adopt a pure client-origin move before creating the next lease.

        The exact HWND/PID/title and client size remain immutable.  Only a
        ``left``/``top`` change between actions is recoverable.  Once a lease
        is armed, its existing checks continue to fail closed on every form of
        geometry drift so an in-flight click, swap or QTE is never rebased.
        """

        previous = self.binding
        failure = _binding_failure(self.backend, previous)
        if failure is None:
            return
        if failure is not LeaseStatus.WINDOW_CHANGED:
            raise RuntimeError(f"cannot prepare {boundary}: {failure.value}")

        started = time.perf_counter()
        window = previous.window
        hwnd = window.hwnd
        if (
            self.backend.window_pid(hwnd) != window.pid
            or not self.backend.is_window_visible(hwnd)
            or self.backend.is_iconic(hwnd)
        ):
            raise RuntimeError(
                f"cannot prepare {boundary}: {LeaseStatus.WINDOW_INVALID.value}"
            )
        if self.backend.window_title(hwnd) != window.title:
            raise RuntimeError(
                f"cannot prepare {boundary}: {LeaseStatus.WINDOW_CHANGED.value}"
            )

        current = self.backend.client_geometry(hwnd)
        if current is None:
            raise RuntimeError(
                f"cannot prepare {boundary}: {LeaseStatus.WINDOW_INVALID.value}"
            )
        if (
            current.width != previous.geometry.width
            or current.height != previous.geometry.height
        ):
            raise RuntimeError(
                f"cannot prepare {boundary}: {LeaseStatus.WINDOW_CHANGED.value}"
            )
        if (
            current.left == previous.geometry.left
            and current.top == previous.geometry.top
        ):
            # The first WINDOW_CHANGED came from an identity/title race rather
            # than a stable, recoverable origin move.
            raise RuntimeError(
                f"cannot prepare {boundary}: {LeaseStatus.WINDOW_CHANGED.value}"
            )

        refreshed = ExactWindowBinding(window, current)
        if _binding_failure(self.backend, refreshed) is not None:
            raise RuntimeError(
                f"cannot prepare {boundary}: {LeaseStatus.WINDOW_CHANGED.value}"
            )

        self.binding = refreshed
        self._pin.binding = refreshed
        self.event_sink(
            "pinned_window_origin_rebased",
            {
                "boundary": boundary,
                "hwnd": hwnd,
                "oldLeft": previous.geometry.left,
                "oldTop": previous.geometry.top,
                "newLeft": current.left,
                "newTop": current.top,
                "width": current.width,
                "height": current.height,
                "deltaX": current.left - previous.geometry.left,
                "deltaY": current.top - previous.geometry.top,
                "geometryReadMilliseconds": round(
                    (time.perf_counter() - started) * 1000.0,
                    3,
                ),
            },
        )

    @property
    def active(self) -> bool:
        return self._active

    def start(self) -> PinResult:
        if self._active:
            return PinResult(PinStatus.PINNED, "exact game window already pinned")
        result = self._pin.pin()
        self._active = result.pinned
        return result

    def close(self) -> PinResult:
        result = self._pin.close()
        self._active = False
        return result

    def execute_mouse(
        self,
        *,
        domain: InputDeliveryDomain,
        action_identity: str,
        action: Callable[[], bool],
        preflight: Callable[[], bool],
        expected_cursor_after: tuple[int, int],
        post_focus_preflight: Callable[[], bool] | None = None,
    ) -> LeaseResult:
        if not self._active:
            raise RuntimeError("pinned mouse session is not active")
        self._refresh_moved_window_at_action_boundary(
            f"mouse:{domain.value}"
        )
        if not self.backend.is_topmost(self.binding.window.hwnd):
            raise RuntimeError("exact game window lost its topmost pin")
        authority = InputDeliveryAuthority(
            self.config,
            domain,
            self.binding,
            action_identity,
        )
        if authority.lease_kind is not InputLeaseKind.MOUSE:
            raise RuntimeError(f"{domain.value} requires a mouse lease")
        if authority.action_identity in self._used_action_identities:
            raise RuntimeError("mouse action identity was already leased")
        # Consume before any wait/focus/input. The action identity owns this
        # entire bounded attempt group and cannot be armed by another caller.
        self._used_action_identities.add(authority.action_identity)

        kwargs: dict[str, Any] = {}
        if self.sleeper is not None:
            kwargs["sleeper"] = self.sleeper
        if self.monotonic is not None:
            kwargs["monotonic"] = self.monotonic
        held_pointer = getattr(self.backend, "any_pointer_button_pressed", None)
        attempt_limit = max(1, int(self.settings.focus_takeover_attempts))
        result: LeaseResult | None = None
        for attempt in range(1, attempt_limit + 1):
            lease = BoundedForegroundLease(
                self.backend,
                stop_requested=self.stop_requested,
                event_sink=self.event_sink,
                required_idle_seconds=self.settings.required_idle_seconds,
                idle_timeout_seconds=self.settings.idle_timeout_seconds,
                focus_settle_seconds=self.settings.focus_settle_seconds,
                allow_takeover_after_idle_timeout=True,
                allow_already_foreground=True,
                held_input_pressed=(
                    held_pointer
                    if callable(held_pointer)
                    else self.backend.any_input_pressed
                ),
                focus_request_attempts=self.settings.focus_request_attempts,
                require_exclusive_input=True,
                exclusive_input_attempts=self.settings.exclusive_input_attempts,
                post_action_settle_seconds=self.settings.post_action_settle_seconds,
                **kwargs,
            )
            lease.arm(self.binding, authority.action_identity)
            result = lease.execute(
                action,
                preflight=preflight,
                post_focus_preflight=post_focus_preflight,
                expected_cursor_after=expected_cursor_after,
            )
            retryable_takeover = bool(
                result.status is LeaseStatus.USER_TAKEOVER_DURING_ACTION
                and not result.action_attempted
                and not self.stop_requested()
            )
            if not retryable_takeover or attempt >= attempt_limit:
                return result
            self.event_sink(
                "pinned_mouse_focus_takeover_retry",
                {
                    "actionIdentity": authority.action_identity,
                    "attempt": attempt,
                    "nextAttempt": attempt + 1,
                    "maxAttempts": attempt_limit,
                    "inputSent": False,
                },
            )
        assert result is not None
        return result

    def expected_cursor_for_normalized_point(
        self, normalized_point: tuple[float, float]
    ) -> tuple[int, int]:
        """Map one already-proven client point to its exact screen position."""

        x, y = normalized_point
        if not (0.0 <= x <= 1.0 and 0.0 <= y <= 1.0):
            raise ValueError("normalized point must be inside the client")
        if self._active:
            self._refresh_moved_window_at_action_boundary(
                "normalized_point_mapping"
            )
        geometry = self.binding.geometry
        return (
            geometry.left + int(x * (geometry.width - 1)),
            geometry.top + int(y * (geometry.height - 1)),
        )

    def bind_executor(
        self,
        source: ForegroundClickExecutor,
    ) -> ForegroundClickExecutor:
        """Clone an accepted executor onto the lease-aware backend.

        The native CURSOR_CONFINE fallback advances its one-pixel clip from
        ``ForegroundLeaseBackend.set_cursor_pos``. Reusing an executor bound
        directly to ``NativeWin32Backend`` bypasses that advance and can leave
        the physical click at the user's old cursor position.
        """

        return ForegroundClickExecutor(
            self.backend,
            click_delay_seconds=source.click_delay_seconds,
            cursor_settle_seconds=source.cursor_settle_seconds,
            input_mode=source.input_mode,
            drag_duration_seconds=source.drag_duration_seconds,
            drag_steps=source.drag_steps,
            drag_overshoot_fraction=source.drag_overshoot_fraction,
            sleeper=source.sleeper,
            swap_pacer=source.swap_pacer,
        )

    def execute_swap(
        self,
        *,
        action_identity: str,
        action: Callable[[], bool],
        preflight: Callable[[], bool],
        expected_cursor_after: tuple[int, int],
    ) -> LeaseResult:
        return self.execute_mouse(
            domain=InputDeliveryDomain.BOARD_SWAP,
            action_identity=action_identity,
            action=action,
            preflight=preflight,
            post_focus_preflight=None,
            expected_cursor_after=expected_cursor_after,
        )

    def create_qte_lease(
        self,
        *,
        action_identity: str,
        settings: PinnedQteLeaseSettings | None = None,
    ) -> PinnedQteLeaseAction:
        """Prepare one typed lease for the existing Pet Skill/QTE primitive.

        The run-scoped session continues to own the topmost pin.  This child
        lease owns only the bounded foreground/input interval: mouse through
        the one card click, then keyboard through the acknowledged QTE.
        """

        if not self._active:
            raise RuntimeError("pinned mouse session is not active")
        self._refresh_moved_window_at_action_boundary("qte")
        if not self.backend.is_topmost(self.binding.window.hwnd):
            raise RuntimeError("exact game window lost its topmost pin")
        authority = InputDeliveryAuthority(
            self.config,
            InputDeliveryDomain.PET_SKILL_QTE,
            self.binding,
            action_identity,
        )
        if authority.lease_kind is not InputLeaseKind.QTE_MOUSE_THEN_KEYBOARD:
            raise RuntimeError("Pet Skill requires a mouse-then-keyboard lease")
        if authority.action_identity in self._used_action_identities:
            raise RuntimeError("QTE action identity was already leased")
        self._used_action_identities.add(authority.action_identity)

        qte_settings = settings or PinnedQteLeaseSettings()
        kwargs: dict[str, Any] = {}
        if self.sleeper is not None:
            kwargs["sleeper"] = self.sleeper
        if self.monotonic is not None:
            kwargs["monotonic"] = self.monotonic
        backend = NativeQteLeaseBackend(self.backend)
        lease = BoundedForegroundQteLease(
            backend,
            stop_requested=self.stop_requested,
            event_sink=self.event_sink,
            required_idle_seconds=qte_settings.required_idle_seconds,
            idle_timeout_seconds=qte_settings.idle_timeout_seconds,
            focus_settle_seconds=qte_settings.focus_settle_seconds,
            focus_request_attempts=qte_settings.focus_request_attempts,
            focus_takeover_attempts=qte_settings.focus_takeover_attempts,
            maximum_duration_seconds=qte_settings.maximum_duration_seconds,
            **kwargs,
        )
        lease.arm(self.binding, authority.action_identity)
        return PinnedQteLeaseAction(backend, lease, authority)

    def __enter__(self) -> "PinnedForegroundMouseSession":
        result = self.start()
        if not result.pinned:
            raise RuntimeError(result.reason)
        return self

    def __exit__(self, _exc_type: Any, _exc: Any, _traceback: Any) -> None:
        self.close()


class PinnedForegroundBoardSession(PinnedForegroundMouseSession):
    """Backward-compatible board facade over the shared mouse session."""


__all__ = [
    "PinnedBoardLeaseSettings",
    "PinnedForegroundBoardSession",
    "PinnedForegroundMouseSession",
    "PinnedQteLeaseAction",
    "PinnedQteLeaseSettings",
]
