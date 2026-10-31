"""C3 v2 offline qualification; own helper processes only, no game/input access."""
from __future__ import annotations

import argparse
from contextlib import contextmanager
from dataclasses import replace
import ctypes
import gzip
import hashlib
import json
import os
from pathlib import Path
import platform
import statistics
import sys
import time

ROOT=Path(__file__).resolve().parents[1]
for directory in (ROOT,ROOT/'src'):
    if str(directory) not in sys.path:sys.path.insert(0,str(directory))

from pokiguard_v2.basic_policy import PlayStyle, BasicPolicyEngine
from pokiguard_v2.board_diagnostics import analyze_game_state
from pokiguard_v2.desktop_control_plane import DesktopConfig
from pokiguard_v2.desktop_farm_controller import (
    DesktopFarmControllerManager, DesktopControllerSnapshot, DesktopControllerState,
)
from pokiguard_v2.reasoning_settings import AISettings, RunShadowSession
from pokiguard_v2.reasoning_shadow import attach_shadow_log
from pokiguard_v2.gameplay_profile import MainPetType, EvolutionTarget, DamageCardMode, GameMode, AuditionMode
from tests.test_reasoning_shadow import publication, sent_row
from tools.basic_auto_bot import _decision_fields, _write
from tools.evaluate_reasoning_runner import dump, quantiles, own_process_resources, wait_for


class KnownProcessCPU:
    """Retain query handles so final child CPU remains readable after reap."""
    def __init__(self):
        from ctypes import wintypes
        self.kernel=ctypes.WinDLL('kernel32',use_last_error=True)
        self.kernel.OpenProcess.argtypes=(wintypes.DWORD,wintypes.BOOL,wintypes.DWORD)
        self.kernel.OpenProcess.restype=wintypes.HANDLE
        self.kernel.GetProcessTimes.argtypes=(wintypes.HANDLE,ctypes.POINTER(wintypes.FILETIME),
            ctypes.POINTER(wintypes.FILETIME),ctypes.POINTER(wintypes.FILETIME),ctypes.POINTER(wintypes.FILETIME))
        self.kernel.CloseHandle.argtypes=(wintypes.HANDLE,)
        self.FILETIME=wintypes.FILETIME;self.handles={}

    def observe(self,pid):
        if pid and pid not in self.handles:
            handle=self.kernel.OpenProcess(0x1000,False,pid)
            if handle:self.handles[pid]=handle

    def finish(self):
        values={}
        for pid,handle in self.handles.items():
            stamps=[self.FILETIME() for _ in range(4)]
            if not self.kernel.GetProcessTimes(handle,*(ctypes.byref(s) for s in stamps)):
                raise ctypes.WinError(ctypes.get_last_error())
            values[pid]=sum((s.dwHighDateTime<<32)+s.dwLowDateTime for s in stamps[2:])*100
            self.kernel.CloseHandle(handle)
        self.handles.clear()
        return values


@contextmanager
def controlled_main_thread():
    """Only this offline main thread; undo affinity/priority in all exit paths."""
    kernel=ctypes.WinDLL('kernel32',use_last_error=True)
    kernel.GetCurrentThread.restype=ctypes.c_void_p
    kernel.GetCurrentProcess.restype=ctypes.c_void_p
    kernel.SetThreadAffinityMask.argtypes=(ctypes.c_void_p,ctypes.c_size_t)
    kernel.SetThreadAffinityMask.restype=ctypes.c_size_t
    kernel.GetProcessAffinityMask.argtypes=(ctypes.c_void_p,ctypes.POINTER(ctypes.c_size_t),ctypes.POINTER(ctypes.c_size_t))
    kernel.GetThreadPriority.argtypes=(ctypes.c_void_p,)
    kernel.SetThreadPriority.argtypes=(ctypes.c_void_p,ctypes.c_int)
    process_mask,system_mask=ctypes.c_size_t(),ctypes.c_size_t()
    if not kernel.GetProcessAffinityMask(kernel.GetCurrentProcess(),ctypes.byref(process_mask),ctypes.byref(system_mask)):
        raise ctypes.WinError(ctypes.get_last_error())
    mask=1<<(process_mask.value.bit_length()-1)
    thread=kernel.GetCurrentThread();priority=kernel.GetThreadPriority(thread)
    previous=kernel.SetThreadAffinityMask(thread,mask)
    if not previous:raise ctypes.WinError(ctypes.get_last_error())
    try:
        if not kernel.SetThreadPriority(thread,1):raise ctypes.WinError(ctypes.get_last_error())
        yield dict(affinity_mask=mask,priority='ABOVE_NORMAL_THREAD_ONLY',realtime=False)
    finally:
        kernel.SetThreadPriority(thread,priority);kernel.SetThreadAffinityMask(thread,previous)


