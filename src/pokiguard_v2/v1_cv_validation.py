"""Optional live V1 CV observer used only to validate memory snapshots."""

from __future__ import annotations

from dataclasses import dataclass
import hashlib
import importlib
import json
from pathlib import Path
import re
import sys
from typing import Any

from .state import GameState, GamePhase
from .v1_solver_adapter import V1ContextHints


@dataclass(frozen=True)
class CvComparison:
    accepted: bool
    reason: str
    cells_compared: int = 0
    gem_matches: int = 0
    gem_mismatches: tuple[tuple[int, int, str, str], ...] = ()
    unknowns: int = 0
    multiplier_compared: int = 0
    multiplier_matches: int = 0
    multiplier_mismatches: tuple[tuple[int, int, int, int], ...] = ()
    cv_hash: str | None = None
    source: str = "live_v1_cv"
    source_file: str | None = None


class V1CvValidator:
    """Captures/analyzes through V1's unmodified read-only vision classes."""

    def __init__(self, v1_root: Path) -> None:
        self.v1_root = v1_root.resolve()
        if str(self.v1_root) not in sys.path:
            sys.path.insert(0, str(self.v1_root))
        vision = importlib.import_module("pokiguard_auto.vision")
        win32 = importlib.import_module("pokiguard_auto.win32")
        config_path = self.v1_root / "config.json"
        config: dict[str, Any] = {}
        if config_path.exists():
            loaded = json.loads(config_path.read_text(encoding="utf-8"))
            if isinstance(loaded, dict):
                config = loaded
        geometry = vision.BoardGeometry(
            first_center_x=float(config.get("board_first_center_x", 0.360)),
            first_center_y=float(config.get("board_first_center_y", 0.150)),
            step_x=float(config.get("board_step_x", 0.0410)),
            step_y=float(config.get("board_step_y", 0.0760)),
        )
        self.window_title = str(config.get("window_title", "PokiguardOnlines"))
        self._find_window = win32.find_window
        self._capture = win32.WindowCapture()
        self._analyzer = vision.VisionAnalyzer(
            geometry,
            use_template_matching=bool(config.get("use_template_matching", True)),
        )

    def close(self) -> None:
        self._capture.close()

    def __enter__(self) -> "V1CvValidator":
        return self

    def __exit__(self, *_args: object) -> None:
        self.close()

    def observe(self) -> Any | None:
        hwnd = self._find_window(self.window_title)
        if hwnd is None:
            return None
        frame = self._capture.grab(hwnd)
        return self._analyzer.analyze(frame) if frame is not None else None

    @staticmethod
    def context_hints(observation: Any | None) -> V1ContextHints:
        if observation is None:
            return V1ContextHints()
        return V1ContextHints(
            player_hp_ratio=observation.player_hp,
            enemy_hp_ratio=observation.enemy_hp,
            player_mana_value=observation.player_mana_value,
            player_rage_value=observation.player_rage_value,
            enemy_mana_value=observation.enemy_mana_value,
            enemy_rage_value=observation.enemy_rage_value,
            evolution_available=observation.evolution_active,
            attack_available=observation.attack_active,
            finishing_phase=(
                observation.enemy_hp_below_30000 is True
                or observation.enemy_hp <= 0.30
            ),
        )

    @staticmethod
    def compare(state: GameState, observation: Any | None) -> CvComparison:
        if state.phase is not GamePhase.COMBAT or state.board is None:
            return CvComparison(False, "memory_state_not_combat")
        if observation is None:
            return CvComparison(False, "cv_capture_unavailable")
        if observation.board is None:
            return CvComparison(
                False,
                "v1_cv_board_not_full",
                unknowns=int(getattr(observation, "unknown_cells", 64)),
            )
        gem_mismatches: list[tuple[int, int, str, str]] = []
        multiplier_mismatches: list[tuple[int, int, int, int]] = []
        gem_matches = 0
        multiplier_matches = 0
        values: list[tuple[str, int]] = []
        for row in range(8):
            for col in range(8):
                memory_cell = state.board.cells[row][col]
                cv_gem = observation.board[row][col]
                cv_multiplier = (
                    observation.multipliers[row][col]
                    if observation.multipliers is not None
                    else None
                )
                values.append((cv_gem.value, cv_multiplier or 0))
                if cv_gem.value == memory_cell.gem.value:
                    gem_matches += 1
                else:
                    gem_mismatches.append(
                        (row, col, memory_cell.gem.value, cv_gem.value)
                    )
                if cv_multiplier is not None:
                    if cv_multiplier == memory_cell.multiplier:
                        multiplier_matches += 1
                    else:
                        multiplier_mismatches.append(
                            (row, col, memory_cell.multiplier, cv_multiplier)
                        )
        cv_hash = hashlib.sha256(
            json.dumps(values, separators=(",", ":")).encode("utf-8")
        ).hexdigest()
        multiplier_compared = 64 if observation.multipliers is not None else 0
        return CvComparison(
            accepted=not gem_mismatches and not multiplier_mismatches,
            reason=(
                "exact_match"
                if not gem_mismatches and not multiplier_mismatches
                else "cell_mismatch"
            ),
            cells_compared=64,
            gem_matches=gem_matches,
            gem_mismatches=tuple(gem_mismatches),
            unknowns=0,
            multiplier_compared=multiplier_compared,
            multiplier_matches=multiplier_matches,
            multiplier_mismatches=tuple(multiplier_mismatches),
            cv_hash=cv_hash,
        )

    def compare_debug_snapshot(
        self, state: GameState, *, since_ns: int
    ) -> CvComparison | None:
        """Match a V1 full-board debug artifact by all 64 gem values.

        V1 writes one structured ``debug/boards/*.txt`` artifact at the start
        of each recognized player turn.  This is an independent CV result.  A
        file is accepted only when it was written after this shadow session,
        declares ``source=full unknown=0``, parses as exactly 8x8, and every
        token equals the memory state.  It never fills or corrects memory.

        V1's text artifact does not contain badge multipliers; those remain
        protected by the provider's independent WsCombatBatch/64-Dot equality
        gate and are therefore deliberately reported as not CV-compared.
        """

        if state.phase is not GamePhase.COMBAT or state.board is None:
            return None
        board_dir = self.v1_root / "debug" / "boards"
        if not board_dir.is_dir():
            return None
        expected = tuple(
            tuple(state.board.cells[row][col].gem.value for col in range(8))
            for row in range(8)
        )
        code_to_gem = {
            "K": "sword",
            "M": "mana",
            "N": "rage",
            "B": "shield",
            "H": "health",
            "D": "drain",
        }
        row_pattern = re.compile(r"^r([0-7])\s+(.+)$")
        for path in sorted(
            board_dir.glob("*.txt"),
            key=lambda candidate: candidate.stat().st_mtime_ns,
            reverse=True,
        ):
            try:
                if path.stat().st_mtime_ns < since_ns:
                    continue
                text = path.read_text(encoding="utf-8")
            except OSError:
                continue
            if "source=full unknown=0" not in text:
                continue
            rows: dict[int, tuple[str, ...]] = {}
            for line in text.splitlines():
                if line.startswith("confidence:"):
                    break
                match = row_pattern.match(line)
                if match is None:
                    continue
                tokens = tuple(match.group(2).split())
                if len(tokens) != 8 or any(token not in code_to_gem for token in tokens):
                    rows.clear()
                    break
                rows[int(match.group(1))] = tuple(code_to_gem[token] for token in tokens)
            if set(rows) != set(range(8)):
                continue
            observed = tuple(rows[row] for row in range(8))
            if observed != expected:
                continue
            debug_hash = hashlib.sha256(
                json.dumps(observed, separators=(",", ":")).encode("utf-8")
            ).hexdigest()
            return CvComparison(
                accepted=True,
                reason="exact_match_v1_debug",
                cells_compared=64,
                gem_matches=64,
                multiplier_compared=0,
                multiplier_matches=0,
                cv_hash=debug_hash,
                source="v1_structured_debug",
                source_file=str(path.resolve()),
            )
        return None
