"""Verify actual ZIP bytes and execute frozen checks outside the checkout CWD."""
from __future__ import annotations
import argparse
import json
import os
from pathlib import Path
import subprocess
import sys
import zipfile
ROOT = Path(__file__).resolve().parents[1]
sys.path[:0] = [str(ROOT), str(ROOT / 'src')]


def main():
    from pokiguard_v2.updater.protocol import verify
    from pokiguard_v2.updater.package import extract
    from pokiguard_v2.updater.transaction import run_health
    from pokiguard_v2.compatibility.profile import atomic_json
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--archive', type=Path, required=True)
    parser.add_argument('--manifest', type=Path)
    parser.add_argument('--output', type=Path, required=True)
    args = parser.parse_args()
    args.output.mkdir(parents=True, exist_ok=False)
    checks = []
    if args.manifest:
        release = verify(json.loads(args.manifest.read_text('utf-8')))
    else:
        # CI builds without a signing secret are still executable-tested, but
        # this synthetic descriptor cannot be consumed by the client updater.
        from pokiguard_v2.updater.protocol import Release
        from pokiguard_v2.compatibility.profile import file_hash
        with zipfile.ZipFile(args.archive) as z:
            require_crc = z.testzip()
            if require_crc is not None: raise ValueError(require_crc)
            base = 'PokiguardToolV2/_internal/pokiguard_v2/resources/'
            build = json.loads(z.read(base+'update_build.json'))
            identity = json.loads(z.read(base+'package_build.json'))
        release = Release(build['version'],build['build'],'',args.archive.stat().st_size,
                          file_hash(args.archive),identity['source_sha256'],'',b'')
    folder = extract(args.archive, args.output / 'extracted', release)
    from pokiguard_v2.updater.protocol import EXE_NAME
    for flag in ('--updater-self-check','--compatibility-self-check','--packaging-self-check','--packaged-reasoning-self-check'):
        data = args.output / flag.removeprefix('--')
        env = dict(os.environ, POKIGUARD_V2_DATA_ROOT=str(data.resolve()))
        env.pop('PYTHONPATH',None)
        child = subprocess.Popen([str(folder / EXE_NAME), flag],cwd=args.output,env=env,
                                 creationflags=getattr(subprocess,'CREATE_NO_WINDOW',0))
        try: code = child.wait(timeout=60)
        except subprocess.TimeoutExpired:
            child.kill(); child.wait(); raise
        if code: raise RuntimeError(f'{flag} exit {code}')
        checks.append({'argument':flag,'exit_code':code})
    run_health(folder,args.output,release)
    checks.append({'argument':'--update-health-check','exit_code':0})
    atomic_json(args.output / 'verification.json',{'version':release.version,'build':release.build,
        'sha256':release.sha256,'checks':checks,'game_inputs':0,'pythonpath':False})
    print('Frozen package verified:',folder)
    return 0


if __name__ == '__main__': raise SystemExit(main())
