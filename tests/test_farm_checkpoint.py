from __future__ import annotations

import json
import tempfile
import unittest
from pathlib import Path

from pokiguard_v2.boss_entry import BossLobbyState, FarmTarget
from pokiguard_v2.farm_checkpoint import (
    CHECKPOINT_SCHEMA,
    CheckpointError,
    CheckpointPayload,
    ResumeDecision,
    load_checkpoint,
    validate_for_resume,
    write_checkpoint,
)
from pokiguard_v2.farm_control import FarmControlState, GracefulStopController
from pokiguard_v2.farm_cycle import OpeningEvidence
from pokiguard_v2.farm_run import (
    FarmInputDomain,
    FarmRun,
    FarmRunEntryCapability,
    FarmRunGameplayCapability,
    FarmRunLimits,
    FarmRunState,
    FarmRunStopReason,
    MatchResult,
)
from pokiguard_v2.state import CombatSessionKey


SOURCE = "ChatMessageDTO.MATCH_START.matchPayload.board"


def session(index: int) -> CombatSessionKey:
    return CombatSessionKey(index, 0x100000 + index, f"M_{index:08x}")


def opening(key: CombatSessionKey, *, hash_digit: str | None = None) -> OpeningEvidence:
    digit = hash_digit or f"{key.lifecycle_epoch % 16:x}"
    return OpeningEvidence(
        session=key,
        match_id=key.match_id,
        board_hash=digit * 64,
        complete_cells=64,
        unique_coordinates=64,
        source=SOURCE,
        first_local_turn=True,
        local_move_sequence=0,
        stable_confirmations=3,
    )


def start_run(
    limits: FarmRunLimits | None = None,
    *,
    control: bool = False,
    resume: ResumeDecision | None = None,
    continuation_of: str | None = None,
) -> FarmRun:
    controller = GracefulStopController(timestamp=0.0) if control else None
    run = FarmRun(
        FarmTarget(boss_id="1289", boss_name="Starburst"),
        limits=limits,
        control=controller,
        resume=resume,
        continuation_of=continuation_of,
    )
    assert run.observe_initial_lobby(BossLobbyState.BOSS_LOBBY)
    return run


def enter(run: FarmRun, key: CombatSessionKey) -> None:
    assert run.target_resolved()
    capability = FarmRunEntryCapability(run)
    permit = capability.reserve(foreground=True)
    assert permit is not None
    assert capability.complete(permit, sent=True, detail="Start:SENT")
    assert run.accept_session(key)
    assert run.accept_opening(opening(key))


def finish_normal(run: FarmRun, result: MatchResult = MatchResult.WIN) -> None:
    assert run.normal_combat_ended(result)
    assert run.observe_postmatch()
    assert run.observe_return_lobby(BossLobbyState.BOSS_LOBBY)


def _payload(
    farm_run_id: str = "test_run",
    *,
    completed: int = 0,
    wins: int = 0,
    losses: int = 0,
    unknown: int = 0,
    attempts: int | None = None,
    aborts: int = 0,
    recoveries: int = 0,
    exits: int = 0,
    seen: tuple[str, ...] = (),
    finalized: str | None = None,
    target_boss_id: str = "1289",
    target_boss_name: str = "Starburst",
    target_completed: int = 5,
    max_recoveries: int = 1,
    max_attempts: int = 8,
) -> CheckpointPayload:
    effective_attempts = (
        attempts
        if attempts is not None
        else max(completed + aborts, len(seen))
    )
    return CheckpointPayload(
        schema_version=CHECKPOINT_SCHEMA,
        farm_run_id=farm_run_id,
        continuation_of=None,
        checkpoint_seq=1,
        created_at=1700000000.0,
        updated_at=1700000100.0,
        target_boss_id=target_boss_id,
        target_boss_name=target_boss_name,
        configured_limits={
            "target_completed_matches": target_completed,
            "max_technical_recoveries": max_recoveries,
            "max_match_attempts": max_attempts,
        },
        run_started_at=1700000000.0,
        match_attempts=effective_attempts,
        completed_matches=completed,
        wins=wins,
        losses=losses,
        unknown_results=unknown,
        technical_aborts=aborts,
        technical_recoveries=recoveries,
        technical_exits=exits,
        last_completed_match_id=(
            seen[min(completed - 1, len(seen) - 1)]
            if completed > 0 and seen
            else None
        ),
        seen_match_ids=seen,
        action_aggregates={
            "swap_sent": 0,
            "swap_acknowledged": 0,
            "swap_rejected": 0,
            "swap_aborted_state_changed": 0,
            "cast_sent": 0,
            "cast_accepted": 0,
            "cast_rejected": 0,
            "evolve_attempts": 0,
            "evolve_success": 0,
            "evolve_failed": 0,
        },
        pass_totals=0,
        consistency_aggregates={
            "consistent": wins + losses,
            "memory_incomplete": 0,
            "conflicts": 0,
            "strong_terminal_results": wins + losses,
        },
        last_safe_lifecycle="BOSS_LOBBY",
        stop_request_state=(
            "STOPPED_AT_LOBBY" if finalized == "STOPPED_GRACEFULLY" else None
        ),
        stop_reason=(
            "STOPPED_GRACEFULLY" if finalized == "STOPPED_GRACEFULLY" else None
        ),
        finalized_status=finalized,
    )


