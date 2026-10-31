"""Current-combat admission for the Dinosaur play style, without boss entry."""
from __future__ import annotations

from .basic_policy import PlayStyle
from .boss_entry import FarmTarget
from .combat_lifecycle import CombatLifecycleState
from .farm_run import (
    FarmRun, FarmRunLimits, FarmRunState, FarmRunStopReason, MatchTelemetry,
    utc_timestamp,
)
from .state import (
    CombatSessionKey, GamePhase, GameState, TerminalCombatSnapshot,
    TerminalResult, TerminalResultConfidence,
)


def missed_turn_can_wait(*, play_style: str, turn: int | None,
                            local_move_sequence: int | None,
                            sent_consuming_inputs: int, pending: object | None,
                            mandatory_reset: bool) -> bool:
    """An unsent Dinosaur turn may expire; read a fresh board next turn.

    The caller proves the exact local session and that this turn has no sent
    consuming action. Prior turns' input count and the idle-reset requirement
    do not turn an expired timer into a controller Stop. Pending/uncertain
    actions retain their separate ACK/timeout guards. Never fabricate PASS.
    """
    return bool(
        play_style == PlayStyle.DINOSAUR.value
        and type(turn) is int and turn >= 0
        and type(local_move_sequence) is int and local_move_sequence >= 0
        and pending is None
    )


# Compatibility name for existing offline imports; the current rule covers
# every unsent local turn, including a session attached after turn one.
missed_opening_can_wait = missed_turn_can_wait


def confirmed_dinosaur_win(terminal: TerminalCombatSnapshot | None,
                          session: CombatSessionKey | None) -> bool:
    """Strong outcome for this exact combat; presentation/lobby not required."""
    return bool(
        terminal is not None and session is not None
        and terminal.session_key == session and terminal.match_id == session.match_id
        and terminal.result is TerminalResult.WIN
        and terminal.confidence is TerminalResultConfidence.STRONG
        and terminal.captured_before_cleanup
        and terminal.evidence_sources
        and not any(source in {'TERMINAL_MEMORY_CONFLICT','TERMINAL_SNAPSHOT_MISSING',
                               'TERMINAL_SNAPSHOT_INVALID'} for source in terminal.evidence_sources)
    )


def completed_dinosaur_win_summary(summary: dict, terminal: TerminalCombatSnapshot,
                                  session: CombatSessionKey) -> bool:
    """Accept this profile's early win without inventing postmatch evidence."""
    safety=summary.get('safetyTelemetry')
    return bool(
        summary.get('stopReason') == 'DINOSAUR_WIN_CONFIRMED'
        and summary.get('attemptClassification') == 'DINOSAUR_CURRENT_WIN'
        and summary.get('fullCombatResult') == 'WIN'
        and summary.get('sessionCleared') is True
        and summary.get('activeSession') is None and summary.get('pending') is None
        and isinstance(safety,dict) and all(int(v or 0)==0 for v in safety.values())
        and confirmed_dinosaur_win(terminal,session)
    )


class DinosaurCombatRun(FarmRun):
    """Reuse the gameplay permit/telemetry ledger for exactly one live match.

    The descriptive target is not a game pet identity. This runner never
    resolves it or obtains an entry, navigation, reward or recovery permit.
    """

    def __init__(self, config, *, expected_match_id: str) -> None:
        if config.play_style is not PlayStyle.DINOSAUR:
            raise ValueError("DINOSAUR_PROFILE_REQUIRED")
        if not isinstance(expected_match_id, str) or not expected_match_id.strip():
            raise ValueError("CURRENT_COMBAT_MATCH_ID_NOT_PROVEN")
        self.expected_match_id = expected_match_id
        super().__init__(
            FarmTarget(boss_name="Khủng long"),
            limits=FarmRunLimits(1, 0, 1),
            gameplay_config=config.gameplay_config,
            input_delivery_mode=config.input_delivery_mode,
        )
        self._transition(FarmRunState.WAIT_OPENING, "dinosaur_wait_current_board",
                         expectedMatchId=expected_match_id, entryInputSent=False)

    def adopt(self, state: GameState, *, confirmations: int) -> bool:
        battle = state.battle
        session = battle.session_key
        if (
            self.state is not FarmRunState.WAIT_OPENING
            or self.match_attempts != 0 or self._pending is not None
            or state.phase is not GamePhase.COMBAT
            or state.board is None or not state.board.production_ready
            or battle.combat_lifecycle is not CombatLifecycleState.ACTIVE
            or battle.stable is not True or confirmations < 2
            or session is None or session.match_id != self.expected_match_id
            or battle.match_id != self.expected_match_id
            or not battle.board_hash or battle.srv_seq is None
            or battle.match_over is not False
            or battle.board_is_game_over is not False
        ):
            self.safe_stop(FarmRunStopReason.OPENING_INVARIANT_FAILED,
                           detail="DINOSAUR_CURRENT_BOARD_NOT_PROVEN")
            return False
        self._seen_sessions.add(session)
        self._seen_match_ids.add(session.match_id)
        self.current_session = session
        self.match_attempts = 1
        self.attempts.append(MatchTelemetry(1, session.match_id, session,
                                           utc_timestamp()))
        self._transition(FarmRunState.COMBAT_ACTIVE, "dinosaur_current_combat_adopted",
                         session=session, turn=battle.turn_number,
                         entryInputSent=False, openingTurnRequired=False)
        return True

    def finish_current_combat(self, terminal: TerminalCombatSnapshot) -> bool:
        if not terminal.evidence_sources or any(source in {
            "TERMINAL_SNAPSHOT_MISSING", "TERMINAL_SNAPSHOT_INVALID",
        } for source in terminal.evidence_sources):
            self.safe_stop(FarmRunStopReason.COMBAT_SAFE_STOP,
                           detail="DINOSAUR_TERMINAL_UNPROVEN")
            return False
        if not self.normal_combat_ended(terminal):
            return False
        self.stop_reason = (
            FarmRunStopReason.STOPPED_GRACEFULLY
            if self.graceful_stop_requested()
            else FarmRunStopReason.FARM_TARGET_COMPLETED
        )
        self.end_timestamp = utc_timestamp()
        self._transition(FarmRunState.FARM_RUN_COMPLETE,
                         "dinosaur_current_combat_completed",
                         bossLobbyRequired=False, automaticReentry=False)
        return True
