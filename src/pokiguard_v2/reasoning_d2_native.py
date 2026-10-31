"""D2 setup-only native/cost review. No game handles, readers or input."""
import ast
import hashlib
import json
import math
import time
from pathlib import Path

from .reasoning_calibration_review import document, read_ref, PARAMETERS
from .reasoning_snapshot import FrozenJSON, canonical_json, digest, require
from .reasoning_full_actions import VERSION, PROTOCOL

SCHEMA = 'pokiguard.reasoning.current_native_d2.v1'


def check_config(config):
    if config.normalized_boss_id=='1170':
        from .reasoning_d2_targeted import check_config as check_targeted_config
        return check_targeted_config(config)
    require(config.play_style.value=='skill_rush' and config.intelligence.value=='basic'
        and config.game_mode.value=='solo' and config.ai.shadow_enabled is False
        and [getattr(config,k).value for k in ('main_pet','evolution','damage_card')]==['legendary','none','pet_skill']
        and config.audition_mode.value=='audition_v3' and config.pet_skill_fire_condition.value=='sword_count'
        and config.pet_skill_fire_value==7 and config.normalized_boss_id=='1289'
        and config.max_match_attempts in (1,3)
        and config.target_completed_matches==config.max_match_attempts
        and config.input_delivery_mode.value=='foreground' and config.board_input_mode.value=='two_click',
        'D2 requires the frozen HT7/Starburst73/7effectiveSword/SOLO/BASIC cohort and matching1or3attempt limits')


def check_remaining_attempt(directory,data):
    """One unstarted slot from the closed cap10 batch; no new attempt budget."""
    if data['total_attempt_cap']==3:
        return
    require(data['total_attempt_cap']==1,'unsupported D2 attempt cap')
    review=document(directory,data['remaining_attempt_review'])
    ledger=document(directory,review['ledger'])
    closure=document(directory,review['closure'])
    require(review['scope']=='REMAINING_ONE_OF_AUTHORIZED_TEN'
        and ledger['combined_authorized_cap']==10 and ledger['combined_started']==9
        and ledger['remaining_authorized_attempts']==1
        and ledger['request_consumed'] is True
        and closure['farm_run_id']=='a9d656b75dd34da1bdeb3fdaf53a513c'
        and closure['attempts']==2 and closure['completed']==1 and closure['not_started']==1
        and closure['status']=='BATCH_STOPPED_NATIVE_POLICY_GUARD_CONFLICT_REMEDIATION_REQUIRED',
        'one remaining D2 attempt is not proven by the closed batch ledger')


def strip_d2_controller(tree):
    """Remove only five optional selector blocks and one late-swap guard.

    None contains a native read/capture/executor; exact AST equality after
    removal proves the prior controller order, including every existing QTE call.
    """
    class Strip(ast.NodeTransformer):
        blocks=0
        late=0
        def visit_If(self,node):
            text=ast.unparse(node)
            test=ast.unparse(node.test)
            direct_publish=any(isinstance(x,ast.ImportFrom) and
                x.module=='pokiguard_v2.reasoning_full_actions' for x in node.body)
            marker=any(isinstance(x,ast.Constant) and x.value in
                ('reasoning_pass_veto','reasoning_family_veto','reasoning_skill_veto') for x in ast.walk(node))
            skill_final=(len(node.body)==2 and isinstance(node.body[0],ast.Assign)
                and [ast.unparse(t) for t in node.body[0].targets]==['failure'])
            remove=(direct_publish and test=='selection_adapter is not None') or (
                (direct_publish or (marker and skill_final)) and test=='selection_receipt is not None') or (
                marker and test=="getattr(selection_adapter.pilot_authority, 'action_profile', None) is not None")
            if remove:
                calls=[x for x in ast.walk(node) if isinstance(x,ast.Call)]
                allowed={'publish_context_safely','_current_skill_rush_match_context','revalidate_safely',
                    'time.perf_counter_ns','_write','_cancel_unsent','getattr',
                    '_must_pause_for_no_safe_move'}
                require(all(ast.unparse(x.func) in allowed for x in calls),'new selector block owns IO')
                require(not node.orelse,'new selector block has unexpected alternate flow')
                self.blocks+=1
                return None
            if isinstance(node.test,ast.BoolOp) and isinstance(node.test.op,ast.And):
                extra=[x for x in node.test.values if ast.unparse(x)==
                    "getattr(selection_adapter.pilot_authority, 'action_profile', None) is None"]
                if extra:
                    require(len(extra)==1 and 'late_selection' in text,'unknown changed legacy condition')
                    node.test.values.remove(extra[0]);self.late+=1
            return self.generic_visit(node)
    strip=Strip();reduced=strip.visit(tree)
    require((strip.blocks,strip.late)==(5,1),'D2 controller boundary changed')
    return reduced


