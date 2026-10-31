"""Create non-private source identity and a synthetic offline worker probe asset."""
from pathlib import Path
import hashlib,json,sys
ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]


def main():
    from pokiguard_v2.reasoning_calibration import source_files,source_fingerprint
    from pokiguard_v2.version import APP_VERSION
    from tools.evaluate_reasoning_planner import snapshot,board_data
    out=Path(sys.argv[1]).resolve();out.mkdir(parents=True,exist_ok=True)
    files=source_files(ROOT)
    recipe={n:hashlib.sha256((ROOT/n).read_bytes()).hexdigest() for n in (
        'scripts/build_windows.ps1','scripts/create_package_build.py','packaging/PokiguardToolV2.spec')}
    (out/'package_build.json').write_text(json.dumps(dict(schema='pokiguard.package_build.v1',
        source_sha256=source_fingerprint(ROOT),source_files=files,version=APP_VERSION,
        recipe=recipe,capabilities='BASIC_DEFAULT_UI_DEMON_SHIELD_OPTIN_PROFILE_REQUIRED',contains_account_data=False),indent=2),encoding='utf-8')
    (out/'package_probe.json').write_text(json.dumps(snapshot(board=board_data('generated')).to_dict()),encoding='utf-8')


if __name__=='__main__':main()
