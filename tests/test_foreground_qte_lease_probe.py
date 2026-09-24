from __future__ import annotations

from pathlib import Path
from types import SimpleNamespace
import sys
import unittest
from unittest.mock import MagicMock


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.gameplay_profile import AuditionMode  # noqa: E402
from tools.foreground_qte_lease_probe import (  # noqa: E402
    Phase4FullQteLeaseHook,
    Phase4QteObservationHook,
    _full_action_accepted,
    _validate_args,
)


class Phase4QteObservationHookTests(unittest.TestCase):
    def test_b1_stops_on_one_fresh_qte_without_input_api(self) -> None:
        emitted: list[tuple[str, dict]] = []
        hook = Phase4QteObservationHook(
            stop_requested=lambda: False,
            audition_mode=AuditionMode.V3_TWO_DIRECTION,
        )
        hook.attach(
            SimpleNamespace(pid=123),
            lambda event, **fields: emitted.append((event, fields)),
        )
        qte = SimpleNamespace(active=True, completed=False, current_index=0)

        hook.snapshot(qte, lifecycle_valid=True)

        self.assertTrue(hook.done)
        self.assertIs(hook.observation, qte)
        self.assertEqual(emitted[-1][0], "phase4_qte_b1_fresh_qte_observed")
        self.assertTrue(emitted[-1][1]["zeroInput"])

    def test_b1_ignores_noncurrent_or_completed_qte(self) -> None:
        hook = Phase4QteObservationHook(
            stop_requested=lambda: False,
            audition_mode=AuditionMode.V3_TWO_DIRECTION,
        )
        hook.snapshot(
            SimpleNamespace(active=True, completed=False),
            lifecycle_valid=False,
        )
        hook.snapshot(
            SimpleNamespace(active=False, completed=True),
            lifecycle_valid=True,
        )
        self.assertFalse(hook.done)

    def test_b1_stop_is_idempotent_before_outer_cleanup(self) -> None:
        emitted: list[str] = []
        hook = Phase4QteObservationHook(
            stop_requested=lambda: False,
            audition_mode=AuditionMode.V3_TWO_DIRECTION,
        )
        hook.attach(
            SimpleNamespace(pid=123),
            lambda event, **_fields: emitted.append(event),
        )

        hook.stop("OBSERVER_STOP")
        hook.stop("OUTER_FINALLY")

        self.assertEqual(emitted.count("phase4_qte_b1_stopped"), 1)


class FullActionAcceptanceTests(unittest.TestCase):
    @staticmethod
    def _hook(
        *,
        foreground_before: int | None = 123,
        focus_restored: bool = True,
        completed_successfully: bool = True,
    ) -> SimpleNamespace:
        return SimpleNamespace(
            completed_successfully=completed_successfully,
            lease_acquire_result=SimpleNamespace(
                acquired=True,
                foreground_before=foreground_before,
            ),
            mouse_release_result=SimpleNamespace(
                released=True,
                cursor_restored=True,
            ),
            lease_release_result=SimpleNamespace(
                released=True,
                focus_restored=focus_restored,
                cursor_restored=True,
            ),
        )

    def test_b2_accepts_existing_full_action_without_focus_handoff_requirement(self) -> None:
        self.assertTrue(
            _full_action_accepted(
                self._hook(foreground_before=456),
                game_hwnd=456,
                require_focus_handoff=False,
            )
        )

    def test_b3_requires_takeover_from_other_foreground_and_restoration(self) -> None:
        self.assertTrue(
            _full_action_accepted(
                self._hook(foreground_before=123),
                game_hwnd=456,
                require_focus_handoff=True,
            )
        )
        self.assertFalse(
            _full_action_accepted(
                self._hook(foreground_before=456),
                game_hwnd=456,
                require_focus_handoff=True,
            )
        )
        self.assertTrue(
            _full_action_accepted(
                self._hook(foreground_before=123, focus_restored=False),
                game_hwnd=456,
                require_focus_handoff=True,
            )
        )

    def test_failed_existing_action_is_rejected(self) -> None:
        self.assertFalse(
            _full_action_accepted(
                self._hook(completed_successfully=False),
                game_hwnd=456,
                require_focus_handoff=False,
            )
        )

    def test_mouse_must_be_released_before_qte_keys_are_accepted(self) -> None:
        hook = self._hook()
        hook.mouse_release_result = SimpleNamespace(released=False)
        self.assertFalse(
            _full_action_accepted(
                hook,
                game_hwnd=456,
                require_focus_handoff=False,
            )
        )

    def test_b3_still_requires_cursor_restoration(self) -> None:
        hook = self._hook(foreground_before=123, focus_restored=False)
        hook.lease_release_result.cursor_restored = False
        self.assertFalse(
            _full_action_accepted(
                hook,
                game_hwnd=456,
                require_focus_handoff=True,
            )
        )


class FocusHandoffGateTests(unittest.TestCase):
    @staticmethod
    def _hook(*, foreground: int, game_hwnd: int = 456) -> tuple[Phase4FullQteLeaseHook, SimpleNamespace]:
        lease = SimpleNamespace(
            active=False,
            backend=SimpleNamespace(foreground_window=lambda: foreground),
            acquire=MagicMock(),
        )
        hook = Phase4FullQteLeaseHook(
            backend=SimpleNamespace(),
            binding=SimpleNamespace(hwnd=game_hwnd),
            lease=lease,
            stop_requested=lambda: False,
            audition_mode=AuditionMode.V3_TWO_DIRECTION,
            direction_ack_timeout_seconds=1.25,
            qte_generation_timeout_seconds=3.0,
            result_timeout_seconds=15.0,
            require_external_foreground_before_acquire=True,
        )
        return hook, lease

    @staticmethod
    def _card(*, interactable: bool) -> SimpleNamespace:
        return SimpleNamespace(
            interactable=interactable,
            button_address=789,
            has_used_this_match=False,
            has_used_this_turn=False,
            action_pending=False,
            is_placeholder=False,
        )

    def test_b3_waits_without_consuming_lease_until_another_window_has_focus(self) -> None:
        game_hwnd = 456
        hook, lease = self._hook(foreground=game_hwnd, game_hwnd=game_hwnd)

        self.assertIsNone(
            hook._geometry_proof(object(), self._card(interactable=True))
        )
        lease.acquire.assert_not_called()

    def test_b3_does_not_consume_lease_while_exact_card_is_not_actionable(self) -> None:
        hook, lease = self._hook(foreground=123)

        self.assertIsNone(
            hook._geometry_proof(object(), self._card(interactable=False))
        )
        lease.acquire.assert_not_called()


class ArgumentValidationTests(unittest.TestCase):
    def test_live_stage_requires_explicit_prearm(self) -> None:
        args = SimpleNamespace(
            prearmed=False,
            interval=0.025,
            timeout=900.0,
            maximum_lease_duration=20.0,
        )
        with self.assertRaisesRegex(ValueError, "--prearmed"):
            _validate_args(args)


if __name__ == "__main__":
    unittest.main()
