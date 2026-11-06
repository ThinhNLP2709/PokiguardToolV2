"""Assemble a bounded common-engine timing profile from completed controls.

File-only: never installs a profile, changes preferences, starts a game/tool or
claims reasoning live acceptance. Original raw paths are archive identities.
"""
import argparse,hashlib,json,sys
from pathlib import Path
ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.reasoning_common_native import SCHEMA,review_bundle
from pokiguard_v2.reasoning_calibration import source_fingerprint
from pokiguard_v2.reasoning_snapshot import require,strict_json_loads


def prepare(export_path,qualification_path,output,*,max_attempts=3):
    output=Path(output).resolve();export_path=Path(export_path).resolve()
    qualification_path=Path(qualification_path).resolve()
    require(output.is_relative_to(ROOT) and not output.exists(),'fresh output inside V2 required')
    require(type(max_attempts) is int and 1<=max_attempts<=3,'initial reasoning trial is at most three attempts')
    export=strict_json_loads(export_path.read_text('utf-8'))
    qualification=strict_json_loads(qualification_path.read_text('utf-8'))
    require(export['source_sha256']==qualification['source_sha256']==source_fingerprint(ROOT),
        'fresh controls and qualification must match current source')
    inputs=export['inputs'];require(4<=len(inputs)<=128,'bounded complete control archive required')
    output.mkdir(parents=True);(output/'raw').mkdir()
    def save(path,raw):
        (output/path).write_bytes(raw)
        return dict(path=path,sha256=hashlib.sha256(raw).hexdigest())
    archive={};total=0
    for i,(name,expected) in enumerate(sorted(inputs.items())):
        p=Path(name);require(p.is_file() and p.stat().st_size<=32*1024*1024,'bounded source record required')
        raw=p.read_bytes();total+=len(raw)
        require(total<=64*1024*1024 and hashlib.sha256(raw).hexdigest()==expected,'raw input changed or too large')
        archive[name]=save(f'raw/{i:03d}.jsonl' if p.suffix=='.jsonl' else f'raw/{i:03d}.json',raw)
    def one(predicate):
        found=[name for name in inputs if predicate(Path(name))]
        require(len(found)==1,'unambiguous control role required')
        return found[0]
    request_name=one(lambda p:hashlib.sha256(p.read_bytes()).hexdigest()==export['request_sha256'])
    request=strict_json_loads(Path(request_name).read_text('utf-8'))
    roles=dict(request=request_name,binding=one(lambda p:p.name=='session.json'),
        watermark=one(lambda p:p.name=='watermarks.json'),run=one(lambda p:p.name=='run.json'))
    data=dict(schema=SCHEMA,status='NATIVE_TIMING_PROJECTION_REASONING_LIVE_PENDING',
        source_sha256=export['source_sha256'],game_build_sha256=export['game_build_sha256'],
        host_sha256=export['host_sha256'],game_executable_sha256=request['game_executable_sha256'],
        control_export=save('control_export.json',export_path.read_bytes()),
        qualification=save('qualification.json',qualification_path.read_bytes()),archive=archive,roles=roles,
        max_attempts=max_attempts,input_families=['swap'],style_selection='FROM_EXISTING_GAMEPLAY_CONFIG',
        installed=False,live_acceptance=False,native_U_ms=None)
    components,samples=review_bundle(output,data)
    (output/'common.json').write_text(json.dumps(data,ensure_ascii=False,indent=2),encoding='utf-8')
    return dict(profile=str(output/'common.json'),samples=samples,components=components,
        installed=False,automatic_start=False,live_acceptance=False)


def prepare_compatible(profile_path,qualification_path,output,*,max_attempts=1):
    """File-only reuse of exact old raw measurements under a reviewed projection."""
    from pokiguard_v2.reasoning_calibration_review import document,read_ref
    original=Path(profile_path).resolve();output=Path(output).resolve()
    require(output.is_relative_to(ROOT) and not output.exists(),'fresh output inside V2 required')
    require(type(max_attempts) is int and 1<=max_attempts<=3,'initial reasoning trial is at most three attempts')
    data=strict_json_loads(original.read_text('utf-8'))
    review_bundle(original.parent,data) # Revalidate the original raw evidence first.
    qpath=Path(qualification_path).resolve();q=strict_json_loads(qpath.read_text('utf-8'))
    require(q['source_sha256']==source_fingerprint(ROOT),'current qualification required')
    output.mkdir(parents=True)
    def save(name,raw):
        path=output/name;path.parent.mkdir(parents=True,exist_ok=True);path.write_bytes(raw)
        return dict(path=name,sha256=hashlib.sha256(raw).hexdigest())
    data['control_export']=save('control_export.json',read_ref(original.parent,data['control_export']))
    for name,ref in data['archive'].items():
        data['archive'][name]=save(ref['path'],read_ref(original.parent,ref))
    baseline=ROOT/'docs/phase5/artifacts/adviser_timing_reuse_20261104'
    data['timing_reuse']=dict(
        control_qualification=save('control_qualification.json',read_ref(original.parent,data['qualification'])),
        reviewed_source=save('reviewed_source.json',(baseline/'before_source.json').read_bytes()),
        native_before=save('native_before.txt',(baseline/'before/src/pokiguard_v2/reasoning_common_native.py').read_bytes()))
    data['qualification']=save('qualification.json',qpath.read_bytes())
    data['control_source_sha256']=data['source_sha256'];data['source_sha256']=q['source_sha256']
    data.update(max_attempts=max_attempts,installed=False,live_acceptance=False)
    components,samples=review_bundle(output,data)
    (output/'common.json').write_text(json.dumps(data,ensure_ascii=False,indent=2),encoding='utf-8')
    return dict(profile=str(output/'common.json'),samples=samples,components=components,
        control_source_sha256=data['control_source_sha256'],source_sha256=data['source_sha256'],
        installed=False,automatic_start=False,live_acceptance=False)


def main():
    p=argparse.ArgumentParser(description=__doc__)
    p.add_argument('--export',type=Path,required=True);p.add_argument('--qualification',type=Path,required=True)
    p.add_argument('--output-dir',type=Path,required=True);p.add_argument('--max-attempts',type=int,default=3)
    a=p.parse_args();print(json.dumps(prepare(a.export,a.qualification,a.output_dir,max_attempts=a.max_attempts)))


if __name__=='__main__':main()
