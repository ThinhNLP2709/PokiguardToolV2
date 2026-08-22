from __future__ import annotations

from dataclasses import replace
from types import SimpleNamespace
import unittest
from unittest.mock import patch

from pokiguard_v2.autonomous_control import (
    ActionResultKind,
    AutonomousActionIdentity,
    AutonomousGuard,
    AutonomousSource,
    AutonomousStatus,
    ConsumingTurnRegistry,
    PendingAutonomousAction,
    TurnTransitionKind,
    TurnTransitionTracker,
    direct_runtime_proves_cast_accepted,
    direct_runtime_proves_swap_accepted,
    plan_action_response_wait,
)
from pokiguard_v2.authoritative_pass import (
    AuthoritativePassCoordinator,
    PassResultKind,
)
from pokiguard_v2.basic_policy import (
    BasicPolicyEngine,
    ManaPriority,
    PolicyAction,
    PolicyConfig,
)
from pokiguard_v2.combat_lifecycle import CombatLifecycleState
from pokiguard_v2.gameplay_ui import (
    GameplayControl,
    locate_gameplay_control,
    resolve_runtime_card_strip,
)
from pokiguard_v2.game_owned_idle import (
    AcceptedActivityKind,
    GameOwnedIdleCache,
    ResetCapability,
    ResetConfidence,
)
from pokiguard_v2.state import (
    CombatSessionKey,
    GamePhase,
    GameState,
    ParticipantState,
)
from tests.test_basic_policy import attack_card, combat_state
from tools.idle_state_watch import ServerMessage
from tools.basic_auto_bot import (
    _attack_cost_evidence,
    _b4_cast_acceptance_evidence,
    _b4_evolve_forbidden,
    _can_wait_after_unconfirmed_evolve,
    Counters,
    EvolveOnlyTurnWait,
    _acceptance_forced_pass_decision,
    _action_budget_reached,
    _attempt_classification,
    _beep,
    _bounded_stop_reason,
    _combat_end_stop_reason,
    _combat_ownership_ended,
    _fusion_terminal_result,
    _classify_combat_result,
    _idle_session_id,
    _latest_fusion_for_terminal,
    _local_turn_action_deadline_reached,
    _local_turn_deadline_warning_seconds,
    _force_full_pass_scan_once,
    _must_pause_for_no_safe_move,
    _observe_b4_cast_idle_reset,
    _observe_cast_idle_reset,
    _pass_cycle_coverage,
    _pass_lifecycle_evidence,
    _pass_wait_activity_is_fresh,
    _pass_terminal_disposition,
    _post_evolve_settle_status,
    _evolve_only_turn_wait_status,
    _evolve_terminal_touches_turn,
    _policy_none_stop_reason,
    _policy_branch,
    _provider_poll_for_controller,
    _record_policy_observation,
    _record_sent_input_safety,
    _record_turn_observation,
    _reported_cast_reset_confidence,
    _runtime_observation_for_controller,
    _sent_action_count,
    _turn_consuming_action_count,
    _without_optional_card_actions,
    _validate_args,
    build_parser,
    main,
)


