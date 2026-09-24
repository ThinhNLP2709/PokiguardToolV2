#!/usr/bin/env python3
"""Phase 4A.1-R2 B3: one exact board swap through a foreground lease."""

from __future__ import annotations

import argparse
from contextlib import ExitStack
from datetime import datetime
from pathlib import Path
import sys
from typing import Any


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.app_paths import current_app_paths  # noqa: E402
from pokiguard_v2.controller_lease import AutomationControllerLease  # noqa: E402
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
)
from pokiguard_v2.win32_input import (  # noqa: E402
    BoardCalibration,
    ForegroundClickExecutor,
    NativeWin32Backend,
    map_swap_to_pixels,
)
from tools.background_mouse_probe import (  # noqa: E402
    ArtifactLog,
    StopController,
    _git_head,
    _runtime_preflight,
    _sha256,
    _wait_board_proposal,
    _wait_swap_ack,
)
from tools.foreground_lease_probe import _exact_binding  # noqa: E402
from tools.foreground_lease_transport import (  # noqa: E402
    BoundedForegroundLease,
    LeaseStatus,
    NativeForegroundLeaseBackend,
    PinnedWindowSession,
)
from tools.runtime_common import attach_target  # noqa: E402
from tools.idle_state_watch import read_match_runtime  # noqa: E402
from tools.dispatcher_qte_result_tap import DispatcherTransportTap  # noqa: E402


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument(
        "--prearmed",
        action="store_true",
        help="the command invocation explicitly arms one B3 swap",
    )
    parser.add_argument("--artifacts", type=Path)
    parser.add_argument("--board-timeout", type=float, default=120.0)
    parser.add_argument("--ack-timeout", type=float, default=12.0)
    parser.add_argument("--interval", type=float, default=0.12)
    parser.add_argument("--minimum-action-time", type=int, default=7)
    parser.add_argument("--required-idle", type=float, default=0.25)
    parser.add_argument("--idle-timeout", type=float, default=0.75)
    parser.add_argument("--focus-settle", type=float, default=0.40)
    parser.add_argument("--post-action-settle", type=float, default=0.20)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    return parser


def _validate_args(args: argparse.Namespace) -> None:
    if not args.prearmed:
        raise ValueError("B3 input requires explicit --prearmed")
    if not 10 <= args.board_timeout <= 600:
        raise ValueError("--board-timeout must be between 10 and 600 seconds")
    if not 2 <= args.ack_timeout <= 60:
        raise ValueError("--ack-timeout must be between 2 and 60 seconds")
    if not 0.08 <= args.interval <= 0.50:
        raise ValueError("--interval must be between 0.08 and 0.50 seconds")
    if not 4 <= args.minimum_action_time <= 10:
        raise ValueError("--minimum-action-time must be between 4 and 10 seconds")
    if not 0.20 <= args.required_idle <= 2.0:
        raise ValueError("--required-idle must be between 0.20 and 2.0 seconds")
    if not args.required_idle <= args.idle_timeout <= 30.0:
        raise ValueError("--idle-timeout is outside the bounded range")
    if not 0.10 <= args.focus_settle <= 1.0:
        raise ValueError("--focus-settle must be between 0.10 and 1.0 seconds")
    if not 0.08 <= args.post_action_settle <= 0.50:
        raise ValueError("--post-action-settle must be between 0.08 and 0.50 seconds")


