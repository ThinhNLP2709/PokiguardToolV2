from __future__ import annotations

from dataclasses import replace
import json
from pathlib import Path
import tempfile
import unittest
from unittest import mock
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
from pokiguard_v2.state import (
    BattleState,
    CombatSessionKey,
    GameOwnedIdleStatus,
    GamePhase,
    GameState,
)
from pokiguard_v2.technical_recovery import (
    ACTIVE_COMBAT_PROGRESS_STALL_MIN_SAMPLES,
    ACTIVE_COMBAT_PROGRESS_STALL_SECONDS,
    ActiveCombatProgressStall,
    ActiveCombatProgressWatchdog,
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
    _guard_recovered_handoff,
    _recovery_lobby_ack_epoch_rejection,
    _recovered_handoff_rejection,
    _recovered_opening_from_entry,
    _usable_calibrated_exit,
    _wait_for_clean_recovery_lobby_ack_epoch,
)


MATCH_START = "ChatMessageDTO.MATCH_START.matchPayload.board"


class RecoveredHandoffGuardTests(unittest.TestCase):
    def test_live_exit_calibration_bypasses_temporal_locator_only_when_complete(self) -> None:
        accepted = SimpleNamespace(found=True, normalized_point=(0.03, 0.05))
        self.assertIs(_usable_calibrated_exit(accepted), accepted)
        self.assertIsNone(
            _usable_calibrated_exit(
                SimpleNamespace(found=False, normalized_point=(0.03, 0.05))
            )
        )
        self.assertIsNone(
            _usable_calibrated_exit(
                SimpleNamespace(found=True, normalized_point=None)
            )
        )

    def setUp(self) -> None:
        self.session = CombatSessionKey(8, 0x20000000000, "match-new")

    def opening_state(self) -> GameState:
        state = active_state(session=self.session)
        return replace(
            state,
            battle=replace(
                state.battle,
                srv_seq=3,
                turn_number=1,
                local_move_sequence=0,
                last_move_sequence=None,
            ),
        )

    def test_clean_pristine_opening_is_accepted(self) -> None:
        self.assertIsNone(
            _recovered_handoff_rejection(
                expected_session=self.session,
                current_session=self.session,
                highest_acked_sequence=None,
                state=self.opening_state(),
            )
        )

    def test_delayed_prior_match_ack_epoch_is_rejected(self) -> None:
        self.assertEqual(
            _recovered_handoff_rejection(
                expected_session=self.session,
                current_session=self.session,
                highest_acked_sequence=27,
                state=self.opening_state(),
            ),
            "RECOVERY_ACK_EPOCH_NOT_RESET",
        )

    def test_explicit_session_scoped_ack_isolation_accepts_pristine_opening(self) -> None:
        self.assertIsNone(
            _recovered_handoff_rejection(
                expected_session=self.session,
                current_session=self.session,
                highest_acked_sequence=53,
                state=self.opening_state(),
                recovery_ack_epoch_isolated=True,
            )
        )

    def test_guard_accepts_two_isolated_current_session_openings(self) -> None:
        state = self.opening_state()

        class Provider:
            current_session_key = self.session
            metrics = SimpleNamespace(highest_acked_sequence=53)
            scan_diagnostics = {"effectiveAckedSequence": None}

            @staticmethod
            def poll():
                return SimpleNamespace(state=state, reason="isolated_recovery_opening")

            @staticmethod
            def recovery_ack_epoch_isolated_for(session):
                return session == self.session

        ticks = iter((0.0, 0.1, 0.2, 0.3))
        with (
            mock.patch(
                "tools.technical_recovery.time.monotonic",
                side_effect=lambda: next(ticks),
            ),
            mock.patch("tools.technical_recovery.time.sleep"),
        ):
            accepted, evidence = _guard_recovered_handoff(
                Provider(),
                self.session,
                interval=0.02,
                duration=0.3,
            )

        self.assertTrue(accepted, evidence)
        self.assertEqual(evidence["cleanStateSamples"], 3)
        self.assertTrue(evidence["recoveryAckEpochIsolated"])
        self.assertEqual(evidence["highestAckedSequence"], 53)

    def test_guard_waits_for_stale_ack_gauge_to_clear_before_accepting(self) -> None:
        state = self.opening_state()
        samples = iter(
            (
                (state, 27),
                (state, None),
                (state, None),
            )
        )

        class Provider:
            current_session_key = self.session
            metrics = SimpleNamespace(highest_acked_sequence=27)

            def poll(inner_self):
                current_state, ack = next(samples)
                inner_self.metrics.highest_acked_sequence = ack
                return SimpleNamespace(state=current_state, reason="fixture")

        ticks = iter((0.0, 0.1, 0.2, 0.3))
        with (
                mock.patch(
                "tools.technical_recovery.time.monotonic",
                side_effect=lambda: next(ticks),
            ),
            unittest.mock.patch("tools.technical_recovery.time.sleep"),
        ):
            accepted, evidence = _guard_recovered_handoff(
                Provider(),
                self.session,
                interval=0.02,
                duration=0.3,
            )

        self.assertTrue(accepted, evidence)
        self.assertEqual(evidence["polls"], 3)
        self.assertEqual(evidence["cleanStateSamples"], 2)
        self.assertIsNone(evidence["highestAckedSequence"])

    def test_guard_persistent_dirty_ack_waits_bounded_window_then_rejects(self) -> None:
        state = self.opening_state()

        class Provider:
            current_session_key = self.session
            metrics = SimpleNamespace(highest_acked_sequence=27)

            @staticmethod
            def poll():
                return SimpleNamespace(state=state, reason="fixture")

        ticks = iter((0.0, 0.1, 0.2, 0.3))
        with (
            mock.patch(
                "tools.technical_recovery.time.monotonic",
                side_effect=lambda: next(ticks),
            ),
            unittest.mock.patch("tools.technical_recovery.time.sleep") as sleep,
        ):
            accepted, evidence = _guard_recovered_handoff(
                Provider(),
                self.session,
                interval=0.02,
                duration=0.3,
            )

        self.assertFalse(accepted)
        self.assertEqual(evidence["reason"], "RECOVERY_ACK_EPOCH_NOT_RESET")
        self.assertEqual(evidence["polls"], 3)
        self.assertEqual(sleep.call_count, 2)

    def test_guard_rejects_session_change_without_waiting(self) -> None:
        state = self.opening_state()

        class Provider:
            current_session_key = CombatSessionKey(
                self.session.lifecycle_epoch + 1,
                self.session.board_instance,
                "match-other",
            )
            metrics = SimpleNamespace(highest_acked_sequence=None)

            @staticmethod
            def poll():
                return SimpleNamespace(state=state, reason="fixture")

        ticks = iter((0.0, 0.1))
        with (
                mock.patch(
                "tools.technical_recovery.time.monotonic",
                side_effect=lambda: next(ticks),
            ),
            unittest.mock.patch("tools.technical_recovery.time.sleep") as sleep,
        ):
            accepted, evidence = _guard_recovered_handoff(
                Provider(),
                self.session,
                interval=0.02,
                duration=0.3,
            )

        self.assertFalse(accepted)
        self.assertEqual(
            evidence["reason"], "RECOVERY_HANDOFF_SESSION_CHANGED"
        )
        sleep.assert_not_called()

    def test_non_pristine_action_state_is_rejected(self) -> None:
        state = self.opening_state()
        state = replace(
            state,
            battle=replace(
                state.battle,
                local_move_sequence=1,
                last_move_sequence=5,
            ),
        )
        self.assertEqual(
            _recovered_handoff_rejection(
                expected_session=self.session,
                current_session=self.session,
                highest_acked_sequence=None,
                state=state,
            ),
            "RECOVERY_HANDOFF_ACTION_STATE_NOT_PRISTINE",
        )

    def test_missing_state_is_tolerated_during_guard_window(self) -> None:
        self.assertIsNone(
            _recovered_handoff_rejection(
                expected_session=self.session,
                current_session=self.session,
                highest_acked_sequence=None,
                state=None,
            )
        )

    def test_clean_boss_lobby_ack_epoch_allows_reentry(self) -> None:
        self.assertIsNone(
            _recovery_lobby_ack_epoch_rejection(
                match_id=None,
                highest_acked_sequence=None,
            )
        )

    def test_dirty_boss_lobby_ack_epoch_blocks_before_reentry(self) -> None:
        self.assertEqual(
            _recovery_lobby_ack_epoch_rejection(
                match_id=None,
                highest_acked_sequence=19,
            ),
            "RECOVERY_ACK_EPOCH_NOT_RESET",
        )

    def test_ack_epoch_wait_accepts_only_after_runtime_clears(self) -> None:
        samples = iter(
            (
                (0x1000, SimpleNamespace(match_id=None, highest_acked_sequence=49)),
                (0x1000, SimpleNamespace(match_id=None, highest_acked_sequence=49)),
                (0x1000, SimpleNamespace(match_id=None, highest_acked_sequence=None)),
            )
        )
        ticks = iter((0.0, 0.1, 0.2, 0.3))
        result = _wait_for_clean_recovery_lobby_ack_epoch(
            object(),
            timeout=1.0,
            interval=0.02,
            reader=lambda _process: next(samples),
            monotonic=lambda: next(ticks),
            sleeper=lambda _seconds: None,
        )
        self.assertIsNone(result[0])
        self.assertEqual(result[1], 0x1000)
        self.assertIsNone(result[2].highest_acked_sequence)
        self.assertEqual(result[3], 3)

    def test_frozen_owner_free_lobby_epoch_defers_reset_until_new_session(self) -> None:
        runtime = SimpleNamespace(
            match_id=None,
            highest_acked_sequence=29,
            local_move_sequence=6,
        )
        ticks = iter((0.0, 0.0, 0.3, 0.6, 0.9, 1.2, 1.5, 1.8, 2.1))
        result = _wait_for_clean_recovery_lobby_ack_epoch(
            object(),
            timeout=15.0,
            interval=0.02,
            reader=lambda _process: (0x1000, runtime),
            monotonic=lambda: next(ticks),
            sleeper=lambda _seconds: None,
        )
        self.assertIsNone(result[0])
        self.assertIs(result[2], runtime)
        self.assertEqual(result[3], 8)

    def test_advancing_dirty_lobby_epoch_still_blocks(self) -> None:
        samples = iter(
            (
                (0x1000, SimpleNamespace(match_id=None, highest_acked_sequence=29, local_move_sequence=6)),
                (0x1000, SimpleNamespace(match_id=None, highest_acked_sequence=30, local_move_sequence=6)),
                (0x1000, SimpleNamespace(match_id=None, highest_acked_sequence=31, local_move_sequence=7)),
                (0x1000, SimpleNamespace(match_id=None, highest_acked_sequence=32, local_move_sequence=7)),
            )
        )
        ticks = iter((0.0, 0.0, 0.2, 0.4, 0.6))
        result = _wait_for_clean_recovery_lobby_ack_epoch(
            object(),
            timeout=0.6,
            interval=0.02,
            reader=lambda _process: next(samples),
            monotonic=lambda: next(ticks),
            sleeper=lambda _seconds: None,
        )
        self.assertEqual(result[0], "RECOVERY_ACK_EPOCH_NOT_RESET")
        self.assertEqual(result[2].highest_acked_sequence, 32)
        self.assertEqual(result[3], 4)

    def test_unreadable_lobby_epoch_still_blocks(self) -> None:
        ticks = iter((0.0, 0.0, 0.2, 0.4))

        def unreadable(_process: object) -> tuple[int | None, object]:
            raise OSError("fixture read failure")

        result = _wait_for_clean_recovery_lobby_ack_epoch(
            object(),
            timeout=0.4,
            interval=0.02,
            reader=unreadable,
            monotonic=lambda: next(ticks),
            sleeper=lambda _seconds: None,
        )
        self.assertEqual(result[0], "RECOVERY_LOBBY_ACK_EPOCH_UNREADABLE")
        self.assertIsNone(result[1])
        self.assertIsNone(result[2])
        self.assertEqual(result[3], 3)

    def test_old_match_identity_blocks_before_reentry(self) -> None:
        self.assertEqual(
            _recovery_lobby_ack_epoch_rejection(
                match_id="match-old",
                highest_acked_sequence=None,
            ),
            "RECOVERY_LOBBY_MATCH_NOT_CLEARED",
        )


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


