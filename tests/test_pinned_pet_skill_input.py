from __future__ import annotations

from pathlib import Path
from types import SimpleNamespace
import sys
import unittest
from unittest.mock import patch


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.gameplay_profile import AuditionMode  # noqa: E402
from pokiguard_v2.pet_skill_action import (  # noqa: E402
    PetSkillActionResultKind,
    PetSkillActionState,
)
from pokiguard_v2.state import CombatSessionKey  # noqa: E402
from tools.pet_skill_action import (  # noqa: E402
    Phase3b3RuntimeHook,
    PinnedForegroundPetSkillHook,
)


class FakeLease:
    def __init__(self, *, acquire_ok: bool = True, retain_ok: bool = True) -> None:
        self.active = False
        self.acquire_ok = acquire_ok
        self.retain_ok = retain_ok
        self.valid = True
        self.acquire_calls = 0
        self.mouse_release_calls = 0
        self.guard_retention_calls = 0
        self.release_reasons: list[str] = []

    def acquire(self, *, preflight):
        self.acquire_calls += 1
        accepted = bool(preflight()) and self.acquire_ok
        self.active = accepted
        return SimpleNamespace(
            acquired=accepted,
            status=SimpleNamespace(value="ACTIVE" if accepted else "STALE_ACTION"),
        )

    def validate_active(self) -> bool:
        return self.active and self.valid

    def release_mouse_for_keyboard_phase(self, _reason: str):
        self.mouse_release_calls += 1
        return SimpleNamespace(released=True)

    def retain_mouse_for_keyboard_phase(self, _reason: str):
        self.guard_retention_calls += 1
        return SimpleNamespace(ready=self.retain_ok)

    def release(self, reason: str):
        self.release_reasons.append(reason)
        self.active = False
        return SimpleNamespace(released=True)


def card(*, interactable: bool = True) -> SimpleNamespace:
    return SimpleNamespace(
        interactable=interactable,
        button_address=0x1234,
        has_used_this_match=False,
        has_used_this_turn=False,
        action_pending=False,
        is_placeholder=False,
    )


def hook(
    lease: FakeLease,
    *,
    stopped=lambda: False,
    acquired=lambda: True,
    expected_session=None,
) -> PinnedForegroundPetSkillHook:
    return PinnedForegroundPetSkillHook(
        backend=SimpleNamespace(),
        binding=SimpleNamespace(hwnd=5),
        lease=lease,  # type: ignore[arg-type]
        stop_requested=stopped,
        audition_mode=AuditionMode.V3_TWO_DIRECTION,
        direction_ack_timeout_seconds=1.25,
        qte_generation_timeout_seconds=3.0,
        result_timeout_seconds=15.0,
        post_state_timeout_seconds=15.0,
        on_lease_acquired=acquired,
        expected_session=expected_session,
    )


