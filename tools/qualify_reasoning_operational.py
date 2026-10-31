"""P10 offline current-source trace, timing, CPU, Stop and bounded stress checks.

Native/game/input surfaces are controller fakes. Never prepares live authority.
"""
import argparse
import ast
from collections import Counter, deque
from dataclasses import replace
import json
import hashlib
from pathlib import Path
import sys
import time
import threading
import unittest

ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src'),str(ROOT/'tests')]
from tests.reasoning_controller_fixture import controller_trace, operational_baseline, assert_c3_source_compatibility
from tests.test_reasoning_operational import native_state, operational_authority, PARAMS
from tests.test_reasoning_pilot import MemorySink
from pokiguard_v2.basic_policy import PolicyConfig, BasicPolicyEngine, PlayStyle
from pokiguard_v2.reasoning_pilot import PilotSelectionBridge
from pokiguard_v2.reasoning_operational import operational_deadline_ns, host_fingerprint
from pokiguard_v2.reasoning_calibration import source_files, source_fingerprint
from pokiguard_v2.reasoning_selection import GuardedSelectionAdapter, select_safely, revalidate_safely
from pokiguard_v2.reasoning_diagnostics import DiagnosticBuffer, LogLimits
from pokiguard_v2.reasoning_swap_timing import SwapTimingCollector
from pokiguard_v2.autonomous_control import AutonomousSource
from tools.qualify_reasoning_selection import quantiles


def controller_ast_parity():
    directory,_=operational_baseline(ROOT)
    before=ast.parse((directory/'before/tools/basic_auto_bot.py').read_text(encoding='utf-8'))
    current=ast.parse((ROOT/'tools/basic_auto_bot.py').read_text(encoding='utf-8'))
    counts={}
    class Remove(ast.NodeTransformer):
        def visit_If(self,node):
            if ast.unparse(node.test)=='swap_timing_adapter is not None':
                calls=[n for n in ast.walk(node) if isinstance(n,ast.Call) and isinstance(n.func,ast.Name)
                       and n.func.id=='timing_safely']
                if len(calls)==1 and len(calls[0].args)>1:
                    name=ast.literal_eval(calls[0].args[1])
                    if name in ('observe_start','observe_end','decision','checkpoint'):
                        counts[name]=counts.get(name,0)+1;return None
            if ast.dump(node.test,include_attributes=False)==ast.dump(ast.parse(
                    'failure is None and selection_receipt is not None and swap_timing_adapter is not None',
                    mode='eval').body,include_attributes=False):
                counts['preflight_veto']=counts.get('preflight_veto',0)+1;return None
            return self.generic_visit(node)
    current=Remove().visit(current)
    return dict(counts=counts,pass_counts=counts==dict(observe_start=1,observe_end=1,decision=1,checkpoint=2,preflight_veto=1),
        pass_ast=ast.dump(before,include_attributes=False)==ast.dump(current,include_attributes=False))


