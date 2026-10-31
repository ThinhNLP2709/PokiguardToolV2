"""C2 immutable desktop intent and optional shadow ownership. No input authority."""
from __future__ import annotations

from dataclasses import asdict, dataclass
import hashlib
import json
from pathlib import Path
import uuid


AI_SETTINGS_SCHEMA = "pokiguard.ai_settings.v1"
AI_RUN_SCHEMA = "pokiguard.ai_run_intent.v1"
MIN_BUDGET_MS = 50
MAX_BUDGET_MS = 6000
DEFAULT_BUDGET_MS = 4000


@dataclass(frozen=True)
class AISettings:
    shadow_enabled: bool = False
    budget_ms: int = DEFAULT_BUDGET_MS
    reasoning_enabled: bool = False

    def __post_init__(self):
        if type(self.shadow_enabled) is not bool:
            raise ValueError("shadow_enabled must be bool")
        if type(self.reasoning_enabled) is not bool:
            raise ValueError("reasoning_enabled must be bool")
        if type(self.budget_ms) is not int or not MIN_BUDGET_MS <= self.budget_ms <= MAX_BUDGET_MS:
            raise ValueError("AI budget must be an integer between 50 and 6000 ms")

    def to_dict(self):
        raw = dict(schema=AI_SETTINGS_SCHEMA, shadow_enabled=self.shadow_enabled,
                   budget_ms=self.budget_ms)
        if self.reasoning_enabled:
            raw['reasoning_enabled'] = True
        return raw

    @classmethod
    def from_dict(cls, raw):
        if raw is None:
            return cls()
        if type(raw) is not dict or raw.get("schema", AI_SETTINGS_SCHEMA) != AI_SETTINGS_SCHEMA:
            raise ValueError("unsupported AI settings schema")
        return cls(raw.get("shadow_enabled", False), raw.get("budget_ms", DEFAULT_BUDGET_MS),
                   raw.get("reasoning_enabled", False))

    @classmethod
    def from_strings(cls, shadow_enabled: str, budget_ms: str, reasoning_enabled: str = "false"):
        if shadow_enabled not in {"true", "false"}:
            raise ValueError("AI shadow must be true or false")
        if not isinstance(budget_ms, str) or not budget_ms.isascii() or not budget_ms.isdigit():
            raise ValueError("AI budget must contain ASCII decimal digits")
        if reasoning_enabled not in {"true", "false"}:
            raise ValueError("AI reasoning must be true or false")
        return cls(shadow_enabled == "true", int(budget_ms), reasoning_enabled == "true")


@dataclass(frozen=True)
class FrozenAIIntent:
    """Canonical accepted DesktopConfig copy, including PlayStyle/tactical intent."""
    config_json: str
    config_id: str
    settings: AISettings
    profile: str

    @classmethod
    def freeze(cls, config):
        raw = dict(schema=AI_RUN_SCHEMA, config={**asdict(config), "ai": config.ai.to_dict()})
        encoded = json.dumps(raw, ensure_ascii=False, sort_keys=True,
                             separators=(",", ":"), allow_nan=False,
                             default=lambda value: value.value)
        return cls(encoded, hashlib.sha256(encoded.encode()).hexdigest(),
                   config.ai, config.play_style.value)


@dataclass(frozen=True)
class AIStatus:
    state: str = "OFF"
    reason: str = "SHADOW_DISABLED"
    config_id: str = ""
    observation: int = 0
    suggestion: str = ""
    dropped: int = 0
    written: int = 0
    queued: int = 0
    faults: int = 0
    unsupported: int = 0
    skipped: int = 0
    accounting_valid: bool = False
    # Shadow never applies a tactical override or takes selection authority.
    selection_authority: bool = False


class RunShadowSession:
    """One frozen Start/Resume intent; one factory-owned observer per combat.

    Setup runs on the existing farm controller thread. Status is emitted from
    the existing shadow observer, never Tk/action admission. Stop only signals.
    A previous cleanup still running causes AI to skip rather than wait.
    """
    def __init__(self, config, *, directory: Path, observer, factory=None):
        self.intent = FrozenAIIntent.freeze(config)
        self.directory = directory
        self.observer = observer
        self.factory = factory
        self.run_id = uuid.uuid4().hex
        self.serial = 0
        self.adapter = None
        self.stopped = False

    def _publish(self, status):
        try:
            return self.observer(status, "AI_STATUS")
        except Exception:
            return False  # Only display is lost; gameplay remains BASIC.

    def prepare(self):
        """Optional setup at an existing combat invocation, never waits for cleanup."""
        if self.stopped or not self.intent.settings.shadow_enabled or self.intent.settings.reasoning_enabled:
            return None
        self.serial += 1
        serial = self.serial
        if self.intent.profile == "bu_win":
            self._publish(AIStatus("UNSUPPORTED", "COOP_SHADOW_NOT_ACCEPTED",
                                   self.intent.config_id, serial))
            return None
        try:
            if self.adapter is not None:
                self.adapter.stop()
            factory = self.factory
            if factory is None:
                from .reasoning_shadow import create_shadow
                factory = create_shadow

            def status_changed(values):
                if self.stopped or serial != self.serial:
                    return False
                return self._publish(AIStatus(config_id=self.intent.config_id,
                                              observation=serial, **values))

            self._publish(AIStatus("WAITING", "WAITING_PUBLICATION",
                                   self.intent.config_id, serial))
            adapter = factory(enabled=True, directory=self.directory,
                              run_id=f"{self.run_id}:{serial}",
                              budget_ms=self.intent.settings.budget_ms,
                              config_version=self.intent.config_id,
                              status_callback=status_changed)
            self.adapter = adapter
            if adapter is None:
                self._publish(AIStatus("DEGRADED", "SHADOW_FACTORY_UNAVAILABLE",
                                       self.intent.config_id, serial))
            return adapter
        except Exception as exc:
            self._publish(AIStatus("DEGRADED", f"SHADOW_SETUP_{type(exc).__name__}"[:128],
                                   self.intent.config_id, serial))
            return None

    def stop(self):
        self.stopped = True
        try:
            if self.adapter is not None:
                self.adapter.stop()
        except Exception:
            pass


def prepare_shadow_safely(session):
    try:
        return session.prepare()
    except Exception:
        return None
