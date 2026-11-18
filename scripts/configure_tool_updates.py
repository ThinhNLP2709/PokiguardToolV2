"""One-time publisher key creation. Prints only the public key/config path."""
from __future__ import annotations
import argparse
import base64
import hashlib
import json
import os
from pathlib import Path
import re
import sys
ROOT = Path(__file__).resolve().parents[1]
sys.path[:0] = [str(ROOT), str(ROOT / 'src')]


def main():
    from cryptography.hazmat.primitives.asymmetric.ed25519 import Ed25519PrivateKey
    from cryptography.hazmat.primitives.serialization import Encoding, PrivateFormat, PublicFormat, NoEncryption, load_pem_private_key
    from pokiguard_v2.compatibility.profile import atomic_json
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--repository', default='ThinhNLP2709/PokiguardToolV2')
    parser.add_argument('--key-file', type=Path, default=Path(os.environ.get('LOCALAPPDATA', ROOT / 'temp/reasoning')) / 'PokiguardToolV2/publisher/update-signing.pem')
    args = parser.parse_args()
    if not re.fullmatch(r'[A-Za-z0-9_.-]+/[A-Za-z0-9_.-]+', args.repository):
        parser.error('Invalid owner/repository')
    path = args.key_file.expanduser().resolve()
    if path.exists():
        key = load_pem_private_key(path.read_bytes(), password=None)
        if not isinstance(key, Ed25519PrivateKey): raise ValueError('Expected Ed25519 key')
    else:
        key = Ed25519PrivateKey.generate()
        path.parent.mkdir(parents=True, exist_ok=True)
        with path.open('xb') as output:
            output.write(key.private_bytes(Encoding.PEM, PrivateFormat.PKCS8, NoEncryption()))
        if os.name != 'nt': path.chmod(0o600)
    public = key.public_key().public_bytes(Encoding.Raw, PublicFormat.Raw)
    key_id = hashlib.sha256(public).hexdigest()[:16]
    destination = ROOT / 'src/pokiguard_v2/resources/update_config.json'
    atomic_json(destination, {'schema': 1, 'repository': args.repository,
        'manifest_url': f'https://github.com/{args.repository}/releases/latest/download/update.json',
        'public_keys': {key_id: base64.b64encode(public).decode('ascii')}})
    print('Private key stored locally:', path)
    print('Public key ID:', key_id)
    print('Public config:', destination)
    return 0


if __name__ == '__main__': raise SystemExit(main())
