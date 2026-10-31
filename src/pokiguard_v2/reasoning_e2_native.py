"""E2 b12 setup admission from all five native BASIC controls; no game IO."""
import ast
import hashlib
import json
import math
from pathlib import Path
import time

from .reasoning_calibration_review import document, read_ref, PARAMETERS
from .reasoning_demon import MODEL, VERSION, structural_witness
from .reasoning_snapshot import FrozenJSON, canonical_json, digest, require

PROTOCOL = 'E2_B12_DEMON_SHIELD_RELIABILITY20_V1'
SCHEMA = 'pokiguard.reasoning.e2_native_b12.v1'
NATIVE_SOURCE = '782aba5054d9a7da84ca244750a7d3821318e633bacccf47fc2949b2ab306289'
BUILD = '51eaeff77252e7119647a590c534196093b36e752115b500672f24da758f1064'
REQUEST_SHA = '8bcbd5337bdf4a13c5e1196ff62beba38744a510e4b229b79f746b2425ba49a9'
BATCH_ID = 'E2_c71997084df8df511b63770f'
CHANGED = {'src/pokiguard_v2/reasoning_operational.py', 'src/pokiguard_v2/reasoning_operational_launch.py'}
ADDED = {'src/pokiguard_v2/reasoning_e2_native.py', 'tests/test_reasoning_e2_native.py'}


def check_config(config):
    from .input_randomization import InputRandomization
    require(config.play_style.value == 'demon_aegis_farm' and config.game_mode.value == 'solo'
        and config.intelligence.value == 'basic' and not config.ai.shadow_enabled
        and [getattr(config,k).value for k in ('main_pet','evolution','damage_card')]
            == ['normal','none','pet_passive']
        and config.demon_target_gem.value == 'shield'
        and config.pet_skill_fire_condition.value == 'sword_count' and config.pet_skill_fire_value == 4
        and config.normalized_boss_id == '1436'
        and config.target_completed_matches == config.max_match_attempts == 20
        and config.max_technical_recoveries == 1
        and config.input_delivery_mode.value == 'foreground' and config.board_input_mode.value == 'two_click'
        and config.game_window_size_profile.value == 'original_1280x640'
        and config.ai.budget_ms == 4000 and config.input_randomization == InputRandomization(),
        'E2 requires exact b12 Solo Demon Shield4 / normal none passive /20 attempts / original input settings')


