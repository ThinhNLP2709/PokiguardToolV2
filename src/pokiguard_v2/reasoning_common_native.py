"""File-only admission for the shared chooser; no game reader or executor.

Timing belongs to an input family, not to a selectable AI play style. A native
swap projection can cover the same existing two-click primitive across goals.
Unmeasured skill/PASS families remain with BASIC. Small native samples are
operational projections, never finite server-age or scheduling guarantees.
"""
from dataclasses import dataclass
import hashlib
import math
from pathlib import Path
import time

from .reasoning_snapshot import FrozenJSON,canonical_json,digest,require,strict_json_loads

SCHEMA='pokiguard.common_reasoning.native_swap_projection.v1'
CONTEXT='COMMON_NATIVE_OPERATIONAL_SWAP'
REQUIRED_GATES=frozenset(('disabled_semantic_parity','enabled_transport_order','boundary_input',
    'configured_demon_targets','protected_source','worker_reaped','writer_reaped',
    'legacy_calibration_ast_unchanged','fixture_target_argument_only','source_additions_reviewed',
    'source_frozen','flushed','selector_current_contract_smoke','no_log_loss'))
CONTRACT=digest(dict(engine='common_reasoning.v1',input='EXISTING_OWNER_ONLY',
    fallback='BASIC',model='CONDITIONAL_STRUCTURAL_PROXY',timing='OPERATIONAL_PROJECTION'))


def profile_path(paths):
    return paths.data_root/'preferences/reasoning_acceptance/common.json'


def transport_reason(config):
    from .reasoning_common_problem import PROFILES
    if config.play_style.value not in PROFILES:return 'UI_REASONING_CONFIG_UNSUPPORTED'
    if (config.input_delivery_mode.value!='foreground' or config.board_input_mode.value!='two_click'
            or config.game_window_size_profile.value!='original_1280x640'):
        return 'UI_REASONING_TRANSPORT_UNMEASURED'
    r=config.input_randomization
    if r.reaction_max_seconds>1 or r.inter_click_max_seconds>1.5 or r.coordinate_max_percent>10:
        return 'UI_REASONING_TIMING_CONFIG_UNSUPPORTED'
    return None