class GracefulStopAtLobbyTests(unittest.TestCase):
    def test_stop_before_any_entry(self) -> None:
        run = start_run(control=True)
        self.assertTrue(run.graceful_stop_request(lifecycle="LOBBY", match_id=None))
        snapshot = run.snapshot()
        self.assertEqual(snapshot.stop_reason, FarmRunStopReason.STOPPED_GRACEFULLY)
        self.assertEqual(snapshot.state, FarmRunState.FARM_RUN_COMPLETE)
        self.assertFalse(any(r.sent for r in snapshot.input_records))

    def test_stop_before_entry_click_cancels_reservation(self) -> None:
        run = start_run(control=True)
        assert run.target_resolved()
        cap = FarmRunEntryCapability(run)
        permit = cap.reserve(foreground=True)
        self.assertIsNotNone(permit)
        # Graceful stop before the physical click is sent.
        self.assertTrue(run.graceful_stop_request(lifecycle="ENTRY_PENDING", match_id=None))
        snapshot = run.snapshot()
        self.assertEqual(snapshot.stop_reason, FarmRunStopReason.STOPPED_GRACEFULLY)
        self.assertFalse(any(r.sent for r in snapshot.input_records))
        # Run is stopped; further reserves must be rejected.
        self.assertIsNone(cap.reserve(foreground=True))

    def test_duplicate_press_is_idempotent(self) -> None:
        run = start_run(control=True)
        self.assertTrue(run.graceful_stop_request(lifecycle="LOBBY", match_id=None))
        self.assertFalse(run.graceful_stop_request(lifecycle="LOBBY", match_id=None))
        snapshot = run.snapshot()
        self.assertEqual(snapshot.control_state, FarmControlState.STOPPED_AT_LOBBY)