class PinnedForegroundPetSkillHookTests(unittest.TestCase):
    def test_initial_runtime_match_accepts_only_exact_farm_session(self) -> None:
        lease = FakeLease()
        session = CombatSessionKey(7, 0x12340000, "M_CURRENT")
        action = hook(lease, expected_session=session)

        self.assertTrue(action.is_expected_initial_match_id("M_CURRENT"))
        self.assertFalse(action.is_expected_initial_match_id("M_OTHER"))
        self.assertFalse(action.is_expected_initial_match_id(None))

    def test_non_actionable_card_does_not_acquire_or_reserve(self) -> None:
        lease = FakeLease()
        reserve_calls = 0

        def reserve() -> bool:
            nonlocal reserve_calls
            reserve_calls += 1
            return True

        action = hook(lease, acquired=reserve)

        self.assertIsNone(action._geometry_proof(object(), card(interactable=False)))
        self.assertEqual(lease.acquire_calls, 0)
        self.assertEqual(reserve_calls, 0)

    def test_exact_card_acquires_transport_then_farm_capability_once(self) -> None:
        lease = FakeLease()
        reserve_calls = 0

        def reserve() -> bool:
            nonlocal reserve_calls
            reserve_calls += 1
            return True

        action = hook(lease, acquired=reserve)

        # The pre-acquire sample is deliberately never reused for the click.
        self.assertIsNone(action._geometry_proof(object(), card()))
        self.assertTrue(lease.active)
        self.assertEqual(lease.acquire_calls, 1)
        self.assertEqual(reserve_calls, 1)
        self.assertTrue(action._lease_callback_completed)

    def test_farm_capability_denial_releases_guard_before_any_input(self) -> None:
        lease = FakeLease()
        action = hook(lease, acquired=lambda: False)

        self.assertIsNone(action._geometry_proof(object(), card()))

        self.assertFalse(lease.active)
        self.assertEqual(
            lease.release_reasons,
            ["PINNED_QTE_FARM_CAPABILITY_DENIED"],
        )

    def test_failed_transport_acquire_is_terminal_and_never_rearmed(self) -> None:
        lease = FakeLease(acquire_ok=False)
        action = hook(lease)

        self.assertIsNone(action._geometry_proof(object(), card()))

        self.assertTrue(action.done)
        self.assertEqual(lease.acquire_calls, 1)
        self.assertEqual(
            action._fatal_stop_reason,
            "PINNED_QTE_LEASE_STALE_ACTION",
        )

    def test_fresh_qte_bind_retains_mouse_through_direction_stage(self) -> None:
        lease = FakeLease()
        lease.active = True
        action = hook(lease)
        action._executor = SimpleNamespace(
            state=PetSkillActionState.DIRECTIONS,
            result=None,
            active=False,
        )

        with patch.object(Phase3b3RuntimeHook, "_drive", return_value=None):
            action._drive(None, inactive_qte_proven=False)

        self.assertEqual(lease.mouse_release_calls, 0)
        self.assertEqual(lease.guard_retention_calls, 1)
        self.assertTrue(action.guard_retention_result.ready)
        self.assertIsNone(action.mouse_release_result)

    def test_focus_or_binding_loss_aborts_and_releases(self) -> None:
        lease = FakeLease()
        lease.active = True
        lease.valid = False
        action = hook(lease)

        action._drive(None, inactive_qte_proven=False)

        self.assertFalse(lease.active)
        self.assertEqual(lease.release_reasons, ["PINNED_QTE_LEASE_INVALIDATED"])

    def test_full_qte_guard_failure_aborts_and_releases(self) -> None:
        lease = FakeLease(retain_ok=False)
        lease.active = True
        action = hook(lease)
        action._executor = SimpleNamespace(
            state=PetSkillActionState.DIRECTIONS,
            result=None,
            active=False,
        )

        with patch.object(Phase3b3RuntimeHook, "_drive", return_value=None):
            action._drive(None, inactive_qte_proven=False)

        self.assertFalse(lease.active)
        self.assertEqual(lease.guard_retention_calls, 1)
        self.assertEqual(lease.release_reasons, ["PINNED_QTE_FULL_GUARD_FAILED"])

    def test_torn_native_hand_rearms_inside_same_zero_input_lease(self) -> None:
        lease = FakeLease()
        lease.active = True
        action = hook(lease)
        completed = SimpleNamespace(
            result=SimpleNamespace(
                kind=PetSkillActionResultKind.PREFLIGHT_REJECTED,
                reason="FINAL_CARD_CURRENT_PET_SKILL_CAPABILITY_MISSING",
                card_clicks=0,
                space_presses=0,
            ),
            action_id="old-action",
        )
        replacement = SimpleNamespace()
        action._executor_factory = lambda: replacement
        action._invocation_consumed = True
        action._latest_context = {
            "card_diagnostics": {
                "nativeCardDiscoveryReason": (
                    "pet_skill_control_read_error:native_card_ui: "
                    "geometry changed during walk"
                )
            }
        }

        rearmed = action._rearm_after_zero_input_preflight_race(completed)

        self.assertTrue(rearmed)
        self.assertIs(action._executor, replacement)
        self.assertFalse(action._invocation_consumed)
        self.assertTrue(lease.active)
        self.assertEqual(lease.release_reasons, [])

    def test_emergency_stop_releases_active_keyboard_or_mouse_guard(self) -> None:
        lease = FakeLease()
        lease.active = True
        action = hook(lease, stopped=lambda: True)

        self.assertTrue(action.done)
        self.assertFalse(lease.active)
        self.assertEqual(lease.release_reasons, ["EMERGENCY_STOP"])


if __name__ == "__main__":
    unittest.main()
