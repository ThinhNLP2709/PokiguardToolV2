from __future__ import annotations

from pathlib import Path
import sys
import tempfile
import unittest
from types import SimpleNamespace
from unittest.mock import Mock, patch


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.action_control import (  # noqa: E402
    AckOutcome,
    AckStatus,
    ActionIdentity,
    ActionLock,
    invalidate_pending_for_sequence_desync,
)
from pokiguard_v2.actionability import (  # noqa: E402
    ActionabilityGate,
    GateReason,
)
from pokiguard_v2.combat_lifecycle import CombatLifecycleState  # noqa: E402
from pokiguard_v2.il2cpp_external import MemoryRegion  # noqa: E402
from pokiguard_v2.memory_scan import QwordScanResult  # noqa: E402
from pokiguard_v2.state import BattleState, GamePhase, GameState  # noqa: E402
from pokiguard_v2.sequence_desync import (  # noqa: E402
    BoardTerminalKind,
    RecoveryLifecycleState,
    RecoveryStateMachine,
    SequenceDesyncSource,
    SequenceDesyncState,
    SequenceDesyncTracker,
    SequenceRejectKind,
    classify_board_terminal,
    classify_sequence_signal,
)
from pokiguard_v2.sequence_desync_artifacts import (  # noqa: E402
    write_sequence_desync_artifact,
)
from pokiguard_v2.win32_screenshot import write_png_rgb  # noqa: E402
from tools.replay_sequence_desync import replay  # noqa: E402
from tools.sequence_desync_runtime import (  # noqa: E402
    RuntimeSequenceMonitor,
    _current_learned_regions,
)
try:  # unittest discovery adds tests/ directly; module execution does not.
    from test_actionability import SESSION, actionable_state, context  # type: ignore  # noqa: E402
except ModuleNotFoundError:  # pragma: no cover - invocation dependent
    from tests.test_actionability import SESSION, actionable_state, context  # noqa: E402


class SequenceClassificationTests(unittest.TestCase):
    def test_force_resync_detection(self) -> None:
        signal = classify_sequence_signal(
            event_type="MATCH_REJECT", reject_reason="FORCE_RESYNC"
        )
        self.assertIsNotNone(signal)
        self.assertEqual(signal.sources, (SequenceDesyncSource.FORCE_RESYNC,))
        self.assertEqual(signal.evidence_field, "ChatMessageDTO.rejectReason")


