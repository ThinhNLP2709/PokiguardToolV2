"""Own Mega offline package/qualification. Drafts never Start or discover game."""
import argparse,hashlib,json,shutil,sys,time
from dataclasses import replace
from pathlib import Path

ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.reasoning_snapshot import canonical_json,digest,FrozenJSON,require,Action
from pokiguard_v2.reasoning_calibration import source_files,source_fingerprint,decode_config
from pokiguard_v2.reasoning_calibration_review import PARAMETERS
from pokiguard_v2.reasoning_mega import VERSION,PROTOCOL,profile_for
from pokiguard_v2.reasoning_mega_native import SCHEMA,verify_native,verify_boundary,check_config,run_id
from pokiguard_v2.reasoning_operational import host_fingerprint
from pokiguard_v2.reasoning_operational_launch import operational_policy_json,OperationalPilotLaunch
from pokiguard_v2.reasoning_component_guard import VERSION as GUARD

FOLDERS=['5d4_smallblue_basic3_live_20261018_041121','5d4_input_probe1_live_20261018_125726',
    '5d4_input_retry1_live_20261018_140315','5d4_input_repeat1_live_20261018_143456']


def write(path,value):
    path=Path(path);path.parent.mkdir(parents=True,exist_ok=True)
    with path.open('x',encoding='utf-8') as f:json.dump(value,f,ensure_ascii=False,indent=2);f.write('\n')


def ref(base,path):return dict(path=Path(path).relative_to(base).as_posix(),sha256=hashlib.sha256(Path(path).read_bytes()).hexdigest())


def copy_native(out):
    out=Path(out);out.mkdir(parents=True,exist_ok=True);audit=[];history=[];manifests=[];lookup={}
    def copy(path,name):
        dest=out/name;dest.parent.mkdir(parents=True,exist_ok=True);shutil.copyfile(path,dest);return ref(out,dest)
    for i,folder in enumerate(FOLDERS):
        package=ROOT/'docs/phase5/artifacts'/folder
        history.append(copy(package/'closure.json','history/'+str(i)+'_closure.json'))
        manifests.append(copy(package/'raw_manifest.json','history/'+str(i)+'_raw_manifest.json'))
        data=json.loads((package/'raw_manifest.json').read_text('utf-8'))
        for original,item in data['files'].items():
            source=ROOT/item['archive']
            require(hashlib.sha256(source.read_bytes()).hexdigest()==item['sha256'],'sealed source raw changed')
            require(hashlib.sha256((ROOT/original).read_bytes()).hexdigest()==item['sha256'],'original native raw changed')
            target=copy(source,'native/'+original);lookup[original]=target
            audit.append(dict(original=original,ref=target,sha256=item['sha256']))
    native='docs/phase5/artifacts/'+FOLDERS[-1]+'/ui_session/basic_calibration/'
    farm='logs/farm_runs/b5e66cb14607410989c8057290a63cc8/'
    records,=[n for n in lookup if n.startswith(native+'reasoning.') and n.endswith('.jsonl')]
    return dict(schema=SCHEMA,history=history,raw_manifests=manifests,raw_audit=audit,
        native_source_manifest=copy(ROOT/'docs/phase5/artifacts'/FOLDERS[-1]/'native_source_manifest.json','native_source_manifest.json'),
        request=lookup['docs/phase5/artifacts/5d4_repeat_measurement_preparation_20261018/repeat_request_cap8.json'],
        session=lookup[native+'session.json'],run=lookup[farm+'run.json'],watermarks=lookup[native+'watermarks.json'],
        records=lookup[records],combat=lookup[farm+'matches/attempt_001/combat.jsonl'],
        pet_skills=[lookup[farm+'matches/attempt_001/pet_skill_M_ffd55a9b_turn'+str(t)+'.jsonl'] for t in (13,17,25,29)])


