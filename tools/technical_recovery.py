#!/usr/bin/env python3
"""Phase 2D.3 bounded automatic technical recovery and controlled re-entry.

Live test mode is explicit and does not claim a real technical failure.  The
runner sends only normal foreground recovery/entry UI input, permits one
recovery, and hard-stops at the fresh 64-cell opening with gameplay disabled.
"""

from __future__ import annotations

import argparse
from argparse import Namespace
from contextlib import nullcontext
import json
from pathlib import Path
import sys
import time
from typing import Any, Sequence

try:
    import winsound
except ImportError:  # pragma: no cover - production is Windows-only
    winsound = None


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.app_paths import current_app_paths  # noqa: E402
from pokiguard_v2.board_diagnostics import (  # noqa: E402
    analyze_game_state,
    diagnostic_board_hash,
)
from pokiguard_v2.boss_entry import (  # noqa: E402
    BossLobbyState,
    FarmTarget,
    TargetResolutionStatus,
    TargetSelectionState,
    resolve_target,
)
from pokiguard_v2.combat_lifecycle import (  # noqa: E402
    CombatLifecycleState,
    CombatSessionTracker,
)
from pokiguard_v2.controller_lease import AutomationControllerLease  # noqa: E402
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
)
from pokiguard_v2.il2cpp_external import ExternalReadError  # noqa: E402
from pokiguard_v2.il2cpp_layout import LayoutValidationError  # noqa: E402
from pokiguard_v2.recovery_ui import locate_confirm_leave, locate_exit_back  # noqa: E402
from pokiguard_v2.state import (  # noqa: E402
    BattleState,
    BoardState,
    CellState,
    CombatSessionKey,
    GamePhase,
    GameState,
    GemType,
)
from pokiguard_v2.technical_recovery import (  # noqa: E402
    FailedSessionEvidence,
    RecoveredOpeningEvidence,
    RecoveryArtifactWriter,
    RecoveryInputDomain,
    RecoveryReentryCapability,
    TechnicalRecoveryCoordinator,
    TechnicalRecoveryDispatcher,
    TechnicalRecoveryResult,
    TechnicalRecoveryState,
)
from pokiguard_v2.win32_input import (  # noqa: E402
    CoordinateSafetyError,
    ForegroundClickExecutor,
    HotkeyEdges,
    NativeWin32Backend,
    find_window_for_pid,
)
from pokiguard_v2.win32_screenshot import (  # noqa: E402
    capture_client_rgb,
    write_png_rgb,
)
from tools import boss_entry  # noqa: E402
from tools.farm_cycle import _wait_boss_lobby  # noqa: E402
from tools.idle_state_watch import read_match_runtime  # noqa: E402
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.replay_sequence_desync import replay  # noqa: E402
from tools.runtime_common import attach_target  # noqa: E402
from tools.sequence_desync_runtime import RuntimeSequenceMonitor  # noqa: E402
from tools.sequence_recovery import _live_exit_calibration, _locate_temporally  # noqa: E402


RECOVERED_HANDOFF_GUARD_SECONDS = 2.5
RECOVERY_ACK_EPOCH_WAIT_SECONDS = 15.0
RECOVERY_FROZEN_ACK_MIN_SECONDS = 2.0
RECOVERY_FROZEN_ACK_MIN_SAMPLES = 8


def _usable_calibrated_exit(candidate: Any | None) -> Any | None:
    """Return only a complete, live-proven exit calibration candidate."""

    if (
        candidate is None
        or not candidate.found
        or candidate.normalized_point is None
    ):
        return None
    return candidate


def _recovery_lobby_ack_epoch_rejection(
    *,
    match_id: str | None,
    highest_acked_sequence: int | None,
) -> str | None:
    """Require a clean MatchService epoch before recovery re-entry.

    A forced combat exit can leave ``MatchService._ackedSeqs`` populated in
    the boss lobby. The next MATCH_START initially looks pristine, but the
    retained ACK watermark can become visible only after the re-entry input.
    At that point the new match's small sequence numbers collide with the old
    match and no read-only provider can safely decide which ACK owns a board.

    This lobby check therefore happens *before* RECOVERY_REENTRY is reserved.
    It is intentionally stricter than normal postmatch entry: technical
    recovery must not spend another match merely to rediscover known stale
    transport state.
    """

    if match_id is not None:
        return "RECOVERY_LOBBY_MATCH_NOT_CLEARED"
    if highest_acked_sequence is not None:
        return "RECOVERY_ACK_EPOCH_NOT_RESET"
    return None


def _wait_for_clean_recovery_lobby_ack_epoch(
    process: Any,
    *,
    timeout: float,
    interval: float,
    reader: Any | None = None,
    monotonic: Any | None = None,
    sleeper: Any | None = None,
) -> tuple[str | None, int | None, Any | None, int]:
    """Read-only bounded wait for a safe recovery-lobby ACK boundary.

    A forced exit can leave ``MatchService._ackedSeqs`` populated for several
    lobby frames.  Prefer a fully cleared epoch.  Live exact-25 evidence also
    proved that a normal, owner-free boss lobby can retain the prior ACK and
    local-move watermarks indefinitely; normal entry clears them only while
    binding the next MATCH_START session.

    A dirty epoch is therefore eligible for *deferred reset* only after the
    MatchService address, highest ACK, and local move sequence remain identical
    for a bounded duration/sample count while ``CurrentMatchId`` stays null.
    The caller has already proved an exact boss lobby and no provider session,
    re-proves that lobby after this wait, and the recovered handoff still
    requires a distinct pristine MATCH_START plus a cleared ACK epoch before
    gameplay unlocks.  Advancing, unreadable, or still-owned state fails
    closed.
    """

    read = read_match_runtime if reader is None else reader
    now = time.monotonic if monotonic is None else monotonic
    sleep = time.sleep if sleeper is None else sleeper
    started_at = now()
    deadline = started_at + max(0.0, float(timeout))
    samples = 0
    last_rejection = "RECOVERY_LOBBY_ACK_EPOCH_UNREADABLE"
    last_match_service: int | None = None
    last_runtime: Any | None = None
    frozen_signature: tuple[int, int, int] | None = None
    frozen_since: float | None = None
    frozen_samples = 0
    while True:
        sampled_at = now()
        samples += 1
        try:
            last_match_service, last_runtime = read(process)
            last_rejection = _recovery_lobby_ack_epoch_rejection(
                match_id=last_runtime.match_id,
                highest_acked_sequence=last_runtime.highest_acked_sequence,
            )
        except (ExternalReadError, OSError, LayoutValidationError, TypeError):
            last_rejection = "RECOVERY_LOBBY_ACK_EPOCH_UNREADABLE"
            last_match_service = None
            last_runtime = None
        if last_rejection is None:
            return None, last_match_service, last_runtime, samples

        local_move_sequence = (
            getattr(last_runtime, "local_move_sequence", None)
            if last_runtime is not None
            else None
        )
        if (
            last_rejection == "RECOVERY_ACK_EPOCH_NOT_RESET"
            and last_match_service is not None
            and last_runtime is not None
            and last_runtime.match_id is None
            and isinstance(last_runtime.highest_acked_sequence, int)
            and isinstance(local_move_sequence, int)
            and local_move_sequence >= 0
        ):
            signature = (
                int(last_match_service),
                int(last_runtime.highest_acked_sequence),
                int(local_move_sequence),
            )
            if signature != frozen_signature:
                frozen_signature = signature
                frozen_since = sampled_at
                frozen_samples = 1
            else:
                frozen_samples += 1
            if (
                frozen_since is not None
                and frozen_samples >= RECOVERY_FROZEN_ACK_MIN_SAMPLES
                and sampled_at - frozen_since >= RECOVERY_FROZEN_ACK_MIN_SECONDS
            ):
                return None, last_match_service, last_runtime, samples
        else:
            frozen_signature = None
            frozen_since = None
            frozen_samples = 0

        if sampled_at >= deadline:
            return last_rejection, last_match_service, last_runtime, samples
        sleep(max(0.02, float(interval)))


