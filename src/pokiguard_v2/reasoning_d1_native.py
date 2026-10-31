"""Current-source D1 native calibration. No old source timing rebinding.

File-only setup; activation, ownership, input and ACK stay with existing owners.
"""
import json
from pathlib import Path
import time

from .reasoning_snapshot import FrozenJSON, canonical_json, digest, require, strict_json_loads
from .reasoning_calibration_review import document, read_ref, PARAMETERS
from .reasoning_root_policy import POLICY, validate_policy, validate_costs as root_costs
from .reasoning_config_projection import VERSION

SCHEMA='pokiguard.reasoning.current_native_d1.v1'
PROTOCOL='D1_SIMPLE_CAREFUL_CURRENT_NATIVE_V1'
SOURCE_POLICY='UNCACHED_AUTONOMOUS_SOURCE_V1'


def check_config(config):
    from .reasoning_calibration import check_config as basic_config
    basic_config(config,3)
    require(config.target_completed_matches==3, 'D1 cohort requires3total/3target attempts')


def validate_costs(directory,q):
    require(q.get('source_projection_policy')==SOURCE_POLICY
            and q.get('config_projection_policy')==VERSION and q.get('profile') in ('simple','careful'),
            'current D1 collector costs required')
    rows=[strict_json_loads(s) for s in read_ref(directory,dict(path='pipeline_raw.jsonl',
        sha256=q['raw_sha256']['pipeline_raw.jsonl'])).decode().splitlines()]
    require(len(rows)==6000 and all(r.get('source_projection_policy')==SOURCE_POLICY for r in rows),
            'actual source projection pipeline required')
    if q.get('component_guard_policy') is not None:
        from .reasoning_component_guard import VERSION as GUARD_VERSION
        require(q['component_guard_policy']==GUARD_VERSION
                and all(r.get('component_guard_policy')==GUARD_VERSION for r in rows),
                'actual shared guard collector pipeline required')
    return root_costs(directory,q)


