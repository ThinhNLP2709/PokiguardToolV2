from __future__ import annotations

from dataclasses import replace
from pathlib import Path
import inspect
import sys
import unittest
from unittest.mock import patch


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
if str(SRC_ROOT) not in sys.path:
    sys.path.insert(0, str(SRC_ROOT))

from pokiguard_v2.pet_qte_observer import (  # noqa: E402
    QteBindingStatus,
    QteGenerationIdentity,
)
from pokiguard_v2.pet_skill_shadow import (  # noqa: E402
    PetSkillFamily,
    QteDirection,
    QteEvidenceStatus,
    QteSnapshot,
    QteTimingRegion,
)
from pokiguard_v2.qte_direction_assist import (  # noqa: E402
    AutomatedQteDirection,
    QteAssistState,
    QteDirectionAssist,
    QteDirectionInputExecutor,
    QteDirectionInputStatus,
    QteDirectionRecordStatus,
    automated_direction,
)
from pokiguard_v2.state import CombatSessionKey  # noqa: E402
from pokiguard_v2.win32_input import ClientGeometry, WindowBinding  # noqa: E402


SESSION_A = CombatSessionKey(1, 0x100000, "M_A")
SESSION_B = CombatSessionKey(2, 0x200000, "M_B")
BINDING = WindowBinding(0x1234, 42, "PokiguardOnlines", 1280, 640)
SEQUENCE = (
    QteDirection.UP,
    QteDirection.DOWN,
    QteDirection.LEFT,
    QteDirection.RIGHT,
)


class FakeKeyboardBackend:
    def __init__(self) -> None:
        self.pid = 42
        self.geometry = ClientGeometry(10, 20, 1280, 640)
        self.foreground = True
        self.delivery_ok = True
        self.virtual_keys: list[int] = []

    def client_geometry(self, _hwnd: int) -> ClientGeometry | None:
        return self.geometry

    def is_foreground(self, _hwnd: int) -> bool:
        return self.foreground

    def window_pid(self, _hwnd: int) -> int | None:
        return self.pid

    def press_virtual_key(self, virtual_key: int) -> bool:
        self.virtual_keys.append(virtual_key)
        return self.delivery_ok


class Timestamp:
    def __init__(self) -> None:
        self.value = 1000.0

    def __call__(self) -> float:
        self.value += 0.001
        return self.value


def snapshot(
    *,
    index: int = 0,
    correct: int | None = None,
    presses: tuple[QteDirection, ...] | None = None,
    sequence: tuple[QteDirection, ...] = SEQUENCE,
    generation: int = 1,
    session: CombatSessionKey = SESSION_A,
    skill_card_id: int = 7,
    turn: int = 33,
    active: bool = True,
    completed: bool = False,
    evidence_status: QteEvidenceStatus = QteEvidenceStatus.CURRENT,
    observed_at: float = 100.0,
    elapsed: float = 0.5,
) -> QteSnapshot:
    resolved_correct = index if correct is None else correct
    resolved_presses = sequence[:index] if presses is None else presses
    identity = (
        QteGenerationIdentity(
            session_key=session,
            local_actor_number=1,
            skill_card_id=skill_card_id,
            turn_number=turn,
            card_ui_address=0x500000 + generation,
            server_sequence_list_address=0x800000 + generation,
            current_arrows_list_address=0x810000 + generation,
            current_arrow_seed=55 + generation,
            observer_generation=generation,
        )
        if evidence_status is QteEvidenceStatus.CURRENT
        else None
    )
    expected = sequence[index] if 0 <= index < len(sequence) else None
    return QteSnapshot(
        observed_at=observed_at,
        match_id=session.match_id,
        session_key=session,
        turn_number=turn if identity else None,
        local_actor=1 if identity else None,
        skill_card_id=skill_card_id if identity else None,
        qte_generation=generation if identity else None,
        qte_family=PetSkillFamily.AUTOMATIC_DOT_DESTRUCTION,
        active=active,
        raw_sequence=tuple(item.value for item in sequence),
        sequence=sequence,
        sequence_length=len(sequence),
        current_index=index if identity else None,
        correct_count=resolved_correct if identity else None,
        completed=completed,
        raw_presses=tuple(item.value for item in resolved_presses),
        presses=resolved_presses,
        qte_start_time=observed_at - elapsed,
        current_elapsed=elapsed,
        perfect_start=3.0,
        perfect_end=3.3,
        recommended_confirm_elapsed=3.15,
        timing_region=QteTimingRegion.BEFORE_PERFECT,
        expected_direction=expected if identity else None,
        predicted_timing_result=None,
        runtime_result_text=None,
        runtime_display_result=None,
        server_result_text=None,
        server_resolved_result=None,
        server_response_correlated=False,
        server_correlation_provenance=None,
        prediction_runtime_consistent=None,
        prediction_server_consistent=None,
        qte_elapsed_ms=round(elapsed * 1000),
        ownership_status=(
            QteBindingStatus.BOUND_CURRENT
            if identity
            else QteBindingStatus.INACTIVE
        ),
        stale_reason=None,
        evidence_status=evidence_status,
        identity=identity,
    )


