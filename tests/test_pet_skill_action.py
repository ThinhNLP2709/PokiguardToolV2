from __future__ import annotations

from dataclasses import replace
from pathlib import Path
from types import SimpleNamespace
import inspect
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.combat_lifecycle import CombatLifecycleState
from pokiguard_v2.gameplay_ui import resolve_runtime_card_strip
from pokiguard_v2.il2cpp_layout import LayoutValidationError
from pokiguard_v2.native_card_ui import NativeGeometryBusyError
from pokiguard_v2.pet_qte_observer import QteBindingStatus, QteGenerationIdentity
from pokiguard_v2.pet_skill_action import (
    PetSkillActionExecutor,
    PetSkillActionObservation,
    PetSkillActionResultKind,
    PetSkillActionState,
    PetSkillCardGeometryProof,
    QteSpaceInputExecutor,
)
from pokiguard_v2.pet_skill_shadow import (
    PetSkillCapability,
    PetSkillCapabilityStatus,
    PetSkillCostSource,
    PetSkillFamily,
    PetSkillTargetMode,
    QteDirection,
    QteEvidenceStatus,
    QteSnapshot,
    QteTimingRegion,
    QteTimingResult,
    live_pet_skill_card_from_state,
)
from pokiguard_v2.qte_direction_assist import (
    QteDirectionAssist,
    QteDirectionInputExecutor,
)
from pokiguard_v2.state import CardState, CombatSessionKey, GamePhase
from pokiguard_v2.win32_input import (
    ClickPointResult,
    ClickStatus,
    ClientGeometry,
    WindowBinding,
)


SESSION_A = CombatSessionKey(1, 0x1000, "M_A")
SESSION_B = CombatSessionKey(2, 0x2000, "M_B")
BINDING = WindowBinding(0xABC, 42, "PokiguardOnlines", 1280, 640)
SEQUENCE = (QteDirection.UP, QteDirection.LEFT)


class FakeInputBackend:
    def __init__(self) -> None:
        self.geometry = ClientGeometry(10, 20, 1280, 640)
        self.pid = 42
        self.foreground = True
        self.keys: list[int] = []

    def client_geometry(self, _hwnd: int):
        return self.geometry

    def is_foreground(self, _hwnd: int) -> bool:
        return self.foreground

    def window_pid(self, _hwnd: int):
        return self.pid

    def press_virtual_key(self, key: int) -> bool:
        self.keys.append(key)
        return True


class FakeMouse:
    def __init__(self) -> None:
        self.points: list[tuple[float, float]] = []
        self.settle_cursor: list[bool] = []
        self.status = ClickStatus.SENT

    def send_normalized_point(self, _binding, point, *, settle_cursor=False):
        if self.status is ClickStatus.SENT:
            self.points.append(point)
            self.settle_cursor.append(settle_cursor)
        return ClickPointResult(self.status)


def capability(
    *, session: CombatSessionKey = SESSION_A, mana_cost: int | None = 200,
    power_cost: int | None = 200, skill_card_id: int = 7,
    actionable: bool | None = True,
) -> PetSkillCapability:
    return PetSkillCapability(
        observed_at=1.0,
        status=PetSkillCapabilityStatus.CURRENT,
        session_key=session,
        pet_id=7,
        pet_name="HT7",
        source_pet_skill_card_id=skill_card_id,
        skill_card_id=skill_card_id,
        card_data_id=70,
        card_data_address=0x3000,
        card_id=skill_card_id,
        card_name="Skill",
        skill_type="DOT_QTE",
        element_type="ATTACK_LEGEND_",
        effective_mana_cost=mana_cost,
        effective_mana_cost_source=PetSkillCostSource.CONDITION_USE,
        effective_power_cost=power_cost,
        effective_power_cost_source=PetSkillCostSource.POWER,
        raw_condition_use=mana_cost,
        raw_power=power_cost,
        raw_mana_cost=0,
        raw_power_cost=0,
        cooldown_turns=0,
        need_perfection=True,
        eat_perfect=100,
        eat_good=50,
        eat_bad=0,
        skill_family=PetSkillFamily.AUTOMATIC_DOT_DESTRUCTION,
        target_mode=PetSkillTargetMode.AUTOMATIC,
        live_card_present=True,
        live_card_actionable=actionable,
        live_card_address=0x4000,
        live_button_address=0x5000,
        ownership_current=True,
        source="current Board CardUI",
    )


def card(*, interactable: bool = True, skill_card_id: int = 7) -> CardState:
    return CardState(
        object_address=0x4000,
        data_address=0x3000,
        data_id=70,
        card_id=skill_card_id,
        name="Skill",
        description=None,
        element_type="ATTACK_LEGEND_",
        skill_type="DOT_QTE",
        interactable=interactable,
        has_used_this_match=False,
        has_used_this_turn=False,
        last_turn_used=-1,
        action_pending=False,
        is_placeholder=False,
        mana_cost=0,
        power_cost=0,
        cooldown_turns=0,
        need_perfection=True,
        condition_use=200,
        power=200,
        ui_slot=0,
        ui_slot_count=2,
        button_address=0x5000,
    )


def geometry(*, session: CombatSessionKey = SESSION_A, skill_card_id: int = 7):
    return PetSkillCardGeometryProof(
        session_key=session,
        card_ui_address=0x4000,
        button_address=0x5000,
        card_data_address=0x3000,
        skill_card_id=skill_card_id,
        window_binding=BINDING,
        normalized_point=(0.471, 0.824),
        slot_index=0,
        slot_count=2,
        source="same_session_layout_continuity_plus_current_pet_skill_cardui",
    )


def identity(*, session: CombatSessionKey = SESSION_A, generation: int = 1):
    return QteGenerationIdentity(
        session_key=session,
        local_actor_number=1,
        skill_card_id=7,
        turn_number=11,
        card_ui_address=0x4000,
        server_sequence_list_address=0x6000,
        current_arrows_list_address=0x7000,
        current_arrow_seed=123,
        observer_generation=generation,
    )


