"""File-only boss SWAP intervals with actual published before/after boards.

Never infer a before board from our LastMove, collapse simulation or refill.
An observed interval is descriptive evidence, not an optimal-action label.
"""
from collections import Counter
from copy import deepcopy
import argparse
import hashlib
import json
from pathlib import Path
import sys

ROOT = Path(__file__).resolve().parents[1]
sys.path[:0] = [str(ROOT), str(ROOT/'src')]
from pokiguard_v2.combat_board_evidence import (
    BOARD_SCHEMA, STATE_SCHEMA, BOARD_ORDER, MAX_STATE_RECORDS, retained_board_fields,
    valid_screen_board, semantic_board_hash,
)
from pokiguard_v2.il2cpp_layout import BoardCellSnapshot
from pokiguard_v2.combat_outcome_evidence import (
    SCHEMA as OUTCOME_SCHEMA, RESPONSE_TYPES, RESPONSE_IDENTITY_SCHEMA, MAX_RETAINED_CAPTURES,
)
from tools.normalize_action_outcomes import (
    extract as extract_outcomes, checked as checked_outcome, integer, hash_value, actor, text,
)


def checked_state(value):
    if (type(value) is not dict or value.get('schema') != STATE_SCHEMA
            or value.get('status') != 'CAPTURED' or value.get('input_authority') is not False
            or value.get('training_eligible') is not False
            or any(value.get(k) is not True for k in ('stable', 'latest', 'acknowledged'))
            or not text(value.get('match_id')) or not integer(value.get('lifecycle_epoch'), 1)
            or not integer(value.get('board_instance'), 1, 2**64-1)
            or not integer(value.get('server_sequence'), 0, 10000000)
            or not integer(value.get('turn'), 1) or not hash_value(value.get('board_hash'))
            or value.get('board_order') != BOARD_ORDER or not valid_screen_board(value.get('board'))
            or value.get('semantic_board_sha256') != semantic_board_hash(value['board'])
            or not actor(value.get('local_identity')) or value['local_identity'] == 'BOSS'
            or value.get('actor_identity') not in ('BOSS', value['local_identity'])
            or type(value.get('sources')) is not list or not 0 < len(value['sources']) <= 32
            or any(not text(s) for s in value['sources'])):
        raise ValueError('INVALID_PUBLISHED_STATE')
    return deepcopy(value)


def checked_retained(value):
    if (type(value) is not dict or value.get('schema') != BOARD_SCHEMA
            or value.get('status') != 'CAPTURED' or value.get('input_authority') is not False
            or value.get('training_eligible') is not False):
        raise ValueError('INVALID_RETAINED_BOARD')
    raw = value.get('native_cells')
    if type(raw) is not list or len(raw) != 64 or any(type(c) is not list or len(c) != 4 for c in raw):
        raise ValueError('INVALID_NATIVE_CELLS')
    cells = tuple(BoardCellSnapshot(0, c[1], c[0], 0, c[2], c[3]) for c in raw)
    reconstructed = retained_board_fields(cells, match_id=value.get('match_id'),
        lifecycle_epoch=value.get('lifecycle_epoch'), sequence=value.get('server_sequence'),
        source=value.get('source'), accepted=True).get('boardEvidence')
    if reconstructed is None or value.get('board_hash') != reconstructed['board_hash']:
        raise ValueError('RETAINED_BOARD_HASH_OR_DOMAIN')
    return deepcopy(value)


def _response_scope(row, capture):
    """A new drained response can carry identity without carrying effects."""
    identity = capture.get('response_identity')
    if (row.get('event') not in ('dispatcher_combat_outcome', 'dispatcher_board_snapshot_offered')
            or type(identity) is not dict
            or identity.get('schema') != RESPONSE_IDENTITY_SCHEMA
            or identity.get('source') != 'EXISTING_IMMUTABLE_JSON_VALIDATED_MATCH_SEQUENCE'
            or identity.get('effect_evidence') is not False or identity.get('input_authority') is not False
            or not text(identity.get('match_id')) or row.get('matchId') != identity['match_id']
            or not integer(row.get('lifecycleEpoch'), 1)
            or identity.get('event_type') not in RESPONSE_TYPES
            or not integer(identity.get('server_sequence'), 0, 10000000)
            or not hash_value(identity.get('raw_sha256'))):
        raise ValueError('UNVERIFIED_RESPONSE_IDENTITY')
    for field, value in (('srvSeq', identity['server_sequence']), ('eventType', identity['event_type'])):
        if field in row and (type(row[field]) is not type(value) or row[field] != value):
            raise ValueError('CONFLICTING_RESPONSE_IDENTITY')
    return dict(match_id=identity['match_id'], lifecycle_epoch=row['lifecycleEpoch'],
        server_sequence=identity['server_sequence'])


