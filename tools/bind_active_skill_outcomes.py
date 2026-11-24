"""File-only observed skill response joins, separate from legacy SWAP output.

Uses an actual primitive click plus exact controller action identity and a
unique actor/card/sequence response. It does not certify server action echoes,
whole-action effect coverage, damage models, training labels or input authority.
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
from pokiguard_v2.combat_outcome_evidence import actor_identity
from pokiguard_v2.skill_action_evidence import MAX_CONTEXT_BYTES, SCHEMA as CONTEXT_SCHEMA
from tools.audit_active_skill_inventory import (
    analyze_rows, combat_index, controller_join, digest, integer, read_rows, sha_file,
)
from tools.normalize_action_outcomes import extract as extract_legacy, hash_value, text

SCHEMA = 'pokiguard.active_skill_response_observation.v1'
MAX_PRIMITIVES = 256
MAX_PRIMITIVE_BYTES = 8 * 1024 * 1024


def check_context(context, source, record):
    """Optional controller checkpoint is not final click or effect-time state."""
    if context is None or (type(context) is dict and context.get('status') == 'UNAVAILABLE'):
        return None
    if (type(context) is not dict or context.get('schema') != CONTEXT_SCHEMA
            or context.get('status') != 'RECORDED' or context.get('input_authority') is not False
            or context.get('calibration_eligible') is not False):
        raise ValueError('SKILL_CONTEXT_SHAPE')
    raw = deepcopy(context)
    claimed = raw.pop('context_sha256', None)
    encoded = json.dumps(raw, sort_keys=True, separators=(',', ':'), ensure_ascii=True).encode()
    if claimed != hashlib.sha256(encoded).hexdigest():
        raise ValueError('SKILL_CONTEXT_HASH')
    if len(json.dumps(context, ensure_ascii=True, separators=(',', ':')).encode()) > MAX_CONTEXT_BYTES:
        raise ValueError('SKILL_CONTEXT_BYTE_LIMIT')
    sanitized = deepcopy(source)
    sanitized['actor_identity'] = actor_identity(sanitized.pop('current_turn_player'))
    if context.get('source') != sanitized or context.get('skill_card_id') != record['skill_card_id']:
        raise ValueError('SKILL_CONTEXT_SOURCE')
    cost = context.get('costs') or {}
    if [cost.get('mana'), cost.get('rage')] != record['effective_cost']:
        raise ValueError('SKILL_CONTEXT_COST_CHANGED_BEFORE_CLICK')
    return deepcopy(context)


def _valid_source(source, record):
    if type(source) is not dict or type(source.get('session')) is not dict:
        return False
    return (source['session'].get('match_id') == record['match_id']
            and digest(source['session']) == record['session_key_sha256']
            and integer(source.get('turn')) and source['turn'] > 0
            and source.get('turn') == record['source_turn']
            and integer(source.get('srv_seq'))
            and hash_value(source.get('board_hash')) and hash_value(source.get('critical_state_hash'))
            and text(source.get('current_turn_player')))


def _phase(capability):
    value = dict(next=capability.get('skill_phase_next'), maximum=capability.get('skill_phase_max'),
                 source=capability.get('skill_phase_source'))
    if (type(value['next']) is int and type(value['maximum']) is int
            and 1 <= value['next'] <= value['maximum'] <= 16
            and type(value['source']) is str and value['source']):
        return dict(status='OBSERVED_BEFORE_CLICK', **value)
    return dict(status='UNKNOWN', next=None, maximum=None, source=None)


def prepare_candidates(path, rows, index):
    primitives = sorted(path.parent.glob('pet_skill_*.jsonl'))
    if len(primitives) > MAX_PRIMITIVES:
        return [], [dict(reason='PRIMITIVE_FILE_LIMIT')], []
    candidates, excluded, manifest, seen_hashes = [], [], [], set()
    for primitive in primitives:
        if primitive.stat().st_size > MAX_PRIMITIVE_BYTES:
            excluded.append(dict(path=str(primitive), reason='PRIMITIVE_BYTE_LIMIT'))
            continue
        sha = sha_file(primitive)
        if sha in seen_hashes:
            continue
        seen_hashes.add(sha)
        parsed, errors = read_rows(primitive)
        manifest.append(dict(path=str(primitive), sha256=sha, malformed_lines=errors))
        if errors:
            excluded.append(dict(path=str(primitive), reason='MALFORMED_PRIMITIVE'))
            continue
        by_line = dict(parsed)
        for record in analyze_rows(parsed):
            joined = controller_join(record, index)
            if not joined['controller_join_verified']:
                continue
            start = dict(rows)[joined['controller_start_line']]
            end = dict(rows)[joined['controller_result_line']]
            source = (end.get('identity') or {}).get('source')
            if not _valid_source(source, record) or end.get('inputSent') is not True:
                excluded.append(dict(action_key=record['action_key'], reason='SKILL_SOURCE_OR_INPUT_UNVERIFIED'))
                continue
            try:
                context = check_context(start.get('skillActionContext'), source, record)
            except (ValueError, TypeError, KeyError) as exc:
                excluded.append(dict(action_key=record['action_key'], reason=str(exc)))
                continue
            cap = by_line[record['capability_line']]['capability']
            post_caps = [d['capability'] for n, d in parsed
                         if record['click_line'] < n < record['result_line']
                         and d.get('event') == 'pet_skill_capability_observed'
                         and type(d.get('capability')) is dict]
            result = by_line[record['result_line']]['result']
            post = result.get('post_state')
            candidates.append(dict(record=record, source=source, start_line=joined['controller_start_line'],
                result_line=joined['controller_result_line'], context=context, phase=_phase(cap),
                post_battle=post.get('battle') if type(post) is dict else None,
                post_capability=post_caps[-1] if post_caps else None,
                primitive_sha256=sha, primitive_path=str(primitive),
                actor=actor_identity(source['current_turn_player'])))
    grouped = defaultdict(list)
    for candidate in candidates:
        grouped[candidate['record']['action_key']].append(candidate)
    for key, group in grouped.items():
        if len(group) != 1:
            excluded.append(dict(action_key=key, reason='CONFLICTING_PRIMITIVE_ACTION_ID'))
    return [g[0] for g in grouped.values() if len(g) == 1], excluded, manifest


def _window(candidate, rows, observation):
    start, source = candidate['start_line'], candidate['source']
    line = min(observation['provenance']['outcome_lines'])
    if not start < line or not source['srv_seq'] < observation['server_sequence']:
        return False
    following = [(n, r) for n, r in rows if n > start
                 and r.get('event') in {'action_sent', 'pet_skill_dispatch_started'}]
    if following:
        n, row = following[0]
        if not line < n:
            return False
        other = (row.get('identity') or {}).get('source') or {}
        if other.get('session') != source['session'] or not integer(other.get('srv_seq')):
            return False
        if not source['srv_seq'] < observation['server_sequence'] <= other['srv_seq']:
            return False
    return True


def _client_anchor(candidate, observation, exports):
    """Stronger host anchors for a separately labelled, opt-in observation.

    This never invents a wire card ID. Terminal partial snapshots are excluded.
    """
    c, r = candidate, candidate['record']
    cap, battle = c.get('post_capability'), c.get('post_battle')
    if (c['context'] is None or not r['resource_endpoint_consistent']
            or type(cap) is not dict or type(battle) is not dict):
        return False
    if not (cap.get('status') == 'CURRENT' and cap.get('ownership_current') is True
            and cap.get('skill_card_id') == r['skill_card_id']
            and cap.get('session_key') == c['source']['session']
            and battle.get('session_key') == c['source']['session']
            and battle.get('match_id') == observation['match_id']
            and type(battle.get('srv_seq')) is int
            and battle['srv_seq'] == observation['server_sequence']
            and battle.get('is_local_turn') is False):
        return False
    return any(x.get('event') == 'pet_skill_retained_outcome'
               and x.get('sourceSession') == c['source']['session']
               and type(x.get('sourceTurn')) is int and x['sourceTurn'] == r['source_turn']
               and type(x.get('sourceSrvSeq')) is int and x['sourceSrvSeq'] == c['source']['srv_seq']
               for x in exports)


def _blocking_legacy_exclusions(observation, candidates, rows, excluded):
    """A known missing MOVE body outside this skill window is not corruption."""
    by_line = dict(rows)
    relevant = [c for c in candidates if c['record']['match_id'] == observation['match_id']
                and c['actor'] == observation['actor_identity'] and _window(c, rows, observation)]
    for error in excluded:
        line = error.get('line')
        row = by_line.get(line, {})
        capture = row.get('combatOutcome')
        identity = capture.get('response_identity') if type(capture) is dict else None
        known_missing_move = (error.get('reason') == 'NOT_CAPTURED_OBSERVATION'
            and type(capture) is dict and capture.get('status') == 'UNAVAILABLE'
            and capture.get('input_authority') is False and type(identity) is dict
            and identity.get('event_type') == 'MATCH_MOVE_RES'
            and integer(identity.get('server_sequence')) and hash_value(identity.get('raw_sha256')))
        if not known_missing_move:
            return True
        if any(identity.get('match_id') == observation['match_id'] and (
                c['start_line'] < line <= min(observation['provenance']['outcome_lines'])
                or c['source']['srv_seq'] < identity['server_sequence'] <= observation['server_sequence'])
                for c in relevant):
            return True
    return False


def join(observation, candidates, all_skill_observations, rows, *, client_window=False):
    empty = dict(status='UNBOUND', reason='NO_VERIFIED_CLICK_SOURCE', acknowledged=False,
                 server_action_echo=False, input_authority=False)
    ids = observation.get('card_ids')
    missing_both = type(ids) is dict and ids.get('skillCardId') is None and ids.get('cardId') is None
    client_only = client_window and missing_both
    if not client_only and (type(ids) is not dict or type(ids.get('skillCardId')) is not int or ids['skillCardId'] < 0):
        return dict(empty, reason='EXPLICIT_SKILL_CARD_ID_MISSING'), None
    # cardId is not guessed to mean skillCardId; conflicting supplied values are
    # retained for investigation instead of selecting the convenient field.
    if ids.get('cardId') is not None and (type(ids['cardId']) is not int or ids['cardId'] != ids['skillCardId']):
        return dict(empty, reason='WIRE_CARD_IDS_DISAGREE'), None
    matched = []
    for c in candidates:
        r = c['record']
        if (observation['match_id'] != r['match_id'] or observation['actor_identity'] != c['actor']
                or not client_only and ids['skillCardId'] != r['skill_card_id']
                or not _window(c, rows, observation)):
            continue
        # New retained exports carry the exact host session that requested the
        # snapshot. It is diagnostic scope, never a wire echo from the server.
        exports = [dict(rows)[n] for n in observation['provenance']['outcome_lines']]
        if any(x.get('sourceSession') is not None and x['sourceSession'] != c['source']['session'] for x in exports):
            continue
        if client_only and not _client_anchor(c, observation, exports):
            empty['reason'] = 'CLIENT_POST_SKILL_ANCHOR_UNAVAILABLE'
            continue
        peers = [o for o in all_skill_observations if o['match_id'] == r['match_id']
                 and o['actor_identity'] == c['actor'] and _window(c, rows, o)]
        if len(peers) != 1:
            return dict(empty, reason='MULTIPLE_SKILL_RESPONSES_IN_ACTION_WINDOW'), None
        matched.append(c)
    if len(matched) != 1:
        return dict(empty, reason='AMBIGUOUS_SKILL_SOURCE' if matched else empty['reason']), None
    c = matched[0]
    source = deepcopy(c['source'])
    source['actor_identity'] = actor_identity(source.pop('current_turn_player'))
    return dict(status='OBSERVED_CLIENT_CARD_WINDOW' if client_only else 'OBSERVED_SKILL_RESPONSE_MATCH',
        reason='CLIENT_CARD_AND_EXACT_POST_RESPONSE_ANCHOR_NOT_WIRE_CARD_PROOF' if client_only
            else 'UNIQUE_CLICK_ACTOR_CARD_SEQUENCE_LOG_WINDOW_NOT_WIRE_ACTION_ECHO',
        wire_card_identity='UNKNOWN' if client_only else 'EXPLICIT_MATCH',
        acknowledged=False, server_action_echo=False, input_authority=False,
        action_key=c['record']['action_key'], action_id=c['record']['action_id'],
        source=source, skill_card_id=c['record']['skill_card_id'],
        dispatch_start_line=c['start_line'], dispatch_result_line=c['result_line']), c


def bind_file(path, *, review_client_windows=False):
    path = Path(path)
    legacy = extract_legacy(path)
    rows, errors = read_rows(path)
    index = combat_index(path)
    candidates, excluded, manifest = prepare_candidates(path, rows, index)
    skills = [o for o in legacy['observations'] if o['event_type'] == 'MATCH_SKILL_USE_RES']
    output, client_output = [], []
    for observation in skills:
        blocked = errors or excluded or _blocking_legacy_exclusions(observation, candidates, rows, legacy['excluded'])
        if blocked:
            binding, c = (dict(status='UNBOUND', reason='INVALID_OR_CONFLICTING_INPUT_EVIDENCE',
                acknowledged=False, server_action_echo=False, input_authority=False), None)
        else:
            binding, c = join(observation, candidates, skills, rows)
        record = dict(schema=SCHEMA, match_id=observation['match_id'],
            server_sequence=observation['server_sequence'], actor_identity=observation['actor_identity'],
            skill_action_binding=binding, ordered_steps=deepcopy(observation['steps']),
            observed_effect_totals=deepcopy(observation['effect_totals']),
            pre_skill_context=None if c is None else c['context'], effect_time_context=None,
            final_card_before_click=None if c is None else dict(family=c['record']['family'],
                effective_cost=c['record']['effective_cost'], cost_sources=c['record']['cost_sources'], phase=c['phase']),
            resource_endpoint=None if c is None or not c['record']['resource_endpoint_consistent'] else dict(
                before=c['record']['resources_before'], after=c['record']['resources_after'],
                net_delta=c['record']['resource_net_delta'], scope='OBSERVED_NET_NOT_COST_OR_REFUND'),
            provenance=dict(combat_sha256=legacy['sha256'], response=deepcopy(observation['provenance']),
                primitive_sha256=None if c is None else c['primitive_sha256']),
            complete_action_coverage='UNKNOWN', calibration_eligible=False, training_eligible=False,
            input_authority=False, prediction=None)
        output.append(record)
        if review_client_windows:
            ids = observation.get('card_ids') or {}
            if ids.get('skillCardId') is None and ids.get('cardId') is None:
                cb, cc = (binding, None) if blocked else join(observation, candidates, skills, rows, client_window=True)
                client_record = deepcopy(record)
                client_record.update(skill_action_binding=cb,
                    association_scope='OPT_IN_CLIENT_WINDOW_NOT_EXPLICIT_WIRE_CARD_BINDING',
                    pre_skill_context=None if cc is None else cc['context'],
                    final_card_before_click=None if cc is None else dict(family=cc['record']['family'],
                        effective_cost=cc['record']['effective_cost'], cost_sources=cc['record']['cost_sources'], phase=cc['phase']),
                    resource_endpoint=None if cc is None else dict(before=cc['record']['resources_before'],
                        after=cc['record']['resources_after'],net_delta=cc['record']['resource_net_delta'],
                        scope='OBSERVED_NET_NOT_COST_OR_REFUND'))
                if cc is not None:
                    client_record['provenance']['primitive_sha256'] = cc['primitive_sha256']
                client_output.append(client_record)
    result = dict(schema='pokiguard.active_skill_binding_audit.v1', legacy=legacy,
        skill_observations=output, candidate_click_actions=len(candidates), excluded_skill_inputs=excluded,
        primitive_manifest=manifest,
        summary=dict(responses=len(output), matched=sum(o['skill_action_binding']['status']=='OBSERVED_SKILL_RESPONSE_MATCH' for o in output),
            by_reason=dict(Counter(o['skill_action_binding']['reason'] for o in output)),
            training_eligible=0, models_fitted=0, process_attachment=False, windows_input=False))
    if review_client_windows:
        result['client_card_window_observations'] = client_output
        result['summary']['client_window_matched'] = sum(o['skill_action_binding']['status']=='OBSERVED_CLIENT_CARD_WINDOW' for o in client_output)
    return result


def main():
    p = argparse.ArgumentParser(__doc__)
    p.add_argument('--combat', type=Path, required=True)
    p.add_argument('--out', type=Path, required=True)
    p.add_argument('--review-client-windows', action='store_true',
                   help='separate weaker client-card observations; never replace strict wire-card results')
    args = p.parse_args()
    out = args.out.resolve()
    if not out.is_relative_to(ROOT):
        p.error('output must stay inside PokiguardToolV2')
    result = bind_file(args.combat, review_client_windows=args.review_client_windows)
    out.parent.mkdir(parents=True, exist_ok=True)
    with out.open('x', encoding='utf-8') as stream:
        json.dump(result, stream, ensure_ascii=False, indent=2)
    print(json.dumps(result['summary']))


if __name__ == '__main__':
    main()
