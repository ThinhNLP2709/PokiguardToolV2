"""D1-P2 file-only qualification. All native/controller input surfaces are fakes."""
from __future__ import annotations

import argparse
import ast
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import sys
import time
import unittest

ROOT = Path(__file__).resolve().parents[1]
sys.path[:0] = [str(ROOT), str(ROOT/'src'), str(ROOT/'tests')]
ARCHIVE = ROOT/'docs/phase5/artifacts/5d1_timely_activation_v1'

from pokiguard_v2.reasoning_pilot import PilotSelectionBridge
from pokiguard_v2.reasoning_swap_timing import SwapTimingCollector
from pokiguard_v2.reasoning_diagnostics import BoundedDiagnostics, LogLimits
from tests.reasoning_controller_fixture import assert_c3_source_compatibility, controller_trace
from tests.test_reasoning_pilot import MemorySink, scoped_state, pilot_authority
from tests.test_reasoning_selection import original_controller
from tests.reasoning_worker_fixtures import raises, corrupt, hang
from tools.qualify_reasoning_selection import controller_ast_audit, quantiles


def write(path, value):
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(json.dumps(value, indent=2, ensure_ascii=False), encoding='utf-8')


def source_manifest():
    files = {p.relative_to(ROOT).as_posix(): hashlib.sha256(p.read_bytes()).hexdigest()
             for folder in ('src','tools','tests') for p in (ROOT/folder).rglob('*.py')}
    return dict(files=dict(sorted(files.items())), fingerprint=hashlib.sha256(
        json.dumps(files, sort_keys=True, separators=(',',':')).encode()).hexdigest())


def optional_source_audits():
    """Reconstruct exact predecessor ASTs, removing only explicit opt-in edits."""
    dump=lambda n:ast.dump(n,include_attributes=False)
    def expression(s):return dump(ast.parse(s,mode='eval').body)
    results={}
    for filename in ('src/pokiguard_v2/win32_input.py','tools/farm_run.py',
                     'src/pokiguard_v2/desktop_farm_controller.py'):
        before=ast.parse((ARCHIVE/'before'/filename).read_text(encoding='utf-8'))
        current=ast.parse((ROOT/filename).read_text(encoding='utf-8'))
        class Remove(ast.NodeTransformer):
            def visit_FunctionDef(self,node):
                pairs=list(zip(node.args.kwonlyargs,node.args.kw_defaults))
                kept=[(a,d) for a,d in pairs if a.arg not in ('reasoned','reasoning_session','reasoning_session_factory','calibration_gate')]
                node.args.kwonlyargs=[a for a,_ in kept];node.args.kw_defaults=[d for _,d in kept]
                return self.generic_visit(node)
            def visit_If(self,node):
                test=dump(node.test)
                if filename.endswith('win32_input.py') and test==expression('not reasoned'):
                    return node.body
                if test==expression('reasoning_session is not None'):
                    return self.generic_visit(node.orelse[0]) if node.orelse else None
                if test==expression('self._calibration_gate is not None'):
                    return None
                if test==expression('self._reasoning_session_factory is not None'):
                    return None
                return self.generic_visit(node)
            def visit_IfExp(self,node):
                if filename.endswith('win32_input.py') and dump(node.test)==expression('reasoned'):
                    return node.orelse
                return self.generic_visit(node)
            def visit_Assign(self,node):
                if any(isinstance(t,ast.Attribute) and t.attr in ('_reasoning_session_factory','_calibration_gate') for t in node.targets):
                    return None
                return self.generic_visit(node)
            def visit_Call(self,node):
                node.keywords=[kw for kw in node.keywords if not (kw.arg is None and
                    dump(kw.value)==expression('{} if reasoning_session is None else {"reasoning_session": reasoning_session}'))]
                return self.generic_visit(node)
        results[filename]=dump(before)==dump(Remove().visit(current))
    return results


