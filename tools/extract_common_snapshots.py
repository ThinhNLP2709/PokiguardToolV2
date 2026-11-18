"""Export exact recorded adviser inputs for offline replay, with log provenance."""
import argparse
from collections import Counter
import hashlib
import json
from pathlib import Path
import sys

ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.reasoning_common_capture import EVENT,decode_snapshot_event
from pokiguard_v2.reasoning_snapshot import strict_json_loads


def extract(paths):
    cases={};counts=Counter();manifest=[]
    for path in sorted(set(paths)):
        digest=hashlib.sha256();pending=[]
        with path.open('rb') as stream:
            for number,raw in enumerate(stream,1):
                digest.update(raw)
                if len(raw)>32768:
                    counts['oversized_lines']+=1;continue
                try:record=strict_json_loads(raw.decode('utf-8-sig'))
                except (ValueError,UnicodeError,RecursionError):
                    counts['invalid_json_lines']+=1;continue
                if type(record) is not dict or record.get('event_type')!=EVENT:continue
                counts['snapshot_events']+=1
                try:value=decode_snapshot_event(record)
                except (ValueError,TypeError,KeyError,IndexError):
                    counts['incomplete_or_invalid_snapshots']+=1;continue
                pending.append((number,hashlib.sha256(raw).hexdigest(),value))
        sha=digest.hexdigest();manifest.append(dict(path=str(path),sha256=sha))
        for number,line_sha,value in pending:
            if value.snapshot_id in cases:
                counts['duplicate_snapshots']+=1;continue
            cases[value.snapshot_id]=dict(snapshot_id=value.snapshot_id,profile=value.intent.profile,
                problem=value.to_dict(),provenance=dict(path=str(path),line=number,file_sha256=sha,line_sha256=line_sha),
                delivery_or_native_acceptance='UNKNOWN_REQUIRES_SEPARATE_ACTION_AND_ACK_JOIN',input_authority=False)
    return dict(schema='pokiguard.extracted_common_snapshots.v1',cases=list(cases.values()),
        counts=dict(counts),file_manifest=manifest,input_authority=False,damage_model_fitted=False)


def main():
    parser=argparse.ArgumentParser(__doc__)
    parser.add_argument('--logs',type=Path,required=True)
    parser.add_argument('--out',type=Path,required=True)
    args=parser.parse_args()
    paths=[args.logs] if args.logs.is_file() else args.logs.rglob('*.jsonl')
    output=extract(paths)
    args.out.parent.mkdir(parents=True,exist_ok=True)
    with args.out.open('x',encoding='utf-8') as stream:json.dump(output,stream,indent=2)
    print(json.dumps(dict(cases=len(output['cases']),counts=output['counts'],input_authority=False)))


if __name__=='__main__':main()
