"""File-only E1 admission for sealed b10/v1.2.7 BASIC timing.

This is separate from historical D3 and game1.7.4.9 authority. No game IO,
planner rules, collector, controller, pacing, or input changes live here.
"""
import ast
import hashlib
import json
from pathlib import Path
import shutil

from .reasoning_calibration_review import document, read_ref, PARAMETERS
from .reasoning_snapshot import canonical_json, digest, require
from .reasoning_e1_native import reference, RECOVERY_POLICY

SCHEMA = 'pokiguard.reasoning.e1_native_b10.v1'
NATIVE_SOURCE = 'b825f71927cd937f7fa47ff5066214b38fa37f8ace7b86a285f5b667e34db84f'
BUILD = '9bedce81bfdeae1d3f749a5244c0288f1891e658f992eb27c31ee874a9b79777'
REQUEST_SHA = 'de78ce1d497f88d62c1d90cd6f2351f90ecf97030ed5bee6b5e51487414a13b1'
CHANGED = {'src/pokiguard_v2/reasoning_comparison.py',
           'tools/prepare_e1_comparison.py', 'tests/game_update_fixture.py',
           'tests/test_reasoning_comparison.py'}
ADDED = {'src/pokiguard_v2/reasoning_e1_b10_native.py', 'tests/test_reasoning_e1_b10.py'}


def copy_native(out, completion):
    root = Path(__file__).resolve().parents[2]
    require(completion.is_relative_to(root) and out.is_relative_to(root), 'V2 evidence required')
    target = out/'native'
    shutil.copytree(completion/'native', target)
    cal = dict(schema=SCHEMA)
    for key, name in [('request','request.json'), ('claim','claim.json'), ('session','session.json'),
                      ('checkpoint','checkpoint.json'), ('final_ui','final_ui.json'),
                      ('watermarks','watermarks.json'), ('records','records.jsonl'),
                      ('events','events.jsonl'), ('native_source','native_source.json')]:
        cal[key] = reference(out, target/name)
    cal['combats'] = [reference(out,p) for p in sorted(target.glob('combat_*.jsonl'))]
    cal['before'] = {}
    for name in sorted(CHANGED):
        saved=out/'before'/name
        saved.parent.mkdir(parents=True,exist_ok=True)
        shutil.copyfile(completion/'before'/name,saved)
        cal['before'][name]=reference(out,saved)
    return cal