def qte(
    *,
    index: int = 0,
    elapsed: float = 1.0,
    generation: int = 1,
    sequence: tuple[QteDirection, ...] = SEQUENCE,
    session: CombatSessionKey = SESSION_A,
    active: bool = True,
    completed: bool = False,
    perfect_start: float = 3.0,
    perfect_end: float = 3.3,
    runtime: QteTimingResult | None = None,
    predicted: QteTimingResult | None = None,
    correlated: bool = False,
    server: QteTimingResult | None = None,
) -> QteSnapshot:
    current_identity = identity(session=session, generation=generation)
    presses = sequence[:index]
    return QteSnapshot(
        observed_at=100.0 + elapsed,
        match_id=session.match_id,
        session_key=session,
        turn_number=11,
        local_actor=1,
        skill_card_id=7,
        qte_generation=generation,
        qte_family=PetSkillFamily.AUTOMATIC_DOT_DESTRUCTION,
        active=active,
        raw_sequence=tuple(item.value for item in sequence),
        sequence=sequence,
        sequence_length=len(sequence),
        current_index=index,
        correct_count=index,
        completed=completed,
        raw_presses=tuple(item.value for item in presses),
        presses=presses,
        qte_start_time=100.0,
        current_elapsed=elapsed,
        perfect_start=perfect_start,
        perfect_end=perfect_end,
        recommended_confirm_elapsed=(perfect_start + perfect_end) / 2,
        timing_region=(
            QteTimingRegion.BEFORE_PERFECT
            if elapsed < perfect_start
            else QteTimingRegion.INSIDE_PERFECT
            if elapsed <= perfect_end
            else QteTimingRegion.AFTER_PERFECT
        ),
        expected_direction=(sequence[index] if index < len(sequence) else None),
        predicted_timing_result=predicted,
        runtime_result_text=(runtime.value if runtime else None),
        runtime_display_result=runtime,
        server_result_text=(server.value if server else None),
        server_resolved_result=server,
        server_response_correlated=correlated,
        server_correlation_provenance=("current generic envelope" if correlated else None),
        prediction_runtime_consistent=(predicted == runtime if predicted and runtime else None),
        prediction_server_consistent=(predicted == server if predicted and server else None),
        qte_elapsed_ms=round(elapsed * 1000),
        ownership_status=(
            QteBindingStatus.COMPLETED_CURRENT
            if completed
            else QteBindingStatus.BOUND_CURRENT
        ),
        stale_reason=None,
        evidence_status=QteEvidenceStatus.CURRENT,
        identity=current_identity,
    )


def inactive_qte(session: CombatSessionKey = SESSION_A) -> QteSnapshot:
    value = qte(session=session)
    return replace(
        value,
        match_id=session.match_id,
        active=False,
        sequence=(),
        raw_sequence=(),
        sequence_length=0,
        current_index=None,
        correct_count=None,
        presses=(),
        raw_presses=(),
        expected_direction=None,
        identity=None,
        qte_generation=None,
        ownership_status=QteBindingStatus.INACTIVE,
        evidence_status=QteEvidenceStatus.INACTIVE,
    )


def observation(now: float = 0.0, **changes) -> PetSkillActionObservation:
    values = dict(
        sampled_monotonic=now,
        match_id=SESSION_A.match_id,
        session_key=SESSION_A,
        lifecycle=CombatLifecycleState.ACTIVE,
        local_actor=1,
        turn_number=11,
        is_local_turn=True,
        mana=250,
        power=250,
        capability=capability(),
        live_card=card(),
        geometry=geometry(),
        qte=inactive_qte(),
        inactive_qte_proven=True,
        window_binding=BINDING,
    )
    values.update(changes)
    return PetSkillActionObservation(**values)


def post_state(*, terminal: bool = False):
    return SimpleNamespace(
        phase=(GamePhase.UNKNOWN if terminal else GamePhase.COMBAT),
        dedup_key=(None if terminal else (SESSION_A, 12, "after")),
        battle=SimpleNamespace(
            match_id="M_A",
            turn_number=12,
            combat_lifecycle=(
                CombatLifecycleState.POSTMATCH
                if terminal
                else CombatLifecycleState.ACTIVE
            ),
            stable=not terminal,
            is_board_ready=(None if terminal else True),
            is_cascade_running=(None if terminal else False),
            board_is_processing_ui=False,
            presentation_busy=False,
            board_is_game_over=terminal,
            match_over=terminal,
            local_has_left_match=False,
        ),
        player=SimpleNamespace(mana=50, power=50),
    )


def executor():
    backend = FakeInputBackend()
    mouse = FakeMouse()
    directions = QteDirectionAssist(
        QteDirectionInputExecutor(backend),
        response_timeout_seconds=0.5,
        timestamp=lambda: 100.0,
    )
    action = PetSkillActionExecutor(
        mouse,
        directions,
        QteSpaceInputExecutor(backend),
        result_timeout_seconds=5.0,
        timestamp=lambda: 100.0,
        action_id_factory=lambda: "ACTION-1",
    )
    return action, mouse, backend


def begin_and_bind(action: PetSkillActionExecutor, *, window=(3.0, 3.3)):
    action.begin(observation(0.0), monotonic_now=0.0)
    action.step(observation(0.05), monotonic_now=0.05)
    action.step(
        observation(
            0.1,
            qte=qte(elapsed=0.2, perfect_start=window[0], perfect_end=window[1]),
            inactive_qte_proven=False,
        ),
        monotonic_now=0.1,
    )


def finish_directions(action: PetSkillActionExecutor, *, window=(3.0, 3.3)):
    begin_and_bind(action, window=window)
    action.step(observation(0.15, qte=qte(index=0, elapsed=0.25, perfect_start=window[0], perfect_end=window[1])), monotonic_now=0.15)
    action.step(observation(0.20, qte=qte(index=1, elapsed=0.30, perfect_start=window[0], perfect_end=window[1])), monotonic_now=0.20)
    action.step(observation(0.25, qte=qte(index=1, elapsed=0.35, perfect_start=window[0], perfect_end=window[1])), monotonic_now=0.25)
    action.step(observation(0.30, qte=qte(index=2, elapsed=0.40, perfect_start=window[0], perfect_end=window[1])), monotonic_now=0.30)


