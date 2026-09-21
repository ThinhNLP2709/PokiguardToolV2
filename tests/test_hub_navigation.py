from __future__ import annotations

import unittest
from types import SimpleNamespace
from unittest.mock import patch

from pokiguard_v2.hub_navigation import (
    HubChinhPhucControl,
    locate_hub_chinh_phuc_control,
    read_hub_chinh_phuc_control,
    same_clean_hub_chinh_phuc_control,
)
from tests.test_native_card_ui import NativeFixture


def control(**changes: object) -> HubChinhPhucControl:
    values = {
        "manager_quang_truong": 0x20000001000,
        "panel_chinh_phuc": 0x20000002000,
        "panel_native": 0x20000003000,
        "panel_active": False,
        "button_chinh_phuc": 0x20000004000,
        "button_native": 0x20000005000,
        "button_active": True,
        "button_interactable": True,
        "button_groups_allow": True,
        "viewport_rect": (0.65, 0.70, 0.76, 0.86),
        "root_transform": 0x20000006000,
        "root_aspect": 2.0,
        "clean": True,
        "reasons": (),
    }
    values.update(changes)
    return HubChinhPhucControl(**values)


class HubNavigationTests(unittest.TestCase):
    def test_exact_manager_fields_resolve_closed_panel_and_live_button(self) -> None:
        fixture = NativeFixture()
        manager = fixture.alloc()
        panel = fixture.node(None, (-10, -10, 20, 20), (0, 0, 0))
        fixture.memory.map(panel.native + 0x4F, b"\0")
        button = fixture.cards[1].button
        fixture.memory.map(button.managed + 0xD8, b"\1")
        fixture.memory.map(button.managed + 0xE8, b"\1")

        class Resolver:
            game_assembly_base = fixture.ga
            memory = fixture.memory

            def read_bool(self, address: int) -> bool:
                return bool(self.memory.read(address, 1)[0])

        target = SimpleNamespace(memory=fixture.memory, resolver=Resolver())
        pointers = {0x2C0: panel.managed, 0x2C8: button.managed}
        with patch(
            "pokiguard_v2.hub_navigation._static_instance", return_value=manager
        ), patch(
            "pokiguard_v2.hub_navigation._read_pointer",
            side_effect=lambda _resolver, _base, offset: pointers.get(offset),
        ), patch(
            "pokiguard_v2.hub_navigation._native_pointer",
            return_value=panel.native,
        ):
            observed = read_hub_chinh_phuc_control(target)

        self.assertTrue(observed.clean, observed.reasons)
        self.assertFalse(observed.panel_active)
        self.assertTrue(observed.button_active)
        self.assertTrue(observed.button_interactable)
        self.assertIsNotNone(observed.viewport_rect)

    def test_two_samples_require_stable_identity_and_geometry(self) -> None:
        first = control()
        self.assertTrue(same_clean_hub_chinh_phuc_control(first, control()))
        self.assertFalse(
            same_clean_hub_chinh_phuc_control(
                first, control(button_native=0x20000007000)
            )
        )
        self.assertFalse(
            same_clean_hub_chinh_phuc_control(
                first, control(viewport_rect=(0.62, 0.70, 0.76, 0.86))
            )
        )

    def test_native_canvas_rect_maps_to_client_after_visual_sanity(self) -> None:
        width, height = 800, 400
        rgb = bytes((240, 80, 5)) * width * height
        located = locate_hub_chinh_phuc_control(
            rgb, width, height, control()
        )
        self.assertTrue(located.found, located)
        self.assertEqual(located.normalized_point, (0.7050000000000001, 0.78))

        rejected = locate_hub_chinh_phuc_control(
            bytes((20, 20, 20)) * width * height,
            width,
            height,
            control(),
        )
        self.assertFalse(rejected.found)
        self.assertEqual(rejected.reason, "native_hub_visual_sanity_failed")


if __name__ == "__main__":
    unittest.main()
