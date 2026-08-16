from __future__ import annotations

from dataclasses import replace
from pathlib import Path
import tempfile
import unittest

from pokiguard_v2.boss_entry import BossLobbyState, FarmTarget
from pokiguard_v2.combat_lifecycle import CombatLifecycleState
from pokiguard_v2.farm_cycle import OpeningEvidence
from pokiguard_v2.farm_run import (
    FarmInputDomain,
    FarmRun,
    FarmRunArtifactWriter,
    FarmRunEntryCapability,
    FarmRunGameplayCapability,
    FarmRunLimits,
    FarmRunState,
    FarmRunStopReason,
    MatchResult,
)
from pokiguard_v2.state import CombatSessionKey
from pokiguard_v2.technical_recovery import (
    FailedSessionEvidence,
    RecoveredOpeningEvidence,
    RecoveryInputDomain,
    TechnicalRecoveryCoordinator,
    TechnicalRecoveryDispatcher,
    TechnicalRecoveryState,
)
from tools.farm_run import _stage_b1_action_proof


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


def enter(
    run: FarmRun,
    key: CombatSessionKey,
    *,
    test_only_recovery: bool = False,
    opening_evidence: OpeningEvidence | None = None,
) -> None:
    assert run.target_resolved()
    capability = FarmRunEntryCapability(run)
    permit = capability.reserve(foreground=True)
    assert permit is not None
    assert capability.complete(permit, sent=True, detail="Start:SENT")
    assert run.accept_session(key)
    assert run.accept_opening(
        opening_evidence or opening(key),
        test_only_recovery=test_only_recovery,
    )


def start_run(limits: FarmRunLimits | None = None) -> FarmRun:
    run = FarmRun(FarmTarget(boss_id="1289", boss_name="Starburst"), limits=limits)
    assert run.observe_initial_lobby(BossLobbyState.BOSS_LOBBY)
    return run


def finish_normal(run: FarmRun, result: MatchResult = MatchResult.WIN) -> None:
    assert run.normal_combat_ended(result)
    assert run.observe_postmatch()
    assert run.observe_return_lobby(BossLobbyState.BOSS_LOBBY)


def complete_recovery_coordinator(
    old: CombatSessionKey, new: CombatSessionKey
) -> TechnicalRecoveryCoordinator:
    coordinator = TechnicalRecoveryCoordinator(max_technical_recoveries=1)
    failed = FailedSessionEvidence(
        session_key=old,
        match_id=old.match_id,
        board_instance=old.board_instance,
        lifecycle_epoch=old.lifecycle_epoch,
        turn=7,
        srv_seq=4,
        board_hash="a" * 64,
    )
    assert TechnicalRecoveryDispatcher(coordinator).arm_test_only_evidence(failed)
    assert coordinator.exit_control_ready(locator_proof="offline Exit")
    permit = coordinator.reserve_exit(
        foreground=True, same_session=True, lifecycle_active=True
    )
    assert permit is not None
    assert coordinator.complete_input(permit, sent=True, detail="Exit:SENT")
    assert coordinator.confirm_modal_ready(locator_proof="offline confirm")
    permit = coordinator.reserve_confirm(foreground=True, context_valid=True)
    assert permit is not None
    assert coordinator.complete_input(permit, sent=True, detail="Confirm:SENT")
    assert coordinator.observe_local_lifecycle(CombatLifecycleState.LOBBY)
    assert coordinator.observe_boss_lobby(exact_boss_lobby=True)
    assert coordinator.clear_old_session(
        provider_session_none=True,
        pending_action_none=True,
        desync_old_session_ended=True,
    )
    assert coordinator.resolve_target(
        resolved=True,
        available=True,
        selected=True,
        exact_identity=True,
        target_id="1289",
        target_name="Starburst",
    )
    assert coordinator.reentry_ready(proof="offline exact target")
    permit = coordinator.reserve_reentry(foreground=True)
    assert permit is not None
    assert coordinator.complete_input(permit, sent=True, detail="Reentry:SENT")
    assert coordinator.accept_new_session(new)
    recovered = RecoveredOpeningEvidence(
        session=new,
        match_id=new.match_id,
        board_hash="b" * 64,
        srv_seq=1,
        complete_cells=64,
        unique_coordinates=64,
        source=SOURCE,
        first_local_turn=True,
        local_move_sequence=0,
        stable_confirmations=3,
    )
    assert coordinator.accept_opening(recovered)
    return coordinator


