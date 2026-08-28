"""Explainable Phase 2C.2A BASIC gameplay policy.

This module only proposes actions.  It has no input, click, process-write,
network, or game-method call path.
"""

from __future__ import annotations

from dataclasses import dataclass
from enum import Enum

from .board_simulator import MoveEvaluation, SwapMove, evaluate_all_moves
from .state import CardState, GameOwnedIdleStatus, GamePhase, GameState, GemType


class PlayStyle(str, Enum):
    SIMPLE = "simple"
    CAREFUL = "careful"


class ManaPriority(str, Enum):
    EVOLUTION = "evolution"
    ATTACK = "attack"


class Intelligence(str, Enum):
    BASIC = "basic"
    REASONING = "reasoning"


class PolicyAction(str, Enum):
    EVOLVE = "evolve"
    CAST = "cast"
    SWAP = "swap"
    PASS = "pass"
    EXIT_MATCH = "exit_match"
    NONE = "none"


@dataclass(frozen=True)
class PolicyConfig:
    play_style: PlayStyle = PlayStyle.SIMPLE
    mana_priority: ManaPriority = ManaPriority.EVOLUTION
    intelligence: Intelligence = Intelligence.BASIC
    minimum_turn_time_seconds: int = 3
    # EVOLVE does not consume the turn, so it is useful only while enough of
    # the same local turn remains for its server response/animation and the
    # mandatory fresh-state follow-up action. Live Phase 2D.6 lag evidence
    # showed that proposing it at 8 seconds can consume the whole turn.
    minimum_evolve_time_seconds: int = 10
    # Step 3 finisher: once the boss is at or below this absolute current HP,
    # a Sword-free board casts as soon as one Attack card is affordable.
    # 0 disables the finisher entirely.
    cast_when_boss_hp_below: int = 30_000
    # Step 5 stockpile rule: cast only above this mana so a 320 reserve
    # (two casts) survives the 160 cost.
    cast_mana_stockpile_threshold: int = 480
    # Step 3 Rage floor; reaching it boosts Sword damage.
    rage_target: int = 100
    # Step 4 low-HP thresholds per play style.
    low_hp_ratio_simple: float = 0.30
    low_hp_ratio_careful: float = 0.50
    # Step 5 boss-resource branches.
    boss_high_mana: int = 160
    boss_high_rage: int = 100
    boss_low_resource: int = 50

    def __post_init__(self) -> None:
        if not 0 <= self.minimum_turn_time_seconds <= 14:
            raise ValueError("minimum_turn_time_seconds must be between 0 and 14")
        if not self.minimum_turn_time_seconds <= self.minimum_evolve_time_seconds <= 14:
            raise ValueError(
                "minimum_evolve_time_seconds must be between "
                "minimum_turn_time_seconds and 14"
            )
        if self.cast_when_boss_hp_below < 0:
            raise ValueError("cast_when_boss_hp_below must be >= 0")
        if self.cast_mana_stockpile_threshold < 0:
            raise ValueError("cast_mana_stockpile_threshold must be >= 0")
        if self.rage_target < 0:
            raise ValueError("rage_target must be >= 0")
        for name in ("boss_high_mana", "boss_high_rage", "boss_low_resource"):
            if getattr(self, name) < 0:
                raise ValueError(f"{name} must be >= 0")
        for name in ("low_hp_ratio_simple", "low_hp_ratio_careful"):
            value = getattr(self, name)
            if not 0.0 <= value <= 1.0:
                raise ValueError(f"{name} must be between 0 and 1")

    @property
    def low_hp_ratio(self) -> float:
        return (
            self.low_hp_ratio_simple
            if self.play_style is PlayStyle.SIMPLE
            else self.low_hp_ratio_careful
        )


