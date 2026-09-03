from __future__ import annotations

from dataclasses import replace
import os
from pathlib import Path
import tempfile
from types import SimpleNamespace
import unittest
from unittest.mock import patch

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
from pokiguard_v2.postmatch_ui import PostmatchControl, PostmatchUiLocation
from pokiguard_v2.win32_input import (
    ClientGeometry,
    ClickPointResult,
    ForegroundClickExecutor,
    WindowBinding,
)
from pokiguard_v2.technical_recovery import (
    FailedSessionEvidence,
    RecoveredOpeningEvidence,
    RecoveryInputDomain,
    TechnicalRecoveryCoordinator,
    TechnicalRecoveryDispatcher,
    TechnicalRecoveryState,
)
from tools.farm_run import (
    ClickStatus,
    _ControllerMemorySampler,
    _confirm_postmatch,
    _exact_target_room_restored,
    _failed_recovery_fallback_allowed,
    _farm_room_ejection_sources,
    _outside_current_boss_room,
    _owner_free_chinh_phuc_map_snapshot,
    _postmatch_reentry_source,
    _restore_bound_game_foreground,
    _stable_visual_proof,
    _stage_b1_action_proof,
    _world_map_ejection_proven,
)
from tools.farm_cycle import LobbyWaitResult


SOURCE = "ChatMessageDTO.MATCH_START.matchPayload.board"


class _ForegroundBackend:
    def __init__(self, *, restore_ok: bool = True, pid: int = 123) -> None:
        self.pid = pid
        self.restore_ok = restore_ok
        self.foreground = False
        self.geometry = ClientGeometry(100, 100, 1280, 720)
        self.restore_calls = 0

    def window_pid(self, _hwnd: int) -> int | None:
        return self.pid

    def client_geometry(self, _hwnd: int) -> ClientGeometry | None:
        return self.geometry

    def is_foreground(self, _hwnd: int) -> bool:
        return self.foreground

    def restore_and_foreground(self, _hwnd: int) -> bool:
        self.restore_calls += 1
        if self.restore_ok:
            self.foreground = True
        return self.restore_ok


class ReentryForegroundTests(unittest.TestCase):
    def test_reentry_restores_exact_bound_game_before_target_proof(self) -> None:
        backend = _ForegroundBackend()
        executor = ForegroundClickExecutor(backend, sleeper=lambda _seconds: None)
        binding = WindowBinding(5, 123, "Pokiguard", 1280, 720)

        self.assertTrue(
            _restore_bound_game_foreground(
                binding,
                executor,
                sleeper=lambda _seconds: None,
            )
        )
        self.assertEqual(backend.restore_calls, 1)

    def test_reentry_wrong_pid_fails_without_foreground_transfer(self) -> None:
        backend = _ForegroundBackend(pid=999)
        executor = ForegroundClickExecutor(backend, sleeper=lambda _seconds: None)
        binding = WindowBinding(5, 123, "Pokiguard", 1280, 720)

        self.assertFalse(
            _restore_bound_game_foreground(
                binding,
                executor,
                sleeper=lambda _seconds: None,
            )
        )
        self.assertEqual(backend.restore_calls, 0)


class ChinhPhucMapSnapshotTests(unittest.TestCase):
    @staticmethod
    def lobby(
        *,
        state: BossLobbyState,
        branch: str | None,
        current_room_id: str | None = None,
        current_room_type: str | None = None,
        owner_username: str | None = None,
        is_host: bool = False,
        lifecycle: CombatLifecycleState = CombatLifecycleState.LOBBY,
    ) -> SimpleNamespace:
        return SimpleNamespace(
            state=state,
            branch=branch,
            combat_lifecycle=SimpleNamespace(state=lifecycle),
            chinh_phuc=SimpleNamespace(
                current_room_id=current_room_id,
                current_room_type=current_room_type,
                owner_username=owner_username,
                is_host=is_host,
            ),
        )

    def test_exact_world_list_map_is_accepted(self) -> None:
        self.assertTrue(
            _owner_free_chinh_phuc_map_snapshot(
                self.lobby(
                    state=BossLobbyState.BOSS_LOBBY,
                    branch="WORLD_BOSS_LIST",
                )
            )
        )

    def test_owner_free_post_shell_transitional_map_is_accepted(self) -> None:
        self.assertTrue(
            _owner_free_chinh_phuc_map_snapshot(
                self.lobby(
                    state=BossLobbyState.LOBBY_OTHER,
                    branch=None,
                )
            )
        )

    def test_room_or_owned_transitional_shape_is_rejected(self) -> None:
        cases = (
            self.lobby(
                state=BossLobbyState.LOBBY_OTHER,
                branch=None,
                current_room_id="Coop_123",
            ),
            self.lobby(
                state=BossLobbyState.LOBBY_OTHER,
                branch=None,
                current_room_type="ChinhPhuc",
            ),
            self.lobby(
                state=BossLobbyState.LOBBY_OTHER,
                branch=None,
                owner_username="happi",
            ),
            self.lobby(
                state=BossLobbyState.LOBBY_OTHER,
                branch=None,
                is_host=True,
            ),
            self.lobby(
                state=BossLobbyState.LOBBY_OTHER,
                branch=None,
                lifecycle=CombatLifecycleState.ACTIVE,
            ),
            self.lobby(
                state=BossLobbyState.LOBBY_OTHER,
                branch="WORLD_BOSS_LIST",
            ),
        )
        for case in cases:
            with self.subTest(case=case):
                self.assertFalse(_owner_free_chinh_phuc_map_snapshot(case))


