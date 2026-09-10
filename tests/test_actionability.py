from __future__ import annotations

from dataclasses import replace
from pathlib import Path
import sys
import unittest


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.actionability import (
    ActionabilityGate,
    GateContext,
    GateReason,
)
from pokiguard_v2.combat_lifecycle import CombatLifecycleState
from pokiguard_v2.state import (
    BattleState,
    BoardState,
    CellState,
    CombatSessionKey,
    GamePhase,
    GameState,
    GemType,
    ParticipantState,
)


SESSION = CombatSessionKey(1, 0x200000, "match-1")


def board() -> BoardState:
    gems = tuple(GemType)
    return BoardState(
        tuple(
            tuple(
                CellState(row, col, gems[(row * 8 + col) % 6], 1)
                for col in range(8)
            )
            for row in range(8)
        )
    )


def actionable_state() -> GameState:
    player = ParticipantState(1, True, False, 100, 200)
    boss = ParticipantState(99, False, True, 500, 1000)
    return GameState(
        GamePhase.COMBAT,
        "now",
        board(),
        BattleState(
            combat_lifecycle=CombatLifecycleState.ACTIVE,
            board_instance=SESSION.board_instance,
            srv_seq=75,
            turn_number=10,
            current_turn_player="Happi",
            stable=True,
            board_hash="a" * 64,
            sources=("MatchService._ackedSeqs+postLobbyHeap",),
            session_key=SESSION,
            match_id=SESSION.match_id,
            acknowledged=True,
            latest=True,
            is_board_ready=True,
            is_cascade_running=False,
            board_current_state=1,
            board_has_destroyed_this_turn=False,
            board_is_processing_ui=False,
            board_is_game_over=False,
            board_modal_open=False,
            board_is_resuming=False,
            match_over=False,
            deferred_game_over=False,
            start_gate_paused=False,
            clock_paused=False,
            connection_ready=True,
            reconnecting=False,
            match_resyncing=False,
            presentation_busy=False,
            local_username="happi",
            is_local_turn=True,
            local_actor_number=1,
            client_move_allowed=True,
        ),
        player,
        (boss,),
        (player, boss),
    )


def context(**changes: object) -> GateContext:
    values = dict(
        current_session=SESSION,
        game_foreground=True,
        window_valid=True,
        input_locked=False,
        auto_paused=False,
    )
    values.update(changes)
    return GateContext(**values)


