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
from tools.normalize_action_outcomes import extract as extract_outcomes, integer, hash_value, actor, text


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
        if (outcomes['excluded'] or any(before_line <= e['line'] <= after_line for e in excluded)
                or any(before_line < n < after_line and r.get('event') == 'action_sent' for n, r in rows)):
            unbound.append(dict(record, reason='INVALID_OR_LOCAL_INPUT_IN_BOSS_INTERVAL'))
            continue
        native = operations[0]['native_swap']
        swap = [[7-native[0], native[1]], [7-native[2], native[3]]]
        intervals.append(dict(record, status='OBSERVED_PUBLISHED_STATE_INTERVAL',
            before=before, after=after, before_line=before_line, after_line=after_line,
            operation_index=operations[0]['operation_index'], native_swap=native, screen_swap=swap,
            effects=response['steps'], whole_action_completeness='UNKNOWN',
            boss_decision_authority='UNKNOWN_SINGLE_SWAP_OPERATION_OBSERVED',
            optimal_move_label=None, refill_model=None))
    return dict(path=str(path), sha256=hashlib.sha256(raw).hexdigest(),
        published_states=len(states), retained_boards=len(retained), intervals=intervals,
        unbound=unbound, excluded=excluded, outcome_exclusions=outcomes['excluded'])


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
