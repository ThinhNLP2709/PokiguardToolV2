from __future__ import annotations

from dataclasses import replace
import unittest
from unittest.mock import Mock

from pokiguard_v2.gameplay_profile import AuditionMode
from pokiguard_v2.pet_skill_action import (
    PetSkillActionExecutor,
    PetSkillActionResultKind,
    PetSkillActionState,
    QteSpaceInputExecutor,
)
from pokiguard_v2.pet_skill_shadow import PetSkillFamily, PetSkillTargetMode
from tests.test_pet_skill_action import (
    FakeInputBackend,
    FakeMouse,
    observation,
    post_state,
)
from tools.pet_qte_observer import _no_action_click_only_inactive_edge
from tools.pet_skill_action import Phase3b3RuntimeHook


def click_only_executor(*, post_timeout: float = 2.0):
    backend = FakeInputBackend()
    mouse = FakeMouse()
    directions = Mock()
    action = PetSkillActionExecutor(
        mouse,
        directions,
        QteSpaceInputExecutor(backend),
        post_state_timeout_seconds=post_timeout,
        timestamp=lambda: 100.0,
        action_id_factory=lambda: "MEGA-ACTION-1",
        audition_mode=AuditionMode.NO_ACTION,
    )
    return action, mouse, backend, directions


