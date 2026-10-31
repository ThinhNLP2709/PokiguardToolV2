"""Explicit F1 lab opt-in for an exact package. Never enables ordinary preferences.

External review/calibration stay in the operator's writable acceptance directory,
never inside the distributed archive. Existing source-only pilot gates stay closed.
"""
from dataclasses import dataclass
import hashlib
import json
from pathlib import Path
import sys
import time

from .reasoning_snapshot import canonical_json,digest,FrozenJSON,require,strict_json_loads
from .board_diagnostics import jsonable

PROTOCOL='F1_B12_DEMON_SHIELD_PACKAGE2_V1'
BASIC_PROTOCOL='F1_B12_BASIC_PACKAGE2_V1'
MANIFEST='pokiguard.package_build.v1'


def file_hash(path):return hashlib.sha256(Path(path).read_bytes()).hexdigest()


def package_identity(paths,executable=None):
    require(paths.frozen,'packaged acceptance requires frozen runtime')
    exe=Path(executable or sys.executable).resolve()
    manifest=paths.package_root/'resources/package_build.json'
    require(exe.parent==paths.install_root and exe.is_file() and manifest.stat().st_size<=256*1024,
        'exact installed package identity required')
    data=strict_json_loads(manifest.read_text(encoding='utf-8'))
    require(data['schema']==MANIFEST and data['source_sha256']==digest(data['source_files']),
        'package source manifest invalid')
    return dict(executable=str(exe),executable_sha256=file_hash(exe),manifest_sha256=file_hash(manifest),
        source_sha256=data['source_sha256'])


@dataclass(frozen=True)
class PackageBinding:
    paths: object
    identity_json: str

    def verify(self,request,root):
        require(Path(root).resolve()==self.paths.data_root,'package claim root changed')
        actual=package_identity(self.paths)
        require(canonical_json(actual)==self.identity_json,'package files changed')
        raw=strict_json_loads(Path(request.path).read_text(encoding='utf-8'))
        require(raw['pilot_protocol']==PROTOCOL and raw['package']==actual
            and raw['runtime_sha256']==actual['source_sha256'],'package request binding changed')


def check_config(config):
    from dataclasses import replace
    from .reasoning_e2_native import check_config as e2
    require(config.max_match_attempts==config.target_completed_matches==2,'F1 session requires exactly2 attempts')
    e2(replace(config,max_match_attempts=20,target_completed_matches=20))


