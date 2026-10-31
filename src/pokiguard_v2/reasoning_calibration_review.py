"""Setup-only review of the sealed P11 cohort. No reader/input/live activation.

Original absolute filenames are opaque identities. Only bounded, hash-pinned
package references are opened. This schema deliberately supports one reviewed
cohort, not arbitrary mixed-witness exports or a replacement finite-U proof.
"""
from copy import deepcopy
import ast
import hashlib
import math
from pathlib import Path, PurePosixPath

from .reasoning_snapshot import canonical_json, digest, require, strict_json_loads

SCHEMA = 'pokiguard.reasoning.operational_calibration_review.v2'
NATIVE_SOURCE = 'bb69e4c5b6d8d027f86047c4752aee4a90cbb5e470e9f8558bc79c221c2d772f'
WITNESS = dict(account_username_sha256='b704ca2b0f1020a6e8fb2d125f99cb515d45c97d96cc43600bd95e5770a64c0e',
    boss=[99, 84180, 445, 250, 325], loadout=dict(config=['normal','normal','default_attack'],
    fusion=[254767,2102], cards=[[64647,4,'ATTACK',0,0,0]]))
PARAMETERS = dict(cursor_settle_seconds=.06, mouse_button_hold_seconds=.075)
CHANGED = {'src/pokiguard_v2/reasoning_operational.py', 'src/pokiguard_v2/reasoning_pilot.py',
    'tests/reasoning_controller_fixture.py', 'tools/qualify_reasoning_operational.py'}
ADDED = {'src/pokiguard_v2/reasoning_calibration_review.py',
    'tools/review_reasoning_calibration.py', 'tests/test_reasoning_calibration_review.py'}
P13_SOURCE = '3fb6430aff31ceac4224b0bdbcb012352b84b6fcbcae68a0d1fb1b6384591fe3'
SUCCESSOR_CHANGED = {'src/pokiguard_v2/reasoning_operational.py',
    'src/pokiguard_v2/reasoning_calibration_review.py', 'tools/desktop_ui.py',
    'tools/review_reasoning_calibration.py', 'tests/reasoning_controller_fixture.py'}
SUCCESSOR_ADDED = {'src/pokiguard_v2/reasoning_operational_launch.py',
    'tools/prepare_operational_pilot.py', 'tests/test_reasoning_operational_launch.py'}
OLD_POLICY_GATE = '''        require(canonical_json(jsonable(basic_policy_config(config))) == policy_json,
                "launch/incumbent policy differs from calibration")'''
NEW_POLICY_GATE = '''        from .reasoning_operational_launch import operational_policy_json
        require(policy_json in (canonical_json(jsonable(basic_policy_config(config))),
                                operational_policy_json(config)),
                "launch/incumbent policy differs from calibration")'''


def read_ref(directory, ref, *, cap=32*1024*1024):
    name = ref['path']
    require(type(name) is str and '\\' not in name and ':' not in name
            and not PurePosixPath(name).is_absolute() and '..' not in PurePosixPath(name).parts,
            'relative package reference required')
    path = (Path(directory)/name).resolve()
    require(path.is_relative_to(Path(directory).resolve()) and path.is_file()
            and path.stat().st_size <= cap, 'bounded package file required')
    raw = path.read_bytes()
    require(hashlib.sha256(raw).hexdigest() == ref['sha256'], 'package SHA changed')
    return raw


def document(directory, ref):
    return strict_json_loads(read_ref(directory, ref).decode('utf-8'))


