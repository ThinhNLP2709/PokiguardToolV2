"""Normalize saved Demon move observations; never fit or activate damage models.

Only already logged boards, moves, ACKs and server steps are used. Destroyed
tags are compared with both physical and effective first-wave ledgers rather
than assumed to be either. All output remains observation-only.
"""
from collections import Counter
import argparse
import hashlib
import json
from pathlib import Path
import sys

ROOT = Path(__file__).resolve().parents[1]
sys.path[:0] = [str(ROOT), str(ROOT/'src')]
from pokiguard_v2.board_simulator import SimulatedCell, SwapMove, _match_through, _tallies
from pokiguard_v2.combat_outcome_evidence import actor_identity
from pokiguard_v2.demon_aegis import _passive_geometry, _swapped_grid
from pokiguard_v2.live_state import gem_for_tag
from pokiguard_v2.state import GemType, SUPPORTED_CELL_MULTIPLIERS


def first_wave(board, move, target):
    if type(board) is not list or len(board) != 8 or any(type(row) is not list or len(row) != 8 for row in board):
        raise ValueError('BOARD_SHAPE')
    grid = []
    for row in board:
        cells = []
        for cell in row:
            if type(cell) is not list or len(cell) != 2:
                raise ValueError('CELL_SHAPE')
            gem, multiplier = cell
            if GemType(gem) is GemType.UNKNOWN or type(multiplier) is not int or multiplier not in SUPPORTED_CELL_MULTIPLIERS:
                raise ValueError('UNKNOWN_CELL_OR_MULTIPLIER')
            cells.append(SimulatedCell(GemType(gem), multiplier))
        grid.append(tuple(cells))
    if (type(move) is not list or len(move) != 2
            or any(type(p) is not list or len(p) != 2 or any(type(v) is not int or not 0 <= v < 8 for v in p) for p in move)
            or sum(abs(a-b) for a, b in zip(*move)) != 1):
        raise ValueError('MOVE_DOMAIN')
    swap = SwapMove(*(tuple(p) for p in move))
    swapped = _swapped_grid(tuple(grid), swap)
    direct = _match_through(swapped, swap.first) | _match_through(swapped, swap.second)
    if (grid[swap.first[0]][swap.first[1]].gem is grid[swap.second[0]][swap.second[1]].gem
            or not direct):
        raise ValueError('ILLEGAL_SWAP')
    target = GemType(target)
    if target not in (GemType.SHIELD, GemType.HEALTH, GemType.MANA, GemType.DRAIN, GemType.RAGE):
        raise ValueError('UNSUPPORTED_PASSIVE_TARGET')
    matched, blast, physical, effective = _passive_geometry(tuple(grid), swap, target)
    if not matched:
        raise ValueError('NOT_A_KNOWN_DEMON_ACTIVATION')
    resources = _tallies(swapped, set(blast) | direct)
    gems = tuple(g for g in GemType if g is not GemType.UNKNOWN)
    return dict(physical={g.value: resources.cells(g) for g in gems},
        effective={g.value: resources.effective(g) for g in gems},
        passive_sword_cells=physical, passive_sword_effective=effective,
        kind='EXISTING_SOLVER_FIRST_WAVE_NO_REFILL_CREDIT')


