"""Fail-closed terminal combat classification and UI audit reconciliation."""

from __future__ import annotations

from dataclasses import replace
import unicodedata

from .state import (
    CombatSessionKey,
    GameState,
    ParticipantState,
    ResultConsistency,
    TerminalCombatSnapshot,
    TerminalResult,
    TerminalResultConfidence,
)


AUTHORITATIVE_BOSS_WINNERS = frozenset({"BOSS", "__BOSS__"})


def result_from_winner(
    winner: str | None, local_username: str | None
) -> TerminalResult:
    """Mirror the reverse-proven BoardWsApplier winner comparison exactly."""

    if not winner:
        return TerminalResult.UNKNOWN
    if local_username and winner.casefold() == local_username.casefold():
        return TerminalResult.WIN
    if winner in AUTHORITATIVE_BOSS_WINNERS:
        return TerminalResult.LOSS
    return TerminalResult.UNKNOWN


def result_from_hp(
    local_hp: int | None, boss_hp: int | None
) -> TerminalResult:
    """Resolve only an unambiguous terminal HP pair."""

    if local_hp is None or boss_hp is None:
        return TerminalResult.UNKNOWN
    if boss_hp == 0 and local_hp > 0:
        return TerminalResult.WIN
    if local_hp == 0 and boss_hp > 0:
        return TerminalResult.LOSS
    return TerminalResult.UNKNOWN


def ui_result_from_text(value: str | None) -> TerminalResult:
    """Classify only the two user-verified result labels, never fuzzy OCR."""

    if value is None:
        return TerminalResult.UNKNOWN
    normalized = unicodedata.normalize("NFC", value).strip().casefold()
    if normalized == "thắng".casefold():
        return TerminalResult.WIN
    if normalized == "thua".casefold():
        return TerminalResult.LOSS
    return TerminalResult.UNKNOWN


def reconcile_results(
    memory_result: TerminalResult, ui_result: TerminalResult
) -> ResultConsistency:
    if memory_result is TerminalResult.UNKNOWN:
        if ui_result is TerminalResult.UNKNOWN:
            return ResultConsistency.BOTH_UNKNOWN
        return ResultConsistency.MEMORY_INCOMPLETE
    if ui_result is TerminalResult.UNKNOWN:
        return ResultConsistency.UI_INCOMPLETE
    if memory_result is ui_result:
        return ResultConsistency.CONSISTENT
    return ResultConsistency.RESULT_CONFLICT


def _local_and_boss(
    participants: tuple[ParticipantState, ...],
) -> tuple[ParticipantState | None, ParticipantState | None]:
    local = next((item for item in participants if item.is_local is True), None)
    boss = next((item for item in participants if item.is_boss is True), None)
    return local, boss


def capture_terminal_snapshot(
    *,
    session_key: CombatSessionKey,
    timestamp: str,
    active_state: GameState | None = None,
    terminal_participants: tuple[ParticipantState, ...] = (),
    terminal_event_type: str | None = None,
    terminal_winner: str | None = None,
    local_username: str | None = None,
    ui_text: str | None = None,
    captured_before_cleanup: bool,
) -> TerminalCombatSnapshot:
    """Build one immutable terminal record without trusting stale positive HP.

    Current terminal participants are preferred.  The last ACTIVE snapshot is
    used for HP classification only when it already contains a terminal zero;
    ordinary positive pre-terminal stats cannot manufacture a result after
    ownership has disappeared.
    """

    local, boss = _local_and_boss(terminal_participants)
    active_local = active_state.player if active_state is not None else None
    active_boss = None
    if active_state is not None:
        active_boss = next(
            (item for item in active_state.opponents if item.is_boss is True),
            active_state.opponents[0] if active_state.opponents else None,
        )

    use_active_hp = bool(
        not terminal_participants
        and (
            (active_local is not None and active_local.hp == 0)
            or (active_boss is not None and active_boss.hp == 0)
        )
    )
    if local is None and use_active_hp:
        local = active_local
    if boss is None and use_active_hp:
        boss = active_boss

    local_hp = local.hp if local is not None else None
    boss_hp = boss.hp if boss is not None else None
    hp_result = result_from_hp(local_hp, boss_hp)
    username = local_username
    if username is None and active_state is not None:
        username = active_state.battle.local_username
    event_result = result_from_winner(terminal_winner, username)

    sources: list[str] = []
    if terminal_event_type == "MATCH_GAME_OVER":
        sources.append("ChatMessageDTO.MATCH_GAME_OVER")
    if terminal_winner:
        sources.append("ChatMessageDTO.matchPayload.winner")
    if local is not None:
        sources.append("Active.PlayerStats.local")
    if boss is not None:
        sources.append("Active.PlayerStats.boss")
    if captured_before_cleanup:
        sources.append("ACTIVE_TO_POSTMATCH_PRE_CLEANUP")

    resolved = TerminalResult.UNKNOWN
    confidence = TerminalResultConfidence.UNKNOWN
    if (
        event_result is not TerminalResult.UNKNOWN
        and hp_result is not TerminalResult.UNKNOWN
        and event_result is not hp_result
    ):
        sources.append("TERMINAL_MEMORY_CONFLICT")
        confidence = TerminalResultConfidence.PARTIAL
    elif event_result is not TerminalResult.UNKNOWN:
        resolved = event_result
        confidence = (
            TerminalResultConfidence.STRONG
            if captured_before_cleanup
            else TerminalResultConfidence.PARTIAL
        )
    elif hp_result is not TerminalResult.UNKNOWN:
        resolved = hp_result
        confidence = (
            TerminalResultConfidence.STRONG
            if captured_before_cleanup
            else TerminalResultConfidence.PARTIAL
        )
        sources.append("TERMINAL_HP_PAIR")
    elif sources:
        confidence = TerminalResultConfidence.PARTIAL

    battle = active_state.battle if active_state is not None else None
    return TerminalCombatSnapshot(
        match_id=session_key.match_id,
        session_key=session_key,
        lifecycle_epoch=session_key.lifecycle_epoch,
        timestamp=timestamp,
        turn_number=battle.turn_number if battle is not None else None,
        srv_seq=battle.srv_seq if battle is not None else None,
        board_hash=battle.board_hash if battle is not None else None,
        local_actor_number=local.actor_number if local is not None else None,
        local_hp=local_hp,
        local_max_hp=local.max_hp if local is not None else None,
        boss_actor_number=boss.actor_number if boss is not None else None,
        boss_hp=boss_hp,
        boss_max_hp=boss.max_hp if boss is not None else None,
        terminal_event_type=terminal_event_type,
        terminal_winner=terminal_winner,
        result=resolved,
        confidence=confidence,
        evidence_sources=tuple(dict.fromkeys(sources)),
        ui_text=ui_text,
        ui_result=ui_result_from_text(ui_text),
        captured_before_cleanup=captured_before_cleanup,
    )


