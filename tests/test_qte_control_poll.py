from dataclasses import replace
from types import SimpleNamespace
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.combat_lifecycle import (
    CombatLifecycleState, CombatLifecycleObservation, CombatLifecycleSignals,
    CombatSessionTracker,
)
from pokiguard_v2.il2cpp_layout import LayoutValidationError
from pokiguard_v2.memory_board_provider import MemoryBoardStateProvider, ProviderPoll
from pokiguard_v2.pet_skill_action import (
    PetSkillActionExecutor,
    PetSkillActionResultKind,
    PetSkillActionState,
    QteSpaceInputExecutor,
)
from pokiguard_v2.qte_direction_assist import QteDirectionAssist, QteDirectionInputExecutor
from pokiguard_v2.pet_skill_shadow import QteDirection, QteTimingResult
from pokiguard_v2.pet_skill_shadow import QteObserver
from pokiguard_v2.pet_qte_observer import BoundQteObservation, QteBindingStatus
from pokiguard_v2.state import GameState, GamePhase, ParticipantState
from tools.pet_qte_observer import (
    DISPATCHER_RESULT_EXCLUSIVE_WINDOW_SECONDS,
    _defer_heap_result_scan,
    _offer_dispatcher_raw_qte_board_snapshot,
    _offer_qte_result_board_snapshot,
    _participant_snapshot,
    _poll_provider,
    _poll_delay,
    _requires_full_qte_result_scan,
    _notify_explicit_server_reject,
)
from tools.pet_skill_action import Phase3b3RuntimeHook, build_parser
from tests.test_pet_skill_action import (
    SESSION_A, SESSION_B, BINDING, FakeInputBackend, FakeMouse, observation, qte, capability, card,
    executor, begin_and_bind, finish_directions,
)
from tests.test_basic_policy import combat_state


def hook_for(action):
    hook = Phase3b3RuntimeHook(direction_ack_timeout_seconds=1.25,
        qte_generation_timeout_seconds=3, result_timeout_seconds=5, post_state_timeout_seconds=4)
    hook._executor = action
    return hook


