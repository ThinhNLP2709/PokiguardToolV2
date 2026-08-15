"""Cooperative single-owner lease for Pokiguard automation controllers."""

from __future__ import annotations

from pathlib import Path
from typing import BinaryIO


class ControllerLeaseError(RuntimeError):
    pass


class AutomationControllerLease:
    """Hold a non-blocking one-byte OS file lock for the controller lifetime."""

    def __init__(self, path: Path) -> None:
        self.path = path.resolve()
        self._handle: BinaryIO | None = None

    def __enter__(self) -> "AutomationControllerLease":
        self.path.parent.mkdir(parents=True, exist_ok=True)
        handle = self.path.open("a+b")
        handle.seek(0, 2)
        if handle.tell() == 0:
            handle.write(b"\0")
            handle.flush()
        handle.seek(0)
        try:
            self._lock(handle)
        except OSError as exc:
            handle.close()
            raise ControllerLeaseError(
                f"another Pokiguard automation controller owns {self.path}"
            ) from exc
        self._handle = handle
        return self

    def __exit__(self, exc_type: object, exc: object, traceback: object) -> None:
        handle = self._handle
        self._handle = None
        if handle is None:
            return
        try:
            handle.seek(0)
            self._unlock(handle)
        finally:
            handle.close()

    @staticmethod
    def _lock(handle: BinaryIO) -> None:
        try:
            import msvcrt
        except ImportError:  # pragma: no cover - development fallback
            import fcntl

            fcntl.flock(handle.fileno(), fcntl.LOCK_EX | fcntl.LOCK_NB)
        else:
            msvcrt.locking(handle.fileno(), msvcrt.LK_NBLCK, 1)

    @staticmethod
    def _unlock(handle: BinaryIO) -> None:
        try:
            import msvcrt
        except ImportError:  # pragma: no cover - development fallback
            import fcntl

            fcntl.flock(handle.fileno(), fcntl.LOCK_UN)
        else:
            msvcrt.locking(handle.fileno(), msvcrt.LK_UNLCK, 1)


__all__ = ["AutomationControllerLease", "ControllerLeaseError"]
