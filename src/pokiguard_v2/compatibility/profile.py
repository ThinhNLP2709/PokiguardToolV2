"""Immutable address-only profiles, exact install identity and atomic storage."""
from __future__ import annotations

from dataclasses import dataclass
import hashlib
import json
import math
import os
from pathlib import Path
import re
import struct
import tempfile

from ..app_paths import current_app_paths


class CompatibilityError(ValueError):
    def __init__(self, reason: str, detail: str = "") -> None:
        self.reason = reason
        super().__init__(f"{reason}: {detail}" if detail else reason)


def require(condition: bool, reason: str, detail: str = "") -> None:
    if not condition:
        raise CompatibilityError(reason, detail)


def canonical(value: object) -> bytes:
    return json.dumps(value, ensure_ascii=False, sort_keys=True,
                      separators=(",", ":"), allow_nan=False).encode("utf-8")


def digest(value: object) -> str:
    return hashlib.sha256(canonical(value)).hexdigest()


def file_hash(path: Path) -> str:
    h = hashlib.sha256()
    with path.open("rb") as stream:
        for block in iter(lambda: stream.read(1024 * 1024), b""):
            h.update(block)
    return h.hexdigest()


def load_json(path: Path, *, limit: int = 8 * 1024 * 1024) -> dict:
    require(path.stat().st_size <= limit, "PROFILE_TOO_LARGE")
    def pairs(items):
        result = {}
        for key, value in items:
            require(key not in result, "DUPLICATE_JSON_KEY", key)
            result[key] = value
        return result
    data = json.loads(path.read_text("utf-8-sig"), object_pairs_hook=pairs)
    require(type(data) is dict, "INVALID_JSON_OBJECT")
    return data


def atomic_json(path: Path, value: dict) -> None:
    path.parent.mkdir(parents=True, exist_ok=True)
    fd, temporary = tempfile.mkstemp(prefix=".profile-", suffix=".json", dir=path.parent)
    try:
        with os.fdopen(fd, "wb") as out:
            out.write(canonical(value))
            out.flush()
            os.fsync(out.fileno())
        os.replace(temporary, path)
    finally:
        Path(temporary).unlink(missing_ok=True)


def compatibility_root() -> Path:
    return current_app_paths().data_root / "compatibility"


def contract_path() -> Path:
    return Path(__file__).resolve().parents[1] / "resources" / "compatibility_b17.json"


def load_contract() -> dict:
    return load_json(contract_path())


def install_identity(executable: Path) -> dict:
    """Only reads the selected install; never writes beside the launcher."""
    executable = executable.resolve()
    data = executable.parent / (executable.stem + "_Data")
    metadata = data / "il2cpp_data" / "Metadata" / "global-metadata.dat"
    paths = {"launcher": executable, "assembly": executable.parent / "GameAssembly.dll",
             "unity": executable.parent / "UnityPlayer.dll", "metadata": metadata,
             "app_info": data / "app.info"}
    require(all(p.is_file() for p in paths.values()), "INSTALL_INCOMPLETE")
    with metadata.open("rb") as stream:
        header = stream.read(8)
    require(len(header) == 8, "METADATA_HEADER_INVALID")
    magic, version = struct.unpack("<II", header)
    require(magic == 0xFAB11BAF, "METADATA_HEADER_INVALID")
    # Serialized scene/prefab layouts can change without any C# field change.
    # Texture/audio payloads are not layout authority; scene/assets/catalog data
    # are. Remote Addressables changes therefore invalidate this contract too.
    layouts = [p for p in data.iterdir() if p.is_file() and
               (p.suffix == ".assets" or p.name in {"globalgamemanagers", "boot.config"}
                or re.fullmatch(r"level\d+", p.name))]
    streaming = data / "StreamingAssets"
    if streaming.is_dir():
        layouts.extend(p for p in streaming.rglob("*") if p.is_file())
    require(bool(layouts), "UI_ASSET_CONTRACT_MISSING")
    return {"files": {key: {"sha256": file_hash(path), "size": path.stat().st_size}
                      for key, path in paths.items()}, "metadata_version": version,
            "ui_assets": {p.relative_to(data).as_posix(): {"sha256": file_hash(p), "size": p.stat().st_size}
                          for p in sorted(layouts)}}