def run(args: argparse.Namespace) -> int:
    _validate_args(args)
    artifact_root = (
        args.artifacts
        or PROJECT_ROOT
        / "logs"
        / "phase4a1_r2"
        / f"b3_{datetime.now():%Y%m%d_%H%M%S}"
    ).resolve()
    log = ArtifactLog(artifact_root)
    log.summary = {
        "phase": "4A.1-R2",
        "stage": "B3",
        "status": "RUNNING",
        "inputCounts": {"foregroundLeaseSwaps": 0},
        "productionIntegration": False,
        "artifacts": str(artifact_root),
    }
    stop = StopController()
    stop.start()
    pin_session: PinnedWindowSession | None = None
    exit_code = 2
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
                    # Match the accepted FarmRunner lifecycle: construct from
                    # the lobby so the provider owns the opening transition
                    # and can publish the mandatory first local turn.
                    require_lobby_start=True,
                    # Dot discovery is audit-only and must not consume the
                    # opening action deadline.
                    enable_dot_audit=False,
                ),
            )
            dispatcher_tap = stack.enter_context(DispatcherTransportTap(target))
            try:
                _service, lobby_runtime = read_match_runtime(target)
                lobby_match_id = lobby_runtime.match_id
            except (OSError, RuntimeError, ValueError):
                lobby_match_id = None
            dispatcher_tap.arm_for_new_match(lobby_match_id)
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
            pin_session = PinnedWindowSession(
                lease_backend,
                exact,
                event_sink=log.sink,
            )
            pin_result = pin_session.pin()
            log.summary["pinResult"] = pin_result
            log.event(
                "b3_probe_started",
                summary=log.summary,
                foregroundHwnd=lease_backend.foreground_window(),
                cursor=lease_backend.cursor_pos(),
                dispatcherTap=dispatcher_tap.diagnostics,
                lobbyMatchId=lobby_match_id,
            )
            log.save()
            if not pin_result.pinned:
                raise RuntimeError(pin_result.reason)

            print(f"Phase 4A.1-R2 B3 artifacts: {artifact_root}", flush=True)
            print(
                "B3 armed for exactly one swap. Keep the pinned game visible "
                "and enter the match normally. The probe may take mouse focus "
                "after 0.75 s and waits only for held mouse buttons. Press F9 "
                "to stop.",
                flush=True,
            )
            proposal = _wait_board_proposal(
                target=target,
                provider=provider,
                backend=lease_backend,
                exact=exact,
                minimum_turn=1,
                minimum_time=args.minimum_action_time,
                timeout=args.board_timeout,
                interval=args.interval,
                log=log,
                require_game_background=False,
                dispatcher_tap=dispatcher_tap,
                require_first_local_turn=True,
            )
            if proposal is None or stop.requested():
                log.summary.update(status="NOT_RUN", stopReason="NO_FRESH_LOCAL_TURN")
                log.event("b3_not_run", reason=log.summary["stopReason"])
                exit_code = 3
                return exit_code

            move = proposal.evaluation.move
            plan = map_swap_to_pixels(
                move.first,
                move.second,
                BoardCalibration(),
                exact.geometry,
                virtual_screen=input_backend.virtual_screen(),
            )
            log.event(
                "b3_proposal",
                preState=proposal.pre,
                boardHash=proposal.state.battle.board_hash,
                evaluation=proposal.evaluation,
                coordinatePlan=plan,
            )
            # Route cursor moves through the lease backend so its bounded
            # cursor-confinement fallback can advance to each click point when
            # Windows denies the stronger BlockInput API.
            executor = ForegroundClickExecutor(lease_backend)
            swap_holder: dict[str, Any] = {}

            def action() -> bool:
                result = executor.send_swap(
                    exact.window,
                    plan,
                    remaining_seconds=(
                        proposal.state.battle.turn_time_remaining_seconds
                    ),
                )
                swap_holder["result"] = result
                log.event("b3_foreground_swap", result=result)
                return result.sent

            lease = BoundedForegroundLease(
                lease_backend,
                stop_requested=stop.requested,
                event_sink=log.sink,
                required_idle_seconds=args.required_idle,
                idle_timeout_seconds=args.idle_timeout,
                focus_settle_seconds=args.focus_settle,
                allow_takeover_after_idle_timeout=True,
                allow_already_foreground=True,
                held_input_pressed=lease_backend.any_pointer_button_pressed,
                focus_request_attempts=3,
                require_exclusive_input=True,
                exclusive_input_attempts=3,
                post_action_settle_seconds=args.post_action_settle,
            )
            lease.arm(
                exact,
                (
                    f"B3:{proposal.pre.match_id}:{proposal.pre.turn}:"
                    f"{proposal.pre.local_move_sequence}:"
                    f"{move.first}->{move.second}"
                ),
            )
            delivery = lease.execute(
                action,
                preflight=lambda: _runtime_preflight(
                    proposal.pre,
                    read_match_runtime(target)[1],
                    args.minimum_action_time,
                ),
                expected_cursor_after=(plan.second.screen_x, plan.second.screen_y),
            )
            if delivery.action_attempted:
                log.summary["inputCounts"]["foregroundLeaseSwaps"] = 1

            swap_acked = explicit_reject = False
            post_runtime = None
            if delivery.action_succeeded:
                swap_acked, explicit_reject, post_runtime = _wait_swap_ack(
                    target=target,
                    pre=proposal.pre,
                    timeout=args.ack_timeout,
                    interval=args.interval,
                    log=log,
                )
            accepted = bool(
                swap_acked
                and delivery.status is LeaseStatus.COMPLETE
                and not explicit_reject
            )
            result = (
                "ACCEPTED"
                if accepted
                else ("UNCONFIRMED" if delivery.action_succeeded else "NOT_RUN")
            )
            log.summary.update(
                status=result,
                stopReason=(
                    "EXACT_SWAP_ACK"
                    if accepted
                    else delivery.status.value
                ),
                leaseStatus=delivery.status.value,
                swapAcked=swap_acked,
            )
            log.event(
                "b3_finished",
                result=result,
                proposal=proposal,
                lease=delivery,
                swap=swap_holder.get("result"),
                postRuntime=post_runtime,
                swapAcked=swap_acked,
                explicitReject=explicit_reject,
                noRetry=True,
            )
            log.save()
            print(
                f"B3 {result}: lease={delivery.status.value}, "
                f"SWAP_ACK={swap_acked}. Không tự retry.",
                flush=True,
            )
            exit_code = 0 if accepted else 3
            return exit_code
    except Exception as exc:
        log.summary.update(status="FAILED", stopReason=f"{type(exc).__name__}: {exc}")
        log.event("b3_probe_failed", errorType=type(exc).__name__, error=str(exc))
        print(f"B3 failed: {type(exc).__name__}: {exc}", file=sys.stderr, flush=True)
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
