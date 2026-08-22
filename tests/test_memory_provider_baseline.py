from __future__ import annotations

from dataclasses import replace
from types import SimpleNamespace
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.memory_board_provider import (
    ActionRuntimeSignals,
    MemoryBoardStateProvider,
    MemoryProviderConfig,
    ProviderMetrics,
    _combat_type_info_blocker,
    _drop_session_volatile_learned_regions,
    _durable_non_board_fusion_transition,
    _extended_card_scan_relevant,
    _extended_fusion_scan_relevant,
    _first_session_ui_scan_required,
    _extended_card_scan_still_needed,
    _match_start_opening_has_priority,
    _opening_board_action_has_priority,
    _normalize_last_move_telemetry,
    _needs_immediate_full_ack_rescan,
    _next_direct_owner_grace,
    _owner_batches_confirmed_by_ack,
    _presentation_idle_for_publication,
    _region_size_band,
    _select_latest_identity,
)
from pokiguard_v2.actionability import ActionabilityGate, GateContext
from pokiguard_v2.state import FusionState
from pokiguard_v2.il2cpp_external import MemoryRegion
from pokiguard_v2.state import ParticipantState
from tests.test_basic_policy import combat_state


class ExtendedFusionUiScanTests(unittest.TestCase):
    def test_config_rejects_ack_heap_envelope_below_normal_scan(self) -> None:
        with self.assertRaises(ValueError):
            MemoryProviderConfig(
                max_region_mib=8,
                ack_heap_region_mib=7,
            )

    def test_config_rejects_extension_below_normal_envelope(self) -> None:
        with self.assertRaises(ValueError):
            MemoryProviderConfig(
                max_region_mib=8,
                extended_fusion_ui_region_mib=7,
            )

    def test_config_rejects_card_extension_below_normal_envelope(self) -> None:
        with self.assertRaises(ValueError):
            MemoryProviderConfig(
                max_region_mib=8,
                extended_card_ui_region_mib=7,
            )

    def test_region_band_excludes_normal_and_over_limit_regions(self) -> None:
        normal = MemoryRegion(0x1000, 8 * 1024 * 1024, 0x04, 0x20000)
        evidenced = MemoryRegion(0x900000, 14 * 1024 * 1024, 0x04, 0x20000)
        too_large = MemoryRegion(0x2000000, 17 * 1024 * 1024, 0x04, 0x20000)

        self.assertEqual(
            _region_size_band(
                (normal, evidenced, too_large),
                minimum_exclusive_mib=8,
                maximum_inclusive_mib=16,
            ),
            (evidenced,),
        )

    def test_extended_scan_requires_local_turn_and_sufficient_local_mana(self) -> None:
        fusion = SimpleNamespace(
            candidate_available=True,
            mana_cost=160,
            selected_user_pet_id=218166,
            selected_pet_id=1289,
        )
        enough = (ParticipantState(1, is_local=True, mana=160),)
        short = (ParticipantState(1, is_local=True, mana=159),)

        self.assertTrue(
            _extended_fusion_scan_relevant(
                fusion,
                enough,
                is_local_turn=True,
                turn=5,
                last_scanned_turn=3,
            )
        )
        self.assertFalse(
            _extended_fusion_scan_relevant(
                fusion,
                short,
                is_local_turn=True,
                turn=5,
                last_scanned_turn=3,
            )
        )
        self.assertFalse(
            _extended_fusion_scan_relevant(
                fusion,
                enough,
                is_local_turn=False,
                turn=5,
                last_scanned_turn=3,
            )
        )
        self.assertFalse(
            _extended_fusion_scan_relevant(
                fusion,
                enough,
                is_local_turn=True,
                turn=5,
                last_scanned_turn=5,
            )
        )
        self.assertFalse(
            _extended_fusion_scan_relevant(
                SimpleNamespace(
                    candidate_available=True,
                    mana_cost=160,
                    selected_user_pet_id=0,
                    selected_pet_id=0,
                ),
                enough,
                is_local_turn=True,
                turn=5,
                last_scanned_turn=3,
            )
        )

    def test_extended_card_scan_is_bounded_and_second_try_requires_mana(self) -> None:
        no_mana = (ParticipantState(1, is_local=True, mana=0),)
        has_mana = (ParticipantState(1, is_local=True, mana=160),)

        self.assertTrue(
            _extended_card_scan_relevant(
                no_mana,
                is_local_turn=True,
                turn=1,
                last_scanned_turn=None,
                attempts=0,
            )
        )
        self.assertFalse(
            _extended_card_scan_relevant(
                no_mana,
                is_local_turn=True,
                turn=3,
                last_scanned_turn=1,
                attempts=1,
            )
        )
        self.assertTrue(
            _extended_card_scan_relevant(
                has_mana,
                is_local_turn=True,
                turn=3,
                last_scanned_turn=1,
                attempts=1,
            )
        )
        self.assertTrue(
            _extended_card_scan_relevant(
                has_mana,
                is_local_turn=True,
                turn=5,
                last_scanned_turn=3,
                attempts=2,
            )
        )
        self.assertFalse(
            _extended_card_scan_relevant(
                has_mana,
                is_local_turn=True,
                turn=9,
                last_scanned_turn=7,
                attempts=4,
            )
        )

    def test_first_session_ui_scan_forces_full_current_region_discovery(self) -> None:
        self.assertTrue(
            _first_session_ui_scan_required(
                1,
                needs_card_scan=True,
                needs_fusion_ui_scan=False,
            )
        )
        self.assertTrue(
            _first_session_ui_scan_required(
                1,
                needs_card_scan=False,
                needs_fusion_ui_scan=True,
            )
        )
        self.assertFalse(
            _first_session_ui_scan_required(
                2,
                needs_card_scan=True,
                needs_fusion_ui_scan=True,
            )
        )

    def test_pristine_first_turn_prioritizes_match_start_before_heap_scans(self) -> None:
        self.assertTrue(
            _match_start_opening_has_priority(
                opening_snapshot_available=False,
                turn=1,
                local_move_sequence=0,
                last_move_sequence=None,
            )
        )
        self.assertFalse(
            _match_start_opening_has_priority(
                opening_snapshot_available=True,
                turn=1,
                local_move_sequence=0,
                last_move_sequence=None,
            )
        )

    def test_pristine_local_opening_defers_optional_ui_discovery(self) -> None:
        self.assertTrue(
            _opening_board_action_has_priority(
                is_local_turn=True,
                turn=1,
                local_move_sequence=0,
                last_move_sequence=None,
            )
        )
        self.assertFalse(
            _opening_board_action_has_priority(
                is_local_turn=False,
                turn=1,
                local_move_sequence=0,
                last_move_sequence=None,
            )
        )
        self.assertFalse(
            _opening_board_action_has_priority(
                is_local_turn=True,
                turn=3,
                local_move_sequence=0,
                last_move_sequence=None,
            )
        )
        self.assertFalse(
            _opening_board_action_has_priority(
                is_local_turn=True,
                turn=1,
                local_move_sequence=1,
                last_move_sequence=1,
            )
        )
        self.assertFalse(
            _match_start_opening_has_priority(
                opening_snapshot_available=False,
                turn=3,
                local_move_sequence=0,
                last_move_sequence=None,
            )
        )

    def test_extended_card_scan_is_skipped_when_normal_scan_found_attack(self) -> None:
        attack = SimpleNamespace(is_attack=True)
        mana = SimpleNamespace(is_attack=False)
        self.assertFalse(_extended_card_scan_still_needed(True, (mana, attack)))
        self.assertTrue(_extended_card_scan_still_needed(True, (mana,)))
        self.assertFalse(_extended_card_scan_still_needed(False, ()))

    def test_new_session_drops_only_volatile_learned_regions(self) -> None:
        learned = {
            "batch": {"old_batch_region"},
            "card_ui": {"old_card_region"},
            "fusion_ui": {"old_fusion_region"},
            "board_ws": {"stable_owner_hint"},
        }

        _drop_session_volatile_learned_regions(learned)

        self.assertEqual(learned, {"board_ws": {"stable_owner_hint"}})