def _recovered_handoff_rejection(
    *,
    expected_session: CombatSessionKey,
    current_session: CombatSessionKey | None,
    highest_acked_sequence: int | None,
    state: GameState | None,
    recovery_ack_epoch_isolated: bool = False,
) -> str | None:
    """Reject runtime evidence that leaked across a recovery re-entry.

    A normal new match clears ``MatchService._ackedSeqs`` before the pristine
    first local turn. Live evidence also proved a frozen old watermark can
    survive the distinct recovered MATCH_START. It remains acceptable only
    when the provider explicitly isolates it and publishes exact new-session
    opening/transport/BoardWs evidence; a raw non-null ACK without that scope
    is still rejected.
    """

    if current_session != expected_session:
        return "RECOVERY_HANDOFF_SESSION_CHANGED"
    if highest_acked_sequence is not None and not recovery_ack_epoch_isolated:
        return "RECOVERY_ACK_EPOCH_NOT_RESET"
    if state is None:
        return None
    battle = state.battle
    if (
        battle.session_key != expected_session
        or battle.match_id != expected_session.match_id
    ):
        return "RECOVERY_HANDOFF_STATE_SESSION_CHANGED"
    if battle.turn_number not in (0, 1):
        return "RECOVERY_HANDOFF_FIRST_TURN_LOST"
    if battle.local_move_sequence != 0 or battle.last_move_sequence not in (
        None,
        -1,
        0,
    ):
        return "RECOVERY_HANDOFF_ACTION_STATE_NOT_PRISTINE"
    return None


def _guard_recovered_handoff(
    provider: MemoryBoardStateProvider,
    expected_session: CombatSessionKey,
    *,
    interval: float,
    duration: float = RECOVERED_HANDOFF_GUARD_SECONDS,
) -> tuple[bool, dict[str, Any]]:
    """Keep gameplay locked briefly while the new ACK epoch settles."""

    deadline = time.monotonic() + max(0.0, duration)
    clean_state_samples = 0
    polls = 0
    last_reason: str | None = None
    last_timer: int | None = None
    ack_epoch_dirty = False
    ack_epoch_isolated = False
    while True:
        poll = provider.poll()
        polls += 1
        state = poll.state
        isolation_probe = getattr(
            provider, "recovery_ack_epoch_isolated_for", None
        )
        current_ack_isolated = bool(
            callable(isolation_probe) and isolation_probe(expected_session)
        )
        if state is not None:
            last_timer = state.battle.turn_time_remaining_seconds
        rejection = _recovered_handoff_rejection(
            expected_session=expected_session,
            current_session=provider.current_session_key,
            highest_acked_sequence=provider.metrics.highest_acked_sequence,
            state=state,
            recovery_ack_epoch_isolated=current_ack_isolated,
        )
        if rejection == "RECOVERY_ACK_EPOCH_NOT_RESET":
            # A shared provider may enter this guard with the failed session's
            # last diagnostic gauge before its first new-session ACK read.
            # Keep gameplay locked for the complete bounded guard window.  A
            # genuinely delayed/retained ACK remains non-null at the deadline
            # and is still rejected; a lifecycle-reset gauge can settle to the
            # exact empty new-match epoch without abandoning a valid opening.
            ack_epoch_dirty = True
            last_reason = rejection
        elif rejection is not None:
            return False, {
                "reason": rejection,
                "polls": polls,
                "cleanStateSamples": clean_state_samples,
                "providerReason": poll.reason,
                "highestAckedSequence": provider.metrics.highest_acked_sequence,
                "turnTimeRemainingSeconds": last_timer,
            }
        elif state is not None:
            clean_state_samples += 1
            ack_epoch_dirty = False
            ack_epoch_isolated = current_ack_isolated
            last_reason = poll.reason
        elif rejection is None:
            last_reason = poll.reason
        if time.monotonic() >= deadline:
            break
        time.sleep(max(0.02, interval))

    final_ack = provider.metrics.highest_acked_sequence
    timer_safe = bool(last_timer is not None and last_timer > 4)
    isolation_probe = getattr(provider, "recovery_ack_epoch_isolated_for", None)
    final_isolated = bool(
        callable(isolation_probe) and isolation_probe(expected_session)
    )
    scan_diagnostics = getattr(provider, "scan_diagnostics", {})
    ack_epoch_clean = bool(
        (final_ack is None and not ack_epoch_dirty)
        or (final_isolated and ack_epoch_isolated)
    )
    accepted = clean_state_samples >= 2 and timer_safe and ack_epoch_clean
    terminal_reason = None
    if not ack_epoch_clean:
        terminal_reason = "RECOVERY_ACK_EPOCH_NOT_RESET"
    elif not accepted:
        terminal_reason = "RECOVERY_HANDOFF_NOT_STABLY_ACTIONABLE"
    return accepted, {
        "reason": terminal_reason,
        "polls": polls,
        "cleanStateSamples": clean_state_samples,
        "providerReason": last_reason,
        "highestAckedSequence": final_ack,
        "recoveryAckEpochIsolated": final_isolated,
        "effectiveAckedSequence": (
            scan_diagnostics.get("effectiveAckedSequence")
            if isinstance(scan_diagnostics, dict)
            else None
        ),
        "turnTimeRemainingSeconds": last_timer,
        "guardSeconds": max(0.0, duration),
    }


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    mode = parser.add_mutually_exclusive_group(required=True)
    mode.add_argument(
        "--stage-a-replay",
        action="store_true",
        help="offline captured-sequence/dead-board dispatch verification; inputs=0",
    )
    mode.add_argument(
        "--recovery-ui-test",
        action="store_true",
        help="explicit TEST_ONLY trigger in ACTIVE_COMBAT, then automatic exit/re-entry",
    )
    mode.add_argument(
        "--watch-production",
        action="store_true",
        help="wait for a natural sequence-desync or exact live dead board",
    )
    target = parser.add_mutually_exclusive_group()
    target.add_argument("--boss-id", help="exact runtime boss/enemy pet ID")
    target.add_argument("--boss-name", help="exact NFC/casefold boss name")
    parser.add_argument("--sequence-fixture", type=Path)
    parser.add_argument("--artifacts", type=Path)
    parser.add_argument("--interval", type=float, default=0.12)
    parser.add_argument("--trigger-timeout", type=float, default=300.0)
    parser.add_argument("--exit-locator-timeout", type=float, default=12.0)
    parser.add_argument("--modal-timeout", type=float, default=12.0)
    parser.add_argument("--local-exit-timeout", type=float, default=30.0)
    parser.add_argument("--lobby-timeout", type=float, default=60.0)
    parser.add_argument("--entry-timeout", type=float, default=45.0)
    parser.add_argument("--opening-timeout", type=float, default=35.0)
    parser.add_argument("--max-technical-recoveries", type=int, default=1)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--ack-heap-region-mib", type=int, default=16)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument("--no-beep", action="store_true")
    return parser


def _validate_args(args: Namespace) -> None:
    if not 0.08 <= args.interval <= 0.50:
        raise ValueError("--interval must be between 0.08 and 0.50 seconds")
    for name in (
        "trigger_timeout",
        "exit_locator_timeout",
        "modal_timeout",
        "local_exit_timeout",
        "lobby_timeout",
        "entry_timeout",
        "opening_timeout",
    ):
        if not 5 <= float(getattr(args, name)) <= 600:
            raise ValueError(f"--{name.replace('_', '-')} must be between 5 and 600 seconds")
    if args.max_technical_recoveries != 1:
        raise ValueError("Phase 2D.3 requires --max-technical-recoveries 1")
    if not 1 <= args.max_region_mib <= 32 or not 1 <= args.chunk_mib <= 16:
        raise ValueError("scan size arguments are outside safe bounds")
    if not args.max_region_mib <= args.ack_heap_region_mib <= 32:
        raise ValueError("--ack-heap-region-mib must cover --max-region-mib and be <= 32")
    if not args.stage_a_replay and not (args.boss_id or args.boss_name):
        raise ValueError("live recovery requires exact --boss-id or --boss-name")


def _beep(kind: str, enabled: bool) -> None:
    if not enabled or winsound is None:
        return
    try:
        if kind == "pass":
            winsound.Beep(1040, 180)
            winsound.Beep(1320, 260)
        else:
            winsound.Beep(880, 240)
            winsound.Beep(660, 240)
            winsound.Beep(440, 420)
    except RuntimeError:
        pass