class ControllerMemorySamplerTests(unittest.TestCase):
    @unittest.skipUnless(os.name == "nt", "Win32 working-set sampler")
    def test_x64_windows_working_set_is_available_and_bounded(self) -> None:
        sampler = _ControllerMemorySampler()
        value = sampler.sample()
        self.assertIsNotNone(value)
        self.assertGreater(value or 0, 0)
        report = sampler.report()
        self.assertTrue(report["available"])
        self.assertEqual(report["sampleCount"], 1)
        self.assertEqual(report["retainedSampleCap"], 512)


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


class MatchEnergyAccountingTests(unittest.TestCase):
    def test_live_turn_progress_is_monotonic_and_session_bound(self) -> None:
        run = start_run()
        active = session(1)
        enter(run, active)

        self.assertTrue(
            run.observe_combat_turn_counts(
                session=active,
                local_turns=3,
                boss_turns=2,
            )
        )
        self.assertEqual(3, run.current_attempt.local_turns)
        self.assertFalse(
            run.observe_combat_turn_counts(
                session=active,
                local_turns=2,
                boss_turns=2,
            )
        )
        self.assertFalse(
            run.observe_combat_turn_counts(
                session=session(2),
                local_turns=4,
                boss_turns=3,
            )
        )
        self.assertEqual(3, run.current_attempt.local_turns)

    def test_distinct_local_turn_count_is_recorded_as_match_energy(self) -> None:
        run = start_run()
        enter(run, session(1))

        run.apply_combat_summary(
            {
                "localTurnsObserved": 12,
                "bossTurnsObserved": 11,
                "counters": {},
            }
        )

        self.assertEqual(12, run.current_attempt.local_turns)
        event = next(
            item for item in run.events
            if item.event == "match_turn_energy_counted"
        )
        self.assertEqual(12, event.detail["energyUsed"])
        self.assertEqual(1, event.detail["attemptIndex"])


class PostmatchConfirmationTimingTests(unittest.TestCase):
    def test_three_visual_frames_use_only_initial_and_final_memory_polls(self) -> None:
        run = start_run()
        enter(run, session(1))
        self.assertTrue(run.normal_combat_ended(MatchResult.WIN))
        self.assertTrue(run.observe_postmatch())

        class Provider:
            def __init__(self) -> None:
                self.polls = 0

            def poll(self) -> SimpleNamespace:
                self.polls += 1
                return SimpleNamespace(
                    combat_lifecycle=SimpleNamespace(
                        state=CombatLifecycleState.POSTMATCH
                    ),
                    state=None,
                )

        class Executor:
            def __init__(self) -> None:
                self.points: list[tuple[float, float]] = []

            def window_status(self, _binding: object) -> SimpleNamespace:
                return SimpleNamespace(valid=True, foreground=True)

            def send_normalized_point(
                self, _binding: object, point: tuple[float, float]
            ) -> ClickPointResult:
                self.points.append(point)
                return ClickPointResult(ClickStatus.SENT)

        provider = Provider()
        executor = Executor()
        capture = SimpleNamespace(width=800, height=450, rgb=bytes(800 * 450 * 3))
        location = PostmatchUiLocation(
            PostmatchControl.RESULT_CONFIRM,
            True,
            (0.5, 0.88),
            0.98,
            "stable test result control",
        )
        sleeps: list[float] = []
        hotkeys = SimpleNamespace(poll=lambda: (False, False))
        process = SimpleNamespace(pid=123, is_running=lambda: True)

        with (
            patch("tools.farm_run.capture_client_rgb", return_value=capture),
            patch("tools.farm_run.locate_result_confirm", return_value=location),
            patch("tools.farm_run.write_png_rgb"),
        ):
            confirmed, _ui_result, _ui_text = _confirm_postmatch(
                run=run,
                process=process,
                provider=provider,  # type: ignore[arg-type]
                binding=object(),
                executor=executor,  # type: ignore[arg-type]
                directory=Path("unused"),
                interval=0.12,
                ui_timeout=3.0,
                hotkeys=hotkeys,  # type: ignore[arg-type]
                sleeper=sleeps.append,
            )

        self.assertTrue(confirmed)
        self.assertEqual(provider.polls, 2)
        self.assertEqual(sleeps, [0.12, 0.12])
        self.assertEqual(executor.points, [(0.5, 0.88)])
        self.assertEqual(run.snapshot().total_postmatch_inputs, 1)