class LobbyBaselineTests(unittest.TestCase):
    @staticmethod
    def _provider(*, batch_class, board_ws_class):
        provider = MemoryBoardStateProvider.__new__(MemoryBoardStateProvider)
        provider._batch_class = batch_class
        provider._board_ws_class = board_ws_class
        provider._lobby_batch_baseline = set()
        provider._lobby_baseline_ready = False
        provider._needs_lobby_baseline = True
        provider.metrics = ProviderMetrics()
        provider.target = SimpleNamespace(memory=object())
        provider._scan = Mock(
            return_value=SimpleNamespace(matches={"batch": (0x2000,)})
        )
        return provider

    def test_batch_type_alone_is_enough_for_lobby_fingerprint(self) -> None:
        provider = self._provider(batch_class=0x1000, board_ws_class=None)
        batch = object()
        identity = (0x2000, 7, "hash")

        with (
            patch(
                "pokiguard_v2.memory_board_provider.validate_combat_batch_hits",
                return_value=(batch,),
            ),
            patch(
                "pokiguard_v2.memory_board_provider.batch_identity",
                return_value=identity,
            ),
        ):
            self.assertTrue(provider._refresh_lobby_baseline())

        provider._scan.assert_called_once_with(
            {"batch": 0x1000}, force_full=True
        )
        self.assertEqual(provider._lobby_batch_baseline, {identity})
        self.assertTrue(provider._lobby_baseline_ready)
        self.assertFalse(provider._needs_lobby_baseline)

    def test_clean_process_without_combat_types_has_empty_ready_baseline(self) -> None:
        provider = self._provider(batch_class=None, board_ws_class=None)

        self.assertTrue(provider._refresh_lobby_baseline())

        provider._scan.assert_not_called()
        self.assertEqual(provider._lobby_batch_baseline, set())
        self.assertTrue(provider._lobby_baseline_ready)

    def test_board_ws_type_alone_still_has_empty_ready_baseline(self) -> None:
        provider = self._provider(batch_class=None, board_ws_class=0x3000)

        self.assertTrue(provider._refresh_lobby_baseline())

        provider._scan.assert_not_called()
        self.assertEqual(provider._lobby_batch_baseline, set())
        self.assertTrue(provider._lobby_baseline_ready)
        self.assertFalse(provider._needs_lobby_baseline)


