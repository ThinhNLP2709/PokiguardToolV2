"""U1 file-only same-board bench, frozen corpus and timing study.

No game process, memory, input, PASS, ACK, recovery or runtime authority. Native
BASIC/R proposals and production-branch replays stay labelled separately. Counts
are the existing solver's known-cascade horizon, never damage, win, net balance
or optimal-action labels. G4 keeps its own schema and is never aliased to a
CommonProblem profile. Observed futures never enter planner inputs.
"""
from collections import Counter, defaultdict
from datetime import datetime, timezone
from pathlib import Path
from types import SimpleNamespace
import argparse
import hashlib
import json
import math
import os
import platform
import sys
import time

ROOT = Path(__file__).resolve().parents[1]
sys.path[:0] = [str(ROOT), str(ROOT / 'src')]
from pokiguard_v2.board_simulator import evaluate_all_moves
from pokiguard_v2.galaxy_shadow_sword import plan_g4, projection
from pokiguard_v2.reasoning_calibration import source_fingerprint
from pokiguard_v2.reasoning_common_capture import EVENT, decode_snapshot_event
from pokiguard_v2.reasoning_common_planner import CommonLimits, plan_common
from pokiguard_v2.reasoning_common_problem import CommonProblem, PROFILES
from pokiguard_v2.reasoning_snapshot import Action, digest, require, strict_json_loads
from pokiguard_v2.state import BoardState, CellState, GemType
from tools.compare_same_state_decisions import classify_pair, project_action

CORPUS = 'pokiguard.opus.u1_corpus.v1'
RESULT = 'pokiguard.opus.u1_bench.v1'
TIMING = 'pokiguard.opus.u1_timing.v1'
HANDOFF = 'docs/phase5/mega_galaxy_handoff_20261124'
SUBSET = 'tests/fixtures/mega_native_reasoning5_20261124/cases.json'
GEMS = ('sword', 'mana', 'rage', 'shield', 'health', 'drain')
LABELS = dict(training_eligible=False, independent_holdout=False, quality_label=None,
    alternative_outcome=None, actual_refill_injected=False, damage_model_fitted=False)
PORTABLE = (
    ('ICARUS', HANDOFF + '/datasets/icarus_native_swaps.json', 'native_pairs'),
    ('ICARUS', HANDOFF + '/datasets/icarus_skill_receipts.json', 'skills'),
    ('TREX', 'tests/fixtures/trex_native_reasoning1_20261124/cases.json', 'native_pairs'),
    ('G1', 'tests/fixtures/g1_native_reasoning3_20261124/swaps.json', 'branch_pairs'),
    ('G1', 'tests/fixtures/g1_native_reasoning3_20261124/cases.json', 'skills'),
    ('G2', 'tests/fixtures/g2_native_reasoning1_20261124/swaps.json', 'branch_pairs'),
    ('G2', 'tests/fixtures/g2_native_reasoning1_20261124/cases.json', 'skills'),
    ('G2_BASIC', 'tests/fixtures/g2_native_basic1_20261124/cases.json', 'skills'),
    ('G3', 'tests/fixtures/g3_native_reasoning3_20261124/swaps.json', 'branch_pairs'),
    ('G3', 'tests/fixtures/g3_native_reasoning3_20261124/cases.json', 'skills'),
    ('G4', 'tests/fixtures/g4_native_reasoning3_20261124/cases.json', 'g4'))
# (cases, native actions differing from the same-board baseline) per handoff reports.
EXPECTED = {('ICARUS', 'SWAP_PAIR'): (88, 60), ('ICARUS', 'SKILL_PRESTATE'): (14, 0),
    ('TREX', 'SWAP_PAIR'): (10, 6), ('G1', 'SWAP_PAIR'): (21, 7), ('G1', 'SKILL_PRESTATE'): (3, 0),
    ('G2', 'SWAP_PAIR'): (16, 7), ('G2', 'SKILL_PRESTATE'): (3, 0), ('G2_BASIC', 'SKILL_PRESTATE'): (3, 0),
    ('G3', 'SWAP_PAIR'): (22, 11), ('G3', 'SKILL_PRESTATE'): (3, 0), ('G4', 'SWAP_PAIR'): (9, 2)}
SKILL_KIND = dict(ICARUS='NATIVE_BASIC_SKILL_OWNER_IN_REASONING_RUN', G2_BASIC='NATIVE_BASIC_SKILL',
    G1='NATIVE_GALAXY_PER_PET_SKILL', G2='NATIVE_GALAXY_PER_PET_SKILL', G3='NATIVE_GALAXY_PER_PET_SKILL')


def sha_bytes(raw): return hashlib.sha256(raw).hexdigest()
def sha_file(path): return sha_bytes(Path(path).read_bytes())
def canon(value): return json.dumps(value, ensure_ascii=False, sort_keys=True, separators=(',', ':'), allow_nan=False)
def canon_sha(value): return sha_bytes(canon(value).encode('utf-8'))
def rel(path): return Path(path).resolve().relative_to(ROOT).as_posix()
def ms(ns): return None if ns is None else round(ns / 1e6, 4)


def quantiles(values):
    """Nearest-rank percentiles (no interpolation); n<100 makes p99 the maximum."""
    xs = sorted(v for v in values if v is not None)
    if not xs: return dict(n=0)
    rank = lambda q: xs[max(0, math.ceil(q * len(xs)) - 1)]
    return dict(n=len(xs), min=xs[0], p50=rank(.5), p95=rank(.95), p99=rank(.99), max=xs[-1],
        mean=round(sum(xs) / len(xs), 4))


def dump_bytes(value):
    return (json.dumps(value, ensure_ascii=False, indent=1, sort_keys=True, allow_nan=False) + '\n').encode('utf-8')


def write_new(path, value):
    path = Path(path).resolve()
    require(path.is_relative_to(ROOT), 'OUTPUT_INSIDE_V2_REQUIRED')
    path.parent.mkdir(parents=True, exist_ok=True)
    raw = dump_bytes(value)
    with path.open('xb') as stream: stream.write(raw)
    return sha_bytes(raw)


def pins():
    path = ROOT / HANDOFF / 'manifest.json'
    verification = json.loads((ROOT / HANDOFF / 'verification.json').read_text('utf-8'))
    require(sha_file(path) == verification['manifest_sha256'], 'HANDOFF_MANIFEST_CHANGED')
    manifest = json.loads(path.read_text('utf-8'))
    return manifest, {p['path']: p['sha256'] for p in manifest['portable_files']}


def read_pinned(path, pinned):
    raw = (ROOT / path).read_bytes()
    require(pinned.get(path) == sha_bytes(raw), 'PORTABLE_SOURCE_CHANGED:' + path)
    return json.loads(raw.decode('utf-8'))