class QteControlPollTests(unittest.TestCase):
    def setUp(self):
        self.provider = p = object.__new__(MemoryBoardStateProvider)
        p.target = Mock()
        p.target.is_running.return_value = True
        p.target.resolver.read_i32.return_value = 11
        p._lifecycle_tracker = CombatSessionTracker()
        p._lifecycle_tracker.observe(CombatLifecycleState.ACTIVE, SESSION_A.board_instance, SESSION_A.match_id)
        self.board = SimpleNamespace(accepted=True, board_instance=SESSION_A.board_instance,
            active=0x9000, is_game_over=False, is_board_ready=True,
            is_cascade_running=False, current_state=1, is_processing_ui=False, is_resuming=False)
        p._resolve_board = Mock(return_value=self.board)
        p._resolve_match_service = Mock(return_value=0xA000)
        p._read_string_field = Mock(return_value=SESSION_A.match_id)
        self.signals = SimpleNamespace(local_username="local", connection_ready=True,
            reconnecting=False, match_resyncing=False, match_over=False, deferred_game_over=False,
            is_local_turn=lambda _: True, in_flight_batches=0, clock_paused=False,
            start_gate_paused=False)
        p._read_action_signals = Mock(return_value=self.signals)
        self.lifecycle = CombatLifecycleObservation(CombatLifecycleState.ACTIVE,
            CombatLifecycleSignals(), "test_current")
        prefix = "pokiguard_v2.memory_board_provider."
        for name, value in (("read_combat_lifecycle", self.lifecycle),
                            ("read_match_local_actor_number", 1),
                            ("read_left_actor_numbers", SimpleNamespace(actor_numbers=()))):
            patcher = patch(prefix + name, return_value=value)
            setattr(self, name, patcher.start())
            self.addCleanup(patcher.stop)

    def test_one_shot_cli_allows_delayed_server_and_full_skill_resolution(self):
        args = build_parser().parse_args(["--execute-once"])
        self.assertEqual(args.result_timeout, 15.0)
        self.assertEqual(args.post_state_timeout, 30.0)

    def test_fresh_control_has_no_board_cards_or_publication(self):
        p = self.provider
        p.poll = Mock(side_effect=AssertionError("full poll prohibited"))
        result = p.poll_qte_control(SESSION_A)
        self.assertEqual(result.reason, "qte_control_only")
        self.assertFalse(result.publish)
        self.assertIsNone(result.state)
        self.assertFalse(result.control_battle.stable)
        self.assertEqual(result.control_battle.local_actor_number, 1)
        self.assertEqual(result.control_battle.session_key, SESSION_A)
        self.assertTrue(result.control_battle.is_board_ready)
        self.assertEqual(result.control_battle.board_current_state, 1)
        self.assertFalse(result.control_battle.is_cascade_running)
        self.assertFalse(result.control_battle.board_is_processing_ui)
        self.assertFalse(result.control_battle.board_is_resuming)
        self.assertFalse(result.control_battle.presentation_busy)
        self.assertFalse(result.control_battle.clock_paused)
        self.assertFalse(result.control_battle.start_gate_paused)
        self.assertEqual(p._resolve_board.call_count, 2)

    def test_missing_session_does_not_read_stale_roots(self):
        result = self.provider.poll_qte_control(SESSION_B)
        self.assertIsNone(result.control_battle)
        self.provider._resolve_board.assert_not_called()

    def test_game_exit(self):
        self.provider.target.is_running.return_value = False
        self.assertIsNone(self.provider.poll_qte_control(SESSION_A).control_battle)

    def test_lifecycle_exit_or_read_error_never_authorizes(self):
        for lifecycle in (replace(self.lifecycle, state=CombatLifecycleState.LEAVING),
                          replace(self.lifecycle, signals=CombatLifecycleSignals(read_errors=("torn",)))):
            with self.subTest(lifecycle=lifecycle):
                self.provider._lifecycle_tracker = CombatSessionTracker()
                self.provider._lifecycle_tracker.observe(CombatLifecycleState.ACTIVE, SESSION_A.board_instance, "M_A")
                self.read_combat_lifecycle.return_value = lifecycle
                result = self.provider.poll_qte_control(SESSION_A)
                self.assertIsNone(result.control_battle)
                self.assertIsNone(result.session_key)
                if lifecycle.signals.read_errors:
                    self.assertEqual(
                        self.provider._lifecycle_tracker.session,
                        SESSION_A,
                    )
                else:
                    self.assertIsNone(self.provider._lifecycle_tracker.session)

    def test_owner_or_turn_changes_during_read(self):
        changed = SimpleNamespace(**{**vars(self.board), "active":0x9900})
        self.provider._resolve_board.side_effect = [self.board, changed]
        self.assertIsNone(self.provider.poll_qte_control(SESSION_A).control_battle)
        self.provider._resolve_board.side_effect = None
        self.provider.target.resolver.read_i32.side_effect = [11, 12]
        self.assertIsNone(self.provider.poll_qte_control(SESSION_A).control_battle)

    def test_connection_unknown_disconnected_or_recovering(self):
        for field, value in (("connection_ready", None), ("connection_ready", False),
                             ("reconnecting", True), ("match_resyncing", True)):
            with self.subTest(field=field, value=value):
                changed = SimpleNamespace(**{**vars(self.signals), field:value})
                self.provider._read_action_signals.return_value = changed
                self.assertIsNone(self.provider.poll_qte_control(SESSION_A).control_battle)

    def test_actor_unknown_or_membership_torn(self):
        self.read_match_local_actor_number.return_value = None
        self.assertIsNone(self.provider.poll_qte_control(SESSION_A).control_battle)
        self.read_match_local_actor_number.return_value = 1
        self.read_left_actor_numbers.side_effect = LayoutValidationError("torn membership")
        self.assertIsNone(self.provider.poll_qte_control(SESSION_A).control_battle)

    def test_local_left_signal_is_fresh(self):
        self.read_left_actor_numbers.return_value = SimpleNamespace(actor_numbers=(1,))
        result = self.provider.poll_qte_control(SESSION_A)
        self.assertTrue(result.control_battle.local_has_left_match)


