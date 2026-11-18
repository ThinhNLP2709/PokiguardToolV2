"""Background migration lifecycle shared by the desktop UI and its tests."""
from __future__ import annotations
import queue
import threading

from .service import migrate


class MigrationWorker:
    def __init__(self, engine=migrate):
        self.engine = engine
        self.events = queue.Queue()
        self.cancel = threading.Event()
        self.thread = None

    @property
    def busy(self):
        return self.thread is not None and self.thread.is_alive()

    def start(self, location: str) -> bool:
        if self.busy:
            return False
        self.cancel.clear()
        def run():
            try:
                result = self.engine(location, cancel=self.cancel,
                    progress=lambda text: self.events.put(("progress", text)))
                self.events.put(("result", result))
            except Exception as exc:
                self.events.put(("error", exc))
        self.thread = threading.Thread(target=run, name="PokiguardCompatibility", daemon=True)
        self.thread.start()
        return True
