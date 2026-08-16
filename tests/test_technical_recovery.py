from __future__ import annotations

from dataclasses import replace
import json
from pathlib import Path
import tempfile
import unittest
import sys
from types import SimpleNamespace


ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = ROOT / "src"
for import_path in (str(ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.board_diagnostics import analyze_game_state, diagnostic_board_hash
from pokiguard_v2.combat_lifecycle import CombatLifecycleState
from pokiguard_v2.sequence_desync import SequenceDesyncSource, SequenceDesyncState
from pokiguard_v2.state import BattleState, CombatSessionKey, GamePhase, GameState
from pokiguard_v2.technical_recovery import (
    FailedSessionEvidence,
    RecoveredOpeningEvidence,
    RecoveryArtifactWriter,
    RecoveryInputDomain,
    RecoveryReentryCapability,
    TechnicalRecoveryCoordinator,
    TechnicalRecoveryDispatcher,
    TechnicalRecoveryResult,
    TechnicalRecoveryState,
)
from tests.test_board_simulator import cyclic_board, fixture_board
from tools.basic_auto_bot import SharedCombatRuntime, _dispatch_technical_recovery
from tools.replay_sequence_desync import replay
from tools.technical_recovery import (
    _failed_session_still_active,
    _final_live_invariants,
    _recovered_opening_from_entry,
)


MATCH_START = "ChatMessageDTO.MATCH_START.matchPayload.board"


def active_state(
    *,
    session: CombatSessionKey | None = None,
    board=None,
    board_hash: str | None = None,
) -> GameState:
    session = session or CombatSessionKey(1, 0x20000000000, "match-old")
    board = board or fixture_board()
    return GameState(
        GamePhase.COMBAT,
        "2026-08-15T00:00:00.000Z",
        board=board,
        battle=BattleState(
            combat_lifecycle=CombatLifecycleState.ACTIVE,
            board_instance=session.board_instance,
            srv_seq=41,
            turn_number=17,
            current_turn_player="happi",
            stable=True,
            board_hash=board_hash or diagnostic_board_hash(board),
            sources=("WsCombatBatch.board",),
            session_key=session,
            match_id=session.match_id,
            acknowledged=True,
            latest=True,
            is_board_ready=True,
            is_cascade_running=False,
            is_local_turn=True,
            client_move_allowed=True,
            turn_duration_seconds=14,
            turn_time_remaining_seconds=12,
            turn_timer_source="fixture",
            local_move_sequence=8,
        ),
    )


def opening(session: CombatSessionKey, board_hash: str = "b" * 64) -> RecoveredOpeningEvidence:
    return RecoveredOpeningEvidence(
        session=session,
        match_id=session.match_id,
        board_hash=board_hash,
        srv_seq=3,
        complete_cells=64,
        unique_coordinates=64,
        source=MATCH_START,
        first_local_turn=True,
        local_move_sequence=0,
        stable_confirmations=2,
    )


def arm_test_only(coordinator: TechnicalRecoveryCoordinator, state: GameState | None = None) -> GameState:
    state = state or active_state()
    dispatched = TechnicalRecoveryDispatcher(coordinator).arm_test_only(state)
    if not dispatched:
        raise AssertionError("test-only recovery did not arm")
    return state


def advance_to_target(coordinator: TechnicalRecoveryCoordinator) -> None:
    coordinator.exit_control_ready(locator_proof="stable-exit")
    permit = coordinator.reserve_exit(
        foreground=True,
        same_session=True,
        lifecycle_active=True,
    )
    assert permit is not None
    coordinator.complete_input(permit, sent=True, detail="EXIT:SENT")
    coordinator.confirm_modal_ready(locator_proof="stable-modal")
    permit = coordinator.reserve_confirm(foreground=True, context_valid=True)
    assert permit is not None
    coordinator.complete_input(permit, sent=True, detail="CONFIRM:SENT")
    coordinator.observe_local_lifecycle(CombatLifecycleState.POSTMATCH)
    coordinator.observe_boss_lobby(exact_boss_lobby=True)
    coordinator.clear_old_session(
        provider_session_none=True,
        pending_action_none=True,
        desync_old_session_ended=True,
    )
    coordinator.resolve_target(
        resolved=True,
        available=True,
        selected=True,
        exact_identity=True,
        target_id="1289",
        target_name="Starburst",
    )


class LiveRecoveryPreflightTests(unittest.TestCase):
    def test_recovered_opening_uses_exact_hardened_entry_acceptance(self) -> None:
        session = CombatSessionKey(2, 0x20000001000, "match-new")
        result = {
            "status": "PASS",
            "session": {
                "lifecycle_epoch": 2,
                "board_instance": 0x20000001000,
                "match_id": "match-new",
            },
            "matchId": "match-new",
            "boardHash": "a" * 64,
            "srvSeq": 3,
            "openingCells": 64,
            "openingUniqueCoordinates": 64,
            "openingSource": MATCH_START,
            "firstLocalTurn": True,
            "localMoveSequence": 0,
            "stableConfirmations": 2,
            "openingProductionReady": True,
            "openingGemTypesValid": True,
            "openingMultipliersValid": True,
            "openingFreshDto": True,
            "turnTimeRemainingSeconds": 7,
        }
        opening = _recovered_opening_from_entry(result, session)
        self.assertIsNotNone(opening)
        assert opening is not None
        self.assertEqual(opening.session, session)
        self.assertTrue(opening.timer_safe)

        stale = dict(result)
        stale["session"] = {**result["session"], "match_id": "match-stale"}
        self.assertIsNone(_recovered_opening_from_entry(stale, session))

        incomplete = dict(result)
        incomplete.pop("openingUniqueCoordinates")
        self.assertIsNone(_recovered_opening_from_entry(incomplete, session))

    def test_exact_per_poll_session_proves_active_early_return(self) -> None:
        state = active_state()
        session = state.battle.session_key
        assert session is not None
        failed = FailedSessionEvidence(
            session,
            state.battle.match_id or "",
            state.battle.board_instance,
            session.lifecycle_epoch,
            state.battle.turn_number,
            state.battle.srv_seq,
            state.battle.board_hash,
        )
        poll = SimpleNamespace(
            combat_lifecycle=None,
            state=None,
            session_key=session,
        )
        self.assertTrue(_failed_session_still_active(poll, failed))

        stale = replace(
            session,
            lifecycle_epoch=session.lifecycle_epoch + 1,
        )
        self.assertFalse(
            _failed_session_still_active(
                SimpleNamespace(
                    combat_lifecycle=None,
                    state=None,
                    session_key=stale,
                ),
                failed,
            )
        )

    def test_exact_published_state_proves_active_session_without_duplicate_lifecycle_poll(self) -> None:
        state = active_state()
        session = state.battle.session_key
        assert session is not None
        failed = FailedSessionEvidence(
            session,
            state.battle.match_id or "",
            state.battle.board_instance,
            session.lifecycle_epoch,
            state.battle.turn_number,
            state.battle.srv_seq,
            state.battle.board_hash,
        )
        poll = SimpleNamespace(combat_lifecycle=None, state=state)
        self.assertTrue(_failed_session_still_active(poll, failed))

        changed_failed = replace(failed, match_id="different-match")
        self.assertFalse(
            _failed_session_still_active(
                SimpleNamespace(combat_lifecycle=None, state=state),
                changed_failed,
            )
        )

    def test_non_active_published_state_never_proves_exit_preflight(self) -> None:
        state = active_state()
        session = state.battle.session_key
        assert session is not None
        failed = FailedSessionEvidence(
            session,
            state.battle.match_id or "",
            state.battle.board_instance,
            session.lifecycle_epoch,
            state.battle.turn_number,
            state.battle.srv_seq,
            state.battle.board_hash,
        )
        postmatch = SimpleNamespace(phase=GamePhase.UNKNOWN, battle=state.battle)
        self.assertFalse(
            _failed_session_still_active(
                SimpleNamespace(combat_lifecycle=None, state=postmatch),
                failed,
            )
        )


class TechnicalRecoveryCoordinatorTests(unittest.TestCase):
    def test_happy_path_hard_stops_at_fresh_opening(self) -> None:
        coordinator = TechnicalRecoveryCoordinator()
        old = arm_test_only(coordinator)
        advance_to_target(coordinator)
        capability = RecoveryReentryCapability(coordinator)
        permit = capability.reserve(foreground=True)
        self.assertIsNotNone(permit)
        self.assertTrue(capability.complete(permit, sent=True, detail="ENTRY:SENT"))  # type: ignore[arg-type]
        new = CombatSessionKey(2, 0x20000001000, "match-new")
        self.assertTrue(coordinator.accept_new_session(new))
        self.assertTrue(coordinator.accept_opening(opening(new)))

        accepted, reason = _final_live_invariants(coordinator)
        self.assertTrue(accepted, reason)
        snapshot = coordinator.snapshot()
        self.assertEqual(snapshot.state, TechnicalRecoveryState.RECOVERY_COMPLETE)
        self.assertTrue(snapshot.gameplay_locked)
        self.assertNotEqual(snapshot.trigger.failed_session.match_id, new.match_id)  # type: ignore[union-attr]
        self.assertNotEqual(snapshot.trigger.failed_session.board_hash, "b" * 64)  # type: ignore[union-attr]
        counts = {
            domain: sum(record.sent and record.domain is domain for record in snapshot.input_records)
            for domain in RecoveryInputDomain
        }
        self.assertEqual(counts[RecoveryInputDomain.RECOVERY_EXIT], 1)
        self.assertEqual(counts[RecoveryInputDomain.RECOVERY_CONFIRM], 1)
        self.assertEqual(counts[RecoveryInputDomain.RECOVERY_REENTRY], 1)
        self.assertEqual(counts[RecoveryInputDomain.RECOVERY_TARGET_SELECT], 0)
        self.assertFalse(coordinator.record_gameplay_boundary(sent=False, recovered_combat=True))

    def test_foreground_loss_blocks_each_input_boundary(self) -> None:
        coordinator = TechnicalRecoveryCoordinator()
        arm_test_only(coordinator)
        coordinator.exit_control_ready(locator_proof="stable-exit")
        self.assertIsNone(
            coordinator.reserve_exit(
                foreground=False,
                same_session=True,
                lifecycle_active=True,
            )
        )
        self.assertEqual(
            coordinator.snapshot().result,
            TechnicalRecoveryResult.RECOVERY_BLOCKED_FOREGROUND,
        )
        self.assertEqual(coordinator.snapshot().input_records, ())

    def test_duplicate_trigger_does_not_create_second_attempt(self) -> None:
        coordinator = TechnicalRecoveryCoordinator()
        state = arm_test_only(coordinator)
        dispatcher = TechnicalRecoveryDispatcher(coordinator)
        self.assertFalse(dispatcher.arm_test_only(state))
        self.assertEqual(coordinator.snapshot().safety.recovery_attempts, 1)
        self.assertEqual(coordinator.state, TechnicalRecoveryState.RESOLVE_EXIT_CONTROL)

    def test_test_only_can_arm_from_hardened_lifecycle_identity_without_board(self) -> None:
        state = active_state()
        failed = FailedSessionEvidence(
            session_key=state.battle.session_key,
            match_id=state.battle.match_id or "",
            board_instance=state.battle.board_instance,
            lifecycle_epoch=state.battle.session_key.lifecycle_epoch,  # type: ignore[union-attr]
            turn=state.battle.turn_number,
            srv_seq=state.battle.srv_seq,
            board_hash=None,
        )
        coordinator = TechnicalRecoveryCoordinator()
        self.assertTrue(
            TechnicalRecoveryDispatcher(coordinator).arm_test_only_evidence(failed)
        )
        self.assertTrue(coordinator.gameplay_locked)
        self.assertIsNone(coordinator.trigger.reason)  # type: ignore[union-attr]
        self.assertEqual(coordinator.trigger.source.value, "TEST_ONLY")  # type: ignore[union-attr]

    def test_second_distinct_trigger_reaches_hard_recovery_limit(self) -> None:
        coordinator = TechnicalRecoveryCoordinator()
        state = arm_test_only(coordinator)
        changed = replace(
            state,
            battle=replace(state.battle, turn_number=(state.battle.turn_number or 0) + 2),
        )
        self.assertFalse(TechnicalRecoveryDispatcher(coordinator).arm_test_only(changed))
        self.assertEqual(coordinator.snapshot().safety.recovery_attempts, 1)
        self.assertEqual(coordinator.state, TechnicalRecoveryState.RECOVERY_LIMIT_REACHED)

    def test_same_production_signal_is_deduplicated_without_second_exit(self) -> None:
        state = active_state()
        desync = SequenceDesyncState(
            detected=True,
            source=SequenceDesyncSource.FORCE_RESYNC,
            first_seen_at=state.timestamp,
            last_seen_at=state.timestamp,
            session_key=state.battle.session_key,
            match_id=state.battle.match_id,
            turn=state.battle.turn_number,
            srv_seq=state.battle.srv_seq,
            terminal_for_session=True,
        )
        coordinator = TechnicalRecoveryCoordinator()
        dispatcher = TechnicalRecoveryDispatcher(coordinator)
        self.assertTrue(dispatcher.dispatch_sequence_desync(desync, state=state))
        self.assertFalse(dispatcher.dispatch_sequence_desync(desync, state=state))
        self.assertEqual(coordinator.snapshot().safety.recovery_attempts, 1)
        self.assertEqual(coordinator.state, TechnicalRecoveryState.RESOLVE_EXIT_CONTROL)

    def test_duplicate_exit_confirm_and_reentry_are_counted_and_blocked(self) -> None:
        coordinator = TechnicalRecoveryCoordinator()
        arm_test_only(coordinator)
        coordinator.exit_control_ready(locator_proof="exit")
        permit = coordinator.reserve_exit(
            foreground=True, same_session=True, lifecycle_active=True
        )
        assert permit is not None
        coordinator.complete_input(permit, sent=True, detail="sent")
        self.assertIsNone(
            coordinator.reserve_exit(
                foreground=True, same_session=True, lifecycle_active=True
            )
        )
        self.assertEqual(coordinator.snapshot().safety.duplicate_exit, 1)

        coordinator = TechnicalRecoveryCoordinator()
        arm_test_only(coordinator)
        coordinator.exit_control_ready(locator_proof="exit")
        permit = coordinator.reserve_exit(
            foreground=True, same_session=True, lifecycle_active=True
        )
        assert permit is not None
        coordinator.complete_input(permit, sent=True, detail="sent")
        coordinator.confirm_modal_ready(locator_proof="modal")
        permit = coordinator.reserve_confirm(foreground=True, context_valid=True)
        assert permit is not None
        coordinator.complete_input(permit, sent=True, detail="sent")
        self.assertIsNone(coordinator.reserve_confirm(foreground=True, context_valid=True))
        self.assertEqual(coordinator.snapshot().safety.duplicate_confirm, 1)

        coordinator = TechnicalRecoveryCoordinator()
        arm_test_only(coordinator)
        advance_to_target(coordinator)
        coordinator.reentry_ready(proof="ready")
        permit = coordinator.reserve_reentry(foreground=True)
        assert permit is not None
        coordinator.complete_input(permit, sent=True, detail="sent")
        self.assertIsNone(coordinator.reserve_reentry(foreground=True))
        self.assertEqual(coordinator.snapshot().safety.duplicate_reentry, 1)

    def test_failure_result_paths_are_explicit(self) -> None:
        cases = (
            TechnicalRecoveryResult.RECOVERY_EXIT_LOCATOR_FAILED,
            TechnicalRecoveryResult.RECOVERY_CONFIRM_FAILED,
            TechnicalRecoveryResult.RECOVERY_LOBBY_TIMEOUT,
            TechnicalRecoveryResult.RECOVERY_TARGET_FAILED,
            TechnicalRecoveryResult.RECOVERY_REENTRY_FAILED,
            TechnicalRecoveryResult.RECOVERY_NEW_SESSION_FAILED,
            TechnicalRecoveryResult.RECOVERY_OPENING_FAILED,
        )
        for result in cases:
            with self.subTest(result=result):
                coordinator = TechnicalRecoveryCoordinator()
                arm_test_only(coordinator)
                coordinator.block(result, "test")
                self.assertEqual(coordinator.state, TechnicalRecoveryState.RECOVERY_BLOCKED)
                self.assertEqual(coordinator.snapshot().result, result)

    def test_same_match_or_board_or_epoch_is_stale_session_confusion(self) -> None:
        old = CombatSessionKey(4, 0x20000000000, "match-old")
        for new in (
            CombatSessionKey(5, 0x20000001000, "match-old"),
            CombatSessionKey(5, old.board_instance, "match-new"),
            CombatSessionKey(old.lifecycle_epoch, 0x20000001000, "match-new"),
        ):
            with self.subTest(new=new):
                coordinator = TechnicalRecoveryCoordinator()
                arm_test_only(coordinator, active_state(session=old))
                advance_to_target(coordinator)
                capability = RecoveryReentryCapability(coordinator)
                permit = capability.reserve(foreground=True)
                assert permit is not None
                capability.complete(permit, sent=True)
                self.assertFalse(coordinator.accept_new_session(new))
                self.assertEqual(coordinator.snapshot().safety.stale_session_confusion, 1)

    def test_opening_rejects_reused_hash_and_each_core_invariant(self) -> None:
        old_hash = "a" * 64
        cases = {
            "reused_hash": {"board_hash": old_hash},
            "non_hex_hash": {"board_hash": "z" * 64},
            "cells": {"complete_cells": 63},
            "coordinates": {"unique_coordinates": 63},
            "source": {"source": "UNKNOWN"},
            "first_turn": {"first_local_turn": False},
            "local_seq": {"local_move_sequence": 1},
            "stable": {"stable_confirmations": 1},
            "production": {"production_ready": False},
            "gem_types": {"gem_types_valid": False},
            "multipliers": {"multipliers_valid": False},
            "fresh_dto": {"fresh_dto": False},
            "timer": {"timer_safe": False},
        }
        for name, changes in cases.items():
            with self.subTest(name=name):
                coordinator = TechnicalRecoveryCoordinator()
                arm_test_only(coordinator, active_state(board_hash=old_hash))
                advance_to_target(coordinator)
                capability = RecoveryReentryCapability(coordinator)
                permit = capability.reserve(foreground=True)
                assert permit is not None
                capability.complete(permit, sent=True)
                new = CombatSessionKey(2, 0x20000001000, "match-new")
                self.assertTrue(coordinator.accept_new_session(new))
                self.assertFalse(coordinator.accept_opening(replace(opening(new), **changes)))

    def test_gameplay_is_absolutely_locked_and_f9_clears_pending(self) -> None:
        coordinator = TechnicalRecoveryCoordinator()
        arm_test_only(coordinator)
        self.assertFalse(coordinator.record_gameplay_boundary(sent=False))
        coordinator.exit_control_ready(locator_proof="exit")
        self.assertIsNotNone(
            coordinator.reserve_exit(
                foreground=True, same_session=True, lifecycle_active=True
            )
        )
        coordinator.emergency_stop()
        self.assertEqual(
            coordinator.snapshot().result,
            TechnicalRecoveryResult.RECOVERY_ABORTED_USER_STOP,
        )
        self.assertEqual(coordinator.snapshot().input_records, ())
        self.assertFalse(coordinator.record_gameplay_boundary(sent=False))


class TechnicalRecoveryDispatchTests(unittest.TestCase):
    def test_captured_sequence_fixture_dispatches_same_coordinator_path(self) -> None:
        tracker = replay(ROOT / "reference" / "sequence_desync_m714b231e.jsonl")
        coordinator = TechnicalRecoveryCoordinator()
        self.assertTrue(
            TechnicalRecoveryDispatcher(coordinator).dispatch_sequence_desync(
                tracker.state,
                evidence_source="captured replay",
            )
        )
        self.assertEqual(coordinator.state, TechnicalRecoveryState.RESOLVE_EXIT_CONTROL)
        self.assertTrue(coordinator.gameplay_locked)

    def test_exact_dead_board_dispatches_but_policy_no_safe_move_does_not(self) -> None:
        state = active_state(board=cyclic_board())
        analysis = analyze_game_state(state)
        self.assertEqual(analysis.legal_match_producing_moves, 0)
        self.assertTrue(analysis.dead_board)
        coordinator = TechnicalRecoveryCoordinator()
        dispatcher = TechnicalRecoveryDispatcher(coordinator)
        self.assertTrue(dispatcher.dispatch_dead_board(state, analysis))

        policy = TechnicalRecoveryCoordinator()
        policy_dispatch = TechnicalRecoveryDispatcher(policy)
        self.assertFalse(
            policy_dispatch.dispatch_policy_no_safe_move(
                legal_move_count=2,
                safe_move_count=0,
            )
        )
        self.assertEqual(policy.state, TechnicalRecoveryState.IDLE)

    def test_stale_dead_board_analysis_and_mismatched_desync_session_do_not_dispatch(self) -> None:
        state = active_state(board=cyclic_board())
        analysis = analyze_game_state(state)
        changed_state = replace(state, timestamp="2026-08-15T00:00:01.000Z")
        coordinator = TechnicalRecoveryCoordinator()
        self.assertFalse(
            TechnicalRecoveryDispatcher(coordinator).dispatch_dead_board(
                changed_state,
                analysis,
            )
        )
        self.assertEqual(coordinator.state, TechnicalRecoveryState.IDLE)

        desync = SequenceDesyncState(
            detected=True,
            source=SequenceDesyncSource.FORCE_RESYNC,
            first_seen_at=state.timestamp,
            last_seen_at=state.timestamp,
            session_key=CombatSessionKey(2, 0x20000001000, "match-old"),
            match_id=state.battle.match_id,
            turn=state.battle.turn_number,
            srv_seq=state.battle.srv_seq,
            terminal_for_session=True,
        )
        self.assertFalse(
            TechnicalRecoveryDispatcher(coordinator).dispatch_sequence_desync(
                desync,
                state=state,
            )
        )
        self.assertEqual(coordinator.state, TechnicalRecoveryState.IDLE)

    def test_basic_auto_production_hook_uses_the_same_dispatcher(self) -> None:
        state = active_state(board=cyclic_board())
        analysis = analyze_game_state(state)
        coordinator = TechnicalRecoveryCoordinator()
        dispatcher = TechnicalRecoveryDispatcher(coordinator)
        runtime = SharedCombatRuntime(
            None,
            None,  # type: ignore[arg-type]
            None,  # type: ignore[arg-type]
            None,
            None,  # type: ignore[arg-type]
            None,  # type: ignore[arg-type]
            technical_recovery_dispatcher=dispatcher,
        )
        self.assertTrue(
            _dispatch_technical_recovery(
                runtime,
                reason="DEAD_BOARD_NO_REFRESH",
                state=state,
                analysis=analysis,
            )
        )
        self.assertTrue(coordinator.gameplay_locked)
        self.assertFalse(
            _dispatch_technical_recovery(
                runtime,
                reason="POLICY_NO_SAFE_MOVE",
                state=state,
                analysis=analysis,
            )
        )

    def test_artifact_writer_has_required_json_and_event_files(self) -> None:
        coordinator = TechnicalRecoveryCoordinator()
        state = arm_test_only(coordinator)
        with tempfile.TemporaryDirectory() as directory:
            artifact = RecoveryArtifactWriter.create(Path(directory))
            artifact.write_failure(coordinator, state)
            artifact.event("trigger", inputCount=0)
            artifact.finalize(coordinator, stageResult="TEST")
            for name in (
                "recovery.json",
                "events.jsonl",
                "failure_state.json",
                "board.json",
            ):
                self.assertTrue((artifact.directory / name).is_file(), name)
            payload = json.loads(artifact.recovery_path.read_text(encoding="utf-8"))
            self.assertFalse(payload["memoryWrites"])
            self.assertFalse(payload["directGameCalls"])
            self.assertFalse(payload["networkManipulation"])


if __name__ == "__main__":
    unittest.main()
