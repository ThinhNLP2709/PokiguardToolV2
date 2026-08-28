"""Canonical source and frozen runtime paths for PokiguardToolV2.

The source checkout keeps its historical ``logs`` layout for developer runs.
A frozen Windows build never treats its executable directory, PyInstaller
bundle directory, current working directory, source checkout, or game install
as writable storage.  It uses one per-user root under ``LOCALAPPDATA``.
"""

from __future__ import annotations

from dataclasses import dataclass
import os
from pathlib import Path
import sys
from typing import Mapping


APP_DATA_DIRECTORY = "PokiguardToolV2"
DATA_ROOT_ENV = "POKIGUARD_V2_DATA_ROOT"


class AppPathError(RuntimeError):
    """Raised when a safe absolute runtime path cannot be resolved."""


@dataclass(frozen=True)
class AppPaths:
    frozen: bool
    source_root: Path
    install_root: Path
    package_root: Path
    data_root: Path
    logs_root: Path
    desktop_ui_logs: Path
    farm_runs: Path
    preferences_root: Path
    preferences_file: Path
    temporary_root: Path
    startup_logs: Path
    startup_log: Path
    controller_lock: Path
    desktop_lock: Path
    reset_evidence: Path
    reference_root: Path

    @property
    def writable_directories(self) -> tuple[Path, ...]:
        return (
            self.data_root,
            self.logs_root,
            self.desktop_ui_logs,
            self.farm_runs,
            self.preferences_root,
            self.temporary_root,
            self.startup_logs,
        )

    def ensure_writable_directories(self) -> None:
        for path in self.writable_directories:
            path.mkdir(parents=True, exist_ok=True)


def _absolute(path: Path, *, label: str) -> Path:
    value = path.expanduser()
    if not value.is_absolute():
        raise AppPathError(f"{label} must be an absolute path: {value}")
    return value.resolve()


def resolve_app_paths(
    *,
    frozen: bool | None = None,
    module_file: str | Path | None = None,
    executable: str | Path | None = None,
    bundle_root: str | Path | None = None,
    environ: Mapping[str, str] | None = None,
) -> AppPaths:
    """Resolve all roots without consulting or depending on the current CWD.

    Optional arguments are intentionally injectable so packaging behavior can
    be verified without mutating ``sys.frozen`` or the host environment.
    """

    env = os.environ if environ is None else environ
    is_frozen = bool(getattr(sys, "frozen", False)) if frozen is None else frozen
    own_file = Path(module_file or __file__).resolve()
    source_root = own_file.parents[2]
    package_root = own_file.parent

    executable_path = Path(executable or sys.executable).resolve()
    install_root = executable_path.parent if is_frozen else source_root
    if is_frozen:
        pyinstaller_root = bundle_root or getattr(sys, "_MEIPASS", None)
        if pyinstaller_root is not None:
            frozen_bundle = _absolute(Path(pyinstaller_root), label="bundle root")
            bundled_package = frozen_bundle / "pokiguard_v2"
            if bundled_package.is_dir():
                package_root = bundled_package

    override = str(env.get(DATA_ROOT_ENV, "")).strip()
    if override:
        data_root = _absolute(Path(override), label=DATA_ROOT_ENV)
    elif is_frozen:
        local_app_data = str(env.get("LOCALAPPDATA", "")).strip()
        if not local_app_data:
            raise AppPathError(
                "LOCALAPPDATA is unavailable; refusing to write beside the packaged app"
            )
        data_root = _absolute(
            Path(local_app_data) / APP_DATA_DIRECTORY,
            label="packaged data root",
        )
    else:
        data_root = source_root

    logs_root = data_root / "logs"
    if is_frozen or override:
        preferences_root = data_root / "preferences"
        preferences_file = preferences_root / "operator_preferences.json"
    else:
        # Preserve the accepted source launcher layout.
        preferences_root = logs_root / "desktop_ui"
        preferences_file = preferences_root / "operator_preferences.json"

    resource_base = package_root / "resources"
    return AppPaths(
        frozen=is_frozen,
        source_root=source_root,
        install_root=install_root,
        package_root=package_root,
        data_root=data_root,
        logs_root=logs_root,
        desktop_ui_logs=logs_root / "desktop_ui",
        farm_runs=logs_root / "farm_runs",
        preferences_root=preferences_root,
        preferences_file=preferences_file,
        temporary_root=data_root / "temp",
        startup_logs=logs_root / "startup",
        startup_log=logs_root / "startup" / "startup.jsonl",
        controller_lock=logs_root / ".automation_controller.lock",
        desktop_lock=data_root / ".desktop_ui.lock",
        reset_evidence=resource_base / "reset_capabilities.json",
        reference_root=(
            resource_base / "reference" if is_frozen else source_root / "reference"
        ),
    )


def current_app_paths() -> AppPaths:
    return resolve_app_paths()


def create_unique_directory(parent: Path, stem: str) -> Path:
    """Atomically create ``stem`` or a bounded numbered sibling."""

    parent.mkdir(parents=True, exist_ok=True)
    for number in range(0, 1000):
        candidate = parent / (stem if number == 0 else f"{stem}_{number:03d}")
        try:
            candidate.mkdir()
        except FileExistsError:
            continue
        return candidate.resolve()
    raise FileExistsError(f"could not allocate a unique directory under {parent}")


__all__ = [
    "APP_DATA_DIRECTORY",
    "AppPathError",
    "AppPaths",
    "DATA_ROOT_ENV",
    "create_unique_directory",
    "current_app_paths",
    "resolve_app_paths",
]
