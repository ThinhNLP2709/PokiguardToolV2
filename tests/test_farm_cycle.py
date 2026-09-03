"""Offline safety and integration tests for Phase 2D.2."""

from __future__ import annotations

import unittest
from pathlib import Path
from types import SimpleNamespace

from pokiguard_v2.boss_entry import BossLobbyState, FarmTarget
from pokiguard_v2.combat_lifecycle import CombatLifecycleState
from pokiguard_v2.farm_cycle import (
    FarmCycle,
    FarmCycleState,
    FarmCycleStopReason,
    InputDomain,
    OpeningEvidence,
)
from pokiguard_v2.farm_cycle_runtime import (
    CombatResult,
    EntryResult,
    EntryResultKind,
    FarmCycleCoordinator,
    FarmEntryCapability,
    FarmGameplayCapability,
)
from pokiguard_v2.state import CombatSessionKey
from tools.farm_cycle import (
    _combat_args,
    _final_invariants,
    _is_detached_chinh_phuc_room_candidate,
    _is_transient_chinh_phuc_room_rehydration,
    _resolve_pass_stage,
    _validate_combat_summary,
)


MATCH_START_SOURCE = "ChatMessageDTO.MATCH_START.matchPayload.board"


def session(epoch: int, board: int, match_id: str) -> CombatSessionKey:
    return CombatSessionKey(epoch, board, match_id)


def opening(key: CombatSessionKey, **changes: object) -> OpeningEvidence:
    values: dict[str, object] = {
        "session": key,
        "match_id": key.match_id,
        "board_hash": "a" * 64,
        "complete_cells": 64,
        "unique_coordinates": 64,
        "source": MATCH_START_SOURCE,
        "first_local_turn": True,
        "local_move_sequence": 0,
        "stable_confirmations": 2,
        "production_ready": True,
        "gem_types_valid": True,
        "multipliers_valid": True,
        "fresh_dto": True,
        "timer_safe": True,
    }
    values.update(changes)
    return OpeningEvidence(**values)  # type: ignore[arg-type]


