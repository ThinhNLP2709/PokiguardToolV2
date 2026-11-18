"""Offline-only common chooser qualification. Native surfaces are hard fakes.

Pins the v1.3.0 controller from git, compares disabled traces, checks enabled
transport order, then uses the real isolated worker and bounded disk writer.
Never attaches to a process, opens a game or creates native timing authority.
"""
from pathlib import Path
import argparse,ast,hashlib,importlib.util,json,re,subprocess,sys,time
ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.reasoning_common_problem import PROFILES
from pokiguard_v2.reasoning_calibration import source_files
from pokiguard_v2.reasoning_snapshot import digest
from pokiguard_v2.reasoning_common_selection import CommonSelectionBridge,CONTEXT
from pokiguard_v2.reasoning_common_evidence import packet
from pokiguard_v2.reasoning_full_actions import publish_context_safely
from pokiguard_v2.reasoning_diagnostics import BoundedDiagnostics,LogLimits
from pokiguard_v2.reasoning_selection import select_safely,revalidate_safely
from tests.reasoning_controller_fixture import controller_trace
from tests.test_reasoning_pilot import scoped_state,MemorySink
from tests.test_reasoning_common_selection import admission
from tests.test_reasoning_common_evidence import fixture
from tests.test_reasoning_common_models import demon_packet
from pokiguard_v2.reasoning_common_models import DEMON_TARGETS,DEMON_DECLARATION
from pokiguard_v2.pet_configuration import GameplayConfig

CHECKPOINT='e3e3dee90dd09ecd51961c06d0b390dbb04994b5'
# Reviewed read-compatibility migration only. This is not a native timing
# profile/source pin and grants no attempts or action-family authority.
LEGACY_MEGA_DEFAULT_REVIEW_SHA='de85959c3d9b7d07eab624352b5793532ba1f7c473cbddb33914023832108fd9'
LEGACY_MEGA_DEFAULT_REVIEW_VALUE='hp_below_30'


def sha(raw):return hashlib.sha256(raw).hexdigest()
def quantiles(values):
    values=sorted(values)
    return {k:values[min(len(values)-1,int((len(values)-1)*q))]
        for k,q in (('p50',.5),('p95',.95),('p99',.99),('max',1))}


def semantic_trace(result):
    code,calls,rows=result
    rows=json.loads(json.dumps(rows))
    for row in rows:
        if row.get('event')=='auto_pause' and type(row.get('artifact')) is str:
            # Only the generated clock component of the diagnostic pathname.
            row['artifact']=re.sub(r'(?<=[/\\])\d{8}_\d{6}_\d{3}_','CLOCK_',row['artifact'])
    return code,calls,rows


def calibration_projection():
    name='src/pokiguard_v2/reasoning_calibration.py'
    return calibration_ast_projection(subprocess.check_output(['git','show',CHECKPOINT+':'+name],cwd=ROOT),
        (ROOT/name).read_bytes())


def calibration_ast_projection(previous_raw,current_raw):
    """Exact historical projection plus one hash-pinned default-field migration.

    The legacy default must remain HP<30%. No function is skipped wholesale; after the
    two reviewed branches are removed the complete AST must still be equal.
    Unknown edits to the migrated file fail even if its branch looks similar.
    """
    previous=ast.parse(previous_raw)
    current=ast.parse(current_raw)
    constants=[n for n in current.body if isinstance(n,ast.Assign) and any(
        isinstance(t,ast.Name) and t.id=='COMMON_DEMON_CONTROL_PROTOCOL' for t in n.targets)]
    assert len(constants)==1
    current.body.remove(constants[0])
    function=next(n for n in current.body if isinstance(n,ast.FunctionDef) and n.name=='check_config')
    branch=function.body[0]
    assert isinstance(branch,ast.If) and ast.unparse(branch.test)=='profile_protocol == COMMON_DEMON_CONTROL_PROTOCOL'
    function.body.remove(branch)
    decoder=next(n for n in current.body if isinstance(n,ast.FunctionDef) and n.name=='decode_config')
    migration=ast.parse("if type(raw) is dict and 'mega_self_protection' not in raw:\n"
        "    raw = dict(raw, mega_self_protection=default.mega_self_protection.value)\n").body[0]
    matches=[n for n in decoder.body if ast.dump(n,include_attributes=False)==ast.dump(migration,include_attributes=False)]
    if matches:
        from pokiguard_v2.desktop_control_plane import DesktopConfig
        if (len(matches)!=1 or sha(current_raw)!=LEGACY_MEGA_DEFAULT_REVIEW_SHA
                or DesktopConfig().mega_self_protection.value!=LEGACY_MEGA_DEFAULT_REVIEW_VALUE):
            return False
        decoder.body.remove(matches[0])
    return ast.dump(previous,include_attributes=False)==ast.dump(current,include_attributes=False)