def _offline_dead_board_state() -> GameState:
    gems = tuple(gem for gem in GemType if gem is not GemType.UNKNOWN)
    board = BoardState(
        tuple(
            tuple(
                CellState(row, col, gems[(row * 2 + col) % len(gems)], 1)
                for col in range(8)
            )
            for row in range(8)
        )
    )
    session = CombatSessionKey(1, 0x20000000000, "OFFLINE_DEAD_BOARD")
    return GameState(
        GamePhase.COMBAT,
        "2026-08-15T00:00:00.000Z",
        board=board,
        battle=BattleState(
            combat_lifecycle=CombatLifecycleState.ACTIVE,
            board_instance=session.board_instance,
            srv_seq=42,
            turn_number=17,
            current_turn_player="offline-local",
            stable=True,
            board_hash=diagnostic_board_hash(board),
            sources=("WsCombatBatch.board",),
            session_key=session,
            match_id=session.match_id,
            acknowledged=True,
            latest=True,
            is_board_ready=True,
            is_cascade_running=False,
            is_local_turn=True,
            client_move_allowed=True,
            turn_duration_seconds=14,
            turn_time_remaining_seconds=12,
            turn_timer_source="offline_fixture",
            local_move_sequence=8,
        ),
    )


def _run_stage_a(args: Namespace) -> int:
    root = (args.artifacts or current_app_paths().logs_root / "technical_recovery").resolve()
    fixture = (
        args.sequence_fixture
        or PROJECT_ROOT / "reference" / "sequence_desync_m714b231e.jsonl"
    ).resolve()

    tracker = replay(fixture)
    sequence = TechnicalRecoveryCoordinator(max_technical_recoveries=1)
    sequence_dispatch = TechnicalRecoveryDispatcher(sequence)
    sequence_ok = sequence_dispatch.dispatch_sequence_desync(
        tracker.state,
        evidence_source=f"captured replay:{fixture.name}",
    )
    sequence_artifact = RecoveryArtifactWriter.create(root)
    sequence_artifact.write_failure(sequence, None)
    sequence_artifact.event(
        "stage_a_sequence_replay",
        fixture=fixture,
        desync=tracker.state,
        dispatched=sequence_ok,
        gameplayLocked=sequence.gameplay_locked,
        actualUiInputs=0,
    )
    sequence_artifact.finalize(
        sequence,
        stage="A_SEQUENCE_REPLAY",
        stageResult=("PASS" if sequence_ok and sequence.gameplay_locked else "FAIL"),
        actualUiInputs=0,
    )

    dead_state = _offline_dead_board_state()
    dead_analysis = analyze_game_state(dead_state)
    dead = TechnicalRecoveryCoordinator(max_technical_recoveries=1)
    dead_dispatch = TechnicalRecoveryDispatcher(dead)
    dead_ok = dead_dispatch.dispatch_dead_board(dead_state, dead_analysis)
    dead_artifact = RecoveryArtifactWriter.create(root)
    dead_artifact.write_failure(dead, dead_state)
    dead_artifact.event(
        "stage_a_dead_board_fixture",
        liveRuntimeObserved=False,
        legalMoveCount=dead_analysis.legal_match_producing_moves,
        safeMoveCount=dead_analysis.safe_move_count,
        deadBoard=dead_analysis.dead_board,
        dispatched=dead_ok,
        gameplayLocked=dead.gameplay_locked,
        actualUiInputs=0,
    )
    dead_artifact.finalize(
        dead,
        stage="A_DEAD_BOARD_FIXTURE",
        stageResult=("PASS" if dead_ok and dead.gameplay_locked else "FAIL"),
        deadBoardRuntimeLive="NOT_OBSERVED",
        actualUiInputs=0,
    )

    policy = TechnicalRecoveryCoordinator(max_technical_recoveries=1)
    policy_dispatch = TechnicalRecoveryDispatcher(policy)
    policy_dispatched = policy_dispatch.dispatch_policy_no_safe_move(
        legal_move_count=2,
        safe_move_count=0,
    )
    nontechnical_ok = not policy_dispatched and policy.state is TechnicalRecoveryState.IDLE
    passed = bool(
        sequence_ok
        and sequence.gameplay_locked
        and dead_ok
        and dead.gameplay_locked
        and dead_analysis.legal_match_producing_moves == 0
        and nontechnical_ok
    )
    print(
        json.dumps(
            {
                "stage": "PHASE_2D3_STAGE_A",
                "accepted": passed,
                "sequenceFixture": str(fixture),
                "sequenceDispatch": sequence_ok,
                "sequenceGameplayLocked": sequence.gameplay_locked,
                "deadBoardDispatch": dead_ok,
                "deadBoardLegalMoves": dead_analysis.legal_match_producing_moves,
                "deadBoardRuntimeLive": "NOT_OBSERVED",
                "policyNoSafeMoveDispatch": policy_dispatched,
                "actualUiInputs": 0,
                "artifacts": [
                    str(sequence_artifact.directory),
                    str(dead_artifact.directory),
                ],
            },
            ensure_ascii=False,
            indent=2,
        ),
        flush=True,
    )
    return 0 if passed else 2


def _save_current_capture(pid: int, path: Path) -> bool:
    try:
        capture = capture_client_rgb(pid)
        write_png_rgb(path, capture.width, capture.height, capture.rgb)
        return path.is_file() and path.stat().st_size > 0
    except (OSError, RuntimeError, ValueError):
        return False


def _stop_requested(hotkeys: HotkeyEdges) -> bool:
    _unused_f8, f9 = hotkeys.poll()
    return bool(f9)


def _poll_farm_graceful_stop(shared_runtime: Any | None) -> bool:
    """Latch/register F6 without consuming it or interrupting required exit UI."""

    if shared_runtime is None:
        return False
    farm_hotkeys = getattr(shared_runtime, "farm_control_hotkeys", None)
    if farm_hotkeys is not None:
        farm_hotkeys.poll()
    capability = getattr(shared_runtime, "gameplay_capability", None)
    checker = getattr(capability, "graceful_stop_requested", None)
    return bool(checker is not None and checker())


def _farm_emergency_requested(shared_runtime: Any | None) -> bool:
    if shared_runtime is None:
        return False
    farm_hotkeys = getattr(shared_runtime, "farm_control_hotkeys", None)
    if farm_hotkeys is None:
        return False
    _graceful, emergency = farm_hotkeys.poll()
    return bool(emergency or getattr(farm_hotkeys, "emergency_requested", False))


def _any_emergency_stop_requested(
    hotkeys: HotkeyEdges,
    shared_runtime: Any | None,
) -> bool:
    return _stop_requested(hotkeys) or _farm_emergency_requested(shared_runtime)


def _execute_farm_controlled_input(
    shared_runtime: Any | None,
    operation: Any,
) -> tuple[bool, Any | None]:
    farm_hotkeys = (
        getattr(shared_runtime, "farm_control_hotkeys", None)
        if shared_runtime is not None
        else None
    )
    if farm_hotkeys is None:
        return True, operation()
    return farm_hotkeys.execute_if_authorized(operation)


def _failed_session_still_active(poll: Any, failed: FailedSessionEvidence) -> bool:
    lifecycle = poll.combat_lifecycle
    if lifecycle is not None and lifecycle.state is CombatLifecycleState.ACTIVE:
        signals = lifecycle.signals
        if (
            signals.match_id == failed.match_id
            and signals.board_instance == failed.board_instance
        ):
            return True

    # ``MemoryBoardStateProvider.poll`` issues ``session_key`` only after the
    # lifecycle sample made by that same poll classified the local rig as
    # ACTIVE.  Some ACTIVE branches intentionally return before publishing a
    # board (for example while waiting for the direct-owner batch), and those
    # branches do not carry the detailed lifecycle object.  The per-poll key is
    # therefore authoritative current evidence, unlike
    # ``provider.current_session_key`` which may be cached from an older poll.
    poll_session = getattr(poll, "session_key", None)
    if poll_session is not None and poll_session == failed.session_key:
        return bool(
            poll_session.match_id == failed.match_id
            and poll_session.board_instance == failed.board_instance
            and poll_session.lifecycle_epoch == failed.lifecycle_epoch
        )

    # A shared provider may return an actionable current GameState without a
    # second lifecycle observation on the same poll.  This is not a weaker
    # fallback: require the exact failed session, MatchId, Board.Instance and
    # ACTIVE lifecycle already bound into that published state.
    state = poll.state
    if state is None or state.phase is not GamePhase.COMBAT:
        return False
    battle = state.battle
    return bool(
        battle.combat_lifecycle is CombatLifecycleState.ACTIVE
        and battle.session_key == failed.session_key
        and battle.match_id == failed.match_id
        and battle.board_instance == failed.board_instance
    )


def _block_and_finalize(
    coordinator: TechnicalRecoveryCoordinator,
    artifacts: RecoveryArtifactWriter,
    result: TechnicalRecoveryResult,
    detail: str,
    *,
    event: str,
) -> int:
    coordinator.block(result, detail)
    artifacts.event(event, result=result, detail=detail)
    artifacts.finalize(coordinator, stage="B_LIVE", stageResult="SAFE_STOP")
    return 2