def _legacy_metadata_scopes(rows):
    """Reconcile a complete single-session index; no time/nearest-row guessing.

    This deliberately rejects partial indexes, duplicate emissions and ambiguous
    residual groups. It scopes exclusions only; no observation becomes CAPTURED.
    """
    try:
        summaries = [r for _, r in rows if r.get('event') == 'auto_controller_summary']
        if len(summaries) != 1:
            return {}
        summary = summaries[0]
        if (summary.get('sessionCleared') is not True or summary.get('status') != 'STOPPED'
                or 'activeSession' not in summary or summary['activeSession'] is not None
                or 'pending' not in summary or summary['pending'] is not None):
            return {}
        transport = summary['dispatcherTransport']
        if type(transport) is not dict:
            return {}
        if any(type(transport.get(k)) is not int or transport[k] != 0
                for k in ('outcome_capture_faults', 'dispatcher_read_trace_faults')):
            return {}
        trace = transport['dispatcher_reads']; index = transport['outcome_capture']
        if type(trace) is not dict or type(index) is not dict:
            return {}
        match = trace.get('match_id')
        if (trace.get('schema') != 'pokiguard.dispatcher_read_trace.v1' or not text(match)
                or trace.get('input_authority') is not False or not text(trace.get('trace_id'), 64)
                or trace.get('effect_completeness') != 'UNKNOWN'
                or not integer(trace.get('reads_completed'), 1, 2**63-1)
                or type(trace.get('reads_started')) is not int or trace['reads_started'] != trace['reads_completed']
                or type(trace.get('obsolete_completions')) is not int or trace['obsolete_completions'] != 0
                or index.get('schema') != 'pokiguard.combat_capture_diagnostics.v1'
                or index.get('record_limit') != MAX_RETAINED_CAPTURES
                or type(index.get('dropped_observations')) is not int or index['dropped_observations'] != 0
                or index.get('unscoped_json_read_errors') != [] or index.get('input_authority') is not False
                or index.get('effect_completeness') != 'UNKNOWN'):
            return {}
        observations = index['observations']
        if type(observations) is not list or not 0 < len(observations) <= MAX_RETAINED_CAPTURES:
            return {}
        states = [checked_state(r['stateEvidence']) for _, r in rows if 'stateEvidence' in r]
        sessions = {(s['match_id'], s['lifecycle_epoch'], s['board_instance']) for s in states}
        if len(sessions) != 1:
            return {}
        session_match, epoch, _ = next(iter(sessions))
        if session_match != match:
            return {}
        by_key = {}
        for observation in observations:
            if type(observation) is not dict:
                return {}
            binding = observation.get('reader_binding')
            root = binding.get('root') if type(binding) is dict else None
            if (observation.get('match_id') != match or observation.get('event_type') not in RESPONSE_TYPES
                    or not integer(observation.get('server_sequence'), 0, 10000000)
                    or observation.get('metadata_source') != 'IMMUTABLE_JSON'
                    or observation.get('projection_status') not in ('CAPTURED', 'UNAVAILABLE')
                    or not text(observation.get('projection_reason'), 96)
                    or not hash_value(observation.get('raw_sha256'))
                    or not integer(observation.get('json_chars'), 1, 262144)
                    or observation.get('json_read_state') != 'READ' or observation.get('json_read_error') is not None
                    or observation.get('conflicting_raw_identity') is not False
                    or any(type(observation.get(k)) is not bool for k in ('board_fields_offered', 'queue_drained'))
                    or type(binding) is not dict or binding.get('trace_id') != trace['trace_id']
                    or not integer(binding.get('read_id'), 1, trace['reads_completed'])
                    or any(not integer(binding.get(k), 0, 2**63-1)
                        for k in ('read_started_ns', 'read_finished_ns', 'decoded_ns'))
                    or not binding['read_started_ns'] <= binding['read_finished_ns'] <= binding['decoded_ns']
                    or type(root) is not dict or root.get('source') not in ('execution_queue', 'drain_buffer')
                    or not integer(root.get('logical_index'), 0, 255)
                    or any(type(root.get(k)) is not str or len(root[k]) != 24
                        or any(c not in '0123456789abcdef' for c in root[k])
                        for k in ('callback_token', 'dto_token', 'json_token'))):
                return {}
            key = (match, observation['event_type'], observation['server_sequence'])
            if key in by_key:
                return {}
            by_key[key] = observation
        emitted = [(n, r) for n, r in rows if 'combatOutcome' in r]
        if len(emitted) != len(by_key):
            return {}
        used = set(); unresolved = []
        for line, row in emitted:
            capture = row['combatOutcome']
            if (row.get('event') not in ('dispatcher_board_snapshot_offered', 'dispatcher_combat_outcome')
                    or row.get('matchId') != match or type(row.get('lifecycleEpoch')) is not int
                    or row['lifecycleEpoch'] != epoch or type(capture) is not dict
                    or capture.get('schema') != OUTCOME_SCHEMA or capture.get('input_authority') is not False
                    or capture.get('damage_prediction') is not False):
                return {}
            if capture.get('status') == 'CAPTURED':
                evidence = checked_outcome(capture)
                key = (evidence['match_id'], evidence['event_type'], evidence['server_sequence'])
                observation = by_key.get(key, {})
                if (key in used or observation.get('projection_status') != 'CAPTURED'
                        or observation.get('projection_reason') != capture.get('reason')
                        or observation.get('raw_sha256') != evidence['raw_sha256']
                        or not (observation.get('board_fields_offered') or observation.get('queue_drained'))):
                    return {}
                if any(k in row and (type(row[k]) is not type(value) or row[k] != value)
                        for k, value in (('srvSeq', key[2]), ('eventType', key[1]))):
                    return {}
                used.add(key)
            elif (capture.get('status') == 'UNAVAILABLE' and capture.get('evidence') is None
                    and capture.get('reason') in ('COMBAT_STEPS_ABSENT', 'EMPTY_COMBAT_STEPS_NOT_ZERO_DAMAGE')
                    and row['event'] == 'dispatcher_combat_outcome' and 'response_identity' not in capture):
                unresolved.append((line, capture))
            else:
                return {}
        result = {}
        for line, capture in unresolved:
            candidates = [key for key, observation in by_key.items() if key not in used
                and observation.get('projection_status') == capture['status']
                and observation.get('projection_reason') == capture['reason']]
            # Every residual group must have one emitted row and one index key.
            if len(candidates) != 1 or sum(c['reason'] == capture['reason'] for _, c in unresolved) != 1:
                return {}
            key = candidates[0]; used.add(key)
            result[line] = dict(scope=dict(match_id=match, lifecycle_epoch=epoch, server_sequence=key[2]),
                raw_sha256=by_key[key]['raw_sha256'], basis='UNIQUE_COMPLETE_CAPTURE_METADATA_ACCOUNTING')
        return result if used == set(by_key) else {}
    except (ValueError, TypeError, KeyError):
        return {}


