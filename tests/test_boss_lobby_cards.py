from __future__ import annotations

import struct
from pathlib import Path
import sys
from types import SimpleNamespace
import unittest
from unittest.mock import patch


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
if str(SRC_ROOT) not in sys.path:
    sys.path.insert(0, str(SRC_ROOT))

from pokiguard_v2.boss_lobby_runtime import (  # noqa: E402
    MANAGER_ROOM_SELECTED_CARDS_OFFSET,
    ROOM_COOP_V2_REFS_BUTTON_START_OFFSET,
    ROOM_COOP_V2_REFS_OFFSET,
    ROOM_COOP_V2_START_STATE_OFFSET,
    ROOM_START_MY_READY_OFFSET,
    ROOM_START_PHASE_OFFSET,
    ROOM_CARDS_OFFSET,
    RoomStartPhase,
    _hub_surface_flags,
    _read_lobby_card_loadout,
    _read_room_start_state,
    _static_instance,
    read_boss_lobby_runtime,
)
from pokiguard_v2.boss_entry import BossLobbyState  # noqa: E402
from pokiguard_v2.combat_lifecycle import (  # noqa: E402
    CombatLifecycleObservation,
    CombatLifecycleSignals,
    CombatLifecycleState,
)
import pokiguard_v2.boss_lobby_runtime as lobby_runtime_module  # noqa: E402


class FakeMemory:
    def __init__(self) -> None:
        self.bytes: dict[int, int] = {}

    def map(self, address: int, data: bytes | bytearray) -> None:
        self.bytes.update({address + index: value for index, value in enumerate(data)})

    def read(self, address: int, size: int) -> bytes:
        return bytes(self.bytes[address + index] for index in range(size))

    def is_readable(self, address: int, size: int) -> bool:
        return size > 0 and all(address + index in self.bytes for index in range(size))


class FakeResolver:
    def __init__(self, memory: FakeMemory) -> None:
        self.memory = memory

    def read_pointer(self, address: int) -> int:
        return struct.unpack("<Q", self.memory.read(address, 8))[0]

    def read_i32(self, address: int) -> int:
        return struct.unpack("<i", self.memory.read(address, 4))[0]

    def read_bool(self, address: int) -> bool:
        return bool(self.memory.read(address, 1)[0])


def map_string(memory: FakeMemory, address: int, value: str, klass: int) -> None:
    raw = bytearray(0x14 + len(value) * 2)
    struct.pack_into("<Q", raw, 0, klass)
    struct.pack_into("<i", raw, 0x10, len(value))
    raw[0x14:] = value.encode("utf-16-le")
    memory.map(address, raw)


def map_card_data(
    memory: FakeMemory,
    address: int,
    *,
    klass: int,
    string_klass: int,
    data_id: int,
    card_id: int,
    name: str,
    element_type: str,
) -> None:
    name_address = address + 0x1000
    element_address = address + 0x2000
    map_string(memory, name_address, name, string_klass)
    map_string(memory, element_address, element_type, string_klass)
    raw = bytearray(0x9C)
    struct.pack_into("<Q", raw, 0, klass)
    struct.pack_into("<qq", raw, 0x10, data_id, card_id)
    struct.pack_into("<Q", raw, 0x20, name_address)
    struct.pack_into("<Q", raw, 0x30, element_address)
    struct.pack_into("<q", raw, 0x48, 160)
    struct.pack_into("<i", raw, 0x80, 160)
    memory.map(address, raw)


def map_list(
    memory: FakeMemory,
    list_address: int,
    array_address: int,
    values: tuple[int, ...],
    *,
    array_class: int,
) -> None:
    raw_list = bytearray(0x20)
    struct.pack_into("<Q", raw_list, 0x10, array_address)
    struct.pack_into("<ii", raw_list, 0x18, len(values), 7)
    memory.map(list_address, raw_list)
    raw_array = bytearray(0x20 + len(values) * 8)
    struct.pack_into("<Q", raw_array, 0, array_class)
    struct.pack_into("<Q", raw_array, 0x18, len(values))
    if values:
        struct.pack_into(f"<{len(values)}Q", raw_array, 0x20, *values)
    memory.map(array_address, raw_array)