@dataclass(frozen=True)
class RuntimeProfile:
    """A baseline RVA is a stable binding key, not a delta or runtime pointer."""
    identity_json: bytes
    bindings: tuple[tuple[int, int], ...]
    component_cache: int
    unmarshal_rva: int
    unmarshal_hex: str
    contract_sha256: str

    @property
    def identity(self) -> dict:
        return json.loads(self.identity_json)

    def type_info_rva(self, baseline: int) -> int:
        for old, current in self.bindings:
            if old == baseline:
                return current
        raise CompatibilityError("PROFILE_BINDING_MISSING", hex(baseline))

    def to_dict(self) -> dict:
        return {"schema": 1, "contract_sha256": self.contract_sha256,
                "identity": self.identity, "bindings": [list(p) for p in self.bindings],
                "component_cache": self.component_cache,
                "unmarshal": [self.unmarshal_rva, self.unmarshal_hex]}

    @property
    def profile_id(self) -> str:
        return digest(self.to_dict())

    @classmethod
    def from_dict(cls, data: dict, contract: dict) -> "RuntimeProfile":
        require(set(data) == {"schema", "contract_sha256", "identity", "bindings",
                              "component_cache", "unmarshal"}, "PROFILE_SCHEMA_INVALID")
        require(data["schema"] == 1 and data["contract_sha256"] == digest(contract),
                "PROFILE_CONTRACT_MISMATCH")
        require(type(data["identity"]) is dict, "PROFILE_IDENTITY_INVALID")
        identity = data["identity"]
        require(set(identity) == {"files", "metadata_version", "ui_assets"}, "PROFILE_IDENTITY_INVALID")
        expected_files = contract["identity"]["files"]
        require(set(identity["files"]) == set(expected_files), "PROFILE_IDENTITY_INVALID")
        for row in identity["files"].values():
            require(set(row) == {"sha256", "size"} and type(row["size"]) is int
                    and 0 < row["size"] < 2**32
                    and re.fullmatch("[0-9a-f]{64}", str(row["sha256"])) is not None,
                    "PROFILE_IDENTITY_INVALID")
        require(identity["metadata_version"] == contract["identity"]["metadata_version"]
                and identity["files"]["unity"] == expected_files["unity"],
                "PROFILE_ABI_UNSUPPORTED")
        require(identity["ui_assets"] == contract["identity"]["ui_assets"], "PROFILE_UI_ASSETS_CHANGED")
        pairs = data["bindings"]
        require(type(pairs) is list and all(type(p) is list and len(p) == 2
                and all(type(x) is int and 0 < x < 2**31 and x % 8 == 0 for x in p)
                for p in pairs), "PROFILE_BINDINGS_INVALID")
        expected = {r["rva"] for r in contract["roots"]}
        require(len(pairs) == len(expected) and {p[0] for p in pairs} == expected
                and len({p[1] for p in pairs}) == len(pairs), "PROFILE_BINDINGS_INVALID")
        require(type(data["component_cache"]) is int and 0 < data["component_cache"] < 2**31
                and data["component_cache"] % 8 == 0, "PROFILE_NATIVE_INVALID")
        native = data["unmarshal"]
        require(type(native) is list and len(native) == 2 and type(native[0]) is int
                and 0 < native[0] < 2**31 and type(native[1]) is str
                and re.fullmatch("[0-9a-f]{48}", native[1]) is not None,
                "PROFILE_NATIVE_INVALID")
        return cls(canonical(identity), tuple(sorted(tuple(p) for p in pairs)),
                   data["component_cache"], native[0], native[1], data["contract_sha256"])


def active_profile(executable: Path, *, root: Path | None = None) -> RuntimeProfile | None:
    """Profiles are selected by exact build, never by most recent successful job."""
    from ..game_location import SUPPORTED_GAME_ASSEMBLY_SHA256
    assembly = executable.parent / "GameAssembly.dll"
    build = file_hash(assembly)
    if build in SUPPORTED_GAME_ASSEMBLY_SHA256:
        return None  # Preserve the existing built-in B17 attachment path.
    location = (root or compatibility_root()) / "profiles" / f"{build}.json"
    require(location.is_file(), "GAME_BUILD_INCOMPATIBLE", "Chạy Cập nhật tương thích trong Cài đặt.")
    record = load_json(location)
    require(record.get("status") == "verified", "PROFILE_NOT_VERIFIED")
    profile = RuntimeProfile.from_dict(record["profile"], load_contract())
    require(record.get("profile_id") == profile.profile_id, "PROFILE_CHECKSUM_MISMATCH")
    evidence = record.get("probe", {})
    require(evidence.get("status") == "verified" and evidence.get("game_inputs") == 0
            and evidence.get("profile_id") == profile.profile_id
            and type(record.get("verified_at")) in (int, float)
            and math.isfinite(record["verified_at"]) and record["verified_at"] > 0,
            "PROFILE_PROBE_EVIDENCE_INVALID")
    require(install_identity(executable) == profile.identity, "INSTALL_CHANGED")
    return profile


def verified_assembly_profile(assembly: Path) -> RuntimeProfile:
    """Pure file gate used by existing qualification code, without rebinding it.

    Qualification must still match its own exact build/source evidence. Verify
    the complete install of a paired launcher rather than trusting a hash entry.
    The actual attach additionally validates the operator's exact selected EXE.
    """
    from ..game_location import is_supported_game_executable_name
    last = None
    for executable in assembly.resolve().parent.iterdir():
        if executable.is_file() and is_supported_game_executable_name(executable.name):
            try:
                profile = active_profile(executable)
                if profile is not None:
                    return profile
            except (ValueError, OSError, KeyError, TypeError) as exc:
                last = exc
    raise CompatibilityError("GAME_BUILD_INCOMPATIBLE", str(last or "No verified profile for this install"))
