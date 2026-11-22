"""File-only readiness audit for Demon damage/heal research, never a predictor.

Use the existing exact SWAP binder. An observed attack stat is not an avatar,
gear, element or crit certificate; first-wave counts are not full-action counts.
"""
from collections import Counter
from copy import deepcopy
import argparse
import hashlib
import json
from pathlib import Path
import sys

ROOT = Path(__file__).resolve().parents[1]
sys.path[:0] = [str(ROOT), str(ROOT / 'src')]
from tools.normalize_action_outcomes import extract, integer, source_of
from tools.normalize_combat_observations import first_wave

SCHEMA = 'pokiguard.demon_damage_context_audit.v1'


def full_power_state(step):
    """Only new explicit metadata can distinguish wire absence from null."""
    presence = step.get('full_power_presence')
    if presence == 'ABSENT': return 'WIRE_ABSENT'
    if presence == 'NULL': return 'WIRE_NULL'
    if presence == 'VALUE': return 'WIRE_TRUE' if step['full_power'] else 'WIRE_FALSE'
    if type(step.get('full_power')) is bool:
        return 'LEGACY_TRUE' if step['full_power'] else 'LEGACY_FALSE'
    return 'UNKNOWN_LEGACY_NULL_OR_ABSENT'


def stats_context(sent, key):
    stats = sent.get(key)
    if (type(stats) is not dict or stats.get('is_local') is not (key == 'player')
            or stats.get('is_boss') is not (key == 'boss')
            or stats.get('source') not in ('Active.playerStatsMap/ObfuscatedInt.Value',
                                          'Active.playerStatsList/ObfuscatedInt.Value')
            or not integer(stats.get('actor_number'), 1)):
        return dict(status='UNKNOWN_OWNERSHIP_OR_STATS_SOURCE', observed=None)
    names = ('hp', 'max_hp', 'mana', 'max_mana', 'power', 'max_power', 'attack', 'shield')
    values = {name: stats.get(name) if integer(stats.get(name), 0) else None for name in names}
    return dict(status='OBSERVED_STATS_NOT_COMPLETE_LOADOUT', source=stats['source'],
                observed=values, complete_numeric_fields=all(v is not None for v in values.values()))


