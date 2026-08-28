from __future__ import annotations

import unittest
from pathlib import Path
import tempfile

from pokiguard_v2.boss_entry import BossLobbyState, FarmTarget
from pokiguard_v2.farm_cycle import OpeningEvidence
from pokiguard_v2.farm_run import (
    FarmRun,
    FarmRunEntryCapability,
    FarmRunLimits,
    FarmRunState,
    FarmRunStopReason,
)
from pokiguard_v2.state import (
    BattleState,
    CombatSessionKey,
    GamePhase,
    GameState,
    ParticipantState,
    ResultConsistency,
    TerminalResult,
    TerminalResultConfidence,
)
from pokiguard_v2.terminal_result import (
    capture_terminal_snapshot,
    merge_terminal_snapshots,
    reconcile_results,
    ui_result_from_text,
)
from tools.farm_run import (
    _recovery_args,
    _terminal_snapshot_from_summary,
    _validate_args,
    build_parser,
)
from tools.idle_state_watch import SERVER_EVENT_TYPES


def session(index: int = 1) -> CombatSessionKey:
    return CombatSessionKey(index, 0x120000 + index, f"M_d5_{index}")


def participant_pair(
    local_hp: int | None, boss_hp: int | None
) -> tuple[ParticipantState, ParticipantState]:
    return (
        ParticipantState(
            1,
            is_local=True,
            is_boss=False,
            hp=local_hp,
            max_hp=100,
            source="Active.PlayerStats",
        ),
        ParticipantState(
            2,
            is_local=False,
            is_boss=True,
            hp=boss_hp,
            max_hp=200,
            source="Active.PlayerStats",
        ),
    )


def active_state(
    key: CombatSessionKey, local_hp: int | None, boss_hp: int | None
) -> GameState:
    local, boss = participant_pair(local_hp, boss_hp)
    return GameState(
        GamePhase.UNKNOWN,
        "2026-08-16T00:00:00.000Z",
        battle=BattleState(
            board_instance=key.board_instance,
            srv_seq=9,
            turn_number=12,
            board_hash="a" * 64,
            session_key=key,
            match_id=key.match_id,
            local_username="happi",
        ),
        player=local,
        opponents=(boss,),
        participants=(local, boss),
    )


def terminal(
    key: CombatSessionKey,
    local_hp: int | None,
    boss_hp: int | None,
    *,
    ui_text: str | None = None,
):
    return capture_terminal_snapshot(
        session_key=key,
        timestamp="2026-08-16T00:00:01.000Z",
        active_state=active_state(key, 50, 50),
        terminal_participants=participant_pair(local_hp, boss_hp),
        local_username="happi",
        ui_text=ui_text,
        captured_before_cleanup=True,
    )


def enter_run(run: FarmRun, key: CombatSessionKey) -> None:
    assert run.target_resolved()
    capability = FarmRunEntryCapability(run)
    permit = capability.reserve(foreground=True)
    assert permit is not None
    assert capability.complete(permit, sent=True)
    assert run.accept_session(key)
    assert run.accept_opening(
        OpeningEvidence(
            session=key,
            match_id=key.match_id,
            board_hash="b" * 64,
            complete_cells=64,
            unique_coordinates=64,
            source="ChatMessageDTO.MATCH_START.matchPayload.board",
            first_local_turn=True,
            local_move_sequence=0,
            stable_confirmations=2,
        )
    )


def new_run(limits: FarmRunLimits | None = None) -> FarmRun:
    run = FarmRun(FarmTarget(boss_id="1289"), limits=limits)
    assert run.observe_initial_lobby(BossLobbyState.BOSS_LOBBY)
    return run