def normalize(sent, record, *, target, acknowledged):
    """Produce a scoped observation; statistical/model eligibility stays false."""
    source = sent['identity']['source']
    evidence = record.get('evidence')
    if (record.get('schema') != 'pokiguard.combat_outcome_evidence.v1'
            or record.get('status') != 'CAPTURED' or type(evidence) is not dict):
        raise ValueError('NO_CAPTURED_EFFECTS')
    actor = actor_identity(source['current_turn_player'])
    if (actor == 'BOSS' or sent['identity'].get('action') != 'swap'
            or source['session']['match_id'] != evidence.get('match_id')
            or sent['matchId'] != evidence['match_id']
            or actor != evidence.get('actor_identity')
            or evidence.get('event_type') != 'MATCH_MOVE_RES'
            or type(source.get('srv_seq')) is not int or source['srv_seq'] < 0
            or type(evidence.get('server_sequence')) is not int
            or evidence['server_sequence'] <= source['srv_seq']):
        raise ValueError('SOURCE_IDENTITY_OR_SEQUENCE_MISMATCH')
    if (sent.get('boardSnapshotOrder') != 'screen_rows_top_to_bottom_columns_left_to_right'
            or not source.get('board_hash') or type(source.get('turn')) is not int
            or type(sent.get('turn')) is not int
            or sent.get('boardHash') != source['board_hash'] or sent.get('turn') != source['turn']):
        raise ValueError('SOURCE_BOARD_OR_TURN_MISMATCH')
    move = [sent['move']['first'], sent['move']['second']]
    if sent['identity'].get('target') != move:
        raise ValueError('INPUT_TARGET_MISMATCH')
    ledger = first_wave(sent['boardSnapshot'], move, target)
    tags = evidence.get('destroyed_by_tag')
    if type(tags) is not dict:
        raise ValueError('DESTROYED_TAGS_UNKNOWN')
    observed = {g: 0 for g in ledger['effective']}
    for tag, amount in tags.items():
        if type(tag) is not str:
            raise ValueError('DESTROYED_TAG_DOMAIN')
        gem = gem_for_tag(tag)
        if gem is GemType.UNKNOWN or type(amount) is not int or amount < 0:
            raise ValueError('DESTROYED_TAG_DOMAIN')
        observed[gem.value] += amount
    steps = evidence.get('steps')
    if type(steps) is not list or not 0 < len(steps) <= 128:
        raise ValueError('STEP_SHAPE')
    if any(type(s) is not dict or type(s.get('idx')) is not int or s['idx'] < 0
            or type(s.get('amount')) is not int
            or (s.get('after') is not None and type(s['after']) is not dict)
            or (s.get('full_power') is not None and type(s['full_power']) is not bool)
            for s in steps):
        raise ValueError('STEP_FIELD_TYPE')
    if any(a['idx'] >= b['idx'] for a, b in zip(steps, steps[1:])):
        raise ValueError('STEP_ORDER')
    damage = [s for s in steps if s.get('kind') == 'DAMAGE' and s.get('source') == actor and s.get('target') == 'BOSS']
    blocks = [s for s in steps if s.get('kind') == 'BLOCK' and s.get('source') == actor and s.get('target') == 'BOSS']
    if not damage or any(s['amount'] < 0 for s in damage + blocks):
        raise ValueError('NO_POSITIVE_ATTRIBUTABLE_DAMAGE')
    hp_before = sent['boss'].get('hp'); shield_before = sent['boss'].get('shield')
    hp_after = (damage[-1].get('after') or {}).get('HP')
    shield_after = (blocks[-1].get('after') or {}).get('SHIELD') if blocks else shield_before
    hp_damage = sum(s['amount'] for s in damage); blocked = sum(s['amount'] for s in blocks)
    weighted_match = observed == ledger['effective']
    physical_match = observed == ledger['physical']
    hp_consistent = type(hp_before) is int and type(hp_after) is int and hp_before - hp_after == hp_damage
    shield_consistent = (type(shield_before) is int and type(shield_after) is int
        and shield_before - shield_after == blocked)
    # Reconcile every recorded decrement, not just the endpoints. An omitted
    # intermediate heal/shield effect must not become an apparent clean sample.
    for effects, initial, key in ((damage, hp_before, 'HP'), (blocks, shield_before, 'SHIELD')):
        cursor = initial
        for step in effects:
            after = (step.get('after') or {}).get(key)
            consistent = (type(cursor) is int and cursor >= 0 and type(after) is int
                and after >= 0 and cursor - after == step['amount'])
            if key == 'HP': hp_consistent = hp_consistent and consistent
            else: shield_consistent = shield_consistent and consistent
            cursor = after
    blockers = []
    if not acknowledged: blockers.append('NO_SWAP_ACK')
    if [s['idx'] for s in steps] != list(range(len(steps))): blockers.append('INCOMPLETE_STEP_INDEX')
    if type(hp_after) is not int or hp_after <= 0: blockers.append('TERMINAL_OR_UNKNOWN_HP')
    if not hp_consistent: blockers.append('HP_LEDGER_MISMATCH')
    if not shield_consistent: blockers.append('SHIELD_LEDGER_MISMATCH')
    if not weighted_match: blockers.append('FIRST_WAVE_LEDGER_NOT_EQUAL_TO_SERVER_TAGS')
    if any(s.get('kind') in ('HEAL', 'SHIELD') and s.get('target') == 'BOSS' for s in steps):
        blockers.append('INTERVENING_BOSS_HP_OR_SHIELD_EFFECT')
    if len({s.get('damage_source') for s in damage}) != 1:
        blockers.append('MIXED_DAMAGE_SOURCES')
    if evidence.get('wire_swap') is not None:
        blockers.append('WIRE_COORDINATES_NOT_VERIFIED_BY_THIS_NORMALIZER')
    first_damage_idx = min(s['idx'] for s in damage)
    power = [s for s in steps if s.get('kind') == 'POWER' and s.get('source') == actor
        and s.get('target') == actor and s['idx'] < first_damage_idx]
    rage_before = sent['player'].get('power')
    power_after = (power[-1].get('after') or {}).get('POWER') if power else rage_before
    rage_gain = sum(s['amount'] for s in power)
    power_consistent = type(rage_before) is int and type(power_after) is int and rage_before + rage_gain == power_after
    if not power_consistent: blockers.append('POWER_LEDGER_MISMATCH')
    full_power = [s.get('full_power') for s in damage]
    swords = ledger['effective']['sword']
    return dict(schema='pokiguard.normalized_combat_observation.v1', match_id=evidence['match_id'],
        source_turn=source['turn'], source_sequence=source['srv_seq'], outcome_sequence=evidence['server_sequence'],
        actor_identity=actor, first_wave=ledger, server_destroyed=observed,
        matches_effective_ledger=weighted_match, matches_physical_ledger=physical_match,
        hp_damage=hp_damage, shield_blocked=blocked, hp_ledger_consistent=hp_consistent,
        shield_ledger_consistent=shield_consistent, hp_before=hp_before, hp_after=hp_after,
        observed_hp_damage_plus_blocked=hp_damage+blocked,
        observed_per_effective_sword=(hp_damage+blocked)/swords if swords and not blockers else None,
        ratio_kind='DESCRIPTIVE_OBSERVATION_NOT_PREDICTIVE_COEFFICIENT',
        power=dict(before=rage_before, added_before_damage=rage_gain, after=power_after,
            consistent=power_consistent, ordered_before_damage=bool(power), damage_full_power=full_power),
        damage_sources=[s.get('damage_source') for s in damage],
        usable_observation=not blockers, observation_blockers=blockers,
        calibration_eligible=False, input_authority=False,
        unverified=['WHOLE_ACTION_EFFECT_COMPLETENESS','EXACT_RUNTIME_PET_AND_LOADOUT','ELEMENT_CRIT_BUFF_CONTEXT',
            'DAMAGE_SOURCE_SUBTYPE','OUT_OF_SAMPLE_DAMAGE_BOUNDS'])


