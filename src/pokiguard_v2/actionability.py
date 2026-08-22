"""Fail-closed Phase 2C.1 permission gate for one normal board swap."""

from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum
import re
from typing import Any

from .state import CombatSessionKey, GamePhase, GameState
from .combat_lifecycle import CombatLifecycleState
from .sequence_desync import SequenceDesyncState


class GateReason(str, Enum):
    PASS = "PASS"
    SEQUENCE_DESYNC = "SEQUENCE_DESYNC"
    NOT_IN_COMBAT = "NOT_IN_COMBAT"
    LOBBY = "LOBBY"
    ENTERING_COMBAT = "ENTERING_COMBAT"
    LEAVING_COMBAT = "LEAVING_COMBAT"
    POSTMATCH = "POSTMATCH"
    STALE_SERVER_MATCH = "STALE_SERVER_MATCH"
    LIFECYCLE_UNKNOWN = "LIFECYCLE_UNKNOWN"
    INVALID_SESSION = "INVALID_SESSION"
    INVALID_BOARD = "INVALID_BOARD"
    BOARD_UNSTABLE = "BOARD_UNSTABLE"
    BOARD_NOT_MOVE_STATE = "BOARD_NOT_MOVE_STATE"
    PRESENTATION_BUSY = "PRESENTATION_BUSY"
    TURN_ALREADY_RESOLVING = "TURN_ALREADY_RESOLVING"
    TURN_UNKNOWN = "TURN_UNKNOWN"
    NOT_LOCAL_TURN = "NOT_LOCAL_TURN"
    PLAYER_STATS_UNKNOWN = "PLAYER_STATS_UNKNOWN"
    PLAYER_DEAD = "PLAYER_DEAD"
    BOSS_STATS_UNKNOWN = "BOSS_STATS_UNKNOWN"
    BOSS_DEAD = "BOSS_DEAD"
    END_STATE_UNKNOWN = "END_STATE_UNKNOWN"
    GAME_OVER = "GAME_OVER"
    MATCH_OVER = "MATCH_OVER"
    GAME_ENDING = "GAME_ENDING"
    MODAL_OPEN = "MODAL_OPEN"
    CONNECTION_UNKNOWN = "CONNECTION_UNKNOWN"
    DISCONNECTED = "DISCONNECTED"
    RECONNECTING = "RECONNECTING"
    CLOCK_PAUSED = "CLOCK_PAUSED"
    CLIENT_MOVE_PERMISSION_UNKNOWN = "CLIENT_MOVE_PERMISSION_UNKNOWN"
    CLIENT_MOVE_BLOCKED = "CLIENT_MOVE_BLOCKED"
    GAME_NOT_FOREGROUND = "GAME_NOT_FOREGROUND"
    WINDOW_INVALID = "WINDOW_INVALID"
    INPUT_LOCKED = "INPUT_LOCKED"
    AUTO_PAUSED = "AUTO_PAUSED"


@dataclass(frozen=True)
class GateContext:
    current_session: CombatSessionKey | None
    game_foreground: bool | None
    window_valid: bool
    input_locked: bool = False
    auto_paused: bool = False
    sequence_desync: SequenceDesyncState | None = None
    allow_opening_board_only: bool = False


@dataclass(frozen=True)
class GateResult:
    actionable: bool
    reason: GateReason
    details: dict[str, Any] = field(default_factory=dict)