class PetSkillActionTests(unittest.TestCase):
    def test_post_state_wait_accepts_bounded_long_skill_animation_window(self):
        backend = FakeInputBackend()
        mouse = FakeMouse()
        directions = QteDirectionAssist(
            QteDirectionInputExecutor(backend),
            response_timeout_seconds=0.5,
            timestamp=lambda: 100.0,
        )

        action = PetSkillActionExecutor(
            mouse,
            directions,
            QteSpaceInputExecutor(backend),
            post_state_timeout_seconds=30.0,
        )

        self.assertIsInstance(action, PetSkillActionExecutor)
        with self.assertRaisesRegex(ValueError, "between 0.5 and 30 seconds"):
            PetSkillActionExecutor(
                mouse,
                directions,
                QteSpaceInputExecutor(backend),
                post_state_timeout_seconds=30.01,
            )

    def test_valid_full_path_is_one_card_two_arrows_one_space_and_perfect(self):
        action, mouse, backend = executor()
        finish_directions(action)
        self.assertEqual(action.state, PetSkillActionState.WAIT_PERFECT_TARGET)
        action.step(observation(1.0, qte=qte(index=2, elapsed=3.15)), monotonic_now=1.0)
        action.step(
            observation(
                1.1,
                qte=qte(
                    index=2, elapsed=3.16, active=False, completed=True,
                    predicted=QteTimingResult.PERFECT,
                    runtime=QteTimingResult.PERFECT,
                    correlated=True,
                ),
            ),
            monotonic_now=1.1,
        )
        action.step(
            observation(1.2, post_state=post_state(), post_state_fresh=True),
            monotonic_now=1.2,
        )
        self.assertTrue(action.result.success)  # type: ignore[union-attr]
        self.assertEqual(len(mouse.points), 1)
        self.assertEqual(backend.keys, [0x26, 0x25, 0x20])
        self.assertEqual(action.result.card_clicks, 1)  # type: ignore[union-attr]
        self.assertEqual(action.result.space_presses, 1)  # type: ignore[union-attr]

    def test_runtime_perfect_completes_without_callback_or_settled_state(self):
        action, _, backend = executor()
        finish_directions(action)
        action.step(observation(1.0, qte=qte(index=2, elapsed=3.15)), monotonic_now=1.0)
        action.step(
            observation(
                1.1,
                qte=qte(
                    index=2,
                    elapsed=3.16,
                    active=False,
                    completed=True,
                    runtime=QteTimingResult.PERFECT,
                ),
            ),
            monotonic_now=1.1,
        )
        self.assertEqual(action.state, PetSkillActionState.COMPLETE)
        self.assertTrue(action.result.success)  # type: ignore[union-attr]
        self.assertEqual(
            action.result.reason,  # type: ignore[union-attr]
            "CURRENT_GENERATION_RUNTIME_PERFECT",
        )
        self.assertIsNone(action.result.post_state)  # type: ignore[union-attr]

        unsettled = post_state()
        unsettled.battle.is_cascade_running = True
        action.step(
            observation(1.2, post_state=unsettled, post_state_fresh=True),
            monotonic_now=1.2,
        )
        first_result = action.result

        unchanged = post_state()
        unchanged.battle.turn_number = 11
        unchanged.player.mana = 250
        unchanged.player.power = 250
        action.step(
            observation(1.25, post_state=unchanged, post_state_fresh=True),
            monotonic_now=1.25,
        )
        self.assertIs(action.result, first_result)

        action.step(
            observation(1.3, post_state=post_state(), post_state_fresh=True),
            monotonic_now=1.3,
        )
        self.assertIs(action.result, first_result)
        self.assertTrue(action.result.success)  # type: ignore[union-attr]
        self.assertFalse(action.result.telemetry.server_response_correlated)  # type: ignore[union-attr]
        self.assertEqual(backend.keys.count(0x20), 1)

    def test_invalid_resources_send_zero_input(self):
        action, mouse, backend = executor()
        action.begin(observation(mana=199), monotonic_now=0.0)
        self.assertEqual(action.result.kind, PetSkillActionResultKind.PREFLIGHT_REJECTED)  # type: ignore[union-attr]
        self.assertEqual((mouse.points, backend.keys), ([], []))

    def test_missing_capability_sends_zero_input(self):
        action, mouse, backend = executor()
        action.begin(observation(capability=None), monotonic_now=0.0)
        self.assertEqual((mouse.points, backend.keys), ([], []))

    def test_missing_live_card_sends_zero_input(self):
        action, mouse, backend = executor()
        action.begin(observation(live_card=None), monotonic_now=0.0)
        self.assertEqual((mouse.points, backend.keys), ([], []))

    def test_card_not_interactable_sends_zero_input(self):
        action, mouse, backend = executor()
        action.begin(
            observation(live_card=card(interactable=False), capability=capability(actionable=False)),
            monotonic_now=0.0,
        )
        self.assertEqual((mouse.points, backend.keys), ([], []))

    def test_ambiguous_capability_sends_zero_input(self):
        action, mouse, backend = executor()
        ambiguous = replace(
            capability(),
            status=PetSkillCapabilityStatus.AMBIGUOUS,
            ownership_current=False,
        )
        action.begin(observation(capability=ambiguous), monotonic_now=0.0)
        self.assertEqual((mouse.points, backend.keys), ([], []))

    def test_wrong_match_before_card_sends_zero(self):
        action, mouse, _ = executor()
        action.begin(observation(match_id="M_WRONG"), monotonic_now=0.0)
        self.assertEqual(mouse.points, [])

    def test_foreground_lost_before_card_sends_zero(self):
        action, mouse, backend = executor()
        action.begin(observation(game_foreground=False), monotonic_now=0.0)
        self.assertEqual(mouse.points, [])
        self.assertEqual(action.result.kind, PetSkillActionResultKind.PREFLIGHT_REJECTED)  # type: ignore[union-attr]

    def test_stale_qte_after_card_sends_no_arrows(self):
        action, _, backend = executor()
        action.begin(observation(), monotonic_now=0.0)
        action.step(observation(0.05), monotonic_now=0.05)
        action.step(observation(0.1, qte=qte(session=SESSION_B)), monotonic_now=0.1)
        self.assertEqual(backend.keys, [])
        self.assertEqual(action.result.kind, PetSkillActionResultKind.QTE_STALE_OR_AMBIGUOUS)  # type: ignore[union-attr]

    def test_no_fresh_qte_never_retries_card(self):
        action, mouse, backend = executor()
        action.begin(observation(), monotonic_now=0.0)
        action.step(observation(0.05), monotonic_now=0.05)
        action.step(observation(3.1), monotonic_now=3.1)
        self.assertEqual(len(mouse.points), 1)
        self.assertEqual(mouse.settle_cursor, [True])
        self.assertEqual(backend.keys, [])
        self.assertEqual(action.result.kind, PetSkillActionResultKind.CARD_CLICK_SENT_QTE_UNCONFIRMED)  # type: ignore[union-attr]

    def test_midstream_qte_is_not_fresh(self):
        action, _, backend = executor()
        action.begin(observation(), monotonic_now=0.0)
        action.step(observation(0.05), monotonic_now=0.05)
        action.step(observation(0.1, qte=qte(index=1)), monotonic_now=0.1)
        self.assertEqual(backend.keys, [])

    def test_generation_change_during_arrows_blocks_remaining_input(self):
        action, _, backend = executor()
        begin_and_bind(action)
        action.step(observation(0.15, qte=qte(index=0)), monotonic_now=0.15)
        action.step(observation(0.20, qte=qte(index=1, generation=2)), monotonic_now=0.20)
        self.assertEqual(backend.keys, [0x26])
        self.assertEqual(action.result.kind, PetSkillActionResultKind.QTE_STALE_OR_AMBIGUOUS)  # type: ignore[union-attr]

    def test_direction_unconfirmed_never_sends_space(self):
        action, _, backend = executor()
        begin_and_bind(action)
        action.step(observation(0.15, qte=qte(index=0)), monotonic_now=0.15)
        action.step(observation(0.70, qte=qte(index=0)), monotonic_now=0.70)
        self.assertEqual(backend.keys, [0x26])
        self.assertEqual(action.result.kind, PetSkillActionResultKind.DIRECTION_UNCONFIRMED)  # type: ignore[union-attr]

    def test_invalid_perfect_interval_sends_no_space(self):
        action, _, backend = executor()
        finish_directions(action)
        bad = replace(qte(index=2, elapsed=3.15), perfect_start=None)
        action.step(observation(1.0, qte=bad), monotonic_now=1.0)
        self.assertNotIn(0x20, backend.keys)

    def test_different_runtime_windows_use_their_own_midpoints(self):
        for window in ((2.7, 3.0), (3.4, 3.8)):
            action, _, backend = executor()
            finish_directions(action, window=window)
            midpoint = sum(window) / 2
            action.step(
                observation(1.0, qte=qte(index=2, elapsed=midpoint, perfect_start=window[0], perfect_end=window[1])),
                monotonic_now=1.0,
            )
            self.assertEqual(backend.keys[-1], 0x20)
            self.assertAlmostEqual(action.telemetry.target_confirm_elapsed, midpoint)

    def test_early_perfect_wait_does_not_press_space(self):
        action, _, backend = executor()
        finish_directions(action)
        action.step(observation(1.0, qte=qte(index=2, elapsed=2.8)), monotonic_now=1.0)
        self.assertNotIn(0x20, backend.keys)

    def test_lifecycle_change_during_perfect_wait_sends_no_space(self):
        action, _, backend = executor()
        finish_directions(action)
        action.step(
            observation(
                1.0,
                qte=qte(index=2, elapsed=3.15),
                lifecycle=CombatLifecycleState.POSTMATCH,
            ),
            monotonic_now=1.0,
        )
        self.assertNotIn(0x20, backend.keys)

    def test_delayed_provider_sample_fails_final_preflight(self):
        action, _, backend = executor()
        finish_directions(action)
        action.step(
            observation(0.5, qte=qte(index=2, elapsed=2.7)),
            monotonic_now=1.0,
        )
        self.assertNotIn(0x20, backend.keys)

    def test_passed_perfect_window_sends_no_space(self):
        action, _, backend = executor()
        finish_directions(action)
        action.step(observation(1.0, qte=qte(index=2, elapsed=3.31)), monotonic_now=1.0)
        self.assertNotIn(0x20, backend.keys)
        self.assertEqual(action.result.kind, PetSkillActionResultKind.PERFECT_WINDOW_MISSED)  # type: ignore[union-attr]

    def test_foreground_loss_during_wait_sends_no_space(self):
        action, _, backend = executor()
        finish_directions(action)
        backend.foreground = False
        action.step(
            observation(1.0, qte=qte(index=2, elapsed=3.15), game_foreground=False),
            monotonic_now=1.0,
        )
        self.assertNotIn(0x20, backend.keys)
        self.assertEqual(action.result.kind, PetSkillActionResultKind.INVALIDATED)  # type: ignore[union-attr]

    def test_changed_capability_at_final_preflight_sends_no_space(self):
        action, _, backend = executor()
        finish_directions(action)
        action.step(
            observation(
                1.0,
                qte=qte(index=2, elapsed=3.15),
                capability=capability(skill_card_id=8),
            ),
            monotonic_now=1.0,
        )
        self.assertNotIn(0x20, backend.keys)

    def test_changed_source_turn_at_final_preflight_sends_no_space(self):
        action, _, backend = executor()
        finish_directions(action)
        action.step(
            observation(1.0, qte=qte(index=2, elapsed=3.15), turn_number=12),
            monotonic_now=1.0,
        )
        self.assertNotIn(0x20, backend.keys)

    def test_delayed_result_does_not_send_second_space(self):
        action, _, backend = executor()
        finish_directions(action)
        action.step(observation(1.0, qte=qte(index=2, elapsed=3.15)), monotonic_now=1.0)
        action.step(observation(2.0, qte=qte(index=2, elapsed=3.2)), monotonic_now=2.0)
        action.step(observation(6.1, qte=qte(index=2, elapsed=3.2)), monotonic_now=6.1)
        self.assertEqual(backend.keys.count(0x20), 1)
        self.assertEqual(action.result.kind, PetSkillActionResultKind.SPACE_SENT_RESULT_UNCONFIRMED)  # type: ignore[union-attr]
        self.assertEqual(
            action.result.reason,  # type: ignore[union-attr]
            "SPACE_SENT_RUNTIME_COMPLETION_UNCONFIRMED_NO_RETRY",
        )

    def test_foreground_loss_on_runtime_perfect_does_not_veto_completed_input(self):
        action, mouse, backend = executor()
        finish_directions(action)
        action.step(observation(1.0, qte=qte(index=2, elapsed=3.15)), monotonic_now=1.0)
        before = list(backend.keys)

        action.step(
            observation(
                1.1,
                qte=qte(
                    index=2,
                    elapsed=3.16,
                    active=False,
                    completed=True,
                    predicted=QteTimingResult.PERFECT,
                    runtime=QteTimingResult.PERFECT,
                ),
                game_foreground=False,
            ),
            monotonic_now=1.1,
        )

        self.assertTrue(action.result.success)  # type: ignore[union-attr]
        self.assertEqual(action.state, PetSkillActionState.COMPLETE)
        self.assertEqual(len(mouse.points), 1)
        self.assertEqual(backend.keys, before)

    def test_terminal_after_runtime_perfect_is_outside_completed_primitive(self):
        action, mouse, backend = executor()
        finish_directions(action)
        action.step(observation(1.0, qte=qte(index=2, elapsed=3.15)), monotonic_now=1.0)
        completed = qte(
            index=2,
            elapsed=3.16,
            active=False,
            completed=True,
            predicted=QteTimingResult.PERFECT,
            runtime=QteTimingResult.PERFECT,
        )
        action.step(observation(1.1, qte=completed), monotonic_now=1.1)
        before = list(backend.keys)

        action.step(
            observation(
                1.2,
                qte=None,
                lifecycle=CombatLifecycleState.UNKNOWN,
                postmatch_or_terminal=True,
            ),
            monotonic_now=1.2,
        )
        self.assertTrue(action.result.success)  # type: ignore[union-attr]
        self.assertEqual(action.state, PetSkillActionState.COMPLETE)
        accepted = action.result

        terminal_state = post_state(terminal=True)
        action.step(
            observation(
                1.3,
                qte=None,
                lifecycle=CombatLifecycleState.UNKNOWN,
                postmatch_or_terminal=True,
                post_state=terminal_state,
                post_state_fresh=True,
            ),
            monotonic_now=1.3,
        )

        self.assertIs(action.result, accepted)
        self.assertIsNone(action.result.post_state)  # type: ignore[union-attr]
        self.assertEqual(len(mouse.points), 1)
        self.assertEqual(backend.keys, before)

    def test_good_and_bad_are_timing_mismatches(self):
        for outcome in (QteTimingResult.GOOD, QteTimingResult.BAD):
            action, _, backend = executor()
            finish_directions(action)
            action.step(observation(1.0, qte=qte(index=2, elapsed=3.15)), monotonic_now=1.0)
            action.step(
                observation(1.1, qte=qte(index=2, elapsed=3.16, active=False, completed=True, predicted=outcome, runtime=outcome, correlated=True, server=outcome)),
                monotonic_now=1.1,
            )
            self.assertEqual(action.result.kind, PetSkillActionResultKind.TIMING_RESULT_MISMATCH)  # type: ignore[union-attr]
            self.assertEqual(backend.keys.count(0x20), 1)

    def test_server_timing_echo_is_optional_telemetry_after_runtime_perfect(self):
        action, _, _ = executor()
        finish_directions(action)
        action.step(observation(1.0, qte=qte(index=2, elapsed=3.15)), monotonic_now=1.0)
        completed = qte(
            index=2,
            elapsed=3.16,
            active=False,
            completed=True,
            predicted=QteTimingResult.PERFECT,
            runtime=QteTimingResult.PERFECT,
            correlated=True,
            server=QteTimingResult.GOOD,
        )
        action.step(observation(1.1, qte=completed), monotonic_now=1.1)
        self.assertEqual(action.state, PetSkillActionState.COMPLETE)
        self.assertTrue(action.result.success)  # type: ignore[union-attr]
        self.assertTrue(action.result.telemetry.server_response_correlated)  # type: ignore[union-attr]
        self.assertEqual(
            action.result.telemetry.server_result,  # type: ignore[union-attr]
            QteTimingResult.GOOD,
        )

    def test_late_server_reject_cannot_reopen_completed_runtime_perfect(self):
        action, _, backend = executor()
        finish_directions(action)
        action.step(observation(1.0, qte=qte(index=2, elapsed=3.15)), monotonic_now=1.0)
        action.step(
            observation(
                1.1,
                qte=qte(
                    index=2,
                    elapsed=3.16,
                    active=False,
                    completed=True,
                    runtime=QteTimingResult.PERFECT,
                ),
            ),
            monotonic_now=1.1,
        )
        accepted = action.result
        action.reject_server_result(monotonic_now=1.2, reason="late callback")
        self.assertIs(action.result, accepted)
        self.assertTrue(action.result.success)  # type: ignore[union-attr]
        self.assertFalse(action.result.telemetry.server_reject_observed)  # type: ignore[union-attr]
        self.assertEqual(backend.keys.count(0x20), 1)

    def test_exact_explicit_server_reject_before_runtime_perfect_fails(self):
        action, _, backend = executor()
        finish_directions(action)
        action.step(
            observation(1.0, qte=qte(index=2, elapsed=3.15)),
            monotonic_now=1.0,
        )
        self.assertEqual(action.state, PetSkillActionState.WAIT_RESULT)
        action.reject_server_result(monotonic_now=1.05, reason="server rejected skill")
        self.assertEqual(
            action.result.kind,  # type: ignore[union-attr]
            PetSkillActionResultKind.INVALIDATED,
        )
        self.assertTrue(action.result.telemetry.server_reject_observed)  # type: ignore[union-attr]
        self.assertEqual(backend.keys.count(0x20), 1)

    def test_stale_old_result_is_rejected(self):
        action, _, backend = executor()
        finish_directions(action)
        action.step(observation(1.0, qte=qte(index=2, elapsed=3.15)), monotonic_now=1.0)
        action.step(observation(1.1, qte=qte(index=2, generation=2, active=False, completed=True, predicted=QteTimingResult.PERFECT, runtime=QteTimingResult.PERFECT, correlated=True)), monotonic_now=1.1)
        self.assertEqual(action.result.kind, PetSkillActionResultKind.INVALIDATED)  # type: ignore[union-attr]
        self.assertEqual(backend.keys.count(0x20), 1)

    def test_emergency_stop_at_each_input_boundary_never_adds_input(self):
        # before card
        action, mouse, backend = executor()
        action.begin(observation(emergency_stop=True), monotonic_now=0.0)
        self.assertEqual((len(mouse.points), backend.keys), (0, []))
        # after card
        action, mouse, backend = executor()
        action.begin(observation(), monotonic_now=0.0)
        action.step(observation(0.05), monotonic_now=0.05)
        action.step(observation(0.1, emergency_stop=True), monotonic_now=0.1)
        self.assertEqual((len(mouse.points), backend.keys), (1, []))
        # after one arrow
        action, _, backend = executor()
        begin_and_bind(action)
        action.step(observation(0.15, qte=qte(index=0)), monotonic_now=0.15)
        action.step(observation(0.16, qte=qte(index=0), emergency_stop=True), monotonic_now=0.16)
        self.assertEqual(backend.keys, [0x26])
        # directions complete / waiting Perfect
        action, _, backend = executor()
        finish_directions(action)
        action.step(observation(0.4, qte=qte(index=2), emergency_stop=True), monotonic_now=0.4)
        self.assertNotIn(0x20, backend.keys)
        # after Space before result
        action, _, backend = executor()
        finish_directions(action)
        action.step(observation(1.0, qte=qte(index=2, elapsed=3.15)), monotonic_now=1.0)
        action.step(observation(1.01, qte=qte(index=2, elapsed=3.16), emergency_stop=True), monotonic_now=1.01)
        self.assertEqual(backend.keys.count(0x20), 1)

    def test_session_isolation_requires_new_executor_and_new_generation(self):
        action, _, _ = executor()
        action.begin(observation(), monotonic_now=0.0)
        with self.assertRaises(RuntimeError):
            action.begin(observation(), monotonic_now=0.1)
        action_b, mouse_b, _ = executor()
        obs_b = observation(
            session_key=SESSION_B,
            match_id="M_B",
            capability=capability(session=SESSION_B),
            geometry=geometry(session=SESSION_B),
            qte=inactive_qte(SESSION_B),
        )
        action_b.begin(obs_b, monotonic_now=0.0)
        action_b.step(replace(obs_b, sampled_monotonic=0.05), monotonic_now=0.05)
        self.assertEqual(len(mouse_b.points), 1)

    def test_resources_drop_between_initial_and_final_card_preflight(self):
        action, mouse, backend = executor()
        action.begin(observation(0.0), monotonic_now=0.0)
        action.step(observation(0.05, mana=199), monotonic_now=0.05)
        self.assertEqual((mouse.points, backend.keys), ([], []))
        self.assertEqual(action.result.kind, PetSkillActionResultKind.PREFLIGHT_REJECTED)  # type: ignore[union-attr]

    def test_card_changes_between_initial_and_final_preflight(self):
        action, mouse, backend = executor()
        action.begin(observation(0.0), monotonic_now=0.0)
        changed = replace(card(), object_address=0x4444)
        action.step(observation(0.05, live_card=changed), monotonic_now=0.05)
        self.assertEqual((mouse.points, backend.keys), ([], []))

    def test_card_geometry_identity_conflict_sends_zero(self):
        action, mouse, _ = executor()
        action.begin(observation(geometry=geometry(skill_card_id=2)), monotonic_now=0.0)
        self.assertEqual(mouse.points, [])

    def test_previous_layout_cannot_authorize_post_fusion_skill_slot(self):
        baseline = resolve_runtime_card_strip(
            selected_card_data_addresses=(0x1000, 0x2000, 0x3000),
            rendered_card_data_addresses=(0x1000, 0x2000, 0x3000),
            cards_in_hand_count=4, fusion_expected=True,
            fusion_skill_card_data_address=None,
        )
        for owner_count in (4, 5, 6):
            with self.subTest(owner_count=owner_count):
                layout = resolve_runtime_card_strip(
                    selected_card_data_addresses=(0x1000, 0x2000, 0x3000),
                    rendered_card_data_addresses=(0x1000, 0x2000, 0x3000, 0x7000),
                    cards_in_hand_count=owner_count, fusion_expected=True,
                    fusion_skill_card_data_address=0x7000,
                    prior_current_session_layout=baseline,
                )
                self.assertFalse(layout.resolved)
                self.assertIsNone(layout.pet_skill_slot)
                self.assertEqual(layout.reason, "pet_skill_requires_current_native_geometry")

    def test_live_card_projection_preserves_exact_button_identity(self):
        projected = live_pet_skill_card_from_state(
            card(),
            session_key=SESSION_A,
            active_instance=0x9000,
        )
        self.assertTrue(projected.button_validated)
        self.assertEqual(projected.button_address, 0x5000)
        self.assertEqual(projected.card_ui_address, 0x4000)

    def test_module_has_no_forbidden_direct_or_network_path(self):
        import pokiguard_v2.pet_skill_action as module

        source = inspect.getsource(module)
        for forbidden in (
            "WriteProcessMemory",
            "RequestSwap",
            "SendSkillUse",
            "RequestQteChallenge",
            "CreateRemoteThread",
            "socket.",
        ):
            self.assertNotIn(forbidden, source)
        harness = (
            Path(__file__).resolve().parents[1] / "tools" / "pet_skill_action.py"
        ).read_text(encoding="utf-8")
        self.assertIn("AutomationControllerLease", harness)
        self.assertIn("--execute-once", harness)
        self.assertIn("qtes=0", harness)
        for forbidden in (
            "WriteProcessMemory",
            "CreateRemoteThread",
            "RequestSwap",
            "SendMove",
            "SendSkillUse",
            "RequestQteChallenge",
        ):
            self.assertNotIn(forbidden, harness)