class FarmRunBoundaryTests(unittest.TestCase):
    def test_invalid_start_is_zero_input(self) -> None:
        run = FarmRun(FarmTarget(boss_id="1289"))
        self.assertFalse(run.observe_initial_lobby(BossLobbyState.ACTIVE_COMBAT))
        snapshot = run.snapshot()
        self.assertEqual(snapshot.stop_reason, FarmRunStopReason.FARM_START_STATE_INVALID)
        self.assertEqual(snapshot.input_records, ())

    def test_target_three_stops_at_lobby_without_entry_four(self) -> None:
        run = start_run(FarmRunLimits(3, 1, 5))
        for index in range(1, 4):
            enter(run, session(index))
            finish_normal(run, MatchResult.WIN if index != 2 else MatchResult.LOSS)
        snapshot = run.snapshot()
        self.assertEqual(snapshot.state, FarmRunState.FARM_RUN_COMPLETE)
        self.assertEqual(snapshot.stop_reason, FarmRunStopReason.FARM_TARGET_COMPLETED)
        self.assertEqual(snapshot.match_attempts, 3)
        self.assertEqual(snapshot.completed_matches, 3)
        self.assertEqual(snapshot.wins, 2)
        self.assertEqual(snapshot.losses, 1)
        self.assertEqual(snapshot.total_lobby_inputs, 3)
        self.assertFalse(run.target_resolved())
        self.assertEqual(run.snapshot().total_lobby_inputs, 3)

    def test_session_and_match_id_must_both_be_unique(self) -> None:
        run = start_run()
        first = session(1)
        enter(run, first)
        finish_normal(run)
        self.assertTrue(run.target_resolved())
        capability = FarmRunEntryCapability(run)
        permit = capability.reserve(foreground=True)
        self.assertIsNotNone(permit)
        self.assertTrue(capability.complete(permit, sent=True))  # type: ignore[arg-type]
        reused_match = CombatSessionKey(2, 0x999999, first.match_id)
        self.assertFalse(run.accept_session(reused_match))
        self.assertEqual(run.snapshot().stop_reason, FarmRunStopReason.SESSION_REUSE_AMBIGUOUS)

    def test_match_attempt_limit_blocks_entry_before_input(self) -> None:
        run = start_run(FarmRunLimits(1, 0, 1))
        enter(run, session(1))
        # A technical abort cannot recover because both recovery and attempt
        # budgets are already exhausted.
        self.assertFalse(run.technical_failure("SEQUENCE_DESYNC"))
        snapshot = run.snapshot()
        self.assertEqual(snapshot.match_attempts, 1)
        self.assertIn(
            snapshot.stop_reason,
            {FarmRunStopReason.RECOVERY_LIMIT_REACHED, FarmRunStopReason.MATCH_ATTEMPT_LIMIT_REACHED},
        )
        self.assertEqual(snapshot.total_lobby_inputs, 1)

    def test_nontechnical_safe_stop_never_enters_recovery(self) -> None:
        run = start_run()
        enter(run, session(1))
        self.assertFalse(run.technical_failure("POLICY_NO_SAFE_MOVE"))
        self.assertEqual(run.snapshot().technical_aborts, 0)
        self.assertEqual(run.snapshot().technical_recoveries, 0)
        self.assertEqual(run.snapshot().stop_reason, FarmRunStopReason.COMBAT_SAFE_STOP)

    def test_pass_is_zero_windows_input(self) -> None:
        run = start_run()
        key = session(1)
        enter(run, key)
        capability = FarmRunGameplayCapability(run, key)
        permit = capability.reserve(action="PASS", session=key, foreground=True)
        self.assertIsNotNone(permit)
        self.assertTrue(capability.complete(permit, sent=False, detail="authoritative wait"))  # type: ignore[arg-type]
        self.assertEqual(run.snapshot().total_gameplay_inputs, 0)

    def test_input_after_terminal_stop_is_denied_and_counted(self) -> None:
        run = start_run(FarmRunLimits(1, 0, 1))
        key = session(1)
        enter(run, key)
        finish_normal(run)
        self.assertEqual(run.state, FarmRunState.FARM_RUN_COMPLETE)
        self.assertIsNone(
            run.reserve_gameplay(FarmInputDomain.GAMEPLAY_SWAP, key, foreground=True)
        )
        self.assertEqual(run.snapshot().safety.input_after_farm_stop, 1)