class TerminalClassificationTests(unittest.TestCase):
    def test_match_game_over_is_scanned(self) -> None:
        self.assertIn("MATCH_GAME_OVER", SERVER_EVENT_TYPES)

    def test_win_captured_before_ownership_cleanup(self) -> None:
        snapshot = terminal(session(), 50, 0)
        self.assertEqual(snapshot.result, TerminalResult.WIN)
        self.assertEqual(snapshot.confidence, TerminalResultConfidence.STRONG)
        self.assertIn("TERMINAL_HP_PAIR", snapshot.evidence_sources)

    def test_loss_captured_before_ownership_cleanup(self) -> None:
        snapshot = terminal(session(), 0, 50)
        self.assertEqual(snapshot.result, TerminalResult.LOSS)
        self.assertEqual(snapshot.confidence, TerminalResultConfidence.STRONG)

    def test_unknown_when_evidence_is_insufficient(self) -> None:
        snapshot = terminal(session(), 50, 50)
        self.assertEqual(snapshot.result, TerminalResult.UNKNOWN)
        self.assertNotEqual(snapshot.confidence, TerminalResultConfidence.STRONG)

    def test_ownership_disappears_too_early_does_not_use_stale_positive_hp(self) -> None:
        key = session()
        snapshot = capture_terminal_snapshot(
            session_key=key,
            timestamp="2026-08-16T00:00:01.000Z",
            active_state=active_state(key, 50, 50),
            terminal_participants=(),
            captured_before_cleanup=False,
        )
        self.assertEqual(snapshot.result, TerminalResult.UNKNOWN)
        self.assertIsNone(snapshot.local_hp)
        self.assertIsNone(snapshot.boss_hp)

    def test_authoritative_winner_resolves_without_hp_pair(self) -> None:
        key = session()
        snapshot = capture_terminal_snapshot(
            session_key=key,
            timestamp="2026-08-16T00:00:01.000Z",
            active_state=active_state(key, 50, 50),
            terminal_event_type="MATCH_GAME_OVER",
            terminal_winner="happi",
            local_username="happi",
            captured_before_cleanup=True,
        )
        self.assertEqual(snapshot.result, TerminalResult.WIN)
        self.assertEqual(snapshot.confidence, TerminalResultConfidence.STRONG)

    def test_frozen_strong_result_survives_cleanup_observation(self) -> None:
        key = session()
        frozen = terminal(key, 50, 0)
        cleanup = capture_terminal_snapshot(
            session_key=key,
            timestamp="2026-08-16T00:00:02.000Z",
            terminal_participants=(),
            ui_text="THẮNG",
            captured_before_cleanup=False,
        )
        merged = merge_terminal_snapshots(frozen, cleanup)
        self.assertIsNotNone(merged)
        self.assertEqual(merged.result, TerminalResult.WIN)  # type: ignore[union-attr]
        self.assertEqual(merged.ui_result, TerminalResult.WIN)  # type: ignore[union-attr]

    def test_terminal_memory_conflict_is_sticky(self) -> None:
        key = session()
        win = terminal(key, 50, 0)
        loss = terminal(key, 0, 50)
        conflict = merge_terminal_snapshots(win, loss)
        restored = merge_terminal_snapshots(conflict, win)
        self.assertEqual(restored.result, TerminalResult.UNKNOWN)  # type: ignore[union-attr]
        self.assertIn(  # type: ignore[union-attr]
            "TERMINAL_MEMORY_CONFLICT", restored.evidence_sources
        )

    def test_ui_memory_consistency_matrix(self) -> None:
        self.assertEqual(
            reconcile_results(TerminalResult.WIN, ui_result_from_text("THẮNG")),
            ResultConsistency.CONSISTENT,
        )
        self.assertEqual(
            reconcile_results(TerminalResult.LOSS, ui_result_from_text("THUA")),
            ResultConsistency.CONSISTENT,
        )
        self.assertEqual(
            reconcile_results(TerminalResult.UNKNOWN, ui_result_from_text("THẮNG")),
            ResultConsistency.MEMORY_INCOMPLETE,
        )
        self.assertEqual(
            reconcile_results(TerminalResult.WIN, ui_result_from_text("THUA")),
            ResultConsistency.RESULT_CONFLICT,
        )