class QteInitializationWaitTests(unittest.TestCase):
    @staticmethod
    def pending():
        return replace(inactive_qte(), evidence_status=QteEvidenceStatus.UNKNOWN,
                       ownership_status=QteBindingStatus.SEQUENCE_UNAVAILABLE,
                       stale_reason="current server challenge has no direction sequence")

    def start(self):
        action, mouse, backend = executor()
        action.begin(observation(), monotonic_now=0)
        action.step(observation(.05), monotonic_now=.05)
        return action, mouse, backend

    def test_delayed_sequence_waits_then_binds_without_early_or_retried_input(self):
        action, mouse, backend = self.start()
        for now in (1.5, 1.6, 1.7):
            action.step(observation(now, qte=self.pending()), monotonic_now=now)
            self.assertIsNone(action.result)
            self.assertEqual(action.state, PetSkillActionState.WAIT_QTE_GENERATION)
            self.assertEqual(backend.keys, [])
        self.assertEqual(len(mouse.points), 1)
        self.assertEqual(sum(e.event == "pet_skill_qte_initialization_wait" for e in action.events), 1)
        action.step(observation(1.8, qte=qte(index=0, elapsed=.1)), monotonic_now=1.8)
        self.assertEqual(action.state, PetSkillActionState.DIRECTIONS)
        self.assertEqual(backend.keys, [])
        action.step(observation(1.85, qte=qte(index=0, elapsed=.15)), monotonic_now=1.85)
        self.assertEqual(backend.keys, [0x26])

    def test_wait_does_not_extend_original_three_second_generation_deadline(self):
        action, mouse, backend = self.start()
        for now in (1.5, 2, 2.9, 3.051):
            action.step(observation(now, qte=self.pending()), monotonic_now=now)
        self.assertEqual(action.result.reason, "CARD_CLICK_SENT_QTE_UNCONFIRMED_NO_RETRY")
        self.assertEqual(len(mouse.points), 1)
        self.assertEqual(backend.keys, [])

    def test_other_invalid_evidence_is_not_downgraded_to_waiting(self):
        for status in (QteBindingStatus.WRONG_SESSION, QteBindingStatus.WRONG_OWNER,
                       QteBindingStatus.WRONG_CARD, QteBindingStatus.UNBOUND_MIDSTREAM,
                       QteBindingStatus.AMBIGUOUS_QTE_CANDIDATES,
                       QteBindingStatus.INVALID_TIMING, QteBindingStatus.UNKNOWN_DIRECTION):
            with self.subTest(status=status):
                action, _, backend = self.start()
                action.step(observation(1, qte=replace(self.pending(), ownership_status=status)), monotonic_now=1)
                self.assertIsNotNone(action.result)
                self.assertEqual(backend.keys, [])

    def test_current_clicked_identity_turn_and_actor_remain_mandatory(self):
        for change in ({"local_actor":2}, {"turn_number":12}, {"is_local_turn":False},
                       {"capability":replace(capability(), card_data_address=0xDEAD)},
                       {"capability":replace(capability(), live_button_address=0xDEAD)},
                       {"capability":replace(capability(), live_card_address=0xDEAD)}):
            with self.subTest(change=change):
                action, _, backend = self.start()
                action.step(observation(1, qte=self.pending(), **change), monotonic_now=1)
                self.assertIsNotNone(action.result)
                self.assertEqual(backend.keys, [])

    def test_sequence_loss_after_binding_is_not_an_initialization_wait(self):
        action, _, backend = executor()
        begin_and_bind(action)
        action.step(observation(.2, qte=self.pending()), monotonic_now=.2)
        self.assertIsNotNone(action.result)
        self.assertEqual(backend.keys, [])


