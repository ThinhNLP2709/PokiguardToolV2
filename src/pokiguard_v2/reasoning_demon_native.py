"""D3 file-only setup gate; native control rows and narrow successor boundary."""
import json
import math
from pathlib import Path
import time

from .reasoning_calibration_review import document, read_ref, PARAMETERS
from .reasoning_demon import MODEL, VERSION, PROTOCOL, structural_witness
from .reasoning_snapshot import FrozenJSON, digest, require

SCHEMA = 'pokiguard.reasoning.current_native_d3.v1'
MULTIPLIER20_PROTOCOL = 'D3_DEMON_MULTIPLIER20_CURRENT_NATIVE_V1'
PREVIOUS9_LEDGER_SHA = '225ba4d64013b1e69f3543f904b03fcf93cde9141b2bd69d963994aeaf572d3b'
NATIVE_SOURCE = 'f397a136d1eafb8f4b2f6159716469d1378c1a4977ba36f254282c6fcecc09ba'
CHANGED = {'src/pokiguard_v2/reasoning_operational.py', 'src/pokiguard_v2/reasoning_operational_launch.py',
    'src/pokiguard_v2/reasoning_planner.py', 'src/pokiguard_v2/reasoning_pilot.py',
    'src/pokiguard_v2/reasoning_selection.py', 'tests/reasoning_controller_fixture.py',
    'tests/test_reasoning_d2_targeted.py'}
ADDED = {'src/pokiguard_v2/reasoning_demon.py', 'src/pokiguard_v2/reasoning_demon_native.py',
    'tools/prepare_d3_reasoning.py', 'tests/test_reasoning_demon.py'}


def check_config(config, *, protocol=PROTOCOL):
    require(protocol in (PROTOCOL, MULTIPLIER20_PROTOCOL), 'unknown D3 bounded protocol')
    cap = 20 if protocol == MULTIPLIER20_PROTOCOL else 3
    require(config.play_style.value=='demon_aegis_farm' and config.intelligence.value=='basic'
        and config.game_mode.value=='solo' and config.ai.shadow_enabled is False
        and [getattr(config,k).value for k in ('main_pet','evolution','damage_card')]==['normal','none','pet_passive']
        and config.pet_skill_fire_condition.value=='sword_count' and config.pet_skill_fire_value==4
        and config.demon_target_gem.value=='shield'
        and config.normalized_boss_id=='1436' and config.target_completed_matches==config.max_match_attempts==cap
        and config.input_delivery_mode.value=='foreground' and config.board_input_mode.value=='two_click',
        'D3 minimum requires frozen Demon/Lieyun77/setting4/foreground/two_click and exact protocol cap')


def verify_multiplier20_extension(directory, data, activation):
    """Setup-only exception for the user's separate twenty-match request.

    The old three-match protocol and its native calibration remain unchanged.
    This record neither grants another cohort nor relaxes any gameplay gate.
    """
    extension = document(directory, data['batch_extension'])
    previous_ref = extension['previous_cumulative']
    require(previous_ref['sha256'] == PREVIOUS9_LEDGER_SHA, 'D3 previous nine-match ledger changed')
    previous = document(directory, previous_ref)
    require(extension['schema'] == '5d3.multiplier20.extension.v1'
        and extension['accepted'] is True and extension['scope'] == 'USER_REQUESTED_D3_MULTIPLIER20'
        and extension['previous_attempts_consumed'] == previous['cumulative_started']
            == previous['cumulative_completed'] == 9
        and previous['remaining_authorized_attempts'] == 0
        and extension['attempt_cap'] == data['total_attempt_cap'] == activation['total_attempt_cap'] == 20
        and extension['maximum_cumulative_attempts'] == 29
        and extension['failed_entry_abort_included'] is True
        and extension['no_automatic_extension'] is True
        and extension['source_sha256'] == data['runtime_sha256']
        and activation['batch_extension_sha256'] == data['batch_extension']['sha256']
        and activation['manual_start_only'] is True
        and type(activation['operator_authorization']) is str
        and bool(activation['operator_authorization'].strip())
        and type(extension['operator_authorization']) is str
        and bool(extension['operator_authorization'].strip()), 'D3 explicit multiplier20 extension required')
    return extension