class ActiveCombatProgressWatchdogTests(unittest.TestCase):
    def setUp(self) -> None:
        self.session = CombatSessionKey(23, 0x1F4335C7540, "M_ef4e8a78")
        self.sample = {
            "session_key": self.session,
            "match_id": self.session.match_id,
            "turn": 10,
            "current_player": "__BOSS__",
            "local_username": "happi",
            "remaining_seconds": 14,
            "local_move_sequence": 3,
            "last_move_sequence": 3,
            "highest_acked_sequence": 24,
            "eligible": True,
        }

    def test_attempt_23_signature_triggers_after_bounded_unchanged_window(self) -> None:
        watchdog = ActiveCombatProgressWatchdog()
        self.assertIsNone(watchdog.observe(sampled_at=0.0, **self.sample))
        self.assertIsNone(watchdog.observe(sampled_at=10.0, **self.sample))
        self.assertIsNone(watchdog.observe(sampled_at=30.0, **self.sample))
        stall = watchdog.observe(
            sampled_at=ACTIVE_COMBAT_PROGRESS_STALL_SECONDS,
            **self.sample,
        )
        self.assertIsNotNone(stall)
        assert stall is not None
        self.assertEqual(stall.turn, 10)
        self.assertEqual(stall.current_player, "__BOSS__")
        self.assertEqual(stall.remaining_seconds, 14)
        self.assertEqual(stall.highest_acked_sequence, 24)
        self.assertGreaterEqual(
            stall.sample_count, ACTIVE_COMBAT_PROGRESS_STALL_MIN_SAMPLES
        )

    def test_any_progress_or_ineligible_sample_restarts_proof(self) -> None:
        watchdog = ActiveCombatProgressWatchdog(stall_seconds=5.0, minimum_samples=2)
        self.assertIsNone(watchdog.observe(sampled_at=0.0, **self.sample))
        changed = dict(self.sample, remaining_seconds=13)
        self.assertIsNone(watchdog.observe(sampled_at=5.0, **changed))
        self.assertIsNone(watchdog.observe(sampled_at=6.0, **changed))
        self.assertIsNone(
            watchdog.observe(sampled_at=20.0, **dict(changed, eligible=False))
        )
        self.assertIsNone(watchdog.observe(sampled_at=30.0, **changed))
        stall = watchdog.observe(sampled_at=35.0, **changed)
        self.assertIsNotNone(stall)

    def test_missing_ack_or_pristine_opening_never_starts_watchdog(self) -> None:
        watchdog = ActiveCombatProgressWatchdog(stall_seconds=1.0, minimum_samples=2)
        for change in (
            {"highest_acked_sequence": None},
            {"highest_acked_sequence": 0},
            {"turn": 1},
            {"local_move_sequence": 0},
            {"last_move_sequence": None},
            {"match_id": "other"},
        ):
            with self.subTest(change=change):
                sample = dict(self.sample)
                sample.update(change)
                self.assertIsNone(watchdog.observe(sampled_at=0.0, **sample))
                self.assertIsNone(watchdog.observe(sampled_at=10.0, **sample))


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
    def test_entry_opening_timeout_requires_exact_untouched_advanced_session(
        self,
    ) -> None:
        session = CombatSessionKey(14, 0x22220000, "M_31f7fb40")

        def dispatch(**changes):
            coordinator = TechnicalRecoveryCoordinator()
            evidence = {
                "session_key": session,
                "match_id": session.match_id,
                "provider_session": session,
                "entry_clicks": 1,
                "gameplay_inputs": 0,
                "published_turn": 3,
                "first_local_turn": False,
                "local_move_sequence": 0,
                "srv_seq": 7,
                "board_hash": "f" * 64,
                "board_source": (
                    "ChatMessageDTO.MATCH_MOVE_RES.matchPayload.board"
                ),
            }
            evidence.update(changes)
            accepted = TechnicalRecoveryDispatcher(
                coordinator
            ).dispatch_entry_opening_timeout_active_combat(**evidence)
            return accepted, coordinator

        accepted, coordinator = dispatch()
        self.assertTrue(accepted)
        self.assertEqual(
            coordinator.trigger.reason.value,  # type: ignore[union-attr]
            "ENTRY_OPENING_TIMEOUT_ACTIVE_COMBAT",
        )
        self.assertEqual(
            coordinator.trigger.source.value,  # type: ignore[union-attr]
            "PRODUCTION_ENTRY_OPENING_TIMEOUT",
        )

        for changes in (
            {"provider_session": CombatSessionKey(15, 0x22220008, "M_other")},
            {"match_id": "M_other"},
            {"entry_clicks": 0},
            {"entry_clicks": 2},
            {"gameplay_inputs": 1},
            {"published_turn": 1},
            {"first_local_turn": True},
            {"local_move_sequence": 1},
            {"srv_seq": 0},
            {"board_hash": ""},
            {
                "board_source": (
                    "ChatMessageDTO.MATCH_START.matchPayload.board"
                )
            },
        ):
            with self.subTest(changes=changes):
                rejected, rejected_coordinator = dispatch(**changes)
                self.assertFalse(rejected)
                self.assertEqual(
                    rejected_coordinator.state,
                    TechnicalRecoveryState.IDLE,
                )

    def test_late_mandatory_reset_requires_exact_idle_two_current_turn(
        self,
    ) -> None:
        session = CombatSessionKey(10, 0x2000000A000, "match-late-reset")
        base = active_state(session=session)
        state = replace(
            base,
            battle=replace(
                base.battle,
                turn_number=63,
                turn_time_remaining_seconds=0,
                sources=("BoardWsApplier._ackedSeqs",),
                board_current_state=1,
                board_has_destroyed_this_turn=False,
                board_is_processing_ui=False,
                board_is_game_over=False,
                board_modal_open=False,
                board_is_resuming=False,
                match_over=False,
                deferred_game_over=False,
                start_gate_paused=False,
                clock_paused=False,
                connection_ready=True,
                reconnecting=False,
                match_resyncing=False,
                presentation_busy=False,
                local_username="happi",
                consecutive_passes=2,
                consecutive_pass_threshold=3,
                consecutive_pass_source="MATCH_AFK_WARN@2026-08-23T01:18:23Z",
                consecutive_pass_status=(
                    GameOwnedIdleStatus.PASS_FORBIDDEN_MANDATORY_ACTION
                ),
            ),
        )

        def dispatch(current: GameState = state, **changes):
            coordinator = TechnicalRecoveryCoordinator()
            evidence = {
                "session_key": session,
                "match_id": session.match_id,
                "turn": 63,
                "remaining_seconds": 0,
                "minimum_action_time": 1,
                "recovery_warning_seconds": 1,
                "selected_action": "SWAP",
                "mandatory_reset_pending": True,
                "game_foreground": True,
                "window_valid": True,
                "controller_running": True,
                "pending_action": False,
                "consuming_action_sent": False,
                "authoritative_pass_wait_active": False,
                "evolve_wait_active": False,
                "sequence_desync": None,
            }
            evidence.update(changes)
            accepted = TechnicalRecoveryDispatcher(
                coordinator
            ).dispatch_late_mandatory_reset(current, **evidence)
            return accepted, coordinator

        accepted, coordinator = dispatch()
        self.assertTrue(accepted)
        self.assertEqual(
            coordinator.trigger.reason.value,  # type: ignore[union-attr]
            "LATE_MANDATORY_RESET",
        )
        self.assertEqual(
            coordinator.trigger.source.value,  # type: ignore[union-attr]
            "PRODUCTION_LATE_MANDATORY_RESET",
        )

        # Production passes PolicyAction.value across this boundary.  Those
        # values are lower-case even though older direct callers used names.
        lower_case_accepted, lower_case_coordinator = dispatch(
            selected_action="swap"
        )
        self.assertTrue(lower_case_accepted)
        self.assertEqual(
            lower_case_coordinator.trigger.reason.value,  # type: ignore[union-attr]
            "LATE_MANDATORY_RESET",
        )
        timer_blocked, timer_blocked_coordinator = dispatch(
            selected_action="none",
            policy_blocker="TURN_TIMER_SAFETY_MARGIN",
        )
        self.assertTrue(timer_blocked)
        self.assertEqual(
            timer_blocked_coordinator.trigger.reason.value,  # type: ignore[union-attr]
            "LATE_MANDATORY_RESET",
        )

        stale_idle = replace(
            state,
            battle=replace(
                state.battle,
                consecutive_passes=1,
                consecutive_pass_status=GameOwnedIdleStatus.PASS_ALLOWED,
            ),
        )
        for current, change in (
            (
                replace(
                    state,
                    battle=replace(
                        state.battle,
                        turn_time_remaining_seconds=4,
                    ),
                ),
                {"remaining_seconds": 4},
            ),
            (state, {"mandatory_reset_pending": False}),
            (state, {"selected_action": "PASS"}),
            (state, {"selected_action": "NONE", "policy_blocker": None}),
            (state, {"game_foreground": False}),
            (state, {"pending_action": True}),
            (state, {"consuming_action_sent": True}),
            (state, {"turn": 64}),
            (stale_idle, {}),
        ):
            with self.subTest(change=change, stale=current is stale_idle):
                rejected, rejected_coordinator = dispatch(current, **change)
                self.assertFalse(rejected)
                self.assertEqual(
                    rejected_coordinator.state,
                    TechnicalRecoveryState.IDLE,
                )

    def test_controller_stall_dispatch_requires_fully_actionable_current_turn(
        self,
    ) -> None:
        session = CombatSessionKey(9, 0x20000009000, "match-stall")
        base = active_state(session=session)
        state = replace(
            base,
            battle=replace(
                base.battle,
                turn_number=23,
                turn_time_remaining_seconds=3,
                sources=("BoardWsApplier._ackedSeqs",),
                board_current_state=1,
                board_has_destroyed_this_turn=False,
                board_is_processing_ui=False,
                board_is_game_over=False,
                board_modal_open=False,
                board_is_resuming=False,
                match_over=False,
                deferred_game_over=False,
                start_gate_paused=False,
                clock_paused=False,
                connection_ready=True,
                reconnecting=False,
                match_resyncing=False,
                presentation_busy=False,
                local_username="happi",
            ),
        )

        def dispatch(current: GameState = state, **changes):
            coordinator = TechnicalRecoveryCoordinator()
            evidence = {
                "session_key": session,
                "match_id": session.match_id,
                "turn": 23,
                "remaining_seconds": 3,
                "warning_seconds": 4,
                "game_foreground": True,
                "window_valid": True,
                "controller_running": True,
                "pending_action": False,
                "consuming_action_sent": False,
                "authoritative_pass_wait_active": False,
                "evolve_wait_active": False,
                "sequence_desync": None,
            }
            evidence.update(changes)
            accepted = TechnicalRecoveryDispatcher(
                coordinator
            ).dispatch_controller_stalled_active_combat(current, **evidence)
            return accepted, coordinator

        accepted, coordinator = dispatch()
        self.assertTrue(accepted)
        self.assertEqual(
            coordinator.trigger.reason.value,  # type: ignore[union-attr]
            "CONTROLLER_STALLED_ACTIVE_COMBAT",
        )
        self.assertEqual(
            coordinator.trigger.source.value,  # type: ignore[union-attr]
            "PRODUCTION_CONTROLLER_STALL",
        )

        reconnecting = replace(
            state,
            battle=replace(state.battle, reconnecting=True),
        )
        boss_turn = replace(
            state,
            battle=replace(
                state.battle,
                current_turn_player="boss",
                is_local_turn=False,
            ),
        )
        for current, change in (
            (state, {"game_foreground": False}),
            (state, {"window_valid": False}),
            (state, {"pending_action": True}),
            (state, {"consuming_action_sent": True}),
            (state, {"authoritative_pass_wait_active": True}),
            (state, {"evolve_wait_active": True}),
            (state, {"remaining_seconds": 4}),
            (state, {"turn": 24}),
            (reconnecting, {}),
            (boss_turn, {}),
        ):
            with self.subTest(change=change, reconnecting=current is reconnecting):
                rejected, rejected_coordinator = dispatch(current, **change)
                self.assertFalse(rejected)
                self.assertEqual(
                    rejected_coordinator.state,
                    TechnicalRecoveryState.IDLE,
                )

    def test_active_combat_progress_stall_dispatches_on_either_turn_owner(self) -> None:
        session = CombatSessionKey(23, 0x1F4335C7540, "M_ef4e8a78")
        base = active_state(session=session)

        for current_player, is_local_turn in (
            ("__BOSS__", False),
            ("happi", True),
        ):
            with self.subTest(current_player=current_player):
                state = replace(
                    base,
                    battle=replace(
                        base.battle,
                        turn_number=10,
                        current_turn_player=current_player,
                        local_username="happi",
                        is_local_turn=is_local_turn,
                        turn_time_remaining_seconds=14,
                        local_move_sequence=3,
                        last_move_sequence=3,
                    ),
                )
                stall = ActiveCombatProgressStall(
                    session_key=session,
                    match_id=session.match_id,
                    turn=10,
                    current_player=current_player,
                    local_username="happi",
                    remaining_seconds=14,
                    local_move_sequence=3,
                    last_move_sequence=3,
                    highest_acked_sequence=24,
                    unchanged_seconds=ACTIVE_COMBAT_PROGRESS_STALL_SECONDS,
                    sample_count=ACTIVE_COMBAT_PROGRESS_STALL_MIN_SAMPLES,
                )
                coordinator = TechnicalRecoveryCoordinator()
                accepted = TechnicalRecoveryDispatcher(
                    coordinator
                ).dispatch_active_combat_progress_stalled(
                    state,
                    stall=stall,
                    game_foreground=True,
                    window_valid=True,
                    controller_running=True,
                    pending_action=False,
                    accepted_consuming_actions=3,
                    authoritative_pass_wait_active=False,
                    evolve_wait_active=False,
                    sequence_desync=None,
                )
                self.assertTrue(accepted)
                self.assertEqual(
                    coordinator.trigger.reason.value,  # type: ignore[union-attr]
                    "ACTIVE_COMBAT_PROGRESS_STALLED",
                )
                self.assertEqual(
                    coordinator.trigger.source.value,  # type: ignore[union-attr]
                    "PRODUCTION_ACTIVE_COMBAT_PROGRESS_STALL",
                )

    def test_active_combat_progress_stall_rejects_ambiguous_or_pending_state(self) -> None:
        session = CombatSessionKey(23, 0x1F4335C7540, "M_ef4e8a78")
        base = active_state(session=session)
        state = replace(
            base,
            battle=replace(
                base.battle,
                turn_number=10,
                current_turn_player="__BOSS__",
                local_username="happi",
                is_local_turn=False,
                turn_time_remaining_seconds=14,
                local_move_sequence=3,
                last_move_sequence=3,
            ),
        )
        stall = ActiveCombatProgressStall(
            session_key=session,
            match_id=session.match_id,
            turn=10,
            current_player="__BOSS__",
            local_username="happi",
            remaining_seconds=14,
            local_move_sequence=3,
            last_move_sequence=3,
            highest_acked_sequence=24,
            unchanged_seconds=ACTIVE_COMBAT_PROGRESS_STALL_SECONDS,
            sample_count=ACTIVE_COMBAT_PROGRESS_STALL_MIN_SAMPLES,
        )
        base_evidence = {
            "stall": stall,
            "game_foreground": True,
            "window_valid": True,
            "controller_running": True,
            "pending_action": False,
            "accepted_consuming_actions": 3,
            "authoritative_pass_wait_active": False,
            "evolve_wait_active": False,
            "sequence_desync": None,
        }
        for current, change in (
            (state, {"game_foreground": False}),
            (state, {"window_valid": False}),
            (state, {"controller_running": False}),
            (state, {"pending_action": True}),
            (state, {"accepted_consuming_actions": 0}),
            (state, {"authoritative_pass_wait_active": True}),
            (state, {"evolve_wait_active": True}),
            (
                replace(state, battle=replace(state.battle, turn_number=11)),
                {},
            ),
            (
                state,
                {
                    "stall": replace(
                        stall,
                        unchanged_seconds=(
                            ACTIVE_COMBAT_PROGRESS_STALL_SECONDS - 0.001
                        ),
                    )
                },
            ),
        ):
            with self.subTest(change=change):
                evidence = dict(base_evidence)
                evidence.update(change)
                coordinator = TechnicalRecoveryCoordinator()
                self.assertFalse(
                    TechnicalRecoveryDispatcher(
                        coordinator
                    ).dispatch_active_combat_progress_stalled(
                        current,
                        **evidence,
                    )
                )
                self.assertEqual(coordinator.state, TechnicalRecoveryState.IDLE)

    def test_local_player_left_dispatch_requires_exact_board_signal(self) -> None:
        session = CombatSessionKey(10, 0x2000000A000, "match-left")
        base = active_state(session=session)
        left = replace(
            base,
            battle=replace(
                base.battle,
                local_actor_number=1,
                local_has_left_match=True,
                client_move_allowed=False,
            ),
        )
        coordinator = TechnicalRecoveryCoordinator()
        dispatcher = TechnicalRecoveryDispatcher(coordinator)
        self.assertTrue(
            dispatcher.dispatch_local_player_left_active_combat(
                left,
                session_key=session,
                match_id=session.match_id,
            )
        )
        self.assertEqual(
            coordinator.trigger.reason.value,  # type: ignore[union-attr]
            "LOCAL_PLAYER_LEFT_ACTIVE_COMBAT",
        )
        self.assertEqual(
            coordinator.trigger.source.value,  # type: ignore[union-attr]
            "PRODUCTION_BOARD_LEFT_ACTOR_SET",
        )

        for current, owned_session, match_id in (
            (replace(left, battle=replace(left.battle, local_has_left_match=False)), session, session.match_id),
            (replace(left, battle=replace(left.battle, local_actor_number=None)), session, session.match_id),
            (left, CombatSessionKey(11, session.board_instance, session.match_id), session.match_id),
            (left, session, "other-match"),
        ):
            with self.subTest(current=current, owned_session=owned_session, match_id=match_id):
                rejected = TechnicalRecoveryCoordinator()
                self.assertFalse(
                    TechnicalRecoveryDispatcher(
                        rejected
                    ).dispatch_local_player_left_active_combat(
                        current,
                        session_key=owned_session,
                        match_id=match_id,
                    )
                )
                self.assertEqual(rejected.state, TechnicalRecoveryState.IDLE)

    def test_actionability_state_loss_dispatch_requires_exact_reconnect_signature(
        self,
    ) -> None:
        session = CombatSessionKey(7, 0x20000007000, "match-reconnect")

        def dispatch(**changes):
            coordinator = TechnicalRecoveryCoordinator()
            evidence = {
                "session_key": session,
                "match_id": session.match_id,
                "turn": 33,
                "current_player": "happi",
                "local_username": "happi",
                "remaining_seconds": 4,
                "warning_seconds": 4,
                "local_move_sequence": 0,
                "last_move_sequence": None,
                "provider_reason": "stale_sequence",
                "actionability_gate_reason": None,
                "accepted_consuming_actions": 16,
                "last_accepted_srv_seq": 71,
                "last_accepted_board_hash": "a" * 64,
                "highest_acked_sequence": None,
                "last_published_turn": None,
            }
            evidence.update(changes)
            accepted = TechnicalRecoveryDispatcher(
                coordinator
            ).dispatch_actionability_state_lost(**evidence)
            return accepted, coordinator

        accepted, coordinator = dispatch()
        self.assertTrue(accepted)
        self.assertEqual(
            coordinator.trigger.reason.value,
            "ACTIONABILITY_STATE_LOST",
        )
        self.assertEqual(coordinator.trigger.failed_session.turn, 33)

        reconnect_wait, reconnect_coordinator = dispatch(
            provider_reason="awaiting_stability_confirmation",
            actionability_gate_reason="RECONNECTING",
        )
        self.assertTrue(reconnect_wait)
        self.assertEqual(
            reconnect_coordinator.trigger.reason.value,
            "ACTIONABILITY_STATE_LOST",
        )

        transport_gap, transport_coordinator = dispatch(
            provider_reason="latest_acked_batch_not_resolved",
            local_move_sequence=13,
            last_move_sequence=13,
            highest_acked_sequence=72,
            last_accepted_srv_seq=67,
            last_published_turn=31,
        )
        self.assertTrue(transport_gap)
        self.assertEqual(
            transport_coordinator.trigger.reason.value,
            "ACTIONABILITY_STATE_LOST",
        )

        for change in (
            {"turn": 1, "accepted_consuming_actions": 0},
            {"local_move_sequence": 16},
            {"last_move_sequence": 16},
            {"provider_reason": "stable_ack_attested_dto"},
            {
                "provider_reason": "awaiting_stability_confirmation",
                "actionability_gate_reason": None,
            },
            {"remaining_seconds": 5},
            {"last_accepted_srv_seq": None},
            {
                "provider_reason": "latest_acked_batch_not_resolved",
                "local_move_sequence": 13,
                "last_move_sequence": 13,
                "highest_acked_sequence": 67,
                "last_accepted_srv_seq": 67,
                "last_published_turn": 31,
            },
        ):
            with self.subTest(change=change):
                rejected, rejected_coordinator = dispatch(**change)
                self.assertFalse(rejected)
                self.assertEqual(
                    rejected_coordinator.state,
                    TechnicalRecoveryState.IDLE,
                )

    def test_unconfirmed_pass_dispatch_requires_zero_input_runtime_reset(self) -> None:
        session = CombatSessionKey(5, 0x20000005000, "match-pass-reset")

        def dispatch(**changes):
            coordinator = TechnicalRecoveryCoordinator()
            evidence = {
                "session_key": session,
                "match_id": session.match_id,
                "source_turn": 17,
                "source_srv_seq": 37,
                "source_board_hash": "4" * 64,
                "source_local_move_sequence": 8,
                "current_turn": 19,
                "current_player": "happi",
                "local_username": "happi",
                "current_local_move_sequence": 0,
                "current_last_move_sequence": None,
                "current_highest_acked_sequence": None,
                "gameplay_inputs_during_wait": 0,
                "terminal_detail": (
                    "next local turn reached without a correlated AFK payload"
                ),
            }
            evidence.update(changes)
            accepted = TechnicalRecoveryDispatcher(
                coordinator
            ).dispatch_unconfirmed_pass_runtime_reset(**evidence)
            return accepted, coordinator

        accepted, coordinator = dispatch()
        self.assertTrue(accepted)
        self.assertEqual(
            coordinator.trigger.reason.value,
            "ACTIONABILITY_STATE_LOST",
        )

        for change in (
            {"gameplay_inputs_during_wait": 1},
            {"source_local_move_sequence": 0},
            {"current_local_move_sequence": 8},
            {"current_last_move_sequence": 8},
            {"current_highest_acked_sequence": 37},
            {"current_turn": 17},
        ):
            with self.subTest(change=change):
                rejected, rejected_coordinator = dispatch(**change)
                self.assertFalse(rejected)
                self.assertEqual(
                    rejected_coordinator.state,
                    TechnicalRecoveryState.IDLE,
                )

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

        deadline_coordinator = TechnicalRecoveryCoordinator()
        deadline_runtime = SharedCombatRuntime(
            None,
            None,  # type: ignore[arg-type]
            None,  # type: ignore[arg-type]
            None,
            None,  # type: ignore[arg-type]
            None,  # type: ignore[arg-type]
            technical_recovery_dispatcher=TechnicalRecoveryDispatcher(
                deadline_coordinator
            ),
        )
        session = state.battle.session_key
        assert session is not None
        self.assertTrue(
            _dispatch_technical_recovery(
                deadline_runtime,
                reason="ACTIONABILITY_STATE_LOST",
                state=state,
                actionability_evidence={
                    "session_key": session,
                    "match_id": session.match_id,
                    "turn": 33,
                    "current_player": "happi",
                    "local_username": "happi",
                    "remaining_seconds": 4,
                    "warning_seconds": 4,
                    "local_move_sequence": 0,
                    "last_move_sequence": None,
                    "provider_reason": "stale_sequence",
                    "actionability_gate_reason": None,
                    "accepted_consuming_actions": 8,
                    "last_accepted_srv_seq": 71,
                    "last_accepted_board_hash": "b" * 64,
                },
            )
        )
        self.assertTrue(deadline_coordinator.gameplay_locked)

        stall_coordinator = TechnicalRecoveryCoordinator()
        stall_runtime = replace(
            deadline_runtime,
            technical_recovery_dispatcher=TechnicalRecoveryDispatcher(
                stall_coordinator
            ),
        )
        stall_state = replace(
            state,
            battle=replace(
                state.battle,
                turn_number=23,
                turn_time_remaining_seconds=3,
                sources=("BoardWsApplier._ackedSeqs",),
                board_current_state=1,
                board_has_destroyed_this_turn=False,
                board_is_processing_ui=False,
                board_is_game_over=False,
                board_modal_open=False,
                board_is_resuming=False,
                match_over=False,
                deferred_game_over=False,
                start_gate_paused=False,
                clock_paused=False,
                connection_ready=True,
                reconnecting=False,
                match_resyncing=False,
                presentation_busy=False,
                local_username="happi",
            ),
        )
        self.assertTrue(
            _dispatch_technical_recovery(
                stall_runtime,
                reason="CONTROLLER_STALLED_ACTIVE_COMBAT",
                state=stall_state,
                controller_stall_evidence={
                    "session_key": session,
                    "match_id": session.match_id,
                    "turn": 23,
                    "remaining_seconds": 3,
                    "warning_seconds": 4,
                    "game_foreground": True,
                    "window_valid": True,
                    "controller_running": True,
                    "pending_action": False,
                    "consuming_action_sent": False,
                    "authoritative_pass_wait_active": False,
                    "evolve_wait_active": False,
                    "sequence_desync": None,
                },
            )
        )
        self.assertTrue(stall_coordinator.gameplay_locked)

        progress_coordinator = TechnicalRecoveryCoordinator()
        progress_runtime = replace(
            deadline_runtime,
            technical_recovery_dispatcher=TechnicalRecoveryDispatcher(
                progress_coordinator
            ),
        )
        progress_state = replace(
            state,
            battle=replace(
                state.battle,
                turn_number=10,
                current_turn_player="__BOSS__",
                local_username="happi",
                is_local_turn=False,
                turn_time_remaining_seconds=14,
                local_move_sequence=3,
                last_move_sequence=3,
            ),
        )
        progress_stall = ActiveCombatProgressStall(
            session_key=session,
            match_id=session.match_id,
            turn=10,
            current_player="__BOSS__",
            local_username="happi",
            remaining_seconds=14,
            local_move_sequence=3,
            last_move_sequence=3,
            highest_acked_sequence=24,
            unchanged_seconds=ACTIVE_COMBAT_PROGRESS_STALL_SECONDS,
            sample_count=ACTIVE_COMBAT_PROGRESS_STALL_MIN_SAMPLES,
        )
        self.assertTrue(
            _dispatch_technical_recovery(
                progress_runtime,
                reason="ACTIVE_COMBAT_PROGRESS_STALLED",
                state=progress_state,
                active_combat_progress_stall=progress_stall,
                active_combat_progress_evidence={
                    "game_foreground": True,
                    "window_valid": True,
                    "controller_running": True,
                    "pending_action": False,
                    "accepted_consuming_actions": 3,
                    "authoritative_pass_wait_active": False,
                    "evolve_wait_active": False,
                    "sequence_desync": None,
                },
            )
        )
        self.assertTrue(progress_coordinator.gameplay_locked)

        left_coordinator = TechnicalRecoveryCoordinator()
        left_runtime = replace(
            deadline_runtime,
            technical_recovery_dispatcher=TechnicalRecoveryDispatcher(
                left_coordinator
            ),
        )
        left_state = replace(
            state,
            battle=replace(
                state.battle,
                local_actor_number=1,
                local_has_left_match=True,
                client_move_allowed=False,
            ),
        )
        self.assertTrue(
            _dispatch_technical_recovery(
                left_runtime,
                reason="LOCAL_PLAYER_LEFT_ACTIVE_COMBAT",
                state=left_state,
                local_player_left_evidence={
                    "session_key": session,
                    "match_id": session.match_id,
                },
            )
        )
        self.assertTrue(left_coordinator.gameplay_locked)

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