def armed_assist(
    *, response_timeout: float = 0.75
) -> tuple[QteDirectionAssist, FakeKeyboardBackend]:
    backend = FakeKeyboardBackend()
    assist = QteDirectionAssist(
        QteDirectionInputExecutor(backend),
        response_timeout_seconds=response_timeout,
        timestamp=Timestamp(),
    )
    assist.arm(
        session_key=SESSION_A,
        window_binding=BINDING,
        inactive_baseline_proven=True,
    )
    return assist, backend


def observe(
    assist: QteDirectionAssist,
    value: QteSnapshot | None,
    now: float,
    **changes: object,
):
    values: dict[str, object] = {
        "window_binding": BINDING,
        "monotonic_now": now,
        "lifecycle_valid": True,
        "authority_owned": True,
    }
    values.update(changes)
    return assist.observe(value, **values)  # type: ignore[arg-type]


def drive_sequence(
    assist: QteDirectionAssist,
    sequence: tuple[QteDirection, ...] = SEQUENCE,
) -> None:
    now = 0.0
    observe(assist, snapshot(sequence=sequence), now)
    for index in range(len(sequence)):
        now += 0.05
        observe(assist, snapshot(index=index, sequence=sequence), now)
        now += 0.05
        observe(
            assist,
            snapshot(
                index=index + 1,
                sequence=sequence,
                observed_at=100.0 + now,
                elapsed=0.4 + now,
            ),
            now,
        )