def verify_controls(directory,controls):
    """Read original same-package BASIC2 records; a summary cannot grant R input."""
    from .reasoning_calibration_review import document,read_ref,PARAMETERS
    from .reasoning_calibration import decode_config
    require(controls['schema']=='pokiguard.f1.basic2_review.v1','F1 native BASIC2 schema required')
    refs=controls['native'];run=document(directory,refs['run']);cp=document(directory,refs['checkpoint'])
    session=document(directory,refs['session']);water=document(directory,refs['watermarks'])
    request=document(directory,refs['request']);claim=document(directory,refs['claim'])
    config=decode_config(request['full_config']);check_config(config)
    s=run['snapshot']
    require(request['pilot_protocol']==BASIC_PROTOCOL and request['assigned_slots']==[1,2]
        and request['package']==controls['package'] and request['runtime_sha256']==controls['source_sha256']
        and request['batch_id']==controls['batch_id']
        and request['run_id']==session['run_id']==water['run_id']==claim['run_id']
        and claim['request_sha256']==refs['request']['sha256']
        and session['farm_run_id']==cp['farm_run_id']==s['farm_run_id']
        and cp['match_attempts']==cp['completed_matches']==2
        and cp['gameplay_config']==config.gameplay_config.to_dict()
        and cp['configured_limits']==dict(target_completed_matches=2,max_technical_recoveries=1,max_match_attempts=2)
        and cp['finalized_status']=='COMPLETED' and cp['stop_reason']=='FARM_TARGET_COMPLETED'
        and run['finalLifecycle']=='BOSS_LOBBY' and run['unexpectedError'] is None
        and all(s[k]==0 for k in ('technical_aborts','technical_recoveries','safe_stops','total_pass_count',
            'total_provider_read_errors','total_provider_dto_rejections','total_recovery_inputs'))
        and all(v==0 for v in s['safety'].values()),'F1 BASIC2 exact request/run/safety proof missing')
    require(water['flushed'] and water['closed'] and not water['collector_disabled'] and water['collector_dropped']==0,
        'F1 BASIC2 timing durability required')
    stats=water['before_close']
    require(stats['accounting_valid'] and stats['eligible']==stats['enqueued']==stats['written']
        and all(stats[k]==0 for k in ('dropped_before_enqueue','failed_write','discarded_after_enqueue','queued','in_writer')),
        'F1 BASIC2 diagnostic loss')
    sent=[];ack=[];terminal=[];players=[]
    require(len(refs['combats'])==2,'all F1 BASIC combats required')
    for ref in refs['combats']:
        rows=[json.loads(l) for l in read_ref(directory,ref).decode('utf-8').splitlines()]
        sm=next(r for r in reversed(rows) if r['event']=='auto_controller_summary');t=sm['terminalCombatSnapshot']
        actions=[r['identity'] for r in rows if r['event']=='action_sent']
        acks=[r['action']['identity'] for r in rows if r['event']=='action_result' and r.get('result')=='SWAP_ACKNOWLEDGED']
        endings=[r for r in rows if r['event']=='action_result' and r.get('result')=='ACTION_ABORTED_STATE_CHANGED']
        players.extend([r['player'][k] for k in ('max_hp','max_mana','max_power','attack')] for r in rows if r['event']=='policy_decision')
        require(sm['pending'] is None and all(v==0 for v in sm['safetyTelemetry'].values())
            and sm['counters']['action_response_timeouts']==0 and t['confidence']=='STRONG'
            and t['result'] in ('WIN','LOSS') and t['captured_before_cleanup']
            and len(actions)==len(acks)+len(endings)
            and all(r['reason']=='COMBAT_LIFECYCLE_ENDED' and r['action']['identity']['source']['turn']==t['turn_number'] for r in endings),
            'F1 BASIC action/terminal evidence incomplete')
        sent.extend(actions);ack.extend(acks);terminal.extend(r['action']['identity'] for r in endings)
    rows=[json.loads(l) for l in read_ref(directory,refs['records']).decode('utf-8').splitlines()]
    require(len(rows)==len(sent)==stats['written']==water['sequence']
        and [r['event_seq'] for r in rows]==list(range(1,len(rows)+1)), 'F1 timing/all-action accounting mismatch')
    require(len({canonical_json(a) for a in sent})==len(sent)
        and {canonical_json(a) for a in sent}=={canonical_json(a) for a in ack+terminal},'duplicate/missing F1 native action')
    h=[];i=[];witnesses=[]
    for row,action in zip(rows,sent):
        p=row['payload']
        require(row['event_type']=='reasoning.swap_timing' and p['autonomous_source']==action['source']
            and p['status']=='RETURNED' and p['sent_clicks']==2 and p['required_input_completed']
            and p['preflight_failure'] is None and p['operational_fault'] is None
            and p['input_parameters']==PARAMETERS and p['clock']=='host.perf_counter_ns'
            and p['timer_source']=='MatchService.server_tick' and p['input_mode']=='foreground'
            and p['board_input_mode']=='two_click' and p['native_U_ms'] is None,
            'F1 native timing source invalid')
        ts=[p[k] for k in ('observed_ns','observation_read_end_ns','decision_exit_ns','preflight_start_ns','read_end_ns','validation_end_ns','executor_return_ns')]
        require(all(type(t)is int and t>=0 for t in ts) and ts==sorted(ts)
            and p['controller_tail_ns']==ts[3]-ts[2] and p['elapsed_upper_bound_ns']==ts[-1]-ts[3]
            and (ts[1]-ts[0])/1e6<=250 and (ts[4]-ts[3])/1e6<=100,'F1 timing intervals invalid')
        witnesses.append(p['witness'])
        if action in ack:
            h.append(p['controller_tail_ns']/1e6);i.append(p['elapsed_upper_bound_ns']/1e6)
        else:require(action in terminal,'unproved F1 terminal exclusion')
    require(witnesses and witnesses[0] is not None and all(w==witnesses[0] for w in witnesses)
        and players and all(p==players[0] for p in players),'F1 mixed native cohort')
    return dict(H_ms=max(h) if h else None,I_ms=max(i) if i else None,ACK_samples=len(h),sent=len(sent),
        witness=witnesses[0],player_stats=players[0])


