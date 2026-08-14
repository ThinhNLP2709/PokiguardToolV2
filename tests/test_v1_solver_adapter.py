from __future__ import annotations

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
)
from pokiguard_v2.v1_solver_adapter import V1SolverAdapter


TOKEN = {
    "S": GemType.SWORD,
    "M": GemType.MANA,
    "R": GemType.RAGE,
    "P": GemType.SHIELD,
    "H": GemType.HEALTH,
    "D": GemType.DRAIN,
}


ROWS = (
    "SMSRPHDM",
    "MSRPHDMR",
    "RPHDMRPH",
    "PHDMRPHD",
    "HDMRPHDM",
    "DMRPHDMR",
    "MRPHDMRP",
    "RPHDMRPH",
)


def state_with_multiplier(multiplier: int) -> GameState:
    cells = tuple(
        tuple(
            CellState(
                row,
                col,
                TOKEN[ROWS[row][col]],
                multiplier if (row, col) == (1, 1) else 1,
            )
            for col in range(8)
        )
        for row in range(8)
    )
    return GameState(
        GamePhase.COMBAT,
        "2026-08-12T00:00:00.000Z",
        board=BoardState(cells),
        battle=BattleState(
            board_instance=0x20000000000,
            srv_seq=1,
            stable=True,
            board_hash="fixture",
        ),
    )


class V1SolverAdapterTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls) -> None:
        cls.adapter = V1SolverAdapter(Path(r"D:\PokiguardAuto"))

    def test_imports_exact_read_only_v1_solver(self) -> None:
        solver_path = Path(self.adapter.solver.__file__).resolve()
        self.assertIn(Path(r"D:\PokiguardAuto").resolve(), solver_path.parents)

    def test_multiplier_is_not_discarded(self) -> None:
        moves = self.adapter.evaluate_moves(state_with_multiplier(4))
        target = next(
            move
            for move in moves
            if (move.first, move.second) == ((0, 1), (1, 1))
        )
        sword = self.adapter.models.Token.SWORD
        self.assertEqual(target.collected[sword], 6)

    def test_adapter_returns_v1_decision_without_cv_board(self) -> None:
        decision = self.adapter.decide(state_with_multiplier(2))
        self.assertIn(decision.solver_action, {"move", "skip"})
        self.assertIsNotNone(decision.first)
        self.assertIsNotNone(decision.second)


if __name__ == "__main__":
    unittest.main()