def controller_boundary(before_path,current_path):
    old=ast.parse(Path(before_path).read_text(encoding='utf-8-sig'))
    new=ast.parse(Path(current_path).read_text(encoding='utf-8-sig'))
    require(ast.dump(old)==ast.dump(strip_d2_controller(new)),'legacy controller AST/order changed')
    return dict(legacy_ast_exact=True,optional_blocks=5,late_family_guard=1,
        no_new_provider_read_or_capture=True,QTE_call_exact=True)


def verify_native(directory, cal):
    """Revalidate every native attempt/row; closures alone are not authority."""
    require(cal['schema']==SCHEMA and len(cal['batches'])==2,'D2 control+separate probe required')
    H=[];I=[];spans=[];witnesses=[];total=0;skills=0;root_reads=[];hosts=[];builds=[]
    for index,batch in enumerate(cal['batches']):
        req=document(directory,batch['request']);session=document(directory,batch['session'])
        run=document(directory,batch['run']);water=document(directory,batch['watermarks'])
        native_source=document(directory,batch['source_manifest'])
        rows=[json.loads(line) for line in read_ref(directory,batch['records']).decode().splitlines()]
        cap=(3,1)[index]
        require(req['profile_protocol']==('D2_SKILL_RUSH_BASIC_CONTROL_V1','D2_SKILL_RUSH_SKILL_TIMING_PROBE_V1')[index],
            'native batch protocol changed')
        hosts.append(req['host_sha256']);builds.append(req['game_build_sha256'])
        require(req['reasoning_enabled'] is False and req['config']['intelligence']=='basic'
            and req['config']['ai']['shadow_enabled'] is False and req['config']['pet_skill_fire_value']==7
            and req['total_attempt_cap']==session['total_attempt_cap']==cap
            and req['run_id']==session['run_id']==water['run_id']
            and req['source_sha256']==native_source['fingerprint']
            and digest(native_source['files'])==native_source['fingerprint'], 'native request/source origin changed')
        snapshot=run['snapshot'];total+=snapshot['match_attempts']
        require(snapshot['farm_run_id']==session['farm_run_id']
            and snapshot['match_attempts']==snapshot['completed_matches']==cap
            and snapshot['technical_aborts']==snapshot['technical_recoveries']==0
            and all(v==0 for v in snapshot['safety'].values())
            and run['finalLifecycle']=='BOSS_LOBBY' and snapshot['stop_reason']=='FARM_TARGET_COMPLETED'
            and run['unexpectedError'] is None,'native all-attempt flow not clean')
        stats=water['before_close']
        require(water['flushed'] and water['closed'] and not water['collector_disabled']
            and water['collector_dropped']==0 and stats['accounting_valid'] and not stats['disabled']
            and stats['written']==stats['enqueued']==water['sequence']==len(rows)
            and all(stats[k]==0 for k in ('dropped_before_enqueue','failed_write','discarded_after_enqueue','queued','in_writer')),
            'native timing not durable/complete')
        require([r['event_seq'] for r in rows]==list(range(1,len(rows)+1)),'native timing sequence lost')
        combats=[json.loads(line) for ref in batch['combats'] for line in read_ref(directory,ref).decode().splitlines()]
        sent=[r['identity'] for r in combats if r['event']=='action_sent']
        ack=[r['action']['identity'] for r in combats if r['event']=='action_terminal' and r['result']=='SWAP_ACKNOWLEDGED']
        swaps=[r['payload'] for r in rows if r['event_type']=='reasoning.swap_timing']
        require(len(sent)==len(ack)==len(swaps)==snapshot['total_swap_sent']==snapshot['total_swap_acknowledged']
            and sent==ack,'native swap/ACK/timing incomplete')
        for identity,p in zip(sent,swaps):
            require(identity['source']==p['autonomous_source'] and p['status']=='RETURNED'
                and p['required_input_completed'] and p['sent_clicks']==2 and p['operational_fault'] is None
                and p['decision_source_hash']==p['source_hash']==identity['source']['critical_state_hash']
                and p['clock']=='host.perf_counter_ns'
                and p['observed_ns']<=p['observation_read_end_ns']<=p['decision_exit_ns']<=p['preflight_start_ns']<=p['executor_return_ns'],
                'native swap interval/source invalid')
            h=p['preflight_start_ns']-p['decision_exit_ns'];i=p['executor_return_ns']-p['preflight_start_ns']
            require(h==p['controller_tail_ns'] and i==p['elapsed_upper_bound_ns'],'native swap durations differ')
            H.append(h/1e6);I.append(i/1e6);witnesses.append(p['witness'])
            root_reads.append((p['observation_read_end_ns']-p['observed_ns'])/1e6)
        dispatches=[r for r in combats if r['event']=='pet_skill_dispatch_result']
        skill_logs=[[json.loads(line) for line in read_ref(directory,ref).decode().splitlines()]
            for ref in batch['pet_skills']]
        skills+=len(dispatches)
        require(len(dispatches)==len(skill_logs)==cap,'native successful skill coverage missing')
        for d in dispatches:
            result=d['result'];direction=result['telemetry']['direction_summary']
            require(result['kind']=='SUCCESS_PERFECT' and result['card_clicks']==result['space_presses']==1
                and direction['directions_sent']==direction['directions_confirmed']==7
                and all(direction[k]==0 for k in ('wrong_directions','skipped_directions','duplicate_directions',
                    'stale_directions','unconfirmed_directions','blind_retries')), 'native QTE not clean')
            matching=[log for log in skill_logs if any(r['event']=='observer_stopped'
                and r.get('runtimeHookSummary',{}).get('action_id')==result['action_id'] for r in log)]
            require(len(matching)==1,'native skill primitive log/action not bound')
            caps=[r['capability'] for r in matching[0] if r['event']=='pet_skill_capability_observed']
            require(any(c['status']=='CURRENT' and c['ownership_current'] and c['pet_id']==2035
                and c['source_pet_skill_card_id']==c['skill_card_id']==7
                and c['session_key']==d['identity']['source']['session']
                and c['skill_family']=='AUTOMATIC_DOT_DESTRUCTION'
                and c['effective_mana_cost_source']=='CONDITION_USE' and c['effective_power_cost_source']=='POWER'
                and type(c['effective_mana_cost']) is int and c['effective_mana_cost']>0
                and type(c['effective_power_cost']) is int and c['effective_power_cost']>0
                and c['cooldown_turns']==0 and c['live_card_actionable'] is True for c in caps),
                'native actual HT7 capability/pet/cost ownership missing')
        for row in rows:
            require(row['event_type'] in ('reasoning.swap_timing','reasoning.decision_timing','reasoning.skill_timing'),
                'unknown native timing row')
            if row['event_type']!='reasoning.skill_timing':continue
            p=row['payload'];d,=[d for d in dispatches if d['identity']['source']['turn']==p['turn']]
            s=d['identity']['source']
            require(p['match_id']==s['session']['match_id'] and p['skill_card_id']==d['result']['action_id']['skill_card_id']
                and p['source_hash']==p['decision_source_hash']==s['critical_state_hash']
                and p['clock']=='host.perf_counter_ns' and p['status']=='RETURNED' and p['complete_interval_bound']
                and p['result_kind']=='SUCCESS_PERFECT' and p['card_clicks']==p['space_presses']==1
                and p['decision_exit_ns']<=p['primitive_start_ns']<=p['executor_return_ns']
                and p['first_click_ns'] is None and p['first_click_status']=='NOT_MEASURED', 'native skill span not bound')
            h=p['primitive_start_ns']-p['decision_exit_ns'];i=p['executor_return_ns']-p['primitive_start_ns']
            require(p['controller_tail_ns']==h and p['full_primitive_ns']==i and p['full_tail_ns']==h+i,
                'native skill duration changed')
            H.append(h/1e6);I.append(i/1e6);spans.append(p)
    require(total==skills==4 and len(spans)==1,'native original3 + separate1 required')
    require(len(set(hosts))==len(set(builds))==1,'native host/build changed between batches')
    from .reasoning_full_actions import structural_witness
    normalized=[structural_witness(w) for w in witnesses]
    require(all(w==normalized[0] for w in normalized),'mixed native witnesses')
    require(normalized[0]['loadout']['config']==['legendary','none','pet_skill'],'native loadout differs')
    return dict(H_ms=max(H),I_ms=max(I),swap_samples=len(witnesses),skill_samples=1,
        attempts=4,skills=skills,witness=normalized[0],root_read_max_ms=max(root_reads),
        optional_skill_witness_count=sum(w!=n for w,n in zip(witnesses,normalized)),
        host_sha256=hosts[0],game_build_sha256=builds[0],
        coverage='WHOLE_SKILL_PRIMITIVE_RETURN_NOT_EXACT_FIRST_CLICK',sample_maxima_not_future_bound=True)


