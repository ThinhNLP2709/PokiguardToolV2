from __future__ import annotations

from pathlib import Path
import sys
from types import SimpleNamespace
import unittest


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.combat_lifecycle import CombatLifecycleState  # noqa: E402
from tools.foreground_lease_probe import (  # noqa: E402
    _fresh_active_lifecycle_ack,
    _wait_lease_opening_ack,
    _validate_args,
    build_parser,
)


class ForegroundLeaseProbeArgumentTests(unittest.TestCase):
    def test_b1_only_is_default(self) -> None:
        args = build_parser().parse_args(["--boss-id", "1289"])

        _validate_args(args)

        self.assertFalse(args.live_start)
        self.assertFalse(args.prearmed)

    def test_prearmed_requires_live_start(self) -> None:
        args = build_parser().parse_args(["--boss-id", "1289", "--prearmed"])

        with self.assertRaises(ValueError):
            _validate_args(args)

    def test_live_start_bounds_accept_documented_defaults(self) -> None:
        args = build_parser().parse_args(
            ["--boss-name", "Starburst", "--live-start"]
        )

        _validate_args(args)

        self.assertEqual(args.required_idle, 0.45)
        self.assertEqual(args.idle_timeout, 8.0)
        self.assertEqual(args.focus_settle, 0.40)
        self.assertEqual(args.cursor_settle, 0.25)


class ForegroundLeaseOpeningAckTests(unittest.TestCase):
    @staticmethod
    def lifecycle(*, board_instance: int = 0x1234) -> SimpleNamespace:
        return SimpleNamespace(
            state=CombatLifecycleState.ACTIVE,
            signals=SimpleNamespace(
                match_id="M_new",
                board_instance=board_instance,
                current_rig_alive=True,
                objects_consistent=True,
                board_ready=True,
                read_errors=(),
            ),
        )

    def test_fresh_active_owned_session_is_authoritative_entry_ack(self) -> None:
        session = SimpleNamespace(match_id="M_new", board_instance=0x1234)

        self.assertTrue(
            _fresh_active_lifecycle_ack(
                old_session=None,
                session=session,
                lifecycle=self.lifecycle(),
            )
        )

    def test_old_or_inconsistent_active_session_is_rejected(self) -> None:
        session = SimpleNamespace(match_id="M_new", board_instance=0x1234)

        self.assertFalse(
            _fresh_active_lifecycle_ack(
                old_session=session,
                session=session,
                lifecycle=self.lifecycle(),
            )
        )
        self.assertFalse(
            _fresh_active_lifecycle_ack(
                old_session=None,
                session=session,
                lifecycle=self.lifecycle(board_instance=0x9999),
            )
        )

    def test_wait_requires_two_matching_active_lifecycle_samples(self) -> None:
        session = SimpleNamespace(match_id="M_new", board_instance=0x1234)
        polls = [
            SimpleNamespace(
                state=None,
                reason="active-one",
                session_key=session,
                combat_lifecycle=self.lifecycle(),
            ),
            SimpleNamespace(
                state=None,
                reason="active-two",
                session_key=session,
                combat_lifecycle=self.lifecycle(),
            ),
        ]
        provider = SimpleNamespace(poll=lambda: polls.pop(0))
        target = SimpleNamespace(is_running=lambda: True)
        events: list[dict[str, object]] = []
        log = SimpleNamespace(
            event=lambda _event, **fields: events.append(fields)
        )

        accepted, state, kind, last_poll = _wait_lease_opening_ack(
            target=target,
            provider=provider,
            old_session=None,
            timeout=1.0,
            interval=0.0,
            log=log,
        )

        self.assertTrue(accepted)
        self.assertIsNone(state)
        self.assertEqual(kind, "FRESH_ACTIVE_LIFECYCLE_X2")
        self.assertEqual(last_poll.reason, "active-two")
        self.assertEqual([event["activeConfirmations"] for event in events], [1, 2])


if __name__ == "__main__":
    unittest.main()