class CombatTypeInfoGateTests(unittest.TestCase):
    def test_match_start_can_bootstrap_before_batch_type_initializes(self) -> None:
        self.assertIsNone(
            _combat_type_info_blocker(
                batch_class=None,
                board_ws_class=0x3000,
                opening_snapshot_available=True,
            )
        )

    def test_missing_batch_without_opening_snapshot_fails_closed(self) -> None:
        self.assertEqual(
            _combat_type_info_blocker(
                batch_class=None,
                board_ws_class=0x3000,
                opening_snapshot_available=False,
            ),
            "combat_batch_type_info_not_initialized",
        )

    def test_missing_board_ws_always_fails_closed(self) -> None:
        self.assertEqual(
            _combat_type_info_blocker(
                batch_class=0x2000,
                board_ws_class=None,
                opening_snapshot_available=True,
            ),
            "board_ws_type_info_not_initialized",
        )


class PresentationIdleGateTests(unittest.TestCase):
    def test_clean_opening_can_use_durable_match_service_idle(self) -> None:
        self.assertTrue(
            _presentation_idle_for_publication(
                opening_authoritative=True,
                owner_idle=False,
                pending_before=None,
                pending_after=None,
                in_flight_before=0,
                in_flight_after=0,
            )
        )

    def test_non_opening_still_requires_validated_owner(self) -> None:
        self.assertFalse(
            _presentation_idle_for_publication(
                opening_authoritative=False,
                owner_idle=False,
                pending_before=None,
                pending_after=None,
                in_flight_before=0,
                in_flight_after=0,
            )
        )

    def test_opening_pending_or_in_flight_fails_closed(self) -> None:
        cases = (
            (0x2000, None, 0, 0),
            (None, 0x2000, 0, 0),
            (None, None, 1, 0),
            (None, None, 0, 1),
            (None, None, 0, None),
        )
        for pending_before, pending_after, before, after in cases:
            with self.subTest(
                pending_before=pending_before,
                pending_after=pending_after,
                in_flight_before=before,
                in_flight_after=after,
            ):
                self.assertFalse(
                    _presentation_idle_for_publication(
                        opening_authoritative=True,
                        owner_idle=False,
                        pending_before=pending_before,
                        pending_after=pending_after,
                        in_flight_before=before,
                        in_flight_after=after,
                    )
                )

    def test_validated_owner_remains_sufficient(self) -> None:
        self.assertTrue(
            _presentation_idle_for_publication(
                opening_authoritative=False,
                owner_idle=True,
                pending_before=None,
                pending_after=None,
                in_flight_before=0,
                in_flight_after=0,
            )
        )