def verify_basic3(directory, cal):
    require(cal['schema'] == SCHEMA and cal['request']['sha256'] == REQUEST_SHA,
            'separate E2 current-game calibration required')
    req = document(directory, cal['request'])
    source = document(directory, cal['native_source'])
    session = document(directory, cal['session'])
    claim = document(directory, cal['claim'])
    cp = document(directory, cal['checkpoint'])
    ui = document(directory, cal['final_ui'])
    water = document(directory, cal['watermarks'])
    from .reasoning_calibration import decode_config, check_config, D3_CONTROL_PROTOCOL
    config = decode_config(req['config'])
    check_config(config, 3, profile_protocol=D3_CONTROL_PROTOCOL)
    require(req['source_sha256'] == source['fingerprint'] == digest(source['files']) == NATIVE_SOURCE
        and req['game_build_sha256'] == BUILD and req['reasoning_enabled'] is False
        and req['profile_protocol'] == D3_CONTROL_PROTOCOL
        and req['cohort'] == 'E2_B12_V1210_DEMON_LIEYUN77_BASIC3_WITHIN_BASIC5'
        and req['counts_within_basic5'] is True and req['no_automatic_extension'] is True
        and config.normalized_boss_id == '1436' and config.max_technical_recoveries == 1
        and req['run_id'] == claim['run_id'] == session['run_id'] == water['run_id']
        and req['created_at'] <= claim['claimed_at'] < req['expires_at']
        and req['expires_at']-req['created_at'] <= 7200
        and req['total_attempt_cap'] == session['total_attempt_cap'] == 3
        and session['config_json'] == canonical_json(req['config']), 'E2 native binding mismatch')
    c = ui['controller']
    require(cp['farm_run_id'] == c['farm_run_id'] == session['farm_run_id']
        and cp['match_attempts'] == cp['completed_matches'] == cp['wins'] == 3
        and cp['technical_aborts'] == cp['technical_recoveries'] == cp['losses'] == cp['unknown_results'] == 0
        and cp['finalized_status'] == 'COMPLETED' and cp['stop_reason'] == 'FARM_TARGET_COMPLETED'
        and cp['last_safe_lifecycle'] == ui['lifecycle'] == 'BOSS_LOBBY'
        and cp['continuation_of'] is None and c['active'] is False and c['state'] == 'STOPPED'
        and c['exit_code'] == 0 and c['last_error'] is None
        and c['match_attempts'] == c['completed_matches'] == c['wins'] == 3
        and c['total_gameplay_inputs'] == cp['action_aggregates']['swap_sent']
        and c['total_lobby_inputs'] == c['total_postmatch_inputs'] == 3
        and c['total_recovery_inputs'] == 0 and ui['targetId'] == '1436' and ui['targetLevel'] == 77,
        'E2 all-attempt/final boundary missing')
    require(cp['configured_limits'] == dict(target_completed_matches=3,max_technical_recoveries=1,max_match_attempts=3),
        'preserve observed compatibility-only CLI field; never rewrite the native ledger')
    stats = water['before_close']
    require(water['flushed'] is True and water['closed'] is True
        and water['collector_disabled'] is False and water['collector_dropped'] == 0
        and stats['accounting_valid'] is True and stats['disabled'] is False
        and all(stats[k] == 0 for k in ('dropped_before_enqueue','failed_write','discarded_after_enqueue','queued','in_writer')),
        'E2 durable timing incomplete')
    rows = [json.loads(x) for x in read_ref(directory,cal['records']).decode().splitlines()]
    require(0 < len(rows) <= 432 and [r['event_seq'] for r in rows] == list(range(1,len(rows)+1))
        and stats['eligible'] == stats['enqueued'] == stats['written'] == water['sequence'] == len(rows),
        'E2 timing sequence incomplete')
    sent, ack, terminals, matches, player_stats = [], [], [], [], []
    require(len(cal['combats']) == 3, 'all three BASIC attempts required')
    for ref in cal['combats']:
        combat = [json.loads(x) for x in read_ref(directory,ref).decode().splitlines()]
        summary = next(x for x in reversed(combat) if x['event'] == 'auto_controller_summary')
        t = summary['terminalCombatSnapshot']
        actions = [x['identity'] for x in combat if x['event'] == 'action_sent']
        acknowledged = [x['action']['identity'] for x in combat
            if x['event'] == 'action_result' and x.get('result') == 'SWAP_ACKNOWLEDGED']
        endings = [x for x in combat if x['event'] == 'action_result'
            and x.get('result') == 'ACTION_ABORTED_STATE_CHANGED']
        policies = [x for x in combat if x['event'] == 'policy_decision']
        require(summary['pending'] is None and all(v == 0 for v in summary['safetyTelemetry'].values())
            and summary['counters']['action_response_timeouts'] == 0
            and summary['providerMetrics']['read_errors'] == 0
            and summary['fullCombatResult'] == t['result'] == 'WIN'
            and t['confidence'] == 'STRONG' and t['local_hp'] > 0 and t['boss_hp'] == 0
            and t['captured_before_cleanup'] is True and len(endings) == 1
            and endings[0]['reason'] == 'COMBAT_LIFECYCLE_ENDED'
            and t['turn_number'] == endings[0]['action']['identity']['source']['turn']
            and len(actions) == len(acknowledged)+1 == len(policies)
            and all(x['action'] == 'swap' and x['source']['session']['match_id'] == t['match_id'] for x in actions),
            'E2 pending/safety/terminal or action fault')
        matches.append(t['match_id'])
        sent.extend(actions); ack.extend(acknowledged); terminals.append(endings[0]['action']['identity'])
        player_stats.extend([p['player'][k] for k in ('max_hp','max_mana','max_power','attack')] for p in policies)
    require(len(set(matches)) == 3 and set(matches) == set(cp['seen_match_ids'])
        and len(sent) == len(rows) == cp['action_aggregates']['swap_sent']
        and len(ack) == cp['action_aggregates']['swap_acknowledged']
        and len(terminals) == cp['action_aggregates']['swap_aborted_state_changed']
        and len(sent) == len(ack)+len(terminals)
        and len({canonical_json(x) for x in sent}) == len(sent)
        and {canonical_json(x) for x in ack+terminals} == {canonical_json(x) for x in sent},
        'E2 action accounting mismatch')
    H, I, root, final, witnesses = [], [], [], [], []
    for row, identity in zip(rows,sent):
        p = row['payload']
        times = [p.get(k) for k in ('observed_ns','observation_read_end_ns','decision_exit_ns',
            'fresh_checkpoint_ns','final_checkpoint_ns','preflight_start_ns','read_end_ns','validation_end_ns','executor_return_ns')]
        require(all(type(t) is int and t >= 0 for t in times) and times == sorted(times)
            and row['event_type'] == 'reasoning.swap_timing'
            and row['correlation'] == dict(run_id=req['run_id'],mode='BASIC_CALIBRATION_ONLY')
            and row['input_authority'] is False and p['input_authority'] is False
            and p['autonomous_source'] == identity['source']
            and p['match_id'] == identity['source']['session']['match_id'] and p['turn'] == identity['source']['turn']
            and p['decision_source_hash'] == p['source_hash'] == identity['source']['critical_state_hash']
            and p['status'] == 'RETURNED' and p['preflight_failure'] is None and p['operational_fault'] is None
            and p['required_input_completed'] is True and p['sent_clicks'] == 2 and p['click_status'] == 'SENT'
            and (p['input_mode'],p['board_input_mode']) == ('foreground','two_click')
            and p['input_parameters'] == PARAMETERS and p['clock'] == 'host.perf_counter_ns'
            and p['timer_source'] == 'MatchService.server_tick' and p['native_U_ms'] is None,
            'E2 timing identity/clock/input invalid')
        h = p['preflight_start_ns']-p['decision_exit_ns']
        i = p['executor_return_ns']-p['preflight_start_ns']
        require(h == p['controller_tail_ns'] and i == p['elapsed_upper_bound_ns'] and i > 0
            and h+i == p['full_tail_ns'], 'E2 interval mismatch')
        root.append((p['observation_read_end_ns']-p['observed_ns'])/1e6)
        final.append((p['read_end_ns']-p['preflight_start_ns'])/1e6)
        witnesses.append(p['witness'])
        if identity in ack:
            H.append(h/1e6); I.append(i/1e6)
        else:
            require(identity in terminals,'unproved terminal exclusion')
    require(H and max(root) <= 250 and max(final) <= 100
        and witnesses[0] is not None and all(w == witnesses[0] for w in witnesses)
        and all(s == player_stats[0] for s in player_stats), 'E2 mixed witness/read cohort or no ACK sample')
    return dict(H_ms=max(H),I_ms=max(I),ack_samples=len(ack),terminal_excluded=len(terminals),total_sent=len(sent),
        witness=witnesses[0],player_stats=player_stats[0],root_read_sample_max_ms=max(root),
        final_read_sample_max_ms=max(final),native_source_sha256=NATIVE_SOURCE,
        host_sha256=req['host_sha256'],game_build_sha256=BUILD,sample_max_not_future_bound=True,
        native_U_ms=None,exact_boss_action='UNKNOWN',own_pet='OPERATOR_BINDING_ONLY',
        observed_legacy_cli_recovery_field=1,actual_recoveries=0,
        recovery_field_enforces_limit=False,comparison_requires_observed_zero_recovery=True)


