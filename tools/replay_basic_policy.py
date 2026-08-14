#!/usr/bin/env python3
"""Offline audit/replay for Phase 2C.2A BASIC shadow JSONL logs.

Old logs that contain only ``DecisionTrace`` remain auditable, but are marked
NOT_COMPARABLE for engine replay.  Logs created after Phase 2C.2A.1 include a
complete provider-neutral ``gameState`` and can be fed back through the policy
engine repeatedly without reading the game process.
"""

from __future__ import annotations

import argparse
from collections import Counter
from dataclasses import asdict, dataclass, is_dataclass
from enum import Enum
import hashlib
import json
from pathlib import Path
import sys
from typing import Any, Iterable, Sequence


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.basic_policy import (  # noqa: E402
    BasicPolicyEngine,
    Intelligence,
    ManaPriority,
    PlayStyle,
    PolicyConfig,
)
from pokiguard_v2.combat_lifecycle import CombatLifecycleState  # noqa: E402
from pokiguard_v2.state import (  # noqa: E402
    BattleState,
    BoardState,
    CardState,
    CellState,
    CombatSessionKey,
    FusionState,
    GamePhase,
    GameState,
    GemType,
    ParticipantState,
)


DECISION_EVENT = "basic_policy_decision"
COMPARISONS = ("MATCH", "DIFFERENT", "NOT_COMPARABLE", "UNKNOWN")


@dataclass(frozen=True)
class ActualAudit:
    action: str
    comparison: str
    evidence: str

    def __post_init__(self) -> None:
        if self.comparison not in COMPARISONS:
            raise ValueError("invalid comparison classification")


def _jsonable(value: Any) -> Any:
    if is_dataclass(value):
        return _jsonable(asdict(value))
    if isinstance(value, Enum):
        return value.value
    if isinstance(value, dict):
        return {str(key): _jsonable(item) for key, item in value.items()}
    if isinstance(value, (tuple, list)):
        return [_jsonable(item) for item in value]
    return value


def _canonical(value: Any) -> str:
    return json.dumps(
        _jsonable(value), ensure_ascii=False, sort_keys=True, separators=(",", ":")
    )


def load_jsonl(path: Path) -> list[dict[str, Any]]:
    rows: list[dict[str, Any]] = []
    with path.open("r", encoding="utf-8") as source:
        for line_number, raw in enumerate(source, 1):
            if not raw.strip():
                continue
            try:
                value = json.loads(raw)
            except json.JSONDecodeError as exc:
                raise ValueError(f"invalid JSONL at line {line_number}: {exc}") from exc
            if not isinstance(value, dict):
                raise ValueError(f"JSONL line {line_number} is not an object")
            rows.append(value)
    return rows


def decision_rows(rows: Iterable[dict[str, Any]]) -> list[dict[str, Any]]:
    return [row for row in rows if row.get("event") == DECISION_EVENT]


def _participant(value: dict[str, Any] | None) -> ParticipantState | None:
    return ParticipantState(**value) if value is not None else None


def _card(value: dict[str, Any]) -> CardState:
    copied = dict(value)
    copied["color_requirements"] = tuple(
        tuple(item) for item in copied.get("color_requirements", ())
    )
    copied["quality_values"] = tuple(
        tuple(item) for item in copied.get("quality_values", ())
    )
    return CardState(**copied)


def game_state_from_json(value: dict[str, Any]) -> GameState:
    board_value = value.get("board")
    board = None
    if board_value is not None:
        board = BoardState(
            tuple(
                tuple(
                    CellState(
                        row=int(cell["row"]),
                        col=int(cell["col"]),
                        gem=GemType(cell["gem"]),
                        multiplier=int(cell["multiplier"]),
                    )
                    for cell in row
                )
                for row in board_value["cells"]
            )
        )

    battle_value = dict(value.get("battle") or {})
    battle_value["sources"] = tuple(battle_value.get("sources") or ())
    # Historical complete shadow traces predate the explicit lifecycle field;
    # they were emitted only from a published COMBAT state. This is offline
    # replay compatibility, never a production runtime fallback.
    lifecycle_value = battle_value.get("combat_lifecycle")
    if lifecycle_value is None and value.get("phase") == GamePhase.COMBAT.value:
        lifecycle_value = CombatLifecycleState.ACTIVE.value
    battle_value["combat_lifecycle"] = CombatLifecycleState(
        lifecycle_value or CombatLifecycleState.UNKNOWN.value
    )
    session_value = battle_value.get("session_key")
    if session_value is not None:
        battle_value["session_key"] = CombatSessionKey(**session_value)
    battle = BattleState(**battle_value)
    return GameState(
        phase=GamePhase(value["phase"]),
        timestamp=value["timestamp"],
        board=board,
        battle=battle,
        player=_participant(value.get("player")),
        opponents=tuple(_participant(item) for item in value.get("opponents", ())),
        participants=tuple(
            _participant(item) for item in value.get("participants", ())
        ),
        cards=tuple(_card(item) for item in value.get("cards", ())),
        fusion=(FusionState(**value["fusion"]) if value.get("fusion") else None),
    )


