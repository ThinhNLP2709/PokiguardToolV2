"""Recompute C3 v2 offline gates from frozen raw evidence; no game access."""
import argparse
from collections import Counter, defaultdict
import hashlib
import json
import math
from pathlib import Path
import re
import sys
import unittest

ROOT=Path(__file__).resolve().parents[1]
for path in (ROOT,ROOT/'src'):
    if str(path) not in sys.path:sys.path.insert(0,str(path))
NEW={'tools/qualify_reasoning_integration.py','tools/qualify_reasoning_disabled.py',
     'tools/qualify_reasoning_sink_cpu.py','tools/verify_reasoning_acceptance.py',
     'tests/reasoning_controller_fixture.py','tests/test_reasoning_acceptance.py'}


def read(path):return json.loads(path.read_text(encoding='utf-8'))


def digest(path):return hashlib.sha256(path.read_bytes()).hexdigest()


def dump(path,value):
    path.write_text(json.dumps(value,ensure_ascii=False,indent=2,allow_nan=False)+'\n',encoding='utf-8')


def quantiles(values):
    values=sorted(values)
    return {k:values[math.ceil(len(values)*p)-1]/1e6 for k,p in
        (('p50',.5),('p95',.95),('p99',.99),('max',1))}


def healthy(stats):
    return (stats['accounting_valid'] and stats['eligible']==stats['written'] and
        all(stats[k]==0 for k in ('dropped_before_enqueue','failed_write',
            'discarded_after_enqueue','queued','in_writer','charged_bytes')))