def qualify(out):
    if (out/'qualification.json').exists():raise ValueError('use a new immutable output directory')
    out.mkdir(parents=True,exist_ok=True)
    gates={};source=source_manifest();before=json.loads((ARCHIVE/'before_source_manifest.json').read_text())['files']
    expected_existing=sorted(('src/pokiguard_v2/reasoning_pilot.py','src/pokiguard_v2/desktop_farm_controller.py',
        'src/pokiguard_v2/win32_input.py','tools/basic_auto_bot.py','tools/farm_run.py',
        'tests/reasoning_controller_fixture.py','tools/qualify_reasoning_selection.py'))
    expected_new=sorted(('src/pokiguard_v2/reasoning_warm_runner.py','src/pokiguard_v2/reasoning_pilot_activation.py',
        'src/pokiguard_v2/reasoning_swap_timing.py','tests/test_reasoning_pilot_preparation.py',
        'tools/qualify_reasoning_pilot_preparation.py'))
    changed=sorted(p for p,v in before.items() if source['files'].get(p)!=v)
    added=sorted(set(source['files'])-set(before))
    gates['exact_existing_source_scope']=changed==expected_existing
    gates['exact_new_source_scope']=added==expected_new
    assert_c3_source_compatibility(unittest.TestCase());gates['historical_evidence_byte_bound']=True
    audit=controller_ast_audit();gates['controller_exact_optional_ast']=audit['pass_counts'] and audit['pass_ast']
    audits=optional_source_audits();gates.update({'optional_ast:'+k:v for k,v in audits.items()})
    write(out/'source_manifest.json',source)
    for case in ('normal','pending','stale','wrong_turn','stop'):
        old=controller_trace(out/f'disabled_{case}_before.jsonl',case=case,controller_module=original_controller())
        new=controller_trace(out/f'disabled_{case}_after.jsonl',case=case)
        gates['disabled_exact_trace:'+case]=old==new
        write(out/f'disabled_{case}_calls.json',new[1])
    trials=[];timings=[];overrides=0
    cases=[(p,'normal',4000,None,False) for p in ('simple','careful') for _ in range(3)]
    cases += [('simple',c,4000,None,False) for c in ('pending','stale','wrong_turn','reserve_final','stop_in_reasoning')]
    cases += [('simple','normal',50,hang,False),('simple','normal',4000,raises,False),
              ('simple','normal',4000,corrupt,False),('simple','normal',4000,None,True)]
    for index,(profile,case,budget,compute,minimal) in enumerate(cases):
        box={}
        def factory(state,config):
            a=replace(pilot_authority(state,config,minimal_model=minimal),budget_ms=budget)
            b=PilotSelectionBridge(authority=a,diagnostics=MemorySink(),verified_build_sha256=a.game_build_sha256,
                enabled=True,warm_worker=True,decision_budget=True)
            if compute is not None:b.runner.compute=compute
            box['b']=b
            return b  # No pre-admission or wait before controller.run.
        label=f'{index:02}_{profile}_{case}_{budget}_{getattr(compute,"__name__","planner")}_minimal{minimal}'
        result=controller_trace(out/(label+'.jsonl'),initial_combat=scoped_state(),profile=profile,case=case,
            selection_factory=factory,real_processing_clock=True)
        b=box['b'];closed=b.close()
        sent=result[1].count('FAKE_NORMAL_INPUT');acked=result[1].count('executor.ack')
        selected=sent==1 and b.counts['VALID_COMPLETED_R1']==3
        overrides+=selected
        row=dict(label=label,case=case,profile=profile,sent=sent,acked=acked,actual_override=selected,
            selection=dict(b.counts),producer=dict(b.bridge_counts),runner=dict(b.runner.counters),
            preparation=list(b.preparation),checkpoints=list(b.checkpoints),budget=list(b.budget_receipts),
            completed=b.completed_history,worker_timing=list(b.runner.timings),cleanup=list(b.runner.cleanups),closed=closed)
        write(out/(label+'_receipts.json'),row);write(out/(label+'_calls.json'),result[1]);trials.append(row)
        gates['cleanup:'+str(index)]=closed and b.runner.counters['processes']==b.runner.counters['reaped']
        if index<6:
            gates['cold_in_controller_override_ack:'+str(index)]=selected and acked==1 and len(b.preparation)==1
            gates['early_return_before_deadline:'+str(index)]=b.budget_receipts[-1]['ended_ns']<b.budget_receipts[-1]['deadline_ns']
            old=controller_trace(out/(label+'_before.jsonl'),initial_combat=scoped_state(),profile=profile,
                controller_module=original_controller())
            gates['same_read_capture_input_ack_order:'+str(index)]=old[1]==result[1]
            timings.append((b.budget_receipts[-1]['ended_ns']-b.budget_receipts[-1]['started_ns'])/1e6)
        elif case=='pending':gates['pending_single_input_no_replacement']=sent==1 and acked==0
        elif case in ('stale','wrong_turn','reserve_final','stop_in_reasoning'):
            gates['zero_input:'+case]=sent==0
        else:gates['fallback:'+label]=sent==acked==1 and not selected
    box={}
    def timing_factory(*_):
        box['collector']=SwapTimingCollector(sink=MemorySink());return box['collector']
    trace=controller_trace(out/'timing_controller.jsonl',initial_combat=scoped_state(),
        timing_factory=timing_factory,real_processing_clock=True)
    events=[json.loads(v) for v in box['collector'].sink.buffer.items]
    write(out/'swap_timing_synthetic.json',events)
    gates['timing_upper_bound_and_ack_without_extra_io']=(len(events)==1 and
        events[0]['payload']['required_input_completed'] and trace[1].count('executor.ack')==1 and
        events[0]['payload']['native_timer_bound']=='UNBOUND')
    sink=BoundedDiagnostics(out/'diagnostics',limits=LogLimits(records=432,bytes=6*1024*1024))
    box={}
    def disk_factory(state,config):
        a=pilot_authority(state,config)
        box['b']=PilotSelectionBridge(authority=a,diagnostics=sink,verified_build_sha256=a.game_build_sha256,
            enabled=True,warm_worker=True,decision_budget=True)
        return box['b']
    controller_trace(out/'disk_controller.jsonl',initial_combat=scoped_state(),selection_factory=disk_factory,
        real_processing_clock=True)
    closed=box['b'].close();flushed=sink.flush(5);stats=sink.buffer.stats();disk_closed=sink.close()
    gates['new_producer_actual_disk_write_ack_cleanup']=(closed and flushed and disk_closed
        and stats['written']>=3 and stats['dropped_before_enqueue']==0 and stats['failed_write']==0
        and stats['discarded_after_enqueue']==0 and stats['accounting_valid'])
    summary=dict(mode='OFFLINE_NATIVE_FAKES_ONLY',milestone_result='PARTIAL',
        gates=gates,passed=sum(gates.values()),total=len(gates),offline_gates_pass=all(gates.values()),
        source_fingerprint=source['fingerprint'],source_count=len(source['files']),existing_changed=changed,new_files=added,
        controller_ast=audit,optional_ast=audits,trials=trials,actual_overrides=overrides,
        cold_decision_slice_ms=quantiles(timings),disk_stats=stats,
        efficacy='NOT_MEASURED_SYNTHETIC_EFFECTS',native_calibration='UNBOUND_NOT_ACTIVATED',
        affected_long_soak_and_paired_cpu='NOT_REQUALIFIED_NO_TRANSFER_FROM_C3',
        live_attempts=0,build_version_git_mutation=False)
    write(out/'qualification.json',summary)
    print(json.dumps({k:summary[k] for k in ('passed','total','offline_gates_pass','actual_overrides','cold_decision_slice_ms','milestone_result')}))
    return 0 if all(gates.values()) else 1


if __name__=='__main__':
    parser=argparse.ArgumentParser(description=__doc__);parser.add_argument('--out',type=Path,required=True)
    raise SystemExit(qualify(parser.parse_args().out.resolve()))
