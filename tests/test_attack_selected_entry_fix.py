from dataclasses import replace
from pathlib import Path
from types import SimpleNamespace as NS
from contextlib import ExitStack
import tempfile
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.boss_entry import BossLobbyState
from pokiguard_v2.desktop_farm_controller import DesktopFarmControllerManager, DesktopControllerSnapshot, DesktopControllerState
from pokiguard_v2.desktop_ui import DesktopViewModel, DesktopEventLog
from pokiguard_v2.farm_run import FarmRunState, FarmRunStopReason
from pokiguard_v2.win32_screenshot import ClientRgbCapture, configure_diagnostic_image_writes, diagnostic_image_writes_enabled
from tools.boss_entry import _ensure_required_attack_card
from test_desktop_farm_controller import _source
from test_desktop_ui_hardening import _snapshot


def loadout(selected=True, data_id=64647):
    attack = NS(data_id=data_id, card_id=4, element_type="ATTACK", count=1)
    cards = (NS(data_id=1, card_id=1, element_type="MANA", count=1), attack)
    return NS(manager_cards=(attack,) if selected else (), room_cards=cards,
              identity=((data_id, 4, "ATTACK"),) if selected else ())


def room(cards, room_id="Coop_test"):
    return NS(state=BossLobbyState.BOSS_LOBBY, branch="CHINH_PHUC_ROOM",
              chinh_phuc=NS(card_loadout=cards, current_room_id=room_id, enemy_pet_id=2215))