class RuntimeGeometryRetryTests(unittest.TestCase):
    def setUp(self):
        from tools.pet_skill_action import Phase3b3RuntimeHook
        self.hook = Phase3b3RuntimeHook(direction_ack_timeout_seconds=1.25,
            qte_generation_timeout_seconds=3, result_timeout_seconds=5, post_state_timeout_seconds=4)
        self.action, self.mouse, self.backend = executor()
        self.hook._executor, self.hook._backend, self.hook._binding = self.action, self.backend, BINDING
        self.hook._target = SimpleNamespace(pid=BINDING.pid, memory=object(), is_running=lambda:True,
            resolver=SimpleNamespace(resolve_type_info_class=lambda _:0x999, read_pointer=lambda _:0x888))
        self.entry = SimpleNamespace(viewport_rect=(.1,.7,.2,.9), root_aspect=2)
        self.hand = SimpleNamespace(entry_for_card=lambda _:self.entry, slot_for_card=lambda _:0,
                                    visible=(self.entry,))
        self.reader = SimpleNamespace(read_hand=Mock(return_value=self.hand), validate_button_owner=Mock())
        self.hook._native_cards = self.reader
        self.current = SimpleNamespace(card_data=0x3000, button=0x5000, ui_interactable=True,
            action_pending=False, is_placeholder=False, has_used_this_turn=False)
        self.capture = SimpleNamespace(width=1280, height=640, rgb=b"unused-mock")
        self.location = SimpleNamespace(found=True, normalized_point=(.15,.8), reason="current_native")
        for name, value in (("read_combat_card",self.current), ("capture_client_rgb",self.capture),
                            ("locate_native_pet_skill_control",self.location)):
            mocker = patch("tools.pet_skill_action." + name, return_value=value)
            mocker.start()
            self.addCleanup(mocker.stop)
        self.events = []
        self.hook._emit = lambda event, **fields:self.events.append((event,fields))
        self.hook._inactive_sessions.add(SESSION_A)

    def test_busy_read_then_current_hand_does_not_require_previous_slot(self):
        self.reader.read_hand.side_effect = [NativeGeometryBusyError("busy"), self.hand]
        proof = self.hook._geometry_proof(SESSION_A, replace(card(), ui_slot=None, ui_slot_count=None))
        self.assertEqual(proof.normalized_point, (.15,.8))
        self.assertEqual(proof.slot_index, 0)
        self.assertEqual(self.reader.read_hand.call_count, 2)
        self.assertEqual(self.hook._geometry_read_attempts, 2)
        self.assertEqual(self.hook._geometry_retry_reason, "busy")
        self.reader.validate_button_owner.assert_called_once_with(0x4000,0x5000,self.entry)
        self.assertEqual(self.mouse.points, [])

    def test_persistent_busy_stops_after_two_reads(self):
        self.reader.read_hand.side_effect = NativeGeometryBusyError("still busy")
        self.assertIsNone(self.hook._geometry_proof(SESSION_A, card()))
        self.assertEqual(self.reader.read_hand.call_count, 2)
        self.assertEqual(self.hook._geometry_reason, "still busy")
        self.reader.validate_button_owner.assert_not_called()

    def test_invalid_layout_or_pointer_is_not_retried(self):
        self.reader.read_hand.side_effect = LayoutValidationError("foreign owner")
        self.assertIsNone(self.hook._geometry_proof(SESSION_A, card()))
        self.assertEqual(self.reader.read_hand.call_count, 1)
        self.assertEqual(self.hook._geometry_reason, "foreign owner")

    def test_card_data_change_after_retry_still_rejects(self):
        self.reader.read_hand.side_effect = [NativeGeometryBusyError("busy"), self.hand]
        self.current.card_data = 0xDEAD
        self.assertIsNone(self.hook._geometry_proof(SESSION_A, card()))
        self.assertEqual(self.hook._geometry_reason, "CARD_CHANGED_BEFORE_GEOMETRY_PROOF")

    def test_fresh_native_proof_supplies_missing_provider_slot_without_changing_card(self):
        original = replace(card(), ui_slot=None, ui_slot_count=None)
        for now in (10.0,10.1):
            self.hook.runtime_context(sampled_monotonic=now, session=SESSION_A,
                runtime=SimpleNamespace(match_id="M_A", turn=11, current_player="local", local_username="local"),
                resources={"mana":250,"power":250}, capability=capability(), live_cards=(original,),
                local_actor=1, lifecycle_valid=True)
            with patch("tools.pet_skill_action.time.monotonic", return_value=now):
                self.hook._drive(None, inactive_qte_proven=True)
        self.assertEqual(self.action.state, PetSkillActionState.WAIT_QTE_GENERATION)
        self.assertEqual(self.mouse.points, [(.15,.8)])
        self.assertIsNone(original.ui_slot)
        self.assertIsNone(original.ui_slot_count)

    def test_combined_retry_time_does_not_restamp_final_preflight(self):
        clock = [10.0]
        def context():
            self.hook.runtime_context(sampled_monotonic=clock[0], session=SESSION_A,
                runtime=SimpleNamespace(match_id="M_A", turn=11, current_player="local", local_username="local"),
                resources={"mana":250,"power":250}, capability=capability(), live_cards=(card(),),
                local_actor=1, lifecycle_valid=True)
        context()
        with patch("tools.pet_skill_action.time.monotonic", side_effect=lambda:clock[0]):
            self.hook._drive(None, inactive_qte_proven=True)
        self.assertEqual(self.action.state, PetSkillActionState.PREFLIGHT)
        calls = []
        def delayed(*_):
            clock[0] += .2
            calls.append(1)
            if len(calls)==1:raise NativeGeometryBusyError("busy")
            return self.hand
        self.reader.read_hand.side_effect = delayed
        clock[0] = 10.1
        context()
        with patch("tools.pet_skill_action.time.monotonic", side_effect=lambda:clock[0]):
            self.hook._drive(None, inactive_qte_proven=True)
        self.assertEqual(self.action.result.reason, "FINAL_CARD_PREFLIGHT_SAMPLE_STALE")
        self.assertEqual(self.hook._latest_context["sampled_monotonic"], 10.1)
        self.assertEqual(self.mouse.points, [])
        fields = self.events[-1][1]
        self.assertEqual(fields["geometryReadAttempts"], 2)
        self.assertEqual(fields["geometryRetryReason"], "busy")
        self.assertEqual(fields["lastCardPreflightTiming"]["sampleAgeMs"], 400)


