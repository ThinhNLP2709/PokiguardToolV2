"""C4 file-only source/trace/host-checkpoint qualification. Never attaches game."""
from __future__ import annotations

import argparse
import ast
from collections import Counter
from dataclasses import replace
import hashlib
import json
import math
from pathlib import Path
import sys
import tempfile
import time
import unittest
from unittest.mock import patch

ROOT = Path(__file__).resolve().parents[1]
for directory in (ROOT, ROOT/'src', ROOT/'tests'):
    sys.path.insert(0, str(directory))

from pokiguard_v2.reasoning_diagnostics import DiagnosticBuffer, LogLimits
from pokiguard_v2.reasoning_selection import GuardedSelectionAdapter, select_safely, stop_safely
from tests.reasoning_controller_fixture import assert_c3_source_compatibility, controller_trace, pet_skill_fault_baseline
from tests.test_reasoning_selection import (ARTIFACTS, NOW, OFFLINE_CONTEXT, SelectionTests,
    adapter_fixture, original_controller, tactical_combat)


def quantiles(values):
    ordered=sorted(values)
    return dict(n=len(values),**{name:ordered[max(0,math.ceil(len(ordered)*q)-1)]
        for name,q in (('p50',.5),('p95',.95),('p99',.99),('max',1))})


def controller_ast_audit():
    before=ast.parse((ARTIFACTS/'before/tools/basic_auto_bot.py').read_text(encoding='utf-8'))
    try:
        fault_dir,_=pet_skill_fault_baseline(ROOT)
    except AssertionError:
        return dict(counts={},expected={'reviewed_source_binding':1},pass_counts=False,
            pass_bu_win_side_fix=False,pass_ast=False,
            binding_failure='PET_SKILL_SIDE_FIX_BINDING_FAILED')
    # Audit historical reasoning hooks against the exact pre-fault-fix body;
    # the independent manifest pins actual runtime bytes above.
    current_bytes=(fault_dir/'before/tools/basic_auto_bot.py').read_bytes()
    current=ast.parse(current_bytes.decode('utf-8'))
    # Historical reasoning acceptance still uses its original controller.
    # Account separately for the reviewed Bú win guard: pin both byte sets,
    # prove that exactly that function changed, then restore its original AST
    # before removing the optional reasoning hooks. Any future edit fails.
    side_dir=ROOT/'docs/artifacts/bu_win_no_safe_move_20261013'
    side=json.loads((side_dir/'after_runtime_manifest.json').read_text(encoding='utf-8'))
    prior_bytes=(side_dir/'before/tools/basic_auto_bot.py').read_bytes()
    side_binding=(side['schema']=='bu_win_no_safe_move_20261013.v1'
        and side['historicalPhase5AcceptanceRebound'] is False
        and side['files']=={'tools/basic_auto_bot.py':
            '1413fc2f8dfc07a1bba76acc5aaefa3b627d94c0a146447d36939e8392d2bc6a'}
        and hashlib.sha256(current_bytes).hexdigest()==side['files']['tools/basic_auto_bot.py']
        and hashlib.sha256(prior_bytes).hexdigest()==
            '5eff9ad8792769a2af382c05bd2dd737432e66fce4a79e363e9cd9b5d8bbf6d0')
    prior=ast.parse(prior_bytes.decode('utf-8'))
    reviewed=ast.parse(current_bytes.decode('utf-8'))
    guards=[i for i,n in enumerate(reviewed.body) if isinstance(n,ast.FunctionDef)
        and n.name=='_must_pause_for_no_safe_move']
    old_guards=[n for n in prior.body if isinstance(n,ast.FunctionDef)
        and n.name=='_must_pause_for_no_safe_move']
    side_scope=False
    if side_binding and len(guards)==len(old_guards)==1:
        reviewed.body[guards[0]]=old_guards[0]
        side_scope=ast.dump(reviewed,include_attributes=False)==ast.dump(prior,include_attributes=False)
        if side_scope:current=reviewed
    counts=Counter()
    optional_tests={ast.dump(ast.parse(value,mode='eval').body,include_attributes=False):name
        for value,name in (
            ('selection_adapter is not None','setup'),
            ('selection_adapter is not None and decision == basic_decision','root'),
            ('selection_receipt is not None','fresh'),
            ('failure is None and selection_receipt is not None','final'))}
    pilot_test=ast.dump(ast.parse('selection_adapter is not None and type(selection_adapter) is PilotSelectionBridge',
                                 mode='eval').body,include_attributes=False)
    p2_tests={ast.dump(ast.parse(value,mode='eval').body,include_attributes=False):kind
        for value,kind in (
            ('swap_timing_adapter is not None','timing_hook'),
            ('swap_timing_adapter is not None and board_lease_session is None','timing_start'),
            ('selection_adapter is not None and type(selection_adapter) is PilotSelectionBridge and selection_adapter.decision_budget and decision == basic_decision','budget_hook'),
            ('selection_receipt is None and selection_adapter is not None and type(selection_adapter) is PilotSelectionBridge and selection_adapter.warm_worker and decision == basic_decision','late_root'))}
    class RemoveC4(ast.NodeTransformer):
        def visit_Call(self,node):
            extra=ast.dump(ast.parse('{"reasoned": True} if selection_receipt is not None else {}',mode='eval').body,include_attributes=False)
            kept=[]
            for kw in node.keywords:
                if kw.arg is None and ast.dump(kw.value,include_attributes=False)==extra:
                    counts['reasoned_keyword']+=1
                else:kept.append(kw)
            node.keywords=kept
            return self.generic_visit(node)
        def visit_FunctionDef(self,node):
            if node.name=='run':
                pairs=list(zip(node.args.kwonlyargs,node.args.kw_defaults))
                counts['keyword']+=sum(arg.arg=='selection_adapter' for arg,_ in pairs)
                counts['timing_keyword']+=sum(arg.arg=='swap_timing_adapter' for arg,_ in pairs)
                kept=[(arg,default) for arg,default in pairs if arg.arg not in ('selection_adapter','swap_timing_adapter')]
                node.args.kwonlyargs=[arg for arg,_ in kept]
                node.args.kw_defaults=[default for _,default in kept]
            return self.generic_visit(node)
        def visit_If(self,node):
            kind=p2_tests.get(ast.dump(node.test,include_attributes=False))
            if kind:
                counts[kind]+=1
                return None
            if ast.dump(node.test,include_attributes=False)==pilot_test:
                counts['pilot_admission']+=1
                return None
            kind=optional_tests.get(ast.dump(node.test,include_attributes=False))
            if kind:
                counts[kind]+=1
                return None
            return self.generic_visit(node)
        def visit_Assign(self,node):
            if len(node.targets)==1 and isinstance(node.targets[0],ast.Name) and node.targets[0].id in (
                    'selection_receipt','selection_baseline'):
                counts['local_assignment']+=1
                return None
            return self.generic_visit(node)
    rebuilt=RemoveC4().visit(current)
    expected=dict(setup=1,root=1,fresh=1,final=1,keyword=1,local_assignment=2,pilot_admission=2,
                  timing_keyword=1,timing_hook=5,timing_start=1,late_root=1,budget_hook=1,reasoned_keyword=1)
    return dict(counts=counts,expected=expected,pass_counts=dict(counts)==expected,
        pass_bu_win_side_fix=side_binding and side_scope,
        pass_ast=side_binding and side_scope and
            ast.dump(before,include_attributes=False)==ast.dump(rebuilt,include_attributes=False))


