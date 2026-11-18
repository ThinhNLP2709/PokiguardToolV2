"""Configure the encrypted signing secret for the pinned release repository."""
from __future__ import annotations
import argparse
import base64
import hashlib
import os
from pathlib import Path
import sys
ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT/'src'),str(ROOT/'scripts')]


def main():
    from github_release_api import GitHubClient
    from pokiguard_v2.updater.protocol import config,require
    from cryptography.hazmat.primitives.serialization import load_pem_private_key,Encoding,PublicFormat
    parser=argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--key-file',type=Path,default=Path(os.environ['LOCALAPPDATA'])/'PokiguardToolV2/publisher/update-signing.pem')
    parser.add_argument('--configure-secret',action='store_true')
    args=parser.parse_args()
    trust=config();client=GitHubClient(trust['repository'])
    permissions=client.request('actions/permissions')
    require(permissions.get('enabled') is True,'GITHUB_ACTIONS_DISABLED')
    if args.configure_secret:
        from nacl import encoding,public
        pem=args.key_file.read_bytes()
        key=load_pem_private_key(pem,password=None)
        raw=key.public_key().public_bytes(Encoding.Raw,PublicFormat.Raw)
        key_id=hashlib.sha256(raw).hexdigest()[:16]
        require(trust['public_keys'].get(key_id)==base64.b64encode(raw).decode(),'RELEASE_KEY_NOT_PINNED')
        server=client.request('actions/secrets/public-key')
        sealed=public.SealedBox(public.PublicKey(server['key'].encode(),encoding.Base64Encoder()))
        encrypted=base64.b64encode(sealed.encrypt(base64.b64encode(pem))).decode()
        client.request('actions/secrets/UPDATE_SIGNING_KEY_B64',
            {'encrypted_value':encrypted,'key_id':server['key_id']},method='PUT')
    metadata=client.request('actions/secrets/UPDATE_SIGNING_KEY_B64')
    print('Actions enabled; signing secret configured for',trust['repository'])
    print('Secret name:',metadata['name'],'updated:',metadata['updated_at'])
    return 0


if __name__=='__main__':raise SystemExit(main())
