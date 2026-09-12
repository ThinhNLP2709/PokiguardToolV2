"""Read-only Phase 3C.0 classification for post-Pet-Skill continuation.

This module does not grant input authority.  It evaluates the normal Phase 2
actionability gate twice against one fresh state: once exactly as published,
and once with only the durable legend-card contributor removed from the modal
aggregate.  That counterfactual identifies a latched flag without weakening
the production gate.
"""

from __future__ import annotations

from dataclasses import dataclass, replace
from enum import Enum

from .actionability import ActionabilityGate, GateContext, GateReason
from .state import CombatSessionKey, GameState


class LegendContinuationVerdict(str, Enum):
    WAITING_FOR_CURRENT_STATE = "WAITING_FOR_CURRENT_STATE"
    WAITING_FOR_NEXT_LOCAL_TURN = "WAITING_FOR_NEXT_LOCAL_TURN"
    SAME_TURN_ACTIONABLE = "SAME_TURN_ACTIONABLE"
    SAME_TURN_BLOCKED_ONLY_BY_LEGEND_LATCH = (
        "SAME_TURN_BLOCKED_ONLY_BY_LEGEND_LATCH"
    )
    NEXT_LOCAL_TURN_ACTIONABLE = "NEXT_LOCAL_TURN_ACTIONABLE"
    NEXT_LOCAL_TURN_BLOCKED_ONLY_BY_LEGEND_LATCH = (
        "NEXT_LOCAL_TURN_BLOCKED_ONLY_BY_LEGEND_LATCH"
    )
    TURN_CHANGED_BEFORE_CURRENT_SAMPLE = "TURN_CHANGED_BEFORE_CURRENT_SAMPLE"
    SESSION_CHANGED = "SESSION_CHANGED"


@dataclass(frozen=True)
class LegendContinuationSample:
    verdict: LegendContinuationVerdict
    source_turn: int
    observed_turn: int | None
    legend_flag: bool | None
    other_modal_open: bool | None
    actual_gate_reason: GateReason | None
    without_legend_gate_reason: GateReason | None

    @property
    def conclusive_same_turn(self) -> bool:
        return self.verdict in {
            LegendContinuationVerdict.SAME_TURN_ACTIONABLE,
            LegendContinuationVerdict.SAME_TURN_BLOCKED_ONLY_BY_LEGEND_LATCH,
        }

    @property
    def conclusive_continuation(self) -> bool:
        return self.verdict in {
            LegendContinuationVerdict.SAME_TURN_ACTIONABLE,
            LegendContinuationVerdict.SAME_TURN_BLOCKED_ONLY_BY_LEGEND_LATCH,
            LegendContinuationVerdict.NEXT_LOCAL_TURN_ACTIONABLE,
            LegendContinuationVerdict.NEXT_LOCAL_TURN_BLOCKED_ONLY_BY_LEGEND_LATCH,
        }


def classify_legend_card_continuation(
    state: GameState,
    *,
    expected_session: CombatSessionKey,
    source_turn: int,
) -> LegendContinuationSample:
    """Classify one fresh full-board state without changing its real gate."""

    battle = state.battle
    if battle.session_key != expected_session:
        return LegendContinuationSample(
            LegendContinuationVerdict.SESSION_CHANGED,
            source_turn,
            battle.turn_number,
            battle.board_is_using_legend_card,
            None,
            None,
            None,
        )
    if battle.turn_number is None or battle.turn_number < source_turn:
        return LegendContinuationSample(
            LegendContinuationVerdict.TURN_CHANGED_BEFORE_CURRENT_SAMPLE,
            source_turn,
            battle.turn_number,
            battle.board_is_using_legend_card,
            None,
            None,
            None,
        )

    same_turn = battle.turn_number == source_turn
    if not same_turn and battle.is_local_turn is not True:
        return LegendContinuationSample(
            LegendContinuationVerdict.WAITING_FOR_NEXT_LOCAL_TURN,
            source_turn,
            battle.turn_number,
            battle.board_is_using_legend_card,
            None,
            None,
            None,
        )

    modal_values = (
        battle.board_is_using_mega,
        battle.board_is_mega1_panel_open,
        battle.board_is_mega2_panel_open,
    )
    legend = battle.board_is_using_legend_card
    if legend is None or any(value is None for value in modal_values):
        return LegendContinuationSample(
            LegendContinuationVerdict.WAITING_FOR_CURRENT_STATE,
            source_turn,
            battle.turn_number,
            legend,
            None,
            None,
            None,
        )

    other_modal_open = any(bool(value) for value in modal_values)
    context = GateContext(
        current_session=expected_session,
        game_foreground=True,
        window_valid=True,
    )
    actual = ActionabilityGate.evaluate(state, context)
    without_legend = ActionabilityGate.evaluate(
        replace(
            state,
            battle=replace(battle, board_modal_open=other_modal_open),
        ),
        context,
    )
    if actual.actionable:
        verdict = (
            LegendContinuationVerdict.SAME_TURN_ACTIONABLE
            if same_turn
            else LegendContinuationVerdict.NEXT_LOCAL_TURN_ACTIONABLE
        )
    elif (
        legend
        and not other_modal_open
        and actual.reason is GateReason.MODAL_OPEN
        and without_legend.actionable
    ):
        verdict = (
            LegendContinuationVerdict.SAME_TURN_BLOCKED_ONLY_BY_LEGEND_LATCH
            if same_turn
            else LegendContinuationVerdict.NEXT_LOCAL_TURN_BLOCKED_ONLY_BY_LEGEND_LATCH
        )
    else:
        verdict = LegendContinuationVerdict.WAITING_FOR_CURRENT_STATE
    return LegendContinuationSample(
        verdict,
        source_turn,
        battle.turn_number,
        legend,
        other_modal_open,
        actual.reason,
        without_legend.reason,
    )