def source_compatibility(directory, ref, native_sha, target_sha):
    c = document(directory, ref)
    if c.get('schema') == 'pokiguard.reasoning.calibration_source_successor.v1':
        require(c['native_runtime_sha256']==native_sha==NATIVE_SOURCE
                and c['base_runtime_sha256']==P13_SOURCE
                and c['target_runtime_sha256']==target_sha, 'source successor pins changed')
        base=source_compatibility(directory,c['base_compatibility'],native_sha,P13_SOURCE)
        before,after=base['target_files'],c['target_files']
        require(digest(after)==target_sha and set(before)<=set(after)
                and set(after)-set(before)==SUCCESSOR_ADDED, 'unreviewed successor source additions')
        changed={n for n in before if before[n]!=after[n]}
        require(changed==set(c['changed'])==SUCCESSOR_CHANGED, 'unreviewed successor native path')
        for name,pair in c['changed'].items():
            old=read_ref(directory,pair['before']);new=read_ref(directory,pair['after'])
            require(hashlib.sha256(old).hexdigest()==before[name]
                    and hashlib.sha256(new).hexdigest()==after[name], 'successor bytes changed')
            if name=='src/pokiguard_v2/reasoning_operational.py':
                text=old.decode('utf-8')
                require(text.count(OLD_POLICY_GATE)==1
                        and new.decode('utf-8')==text.replace(OLD_POLICY_GATE,NEW_POLICY_GATE),
                        'successor changed runtime beyond setup policy validation')
        # Other five-file successor changes are setup/export/test-only. All
        # reader/combat/solver/input/ACK/timing/selection bytes remain exact.
        return c
    require(c['native_runtime_sha256'] == native_sha == NATIVE_SOURCE
            and c['target_runtime_sha256'] == target_sha, 'distinct source pins required')
    before, after = c['native_files'], c['target_files']
    require(digest(before) == native_sha and digest(after) == target_sha,
            'complete source manifests required')
    require(set(before) <= set(after) and set(after)-set(before) == ADDED,
            'unexpected added/removed source')
    changed = {n for n in before if before[n] != after[n]}
    require(changed == CHANGED and set(c['changed']) == changed, 'unreviewed native path change')
    for name, pair in c['changed'].items():
        old = read_ref(directory, pair['before']); new = read_ref(directory, pair['after'])
        require(hashlib.sha256(old).hexdigest() == before[name]
                and hashlib.sha256(new).hexdigest() == after[name], 'source bytes unbound')
        a, b = ast.parse(old.decode('utf-8')), ast.parse(new.decode('utf-8'))
        if name == 'src/pokiguard_v2/reasoning_operational.py':
            # Only the setup loader changes. Exact equality, authority, deadline,
            # command ceiling, session ownership and runtime methods stay exact.
            for tree in (a,b):
                tree.body = [n for n in tree.body if not
                    isinstance(n, ast.FunctionDef) or n.name != 'load_operational_authority']
        elif name == 'src/pokiguard_v2/reasoning_pilot.py':
            # One reproduced owner invalidation correction, nowhere else.
            prepare = next(n for n in ast.walk(b) if isinstance(n,ast.FunctionDef) and n.name=='_prepare')
            guard = next(n for n in prepare.body if isinstance(n,ast.If))
            require(ast.unparse(guard.body[0]) == 'self.completed = self.active = None',
                    'unexpected owner correction')
            guard.body[0] = ast.parse('self.completed = None').body[0]
        else:
            continue  # Offline test/audit/qualification utilities, no native interval.
        require(ast.dump(a,include_attributes=False) == ast.dump(b,include_attributes=False),
                'native timing dependency changed: '+name)
    return c


