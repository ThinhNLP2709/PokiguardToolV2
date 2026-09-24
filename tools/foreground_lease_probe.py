#!/usr/bin/env python3
"""Phase 4A.1-R2 live probe for a pinned, bounded foreground lease.

B1 pins the exact game HWND as topmost without activating it and proves the
selected boss-lobby Start control with zero input.  Optional B2 waits for an
explicit arm, acquires the foreground once, clicks that proven Start through
the accepted foreground executor, releases focus/cursor, then checks the
read-only session/opening acknowledgement.
"""

from __future__ import annotations

import argparse
from contextlib import ExitStack
from datetime import datetime
from pathlib import Path
import sys
import time
from typing import Any


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.app_paths import current_app_paths  # noqa: E402
from pokiguard_v2.boss_entry import FarmTarget  # noqa: E402
from pokiguard_v2.controller_lease import AutomationControllerLease  # noqa: E402
from pokiguard_v2.combat_lifecycle import CombatLifecycleState  # noqa: E402
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
)
from pokiguard_v2.win32_input import (  # noqa: E402
    ForegroundClickExecutor,
    NativeWin32Backend,
    find_window_for_pid,
)
from pokiguard_v2.win32_screenshot import write_png_rgb  # noqa: E402
from tools.background_mouse_probe import (  # noqa: E402
    ArtifactLog,
    StopController,
    _capture_start_proof,
    _entry_state_accepted,
    _git_head,
    _lobby_preflight,
    _sha256,
)
from tools.background_mouse_transport import ExactWindowBinding  # noqa: E402
from tools.foreground_lease_transport import (  # noqa: E402
    BoundedForegroundLease,
    LeaseStatus,
    NativeForegroundLeaseBackend,
    PinnedWindowSession,
)
from tools.runtime_common import attach_target  # noqa: E402


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    target = parser.add_mutually_exclusive_group(required=True)
    target.add_argument("--boss-id")
    target.add_argument("--boss-name")
    parser.add_argument(
        "--live-start",
        action="store_true",
        help="after B1, arm exactly one foreground-lease Start click",
    )
    parser.add_argument(
        "--prearmed",
        action="store_true",
        help="use the command invocation itself as the B2 arm (requires --live-start)",
    )
    parser.add_argument("--artifacts", type=Path)
    parser.add_argument("--lobby-timeout", type=float, default=120.0)
    parser.add_argument("--opening-timeout", type=float, default=40.0)
    parser.add_argument("--interval", type=float, default=0.12)
    parser.add_argument("--required-idle", type=float, default=0.45)
    parser.add_argument("--idle-timeout", type=float, default=8.0)
    parser.add_argument("--focus-settle", type=float, default=0.40)
    parser.add_argument("--cursor-settle", type=float, default=0.25)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    return parser


def _validate_args(args: argparse.Namespace) -> None:
    if args.prearmed and not args.live_start:
        raise ValueError("--prearmed requires --live-start")
    if not 5 <= args.lobby_timeout <= 600:
        raise ValueError("--lobby-timeout must be between 5 and 600 seconds")
    if not 5 <= args.opening_timeout <= 300:
        raise ValueError("--opening-timeout must be between 5 and 300 seconds")
    if not 0.08 <= args.interval <= 0.50:
        raise ValueError("--interval must be between 0.08 and 0.50 seconds")
    if not 0.20 <= args.required_idle <= 2.0:
        raise ValueError("--required-idle must be between 0.20 and 2.0 seconds")
    if not args.required_idle <= args.idle_timeout <= 30.0:
        raise ValueError("--idle-timeout is outside the bounded range")
    if not 0.10 <= args.focus_settle <= 1.0:
        raise ValueError("--focus-settle must be between 0.10 and 1.0 seconds")
    if not 0.05 <= args.cursor_settle <= 0.25:
        raise ValueError("--cursor-settle must be between 0.05 and 0.25 seconds")