def verify_native(directory, cal):
    require(cal['schema'] == SCHEMA and cal['request']['sha256'] == REQUEST_SHA,
            'separate E1 current-game calibration required')
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
        and req['cohort'] == 'E1_B10_V127_DEMON_LIEYUN77_BASIC3_TIMING_REQUALIFICATION'
        and req['outside_comparison_holdout'] is True and req['no_automatic_extension'] is True
        and config.normalized_boss_id == '1436' and config.max_technical_recoveries == 0
        and req['run_id'] == claim['run_id'] == session['run_id'] == water['run_id']
        and req['created_at'] <= claim['claimed_at'] < req['expires_at']
        and req['expires_at']-req['created_at'] <= 7200
        and req['total_attempt_cap'] == session['total_attempt_cap'] == 3
        and session['config_json'] == canonical_json(req['config']), 'E1 native binding mismatch')
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
        'E1 all-attempt/final boundary missing')
    require(cp['configured_limits'] == dict(target_completed_matches=3,max_technical_recoveries=1,max_match_attempts=3),
        'preserve observed compatibility-only CLI field; never rewrite the native ledger')
    stats = water['before_close']
    require(water['flushed'] is True and water['closed'] is True
        and water['collector_disabled'] is False and water['collector_dropped'] == 0
        and stats['accounting_valid'] is True and stats['disabled'] is False
        and all(stats[k] == 0 for k in ('dropped_before_enqueue','failed_write','discarded_after_enqueue','queued','in_writer')),
        'E1 durable timing incomplete')
    rows = [json.loads(x) for x in read_ref(directory,cal['records']).decode().splitlines()]
    require(0 < len(rows) <= 432 and [r['event_seq'] for r in rows] == list(range(1,len(rows)+1))
        and stats['eligible'] == stats['enqueued'] == stats['written'] == water['sequence'] == len(rows),
        'E1 timing sequence incomplete')
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
            'E1 pending/safety/terminal or action fault')
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
        'E1 action accounting mismatch')
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
            'E1 timing identity/clock/input invalid')
        h = p['preflight_start_ns']-p['decision_exit_ns']
        i = p['executor_return_ns']-p['preflight_start_ns']
        require(h == p['controller_tail_ns'] and i == p['elapsed_upper_bound_ns'] and i > 0
            and h+i == p['full_tail_ns'], 'E1 interval mismatch')
        root.append((p['observation_read_end_ns']-p['observed_ns'])/1e6)
        final.append((p['read_end_ns']-p['preflight_start_ns'])/1e6)
        witnesses.append(p['witness'])
        if identity in ack:
            H.append(h/1e6); I.append(i/1e6)
        else:
            require(identity in terminals,'unproved terminal exclusion')
    require(H and max(root) <= 250 and max(final) <= 100
        and witnesses[0] is not None and all(w == witnesses[0] for w in witnesses)
        and all(s == player_stats[0] for s in player_stats), 'E1 mixed witness/read cohort or no ACK sample')
    return dict(H_ms=max(H),I_ms=max(I),ack_samples=len(ack),terminal_excluded=len(terminals),total_sent=len(sent),
        witness=witnesses[0],player_stats=player_stats[0],root_read_sample_max_ms=max(root),
        final_read_sample_max_ms=max(final),native_source_sha256=NATIVE_SOURCE,
        host_sha256=req['host_sha256'],game_build_sha256=BUILD,sample_max_not_future_bound=True,
        native_U_ms=None,exact_boss_action='UNKNOWN',own_pet='OPERATOR_BINDING_ONLY',
        observed_legacy_cli_recovery_field=1,actual_recoveries=0,
        recovery_field_enforces_limit=False,comparison_requires_observed_zero_recovery=True)


def verify_boundary(directory, cal, runtime_sha):
    """Admit setup-only changes relative to actual current-build native source."""
    from .reasoning_calibration import source_files
    root=Path(__file__).resolve().parents[2]
    old=document(directory,cal['native_source'])
    current=document(directory,cal['source_manifest'])
    require(old['fingerprint']==digest(old['files'])==NATIVE_SOURCE
        and current['fingerprint']==digest(current['files'])==runtime_sha
        and source_files(root)==current['files'], 'b10 source manifests unbound')
    a,b=old['files'],current['files']
    require(set(a)<=set(b) and {p for p in a if a[p]!=b[p]}==CHANGED
        and set(b)-set(a)==ADDED and set(cal['before'])==CHANGED,
        'unreviewed b10 E1 successor')
    for name in CHANGED:
        before=read_ref(directory,cal['before'][name])
        require(hashlib.sha256(before).hexdigest()==a[name], 'b10 predecessor bytes changed')
        if name.startswith('tests/'):
            continue
        trees=[ast.parse(value.decode('utf-8')) for value in (before,(root/name).read_bytes())]
        if name.startswith('src/'):
            allowed={'load_reviewed_authority'}
        else:
            allowed={'prepare'}
        for tree in trees:
            tree.body=[node for node in tree.body if not isinstance(node,ast.FunctionDef) or node.name not in allowed]
        require(ast.dump(trees[0],include_attributes=False)==ast.dump(trees[1],include_attributes=False),
            'b10 changed code outside E1 setup admission')
    return dict(changed=sorted(CHANGED),added=sorted(ADDED),unchanged=len(a)-len(CHANGED),
        native_source_not_relabelled=True,original_game1749_and_D3_authority_untouched=True,
        basic_solver_demon_planner_reader_collector_input_ack_qte_farm_stop_byte_exact=True,
        effective_sword_basic_is_the_control=True,
        recovery_exclusion='OBSERVED_LOG_AND_OPERATOR_STOP_NOT_LEGACY_CONFIG_FIELD')