def _review_timing_reuse(directory,data,control_source,qualification):
    """Reuse only the reviewed 5188 -> 4da1 change; never relabel raw controls.

    The four gameplay deltas are pinned to their already reviewed bytes. Later
    deltas may only be this setup review and its two file-only preparation tools.
    The authority, reserves, transport checks and native loader AST stay exact.
    """
    if control_source==data['source_sha256']:return
    import ast
    from .reasoning_calibration_review import document,read_ref
    require(control_source=='518805f4840243831f1729d48b0136717c111726ef720dd94794880104735ac8',
        'UI_REASONING_TIMING_SOURCE_UNREVIEWED')
    proof=data.get('timing_reuse',{})
    old=document(directory,proof['control_qualification'])
    reviewed=document(directory,proof['reviewed_source'])
    require(old['source_sha256']==digest(old['source_files'])==control_source
        and old['host_sha256']==data['host_sha256']
        and set(old['gates'])==REQUIRED_GATES and all(v is True for v in old['gates'].values())
        and old['live_attempts']==0 and old['input_authority'] is False
        and reviewed['fingerprint']==digest(reviewed['files'])==
            '4da18e87199703c872ac777a5534e4f52037e8f8c2f75a0abddc5f572c739cb0',
        'UI_REASONING_TIMING_REVIEW_CHANGED')
    def runtime(files):return {n:h for n,h in files.items() if n.startswith(('src/','tools/'))}
    before=runtime(old['source_files']);after=runtime(reviewed['files'])
    expected={
        'src/pokiguard_v2/farm_run.py':'e8dab5b15acf2dd5a5ce059422ea67f871c8ba4b6bb814c52f22a81585a32954',
        'tools/farm_run.py':'ef64e7e3e96d5a495e608ce5150170012dbc42bc969841879c59a32ced7ad0a0',
        'src/pokiguard_v2/reasoning_common_planner.py':'03c2ba24d65b66456f1d4b894a957405ccef7d0a2f6a88336a1017f2abaf16d3',
        'src/pokiguard_v2/room_invite.py':'37412c6d7c0d93cb394ac67248f161c501502184ae47838d13df2e34b496dfe1'}
    changed={n:after.get(n) for n in set(before)|set(after) if before.get(n)!=after.get(n)}
    require(changed==expected,'UI_REASONING_INPUT_PROJECTION_CHANGED')
    current=runtime(qualification['source_files'])
    setup={'src/pokiguard_v2/reasoning_common_native.py',
        'tools/prepare_common_runtime.py','tools/qualify_common_reasoning.py'}
    # Reviewed checkpoint-only atomic replacement retry. No combat reader,
    # selector, input primitive or controller tail code changes in this delta.
    checkpoint='src/pokiguard_v2/farm_checkpoint.py'
    require(current.get(checkpoint) in (after[checkpoint],'069f5a3f7493c11f4c2c75a3e0d9baed8ee0585c6b54e58ee8d9440a9fa29817'),
        'UI_REASONING_INPUT_IMPLEMENTATION_CHANGED')
    # Explicit label-only 1.3.1 successor. All remaining runtime bytes stay pinned.
    version='src/pokiguard_v2/version.py'
    require(current.get(version) in (after[version],'f30182ff58fc14991b8d2310eb4245199b93a7ca44283380fafe9f25629e0cf0'),
        'UI_REASONING_INPUT_IMPLEMENTATION_CHANGED')
    require(set(current)==set(after) and {n for n in after if after[n]!=current[n]}<=setup|{checkpoint,version},
        'UI_REASONING_INPUT_IMPLEMENTATION_CHANGED')
    name='src/pokiguard_v2/reasoning_common_native.py'
    native_before=read_ref(directory,proof['native_before'])
    require(hashlib.sha256(native_before).hexdigest()==before[name],
        'UI_REASONING_NATIVE_BASELINE_CHANGED')
    # review_bundle is setup-only; do not permit changes to the input-family
    # envelope or CommonNativeAuthority while reusing measured input intervals.
    def protected(raw):
        tree=ast.parse(raw)
        tree.body=[n for n in tree.body if not (isinstance(n,ast.FunctionDef)
            and n.name in ('review_bundle','_review_timing_reuse'))]
        return ast.dump(tree,include_attributes=False)
    current_native=Path(__file__).read_bytes()
    require(hashlib.sha256(current_native).hexdigest()==current[name]
        and protected(native_before)==protected(current_native),
        'UI_REASONING_NATIVE_ENVELOPE_CHANGED')