class ActionabilityGateTests(unittest.TestCase):
    def test_full_proven_state_passes(self) -> None:
        result = ActionabilityGate.evaluate(actionable_state(), context())
        self.assertTrue(result.actionable)
        self.assertEqual(result.reason, GateReason.PASS)

    def test_local_player_left_signal_blocks_all_gameplay(self) -> None:
        state = actionable_state()
        left = replace(
            state,
            battle=replace(
                state.battle,
                local_has_left_match=True,
                client_move_allowed=False,
            ),
        )
        result = ActionabilityGate.evaluate(left, context())
        self.assertFalse(result.actionable)
        self.assertEqual(result.reason, GateReason.LOCAL_PLAYER_LEFT)

    def test_exact_match_start_sequence_is_authoritative_without_ack(self) -> None:
        state = actionable_state()
        opening = replace(
            state,
            battle=replace(
                state.battle,
                srv_seq=3,
                sources=("ChatMessageDTO.MATCH_START.matchPayload.board",),
                acknowledged=False,
                turn_number=1,
                local_move_sequence=0,
                last_move_sequence=None,
            ),
        )
        result = ActionabilityGate.evaluate(opening, context())
        self.assertTrue(result.actionable)
        self.assertEqual(result.reason, GateReason.PASS)

    def test_exact_opening_can_be_board_only_when_stats_have_not_hydrated(self) -> None:
        state = actionable_state()
        opening = replace(
            state,
            player=None,
            opponents=(),
            participants=(),
            battle=replace(
                state.battle,
                srv_seq=3,
                sources=("ChatMessageDTO.MATCH_START.matchPayload.board",),
                acknowledged=False,
                turn_number=1,
                local_move_sequence=0,
                last_move_sequence=None,
            ),
        )

        strict = ActionabilityGate.evaluate(opening, context())
        self.assertEqual(strict.reason, GateReason.PLAYER_STATS_UNKNOWN)

        board_only = ActionabilityGate.evaluate(
            opening,
            context(allow_opening_board_only=True),
        )
        self.assertTrue(board_only.actionable, board_only)
        self.assertTrue(board_only.details["openingBoardOnly"])
        self.assertIsNone(board_only.details["playerHp"])
        self.assertIsNone(board_only.details["bossHp"])

    def test_board_only_stats_exception_is_opening_and_connection_scoped(self) -> None:
        state = actionable_state()
        missing = replace(state, player=None, opponents=(), participants=())
        self.assertEqual(
            ActionabilityGate.evaluate(
                missing,
                context(allow_opening_board_only=True),
            ).reason,
            GateReason.PLAYER_STATS_UNKNOWN,
        )

        disconnected_opening = replace(
            missing,
            battle=replace(
                missing.battle,
                srv_seq=3,
                sources=("ChatMessageDTO.MATCH_START.matchPayload.board",),
                acknowledged=False,
                turn_number=1,
                local_move_sequence=0,
                last_move_sequence=None,
                connection_ready=False,
            ),
        )
        self.assertEqual(
            ActionabilityGate.evaluate(
                disconnected_opening,
                context(allow_opening_board_only=True),
            ).reason,
            GateReason.DISCONNECTED,
        )

    def test_explicit_authoritative_board_only_stats_fallback_is_not_opening_only(self) -> None:
        state = actionable_state()
        missing = replace(state, player=None, opponents=(), participants=())

        strict = ActionabilityGate.evaluate(missing, context())
        self.assertEqual(GateReason.PLAYER_STATS_UNKNOWN, strict.reason)

        fallback = ActionabilityGate.evaluate(
            missing,
            context(allow_authoritative_board_only_stats=True),
        )
        self.assertTrue(fallback.actionable, fallback)
        self.assertTrue(fallback.details["boardOnlyStatsFallback"])
        self.assertFalse(fallback.details["openingBoardOnly"])

        disconnected = replace(
            missing,
            battle=replace(missing.battle, connection_ready=False),
        )
        self.assertEqual(
            GateReason.DISCONNECTED,
            ActionabilityGate.evaluate(
                disconnected,
                context(allow_authoritative_board_only_stats=True),
            ).reason,
        )

    def test_acked_match_move_transport_board_is_authoritative(self) -> None:
        state = actionable_state()
        transport = replace(
            state,
            battle=replace(
                state.battle,
                sources=(
                    "ChatMessageDTO.MATCH_MOVE_RES.matchPayload.board+"
                    "MatchService._ackedSeqs",
                ),
            ),
        )
        result = ActionabilityGate.evaluate(transport, context())
        self.assertTrue(result.actionable, result)
        self.assertEqual(result.reason, GateReason.PASS)

    def test_sequence_zero_without_match_start_source_fails_closed(self) -> None:
        state = actionable_state()
        unowned = replace(
            state,
            battle=replace(
                state.battle,
                srv_seq=0,
                sources=("bounded_heap_scan",),
                acknowledged=False,
            ),
        )
        self.assertEqual(
            ActionabilityGate.evaluate(unowned, context()).reason,
            GateReason.INVALID_BOARD,
        )

    def test_out_of_range_match_start_sequence_fails_closed(self) -> None:
        state = actionable_state()
        invalid = replace(
            state,
            battle=replace(
                state.battle,
                srv_seq=10_000_001,
                sources=("ChatMessageDTO.MATCH_START.matchPayload.board",),
                acknowledged=False,
            ),
        )
        self.assertEqual(
            ActionabilityGate.evaluate(invalid, context()).reason,
            GateReason.INVALID_BOARD,
        )

    def test_match_start_source_after_local_move_fails_closed(self) -> None:
        state = actionable_state()
        stale_opening = replace(
            state,
            battle=replace(
                state.battle,
                srv_seq=3,
                sources=("ChatMessageDTO.MATCH_START.matchPayload.board",),
                acknowledged=False,
                turn_number=1,
                local_move_sequence=1,
                last_move_sequence=1,
            ),
        )
        self.assertEqual(
            ActionabilityGate.evaluate(stale_opening, context()).reason,
            GateReason.INVALID_BOARD,
        )

    def test_lobby_and_wrong_session_fail(self) -> None:
        lobby = GameState(
            GamePhase.LOBBY,
            "now",
            battle=BattleState(combat_lifecycle=CombatLifecycleState.LOBBY),
        )
        self.assertEqual(
            ActionabilityGate.evaluate(lobby, context()).reason,
            GateReason.LOBBY,
        )
        self.assertEqual(
            ActionabilityGate.evaluate(
                actionable_state(), context(current_session=None)
            ).reason,
            GateReason.INVALID_SESSION,
        )

    def test_every_non_active_lifecycle_has_a_specific_rejection(self) -> None:
        expected = {
            CombatLifecycleState.ENTERING: GateReason.ENTERING_COMBAT,
            CombatLifecycleState.LEAVING: GateReason.LEAVING_COMBAT,
            CombatLifecycleState.POSTMATCH: GateReason.POSTMATCH,
            CombatLifecycleState.STALE_SERVER_MATCH: GateReason.STALE_SERVER_MATCH,
            CombatLifecycleState.UNKNOWN: GateReason.LIFECYCLE_UNKNOWN,
        }
        state = actionable_state()
        for lifecycle, reason in expected.items():
            with self.subTest(lifecycle=lifecycle):
                candidate = replace(
                    state,
                    battle=replace(state.battle, combat_lifecycle=lifecycle),
                )
                self.assertEqual(
                    ActionabilityGate.evaluate(candidate, context()).reason,
                    reason,
                )

    def test_turn_unknown_and_not_local_are_distinct(self) -> None:
        state = actionable_state()
        unknown = replace(state, battle=replace(state.battle, is_local_turn=None))
        other = replace(state, battle=replace(state.battle, is_local_turn=False))
        self.assertEqual(
            ActionabilityGate.evaluate(unknown, context()).reason,
            GateReason.TURN_UNKNOWN,
        )
        self.assertEqual(
            ActionabilityGate.evaluate(other, context()).reason,
            GateReason.NOT_LOCAL_TURN,
        )

    def test_unstable_processing_and_wait_state_are_blocked(self) -> None:
        state = actionable_state()
        unstable = replace(
            state, battle=replace(state.battle, is_cascade_running=True)
        )
        processing = replace(
            state, battle=replace(state.battle, board_is_processing_ui=True)
        )
        waiting = replace(
            state, battle=replace(state.battle, board_current_state=0)
        )
        self.assertEqual(
            ActionabilityGate.evaluate(unstable, context()).reason,
            GateReason.BOARD_UNSTABLE,
        )
        self.assertEqual(
            ActionabilityGate.evaluate(processing, context()).reason,
            GateReason.PRESENTATION_BUSY,
        )
        self.assertEqual(
            ActionabilityGate.evaluate(waiting, context()).reason,
            GateReason.BOARD_NOT_MOVE_STATE,
        )

    def test_player_and_boss_death_are_distinct(self) -> None:
        state = actionable_state()
        dead_player = replace(state, player=replace(state.player, hp=0))
        dead_boss = replace(
            state,
            opponents=(replace(state.opponents[0], hp=0),),
        )
        self.assertEqual(
            ActionabilityGate.evaluate(dead_player, context()).reason,
            GateReason.PLAYER_DEAD,
        )
        self.assertEqual(
            ActionabilityGate.evaluate(dead_boss, context()).reason,
            GateReason.BOSS_DEAD,
        )

    def test_end_modal_connection_and_foreground_fail_closed(self) -> None:
        state = actionable_state()
        cases = (
            (
                replace(state, battle=replace(state.battle, match_over=True)),
                GateReason.MATCH_OVER,
            ),
            (
                replace(state, battle=replace(state.battle, board_modal_open=True)),
                GateReason.MODAL_OPEN,
            ),
            (
                replace(state, battle=replace(state.battle, reconnecting=True)),
                GateReason.RECONNECTING,
            ),
            (
                replace(state, battle=replace(state.battle, connection_ready=False)),
                GateReason.DISCONNECTED,
            ),
        )
        for candidate, reason in cases:
            with self.subTest(reason=reason):
                self.assertEqual(
                    ActionabilityGate.evaluate(candidate, context()).reason,
                    reason,
                )
        self.assertEqual(
            ActionabilityGate.evaluate(
                state, context(game_foreground=False)
            ).reason,
            GateReason.GAME_NOT_FOREGROUND,
        )

    def test_clock_paused_returns_detail_without_duplicate_reason_argument(self) -> None:
        """Regression: post-Fusion pause used to crash Stage B2 with TypeError."""

        state = actionable_state()
        paused = replace(
            state,
            battle=replace(
                state.battle,
                clock_paused=True,
                clock_pause_reason="fusion_transition",
            ),
        )
        result = ActionabilityGate.evaluate(paused, context())
        self.assertFalse(result.actionable)
        self.assertEqual(result.reason, GateReason.CLOCK_PAUSED)
        self.assertEqual(result.details["clockPauseReason"], "fusion_transition")
        self.assertFalse(result.details["startGatePaused"])


if __name__ == "__main__":
    unittest.main()
