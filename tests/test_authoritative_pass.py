from __future__ import annotations

from dataclasses import replace
import unittest
from pathlib import Path
import sys


SRC = Path(__file__).resolve().parents[1] / "src"
if str(SRC) not in sys.path:
    sys.path.insert(0, str(SRC))

from pokiguard_v2.authoritative_pass import (
    AuthoritativePassCoordinator,
    PassResultKind,
    PassWaitState,
)
from pokiguard_v2.game_owned_idle import (
    GameOwnedIdleState,
    PassReadiness,
    PassReadinessResult,
)


SESSION = "epoch=1|board=0x1234|match=M_test"


def readiness(value: PassReadiness) -> PassReadinessResult:
    return PassReadinessResult(
        value,
        can_pass_now=value
        in {PassReadiness.RESET_BASELINE_CONFIRMED, PassReadiness.PASS_ALLOWED},
        must_act_now=value is PassReadiness.PASS_FORBIDDEN_MANDATORY_ACTION,
        reason="fixture",
        state=None,
    )


def idle(count: int, turn: int = 5) -> GameOwnedIdleState:
    return GameOwnedIdleState(
        session_id=SESSION,
        username="happi",
        idle_count=count,
        threshold=3,
        source_message_type="MATCH_TURN_END",
        source_srv_seq=12,
        source_turn=turn,
        source_timestamp="server",
        observed_timestamp="local",
    )


