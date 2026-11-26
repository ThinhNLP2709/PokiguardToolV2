"""G4 passive combo adviser over the existing deterministic match solver.

The user confirms 9..13 multiplier-weighted units per swap, including cascades.
Sum the observed x1..x7 values of every collected gem, retaining physical
cell counts as separate diagnostics. Unknown refill is never invented. Neither
the displayed damage tiers nor 2% lifesteal certify actual damage or survival.
"""
from dataclasses import dataclass
import time

from .board_simulator import _CellValue, _candidate_swaps, _resolve_known_reply
from .state import GemType
from .boss_threat import state_boss_threat

DECLARED_TIERS = ((9, 500000), (10, 700000), (11, 1000000), (12, 1500000), (13, 2000000))


def milestone(units):
    return max((n for n, _ in DECLARED_TIERS if units >= n), default=0)


def projection(move, *, passive_active=True):
    units = move.total.total_effective
    tier = milestone(units) if passive_active else 0
    return dict(known_destroyed_cells=move.total.total_cells, direct_cells=move.direct.total_cells,
        cascade_cells=move.cascade.total_cells, known_cascade_rounds=move.cascade_rounds,
        known_combo_units=units, direct_combo_units=move.direct.total_effective,
        cascade_combo_units=move.cascade.total_effective,
        effective_resource_units=units, declared_milestone=tier, passive_active=passive_active,
        declared_damage_reference=dict(DECLARED_TIERS).get(tier),
        lifesteal_opportunity=tier >= 11, actual_damage=None, actual_heal=None,
        kill_certified=False, survival_certified=False, steadfast_active='UNKNOWN',
        trigger_counting='MULTIPLIER_WEIGHTED_ALL_GEMS_PER_SWAP',
        trigger_support='USER_CONFIRMED_MULTIPLIERS_20261122_NOT_LIVE_VERIFIED',
        actual_refill_used=False, unknown_refill_cells=move.unknown_exposure.cells)


@dataclass(frozen=True)
class G4Plan:
    selected: object
    step: str
    facts: dict


class _Budget:
    def __init__(self, milliseconds, clock):
        self.clock = clock
        self.deadline = clock() + milliseconds * 1000000
        self.nodes = 0

    def tick(self):
        if self.nodes >= 1800 or self.clock() >= self.deadline:
            raise TimeoutError('G4 bounded setup exhausted')
        self.nodes += 1


def _options(source, budget):
    grid = [[_CellValue(c.gem, c.multiplier) for c in row] for row in source]
    options = []
    for swap in _candidate_swaps():
        budget.tick()
        result = _resolve_known_reply(grid, swap)
        if result is not None:
            direct, cascade, _, after = result
            options.append((swap, direct.total_effective + cascade.total_effective,
                direct.effective(GemType.SWORD) + cascade.effective(GemType.SWORD), after))
    return options


def _future(move, budget):
    # Conditional on the user's known Sword-first boss tendency. Every tie is
    # retained; different replies are never added into one response.
    replies = _options(move.result, budget)
    if not replies:
        return dict(complete=True, conditional_floor=0, reply_count=0,
            support='NO_KNOWN_BOSS_REPLY_NOT_PROOF_BOSS_PASSES')
    maximum = max(r[2] for r in replies)
    nominal = [r for r in replies if r[2] == maximum]
    if len(nominal) > 4:
        return dict(complete=False, conditional_floor=0, reply_count=len(nominal),
            support='TOO_MANY_REPLY_TIES_NO_SETUP_CREDIT')
    counts = [max((r[1] for r in _options(reply[3], budget)), default=0) for reply in nominal]
    return dict(complete=True, conditional_floor=min(counts), conditional_ceiling=max(counts),
        reply_count=len(nominal), boss_sword_reference=maximum,
        support='KNOWN_COLLAPSE_NO_REFILL_CONDITIONAL_SWORD_FIRST_ALL_TIES')