def verify(out):
    gates={};details={}
    previous=read(out.parent/'5c3_integration_v1/source_manifest.json')['files']
    current={p.relative_to(ROOT).as_posix():digest(p) for base in ('src','tools','tests')
        for p in sorted((ROOT/base).rglob('*.py'))}
    remediation={'src/pokiguard_v2/reasoning_diagnostics.py','tests/test_reasoning_integration.py'}
    gates['248_existing_C3_sources_byte_preserved']=len(previous)==250 and all(current.get(p)==sha for p,sha in previous.items() if p not in remediation)
    from tests.reasoning_controller_fixture import assert_c3_source_compatibility
    assert_c3_source_compatibility(unittest.TestCase())
    gates['AI_rotation_and_source_audit_only_changes']=True
    gates['new_sources_offline_allowlist']=set(current)-set(previous)==NEW
    dump(out/'source_manifest.json',dict(files=current,fingerprint=hashlib.sha256(
        json.dumps(current,sort_keys=True,separators=(',',':')).encode()).hexdigest()))
    for directory in ('causal_native_timing','resource_soak','disabled_resources','paired_sink_cpu'):
        frozen=read(out/directory/'protocol.json')['source_files']
        # All preexisting sources are fixed. New harnesses added later are not
        # imported by the timing/soak process; its entry point is also fixed.
        entries={'causal_native_timing':{'tools/qualify_reasoning_integration.py'},
            'resource_soak':{'tools/qualify_reasoning_integration.py'},
            'disabled_resources':{'tools/qualify_reasoning_disabled.py','tests/reasoning_controller_fixture.py'},
            'paired_sink_cpu':{'tools/qualify_reasoning_integration.py','tools/qualify_reasoning_sink_cpu.py'}}
        executed=set(previous)|entries[directory]
        if directory=='causal_native_timing':
            import ast
            old=(out.parent/'5c3_integration_v2/executed_sources/tools__qualify_reasoning_integration.py').read_text(encoding='utf-8')
            now=(ROOT/'tools/qualify_reasoning_integration.py').read_text(encoding='utf-8')
            def without_resource(text):
                module=ast.parse(text)
                module.body=[node for node in module.body if not isinstance(node,ast.FunctionDef) or node.name!='resources']
                return ast.dump(module,include_attributes=False)
            gates['benchmark_host_code_AST_preserved']=without_resource(old)==without_resource(now)
            gates['frozen_executed_sources.'+directory]=all(current.get(p)==frozen.get(p) for p in executed-remediation-{'tools/qualify_reasoning_integration.py'})
        else:gates['frozen_executed_sources.'+directory]=all(current.get(p)==frozen.get(p) for p in executed)
    data=read(out/'causal_native_timing/benchmark.json')
    grouped=defaultdict(list);warm=Counter();all_rows=0
    for line in (out/'causal_native_timing/raw.jsonl').open(encoding='utf-8'):
        row=json.loads(line);key=(row['run'],row['mode']);all_rows+=1
        if row['warmup']:warm[key]+=1
        else:grouped[key].append(row)
    gates['latency_raw_132000_pairs']=all_rows==132000 and len(grouped)==12
    for result in data['results']:
        key=(result['run'],result['mode']);rows=grouped[key]
        limits=[.1,.5,1,5] if key[1]=='disabled' else [.5,1,3,10]
        gates[f'latency_N.{key}']=len(rows)==10000 and warm[key]==1000
        for profile in sorted({r['profile'] for r in rows}):
            family=[r for r in rows if r['profile']==profile]
            addition=quantiles([r['mode_added_ns'] for r in family])
            control=quantiles([r['control_ns'] for r in family])
            actual=quantiles([r['mode_ns'] for r in family])
            gates[f'latency.{key}.{profile}']=all(addition[k]<=v for k,v in zip(addition,limits)) and all(
                actual[k]-control[k]<=v for k,v in zip(('p50','p95','p99'),limits))
        gates[f'common_log_parity.{key}']=all(g['parity'] for g in result['groups'])
    details['latency']=data['results']
    soak=read(out/'resource_soak/resources.json');mib=1024**2
    gates.update(resource_30_minutes=soak['protocol']['seconds']>=1800 and soak['elapsed_s']>=1830,
        main_CPU_cap=soak['main_CPU_host_pp']<=5,
        main_memory_cap=soak['main_added_private_bytes']<=32*mib,
        total_memory_cap=soak['total_added_private_bytes']<=256*mib,
        queue_cap=soak['queue_peak_bytes']<=8*mib,
        retained_growth=soak['growth_bytes'] is not None and soak['growth_bytes']<=8*mib,
        complete_growth_windows=soak['first_window_N']>=10000 and soak['last_window_N']>=10000,
        healthy_durable_log=healthy(soak['accounting']),
        healthy_jobs=soak['adapter_counts']['prepared']==soak['adapter_counts']['dispatched']==soak['adapter_counts']['outcomes']==soak['publications'],
        healthy_no_adapter_loss=all(soak['adapter_counts'][k]==0 for k in
            ('dropped','faults','unknown_attribution','log_dropped','discarded','rate_limited','log_rate_limited')),
        all_child_CPU_captured=soak['all_child_CPU_captured'],
        resource_cleanup=soak['cleanup'] and soak['runner_counts']['processes']==soak['runner_counts']['reaped'],
        no_selection_authority=not soak['status']['selection_authority'])
    details['resources']={k:v for k,v in soak.items() if k not in ('source_files','runner_timings')}
    last_sample=None
    for line in (out/'resource_soak/raw.jsonl').open(encoding='utf-8'):last_sample=json.loads(line)
    logger_candidates=[r['pid'] for r in last_sample['resources'] if r['pid']!=soak['baseline']['pid']]
    gates['lazy_writer_CPU_identity_verified']=len(logger_candidates)==1 and str(logger_candidates[0]) in soak['child_CPU_ns']
    if gates['lazy_writer_CPU_identity_verified']:
        writer_pid=logger_candidates[0]
        gates['corrected_writer_PID_metadata']=soak['writer_pid']==writer_pid
        details['resources']['verified_writer_pid_from_final_raw_sample']=writer_pid
        details['resources']['verified_main_plus_writer_CPU_upper_bound']=soak['main_CPU_host_pp']+soak['child_CPU_ns'][str(writer_pid)]/1e9/soak['elapsed_s']/soak['logical_cpus']*100
        details['resources']['cached_writer_pid_note']='V2 cached None before lazy launch; V3 updates metadata after launch and checks it against final raw; total CPU includes all retained child handles'
    durable=[]
    for path in sorted((out/'resource_soak/ai').glob('reasoning.*.jsonl')):
        durable.extend(json.loads(line) for line in path.open(encoding='utf-8'))
    event_counts=Counter(r['event_type'] for r in durable)
    gates['durable_AI_sequence_contiguous']=[r['event_seq'] for r in durable]==list(range(1,len(durable)+1))
    summaries=[r for r in durable if r['event_type']=='reasoning.run_summary']
    gates['durable_final_summary']=len(summaries)==1 and durable[-1] is summaries[0] and healthy(summaries[0]['payload']['log_watermark'])
    gates['durable_all_dispatch_outcomes']=event_counts['reasoning.shadow_dispatch']==event_counts['reasoning.shadow_outcome']==soak['publications']
    gates['durable_AI_has_no_authority']=all(r['input_authority'] is False and r['payload'].get('selection_authority',False) is False for r in durable)
    details['durable_event_counts']=dict(event_counts)
    disabled=read(out/'disabled_resources/result.json')
    gates['disabled_CPU']=disabled['main_CPU_host_pp_upper_bound']<=1
    gates['disabled_memory']=disabled['main_added_private_bytes']<=8*mib
    gates['disabled_no_AI_resources_reads_captures']=all(disabled[k]==0 for k in
        ('AI_modules','AI_threads','AI_jobs','AI_files','extra_reads','extra_captures'))
    details['disabled']=disabled
    sink=read(out/'paired_sink_cpu/result.json')
    gates['paired_sink_CPU_three_runs']=len(sink['rows'])==6 and len(sink['separate_minus_shared_CPU_host_pp'])==3
    gates['separate_minus_shared_CPU_cap']=all(v<=1 for v in sink['separate_minus_shared_CPU_host_pp'])
    gates['paired_sink_no_loss_reaped']=all(r['all_children_counted'] and all(healthy(s) for s in r['accounting']) and
        all(r['adapter_counts'][k]==0 for k in ('dropped','faults','unknown_attribution','log_dropped','discarded')) and
        r['runner_counts']['processes']==r['runner_counts']['reaped'] for r in sink['rows'])
    # A zero-cost shared admission is a conservative control for incremental
    # separate admission: complete shadow overhead is below the stricter row.
    gates['separate_admission_upper_bound_vs_shared']=all(all(group['paired_delta_ms'][k]<=v for k,v in
        zip(('p50','p95','p99','max'),[.1,.5,1,5])) for r in data['results'] if r['mode']=='shadow'
        for group in [r,*r['groups']])
    details['sink_CPU']=sink['separate_minus_shared_CPU_host_pp']
    evidence=[json.loads(s) for s in (out/'integration_raw.jsonl').read_text(encoding='utf-8').splitlines()]
    counts=Counter(r['kind'] for r in evidence)
    gates['actual_positive_controller_traces']=counts['full_controller_trace']==4 and all(r['gameplay_log_parity'] for r in evidence if r['kind']=='full_controller_trace')
    gates['actual_controller_Stop_signals_100']=counts['controller_stop_signal']==100
    gates['known_fault_fallback_30_each']=Counter(r['variant'] for r in evidence if r['kind']=='known_fault_fallback')==dict(admission_raises=30,stop_also_raises=30)
    for kind,limits in (('controller_stop_signal',[5,5,10,25]),('known_fault_fallback',[1,5,10,25])):
        q=quantiles([r['elapsed_ns'] for r in evidence if r['kind']==kind]);details[kind]=q
        gates[kind+'_latency']=all(q[k]<=v for k,v in zip(q,limits))
    b4=read(out.parent/'5b4_isolation_v4/faults/faults.json')
    gates['B4_fault_sources_compatible']=all(current.get(p)==sha for p,sha in b4['source_hashes'].items() if p!='src/pokiguard_v2/reasoning_diagnostics.py')
    gates['native_frozen_clock_rotation_30']=counts['frozen_clock_rotation']==30 and all(r['all_written'] for r in evidence if r['kind']=='frozen_clock_rotation')
    gates['B4_cooperative_cancel']=all(c['cooperative'] and c['duration_ns']<=100_000_000 for r in b4['trials'] if r['variant']=='cooperative' for c in r['cleanup'])
    gates['B4_hung_reap']=all(c['reaped'] and c['duration_ns']<=1_000_000_000 for r in b4['trials'] if r['variant']=='hang' for c in r['cleanup'])
    gates['B4_native_log_faults_30_each']=all(sum(r['variant']==v for r in b4['trials'])>=30 for v in ('log_denied','log_disk_full','log_hang','log_crash'))
    old=read(out.parent/'5c3_integration_v1/verification.json')
    details['parent_v1_verification']=old
    log=(out/'full_regression.log').read_text(encoding='utf-8')
    match=re.search(r'Ran (\d+) tests in ([\d.]+)s',log)
    gates['full_regression']=bool(match and int(match[1])>=1966 and log.rstrip().endswith('OK'))
    details['regression']=None if match is None else dict(tests=int(match[1]),seconds=float(match[2]))
    result='PASS_OFFLINE_LIVE_PENDING' if all(gates.values()) else 'PARTIAL'
    dump(out/'verification.json',dict(schema='pokiguard.phase5.c3_verification.v2',
        result=result,gates=gates,details=details,live_attempts=0,
        interpretation='offline SWAP observer scope; B4 component cancellation/native fault evidence retained with exact source binding; shared CPU comparator emulated'))
    print(result,len(gates),'gates; failures:',[k for k,v in gates.items() if not v])