def load_authority(directory,data,cal,request,*,policy_json,now):
    """Setup-only successor review; no source directory is trusted in frozen mode."""
    from .reasoning_calibration_review import document,PARAMETERS
    from .reasoning_calibration import decode_config
    from .reasoning_e2_native import verify_native,NATIVE_SOURCE
    from .reasoning_demon import MODEL
    from .reasoning_operational import OperationalPilotAuthority,command_wait_ms
    from .reasoning_root_policy import POLICY
    from .reasoning_component_guard import VERSION as GUARD
    check_config(decode_config(data['full_config']))
    require(data['pilot_protocol']==PROTOCOL and data['total_attempt_cap']==2
        and data['assigned_slots']==[3,4] and data['basic_attempts_consumed']==2
        and data['batch_total_attempt_cap']==4 and data['component_guard_policy']==GUARD
        and data['root_read_policy']==POLICY and data['component_monitor']=='POST_RETURN_COMPONENTS_V1',
        'F1 independent bounded request required')
    native=verify_native(directory,cal['native_e2'])
    boundary=document(directory,cal['package_boundary'])
    require(boundary['native_source_sha256']==NATIVE_SOURCE
        and boundary['source_sha256']==request.runtime_sha256
        and boundary['core_parity'] is True and boundary['setup_only'] is True
        and boundary['package']==data['package'],'F1 reviewed package boundary missing')
    controls=document(directory,cal['basic2_review'])
    package_timing=verify_controls(directory,controls)
    require(package_timing['witness']==native['witness'] and package_timing['player_stats']==native['player_stats'],
        'F1 package controls differ from calibrated cohort')
    require(controls['package']==data['package'] and controls['assigned_slots']==[1,2]
        and controls['attempts']==controls['completed']==2 and controls['safety_zero'] is True
        and controls['source_sha256']==request.runtime_sha256
        and controls['batch_id']==data['batch_id'] and controls['technical_aborts']==controls['recoveries']==0,
        'same-artifact F1 BASIC2 review required')
    require(native['host_sha256']==request.host_sha256 and native['game_build_sha256']==request.verified_build_sha256
        and native['witness']==data['witness'],'F1 calibrated cohort changed')
    profile=dict(MODEL,account_sha256=native['witness']['account_username_sha256'],player_stats=native['player_stats'])
    require(data['demon_profile']==profile and data['scope']==dict(account_binding=profile['account_sha256'],
        boss='1436',loadout='DEMON_NORMAL_NONE_PASSIVE_OPERATOR_LIEYUN77'),'F1 exact Demon scope required')
    q=document(directory,data['selector_allowance'])
    require(q['source_sha256']==request.runtime_sha256 and q['host_sha256']==request.host_sha256
        and q['status']=='PASS' and q['worker_roundtrip_pass'] and q['loss']==0,
        'F1 final-source qualification required')
    costs=document(directory,q['raw_costs'])
    require(len(costs)==q['cycles'] and q['cycles']>=100 and all(type(x)in(int,float) and 0<=x<=30 for x in costs)
        and max(costs)==q['selector_extra_ms'],'F1 selector allowance invalid')
    activation=document(directory,data['activation_review'])
    require(activation['manual_start_only'] is True and activation['pilot_protocol']==PROTOCOL
        and activation['package']==data['package'] and activation['assigned_slots']==[3,4]
        and activation['batch_id']==data['batch_id'],'F1 package activation review missing')
    # Native E2 maxima stay labelled. Include any larger verified package samples.
    h=max(native['H_ms'],package_timing['H_ms'] or 0)
    i=max(native['I_ms'],package_timing['I_ms'] or 0)
    components=dict(controller_tail_ms=h,final_input_ms=i,selector_extra_ms=max(costs),
        command_wait_ms=command_wait_ms(**PARAMETERS),host_guard_ms=250)
    return OperationalPilotAuthority('demon_aegis_farm',policy_json,FrozenJSON.of(data['scope']),FrozenJSON.of(data['witness']),
        FrozenJSON.of(data['model']),request.verified_build_sha256,request.runtime_sha256,request.host_sha256,
        request.contract_sha256,request.decision_sha256,data['calibration']['sha256'],FrozenJSON.of(components),
        FrozenJSON.of(PARAMETERS),100,native['ack_samples'],time.perf_counter_ns()+int((data['expires_at']-now)*1e9),
        budget_ms=4000,root_read_policy=FrozenJSON.of(POLICY),component_guard_policy=GUARD,demon_profile=FrozenJSON.of(profile))


