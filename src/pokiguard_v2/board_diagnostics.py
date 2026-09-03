"""Pure dead-board diagnostics and deterministic artifact/replay helpers.

Legality is deliberately independent from policy preference.  A legal swap is
one of the 112 adjacent pairs which the production simulator proves creates a
match.  Safety/danger and BASIC policy are reported as separate layers.
"""

from __future__ import annotations

from dataclasses import asdict, dataclass, fields, is_dataclass
from datetime import datetime, timezone
from enum import Enum
import hashlib
import json
from pathlib import Path
import re
from typing import Any, Callable

from .basic_policy import BasicPolicyEngine, PolicyAction, PolicyDecision
from .board_simulator import MoveEvaluation, evaluate_all_moves
from .combat_lifecycle import CombatLifecycleState
from .live_state import runtime_row_to_screen_row, screen_row_to_runtime_row
from .state import (
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


TOTAL_ADJACENT_SWAPS = 112
ARTIFACT_SCHEMA = "pokiguard.dead_board.v1"


class MoveTimingClassification(str, Enum):
    NO_LEGAL_MOVE = "NO_LEGAL_MOVE"
    MOVE_NOT_ATTEMPTED_TOO_LATE = "MOVE_NOT_ATTEMPTED_TOO_LATE"
    MOVE_ATTEMPTED_TOO_LATE = "MOVE_ATTEMPTED_TOO_LATE"
    MOVE_REJECTED_TIMEOUT = "MOVE_REJECTED_TIMEOUT"
    MOVE_REJECTED_SEQUENCE_DESYNC = "MOVE_REJECTED_SEQUENCE_DESYNC"
    MOVE_REJECTED_OTHER = "MOVE_REJECTED_OTHER"
    MOVE_ACCEPTED = "MOVE_ACCEPTED"
    MOVE_NOT_ATTEMPTED = "MOVE_NOT_ATTEMPTED"
    UNKNOWN = "UNKNOWN"


@dataclass(frozen=True)
class BoardDiagnosticResult:
    state_timestamp: str
    decision_timestamp: str
    diagnostic_board_hash: str
    total_adjacent_swaps: int
    legal_match_producing_moves: int
    illegal_no_match_swaps: int
    safe_move_count: int
    dangerous_move_count: int
    dead_board: bool | None
    legal_moves: tuple[dict[str, Any], ...]
    policy: dict[str, Any]
    policy_observability: dict[str, Any]


@dataclass(frozen=True)
class DiagnosticArtifact:
    directory: Path
    board_json: Path
    board_text: Path
    analysis_json: Path
    screenshot: Path | None


def utc_timestamp() -> str:
    return datetime.now(timezone.utc).isoformat(timespec="milliseconds").replace(
        "+00:00", "Z"
    )


def jsonable(value: Any) -> Any:
    if is_dataclass(value):
        return jsonable(asdict(value))
    if isinstance(value, Enum):
        return value.value
    if isinstance(value, dict):
        return {str(key): jsonable(item) for key, item in value.items()}
    if isinstance(value, (tuple, list, set)):
        return [jsonable(item) for item in value]
    return value


def diagnostic_board_hash(board: BoardState) -> str:
    values = [
        (cell.row, cell.col, cell.gem.value, cell.multiplier)
        for row in board.cells
        for cell in row
    ]
    raw = json.dumps(values, ensure_ascii=False, separators=(",", ":"))
    return hashlib.sha256(raw.encode("utf-8")).hexdigest()


def _coordinate(screen_row: int, col: int) -> dict[str, int]:
    return {
        "runtimeRow": screen_row_to_runtime_row(screen_row),
        "runtimeCol": col,
        "screenRow": screen_row,
        "screenCol": col,
    }


def board_cells_payload(board: BoardState) -> list[dict[str, Any]]:
    return [
        {
            **_coordinate(cell.row, cell.col),
            "gemType": cell.gem.value,
            "multiplier": cell.multiplier,
        }
        for row in board.cells
        for cell in row
    ]


def _resource_payload(result: Any) -> dict[str, dict[str, int]]:
    return {
        gem.value: {"cells": tally.cells, "effective": tally.effective}
        for gem, tally in result.values
    }


def move_payload(value: MoveEvaluation) -> dict[str, Any]:
    direct_cells = value.clear_rounds[0] if value.clear_rounds else ()
    cascade_rounds = value.clear_rounds[1:] if len(value.clear_rounds) > 1 else ()
    risk = value.sword_risk
    exposure = value.unknown_exposure
    return {
        "from": _coordinate(*value.move.first),
        "to": _coordinate(*value.move.second),
        "horizontal": value.horizontal,
        "directMatches": [_coordinate(*cell) for cell in direct_cells],
        "cascade": {
            "roundCount": value.cascade_rounds,
            "clearRounds": [
                [_coordinate(*cell) for cell in round_cells]
                for round_cells in cascade_rounds
            ],
            "longestMatch": value.longest_match,
        },
        "resources": {
            "direct": _resource_payload(value.direct),
            "cascade": _resource_payload(value.cascade),
            "total": _resource_payload(value.total),
        },
        "danger": {
            "safe": risk.safe,
            "dangerScore": risk.danger_score,
            "swordPotentialsLeft": risk.potentials_left,
            "swordPotentialEffectiveMax": risk.potential_effective_max,
            "opponentSwordReplies": risk.opponent_sword_replies,
            "opponentSwordReplyCellsMax": risk.opponent_sword_reply_cells_max,
            "opponentSwordReplyEffectiveMax": risk.opponent_sword_reply_effective_max,
            "indirectSwordReplies": risk.indirect_sword_replies,
            "indirectSwordEffectiveMax": risk.indirect_sword_effective_max,
            "swordDangerRegionsLeft": risk.danger_regions_left,
            "collapseSupportHazard": risk.collapse_support_hazard,
            "unknownSwordCompletions": risk.unknown_sword_completions,
            "unknownSwordEffectiveMax": risk.unknown_sword_effective_max,
        },
        "unknownExposure": {
            "cells": exposure.cells,
            "columns": [
                {"screenCol": col, "count": count}
                for col, count in exposure.columns
            ],
            "maxColumnDepth": exposure.max_column_depth,
            "hypotheticalSwordCompletions": exposure.hypothetical_sword_completions,
            "hypotheticalSwordEffectiveMax": exposure.hypothetical_sword_effective_max,
        },
        "calculable": value.calculable,
    }


def _policy_payload(decision: PolicyDecision) -> dict[str, Any]:
    return jsonable(decision)


def _why_not(decision: PolicyDecision) -> dict[str, list[str]]:
    names = ("Sword", "Rage", "Mana", "Health", "Cast", "Drain", "Shield")
    result = {name: [] for name in names}
    prefixes = {
        "STEP_2_SWORD": "Sword",
        "STEP_3_RAGE": "Rage",
        "STEP_3_MANA": "Mana",
        "STEP_4_HEALTH": "Health",
        "STEP_5_CAST": "Cast",
        "STEP_5_DRAIN": "Drain",
        "STEP_5_SHIELD": "Shield",
        "STEP_5_RESOURCE": "Drain",
    }
    for reason in decision.trace.failed_higher_priority_branches:
        prefix = reason.split(":", 1)[0]
        name = prefixes.get(prefix)
        if name is not None:
            result[name].append(reason)
        if prefix == "STEP_5_RESOURCE":
            result["Shield"].append(reason)
    return result


def _safe_resource_counts(
    evaluations: tuple[MoveEvaluation, ...],
) -> dict[str, int]:
    safe = tuple(value for value in evaluations if value.sword_risk.safe)
    return {
        gem.value: sum(value.total.effective(gem) > 0 for value in safe)
        for gem in GemType
        if gem is not GemType.UNKNOWN
    }


def _dead_board_gate(state: GameState, legal_count: int) -> bool | None:
    battle = state.battle
    opening_authoritative = bool(
        "ChatMessageDTO.MATCH_START.matchPayload.board" in battle.sources
        and battle.local_move_sequence == 0
        and battle.last_move_sequence in (None, -1, 0)
        and battle.turn_number in (0, 1)
    )
    exact = bool(
        state.phase is GamePhase.COMBAT
        and state.board is not None
        and state.board.production_ready
        and sum(len(row) for row in state.board.cells) == 64
        and battle.combat_lifecycle is CombatLifecycleState.ACTIVE
        and battle.is_local_turn is True
        and battle.stable
        and (battle.acknowledged or opening_authoritative)
        and battle.latest
        and battle.is_board_ready is True
        and battle.is_cascade_running is False
    )
    return legal_count == 0 if exact else None


def analyze_game_state(
    state: GameState,
    *,
    policy_engine: BasicPolicyEngine | None = None,
    decision_timestamp: str | None = None,
) -> BoardDiagnosticResult:
    if state.phase is not GamePhase.COMBAT or state.board is None:
        raise ValueError("board diagnostics require a stable combat GameState")
    evaluations = evaluate_all_moves(state.board)
    if len(evaluations) > TOTAL_ADJACENT_SWAPS:
        raise AssertionError("legal move count exceeds the 112 adjacent pairs")
    decision = (policy_engine or BasicPolicyEngine()).decide(state)
    safe_count = sum(value.sword_risk.safe for value in evaluations)
    dangerous_count = len(evaluations) - safe_count
    observability = {
        "legalMoveCount": len(evaluations),
        "safeMoveCount": safe_count,
        "dangerousMoveCount": dangerous_count,
        "policySelectedAction": decision.action.value,
        "safeResourcesAvailable": _safe_resource_counts(evaluations),
        "bossResources": {
            "mana": state.opponents[0].mana if state.opponents else None,
            "rage": state.opponents[0].power if state.opponents else None,
        },
    }
    if decision.action in {PolicyAction.NONE, PolicyAction.PASS}:
        observability["whyNot"] = _why_not(decision)
    return BoardDiagnosticResult(
        state_timestamp=state.timestamp,
        decision_timestamp=decision_timestamp or utc_timestamp(),
        diagnostic_board_hash=diagnostic_board_hash(state.board),
        total_adjacent_swaps=TOTAL_ADJACENT_SWAPS,
        legal_match_producing_moves=len(evaluations),
        illegal_no_match_swaps=TOTAL_ADJACENT_SWAPS - len(evaluations),
        safe_move_count=safe_count,
        dangerous_move_count=dangerous_count,
        dead_board=_dead_board_gate(state, len(evaluations)),
        legal_moves=tuple(move_payload(value) for value in evaluations),
        policy=_policy_payload(decision),
        policy_observability=observability,
    )


def classify_move_timing(
    *,
    legal_move_count: int | None,
    remaining_seconds: int | None,
    attempted: bool,
    accepted: bool | None = None,
    reject_reason: str | None = None,
    deadline_seconds: int = 1,
) -> MoveTimingClassification:
    if legal_move_count == 0:
        return MoveTimingClassification.NO_LEGAL_MOVE
    lowered = (reject_reason or "").casefold()
    if accepted is False:
        if (
            "seqnum" in lowered
            or "sequence" in lowered
            or "resync" in lowered
            or "gap/duplicate" in lowered
        ):
            return MoveTimingClassification.MOVE_REJECTED_SEQUENCE_DESYNC
        if any(word in lowered for word in ("timeout", "time", "deadline", "late")):
            return MoveTimingClassification.MOVE_REJECTED_TIMEOUT
        return MoveTimingClassification.MOVE_REJECTED_OTHER
    if accepted is True:
        return MoveTimingClassification.MOVE_ACCEPTED
    if remaining_seconds is not None and remaining_seconds <= deadline_seconds:
        return (
            MoveTimingClassification.MOVE_ATTEMPTED_TOO_LATE
            if attempted
            else MoveTimingClassification.MOVE_NOT_ATTEMPTED_TOO_LATE
        )
    if not attempted and legal_move_count is not None and legal_move_count > 0:
        return MoveTimingClassification.MOVE_NOT_ATTEMPTED
    return MoveTimingClassification.UNKNOWN


def game_state_payload(state: GameState) -> dict[str, Any]:
    if state.board is None:
        raise ValueError("artifact state has no board")
    return {
        "schema": ARTIFACT_SCHEMA,
        "sourceTimestamp": state.timestamp,
        "sessionKey": jsonable(state.battle.session_key),
        "matchId": state.battle.match_id,
        "srvSeq": state.battle.srv_seq,
        "turnNumber": state.battle.turn_number,
        "currentTurnPlayer": state.battle.current_turn_player,
        "boardInstance": state.battle.board_instance,
        "boardHash": state.battle.board_hash,
        "diagnosticBoardHash": diagnostic_board_hash(state.board),
        "coordinateConvention": {
            "screen": "row 0 is top",
            "runtime": "row 0 is bottom",
            "mapping": "screenRow = 7 - runtimeRow",
        },
        "cells": board_cells_payload(state.board),
        "gameState": {
            "phase": state.phase.value,
            "timestamp": state.timestamp,
            "battle": jsonable(state.battle),
            "player": jsonable(state.player),
            "opponents": jsonable(state.opponents),
            "participants": jsonable(state.participants),
            "cards": jsonable(state.cards),
            "fusion": jsonable(state.fusion),
        },
    }


def _construct(cls: Any, values: dict[str, Any]) -> Any:
    allowed = {item.name for item in fields(cls)}
    return cls(**{key: value for key, value in values.items() if key in allowed})


def game_state_from_payload(payload: dict[str, Any]) -> GameState:
    if payload.get("schema") != ARTIFACT_SCHEMA:
        raise ValueError("unsupported board artifact schema")
    cells = payload.get("cells")
    if not isinstance(cells, list) or len(cells) != 64:
        raise ValueError("board artifact must contain exactly 64 cells")
    by_screen: dict[tuple[int, int], CellState] = {}
    for item in cells:
        screen_row = int(item["screenRow"])
        screen_col = int(item["screenCol"])
        runtime_row = int(item["runtimeRow"])
        runtime_col = int(item["runtimeCol"])
        if runtime_row_to_screen_row(runtime_row) != screen_row or runtime_col != screen_col:
            raise ValueError("artifact runtime/screen coordinate mismatch")
        cell = CellState(
            screen_row,
            screen_col,
            GemType(str(item["gemType"])),
            int(item["multiplier"]),
        )
        if (screen_row, screen_col) in by_screen:
            raise ValueError("artifact contains a duplicate cell")
        by_screen[(screen_row, screen_col)] = cell
    board = BoardState(
        tuple(
            tuple(by_screen[(row, col)] for col in range(8))
            for row in range(8)
        )
    )
    game = payload.get("gameState") or {}
    battle_values = dict(game.get("battle") or {})
    battle_values["combat_lifecycle"] = CombatLifecycleState(
        battle_values.get("combat_lifecycle", CombatLifecycleState.ACTIVE.value)
    )
    session_values = battle_values.get("session_key")
    if session_values:
        battle_values["session_key"] = _construct(CombatSessionKey, session_values)
    battle = _construct(BattleState, battle_values)
    player_values = game.get("player")
    player = _construct(ParticipantState, player_values) if player_values else None
    opponents = tuple(
        _construct(ParticipantState, item) for item in game.get("opponents", ())
    )
    participants = tuple(
        _construct(ParticipantState, item) for item in game.get("participants", ())
    )
    cards = tuple(_construct(CardState, item) for item in game.get("cards", ()))
    fusion_values = game.get("fusion")
    fusion = _construct(FusionState, fusion_values) if fusion_values else None
    return GameState(
        phase=GamePhase(game.get("phase", GamePhase.COMBAT.value)),
        timestamp=str(game.get("timestamp") or payload.get("sourceTimestamp")),
        board=board,
        battle=battle,
        player=player,
        opponents=opponents,
        participants=participants,
        cards=cards,
        fusion=fusion,
    )


def board_text(board: BoardState) -> str:
    abbreviations = {
        GemType.SWORD: "SW",
        GemType.MANA: "MA",
        GemType.RAGE: "RA",
        GemType.SHIELD: "SH",
        GemType.HEALTH: "HP",
        GemType.DRAIN: "DR",
        GemType.UNKNOWN: "??",
    }
    lines = ["screen rows 0(top)..7(bottom); runtimeRow = 7-screenRow"]
    for row in board.cells:
        lines.append(
            " ".join(f"{abbreviations[cell.gem]}x{cell.multiplier}" for cell in row)
        )
    return "\n".join(lines) + "\n"


def _safe_component(value: str) -> str:
    return re.sub(r"[^A-Za-z0-9_.-]+", "_", value).strip("_") or "unknown"


def write_diagnostic_artifact(
    root: Path,
    *,
    event: str,
    state: GameState,
    analysis: BoardDiagnosticResult,
    screenshot_capture: Callable[[Path], dict[str, Any]] | None = None,
) -> DiagnosticArtifact:
    if state.board is None:
        raise ValueError("diagnostic artifact requires a board")
    stamp = datetime.now().strftime("%Y%m%d_%H%M%S_%f")[:-3]
    directory = root / (
        f"{stamp}_{_safe_component(event)}_seq{state.battle.srv_seq}_"
        f"{analysis.diagnostic_board_hash[:12]}"
    )
    directory.mkdir(parents=True, exist_ok=False)
    board_path = directory / "board.json"
    text_path = directory / "board.txt"
    analysis_path = directory / "analysis.json"
    screenshot_path: Path | None = None
    screenshot_result: dict[str, Any] = {"captured": False, "reason": "disabled"}
    if screenshot_capture is not None:
        candidate = directory / "screenshot.png"
        try:
            screenshot_result = screenshot_capture(candidate)
            if candidate.is_file() and candidate.stat().st_size > 0:
                screenshot_path = candidate
                screenshot_result = {"captured": True, **screenshot_result}
            else:
                screenshot_result = {
                    "captured": False,
                    "reason": "capture returned without a PNG",
                    **screenshot_result,
                }
        except (OSError, RuntimeError, ValueError) as exc:
            screenshot_result = {"captured": False, "reason": str(exc)}
    board_path.write_text(
        json.dumps(game_state_payload(state), ensure_ascii=False, indent=2),
        encoding="utf-8",
    )
    text_path.write_text(board_text(state.board), encoding="utf-8")
    analysis_payload = {
        "schema": ARTIFACT_SCHEMA,
        "event": event,
        "session": jsonable(state.battle.session_key),
        "matchId": state.battle.match_id,
        "srvSeq": state.battle.srv_seq,
        "turn": state.battle.turn_number,
        "boardHash": state.battle.board_hash,
        "diagnosticBoardHash": analysis.diagnostic_board_hash,
        "legalMoveCount": analysis.legal_match_producing_moves,
        "safeMoveCount": analysis.safe_move_count,
        "dangerousMoveCount": analysis.dangerous_move_count,
        "deadBoard": analysis.dead_board,
        "timer": {
            "duration": state.battle.turn_duration_seconds,
            "remaining": state.battle.turn_time_remaining_seconds,
            "source": state.battle.turn_timer_source,
            "stateTimestamp": analysis.state_timestamp,
            "decisionTimestamp": analysis.decision_timestamp,
        },
        "lifecycle": state.battle.combat_lifecycle.value,
        "player": jsonable(state.player),
        "boss": jsonable(state.opponents[0]) if state.opponents else None,
        "fusion": jsonable(state.fusion),
        "cards": jsonable(state.cards),
        "idle": {
            "count": state.battle.consecutive_passes,
            "threshold": state.battle.consecutive_pass_threshold,
            "source": state.battle.consecutive_pass_source,
        },
        "totalAdjacentSwaps": analysis.total_adjacent_swaps,
        "illegalNoMatchSwaps": analysis.illegal_no_match_swaps,
        "legalMoves": list(analysis.legal_moves),
        "policy": analysis.policy,
        "policyObservability": analysis.policy_observability,
        "screenshot": screenshot_result,
    }
    analysis_path.write_text(
        json.dumps(analysis_payload, ensure_ascii=False, indent=2),
        encoding="utf-8",
    )
    return DiagnosticArtifact(
        directory=directory,
        board_json=board_path,
        board_text=text_path,
        analysis_json=analysis_path,
        screenshot=screenshot_path,
    )


__all__ = [
    "ARTIFACT_SCHEMA",
    "TOTAL_ADJACENT_SWAPS",
    "BoardDiagnosticResult",
    "DiagnosticArtifact",
    "MoveTimingClassification",
    "analyze_game_state",
    "board_cells_payload",
    "board_text",
    "classify_move_timing",
    "diagnostic_board_hash",
    "game_state_from_payload",
    "game_state_payload",
    "jsonable",
    "move_payload",
    "utc_timestamp",
    "write_diagnostic_artifact",
]