class FarmCycleTests(unittest.TestCase):
    def test_detached_room_shell_candidate_requires_exact_pet_and_no_owner(self) -> None:
        lobby = SimpleNamespace(
            state=BossLobbyState.LOBBY_OTHER,
            branch=None,
            combat_lifecycle=SimpleNamespace(state=CombatLifecycleState.LOBBY),
            chinh_phuc=SimpleNamespace(
                current_room_id=None,
                current_room_type=None,
                room_data=0x20000001000,
                enemy_pet_id=1289,
                button_start=0x20000002000,
                button_native=0x10000002000,
                button_interactable=True,
                is_host=False,
            ),
        )
        self.assertTrue(
            _is_detached_chinh_phuc_room_candidate(
                lobby, target_pet_id=1289, no_combat_owner=True
            )
        )
        self.assertFalse(
            _is_detached_chinh_phuc_room_candidate(
                lobby, target_pet_id=2243, no_combat_owner=True
            )
        )
        self.assertFalse(
            _is_detached_chinh_phuc_room_candidate(
                lobby, target_pet_id=1289, no_combat_owner=False
            )
        )

    def test_production_combat_uses_restored_four_second_floor(self) -> None:
        args = SimpleNamespace(
            play_style="simple",
            mana_priority="evolution",
            interval=0.12,
            max_total_input_actions=100,
            combat_timeout=1800.0,
            return_lobby_timeout=30.0,
            no_beep=False,
            max_region_mib=8,
            ack_heap_region_mib=16,
            chunk_mib=2,
            reset_evidence=Path("reset.json"),
            pass_acceptance_stage=None,
        )
        combat = _combat_args(args, Path("combat.jsonl"))
        self.assertEqual(combat.minimum_action_time, 1)
        self.assertEqual(combat.postmatch_observation_timeout, 1.0)
        self.assertEqual(combat.board_input_mode, "two_click")

    def test_pass_profile_matches_every_supported_basic_policy_draft(self) -> None:
        reset = object()
        self.assertEqual(
            "B5",
            _resolve_pass_stage(
                SimpleNamespace(
                    pass_acceptance_stage=None,
                    reset_evidence=reset,
                    play_style="simple",
                    mana_priority="evolution",
                )
            ),
        )
        self.assertEqual(
            "B3",
            _resolve_pass_stage(
                SimpleNamespace(
                    pass_acceptance_stage=None,
                    reset_evidence=reset,
                    play_style="careful",
                    mana_priority="evolution",
                )
            ),
        )
        for play_style in ("simple", "careful"):
            self.assertEqual(
                "B4",
                _resolve_pass_stage(
                    SimpleNamespace(
                        pass_acceptance_stage=None,
                        reset_evidence=reset,
                        play_style=play_style,
                        mana_priority="attack",
                    )
                ),
            )
        self.assertEqual(
            "DISABLED",
            _resolve_pass_stage(
                SimpleNamespace(
                    pass_acceptance_stage=None,
                    reset_evidence=None,
                    play_style="careful",
                    mana_priority="attack",
                )
            ),
        )
        self.assertEqual(
            "P2",
            _resolve_pass_stage(
                SimpleNamespace(
                    pass_acceptance_stage="P2",
                    reset_evidence=reset,
                    play_style="careful",
                    mana_priority="attack",
                )
            ),
        )

    def test_post_result_room_rehydration_is_distinct_from_real_map(self) -> None:
        def lobby(
            *,
            room_id: str | None,
            room_data: int | None,
            room_type: str | None = "ChinhPhuc",
            button_start: int | None = None,
            button_interactable: bool | None = None,
        ):
            return SimpleNamespace(
                branch="WORLD_BOSS_LIST",
                chinh_phuc=SimpleNamespace(
                    current_room_type=room_type,
                    current_room_id=room_id,
                    room_data=room_data,
                    button_start=button_start,
                    button_interactable=button_interactable,
                ),
            )

        self.assertTrue(
            _is_transient_chinh_phuc_room_rehydration(
                lobby(room_id="Coop_578601", room_data=None)
            )
        )
        self.assertFalse(
            _is_transient_chinh_phuc_room_rehydration(
                lobby(room_id=None, room_data=None)
            )
        )
        self.assertFalse(
            _is_transient_chinh_phuc_room_rehydration(
                lobby(room_id="Coop_578601", room_data=0x20000001000)
            )
        )
        self.assertTrue(
            _is_transient_chinh_phuc_room_rehydration(
                lobby(
                    room_id="Coop_578601",
                    room_data=0x20000001000,
                    button_start=0x20000002000,
                    button_interactable=False,
                )
            )
        )
        self.assertFalse(
            _is_transient_chinh_phuc_room_rehydration(
                lobby(
                    room_id="Coop_578601",
                    room_data=0x20000001000,
                    button_start=0x20000002000,
                    button_interactable=True,
                )
            )
        )

    def setUp(self) -> None:
        self.target = FarmTarget(boss_id="1289")
        self.match1 = session(1, 0x1000, "match-1")
        self.match2 = session(2, 0x2000, "match-2")

    def _to_entry_ready(self, number: int, cycle: FarmCycle | None = None) -> FarmCycle:
        if number == 1:
            cycle = cycle or FarmCycle(self.target)
            self.assertTrue(cycle.observe_initial_lobby(BossLobbyState.BOSS_LOBBY))
        assert cycle is not None
        self.assertTrue(cycle.target_resolved(entry_number=number))
        return cycle

    def _send_entry(self, cycle: FarmCycle, number: int) -> None:
        capability = FarmEntryCapability(cycle, number)
        permit = capability.reserve(foreground=True)
        self.assertIsNotNone(permit)
        self.assertTrue(capability.complete(permit, sent=True, detail=f"entry#{number}"))  # type: ignore[arg-type]

    def _to_combat1_active(self) -> FarmCycle:
        cycle = self._to_entry_ready(1)
        self._send_entry(cycle, 1)
        self.assertTrue(cycle.accept_session(self.match1))
        self.assertTrue(cycle.accept_opening(opening(self.match1)))
        self.assertTrue(cycle.begin_combat1_play(self.match1))
        return cycle

    def _complete_normal_path(self) -> FarmCycle:
        cycle = self._to_combat1_active()
        capability = FarmGameplayCapability(cycle, self.match1)
        swap = capability.reserve(action="SWAP", session=self.match1, foreground=True)
        self.assertIsNotNone(swap)
        self.assertTrue(capability.complete(swap, sent=True, detail="2 clicks"))  # type: ignore[arg-type]
        passed = capability.reserve(action="PASS", session=self.match1, foreground=True)
        self.assertIsNotNone(passed)
        self.assertTrue(capability.complete(passed, sent=False, detail="0 clicks"))  # type: ignore[arg-type]
        self.assertTrue(cycle.combat1_finished())
        self.assertTrue(cycle.observe_postmatch())
        self.assertTrue(cycle.observe_return_lobby(BossLobbyState.BOSS_LOBBY))
        self.assertTrue(cycle.target_resolved(entry_number=2))
        self._send_entry(cycle, 2)
        self.assertTrue(cycle.accept_session(self.match2))
        self.assertTrue(cycle.accept_opening(opening(self.match2)))
        return cycle

    def test_normal_path_completes_with_exact_limits(self) -> None:
        cycle = self._complete_normal_path()
        snapshot = cycle.snapshot()
        accepted, reason = _final_invariants(cycle)

        self.assertTrue(accepted, reason)
        self.assertEqual(snapshot.state, FarmCycleState.FARM_CYCLE_COMPLETE)
        self.assertEqual(snapshot.stop_reason, FarmCycleStopReason.SECOND_COMBAT_OPENING_READY)
        self.assertEqual(snapshot.entry_inputs_total, 2)
        self.assertEqual(snapshot.combat_sessions_seen, 2)
        self.assertEqual(snapshot.combat_sessions_played, 1)
        gameplay = [record for record in snapshot.input_records if record.domain.gameplay]
        self.assertEqual([record.session for record in gameplay], [self.match1, self.match1])
        self.assertEqual([record.sent for record in gameplay], [True, False])

    def test_single_cycle_completes_at_returned_lobby_without_entry2(self) -> None:
        cycle = self._to_combat1_active()
        self.assertTrue(cycle.combat1_finished())
        self.assertTrue(cycle.observe_postmatch())
        self.assertTrue(
            cycle.complete_after_return_lobby(BossLobbyState.BOSS_LOBBY)
        )

        accepted, reason = _final_invariants(
            cycle,
            stop_after_return_lobby=True,
        )
        snapshot = cycle.snapshot()
        self.assertTrue(accepted, reason)
        self.assertEqual(reason, "SINGLE_CYCLE_RETURNED_LOBBY_PROVEN")
        self.assertEqual(snapshot.state, FarmCycleState.FARM_CYCLE_COMPLETE)
        self.assertEqual(
            snapshot.stop_reason,
            FarmCycleStopReason.RETURNED_BOSS_LOBBY_READY,
        )
        self.assertEqual(snapshot.entry_inputs_total, 1)
        self.assertEqual(snapshot.combat_sessions_seen, 1)
        self.assertEqual(snapshot.combat_sessions_played, 1)
        self.assertIsNone(snapshot.session2)

    def test_single_cycle_rejects_non_boss_lobby(self) -> None:
        cycle = self._to_combat1_active()
        self.assertTrue(cycle.combat1_finished())
        self.assertTrue(cycle.observe_postmatch())
        self.assertFalse(cycle.complete_after_return_lobby(BossLobbyState.LOBBY_OTHER))
        self.assertEqual(
            cycle.snapshot().stop_reason,
            FarmCycleStopReason.RETURN_LOBBY_TIMEOUT,
        )

    def test_entry_reservation_is_not_counted_until_executor_reports_sent(self) -> None:
        cycle = self._to_entry_ready(1)
        permit = cycle.reserve_entry(entry_number=1, foreground=True)
        self.assertIsNotNone(permit)
        self.assertEqual(cycle.snapshot().entry_inputs_total, 0)
        self.assertTrue(cycle.complete_entry(permit, sent=True))  # type: ignore[arg-type]
        self.assertEqual(cycle.snapshot().entry_inputs_total, 1)

    def test_failed_entry_input_stops_and_is_not_counted(self) -> None:
        cycle = self._to_entry_ready(1)
        permit = cycle.reserve_entry(entry_number=1, foreground=True)
        self.assertIsNotNone(permit)
        self.assertFalse(cycle.complete_entry(permit, sent=False, detail="focus changed"))  # type: ignore[arg-type]
        self.assertEqual(cycle.snapshot().entry_inputs_total, 0)
        self.assertEqual(cycle.snapshot().stop_reason, FarmCycleStopReason.ENTRY_INPUT_FAILED)

    def test_duplicate_entry_reservation_fails_closed_before_click(self) -> None:
        cycle = self._to_entry_ready(1)
        self.assertIsNotNone(cycle.reserve_entry(entry_number=1, foreground=True))
        self.assertIsNone(cycle.reserve_entry(entry_number=1, foreground=True))
        self.assertEqual(cycle.snapshot().entry_inputs_total, 0)
        self.assertEqual(cycle.snapshot().stop_reason, FarmCycleStopReason.ENTRY_CAPABILITY_DENIED)

    def test_invalid_initial_state_stops_without_input(self) -> None:
        cycle = FarmCycle(self.target)
        self.assertFalse(cycle.observe_initial_lobby(BossLobbyState.ACTIVE_COMBAT))
        self.assertEqual(cycle.snapshot().stop_reason, FarmCycleStopReason.FARM_START_STATE_INVALID)
        self.assertEqual(cycle.snapshot().input_records, ())

    def test_target_missing_and_ambiguous_preserve_zero_input(self) -> None:
        for reason in (FarmCycleStopReason.TARGET_MISSING, FarmCycleStopReason.TARGET_AMBIGUOUS):
            with self.subTest(reason=reason):
                cycle = FarmCycle(self.target)
                cycle.safe_stop(reason)
                self.assertEqual(cycle.snapshot().input_records, ())
                self.assertEqual(cycle.snapshot().stop_reason, reason)

    def test_foreground_loss_blocks_entry_before_click(self) -> None:
        cycle = self._to_entry_ready(1)
        self.assertIsNone(cycle.reserve_entry(entry_number=1, foreground=False))
        self.assertEqual(cycle.snapshot().stop_reason, FarmCycleStopReason.FOREGROUND_LOST)
        self.assertEqual(cycle.snapshot().entry_inputs_total, 0)

    def test_opening_rejects_each_required_invariant(self) -> None:
        cases = {
            "hash": {"board_hash": "not-sha256"},
            "cells": {"complete_cells": 63},
            "coordinates": {"unique_coordinates": 63},
            "gem": {"gem_types_valid": False},
            "multiplier": {"multipliers_valid": False},
            "dto": {"fresh_dto": False},
            "timer": {"timer_safe": False},
        }
        for name, changes in cases.items():
            with self.subTest(name=name):
                cycle = self._to_entry_ready(1)
                self._send_entry(cycle, 1)
                self.assertTrue(cycle.accept_session(self.match1))
                self.assertFalse(cycle.accept_opening(opening(self.match1, **changes)))
                self.assertEqual(cycle.snapshot().stop_reason, FarmCycleStopReason.OPENING_INVARIANT_FAILED)

    def test_second_session_cannot_reuse_first_match_identity(self) -> None:
        cycle = self._to_combat1_active()
        self.assertTrue(cycle.combat1_finished())
        self.assertTrue(cycle.observe_postmatch())
        self.assertTrue(cycle.observe_return_lobby(BossLobbyState.BOSS_LOBBY))
        self.assertTrue(cycle.target_resolved(entry_number=2))
        self._send_entry(cycle, 2)
        self.assertFalse(cycle.accept_session(session(2, 0x2000, "match-1")))
        self.assertEqual(cycle.snapshot().stop_reason, FarmCycleStopReason.NEW_SESSION_NOT_PROVEN_NEW)

    def test_combat_end_with_uncompleted_capability_fails_closed(self) -> None:
        cycle = self._to_combat1_active()
        permit = cycle.reserve_gameplay(InputDomain.GAMEPLAY_SWAP, self.match1, foreground=True)
        self.assertIsNotNone(permit)
        self.assertFalse(cycle.combat1_finished())
        self.assertEqual(cycle.snapshot().stop_reason, FarmCycleStopReason.INTERNAL_INVARIANT)

    def test_sequence_desync_and_dead_board_never_reenter(self) -> None:
        for detail in ("REJECTED_SEQUENCE_DESYNC", "DEAD_BOARD_NO_REFRESH"):
            with self.subTest(detail=detail):
                cycle = self._to_combat1_active()
                self.assertFalse(cycle.combat1_finished(safe_stop=True, detail=detail))
                self.assertEqual(cycle.snapshot().stop_reason, FarmCycleStopReason.COMBAT_SAFE_STOP)
                self.assertFalse(cycle.observe_postmatch())
                self.assertEqual(cycle.snapshot().entry_inputs_total, 1)

    def test_combat2_has_no_gameplay_capability_or_executor_record(self) -> None:
        cycle = self._complete_normal_path()
        capability = FarmGameplayCapability(cycle, self.match2)
        self.assertIsNone(capability.reserve(action="SWAP", session=self.match2, foreground=True))
        snapshot = cycle.snapshot()
        self.assertFalse(any(record.session == self.match2 and record.domain.gameplay for record in snapshot.input_records))

    def test_third_entry_is_rejected_without_click(self) -> None:
        cycle = self._complete_normal_path()
        capability = FarmEntryCapability(cycle, 3)
        self.assertIsNone(capability.reserve(foreground=True))
        self.assertEqual(cycle.snapshot().entry_inputs_total, 2)

    def test_return_lobby_requires_exact_boss_lobby(self) -> None:
        cycle = self._to_combat1_active()
        self.assertTrue(cycle.combat1_finished())
        self.assertTrue(cycle.observe_postmatch())
        self.assertFalse(cycle.observe_return_lobby(BossLobbyState.LOBBY_OTHER))
        self.assertEqual(cycle.snapshot().stop_reason, FarmCycleStopReason.RETURN_LOBBY_TIMEOUT)

    def test_pass_can_never_claim_a_windows_input(self) -> None:
        cycle = self._to_combat1_active()
        permit = cycle.reserve_gameplay(InputDomain.GAMEPLAY_PASS, self.match1, foreground=True)
        self.assertIsNotNone(permit)
        self.assertFalse(cycle.complete_gameplay(permit, sent=True))  # type: ignore[arg-type]
        self.assertEqual(cycle.snapshot().stop_reason, FarmCycleStopReason.INTERNAL_INVARIANT)

    def test_failed_physical_gameplay_input_stops_cycle(self) -> None:
        cycle = self._to_combat1_active()
        permit = cycle.reserve_gameplay(InputDomain.GAMEPLAY_SWAP, self.match1, foreground=True)
        self.assertIsNotNone(permit)
        self.assertFalse(cycle.complete_gameplay(permit, sent=False, detail="FOCUS_CHANGED"))  # type: ignore[arg-type]
        self.assertEqual(cycle.snapshot().stop_reason, FarmCycleStopReason.GAMEPLAY_CAPABILITY_DENIED)
        self.assertFalse(cycle.snapshot().input_records[-1].sent)

    def test_postmatch_input_is_single_use_and_separate_from_gameplay(self) -> None:
        cycle = self._to_combat1_active()
        self.assertTrue(cycle.combat1_finished())
        self.assertTrue(cycle.observe_postmatch())
        permit = cycle.reserve_postmatch_input(foreground=True)
        self.assertIsNotNone(permit)
        self.assertTrue(
            cycle.complete_postmatch_input(permit, sent=True, detail="RESULT_CONFIRM:SENT")  # type: ignore[arg-type]
        )
        record = cycle.snapshot().input_records[-1]
        self.assertEqual(record.domain, InputDomain.POSTMATCH_UI)
        self.assertTrue(record.sent)
        self.assertIsNone(record.session)

        self.assertIsNone(cycle.reserve_postmatch_input(foreground=True))
        self.assertEqual(
            cycle.snapshot().stop_reason,
            FarmCycleStopReason.POSTMATCH_UI_AMBIGUOUS,
        )