def common_case(cohort, kind, cp, *, baseline_kind, native_kind, native, reason, execution, ref, context=None):
    problem = CommonProblem.from_dict(cp)
    require(problem.to_dict() == cp, 'COMMON_PROBLEM_NOT_CANONICAL')
    return dict(case_id=problem.snapshot_id, cohort=cohort, kind=kind, schema='COMMON_PROBLEM_V1',
        profile=problem.intent.profile, problem=cp,
        baseline=dict(kind=baseline_kind, action=problem.baseline.to_dict()),
        native=dict(kind=native_kind, action=native, decision_reason=reason, execution=execution),
        source=ref, context=context or {}, labels=LABELS)


def native_pairs(cohort, path, data):
    for i, c in enumerate(data['cases']):
        require(c['baseline']['action'] == c['common_problem']['baseline'] and c['source_binding']['acknowledged'] is True
            and c['comparison_scope'] == 'SAME_PRE_INPUT_BOARD_NATIVE_BASIC_VS_ACTUAL_NATIVE_CHOICE_NOT_RECOMPUTED_SEARCH',
            'NATIVE_PAIR_SCOPE')
        yield common_case(cohort, 'SWAP_PAIR', c['common_problem'], baseline_kind='NATIVE_BASIC_INCUMBENT',
            native_kind='NATIVE_COMMON_WORKER_SENT', native=c['actual_chosen']['action'],
            reason=c['native_decision_reason'], execution='ACK', ref=dict(path=path, index=i, job_id=c['job_id']))


def branch_pairs(cohort, path, data):
    for i, c in enumerate(data['cases']):
        require(c['baseline']['action'] == c['common_problem']['baseline'] and c['source_binding']['acknowledged'] is True
            and c['basic_kind'] == 'PRODUCTION_RESOURCE_BRANCH_REPLAY_NOT_LOGGED_NATIVE_BASIC', 'BRANCH_PAIR_SCOPE')
        yield common_case(cohort, 'SWAP_PAIR', c['common_problem'], baseline_kind='PRODUCTION_RESOURCE_BRANCH_REPLAY',
            native_kind='NATIVE_GALAXY_PER_PET_SENT', native=c['actual_chosen']['action'], reason=c['native_step'],
            execution='ACK', ref=dict(path=path, index=i, combat_sha256=c['source_binding']['combat_sha256'],
                policy_line=c['source_binding']['policy_line'], sent_line=c['source_binding']['sent_line']),
            context=dict(basic_replay_step=c['basic_replay_step'], shields_known_after=c['shields_known_after'],
                shared_gate_scope=c['shared_gate_scope'], pass_permission_sensitivity=c['pass_permission_sensitivity']))


def skills(cohort, path, data):
    for i, c in enumerate(data['cases']):
        cp = c['common_problem']
        require(cp['baseline']['family'] == 'pet_skill', 'SKILL_PRESTATE_REQUIRED')
        response = c.get('association') or ('ORDERED_RESPONSE_RETAINED' if c.get('ordered_response') is not None
            else 'ORDERED_RESPONSE_NOT_RETAINED')
        executed = 'NATIVE_BASIC_INCUMBENT' if cohort in ('ICARUS', 'G2_BASIC') else 'RECORDED_GALAXY_R_SKILL_NOT_BASIC_PROPOSAL'
        yield common_case(cohort, 'SKILL_PRESTATE', cp, baseline_kind=executed, native_kind=SKILL_KIND[cohort],
            native=cp['baseline'], reason=cp['baseline_reason'][:160], execution='SKILL_DISPATCHED',
            ref=dict(path=path, index=i), context=dict(response_binding=response, wire_card_identity='UNKNOWN'))


def g4(cohort, path, data):
    require(data['common_problem_compatible'] is False, 'G4_SCHEMA_SCOPE')  # historical G4 logs keep their native schema
    for i, c in enumerate(data['cases']):
        pre, e = c['pre_input'], c['execution']
        require(digest(pre) == c['case_id'] and c['common_schema_supported'] is False
            and c['basic_scope'] == 'PRODUCTION_PLAN_G4_REASONING_FALSE_BRANCH_REPLAY_NOT_NATIVE_BASIC_PROPOSAL', 'G4_CASE_SCOPE')
        require(e['protocol_ack'] or (e['terminal_outcome'] and e['reason'] == 'COMBAT_LIFECYCLE_ENDED'), 'G4_EXECUTION_SCOPE')
        yield dict(case_id=c['case_id'], cohort=cohort, kind='SWAP_PAIR', schema='G4_NATIVE_V1',
            profile='galaxy_shadow_sword', problem=pre,
            baseline=dict(kind='PRODUCTION_PLAN_G4_REASONING_FALSE_REPLAY', action=c['basic']['action']),
            native=dict(kind='NATIVE_PLAN_G4_REASONING_SENT', action=c['native_reasoning']['action'],
                decision_reason=c['native_step'], execution='ACK' if e['protocol_ack'] else 'TERMINAL_NO_PROTOCOL_ACK',
                execution_detail=dict(result=e['result'], reason=e['reason'], sent_line=e['sent_line'])),
            source=dict(path=path, index=i, combat_path=pre['provenance']['path'],
                combat_sha256=pre['provenance']['file_sha256'], policy_line=pre['provenance']['line']),
            context=dict(basic_step=c['basic_step'], common_exclusion=c['common_exclusion']), labels=LABELS)


READERS = dict(native_pairs=native_pairs, branch_pairs=branch_pairs, skills=skills, g4=g4)


def live_session_logs(kind='UI_REASONING'):
    found = []
    for base in (ROOT / 'docs', ROOT / 'logs'):
        for path in base.rglob('reasoning.*.jsonl'):
            ui = (path.parent.name.startswith('ui_') and path.parent.parent.name == 'reasoning'
                and path.parent.parent.parent.name == 'farm_runs')
            if ui if kind == 'UI_REASONING' else path.parent.name == 'basic_calibration': found.append(path)
    return sorted(found, key=rel)


def calibration_source(path):
    """BASIC timing logs carry no source in session.json; use the setup request beside them."""
    for parent in path.parents[1:4]:
        request = parent / 'request.json'
        if request.is_file():
            value = json.loads(request.read_text('utf-8'))
            if type(value) is dict and value.get('source_sha256'): return value['source_sha256']
    return None


def read_records(path):
    rows = []
    for number, raw in enumerate(path.read_bytes().splitlines(), 1):
        try: record = strict_json_loads(raw.decode('utf-8-sig'))
        except (ValueError, UnicodeError, RecursionError): continue
        if type(record) is dict: rows.append((number, record))
    return rows


