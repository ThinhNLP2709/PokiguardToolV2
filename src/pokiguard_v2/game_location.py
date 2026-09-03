"""Validated game-install location selection for versioned Pokiguard builds.

The launcher name is not stable: current releases use names such as
``Pokiguard-1.7.4.exe``.  The UI persists the exact executable selected by the
operator. Directory resolution remains only as a backward-compatible migration
for preferences written before exact-path selection was introduced.
"""

from __future__ import annotations

from dataclasses import dataclass
import hashlib
from pathlib import Path
import re


_VERSIONED_NAME = re.compile(
    r"^pokiguard-(?P<version>\d+(?:\.\d+)*)\.exe$",
    re.IGNORECASE,
)
_LEGACY_NAME = "pokiguard.exe"

# Runtime layouts in v1.0.8 are verified only for this exact 1.7.4 binary.
# Future executable names may still resolve in Settings, but attachment must
# fail closed until their GameAssembly fingerprint is reverse-verified.
SUPPORTED_GAME_ASSEMBLY_SHA256 = frozenset(
    {"c67ff9cc3bb280cc63b3b9be24d45ed038937f70a95e13075d361c8ddde95a78"}
)


class GameLocationError(ValueError):
    """A configured location cannot resolve to a supported game executable."""

    def __init__(self, reason: str, message: str) -> None:
        super().__init__(message)
        self.reason = reason


@dataclass(frozen=True)
class GameExecutableSelection:
    location: Path
    executable: Path
    version: tuple[int, ...]


def is_supported_game_executable_name(name: str) -> bool:
    """Accept the retired legacy name and current versioned launcher names."""

    normalized = str(name).strip().casefold()
    return normalized == _LEGACY_NAME or _VERSIONED_NAME.fullmatch(normalized) is not None


def _version_for_name(name: str) -> tuple[int, ...]:
    match = _VERSIONED_NAME.fullmatch(name.strip())
    if match is None:
        return ()
    return tuple(int(part) for part in match.group("version").split("."))


def _validate_install_pair(executable: Path) -> None:
    if not executable.is_file():
        raise GameLocationError(
            "GAME_EXECUTABLE_NOT_FOUND",
            f"game executable not found: {executable}",
        )
    if not is_supported_game_executable_name(executable.name):
        raise GameLocationError(
            "GAME_EXECUTABLE_NAME_UNSUPPORTED",
            "expected Pokiguard-<version>.exe in the selected game folder",
        )
    game_assembly = executable.parent / "GameAssembly.dll"
    if not game_assembly.is_file():
        raise GameLocationError(
            "GAME_ASSEMBLY_NOT_FOUND",
            f"GameAssembly.dll not found beside {executable.name}",
        )


def game_assembly_sha256(path: str | Path) -> str:
    """Hash one read-only GameAssembly file without loading or modifying it."""

    digest = hashlib.sha256()
    with Path(path).open("rb") as handle:
        for chunk in iter(lambda: handle.read(1024 * 1024), b""):
            digest.update(chunk)
    return digest.hexdigest()


def validate_supported_game_assembly(path: str | Path) -> str:
    """Return the verified hash or fail closed for an unknown game build."""

    actual = game_assembly_sha256(path)
    if actual.casefold() not in SUPPORTED_GAME_ASSEMBLY_SHA256:
        raise GameLocationError(
            "GAME_BUILD_INCOMPATIBLE",
            "incompatible game build: GameAssembly.dll SHA-256 "
            f"{actual.upper()} is not reverse-verified",
        )
    return actual


def resolve_game_executable(location: str | Path) -> GameExecutableSelection:
    """Resolve a selected folder (or directly typed executable) deterministically.

    Versioned launchers outrank the retired legacy name, and the highest
    numeric version wins when an update leaves more than one executable in the
    install directory.
    """

    raw = str(location).strip().strip('"')
    if not raw:
        raise GameLocationError(
            "GAME_LOCATION_REQUIRED",
            "select the folder containing Pokiguard-<version>.exe",
        )
    selected = Path(raw).expanduser().resolve()
    if selected.is_file():
        _validate_install_pair(selected)
        return GameExecutableSelection(
            selected.parent,
            selected,
            _version_for_name(selected.name),
        )
    if not selected.is_dir():
        raise GameLocationError(
            "GAME_LOCATION_NOT_FOUND",
            f"game location does not exist: {selected}",
        )

    candidates = tuple(
        path
        for path in selected.iterdir()
        if path.is_file() and is_supported_game_executable_name(path.name)
    )
    if not candidates:
        raise GameLocationError(
            "GAME_EXECUTABLE_NOT_FOUND",
            f"no Pokiguard-<version>.exe found in {selected}",
        )
    executable = max(
        candidates,
        key=lambda path: (
            bool(_version_for_name(path.name)),
            _version_for_name(path.name),
            path.stat().st_mtime_ns,
            path.name.casefold(),
        ),
    ).resolve()
    _validate_install_pair(executable)
    return GameExecutableSelection(
        selected,
        executable,
        _version_for_name(executable.name),
    )


__all__ = [
    "GameExecutableSelection",
    "GameLocationError",
    "SUPPORTED_GAME_ASSEMBLY_SHA256",
    "game_assembly_sha256",
    "is_supported_game_executable_name",
    "resolve_game_executable",
    "validate_supported_game_assembly",
]
