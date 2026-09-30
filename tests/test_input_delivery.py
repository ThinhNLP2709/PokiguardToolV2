from __future__ import annotations

from dataclasses import FrozenInstanceError
import json
from pathlib import Path
import sys
import unittest


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.foreground_lease_transport import (  # noqa: E402
    BoundedForegroundLease as ProductionMouseLease,
)
from pokiguard_v2.foreground_qte_lease_transport import (  # noqa: E402
    BoundedForegroundQteLease as ProductionQteLease,
)
from pokiguard_v2.input_delivery import (  # noqa: E402
    DeliveryAttemptStatus,
    ExactWindowBinding,
    InputDeliveryAuthority,
    InputDeliveryConfig,
    InputDeliveryConfigError,
    InputDeliveryDomain,
    InputDeliveryMode,
    InputDeliveryTelemetry,
    InputLeaseKind,
    input_delivery_capability,
)
from pokiguard_v2.win32_input import ClientGeometry, WindowBinding  # noqa: E402
from tools.foreground_lease_transport import (  # noqa: E402
    BoundedForegroundLease as ToolMouseLease,
)
from tools.foreground_qte_lease_transport import (  # noqa: E402
    BoundedForegroundQteLease as ToolQteLease,
)
from tools.basic_auto_bot import (  # noqa: E402
    _pinned_board_selection_gate_foreground,
)


def exact_binding() -> ExactWindowBinding:
    return ExactWindowBinding(
        WindowBinding(1234, 5678, "PokiguardOnlines", 1280, 640),
        ClientGeometry(100, 200, 1280, 640),
    )


class InputDeliveryConfigTests(unittest.TestCase):
    def test_default_and_legacy_missing_mode_are_foreground(self) -> None:
        self.assertIs(InputDeliveryConfig().mode, InputDeliveryMode.FOREGROUND)
        self.assertIs(
            InputDeliveryConfig.from_dict({}).mode,
            InputDeliveryMode.FOREGROUND,
        )
        self.assertIs(InputDeliveryConfig.from_dict(None).mode, InputDeliveryMode.FOREGROUND)

    def test_beta_round_trip_is_explicit_and_stable(self) -> None:
        original = InputDeliveryConfig(InputDeliveryMode.PINNED_FOREGROUND_LEASE_BETA)
        self.assertEqual(InputDeliveryConfig.from_dict(original.to_dict()), original)
        self.assertEqual(
            original.to_dict(),
            {
                "schema": "pokiguard.input_delivery.v1",
                "mode": "pinned_foreground_lease_beta",
            },
        )

    def test_unknown_schema_or_mode_fails_without_fallback(self) -> None:
        with self.assertRaises(InputDeliveryConfigError):
            InputDeliveryConfig.from_dict({"schema": "future", "mode": "foreground"})
        with self.assertRaises(InputDeliveryConfigError):
            InputDeliveryConfig.from_dict({"mode": "background"})

    def test_config_is_immutable(self) -> None:
        config = InputDeliveryConfig()
        with self.assertRaises(FrozenInstanceError):
            config.mode = InputDeliveryMode.PINNED_FOREGROUND_LEASE_BETA  # type: ignore[misc]