def config_from_rows(rows: Iterable[dict[str, Any]]) -> PolicyConfig:
    started = next(
        (row for row in rows if row.get("event") == "basic_policy_shadow_started"),
        {},
    )
    value = started.get("config") or {}
    return PolicyConfig(
        play_style=PlayStyle(value.get("play_style", PlayStyle.SIMPLE.value)),
        mana_priority=ManaPriority(
            value.get("mana_priority", ManaPriority.EVOLUTION.value)
        ),
        intelligence=Intelligence(value.get("intelligence", Intelligence.BASIC.value)),
        minimum_turn_time_seconds=int(value.get("minimum_turn_time_seconds", 3)),
    )


def _fusion_attempt(value: dict[str, Any]) -> int | None:
    fusion = value.get("fusion") or {}
    attempt = fusion.get("last_attempt_turn")
    return attempt if isinstance(attempt, int) and attempt >= 0 else None


def infer_actual_actions(decisions: Sequence[dict[str, Any]]) -> list[ActualAudit]:
    """Use only durable fields present in the log; never infer PASS locally."""

    result: list[ActualAudit] = []
    for index, row in enumerate(decisions):
        proposal = (row.get("decision") or {}).get("action", "none").upper()
        turn = row.get("turn")
        next_row = decisions[index + 1] if index + 1 < len(decisions) else None
        exact_next_local = bool(
            next_row is not None
            and isinstance(turn, int)
            and next_row.get("turn") == turn + 2
            and next_row.get("boardInstance") == row.get("boardInstance")
        )

        if exact_next_local:
            before_attempt = _fusion_attempt(row)
            after_attempt = _fusion_attempt(next_row)
            if after_attempt == turn and after_attempt != before_attempt:
                comparison = "MATCH" if proposal == "EVOLVE" else "DIFFERENT"
                result.append(
                    ActualAudit(
                        "EVOLVE",
                        comparison,
                        f"Fusion.last_attempt_turn changed {before_attempt}->{after_attempt}",
                    )
                )
                continue
            if proposal == "EVOLVE" and after_attempt != turn:
                result.append(
                    ActualAudit(
                        "UNKNOWN",
                        "DIFFERENT",
                        "adjacent next local snapshot proves no EVOLVE attempt on this turn; consuming action is not logged",
                    )
                )
                continue

            current_battle = (row.get("gameState") or {}).get("battle") or {}
            next_battle = (next_row.get("gameState") or {}).get("battle") or {}
            before_move_seq = current_battle.get("last_move_sequence")
            after_move_seq = next_battle.get("last_move_sequence")
            if (
                isinstance(before_move_seq, int)
                and isinstance(after_move_seq, int)
                and after_move_seq > before_move_seq
            ):
                coords = (
                    next_battle.get("last_move_from_row"),
                    next_battle.get("last_move_from_col"),
                    next_battle.get("last_move_to_row"),
                    next_battle.get("last_move_to_col"),
                )
                action = f"SWAP r{coords[0]}c{coords[1]}-r{coords[2]}c{coords[3]}"
                proposed_move = (row.get("decision") or {}).get("move")
                actual_move = {
                    "first": [coords[0], coords[1]],
                    "second": [coords[2], coords[3]],
                }
                same = proposal == "SWAP" and proposed_move in (
                    actual_move,
                    {"first": actual_move["second"], "second": actual_move["first"]},
                )
                result.append(
                    ActualAudit(
                        action,
                        "MATCH" if same else "DIFFERENT",
                        f"MatchService.LastMoveSeqNum changed {before_move_seq}->{after_move_seq}",
                    )
                )
                continue

        result.append(
            ActualAudit(
                "UNKNOWN",
                "UNKNOWN" if proposal != "NONE" else "NOT_COMPARABLE",
                "log has no exact per-turn LastMove/card/pass event",
            )
        )
    return result


def replay_decisions(
    rows: Sequence[dict[str, Any]], repeats: int
) -> tuple[str, list[dict[str, Any]]]:
    decisions = decision_rows(rows)
    if not decisions or any("gameState" not in row for row in decisions):
        return "NOT_COMPARABLE", []
    engine = BasicPolicyEngine(config_from_rows(rows))
    output: list[dict[str, Any]] = []
    for row in decisions:
        state = game_state_from_json(row["gameState"])
        observed: list[str] = []
        replayed: Any = None
        for _ in range(repeats):
            replayed = engine.decide(state)
            observed.append(_canonical(replayed))
        deterministic = len(set(observed)) == 1
        equals_log = observed[0] == _canonical(row.get("decision"))
        output.append(
            {
                "turn": row.get("turn"),
                "srvSeq": row.get("srvSeq"),
                "deterministic": deterministic,
                "equalsLoggedDecision": equals_log,
                "sha256": hashlib.sha256(observed[0].encode("utf-8")).hexdigest(),
            }
        )
    status = (
        "MATCH"
        if all(item["deterministic"] and item["equalsLoggedDecision"] for item in output)
        else "DIFFERENT"
    )
    return status, output


