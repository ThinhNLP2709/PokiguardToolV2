"""Prepare the remaining D2 REASONING3 offline; no game discovery or auto Start.

The package is a draft until separately activated for the user-prepared lobby.
Qualification uses explicitly synthetic state and never supplies native input.
"""
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
from pokiguard_v2.reasoning_snapshot import canonical_json,digest,FrozenJSON,require,Action
from pokiguard_v2.reasoning_calibration import source_files,source_fingerprint,decode_config
from pokiguard_v2.reasoning_calibration_review import PARAMETERS
from pokiguard_v2.reasoning_full_actions import VERSION,PROTOCOL,SOURCE_BINDING,context_packet,publish_context_safely
from pokiguard_v2.reasoning_d2_native import SCHEMA,verify_native,controller_boundary
from pokiguard_v2.reasoning_operational import host_fingerprint,command_wait_ms
from pokiguard_v2.reasoning_operational_launch import operational_policy_json
from pokiguard_v2.reasoning_component_guard import VERSION as GUARD

ART=ROOT/'docs/phase5/artifacts/5d2_skill_rush_v1'


def write(path,value):
    path.parent.mkdir(parents=True,exist_ok=True)
    with path.open('x',encoding='utf-8') as output:output.write(json.dumps(value,ensure_ascii=False,indent=2)+'\n')


def ref(base,path):
    return dict(path=path.relative_to(base).as_posix(),sha256=hashlib.sha256(path.read_bytes()).hexdigest())


