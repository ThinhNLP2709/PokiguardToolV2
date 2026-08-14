from __future__ import annotations

from dataclasses import replace
import json
from pathlib import Path
import tempfile
import unittest

from pokiguard_v2.board_diagnostics import (
    MoveTimingClassification,
    analyze_game_state,
    board_cells_payload,
    classify_move_timing,
    game_state_from_payload,
    game_state_payload,
    write_diagnostic_artifact,
)
from tools.replay_board_state import replay
from tests.test_basic_policy import combat_state, no_sword_or_mana_board
from tests.test_board_simulator import cyclic_board, fixture_board


def current_state(board):
    state = combat_state(board=board, rage=100)
    return replace(
        state,
        battle=replace(
            state.battle,
            board_hash="a" * 64,
            acknowledged=True,
            latest=True,
            is_board_ready=True,
            is_cascade_running=False,
        ),
    )


class BoardDiagnosticTests(unittest.TestCase):
    def test_exhaustive_counts_separate_legality_and_safety(self) -> None:
        analysis = analyze_game_state(current_state(fixture_board()))
        self.assertEqual(analysis.total_adjacent_swaps, 112)
        self.assertEqual(
            analysis.legal_match_producing_moves + analysis.illegal_no_match_swaps,
            112,
        )
        self.assertEqual(
            analysis.safe_move_count + analysis.dangerous_move_count,
            analysis.legal_match_producing_moves,
        )
        self.assertFalse(analysis.dead_board)
        self.assertEqual(len(analysis.legal_moves), analysis.legal_match_producing_moves)

    def test_exact_dead_board_requires_all_runtime_gates(self) -> None:
        analysis = analyze_game_state(current_state(cyclic_board()))
        self.assertEqual(analysis.legal_match_producing_moves, 0)
        self.assertTrue(analysis.dead_board)
        self.assertEqual(analysis.policy["action"], "exit_match")

        unstable = current_state(cyclic_board())
        unstable = replace(unstable, battle=replace(unstable.battle, latest=False))
        self.assertIsNone(analyze_game_state(unstable).dead_board)

    def test_exact_opening_snapshot_can_prove_dead_board_without_ack(self) -> None:
        state = current_state(cyclic_board())
        opening = replace(
            state,
            battle=replace(
                state.battle,
                acknowledged=False,
                turn_number=1,
                local_move_sequence=0,
                last_move_sequence=None,
                sources=(
                    "ChatMessageDTO.MATCH_START.matchPayload.board",
                ),
            ),
        )
        self.assertTrue(analyze_game_state(opening).dead_board)

    def test_cells_store_runtime_and_screen_coordinates(self) -> None:
        cells = board_cells_payload(fixture_board())
        self.assertEqual(len(cells), 64)
        top_left = cells[0]
        self.assertEqual(
            (top_left["screenRow"], top_left["runtimeRow"]), (0, 7)
        )

    def test_artifact_round_trip_and_replay_are_deterministic(self) -> None:
        state = current_state(cyclic_board())
        analysis = analyze_game_state(state)
        with tempfile.TemporaryDirectory() as directory:
            artifact = write_diagnostic_artifact(
                Path(directory), event="dead_board", state=state, analysis=analysis
            )
            payload = json.loads(artifact.board_json.read_text(encoding="utf-8"))
            restored = game_state_from_payload(payload)
            self.assertEqual(restored.board, state.board)
            first = replay(artifact.board_json)
            second = replay(artifact.board_json)
            self.assertEqual(first, second)
            self.assertTrue(first["deadBoard"])
            self.assertEqual(first["legalMoveCount"], 0)

    def test_game_state_payload_rejects_coordinate_tampering(self) -> None:
        payload = game_state_payload(current_state(fixture_board()))
        payload["cells"][0]["runtimeRow"] = 0
        with self.assertRaises(ValueError):
            game_state_from_payload(payload)

    def test_timer_classifications_do_not_call_legal_board_dead(self) -> None:
        self.assertEqual(
            classify_move_timing(
                legal_move_count=0, remaining_seconds=10, attempted=False
            ),
            MoveTimingClassification.NO_LEGAL_MOVE,
        )
        self.assertEqual(
            classify_move_timing(
                legal_move_count=5, remaining_seconds=1, attempted=False
            ),
            MoveTimingClassification.MOVE_NOT_ATTEMPTED_TOO_LATE,
        )
        self.assertEqual(
            classify_move_timing(
                legal_move_count=5, remaining_seconds=1, attempted=True
            ),
            MoveTimingClassification.MOVE_ATTEMPTED_TOO_LATE,
        )
        self.assertEqual(
            classify_move_timing(
                legal_move_count=5,
                remaining_seconds=0,
                attempted=True,
                accepted=False,
                reject_reason="deadline timeout",
            ),
            MoveTimingClassification.MOVE_REJECTED_TIMEOUT,
        )
        self.assertEqual(
            classify_move_timing(
                legal_move_count=1,
                remaining_seconds=9,
                attempted=True,
                accepted=False,
                reject_reason="SeqNum gap/duplicate — resync needed",
            ),
            MoveTimingClassification.MOVE_REJECTED_SEQUENCE_DESYNC,
        )

    def test_none_policy_contains_required_why_not_observability(self) -> None:
        analysis = analyze_game_state(current_state(no_sword_or_mana_board()))
        if analysis.policy["action"] in {"none", "pass"}:
            self.assertEqual(
                set(analysis.policy_observability["whyNot"]),
                {"Sword", "Rage", "Mana", "Health", "Cast", "Drain", "Shield"},
            )


if __name__ == "__main__":
    unittest.main()