class RecoveryResumeTests(unittest.TestCase):
    def _recovery_resume(self, reason: str) -> FarmRun:
        run = start_run(FarmRunLimits(3, 1, 5))
        old, new = session(1), session(2)
        enter(run, old)
        self.assertTrue(run.technical_failure(reason))
        self.assertTrue(run.begin_recovery())
        coordinator = complete_recovery_coordinator(old, new)
        self.assertEqual(coordinator.state, TechnicalRecoveryState.RECOVERY_COMPLETE)
        self.assertTrue(run.record_successful_recovery(coordinator.snapshot().input_records))
        self.assertTrue(run.accept_session(new, recovered=True))
        self.assertTrue(run.accept_opening(opening(new, hash_digit="b"), recovered=True))
        self.assertTrue(run.resume_recovered_gameplay(old_state_leak_free=True))
        capability = FarmRunGameplayCapability(run, new)
        permit = capability.reserve(action="SWAP", session=new, foreground=True)
        self.assertIsNotNone(permit)
        self.assertTrue(capability.complete(permit, sent=True, detail="fresh SWAP:SENT"))  # type: ignore[arg-type]
        return run

    def test_sequence_desync_recovery_resumes_fresh_gameplay(self) -> None:
        run = self._recovery_resume("SEQUENCE_DESYNC")
        snapshot = run.snapshot()
        self.assertEqual(snapshot.match_attempts, 2)
        self.assertEqual(snapshot.completed_matches, 0)
        self.assertEqual(snapshot.technical_aborts, 1)
        self.assertEqual(snapshot.technical_recoveries, 1)
        self.assertEqual(snapshot.attempts[0].result, MatchResult.TECHNICAL_ABORT)
        self.assertTrue(snapshot.attempts[1].recovered)
        self.assertEqual(snapshot.total_recovery_inputs, 3)
        self.assertEqual(snapshot.total_gameplay_inputs, 1)
        self.assertEqual(snapshot.safety.nonzero(), {})

    def test_dead_board_fixture_uses_same_recovery_resume_path(self) -> None:
        run = self._recovery_resume("DEAD_BOARD_NO_REFRESH")
        self.assertEqual(run.snapshot().attempts[0].dead_board, 1)
        self.assertEqual(run.snapshot().technical_recoveries, 1)

    def test_second_failure_stops_before_second_exit(self) -> None:
        run = self._recovery_resume("SEQUENCE_DESYNC")
        self.assertFalse(run.technical_failure("DEAD_BOARD_NO_REFRESH"))
        snapshot = run.snapshot()
        self.assertEqual(snapshot.stop_reason, FarmRunStopReason.RECOVERY_LIMIT_REACHED)
        self.assertEqual(snapshot.technical_aborts, 2)
        self.assertEqual(snapshot.technical_recoveries, 1)
        self.assertEqual(snapshot.total_recovery_inputs, 3)

    def test_two_bounded_recoveries_validate_each_invocation(self) -> None:
        run = start_run(FarmRunLimits(3, 2, 5))
        first, second, third = session(1), session(2), session(3)
        enter(run, first)

        self.assertTrue(run.technical_failure("DEAD_BOARD_NO_REFRESH"))
        self.assertTrue(run.begin_recovery())
        recovery_one = complete_recovery_coordinator(first, second)
        self.assertTrue(
            run.record_successful_recovery(
                recovery_one.snapshot().input_records
            )
        )
        self.assertTrue(run.accept_session(second, recovered=True))
        self.assertTrue(
            run.accept_opening(opening(second, hash_digit="b"), recovered=True)
        )
        self.assertTrue(run.resume_recovered_gameplay(old_state_leak_free=True))

        self.assertTrue(run.technical_failure("DEAD_BOARD_NO_REFRESH"))
        self.assertTrue(run.begin_recovery())
        recovery_two = complete_recovery_coordinator(second, third)
        self.assertTrue(
            run.record_successful_recovery(
                recovery_two.snapshot().input_records
            )
        )
        self.assertTrue(run.accept_session(third, recovered=True))
        self.assertTrue(
            run.accept_opening(opening(third, hash_digit="c"), recovered=True)
        )
        self.assertTrue(run.resume_recovered_gameplay(old_state_leak_free=True))

        snapshot = run.snapshot()
        self.assertEqual(snapshot.technical_aborts, 2)
        self.assertEqual(snapshot.technical_recoveries, 2)
        self.assertEqual(snapshot.total_recovery_inputs, 6)
        self.assertEqual(snapshot.safety.nonzero(), {})

    def test_failed_old_state_cleanliness_blocks_gameplay(self) -> None:
        run = start_run()
        old, new = session(1), session(2)
        enter(run, old)
        self.assertTrue(run.technical_failure("SEQUENCE_DESYNC"))
        self.assertTrue(run.begin_recovery())
        coordinator = complete_recovery_coordinator(old, new)
        self.assertTrue(run.record_successful_recovery(coordinator.snapshot().input_records))
        self.assertTrue(run.accept_session(new, recovered=True))
        self.assertTrue(run.accept_opening(opening(new, hash_digit="b"), recovered=True))
        self.assertFalse(run.resume_recovered_gameplay(old_state_leak_free=False))
        self.assertEqual(run.snapshot().stop_reason, FarmRunStopReason.RECOVERY_FAILED)

    def test_stage_b1_test_trigger_does_not_claim_production_failure(self) -> None:
        run = start_run()
        enter(run, session(1), test_only_recovery=True)
        self.assertTrue(run.test_only_recovery_trigger())
        event = run.snapshot().events[-1]
        self.assertEqual(event.detail["reason"], "TEST_ONLY")
        self.assertTrue(event.detail["testOnly"])
        self.assertFalse(event.detail["naturallyOccurringTechnicalFailure"])
        self.assertEqual(run.snapshot().attempts[0].sequence_desync, 0)
        self.assertEqual(run.snapshot().attempts[0].dead_board, 0)

    def test_stage_b1_timer_floor_allows_only_immediate_test_recovery(self) -> None:
        run = start_run()
        key = session(1)
        deadline_opening = replace(opening(key), timer_safe=False)
        enter(
            run,
            key,
            test_only_recovery=True,
            opening_evidence=deadline_opening,
        )
        capability = FarmRunGameplayCapability(run, key)
        self.assertIsNone(
            capability.reserve(action="SWAP", session=key, foreground=True)
        )
        self.assertEqual(
            run.snapshot().stop_reason,
            FarmRunStopReason.GAMEPLAY_CAPABILITY_DENIED,
        )

        retry = start_run()
        enter(
            retry,
            key,
            test_only_recovery=True,
            opening_evidence=deadline_opening,
        )
        self.assertTrue(retry.test_only_recovery_trigger())
        self.assertEqual(retry.state, FarmRunState.RECOVERY_PENDING)

    def test_b1_proof_requires_one_accepted_consuming_terminal(self) -> None:
        records = [
            {"event": "action_sent", "action": "EVOLVE", "identity": {"id": 1}},
            {"event": "action_terminal", "result": "EVOLVE_FAILED"},
            {"event": "action_sent", "action": "SWAP", "identity": {"id": 2}},
            {"event": "action_terminal", "result": "SWAP_ACKNOWLEDGED"},
            {
                "event": "auto_controller_summary",
                "stopReason": "AUTO_STOP_AFTER_ACK",
                "turnConsumingActions": 1,
                "pending": None,
                "safetyTelemetry": {
                    "duplicate": 0,
                    "wrongTurn": 0,
                    "bossTurnInput": 0,
                    "staleAction": 0,
                },
            },
        ]
        accepted, proof = _stage_b1_action_proof(records)
        self.assertTrue(accepted)
        self.assertEqual(proof["firstDecision"]["action"], "EVOLVE")
        self.assertEqual(
            proof["firstConsumingTerminal"]["result"], "SWAP_ACKNOWLEDGED"
        )

        bad = [dict(item) for item in records]
        bad[-1] = {**bad[-1], "turnConsumingActions": 2}
        self.assertFalse(_stage_b1_action_proof(bad)[0])

    def test_artifact_tree_contains_required_paths(self) -> None:
        run = start_run()
        with tempfile.TemporaryDirectory() as temporary:
            writer = FarmRunArtifactWriter.create(Path(temporary), run.farm_run_id)
            writer.event("stage_a", actualUiInputs=0)
            writer.finalize(run, stage="A")
            self.assertTrue((writer.directory / "run.json").is_file())
            self.assertTrue((writer.directory / "events.jsonl").is_file())
            self.assertTrue((writer.directory / "matches").is_dir())
            self.assertTrue((writer.directory / "recoveries").is_dir())


if __name__ == "__main__":
    unittest.main()
