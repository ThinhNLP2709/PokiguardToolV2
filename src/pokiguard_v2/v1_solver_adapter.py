"""Read-only adapter from V2 GameState to the unmodified V1 solver modules."""

from __future__ import annotations

from dataclasses import dataclass
import importlib
import json
from pathlib import Path
import sys
from typing import Any

from .state import GameState, GamePhase, PossibleAction, adapt_board_to_enum


@dataclass(frozen=True)
class V1ContextHints:
    """Optional CV/session facts that memory has not proven yet."""

    player_hp_ratio: float | None = None
    enemy_hp_ratio: float | None = None
    player_mana_value: int | None = None
    player_rage_value: int | None = None
    enemy_mana_value: int | None = None
    enemy_rage_value: int | None = None
    evolution_available: bool | None = None
    attack_available: bool | None = None
    evolution_used: bool | None = None
    finishing_phase: bool | None = None


@dataclass
class V1ShadowSession:
    consecutive_skips: int = 0
    published_turns: int = 0


@dataclass(frozen=True)
class ShadowDecision:
    solver_action: str
    possible_actions: tuple[PossibleAction, ...]
    reason: str
    first: tuple[int, int] | None
    second: tuple[int, int] | None
    score: float | None
    collected: tuple[tuple[str, int], ...]
    cascade_count: int | None
    longest_match: int | None
    opponent_swords: int | None
    sword_drop_risk: int | None


def _ratio(current: int | None, maximum: int | None) -> float | None:
    if current is None or maximum is None or maximum <= 0:
        return None
    return min(1.0, max(0.0, float(current) / float(maximum)))