class QteDirectionInputExecutorTests(unittest.TestCase):
    def test_public_direction_vocabulary_is_only_four_directions(self) -> None:
        self.assertEqual(
            {item.value for item in AutomatedQteDirection},
            {"UP", "DOWN", "LEFT", "RIGHT"},
        )

    def test_exact_arrow_virtual_key_mapping(self) -> None:
        backend = FakeKeyboardBackend()
        executor = QteDirectionInputExecutor(backend)
        results = [executor.send_qte_direction(BINDING, item) for item in AutomatedQteDirection]
        self.assertEqual(backend.virtual_keys, [0x26, 0x28, 0x25, 0x27])
        self.assertTrue(all(item.sent and item.logical_presses == 1 for item in results))

    def test_unknown_direction_has_no_automated_mapping(self) -> None:
        self.assertIsNone(automated_direction(QteDirection.UNKNOWN))

    def test_arbitrary_key_cannot_cross_public_boundary(self) -> None:
        executor = QteDirectionInputExecutor(FakeKeyboardBackend())
        with self.assertRaises(TypeError):
            executor.send_qte_direction(BINDING, "SPACE")  # type: ignore[arg-type]

    def test_wrong_pid_sends_nothing(self) -> None:
        backend = FakeKeyboardBackend()
        backend.pid = 99
        result = QteDirectionInputExecutor(backend).send_qte_direction(
            BINDING, AutomatedQteDirection.UP
        )
        self.assertEqual(result.status, QteDirectionInputStatus.WINDOW_INVALID)
        self.assertEqual(backend.virtual_keys, [])

    def test_changed_geometry_sends_nothing(self) -> None:
        backend = FakeKeyboardBackend()
        backend.geometry = ClientGeometry(10, 20, 1279, 640)
        result = QteDirectionInputExecutor(backend).send_qte_direction(
            BINDING, AutomatedQteDirection.UP
        )
        self.assertEqual(result.status, QteDirectionInputStatus.WINDOW_CHANGED)
        self.assertEqual(backend.virtual_keys, [])

    def test_foreground_lost_sends_nothing(self) -> None:
        backend = FakeKeyboardBackend()
        backend.foreground = False
        result = QteDirectionInputExecutor(backend).send_qte_direction(
            BINDING, AutomatedQteDirection.UP
        )
        self.assertEqual(result.status, QteDirectionInputStatus.GAME_NOT_FOREGROUND)
        self.assertEqual(backend.virtual_keys, [])

    @unittest.skipUnless(sys.platform == "win32", "Win32 scan-code assertion")
    def test_native_arrow_press_uses_legacy_key_event_across_frames(self) -> None:
        import pokiguard_v2.win32_input as win32_input

        class FakeUser32:
            def __init__(self) -> None:
                self.events: list[tuple[int, int, int]] = []

            def MapVirtualKeyW(self, virtual_key: int, mode: int) -> int:
                self.asserted = (virtual_key, mode)
                return 0x48

            def keybd_event(
                self,
                virtual_key: int,
                scan_code: int,
                flags: int,
                _extra_info: int,
            ) -> None:
                self.events.append((virtual_key, scan_code, flags))

        fake = FakeUser32()
        with (
            patch.object(win32_input, "_user32", fake),
            patch.object(win32_input.time, "sleep") as sleep,
        ):
            self.assertTrue(win32_input.NativeWin32Backend().press_virtual_key(0x26))
        self.assertEqual(fake.asserted, (0x26, win32_input.MAPVK_VK_TO_VSC))
        self.assertEqual(
            fake.events,
            [
                (0x26, 0x48, win32_input.KEYEVENTF_EXTENDEDKEY),
                (
                    0x26,
                    0x48,
                    win32_input.KEYEVENTF_EXTENDEDKEY | win32_input.KEYEVENTF_KEYUP,
                ),
            ],
        )
        sleep.assert_called_once_with(win32_input.QTE_DIRECTION_KEY_HOLD_SECONDS)


