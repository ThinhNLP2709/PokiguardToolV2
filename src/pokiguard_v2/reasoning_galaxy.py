"""UI opt-in owner for the synchronous per-pet Galaxy tactical branches.

This does not enable or relabel the calibrated common worker. The existing
policy checkpoints rerun G1/G2/G3 or the separate G4 passive combo adviser over
each fresh state before normal input. No G4 active-card identity is invented.
"""
import json
import threading
from pathlib import Path

from .reasoning_settings import AIStatus, FrozenAIIntent


class GalaxyReasoningSession:
    def __init__(self, config, *, directory, observer):
        self.intent = FrozenAIIntent.freeze(config)
        self.directory = Path(directory)
        self.observer = observer
        self.closed = threading.Event()
        self.cleanup_ok = True
        self.bound = False
        self.stopped = False
        self.g4 = config.play_style.value == 'galaxy_shadow_sword'

    def _publish(self, state, reason):
        try:
            self.observer(AIStatus(state, reason, self.intent.config_id,
                selection_authority=not self.stopped), "AI_STATUS")
        except Exception:
            pass  # Display never grants input permission.

    def bind_run(self, farm_run_id, directory):
        if self.bound or self.stopped:
            raise ValueError("Galaxy reasoning session already bound/stopped")
        self.directory.mkdir(parents=True, exist_ok=False)
        (self.directory / "session.json").write_text(json.dumps(dict(
            kind="G4_COMBO_BOARD_TACTICS" if self.g4 else "GALAXY_PER_PET_TACTICS", farm_run_id=farm_run_id,
            farm_directory=str(Path(directory).resolve()), config_id=self.intent.config_id,
            common_worker=False, input_authority=False), indent=2), encoding="utf-8")
        self.bound = True
        self._publish("WAITING", "UI_REASONING_G4_WAITING_COMBAT" if self.g4 else "UI_REASONING_GALAXY_WAITING_COMBAT")

    def prepare_options(self):
        if not self.bound or self.stopped:
            return {}
        if self.g4:
            self._publish("REASONING", "UI_REASONING_G4_READY")
            return {"galaxy_reasoning": True, "g4_reasoning_budget_ms": min(250, self.intent.settings.budget_ms)}
        self._publish("REASONING", "UI_REASONING_GALAXY_PETS_READY")
        return {"galaxy_reasoning": True}

    def stop(self):
        if self.stopped:
            return
        self.stopped = True
        self.closed.set()
        self._publish("STOPPED", "UI_REASONING_G4_STOPPED" if self.g4 else "UI_REASONING_GALAXY_STOPPED")

    def wait_closed(self, timeout=5.0):
        return self.closed.is_set() and self.cleanup_ok
