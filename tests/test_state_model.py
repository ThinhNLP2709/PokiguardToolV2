from __future__ import annotations

from enum import Enum
from pathlib import Path
import sys
import unittest


SRC = Path(__file__).resolve().parents[1] / "src"
if str(SRC) not in sys.path:
    sys.path.insert(0, str(SRC))

from pokiguard_v2.state import (
    BattleState,
    BoardState,
    CellState,
    GamePhase,
    GameState,
    GemType,
    adapt_board_to_enum,
)


class V1TokenFixture(str, Enum):
    SWORD = "sword"
    MANA = "mana"
    RAGE = "rage"
    SHIELD = "shield"
    HEALTH = "health"
    DRAIN = "drain"
    UNKNOWN = "unknown"


def cell_board(gem: GemType = GemType.SWORD) -> BoardState:
    return BoardState(
        tuple(
            tuple(CellState(row, col, gem, 1 + col % 4) for col in range(8))
            for row in range(8)
        )
    )


def combat_state(board: BoardState | None = None) -> GameState:
    return GameState(
        GamePhase.COMBAT,
        "2026-08-12T00:00:00.000Z",
        board=board or cell_board(),
        battle=BattleState(
            board_instance=0x20000000000,
            srv_seq=10,
            turn_number=3,
            stable=True,
            board_hash="abc",
        ),
    )


class StateModelTests(unittest.TestCase):
    def test_accepts_exact_8x8_and_adapts_to_v1_values(self) -> None:
        state = combat_state()
        assert state.board is not None
        adapted = adapt_board_to_enum(state.board.board, V1TokenFixture)
        self.assertEqual(adapted[0][0], V1TokenFixture.SWORD)
        self.assertEqual(len(adapted), 8)
        self.assertEqual(state.dedup_key, (0x20000000000, 10, "abc"))

    def test_lobby_has_no_board(self) -> None:
        state = GameState(GamePhase.LOBBY, "2026-08-12T00:00:00.000Z")
        self.assertIsNone(state.board)
        with self.assertRaises(ValueError):
            GameState(
                GamePhase.LOBBY,
                "2026-08-12T00:00:00.000Z",
                board=cell_board(),
            )

    def test_rejects_non_8x8_board(self) -> None:
        bad = tuple(
            tuple(CellState(row, col, GemType.MANA, 1) for col in range(8))
            for row in range(7)
        )
        with self.assertRaises(ValueError):
            BoardState(bad)  # type: ignore[arg-type]

    def test_rejects_unproven_multiplier(self) -> None:
        with self.assertRaises(ValueError):
            CellState(0, 0, GemType.HEALTH, 5)

    def test_adapter_accepts_actual_v1_token_when_reference_is_available(self) -> None:
        v1_root = Path(r"D:\PokiguardAuto")
        if not v1_root.is_dir():
            self.skipTest("PokiguardAuto reference folder is not available")
        if str(v1_root) not in sys.path:
            sys.path.insert(0, str(v1_root))
        from pokiguard_auto.models import Token

        adapted = adapt_board_to_enum(cell_board(GemType.DRAIN).board, Token)
        self.assertEqual(adapted[7][7], Token.DRAIN)

    def test_cell_board_exposes_parallel_multiplier_view(self) -> None:
        state = cell_board(GemType.MANA)
        self.assertEqual(state.board[7][7], GemType.MANA)
        self.assertEqual(state.multipliers[0], (1, 2, 3, 4, 1, 2, 3, 4))
        self.assertTrue(state.production_ready)

    def test_cell_board_rejects_misplaced_coordinates(self) -> None:
        cells = list(cell_board(GemType.RAGE).cells)
        cells[0] = (CellState(1, 0, GemType.RAGE, 1),) + cells[0][1:]
        with self.assertRaises(ValueError):
            BoardState(tuple(cells))

    def test_last_move_runtime_evidence_is_bounded(self) -> None:
        self.assertEqual(BattleState(last_move_sequence=-1).last_move_sequence, -1)
        battle = BattleState(
            local_move_sequence=22,
            last_move_sequence=22,
            last_move_from_col=1,
            last_move_from_row=5,
            last_move_to_col=0,
            last_move_to_row=5,
        )
        self.assertEqual(battle.last_move_sequence, 22)
        with self.assertRaises(ValueError):
            BattleState(last_move_sequence=1, last_move_from_col=8)


if __name__ == "__main__":
    unittest.main()
