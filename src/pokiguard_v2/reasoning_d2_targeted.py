"""Setup-only DarkQueen/HT7 targeted review. No reader, worker or input owner."""
import ast
import hashlib
import json
import math
from pathlib import Path
import time

from .reasoning_calibration_review import document, read_ref, PARAMETERS
from .reasoning_snapshot import canonical_json, digest, FrozenJSON, require

SCHEMA = 'pokiguard.reasoning.d2_darkqueen_targeted.v1'
NATIVE_SOURCE = '635d6e4c0a3fb5fd210a859cdab926a2ef9a38a4e72419b7a146487abdab781e'
NATIVE_FARM = 'cdd797131ecb4f2dad761d44eed74794'
NATIVE_MATCH = 'M_a6165d21'
CHANGED = {'src/pokiguard_v2/reasoning_d2_native.py'}
ADDED = {'src/pokiguard_v2/reasoning_d2_targeted.py',
    'tools/prepare_d2_targeted.py', 'tests/test_reasoning_d2_targeted.py'}


def check_config(config):
    require(config.play_style.value=='skill_rush' and config.intelligence.value=='basic'
        and config.game_mode.value=='solo' and config.ai.shadow_enabled is False
        and [getattr(config,k).value for k in ('main_pet','evolution','damage_card')]==['legendary','none','pet_skill']
        and config.audition_mode.value=='audition_v3' and config.pet_skill_fire_condition.value=='sword_count'
        and config.pet_skill_fire_value==7 and config.normalized_boss_id=='1170'
        and config.target_completed_matches==config.max_match_attempts==2
        and config.input_delivery_mode.value=='foreground' and config.board_input_mode.value=='two_click',
        'targeted D2 requires DarkQueen1170/HT7/7effectiveSword/SOLO/BASIC/2attempts')


def lines(directory, ref):
    return [json.loads(line) for line in read_ref(directory,ref).decode('utf-8').splitlines() if line.strip()]


