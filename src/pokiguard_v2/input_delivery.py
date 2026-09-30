"""Typed input-delivery contract for the Phase 4 pinned-foreground branch.

This module describes *how* an already-authorized action may reach the game.
It does not grant FarmRunner permits, relax actionability, or send input.  The
default remains the accepted foreground path.  The beta mode keeps the exact
game window visible/topmost and permits only bounded foreground leases around
the existing input executors.
"""

from __future__ import annotations

from dataclasses import asdict, dataclass
from enum import Enum
from typing import Any, ClassVar, Mapping

from .win32_input import ClientGeometry, WindowBinding


class InputDeliveryMode(str, Enum):
    FOREGROUND = "foreground"
    PINNED_FOREGROUND_LEASE_BETA = "pinned_foreground_lease_beta"


class InputDeliveryDomain(str, Enum):
    BOSS_ENTRY = "boss_entry"
    BOARD_SWAP = "board_swap"
    UI_CARD = "ui_card"
    PET_SKILL_QTE = "pet_skill_qte"
    POSTMATCH_CONFIRM = "postmatch_confirm"
    NAVIGATION_RECOVERY = "navigation_recovery"


class InputLeaseKind(str, Enum):
    NONE = "none"
    MOUSE = "mouse"
    QTE_MOUSE_THEN_KEYBOARD = "qte_mouse_then_keyboard"


class DeliveryAttemptStatus(str, Enum):
    NOT_STARTED = "NOT_STARTED"
    REJECTED = "REJECTED"
    SENT = "SENT"
    PARTIAL = "PARTIAL"
    ACKNOWLEDGED = "ACKNOWLEDGED"
    CLEANUP_FAILED = "CLEANUP_FAILED"


class InputDeliveryConfigError(ValueError):
    pass


@dataclass(frozen=True)
class ExactWindowBinding:
    """One immutable PID/HWND/title/client-geometry identity."""

    window: WindowBinding
    geometry: ClientGeometry

    def __post_init__(self) -> None:
        if not isinstance(self.window, WindowBinding):
            raise TypeError("window must be WindowBinding")
        if not isinstance(self.geometry, ClientGeometry):
            raise TypeError("geometry must be ClientGeometry")
        if self.window.hwnd <= 0 or self.window.pid <= 0:
            raise ValueError("window HWND/PID must be positive")
        if not self.window.title.strip():
            raise ValueError("window title is required")
        if self.geometry.width <= 0 or self.geometry.height <= 0:
            raise ValueError("client geometry must be positive")
        if (
            self.geometry.width != self.window.initial_width
            or self.geometry.height != self.window.initial_height
        ):
            raise ValueError("client geometry must match the bound window size")


@dataclass(frozen=True)
class InputDeliveryConfig:
    """Standalone immutable config; UI/FarmRunner wiring belongs to 4C.1."""

    SCHEMA: ClassVar[str] = "pokiguard.input_delivery.v1"
    mode: InputDeliveryMode = InputDeliveryMode.FOREGROUND

    def __post_init__(self) -> None:
        if not isinstance(self.mode, InputDeliveryMode):
            raise InputDeliveryConfigError("mode must be InputDeliveryMode")

    def to_dict(self) -> dict[str, str]:
        return {"schema": self.SCHEMA, "mode": self.mode.value}

    @classmethod
    def from_dict(cls, raw: Mapping[str, Any] | None) -> "InputDeliveryConfig":
        if raw is None:
            return cls()
        if not isinstance(raw, Mapping):
            raise InputDeliveryConfigError("input-delivery config must be an object")
        schema = raw.get("schema")
        if schema not in (None, cls.SCHEMA):
            raise InputDeliveryConfigError(
                f"unsupported input-delivery schema: {schema!r}"
            )
        value = raw.get("mode", InputDeliveryMode.FOREGROUND.value)
        try:
            mode = InputDeliveryMode(value)
        except (TypeError, ValueError) as exc:
            raise InputDeliveryConfigError(
                f"unsupported input-delivery mode: {value!r}"
            ) from exc
        return cls(mode=mode)


@dataclass(frozen=True)
class InputDeliveryCapability:
    mode: InputDeliveryMode
    pin_required: bool
    foreground_required_at_send: bool
    may_take_foreground: bool
    minimized_supported: bool
    domain_lease_kinds: tuple[tuple[InputDeliveryDomain, InputLeaseKind], ...]

    def lease_kind_for(self, domain: InputDeliveryDomain) -> InputLeaseKind:
        if not isinstance(domain, InputDeliveryDomain):
            raise InputDeliveryConfigError("domain must be InputDeliveryDomain")
        for candidate, kind in self.domain_lease_kinds:
            if candidate is domain:
                return kind
        raise InputDeliveryConfigError(
            f"{domain.value} is unsupported for {self.mode.value}"
        )