def verify_native(directory,cal,request,*,policy_json,witness):
    """Full current raw lineage, explicit exclusions, complete all-attempt costs."""
    from .reasoning_calibration import source_files, source_fingerprint
    from .reasoning_operational import host_fingerprint
    root=Path(__file__).resolve().parents[2]
    require(source_fingerprint(root)==request.runtime_sha256,'current source differs from request')
    native_sha=request.runtime_sha256;native_files=source_files(root);compatibility=None
    if cal.get('native_boundary_review') is not None:
        from .reasoning_native_boundary_review import verified_origin
        compatibility=verified_origin(directory,cal['native_boundary_review'],current_sha256=request.runtime_sha256)
        native_sha=compatibility['source_sha256'];native_files=compatibility['files']
    require(cal['schema']==SCHEMA and cal['mode']=='BASIC_CALIBRATION_ONLY'
            and cal['origin']=='NATIVE_OBSERVATION' and cal['runtime_sha256']==native_sha
            and cal['host_sha256']==request.host_sha256==host_fingerprint()
            and cal['game_build_sha256']==request.verified_build_sha256
            and cal['policy_json']==policy_json and cal['witness']==witness,
            'fresh exact current-source native cohort required')
    require(type(witness) is dict and any(c[2]=='ATTACK' for c in witness.get('loadout',{}).get('cards',[])),
            'current equipped Attack witness required')
    manifest=document(directory,cal['source_manifest'])
    require(manifest['files']==native_files and digest(manifest['files'])==native_sha,
            'complete current native source manifest required')
    from .reasoning_calibration import decode_config
    from .reasoning_operational_launch import operational_policy_json
    native_request=document(directory,cal['native_request']);session=document(directory,cal['native_session'])
    native_config=decode_config(native_request['config']);check_config(native_config)
    require(native_request['schema']=='pokiguard.basic_calibration_request.v1'
            and native_request['reasoning_enabled'] is False
            and native_request['source_sha256']==native_sha
            and native_request['host_sha256']==request.host_sha256
            and native_request['game_build_sha256']==request.verified_build_sha256
            and native_request['total_attempt_cap']==session['total_attempt_cap']==3
            and native_request['run_id']==session['run_id']
            and type(native_request['run_id']) is str and len(native_request['run_id'])==32
            and all(c in '0123456789abcdef' for c in native_request['run_id'])
            and session['config_json']==canonical_json(native_request['config'])
            and operational_policy_json(native_config)==policy_json,
            'native request/session/config binding required')
    run=document(directory,cal['farm_run'])['snapshot']
    ledger=document(directory,cal['attempt_ledger']);farm=document(directory,cal['farm_export'])
    require(cal['total_attempt_cap']==3 and type(ledger) is list and 1<=len(ledger)<=3
            and [a['index'] for a in ledger]==list(range(len(ledger)))
            and all(a['status'] in ('COMPLETED','ABORTED','INVALID','FAILED') for a in ledger),
            'all attempts including failures required')
    require(farm['schema']=='pokiguard.basic_calibration_export.v1' and farm['finalized'] is True
            and set(farm['errors'])<= {'MISSING_OR_MIXED_RUNTIME_WITNESS'}
            and farm['source_sha256']==native_sha
            and farm['game_build_sha256']==request.verified_build_sha256
            and farm['host_sha256']==request.host_sha256 and farm['total_attempt_cap']==3
            and farm['all_attempt_count']==len(ledger)==len(farm['all_attempts'])
            and [a['attempt_index'] for a in farm['all_attempts']]==list(range(1,len(ledger)+1)),
            'native finalized all-attempt export required')
    require(run['farm_run_id']==session['farm_run_id']
            and run['limits']['max_match_attempts']==3 and run['match_attempts']==len(ledger)
            and run['attempts']==farm['all_attempts'], 'native FarmRun/session/all-attempt binding required')
    water=document(directory,cal['watermarks']);stats=water['before_close']
    require(water['run_id']==native_request['run_id']
            and water['flushed'] is True and water['closed'] is True and water['collector_dropped']==0
            and water['collector_disabled'] is False and stats['accounting_valid'] is True
            and stats['eligible']==stats['written'] and all(stats[k]==0 for k in
            ('dropped_before_enqueue','failed_write','discarded_after_enqueue','queued','in_writer')),
            'durable complete calibration required')
    records=[strict_json_loads(s) for s in read_ref(directory,cal['records']).decode().splitlines()]
    require(1<=len(records)<=1024 and water['sequence']==len(records), 'complete native timing sequence required')
    require(1<=len(cal['combat_records'])<=3, 'complete bounded combat refs required')
    combats=[strict_json_loads(s) for ref in cal['combat_records'] for s in read_ref(directory,ref).decode().splitlines()]
    sent=[r for r in combats if r.get('event')=='action_sent' and r.get('action')=='SWAP']
    sources=set();covered=set();intervals=[];excluded=[]
    for index,event in enumerate(records):
        require(event['event_seq']==index+1 and event['correlation']['run_id']==native_request['run_id']
                and event['correlation']['mode']=='BASIC_CALIBRATION_ONLY'
                and event['event_type'] in ('reasoning.swap_timing','reasoning.decision_timing'),
                'mixed or missing native timing event')
        p=event['payload']
        if event['event_type']!='reasoning.swap_timing':
            excluded.append(dict(sequence=index+1,reason=p['status']));continue
        source=p['autonomous_source'];key=canonical_json(source);covered.add(key)
        require(p['policy_sha256']==digest(json.loads(policy_json)) and p['timer_source']=='MatchService.server_tick'
                and p['input_mode']=='foreground' and p['clock']=='host.perf_counter_ns'
                and p['input_parameters']==PARAMETERS,'native config/input/timer mismatch')
        if not p['required_input_completed']:
            excluded.append(dict(sequence=index+1,reason='INCOMPLETE_INPUT'));continue
        bound=p['witness']==witness
        partial=p['witness']
        opening=(source.get('turn') in (0,1) and type(partial) is dict
            and partial.get('account_username_sha256')==witness['account_username_sha256']
            and partial.get('boss')==witness['boss'] and partial.get('loadout',{}).get('config')==witness['loadout']['config']
            and partial.get('loadout',{}).get('cards')==[])
        require((bound or opening) and p['status']=='RETURNED' and p['sent_clicks']==2
                and p['click_status']=='SENT' and p['board_input_mode']=='two_click'
                and p['preflight_failure'] is None,'native ownership/loadout/input anchor required')
        ts=[p[k] for k in ('decision_exit_ns','preflight_start_ns','read_end_ns','validation_end_ns','executor_return_ns')]
        require(all(type(t) is int and t>=0 for t in ts) and ts==sorted(ts) and ts[-1]>ts[1],
                'valid native H/I clock intervals required')
        observed,end=p['observed_ns'],p['observation_read_end_ns']
        require(type(observed) is int and type(end) is int and 0<=observed<=end<=ts[0],
                'native observation clock order required')
        admissible=bound and end-observed<=250_000_000 and ts[2]-ts[1]<=100_000_000
        require(key not in sources and p['decision_source_hash']==p['source_hash']==source['critical_state_hash']
                and p['turn']==source['turn'] and p['match_id']==source['session']['match_id'],
                'duplicate/stale native source')
        require(p['controller_tail_ns']==ts[1]-ts[0] and p['elapsed_upper_bound_ns']==ts[-1]-ts[1]
                and p['full_tail_ns']==ts[-1]-ts[0], 'native derived timing differs from raw clocks')
        sources.add(key)
        join=[r for r in sent if r.get('identity',{}).get('source')==source]
        ack=[r for r in combats if r.get('event')=='action_result' and r.get('result')=='SWAP_ACKNOWLEDGED'
             and r.get('action',{}).get('identity',{}).get('source')==source]
        terminal=[r for r in combats if r.get('event')=='action_result'
            and r.get('reason')=='COMBAT_LIFECYCLE_ENDED'
            and r.get('action',{}).get('identity',{}).get('source')==source]
        attempts=[a for a in farm['all_attempts'] if a.get('session_key')==source['session']]
        terminal_proved=False
        if len(ack)==0 and len(terminal)==len(attempts)==len(join)==1:
            attempt=attempts[0];snapshot=attempt.get('terminal_snapshot')
            summaries=[r for r in combats if r.get('event')=='auto_controller_summary'
                and r.get('terminalCombatSnapshot')==snapshot]
            last=[r for r in sent if r.get('identity',{}).get('source',{}).get('session')==source['session']]
            terminal_proved=(type(snapshot) is dict and snapshot.get('session_key')==source['session']
                and snapshot.get('match_id')==source['session']['match_id']
                and snapshot.get('turn_number')==source['turn'] and snapshot.get('srv_seq')==source['srv_seq']
                and snapshot.get('result')==attempt.get('result')=='WIN' and snapshot.get('confidence')=='STRONG'
                and snapshot.get('boss_hp')==0 and snapshot.get('captured_before_cleanup') is True
                and attempt.get('normal_postmatch') is True and len(summaries)==1
                and summaries[0].get('stopReason')=='COMBAT_LIFECYCLE_ENDED'
                and terminal[0].get('result')=='ACTION_ABORTED_STATE_CHANGED' and last[-1]==join[0])
        results=ack if len(ack)==1 else terminal if terminal_proved else []
        require(len(join)==len(results)==1 and results[0]['action']['identity']==join[0]['identity']
                and combats.index(results[0])>combats.index(join[0]),
                'independent native sent/ACK or terminal proof required')
        intervals.append(dict(H_ms=(ts[1]-ts[0])/1e6,I_ms=(ts[-1]-ts[1])/1e6,sequence=index+1,
            full_witness=bound,admissible=admissible,acknowledged=len(ack)==1,
            classification='TERMINAL_PROVED' if terminal_proved else 'FULL_ANCHOR' if admissible else 'OPENING_OR_READ_VETO'))
    require(all(canonical_json(r.get('identity',{}).get('source')) in covered for r in sent),
            'every sent swap must have a retained timing record')
    anchors=sum(x['admissible'] and x['acknowledged'] for x in intervals)
    require(1<=len(intervals)<=512 and anchors>0, 'current native full H/I anchors missing')
    return dict(scope='CURRENT_SOURCE_NATIVE_BASIC' if compatibility is None else compatibility['scope'],
        native_origin_sha256=native_sha,current_runtime_sha256=request.runtime_sha256,
        anchors=anchors,returns=len(intervals),all_attempts=len(ledger),
        intervals=intervals,excluded=excluded,maxima_ms={k:max(x[k] for x in intervals) for k in ('H_ms','I_ms')},
        native_U_ms=None,transport_age_ms=None,host_unity_alignment_ms=None)


