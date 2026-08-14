from __future__ import annotations

from dataclasses import replace
from pathlib import Path
import sys
import unittest


ROOT = Path(__file__).resolve().parents[1]
for import_path in (str(ROOT), str(ROOT / "src")):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from tools.idle_state_watch import ServerMessage
from tools.lifecycle_idle_watch import _message_identity


def message() -> ServerMessage:
    return ServerMessage(
        address=0x100000,
        event_type="MATCH_MOVE_RES",
        match_id="M_one",
        timestamp="2026-08-12T22:00:00",
        username=None,
        payload_address=0x200000,
        server_sequence=17,
        from_col=None,
        from_row=None,
        to_col=None,
        to_row=None,
        card_id=None,
        skill_card_id=None,
        reject_reason=None,
        idle_count=None,
        threshold=None,
        payload_ints=(),
        payload_bools=(),
        payload_strings=(("actorUsername", "happi"),),
    )


class LifecycleIdleWatchTests(unittest.TestCase):
    def test_transient_duplicate_address_has_same_semantic_identity(self) -> None:
        first = message()
        duplicate = replace(first, address=0x300000, payload_address=0x400000)
        self.assertEqual(_message_identity(first), _message_identity(duplicate))

    def test_actor_or_sequence_change_is_a_distinct_server_message(self) -> None:
        first = message()
        other_actor = replace(
            first, payload_strings=(("actorUsername", "__BOSS__"),)
        )
        other_sequence = replace(first, server_sequence=18)
        self.assertNotEqual(_message_identity(first), _message_identity(other_actor))
        self.assertNotEqual(_message_identity(first), _message_identity(other_sequence))


if __name__ == "__main__":
    unittest.main()
