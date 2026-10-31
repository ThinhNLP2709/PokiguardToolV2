"""File-only Mega native evidence and bounded pilot admission; no game APIs."""
import hashlib,math,time
from pathlib import Path

from .reasoning_calibration_review import document,read_ref,PARAMETERS
from .reasoning_snapshot import FrozenJSON,digest,require
from .reasoning_mega import VERSION,PROTOCOL,profile_for,structural_witness

SCHEMA='pokiguard.reasoning.current_native_d4.v1'
NATIVE_SOURCE='efc3887a67ad352fcd6d5e654f1afb07937b0119fc1279030d789a8159077e6a'
HISTORY=[
    ('fe2ee9c2eeadb21db4ff99226b90a62f6538fcf94d8be9ec4d505e957dbe1a79',3,3),
    ('ad3c204fe7502af5ff928093b60bd577c329a16f95a052f5b00897a21adc7ae1',1,1),
    ('99f9421e19b82e87df34f70753ba8b9f4f5c1a07a7683e82c660f5d60c38aaa6',1,0),
    ('a6682838c1ca9eec4fdb82662a49963efeefd65da7b0ee00ce8e5edeabd430bf',1,1)]
RAW_MANIFESTS=['add02106af318cf774e6f8ff1a75a9678b09931ac4e1c449c386262bdb9ab8ab',
    'ece255cce43301adb8db9c1849a0921c2802526470a5fc3064087a6c6aa1adab',
    'c35d581aabc3cd716fa6346b7ccf79f8976dd2c246bd24543b851976e5ab4007',
    '73f9a9af59c204ebdd2f81549c2268bbe4afe00afdcc9e16e0a4cd0a68c6dc17']
CHANGED={
    'src/pokiguard_v2/reasoning_full_action_planner.py','src/pokiguard_v2/reasoning_full_actions.py',
    'src/pokiguard_v2/reasoning_operational.py','src/pokiguard_v2/reasoning_operational_launch.py',
    'src/pokiguard_v2/reasoning_runner.py','src/pokiguard_v2/reasoning_selection.py',
    'src/pokiguard_v2/reasoning_mega_timing.py','src/pokiguard_v2/reasoning_swap_timing.py',
    'tests/reasoning_controller_fixture.py','tests/test_reasoning_mega_timing.py','tests/test_reasoning_demon.py',
    'tests/test_reasoning_shared_guard.py','tests/test_reasoning_planner.py'}
ADDED={'src/pokiguard_v2/reasoning_mega.py','src/pokiguard_v2/reasoning_mega_native.py',
    'tools/prepare_d4_reasoning.py','tests/test_reasoning_mega.py','tests/test_reasoning_mega_native.py'}


def check_config(config):
    require(config.play_style.value=='mega_icarus_spam_skill' and config.game_mode.value=='solo'
        and config.intelligence.value=='basic' and config.ai.shadow_enabled is False
        and [getattr(config,k).value for k in ('main_pet','evolution','damage_card')]==['normal','mega','pet_skill']
        and config.audition_mode.value=='none' and config.pet_skill_fire_condition.value=='sword_count'
        and config.pet_skill_fire_value==6 and config.normalized_boss_id=='2346'
        and config.target_completed_matches==config.max_match_attempts==2
        and config.input_delivery_mode.value=='foreground' and config.board_input_mode.value=='two_click'
        and config.ai.budget_ms==4000,'frozen SmallBlue220/Javan->Mega/seal6/noQTE/BASIC/SOLO/two remaining attempts required')


def run_id():
    return hashlib.sha256(('D4_RESERVED_REASONING2:'+HISTORY[-1][0]).encode()).hexdigest()[:32]


