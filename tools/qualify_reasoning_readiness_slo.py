"""P3 prepared checkpoint, actual warm fault/Stop and paired CPU probes.

All states/effects are synthetic. No game, read provider or input capability.
"""
from copy import copy
from collections import Counter, deque
from dataclasses import replace
import argparse, json, os
from pathlib import Path
import sys, time
ROOT=Path(__file__).resolve().parents[1];sys.path[:0]=[str(ROOT),str(ROOT/'src'),str(ROOT/'tests')]
from tools.qualify_reasoning_readiness import make_bridge,exercise,sources
from tools.qualify_reasoning_integration import KnownProcessCPU,controlled_main_thread
from tools.qualify_reasoning_sink_cpu import RouteSink
from tools.evaluate_reasoning_runner import dump,quantiles,wait_for,own_process_resources
from tests.test_reasoning_pilot import MemorySink,scoped_state,pilot_authority
from tests.reasoning_worker_fixtures import hang,corrupt,raises
from pokiguard_v2.reasoning_diagnostics import DiagnosticBuffer,LogLimits,BoundedDiagnostics
from pokiguard_v2.reasoning_pilot import PilotSelectionBridge
from pokiguard_v2.reasoning_selection import select_safely,revalidate_safely
from pokiguard_v2.basic_policy import BasicPolicyEngine,PolicyConfig


def checkpoints(out):
    b,c,s,sink=make_bridge(out/'warm');receipt=exercise(b,c,s,0)
    if not receipt['override']:raise RuntimeError('actual warm offer missing')
    offer=b.completed;baseline=BasicPolicyEngine(c).decide(s);now=offer.completed_ns+1
    def ready():
        a=copy(b);a.counts=Counter();a.checkpoints=deque(maxlen=64)
        a.diagnostics=DiagnosticBuffer(LogLimits(records=432,bytes=6*1024*1024))
        a._emitted=0;a._window=None;a._sequence=0
        return a
    def critical(a):
        if a is None:return baseline
        kw=dict(now_ns=now,input_allowed=True,context=a.pilot_authority.context)
        r=select_safely(a,s,baseline,c,**kw)
        fresh=revalidate_safely(a,r.receipt,s,baseline,c,**kw)
        final=revalidate_safely(a,r.receipt,s,baseline,c,**kw,final=True,final_remaining_seconds=12)
        if r.receipt is None or fresh is not None or final is not None:raise RuntimeError('checkpoint rejected')
        return r.decision
    summaries=[]
    try:
        with controlled_main_thread() as env,(out/'raw.jsonl').open('w') as raw:
            for run in range(3):
                for mode in (('disabled','ready') if run%2==0 else ('ready','disabled')):
                    deltas=[];absolute=[]
                    for index in range(11000):
                        a=ready() if mode=='ready' else None
                        def control():
                            start=time.perf_counter_ns();result=baseline
                            return time.perf_counter_ns()-start
                        def actual():
                            start=time.perf_counter_ns();critical(a)
                            return time.perf_counter_ns()-start
                        if index%2:ct,at=control(),actual()
                        else:at,ct=actual(),control()
                        raw.write(json.dumps(dict(run=run,mode=mode,index=index,warmup=index<1000,
                          control_ns=ct,actual_ns=at,paired_delta_ns=at-ct),separators=(',',':'))+'\n')
                        if index>=1000:deltas.append((at-ct)/1e6);absolute.append(at/1e6)
                    q=quantiles(deltas);limits=[.1,.5,1,5] if mode=='disabled' else [1,2,5,20]
                    summaries.append(dict(run=run,mode=mode,paired_added_ms=q,absolute_ms=quantiles(absolute),
                      passed=all(q[k]<=v for k,v in zip(('p50','p95','p99','max'),limits))))
    finally:b.stop();closed=b.close();sink.stop();writer=sink.close()
    dump(out/'result.json',dict(results=summaries,passed=all(r['passed'] for r in summaries),
      cleanup=closed and writer,environment=env,actual_cold_decision_wait=receipt,
      protocol=dict(runs=3,warmup_per_mode=1000,measured_per_mode=10000,clock='perf_counter_ns',
        prepared='actual warm completed offer; shallow adapter copy and fresh bounded diagnostic buffer OUTSIDE timed interval; immutable timestamp fixed; full production select/revalidate methods',
        disabled='three optional decisions collapsed to absence, same BASIC object; full native disabled trace separately',
        scope='prepared root+fresh+final checkpoint overhead; not intentional decision wait, disk durability or full live latency'),
      affected_sources=sources(),game_attach=False,input_authority=False))