class AutonomousGuardTests(unittest.TestCase):
    def test_action_timeout_extends_only_read_observation_on_fresh_source_turn(self) -> None:
        state = combat_state(turn=9)
        session = CombatSessionKey(1, state.battle.board_instance, "M_timeout")
        state = replace(
            state,
            battle=replace(
                state.battle,
                match_id=session.match_id,
                session_key=session,
            ),
        )
        decision = BasicPolicyEngine().decide(state)
        identity = AutonomousActionIdentity.from_decision(state, decision)
        pending = PendingAutonomousAction(identity, 1.0, 241, None)

        plan = plan_action_response_wait(
            pending,
            session=state.battle.session_key,
            turn=9,
            is_local_turn=True,
            remaining_seconds=7,
            minimum_action_time=4,
        )

        self.assertTrue(plan.extend_observation)
        self.assertEqual(plan.extension_seconds, 2.0)

    def test_action_timeout_never_extends_after_turn_changes_or_limit_is_used(self) -> None:
        state = combat_state(turn=9)
        session = CombatSessionKey(1, state.battle.board_instance, "M_timeout")
        state = replace(
            state,
            battle=replace(
                state.battle,
                match_id=session.match_id,
                session_key=session,
            ),
        )
        decision = BasicPolicyEngine().decide(state)
        identity = AutonomousActionIdentity.from_decision(state, decision)
        pending = PendingAutonomousAction(identity, 1.0, 241, None)

        changed = plan_action_response_wait(
            pending,
            session=state.battle.session_key,
            turn=10,
            is_local_turn=True,
            remaining_seconds=14,
            minimum_action_time=4,
        )
        pending.response_wait_extensions = 1
        exhausted = plan_action_response_wait(
            pending,
            session=state.battle.session_key,
            turn=9,
            is_local_turn=True,
            remaining_seconds=14,
            minimum_action_time=4,
        )

        self.assertFalse(changed.extend_observation)
        self.assertFalse(exhausted.extend_observation)

    def test_evolve_only_turn_wait_is_not_an_authoritative_pass(self) -> None:
        session = CombatSessionKey(4, 0x1234, "M_evolve_only")
        wait = EvolveOnlyTurnWait(
            session=session,
            match_id="M_evolve_only",
            source_turn=25,
            source_srv_seq=52,
            board_hash="board-25",
            source_local_move_sequence=9,
            started_timestamp="2026-08-14T15:33:38.180Z",
            gameplay_inputs_total=11,
        )
        common = {
            "current_session": session,
            "current_match_id": "M_evolve_only",
            "current_local_move_sequence": 9,
            "gameplay_inputs_total": 11,
        }

        self.assertEqual(
            _evolve_only_turn_wait_status(
                wait, current_turn=25, is_local_turn=True, **common
            ),
            "WAIT_SOURCE_TURN",
        )
        self.assertEqual(
            _evolve_only_turn_wait_status(
                wait, current_turn=26, is_local_turn=False, **common
            ),
            "WAIT_OPPONENT_TURN",
        )
        self.assertEqual(
            _evolve_only_turn_wait_status(
                wait, current_turn=27, is_local_turn=True, **common
            ),
            "COMPLETED_NEXT_LOCAL_TURN",
        )
        self.assertEqual(
            _evolve_only_turn_wait_status(
                wait,
                current_turn=25,
                is_local_turn=True,
                **{**common, "gameplay_inputs_total": 12},
            ),
            "ABORT_GAMEPLAY_INPUT_OBSERVED",
        )
        self.assertEqual(
            _evolve_only_turn_wait_status(
                wait,
                current_turn=26,
                is_local_turn=False,
                **{**common, "current_local_move_sequence": 10},
            ),
            "ABORT_LOCAL_MOVE_SEQUENCE_CHANGED",
        )

    def test_failed_and_successful_evolve_both_touch_the_turn(self) -> None:
        self.assertTrue(
            _evolve_terminal_touches_turn(ActionResultKind.EVOLVE_SUCCESS)
        )
        self.assertTrue(
            _evolve_terminal_touches_turn(ActionResultKind.EVOLVE_FAILED)
        )
        self.assertFalse(
            _evolve_terminal_touches_turn(ActionResultKind.ACTION_EXPIRED)
        )

    def test_pass_wait_rejects_stale_or_malformed_activity_timestamp(self) -> None:
        attempt = SimpleNamespace(
            started_timestamp="2026-08-14T11:06:00.808Z",
            source_srv_seq=19,
        )
        stale = SimpleNamespace(
            timestamp="2026-08-14T17:05:59", server_sequence=21
        )
        malformed = SimpleNamespace(
            timestamp="Ping: 195 ms | FPS: 52", server_sequence=21
        )
        stale_sequence = SimpleNamespace(
            timestamp="2026-08-14T18:06:01", server_sequence=3
        )
        missing_sequence = SimpleNamespace(
            timestamp="2026-08-14T18:06:01", server_sequence=None
        )
        fresh = SimpleNamespace(
            timestamp="2026-08-14T18:06:01", server_sequence=21
        )

        self.assertFalse(_pass_wait_activity_is_fresh(stale, attempt))
        self.assertFalse(_pass_wait_activity_is_fresh(malformed, attempt))
        self.assertFalse(_pass_wait_activity_is_fresh(stale_sequence, attempt))
        self.assertFalse(_pass_wait_activity_is_fresh(missing_sequence, attempt))
        self.assertTrue(_pass_wait_activity_is_fresh(fresh, attempt))

    def test_acceptance_force_pass_is_explicit_and_authoritative(self) -> None:
        state = self._state()
        basic = BasicPolicyEngine().decide(state)
        coordinator = AuthoritativePassCoordinator(max_auto_passes=2)
        ready = SimpleNamespace(can_pass_now=True, must_act_now=False)

        forced = _acceptance_forced_pass_decision(
            state,
            basic,
            pass_stage="P2",
            force_after_actions=5,
            accepted_consuming_actions=5,
            pass_coordinator=coordinator,
            idle_readiness=ready,
        )
        self.assertEqual(forced.action, PolicyAction.PASS)
        self.assertEqual(
            forced.trace.policy_step, "PHASE_2C2C_FORCED_PASS"
        )
        self.assertIsNone(forced.move)

        disabled = _acceptance_forced_pass_decision(
            state,
            basic,
            pass_stage="P2",
            force_after_actions=0,
            accepted_consuming_actions=20,
            pass_coordinator=coordinator,
            idle_readiness=ready,
        )
        forbidden = _acceptance_forced_pass_decision(
            state,
            basic,
            pass_stage="P2",
            force_after_actions=5,
            accepted_consuming_actions=5,
            pass_coordinator=coordinator,
            idle_readiness=SimpleNamespace(
                can_pass_now=False, must_act_now=True
            ),
        )
        self.assertEqual(disabled, basic)
        self.assertEqual(forbidden, basic)

    def test_pass_lifecycle_transient_provider_miss_is_unknown(self) -> None:
        self.assertIsNone(
            _pass_lifecycle_evidence(None, "M_fixture")
        )
        self.assertFalse(_pass_lifecycle_evidence(None, None))
        self.assertTrue(
            _pass_lifecycle_evidence(CombatLifecycleState.ACTIVE, "M_fixture")
        )
        self.assertFalse(
            _pass_lifecycle_evidence(CombatLifecycleState.LEAVING, "M_fixture")
        )

    def test_p2_first_confirmed_pass_continues_and_second_stops(self) -> None:
        first = _pass_terminal_disposition(
            "P2",
            PassResultKind.PASS_CONFIRMED_IDLE_1,
            p3_reset_validation_pending=False,
        )
        second = _pass_terminal_disposition(
            "P2",
            PassResultKind.PASS_CONFIRMED_IDLE_2,
            p3_reset_validation_pending=False,
        )
        failed = _pass_terminal_disposition(
            "P2",
            PassResultKind.PASS_STATE_UNCONFIRMED,
            p3_reset_validation_pending=False,
        )
        self.assertTrue(first.confirmed)
        self.assertFalse(first.stop)
        self.assertTrue(second.stop)
        self.assertEqual(second.stop_reason, "P2_TWO_AUTONOMOUS_PASSES_CONFIRMED")
        self.assertTrue(failed.stop)

    def test_b3_confirmed_passes_continue_and_second_requires_reset(self) -> None:
        first = _pass_terminal_disposition(
            "B3",
            PassResultKind.PASS_CONFIRMED_IDLE_1,
            p3_reset_validation_pending=False,
        )
        second = _pass_terminal_disposition(
            "B3",
            PassResultKind.PASS_CONFIRMED_IDLE_2,
            p3_reset_validation_pending=False,
        )
        failed = _pass_terminal_disposition(
            "B3",
            PassResultKind.PASS_STATE_UNCONFIRMED,
            p3_reset_validation_pending=False,
        )
        self.assertTrue(first.confirmed)
        self.assertFalse(first.stop)
        self.assertFalse(first.begin_p3_mandatory_reset)
        self.assertTrue(second.confirmed)
        self.assertFalse(second.stop)
        self.assertTrue(second.begin_p3_mandatory_reset)
        self.assertTrue(failed.stop)

    def test_b4_reuses_production_pass_disposition(self) -> None:
        first = _pass_terminal_disposition(
            "B4",
            PassResultKind.PASS_CONFIRMED_IDLE_1,
            p3_reset_validation_pending=False,
        )
        second = _pass_terminal_disposition(
            "B4",
            PassResultKind.PASS_CONFIRMED_IDLE_2,
            p3_reset_validation_pending=False,
        )
        self.assertFalse(first.stop)
        self.assertFalse(first.begin_p3_mandatory_reset)
        self.assertFalse(second.stop)
        self.assertTrue(second.begin_p3_mandatory_reset)

    def test_b5_second_pass_requires_action_and_later_idle_one_completes_cycle(self) -> None:
        second = _pass_terminal_disposition(
            "B5",
            PassResultKind.PASS_CONFIRMED_IDLE_2,
            p3_reset_validation_pending=False,
        )
        after_reset = _pass_terminal_disposition(
            "B5",
            PassResultKind.PASS_CONFIRMED_IDLE_1,
            p3_reset_validation_pending=True,
        )
        self.assertFalse(second.stop)
        self.assertTrue(second.begin_p3_mandatory_reset)
        self.assertFalse(after_reset.stop)
        self.assertTrue(after_reset.complete_reset_cycle)
        self.assertFalse(after_reset.begin_p3_mandatory_reset)

    def test_unknown_authoritative_pass_state_has_distinct_safe_stop(self) -> None:
        state = self._state(rage=100)
        decision = BasicPolicyEngine().decide(state)
        decision = replace(
            decision,
            action=PolicyAction.NONE,
            trace=replace(
                decision.trace,
                blocker="GAME_OWNED_SKIP_STATE_UNKNOWN",
            ),
        )
        self.assertFalse(
            _must_pause_for_no_safe_move(
                decision,
                legal_move_count=8,
                safe_move_count=0,
                first_local_turn=False,
            )
        )
        self.assertEqual(
            _policy_none_stop_reason(
                decision,
                legal_move_count=8,
                safe_move_count=0,
            ),
            "PASS_STATE_UNKNOWN",
        )

    def test_pass_wait_defers_heavy_provider_poll(self) -> None:
        class ProviderStub:
            def __init__(self) -> None:
                self.calls = 0

            def poll(self):
                self.calls += 1
                raise AssertionError("heavy provider poll must be deferred")

        provider = ProviderStub()
        session = CombatSessionKey(1, 0x1234, "M_fixture")
        result = _provider_poll_for_controller(
            provider,  # type: ignore[arg-type]
            pass_wait_locked=True,
            active_session=session,
        )
        self.assertEqual(provider.calls, 0)
        self.assertEqual(result.reason, "pass_wait_runtime_only")
        self.assertEqual(result.session_key, session)
        self.assertIsNone(result.state)

    def test_pass_wait_forces_only_one_full_message_scan_per_attempt(self) -> None:
        identity = ("session", 17, 37)
        self.assertTrue(_force_full_pass_scan_once(identity, None))
        self.assertFalse(_force_full_pass_scan_once(identity, identity))
        self.assertTrue(
            _force_full_pass_scan_once(("session", 25, 53), identity)
        )
        self.assertFalse(_force_full_pass_scan_once(None, identity))

    @staticmethod
    def _state(**kwargs):
        state = combat_state(**kwargs)
        session = CombatSessionKey(1, state.battle.board_instance, "M_fixture")
        return replace(
            state,
            battle=replace(
                state.battle,
                session_key=session,
                match_id=session.match_id,
            ),
        )

    def test_identity_is_single_use_and_pause_is_immediate(self) -> None:
        state = self._state(fusion_used=False)
        decision = BasicPolicyEngine(
            PolicyConfig(mana_priority=ManaPriority.EVOLUTION)
        ).decide(state)
        identity = AutonomousActionIdentity.from_decision(state, decision, attempt=1)
        guard = AutonomousGuard()
        guard.begin_session()
        self.assertTrue(guard.reserve(identity))
        self.assertEqual(guard.executed_count, 0)
        guard.begin(PendingAutonomousAction(identity, 1.0, 320, 160))
        self.assertEqual(guard.executed_count, 1)
        self.assertEqual(guard.status, AutonomousStatus.INPUT_LOCKED)
        guard.complete_pending()
        self.assertFalse(guard.reserve(identity))
        guard.pause(automatic=False)
        self.assertFalse(guard.input_allowed)
        self.assertTrue(guard.resume())
        self.assertTrue(guard.input_allowed)

    def test_unconfirmed_evolve_can_zero_input_wait_after_proven_reset(self) -> None:
        state = self._state(fusion_used=False)
        decision = BasicPolicyEngine(
            PolicyConfig(mana_priority=ManaPriority.EVOLUTION)
        ).decide(state)
        identity = AutonomousActionIdentity.from_decision(
            state, decision, attempt=1
        )
        pending = PendingAutonomousAction(identity, 1.0, 320, 160)

        allowed, reason = _can_wait_after_unconfirmed_evolve(
            pending,
            pass_stage="B5",
            active_session=state.battle.session_key,
            current_turn=state.battle.turn_number,
            is_local_turn=True,
            is_first_local_turn=False,
            lifecycle_active=True,
            board_current_valid=True,
            idle_can_pass=True,
            idle_must_act=False,
            sequence_desync=False,
            timeout_reason="INSUFFICIENT_SAFE_TURN_TIME",
        )

        self.assertTrue(allowed)
        self.assertEqual(reason, "SAFE_ZERO_INPUT_WAIT_AFTER_UNCONFIRMED_EVOLVE")
        self.assertFalse(pending.consumes_turn)

    def test_unconfirmed_evolve_can_wait_after_observation_extension_exhausted(self) -> None:
        state = self._state(fusion_used=False)
        decision = BasicPolicyEngine(
            PolicyConfig(mana_priority=ManaPriority.EVOLUTION)
        ).decide(state)
        pending = PendingAutonomousAction(
            AutonomousActionIdentity.from_decision(state, decision, attempt=2),
            1.0,
            320,
            160,
            response_wait_extensions=1,
        )

        allowed, reason = _can_wait_after_unconfirmed_evolve(
            pending,
            pass_stage="B5",
            active_session=state.battle.session_key,
            current_turn=state.battle.turn_number,
            is_local_turn=True,
            is_first_local_turn=False,
            lifecycle_active=True,
            board_current_valid=True,
            idle_can_pass=True,
            idle_must_act=False,
            sequence_desync=False,
            timeout_reason="EXTENSION_LIMIT_REACHED",
        )

        self.assertTrue(allowed)
        self.assertEqual(reason, "SAFE_ZERO_INPUT_WAIT_AFTER_UNCONFIRMED_EVOLVE")

    def test_unconfirmed_evolve_wait_is_denied_when_idle_requires_action(self) -> None:
        state = self._state(fusion_used=False)
        decision = BasicPolicyEngine(
            PolicyConfig(mana_priority=ManaPriority.EVOLUTION)
        ).decide(state)
        pending = PendingAutonomousAction(
            AutonomousActionIdentity.from_decision(state, decision, attempt=1),
            1.0,
            320,
            160,
        )

        allowed, reason = _can_wait_after_unconfirmed_evolve(
            pending,
            pass_stage="B5",
            active_session=state.battle.session_key,
            current_turn=state.battle.turn_number,
            is_local_turn=True,
            is_first_local_turn=False,
            lifecycle_active=True,
            board_current_valid=True,
            idle_can_pass=False,
            idle_must_act=True,
            sequence_desync=False,
            timeout_reason="INSUFFICIENT_SAFE_TURN_TIME",
        )

        self.assertFalse(allowed)
        self.assertEqual(reason, "AUTHORITATIVE_IDLE_DOES_NOT_ALLOW_PASS")

    def test_unconfirmed_evolve_wait_never_applies_to_consuming_action(self) -> None:
        state = self._state()
        decision = BasicPolicyEngine().decide(state)
        pending = PendingAutonomousAction(
            AutonomousActionIdentity.from_decision(state, decision),
            1.0,
            320,
            None,
        )

        allowed, reason = _can_wait_after_unconfirmed_evolve(
            pending,
            pass_stage="B5",
            active_session=state.battle.session_key,
            current_turn=state.battle.turn_number,
            is_local_turn=True,
            is_first_local_turn=False,
            lifecycle_active=True,
            board_current_valid=True,
            idle_can_pass=True,
            idle_must_act=False,
            sequence_desync=False,
            timeout_reason="INSUFFICIENT_SAFE_TURN_TIME",
        )

        self.assertFalse(allowed)
        self.assertEqual(reason, "NOT_NONCONSUMING_EVOLVE")

    def test_recovery_cancels_pending_and_cannot_resume(self) -> None:
        state = self._state(fusion_used=False)
        decision = BasicPolicyEngine().decide(state)
        identity = AutonomousActionIdentity.from_decision(state, decision, attempt=1)
        guard = AutonomousGuard()
        guard.begin_session()
        self.assertTrue(guard.reserve(identity))
        guard.begin(PendingAutonomousAction(identity, 1.0, 320, 160))
        self.assertEqual(guard.require_recovery().identity, identity)
        self.assertEqual(guard.status, AutonomousStatus.RECOVERY_REQUIRED)
        self.assertFalse(guard.resume())

    def test_emergency_stop_cancels_pending_and_disables_input(self) -> None:
        state = self._state()
        decision = BasicPolicyEngine().decide(state)
        identity = AutonomousActionIdentity.from_decision(state, decision, attempt=1)
        guard = AutonomousGuard()
        guard.begin_session()
        self.assertTrue(guard.reserve(identity))
        guard.begin(PendingAutonomousAction(identity, 1.0, 320, 160))

        stopped = guard.stop()

        self.assertIsNotNone(stopped)
        self.assertEqual(stopped.identity, identity)
        self.assertIsNone(guard.pending)
        self.assertEqual(guard.status, AutonomousStatus.STOPPED)
        self.assertFalse(guard.input_allowed)

    def test_manual_state_change_invalidates_source(self) -> None:
        state = self._state()
        source = AutonomousSource.from_state(state)
        changed = replace(
            state,
            battle=replace(state.battle, srv_seq=state.battle.srv_seq + 1),
        )
        self.assertFalse(source.matches(changed))

    def test_only_one_consuming_action_per_turn(self) -> None:
        state = self._state()
        registry = ConsumingTurnRegistry()
        self.assertTrue(registry.reserve(state.battle.session_key, 14))
        self.assertFalse(registry.reserve(state.battle.session_key, 14))
        self.assertTrue(registry.reserve(state.battle.session_key, 15))

    def test_action_budget_waits_for_terminal_result_and_then_stops(self) -> None:
        state = self._state()
        decision = BasicPolicyEngine().decide(state)
        identity = AutonomousActionIdentity.from_decision(state, decision, attempt=1)
        pending = PendingAutonomousAction(identity, 1.0, 0, None)
        counters = Counters(
            swap_sent=1,
            input_actions_total=1,
            turn_consuming_actions_total=1,
        )

        self.assertEqual(_sent_action_count(counters), 1)
        self.assertFalse(
            _action_budget_reached(counters, max_actions=1, pending=pending)
        )
        self.assertTrue(
            _action_budget_reached(counters, max_actions=1, pending=None)
        )
        self.assertFalse(
            _action_budget_reached(counters, max_actions=0, pending=None)
        )

    @patch("tools.basic_auto_bot.winsound")
    def test_pause_alert_is_a_long_three_tone_pattern(self, winsound_mock) -> None:
        self.assertTrue(_beep("pause", True))
        self.assertEqual(winsound_mock.Beep.call_count, 3)
        self.assertGreaterEqual(
            sum(call.args[1] for call in winsound_mock.Beep.call_args_list),
            700,
        )

    def test_stage_b1_budget_excludes_evolve_and_waits_for_terminal(self) -> None:
        state = self._state(fusion_used=False)
        decision = BasicPolicyEngine(
            PolicyConfig(mana_priority=ManaPriority.EVOLUTION)
        ).decide(state)
        identity = AutonomousActionIdentity.from_decision(state, decision, attempt=1)
        pending = PendingAutonomousAction(identity, 1.0, 320, 160)
        counters = Counters(
            evolve_sent=2,
            swap_sent=3,
            input_actions_total=5,
            turn_consuming_actions_total=3,
            evolve_attempts=2,
            swap_actions=3,
        )
        self.assertEqual(_sent_action_count(counters), 5)
        self.assertEqual(_turn_consuming_action_count(counters), 3)
        self.assertIsNone(
            _bounded_stop_reason(
                counters,
                max_turn_actions=3,
                max_total_input_actions=10,
                pending=pending,
            )
        )
        self.assertEqual(
            _bounded_stop_reason(
                counters,
                max_turn_actions=3,
                max_total_input_actions=10,
                pending=None,
            ),
            "AUTO_STOP_AFTER_ACK",
        )

    def test_total_input_ceiling_stops_evolve_retry_loop(self) -> None:
        counters = Counters(
            evolve_sent=10,
            input_actions_total=10,
            evolve_attempts=10,
        )
        self.assertEqual(
            _bounded_stop_reason(
                counters,
                max_turn_actions=3,
                max_total_input_actions=10,
                pending=None,
            ),
            "AUTO_PAUSE_SAFETY_LIMIT",
        )

    def test_stage_b3_defaults_disable_gameplay_cap_and_keep_high_safety_ceiling(self) -> None:
        args = build_parser().parse_args(["--watch"])
        self.assertEqual(args.max_turn_actions, 0)
        self.assertEqual(args.max_total_input_actions, 100)
        self.assertEqual(args.ack_heap_region_mib, 16)
        self.assertEqual(args.acceptance_force_pass_after_actions, 0)
        _validate_args(args)

    def test_stage_b4_requires_attack_priority_and_production_pass_evidence(self) -> None:
        wrong_priority = build_parser().parse_args(
            [
                "--watch",
                "--pass-acceptance-stage",
                "B4",
                "--reset-evidence",
                "reset.json",
            ]
        )
        with self.assertRaisesRegex(ValueError, "requires --mana-priority attack"):
            _validate_args(wrong_priority)
        configured = build_parser().parse_args(
            [
                "--watch",
                "--pass-acceptance-stage",
                "B4",
                "--mana-priority",
                "attack",
                "--reset-evidence",
                "reset.json",
            ]
        )
        _validate_args(configured)
        self.assertEqual(configured.max_turn_actions, 0)
        self.assertEqual(configured.acceptance_force_pass_after_actions, 0)

    def test_stage_b5_requires_exact_basic_profile_and_production_pass_evidence(self) -> None:
        configured = build_parser().parse_args(
            [
                "--watch",
                "--pass-acceptance-stage",
                "B5",
                "--reset-evidence",
                "reset.json",
            ]
        )
        _validate_args(configured)
        self.assertEqual(configured.play_style, "simple")
        self.assertEqual(configured.mana_priority, "evolution")
        self.assertEqual(configured.intelligence, "basic")
        self.assertIsNone(configured.max_actions)
        self.assertEqual(configured.max_turn_actions, 0)
        for option in (
            ("--play-style", "careful", "play-style simple"),
            ("--mana-priority", "attack", "mana-priority evolution"),
        ):
            name, value, error = option
            wrong = build_parser().parse_args(
                [
                    "--watch",
                    "--pass-acceptance-stage",
                    "B5",
                    "--reset-evidence",
                    "reset.json",
                    name,
                    value,
                ]
            )
            with self.assertRaisesRegex(ValueError, error):
                _validate_args(wrong)

    def test_b5_full_match_classification_distinguishes_cycle_coverage(self) -> None:
        partial = Counters(sessions_completed=1, pass_confirmed_idle_1=1)
        strong = Counters(
            sessions_completed=1,
            pass_confirmed_idle_1=2,
            pass_confirmed_idle_2=1,
            mandatory_actions_required=1,
            pass_reset_cycles_confirmed=1,
        )
        self.assertEqual(_pass_cycle_coverage(Counters()), "NOT_OBSERVED")
        self.assertEqual(_pass_cycle_coverage(partial), "PARTIAL")
        self.assertEqual(_pass_cycle_coverage(strong), "FULL")
        self.assertEqual(
            _attempt_classification(
                "COMBAT_LIFECYCLE_ENDED", partial, pass_stage="B5"
            ),
            "FULL_MATCH_PASS",
        )
        self.assertEqual(
            _attempt_classification(
                "COMBAT_LIFECYCLE_ENDED", strong, pass_stage="B5"
            ),
            "B5_PASS_STRONG",
        )
        strong.wrong_third_pass = 1
        self.assertEqual(
            _attempt_classification(
                "COMBAT_LIFECYCLE_ENDED", strong, pass_stage="B5"
            ),
            "FULL_MATCH_COMPLETED_WITH_SAFETY_FINDING",
        )

    def test_b4_hard_assertion_forbids_evolve_only_in_attack_stage(self) -> None:
        self.assertTrue(
            _b4_evolve_forbidden(
                stage="B4",
                mana_priority=ManaPriority.ATTACK,
                action=PolicyAction.EVOLVE,
            )
        )
        self.assertFalse(
            _b4_evolve_forbidden(
                stage="B3",
                mana_priority=ManaPriority.ATTACK,
                action=PolicyAction.EVOLVE,
            )
        )
        self.assertFalse(
            _b4_evolve_forbidden(
                stage="B4",
                mana_priority=ManaPriority.ATTACK,
                action=PolicyAction.CAST,
            )
        )

    def test_b4_cast_requires_exact_cost_mana_card_and_consuming_turn(self) -> None:
        state = self._state()
        base = BasicPolicyEngine().decide(state)
        card_before = attack_card()
        cast = replace(
            base,
            action=PolicyAction.CAST,
            move=None,
            card_object_address=card_before.object_address,
            consumes_turn=True,
        )
        identity = AutonomousActionIdentity.from_decision(state, cast)
        cost, source = _attack_cost_evidence(card_before)
        pending = PendingAutonomousAction(
            identity,
            1.0,
            590,
            cost,
            card_last_turn_used=card_before.last_turn_used,
            card_id=card_before.card_id,
            card_object_address=card_before.object_address,
            card_name=card_before.name,
            card_element_type=card_before.element_type,
            card_cost_source=source,
            card_interactable_before=True,
            card_has_used_this_turn_before=False,
            consuming_transition_seen=True,
        )
        card_after = replace(
            card_before,
            interactable=False,
            has_used_this_turn=True,
            last_turn_used=identity.source.turn,
        )
        valid = dict(
            mana_after=430,
            card_after=card_after,
            observed_turn=identity.source.turn + 1,
            observed_current_player="boss",
        )
        proof = _b4_cast_acceptance_evidence(pending, **valid)
        self.assertTrue(proof.accepted)
        self.assertEqual(proof.actual_cost, 160)
        self.assertEqual(proof.cost_source, "CardData.conditionUse")
        self.assertEqual(proof.expected_mana_after, 430)
        for conflict in (
            {"mana_after": 431},
            {"card_after": None},
            {"observed_turn": identity.source.turn + 2},
            {"observed_current_player": identity.source.current_turn_player},
        ):
            with self.subTest(conflict=conflict):
                self.assertFalse(
                    _b4_cast_acceptance_evidence(
                        pending, **{**valid, **conflict}
                    ).accepted
                )

    def test_b4_cast_can_use_accepted_response_when_card_snapshot_is_transient(self) -> None:
        state = self._state()
        base = BasicPolicyEngine().decide(state)
        card = attack_card()
        cast = replace(
            base,
            action=PolicyAction.CAST,
            move=None,
            card_object_address=card.object_address,
            consumes_turn=True,
        )
        identity = AutonomousActionIdentity.from_decision(state, cast)
        pending = PendingAutonomousAction(
            identity,
            1.0,
            590,
            160,
            card_id=card.card_id,
            card_object_address=card.object_address,
            card_element_type=card.element_type,
            card_interactable_before=True,
            card_has_used_this_turn_before=False,
            server_response_seen=True,
            response_success=True,
            consuming_transition_seen=True,
        )
        self.assertTrue(
            _b4_cast_acceptance_evidence(
                pending,
                mana_after=430,
                card_after=None,
                observed_turn=identity.source.turn + 1,
                observed_current_player="boss",
            ).accepted
        )

    def test_b4_direct_cast_proof_does_not_fabricate_idle_response(self) -> None:
        state = self._state()
        base = BasicPolicyEngine().decide(state)
        card = attack_card()
        cast = replace(
            base,
            action=PolicyAction.CAST,
            move=None,
            card_object_address=card.object_address,
            consumes_turn=True,
        )
        pending = PendingAutonomousAction(
            AutonomousActionIdentity.from_decision(state, cast),
            1.0,
            590,
            160,
            card_object_address=card.object_address,
            consuming_transition_seen=True,
        )
        cache = GameOwnedIdleCache()
        self.assertIsNone(_observe_b4_cast_idle_reset(cache, pending))
        self.assertIsNone(cache.state)
        self.assertIsNone(cache.reset_baseline)

    def test_b5_direct_cast_state_can_only_correlate_strongly_inferred_reset(self) -> None:
        state = self._state()
        card = attack_card()
        cast = replace(
            BasicPolicyEngine().decide(state),
            action=PolicyAction.CAST,
            move=None,
            card_object_address=card.object_address,
            consumes_turn=True,
        )
        pending = PendingAutonomousAction(
            AutonomousActionIdentity.from_decision(state, cast),
            1.0,
            590,
            160,
            card_object_address=card.object_address,
            consuming_transition_seen=True,
            consuming_transition_evidence=SimpleNamespace(
                highest_acked_sequence=64
            ),
            mandatory_after_idle_2=True,
        )
        cache = GameOwnedIdleCache()
        session_id = _idle_session_id(state.battle.session_key)
        self.assertIsNotNone(session_id)
        before = cache.observe_server_payload(
            session_id=session_id,
            username=state.battle.local_username or "happi",
            idle_count=2,
            threshold=3,
            source_message_type="MATCH_TURN_END",
            source_srv_seq=60,
            source_turn=state.battle.turn_number,
            source_timestamp="server-before",
            observed_timestamp="local-before",
        )
        activity = _observe_cast_idle_reset(
            cache,
            pending,
            allow_direct_state=True,
        )
        self.assertEqual(
            activity.source_message_type,
            "DIRECT_CAST_STATE_TRANSITION",
        )
        self.assertEqual(cache.state.idle_count, before.idle_count)
        reset = cache.observe_server_payload(
            session_id=session_id,
            username=state.battle.local_username or "happi",
            idle_count=1,
            threshold=3,
            source_message_type="MATCH_TURN_END",
            source_srv_seq=65,
            source_turn=state.battle.turn_number + 2,
            source_timestamp="server-after",
            observed_timestamp="local-after",
        )
        self.assertEqual(
            reset.reset_confidence,
            ResetConfidence.RESET_STRONGLY_INFERRED,
        )
        self.assertEqual(reset.reset_activity.kind, AcceptedActivityKind.CAST)
        self.assertEqual(
            _reported_cast_reset_confidence(
                (reset.reset_confidence,),
                ResetCapability(
                    kind=AcceptedActivityKind.CAST,
                    confirmations=0,
                    required_confirmations=2,
                    confidence=ResetConfidence.RESET_UNKNOWN,
                    proof_identities=(),
                ),
            ),
            "STRONGLY_INFERRED",
        )

    def test_b4_attributed_card_response_can_seed_idle_reset_observation(self) -> None:
        state = self._state()
        base = BasicPolicyEngine().decide(state)
        card = attack_card()
        cast = replace(
            base,
            action=PolicyAction.CAST,
            move=None,
            card_object_address=card.object_address,
            consumes_turn=True,
        )
        pending = PendingAutonomousAction(
            AutonomousActionIdentity.from_decision(state, cast),
            1.0,
            590,
            160,
            card_object_address=card.object_address,
            server_response_seen=True,
            response_success=True,
        )
        pending.response_evidence = ServerMessage(
            address=0x1234,
            event_type="MATCH_CARD_USE_RES",
            match_id=state.battle.match_id,
            timestamp="2026-08-14T12:58:06.500Z",
            username=state.battle.local_username,
            payload_address=0x5678,
            server_sequence=64,
            from_col=None,
            from_row=None,
            to_col=None,
            to_row=None,
            card_id=card.card_id,
            skill_card_id=None,
            reject_reason=None,
            idle_count=None,
            threshold=None,
            payload_ints=(),
            payload_bools=(("success", True),),
            payload_strings=(),
        )
        activity = _observe_b4_cast_idle_reset(GameOwnedIdleCache(), pending)
        self.assertIsNotNone(activity)
        self.assertEqual(activity.source_message_type, "MATCH_CARD_USE_RES")

    @patch("tools.basic_auto_bot._persist_fatal_controller_error")
    @patch("tools.basic_auto_bot._beep")
    @patch("tools.basic_auto_bot.run", side_effect=ValueError("fatal-test"))
    def test_unhandled_controller_failure_emits_pause_alarm(
        self, _run_mock, beep_mock, _persist_mock
    ) -> None:
        self.assertEqual(main(["--watch"]), 1)
        beep_mock.assert_called_once_with("pause", True)

    def test_stage_b3_rejects_ack_heap_envelope_below_normal_scan(self) -> None:
        args = build_parser().parse_args(
            ["--watch", "--max-region-mib", "16", "--ack-heap-region-mib", "8"]
        )
        with self.assertRaisesRegex(ValueError, "must cover --max-region-mib"):
            _validate_args(args)

    def test_pass_acceptance_requires_p0_evidence_and_is_opt_in(self) -> None:
        missing = build_parser().parse_args(
            ["--watch", "--pass-acceptance-stage", "P1"]
        )
        with self.assertRaisesRegex(ValueError, "requires --reset-evidence"):
            _validate_args(missing)
        disabled_with_evidence = build_parser().parse_args(
            ["--watch", "--reset-evidence", "reset.json"]
        )
        with self.assertRaisesRegex(ValueError, "requires P1/P2/P3/B3"):
            _validate_args(disabled_with_evidence)
        enabled = build_parser().parse_args(
            [
                "--watch",
                "--pass-acceptance-stage",
                "P2",
                "--reset-evidence",
                "reset.json",
                "--acceptance-force-pass-after-actions",
                "5",
            ]
        )
        _validate_args(enabled)
        force_without_stage = build_parser().parse_args(
            ["--watch", "--acceptance-force-pass-after-actions", "5"]
        )
        with self.assertRaisesRegex(ValueError, "requires P2 or P3"):
            _validate_args(force_without_stage)

        b3 = build_parser().parse_args(
            [
                "--watch",
                "--pass-acceptance-stage",
                "B3",
                "--reset-evidence",
                "reset.json",
            ]
        )
        _validate_args(b3)
        self.assertEqual(b3.acceptance_force_pass_after_actions, 0)
        b3_forced = build_parser().parse_args(
            [
                "--watch",
                "--pass-acceptance-stage",
                "B3",
                "--reset-evidence",
                "reset.json",
                "--acceptance-force-pass-after-actions",
                "5",
            ]
        )
        with self.assertRaisesRegex(ValueError, "requires P2 or P3"):
            _validate_args(b3_forced)

    def test_stage_b3_does_not_stop_at_tenth_consuming_action(self) -> None:
        state = self._state()
        decision = BasicPolicyEngine().decide(state)
        identity = AutonomousActionIdentity.from_decision(state, decision, attempt=1)
        pending = PendingAutonomousAction(identity, 1.0, 0, None)
        counters = Counters(
            swap_sent=9,
            cast_sent=1,
            input_actions_total=12,
            turn_consuming_actions_total=10,
            evolve_attempts=2,
            swap_actions=9,
            cast_actions=1,
        )
        self.assertIsNone(
            _bounded_stop_reason(
                counters,
                max_turn_actions=0,
                max_total_input_actions=100,
                pending=pending,
            )
        )
        self.assertIsNone(
            _bounded_stop_reason(
                counters,
                max_turn_actions=0,
                max_total_input_actions=100,
                pending=None,
            )
        )

    def test_stage_b3_rejects_bounded_turn_cap_and_low_emergency_ceiling(self) -> None:
        bounded_turns = build_parser().parse_args(
            ["--watch", "--max-turn-actions", "10"]
        )
        with self.assertRaisesRegex(ValueError, "requires --max-turn-actions 0"):
            _validate_args(bounded_turns)
        low_input_ceiling = build_parser().parse_args(
            ["--watch", "--max-total-input-actions", "20"]
        )
        with self.assertRaisesRegex(ValueError, "between 50 and 1000"):
            _validate_args(low_input_ceiling)

    def test_phase2d4_b1_internal_handoff_requires_exactly_one_turn_action(self) -> None:
        bounded = build_parser().parse_args(
            [
                "--watch",
                "--pass-acceptance-stage",
                "B5",
                "--reset-evidence",
                "reset.json",
            ]
        )
        bounded.phase2d4_bounded_handoff = True
        bounded.max_turn_actions = 1
        _validate_args(bounded)

        bounded.max_turn_actions = 2
        with self.assertRaisesRegex(ValueError, "requires --max-turn-actions 1"):
            _validate_args(bounded)

    @patch("tools.basic_auto_bot.read_match_runtime")
    def test_phase2d4_b1_fast_handoff_reuses_proven_opening_without_monitor_scan(
        self, read_runtime
    ) -> None:
        runtime = SimpleNamespace(match_id="M_new", turn=1, remaining=6)
        read_runtime.return_value = (0x1234, runtime)
        monitor = SimpleNamespace(poll=lambda **_kwargs: self.fail("unexpected scan"))

        observation = _runtime_observation_for_controller(
            object(),
            monitor,  # type: ignore[arg-type]
            session_key=CombatSessionKey(2, 0x4567, "M_new"),
            match_id="M_new",
            turn=1,
            srv_seq=3,
            fast_bounded_handoff=True,
        )

        self.assertIs(observation.runtime, runtime)
        self.assertEqual(observation.messages, ())
        self.assertFalse(observation.scan_performed)

    def test_stage_b3_emergency_ceiling_waits_for_terminal_then_pauses(self) -> None:
        counters = Counters(input_actions_total=100, turn_consuming_actions_total=90)
        state = self._state()
        identity = AutonomousActionIdentity.from_decision(
            state, BasicPolicyEngine().decide(state)
        )
        pending = PendingAutonomousAction(identity, 1.0, 0, None)

        self.assertIsNone(
            _bounded_stop_reason(
                counters,
                max_turn_actions=0,
                max_total_input_actions=100,
                pending=pending,
            )
        )
        self.assertEqual(
            _bounded_stop_reason(
                counters,
                max_turn_actions=0,
                max_total_input_actions=100,
                pending=None,
            ),
            "AUTO_PAUSE_SAFETY_LIMIT",
        )

    def test_stage_b3_turn_policy_and_input_safety_telemetry(self) -> None:
        state = self._state()
        counters = Counters()
        seen_turns = set()

        self.assertEqual(
            _record_turn_observation(
                counters,
                seen_turns,
                session=state.battle.session_key,
                turn=1,
                current_player="happi",
                local_username="happi",
            ),
            "LOCAL",
        )
        self.assertIsNone(
            _record_turn_observation(
                counters,
                seen_turns,
                session=state.battle.session_key,
                turn=1,
                current_player="happi",
                local_username="happi",
            )
        )
        self.assertEqual(
            _record_turn_observation(
                counters,
                seen_turns,
                session=state.battle.session_key,
                turn=2,
                current_player="boss",
                local_username="happi",
            ),
            "BOSS",
        )
        self.assertEqual(counters.local_turns_observed, 1)
        self.assertEqual(counters.boss_turns_observed, 1)

        decision = BasicPolicyEngine().decide(state)
        seen_policy = set()
        branch = _record_policy_observation(
            counters, seen_policy, state=state, decision=decision
        )
        self.assertEqual(branch, "SWORD")
        self.assertIsNone(
            _record_policy_observation(
                counters, seen_policy, state=state, decision=decision
            )
        )
        self.assertEqual(counters.policy_branches, {"SWORD": 1})
        self.assertEqual(_policy_branch("STEP_5_SAFE_FALLBACK"), "SAFE_RESOURCE_FALLBACK")

        unsafe = replace(
            state,
            battle=replace(
                state.battle,
                combat_lifecycle=CombatLifecycleState.POSTMATCH,
                is_local_turn=False,
            ),
        )
        _record_sent_input_safety(counters, unsafe)
        self.assertEqual(counters.wrong_turn_inputs, 1)
        self.assertEqual(counters.boss_turn_inputs, 1)
        self.assertEqual(counters.postmatch_inputs, 1)
        self.assertEqual(counters.input_after_combat, 1)

    def test_local_turn_deadline_warns_once_before_a_silent_skip(self) -> None:
        state = self._state()
        session = state.battle.session_key
        common = dict(
            session=session,
            turn=15,
            match_id=session.match_id,
            current_player="happi",
            local_username="happi",
            warning_seconds=6,
            status=AutonomousStatus.RUNNING,
            pending=None,
        )

        self.assertTrue(
            _local_turn_action_deadline_reached(
                **common,
                remaining_seconds=5,
                consuming_action_turns=set(),
            )
        )
        self.assertFalse(
            _local_turn_action_deadline_reached(
                **common,
                remaining_seconds=7,
                consuming_action_turns=set(),
            )
        )
        self.assertFalse(
            _local_turn_action_deadline_reached(
                **common,
                remaining_seconds=6,
                consuming_action_turns={(session, 15)},
            )
        )

    def test_local_turn_deadline_uses_exact_four_second_action_floor(self) -> None:
        self.assertEqual(_local_turn_deadline_warning_seconds(4), 4)
        self.assertEqual(_local_turn_deadline_warning_seconds(10), 10)
        with self.assertRaises(ValueError):
            _local_turn_deadline_warning_seconds(-1)

        state = self._state()
        session = state.battle.session_key
        common = dict(
            session=session,
            turn=1,
            match_id=session.match_id,
            current_player="happi",
            local_username="happi",
            warning_seconds=_local_turn_deadline_warning_seconds(4),
            status=AutonomousStatus.RUNNING,
            pending=None,
            consuming_action_turns=set(),
        )
        self.assertFalse(
            _local_turn_action_deadline_reached(**common, remaining_seconds=5)
        )
        self.assertFalse(
            _local_turn_action_deadline_reached(**common, remaining_seconds=4)
        )
        self.assertTrue(
            _local_turn_action_deadline_reached(**common, remaining_seconds=3)
        )

    def test_evolve_failure_response_is_terminal_without_optional_turn_lock(self) -> None:
        state = self._state(fusion_used=False)
        decision = BasicPolicyEngine(
            PolicyConfig(mana_priority=ManaPriority.EVOLUTION)
        ).decide(state)
        identity = AutonomousActionIdentity.from_decision(state, decision, attempt=1)
        pending = PendingAutonomousAction(identity, 1.0, 385, 160)
        pending.server_response_seen = True
        pending.response_success = False
        self.assertEqual(
            _fusion_terminal_result(pending, state.fusion),
            ActionResultKind.EVOLVE_FAILED,
        )

    def test_evolve_success_still_requires_durable_used_transition(self) -> None:
        state = self._state(fusion_used=False)
        decision = BasicPolicyEngine(
            PolicyConfig(mana_priority=ManaPriority.EVOLUTION)
        ).decide(state)
        identity = AutonomousActionIdentity.from_decision(state, decision, attempt=1)
        pending = PendingAutonomousAction(identity, 1.0, 385, 160)
        pending.server_response_seen = True
        pending.response_success = True
        self.assertIsNone(_fusion_terminal_result(pending, state.fusion))
        succeeded = replace(state.fusion, used=True)
        self.assertEqual(
            _fusion_terminal_result(pending, succeeded),
            ActionResultKind.EVOLVE_SUCCESS,
        )

    def test_evolve_success_uses_direct_fusion_while_board_reread_catches_up(self) -> None:
        state = self._state(fusion_used=False)
        decision = BasicPolicyEngine(
            PolicyConfig(mana_priority=ManaPriority.EVOLUTION)
        ).decide(state)
        identity = AutonomousActionIdentity.from_decision(state, decision, attempt=1)
        pending = PendingAutonomousAction(identity, 1.0, 210, 160)
        pending.server_response_seen = True
        pending.response_success = True
        direct_fusion = replace(
            state.fusion,
            used=True,
            available=False,
            last_attempt_turn=state.battle.turn_number,
        )

        latest = _latest_fusion_for_terminal(None, direct_fusion)

        self.assertIs(latest, direct_fusion)
        self.assertEqual(
            _fusion_terminal_result(pending, latest),
            ActionResultKind.EVOLVE_SUCCESS,
        )

    def test_post_evolve_follow_up_waits_for_animation_settlement(self) -> None:
        state = self._state(fusion_used=True)
        common = {
            "source_session": state.battle.session_key,
            "source_turn": state.battle.turn_number,
            "not_before": 13.5,
        }
        self.assertEqual(
            _post_evolve_settle_status(state, now=10.0, **common),
            "WAIT",
        )
        self.assertEqual(
            _post_evolve_settle_status(state, now=13.5, **common),
            "READY",
        )
        next_turn = replace(
            state,
            battle=replace(
                state.battle,
                turn_number=state.battle.turn_number + 1,
            ),
        )
        self.assertEqual(
            _post_evolve_settle_status(next_turn, now=10.0, **common),
            "SOURCE_CHANGED",
        )

    def test_durable_fusion_transition_is_terminal_equivalent_without_heap_response(self) -> None:
        state = self._state(fusion_used=False)
        decision = BasicPolicyEngine(
            PolicyConfig(mana_priority=ManaPriority.EVOLUTION)
        ).decide(state)
        identity = AutonomousActionIdentity.from_decision(state, decision, attempt=1)
        pending = PendingAutonomousAction(
            identity,
            1.0,
            210,
            160,
            fusion_last_attempt_turn_before=-1,
            fusion_used_before=False,
        )
        durable = replace(
            state.fusion,
            used=True,
            available=False,
            last_attempt_turn=state.battle.turn_number,
        )

        self.assertFalse(pending.server_response_seen)
        self.assertEqual(
            _fusion_terminal_result(pending, durable),
            ActionResultKind.EVOLVE_SUCCESS,
        )

        stale_turn = replace(
            durable,
            last_attempt_turn=state.battle.turn_number - 1,
        )
        self.assertIsNone(_fusion_terminal_result(pending, stale_turn))

    def test_unsent_reservation_can_be_cancelled_and_recomputed(self) -> None:
        state = self._state()
        identity = AutonomousActionIdentity.from_decision(
            state, BasicPolicyEngine().decide(state), attempt=1
        )
        guard = AutonomousGuard()
        guard.begin_session()
        self.assertTrue(guard.reserve(identity))
        self.assertTrue(guard.cancel_reservation(identity))
        self.assertEqual(guard.executed_count, 0)
        self.assertTrue(guard.reserve(identity))

    def test_source_matches_ignores_timer_but_rejects_resource_change(self) -> None:
        state = self._state()
        source = AutonomousSource.from_state(state)
        timer_tick = replace(
            state,
            battle=replace(
                state.battle,
                turn_time_remaining_seconds=(
                    state.battle.turn_time_remaining_seconds - 1
                ),
            ),
        )
        self.assertTrue(source.matches(timer_tick))
        changed = replace(
            state,
            player=replace(state.player, mana=state.player.mana + 1),
        )
        self.assertFalse(source.matches(changed))

    def test_turn_transition_requires_observed_opponent_before_next_local(self) -> None:
        first = self._state()
        action = AutonomousActionIdentity.from_decision(
            first, BasicPolicyEngine().decide(first), attempt=1
        )
        tracker = TurnTransitionTracker()
        tracker.begin(action)
        opponent = replace(
            first,
            battle=replace(
                first.battle,
                srv_seq=first.battle.srv_seq + 1,
                turn_number=first.battle.turn_number + 1,
                current_turn_player="boss",
                is_local_turn=False,
                client_move_allowed=False,
            ),
        )
        seen = tracker.observe(opponent)
        self.assertEqual(seen.kind, TurnTransitionKind.OPPONENT_TURN)
        local = replace(
            opponent,
            battle=replace(
                opponent.battle,
                srv_seq=opponent.battle.srv_seq + 1,
                turn_number=opponent.battle.turn_number + 1,
                current_turn_player=first.battle.current_turn_player,
                is_local_turn=True,
                client_move_allowed=True,
            ),
        )
        returned = tracker.observe(local)
        self.assertEqual(returned.kind, TurnTransitionKind.LOCAL_TURN_RETURNED)
        self.assertIsNone(tracker.action)

    def test_direct_runtime_proves_opponent_transition_without_board_publish(self) -> None:
        first = self._state()
        action = AutonomousActionIdentity.from_decision(
            first, BasicPolicyEngine().decide(first), attempt=1
        )
        tracker = TurnTransitionTracker()
        tracker.begin(action)
        self.assertIsNone(
            tracker.observe_runtime(
                session=first.battle.session_key,
                turn=first.battle.turn_number,
                current_player=first.battle.current_turn_player,
                local_username=first.battle.current_turn_player,
            )
        )
        opponent = tracker.observe_runtime(
            session=first.battle.session_key,
            turn=first.battle.turn_number + 1,
            current_player="boss",
            local_username=first.battle.current_turn_player,
        )
        self.assertEqual(opponent.kind, TurnTransitionKind.OPPONENT_TURN)
        returned = tracker.observe_runtime(
            session=first.battle.session_key,
            turn=first.battle.turn_number + 2,
            current_player=first.battle.current_turn_player,
            local_username=first.battle.current_turn_player,
        )
        self.assertEqual(returned.kind, TurnTransitionKind.LOCAL_TURN_RETURNED)
        self.assertIsNone(returned.new_source)
        self.assertIsNone(tracker.action)

    def test_direct_runtime_even_turn_advance_proves_missed_opponent_sample(self) -> None:
        first = self._state()
        action = AutonomousActionIdentity.from_decision(
            first, BasicPolicyEngine().decide(first), attempt=1
        )
        tracker = TurnTransitionTracker()
        tracker.begin(action)

        returned = tracker.observe_runtime(
            session=first.battle.session_key,
            turn=first.battle.turn_number + 2,
            current_player=first.battle.current_turn_player,
            local_username=first.battle.current_turn_player,
        )

        self.assertEqual(
            returned.kind,
            TurnTransitionKind.LOCAL_TURN_RETURNED_BY_AUTHORITATIVE_ADVANCE,
        )
        self.assertIsNone(tracker.action)

    def test_direct_runtime_odd_local_advance_remains_unconfirmed(self) -> None:
        first = self._state()
        action = AutonomousActionIdentity.from_decision(
            first, BasicPolicyEngine().decide(first), attempt=1
        )
        tracker = TurnTransitionTracker()
        tracker.begin(action)

        self.assertIsNone(
            tracker.observe_runtime(
                session=first.battle.session_key,
                turn=first.battle.turn_number + 3,
                current_player=first.battle.current_turn_player,
                local_username=first.battle.current_turn_player,
            )
        )
        self.assertTrue(tracker.unconfirmed_local_seen)

    def test_published_even_turn_advance_proves_missed_opponent_sample(self) -> None:
        first = self._state()
        action = AutonomousActionIdentity.from_decision(
            first, BasicPolicyEngine().decide(first), attempt=1
        )
        tracker = TurnTransitionTracker()
        tracker.begin(action)
        returned_state = replace(
            first,
            battle=replace(
                first.battle,
                srv_seq=first.battle.srv_seq + 4,
                turn_number=first.battle.turn_number + 2,
            ),
        )

        returned = tracker.observe(returned_state)

        self.assertEqual(
            returned.kind,
            TurnTransitionKind.LOCAL_TURN_RETURNED_BY_AUTHORITATIVE_ADVANCE,
        )
        self.assertIsNotNone(returned.new_source)
        self.assertIsNone(tracker.action)

    def test_no_safe_move_pause_allows_nonboard_actions_and_real_sword(self) -> None:
        state = self._state()
        sword = BasicPolicyEngine().decide(state)
        self.assertEqual(sword.trace.policy_step, "STEP_2_SWORD")
        self.assertFalse(
            _must_pause_for_no_safe_move(
                sword,
                legal_move_count=3,
                safe_move_count=0,
                first_local_turn=False,
            )
        )

        non_sword = replace(
            sword,
            trace=replace(sword.trace, policy_step="STEP_3_RAGE"),
        )
        self.assertTrue(
            _must_pause_for_no_safe_move(
                non_sword,
                legal_move_count=3,
                safe_move_count=0,
                first_local_turn=False,
            )
        )

        for action, step in (
            (PolicyAction.EVOLVE, "STEP_1_EVOLVE"),
            (PolicyAction.CAST, "STEP_5_CAST"),
            (PolicyAction.PASS, "STEP_6_PASS"),
        ):
            with self.subTest(action=action):
                non_board_action = replace(
                    sword,
                    action=action,
                    move=None,
                    trace=replace(sword.trace, policy_step=step),
                )
                self.assertFalse(
                    _must_pause_for_no_safe_move(
                        non_board_action,
                        legal_move_count=1,
                        safe_move_count=0,
                        first_local_turn=False,
                    )
                )

    def test_exact_direct_runtime_swap_transition_proves_acceptance(self) -> None:
        state = self._state()
        decision = BasicPolicyEngine().decide(state)
        self.assertIsNotNone(decision.move)
        identity = AutonomousActionIdentity.from_decision(state, decision)
        pending = PendingAutonomousAction(
            identity,
            1.0,
            0,
            None,
            local_move_sequence_before=4,
            last_move_sequence_before=4,
        )
        first, second = identity.target

        self.assertTrue(
            direct_runtime_proves_swap_accepted(
                pending,
                session=identity.source.session,
                turn=identity.source.turn + 1,
                current_player="boss",
                local_username=identity.source.current_turn_player,
                local_move_sequence=5,
                last_move_sequence=5,
                last_move_from_col=first[1],
                last_move_from_row=7 - first[0],
                last_move_to_col=second[1],
                last_move_to_row=7 - second[0],
            )
        )

    def test_exact_direct_runtime_cast_transition_proves_acceptance(self) -> None:
        state = self._state()
        base = BasicPolicyEngine().decide(state)
        cast = replace(
            base,
            action=PolicyAction.CAST,
            move=None,
            card_object_address=0x1234,
            consumes_turn=True,
        )
        identity = AutonomousActionIdentity.from_decision(state, cast)
        pending = PendingAutonomousAction(
            identity,
            1.0,
            590,
            160,
            local_move_sequence_before=19,
            last_move_sequence_before=19,
        )
        valid = dict(
            session=identity.source.session,
            turn=identity.source.turn + 1,
            current_player="boss",
            local_username=identity.source.current_turn_player,
            local_move_sequence=19,
            last_move_sequence=19,
        )
        self.assertTrue(direct_runtime_proves_cast_accepted(pending, **valid))
        for conflict in (
            {"turn": identity.source.turn + 2},
            {"current_player": identity.source.current_turn_player},
            {"local_move_sequence": 20},
            {"last_move_sequence": 20},
        ):
            with self.subTest(conflict=conflict):
                self.assertFalse(
                    direct_runtime_proves_cast_accepted(
                        pending, **{**valid, **conflict}
                    )
                )

    def test_combat_end_preserves_prior_safe_terminal_reason(self) -> None:
        self.assertEqual(
            _combat_end_stop_reason(
                "ACTION_RESPONSE_TIMEOUT", AutonomousStatus.AUTO_PAUSED
            ),
            "ACTION_RESPONSE_TIMEOUT",
        )
        self.assertEqual(
            _combat_end_stop_reason(
                "DEAD_BOARD_NO_REFRESH", AutonomousStatus.RECOVERY_REQUIRED
            ),
            "DEAD_BOARD_NO_REFRESH",
        )
        self.assertEqual(
            _combat_end_stop_reason(
                "PROCESS_OR_CONTROLLER_STOPPED", AutonomousStatus.AUTO_PAUSED
            ),
            "COMBAT_LIFECYCLE_ENDED",
        )

    def test_postmatch_lifecycle_ends_ownership_without_board_lost_literal(self) -> None:
        session = SimpleNamespace(match_id="M_terminal")
        self.assertTrue(
            _combat_ownership_ended(
                lifecycle_event="postmatch",
                lifecycle_state=CombatLifecycleState.POSTMATCH,
                session_seen=True,
                active_session=session,
                state=None,
            )
        )
        self.assertFalse(
            _combat_ownership_ended(
                lifecycle_event=None,
                lifecycle_state=CombatLifecycleState.ACTIVE,
                session_seen=True,
                active_session=session,
                state=None,
            )
        )

    def test_direct_runtime_swap_acceptance_rejects_each_conflict(self) -> None:
        state = self._state()
        identity = AutonomousActionIdentity.from_decision(
            state, BasicPolicyEngine().decide(state)
        )
        pending = PendingAutonomousAction(
            identity,
            1.0,
            0,
            None,
            local_move_sequence_before=4,
            last_move_sequence_before=4,
        )
        first, second = identity.target
        valid = dict(
            session=identity.source.session,
            turn=identity.source.turn + 1,
            current_player="boss",
            local_username=identity.source.current_turn_player,
            local_move_sequence=5,
            last_move_sequence=5,
            last_move_from_col=first[1],
            last_move_from_row=7 - first[0],
            last_move_to_col=second[1],
            last_move_to_row=7 - second[0],
        )
        conflicts = (
            {"turn": identity.source.turn + 2},
            {"current_player": identity.source.current_turn_player},
            {"local_move_sequence": 6},
            {"last_move_sequence": 4},
            {"last_move_to_col": (second[1] + 1) % 8},
        )

        for conflict in conflicts:
            with self.subTest(conflict=conflict):
                sample = {**valid, **conflict}
                self.assertFalse(
                    direct_runtime_proves_swap_accepted(pending, **sample)
                )

    def test_direct_local_actor_lag_waits_before_observing_opponent(self) -> None:
        first = self._state()
        action = AutonomousActionIdentity.from_decision(
            first, BasicPolicyEngine().decide(first), attempt=1
        )
        tracker = TurnTransitionTracker()
        tracker.begin(action)

        transient_local = tracker.observe_runtime(
            session=first.battle.session_key,
            turn=first.battle.turn_number + 1,
            current_player=first.battle.current_turn_player,
            local_username=first.battle.current_turn_player,
        )

        self.assertIsNone(transient_local)
        self.assertTrue(tracker.unconfirmed_local_seen)
        self.assertIsNotNone(tracker.action)

        opponent = tracker.observe_runtime(
            session=first.battle.session_key,
            turn=first.battle.turn_number + 1,
            current_player="boss",
            local_username=first.battle.current_turn_player,
        )
        self.assertEqual(opponent.kind, TurnTransitionKind.OPPONENT_TURN)
        self.assertFalse(tracker.unconfirmed_local_seen)

    def test_unresolved_local_actor_lag_fails_closed_only_on_expiry(self) -> None:
        first = self._state()
        action = AutonomousActionIdentity.from_decision(
            first, BasicPolicyEngine().decide(first), attempt=1
        )
        tracker = TurnTransitionTracker()
        tracker.begin(action)
        self.assertIsNone(
            tracker.observe_runtime(
                session=first.battle.session_key,
                turn=first.battle.turn_number + 1,
                current_player=first.battle.current_turn_player,
                local_username=first.battle.current_turn_player,
            )
        )

        expired = tracker.expire_unconfirmed_local()

        self.assertEqual(
            expired.kind,
            TurnTransitionKind.LOCAL_TURN_WITHOUT_OBSERVED_OPPONENT,
        )
        self.assertIsNone(tracker.action)