def metadata():
    sources={p.relative_to(ROOT).as_posix():hashlib.sha256(p.read_bytes()).hexdigest()
        for base in ('src','tools','tests') for p in sorted((ROOT/base).rglob('*.py'))}
    return dict(schema='pokiguard.c3.qualification.v2',date='2026-10-11',
        python=sys.version,platform=platform.platform(),logical_cpus=os.cpu_count(),
        clock=vars(time.get_clock_info('perf_counter')),source_files=sources,
        fingerprint=hashlib.sha256(json.dumps(sources,sort_keys=True,separators=(',',':')).encode()).hexdigest(),
        game_attach=False,input_authority=False)


def session_for(profile,directory):
    manager=DesktopFarmControllerManager(ROOT,runner=lambda *_:0)
    manager._snapshot=DesktopControllerSnapshot(generation=1,active=True,state=DesktopControllerState.RUNNING)
    loadout={}
    if profile is PlayStyle.MEGA_ICARUS_SPAM_SKILL:
        loadout=dict(main_pet=MainPetType.MEGA,evolution=EvolutionTarget.NONE,
                     damage_card=DamageCardMode.PET_SKILL,audition_mode=AuditionMode.NO_ACTION)
    elif profile is PlayStyle.BU_WIN:
        loadout=dict(game_mode=GameMode.COOP,evolution=EvolutionTarget.NONE,damage_card=DamageCardMode.NONE)
    elif profile is PlayStyle.DEMON_AEGIS_FARM:
        loadout=dict(evolution=EvolutionTarget.NONE,damage_card=DamageCardMode.PET_PASSIVE)
    session=RunShadowSession(DesktopConfig(play_style=profile,ai=AISettings(True),**loadout),directory=directory,
        observer=lambda status,phase:manager._observe(1,status,phase))
    return session,manager


class NativeCostLog:
    """Offline instrumentation around the *same* native write, no IO changes."""
    def __init__(self,stream):self.stream=stream;self.last_ns=0

    def write(self,raw):
        begin=time.perf_counter_ns();result=self.stream.write(raw)
        self.last_ns=time.perf_counter_ns()-begin
        return result

    def flush(self):
        begin=time.perf_counter_ns();result=self.stream.flush()
        self.last_ns=time.perf_counter_ns()-begin
        return result


class SameCallProbe:
    def __init__(self,base,observed):self.base=base;self.observed=observed;self.added_ns=0

    def write(self,raw):
        begin=time.perf_counter_ns();result=self.observed.write(raw)
        self.added_ns+=time.perf_counter_ns()-begin-self.base.last_ns
        return result

    def flush(self):
        begin=time.perf_counter_ns();result=self.observed.flush()
        self.added_ns+=time.perf_counter_ns()-begin-self.base.last_ns
        return result


def native_pair_parity(control,actual):
    count=0
    with control.open(encoding='utf-8') as a,actual.open(encoding='utf-8') as b:
        from itertools import zip_longest
        for x,y in zip_longest(a,b):
            if x is None or y is None:return False,count
            x=json.loads(x);y=json.loads(y);x.pop('timestamp',None);y.pop('timestamp',None)
            if x!=y:return False,count
            count+=1
    return True,count


def archive(path):
    with path.open('rb') as source,gzip.open(str(path)+'.gz','wb') as target:
        import shutil
        shutil.copyfileobj(source,target)
    # Exact named temporary measurement file, within the selected output only.
    path.unlink()


