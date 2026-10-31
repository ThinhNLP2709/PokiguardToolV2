"""C3 paired whole-planner CPU with the C1 shared-writer emulation.

The accepted synchronous gameplay writer is used in both modes, unmodified.
An additional B4 common-writer emulation is identical in both modes. Only AI
records move between it and a separate native AI writer. This is an offline
comparison backend, never a replacement for the production common writer.
"""
from dataclasses import replace
import argparse
import json
import os
from pathlib import Path
from queue import SimpleQueue, Empty
import sys
import time

ROOT=Path(__file__).resolve().parents[1]
for directory in (ROOT,ROOT/'src'):
    if str(directory) not in sys.path:sys.path.insert(0,str(directory))

from tools.qualify_reasoning_integration import (metadata, session_for, KnownProcessCPU,
    PlayStyle, publication, BasicPolicyEngine, analyze_game_state, attach_shadow_log,
    _decision_fields, _write, sent_row, dump, wait_for, own_process_resources)
from pokiguard_v2.reasoning_diagnostics import BoundedDiagnostics, LogLimits
from pokiguard_v2.reasoning_shadow import create_shadow, SINK_BYTES
from pokiguard_v2.autonomous_control import AutonomousActionIdentity


class RouteSink:
    """One observer producer for both comparison buffers; no gameplay waits."""
    def __init__(self,common,ai):
        self.common,self.ai=common,ai
        self.buffer=ai.buffer
        self.pending=SimpleQueue()

    def enqueue(self,raw,*,critical=False):
        while True:
            try:gameplay=self.pending.get_nowait()
            except Empty:break
            if not self.common.enqueue(gameplay):raise RuntimeError('emulated common drop')
        return self.ai.enqueue(raw,critical=critical)


def qualify(out):
    report=metadata()
    report['protocol']=dict(runs=3,seconds_per_mode=30,source_cadence_s=2,
        order='shared/separate, separate/shared, shared/separate',
        comparison='whole native session/controller publications/real R1/status; C1 shared B4 writer emulation vs extra separate AI writer',
        scope='shared comparator is offline emulation; accepted synchronous common write/flush byte/order unchanged in both modes',
        cpu='main delta plus final full lifetime CPU of every known child, including startup and compute; host normalized',
        limits_cpu_delta_host_pp=1,no_concurrent_tests=True)
    dump(out/'protocol.json',report);rows=[]
    for repeat in range(3):
        for mode in (('shared','separate') if repeat%2==0 else ('separate','shared')):
            directory=out/f'{repeat}-{mode}';directory.mkdir()
            common=BoundedDiagnostics(directory/'common-emulation',stem='shared',limits=LogLimits(records=432,bytes=SINK_BYTES))
            ai=BoundedDiagnostics(directory/'ai',limits=LogLimits(records=432,bytes=SINK_BYTES)) if mode=='separate' else common
            routed=RouteSink(common,ai)
            session,manager=session_for(PlayStyle.SIMPLE,directory/'ai')
            session.factory=lambda **kw:create_shadow(diagnostics=routed,**kw)
            adapter=session.prepare()
            if adapter is None:raise RuntimeError('session not available')
            writers=[common]+([ai] if mode=='separate' else [])
            cpu=KnownProcessCPU()
            for writer in writers:cpu.observe(writer.pid)
            config,state,_,_,_=publication();before=own_process_resources(os.getpid())
            start=time.perf_counter();jobs=0
            try:
                with (directory/'gameplay.jsonl').open('a',encoding='utf-8',buffering=1) as stream:
                    log=attach_shadow_log(stream,adapter,config)
                    while time.perf_counter()-start<30:
                        fresh=replace(state,battle=replace(state.battle,turn_number=14+jobs*2,srv_seq=14+jobs*2))
                        policy=BasicPolicyEngine(config);decision=policy.decide(fresh)
                        analysis=analyze_game_state(fresh,policy_engine=policy)
                        fields=_decision_fields(fresh,decision,analysis)
                        raw=sent_row(fresh,decision,fields)
                        routed.pending.put(raw.encode())
                        _write(log,'policy_decision',**fields,trace=decision.trace)
                        log.write(raw)
                        _write(log,'action_result',result='SWAP_ACKNOWLEDGED',
                            action={'identity':AutonomousActionIdentity.from_decision(fresh,decision)})
                        jobs+=1;until=start+jobs*2
                        while time.perf_counter()<until:
                            cpu.observe(adapter.runner.active_pid)
                            for writer in writers:cpu.observe(writer.pid)  # Native writers launch lazily.
                            time.sleep(.02)
                    wait_for(lambda:adapter.runner.active_job is None)
                    wait_for(lambda:adapter.counts['outcomes']==jobs)
                    for writer in writers:
                        if not writer.flush():raise RuntimeError('writer flush failed')
                    counts=[writer.buffer.stats() for writer in writers]
                    adapter_counts=dict(adapter.counts)
                session.stop()
                if not adapter.close(2):raise RuntimeError('adapter unreaped')
                if not all([writer.close() for writer in writers]):raise RuntimeError('comparison writer unreaped')
                child_cpu=cpu.finish();after=own_process_resources(os.getpid());wall=time.perf_counter()-start
                total_cpu=after['cpu_ns']-before['cpu_ns']+sum(child_cpu.values())
                rows.append(dict(run=repeat,mode=mode,seconds=wall,jobs=jobs,
                    host_CPU_pp=total_cpu/1e9/wall/(os.cpu_count() or 1)*100,
                    main_cpu_ns=after['cpu_ns']-before['cpu_ns'],child_cpu_ns=child_cpu,
                    all_children_counted=len(child_cpu)==adapter.runner.counters['processes']+len(writers),
                    adapter_counts=adapter_counts,accounting=counts,runner_counts=adapter.runner.counters))
                dump(out/'progress.json',rows)
                print(f"paired CPU run={repeat} mode={mode} host={rows[-1]['host_CPU_pp']:.5f}pp",flush=True)
            finally:
                session.stop();adapter.close(2)
                for writer in writers:writer.close()
    deltas=[next(r['host_CPU_pp'] for r in rows if r['run']==i and r['mode']=='separate')-
        next(r['host_CPU_pp'] for r in rows if r['run']==i and r['mode']=='shared') for i in range(3)]
    report.update(rows=rows,separate_minus_shared_CPU_host_pp=deltas)
    dump(out/'result.json',report)


def main():
    parser=argparse.ArgumentParser();parser.add_argument('--out',type=Path,required=True);args=parser.parse_args()
    if args.out.exists():raise SystemExit('Frozen output exists')
    args.out.mkdir(parents=True);qualify(args.out)


if __name__=='__main__':main()
