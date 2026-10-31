"""D3 minimum offline package; separate explicit activation, never game IO/Start."""
import argparse
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import shutil
import sys
import time
import uuid

ROOT=Path(__file__).resolve().parents[1]
sys.path[:0]=[str(ROOT),str(ROOT/'src')]
from pokiguard_v2.reasoning_calibration import source_files,source_fingerprint,decode_config
from pokiguard_v2.reasoning_calibration_review import PARAMETERS
from pokiguard_v2.reasoning_demon import MODEL,VERSION,PROTOCOL
from pokiguard_v2.reasoning_demon_native import (SCHEMA,verify_native,verify_boundary,check_config,
    MULTIPLIER20_PROTOCOL,PREVIOUS9_LEDGER_SHA)
from pokiguard_v2.reasoning_operational import host_fingerprint,command_wait_ms
from pokiguard_v2.reasoning_operational_launch import operational_policy_json,OperationalPilotLaunch
from pokiguard_v2.reasoning_snapshot import canonical_json,digest,require

CONTROL=ROOT/'docs/phase5/artifacts/5d3_lieyun_basic3_live_20261018_021056'
BEFORE=ROOT/'docs/phase5/artifacts/5d3_demon_reasoning_20261018/before_source.json'


def write(path,value):
    path.parent.mkdir(parents=True,exist_ok=True)
    with path.open('x',encoding='utf-8') as stream:stream.write(json.dumps(value,ensure_ascii=False,indent=2)+'\n')


def ref(base,path):
    return dict(path=path.relative_to(base).as_posix(),sha256=hashlib.sha256(path.read_bytes()).hexdigest())


def copy_native(out):
    cal=CONTROL/'ui_session/basic_calibration'
    session=json.loads((cal/'session.json').read_text('utf-8'))
    farm=Path(session['farm_directory'])
    def cp(path,name):
        dst=out/'native'/name;dst.parent.mkdir(parents=True,exist_ok=True);shutil.copyfile(path,dst)
        return ref(out,dst)
    timing=list(cal.glob('reasoning.*.jsonl'));require(len(timing)==1,'review timing rotation explicitly')
    return dict(schema=SCHEMA,request=cp(CONTROL/'request.json','request.json'),
        session=cp(cal/'session.json','session.json'),run=cp(farm/'run.json','run.json'),
        watermarks=cp(cal/'watermarks.json','watermarks.json'),records=cp(timing[0],'records.jsonl'),
        native_source=cp(BEFORE,'native_source.json'),
        combats=[cp(p,f'combat_{i}.jsonl') for i,p in enumerate(sorted(farm.glob('matches/*/combat.jsonl')))])