class GracefulStopDuringCombatTests(unittest.TestCase):
    def test_f9_emergency_clears_pending_and_blocks_delayed_gameplay(self) -> None:
        run = start_run(FarmRunLimits(3, 1, 5), control=True)
        key = session(1)
        enter(run, key)
        capability = FarmRunGameplayCapability(run, key)
        permit = capability.reserve(action="SWAP", session=key, foreground=True)
        self.assertIsNotNone(permit)

        run.safe_stop(FarmRunStopReason.EMERGENCY_STOP, detail="F9 test")

        snapshot = run.snapshot()
        self.assertEqual(snapshot.stop_reason, FarmRunStopReason.EMERGENCY_STOP)
        self.assertEqual(snapshot.control_state, FarmControlState.EMERGENCY_STOPPED)
        self.assertIsNone(run._pending)
        self.assertIsNone(
            capability.reserve(action="SWAP", session=key, foreground=True)
        )
        self.assertEqual(run.snapshot().safety.input_after_farm_stop, 1)

    def test_stop_after_entry_sent_drains_current_match(self) -> None:
        run = start_run(FarmRunLimits(3, 1, 5), control=True)
        enter(run, session(1))
        self.assertTrue(run.graceful_stop_request(lifecycle="ACTIVE_COMBAT", match_id="M_00000001"))
        self.assertEqual(run._control.state, FarmControlState.DRAINING_CURRENT_MATCH)
        finish_normal(run)
        snapshot = run.snapshot()
        self.assertEqual(snapshot.completed_matches, 1)
        self.assertEqual(snapshot.stop_reason, FarmRunStopReason.STOPPED_GRACEFULLY)
        self.assertEqual(snapshot.state, FarmRunState.FARM_RUN_COMPLETE)
        # No second entry ever attempted.
        self.assertIsNone(FarmRunEntryCapability(run).reserve(foreground=True))

    def test_repeated_stop_during_drain_is_counted_and_does_not_reset_state(self) -> None:
        run = start_run(FarmRunLimits(3, 1, 5), control=True)
        enter(run, session(1))
        self.assertTrue(
            run.graceful_stop_request(
                lifecycle="ACTIVE_COMBAT", match_id="M_00000001"
            )
        )
        self.assertFalse(
            run.graceful_stop_request(
                lifecycle="ACTIVE_COMBAT", match_id="M_00000001"
            )
        )
        control = run._control.snapshot()
        self.assertEqual(control.state, FarmControlState.DRAINING_CURRENT_MATCH)
        self.assertEqual(control.duplicate_requests, 1)

    def test_stop_during_postmatch_completes_only_to_lobby(self) -> None:
        run = start_run(FarmRunLimits(3, 1, 5), control=True)
        enter(run, session(1))
        assert run.normal_combat_ended(MatchResult.WIN)
        assert run.observe_postmatch()
        self.assertTrue(run.graceful_stop_request(lifecycle="POSTMATCH", match_id="M_00000001"))
        assert run.observe_return_lobby(BossLobbyState.BOSS_LOBBY)
        snapshot = run.snapshot()
        self.assertEqual(snapshot.stop_reason, FarmRunStopReason.STOPPED_GRACEFULLY)
        self.assertEqual(snapshot.completed_matches, 1)

    def test_entry_gate_blocks_new_entry_after_drain(self) -> None:
        run = start_run(FarmRunLimits(3, 1, 5), control=True)
        enter(run, session(1))
        run.graceful_stop_request(lifecycle="ACTIVE_COMBAT", match_id="M_00000001")
        finish_normal(run)
        # After drain, a fresh reserve must fail at the gate.
        self.assertIsNone(FarmRunEntryCapability(run).reserve(foreground=True))
        snapshot = run.snapshot()
        self.assertEqual(snapshot.stop_reason, FarmRunStopReason.STOPPED_GRACEFULLY)

    def test_race_stop_and_entry_same_tick(self) -> None:
        """Postmatch→lobby and entry become actionable same poll; stop wins."""
        run = start_run(FarmRunLimits(3, 1, 5), control=True)
        enter(run, session(1))
        assert run.normal_combat_ended(MatchResult.WIN)
        assert run.observe_postmatch()
        assert run.observe_return_lobby(BossLobbyState.BOSS_LOBBY)
        # Stop request happens before the next reserve_entry call.
        run.graceful_stop_request(lifecycle="BOSS_LOBBY", match_id=None)
        self.assertIsNone(FarmRunEntryCapability(run).reserve(foreground=True))
        snapshot = run.snapshot()
        self.assertEqual(snapshot.stop_reason, FarmRunStopReason.STOPPED_GRACEFULLY)
        self.assertEqual(snapshot.completed_matches, 1)
        # No second entry attempt was ever counted.
        self.assertEqual(snapshot.match_attempts, 1)
        self.assertFalse(
            any(
                r.domain is FarmInputDomain.BOSS_ENTRY and r.sent
                for r in snapshot.input_records[1:]
            )
        )