def session_logs(kind='UI_REASONING'):
    """Unique live logs (byte-identical copies skipped), with session.json identity."""
    seen, out = set(), []
    for path in live_session_logs(kind):
        sha = sha_file(path)
        if sha in seen: continue
        seen.add(sha)
        session = path.parent / 'session.json'
        identity = dict(json.loads(session.read_text('utf-8')) if session.is_file() else {})
        if kind != 'UI_REASONING':
            config = json.loads(identity.get('config_json') or '{}')
            identity.update(runtime_sha256=calibration_source(path), profile=config.get('play_style'))
        out.append((path, sha, identity))
    return out


def local_tier(exclude):
    cases, overlap, counts = [], 0, Counter()
    for path, sha, identity in session_logs():
        rows = read_records(path)
        decisions = {r['correlation'].get('job_id'): (n, r) for n, r in rows if r.get('event_type') == 'reasoning.decision'}
        for number, record in rows:
            if record.get('event_type') != EVENT: continue
            try: problem = decode_snapshot_event(record)
            except (ValueError, TypeError, KeyError, IndexError):
                counts['undecodable'] += 1; continue
            if problem.snapshot_id in exclude:
                overlap += 1; continue
            job = record['correlation']['job_id']
            line, decision = decisions.get(job, (None, None))
            payload = decision['payload'] if decision else {}
            if decision is None or payload.get('baseline_action') != problem.baseline.to_dict():
                counts['decision_unjoined'] += 1; continue
            exclude.add(problem.snapshot_id)
            counts[problem.intent.profile] += 1
            cases.append(common_case('LOCAL_' + problem.intent.profile.upper(), 'NATIVE_DECISION', problem.to_dict(),
                baseline_kind='NATIVE_BASIC_INCUMBENT', native_kind='NATIVE_COMMON_WORKER_DECISION_INPUT_NOT_JOINED',
                native=payload.get('proposal_action') or payload['baseline_action'], reason=payload['reason'],
                execution='UNKNOWN_NOT_JOINED_TO_INPUT',
                ref=dict(path=rel(path), file_sha256=sha, snapshot_line=number, decision_line=line, job_id=job,
                    runtime_sha256=identity.get('runtime_sha256'), farm_run_id=identity.get('farm_run_id'))))
    return cases, overlap, dict(counts)


def portable_corpus():
    manifest, pinned = pins()
    cases, sources = [], []
    for cohort, path, reader in PORTABLE:
        produced = list(READERS[reader](cohort, path, read_pinned(path, pinned)))
        sources.append(dict(path=path, sha256=pinned[path], cohort=cohort, reader=reader, cases=len(produced)))
        cases.extend(produced)
    groups = defaultdict(list)
    for c in cases: groups[(c['cohort'], c['kind'])].append(c)
    for key, (n, changed) in EXPECTED.items():
        rs = groups.get(key, [])
        require(len(rs) == n and sum(r['native']['action'] != r['baseline']['action'] for r in rs) == changed,
            'HANDOFF_COUNT_CHANGED:' + '/'.join(key))
    require(Counter(c['native']['execution'] for c in groups[('G4', 'SWAP_PAIR')]) == Counter(ACK=6, TERMINAL_NO_PROTOCOL_ACK=3),
        'G4_ACK_SPLIT_CHANGED')
    ids = [c['case_id'] for c in cases]
    require(len(ids) == len(set(ids)) == 192, 'PORTABLE_CASE_IDS')
    subset = {CommonProblem.from_dict(c['common_problem']).snapshot_id for c in read_pinned(SUBSET, pinned)['cases']}
    icarus = {c['case_id'] for c in groups[('ICARUS', 'SWAP_PAIR')]}
    require(len(subset) == 13 and subset <= icarus, 'ICARUS_FIXTURE_NOT_SUBSET')
    portable = dict(schema=CORPUS, tier='PORTABLE', native_source_sha256=manifest['source_sha256'],
        handoff_manifest_sha256=sha_file(ROOT / HANDOFF / 'manifest.json'), sources=sources,
        excluded=dict(icarus_selected_fixture=dict(path=SUBSET, sha256=pinned[SUBSET], cases=13,
            reason='SUBSET_OF_88_NATIVE_PAIRS_NOT_INDEPENDENT'),
            trex_skill_case='NO_COMMON_PROBLEM_PRE_CONTEXT_ONLY',
            g1_nightsilver_prior_trial='SEPARATE_PENDING_FULL_AUDIT_NOT_IN_CORPUS'),
        counts={'/'.join(k): len(v) for k, v in sorted(groups.items())}, cases=cases, labels=LABELS)
    return portable


def build(args):
    portable = portable_corpus()
    out = Path(args.out)
    written = dict(portable=write_new(out / 'corpus_portable.json', portable))
    if args.local:
        exclude = {c['case_id'] for c in portable['cases']}
        local, overlap, counts = local_tier(exclude)
        written['local'] = write_new(out / 'corpus_local.json', dict(schema=CORPUS, tier='LOCAL_NATIVE_SNAPSHOTS',
            overlap_with_portable=overlap, counts=counts, cases=local, labels=LABELS,
            scope='EXACT_WORKER_INPUTS_FROM_LIVE_UI_SESSIONS_OLDER_SOURCES_ALLOWED_DECISIONS_NOT_JOINED_TO_INPUT'))
    print(json.dumps(dict(written=written, portable=portable['counts'])))


def board_state(rows):
    return BoardState(tuple(tuple(CellState(r, c, GemType(g), m) for c, (g, m) in enumerate(values))
        for r, values in enumerate(rows)))


def compact(p):
    if p is None: return None
    out = dict(action=p['action'], status=p['status'], reason=p.get('reason'))
    if p['status'] != 'MODELED': return out
    res, hazard = p['known_resources'], p['one_cell_refill_hazard'] or {}
    maxima = p.get('known_reply_resource_maxima')
    out.update(coverage=p['coverage'], effective={g: res[g]['effective'] for g in GEMS},
        physical={g: res[g]['physical'] for g in GEMS}, total_effective=sum(res[g]['effective'] for g in GEMS),
        total_physical=sum(res[g]['physical'] for g in GEMS), known_reply_sword_max=p['known_reply_sword_max'],
        known_reply_count=p['known_reply_count'], refill_hazard_swords=hazard.get('effective_swords', 0),
        refill_hazard_sites=hazard.get('completion_sites', 0), unresolved_refill_cells=p['unresolved_refill_cells'],
        mana_cost=p['mana_cost'], rage_cost=p['rage_cost'], unresolved_local_effect=p['unresolved_local_effect'],
        self_heal_present=p['self_heal_present'],
        boss_best_reply_effective=None if maxima is None else {g: maxima[g]['effective'] for g in GEMS})
    return out