def verify_native(directory, cal):
    """Account all17 rows; exclude only the proven terminal pending swap span."""
    from dataclasses import replace
    from .reasoning_calibration import decode_config, D2_TIMING_PROTOCOL
    from .reasoning_full_actions import structural_witness
    require(cal['schema']==SCHEMA, 'targeted native schema required')
    b=cal['native'];req=document(directory,b['request']);session=document(directory,b['session'])
    run=document(directory,b['run']);water=document(directory,b['watermarks'])
    origin=document(directory,b['source_manifest']);rows=lines(directory,b['records'])
    config=decode_config(req['config'])
    check_config(replace(config,target_completed_matches=2,max_match_attempts=2))
    require(req['profile_protocol']==D2_TIMING_PROTOCOL and req['reasoning_enabled'] is False
        and req['total_attempt_cap']==session['total_attempt_cap']==config.max_match_attempts==config.target_completed_matches==1
        and req['run_id']==session['run_id']==water['run_id']
        and canonical_json(req['config'])==session['config_json']
        and req['source_sha256']==origin['fingerprint']==digest(origin['files'])==NATIVE_SOURCE,
        'targeted native origin/config changed')
    snap=run['snapshot'];attempts=snap['attempts']
    require(snap['farm_run_id']==session['farm_run_id']==NATIVE_FARM
        and snap['match_attempts']==snap['completed_matches']==snap['wins']==len(attempts)==1
        and attempts[0]['match_id']==NATIVE_MATCH and attempts[0]['normal_postmatch'] is True
        and snap['technical_aborts']==snap['technical_recoveries']==snap['total_pass_count']==0
        and snap['total_provider_read_errors']==snap['total_provider_dto_rejections']==0
        and all(v==0 for v in snap['safety'].values()) and run['stageResult']=='PASS'
        and run['finalLifecycle']=='BOSS_LOBBY' and snap['stop_reason']=='FARM_TARGET_COMPLETED'
        and run['unexpectedError'] is None, 'targeted all-attempt flow not clean')
    stats=water['before_close']
    require(water['flushed'] and water['closed'] and not water['collector_disabled']
        and water['collector_dropped']==0 and stats['accounting_valid'] and not stats['disabled']
        and stats['eligible']==stats['written']==stats['enqueued']==water['sequence']==len(rows)==17
        and all(stats[k]==0 for k in ('dropped_before_enqueue','failed_write','discarded_after_enqueue','queued','in_writer'))
        and [r['event_seq'] for r in rows]==list(range(1,18)), 'targeted native rows not durable/complete')
    require(all(r['correlation']['run_id']==req['run_id'] and r['input_authority'] is False
        and r['event_type'] in ('reasoning.decision_timing','reasoning.swap_timing','reasoning.skill_timing') for r in rows),
        'unbound native timing row')
    combat=lines(directory,b['combat'])
    summary,=[r for r in combat if r['event']=='auto_controller_summary'];c=summary['counters']
    require(summary['pending'] is None and all(v==0 for v in summary['safetyTelemetry'].values())
        and c['pet_skill_same_source_followups']==c['pet_skill_turn_resolution_unconfirmed']==0
        and c['pet_skill_zero_input_failures']==c['pet_skill_after_input_failures']==0
        and c['action_response_timeouts']==c['local_turn_deadline_safe_stops']==0
        and c['action_aborted_due_lifecycle']==c['swap_aborted_due_lifecycle']==c['expired_actions']==1,
        'targeted native ownership/skill/lifecycle differs')
    sent=[r['identity'] for r in combat if r['event']=='action_sent']
    ack=[r['action']['identity'] for r in combat if r['event']=='action_terminal' and r['result']=='SWAP_ACKNOWLEDGED']
    terminal=[r for r in combat if r['event']=='action_terminal' and r['result']=='ACTION_ABORTED_STATE_CHANGED']
    swaps=[r['payload'] for r in rows if r['event_type']=='reasoning.swap_timing']
    require(len(sent)==len(swaps)==snap['total_swap_sent']==c['swap_sent']==13
        and len(ack)==snap['total_swap_acknowledged']==c['swap_acknowledged']==12
        and ack==sent[:-1] and len(terminal)==1 and terminal[0]['action']['identity']==sent[-1]
        and terminal[0]['reason']=='COMBAT_LIFECYCLE_ENDED' and sent[-1]['source']['turn']==31,
        'unaccounted native swap/ACK; no generic missing-ACK exemption')
    final=attempts[0]['terminal_snapshot']
    require(final['session_key']==sent[-1]['source']['session'] and final['match_id']==NATIVE_MATCH
        and final['turn_number']==31 and final['boss_hp']==0 and final['local_hp']>0
        and final['captured_before_cleanup'] is True and attempts[0]['result_consistency']=='CONSISTENT'
        and attempts[0]['terminal_result_confidence']=='STRONG', 'terminal exclusion not proven')
    unsent=[r for r in combat if r['event']=='action_result' and r['result']=='ACTION_ABORTED_STATE_CHANGED' and 'action' not in r]
    decisions=[r['payload'] for r in rows if r['event_type']=='reasoning.decision_timing']
    require(len(unsent)==len(decisions)==1 and decisions[0]['status']=='SUPERSEDED_BEFORE_PREFLIGHT'
        and decisions[0]['decision_source_hash']==unsent[0]['identity']['source']['critical_state_hash']
        and decisions[0]['fresh_checkpoint_ns'] is decisions[0]['final_checkpoint_ns'] is None,
        'pre-input rejected decision not accounted')
    H=[];I=[];roots=[];witnesses=[]
    for index,(identity,p) in enumerate(zip(sent,swaps)):
        require(identity['source']==p['autonomous_source'] and p['status']=='RETURNED'
            and p['required_input_completed'] and p['sent_clicks']==2 and p['operational_fault'] is None
            and p['decision_source_hash']==p['source_hash']==identity['source']['critical_state_hash']
            and p['timer_source']=='MatchService.server_tick' and p['input_parameters']==PARAMETERS
            and p['clock']=='host.perf_counter_ns' and p['input_mode']=='foreground'
            and p['board_input_mode']=='two_click' and p['preflight_failure'] is None
            and p['observed_ns']<=p['observation_read_end_ns']<=p['decision_exit_ns']<=p['preflight_start_ns']<=p['executor_return_ns'],
            'targeted native swap interval/source invalid')
        h=p['preflight_start_ns']-p['decision_exit_ns'];i=p['executor_return_ns']-p['preflight_start_ns']
        require(h==p['controller_tail_ns'] and i==p['elapsed_upper_bound_ns'],'native swap duration changed')
        witnesses.append(structural_witness(p['witness']))
        if index<12:  # The final pending action is accounted, never relabeled ACK.
            H.append(h/1e6);I.append(i/1e6);roots.append((p['observation_read_end_ns']-p['observed_ns'])/1e6)
    require(all(w==witnesses[0] for w in witnesses)
        and witnesses[0]['boss']==[99,395523,485,250,535]
        and witnesses[0]['loadout']['config']==['legendary','none','pet_skill'], 'mixed targeted cohort/witness')
    dispatches=[r for r in combat if r['event']=='pet_skill_dispatch_result']
    skill_rows=[r['payload'] for r in rows if r['event_type']=='reasoning.skill_timing']
    require(len(dispatches)==len(skill_rows)==len(b['pet_skills'])==c['pet_skill_perfect']==3,
        'targeted native skill coverage missing')
    logs=[lines(directory,ref) for ref in b['pet_skills']];chains=[]
    for index,d in enumerate(dispatches):
        result=d['result'];s=d['identity']['source'];turn=s['turn'];direction=result['telemetry']['direction_summary']
        require(result['kind']=='SUCCESS_PERFECT' and result['card_clicks']==result['space_presses']==1
            and direction['directions_sent']==direction['directions_confirmed']==7
            and all(direction[k]==0 for k in ('wrong_directions','skipped_directions','duplicate_directions',
                'stale_directions','unconfirmed_directions','blind_retries'))
            and d['sourceTurnClosed'] and d['sameTurnFallback'] is False and d['blindRetry'] is False,
            'targeted skill/QTE not clean')
        matching=[log for log in logs if any(r['event']=='observer_stopped'
            and r.get('runtimeHookSummary',{}).get('action_id')==result['action_id'] for r in log)]
        require(len(matching)==1,'native skill primitive/action not bound')
        caps=[r['capability'] for r in matching[0] if r['event']=='pet_skill_capability_observed']
        require(any(cap['status']=='CURRENT' and cap['ownership_current'] and cap['pet_id']==2035
            and cap['source_pet_skill_card_id']==cap['skill_card_id']==7 and cap['session_key']==s['session']
            and cap['skill_family']=='AUTOMATIC_DOT_DESTRUCTION' and cap['cooldown_turns']==0
            and cap['live_card_actionable'] is True and cap['effective_mana_cost']==cap['effective_power_cost']==200
            and cap['effective_mana_cost_source']=='CONDITION_USE' and cap['effective_power_cost_source']=='POWER' for cap in caps),
            'actual HT7 source/cost ownership missing')
        p,=[p for p in skill_rows if p['turn']==turn]
        require(p['match_id']==NATIVE_MATCH and p['skill_card_id']==7
            and p['source_hash']==p['decision_source_hash']==s['critical_state_hash']
            and p['clock']=='host.perf_counter_ns' and p['status']=='RETURNED' and p['complete_interval_bound']
            and p['result_kind']=='SUCCESS_PERFECT' and p['card_clicks']==p['space_presses']==1
            and p['first_click_ns'] is None and p['first_click_status']=='NOT_MEASURED'
            and p['input_parameters']==PARAMETERS
            and p['observed_ns']<=p['observation_read_end_ns']<=p['decision_exit_ns']<=p['primitive_start_ns']<=p['executor_return_ns'],
            'targeted native skill span invalid')
        h=p['primitive_start_ns']-p['decision_exit_ns'];i=p['executor_return_ns']-p['primitive_start_ns']
        require(p['controller_tail_ns']==h and p['full_primitive_ns']==i and p['full_tail_ns']==h+i,'native skill duration changed')
        H.append(h/1e6);I.append(i/1e6);roots.append((p['observation_read_end_ns']-p['observed_ns'])/1e6)
        returned,=[r for r in combat if r['event']=='pet_skill_turn_resolved' and r['sourceTurn']==turn and r['kind']=='LOCAL_TURN_RETURNED']
        opponent,=[r for r in combat if r['event']=='pet_skill_turn_resolved' and r['sourceTurn']==turn and r['kind']=='OPPONENT_TURN']
        later,=[a for a in ack if a['source']['turn']==returned['nextTurn'] and a['source']['session']==s['session']]
        policy,=[r for r in combat if r['event']=='policy_decision' and r['turn']==returned['nextTurn']]
        require(turn<opponent['nextTurn']<returned['nextTurn'] and opponent['timestamp']<returned['timestamp']
            and policy['trace']['pet_skill_success_count_current_match']==index+1,
            'HT7 nonterminal continuation/history not proven')
        chains.append(dict(skill_turn=turn,opponent_turn=opponent['nextTurn'],later_ack_turn=later['source']['turn']))
    require(chains==[dict(skill_turn=a,opponent_turn=b,later_ack_turn=c) for a,b,c in ((15,16,17),(19,20,21),(27,28,29))],
        'targeted native continuation population changed')
    return dict(H_ms=max(H),I_ms=max(I),swap_samples=12,skill_samples=3,attempts=1,
        accounted_swap_spans=13,excluded_terminal_swap_spans=1,excluded_unsent_decisions=1,
        native_records=17,continuation_chains=chains,witness=witnesses[0],root_read_max_ms=max(roots),
        host_sha256=req['host_sha256'],game_build_sha256=req['game_build_sha256'],
        coverage='ACKED_SWAPS_AND_WHOLE_EXISTING_HT7_PRIMITIVE_RETURN',sample_maxima_not_future_bound=True)