def qualify(out):
    from tests.test_reasoning_full_actions import completed_fixture,full_fixture
    from tests.test_reasoning_pilot import MemorySink
    from pokiguard_v2.reasoning_selection import CompletedProposal,GuardedSelectionAdapter,select_safely,revalidate_safely
    from pokiguard_v2.reasoning_pilot import PilotSelectionBridge
    from pokiguard_v2.reasoning_diagnostics import BoundedDiagnostics,LogLimits
    from pokiguard_v2.reasoning_swap_timing import SwapTimingCollector
    from pokiguard_v2.autonomous_control import AutonomousSource
    from pokiguard_v2.board_simulator import evaluate_all_moves
    from tools.basic_auto_bot import _must_pause_for_no_safe_move
    from types import SimpleNamespace
    out.mkdir(parents=True,exist_ok=False)
    rows=[];loss=0;paths={};statuses={}
    # Synthetic prevalidated-receipt injection covers all selector branches for
    # cost only. It is not a utility/override/native input acceptance claim.
    for n in range(100):
        fixture,raw,kwargs=completed_fixture(native_source=n%2==0);s,c,b,cap,h,a,packet,snap=fixture
        offer=CompletedProposal.prepare(**kwargs)
        native_moves=evaluate_all_moves(s.board)
        native_safe_count=sum(m.sword_risk.safe for m in native_moves)
        native_guard=lambda proposed: _must_pause_for_no_safe_move(proposed,
            legal_move_count=len(native_moves),safe_move_count=native_safe_count,
            first_local_turn=s.battle.is_first_local_turn)
        choices=[Action.from_dict(x['action']) for x in snap.recorded.plain()['d2_actions']['choices'] if x['eligible']]
        targets=[next(x for x in choices if x.family==family) for family in ('swap','pet_skill','pass')]
        samples=[]
        for target in targets+[None]:
            from pokiguard_v2.basic_policy import _candidate_trace
            from pokiguard_v2.board_simulator import simulate_move
            family=b.action.value if target is None else target.family
            lane='completed_retention' if target is None else family
            trace=(_candidate_trace(simulate_move(s.board,target.move),board=s.board) if target is not None and family=='swap' else None)
            measured=replace(offer,reply=replace(offer.reply,proposal=target),candidate_trace=trace)
            sink=MemorySink();adapter=GuardedSelectionAdapter(measured,diagnostics=sink.buffer,enabled=True,pilot_authority=a)
            adapter.native_policy_guard=native_guard
            timing_sink=MemorySink()
            collector=SwapTimingCollector(sink=timing_sink,run_id='SYNTHETIC_COST_NO_INPUT',operational_authority=a,
                component_monitor=True,measure_skills=True)
            adapter.action_context=packet
            begin=time.perf_counter_ns()
            publish_context_safely(adapter,s,c,b,cap,h,True)
            selected=select_safely(adapter,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
            publish_context_safely(adapter,s,c,b,cap,h,True)
            fresh=revalidate_safely(adapter,measured,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
            final=revalidate_safely(adapter,measured,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context,
                final=True,final_remaining_seconds=14)
            collector.observe_start();collector.observe_end(state=s)
            collector.decision(state=s,config=c,input_parameters=PARAMETERS)
            source_hash=AutonomousSource.from_state(s).critical_state_hash
            if family=='pet_skill':
                collector.skill_start(match_id=s.battle.match_id,turn=s.battle.turn_number,source_hash=source_hash,skill_card_id=7)
                collector.skill_finish(result=SimpleNamespace(kind=SimpleNamespace(value='SYNTHETIC_NO_INPUT'),card_clicks=0,space_presses=0))
            elif family=='swap':
                collector.start(state=s,config=c,input_mode='foreground',source_hash=source_hash)
                collector.preflight(remaining=14,failure=None,read_end_ns=time.perf_counter_ns())
                collector.finish(result=None,status='SYNTHETIC_NO_INPUT')
            else:collector.stop()
            elapsed=(time.perf_counter_ns()-begin)/1e6;samples.append(elapsed)
            require(selected.receipt is measured and fresh is final is None,'cost branch did not validate')
            require(selected.decision.action.value==family,'wrong family recipe')
            stats=sink.buffer.stats();loss+=stats['dropped_before_enqueue']
            require(not collector.disabled and collector.dropped==0 and len(timing_sink.buffer.items)==1,
                'D2 family timing pipeline fault/loss')
            paths.setdefault(lane,[]).append(elapsed)
        rows.append(max(samples))
    write(out/'raw_costs.json',rows);write(out/'family_costs.json',paths)
    s,c,b,cap,h,a,packet,snap=full_fixture(native_source=True)
    sink=BoundedDiagnostics(out/'worker_diagnostics',limits=LogLimits(records=432,bytes=6*1024*1024))
    bridge=PilotSelectionBridge(authority=a,diagnostics=sink,verified_build_sha256=a.game_build_sha256,
        enabled=True,warm_worker=True,decision_budget=True)
    try:
        now=time.perf_counter_ns();bridge.observe(s,c,observed_ns=now,read_end_ns=now,context=a.context)
        publish_context_safely(bridge,s,c,b,cap,h,True)
        outcome=bridge.await_decision(s,b,c,context=a.context,stop_requested=lambda:False)
        require(outcome=='COMPLETED' and bridge.completed is not None,'actual worker roundtrip failed')
        selected=select_safely(bridge,s,b,c,now_ns=time.perf_counter_ns(),input_allowed=True,context=a.context)
        require(selected.receipt is bridge.completed and selected.reason=='VALID_COMPLETED_R1_RETENTION',
            'actual completed retention must carry its validated receipt')
        counts=dict(bridge.bridge_counts)
        require(bridge.close(),'worker cleanup failed')
        require(sink.flush(),'qualification diagnostics not durable')
        before=sink.buffer.stats()
        require(sink.close(),'writer cleanup failed')
        require(before['accounting_valid'] and before['written']>0 and before['dropped_before_enqueue']==0
            and before['failed_write']==0 and not before['disabled'],'qualification diagnostics lost')
    finally:
        bridge.close();sink.close()
    boundary=controller_boundary(ART/'offline_completion_v1/before/tools/basic_auto_bot.py',ROOT/'tools/basic_auto_bot.py')
    require(max(rows)<=30 and loss==0,'D2 selector cost exceeds30ms or diagnostics lost')
    q=dict(schema='5d2.selector_qualification.v1',status='PASS',source_sha256=source_fingerprint(ROOT),
        component_guard_policy=GUARD,
        host_sha256=host_fingerprint(),profile_version=VERSION,cycles=len(rows),raw_costs=ref(out,out/'raw_costs.json'),
        selector_extra_ms=max(rows),loss=loss,current_controller_boundary_pass=boundary['legacy_ast_exact'],
        worker_roundtrip_pass=True,worker_counts=counts,writer_before_close=before,
        family_max_ms={k:max(v) for k,v in paths.items()},
        native_controller_capability_shape_cycles=50,pet_bound_capability_cycles=50,
        coverage='SYNTHETIC_HOST_COST_AND_REAL_ISOLATED_WORKER_NO_NATIVE_INPUT',
        native_override_latency='NOT_OBSERVED',sample_max_not_future_guarantee=True)
    write(out/'qualification.json',q)
    return q


def prepare(out,remediation_of=None):
    out.mkdir(parents=True,exist_ok=False)
    current=source_files(ROOT);source=source_fingerprint(ROOT)
    def copy(path,name):
        dst=out/name;dst.parent.mkdir(parents=True,exist_ok=True);shutil.copyfile(path,dst)
        return ref(out,dst)
    batches=[]
    controls=ART/'basic_control/relaunch_sword7_20261016_223657'
    probe=ART/'skill_timing_probe_proposal'
    for index,(base,manifest) in enumerate(((controls,ART/'source_freeze.json'),(probe,ART/'action_source_freeze.json'))):
        cal=base/'ui_session/basic_calibration'
        session=json.loads((cal/'session.json').read_text(encoding='utf-8'))
        farm=Path(session['farm_directory']);prefix='native/'+str(index)+'/'
        timing=list(cal.glob('reasoning.*.jsonl'));require(len(timing)==1,'native rotation needs explicit merge review')
        batches.append(dict(request=copy(base/'request.json',prefix+'request.json'),
            session=copy(cal/'session.json',prefix+'session.json'),run=copy(farm/'run.json',prefix+'run.json'),
            watermarks=copy(cal/'watermarks.json',prefix+'watermarks.json'),records=copy(timing[0],prefix+'records.jsonl'),
            source_manifest=copy(manifest,prefix+'source_manifest.json'),
            pet_skills=[copy(p,prefix+'skill_'+str(i)+'.jsonl') for i,p in enumerate(sorted((farm/'matches').glob('*/pet_skill*.jsonl')))],
            combats=[copy(p,prefix+'combat_'+str(i)+'.jsonl') for i,p in enumerate(sorted((farm/'matches').glob('*/combat.jsonl')))]))
    old=json.loads((ART/'offline_completion_v1/before_source.json').read_text(encoding='utf-8'))['files']
    changed={k:v for k,v in current.items() if k in old and old[k]!=v}
    boundary=dict(changed_files=changed,before_files={k:old[k] for k in changed},
        added_files={k:v for k,v in current.items() if k not in old},historical_acceptance_rebound=False)
    # This review is also the exact successor view used by historical tests.
    (ART/'offline_completion_v1/runtime_boundary.json').write_text(json.dumps(boundary,indent=2),encoding='utf-8')
    write(out/'runtime_boundary.json',boundary)
    write(out/'source_manifest.json',dict(fingerprint=source,files=current))
    cal=dict(schema=SCHEMA,runtime_sha256=source,batches=batches,
        source_manifest=ref(out,out/'source_manifest.json'),boundary_review=ref(out,out/'runtime_boundary.json'),
        before_source=copy(ART/'offline_completion_v1/before_source.json','before_source.json'),
        control_controller=copy(ART/'pre_skill_timing/tools/basic_auto_bot.py','control_controller.py'),
        before_controller=copy(ART/'offline_completion_v1/before/tools/basic_auto_bot.py','before_controller.py'))
    native=verify_native(out,cal);write(out/'calibration.json',cal);write(out/'native_review.json',native)
    q=qualify(out/'qualification')
    # refs inside qualification are relative to the qualification directory;
    # rebase the top-level raw costs without changing its measured data.
    q['raw_costs']=ref(out,out/'qualification/raw_costs.json')
    write(out/'selector_allowance.json',q)
    request=json.loads((controls/'request.json').read_text(encoding='utf-8'))
    config=decode_config(request['config'])
    from pokiguard_v2.reasoning_root_policy import POLICY
    profile=dict(version=VERSION,account_sha256=native['witness']['account_username_sha256'],
        pet_id=2035,skill_card_id=7,condition='PERFECT_ONLY',resource_conversion=dict(mana=30,rage=20),
        source_binding=SOURCE_BINDING)
    components=dict(controller_tail_ms=native['H_ms'],final_input_ms=native['I_ms'],selector_extra_ms=q['selector_extra_ms'],
        command_wait_ms=command_wait_ms(**PARAMETERS),host_guard_ms=250)
    write(out/'contract.md.json',dict(scope='D2_CONDITIONAL_FULL_ACTION_OPERATIONAL_TIMING',
        authority='DIRECT_USER_FULL_ACTION_CLARIFICATION_AND_COMPLETE_OFFLINE_REQUEST_2026_10_16',
        rules=['t0 based budget, no new reads/captures, existing family owner/QTE/ACK unchanged',
            'observed sample maxima + selector + full BASIC wait ceiling +250ms shared host guard; margin100ms',
            'native U/server age/OS stalls UNKNOWN; no hard future guarantee',
            'failure before input retains valid BASIC; changed family/source returns to existing loop',
            'no same-source second input after dispatch; Stop signal never waits for worker cleanup'],
        action_profile=profile))
    contract=ref(out,out/'contract.md.json')
    write(out/'decision.json',dict(accepted=True,scope='OFFLINE_IMPLEMENTATION_AND_READINESS_ONLY',
        contract_sha256=contract['sha256'],user_authorization='vậy hoàn thiện đi',live_activation=False))
    template=dict(schema='pokiguard.reasoning.operational_pilot.v1',origin='NATIVE_OPERATIONAL_CALIBRATED',
        pilot_protocol=PROTOCOL,full_config=request['config'],full_config_sha256=digest(request['config']),
        policy_json=operational_policy_json(config),runtime_sha256=source,host_sha256=host_fingerprint(),
        game_build_sha256=request['game_build_sha256'],game_executable=request['game_executable'],
        game_executable_sha256=request['game_executable_sha256'],witness=native['witness'],
        scope=dict(account_binding=native['witness']['account_username_sha256'],boss='1289',loadout='HT7_2035_CARD7_NATIVE_WITNESS'),
        model=dict(version='5b2.scoped_inputs.v1'),action_profile=profile,calibration=ref(out,out/'calibration.json'),
        selector_allowance=ref(out,out/'selector_allowance.json'),contract=contract,decision=ref(out,out/'decision.json'),
        contract_sha256=contract['sha256'],decision_sha256=ref(out,out/'decision.json')['sha256'],
        root_read_policy=POLICY,max_read_span_ms=100,host_guard_ms=250,return_margin_ms=100,
        component_monitor='POST_RETURN_COMPONENTS_V1',input_parameters=PARAMETERS,budget_ms=config.ai.budget_ms,
        component_guard_policy=GUARD,
        total_attempt_cap=3,native_U_ms=None,transport_age_ms=None,host_unity_alignment_ms=None,
        activation='EXPLICIT_BOUNDED_PILOT_REQUEST')
    draft=dict(status='OFFLINE_PREPARED_NOT_ACTIVATED',accepted=False,run_id=None,created_at=None,expires_at=None,
        input_authority=False,reasoning_attempts_started=0,reasoning_reserved=3,
        original_cap=6,original_basic_used=3,separate_probe_used=1,combined_authorized_cap=7,
        reserve_components=components,reserve_ms=sum(components.values()),request_template=template,
        gate='User prepares Starburst73/HT7 lobby and requests the remaining3 live; activate then manual TOOL Start.',
        limitations=['CONDITIONAL_PERFECT_ONLY','PASS_LIVE_NOT_OBSERVED','LATER_LOCAL_AFTER_SKILL_NOT_OBSERVED',
            'NATIVE_OVERRIDE_LATENCY_NOT_OBSERVED','NO_EFFICACY_CLAIM'])
    if remediation_of is not None:
        closure=json.loads(remediation_of.read_text(encoding='utf-8'))
        require(closure['status']=='BATCH_COMPLETE_REASONING_ACCEPTANCE_FAILED'
            and closure['attempts']==closure['completed']==3 and closure['additional_live_authorized'] is False,
            'closed failed batch required; no implicit retry')
        draft.update(status='OFFLINE_PREPARED_REMEDIATION_NOT_AUTHORIZED',reasoning_reserved=0,
            original_reasoning_used=3,combined_started=7,combined_authorized_cap=7,
            proposed_additional_attempts=3,proposed_combined_cap=10,
            remediation_of=copy(remediation_of,'prior_batch_closure.json'),
            gate='Original cap7 exhausted. Direct user authorization of a NEW bounded3 batch is required; no auto activation.')
    require(source_fingerprint(ROOT)==source,'source changed during qualification')
    write(out/'draft.json',draft)
    return draft


def activate(package,authorization):
    """Call only after explicit live activation, never as part of prepare."""
    draft=json.loads((package/'draft.json').read_text(encoding='utf-8'))
    data=draft['request_template']
    require(source_fingerprint(ROOT)==data['runtime_sha256'],'source changed after offline preparation')
    require(bool(authorization.strip()),'direct operator live authorization required')
    now=time.time();data.update(run_id=uuid.uuid4().hex,created_at=now,expires_at=now+7200)
    review=dict(accepted=True,scope='BOUNDED_OPERATIONAL_PILOT',operator_authorization=authorization,
        **{k:data[k] for k in ('run_id','total_attempt_cap','full_config_sha256','runtime_sha256','host_sha256',
            'contract_sha256','decision_sha256','pilot_protocol')},
        component_guard_policy=GUARD,
        calibration_sha256=data['calibration']['sha256'],selector_allowance_sha256=data['selector_allowance']['sha256'])
    if 'remediation_of' in draft:
        review.update(remediation_of=draft['remediation_of'],prior_combined_started=7,
            additional_attempt_cap=3,combined_authorized_cap=10)
    write(package/'activation_review.json',review)
    data['activation_review']=ref(package,package/'activation_review.json')
    data['activation_sha256']=data['activation_review']['sha256']
    write(package/'request.json',data)
    sha=ref(package,package/'request.json')['sha256']
    (package/'request.sha256').write_text(sha+'\n',encoding='ascii')
    return sha


if __name__=='__main__':
    parser=argparse.ArgumentParser(description=__doc__);parser.add_argument('mode',choices=('prepare','activate'))
    parser.add_argument('--out',type=Path,required=True);parser.add_argument('--authorization')
    parser.add_argument('--remediation-of',type=Path)
    args=parser.parse_args()
    result=prepare(args.out,args.remediation_of) if args.mode=='prepare' else dict(request_sha256=activate(args.out,args.authorization or ''))
    print(json.dumps({k:v for k,v in result.items() if k!='request_template'},ensure_ascii=True))