def _entry_args(args: Namespace, artifacts: Path) -> Namespace:
    return Namespace(
        inspect_only=False,
        stage_a=False,
        stage_b=True,
        boss_id=args.boss_id,
        boss_name=args.boss_name,
        lobby_timeout=args.lobby_timeout,
        entry_timeout=args.entry_timeout,
        opening_timeout=args.opening_timeout,
        interval=args.interval,
        max_region_mib=args.max_region_mib,
        chunk_mib=args.chunk_mib,
        artifacts=artifacts,
        no_beep=args.no_beep,
    )


def _recovered_opening(provider: MemoryBoardStateProvider) -> RecoveredOpeningEvidence | None:
    poll = provider.poll()
    state = poll.state
    session = provider.current_session_key
    if (
        session is None
        or state is None
        or state.board is None
        or state.battle.session_key != session
        or state.battle.srv_seq is None
    ):
        return None
    cells = tuple(cell for row in state.board.cells for cell in row)
    source = "ChatMessageDTO.MATCH_START.matchPayload.board"
    return RecoveredOpeningEvidence(
        session=session,
        match_id=session.match_id,
        board_hash=state.battle.board_hash or "",
        srv_seq=state.battle.srv_seq,
        complete_cells=len(cells),
        unique_coordinates=len({(cell.row, cell.col) for cell in cells}),
        source=source if source in state.battle.sources else "UNKNOWN",
        first_local_turn=state.battle.is_first_local_turn is True,
        local_move_sequence=state.battle.local_move_sequence,
        stable_confirmations=poll.confirmations,
        production_ready=state.board.production_ready,
        gem_types_valid=all(cell.gem is not GemType.UNKNOWN for cell in cells),
        multipliers_valid=all(cell.multiplier in (1, 2, 3, 4) for cell in cells),
        fresh_dto=source in state.battle.sources,
        timer_safe=(
            state.battle.turn_time_remaining_seconds is not None
            and state.battle.turn_time_remaining_seconds > 4
        ),
    )


def _recovered_opening_from_entry(
    result: dict[str, Any],
    session: CombatSessionKey | None,
) -> RecoveredOpeningEvidence | None:
    """Rehydrate the exact opening already accepted by Phase 2D.1.

    Re-polling after entry can consume the remaining opening-turn budget and
    can observe an unrelated transient provider branch.  The entry result is
    accepted only when its full session identity and hardened opening fields
    agree with the provider's current session.
    """

    if session is None or result.get("status") != "PASS":
        return None
    raw_session = result.get("session")
    if not isinstance(raw_session, dict):
        return None
    try:
        result_session = CombatSessionKey(
            int(raw_session["lifecycle_epoch"]),
            int(raw_session["board_instance"]),
            str(raw_session["match_id"]),
        )
        opening = RecoveredOpeningEvidence(
            session=result_session,
            match_id=str(result["matchId"]),
            board_hash=str(result["boardHash"]),
            srv_seq=int(result["srvSeq"]),
            complete_cells=int(result["openingCells"]),
            unique_coordinates=int(result["openingUniqueCoordinates"]),
            source=str(result["openingSource"]),
            first_local_turn=result["firstLocalTurn"] is True,
            local_move_sequence=int(result["localMoveSequence"]),
            stable_confirmations=int(result["stableConfirmations"]),
            production_ready=result["openingProductionReady"] is True,
            gem_types_valid=result["openingGemTypesValid"] is True,
            multipliers_valid=result["openingMultipliersValid"] is True,
            fresh_dto=result["openingFreshDto"] is True,
            timer_safe=(
                result["turnTimeRemainingSeconds"] is not None
                and float(result["turnTimeRemainingSeconds"]) > 4
            ),
        )
    except (KeyError, TypeError, ValueError):
        return None
    if result_session != session or opening.match_id != session.match_id:
        return None
    return opening


def _final_live_invariants(coordinator: TechnicalRecoveryCoordinator) -> tuple[bool, str]:
    snapshot = coordinator.snapshot()
    counts = {
        domain: sum(
            1 for record in snapshot.input_records if record.domain is domain and record.sent
        )
        for domain in RecoveryInputDomain
    }
    safety = snapshot.safety
    if snapshot.state is not TechnicalRecoveryState.RECOVERY_COMPLETE:
        return False, "RECOVERY_NOT_COMPLETE"
    if snapshot.result is not TechnicalRecoveryResult.RECOVERY_COMPLETE:
        return False, "RECOVERY_RESULT_NOT_COMPLETE"
    if safety.recovery_attempts != 1:
        return False, "RECOVERY_ATTEMPT_COUNT_NOT_ONE"
    if counts[RecoveryInputDomain.RECOVERY_EXIT] != 1:
        return False, "RECOVERY_EXIT_INPUT_COUNT_NOT_ONE"
    if counts[RecoveryInputDomain.RECOVERY_CONFIRM] != 1:
        return False, "RECOVERY_CONFIRM_INPUT_COUNT_NOT_ONE"
    if counts[RecoveryInputDomain.RECOVERY_REENTRY] != 1:
        return False, "RECOVERY_REENTRY_INPUT_COUNT_NOT_ONE"
    if counts[RecoveryInputDomain.RECOVERY_TARGET_SELECT] > 1:
        return False, "RECOVERY_TARGET_SELECTION_INPUT_EXCEEDED"
    if any(
        (
            safety.gameplay_inputs_after_trigger,
            safety.gameplay_inputs_during_recovery,
            safety.gameplay_inputs_in_recovered_combat,
            safety.duplicate_exit,
            safety.duplicate_confirm,
            safety.duplicate_reentry,
            safety.wrong_ui_click,
            safety.stale_session_confusion,
            safety.wrong_target,
        )
    ):
        return False, "RECOVERY_SAFETY_COUNTER_NONZERO"
    if snapshot.new_session is None or snapshot.new_opening is None:
        return False, "RECOVERED_SESSION_OR_OPENING_MISSING"
    return True, "PHASE2D3_RECOVERY_BOUNDARY_PROVEN"


