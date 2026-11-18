"""Risky legal moves and zero-input skill failures keep the combat running."""

from dataclasses import dataclass, replace
from pathlib import Path
from types import SimpleNamespace
import tempfile
import unittest
from unittest.mock import patch

from pokiguard_v2.basic_policy import BasicPolicyEngine, PlayStyle, PolicyAction
from pokiguard_v2.board_diagnostics import analyze_game_state
from pokiguard_v2.foreground_lease_transport import LeaseStatus
from pokiguard_v2.foreground_qte_lease_transport import (
    QteLeaseAcquireResult, QteLeaseReleaseResult, QteLeaseStatus,
)
from pokiguard_v2.gameplay_profile import AuditionMode
from pokiguard_v2.input_delivery import ExactWindowBinding, InputDeliveryConfig, InputDeliveryMode
from pokiguard_v2.pet_configuration import GameplayConfig, basic_policy_config
from pokiguard_v2.pet_skill_action import PetSkillActionResultKind
from pokiguard_v2.win32_input import ClientGeometry
from tests.reasoning_controller_fixture import controller_trace
from tests.test_bu_win_no_safe_move import observed_bu_win_state
from tests.test_galaxy import galaxy_config
from tests.test_mega_icarus_click_only import click_only_executor, observation
from tests.test_phase3c1_pet_skill_policy import capability, session_state
from tests.test_phase3c3_skill_rush_policy import with_player_hp
from tests.test_pinned_pet_skill_input import FakeLease, card, hook
from tools import basic_auto_bot as bot
from tools import pet_skill_action as skill_tool


@dataclass(frozen=True)
class OfflineSwapDelivery:
    status: LeaseStatus
    action_attempted: bool
    action_succeeded: bool


def unreadable_click_only_hook(lease=None, *, expected_session=None, source_turn=10, begin=False):
    sample = observation(0.0, seal_type="MEGA_TREX", turn_number=source_turn)
    lease = lease or FakeLease()
    lease.active = True
    current = hook(
        lease, audition_mode=AuditionMode.NO_ACTION,
        expected_session=expected_session or sample.session_key,
    )
    executor, mouse, keyboard, _ = click_only_executor()
    if begin:
        executor.begin(sample, monotonic_now=0.0)
    current._executor = executor
    current._latest_context = {
        "session": expected_session or sample.session_key,
        "lifecycle_valid": True,
        "active_qte_present": False,
    }
    current.unreadable("ACTIVE_QTE_UNREADABLE_OR_AMBIGUOUS")
    return current, lease, mouse, keyboard


