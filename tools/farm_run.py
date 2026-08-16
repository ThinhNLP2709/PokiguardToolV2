#!/usr/bin/env python3
"""Phase 2D.4 bounded continuous farming and recovery-resume runner."""

from __future__ import annotations

import argparse
from argparse import Namespace
from dataclasses import asdict
from pathlib import Path
import json
import sys
import time
import traceback
from typing import Any, Sequence


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.board_diagnostics import analyze_game_state  # noqa: E402
from pokiguard_v2.boss_entry import BossLobbyState, FarmTarget  # noqa: E402
from pokiguard_v2.combat_lifecycle import CombatLifecycleState  # noqa: E402
from pokiguard_v2.controller_lease import AutomationControllerLease  # noqa: E402
from pokiguard_v2.farm_cycle import OpeningEvidence  # noqa: E402
from pokiguard_v2.farm_run import (  # noqa: E402
    FarmInputDomain,
    FarmRun,
    FarmRunArtifactWriter,
    FarmRunEntryCapability,
    FarmRunGameplayCapability,
    FarmRunLimits,
    FarmRunState,
    FarmRunStopReason,
    MatchResult,
)
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
)
from pokiguard_v2.postmatch_ui import (  # noqa: E402
    locate_result_confirm,
    prove_stable_result_confirm,
)
from pokiguard_v2.technical_recovery import (  # noqa: E402
    RecoveredOpeningEvidence,
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
from pokiguard_v2.win32_screenshot import capture_client_rgb, write_png_rgb  # noqa: E402
from tools import basic_auto_bot, boss_entry, technical_recovery  # noqa: E402
from tools.farm_cycle import (  # noqa: E402
    _combat_args,
    _entry_args,
    _last_event,
    _read_jsonl,
    _validate_combat_summary,
    _wait_boss_lobby,
)
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.replay_sequence_desync import replay  # noqa: E402
from tools.runtime_common import attach_target  # noqa: E402
from tools.sequence_desync_runtime import RuntimeSequenceMonitor  # noqa: E402


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    mode = parser.add_mutually_exclusive_group(required=True)
    mode.add_argument(
        "--stage-a-replay",
        action="store_true",
        help="offline recovery-resume integration; actual Windows inputs=0",
    )
    mode.add_argument(
        "--stage-b1-recovery-resume",
        action="store_true",
        help="TEST_ONLY recovery then exactly one accepted consuming action",
    )
    mode.add_argument(
        "--stage-b2-farm",
        action="store_true",
        help="bounded production multi-match farm",
    )
    target = parser.add_mutually_exclusive_group()
    target.add_argument("--boss-id", help="exact runtime boss/enemy pet ID")
    target.add_argument("--boss-name", help="exact NFC/casefold boss name")
    parser.add_argument("--target-matches", type=int, default=3)
    parser.add_argument("--max-technical-recoveries", type=int, default=1)
    parser.add_argument("--max-match-attempts", type=int, default=5)
    parser.add_argument("--post-recovery-test-consuming-actions", type=int, default=1)
    parser.add_argument("--sequence-fixture", type=Path)
    parser.add_argument("--reset-evidence", type=Path)
    parser.add_argument("--artifacts", type=Path)
    parser.add_argument("--interval", type=float, default=0.12)
    parser.add_argument("--lobby-timeout", type=float, default=180.0)
    parser.add_argument("--entry-timeout", type=float, default=45.0)
    parser.add_argument("--opening-timeout", type=float, default=35.0)
    parser.add_argument("--return-lobby-timeout", type=float, default=90.0)
    parser.add_argument("--combat-timeout", type=float, default=1800.0)
    parser.add_argument("--max-total-input-actions", type=int, default=100)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--ack-heap-region-mib", type=int, default=16)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument("--no-beep", action="store_true")
    return parser


def _validate_args(args: Namespace) -> FarmRunLimits:
    limits = FarmRunLimits(
        args.target_matches,
        args.max_technical_recoveries,
        args.max_match_attempts,
    )
    if not args.stage_a_replay and not (args.boss_id or args.boss_name):
        raise ValueError("live farm run requires --boss-id or --boss-name")
    if args.stage_b1_recovery_resume and args.post_recovery_test_consuming_actions != 1:
        raise ValueError("Stage B1 hard-requires exactly one consuming action")
    if not 0.08 <= args.interval <= 0.50:
        raise ValueError("--interval must be between 0.08 and 0.50")
    for name in ("lobby_timeout", "entry_timeout", "opening_timeout"):
        if not 5 <= float(getattr(args, name)) <= 600:
            raise ValueError(f"--{name.replace('_', '-')} must be between 5 and 600")
    for name in ("return_lobby_timeout", "combat_timeout"):
        if not 5 <= float(getattr(args, name)) <= 3600:
            raise ValueError(f"--{name.replace('_', '-')} must be between 5 and 3600")
    if not 1 <= args.max_total_input_actions <= 1000:
        raise ValueError("--max-total-input-actions must be between 1 and 1000")
    if not 1 <= args.max_region_mib <= 32 or not 1 <= args.chunk_mib <= 16:
        raise ValueError("scan size arguments are outside safe bounds")
    if not args.max_region_mib <= args.ack_heap_region_mib <= 32:
        raise ValueError("--ack-heap-region-mib must cover --max-region-mib and be <= 32")
    if not args.stage_a_replay:
        if args.reset_evidence is None or not args.reset_evidence.is_file():
            raise FileNotFoundError("live B5 requires --reset-evidence")
    return limits


def _recovery_args(args: Namespace, artifacts: Path, *, test_only: bool) -> Namespace:
    return Namespace(
        stage_a_replay=False,
        recovery_ui_test=test_only,
        watch_production=not test_only,
        boss_id=args.boss_id,
        boss_name=args.boss_name,
        sequence_fixture=None,
        artifacts=artifacts,
        interval=args.interval,
        trigger_timeout=300.0,
        exit_locator_timeout=12.0,
        modal_timeout=12.0,
        local_exit_timeout=30.0,
        lobby_timeout=args.lobby_timeout,
        entry_timeout=args.entry_timeout,
        opening_timeout=args.opening_timeout,
        max_technical_recoveries=1,
        max_region_mib=args.max_region_mib,
        ack_heap_region_mib=args.ack_heap_region_mib,
        chunk_mib=args.chunk_mib,
        no_beep=args.no_beep,
    )


def _write_model_events(writer: FarmRunArtifactWriter, run: FarmRun) -> None:
    for event in run.snapshot().events:
        writer.event(
            "farm_state_event",
            farmEventIndex=event.index,
            farmEvent=event.event,
            farmState=event.state,
            detail=event.detail,
        )


def _run_entry(
    *,
    run: FarmRun,
    args: Namespace,
    directory: Path,
    process: Any,
    provider: MemoryBoardStateProvider,
    monitor: RuntimeSequenceMonitor,
    binding: Any,
    executor: ForegroundClickExecutor,
    backend: NativeWin32Backend,
    test_only_recovery: bool = False,
) -> tuple[OpeningEvidence | None, dict[str, Any] | None]:
    if not run.target_resolved(exact=True):
        return None, None
    entry_directory = directory / "entry"
    runtime = boss_entry.SharedEntryRuntime(
        process,
        provider,
        monitor,
        binding,
        executor,
        backend,
        FarmRunEntryCapability(run),
    )
    boss_entry.run(_entry_args(args, entry_directory), shared_runtime=runtime)
    try:
        result = json.loads(
            (entry_directory / "entry.json").read_text(encoding="utf-8")
        )
    except (OSError, ValueError):
        run.safe_stop(FarmRunStopReason.OPENING_INVARIANT_FAILED, detail="entry summary missing")
        return None, None
    if result.get("status") != "PASS":
        if not run.stopped:
            raw_reason = str(result.get("stopReason") or "ENTRY_FAILED")
            if raw_reason == "F9_EMERGENCY_STOP":
                reason = FarmRunStopReason.EMERGENCY_STOP
            elif "FOREGROUND" in raw_reason:
                reason = FarmRunStopReason.FOREGROUND_LOST
            elif "TIMEOUT" in raw_reason:
                reason = FarmRunStopReason.ENTRY_TIMEOUT
            else:
                reason = FarmRunStopReason.OPENING_INVARIANT_FAILED
            run.safe_stop(reason, entry=result)
        return None, result
    key = provider.current_session_key
    try:
        current = (
            OpeningEvidence(
                session=key,
                match_id=str(result["matchId"]),
                board_hash=str(result["boardHash"]),
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
            if key is not None
            else None
        )
    except (KeyError, TypeError, ValueError):
        current = None
    if current is None or not run.accept_session(current.session):
        if not run.stopped:
            run.safe_stop(FarmRunStopReason.OPENING_INVARIANT_FAILED)
        return None, result
    if not run.accept_opening(current, test_only_recovery=test_only_recovery):
        return None, result
    return current, result


def _confirm_postmatch(
    *,
    run: FarmRun,
    process: Any,
    provider: MemoryBoardStateProvider,
    binding: Any,
    executor: ForegroundClickExecutor,
    directory: Path,
    interval: float,
    hotkeys: HotkeyEdges,
) -> bool:
    locations = []
    for frame_number in range(1, 4):
        _unused, stop = hotkeys.poll()
        if stop:
            run.safe_stop(FarmRunStopReason.EMERGENCY_STOP)
            return False
        poll = provider.poll()
        lifecycle = (
            poll.combat_lifecycle.state
            if poll.combat_lifecycle is not None
            else CombatLifecycleState.UNKNOWN
        )
        if lifecycle is not CombatLifecycleState.POSTMATCH:
            run.safe_stop(
                FarmRunStopReason.POSTMATCH_UI_AMBIGUOUS,
                detail=f"postmatch lifecycle changed to {lifecycle.value}",
            )
            return False
        capture = capture_client_rgb(process.pid)
        write_png_rgb(
            directory / f"postmatch_result_frame_{frame_number}.png",
            capture.width,
            capture.height,
            capture.rgb,
        )
        locations.append(locate_result_confirm(capture.rgb, capture.width, capture.height))
        if frame_number < 3:
            time.sleep(max(interval, 0.25))
    proof = prove_stable_result_confirm(locations, required_frames=3)
    if not proof.proven or proof.normalized_point is None:
        run.safe_stop(FarmRunStopReason.POSTMATCH_UI_AMBIGUOUS, detail=proof.reason)
        return False
    final = provider.poll()
    lifecycle = (
        final.combat_lifecycle.state
        if final.combat_lifecycle is not None
        else CombatLifecycleState.UNKNOWN
    )
    window = executor.window_status(binding)
    if lifecycle is not CombatLifecycleState.POSTMATCH:
        run.safe_stop(FarmRunStopReason.POSTMATCH_UI_AMBIGUOUS)
        return False
    permit = run.reserve_postmatch(
        foreground=window.valid and window.foreground is True
    )
    if permit is None:
        return False
    click = executor.send_normalized_point(binding, proof.normalized_point)
    return run.complete_postmatch(
        permit,
        sent=click.sent,
        detail=f"RESULT_CONFIRM:{click.status.value}",
    )


def _classify_match_result(summary: dict[str, Any] | None) -> MatchResult:
    value = str((summary or {}).get("fullCombatResult") or "UNKNOWN").upper()
    if "WIN" in value:
        return MatchResult.WIN
    if "LOSS" in value or "LOSE" in value:
        return MatchResult.LOSS
    return MatchResult.UNKNOWN


def _merge_combat_safety(run: FarmRun, summary: dict[str, Any] | None) -> None:
    safety = (summary or {}).get("safetyTelemetry") or {}
    run.safety.duplicate_gameplay_input += int(safety.get("duplicate") or 0)
    run.safety.wrong_turn_input += int(safety.get("wrongTurn") or 0)
    run.safety.opponent_turn_input += int(safety.get("bossTurnInput") or 0)
    run.safety.stale_action += int(safety.get("staleAction") or 0)
    run.safety.postmatch_gameplay_input += int(safety.get("postmatchInput") or 0)
    run.safety.lobby_gameplay_input += int(safety.get("lobbyInput") or 0)
    run.safety.input_after_farm_stop += int(safety.get("inputAfterCombat") or 0)


def _technical_reason(coordinator: TechnicalRecoveryCoordinator) -> str | None:
    trigger = coordinator.trigger
    if trigger is None or trigger.reason is None:
        return None
    return trigger.reason.value


def _opening_from_recovery(value: RecoveredOpeningEvidence) -> OpeningEvidence:
    return OpeningEvidence(
        session=value.session,
        match_id=value.match_id,
        board_hash=value.board_hash,
        complete_cells=value.complete_cells,
        unique_coordinates=value.unique_coordinates,
        source=value.source,
        first_local_turn=value.first_local_turn,
        local_move_sequence=value.local_move_sequence,
        stable_confirmations=value.stable_confirmations,
        production_ready=value.production_ready,
        gem_types_valid=value.gem_types_valid,
        multipliers_valid=value.multipliers_valid,
        fresh_dto=value.fresh_dto,
        timer_safe=value.timer_safe,
    )


def _recovery_clean(snapshot: Any) -> bool:
    old = snapshot.trigger.failed_session if snapshot.trigger is not None else None
    new = snapshot.new_session
    opening = snapshot.new_opening
    return bool(
        snapshot.state is TechnicalRecoveryState.RECOVERY_COMPLETE
        and snapshot.result is TechnicalRecoveryResult.RECOVERY_COMPLETE
        and snapshot.gameplay_locked is True
        and snapshot.old_session_invalidated is True
        and old is not None
        and new is not None
        and opening is not None
        and old.match_id != new.match_id
        and old.session_key != new
        and (old.board_instance is None or old.board_instance != new.board_instance)
        and (
            old.lifecycle_epoch is None
            or new.lifecycle_epoch > old.lifecycle_epoch
        )
        and (old.board_hash is None or old.board_hash != opening.board_hash)
        and snapshot.safety.gameplay_inputs_after_trigger == 0
        and snapshot.safety.gameplay_inputs_during_recovery == 0
        and snapshot.safety.gameplay_inputs_in_recovered_combat == 0
        and snapshot.safety.stale_session_confusion == 0
    )


def _run_recovery(
    *,
    run: FarmRun,
    args: Namespace,
    runtime: basic_auto_bot.SharedCombatRuntime,
    coordinator: TechnicalRecoveryCoordinator,
    failure_state: Any,
    writer: FarmRunArtifactWriter,
    test_only: bool,
) -> bool:
    if not run.begin_recovery():
        return False
    code = technical_recovery.run_armed_live_recovery(
        _recovery_args(args, writer.directory / "recoveries", test_only=test_only),
        shared_runtime=runtime,
        coordinator=coordinator,
        failure_state=failure_state,
    )
    snapshot = coordinator.snapshot()
    writer.event(
        "technical_recovery_returned",
        exitCode=code,
        recovery=snapshot,
        oldStateLeakFree=_recovery_clean(snapshot),
    )
    if code != 0 or not _recovery_clean(snapshot):
        run.safe_stop(FarmRunStopReason.RECOVERY_FAILED, exitCode=code)
        return False
    if not run.record_successful_recovery(snapshot.input_records):
        return False
    assert snapshot.new_session is not None and snapshot.new_opening is not None
    if not run.accept_session(snapshot.new_session, recovered=True):
        return False
    if not run.accept_opening(
        _opening_from_recovery(snapshot.new_opening), recovered=True
    ):
        return False
    if not run.resume_recovered_gameplay(old_state_leak_free=True):
        return False
    writer.event(
        "RECOVERY_HANDOFF_TO_GAMEPLAY",
        oldMatchId=snapshot.trigger.failed_session.match_id,
        newMatchId=snapshot.new_session.match_id,
        openingSrvSeq=snapshot.new_opening.srv_seq,
        openingBoardHash=snapshot.new_opening.board_hash,
        staleProposalReused=False,
        fullStateRereadRequired=True,
    )
    return True


def _stage_b1_action_proof(records: list[dict[str, Any]]) -> tuple[bool, dict[str, Any]]:
    summary = _last_event(records, "auto_controller_summary") or {}
    sent = [
        record
        for record in records
        if record.get("event") == "action_sent"
    ]
    terminals = [
        record
        for record in records
        if record.get("event") == "action_terminal"
        and record.get("result") in {"SWAP_ACKNOWLEDGED", "CAST_ACCEPTED"}
    ]
    safety = summary.get("safetyTelemetry") or {}
    accepted = bool(
        summary.get("stopReason") == "AUTO_STOP_AFTER_ACK"
        and int(summary.get("turnConsumingActions") or 0) == 1
        and summary.get("pending") is None
        and terminals
        and not any(int(value or 0) for value in safety.values())
    )
    return accepted, {
        "firstDecision": sent[0] if sent else None,
        "firstConsumingTerminal": terminals[0] if terminals else None,
        "summary": summary,
    }


def _offline_opening(key: Any, digit: str) -> OpeningEvidence:
    return OpeningEvidence(
        key,
        key.match_id,
        digit * 64,
        64,
        64,
        "ChatMessageDTO.MATCH_START.matchPayload.board",
        True,
        0,
        3,
    )


def _stage_a(args: Namespace, limits: FarmRunLimits) -> int:
    from pokiguard_v2.state import CombatSessionKey
    root = (args.artifacts or PROJECT_ROOT / "logs" / "farm_runs").resolve()
    fixture = (
        args.sequence_fixture
        or PROJECT_ROOT / "reference" / "sequence_desync_m714b231e.jsonl"
    ).resolve()
    tracker = replay(fixture)
    cases: list[dict[str, Any]] = []
    for case_name, reason in (
        ("SEQUENCE_DESYNC", "SEQUENCE_DESYNC"),
        ("DEAD_BOARD_FIXTURE", "DEAD_BOARD_NO_REFRESH"),
    ):
        dead_state = None
        if reason == "SEQUENCE_DESYNC":
            captured_session = tracker.state.session_key
            if captured_session is None or tracker.state.match_id is None:
                raise ValueError("captured sequence fixture has no session identity")
            captured_text = str(captured_session)
            board_text = next(
                (
                    part.split("=", 1)[1]
                    for part in captured_text.split("|")
                    if part.startswith("board=")
                ),
                "0x100001",
            )
            old = CombatSessionKey(1, int(board_text, 16), tracker.state.match_id)
            old_hash = "a" * 64
        else:
            dead_state = technical_recovery._offline_dead_board_state()
            old = dead_state.battle.session_key
            if old is None:
                raise ValueError("dead-board fixture has no session identity")
            old_hash = dead_state.battle.board_hash or "a" * 64
        new = CombatSessionKey(
            old.lifecycle_epoch + 1,
            old.board_instance + 1,
            f"{old.match_id}_RECOVERED",
        )
        run = FarmRun(
            FarmTarget(boss_id="1289", boss_name="Starburst"),
            limits=limits,
            farm_run_id=f"stage_a_{case_name.casefold()}_{int(time.time() * 1000)}",
        )
        writer = FarmRunArtifactWriter.create(root, run.farm_run_id)
        run.observe_initial_lobby(BossLobbyState.BOSS_LOBBY)
        run.target_resolved()
        permit = run.reserve_entry(foreground=True)
        assert permit is not None
        run.complete_entry(permit, sent=True, detail="SIMULATED_NO_WINDOWS_INPUT")
        run.accept_session(old)
        run.accept_opening(
            OpeningEvidence(
                old,
                old.match_id,
                old_hash,
                64,
                64,
                "ChatMessageDTO.MATCH_START.matchPayload.board",
                True,
                0,
                3,
            )
        )
        coordinator = TechnicalRecoveryCoordinator(max_technical_recoveries=1)
        dispatcher = TechnicalRecoveryDispatcher(coordinator)
        if reason == "SEQUENCE_DESYNC":
            dispatched = dispatcher.dispatch_sequence_desync(
                tracker.state,
                evidence_source=f"captured replay:{fixture.name}",
            )
        else:
            assert dead_state is not None
            dispatched = dispatcher.dispatch_dead_board(
                dead_state,
                analyze_game_state(dead_state),
                evidence_source="deterministic legal=0 fixture",
            )
        run.technical_failure(reason)
        run.begin_recovery()
        coordinator.exit_control_ready(locator_proof="offline")
        p = coordinator.reserve_exit(
            foreground=True, same_session=True, lifecycle_active=True
        )
        assert p is not None
        coordinator.complete_input(p, sent=True, detail="SIMULATED")
        coordinator.confirm_modal_ready(locator_proof="offline")
        p = coordinator.reserve_confirm(foreground=True, context_valid=True)
        assert p is not None
        coordinator.complete_input(p, sent=True, detail="SIMULATED")
        coordinator.observe_local_lifecycle(CombatLifecycleState.LOBBY)
        coordinator.observe_boss_lobby(exact_boss_lobby=True)
        coordinator.clear_old_session(
            provider_session_none=True,
            pending_action_none=True,
            desync_old_session_ended=True,
        )
        coordinator.resolve_target(
            resolved=True,
            available=True,
            selected=True,
            exact_identity=True,
            target_id="1289",
            target_name="Starburst",
        )
        coordinator.reentry_ready(proof="offline")
        p = coordinator.reserve_reentry(foreground=True)
        assert p is not None
        coordinator.complete_input(p, sent=True, detail="SIMULATED")
        coordinator.accept_new_session(new)
        recovered = RecoveredOpeningEvidence(
            new,
            new.match_id,
            "b" * 64,
            1,
            64,
            64,
            "ChatMessageDTO.MATCH_START.matchPayload.board",
            True,
            0,
            3,
        )
        coordinator.accept_opening(recovered)
        run.record_successful_recovery(coordinator.snapshot().input_records)
        run.accept_session(new, recovered=True)
        run.accept_opening(_opening_from_recovery(recovered), recovered=True)
        run.resume_recovered_gameplay(old_state_leak_free=True)
        capability = FarmRunGameplayCapability(run, new)
        p2 = capability.reserve(action="SWAP", session=new, foreground=True)
        assert p2 is not None
        capability.complete(p2, sent=True, detail="SIMULATED_ACK")
        accepted = bool(
            dispatched
            and run.snapshot().technical_recoveries == 1
            and run.snapshot().match_attempts == 2
            and run.snapshot().safety.nonzero() == {}
        )
        writer.event(
            "stage_a_recovery_resume",
            case=case_name,
            accepted=accepted,
            actualWindowsInputs=0,
            simulatedCapabilityInputs=True,
            liveDeadBoard=("NOT_OBSERVED" if reason == "DEAD_BOARD_NO_REFRESH" else None),
        )
        _write_model_events(writer, run)
        writer.finalize(
            run,
            stage="A",
            stageResult=("PASS" if accepted else "FAIL"),
            actualWindowsInputs=0,
        )
        cases.append({"case": case_name, "accepted": accepted, "directory": writer.directory})
    passed = all(case["accepted"] for case in cases)
    print(
        json.dumps(
            {
                "stage": "PHASE_2D4_STAGE_A",
                "accepted": passed,
                "cases": cases,
                "actualWindowsInputs": 0,
                "liveDeadBoard": "NOT_OBSERVED",
            },
            default=str,
            ensure_ascii=False,
            indent=2,
        )
    )
    return 0 if passed else 2


def _run_live(args: Namespace, limits: FarmRunLimits) -> int:
    stage_b1 = bool(args.stage_b1_recovery_resume)
    target = FarmTarget(args.boss_id, args.boss_name)
    run = FarmRun(target, limits=limits)
    root = (args.artifacts or PROJECT_ROOT / "logs" / "farm_runs").resolve()
    writer = FarmRunArtifactWriter.create(root, run.farm_run_id)
    unexpected: dict[str, Any] | None = None
    stage_b1_proof: dict[str, Any] | None = None
    natural_technical_failure = False

    try:
        with attach_target() as process:
            backend = NativeWin32Backend()
            binding = find_window_for_pid(process.pid, backend)
            executor = ForegroundClickExecutor(backend)
            provider = MemoryBoardStateProvider(
                process,
                MemoryProviderConfig(
                    max_region_mib=args.max_region_mib,
                    chunk_mib=args.chunk_mib,
                    required_confirmations=2,
                    require_lobby_start=True,
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
            hotkeys = HotkeyEdges()
            writer.event(
                "farm_run_started",
                farmRunId=run.farm_run_id,
                mode=("STAGE_B1_TEST_ONLY" if stage_b1 else "STAGE_B2_PRODUCTION"),
                target=target,
                limits=limits,
                F7="DISABLED",
                F9="EMERGENCY_STOP",
            )
            initial = _wait_boss_lobby(
                process, provider, target, args.lobby_timeout, args.interval, hotkeys
            )
            writer.event("initial_boss_lobby", result=initial)
            if not initial.ready:
                initial_reason = (
                    FarmRunStopReason.EMERGENCY_STOP
                    if initial.reason == "F9_EMERGENCY_STOP"
                    else FarmRunStopReason.FARM_START_STATE_INVALID
                )
                run.safe_stop(initial_reason, detail=initial.reason)
            else:
                run.observe_initial_lobby(BossLobbyState.BOSS_LOBBY)

            while process.is_running() and not run.stopped:
                if run.state is FarmRunState.RESOLVE_TARGET:
                    match_directory = writer.directory / "matches" / f"attempt_{run.match_attempts + 1:03d}"
                    match_directory.mkdir(parents=True, exist_ok=False)
                    opening, entry_result = _run_entry(
                        run=run,
                        args=args,
                        directory=match_directory,
                        process=process,
                        provider=provider,
                        monitor=monitor,
                        binding=binding,
                        executor=executor,
                        backend=backend,
                        test_only_recovery=stage_b1,
                    )
                    writer.event(
                        "match_entry_result",
                        attemptIndex=run.match_attempts,
                        opening=opening,
                        entry=entry_result,
                    )
                    if opening is None:
                        continue

                if run.state is not FarmRunState.COMBAT_ACTIVE or run.current_session is None:
                    if not run.stopped:
                        run.safe_stop(FarmRunStopReason.INTERNAL_INVARIANT, state=run.state)
                    continue

                session = run.current_session
                attempt_index = run.match_attempts
                match_directory = writer.directory / "matches" / f"attempt_{attempt_index:03d}"
                match_directory.mkdir(parents=True, exist_ok=True)

                coordinator = TechnicalRecoveryCoordinator(max_technical_recoveries=1)
                dispatcher = TechnicalRecoveryDispatcher(coordinator)
                runtime = basic_auto_bot.SharedCombatRuntime(
                    process,
                    provider,
                    monitor,
                    binding,
                    executor,
                    backend,
                    session,
                    FarmRunGameplayCapability(run, session),
                    dispatcher if run.technical_recoveries < limits.max_technical_recoveries else None,
                )

                if stage_b1 and run.technical_recoveries == 0:
                    state = provider.poll().state
                    if state is None or state.battle.session_key != session:
                        run.safe_stop(FarmRunStopReason.RECOVERY_FAILED, detail="B1 state unavailable")
                        continue
                    if not dispatcher.arm_test_only(state):
                        run.safe_stop(FarmRunStopReason.RECOVERY_FAILED, detail="B1 TEST_ONLY arm failed")
                        continue
                    if not run.test_only_recovery_trigger():
                        continue
                    if not _run_recovery(
                        run=run,
                        args=args,
                        runtime=runtime,
                        coordinator=coordinator,
                        failure_state=state,
                        writer=writer,
                        test_only=True,
                    ):
                        continue
                    session = run.current_session
                    assert session is not None
                    recovered_directory = (
                        writer.directory
                        / "matches"
                        / f"attempt_{run.match_attempts:03d}"
                    )
                    recovered_directory.mkdir(parents=True, exist_ok=True)
                    combat_log = recovered_directory / "recovered_one_action.jsonl"
                    combat_args = _combat_args(args, combat_log)
                    combat_args.max_turn_actions = 1
                    combat_args.max_total_input_actions = max(
                        50, args.max_total_input_actions
                    )
                    # Internal-only mode: keep the production B5 policy and
                    # acknowledgement machinery, but hard-stop this recovered
                    # handoff after exactly one terminal consuming action.
                    # No CLI switch exposes this exception to B3/B4/B5.
                    combat_args.phase2d4_bounded_handoff = True
                    resumed_runtime = basic_auto_bot.SharedCombatRuntime(
                        process,
                        provider,
                        monitor,
                        binding,
                        executor,
                        backend,
                        session,
                        FarmRunGameplayCapability(run, session),
                        None,
                    )
                    basic_auto_bot.run(combat_args, shared_runtime=resumed_runtime)
                    records = _read_jsonl(combat_log)
                    accepted, stage_b1_proof = _stage_b1_action_proof(records)
                    summary = stage_b1_proof.get("summary") if stage_b1_proof else None
                    run.apply_combat_summary(summary or {})
                    _merge_combat_safety(run, summary)
                    writer.event(
                        "RECOVERY_HANDOFF_TO_GAMEPLAY_RESULT",
                        accepted=accepted,
                        firstDecision=(stage_b1_proof or {}).get("firstDecision"),
                        firstActionIdentity=(
                            ((stage_b1_proof or {}).get("firstDecision") or {}).get("identity")
                        ),
                        terminal=(stage_b1_proof or {}).get("firstConsumingTerminal"),
                    )
                    if accepted and run.snapshot().safety.nonzero() == {}:
                        writer.event(
                            "TECHNICAL_RECOVERY_GAMEPLAY_RESUMED_PROVEN",
                            invariant="PHASE2D4_RECOVERY_RESUME_PROVEN",
                            accepted=True,
                        )
                        run.complete_stage_b1(invariant="PHASE2D4_RECOVERY_RESUME_PROVEN")
                    else:
                        run.safe_stop(FarmRunStopReason.COMBAT_SAFE_STOP, detail="B1 action proof failed")
                    continue

                combat_log = match_directory / "combat.jsonl"
                basic_auto_bot.run(
                    _combat_args(args, combat_log), shared_runtime=runtime
                )
                records = _read_jsonl(combat_log)
                combat_ok, combat_reason, summary = _validate_combat_summary(records)
                run.apply_combat_summary(summary or {})
                _merge_combat_safety(run, summary)
                writer.event(
                    "combat_controller_returned",
                    attemptIndex=attempt_index,
                    acceptedNormalEnd=combat_ok,
                    reason=combat_reason,
                    summary=summary,
                    recoveryTrigger=coordinator.trigger,
                )

                if coordinator.trigger is not None:
                    reason = _technical_reason(coordinator)
                    if reason is None:
                        run.safe_stop(FarmRunStopReason.RECOVERY_FAILED, detail="production reason missing")
                        continue
                    natural_technical_failure = True
                    failure_state = provider.poll().state
                    if not run.technical_failure(reason):
                        continue
                    _run_recovery(
                        run=run,
                        args=args,
                        runtime=runtime,
                        coordinator=coordinator,
                        failure_state=failure_state,
                        writer=writer,
                        test_only=False,
                    )
                    continue

                if not combat_ok:
                    if combat_reason in {"REJECTED_SEQUENCE_DESYNC", "DEAD_BOARD_NO_REFRESH"}:
                        reason = (
                            "SEQUENCE_DESYNC"
                            if combat_reason == "REJECTED_SEQUENCE_DESYNC"
                            else combat_reason
                        )
                        run.technical_failure(reason)
                    else:
                        run.safe_stop(FarmRunStopReason.COMBAT_SAFE_STOP, detail=combat_reason)
                    continue

                result = _classify_match_result(summary)
                if not run.normal_combat_ended(result) or not run.observe_postmatch():
                    continue
                postmatch_ready = True
                if combat_reason == "POSTMATCH_RESULT_UI_REQUIRED":
                    postmatch_ready = _confirm_postmatch(
                        run=run,
                        process=process,
                        provider=provider,
                        binding=binding,
                        executor=executor,
                        directory=match_directory,
                        interval=args.interval,
                        hotkeys=hotkeys,
                    )
                if not postmatch_ready:
                    continue
                returned = _wait_boss_lobby(
                    process,
                    provider,
                    target,
                    args.return_lobby_timeout,
                    args.interval,
                    hotkeys,
                )
                writer.event("normal_return_boss_lobby", attemptIndex=attempt_index, result=returned)
                if not returned.ready:
                    reason = (
                        FarmRunStopReason.EMERGENCY_STOP
                        if returned.reason == "F9_EMERGENCY_STOP"
                        else FarmRunStopReason.RETURN_LOBBY_TIMEOUT
                    )
                    run.safe_stop(reason, detail=returned.reason)
                    continue
                run.observe_return_lobby(BossLobbyState.BOSS_LOBBY)

            if not process.is_running() and not run.stopped:
                run.safe_stop(FarmRunStopReason.COMBAT_SAFE_STOP, detail="target process exited")
    except KeyboardInterrupt:
        run.safe_stop(FarmRunStopReason.EMERGENCY_STOP, detail="KeyboardInterrupt")
    except Exception as exc:  # noqa: BLE001 - controller must persist and fail closed
        run.safe_stop(
            FarmRunStopReason.INTERNAL_INVARIANT,
            exceptionType=type(exc).__name__,
            detail=str(exc),
        )
        unexpected = {
            "type": type(exc).__name__,
            "message": str(exc),
            "traceback": traceback.format_exc(),
        }

    snapshot = run.snapshot()
    safety_ok = snapshot.safety.nonzero() == {}
    if stage_b1:
        accepted = bool(
            snapshot.state is FarmRunState.FARM_RUN_COMPLETE
            and snapshot.stop_reason is FarmRunStopReason.STAGE_B1_ACTION_ACCEPTED
            and snapshot.technical_recoveries == 1
            and safety_ok
        )
        invariant = "PHASE2D4_RECOVERY_RESUME_PROVEN" if accepted else "NOT_PROVEN"
    else:
        accepted = bool(
            snapshot.state is FarmRunState.FARM_RUN_COMPLETE
            and snapshot.stop_reason is FarmRunStopReason.FARM_TARGET_COMPLETED
            and snapshot.completed_matches == limits.target_completed_matches
            and snapshot.match_attempts <= limits.max_match_attempts
            and safety_ok
        )
        invariant = "PHASE2D4_BOUNDED_FARM_PROVEN" if accepted else "NOT_PROVEN"
    _write_model_events(writer, run)
    writer.finalize(
        run,
        stage=("B1" if stage_b1 else "B2"),
        stageResult=("PASS" if accepted else "SAFE_STOP"),
        finalInvariant=invariant,
        stageB1Proof=stage_b1_proof,
        naturalTechnicalFailure=("OBSERVED" if natural_technical_failure else "NOT_OBSERVED"),
        unexpectedError=unexpected,
    )
    print(
        f"Phase 2D.4 {'B1' if stage_b1 else 'B2'} "
        f"{'PASS' if accepted else 'STOPPED'} ({invariant}); "
        f"reason={snapshot.stop_reason}; artifacts={writer.directory}",
        flush=True,
    )
    return 0 if accepted else 2


def run(args: Namespace) -> int:
    limits = _validate_args(args)
    return _stage_a(args, limits) if args.stage_a_replay else _run_live(args, limits)


def main(argv: Sequence[str] | None = None) -> int:
    args = build_parser().parse_args(argv)
    try:
        with AutomationControllerLease(PROJECT_ROOT / "logs" / ".automation_controller.lock"):
            return run(args)
    except KeyboardInterrupt:
        print("Ctrl+C emergency stop received.")
        return 130
    except (
        CoordinateSafetyError,
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
