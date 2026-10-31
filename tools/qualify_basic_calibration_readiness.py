"""P3 exact optional seams and timing hot-path measurements, no native IO."""
import ast, argparse, hashlib, json
from pathlib import Path
import sys,time,unittest
ROOT=Path(__file__).resolve().parents[1];sys.path[:0]=[str(ROOT),str(ROOT/'src'),str(ROOT/'tests')]
from tools.qualify_reasoning_pilot_preparation import optional_source_audits
from tools.qualify_reasoning_selection import controller_ast_audit
from tests.reasoning_controller_fixture import controller_trace,assert_c3_source_compatibility
from tests.test_reasoning_selection import original_controller
from tests.test_reasoning_pilot import MemorySink,scoped_state
from tools.evaluate_reasoning_runner import dump,quantiles
from pokiguard_v2.basic_policy import PolicyConfig
from pokiguard_v2.reasoning_swap_timing import SwapTimingCollector
from pokiguard_v2.win32_input import ClickStatus
from types import SimpleNamespace


def desktop_audit(before):
    dump_ast=lambda n:ast.dump(n,include_attributes=False)
    current=ast.parse((ROOT/'tools/desktop_ui.py').read_text(encoding='utf-8'))
    class Remove(ast.NodeTransformer):
        def visit_Assign(self,n):
            if any(isinstance(t,ast.Name) and t.id=='calibration' for t in n.targets):return None
            return self.generic_visit(n)
        def visit_If(self,n):
            if ast.unparse(n.test)=="getattr(args, 'basic_calibration_request', None) is not None":return None
            return self.generic_visit(n)
        def visit_Expr(self,n):
            if isinstance(n.value,ast.Call) and n.value.args and isinstance(n.value.args[0],ast.Constant):
                if n.value.args[0].value in ('--basic-calibration-request','--basic-calibration-sha256'):return None
            return self.generic_visit(n)
        def visit_Call(self,n):
            n.keywords=[k for k in n.keywords if not (k.arg is None and
              ast.unparse(k.value).startswith('{} if calibration is None else dict('))]
            return self.generic_visit(n)
    return dump_ast(ast.parse(before.read_text(encoding='utf-8')))==dump_ast(Remove().visit(current))


def qualify(out):
    archive=ROOT/'docs/phase5/artifacts/5d1_activation_readiness_v1'
    before=json.loads((archive/'before_source_manifest.json').read_text())['files']
    files={p.relative_to(ROOT).as_posix():hashlib.sha256(p.read_bytes()).hexdigest()
      for base in ('src','tools','tests') for p in sorted((ROOT/base).rglob('*.py'))}
    changed=sorted(p for p,v in before.items() if files.get(p)!=v);added=sorted(set(files)-set(before))
    gates={};audit=controller_ast_audit()
    gates['controller_optional_ast_exact']=audit['pass_ast'] and audit['pass_counts']
    gates.update({'optional:'+k:v for k,v in optional_source_audits().items()})
    gates['desktop_default_ast_exact']=desktop_audit(archive/'before/tools/desktop_ui.py')
    assert_c3_source_compatibility(unittest.TestCase());gates['historical_byte_binding']=True
    for case in ('normal','pending','stale','wrong_turn','stop'):
        old=controller_trace(out/f'{case}_before.jsonl',case=case,controller_module=original_controller())
        current=controller_trace(out/f'{case}_after.jsonl',case=case)
        gates['disabled_trace:'+case]=old==current
        dump(out/f'{case}_native_fake_calls.json',current[1])
    s=scoped_state();c=PolicyConfig();result=SimpleNamespace(sent_clicks=2,input_mode='two_click',status=ClickStatus.SENT)
    stats=[]
    with (out/'timing_raw.jsonl').open('w') as raw:
        for run in range(3):
            rows=[]
            for i in range(11000):
                sink=MemorySink();collector=SwapTimingCollector(sink=sink,run_id='SYNTHETIC_OFFLINE_SLO')
                start=time.perf_counter_ns()
                collector.start(state=s,config=c,input_mode='foreground',source_hash='SYNTHETIC')
                collector.preflight(remaining=12,failure=None,read_end_ns=time.perf_counter_ns())
                collector.finish(result=result)
                elapsed=(time.perf_counter_ns()-start)/1e6
                if len(sink.buffer.items)!=1 or collector.disabled:raise RuntimeError('timing event missing')
                raw.write(json.dumps(dict(run=run,index=i,warmup=i<1000,ms=elapsed))+'\n')
                if i>=1000:rows.append(elapsed)
            q=quantiles(rows);stats.append(q)
            gates['timing_critical_overhead:'+str(run)]=all(q[k]<=v for k,v in zip(('p50','p95','p99','max'),[.5,1,3,10]))
    pref=ROOT/'logs/desktop_ui/phase2e3_operator_preferences.json'
    gates['ordinary_preferences_preserved']=hashlib.sha256(pref.read_bytes()).hexdigest()==(archive/'before_preferences_sha256.txt').read_text().strip()
    gates['version_preserved']=files['src/pokiguard_v2/version.py']==before['src/pokiguard_v2/version.py']
    dump(out/'qualification.json',dict(gates=gates,changed_existing=changed,added=added,
      source_count=len(files),timing_full_start_preflight_finish_ms=stats,controller_ast=audit,
      timing_scope='3 x10000 independent raw synthetic events +1000 warmup each; fresh bounded sinks outside timed interval, full collector/encoding/enqueue inside; no disk durability claim',
      game_attach=False,input_authority=False))


def main():
    p=argparse.ArgumentParser();p.add_argument('--out',required=True,type=Path);args=p.parse_args()
    if args.out.exists():raise SystemExit('Frozen output exists')
    args.out.mkdir(parents=True);qualify(args.out)
if __name__=='__main__':main()