_ALL_FOREGROUND_DOMAINS = tuple(
    (domain, InputLeaseKind.NONE) for domain in InputDeliveryDomain
)
_PINNED_DOMAINS = tuple(
    (
        domain,
        (
            InputLeaseKind.QTE_MOUSE_THEN_KEYBOARD
            if domain is InputDeliveryDomain.PET_SKILL_QTE
            else InputLeaseKind.MOUSE
        ),
    )
    for domain in InputDeliveryDomain
)


def input_delivery_capability(
    mode: InputDeliveryMode,
) -> InputDeliveryCapability:
    if not isinstance(mode, InputDeliveryMode):
        raise InputDeliveryConfigError("mode must be InputDeliveryMode")
    if mode is InputDeliveryMode.FOREGROUND:
        return InputDeliveryCapability(
            mode=mode,
            pin_required=False,
            foreground_required_at_send=True,
            may_take_foreground=False,
            minimized_supported=False,
            domain_lease_kinds=_ALL_FOREGROUND_DOMAINS,
        )
    if mode is InputDeliveryMode.PINNED_FOREGROUND_LEASE_BETA:
        return InputDeliveryCapability(
            mode=mode,
            pin_required=True,
            foreground_required_at_send=True,
            may_take_foreground=True,
            minimized_supported=False,
            domain_lease_kinds=_PINNED_DOMAINS,
        )
    raise InputDeliveryConfigError(f"unsupported input-delivery mode: {mode!r}")


@dataclass(frozen=True)
class InputDeliveryAuthority:
    """Typed request passed to a future domain-specific integration."""

    config: InputDeliveryConfig
    domain: InputDeliveryDomain
    binding: ExactWindowBinding
    action_identity: str

    def __post_init__(self) -> None:
        if not isinstance(self.config, InputDeliveryConfig):
            raise TypeError("config must be InputDeliveryConfig")
        if not isinstance(self.domain, InputDeliveryDomain):
            raise TypeError("domain must be InputDeliveryDomain")
        if not isinstance(self.binding, ExactWindowBinding):
            raise TypeError("binding must be ExactWindowBinding")
        if not self.action_identity.strip():
            raise ValueError("action_identity is required")
        self.capability.lease_kind_for(self.domain)

    @property
    def capability(self) -> InputDeliveryCapability:
        return input_delivery_capability(self.config.mode)

    @property
    def lease_kind(self) -> InputLeaseKind:
        return self.capability.lease_kind_for(self.domain)


@dataclass(frozen=True)
class InputDeliveryTelemetry:
    """Small serializable envelope; it deliberately contains no raw memory."""

    authority: InputDeliveryAuthority
    status: DeliveryAttemptStatus
    expected_ack_kind: str
    client_points: tuple[tuple[int, int], ...] = ()
    event_timestamps: tuple[float, ...] = ()
    foreground_before: int | None = None
    foreground_after: int | None = None
    queued: bool | None = None
    cleanup_result: str | None = None
    run_id: str | None = None
    session_id: str | None = None

    def __post_init__(self) -> None:
        if not isinstance(self.status, DeliveryAttemptStatus):
            raise TypeError("status must be DeliveryAttemptStatus")
        if not self.expected_ack_kind.strip():
            raise ValueError("expected_ack_kind is required")
        if any(x < 0 or y < 0 for x, y in self.client_points):
            raise ValueError("client points must be nonnegative")
        if any(value < 0 for value in self.event_timestamps):
            raise ValueError("event timestamps must be nonnegative")

    def to_dict(self) -> dict[str, Any]:
        payload = asdict(self)
        payload["authority"]["config"]["mode"] = self.authority.config.mode.value
        payload["authority"]["domain"] = self.authority.domain.value
        payload["status"] = self.status.value
        payload["leaseKind"] = self.authority.lease_kind.value
        return payload


__all__ = [
    "DeliveryAttemptStatus",
    "ExactWindowBinding",
    "InputDeliveryAuthority",
    "InputDeliveryCapability",
    "InputDeliveryConfig",
    "InputDeliveryConfigError",
    "InputDeliveryDomain",
    "InputDeliveryMode",
    "InputDeliveryTelemetry",
    "InputLeaseKind",
    "input_delivery_capability",
]