def verify_native(directory, cal):
    require(cal['schema']==SCHEMA, 'D3 native schema required')
    req=document(directory,cal['request']);session=document(directory,cal['session'])
    run=document(directory,cal['run']);water=document(directory,cal['watermarks'])
    origin=document(directory,cal['native_source'])
    require(req['profile_protocol']=='D3_DEMON_AEGIS_BASIC_CONTROL_V1' and req['reasoning_enabled'] is False
        and req['source_sha256']==origin['fingerprint']==NATIVE_SOURCE==digest(origin['files'])
        and req['total_attempt_cap']==session['total_attempt_cap']==3
        and req['run_id']==session['run_id']==water['run_id'], 'D3 native request/source mismatch')
    from .reasoning_calibration import decode_config
    check_config(decode_config(req['config']))
    s=run['snapshot'];stats=water['before_close']
    require(s['farm_run_id']==session['farm_run_id'] and s['match_attempts']==s['completed_matches']==3
        and s['technical_aborts']==s['technical_recoveries']==0 and all(v==0 for v in s['safety'].values())
        and run['finalLifecycle']=='BOSS_LOBBY' and s['stop_reason']=='FARM_TARGET_COMPLETED'
        and run['unexpectedError'] is None and s['total_swap_sent']==12 and s['total_swap_acknowledged']==9,
        'D3 all-attempt boundary missing')
    require(water['flushed'] and water['closed'] and not water['collector_disabled']
        and water['collector_dropped']==0 and stats['accounting_valid'] and not stats['disabled']
        and all(stats[k]==0 for k in ('dropped_before_enqueue','failed_write','discarded_after_enqueue','queued','in_writer')),
        'D3 durable timing incomplete')
    rows=[json.loads(line) for line in read_ref(directory,cal['records']).decode().splitlines()]
    require([r['event_seq'] for r in rows]==list(range(1,13))
        and stats['written']==stats['enqueued']==water['sequence']==len(rows)==12,'D3 timing sequence incomplete')
    sent=[];ack=[];terminal=[];matches=[];player_stats=[]
    for ref in cal['combats']:
        combat=[json.loads(line) for line in read_ref(directory,ref).decode().splitlines()]
        summary=next(x for x in reversed(combat) if x['event']=='auto_controller_summary')
        terminal_snapshot=summary['terminalCombatSnapshot']
        require(summary['pending'] is None and all(v==0 for v in summary['safetyTelemetry'].values())
            and summary['counters']['action_response_timeouts']==0
            and terminal_snapshot['confidence']=='STRONG' and terminal_snapshot['local_hp']>0
            and terminal_snapshot['boss_hp']==0 and terminal_snapshot['captured_before_cleanup'] is True,
            'D3 native pending/safety/terminal evidence fault')
        actions=[x['identity'] for x in combat if x['event']=='action_sent']
        policies=[x for x in combat if x['event']=='policy_decision']
        require(len(policies)==len(actions),'D3 policy publications incomplete')
        player_stats.extend([p['player'][k] for k in ('max_hp','max_mana','max_power','attack')] for p in policies)
        acknowledged=[x['action']['identity'] for x in combat if x['event']=='action_result' and x.get('result')=='SWAP_ACKNOWLEDGED']
        endings=[x for x in combat if x['event']=='action_result' and x.get('result')=='ACTION_ABORTED_STATE_CHANGED']
        require(len(endings)==1 and endings[0]['reason']=='COMBAT_LIFECYCLE_ENDED'
            and summary['terminalCombatSnapshot']['turn_number']==endings[0]['action']['identity']['source']['turn']
            and summary['fullCombatResult']=='WIN' and len(actions)==len(acknowledged)+1,
            'only narrowly proved terminal unacknowledged row may be excluded')
        match=summary['terminalCombatSnapshot']['match_id'];matches.append(match)
        require(all(x['source']['session']['match_id']==match for x in actions),'D3 cross-match action')
        sent.extend(actions);ack.extend(acknowledged);terminal.append(endings[0]['action']['identity'])
    require(len(matches)==len(set(matches))==3 and len(sent)==12 and len(ack)==9
        and all(x in sent for x in ack+terminal) and len({json.dumps(x,sort_keys=True) for x in sent})==12,
        'D3 action accounting mismatch')
    H=[];I=[];root=[];reads=[];witnesses=[];qualified=0;excluded=0
    require(len(cal['combats'])==3,'D3 requires all three combats')
    for row, identity in zip(rows,sent):
        p=row['payload']
        require(row['event_type']=='reasoning.swap_timing' and row['correlation']['run_id']==req['run_id']
            and p['autonomous_source']==identity['source'] and p['status']=='RETURNED'
            and p['required_input_completed'] and p['sent_clicks']==2 and p['operational_fault'] is None
            and p['input_parameters']==PARAMETERS and p['clock']=='host.perf_counter_ns'
            and p['timer_source']=='MatchService.server_tick' and p['native_U_ms'] is None
            and p['decision_source_hash']==p['source_hash']==identity['source']['critical_state_hash']
            and p['observed_ns']<=p['observation_read_end_ns']<=p['decision_exit_ns']<=p['preflight_start_ns']
                <=p['read_end_ns']<=p['executor_return_ns'],'D3 timing identity/clock/parameters invalid')
        h=p['preflight_start_ns']-p['decision_exit_ns'];i=p['executor_return_ns']-p['preflight_start_ns']
        require(h==p['controller_tail_ns'] and i==p['elapsed_upper_bound_ns'],'D3 timing duration mismatch')
        root.append((p['observation_read_end_ns']-p['observed_ns'])/1e6)
        reads.append((p['read_end_ns']-p['preflight_start_ns'])/1e6)
        witnesses.append(structural_witness(p['witness']))
        if identity in ack:
            H.append(h/1e6);I.append(i/1e6);qualified+=1
        else:
            require(identity in terminal,'D3 unaccounted timing sample');excluded+=1
    require(qualified==9 and excluded==3 and all(w==witnesses[0] for w in witnesses)
        and len(player_stats)==12 and all(p==player_stats[0] for p in player_stats)
        and max(root)<=250 and max(reads)<=100,'D3 native cohort/read policy mismatch')
    witness=rows[-1]['payload']['witness']
    return dict(H_ms=max(H),I_ms=max(I),ack_samples=9,terminal_excluded=3,total_sent=12,
        witness=witness,player_stats=player_stats[0],root_read_sample_max_ms=max(root),final_read_sample_max_ms=max(reads),
        native_source_sha256=NATIVE_SOURCE,host_sha256=req['host_sha256'],game_build_sha256=req['game_build_sha256'],
        sample_max_not_future_bound=True,native_U_ms=None,exact_boss_action='UNKNOWN',own_pet='OPERATOR_BINDING_ONLY')