class FarmRunBoundaryTests(unittest.TestCase):
    def test_one_exact_entry_retry_is_allowed_without_new_match_attempt(self) -> None:
        run = start_run()
        self.assertTrue(run.target_resolved())
        capability = FarmRunEntryCapability(run)
        first = capability.reserve(foreground=True)
        self.assertIsNotNone(first)
        self.assertTrue(capability.complete(first, sent=True))  # type: ignore[arg-type]
        retry = capability.reserve_retry(
            foreground=True,
            exact_same_target=True,
            no_combat_owner=True,
            stable_same_button=True,
        )
        self.assertIsNotNone(retry)
        self.assertTrue(capability.complete_retry(retry, sent=True))  # type: ignore[arg-type]
        self.assertEqual(run.match_attempts, 0)
        self.assertEqual(run.state, FarmRunState.ENTRY_PENDING)
        self.assertEqual(run.snapshot().total_lobby_inputs, 2)
        self.assertEqual(run.snapshot().safety.nonzero(), {})

        self.assertIsNone(
            capability.reserve_retry(
                foreground=True,
                exact_same_target=True,
                no_combat_owner=True,
                stable_same_button=True,
            )
        )
        self.assertEqual(run.stop_reason, FarmRunStopReason.ENTRY_CAPABILITY_DENIED)

    def test_entry_retry_rejects_changed_target_without_input(self) -> None:
        run = start_run()
        self.assertTrue(run.target_resolved())
        capability = FarmRunEntryCapability(run)
        first = capability.reserve(foreground=True)
        self.assertIsNotNone(first)
        self.assertTrue(capability.complete(first, sent=True))  # type: ignore[arg-type]
        self.assertIsNone(
            capability.reserve_retry(
                foreground=True,
                exact_same_target=False,
                no_combat_owner=True,
                stable_same_button=True,
            )
        )
        retries = [
            record
            for record in run.input_records
            if record.domain is FarmInputDomain.BOSS_ENTRY_RETRY
        ]
        self.assertEqual(retries, [])

    def test_one_attack_card_selection_precedes_independent_entry_permit(self) -> None:
        run = start_run(FarmRunLimits(1, 0, 1))
        self.assertTrue(run.target_resolved())
        card_permit = run.reserve_lobby_card_select(
            foreground=True,
            exact_attack_identity=True,
            no_combat_owner=True,
            selected_attack_missing=True,
            unique_room_attack=True,
        )
        self.assertIsNotNone(card_permit)
        self.assertTrue(
            run.complete_lobby_card_select(
                card_permit,  # type: ignore[arg-type]
                sent=True,
                detail="ATTACK data=64647 card=4 roomIndex=3:SENT",
            )
        )
        self.assertEqual(run.state, FarmRunState.ENTRY_READY)
        entry_permit = run.reserve_entry(foreground=True)
        self.assertIsNotNone(entry_permit)
        self.assertTrue(
            run.complete_entry(entry_permit, sent=True)  # type: ignore[arg-type]
        )
        self.assertEqual(run.snapshot().total_lobby_inputs, 2)

    def test_duplicate_or_unproven_attack_card_selection_fails_closed(self) -> None:
        run = start_run(FarmRunLimits(1, 0, 1))
        self.assertTrue(run.target_resolved())
        denied = run.reserve_lobby_card_select(
            foreground=True,
            exact_attack_identity=False,
            no_combat_owner=True,
            selected_attack_missing=True,
            unique_room_attack=True,
        )
        self.assertIsNone(denied)
        self.assertTrue(run.stopped)

    def test_postmatch_reentry_accepts_exact_detached_shell_only(self) -> None:
        chinh_phuc = SimpleNamespace(
            current_room_id=None,
            current_room_type=None,
            room_data=0x20000001000,
            enemy_pet_id=1289,
            button_start=0x20000002000,
            button_native=0x10000002000,
            button_interactable=True,
            is_host=False,
        )
        lobby = SimpleNamespace(
            state=BossLobbyState.LOBBY_OTHER,
            branch=None,
            combat_lifecycle=SimpleNamespace(state=CombatLifecycleState.LOBBY),
            chinh_phuc=chinh_phuc,
        )
        candidate = LobbyWaitResult(
            False,
            BossLobbyState.LOBBY_OTHER,
            None,
            "DETACHED_ROOM_SHELL_CANDIDATE",
            lobby,
            2,
        )
        self.assertEqual(
            "DETACHED_ROOM_SHELL",
            _postmatch_reentry_source(
                candidate, target_pet_id=1289, current_session=None
            ),
        )
        self.assertEqual(
            (False, True),
            _farm_room_ejection_sources(
                candidate,
                target_boss_id="1289",
                current_session=None,
            ),
        )
        self.assertIsNone(
            _postmatch_reentry_source(
                candidate, target_pet_id=2243, current_session=None
            )
        )
        self.assertIsNone(
            _postmatch_reentry_source(
                candidate, target_pet_id=1289, current_session=object()
            )
        )

    def test_current_room_only_distinguishes_room_from_world_boss_map(self) -> None:
        room = LobbyWaitResult(
            True,
            BossLobbyState.BOSS_LOBBY,
            None,
            "BOSS_LOBBY_READY",
            type("Lobby", (), {"branch": "CHINH_PHUC_ROOM"})(),
        )
        world_map = replace(
            room,
            lobby=type("Lobby", (), {"branch": "WORLD_BOSS_LIST"})(),
        )
        self.assertFalse(_outside_current_boss_room(room))
        self.assertTrue(_outside_current_boss_room(world_map))

    def test_ejection_and_restored_room_require_exact_branch_and_no_owner(self) -> None:
        chinh_phuc = type("ChinhPhuc", (), {"current_room_id": None})()
        world_map = LobbyWaitResult(
            False,
            BossLobbyState.BOSS_LOBBY,
            None,
            "TARGET_MISSING",
            type(
                "Lobby",
                (),
                {"branch": "WORLD_BOSS_LIST", "chinh_phuc": chinh_phuc},
            )(),
        )
        room = replace(
            world_map,
            ready=True,
            reason="BOSS_LOBBY_READY",
            lobby=type(
                "Lobby",
                (),
                {"branch": "CHINH_PHUC_ROOM", "chinh_phuc": chinh_phuc},
            )(),
        )
        self.assertTrue(
            _world_map_ejection_proven(world_map, current_session=None)
        )
        self.assertEqual(
            (True, False),
            _farm_room_ejection_sources(
                world_map,
                target_boss_id="1289",
                current_session=None,
            ),
        )
        self.assertFalse(
            _world_map_ejection_proven(world_map, current_session=object())
        )
        self.assertTrue(
            _exact_target_room_restored(room, current_session=None)
        )
        self.assertFalse(
            _exact_target_room_restored(room, current_session=object())
        )

    def test_ejected_map_reentry_is_bounded_and_does_not_count_match(self) -> None:
        run = start_run(FarmRunLimits(3, 2, 5))
        enter(run, session(1))
        self.assertTrue(run.technical_failure("ROOM_EJECTED_TO_BOSS_MAP"))
        self.assertTrue(
            run.begin_ejected_map_reentry(
                target_boss_id="1289",
                exact_world_map=True,
                no_combat_owner=True,
            )
        )
        permit = run.reserve_target_select(foreground=True)
        self.assertIsNotNone(permit)
        self.assertTrue(
            run.complete_target_select(permit, sent=True, detail="exact pet 1289")
        )
        self.assertTrue(
            run.complete_ejected_map_reentry(
                target_boss_id="1289",
                exact_target_room=True,
                no_combat_owner=True,
            )
        )
        self.assertTrue(run.observe_return_lobby(BossLobbyState.BOSS_LOBBY))
        snapshot = run.snapshot()
        self.assertEqual(0, snapshot.completed_matches)
        self.assertEqual(1, snapshot.technical_aborts)
        self.assertEqual(1, snapshot.technical_recoveries)
        self.assertEqual(FarmRunState.RESOLVE_TARGET, snapshot.state)

    def test_failed_recovery_fallback_accepts_one_audited_prior_reentry(self) -> None:
        run = start_run(FarmRunLimits(3, 2, 5))
        enter(run, session(1))
        self.assertTrue(run.technical_failure("LATE_MANDATORY_RESET"))
        self.assertTrue(run.begin_recovery())
        records = (
            SimpleNamespace(
                domain=RecoveryInputDomain.RECOVERY_EXIT,
                sent=True,
                detail="normal Exit",
            ),
            SimpleNamespace(
                domain=RecoveryInputDomain.RECOVERY_CONFIRM,
                sent=True,
                detail="normal confirm",
            ),
        )
        self.assertTrue(run.prepare_failed_recovery_map_fallback(records))
        self.assertTrue(
            run.begin_ejected_map_reentry(
                target_boss_id="1289",
                exact_world_map=True,
                no_combat_owner=True,
            )
        )

        after_reentry = start_run(FarmRunLimits(3, 2, 5))
        enter(after_reentry, session(2))
        self.assertTrue(after_reentry.technical_failure("LATE_MANDATORY_RESET"))
        self.assertTrue(after_reentry.begin_recovery())
        self.assertTrue(
            after_reentry.prepare_failed_recovery_map_fallback(
                (
                    SimpleNamespace(
                        domain=RecoveryInputDomain.RECOVERY_REENTRY,
                        sent=True,
                        detail="one recovered combat entry",
                    ),
                )
            )
        )
        self.assertTrue(
            after_reentry.begin_ejected_map_reentry(
                target_boss_id="1289",
                exact_world_map=False,
                detached_room_shell=True,
                no_combat_owner=True,
            )
        )

        duplicate = start_run(FarmRunLimits(3, 2, 5))
        enter(duplicate, session(3))
        self.assertTrue(duplicate.technical_failure("LATE_MANDATORY_RESET"))
        self.assertTrue(duplicate.begin_recovery())
        self.assertFalse(
            duplicate.prepare_failed_recovery_map_fallback(
                tuple(
                    SimpleNamespace(
                        domain=RecoveryInputDomain.RECOVERY_REENTRY,
                        sent=True,
                        detail=f"re-entry {index}",
                    )
                    for index in range(2)
                )
            )
        )

    def test_failed_recovery_can_resume_from_exact_pinned_room(self) -> None:
        run = start_run(FarmRunLimits(3, 2, 5))
        enter(run, session(1))
        self.assertTrue(run.technical_failure("DEAD_BOARD_NO_REFRESH"))
        self.assertTrue(run.begin_recovery())
        records = (
            SimpleNamespace(
                domain=RecoveryInputDomain.RECOVERY_EXIT,
                sent=True,
                detail="normal Exit",
            ),
            SimpleNamespace(
                domain=RecoveryInputDomain.RECOVERY_CONFIRM,
                sent=True,
                detail="normal confirm",
            ),
        )
        self.assertTrue(run.prepare_failed_recovery_map_fallback(records))
        self.assertTrue(
            run.complete_failed_recovery_room_fallback(
                target_boss_id="1289",
                exact_target_room=True,
                no_combat_owner=True,
            )
        )
        self.assertTrue(run.observe_return_lobby(BossLobbyState.BOSS_LOBBY))
        snapshot = run.snapshot()
        self.assertEqual(snapshot.state, FarmRunState.RESOLVE_TARGET)
        self.assertEqual(snapshot.technical_recoveries, 1)
        self.assertIsNone(run.current_session)
        self.assertEqual(snapshot.completed_matches, 0)
        self.assertEqual(snapshot.technical_aborts, 1)

    def test_dirty_ack_epoch_can_never_use_failed_recovery_fallback(self) -> None:
        for detail in (
            "RECOVERY_ACK_EPOCH_NOT_RESET",
            "RECOVERY_LOBBY_MATCH_NOT_CLEARED",
            "RECOVERY_LOBBY_ACK_EPOCH_UNREADABLE",
        ):
            with self.subTest(detail=detail):
                self.assertFalse(
                    _failed_recovery_fallback_allowed(
                        SimpleNamespace(result_detail=detail)
                    )
                )
        self.assertTrue(
            _failed_recovery_fallback_allowed(
                SimpleNamespace(result_detail="ROOM_EJECTED_TO_BOSS_MAP")
            )
        )

    def test_failed_recovery_exact_room_requires_the_pinned_target(self) -> None:
        run = start_run(FarmRunLimits(3, 2, 5))
        enter(run, session(1))
        self.assertTrue(run.technical_failure("DEAD_BOARD_NO_REFRESH"))
        self.assertTrue(run.begin_recovery())
        self.assertFalse(
            run.complete_failed_recovery_room_fallback(
                target_boss_id="9999",
                exact_target_room=True,
                no_combat_owner=True,
            )
        )
        self.assertEqual(run.snapshot().stop_reason, FarmRunStopReason.RECOVERY_FAILED)

    def test_map_return_uses_the_runtime_click_status_enum(self) -> None:
        self.assertEqual(ClickStatus.SENT.value, "SENT")

    def test_map_return_visual_proof_requires_two_stable_found_frames(self) -> None:
        capture = SimpleNamespace(width=1280, height=720)
        found = SimpleNamespace(found=True, normalized_point=(0.05, 0.62))
        shifted = SimpleNamespace(found=True, normalized_point=(0.08, 0.62))
        missing = SimpleNamespace(found=False, normalized_point=None)

        self.assertTrue(
            _stable_visual_proof(capture, found, capture, found)
        )
        self.assertFalse(
            _stable_visual_proof(capture, found, capture, shifted)
        )
        self.assertFalse(
            _stable_visual_proof(capture, missing, capture, found)
        )
        self.assertFalse(
            _stable_visual_proof(
                capture,
                found,
                SimpleNamespace(width=960, height=540),
                found,
            )
        )

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

    def test_one_runtime_proven_map_target_select_is_allowed_during_return(self) -> None:
        run = start_run()
        enter(run, session(1))
        self.assertTrue(run.normal_combat_ended(MatchResult.WIN))
        self.assertTrue(run.observe_postmatch())

        permit = run.reserve_target_select(foreground=True)
        self.assertIsNotNone(permit)
        self.assertTrue(
            run.complete_target_select(
                permit,  # type: ignore[arg-type]
                sent=True,
                detail="CHINH_PHUC_MAP pet=1289 group=5 order=8:SENT",
            )
        )
        self.assertEqual(run.state, FarmRunState.WAIT_BOSS_LOBBY)
        self.assertTrue(run.observe_return_lobby(BossLobbyState.BOSS_LOBBY))
        records = [
            item
            for item in run.input_records
            if item.domain is FarmInputDomain.BOSS_TARGET_SELECT
        ]
        self.assertEqual(len(records), 1)
        self.assertTrue(records[0].sent)
        self.assertEqual(run.snapshot().total_lobby_inputs, 2)

    def test_one_detached_room_shell_exit_can_precede_exact_target_select(self) -> None:
        run = start_run()
        enter(run, session(1))
        self.assertTrue(run.normal_combat_ended(MatchResult.WIN))
        self.assertTrue(run.observe_postmatch())

        shell = run.reserve_room_shell_exit(foreground=True)
        self.assertIsNotNone(shell)
        self.assertTrue(
            run.complete_room_shell_exit(
                shell,  # type: ignore[arg-type]
                sent=True,
                detail="detached exact pet room shell",
            )
        )
        confirm = run.reserve_room_shell_confirm(foreground=True)
        self.assertIsNotNone(confirm)
        self.assertTrue(
            run.complete_room_shell_confirm(
                confirm,  # type: ignore[arg-type]
                sent=True,
                detail="leave detached exact pet room shell",
            )
        )
        target = run.reserve_target_select(foreground=True)
        self.assertIsNotNone(target)
        self.assertTrue(
            run.complete_target_select(
                target,  # type: ignore[arg-type]
                sent=True,
                detail="exact pet 1289 after shell exit",
            )
        )
        self.assertTrue(run.observe_return_lobby(BossLobbyState.BOSS_LOBBY))
        records = [
            item
            for item in run.input_records
            if item.domain
            in {
                FarmInputDomain.BOSS_ROOM_SHELL_EXIT,
                FarmInputDomain.BOSS_ROOM_SHELL_CONFIRM,
                FarmInputDomain.BOSS_TARGET_SELECT,
            }
        ]
        self.assertEqual(
            [item.domain for item in records],
            [
                FarmInputDomain.BOSS_ROOM_SHELL_EXIT,
                FarmInputDomain.BOSS_ROOM_SHELL_CONFIRM,
                FarmInputDomain.BOSS_TARGET_SELECT,
            ],
        )
        self.assertTrue(all(item.sent for item in records))
        self.assertEqual(run.snapshot().total_lobby_inputs, 4)

    def test_detached_room_shell_confirm_requires_one_exit_and_is_single_use(self) -> None:
        run = start_run()
        enter(run, session(1))
        self.assertTrue(run.normal_combat_ended(MatchResult.WIN))
        self.assertTrue(run.observe_postmatch())

        self.assertIsNone(run.reserve_room_shell_confirm(foreground=True))
        self.assertEqual(run.stop_reason, FarmRunStopReason.RETURN_LOBBY_TIMEOUT)

        run = start_run()
        enter(run, session(1))
        self.assertTrue(run.normal_combat_ended(MatchResult.WIN))
        self.assertTrue(run.observe_postmatch())
        shell = run.reserve_room_shell_exit(foreground=True)
        self.assertIsNotNone(shell)
        self.assertTrue(run.complete_room_shell_exit(shell, sent=True))  # type: ignore[arg-type]
        confirm = run.reserve_room_shell_confirm(foreground=True)
        self.assertIsNotNone(confirm)
        self.assertTrue(run.complete_room_shell_confirm(confirm, sent=True))  # type: ignore[arg-type]
        self.assertIsNone(run.reserve_room_shell_confirm(foreground=True))
        self.assertEqual(run.stop_reason, FarmRunStopReason.RETURN_LOBBY_TIMEOUT)

    def test_duplicate_detached_room_shell_exit_fails_closed(self) -> None:
        run = start_run()
        enter(run, session(1))
        self.assertTrue(run.normal_combat_ended(MatchResult.WIN))
        self.assertTrue(run.observe_postmatch())
        permit = run.reserve_room_shell_exit(foreground=True)
        self.assertIsNotNone(permit)
        self.assertTrue(
            run.complete_room_shell_exit(permit, sent=True)  # type: ignore[arg-type]
        )

        self.assertIsNone(run.reserve_room_shell_exit(foreground=True))
        self.assertEqual(run.stop_reason, FarmRunStopReason.RETURN_LOBBY_TIMEOUT)

    def test_direct_map_proof_can_replace_shell_confirm_but_is_explicit(self) -> None:
        run = start_run()
        enter(run, session(1))
        self.assertTrue(run.normal_combat_ended(MatchResult.WIN))
        self.assertTrue(run.observe_postmatch())
        shell = run.reserve_room_shell_exit(foreground=True)
        self.assertIsNotNone(shell)
        self.assertTrue(run.complete_room_shell_exit(shell, sent=True))  # type: ignore[arg-type]
        target = run.reserve_target_select(
            foreground=True,
            direct_map_after_shell_exit=True,
        )
        self.assertIsNotNone(target)
        self.assertTrue(run.complete_target_select(target, sent=True))  # type: ignore[arg-type]

        run = start_run()
        enter(run, session(1))
        self.assertTrue(run.normal_combat_ended(MatchResult.WIN))
        self.assertTrue(run.observe_postmatch())
        shell = run.reserve_room_shell_exit(foreground=True)
        self.assertIsNotNone(shell)
        self.assertTrue(run.complete_room_shell_exit(shell, sent=True))  # type: ignore[arg-type]
        self.assertIsNone(run.reserve_target_select(foreground=True))
        self.assertEqual(run.stop_reason, FarmRunStopReason.RETURN_LOBBY_TIMEOUT)

    def test_duplicate_map_target_select_fails_closed(self) -> None:
        run = start_run()
        enter(run, session(1))
        self.assertTrue(run.normal_combat_ended(MatchResult.WIN))
        self.assertTrue(run.observe_postmatch())
        permit = run.reserve_target_select(foreground=True)
        self.assertIsNotNone(permit)
        self.assertTrue(run.complete_target_select(permit, sent=True))  # type: ignore[arg-type]

        self.assertIsNone(run.reserve_target_select(foreground=True))
        self.assertEqual(run.stop_reason, FarmRunStopReason.RETURN_LOBBY_TIMEOUT)

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

    def test_transient_pass_preflight_can_release_zero_input_permit(self) -> None:
        run = start_run()
        key = session(1)
        enter(run, key)
        capability = FarmRunGameplayCapability(run, key)
        permit = capability.reserve(action="PASS", session=key, foreground=True)
        self.assertIsNotNone(permit)
        self.assertTrue(
            capability.abandon_pass_preflight(  # type: ignore[arg-type]
                permit,
                detail="transient board-only participant gap",
            )
        )
        self.assertEqual(run.state, FarmRunState.COMBAT_ACTIVE)
        self.assertIsNone(run.stop_reason)
        self.assertEqual(run.snapshot().total_gameplay_inputs, 0)
        self.assertEqual(run.snapshot().safety.nonzero(), {})

        next_permit = capability.reserve(
            action="SWAP", session=key, foreground=True
        )
        self.assertIsNotNone(next_permit)
        self.assertTrue(
            capability.complete(  # type: ignore[arg-type]
                next_permit,
                sent=True,
                detail="fresh recomputed swap",
            )
        )

    def test_transient_physical_preflight_can_release_unsent_permit(self) -> None:
        run = start_run()
        key = session(1)
        enter(run, key)
        capability = FarmRunGameplayCapability(run, key)
        permit = capability.reserve(action="SWAP", session=key, foreground=True)
        self.assertIsNotNone(permit)
        self.assertTrue(
            capability.abandon_gameplay_preflight(  # type: ignore[arg-type]
                permit,
                detail="turn changed before Windows input",
            )
        )
        self.assertEqual(run.state, FarmRunState.COMBAT_ACTIVE)
        self.assertIsNone(run.stop_reason)
        self.assertEqual(run.snapshot().total_gameplay_inputs, 0)
        self.assertEqual(run.snapshot().safety.nonzero(), {})

        replacement = capability.reserve(
            action="SWAP", session=key, foreground=True
        )
        self.assertIsNotNone(replacement)

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
    def test_missed_opening_can_abort_only_untouched_wait_opening_attempt(self) -> None:
        run = start_run(FarmRunLimits(3, 1, 5))
        key = session(1)
        self.assertTrue(run.target_resolved())
        capability = FarmRunEntryCapability(run)
        permit = capability.reserve(foreground=True)
        self.assertIsNotNone(permit)
        self.assertTrue(
            capability.complete(permit, sent=True, detail="Start:SENT")  # type: ignore[arg-type]
        )
        self.assertTrue(run.accept_session(key))
        self.assertEqual(run.state, FarmRunState.WAIT_OPENING)

        self.assertTrue(
            run.technical_failure("ENTRY_OPENING_TIMEOUT_ACTIVE_COMBAT")
        )
        snapshot = run.snapshot()
        self.assertEqual(snapshot.state, FarmRunState.RECOVERY_PENDING)
        self.assertEqual(snapshot.match_attempts, 1)
        self.assertEqual(snapshot.completed_matches, 0)
        self.assertEqual(snapshot.technical_aborts, 1)
        self.assertEqual(snapshot.attempts[0].result, MatchResult.TECHNICAL_ABORT)
        self.assertEqual(snapshot.total_gameplay_inputs, 0)
        self.assertEqual(snapshot.safety.nonzero(), {})

    def test_other_technical_reason_cannot_abort_wait_opening(self) -> None:
        run = start_run(FarmRunLimits(3, 1, 5))
        key = session(1)
        self.assertTrue(run.target_resolved())
        capability = FarmRunEntryCapability(run)
        permit = capability.reserve(foreground=True)
        self.assertIsNotNone(permit)
        self.assertTrue(
            capability.complete(permit, sent=True, detail="Start:SENT")  # type: ignore[arg-type]
        )
        self.assertTrue(run.accept_session(key))

        self.assertFalse(run.technical_failure("DEAD_BOARD_NO_REFRESH"))
        snapshot = run.snapshot()
        self.assertEqual(snapshot.state, FarmRunState.WAIT_OPENING)
        self.assertEqual(snapshot.technical_aborts, 0)
        self.assertEqual(snapshot.attempts[0].result, MatchResult.UNKNOWN)

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

    def test_actionability_state_loss_uses_same_bounded_recovery_path(self) -> None:
        run = self._recovery_resume("ACTIONABILITY_STATE_LOST")
        snapshot = run.snapshot()
        self.assertEqual(snapshot.technical_aborts, 1)
        self.assertEqual(snapshot.technical_recoveries, 1)
        self.assertTrue(snapshot.attempts[0].technical_recovery)

    def test_controller_stall_uses_same_bounded_recovery_path(self) -> None:
        run = self._recovery_resume("CONTROLLER_STALLED_ACTIVE_COMBAT")
        snapshot = run.snapshot()
        self.assertEqual(snapshot.technical_aborts, 1)
        self.assertEqual(snapshot.technical_recoveries, 1)
        self.assertTrue(snapshot.attempts[0].technical_recovery)

    def test_active_combat_progress_stall_uses_same_unbounded_recovery_path(self) -> None:
        run = self._recovery_resume("ACTIVE_COMBAT_PROGRESS_STALLED")
        snapshot = run.snapshot()
        self.assertEqual(snapshot.technical_aborts, 1)
        self.assertEqual(snapshot.technical_recoveries, 1)
        self.assertTrue(snapshot.attempts[0].technical_recovery)

    def test_local_player_left_uses_same_bounded_recovery_path(self) -> None:
        run = self._recovery_resume("LOCAL_PLAYER_LEFT_ACTIVE_COMBAT")
        snapshot = run.snapshot()
        self.assertEqual(snapshot.technical_aborts, 1)
        self.assertEqual(snapshot.technical_recoveries, 1)
        self.assertTrue(snapshot.attempts[0].technical_recovery)

    def test_late_mandatory_reset_uses_same_bounded_recovery_path(self) -> None:
        run = self._recovery_resume("LATE_MANDATORY_RESET")
        snapshot = run.snapshot()
        self.assertEqual(snapshot.technical_aborts, 1)
        self.assertEqual(snapshot.technical_recoveries, 1)
        self.assertTrue(snapshot.attempts[0].technical_recovery)

    def test_second_failure_remains_recoverable_after_legacy_limit(self) -> None:
        run = self._recovery_resume("SEQUENCE_DESYNC")
        current = run.current_session
        assert current is not None
        next_session = session(3)
        self.assertTrue(run.technical_failure("DEAD_BOARD_NO_REFRESH"))
        self.assertTrue(run.begin_recovery())
        recovery = complete_recovery_coordinator(current, next_session)
        self.assertTrue(
            run.record_successful_recovery(recovery.snapshot().input_records)
        )
        snapshot = run.snapshot()
        self.assertIsNone(snapshot.stop_reason)
        self.assertEqual(snapshot.technical_aborts, 2)
        self.assertEqual(snapshot.technical_recoveries, 2)
        self.assertEqual(snapshot.total_recovery_inputs, 6)

    def test_two_recoveries_validate_each_invocation_even_with_legacy_limit_one(self) -> None:
        run = start_run(FarmRunLimits(3, 1, 5))
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