def context(problem):
    f = problem.facts.plain(); own = f.get('self') or {}; boss = f.get('opponent') or {}
    need = f.get('resource_requirements') or {}; rate = f.get('conversion') or {}
    def frac(a, b): return round(a / b, 4) if type(a) is int and type(b) is int and b > 0 else None
    deficit = {k: max(0, need[k] - own[k]) if type(need.get(k)) is int and type(own.get(k)) is int else None
        for k in ('mana', 'rage')}
    full = dict(mana=type(own.get('mana')) is int and type(own.get('max_mana')) is int and own['mana'] >= own['max_mana'],
        rage=type(own.get('rage')) is int and type(own.get('max_rage')) is int and own['rage'] >= own['max_rage'],
        health=type(own.get('hp')) is int and type(own.get('max_hp')) is int and own['hp'] >= own['max_hp'])
    return dict(self_hp_fraction=frac(own.get('hp'), own.get('max_hp')), boss_hp_fraction=frac(boss.get('hp'), boss.get('max_hp')),
        self_rage=own.get('rage'), boss_mana=boss.get('mana'), boss_rage=boss.get('rage'), boss_shield=boss.get('shield'),
        skill_cost=dict(mana=need.get('mana'), rage=need.get('rage')), deficit=deficit, resource_full=full,
        conversion=dict(mana=rate.get('mana'), rage=rate.get('rage')), boss_policy=f.get('boss_policy'),
        profile=problem.intent.profile, board_shield_effective=sum(m or 1 for row in problem.board for g, m in row if g == 'shield'))


def resource_view(arm, ctx):
    """Gross collection vs the current deficit at user-declared rates; never a net balance."""
    if arm is None or arm.get('status') != 'MODELED': return None
    out = {}
    for k in ('mana', 'rage'):
        d, r = ctx['deficit'][k], ctx['conversion'][k]
        gross = arm['effective'][k] * r if type(r) is int else None
        out[k] = dict(deficit=d, gross_points=gross, covers_deficit=None if d is None or gross is None or d == 0 else gross >= d)
    out['collected_while_full'] = {k: arm['effective'][k] for k in ('mana', 'rage', 'health')
        if ctx['resource_full'][k] and arm['effective'][k]}
    out['needed_effective'] = (None if any(ctx['deficit'][k] is None for k in ('mana', 'rage'))
        else sum(arm['effective'][k] for k in ('mana', 'rage') if ctx['deficit'][k] > 0))
    # Known Shield left on the settled known board, refill ignored (Galaxy keeps Shield for skills).
    out['shield_known_remaining'] = ctx['board_shield_effective'] - arm['effective']['shield']
    # Galaxy per-pet rule (docs/galaxy_glank_reasoning.md): no Sword while Rage > 0. Other styles: None.
    out['galaxy_sword_with_nonzero_rage'] = (arm['effective']['sword'] > 0 and type(ctx['self_rage']) is int
        and ctx['self_rage'] > 0) if ctx['profile'] == 'galaxy' else None
    out['scope'] = 'USER_DECLARED_RATE_GROSS_COLLECTION_NOT_NET_BALANCE_DRAIN_OR_REFILL'
    return out


def run_common(case):
    problem = CommonProblem.from_dict(case['problem'])
    base_action, native_action = case['baseline']['action'], case['native']['action']
    require(base_action == problem.baseline.to_dict(), 'BASELINE_CHANGED')
    projections = {}
    def project(action):
        key = canon(action)
        if key not in projections: projections[key] = project_action(problem, Action.from_dict(action))
        return projections[key]
    full = plan_common(problem, clock=lambda: 0)
    one = plan_common(problem, CommonLimits(lookahead=False), clock=lambda: 0)
    pick = lambda d: (d.proposal or d.baseline).to_dict()
    basic, native, common = project(base_action), project(native_action), project(pick(full))
    ctx = context(problem); fd = full.diagnostics.plain()
    arms = dict(basic=compact(basic), native=compact(native), common=compact(common))
    return dict(case_id=case['case_id'], cohort=case['cohort'], kind=case['kind'], profile=case['profile'],
        baseline_kind=case['baseline']['kind'], native_kind=case['native']['kind'], execution=case['native']['execution'],
        native_reason=case['native']['decision_reason'], arms=arms,
        resources={k: resource_view(v, ctx) for k, v in arms.items()}, context=ctx,
        common=dict(reason=full.reason, disposition=full.disposition, stage=fd['stage'], nodes=fd['nodes'],
            legal_swaps=fd['legal_swaps'], excluded=[x['reason'] for x in fd['excluded_actions']],
            one_step=dict(reason=one.reason, action=pick(one), nodes=one.diagnostics.plain()['nodes'])),
        comparisons=dict(basic_vs_native=classify_pair(basic, native), basic_vs_common=classify_pair(basic, common)),
        parity=dict(native_changed=native_action != base_action, common_changed=pick(full) != base_action,
            common_equals_native=pick(full) == native_action, one_step_equals_full=pick(one) == pick(full)))


def g4_inputs(pre):
    board = board_state(pre['board'])
    require(board.production_ready, 'G4_BOARD_NOT_READY')
    state = SimpleNamespace(board=board, player=SimpleNamespace(**pre['player']), opponents=(SimpleNamespace(**pre['boss']),))
    f = pre['native_g4_facts']
    kwargs = dict(budget_ms=f['setup_budget_ms'], passive_active=f['passive_active'],
        evolution_pending=f['evolution_pending'], evolution_mana_cost=f['evolution_mana_cost'])
    return state, kwargs


def g4_view(move):
    p = projection(move)
    return dict(action=Action('swap', move.move).to_dict(), status='MODELED', combo_units=p['known_combo_units'],
        destroyed_cells=p['known_destroyed_cells'], cascade_rounds=p['known_cascade_rounds'],
        milestone=p['declared_milestone'], lifesteal_opportunity=p['lifesteal_opportunity'],
        effective={g: move.total.effective(GemType(g)) for g in GEMS}, physical={g: move.total.cells(GemType(g)) for g in GEMS},
        known_reply_sword_max=move.sword_risk.opponent_sword_reply_effective_max,
        refill_hazard_swords=move.unknown_exposure.hypothetical_sword_effective_max,
        unresolved_refill_cells=move.unknown_exposure.cells)