def verify_boundary(directory,cal,runtime_sha256,*,root=None):
    from .reasoning_calibration import source_files
    root=Path(__file__).resolve().parents[2] if root is None else Path(root)
    old=document(directory,cal['native_source_manifest']);new=document(directory,cal['source_manifest'])
    require(old['fingerprint']==digest(old['files'])==NATIVE_SOURCE
        and new['fingerprint']==digest(new['files'])==runtime_sha256,'Mega source manifests unbound')
    current=source_files(root)
    require(current==new['files'],'current source differs from reviewed Mega package')
    changed={n for n,h in old['files'].items() if current.get(n)!=h}
    require(changed==CHANGED and set(current)-set(old['files'])==ADDED
        and set(old['files'])<=set(current),'unreviewed Mega source additions/changes')
    # Every non-reasoning byte, including controller, BASIC, simulator, readers,
    # capture, executor, QTE, ACK and farm must remain native-identical.
    require(all(current[n]==h for n,h in old['files'].items() if n not in CHANGED),
        'native core execution changed')
    return dict(status='PASS',changed_files=sorted(changed),added_files=sorted(ADDED),
        unchanged_files=len(old['files'])-len(changed),controller_byte_exact=True,
        basic_solver_reader_capture_input_QTE_ACK_farm_byte_exact=True)