def fixture_target_projection():
    name='tests/reasoning_controller_fixture.py'
    previous=ast.parse(subprocess.check_output(['git','show',CHECKPOINT+':'+name],cwd=ROOT))
    current=ast.parse((ROOT/name).read_bytes());removed=[]
    class TargetArgument(ast.NodeTransformer):
        def visit_Assign(self,node):
            if ast.unparse(node)=='args.demon_target_gem = gameplay_config.demon_target_gem.value':
                removed.append(node);return None
            return self.generic_visit(node)
    current=TargetArgument().visit(current)
    return len(removed)==1 and ast.dump(previous,include_attributes=False)==ast.dump(current,include_attributes=False)


def qualify(output,assistant_baseline=None):
    output.mkdir(parents=True,exist_ok=False) # Preserve earlier qualification attempts.
    source_start=source_files(ROOT)
    if assistant_baseline is None:
        before=json.loads((ROOT/'docs/phase5/artifacts/common_reasoning_20261101/before_source.json').read_text('utf-8'))
        raw=subprocess.check_output(['git','show',CHECKPOINT+':tools/basic_auto_bot.py'],cwd=ROOT)
    else:
        base=Path(assistant_baseline).resolve()
        assert base.is_relative_to(ROOT)
        before=json.loads((base/'before_source.json').read_text('utf-8'))
        assert digest(before['files'])==before['fingerprint']
        raw=(base/'baseline_basic_auto_bot.py').read_bytes()
    assert sha(raw)==before['files']['tools/basic_auto_bot.py']
    saved=output/'v1_3_0_basic_auto_bot.py';saved.write_bytes(raw)
    name='tools._common_release_baseline';spec=importlib.util.spec_from_file_location(name,saved)
    module=importlib.util.module_from_spec(spec);sys.modules[name]=module;spec.loader.exec_module(module)
    parity=[]
    for profile in sorted(PROFILES):
        for case in ('normal','stale','wrong_turn','pending','stop','stop_before_input'):
            options=dict(initial_combat=scoped_state(),profile=profile,case=case)
            old=controller_trace(output/f'disabled_{profile}_{case}_before.jsonl',controller_module=module,**options)
            current=controller_trace(output/f'disabled_{profile}_{case}_current.jsonl',**options)
            parity.append(dict(profile=profile,case=case,exact_trace=current==old,
                semantic_trace=semantic_trace(current)==semantic_trace(old),
                calls_equal=current[1]==old[1],basic_inputs=current[1].count('FAKE_NORMAL_INPUT')))
    enabled=[]
    for profile in sorted(PROFILES):
        box={}
        def factory(state,config):
            b=CommonSelectionBridge(admission=admission(config),diagnostics=MemorySink(),enabled=True)
            box['bridge']=b;return b
        try:
            options=dict(initial_combat=scoped_state(),profile=profile,real_processing_clock=True)
            old=controller_trace(output/f'enabled_{profile}_before.jsonl',**options)
            current=controller_trace(output/f'enabled_{profile}_current.jsonl',selection_factory=factory,**options)
            b=box['bridge']
            enabled.append(dict(profile=profile,calls_equal=old[1]==current[1],counts=dict(b.counts),
                budget=list(b.budget_receipts),fallback=b.preparation_reason))
        finally:
            assert box['bridge'].close()
    configured_targets=[]
    for target in DEMON_TARGETS:
        state,config,*_=demon_packet(target)
        gameplay=GameplayConfig(play_style=config.play_style,main_pet=config.main_pet,
            evolution=config.evolution,damage_card=config.damage_card,
            pet_skill_fire_condition=config.pet_skill_fire_condition,pet_skill_fire_value=config.pet_skill_fire_value,
            demon_target_gem=config.demon_target_gem)
        box={}
        def factory(state,config):
            b=CommonSelectionBridge(admission=admission(config),diagnostics=MemorySink(),enabled=True)
            box['bridge']=b;return b
        try:
            options=dict(initial_combat=state,profile='demon_aegis_farm',gameplay_config=gameplay,real_processing_clock=True)
            before_target=controller_trace(output/f'target_{target}_basic.jsonl',**options)
            common_target=controller_trace(output/f'target_{target}_common.jsonl',selection_factory=factory,**options)
            b=box['bridge'];offer=b.completed
            effect=None if offer is None else offer.job.snapshot.facts.plain().get('demon_effect')
            configured_targets.append(dict(target=target,calls_equal=before_target[1]==common_target[1],
                counts=dict(b.counts),budget=list(b.budget_receipts),fallback=b.preparation_reason,
                model_completed=offer is not None,effect=effect,
                declaration_bound=effect is not None and effect['configured_target']==target
                    and effect['declaration']==DEMON_DECLARATION.plain()))
        finally:assert box['bridge'].close()
    boundary=[]
    for case,pid in (('stale',0),('pending',0),('stop_before_input',0),('stop_in_reasoning',0),('normal',123)):
        box={}
        def factory(state,config):
            b=CommonSelectionBridge(admission=admission(config),diagnostics=MemorySink(),enabled=True)
            box['bridge']=b;return b
        try:
            current=controller_trace(output/f'boundary_{case}_{pid}.jsonl',initial_combat=scoped_state(),case=case,
                target_pid=pid,selection_factory=factory,real_processing_clock=True)
            expected=1 if case in ('pending','normal') else 0
            boundary.append(dict(case=case,pid=pid,inputs=current[1].count('FAKE_NORMAL_INPUT'),
                expected_inputs=expected,pass_inputs=current[1].count('FAKE_NORMAL_INPUT')==expected,
                counts=dict(box['bridge'].counts)))
        finally:assert box['bridge'].close()

    sink=BoundedDiagnostics(output/'diagnostics',limits=LogLimits(records=432,bytes=6*1024*1024))
    value=fixture();state,config,baseline,*_=value
    bridge=CommonSelectionBridge(admission=admission(config),diagnostics=sink,enabled=True)
    measurements=[]
    try:
        now=time.perf_counter_ns();assert bridge.observe(state,config,observed_ns=now,read_end_ns=now,context=CONTEXT)
        publish_context_safely(bridge,*value)
        assert bridge.await_decision(state,baseline,config,context=CONTEXT,stop_requested=lambda:False)=='COMPLETED',bridge.preparation_reason
        for i in range(100):
            started=time.perf_counter_ns()
            selected=select_safely(bridge,state,baseline,config,now_ns=started,input_allowed=True,context=CONTEXT)
            root=time.perf_counter_ns()
            fresh=revalidate_safely(bridge,selected.receipt,state,baseline,config,now_ns=root,input_allowed=True,context=CONTEXT)
            middle=time.perf_counter_ns()
            final=revalidate_safely(bridge,selected.receipt,state,baseline,config,now_ns=middle,input_allowed=True,
                context=CONTEXT,final=True,final_remaining_seconds=14)
            ended=time.perf_counter_ns()
            assert selected.receipt is not None and fresh is None and final is None,(i,selected.reason,fresh,final)
            measurements.append(dict(root_ms=(root-started)/1e6,fresh_ms=(middle-root)/1e6,
                final_ms=(ended-middle)/1e6,triple_ms=(ended-started)/1e6))
            time.sleep(.01) # Diagnostic drain in offline harness only, outside measured checkpoints.
        summary={k:quantiles([m[k] for m in measurements]) for k in measurements[0]}
    finally:
        bridge_closed=bridge.close();flushed=sink.flush();stats=sink.buffer.stats();sink_closed=sink.close()
        (output/'writer_watermark.json').write_text(json.dumps(dict(stats=stats,counts=dict(bridge.counts),
            bridge_closed=bridge_closed,writer_closed=sink_closed,measurements=len(measurements)),indent=2),encoding='utf-8')
    durable=[json.loads(line) for path in (output/'diagnostics').glob('reasoning.*.jsonl')
        for line in path.read_text('utf-8').splitlines()]
    checkpoints=[row for row in durable if row['event_type']=='reasoning.common_selection'
        and row['correlation'].get('run_id')==bridge.run_id]
    changed={name:dict(before=expected,after=sha((ROOT/name).read_bytes())) for name,expected in before['files'].items()
        if not (ROOT/name).exists() or sha((ROOT/name).read_bytes())!=expected}
    allowed={'src/pokiguard_v2/reasoning_runner.py','src/pokiguard_v2/reasoning_full_actions.py',
        'tools/basic_auto_bot.py','tools/dinosaur_run.py','src/pokiguard_v2/reasoning_calibration.py'}
    allowed.add('tests/reasoning_controller_fixture.py')
    additions=set(source_start)-set(before['files'])
    approved_additions={
        'src/pokiguard_v2/reasoning_common_'+name+'.py' for name in ('problem','planner','evidence','selection','models')}
    approved_additions.update('tests/test_reasoning_common'+suffix+'.py'
        for suffix in ('','_evidence','_selection','_models','_control'))
    approved_additions.update(('tools/qualify_common_reasoning.py','tools/prepare_common_control.py'))
    if assistant_baseline is not None:
        allowed={
            'src/pokiguard_v2/reasoning_common_'+n+'.py' for n in ('models','evidence','planner','selection')}
        allowed.update('src/pokiguard_v2/'+n+'.py' for n in (
            'reasoning_ui_scope','reasoning_ui_profile','reasoning_ui_session','desktop_ui','desktop_farm_controller'))
        allowed.update(('tools/qualify_common_reasoning.py','tests/test_reasoning_ui_delivery.py',
            'tests/test_reasoning_settings.py','tests/test_demon_target_gem.py'))
        approved_additions={'src/pokiguard_v2/reasoning_common_native.py',
            'tools/prepare_common_runtime.py','tests/test_reasoning_common_assistant.py',
            'tests/test_reasoning_common_native.py'}
    if assistant_baseline is not None and before['fingerprint']=='513e010428216e5c448629f5f1ea95b7699e006d3651e95cd4dc77640967745d':
        allowed={
            'src/pokiguard_v2/'+n+'.py' for n in ('desktop_ui','reasoning_common_evidence',
                'reasoning_common_models','reasoning_common_planner','reasoning_common_selection','reasoning_runner')}
        allowed.update(('tools/qualify_common_reasoning.py','tests/test_reasoning_common_evidence.py',
            'tests/test_reasoning_settings.py','tests/test_reasoning_ui_delivery.py','tests/test_game_update_b14.py',
            'tests/test_reasoning_common_native.py'))
        approved_additions={'src/pokiguard_v2/reasoning_common_tactics.py','tests/test_reasoning_strategy_intent.py'}
    if assistant_baseline is not None and before['fingerprint']=='4da18e87199703c872ac777a5534e4f52037e8f8c2f75a0abddc5f572c739cb0':
        allowed={'src/pokiguard_v2/reasoning_common_native.py','tools/prepare_common_runtime.py',
            'tools/qualify_common_reasoning.py','tests/test_reasoning_common_native.py',
            'tests/test_game_update_b14.py'}
        approved_additions=set()
    if assistant_baseline is not None and before['fingerprint']=='0286e159562d1b4a54429af65762c376a1d7251fef29b6125036a30153df5199':
        allowed={'src/pokiguard_v2/farm_checkpoint.py','src/pokiguard_v2/reasoning_common_native.py',
            'tools/qualify_common_reasoning.py','tests/test_farm_checkpoint.py',
            'tests/test_farm_run_cli_d6.py','tests/test_reasoning_common_native.py','tests/test_game_update_b14.py'}
        approved_additions=set()
    if assistant_baseline is not None and before['fingerprint']=='3badf8c5710fc22740cd20dc66d0e19d5d39d6dcd4c13a39dc587fd55a102523':
        allowed={'src/pokiguard_v2/version.py','src/pokiguard_v2/reasoning_common_native.py',
            'tools/qualify_common_reasoning.py','tests/test_windows_packaging.py',
            'tests/test_desktop_ui_hardening.py','tests/test_release_130.py',
            'tests/test_game_update_b14.py','tests/test_reasoning_common_native.py'}
        approved_additions=set()
    gates=dict(disabled_semantic_parity=all(p['semantic_trace'] for p in parity),
        enabled_transport_order=all(p['calls_equal'] for p in enabled),boundary_input=all(p['pass_inputs'] for p in boundary),
        configured_demon_targets=all(p['calls_equal'] and p['model_completed'] and p['declaration_bound'] for p in configured_targets),
        protected_source=set(changed)<=allowed,worker_reaped=bridge_closed,writer_reaped=sink_closed,
        legacy_calibration_ast_unchanged=calibration_projection(),
        fixture_target_argument_only=fixture_target_projection(),
        source_additions_reviewed=additions==approved_additions,source_frozen=source_start==source_files(ROOT),
        flushed=flushed,selector_current_contract_smoke=all(summary['triple_ms'][k]<=v for k,v in (('p50',1.5),('p95',3),('p99',9),('max',30))),
        no_log_loss=(len(checkpoints)==300 and len({row['event_seq'] for row in checkpoints})==300
            and not bridge.counts['diagnostic_transfer_failed'] and not stats['failed_write'] and not stats['discarded_after_enqueue']))
    from pokiguard_v2.reasoning_operational import host_fingerprint
    result=dict(host_sha256=host_fingerprint(),scope='SYNTHETIC_ONLY_NOT_NATIVE_ACCEPTANCE',checkpoint=CHECKPOINT if assistant_baseline is None else str(Path(assistant_baseline)/'before_source.json'),baseline_controller_sha256=sha(raw),
        source_sha256=digest(source_start),source_files=source_start,added_source=sorted(additions),
        parity=parity,enabled=enabled,configured_demon_targets=configured_targets,boundaries=boundary,measurements=measurements,latency=summary,
        changed_existing_source=changed,gates=gates,writer=stats,worker=dict(bridge.runner.counters),
        diagnostic_checkpoint_records=len(checkpoints),retry_note='Sink rejected attempts may be retried off-controller; unique durable records checked separately',
        performance_scope='100 synthetic triples with real worker/writer; not the 5000-sample native admission qualification',
        performance_threshold_source='docs/phase5/prompts/5D1_P13_CALIBRATION_REVIEW_IMPLEMENTATION_OFFLINE.md',
        historical_C4_target_met=all(summary['triple_ms'][k]<=v for k,v in (('p50',1),('p95',2),('p99',5),('max',20))),
        live_attempts=0,input_authority=False)
    (output/'qualification.json').write_text(json.dumps(result,ensure_ascii=False,indent=2),encoding='utf-8')
    print(json.dumps(dict(gates=gates,latency=summary,output=str(output/'qualification.json')),ensure_ascii=False))
    return 0 if all(gates.values()) else 1


if __name__=='__main__':
    parser=argparse.ArgumentParser();parser.add_argument('--output-dir',type=Path,required=True)
    parser.add_argument('--assistant-baseline',type=Path)
    args=parser.parse_args()
    raise SystemExit(qualify(args.output_dir,args.assistant_baseline))
