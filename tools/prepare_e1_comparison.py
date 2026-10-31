"""File-only E1 draft / separately activated twenty-attempt comparison.

No process discovery, game state read, capture, UI, input or automatic Start.
"""
import argparse
from dataclasses import replace
import hashlib
import json
from pathlib import Path
import random
import shutil
import sys
import time
import uuid

ROOT = Path(__file__).resolve().parents[1]
sys.path[:0] = [str(ROOT), str(ROOT/'src')]
from pokiguard_v2.board_diagnostics import jsonable
from pokiguard_v2.reasoning_calibration import decode_config, source_files, source_fingerprint
from pokiguard_v2.reasoning_calibration_review import PARAMETERS
from pokiguard_v2.reasoning_comparison import PROTOCOL, assignment, check_config, verify_boundary
from pokiguard_v2.reasoning_demon import MODEL
from pokiguard_v2.reasoning_demon_native import verify_native
from pokiguard_v2.reasoning_operational import host_fingerprint
from pokiguard_v2.reasoning_operational_launch import operational_policy_json
from pokiguard_v2.reasoning_root_policy import POLICY
from pokiguard_v2.reasoning_component_guard import VERSION as GUARD
from pokiguard_v2.reasoning_snapshot import digest, require
from tools.prepare_d3_reasoning import copy_native, qualify, ref, write, CONTROL