class QteCriticalSchedulingTests(unittest.TestCase):
    def test_dispatcher_exclusive_window_preserves_owner_batch_sampling(self):
        self.assertEqual(DISPATCHER_RESULT_EXCLUSIVE_WINDOW_SECONDS, 3.0)
        self.assertTrue(_defer_heap_result_scan(
            dispatcher_available=True,
            dispatcher_result_count=0,
            completion_epoch=100.0,
            observed_epoch=102.999,
        ))
        self.assertFalse(_defer_heap_result_scan(
            dispatcher_available=True,
            dispatcher_result_count=1,
            completion_epoch=100.0,
            observed_epoch=100.5,
        ))
        self.assertFalse(_defer_heap_result_scan(
            dispatcher_available=True,
            dispatcher_result_count=0,
            completion_epoch=100.0,
            observed_epoch=103.0,
        ))
        self.assertFalse(_defer_heap_result_scan(
            dispatcher_available=False,
            dispatcher_result_count=0,
            completion_epoch=100.0,
            observed_epoch=100.5,
        ))

    def test_input_free_control_read_failure_keeps_exact_watch_session(self):
        action, mouse, backend = executor()
        hook = hook_for(action)
        hook._latest_context = {"session": SESSION_A}
        emitted = []
        hook._emit = lambda event, **values: emitted.append((event, values))

        self.assertTrue(
            hook.retain_pre_action_after_control_read_failure(
                "qte_control_rejected:QTE control read changed during sample"
            )
        )
        self.assertEqual(hook.pre_action_watch_session, SESSION_A)
        self.assertFalse(hook.done)
        self.assertEqual((mouse.points, backend.keys), ([], []))
        self.assertEqual(emitted[-1][0], "pet_skill_pre_action_control_read_retry")
        self.assertFalse(emitted[-1][1]["fullProviderFallback"])

    def test_input_free_runtime_and_actor_torn_reads_keep_exact_watch_session(self):
        for reason in (
            "QTE_CURRENT_RUNTIME_UNREADABLE",
            "QTE_CURRENT_ACTOR_UNREADABLE",
        ):
            with self.subTest(reason=reason):
                action, mouse, backend = executor()
                hook = hook_for(action)
                hook._latest_context = {"session": SESSION_A}

                self.assertTrue(
                    hook.retain_pre_action_after_transient_read_failure(reason)
                )
                self.assertEqual(hook.pre_action_watch_session, SESSION_A)
                self.assertFalse(hook.done)
                self.assertEqual((mouse.points, backend.keys), ([], []))

    def test_control_read_failure_is_terminal_after_click_or_session_loss(self):
        action, _, _ = executor()
        hook = hook_for(action)
        hook._latest_context = {"session": SESSION_A}
        self.assertFalse(
            hook.retain_pre_action_after_control_read_failure(
                "qte_control_session_not_owned"
            )
        )
        begin_and_bind(action)
        self.assertIsNotNone(action.telemetry.card_click_timestamp)
        self.assertFalse(
            hook.retain_pre_action_after_transient_read_failure(
                "QTE_CURRENT_ACTOR_UNREADABLE"
            )
        )

    @patch("tools.pet_qte_observer.read_active_participants")
    def test_torn_resource_read_never_authorizes_from_board_fallback(self, read):
        read.side_effect = LayoutValidationError("playerStatsMap changed during read")
        fallback = SimpleNamespace(
            player=ParticipantState(
                actor_number=1,
                is_local=True,
                mana=999,
                power=250,
                hp=100,
                max_hp=100,
                source="older board snapshot",
            ),
            opponents=(),
            battle=SimpleNamespace(board_hash="old"),
        )

        sample = _participant_snapshot(
            SimpleNamespace(memory=Mock()),
            active_instance=0x9000,
            stats_class=0xA000,
            local_actor_number=1,
            fallback_state=fallback,
        )

        self.assertFalse(sample["resourceCurrent"])
        self.assertIsNone(sample["mana"])
        self.assertIsNone(sample["power"])
        self.assertIn("playerStatsMap changed", sample["resourceReadError"])

    @patch("tools.pet_qte_observer.read_active_participants")
    def test_fresh_resource_read_records_exact_source(self, read):
        read.return_value = (
            ParticipantState(
                actor_number=1,
                is_local=True,
                mana=640,
                power=250,
                source="Active.playerStatsMap/ObfuscatedInt.Value",
            ),
        )

        sample = _participant_snapshot(
            SimpleNamespace(memory=Mock()),
            active_instance=0x9000,
            stats_class=0xA000,
            local_actor_number=1,
            fallback_state=None,
        )

        self.assertTrue(sample["resourceCurrent"])
        self.assertEqual((sample["mana"], sample["power"]), (640, 250))
        self.assertEqual(
            sample["resourceSource"],
            "Active.playerStatsMap/ObfuscatedInt.Value",
        )
        self.assertIsNone(sample["resourceReadError"])

    def test_zero_input_turn_boundary_preflight_is_rearmed(self):
        action, mouse, backend = executor()
        action.begin(observation(), monotonic_now=0)
        action.step(
            observation(.05, is_local_turn=False),
            monotonic_now=.05,
        )
        self.assertIs(action.result.kind, PetSkillActionResultKind.PREFLIGHT_REJECTED)
        self.assertEqual(action.result.reason, "FINAL_CARD_LOCAL_TURN_NOT_ACTIONABLE")
        hook = hook_for(action)
        hook._invocation_consumed = True
        replacement, _, _ = executor()
        hook._executor_factory = lambda: replacement
        emitted = []
        hook._emit = lambda event, **values: emitted.append((event, values))

        self.assertTrue(hook._rearm_after_zero_input_preflight_race(action))
        self.assertIs(hook._executor, replacement)
        self.assertFalse(hook._invocation_consumed)
        self.assertFalse(hook.done)
        self.assertEqual((mouse.points, backend.keys), ([], []))
        self.assertEqual(emitted[-1][0], "pet_skill_action_preflight_rearmed")

    def test_zero_input_torn_native_hand_final_preflight_is_rearmed(self):
        action, mouse, backend = executor()
        action.begin(observation(), monotonic_now=0)
        action.step(
            observation(
                .05,
                capability=None,
                live_card=None,
                geometry=None,
            ),
            monotonic_now=.05,
        )
        self.assertIs(action.result.kind, PetSkillActionResultKind.PREFLIGHT_REJECTED)
        self.assertEqual(
            action.result.reason,
            "FINAL_CARD_CURRENT_PET_SKILL_CAPABILITY_MISSING",
        )
        hook = hook_for(action)
        hook._invocation_consumed = True
        hook._latest_context = {
            "session": SESSION_A,
            "card_diagnostics": {
                "nativeCardDiscoveryReason": (
                    "pet_skill_control_read_error:native_card_ui: "
                    "geometry changed during walk"
                ),
            },
        }
        replacement, _, _ = executor()
        hook._executor_factory = lambda: replacement
        emitted = []
        hook._emit = lambda event, **values: emitted.append((event, values))

        self.assertTrue(hook._rearm_after_zero_input_preflight_race(action))
        self.assertIs(hook._executor, replacement)
        self.assertFalse(hook._invocation_consumed)
        self.assertEqual((mouse.points, backend.keys), ([], []))
        self.assertIn(
            "geometry changed during walk",
            emitted[-1][1]["nativeCardDiscoveryReason"],
        )

    def test_missing_capability_without_native_reader_error_remains_terminal(self):
        action, _, _ = executor()
        action.begin(observation(), monotonic_now=0)
        action.step(
            observation(.05, capability=None, live_card=None, geometry=None),
            monotonic_now=.05,
        )
        hook = hook_for(action)
        hook._invocation_consumed = True
        hook._latest_context = {
            "session": SESSION_A,
            "card_diagnostics": {"nativeCardDiscoveryReason": "no_skill_card"},
        }
        replacement, _, _ = executor()
        hook._executor_factory = lambda: replacement

        self.assertFalse(hook._rearm_after_zero_input_preflight_race(action))
        self.assertIs(hook._executor, action)

    def test_preflight_rearm_never_applies_after_any_input_or_other_failure(self):
        action, mouse, backend = executor()
        begin_and_bind(action)
        action.abort(monotonic_now=.2, reason="TEST_ABORT")
        hook = hook_for(action)
        replacement, _, _ = executor()
        hook._executor_factory = lambda: replacement

        self.assertFalse(hook._rearm_after_zero_input_preflight_race(action))
        self.assertIs(hook._executor, action)
        self.assertEqual(len(mouse.points), 1)
        self.assertEqual(backend.keys, [])

    def test_pre_action_stage_stall_revokes_authority_without_input(self):
        action, mouse, backend = executor()
        hook = hook_for(action)
        hook._latest_context = {"session": SESSION_A}
        emitted = []
        hook._emit = lambda event, **values: emitted.append((event, values))

        with patch("tools.pet_skill_action.time.monotonic", return_value=1.0):
            hook.trace_stage("provider_poll_begin")
        self.assertTrue(hook._check_stage_stall(3.01))

        self.assertTrue(hook.done)
        self.assertEqual(hook.summary["reason"], "OBSERVER_STAGE_STALLED:provider_poll")
        self.assertEqual(mouse.points, [])
        self.assertEqual(backend.keys, [])
        self.assertEqual(emitted[-1][0], "pet_skill_action_stage_stalled")
        self.assertTrue(emitted[-1][1]["failClosed"])

    def test_stage_watchdog_ignores_lobby_and_subthreshold_reads(self):
        action, _, _ = executor()
        hook = hook_for(action)
        with patch("tools.pet_skill_action.time.monotonic", return_value=1.0):
            hook.trace_stage("provider_poll_begin")
        self.assertFalse(hook._check_stage_stall(10.0))  # no current session
        hook._latest_context = {"session": SESSION_A}
        self.assertFalse(hook._check_stage_stall(2.99))
        self.assertFalse(hook.done)

    def test_routing_is_scoped_to_owned_action_not_basic_or_readonly(self):
        p = Mock()
        p.refresh_pet_skill_cards.return_value = ()
        p.scan_diagnostics = {"nativeCardDiscoveryReason": "validated"}
        action, _, _ = executor()
        hook = hook_for(action)
        self.assertFalse(_poll_provider(p, None)[1])
        self.assertFalse(_poll_provider(p, hook)[1])
        action.begin(observation(), monotonic_now=0)
        # The second, still input-free card preflight must preserve exact combat
        # ownership without depending on full board/batch publication.
        self.assertEqual(hook.pre_action_watch_session, SESSION_A)
        self.assertTrue(_poll_provider(p, hook)[1])
        p.refresh_pet_skill_cards.assert_called_once_with(SESSION_A)
        p.poll_qte_control.assert_called_once_with(SESSION_A)
        p.poll_qte_control.reset_mock()
        action.step(observation(.05), monotonic_now=.05)
        self.assertTrue(_poll_provider(p, hook)[1])
        p.poll_qte_control.assert_called_once_with(SESSION_A)
        action.abort(monotonic_now=.1)
        self.assertFalse(_poll_provider(p, hook)[1])

    def test_idle_harness_uses_native_card_control_refresh_after_session_known(self):
        provider = Mock()
        provider.refresh_pet_skill_cards.return_value = ()
        provider.scan_diagnostics = {
            "nativeCardDiscoveryReason": "pet_skill_not_unlocked_by_fusion"
        }
        provider.poll_qte_control.return_value = ProviderPoll(
            None,
            False,
            "qte_control_only",
            session_key=SESSION_A,
        )
        action, _, _ = executor()
        hook = hook_for(action)
        self.assertIsNone(hook.pre_action_watch_session)
        hook._latest_context = {"session": SESSION_A}

        result, control_only = _poll_provider(provider, hook)

        self.assertTrue(control_only)
        self.assertEqual(result.session_key, SESSION_A)
        provider.refresh_pet_skill_cards.assert_called_once_with(SESSION_A)
        provider.poll_qte_control.assert_called_once_with(SESSION_A)
        provider.poll.assert_not_called()

    def test_watch_poll_exposes_refresh_and_control_stage_boundaries(self):
        provider = Mock()
        provider.refresh_pet_skill_cards.return_value = ()
        provider.scan_diagnostics = {"nativeCardDiscoveryReason": "validated"}
        provider.poll_qte_control.return_value = ProviderPoll(
            None, False, "qte_control_only", session_key=SESSION_A
        )
        action, _, _ = executor()
        hook = hook_for(action)
        hook._latest_context = {"session": SESSION_A}
        hook.trace_stage = Mock()

        _poll_provider(provider, hook)

        self.assertEqual(
            [call.args[0] for call in hook.trace_stage.call_args_list],
            [
                "pet_skill_refresh_begin",
                "pet_skill_refresh_end",
                "qte_control_begin",
                "qte_control_end",
            ],
        )

    def test_control_refresh_telemetry_is_bounded_and_records_live_card(self):
        action, _, _ = executor()
        hook = hook_for(action)
        emitted = []
        hook._emit = lambda event, **values: emitted.append((event, values))
        live = card()

        with patch("tools.pet_skill_action.time.monotonic", side_effect=(1.0, 2.0, 6.1)):
            hook.pet_skill_control_refresh(
                (live,), reason="pet_skill_control_native_hand_validated", elapsed_ms=201.0
            )
            hook.pet_skill_control_refresh(
                (live,), reason="pet_skill_control_native_hand_validated", elapsed_ms=202.0
            )
            hook.pet_skill_control_refresh(
                (live,), reason="pet_skill_control_native_hand_validated", elapsed_ms=203.0
            )

        self.assertEqual([item[0] for item in emitted], [
            "pet_skill_control_refresh", "pet_skill_control_refresh"
        ])
        self.assertEqual(emitted[-1][1]["cards"], (live,))

    def test_fast_poll_stops_at_runtime_perfect_without_post_state_poll(self):
        action, _, _ = executor()
        finish_directions(action)
        obs = observation(1, qte=qte(index=2, elapsed=3.15))
        action.step(obs, monotonic_now=1)
        hook = hook_for(action)
        hook._last_observation = obs
        self.assertEqual(hook.critical_qte_session, SESSION_A)
        # Only read current CardUI completion; response capture is disabled.
        self.assertIsNone(hook.result_wait_session)
        hook._last_observation = replace(
            obs,
            qte=replace(
                obs.qte,
                completed=True,
                predicted_timing_result=QteTimingResult.PERFECT,
                runtime_display_result=QteTimingResult.PERFECT,
            ),
        )
        # Routing follows validated completion, not a relabelled last sample.
        self.assertEqual(hook.critical_qte_session, SESSION_A)
        action.step(hook._last_observation, monotonic_now=1.1)
        self.assertIsNone(hook.critical_qte_session)
        self.assertIsNone(hook.result_wait_session)
        self.assertIsNone(hook.post_qte_session)
        self.assertTrue(action.result.success)
        self.assertEqual(action.result.reason, "CURRENT_GENERATION_RUNTIME_PERFECT")

    def test_production_hook_never_arms_callback_tap(self):
        action, _, _ = executor()
        hook = hook_for(action)
        tap = Mock()
        hook._result_tap = tap

        hook._sync_result_tap()

        tap.disarm.assert_called_once_with()
        tap.arm.assert_not_called()

    def test_result_scan_rediscovery_cannot_be_permanently_confined_to_old_hints(self):
        expected_full = {1, 2, 8, 16}
        actual_full = {
            number
            for number in range(1, 18)
            if _requires_full_qte_result_scan(number, learned_region_count=10)
        }
        self.assertEqual(actual_full, expected_full)
        self.assertTrue(_requires_full_qte_result_scan(3, learned_region_count=0))
        with self.assertRaises(ValueError):
            _requires_full_qte_result_scan(0, learned_region_count=0)
        with self.assertRaises(ValueError):
            _requires_full_qte_result_scan(1, learned_region_count=-1)

    def test_seven_acknowledged_keys_and_one_space_without_full_scan(self):
        sequence = (QteDirection.LEFT, QteDirection.RIGHT, QteDirection.UP,
                    QteDirection.RIGHT, QteDirection.RIGHT, QteDirection.UP, QteDirection.LEFT)
        for start, end in ((3.0, 3.3), (2.4, 2.8)):
            with self.subTest(window=(start, end)):
                clock = [0.0]
                backend = FakeInputBackend()
                def key_press(key):
                    backend.keys.append(key)
                    clock[0] += .04  # accepted physical key hold; no actual input
                    return True
                backend.press_virtual_key = key_press
                action = PetSkillActionExecutor(FakeMouse(),
                    QteDirectionAssist(QteDirectionInputExecutor(backend), timestamp=lambda:clock[0]),
                    QteSpaceInputExecutor(backend), timestamp=lambda:clock[0])
                hook = hook_for(action)
                action.begin(observation(), monotonic_now=0)
                action.step(observation(.025), monotonic_now=.025)
                clock[0] = .05
                p = Mock()
                p.poll.side_effect = AssertionError("expensive full scan in QTE")
                while clock[0] < end and action.state is not PetSkillActionState.WAIT_RESULT:
                    self.assertTrue(_poll_provider(p, hook)[1])
                    # Next fresh RAM observation acknowledges exactly the sent keys.
                    index = len(backend.keys)
                    snap = qte(sequence=sequence, index=index, elapsed=clock[0],
                               perfect_start=start, perfect_end=end)
                    obs = observation(clock[0], qte=snap, inactive_qte_proven=False)
                    hook._last_observation = obs
                    action.step(obs, monotonic_now=clock[0])
                    clock[0] += _poll_delay(.025, hook)
                    if action.result is not None:
                        self.fail(action.result.reason)
                self.assertEqual(len(backend.keys), 8)
                self.assertEqual(backend.keys.count(0x20), 1)
                self.assertEqual(action.telemetry.direction_summary.directions_confirmed, 7)
                self.assertLess(action.telemetry.directions_complete_elapsed, 1.5)
                self.assertTrue(start <= action.telemetry.space_send_elapsed <= end)
                self.assertLess(abs(action.telemetry.confirm_target_error), .05)
                p.poll.assert_not_called()

    def test_lagging_unfinished_sequence_stops_at_perfect_deadline_keeps_records(self):
        action, _, backend = executor()
        begin_and_bind(action)
        action.step(observation(.15, qte=qte(index=0)), monotonic_now=.15)
        action.step(observation(.2, qte=qte(index=1, elapsed=3.5)), monotonic_now=.2)
        self.assertEqual(backend.keys, [0x26])
        self.assertEqual(action.result.reason, "PERFECT_WINDOW_MISSED_DURING_DIRECTIONS")
        self.assertIsNotNone(action.result.telemetry.direction_summary)
        self.assertTrue(any(e.direction_event for e in action.events))

    def test_expired_sample_no_arrow_and_frozen_clock_no_early_space(self):
        action, _, backend = executor()
        begin_and_bind(action)
        action.step(observation(.15, qte=qte()), monotonic_now=.6)
        self.assertEqual(backend.keys, [])
        self.assertEqual(action.result.reason, "QTE_CONTROL_SAMPLE_STALE")
        action, _, backend = executor()
        finish_directions(action)
        action.step(observation(1, qte=qte(index=2, elapsed=2.95)), monotonic_now=1.25)
        self.assertNotIn(0x20, backend.keys)  # projection 3.20 is not RAM Perfect

    def test_fresh_qte_cannot_restamp_old_lifecycle_sample(self):
        action, _, backend = executor()
        begin_and_bind(action)
        action.step(observation(1, qte=qte(), control_sampled_monotonic=.1), monotonic_now=1)
        self.assertEqual(backend.keys, [])
        self.assertEqual(action.result.reason, "QTE_CONTROL_SAMPLE_STALE")