def qualify(out):
    """Measured selector cost + actual isolated worker; all state/input fake."""
    from tests.test_reasoning_mega import completed_fixture,fixture
    from tests.test_reasoning_pilot import MemorySink
    from pokiguard_v2.reasoning_full_actions import publish_context_safely
    from pokiguard_v2.reasoning_selection import select_safely,revalidate_safely,GuardedSelectionAdapter
    from pokiguard_v2.basic_policy import _candidate_trace
    from pokiguard_v2.board_simulator import evaluate_all_moves,simulate_move
    from pokiguard_v2.reasoning_pilot import PilotSelectionBridge
    from pokiguard_v2.reasoning_diagnostics import BoundedDiagnostics,LogLimits
    from pokiguard_v2.reasoning_mega_timing import MegaClickTimingCollector
    from pokiguard_v2.reasoning_swap_timing import timing_safely,operational_preflight_failure
    from pokiguard_v2.autonomous_control import AutonomousSource
    from types import SimpleNamespace as NS
    from tools.basic_auto_bot import _must_pause_for_no_safe_move
    out=Path(out);out.mkdir(parents=True,exist_ok=False)
    data,raw,args,offer=completed_fixture();s,c,b,cap,h,a,packet,snap=data
    # Fixed valid fixture instant for selector-cost trials only. Actual wall
    # clock cost is measured below; the separate worker uses real deadlines.
    selector_now=offer.completed_ns+1
    eligible=[Action.from_dict(v['action']) for v in snap.recorded.plain()['d2_actions']['choices'] if v['eligible']]
    targets=[next(v for v in eligible if v.family==family) for family in ('swap','pet_skill','pass')]+[None]
    moves=evaluate_all_moves(s.board);safe=sum(v.sword_risk.safe for v in moves)
    native_guard=lambda d:_must_pause_for_no_safe_move(d,legal_move_count=len(moves),safe_move_count=safe,first_local_turn=s.battle.is_first_local_turn)
    costs=[];family_costs={};loss=0
    # Receipt injection below measures the existing seams only, never utility
    # correctness or live authorization. The actual worker is checked separately.
    for index in range(100):
        values=[]
        for target in targets:
            trace=None if target is None or target.family!='swap' else _candidate_trace(simulate_move(s.board,target.move),board=s.board)
            measured=replace(offer,reply=replace(offer.reply,proposal=target,
                reason='BASELINE_TOP_IN_TOTAL_ORDER' if target is None else 'D4_ROBUST_SEAL_PRESSURE_PROXY_IMPROVEMENT'),candidate_trace=trace)
            sink=MemorySink();adapter=GuardedSelectionAdapter(measured,diagnostics=sink.buffer,enabled=True,pilot_authority=a)
            adapter.native_policy_guard=native_guard;adapter.action_context=packet
            timing_sink=MemorySink();collector=MegaClickTimingCollector(sink=timing_sink,run_id='SYNTHETIC_D4_COST_NO_INPUT',
                operational_authority=a,component_monitor=True)
            family=b.action.value if target is None else target.family
            start=time.perf_counter_ns()
            publish_context_safely(adapter,s,c,b,cap,h,True)
            selected=select_safely(adapter,s,b,c,now_ns=selector_now,input_allowed=True,context=a.context)
            publish_context_safely(adapter,s,c,b,cap,h,True)
            fresh=revalidate_safely(adapter,measured,s,b,c,now_ns=selector_now,input_allowed=True,context=a.context)
            final=revalidate_safely(adapter,measured,s,b,c,now_ns=selector_now,input_allowed=True,context=a.context,
                final=True,final_remaining_seconds=13)
            collector.observe_start();collector.observe_end(state=s);collector.decision(state=s,config=c,input_parameters=PARAMETERS)
            if family=='pet_skill':
                timing_safely(collector,'skill_start',match_id=s.battle.match_id,turn=s.battle.turn_number,
                    source_hash=AutonomousSource.from_state(s).critical_state_hash,skill_card_id=22)
                timing_safely(collector,'skill_finish',result=NS(kind=NS(value='SUCCESS_NO_ACTION'),card_clicks=1,space_presses=0,
                    direction_presses=0,telemetry=NS(card_click_timestamp=time.monotonic())))
            elif family=='swap':
                collector.start(state=s,config=c,input_mode='foreground',source_hash=AutonomousSource.from_state(s).critical_state_hash)
                require(operational_preflight_failure(collector,read_end_ns=time.perf_counter_ns(),input_parameters=PARAMETERS) is None,
                    'Mega subclass lost existing operational preflight')
                collector.preflight(remaining=13,failure=None,read_end_ns=time.perf_counter_ns())
                collector.finish(result=None,status='SYNTHETIC_NO_INPUT')
            else:collector.stop()
            elapsed=(time.perf_counter_ns()-start)/1e6;values.append(elapsed)
            require(selected.receipt is measured and fresh is final is None and selected.decision.action.value==family,
                'Mega selector family/retention seam failed')
            require(not collector.disabled and collector.dropped==0,'Mega input/whole-span monitor fault')
            loss+=sink.buffer.stats()['dropped_before_enqueue']
            family_costs.setdefault('retention' if target is None else target.family,[]).append(elapsed)
        costs.append(max(values))
    write(out/'raw_costs.json',costs);write(out/'family_costs.json',family_costs)
    s,c,b,cap,h,a,packet,snap=fixture(turn=21,hp_ratio=.6,mana=300,rage=200)
    sink=BoundedDiagnostics(out/'worker_diagnostics',limits=LogLimits(records=432,bytes=6*1024*1024))
    bridge=PilotSelectionBridge(authority=a,diagnostics=sink,verified_build_sha256=a.game_build_sha256,
        enabled=True,warm_worker=True,decision_budget=True)
    cleanup=False
    try:
        observed=time.perf_counter_ns();bridge.observe(s,c,observed_ns=observed,read_end_ns=observed,context=a.context)
        publish_context_safely(bridge,s,c,b,cap,h,True)
        status=bridge.await_decision(s,b,c,context=a.context,stop_requested=lambda:False)
        require(status=='COMPLETED' and bridge.completed is not None,'own Mega worker did not complete')
        selected=select_safely(bridge,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        require(selected.receipt is bridge.completed and selected.decision.action.value=='pet_skill'
            and b.action.value=='swap','own Mega worker did not publish the validated early-skill comparison')
        elapsed=(time.perf_counter_ns()-observed)/1e6;counts=dict(bridge.bridge_counts)
        cleanup=bridge.close();require(cleanup and sink.flush(),'worker/writer cleanup failed')
        before=sink.buffer.stats();require(before['accounting_valid'] and before['written']>0
            and before['dropped_before_enqueue']==before['failed_write']==0,'qualification diagnostics lost')
        require(sink.close(),'writer close failed')
    finally:bridge.close();sink.close()
    require(max(costs)<=30 and loss==0,'Mega selector cost exceeds30ms or lost records')
    q=dict(status='PASS',source_sha256=source_fingerprint(ROOT),host_sha256=host_fingerprint(),profile_version=VERSION,
        cycles=100,raw_costs=ref(out,out/'raw_costs.json'),selector_extra_ms=max(costs),family_max_ms={k:max(v) for k,v in family_costs.items()},
        loss=loss,worker_roundtrip_pass=True,writer_cleanup_pass=cleanup,worker_roundtrip_ms=elapsed,
        worker_counts=counts,writer_before_close=before,controller_byte_exact=True,component_guard_policy=GUARD,
        scope='SYNTHETIC_CURRENT_HOST_SEAM_COST_AND_REAL_ISOLATED_WORKER_NO_GAME_OR_INPUT',
        native_override_latency='NOT_OBSERVED',sample_max_not_future_bound=True)
    write(out/'qualification.json',q);return q


def prepare(out):
    out=Path(out).resolve();require(out.is_relative_to(ROOT) and not out.exists(),'fresh V2 package required')
    out.mkdir(parents=True);cal=copy_native(out)
    write(out/'source_manifest.json',dict(fingerprint=source_fingerprint(ROOT),files=source_files(ROOT)))
    cal.update(runtime_sha256=source_fingerprint(ROOT),source_manifest=ref(out,out/'source_manifest.json'))
    native=verify_native(out,cal);boundary=verify_boundary(out,cal,source_fingerprint(ROOT))
    write(out/'calibration.json',cal);write(out/'native_review.json',native);write(out/'boundary_review.json',boundary)
    q=qualify(out/'qualification');q['raw_costs']=ref(out,out/'qualification/raw_costs.json');write(out/'selector_allowance.json',q)
    native_request=json.loads((ROOT/'docs/phase5/artifacts/5d4_repeat_measurement_preparation_20261018/repeat_request_cap8.json').read_text('utf-8'))
    config=replace(decode_config(native_request['config']),max_match_attempts=2,target_completed_matches=2);check_config(config)
    from pokiguard_v2.reasoning_root_policy import POLICY
    from pokiguard_v2.board_diagnostics import jsonable
    write(out/'contract.json',dict(scope=PROTOCOL,action_profile=profile_for(native['witness']),
        native_U_ms=None,sample_max_not_future_bound=True,server_age='UNKNOWN',
        rules=['same published board/state and existing controller incumbent; no extra game read/capture/input',
            'settings advisory; current card/source/cost/cooldown/owner validity hard; EVOLVE remains existing owner',
            'known seal30/support/replies only; no HP damage/heal/refill/win guarantee',
            'same observation-t0 budget; explicit BASIC fallback command ceiling; no second input after dispatch',
            'six attempts consumed, exactly two REASONING remain within total8; no automatic extension'],
        live_acceptance='PENDING'))
    contract=ref(out,out/'contract.json')
    write(out/'decision.json',dict(accepted=True,scope='OFFLINE_IMPLEMENTATION_AND_READINESS_ONLY',
        contract_sha256=contract['sha256'],live_activation=False))
    template=dict(schema='pokiguard.reasoning.operational_pilot.v1',origin='NATIVE_OPERATIONAL_CALIBRATED',pilot_protocol=PROTOCOL,
        full_config=jsonable(config),full_config_sha256=digest(jsonable(config)),policy_json=operational_policy_json(config),
        runtime_sha256=source_fingerprint(ROOT),host_sha256=host_fingerprint(),game_build_sha256=native_request['game_build_sha256'],
        game_executable=native_request['game_executable'],game_executable_sha256=native_request['game_executable_sha256'],
        witness=native['witness'],scope=dict(account_binding=native['witness']['account_username_sha256'],boss='2346',
            loadout='SMALLBLUE220_JAVAN_TO_MEGA_SEAL6_CLICK_ONLY'),model=dict(version='5b2.scoped_inputs.v1'),
        action_profile=profile_for(native['witness']),calibration=ref(out,out/'calibration.json'),selector_allowance=ref(out,out/'selector_allowance.json'),
        contract=contract,decision=ref(out,out/'decision.json'),contract_sha256=contract['sha256'],decision_sha256=ref(out,out/'decision.json')['sha256'],
        root_read_policy=POLICY,max_read_span_ms=100,component_monitor='POST_RETURN_COMPONENTS_V1',component_guard_policy=GUARD,
        input_parameters=PARAMETERS,host_guard_ms=250,return_margin_ms=100,budget_ms=4000,native_U_ms=None,
        transport_age_ms=None,host_unity_alignment_ms=None,total_attempt_cap=2,previous_attempts_consumed=6,total_d4_cap=8)
    write(out/'draft.json',dict(schema='pokiguard.reasoning.operational_pilot_draft.v1',accepted=False,input_authority=False,
        reasoning_enabled=False,live_request_created=False,template=template,next='USER_READY_TWO_REMAINING_REASONING_AND_MANUAL_TOOL_START'))
    return template


def activate(draft,out,authorization):
    draft=Path(draft).resolve();out=Path(out).resolve()
    require(draft.is_relative_to(ROOT) and out==draft.parent/'request.json' and not out.exists()
        and type(authorization) is str and bool(authorization.strip()),'fresh request and direct operator readiness required')
    d=json.loads(draft.read_text('utf-8'));require(d['accepted'] is False and d['input_authority'] is False,'inert draft required')
    data=d['template'];check_config(decode_config(data['full_config']))
    require(data['runtime_sha256']==source_fingerprint(ROOT) and data['host_sha256']==host_fingerprint(),'prepared source/host changed')
    now=time.time();identity=run_id()
    activation=dict(accepted=True,scope='BOUNDED_OPERATIONAL_PILOT',run_id=identity,total_attempt_cap=2,
        full_config_sha256=data['full_config_sha256'],runtime_sha256=data['runtime_sha256'],host_sha256=data['host_sha256'],
        contract_sha256=data['contract_sha256'],decision_sha256=data['decision_sha256'],pilot_protocol=PROTOCOL,
        calibration_sha256=data['calibration']['sha256'],selector_allowance_sha256=data['selector_allowance']['sha256'],
        component_guard_policy=GUARD,previous_attempts_consumed=6,total_d4_cap=8,
        operator_authorization=authorization,manual_start_only=True)
    write(out.parent/'activation_review.json',activation)
    data.update(created_at=now,expires_at=now+7200,run_id=identity,activation='EXPLICIT_BOUNDED_PILOT_REQUEST',
        activation_review=ref(out.parent,out.parent/'activation_review.json'),activation_sha256=ref(out.parent,out.parent/'activation_review.json')['sha256'])
    write(out,data)
    OperationalPilotLaunch(out,ref(out.parent,out)['sha256'],root=ROOT,directory=out.parent/'preview_only',
        game_executable=lambda:data['game_executable'])
    return data


def main():
    p=argparse.ArgumentParser(description=__doc__);sub=p.add_subparsers(dest='mode',required=True)
    a=sub.add_parser('prepare');a.add_argument('--out',type=Path,required=True)
    a=sub.add_parser('activate');a.add_argument('--draft',type=Path,required=True);a.add_argument('--out',type=Path,required=True);a.add_argument('--authorization',required=True)
    args=p.parse_args();data=prepare(args.out) if args.mode=='prepare' else activate(args.draft,args.out,args.authorization)
    print(json.dumps(dict(status='OFFLINE_READY_INERT_DRAFT' if args.mode=='prepare' else 'MANUAL_START_REQUEST_PREPARED',
        source_sha256=data['runtime_sha256'],automatic_start=False,attempt_cap=2)))


if __name__=='__main__':main()