def lifecycle(out):
    rows=[];stops=[]
    c=PolicyConfig(minimum_turn_time_seconds=1,minimum_evolve_time_seconds=1);s=scoped_state()
    baseline=BasicPolicyEngine(c).decide(s)
    for name,compute in (('deadline',hang),('corrupt',corrupt),('raises',raises)):
        for index in range(30):
            a=replace(pilot_authority(s,c),budget_ms=1500 if name=='deadline' else 4000)
            sink=MemorySink();b=PilotSelectionBridge(authority=a,diagnostics=sink,
              verified_build_sha256=a.game_build_sha256,enabled=True,warm_worker=True,decision_budget=True)
            b.runner.compute=compute;now=time.perf_counter_ns()
            b.observe(s,c,observed_ns=now,read_end_ns=now,context=a.context)
            reason=b.await_decision(s,baseline,c,context=a.context,stop_requested=lambda:False)
            start=time.perf_counter_ns();r=select_safely(b,s,baseline,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
            fallback_ms=(time.perf_counter_ns()-start)/1e6
            b.stop();closed=b.close()
            rows.append(dict(kind=name,index=index,reason=reason,fallback_ms=fallback_ms,
              baseline=r.decision is baseline,receipt_absent=r.receipt is None,
              cleanup=closed,processes=b.runner.counters['processes'],reaped=b.runner.counters['reaped'],
              cleanup_records=list(b.runner.cleanups)))
        print('P3 fault '+name,flush=True)
    for index in range(100):
        kind=('startup','active_hang','pending_owner','log_full','ready')[index%5]
        a=pilot_authority(s,c);sink=MemorySink()
        b=PilotSelectionBridge(authority=a,diagnostics=sink,verified_build_sha256=a.game_build_sha256,
          enabled=True,warm_worker=True,decision_budget=False)
        if kind!='startup':
            if kind=='active_hang':b.runner.compute=hang
            wait_for(b.runner.ready.is_set)
            now=time.perf_counter_ns();b.observe(s,c,observed_ns=now,read_end_ns=now,context=a.context)
            wait_for(lambda:b.runner.active_job is not None or b.completed is not None)
        if kind=='log_full':sink.buffer.disable('P3_EXPLICIT_FAULT')
        start=time.perf_counter_ns();b.stop();signal_ms=(time.perf_counter_ns()-start)/1e6
        r=select_safely(b,s,baseline,c,now_ns=time.perf_counter_ns(),input_allowed=kind!='pending_owner',context=a.context)
        start=time.perf_counter_ns();closed=b.close();cleanup_ms=(time.perf_counter_ns()-start)/1e6
        stops.append(dict(index=index,kind=kind,signal_ms=signal_ms,cleanup_ms=cleanup_ms,cleanup=closed,
          receipt_absent=r.receipt is None,processes=b.runner.counters['processes'],reaped=b.runner.counters['reaped']))
    summary={k:quantiles([r['fallback_ms'] for r in rows if r['kind']==k]) for k in ('deadline','corrupt','raises')}
    stop=quantiles([r['signal_ms'] for r in stops])
    gates=dict(faults_keep_basic=all(r['baseline'] and r['receipt_absent'] for r in rows),
      actual_hung_deadline=all(r['reason']=='DEADLINE' for r in rows if r['kind']=='deadline'),
      all_reaped=all(r['cleanup'] and r['processes']==r['reaped'] for r in rows+stops),
      stop_no_selection=all(r['receipt_absent'] for r in stops),
      known_fault_fallback=all(all(q[k]<=v for k,v in zip(('p50','p95','p99','max'),[1,5,10,25])) for q in summary.values()),
      stop_signal=all(stop[k]<=v for k,v in (('p95',5),('p99',10),('max',25))),
      cleanup_offcaller=max(r['cleanup_ms'] for r in stops)<=1000)
    dump(out/'result.json',dict(rows=rows,stops=stops,summary=summary,stop=stop,gates=gates,
      protocol='30 independent actual warm runner trials per fault; 100 Stop across 5 strata; pending owner is no-input selector check, full controller pending parity separately',
      affected_sources=sources(),game_attach=False,input_authority=False))


def cpu_pairs(out):
    rows=[]
    for run in range(3):
        for mode in (('control','separate') if run%2==0 else ('separate','control')):
            directory=out/f'{run}-{mode}';directory.mkdir()
            common=BoundedDiagnostics(directory/'common',limits=LogLimits(records=432,bytes=6*1024*1024))
            if mode=='separate':sink=BoundedDiagnostics(directory/'ai',limits=LogLimits(records=432,bytes=6*1024*1024))
            else:sink=common
            routed=RouteSink(common,sink)
            # Both queues receive identical gameplay-emulation bytes on the AI
            # producer thread, preserving single-producer buffer ownership.
            b,c,s,_=make_bridge(directory/'unused',sink=routed);cpu=KnownProcessCPU()
            before=own_process_resources(os.getpid());started=time.perf_counter();jobs=0
            try:
                while time.perf_counter()-started<30:
                    routed.pending.put(b'{"event":"P3_OFFLINE_COMMON_WRITER_EMULATION","input_authority":false}\n')
                    exercise(b,c,s,jobs);jobs+=1;until=started+jobs*2
                    while time.perf_counter()<until:
                        for pid in (b.runner.active_pid,common.pid,sink.pid):cpu.observe(pid)
                        time.sleep(.02)
                wait_for(lambda:b.relay.bytes==0 and b.diagnostics.queued_bytes==0)
                flushed=sink.flush() and common.flush();accounting=[sink.buffer.stats()]
                if common is not sink:accounting.append(common.buffer.stats())
            finally:
                b.stop();closed=b.close();sink.stop();writer=sink.close()
                if common is not sink:common.stop();writer=common.close() and writer
                children=cpu.finish()
            after=own_process_resources(os.getpid());wall=time.perf_counter()-started
            total=after['cpu_ns']-before['cpu_ns']+sum(children.values())
            rows.append(dict(run=run,mode=mode,jobs=jobs,seconds=wall,host_CPU_pp=total/1e9/wall/(os.cpu_count() or 1)*100,
              child_CPU_ns=children,accounting=accounting,cleanup=closed and writer,flushed=flushed,
              all_children_counted=len(children)==b.runner.counters['processes']+(2 if mode=='separate' else 1)))
            print(f'P3 CPU {run} {mode} {rows[-1]["host_CPU_pp"]:.4f}pp',flush=True)
    deltas=[next(r['host_CPU_pp'] for r in rows if r['run']==i and r['mode']=='separate')-
      next(r['host_CPU_pp'] for r in rows if r['run']==i and r['mode']=='control') for i in range(3)]
    dump(out/'result.json',dict(rows=rows,separate_minus_shared_host_pp=deltas,
      passed=statistics_mean(deltas)<=1 and all(r['cleanup'] and r['flushed'] and r['all_children_counted'] for r in rows),
      protocol='3 interleaved 30s pairs, fixed 2s jobs, whole actual warm pipeline incl startup; C1 shared queue emulation vs extra separate writer; identical gameplay rows both modes; fixed concurrent owned 2s warm soak, no regression workload',
      limitation='shared comparator is asynchronous gameplay-writer emulation; accepted synchronous native gameplay writer unchanged, not whole-app or live CPU certification',
      affected_sources=sources()))


def statistics_mean(x):return sum(x)/len(x)
def main():
    p=argparse.ArgumentParser();p.add_argument('--mode',choices=['checkpoints','lifecycle','cpu'],required=True)
    p.add_argument('--out',type=Path,required=True);args=p.parse_args()
    if args.out.exists():raise SystemExit('Frozen output exists')
    args.out.mkdir(parents=True);dict(checkpoints=checkpoints,lifecycle=lifecycle,cpu=cpu_pairs)[args.mode](args.out)
if __name__=='__main__':main()
