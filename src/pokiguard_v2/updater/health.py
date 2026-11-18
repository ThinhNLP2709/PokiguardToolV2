"""Frozen update acceptance without attaching a game or creating input objects."""
from __future__ import annotations
import os
from .protocol import config, installed_build, require
from ..compatibility.profile import atomic_json, load_json


def self_check():
    from cryptography.hazmat.primitives.asymmetric.ed25519 import Ed25519PublicKey
    import base64
    trust = config()
    require(trust['schema'] == 1 and bool(trust['public_keys']), 'UPDATE_NOT_CONFIGURED')
    for value in trust['public_keys'].values():
        Ed25519PublicKey.from_public_bytes(base64.b64decode(value, validate=True))
    from .protocol import github_asset_url
    github_asset_url(trust['manifest_url'], trust['repository'], latest=True)
    installed_build()


def run(paths):
    from ..windows_entry import _run_packaging_self_check
    from ..packaged_verification import run as reasoning_check
    self_check()
    require(_run_packaging_self_check(paths) == 0, 'UPDATE_IMPORT_CHECK_FAILED')
    require(reasoning_check(paths) == 0, 'UPDATE_REASONING_CHECK_FAILED')
    from ..compatibility.profile import load_contract
    import capstone
    require(len(list(capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64).disasm(b'\x90', 0x1000))) == 1,
            'UPDATE_DECODER_CHECK_FAILED')
    load_contract()
    identity = load_json(paths.package_root / 'resources/package_build.json')
    build = installed_build()
    atomic_json(paths.data_root / 'update-health.json', {'nonce': os.environ.get('POKIGUARD_UPDATE_HEALTH_NONCE', ''),
        'version': build['version'], 'build': build['build'], 'source_sha256': identity['source_sha256'], 'game_inputs': 0})
    return 0
