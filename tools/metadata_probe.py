#!/usr/bin/env python3
"""Read and validate a Unity IL2CPP global-metadata.dat header.

This tool is intentionally read-only and has no third-party dependencies.
"""

from __future__ import annotations

import argparse
from dataclasses import dataclass
from pathlib import Path
import struct
import sys
from typing import Iterable


EXPECTED_MAGIC = 0xFAB11BAF
EXPECTED_VERSION = 31
HEADER_SIZE = 8
DEFAULT_RELATIVE_METADATA = Path(
    "Pokiguard_Data/il2cpp_data/Metadata/global-metadata.dat"
)


class MetadataProbeError(RuntimeError):
    """Raised when the metadata file cannot be resolved or parsed safely."""


@dataclass(frozen=True)
class MetadataHeader:
    path: Path
    magic: int
    version: int
    file_size: int

    @property
    def valid(self) -> bool:
        return self.magic == EXPECTED_MAGIC and self.version == EXPECTED_VERSION


def _candidate_paths(value: Path) -> Iterable[Path]:
    if value.is_file():
        yield value
        return
    yield value / "global-metadata.dat"
    yield value / DEFAULT_RELATIVE_METADATA


def resolve_metadata_path(value: str | Path | None = None) -> Path:
    """Resolve an explicit metadata/game path or auto-detect the sibling pc folder."""
    if value is not None:
        requested = Path(value).expanduser()
        for candidate in _candidate_paths(requested):
            if candidate.is_file():
                return candidate.resolve()
        raise MetadataProbeError(f"global-metadata.dat not found under: {requested}")

    project_root = Path(__file__).resolve().parents[1]
    roots = (
        project_root.parent / "pc",
        Path.cwd() / "pc",
        Path.cwd(),
    )
    seen: set[Path] = set()
    for root in roots:
        for candidate in _candidate_paths(root):
            normalized = candidate.resolve()
            if normalized in seen:
                continue
            seen.add(normalized)
            if normalized.is_file():
                return normalized
    raise MetadataProbeError(
        "global-metadata.dat not found; pass the file path or the Pokiguard game folder"
    )


def parse_metadata(path: str | Path) -> MetadataHeader:
    metadata_path = Path(path).expanduser().resolve(strict=True)
    file_size = metadata_path.stat().st_size
    if file_size < HEADER_SIZE:
        raise MetadataProbeError(
            f"metadata file is too small: {file_size} bytes (need at least {HEADER_SIZE})"
        )
    with metadata_path.open("rb") as handle:
        header = handle.read(HEADER_SIZE)
    if len(header) != HEADER_SIZE:
        raise MetadataProbeError("short read while reading metadata header")
    magic, version = struct.unpack("<II", header)
    return MetadataHeader(metadata_path, magic, version, file_size)


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(
        description="Read-only probe for Pokiguard global-metadata.dat"
    )
    parser.add_argument(
        "path",
        nargs="?",
        help="metadata file, Metadata directory, or Pokiguard game directory",
    )
    return parser


def main(argv: list[str] | None = None) -> int:
    args = build_parser().parse_args(argv)
    try:
        path = resolve_metadata_path(args.path)
        result = parse_metadata(path)
    except (MetadataProbeError, OSError) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 2

    print(f"path: {result.path}")
    print(f"magic: 0x{result.magic:08X}")
    print(f"metadata version: {result.version}")
    print(f"file size: {result.file_size} bytes")

    if not result.valid:
        print(
            "ERROR: unexpected metadata header "
            f"(expected magic=0x{EXPECTED_MAGIC:08X}, version={EXPECTED_VERSION})",
            file=sys.stderr,
        )
        return 1
    print("status: OK")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