def outcome_exclusion_scopes(exclusions, rows):
    """Scope gaps with accepted boards, explicit identities or complete accounting.

    Unknown or conflicting scope still blocks every interval. Effects remain
    unavailable; neither log order nor approximate time proves separation.
    """
    by_line = dict(rows)
    reconciled = _legacy_metadata_scopes(rows)
    result = []
    for index, exclusion in enumerate(exclusions):
        line = exclusion.get('line')
        scope = None
        basis = None
        row = by_line.get(line, {}) if integer(line, 1) and 'lines' not in exclusion else {}
        try:
            capture = row.get('combatOutcome', {})
            if (type(capture) is not dict or capture.get('schema') != OUTCOME_SCHEMA
                    or capture.get('status') not in ('INVALID', 'UNAVAILABLE') or capture.get('evidence') is not None
                    or capture.get('input_authority') is not False
                    or capture.get('damage_prediction') is not False):
                raise ValueError('UNVERIFIED_OUTCOME_SCOPE')
            explicit = _response_scope(row, capture) if 'response_identity' in capture else None
            if explicit is not None and row.get('event') == 'dispatcher_combat_outcome':
                scope = explicit
                basis = 'EXPLICIT_IMMUTABLE_RESPONSE_IDENTITY'
            elif line in reconciled:
                scope = reconciled[line]['scope']
                basis = reconciled[line]['basis']
            if scope is not None:
                result.append(dict(exclusion_index=index, line=line, scope=scope, scope_basis=basis))
                continue
            if (row.get('event') != 'dispatcher_board_snapshot_offered'
                    or row.get('accepted') is not True or type(row.get('completeCells')) is not int
                    or row['completeCells'] != 64 or row.get('eventType') not in RESPONSE_TYPES):
                raise ValueError('UNVERIFIED_OUTCOME_SCOPE')
            board = checked_retained(row.get('boardEvidence'))
            if (row.get('matchId') != board['match_id']
                    or not integer(row.get('lifecycleEpoch'), 1)
                    or row['lifecycleEpoch'] != board['lifecycle_epoch']
                    or not integer(row.get('srvSeq'), 0, 10000000)
                    or row['srvSeq'] != board['server_sequence']
                    or capture.get('post_board_hash') != board['board_hash']):
                raise ValueError('UNVERIFIED_OUTCOME_SCOPE')
            scope = {key: board[key] for key in ('match_id', 'lifecycle_epoch', 'server_sequence')}
            if explicit is not None and explicit != scope:
                scope = None
                raise ValueError('CONFLICTING_RESPONSE_BOARD_SCOPE')
            basis = 'EXACT_ACCEPTED_BOARD'
        except (ValueError, TypeError, KeyError):
            pass
        result.append(dict(exclusion_index=index, line=line, scope=scope, scope_basis=basis))
    return result