def plan_g4(state, moves, *, reasoning=False, budget_ms=150, clock=time.perf_counter_ns,
            passive_active=True, evolution_pending=False, evolution_mana_cost=None, evolved=False):
    """Always return an existing legal swap when one exists, even if risky."""
    if (type(reasoning) is not bool or type(passive_active) is not bool
            or type(evolution_pending) is not bool or type(evolved) is not bool
            or type(budget_ms) is not int or not 1 <= budget_ms <= 250):
        raise ValueError('G4 requires a boolean mode and a bounded 1..250ms setup budget')
    if not moves:
        return G4Plan(None, 'NO_LEGAL_MOVE', dict(legal_moves=0, actual_refill_used=False))
    own = state.player
    hp = getattr(own, 'hp', None); maximum = getattr(own, 'max_hp', None)
    fill = hp / maximum if type(hp) is int and type(maximum) is int and maximum > 0 else None
    critical = fill is not None and fill <= .30
    boss = next((a for a in state.opponents if a.is_boss), None)
    def fraction(actor, value, cap):
        n, d = getattr(actor, value, None), getattr(actor, cap, None)
        return n/d if type(n) is int and type(d) is int and d > 0 else None
    boss_hp = fraction(boss, 'hp', 'max_hp')
    boss_rage = fraction(boss, 'power', 'max_power')
    own_rage = fraction(own, 'power', 'max_power')
    boss_threat = state_boss_threat(state)
    pressure = critical or (fill is not None and fill <= .60 and boss_rage is not None and boss_rage >= .80)
    # K7 (D-U1): boss-threat early protection only before a successful evolution;
    # once evolved, protection follows the configured HP rule like BASIC.
    early_protection = bool(reasoning and not evolved)
    if early_protection:
        pressure = pressure or boss_threat['protection_requested']
    mana = getattr(own, 'mana', None)
    cost_known = type(evolution_mana_cost) is int and evolution_mana_cost > 0
    balance_known = type(mana) is int and mana >= 0
    missing_mana = (max(0, evolution_mana_cost - mana)
        if evolution_pending and cost_known and balance_known else None)
    maximum_mana = getattr(own, 'max_mana', None)
    mana_capped = (balance_known and type(maximum_mana) is int and maximum_mana > 0
        and mana >= maximum_mana)
    needs_mana = evolution_pending and not mana_capped and (missing_mana is None or missing_mana > 0)
    # The selected route defines the current goal. Known Sword denial applies
    # in either phase; unknown refill never becomes a safety guarantee.
    stats = {m.move: projection(m, passive_active=passive_active) for m in moves}
    minimum_reply = min(m.sword_risk.opponent_sword_reply_effective_max for m in moves)
    pool = tuple(m for m in moves if m.sword_risk.opponent_sword_reply_effective_max == minimum_reply)
    activated = tuple(m for m in pool if stats[m.move]['declared_milestone'])
    mana_moves = tuple(m for m in pool if m.total.effective(GemType.MANA) > 0)
    def risk(m):
        r = m.sword_risk
        return (r.opponent_sword_reply_effective_max, r.opponent_sword_replies,
            m.unknown_exposure.hypothetical_sword_effective_max, r.danger_score)
    def health(m):
        return m.total.effective(GemType.HEALTH) * (1-fill if fill is not None else 0)
    def combo_rank(m):
        return (-stats[m.move]['declared_milestone'], -m.sword_effective, -health(m),
            risk(m), -m.total.total_effective, m.unknown_exposure.cells, m.move)
    def fallback_rank(m):
        return (-m.total.total_effective, risk(m), -health(m), -m.sword_effective, m.move)
    def mana_rank(m):
        return (-m.total.effective(GemType.MANA), -health(m),
            -m.total.effective(GemType.SHIELD), risk(m), -m.total.total_effective, m.move)
    def protection(m):
        # Resource opportunities, not predicted HP or skill denial. Drain may
        # target Mana OR Rage; never add two simultaneous transfers.
        health_value = min(1., m.total.effective(GemType.HEALTH)/6) * (1-fill if fill is not None else 1.)
        existing = fraction(own, 'shield', 'max_hp')
        shield_value = min(1., m.total.effective(GemType.SHIELD)/6) * boss_threat['shield_buffer_pressure'] * (1-min(1., existing or 0.))
        exposed = boss_threat['stored_resource_pressure']
        drain_value = min(1., m.total.effective(GemType.DRAIN)/6) * (exposed if exposed is not None else 0.)
        return dict(health=health_value, shield=shield_value, drain=drain_value,
            combined=health_value+.5*shield_value+.5*drain_value)
    def protection_rank(m):
        return (-protection(m)['combined'], combo_rank(m), fallback_rank(m))

    if needs_mana and mana_moves:
        selected = min(mana_moves, key=mana_rank); step = 'EVOLUTION_MANA'
    elif evolution_pending:
        if pressure and any(health(m) > 0 or m.total.effective(GemType.SHIELD) > 0 for m in pool):
            selected = min(pool, key=lambda m: (-health(m), -m.total.effective(GemType.SHIELD),
                risk(m), fallback_rank(m)))
            step = 'EVOLUTION_PROTECT'
        else:
            selected = min(pool, key=fallback_rank); step = 'EVOLUTION_BOARD_PROGRESS'
    elif activated:
        selected = min(activated, key=combo_rank); step = 'TRIGGER'
    else:
        selected = min(pool, key=fallback_rank); step = 'BEST_AVAILABLE'
    future = {}; work = _Budget(budget_ms, clock); exhausted = False
    if reasoning and not evolution_pending:
        # Refills can still create threats even when this known board has no
        # Sword reply. This is a ranking preference, never a safety certificate.
        healed_trigger = tuple(m for m in activated if stats[m.move]['lifesteal_opportunity'])
        defensive_trigger = tuple(m for m in activated if protection(m)['combined'] > 0)
        if pressure and healed_trigger:
            selected = min(healed_trigger, key=lambda m: (
                -stats[m.move]['declared_milestone'], protection_rank(m)))
            step = 'HEALING_COMBO'
        elif pressure and defensive_trigger:
            # Keep a passive trigger that already collects protection instead
            # of discarding its attack for a slightly larger Health-only proxy.
            selected = min(defensive_trigger, key=lambda m: (
                -stats[m.move]['declared_milestone'], protection_rank(m)))
            step = 'PROTECTING_TRIGGER'
        elif pressure and any(protection(m)['combined'] > 0 for m in pool):
            selected = min(pool, key=protection_rank)
            step = 'PROTECT'
        elif not activated and passive_active and not pressure:
            # A Sword action is one candidate, not a compulsory goal. Setup
            # cannot leave more known Sword for the boss. Partial work gets no credit.
            for move in sorted(pool, key=fallback_rank)[:6]:
                try:
                    future[move.move] = _future(move, work)
                except TimeoutError:
                    exhausted = True
                    break
            setups = tuple(m for m in pool if future.get(m.move, {}).get('complete')
                and future[m.move]['conditional_floor'] >= 9)
            if setups:
                selected = min(setups, key=lambda m: (
                    -milestone(future[m.move]['conditional_floor']), risk(m), fallback_rank(m)))
                step = 'CONDITIONAL_SETUP'
    facts = dict(mode='REASONING' if reasoning else 'BASIC', legal_moves=len(moves),
        trigger_candidates=len(activated), hp_fraction=fill, selected=stats[selected.move],
        foundation='ROUTE_GOAL_WITH_MINIMUM_KNOWN_SWORD_REPLY',
        passive_active=passive_active, evolution_mana_cost=evolution_mana_cost,
        evolution_pending=evolution_pending, evolution_missing_mana=missing_mana,
        goal='EVOLUTION' if evolution_pending else 'PASSIVE_COMBO',
        phase=('BUILD_EVOLUTION_MANA' if needs_mana else
            'EVOLUTION_MANA_CAPPED' if mana_capped and missing_mana != 0 else 'WAIT_EVOLUTION_ACTION')
            if evolution_pending else 'PASSIVE_COMBO',
        evolution_cost_known=cost_known if evolution_pending else None,
        evolution_mana_capped=mana_capped if evolution_pending else None,
        evolution_mana_progress_units=selected.total.effective(GemType.MANA) if needs_mana else 0,
        evolution_progress_prediction='OBSERVED_GEM_UNITS_NOT_CERTIFIED_MANA_GAIN',
        minimum_known_boss_sword_reply=minimum_reply, minimum_reply_candidates=len(pool),
        zero_known_sword_reply_available=minimum_reply == 0,
        avoidable_known_sword_reply=False, refill_safety_certified=False,
        boss_hp_fraction=boss_hp, boss_rage_fraction=boss_rage, own_rage_fraction=own_rage,
        pressure_proxy=pressure, pressure_is_lethality_proof=False,
        **({'early_protection_allowed': False} if reasoning and evolved else {}),
        boss_skill_threat=boss_threat, selected_protection_proxy=protection(selected),
        protection_amounts_and_drain_target='UNKNOWN_NOT_SURVIVAL_OR_CAST_PREVENTION',
        low_boss_hp_bonus='DECLARED_OPPORTUNITY_NOT_A_DAMAGE_FORMULA' if boss_hp is not None and boss_hp < 1 else 'UNKNOWN_OR_NOT_ACTIVE',
        boss_reply_sword_max=selected.sword_risk.opponent_sword_reply_effective_max,
        setup=future.get(selected.move), setup_candidates_checked=len(future),
        setup_candidates_completed=sum(bool(v['complete']) for v in future.values()),
        setup_nodes=work.nodes, setup_budget_ms=budget_ms, setup_budget_exhausted=exhausted,
        resource_cost=dict(mana=0, rage=0), skill_card_click=False, seal=False,
        identity_source='OPERATOR_G4_STYLE_NOT_RUNTIME_PET_IDENTIFICATION',
        effect_formula='SERVER_UNKNOWN', actual_refill_used=False,
        recommendation_only=True, auto_stop_for_danger=False)
    return G4Plan(selected, step, facts)