class CombatResultClassificationTests(unittest.TestCase):
    def test_postmatch_terminal_boss_hp_classifies_win(self) -> None:
        state = GameState(
            GamePhase.UNKNOWN,
            "2026-08-16T00:00:00Z",
            player=ParticipantState(1, is_local=True, hp=42, max_hp=100),
            opponents=(
                ParticipantState(99, is_local=False, is_boss=True, hp=0, max_hp=500),
            ),
        )

        self.assertEqual(_classify_combat_result(state), "WIN")

    def test_postmatch_terminal_player_hp_classifies_loss(self) -> None:
        state = GameState(
            GamePhase.UNKNOWN,
            "2026-08-16T00:00:00Z",
            player=ParticipantState(1, is_local=True, hp=0, max_hp=100),
            opponents=(
                ParticipantState(99, is_local=False, is_boss=True, hp=12, max_hp=500),
            ),
        )

        self.assertEqual(_classify_combat_result(state), "LOSS")

    def test_missing_terminal_stats_stays_unknown(self) -> None:
        state = GameState(GamePhase.UNKNOWN, "2026-08-16T00:00:00Z")

        self.assertEqual(_classify_combat_result(state), "ENDED_RESULT_UNKNOWN")


class GameplayUiTests(unittest.TestCase):
    def test_blank_capture_never_proves_a_card(self) -> None:
        rgb = bytes(800 * 450 * 3)
        for control in GameplayControl:
            result = locate_gameplay_control(rgb, 800, 450, control)
            self.assertFalse(result.found)
            self.assertIsNone(result.normalized_point)

    def test_colorful_tiles_are_control_specific(self) -> None:
        width, height = 800, 450
        rgb = bytearray(width * height * 3)
        for control, point, color in (
            (GameplayControl.EVOLVE, (0.417, 0.836), (40, 130, 230)),
            (GameplayControl.CAST_ATTACK, (0.474, 0.836), (230, 80, 30)),
        ):
            cx, cy = round(point[0] * width), round(point[1] * height)
            for y in range(cy - 30, cy + 30):
                for x in range(cx - 20, cx + 20):
                    offset = (y * width + x) * 3
                    rgb[offset : offset + 3] = bytes(color if (x + y) % 3 else (245, 245, 245))
            self.assertTrue(
                locate_gameplay_control(bytes(rgb), width, height, control).found
            )

    def test_runtime_slots_recenter_two_tile_loadout(self) -> None:
        width, height = 1280, 710
        rgb = bytearray(width * height * 3)
        expected = {
            GameplayControl.EVOLVE: (0.471, 0.836),
            GameplayControl.CAST_ATTACK: (0.529, 0.836),
        }
        colors = {
            GameplayControl.EVOLVE: (40, 130, 230),
            GameplayControl.CAST_ATTACK: (230, 80, 30),
        }
        for control, point in expected.items():
            cx, cy = round(point[0] * width), round(point[1] * height)
            for y in range(cy - 35, cy + 35):
                for x in range(cx - 24, cx + 24):
                    offset = (y * width + x) * 3
                    rgb[offset : offset + 3] = bytes(
                        colors[control] if (x + y) % 3 else (245, 245, 245)
                    )

        evolve = locate_gameplay_control(
            bytes(rgb),
            width,
            height,
            GameplayControl.EVOLVE,
            slot_index=0,
            slot_count=2,
        )
        attack = locate_gameplay_control(
            bytes(rgb),
            width,
            height,
            GameplayControl.CAST_ATTACK,
            slot_index=1,
            slot_count=2,
        )

        self.assertTrue(evolve.found)
        self.assertEqual(evolve.normalized_point, expected[GameplayControl.EVOLVE])
        self.assertTrue(attack.found)
        self.assertEqual(
            attack.normalized_point, expected[GameplayControl.CAST_ATTACK]
        )

    def test_runtime_four_slot_strip_preserves_v1_calibration(self) -> None:
        width, height = 800, 450
        rgb = bytearray(width * height * 3)
        for control, point, color in (
            (GameplayControl.EVOLVE, (0.413, 0.836), (40, 130, 230)),
            (GameplayControl.CAST_ATTACK, (0.471, 0.836), (230, 80, 30)),
        ):
            cx, cy = round(point[0] * width), round(point[1] * height)
            for y in range(cy - 30, cy + 30):
                for x in range(cx - 20, cx + 20):
                    offset = (y * width + x) * 3
                    rgb[offset : offset + 3] = bytes(
                        color if (x + y) % 3 else (245, 245, 245)
                    )
            located = locate_gameplay_control(
                bytes(rgb),
                width,
                height,
                control,
                slot_index=(0 if control is GameplayControl.EVOLVE else 1),
                slot_count=4,
            )
            self.assertTrue(located.found)
            self.assertEqual(located.normalized_point, point)

    def test_special_pet_skill_layout_is_deferred_fail_closed(self) -> None:
        layout = resolve_runtime_card_strip(
            selected_card_data_addresses=(0x1000, 0x2000, 0x3000),
            rendered_card_data_addresses=(0x1000, 0x2000, 0x3000, 0x4000),
            cards_in_hand_count=5,
            fusion_expected=True,
            fusion_skill_card_data_address=0x4000,
        )

        self.assertFalse(layout.resolved)
        self.assertEqual(layout.slot_count, 5)
        self.assertIsNone(layout.fusion_slot)
        self.assertEqual(layout.card_slots, ())
        self.assertEqual(layout.reason, "pet_skill_layout_deferred")

    def test_arbitrary_selected_order_maps_attack_by_card_data_not_type_slot(self) -> None:
        layout = resolve_runtime_card_strip(
            selected_card_data_addresses=(0xA000, 0xB000, 0xC000, 0xD000),
            rendered_card_data_addresses=(0xD000, 0xA000),
            cards_in_hand_count=5,
            fusion_expected=True,
            fusion_skill_card_data_address=None,
        )

        self.assertTrue(layout.resolved)
        self.assertEqual(layout.fusion_slot, 0)
        self.assertEqual(layout.slot_for_card_data(0xA000), 1)
        self.assertEqual(layout.slot_for_card_data(0xD000), 4)

    def test_ambiguous_or_mismatched_runtime_layout_fails_closed(self) -> None:
        mismatch = resolve_runtime_card_strip(
            selected_card_data_addresses=(0x1000,),
            rendered_card_data_addresses=(0x1000,),
            cards_in_hand_count=1,
            fusion_expected=True,
            fusion_skill_card_data_address=None,
        )
        duplicate = resolve_runtime_card_strip(
            selected_card_data_addresses=(0x1000, 0x1000),
            rendered_card_data_addresses=(0x1000,),
            cards_in_hand_count=2,
            fusion_expected=False,
            fusion_skill_card_data_address=None,
        )

        self.assertFalse(mismatch.resolved)
        self.assertFalse(duplicate.resolved)
        blank = bytes(800 * 450 * 3)
        self.assertFalse(
            locate_gameplay_control(
                blank,
                800,
                450,
                GameplayControl.CAST_ATTACK,
                slot_index=None,
                slot_count=4,
            ).found
        )

    def test_board_only_and_no_fusion_loadouts_resolve_without_fixed_slots(self) -> None:
        empty = resolve_runtime_card_strip(
            selected_card_data_addresses=(),
            rendered_card_data_addresses=(),
            cards_in_hand_count=0,
            fusion_expected=False,
            fusion_skill_card_data_address=None,
        )
        ordinary = resolve_runtime_card_strip(
            selected_card_data_addresses=(0x1000, 0x2000, 0x3000),
            rendered_card_data_addresses=(0x2000,),
            cards_in_hand_count=3,
            fusion_expected=False,
            fusion_skill_card_data_address=None,
        )

        self.assertTrue(empty.resolved)
        self.assertEqual((empty.slot_count, empty.fusion_slot), (0, None))
        self.assertTrue(ordinary.resolved)
        self.assertEqual(ordinary.slot_for_card_data(0x1000), 0)
        self.assertEqual(ordinary.slot_for_card_data(0x3000), 2)

    def test_optional_card_locator_failure_masks_only_that_turn_action(self) -> None:
        card = attack_card()
        state = combat_state(mana=600, cards=(card,))
        fusion = replace(
            state.fusion,
            used=False,
            available=True,
            ui_interactable=True,
            ui_address=0x21000000000,
            ui_slot=0,
            ui_slot_count=2,
        )
        state = replace(state, fusion=fusion)

        cast_masked = _without_optional_card_actions(
            state, frozenset({PolicyAction.CAST})
        )
        evolve_masked = _without_optional_card_actions(
            state, frozenset({PolicyAction.EVOLVE})
        )

        self.assertFalse(cast_masked.cards[0].interactable)
        self.assertTrue(cast_masked.fusion.ui_interactable)
        self.assertTrue(evolve_masked.cards[0].interactable)
        self.assertFalse(evolve_masked.fusion.ui_interactable)


if __name__ == "__main__":
    unittest.main()
