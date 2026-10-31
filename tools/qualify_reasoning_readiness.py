"""P3 offline warm producer qualification. Own helper PIDs only, no game IO."""
from dataclasses import replace
import argparse, hashlib, json, os
from pathlib import Path
import statistics, sys, time
from collections import deque
ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src'),str(ROOT/'tests')]
from tools.qualify_reasoning_integration import KnownProcessCPU
from tools.evaluate_reasoning_runner import dump, quantiles, own_process_resources, wait_for
from tests.test_reasoning_pilot import scoped_state, pilot_authority, MemorySink
from pokiguard_v2.basic_policy import PolicyConfig, BasicPolicyEngine
from pokiguard_v2.reasoning_pilot import PilotSelectionBridge
from pokiguard_v2.reasoning_selection import select_safely
from pokiguard_v2.reasoning_diagnostics import BoundedDiagnostics, LogLimits


def sources():
    # Exact affected production modules; file-only activation/export are qualified separately.
    names=['reasoning_pilot','reasoning_warm_runner','reasoning_runner','reasoning_diagnostics',
      'reasoning_selection','reasoning_pilot_contract','reasoning_planner','reasoning_snapshot',
      'reasoning_telemetry','reasoning_refinement','board_diagnostics','basic_policy']
    paths=['src/pokiguard_v2/'+n+'.py' for n in names]+[
      'tools/qualify_reasoning_readiness.py','tests/test_reasoning_pilot.py']
    return {p:hashlib.sha256((ROOT/p).read_bytes()).hexdigest() for p in paths}


def make_bridge(directory, *, sink=None):
    config=PolicyConfig(minimum_turn_time_seconds=1,minimum_evolve_time_seconds=1)
    state=scoped_state();a=pilot_authority(state,config)
    sink=sink or BoundedDiagnostics(directory,limits=LogLimits(records=432,bytes=6*1024*1024))
    b=PilotSelectionBridge(authority=a,diagnostics=sink,verified_build_sha256=a.game_build_sha256,
      enabled=True,warm_worker=True,decision_budget=True)
    return b,config,state,sink


def exercise(b,config,state,index):
    state=replace(state,battle=replace(state.battle,turn_number=14+index*2,srv_seq=14+index*2))
    now=time.perf_counter_ns();baseline=BasicPolicyEngine(config).decide(state)
    b.observe(state,config,observed_ns=now,read_end_ns=now,context=b.pilot_authority.context)
    begin=time.perf_counter_ns()
    reason=b.await_decision(state,baseline,config,context=b.pilot_authority.context,stop_requested=lambda:False)
    decision_ms=(time.perf_counter_ns()-begin)/1e6
    begin=time.perf_counter_ns()
    selected=select_safely(b,state,baseline,config,now_ns=time.perf_counter_ns(),input_allowed=True,
      context=b.pilot_authority.context)
    return dict(index=index,decision_wait_ms=decision_ms,selection_ms=(time.perf_counter_ns()-begin)/1e6,
      reason=reason,override=selected.receipt is not None)