def g4_classify(a, b):
    """Mechanical screen in the G4 schema; never an optimal-action certificate."""
    gaps = ['ACTUAL_REFILL_UNOBSERVED', 'PASSIVE_DAMAGE_HEAL_AND_STEADFAST_UNKNOWN', 'X7_RUNTIME_MULTIPLIER_UNOBSERVED']
    if a['action'] == b['action']:
        return dict(category='SAME_ACTION', benefits=[], costs=[], unknowns=['ACTUAL_FUTURE_UNOBSERVED'])
    benefits, costs = [], []
    def delta(name, x, y, smaller=False):
        if x != y: (benefits if (y < x if smaller else y > x) else costs).append(dict(dimension=name, basic=x, reasoning=y))
    delta('milestone', a['milestone'], b['milestone']); delta('combo_units', a['combo_units'], b['combo_units'])
    for g in GEMS: delta('collection.' + g + '.effective', a['effective'][g], b['effective'][g])
    for name in ('known_reply_sword_max', 'refill_hazard_swords', 'unresolved_refill_cells'):
        delta(name, a[name], b[name], True)
    category = ('TRADEOFF' if benefits and costs else 'CONDITIONAL_MECHANICAL_ADVANTAGE' if benefits
        else 'REVIEW_IMMEDIATE_COST_WITHOUT_MEASURED_GAIN' if costs else 'NO_KNOWN_MECHANICAL_SEPARATION')
    return dict(category=category, benefits=benefits, costs=costs, unknowns=gaps, count_gain_is_not_net_benefit=True)


def run_g4(case):
    pre = case['problem']; state, kwargs = g4_inputs(pre)
    moves = evaluate_all_moves(state.board)
    native = plan_g4(state, moves, reasoning=True, clock=lambda: 0, **kwargs)
    basic = plan_g4(state, moves, reasoning=False, clock=lambda: 0, **kwargs)
    a, b = g4_view(basic.selected), g4_view(native.selected)
    return dict(case_id=case['case_id'], cohort=case['cohort'], kind=case['kind'], profile=case['profile'],
        baseline_kind=case['baseline']['kind'], native_kind=case['native']['kind'], execution=case['native']['execution'],
        native_reason=case['native']['decision_reason'], arms=dict(basic=a, native=b, common=None),
        common=dict(reason='GALAXY_SHADOW_SWORD_NOT_IN_COMMON_PROFILES_GAP_U4'),
        steps=dict(basic=basic.step, native=native.step), setup_nodes=native.facts['setup_nodes'],
        comparisons=dict(basic_vs_native=g4_classify(a, b)),
        parity=dict(native_changed=b['action'] != a['action'], basic_replay_equals_recorded=a['action'] == case['baseline']['action'],
            native_replay_equals_sent=b['action'] == case['native']['action'], native_facts_equal_logged=native.facts == pre['native_g4_facts']))


def load_corpora(paths):
    corpora = []
    for path in paths:
        raw = Path(path).read_bytes(); data = json.loads(raw.decode('utf-8'))
        require(data['schema'] == CORPUS, 'CORPUS_SCHEMA')
        corpora.append((rel(path), sha_bytes(raw), data))
    return corpora


def tally(rs, key, arm):
    out = dict(categories=Counter(), benefits=Counter(), costs=Counter(), sword_reply=Counter(), refill_hazard=Counter(),
        combo_units=Counter(), needed_resource=Counter(), shield_known_remaining=Counter())
    deltas = Counter(); changed = 0
    for r in rs:
        cmp, a, b = r['comparisons'].get(key), r['arms']['basic'], r['arms'].get(arm)
        if cmp is None or b is None: continue
        out['categories'][cmp['category']] += 1
        out['benefits'].update(x['dimension'] for x in cmp['benefits']); out['costs'].update(x['dimension'] for x in cmp['costs'])
        if a['action'] == b['action'] or a.get('status') != 'MODELED' or b.get('status') != 'MODELED': continue
        changed += 1
        units = 'combo_units' if 'combo_units' in a else 'total_effective'
        view = lambda name, field: ((r.get('resources') or {}).get(name) or {}).get(field)
        for name, x, y in (('sword_reply', a.get('known_reply_sword_max'), b.get('known_reply_sword_max')),
                ('refill_hazard', a.get('refill_hazard_swords'), b.get('refill_hazard_swords')),
                ('combo_units', a.get(units), b.get(units)),
                ('needed_resource', view('basic', 'needed_effective'), view(arm, 'needed_effective')),
                ('shield_known_remaining', view('basic', 'shield_known_remaining'), view(arm, 'shield_known_remaining'))):
            out[name]['UNKNOWN' if x is None or y is None else 'LOWER' if y < x else 'HIGHER' if y > x else 'EQUAL'] += 1
        for g in GEMS: deltas[g] += b['effective'][g] - a['effective'][g]
    out = {k: dict(v) for k, v in out.items()}
    out.update(changed_modeled=changed, effective_delta_sum={g: deltas[g] for g in GEMS})
    return out


def summarize(results):
    groups = defaultdict(list)
    for r in results: groups[(r['cohort'], r['kind'])].append(r)
    out = {}
    for (cohort, kind), rs in sorted(groups.items()):
        s = dict(n=len(rs), baseline_kinds=dict(Counter(r['baseline_kind'] for r in rs)),
            native_kinds=dict(Counter(r['native_kind'] for r in rs)), executions=dict(Counter(r['execution'] for r in rs)),
            native_changed=sum(r['parity']['native_changed'] for r in rs),
            native_vs_basic=tally(rs, 'basic_vs_native', 'native'))
        def reply(arm):
            values = [r['arms'][arm].get('known_reply_sword_max') for r in rs if r['arms'].get(arm)]
            return dict(quantiles(values), zero=sum(v == 0 for v in values if v is not None))
        s['known_reply_sword_max'] = dict(basic=reply('basic'), native=reply('native'))
        if rs[0]['profile'] == 'galaxy_shadow_sword':
            s.update(basic_replay_equals_recorded=sum(r['parity']['basic_replay_equals_recorded'] for r in rs),
                native_replay_equals_sent=sum(r['parity']['native_replay_equals_sent'] for r in rs),
                native_facts_equal_logged=sum(r['parity']['native_facts_equal_logged'] for r in rs),
                steps=dict(basic=dict(Counter(r['steps']['basic'] for r in rs)), native=dict(Counter(r['steps']['native'] for r in rs))),
                milestones=dict(basic=dict(Counter(r['arms']['basic']['milestone'] for r in rs)),
                    native=dict(Counter(r['arms']['native']['milestone'] for r in rs))),
                combo_units=dict(basic=quantiles([r['arms']['basic']['combo_units'] for r in rs]),
                    native=quantiles([r['arms']['native']['combo_units'] for r in rs])),
                weighted_differs_from_physical=sum(r['arms']['native']['combo_units'] != r['arms']['native']['destroyed_cells'] for r in rs),
                common='GAP_GALAXY_SHADOW_SWORD_NOT_IN_COMMON_PROFILES')
        else:
            s.update(common_changed=sum(r['parity']['common_changed'] for r in rs),
                common_equals_native=sum(r['parity']['common_equals_native'] for r in rs),
                one_step_equals_full=sum(r['parity']['one_step_equals_full'] for r in rs),
                common_vs_basic=tally(rs, 'basic_vs_common', 'common'),
                common_reasons=dict(Counter(r['common']['reason'] for r in rs)),
                common_stages=dict(Counter(r['common']['stage'] for r in rs)),
                common_nodes=quantiles([r['common']['nodes'] for r in rs]),
                native_reasons=dict(Counter(r['native_reason'] for r in rs)) if kind != 'SKILL_PRESTATE' else None,
                common_selected_family=dict(Counter(r['arms']['common']['action']['family'] for r in rs)),
                galaxy_sword_with_nonzero_rage={arm: sum(bool((r['resources'].get(arm) or {}).get('galaxy_sword_with_nonzero_rage'))
                    for r in rs) for arm in ('basic', 'native', 'common')} if rs[0]['profile'] == 'galaxy' else None,
                collected_while_full={arm: sum(bool((r['resources'].get(arm) or {}).get('collected_while_full')) for r in rs)
                    for arm in ('basic', 'native', 'common')})
            s['known_reply_sword_max']['common'] = reply('common')
        out['/'.join((cohort, kind))] = s
    return out


