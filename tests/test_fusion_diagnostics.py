from __future__ import annotations

import unittest

from pokiguard_v2.fusion_diagnostics import (
    FusionAttemptTracker,
    FusionIdleReset,
    FusionResponse,
    FusionRuntimeSnapshot,
    FusionTurnConsumption,
)
from pokiguard_v2.state import FusionState


def fusion(*, turn: int, used: bool, locked: bool) -> FusionState:
    return FusionState(
        enabled=True,
        available=not used and not locked,
        used=used,
        locked_this_turn=locked,
        last_attempt_turn=turn,
        mana_cost=160,
    )


def snapshot(
    timestamp: str,
    *,
    turn: int,
    mana: int,
    fusion_state: FusionState,
    ui: bool,
    idle: int | None = 1,
) -> FusionRuntimeSnapshot:
    return FusionRuntimeSnapshot(
        session_id="session",
        timestamp=timestamp,
        mana=mana,
        current_turn_player="happi",
        local_username="happi",
        turn_number=turn,
        turn_remaining=10,
        idle_count=idle,
        idle_threshold=3 if idle is not None else None,
        idle_authoritative=idle is not None,
        fusion=fusion_state,
        ui_interactable=ui,
        ui_address=0x20000001000,
    )


class FusionDiagnosticTests(unittest.TestCase):
    def test_response_visible_before_durable_attempt_transition_is_merged(self) -> None:
        tracker = FusionAttemptTracker()
        before = snapshot(
            "t0",
            turn=7,
            mana=210,
            fusion_state=fusion(turn=-1, used=False, locked=False),
            ui=False,
        )
        tracker.observe_snapshot(before)
        record = tracker.observe_response(
            FusionResponse("t1", "server", False),
            before,
        )
        changed = tracker.observe_snapshot(
            snapshot(
                "t2",
                turn=7,
                mana=50,
                fusion_state=fusion(turn=7, used=False, locked=True),
                ui=False,
            )
        )
        self.assertEqual(len(tracker.records), 1)
        self.assertEqual(changed, (record,))
        self.assertEqual(record.attempt_turn, 7)
        self.assertEqual(record.mana_delta, -160)
        self.assertEqual(
            record.turn_consumption,
            FusionTurnConsumption.NOT_CONSUMED_AT_RESPONSE,
        )
        self.assertEqual(record.response_snapshot.timestamp, "t0")
        self.assertEqual(record.after_response.timestamp, "t2")

    def test_early_response_is_attributed_to_current_turn_not_previous_attempt(self) -> None:
        tracker = FusionAttemptTracker()
        previous_attempt = tracker.observe_snapshot(
            snapshot(
                "t0",
                turn=5,
                mana=50,
                fusion_state=fusion(turn=5, used=False, locked=True),
                ui=False,
            )
        )[0]
        tracker.observe_snapshot(
            snapshot(
                "t1",
                turn=7,
                mana=210,
                fusion_state=fusion(turn=5, used=False, locked=False),
                ui=True,
            )
        )
        current_attempt = tracker.observe_response(
            FusionResponse("t2", "server", False),
            snapshot(
                "t2",
                turn=7,
                mana=50,
                fusion_state=fusion(turn=5, used=False, locked=False),
                ui=False,
            ),
        )
        self.assertIsNone(previous_attempt.response)
        self.assertEqual(current_attempt.attempt_turn, 7)
        tracker.observe_snapshot(
            snapshot(
                "t3",
                turn=7,
                mana=50,
                fusion_state=fusion(turn=7, used=False, locked=True),
                ui=False,
            )
        )
        self.assertEqual(len(tracker.records), 2)
        self.assertIs(tracker.records[-1], current_attempt)
        self.assertIn(
            "MatchService.LocalFusionLastAttemptTurn changed",
            current_attempt.request_evidence,
        )

    def test_failed_attempt_waits_for_response_and_actionable_next_turn(self) -> None:
        tracker = FusionAttemptTracker()
        tracker.observe_snapshot(
            snapshot(
                "t0", turn=4, mana=200, fusion_state=fusion(turn=-1, used=False, locked=False), ui=True
            )
        )
        records = tracker.observe_snapshot(
            snapshot(
                "t1", turn=5, mana=200, fusion_state=fusion(turn=5, used=False, locked=True), ui=False
            )
        )
        self.assertEqual(len(records), 1)
        record = records[0]
        self.assertFalse(record.retry_allowed or False)
        tracker.observe_response(
            FusionResponse("t2", "server", False, reason="drop"),
            snapshot(
                "t2", turn=5, mana=200, fusion_state=fusion(turn=5, used=False, locked=True), ui=False
            ),
        )
        self.assertFalse(record.retry_allowed)
        tracker.observe_snapshot(
            snapshot(
                "t3", turn=6, mana=200, fusion_state=fusion(turn=5, used=False, locked=False), ui=True
            )
        )
        self.assertTrue(record.retry_allowed)
        self.assertEqual(record.mana_delta, 0)
        tracker.observe_snapshot(
            snapshot(
                "t4",
                turn=8,
                mana=40,
                fusion_state=fusion(turn=7, used=True, locked=False),
                ui=False,
            )
        )
        self.assertTrue(record.retry_allowed)

    def test_success_preserves_same_local_turn_and_costs_observed_mana(self) -> None:
        tracker = FusionAttemptTracker()
        tracker.observe_snapshot(
            snapshot(
                "t0", turn=9, mana=321, fusion_state=fusion(turn=-1, used=False, locked=False), ui=True
            )
        )
        tracker.observe_snapshot(
            snapshot(
                "t1", turn=9, mana=321, fusion_state=fusion(turn=9, used=False, locked=True), ui=False
            )
        )
        record = tracker.observe_response(
            FusionResponse("t2", "server", True),
            snapshot(
                "t2", turn=9, mana=161, fusion_state=fusion(turn=9, used=True, locked=True), ui=False
            ),
        )
        self.assertEqual(record.mana_delta, -160)
        self.assertEqual(
            record.turn_consumption,
            FusionTurnConsumption.NOT_CONSUMED_AT_RESPONSE,
        )
        self.assertFalse(record.retry_allowed)

    def test_idle_is_unknown_when_swap_confounds(self) -> None:
        tracker = FusionAttemptTracker()
        tracker.observe_snapshot(
            snapshot(
                "t0", turn=3, mana=200, fusion_state=fusion(turn=-1, used=False, locked=False), ui=True
            )
        )
        tracker.observe_snapshot(
            snapshot(
                "t1", turn=3, mana=200, fusion_state=fusion(turn=3, used=False, locked=True), ui=False
            )
        )
        record = tracker.observe_response(
            FusionResponse("t2", "server", False),
            snapshot(
                "t2", turn=3, mana=200, fusion_state=fusion(turn=3, used=False, locked=True), ui=False
            ),
        )
        tracker.observe_activity("session", "swap")
        tracker.observe_authoritative_idle("session", 2, 3)
        self.assertEqual(record.idle_reset, FusionIdleReset.UNKNOWN)

    def test_response_snapshot_is_not_overwritten_by_later_gameplay(self) -> None:
        tracker = FusionAttemptTracker()
        tracker.observe_snapshot(
            snapshot(
                "t0",
                turn=9,
                mana=321,
                fusion_state=fusion(turn=-1, used=False, locked=False),
                ui=True,
            )
        )
        tracker.observe_snapshot(
            snapshot(
                "t1",
                turn=9,
                mana=321,
                fusion_state=fusion(turn=9, used=False, locked=True),
                ui=False,
            )
        )
        record = tracker.observe_response(
            FusionResponse("t2", "server", True),
            snapshot(
                "t2",
                turn=9,
                mana=161,
                fusion_state=fusion(turn=9, used=True, locked=True),
                ui=False,
            ),
        )
        tracker.observe_snapshot(
            snapshot(
                "t3",
                turn=11,
                mana=240,
                fusion_state=fusion(turn=9, used=True, locked=False),
                ui=False,
            )
        )
        self.assertEqual(record.mana_delta, -160)
        self.assertEqual(record.after_response.timestamp, "t2")

    def test_equal_authoritative_idle_count_does_not_prove_reset(self) -> None:
        tracker = FusionAttemptTracker()
        tracker.observe_snapshot(
            snapshot(
                "t0",
                turn=3,
                mana=200,
                fusion_state=fusion(turn=-1, used=False, locked=False),
                ui=True,
                idle=1,
            )
        )
        tracker.observe_snapshot(
            snapshot(
                "t1",
                turn=3,
                mana=200,
                fusion_state=fusion(turn=3, used=False, locked=True),
                ui=False,
                idle=1,
            )
        )
        record = tracker.observe_response(
            FusionResponse("t2", "server", False),
            snapshot(
                "t2",
                turn=3,
                mana=200,
                fusion_state=fusion(turn=3, used=False, locked=True),
                ui=False,
                idle=1,
            ),
        )
        tracker.observe_authoritative_idle("session", 1, 3)
        self.assertEqual(record.idle_reset, FusionIdleReset.UNKNOWN)


if __name__ == "__main__":
    unittest.main()
