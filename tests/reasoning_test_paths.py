"""Shared workspace location for disposable reasoning test data."""

from pathlib import Path


def reasoning_temp_root() -> Path:
    """Keep temporary datasets and review copies out of the workspace root."""
    directory = Path(__file__).resolve().parents[1] / "temp" / "reasoning"
    directory.mkdir(parents=True, exist_ok=True)
    return directory
