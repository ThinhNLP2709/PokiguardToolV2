#!/usr/bin/env python3
"""Replay one dead/low-board ``board.json`` deterministically (NO INPUT)."""

from __future__ import annotations

import argparse
import json
from pathlib import Path
import sys
from typing import Sequence


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.board_diagnostics import (  # noqa: E402
    analyze_game_state,
    game_state_from_payload,
    jsonable,
)


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("board_json", type=Path)
    parser.add_argument("--output", type=Path)
    return parser


def replay(path: Path) -> dict[str, object]:
    payload = json.loads(path.read_text(encoding="utf-8"))
    state = game_state_from_payload(payload)
    analysis = analyze_game_state(state)
    return {
        "source": str(path.resolve()),
        "sourceBoardHash": state.battle.board_hash,
        "diagnosticBoardHash": analysis.diagnostic_board_hash,
        "totalAdjacentSwaps": analysis.total_adjacent_swaps,
        "legalMoveCount": analysis.legal_match_producing_moves,
        "illegalNoMatchSwaps": analysis.illegal_no_match_swaps,
        "safeMoveCount": analysis.safe_move_count,
        "dangerousMoveCount": analysis.dangerous_move_count,
        "deadBoard": analysis.dead_board,
        "legalMoves": list(analysis.legal_moves),
        "policy": analysis.policy,
        "policyObservability": analysis.policy_observability,
    }


def main(argv: Sequence[str] | None = None) -> int:
    args = build_parser().parse_args(argv)
    try:
        result = replay(args.board_json.resolve())
    except (OSError, ValueError, KeyError, json.JSONDecodeError) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1
    rendered = json.dumps(jsonable(result), ensure_ascii=False, indent=2)
    if args.output:
        output = args.output.resolve()
        output.parent.mkdir(parents=True, exist_ok=True)
        output.write_text(rendered + "\n", encoding="utf-8")
    print(rendered)
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