class TechnicalExitTests(unittest.TestCase):
    def test_recovery_exit_without_reentry_stops_gracefully(self) -> None:
        run = start_run(FarmRunLimits(3, 1, 5), control=True)
        enter(run, session(1))
        run.graceful_stop_request(lifecycle="ACTIVE_COMBAT", match_id="M_00000001")
        assert run.technical_failure("SEQUENCE_DESYNC")
        assert run.begin_recovery()
        exit_record = type("R", (), {"domain": FarmInputDomain.RECOVERY_EXIT, "sent": True})()
        confirm_record = type("R", (), {"domain": FarmInputDomain.RECOVERY_CONFIRM, "sent": True})()
        self.assertTrue(run.record_technical_exit((exit_record, confirm_record)))
        snapshot = run.snapshot()
        self.assertEqual(snapshot.stop_reason, FarmRunStopReason.STOPPED_GRACEFULLY)
        self.assertEqual(snapshot.technical_exits, 1)
        self.assertEqual(snapshot.technical_recoveries, 0)
        self.assertTrue(run._control.snapshot().recovery_reentry_suppressed)

    def test_technical_exit_with_reentry_fails_closed(self) -> None:
        run = start_run(FarmRunLimits(3, 1, 5), control=True)
        enter(run, session(1))
        run.graceful_stop_request(lifecycle="ACTIVE_COMBAT", match_id="M_00000001")
        assert run.technical_failure("SEQUENCE_DESYNC")
        assert run.begin_recovery()
        records = (
            type("R", (), {"domain": FarmInputDomain.RECOVERY_EXIT, "sent": True})(),
            type("R", (), {"domain": FarmInputDomain.RECOVERY_CONFIRM, "sent": True})(),
            type("R", (), {"domain": FarmInputDomain.RECOVERY_REENTRY, "sent": True})(),
        )
        self.assertFalse(run.record_technical_exit(records))
        snapshot = run.snapshot()
        self.assertEqual(snapshot.stop_reason, FarmRunStopReason.INTERNAL_INVARIANT)