class RuntimeHookPreflightLatencyTests(unittest.TestCase):
    def setUp(self):
        from tools.pet_skill_action import Phase3b3RuntimeHook

        self.hook = Phase3b3RuntimeHook(
            direction_ack_timeout_seconds=1.25,
            qte_generation_timeout_seconds=3,
            result_timeout_seconds=5,
            post_state_timeout_seconds=4,
        )
        self.action, self.mouse, self.backend = executor()
        self.hook._executor = self.action
        self.hook._backend = self.backend
        self.hook._binding = BINDING
        self.hook._target = SimpleNamespace(is_running=lambda: True)
        self.hook._inactive_sessions.add(SESSION_A)
        self.events = []
        self.hook._emit = lambda event, **fields: self.events.append((event, fields))
        self.clock = 10.0
        self.delay = .2

        def geometry_sample(_session, _card):
            self.clock += self.delay
            return geometry()

        self.hook._geometry_proof = geometry_sample
        self.set_context()

    def set_context(self):
        self.hook.runtime_context(
            sampled_monotonic=self.clock, session=SESSION_A,
            runtime=SimpleNamespace(match_id="M_A", turn=11, current_player="local", local_username="local"),
            resources={"mana":250, "power":250}, capability=capability(),
            live_cards=(card(),), local_actor=1, lifecycle_valid=True,
        )

    def drive(self):
        with patch("tools.pet_skill_action.time.monotonic", side_effect=lambda: self.clock):
            self.hook._drive(None, inactive_qte_proven=True)

    def test_current_geometry_allows_two_separate_preflights_and_one_card_click(self):
        self.drive()
        self.assertEqual(self.action.state, PetSkillActionState.PREFLIGHT)
        self.assertEqual(self.mouse.points, [])
        self.clock += .025
        self.set_context()
        self.drive()
        self.assertEqual(len(self.mouse.points), 1)
        timing = self.events[-1][1]["lastCardPreflightTiming"]
        self.assertEqual(timing, {"geometryMs":200.0, "sampleAgeMs":200.0})

    def test_slow_geometry_keeps_original_timestamp_and_cannot_authorize_click(self):
        self.delay = .7
        self.drive()
        self.assertEqual(self.action.state, PetSkillActionState.IDLE)
        self.assertFalse(self.hook._invocation_consumed)
        self.assertEqual(self.mouse.points, [])
        self.assertEqual(self.hook._latest_context["sampled_monotonic"], 10.0)
        event, fields = self.events[-1]
        self.assertEqual(event, "pet_skill_action_waiting")
        self.assertEqual(fields["reason"], "PREFLIGHT_SAMPLE_STALE")
        self.assertEqual(fields["preflightTiming"], {"geometryMs":700.0, "sampleAgeMs":700.0})

    def test_slow_final_geometry_still_fails_closed_without_click(self):
        self.drive()
        self.clock += .025
        self.set_context()
        self.delay = .7
        self.drive()
        self.assertEqual(self.mouse.points, [])
        self.assertEqual(self.action.result.reason, "FINAL_CARD_PREFLIGHT_SAMPLE_STALE")


if __name__ == "__main__":
    unittest.main()
