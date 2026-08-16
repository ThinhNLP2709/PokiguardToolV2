#!/usr/bin/env python3
"""Confirmed, one-UI-step-at-a-time normal combat exit recovery.

This tool never performs a board/card/Fusion action.  F10 advances at most one
visually proven recovery control; F9 stops.  Automatic exit and re-entry are
not implemented in Phase 2C.2A.4.
"""

from __future__ import annotations

import argparse
from dataclasses import asdict, is_dataclass
from datetime import datetime
from enum import Enum
import json
from pathlib import Path
import sys
import time
from typing import Any, Sequence

try:
    import winsound
except ImportError:  # pragma: no cover
    winsound = None


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.combat_lifecycle import (  # noqa: E402
    CombatLifecycleState,
    CombatSessionTracker,
    read_combat_lifecycle,
)
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
    ProviderSetupError,
    utc_timestamp,
)
from pokiguard_v2.recovery_ui import (  # noqa: E402
    RecoveryControl,
    RecoveryUiLocation,
    locate_confirm_leave,
    locate_exit_back,
)
from pokiguard_v2.sequence_desync import (  # noqa: E402
    RecoveryLifecycleState,
    RecoveryStateMachine,
)
from pokiguard_v2.sequence_desync_artifacts import (  # noqa: E402
    write_sequence_desync_artifact,
)
from pokiguard_v2.win32_input import (  # noqa: E402
    CoordinateSafetyError,
    ForegroundClickExecutor,
    NativeWin32Backend,
    RecoveryHotkeyEdges,
    find_window_for_pid,
)
from pokiguard_v2.win32_screenshot import (  # noqa: E402
    capture_client_png,
    capture_client_rgb,
)
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.runtime_common import attach_target, hex_pointer  # noqa: E402
from tools.sequence_desync_runtime import RuntimeSequenceMonitor  # noqa: E402
from tools.idle_state_watch import (  # noqa: E402
    _read_board_observation,
    read_match_runtime,
)


def _jsonable(value: Any) -> Any:
    if is_dataclass(value):
        return _jsonable(asdict(value))
    if isinstance(value, Enum):
        return value.value
    if isinstance(value, dict):
        return {str(key): _jsonable(item) for key, item in value.items()}
    if isinstance(value, (tuple, list, set)):
        return [_jsonable(item) for item in value]
    return value


def _write(log: Any, event: str, **fields: Any) -> None:
    log.write(
        json.dumps(
            {"timestamp": utc_timestamp(), "event": event, **_jsonable(fields)},
            ensure_ascii=False,
            separators=(",", ":"),
        )
        + "\n"
    )
    log.flush()


def _beep() -> bool:
    if winsound is None:
        return False
    try:
        winsound.Beep(440, 180)
        winsound.Beep(330, 260)
        return True
    except RuntimeError:
        return False


def _locate_temporally(
    pid: int,
    locator: Any,
    *,
    attempts: int = 6,
    interval: float = 0.12,
    minimum_hits: int = 2,
) -> RecoveryUiLocation:
    """Accept a blinking UI control only after consistent multi-frame hits."""

    positives: list[RecoveryUiLocation] = []
    last: RecoveryUiLocation | None = None
    for _ in range(attempts):
        capture = capture_client_rgb(pid)
        last = locator(capture.rgb, capture.width, capture.height)
        if last.found and last.normalized_point is not None:
            positives.append(last)
        time.sleep(interval)
    if len(positives) < minimum_hits:
        return last or RecoveryUiLocation(
            control=(
                RecoveryControl.CONFIRM_LEAVE
                if locator is locate_confirm_leave
                else RecoveryControl.EXIT_BACK
            ),
            found=False,
            normalized_point=None,
            confidence=0.0,
            reason="temporal_locator_no_samples",
        )
    xs = [item.normalized_point[0] for item in positives]
    ys = [item.normalized_point[1] for item in positives]
    if max(xs) - min(xs) > 0.015 or max(ys) - min(ys) > 0.020:
        return RecoveryUiLocation(
            positives[0].control,
            False,
            None,
            0.0,
            "temporal_locator_centers_disagree",
            {"hits": len(positives)},
        )
    best = max(positives, key=lambda item: item.confidence)
    return RecoveryUiLocation(
        best.control,
        True,
        (sum(xs) / len(xs), sum(ys) / len(ys)),
        best.confidence,
        "temporally_consistent:" + best.reason,
        {**best.metrics, "hits": len(positives), "attempts": attempts},
    )