def verify_source_boundary(directory, cal, root):
    from .reasoning_calibration import source_files, source_fingerprint
    before=document(directory,cal['native']['source_manifest'])
    after=document(directory,cal['source_manifest'])
    old,current=before['files'],source_files(root)
    require(before['fingerprint']==digest(old)==NATIVE_SOURCE
        and after['fingerprint']==digest(after['files'])==source_fingerprint(root)==cal['runtime_sha256']
        and after['files']==current and set(old)<=set(current)
        and set(current)-set(old)==ADDED
        and {name for name in old if current[name]!=old[name]}==CHANGED,
        'targeted review changed native execution or unreviewed sources')
    name='src/pokiguard_v2/reasoning_d2_native.py'
    original=read_ref(directory,cal['before_native_loader'])
    require(hashlib.sha256(original).hexdigest()==old[name], 'native predecessor loader changed')
    expected=[ast.dump(ast.parse(text).body[0]) for text in (
        "if config.normalized_boss_id=='1170':\n from .reasoning_d2_targeted import check_config as check_targeted_config\n return check_targeted_config(config)",
        "if cal.get('schema')=='pokiguard.reasoning.d2_darkqueen_targeted.v1':\n from .reasoning_d2_targeted import load_reviewed_authority as load_targeted_authority\n return load_targeted_authority(directory,data,cal,request,policy_json=policy_json,now=now)")]
    class Strip(ast.NodeTransformer):
        count=0
        def visit_If(self,node):
            if any(isinstance(x,ast.ImportFrom) and x.module=='reasoning_d2_targeted' for x in node.body):
                require(ast.dump(node) in expected, 'targeted setup dispatch changed beyond review')
                self.count+=1
                return None
            return self.generic_visit(node)
    strip=Strip();tree=strip.visit(ast.parse((root/name).read_text(encoding='utf-8-sig')))
    require(strip.count==2 and ast.dump(tree)==ast.dump(ast.parse(original.decode('utf-8-sig'))),
        'legacy D2 setup changed beyond two explicit dispatches')
    return dict(changed=sorted(CHANGED),added=sorted(ADDED),native_execution_files_byte_exact=True,
        legacy_d2_setup_ast_exact=True,source_sha256=after['fingerprint'])