def admission_costs(out, state, config, authority, offer, observed_ns):
    """Real current admission plus three checkpoints, with inert owner only."""
    paths={}; cpu={}; outcomes={}
    baseline=BasicPolicyEngine(config).decide(state)
    with (out/'admission_raw.jsonl').open('x',encoding='utf-8') as raw:
        for mode in ('admitted','span_rejected','clock_rejected','busy'):
            values=[]; cpus=[]
            for index in range(6000):
                adapter=object.__new__(PilotSelectionBridge)
                GuardedSelectionAdapter.__init__(adapter,completed=offer,
                    diagnostics=DiagnosticBuffer(LogLimits(records=64,bytes=128*1024,reserved_bytes=16*1024)),
                    enabled=True,pilot_authority=authority)
                adapter.request_lock=threading.Lock();adapter.request=None
                adapter.bridge_counts=Counter();adapter.wake=threading.Event()
                adapter.decision_budget=True;adapter.last_admission=None;adapter.checkpoints=deque(maxlen=64)
                if mode=='busy':adapter.request_lock.acquire()
                cap_ns=int(authority.max_root_poll_span_ms*1e6)
                read_end=observed_ns+(cap_ns+1 if mode=='span_rejected' else cap_ns)
                if mode=='clock_rejected':read_end=observed_ns-1
                begin_cpu=time.process_time_ns();begin=time.perf_counter_ns()
                adapter.observe(state,config,observed_ns=observed_ns,read_end_ns=read_end,context=authority.context)
                selected=select_safely(adapter,state,baseline,config,now_ns=offer.completed_ns,input_allowed=True,context=authority.context)
                fresh=revalidate_safely(adapter,offer,state,baseline,config,now_ns=offer.completed_ns,input_allowed=True,context=authority.context)
                final=revalidate_safely(adapter,offer,state,baseline,config,now_ns=offer.completed_ns,input_allowed=True,
                    context=authority.context,final=True,final_remaining_seconds=12)
                elapsed=(time.perf_counter_ns()-begin)/1e6;cpu_elapsed=(time.process_time_ns()-begin_cpu)/1e6
                if mode=='busy':adapter.request_lock.release()
                expected=dict(admitted='RETAIN_BASELINE',span_rejected='OBSERVATION_READ_SPAN_EXCEEDED',
                    clock_rejected='OBSERVATION_CLOCK_INVALID',busy='ADMISSION_BUSY')[mode]
                if (selected.reason,fresh,final)!=(expected,expected,expected):
                    raise AssertionError('admission path changed during measurement')
                if index==1000:outcomes[mode]=dict(root=selected.reason,fresh=fresh,final=final)
                if index>=1000:values.append(elapsed);cpus.append(cpu_elapsed)
                record=dict(path=mode,index=index,warmup=index<1000,ms=elapsed,cpu_ms=cpu_elapsed)
                if authority.root_read_policy is not None:
                    record.update(root_read_policy=authority.root_read_policy.plain(),read_span_ns=read_end-observed_ns)
                raw.write(json.dumps(record)+'\n')
            paths[mode]=quantiles(values);cpu[mode]=sum(cpus)/5000
    return paths,cpu,outcomes