def prepare(out, predecessor, *, current_native=None):
    out = Path(out).resolve()
    predecessor = Path(predecessor).resolve()
    require(out.is_relative_to(ROOT) and not out.exists() and predecessor.is_relative_to(ROOT),
            'fresh E1 output and predecessor inside V2 required')
    out.mkdir(parents=True)
    if current_native is None:
        cal = copy_native(out)
    else:
        completion = Path(current_native).resolve()
        observed = json.loads((completion/'native/request.json').read_text(encoding='utf-8'))
        if observed.get('cohort') == 'E1_B10_V127_DEMON_LIEYUN77_BASIC3_TIMING_REQUALIFICATION':
            from pokiguard_v2.reasoning_e1_b10_native import copy_native as copy_current
        else:
            from pokiguard_v2.reasoning_e1_native import copy_native as copy_current
        cal = copy_current(out, completion)
    shutil.copyfile(predecessor, out/'e1_predecessor.json')
    cal['e1_predecessor'] = ref(out, out/'e1_predecessor.json')
    write(out/'source_manifest.json', dict(fingerprint=source_fingerprint(ROOT), files=source_files(ROOT)))
    cal['source_manifest'] = ref(out, out/'source_manifest.json')
    if current_native is None:
        native = verify_native(out, cal)
        boundary = verify_boundary(out, cal, source_fingerprint(ROOT))
    else:
        if cal['schema'] == 'pokiguard.reasoning.e1_native_b10.v1':
            from pokiguard_v2.reasoning_e1_b10_native import verify_native as verify_current, verify_boundary as verify_current_boundary
        else:
            from pokiguard_v2.reasoning_e1_native import verify_native as verify_current, verify_boundary as verify_current_boundary
        native = verify_current(out, cal)
        boundary = verify_current_boundary(out, cal, source_fingerprint(ROOT))
    write(out/'calibration.json', cal)
    write(out/'native_review.json', native)
    write(out/'runtime_boundary.json', boundary)
    q = qualify(out/'qualification', **({} if current_native is None else
        dict(controller_manifest=out/'source_manifest.json')))
    q['raw_costs'] = ref(out, out/'qualification/raw_costs.json')
    write(out/'selector_allowance.json', q)
    original = json.loads(((CONTROL/'request.json') if current_native is None else
        out/'native/request.json').read_text(encoding='utf-8'))
    config = replace(decode_config(original['config']), target_completed_matches=20,
                     max_match_attempts=20, max_technical_recoveries=0)
    check_config(config)
    full_config = jsonable(config)
    policy = operational_policy_json(config)
    sequence = [['BASIC', 'REASONING']]*5 + [['REASONING', 'BASIC']]*5
    random.Random(20261019).shuffle(sequence)
    rows = [dict(slot=i*2+j+1, block=i+1, arm=arm)
            for i, block in enumerate(sequence) for j, arm in enumerate(block)]
    run_id = uuid.uuid4().hex
    manifest = dict(schema='pokiguard.e1.comparison_manifest.v1', protocol=PROTOCOL,
        batch_id='E1_LIEYUN77_'+run_id, run_id=run_id, prepared_at=time.time(),
        status='FROZEN_OFFLINE_LIVE_PENDING', live_activated=False,
        source_sha256=source_fingerprint(ROOT), full_config_sha256=digest(full_config), policy_json=policy,
        game_build_sha256=native['game_build_sha256'], host_sha256=host_fingerprint(),
        cohort=dict(profile='demon_aegis_farm', boss_id='1436', boss_level=77,
            pet='Demon Aegis normal', evolution='none', damage_card='pet_passive', sword_setting=4,
            account_sha256=native['witness']['account_username_sha256'],
            player_stats=native['player_stats'], input='foreground/two_click',
            binding='OPERATOR_PET_LABEL_PLUS_NATIVE_STRUCTURAL_WITNESS',
            current_room_and_stats='NOT_OBSERVED_UNTIL_USER_PREPARES_GAME'),
        total_attempt_cap=20, attempts_per_arm=10, assignment_seed=20261019,
        assignment=rows, assignment_unit='WHOLE_MATCH_EXISTING_COMBAT_PREPARE_SEAM',
        failed_entry_abort_included=True, no_automatic_extension=True,
        old_pilots_excluded=True, no_r2_model_or_retuning=True, default_remains='BASIC',
        primary=dict(metric='ACTUAL_ACCOUNT_ENERGY_PER_WIN_R_OVER_B',
                     source='UNKNOWN_NOT_PUBLISHED_IN_ACCEPTED_LOGS',
                     missing_rule='INCONCLUSIVE_NO_PRIMARY_SUBSTITUTION'),
        secondary=['LOCAL_TURN_ENERGY_PROXY_PER_WIN', 'ACTIVE_TIME_PER_WIN',
                   'WIN_THROUGHPUT', 'ALL_ATTEMPT_WIN_ACCOUNTING', 'REASONING_EXPOSURE_AND_FALLBACK'],
        analysis=dict(confidence=.95, bootstrap_resamples=10000, bootstrap_seed=510019,
            inference_unit='DEFENSIBLE_INDEPENDENT_SESSION_CLUSTERS',
            minimum_clusters=10, minimum_wins_per_arm=10,
            between_block_independence='NOT_ASSUMED',
            expected_session_clusters=1, small_sample_verdict='INCONCLUSIVE',
            energy_benefit_upper_ratio=.95, win_difference_lower=-.05,
            throughput_ratio_lower=.95, critical_violation_limit=0,
            unknown_terminals='COUNT_IN_N_AND_REPORT_WORST_BEST_BOUNDS',
            zero_win_ratio='UNDEFINED', degenerate_or_undefined_bootstrap='INCONCLUSIVE'),
        stop_rules=['USER_STOP_OR_ABORT', 'CRITICAL_FLOW_INPUT_OWNERSHIP_OR_ACK_FAULT',
                    'SOURCE_CONFIG_COHORT_DRIFT', 'ESSENTIAL_DIAGNOSTICS_MISSING',
                    'AI_BREAKER_OPEN_EVALUATION_END_AT_NEXT_SAFE_BOUNDARY', 'CAP20_OR_TWO_HOUR_WINDOW'],
        stop_owner='EXISTING_FARM_STOP_AND_OPERATOR;NO_PLANNER_INPUT_AUTHORITY')
    if current_native is not None:
        from pokiguard_v2.reasoning_e1_native import RECOVERY_POLICY
        manifest['recovery_policy'] = RECOVERY_POLICY
    assignment(manifest)
    write(out/'comparison_manifest.json', manifest)
    profile = dict(MODEL, account_sha256=native['witness']['account_username_sha256'],
                   player_stats=native['player_stats'])
    contract = dict(scope='E1_SCOPED_DEMON_BLOCKED_COMPARISON',
        profile=profile, unchanged_controller=True, native_U_ms=None,
        sample_max_not_future_bound=True, actual_account_energy='UNKNOWN',
        reasoning_retention_valid=True, no_override_quota=True,
        baseline_gameplay_unchanged=True, no_extra_read_capture=True,
        assignment_sha256=ref(out, out/'comparison_manifest.json')['sha256'])
    write(out/'contract.json', contract)
    write(out/'decision.json', dict(accepted=True, scope='OFFLINE_IMPLEMENTATION_AND_READINESS_ONLY',
          contract_sha256=ref(out, out/'contract.json')['sha256'], live_authority=False))
    draft = dict(schema='pokiguard.e1.comparison_draft.v1', accepted=False,
        input_authority=False, request_created=False, claim_created=False,
        pilot_protocol=PROTOCOL, full_config=full_config, full_config_sha256=digest(full_config),
        policy_json=policy, runtime_sha256=source_fingerprint(ROOT), host_sha256=host_fingerprint(),
        game_build_sha256=native['game_build_sha256'], game_executable=original['game_executable'],
        game_executable_sha256=original['game_executable_sha256'], witness=native['witness'],
        scope=dict(account_binding=native['witness']['account_username_sha256'], boss='1436',
                   loadout='DEMON_NORMAL_NONE_PASSIVE_OPERATOR_LIEYUN77'),
        model=dict(version='5b2.scoped_inputs.v1'), demon_profile=profile,
        **{k:ref(out, out/name) for k,name in [
            ('comparison_manifest','comparison_manifest.json'), ('calibration','calibration.json'),
            ('selector_allowance','selector_allowance.json'),('contract','contract.json'),('decision','decision.json')]},
        root_read_policy=POLICY, max_read_span_ms=100, component_monitor='POST_RETURN_COMPONENTS_V1',
        component_guard_policy=GUARD, input_parameters=PARAMETERS, host_guard_ms=250,
        return_margin_ms=100, budget_ms=4000, native_U_ms=None, transport_age_ms=None,
        host_unity_alignment_ms=None, total_attempt_cap=20, run_id=run_id)
    draft['contract_sha256'] = draft['contract']['sha256']
    draft['decision_sha256'] = draft['decision']['sha256']
    write(out/'draft.json', draft)
    return dict(status='OFFLINE_READY_LIVE_PENDING', source_sha256=source_fingerprint(ROOT),
                assignment=[r['arm'] for r in rows], request_created=False, claim_created=False,
                native_attach=0, native_inputs=0, automatic_start=False)


