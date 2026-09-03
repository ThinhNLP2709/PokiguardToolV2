from __future__ import annotations

from pathlib import Path
import sys
import unittest


SRC = Path(__file__).resolve().parents[1] / "src"
if str(SRC) not in sys.path:
    sys.path.insert(0, str(SRC))

from pokiguard_v2.combat_lifecycle import (
    CombatLifecycleSignals,
    CombatLifecycleState,
    CombatSessionTracker,
    MatchHostState,
    classify_combat_lifecycle,
)
from pokiguard_v2.state import BattleState


def active_signals(**changes: object) -> CombatLifecycleSignals:
    values = dict(
        match_host_state=MatchHostState.RUNNING,
        current_rig=0x200000,
        current_rig_native=0x300000,
        current_rig_alive=True,
        scene_loading=False,
        scene_unloading=False,
        hub_suspended=True,
        board_instance=0x400000,
        active_instance=0x500000,
        manager_match_instance=0x600000,
        manager_active=0x500000,
        manager_is_boss_battle=True,
        objects_consistent=True,
        match_id="M_one",
        board_ready=True,
        board_game_over=False,
        match_over=False,
        deferred_game_over=False,
    )
    values.update(changes)
    return CombatLifecycleSignals(**values)


class CombatLifecycleTests(unittest.TestCase):
    def test_active_requires_all_local_rig_and_ownership_signals(self) -> None:
        self.assertEqual(
            classify_combat_lifecycle(active_signals()).state,
            CombatLifecycleState.ACTIVE,
        )
        for field, value in (
            ("current_rig_alive", False),
            ("hub_suspended", None),
            ("objects_consistent", False),
            ("board_ready", False),
        ):
            with self.subTest(field=field):
                self.assertNotEqual(
                    classify_combat_lifecycle(active_signals(**{field: value})).state,
                    CombatLifecycleState.ACTIVE,
                )

    def test_current_boss_combat_accepts_readable_false_legacy_flags(self) -> None:
        """1.7.4 leaves both legacy booleans false despite a proven live rig."""

        observation = classify_combat_lifecycle(
            active_signals(
                hub_suspended=False,
                manager_is_boss_battle=False,
                match_id="M_b727b2f1",
            )
        )
        self.assertEqual(observation.state, CombatLifecycleState.ACTIVE)
        self.assertEqual(observation.reason, "local_rig_and_combat_ownership_agree")

    def test_entering_leaving_and_postmatch_win_over_active(self) -> None:
        self.assertEqual(
            classify_combat_lifecycle(
                active_signals(match_host_state=MatchHostState.BUILDING)
            ).state,
            CombatLifecycleState.ENTERING,
        )
        self.assertEqual(
            classify_combat_lifecycle(active_signals(scene_unloading=True)).state,
            CombatLifecycleState.LEAVING,
        )
        self.assertEqual(
            classify_combat_lifecycle(active_signals(match_over=True)).state,
            CombatLifecycleState.POSTMATCH,
        )

    def test_server_match_without_any_local_rig_is_stale(self) -> None:
        signals = CombatLifecycleSignals(
            match_host_state=MatchHostState.IDLE,
            current_rig_alive=False,
            scene_loading=False,
            scene_unloading=False,
            hub_suspended=False,
            match_id="M_stale",
        )
        self.assertEqual(
            classify_combat_lifecycle(signals).state,
            CombatLifecycleState.STALE_SERVER_MATCH,
        )

    def test_same_local_absence_without_match_is_lobby(self) -> None:
        signals = CombatLifecycleSignals(
            match_host_state=MatchHostState.IDLE,
            current_rig_alive=False,
            scene_loading=False,
            scene_unloading=False,
            hub_suspended=False,
        )
        self.assertEqual(
            classify_combat_lifecycle(signals).state,
            CombatLifecycleState.LOBBY,
        )

    def test_session_invalidates_immediately_and_new_combat_gets_new_epoch(self) -> None:
        tracker = CombatSessionTracker()
        first = tracker.observe(CombatLifecycleState.ACTIVE, 0x400000, "M_one")
        self.assertIsNotNone(first)
        self.assertIsNone(
            tracker.observe(CombatLifecycleState.LEAVING, 0x400000, "M_one")
        )
        self.assertIsNone(tracker.session)
        second = tracker.observe(CombatLifecycleState.ACTIVE, 0x400000, "M_two")
        self.assertGreater(second.lifecycle_epoch, first.lifecycle_epoch)
        self.assertNotEqual(second, first)

    def test_first_turn_signal_is_suppressed_outside_active_lifecycle(self) -> None:
        active = BattleState(
            combat_lifecycle=CombatLifecycleState.ACTIVE,
            turn_number=1,
            is_local_turn=True,
        )
        stale = BattleState(
            combat_lifecycle=CombatLifecycleState.STALE_SERVER_MATCH,
            turn_number=1,
            is_local_turn=True,
        )
        self.assertTrue(active.is_first_local_turn)
        self.assertIsNone(stale.is_first_local_turn)


if __name__ == "__main__":
    unittest.main()