def verify_boundary(directory, cal, runtime_sha):
    from .reasoning_calibration import source_files
    old=document(directory,cal['native_source']);new=document(directory,cal['source_manifest'])
    require(new['fingerprint']==digest(new['files'])==runtime_sha,'D3 current source unpinned')
    changed={p for p in old['files'] if old['files'][p]!=new['files'].get(p)}
    added=set(new['files'])-set(old['files'])
    require(changed==CHANGED and added==ADDED,'unreviewed D3 source boundary')
    root=Path(__file__).resolve().parents[2]
    require(source_files(root)==new['files'],'D3 current files changed')
    # Every gameplay/controller/solver/provider/capture/input/QTE/ACK/lifecycle
    # file is byte-exact to the native BASIC cohort. Only the listed optional
    # reasoning/setup modules and historical fixture are successor code.
    return dict(changed=sorted(changed),added=sorted(added),unchanged=len(old['files'])-len(changed),
        gameplay_controller_byte_exact=True,native_source_not_relabelled=True)


def load_reviewed_authority(directory,data,cal,request,*,policy_json,now):
    from .reasoning_operational import OperationalPilotAuthority,command_wait_ms
    from .reasoning_root_policy import POLICY
    from .reasoning_component_guard import VERSION as GUARD
    extended = data['pilot_protocol'] == MULTIPLIER20_PROTOCOL
    require(data['pilot_protocol'] in (PROTOCOL, MULTIPLIER20_PROTOCOL)
        and data['total_attempt_cap']==(20 if extended else 3)
        and data['root_read_policy']==POLICY and data['component_guard_policy']==GUARD
        and data['component_monitor']=='POST_RETURN_COMPONENTS_V1','D3 independent bounded protocol required')
    native=verify_native(directory,cal);verify_boundary(directory,cal,request.runtime_sha256)
    require(native['host_sha256']==request.host_sha256 and native['game_build_sha256']==request.verified_build_sha256
        and structural_witness(data['witness'])==structural_witness(native['witness']), 'D3 native cohort mismatch')
    require(data['scope']==dict(account_binding=native['witness']['account_username_sha256'],
        boss='1436',loadout='DEMON_NORMAL_NONE_PASSIVE_OPERATOR_LIEYUN77'), 'D3 scope mismatch')
    profile=dict(MODEL,account_sha256=native['witness']['account_username_sha256'],player_stats=native['player_stats'])
    require(data['demon_profile']==profile,'D3 user certificate drift')
    qualification=document(directory,data['selector_allowance'])
    q=qualification
    require(q['status']=='PASS' and q['source_sha256']==request.runtime_sha256
        and q['host_sha256']==request.host_sha256 and q['profile_version']==VERSION and q['cycles']>=100
        and q['loss']==0 and q['worker_roundtrip_pass'] and q['controller_byte_exact'], 'D3 own qualification required')
    costs=document(directory,q['raw_costs'])
    require(len(costs)==q['cycles'] and all(type(x) in (int,float) and math.isfinite(x) and x>=0 for x in costs)
        and max(costs)==q['selector_extra_ms'] and max(costs)<=30,'D3 selector allowance invalid')
    activation=document(directory,data['activation_review'])
    require(activation['pilot_protocol']==data['pilot_protocol'] and activation['calibration_sha256']==data['calibration']['sha256']
        and activation['selector_allowance_sha256']==data['selector_allowance']['sha256']
        and activation['component_guard_policy']==GUARD,'D3 activation pins missing')
    if extended:
        from .reasoning_calibration import decode_config
        check_config(decode_config(data['full_config']), protocol=MULTIPLIER20_PROTOCOL)
        verify_multiplier20_extension(directory, data, activation)
    components=dict(controller_tail_ms=native['H_ms'],final_input_ms=native['I_ms'],selector_extra_ms=max(costs),
        command_wait_ms=command_wait_ms(**PARAMETERS),host_guard_ms=250)
    return OperationalPilotAuthority('demon_aegis_farm',policy_json,FrozenJSON.of(data['scope']),FrozenJSON.of(data['witness']),
        FrozenJSON.of(data['model']),request.verified_build_sha256,request.runtime_sha256,request.host_sha256,
        request.contract_sha256,request.decision_sha256,data['calibration']['sha256'],FrozenJSON.of(components),
        FrozenJSON.of(PARAMETERS),100,9,time.perf_counter_ns()+int((data['expires_at']-now)*1e9),
        return_margin_ms=100,budget_ms=data['budget_ms'],root_read_policy=FrozenJSON.of(POLICY),
        component_guard_policy=GUARD,demon_profile=FrozenJSON.of(profile))