class CombatSummaryTests(unittest.TestCase):
    def valid_records(self) -> list[dict[str, object]]:
        return [
            {"event": "postmatch_observation_complete", "automaticInputDisabled": True},
            {
                "event": "auto_controller_summary",
                "stopReason": "COMBAT_LIFECYCLE_ENDED",
                "attemptClassification": "FULL_MATCH_PASS",
                "fullCombatResult": "WIN",
                "sessionCleared": True,
                "activeSession": None,
                "pending": None,
                "safetyTelemetry": {
                    "duplicate": 0,
                    "misclick": 0,
                    "partialInput": 0,
                    "wrongTurn": 0,
                    "staleAction": 0,
                    "bossTurnInput": 0,
                    "postmatchInput": 0,
                    "lobbyInput": 0,
                    "inputAfterCombat": 0,
                },
            },
        ]

    def test_accepts_only_full_safe_combat_plus_postmatch_proof(self) -> None:
        accepted, reason, _summary = _validate_combat_summary(self.valid_records())
        self.assertTrue(accepted, reason)

    def test_postmatch_ambiguity_is_not_promoted_to_success(self) -> None:
        records = self.valid_records()[1:]
        accepted, reason, _summary = _validate_combat_summary(records)
        self.assertFalse(accepted)
        self.assertEqual(reason, "POSTMATCH_NOT_AUTHORITATIVELY_OBSERVED")

    def test_authoritative_postmatch_timeout_routes_to_result_ui_handler(self) -> None:
        records = [
            {
                "event": "postmatch_observation_timeout",
                "automaticInputDisabled": True,
                "lifecycle": "postmatch",
            },
            *self.valid_records()[1:],
        ]
        accepted, reason, _summary = _validate_combat_summary(records)
        self.assertTrue(accepted, reason)
        self.assertEqual(reason, "POSTMATCH_RESULT_UI_REQUIRED")

    def test_unproven_unknown_lifecycle_loss_is_not_a_completed_match(self) -> None:
        records = self.valid_records()
        summary = records[-1]
        summary["fullCombatResult"] = "UNKNOWN"
        summary["terminalCombatSnapshot"] = {
            "result": "UNKNOWN",
            "confidence": "UNKNOWN",
            "evidence_sources": [],
            "captured_before_cleanup": False,
        }

        accepted, reason, _summary = _validate_combat_summary(records)

        self.assertFalse(accepted)
        self.assertEqual(reason, "COMBAT_TERMINAL_UNPROVEN")

    def test_evidence_backed_unknown_result_remains_a_completed_match(self) -> None:
        records = self.valid_records()
        summary = records[-1]
        summary["fullCombatResult"] = "UNKNOWN"
        summary["terminalCombatSnapshot"] = {
            "result": "UNKNOWN",
            "confidence": "PARTIAL",
            "evidence_sources": [
                "Active.PlayerStats.local",
                "Active.PlayerStats.boss",
                "ACTIVE_TO_POSTMATCH_PRE_CLEANUP",
            ],
            "captured_before_cleanup": True,
        }

        accepted, reason, _summary = _validate_combat_summary(records)

        self.assertTrue(accepted, reason)
        self.assertEqual(reason, "COMBAT_LIFECYCLE_ENDED")

    def test_safety_finding_is_not_promoted_to_success(self) -> None:
        records = self.valid_records()
        records[-1]["safetyTelemetry"]["wrongTurn"] = 1  # type: ignore[index]
        accepted, reason, _summary = _validate_combat_summary(records)
        self.assertFalse(accepted)
        self.assertEqual(reason, "COMBAT_SAFETY_COUNTER_NONZERO")