class PackagedAcceptanceLaunch:
    """One manual Start; exact EXE/source/build/host/config/cap/expiry, local claim."""
    def __init__(self,path,sha256,*,paths,directory,game_executable):
        from .reasoning_calibration import decode_config
        self.paths=paths;self.path=Path(path).resolve();self.directory=Path(directory)
        require(self.path.is_relative_to(paths.data_root) and self.path.stat().st_size<=512*1024,
            'package request must be inside private writable data root')
        require(file_hash(self.path)==sha256,'package request SHA changed')
        self.sha256=sha256;self.data=strict_json_loads(self.path.read_text(encoding='utf-8'))
        self.config=decode_config(self.data['full_config']);check_config(self.config)
        self.config_json=canonical_json(self.data['full_config']);self.game_executable=game_executable
        self.claimed=False;self.delivered=False;self.session=None
        batch=self.data['batch_id']
        require(type(batch)is str and len(batch)==35 and batch.startswith('F1_')
            and all(c in '0123456789abcdef' for c in batch[3:]),'F1 batch identity invalid')
        arm='BASIC' if self.data['pilot_protocol']==BASIC_PROTOCOL else 'REASONING'
        self.claim_path=paths.data_root/'logs/packaged_acceptance_claims'/(batch+'_'+arm+'.json')
        self.verify();require(not self.claim_path.exists(),'package request consumed; no reset/resume')

    def verify(self):
        from .game_location import validate_supported_game_assembly,game_assembly_sha256
        from .reasoning_operational import host_fingerprint,OperationalArtifactRequest,load_operational_authority
        from .reasoning_operational_launch import operational_policy_json
        d=self.data;actual=package_identity(self.paths);now=time.time()
        require(file_hash(self.path)==self.sha256 and d['package']==actual
            and d['runtime_sha256']==actual['source_sha256'] and d['host_sha256']==host_fingerprint(),
            'package/source/host changed')
        require(d['created_at']<=now<d['expires_at'] and 60<=d['expires_at']-d['created_at']<=7200,
            'expired package request')
        require(type(d['run_id'])is str and len(d['run_id'])==32 and all(c in '0123456789abcdef' for c in d['run_id']),
            'package run identity invalid')
        require(d['full_config_sha256']==digest(self.data['full_config']) and d['total_attempt_cap']==2
            and d['batch_total_attempt_cap']==4 and d['manual_start_only'] is True,'package cap/config changed')
        selected=self.game_executable()
        require(selected is not None and Path(selected).resolve()==Path(d['game_executable']).resolve(),
            'selected game executable changed')
        exe=Path(selected)
        require(validate_supported_game_assembly(exe.parent/'GameAssembly.dll')==d['game_build_sha256']
            and game_assembly_sha256(exe)==d['game_executable_sha256'],'game files changed')
        if d['pilot_protocol']==BASIC_PROTOCOL:
            require(d['schema']=='pokiguard.packaged_basic_acceptance.v1'
                and d['assigned_slots']==[1,2] and d['reasoning_enabled'] is False,'F1 BASIC only slots1–2')
            return
        require(d['pilot_protocol']==PROTOCOL,'unsupported packaged acceptance protocol')
        self.request=OperationalArtifactRequest(str(self.path),self.sha256,d['game_build_sha256'],
            d['runtime_sha256'],d['host_sha256'],d['contract_sha256'],d['decision_sha256'],
            d['full_config_sha256'],d['activation_sha256'])
        load_operational_authority(self.request,policy_json=operational_policy_json(self.config))

    def validate_launch(self,config,checkpoint):
        require(not self.claimed and not self.claim_path.exists() and checkpoint is None
            and time.time()<self.data['expires_at'] and canonical_json(jsonable(config))==self.config_json,
            'package session consumed/expired/resumed/config changed')

    def claim(self,config,checkpoint):
        self.validate_launch(config,checkpoint);self.verify()
        self.claim_path.parent.mkdir(parents=True,exist_ok=True)
        with self.claim_path.open('x',encoding='utf-8') as f:
            json.dump(dict(run_id=self.data['run_id'],request_sha256=self.sha256,assigned_slots=self.data['assigned_slots']),f)
        # A setup failure still consumes this arm's Start; never reset a durable claim.
        self.claimed=True
        if self.data['pilot_protocol']==BASIC_PROTOCOL:
            from .reasoning_swap_timing import SwapTimingRequest,SwapTimingSession
            self.session=SwapTimingSession(SwapTimingRequest(self.data['run_id'],self.config_json,2),config=config,directory=self.directory)
        else:
            from .reasoning_operational import OperationalPilotSession
            from .reasoning_operational_launch import operational_policy_json
            binding=PackageBinding(self.paths,canonical_json(self.data['package']))
            self.session=OperationalPilotSession(self.request,root=self.paths.data_root,config=config,
                policy_json=operational_policy_json(config),directory=self.directory,
                game_executable=self.game_executable(),package_binding=binding)

    def __call__(self,config):
        self.validate_delivery(config)
        self.delivered=True
        return self.session

    def validate_delivery(self,config):
        from .board_diagnostics import jsonable
        require(self.claimed and not self.delivered and self.session is not None
            and canonical_json(jsonable(config))==self.config_json,'one matching package Start required')