def verify_native(directory,cal):
    """Recompute joins, elapsed samples and all six consumed attempts from raw."""
    import json
    from types import SimpleNamespace as NS
    from .reasoning_calibration import decode_config
    from .reasoning_operational_launch import operational_policy_json
    from .reasoning_mega_timing import input_interval
    require(cal['schema']==SCHEMA and len(cal['history'])==4,'complete Mega history required')
    for ref,(expected,attempts,wins) in zip(cal['history'],HISTORY):
        raw=read_ref(directory,ref);closed=json.loads(raw)
        require(hashlib.sha256(raw).hexdigest()==expected and closed['attempts']==attempts
            and closed['wins']==wins and closed['reasoning_activation'] is False,'consumed native attempt removed or rebound')
    expected={};lookup={}
    require(len(cal['raw_manifests'])==4,'all four raw manifests required')
    for ref,pin in zip(cal['raw_manifests'],RAW_MANIFESTS):
        raw=read_ref(directory,ref);require(hashlib.sha256(raw).hexdigest()==pin,'sealed raw manifest changed')
        expected.update({name:value['sha256'] for name,value in json.loads(raw)['files'].items()})
    for item in cal['raw_audit']:
        raw=read_ref(directory,item['ref'])
        require(item['original'] not in lookup and hashlib.sha256(raw).hexdigest()==item['sha256']
            ==expected.get(item['original']),'prior raw history changed')
        lookup[item['original']]=item['ref']
    require(len(lookup)==len(expected)==78 and set(lookup)==set(expected),'all original D4 native files must be preserved')
    native='docs/phase5/artifacts/5d4_input_repeat1_live_20261018_143456/ui_session/basic_calibration/'
    farm='logs/farm_runs/b5e66cb14607410989c8057290a63cc8/'
    for role,name in dict(request='docs/phase5/artifacts/5d4_repeat_measurement_preparation_20261018/repeat_request_cap8.json',
        session=native+'session.json',run=farm+'run.json',watermarks=native+'watermarks.json',
        combat=farm+'matches/attempt_001/combat.jsonl').items():
        require(cal[role]==lookup[name],'native role rebound to an unsealed file')
    records_name,=[n for n in lookup if n.startswith(native+'reasoning.') and n.endswith('.jsonl')]
    require(cal['records']==lookup[records_name] and cal['pet_skills']==[lookup[farm+
        'matches/attempt_001/pet_skill_M_ffd55a9b_turn'+str(t)+'.jsonl'] for t in (13,17,25,29)],
        'native timing/skill roles rebound')
    req=document(directory,cal['request']);session=document(directory,cal['session'])
    run=document(directory,cal['run']);water=document(directory,cal['watermarks'])
    origin=document(directory,cal['native_source_manifest'])
    require(req['source_sha256']==origin['fingerprint']==digest(origin['files'])==NATIVE_SOURCE
        and req['reasoning_enabled'] is False and req['config']['intelligence']=='basic'
        and req['config']['ai']['shadow_enabled'] is False and req['total_attempt_cap']==session['total_attempt_cap']==1
        and req['run_id']==session['run_id']==water['run_id'],'native BASIC-only source/cap/session changed')
    ledger=run['snapshot'];require(ledger['farm_run_id']==session['farm_run_id']=='b5e66cb14607410989c8057290a63cc8'
        and ledger['match_attempts']==ledger['completed_matches']==ledger['wins']==1
        and ledger['stop_reason']=='FARM_TARGET_COMPLETED' and run['finalLifecycle']=='BOSS_LOBBY'
        and ledger['technical_aborts']==ledger['technical_recoveries']==0
        and not any(ledger['safety'].values()),'completed native measurement control not clean')
    records=[json.loads(l) for l in read_ref(directory,cal['records']).decode('utf-8').splitlines()]
    combat=[json.loads(l) for l in read_ref(directory,cal['combat']).decode('utf-8').splitlines()]
    stats=water['before_close']
    require(water['flushed'] and water['closed'] and not water['collector_disabled'] and water['collector_dropped']==0
        and stats['accounting_valid'] and stats['written']==stats['enqueued']==stats['eligible']==water['sequence']==len(records)==18
        and all(stats[k]==0 for k in ('dropped_before_enqueue','failed_write','discarded_after_enqueue','queued','in_writer')),
        'native timing durability incomplete')
    require([r['event_seq'] for r in records]==list(range(1,19))
        and all(r['correlation']['run_id']==req['run_id'] and r['correlation']['mode']=='BASIC_CALIBRATION_ONLY' for r in records),
        'native timing sequence/correlation changed')
    H=[];I=[];roots=[];finals=[];witnesses=[];spans=[]
    swaps=[r['payload'] for r in records if r['event_type']=='reasoning.swap_timing']
    sent=[r for r in combat if r['event']=='action_sent' and r.get('action')=='SWAP']
    acks=[r for r in combat if r['event']=='action_result' and r.get('result')=='SWAP_ACKNOWLEDGED']
    require(len(swaps)==len(sent)==len(acks)==11,'every sent swap requires one timing and ACK')
    native_policy=operational_policy_json(decode_config(req['config']))
    for p in swaps:
        source=p['autonomous_source']
        require(sum(r['identity']['source']==source for r in sent)==sum(r['action']['identity']['source']==source for r in acks)==1
            and p['source_hash']==p['decision_source_hash']==source['critical_state_hash']
            and p['status']=='RETURNED' and p['required_input_completed'] and p['sent_clicks']==2
            and p['click_status']=='SENT' and p['preflight_failure'] is None and p['operational_fault'] is None
            and p['clock']=='host.perf_counter_ns' and p['timer_source']=='MatchService.server_tick'
            and p['input_mode']=='foreground' and p['board_input_mode']=='two_click'
            and p['input_parameters']==PARAMETERS and p['policy_sha256']==digest(json.loads(native_policy)),
            'native swap input/source/clock/policy differs')
        ts=[p[k] for k in ('observed_ns','observation_read_end_ns','decision_exit_ns','preflight_start_ns',
            'read_end_ns','validation_end_ns','executor_return_ns')]
        require(all(type(t) is int for t in ts) and 0<=ts[0] and ts==sorted(ts)
            and p['controller_tail_ns']==ts[3]-ts[2] and p['elapsed_upper_bound_ns']==ts[-1]-ts[3],
            'native swap duration invalid')
        H.append(p['controller_tail_ns']/1e6);I.append(p['elapsed_upper_bound_ns']/1e6)
        roots.append((ts[1]-ts[0])/1e6);finals.append((p['read_end_ns']-p['preflight_start_ns'])/1e6)
        witnesses.append(structural_witness(p['witness']))
    skill_logs=[[json.loads(l) for l in read_ref(directory,ref).decode('utf-8').splitlines()] for ref in cal['pet_skills']]
    dispatches=[r for r in combat if r['event']=='pet_skill_dispatch_result']
    skillrows=[r['payload'] for r in records if r['event_type']=='reasoning.skill_timing']
    require(len(skill_logs)==len(dispatches)==len(skillrows)==4,'all four skill cycles required')
    for p in skillrows:
        d,=[r for r in dispatches if r['identity']['source']['turn']==p['turn']];result=d['result'];source=d['identity']['source']
        matching=[log for log in skill_logs if any(r['event']=='observer_stopped'
            and r.get('runtimeHookSummary',{}).get('action_id')==result['action_id'] for r in log)]
        require(len(matching)==1,'skill primitive/source join is ambiguous')
        caps=[r['capability'] for r in matching[0] if r['event']=='pet_skill_capability_observed']
        require(any(c['status']=='CURRENT' and c['ownership_current'] and c['pet_id']==2524
            and c['source_pet_skill_card_id'] is None and c['skill_card_id']==c['card_id']==22
            and c['skill_family']=='MEGA_ICARUS_CLICK_ONLY' and c['target_mode']=='AUTOMATIC'
            and c['session_key']==source['session'] and c['live_card_actionable'] is True
            and c['effective_mana_cost']==200 and c['effective_power_cost']==150
            and c['effective_mana_cost_source']=='CONDITION_USE' and c['effective_power_cost_source']=='POWER'
            and c['cooldown_turns']==0 for c in caps),'own native Mega current card/cost missing')
        require(result['kind']==p['result_kind']=='SUCCESS_NO_ACTION'
            and (result['card_clicks'],result['space_presses'],result['direction_presses'])==(1,0,0)
            and p['match_id']==source['session']['match_id'] and p['source_hash']==p['decision_source_hash']==source['critical_state_hash']
            and p['skill_card_id']==22 and p['status']=='RETURNED' and p['complete_interval_bound']
            and p['first_click_ns'] is None and p['first_click_status']=='NOT_MEASURED'
            and p['clock']=='host.perf_counter_ns' and p['input_parameters']==PARAMETERS,'native click-only/source changed')
        v=p['click_only_input']
        replay=input_interval(dict(monotonic_start=v['start_seconds'],implementation=v['implementation'],resolution_seconds=v['resolution_seconds']),
            NS(kind=NS(value=result['kind']),card_clicks=1,space_presses=0,direction_presses=0,
                telemetry=NS(card_click_timestamp=result['telemetry']['card_click_timestamp'])),v['readonly_return_seconds'])
        require(replay==v and v['status']=='OBSERVED_PADDED_ELAPSED' and v['input_authority'] is False
            and v['sample_max_is_future_bound'] is False,'same-clock padded native click interval invalid')
        require(p['observed_ns']<=p['observation_read_end_ns']<=p['decision_exit_ns']<=p['primitive_start_ns']<=p['executor_return_ns']
            and p['controller_tail_ns']==p['primitive_start_ns']-p['decision_exit_ns']
            and p['full_primitive_ns']==p['executor_return_ns']-p['primitive_start_ns'],'whole skill clock interval invalid')
        H.append(p['controller_tail_ns']/1e6);I.append(v['required_input_upper_ms']);spans.append(v)
        roots.append((p['observation_read_end_ns']-p['observed_ns'])/1e6)
    require(all(w==witnesses[0] for w in witnesses) and max(roots)<=250 and max(finals)<=100,
        'native witness/root/final span differs')
    require(sorted(p['turn'] for p in skillrows)==[13,17,25,29],'native repeated/terminal sample coverage changed')
    return dict(H_ms=max(H),I_ms=max(I),swap_samples=11,skill_samples=4,attempts_consumed=6,
        wins=5,safe_stops=1,remaining_reasoning=2,total_case_cap=8,witness=witnesses[0],
        host_sha256=req['host_sha256'],game_build_sha256=req['game_build_sha256'],policy_json=native_policy,
        root_read_max_ms=max(roots),final_read_max_ms=max(finals),input_intervals=spans,
        native_U_ms=None,sample_maxima_not_future_bound=True,coverage='SWAP_RETURN_AND_SAME_CLOCK_MEGA_CLICK_PADDED_ELAPSED')


