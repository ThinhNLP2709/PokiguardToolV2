from __future__ import annotations

from dataclasses import replace
import threading
import unittest

from pokiguard_v2.actionability import ActionabilityGate, GateReason
from pokiguard_v2.autonomous_control import (
    AutonomousActionIdentity,
    TurnTransitionKind,
    TurnTransitionTracker,
)
from pokiguard_v2.pet_skill_action import (
    PetSkillActionResult,
    PetSkillActionResultKind,
    PetSkillActionState,
    PetSkillActionTelemetry,
)
from pokiguard_v2.pet_skill_farm import (
    PetSkillDispatchState,
    PetSkillFarmDispatcher,
)
from pokiguard_v2.basic_policy import PolicyAction
from tests.test_actionability import actionable_state, context
from tests.test_phase3c1_pet_skill_policy import (
    capability,
    session_state,
    skill_policy,
)


def result(
    kind: PetSkillActionResultKind,
    *,
    clicks: int,
) -> PetSkillActionResult:
    return PetSkillActionResult(
        kind,
        (
            PetSkillActionState.COMPLETE
            if kind is PetSkillActionResultKind.SUCCESS_PERFECT
            else PetSkillActionState.FAILED
        ),
        None,
        kind.value,
        clicks,
        1 if kind is PetSkillActionResultKind.SUCCESS_PERFECT else 0,
        PetSkillActionTelemetry(),
    )


class FakeLease:
    def __init__(self) -> None:
        self.acquired = 0
        self.completed = 0
        self.abandoned = 0

    def acquire(self):
        self.acquired += 1
        return object()

    def complete(self, _permit, sent: bool, _detail: str) -> bool:
        self.completed += 1
        return sent

    def abandon(self, _permit, _detail: str) -> bool:
        self.abandoned += 1
        return True


