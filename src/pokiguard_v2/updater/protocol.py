"""Small signed stable-channel manifest. Never executes manifest instructions."""
from __future__ import annotations
import base64
from dataclasses import dataclass
import json
from pathlib import Path
import re
from urllib.parse import urlsplit, unquote

from ..compatibility.profile import atomic_json, canonical, file_hash, load_json

DOMAIN = b"PokiguardToolV2.application-update.v1\n"
PLATFORM = "windows-x64"
EXE_NAME = "PokiguardToolV2.exe"
PACKAGE_NAME = "PokiguardToolV2"


class UpdateError(ValueError):
    def __init__(self, reason, detail=""):
        self.reason = reason
        super().__init__(f"{reason}: {detail}" if detail else reason)


def require(value, reason, detail=""):
    if not value:
        raise UpdateError(reason, detail)


def resources() -> Path:
    return Path(__file__).resolve().parents[1] / "resources"


def config() -> dict:
    return load_json(resources() / "update_config.json")


def version_key(version: str, build: int) -> tuple:
    require(type(version) is str and re.fullmatch(r"v?(0|[1-9]\d*)\.(0|[1-9]\d*)\.(0|[1-9]\d*)", version), "UPDATE_VERSION_INVALID")
    require(type(build) is int and 0 <= build < 2**31, "UPDATE_BUILD_INVALID")
    return (*map(int, version.removeprefix("v").split(".")), build)


def installed_build(install: Path | None = None) -> dict:
    path = (install / "_internal/pokiguard_v2/resources" if install else resources()) / "update_build.json"
    if not path.is_file() and install is None:
        from ..version import APP_VERSION
        return {"version": APP_VERSION, "build": 0, "platform": PLATFORM}
    data = load_json(path)
    version_key(data["version"], data["build"])
    require(data["platform"] == PLATFORM, "UPDATE_PLATFORM_INVALID")
    return data


def github_asset_url(value: str, repository: str, *, latest=False):
    require(type(value) is str, "UPDATE_URL_INVALID")
    parts = urlsplit(value)
    prefix = f"/{repository}/releases/" + ("latest/download/" if latest else "download/")
    require(parts.scheme == "https" and parts.netloc == "github.com" and not parts.query
            and not parts.fragment and parts.path.startswith(prefix)
            and ".." not in unquote(parts.path).split("/") and "\\" not in value,
            "UPDATE_URL_INVALID")


@dataclass(frozen=True)
class Release:
    version: str
    build: int
    url: str
    size: int
    sha256: str
    source_sha256: str
    notes: str
    document_bytes: bytes

    @property
    def key(self):
        return version_key(self.version, self.build)

    @property
    def label(self):
        return f"{self.version} · build {self.build}"


def verify(document: dict, trust: dict | None = None) -> Release:
    from cryptography.hazmat.primitives.asymmetric.ed25519 import Ed25519PublicKey
    trust = config() if trust is None else trust
    require(set(document) == {"key_id", "payload", "signature"}, "UPDATE_MANIFEST_INVALID")
    encoded = trust["public_keys"].get(document["key_id"])
    require(encoded is not None, "UPDATE_KEY_UNTRUSTED")
    try:
        key = Ed25519PublicKey.from_public_bytes(base64.b64decode(encoded, validate=True))
        key.verify(base64.b64decode(document["signature"], validate=True), DOMAIN + canonical(document["payload"]))
    except Exception as exc:
        raise UpdateError("UPDATE_SIGNATURE_INVALID") from exc
    row = document["payload"]
    require(set(row) == {"schema", "platform", "channel", "version", "build", "url", "size",
                          "sha256", "source_sha256", "notes"}, "UPDATE_PAYLOAD_INVALID")
    require(row["schema"] == 1 and row["platform"] == PLATFORM and row["channel"] == "stable", "UPDATE_PROTOCOL_UNSUPPORTED")
    version_key(row["version"], row["build"])
    require(type(row["size"]) is int and 0 < row["size"] <= 256 * 1024**2, "UPDATE_SIZE_INVALID")
    for key in ("sha256", "source_sha256"):
        require(type(row[key]) is str and re.fullmatch(r"[0-9a-f]{64}", row[key]), "UPDATE_HASH_INVALID")
    require(type(row["notes"]) is str and len(row["notes"]) <= 8000, "UPDATE_NOTES_INVALID")
    github_asset_url(row["url"], trust["repository"])
    return Release(*(row[k] for k in ("version", "build", "url", "size", "sha256", "source_sha256", "notes")), canonical(document))


def newer(release: Release, current: dict) -> bool:
    return release.key > version_key(current["version"], current["build"])