def load_reviewed_authority(directory,data,cal,request,*,policy_json,now):
    from .reasoning_calibration import source_fingerprint,decode_config
    from .reasoning_operational import OperationalPilotAuthority,command_wait_ms
    from .reasoning_root_policy import POLICY
    from .reasoning_component_guard import VERSION as GUARD
    root=Path(__file__).resolve().parents[2];config=decode_config(data['full_config']);check_config(config)
    require(data['pilot_protocol']==PROTOCOL and data['run_id']==run_id() and data['total_attempt_cap']==2
        and data['previous_attempts_consumed']==6 and data['total_d4_cap']==8
        and data['policy_json']==policy_json and data['input_parameters']==PARAMETERS
        and data['root_read_policy']==POLICY and data['max_read_span_ms']==100
        and data['component_guard_policy']==GUARD and data['component_monitor']=='POST_RETURN_COMPONENTS_V1',
        'Mega bounded operational protocol differs')
    require(source_fingerprint(root)==request.runtime_sha256==cal['runtime_sha256'],'current Mega source changed')
    verify_boundary(directory,cal,request.runtime_sha256)
    native=verify_native(directory,cal)
    require(native['policy_json']==policy_json and native['host_sha256']==request.host_sha256
        and native['game_build_sha256']==request.verified_build_sha256 and native['witness']==data['witness']
        and data['action_profile']==profile_for(native['witness']),'native policy/host/build/cohort changed')
    q=document(directory,data['selector_allowance']);costs=document(directory,q['raw_costs'])
    require(q['status']=='PASS' and q['source_sha256']==request.runtime_sha256
        and q['host_sha256']==request.host_sha256 and q['profile_version']==VERSION
        and q['cycles']>=100 and len(costs)==q['cycles']
        and all(type(v) in (int,float) and math.isfinite(v) and v>=0 for v in costs)
        and q['selector_extra_ms']==max(costs)<=30 and q['loss']==0 and q['worker_roundtrip_pass']
        and q['writer_cleanup_pass'] and q['controller_byte_exact'] and q['component_guard_policy']==GUARD,
        'own final-source Mega selector/worker/writer qualification required')
    activation=document(directory,data['activation_review'])
    require(activation['pilot_protocol']==PROTOCOL and activation['calibration_sha256']==data['calibration']['sha256']
        and activation['selector_allowance_sha256']==data['selector_allowance']['sha256']
        and activation['component_guard_policy']==GUARD and activation['previous_attempts_consumed']==6
        and activation['total_d4_cap']==8,'independent two-remaining-attempt activation required')
    components=dict(controller_tail_ms=native['H_ms'],final_input_ms=native['I_ms'],selector_extra_ms=max(costs),
        command_wait_ms=command_wait_ms(**PARAMETERS),host_guard_ms=250)
    return OperationalPilotAuthority('mega_icarus_spam_skill',policy_json,FrozenJSON.of(data['scope']),FrozenJSON.of(data['witness']),
        FrozenJSON.of(data['model']),request.verified_build_sha256,request.runtime_sha256,request.host_sha256,
        request.contract_sha256,request.decision_sha256,data['calibration']['sha256'],FrozenJSON.of(components),
        FrozenJSON.of(PARAMETERS),100,15,time.perf_counter_ns()+int((data['expires_at']-now)*1e9),
        return_margin_ms=100,budget_ms=4000,root_read_policy=FrozenJSON.of(POLICY),
        action_profile=FrozenJSON.of(data['action_profile']),component_guard_policy=GUARD)
