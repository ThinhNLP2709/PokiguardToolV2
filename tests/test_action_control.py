from __future__ import annotations

from dataclasses import replace
from pathlib import Path
import sys
import unittest


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.action_control import (
    AckOutcome,
    AckStatus,
    ActionIdentity,
    ActionLock,
    SkipTracker,
)
from test_actionability import SESSION, actionable_state


IDENTITY = ActionIdentity(SESSION, 75, "a" * 64, (4, 2), (4, 3))


class ActionLockTests(unittest.TestCase):
    def test_identity_can_be_reserved_only_once(self) -> None:
        lock = ActionLock()
        self.assertTrue(lock.reserve(IDENTITY))
        self.assertFalse(lock.reserve(IDENTITY))

    def test_new_sequence_acknowledges_and_unlocks(self) -> None:
        lock = ActionLock()
        lock.reserve(IDENTITY)
        lock.begin(
            IDENTITY,
            source_turn_number=10,
            source_turn_player="Happi",
            now=1.0,
        )
        state = actionable_state()
        state = replace(
            state,
            battle=replace(
                state.battle,
                srv_seq=77,
                board_hash="b" * 64,
            ),
        )
        result = lock.observe(state, now=1.3)
        self.assertEqual(result.status, AckStatus.ACKNOWLEDGED)
        self.assertEqual(result.outcome, AckOutcome.MOVE_ACCEPTED)
        self.assertEqual(result.latency_ms, 300)
        self.assertFalse(lock.locked)

    def test_raw_acked_sequence_unlocks_before_stable_board_publish(self) -> None:
        lock = ActionLock(timeout_seconds=7.0)
        identity = replace(IDENTITY, source_srv_seq=10)
        self.assertTrue(lock.reserve(identity))
        lock.begin(
            identity,
            source_turn_number=2,
            source_turn_player="local",
            now=100.0,
        )

        result = lock.observe(
            None,
            now=103.5,
            observed_srv_seq=11,
        )

        self.assertEqual(result.status, AckStatus.ACKNOWLEDGED)
        self.assertEqual(result.outcome, AckOutcome.MOVE_ACCEPTED)
        self.assertEqual(result.new_srv_seq, 11)
        self.assertFalse(lock.locked)

    def test_same_state_waits_then_times_out_without_retry(self) -> None:
        lock = ActionLock(timeout_seconds=2.0)
        lock.reserve(IDENTITY)
        lock.begin(
            IDENTITY,
            source_turn_number=10,
            source_turn_player="Happi",
            now=1.0,
        )
        self.assertEqual(
            lock.observe(actionable_state(), now=2.0).status,
            AckStatus.WAITING,
        )
        result = lock.observe(actionable_state(), now=3.1)
        self.assertEqual(result.status, AckStatus.TIMEOUT)
        self.assertEqual(result.outcome, AckOutcome.MOVE_NO_STATE_CHANGE)
        self.assertTrue(lock.was_executed(IDENTITY))


class SkipTrackerTests(unittest.TestCase):
    def test_two_unique_local_states_auto_pause(self) -> None:
        tracker = SkipTracker()
        first = actionable_state()
        second = replace(
            first,
            battle=replace(
                first.battle, srv_seq=77, board_hash="b" * 64
            ),
        )
        self.assertTrue(tracker.record(first, ["SOLVER_SKIP"]))
        self.assertFalse(tracker.record(first, ["SOLVER_SKIP"]))
        self.assertFalse(tracker.auto_paused)
        self.assertTrue(tracker.record(second, ["GAME_NOT_FOREGROUND"]))
        self.assertTrue(tracker.auto_paused)
        self.assertEqual(tracker.consecutive, 2)

        third = replace(
            first,
            battle=replace(
                first.battle, srv_seq=79, board_hash="c" * 64
            ),
        )
        self.assertFalse(tracker.record(third, ["third"]))
        self.assertEqual(tracker.consecutive, 2)
        self.assertEqual(
            tracker.reasons,
            ["SOLVER_SKIP", "GAME_NOT_FOREGROUND"],
        )

    def test_ack_and_new_session_reset(self) -> None:
        tracker = SkipTracker()
        tracker.record(actionable_state(), ["one"])
        tracker.acknowledged()
        self.assertEqual(tracker.consecutive, 0)


if __name__ == "__main__":
    unittest.main()