class ActionabilityGate:
    """Evaluate every state/input precondition in a deterministic order."""

    _hash_pattern = re.compile(r"[0-9a-f]{64}")

    @classmethod
    def _reject(cls, reason: GateReason, **details: Any) -> GateResult:
        return GateResult(False, reason, details)

    @classmethod
    def evaluate(cls, state: GameState, context: GateContext) -> GateResult:
        battle = state.battle
        # Session-terminal protocol failure outranks every gameplay path,
        # including solver/PASS/fallback/card/Fusion/swap decisions.
        desync = context.sequence_desync
        if desync is not None and desync.terminal_for_session:
            return cls._reject(
                GateReason.SEQUENCE_DESYNC,
                source=desync.source,
                session=desync.session_key,
                matchId=desync.match_id,
                turn=desync.turn,
                srvSeq=desync.srv_seq,
                rejectCount=desync.reject_count,
            )
        lifecycle_reasons = {
            CombatLifecycleState.LOBBY: GateReason.LOBBY,
            CombatLifecycleState.ENTERING: GateReason.ENTERING_COMBAT,
            CombatLifecycleState.LEAVING: GateReason.LEAVING_COMBAT,
            CombatLifecycleState.POSTMATCH: GateReason.POSTMATCH,
            CombatLifecycleState.STALE_SERVER_MATCH: GateReason.STALE_SERVER_MATCH,
            CombatLifecycleState.UNKNOWN: GateReason.LIFECYCLE_UNKNOWN,
        }
        if battle.combat_lifecycle is not CombatLifecycleState.ACTIVE:
            reason = lifecycle_reasons[battle.combat_lifecycle]
            if (
                state.phase is GamePhase.LOBBY
                and battle.combat_lifecycle is CombatLifecycleState.UNKNOWN
            ):
                reason = GateReason.LOBBY
            return cls._reject(reason, lifecycle=battle.combat_lifecycle.value)
        if state.phase is not GamePhase.COMBAT or state.board is None:
            return cls._reject(GateReason.NOT_IN_COMBAT, phase=state.phase.value)
        if (
            battle.session_key is None
            or context.current_session is None
            or battle.session_key != context.current_session
            or battle.board_instance != battle.session_key.board_instance
            or battle.match_id != battle.session_key.match_id
        ):
            return cls._reject(
                GateReason.INVALID_SESSION,
                stateSession=battle.session_key,
                currentSession=context.current_session,
            )
        opening_authoritative = bool(
            battle.srv_seq is not None
            and 0 <= battle.srv_seq <= 10_000_000
            and "ChatMessageDTO.MATCH_START.matchPayload.board" in battle.sources
            and battle.local_move_sequence == 0
            and battle.last_move_sequence in (None, -1, 0)
            and battle.turn_number in (0, 1)
        )
        authoritative_source = bool(
            any("_ackedSeqs" in source for source in battle.sources)
            or opening_authoritative
        )
        if (
            not state.board.production_ready
            or battle.srv_seq is None
            or battle.board_hash is None
            or cls._hash_pattern.fullmatch(battle.board_hash) is None
            or not (battle.acknowledged or opening_authoritative)
            or not battle.latest
            or not authoritative_source
        ):
            return cls._reject(
                GateReason.INVALID_BOARD,
                srvSeq=battle.srv_seq,
                boardHash=battle.board_hash,
                acknowledged=battle.acknowledged,
                latest=battle.latest,
                sources=battle.sources,
            )
        if (
            not battle.stable
            or battle.is_board_ready is not True
            or battle.is_cascade_running is not False
        ):
            return cls._reject(
                GateReason.BOARD_UNSTABLE,
                stable=battle.stable,
                isBoardReady=battle.is_board_ready,
                isCascadeRunning=battle.is_cascade_running,
            )
        if battle.board_current_state != 1:
            return cls._reject(
                GateReason.BOARD_NOT_MOVE_STATE,
                boardCurrentState=battle.board_current_state,
            )
        if battle.board_is_processing_ui is True or battle.presentation_busy is True:
            return cls._reject(
                GateReason.PRESENTATION_BUSY,
                boardProcessingUi=battle.board_is_processing_ui,
                presentationBusy=battle.presentation_busy,
            )
        if battle.board_has_destroyed_this_turn is True:
            return cls._reject(GateReason.TURN_ALREADY_RESOLVING)
        if battle.is_local_turn is None or not battle.local_username:
            return cls._reject(
                GateReason.TURN_UNKNOWN,
                currentTurnPlayer=battle.current_turn_player,
                localUsername=battle.local_username,
            )
        if battle.is_local_turn is not True:
            return cls._reject(
                GateReason.NOT_LOCAL_TURN,
                currentTurnPlayer=battle.current_turn_player,
                localUsername=battle.local_username,
            )

        opening_board_only_allowed = bool(
            context.allow_opening_board_only
            and opening_authoritative
            and battle.is_local_turn is True
            and battle.local_move_sequence == 0
        )
        opening_board_only = False
        player = state.player
        if player is None or player.hp is None or player.max_hp is None:
            if not opening_board_only_allowed:
                return cls._reject(GateReason.PLAYER_STATS_UNKNOWN)
            opening_board_only = True
        elif player.max_hp <= 0:
            return cls._reject(
                GateReason.PLAYER_STATS_UNKNOWN,
                hp=player.hp,
                maxHp=player.max_hp,
            )
        elif player.hp <= 0:
            return cls._reject(GateReason.PLAYER_DEAD, hp=player.hp)
        boss = next(
            (participant for participant in state.opponents if participant.is_boss),
            None,
        )
        if boss is None or boss.hp is None or boss.max_hp is None:
            if not opening_board_only_allowed:
                return cls._reject(GateReason.BOSS_STATS_UNKNOWN)
            opening_board_only = True
        elif boss.max_hp <= 0:
            return cls._reject(
                GateReason.BOSS_STATS_UNKNOWN,
                hp=boss.hp,
                maxHp=boss.max_hp,
            )
        elif boss.hp <= 0:
            return cls._reject(GateReason.BOSS_DEAD, hp=boss.hp)

        if battle.board_is_game_over is None or battle.match_over is None:
            return cls._reject(GateReason.END_STATE_UNKNOWN)
        if battle.board_is_game_over:
            return cls._reject(GateReason.GAME_OVER)
        if battle.match_over:
            return cls._reject(GateReason.MATCH_OVER)
        if battle.deferred_game_over is None:
            return cls._reject(GateReason.END_STATE_UNKNOWN)
        if battle.deferred_game_over:
            return cls._reject(GateReason.GAME_ENDING)
        if battle.board_modal_open is None:
            return cls._reject(GateReason.END_STATE_UNKNOWN, modal="unknown")
        if battle.board_modal_open:
            return cls._reject(GateReason.MODAL_OPEN)

        if battle.connection_ready is None or battle.reconnecting is None:
            return cls._reject(GateReason.CONNECTION_UNKNOWN)
        if battle.reconnecting or battle.match_resyncing or battle.board_is_resuming:
            return cls._reject(GateReason.RECONNECTING)
        if not battle.connection_ready:
            return cls._reject(GateReason.DISCONNECTED)
        if battle.clock_paused is None:
            return cls._reject(GateReason.CONNECTION_UNKNOWN, clock="unknown")
        if battle.clock_paused or battle.start_gate_paused:
            return cls._reject(
                GateReason.CLOCK_PAUSED,
                clockPauseReason=battle.clock_pause_reason,
                startGatePaused=battle.start_gate_paused,
            )
        if battle.client_move_allowed is None:
            return cls._reject(GateReason.CLIENT_MOVE_PERMISSION_UNKNOWN)
        if battle.client_move_allowed is not True:
            return cls._reject(GateReason.CLIENT_MOVE_BLOCKED)

        if context.input_locked:
            return cls._reject(GateReason.INPUT_LOCKED)
        if context.auto_paused:
            return cls._reject(GateReason.AUTO_PAUSED)
        if not context.window_valid:
            return cls._reject(GateReason.WINDOW_INVALID)
        if context.game_foreground is not True:
            return cls._reject(GateReason.GAME_NOT_FOREGROUND)
        return GateResult(
            True,
            GateReason.PASS,
            {
                "session": battle.session_key,
                "srvSeq": battle.srv_seq,
                "boardHash": battle.board_hash,
                "localActor": battle.local_actor_number,
                "playerHp": player.hp if player is not None else None,
                "bossHp": boss.hp if boss is not None else None,
                "openingBoardOnly": opening_board_only,
            },
        )