class AttackSelectedEntryFixTests(unittest.TestCase):
    def exercise(self, directory, *, selected=True, fresh=None, disk_failure=False):
        initial = room(loadout(selected))
        current = fresh or initial
        clock = [0.0]
        capture = ClientRgbCapture("fake game", 0, 0, 8, 4, bytes((20, 40, 60)) * 32)
        missing = NS(found=False, normalized_point=None)
        provider = NS(poll=Mock(return_value=NS(combat_lifecycle=object())), current_session_key=None)
        executor = Mock()
        executor.window_status.return_value = NS(valid=True, foreground=True, geometry=NS(width=8, height=4))
        runtime = NS(target=NS(pid=123, resolver=object(), is_running=lambda: True),
                     provider=provider, executor=executor, binding=object(),
                     pinned_input_session=None, lobby_card_capability=Mock())
        records = []
        result = {}

        def sleep(seconds):
            clock[0] += seconds

        with ExitStack() as stack:
            stack.enter_context(patch("tools.boss_entry.time.monotonic", side_effect=lambda: clock[0]))
            stack.enter_context(patch("tools.boss_entry.time.sleep", side_effect=sleep))
            captures = stack.enter_context(patch("tools.boss_entry.capture_client_rgb", return_value=capture))
            stack.enter_context(patch("tools.boss_entry.locate_chinh_phuc_attack_card_toggle", return_value=missing))
            reads = stack.enter_context(patch("tools.boss_entry.read_boss_lobby_runtime", return_value=current))
            stack.enter_context(patch("tools.boss_entry._write", side_effect=lambda log, event, **kw: records.append((event, kw))))
            if disk_failure:
                stack.enter_context(patch("tools.boss_entry.write_failure_png_rgb", side_effect=OSError("disk full")))
            value = _ensure_required_attack_card(runtime=runtime, lobby=initial, result=result,
                        log=object(), artifact_dir=directory, interval=.2)
        executor.click.assert_not_called()
        runtime.lobby_card_capability.reserve.assert_not_called()
        return value, result, records, clock[0], provider.poll.call_count, reads.call_count, captures.call_count

    def setUp(self):
        self.old_policy = diagnostic_image_writes_enabled()
        configure_diagnostic_image_writes(enabled=False)

    def tearDown(self):
        configure_diagnostic_image_writes(enabled=self.old_policy)

    def test_selected_attack_with_unrecognized_art_settles_and_rechecks_without_click(self):
        with tempfile.TemporaryDirectory() as temp:
            value, result, records, elapsed, polls, reads, _ = self.exercise(Path(temp))
            self.assertIsNotNone(value)
            self.assertEqual({}, result)
            self.assertGreaterEqual(elapsed, 3)
            self.assertLess(elapsed, 3.3)
            self.assertEqual((1, 1), (polls, reads))
            settled = dict(records)["preentry_attack_selection_settled"]
            self.assertEqual(0, settled["stableVisualFrames"])
            self.assertFalse(settled["visualToggleRequired"])
            self.assertEqual([], list(Path(temp).iterdir()))

    def test_selected_attack_still_rejects_changed_room_or_card_before_start(self):
        for fresh in (room(loadout(), "different_room"), room(loadout(data_id=999)), room(loadout(False))):
            with self.subTest(fresh=fresh), tempfile.TemporaryDirectory() as temp:
                value, result, _, _, polls, _, _ = self.exercise(Path(temp), fresh=fresh)
                self.assertIsNone(value)
                self.assertEqual("ATTACK_CARD_RUNTIME_CHANGED", result["stopReason"])
                self.assertEqual(1, polls)

    def test_unselected_attack_keeps_strict_visual_gate_and_saves_only_existing_failure_pair(self):
        with tempfile.TemporaryDirectory() as temp:
            value, result, _, elapsed, polls, reads, captures = self.exercise(Path(temp), selected=False)
            self.assertIsNone(value)
            self.assertEqual("ATTACK_CARD_TOGGLE_UNPROVEN", result["stopReason"])
            self.assertGreaterEqual(elapsed, 15)
            self.assertEqual((0, 0), (polls, reads))
            self.assertLessEqual(captures, 77)
            self.assertEqual(2, len(list(Path(temp).glob("attack_card_failure_*.png"))))

    def test_failure_image_disk_error_does_not_replace_original_stop(self):
        with tempfile.TemporaryDirectory() as temp:
            value, result, records, *_ = self.exercise(Path(temp), selected=False, disk_failure=True)
            self.assertIsNone(value)
            self.assertEqual("ATTACK_CARD_TOGGLE_UNPROVEN", result["stopReason"])
            self.assertEqual(2, sum(e == "attack_card_failure_image_write_failed" for e, _ in records))

    def test_png_storage_policy_does_not_change_selected_card_result_or_reads(self):
        outcomes = []
        for enabled in (False, True):
            configure_diagnostic_image_writes(enabled=enabled)
            with tempfile.TemporaryDirectory() as temp:
                value, result, _, elapsed, polls, reads, captures = self.exercise(Path(temp))
                outcomes.append((value.identity, result, elapsed, polls, reads, captures))
        self.assertEqual(outcomes[0], outcomes[1])

    def test_stop_detail_projects_to_visible_guidance_and_operator_log(self):
        with tempfile.TemporaryDirectory() as temp:
            manager = DesktopFarmControllerManager(Path(temp), reset_evidence=Path(temp)/"reset.json", artifacts_root=Path(temp))
            source = _source(state=FarmRunState.SAFE_STOP, stop_reason=FarmRunStopReason.OPENING_INVARIANT_FAILED)
            source.events = (NS(detail={"entry": {"stopReason": "ATTACK_CARD_TOGGLE_UNPROVEN"}}),)
            manager._observe(manager.snapshot().generation, source, "FINISHED")
            projected = manager.snapshot()
            self.assertEqual("ATTACK_CARD_TOGGLE_UNPROVEN", projected.last_stop_detail)
            controller = replace(projected, state=DesktopControllerState.STOPPED, active=False)
            snap = _snapshot(controller=controller, lifecycle="BOSS_LOBBY")
            vm = DesktopViewModel(NS(snapshot=lambda: snap), Mock(), stale_after_seconds=10)
            presentation = vm.presentation(now_monotonic=snap.sampled_monotonic)
            self.assertEqual("ĐÃ DỪNG", presentation.operator_status)
            self.assertIn("thẻ Tấn công", presentation.operator_guidance)
            log = DesktopEventLog(Path(temp)/"ui.jsonl")
            try:
                log.poll_event("snapshot_refreshed", snap)
                self.assertIn("thẻ Tấn công", log.entries()[-1].message)
            finally:
                log.close()


if __name__ == "__main__":
    unittest.main()
