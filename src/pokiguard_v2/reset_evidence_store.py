"""Validated JSON persistence for audited SWAP/CAST reset capabilities."""

from __future__ import annotations

from dataclasses import asdict
from enum import Enum
import json
from pathlib import Path
from typing import Iterable

from .game_owned_idle import (
    AcceptedActivityKind,
    ResetCapability,
    ResetConfidence,
)


SCHEMA_VERSION = 1


def _json_value(value):
    if isinstance(value, Enum):
        return value.value
    if isinstance(value, dict):
        return {str(key): _json_value(item) for key, item in value.items()}
    if isinstance(value, (tuple, list)):
        return [_json_value(item) for item in value]
    return value


def write_reset_capabilities(
    path: Path,
    capabilities: Iterable[ResetCapability],
    *,
    generated_at: str,
    source_log: str,
) -> None:
    values = tuple(capabilities)
    if not values:
        raise ValueError("at least one reset capability is required")
    payload = {
        "schemaVersion": SCHEMA_VERSION,
        "generatedAt": generated_at,
        "sourceLog": source_log,
        "capabilities": [
            {
                **_json_value(asdict(value)),
                "kind": value.kind.value,
                "confidence": value.confidence.value,
                "productionReady": value.production_ready,
            }
            for value in values
        ],
    }
    path.parent.mkdir(parents=True, exist_ok=True)
    temporary = path.with_suffix(path.suffix + ".tmp")
    temporary.write_text(
        json.dumps(payload, ensure_ascii=False, indent=2) + "\n",
        encoding="utf-8",
    )
    temporary.replace(path)


def load_reset_capabilities(
    path: Path, *, require_production_ready: bool = True
) -> tuple[ResetCapability, ...]:
    raw = json.loads(path.read_text(encoding="utf-8"))
    if not isinstance(raw, dict) or raw.get("schemaVersion") != SCHEMA_VERSION:
        raise ValueError("unsupported reset evidence schema")
    values = raw.get("capabilities")
    if not isinstance(values, list) or not values:
        raise ValueError("reset evidence contains no capabilities")
    result = []
    for item in values:
        if not isinstance(item, dict):
            raise ValueError("reset capability entry is invalid")
        identities = item.get("proof_identities")
        if not isinstance(identities, list):
            raise ValueError("reset capability proof identities are invalid")
        capability = ResetCapability(
            kind=AcceptedActivityKind(str(item.get("kind"))),
            confirmations=int(item.get("confirmations")),
            required_confirmations=int(item.get("required_confirmations")),
            confidence=ResetConfidence(str(item.get("confidence"))),
            proof_identities=tuple(tuple(value) for value in identities),
        )
        if bool(item.get("productionReady")) != capability.production_ready:
            raise ValueError("reset capability productionReady flag is inconsistent")
        if require_production_ready and not capability.production_ready:
            continue
        result.append(capability)
    if require_production_ready and not result:
        raise ValueError("no production-ready reset capability is present")
    return tuple(result)


__all__ = [
    "SCHEMA_VERSION",
    "load_reset_capabilities",
    "write_reset_capabilities",
]
