"""Bounded, local maintenance helpers for FarmRunner log artifacts."""

from __future__ import annotations

from dataclasses import dataclass
import os
from pathlib import Path
import shutil


@dataclass(frozen=True)
class FarmRunStorageUsage:
    """A stable snapshot of the files currently stored under ``farm_runs``."""

    total_bytes: int = 0
    file_count: int = 0
    directory_count: int = 0


def format_byte_size(total_bytes: int) -> str:
    """Render a non-negative byte count using compact binary units."""

    value = max(0, int(total_bytes))
    if value < 1024:
        return f"{value} B"
    amount = float(value)
    for unit in ("KB", "MB", "GB", "TB"):
        amount /= 1024.0
        if amount < 1024.0 or unit == "TB":
            rendered = f"{amount:.2f}".rstrip("0").rstrip(".")
            return f"{rendered} {unit}"
    raise AssertionError("unreachable")


def _validated_farm_runs_root(root: Path) -> Path:
    resolved = Path(root).expanduser().resolve(strict=False)
    if resolved.name.casefold() != "farm_runs":
        raise ValueError("chỉ được phép quản lý đúng thư mục farm_runs")
    if resolved == Path(resolved.anchor):
        raise ValueError("không được phép quản lý thư mục gốc của ổ đĩa")
    return resolved


def scan_farm_runs(root: Path) -> FarmRunStorageUsage:
    """Measure files below ``farm_runs`` without following directory links."""

    resolved = _validated_farm_runs_root(root)
    if not resolved.exists():
        return FarmRunStorageUsage()
    if not resolved.is_dir():
        raise NotADirectoryError(str(resolved))

    total_bytes = 0
    file_count = 0
    directory_count = 0
    pending = [resolved]
    while pending:
        directory = pending.pop()
        try:
            entries = tuple(os.scandir(directory))
        except FileNotFoundError:
            # A completed run can be removed while a manual refresh is still
            # measuring an earlier directory snapshot.
            continue
        for entry in entries:
            try:
                if entry.is_dir(follow_symlinks=False):
                    directory_count += 1
                    pending.append(Path(entry.path))
                    continue
                stat = entry.stat(follow_symlinks=False)
            except FileNotFoundError:
                continue
            file_count += 1
            total_bytes += max(0, int(stat.st_size))
    return FarmRunStorageUsage(total_bytes, file_count, directory_count)


def clear_farm_runs(root: Path) -> FarmRunStorageUsage:
    """Delete every child below ``farm_runs`` while preserving the root."""

    resolved = _validated_farm_runs_root(root)
    before = scan_farm_runs(resolved)
    resolved.mkdir(parents=True, exist_ok=True)
    for child in tuple(resolved.iterdir()):
        try:
            if child.is_symlink() or not child.is_dir():
                child.unlink()
            else:
                shutil.rmtree(child)
        except FileNotFoundError:
            continue
    return before


__all__ = [
    "FarmRunStorageUsage",
    "clear_farm_runs",
    "format_byte_size",
    "scan_farm_runs",
]