class GameplayRiskContinuationTests(unittest.TestCase):
    def test_galaxy_survival_with_zero_safe_moves_reaches_input_and_ack(self):
        config = galaxy_config()
        state = replace(
            with_player_hp(session_state(mana=717, rage=35), hp=22),
            board=observed_bu_win_state().board,
        )
        analysis = analyze_game_state(state)
        self.assertEqual(analysis.safe_move_count, 0)
        self.assertGreater(analysis.legal_match_producing_moves, 0)

        def skill(_provider, current, _resolver):
            return replace(
                capability(element="GALAXY_RICKY", mana_cost=200, rage_cost=200),
                session_key=current.battle.session_key,
            )

        decision = BasicPolicyEngine(basic_policy_config(config)).decide(
            state, pet_skill_capability=skill(None, state, None),
        )
        self.assertEqual(decision.trace.policy_step, "GALAXY_SURVIVAL_SWORD")
        with tempfile.TemporaryDirectory() as folder, patch.object(
            bot, "_current_pet_skill_capability", side_effect=skill
        ):
            _, calls, rows = controller_trace(
                Path(folder) / "combat.jsonl", profile=config.play_style.value,
                initial_combat=state, gameplay_config=config,
            )
        self.assertEqual(calls.count("FAKE_NORMAL_INPUT"), 1)
        self.assertEqual(calls.count("executor.ack"), 1)
        self.assertFalse(any(row.get("reason") == "POLICY_NO_SAFE_MOVE" for row in rows))

    def test_valid_risky_swap_does_not_depend_on_a_style_or_trace_allowlist(self):
        decision = BasicPolicyEngine().decide(session_state(mana=0, rage=0))
        self.assertEqual(decision.action, PolicyAction.SWAP)
        for style in PlayStyle:
            with self.subTest(style=style):
                chosen = replace(
                    decision, trace=replace(
                        decision.trace, play_style=style.value, policy_step="POLICY_SELECTED_LEGAL_MOVE",
                    ),
                )
                self.assertFalse(bot._must_pause_for_no_safe_move(
                    chosen, legal_move_count=9, safe_move_count=0, first_local_turn=False,
                ))

    def test_preclick_unreadable_card_releases_the_lease_and_allows_fresh_board(self):
        current, lease, mouse, keyboard = unreadable_click_only_hook()
        self.assertTrue(current.can_fallback_to_board)
        self.assertFalse(lease.active)
        self.assertTrue(current.lease_release_result.released)
        self.assertEqual(mouse.points, [])
        self.assertEqual(keyboard.keys, [])
        self.assertIsNone(current.result)
        self.assertEqual(current.summary["state"], "FAILED_BEFORE_ACTION")
        current, lease, mouse, keyboard = unreadable_click_only_hook(begin=True)
        self.assertTrue(current.can_fallback_to_board)
        self.assertFalse(lease.active)
        self.assertEqual(mouse.points, [])
        self.assertEqual(keyboard.keys, [])
        self.assertEqual(current.result.kind, PetSkillActionResultKind.INVALIDATED)

    def test_ambiguous_live_qte_and_invalid_ownership_do_not_authorize_fallback(self):
        for field, value in (
            ("active_qte_present", True), ("active_qte_present", None),
            ("lifecycle_valid", False), ("session", None),
        ):
            with self.subTest(field=field, value=value):
                current, _, _, _ = unreadable_click_only_hook()
                current._latest_context[field] = value
                self.assertFalse(current.can_fallback_to_board)
        current, _, _, _ = unreadable_click_only_hook(begin=True)
        original = current.result
        for change in (
            {"card_clicks": 1}, {"space_presses": 1}, {"direction_presses": 1},
            {"kind": PetSkillActionResultKind.CARD_CLICK_UNCONFIRMED},
            {"kind": PetSkillActionResultKind.EMERGENCY_STOPPED},
        ):
            with self.subTest(result=change):
                current._executor._result = replace(original, **change)
                self.assertFalse(current.can_fallback_to_board)

    def test_pinned_skill_failure_before_click_falls_back_once_on_fresh_board(self):
        config = GameplayConfig.from_dict({
            "play_style": "mega_icarus_spam_skill", "main_pet": "mega",
            "evolution": "none", "damage_card": "pet_skill",
            "pet_skill_fire_condition": "sword_count", "pet_skill_fire_value": 2,
        })
        construct = bot.SharedCombatRuntime
        permits = []
        leases = []

        def runtime(*args, **kwargs):
            original = construct(*args, **kwargs)
            binding = replace(original.binding, hwnd=5, pid=123)
            original.executor.swap_end_position = lambda _plan: None

            def execute_swap(*, action, preflight, **_kwargs):
                self.assertTrue(preflight())
                succeeded = action()
                return OfflineSwapDelivery(LeaseStatus.COMPLETE, True, succeeded)

            def create_qte_lease(**_kwargs):
                self.assertFalse(leases)
                lease = FakeLease()
                leases.append(lease)
                return SimpleNamespace(lease=lease, backend=SimpleNamespace(), authority="OFFLINE_QTE")

            pin = SimpleNamespace(
                active=True,
                binding=ExactWindowBinding(binding, ClientGeometry(0, 0, 1280, 640)),
                create_qte_lease=create_qte_lease,
                execute_swap=execute_swap,
            )
            farm = SimpleNamespace(
                reserve=lambda **event: permits.append(event["action"]) or object(),
                abandon_gameplay_preflight=lambda *_, **__: True,
                complete=lambda *_, **__: True,
            )
            return replace(
                original, binding=binding, gameplay_capability=farm, pinned_input_session=pin,
                input_delivery_config=InputDeliveryConfig(InputDeliveryMode.PINNED_FOREGROUND_LEASE_BETA),
            )

        def skill(_provider, current, _resolver):
            return replace(
                capability(element="MEGA_TREX", card_id=9999),
                session_key=current.battle.session_key,
            )

        def dispatch(**kwargs):
            current = hook(
                kwargs["pinned_qte_lease"], audition_mode=AuditionMode.NO_ACTION,
                acquired=kwargs["on_pinned_qte_lease_acquired"],
                expected_session=kwargs["expected_session"],
            )
            current._geometry_proof(kwargs["expected_session"], card())
            failed, lease, _, _ = unreadable_click_only_hook(
                kwargs["pinned_qte_lease"], expected_session=kwargs["expected_session"],
            )
            failed.lease_acquire_result = QteLeaseAcquireResult(
                QteLeaseStatus.ACTIVE, "OFFLINE_ACQUIRED", "OFFLINE_QTE",
                None, None, None, None, 0.0,
            )
            failed.lease_release_result = QteLeaseReleaseResult(
                QteLeaseStatus.COMPLETE, "OFFLINE_RELEASED", "OFFLINE_QTE",
                True, True, True, 0.0,
            )
            self.assertFalse(lease.active)
            return failed

        with tempfile.TemporaryDirectory() as folder, patch.object(
            bot, "SharedCombatRuntime", side_effect=runtime
        ), patch.object(bot, "_current_pet_skill_capability", side_effect=skill), patch.object(
            skill_tool, "run_embedded_policy_action", side_effect=dispatch
        ) as primitive:
            _, calls, rows = controller_trace(
                Path(folder) / "combat.jsonl", profile=config.play_style.value,
                initial_combat=session_state(mana=400, rage=250),
                gameplay_config=config, case="pet_skill_geometry_fallback",
            )
        primitive.assert_called_once()
        self.assertEqual(permits, ["pet_skill", "swap"])
        self.assertEqual(calls.count("FAKE_NORMAL_INPUT"), 1)
        self.assertEqual(calls.count("executor.ack"), 1)
        self.assertEqual(sum(row["event"] == "pet_skill_geometry_board_fallback" for row in rows), 1)
        fallback = next(row for row in rows if row["event"] == "pet_skill_geometry_board_fallback")
        self.assertEqual(fallback["reason"], "ACTIVE_QTE_UNREADABLE_OR_AMBIGUOUS")
        self.assertFalse(any(
            row.get("reason") == "PINNED_QTE_ZERO_INPUT_LEASE_CONSUMED" for row in rows
        ))