class OwnerAckPromotionTests(unittest.TestCase):
    def test_only_current_owner_capture_with_exact_ack_is_promoted(self) -> None:
        owned = (0x2000, 5, "owned")
        unowned = (0x3000, 5, "unowned")
        unacked = (0x4000, 7, "unacked")
        stale_owner = (0x5000, 5, "not-tracked")
        tracked = {owned: object(), unowned: object(), unacked: object()}

        promoted = _owner_batches_confirmed_by_ack(
            tracked, {owned, unacked, stale_owner}, {5}
        )

        self.assertEqual(promoted, {owned})

    def test_no_ack_never_promotes_owner_capture(self) -> None:
        owned = (0x2000, 5, "owned")
        self.assertEqual(
            _owner_batches_confirmed_by_ack({owned: object()}, {owned}, set()),
            set(),
        )

    def test_transport_capture_also_requires_exact_ack_sequence(self) -> None:
        move_response = (0x2200, 9, "transport")
        tracked = {move_response: object()}

        self.assertEqual(
            _owner_batches_confirmed_by_ack(
                tracked, {move_response}, {7}
            ),
            set(),
        )
        self.assertEqual(
            _owner_batches_confirmed_by_ack(
                tracked, {move_response}, {7, 9}
            ),
            {move_response},
        )

    def test_conflicting_heap_hashes_require_one_owner_attested_hash(self) -> None:
        heap_only = (0x2000, 15, "heap")
        owned = (0x3000, 15, "owned")

        self.assertIsNone(
            _select_latest_identity([heap_only, owned], set())
        )
        self.assertEqual(
            _select_latest_identity([heap_only, owned], {owned}),
            owned,
        )

    def test_conflicting_owner_hashes_still_fail_closed(self) -> None:
        first = (0x2000, 15, "first")
        second = (0x3000, 15, "second")

        self.assertIsNone(
            _select_latest_identity([first, second], {first, second})
        )

    def test_direct_owner_gets_bounded_capture_window_before_heap_scan(self) -> None:
        sequence = None
        polls = 0
        for expected in range(1, 2):
            sequence, polls, defer = _next_direct_owner_grace(
                acked_highest=15,
                have_highest=False,
                valid_owner_count=1,
                previous_sequence=sequence,
                previous_polls=polls,
            )
            self.assertTrue(defer)
            self.assertEqual(polls, expected)
        _sequence, polls, defer = _next_direct_owner_grace(
            acked_highest=15,
            have_highest=False,
            valid_owner_count=1,
            previous_sequence=sequence,
            previous_polls=polls,
        )
        self.assertFalse(defer)
        self.assertEqual(polls, 2)

    def test_learned_ack_scan_miss_escalates_full_in_same_poll(self) -> None:
        old = (0x2000, 60, "old")
        self.assertTrue(
            _needs_immediate_full_ack_rescan(
                acked_highest=62,
                ack_attested={old},
                prior_scan_was_full=False,
            )
        )
        self.assertFalse(
            _needs_immediate_full_ack_rescan(
                acked_highest=62,
                ack_attested={old, (0x3000, 62, "current")},
                prior_scan_was_full=False,
            )
        )
        self.assertFalse(
            _needs_immediate_full_ack_rescan(
                acked_highest=62,
                ack_attested={old},
                prior_scan_was_full=True,
            )
        )