class BossLobbyCardTests(unittest.TestCase):
    BASE = 0x0000021000000000

    def test_b5_static_instance_can_use_nonzero_static_field_slot(self) -> None:
        memory = FakeMemory()
        klass = self.BASE + 0x100
        fields = self.BASE + 0x400
        instance = self.BASE + 0x800
        raw_class = bytearray(0xA0)
        struct.pack_into("<Q", raw_class, 0x98, fields)
        memory.map(klass, raw_class)
        raw_fields = bytearray(0x10)
        struct.pack_into("<Q", raw_fields, 0x00, self.BASE + 0xDEAD)
        struct.pack_into("<Q", raw_fields, 0x08, instance)
        memory.map(fields, raw_fields)
        raw_instance = bytearray(0x20)
        struct.pack_into("<Q", raw_instance, 0x00, klass)
        memory.map(instance, raw_instance)

        class Resolver(FakeResolver):
            def resolve_type_info_class(self, _rva: int) -> int:
                return klass

        self.assertEqual(
            _static_instance(
                Resolver(memory),
                0x1234,
                size=0x20,
                static_field_offset=0x08,
            ),
            instance,
        )

    def test_b5_room_start_idle_is_bound_to_exact_manager_button(self) -> None:
        memory = FakeMemory()
        resolver = FakeResolver(memory)
        view = self.BASE + 0x100
        refs = self.BASE + 0x300
        state = self.BASE + 0x700
        button = self.BASE + 0xA00
        raw_view = bytearray(0xB8)
        struct.pack_into("<Q", raw_view, ROOM_COOP_V2_REFS_OFFSET, refs)
        struct.pack_into("<Q", raw_view, ROOM_COOP_V2_START_STATE_OFFSET, state)
        memory.map(view, raw_view)
        raw_refs = bytearray(ROOM_COOP_V2_REFS_BUTTON_START_OFFSET + 8)
        struct.pack_into(
            "<Q", raw_refs, ROOM_COOP_V2_REFS_BUTTON_START_OFFSET, button
        )
        memory.map(refs, raw_refs)
        raw_state = bytearray(ROOM_START_MY_READY_OFFSET + 1)
        struct.pack_into("<i", raw_state, ROOM_START_PHASE_OFFSET, RoomStartPhase.IDLE)
        raw_state[ROOM_START_MY_READY_OFFSET] = 0
        memory.map(state, raw_state)

        with patch.object(lobby_runtime_module, "_static_instance", return_value=view):
            observed = _read_room_start_state(resolver, button)

        self.assertEqual(observed[:5], (view, refs, state, RoomStartPhase.IDLE, False))
        self.assertEqual(observed[5], ())

    def test_b5_room_start_countdown_blocks_repeated_main_button_click(self) -> None:
        memory = FakeMemory()
        resolver = FakeResolver(memory)
        view = self.BASE + 0x100
        refs = self.BASE + 0x300
        state = self.BASE + 0x700
        button = self.BASE + 0xA00
        raw_view = bytearray(0xB8)
        struct.pack_into("<Q", raw_view, ROOM_COOP_V2_REFS_OFFSET, refs)
        struct.pack_into("<Q", raw_view, ROOM_COOP_V2_START_STATE_OFFSET, state)
        memory.map(view, raw_view)
        raw_refs = bytearray(ROOM_COOP_V2_REFS_BUTTON_START_OFFSET + 8)
        struct.pack_into(
            "<Q", raw_refs, ROOM_COOP_V2_REFS_BUTTON_START_OFFSET, button
        )
        memory.map(refs, raw_refs)
        raw_state = bytearray(ROOM_START_MY_READY_OFFSET + 1)
        struct.pack_into(
            "<i", raw_state, ROOM_START_PHASE_OFFSET, RoomStartPhase.COUNTING
        )
        raw_state[ROOM_START_MY_READY_OFFSET] = 1
        memory.map(state, raw_state)

        with patch.object(lobby_runtime_module, "_static_instance", return_value=view):
            observed = _read_room_start_state(resolver, button)

        self.assertEqual(observed[3], RoomStartPhase.COUNTING)
        self.assertTrue(observed[4])
        self.assertIn("RoomStartState is not Idle (COUNTING)", observed[5])
        self.assertIn(
            "RoomStartState already marks the local user ready", observed[5]
        )

    def test_preentry_loadout_reads_both_sources_and_finds_attack(self) -> None:
        memory = FakeMemory()
        resolver = FakeResolver(memory)
        manager = self.BASE
        room = self.BASE + 0x1000
        manager_list = self.BASE + 0x2000
        room_list = self.BASE + 0x3000
        manager_array = self.BASE + 0x4000
        room_array = self.BASE + 0x5000
        data_class = self.BASE + 0x6000
        string_class = self.BASE + 0x7000
        array_class = self.BASE + 0x8000
        cards = (
            self.BASE + 0x10000,
            self.BASE + 0x20000,
            self.BASE + 0x30000,
        )
        for pointer in (data_class, string_class, array_class):
            memory.map(pointer, bytearray(8))
        for index, (name, element) in enumerate(
            (("Tan cong", "ATTACK"), ("Ho tro", "BUFF"), ("Khien", "SHIELD"))
        ):
            map_card_data(
                memory,
                cards[index],
                klass=data_class,
                string_klass=string_class,
                data_id=9000 + index,
                card_id=70 + index,
                name=name,
                element_type=element,
            )
        manager_raw = bytearray(0x110)
        struct.pack_into("<Q", manager_raw, MANAGER_ROOM_SELECTED_CARDS_OFFSET, manager_list)
        memory.map(manager, manager_raw)
        room_raw = bytearray(0x60)
        struct.pack_into("<Q", room_raw, ROOM_CARDS_OFFSET, room_list)
        memory.map(room, room_raw)
        map_list(memory, manager_list, manager_array, cards, array_class=array_class)
        map_list(memory, room_list, room_array, cards, array_class=array_class)

        loadout = _read_lobby_card_loadout(resolver, manager, room)

        self.assertEqual(loadout.card_count, 3)
        self.assertEqual(loadout.attack_card_count, 1)
        self.assertTrue(loadout.sources_agree)
        self.assertEqual(len(loadout.identity), 3)
        self.assertEqual(loadout.reasons, ())

        # A process/lobby reset can empty the UI-owned selection while the
        # RoomDTO retains its prior loadout. The stale RoomDTO must remain
        # telemetry and must not be promoted to a live next-combat claim.
        map_list(memory, manager_list, manager_array, (), array_class=array_class)
        stale = _read_lobby_card_loadout(resolver, manager, room)
        self.assertEqual(stale.card_count, 0)
        self.assertEqual(stale.attack_card_count, 0)
        self.assertEqual(stale.manager_attack_card_count, 0)
        self.assertEqual(stale.room_attack_card_count, 1)
        self.assertFalse(stale.sources_agree)


