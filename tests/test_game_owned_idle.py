from __future__ import annotations

import unittest
from pathlib import Path
import sys


SRC = Path(__file__).resolve().parents[1] / "src"
if str(SRC) not in sys.path:
    sys.path.insert(0, str(SRC))

from pokiguard_v2.game_owned_idle import (
    AcceptedActivityKind,
    GameOwnedIdleCache,
    IdleFreshness,
    PassReadiness,
    ResetCapability,
    ResetConfidence,
)


class GameOwnedIdleCacheTests(unittest.TestCase):
    def observe(self, cache: GameOwnedIdleCache, count: int = 1):
        return cache.observe_server_payload(
            session_id="epoch=1|board=0x1234|match=M_test",
            username="happi",
            idle_count=count,
            threshold=3,
            source_message_type="MATCH_TURN_END",
            source_srv_seq=11,
            source_turn=3,
            source_timestamp="2026-08-12T00:00:00Z",
            observed_timestamp="2026-08-12T00:00:00.100Z",
        )

    def test_only_exact_server_payload_replaces_count(self) -> None:
        cache = GameOwnedIdleCache()
        first = self.observe(cache, 1)
        self.assertEqual(first.idle_count, 1)

        cache.mark_current_state_unproven(first.session_id, "swap_or_turn_transition")
        self.assertEqual(cache.state.idle_count, 1)
        self.assertEqual(cache.state.freshness, IdleFreshness.CURRENT_STATE_UNPROVEN)

        second = self.observe(cache, 2)
        self.assertEqual(second.idle_count, 2)
        self.assertEqual(second.freshness, IdleFreshness.EXACT_SERVER_EVENT)

    def test_new_session_discards_previous_payload(self) -> None:
        cache = GameOwnedIdleCache()
        self.observe(cache)
        cache.begin_session("epoch=2|board=0x5678|match=M_next")
        self.assertIsNone(cache.state)

    def test_turn_associated_count_two_requires_action(self) -> None:
        cache = GameOwnedIdleCache()
        state = self.observe(cache, 2)
        result = cache.pass_readiness(
            current_session_id=state.session_id,
            local_username="HAPPI",
            current_turn=3,
            is_local_turn=True,
            lifecycle_active=True,
        )
        self.assertEqual(
            result.readiness, PassReadiness.PASS_FORBIDDEN_MANDATORY_ACTION
        )
        self.assertFalse(result.can_pass_now)
        self.assertTrue(result.must_act_now)

    def test_turn_associated_count_one_allows_one_more_pass(self) -> None:
        cache = GameOwnedIdleCache()
        state = self.observe(cache, 1)
        result = cache.pass_readiness(
            current_session_id=state.session_id,
            local_username="happi",
            current_turn=3,
            is_local_turn=True,
            lifecycle_active=True,
        )
        self.assertEqual(result.readiness, PassReadiness.PASS_ALLOWED)
        self.assertTrue(result.can_pass_now)
        self.assertFalse(result.must_act_now)

    def test_direct_or_wrong_turn_payload_stays_unknown(self) -> None:
        cache = GameOwnedIdleCache()
        state = self.observe(cache, 1)
        wrong_turn = cache.pass_readiness(
            current_session_id=state.session_id,
            local_username="happi",
            current_turn=5,
            is_local_turn=True,
            lifecycle_active=True,
        )
        self.assertEqual(wrong_turn.readiness, PassReadiness.UNKNOWN)
        direct = cache.observe_server_payload(
            session_id=state.session_id,
            username="happi",
            idle_count=1,
            threshold=3,
            source_message_type="MATCH_AFK_WARN",
            source_srv_seq=None,
            source_turn=None,
            source_timestamp=None,
            observed_timestamp="now",
        )
        result = cache.pass_readiness(
            current_session_id=direct.session_id,
            local_username="happi",
            current_turn=3,
            is_local_turn=True,
            lifecycle_active=True,
        )
        self.assertEqual(result.readiness, PassReadiness.UNKNOWN)

    def test_accepted_action_never_locally_changes_count(self) -> None:
        cache = GameOwnedIdleCache()
        state = self.observe(cache, 2)
        cache.observe_accepted_activity(
            session_id=state.session_id,
            kind=AcceptedActivityKind.SWAP,
            source_message_type="MATCH_MOVE_RES",
            source_srv_seq=20,
            source_turn=3,
            source_timestamp="server-action",
            observed_timestamp="local-action",
        )
        self.assertEqual(cache.state.idle_count, 2)
        self.assertEqual(cache.state.freshness, IdleFreshness.CURRENT_STATE_UNPROVEN)

    def test_lower_next_payload_classifies_server_sequence_reset(self) -> None:
        cache = GameOwnedIdleCache()
        state = self.observe(cache, 2)
        cache.observe_accepted_activity(
            session_id=state.session_id,
            kind=AcceptedActivityKind.CAST,
            source_message_type="MATCH_CARD_USE_RES",
            source_srv_seq=20,
            source_turn=3,
            source_timestamp="server-action",
            observed_timestamp="local-action",
        )
        reset = cache.observe_server_payload(
            session_id=state.session_id,
            username="happi",
            idle_count=1,
            threshold=3,
            source_message_type="MATCH_TURN_END",
            source_srv_seq=21,
            source_turn=5,
            source_timestamp="server-idle",
            observed_timestamp="local-idle",
        )
        self.assertEqual(
            reset.reset_confidence,
            ResetConfidence.RESET_CONFIRMED_BY_SERVER_SEQUENCE,
        )
        self.assertEqual(reset.reset_from_idle_count, 2)
        self.assertEqual(reset.reset_activity.kind, AcceptedActivityKind.CAST)

    def test_lower_payload_without_sequence_is_only_strongly_inferred(self) -> None:
        cache = GameOwnedIdleCache()
        state = self.observe(cache, 2)
        cache.observe_accepted_activity(
            session_id=state.session_id,
            kind=AcceptedActivityKind.EVOLVE,
            source_message_type="MATCH_FUSION_RES",
            source_srv_seq=None,
            source_turn=3,
            source_timestamp=None,
            observed_timestamp="local-action",
        )
        reset = cache.observe_server_payload(
            session_id=state.session_id,
            username="happi",
            idle_count=1,
            threshold=3,
            source_message_type="MATCH_TURN_END",
            source_srv_seq=None,
            source_turn=5,
            source_timestamp=None,
            observed_timestamp="local-idle",
        )
        self.assertEqual(
            reset.reset_confidence,
            ResetConfidence.RESET_STRONGLY_INFERRED,
        )

    def test_explicit_zero_is_not_inferred(self) -> None:
        cache = GameOwnedIdleCache()
        state = self.observe(cache, 2)
        reset = cache.observe_server_payload(
            session_id=state.session_id,
            username="happi",
            idle_count=0,
            threshold=3,
            source_message_type="MATCH_AFK_WARN",
            source_srv_seq=None,
            source_turn=None,
            source_timestamp=None,
            observed_timestamp="now",
        )
        self.assertEqual(
            reset.reset_confidence,
            ResetConfidence.RESET_CONFIRMED_EXPLICIT,
        )

    def test_turn_associated_explicit_zero_allows_pass(self) -> None:
        cache = GameOwnedIdleCache()
        state = cache.observe_server_payload(
            session_id="epoch=1|board=0x1234|match=M_test",
            username="happi",
            idle_count=0,
            threshold=3,
            source_message_type="MATCH_TURN_END",
            source_srv_seq=22,
            source_turn=3,
            source_timestamp="server",
            observed_timestamp="local",
        )
        result = cache.pass_readiness(
            current_session_id=state.session_id,
            local_username="happi",
            current_turn=3,
            is_local_turn=True,
            lifecycle_active=True,
        )
        self.assertEqual(result.readiness, PassReadiness.PASS_ALLOWED)

    def test_lifecycle_exit_clears_cache_and_blocks_pass(self) -> None:
        cache = GameOwnedIdleCache()
        state = self.observe(cache, 1)
        cache.end_session(state.session_id)
        self.assertIsNone(cache.state)
        readiness = cache.pass_readiness(
            current_session_id=None,
            local_username="happi",
            current_turn=3,
            is_local_turn=True,
            lifecycle_active=False,
        )
        self.assertEqual(readiness.readiness, PassReadiness.UNKNOWN)
        self.assertEqual(readiness.reason, "combat_lifecycle_not_active")

    def test_invalid_payload_is_rejected_instead_of_clamped(self) -> None:
        cache = GameOwnedIdleCache()
        with self.assertRaises(ValueError):
            cache.observe_server_payload(
                session_id="s",
                username="happi",
                idle_count=4,
                threshold=3,
                source_message_type="MATCH_AFK_WARN",
                source_srv_seq=None,
                source_turn=None,
                source_timestamp=None,
                observed_timestamp="now",
            )

    def test_same_one_after_ordered_swap_is_reset_proof_without_local_zero(self) -> None:
        cache = GameOwnedIdleCache(required_reset_confirmations=2)
        before = self.observe(cache, 1)
        cache.observe_accepted_activity(
            session_id=before.session_id,
            kind=AcceptedActivityKind.SWAP,
            source_message_type="MATCH_MOVE_RES",
            source_srv_seq=20,
            source_turn=3,
            source_timestamp="action",
            observed_timestamp="action-local",
        )
        after = cache.observe_server_payload(
            session_id=before.session_id,
            username="happi",
            idle_count=1,
            threshold=3,
            source_message_type="MATCH_TURN_END",
            source_srv_seq=21,
            source_turn=5,
            source_timestamp="idle",
            observed_timestamp="idle-local",
        )
        self.assertEqual(after.idle_count, 1)
        self.assertEqual(
            after.reset_confidence,
            ResetConfidence.RESET_CONFIRMED_BY_SERVER_SEQUENCE,
        )
        capability = cache.reset_capability(AcceptedActivityKind.SWAP)
        self.assertEqual(capability.confirmations, 1)
        self.assertFalse(capability.production_ready)

    def test_two_ordered_swap_reset_proofs_enable_non_numeric_baseline(self) -> None:
        seeded = ResetCapability(
            kind=AcceptedActivityKind.SWAP,
            confirmations=2,
            required_confirmations=2,
            confidence=ResetConfidence.RESET_CONFIRMED_BY_SERVER_SEQUENCE,
            proof_identities=(("proof-1",), ("proof-2",)),
        )
        cache = GameOwnedIdleCache(seeded_capabilities=(seeded,))
        session = "epoch=1|board=0x1234|match=M_test"
        cache.begin_session(session)
        cache.observe_accepted_activity(
            session_id=session,
            kind=AcceptedActivityKind.SWAP,
            source_message_type="MATCH_MOVE_RES",
            source_srv_seq=30,
            source_turn=7,
            source_timestamp="action",
            observed_timestamp="local",
        )
        readiness = cache.pass_readiness(
            current_session_id=session,
            local_username="happi",
            current_turn=9,
            is_local_turn=True,
            lifecycle_active=True,
            is_first_local_turn=False,
        )
        self.assertEqual(
            readiness.readiness, PassReadiness.RESET_BASELINE_CONFIRMED
        )
        self.assertTrue(readiness.can_pass_now)
        self.assertIsNone(readiness.state)

    def test_rejected_swap_does_not_reset_or_invalidate_exact_idle(self) -> None:
        cache = GameOwnedIdleCache()
        state = self.observe(cache, 2)
        cache.observe_rejected_activity(
            session_id=state.session_id, kind=AcceptedActivityKind.SWAP
        )
        self.assertEqual(cache.state, state)
        self.assertIsNone(cache.reset_baseline)
        self.assertIsNone(cache.pending_reset_activity)

    def test_evolve_does_not_reset_or_stale_idle(self) -> None:
        cache = GameOwnedIdleCache()
        state = self.observe(cache, 1)
        cache.observe_accepted_activity(
            session_id=state.session_id,
            kind=AcceptedActivityKind.EVOLVE,
            source_message_type="MATCH_FUSION_RES",
            source_srv_seq=None,
            source_turn=3,
            source_timestamp="fusion",
            observed_timestamp="local",
        )
        self.assertEqual(cache.state, state)
        self.assertIsNone(cache.pending_reset_activity)
        self.assertIsNone(cache.reset_baseline)

    def test_stale_nested_idle_turn_is_rejected(self) -> None:
        cache = GameOwnedIdleCache()
        current = self.observe(cache, 1)
        with self.assertRaisesRegex(ValueError, "stale"):
            cache.observe_server_payload(
                session_id=current.session_id,
                username="happi",
                idle_count=2,
                threshold=3,
                source_message_type="MATCH_TURN_END",
                source_srv_seq=None,
                source_turn=1,
                source_timestamp="old",
                observed_timestamp="late-scan",
            )
        self.assertEqual(cache.state, current)

    def test_first_turn_forbids_pass_even_with_reset_baseline(self) -> None:
        seeded = ResetCapability(
            kind=AcceptedActivityKind.SWAP,
            confirmations=2,
            required_confirmations=2,
            confidence=ResetConfidence.RESET_CONFIRMED_BY_SERVER_SEQUENCE,
            proof_identities=(("p1",), ("p2",)),
        )
        cache = GameOwnedIdleCache(seeded_capabilities=(seeded,))
        session = "epoch=1|board=0x1234|match=M_test"
        cache.observe_accepted_activity(
            session_id=session,
            kind=AcceptedActivityKind.SWAP,
            source_message_type="MATCH_MOVE_RES",
            source_srv_seq=1,
            source_turn=0,
            source_timestamp="action",
            observed_timestamp="local",
        )
        readiness = cache.pass_readiness(
            current_session_id=session,
            local_username="happi",
            current_turn=1,
            is_local_turn=True,
            lifecycle_active=True,
            is_first_local_turn=True,
        )
        self.assertEqual(
            readiness.readiness,
            PassReadiness.PASS_FORBIDDEN_MANDATORY_ACTION,
        )


if __name__ == "__main__":
    unittest.main()
