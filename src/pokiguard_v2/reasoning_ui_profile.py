"""Setup-only UI admission from retained native evidence, never game input.

The local profile is a new deployment review, not an old pilot request. Missing
or incompatible evidence disables UI reasoning; it never prevents BASIC farming.
Private calibration stays outside the distributed binary.
"""
from dataclasses import replace
import hashlib
from pathlib import Path
import time

from .reasoning_snapshot import FrozenJSON, digest, require

SCHEMA = 'pokiguard.ui_reasoning.acceptance.v1'
F1_SOURCE = 'f0aeab76e40ffc12fa11692702119d181bc8e869ae44033f7624ec80d1a8018b'
F1_CLOSURE_SHA = '030ab760a7b8f958bab189e80b9ad36635aaf6eaf90b1e5f9033bd6987da49f7'
CONTRACT_SHA = 'f4b60231388ae2b19b3b0399d778f4eea12dca93f1df39868ad22f19801742e0'
DECISION_SHA = '2867597fc8181e10af7c28478b46b4aed33db477707d6d09accf2e1f994e2a33'
UI_DELTA = frozenset(('src/pokiguard_v2/reasoning_settings.py',
    'src/pokiguard_v2/desktop_control_plane.py','src/pokiguard_v2/desktop_farm_controller.py',
    'src/pokiguard_v2/desktop_ui.py','src/pokiguard_v2/reasoning_calibration.py'))
# Reviewed 1.3.0 label-only successor. Other version/test edits cannot silently
# inherit this exception; gameplay modules remain under the original guard.
UI_METADATA_130 = {
    'src/pokiguard_v2/version.py':'ece21c4dbb4217e9f8ea264b9a3b28307bff6c5b8396b22a6370763fc7784d6f',
    'tests/test_desktop_ui_hardening.py':'7e366f1007ba7dc12b3e308f1ad6187cfefc7f1b372210c9bf852343616ba2b1',
    'tests/test_windows_packaging.py':'cb4c6e6189685e434bff2c1a3ccc5375dc7444520eb226f5c7e2e2d3a6622d5c',
}


def verify_ui_source_files(base,files):
    require(set(base)<=set(files),'UI_REASONING_GAMEPLAY_CORE_CHANGED')
    changed={name for name in base if base[name]!=files[name]}
    require(changed<=UI_DELTA|UI_METADATA_130.keys(),'UI_REASONING_GAMEPLAY_CORE_CHANGED')
    require(all(files[name]==UI_METADATA_130[name] for name in changed & UI_METADATA_130.keys()),
        'UI_REASONING_VERSION_METADATA_CHANGED')


def acceptance_path(paths):
    return paths.data_root/'preferences/reasoning_acceptance/acceptance.json'


def runtime_source_identity(paths):
    if paths.frozen:
        from .packaged_reasoning import package_identity
        from .reasoning_snapshot import strict_json_loads
        identity=package_identity(paths)
        manifest=strict_json_loads((paths.package_root/'resources/package_build.json').read_text(encoding='utf-8'))
        return identity['source_sha256'],manifest['source_files'],identity
    from .reasoning_calibration import source_files
    files=source_files(paths.source_root)
    return digest(files),files,None