def verify_native(directory, cal):
    """Join timing provenance with every BASIC control, including slots4–5."""
    native = verify_basic3(directory, cal)
    req = document(directory, cal['request'])
    allocation = document(directory, cal['basic5_allocation'])
    require(req['batch_id'] == allocation['batch_id'] == BATCH_ID
        and req['assigned_slots'] == [1,2,3] and req['batch_total_attempt_cap'] == 25
        and allocation['total_attempt_cap'] == 25
        and allocation['planned_basic_attempts'] == 5 and allocation['planned_reasoning_attempts'] == 20
        and allocation['consumed_attempts'] == allocation['completed_matches'] == 5
        and allocation['no_automatic_extension'] is True and allocation['failures_count_towards_cap'] is True,
        'E2 complete five-control allocation required')
    slots = allocation['assignment']
    require(len(slots) == 25 and [s['slot'] for s in slots] == list(range(1,26))
        and all(s['arm'] == 'BASIC' and s['status'] == 'COMPLETED' and s['result'] == 'WIN' for s in slots[:5])
        and all(s['arm'] == 'REASONING' and s['status'] == 'NOT_STARTED' for s in slots[5:]),
        'E2 allocation reset/reassignment or prior REASONING attempt')
    b = cal['basic2']
    spec = document(directory, b['spec'])
    cp = document(directory, b['checkpoint'])
    run = document(directory, b['run'])
    ui = document(directory, b['final_ui'])
    c, s = ui['controller'], run['snapshot']
    require(spec['batch_id'] == BATCH_ID and spec['assigned_slots'] == [4,5]
        and spec['consumed_before'] == 3 and spec['total_cap'] == 25
        and spec['source_sha256'] == NATIVE_SOURCE
        and cp['farm_run_id'] == c['farm_run_id'] == s['farm_run_id'] == 'c23e45f0b58d48b1b5dd5779679679fd'
        and cp['configured_limits'] == dict(target_completed_matches=2,max_technical_recoveries=1,max_match_attempts=2)
        and cp['match_attempts'] == cp['completed_matches'] == cp['wins'] == 2
        and cp['finalized_status'] == 'COMPLETED' and cp['stop_reason'] == 'FARM_TARGET_COMPLETED'
        and cp['continuation_of'] is None and cp['last_safe_lifecycle'] == 'BOSS_LOBBY'
        and ui['targetId'] == '1436' and ui['targetLevel'] == 77 and ui['lifecycle'] == 'BOSS_LOBBY'
        and c['state'] == 'STOPPED' and c['active'] is False and c['exit_code'] == 0 and c['last_error'] is None
        and c['total_lobby_inputs'] == c['total_postmatch_inputs'] == 2
        and run['finalLifecycle'] == 'BOSS_LOBBY' and run['unexpectedError'] is None
        and all(s[k] == 0 for k in ('losses','unknown_results','technical_aborts','technical_recoveries',
            'safe_stops','total_pass_count','total_provider_read_errors','total_provider_dto_rejections','total_recovery_inputs'))
        and all(v == 0 for v in s['safety'].values()) and s['result_accounting_consistent']
        and s['attempt_accounting_consistent'], 'E2 BASIC slots4–5 flow/accounting fault')
    require(cp['gameplay_config'] == document(directory,cal['checkpoint'])['gameplay_config'],
        'E2 control gameplay configuration drift')
    sent, ack, terminal, matches = [], [], [], []
    require(len(b['combats']) == 2, 'all remaining BASIC combats required')
    for ref in b['combats']:
        rows = [json.loads(l) for l in read_ref(directory,ref).decode('utf-8').splitlines()]
        sm = next(r for r in reversed(rows) if r['event'] == 'auto_controller_summary')
        t = sm['terminalCombatSnapshot']
        actions = [r['identity'] for r in rows if r['event'] == 'action_sent']
        acknowledged = [r['action']['identity'] for r in rows if r['event'] == 'action_result' and r.get('result') == 'SWAP_ACKNOWLEDGED']
        endings = [r for r in rows if r['event'] == 'action_result' and r.get('result') == 'ACTION_ABORTED_STATE_CHANGED']
        policies = [r for r in rows if r['event'] == 'policy_decision']
        require(sm['pending'] is None and sm['fullCombatResult'] == t['result'] == 'WIN'
            and t['confidence'] == 'STRONG' and t['local_hp'] > 0 and t['boss_hp'] == 0 and t['captured_before_cleanup']
            and all(v == 0 for v in sm['safetyTelemetry'].values())
            and sm['counters']['action_response_timeouts'] == sm['counters']['too_late'] == 0
            and len(endings) == 1 and endings[0]['reason'] == 'COMBAT_LIFECYCLE_ENDED'
            and endings[0]['action']['identity']['source']['turn'] == t['turn_number']
            and len(actions) == len(policies) == len(acknowledged)+1
            and all(a['action'] == 'swap' and a['source']['session']['match_id'] == t['match_id'] for a in actions)
            and all([p['player'][k] for k in ('max_hp','max_mana','max_power','attack')] == native['player_stats'] for p in policies)
            and all(p['cardDiagnostics']['cards'] == [] for p in policies), 'E2 BASIC2 combat/cohort drift')
        sent.extend(actions); ack.extend(acknowledged); terminal.append(endings[0]['action']['identity'])
        matches.append(t['match_id'])
    require(len(sent) == s['total_swap_sent'] == 4 and len(ack) == s['total_swap_acknowledged'] == 2
        and len(terminal) == s['total_swap_aborted_state_changed'] == 2
        and len({canonical_json(a) for a in sent}) == 4
        and {canonical_json(a) for a in sent} == {canonical_json(a) for a in ack+terminal}
        and len(set(matches)) == 2 and set(matches) == set(cp['seen_match_ids'])
        and set(matches) == {slot['match_id'] for slot in slots[3:5]}
        and set(document(directory,cal['checkpoint'])['seen_match_ids']) == {slot['match_id'] for slot in slots[:3]}
        and len({slot['match_id'] for slot in slots[:5]}) == 5, 'E2 all-five identity accounting fault')
    return dict(native, basic_attempts_consumed=5, basic_wins=5, total_basic_sent=9,
        total_basic_ACK=4, total_basic_terminal=5, batch_id=BATCH_ID)