def review_bundle(directory,data):
    """Recompute timing from hash-pinned raw lines, including sent/ACK joins."""
    from .reasoning_calibration_review import document,read_ref,PARAMETERS
    from .reasoning_calibration import (COMMON_DEMON_CONTROL_PROTOCOL,COMMON_MEGA_CONTROL_PROTOCOL,
        COMMON_GALAXY_CONTROL_PROTOCOL,check_config,decode_config)
    require(data['schema']==SCHEMA,'UI_REASONING_PROFILE_SCHEMA')
    export=document(directory,data['control_export'])
    require(export['schema']=='pokiguard.basic_calibration_export.v1' and export['finalized'] is True
        and export['errors']==[] and export['reasoning_authority'] is False,'UI_REASONING_CONTROL_INCOMPLETE')
    mapping=data['archive'];inputs=export['inputs']
    require(type(mapping) is dict and set(mapping)==set(inputs) and 4<=len(mapping)<=128,
        'UI_REASONING_RAW_ARCHIVE_INCOMPLETE')
    raw={};total=0
    for name,ref in mapping.items():
        require(ref['sha256']==inputs[name],'UI_REASONING_RAW_PIN_CHANGED')
        value=read_ref(directory,ref);total+=len(value)
        require(total<=64*1024*1024,'UI_REASONING_RAW_ARCHIVE_TOO_LARGE')
        raw[name]=value
    def role(name):return strict_json_loads(raw[data['roles'][name]].decode('utf-8'))
    request=role('request');binding=role('binding');watermark=role('watermark');run=role('run')['snapshot']
    require(hashlib.sha256(raw[data['roles']['request']]).hexdigest()==export['request_sha256'],
        'UI_REASONING_REQUEST_CHANGED')
    config=decode_config(request['config']);cap=request['total_attempt_cap']
    protocol=request.get('profile_protocol')
    require(protocol in (COMMON_DEMON_CONTROL_PROTOCOL,COMMON_MEGA_CONTROL_PROTOCOL,COMMON_GALAXY_CONTROL_PROTOCOL),
        'UI_REASONING_CONTROL_PROTOCOL')
    check_config(config,cap,profile_protocol=protocol)
    require(request['reasoning_enabled'] is False
        and request['config']['ai'].get('reasoning_enabled',False) is False,'UI_REASONING_CONTROL_PROTOCOL')
    require(export['run_id']==request['run_id']==binding['run_id']==watermark['run_id']
        and binding['farm_run_id']==run['farm_run_id']
        and binding['config_json']==canonical_json(request['config'])
        and binding['total_attempt_cap']==export['total_attempt_cap']==cap
        and run['limits']['max_match_attempts']==cap
        and export['all_attempts']==run['attempts']
        and export['all_attempt_count']==run['match_attempts']==len(run['attempts'])==cap
        and run['completed_matches']==cap and run['technical_aborts']==0
        and run['stop_reason']=='FARM_TARGET_COMPLETED'
        and [a['attempt_index'] for a in run['attempts']]==list(range(1,cap+1)),
        'UI_REASONING_CONTROL_LEDGER_CHANGED')
    require(watermark['flushed'] is True and watermark['closed'] is True
        and watermark['collector_dropped']==0 and watermark['collector_disabled'] is False,
        'UI_REASONING_CONTROL_LOG_LOSS')
    for key in ('before_close','after_close'):
        stats=watermark[key]
        require(stats['accounting_valid'] is True and stats['eligible']==stats['written']
            and all(stats[k]==0 for k in ('dropped_before_enqueue','failed_write',
                'discarded_after_enqueue','queued','in_writer')),'UI_REASONING_CONTROL_LOG_LOSS')
    control_source=data.get('control_source_sha256',data['source_sha256'])
    require(control_source==request['source_sha256']==export['source_sha256'],
        'UI_REASONING_CONTROL_IDENTITY_CHANGED')
    for key in ('game_build_sha256','host_sha256'):
        require(data[key]==request[key]==export[key],'UI_REASONING_CONTROL_IDENTITY_CHANGED')
    require(data['game_executable_sha256']==request['game_executable_sha256'],'UI_REASONING_EXE_CHANGED')
    qualification=document(directory,data['qualification'])
    gates=qualification['gates'];measurements=qualification['measurements']
    require(qualification['source_sha256']==data['source_sha256']
        and digest(qualification['source_files'])==data['source_sha256']
        and qualification['live_attempts']==0 and qualification['input_authority'] is False
        and qualification['host_sha256']==data['host_sha256']
        and set(gates)==REQUIRED_GATES and all(v is True for v in gates.values())
        and len(measurements)>=100,'UI_REASONING_QUALIFICATION_INVALID')
    _review_timing_reuse(directory,data,control_source,qualification)
    for row in measurements:
        require(set(row)==set(('root_ms','fresh_ms','final_ms','triple_ms'))
            and all(type(v) in (int,float) and math.isfinite(v) and v>=0 for v in row.values())
            and abs(row['triple_ms']-sum(row[k] for k in ('root_ms','fresh_ms','final_ms')))<=.001,
            'UI_REASONING_SELECTOR_INTERVAL_INVALID')
    costs=[row['triple_ms'] for row in measurements]
    require(all(type(v) in (int,float) and math.isfinite(v) and 0<=v<=30 for v in costs),
        'UI_REASONING_SELECTOR_TIMING_INVALID')
    def line(ref):
        require(ref['path'] in raw and ref['sha256']==inputs[ref['path']]
            and type(ref['line']) is int and 1<=ref['line']<=100000,'UI_REASONING_RAW_LINE_UNBOUND')
        return strict_json_loads(raw[ref['path']].decode('utf-8').splitlines()[ref['line']-1])
    H=[];I=[];seen=set();mega_witnesses=set()
    for sample in export['samples']:
        event=line(sample);p=event['payload']
        require(event['event_type']=='reasoning.swap_timing' and event['correlation']['run_id']==request['run_id']
            and p==sample['payload'],'UI_REASONING_SAMPLE_CHANGED')
        if not sample['eligible_for_descriptive_R']:continue
        if protocol in (COMMON_MEGA_CONTROL_PROTOCOL,COMMON_GALAXY_CONTROL_PROTOCOL):
            from .reasoning_mega_control import mega_swap_witness_key
            mega_witnesses.add(mega_swap_witness_key(p.get('witness'),config))
        key=(sample['path'],sample['line']);require(key not in seen,'UI_REASONING_DUPLICATE_SAMPLE');seen.add(key)
        times=[p.get(k) for k in ('observed_ns','observation_read_end_ns','decision_exit_ns',
            'preflight_start_ns','read_end_ns','validation_end_ns','executor_return_ns')]
        require(all(type(v) is int and v>=0 for v in times) and times==sorted(times)
            and times[-1]>times[3] and times[1]-times[0]<=100_000_000 and times[4]-times[3]<=100_000_000
            and p['elapsed_upper_bound_ns']==times[-1]-times[3]
            and p['controller_tail_ns']==times[3]-times[2]
            and p['full_tail_ns']==times[-1]-times[2], 'UI_REASONING_NATIVE_INTERVAL_INVALID')
        require(p['status']=='RETURNED' and p['required_input_completed'] is True and p['sent_clicks']==2
            and p['click_status']=='SENT' and p['preflight_failure'] is None
            and p['input_mode']=='foreground' and p['board_input_mode']=='two_click'
            and p['timer_source']=='MatchService.server_tick' and p['input_parameters']==PARAMETERS,
            'UI_REASONING_NATIVE_INPUT_INVALID')
        require(len(sample['sent'])==len(sample['ack'])==1,'UI_REASONING_NATIVE_ACK_MISSING')
        sent=line(sample['sent'][0]);ack=line(sample['ack'][0]);source=p['autonomous_source']
        require(type(source) is dict and set(source)==set(('session','srv_seq','board_hash','turn',
            'current_turn_player','critical_state_hash')),'UI_REASONING_NATIVE_SOURCE_INCOMPLETE')
        from .reasoning_operational import _sha
        _sha(source['critical_state_hash']);_sha(source['board_hash'])
        session=source['session']
        require(type(session) is dict and set(session)==set(('lifecycle_epoch','board_instance','match_id'))
            and all(type(session[k]) is int and session[k]>0 for k in ('lifecycle_epoch','board_instance'))
            and type(session['match_id']) is str and bool(session['match_id'])
            and all(type(source[k]) is int and source[k]>=0 for k in ('srv_seq','turn'))
            and type(source['current_turn_player']) is str and bool(source['current_turn_player'])
            and all(type(p.get(k)) in (int,float) and math.isfinite(p[k]) and p[k]>0
                for k in ('raw_remaining_seconds','remaining')),'UI_REASONING_NATIVE_SOURCE_INVALID')
        require(source is not None and p['decision_source_hash']==p['source_hash']==source['critical_state_hash']
            and sent['event']=='action_sent' and sent['action']=='SWAP'
            and sent['identity']['source']==source and ack['event']=='action_result'
            and ack['result']=='SWAP_ACKNOWLEDGED' and ack['action']['identity']['source']==source,
            'UI_REASONING_NATIVE_ACK_UNBOUND')
        H.append((times[3]-times[2])/1e6);I.append((times[-1]-times[3])/1e6)
    require(len(H)>=1 and max(I)>0,'UI_REASONING_NATIVE_TIMING_MISSING')
    if protocol in (COMMON_MEGA_CONTROL_PROTOCOL,COMMON_GALAXY_CONTROL_PROTOCOL):
        require(len(mega_witnesses)==1,'UI_REASONING_MIXED_MEGA_SWAP_WITNESS')
    return dict(controller_tail_ms=max(H),final_input_ms=max(I),selector_extra_ms=max(costs)),len(H)