def load_ui_authority(config, *, paths, game_executable):
    """Bounded file/hash review before farm entry. No memory/capture/native call."""
    from .reasoning_calibration_review import document,PARAMETERS
    from .reasoning_snapshot import strict_json_loads
    from .reasoning_ui_scope import ui_reasoning_scope_reason
    from .reasoning_operational import host_fingerprint,OperationalPilotAuthority,command_wait_ms
    from .reasoning_operational_launch import operational_policy_json
    from .reasoning_e2_native import verify_native
    from .packaged_reasoning import verify_controls
    from .reasoning_demon import MODEL
    from .reasoning_root_policy import POLICY
    from .reasoning_component_guard import VERSION as GUARD
    from .game_location import validate_supported_game_assembly
    require(config.ai.reasoning_enabled,'UI_REASONING_DISABLED')
    require(ui_reasoning_scope_reason(config,require_target=True) is None,'UI_REASONING_CONFIG_UNSUPPORTED')
    path=acceptance_path(paths)
    require(path.is_file() and path.stat().st_size<=512*1024,'UI_REASONING_PROFILE_MISSING')
    raw=path.read_bytes();data=strict_json_loads(raw.decode('utf-8'));directory=path.parent
    require(data['schema']==SCHEMA,'UI_REASONING_PROFILE_SCHEMA')
    require(data['contract_sha256']==CONTRACT_SHA and data['decision_sha256']==DECISION_SHA,
        'UI_REASONING_CONTRACT_CHANGED')
    source,files,package=runtime_source_identity(paths)
    require(data['source_sha256']==source and data['package']==package,'UI_REASONING_DEPLOYMENT_CHANGED')
    base=document(directory,data['base_source'])
    require(base['fingerprint']==digest(base['files'])==F1_SOURCE,'UI_REASONING_BASE_SOURCE_CHANGED')
    verify_ui_source_files(base['files'],files)
    closure=document(directory,data['f1_closure'])
    require(data['f1_closure']['sha256']==F1_CLOSURE_SHA and closure['source_sha256']==F1_SOURCE
        and closure['status']=='CLOSED_PASS_STRONG_SCOPED_TECHNICAL'
        and closure['cap']==closure['attempts']==closure['completed']==closure['wins']==4,
        'UI_REASONING_NATIVE_ACCEPTANCE_MISSING')
    controls=document(directory,data['basic2_review']);native=verify_controls(directory,controls)
    require(controls['source_sha256']==F1_SOURCE and controls['batch_id']==closure['batch_id'],
        'UI_REASONING_NATIVE_CONTROL_CHANGED')
    cal=document(directory,data['native_e2']);older=verify_native(directory,cal)
    require(native['witness']==older['witness'] and native['player_stats']==older['player_stats'],
        'UI_REASONING_CALIBRATION_COHORT_CHANGED')
    require(host_fingerprint()==data['host_sha256']==older['host_sha256'],'UI_REASONING_HOST_CHANGED')
    exe=Path(game_executable).resolve()
    require(hashlib.sha256(exe.read_bytes()).hexdigest()==data['game_executable_sha256']
        and validate_supported_game_assembly(exe.parent/'GameAssembly.dll')==data['game_build_sha256']==older['game_build_sha256'],
        'UI_REASONING_GAME_CHANGED')
    qualification=document(directory,data['qualification']);costs=document(directory,qualification['raw_costs'])
    require(qualification['status']=='PASS' and qualification['source_sha256']==source
        and qualification['host_sha256']==data['host_sha256'] and qualification['worker_roundtrip_pass'] is True
        and qualification['controller_byte_exact'] is True
        and qualification['origin']=='SYNTHETIC_GAME_STATE_REAL_LOCAL_WORKER_NO_NATIVE_INPUT'
        and qualification['loss']==0 and type(qualification['cycles']) is int and qualification['cycles']>=100
        and len(costs)==qualification['cycles']
        and all(type(x) in (int,float) and 0<=x<=30 for x in costs)
        and max(costs)==qualification['selector_extra_ms'],'UI_REASONING_QUALIFICATION_INVALID')
    profile=dict(MODEL,account_sha256=native['witness']['account_username_sha256'],player_stats=native['player_stats'])
    components=dict(controller_tail_ms=max(native['H_ms'] or 0,older['H_ms']),
        final_input_ms=max(native['I_ms'] or 0,older['I_ms']),selector_extra_ms=max(costs),
        command_wait_ms=command_wait_ms(**PARAMETERS),host_guard_ms=250)
    return OperationalPilotAuthority('demon_aegis_farm',operational_policy_json(config),
        FrozenJSON.of(dict(account_binding=profile['account_sha256'],boss='1436',
            loadout='DEMON_NORMAL_NONE_PASSIVE_OPERATOR_LIEYUN77')),
        FrozenJSON.of(native['witness']),FrozenJSON.of(dict(version='5b2.scoped_inputs.v1')),
        data['game_build_sha256'],source,data['host_sha256'],data['contract_sha256'],data['decision_sha256'],
        hashlib.sha256(raw).hexdigest(),FrozenJSON.of(components),FrozenJSON.of(PARAMETERS),100,
        older['ack_samples'],time.perf_counter_ns()+24*60*60*1_000_000_000,
        budget_ms=min(4000,config.ai.budget_ms),root_read_policy=FrozenJSON.of(POLICY),
        component_guard_policy=GUARD,demon_profile=FrozenJSON.of(profile))