class RuntimeRegionLearningTests(unittest.TestCase):
    def test_pass_wait_can_force_all_candidate_regions(self) -> None:
        learned = MemoryRegion(0x1000, 0x1000, 0x04, 0x20000)
        newly_allocated = MemoryRegion(0x4000, 0x1000, 0x04, 0x20000)
        monitor = RuntimeSequenceMonitor.__new__(RuntimeSequenceMonitor)
        monitor.target = SimpleNamespace(memory=object())
        monitor.max_region_mib = 8
        monitor.chunk_mib = 2
        monitor.full_rescan_interval = 999
        monitor.minimum_scan_seconds = 0.0
        monitor.tracker = Mock()
        monitor.events = Mock()
        monitor._dto_class = 0xABC
        monitor._learned_regions = {learned}
        monitor._seen = set()
        monitor._scans = 0
        monitor._last_scan = 0.0
        monitor._current_match_start = None
        runtime = SimpleNamespace(
            match_id="M_fixture",
            local_move_sequence=0,
            last_move_sequence=None,
            highest_acked_sequence=None,
        )
        scan = QwordScanResult({"chat_message": ()}, 0, 0x2000, 0)

        with (
            patch(
                "tools.sequence_desync_runtime.read_match_runtime",
                return_value=(0x1234, runtime),
            ),
            patch(
                "tools.sequence_desync_runtime._regions",
                return_value=(learned, newly_allocated),
            ),
            patch(
                "tools.sequence_desync_runtime.scan_aligned_qwords",
                return_value=scan,
            ) as scanner,
        ):
            observation = monitor.poll(
                session_key=(1,),
                match_id="M_fixture",
                turn=3,
                srv_seq=7,
                timestamp="now",
                force_full_scan=True,
            )

        self.assertEqual(
            tuple(scanner.call_args.args[1]), (learned, newly_allocated)
        )
        self.assertTrue(observation.scan_performed)
        self.assertTrue(observation.full_scan_performed)

    def test_rebinds_evidenced_range_to_current_region_descriptor(self) -> None:
        old = MemoryRegion(0x1000, 0x2000, 0x04, 0x20000)
        grown = MemoryRegion(0x1000, 0x3000, 0x04, 0x20000)
        unrelated = MemoryRegion(0x9000, 0x1000, 0x04, 0x20000)

        self.assertEqual(
            _current_learned_regions((grown, unrelated), (old,)),
            (grown,),
        )

    def test_begin_session_retains_process_lifetime_region_evidence(self) -> None:
        region = MemoryRegion(0x1000, 0x2000, 0x04, 0x20000)
        monitor = RuntimeSequenceMonitor.__new__(RuntimeSequenceMonitor)
        monitor.tracker = Mock(begin_session=Mock(return_value=True))
        monitor._learned_regions = {region}
        monitor._seen = {("old",)}
        monitor._last_scan = 5.0
        monitor._current_match_start = object()

        self.assertTrue(monitor.begin_session((1,), "M_new", clean=True))

        self.assertEqual(monitor._learned_regions, {region})
        self.assertEqual(monitor._seen, set())

    def test_lobby_prime_learns_only_regions_containing_class_hits(self) -> None:
        hit_region = MemoryRegion(0x1000, 0x1000, 0x04, 0x20000)
        empty_region = MemoryRegion(0x4000, 0x1000, 0x04, 0x20000)
        monitor = RuntimeSequenceMonitor.__new__(RuntimeSequenceMonitor)
        monitor.target = SimpleNamespace(
            memory=object(),
            resolver=Mock(resolve_type_info_class=Mock(return_value=0xABC)),
        )
        monitor.max_region_mib = 16
        monitor.chunk_mib = 2
        monitor._dto_class = 0xABC
        monitor._learned_regions = set()
        scan = QwordScanResult(
            {"chat_message": (0x1080,)}, 2, 0x2000, 0
        )
        with (
            patch(
                "tools.sequence_desync_runtime._regions",
                return_value=(hit_region, empty_region),
            ),
            patch(
                "tools.sequence_desync_runtime.scan_aligned_qwords",
                return_value=scan,
            ),
        ):
            result = monitor.prime_regions()

        self.assertEqual(monitor._learned_regions, {hit_region})
        self.assertEqual(result.learned_regions, 1)
        self.assertEqual(result.message_hits, 1)

    def test_entry_region_prime_reuses_live_process_evidence_without_scan(self) -> None:
        old = MemoryRegion(0x1000, 0x1000, 0x04, 0x20000)
        current = MemoryRegion(0x1000, 0x1800, 0x04, 0x20000)
        monitor = RuntimeSequenceMonitor.__new__(RuntimeSequenceMonitor)
        monitor.target = SimpleNamespace(memory=object())
        monitor.max_region_mib = 8
        monitor._dto_class = 0xABC
        monitor._learned_regions = {old}
        monitor.prime_regions = Mock()

        with patch(
            "tools.sequence_desync_runtime._regions", return_value=(current,)
        ):
            result = monitor.ensure_regions_primed()

        self.assertEqual(monitor._learned_regions, {current})
        self.assertEqual(result.learned_regions, 1)
        self.assertEqual(result.scanned_bytes, 0)
        monitor.prime_regions.assert_not_called()

    def test_entry_region_prime_rescans_at_lobby_after_heap_reset(self) -> None:
        old = MemoryRegion(0x1000, 0x1000, 0x04, 0x20000)
        replacement = MemoryRegion(0x9000, 0x1000, 0x04, 0x20000)
        expected = SimpleNamespace(scanned_bytes=123)
        monitor = RuntimeSequenceMonitor.__new__(RuntimeSequenceMonitor)
        monitor.target = SimpleNamespace(memory=object())
        monitor.max_region_mib = 8
        monitor._dto_class = 0xABC
        monitor._learned_regions = {old}
        monitor.prime_regions = Mock(return_value=expected)

        with patch(
            "tools.sequence_desync_runtime._regions", return_value=(replacement,)
        ):
            result = monitor.ensure_regions_primed()

        self.assertIs(result, expected)
        self.assertEqual(monitor._learned_regions, set())
        monitor.prime_regions.assert_called_once_with()

    def test_gap_and_duplicate_rejects(self) -> None:
        gap = classify_sequence_signal(
            event_type="MATCH_REJECT", reject_code="SEQ_GAP"
        )
        duplicate = classify_sequence_signal(
            event_type="MATCH_REJECT", reject_reason="SeqNum duplicate"
        )
        combined = classify_sequence_signal(
            event_type="MATCH_REJECT",
            reject_reason="SeqNum gap/duplicate — resync needed",
        )
        self.assertEqual(gap.reject_kind, SequenceRejectKind.SEQ_GAP)
        self.assertEqual(duplicate.reject_kind, SequenceRejectKind.SEQ_DUPLICATE)
        self.assertEqual(combined.reject_kind, SequenceRejectKind.MULTIPLE)
        self.assertEqual(
            classify_sequence_signal(
                event_type="MATCH_REJECT",
                reject_code="MATCH_REJECT_SEQ_GAP",
            ).reject_kind,
            SequenceRejectKind.SEQ_GAP,
        )

    def test_unrelated_reject_and_structured_precedence(self) -> None:
        self.assertIsNone(
            classify_sequence_signal(
                event_type="MATCH_REJECT", reject_reason="NOT_ENOUGH_MANA"
            )
        )
        self.assertIsNone(
            classify_sequence_signal(
                event_type="MATCH_REJECT",
                reject_code="CARD_COOLDOWN",
                fallback_text="SeqNum gap",
            )
        )