class TerminalFarmAccountingTests(unittest.TestCase):
    def test_summary_round_trip_preserves_terminal_session(self) -> None:
        key = session()
        source = terminal(key, 50, 0)
        raw = {
            "match_id": source.match_id,
            "session_key": {
                "lifecycle_epoch": key.lifecycle_epoch,
                "board_instance": key.board_instance,
                "match_id": key.match_id,
            },
            "lifecycle_epoch": source.lifecycle_epoch,
            "timestamp": source.timestamp,
            "turn_number": source.turn_number,
            "srv_seq": source.srv_seq,
            "board_hash": source.board_hash,
            "local_actor_number": source.local_actor_number,
            "local_hp": source.local_hp,
            "local_max_hp": source.local_max_hp,
            "boss_actor_number": source.boss_actor_number,
            "boss_hp": source.boss_hp,
            "boss_max_hp": source.boss_max_hp,
            "result": source.result.value,
            "confidence": source.confidence.value,
            "evidence_sources": list(source.evidence_sources),
            "ui_result": source.ui_result.value,
            "captured_before_cleanup": True,
        }
        observed = _terminal_snapshot_from_summary(
            {"terminalCombatSnapshot": raw}, key
        )
        self.assertEqual(observed, source)

    def test_d5_b1_limits_are_hard_bounded_to_one_attempt(self) -> None:
        with tempfile.TemporaryDirectory() as temporary:
            evidence = Path(temporary) / "reset.json"
            evidence.write_text("{}", encoding="utf-8")
            args = build_parser().parse_args(
                [
                    "--stage-d5-b1-terminal",
                    "--boss-id",
                    "1289",
                    "--reset-evidence",
                    str(evidence),
                ]
            )
            limits = _validate_args(args)
        self.assertEqual(limits.target_completed_matches, 1)
        self.assertEqual(limits.max_technical_recoveries, 0)
        self.assertEqual(limits.max_match_attempts, 1)

    def test_d5_b2_outer_recovery_limit_is_not_forwarded_to_d3(self) -> None:
        args = build_parser().parse_args(
            [
                "--stage-d5-b2-soak",
                "--boss-id",
                "1289",
                "--target-matches",
                "10",
                "--max-technical-recoveries",
                "2",
                "--max-match-attempts",
                "14",
            ]
        )

        recovery = _recovery_args(args, Path("artifacts"), test_only=False)

        self.assertEqual(args.max_technical_recoveries, 2)
        self.assertEqual(recovery.max_technical_recoveries, 1)

    def test_normal_completed_match_counts_exactly_once(self) -> None:
        key = session()
        run = new_run(FarmRunLimits(1, 0, 1))
        enter_run(run, key)
        snapshot = terminal(key, 50, 0, ui_text="THẮNG")
        self.assertTrue(run.normal_combat_ended(snapshot))
        self.assertTrue(run.normal_combat_ended(snapshot))
        result = run.snapshot()
        self.assertEqual(result.completed_matches, 1)
        self.assertEqual(result.wins, 1)
        self.assertEqual(result.losses, 0)
        self.assertEqual(result.unknown_results, 0)
        self.assertTrue(result.result_accounting_consistent)
        self.assertEqual(result.safety.result_double_count, 0)

    def test_repeated_postmatch_polling_is_idempotent(self) -> None:
        key = session()
        run = new_run(FarmRunLimits(1, 0, 1))
        enter_run(run, key)
        self.assertTrue(run.normal_combat_ended(terminal(key, 50, 0)))
        self.assertTrue(run.observe_postmatch())
        self.assertTrue(run.observe_postmatch())
        self.assertEqual(run.snapshot().completed_matches, 1)

    def test_unknown_normal_result_is_exposed(self) -> None:
        key = session()
        run = new_run(FarmRunLimits(1, 0, 1))
        enter_run(run, key)
        self.assertTrue(run.normal_combat_ended(terminal(key, 50, 50)))
        result = run.snapshot()
        self.assertEqual(result.completed_matches, 1)
        self.assertEqual(result.unknown_results, 1)
        self.assertTrue(result.result_accounting_consistent)

    def test_unproven_unknown_lifecycle_loss_does_not_count_completed(self) -> None:
        key = session()
        run = new_run(FarmRunLimits(1, 0, 1))
        enter_run(run, key)
        snapshot = capture_terminal_snapshot(
            session_key=key,
            timestamp="2026-08-16T00:00:01.000Z",
            active_state=active_state(key, 50, 50),
            terminal_participants=(),
            local_username="happi",
            captured_before_cleanup=False,
        )

        self.assertFalse(run.normal_combat_ended(snapshot))

        result = run.snapshot()
        self.assertEqual(result.completed_matches, 0)
        self.assertEqual(result.unknown_results, 0)
        self.assertEqual(result.stop_reason, FarmRunStopReason.COMBAT_SAFE_STOP)
        self.assertEqual(result.attempts[-1].result.value, "SAFE_STOP")

    def test_technical_abort_does_not_count_normal_result(self) -> None:
        key = session()
        run = new_run(FarmRunLimits(1, 1, 2))
        enter_run(run, key)
        self.assertTrue(run.technical_failure("SEQUENCE_DESYNC"))
        result = run.snapshot()
        self.assertEqual(result.technical_aborts, 1)
        self.assertEqual(result.completed_matches, 0)
        self.assertEqual(result.wins + result.losses + result.unknown_results, 0)

    def test_result_conflict_stops_only_after_safe_lobby(self) -> None:
        key = session()
        run = new_run(FarmRunLimits(2, 0, 2))
        enter_run(run, key)
        self.assertTrue(run.normal_combat_ended(terminal(key, 50, 0)))
        self.assertTrue(run.observe_postmatch())
        consistency = run.record_postmatch_ui_audit(
            TerminalResult.LOSS, ui_text="THUA"
        )
        self.assertEqual(consistency, ResultConsistency.RESULT_CONFLICT)
        self.assertFalse(run.observe_return_lobby(BossLobbyState.BOSS_LOBBY))
        self.assertEqual(run.state, FarmRunState.SAFE_STOP)
        self.assertEqual(run.snapshot().safety.result_conflict, 1)


if __name__ == "__main__":
    unittest.main()