def _live_exit_calibration(
    *,
    pid: int,
    width: int,
    height: int,
) -> RecoveryUiLocation | None:
    """Load an exact-dimension, live-proven blinking-control calibration."""

    paths = sorted(
        (PROJECT_ROOT / "reference").glob("exit_ui_live_calibration*.json")
    )
    for path in paths:
        try:
            payload = json.loads(path.read_text(encoding="utf-8"))
            if payload.get("schema") != "pokiguard.exit_ui_calibration.v1":
                continue
            if payload.get("processName") != "Pokiguard.exe":
                continue
            if (
                payload.get("clientWidth") != width
                or payload.get("clientHeight") != height
            ):
                continue
            point = tuple(float(value) for value in payload["normalizedPoint"])
            evidence = payload.get("evidence") or {}
            if (
                len(point) != 2
                or evidence.get("clickStatus") != "SENT"
                or int(evidence.get("confirmModalHits", 0)) < 2
            ):
                continue
            return RecoveryUiLocation(
                RecoveryControl.EXIT_BACK,
                True,
                (point[0], point[1]),
                0.99,
                "live_proven_blinking_exit_hitbox_calibration",
                {
                    "pid": pid,
                    "clientWidth": width,
                    "clientHeight": height,
                    "calibrationFile": str(path),
                    "sourceLog": str(evidence.get("sourceLog")),
                    "confirmModalHits": int(evidence.get("confirmModalHits", 0)),
                },
            )
        except (KeyError, OSError, TypeError, ValueError, json.JSONDecodeError):
            continue
    return None


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    mode = parser.add_mutually_exclusive_group(required=True)
    mode.add_argument(
        "--manual-test",
        action="store_true",
        help="test only the UI exit flow; does not claim a desync occurred",
    )
    mode.add_argument(
        "--watch-desync",
        action="store_true",
        help="arm recovery only after a real FORCE_RESYNC/sequence reject",
    )
    parser.add_argument("--single-step", action="store_true", required=True)
    parser.add_argument("--log", type=Path)
    parser.add_argument("--interval", type=float, default=0.15)
    parser.add_argument("--timeout", type=float, default=0.0)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    return parser