def _run_live(
    args: Namespace,
    *,
    shared_runtime: Any | None = None,
    armed_coordinator: TechnicalRecoveryCoordinator | None = None,
    armed_failure_state: GameState | None = None,
) -> int:
    """Run the accepted Phase 2D.3 UI path.

    Phase 2D.4 may inject the already-armed production coordinator plus the
    farm-owned process/provider/monitor/input objects.  The standalone 2D.3
    CLI leaves these unset and retains its accepted attach-and-detect flow.
    In both cases all recovery UI below is the same implementation.
    """
    target_identity = FarmTarget(args.boss_id, args.boss_name)
    root = (args.artifacts or current_app_paths().logs_root / "technical_recovery").resolve()
    coordinator = armed_coordinator or TechnicalRecoveryCoordinator(
        max_technical_recoveries=args.max_technical_recoveries
    )
    dispatcher = TechnicalRecoveryDispatcher(coordinator)
    artifacts: RecoveryArtifactWriter | None = None
    beep_enabled = not args.no_beep

    process_context = (
        attach_target()
        if shared_runtime is None
        else nullcontext(shared_runtime.target)
    )
    with process_context as process:
        if shared_runtime is None:
            backend = NativeWin32Backend()
            binding = find_window_for_pid(process.pid, backend)
            executor = ForegroundClickExecutor(backend)
            provider = MemoryBoardStateProvider(
                process,
                MemoryProviderConfig(
                    max_region_mib=args.max_region_mib,
                    chunk_mib=args.chunk_mib,
                    required_confirmations=2,
                    require_lobby_start=False,
                    allow_ack_heap_scan=True,
                    ack_heap_region_mib=args.ack_heap_region_mib,
                    extended_fusion_ui_region_mib=max(args.max_region_mib, 16),
                ),
            )
            monitor = RuntimeSequenceMonitor(
                process,
                max_region_mib=max(args.max_region_mib, 16),
                chunk_mib=args.chunk_mib,
                full_rescan_interval=8,
            )
        else:
            backend = shared_runtime.backend
            binding = shared_runtime.binding
            executor = shared_runtime.executor
            provider = shared_runtime.provider
            monitor = shared_runtime.monitor
        hotkeys = HotkeyEdges()
        print(
            "Phase 2D.3 ready: F9 emergency stop; F7/F10 are disabled. "
            "Keep Pokiguard foreground.",
            flush=True,
        )
        if args.recovery_ui_test:
            print(
                "TEST_ONLY mode: this will intentionally abandon the current combat; "
                "it does not claim desync or dead board.",
                flush=True,
            )

        deadline = time.monotonic() + args.trigger_timeout
        active_session: CombatSessionKey | None = None
        failure_state: GameState | None = armed_failure_state
        trigger_armed = coordinator.trigger is not None
        test_session_tracker = CombatSessionTracker()
        test_active_key: tuple[Any, ...] | None = None
        test_active_confirmations = 0
        last_wait_status: tuple[Any, ...] | None = None
        while (
            not trigger_armed
            and process.is_running()
            and time.monotonic() < deadline
        ):
            _poll_farm_graceful_stop(shared_runtime)
            if _any_emergency_stop_requested(hotkeys, shared_runtime):
                coordinator.emergency_stop(detail="F9 before recovery trigger")
                return 130
            poll = provider.poll()
            state = poll.state
            lifecycle_observation = poll.combat_lifecycle
            lifecycle = (
                lifecycle_observation.state
                if lifecycle_observation is not None
                else CombatLifecycleState.UNKNOWN
            )
            signals = (
                lifecycle_observation.signals
                if lifecycle_observation is not None
                else None
            )
            lifecycle_session = test_session_tracker.observe(
                lifecycle,
                signals.board_instance if signals is not None else None,
                signals.match_id if signals is not None else None,
            )
            wait_status = (
                poll.reason,
                lifecycle.value,
                signals.match_id if signals is not None else None,
                signals.board_instance if signals is not None else None,
                state is not None and state.phase is GamePhase.COMBAT,
            )
            if wait_status != last_wait_status:
                print(
                    "Recovery preflight: "
                    f"provider={poll.reason}; lifecycle={lifecycle.value}; "
                    f"match={wait_status[2]}; boardPublished={wait_status[4]}",
                    flush=True,
                )
                last_wait_status = wait_status

            if args.recovery_ui_test:
                current_key = (
                    lifecycle_session,
                    signals.match_id if signals is not None else None,
                    signals.board_instance if signals is not None else None,
                )
                if (
                    lifecycle is CombatLifecycleState.ACTIVE
                    and lifecycle_session is not None
                    and signals is not None
                    and signals.objects_consistent is True
                    and signals.board_ready is True
                ):
                    test_active_confirmations = (
                        test_active_confirmations + 1
                        if current_key == test_active_key
                        else 1
                    )
                    test_active_key = current_key
                else:
                    test_active_key = None
                    test_active_confirmations = 0
                if test_active_confirmations >= 2:
                    try:
                        _match_service, runtime_state = read_match_runtime(process)
                    except (OSError, RuntimeError, ValueError):
                        runtime_state = None
                    if (
                        runtime_state is not None
                        and runtime_state.match_id == signals.match_id
                    ):
                        failed = FailedSessionEvidence(
                            session_key=lifecycle_session,
                            match_id=signals.match_id or "",
                            board_instance=signals.board_instance,
                            lifecycle_epoch=lifecycle_session.lifecycle_epoch,
                            turn=runtime_state.turn,
                            srv_seq=runtime_state.highest_acked_sequence,
                            board_hash=(
                                state.battle.board_hash
                                if state is not None and state.phase is GamePhase.COMBAT
                                else None
                            ),
                        )
                        if dispatcher.arm_test_only_evidence(failed):
                            failure_state = (
                                state
                                if state is not None and state.phase is GamePhase.COMBAT
                                else None
                            )
                            trigger_armed = True
                            break
                time.sleep(args.interval)
                continue

            if (
                lifecycle is not CombatLifecycleState.ACTIVE
                or state is None
                or state.battle.session_key is None
            ):
                time.sleep(args.interval)
                continue
            if active_session != state.battle.session_key:
                active_session = state.battle.session_key
                monitor.begin_session(active_session, active_session.match_id, clean=True)

            observation = monitor.poll(
                session_key=active_session,
                match_id=active_session.match_id,
                turn=state.battle.turn_number,
                srv_seq=state.battle.srv_seq,
                timestamp=state.timestamp,
            )
            if observation.first_detected and dispatcher.dispatch_sequence_desync(
                monitor.tracker.state,
                state=state,
            ):
                failure_state = state
                trigger_armed = True
                break
            if state.battle.is_local_turn is True:
                analysis = analyze_game_state(state)
                if dispatcher.dispatch_dead_board(state, analysis):
                    failure_state = state
                    trigger_armed = True
                    break
            time.sleep(args.interval)

        if not trigger_armed or coordinator.trigger is None:
            return 2

        artifacts = RecoveryArtifactWriter.create(root)
        artifacts.write_failure(coordinator, failure_state)
        _save_current_capture(process.pid, artifacts.directory / "failure_screenshot.png")
        artifacts.event(
            "recovery_triggered",
            trigger=coordinator.trigger,
            gameplayLocked=coordinator.gameplay_locked,
            F7="DISABLED",
            F9="EMERGENCY_STOP",
            F10="DISABLED",
        )
        _beep("warning", beep_enabled)

        # Resolve the accepted blinking Exit control with a bounded temporal
        # locator and exact-dimension live calibration fallback.  The accepted
        # manual recovery first hovered this normalized combat-only anchor so
        # the blinking control became observable; moving sends no click.
        if _any_emergency_stop_requested(hotkeys, shared_runtime):
            coordinator.emergency_stop()
            artifacts.finalize(coordinator, stage="B_LIVE", stageResult="ABORTED")
            return 130
        _poll_farm_graceful_stop(shared_runtime)
        hover_window = executor.window_status(binding)
        if not hover_window.valid or hover_window.foreground is not True:
            return _block_and_finalize(
                coordinator,
                artifacts,
                TechnicalRecoveryResult.RECOVERY_BLOCKED_FOREGROUND,
                "foreground lost before recovery Exit hover probe",
                event="recovery_exit_hover_blocked",
            )
        try:
            hover_capture = capture_client_rgb(process.pid)
            hover_calibration = _live_exit_calibration(
                pid=process.pid,
                width=hover_capture.width,
                height=hover_capture.height,
            )
        except (OSError, RuntimeError, ValueError):
            hover_calibration = None
        hover_point = (
            hover_calibration.normalized_point
            if hover_calibration is not None
            and hover_calibration.normalized_point is not None
            else (0.04134466769706337, 0.06824712643678162)
        )
        hover_authorized, hover = _execute_farm_controlled_input(
            shared_runtime,
            lambda: executor.move_normalized_point(
                binding,
                hover_point,
            ),
        )
        if not hover_authorized or hover is None:
            coordinator.emergency_stop(
                detail="emergency authority revoked before recovery Exit hover"
            )
            artifacts.event("emergency_stop", stage="EXIT_HOVER", inputSent=False)
            artifacts.finalize(coordinator, stage="B_LIVE", stageResult="ABORTED")
            return 130
        artifacts.event(
            "recovery_exit_hover_probe",
            normalizedPoint=hover_point,
            calibration=hover_calibration,
            status=hover,
            clickSent=False,
        )
        if hover.value != "SENT":
            return _block_and_finalize(
                coordinator,
                artifacts,
                TechnicalRecoveryResult.RECOVERY_BLOCKED_FOREGROUND,
                f"Exit hover probe failed: {hover.value}",
                event="recovery_exit_hover_blocked",
            )
        exit_deadline = time.monotonic() + args.exit_locator_timeout
        # Exact-dimension calibration with live SENT + modal evidence is
        # already stronger than a fresh sample of this blinking control. Use
        # it immediately. Waiting through the temporal locator first consumed
        # six seconds in B6 attempt 4 and let the server eject the failed
        # session before recovery could click. Unknown dimensions still take
        # the bounded visual-locator path below.
        exit_location = _usable_calibrated_exit(hover_calibration)
        while process.is_running() and time.monotonic() < exit_deadline:
            if exit_location is not None:
                break
            _poll_farm_graceful_stop(shared_runtime)
            if _any_emergency_stop_requested(hotkeys, shared_runtime):
                coordinator.emergency_stop()
                artifacts.event("emergency_stop", stage="EXIT_LOCATOR")
                artifacts.finalize(coordinator, stage="B_LIVE", stageResult="ABORTED")
                return 130
            candidate = _locate_temporally(
                process.pid,
                locate_exit_back,
                attempts=6,
                interval=max(args.interval, 0.12),
                minimum_hits=2,
            )
            if not candidate.found:
                capture = capture_client_rgb(process.pid)
                candidate = _live_exit_calibration(
                    pid=process.pid,
                    width=capture.width,
                    height=capture.height,
                ) or candidate
            if candidate.found and candidate.normalized_point is not None:
                exit_location = candidate
                break
        if exit_location is None:
            return _block_and_finalize(
                coordinator,
                artifacts,
                TechnicalRecoveryResult.RECOVERY_EXIT_LOCATOR_FAILED,
                "RECOVERY_EXIT_CONTROL_MISSING_OR_AMBIGUOUS",
                event="recovery_exit_control_ambiguous",
            )
        _save_current_capture(process.pid, artifacts.directory / "exit_control.png")
        if not coordinator.exit_control_ready(locator_proof=exit_location.reason):
            return _block_and_finalize(
                coordinator,
                artifacts,
                TechnicalRecoveryResult.RECOVERY_EXIT_LOCATOR_FAILED,
                "coordinator rejected Exit locator proof",
                event="recovery_exit_control_rejected",
            )

        if _any_emergency_stop_requested(hotkeys, shared_runtime):
            coordinator.emergency_stop()
            artifacts.finalize(coordinator, stage="B_LIVE", stageResult="ABORTED")
            return 130
        _poll_farm_graceful_stop(shared_runtime)
        pre_exit = provider.poll()
        pre_exit_lifecycle = (
            pre_exit.combat_lifecycle.state
            if pre_exit.combat_lifecycle is not None
            else CombatLifecycleState.UNKNOWN
        )
        same_failed_session = _failed_session_still_active(
            pre_exit,
            coordinator.trigger.failed_session,
        )
        artifacts.event(
            "recovery_exit_preflight",
            providerReason=pre_exit.reason,
            lifecycleObservation=pre_exit_lifecycle,
            publishedState=pre_exit.state,
            pollSession=pre_exit.session_key,
            providerSession=provider.current_session_key,
            failedSession=coordinator.trigger.failed_session,
            sameFailedSessionActive=same_failed_session,
        )
        window = executor.window_status(binding)
        permit = coordinator.reserve_exit(
            foreground=window.valid and window.foreground is True,
            same_session=same_failed_session,
            lifecycle_active=(
                pre_exit_lifecycle is CombatLifecycleState.ACTIVE
                or same_failed_session
            ),
        )
        if permit is None:
            artifacts.finalize(coordinator, stage="B_LIVE", stageResult="SAFE_STOP")
            return 2
        click_authorized, click = _execute_farm_controlled_input(
            shared_runtime,
            lambda: executor.send_normalized_point(
                binding, exit_location.normalized_point
            ),
        )
        if not click_authorized or click is None:
            coordinator.cancel_input(
                permit, detail="emergency authority revoked before recovery Exit input"
            )
            coordinator.emergency_stop(
                detail="emergency authority revoked before recovery Exit input"
            )
            artifacts.event("emergency_stop", stage="EXIT_INPUT", inputSent=False)
            artifacts.finalize(coordinator, stage="B_LIVE", stageResult="ABORTED")
            return 130
        coordinator.complete_input(
            permit,
            sent=click.sent,
            detail=f"EXIT_BACK:{click.status.value}",
        )
        artifacts.event(
            "recovery_exit_input",
            locator=exit_location,
            click=click,
            count=1 if click.sent else 0,
        )
        if not click.sent:
            artifacts.finalize(coordinator, stage="B_LIVE", stageResult="SAFE_STOP")
            return 2

        modal_deadline = time.monotonic() + args.modal_timeout
        confirm_location = None
        while process.is_running() and time.monotonic() < modal_deadline:
            _poll_farm_graceful_stop(shared_runtime)
            if _any_emergency_stop_requested(hotkeys, shared_runtime):
                coordinator.emergency_stop()
                artifacts.event("emergency_stop", stage="CONFIRM_MODAL")
                artifacts.finalize(coordinator, stage="B_LIVE", stageResult="ABORTED")
                return 130
            candidate = _locate_temporally(
                process.pid,
                locate_confirm_leave,
                attempts=3,
                interval=max(args.interval, 0.12),
                minimum_hits=3,
            )
            if candidate.found and candidate.normalized_point is not None:
                confirm_location = candidate
                break
            time.sleep(args.interval)
        if confirm_location is None:
            return _block_and_finalize(
                coordinator,
                artifacts,
                TechnicalRecoveryResult.RECOVERY_CONFIRM_FAILED,
                "RECOVERY_CONFIRM_MODAL_TIMEOUT_OR_AMBIGUOUS",
                event="recovery_confirm_modal_failed",
            )
        _save_current_capture(process.pid, artifacts.directory / "confirm_modal.png")
        if not coordinator.confirm_modal_ready(locator_proof=confirm_location.reason):
            return _block_and_finalize(
                coordinator,
                artifacts,
                TechnicalRecoveryResult.RECOVERY_CONFIRM_FAILED,
                "coordinator rejected stable confirm-modal proof",
                event="recovery_confirm_modal_rejected",
            )

        if _any_emergency_stop_requested(hotkeys, shared_runtime):
            coordinator.emergency_stop()
            artifacts.finalize(coordinator, stage="B_LIVE", stageResult="ABORTED")
            return 130
        _poll_farm_graceful_stop(shared_runtime)
        pre_confirm = provider.poll()
        confirm_lifecycle = (
            pre_confirm.combat_lifecycle.state
            if pre_confirm.combat_lifecycle is not None
            else CombatLifecycleState.UNKNOWN
        )
        confirm_same_failed_session = _failed_session_still_active(
            pre_confirm,
            coordinator.trigger.failed_session,
        )
        artifacts.event(
            "recovery_confirm_preflight",
            providerReason=pre_confirm.reason,
            lifecycleObservation=confirm_lifecycle,
            publishedState=pre_confirm.state,
            pollSession=pre_confirm.session_key,
            providerSession=provider.current_session_key,
            failedSession=coordinator.trigger.failed_session,
            sameFailedSessionActive=confirm_same_failed_session,
        )
        window = executor.window_status(binding)
        permit = coordinator.reserve_confirm(
            foreground=window.valid and window.foreground is True,
            context_valid=(
                (
                    confirm_lifecycle is CombatLifecycleState.ACTIVE
                    or confirm_same_failed_session
                )
                and confirm_same_failed_session
            ),
        )
        if permit is None:
            artifacts.finalize(coordinator, stage="B_LIVE", stageResult="SAFE_STOP")
            return 2
        click_authorized, click = _execute_farm_controlled_input(
            shared_runtime,
            lambda: executor.send_normalized_point(
                binding, confirm_location.normalized_point
            ),
        )
        if not click_authorized or click is None:
            coordinator.cancel_input(
                permit,
                detail="emergency authority revoked before recovery confirm input",
            )
            coordinator.emergency_stop(
                detail="emergency authority revoked before recovery confirm input"
            )
            artifacts.event("emergency_stop", stage="CONFIRM_INPUT", inputSent=False)
            artifacts.finalize(coordinator, stage="B_LIVE", stageResult="ABORTED")
            return 130
        coordinator.complete_input(
            permit,
            sent=click.sent,
            detail=f"CONFIRM_LEAVE:{click.status.value}",
        )
        artifacts.event(
            "recovery_confirm_input",
            locator=confirm_location,
            click=click,
            count=1 if click.sent else 0,
        )
        if not click.sent:
            artifacts.finalize(coordinator, stage="B_LIVE", stageResult="SAFE_STOP")
            return 2

        local_exit_deadline = time.monotonic() + args.local_exit_timeout
        lifecycle_history: list[str] = []
        while process.is_running() and time.monotonic() < local_exit_deadline:
            _poll_farm_graceful_stop(shared_runtime)
            if _any_emergency_stop_requested(hotkeys, shared_runtime):
                coordinator.emergency_stop()
                artifacts.event("emergency_stop", stage="WAIT_LOCAL_COMBAT_END")
                artifacts.finalize(coordinator, stage="B_LIVE", stageResult="ABORTED")
                return 130
            poll = provider.poll()
            lifecycle = (
                poll.combat_lifecycle.state
                if poll.combat_lifecycle is not None
                else CombatLifecycleState.UNKNOWN
            )
            if not lifecycle_history or lifecycle_history[-1] != lifecycle.value:
                lifecycle_history.append(lifecycle.value)
                artifacts.event(
                    "recovery_lifecycle_changed",
                    lifecycle=lifecycle,
                    providerSession=provider.current_session_key,
                )
            coordinator.observe_local_lifecycle(lifecycle)
            if coordinator.state is TechnicalRecoveryState.WAIT_BOSS_LOBBY:
                break
            time.sleep(args.interval)
        if coordinator.state is not TechnicalRecoveryState.WAIT_BOSS_LOBBY:
            return _block_and_finalize(
                coordinator,
                artifacts,
                TechnicalRecoveryResult.RECOVERY_LOBBY_TIMEOUT,
                "local combat lifecycle did not end before timeout",
                event="recovery_local_combat_end_timeout",
            )

        failed_session = coordinator.trigger.failed_session.session_key
        monitor.end_session(failed_session)
        lobby = _wait_boss_lobby(
            process,
            provider,
            target_identity,
            args.lobby_timeout,
            args.interval,
            hotkeys,
            getattr(shared_runtime, "farm_control_hotkeys", None),
            transient_room_grace_seconds=min(
                20.0, float(args.lobby_timeout) * 0.5
            ),
        )
        artifacts.event("recovery_boss_lobby_wait", result=lobby)
        if lobby.reason == "F9_EMERGENCY_STOP":
            coordinator.emergency_stop()
            artifacts.finalize(coordinator, stage="B_LIVE", stageResult="ABORTED")
            return 130
        if not lobby.ready or lobby.state is not BossLobbyState.BOSS_LOBBY:
            return _block_and_finalize(
                coordinator,
                artifacts,
                TechnicalRecoveryResult.RECOVERY_LOBBY_TIMEOUT,
                lobby.reason,
                event="recovery_boss_lobby_failed",
            )
        if (
            getattr(args, "require_current_boss_room", False)
            and (lobby.lobby is None or lobby.lobby.branch != "CHINH_PHUC_ROOM")
        ):
            artifacts.event(
                "recovery_room_ejected_stop",
                branch=(lobby.lobby.branch if lobby.lobby is not None else None),
                recoveryReentrySent=False,
                mapTargetSelectionAttempted=False,
            )
            return _block_and_finalize(
                coordinator,
                artifacts,
                TechnicalRecoveryResult.RECOVERY_LOBBY_TIMEOUT,
                "ROOM_EJECTED_TO_BOSS_MAP",
                event="recovery_current_room_required",
            )
        _save_current_capture(process.pid, artifacts.directory / "boss_lobby.png")
        if not coordinator.observe_boss_lobby(exact_boss_lobby=True):
            return _block_and_finalize(
                coordinator,
                artifacts,
                TechnicalRecoveryResult.RECOVERY_LOBBY_TIMEOUT,
                "coordinator rejected exact BOSS_LOBBY",
                event="recovery_boss_lobby_rejected",
            )
        if not coordinator.clear_old_session(
            provider_session_none=provider.current_session_key is None,
            pending_action_none=True,
            desync_old_session_ended=True,
        ):
            artifacts.finalize(coordinator, stage="B_LIVE", stageResult="SAFE_STOP")
            return 2

        # A graceful request during recovery must still finish the required
        # normal Exit/confirm sequence. At the first exact clean boss-lobby
        # boundary, suppress re-entry and hand the technical-exit accounting to
        # the outer FarmRun. No gameplay or RECOVERY_REENTRY input is sent.
        if _any_emergency_stop_requested(hotkeys, shared_runtime):
            coordinator.emergency_stop(
                detail="emergency stop at recovery boss-lobby boundary"
            )
            artifacts.event(
                "emergency_stop",
                stage="BOSS_LOBBY_BOUNDARY",
                recoveryReentrySent=False,
            )
            artifacts.finalize(coordinator, stage="B_LIVE", stageResult="ABORTED")
            return 130
        if _poll_farm_graceful_stop(shared_runtime):
            artifacts.event(
                "recovery_graceful_stop_at_lobby",
                recoveryReentrySent=False,
                oldSessionCleared=True,
            )
            artifacts.finalize(
                coordinator,
                stage="B_LIVE",
                stageResult="STOPPED_GRACEFULLY_AT_LOBBY",
            )
            return 3

        # Live B3 proved that the game can retain the failed match's ACK set
        # after a normal foreground << / confirm exit. Exact-25 later proved
        # that this can be a frozen owner-free lobby residue which normal entry
        # clears only while binding the next MATCH_START. Read the authoritative
        # MatchService singleton at the exact lobby boundary. Accept either a
        # clean epoch or a bounded, frozen residue; advancing/unreadable/owned
        # state still blocks. The post-entry handoff remains locked until the
        # distinct pristine opening has either a cleared ACK epoch or the
        # explicitly armed current-session isolation proof.
        ack_wait_seconds = min(
            RECOVERY_ACK_EPOCH_WAIT_SECONDS,
            max(5.0, float(args.lobby_timeout) * 0.25),
        )
        (
            lobby_ack_rejection,
            lobby_match_service,
            lobby_runtime,
            ack_epoch_samples,
        ) = _wait_for_clean_recovery_lobby_ack_epoch(
            process,
            timeout=ack_wait_seconds,
            interval=max(0.12, float(args.interval)),
        )
        artifacts.event(
            "recovery_lobby_ack_epoch",
            accepted=lobby_ack_rejection is None,
            reason=lobby_ack_rejection,
            matchService=lobby_match_service,
            matchId=(lobby_runtime.match_id if lobby_runtime is not None else None),
            highestAckedSequence=(
                lobby_runtime.highest_acked_sequence
                if lobby_runtime is not None
                else None
            ),
            localMoveSequence=(
                lobby_runtime.local_move_sequence
                if lobby_runtime is not None
                else None
            ),
            waitSeconds=ack_wait_seconds,
            samples=ack_epoch_samples,
            acceptanceMode=(
                "FROZEN_STALE_EPOCH_DEFERRED_RESET"
                if lobby_ack_rejection is None
                and lobby_runtime is not None
                and lobby_runtime.highest_acked_sequence is not None
                else "CLEAN_EPOCH"
                if lobby_ack_rejection is None
                else "REJECTED"
            ),
            resetRequiredAtRecoveredOpening=bool(
                lobby_ack_rejection is None
                and lobby_runtime is not None
                and lobby_runtime.highest_acked_sequence is not None
            ),
            recoveryReentrySent=False,
        )
        deferred_ack_reset = bool(
            lobby_ack_rejection is None
            and lobby_runtime is not None
            and lobby_runtime.highest_acked_sequence is not None
        )
        if lobby_ack_rejection is not None:
            return _block_and_finalize(
                coordinator,
                artifacts,
                TechnicalRecoveryResult.RECOVERY_OPENING_FAILED,
                lobby_ack_rejection,
                event="recovery_lobby_ack_epoch_blocked",
            )

        # The zero-input ACK wait may span a room ejection or another lobby
        # transition. Re-prove the exact current room before resolving the
        # target or reserving RECOVERY_REENTRY; never reuse the earlier view.
        lobby = _wait_boss_lobby(
            process,
            provider,
            target_identity,
            min(10.0, float(args.lobby_timeout)),
            args.interval,
            hotkeys,
            getattr(shared_runtime, "farm_control_hotkeys", None),
            transient_room_grace_seconds=min(
                10.0, float(args.lobby_timeout) * 0.25
            ),
        )
        artifacts.event("recovery_boss_lobby_revalidated", result=lobby)
        if (
            not lobby.ready
            or lobby.state is not BossLobbyState.BOSS_LOBBY
            or lobby.lobby is None
            or lobby.lobby.branch != "CHINH_PHUC_ROOM"
        ):
            return _block_and_finalize(
                coordinator,
                artifacts,
                TechnicalRecoveryResult.RECOVERY_LOBBY_TIMEOUT,
                "RECOVERY_ROOM_CHANGED_DURING_ACK_WAIT",
                event="recovery_boss_lobby_revalidation_failed",
            )

        resolution = resolve_target(target_identity, lobby.lobby.candidates)
        candidate = resolution.candidate
        exact = bool(
            resolution.status is TargetResolutionStatus.RESOLVED
            and candidate is not None
            and candidate.identity.stable_key()
            in {item.identity.stable_key() for item in lobby.lobby.candidates}
        )
        if not coordinator.resolve_target(
            resolved=resolution.status is TargetResolutionStatus.RESOLVED,
            available=bool(candidate is not None and candidate.available),
            selected=bool(
                candidate is not None
                and candidate.selection is TargetSelectionState.SELECTED
            ),
            exact_identity=exact,
            target_id=(candidate.identity.boss_id if candidate is not None else None),
            target_name=(candidate.identity.boss_name if candidate is not None else None),
        ):
            artifacts.finalize(coordinator, stage="B_LIVE", stageResult="SAFE_STOP")
            return 2
        provider.cancel_recovery_ack_epoch_isolation()
        if deferred_ack_reset:
            if (
                lobby_runtime is None
                or lobby_runtime.highest_acked_sequence is None
                or lobby_runtime.local_move_sequence is None
                or not provider.arm_recovery_ack_epoch_isolation(
                    stale_highest=int(lobby_runtime.highest_acked_sequence),
                    stale_local_move_sequence=int(
                        lobby_runtime.local_move_sequence
                    ),
                )
            ):
                return _block_and_finalize(
                    coordinator,
                    artifacts,
                    TechnicalRecoveryResult.RECOVERY_OPENING_FAILED,
                    "RECOVERY_ACK_ISOLATION_ARM_FAILED",
                    event="recovery_ack_isolation_arm_failed",
                )
            artifacts.event(
                "recovery_ack_isolation_armed",
                staleHighestAckedSequence=(
                    lobby_runtime.highest_acked_sequence
                ),
                staleLocalMoveSequence=lobby_runtime.local_move_sequence,
                nextDistinctSessionOnly=True,
            )
        _save_current_capture(process.pid, artifacts.directory / "reentry_before.png")

        reentry_dir = artifacts.directory / "reentry"
        runtime = boss_entry.SharedEntryRuntime(
            process,
            provider,
            monitor,
            binding,
            executor,
            backend,
            RecoveryReentryCapability(
                coordinator,
                getattr(shared_runtime, "farm_control_hotkeys", None),
            ),
        )
        boss_entry.run(_entry_args(args, reentry_dir), shared_runtime=runtime)
        try:
            entry_result = json.loads(
                (reentry_dir / "entry.json").read_text(encoding="utf-8")
            )
        except (OSError, ValueError):
            entry_result = {"status": "MISSING", "stopReason": "ENTRY_SUMMARY_MISSING"}
        artifacts.event("recovery_reentry_result", result=entry_result)
        if entry_result.get("stopReason") == "F9_EMERGENCY_STOP":
            provider.cancel_recovery_ack_epoch_isolation()
            coordinator.emergency_stop()
            artifacts.finalize(
                coordinator,
                stage="B_LIVE",
                stageResult="ABORTED",
                entry=entry_result,
            )
            return 130
        if entry_result.get("status") != "PASS":
            provider.cancel_recovery_ack_epoch_isolation()
            result = (
                TechnicalRecoveryResult.RECOVERY_OPENING_FAILED
                if "OPENING" in str(entry_result.get("stopReason"))
                else TechnicalRecoveryResult.RECOVERY_REENTRY_FAILED
            )
            coordinator.block(result, str(entry_result.get("stopReason")))
            artifacts.finalize(
                coordinator,
                stage="B_LIVE",
                stageResult="SAFE_STOP",
                entry=entry_result,
            )
            return 2

        new_session = provider.current_session_key
        opening = _recovered_opening_from_entry(entry_result, new_session)
        if new_session is None or not coordinator.accept_new_session(new_session):
            provider.cancel_recovery_ack_epoch_isolation()
            artifacts.finalize(
                coordinator,
                stage="B_LIVE",
                stageResult="SAFE_STOP",
                entry=entry_result,
            )
            return 2
        handoff_clean, handoff_evidence = _guard_recovered_handoff(
            provider,
            new_session,
            interval=args.interval,
        )
        artifacts.event(
            "recovery_handoff_guard",
            accepted=handoff_clean,
            expectedSession=new_session,
            **handoff_evidence,
        )
        if not handoff_clean:
            provider.cancel_recovery_ack_epoch_isolation()
            coordinator.block(
                TechnicalRecoveryResult.RECOVERY_OPENING_FAILED,
                str(
                    handoff_evidence.get("reason")
                    or "RECOVERY_HANDOFF_NOT_STABLY_ACTIONABLE"
                ),
            )
            artifacts.finalize(
                coordinator,
                stage="B_LIVE",
                stageResult="SAFE_STOP",
                entry=entry_result,
                recoveryHandoffGuard=handoff_evidence,
            )
            return 2
        if opening is None or not coordinator.accept_opening(opening):
            provider.cancel_recovery_ack_epoch_isolation()
            if opening is None:
                coordinator.block(
                    TechnicalRecoveryResult.RECOVERY_OPENING_FAILED,
                    "provider did not retain the accepted opening",
                )
            artifacts.finalize(
                coordinator,
                stage="B_LIVE",
                stageResult="SAFE_STOP",
                entry=entry_result,
            )
            return 2
        failed = coordinator.trigger.failed_session
        artifacts.event(
            "recovery_session_cleanliness",
            oldMatchId=failed.match_id,
            newMatchId=new_session.match_id,
            matchIdChanged=new_session.match_id != failed.match_id,
            oldSession=failed.session_key,
            newSession=new_session,
            sessionChanged=new_session != failed.session_key,
            oldBoardInstance=failed.board_instance,
            newBoardInstance=new_session.board_instance,
            boardInstanceChanged=(
                failed.board_instance is None
                or new_session.board_instance != failed.board_instance
            ),
            oldLifecycleEpoch=failed.lifecycle_epoch,
            newLifecycleEpoch=new_session.lifecycle_epoch,
            lifecycleEpochAdvanced=(
                failed.lifecycle_epoch is None
                or new_session.lifecycle_epoch > failed.lifecycle_epoch
            ),
            oldBoardHash=failed.board_hash,
            newBoardHash=opening.board_hash,
            boardHashNotReused=(
                failed.board_hash is None or opening.board_hash != failed.board_hash
            ),
            oldSrvSeq=failed.srv_seq,
            newOpeningSrvSeq=opening.srv_seq,
            oldSrvSeqTrackingCleared=True,
            oldIdleStateCleared=True,
            oldDesyncSessionEnded=True,
            pendingGameplayAction=None,
            pendingProposal=None,
            cardTransientStateCleared=True,
            fusionTransientStateCleared=True,
        )
        _save_current_capture(process.pid, artifacts.directory / "new_combat_opening.png")
        accepted, reason = _final_live_invariants(coordinator)
        if not accepted:
            provider.cancel_recovery_ack_epoch_isolation()
        artifacts.event(
            "phase2d3_final_invariants",
            accepted=accepted,
            reason=reason,
            lifecycleHistory=lifecycle_history,
        )
        artifacts.finalize(
            coordinator,
            stage="B_LIVE",
            stageResult=("PASS" if accepted else "FAIL"),
            finalInvariant=reason,
            entry=entry_result,
            lifecycleHistory=lifecycle_history,
            naturallyOccurringTechnicalFailure=(
                "NOT_OBSERVED"
                if coordinator.trigger.source.value == "TEST_ONLY"
                else "OBSERVED"
            ),
        )
        _beep("pass" if accepted else "warning", beep_enabled)
        print(
            f"Phase 2D.3 {'PASS' if accepted else 'FAIL'} ({reason}); "
            f"hard-stopped at recovered opening; artifacts: {artifacts.directory}",
            flush=True,
        )
        return 0 if accepted else 2


