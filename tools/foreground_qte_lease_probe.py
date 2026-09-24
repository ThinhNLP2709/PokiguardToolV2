"""Phase 4A.2-R1 live probes for one pinned foreground QTE session lease."""

from __future__ import annotations

import argparse
from datetime import datetime
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
from pokiguard_v2.gameplay_profile import AuditionMode  # noqa: E402
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
)
from pokiguard_v2.pet_skill_action import PetSkillActionState  # noqa: E402
from pokiguard_v2.win32_input import NativeWin32Backend  # noqa: E402
from tools.background_mouse_probe import (  # noqa: E402
    ArtifactLog,
    StopController,
    _git_head,
    _sha256,
)
from tools.foreground_lease_probe import _exact_binding  # noqa: E402
from tools.foreground_lease_transport import (  # noqa: E402
    NativeForegroundLeaseBackend,
    PinnedWindowSession,
)
from tools.foreground_qte_lease_transport import (  # noqa: E402
    BoundedForegroundQteLease,
    NativeQteLeaseBackend,
    QteLeaseAcquireResult,
    QteLeaseMouseReleaseResult,
    QteLeaseReleaseResult,
    jsonable,
)
from tools.pet_qte_observer import run as run_observer  # noqa: E402
from tools.pet_skill_action import Phase3b3RuntimeHook  # noqa: E402
from tools.runtime_common import attach_target  # noqa: E402


class Phase4QteObservationHook:
    """B1: observe the current QTE instance and stop with zero input."""

    name = "PHASE4A2_B1_QTE_ZERO_INPUT_OBSERVATION"

    def __init__(self, *, stop_requested: Callable[[], bool], audition_mode: AuditionMode) -> None:
        self.stop_requested = stop_requested
        self.audition_mode = audition_mode
        self._emit: Callable[..., None] | None = None
        self.observation: Any | None = None
        self._stopped = False

    @property
    def done(self) -> bool:
        return bool(self._stopped or self.observation is not None or self.stop_requested())

    @property
    def summary(self) -> Any:
        return self.observation

    def attach(self, target: Any, emit: Callable[..., None]) -> None:
        self._emit = emit
        emit(
            "phase4_qte_b1_attached",
            pid=target.pid,
            zeroInput=True,
            auditionMode=self.audition_mode.value,
        )

    def started(self, log_path: Path) -> None:
        print(f"B1 zero-input QTE observation armed; log: {log_path}", flush=True)
        print(
            "Enter combat, build resources, then click the Pet Skill card manually. "
            "The probe observes the current QTE instance with zero input and stops.",
            flush=True,
        )

    def inactive(self, _session: Any) -> None:
        return

    def snapshot(self, value: Any, *, lifecycle_valid: bool) -> None:
        if self.observation is not None or not lifecycle_valid:
            return
        if value is not None and value.active and not value.completed:
            self.observation = value
            if self._emit is not None:
                self._emit(
                    "phase4_qte_b1_fresh_qte_observed",
                    qte=value,
                    zeroInput=True,
                )
            print("B1 OBSERVED: current QTE instance bound with zero input.", flush=True)

    def unreadable(self, _reason: str) -> None:
        return

    def invalidate(self, reason: str) -> None:
        if self._emit is not None:
            self._emit("phase4_qte_b1_invalidated", reason=reason)

    def stop(self, reason: str) -> None:
        if self._stopped:
            return
        self._stopped = True
        # The observer invokes stop once while its JSONL handle is still open.
        # The outer probe finally may call stop again after that handle closes;
        # the idempotent guard above prevents a cleanup-only log write from
        # masking an already accepted stage or skipping topmost release.
        if self._emit is not None:
            self._emit("phase4_qte_b1_stopped", reason=reason)