class V1SolverAdapter:
    """Imports ``PokiguardAuto`` in place; no source is copied or modified."""

    def __init__(self, v1_root: Path) -> None:
        self.v1_root = v1_root.resolve()
        package = self.v1_root / "pokiguard_auto"
        if not package.is_dir():
            raise FileNotFoundError(f"V1 package not found: {package}")
        if str(self.v1_root) not in sys.path:
            sys.path.insert(0, str(self.v1_root))
        self.models = importlib.import_module("pokiguard_auto.models")
        self.solver = importlib.import_module("pokiguard_auto.solver")
        module_path = Path(self.solver.__file__).resolve()
        if self.v1_root not in module_path.parents:
            raise RuntimeError(f"refusing unexpected V1 solver module: {module_path}")
        config_path = self.v1_root / "config.json"
        self.config: dict[str, Any] = {}
        if config_path.exists():
            value = json.loads(config_path.read_text(encoding="utf-8"))
            if isinstance(value, dict):
                self.config = value

    def _combat_context(
        self, state: GameState, hints: V1ContextHints | None
    ) -> Any:
        hints = hints or V1ContextHints()
        player = state.player
        boss = next(
            (participant for participant in state.opponents if participant.is_boss),
            state.opponents[0] if state.opponents else None,
        )
        player_hp = (
            _ratio(player.hp, player.max_hp) if player is not None else None
        )
        enemy_hp = _ratio(boss.hp, boss.max_hp) if boss is not None else None
        player_mana_value = (
            player.mana if player is not None and player.mana is not None else None
        )
        player_rage_value = (
            player.power if player is not None and player.power is not None else None
        )
        enemy_mana_value = (
            boss.mana if boss is not None and boss.mana is not None else None
        )
        enemy_rage_value = (
            boss.power if boss is not None and boss.power is not None else None
        )
        fusion_available = (
            state.fusion.available if state.fusion is not None else None
        )
        fusion_used = state.fusion.used if state.fusion is not None else None
        attack_available = any(card.is_attack and card.interactable for card in state.cards)
        return self.models.CombatContext(
            player_hp=(
                player_hp
                if player_hp is not None
                else hints.player_hp_ratio
                if hints.player_hp_ratio is not None
                else 1.0
            ),
            enemy_hp=(
                enemy_hp
                if enemy_hp is not None
                else hints.enemy_hp_ratio
                if hints.enemy_hp_ratio is not None
                else 1.0
            ),
            player_rage=min(
                1.0,
                max(
                    0.0,
                    float(
                        player_rage_value
                        if player_rage_value is not None
                        else hints.player_rage_value or 0
                    )
                    / 100.0,
                ),
            ),
            enemy_rage=min(
                1.0,
                max(
                    0.0,
                    float(
                        enemy_rage_value
                        if enemy_rage_value is not None
                        else hints.enemy_rage_value or 0
                    )
                    / 100.0,
                ),
            ),
            # These divisors intentionally preserve V1's current contract.
            player_mana=min(
                1.0,
                max(
                    0.0,
                    float(
                        player_mana_value
                        if player_mana_value is not None
                        else hints.player_mana_value or 0
                    )
                    / 160.0,
                ),
            ),
            enemy_mana=min(
                1.0,
                max(
                    0.0,
                    float(
                        enemy_mana_value
                        if enemy_mana_value is not None
                        else hints.enemy_mana_value or 0
                    )
                    / 160.0,
                ),
            ),
            evolution_available=(
                fusion_available
                if fusion_available is not None
                else bool(hints.evolution_available)
            ),
            attack_available=(
                attack_available
                if state.cards
                else bool(hints.attack_available)
            ),
            evolution_used=(
                fusion_used
                if fusion_used is not None
                else bool(hints.evolution_used)
            ),
            battle_strategy=str(self.config.get("battle_strategy", "careful")),
            finishing_phase=bool(hints.finishing_phase),
            defensive_hp_threshold=float(
                self.config.get("defensive_hp_threshold", 0.48)
            ),
            safe_mode_hp=float(self.config.get("safe_sword_avoid_hp", 0.35)),
            avoid_leaving_swords_for_boss=bool(
                self.config.get("avoid_leaving_swords_for_boss", False)
            ),
            max_acceptable_sword_drop_risk=int(
                self.config.get("max_acceptable_sword_drop_risk", 3)
            ),
            drain_useful_bar=float(self.config.get("drain_useful_bar", 0.5)),
            drain_useful_mana_bar=float(
                self.config.get("drain_useful_mana_bar", 0.3125)
            ),
            drain_defensive_bar=float(
                self.config.get("drain_defensive_bar", 0.5)
            ),
            drain_defensive_mana_bar=float(
                self.config.get("drain_defensive_mana_bar", 0.3125)
            ),
        )

    def decide(
        self,
        state: GameState,
        *,
        hints: V1ContextHints | None = None,
        session: V1ShadowSession | None = None,
    ) -> ShadowDecision:
        if state.phase is not GamePhase.COMBAT or state.board is None:
            raise ValueError("V1 solver requires a stable combat GameState")
        session = session or V1ShadowSession()
        board = adapt_board_to_enum(state.board.board, self.models.Token)
        multipliers = state.board.multipliers
        context = self._combat_context(state, hints)
        opening = session.published_turns == 0
        allow_skip = bool(self.config.get("smart_skip", True)) and (
            session.published_turns + 1
            >= int(self.config.get("smart_skip_min_player_turn", 10))
        )
        decision = self.solver.decide_turn(
            board,
            context,
            consecutive_skips=session.consecutive_skips,
            blocked=set(),
            multipliers=multipliers,
            max_consecutive_skips=int(self.config.get("max_consecutive_skips", 2)),
            allow_skip=allow_skip and not opening,
            skip_min_player_hp=float(self.config.get("skip_min_player_hp", 0.40)),
            skip_bad_board_score=float(
                self.config.get("skip_bad_board_score", 26.0)
            ),
            many_swords_threshold=int(
                self.config.get("many_swords_threshold", 14)
            ),
            aggressive_finish_hp=float(
                self.config.get("aggressive_finish_hp", 0.30)
            ),
            solver_mode=str(self.config.get("solver_mode", "default")),
            ai_time_budget_ms=int(self.config.get("ai_time_budget_ms", 900)),
            ai_candidates=int(self.config.get("ai_candidates", 10)),
            ai_rollouts=int(self.config.get("ai_rollouts", 6)),
            refill_risk_samples=int(self.config.get("refill_risk_samples", 6)),
            max_safe_boss_swords=int(
                self.config.get("max_safe_boss_swords", 3)
            ),
            opening_required=opening,
            late_game_skip_allowed=allow_skip,
        )
        move = decision.move
        possible: list[PossibleAction] = []
        if move is not None:
            possible.append(PossibleAction.SWAP)
        if any(card.interactable for card in state.cards):
            possible.append(PossibleAction.USE_CARD)
        if state.fusion is not None and state.fusion.available:
            possible.append(PossibleAction.FUSION)
        if not possible or decision.action == "skip":
            possible.append(PossibleAction.NONE)
        session.published_turns += 1
        if decision.action == "skip":
            session.consecutive_skips += 1
        elif move is not None:
            session.consecutive_skips = 0
        return ShadowDecision(
            solver_action=decision.action,
            possible_actions=tuple(dict.fromkeys(possible)),
            reason=decision.reason,
            first=move.first if move is not None else None,
            second=move.second if move is not None else None,
            score=move.score if move is not None else None,
            collected=(
                tuple(sorted((token.value, count) for token, count in move.collected.items()))
                if move is not None
                else ()
            ),
            cascade_count=move.cascade_count if move is not None else None,
            longest_match=move.longest_match if move is not None else None,
            opponent_swords=move.opponent_swords if move is not None else None,
            sword_drop_risk=move.sword_drop_risk if move is not None else None,
        )

    def evaluate_moves(
        self,
        state: GameState,
        *,
        hints: V1ContextHints | None = None,
        blocked: set[tuple[tuple[int, int], tuple[int, int]]] | None = None,
        refill_risk_samples: int = 0,
    ) -> list[Any]:
        """Expose the exact lower-level V1 entrypoint for audits/tests."""

        if state.phase is not GamePhase.COMBAT or state.board is None:
            raise ValueError("V1 solver requires a stable combat GameState")
        return self.solver.evaluate_moves(
            adapt_board_to_enum(state.board.board, self.models.Token),
            self._combat_context(state, hints),
            blocked=blocked,
            multipliers=state.board.multipliers,
            refill_risk_samples=refill_risk_samples,
        )