def run(args: argparse.Namespace) -> int:
    if not 0.05 <= args.interval <= 2.0:
        raise ValueError("--interval must be between 0.05 and 2 seconds")
    if args.timeout < 0:
        raise ValueError("--timeout cannot be negative")
    log_path = (
        args.log
        or PROJECT_ROOT
        / "logs"
        / f"phase2c2a4_recovery_{datetime.now():%Y%m%d_%H%M%S}.jsonl"
    ).resolve()
    log_path.parent.mkdir(parents=True, exist_ok=True)

    backend = NativeWin32Backend()
    hotkeys = RecoveryHotkeyEdges()
    recovery = RecoveryStateMachine()
    with attach_target() as target, log_path.open(
        "a", encoding="utf-8", buffering=1
    ) as log:
        binding = find_window_for_pid(target.pid, backend)
        executor = ForegroundClickExecutor(backend)
        provider = MemoryBoardStateProvider(
            target,
            MemoryProviderConfig(
                max_region_mib=args.max_region_mib,
                chunk_mib=args.chunk_mib,
                required_confirmations=2,
                require_lobby_start=False,
            ),
        )
        monitor = RuntimeSequenceMonitor(
            target,
            max_region_mib=args.max_region_mib,
            chunk_mib=args.chunk_mib,
        )
        recovery_sessions = CombatSessionTracker()
        _write(
            log,
            "sequence_recovery_started",
            mode=("MANUAL_UI_FLOW_TEST" if args.manual_test else "REAL_DESYNC_ONLY"),
            inputMode="F10_SINGLE_UI_STEP_CONFIRMED",
            stopKey="F9",
            automaticExit=False,
            automaticReentry=False,
            processAccess=["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"],
            normalInputApi="SetCursorPos+mouse_event",
            gameAssemblyBase=hex_pointer(target.game_assembly.base),
        )
        print(f"Recovery controller log: {log_path}", flush=True)
        print("F10 = confirm ONE proven recovery UI step; F9 = stop.", flush=True)
        if args.manual_test:
            print(
                "MANUAL UI FLOW TEST: F10 will intentionally leave the current combat; "
                "this is not a desync claim.",
                flush=True,
            )

        started = time.monotonic()
        previous_lifecycle = None
        active_session = None
        manual_armed = False
        confirm_sent = False
        last_stable_state = None
        while target.is_running():
            if args.timeout and time.monotonic() - started >= args.timeout:
                _write(log, "recovery_timeout", state=recovery.state)
                return 2
            advance, stop = hotkeys.poll()
            if stop:
                _write(log, "emergency_stop", key="F9", state=recovery.state)
                return 130
            poll = provider.poll()
            if poll.state is not None:
                last_stable_state = poll.state
            try:
                _match_service, runtime = read_match_runtime(target)
                _board_instance, board_observation = _read_board_observation(target)
                direct_lifecycle = read_combat_lifecycle(
                    target.resolver,
                    board=(
                        board_observation
                        if board_observation is not None and board_observation.accepted
                        else None
                    ),
                    match_id=runtime.match_id,
                    match_over=(
                        poll.combat_lifecycle.signals.match_over
                        if poll.combat_lifecycle is not None
                        else None
                    ),
                    deferred_game_over=(
                        poll.combat_lifecycle.signals.deferred_game_over
                        if poll.combat_lifecycle is not None
                        else None
                    ),
                )
                lifecycle = direct_lifecycle.state
                lifecycle_reason = direct_lifecycle.reason
                runtime_session = recovery_sessions.observe(
                    lifecycle,
                    direct_lifecycle.signals.board_instance,
                    direct_lifecycle.signals.match_id,
                )
            except (OSError, RuntimeError, ValueError) as exc:
                lifecycle = CombatLifecycleState.UNKNOWN
                lifecycle_reason = f"direct_lifecycle_error:{exc}"
                runtime = None
                runtime_session = recovery_sessions.observe(lifecycle, None, None)
            if lifecycle != previous_lifecycle:
                _write(
                    log,
                    "combat_lifecycle_changed",
                    lifecycle=lifecycle,
                    reason=(
                        lifecycle_reason
                    ),
                    session=runtime_session,
                )
                previous_lifecycle = lifecycle
            if runtime_session is not None and runtime_session != active_session:
                if active_session is not None:
                    monitor.end_session(active_session)
                active_session = runtime_session
                monitor.begin_session(
                    active_session,
                    active_session.match_id,
                    clean=True,
                )
            if active_session is not None and lifecycle is not CombatLifecycleState.ACTIVE:
                monitor.end_session(active_session)

            if (
                args.manual_test
                and not manual_armed
                and lifecycle is CombatLifecycleState.ACTIVE
            ):
                recovery.manual_test_required()
                manual_armed = True
                existing_modal = _locate_temporally(
                    target.pid,
                    locate_confirm_leave,
                    attempts=3,
                    interval=0.08,
                    minimum_hits=2,
                )
                if existing_modal.found:
                    recovery.request()
                    recovery.exit_control_clicked()
                    recovery.modal_visible()
                _write(
                    log,
                    "recovery_required",
                    reason="MANUAL_UI_FLOW_TEST",
                    realDesync=False,
                    state=recovery.state,
                    beep=_beep(),
                    preexistingConfirmModal=(existing_modal if existing_modal.found else None),
                )
                print(
                    (
                        "Leave modal already proven. Press F10 to confirm exit."
                        if existing_modal.found
                        else "UI exit locator armed. Press F10 for the Exit/Back step."
                    ),
                    flush=True,
                )
                # A key press made before the explicit ready signal cannot
                # authorize the first recovery click.
                advance = False

            if (
                args.watch_desync
                and active_session is not None
                and lifecycle is CombatLifecycleState.ACTIVE
            ):
                state = poll.state
                observation = monitor.poll(
                    session_key=active_session,
                    match_id=active_session.match_id,
                    turn=(
                        runtime.turn
                        if runtime is not None
                        else state.battle.turn_number if state is not None else None
                    ),
                    srv_seq=(state.battle.srv_seq if state is not None else None),
                    timestamp=utc_timestamp(),
                )
                if observation.first_detected:
                    recovery.desync_detected()
                    _write(
                        log,
                        "recovery_required",
                        reason="SEQUENCE_DESYNC",
                        realDesync=True,
                        desync=monitor.tracker.state,
                        state=recovery.state,
                        beep=_beep(),
                    )
                    if last_stable_state is not None:
                        try:
                            artifact = write_sequence_desync_artifact(
                                PROJECT_ROOT / "logs" / "sequence_desync",
                                desync=monitor.tracker.state,
                                state=last_stable_state,
                                recent_events=monitor.events.snapshot(),
                                screenshot_writer=lambda path: capture_client_png(
                                    target.pid, path
                                ),
                                correlation={
                                    "fusionState": last_stable_state.fusion,
                                    "causalConclusion": "UNKNOWN",
                                },
                            )
                            _write(
                                log,
                                "sequence_desync_artifact_saved",
                                directory=str(artifact.directory),
                            )
                        except (FileExistsError, OSError, RuntimeError, ValueError) as exc:
                            _write(
                                log,
                                "sequence_desync_artifact_error",
                                detail=str(exc),
                            )
                    print("SEQUENCE_DESYNC locked. Press F10 for Exit/Back.", flush=True)
                    advance = False

            if recovery.state is RecoveryLifecycleState.EXIT_CONTROL_CLICKED:
                modal = _locate_temporally(
                    target.pid,
                    locate_confirm_leave,
                    attempts=3,
                    interval=0.08,
                    minimum_hits=2,
                )
                if modal.found:
                    recovery.modal_visible()
                    _write(log, "confirm_modal_proven", locator=modal)
                    _beep()
                    print("Leave modal proven. Press F10 to confirm exit.", flush=True)

            if advance and recovery.state is RecoveryLifecycleState.RECOVERY_REQUIRED:
                hover = executor.move_normalized_point(
                    binding, (0.04134466769706337, 0.06824712643678162)
                )
                if hover.value != "SENT":
                    recovery.block(hover.value)
                    _write(log, "recovery_blocked", control="EXIT_BACK_HOVER", status=hover)
                    return 3
                locator = _locate_temporally(target.pid, locate_exit_back)
                if not locator.found:
                    current_capture = capture_client_rgb(target.pid)
                    calibrated = _live_exit_calibration(
                        pid=target.pid,
                        width=current_capture.width,
                        height=current_capture.height,
                    )
                    if calibrated is not None:
                        locator = calibrated
                        _write(
                            log,
                            "blinking_exit_calibration_used",
                            locator=locator,
                            temporalLocatorFailed=True,
                        )
                if not locator.found:
                    recovery.block(locator.reason)
                    _write(log, "recovery_blocked", control="EXIT_BACK", locator=locator)
                    print(f"RECOVERY_BLOCKED: {locator.reason}", flush=True)
                    return 3
                recovery.request()
                result = executor.send_normalized_point(binding, locator.normalized_point)
                _write(log, "recovery_ui_step", control="EXIT_BACK", locator=locator, result=result)
                if not result.sent:
                    recovery.block(result.status.value)
                    return 3
                recovery.exit_control_clicked()
                print("Exit/Back clicked once; waiting to prove leave modal.", flush=True)
            elif advance and recovery.state is RecoveryLifecycleState.CONFIRM_MODAL_VISIBLE:
                capture = capture_client_rgb(target.pid)
                locator = locate_confirm_leave(capture.rgb, capture.width, capture.height)
                if not locator.found:
                    recovery.block(locator.reason)
                    _write(log, "recovery_blocked", control="CONFIRM_LEAVE", locator=locator)
                    print(f"RECOVERY_BLOCKED: {locator.reason}", flush=True)
                    return 3
                result = executor.send_normalized_point(binding, locator.normalized_point)
                _write(log, "recovery_ui_step", control="CONFIRM_LEAVE", locator=locator, result=result)
                if not result.sent:
                    recovery.block(result.status.value)
                    return 3
                confirm_sent = True
                print("Confirm-exit clicked once; waiting for hardened lifecycle exit.", flush=True)
            elif advance:
                _write(log, "confirmation_ignored", state=recovery.state, key="F10")

            if confirm_sent:
                recovery.observe_lifecycle(lifecycle)
                if recovery.state is RecoveryLifecycleState.BOSS_MAP_OR_LOBBY:
                    stale = lifecycle is CombatLifecycleState.STALE_SERVER_MATCH
                    _write(
                        log,
                        "single_step_exit_pass",
                        lifecycle=lifecycle,
                        staleServerMatch=stale,
                        actionable=False,
                        localCombatUiExited=True,
                        recoveryState=recovery.state,
                        noStrayGameplayClick=True,
                    )
                    print(
                        "SINGLE-STEP EXIT PASS: local combat rig/UI exited"
                        + ("; stale server match remains non-actionable." if stale else "."),
                        flush=True,
                    )
                    return 0
            time.sleep(args.interval)
        return 1


def main(argv: Sequence[str] | None = None) -> int:
    try:
        return run(build_parser().parse_args(argv))
    except KeyboardInterrupt:
        return 130
    except (
        CoordinateSafetyError,
        FileNotFoundError,
        OSError,
        ProcessProbeError,
        ProviderSetupError,
        RuntimeError,
        ValueError,
    ) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