class CoordinatorTests(unittest.TestCase):
    def test_runs_two_entries_but_only_one_combat_through_capabilities(self) -> None:
        target = FarmTarget(boss_id="1289")
        first = session(1, 0x1000, "match-1")
        second = session(2, 0x2000, "match-2")

        class Lobby:
            calls: list[bool] = []

            def wait_for_lobby(self, *, initial: bool) -> BossLobbyState:
                self.calls.append(initial)
                return BossLobbyState.BOSS_LOBBY

        class Entry:
            calls: list[int] = []

            def enter(self, *, entry_number: int, capability: FarmEntryCapability) -> EntryResult:
                self.calls.append(entry_number)
                permit = capability.reserve(foreground=True)
                assert permit is not None
                capability.complete(permit, sent=True)
                key = first if entry_number == 1 else second
                return EntryResult(EntryResultKind.ACCEPTED, key, opening(key))

        class Combat:
            calls: list[CombatSessionKey] = []

            def play_one(self, *, session: CombatSessionKey, capability: FarmGameplayCapability) -> CombatResult:
                self.calls.append(session)
                permit = capability.reserve(action="SWAP", session=session, foreground=True)
                assert permit is not None
                capability.complete(permit, sent=True)
                return CombatResult(lifecycle_ended=True, postmatch_observed=True)

        lobby, entry, combat = Lobby(), Entry(), Combat()
        cycle = FarmCycleCoordinator(FarmCycle(target), lobby=lobby, entry=entry, combat=combat).run()
        self.assertEqual(entry.calls, [1, 2])
        self.assertEqual(combat.calls, [first])
        self.assertEqual(cycle.snapshot().state, FarmCycleState.FARM_CYCLE_COMPLETE)

    def test_safe_combat_result_does_not_start_second_entry(self) -> None:
        target = FarmTarget(boss_id="1289")
        first = session(1, 0x1000, "match-1")

        class Lobby:
            def wait_for_lobby(self, *, initial: bool) -> BossLobbyState:
                return BossLobbyState.BOSS_LOBBY

        class Entry:
            calls = 0

            def enter(self, *, entry_number: int, capability: FarmEntryCapability) -> EntryResult:
                self.calls += 1
                permit = capability.reserve(foreground=True)
                assert permit is not None
                capability.complete(permit, sent=True)
                return EntryResult(EntryResultKind.ACCEPTED, first, opening(first))

        class Combat:
            def play_one(self, *, session: CombatSessionKey, capability: FarmGameplayCapability) -> CombatResult:
                return CombatResult(False, safe_stop=True, reason="DEAD_BOARD_NO_REFRESH")

        entry = Entry()
        cycle = FarmCycleCoordinator(FarmCycle(target), lobby=Lobby(), entry=entry, combat=Combat()).run()
        self.assertEqual(entry.calls, 1)
        self.assertEqual(cycle.snapshot().stop_reason, FarmCycleStopReason.COMBAT_SAFE_STOP)

    def test_postmatch_ambiguity_stops_before_entry2(self) -> None:
        target = FarmTarget(boss_id="1289")
        first = session(1, 0x1000, "match-1")

        class Lobby:
            def wait_for_lobby(self, *, initial: bool) -> BossLobbyState:
                return BossLobbyState.BOSS_LOBBY

        class Entry:
            calls = 0

            def enter(self, *, entry_number: int, capability: FarmEntryCapability) -> EntryResult:
                self.calls += 1
                permit = capability.reserve(foreground=True)
                assert permit is not None
                capability.complete(permit, sent=True)
                return EntryResult(EntryResultKind.ACCEPTED, first, opening(first))

        class Combat:
            def play_one(self, *, session: CombatSessionKey, capability: FarmGameplayCapability) -> CombatResult:
                return CombatResult(True, postmatch_observed=False)

        entry = Entry()
        cycle = FarmCycleCoordinator(FarmCycle(target), lobby=Lobby(), entry=entry, combat=Combat()).run()
        self.assertEqual(entry.calls, 1)
        self.assertEqual(cycle.snapshot().stop_reason, FarmCycleStopReason.POSTMATCH_UI_AMBIGUOUS)


if __name__ == "__main__":
    unittest.main()