class MegaIcarusClickOnlyTests(unittest.TestCase):
    def test_current_actionable_click_only_capability_is_an_inactive_qte_edge(self) -> None:
        capability = replace(
            observation(0.0).capability,
            skill_family=PetSkillFamily.MEGA_ICARUS_CLICK_ONLY,
            target_mode=PetSkillTargetMode.AUTOMATIC,
        )
        self.assertTrue(
            _no_action_click_only_inactive_edge(
                AuditionMode.NO_ACTION,
                capability,
            )
        )
        self.assertFalse(
            _no_action_click_only_inactive_edge(
                AuditionMode.V3_TWO_DIRECTION,
                capability,
            )
        )

    def test_click_only_edge_requires_current_actionable_automatic_card(self) -> None:
        capability = replace(
            observation(0.0).capability,
            skill_family=PetSkillFamily.MEGA_ICARUS_CLICK_ONLY,
            target_mode=PetSkillTargetMode.AUTOMATIC,
        )
        self.assertFalse(
            _no_action_click_only_inactive_edge(
                AuditionMode.NO_ACTION,
                replace(capability, live_card_actionable=False),
            )
        )
        self.assertFalse(
            _no_action_click_only_inactive_edge(
                AuditionMode.NO_ACTION,
                replace(capability, ownership_current=False),
            )
        )

    def test_click_only_post_click_edge_accepts_expected_non_actionable_card(self) -> None:
        capability = replace(
            observation(0.0).capability,
            skill_family=PetSkillFamily.MEGA_ICARUS_CLICK_ONLY,
            target_mode=PetSkillTargetMode.AUTOMATIC,
            live_card_actionable=False,
        )
        self.assertTrue(
            _no_action_click_only_inactive_edge(
                AuditionMode.NO_ACTION,
                capability,
                post_click_pending=True,
            )
        )
        self.assertFalse(
            _no_action_click_only_inactive_edge(
                AuditionMode.V3_TWO_DIRECTION,
                capability,
                post_click_pending=True,
            )
        )

    def test_click_only_post_click_survives_transient_control_gap(self) -> None:
        action, _, _, _ = click_only_executor()
        action.begin(observation(0.0), monotonic_now=0.0)
        action.step(observation(0.05), monotonic_now=0.05)
        hook = Phase3b3RuntimeHook(
            direction_ack_timeout_seconds=1.0,
            qte_generation_timeout_seconds=1.0,
            result_timeout_seconds=1.0,
            post_state_timeout_seconds=1.0,
            audition_mode=AuditionMode.NO_ACTION,
        )
        hook._executor = action
        hook._target = Mock(is_running=lambda: True)

        self.assertTrue(hook.no_action_post_click_pending)
        self.assertTrue(
            hook.retain_post_space_after_control_read_failure(
                "post_qte_control_rejected:presentation_busy_or_batch_pending"
            )
        )

    def test_one_click_zero_direction_zero_space_and_resource_transition(self) -> None:
        action, mouse, backend, directions = click_only_executor()
        action.begin(observation(0.0), monotonic_now=0.0)
        action.step(observation(0.05), monotonic_now=0.05)
        self.assertIs(action.state, PetSkillActionState.POST_SKILL_REREAD)
        self.assertEqual(len(mouse.points), 1)
        self.assertEqual(backend.keys, [])
        directions.arm.assert_not_called()
        directions.step.assert_not_called()

        action.step(
            observation(
                0.10,
                post_state=post_state(),
                post_state_fresh=True,
            ),
            monotonic_now=0.10,
        )
        self.assertIsNotNone(action.result)
        self.assertIs(action.result.kind, PetSkillActionResultKind.SUCCESS_NO_ACTION)
        self.assertTrue(action.result.success)
        self.assertEqual(action.result.card_clicks, 1)
        self.assertEqual(action.result.direction_presses, 0)
        self.assertEqual(action.result.space_presses, 0)
        directions.abort.assert_not_called()

    def test_combat_end_after_click_confirms_success(self) -> None:
        action, mouse, backend, directions = click_only_executor()
        action.begin(observation(0.0), monotonic_now=0.0)
        action.step(observation(0.05), monotonic_now=0.05)
        action.step(
            observation(
                0.10,
                qte=None,
                postmatch_or_terminal=True,
                post_state=post_state(terminal=True),
                post_state_fresh=True,
            ),
            monotonic_now=0.10,
        )
        self.assertIs(action.result.kind, PetSkillActionResultKind.SUCCESS_NO_ACTION)
        self.assertEqual(len(mouse.points), 1)
        self.assertEqual(backend.keys, [])

    def test_fresh_card_actionability_transition_confirms_success(self) -> None:
        action, mouse, backend, directions = click_only_executor()
        action.begin(observation(0.0), monotonic_now=0.0)
        action.step(observation(0.05), monotonic_now=0.05)
        unchanged = post_state()
        unchanged.dedup_key = None
        unchanged.battle.turn_number = 11
        unchanged.player.mana = 250
        unchanged.player.power = 250
        used_card = replace(
            observation(0.10).live_card,
            has_used_this_turn=True,
            interactable=False,
        )
        action.step(
            observation(
                0.10,
                live_card=used_card,
                post_state=unchanged,
                post_state_fresh=True,
            ),
            monotonic_now=0.10,
        )
        self.assertIs(action.result.kind, PetSkillActionResultKind.SUCCESS_NO_ACTION)
        self.assertEqual(action.result.direction_presses, 0)
        self.assertEqual(action.result.space_presses, 0)

    def test_click_sent_timeout_is_unconfirmed_and_never_retries(self) -> None:
        action, mouse, backend, directions = click_only_executor(post_timeout=0.5)
        action.begin(observation(0.0), monotonic_now=0.0)
        action.step(observation(0.05), monotonic_now=0.05)
        action.step(observation(0.60), monotonic_now=0.60)
        self.assertIs(
            action.result.kind,
            PetSkillActionResultKind.POST_SKILL_REREAD_UNCONFIRMED,
        )
        self.assertIn("NO_RETRY", action.result.reason)
        self.assertEqual(len(mouse.points), 1)
        self.assertEqual(backend.keys, [])
        directions.abort.assert_not_called()

    def test_wrong_final_card_identity_emits_zero_input(self) -> None:
        action, mouse, backend, directions = click_only_executor()
        action.begin(observation(0.0), monotonic_now=0.0)
        action.step(
            observation(
                0.05,
                live_card=replace(observation(0.05).live_card, card_id=999),
            ),
            monotonic_now=0.05,
        )
        self.assertIs(
            action.result.kind, PetSkillActionResultKind.PREFLIGHT_REJECTED
        )
        self.assertEqual(len(mouse.points), 0)
        self.assertEqual(backend.keys, [])
        directions.arm.assert_not_called()

    def test_shutdown_after_click_cleans_up_without_qte_calls(self) -> None:
        action, mouse, backend, directions = click_only_executor()
        action.begin(observation(0.0), monotonic_now=0.0)
        action.step(observation(0.05), monotonic_now=0.05)
        action.step(
            observation(0.10, shutdown_requested=True),
            monotonic_now=0.10,
        )
        self.assertIs(action.result.kind, PetSkillActionResultKind.SHUTDOWN)
        self.assertEqual(len(mouse.points), 1)
        self.assertEqual(backend.keys, [])
        directions.abort.assert_not_called()


if __name__ == "__main__":
    unittest.main()