class CheckpointRoundTripTests(unittest.TestCase):
    def test_write_then_load_round_trip(self) -> None:
        payload = _payload(completed=2, wins=2, seen=("M_a", "M_b"))
        with tempfile.TemporaryDirectory() as tmp:
            path = Path(tmp) / "checkpoint.json"
            write_checkpoint(path, payload)
            loaded = load_checkpoint(path)
            self.assertEqual(loaded.completed_matches, 2)
            self.assertEqual(loaded.seen_match_ids, ("M_a", "M_b"))
            self.assertEqual(loaded.schema_version, CHECKPOINT_SCHEMA)

    def test_atomic_write_leaves_no_temp_on_success(self) -> None:
        payload = _payload()
        with tempfile.TemporaryDirectory() as tmp:
            directory = Path(tmp)
            path = directory / "checkpoint.json"
            write_checkpoint(path, payload)
            temps = list(directory.glob("checkpoint_*.tmp"))
            self.assertEqual(temps, [])
            self.assertTrue(path.exists())

    def test_malformed_json_raises_checkpoint_invalid(self) -> None:
        with tempfile.TemporaryDirectory() as tmp:
            path = Path(tmp) / "checkpoint.json"
            path.write_text("{not valid json", encoding="utf-8")
            with self.assertRaises(CheckpointError) as ctx:
                load_checkpoint(path)
            self.assertEqual(ctx.exception.reason, "CHECKPOINT_INVALID")

    def test_inconsistent_completed_accounting_is_rejected_before_write(self) -> None:
        payload = _payload(
            completed=2,
            wins=1,
            seen=("M_a", "M_b"),
        )
        with tempfile.TemporaryDirectory() as tmp:
            path = Path(tmp) / "checkpoint.json"
            with self.assertRaises(CheckpointError) as ctx:
                write_checkpoint(path, payload)
            self.assertEqual(ctx.exception.reason, "CHECKPOINT_INVALID")
            self.assertFalse(path.exists())

    def test_boolean_counter_in_external_json_is_not_coerced_to_integer(self) -> None:
        payload = _payload()
        raw = dict(payload.__dict__)
        raw["match_attempts"] = False
        with tempfile.TemporaryDirectory() as tmp:
            path = Path(tmp) / "checkpoint.json"
            path.write_text(json.dumps(raw), encoding="utf-8")
            with self.assertRaises(CheckpointError) as ctx:
                load_checkpoint(path)
            self.assertEqual(ctx.exception.reason, "CHECKPOINT_INVALID")

    def test_partial_swap_rejection_does_not_require_full_swap_sent(self) -> None:
        payload = _payload()
        payload = CheckpointPayload(
            **{
                **payload.__dict__,
                "action_aggregates": {
                    **payload.action_aggregates,
                    "swap_rejected": 1,
                },
            }
        )
        with tempfile.TemporaryDirectory() as tmp:
            path = Path(tmp) / "checkpoint.json"
            write_checkpoint(path, payload)
            self.assertEqual(load_checkpoint(path).action_aggregates["swap_rejected"], 1)

    def test_unsupported_schema_raises(self) -> None:
        payload = _payload()
        bad = {**dict(zip(
            [
                "schema_version", "farm_run_id", "continuation_of", "checkpoint_seq",
                "created_at", "updated_at", "target_boss_id", "target_boss_name",
                "configured_limits", "run_started_at", "match_attempts",
                "completed_matches", "wins", "losses", "unknown_results",
                "technical_aborts", "technical_recoveries", "technical_exits",
                "last_completed_match_id", "seen_match_ids", "action_aggregates",
                "pass_totals", "consistency_aggregates", "last_safe_lifecycle",
                "stop_request_state", "stop_reason", "finalized_status",
            ],
            [
                "pokiguard.farm_checkpoint.v99", payload.farm_run_id, None, 1,
                0.0, 0.0, "1289", "Starburst", {}, 0.0, 0, 0, 0, 0, 0, 0, 0, 0,
                None, [], {}, 0, {}, None, None, None, None,
            ],
        ))}
        with tempfile.TemporaryDirectory() as tmp:
            path = Path(tmp) / "checkpoint.json"
            path.write_text(json.dumps(bad), encoding="utf-8")
            with self.assertRaises(CheckpointError) as ctx:
                load_checkpoint(path)
            self.assertEqual(ctx.exception.reason, "CHECKPOINT_SCHEMA_UNSUPPORTED")

    def test_legacy_recovery_limit_mismatch_does_not_block_resume(self) -> None:
        payload = _payload(
            finalized="STOPPED_GRACEFULLY",
            target_completed=5,
            max_recoveries=1,
            max_attempts=8,
        )
        decision = validate_for_resume(
            payload,
            target_boss_id="1289",
            target_boss_name="Starburst",
            target_completed_matches=5,
            max_technical_recoveries=2,  # mismatch
            max_match_attempts=8,
        )
        self.assertTrue(decision.allowed)
        self.assertIsNone(decision.reason)

    def test_max_attempt_mismatch_still_blocks_resume(self) -> None:
        payload = _payload(
            finalized="STOPPED_GRACEFULLY",
            target_completed=5,
            max_recoveries=1,
            max_attempts=8,
        )
        decision = validate_for_resume(
            payload,
            target_boss_id="1289",
            target_boss_name="Starburst",
            target_completed_matches=5,
            max_technical_recoveries=999,
            max_match_attempts=9,
        )
        self.assertFalse(decision.allowed)
        self.assertEqual(decision.reason, "CHECKPOINT_CONFIG_MISMATCH")

    def test_legacy_recovery_cap_safe_stop_can_resume_history_from_lobby(self) -> None:
        seen = tuple(f"M_{index}" for index in range(23))
        payload = _payload(
            completed=19,
            wins=19,
            attempts=23,
            aborts=3,
            recoveries=3,
            seen=seen,
            finalized="SAFE_STOP",
            target_completed=25,
            max_recoveries=3,
            max_attempts=32,
        )
        payload = CheckpointPayload(
            **{
                **payload.__dict__,
                "last_safe_lifecycle": "BOSS_LOBBY",
                "stop_request_state": "RUNNING",
                "stop_reason": "COMBAT_SAFE_STOP",
            }
        )
        decision = validate_for_resume(
            payload,
            target_boss_id="1289",
            target_boss_name="Starburst",
            target_completed_matches=25,
            max_technical_recoveries=1,
            max_match_attempts=32,
        )
        self.assertTrue(decision.allowed)
        self.assertEqual(decision.historical_counters["match_attempts"], 23)
        self.assertEqual(decision.historical_counters["completed_matches"], 19)
        self.assertEqual(decision.historical_counters["technical_aborts"], 4)
        self.assertEqual(decision.remaining_completed, 6)

    def test_already_completed_blocks_resume(self) -> None:
        payload = _payload(completed=5, finalized="COMPLETED")
        decision = validate_for_resume(
            payload,
            target_boss_id="1289",
            target_boss_name="Starburst",
            target_completed_matches=5,
            max_technical_recoveries=1,
            max_match_attempts=8,
        )
        self.assertFalse(decision.allowed)
        self.assertEqual(decision.reason, "CHECKPOINT_ALREADY_COMPLETED")

    def test_emergency_stopped_blocks_resume(self) -> None:
        payload = _payload(finalized="EMERGENCY_STOPPED")
        decision = validate_for_resume(
            payload,
            target_boss_id="1289",
            target_boss_name="Starburst",
            target_completed_matches=5,
            max_technical_recoveries=1,
            max_match_attempts=8,
        )
        self.assertFalse(decision.allowed)
        self.assertEqual(decision.reason, "CHECKPOINT_NOT_RESUMABLE")

    def test_unfinalized_running_checkpoint_allows_history_only_resume(self) -> None:
        payload = _payload()
        payload = CheckpointPayload(
            **{**payload.__dict__, "stop_request_state": "RUNNING"}
        )
        decision = validate_for_resume(
            payload,
            target_boss_id="1289",
            target_boss_name="Starburst",
            target_completed_matches=5,
            max_technical_recoveries=1,
            max_match_attempts=8,
        )
        self.assertTrue(decision.allowed)
        self.assertIsNone(decision.reason)
        self.assertEqual(decision.historical_counters["completed_matches"], 0)
        self.assertEqual(decision.seen_match_ids, ())

    def test_unfinalized_running_checkpoint_requires_durable_lobby_boundary(self) -> None:
        payload = _payload()
        payload = CheckpointPayload(
            **{
                **payload.__dict__,
                "last_safe_lifecycle": "ACTIVE_COMBAT",
                "stop_request_state": "RUNNING",
            }
        )
        decision = validate_for_resume(
            payload,
            target_boss_id="1289",
            target_boss_name="Starburst",
            target_completed_matches=5,
            max_technical_recoveries=1,
            max_match_attempts=8,
        )
        self.assertFalse(decision.allowed)
        self.assertEqual(decision.reason, "CHECKPOINT_NOT_RESUMABLE")

    def test_graceful_checkpoint_requires_exact_safe_lobby_boundary(self) -> None:
        payload = _payload(finalized="STOPPED_GRACEFULLY")
        payload = CheckpointPayload(
            **{**payload.__dict__, "last_safe_lifecycle": "ACTIVE_COMBAT"}
        )
        decision = validate_for_resume(
            payload,
            target_boss_id="1289",
            target_boss_name="Starburst",
            target_completed_matches=5,
            max_technical_recoveries=1,
            max_match_attempts=8,
        )
        self.assertFalse(decision.allowed)
        self.assertEqual(decision.reason, "CHECKPOINT_NOT_RESUMABLE")

    def test_stopped_gracefully_allows_resume_when_target_not_reached(self) -> None:
        payload = _payload(
            completed=2, wins=2, finalized="STOPPED_GRACEFULLY", seen=("M_a", "M_b")
        )
        decision = validate_for_resume(
            payload,
            target_boss_id="1289",
            target_boss_name="Starburst",
            target_completed_matches=5,
            max_technical_recoveries=1,
            max_match_attempts=8,
        )
        self.assertTrue(decision.allowed)
        self.assertIsNone(decision.reason)
        self.assertEqual(decision.historical_counters["completed_matches"], 2)
        self.assertEqual(decision.remaining_completed, 3)
        self.assertEqual(decision.seen_match_ids, ("M_a", "M_b"))

    def test_forbidden_gameplay_state_key_rejected(self) -> None:
        payload = _payload()
        raw = dict(zip(
            [
                "schema_version", "farm_run_id", "continuation_of", "checkpoint_seq",
                "created_at", "updated_at", "target_boss_id", "target_boss_name",
                "configured_limits", "run_started_at", "match_attempts",
                "completed_matches", "wins", "losses", "unknown_results",
                "technical_aborts", "technical_recoveries", "technical_exits",
                "last_completed_match_id", "seen_match_ids", "action_aggregates",
                "pass_totals", "consistency_aggregates", "last_safe_lifecycle",
                "stop_request_state", "stop_reason", "finalized_status",
            ],
            [
                CHECKPOINT_SCHEMA, payload.farm_run_id, None, 1, 0.0, 0.0,
                "1289", "Starburst", {}, 0.0, 0, 0, 0, 0, 0, 0, 0, 0, None, [],
                {}, 0, {}, None, None, None, None,
            ],
        ))
        raw["board_instance"] = 0xDEAD  # forbidden
        with tempfile.TemporaryDirectory() as tmp:
            path = Path(tmp) / "checkpoint.json"
            path.write_text(json.dumps(raw), encoding="utf-8")
            with self.assertRaises(CheckpointError) as ctx:
                load_checkpoint(path)
            self.assertEqual(ctx.exception.reason, "CHECKPOINT_INVALID")
            self.assertIn("forbidden", ctx.exception.args[0])