@dataclass(frozen=True)
class CommonNativeAuthority:
    policy_json:str
    reserve_components:FrozenJSON
    runtime_sha256:str
    game_build_sha256:str
    host_sha256:str
    calibration_sha256:str
    valid_until_ns:int
    budget_ms:int
    calibration_samples:int
    minimum_ms:float=1000
    input_parameters:FrozenJSON=FrozenJSON.of(dict(cursor_settle_seconds=.06,mouse_button_hold_seconds=.075))
    max_read_span_ms:int=100
    root_read_policy:object=None
    config_projection_policy:object=None
    component_guard_policy:str='SHARED_HOST_GUARD_V1'
    contract_sha256:str=CONTRACT
    decision_sha256:str=CONTRACT

    def __post_init__(self):
        from .reasoning_operational import _sha,command_wait_ms,COMPONENTS
        from .reasoning_component_guard import VERSION
        for value in (self.runtime_sha256,self.game_build_sha256,self.host_sha256,self.calibration_sha256):_sha(value)
        c=self.reserve_components.plain()
        require(set(c)==COMPONENTS and all(type(v) in (int,float) and math.isfinite(v) and v>=0 for v in c.values())
            and c['final_input_ms']>0 and c['host_guard_ms']>=250
            and c['command_wait_ms']==command_wait_ms(**self.input_parameters.plain()),'invalid common native reserve')
        require(type(self.calibration_samples) is int and 1<=self.calibration_samples<=512
            and type(self.valid_until_ns) is int and self.valid_until_ns>0
            and type(self.budget_ms) is int and 50<=self.budget_ms<=6000
            and type(self.minimum_ms) in (int,float) and math.isfinite(self.minimum_ms) and self.minimum_ms>=1000
            and self.max_read_span_ms==100 and self.component_guard_policy==VERSION
            and self.root_read_policy is None and self.config_projection_policy is None,'invalid common native context')
        require(canonical_json(strict_json_loads(self.policy_json))==self.policy_json,'canonical common policy required')

    @property
    def reserve_ms(self):return max(self.minimum_ms,sum(self.reserve_components.plain().values()))
    @property
    def identity(self):return digest(dict(policy=self.policy_json,components=self.reserve_components.plain(),
        runtime=self.runtime_sha256,build=self.game_build_sha256,host=self.host_sha256,
        calibration=self.calibration_sha256,expiry=self.valid_until_ns,budget=self.budget_ms,
        minimum_ms=self.minimum_ms,parameters=self.input_parameters.plain(),read_cap=self.max_read_span_ms,
        guard=self.component_guard_policy,samples=self.calibration_samples))

    def matches(self,state,config):
        from .reasoning_common_evidence import policy_json
        return (time.perf_counter_ns()<self.valid_until_ns and policy_json(config)==self.policy_json
            and state.battle.turn_timer_source=='MatchService.server_tick')