def benchmark(out):
    info=metadata()
    info['protocol']=dict(runs=3,measured_per_mode=10000,warmup_per_mode=1000,
        modes=['disabled','shadow','degraded','stopped'],profiles=[p.value for p in PlayStyle],
        scope='complete existing fields/JSON/native append/flush plus optional admission; unchanged solver/provider/input excluded',
        reason_for_v2='v1 mixed-profile config conflicts and digest backend cannot qualify healthy fixed-profile/native-writer integration',
        background_workload='burst admission stress, frozen profile per combat; healthy source-changing cadence separately in resources',
        binding='one native factory owner, matching immutable profile/config; Coop explicitly unsupported',
        order='mode rotation per run; profile rotation per run; pair order alternates',
        sink='accepted TextIOWrapper UTF-8 append buffering=1; actual owned separate AI disk writer/status callback',
        raw='retain every sample including stalls, every native common row losslessly gzip archived',
        limits_ms=dict(disabled=[.1,.5,1,5],shadow=[.5,1,3,10]),
        null_control='disabled paths are identical functions/handles; no selective outlier rejection, no repeat-to-pass',
        max_added_method='same-call outer wrapper minus nested identical native IO, all clock/probe overhead retained; no unmatched disk-write subtraction for max',
        tail_method='same-call causal p50/p95/p99/max AND full native Qmode-Qcontrol p50/p95/p99 gates; raw IO maxima and unmatched paired wall deltas retained descriptively',
        numeric_targets_unchanged=True,
        proof='all existing runtime sources byte-preserved; every new combat hot-path operation is inside ObservedLog.write/flush',
        cpu_environment='only measurement main thread pinned/above normal; never game or other apps',
        interpretation='per-run/family gates; failed v1 retained; no latency claim for actual game/ACK/QTE')
    dump(out/'protocol.json',info)
    results=[]
    profiles=list(PlayStyle)
    with controlled_main_thread() as environment,(out/'raw.jsonl').open('w',encoding='utf-8',buffering=1) as raw:
        info['thread_environment']=environment
        for run in range(3):
            modes=info['protocol']['modes'];modes=modes[run:]+modes[:run]
            for mode in modes:
                rows=[];groups=[]
                for slot,profile in enumerate(profiles[run:]+profiles[:run]):
                    n=1667 if slot<4 else 1666
                    warmup=167 if slot<4 else 166
                    config,state,decision,_,_=publication(profile)
                    analysis=analyze_game_state(state,policy_engine=BasicPolicyEngine(config))
                    session=manager=adapter=None
                    if mode!='disabled':
                        session,manager=session_for(profile,out/f'ai-{run}-{mode}-{profile.value}')
                        adapter=session.prepare()
                        if profile is not PlayStyle.BU_WIN and adapter is None:
                            raise RuntimeError('owned native shadow unavailable')
                        if adapter is not None and mode=='degraded':adapter.sink.buffer.disable('C3 declared sink fault')
                        if adapter is not None and mode=='stopped':adapter.stop()
                    a=out/f'control-{run}-{mode}-{profile.value}.jsonl'
                    b=out/f'mode-{run}-{mode}-{profile.value}.jsonl'
                    try:
                        with a.open('a',encoding='utf-8',buffering=1) as control,b.open('a',encoding='utf-8',buffering=1) as actual:
                            base_control,base_actual=NativeCostLog(control),NativeCostLog(actual)
                            control_probe=SameCallProbe(base_control,attach_shadow_log(base_control,None,config))
                            observed=SameCallProbe(base_actual,attach_shadow_log(base_actual,adapter,config))
                            def measure(log):
                                start=time.perf_counter_ns()
                                log.added_ns=0
                                fields=_decision_fields(state,decision,analysis)
                                _write(log,'policy_decision',**fields,trace=decision.trace)
                                return time.perf_counter_ns()-start,log.added_ns
                            for i in range(n+warmup):
                                if i%2:(c,ca),(v,va)=measure(control_probe),measure(observed)
                                else:(v,va),(c,ca)=measure(observed),measure(control_probe)
                                row=dict(run=run,mode=mode,profile=profile.value,family=decision.action.value,
                                    index=i,warmup=i<warmup,control_ns=c,mode_ns=v,delta_ns=v-c,
                                    control_added_ns=ca,mode_added_ns=va,paired_causal_ns=va-ca)
                                raw.write(json.dumps(row,separators=(',',':'))+'\n')
                                if i>=warmup:rows.append(row)
                        parity,count=native_pair_parity(a,b)
                        groups.append(dict(profile=profile.value,family=decision.action.value,N=n,parity=parity,
                            publications=count,config_id=None if session is None else session.intent.config_id,
                            adapter_counts=None if adapter is None else dict(adapter.counts),
                            Coop_supported=profile is not PlayStyle.BU_WIN))
                    finally:
                        if session:session.stop()
                        if adapter is not None and not adapter.close(2):raise RuntimeError('native child cleanup failed')
                    archive(a);archive(b)
                limits=info['protocol']['limits_ms']['disabled' if mode=='disabled' else 'shadow']
                def stats(selected):
                    q=lambda key:{k:v/1e6 for k,v in quantiles([r[key] for r in selected]).items() if k!='n'}
                    c,a,d=q('control_ns'),q('mode_ns'),q('mode_added_ns')
                    return dict(control_ms=c,mode_ms=a,paired_delta_ms=d,
                        paired_wall_delta_ms=q('delta_ns'),control_probe_added_ms=q('control_added_ns'),
                        paired_causal_difference_ms=q('paired_causal_ns'),
                        quantile_difference_ms={k:a[k]-c[k] for k in a},
                        passed=all(d[k]<=v for k,v in zip(('p50','p95','p99','max'),limits))
                            and all(a[k]-c[k]<=v for k,v in zip(('p50','p95','p99'),limits[:3])))
                for group in groups:group.update(stats([r for r in rows if r['profile']==group['profile']]))
                result=dict(run=run,mode=mode,N=len(rows),groups=groups,**stats(rows))
                result['passed']=result['passed'] and all(g['passed'] and g['parity'] for g in groups)
                results.append(result)
                print(f"native benchmark run={run} mode={mode} {result['paired_delta_ms']} PASS={result['passed']}",flush=True)
    info.update(results=results,passed=all(r['passed'] for r in results))
    dump(out/'benchmark.json',info)