def audit_file(path):
    path = Path(path)
    raw = path.read_bytes()
    digest = hashlib.sha256(raw).hexdigest()
    rows = [json.loads(line) for line in raw.decode('utf-8-sig').splitlines() if line.strip()]
    # action_line refers to physical file lines, including blanks.
    physical = raw.decode('utf-8-sig').splitlines()
    configurations = [r.get('config') for r in rows if r.get('event') == 'auto_controller_started']
    if (len(configurations) != 1 or type(configurations[0]) is not dict
            or configurations[0].get('play_style') != 'demon_aegis_farm'
            or configurations[0].get('damage_card') != 'pet_passive'):
        return dict(path=str(path), sha256=digest, records=[],
                    file_exclusions=['NOT_ONE_DECLARED_DEMON_PASSIVE_CONFIGURATION'])
    config = configurations[0]
    normalized = extract(path)
    if normalized['sha256'] != digest or hashlib.sha256(path.read_bytes()).hexdigest() != digest:
        raise ValueError('INPUT_CHANGED_DURING_AUDIT')
    records = []
    for obs in normalized['observations']:
        binding = obs['action_binding']
        if obs['actor_identity'] == 'BOSS': continue
        sent = None
        if binding.get('action_line') is not None:
            candidate = json.loads(physical[binding['action_line'] - 1])
            source = deepcopy(source_of(candidate))
            source.pop('current_turn_player')
            source['actor_identity'] = obs['actor_identity']
            if source != binding['source']:
                raise ValueError('ACTION_LINE_SOURCE_MISMATCH')
            sent = candidate
        blockers = ['WHOLE_ACTION_EFFECT_COMPLETENESS_UNKNOWN',
            'PET_AVATAR_GEAR_IDENTITIES_NOT_BOUND', 'ELEMENT_CRIT_BUFF_CONTEXT_UNKNOWN',
            'FULL_POWER_ACTIVATION_COST_AND_CROSS_LIST_ORDER_UNKNOWN']
        if binding['status'] != 'EXACT_SWAP_SENT_ACK': blockers.append('NO_EXACT_SWAP_SENT_ACK')
        steps = obs['steps']
        damages = [s for s in steps if s['kind'] == 'DAMAGE'
                   and s['source'] == obs['actor_identity'] and s['target'] == 'BOSS']
        heals = [s for s in steps if s['kind'] == 'HEAL'
                 and s['target'] == obs['actor_identity']]
        states = [dict(idx=s['idx'], state=full_power_state(s)) for s in damages]
        if any(s['state'].startswith(('LEGACY_', 'UNKNOWN_')) for s in states):
            blockers.append('FULL_POWER_WIRE_PRESENCE_NOT_RETAINED')
        if not damages: blockers.append('NO_RECORDED_LOCAL_TO_BOSS_DAMAGE_COMPONENT')
        if any(s['amount'] < 0 for s in damages + heals): blockers.append('NEGATIVE_COMPONENT_AMOUNT')
        wave = None
        if sent is not None:
            try:
                move = binding['action']['target']
                wave = first_wave(sent['boardSnapshot'], move, config.get('demon_target_gem'))
            except (ValueError, KeyError, TypeError):
                blockers.append('NO_VERIFIED_DECLARED_PASSIVE_FIRST_WAVE')
        else:
            blockers.append('NO_VERIFIED_DECLARED_PASSIVE_FIRST_WAVE')
        own = stats_context(sent or {}, 'player')
        boss = stats_context(sent or {}, 'boss')
        if any(s.get('complete_numeric_fields') is not True for s in (own, boss)):
            blockers.append('OBSERVED_STATS_INCOMPLETE')
        if obs['zero_hp_targets']: blockers.append('ZERO_HP_CENSORED')
        records.append(dict(match_id=obs['match_id'], server_sequence=obs['server_sequence'],
            event_type=obs['event_type'], source=binding.get('source'),
            action_binding_status=binding['status'], raw_response_sha256=obs['provenance']['raw_response_sha256'],
            action_line=binding.get('action_line'),
            declared_settings={k: config.get(k) for k in ('main_pet', 'evolution_target', 'demon_target_gem')},
            self_stats=own, boss_stats=boss, first_wave=wave,
            first_wave_scope='DECLARED_PASSIVE_NO_REFILL_OR_WHOLE_ACTION_CREDIT',
            damage_components=[dict(idx=s['idx'], amount=s['amount'], damage_source=s.get('damage_source')) for s in damages],
            observed_damage_component_sum=sum(s['amount'] for s in damages) if damages else None,
            observed_heal_component_sum=sum(s['amount'] for s in heals) if heals else None,
            missing_component_is_zero=False, full_power_states=states,
            zero_hp_targets=obs['zero_hp_targets'], calibration_blockers=blockers,
            calibration_eligible=False, training_eligible=False, prediction=None))
    return dict(path=str(path), sha256=digest, records=records,
        file_exclusions=[], normalization_excluded=normalized['excluded'])


def summarize(cases):
    # Copies of a response in archived profiles or runs cannot add samples.
    unique = {}
    conflicts = set()
    for case in cases:
        for record in case['records']:
            key = (record['match_id'], record['server_sequence'], record['event_type'])
            if key in unique and unique[key] != record: conflicts.add(key)
            unique.setdefault(key, record)
    records = [r for key, r in unique.items() if key not in conflicts]
    return dict(schema=SCHEMA, files=len(cases), unique_local_observations=len(records),
        conflicting_identities=len(conflicts), matches=len({r['match_id'] for r in records}),
        exact_swap_sent_ack=sum(r['action_binding_status'] == 'EXACT_SWAP_SENT_ACK' for r in records),
        known_declared_passive_first_wave=sum(r['first_wave'] is not None for r in records),
        complete_observed_stats=sum(all(r[k].get('complete_numeric_fields') is True
            for k in ('self_stats', 'boss_stats')) for r in records),
        damage_components=sum(len(r['damage_components']) for r in records),
        full_power_states=dict(Counter(s['state'] for r in records for s in r['full_power_states'])),
        calibration_blockers=dict(Counter(b for r in records for b in r['calibration_blockers'])),
        calibration_eligible=0, training_eligible=0, models_fitted=0,
        independent_holdout=False, input_authority=False, process_attachment=False, windows_input=False)


def main():
    p = argparse.ArgumentParser(__doc__)
    p.add_argument('--combat', type=Path, action='append', required=True)
    p.add_argument('--out', type=Path, required=True)
    args = p.parse_args()
    cases = [audit_file(path) for path in sorted(set(args.combat))]
    output = args.out.resolve()
    if not output.is_relative_to(ROOT): raise ValueError('OUTPUT_INSIDE_V2_REQUIRED')
    output.parent.mkdir(parents=True, exist_ok=True)
    with output.open('x', encoding='utf-8') as f:
        json.dump(dict(summary=summarize(cases), cases=cases), f, indent=2)
    print(json.dumps(summarize(cases)))


if __name__ == '__main__': main()