def load_reviewed_authority(directory,data,cal,request,*,policy_json,now):
    if cal.get('schema')=='pokiguard.reasoning.d2_darkqueen_targeted.v1':
        from .reasoning_d2_targeted import load_reviewed_authority as load_targeted_authority
        return load_targeted_authority(directory,data,cal,request,policy_json=policy_json,now=now)
    from .reasoning_calibration import source_fingerprint,source_files
    from .reasoning_operational import OperationalPilotAuthority,command_wait_ms
    from .reasoning_root_policy import POLICY
    from .reasoning_operational_launch import operational_policy_json
    from .reasoning_calibration import decode_config
    from .reasoning_component_guard import VERSION as GUARD
    root=Path(__file__).resolve().parents[2]
    config=decode_config(data['full_config']);check_config(config)
    check_remaining_attempt(directory,data)
    require(data['pilot_protocol']==PROTOCOL and data['policy_json']==policy_json==operational_policy_json(config)
        and data['input_parameters']==PARAMETERS and data['root_read_policy']==POLICY
        and data['max_read_span_ms']==100 and data['total_attempt_cap']==config.max_match_attempts
        and data['component_monitor']=='POST_RETURN_COMPONENTS_V1'
        and data['component_guard_policy']==GUARD,'complete D2 protocol required')
    require(source_fingerprint(root)==request.runtime_sha256==cal['runtime_sha256'],'current D2 source changed')
    boundary=document(directory,cal['boundary_review'])
    current=source_files(root);old=document(directory,cal['before_source'])['files']
    origins=[document(directory,b['source_manifest'])['files'] for b in cal['batches']]
    require(old==origins[1],'probe origin is not the pre-integration source')
    for origin in origins:
        for name,sha in origin.items():
            if name.startswith('tests/') or name.startswith('src/pokiguard_v2/reasoning_') or name in (
                    'tools/basic_auto_bot.py','tools/prepare_d2_control.py'):
                continue
            require(old.get(name)==sha,'native core execution bytes changed: '+name)
    changed={k for k in old if current.get(k)!=old[k]}
    require(changed==set(boundary['changed_files']) and current==document(directory,cal['source_manifest'])['files'],
        'source boundary review changed')
    require(all(k.startswith(('src/pokiguard_v2/reasoning_','tests/')) or k=='tools/basic_auto_bot.py'
        for k in changed),'non-reasoning execution file changed')
    before_controller=read_ref(directory,cal['before_controller']).decode('utf-8-sig')
    require(hashlib.sha256(before_controller.encode()).hexdigest()==old['tools/basic_auto_bot.py'], 'before controller changed')
    require(ast.dump(ast.parse(before_controller))==ast.dump(strip_d2_controller(ast.parse((root/'tools/basic_auto_bot.py').read_text(encoding='utf-8')))),
        'controller/QTE flow changed')
    control_raw=read_ref(directory,cal['control_controller'])
    require(hashlib.sha256(control_raw).hexdigest()==origins[0]['tools/basic_auto_bot.py'],
        'original control controller not bound')
    class StripSkillTiming(ast.NodeTransformer):
        count=0
        def visit_If(self,node):
            if len(node.body)==1 and isinstance(node.body[0],ast.Expr) and isinstance(node.body[0].value,ast.Call):
                call=node.body[0].value
                if (isinstance(call.func,ast.Name) and call.func.id=='timing_safely' and len(call.args)>1
                    and isinstance(call.args[1],ast.Constant) and call.args[1].value in ('skill_start','skill_finish')):
                    require(ast.unparse(node.test)=='swap_timing_adapter is not None' and not node.orelse,
                        'unreviewed skill timing branch')
                    self.count+=1;return None
            return self.generic_visit(node)
    strip=StripSkillTiming();old_ast=strip.visit(ast.parse(before_controller))
    require(strip.count==2 and ast.dump(old_ast)==ast.dump(ast.parse(control_raw.decode('utf-8'))),
        'native control-to-probe execution changed beyond two timestamps')
    native=verify_native(directory,cal)
    require(native['host_sha256']==request.host_sha256 and native['game_build_sha256']==request.verified_build_sha256,
        'native calibration host/build differs from current request')
    require(data['witness']==native['witness'],'current witness differs from native')
    q=document(directory,data['selector_allowance'])
    require(q['status']=='PASS' and q['source_sha256']==request.runtime_sha256
        and q['host_sha256']==request.host_sha256 and q['profile_version']==VERSION
        and q['cycles']>=100 and q['loss']==0 and q['worker_roundtrip_pass'] is True
        and q['current_controller_boundary_pass'] is True and q['component_guard_policy']==GUARD,
        'D2 own cost/flow qualification required')
    rows=document(directory,q['raw_costs'])
    require(len(rows)==q['cycles'] and all(type(x) in (int,float) and math.isfinite(x) and x>=0 for x in rows),
        'D2 cost rows invalid')
    allowance=max(rows)
    require(q['selector_extra_ms']==allowance and allowance<=30,'D2 selector allowance invalid/too slow')
    activation=document(directory,data['activation_review'])
    require(activation['pilot_protocol']==PROTOCOL and activation['calibration_sha256']==data['calibration']['sha256']
        and activation['selector_allowance_sha256']==data['selector_allowance']['sha256']
        and activation['component_guard_policy']==GUARD, 'D2 independent activation pins missing')
    components=dict(controller_tail_ms=native['H_ms'],final_input_ms=native['I_ms'],selector_extra_ms=allowance,
        command_wait_ms=command_wait_ms(**PARAMETERS),host_guard_ms=250)
    return OperationalPilotAuthority('skill_rush',policy_json,FrozenJSON.of(data['scope']),FrozenJSON.of(data['witness']),
        FrozenJSON.of(data['model']),request.verified_build_sha256,request.runtime_sha256,request.host_sha256,
        request.contract_sha256,request.decision_sha256,data['calibration']['sha256'],FrozenJSON.of(components),
        FrozenJSON.of(PARAMETERS),100,native['swap_samples']+1,time.perf_counter_ns()+int((data['expires_at']-now)*1e9),
        return_margin_ms=100,budget_ms=data['budget_ms'],root_read_policy=FrozenJSON.of(POLICY),
        action_profile=FrozenJSON.of(data['action_profile']),component_guard_policy=GUARD)