def load_reviewed_authority(directory,data,cal,request,*,policy_json,now):
    from .reasoning_calibration import decode_config
    from .reasoning_operational_launch import operational_policy_json
    from .reasoning_operational import OperationalPilotAuthority,command_wait_ms
    from .reasoning_full_actions import PROTOCOL, VERSION
    from .reasoning_component_guard import VERSION as GUARD
    from .reasoning_root_policy import POLICY
    config=decode_config(data['full_config']);check_config(config)
    require(data['pilot_protocol']==PROTOCOL and data['policy_json']==policy_json==operational_policy_json(config)
        and data['total_attempt_cap']==2 and data['max_read_span_ms']==100
        and data['root_read_policy']==POLICY and data['input_parameters']==PARAMETERS
        and data['host_guard_ms']==250 and data['return_margin_ms']==100
        and data['component_monitor']=='POST_RETURN_COMPONENTS_V1' and data['component_guard_policy']==GUARD,
        'complete targeted D2 protocol required')
    boundary=verify_source_boundary(directory,cal,Path(__file__).resolve().parents[2])
    require(boundary['source_sha256']==request.runtime_sha256, 'targeted current source changed')
    native=verify_native(directory,cal)
    require(native['host_sha256']==request.host_sha256 and native['game_build_sha256']==request.verified_build_sha256
        and native['root_read_max_ms']<=250 and data['witness']==native['witness']
        and data['scope']==dict(account_binding=native['witness']['account_username_sha256'],boss='1170',
            loadout='HT7_2035_CARD7_DARKQUEEN_TARGETED'), 'targeted current cohort/host/build changed')
    review=document(directory,cal['case_review']);ledger=document(directory,review['control_ledger'])
    legacy=document(directory,review['legacy_starburst_ledger'])
    require(review['case_family']=='HT7_NONTERMINAL_CONTINUATION_WITH_FULL_ACTIONS'
        and review['proposed_total_case_cap']==3 and review['basic_attempts_used']==1
        and review['proposed_reasoning_cap']==data['total_attempt_cap']==2
        and ledger['farm_run_id']==NATIVE_FARM and ledger['match_id']==NATIVE_MATCH
        and ledger['authorized_cap']==ledger['started']==ledger['completed']==1
        and ledger['remaining']==0 and ledger['request_consumed'] is True
        and ledger['request']['sha256']==cal['native']['request']['sha256']
        and legacy['combined_authorized_cap']==legacy['combined_started']==10
        and legacy['remaining_authorized_attempts']==0
        and review['legacy_starburst_ledger']['sha256']=='2fb31092d26d013728870495d8dc001fb5cec776afd59272d1ce7eac91babc9d',
        'targeted all-attempt allocation/closed predecessor not proven')
    q=document(directory,data['selector_allowance'])
    costs=document(directory,q['raw_costs'])
    require(q['status']=='PASS' and q['source_sha256']==request.runtime_sha256
        and q['host_sha256']==request.host_sha256 and q['profile_version']==VERSION
        and q['cycles']>=100 and len(costs)==q['cycles'] and q['loss']==0
        and q['worker_roundtrip_pass'] is True and q['current_controller_boundary_pass'] is True
        and q['component_guard_policy']==GUARD
        and all(type(x) in (int,float) and math.isfinite(x) and x>=0 for x in costs)
        and q['selector_extra_ms']==max(costs)<=30, 'targeted own cost/worker/flow qualification missing')
    activation=document(directory,data['activation_review'])
    require(activation['pilot_protocol']==PROTOCOL and activation['calibration_sha256']==data['calibration']['sha256']
        and activation['selector_allowance_sha256']==data['selector_allowance']['sha256']
        and activation['component_guard_policy']==GUARD, 'targeted independent activation pins missing')
    components=dict(controller_tail_ms=native['H_ms'],final_input_ms=native['I_ms'],
        selector_extra_ms=max(costs),command_wait_ms=command_wait_ms(**PARAMETERS),host_guard_ms=250)
    return OperationalPilotAuthority('skill_rush',policy_json,FrozenJSON.of(data['scope']),FrozenJSON.of(data['witness']),
        FrozenJSON.of(data['model']),request.verified_build_sha256,request.runtime_sha256,request.host_sha256,
        request.contract_sha256,request.decision_sha256,data['calibration']['sha256'],FrozenJSON.of(components),
        FrozenJSON.of(PARAMETERS),100,native['swap_samples']+native['skill_samples'],
        time.perf_counter_ns()+int((data['expires_at']-now)*1e9),return_margin_ms=100,
        budget_ms=data['budget_ms'],root_read_policy=FrozenJSON.of(POLICY),
        action_profile=FrozenJSON.of(data['action_profile']),component_guard_policy=GUARD)
