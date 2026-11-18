"""Scoped G2 tactics over the existing solver; no reader or input authority.

The supplied card description declares 30,000 per Shield (without clearing),
100 Mana returned and 50% mitigation for three turns. Damage modifiers, the
active mitigation timer and the passive armor timer are not decoded. B15
ShowGalaxyScanFx sums max(1, Dot.multiplier). Refill is never synthesized.
"""
from dataclasses import dataclass

from .board_simulator import (
    MoveEvaluation, _candidate_swaps, _resolve_known_reply, _CellValue,
)
from .state import GemType


G2_ELEMENT = "GALAXY_2"
SHIELD_REFERENCE = 16  # Effective-value reference, not an eligibility/kill threshold.
NOMINAL_DAMAGE_PER_SHIELD = 30_000


def shield_count(grid):
    return sum(cell.gem is GemType.SHIELD for row in grid for cell in row)


def shield_value(grid):
    return sum(max(1, cell.multiplier or 1) for row in grid for cell in row if cell.gem is GemType.SHIELD)


@dataclass(frozen=True)
class GlankPlan:
    action: str
    step: str
    selected: MoveEvaluation | None
    facts: dict


class GlankPlanner:
    def __init__(self):
        self.session = None
        self.deferred_turn = None
        self.last_skill_turn = None

    def decide(self, state, evaluations, *, can_cast, missing_mana, missing_rage,
               protection_ratio, pass_allowed, last_skill_turn=None):
        if state.battle.session_key != self.session:
            self.session = state.battle.session_key
            self.deferred_turn = None
            self.last_skill_turn = None
        if (type(last_skill_turn) is int
                and (self.last_skill_turn is None or last_skill_turn > self.last_skill_turn)):
            # Only existing exact-session success history starts a new cycle.
            self.deferred_turn = None
            self.last_skill_turn = last_skill_turn
        own = state.player
        hp_ratio = own.hp / own.max_hp if own.hp is not None and own.max_hp and own.max_hp > 0 else None
        boss = next((actor for actor in state.opponents if actor.is_boss), None)
        shields = shield_count(state.board.cells)
        effective_shields = shield_value(state.board.cells)
        sword_allowed = own.power == 0  # UNKNOWN never means empty.
        current_swords = max((move.sword_effective for move in evaluations), default=0)
        nominal_reply = (current_swords * boss.attack
                         if boss is not None and boss.attack is not None else None)
        facts = dict(pet_alias="G2", pet_name="Galaxy Glank", identity_source="CURRENT_OWNED_CARD_UI",
            element_type=G2_ELEMENT, shield_cells=shields,
            shield_effective=effective_shields, shield_reference=SHIELD_REFERENCE,
            count_kind="B15_SUM_MAX_1_DOT_MULTIPLIER",
            nominal_skill_damage=effective_shields * NOMINAL_DAMAGE_PER_SHIELD,
            damage_support="USER_CARD_DESCRIPTION_NOT_SERVER_DAMAGE_OR_KILL_PROOF",
            mana_refund_declared=100, damage_reduction_declared=.5,
            reduction_turns_declared=3, active_reduction_remaining="UNKNOWN",
            passive_armor_remaining="UNKNOWN", hp_ratio=hp_ratio, rage=own.power,
            sword_allowed=sword_allowed, current_sword_effective_max=current_swords,
            nominal_boss_sword_pressure=nominal_reply, refill_credit=0,
            deferred_source_turn=self.deferred_turn if self.deferred_turn != state.battle.turn_number else None)

        def result(action, step, selected=None, **detail):
            return GlankPlan(action, "GALAXY_G2_" + step, selected, dict(facts, **detail))

        # Casting now also protects. Never postpone the available defense at
        # low/unknown HP or substantial known Sword pressure for a refill bet.
        needs_defense = (hp_ratio is None or hp_ratio <= .35
            or (nominal_reply is not None and own.hp is not None
                and nominal_reply >= .25 * (own.hp + (own.shield or 0))))
        if can_cast:
            if needs_defense:
                return result("pet_skill", "FIRE_PROTECTION")
            if effective_shields >= SHIELD_REFERENCE:
                return result("pet_skill", "FIRE_SHIELDS")
            if boss is not None and boss.hp is not None and 0 < boss.hp <= facts["nominal_skill_damage"]:
                return result("pet_skill", "FIRE_NOMINAL_FINISH", kill_certified=False)
            if (self.deferred_turn is not None and state.battle.turn_number is not None
                    and state.battle.turn_number > self.deferred_turn):
                return result("pet_skill", "FIRE_WAIT_LIMIT")

        eligible = tuple(move for move in evaluations if sword_allowed or move.sword_effective == 0)
        safe = tuple(move for move in eligible if move.sword_risk.safe)
        protecting = (protection_ratio is not None and hp_ratio is not None and hp_ratio <= protection_ratio)

        def progress(move):
            # Same declared resource conversions as common reasoning. Only
            # the currently missing cost earns progress, not surplus stock.
            return (min(missing_mana or 0, move.total.effective(GemType.MANA) * 30)
                    + min(missing_rage or 0, move.total.effective(GemType.RAGE) * 20))

        def rank(move):
            risk = move.sword_risk
            return (move.total.effective(GemType.SHIELD), -progress(move),
                risk.opponent_sword_reply_effective_max, risk.opponent_sword_replies,
                -shield_value(move.result), move.unknown_exposure.cells,
                risk.danger_score, move.move)

        if can_cast:
            setup = tuple(move for move in safe
                          if move.sword_effective == 0 and move.total.cells(GemType.SHIELD) == 0)
            if setup and state.battle.turn_number is not None:
                # Bound the deeper comparison to eight candidates and all
                # 112 known boss swaps per candidate. No refill predictions.
                compared = []
                for move in sorted(setup, key=rank)[:8]:
                    grid = [[_CellValue(cell.gem, cell.multiplier) for cell in row] for row in move.result]
                    floors = [shield_value(move.result)]
                    for reply in _candidate_swaps():
                        resolved = _resolve_known_reply(grid, reply)
                        if resolved is not None:
                            floors.append(shield_value(resolved[3]))
                    compared.append((min(floors), move))
                floor, chosen = min(compared, key=lambda item: (-item[0], rank(item[1])))
                if floor < effective_shields:
                    return result("pet_skill", "FIRE_SHIELDS_AT_RISK",
                                  best_known_shield_floor=floor)
                # This is an observed planning deferral, not an input ACK or
                # evidence that a buff is active. Repeated preflights do not
                # consume another waiting turn.
                self.deferred_turn = state.battle.turn_number
                return result("swap", "SETUP_SHIELDS", chosen,
                    known_shields_after=shield_count(chosen.result),
                    known_shield_effective_after=shield_value(chosen.result),
                    shield_floor_after_known_boss_reply=floor,
                    setup_candidates_examined=len(compared),
                    waiting="AT_MOST_ONE_OBSERVED_LOCAL_TURN_NO_REFILL_GAIN_ASSUMED")
            return result("pet_skill", "FIRE_NO_SAFE_SETUP")

        if not eligible:
            if pass_allowed:
                return result("pass", "WAIT_RAGE_PRESERVE")
            return result("none", "SWORD_BLOCKED_WITH_RAGE")

        if protecting:
            # Respect the operator's selected protection threshold while
            # keeping the explicit G2 prohibition on spending nonzero Rage.
            for gem in (GemType.HEALTH, GemType.SHIELD, GemType.DRAIN):
                pool = tuple(move for move in safe if move.total.effective(gem) > 0)
                if pool:
                    chosen = min(pool, key=lambda move: (-move.total.effective(gem), rank(move)))
                    return result("swap", "PROTECT_" + gem.value.upper(), chosen)
        safe_progress = tuple(move for move in safe if progress(move) > 0)
        if safe_progress:
            return result("swap", "RESOURCE_PROGRESS", min(safe_progress, key=rank))
        risky_progress = tuple(move for move in eligible if progress(move) > 0)
        if risky_progress and hp_ratio is not None and hp_ratio > .5 and not protecting:
            chosen = min(risky_progress, key=lambda move: (
                move.sword_risk.opponent_sword_reply_effective_max,
                move.sword_risk.opponent_sword_replies, rank(move)))
            return result("swap", "RESOURCE_RISK_ACCEPTED", chosen)
        # At zero Rage a safe Sword can deny the boss without spending the
        # next skill's Rage. Resource progress above still has first priority.
        empty_rage_swords = tuple(move for move in safe if sword_allowed and move.sword_effective > 0)
        if empty_rage_swords:
            return result("swap", "SWORD_EMPTY_RAGE", min(empty_rage_swords, key=lambda move: (
                -move.sword_effective, rank(move))))
        if safe:
            preserving = tuple(move for move in safe if move.total.cells(GemType.SHIELD) == 0)
            pool = preserving or safe
            # Retain valuable board Shields; use known Health/Drain support
            # when charging is blocked. Do not guess how many refills are Shield.
            chosen = min(pool, key=lambda move: (
                -move.total.effective(GemType.HEALTH) * (1 - hp_ratio if hp_ratio is not None else 1),
                -move.total.effective(GemType.DRAIN) if boss is not None and boss.mana else 0,
                rank(move)))
            return result("swap", "PRESERVE_SHIELDS", chosen)
        chosen = min(eligible, key=lambda move: (
            move.sword_risk.opponent_sword_reply_effective_max,
            move.sword_risk.opponent_sword_replies, rank(move)))
        return result("swap", "LOWEST_KNOWN_RISK", chosen)