@dataclass(frozen=True)
class CandidateTrace:
    move: SwapMove
    horizontal: bool
    calculable: bool
    direct_resources: tuple[tuple[str, int, int], ...]
    cascade_resources: tuple[tuple[str, int, int], ...]
    total_resources: tuple[tuple[str, int, int], ...]
    known_cascades: int
    longest_match: int
    sword_effective: int
    sword_potentials_left: int
    sword_potential_effective_max: int
    sword_danger_regions: int
    collapse_support_hazard: int
    unknown_cells: int
    unknown_max_column_depth: int
    unknown_sword_completions: int
    unknown_sword_effective_max: int
    danger_score: int
    safe: bool


@dataclass(frozen=True)
class DecisionTrace:
    selected_action: PolicyAction
    policy_step: str
    candidate_count: int
    why_selected: str
    failed_higher_priority_branches: tuple[str, ...]
    candidates: tuple[CandidateTrace, ...]
    selected_candidate: CandidateTrace | None
    skip_count: int | None
    skip_threshold: int | None
    skip_source: str | None
    skip_status: GameOwnedIdleStatus
    first_local_turn: bool | None
    turn_number: int | None
    turn_time_remaining_seconds: int | None
    turn_timer_source: str | None
    blocker: str | None = None


@dataclass(frozen=True)
class PolicyDecision:
    action: PolicyAction
    trace: DecisionTrace
    move: SwapMove | None = None
    card_object_address: int | None = None
    consumes_turn: bool = False
    requires_state_reread: bool = False


def _resource_trace(value: MoveEvaluation, attribute: str) -> tuple[tuple[str, int, int], ...]:
    result = getattr(value, attribute)
    return tuple(
        (gem.value, tally.cells, tally.effective)
        for gem, tally in result.values
    )


def _candidate_trace(value: MoveEvaluation) -> CandidateTrace:
    risk = value.sword_risk
    exposure = value.unknown_exposure
    return CandidateTrace(
        move=value.move,
        horizontal=value.horizontal,
        calculable=value.calculable,
        direct_resources=_resource_trace(value, "direct"),
        cascade_resources=_resource_trace(value, "cascade"),
        total_resources=_resource_trace(value, "total"),
        known_cascades=value.cascade_rounds,
        longest_match=value.longest_match,
        sword_effective=value.sword_effective,
        sword_potentials_left=risk.potentials_left,
        sword_potential_effective_max=risk.potential_effective_max,
        sword_danger_regions=risk.danger_regions_left,
        collapse_support_hazard=risk.collapse_support_hazard,
        unknown_cells=exposure.cells,
        unknown_max_column_depth=exposure.max_column_depth,
        unknown_sword_completions=exposure.hypothetical_sword_completions,
        unknown_sword_effective_max=exposure.hypothetical_sword_effective_max,
        danger_score=risk.danger_score,
        safe=risk.safe,
    )


def _attack_cost(card: CardState) -> int:
    if card.mana_cost > 0:
        return card.mana_cost
    if card.condition_use is not None and card.condition_use > 0:
        return int(card.condition_use)
    # CAST is never proposed from a guessed default. The live card must expose
    # its actual positive cost through CardData.manaCost or conditionUse.
    return 2**63 - 1


def _boss(state: GameState):
    return next(
        (opponent for opponent in state.opponents if opponent.is_boss is True),
        state.opponents[0] if state.opponents else None,
    )


def _ratio(current: int | None, maximum: int | None) -> float | None:
    if current is None or maximum is None or maximum <= 0:
        return None
    return max(0.0, min(1.0, current / maximum))