class SequenceTrackerTests(unittest.TestCase):
    def test_terminal_is_sticky_until_clean_new_session(self) -> None:
        tracker = SequenceDesyncTracker()
        self.assertTrue(tracker.begin_session("s1", "m1", clean=True))
        signal = classify_sequence_signal(
            event_type="MATCH_REJECT", reject_reason="FORCE_RESYNC"
        )
        self.assertTrue(
            tracker.observe(
                signal,
                timestamp="t1",
                session_key="s1",
                match_id="m1",
                turn=31,
                srv_seq=30,
            )
        )
        self.assertFalse(
            tracker.observe(
                None,
                timestamp="t2",
                session_key="s1",
                match_id="m1",
                turn=32,
                srv_seq=31,
            )
        )
        self.assertTrue(tracker.state.terminal_for_session)
        self.assertFalse(tracker.begin_session("s2", "m2", clean=True))
        self.assertTrue(tracker.state.detected)
        tracker.end_session("s1")
        self.assertTrue(tracker.begin_session("s2", "m2", clean=True))
        self.assertFalse(tracker.state.detected)

    def test_sources_aggregate_and_reject_count(self) -> None:
        tracker = SequenceDesyncTracker()
        tracker.begin_session("s", "m", clean=True)
        for timestamp, reason in (
            ("1", "FORCE_RESYNC"),
            ("2", "SeqNum gap/duplicate — resync needed"),
        ):
            tracker.observe(
                classify_sequence_signal(
                    event_type="MATCH_REJECT", reject_reason=reason
                ),
                timestamp=timestamp,
                session_key="s",
                match_id="m",
                turn=31,
                srv_seq=30,
            )
        self.assertEqual(tracker.state.source, SequenceDesyncSource.MULTIPLE)
        self.assertEqual(tracker.state.reject_count, 2)

    def test_stale_old_match_signal_is_ignored(self) -> None:
        tracker = SequenceDesyncTracker()
        tracker.begin_session("new", "m2", clean=True)
        first = tracker.observe(
            classify_sequence_signal(
                event_type="MATCH_REJECT", reject_reason="SEQ_GAP"
            ),
            timestamp="t",
            session_key="old",
            match_id="m1",
            turn=1,
            srv_seq=1,
        )
        self.assertFalse(first)
        self.assertFalse(tracker.state.detected)