def load_reviewed_authority(directory,data,cal,request,*,policy_json,now):
    from .reasoning_operational import OperationalPilotAuthority,command_wait_ms
    require(data['pilot_protocol']==PROTOCOL and data['root_read_policy']==POLICY
            and data['config_projection_policy']==VERSION and data['source_projection_policy']==SOURCE_POLICY
            and data['max_read_span_ms']==100 and data['host_guard_ms']==250 and data['return_margin_ms']==100
            and data['component_monitor']=='POST_RETURN_COMPONENTS_V1'
            and data['command_ceiling_version']=='TWO_CLICKS_TWO_SETTLES_V1'
            and data['input_parameters']==PARAMETERS and data['total_attempt_cap']==3,
            'complete D1 current-source protocol required')
    activation=document(directory,data['activation_review'])
    guard_policy=data.get('component_guard_policy')
    if guard_policy is not None:
        from .reasoning_component_guard import VERSION as GUARD_VERSION
        require(guard_policy==GUARD_VERSION and activation.get('component_guard_policy')==guard_policy,
                'independently pinned shared guard policy required')
    require(all(activation.get(k)==data[k] for k in ('pilot_protocol','root_read_policy',
        'config_projection_policy','source_projection_policy'))
        and activation['calibration_sha256']==data['calibration']['sha256']
        and activation['selector_allowance_sha256']==data['selector_allowance']['sha256'],
        'independent D1 native/cost/policy activation pins required')
    native=verify_native(directory,cal,request,policy_json=policy_json,witness=data['witness'])
    allowance=document(directory,data['selector_allowance']);qref=allowance['qualification'];q=document(directory,qref)
    costs=validate_costs(Path(directory)/Path(qref['path']).parent,q)
    require(q.get('component_guard_policy')==guard_policy,'matching collector guard cost qualification required')
    require(q['profile']==json.loads(policy_json)['play_style'],'qualification profile differs from native cohort')
    require(allowance['scope']=='CURRENT_NATIVE_D1_SELECTOR' and allowance['costs']==costs
            and allowance['runtime_sha256']==request.runtime_sha256 and allowance['host_sha256']==request.host_sha256,
            'current D1 allowance binding required')
    components=dict(controller_tail_ms=native['maxima_ms']['H_ms'],final_input_ms=native['maxima_ms']['I_ms'],
        selector_extra_ms=costs['selector_extra_ms'],command_wait_ms=command_wait_ms(**PARAMETERS),host_guard_ms=250)
    return OperationalPilotAuthority(json.loads(policy_json)['play_style'],policy_json,FrozenJSON.of(data['scope']),
        FrozenJSON.of(data['witness']),FrozenJSON.of(data['model']),request.verified_build_sha256,request.runtime_sha256,
        request.host_sha256,request.contract_sha256,request.decision_sha256,data['calibration']['sha256'],FrozenJSON.of(components),
        FrozenJSON.of(PARAMETERS),100,native['anchors'],time.perf_counter_ns()+int((data['expires_at']-now)*1e9),
        return_margin_ms=100,budget_ms=data['budget_ms'],root_read_policy=FrozenJSON.of(POLICY),
        config_projection_policy=VERSION,component_guard_policy=guard_policy)