class AuthoritativePassTests(unittest.TestCase):
    def start(self, controller: AuthoritativePassCoordinator, inputs: int = 4):
        return controller.start(
            session_id=SESSION,
            match_id="M_test",
            local_username="happi",
            source_turn=3,
            source_srv_seq=10,
            board_hash="abc",
            policy_reason="STEP_6_PASS",
            started_timestamp="2026-08-14T10:04:48Z",
            turn_remaining=12,
            idle_before=readiness(PassReadiness.RESET_BASELINE_CONFIRMED),
            gameplay_inputs_total=inputs,
            source_local_move_sequence=2,
            lifecycle_active=True,
            is_local_turn=True,
            is_first_local_turn=False,
            sequence_desync=False,
            participants_alive=True,
            board_current_valid=True,
            policy_selected_pass=True,
        )

    def test_pass_sends_zero_input_and_confirms_idle_one(self) -> None:
        controller = AuthoritativePassCoordinator(max_auto_passes=1)
        self.start(controller)
        controller.observe_turn_end()
        result = controller.observe_authoritative_idle(
            idle(1),
            timestamp="done",
            gameplay_inputs_total=4,
            newly_observed_after_start=True,
        )
        self.assertEqual(result.result, PassResultKind.PASS_CONFIRMED_IDLE_1)
        self.assertEqual(result.gameplay_inputs_during_wait, 0)
        self.assertEqual(controller.confirmed_passes, 1)

    def test_unknown_lifecycle_during_wait_is_not_combat_end(self) -> None:
        controller = AuthoritativePassCoordinator(max_auto_passes=1)
        self.start(controller)
        result = controller.observe_runtime(
            timestamp="poll",
            gameplay_inputs_total=4,
            session_id=SESSION,
            lifecycle_active=None,
            sequence_desync=False,
            current_turn=4,
            is_local_turn=False,
            current_local_move_sequence=2,
        )
        self.assertIsNone(result)
        self.assertEqual(controller.state, PassWaitState.PASS_WAIT)

    def test_direct_warning_before_turn_transition_is_confirmed_after_ordering(self) -> None:
        controller = AuthoritativePassCoordinator(max_auto_passes=2)
        self.start(controller)
        direct = replace(
            idle(1),
            source_message_type="MATCH_AFK_WARN",
            source_turn=None,
            source_srv_seq=None,
            source_timestamp="2026-08-14T17:04:57",
        )
        self.assertIsNone(
            controller.observe_authoritative_idle(
                direct,
                timestamp="warning",
                gameplay_inputs_total=4,
                newly_observed_after_start=True,
            )
        )
        result = controller.observe_runtime(
            timestamp="next-turn",
            gameplay_inputs_total=4,
            session_id=SESSION,
            lifecycle_active=True,
            sequence_desync=False,
            current_turn=5,
            is_local_turn=True,
            current_local_move_sequence=2,
        )
        self.assertIsNotNone(result)
        self.assertEqual(result.result, PassResultKind.PASS_CONFIRMED_IDLE_1)
        self.assertEqual(result.authoritative_idle, direct)
        self.assertEqual(result.gameplay_inputs_during_wait, 0)

    def test_second_pass_confirms_two_and_budget_blocks_third(self) -> None:
        controller = AuthoritativePassCoordinator(max_auto_passes=2)
        self.start(controller)
        first = controller.observe_authoritative_idle(
            idle(1),
            timestamp="done-1",
            gameplay_inputs_total=4,
            newly_observed_after_start=True,
        )
        self.assertEqual(first.result, PassResultKind.PASS_CONFIRMED_IDLE_1)
        controller.take_terminal()
        controller.start(
            session_id=SESSION,
            match_id="M_test",
            local_username="happi",
            source_turn=5,
            source_srv_seq=12,
            board_hash="def",
            policy_reason="STEP_6_PASS",
            started_timestamp="start-2",
            turn_remaining=12,
            idle_before=readiness(PassReadiness.PASS_ALLOWED),
            gameplay_inputs_total=4,
            source_local_move_sequence=2,
            lifecycle_active=True,
            is_local_turn=True,
            is_first_local_turn=False,
            sequence_desync=False,
            participants_alive=True,
            board_current_valid=True,
            policy_selected_pass=True,
        )
        second = controller.observe_authoritative_idle(
            idle(2, turn=7),
            timestamp="done-2",
            gameplay_inputs_total=4,
            newly_observed_after_start=True,
        )
        self.assertEqual(second.result, PassResultKind.PASS_CONFIRMED_IDLE_2)
        controller.take_terminal()
        with self.assertRaisesRegex(ValueError, "budget"):
            self.start(controller)

    def test_consuming_reset_starts_a_new_idle_sequence_at_one(self) -> None:
        controller = AuthoritativePassCoordinator(max_auto_passes=2)
        self.start(controller)
        first = controller.observe_authoritative_idle(
            idle(1),
            timestamp="done-1",
            gameplay_inputs_total=4,
            newly_observed_after_start=True,
        )
        self.assertEqual(first.result, PassResultKind.PASS_CONFIRMED_IDLE_1)
        controller.take_terminal()

        controller.begin_new_reset_cycle(SESSION)
        next_attempt = self.start(controller)
        self.assertEqual(next_attempt.pass_index, 1)
        after_reset = controller.observe_authoritative_idle(
            idle(1),
            timestamp="done-after-reset",
            gameplay_inputs_total=4,
            newly_observed_after_start=True,
        )
        self.assertEqual(
            after_reset.result, PassResultKind.PASS_CONFIRMED_IDLE_1
        )

    def test_first_turn_never_enters_pass_wait(self) -> None:
        controller = AuthoritativePassCoordinator(max_auto_passes=1)
        with self.assertRaisesRegex(ValueError, "first_local_turn"):
            controller.start(
                session_id=SESSION,
                match_id="M_test",
                local_username="happi",
                source_turn=1,
                source_srv_seq=1,
                board_hash="abc",
                policy_reason="STEP_6_PASS",
                started_timestamp="start",
                turn_remaining=14,
                idle_before=readiness(PassReadiness.PASS_ALLOWED),
                gameplay_inputs_total=0,
                source_local_move_sequence=0,
                lifecycle_active=True,
                is_local_turn=True,
                is_first_local_turn=True,
                sequence_desync=False,
                participants_alive=True,
                board_current_valid=True,
                policy_selected_pass=True,
            )
        self.assertEqual(controller.state, PassWaitState.IDLE)

    def test_manual_action_aborts_pass_wait(self) -> None:
        controller = AuthoritativePassCoordinator(max_auto_passes=1)
        self.start(controller)
        result = controller.abort_user_action(
            timestamp="manual", gameplay_inputs_total=4, detail="manual SWAP_ACK"
        )
        self.assertEqual(result.result, PassResultKind.PASS_ABORTED_USER_ACTION)

    def test_sequence_desync_aborts_immediately(self) -> None:
        controller = AuthoritativePassCoordinator(max_auto_passes=1)
        self.start(controller)
        result = controller.observe_runtime(
            timestamp="desync",
            gameplay_inputs_total=4,
            session_id=SESSION,
            lifecycle_active=True,
            sequence_desync=True,
            current_turn=3,
            is_local_turn=True,
            current_local_move_sequence=2,
        )
        self.assertEqual(result.result, PassResultKind.SEQUENCE_DESYNC)

    def test_next_local_turn_without_warning_is_unconfirmed(self) -> None:
        controller = AuthoritativePassCoordinator(max_auto_passes=1)
        self.start(controller)
        result = controller.observe_runtime(
            timestamp="next-local",
            gameplay_inputs_total=4,
            session_id=SESSION,
            lifecycle_active=True,
            sequence_desync=False,
            current_turn=5,
            is_local_turn=True,
            current_local_move_sequence=2,
            scan_complete_for_next_local_turn=True,
        )
        self.assertIsNone(result)
        result = controller.observe_runtime(
            timestamp="next-local-2",
            gameplay_inputs_total=4,
            session_id=SESSION,
            lifecycle_active=True,
            sequence_desync=False,
            current_turn=5,
            is_local_turn=True,
            current_local_move_sequence=2,
            scan_complete_for_next_local_turn=True,
        )
        self.assertEqual(result.result, PassResultKind.PASS_STATE_UNCONFIRMED)

    def test_move_sequence_change_marks_manual_swap(self) -> None:
        controller = AuthoritativePassCoordinator(max_auto_passes=1)
        self.start(controller)
        result = controller.observe_runtime(
            timestamp="manual",
            gameplay_inputs_total=4,
            session_id=SESSION,
            lifecycle_active=True,
            sequence_desync=False,
            current_turn=4,
            is_local_turn=False,
            current_local_move_sequence=3,
        )
        self.assertEqual(result.result, PassResultKind.PASS_ABORTED_USER_ACTION)

    def test_decreased_move_sequence_is_not_manual_action_evidence(self) -> None:
        controller = AuthoritativePassCoordinator(max_auto_passes=1)
        self.start(controller)
        result = controller.observe_runtime(
            timestamp="stale-reset-read",
            gameplay_inputs_total=4,
            session_id=SESSION,
            lifecycle_active=True,
            sequence_desync=False,
            current_turn=3,
            is_local_turn=True,
            current_local_move_sequence=0,
        )
        self.assertIsNone(result)
        self.assertEqual(controller.state, PassWaitState.PASS_WAIT)

    def test_pass_module_has_no_input_executor_or_local_idle_arithmetic(self) -> None:
        root = Path(__file__).resolve().parents[1]
        pass_source = (root / "src" / "pokiguard_v2" / "authoritative_pass.py").read_text(
            encoding="utf-8"
        )
        idle_source = (root / "src" / "pokiguard_v2" / "game_owned_idle.py").read_text(
            encoding="utf-8"
        )
        self.assertNotIn("win32_input", pass_source)
        self.assertNotIn("send_swap", pass_source)
        self.assertNotIn("send_normalized_point", pass_source)
        self.assertNotIn("idle_count +=", idle_source)
        self.assertNotIn("idle_count -=", idle_source)


if __name__ == "__main__":
    unittest.main()