def run(args: Namespace) -> int:
    _validate_args(args)
    return _run_stage_a(args) if args.stage_a_replay else _run_live(args)


def run_armed_live_recovery(
    args: Namespace,
    *,
    shared_runtime: Any,
    coordinator: TechnicalRecoveryCoordinator,
    failure_state: GameState | None,
) -> int:
    """Phase 2D.4 handoff into the exact accepted 2D.3 live UI path."""

    _validate_args(args)
    if coordinator.trigger is None or not coordinator.gameplay_locked:
        raise ValueError("armed recovery handoff requires a locked coordinator trigger")
    if args.stage_a_replay:
        raise ValueError("armed live recovery cannot run in Stage A replay mode")
    return _run_live(
        args,
        shared_runtime=shared_runtime,
        armed_coordinator=coordinator,
        armed_failure_state=failure_state,
    )


def main(argv: Sequence[str] | None = None) -> int:
    args = build_parser().parse_args(argv)
    try:
        with AutomationControllerLease(current_app_paths().controller_lock):
            return run(args)
    except KeyboardInterrupt:
        print("Phase 2D.3 stopped by user.", file=sys.stderr)
        return 130
    except (
        CoordinateSafetyError,
        FileExistsError,
        FileNotFoundError,
        OSError,
        ProcessProbeError,
        RuntimeError,
        ValueError,
    ) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