def extract(path):
    raw = path.read_bytes(); lines = raw.decode('utf-8-sig').splitlines()
    rows = [(i+1, json.loads(line)) for i, line in enumerate(lines) if line.strip()]
    configs = [row.get('config') for _, row in rows if row.get('event') == 'auto_controller_started']
    if len(configs) != 1 or type(configs[0]) is not dict:
        return dict(path=str(path), observations=[], excluded=[dict(reason='CONFIGURATION_MISSING_OR_AMBIGUOUS')])
    config = configs[0]
    if config.get('play_style') != 'demon_aegis_farm' or config.get('damage_card') != 'pet_passive':
        return dict(path=str(path), observations=[], excluded=[dict(reason='CONFIGURATION_NOT_DEMON_PASSIVE')])
    sends = [(n, r) for n, r in rows if r.get('event') == 'action_sent']
    results = [r for _, r in rows if r.get('event') == 'action_result']
    captures = [(n, r['combatOutcome']) for n, r in rows
        if type(r.get('combatOutcome')) is dict and r['combatOutcome'].get('status') == 'CAPTURED']
    observations = []; excluded = []
    for index, (line, sent) in enumerate(sends):
        if sent.get('selectedAction') != 'swap':
            continue
        source = sent['identity']['source']; actor = actor_identity(source['current_turn_player'])
        upper = sends[index+1][1]['identity']['source']['srv_seq'] if index+1 < len(sends) else None
        next_line = sends[index+1][0] if index+1 < len(sends) else len(lines)+1
        if upper is not None and upper <= source['srv_seq']:
            excluded.append(dict(source_turn=source['turn'], action_line=line, reason='NON_INCREASING_ACTION_SEQUENCE'))
            continue
        choices = {}
        conflicting_duplicate = False
        for number, capture in captures:
            e = capture.get('evidence')
            if type(e) is not dict:
                continue
            seq = e.get('server_sequence')
            if (line < number < next_line
                    and e.get('match_id') == source['session']['match_id'] and e.get('actor_identity') == actor
                    and type(seq) is int and source['srv_seq'] < seq and (upper is None or seq <= upper)):
                key = (seq, e.get('raw_sha256'))
                if key in choices and choices[key][1]['evidence'] != e:
                    conflicting_duplicate = True
                choices.setdefault(key, (number, capture))
        if len(choices) != 1 or conflicting_duplicate:
            excluded.append(dict(source_turn=source['turn'], action_line=line,
                reason='CONFLICTING_DUPLICATE' if conflicting_duplicate else 'MISSING_RESPONSE' if not choices else 'AMBIGUOUS_RESPONSE'))
            continue
        number, capture = next(iter(choices.values()))
        acknowledged = any(r.get('result') == 'SWAP_ACKNOWLEDGED'
            and r.get('action', {}).get('identity') == sent['identity'] for r in results)
        try:
            result = normalize(sent, capture, target=config.get('demon_target_gem'), acknowledged=acknowledged)
        except (ValueError, TypeError, KeyError, IndexError) as exc:
            excluded.append(dict(source_turn=source['turn'], action_line=line, outcome_line=number, reason=str(exc)))
            continue
        observations.append(dict(result, provenance=dict(combat_sha256=hashlib.sha256(raw).hexdigest(),
            action_line=line, outcome_line=number, action_line_sha256=hashlib.sha256(lines[line-1].encode()).hexdigest(),
            outcome_line_sha256=hashlib.sha256(lines[number-1].encode()).hexdigest(),
            join='UNIQUE_ACTOR_AND_SEQUENCE_INTERVAL_NOT_WIRE_COORDINATE_ECHO')))
    return dict(path=str(path), observations=observations, excluded=excluded)


def main():
    parser = argparse.ArgumentParser(__doc__)
    parser.add_argument('--combat', type=Path, action='append', required=True)
    parser.add_argument('--out', type=Path, required=True)
    args = parser.parse_args()
    cases = [extract(path) for path in args.combat]
    observations = [row for case in cases for row in case['observations']]
    output = dict(schema='pokiguard.normalized_combat_corpus.v1', cases=cases,
        observation_count=len(observations), usable_observations=sum(row['usable_observation'] for row in observations),
        excluded_reasons=dict(Counter(row['reason'] for case in cases for row in case['excluded'])),
        damage_model_fitted=False, input_authority=False)
    args.out.parent.mkdir(parents=True, exist_ok=True)
    with args.out.open('x', encoding='utf-8') as stream:
        json.dump(output, stream, indent=2)
    print(json.dumps({key: value for key, value in output.items() if key != 'cases'}))


if __name__ == '__main__':
    main()
