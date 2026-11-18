"""Maintainer utility: sign verified profiles; never ship the private key."""
from __future__ import annotations
import argparse
import base64
from pathlib import Path
import time
from pokiguard_v2.compatibility.catalog import DOMAIN
from pokiguard_v2.compatibility.profile import RuntimeProfile, load_contract, load_json, atomic_json, canonical, require


def main(argv=None):
    from cryptography.hazmat.primitives.serialization import load_pem_private_key
    from cryptography.hazmat.primitives.asymmetric.ed25519 import Ed25519PrivateKey
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--key', type=Path, required=True)
    parser.add_argument('--key-id', required=True)
    parser.add_argument('--profile', type=Path, action='append', required=True)
    parser.add_argument('--output', type=Path, required=True)
    args = parser.parse_args(argv)
    key = load_pem_private_key(args.key.read_bytes(), password=None)
    require(isinstance(key, Ed25519PrivateKey), 'CATALOG_KEY_TYPE_INVALID')
    profiles = {}
    for path in args.profile:
        record = load_json(path)
        profile = RuntimeProfile.from_dict(record['profile'], load_contract())
        evidence = record.get('probe', {})
        require(record.get('status') == 'verified' and record.get('profile_id') == profile.profile_id
                and evidence.get('status') == 'verified' and evidence.get('game_inputs') == 0
                and evidence.get('profile_id') == profile.profile_id, 'PROFILE_NOT_VERIFIED')
        build = profile.identity['files']['assembly']['sha256']
        require(build not in profiles, 'CATALOG_DUPLICATE_BUILD')
        profiles[build] = profile.to_dict()
    issued = int(time.time())
    payload = {'schema': 1, 'issued_at': issued, 'expires_at': issued + 30 * 86400, 'profiles': profiles}
    document = {'key_id': args.key_id, 'payload': payload,
                'signature': base64.b64encode(key.sign(DOMAIN + canonical(payload))).decode('ascii')}
    atomic_json(args.output, document)
    print(f'Signed {len(profiles)} verified profiles: {args.output}')
    return 0


if __name__ == '__main__':
    raise SystemExit(main())