class BasicPolicyEngine:
    """Apply the user-specified BASIC rules in their exact priority order."""

    def __init__(self, config: PolicyConfig | None = None) -> None:
        self.config = config or PolicyConfig()

    def _decision(
        self,
        state: GameState,
        action: PolicyAction,
        step: str,
        why: str,
        failures: list[str],
        evaluations: tuple[MoveEvaluation, ...],
        *,
        selected: MoveEvaluation | None = None,
        card: CardState | None = None,
        blocker: str | None = None,
        candidate_count: int | None = None,
    ) -> PolicyDecision:
        candidates = tuple(_candidate_trace(value) for value in evaluations)
        selected_trace = _candidate_trace(selected) if selected is not None else None
        trace = DecisionTrace(
            selected_action=action,
            policy_step=step,
            candidate_count=(
                candidate_count if candidate_count is not None else len(evaluations)
            ),
            why_selected=why,
            failed_higher_priority_branches=tuple(failures),
            candidates=candidates,
            selected_candidate=selected_trace,
            skip_count=state.battle.consecutive_passes,
            skip_threshold=state.battle.consecutive_pass_threshold,
            skip_source=state.battle.consecutive_pass_source,
            skip_status=state.battle.consecutive_pass_status,
            first_local_turn=state.battle.is_first_local_turn,
            turn_number=state.battle.turn_number,
            turn_time_remaining_seconds=state.battle.turn_time_remaining_seconds,
            turn_timer_source=state.battle.turn_timer_source,
            blocker=blocker,
        )
        return PolicyDecision(
            action=action,
            trace=trace,
            move=selected.move if selected is not None else None,
            card_object_address=card.object_address if card is not None else None,
            consumes_turn=action in {
                PolicyAction.CAST,
                PolicyAction.SWAP,
                PolicyAction.PASS,
            },
            requires_state_reread=action is PolicyAction.EVOLVE,
        )

    @staticmethod
    def _sword_rank(value: MoveEvaluation) -> tuple[object, ...]:
        risk = value.sword_risk
        return (
            risk.potential_effective_max > 0,
            -value.sword_effective,
            -value.total.effective(GemType.RAGE),
            -value.cascade_rounds,
            -value.total.total_effective,
            risk.danger_score,
            value.unknown_exposure.cells,
            not value.horizontal,
            not value.calculable,
            value.move,
        )

    @staticmethod
    def _resource_rank(value: MoveEvaluation, gem: GemType) -> tuple[object, ...]:
        return (
            -value.total.effective(gem),
            value.sword_risk.danger_score,
            -value.cascade_rounds,
            value.unknown_exposure.cells,
            not value.horizontal,
            not value.calculable,
            value.move,
        )

    @staticmethod
    def _mandatory_rank(value: MoveEvaluation) -> tuple[object, ...]:
        return (
            value.sword_risk.danger_score,
            value.sword_risk.potential_effective_max,
            value.sword_risk.potentials_left,
            -value.total.effective(GemType.SHIELD),
            value.unknown_exposure.cells,
            -value.total.total_effective,
            not value.horizontal,
            not value.calculable,
            value.move,
        )

    @staticmethod
    def _health_only_fallback_rank(value: MoveEvaluation) -> tuple[object, ...]:
        """Prefer the most predictable move when Health is the sole safe resource."""

        return (
            not value.calculable,
            not value.horizontal,
            -value.total.effective(GemType.HEALTH),
            value.sword_risk.danger_score,
            -value.cascade_rounds,
            value.unknown_exposure.cells,
            value.move,
        )

    def decide(self, state: GameState) -> PolicyDecision:
        failures: list[str] = []
        no_candidates: tuple[MoveEvaluation, ...] = ()
        if self.config.intelligence is not Intelligence.BASIC:
            return self._decision(
                state,
                PolicyAction.NONE,
                "CONFIG",
                "REASONING is represented but intentionally not implemented in Phase 2C.2A",
                failures,
                no_candidates,
                blocker="REASONING_NOT_IMPLEMENTED",
            )
        if state.phase is not GamePhase.COMBAT or state.board is None:
            return self._decision(
                state,
                PolicyAction.NONE,
                "ACTIONABILITY_GATE",
                "No stable combat board is published",
                failures,
                no_candidates,
                blocker="NOT_STABLE_COMBAT",
            )
        if state.battle.is_local_turn is not True or state.battle.client_move_allowed is not True:
            return self._decision(
                state,
                PolicyAction.NONE,
                "ACTIONABILITY_GATE",
                "Runtime move permission does not prove an actionable local turn",
                failures,
                no_candidates,
                blocker="LOCAL_TURN_NOT_ACTIONABLE",
            )
        if (
            state.battle.turn_duration_seconds is None
            or state.battle.turn_time_remaining_seconds is None
            or state.battle.turn_timer_source is None
        ):
            return self._decision(
                state,
                PolicyAction.NONE,
                "ACTIONABILITY_GATE",
                "Turn timer is UNKNOWN; policy fails closed",
                failures,
                no_candidates,
                blocker="TURN_TIMER_UNKNOWN",
            )
        # The configured floor is inclusive. The server timer is an integer
        # tick, so treating the exact floor as expired silently adds a second
        # to the operator-approved limit.
        if state.battle.turn_time_remaining_seconds < self.config.minimum_turn_time_seconds:
            return self._decision(
                state,
                PolicyAction.NONE,
                "ACTIONABILITY_GATE",
                "Latest server timer tick is inside the configured safety margin",
                failures,
                no_candidates,
                blocker="TURN_TIMER_SAFETY_MARGIN",
            )

        player = state.player
        player_mana = player.mana if player is not None else None
        boss = _boss(state)
        boss_hp_current = boss.hp if boss is not None else None
        finisher_threshold = self.config.cast_when_boss_hp_below
        low_boss_hp_mode = bool(
            finisher_threshold > 0
            and boss_hp_current is not None
            and boss_hp_current <= finisher_threshold
        )

        idle_status = state.battle.consecutive_pass_status
        # Compatibility for deterministic fixtures that predate the explicit
        # status field.  The numeric values still originate in the fixture's
        # game-owned payload; no value is synthesized here.
        if (
            idle_status is GameOwnedIdleStatus.UNKNOWN
            and state.battle.consecutive_passes is not None
            and state.battle.consecutive_pass_threshold is not None
            and state.battle.consecutive_pass_source is not None
        ):
            idle_status = (
                GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION
                if state.battle.consecutive_passes
                >= state.battle.consecutive_pass_threshold - 1
                else GameOwnedIdleStatus.PASS_ALLOWED
            )
        mandatory = bool(
            state.battle.is_first_local_turn is True
            or idle_status
            is GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION
        )

        # STEP 1: EVOLVE is non-turn-consuming and requires a fresh GameState.
        # At the authoritative pass limit EVOLVE is deliberately deferred: it
        # does not consume the turn and therefore cannot establish the reset
        # the server requires.  A SWAP/CAST must be selected first.
        if idle_status is GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION:
            failures.append(
                "STEP_1_EVOLVE: deferred because the authoritative idle state "
                "requires a turn-consuming SWAP or CAST"
            )
        elif low_boss_hp_mode:
            failures.append(
                "STEP_1_EVOLVE: disabled while low-boss-HP mode is active "
                f"({boss_hp_current} <= {finisher_threshold})"
            )
        elif self.config.mana_priority is ManaPriority.ATTACK:
            failures.append("STEP_1_EVOLVE: disabled for the entire match by ManaPriority.ATTACK")
        elif (
            state.battle.turn_time_remaining_seconds
            < self.config.minimum_evolve_time_seconds
        ):
            failures.append(
                "STEP_1_EVOLVE: deferred because timer "
                f"{state.battle.turn_time_remaining_seconds}s is below the "
                f"{self.config.minimum_evolve_time_seconds}s same-turn "
                "response/follow-up floor"
            )
        elif state.fusion is None:
            failures.append("STEP_1_EVOLVE: FusionState UNKNOWN")
        elif not (
            (state.fusion.selected_user_pet_id or 0) > 0
            or (state.fusion.selected_pet_id or 0) > 0
        ):
            failures.append(
                "STEP_1_EVOLVE: no evolution pet is selected; continue in "
                "board-only mode"
            )
        elif state.fusion.used:
            failures.append("STEP_1_EVOLVE: fusion already succeeded")
        elif state.fusion.ui_interactable is not True:
            failures.append("STEP_1_EVOLVE: live FusionCardUI is not proven interactable")
        elif (
            state.fusion.ui_slot is None
            or state.fusion.ui_slot_count is None
            or not 0 <= state.fusion.ui_slot < state.fusion.ui_slot_count
        ):
            failures.append(
                "STEP_1_EVOLVE: runtime Fusion card slot is not proven; "
                "continue with board play"
            )
        elif not state.fusion.enabled or not state.fusion.available or state.fusion.locked_this_turn:
            failures.append("STEP_1_EVOLVE: fusion is not currently available")
        elif player_mana is None:
            failures.append("STEP_1_EVOLVE: player mana UNKNOWN")
        elif state.fusion.mana_cost is None or state.fusion.mana_cost <= 0:
            # The current MatchService-owned Fusion state is authoritative.
            # Never infer the commonly observed 160 cost for live input.
            failures.append("STEP_1_EVOLVE: actual positive evolution cost UNKNOWN")
        else:
            evolution_cost = state.fusion.mana_cost
            if player_mana >= evolution_cost:
                return self._decision(
                    state,
                    PolicyAction.EVOLVE,
                    "STEP_1_EVOLVE",
                    f"Evolution priority, not fused, and mana {player_mana} >= {evolution_cost}; re-read after proposal",
                    failures,
                    no_candidates,
                    candidate_count=1,
                )
            failures.append(
                f"STEP_1_EVOLVE: mana {player_mana} below evolution cost {evolution_cost}"
            )

        evaluations = evaluate_all_moves(state.board)
        if not evaluations:
            return self._decision(
                state,
                PolicyAction.EXIT_MATCH,
                "NO_LEGAL_MOVE_BUG",
                "Exhaustive scan of all 112 adjacent pairs found zero match-producing swaps",
                failures,
                evaluations,
                blocker="EXIT_IS_PROPOSAL_ONLY",
            )

        # STEP 2: deterministic Sword collection includes known cascades.
        sword_moves = tuple(value for value in evaluations if value.sword_effective > 0)
        if sword_moves:
            selected = min(sword_moves, key=self._sword_rank)
            return self._decision(
                state,
                PolicyAction.SWAP,
                "STEP_2_SWORD",
                "A deterministic Sword result exists; selected by no-leftover, effective Sword, combo, danger, then UNKNOWN exposure",
                failures,
                sword_moves,
                selected=selected,
            )
        failures.append("STEP_2_SWORD: no legal move collects Sword directly or by known cascade")

        safe_moves = tuple(value for value in evaluations if value.sword_risk.safe)

        attack_cards = tuple(
            card
            for card in state.cards
            if card.is_attack
            and card.interactable
            and not card.action_pending
            and not card.has_used_this_turn
            and card.ui_slot is not None
            and card.ui_slot_count is not None
            and 0 <= card.ui_slot < card.ui_slot_count
        )

        # STEP 3 FINISHER: a Sword-free board with the boss at or below the
        # configured absolute HP casts as soon as one Attack card is
        # affordable.  This deliberately ignores the 480 stockpile rule — the
        # point is to close out the match instead of hoarding mana.
        if finisher_threshold <= 0:
            failures.append("STEP_3_FINISH_CAST: finisher disabled by configuration")
        elif boss_hp_current is None:
            failures.append("STEP_3_FINISH_CAST: boss HP UNKNOWN")
        elif boss_hp_current > finisher_threshold:
            failures.append(
                f"STEP_3_FINISH_CAST: boss HP {boss_hp_current} above finisher threshold {finisher_threshold}"
            )
        elif player_mana is None:
            failures.append("STEP_3_FINISH_CAST: player mana UNKNOWN")
        else:
            usable = tuple(card for card in attack_cards if player_mana >= _attack_cost(card))
            if usable:
                card = min(usable, key=lambda value: (value.card_id, value.object_address))
                return self._decision(
                    state,
                    PolicyAction.CAST,
                    "STEP_3_FINISH_CAST",
                    (
                        f"No Sword on board and boss HP {boss_hp_current} <= {finisher_threshold}; "
                        f"finisher CAST with mana {player_mana}"
                    ),
                    failures,
                    evaluations,
                    card=card,
                    candidate_count=len(usable),
                )
            failures.append(
                "STEP_3_FINISH_CAST: finisher HP condition met but no affordable usable Attack card"
            )

        # LOW-BOSS-HP MODE: after Sword and an immediately affordable CAST,
        # accumulate safe Mana before considering Rage.  This is deliberately
        # scoped to the configurable finisher threshold; normal combat keeps
        # the original Rage-before-Mana policy below.
        mana_moves = tuple(
            value for value in safe_moves if value.total.effective(GemType.MANA) > 0
        )
        if low_boss_hp_mode:
            if mana_moves:
                selected = min(
                    mana_moves,
                    key=lambda value: self._resource_rank(value, GemType.MANA),
                )
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    "STEP_3_LOW_BOSS_MANA",
                    (
                        f"Boss HP {boss_hp_current} <= {finisher_threshold}; "
                        "no affordable CAST is proven, so selected safe Mana"
                    ),
                    failures,
                    mana_moves,
                    selected=selected,
                )
            failures.append(
                "STEP_3_LOW_BOSS_MANA: low-boss-HP mode has no safe Mana move"
            )

        # STEP 3: outside low-boss-HP mode, safe Rage below the configured
        # target remains ahead of safe Mana.  With no low-boss Mana move, Rage
        # is still a legal fallback rather than forcing an unsafe move/PASS.
        rage_target = self.config.rage_target
        if player is None or player.power is None:
            failures.append("STEP_3_RAGE: player Rage UNKNOWN")
        elif player.power < rage_target:
            rage_moves = tuple(
                value for value in safe_moves if value.total.effective(GemType.RAGE) > 0
            )
            if rage_moves:
                selected = min(rage_moves, key=lambda value: self._resource_rank(value, GemType.RAGE))
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    "STEP_3_RAGE",
                    f"Player Rage {player.power} < {rage_target} and a safe Rage move exists",
                    failures,
                    rage_moves,
                    selected=selected,
                )
            failures.append(f"STEP_3_RAGE: Rage below {rage_target} but no safe Rage move")
        else:
            failures.append(f"STEP_3_RAGE: player Rage {player.power} is already >= {rage_target}")

        if mana_moves:
            selected = min(mana_moves, key=lambda value: self._resource_rank(value, GemType.MANA))
            return self._decision(
                state,
                PolicyAction.SWAP,
                "STEP_3_MANA",
                "No safe Rage priority applies; selected a safe Mana move",
                failures,
                mana_moves,
                selected=selected,
            )
        failures.append("STEP_3_MANA: no safe Mana move")

        # STEP 4: health threshold depends on configured play style.
        my_hp = _ratio(player.hp, player.max_hp) if player is not None else None
        boss_hp = _ratio(boss.hp, boss.max_hp) if boss is not None else None
        health_threshold = self.config.low_hp_ratio
        if my_hp is None or boss_hp is None:
            failures.append("STEP_4_HEALTH: HP ratio UNKNOWN")
        elif boss_hp > 0.50 and my_hp < health_threshold:
            health_moves = tuple(
                value for value in safe_moves if value.total.effective(GemType.HEALTH) > 0
            )
            if health_moves:
                selected = min(
                    health_moves,
                    key=lambda value: self._resource_rank(value, GemType.HEALTH),
                )
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    "STEP_4_HEALTH",
                    f"Boss HP {boss_hp:.3f} > 0.5 and player HP {my_hp:.3f} < {health_threshold:.2f}",
                    failures,
                    health_moves,
                    selected=selected,
                )
            failures.append("STEP_4_HEALTH: low HP condition met but no safe Health move")
        else:
            failures.append("STEP_4_HEALTH: configured HP condition is not met")

        # STEP 5: CAST above the stockpile threshold, then exact high/low
        # boss-resource branches.  `attack_cards` was resolved before STEP 3.
        stockpile = self.config.cast_mana_stockpile_threshold
        if player_mana is not None and player_mana > stockpile:
            usable = tuple(card for card in attack_cards if player_mana >= _attack_cost(card))
            if usable:
                card = min(usable, key=lambda value: (value.card_id, value.object_address))
                return self._decision(
                    state,
                    PolicyAction.CAST,
                    "STEP_5_CAST",
                    f"Player mana {player_mana} > {stockpile}; CAST preserves the configured reserve",
                    failures,
                    evaluations,
                    card=card,
                    candidate_count=len(usable),
                )
            failures.append(f"STEP_5_CAST: mana >{stockpile} but no proven usable Attack card")
        else:
            failures.append(
                f"STEP_5_CAST: player mana is UNKNOWN or not greater than {stockpile}"
            )

        boss_mana = boss.mana if boss is not None else None
        boss_rage = boss.power if boss is not None else None
        high_mana = self.config.boss_high_mana
        high_rage = self.config.boss_high_rage
        low_resource = self.config.boss_low_resource
        drain_moves = tuple(
            value for value in safe_moves if value.total.effective(GemType.DRAIN) > 0
        )
        shield_moves = tuple(
            value for value in safe_moves if value.total.effective(GemType.SHIELD) > 0
        )
        if (
            boss_mana is not None
            and boss_rage is not None
            and boss_mana > high_mana
            and boss_rage > high_rage
        ):
            if drain_moves:
                selected = min(
                    drain_moves,
                    key=lambda value: self._resource_rank(value, GemType.DRAIN),
                )
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    "STEP_5_DRAIN",
                    f"Boss mana {boss_mana} > {high_mana} and Rage {boss_rage} > {high_rage}",
                    failures,
                    drain_moves,
                    selected=selected,
                )
            failures.append("STEP_5_DRAIN: high boss resources but no safe Drain move")
        elif (
            boss_mana is not None
            and boss_rage is not None
            and boss_mana < low_resource
            and boss_rage < low_resource
        ):
            if shield_moves:
                selected = min(
                    shield_moves,
                    key=lambda value: self._resource_rank(value, GemType.SHIELD),
                )
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    "STEP_5_SHIELD",
                    f"Boss mana {boss_mana} and Rage {boss_rage} are both below {low_resource}",
                    failures,
                    shield_moves,
                    selected=selected,
                )
            failures.append("STEP_5_SHIELD: low boss resources but no safe Shield move")
        elif boss_mana is None or boss_rage is None:
            failures.append("STEP_5_RESOURCE: boss Mana/Rage UNKNOWN")
        else:
            # The user permits Drain at this stage only for the explicit high-
            # resource branch above, or when Drain is literally the sole safe
            # move (handled below).  Therefore an available safe Shield is the
            # protective choice for an intermediate boss-resource state.
            if shield_moves:
                selected = min(
                    shield_moves,
                    key=lambda value: self._resource_rank(value, GemType.SHIELD),
                )
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    "STEP_5_SHIELD_INTERMEDIATE",
                    f"Boss resources ({boss_mana}, {boss_rage}) are not high enough for Drain; selected safe Shield",
                    failures,
                    shield_moves,
                    selected=selected,
                )
            failures.append(
                f"STEP_5_RESOURCE: intermediate boss resources ({boss_mana}, {boss_rage}) and no safe Shield move"
            )

        # User rule: Drain is normally resource-dependent, but it is still
        # mandatory when it is literally the only Sword-safe move remaining.
        if len(safe_moves) == 1:
            only_safe = safe_moves[0]
            if only_safe.total.effective(GemType.DRAIN) > 0:
                return self._decision(
                    state,
                    PolicyAction.SWAP,
                    "STEP_5_DRAIN_ONLY_SAFE",
                    "Drain is the only Sword-safe move on the board",
                    failures,
                    safe_moves,
                    selected=only_safe,
                )

        # A low-resource boss normally asks for Shield, but a board may offer
        # no safe Shield/Mana/Rage/Drain move at all.  If every remaining safe
        # candidate is exclusively a Health result, taking the predictable
        # Health move follows the user's rule that PASS is reserved for a
        # board without a safe move.  This is intentionally not a general
        # resource fallback.
        non_health_resources = (
            GemType.SWORD,
            GemType.MANA,
            GemType.RAGE,
            GemType.SHIELD,
            GemType.DRAIN,
        )
        if safe_moves and all(
            value.total.effective(GemType.HEALTH) > 0
            and all(
                value.total.effective(gem) == 0
                for gem in non_health_resources
            )
            for value in safe_moves
        ):
            selected = min(safe_moves, key=self._health_only_fallback_rank)
            return self._decision(
                state,
                PolicyAction.SWAP,
                "STEP_5_HEALTH_ONLY_SAFE",
                "Health is the only safe resource result on the board; selected the most calculable safe Health move",
                failures,
                safe_moves,
                selected=selected,
            )

        # STEP 6/7: PASS requires durable game-owned evidence. Mandatory always wins.
        if mandatory:
            selected = min(evaluations, key=self._mandatory_rank)
            return self._decision(
                state,
                PolicyAction.SWAP,
                "STEP_7_MANDATORY",
                "First runtime local turn or two game-owned consecutive passes prohibits PASS; chose minimum Sword risk with Shield tie-break",
                failures,
                evaluations,
                selected=selected,
            )
        # The user permits PASS only when no Sword-safe move remains.  All
        # explicit resource priorities above have already been exhausted, so
        # retain progress with the lowest-risk safe move instead of inventing
        # an undefined/pause state.  This commonly covers safe Rage after the
        # tactical 100-Rage threshold has already been reached.
        if safe_moves:
            selected = min(safe_moves, key=self._mandatory_rank)
            return self._decision(
                state,
                PolicyAction.SWAP,
                "STEP_5_SAFE_FALLBACK",
                "Explicit resource priorities were exhausted; selected the minimum-risk safe move because PASS requires zero safe moves",
                failures,
                safe_moves,
                selected=selected,
            )
        if not safe_moves:
            skip_count = state.battle.consecutive_passes
            threshold = state.battle.consecutive_pass_threshold
            source = state.battle.consecutive_pass_source
            if idle_status in {
                GameOwnedIdleStatus.RESET_BASELINE_CONFIRMED,
                GameOwnedIdleStatus.PASS_ALLOWED,
            }:
                if idle_status is GameOwnedIdleStatus.RESET_BASELINE_CONFIRMED:
                    evidence = (
                        state.battle.consecutive_pass_reset_evidence
                        or "accepted consuming action"
                    )
                    why = (
                        "No safe move and a production-ready reset baseline "
                        f"is confirmed by {evidence}; PASS is allowed without "
                        "inventing idleCount=0"
                    )
                else:
                    why = (
                        f"No safe move and game-owned {source} reports "
                        f"{skip_count}/{threshold}; PASS is allowed"
                    )
                return self._decision(
                    state,
                    PolicyAction.PASS,
                    "STEP_6_PASS",
                    why,
                    failures,
                    evaluations,
                )
            if idle_status is GameOwnedIdleStatus.UNKNOWN:
                return self._decision(
                    state,
                    PolicyAction.NONE,
                    "STEP_6_PASS",
                    "No safe move, but the game-owned consecutive-pass state is UNKNOWN",
                    failures,
                    evaluations,
                    blocker="GAME_OWNED_SKIP_STATE_UNKNOWN",
                )
            if idle_status is not GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION:
                raise AssertionError("unexpected game-owned idle status")
            selected = min(evaluations, key=self._mandatory_rank)
            return self._decision(
                state,
                PolicyAction.SWAP,
                "STEP_7_MANDATORY",
                f"Game-owned {source} reports {skip_count}/{threshold}; PASS prohibited",
                failures,
                evaluations,
                selected=selected,
            )

        raise AssertionError("safe-move fallback must make STEP 6 exhaustive")
