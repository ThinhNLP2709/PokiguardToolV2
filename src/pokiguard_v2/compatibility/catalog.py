"""Optional maintainer catalog with pinned Ed25519 public keys.

No feed is configured by default. Absence/network/signature failure falls back
to the local, pinned Dumper workflow; downloaded data is never executable.
"""
from __future__ import annotations
import base64
import json
from pathlib import Path
import time
import urllib.request

from .profile import RuntimeProfile, canonical, load_json, require
from .toolchain import check_cancel

DOMAIN = b"PokiguardV2.compatibility.catalog.v1\n"


def verify_catalog(document: dict, config: dict, *, now: float | None = None) -> dict:
    from cryptography.hazmat.primitives.asymmetric.ed25519 import Ed25519PublicKey
    require(set(document) == {"key_id", "payload", "signature"}, "CATALOG_SCHEMA_INVALID")
    key = config["public_keys"].get(document["key_id"])
    require(key is not None, "CATALOG_KEY_UNTRUSTED")
    try:
        public = Ed25519PublicKey.from_public_bytes(base64.b64decode(key, validate=True))
        public.verify(base64.b64decode(document["signature"], validate=True),
                      DOMAIN + canonical(document["payload"]))
    except Exception as exc:
        from .profile import CompatibilityError
        raise CompatibilityError("CATALOG_SIGNATURE_INVALID") from exc
    payload = document["payload"]
    clock = time.time() if now is None else now
    require(payload.get("schema") == 1 and type(payload.get("issued_at")) in (int, float)
            and type(payload.get("expires_at")) in (int, float)
            and payload["issued_at"] <= clock + 300 < payload["expires_at"]
            and 0 < payload["expires_at"] - payload["issued_at"] <= 31 * 86400,
            "CATALOG_EXPIRED_OR_INVALID")
    require(type(payload.get("profiles")) is dict, "CATALOG_SCHEMA_INVALID")
    return payload


def fetch_profile(identity: dict, contract: dict, cancel, *, config: dict | None = None):
    config = config if config is not None else load_json(
        Path(__file__).resolve().parents[1] / "resources/compatibility_catalog.json")
    if not config.get("url"):
        return None
    require(config["url"].startswith("https://") and bool(config.get("public_keys")), "CATALOG_CONFIG_INVALID")
    request = urllib.request.Request(config["url"], headers={"User-Agent": "PokiguardToolV2-compatibility/1"})
    with urllib.request.urlopen(request, timeout=15) as response:
        require(response.geturl().startswith("https://"), "CATALOG_REDIRECT_INSECURE")
        raw = response.read(2 * 1024 * 1024 + 1)
        require(len(raw) <= 2 * 1024 * 1024, "CATALOG_TOO_LARGE")
    check_cancel(cancel)
    payload = verify_catalog(json.loads(raw), config)
    build = identity["files"]["assembly"]["sha256"]
    entry = payload["profiles"].get(build)
    if entry is None:
        return None
    profile = RuntimeProfile.from_dict(entry, contract)
    require(profile.identity == identity, "CATALOG_INSTALL_MISMATCH")
    return profile