class Phase4FullQteLeaseHook(Phase3b3RuntimeHook):
    """Use the accepted full action unchanged inside one QTE session lease."""

    name = "PHASE4A2_PINNED_FOREGROUND_EXISTING_FULL_QTE"

    def __init__(
        self,
        *,
        backend: NativeQteLeaseBackend,
        binding: Any,
        lease: BoundedForegroundQteLease,
        stop_requested: Callable[[], bool],
        audition_mode: AuditionMode,
        direction_ack_timeout_seconds: float,
        qte_generation_timeout_seconds: float,
        result_timeout_seconds: float,
        require_external_foreground_before_acquire: bool = False,
    ) -> None:
        super().__init__(
            direction_ack_timeout_seconds=direction_ack_timeout_seconds,
            qte_generation_timeout_seconds=qte_generation_timeout_seconds,
            result_timeout_seconds=result_timeout_seconds,
            post_state_timeout_seconds=result_timeout_seconds,
            allow_zero_input_rearm=False,
            require_fusion_success=False,
            basic_policy_integration=False,
            provided_backend=backend,
            provided_binding=binding,
            audition_mode=audition_mode,
        )
        self._phase4_lease = lease
        self._phase4_stop_requested = stop_requested
        self._phase4_game_hwnd = int(binding.hwnd)
        self._require_external_foreground_before_acquire = bool(
            require_external_foreground_before_acquire
        )
        self.lease_acquire_result: QteLeaseAcquireResult | None = None
        self.mouse_release_result: QteLeaseMouseReleaseResult | None = None
        self.lease_release_result: QteLeaseReleaseResult | None = None

    @property
    def done(self) -> bool:
        if self._phase4_stop_requested():
            self.stop("EMERGENCY_STOP")
            return True
        return super().done

    def _geometry_proof(self, session: Any, live_card: Any) -> Any:
        if self._phase4_lease.active and not self._phase4_lease.validate_active():
            self.invalidate("PHASE4_QTE_LEASE_INVALIDATED")
            self._release("LEASE_INVALIDATED")
            return None
        if not self._phase4_lease.active:
            # Do not consume the one-shot lease merely because resources are
            # ready. The exact current card must already be actionable; the
            # existing executor performs its own independent final preflight
            # again after foreground acquisition and before the click.
            if not bool(
                live_card is not None
                and getattr(live_card, "interactable", None) is True
                and getattr(live_card, "button_address", None) is not None
                and getattr(live_card, "has_used_this_match", None) is not True
                and getattr(live_card, "has_used_this_turn", None) is not True
                and getattr(live_card, "action_pending", None) is not True
                and getattr(live_card, "is_placeholder", None) is not True
            ):
                return None
            if self._require_external_foreground_before_acquire:
                foreground = self._phase4_lease.backend.foreground_window()
                if foreground in (None, self._phase4_game_hwnd):
                    return None
            self.lease_acquire_result = self._phase4_lease.acquire(
                preflight=lambda: bool(
                    not self._phase4_stop_requested()
                    and session is not None
                    and live_card is not None
                    and getattr(live_card, "interactable", None) is True
                )
            )
            if not self.lease_acquire_result.acquired:
                self.invalidate(
                    f"PHASE4_QTE_LEASE_{self.lease_acquire_result.status.value}"
                )
                return None
            # Acquisition itself spans several frames. Force the existing
            # executor to receive a new read-only observation before card input.
            return None
        return super()._geometry_proof(session, live_card)

    def _drive(self, qte: Any, *, inactive_qte_proven: bool) -> None:
        if self._phase4_lease.active and not self._phase4_lease.validate_active():
            self.invalidate("PHASE4_QTE_LEASE_INVALIDATED")
            self._release("LEASE_INVALIDATED")
            return
        try:
            super()._drive(qte, inactive_qte_proven=inactive_qte_proven)
            executor = self._executor
            if (
                self._phase4_lease.active
                and self.mouse_release_result is None
                and executor is not None
                and executor.state is PetSkillActionState.DIRECTIONS
            ):
                self.mouse_release_result = (
                    self._phase4_lease.release_mouse_for_keyboard_phase(
                        "CURRENT_QTE_BOUND"
                    )
                )
                if not self.mouse_release_result.released:
                    self.invalidate("PHASE4_QTE_MOUSE_RELEASE_FAILED")
                    self._release("MOUSE_RELEASE_FAILED")
        finally:
            if super().done:
                self._release("FULL_QTE_TERMINAL")

    def stop(self, reason: str) -> None:
        try:
            super().stop(reason)
        finally:
            self._release(reason)

    def _release(self, reason: str) -> None:
        if self._phase4_lease.active:
            self.lease_release_result = self._phase4_lease.release(reason)


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--stage", choices=("B1", "B2", "B3"), required=True)
    parser.add_argument(
        "--prearmed",
        action="store_true",
        help="required explicit authority for this one bounded live stage",
    )
    parser.add_argument("--artifacts", type=Path)
    parser.add_argument("--interval", type=float, default=0.025)
    parser.add_argument("--timeout", type=float, default=900.0)
    parser.add_argument("--direction-ack-timeout", type=float, default=1.25)
    parser.add_argument("--qte-generation-timeout", type=float, default=3.0)
    parser.add_argument("--result-timeout", type=float, default=15.0)
    parser.add_argument("--maximum-lease-duration", type=float, default=20.0)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument(
        "--audition-mode",
        choices=[value.value for value in AuditionMode],
        default=AuditionMode.V3_TWO_DIRECTION.value,
    )
    return parser