class RuntimePerfectCompletionTests(unittest.TestCase):
    """The input primitive finishes at RAM Perfect; later gameplay is separate."""

    def setUp(self):
        self.action, self.mouse, self.backend = executor()
        finish_directions(self.action)
        self.action.step(observation(1, qte=qte(index=2, elapsed=3.15)), monotonic_now=1)
        self.completed = qte(index=2, elapsed=3.156, active=False, completed=True,
                             runtime=QteTimingResult.PERFECT, predicted=QteTimingResult.PERFECT)
        self.hook = hook_for(self.action)
        self.hook._last_observation = observation(1, qte=qte(index=2, elapsed=3.15))

    def complete(self):
        self.action.step(observation(1.1, qte=self.completed), monotonic_now=1.1)
        return self.action.result

    @staticmethod
    def inactive_snapshot():
        return QteObserver().observe(observed_at=101.3, session_key=SESSION_A,
            observation=BoundQteObservation(QteBindingStatus.INACTIVE,
                "current session has an inactive QTE baseline", None, None, None),
            capability=capability(), player_mana=50, player_power=50)

    def test_space_wait_reads_only_current_control_not_callback_or_board(self):
        provider = Mock()
        control = ProviderPoll(None, False, "qte_control_only",
                               session_key=SESSION_A, control_battle=Mock())
        provider.poll_qte_control.return_value = control

        result, critical = _poll_provider(provider, self.hook)

        self.assertTrue(critical)
        self.assertIs(result, control)
        self.assertFalse(self.hook.done)
        provider.poll_qte_control.assert_called_once_with(SESSION_A)
        provider.capture_transient_batches.assert_not_called()
        provider.poll.assert_not_called()

    def test_runtime_perfect_finishes_hook_without_post_state(self):
        accepted = self.complete()

        self.assertTrue(accepted.success)
        self.assertEqual(accepted.reason, "CURRENT_GENERATION_RUNTIME_PERFECT")
        self.assertIsNone(accepted.post_state)
        self.assertFalse(accepted.telemetry.server_response_correlated)
        self.assertTrue(self.hook.done)
        self.assertFalse(self.action.active)
        self.assertIsNone(self.hook.critical_qte_session)
        self.assertIsNone(self.hook.result_wait_session)
        self.assertIsNone(self.hook.post_qte_session)
        self.assertIsNone(self.hook.pre_action_watch_session)

    def test_missing_board_past_old_deadline_cannot_change_completed_action(self):
        accepted = self.complete()
        before = list(self.backend.keys)
        for now in (1.3, 16.3, 31.2, 100.0):
            self.action.step(observation(now, qte=self.inactive_snapshot()),
                             monotonic_now=now)

        self.assertIs(self.action.result, accepted)
        self.assertEqual(self.backend.keys, before)
        self.assertEqual(len(self.mouse.points), 1)

    def test_late_callback_and_reject_cannot_reopen_completed_action(self):
        accepted = self.complete()
        self.hook.correlated_result(
            replace(self.completed, server_response_correlated=True),
            sampled_monotonic=1.2, game_state=None, resources={},
            runtime=None, control_battle=None)
        _notify_explicit_server_reject(
            self.hook,
            SimpleNamespace(provenance="EXPLICIT_REJECT", reason="late callback"),
            SimpleNamespace(address=0x1234))

        self.assertIs(self.action.result, accepted)
        self.assertFalse(accepted.telemetry.server_reject_observed)
        self.assertEqual(self.backend.keys.count(0x20), 1)

    def test_completed_action_cannot_send_input_for_a_new_generation(self):
        accepted = self.complete()
        before = list(self.backend.keys)
        self.action.step(
            observation(1.3, qte=qte(generation=2)),
            monotonic_now=1.3)
        self.hook.stop("HARNESS_EXIT")

        self.assertIs(self.action.result, accepted)
        self.assertEqual(self.backend.keys, before)
        self.assertEqual(len(self.mouse.points), 1)

    def test_stale_or_other_generation_perfect_cannot_complete_current_action(self):
        for snap in (
            replace(self.completed, identity=qte(generation=2).identity, qte_generation=2),
            qte(index=2, session=SESSION_B, completed=True, runtime=QteTimingResult.PERFECT),
            replace(self.completed, correct_count=1),
            replace(self.completed, ownership_status=QteBindingStatus.WRONG_OWNER),
        ):
            with self.subTest(snapshot=snap):
                self.setUp()
                self.action.step(observation(1.1, qte=snap), monotonic_now=1.1)
                self.assertIsNotNone(self.action.result)
                self.assertFalse(self.action.result.success)
                self.assertEqual(self.backend.keys.count(0x20), 1)

    def test_inactive_without_bound_runtime_completion_still_rejects(self):
        self.action.step(observation(1.3, qte=self.inactive_snapshot()), monotonic_now=1.3)

        self.assertEqual(self.action.result.reason, "QTE_GENERATION_CHANGED_OR_STALE")
        self.assertEqual(self.backend.keys.count(0x20), 1)

    def test_pre_space_control_loss_is_never_retained_as_terminal_wait(self):
        action, _, _ = executor()
        action.begin(observation(), monotonic_now=0.0)
        action.step(observation(0.05), monotonic_now=0.05)
        hook = hook_for(action)
        hook._target = SimpleNamespace(is_running=lambda: True)

        self.assertFalse(hook.retain_post_space_after_control_read_failure(
            "qte_control_rejected:QTE lifecycle changed or unreadable"))


