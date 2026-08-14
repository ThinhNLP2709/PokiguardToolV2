from __future__ import annotations

from pathlib import Path
import sys
import unittest


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.basic_policy import BasicPolicyEngine, PolicyConfig
from tests.test_basic_policy import combat_state
from tools.replay_basic_policy import (
    _jsonable,
    build_audit,
    infer_actual_actions,
)


class ReplayBasicPolicyTests(unittest.TestCase):
    def test_complete_game_state_replays_deterministically(self) -> None:
        state = combat_state()
        decision = BasicPolicyEngine(PolicyConfig()).decide(state)
        rows = [
            {
                "event": "basic_policy_shadow_started",
                "config": {
                    "play_style": "simple",
                    "mana_priority": "evolution",
                    "intelligence": "basic",
                    "minimum_turn_time_seconds": 3,
                },
            },
            {
                "event": "basic_policy_decision",
                "boardInstance": "0x0000020000000000",
                "srvSeq": state.battle.srv_seq,
                "turn": state.battle.turn_number,
                "timer": {"remaining": 12},
                "fusion": _jsonable(state.fusion),
                "gameState": _jsonable(state),
                "decision": _jsonable(decision),
            },
        ]
        audit = build_audit(rows, 5)
        self.assertEqual(audit["replayStatus"], "MATCH")
        self.assertTrue(audit["replay"][0]["deterministic"])
        self.assertTrue(audit["replay"][0]["equalsLoggedDecision"])

    def test_legacy_trace_is_auditable_but_not_replayable(self) -> None:
        state = combat_state()
        decision = BasicPolicyEngine().decide(state)
        rows = [
            {
                "event": "basic_policy_decision",
                "boardInstance": "0x1",
                "srvSeq": 1,
                "turn": 3,
                "timer": {"remaining": 12},
                "fusion": _jsonable(state.fusion),
                "decision": _jsonable(decision),
            }
        ]
        self.assertEqual(build_audit(rows, 3)["replayStatus"], "NOT_COMPARABLE")

    def test_fusion_attempt_is_compared_only_across_exact_adjacent_turns(self) -> None:
        state = combat_state(fusion_used=False, turn=9)
        decision = BasicPolicyEngine().decide(state)
        before = {
            "event": "basic_policy_decision",
            "boardInstance": "0x1",
            "turn": 9,
            "decision": _jsonable(decision),
            "fusion": {"last_attempt_turn": -1},
        }
        after = {
            "event": "basic_policy_decision",
            "boardInstance": "0x1",
            "turn": 11,
            "decision": _jsonable(decision),
            "fusion": {"last_attempt_turn": 9},
        }
        actual = infer_actual_actions([before, after])
        self.assertEqual(actual[0].action, "EVOLVE")
        self.assertEqual(actual[0].comparison, "MATCH")


if __name__ == "__main__":
    unittest.main()