def qualify(out,stress_seconds,*,reviewed_v3=False,reviewed_v4=False,reviewed_v5=False,profile='simple',shared_guard=False):
    if profile not in ('simple','careful'):raise ValueError('D1 Simple/Careful profile required')
    if shared_guard and not reviewed_v5:raise ValueError('shared guard requires current reviewed-v5 path')
    reviewed_v4=reviewed_v4 or reviewed_v5
    reviewed_v3=reviewed_v3 or reviewed_v4
    out.mkdir(parents=True,exist_ok=False)
    frozen_files=source_files(ROOT);runtime_sha=source_fingerprint(ROOT)
    (out/'source_manifest.json').write_text(json.dumps(dict(files=frozen_files,
        fingerprint=runtime_sha,source_count=len(frozen_files)),indent=2)+'\n',encoding='utf-8')
    gates={};audit=controller_ast_parity()
    gates['disabled_controller_ast_exact']=audit['pass_ast'] and audit['pass_counts']
    assert_c3_source_compatibility(unittest.TestCase());gates['historical_sources_exactly_bound']=True
    from tests.test_reasoning_selection import original_controller
    for case in ('normal','pending','stale','wrong_turn','stop'):
        before=controller_trace(out/(case+'_before.jsonl'),case=case,controller_module=original_controller())
        current=controller_trace(out/(case+'_after.jsonl'),case=case)
        gates['disabled_trace:'+case]=before==current
    s=native_state();c=PolicyConfig(play_style=PlayStyle(profile));a=operational_authority(s,c,max_read_span_ms=100,
        valid_until_ns=time.perf_counter_ns()+300_000_000_000)
    if reviewed_v4:
        from dataclasses import replace
        from pokiguard_v2.reasoning_snapshot import FrozenJSON
        from pokiguard_v2.reasoning_root_policy import POLICY
        a=replace(a,root_read_policy=FrozenJSON.of(POLICY))
    if reviewed_v5:
        from pokiguard_v2.reasoning_config_projection import VERSION
        a=replace(a,config_projection_policy=VERSION)
    if shared_guard:
        from pokiguard_v2.reasoning_component_guard import VERSION as GUARD_VERSION
        a=replace(a,component_guard_policy=GUARD_VERSION)
    baseline=BasicPolicyEngine(c).decide(s)
    b=PilotSelectionBridge(authority=a,diagnostics=MemorySink(),verified_build_sha256=a.game_build_sha256,
        enabled=True,decision_budget=True,warm_worker=True)
    try:
        start=time.perf_counter_ns();b.observe(s,c,observed_ns=start,read_end_ns=start,context=a.context)
        b.await_decision(s,baseline,c,context=a.context,stop_requested=lambda:False)
        if b.completed is None:raise AssertionError(dict(b.bridge_counts))
        offer=b.completed
        timings={};cpu={};outcomes={};raw_path=out/'checkpoint_raw.jsonl'
        with raw_path.open('x',encoding='utf-8') as raw:
            for mode in ('disabled','completed','timeout','error','fallback'):
                samples=[];cpu_samples=[]
                for index in range(6000):
                    # Exercise the actual pilot checkpoint/admission override,
                    # with inert ownership here; b above supplies a real worker
                    # completion. Never spawn 30,000 workers for a microbench.
                    adapter=object.__new__(PilotSelectionBridge)
                    GuardedSelectionAdapter.__init__(adapter,completed=offer if mode in ('completed','timeout') else None,
                        diagnostics=DiagnosticBuffer(LogLimits(records=64,bytes=128*1024,reserved_bytes=16*1024)),
                        enabled=True,pilot_authority=a)
                    adapter.last_admission=dict(reason='ADMITTED',observed_ns=start,read_end_ns=start)
                    adapter.checkpoints=deque(maxlen=64)
                    if mode=='error':adapter.disabled=True
                    if mode=='disabled':adapter=None
                    now=offer.job.deadline_ns if mode=='timeout' else offer.completed_ns
                    cpu_begin=time.process_time_ns()
                    begin=time.perf_counter_ns()
                    selected=fresh=final=None
                    if adapter is not None:
                        operational_deadline_ns(observed_ns=start,remaining_ms=12000,now_ns=now,
                            reserve_ms=a.reserve_ms,return_margin_ms=a.return_margin_ms)
                        selected=select_safely(adapter,s,baseline,c,now_ns=now,input_allowed=True,context=a.context)
                        fresh=revalidate_safely(adapter,offer,s,baseline,c,now_ns=now,input_allowed=True,context=a.context)
                        final=revalidate_safely(adapter,offer,s,baseline,c,now_ns=now,input_allowed=True,context=a.context,
                            final=True,final_remaining_seconds=12)
                    elapsed=(time.perf_counter_ns()-begin)/1e6
                    cpu_elapsed=(time.process_time_ns()-cpu_begin)/1e6
                    if adapter is not None:
                        expected_reason=dict(completed='RETAIN_BASELINE',timeout='LATE_PROPOSAL',
                            error='DIAGNOSTIC_DISABLED',fallback='NO_COMPLETED_PROPOSAL')[mode]
                        if selected.reason!=expected_reason:
                            raise AssertionError('checkpoint path changed during measurement')
                    if index==1000:
                        outcomes[mode]=dict(root=None if selected is None else selected.reason,fresh=fresh,final=final)
                    if index>=1000:samples.append(elapsed);cpu_samples.append(cpu_elapsed)
                    raw.write(json.dumps(dict(path=mode,index=index,warmup=index<1000,ms=elapsed,cpu_ms=cpu_elapsed))+'\n')
                timings[mode]=quantiles(samples)
                cpu[mode]=sum(cpu_samples)/len(cpu_samples)
                q=timings[mode];gates['checkpoint_latency:'+mode]=all(q[k]<=v for k,v in
                    zip(('p50','p95','p99','max'),(1.5,3,9,30)))
            gates['added_cpu_three_checkpoints_under_1_5ms']=max(cpu.values())-cpu['disabled']<=1.5
        expected=dict(completed='RETAIN_BASELINE',timeout='LATE_PROPOSAL',error='DIAGNOSTIC_DISABLED',fallback='NO_COMPLETED_PROPOSAL')
        for mode,reason in expected.items():gates['measured_path:'+mode]=outcomes[mode]['root']==reason
        admission_paths=admission_cpu=admission_outcomes=None
        if reviewed_v3:
            admission_paths,admission_cpu,admission_outcomes=admission_costs(out,s,c,a,offer,start)
            for mode,stats in admission_paths.items():
                gates['admission_latency:'+mode]=all(stats[k]<=v for k,v in zip(('p50','p95','p99','max'),(1.5,3,9,30)))
            expected_admission=dict(admitted='RETAIN_BASELINE',span_rejected='OBSERVATION_READ_SPAN_EXCEEDED',
                clock_rejected='OBSERVATION_CLOCK_INVALID',busy='ADMISSION_BUSY')
            for mode,reason in expected_admission.items():
                gates['admission_outcome:'+mode]=all(v==reason for v in admission_outcomes[mode].values())
            gates['admission_cpu_under_1_5ms']=max(admission_cpu.values())<=1.5
        stop=[]
        for _ in range(1000):
            begin=time.perf_counter_ns();b.stop();stop.append((time.perf_counter_ns()-begin)/1e6)
        gates['signal_only_stop_under_25ms']=max(stop)<25
        gates['worker_reaped']=b.close() and b.runner.counters['processes']==b.runner.counters['reaped']
    finally:b.close()
    # Actual full host-only calibration pipeline at bounded fixed memory. Fresh
    # sinks are allocated outside timed interval, with no native input/disk wait.
    collector_timings=[]
    with (out/'pipeline_raw.jsonl').open('x',encoding='utf-8') as raw:
        for index in range(6000):
            sink=MemorySink();collector=SwapTimingCollector(sink=sink,run_id='SYNTHETIC',
                operational_authority=a if reviewed_v3 else None,component_monitor=reviewed_v3)
            begin=time.perf_counter_ns()
            collector.observe_start();collector.observe_end(state=s)
            collector.decision(state=s,config=c,input_parameters=PARAMS)
            collector.checkpoint(name='fresh');collector.checkpoint(name='final')
            collector.start(state=s,config=c,input_mode='foreground',source_hash=AutonomousSource.from_state(s).critical_state_hash)
            collector.preflight(remaining=12,failure=None,read_end_ns=time.perf_counter_ns())
            collector.finish(result=None,status='SYNTHETIC_NO_INPUT')
            elapsed=(time.perf_counter_ns()-begin)/1e6
            if index>=1000:collector_timings.append(elapsed)
            if collector.disabled or len(sink.buffer.items)!=1:raise AssertionError('timing pipeline lost record')
            if reviewed_v3:
                payload=json.loads(sink.buffer.items[0])['payload']
                if payload['component_monitor']!='POST_RETURN_COMPONENTS_V1' or any(payload['component_overruns'].values()):
                    raise AssertionError('v3 operational monitor path not measured')
            record=dict(index=index,warmup=index<1000,ms=elapsed)
            if reviewed_v5:
                if collector.authority.config_projection_policy != VERSION or not collector.component_monitor:
                    raise AssertionError('successor config projection path not measured')
                record['config_projection_policy']=VERSION
                record['source_projection_policy']='UNCACHED_AUTONOMOUS_SOURCE_V1'
                if shared_guard:record['component_guard_policy']=GUARD_VERSION
            raw.write(json.dumps(record)+'\n')
    q=quantiles(collector_timings)
    gates['full_timing_pipeline_latency']=all(q[k]<=v for k,v in zip(('p50','p95','p99','max'),(.5,1,3,10)))
    # Fixed-memory calibration-probe stress, independently of selector CPU.
    import tracemalloc
    tracemalloc.start();stress_start=time.perf_counter();cpu_start=time.process_time()
    loops=0;high=0
    while time.perf_counter()-stress_start<stress_seconds:
        sink=MemorySink();collector=SwapTimingCollector(sink=sink,run_id='SYNTHETIC_STRESS',
            operational_authority=a if reviewed_v3 else None,component_monitor=reviewed_v3)
        collector.observe_start();collector.observe_end(state=s)
        collector.decision(state=s,config=c,input_parameters=PARAMS)
        collector.stop();loops+=1;high=max(high,len(sink.buffer.items))
    current,peak=tracemalloc.get_traced_memory();tracemalloc.stop()
    stress=dict(seconds=time.perf_counter()-stress_start,cpu_seconds=time.process_time()-cpu_start,
        loops=loops,max_queued_records=high,final_traced_bytes=current,peak_traced_bytes=peak)
    gates['bounded_stress_no_retained_history']=high<=1 and peak<16*1024*1024
    gates['final_source_still_frozen']=source_files(ROOT)==frozen_files
    gates['full_60_second_stress']=stress['seconds']>=60
    (out/'stop_raw.json').write_text(json.dumps(stop)+'\n',encoding='utf-8')
    result=dict(schema='5d1.p13.qualification.v1',gates=gates,pass_all=all(gates.values()),
        controller_ast=audit,selector_paths_ms=timings,full_timing_pipeline_ms=q,stop_ms=quantiles(stop),
        mean_cpu_ms_per_three_checkpoints=cpu,
        measured_path_outcomes=outcomes,completed_worker_reply=offer.reply.reason,
        checkpoint_adapter='CURRENT_PILOT_METHODS_WITH_INERT_OWNER_AND_REAL_WORKER_REPLY',
        stress=stress,runtime_sha256=runtime_sha,host_sha256=host_fingerprint(),native_U_ms=None,native_R_ms=None,
        game_attach=False,input_authority=False,production_activation=False,
        scope='CURRENT_SOURCE_OFFLINE_FAKES; NO_NATIVE_OR_WHOLE_APP_SOAK_CLAIM')
    if reviewed_v3:
        result.update(schema='5d1.p18.qualification.v1',component_monitor='POST_RETURN_COMPONENTS_V1',
            admission_paths_ms=admission_paths,admission_mean_cpu_ms=admission_cpu,admission_outcomes=admission_outcomes,
            pipeline_mode='OPERATIONAL_AUTHORITY_WITH_VALIDATED_COMPONENT_MONITOR',
            stress_evidence='RECEIPT_ONLY_NO_PER_CYCLE_TRACE',
            raw_sha256={n:hashlib.sha256((out/n).read_bytes()).hexdigest() for n in
                ('checkpoint_raw.jsonl','admission_raw.jsonl','pipeline_raw.jsonl','stop_raw.json','source_manifest.json')})
    if reviewed_v4:
        result['root_read_policy']=POLICY
    if reviewed_v5:
        result['config_projection_policy']=VERSION
        result['source_projection_policy']='UNCACHED_AUTONOMOUS_SOURCE_V1'
        result['profile']=profile
        if shared_guard:result['component_guard_policy']=GUARD_VERSION
    (out/'qualification.json').write_text(json.dumps(result,indent=2)+'\n',encoding='utf-8')
    print(json.dumps(dict(pass_all=result['pass_all'],gates=len(gates),failed=[k for k,v in gates.items() if not v])))


if __name__=='__main__':
    p=argparse.ArgumentParser();p.add_argument('--out',required=True,type=Path)
    p.add_argument('--stress-seconds',type=int,default=60)
    p.add_argument('--reviewed-v3',action='store_true');p.add_argument('--reviewed-v4',action='store_true')
    p.add_argument('--reviewed-v5',action='store_true')
    p.add_argument('--shared-guard',action='store_true')
    p.add_argument('--profile',choices=['simple','careful'],default='simple');args=p.parse_args()
    if not 10<=args.stress_seconds<=300:raise SystemExit('bounded10..300second scoped stress only')
    qualify(args.out,args.stress_seconds,reviewed_v3=args.reviewed_v3,reviewed_v4=args.reviewed_v4,
        reviewed_v5=args.reviewed_v5,profile=args.profile,shared_guard=args.shared_guard)