def verify_boundary(directory, cal, runtime_sha):
    from .reasoning_calibration import source_files
    root = Path(__file__).resolve().parents[2]
    old = document(directory, cal['native_source'])
    current = document(directory, cal['source_manifest'])
    require(old['fingerprint'] == digest(old['files']) == NATIVE_SOURCE
        and current['fingerprint'] == digest(current['files']) == runtime_sha
        and current['files'] == source_files(root), 'E2 source manifests unbound')
    a,b = old['files'],current['files']
    require(set(a) <= set(b) and {p for p in a if a[p] != b[p]} == CHANGED
        and set(b)-set(a) == ADDED and set(cal['before']) == CHANGED,
        'E2 only setup dispatch/admission may differ from native source')
    for name in CHANGED:
        before = read_ref(directory,cal['before'][name])
        require(hashlib.sha256(before).hexdigest() == a[name], 'E2 predecessor bytes changed')
        trees = [ast.parse(raw.decode('utf-8')) for raw in (before,(root/name).read_bytes())]
        for tree in trees:
            if name.endswith('reasoning_operational.py'):
                tree.body = [n for n in tree.body if not isinstance(n,ast.FunctionDef) or n.name != 'load_operational_authority']
            else:
                owner = next(n for n in tree.body if isinstance(n,ast.ClassDef) and n.name == 'OperationalPilotLaunch')
                owner.body = [n for n in owner.body if not isinstance(n,ast.FunctionDef) or n.name != '__init__']
        require(ast.dump(trees[0],include_attributes=False) == ast.dump(trees[1],include_attributes=False),
            'E2 change outside setup-only dispatch')
    return dict(changed=sorted(CHANGED),added=sorted(ADDED),unchanged=len(a)-len(CHANGED),
        gameplay_controller_reader_input_ACK_QTE_worker_logger_byte_exact=True,
        native_source_not_relabelled=True,historical_authorities_unchanged=True)