def _move_text(decision: dict[str, Any]) -> str:
    move = decision.get("move")
    if not move:
        return "-"
    first, second = move["first"], move["second"]
    return f"r{first[0]}c{first[1]}-r{second[0]}c{second[1]}"


def _selected_text(trace: dict[str, Any]) -> str:
    selected = trace.get("selected_candidate")
    if not selected:
        return "-"
    resources = ",".join(
        f"{gem}:{effective}" for gem, _cells, effective in selected["total_resources"]
    ) or "-"
    return (
        f"{resources}; sword={selected['sword_effective']}; "
        f"cascade={selected['known_cascades']}; left={selected['sword_potentials_left']}; "
        f"danger={selected['danger_score']}; unknown={selected['unknown_cells']}"
    )


def build_audit(rows: Sequence[dict[str, Any]], repeats: int) -> dict[str, Any]:
    decisions = decision_rows(rows)
    actual = infer_actual_actions(decisions)
    replay_status, replay_rows = replay_decisions(rows, repeats)
    coverage = Counter(
        row["decision"]["trace"]["policy_step"] for row in decisions
    )
    return {
        "decisionCount": len(decisions),
        "boardInstances": sorted({row.get("boardInstance") for row in decisions}),
        "srvSeqRange": (
            [min(row["srvSeq"] for row in decisions), max(row["srvSeq"] for row in decisions)]
            if decisions
            else None
        ),
        "turns": sorted({row.get("turn") for row in decisions}),
        "branchCoverage": dict(sorted(coverage.items())),
        "comparisonCoverage": dict(sorted(Counter(x.comparison for x in actual).items())),
        "replayStatus": replay_status,
        "replay": replay_rows,
        "decisions": [
            {
                "turn": row.get("turn"),
                "srvSeq": row.get("srvSeq"),
                "remaining": (row.get("timer") or {}).get("remaining"),
                "step": row["decision"]["trace"]["policy_step"],
                "proposal": row["decision"]["action"],
                "move": _move_text(row["decision"]),
                "selected": _selected_text(row["decision"]["trace"]),
                "blocker": row["decision"]["trace"].get("blocker"),
                "actual": asdict(actual[index]),
                "failedHigherPriorityBranches": row["decision"]["trace"].get(
                    "failed_higher_priority_branches", []
                ),
                "candidates": row["decision"]["trace"].get("candidates", []),
            }
            for index, row in enumerate(decisions)
        ],
    }


def _print_human(audit: dict[str, Any], *, details: bool) -> None:
    print(
        f"decisions={audit['decisionCount']} board={','.join(audit['boardInstances'])} "
        f"srvSeq={audit['srvSeqRange']} replay={audit['replayStatus']}"
    )
    print("coverage=" + json.dumps(audit["branchCoverage"], sort_keys=True))
    print("comparisons=" + json.dumps(audit["comparisonCoverage"], sort_keys=True))
    print("turn seq time step proposal move actual compare selected/blocker")
    for row in audit["decisions"]:
        print(
            f"{row['turn']:>4} {row['srvSeq']:>4} {row['remaining']:>4} "
            f"{row['step']:<27} {row['proposal']:<10} {row['move']:<15} "
            f"{row['actual']['action']:<22} {row['actual']['comparison']:<14} "
            f"{row['selected']} {row['blocker'] or ''}"
        )
        if details:
            print("  actual evidence: " + row["actual"]["evidence"])
            for failure in row["failedHigherPriorityBranches"]:
                print("  skipped: " + failure)
            for candidate in row["candidates"]:
                print("  candidate: " + _canonical(candidate))


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("log", type=Path, help="basic_policy_shadow JSONL")
    parser.add_argument("--repeat", type=int, default=5, help="policy replay count")
    parser.add_argument("--details", action="store_true", help="print failures/candidates")
    parser.add_argument("--json", action="store_true", help="emit machine-readable JSON")
    return parser


def main(argv: Sequence[str] | None = None) -> int:
    args = build_parser().parse_args(argv)
    if args.repeat <= 0:
        raise SystemExit("--repeat must be positive")
    try:
        audit = build_audit(load_jsonl(args.log.resolve()), args.repeat)
    except (OSError, ValueError, KeyError, TypeError) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1
    if args.json:
        print(json.dumps(audit, ensure_ascii=False, indent=2))
    else:
        _print_human(audit, details=args.details)
    return 0 if audit["decisionCount"] else 2


if __name__ == "__main__":
    raise SystemExit(main())