def _validate_args(args: argparse.Namespace) -> None:
    if not args.prearmed:
        raise ValueError("--prearmed is required for one explicit live stage")
    if not 0.02 <= args.interval <= 0.20:
        raise ValueError("--interval must be between 0.02 and 0.20 seconds")
    if not 10 <= args.timeout <= 1800:
        raise ValueError("--timeout must be between 10 and 1800 seconds")
    if not 3 <= args.maximum_lease_duration <= 30:
        raise ValueError("--maximum-lease-duration must be between 3 and 30 seconds")


def _default_artifacts(stage: str) -> Path:
    stamp = datetime.now().strftime("%Y%m%d_%H%M%S")
    return PROJECT_ROOT / "logs" / "phase4a2_r1" / f"{stage.lower()}_{stamp}"


def _full_action_accepted(
    hook: Any,
    *,
    game_hwnd: int,
    require_focus_handoff: bool,
) -> bool:
    """Accept the old full Pet Skill action plus the Phase-4 lease evidence."""

    accepted = bool(
        hook.completed_successfully
        and hook.lease_acquire_result is not None
        and hook.lease_acquire_result.acquired
        and hook.mouse_release_result is not None
        and hook.mouse_release_result.released
        and hook.lease_release_result is not None
        and hook.lease_release_result.released
    )
    if require_focus_handoff:
        accepted = bool(
            accepted
            and hook.lease_acquire_result.foreground_before
            not in (None, game_hwnd)
            and hook.mouse_release_result.cursor_restored is True
            and hook.lease_release_result.cursor_restored is True
        )
    return accepted