class Phase3c1PetSkillDispatchTests(unittest.TestCase):
    def test_success_calls_primitive_and_lease_once_then_closes_source_turn(self) -> None:
        dispatcher = PetSkillFarmDispatcher()
        lease = FakeLease()
        calls = 0

        def primitive():
            nonlocal calls
            calls += 1
            return result(PetSkillActionResultKind.SUCCESS_PERFECT, clicks=1)

        outcome = dispatcher.dispatch(
            source=("M", 17),
            acquire=lease.acquire,
            primitive=primitive,
            complete=lease.complete,
            abandon=lease.abandon,
        )
        self.assertEqual(outcome.state, PetSkillDispatchState.PET_SKILL_RESOLVING)
        self.assertTrue(outcome.source_turn_closed)
        self.assertFalse(outcome.allow_same_turn_fallback)
        self.assertEqual((calls, lease.acquired, lease.completed), (1, 1, 1))
        self.assertEqual(dispatcher.max_simultaneous, 1)

        duplicate = dispatcher.dispatch(
            source=("M", 17),
            acquire=lease.acquire,
            primitive=primitive,
            complete=lease.complete,
            abandon=lease.abandon,
        )
        self.assertEqual(
            duplicate.state,
            PetSkillDispatchState.SOURCE_TURN_ALREADY_CLOSED,
        )
        self.assertEqual((calls, lease.acquired), (1, 1))
        self.assertTrue(dispatcher.later_turn_allowed(("M", 19)))

    def test_zero_input_requires_fresh_state_without_closing_source(self) -> None:
        dispatcher = PetSkillFarmDispatcher()
        lease = FakeLease()
        outcome = dispatcher.dispatch(
            source=("M", 17),
            acquire=lease.acquire,
            primitive=lambda: result(
                PetSkillActionResultKind.PREFLIGHT_REJECTED,
                clicks=0,
            ),
            complete=lease.complete,
            abandon=lease.abandon,
        )
        self.assertEqual(
            outcome.state,
            PetSkillDispatchState.ZERO_INPUT_FRESH_STATE_REQUIRED,
        )
        self.assertTrue(outcome.fresh_state_required)
        self.assertFalse(outcome.source_turn_closed)
        self.assertEqual((lease.completed, lease.abandoned), (0, 1))

    def test_after_input_uncertainty_closes_turn_and_never_falls_back(self) -> None:
        dispatcher = PetSkillFarmDispatcher()
        lease = FakeLease()
        outcome = dispatcher.dispatch(
            source=("M", 17),
            acquire=lease.acquire,
            primitive=lambda: result(
                PetSkillActionResultKind.DIRECTION_UNCONFIRMED,
                clicks=1,
            ),
            complete=lease.complete,
            abandon=lease.abandon,
        )
        self.assertEqual(
            outcome.state,
            PetSkillDispatchState.PET_SKILL_UNCERTAIN_RESOLVING,
        )
        self.assertTrue(outcome.source_turn_closed)
        self.assertFalse(outcome.allow_same_turn_fallback)

    def test_dispatch_lock_never_allows_two_simultaneous_primitives(self) -> None:
        dispatcher = PetSkillFarmDispatcher()
        started = threading.Event()
        release = threading.Event()
        leases = [FakeLease(), FakeLease()]

        def slow():
            started.set()
            release.wait(1.0)
            return result(PetSkillActionResultKind.SUCCESS_PERFECT, clicks=1)

        first = threading.Thread(
            target=lambda: dispatcher.dispatch(
                source=("M", 17),
                acquire=leases[0].acquire,
                primitive=slow,
                complete=leases[0].complete,
                abandon=leases[0].abandon,
            )
        )
        first.start()
        self.assertTrue(started.wait(1.0))
        second = threading.Thread(
            target=lambda: dispatcher.dispatch(
                source=("M", 19),
                acquire=leases[1].acquire,
                primitive=lambda: result(
                    PetSkillActionResultKind.SUCCESS_PERFECT,
                    clicks=1,
                ),
                complete=leases[1].complete,
                abandon=leases[1].abandon,
            )
        )
        second.start()
        release.set()
        first.join(1.0)
        second.join(1.0)
        self.assertEqual(dispatcher.max_simultaneous, 1)
        self.assertEqual(dispatcher.primitive_calls, 2)

    def test_emergency_lease_revocation_sends_no_primitive_input(self) -> None:
        dispatcher = PetSkillFarmDispatcher()
        calls = 0

        def primitive():
            nonlocal calls
            calls += 1
            return result(PetSkillActionResultKind.SUCCESS_PERFECT, clicks=1)

        outcome = dispatcher.dispatch(
            source=("M", 17),
            acquire=lambda: None,
            primitive=primitive,
            complete=lambda *_args: False,
            abandon=lambda *_args: False,
        )
        self.assertEqual(outcome.state, PetSkillDispatchState.LEASE_DENIED)
        self.assertEqual(calls, 0)
        self.assertFalse(outcome.input_sent)

    def test_skill_turn_17_waits_for_boss_18_then_allows_fresh_local_19(self) -> None:
        first = session_state(mana=250, rage=250)
        first = replace(
            first,
            battle=replace(first.battle, turn_number=17, srv_seq=17),
        )
        decision = skill_policy().decide(
            first,
            pet_skill_capability=capability(card_id=120),
        )
        self.assertEqual(decision.action, PolicyAction.PET_SKILL)
        identity = AutonomousActionIdentity.from_decision(first, decision)
        tracker = TurnTransitionTracker()
        tracker.begin(identity)
        self.assertIsNone(tracker.observe(first))

        boss = replace(
            first,
            battle=replace(
                first.battle,
                turn_number=18,
                srv_seq=18,
                current_turn_player="boss",
                is_local_turn=False,
                client_move_allowed=False,
            ),
        )
        boss_observation = tracker.observe(boss)
        assert boss_observation is not None
        self.assertEqual(
            boss_observation.kind,
            TurnTransitionKind.OPPONENT_TURN,
        )

        local = replace(
            boss,
            battle=replace(
                boss.battle,
                turn_number=19,
                srv_seq=19,
                current_turn_player=first.battle.current_turn_player,
                is_local_turn=True,
                client_move_allowed=True,
            ),
        )
        local_observation = tracker.observe(local)
        assert local_observation is not None
        self.assertEqual(
            local_observation.kind,
            TurnTransitionKind.LOCAL_TURN_RETURNED,
        )
        self.assertIsNone(tracker.action)
        second = skill_policy().decide(
            local,
            pet_skill_capability=replace(
                capability(card_id=121),
                live_card_address=0x22000000100,
                live_button_address=0x24000000100,
            ),
        )
        self.assertEqual(second.action, PolicyAction.PET_SKILL)
        self.assertEqual(second.skill_card_id, 121)

    def test_terminal_after_skill_closes_wait_without_boss_turn(self) -> None:
        state = session_state(mana=250, rage=250)
        decision = skill_policy().decide(
            state,
            pet_skill_capability=capability(),
        )
        tracker = TurnTransitionTracker()
        tracker.begin(AutonomousActionIdentity.from_decision(state, decision))
        terminal = tracker.resolve_terminal()
        assert terminal is not None
        self.assertEqual(terminal.kind, TurnTransitionKind.COMBAT_TERMINAL)
        self.assertEqual(terminal.action.action, PolicyAction.PET_SKILL)
        self.assertIsNone(tracker.action)

    def test_legend_latch_alone_does_not_block_next_local_board(self) -> None:
        state = actionable_state()
        latched = replace(
            state,
            battle=replace(
                state.battle,
                board_is_using_legend_card=True,
                board_is_using_mega=False,
                board_is_mega1_panel_open=False,
                board_is_mega2_panel_open=False,
                board_modal_open=False,
            ),
        )
        gate = ActionabilityGate.evaluate(latched, context())
        self.assertTrue(gate.actionable)
        self.assertEqual(gate.reason, GateReason.PASS)


if __name__ == "__main__":
    unittest.main()