def activate(draft_path, authorization):
    path = Path(draft_path).resolve()
    require(path.is_relative_to(ROOT) and type(authorization) is str and authorization.strip(),
            'direct user batch readiness/activation required')
    data = json.loads(path.read_text(encoding='utf-8'))
    require(data['schema'] == 'pokiguard.e1.comparison_draft.v1' and data['accepted'] is False
        and not data['input_authority'] and data['runtime_sha256'] == source_fingerprint(ROOT)
        and not (ROOT/'logs/operational_pilot_claims'/(data['run_id']+'.json')).exists(),
        'E1 draft changed or batch already consumed')
    check_config(decode_config(data['full_config']))
    from pokiguard_v2.reasoning_calibration_review import document
    manifest = document(path.parent, data['comparison_manifest'])
    assignment(manifest)
    require(data['run_id'] == manifest['run_id'], 'E1 batch identity changed; cannot reset cap')
    review = dict(accepted=True, scope='BOUNDED_OPERATIONAL_PILOT', pilot_protocol=PROTOCOL,
        manual_start_only=True, operator_authorization=authorization,
        comparison_sha256=data['comparison_manifest']['sha256'],
        calibration_sha256=data['calibration']['sha256'],
        selector_allowance_sha256=data['selector_allowance']['sha256'], component_guard_policy=GUARD,
        **{k:data[k] for k in ['run_id','total_attempt_cap','full_config_sha256','runtime_sha256',
                              'host_sha256','contract_sha256','decision_sha256']})
    write(path.parent/'activation_review.json', review)
    from pokiguard_v2.reasoning_operational import SCHEMA, ORIGIN
    request = {k:v for k,v in data.items() if k not in
               ('schema','accepted','input_authority','request_created','claim_created')}
    now=time.time()
    request.update(schema=SCHEMA, origin=ORIGIN, activation='EXPLICIT_BOUNDED_PILOT_REQUEST',
        created_at=now, expires_at=now+7200, activation_review=ref(path.parent,path.parent/'activation_review.json'),
        activation_sha256=ref(path.parent,path.parent/'activation_review.json')['sha256'])
    write(path.parent/'request.json', request)
    return dict(request=str(path.parent/'request.json'),
        sha256=hashlib.sha256((path.parent/'request.json').read_bytes()).hexdigest(),
        claim_created=False, automatic_start=False)


def main():
    parser=argparse.ArgumentParser(description=__doc__)
    sub=parser.add_subparsers(dest='mode',required=True)
    p=sub.add_parser('prepare');p.add_argument('--out',type=Path,required=True)
    p.add_argument('--predecessor',type=Path,required=True)
    p.add_argument('--current-native',type=Path,
                   help='sealed E1 game1.7.4.9 BASIC3 completion directory; historical D3 remains unchanged')
    a=sub.add_parser('activate');a.add_argument('--draft',type=Path,required=True)
    a.add_argument('--authorization',required=True)
    args=parser.parse_args()
    result=prepare(args.out,args.predecessor,current_native=args.current_native) if args.mode=='prepare' else activate(args.draft,args.authorization)
    print(json.dumps(result))


if __name__=='__main__':main()