def run(args):
    before = source_fingerprint(ROOT)
    corpora = load_corpora(args.corpus)
    results = []
    for _, _, data in corpora:
        for case in data['cases']:
            results.append(run_g4(case) if case['schema'] == 'G4_NATIVE_V1' else run_common(case))
    require(source_fingerprint(ROOT) == before, 'SOURCE_CHANGED_DURING_RUN')
    output = dict(schema=RESULT, source_sha256=before, corpora=[dict(path=p, sha256=s) for p, s, _ in corpora],
        decision_digest=canon_sha(results), summary=summarize(results), results=results,
        python_hash_seed=os.environ.get('PYTHONHASHSEED'), labels=LABELS,
        scope='SAME_PRE_INPUT_STATE_MECHANICAL_SCREEN_NOT_WIN_DAMAGE_OR_OPTIMAL_LABEL')
    sha = write_new(args.out, output)
    print(json.dumps(dict(file_sha256=sha, decision_digest=output['decision_digest'], cases=len(results), source=before)))


def shas(run): return [c['sha256'] for c in run['corpora']]


def compare_runs(args):
    a, b = (json.loads(Path(p).read_text('utf-8')) for p in (args.a, args.b))
    diffs = [x['case_id'] for x, y in zip(a['results'], b['results']) if canon(x) != canon(y)]
    same = (a['decision_digest'] == b['decision_digest'] == canon_sha(a['results']) == canon_sha(b['results'])
        and shas(a) == shas(b) and a['source_sha256'] == b['source_sha256'] and not diffs
        and len(a['results']) == len(b['results']))
    print(json.dumps(dict(reproducible=same, decision_digest=[a['decision_digest'], b['decision_digest']],
        hash_seeds=[a.get('python_hash_seed'), b.get('python_hash_seed')], cases=len(a['results']), differing_cases=diffs[:20])))
    raise SystemExit(0 if same else 1)


def iso(value):
    return datetime.fromisoformat(value.replace('Z', '+00:00')).timestamp() * 1000


def swap_timing_rows(rows):
    decisions = {r['correlation'].get('job_id'): r['payload'] for _, r in rows if r.get('event_type') == 'reasoning.decision'}
    out = []
    for _, r in rows:
        if r.get('event_type') != 'reasoning.swap_timing': continue
        p = r['payload']; b = p.get('budget') or {}; job = (p.get('selection') or {}).get('job_id')
        d = decisions.get(job) or {}; diag = (d.get('summary') or {}).get('common_diagnostics') or {}
        observed, read_end = p.get('observed_ns'), p.get('observation_read_end_ns')
        span = None if observed is None or read_end is None else ms(read_end - observed)
        out.append(dict(status=p.get('status'), budget_reason=b.get('reason'), preparation=b.get('preparation_reason'),
            read_span_ms=span, read_span_over_gate=span is not None and span > 100,
            remaining_s=p.get('raw_remaining_seconds'), remaining_preflight_s=p.get('remaining'),
            queue_ms=ms(b['started_ns'] - b['read_end_ns']) if b else None,
            worker_wait_ms=ms(b['ended_ns'] - b['started_ns']) if b else None,
            allowed_budget_ms=ms(b['deadline_ns'] - b['read_end_ns']) if b else None,
            decision_ms=ms(p['decision_exit_ns'] - observed) if p.get('decision_exit_ns') and observed else None,
            fresh_ms=ms(p['fresh_checkpoint_ns'] - p['decision_exit_ns']) if p.get('fresh_checkpoint_ns') and p.get('decision_exit_ns') else None,
            final_ms=ms(p['final_checkpoint_ns'] - p['fresh_checkpoint_ns']) if p.get('final_checkpoint_ns') and p.get('fresh_checkpoint_ns') else None,
            H_ms=ms(p.get('controller_tail_ns')), I_ms=ms(p.get('elapsed_upper_bound_ns')), full_tail_ms=ms(p.get('full_tail_ns')),
            e2e_ms=ms(p['executor_return_ns'] - observed) if p.get('executor_return_ns') and observed else None,
            reserve_ms=p.get('reserve_ms'), compute_ms=ms(d.get('compute_ns')), nodes=diag.get('nodes'),
            stage=diag.get('stage'), reason=d.get('reason')))
        row = out[-1]
        row['wait_over_compute'] = (round(row['worker_wait_ms'] / row['compute_ms'], 4)
            if row['worker_wait_ms'] is not None and row['compute_ms'] else None)
    return out


