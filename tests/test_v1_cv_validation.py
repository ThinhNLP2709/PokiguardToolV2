from __future__ import annotations

from pathlib import Path
import sys
import tempfile
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
from pokiguard_v2.v1_cv_validation import V1CvValidator


DEBUG_ROWS = (
    "KMNBHDKM",
    "MNBHDKMN",
    "NBHDKMNB",
    "BHDKMNBH",
    "HDKMNBHD",
    "DKMNBHDK",
    "KMNBHDKM",
    "MNBHDKMN",
)
GEMS = {
    "K": GemType.SWORD,
    "M": GemType.MANA,
    "N": GemType.RAGE,
    "B": GemType.SHIELD,
    "H": GemType.HEALTH,
    "D": GemType.DRAIN,
}


def memory_state() -> GameState:
    board = BoardState(
        tuple(
            tuple(
                CellState(row, col, GEMS[DEBUG_ROWS[row][col]], 1)
                for col in range(8)
            )
            for row in range(8)
        )
    )
    return GameState(
        GamePhase.COMBAT,
        "2026-08-12T00:00:00.000Z",
        board=board,
        battle=BattleState(
            board_instance=0x20000000000,
            srv_seq=3,
            stable=True,
            board_hash="fixture",
        ),
    )


def debug_text(*, source: str = "full", unknown: int = 0) -> str:
    rows = "\n".join(
        f"r{row}   " + "  ".join(DEBUG_ROWS[row]) for row in range(8)
    )
    return (
        "battle=1 turn=1\n"
        f"source={source} unknown={unknown} board_confidence=0.940\n"
        "geometry=first(0.3600,0.1500) step(0.0410,0.0760)\n\n"
        "     c0 c1 c2 c3 c4 c5 c6 c7\n"
        f"{rows}\n\n"
        "confidence:\n"
    )


class V1StructuredDebugAuditTests(unittest.TestCase):
    def test_accepts_only_exact_full_64_cell_artifact(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary)
            board_dir = root / "debug" / "boards"
            board_dir.mkdir(parents=True)
            board_file = board_dir / "b01_turn001.txt"
            board_file.write_text(debug_text(), encoding="utf-8")
            validator = V1CvValidator.__new__(V1CvValidator)
            validator.v1_root = root

            result = validator.compare_debug_snapshot(memory_state(), since_ns=0)

            self.assertIsNotNone(result)
            assert result is not None
            self.assertTrue(result.accepted)
            self.assertEqual(result.cells_compared, 64)
            self.assertEqual(result.gem_matches, 64)
            self.assertEqual(result.multiplier_compared, 0)
            self.assertEqual(result.source, "v1_structured_debug")
            self.assertEqual(result.source_file, str(board_file.resolve()))

    def test_partial_artifact_is_never_promoted(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            root = Path(temporary)
            board_dir = root / "debug" / "boards"
            board_dir.mkdir(parents=True)
            (board_dir / "b01_turn001.txt").write_text(
                debug_text(source="partial", unknown=1), encoding="utf-8"
            )
            validator = V1CvValidator.__new__(V1CvValidator)
            validator.v1_root = root

            result = validator.compare_debug_snapshot(memory_state(), since_ns=0)

            self.assertIsNone(result)


if __name__ == "__main__":
    unittest.main()