class HubSurfaceClassificationTests(unittest.TestCase):
    def test_closed_world_boss_layer_is_general_game_lobby(self) -> None:
        world, chinh, home = _hub_surface_flags(
            master_lobby_active=True,
            panel_boss_active=False,
            panel_world_boss_active=False,
            panel_chinh_phuc_active=False,
            other_blockers=(False, False, False, False, False),
            extra_blockers=(),
            dynamic_panel_count=0,
        )

        self.assertFalse(world)
        self.assertFalse(chinh)
        self.assertTrue(home)

    def test_visible_world_boss_layer_is_not_general_game_lobby(self) -> None:
        world, chinh, home = _hub_surface_flags(
            master_lobby_active=True,
            panel_boss_active=True,
            panel_world_boss_active=True,
            panel_chinh_phuc_active=False,
            other_blockers=(False, False, False, False, False),
            extra_blockers=(),
            dynamic_panel_count=0,
        )

        self.assertTrue(world)
        self.assertFalse(chinh)
        self.assertFalse(home)

    def test_dynamic_or_known_overlay_prevents_false_home_status(self) -> None:
        for other, extra, count in (
            ((True, False, False, False, False), (), 0),
            ((False, False, False, False, False), (True,), 0),
            ((False, False, False, False, False), (), 1),
        ):
            with self.subTest(other=other, extra=extra, count=count):
                world, chinh, home = _hub_surface_flags(
                    master_lobby_active=True,
                    panel_boss_active=False,
                    panel_world_boss_active=False,
                    panel_chinh_phuc_active=False,
                    other_blockers=other,
                    extra_blockers=extra,
                    dynamic_panel_count=count,
                )
                self.assertFalse(world)
                self.assertFalse(chinh)
                self.assertFalse(home)

    def test_exact_conquest_island_dynamic_panel_is_a_proven_surface(self) -> None:
        world, chinh, home = _hub_surface_flags(
            master_lobby_active=True,
            panel_boss_active=False,
            panel_world_boss_active=None,
            panel_chinh_phuc_active=True,
            other_blockers=(False, False, False, False, False),
            extra_blockers=(),
            dynamic_panel_count=1,
            chinh_phuc_panel_main_active=True,
            chinh_phuc_active_panel_index=5,
        )

        self.assertFalse(world)
        self.assertTrue(chinh)
        self.assertFalse(home)

    def test_dynamic_panel_without_exact_island_evidence_fails_closed(self) -> None:
        for panel_main, active_index, count in (
            (True, None, 1),
            (False, 5, 1),
            (True, 5, 2),
        ):
            with self.subTest(
                panel_main=panel_main,
                active_index=active_index,
                count=count,
            ):
                world, chinh, home = _hub_surface_flags(
                    master_lobby_active=True,
                    panel_boss_active=False,
                    panel_world_boss_active=None,
                    panel_chinh_phuc_active=True,
                    other_blockers=(False, False, False, False, False),
                    extra_blockers=(),
                    dynamic_panel_count=count,
                    chinh_phuc_panel_main_active=panel_main,
                    chinh_phuc_active_panel_index=active_index,
                )
                self.assertFalse(world)
                self.assertFalse(chinh)
                self.assertFalse(home)

    @patch.object(lobby_runtime_module, "read_world_boss_list")
    @patch.object(lobby_runtime_module, "read_chinh_phuc_room")
    def test_runtime_names_proven_home_and_map_surfaces(
        self, read_chinh: object, read_world: object
    ) -> None:
        read_chinh.return_value = (  # type: ignore[attr-defined]
            SimpleNamespace(clean=False, reasons=("not an exact room",)),
            (),
        )
        lifecycle = CombatLifecycleObservation(
            CombatLifecycleState.LOBBY,
            CombatLifecycleSignals(),
            "lobby",
        )
        for branch, home, chinh_map in (
            ("GAME_LOBBY", True, False),
            ("CHINH_PHUC_MAP", False, True),
        ):
            with self.subTest(branch=branch):
                read_world.return_value = (  # type: ignore[attr-defined]
                    SimpleNamespace(
                        clean_for_discovery=False,
                        clean_for_game_lobby=home,
                        clean_for_chinh_phuc_map=chinh_map,
                        reasons=(),
                    ),
                    (),
                )
                snapshot = read_boss_lobby_runtime(object(), lifecycle)
                self.assertEqual(snapshot.state, BossLobbyState.LOBBY_OTHER)
                self.assertEqual(snapshot.branch, branch)

    @patch.object(lobby_runtime_module, "read_world_boss_list")
    @patch.object(lobby_runtime_module, "read_chinh_phuc_room")
    def test_runtime_names_exact_active_conquest_island_panel(
        self, read_chinh: object, read_world: object
    ) -> None:
        read_chinh.return_value = (  # type: ignore[attr-defined]
            SimpleNamespace(clean=False, reasons=("not an exact room",)),
            (),
        )
        read_world.return_value = (  # type: ignore[attr-defined]
            SimpleNamespace(
                clean_for_discovery=False,
                clean_for_game_lobby=False,
                clean_for_chinh_phuc_map=True,
                chinh_phuc_active_panel_index=5,
                reasons=(),
            ),
            (),
        )
        lifecycle = CombatLifecycleObservation(
            CombatLifecycleState.LOBBY,
            CombatLifecycleSignals(),
            "lobby",
        )

        snapshot = read_boss_lobby_runtime(object(), lifecycle)

        self.assertEqual(snapshot.state, BossLobbyState.LOBBY_OTHER)
        self.assertEqual(snapshot.branch, "CHINH_PHUC_ISLAND")
        self.assertEqual(snapshot.candidates, ())