def load_reviewed_authority(directory, data, cal, request, *, policy_json, now):
    from .reasoning_calibration import decode_config
    from .reasoning_operational import OperationalPilotAuthority, command_wait_ms
    from .reasoning_root_policy import POLICY
    from .reasoning_component_guard import VERSION as GUARD
    check_config(decode_config(data['full_config']))
    require(data['pilot_protocol'] == PROTOCOL and data['total_attempt_cap'] == 20
        and data['batch_id'] == BATCH_ID and data['assigned_slots'] == list(range(6,26))
        and data['basic_attempts_consumed'] == 5 and data['batch_total_attempt_cap'] == 25
        and data['root_read_policy'] == POLICY and data['component_guard_policy'] == GUARD
        and data['component_monitor'] == 'POST_RETURN_COMPONENTS_V1'
        and 'config_projection_policy' not in data, 'E2 independent bounded reliability protocol required')
    native = verify_native(directory,cal)
    verify_boundary(directory,cal,request.runtime_sha256)
    require(native['host_sha256'] == request.host_sha256 and native['game_build_sha256'] == request.verified_build_sha256
        and data['witness'] == native['witness']
        and data['scope'] == dict(account_binding=native['witness']['account_username_sha256'],
            boss='1436',loadout='DEMON_NORMAL_NONE_PASSIVE_OPERATOR_LIEYUN77'), 'E2 native cohort mismatch')
    profile = dict(MODEL,account_sha256=native['witness']['account_username_sha256'],player_stats=native['player_stats'])
    require(data['demon_profile'] == profile, 'E2 Demon certificate drift')
    q = document(directory,data['selector_allowance'])
    costs = document(directory,q['raw_costs'])
    require(q['status'] == 'PASS' and q['source_sha256'] == request.runtime_sha256
        and q['host_sha256'] == request.host_sha256 and q['profile_version'] == VERSION
        and q['cycles'] >= 100 and q['loss'] == 0 and q['worker_roundtrip_pass'] and q['controller_byte_exact']
        and len(costs) == q['cycles'] and all(type(x) in (int,float) and math.isfinite(x) and 0 <= x <= 30 for x in costs)
        and max(costs) == q['selector_extra_ms'], 'E2 final-source selector qualification required')
    activation = document(directory,data['activation_review'])
    require(activation['pilot_protocol'] == PROTOCOL and activation['manual_start_only'] is True
        and activation['batch_id'] == BATCH_ID and activation['assigned_slots'] == list(range(6,26))
        and activation['basic_attempts_consumed'] == 5 and activation['batch_total_attempt_cap'] == 25
        and activation['calibration_sha256'] == data['calibration']['sha256']
        and activation['selector_allowance_sha256'] == data['selector_allowance']['sha256']
        and activation['component_guard_policy'] == GUARD
        and type(activation['operator_authorization']) is str and bool(activation['operator_authorization'].strip()),
        'E2 separate reviewed activation required')
    components = dict(controller_tail_ms=native['H_ms'],final_input_ms=native['I_ms'],
        selector_extra_ms=max(costs),command_wait_ms=command_wait_ms(**PARAMETERS),host_guard_ms=250)
    return OperationalPilotAuthority('demon_aegis_farm',policy_json,FrozenJSON.of(data['scope']),
        FrozenJSON.of(data['witness']),FrozenJSON.of(data['model']),request.verified_build_sha256,
        request.runtime_sha256,request.host_sha256,request.contract_sha256,request.decision_sha256,
        data['calibration']['sha256'],FrozenJSON.of(components),FrozenJSON.of(PARAMETERS),100,native['ack_samples'],
        time.perf_counter_ns()+int((data['expires_at']-now)*1e9),return_margin_ms=100,budget_ms=4000,
        root_read_policy=FrozenJSON.of(POLICY),component_guard_policy=GUARD,demon_profile=FrozenJSON.of(profile))