class InputDeliveryCapabilityTests(unittest.TestCase):
    def test_only_beta_board_preparation_may_reach_focus_lease_from_background(
        self,
    ) -> None:
        foreground = InputDeliveryConfig(InputDeliveryMode.FOREGROUND)
        beta = InputDeliveryConfig(
            InputDeliveryMode.PINNED_FOREGROUND_LEASE_BETA
        )

        self.assertFalse(
            _pinned_board_selection_gate_foreground(foreground, False)
        )
        self.assertIsNone(
            _pinned_board_selection_gate_foreground(foreground, None)
        )
        self.assertTrue(
            _pinned_board_selection_gate_foreground(beta, False)
        )
        self.assertTrue(
            _pinned_board_selection_gate_foreground(beta, None)
        )

    def test_foreground_keeps_existing_nonlease_semantics(self) -> None:
        capability = input_delivery_capability(InputDeliveryMode.FOREGROUND)
        self.assertFalse(capability.pin_required)
        self.assertFalse(capability.may_take_foreground)
        self.assertTrue(capability.foreground_required_at_send)
        self.assertFalse(capability.minimized_supported)
        self.assertIs(
            capability.lease_kind_for(InputDeliveryDomain.BOARD_SWAP),
            InputLeaseKind.NONE,
        )

    def test_beta_uses_mouse_lease_and_split_qte_lease(self) -> None:
        capability = input_delivery_capability(
            InputDeliveryMode.PINNED_FOREGROUND_LEASE_BETA
        )
        self.assertTrue(capability.pin_required)
        self.assertTrue(capability.may_take_foreground)
        self.assertTrue(capability.foreground_required_at_send)
        self.assertFalse(capability.minimized_supported)
        self.assertIs(
            capability.lease_kind_for(InputDeliveryDomain.BOARD_SWAP),
            InputLeaseKind.MOUSE,
        )
        self.assertIs(
            capability.lease_kind_for(InputDeliveryDomain.PET_SKILL_QTE),
            InputLeaseKind.QTE_MOUSE_THEN_KEYBOARD,
        )

    def test_wrong_typed_mode_or_domain_fails_closed(self) -> None:
        with self.assertRaises(InputDeliveryConfigError):
            input_delivery_capability("foreground")  # type: ignore[arg-type]
        capability = input_delivery_capability(InputDeliveryMode.FOREGROUND)
        with self.assertRaises(InputDeliveryConfigError):
            capability.lease_kind_for("board_swap")  # type: ignore[arg-type]


class InputDeliveryAuthorityTests(unittest.TestCase):
    def test_exact_binding_rejects_geometry_drift(self) -> None:
        with self.assertRaisesRegex(ValueError, "match the bound window size"):
            ExactWindowBinding(
                WindowBinding(1234, 5678, "PokiguardOnlines", 1280, 640),
                ClientGeometry(100, 200, 1279, 640),
            )

    def test_authority_is_typed_and_telemetry_is_serializable(self) -> None:
        authority = InputDeliveryAuthority(
            InputDeliveryConfig(InputDeliveryMode.PINNED_FOREGROUND_LEASE_BETA),
            InputDeliveryDomain.BOARD_SWAP,
            exact_binding(),
            "run-1:match-2:swap-3",
        )
        self.assertIs(authority.lease_kind, InputLeaseKind.MOUSE)
        payload = InputDeliveryTelemetry(
            authority=authority,
            status=DeliveryAttemptStatus.SENT,
            expected_ack_kind="BOARD_SEQUENCE_TURN",
            client_points=((100, 200), (140, 200)),
            event_timestamps=(1.0, 1.2),
            foreground_before=99,
            foreground_after=1234,
            queued=True,
            cleanup_result="COMPLETE",
            run_id="run-1",
            session_id="match-2",
        ).to_dict()
        self.assertEqual(payload["authority"]["config"]["mode"], "pinned_foreground_lease_beta")
        self.assertEqual(payload["authority"]["domain"], "board_swap")
        self.assertEqual(payload["status"], "SENT")
        self.assertEqual(payload["leaseKind"], "mouse")
        self.assertNotIn("rawMemory", payload)
        json.dumps(payload)

    def test_empty_action_identity_is_rejected(self) -> None:
        with self.assertRaisesRegex(ValueError, "action_identity"):
            InputDeliveryAuthority(
                InputDeliveryConfig(),
                InputDeliveryDomain.BOARD_SWAP,
                exact_binding(),
                " ",
            )

    def test_probe_shims_use_the_production_classes(self) -> None:
        self.assertIs(ToolMouseLease, ProductionMouseLease)
        self.assertIs(ToolQteLease, ProductionQteLease)


if __name__ == "__main__":
    unittest.main()
