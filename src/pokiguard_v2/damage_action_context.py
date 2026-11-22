"""Pre-input mechanism descriptors for offline damage research only.

Reuse the existing solver; never insert refill, a server formula, FullPower
labels, response context or input authority. Counts are a conditional prefix,
not net resources or complete damage. This module is not used by gameplay.
"""
from .board_simulator import (
    _CellValue, SwapMove, _match_through, _tallies, _merge_results,
    _resolve_known_reply, _collapse, _matches_touching,
)
from .demon_aegis import _passive_geometry
from .damage_evaluation import TARGET, GEMS, digest, validate_features, input_complete
from .state import GemType

SCHEMA = 'pokiguard.pre_action_damage_mechanisms.v1'
REQUEST_KEYS = frozenset(('sample_id', 'feature_sha256', 'features', 'input_complete', 'target'))


def _hash(value):
    return (type(value) is str and len(value) == 64
            and all(c in '0123456789abcdef' for c in value))


def _counts(result):
    return {unit: {g: getattr(result, method)(GemType(g)) for g in sorted(GEMS)}
            for unit, method in (('physical', 'cells'), ('effective', 'effective'))}


def describe_action(request):
    """Accept exactly the label-free prediction request, not a whole sample."""
    if (type(request) is not dict or set(request) != REQUEST_KEYS
            or request['target'] != TARGET or not _hash(request['sample_id'])
            or not _hash(request['feature_sha256'])):
        raise ValueError('EXACT_PRE_INPUT_REQUEST_REQUIRED')
    f = validate_features(request['features'])
    if (digest(f) != request['feature_sha256']
            or request['input_complete'] is not input_complete(f)):
        raise ValueError('PRE_INPUT_IDENTITY_OR_COMPLETENESS')
    result = dict(schema=SCHEMA, sample_id=request['sample_id'],
        feature_sha256=request['feature_sha256'], input_complete=request['input_complete'],
        status='UNKNOWN', reason=None, first_wave_partition=None, known_prefix=None,
        first_wave_sweep_effective_swords=None, first_wave_direct_effective_swords=None,
        known_ordinary_cascade_effective_swords=None, pre_resource_context=None,
        actual_refill_used=False, net_resource_prediction=False, full_power_prediction=None,
        critical_prediction=None, damage_prediction=None, calibration_eligible=False,
        input_authority=False)
    settings = f['settings']; target = settings['demon_target_gem']
    if (settings['play_style'] != 'demon_aegis_farm' or settings['damage_card'] != 'pet_passive'
            or target not in GEMS - {'sword'}):
        return dict(result, reason='UNSUPPORTED_DECLARED_PASSIVE_CONFIGURATION')
    if f['board'] is None or f['first_wave']['status'] != 'KNOWN':
        return dict(result, reason='BOARD_OR_FIRST_WAVE_UNKNOWN')
    grid = [[_CellValue(GemType(g), m) for g, m in row] for row in f['board']]
    move = SwapMove(*(tuple(p) for p in f['move']))
    ordinary = _resolve_known_reply(grid, move)
    if ordinary is None:
        raise ValueError('NO_LEGAL_PRE_INPUT_SWAP')
    swapped = [list(row) for row in grid]
    a, b = move.first, move.second
    swapped[a[0]][a[1]], swapped[b[0]][b[1]] = swapped[b[0]][b[1]], swapped[a[0]][a[1]]
    direct = _match_through(swapped, a) | _match_through(swapped, b)
    matched, blast, _, _ = _passive_geometry(grid, move, GemType(target))
    cleared = direct | set(blast)
    first = _tallies(swapped, cleared)
    first_counts = _counts(first)
    wave = f['first_wave']
    if (bool(matched) != wave['passive_triggered']
            or any(first_counts[k] != wave[k] for k in ('physical', 'effective'))):
        raise ValueError('FIRST_WAVE_FEATURE_BOARD_MISMATCH')
    sweep = _tallies(swapped, set(blast))
    outside = _tallies(swapped, direct - set(blast))
    first_after = [list(row) for row in swapped]
    displaced = _collapse(first_after, cleared)
    residual = bool(_matches_touching(first_after, displaced)[0])
    ordinary_direct, ordinary_cascade, rounds, ordinary_after = ordinary
    later_target = not matched and ordinary_cascade.cells(GemType(target)) > 0
    if matched or later_target:
        prefix, prefix_rounds, after = first, 0, first_after
        coverage = ('DECLARED_DEMON_FIRST_WAVE_ONLY' if matched
                    else 'FIRST_WAVE_ONLY_LATER_PASSIVE_UNMODELED')
        cascade_swords = 0
    else:
        prefix = _merge_results(ordinary_direct, ordinary_cascade)
        prefix_rounds, after = rounds, ordinary_after
        coverage = 'EXISTING_SOLVER_KNOWN_ORDINARY_CASCADES_NO_REFILL'
        cascade_swords = ordinary_cascade.effective(GemType.SWORD)
    own, boss = f['self_stats'] or {}, f['boss_stats'] or {}
    result.update(status='CONDITIONAL_KNOWN_PREFIX', reason='NO_SERVER_DAMAGE_OR_RAGE_ORDER_ASSUMED',
        first_wave_partition=dict(sweep=_counts(sweep), direct_outside_sweep=_counts(outside)),
        first_wave_sweep_effective_swords=sweep.effective(GemType.SWORD),
        first_wave_direct_effective_swords=outside.effective(GemType.SWORD),
        known_ordinary_cascade_effective_swords=cascade_swords,
        known_prefix=dict(coverage=coverage, **_counts(prefix), ordinary_cascade_rounds=prefix_rounds,
            later_passive_unmodeled=later_target, known_residual_after_first_wave=residual,
            unresolved_refill_cells=sum(c.gem is GemType.UNKNOWN for row in after for c in row),
            continuation_complete=False),
        pre_resource_context=dict(power=own.get('power'), max_power=own.get('max_power'),
            boss_power=boss.get('power'), boss_shield=boss.get('shield'),
            first_wave_effective_rage=first.effective(GemType.RAGE),
            known_prefix_effective_rage=prefix.effective(GemType.RAGE),
            known_prefix_effective_drain=prefix.effective(GemType.DRAIN),
            gross_counts_are_not_net_balance=True, server_resource_order='UNKNOWN'))
    return result