def qualify(out, *, controller_manifest=None):
    from tests.test_reasoning_demon import completed_fixture,fixture
    from tests.test_reasoning_pilot import MemorySink
    from pokiguard_v2.reasoning_selection import GuardedSelectionAdapter,select_safely,revalidate_safely
    from pokiguard_v2.reasoning_pilot import PilotSelectionBridge
    from pokiguard_v2.reasoning_diagnostics import BoundedDiagnostics,LogLimits
    from pokiguard_v2.board_simulator import evaluate_all_moves
    from tools.basic_auto_bot import _must_pause_for_no_safe_move
    out.mkdir(parents=True,exist_ok=False)
    samples=[];paths={};loss=0
    for n in range(100):
        s,c,b,a,snap,raw,kwargs,offer=completed_fixture(9 if n%2==0 else 15,baseline=True if n%2==0 else None)
        values=evaluate_all_moves(s.board);safe=sum(v.sword_risk.safe for v in values)
        for lane in ('completed','missing','expired','stop','sink_failure','guard_veto'):
            sink=MemorySink()
            adapter=GuardedSelectionAdapter(None if lane=='missing' else offer,diagnostics=sink.buffer,
                enabled=True,pilot_authority=a)
            adapter.native_policy_guard=lambda proposed: _must_pause_for_no_safe_move(proposed,
                legal_move_count=len(values),safe_move_count=safe,first_local_turn=s.battle.is_first_local_turn)
            if lane=='guard_veto':adapter.native_policy_guard=lambda proposed:True
            if lane=='stop':adapter.stop()
            if lane=='sink_failure':sink.buffer.disable('SYNTHETIC')
            now=offer.job.deadline_ns if lane=='expired' else time.perf_counter_ns()
            begin=time.perf_counter_ns()
            selected=select_safely(adapter,s,b,c,now_ns=now,input_allowed=True,context=a.context)
            if lane=='completed':
                require(selected.receipt is offer,'D3 completed branch not exercised')
                for final in (False,True):
                    require(revalidate_safely(adapter,offer,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,
                        context=a.context,final=final,final_remaining_seconds=13) is None,'D3 checkpoint rejected')
            elif not (lane=='guard_veto' and offer.reply.proposal is None):
                require(selected.decision is b and selected.receipt is None,'D3 fallback changed BASIC')
            elapsed=(time.perf_counter_ns()-begin)/1e6
            paths.setdefault(lane,[]).append(elapsed)
            if lane!='sink_failure':loss+=sink.buffer.stats()['dropped_before_enqueue']
        samples.append(max(v[-1] for v in paths.values()))
    write(out/'raw_costs.json',samples);write(out/'path_costs.json',paths)
    s,c,b,a,snap=fixture(9,baseline=True)
    sink=BoundedDiagnostics(out/'worker_diagnostics',limits=LogLimits(records=432,bytes=6*1024*1024))
    bridge=PilotSelectionBridge(authority=a,diagnostics=sink,verified_build_sha256=a.game_build_sha256,
        enabled=True,warm_worker=True,decision_budget=True)
    try:
        now=time.perf_counter_ns();bridge.observe(s,c,observed_ns=now,read_end_ns=now,context=a.context)
        require(bridge.await_decision(s,b,c,context=a.context,stop_requested=lambda:False)=='COMPLETED'
            and bridge.completed is not None and bridge.completed.reply.proposal is not None,'D3 isolated worker failed')
        selected=select_safely(bridge,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        require(selected.receipt is bridge.completed,'D3 real worker receipt not selected')
        counts=dict(bridge.bridge_counts)
        require(bridge.close() and sink.flush(),'D3 worker/writer cleanup failed')
        stats=sink.buffer.stats()
        require(sink.close() and stats['accounting_valid'] and stats['written']>0
            and stats['dropped_before_enqueue']==stats['failed_write']==0,'D3 diagnostics not durable')
    finally:bridge.close();sink.close()
    old=json.loads((BEFORE if controller_manifest is None else controller_manifest).read_text('utf-8'))['files']
    controller=hashlib.sha256((ROOT/'tools/basic_auto_bot.py').read_bytes()).hexdigest()==old['tools/basic_auto_bot.py']
    require(controller and max(samples)<=30 and loss==0,'D3 cost/flow qualification failed')
    q=dict(status='PASS',profile_version=VERSION,source_sha256=source_fingerprint(ROOT),host_sha256=host_fingerprint(),
        cycles=100,raw_costs=ref(out,out/'raw_costs.json'),selector_extra_ms=max(samples),loss=loss,
        controller_byte_exact=controller,worker_roundtrip_pass=True,worker_counts=counts,writer_before_close=stats,
        path_max_ms={k:max(v) for k,v in paths.items()},
        origin='SYNTHETIC_GAME_STATE_REAL_LOCAL_WORKER_NO_NATIVE_INPUT',sample_max_not_future_bound=True)
    write(out/'qualification.json',q)
    return q


def prepare(out, *, multiplier20_authorization=None):
    out=Path(out).resolve();require(out.is_relative_to(ROOT),'V2 output required')
    extended = multiplier20_authorization is not None
    if extended:
        require(type(multiplier20_authorization) is str and bool(multiplier20_authorization.strip()),
            'direct user twenty-match request required')
    cap = 20 if extended else 3
    protocol = MULTIPLIER20_PROTOCOL if extended else PROTOCOL
    out.mkdir(parents=True,exist_ok=False)
    cal=copy_native(out)
    write(out/'source_manifest.json',dict(fingerprint=source_fingerprint(ROOT),files=source_files(ROOT)))
    cal['source_manifest']=ref(out,out/'source_manifest.json')
    native=verify_native(out,cal);boundary=verify_boundary(out,cal,source_fingerprint(ROOT))
    write(out/'calibration.json',cal);write(out/'native_review.json',native);write(out/'runtime_boundary.json',boundary)
    q=qualify(out/'qualification');q['raw_costs']=ref(out,out/'qualification/raw_costs.json')
    write(out/'selector_allowance.json',q)
    original=json.loads((CONTROL/'request.json').read_text('utf-8'));config=decode_config(original['config']);check_config(config)
    if extended:
        config=replace(config,target_completed_matches=20,max_match_attempts=20)
        check_config(config,protocol=protocol)
    from pokiguard_v2.board_diagnostics import jsonable
    full_config=jsonable(config)
    from pokiguard_v2.reasoning_root_policy import POLICY
    from pokiguard_v2.reasoning_component_guard import VERSION as GUARD
    profile=dict(MODEL,account_sha256=native['witness']['account_username_sha256'],player_stats=native['player_stats'])
    write(out/'contract.json',dict(scope='D3_OPERATOR_CALIBRATED_MINIMUM',profile=profile,
        native_U_ms=None,server_age='UNKNOWN',sample_max_not_future_bound=True,
        rules=['existing observation t0 deadline and existing SWAP preflight/executor/ACK only',
            'two direct scoped user certificates; physical/effective separate; no damage formula',
            'unknown protection/passive residual/refill keep full normalized intervals; no future setup credit',
            'fallback before dispatch only; no BASIC replay after input; no added readers/screenshots',
            ('Prior9 sealed; separate user-requested maximum20 REASONING attempts including abort/failed entry; no automatic extension'
                if extended else '3 BASIC consumed plus at most3 separate REASONING attempts; no automatic extension')],
        minimum_acceptance='LIVE_PENDING',setup_bait_joint_order='UNSUPPORTED_BY_MINIMUM_SCOPE'))
    contract=ref(out,out/'contract.json')
    write(out/'decision.json',dict(accepted=True,scope='OFFLINE_IMPLEMENTATION_AND_READINESS_ONLY',
        contract_sha256=contract['sha256'],basis='DIRECT_USER_D3_MINIMUM_CRITERIA_2026_10_18',live_activation=False))
    template=dict(schema='pokiguard.reasoning.operational_pilot.v1',origin='NATIVE_OPERATIONAL_CALIBRATED',
        pilot_protocol=protocol,full_config=full_config,full_config_sha256=digest(full_config),
        policy_json=operational_policy_json(config),runtime_sha256=source_fingerprint(ROOT),host_sha256=host_fingerprint(),
        game_build_sha256=original['game_build_sha256'],game_executable=original['game_executable'],
        game_executable_sha256=original['game_executable_sha256'],witness=native['witness'],
        scope=dict(account_binding=native['witness']['account_username_sha256'],boss='1436',
            loadout='DEMON_NORMAL_NONE_PASSIVE_OPERATOR_LIEYUN77'),model=dict(version='5b2.scoped_inputs.v1'),
        demon_profile=profile,calibration=ref(out,out/'calibration.json'),selector_allowance=ref(out,out/'selector_allowance.json'),
        contract=contract,decision=ref(out,out/'decision.json'),contract_sha256=contract['sha256'],
        decision_sha256=ref(out,out/'decision.json')['sha256'],root_read_policy=POLICY,max_read_span_ms=100,
        component_monitor='POST_RETURN_COMPONENTS_V1',component_guard_policy=GUARD,input_parameters=PARAMETERS,
        host_guard_ms=250,return_margin_ms=100,budget_ms=4000,native_U_ms=None,transport_age_ms=None,
        host_unity_alignment_ms=None,total_attempt_cap=cap,total_d3_cap=29 if extended else 6,basic_consumed=3,
        basic_control_run=original['run_id'],reasoning_consumed=0)
    if extended:
        previous=ROOT/'docs/phase5/artifacts/5d3_multiplier_targeted_live_20261018_031504/cumulative_ledger.json'
        require(hashlib.sha256(previous.read_bytes()).hexdigest()==PREVIOUS9_LEDGER_SHA,
            'previous nine-match evidence changed')
        copied=out/'previous9/cumulative_ledger.json';copied.parent.mkdir();shutil.copyfile(previous,copied)
        write(out/'batch_extension.json',dict(schema='5d3.multiplier20.extension.v1',accepted=True,
            scope='USER_REQUESTED_D3_MULTIPLIER20',operator_authorization=multiplier20_authorization,
            previous_cumulative=ref(out,copied),previous_attempts_consumed=9,attempt_cap=20,
            maximum_cumulative_attempts=29,failed_entry_abort_included=True,no_automatic_extension=True,
            source_sha256=template['runtime_sha256']))
        template['batch_extension']=ref(out,out/'batch_extension.json')
    write(out/'draft.json',dict(schema='pokiguard.reasoning.operational_pilot_draft.v1',accepted=False,
        input_authority=False,reasoning_enabled=False,live_request_created=False,template=template,
        next='SEPARATE_USER_READY_REASONING20_ACTIVATION_AND_MANUAL_START' if extended else
            'SEPARATE_USER_READY_REASONING3_ACTIVATION_AND_MANUAL_START'))
    return template


def activate(draft,out,authorization):
    draft=Path(draft).resolve();out=Path(out).resolve()
    require(draft.is_relative_to(ROOT) and out==draft.parent/'request.json' and not out.exists()
        and bool(authorization.strip()),'fresh D3 request and direct bounded user readiness required')
    d=json.loads(draft.read_text('utf-8'));require(d['accepted'] is False and d['input_authority'] is False,'draft required')
    data=d['template'];require(data['runtime_sha256']==source_fingerprint(ROOT) and data['host_sha256']==host_fingerprint(),
        'source/host changed since preparation')
    extended=data['pilot_protocol']==MULTIPLIER20_PROTOCOL
    cap=20 if extended else 3
    check_config(decode_config(data['full_config']),protocol=data['pilot_protocol'])
    require(data['total_attempt_cap']==cap,'D3 activation cap changed')
    now=time.time();run=uuid.uuid4().hex
    activation=dict(accepted=True,scope='BOUNDED_OPERATIONAL_PILOT',run_id=run,total_attempt_cap=cap,
        full_config_sha256=data['full_config_sha256'],runtime_sha256=data['runtime_sha256'],host_sha256=data['host_sha256'],
        contract_sha256=data['contract_sha256'],decision_sha256=data['decision_sha256'],pilot_protocol=data['pilot_protocol'],
        calibration_sha256=data['calibration']['sha256'],selector_allowance_sha256=data['selector_allowance']['sha256'],
        component_guard_policy=data['component_guard_policy'],operator_authorization=authorization,
        manual_start_only=True,basic_attempts_consumed=3,reasoning_attempt_cap=cap,total_d3_cap=29 if extended else 6)
    if extended:
        activation.update(batch_extension_sha256=data['batch_extension']['sha256'],previous_attempts_consumed=9)
    write(out.parent/'activation_review.json',activation)
    data.update(created_at=now,expires_at=now+7200,run_id=run,activation='EXPLICIT_BOUNDED_PILOT_REQUEST',
        activation_review=ref(out.parent,out.parent/'activation_review.json'),
        activation_sha256=ref(out.parent,out.parent/'activation_review.json')['sha256'])
    write(out,data)
    OperationalPilotLaunch(out,ref(out.parent,out)['sha256'],root=ROOT,directory=out.parent/'preview_only',
        game_executable=lambda:data['game_executable'])
    return data


def main():
    p=argparse.ArgumentParser(description=__doc__);sub=p.add_subparsers(dest='mode',required=True)
    a=sub.add_parser('prepare');a.add_argument('--out',type=Path,required=True)
    a.add_argument('--multiplier20-authorization',help='direct user request for the separate maximum20 multiplier batch')
    a=sub.add_parser('activate');a.add_argument('--draft',type=Path,required=True);a.add_argument('--out',type=Path,required=True)
    a.add_argument('--authorization',required=True)
    a=p.parse_args()
    value=prepare(a.out,multiplier20_authorization=a.multiplier20_authorization) if a.mode=='prepare' else activate(a.draft,a.out,a.authorization)
    print(json.dumps(dict(status='OFFLINE_DRAFT_READY' if a.mode=='prepare' else 'REQUEST_VALIDATED',
        source_sha256=value['runtime_sha256'],automatic_start=False,claim_created=False,attempt_cap=value['total_attempt_cap'])))


if __name__=='__main__':main()