def qualify(out):
    if (out/'qualification.json').exists():raise ValueError('retain the recorded block; use a new directory')
    out.mkdir(parents=True,exist_ok=True)
    gates={}
    audit=controller_ast_audit()
    gates['exact_controller_ast_without_optional_seams']=audit['pass_counts'] and audit['pass_ast']
    assert_c3_source_compatibility(unittest.TestCase())
    gates['historical_c3_and_side_correction_binding']=True
    before=json.loads((ARTIFACTS/'before_source_manifest.json').read_text())['files']
    current={str(p.relative_to(ROOT)).replace('\\','/'):hashlib.sha256(p.read_bytes()).hexdigest()
        for directory in ('src','tools','tests') for p in (ROOT/directory).rglob('*.py')}
    changed=sorted(name for name,sha in before.items() if current.get(name)!=sha)
    gates['only_controller_and_test_fixture_changed']=changed==['tests/reasoning_controller_fixture.py','tools/basic_auto_bot.py']
    fingerprint=hashlib.sha256(json.dumps(dict(sorted(current.items())),separators=(',',':')).encode()).hexdigest()
    (out/'source_manifest.json').write_text(json.dumps(dict(files=dict(sorted(current.items())),
        fingerprint=fingerprint,changed_parent_files=changed),indent=2)+'\n',encoding='utf-8')

    traces=[]
    with tempfile.TemporaryDirectory() as folder:
        for case in ('normal','stale','wrong_turn','pending','stop'):
            old=controller_trace(Path(folder)/(case+'_old.jsonl'),case=case,controller_module=original_controller())
            new=controller_trace(Path(folder)/(case+'_new.jsonl'),case=case)
            gates['disabled_exact_parity:'+case]=old==new
            traces.append(dict(mode='DISABLED_PAIR',case=case,old=old,current=new))
        for profile in ('simple','careful'):
            holder={}
            def factory(state,config):
                adapter,baseline,result,*_=adapter_fixture(state,config)
                holder.update(adapter=adapter,baseline=baseline,result=result,state=state,config=config)
                return adapter
            new=controller_trace(Path(folder)/(profile+'_selected.jsonl'),initial_combat=tactical_combat(),
                profile=profile,selection_factory=factory)
            old=controller_trace(Path(folder)/(profile+'_basic.jsonl'),initial_combat=tactical_combat(),
                profile=profile,controller_module=original_controller())
            sent=[row for row in new[2] if row['event']=='action_sent']
            from pokiguard_v2.board_diagnostics import jsonable
            result=holder['result']
            gates['real_R1_override_ack:'+profile]=(result.proposal is not None
                and result.proposal.move!=holder['baseline'].move and len(sent)==1
                and sent[0]['identity']['target']==jsonable((result.proposal.move.first,result.proposal.move.second))
                and new[1].count('executor.ack')==1)
            gates['same_native_call_order:'+profile]=old[1]==new[1]
            traces.append(dict(mode='SELECTED_PAIR',profile=profile,old=old,current=new,
                baseline=holder['baseline'].move.__dict__,proposal=result.proposal.to_dict(),
                settings=jsonable(holder['config']),robust_gap=result.diagnostics.plain().get('robust_gap'),
                diagnostics=dict(holder['adapter'].counts)))
        for case in ('late_fresh','reserve_fresh','stale','wrong_turn','stats_changed','final_late',
                     'reserve_final','stop_after_fresh','stop_before_input','pending'):
            def factory(state,config):
                return adapter_fixture(state,config,
                    reserve_ms=2000 if case in ('reserve_fresh','reserve_final') else 500)[0]
            trace=controller_trace(Path(folder)/(case+'_guarded.jsonl'),case=case,
                initial_combat=tactical_combat(),selection_factory=factory)
            sends=trace[1].count('FAKE_NORMAL_INPUT')
            expected=1 if case in ('late_fresh','reserve_fresh','pending') else 0
            gates['controller_safety:'+case]=sends==expected
            traces.append(dict(mode='GUARDED',case=case,trace=trace))
    (out/'controller_traces.jsonl').write_text(''.join(json.dumps(row,ensure_ascii=False)+'\n' for row in traces),encoding='utf-8')

    fixture=SelectionTests();fixture.setUp()
    offer=fixture.adapter.completed
    def ready():
        return GuardedSelectionAdapter(offer,enabled=True,diagnostics=DiagnosticBuffer(
            LogLimits(records=432,bytes=6*1024*1024)))
    timings=[]
    for block in range(3):
        for index in range(1000):
            adapter=ready()
            started=time.perf_counter_ns()
            selected=adapter.select(fixture.state,fixture.baseline,fixture.config,**fixture.kw)
            root_done=time.perf_counter_ns()
            fresh=adapter.revalidate(selected.receipt,fixture.state,fixture.baseline,fixture.config,**fixture.kw)
            fresh_done=time.perf_counter_ns()
            final=adapter.revalidate(selected.receipt,fixture.state,fixture.baseline,fixture.config,
                **fixture.kw,final=True,final_remaining_seconds=12)
            finished=time.perf_counter_ns()
            if selected.receipt is None or fresh is not None or final is not None:raise AssertionError('ready fixture rejected')
            timings.append(dict(block=block,index=index,root_ms=(root_done-started)/1e6,
                fresh_ms=(fresh_done-root_done)/1e6,final_ms=(finished-fresh_done)/1e6,
                triple_ms=(finished-started)/1e6))
    summary={key:quantiles([row[key] for row in timings]) for key in ('root_ms','fresh_ms','final_ms','triple_ms')}
    for key,limit in (('p50',1),('p95',2),('p99',5),('max',20)):
        gates['ready_triple_SLO:'+key]=summary['triple_ms'][key]<=limit
    # Keep block strata and raw tails, never silently remove an OS outlier.
    strata=[quantiles([row['triple_ms'] for row in timings if row['block']==block]) for block in range(3)]
    for block,stats in enumerate(strata):
        gates['ready_block_SLO:'+str(block)]=all(stats[k]<=v for k,v in (('p50',1),('p95',2),('p99',5),('max',20)))

    faults=[]
    for kind in ('no_completed','expired','config','source','owner','diagnostic_disabled','full','enqueue_exception','selector_exception'):
        for index in range(30):
            adapter=ready();state=fixture.state;config=fixture.config;kw=dict(fixture.kw)
            if kind=='no_completed':adapter.completed=None
            elif kind=='expired':kw['now_ns']=offer.job.deadline_ns
            elif kind=='config':config=replace(config,rage_target=0)
            elif kind=='source':state=replace(state,player=replace(state.player,mana=0))
            elif kind=='owner':kw['input_allowed']=False
            elif kind=='diagnostic_disabled':adapter.diagnostics.disable('OFFLINE_FAULT')
            elif kind=='full':adapter.diagnostics.queued_bytes=adapter.diagnostics.limits.bytes
            if kind=='enqueue_exception':context=patch.object(adapter.diagnostics,'enqueue',side_effect=OSError('OFFLINE'))
            elif kind=='selector_exception':context=patch.object(adapter,'select',side_effect=RuntimeError('OFFLINE'))
            else:
                from contextlib import nullcontext
                context=nullcontext()
            with context:
                started=time.perf_counter_ns()
                result=select_safely(adapter,state,fixture.baseline,config,**kw)
                elapsed=(time.perf_counter_ns()-started)/1e6
            faults.append(dict(kind=kind,index=index,ms=elapsed,retained=result.decision is fixture.baseline,
                receipt_absent=result.receipt is None,reason=result.reason))
    fault_summary={kind:quantiles([row['ms'] for row in faults if row['kind']==kind]) for kind in sorted({r['kind'] for r in faults})}
    gates['all_270_faults_retain_without_input']=all(row['retained'] and row['receipt_absent'] for row in faults)
    for kind,stats in fault_summary.items():
        gates['fault_SLO:'+kind]=all(stats[k]<=v for k,v in (('p50',1),('p95',5),('p99',10),('max',25)))
    stops=[]
    for index in range(100):
        adapter=ready()
        if index%2:adapter.diagnostics.disable('OFFLINE_FULL')
        started=time.perf_counter_ns();stop_safely(adapter);elapsed=(time.perf_counter_ns()-started)/1e6
        selected=adapter.select(fixture.state,fixture.baseline,fixture.config,**fixture.kw)
        stops.append(dict(index=index,ms=elapsed,stopped=adapter.stopped,receipt_absent=selected.receipt is None))
    stop_summary=quantiles([row['ms'] for row in stops])
    gates['100_Stop_no_selection']=all(row['stopped'] and row['receipt_absent'] for row in stops)
    gates['Stop_signal_SLO']=all(stop_summary[k]<=v for k,v in (('p95',5),('p99',10),('max',25)))
    (out/'checkpoint_timings.json').write_text(json.dumps(dict(ready=timings,faults=faults,stops=stops),indent=2)+'\n',encoding='utf-8')
    result=dict(scope='C4_OFFLINE_NATIVE_FAKES_ONLY',gates=gates,passed=sum(gates.values()),total=len(gates),
        controller_ast_audit=audit,source_fingerprint=fingerprint,source_count=len(current),
        changed_parent_files=changed,ready=summary,ready_blocks=strata,faults=fault_summary,stop=stop_summary,
        live_attempts=0,live_reserve='UNKNOWN_NOT_CALIBRATED',production_selection='GATED',
        full_regression='SEPARATE_REQUIRED_EVIDENCE')
    (out/'qualification.json').write_text(json.dumps(result,indent=2)+'\n',encoding='utf-8')
    print(json.dumps({k:result[k] for k in ('passed','total','source_count','ready','stop')},indent=2))
    return 0 if all(gates.values()) else 1


if __name__=='__main__':
    parser=argparse.ArgumentParser();parser.add_argument('--output-dir',type=Path,default=ARTIFACTS)
    raise SystemExit(qualify(parser.parse_args().output_dir))