def _console_arm(stop: StopController) -> bool:
    print(
        "Nhập chính xác 'ARM B2-LEASE' rồi Enter. Sau đó không chạm chuột/phím "
        "trong khoảng nửa giây; F9 để dừng.",
        flush=True,
    )
    try:
        value = input().strip()
    except (EOFError, KeyboardInterrupt):
        return False
    return value == "ARM B2-LEASE" and not stop.requested()


def _exact_binding(
    target: Any,
    input_backend: NativeWin32Backend,
    lease_backend: NativeForegroundLeaseBackend,
) -> ExactWindowBinding:
    window = find_window_for_pid(target.pid, input_backend)
    geometry = input_backend.client_geometry(window.hwnd)
    if geometry is None:
        raise RuntimeError("game window has no valid non-minimized client geometry")
    exact = ExactWindowBinding(window, geometry)
    if lease_backend.window_pid(window.hwnd) != target.pid:
        raise RuntimeError("bound HWND no longer belongs to the attached PID")
    if lease_backend.window_title(window.hwnd) != window.title:
        raise RuntimeError("bound HWND title changed during attach")
    return exact


def _fresh_active_lifecycle_ack(
    *,
    old_session: Any,
    session: Any,
    lifecycle: Any,
) -> bool:
    """Accept a fresh, locally owned ACTIVE session without requiring DTO timing."""

    if (
        session is None
        or session == old_session
        or lifecycle is None
        or lifecycle.state is not CombatLifecycleState.ACTIVE
    ):
        return False
    signals = lifecycle.signals
    return bool(
        session.match_id == signals.match_id
        and session.board_instance == signals.board_instance
        and signals.current_rig_alive is True
        and signals.objects_consistent is True
        and signals.board_ready is True
        and not signals.read_errors
    )


def _wait_lease_opening_ack(
    *,
    target: Any,
    provider: MemoryBoardStateProvider,
    old_session: Any,
    timeout: float,
    interval: float,
    log: ArtifactLog,
) -> tuple[bool, Any, str | None, Any]:
    """Wait for either exact opening DTO or two fresh ACTIVE lifecycle samples."""

    deadline = time.monotonic() + timeout
    active_session = None
    active_confirmations = 0
    last_poll = None
    while target.is_running() and time.monotonic() < deadline:
        poll = provider.poll()
        last_poll = poll
        state = poll.state
        exact_opening = _entry_state_accepted(
            state,
            old_session=old_session,
            require_match_start_opening=True,
        )
        lifecycle_ack = _fresh_active_lifecycle_ack(
            old_session=old_session,
            session=poll.session_key,
            lifecycle=poll.combat_lifecycle,
        )
        if lifecycle_ack:
            if poll.session_key == active_session:
                active_confirmations += 1
            else:
                active_session = poll.session_key
                active_confirmations = 1
        elif poll.session_key != active_session:
            active_session = None
            active_confirmations = 0
        log.event(
            "b2_ack_poll",
            reason=poll.reason,
            session=poll.session_key,
            lifecycle=poll.combat_lifecycle,
            hasState=state is not None,
            exactOpening=exact_opening,
            freshActiveLifecycle=lifecycle_ack,
            activeConfirmations=active_confirmations,
        )
        if exact_opening:
            return True, state, "MATCH_START_OPENING_DTO", poll
        if active_confirmations >= 2:
            return True, state, "FRESH_ACTIVE_LIFECYCLE_X2", poll
        time.sleep(interval)
    return False, None, None, last_poll