def seal(out):
    documents=['docs/phase5/STATUS.md','docs/phase5/ROUTER.md','docs/phase5/README.md',
        'docs/phase5/ROADMAP.md','docs/phase5/PROMPT_INDEX.md','docs/phase5/capability_manifest.md',
        'docs/phase5/reports/5c3_report.md','docs/phase5/reports/5c3_partial_v1_report.md',
        'docs/phase5/reports/5c3_rotation_remediation_report.md',
        'docs/phase5/research/5c3_measurement_return_plan.md',
        'docs/phase5/research/5c3_qualification_protocol_v2.md',
        'docs/CURRENT_STATE.md','docs/reasoning_gameplay_policy.md']
    links=[];broken=[]
    for name in documents:
        path=ROOT/name
        for target in re.findall(r'\]\(([^)]+)\)',path.read_text(encoding='utf-8')):
            target=target.strip('<>')
            if re.match(r'^[a-z]+://',target) or target.startswith(('#','mailto:')):continue
            target=re.sub(r':\d+$','',target.split('#')[0])
            destination=path.parent/target
            links.append((name,target))
            if not destination.exists() and destination.resolve()!=(out/'manifest.json').resolve():
                broken.append((name,target))  # This seal call creates its own manifest below.
    old=read(out.parent/'5c3_integration_v1/manifest.json')
    historical=[name for name,entry in old['artifacts'].items()
        if name.startswith('docs/phase5/artifacts/5c3_integration_v1/') and digest(ROOT/name)!=entry['sha256']]
    historical_report_ok=digest(ROOT/'docs/phase5/reports/5c3_partial_v1_report.md')==old['artifacts']['docs/phase5/reports/5c3_report.md']['sha256']
    dump(out/'integrity.json',dict(links_checked=len(links),broken_links=broken,
        historical_V1_artifact_mismatches=historical,
        historical_report_byte_preserved=historical_report_ok,
        historical_document_hashes='V1 hashes describe the historical PARTIAL report; archived report retained byte-for-byte',
        passed=not broken and not historical and historical_report_ok))
    files={p.relative_to(ROOT).as_posix():dict(sha256=digest(p),bytes=p.stat().st_size)
        for p in sorted(out.rglob('*')) if p.is_file() and p.name!='manifest.json'}
    dump(out/'manifest.json',dict(schema='pokiguard.phase5.c3_artifacts.v2',
        result=read(out/'verification.json')['result'],artifacts=files,
        documents={name:dict(sha256=digest(ROOT/name),bytes=(ROOT/name).stat().st_size) for name in documents}))
    print('integrity',not broken and not historical and historical_report_ok,'links',len(links),'artifacts',len(files))


if __name__=='__main__':
    parser=argparse.ArgumentParser();parser.add_argument('--out',type=Path,required=True)
    parser.add_argument('--seal',action='store_true');args=parser.parse_args()
    if args.seal:seal(args.out)
    else:verify(args.out)