def resources(out,seconds):
    """Real session/observer/worker/logger at fixed source-changing cadence."""
    info=metadata()
    info['protocol']=dict(seconds=seconds,warmup_seconds=30,cadence_seconds=2,sampling_seconds=.02,
        comparison='whole main+separate writer CPU is conservative upper bound on sink delta vs nonnegative shared sink/main CPU; identical compute kernel excluded from sink delta only',
        workload='real SIMPLE policy/dispatch/ACK publication through native common log; actual R1/native AI writer/status',
        growth_windows='first/last 300s of measurement after 30s warmup; main private bytes proxy',
        observer='bounded windows, streamed rows, only own/known helper PIDs; no game state polling',
        limits=dict(main_CPU_host_pp=5,separate_total_CPU_host_pp=1,main_private_MiB=32,
                    total_private_MiB=256,queue_MiB=8,growth_MiB=8),
        source_changed_every_job=True,healthy_log_loss=0)
    dump(out/'protocol.json',info)
    config,state,_,_,_=publication()
    from pokiguard_v2.autonomous_control import AutonomousActionIdentity
    baseline=own_process_resources(os.getpid())
    session,manager=session_for(PlayStyle.SIMPLE,out/'ai')
    adapter=session.prepare()
    if adapter is None:raise RuntimeError('native shadow unavailable')
    writer_pid=adapter.sink.pid
    from collections import deque
    first=[];last=deque(maxlen=16000)
    peak_main=baseline['private_bytes'];peak_total=baseline['private_bytes'];peak_queue=0
    cpu_handles=KnownProcessCPU();completed=0
    start=time.perf_counter()
    try:
        with (out/'common.jsonl').open('a',encoding='utf-8',buffering=1) as common,(out/'raw.jsonl').open('w',encoding='utf-8',buffering=1) as raw:
            log=attach_shadow_log(common,adapter,config)
            while time.perf_counter()-start < seconds+30:
                turn=14+completed*2
                fresh=replace(state,battle=replace(state.battle,turn_number=turn,srv_seq=turn))
                policy=BasicPolicyEngine(config);decision=policy.decide(fresh)
                analysis=analyze_game_state(fresh,policy_engine=policy)
                fields=_decision_fields(fresh,decision,analysis)
                _write(log,'policy_decision',**fields,trace=decision.trace)
                log.write(sent_row(fresh,decision,fields))
                _write(log,'action_result',result='SWAP_ACKNOWLEDGED',action={'identity':AutonomousActionIdentity.from_decision(fresh,decision)})
                next_tick=start+(completed+1)*2
                while time.perf_counter()<min(next_tick,start+seconds+30):
                    elapsed=time.perf_counter()-start
                    if adapter.sink.pid is not None:writer_pid=adapter.sink.pid
                    pids={os.getpid(),adapter.sink.pid,adapter.runner.active_pid}
                    values=[r for pid in pids if pid and (r:=own_process_resources(pid))]
                    own=next(r for r in values if r['pid']==os.getpid())
                    for r in values:
                        if r['pid']!=os.getpid():cpu_handles.observe(r['pid'])
                    total=sum(r['private_bytes'] for r in values)
                    queue=adapter.bytes+adapter.relay.bytes+adapter.sink.buffer.queued_bytes
                    peak_main=max(peak_main,own['private_bytes']);peak_total=max(peak_total,total);peak_queue=max(peak_queue,queue)
                    if 30<=elapsed<330:first.append(own['private_bytes'])
                    if elapsed>=seconds+30-300:last.append(own['private_bytes'])
                    raw.write(json.dumps(dict(elapsed_s=elapsed,resources=values,queue_bytes=queue,
                        counts=dict(adapter.counts)),separators=(',',':'))+'\n')
                    time.sleep(.02)
                completed+=1
                if completed%30==0:
                    dump(out/'progress.json',dict(elapsed_s=time.perf_counter()-start,publications=completed,counts=adapter.counts,
                                                  processes=adapter.runner.counters['processes'],reaped=adapter.runner.counters['reaped']))
                    print(f'resource stream {time.perf_counter()-start:.1f}/{seconds+30}s publications={completed}',flush=True)
            wait_for(lambda:adapter.runner.active_job is None)
            wait_for(lambda:adapter.counts['outcomes']==completed)
            if not adapter.sink.flush():raise RuntimeError('native healthy flush failed')
            info['accounting']=adapter.sink.buffer.stats()
            info['adapter_counts']=dict(adapter.counts);info['runner_counts']=dict(adapter.runner.counters)
            info['status']=manager.snapshot().ai_status.__dict__
    finally:
        session.stop();info['cleanup']=adapter.close(2)
        child_cpu=cpu_handles.finish()
    end=own_process_resources(os.getpid());wall=time.perf_counter()-start
    info.update(publications=completed,elapsed_s=wall,baseline=baseline,
        main_CPU_host_pp=(end['cpu_ns']-baseline['cpu_ns'])/1e9/wall/(os.cpu_count() or 1)*100,
        total_CPU_host_pp=(end['cpu_ns']-baseline['cpu_ns']+sum(child_cpu.values()))/1e9/wall/(os.cpu_count() or 1)*100,
        separate_sink_CPU_host_pp_upper_bound=(end['cpu_ns']-baseline['cpu_ns']+child_cpu.get(writer_pid,0))/1e9/wall/(os.cpu_count() or 1)*100,
        writer_pid=writer_pid,
        child_CPU_scope='retained query handles, final full lifetime CPU after cleanup; includes startup',
        child_CPU_ns=child_cpu,all_child_CPU_captured=len(child_cpu)==adapter.runner.counters['processes']+1,
        main_added_private_bytes=peak_main-baseline['private_bytes'],total_added_private_bytes=peak_total-baseline['private_bytes'],
        queue_peak_bytes=peak_queue,growth_bytes=None if not first or not last else statistics.median(last)-statistics.median(first),
        first_window_N=len(first),last_window_N=len(last),runner_timings=list(adapter.runner.timings))
    dump(out/'resources.json',info)


def main():
    parser=argparse.ArgumentParser();parser.add_argument('mode',choices=('benchmark','resources'))
    parser.add_argument('--out',type=Path,required=True);parser.add_argument('--seconds',type=int,default=1800)
    args=parser.parse_args()
    if args.out.exists():raise SystemExit('Use a new output directory; frozen evidence is never overwritten.')
    args.out.mkdir(parents=True)
    if args.mode=='benchmark':benchmark(args.out)
    else:resources(args.out,args.seconds)


if __name__=='__main__':main()
