"""Sign release ZIP metadata. Private key comes from a local file or Actions secret."""
from __future__ import annotations
import argparse
import base64
import hashlib
import json
import os
from pathlib import Path
import re
import sys
import zipfile
ROOT = Path(__file__).resolve().parents[1]
sys.path[:0] = [str(ROOT), str(ROOT / 'src')]


def main():
    from cryptography.hazmat.primitives.serialization import Encoding, PublicFormat, load_pem_private_key
    from cryptography.hazmat.primitives.asymmetric.ed25519 import Ed25519PrivateKey
    from pokiguard_v2.updater.protocol import config, verify, DOMAIN, require
    from pokiguard_v2.compatibility.profile import atomic_json, canonical, file_hash
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--archive', type=Path, required=True)
    parser.add_argument('--output', type=Path, required=True)
    parser.add_argument('--tag', required=True)
    parser.add_argument('--key-file', type=Path)
    parser.add_argument('--notes', default='Cập nhật tool; không tự khởi chạy lượt chơi.')
    args = parser.parse_args()
    require(re.fullmatch(r'[A-Za-z0-9][A-Za-z0-9._+-]{0,95}', args.tag), 'RELEASE_TAG_INVALID')
    pem = args.key_file.read_bytes() if args.key_file else base64.b64decode(os.environ['UPDATE_SIGNING_KEY_B64'], validate=True)
    key = load_pem_private_key(pem, password=None)
    require(isinstance(key, Ed25519PrivateKey), 'RELEASE_KEY_INVALID')
    public = key.public_key().public_bytes(Encoding.Raw, PublicFormat.Raw)
    key_id = hashlib.sha256(public).hexdigest()[:16]
    trust = config()
    require(trust['public_keys'].get(key_id) == base64.b64encode(public).decode('ascii'), 'RELEASE_KEY_NOT_PINNED')
    with zipfile.ZipFile(args.archive) as source:
        build = json.loads(source.read('PokiguardToolV2/_internal/pokiguard_v2/resources/update_build.json'))
        identity = json.loads(source.read('PokiguardToolV2/_internal/pokiguard_v2/resources/package_build.json'))
        bundled_trust = json.loads(source.read('PokiguardToolV2/_internal/pokiguard_v2/resources/update_config.json'))
    require(bundled_trust == trust, 'RELEASE_TRUST_CONFIG_MISMATCH')
    require(build['version'] == identity['version'], 'RELEASE_VERSION_MISMATCH')
    require(re.fullmatch(r'[A-Za-z0-9._+-]+\.zip', args.archive.name), 'RELEASE_FILENAME_INVALID')
    row = {'schema': 1, 'channel': 'stable', 'platform': build['platform'],
           'version': build['version'], 'build': build['build'], 'notes': args.notes,
           'url': f"https://github.com/{trust['repository']}/releases/download/{args.tag}/{args.archive.name}",
           'size': args.archive.stat().st_size, 'sha256': file_hash(args.archive),
           'source_sha256': identity['source_sha256']}
    document = {'key_id': key_id, 'payload': row,
                'signature': base64.b64encode(key.sign(DOMAIN + canonical(row))).decode('ascii')}
    verify(document)
    atomic_json(args.output, document)
    print(f"Signed {build['version']} build {build['build']}: {args.output}")
    return 0


if __name__ == '__main__': raise SystemExit(main())
