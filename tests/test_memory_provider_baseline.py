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
    _fusion_ui_discovery_expected,
    _first_session_ui_scan_required,
    _extended_card_scan_still_needed,
    _match_start_opening_has_priority,
    _opening_board_action_has_priority,
    _opponent_ui_warmup_required,
    _normalize_last_move_telemetry,
    _needs_immediate_full_ack_rescan,
    _next_direct_owner_grace,
    _owner_batches_confirmed_by_ack,
    _presentation_idle_for_publication,
    _region_size_band,
    _regions_with_address_neighbors,
    _recovered_ack_epoch_view,
    _rotating_region_byte_window,
    _rotating_region_window,
    _select_latest_identity,
)
from pokiguard_v2.actionability import ActionabilityGate, GateContext
from pokiguard_v2.state import CombatSessionKey, FusionState
from pokiguard_v2.il2cpp_external import MemoryRegion
from pokiguard_v2.il2cpp_layout import BoardCellSnapshot, CombatBatchSnapshot
from pokiguard_v2.state import ParticipantState
from tests.test_basic_policy import combat_state


class ExtendedFusionUiScanTests(unittest.TestCase):
    @staticmethod
    def _complete_batch(sequence: int = 7) -> CombatBatchSnapshot:
        cells = tuple(
            BoardCellSnapshot(
                0x500000 + row * 8 + col,
                col,
                row,
                0x600000,
                "vang Dot",
                1,
            )
            for row in range(8)
            for col in range(8)
        )
        return CombatBatchSnapshot(0x400000, sequence, 0x700000, cells)

    def test_runtime_monitor_batch_still_requires_exact_provider_ack(self) -> None:
        provider = MemoryBoardStateProvider.__new__(MemoryBoardStateProvider)
        provider._session_key = CombatSessionKey(1, 0x100000, "M_fixture")
        provider._session_batch_baseline = set()
        provider._tracked = {}
        provider._sources = {}
        provider._runtime_heap_attested = set()

        batch = self._complete_batch()
        self.assertTrue(provider.offer_runtime_heap_batch(batch))
        identity = next(iter(provider._runtime_heap_attested))
        self.assertEqual(identity[1], 7)
        self.assertIn("RuntimeSequenceMonitor.WsCombatBatch", provider._sources[identity])

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

    def test_extended_scan_rotates_bounded_regions_and_prefers_last_hit(self) -> None:
        regions = tuple(
            MemoryRegion(index * 0x1000000, 12 * 1024 * 1024, 0x04, 0x20000)
            for index in range(6)
        )

        selected, cursor = _rotating_region_window(
            regions,
            cursor=1,
            preferred_base=None,
        )
        self.assertEqual(tuple(region.base for region in selected), tuple(region.base for region in regions[1:5]))
        self.assertEqual(cursor, 5)

        preferred, cursor = _rotating_region_window(
            regions,
            cursor=2,
            preferred_base=regions[5].base,
        )
        self.assertEqual(preferred, (regions[5],))
        self.assertEqual(cursor, 0)

    def test_ack_heap_scan_expands_neighbors_and_rotates_by_byte_budget(self) -> None:
        regions = tuple(
            MemoryRegion(index * 0x1000000, 8 * 1024 * 1024, 0x04, 0x20000)
            for index in range(6)
        )
        neighbors = _regions_with_address_neighbors(
            regions,
            (regions[3],),
        )
        self.assertEqual(neighbors, regions[2:5])

        first, cursor = _rotating_region_byte_window(
            regions,
            cursor=0,
            max_bytes=16 * 1024 * 1024,
            max_regions=6,
        )
        self.assertEqual(first, regions[:2])
        self.assertEqual(cursor, 2)
        second, cursor = _rotating_region_byte_window(
            regions,
            cursor=cursor,
            max_bytes=16 * 1024 * 1024,
            max_regions=6,
        )
        self.assertEqual(second, regions[2:4])
        self.assertEqual(cursor, 4)

    def test_ack_heap_full_fallback_is_bounded_to_two_large_regions(self) -> None:
        regions = tuple(
            MemoryRegion(index * 0x2000000, 16 * 1024 * 1024, 0x04, 0x20000)
            for index in range(6)
        )
        provider = MemoryBoardStateProvider.__new__(MemoryBoardStateProvider)
        provider.config = MemoryProviderConfig(
            max_region_mib=8,
            ack_heap_region_mib=16,
        )
        provider.target = SimpleNamespace(
            memory=SimpleNamespace(iter_readable_regions=lambda: iter(regions))
        )
        provider._batch_class = 0x1234
        provider._learned_regions = {}
        provider._ack_heap_region_cursor = 0
        provider._last_ack_heap_fallback_bounded = False
        provider.metrics = ProviderMetrics()

        with patch(
            "pokiguard_v2.memory_board_provider.scan_aligned_qwords",
            return_value=SimpleNamespace(matches={"batch": ()}, bytes_read=0),
        ) as scan:
            provider._scan_ack_heap(force_full=True)

        selected = scan.call_args.args[1]
        self.assertEqual(selected, regions[:2])
        self.assertLessEqual(sum(region.size for region in selected), 32 * 1024 * 1024)
        self.assertEqual(provider._ack_heap_region_cursor, 2)
        self.assertTrue(provider._last_ack_heap_fallback_bounded)

    def test_ack_heap_fallback_includes_current_session_owner_anchor(self) -> None:
        regions = tuple(
            MemoryRegion(index * 0x1000000, 8 * 1024 * 1024, 0x04, 0x20000)
            for index in range(6)
        )
        provider = MemoryBoardStateProvider.__new__(MemoryBoardStateProvider)
        provider.config = MemoryProviderConfig(
            max_region_mib=8,
            ack_heap_region_mib=16,
        )
        provider.target = SimpleNamespace(
            memory=SimpleNamespace(iter_readable_regions=lambda: iter(regions))
        )
        provider._batch_class = 0x1234
        provider._learned_regions = {}
        provider._ack_heap_region_cursor = 0
        provider._last_ack_heap_fallback_bounded = False
        provider._fusion_ui_addresses = {regions[5].base + 0x100}
        provider._card_addresses = set()
        provider._board_ws_addresses = set()
        provider.metrics = ProviderMetrics()

        with patch(
            "pokiguard_v2.memory_board_provider.scan_aligned_qwords",
            return_value=SimpleNamespace(matches={"batch": ()}, bytes_read=0),
        ) as scan:
            provider._scan_ack_heap(force_full=True)

        selected = scan.call_args.args[1]
        self.assertIn(regions[5], selected)
        self.assertIn(regions[4], selected)
        self.assertEqual(provider._ack_heap_region_cursor, 4)

    def test_ack_heap_fallback_uses_validated_dot_anchor_when_ui_is_absent(self) -> None:
        regions = tuple(
            MemoryRegion(index * 0x1000000, 8 * 1024 * 1024, 0x04, 0x20000)
            for index in range(6)
        )
        provider = MemoryBoardStateProvider.__new__(MemoryBoardStateProvider)
        provider.config = MemoryProviderConfig(
            max_region_mib=8,
            ack_heap_region_mib=16,
        )
        provider.target = SimpleNamespace(
            memory=SimpleNamespace(iter_readable_regions=lambda: iter(regions))
        )
        provider._batch_class = 0x1234
        provider._learned_regions = {}
        provider._ack_heap_region_cursor = 0
        provider._last_ack_heap_fallback_bounded = False
        provider._fusion_ui_addresses = set()
        provider._card_addresses = set()
        provider._board_ws_addresses = set()
        provider._dot_pointer_hits = {regions[5].base + 0x100}
        provider.metrics = ProviderMetrics()

        with patch(
            "pokiguard_v2.memory_board_provider.scan_aligned_qwords",
            return_value=SimpleNamespace(matches={"batch": ()}, bytes_read=0),
        ) as scan:
            provider._scan_ack_heap(force_full=True)

        selected = scan.call_args.args[1]
        self.assertIn(regions[5], selected)
        self.assertIn(regions[4], selected)

    def test_extended_fusion_scan_enforces_total_byte_budget(self) -> None:
        regions = tuple(
            MemoryRegion(index * 0x2000000, 12 * 1024 * 1024, 0x04, 0x20000)
            for index in range(4)
        )
        provider = MemoryBoardStateProvider.__new__(MemoryBoardStateProvider)
        provider.config = MemoryProviderConfig(
            max_region_mib=8,
            extended_fusion_ui_region_mib=16,
        )
        provider.target = SimpleNamespace(
            memory=SimpleNamespace(iter_readable_regions=lambda: iter(regions))
        )
        provider._fusion_ui_class = 0x1234
        provider._extended_fusion_region_cursor = 0
        provider._extended_fusion_region_hint_base = None
        provider._last_extended_fusion_regions = ()
        provider.metrics = ProviderMetrics()

        with patch(
            "pokiguard_v2.memory_board_provider.scan_aligned_qwords",
            return_value=SimpleNamespace(matches={"fusion_ui": ()}, bytes_read=0),
        ) as scan:
            provider._scan_extended_fusion_ui()

        selected = scan.call_args.args[1]
        self.assertEqual(selected, (regions[0],))
        self.assertLessEqual(
            sum(region.size for region in selected),
            16 * 1024 * 1024,
        )

    def test_cards_in_hand_anchor_scans_fusion_class_in_owned_regions(self) -> None:
        regions = (
            MemoryRegion(0x200000, 0x70000, 0x04, 0x20000),
            MemoryRegion(0x300000, 0x40000, 0x04, 0x20000),
        )
        provider = MemoryBoardStateProvider.__new__(MemoryBoardStateProvider)
        provider.config = MemoryProviderConfig()
        provider.target = SimpleNamespace(memory=object())
        provider.metrics = ProviderMetrics()
        provider._owned_anchor_regions = Mock(return_value=regions)
        result = SimpleNamespace(matches={"fusion_ui": (0x234000,)}, bytes_read=1)

        with (
            patch(
                "pokiguard_v2.memory_board_provider.read_cards_in_hand_anchors",
                return_value=(0x210000, 0x310000),
            ) as read_anchors,
            patch(
                "pokiguard_v2.memory_board_provider.scan_aligned_qwords",
                return_value=result,
            ) as scan,
        ):
            objects, selected, actual = provider._scan_cards_in_hand_regions(
                0x123000,
                {"fusion_ui": 0x456000},
            )

        self.assertEqual(objects, (0x210000, 0x310000))
        self.assertEqual(selected, regions)
        self.assertIs(actual, result)
        read_anchors.assert_called_once_with(provider.target.memory, 0x123000)
        provider._owned_anchor_regions.assert_called_once_with(
            {0x210000, 0x310000}
        )
        scan.assert_called_once_with(
            provider.target.memory,
            regions,
            {"fusion_ui": 0x456000},
            chunk_size=2 * 1024 * 1024,
        )
        self.assertEqual(provider.metrics.memory_scans, 1)

    def test_extended_fusion_scan_discovers_on_boss_turn_before_mana(self) -> None:
        fusion = SimpleNamespace(
            candidate_available=True,
            # Game-owned FusionEnabled may remain false before affordability;
            # it must not postpone current-session UI discovery.
            enabled=False,
            used_successfully=False,
            skill_card=0x123456,
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
                turn_time_remaining_seconds=13,
            )
        )
        self.assertTrue(
            _extended_fusion_scan_relevant(
                fusion,
                short,
                is_local_turn=False,
                turn=4,
                last_scanned_turn=None,
                turn_time_remaining_seconds=1,
            )
        )
        self.assertFalse(
            _extended_fusion_scan_relevant(
                fusion,
                enough,
                is_local_turn=True,
                turn=5,
                last_scanned_turn=4,
                turn_time_remaining_seconds=13,
            )
        )


        self.assertFalse(
            _extended_fusion_scan_relevant(
                fusion,
                short,
                is_local_turn=True,
                turn=5,
                last_scanned_turn=3,
                turn_time_remaining_seconds=13,
            )
        )
        self.assertTrue(
            _extended_fusion_scan_relevant(
                fusion,
                enough,
                is_local_turn=False,
                turn=5,
                last_scanned_turn=3,
                turn_time_remaining_seconds=13,
            )
        )
        self.assertFalse(
            _extended_fusion_scan_relevant(
                fusion,
                enough,
                is_local_turn=True,
                turn=5,
                last_scanned_turn=5,
                turn_time_remaining_seconds=13,
            )
        )
        self.assertFalse(
            _extended_fusion_scan_relevant(
                SimpleNamespace(
                    candidate_available=True,
                    enabled=True,
                    used_successfully=False,
                    skill_card=0x123456,
                    mana_cost=160,
                    selected_user_pet_id=0,
                    selected_pet_id=0,
                ),
                enough,
                is_local_turn=True,
                turn=5,
                last_scanned_turn=3,
                turn_time_remaining_seconds=13,
            )
        )

        self.assertFalse(
            _extended_fusion_scan_relevant(
                fusion,
                enough,
                is_local_turn=True,
                turn=5,
                last_scanned_turn=3,
                turn_time_remaining_seconds=12,
            )
        )

        # These fields gate EVOLVE input, not discovery of the persistent UI.
        action_blocked = SimpleNamespace(
            candidate_available=False,
            enabled=False,
            used_successfully=True,
            skill_card=None,
            mana_cost=0,
            selected_user_pet_id=218166,
            selected_pet_id=1289,
        )
        self.assertTrue(_fusion_ui_discovery_expected(action_blocked))
        self.assertTrue(
            _extended_fusion_scan_relevant(
                action_blocked,
                short,
                is_local_turn=False,
                turn=4,
                last_scanned_turn=None,
                turn_time_remaining_seconds=1,
            )
        )
        self.assertFalse(
            _fusion_ui_discovery_expected(
                SimpleNamespace(
                    selected_user_pet_id=0,
                    selected_pet_id=0,
                )
            )
        )

    def test_ui_warmup_is_first_boss_turn_and_not_mana_gated(self) -> None:
        self.assertTrue(
            _opponent_ui_warmup_required(
                completed=False,
                opening_board_action_priority=False,
                is_local_turn=False,
                turn=2,
                optional_card_action_expected=True,
            )
        )
        self.assertFalse(
            _opponent_ui_warmup_required(
                completed=False,
                opening_board_action_priority=True,
                is_local_turn=True,
                turn=1,
                optional_card_action_expected=True,
            )
        )
        self.assertFalse(
            _opponent_ui_warmup_required(
                completed=True,
                opening_board_action_priority=False,
                is_local_turn=False,
                turn=4,
                optional_card_action_expected=True,
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
                turn_time_remaining_seconds=13,
            )
        )
        self.assertFalse(
            _extended_card_scan_relevant(
                no_mana,
                is_local_turn=True,
                turn=3,
                last_scanned_turn=1,
                attempts=1,
                turn_time_remaining_seconds=13,
            )
        )
        self.assertTrue(
            _extended_card_scan_relevant(
                has_mana,
                is_local_turn=True,
                turn=3,
                last_scanned_turn=1,
                attempts=1,
                turn_time_remaining_seconds=13,
            )
        )
        self.assertFalse(
            _extended_card_scan_relevant(
                has_mana,
                is_local_turn=True,
                turn=3,
                last_scanned_turn=2,
                attempts=1,
                turn_time_remaining_seconds=13,
            )
        )
        self.assertTrue(
            _extended_card_scan_relevant(
                has_mana,
                is_local_turn=False,
                turn=4,
                last_scanned_turn=3,
                attempts=2,
                turn_time_remaining_seconds=1,
            )
        )
        self.assertFalse(
            _extended_card_scan_relevant(
                has_mana,
                is_local_turn=True,
                turn=9,
                last_scanned_turn=7,
                attempts=4,
                turn_time_remaining_seconds=13,
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

    def test_transport_hints_include_dto_and_batch_regions(self) -> None:
        dto = MemoryRegion(0x1000, 0x1000, 0x04, 0x20000)
        batch = MemoryRegion(0x4000, 0x2000, 0x04, 0x20000)
        unrelated = MemoryRegion(0x9000, 0x1000, 0x04, 0x20000)
        provider = MemoryBoardStateProvider.__new__(MemoryBoardStateProvider)
        provider._learned_regions = {
            "chat_message": {dto},
            "batch": {batch},
            "card_ui": {unrelated},
        }

        self.assertEqual(provider.transport_region_hints, (dto, batch))


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

    def test_transport_identity_outranks_conflicting_unbound_runtime_heap(self) -> None:
        transport = (0x2000, 71, "current-match")
        stale_runtime_heap = (0x3000, 71, "retained-old-match")

        self.assertEqual(
            _select_latest_identity(
                [transport, stale_runtime_heap],
                {transport},
            ),
            transport,
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


class LifecycleAckGaugeTests(unittest.TestCase):
    @staticmethod
    def provider() -> MemoryBoardStateProvider:
        target = SimpleNamespace(
            resolver=SimpleNamespace(resolve_type_info_class=lambda _rva: None)
        )
        with (
            patch.object(MemoryBoardStateProvider, "_resolve_board", return_value=None),
            patch.object(
                MemoryBoardStateProvider,
                "_refresh_lobby_baseline",
                return_value=True,
            ),
        ):
            return MemoryBoardStateProvider(target)

    def test_new_lifecycle_clears_prior_session_ack_gauge(self) -> None:
        provider = self.provider()
        provider.metrics.highest_acked_sequence = 43
        session = CombatSessionKey(5, 0x20000000000, "M_new")

        provider._reset_lifecycle(
            session.board_instance,
            session.match_id,
            session,
        )

        self.assertIsNone(provider.metrics.highest_acked_sequence)

    def test_cleared_lifecycle_clears_prior_session_ack_gauge(self) -> None:
        provider = self.provider()
        provider.metrics.highest_acked_sequence = 43

        provider._clear_lifecycle()

        self.assertIsNone(provider.metrics.highest_acked_sequence)

    def test_frozen_recovery_ack_uses_only_current_session_attestation(self) -> None:
        effective, isolated, reason = _recovered_ack_epoch_view(
            raw_highest=53,
            stale_baseline_highest=53,
            current_session_sequences={3, 7},
        )

        self.assertEqual(effective, 7)
        self.assertTrue(isolated)
        self.assertIsNone(reason)

    def test_unexplained_recovery_ack_advance_fails_closed(self) -> None:
        effective, isolated, reason = _recovered_ack_epoch_view(
            raw_highest=54,
            stale_baseline_highest=53,
            current_session_sequences={7},
        )

        self.assertIsNone(effective)
        self.assertTrue(isolated)
        self.assertEqual(
            reason,
            "recovery_ack_epoch_advanced_without_current_session_evidence",
        )

    def test_current_session_ack_beyond_baseline_returns_to_normal_mode(self) -> None:
        effective, isolated, reason = _recovered_ack_epoch_view(
            raw_highest=54,
            stale_baseline_highest=53,
            current_session_sequences={54},
        )

        self.assertEqual(effective, 54)
        self.assertFalse(isolated)
        self.assertIsNone(reason)

    def test_recovery_ack_scope_is_consumed_by_exactly_next_lifecycle(self) -> None:
        provider = self.provider()
        self.assertTrue(
            provider.arm_recovery_ack_epoch_isolation(
                stale_highest=53,
                stale_local_move_sequence=7,
            )
        )
        session = CombatSessionKey(6, 0x20000001000, "M_recovered")

        provider._reset_lifecycle(
            session.board_instance,
            session.match_id,
            session,
        )
        provider._recovery_ack_isolated = True

        self.assertTrue(provider.recovery_ack_epoch_isolated_for(session))
        self.assertEqual(provider._recovery_ack_baseline_highest, 53)
        self.assertIsNone(provider._pending_recovery_ack_baseline)
        provider._clear_lifecycle()
        self.assertFalse(provider.recovery_ack_epoch_isolated_for(session))


if __name__ == "__main__":
    unittest.main()
