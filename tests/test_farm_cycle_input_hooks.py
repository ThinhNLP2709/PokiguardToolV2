"""Tests for the production B5 capability hook and controller lease."""

from __future__ import annotations

from pathlib import Path
import tempfile
import unittest

from pokiguard_v2.basic_policy import PolicyAction
from pokiguard_v2.autonomous_control import AutonomousStatus
from pokiguard_v2.boss_entry import BossLobbyState, FarmTarget
from pokiguard_v2.controller_lease import AutomationControllerLease, ControllerLeaseError
from pokiguard_v2.farm_cycle import FarmCycle, OpeningEvidence
from pokiguard_v2.farm_cycle_runtime import FarmEntryCapability, FarmGameplayCapability
from pokiguard_v2.state import CombatSessionKey
from tools.basic_auto_bot import (
    SharedCombatRuntime,
    _complete_farm_gameplay,
    _farm_owned_guard_requires_stop,
    _prime_transport_for_runtime,
    _reserve_farm_gameplay,
)


class FarmInputHookTests(unittest.TestCase):
    def active_cycle(self) -> tuple[FarmCycle, CombatSessionKey]:
        cycle = FarmCycle(FarmTarget(boss_id="1289"))
        key = CombatSessionKey(1, 0x1000, "match-1")
        self.assertTrue(cycle.observe_initial_lobby(BossLobbyState.BOSS_LOBBY))
        self.assertTrue(cycle.target_resolved(entry_number=1))
        entry = FarmEntryCapability(cycle, 1)
        permit = entry.reserve(foreground=True)
        assert permit is not None
        self.assertTrue(entry.complete(permit, sent=True))
        self.assertTrue(cycle.accept_session(key))
        self.assertTrue(
            cycle.accept_opening(
                OpeningEvidence(
                    key,
                    key.match_id,
                    "a" * 64,
                    64,
                    64,
                    "ChatMessageDTO.MATCH_START.matchPayload.board",
                    True,
                    0,
                    2,
                )
            )
        )
        self.assertTrue(cycle.begin_combat1_play(key))
        return cycle, key

    def test_shared_b5_runtime_asks_ledger_at_actual_action_boundary(self) -> None:
        cycle, key = self.active_cycle()
        runtime = SharedCombatRuntime(
            None,
            None,  # type: ignore[arg-type]
            None,  # type: ignore[arg-type]
            None,
            None,  # type: ignore[arg-type]
            None,  # type: ignore[arg-type]
            key,
            FarmGameplayCapability(cycle, key),
        )
        allowed, permit = _reserve_farm_gameplay(
            runtime,
            action=PolicyAction.SWAP,
            session=key,
            foreground=True,
        )
        self.assertTrue(allowed)
        self.assertIsNotNone(permit)
        self.assertTrue(
            _complete_farm_gameplay(runtime, permit, sent=True, detail="executor sent 2 clicks")
        )
        self.assertEqual(cycle.snapshot().input_records[-1].session, key)

    def test_shared_b5_runtime_denies_lost_foreground_before_executor(self) -> None:
        cycle, key = self.active_cycle()
        runtime = SharedCombatRuntime(
            None,
            None,  # type: ignore[arg-type]
            None,  # type: ignore[arg-type]
            None,
            None,  # type: ignore[arg-type]
            None,  # type: ignore[arg-type]
            key,
            FarmGameplayCapability(cycle, key),
        )
        allowed, permit = _reserve_farm_gameplay(
            runtime,
            action=PolicyAction.CAST,
            session=key,
            foreground=False,
        )
        self.assertFalse(allowed)
        self.assertIsNone(permit)
        self.assertFalse(any(record.domain.gameplay for record in cycle.snapshot().input_records))

    def test_farm_handoff_reuses_entry_regions_without_rescan(self) -> None:
        class Monitor:
            calls = 0

            def prime_regions(self) -> dict[str, bool]:
                self.calls += 1
                return {"primed": True}

        monitor = Monitor()
        runtime = SharedCombatRuntime(
            None,
            None,  # type: ignore[arg-type]
            monitor,  # type: ignore[arg-type]
            None,
            None,  # type: ignore[arg-type]
            None,  # type: ignore[arg-type]
            "session-1",
        )
        reused = _prime_transport_for_runtime(runtime, farm_owned=True)
        self.assertEqual(monitor.calls, 0)
        self.assertEqual(reused["additionalScanBytes"], 0)
        self.assertEqual(_prime_transport_for_runtime(runtime, farm_owned=False), {"primed": True})
        self.assertEqual(monitor.calls, 1)

    def test_farm_owned_b5_stops_instead_of_waiting_for_interactive_takeover(self) -> None:
        for status in (
            AutonomousStatus.PAUSED_BY_USER,
            AutonomousStatus.AUTO_PAUSED,
            AutonomousStatus.RECOVERY_REQUIRED,
        ):
            with self.subTest(status=status):
                self.assertTrue(
                    _farm_owned_guard_requires_stop(farm_owned=True, status=status)
                )
                self.assertFalse(
                    _farm_owned_guard_requires_stop(farm_owned=False, status=status)
                )

        for status in (
            AutonomousStatus.WAITING_FOR_COMBAT,
            AutonomousStatus.RUNNING,
            AutonomousStatus.INPUT_LOCKED,
            AutonomousStatus.STOPPED,
        ):
            with self.subTest(status=status):
                self.assertFalse(
                    _farm_owned_guard_requires_stop(farm_owned=True, status=status)
                )


class ControllerLeaseTests(unittest.TestCase):
    def test_second_cooperating_controller_is_rejected(self) -> None:
        with tempfile.TemporaryDirectory() as directory:
            path = Path(directory) / "controller.lock"
            with AutomationControllerLease(path):
                with self.assertRaises(ControllerLeaseError):
                    with AutomationControllerLease(path):
                        self.fail("second lease must not be acquired")
            with AutomationControllerLease(path):
                pass


if __name__ == "__main__":
    unittest.main()