class QteDirectionAssistTests(unittest.TestCase):
    def test_initial_state_is_disarmed(self) -> None:
        backend = FakeKeyboardBackend()
        assist = QteDirectionAssist(QteDirectionInputExecutor(backend))
        self.assertEqual(assist.state, QteAssistState.DISARMED)
        self.assertEqual(backend.virtual_keys, [])

    def test_explicit_arm_requires_inactive_baseline(self) -> None:
        assist = QteDirectionAssist(QteDirectionInputExecutor(FakeKeyboardBackend()))
        with self.assertRaises(ValueError):
            assist.arm(
                session_key=SESSION_A,
                window_binding=BINDING,
                inactive_baseline_proven=False,
            )

    def test_no_current_qte_while_armed_sends_zero(self) -> None:
        assist, backend = armed_assist()
        observe(assist, None, 0.0)
        self.assertEqual(assist.state, QteAssistState.ARMED_WAITING_FOR_QTE)
        self.assertEqual(backend.virtual_keys, [])

    def test_bind_requires_fresh_zero_progress_and_does_not_send_yet(self) -> None:
        assist, backend = armed_assist()
        events = observe(assist, snapshot(), 0.0)
        self.assertEqual(events[0].event, "qte_direction_generation_bound")
        self.assertEqual(assist.state, QteAssistState.BOUND_TO_GENERATION)
        self.assertEqual(backend.virtual_keys, [])

    def test_valid_one_direction_sequence(self) -> None:
        assist, backend = armed_assist()
        drive_sequence(assist, (QteDirection.LEFT,))
        self.assertEqual(backend.virtual_keys, [0x25])
        self.assertEqual(assist.state, QteAssistState.DISARMED)
        self.assertEqual(assist.last_summary.directions_confirmed, 1)  # type: ignore[union-attr]

    def test_valid_multi_direction_sequence_and_auto_disarm(self) -> None:
        assist, backend = armed_assist()
        drive_sequence(assist)
        summary = assist.last_summary
        self.assertEqual(backend.virtual_keys, [0x26, 0x28, 0x25, 0x27])
        self.assertEqual(assist.state, QteAssistState.DISARMED)
        self.assertIsNotNone(summary)
        self.assertEqual(summary.directions_sent, 4)  # type: ignore[union-attr]
        self.assertEqual(summary.directions_confirmed, 4)  # type: ignore[union-attr]
        self.assertEqual(summary.automation_stop_reason, "DIRECTIONS_COMPLETE")  # type: ignore[union-attr]
        self.assertGreater(summary.headroom_to_perfect_start, 2.0)  # type: ignore[union-attr]

    def test_each_send_waits_for_exact_progress(self) -> None:
        assist, backend = armed_assist()
        observe(assist, snapshot(), 0.0)
        observe(assist, snapshot(), 0.05)
        observe(assist, snapshot(), 0.10)
        self.assertEqual(backend.virtual_keys, [0x26])
        observe(assist, snapshot(index=1), 0.15)
        self.assertEqual(backend.virtual_keys, [0x26])
        observe(assist, snapshot(index=1), 0.20)
        self.assertEqual(backend.virtual_keys, [0x26, 0x28])

    def test_no_progress_times_out_without_retry(self) -> None:
        assist, backend = armed_assist(response_timeout=0.20)
        observe(assist, snapshot(), 0.0)
        observe(assist, snapshot(), 0.05)
        events = observe(assist, snapshot(observed_at=100.3), 0.30)
        self.assertEqual(backend.virtual_keys, [0x26])
        self.assertEqual(assist.state, QteAssistState.DISARMED)
        self.assertEqual(assist.last_summary.unconfirmed_directions, 1)  # type: ignore[union-attr]
        self.assertEqual(assist.last_summary.blind_retries, 0)  # type: ignore[union-attr]
        self.assertTrue(any(item.event == "qte_direction_input_unconfirmed" for item in events))

    def test_one_torn_read_during_ack_wait_preserves_pending_direction(self) -> None:
        assist, backend = armed_assist(response_timeout=0.50)
        observe(assist, snapshot(), 0.0)
        observe(assist, snapshot(), 0.05)
        events = assist.observe_unavailable(
            monotonic_now=0.20,
            reason="ACTIVE_QTE_UNREADABLE_OR_AMBIGUOUS",
        )
        self.assertEqual(events, ())
        self.assertEqual(backend.virtual_keys, [0x26])
        observe(assist, snapshot(index=1), 0.25)
        self.assertEqual(assist.last_summary, None)
        observe(assist, snapshot(index=1), 0.30)
        self.assertEqual(backend.virtual_keys, [0x26, 0x28])

    def test_torn_reads_expire_unconfirmed_without_retry(self) -> None:
        assist, backend = armed_assist(response_timeout=0.20)
        observe(assist, snapshot(), 0.0)
        observe(assist, snapshot(), 0.05)
        events = assist.observe_unavailable(
            monotonic_now=0.30,
            reason="ACTIVE_QTE_UNREADABLE_OR_AMBIGUOUS",
        )
        self.assertEqual(backend.virtual_keys, [0x26])
        self.assertEqual(assist.state, QteAssistState.DISARMED)
        self.assertEqual(assist.last_summary.unconfirmed_directions, 1)  # type: ignore[union-attr]
        self.assertEqual(assist.last_summary.blind_retries, 0)  # type: ignore[union-attr]
        self.assertTrue(any(item.event == "qte_direction_input_unconfirmed" for item in events))

    def test_current_index_change_before_preflight_sends_zero(self) -> None:
        assist, backend = armed_assist()
        observe(assist, snapshot(), 0.0)
        observe(assist, snapshot(index=1), 0.05)
        self.assertEqual(backend.virtual_keys, [])
        self.assertEqual(assist.last_summary.automation_stop_reason, "QTE_PREINPUT_CHANGED")  # type: ignore[union-attr]

    def test_generation_change_before_send_sends_zero(self) -> None:
        assist, backend = armed_assist()
        observe(assist, snapshot(generation=1), 0.0)
        observe(assist, snapshot(generation=2), 0.05)
        self.assertEqual(backend.virtual_keys, [])
        self.assertEqual(assist.state, QteAssistState.DISARMED)

    def test_generation_change_after_first_send_blocks_second(self) -> None:
        assist, backend = armed_assist()
        observe(assist, snapshot(generation=1), 0.0)
        observe(assist, snapshot(generation=1), 0.05)
        observe(assist, snapshot(generation=2), 0.10)
        self.assertEqual(backend.virtual_keys, [0x26])
        self.assertEqual(assist.last_summary.stale_directions, 1)  # type: ignore[union-attr]
        self.assertEqual(
            assist.last_summary.records[0].status,  # type: ignore[union-attr]
            QteDirectionRecordStatus.INVALIDATED,
        )

    def test_match_invalidation_while_waiting_records_stale_sent_input(self) -> None:
        assist, backend = armed_assist()
        observe(assist, snapshot(), 0.0)
        observe(assist, snapshot(), 0.05)
        assist.invalidate("MATCH_CHANGED")
        self.assertEqual(backend.virtual_keys, [0x26])
        self.assertEqual(assist.last_summary.stale_directions, 1)  # type: ignore[union-attr]
        self.assertEqual(
            assist.last_summary.records[0].failure_reason,  # type: ignore[union-attr]
            "MATCH_CHANGED",
        )

    def test_new_match_before_qte_revokes_authority(self) -> None:
        assist, backend = armed_assist()
        observe(assist, snapshot(session=SESSION_B), 0.0)
        self.assertEqual(backend.virtual_keys, [])
        self.assertEqual(assist.state, QteAssistState.DISARMED)

    def test_wrong_skill_card_sends_zero(self) -> None:
        assist, backend = armed_assist()
        first = snapshot(skill_card_id=7)
        observe(assist, first, 0.0)
        observe(assist, snapshot(skill_card_id=2), 0.05)
        self.assertEqual(backend.virtual_keys, [])

    def test_unknown_direction_sends_zero(self) -> None:
        assist, backend = armed_assist()
        observe(assist, snapshot(sequence=(QteDirection.UNKNOWN,)), 0.0)
        self.assertEqual(backend.virtual_keys, [])
        self.assertEqual(assist.state, QteAssistState.DISARMED)

    def test_out_of_range_initial_index_sends_zero(self) -> None:
        assist, backend = armed_assist()
        observe(assist, snapshot(index=4), 0.0)
        self.assertEqual(backend.virtual_keys, [])

    def test_unexpected_index_jump_stops(self) -> None:
        assist, backend = armed_assist()
        observe(assist, snapshot(), 0.0)
        observe(assist, snapshot(), 0.05)
        observe(assist, snapshot(index=2), 0.10)
        self.assertEqual(backend.virtual_keys, [0x26])
        self.assertEqual(assist.last_summary.skipped_directions, 1)  # type: ignore[union-attr]

    def test_wrong_correct_count_stops(self) -> None:
        assist, backend = armed_assist()
        observe(assist, snapshot(), 0.0)
        observe(assist, snapshot(), 0.05)
        observe(assist, snapshot(index=1, correct=0), 0.10)
        self.assertEqual(backend.virtual_keys, [0x26])
        self.assertEqual(assist.last_summary.wrong_directions, 1)  # type: ignore[union-attr]

    def test_recorded_direction_mismatch_is_counted_wrong(self) -> None:
        assist, backend = armed_assist()
        observe(assist, snapshot(), 0.0)
        observe(assist, snapshot(), 0.05)
        observe(
            assist,
            snapshot(index=1, correct=1, presses=(QteDirection.RIGHT,)),
            0.10,
        )
        self.assertEqual(backend.virtual_keys, [0x26])
        self.assertEqual(assist.last_summary.wrong_directions, 1)  # type: ignore[union-attr]
        self.assertEqual(  # type: ignore[union-attr]
            assist.last_summary.automation_stop_reason,
            "QTE_DIRECTION_MISMATCH",
        )

    def test_lifecycle_invalid_sends_zero(self) -> None:
        assist, backend = armed_assist()
        observe(assist, snapshot(), 0.0, lifecycle_valid=False)
        self.assertEqual(backend.virtual_keys, [])
        self.assertEqual(assist.state, QteAssistState.DISARMED)

    def test_input_authority_missing_sends_zero(self) -> None:
        assist, backend = armed_assist()
        observe(assist, snapshot(), 0.0, authority_owned=False)
        self.assertEqual(backend.virtual_keys, [])

    def test_foreground_loss_at_send_disarms(self) -> None:
        assist, backend = armed_assist()
        observe(assist, snapshot(), 0.0)
        backend.foreground = False
        observe(assist, snapshot(), 0.05)
        self.assertEqual(backend.virtual_keys, [])
        self.assertEqual(assist.state, QteAssistState.DISARMED)

    def test_operator_abort_after_confirm_prevents_next_key(self) -> None:
        assist, backend = armed_assist()
        observe(assist, snapshot(), 0.0)
        observe(assist, snapshot(), 0.05)
        observe(assist, snapshot(index=1), 0.10)
        assist.abort()
        observe(assist, snapshot(index=1), 0.15)
        self.assertEqual(backend.virtual_keys, [0x26])

    def test_emergency_after_send_prevents_additional_key(self) -> None:
        assist, backend = armed_assist()
        observe(assist, snapshot(), 0.0)
        observe(assist, snapshot(), 0.05)
        observe(assist, snapshot(), 0.10, emergency_stop=True)
        self.assertEqual(backend.virtual_keys, [0x26])
        self.assertEqual(assist.state, QteAssistState.DISARMED)

    def test_shutdown_waiting_for_progress_does_not_retry(self) -> None:
        assist, backend = armed_assist()
        observe(assist, snapshot(), 0.0)
        observe(assist, snapshot(), 0.05)
        observe(assist, snapshot(), 0.10, shutdown_requested=True)
        self.assertEqual(backend.virtual_keys, [0x26])
        self.assertEqual(assist.state, QteAssistState.DISARMED)

    def test_one_arm_never_binds_second_generation(self) -> None:
        assist, backend = armed_assist()
        drive_sequence(assist, (QteDirection.UP,))
        observe(assist, snapshot(generation=2, sequence=(QteDirection.DOWN,)), 1.0)
        self.assertEqual(backend.virtual_keys, [0x26])

    def test_summary_proves_no_card_click_or_space(self) -> None:
        assist, _backend = armed_assist()
        drive_sequence(assist, (QteDirection.RIGHT,))
        summary = assist.last_summary
        self.assertEqual(summary.automated_card_clicks, 0)  # type: ignore[union-attr]
        self.assertEqual(summary.automated_space_presses, 0)  # type: ignore[union-attr]

    def test_records_are_one_logical_press_with_authoritative_ack(self) -> None:
        assist, _backend = armed_assist()
        drive_sequence(assist, (QteDirection.DOWN,))
        record = assist.direction_records[0]
        self.assertEqual(record.status, QteDirectionRecordStatus.AUTHORITATIVELY_CONFIRMED)
        self.assertEqual(record.source_current_index, 0)
        self.assertEqual(record.post_current_index, 1)
        self.assertEqual(record.post_correct_count, 1)

    def test_module_has_no_forbidden_direct_or_network_path(self) -> None:
        import pokiguard_v2.qte_direction_assist as module

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


if __name__ == "__main__":
    unittest.main()