def exclusion_affects_interval(item, before_line, before, after_line, after):
    if item['scope'] is None:
        return True
    if before_line <= item['line'] <= after_line:
        return True
    scope = item['scope']
    return (scope['match_id'] == before['match_id']
        and scope['lifecycle_epoch'] == before['lifecycle_epoch']
        and before['server_sequence'] < scope['server_sequence'] <= after['server_sequence'])


def extract(path):
    path = Path(path)
    if path.stat().st_size > 64*1024*1024:
        raise ValueError('BOUNDED_COMBAT_FILE_REQUIRED')
    raw = path.read_bytes()
    if len(raw) > 64*1024*1024:
        raise ValueError('BOUNDED_COMBAT_FILE_REQUIRED')
    rows = []; excluded = []; states = []; retained = []
    for line, string in enumerate(raw.decode('utf-8-sig').splitlines(), 1):
        if not string.strip():
            continue
        try:
            if len(string.encode('utf-8')) > 2*1024*1024:
                raise ValueError('LINE_TOO_LARGE')
            row = json.loads(string)
            if type(row) is not dict:
                raise ValueError('ROW_NOT_OBJECT')
            rows.append((line, row))
            if 'stateEvidence' in row:
                if len(states) >= MAX_STATE_RECORDS:
                    raise ValueError('STATE_RECORD_LIMIT_REACHED')
                states.append((line, checked_state(row['stateEvidence'])))
            if 'boardEvidence' in row:
                retained.append((line, checked_retained(row['boardEvidence'])))
        except (ValueError, TypeError, KeyError) as exc:
            excluded.append(dict(line=line, reason=str(exc)[:100]))
    outcomes = extract_outcomes(path)
    scopes = outcome_exclusion_scopes(outcomes['excluded'], rows)
    responses = outcomes['observations']
    intervals = []; unbound = []
    for response in responses:
        if response['actor_identity'] != 'BOSS':
            continue
        record = dict(match_id=response['match_id'], server_sequence=response['server_sequence'],
            raw_response_sha256=response['provenance']['raw_response_sha256'],
            outcome_lines=response['provenance']['outcome_lines'], input_authority=False,
            training_eligible=False)
        operations = response.get('swap_operations')
        if type(operations) is not list or len(operations) != 1:
            unbound.append(dict(record, reason='NOT_EXACTLY_ONE_CAPTURED_BOSS_SWAP'))
            continue
        match = response['match_id']; seq = response['server_sequence']
        candidates = []
        for before_line, before in states:
            if (before['match_id'] != match or before['actor_identity'] != 'BOSS'
                    or before['server_sequence'] >= seq):
                continue
            for after_line, after in states:
                if (after_line > before_line and after['match_id'] == match
                        and after['lifecycle_epoch'] == before['lifecycle_epoch']
                        and after['board_instance'] == before['board_instance']
                        and after['local_identity'] == before['local_identity']
                        and after['actor_identity'] == after['local_identity']
                        and after['turn'] == before['turn'] + 1 and after['server_sequence'] == seq):
                    candidates.append((before_line, before, after_line, after))
        # Repeated identical samples are harmless; different boards, resources,
        # sequences or sessions for this interval require investigation.
        unique = {}
        for candidate in candidates:
            key = (json.dumps(candidate[1], sort_keys=True), json.dumps(candidate[3], sort_keys=True))
            unique.setdefault(key, candidate)
        if len(unique) != 1:
            unbound.append(dict(record, reason='MISSING_PUBLISHED_BOSS_BOUNDARIES' if not unique
                else 'AMBIGUOUS_PUBLISHED_BOSS_BOUNDARIES'))
            continue
        before_line, before, after_line, after = next(iter(unique.values()))
        other = [r for r in responses if r is not response and r['match_id'] == match
            and before['server_sequence'] < r['server_sequence'] <= seq]
        if other:
            unbound.append(dict(record, reason='MULTIPLE_CAPTURED_ACTIONS_IN_INTERVAL'))
            continue
        if (any(exclusion_affects_interval(e, before_line, before, after_line, after) for e in scopes)
                or any(before_line <= e['line'] <= after_line for e in excluded)
                or any(before_line < n < after_line and r.get('event') == 'action_sent' for n, r in rows)):
            unbound.append(dict(record, reason='INVALID_OR_LOCAL_INPUT_IN_BOSS_INTERVAL'))
            continue
        native = operations[0]['native_swap']
        swap = [[7-native[0], native[1]], [7-native[2], native[3]]]
        intervals.append(dict(record, status='OBSERVED_PUBLISHED_STATE_INTERVAL',
            before=before, after=after, before_line=before_line, after_line=after_line,
            operation_index=operations[0]['operation_index'], native_swap=native, screen_swap=swap,
            effects=response['steps'], whole_action_completeness='UNKNOWN',
            excluded_outcomes_proven_outside_interval=[e['exclusion_index'] for e in scopes],
            boss_decision_authority='UNKNOWN_SINGLE_SWAP_OPERATION_OBSERVED',
            optimal_move_label=None, refill_model=None))
    return dict(path=str(path), sha256=hashlib.sha256(raw).hexdigest(),
        published_states=len(states), retained_boards=len(retained), intervals=intervals,
        unbound=unbound, excluded=excluded, outcome_exclusions=outcomes['excluded'],
        outcome_exclusion_scopes=scopes,
        unscoped_outcome_exclusions=sum(e['scope'] is None for e in scopes))


def summarize(cases):
    return dict(schema='pokiguard.boss_board_interval_corpus.v1', files=len(cases),
        published_states=sum(c['published_states'] for c in cases),
        retained_boards=sum(c['retained_boards'] for c in cases),
        observed_intervals=sum(len(c['intervals']) for c in cases),
        unbound=dict(Counter(r['reason'] for c in cases for r in c['unbound'])),
        invalid_board_or_state_records=sum(len(c['excluded']) for c in cases),
        models_fitted=0, training_eligible=0, process_attachment=False, windows_input=False)


def main():
    p = argparse.ArgumentParser(__doc__)
    p.add_argument('--combat', type=Path, action='append', required=True)
    p.add_argument('--out', type=Path, required=True)
    args = p.parse_args()
    cases = [extract(path) for path in sorted(set(args.combat))]
    out = args.out.resolve()
    if not out.is_relative_to(ROOT):
        raise ValueError('OUTPUT_INSIDE_V2_REQUIRED')
    out.parent.mkdir(parents=True, exist_ok=True)
    summary = summarize(cases)
    with out.open('x', encoding='utf-8') as stream:
        json.dump(dict(summary=summary, cases=cases), stream, indent=2)
    print(json.dumps(summary))


if __name__ == '__main__':
    main()
