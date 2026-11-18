"""Strict extraction of a complete signed one-folder package."""
from __future__ import annotations
from pathlib import Path, PurePosixPath
import re
import zipfile
from .protocol import EXE_NAME, PACKAGE_NAME, Release, require, installed_build
from ..compatibility.profile import file_hash, load_json


def inspect_package(folder: Path, release: Release) -> None:
    require((folder / EXE_NAME).is_file() and (folder / "_internal").is_dir(), "UPDATE_PACKAGE_INCOMPLETE")
    identity = load_json(folder / "_internal/pokiguard_v2/resources/package_build.json")
    build = installed_build(folder)
    require((build["version"], build["build"]) == (release.version, release.build), "UPDATE_PACKAGE_VERSION_MISMATCH")
    require(identity["version"] == release.version and identity["source_sha256"] == release.source_sha256
            and identity.get("contains_account_data") is False, "UPDATE_PACKAGE_IDENTITY_MISMATCH")
    with (folder / EXE_NAME).open("rb") as handle:
        require(handle.read(2) == b"MZ", "UPDATE_EXE_INVALID")
        handle.seek(0x3C); import struct
        offset = struct.unpack("<I", handle.read(4))[0]
        handle.seek(offset)
        require(handle.read(6) == b"PE\0\0\x64\x86", "UPDATE_EXE_ARCH_INVALID")


def extract(archive: Path, destination: Path, release: Release) -> Path:
    require(archive.stat().st_size == release.size and file_hash(archive) == release.sha256, "UPDATE_ARCHIVE_HASH_MISMATCH")
    require(not destination.exists(), "UPDATE_STAGE_EXISTS")
    destination.mkdir(parents=True)
    root = destination.resolve()
    try:
        with zipfile.ZipFile(archive) as source:
            members = source.infolist()
            require(0 < len(members) <= 10000 and sum(m.file_size for m in members) <= 1024**3, "UPDATE_ARCHIVE_TOO_LARGE")
            seen = set()
            for item in members:
                name = item.filename
                parts = PurePosixPath(name).parts
                require(name and "\\" not in name and ":" not in name and not name.startswith("/")
                        and len(parts) >= 2 and parts[0] == PACKAGE_NAME
                        and all(p not in (".", "..") and not p.endswith((".", " "))
                                and not re.match(r"^(CON|PRN|AUX|NUL|COM[1-9]|LPT[1-9])(?:\.|$)", p, re.I)
                                and all(ord(c) >= 32 for c in p) for p in parts), "UPDATE_ARCHIVE_PATH_INVALID")
                require(name.casefold() not in seen, "UPDATE_ARCHIVE_DUPLICATE")
                seen.add(name.casefold())
                require((item.external_attr >> 16) & 0o170000 != 0o120000, "UPDATE_ARCHIVE_LINK_INVALID")
                require(item.file_size <= 256 * 1024**2, "UPDATE_MEMBER_TOO_LARGE")
                target = root.joinpath(*parts)
                require(root in target.resolve().parents, "UPDATE_ARCHIVE_PATH_INVALID")
                if item.is_dir():
                    target.mkdir(parents=True, exist_ok=True)
                else:
                    target.parent.mkdir(parents=True, exist_ok=True)
                    with source.open(item) as stream, target.open("xb") as output:
                        import shutil
                        shutil.copyfileobj(stream, output, 256 * 1024)
        folder = root / PACKAGE_NAME
        inspect_package(folder, release)
        return folder
    except Exception:
        # Failed staging is diagnostic evidence; never remove a computed path.
        raise