def run(args: argparse.Namespace) -> int:
    _validate_args(args)
    stage = args.stage.upper()
    artifacts = (args.artifacts or _default_artifacts(stage)).resolve()
    log = ArtifactLog(artifacts)
    log.summary = {
        "phase": "4A.2-R1",
        "stage": stage,
        "status": "RUNNING",
        "productionIntegration": False,
        "inputCounts": {"cardClicks": 0, "directions": 0, "space": 0},
        "artifacts": str(artifacts),
        "sourceCommit": _git_head(),
    }
    print(f"Phase 4A.2-R1 {stage} artifacts: {artifacts}", flush=True)
    stop = StopController()
    stop.start()
    pin_session: PinnedWindowSession | None = None
    hook: Any | None = None
    previous_interrupt = signal.getsignal(signal.SIGINT)

    def operator_abort(_signum: int, _frame: Any) -> None:
        stop.stop()
        if hook is not None:
            hook.stop("OPERATOR_ABORT")
        raise KeyboardInterrupt

    signal.signal(signal.SIGINT, operator_abort)
    try:
        with AutomationControllerLease(current_app_paths().controller_lock):
            with attach_target() as target:
                input_backend = NativeWin32Backend()
                foreground_backend = NativeForegroundLeaseBackend(input_backend)
                qte_backend = NativeQteLeaseBackend(foreground_backend)
                exact = _exact_binding(target, input_backend, foreground_backend)
                pin_session = PinnedWindowSession(foreground_backend, exact)
                pin_result = pin_session.pin()
                if not pin_result.pinned:
                    raise RuntimeError(pin_result.reason)
                provider = MemoryBoardStateProvider(
                    target,
                    MemoryProviderConfig(
                        max_region_mib=args.max_region_mib,
                        chunk_mib=args.chunk_mib,
                        full_rescan_interval=8,
                        require_lobby_start=True,
                    ),
                )
                audition_mode = AuditionMode(args.audition_mode)
                lease: BoundedForegroundQteLease | None = None
                if stage == "B1":
                    hook = Phase4QteObservationHook(
                        stop_requested=stop.requested,
                        audition_mode=audition_mode,
                    )
                else:
                    lease = BoundedForegroundQteLease(
                        qte_backend,
                        stop_requested=stop.requested,
                        event_sink=log.sink,
                        required_idle_seconds=0.10,
                        idle_timeout_seconds=0.10,
                        focus_settle_seconds=0.20,
                        focus_request_attempts=3,
                        maximum_duration_seconds=args.maximum_lease_duration,
                    )
                    lease.arm(exact, f"4A2:{stage}:existing-full-qte-action")
                    hook = Phase4FullQteLeaseHook(
                        backend=qte_backend,
                        binding=exact.window,
                        lease=lease,
                        stop_requested=stop.requested,
                        audition_mode=audition_mode,
                        direction_ack_timeout_seconds=args.direction_ack_timeout,
                        qte_generation_timeout_seconds=args.qte_generation_timeout,
                        result_timeout_seconds=args.result_timeout,
                        require_external_foreground_before_acquire=stage == "B3",
                    )
                observer_args = argparse.Namespace(
                    watch=True,
                    log=artifacts / "qte_events.jsonl",
                    interval=args.interval,
                    timeout=args.timeout,
                    qtes=0,
                    max_region_mib=args.max_region_mib,
                    chunk_mib=args.chunk_mib,
                    allow_combat_start=False,
                    audition_mode=audition_mode.value,
                )
                log.summary.update(
                    pid=target.pid,
                    hwnd=exact.window.hwnd,
                    title=exact.window.title,
                    clientGeometry=exact.geometry,
                    gameAssemblyPath=str(target.game_assembly.path),
                    gameAssemblySha256=_sha256(target.game_assembly.path),
                    pinResult=pin_result,
                    auditionMode=audition_mode.value,
                )
                observer_result = run_observer(
                    observer_args,
                    runtime_hook=hook,
                    shared_target=target,
                    shared_provider=provider,
                )
                if stage == "B1":
                    accepted = hook.observation is not None and observer_result == 0
                    log.summary["observation"] = hook.observation
                else:
                    result = hook.result
                    accepted = _full_action_accepted(
                        hook,
                        game_hwnd=exact.window.hwnd,
                        require_focus_handoff=stage == "B3",
                    )
                    log.summary["actionResult"] = result
                    log.summary["leaseAcquire"] = hook.lease_acquire_result
                    log.summary["mouseRelease"] = hook.mouse_release_result
                    log.summary["leaseRelease"] = hook.lease_release_result
                    if result is not None:
                        log.summary["inputCounts"]["cardClicks"] = result.card_clicks
                        log.summary["inputCounts"]["space"] = result.space_presses
                        log.summary["inputCounts"]["directions"] = (
                            result.telemetry.direction_summary.directions_sent
                            if result.telemetry.direction_summary is not None
                            else 0
                        )
                log.summary["observerResult"] = observer_result
                log.summary["status"] = "ACCEPTED" if accepted else "NOT_ACCEPTED"
                log.event(
                    "phase4_qte_stage_finished",
                    stage=stage,
                    accepted=accepted,
                    summary=jsonable(hook.summary),
                )
                log.save()
                print(
                    f"{stage} {'ACCEPTED' if accepted else 'NOT ACCEPTED'}. "
                    "No automatic retry.",
                    flush=True,
                )
                return 0 if accepted else 3
    except KeyboardInterrupt:
        log.summary.update(status="STOPPED", stopReason="OPERATOR_ABORT")
        return 130
    except Exception as exc:
        log.summary.update(
            status="FAILED",
            stopReason=f"{type(exc).__name__}: {exc}",
        )
        log.event(
            "phase4_qte_probe_failed",
            errorType=type(exc).__name__,
            error=str(exc),
        )
        print(f"ERROR: {type(exc).__name__}: {exc}", file=sys.stderr, flush=True)
        return 1
    finally:
        if hook is not None:
            try:
                hook.stop("HARNESS_EXIT")
            except (OSError, ValueError) as exc:
                # Observer-owned JSONL is already closed here. Cleanup of the
                # input lease and topmost window must still continue.
                log.event(
                    "phase4_qte_cleanup_log_ignored",
                    errorType=type(exc).__name__,
                    error=str(exc),
                )
        if pin_session is not None:
            try:
                log.summary["unpinResult"] = pin_session.close()
            except Exception as exc:
                log.summary["unpinResult"] = {
                    "status": "FAILED",
                    "reason": f"{type(exc).__name__}: {exc}",
                }
        stop.stop()
        signal.signal(signal.SIGINT, previous_interrupt)
        log.close()


def main() -> int:
    return run(build_parser().parse_args())


if __name__ == "__main__":
    raise SystemExit(main())