def soak(out,seconds):
    frozen=sources();dump(out/'protocol.json',dict(affected_sources=frozen,seconds=seconds,warmup_s=30,
      cadence_s=2,sampling_s=.1,growth_windows_s=300,synthetic=True,game_attach=False,input_authority=False,
      workload='real BASIC -> immutable producer -> warm isolated planner -> completed selector -> capped separate AI writer; no input/ACK',
      limits=dict(main_CPU_host_pp=5,total_private_MiB=256,main_private_MiB=32,queue_MiB=8,growth_MiB=8),
      cpu_scope='whole main and final lifetime CPU of all known children including startup; host normalized'))
    before=own_process_resources(os.getpid());cpu=KnownProcessCPU()
    dump(out/'baseline.json',dict(main_pid=os.getpid(),resources=before))
    b,c,s,sink=make_bridge(out/'ai');first=[];last=deque(maxlen=4000)
    peak_main=before['private_bytes'];peak_total=peak_main;peak_queue=0;rows=[]
    started=time.perf_counter();index=0
    try:
        with (out/'raw.jsonl').open('w',buffering=1) as raw, (out/'jobs.jsonl').open('w',buffering=1) as job_raw:
            while time.perf_counter()-started < seconds+30:
                rows.append(exercise(b,c,s,index));job_raw.write(json.dumps(rows[-1])+'\n');index+=1
                until=min(started+index*2,started+seconds+30)
                while time.perf_counter()<until:
                    elapsed=time.perf_counter()-started
                    values=[r for pid in {os.getpid(),b.runner.active_pid,sink.pid}
                      if pid and (r:=own_process_resources(pid))]
                    for r in values:
                        if r['pid']!=os.getpid():cpu.observe(r['pid'])
                    own=next(r for r in values if r['pid']==os.getpid())
                    total=sum(r['private_bytes'] for r in values)
                    queue=b.diagnostics.queued_bytes+b.relay.bytes+sink.buffer.queued_bytes
                    peak_main=max(peak_main,own['private_bytes']);peak_total=max(peak_total,total);peak_queue=max(peak_queue,queue)
                    if 30<=elapsed<330:first.append(own['private_bytes'])
                    if elapsed>=seconds+30-300:last.append(own['private_bytes'])
                    raw.write(json.dumps(dict(elapsed_s=elapsed,resources=values,queue_bytes=queue,
                      jobs=b.bridge_counts['jobs_submitted']),separators=(',',':'))+'\n')
                    time.sleep(.1)
                if index%30==0:
                    dump(out/'progress.json',dict(elapsed_s=time.perf_counter()-started,jobs=index))
                    print(f'P3 warm soak {time.perf_counter()-started:.1f}/{seconds+30}s jobs={index}',flush=True)
        wait_for(lambda:b.relay.bytes==0 and b.diagnostics.queued_bytes==0)
        flushed=sink.flush();accounting=sink.buffer.stats()
    finally:
        b.stop();closed=b.close();sink.stop();writer_closed=sink.close();child_cpu=cpu.finish()
    after=own_process_resources(os.getpid());wall=time.perf_counter()-started
    dump(out/'final_raw.json',dict(after=after,wall=wall,child_cpu=child_cpu,accounting=accounting,
      closed=closed,writer_closed=writer_closed,flushed=flushed,runner_counts=dict(b.runner.counters),
      producer_counts=dict(b.bridge_counts),peak_main=peak_main,peak_total=peak_total,peak_queue=peak_queue))
    main_cpu=(after['cpu_ns']-before['cpu_ns'])/1e9/wall/(os.cpu_count() or 1)*100
    growth=statistics.median(last)-statistics.median(first)
    gates=dict(fixed_30min=seconds>=1800,all_sources_unchanged=sources()==frozen,
      one_warm_process=b.runner.counters['processes']==1,all_children_counted=len(child_cpu)==2,
      all_jobs_completed=all(r['reason']=='COMPLETED' for r in rows),all_jobs_selected=all(r['override'] for r in rows),
      main_CPU=main_cpu<=5,main_private=peak_main-before['private_bytes']<=32*1024**2,
      total_private=peak_total-before['private_bytes']<=256*1024**2,queue=peak_queue<=8*1024**2,
      growth=growth<=8*1024**2,healthy_log=flushed and accounting['eligible']==accounting['written']
      and all(accounting[k]==0 for k in ('dropped_before_enqueue','failed_write','discarded_after_enqueue')),cleanup=closed and writer_closed)
    dump(out/'resources.json',dict(gates=gates,elapsed_s=wall,jobs=index,main_CPU_host_pp=main_cpu,
      total_CPU_host_pp=(after['cpu_ns']-before['cpu_ns']+sum(child_cpu.values()))/1e9/wall/(os.cpu_count() or 1)*100,
      child_CPU_ns=child_cpu,main_added_private_bytes=peak_main-before['private_bytes'],
      total_added_private_bytes=peak_total-before['private_bytes'],queue_peak_bytes=peak_queue,growth_bytes=growth,
      first_window_N=len(first),last_window_N=len(last),accounting=accounting,runner_counts=dict(b.runner.counters),
      producer_counts=dict(b.bridge_counts),decision_wait=quantiles([r['decision_wait_ms'] for r in rows]),
      checkpoint=quantiles([r['selection_ms'] for r in rows]),raw_jobs=rows,
      scope='synthetic software/resource only; no native efficacy or timer calibration'))


def main():
    p=argparse.ArgumentParser();p.add_argument('--out',type=Path,required=True)
    p.add_argument('--seconds',type=float,default=1800);args=p.parse_args()
    if args.out.exists():raise SystemExit('Frozen output exists')
    args.out.mkdir(parents=True);soak(args.out,args.seconds)


if __name__=='__main__':main()