def merge_terminal_snapshots(
    current: TerminalCombatSnapshot | None,
    observed: TerminalCombatSnapshot | None,
) -> TerminalCombatSnapshot | None:
    """Enrich a frozen record while never downgrading a resolved result."""

    if current is None:
        return observed
    if observed is None:
        return current
    if current.session_key != observed.session_key:
        raise ValueError("cannot merge terminal snapshots from different sessions")

    current_strong = (
        current.confidence is TerminalResultConfidence.STRONG
        and current.result is not TerminalResult.UNKNOWN
    )
    observed_strong = (
        observed.confidence is TerminalResultConfidence.STRONG
        and observed.result is not TerminalResult.UNKNOWN
    )
    sticky_conflict = "TERMINAL_MEMORY_CONFLICT" in current.evidence_sources
    if sticky_conflict:
        result = TerminalResult.UNKNOWN
        confidence = TerminalResultConfidence.PARTIAL
        extra_sources = ()
    elif current_strong and observed_strong and current.result is not observed.result:
        result = TerminalResult.UNKNOWN
        confidence = TerminalResultConfidence.PARTIAL
        extra_sources = ("TERMINAL_MEMORY_CONFLICT",)
    elif current_strong:
        result = current.result
        confidence = current.confidence
        extra_sources = ()
    elif observed_strong:
        result = observed.result
        confidence = observed.confidence
        extra_sources = ()
    elif current.result is not TerminalResult.UNKNOWN:
        result = current.result
        confidence = current.confidence
        extra_sources = ()
    else:
        result = observed.result
        confidence = observed.confidence
        extra_sources = ()

    def prefer(left: object | None, right: object | None) -> object | None:
        return left if left is not None else right

    ui_text = observed.ui_text or current.ui_text
    ui_result = (
        observed.ui_result
        if observed.ui_result is not TerminalResult.UNKNOWN
        else current.ui_result
    )
    return replace(
        current,
        timestamp=observed.timestamp or current.timestamp,
        turn_number=prefer(observed.turn_number, current.turn_number),
        srv_seq=prefer(observed.srv_seq, current.srv_seq),
        board_hash=prefer(observed.board_hash, current.board_hash),
        local_actor_number=prefer(
            observed.local_actor_number, current.local_actor_number
        ),
        local_hp=prefer(observed.local_hp, current.local_hp),
        local_max_hp=prefer(observed.local_max_hp, current.local_max_hp),
        boss_actor_number=prefer(
            observed.boss_actor_number, current.boss_actor_number
        ),
        boss_hp=prefer(observed.boss_hp, current.boss_hp),
        boss_max_hp=prefer(observed.boss_max_hp, current.boss_max_hp),
        terminal_event_type=prefer(
            observed.terminal_event_type, current.terminal_event_type
        ),
        terminal_winner=prefer(observed.terminal_winner, current.terminal_winner),
        result=result,
        confidence=confidence,
        evidence_sources=tuple(
            dict.fromkeys(
                current.evidence_sources + observed.evidence_sources + extra_sources
            )
        ),
        ui_text=ui_text,
        ui_result=ui_result,
        captured_before_cleanup=bool(
            current.captured_before_cleanup or observed.captured_before_cleanup
        ),
    )


__all__ = [
    "capture_terminal_snapshot",
    "merge_terminal_snapshots",
    "reconcile_results",
    "result_from_hp",
    "result_from_winner",
    "ui_result_from_text",
]