class UnknownLifecycleRoomGateTests(unittest.TestCase):
    @patch.object(lobby_runtime_module, "read_world_boss_list")
    @patch.object(lobby_runtime_module, "read_chinh_phuc_room")
    def test_exact_clean_room_recovers_uninitialized_combat_statics(
        self, read_chinh: object, read_world: object
    ) -> None:
        candidate = object()
        read_chinh.return_value = (  # type: ignore[attr-defined]
            SimpleNamespace(clean=True, reasons=()),
            (candidate,),
        )
        read_world.return_value = (  # type: ignore[attr-defined]
            SimpleNamespace(clean_for_discovery=False, reasons=()),
            (),
        )
        lifecycle = CombatLifecycleObservation(
            CombatLifecycleState.UNKNOWN,
            CombatLifecycleSignals(
                active_instance=0x5000,
                manager_match_instance=0x6000,
            ),
            "lifecycle_signals_missing_or_disagree",
        )

        snapshot = read_boss_lobby_runtime(object(), lifecycle)

        self.assertEqual(snapshot.state, BossLobbyState.BOSS_LOBBY)
        self.assertEqual(snapshot.branch, "CHINH_PHUC_ROOM")
        self.assertEqual(snapshot.candidates, (candidate,))

    @patch.object(lobby_runtime_module, "read_world_boss_list")
    @patch.object(lobby_runtime_module, "read_chinh_phuc_room")
    def test_unknown_lifecycle_never_overrides_combat_or_read_error(
        self, read_chinh: object, read_world: object
    ) -> None:
        read_chinh.return_value = (  # type: ignore[attr-defined]
            SimpleNamespace(clean=True, reasons=()),
            (),
        )
        read_world.return_value = (  # type: ignore[attr-defined]
            SimpleNamespace(clean_for_discovery=False, reasons=()),
            (),
        )
        contradictory = (
            CombatLifecycleSignals(board_instance=0x1234),
            CombatLifecycleSignals(read_errors=("MatchHost:invalid",)),
            CombatLifecycleSignals(scene_loading=True),
        )
        for signals in contradictory:
            with self.subTest(signals=signals):
                lifecycle = CombatLifecycleObservation(
                    CombatLifecycleState.UNKNOWN,
                    signals,
                    "lifecycle_signals_missing_or_disagree",
                )
                snapshot = read_boss_lobby_runtime(object(), lifecycle)
                self.assertEqual(snapshot.state, BossLobbyState.UNKNOWN)
                self.assertIsNone(snapshot.branch)


if __name__ == "__main__":
    unittest.main()