class SequenceIntegrationTests(unittest.TestCase):
    def test_gate_blocks_before_normal_actionability(self) -> None:
        desync = SequenceDesyncState(
            detected=True,
            source=SequenceDesyncSource.FORCE_RESYNC,
            first_seen_at="t",
            last_seen_at="t",
            session_key=SESSION,
            match_id=SESSION.match_id,
            turn=31,
            srv_seq=75,
            reject_count=1,
            terminal_for_session=True,
        )
        result = ActionabilityGate.evaluate(
            actionable_state(), context(sequence_desync=desync)
        )
        self.assertFalse(result.actionable)
        self.assertEqual(result.reason, GateReason.SEQUENCE_DESYNC)
        lobby = GameState(
            GamePhase.LOBBY,
            "now",
            battle=BattleState(combat_lifecycle=CombatLifecycleState.LOBBY),
        )
        self.assertEqual(
            ActionabilityGate.evaluate(
                lobby, context(sequence_desync=desync)
            ).reason,
            GateReason.SEQUENCE_DESYNC,
        )

    def test_pending_action_is_immediately_rejected_without_retry(self) -> None:
        identity = ActionIdentity(SESSION, 75, "a" * 64, (4, 2), (4, 3))
        lock = ActionLock(timeout_seconds=7)
        self.assertTrue(lock.reserve(identity))
        lock.begin(
            identity,
            source_turn_number=10,
            source_turn_player="happi",
            now=100,
        )
        invalidation = invalidate_pending_for_sequence_desync(
            object(), lock, now=100.25
        )
        self.assertTrue(invalidation.proposal_invalidated)
        result = invalidation.action_result
        self.assertIsNotNone(result)
        self.assertEqual(result.status, AckStatus.REJECTED)
        self.assertEqual(result.outcome, AckOutcome.REJECTED_SEQUENCE_DESYNC)
        self.assertFalse(lock.locked)
        self.assertFalse(lock.reserve(identity))

    def test_captured_log_replay_is_terminal(self) -> None:
        tracker = replay(
            PROJECT_ROOT / "reference" / "sequence_desync_m714b231e.jsonl"
        )
        self.assertTrue(tracker.state.detected)
        self.assertTrue(tracker.state.terminal_for_session)
        self.assertEqual(tracker.state.match_id, "M_714b231e")
        self.assertEqual(tracker.state.source, SequenceDesyncSource.MULTIPLE)
        self.assertEqual(tracker.state.first_seen_at, "2026-08-12T19:40:00.357Z")

    def test_three_terminal_board_states_never_mix(self) -> None:
        self.assertEqual(
            classify_board_terminal(
                legal_move_count=0, safe_move_count=0, sequence_desync=None
            ),
            BoardTerminalKind.DEAD_BOARD,
        )
        self.assertEqual(
            classify_board_terminal(
                legal_move_count=3,
                safe_move_count=0,
                sequence_desync=SequenceDesyncState(
                    detected=True, terminal_for_session=True
                ),
            ),
            BoardTerminalKind.SEQUENCE_DESYNC,
        )
        self.assertEqual(
            classify_board_terminal(
                legal_move_count=3, safe_move_count=0, sequence_desync=None
            ),
            BoardTerminalKind.POLICY_NO_SAFE_MOVE,
        )

    def test_recovery_transitions_and_stale_match_exit(self) -> None:
        machine = RecoveryStateMachine()
        machine.desync_detected()
        self.assertEqual(machine.state, RecoveryLifecycleState.RECOVERY_REQUIRED)
        self.assertTrue(machine.request())
        self.assertTrue(machine.exit_control_clicked())
        self.assertTrue(machine.modal_visible())
        machine.observe_lifecycle(CombatLifecycleState.STALE_SERVER_MATCH)
        self.assertEqual(machine.state, RecoveryLifecycleState.BOSS_MAP_OR_LOBBY)
        self.assertTrue(machine.ready_for_new_match(clean_new_session=True))

    def test_artifact_contains_all_four_required_files(self) -> None:
        desync = SequenceDesyncState(
            detected=True,
            source=SequenceDesyncSource.FORCE_RESYNC,
            first_seen_at="2026-08-13T00:00:00.000Z",
            last_seen_at="2026-08-13T00:00:00.000Z",
            session_key=SESSION,
            match_id=SESSION.match_id,
            terminal_for_session=True,
        )
        with tempfile.TemporaryDirectory() as temporary:
            def screenshot(path: Path):
                write_png_rgb(path, 1, 1, b"\x00\x00\x00")
                return {"test": True}

            artifact = write_sequence_desync_artifact(
                Path(temporary),
                desync=desync,
                state=actionable_state(),
                recent_events=({"event": "FORCE_RESYNC"},),
                screenshot_writer=screenshot,
            )
            self.assertTrue(artifact.state_json.is_file())
            self.assertTrue(artifact.board_json.is_file())
            self.assertTrue(artifact.screenshot.is_file())
            self.assertTrue(artifact.recent_events_json.is_file())


if __name__ == "__main__":
    unittest.main()