def recompute(directory, data):
    """Derive coverage/joins/maxima from raw bytes, never from declared totals."""
    require(data['schema'] == SCHEMA and data['reasoning_authority'] is False
            and data['live_acceptance'] is False, 'review is not activation')
    require(data['native_runtime_sha256'] == NATIVE_SOURCE and data['max_read_span_ms'] == 100
            and data['proposed_scope_witness'] == WITNESS and data['input_parameters'] == PARAMETERS,
            'P11 scoped review required')
    source_compatibility(directory, data['source_compatibility'],
                         data['native_runtime_sha256'], data['target_runtime_sha256'])
    mapping = data['archive_mapping']
    require(type(mapping) is dict and 1 <= len(mapping) <= 64, 'bounded archive mapping required')
    require(len({v['path'] for v in mapping.values()}) == len(mapping), 'archive alias collision')
    # Validate every preserved raw/claim/failure, including non-accepted attempts.
    for ref in mapping.values(): read_ref(directory, ref)
    def doc(role): return document(directory, mapping[data['roles'][role]])
    export = document(directory, data['raw_export'])
    require(export['schema'] == 'pokiguard.basic_calibration_export.v1'
            and export['finalized'] is True and export['errors'] == ['MISSING_OR_MIXED_RUNTIME_WITNESS']
            and export['reasoning_authority'] is False and export['live_acceptance'] is False,
            'original mixed-witness export must be retained')
    for identity, sha in export['inputs'].items():
        require(identity in mapping and mapping[identity]['sha256'] == sha, 'original input mapping changed')
    archive = document(directory, data['native_archive_manifest'])
    require(archive['originals_unchanged'] is True and len(archive['files'])==22,
            'complete native archive manifest required')
    workspace_identity = data['roles']['run'].split('logs\\farm_runs\\')[0]
    for original, item in archive['files'].items():
        require(workspace_identity+original in mapping
                and mapping[workspace_identity+original]['sha256']==item['sha256'],
                'archived success/failure omitted')
    require(len(data['roles']['claims'])==3 and len(data['roles']['failed_runs'])==2,
            'consumed request/failure ledger omitted')
    for identity in data['roles']['claims']:
        require(identity in mapping, 'consumed claim missing')
        claim = document(directory, mapping[identity])
        require(claim['run_id']+'.json' == identity.split('\\')[-1], 'claim identity changed')
    for identity in data['roles']['failed_runs']:
        failure = document(directory, mapping[identity])
        require(failure['snapshot']['match_attempts']==0, 'unexpected prior failure scope')
    request, session, watermarks, run = (doc(k) for k in ('request','session','watermarks','run'))
    require(export['request_sha256'] == mapping[data['roles']['request']]['sha256']
            and export['source_sha256'] == request['source_sha256'] == NATIVE_SOURCE
            and export['host_sha256'] == request['host_sha256'] == data['host_sha256']
            and export['game_build_sha256'] == request['game_build_sha256'] == data['game_build_sha256']
            and export['run_id'] == request['run_id'] == session['run_id'] == watermarks['run_id'],
            'native request/export/session bindings changed')
    config = request['config']
    require(canonical_json(config) == session['config_json'] and request['reasoning_enabled'] is False
            and config['play_style']=='simple' and config['game_mode']=='solo'
            and config['intelligence']=='basic' and config['ai']['shadow_enabled'] is False
            and [config[k] for k in ('main_pet','evolution','damage_card')]==['normal','normal','default_attack']
            and config['input_delivery_mode']=='foreground' and config['board_input_mode']=='two_click'
            and config['boss_id']=='1289', 'native config changed')
    require(request['total_attempt_cap'] == session['total_attempt_cap'] == export['total_attempt_cap'] == 3,
            'native cap changed')
    snapshot = run['snapshot']; attempts = snapshot['attempts']
    require(snapshot['farm_run_id'] == session['farm_run_id'] and snapshot['match_attempts'] == 3
            and attempts == export['all_attempts'] and export['all_attempt_count'] == len(attempts) == 3
            and [a['attempt_index'] for a in attempts] == [1,2,3], 'all-attempt ledger changed')
    require(watermarks['flushed'] is True and watermarks['closed'] is True
            and watermarks['collector_dropped']==0 and watermarks['collector_disabled'] is False,
            'writer not finalized')
    for stage in ('before_close','after_close'):
        stats = watermarks[stage]
        require(stats['accounting_valid'] is True and stats['eligible']==stats['enqueued']==stats['written']==30
                and all(stats[k]==0 for k in ('dropped_before_enqueue','failed_write',
                    'discarded_after_enqueue','queued','in_writer')), 'timing loss')
    roles = data['roles']; require(len(roles['combats']) == len(roles['entries']) == 3, 'attempt provenance missing')
    combats, entries = [], []
    for identity in roles['combats']:
        combats.append([strict_json_loads(l) for l in read_ref(directory,mapping[identity]).decode('utf-8').splitlines()])
    for identity in roles['entries']: entries.append(document(directory,mapping[identity]))
    events = [strict_json_loads(l) for l in read_ref(directory,mapping[roles['records']]).decode('utf-8').splitlines()]
    require(len(events)==watermarks['sequence']==30
            and [r['event_seq'] for r in events]==list(range(1,31)), 'complete ordered raw coverage required')
    classified=[]; intervals=[]; anchors=[]; sources=set(); decisions=set(); samples=[]
    counts=dict(raw_rows=30,attempts=3,opening_deferred=0,full_witness_ack=0,terminal_no_ack=0,superseded_evolve=0)
    for seq,event in enumerate(events,1):
        require(event['correlation']==dict(run_id=request['run_id'],mode='BASIC_CALIBRATION_ONLY')
                and event['input_authority'] is False, 'mixed timing correlation')
        p=event['payload']
        require(p['native_U_ms'] is None and p['input_parameters']==PARAMETERS, 'unknown U/parameters changed')
        if event['event_type']=='reasoning.decision_timing':
            require(p['status']=='SUPERSEDED_BEFORE_PREFLIGHT', 'unexplained decision row')
            key=p['decision_source_hash']; require(key not in decisions, 'duplicate EVOLVE decision')
            matches=[(j,k,r) for j,rows in enumerate(combats) for k,r in enumerate(rows)
                     if r.get('event')=='action_sent' and r.get('action')=='EVOLVE'
                     and r.get('identity',{}).get('source',{}).get('critical_state_hash')==key]
            require(len(matches)==1, 'superseded decision not bound to EVOLVE')
            j,k,sent=matches[0]
            outcomes=[r for r in combats[j][k+1:] if r.get('event')=='action_result'
                and r.get('action',{}).get('identity')==sent['identity']
                and r.get('result') in ('EVOLVE_SUCCESS','EVOLVE_FAILED')]
            require(len(outcomes)==1, 'EVOLVE outcome missing/ambiguous')
            decisions.add(key); kind='superseded_evolve'; evidence=dict(combat=j+1,sent_line=k+1,outcome=outcomes[0]['result'])
        else:
            require(event['event_type']=='reasoning.swap_timing', 'unknown raw row')
            source=p['autonomous_source']; key=canonical_json(source)
            require(key not in sources and p['source_hash']==p['decision_source_hash']==source['critical_state_hash'],
                    'duplicate/stale timing source')
            sources.add(key)
            js=[j for j,a in enumerate(attempts) if source['session']==a['session_key']]
            require(len(js)==1 and p['match_id']==source['session']['match_id'] and p['turn']==source['turn'],
                    'attempt/source mismatch')
            j=js[0]; rows=combats[j]; attempt=attempts[j]
            sent=[(k,r) for k,r in enumerate(rows) if r.get('event')=='action_sent' and r.get('action')=='SWAP'
                  and r.get('identity',{}).get('source')==source]
            results=[(k,r) for k,r in enumerate(rows) if r.get('event')=='action_result'
                     and r.get('action',{}).get('identity',{}).get('source')==source]
            require(len(sent)==len(results)==1 and results[0][0]>sent[0][0]
                    and results[0][1]['action']['identity']==sent[0][1]['identity'], 'native sent/result ambiguous')
            require(p['policy_sha256']==digest(strict_json_loads(data['policy_json']))
                    and p['timer_source']=='MatchService.server_tick' and p['clock']=='host.perf_counter_ns'
                    and p['input_mode']=='foreground' and p['board_input_mode']=='two_click'
                    and p['required_input_completed'] is True and p['status']=='RETURNED'
                    and p['sent_clicks']==sent[0][1]['sentClicks']==2 and p['click_status']=='SENT'
                    and p['preflight_failure'] is None and p['operational_fault'] is None,
                    'incomplete input/cohort')
            require(sent[0][1]['cursorSettleSeconds']==PARAMETERS['cursor_settle_seconds']
                    and sent[0][1]['mouseButtonHoldSeconds']==PARAMETERS['mouse_button_hold_seconds']
                    and sent[0][1]['inputMode']=='two_click'
                    and sent[0][1]['inputDeliveryMode']=='foreground', 'sent input parameters changed')
            times=[p[k] for k in ('observed_ns','observation_read_end_ns','decision_exit_ns',
                    'fresh_checkpoint_ns','final_checkpoint_ns','preflight_start_ns','read_end_ns',
                    'validation_end_ns','executor_return_ns')]
            require(all(type(t) is int and t>=0 for t in times) and times==sorted(times)
                    and times[-1]>times[5], 'incomplete/nonmonotonic interval')
            require((times[1]-times[0])/1e6<=100 and (times[6]-times[5])/1e6<=100, 'read span exceeded')
            h=(times[5]-times[2])/1e6; i=(times[8]-times[5])/1e6; tail=(times[8]-times[2])/1e6
            require(p['controller_tail_ns']==times[5]-times[2] and p['elapsed_upper_bound_ns']==times[8]-times[5]
                    and p['full_tail_ns']==times[8]-times[2] and p['first_input_ns'] is None
                    and p['first_input_status']=='NOT_MEASURED', 'derived timing/first click forged')
            full=p['witness']==WITNESS
            opening=deepcopy(WITNESS); opening['loadout']['cards']=[]
            require(full or p['witness']==opening, 'unexpected witness group')
            outcome=results[0][1]['result']
            if not full:
                entry=entries[j]
                diagnostics=[r for r in rows[:sent[0][0]] if r.get('event')=='provider_status'
                             and r.get('session')==source['session']]
                require(p['turn']==1 and source['srv_seq']==0 and outcome=='SWAP_ACKNOWLEDGED'
                        and entry['status']=='PASS' and entry['session']==source['session']
                        and entry['boardHash']==source['board_hash'] and entry['firstLocalTurn'] is True
                        and entry['localMoveSequence']==0 and entry['preentryCardIdentity']==[[64647,4,'ATTACK']]
                        and any(r['diagnostics'].get('runtimeCardLayoutReason')=='opening_board_action_priority'
                            and r['diagnostics'].get('liveCardIdentity')==[]
                            and r['diagnostics'].get('nativeCardDiscoveryReason')=='session_reset'
                            and r['diagnostics'].get('preentryCardIdentity')==[[64647,4,'ATTACK']]
                            for r in diagnostics), 'unexplained empty-card observation')
                kind='opening_deferred'
            elif outcome=='SWAP_ACKNOWLEDGED':
                kind='full_witness_ack'; anchors.append(seq)
            else:
                terminal=attempt['terminal_snapshot']
                summaries=[r for r in rows if r.get('event')=='auto_controller_summary']
                require(outcome=='ACTION_ABORTED_STATE_CHANGED' and results[0][1]['reason']=='COMBAT_LIFECYCLE_ENDED'
                        and terminal['session_key']==source['session'] and terminal['match_id']==p['match_id']
                        and terminal['turn_number']==source['turn'] and terminal['srv_seq']==source['srv_seq']
                        and terminal['result']==attempt['result']=='WIN' and terminal['confidence']=='STRONG'
                        and terminal['boss_hp']==0 and terminal['captured_before_cleanup'] is True
                        and attempt['normal_postmatch'] is True and len(summaries)==1
                        and summaries[0]['stopReason']=='COMBAT_LIFECYCLE_ENDED'
                        and summaries[0]['terminalCombatSnapshot']==terminal
                        and sent[-1]==[(k,r) for k,r in enumerate(rows) if r.get('event')=='action_sent'
                            and r.get('action')=='SWAP'][-1], 'missing strong matched terminal evidence')
                kind='terminal_no_ack'
            evidence=dict(combat=j+1,sent_line=sent[0][0]+1,result_line=results[0][0]+1,result=outcome)
            intervals.append(dict(event_seq=seq,kind=kind,H_ms=h,I_ms=i,full_tail_ms=tail,
                root_read_span_ms=(times[1]-times[0])/1e6,final_read_span_ms=(times[6]-times[5])/1e6))
            # Check the original v1 export's copies/joins, retaining its rejections.
            sample=export['samples'][len(samples)]
            require(sample['path']==roles['records'] and sample['sha256']==mapping[roles['records']]['sha256']
                    and sample['line']==seq and sample['payload']==p, 'v1 sample/raw disagreement')
            refs=lambda items:[dict(path=roles['combats'][j],sha256=mapping[roles['combats'][j]]['sha256'],line=k+1)
                               for k,r in items]
            require(sample['sent']==refs(sent) and sample['ack']==refs(results if outcome=='SWAP_ACKNOWLEDGED' else []),
                    'v1 provenance join disagreement')
            samples.append(sample)
        counts[kind]+=1; classified.append(dict(event_seq=seq,kind=kind,evidence=evidence))
    require(len(samples)==len(export['samples'])==export['raw_timing_N']==len(intervals)==26 and len(anchors)==20
            and counts==dict(raw_rows=30,attempts=3,opening_deferred=3,full_witness_ack=20,
                            terminal_no_ack=3,superseded_evolve=4), 'P11 exhaustive coverage changed')
    for j,rows in enumerate(combats):
        a=attempts[j]
        for action,field in (('SWAP','swap_sent'),('EVOLVE','evolve_attempts')):
            require(sum(r.get('event')=='action_sent' and r.get('action')==action for r in rows)==a[field],
                    'unaccounted native action')
        require(all(r.get('action') in ('SWAP','EVOLVE') for r in rows if r.get('event')=='action_sent')
                and a['cast_sent']==a['pass_count']==0, 'unexpected input family')
        for result,field in (('SWAP_ACKNOWLEDGED','swap_acknowledged'),
                             ('ACTION_ABORTED_STATE_CHANGED','swap_aborted_state_changed'),
                             ('EVOLVE_SUCCESS','evolve_success'),('EVOLVE_FAILED','evolve_failed')):
            require(sum(r.get('event')=='action_result' and r.get('result')==result for r in rows)==a[field],
                    'outcome ledger changed')
    require(sum(a['swap_sent'] for a in attempts)==26 and sum(a['evolve_attempts'] for a in attempts)==4
            and sum(a['evolve_failed'] for a in attempts)==1, 'native failure/action coverage changed')
    return dict(counts=counts,row_classification=classified,anchor_rows=anchors,
        host_interval_rows=intervals,all_attempts=attempts,original_errors=export['errors'],
        maxima_ms={k:max(r[k] for r in intervals) for k in
                   ('H_ms','I_ms','full_tail_ms','root_read_span_ms','final_read_span_ms')},
        calibration_samples=26,anchor_samples=20,native_U_ms=None,
        transport_age_ms=None,host_unity_alignment_ms=None)


def verify_review(directory, data, *, runtime_sha256, host_sha256, game_build_sha256, policy_json, witness):
    require(data['target_runtime_sha256']==runtime_sha256 and data['host_sha256']==host_sha256
            and data['game_build_sha256']==game_build_sha256 and data['policy_json']==policy_json
            and data['proposed_scope_witness']==witness, 'review/target scope changed')
    result=recompute(directory,data)
    require(data['review']==result, 'declared review differs from raw evidence')
    return result