def load_common_authority(config,*,paths,game_executable):
    """Called only at run setup. No implicit install, launch, or old-proof upgrade."""
    from .reasoning_ui_profile import runtime_source_identity
    from .reasoning_operational import host_fingerprint,command_wait_ms
    from .reasoning_calibration_review import PARAMETERS
    from .reasoning_operational_launch import operational_policy_json
    from .reasoning_component_guard import VERSION
    from .game_location import validate_supported_game_assembly
    require(config.ai.reasoning_enabled and not config.ai.shadow_enabled,'UI_REASONING_DISABLED')
    require(transport_reason(config) is None,'UI_REASONING_TRANSPORT_UNMEASURED')
    require(config.game_mode.value=='solo','UI_REASONING_TEAM_MODEL_PENDING')
    path=profile_path(paths)
    require(path.is_file() and path.stat().st_size<=512*1024,'UI_REASONING_COMMON_CALIBRATION_REQUIRED')
    data=strict_json_loads(path.read_text('utf-8'))
    source,files,package=runtime_source_identity(paths)
    # A source calibration never silently becomes packaged-binary acceptance.
    require(package is None,'UI_REASONING_COMMON_PACKAGE_PENDING')
    require(data['source_sha256']==source and data['host_sha256']==host_fingerprint(),
        'UI_REASONING_COMMON_DEPLOYMENT_CHANGED')
    exe=Path(game_executable).resolve()
    require(data['game_executable_sha256']==hashlib.sha256(exe.read_bytes()).hexdigest()
        and data['game_build_sha256']==validate_supported_game_assembly(exe.parent/'GameAssembly.dll'),
        'UI_REASONING_GAME_CHANGED')
    components,n=review_bundle(path.parent,data)
    components.update(command_wait_ms=command_wait_ms(**PARAMETERS),host_guard_ms=250)
    require(type(data['max_attempts']) is int and 1<=config.max_match_attempts<=data['max_attempts']<=10000,
        'UI_REASONING_COMMON_ATTEMPT_CAP')
    return CommonNativeAuthority(operational_policy_json(config),FrozenJSON.of(components),source,
        data['game_build_sha256'],data['host_sha256'],digest(data),
        time.perf_counter_ns()+24*60*60*1_000_000_000,config.ai.budget_ms,n,
        minimum_ms=max(1000,strict_json_loads(operational_policy_json(config))['minimum_turn_time_seconds']*1000),component_guard_policy=VERSION)