class NonBoardFusionTransitionTests(unittest.TestCase):
    @staticmethod
    def _action(*, local_sequence: int = 2) -> ActionRuntimeSignals:
        return ActionRuntimeSignals(
            local_username="happi",
            connection_ready=True,
            reconnecting=False,
            match_over=False,
            deferred_game_over=False,
            match_resyncing=False,
            in_flight_batches=0,
            clock_paused=False,
            clock_pause_reason=None,
            start_gate_paused=False,
            local_move_sequence=local_sequence,
            last_move_from_col=4,
            last_move_from_row=7,
            last_move_to_col=5,
            last_move_to_row=7,
            last_move_sequence=local_sequence,
        )

    @staticmethod
    def _canonical(
        *, used: bool, turn: int, last_attempt_turn: int | None = None
    ) -> FusionState:
        return FusionState(
            enabled=True,
            available=not used,
            used=used,
            locked_this_turn=not used,
            last_attempt_turn=(
                last_attempt_turn
                if last_attempt_turn is not None
                else (turn if used else -1)
            ),
            mana_cost=160,
        )

    @staticmethod
    def _memory(*, used: bool, turn: int, last_attempt_turn: int | None = None):
        return SimpleNamespace(
            used_successfully=used,
            last_attempt_turn=(
                last_attempt_turn
                if last_attempt_turn is not None
                else (turn if used else -1)
            ),
        )

    def test_exact_same_turn_fusion_ack_can_retain_unchanged_board(self) -> None:
        dots = tuple(range(64))

        sequence = _durable_non_board_fusion_transition(
            acked_highest=16,
            last_accepted_sequence=11,
            last_accepted_turn=5,
            current_turn=5,
            last_local_move_sequence=2,
            action=self._action(),
            previous_fusion=self._canonical(used=False, turn=5),
            current_fusion=self._memory(used=True, turn=5),
            last_all_dots=dots,
            current_all_dots=dots,
            pending_batch=None,
            current_turn_player="happi",
        )

        self.assertEqual(sequence, 16)

    def test_exact_failed_fusion_ack_can_retain_unchanged_board(self) -> None:
        dots = tuple(range(64))

        sequence = _durable_non_board_fusion_transition(
            acked_highest=33,
            last_accepted_sequence=31,
            last_accepted_turn=15,
            current_turn=15,
            last_local_move_sequence=7,
            action=self._action(local_sequence=7),
            previous_fusion=self._canonical(
                used=False, turn=15, last_attempt_turn=-1
            ),
            current_fusion=self._memory(
                used=False, turn=15, last_attempt_turn=15
            ),
            last_all_dots=dots,
            current_all_dots=dots,
            pending_batch=None,
            current_turn_player="happi",
        )

        self.assertEqual(sequence, 33)

    def test_same_failed_fusion_attempt_is_not_a_new_transition(self) -> None:
        dots = tuple(range(64))

        sequence = _durable_non_board_fusion_transition(
            acked_highest=33,
            last_accepted_sequence=31,
            last_accepted_turn=15,
            current_turn=15,
            last_local_move_sequence=7,
            action=self._action(local_sequence=7),
            previous_fusion=self._canonical(
                used=False, turn=15, last_attempt_turn=15
            ),
            current_fusion=self._memory(
                used=False, turn=15, last_attempt_turn=15
            ),
            last_all_dots=dots,
            current_all_dots=dots,
            pending_batch=None,
            current_turn_player="happi",
        )

        self.assertIsNone(sequence)

    def test_board_or_move_change_rejects_non_board_fusion_path(self) -> None:
        dots = tuple(range(64))
        common = dict(
            acked_highest=16,
            last_accepted_sequence=11,
            last_accepted_turn=5,
            current_turn=5,
            last_local_move_sequence=2,
            previous_fusion=self._canonical(used=False, turn=5),
            current_fusion=self._memory(used=True, turn=5),
            last_all_dots=dots,
            pending_batch=None,
            current_turn_player="happi",
        )
        changed = dots[:-1] + (999,)

        self.assertIsNone(
            _durable_non_board_fusion_transition(
                **common,
                action=self._action(),
                current_all_dots=changed,
            )
        )
        self.assertIsNone(
            _durable_non_board_fusion_transition(
                **common,
                action=self._action(local_sequence=3),
                current_all_dots=dots,
            )
        )

    def test_retained_fusion_board_keeps_ack_provenance_actionable(self) -> None:
        state = combat_state(fusion_used=True)
        battle = state.battle
        session = SimpleNamespace(
            lifecycle_epoch=1,
            board_instance=battle.board_instance,
            match_id="M_fixture",
        )
        from pokiguard_v2.state import CombatSessionKey

        session = CombatSessionKey(
            session.lifecycle_epoch,
            session.board_instance,
            session.match_id,
        )
        state = replace(
            state,
            battle=replace(
                battle,
                session_key=session,
                match_id=session.match_id,
                acknowledged=True,
                latest=True,
                board_hash="a" * 64,
                sources=(
                    "MatchService._ackedSeqs+postLobbyHeap",
                    "MatchService.LocalFusionUsed+unchanged_Board.allDots",
                ),
                connection_ready=True,
                reconnecting=False,
                match_resyncing=False,
                board_is_game_over=False,
                match_over=False,
                deferred_game_over=False,
                board_modal_open=False,
                board_is_resuming=False,
                clock_paused=False,
                start_gate_paused=False,
                presentation_busy=False,
                local_username="happi",
                is_local_turn=True,
                client_move_allowed=True,
                is_board_ready=True,
                is_cascade_running=False,
                board_current_state=1,
                board_has_destroyed_this_turn=False,
                board_is_processing_ui=False,
            ),
        )

        result = ActionabilityGate.evaluate(
            state,
            GateContext(session, True, True),
        )

        self.assertTrue(result.actionable, result)


class LastMoveTransitionTests(unittest.TestCase):
    def test_prior_match_last_move_becomes_unknown_during_new_match_reset(self) -> None:
        sequence, coordinates = _normalize_last_move_telemetry(
            0, 6, (5, 5, 5, 4)
        )

        self.assertIsNone(sequence)
        self.assertEqual(coordinates, (None, None, None, None))

    def test_current_last_move_is_preserved_exactly(self) -> None:
        sequence, coordinates = _normalize_last_move_telemetry(
            6, 6, (5, 5, 5, 4)
        )

        self.assertEqual(sequence, 6)
        self.assertEqual(coordinates, (5, 5, 5, 4))

    def test_invalid_coordinates_become_unknown(self) -> None:
        sequence, coordinates = _normalize_last_move_telemetry(
            6, 6, (8, 5, 5, 4)
        )

        self.assertIsNone(sequence)
        self.assertEqual(coordinates, (None, None, None, None))


if __name__ == "__main__":
    unittest.main()