class AccountingContinuityTests(unittest.TestCase):
    def test_three_plus_two_equals_five_cumulative(self) -> None:
        original = start_run(FarmRunLimits(5, 1, 8), control=True)
        for idx in range(1, 4):
            enter(original, session(idx))
            if idx == 3:
                original.graceful_stop_request(
                    lifecycle="ACTIVE_COMBAT", match_id="M_00000003"
                )
            finish_normal(original, MatchResult.WIN)
        payload = original.checkpoint_payload(finalized_status="STOPPED_GRACEFULLY")
        decision = validate_for_resume(
            payload,
            target_boss_id="1289",
            target_boss_name="Starburst",
            target_completed_matches=5,
            max_technical_recoveries=1,
            max_match_attempts=8,
        )
        self.assertTrue(decision.allowed)
        resumed = start_run(
            FarmRunLimits(5, 1, 8),
            resume=decision,
            continuation_of=original.farm_run_id,
        )
        self.assertEqual(resumed.completed_matches, 3)
        self.assertEqual(resumed.wins, 3)
        for idx in range(4, 6):
            enter(resumed, session(idx))
            finish_normal(resumed, MatchResult.WIN)
        snapshot = resumed.snapshot()
        self.assertEqual(snapshot.completed_matches, 5)
        self.assertEqual(snapshot.wins, 5)
        self.assertEqual(snapshot.stop_reason, FarmRunStopReason.FARM_TARGET_COMPLETED)

    def test_duplicate_match_id_from_checkpoint_triggers_conflict(self) -> None:
        original = start_run(FarmRunLimits(5, 1, 8), control=True)
        enter(original, session(1))
        original.graceful_stop_request(
            lifecycle="ACTIVE_COMBAT", match_id="M_00000001"
        )
        finish_normal(original)
        payload = original.checkpoint_payload(finalized_status="STOPPED_GRACEFULLY")
        decision = validate_for_resume(
            payload,
            target_boss_id="1289",
            target_boss_name="Starburst",
            target_completed_matches=5,
            max_technical_recoveries=1,
            max_match_attempts=8,
        )
        resumed = start_run(
            FarmRunLimits(5, 1, 8),
            resume=decision,
            continuation_of=original.farm_run_id,
        )
        # Reuse the same MatchId that was already recorded.
        assert resumed.target_resolved()
        reused = CombatSessionKey(99, 0x999999, "M_00000001")
        cap = FarmRunEntryCapability(resumed)
        permit = cap.reserve(foreground=True)
        assert permit is not None
        cap.complete(permit, sent=True)
        self.assertFalse(resumed.accept_session(reused))
        snapshot = resumed.snapshot()
        self.assertEqual(snapshot.stop_reason, FarmRunStopReason.CHECKPOINT_MATCH_ID_CONFLICT)

    def test_action_and_result_aggregates_survive_resume(self) -> None:
        payload = _payload(
            completed=2,
            wins=2,
            seen=("M_a", "M_b"),
            finalized="STOPPED_GRACEFULLY",
        )
        payload = CheckpointPayload(
            **{
                **payload.__dict__,
                "action_aggregates": {
                    **payload.action_aggregates,
                    "swap_sent": 7,
                    "swap_acknowledged": 7,
                    "cast_sent": 1,
                    "cast_accepted": 1,
                },
                "pass_totals": 2,
            }
        )
        decision = validate_for_resume(
            payload,
            target_boss_id="1289",
            target_boss_name="Starburst",
            target_completed_matches=5,
            max_technical_recoveries=1,
            max_match_attempts=8,
        )
        resumed = start_run(
            FarmRunLimits(5, 1, 8),
            resume=decision,
            continuation_of=payload.farm_run_id,
        )

        snapshot = resumed.snapshot()
        self.assertEqual(snapshot.total_swap_sent, 7)
        self.assertEqual(snapshot.total_swap_acknowledged, 7)
        self.assertEqual(snapshot.total_cast_sent, 1)
        self.assertEqual(snapshot.total_cast_accepted, 1)
        self.assertEqual(snapshot.total_pass_count, 2)
        self.assertEqual(snapshot.result_consistent_count, 2)
        self.assertTrue(snapshot.memory_terminal_result_proven)


if __name__ == "__main__":
    unittest.main()