def run(args: argparse.Namespace) -> int:
    _validate_args(args)
    artifact_root = (
        args.artifacts
        or PROJECT_ROOT
        / "logs"
        / "phase4a1_r2"
        / f"probe_{datetime.now():%Y%m%d_%H%M%S}"
    ).resolve()
    log = ArtifactLog(artifact_root)
    log.summary = {
        "phase": "4A.1-R2",
        "status": "RUNNING",
        "stages": {"B1": "NOT_RUN", "B2": "NOT_RUN"},
        "inputCounts": {"foregroundLeaseStartClick": 0},
        "productionIntegration": False,
        "artifacts": str(artifact_root),
    }
    stop = StopController()
    stop.start()
    exit_code = 2
    pin_session: PinnedWindowSession | None = None
    try:
        with ExitStack() as stack:
            stack.enter_context(
                AutomationControllerLease(
                    current_app_paths().logs_root / ".automation_controller.lock"
                )
            )
            target = stack.enter_context(attach_target())
            input_backend = NativeWin32Backend()
            lease_backend = NativeForegroundLeaseBackend(input_backend)
            exact = _exact_binding(target, input_backend, lease_backend)
            provider = MemoryBoardStateProvider(
                target,
                MemoryProviderConfig(
                    max_region_mib=args.max_region_mib,
                    chunk_mib=args.chunk_mib,
                    required_confirmations=2,
                    require_lobby_start=True,
                ),
            )
            farm_target = FarmTarget(args.boss_id, args.boss_name)
            log.summary.update(
                sourceCommit=_git_head(),
                pid=target.pid,
                hwnd=exact.window.hwnd,
                title=exact.window.title,
                clientGeometry=exact.geometry,
                gameAssemblyPath=str(target.game_assembly.path),
                gameAssemblySha256=_sha256(target.game_assembly.path),
                processAccess=["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"],
                transport="PINNED_FOREGROUND_LEASE_HARNESS",
            )
            log.event(
                "probe_started",
                summary=log.summary,
                foregroundHwnd=lease_backend.foreground_window(),
                cursor=lease_backend.cursor_pos(),
            )

            pin_session = PinnedWindowSession(
                lease_backend,
                exact,
                event_sink=log.sink,
            )
            pin_result = pin_session.pin()
            log.summary["pinResult"] = pin_result
            log.save()
            if not pin_result.pinned:
                raise RuntimeError(pin_result.reason)

            print(f"Phase 4A.1-R2 artifacts: {artifact_root}", flush=True)
            print(
                "Game đã được ghim TOPMOST nhưng chưa bị kích hoạt. Chuyển focus "
                "sang cửa sổ khác; B1 chỉ đọc và không gửi input. F9 = dừng.",
                flush=True,
            )
            cursor_set_requests_before = lease_backend.cursor_set_requests
            foreground_requests_before = lease_backend.foreground_requests
            proof = _capture_start_proof(
                target=target,
                provider=provider,
                farm_target=farm_target,
                exact=exact,
                backend=lease_backend,  # duck-typed observation surface
                timeout=args.lobby_timeout,
                interval=args.interval,
                log=log,
            )
            write_png_rgb(
                artifact_root / "b1_start_proof.png",
                proof.capture.width,
                proof.capture.height,
                proof.capture.rgb,
            )
            cursor_before = lease_backend.cursor_pos()
            time.sleep(max(args.interval, 0.14))
            cursor_after = lease_backend.cursor_pos()
            b1_pass = bool(
                not stop.requested()
                and lease_backend.is_topmost(exact.window.hwnd)
                and lease_backend.foreground_window() != exact.window.hwnd
                and lease_backend.client_geometry(exact.window.hwnd) == exact.geometry
                and lease_backend.cursor_set_requests == cursor_set_requests_before
                and lease_backend.foreground_requests == foreground_requests_before
            )
            log.summary["stages"]["B1"] = "ACCEPTED" if b1_pass else "FAILED"
            log.event(
                "b1_finished",
                result=log.summary["stages"]["B1"],
                proof=proof,
                topmost=lease_backend.is_topmost(exact.window.hwnd),
                foregroundHwnd=lease_backend.foreground_window(),
                cursorBefore=cursor_before,
                cursorAfter=cursor_after,
                cursorChangedExternally=cursor_before != cursor_after,
                cursorSetRequests=(
                    lease_backend.cursor_set_requests - cursor_set_requests_before
                ),
                foregroundRequests=(
                    lease_backend.foreground_requests - foreground_requests_before
                ),
                zeroInput=True,
            )
            log.save()
            if not b1_pass:
                raise RuntimeError("B1 topmost/nonforeground zero-input proof failed")
            print("B1 ACCEPTED: ghim nổi, game ở nền, zero input.", flush=True)

            if not args.live_start:
                log.summary.update(
                    status="B1_COMPLETE_ZERO_INPUT",
                    stopReason="B2_NOT_ARMED",
                )
                exit_code = 0
                return exit_code
            if not args.prearmed and not _console_arm(stop):
                log.summary.update(status="STOPPED", stopReason="B2_ARM_NOT_SUPPLIED")
                exit_code = 0
                return exit_code

            old_session = provider.current_session_key
            geometry = exact.geometry
            expected_cursor = (
                geometry.left + int(proof.normalized_point[0] * (geometry.width - 1)),
                geometry.top + int(proof.normalized_point[1] * (geometry.height - 1)),
            )
            click_executor = ForegroundClickExecutor(
                input_backend,
                cursor_settle_seconds=args.cursor_settle,
            )
            click_holder: dict[str, Any] = {}

            def action() -> bool:
                click = click_executor.send_normalized_point(
                    exact.window,
                    proof.normalized_point,
                    settle_cursor=True,
                )
                click_holder["result"] = click
                log.event("b2_foreground_click", result=click)
                return click.sent

            lease = BoundedForegroundLease(
                lease_backend,
                stop_requested=stop.requested,
                event_sink=log.sink,
                required_idle_seconds=args.required_idle,
                idle_timeout_seconds=args.idle_timeout,
                focus_settle_seconds=args.focus_settle,
            )
            lease.arm(
                exact,
                f"B2:{proof.target_key}:{proof.signature}:START_SINGLE_CLICK",
            )
            delivery = lease.execute(
                action,
                preflight=lambda: _lobby_preflight(
                    target=target,
                    provider=provider,
                    farm_target=farm_target,
                    proof=proof,
                ),
                expected_cursor_after=expected_cursor,
            )
            if delivery.action_attempted:
                log.summary["inputCounts"]["foregroundLeaseStartClick"] = 1

            accepted = False
            opening_state = None
            ack_kind = None
            ack_poll = None
            if delivery.action_succeeded:
                accepted, opening_state, ack_kind, ack_poll = _wait_lease_opening_ack(
                    target=target,
                    provider=provider,
                    old_session=old_session,
                    timeout=args.opening_timeout,
                    interval=args.interval,
                    log=log,
                )
            stage_result = (
                "ACCEPTED"
                if accepted
                else (
                    "UNCONFIRMED"
                    if delivery.action_succeeded
                    else "NOT_RUN"
                )
            )
            log.summary["stages"]["B2"] = stage_result
            log.summary.update(
                status=(
                    "LIVE_START_ACCEPTED"
                    if accepted
                    else "LIVE_START_NOT_ACCEPTED"
                ),
                stopReason=(
                    "AUTHORITATIVE_OPENING_ACK"
                    if accepted
                    else delivery.status.value
                ),
                leaseStatus=delivery.status.value,
            )
            log.event(
                "b2_finished",
                result=stage_result,
                lease=delivery,
                click=click_holder.get("result"),
                authoritativeAck=accepted,
                ackKind=ack_kind,
                ackPoll=ack_poll,
                openingState=opening_state,
                noRetry=True,
            )
            log.save()
            print(
                f"B2 {stage_result}: lease={delivery.status.value}, "
                f"ACK={accepted}. Không tự retry.",
                flush=True,
            )
            exit_code = 0 if accepted else 3
            return exit_code
    except Exception as exc:
        log.summary.update(status="FAILED", stopReason=f"{type(exc).__name__}: {exc}")
        log.event("probe_failed", errorType=type(exc).__name__, error=str(exc))
        print(f"Probe failed: {type(exc).__name__}: {exc}", file=sys.stderr, flush=True)
        return exit_code
    finally:
        if pin_session is not None:
            unpin_result = pin_session.close()
            log.summary["unpinResult"] = unpin_result
        stop.stop()
        log.close()


def main() -> int:
    return run(build_parser().parse_args())


if __name__ == "__main__":
    raise SystemExit(main())