class DiagnosticCallbackBoardTests(unittest.TestCase):
    """Read-only observer helpers remain available outside the action contract."""

    @patch("tools.pet_qte_observer.read_match_payload_board_snapshot")
    def test_correlated_skill_response_board_is_offered_to_normal_ack_gate(
        self, decode
    ):
        snapshot = SimpleNamespace(sequence=44, cells=tuple(range(64)))
        decode.return_value = snapshot
        target = SimpleNamespace(memory=Mock())
        provider = Mock()
        provider.offer_transport_board_snapshot.return_value = True
        result = SimpleNamespace(
            event_type="MATCH_SKILL_USE_RES",
            match_id="M_A",
            address=0x1234,
            payload_address=0x5678,
        )

        actual, accepted = _offer_qte_result_board_snapshot(
            target,
            provider,
            result,
            classes=Mock(),
        )

        self.assertIs(actual, snapshot)
        self.assertTrue(accepted)
        decode.assert_called_once_with(
            target.memory,
            match_id="M_A",
            message_address=0x1234,
            payload_address=0x5678,
            classes=decode.call_args.kwargs["classes"],
            event_type="MATCH_SKILL_USE_RES",
        )
        provider.offer_transport_board_snapshot.assert_called_once_with(
            snapshot,
            event_type="MATCH_SKILL_USE_RES",
        )

    def test_callback_json_board_is_bound_to_exact_decoded_response(self):
        provider = Mock()
        provider.offer_transport_board_snapshot.return_value = True
        result = SimpleNamespace(
            event_type="MATCH_SKILL_USE_RES",
            match_id="M_A",
            address=0x1234,
        )
        snapshot = SimpleNamespace(
            match_id="M_A",
            message_address=0x1234,
        )

        actual, accepted = _offer_dispatcher_raw_qte_board_snapshot(
            provider, result, snapshot
        )

        self.assertIs(actual, snapshot)
        self.assertTrue(accepted)
        provider.offer_transport_board_snapshot.assert_called_once_with(
            snapshot,
            event_type="MATCH_SKILL_USE_RES",
        )
        with self.assertRaises(LayoutValidationError):
            _offer_dispatcher_raw_qte_board_snapshot(
                provider,
                result,
                SimpleNamespace(match_id="M_old", message_address=0x1234),
            )


if __name__ == "__main__":
    unittest.main()