def native_timing():
    groups = defaultdict(list); decisions = defaultdict(list); selection = defaultdict(Counter)
    decision_timing = defaultdict(Counter); sources = []; reserves = {}
    current = pins()[0]['source_sha256']
    logs = [('UI_REASONING',) + x for x in session_logs()] + [('BASIC_CALIBRATION',) + x for x in session_logs('BASIC_CALIBRATION')]
    for kind, path, sha, identity in logs:
        rows = read_records(path)
        runtime = identity.get('runtime_sha256')
        tier = 'CURRENT_SOURCE' if runtime == current else 'OLDER_SOURCE' if runtime else 'SOURCE_UNKNOWN'
        run = str(identity.get('farm_run_id'))[:8] if tier == 'CURRENT_SOURCE' else 'pooled'
        key = '/'.join((kind, tier, str(identity.get('profile')), run))
        sources.append(dict(path=rel(path), sha256=sha, runtime_sha256=runtime, profile=identity.get('profile'), group=key))
        for row in swap_timing_rows(rows):
            group = key + '/' + ('BASIC_ONLY' if kind == 'BASIC_CALIBRATION' else
                'R_WORKER_COMPLETED' if row['budget_reason'] == 'COMPLETED' and not row['read_span_over_gate']
                else 'FALLBACK_READ_SPAN_OVER_100MS' if row['read_span_over_gate'] else 'FALLBACK_' + str(row['preparation'] or row['budget_reason']))
            groups[group].append(row)
            if row['reserve_ms'] is not None: reserves.setdefault(key, set()).add(row['reserve_ms'])
        for _, r in rows:
            et = r.get('event_type'); p = r.get('payload') or {}
            if et == 'reasoning.decision':
                diag = (p.get('summary') or {}).get('common_diagnostics') or {}
                decisions[key].append(dict(compute_ms=ms(p.get('compute_ns')), nodes=diag.get('nodes'), reason=p.get('reason')))
            elif et == 'reasoning.common_selection': selection[key][p.get('checkpoint') + ':' + p.get('reason')] += 1
            elif et == 'reasoning.decision_timing': decision_timing[key][p.get('status') + ':' + str((p.get('budget') or {}).get('reason'))] += 1
    fields = ('remaining_s', 'read_span_ms', 'queue_ms', 'worker_wait_ms', 'allowed_budget_ms', 'decision_ms', 'fresh_ms',
        'final_ms', 'H_ms', 'I_ms', 'full_tail_ms', 'e2e_ms', 'compute_ms', 'nodes', 'wait_over_compute')
    swap = {g: dict(samples=len(rs), read_span_over_100ms=sum(r['read_span_over_gate'] for r in rs),
        **{f: quantiles([r[f] for r in rs]) for f in fields},
        slack_ms=quantiles([r['remaining_s'] * 1000 - r['e2e_ms'] for r in rs if r['remaining_s'] is not None and r['e2e_ms'] is not None]),
        reserve_ms=sorted(reserves.get(g.rsplit('/', 1)[0], ()))) for g, rs in sorted(groups.items())}
    worker = {k: dict(compute_ms=quantiles([d['compute_ms'] for d in v]), nodes=quantiles([d['nodes'] for d in v]),
        ms_per_1000_nodes=quantiles([round(d['compute_ms'] / d['nodes'] * 1000, 4) for d in v if d['compute_ms'] and d['nodes']]),
        reasons=dict(Counter(d['reason'] for d in v))) for k, v in sorted(decisions.items())}
    return dict(swap_timing=swap, worker_decisions=worker, selection_checkpoints={k: dict(v) for k, v in selection.items()},
        decision_timing_status={k: dict(v) for k, v in decision_timing.items()}, sources=sources)


def combat_timing():
    """Handoff cohorts' pinned combat logs: wall-clock log stamps, ms resolution, not QPC."""
    manifest = pins()[0]; raw = manifest['raw_files']['files']; out = {}
    cohorts = [(c['cohort'], c['farm_run_id']) for c in manifest['cohorts']]
    cohorts.append(('G1_NIGHTSILVER_PRIOR_TRIAL_SEPARATE', manifest['retained_prior_trial']['farm_run_id']))
    for cohort, farm_run in cohorts:
        rows_out = []; files = []
        for path in sorted(p for p in raw if farm_run in p and p.endswith('/combat.jsonl')):
            file = ROOT / path
            if not file.is_file(): continue
            require(raw[path] == sha_file(file), 'PINNED_COMBAT_CHANGED:' + path)
            files.append(dict(path=path, sha256=raw[path]))
            rows = [(n, json.loads(line)) for n, line in enumerate(file.read_text('utf-8').splitlines(), 1) if line.strip()]
            previous = 0
            for n, r in rows:
                if r.get('event') != 'action_sent': continue
                if r.get('action') != 'SWAP':
                    previous = n; continue
                src = r['identity']['source']
                policy = [x for m, x in rows if m < n and x.get('event') == 'policy_decision' and x.get('session') == src['session']
                    and (x.get('turn'), x.get('srvSeq'), x.get('boardHash')) == (src['turn'], src['srv_seq'], src['board_hash'])]
                result = [x for _, x in rows if x.get('event') == 'action_result' and (x.get('action') or {}).get('identity') == r['identity']]
                start, previous = previous, n
                if not policy: continue
                p = policy[-1]
                # Latest readiness after the previous input; it still includes provider waits.
                ready = [x for m, x in rows if start < m < n and x.get('event') == 'idle_readiness'
                    and iso(x['timestamp']) <= iso(p['timestamp'])]
                rows_out.append(dict(remaining_s=p.get('timerRemaining'), policy_step=p.get('policyStep'),
                    ready_to_policy_ms=round(iso(p['timestamp']) - iso(ready[-1]['timestamp']), 3) if ready else None,
                    policy_to_sent_ms=round(iso(r['timestamp']) - iso(p['timestamp']), 3),
                    sent_to_result_ms=round(iso(result[0]['timestamp']) - iso(r['timestamp']), 3) if result else None,
                    result=result[0]['result'] if result else None,
                    inter_click_s=r.get('interClickDelaySeconds')))
        out[cohort] = dict(files=files, swaps=len(rows_out), results=dict(Counter(x['result'] for x in rows_out)),
            **{f: quantiles([x[f] for x in rows_out]) for f in ('remaining_s', 'ready_to_policy_ms', 'policy_to_sent_ms',
                'sent_to_result_ms', 'inter_click_s')}, policy_steps=dict(Counter(x['policy_step'] for x in rows_out)),
            clock='LOG_WALL_CLOCK_MS_NOT_QPC')
    return out


