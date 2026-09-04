#!/usr/bin/env python3
"""Arm one Phase 3B.2 QTE direction sequence; card click and Space stay manual."""

from __future__ import annotations

import argparse
from pathlib import Path
import signal
import sys
import time
from typing import Any, Callable


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.app_paths import current_app_paths  # noqa: E402
from pokiguard_v2.controller_lease import AutomationControllerLease  # noqa: E402
from pokiguard_v2.qte_direction_assist import (  # noqa: E402
    QteAssistEvent,
    QteAssistState,
    QteDirectionAssist,
    QteDirectionInputExecutor,
)
from pokiguard_v2.win32_input import NativeWin32Backend, find_window_for_pid  # noqa: E402
from tools.pet_qte_observer import run as run_observer  # noqa: E402
from tools.runtime_common import default_log_path  # noqa: E402


class Phase3b2RuntimeHook:
    """Bridge the read-only observer to one explicitly armed direction assist."""

    name = "PHASE3B2_QTE_DIRECTION_INPUT"

    def __init__(self, *, response_timeout_seconds: float) -> None:
        self._response_timeout_seconds = response_timeout_seconds
        self._emit: Callable[..., None] | None = None
        self._binding = None
        self._assist: QteDirectionAssist | None = None
        self._arm_consumed = False
        self._trace_cycle = 0
        self._trace_started = time.monotonic()

    @property
    def summary(self) -> Any:
        return self._assist.last_summary if self._assist is not None else None

    def attach(self, target: Any, emit: Callable[..., None]) -> None:
        if "64" not in str(target.architecture):
            raise RuntimeError("Phase 3B.2 requires the accepted x64 game target")
        backend = NativeWin32Backend()
        self._binding = find_window_for_pid(target.pid, backend)
        self._assist = QteDirectionAssist(
            QteDirectionInputExecutor(backend),
            response_timeout_seconds=self._response_timeout_seconds,
        )
        self._emit = emit
        emit(
            "qte_direction_harness_attached",
            pid=target.pid,
            hwnd=self._binding.hwnd,
            architecture=target.architecture,
            publicAllowedKeys=["UP", "DOWN", "LEFT", "RIGHT"],
            directionAckTimeoutSeconds=self._response_timeout_seconds,
            automatedPetSkillCardClicks=0,
            automatedSpacePresses=0,
            inputAuthority="QTE_DIRECTION_INPUT",
        )

    def started(self, log_path: Path) -> None:
        print(f"Phase 3B.2 QTE direction assist; log: {log_path}", flush=True)
        print(
            "WAITING TO ARM: enter combat normally. Pet Skill card click and Space remain MANUAL.",
            flush=True,
        )

    def trace_stage(self, stage: str) -> None:
        """Record only the first two observer cycles for live latency diagnosis."""

        if self._arm_consumed or self._emit is None:
            return
        if stage == "provider_poll_begin":
            self._trace_cycle += 1
        if self._trace_cycle > 2:
            return
        self._emit(
            "qte_direction_observer_stage",
            stage=stage,
            cycle=self._trace_cycle,
            elapsedSeconds=round(time.monotonic() - self._trace_started, 6),
        )

    def _events(self, events: tuple[QteAssistEvent, ...]) -> None:
        if self._emit is None:
            return
        for item in events:
            self._emit(
                item.event,
                assistState=item.state,
                reason=item.reason,
                directionRecord=item.direction_record,
                generationSummary=item.summary,
            )
            if item.event == "qte_direction_assist_armed":
                print(
                    "ARMED: manually click the Pet Skill card when ready; do not press directions.",
                    flush=True,
                )
            elif item.event == "qte_direction_sequence_complete":
                print(
                    "DIRECTIONS COMPLETE: assist DISARMED. Press Space manually at the desired timing.",
                    flush=True,
                )
            elif item.event == "qte_direction_assist_disarmed":
                print(
                    f"DIRECTION ASSIST DISARMED: {item.reason}. Finish manually if safe.",
                    flush=True,
                )

    def inactive(self, session: Any) -> None:
        if self._assist is None or self._binding is None or self._arm_consumed:
            return
        self._events(
            self._assist.arm(
                session_key=session,
                window_binding=self._binding,
                inactive_baseline_proven=True,
            )
        )
        self._arm_consumed = True

    def snapshot(self, value: Any, *, lifecycle_valid: bool) -> None:
        if (
            self._assist is None
            or self._binding is None
            or self._assist.state is QteAssistState.DISARMED
        ):
            return
        self._events(
            self._assist.observe(
                value,
                window_binding=self._binding,
                monotonic_now=time.monotonic(),
                lifecycle_valid=lifecycle_valid,
                authority_owned=True,
            )
        )

    def invalidate(self, reason: str) -> None:
        if self._assist is not None:
            self._events(self._assist.invalidate(reason))

    def unreadable(self, reason: str) -> None:
        if self._assist is not None:
            self._events(
                self._assist.observe_unavailable(
                    monotonic_now=time.monotonic(),
                    reason=reason,
                )
            )

    def stop(self, reason: str) -> None:
        if self._assist is not None:
            self._events(self._assist.abort(reason))


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument(
        "--arm-next",
        action="store_true",
        help="required explicit authority for exactly one fresh QTE generation",
    )
    parser.add_argument("--log", type=Path, help="JSONL output path")
    parser.add_argument("--interval", type=float, default=0.05)
    parser.add_argument("--timeout", type=float, default=900.0)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument(
        "--direction-ack-timeout",
        type=float,
        default=1.25,
        help="bounded read-only progress wait; an expiry never resends the key",
    )
    parser.add_argument(
        "--allow-combat-start",
        action="store_true",
        help="diagnostic only; boss-lobby start is the accepted live procedure",
    )
    return parser


def run(args: argparse.Namespace) -> int:
    if not args.arm_next:
        raise ValueError("start with --arm-next to authorize one QTE generation")
    log_path = (args.log or default_log_path("phase3b2_qte_direction")).resolve()
    observer_args = argparse.Namespace(
        watch=True,
        log=log_path,
        interval=args.interval,
        timeout=args.timeout,
        qtes=1,
        max_region_mib=args.max_region_mib,
        chunk_mib=args.chunk_mib,
        allow_combat_start=args.allow_combat_start,
    )
    hook = Phase3b2RuntimeHook(
        response_timeout_seconds=args.direction_ack_timeout,
    )
    previous_interrupt = signal.getsignal(signal.SIGINT)

    def operator_abort(_signum: int, _frame: Any) -> None:
        hook.stop("OPERATOR_ABORT")
        raise KeyboardInterrupt

    signal.signal(signal.SIGINT, operator_abort)
    try:
        with AutomationControllerLease(current_app_paths().controller_lock):
            return run_observer(observer_args, runtime_hook=hook)
    except KeyboardInterrupt:
        print("QTE direction assist stopped by operator; no further keys can be sent.", flush=True)
        return 130
    finally:
        signal.signal(signal.SIGINT, previous_interrupt)


def main() -> int:
    try:
        return run(build_parser().parse_args())
    except (OSError, RuntimeError, ValueError) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
