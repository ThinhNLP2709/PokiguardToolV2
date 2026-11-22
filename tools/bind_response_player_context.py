"""Bind saved optional player fields to their exact response and existing ACK.

Response context remains post/unspecified-phase observation. No carry-forward,
nearest-time matching, initial-probe import, prediction or process access.
"""
from collections import Counter, defaultdict
from copy import deepcopy
import argparse
import hashlib
import json
from pathlib import Path
import sys

ROOT = Path(__file__).resolve().parents[1]
sys.path[:0] = [str(ROOT), str(ROOT / 'src')]
from pokiguard_v2.combat_outcome_evidence import SCHEMA as CAPTURE_SCHEMA, RESPONSE_IDENTITY_SCHEMA
from pokiguard_v2.combat_player_context import validate_player_context, encoded, valid_hash
from tools.normalize_action_outcomes import checked, extract


def identity(record):
    if (type(record) is not dict or record.get('schema') != CAPTURE_SCHEMA
            or record.get('input_authority') is not False):
        raise ValueError('CONTEXT_CAPTURE_SCHEMA')
    if record.get('status') == 'CAPTURED':
        return checked(record)
    source = record.get('response_identity')
    if (record.get('status') != 'UNAVAILABLE' or type(source) is not dict
            or source.get('schema') != RESPONSE_IDENTITY_SCHEMA
            or source.get('effect_evidence') is not False or source.get('input_authority') is not False
            or source.get('source') != 'EXISTING_IMMUTABLE_JSON_VALIDATED_MATCH_SEQUENCE'):
        raise ValueError('CONTEXT_WITHOUT_VERIFIED_RESPONSE_IDENTITY')
    return source


def key(value):
    return tuple(value[k] for k in ('match_id', 'server_sequence', 'event_type', 'raw_sha256'))


def bind_file(path):
    path = Path(path)
    if path.stat().st_size > 64 * 1024 * 1024: raise ValueError('BOUNDED_COMBAT_FILE_REQUIRED')
    raw = path.read_bytes()
    if len(raw) > 64 * 1024 * 1024: raise ValueError('BOUNDED_COMBAT_FILE_REQUIRED')
    digest = hashlib.sha256(raw).hexdigest()
    normalized = extract(path)
    if normalized['sha256'] != digest: raise ValueError('INPUT_CHANGED_DURING_CONTEXT_BINDING')
    observations = defaultdict(list)
    for o in normalized['observations']:
        observations[o['match_id'], o['server_sequence'], o['event_type'],
                     o['provenance']['raw_response_sha256']].append(o)
    groups = defaultdict(list)
    excluded = []
    for line, text in enumerate(raw.decode('utf-8-sig').splitlines(), 1):
        if not text.strip(): continue
        try:
            if len(text.encode('utf-8')) > 2 * 1024 * 1024: raise ValueError('LINE_TOO_LARGE')
            row = json.loads(text)
            capture = row.get('combatOutcome') if type(row) is dict else None
            if type(capture) is not dict or 'player_context' not in capture: continue
            source = identity(capture)
            context = capture['player_context']
            validate_player_context(context, **{k: source[k] for k in
                ('match_id', 'server_sequence', 'event_type', 'raw_sha256')})
            groups[key(source)].append((line, context, capture['status']))
        except (ValueError, KeyError, TypeError, OverflowError) as exc:
            excluded.append(dict(line=line, reason=str(exc)[:100]))
    bindings = []
    for response, group in groups.items():
        # Missing/omitted optional context in a duplicate does not contradict
        # its captured counterpart. Two different captured views do conflict.
        captured = [v for v in group if v[1]['status'] == 'CAPTURED']
        choices = captured or group
        if len({encoded(c) for _, c, _ in choices}) != 1:
            excluded.append(dict(lines=[v[0] for v in group], reason='CONFLICTING_RESPONSE_CONTEXT'))
            continue
        _, context, capture_status = choices[0]
        obs = observations.get(response, [])
        if len(obs) > 1:
            excluded.append(dict(lines=[v[0] for v in group], reason='AMBIGUOUS_NORMALIZED_RESPONSE'))
            continue
        observation = obs[0] if obs else None
        binding = (deepcopy(observation['action_binding']) if observation else
            dict(status='UNBOUND', reason='NO_TYPED_EFFECT_BINDING', acknowledged=False, source=None))
        # Never borrow actor ownership from a different response or an actorNumber.
        response_actor = observation['actor_identity'] if observation else None
        actor_context = next((p for p in context['players'] if p['actor_identity'] == response_actor), None)
        targets = ({s['target'] for s in observation['steps'] if s['source'] == response_actor}
                   if observation else set())
        target_context = [p for p in context['players'] if p['actor_identity'] in targets]
        bindings.append(dict(match_id=response[0], server_sequence=response[1], event_type=response[2],
            raw_response_sha256=response[3], capture_status=capture_status,
            context_lines=[v[0] for v in group], context=deepcopy(context), action_binding=binding,
            response_actor_context=deepcopy(actor_context), response_target_context=deepcopy(target_context),
            pre_action_context=None, effect_time_context=None,
            context_scope='EXACT_RESPONSE_ONLY_NO_TEMPORAL_PROMOTION',
            calibration_eligible=False, training_eligible=False, prediction=None, input_authority=False))
    if hashlib.sha256(path.read_bytes()).hexdigest() != digest:
        raise ValueError('INPUT_CHANGED_DURING_CONTEXT_BINDING')
    return dict(path=str(path), sha256=digest, context_bindings=bindings,
        excluded=excluded, underlying_outcome_exclusions=normalized['excluded'])


def summarize(cases):
    unique = {}
    conflicts = set()
    for case in cases:
        for b in case['context_bindings']:
            identity = (b['match_id'], b['server_sequence'], b['event_type'])
            # Cross-file copies may have different physical line numbers.
            semantic = {k:v for k,v in b.items() if k != 'context_lines'}
            action = semantic['action_binding']
            semantic['action_binding'] = {k:v for k,v in action.items() if k != 'action_line'}
            if identity in unique and unique[identity] != semantic: conflicts.add(identity)
            unique.setdefault(identity, semantic)
    records = [b for k,b in unique.items() if k not in conflicts]
    return dict(files=len(cases), unique_response_contexts=len(records), conflicting_identities=len(conflicts),
        statuses=dict(Counter(b['context']['status'] for b in records)),
        action_bindings=dict(Counter(b['action_binding']['status'] for b in records)),
        pre_action_contexts=0, effect_time_contexts=0, calibration_eligible=0, models_fitted=0,
        new_game_inputs=0, process_attachment=False, training=False)


def main():
    p = argparse.ArgumentParser(__doc__)
    p.add_argument('--combat', type=Path, action='append', required=True)
    p.add_argument('--out', type=Path, required=True)
    args = p.parse_args()
    cases = [bind_file(path) for path in sorted(set(args.combat))]
    output = args.out.resolve()
    if not output.is_relative_to(ROOT): raise ValueError('OUTPUT_INSIDE_V2_REQUIRED')
    output.parent.mkdir(parents=True, exist_ok=True)
    with output.open('x', encoding='utf-8') as f:
        json.dump(dict(summary=summarize(cases), cases=cases), f, indent=2)
    print(json.dumps(summarize(cases)))


if __name__ == '__main__': main()
