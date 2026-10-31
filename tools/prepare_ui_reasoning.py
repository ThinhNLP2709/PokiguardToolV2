"""Install a source/package-bound UI review from CLOSED native F1 evidence.

Developer preparation only. No request reuse, live claim, game attach or input.
Private calibration is written outside the executable/archive in writable data.
"""
from pathlib import Path
import argparse,hashlib,json,os,shutil,sys

ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
F1=ROOT/'docs/phase5/artifacts/5f1_packaged_20261031'


def main(argv=None):
    parser=argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--out',type=Path,required=True)
    parser.add_argument('--qualification',type=Path,required=True)
    parser.add_argument('--package-executable',type=Path)
    args=parser.parse_args(argv);out=args.out.resolve()
    from pokiguard_v2.reasoning_snapshot import digest,require
    from pokiguard_v2.reasoning_ui_profile import SCHEMA,F1_SOURCE,F1_CLOSURE_SHA,CONTRACT_SHA,DECISION_SHA
    from pokiguard_v2.reasoning_calibration import source_files
    from pokiguard_v2.reasoning_operational import host_fingerprint
    from pokiguard_v2.reasoning_calibration_review import document
    def read(p):return json.loads(Path(p).read_text(encoding='utf-8-sig'))
    def sha(p):return hashlib.sha256(Path(p).read_bytes()).hexdigest()
    def put(name,value):
        target=out/name;target.parent.mkdir(parents=True,exist_ok=True)
        target.write_bytes(json.dumps(value,indent=2).encode('utf-8'))
        return dict(path=name,sha256=sha(target))
    local_app_data=os.environ.get('LOCALAPPDATA')
    data_root=(Path(local_app_data)/'PokiguardToolV2') if local_app_data else None
    require(out.is_relative_to(ROOT) or (data_root is not None and out==data_root/'preferences/reasoning_acceptance'),
        'profile output must stay in V2 or the exact per-user app preference directory')
    require(not out.exists() or not any(out.iterdir()),'profile output is not empty; preserve prior evidence')
    out.mkdir(parents=True,exist_ok=True)
    def copy(source,name):
        target=out/name;target.parent.mkdir(parents=True,exist_ok=True);shutil.copyfile(source,target)
        require(sha(source)==sha(target),'profile copy changed')
        return dict(path=name,sha256=sha(target))
    def refs(directory,value):
        if isinstance(value,dict):
            if set(value)=={'path','sha256'}:
                require(sha(directory/value['path'])==value['sha256'],'native reference changed')
                copy(directory/value['path'],value['path'])
            else:
                for child in value.values():refs(directory,child)
        elif isinstance(value,list):
            for child in value:refs(directory,child)
    closure_path=F1/'closure_20261031/closure.json';closure=read(closure_path)
    require(sha(closure_path)==F1_CLOSURE_SHA and closure['source_sha256']==F1_SOURCE
        and closure['status']=='CLOSED_PASS_STRONG_SCOPED_TECHNICAL','F1 not accepted')
    setup=F1/'live_data/acceptance/reasoning2_setup';cal=read(setup/'calibration.json')
    controls=document(setup,cal['basic2_review']);refs(setup,controls)
    refs(setup,cal['native_e2'])
    source=digest(source_files(ROOT));package=None
    if args.package_executable is not None:
        from pokiguard_v2.app_paths import resolve_app_paths
        from pokiguard_v2.packaged_reasoning import package_identity
        exe=args.package_executable.resolve()
        paths=resolve_app_paths(frozen=True,executable=exe,bundle_root=exe.parent/'_internal',
            environ={'POKIGUARD_V2_DATA_ROOT':str(ROOT)})
        package=package_identity(paths,exe)
        require(package['source_sha256']==source,'build/source changed before UI enrollment')
    q=read(args.qualification)
    require(q['status']=='PASS' and q['source_sha256']==source,'qualification does not match final source')
    copy(args.qualification.parent/q['raw_costs']['path'],'selector/raw_costs.json')
    q['raw_costs']=dict(path='selector/raw_costs.json',sha256=sha(out/'selector/raw_costs.json'))
    request=read(setup/'request.json')
    profile=dict(schema=SCHEMA,source_sha256=source,package=package,host_sha256=host_fingerprint(),
        game_executable_sha256=request['game_executable_sha256'],game_build_sha256=request['game_build_sha256'],
        contract_sha256=CONTRACT_SHA,decision_sha256=DECISION_SHA,
        base_source=copy(F1/'final_source.json','base_source.json'),
        f1_closure=copy(closure_path,'f1_closure.json'),
        basic2_review=put('basic2_review.json',controls),native_e2=put('native_e2.json',cal['native_e2']),
        qualification=put('qualification.json',q),
        purpose='UI_DEMON_SHIELD_CURRENT_COHORT_ONLY_NOT_OLD_PILOT_REACTIVATION')
    put('acceptance.json',profile)
    print(json.dumps(dict(status='PROFILE_PREPARED_NO_INPUT',path=str(out/'acceptance.json'),
        source_sha256=source,scope='Lieyun77/DemonShield4/currentcalibratedaccount',
        game_file_writes=False,live=False)))


if __name__=='__main__':main()