def micro_bench(corpora, repeats):
    per = defaultdict(lambda: defaultdict(list)); seen = set()
    clock = time.perf_counter_ns
    for _, _, data in corpora:
        for case in data['cases']:
            if case['case_id'] in seen: continue
            seen.add(case['case_id']); group = per[case['cohort'] + '/' + case['kind']]
            if case['schema'] == 'G4_NATIVE_V1':
                state, kwargs = g4_inputs(case['problem'])
                for mode in (True, False):
                    samples = []
                    for _ in range(repeats):
                        t0 = clock(); moves = evaluate_all_moves(state.board); plan_g4(state, moves, reasoning=mode, **kwargs)
                        samples.append((clock() - t0) / 1e6)
                    group['plan_g4_reasoning_ms' if mode else 'plan_g4_basic_ms'].append(round(sorted(samples)[len(samples) // 2], 4))
                    group['plan_g4_reasoning_max_ms' if mode else 'plan_g4_basic_max_ms'].append(round(max(samples), 4))
                continue
            problem = CommonProblem.from_dict(case['problem']); board = problem.board_state()
            for name, limits in (('plan_common_ms', CommonLimits()), ('plan_common_one_step_ms', CommonLimits(lookahead=False))):
                samples = []
                for _ in range(repeats):
                    t0 = clock(); decision = plan_common(problem, limits); samples.append((clock() - t0) / 1e6)
                group[name].append(round(sorted(samples)[len(samples) // 2], 4))
                group[name.replace('_ms', '_max_ms')].append(round(max(samples), 4))
                if name == 'plan_common_ms':
                    nodes = decision.diagnostics.plain()['nodes']
                    group['nodes'].append(nodes)
                    group['ms_per_1000_nodes'].append(round(sorted(samples)[len(samples) // 2] / nodes * 1000, 4) if nodes else None)
                    group['deadline_or_cap_hit'].append(int('DEADLINE' in decision.reason or 'NODE_CAP' in decision.reason))
            samples = []
            for _ in range(repeats):
                t0 = clock(); evaluate_all_moves(board); samples.append((clock() - t0) / 1e6)
            group['evaluate_all_moves_ms'].append(round(sorted(samples)[len(samples) // 2], 4))
    out = {g: {k: (sum(v) if k == 'deadline_or_cap_hit' else quantiles(v)) for k, v in m.items()} for g, m in sorted(per.items())}
    pooled = defaultdict(list)
    for m in per.values():
        for k, v in m.items(): pooled[k].extend(v)
    out['ALL'] = {k: (sum(v) if k == 'deadline_or_cap_hit' else quantiles(v)) for k, v in pooled.items()}
    return out


def host():
    from pokiguard_v2.reasoning_operational import host_fingerprint
    return dict(host_sha256=host_fingerprint(), platform=platform.platform(), processor=platform.processor(),
        logical_cpus=os.cpu_count(), python=sys.version.split()[0], clock=str(time.get_clock_info('perf_counter')))


def timing(args):
    before = source_fingerprint(ROOT)
    corpora = load_corpora(args.corpus)
    output = dict(schema=TIMING, source_sha256=before, host=host(), corpora=[dict(path=p, sha256=s) for p, s, _ in corpora],
        percentile_method='NEAREST_RANK_NO_INTERPOLATION', repeats=args.repeats,
        native=native_timing() if args.native else None, combat=combat_timing() if args.native else None,
        offline=micro_bench(corpora, args.repeats), started_utc=datetime.now(timezone.utc).isoformat(),
        scope='DESCRIPTIVE_TIMING_NOT_SERVER_DEADLINE_OR_CUSTOMER_MACHINE_GUARANTEE')
    require(source_fingerprint(ROOT) == before, 'SOURCE_CHANGED_DURING_TIMING')
    print(json.dumps(dict(file_sha256=write_new(args.out, output), source=before)))


def freeze(args):
    """Small committed receipts: corpus pins + per-case index, bench summary, timing summary."""
    corpora = load_corpora(args.corpus)
    a, b = (json.loads(Path(p).read_text('utf-8')) for p in args.runs)
    corpus_pins = [dict(path=p, sha256=s) for p, s, _ in corpora]
    reproducible = (a['decision_digest'] == b['decision_digest'] == canon_sha(a['results']) == canon_sha(b['results'])
        and shas(a) == shas(b) == [c['sha256'] for c in corpus_pins] and a['source_sha256'] == b['source_sha256']
        and a.get('python_hash_seed') != b.get('python_hash_seed'))
    require(reproducible, 'U1_RUNS_NOT_REPRODUCIBLE')
    tool = ROOT / 'tools/reasoning_u1_bench.py'
    index = [dict(case_id=c['case_id'], tier=data['tier'], cohort=c['cohort'], kind=c['kind'], schema=c['schema'],
        profile=c['profile'], baseline_kind=c['baseline']['kind'], native_kind=c['native']['kind'],
        execution=c['native']['execution'], source=c['source']) for _, _, data in corpora for c in data['cases']]
    portable = next(data for _, _, data in corpora if data['tier'] == 'PORTABLE')
    manifest = dict(schema='pokiguard.opus.u1_corpus_manifest.v1', builder=dict(path=rel(tool), sha256=sha_file(tool)),
        source_sha256=a['source_sha256'], native_source_sha256=portable['native_source_sha256'],
        handoff_manifest_sha256=portable['handoff_manifest_sha256'], portable_sources=portable['sources'],
        excluded=portable['excluded'],
        corpora=[dict(path=p, sha256=s, tier=d['tier'], cases=len(d['cases']), counts=d['counts'],
            committed=False, rebuild='python tools/reasoning_u1_bench.py corpus --out <new-dir>' + (' --local' if d['tier'] != 'PORTABLE' else ''))
            for p, s, d in corpora], index=index, labels=LABELS,
        scope='REGRESSION_AND_EVALUATION_CORPUS_NOT_TRAINING_OR_INDEPENDENT_HOLDOUT')
    out = Path(args.out)
    written = dict(manifest=write_new(out / 'corpus_manifest.json', manifest))
    written['bench'] = write_new(out / 'bench_summary.json', dict(schema=RESULT + '.summary', source_sha256=a['source_sha256'],
        corpora=corpus_pins, decision_digest=a['decision_digest'], reproducible=dict(status=reproducible,
            hash_seeds=[a.get('python_hash_seed'), b.get('python_hash_seed')], runs=[dict(path=rel(p), sha256=sha_file(p))
                for p in args.runs], separate_processes=True), summary=a['summary'], labels=LABELS, scope=a['scope']))
    if args.timing:
        value = json.loads(Path(args.timing).read_text('utf-8'))
        require(value['source_sha256'] == a['source_sha256'] and shas(value) == shas(a), 'TIMING_CORPUS_MISMATCH')
        value['timing_file'] = dict(path=rel(args.timing), sha256=sha_file(args.timing))
        written['timing'] = write_new(out / 'timing_summary.json', value)
    print(json.dumps(written))


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    sub = parser.add_subparsers(dest='command', required=True)
    p = sub.add_parser('corpus'); p.add_argument('--out', type=Path, required=True); p.add_argument('--local', action='store_true')
    p.set_defaults(func=build)
    p = sub.add_parser('run'); p.add_argument('--corpus', type=Path, nargs='+', required=True)
    p.add_argument('--out', type=Path, required=True); p.set_defaults(func=run)
    p = sub.add_parser('compare'); p.add_argument('a', type=Path); p.add_argument('b', type=Path); p.set_defaults(func=compare_runs)
    p = sub.add_parser('timing'); p.add_argument('--corpus', type=Path, nargs='+', required=True)
    p.add_argument('--out', type=Path, required=True); p.add_argument('--repeats', type=int, default=3)
    p.add_argument('--native', action='store_true'); p.set_defaults(func=timing)
    p = sub.add_parser('freeze'); p.add_argument('--corpus', type=Path, nargs='+', required=True)
    p.add_argument('--runs', type=Path, nargs=2, required=True); p.add_argument('--timing', type=Path)
    p.add_argument('--out', type=Path, required=True); p.set_defaults(func=freeze)
    args = parser.parse_args(); args.func(args)


if __name__ == '__main__': main()
