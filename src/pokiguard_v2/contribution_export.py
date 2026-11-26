"""D-U3: zip match logs for the owner's small group to share via a Google Drive folder.

No consent text (owner decision 26/11/2026). Only farm-run JSON logs are included; every
account name found in them is replaced by a one-way hash, as a key or a value. Nothing is
uploaded and no Drive credentials are stored: the UI only opens the folder and the link.
"""
import hashlib
import json
import time
import zipfile
from pathlib import Path

SCHEMA = 'pokiguard.contribution_export.v1'
DRIVE_URL = 'https://drive.google.com/drive/folders/1JLlV6A1ezm_NzbTpxtectP-OG_0sASvu?usp=sharing'
NAME_KEYS = frozenset(('username', 'userName', 'actorUsername', 'targetUsername', 'localUsername',
    'ownerUsername', 'playerName', 'displayName', 'nickname', 'accountName', 'winner', 'deferredWinner'))
SUFFIXES = ('.jsonl', '.json')
MAX_TOTAL_BYTES = 512 * 1024 * 1024


def _hash(value):
    return 'sha256:' + hashlib.sha256(value.encode('utf-8')).hexdigest()


def _names(obj, found):
    if isinstance(obj, dict):
        for key, value in obj.items():
            if key in NAME_KEYS and isinstance(value, str) and value:
                found.add(value)
            _names(value, found)
    elif isinstance(obj, list):
        for value in obj:
            _names(value, found)


HOME = (str(Path.home()), Path.home().as_posix())


def _scrub(obj, names):
    if isinstance(obj, dict):
        return {(_hash(k) if k in names else k): _scrub(v, names) for k, v in obj.items()}
    if isinstance(obj, list):
        return [_scrub(v, names) for v in obj]
    if isinstance(obj, str):
        if obj in names:
            return _hash(obj)
        for home in HOME:  # local paths must not reveal the Windows user name
            obj = obj.replace(home, '~')
    return obj


def _records(path):
    """Parsed JSON records; unparseable lines (e.g. a line still being written) are dropped."""
    text = path.read_text(encoding='utf-8', errors='replace')
    lines = text.splitlines() if path.suffix == '.jsonl' else [text]
    for line in lines:
        if not line.strip():
            continue
        try:
            yield json.loads(line)
        except ValueError:
            continue


def export_contribution(farm_runs_root, output_dir, *, now=None):
    root = Path(farm_runs_root).resolve()
    if not root.is_dir():
        raise ValueError('farm_runs folder not found')
    files = sorted(p for p in root.rglob('*') if p.is_file() and p.suffix in SUFFIXES)
    if sum(p.stat().st_size for p in files) > MAX_TOTAL_BYTES:
        raise ValueError('farm_runs logs exceed the 512 MiB export bound')
    names = set()
    for path in files:
        for record in _records(path):
            _names(record, names)
    stamp = time.strftime('%Y%m%d_%H%M%S', time.localtime(now))
    output = Path(output_dir)
    output.mkdir(parents=True, exist_ok=True)
    target = output / f'pokiguard_contribution_{stamp}.zip'
    entries = []
    with zipfile.ZipFile(target, 'w', compression=zipfile.ZIP_DEFLATED) as archive:
        for path in files:
            rows = [json.dumps(_scrub(r, names), ensure_ascii=False, sort_keys=True) for r in _records(path)]
            data = ('\n'.join(rows) + '\n').encode('utf-8')
            arcname = 'farm_runs/' + path.relative_to(root).as_posix()
            archive.writestr(arcname, data)
            entries.append(dict(path=arcname, sha256=hashlib.sha256(data).hexdigest(), records=len(rows)))
        manifest = dict(schema=SCHEMA, created_local=stamp, files=entries, hashed_account_names=len(names),
            scrub='ACCOUNT_NAMES_ONE_WAY_SHA256_KEYS_AND_VALUES', included='FARM_RUN_JSON_LOGS_ONLY',
            excluded='PREFERENCES_CHECKPOINTS_IMAGES_CREDENTIALS', upload='MANUAL_TO_OWNER_DRIVE_FOLDER')
        archive.writestr('manifest.json', json.dumps(manifest, ensure_ascii=False, indent=2))
    return target
