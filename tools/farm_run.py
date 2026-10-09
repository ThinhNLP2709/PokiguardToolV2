#!/usr/bin/env python3
"""Phase 2D.4/2D.5/2D.6 bounded farming with terminal-result fidelity.

Phase 2D.6 adds operator graceful stop (F6), durable history checkpoints,
explicit resume, and a longer bounded soak.  All runs remain finite: there
is no infinite farming mode.
"""

from __future__ import annotations

import argparse
from argparse import Namespace
from dataclasses import asdict
from pathlib import Path
import json
import os
import sys
import time
import traceback
from typing import Any, Callable, Sequence


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.app_paths import current_app_paths  # noqa: E402
from pokiguard_v2.board_diagnostics import analyze_game_state  # noqa: E402
from pokiguard_v2.boss_entry import BossLobbyState, FarmTarget  # noqa: E402
from pokiguard_v2.combat_lifecycle import CombatLifecycleState  # noqa: E402
from pokiguard_v2.chinh_phuc_map import (  # noqa: E402
    discover_chinh_phuc_island_target,
    discover_chinh_phuc_map_target,
)
from pokiguard_v2.boss_entry_ui import (  # noqa: E402
    locate_detached_chinh_phuc_room_shell_exit,
)
from pokiguard_v2.hub_navigation import (  # noqa: E402
    HubChinhPhucControl,
    locate_hub_chinh_phuc_control,
    read_hub_chinh_phuc_control,
    same_clean_hub_chinh_phuc_control,
)
from pokiguard_v2.controller_lease import AutomationControllerLease  # noqa: E402
from pokiguard_v2.farm_cycle import OpeningEvidence  # noqa: E402
from pokiguard_v2.farm_checkpoint import (  # noqa: E402
    CheckpointError,
    load_checkpoint,
    validate_for_resume,
    write_checkpoint,
)
from pokiguard_v2.farm_control import (  # noqa: E402
    FarmControlState,
    GracefulStopController,
)
from pokiguard_v2.farm_run import (  # noqa: E402
    ActiveCombatHandoffEvidence,
    FarmInputDomain,
    FarmRun,
    FarmRunArtifactWriter,
    FarmRunEntryCapability,
    FarmRunGameplayCapability,
    FarmRunLobbyCardCapability,
    FarmRunLimits,
    FarmRunState,
    FarmRunStopReason,
    MatchResult,
)
from pokiguard_v2.opening_snapshot import (  # noqa: E402
    is_ack_attested_current_board_source,
)
from pokiguard_v2.state import (  # noqa: E402
    CombatSessionKey,
    ResultConsistency,
    TerminalCombatSnapshot,
    TerminalResult,
    TerminalResultConfidence,
)
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
)
from pokiguard_v2.native_card_ui import NativeCardUiReader  # noqa: E402
from pokiguard_v2.input_delivery import (  # noqa: E402
    ExactWindowBinding,
    InputDeliveryConfig,
    InputDeliveryDomain,
    InputDeliveryMode,
)
from pokiguard_v2.foreground_lease_transport import (  # noqa: E402
    LeaseStatus,
    NativeForegroundLeaseBackend,
)
from pokiguard_v2.pinned_board_input import (  # noqa: E402
    PinnedForegroundMouseSession,
)
from pokiguard_v2.postmatch_ui import (  # noqa: E402
    locate_result_confirm,
    prove_stable_result_confirm,
)
from pokiguard_v2.recovery_ui import locate_confirm_leave  # noqa: E402
from pokiguard_v2.technical_recovery import (  # noqa: E402
    RecoveredOpeningEvidence,
    TechnicalRecoveryCoordinator,
    TechnicalRecoveryDispatcher,
    TechnicalRecoveryResult,
    TechnicalRecoveryState,
)
from pokiguard_v2.win32_input import (  # noqa: E402
    BoardInputMode,
    ClickStatus,
    CoordinateSafetyError,
    FarmControlHotkeyEdges,
    ForegroundClickExecutor,
    HotkeyEdges,
    NativeWin32Backend,
    find_window_for_pid,
)
from pokiguard_v2.win32_screenshot import capture_client_rgb, write_png_rgb  # noqa: E402
from tools import basic_auto_bot, boss_entry, technical_recovery  # noqa: E402
from tools.farm_cycle import (  # noqa: E402
    LobbyWaitResult,
    _combat_args,
    _entry_args,
    _is_detached_chinh_phuc_room_candidate,
    _last_event,
    _read_lobby_runtime_with_provider_fallback,
    _read_jsonl,
    _validate_combat_summary,
    _wait_boss_lobby,
)
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.replay_sequence_desync import replay  # noqa: E402
from tools.runtime_common import attach_target, utc_timestamp  # noqa: E402
from tools.sequence_desync_runtime import RuntimeSequenceMonitor  # noqa: E402


from pokiguard_v2.pet_configuration import (
    add_pet_arguments,
    gameplay_config_from_args,
    requires_attack_card_preparation,
)
from pokiguard_v2.basic_policy import PlayStyle
from pokiguard_v2.gameplay_profile import GameMode


_PHASE4B2_INPUT_DELIVERY_ENV = "POKIGUARD_PHASE4B2_INPUT_DELIVERY_MODE"


def _source_selected_input_delivery_config(
    environment: dict[str, str] | None = None,
    *,
    selected_mode: str | InputDeliveryMode | None = None,
) -> InputDeliveryConfig:
    """Resolve an explicit UI/CLI selection or the legacy 4B.2 selector.

    The explicit run configuration wins over the source-only environment
    selector. Both retain foreground as the shipping default. Invalid values
    fail before FarmRunner owns any input capability.
    """

    source = os.environ if environment is None else environment
    raw = (
        selected_mode.value
        if isinstance(selected_mode, InputDeliveryMode)
        else selected_mode
    )
    if raw is None:
        raw = source.get(
            _PHASE4B2_INPUT_DELIVERY_ENV,
            InputDeliveryMode.FOREGROUND.value,
        )
    try:
        mode = InputDeliveryMode(raw)
    except ValueError as exc:
        raise ValueError(
            f"invalid {_PHASE4B2_INPUT_DELIVERY_ENV}={raw!r}"
        ) from exc
    return InputDeliveryConfig(mode)


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
    mode.add_argument(
        "--stage-d5-a-results",
        action="store_true",
        help="offline Phase 2D.5 terminal/accounting regression suite; inputs=0",
    )
    mode.add_argument(
        "--stage-d5-b1-terminal",
        action="store_true",
        help="exactly one normal match proving memory-backed terminal result",
    )
    mode.add_argument(
        "--stage-d5-b2-soak",
        action="store_true",
        help="extended finite Phase 2D.5 soak (recommended 10/2/14)",
    )
    mode.add_argument(
        "--stage-d6-a-control",
        action="store_true",
        help="offline Phase 2D.6 graceful-stop/checkpoint suite; inputs=0",
    )
    mode.add_argument(
        "--stage-d6-b1-graceful",
        action="store_true",
        help="live graceful stop via F6 during first combat (never F9)",
    )
    mode.add_argument(
        "--stage-d6-b2-resume",
        action="store_true",
        help="checkpoint/resume continuity across two bounded invocations",
    )
    mode.add_argument(
        "--stage-d6-b3-soak",
        action="store_true",
        help="long bounded soak (recommended 25/3/32); still finite",
    )
    mode.add_argument(
        "--stage-e2-ui",
        action="store_true",
        help=argparse.SUPPRESS,
    )
    target = parser.add_mutually_exclusive_group()
    target.add_argument("--boss-id", help="exact runtime boss/enemy pet ID")
    target.add_argument("--boss-name", help="exact NFC/casefold boss name")
    parser.add_argument("--target-matches", type=int, default=3)
    parser.add_argument(
        "--max-technical-recoveries",
        type=int,
        default=1,
        help=argparse.SUPPRESS,  # accepted only for old scripts/checkpoints; ignored
    )
    parser.add_argument("--max-match-attempts", type=int, default=5)
    parser.add_argument(
        "--stop-if-room-ejected",
        action="store_true",
        help=(
            "fail closed when the selected Chinh Phuc room is lost; never "
            "select a pet from the world boss map"
        ),
    )
    parser.add_argument(
        "--play-style",
        choices=tuple(value.value for value in PlayStyle),
        default=PlayStyle.SIMPLE.value,
    )
    add_pet_arguments(parser)
    parser.add_argument(
        "--board-input-mode",
        choices=tuple(value.value for value in BoardInputMode),
        default=BoardInputMode.TWO_CLICK.value,
        help="adjacent board swap gesture; UI/card controls always use clicks",
    )
    parser.add_argument(
        "--input-delivery-mode",
        choices=tuple(value.value for value in InputDeliveryMode),
        default=None,
        help=argparse.SUPPRESS,
    )
    parser.add_argument("--post-recovery-test-consuming-actions", type=int, default=1)
    resume_group = parser.add_mutually_exclusive_group()
    resume_group.add_argument(
        "--new-run",
        action="store_true",
        help="explicitly start a fresh run; never continues a checkpoint",
    )
    resume_group.add_argument(
        "--resume",
        type=Path,
        help="explicit path to a checkpoint.json to continue; never automatic",
    )
    parser.add_argument("--sequence-fixture", type=Path)
    parser.add_argument("--reset-evidence", type=Path)
    parser.add_argument(
        "--cast-when-boss-hp-below",
        type=int,
        default=30_000,
        help=(
            "Step 3 finisher: no Sword on the board and boss current HP at or below "
            "this value CASTs as soon as one Attack card is affordable. 0 disables it."
        ),
    )
    parser.add_argument("--cast-mana-stockpile", type=int, default=480)
    parser.add_argument("--rage-target", type=int, default=100)
    parser.add_argument("--artifacts", type=Path)
    parser.add_argument("--interval", type=float, default=0.12)
    parser.add_argument("--lobby-timeout", type=float, default=180.0)
    parser.add_argument("--entry-timeout", type=float, default=45.0)
    parser.add_argument("--opening-timeout", type=float, default=35.0)
    parser.add_argument(
        "--postmatch-ui-timeout",
        type=float,
        default=30.0,
        help=(
            "bounded wait for the stable Thang/Thua result modal after the "
            "authoritative combat lifecycle has ended"
        ),
    )
    parser.add_argument("--return-lobby-timeout", type=float, default=90.0)
    parser.add_argument("--combat-timeout", type=float, default=1800.0)
    parser.add_argument("--max-total-input-actions", type=int, default=100)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--ack-heap-region-mib", type=int, default=16)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument("--no-beep", action="store_true")
    return parser


def _validate_args(args: Namespace) -> FarmRunLimits:
    gameplay_config_from_args(args).require_farm_policy()
    # Hard finite bounds.  Phase 2D.6 deliberately ships no infinite mode:
    # FarmRunLimits itself rejects target<=0, so "0 means unlimited" cannot
    # be expressed anywhere in this CLI.
    limits = FarmRunLimits(
        args.target_matches,
        args.max_technical_recoveries,
        args.max_match_attempts,
    )
    offline = (
        args.stage_a_replay
        or args.stage_d5_a_results
        or args.stage_d6_a_control
    )
    if not offline and not (args.boss_id or args.boss_name):
        raise ValueError("live farm run requires --boss-id or --boss-name")
    if args.stage_b1_recovery_resume and args.post_recovery_test_consuming_actions != 1:
        raise ValueError("Stage B1 hard-requires exactly one consuming action")
    if not 0.08 <= args.interval <= 0.50:
        raise ValueError("--interval must be between 0.08 and 0.50")
    for name in ("lobby_timeout", "entry_timeout", "opening_timeout"):
        if not 5 <= float(getattr(args, name)) <= 600:
            raise ValueError(f"--{name.replace('_', '-')} must be between 5 and 600")
    if not 3 <= float(args.postmatch_ui_timeout) <= 60:
        raise ValueError("--postmatch-ui-timeout must be between 3 and 60")
    for name in ("return_lobby_timeout", "combat_timeout"):
        if not 5 <= float(getattr(args, name)) <= 3600:
            raise ValueError(f"--{name.replace('_', '-')} must be between 5 and 3600")
    if not 1 <= args.max_total_input_actions <= 1000:
        raise ValueError("--max-total-input-actions must be between 1 and 1000")
    if args.cast_when_boss_hp_below < 0:
        raise ValueError("--cast-when-boss-hp-below must be >= 0")
    if args.cast_mana_stockpile < 0:
        raise ValueError("--cast-mana-stockpile must be >= 0")
    if args.rage_target < 0:
        raise ValueError("--rage-target must be >= 0")
    if not 1 <= args.max_region_mib <= 32 or not 1 <= args.chunk_mib <= 16:
        raise ValueError("scan size arguments are outside safe bounds")
    if not args.max_region_mib <= args.ack_heap_region_mib <= 32:
        raise ValueError("--ack-heap-region-mib must cover --max-region-mib and be <= 32")
    if args.stage_d5_b1_terminal:
        limits = FarmRunLimits(1, 0, 1)
    if args.stage_d5_b2_soak and (
        limits.target_completed_matches <= 1
        or limits.max_match_attempts < limits.target_completed_matches
    ):
        raise ValueError("Phase 2D.5 B2 requires finite multi-match bounds")
    d6_live = (
        args.stage_d6_b1_graceful
        or args.stage_d6_b2_resume
        or args.stage_d6_b3_soak
    )
    controlled_live = d6_live or args.stage_e2_ui
    if args.stage_d6_b1_graceful:
        # One entry, one match, stopped by the operator's F6 press.
        if limits.target_completed_matches < 2:
            raise ValueError(
                "Stage D6 B1 needs target>=2 so a graceful stop is provable "
                "(the run must stop before a target-driven completion)"
            )
    if args.stage_d6_b2_resume and limits.target_completed_matches < 2:
        raise ValueError("Stage D6 B2 requires target>=2 to split across a resume")
    if args.stage_d6_b3_soak and (
        limits.target_completed_matches < 5
        or limits.max_match_attempts < limits.target_completed_matches
    ):
        raise ValueError("Stage D6 B3 requires a finite multi-match soak (>=5)")
    if args.resume is not None:
        if not controlled_live:
            raise ValueError(
                "--resume is only valid for Phase 2D.6 or Phase 2E.2 "
                "controlled live stages"
            )
        if not args.resume.is_file():
            raise FileNotFoundError(f"checkpoint not found: {args.resume}")
    if controlled_live and not (args.new_run or args.resume):
        raise ValueError(
            "controlled live stages require an explicit --new-run or "
            "--resume <checkpoint.json>; auto-resume is never performed"
        )
    if not offline:
        if args.reset_evidence is None or not args.reset_evidence.is_file():
            raise FileNotFoundError(
                "live B5/D6 farming requires an existing --reset-evidence file"
            )
    return limits


def _recovery_args(args: Namespace, artifacts: Path, *, test_only: bool) -> Namespace:
    return Namespace(
        stage_a_replay=False,
        recovery_ui_test=test_only,
        watch_production=not test_only,
        boss_id=args.boss_id,
        boss_name=args.boss_name,
        game_mode=getattr(args, "game_mode", GameMode.SOLO.value),
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
        # Phase 2D.3 is intentionally a one-recovery state machine per
        # invocation.  The outer FarmRun owns the bounded soak-wide counter
        # (for D5 B2, at most two) and creates a fresh coordinator for each
        # naturally occurring technical failure.
        max_technical_recoveries=1,
        max_region_mib=args.max_region_mib,
        ack_heap_region_mib=args.ack_heap_region_mib,
        chunk_mib=args.chunk_mib,
        no_beep=args.no_beep,
        require_current_boss_room=bool(args.stop_if_room_ejected),
    )


class _ControllerMemorySampler:
    """Bounded working-set telemetry for THIS controller process.

    Read-only self-observation via GetProcessMemoryInfo on our own handle.
    The target game process is never touched by this sampler.
    """

    def __init__(self) -> None:
        self.samples: list[int] = []
        self.start_bytes: int | None = None
        self.peak_bytes: int | None = None
        self.end_bytes: int | None = None
        self._max_samples = 512
        self._available = os.name == "nt"

    def _working_set_bytes(self) -> int | None:
        if not self._available:
            return None
        try:
            import ctypes
            from ctypes import wintypes

            class _PROCESS_MEMORY_COUNTERS(ctypes.Structure):
                _fields_ = [
                    ("cb", wintypes.DWORD),
                    ("PageFaultCount", wintypes.DWORD),
                    ("PeakWorkingSetSize", ctypes.c_size_t),
                    ("WorkingSetSize", ctypes.c_size_t),
                    ("QuotaPeakPagedPoolUsage", ctypes.c_size_t),
                    ("QuotaPagedPoolUsage", ctypes.c_size_t),
                    ("QuotaPeakNonPagedPoolUsage", ctypes.c_size_t),
                    ("QuotaNonPagedPoolUsage", ctypes.c_size_t),
                    ("PagefileUsage", ctypes.c_size_t),
                    ("PeakPagefileUsage", ctypes.c_size_t),
                ]

            counters = _PROCESS_MEMORY_COUNTERS()
            counters.cb = ctypes.sizeof(_PROCESS_MEMORY_COUNTERS)
            # Declare the 64-bit ABI explicitly. Without ``restype=HANDLE``
            # ctypes truncates handles to C ``int`` by default; the pseudo
            # current-process handle then reaches psapi with the wrong value
            # and GetProcessMemoryInfo simply returns FALSE. K32* is exported
            # by kernel32 on the supported x64 Windows clients.
            kernel32 = ctypes.WinDLL("kernel32", use_last_error=True)
            kernel32.GetCurrentProcess.argtypes = []
            kernel32.GetCurrentProcess.restype = wintypes.HANDLE
            kernel32.K32GetProcessMemoryInfo.argtypes = [
                wintypes.HANDLE,
                ctypes.POINTER(_PROCESS_MEMORY_COUNTERS),
                wintypes.DWORD,
            ]
            kernel32.K32GetProcessMemoryInfo.restype = wintypes.BOOL
            handle = kernel32.GetCurrentProcess()
            ok = kernel32.K32GetProcessMemoryInfo(
                handle, ctypes.byref(counters), counters.cb
            )
            if not ok:
                return None
            return int(counters.WorkingSetSize)
        except Exception:  # noqa: BLE001 - telemetry must never break the run
            self._available = False
            return None

    def sample(self) -> int | None:
        value = self._working_set_bytes()
        if value is None:
            return None
        if self.start_bytes is None:
            self.start_bytes = value
        self.end_bytes = value
        self.peak_bytes = value if self.peak_bytes is None else max(self.peak_bytes, value)
        self.samples.append(value)
        if len(self.samples) > self._max_samples:
            del self.samples[: len(self.samples) - self._max_samples]
        return value

    def report(self) -> dict[str, Any]:
        """Honest bounded-soak wording; never claims a leak-free proof."""
        if self.start_bytes is None or self.end_bytes is None:
            return {"available": False}
        growth = self.end_bytes - self.start_bytes
        return {
            "available": True,
            "startWorkingSetBytes": self.start_bytes,
            "peakWorkingSetBytes": self.peak_bytes,
            "endWorkingSetBytes": self.end_bytes,
            "netGrowthBytes": growth,
            "sampleCount": len(self.samples),
            "retainedSampleCap": self._max_samples,
            "interpretation": (
                "no observed unbounded growth during this bounded soak"
            ),
        }


def _checkpoint_path(directory: Path) -> Path:
    return directory / "checkpoint.json"


def _artifact_size_bytes(directory: Path) -> int:
    """Best-effort bounded-run artifact size; files may still be growing."""

    total = 0
    try:
        for path in directory.rglob("*"):
            if path.is_file():
                total += path.stat().st_size
    except OSError:
        return total
    return total


def _print_farm_status(run: FarmRun, *, lifecycle: str) -> None:
    """Concise event-based status without adding a per-poll console stream."""

    snapshot = run.snapshot()
    control_state = (
        snapshot.control_state.value
        if snapshot.control_state is not None
        else "RUNNING"
    )
    print(
        "FarmRun: "
        f"{snapshot.farm_run_id} | completed={snapshot.completed_matches}/"
        f"{snapshot.limits.target_completed_matches} | wins={snapshot.wins} "
        f"losses={snapshot.losses} unknown={snapshot.unknown_results} | "
        f"attempts={snapshot.match_attempts}/"
        f"{snapshot.limits.max_match_attempts} | recoveries="
        f"{snapshot.technical_recoveries}/"
        f"unbounded | lifecycle={lifecycle} | "
        f"match={snapshot.current_match_id or '-'} | stopMode={control_state}",
        flush=True,
    )


def _persist_checkpoint(
    run: FarmRun,
    writer: FarmRunArtifactWriter,
    *,
    finalized_status: str | None = None,
) -> bool:
    """Durable HISTORY only.  Never executable gameplay state."""
    try:
        payload = run.checkpoint_payload(finalized_status=finalized_status)
        write_checkpoint(_checkpoint_path(writer.directory), payload)
        writer.event(
            "checkpoint_written",
            checkpointSeq=payload.checkpoint_seq,
            completedMatches=payload.completed_matches,
            finalizedStatus=finalized_status,
            executableGameplayStatePersisted=False,
        )
        return True
    except Exception as exc:  # noqa: BLE001 - convert persistence faults to safe-stop
        writer.event("checkpoint_write_failed", error=str(exc))
        if not run.stopped:
            run.safe_stop(
                FarmRunStopReason.CHECKPOINT_INVALID,
                detail=f"durable checkpoint write failed: {exc}",
            )
        return False


def _resume_decision(
    args: Namespace,
    limits: FarmRunLimits,
    target: FarmTarget,
    input_delivery_config: InputDeliveryConfig,
) -> Any:
    """Explicit --resume only.  Auto-resume is never performed."""
    payload = load_checkpoint(args.resume)
    decision = validate_for_resume(
        payload,
        target_boss_id=str(target.boss_id or ""),
        target_boss_name=str(target.boss_name or ""),
        target_completed_matches=limits.target_completed_matches,
        max_technical_recoveries=limits.max_technical_recoveries,
        max_match_attempts=limits.max_match_attempts,
        gameplay_config=gameplay_config_from_args(args),
        input_delivery_mode=input_delivery_config.mode,
    )
    return payload, decision


def _write_model_events(writer: FarmRunArtifactWriter, run: FarmRun) -> None:
    for event in run.snapshot().events:
        writer.event(
            "farm_state_event",
            farmEventIndex=event.index,
            farmEvent=event.event,
            farmState=event.state,
            detail=event.detail,
        )


def _entry_preflight_runtime_changed_before_start(
    result: dict[str, Any] | None,
) -> bool:
    """Accept only a zero-input room/navigation change before Start.

    The room can disappear between the first button proof and the pinned
    post-focus proof.  Depending on which Unity objects are torn down first,
    BossEntry reports either a runtime-owner change or a visual/native Button
    change.  Both are safe navigation re-route signals only while every entry
    and gameplay input counter is still zero.
    """

    return bool(
        result is not None
        and result.get("stopReason")
        in {
            "ENTRY_PREFLIGHT_RUNTIME_CHANGED",
            "ENTRY_PREFLIGHT_BUTTON_CHANGED",
        }
        and int(result.get("entryClicks") or 0) == 0
        and int(result.get("entryRetryClicks") or 0) == 0
        and int(result.get("gameplayInputs") or 0) == 0
    )


def _entry_postclick_room_ejection_probe_required(
    result: dict[str, Any] | None,
) -> bool:
    """Defer one post-Start timeout only long enough to prove room ejection.

    This does not authorize navigation.  The caller must still obtain two
    stable owner-free map/island frames and pass the existing exact-pet
    re-entry checks before any additional input is possible.
    """

    return bool(
        result is not None
        and result.get("status") == "STOPPED"
        and result.get("stopReason") == "ENTRY_TIMEOUT_NEW_SESSION"
        and result.get("entryRetryRejectedReason")
        == "ENTRY_RETRY_RUNTIME_CHANGED"
        and int(result.get("entryClicks") or 0) == 1
        and int(result.get("entryRetryClicks") or 0) == 0
        and int(result.get("gameplayInputs") or 0) == 0
    )


def _active_combat_handoff_evidence(
    result: dict[str, Any],
) -> ActiveCombatHandoffEvidence | None:
    """Parse the exact untouched-current-board proof emitted by BossEntry."""

    if (
        result.get("status") != "RECOVERY_REQUIRED"
        or result.get("stopReason") != "ENTRY_OPENING_TIMEOUT_ACTIVE_COMBAT"
    ):
        return None
    raw = result.get("activeCombatTimeoutEvidence") or {}
    raw_session = raw.get("session") or {}
    if raw.get("firstLocalTurn") is not False:
        return None
    try:
        session = CombatSessionKey(
            int(raw_session["lifecycle_epoch"]),
            int(raw_session["board_instance"]),
            str(raw_session["match_id"]),
        )
        evidence = ActiveCombatHandoffEvidence(
            session=session,
            match_id=str(raw["matchId"]),
            board_hash=str(raw["boardHash"]),
            complete_cells=int(raw["completeCells"]),
            unique_coordinates=int(raw["uniqueCoordinates"]),
            source=str(raw["boardSource"]),
            current_board_attested=is_ack_attested_current_board_source(
                raw.get("boardSource")
            ),
            turn_number=int(raw["turn"]),
            first_local_turn=raw.get("firstLocalTurn") is True,
            local_move_sequence=(
                None
                if raw.get("localMoveSequence") is None
                else int(raw["localMoveSequence"])
            ),
            srv_seq=int(raw["srvSeq"]),
            stable_confirmations=int(raw["stableConfirmations"]),
            production_ready=raw.get("productionReady") is True,
            gem_types_valid=raw.get("gemTypesValid") is True,
            multipliers_valid=raw.get("multipliersValid") is True,
            entry_clicks=int(result.get("entryClicks") or 0),
            gameplay_inputs=int(result.get("gameplayInputs") or 0),
        )
    except (KeyError, TypeError, ValueError):
        return None
    return evidence if evidence.valid() else None


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
    control_hotkeys: Any | None = None,
    test_only_recovery: bool = False,
    pinned_input_session: PinnedForegroundMouseSession | None = None,
) -> tuple[
    OpeningEvidence | ActiveCombatHandoffEvidence | None,
    dict[str, Any] | None,
]:
    if not run.target_resolved(exact=True):
        return None, None
    entry_directory = directory / "entry"
    if entry_directory.exists():
        # A zero-input atomic preflight rejection can legitimately return the
        # same not-yet-counted attempt to the navigation router.  Preserve the
        # first proof and give each later probe an independent artifact folder.
        retry_index = 1
        while (directory / f"entry_preflight_retry_{retry_index:02d}").exists():
            retry_index += 1
        entry_directory = directory / f"entry_preflight_retry_{retry_index:02d}"
    runtime = boss_entry.SharedEntryRuntime(
        process,
        provider,
        monitor,
        binding,
        executor,
        backend,
        FarmRunEntryCapability(run, control_hotkeys),
        FarmRunLobbyCardCapability(run, control_hotkeys),
        require_attack_card=requires_attack_card_preparation(
            run.snapshot().gameplay_config
        ),
        coop_mode=(
            run.snapshot().gameplay_config.game_mode is GameMode.COOP
        ),
        pinned_input_session=pinned_input_session,
        emergency_stop_requested=(
            pinned_input_session.stop_requested
            if pinned_input_session is not None
            else lambda: _control_emergency_requested(control_hotkeys)
        ),
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
        if _entry_preflight_runtime_changed_before_start(result):
            # BossEntry rejected the stale room before reserving/sending Start.
            # The caller owns the bounded lobby/map re-router; do not turn this
            # zero-input navigation race into a terminal farm failure here.
            return None, result
        if _entry_postclick_room_ejection_probe_required(result):
            # Live v1.2.3 run 4abfeb... attempt 240 proved that Unity can
            # discard the room after Start without ever creating a combat
            # session.  The outer farm loop owns the existing bounded map
            # re-entry path and will independently re-prove the visible state.
            return None, result
        if result.get("status") == "RECOVERY_REQUIRED" and result.get(
            "stopReason"
        ) == "ENTRY_OPENING_TIMEOUT_ACTIVE_COMBAT":
            handoff = (
                None
                if test_only_recovery
                else _active_combat_handoff_evidence(result)
            )
            if (
                handoff is not None
                and provider.current_session_key == handoff.session
                and run.accept_session(handoff.session)
                and run.accept_active_combat_handoff(handoff)
            ):
                result.update(
                    status="PASS",
                    stopReason="CURRENT_COMBAT_HANDOFF_READY",
                    activeCombatHandoffAccepted=True,
                    openingMode="CURRENT_ACK_ATTESTED_BOARD",
                )
                return handoff, result
            raw = result.get("activeCombatTimeoutEvidence") or {}
            raw_session = raw.get("session") or {}
            try:
                session = CombatSessionKey(
                    int(raw_session["lifecycle_epoch"]),
                    int(raw_session["board_instance"]),
                    str(raw_session["match_id"]),
                )
            except (KeyError, TypeError, ValueError):
                session = None
            if (
                session is not None
                and provider.current_session_key == session
                and run.accept_session(session)
                and run.technical_failure(
                    "ENTRY_OPENING_TIMEOUT_ACTIVE_COMBAT"
                )
            ):
                return None, result
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


class _ContextualFarmHotkeys:
    """Wraps FarmControlHotkeyEdges so each F6 edge remembers *where* it happened.

    The farm loop can only consume a latched press at its next iteration, which
    for a mid-combat press is after the match has already drained to the lobby.
    Reading the lifecycle at consume time therefore always reports BOSS_LOBBY
    and misrepresents the operator's action.  Capturing it at poll time — the
    moment the key edge is actually observed — keeps the record truthful.
    """

    def __init__(self, edges: Any, run_getter: Any) -> None:
        self._edges = edges
        self._run_getter = run_getter
        self.presses: list[dict[str, Any]] = []
        self.total_f6_edges = 0
        self._f9_pending = False

    def _context(self) -> dict[str, Any]:
        run = self._run_getter()
        session = run.current_session
        if run.state in {FarmRunState.RECOVERY_PENDING, FarmRunState.RECOVERY_ACTIVE}:
            lifecycle = "RECOVERY_ACTIVE"
        elif run.state is FarmRunState.WAIT_POSTMATCH:
            lifecycle = "POSTMATCH"
        elif run.state is FarmRunState.WAIT_BOSS_LOBBY:
            lifecycle = "RETURNING_TO_BOSS_LOBBY"
        elif run.state is FarmRunState.COMBAT_ACTIVE:
            lifecycle = "ACTIVE_COMBAT"
        elif session is None:
            lifecycle = "BOSS_LOBBY"
        else:
            lifecycle = "ENTERING_COMBAT"
        return {
            "at": utc_timestamp(),
            "lifecycle": lifecycle,
            "farmState": run.state.value,
            "matchId": session.match_id if session is not None else None,
            "matchAttempt": run.match_attempts,
            "completedMatches": run.completed_matches,
        }

    def _register_f6(self) -> None:
        self.total_f6_edges += 1
        context = self._context()
        run = self._run_getter()
        context["registeredWithRun"] = run.graceful_stop_request(
            lifecycle=context["lifecycle"],
            match_id=context["matchId"],
        )
        self.presses.append(context)

    def poll(self) -> tuple[bool, bool]:
        f6_edge, f9_edge = self._edges.poll()
        if f6_edge:
            self._register_f6()
        if f9_edge:
            self._f9_pending = True
        return f6_edge, self._f9_pending

    def take(self) -> tuple[int, int]:
        # First route a new edge through this contextual wrapper.  The native
        # take() polls once more before consuming; if an edge lands in that
        # tiny gap, synthesize its context here rather than losing its
        # immediate FarmRun registration.
        self.poll()
        f6_count, f9_count = self._edges.take()
        while len(self.presses) < f6_count:
            self._register_f6()
        self._f9_pending = False
        return f6_count, f9_count

    def take_presses(self) -> list[dict[str, Any]]:
        captured, self.presses = self.presses, []
        return captured

    @property
    def emergency_requested(self) -> bool:
        return bool(getattr(self._edges, "emergency_requested", False))

    def execute_if_authorized(self, operation: Any) -> tuple[bool, Any | None]:
        executor = getattr(self._edges, "execute_if_authorized", None)
        if executor is None:
            return (False, None) if self._f9_pending else (True, operation())
        return executor(operation)


def _control_emergency_requested(control_hotkeys: Any | None) -> bool:
    if control_hotkeys is None:
        return False
    _graceful, emergency = control_hotkeys.poll()
    return bool(emergency or control_hotkeys.emergency_requested)


def _pinned_input_stop_requested(
    hotkeys: Any,
    control_hotkeys: Any | None,
    latch: dict[str, bool],
) -> bool:
    """Latch the entry F9 edge without assuming AutoHotkeyEdges methods.

    FarmRunner's lobby watcher owns ``HotkeyEdges`` (poll-only), while the
    combat controller owns ``AutoHotkeyEdges`` (which also exposes
    emergency_stop_requested()).  The run-scoped pinned session starts before
    Boss Start, so its callback must use the common poll contract here and
    retain a short F9 press for every later lease boundary.
    """

    _confirm, emergency_edge = hotkeys.poll()
    if emergency_edge:
        latch["emergency"] = True
    return bool(
        latch.get("emergency", False)
        or (
            control_hotkeys is not None
            and control_hotkeys.emergency_requested
        )
    )


def _execute_controlled_input(
    control_hotkeys: Any | None,
    operation: Any,
) -> tuple[bool, Any | None]:
    if control_hotkeys is None:
        return True, operation()
    return control_hotkeys.execute_if_authorized(operation)


def _confirm_postmatch(
    *,
    run: FarmRun,
    process: Any,
    provider: MemoryBoardStateProvider,
    binding: Any,
    executor: ForegroundClickExecutor,
    directory: Path,
    interval: float,
    ui_timeout: float,
    hotkeys: HotkeyEdges,
    control_hotkeys: Any = None,
    pinned_input_session: PinnedForegroundMouseSession | None = None,
    sleeper: Callable[[float], None] = time.sleep,
) -> tuple[bool, TerminalResult, str | None]:
    # Combat ownership becomes POSTMATCH before Unity finishes the terminal
    # animation.  In particular, the LOSS modal can materialize several
    # seconds later than the first authoritative POSTMATCH sample.  Keep a
    # bounded rolling proof window until the visible modal is stable instead
    # of treating the first three animation frames as an ambiguity.
    locations = []
    captures = []
    ui_observations: list[tuple[TerminalResult, str | None]] = []
    deadline = time.monotonic() + ui_timeout
    proof = prove_stable_result_confirm((), required_frames=3)
    sample_number = 0
    first_wait_frame_written = False
    last_location = None
    last_capture = None

    # Confirm authoritative POSTMATCH once before visual sampling.  Repeating
    # the comparatively heavy provider poll for every screenshot used to add
    # several seconds after the reward and button were already visible.  The
    # final provider poll below remains the immediate pre-click lifecycle
    # check, so stale/disconnected state still fails closed.
    initial = provider.poll()
    initial_lifecycle = (
        initial.combat_lifecycle.state
        if initial.combat_lifecycle is not None
        else CombatLifecycleState.UNKNOWN
    )
    if initial_lifecycle is not CombatLifecycleState.POSTMATCH:
        run.safe_stop(
            FarmRunStopReason.POSTMATCH_UI_AMBIGUOUS,
            detail=f"postmatch lifecycle changed to {initial_lifecycle.value}",
        )
        return False, TerminalResult.UNKNOWN, None
    if initial.state is not None and initial.state.terminal_snapshot is not None:
        snapshot = initial.state.terminal_snapshot
        ui_observations.append((snapshot.ui_result, snapshot.ui_text))

    while process.is_running() and time.monotonic() < deadline:
        sample_number += 1
        external_stop = False
        if control_hotkeys is not None:
            # Latch only; the postmatch confirmation must still complete.
            external_stop = _control_emergency_requested(control_hotkeys)
        _unused, stop = hotkeys.poll()
        if stop or external_stop:
            run.safe_stop(FarmRunStopReason.EMERGENCY_STOP)
            return False, TerminalResult.UNKNOWN, None
        capture = capture_client_rgb(process.pid)
        last_capture = capture
        if not first_wait_frame_written:
            write_png_rgb(
                directory / "postmatch_wait_frame_first.png",
                capture.width,
                capture.height,
                capture.rgb,
            )
            first_wait_frame_written = True
        last_location = locate_result_confirm(capture.rgb, capture.width, capture.height)
        locations.append(last_location)
        captures.append(capture)
        locations = locations[-3:]
        captures = captures[-3:]
        proof = prove_stable_result_confirm(locations, required_frames=3)
        if proof.proven:
            break
        remaining = deadline - time.monotonic()
        if remaining > 0:
            sleeper(min(max(interval, 0.08), remaining))

    if not proof.proven or proof.normalized_point is None:
        if last_capture is not None:
            write_png_rgb(
                directory / "postmatch_wait_frame_last.png",
                last_capture.width,
                last_capture.height,
                last_capture.rgb,
            )
        detail = (
            f"postmatch modal not stable within {ui_timeout:.1f}s; "
            f"samples={sample_number}; "
            f"last={getattr(last_location, 'reason', proof.reason)}"
        )
        run.safe_stop(FarmRunStopReason.POSTMATCH_UI_AMBIGUOUS, detail=detail)
        return False, TerminalResult.UNKNOWN, None
    for frame_number, capture in enumerate(captures[-3:], start=1):
        write_png_rgb(
            directory / f"postmatch_result_frame_{frame_number}.png",
            capture.width,
            capture.height,
            capture.rgb,
        )
    final = provider.poll()
    lifecycle = (
        final.combat_lifecycle.state
        if final.combat_lifecycle is not None
        else CombatLifecycleState.UNKNOWN
    )
    window = executor.window_status(binding)
    if lifecycle is not CombatLifecycleState.POSTMATCH:
        run.safe_stop(FarmRunStopReason.POSTMATCH_UI_AMBIGUOUS)
        return False, TerminalResult.UNKNOWN, None
    if final.state is not None and final.state.terminal_snapshot is not None:
        snapshot = final.state.terminal_snapshot
        ui_observations.append((snapshot.ui_result, snapshot.ui_text))
    known_ui = [item for item in ui_observations if item[0] is not TerminalResult.UNKNOWN]
    if len({item[0] for item in known_ui}) > 1:
        run.safe_stop(
            FarmRunStopReason.POSTMATCH_UI_AMBIGUOUS,
            detail="result title changed between validated postmatch frames",
        )
        return False, TerminalResult.UNKNOWN, None
    ui_result, ui_text = (
        known_ui[-1] if known_ui else (TerminalResult.UNKNOWN, None)
    )
    run.record_postmatch_ui_audit(ui_result, ui_text=ui_text)
    if _control_emergency_requested(control_hotkeys):
        run.safe_stop(FarmRunStopReason.EMERGENCY_STOP)
        return False, ui_result, ui_text
    permit = None
    click = None
    authorized = True
    completed = True
    lease_result = None

    def final_postmatch_preflight() -> bool:
        fresh = provider.poll()
        fresh_lifecycle = (
            fresh.combat_lifecycle.state
            if fresh.combat_lifecycle is not None
            else CombatLifecycleState.UNKNOWN
        )
        if fresh_lifecycle is not CombatLifecycleState.POSTMATCH:
            event_sink = getattr(pinned_input_session, "event_sink", None)
            if callable(event_sink):
                event_sink(
                    "postmatch_final_pre_takeover_preflight",
                    {
                        "accepted": False,
                        "lifecycle": fresh_lifecycle.value,
                        "reason": "postmatch_lifecycle_changed",
                    },
                )
            return False
        fresh_capture = capture_client_rgb(process.pid)
        fresh_location = locate_result_confirm(
            fresh_capture.rgb, fresh_capture.width, fresh_capture.height
        )
        # Reuse the detector's bounded stability rule.  Comparing the fresh
        # point to the averaged proof with exact float equality rejects an
        # unchanged control (for example 0.4984375 versus
        # 0.4984374999999999) after foreground acquisition.
        refreshed_proof = prove_stable_result_confirm(
            [*locations[-2:], fresh_location],
            required_frames=3,
        )
        accepted = refreshed_proof.proven
        event_sink = getattr(pinned_input_session, "event_sink", None)
        if callable(event_sink):
            event_sink(
                "postmatch_final_pre_takeover_preflight",
                {
                    "accepted": accepted,
                    "lifecycle": fresh_lifecycle.value,
                    "reason": refreshed_proof.reason,
                    "freshLocationReason": fresh_location.reason,
                    "freshPoint": fresh_location.normalized_point,
                    "originalProofPoint": proof.normalized_point,
                    "maxDrift": refreshed_proof.max_drift,
                },
            )
        return accepted

    def send_postmatch_once(
        *,
        retry: bool = False,
        point: tuple[float, float] | None = None,
    ) -> bool:
        nonlocal permit, click, authorized, completed
        click_point = point or proof.normalized_point
        if click_point is None:
            return False
        lease_window = executor.window_status(binding)
        permit = run.reserve_postmatch(
            foreground=(
                lease_window.valid and lease_window.foreground is True
            ),
            retry=retry,
        )
        if permit is None:
            return False
        authorized, click = _execute_controlled_input(
            control_hotkeys,
            lambda: executor.send_normalized_point(
                binding,
                click_point,
                # Unity's legacy mouse path can sample cursor movement and
                # button state on different frames, especially in a VM.  A
                # short settle prevents a Windows SENT result whose click is
                # nevertheless missed by the result modal.
                settle_cursor=True,
            ),
        )
        if not authorized or click is None:
            return False
        completed = run.complete_postmatch(
            permit,
            sent=click.sent,
            detail=(
                "RESULT_CONFIRM_RETRY"
                if retry
                else "RESULT_CONFIRM"
            )
            + f":{click.status.value}",
        )
        return bool(completed and click.sent)

    if pinned_input_session is not None:
        snapshot = run.snapshot()
        lease_result = pinned_input_session.execute_mouse(
            domain=InputDeliveryDomain.POSTMATCH_CONFIRM,
            action_identity=(
                f"POSTMATCH_CONFIRM:{run.farm_run_id}:"
                f"{snapshot.match_attempts}:{snapshot.completed_matches}"
            ),
            action=send_postmatch_once,
            preflight=lambda: run.state
            in {FarmRunState.WAIT_POSTMATCH, FarmRunState.WAIT_BOSS_LOBBY},
            final_pre_takeover_preflight=final_postmatch_preflight,
            expected_cursor_after=(
                pinned_input_session.expected_cursor_for_normalized_point(
                    proof.normalized_point
                )
            ),
        )
        sent_ok = lease_result.action_succeeded
    else:
        sent_ok = send_postmatch_once()
    if not authorized:
        run.safe_stop(FarmRunStopReason.EMERGENCY_STOP)
        return False, ui_result, ui_text
    if not sent_ok or click is None or not completed:
        status = (
            lease_result.status.value
            if lease_result is not None
            else "POSTMATCH_CLICK_NOT_COMPLETED"
        )
        run.safe_stop(
            FarmRunStopReason.POSTMATCH_UI_AMBIGUOUS,
            detail=f"postmatch confirmation not sent; lease={status}",
        )
        return False, ui_result, ui_text
    if lease_result is not None and lease_result.status is not LeaseStatus.COMPLETE:
        run.safe_stop(
            FarmRunStopReason.POSTMATCH_UI_AMBIGUOUS,
            detail="pinned postmatch lease cleanup failed after one sent click",
        )
        return False, ui_result, ui_text

    # ``ClickStatus.SENT`` confirms only that Windows accepted the synthetic
    # input.  It is not an acknowledgement from Unity.  VM scheduling can
    # occasionally leave the same result modal untouched.  Retry once, and
    # only once, after both authoritative POSTMATCH memory and the same stable
    # visible control prove that the first click had no effect.
    post_click = provider.poll()
    post_click_lifecycle = (
        post_click.combat_lifecycle.state
        if post_click.combat_lifecycle is not None
        else CombatLifecycleState.UNKNOWN
    )
    if post_click_lifecycle is not CombatLifecycleState.POSTMATCH:
        return True, ui_result, ui_text
    sleeper(max(0.35, interval))
    if _control_emergency_requested(control_hotkeys):
        run.safe_stop(FarmRunStopReason.EMERGENCY_STOP)
        return False, ui_result, ui_text
    retry_state = provider.poll()
    retry_lifecycle = (
        retry_state.combat_lifecycle.state
        if retry_state.combat_lifecycle is not None
        else CombatLifecycleState.UNKNOWN
    )
    if retry_lifecycle is not CombatLifecycleState.POSTMATCH:
        return True, ui_result, ui_text
    retry_capture = capture_client_rgb(process.pid)
    retry_location = locate_result_confirm(
        retry_capture.rgb,
        retry_capture.width,
        retry_capture.height,
    )
    retry_proof = prove_stable_result_confirm(
        [*locations[-2:], retry_location],
        required_frames=3,
    )
    if not retry_proof.proven or retry_proof.normalized_point is None:
        return True, ui_result, ui_text

    permit = None
    click = None
    authorized = True
    completed = True
    lease_result = None
    if pinned_input_session is not None:
        snapshot = run.snapshot()
        lease_result = pinned_input_session.execute_mouse(
            domain=InputDeliveryDomain.POSTMATCH_CONFIRM,
            action_identity=(
                f"POSTMATCH_CONFIRM:{run.farm_run_id}:"
                f"{snapshot.match_attempts}:{snapshot.completed_matches}:retry:1"
            ),
            action=lambda: send_postmatch_once(
                retry=True,
                point=retry_proof.normalized_point,
            ),
            preflight=lambda: run.state is FarmRunState.WAIT_BOSS_LOBBY,
            final_pre_takeover_preflight=final_postmatch_preflight,
            expected_cursor_after=(
                pinned_input_session.expected_cursor_for_normalized_point(
                    retry_proof.normalized_point
                )
            ),
        )
        retry_sent_ok = lease_result.action_succeeded
    else:
        retry_sent_ok = send_postmatch_once(
            retry=True,
            point=retry_proof.normalized_point,
        )
    if not authorized:
        run.safe_stop(FarmRunStopReason.EMERGENCY_STOP)
        return False, ui_result, ui_text
    if not retry_sent_ok or click is None or not completed:
        status = (
            lease_result.status.value
            if lease_result is not None
            else "POSTMATCH_RETRY_NOT_COMPLETED"
        )
        run.safe_stop(
            FarmRunStopReason.POSTMATCH_UI_AMBIGUOUS,
            detail=f"postmatch confirmation retry not sent; lease={status}",
        )
        return False, ui_result, ui_text
    if lease_result is not None and lease_result.status is not LeaseStatus.COMPLETE:
        run.safe_stop(
            FarmRunStopReason.POSTMATCH_UI_AMBIGUOUS,
            detail="pinned postmatch retry cleanup failed after one sent click",
        )
        return False, ui_result, ui_text
    return True, ui_result, ui_text


def _restore_bound_game_foreground(
    binding: Any,
    executor: ForegroundClickExecutor,
    *,
    sleeper: Callable[[float], None] = time.sleep,
) -> bool:
    """Restore only the already bound exact-PID HWND, then verify it afresh.

    Re-entry is an automated input boundary, so a user/UI foreground handoff
    may not be treated as a permanent failure.  Geometry changes remain fatal:
    Start already normalized the client before this binding was created.
    """

    before = executor.window_status(binding)
    if not before.valid:
        return False
    if before.foreground is not True:
        backend = executor.backend
        if (
            backend.window_pid(binding.hwnd) != binding.pid
            or not backend.restore_and_foreground(binding.hwnd)
        ):
            return False
        sleeper(0.20)
    after = executor.window_status(binding)
    return bool(
        after.valid
        and after.foreground is True
        and after.geometry is not None
        and after.geometry.width == binding.initial_width
        and after.geometry.height == binding.initial_height
    )


def _stable_visual_proof(
    first_capture: Any,
    first_location: Any,
    second_capture: Any,
    second_location: Any,
) -> bool:
    """Require the same found normalized point in two consecutive frames."""

    return bool(
        first_location.found
        and second_location.found
        and first_location.normalized_point is not None
        and second_location.normalized_point is not None
        and (first_capture.width, first_capture.height)
        == (second_capture.width, second_capture.height)
        and abs(
            first_location.normalized_point[0]
            - second_location.normalized_point[0]
        )
        <= 0.012
        and abs(
            first_location.normalized_point[1]
            - second_location.normalized_point[1]
        )
        <= 0.012
    )


def _same_clean_chinh_phuc_map_target(left: Any, right: Any) -> bool:
    """Compare the exact runtime identity used by one map-target click."""

    return bool(
        left is not None
        and right is not None
        and getattr(left, "clean", False)
        and getattr(right, "clean", False)
        and getattr(left, "pet_id", None) == getattr(right, "pet_id", None)
        and getattr(left, "group_index", None)
        == getattr(right, "group_index", None)
        and getattr(left, "pet_index", None) == getattr(right, "pet_index", None)
        and getattr(left, "hunt_order", None)
        == getattr(right, "hunt_order", None)
        and getattr(left, "button_address", None)
        == getattr(right, "button_address", None)
        and getattr(left, "button_native", None)
        == getattr(right, "button_native", None)
        and getattr(left, "manager_address", None)
        == getattr(right, "manager_address", None)
        and getattr(left, "button_viewport_rect", None)
        == getattr(right, "button_viewport_rect", None)
        and getattr(left, "button_root_transform", None)
        == getattr(right, "button_root_transform", None)
        and getattr(left, "proof_source", "legacy")
        == getattr(right, "proof_source", "legacy")
    )


def _chinh_phuc_map_runtime_hints(
    lobby: Any,
) -> tuple[int | None, int | None]:
    """Return the current map manager/panel pair when both are available."""

    world = getattr(lobby, "world_boss", None)
    manager = getattr(world, "manager_chinh_phuc", None)
    panel = getattr(world, "chinh_phuc_active_panel_index", None)
    if not isinstance(manager, int) or manager <= 0:
        manager = None
    if not isinstance(panel, int) or panel < 0:
        panel = None
    return manager, panel


def _discover_chinh_phuc_map_target_for_lobby(
    process: Any,
    pet_id: int,
    lobby: Any,
    *,
    max_region_mib: int,
    chunk_mib: int,
) -> Any | None:
    """Discover the target using live map ownership when it is readable.

    During the X transition Unity publishes ManagerChinhPhuc before it selects
    an island panel.  That is a loading boundary, not permission to fall back
    to the expensive process-wide legacy scan.  Wait for the pair to become
    complete; use legacy PlayerPrefs discovery only for older snapshots that
    expose neither field.
    """

    manager, panel = _chinh_phuc_map_runtime_hints(lobby)
    if (manager is None) != (panel is None):
        return None
    kwargs: dict[str, Any] = {
        "max_region_mib": max_region_mib,
        "chunk_mib": chunk_mib,
    }
    if manager is not None and panel is not None:
        kwargs.update(
            manager_hint=manager,
            active_panel_index=panel,
        )
    return discover_chinh_phuc_map_target(process, pet_id, **kwargs)


def _map_target_matches_lobby(runtime: Any, lobby: Any, pet_id: int) -> bool:
    """Bind one exact map target to the current owner-free lobby snapshot."""

    if not (
        runtime is not None
        and getattr(runtime, "clean", False)
        and getattr(runtime, "pet_id", None) == pet_id
        and getattr(runtime, "button_address", None) is not None
        and getattr(runtime, "viewport_point", None) is not None
        and _owner_free_chinh_phuc_map_snapshot(lobby)
    ):
        return False
    manager, panel = _chinh_phuc_map_runtime_hints(lobby)
    if manager is not None or panel is not None:
        return bool(
            manager is not None
            and panel is not None
            and getattr(runtime, "manager_address", None) == manager
            and getattr(runtime, "group_index", None) == panel
        )
    # Compatibility for older snapshots that predate the live map fields.
    chinh_phuc = getattr(lobby, "chinh_phuc", None)
    prefs = getattr(runtime, "prefs", None)
    return bool(
        chinh_phuc is not None
        and getattr(chinh_phuc, "enemy_pet_id", None)
        == getattr(prefs, "selected_pet_id", None)
    )


def _navigation_window_ready(
    binding: Any,
    executor: ForegroundClickExecutor,
    pinned_input_session: PinnedForegroundMouseSession | None,
) -> bool:
    """Validate the bound game between navigation actions.

    Foreground mode keeps the historical foreground requirement.  In pinned
    mode the user is allowed to use another application between actions; the
    bounded lease reacquires foreground only at the send boundary.  The game
    must still be the same valid, visible/topmost pinned window.
    """

    status = executor.window_status(binding)
    if not status.valid:
        return False
    if pinned_input_session is None:
        return status.foreground is True
    if not getattr(pinned_input_session, "active", True):
        return False
    backend = getattr(pinned_input_session, "backend", None)
    exact = getattr(pinned_input_session, "binding", None)
    hwnd = getattr(getattr(exact, "window", None), "hwnd", None)
    if backend is not None and hwnd is not None:
        try:
            return bool(backend.is_topmost(hwnd))
        except (AttributeError, OSError, ValueError):
            return False
    # Lightweight replay doubles do not expose the native pin backend.  Their
    # execute_mouse implementation remains the authoritative lease boundary.
    return True


def _runtime_room_start_rect(
    process: Any,
    lobby: Any,
) -> tuple[float, float, float, float] | None:
    """Read the current ManagerRoom-owned main-button rect without input."""

    button = getattr(getattr(lobby, "chinh_phuc", None), "button_start", None)
    if not button:
        return None
    try:
        geometry = NativeCardUiReader(
            process.memory,
            process.resolver.game_assembly_base,
        ).read_button_geometry(
            button,
            max_translation_jitter=1.0,
            allow_nested_fullscreen_canvas=True,
        )
    except Exception:  # noqa: BLE001 - absent geometry withholds visual proof
        return None
    return geometry.viewport_rect if geometry.active else None


def _navigation_action_identity(
    run: FarmRun,
    action: str,
    *,
    pet_id: int,
) -> str:
    return (
        f"NAVIGATION:{action}:{run.farm_run_id}:"
        f"{run.match_attempts}:{pet_id}"
    )


def _same_clean_chinh_phuc_island_target(left: Any, right: Any) -> bool:
    return bool(
        left is not None
        and right is not None
        and getattr(left, "clean", False)
        and getattr(right, "clean", False)
        and getattr(left, "pet_id", None) == getattr(right, "pet_id", None)
        and getattr(left, "group_id", None) == getattr(right, "group_id", None)
        and getattr(left, "group_index", None)
        == getattr(right, "group_index", None)
        and getattr(left, "manager_address", None)
        == getattr(right, "manager_address", None)
        and getattr(left, "button_address", None)
        == getattr(right, "button_address", None)
        and getattr(left, "button_native", None)
        == getattr(right, "button_native", None)
        and getattr(left, "button_viewport_rect", None)
        == getattr(right, "button_viewport_rect", None)
        and getattr(left, "button_root_transform", None)
        == getattr(right, "button_root_transform", None)
    )


def _select_chinh_phuc_island_from_main_map(
    *,
    run: FarmRun,
    process: Any,
    provider: MemoryBoardStateProvider,
    pet_id: int,
    first_lobby: Any,
    binding: Any,
    executor: ForegroundClickExecutor,
    interval: float,
    control_hotkeys: Any,
    pinned_input_session: PinnedForegroundMouseSession | None,
) -> bool:
    """Select the configured boss's exact island from the conquest main map."""

    first_manager, first_panel = _chinh_phuc_map_runtime_hints(first_lobby)
    if (
        first_manager is None
        or first_panel is not None
        or not _owner_free_chinh_phuc_map_snapshot(first_lobby)
        or provider.current_session_key is not None
    ):
        return False
    first_target = discover_chinh_phuc_island_target(
        process,
        pet_id,
        manager_hint=first_manager,
    )
    if first_target is None or not first_target.clean:
        return False
    time.sleep(max(interval, 0.18))
    second_lobby = _read_lobby_runtime_with_provider_fallback(process, provider)
    second_manager, second_panel = _chinh_phuc_map_runtime_hints(second_lobby)
    second_target = (
        discover_chinh_phuc_island_target(
            process,
            pet_id,
            manager_hint=second_manager,
        )
        if second_manager is not None and second_panel is None
        else None
    )
    stable = bool(
        second_lobby is not None
        and _owner_free_chinh_phuc_map_snapshot(second_lobby)
        and provider.current_session_key is None
        and first_manager == second_manager
        and _same_clean_chinh_phuc_island_target(first_target, second_target)
    )
    if not stable:
        return False

    point = second_target.viewport_point
    click_context: dict[str, Any] = {
        "authorized": True,
        "click": None,
        "completed": False,
    }

    def fresh_island_preflight() -> bool:
        fresh_lobby = _read_lobby_runtime_with_provider_fallback(process, provider)
        fresh_manager, fresh_panel = _chinh_phuc_map_runtime_hints(fresh_lobby)
        fresh_target = (
            discover_chinh_phuc_island_target(
                process,
                pet_id,
                manager_hint=fresh_manager,
            )
            if fresh_manager is not None and fresh_panel is None
            else None
        )
        accepted = bool(
            fresh_lobby is not None
            and _owner_free_chinh_phuc_map_snapshot(fresh_lobby)
            and provider.current_session_key is None
            and _same_clean_chinh_phuc_island_target(
                second_target,
                fresh_target,
            )
        )
        run._event(  # noqa: SLF001
            "chinh_phuc_island_final_pre_takeover_preflight",
            attemptIndex=run.match_attempts,
            targetPetId=pet_id,
            accepted=accepted,
            islandTarget=fresh_target,
            freshLobby=fresh_lobby,
        )
        return accepted

    # Foreground mode does not have a lease callback, so perform the same
    # atomic reread explicitly. Pinned mode performs it after takeover.
    if pinned_input_session is None and not fresh_island_preflight():
        return False

    def send_island_once() -> bool:
        if _control_emergency_requested(control_hotkeys):
            click_context["authorized"] = False
            return False
        status = executor.window_status(binding)
        permit = run.reserve_island_select(
            foreground=status.valid and status.foreground is True
        )
        if permit is None:
            return False
        authorized, click = _execute_controlled_input(
            control_hotkeys,
            lambda: executor.send_normalized_point(binding, point),
        )
        click_context["authorized"] = authorized
        click_context["click"] = click
        if not authorized or click is None:
            return False
        completed = run.complete_island_select(
            permit,
            sent=click.sent,
            detail=(
                f"CHINH_PHUC_ISLAND pet={pet_id} "
                f"group={second_target.group_index}:{click.status.value}"
            ),
        )
        click_context["completed"] = completed
        return bool(completed and click.sent)

    lease_result = None
    if pinned_input_session is not None:
        lease_result = pinned_input_session.execute_mouse(
            domain=InputDeliveryDomain.NAVIGATION_RECOVERY,
            action_identity=_navigation_action_identity(
                run,
                f"ISLAND_SELECT:{second_target.group_index}",
                pet_id=pet_id,
            ),
            action=send_island_once,
            preflight=lambda: not run.stopped,
            final_pre_takeover_preflight=fresh_island_preflight,
            expected_cursor_after=(
                pinned_input_session.expected_cursor_for_normalized_point(point)
            ),
        )
        sent = bool(
            lease_result.action_succeeded
            and lease_result.status is LeaseStatus.COMPLETE
        )
    else:
        sent = send_island_once()
    if not click_context["authorized"]:
        run.safe_stop(
            FarmRunStopReason.EMERGENCY_STOP,
            detail="emergency authority revoked before island input",
        )
        return False
    click = click_context["click"]
    if not sent or click is None or not click_context["completed"]:
        if lease_result is not None:
            run._event(  # noqa: SLF001
                "chinh_phuc_island_lease_rejected",
                attemptIndex=run.match_attempts,
                targetPetId=pet_id,
                leaseStatus=lease_result.status.value,
                leaseReason=lease_result.reason,
            )
        return False
    run._event(  # noqa: SLF001
        "chinh_phuc_island_selected",
        attemptIndex=run.match_attempts,
        targetPetId=pet_id,
        islandTarget=second_target,
        targetButtonPoint=point,
        clickStatus=click.status.value,
        association=(
            "cached GroupDTO target pet + ManagerChinhPhuc.buttons[group_index] "
            "+ native Button RectTransform geometry"
        ),
    )
    return bool(click.sent)


def _detached_shell_exit_runtime_proven(
    lobby: Any,
    *,
    pet_id: int,
    current_session: Any | None,
    first_map_target: Any | None,
    current_map_target: Any | None,
    allow_map_backed_shell: bool = False,
) -> bool:
    """Authorize only the shell-exit step when map objects are not loaded yet.

    New server room teardown can destroy the map Button closures while Unity
    still renders the exact stale room shell.  Those map objects are required
    later for target selection, but cannot be required before the reversible
    shell exit that makes the map load.  The exit remains bound to the exact
    stale enemy pet, owner-free lifecycle and current Start control; two stable
    visual frames are required separately by the caller.
    """

    detached_runtime = _is_detached_chinh_phuc_room_candidate(
        lobby,
        target_pet_id=pet_id,
        no_combat_owner=current_session is None,
    )
    map_backed_runtime = bool(
        allow_map_backed_shell
        and _is_map_backed_detached_chinh_phuc_room_candidate(
            lobby,
            target_pet_id=pet_id,
            no_combat_owner=current_session is None,
        )
    )
    if not detached_runtime and not map_backed_runtime:
        return False
    for target in (first_map_target, current_map_target):
        if target is not None:
            if not getattr(target, "clean", False):
                return False
            if getattr(target, "pet_id", None) != pet_id:
                return False
            prefs = getattr(target, "prefs", None)
            if getattr(prefs, "selected_pet_id", None) != pet_id:
                return False
    if first_map_target is not None and current_map_target is not None:
        return _same_clean_chinh_phuc_map_target(
            first_map_target, current_map_target
        )
    return True


def _is_map_backed_detached_chinh_phuc_room_candidate(
    lobby: Any,
    *,
    target_pet_id: int,
    no_combat_owner: bool,
) -> bool:
    """Recognize contradictory map memory beneath an exact room shell.

    After a server-side room teardown Unity can leave both the detached room
    canvas and the Chinh Phuc island panel active. Memory alone must not pick
    either surface: this predicate only enables the caller's two-frame visual
    disambiguation. A room-shell click still requires the visible Start/Ready
    control and circular exit proof.
    """

    chinh = getattr(lobby, "chinh_phuc", None)
    lifecycle = getattr(
        getattr(lobby, "combat_lifecycle", None), "state", None
    )
    world = getattr(lobby, "world_boss", None)
    return bool(
        no_combat_owner
        and getattr(lobby, "state", None) is BossLobbyState.LOBBY_OTHER
        and getattr(lobby, "branch", None)
        in {"CHINH_PHUC_MAP", "CHINH_PHUC_ISLAND"}
        and lifecycle is CombatLifecycleState.LOBBY
        and world is not None
        and getattr(world, "clean_for_chinh_phuc_map", False) is True
        and chinh is not None
        and getattr(chinh, "current_room_id", None) is None
        and getattr(chinh, "current_room_type", None) is None
        and getattr(chinh, "room_data", None) is not None
        and getattr(chinh, "enemy_pet_id", None) == target_pet_id
        and getattr(chinh, "button_start", None) is not None
        and getattr(chinh, "button_native", None) is not None
        and getattr(chinh, "button_interactable", None) is True
        and getattr(chinh, "is_host", None) is False
    )


def _postmatch_reentry_source(
    initial: LobbyWaitResult,
    *,
    target_pet_id: int,
    current_session: Any | None,
) -> str | None:
    """Classify the exact, read-only postmatch re-entry sources."""

    lobby = initial.lobby
    if lobby is None or current_session is not None:
        return None
    if (
        initial.reason == "GENERAL_HUB_CANDIDATE"
        and lobby.state is BossLobbyState.LOBBY_OTHER
        and lobby.branch == "GAME_LOBBY"
        and getattr(lobby.chinh_phuc, "current_room_id", None) is None
        and getattr(lobby.chinh_phuc, "current_room_type", None) is None
    ):
        return "GENERAL_HUB"
    if (
        initial.reason == "TARGET_MISSING"
        and lobby.state is BossLobbyState.BOSS_LOBBY
        and lobby.branch == "WORLD_BOSS_LIST"
        and lobby.chinh_phuc.current_room_id is None
    ):
        return "WORLD_BOSS_LIST"
    if (
        initial.reason == "CHINH_PHUC_MAP_CANDIDATE"
        and _owner_free_chinh_phuc_map_snapshot(lobby)
    ):
        return "CHINH_PHUC_MAP"
    if (
        initial.reason == "DETACHED_ROOM_SHELL_CANDIDATE"
        and _is_detached_chinh_phuc_room_candidate(
            lobby,
            target_pet_id=target_pet_id,
            no_combat_owner=True,
        )
    ):
        return "DETACHED_ROOM_SHELL"
    return None


def _owner_free_chinh_phuc_map_snapshot(lobby: Any) -> bool:
    """Accept exact read-only shapes of the Chinh Phuc island map.

    A normal map return is classified as ``BOSS_LOBBY/WORLD_BOSS_LIST``.
    After closing a detached postmatch room shell, however, Unity can keep the
    stale ``ManagerRoom.roomData`` while ``WsRoomService`` has already cleared
    ownership; the generic lobby classifier then correctly reports
    ``LOBBY_OTHER`` with no branch.  That owner-free transitional shape is not
    an ambiguous room: the caller also requires a stable runtime-derived badge
    and the exact Button/Pet/PlayerPrefs association before any click.
    """

    chinh_phuc = getattr(lobby, "chinh_phuc", None)
    lifecycle = getattr(lobby, "combat_lifecycle", None)
    if chinh_phuc is None or lifecycle is None:
        return False
    branch = getattr(lobby, "branch", None)
    state = getattr(lobby, "state", None)
    shape = (state, branch)
    ordinary_shape = shape in (
        (BossLobbyState.BOSS_LOBBY, "WORLD_BOSS_LIST"),
        (BossLobbyState.LOBBY_OTHER, None),
    )
    classified_map_shape = shape in (
        (BossLobbyState.LOBBY_OTHER, "CHINH_PHUC_MAP"),
        (BossLobbyState.LOBBY_OTHER, "CHINH_PHUC_ISLAND"),
    )
    if not ordinary_shape and not classified_map_shape:
        return False
    if classified_map_shape and not bool(
        getattr(
            getattr(lobby, "world_boss", None),
            "clean_for_chinh_phuc_map",
            False,
        )
    ):
        return False
    return bool(
        getattr(lifecycle, "state", None) is CombatLifecycleState.LOBBY
        and getattr(chinh_phuc, "current_room_id", None) is None
        and getattr(chinh_phuc, "current_room_type", None) is None
        and getattr(chinh_phuc, "owner_username", None) is None
        and getattr(chinh_phuc, "is_host", None) is False
    )


def _owner_free_general_hub_snapshot(
    lobby: Any,
    control: HubChinhPhucControl | None,
    *,
    current_session: Any | None,
) -> bool:
    """Prove the exact no-room QuangTruong shape before opening Chinh Phuc."""

    chinh_phuc = getattr(lobby, "chinh_phuc", None)
    lifecycle = getattr(lobby, "combat_lifecycle", None)
    if (
        chinh_phuc is None
        or lifecycle is None
        or control is None
        or not control.clean
        or current_session is not None
    ):
        return False
    return bool(
        getattr(lobby, "state", None) is BossLobbyState.LOBBY_OTHER
        and getattr(lobby, "branch", None) in {None, "GAME_LOBBY"}
        and (
            getattr(lobby, "branch", None) is None
            or getattr(
                getattr(lobby, "world_boss", None),
                "clean_for_game_lobby",
                False,
            )
            is True
        )
        and getattr(lifecycle, "state", None) is CombatLifecycleState.LOBBY
        and getattr(chinh_phuc, "current_room_id", None) is None
        and getattr(chinh_phuc, "current_room_type", None) is None
        and getattr(chinh_phuc, "owner_username", None) is None
        and getattr(chinh_phuc, "is_host", None) is False
        and control.panel_active is False
        and control.button_active is True
        and control.button_interactable is True
        and control.button_groups_allow is True
    )


def _settle_detached_room_shell_exit(
    *,
    run: FarmRun,
    process: Any,
    provider: MemoryBoardStateProvider,
    pet_id: int,
    binding: Any,
    executor: ForegroundClickExecutor,
    interval: float,
    timeout: float,
    control_hotkeys: Any,
    directory: Path,
    event_fields: dict[str, Any],
    pinned_input_session: PinnedForegroundMouseSession | None = None,
    max_region_mib: int = 8,
    chunk_mib: int = 2,
    allow_map_backed_shell: bool = False,
) -> tuple[str, Any | None] | None:
    """Prove either direct map navigation or one stable leave confirmation."""

    deadline = time.monotonic() + max(1.0, timeout)
    transition_started = time.monotonic()
    modal_hits = 0
    prior_modal_point: tuple[float, float] | None = None
    prior_map_runtime = None
    resolved_runtime = None
    next_runtime_probe = 0.0
    prior_hub_control: HubChinhPhucControl | None = None
    next_hub_probe = 0.0
    try:
        process_running_diagnostic: bool | None = bool(process.is_running())
    except Exception:  # noqa: BLE001 - diagnostic cannot own transition safety
        process_running_diagnostic = None
    run._event(  # noqa: SLF001
        "chinh_phuc_room_shell_settle_started",
        **event_fields,
        processRunningDiagnostic=process_running_diagnostic,
        timeoutSeconds=max(1.0, timeout),
    )
    # The exact bound HWND/PID/geometry check below is the authoritative live
    # guard for this post-click UI transition. Live run 3363 proved that one
    # GetExitCodeProcess sample can report false immediately after the normal
    # shell click even though the same game PID and window remain alive. Do not
    # let that diagnostic sample skip the entire bounded transition loop.
    while time.monotonic() < deadline:
        if _control_emergency_requested(control_hotkeys):
            run.safe_stop(
                FarmRunStopReason.EMERGENCY_STOP,
                detail="F9 while settling detached-room shell exit",
            )
            return None
        if not _navigation_window_ready(
            binding, executor, pinned_input_session
        ):
            run.safe_stop(
                FarmRunStopReason.FOREGROUND_LOST,
                detail=(
                    "bound/pinned game became invalid while settling "
                    "detached-room shell exit"
                ),
            )
            return None
        capture = capture_client_rgb(process.pid)
        modal = locate_confirm_leave(capture.rgb, capture.width, capture.height)
        if modal.found and modal.normalized_point is not None:
            same_modal = bool(
                prior_modal_point is not None
                and abs(modal.normalized_point[0] - prior_modal_point[0]) <= 0.012
                and abs(modal.normalized_point[1] - prior_modal_point[1]) <= 0.012
            )
            modal_hits = modal_hits + 1 if same_modal else 1
            prior_modal_point = modal.normalized_point
        else:
            modal_hits = 0
            prior_modal_point = None
        if 0 < modal_hits < 3:
            time.sleep(max(interval, 0.12))
            continue
        if modal_hits >= 3:
            write_png_rgb(
                directory / "chinh_phuc_room_shell_confirm.png",
                capture.width,
                capture.height,
                capture.rgb,
            )
            confirm_lobby = _read_lobby_runtime_with_provider_fallback(
                process, provider
            )
            if confirm_lobby is None:
                return None
            if not _detached_shell_exit_runtime_proven(
                confirm_lobby,
                pet_id=pet_id,
                current_session=provider.current_session_key,
                first_map_target=None,
                current_map_target=None,
                allow_map_backed_shell=allow_map_backed_shell,
            ):
                run._event(  # noqa: SLF001
                    "chinh_phuc_room_shell_confirm_rejected",
                    **event_fields,
                    confirmLobby=confirm_lobby,
                    reason="detached-room runtime proof changed before modal confirm",
                )
                return None
            click_context: dict[str, Any] = {
                "authorized": True,
                "click": None,
                "completed": False,
            }

            def fresh_confirm_preflight() -> bool:
                fresh_capture = capture_client_rgb(process.pid)
                fresh_modal = locate_confirm_leave(
                    fresh_capture.rgb,
                    fresh_capture.width,
                    fresh_capture.height,
                )
                fresh_lobby = _read_lobby_runtime_with_provider_fallback(
                    process, provider
                )
                accepted = bool(
                    fresh_lobby is not None
                    and _detached_shell_exit_runtime_proven(
                        fresh_lobby,
                        pet_id=pet_id,
                        current_session=provider.current_session_key,
                        first_map_target=None,
                        current_map_target=None,
                        allow_map_backed_shell=allow_map_backed_shell,
                    )
                    and _stable_visual_proof(
                        capture,
                        modal,
                        fresh_capture,
                        fresh_modal,
                    )
                )
                run._event(  # noqa: SLF001
                    "chinh_phuc_room_shell_confirm_final_pre_takeover_preflight",
                    **event_fields,
                    accepted=accepted,
                    freshModal=fresh_modal,
                    freshLobby=fresh_lobby,
                )
                return accepted

            def send_confirm_once() -> bool:
                if _control_emergency_requested(control_hotkeys):
                    click_context["authorized"] = False
                    return False
                status = executor.window_status(binding)
                permit = run.reserve_room_shell_confirm(
                    foreground=status.valid and status.foreground is True
                )
                if permit is None:
                    return False
                authorized, click = _execute_controlled_input(
                    control_hotkeys,
                    lambda: executor.send_normalized_point(
                        binding, modal.normalized_point
                    ),
                )
                click_context["authorized"] = authorized
                click_context["click"] = click
                if not authorized or click is None:
                    return False
                completed = run.complete_room_shell_confirm(
                    permit,
                    sent=click.sent,
                    detail=(
                        f"CHINH_PHUC_ROOM_SHELL_CONFIRM "
                        f"pet={pet_id}:{click.status.value}"
                    ),
                )
                click_context["completed"] = completed
                return bool(completed and click.sent)

            lease_result = None
            if pinned_input_session is not None:
                lease_result = pinned_input_session.execute_mouse(
                    domain=InputDeliveryDomain.NAVIGATION_RECOVERY,
                    action_identity=_navigation_action_identity(
                        run, "ROOM_SHELL_CONFIRM", pet_id=pet_id
                    ),
                    action=send_confirm_once,
                    preflight=lambda: not run.stopped,
                    final_pre_takeover_preflight=fresh_confirm_preflight,
                    expected_cursor_after=(
                        pinned_input_session.expected_cursor_for_normalized_point(
                            modal.normalized_point
                        )
                    ),
                )
                sent_ok = bool(
                    lease_result.action_succeeded
                    and lease_result.status is LeaseStatus.COMPLETE
                )
            else:
                sent_ok = send_confirm_once()
            authorized = bool(click_context["authorized"])
            click = click_context["click"]
            if not authorized:
                run.safe_stop(
                    FarmRunStopReason.EMERGENCY_STOP,
                    detail="emergency authority revoked before room-shell confirm input",
                )
                return None
            if (
                not sent_ok
                or click is None
                or not click_context["completed"]
            ):
                if lease_result is not None:
                    run._event(  # noqa: SLF001
                        "chinh_phuc_room_shell_confirm_lease_rejected",
                        **event_fields,
                        leaseStatus=lease_result.status.value,
                        leaseReason=lease_result.reason,
                    )
                return None
            run._event(  # noqa: SLF001
                "chinh_phuc_room_shell_confirm_sent",
                **event_fields,
                locator=modal,
                confirmLobby=confirm_lobby,
                clickStatus=click.status.value,
            )
            return ("CONFIRMED", None) if click.sent else None

        # Give the normal click enough time to expose a leave modal or finish
        # loading the island map.  The island target is proved from the live
        # ManagerChinhPhuc panel/Button graph; pixels are used only for the
        # separate leave-confirm modal above.
        now = time.monotonic()
        if (
            now - transition_started >= max(0.75, interval * 3.0)
            and now >= next_runtime_probe
        ):
            try:
                map_lobby = _read_lobby_runtime_with_provider_fallback(
                    process, provider
                )
            except (AttributeError, OSError, ValueError):
                map_lobby = None
            runtime = (
                _discover_chinh_phuc_map_target_for_lobby(
                    process,
                    pet_id,
                    map_lobby,
                    max_region_mib=max_region_mib,
                    chunk_mib=chunk_mib,
                )
                if map_lobby is not None
                and _owner_free_chinh_phuc_map_snapshot(map_lobby)
                and provider.current_session_key is None
                else None
            )
            next_runtime_probe = time.monotonic() + max(0.75, interval)
            if runtime is not None and runtime.clean:
                resolved_runtime = runtime
                if _same_clean_chinh_phuc_map_target(
                    prior_map_runtime, resolved_runtime
                ):
                    run._event(  # noqa: SLF001
                        "chinh_phuc_room_shell_direct_map_proven",
                        **event_fields,
                        firstRuntime=prior_map_runtime,
                        secondRuntime=resolved_runtime,
                        association="native panel Button geometry",
                    )
                    return "DIRECT_MAP", resolved_runtime
                prior_map_runtime = resolved_runtime
            else:
                prior_map_runtime = None

        # A server-side empty-room failure can make the normal shell close
        # return all the way to QuangTruong instead of the island map.  Prove
        # that exact hub state from ManagerQuangTruong and the live Unity
        # Button; generic LOBBY_OTHER alone never authorizes this route.
        now = time.monotonic()
        if now >= next_hub_probe:
            next_hub_probe = now + max(0.25, interval)
            current_hub = None
            try:
                hub_lobby = _read_lobby_runtime_with_provider_fallback(
                    process, provider
                )
                if hub_lobby is not None:
                    current_hub = read_hub_chinh_phuc_control(process)
                    if not _owner_free_general_hub_snapshot(
                        hub_lobby,
                        current_hub,
                        current_session=provider.current_session_key,
                    ):
                        current_hub = None
            except (AttributeError, OSError, ValueError):
                current_hub = None
            if same_clean_hub_chinh_phuc_control(
                prior_hub_control, current_hub
            ):
                run._event(  # noqa: SLF001
                    "chinh_phuc_room_shell_general_hub_proven",
                    **event_fields,
                    firstHubControl=prior_hub_control,
                    secondHubControl=current_hub,
                )
                return "HUB_LOBBY", current_hub
            prior_hub_control = current_hub
        time.sleep(max(interval, 0.12))

    run._event(  # noqa: SLF001
        "chinh_phuc_room_shell_transition_rejected",
        **event_fields,
        reason=(
            "neither stable leave modal, runtime-derived map badge, nor exact "
            "general-hub Chinh Phuc control appeared"
        ),
    )
    return None


def _open_chinh_phuc_from_general_hub(
    *,
    run: FarmRun,
    process: Any,
    provider: MemoryBoardStateProvider,
    first_control: HubChinhPhucControl,
    binding: Any,
    executor: ForegroundClickExecutor,
    control_hotkeys: Any,
    directory: Path,
    event_fields: dict[str, Any],
    pinned_input_session: PinnedForegroundMouseSession | None = None,
) -> bool:
    """Click the exact hub-owned Chinh Phuc Button after an atomic reread."""

    lobby = _read_lobby_runtime_with_provider_fallback(process, provider)
    if lobby is None:
        return False
    second_control = read_hub_chinh_phuc_control(process)
    if not (
        same_clean_hub_chinh_phuc_control(first_control, second_control)
        and _owner_free_general_hub_snapshot(
            lobby,
            second_control,
            current_session=provider.current_session_key,
        )
    ):
        run._event(  # noqa: SLF001
            "general_hub_chinh_phuc_open_rejected",
            **event_fields,
            firstControl=first_control,
            secondControl=second_control,
            currentLobby=lobby,
            reason="atomic general-hub runtime proof changed",
        )
        return False
    capture = capture_client_rgb(process.pid)
    location = locate_hub_chinh_phuc_control(
        capture.rgb,
        capture.width,
        capture.height,
        second_control,
    )
    write_png_rgb(
        directory / "general_hub_chinh_phuc_before.png",
        capture.width,
        capture.height,
        capture.rgb,
    )
    if not location.found or location.normalized_point is None:
        run._event(  # noqa: SLF001
            "general_hub_chinh_phuc_open_rejected",
            **event_fields,
            secondControl=second_control,
            location=location,
            reason="exact hub Button visual sanity failed",
        )
        return False
    click_context: dict[str, Any] = {
        "authorized": True,
        "click": None,
        "completed": False,
    }

    def fresh_hub_preflight() -> bool:
        fresh_lobby = _read_lobby_runtime_with_provider_fallback(
            process, provider
        )
        fresh_control = read_hub_chinh_phuc_control(process)
        fresh_capture = capture_client_rgb(process.pid)
        fresh_location = (
            locate_hub_chinh_phuc_control(
                fresh_capture.rgb,
                fresh_capture.width,
                fresh_capture.height,
                fresh_control,
            )
            if fresh_control is not None
            else None
        )
        accepted = bool(
            same_clean_hub_chinh_phuc_control(
                second_control, fresh_control
            )
            and _owner_free_general_hub_snapshot(
                fresh_lobby,
                fresh_control,
                current_session=provider.current_session_key,
            )
            and fresh_location is not None
            and _stable_visual_proof(
                capture,
                location,
                fresh_capture,
                fresh_location,
            )
        )
        run._event(  # noqa: SLF001
            "general_hub_chinh_phuc_final_pre_takeover_preflight",
            **event_fields,
            accepted=accepted,
            freshControl=fresh_control,
            freshLocation=fresh_location,
            freshLobby=fresh_lobby,
        )
        return accepted

    def send_hub_once() -> bool:
        if _control_emergency_requested(control_hotkeys):
            click_context["authorized"] = False
            return False
        status = executor.window_status(binding)
        permit = run.reserve_hub_chinh_phuc_open(
            foreground=status.valid and status.foreground is True
        )
        if permit is None:
            return False
        authorized, click = _execute_controlled_input(
            control_hotkeys,
            lambda: executor.send_normalized_point(
                binding, location.normalized_point
            ),
        )
        click_context["authorized"] = authorized
        click_context["click"] = click
        if not authorized or click is None:
            return False
        completed = run.complete_hub_chinh_phuc_open(
            permit,
            sent=click.sent,
            detail=f"GENERAL_HUB_CHINH_PHUC:{click.status.value}",
        )
        click_context["completed"] = completed
        return bool(completed and click.sent)

    lease_result = None
    if pinned_input_session is not None:
        pet_id = int(event_fields.get("targetPetId") or 0)
        lease_result = pinned_input_session.execute_mouse(
            domain=InputDeliveryDomain.NAVIGATION_RECOVERY,
            action_identity=_navigation_action_identity(
                run, "OPEN_CHINH_PHUC", pet_id=pet_id
            ),
            action=send_hub_once,
            preflight=lambda: not run.stopped,
            final_pre_takeover_preflight=fresh_hub_preflight,
            expected_cursor_after=(
                pinned_input_session.expected_cursor_for_normalized_point(
                    location.normalized_point
                )
            ),
        )
        sent_ok = bool(
            lease_result.action_succeeded
            and lease_result.status is LeaseStatus.COMPLETE
        )
    else:
        sent_ok = send_hub_once()
    authorized = bool(click_context["authorized"])
    click = click_context["click"]
    if not authorized:
        run.safe_stop(
            FarmRunStopReason.EMERGENCY_STOP,
            detail="emergency authority revoked before hub Chinh Phuc click",
        )
        return False
    if not sent_ok or click is None or not click_context["completed"]:
        if lease_result is not None:
            run._event(  # noqa: SLF001
                "general_hub_chinh_phuc_lease_rejected",
                **event_fields,
                leaseStatus=lease_result.status.value,
                leaseReason=lease_result.reason,
            )
        return False
    run._event(  # noqa: SLF001
        "general_hub_chinh_phuc_open_sent",
        **event_fields,
        control=second_control,
        location=location,
        clickStatus=click.status.value,
        association=(
            "ManagerQuangTruong.btnChinhPhuc + inactive panelChinhPhuc + "
            "live Button/RectTransform ownership"
        ),
    )
    return click.sent


def _return_from_chinh_phuc_map(
    *,
    run: FarmRun,
    process: Any,
    provider: MemoryBoardStateProvider,
    target: FarmTarget,
    initial: LobbyWaitResult,
    binding: Any,
    executor: ForegroundClickExecutor,
    directory: Path,
    interval: float,
    timeout: float,
    hotkeys: HotkeyEdges,
    control_hotkeys: Any = None,
    pinned_input_session: PinnedForegroundMouseSession | None = None,
    max_region_mib: int = 8,
    chunk_mib: int = 2,
) -> LobbyWaitResult | None:
    """Select the same pet when a result returns to its Chinh Phuc map.

    This path is intentionally narrower than a generic visual click. It needs
    stale selected-room identity plus the exact current ManagerChinhPhuc,
    active panel and cached GroupDTO/PetEnemyDTO identity. Two stable memory
    samples must resolve the same cell Button and native RectTransform. The
    hunt-order badge is a separate information control and is never navigation
    geometry.
    """

    lobby = initial.lobby
    try:
        pet_id = int(target.boss_id or "")
    except ValueError:
        return None
    reentry_source = _postmatch_reentry_source(
        initial,
        target_pet_id=pet_id,
        current_session=provider.current_session_key,
    )
    if reentry_source is None:
        return None

    external_f9 = _control_emergency_requested(control_hotkeys)
    _unused, f9 = hotkeys.poll()
    if f9 or external_f9:
        run.safe_stop(FarmRunStopReason.EMERGENCY_STOP, detail="F9 during map return")
        return LobbyWaitResult(False, lobby.state, None, "F9_EMERGENCY_STOP", lobby)

    # Re-entry may happen long after the desktop Start handoff.  Restore only
    # the farm-bound exact game window now, before discovering the target.
    # Every runtime proof below is therefore a post-focus reread; no screenshot
    # can authorize the one target click.
    if (
        pinned_input_session is None
        and not _restore_bound_game_foreground(binding, executor)
    ):
        run.safe_stop(
            FarmRunStopReason.FOREGROUND_LOST,
            detail="exact game foreground/geometry restore failed before map proof",
        )
        return LobbyWaitResult(False, lobby.state, None, "GAME_NOT_FOREGROUND", lobby)

    if reentry_source == "GENERAL_HUB":
        first_hub_lobby = _read_lobby_runtime_with_provider_fallback(
            process, provider
        )
        first_hub_control = read_hub_chinh_phuc_control(process)
        if not _owner_free_general_hub_snapshot(
            first_hub_lobby,
            first_hub_control,
            current_session=provider.current_session_key,
        ):
            return None
        time.sleep(max(interval, 0.18))
        second_hub_lobby = _read_lobby_runtime_with_provider_fallback(
            process, provider
        )
        second_hub_control = read_hub_chinh_phuc_control(process)
        if not (
            same_clean_hub_chinh_phuc_control(
                first_hub_control, second_hub_control
            )
            and _owner_free_general_hub_snapshot(
                second_hub_lobby,
                second_hub_control,
                current_session=provider.current_session_key,
            )
        ):
            return None
        if not _open_chinh_phuc_from_general_hub(
            run=run,
            process=process,
            provider=provider,
            first_control=second_hub_control,
            binding=binding,
            executor=executor,
            control_hotkeys=control_hotkeys,
            directory=directory,
            event_fields={
                "attemptIndex": run.match_attempts,
                "targetPetId": pet_id,
                "initialBranch": lobby.branch,
                "reentrySource": reentry_source,
            },
            pinned_input_session=pinned_input_session,
        ):
            return None
        time.sleep(max(0.75, interval * 3.0))

    # Detached-shell teardown destroys the island-map Button closures before
    # rendering the stale room shell. Scanning here is both inconclusive and
    # expensive; close the exactly proven shell first, then discover the map
    # target. The ordinary WORLD_BOSS_LIST path still requires target proof
    # before any click.
    direct_map_source = reentry_source in {
        "WORLD_BOSS_LIST",
        "CHINH_PHUC_MAP",
        "GENERAL_HUB",
    }
    map_backed_shell_probe = bool(
        reentry_source == "CHINH_PHUC_MAP"
        and _is_map_backed_detached_chinh_phuc_room_candidate(
            lobby,
            target_pet_id=pet_id,
            no_combat_owner=provider.current_session_key is None,
        )
    )
    first_runtime = None
    last_runtime = None
    runtime_scan_count = 0
    runtime_probe_count = 0
    runtime_stable_count = 0
    runtime_wait_reason = None
    last_runtime_wait_signature = None
    island_selection_sent = False
    if direct_map_source:
        # The visible island panel can become authoritative several frames
        # before Unity rebuilds the cached GroupDTO/PetEnemyDTO Button graph.
        # A single None here is a normal construction race, not proof that the
        # configured target is absent.  Wait without input until the same clean
        # target is observed twice, while continuously preserving the exact
        # owner-free map and bound-window fences.
        runtime_deadline = time.monotonic() + min(
            max(15.0, timeout),
            120.0,
        )
        previous_runtime = None
        while process.is_running() and time.monotonic() < runtime_deadline:
            if _control_emergency_requested(control_hotkeys):
                run.safe_stop(
                    FarmRunStopReason.EMERGENCY_STOP,
                    detail="F9 while waiting for Chinh Phuc map runtime",
                )
                return LobbyWaitResult(
                    False,
                    lobby.state,
                    None,
                    "F9_EMERGENCY_STOP",
                    lobby,
                )
            if not _navigation_window_ready(
                binding, executor, pinned_input_session
            ):
                run.safe_stop(
                    FarmRunStopReason.FOREGROUND_LOST,
                    detail="window invalid while waiting for map runtime",
                )
                return LobbyWaitResult(
                    False,
                    lobby.state,
                    None,
                    "GAME_NOT_FOREGROUND",
                    lobby,
                )
            current_map_lobby = _read_lobby_runtime_with_provider_fallback(
                process, provider
            )
            runtime_probe_count += 1
            if (
                current_map_lobby is None
                or not _owner_free_chinh_phuc_map_snapshot(current_map_lobby)
                or provider.current_session_key is not None
            ):
                if (
                    reentry_source == "GENERAL_HUB"
                    and current_map_lobby is not None
                    and getattr(current_map_lobby, "state", None)
                    is BossLobbyState.LOBBY_OTHER
                    and getattr(current_map_lobby, "branch", None)
                    == "GAME_LOBBY"
                    and provider.current_session_key is None
                ):
                    # The foreground click is already complete; allow the
                    # general hub a bounded interval to construct the Chinh
                    # Phuc panel. No additional input is authorized here.
                    time.sleep(max(interval, 0.25))
                    continue
                runtime_wait_reason = "owner-free map proof changed during runtime wait"
                break
            manager_hint, panel_hint = _chinh_phuc_map_runtime_hints(
                current_map_lobby
            )
            if (manager_hint is None) != (panel_hint is None):
                if manager_hint is not None and panel_hint is None:
                    if not island_selection_sent:
                        island_selection_sent = _select_chinh_phuc_island_from_main_map(
                            run=run,
                            process=process,
                            provider=provider,
                            pet_id=pet_id,
                            first_lobby=current_map_lobby,
                            binding=binding,
                            executor=executor,
                            interval=interval,
                            control_hotkeys=control_hotkeys,
                            pinned_input_session=pinned_input_session,
                        )
                        if run.stopped:
                            return LobbyWaitResult(
                                False,
                                lobby.state,
                                None,
                                "ISLAND_SELECTION_FAILED",
                                lobby,
                            )
                        if island_selection_sent:
                            time.sleep(max(0.75, interval * 3.0))
                            continue
                world = getattr(current_map_lobby, "world_boss", None)
                wait_signature = (
                    getattr(current_map_lobby, "branch", None),
                    manager_hint,
                    panel_hint,
                    getattr(world, "chinh_phuc_panel_main_active", None),
                )
                if wait_signature != last_runtime_wait_signature:
                    run._event(  # noqa: SLF001
                        "chinh_phuc_map_runtime_transition_wait",
                        attemptIndex=run.match_attempts,
                        targetPetId=pet_id,
                        branch=wait_signature[0],
                        managerAddress=manager_hint,
                        activePanelIndex=panel_hint,
                        panelMainActive=wait_signature[3],
                        runtimeProbe=runtime_probe_count,
                    )
                    last_runtime_wait_signature = wait_signature
                time.sleep(max(interval, 0.25))
                continue
            last_runtime = _discover_chinh_phuc_map_target_for_lobby(
                process,
                pet_id,
                current_map_lobby,
                max_region_mib=max_region_mib,
                chunk_mib=chunk_mib,
            )
            runtime_scan_count += 1
            if last_runtime is not None and last_runtime.clean:
                runtime_stable_count = (
                    runtime_stable_count + 1
                    if _same_clean_chinh_phuc_map_target(
                        previous_runtime, last_runtime
                    )
                    else 1
                )
                previous_runtime = last_runtime
                if runtime_stable_count >= 2:
                    first_runtime = last_runtime
                    break
            else:
                previous_runtime = None
                runtime_stable_count = 0
            time.sleep(max(interval, 0.25))
        if first_runtime is None and runtime_wait_reason is None:
            runtime_wait_reason = "clean map target runtime did not stabilize"
    writer_fields = {
        "attemptIndex": run.match_attempts,
        "targetPetId": pet_id,
        "initialBranch": lobby.branch,
        "reentrySource": reentry_source,
        "staleRoomPetId": getattr(
            getattr(lobby, "chinh_phuc", None), "enemy_pet_id", None
        ),
        "runtime": first_runtime,
        "lastRuntime": last_runtime,
        "runtimeProbes": runtime_probe_count,
        "runtimeScans": runtime_scan_count,
        "runtimeStableFrames": runtime_stable_count,
    }
    if first_runtime is not None and not first_runtime.clean:
        run._event("chinh_phuc_map_return_rejected", **writer_fields)  # noqa: SLF001
        return None
    if direct_map_source and first_runtime is None:
        run._event(  # noqa: SLF001
            "chinh_phuc_map_return_rejected",
            **writer_fields,
            reason=runtime_wait_reason,
        )
        return None

    stable_native_target = first_runtime is not None
    stable_room_shell = False
    first_shell_exit = None
    second_shell_exit = None
    first_capture = None
    second_capture = None
    proof_frames = 0

    # A clean target normally contains the exact Button and its native
    # RectTransform geometry from two stable memory samples. One server
    # teardown shape leaves that map graph active *behind* the exact detached
    # room canvas. Only for that contradictory shape, use the same bounded
    # two-frame room-control proof before deciding which surface owns input.
    if not stable_native_target or map_backed_shell_probe:
        if not _navigation_window_ready(
            binding, executor, pinned_input_session
        ):
            run.safe_stop(
                FarmRunStopReason.FOREGROUND_LOST,
                detail="detached room-shell proof",
            )
            return LobbyWaitResult(
                False, lobby.state, None, "GAME_NOT_FOREGROUND", lobby
            )

        def park_cursor() -> bool:
            nonlocal authorized, cursor_park
            authorized, cursor_park = _execute_controlled_input(
                control_hotkeys,
                lambda: executor.move_normalized_point(binding, (0.50, 0.015)),
            )
            return bool(authorized and cursor_park is ClickStatus.SENT)

        authorized = True
        cursor_park = None
        if pinned_input_session is not None:
            park_lease = pinned_input_session.execute_mouse(
                domain=InputDeliveryDomain.NAVIGATION_RECOVERY,
                action_identity=_navigation_action_identity(
                    run, "ROOM_SHELL_CURSOR_PARK", pet_id=pet_id
                ),
                action=park_cursor,
                preflight=lambda: not run.stopped,
                final_pre_takeover_preflight=None,
                expected_cursor_after=(
                    pinned_input_session.expected_cursor_for_normalized_point(
                        (0.50, 0.015)
                    )
                ),
            )
            park_ok = bool(
                park_lease.action_succeeded
                and park_lease.status is LeaseStatus.COMPLETE
            )
        else:
            park_ok = park_cursor()
        if not authorized or cursor_park is None:
            run.safe_stop(
                FarmRunStopReason.EMERGENCY_STOP,
                detail="emergency authority revoked before room-shell proof",
            )
            return LobbyWaitResult(
                False, lobby.state, None, "F9_EMERGENCY_STOP", lobby
            )
        if not park_ok or cursor_park is not ClickStatus.SENT:
            run._event(  # noqa: SLF001
                "chinh_phuc_map_return_rejected",
                **writer_fields,
                reason=f"room-shell cursor park failed: {cursor_park.value}",
            )
            return None

        proof_deadline = time.monotonic() + max(1.0, timeout)
        room_start_rect = _runtime_room_start_rect(process, lobby)
        time.sleep(max(interval, 0.18))
        first_capture = capture_client_rgb(process.pid)
        first_shell_exit = locate_detached_chinh_phuc_room_shell_exit(
            first_capture.rgb,
            first_capture.width,
            first_capture.height,
            expected_start_rect=room_start_rect,
        )
        second_capture = first_capture
        second_shell_exit = first_shell_exit
        proof_frames = 1
        while process.is_running() and time.monotonic() < proof_deadline:
            if _control_emergency_requested(control_hotkeys):
                run.safe_stop(
                    FarmRunStopReason.EMERGENCY_STOP,
                    detail="F9 while waiting for detached room-shell proof",
                )
                return LobbyWaitResult(
                    False, lobby.state, None, "F9_EMERGENCY_STOP", lobby
                )
            if not _navigation_window_ready(
                binding, executor, pinned_input_session
            ):
                run.safe_stop(
                    FarmRunStopReason.FOREGROUND_LOST,
                    detail="foreground lost during room-shell proof",
                )
                return LobbyWaitResult(
                    False, lobby.state, None, "GAME_NOT_FOREGROUND", lobby
                )
            time.sleep(max(interval, 0.18))
            second_capture = capture_client_rgb(process.pid)
            second_shell_exit = locate_detached_chinh_phuc_room_shell_exit(
                second_capture.rgb,
                second_capture.width,
                second_capture.height,
                expected_start_rect=room_start_rect,
            )
            proof_frames += 1
            stable_room_shell = _stable_visual_proof(
                first_capture,
                first_shell_exit,
                second_capture,
                second_shell_exit,
            )
            if stable_room_shell:
                break
            first_capture = second_capture
            first_shell_exit = second_shell_exit
        if second_capture is not None:
            write_png_rgb(
                directory / "chinh_phuc_room_shell_before.png",
                second_capture.width,
                second_capture.height,
                second_capture.rgb,
            )
        if not stable_room_shell and not map_backed_shell_probe:
            run._event(  # noqa: SLF001
                "chinh_phuc_map_return_rejected",
                **writer_fields,
                firstShellExit=first_shell_exit,
                secondShellExit=second_shell_exit,
                proofFrames=proof_frames,
                reason="detached-room shell did not pass bounded two-frame proof",
            )
            return None
        if not stable_room_shell and map_backed_shell_probe:
            run._event(  # noqa: SLF001
                "chinh_phuc_map_backed_shell_not_visible",
                **writer_fields,
                firstShellExit=first_shell_exit,
                secondShellExit=second_shell_exit,
                proofFrames=proof_frames,
                reason=(
                    "stale room runtime coexists with map, but the bounded "
                    "room-shell visual proof is absent"
                ),
            )

    if stable_room_shell:
        # A completed match can leave Unity rendering a stale room shell after
        # the server-side ManagerWsRoom ownership has already disappeared.
        # The circular X also exists on the real island map, therefore the
        # click is allowed only with the room-only Start/Ready visual proof and
        # an immediate exact-target/no-owner runtime reread.
        shell_lobby = _read_lobby_runtime_with_provider_fallback(
            process, provider
        )
        if shell_lobby is None:
            return None
        shell_runtime_stable = _detached_shell_exit_runtime_proven(
            shell_lobby,
            pet_id=pet_id,
            current_session=provider.current_session_key,
            first_map_target=first_runtime,
            current_map_target=None,
            allow_map_backed_shell=map_backed_shell_probe,
        )
        if not shell_runtime_stable:
            run._event(  # noqa: SLF001
                "chinh_phuc_room_shell_exit_rejected",
                **writer_fields,
                firstShellExit=first_shell_exit,
                secondShellExit=second_shell_exit,
                shellLobby=shell_lobby,
                reason="atomic detached-room runtime proof changed",
            )
            return None
        if second_shell_exit.normalized_point is None:
            return None
        shell_context: dict[str, Any] = {
            "authorized": True,
            "click": None,
            "completed": False,
        }

        def fresh_shell_exit_preflight() -> bool:
            fresh_lobby = _read_lobby_runtime_with_provider_fallback(
                process, provider
            )
            fresh_capture = capture_client_rgb(process.pid)
            fresh_shell = locate_detached_chinh_phuc_room_shell_exit(
                fresh_capture.rgb,
                fresh_capture.width,
                fresh_capture.height,
                expected_start_rect=_runtime_room_start_rect(
                    process, fresh_lobby
                ),
            )
            accepted = bool(
                fresh_lobby is not None
                and _detached_shell_exit_runtime_proven(
                    fresh_lobby,
                    pet_id=pet_id,
                    current_session=provider.current_session_key,
                    first_map_target=first_runtime,
                    current_map_target=None,
                    allow_map_backed_shell=map_backed_shell_probe,
                )
                and _stable_visual_proof(
                    second_capture,
                    second_shell_exit,
                    fresh_capture,
                    fresh_shell,
                )
            )
            run._event(  # noqa: SLF001
                "chinh_phuc_room_shell_exit_final_pre_takeover_preflight",
                **writer_fields,
                accepted=accepted,
                freshShellExit=fresh_shell,
                freshLobby=fresh_lobby,
            )
            return accepted

        def send_shell_exit_once() -> bool:
            if _control_emergency_requested(control_hotkeys):
                shell_context["authorized"] = False
                return False
            status = executor.window_status(binding)
            shell_permit = run.reserve_room_shell_exit(
                foreground=status.valid and status.foreground is True
            )
            if shell_permit is None:
                return False
            authorized, shell_click = _execute_controlled_input(
                control_hotkeys,
                lambda: executor.send_normalized_point(
                    binding, second_shell_exit.normalized_point
                ),
            )
            shell_context["authorized"] = authorized
            shell_context["click"] = shell_click
            if not authorized or shell_click is None:
                return False
            completed = run.complete_room_shell_exit(
                shell_permit,
                sent=shell_click.sent,
                detail=(
                    f"CHINH_PHUC_ROOM_SHELL_EXIT "
                    f"pet={pet_id}:{shell_click.status.value}"
                ),
            )
            shell_context["completed"] = completed
            return bool(completed and shell_click.sent)

        shell_lease = None
        if pinned_input_session is not None:
            shell_lease = pinned_input_session.execute_mouse(
                domain=InputDeliveryDomain.NAVIGATION_RECOVERY,
                action_identity=_navigation_action_identity(
                    run, "ROOM_SHELL_EXIT", pet_id=pet_id
                ),
                action=send_shell_exit_once,
                preflight=lambda: not run.stopped,
                final_pre_takeover_preflight=fresh_shell_exit_preflight,
                expected_cursor_after=(
                    pinned_input_session.expected_cursor_for_normalized_point(
                        second_shell_exit.normalized_point
                    )
                ),
            )
            shell_sent = bool(
                shell_lease.action_succeeded
                and shell_lease.status is LeaseStatus.COMPLETE
            )
        else:
            shell_sent = send_shell_exit_once()
        authorized = bool(shell_context["authorized"])
        shell_click = shell_context["click"]
        if not authorized:
            run.safe_stop(
                FarmRunStopReason.EMERGENCY_STOP,
                detail="emergency authority revoked before room-shell input",
            )
            return LobbyWaitResult(
                False, lobby.state, None, "F9_EMERGENCY_STOP", lobby
            )
        if (
            not shell_sent
            or shell_click is None
            or not shell_context["completed"]
        ):
            if shell_lease is not None:
                run._event(  # noqa: SLF001
                    "chinh_phuc_room_shell_exit_lease_rejected",
                    **writer_fields,
                    leaseStatus=shell_lease.status.value,
                    leaseReason=shell_lease.reason,
                )
            return None
        run._event(  # noqa: SLF001
            "chinh_phuc_room_shell_exit_sent",
            **writer_fields,
            firstShellExit=first_shell_exit,
            secondShellExit=second_shell_exit,
            shellLobby=shell_lobby,
            clickStatus=shell_click.status.value,
        )
        # Depending on server/UI timing the normal shell close either navigates
        # directly to the map or shows one leave-confirm modal.  Both paths are
        # bounded and require stable visual plus unchanged exact-pet runtime
        # evidence; no other postmatch click is permitted.
        shell_transition_result = _settle_detached_room_shell_exit(
            run=run,
            process=process,
            provider=provider,
            pet_id=pet_id,
            binding=binding,
            executor=executor,
            interval=interval,
            timeout=timeout,
            control_hotkeys=control_hotkeys,
            directory=directory,
            event_fields=writer_fields,
            pinned_input_session=pinned_input_session,
            max_region_mib=max_region_mib,
            chunk_mib=chunk_mib,
            allow_map_backed_shell=map_backed_shell_probe,
        )
        if shell_transition_result is None:
            return None
        shell_transition, transition_runtime = shell_transition_result

        hub_navigation_used = False
        if shell_transition == "HUB_LOBBY":
            if not isinstance(transition_runtime, HubChinhPhucControl) or not (
                _open_chinh_phuc_from_general_hub(
                    run=run,
                    process=process,
                    provider=provider,
                    first_control=transition_runtime,
                    binding=binding,
                    executor=executor,
                    control_hotkeys=control_hotkeys,
                    directory=directory,
                    event_fields=writer_fields,
                    pinned_input_session=pinned_input_session,
                )
            ):
                return None
            hub_navigation_used = True
            transition_runtime = None

        # Wait for two stable reads of the target Button association and its
        # native RectTransform geometry.  No screenshot participates in boss
        # identity or click-point selection.
        map_deadline = time.monotonic() + max(1.0, timeout)
        map_runtime = transition_runtime
        last_map_runtime = None
        prior_hub_control = None
        previous_map_runtime = None
        stable_native_target = bool(
            map_runtime is not None
            and map_runtime.clean
            and map_runtime.viewport_point is not None
        )
        # A confirmed modal or hub transition still needs time to construct
        # the live island panel before its first bounded hierarchy walk.
        if not stable_native_target:
            time.sleep(max(0.75, interval * 3.0))
        while not stable_native_target and time.monotonic() < map_deadline:
            if _control_emergency_requested(control_hotkeys):
                run.safe_stop(
                    FarmRunStopReason.EMERGENCY_STOP,
                    detail="F9 while waiting for map after room-shell exit",
                )
                return LobbyWaitResult(
                    False, lobby.state, None, "F9_EMERGENCY_STOP", lobby
                )
            if not _navigation_window_ready(
                binding, executor, pinned_input_session
            ):
                run.safe_stop(
                    FarmRunStopReason.FOREGROUND_LOST,
                    detail="foreground lost after room-shell exit",
                )
                return LobbyWaitResult(
                    False, lobby.state, None, "GAME_NOT_FOREGROUND", lobby
                )
            try:
                current_map_lobby = (
                    _read_lobby_runtime_with_provider_fallback(
                        process, provider
                    )
                )
            except (AttributeError, OSError, ValueError):
                current_map_lobby = None
            current_manager, current_panel = _chinh_phuc_map_runtime_hints(
                current_map_lobby
            )
            if (
                current_map_lobby is not None
                and current_manager is not None
                and current_panel is None
                and not island_selection_sent
            ):
                island_selection_sent = _select_chinh_phuc_island_from_main_map(
                    run=run,
                    process=process,
                    provider=provider,
                    pet_id=pet_id,
                    first_lobby=current_map_lobby,
                    binding=binding,
                    executor=executor,
                    interval=interval,
                    control_hotkeys=control_hotkeys,
                    pinned_input_session=pinned_input_session,
                )
                if run.stopped:
                    return LobbyWaitResult(
                        False,
                        lobby.state,
                        None,
                        "ISLAND_SELECTION_FAILED",
                        lobby,
                    )
                if island_selection_sent:
                    time.sleep(max(0.75, interval * 3.0))
                    continue
            last_map_runtime = (
                _discover_chinh_phuc_map_target_for_lobby(
                    process,
                    pet_id,
                    current_map_lobby,
                    max_region_mib=max_region_mib,
                    chunk_mib=chunk_mib,
                )
                if current_map_lobby is not None
                and _owner_free_chinh_phuc_map_snapshot(current_map_lobby)
                and provider.current_session_key is None
                else None
            )
            if (
                last_map_runtime is not None
                and last_map_runtime.clean
                and last_map_runtime.viewport_point is not None
            ):
                if _same_clean_chinh_phuc_map_target(
                    previous_map_runtime, last_map_runtime
                ):
                    map_runtime = last_map_runtime
                    stable_native_target = True
                    break
                previous_map_runtime = last_map_runtime
                time.sleep(max(interval, 0.18))
                continue

            previous_map_runtime = None
            # A leave-confirm path may finish in the same general hub as the
            # direct X path. Detect it only through two stable exact
            # ManagerQuangTruong Button samples, then open Chinh Phuc once.
            if not hub_navigation_used:
                try:
                    hub_lobby = _read_lobby_runtime_with_provider_fallback(
                        process, provider
                    )
                    current_hub = read_hub_chinh_phuc_control(process)
                    if not _owner_free_general_hub_snapshot(
                        hub_lobby,
                        current_hub,
                        current_session=provider.current_session_key,
                    ):
                        current_hub = None
                except (AttributeError, OSError, ValueError):
                    current_hub = None
                if same_clean_hub_chinh_phuc_control(
                    prior_hub_control, current_hub
                ):
                    if not _open_chinh_phuc_from_general_hub(
                        run=run,
                        process=process,
                        provider=provider,
                        first_control=current_hub,
                        binding=binding,
                        executor=executor,
                        control_hotkeys=control_hotkeys,
                        directory=directory,
                        event_fields=writer_fields,
                        pinned_input_session=pinned_input_session,
                    ):
                        return None
                    hub_navigation_used = True
                    prior_hub_control = None
                    time.sleep(max(0.75, interval * 3.0))
                    continue
                prior_hub_control = current_hub
            time.sleep(max(interval, 0.18))
        if not stable_native_target or map_runtime is None:
            run._event(  # noqa: SLF001
                "chinh_phuc_room_shell_exit_rejected",
                **writer_fields,
                lastMapRuntime=last_map_runtime,
                reason="native target Button geometry absent after one shell exit",
            )
            return None
        first_runtime = map_runtime

    # Atomic preflight: reread both gameplay lifecycle and the complete target
    # association immediately before reserving the one normal lobby click.
    current_lobby = _read_lobby_runtime_with_provider_fallback(
        process, provider
    )
    if current_lobby is None:
        return None
    second_runtime = _discover_chinh_phuc_map_target_for_lobby(
        process,
        pet_id,
        current_lobby,
        max_region_mib=max_region_mib,
        chunk_mib=chunk_mib,
    )
    runtime_stable = bool(
        _same_clean_chinh_phuc_map_target(first_runtime, second_runtime)
        and _map_target_matches_lobby(second_runtime, current_lobby, pet_id)
        and provider.current_session_key is None
    )
    if not runtime_stable:
        run._event(  # noqa: SLF001
            "chinh_phuc_map_return_rejected",
            **writer_fields,
            secondRuntime=second_runtime,
            currentLobby=current_lobby,
            reason="atomic runtime target preflight changed",
        )
        return None
    target_point = getattr(second_runtime, "viewport_point", None)
    if target_point is None:
        return None
    target_context: dict[str, Any] = {
        "authorized": True,
        "click": None,
        "completed": False,
    }

    def fresh_target_preflight() -> bool:
        fresh_lobby = None
        fresh_runtime = None
        accepted = False
        runtime_probes = 0
        # Acquiring foreground can coincide with one Unity hierarchy rebuild.
        # Retry only a missing target graph while the exact owner-free island
        # and no-combat fences remain true. A different readable target fails
        # closed immediately; no input permit has been reserved at this point.
        for probe in range(4):
            fresh_lobby = _read_lobby_runtime_with_provider_fallback(
                process, provider
            )
            runtime_probes += 1
            if (
                fresh_lobby is None
                or not _owner_free_chinh_phuc_map_snapshot(fresh_lobby)
                or provider.current_session_key is not None
            ):
                break
            fresh_runtime = _discover_chinh_phuc_map_target_for_lobby(
                process,
                pet_id,
                fresh_lobby,
                max_region_mib=max_region_mib,
                chunk_mib=chunk_mib,
            )
            accepted = bool(
                _same_clean_chinh_phuc_map_target(
                    second_runtime, fresh_runtime
                )
                and _map_target_matches_lobby(
                    fresh_runtime, fresh_lobby, pet_id
                )
            )
            if accepted or fresh_runtime is not None:
                break
            if probe < 3:
                time.sleep(max(interval, 0.18))
        run._event(  # noqa: SLF001
            "chinh_phuc_map_target_final_pre_takeover_preflight",
            **writer_fields,
            accepted=accepted,
            postFocusRuntimeProbes=runtime_probes,
            freshRuntime=fresh_runtime,
            freshButtonPoint=(
                fresh_runtime.viewport_point
                if fresh_runtime is not None
                else None
            ),
            freshLobby=fresh_lobby,
        )
        return accepted

    def send_target_once() -> bool:
        if _control_emergency_requested(control_hotkeys):
            target_context["authorized"] = False
            return False
        status = executor.window_status(binding)
        permit = run.reserve_target_select(
            foreground=status.valid and status.foreground is True,
            direct_map_after_shell_exit=(
                stable_room_shell
                and shell_transition in {"DIRECT_MAP", "HUB_LOBBY"}
            ),
        )
        if permit is None:
            return False
        authorized, click = _execute_controlled_input(
            control_hotkeys,
            lambda: executor.send_normalized_point(binding, target_point),
        )
        target_context["authorized"] = authorized
        target_context["click"] = click
        if not authorized or click is None:
            return False
        completed = run.complete_target_select(
            permit,
            sent=click.sent,
            detail=(
                f"CHINH_PHUC_MAP pet={pet_id} "
                f"group={second_runtime.group_index} "
                f"order={second_runtime.hunt_order}:{click.status.value}"
            ),
        )
        target_context["completed"] = completed
        return bool(completed and click.sent)

    target_selection_ordinal = 1 + sum(
        1
        for record in run.input_records
        if record.domain is FarmInputDomain.BOSS_TARGET_SELECT
        and record.attempt_index == run.match_attempts
        and record.sent
    )
    target_lease = None
    if pinned_input_session is not None:
        target_lease = pinned_input_session.execute_mouse(
            domain=InputDeliveryDomain.NAVIGATION_RECOVERY,
            action_identity=_navigation_action_identity(
                run,
                (
                    f"TARGET_SELECT:{second_runtime.group_index}:"
                    f"{second_runtime.hunt_order}:"
                    f"{target_selection_ordinal}"
                ),
                pet_id=pet_id,
            ),
            action=send_target_once,
            preflight=lambda: not run.stopped,
            final_pre_takeover_preflight=fresh_target_preflight,
            expected_cursor_after=(
                pinned_input_session.expected_cursor_for_normalized_point(
                    target_point
                )
            ),
        )
        target_sent = bool(
            target_lease.action_succeeded
            and target_lease.status is LeaseStatus.COMPLETE
        )
    else:
        target_sent = send_target_once()
    authorized = bool(target_context["authorized"])
    click = target_context["click"]
    if not authorized:
        run.safe_stop(
            FarmRunStopReason.EMERGENCY_STOP,
            detail="emergency authority revoked before map target input",
        )
        return LobbyWaitResult(
            False, lobby.state, None, "F9_EMERGENCY_STOP", lobby
        )
    if (
        not target_sent
        or click is None
        or not target_context["completed"]
    ):
        if target_lease is not None:
            run._event(  # noqa: SLF001
                "chinh_phuc_map_target_lease_rejected",
                **writer_fields,
                leaseStatus=target_lease.status.value,
                leaseReason=target_lease.reason,
            )
        return None
    run._event(  # noqa: SLF001
        "chinh_phuc_map_target_selected",
        **writer_fields,
        secondRuntime=second_runtime,
        targetButtonAddress=second_runtime.button_address,
        targetButtonRect=second_runtime.button_viewport_rect,
        targetButtonPoint=target_point,
        clickStatus=click.status.value,
        association=(
            "cached GroupDTO/PetEnemyDTO + active island panel + "
            "ManagerChinhPhuc.OnReceived panelButtons[pet_index] + "
            "native Button RectTransform geometry"
        ),
    )
    if not click.sent:
        return None
    return _wait_boss_lobby(
        process,
        provider,
        target,
        timeout,
        interval,
        hotkeys,
        control_hotkeys,
        wait_through_target_missing=True,
        wait_through_map_candidate=True,
        transient_room_grace_seconds=min(
            10.0,
            max(2.0, timeout * 0.20),
        ),
    )


def _outside_current_boss_room(result: LobbyWaitResult) -> bool:
    """Return true only when read-only evidence proves the room was lost."""

    return bool(
        result.lobby is not None
        and result.lobby.branch != "CHINH_PHUC_ROOM"
    )


def _world_map_ejection_proven(
    result: LobbyWaitResult,
    *,
    current_session: Any | None,
) -> bool:
    """Accept only the settled map branch after the combat owner is gone."""

    return bool(
        result.reason == "TARGET_MISSING"
        and result.lobby is not None
        and result.lobby.branch == "WORLD_BOSS_LIST"
        and result.lobby.chinh_phuc.current_room_id is None
        and current_session is None
    )


def _farm_room_ejection_sources(
    result: LobbyWaitResult,
    *,
    target_boss_id: str,
    current_session: Any | None,
) -> tuple[bool, bool, bool]:
    """Classify owner-free map, detached-shell, and general-hub origins."""

    exact_world_map = _world_map_ejection_proven(
        result, current_session=current_session
    )
    direct_chinh_phuc_map = False
    try:
        target_pet_id = int(str(target_boss_id or "").strip())
    except ValueError:
        target_pet_id = -1
    if target_pet_id > 0 and result.reason == "CHINH_PHUC_MAP_CANDIDATE":
        direct_chinh_phuc_map = (
            _postmatch_reentry_source(
                result,
                target_pet_id=target_pet_id,
                current_session=current_session,
            )
            == "CHINH_PHUC_MAP"
        )
    if exact_world_map or direct_chinh_phuc_map:
        return True, False, False
    detached_room_shell = bool(
        target_pet_id > 0
        and _postmatch_reentry_source(
            result,
            target_pet_id=target_pet_id,
            current_session=current_session,
        )
        == "DETACHED_ROOM_SHELL"
    )
    general_hub = bool(
        target_pet_id > 0
        and _postmatch_reentry_source(
            result,
            target_pet_id=target_pet_id,
            current_session=current_session,
        )
        == "GENERAL_HUB"
    )
    return exact_world_map, detached_room_shell, general_hub


def _exact_target_room_restored(
    result: LobbyWaitResult | None,
    *,
    current_session: Any | None,
) -> bool:
    return bool(
        result is not None
        and result.ready
        and result.lobby is not None
        and result.lobby.branch == "CHINH_PHUC_ROOM"
        and current_session is None
    )


def _restore_ejected_farm_room(
    *,
    run: FarmRun,
    args: Namespace,
    process: Any,
    provider: MemoryBoardStateProvider,
    target: FarmTarget,
    initial: LobbyWaitResult,
    binding: Any,
    executor: ForegroundClickExecutor,
    directory: Path,
    hotkeys: HotkeyEdges,
    control_hotkeys: Any,
    writer: FarmRunArtifactWriter,
    recovery_records: tuple[Any, ...] | None = None,
    pinned_input_session: PinnedForegroundMouseSession | None = None,
) -> bool:
    """Restore the immutable farm-session pet after a proven room ejection."""

    target_id = str(target.boss_id or "").strip()
    try:
        int(target_id)
    except ValueError:
        return False
    exact_world_map, detached_room_shell, general_hub = _farm_room_ejection_sources(
        initial,
        target_boss_id=target_id,
        current_session=provider.current_session_key,
    )
    if not exact_world_map and not detached_room_shell and not general_hub:
        return False
    if run.state is FarmRunState.COMBAT_ACTIVE:
        if not run.technical_failure("ROOM_EJECTED_TO_BOSS_MAP"):
            return False
    elif run.state is FarmRunState.RECOVERY_ACTIVE:
        if not run.prepare_failed_recovery_map_fallback(
            tuple(recovery_records or ())
        ):
            return False
    elif run.state is not FarmRunState.RECOVERY_PENDING:
        return False
    if not run.begin_ejected_map_reentry(
        target_boss_id=target_id,
        exact_world_map=exact_world_map,
        detached_room_shell=detached_room_shell,
        general_hub=general_hub,
        no_combat_owner=True,
    ):
        return False
    executor.arm_recovery_swap_pacing("ROOM_EJECTION_REENTRY")
    map_return = _return_from_chinh_phuc_map(
        run=run,
        process=process,
        provider=provider,
        target=target,
        initial=initial,
        binding=binding,
        executor=executor,
        directory=directory,
        interval=args.interval,
        timeout=args.return_lobby_timeout,
        hotkeys=hotkeys,
        control_hotkeys=control_hotkeys,
        pinned_input_session=pinned_input_session,
        max_region_mib=args.max_region_mib,
        chunk_mib=args.chunk_mib,
    )
    writer.event(
        "combat_room_ejection_reentry",
        attemptIndex=run.match_attempts,
        targetBossId=target_id,
        initial=initial,
        result=map_return,
        recoveryFallback=(recovery_records is not None),
    )
    if not _exact_target_room_restored(
        map_return, current_session=provider.current_session_key
    ):
        if not run.stopped:
            run.safe_stop(
                FarmRunStopReason.RECOVERY_FAILED,
                detail="exact pet room not restored after ejection",
            )
        return False
    if not run.complete_ejected_map_reentry(
        target_boss_id=target_id,
        exact_target_room=True,
        no_combat_owner=True,
    ):
        return False
    return run.observe_return_lobby(BossLobbyState.BOSS_LOBBY)


def _terminal_snapshot_from_summary(
    summary: dict[str, Any] | None,
    expected_session: CombatSessionKey,
) -> TerminalCombatSnapshot:
    raw = (summary or {}).get("terminalCombatSnapshot")
    if not isinstance(raw, dict):
        return TerminalCombatSnapshot(
            match_id=expected_session.match_id,
            session_key=expected_session,
            lifecycle_epoch=expected_session.lifecycle_epoch,
            timestamp=str((summary or {}).get("timestamp") or "UNKNOWN"),
            evidence_sources=("TERMINAL_SNAPSHOT_MISSING",),
        )
    key_raw = raw.get("session_key") or {}
    try:
        key = CombatSessionKey(
            int(key_raw["lifecycle_epoch"]),
            int(key_raw["board_instance"]),
            str(key_raw["match_id"]),
        )
        snapshot = TerminalCombatSnapshot(
            match_id=str(raw["match_id"]),
            session_key=key,
            lifecycle_epoch=int(raw["lifecycle_epoch"]),
            timestamp=str(raw["timestamp"]),
            turn_number=raw.get("turn_number"),
            srv_seq=raw.get("srv_seq"),
            board_hash=raw.get("board_hash"),
            local_actor_number=raw.get("local_actor_number"),
            local_hp=raw.get("local_hp"),
            local_max_hp=raw.get("local_max_hp"),
            boss_actor_number=raw.get("boss_actor_number"),
            boss_hp=raw.get("boss_hp"),
            boss_max_hp=raw.get("boss_max_hp"),
            terminal_event_type=raw.get("terminal_event_type"),
            terminal_winner=raw.get("terminal_winner"),
            result=TerminalResult(str(raw.get("result") or "UNKNOWN")),
            confidence=TerminalResultConfidence(
                str(raw.get("confidence") or "UNKNOWN")
            ),
            evidence_sources=tuple(raw.get("evidence_sources") or ()),
            ui_text=raw.get("ui_text"),
            ui_result=TerminalResult(str(raw.get("ui_result") or "UNKNOWN")),
            captured_before_cleanup=raw.get("captured_before_cleanup") is True,
        )
    except (KeyError, TypeError, ValueError):
        return TerminalCombatSnapshot(
            match_id=expected_session.match_id,
            session_key=expected_session,
            lifecycle_epoch=expected_session.lifecycle_epoch,
            timestamp=str((summary or {}).get("timestamp") or "UNKNOWN"),
            evidence_sources=("TERMINAL_SNAPSHOT_INVALID",),
        )
    if snapshot.session_key != expected_session:
        raise ValueError("terminal snapshot does not match farm-owned session")
    return snapshot


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


_ACK_UNSAFE_RECOVERY_DETAILS = frozenset(
    {
        "RECOVERY_ACK_EPOCH_NOT_RESET",
        "RECOVERY_LOBBY_MATCH_NOT_CLEARED",
        "RECOVERY_LOBBY_ACK_EPOCH_UNREADABLE",
    }
)


def _failed_recovery_fallback_allowed(snapshot: Any) -> bool:
    """Never bypass recovery evidence proving a dirty transport epoch."""

    return str(getattr(snapshot, "result_detail", "") or "") not in (
        _ACK_UNSAFE_RECOVERY_DETAILS
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
    failed_recovery_map_fallback: Callable[[Any], bool] | None = None,
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
    if code == 130:
        run.safe_stop(
            FarmRunStopReason.EMERGENCY_STOP,
            detail="F9 during technical recovery",
        )
        return False
    if code == 3:
        stopped = bool(
            run.graceful_stop_requested()
            and run.record_technical_exit(snapshot.input_records)
        )
        writer.event(
            "technical_recovery_graceful_exit",
            stoppedAtLobby=stopped,
            recovery=snapshot,
            recoveryReentrySent=False,
        )
        if not stopped:
            run.safe_stop(
                FarmRunStopReason.RECOVERY_FAILED,
                detail="graceful technical exit did not validate",
            )
        return stopped
    if code != 0 or not _recovery_clean(snapshot):
        if (
            failed_recovery_map_fallback is not None
            and failed_recovery_map_fallback(snapshot)
        ):
            runtime.executor.arm_recovery_swap_pacing(
                "FAILED_RECOVERY_MAP_FALLBACK"
            )
            writer.event(
                "technical_recovery_fell_back_to_exact_map_reentry",
                recovery=snapshot,
                targetRestored=True,
            )
            return True
        run.safe_stop(FarmRunStopReason.RECOVERY_FAILED, exitCode=code)
        return False
    if not run.record_successful_recovery(snapshot.input_records):
        return False
    if run._control is not None:
        _persist_checkpoint(run, writer, finalized_status=None)
    assert snapshot.new_session is not None and snapshot.new_opening is not None
    if not run.accept_session(snapshot.new_session, recovered=True):
        return False
    if not run.accept_opening(
        _opening_from_recovery(snapshot.new_opening), recovered=True
    ):
        return False
    if not run.resume_recovered_gameplay(old_state_leak_free=True):
        return False
    runtime.executor.arm_recovery_swap_pacing("TECHNICAL_RECOVERY_HANDOFF")
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
    root = (args.artifacts or current_app_paths().farm_runs).resolve()
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


def _notify_run_observer(
    observer: Callable[[Any, str], None] | None,
    run: FarmRun,
    phase: str,
) -> None:
    if observer is None:
        return
    try:
        observer(run.snapshot(), phase)
    except Exception:
        # The UI/status projection is diagnostic.  It must never terminate or
        # mutate the accepted FarmRunner state machine.
        return


def _notify_combat_turn_progress(
    observer: Callable[[Any, str], None] | None,
    run: FarmRun,
    role: str,
    session: Any,
    turn_number: int,
    local_turns: int,
    boss_turns: int,
) -> None:
    """Publish a deduplicated turn already read by the combat controller."""

    if run.observe_combat_turn_counts(
        session=session,
        local_turns=local_turns,
        boss_turns=boss_turns,
    ):
        _notify_run_observer(
            observer,
            run,
            f"COMBAT_{role}_TURN_{turn_number}",
        )


def _run_live(
    args: Namespace,
    limits: FarmRunLimits,
    *,
    control_edges: FarmControlHotkeyEdges | None = None,
    observer: Callable[[Any, str], None] | None = None,
) -> int:
    gameplay_config = gameplay_config_from_args(args)
    gameplay_config.require_farm_policy()
    stage_b1 = bool(args.stage_b1_recovery_resume)
    stage_d5_b1 = bool(args.stage_d5_b1_terminal)
    stage_d5_b2 = bool(args.stage_d5_b2_soak)
    stage_d6_b1 = bool(args.stage_d6_b1_graceful)
    stage_d6_b2 = bool(args.stage_d6_b2_resume)
    stage_d6_b3 = bool(args.stage_d6_b3_soak)
    phase2e2 = bool(args.stage_e2_ui)
    phase2d5 = stage_d5_b1 or stage_d5_b2
    phase2d6 = stage_d6_b1 or stage_d6_b2 or stage_d6_b3
    controlled_run = phase2d6 or phase2e2
    target = FarmTarget(args.boss_id, args.boss_name)
    input_delivery_config = _source_selected_input_delivery_config(
        selected_mode=getattr(args, "input_delivery_mode", None)
    )

    resume_payload = None
    resume_decision = None
    if args.resume is not None:
        try:
            resume_payload, resume_decision = _resume_decision(
                args,
                limits,
                target,
                input_delivery_config,
            )
        except CheckpointError as exc:
            # Fail closed.  A bad checkpoint is never silently discarded.
            print(
                f"ERROR: {exc.reason}: {exc}",
                file=sys.stderr,
                flush=True,
            )
            return 1
        if not resume_decision.allowed:
            print(
                f"ERROR: {resume_decision.reason}: refusing to resume "
                f"{args.resume}; zero Windows input was sent.",
                file=sys.stderr,
                flush=True,
            )
            return 1

    control = GracefulStopController(timestamp=time.time()) if controlled_run else None
    run = FarmRun(
        target,
        limits=limits,
        control=control,
        resume=resume_decision,
        continuation_of=(
            resume_payload.farm_run_id if resume_payload is not None else None
        ),
        gameplay_config=gameplay_config,
        input_delivery_mode=input_delivery_config.mode,
    )
    root = (args.artifacts or current_app_paths().farm_runs).resolve()
    writer = FarmRunArtifactWriter.create(root, run.farm_run_id)
    memory = _ControllerMemorySampler()
    memory.sample()
    unexpected: dict[str, Any] | None = None
    stage_b1_proof: dict[str, Any] | None = None
    natural_technical_failure = False
    graceful_stop_observed = False
    emergency_stop_observed = False
    pinned_input_session: PinnedForegroundMouseSession | None = None
    entry_preflight_reroute_pending = False
    entry_preflight_reroute_attempt: int | None = None
    entry_preflight_reroute_count = 0
    _notify_run_observer(observer, run, "CREATED")

    if resume_decision is not None:
        interrupted_checkpoint = bool(
            resume_payload.finalized_status is None
            and resume_payload.stop_request_state == "RUNNING"
        )
        writer.event(
            "farm_run_resume_accepted",
            checkpoint=str(args.resume),
            continuationOf=resume_payload.farm_run_id,
            historicalCompleted=resume_decision.historical_counters.get(
                "completed_matches"
            ),
            remainingCompleted=resume_decision.remaining_completed,
            executableGameplayStateRestored=False,
            interruptedCheckpoint=interrupted_checkpoint,
            liveBossLobbyRequired=True,
        )

    try:
        with attach_target() as process:
            backend = NativeWin32Backend()
            binding = find_window_for_pid(process.pid, backend)
            executor = ForegroundClickExecutor(
                backend,
                input_mode=BoardInputMode(args.board_input_mode),
            )
            provider = MemoryBoardStateProvider(
                process,
                MemoryProviderConfig(
                    max_region_mib=args.max_region_mib,
                    chunk_mib=args.chunk_mib,
                    required_confirmations=2,
                    require_lobby_start=True,
                    # BASIC owns a high-cadence immutable dispatcher tap plus
                    # a bounded monitor fallback. Keep the provider off the
                    # competing heap path so callback capture stays live.
                    allow_ack_heap_scan=False,
                    enable_dot_audit=False,
                    ack_heap_region_mib=args.ack_heap_region_mib,
                    extended_fusion_ui_region_mib=max(args.max_region_mib, 16),
                    extended_card_ui_region_mib=max(args.max_region_mib, 16),
                ),
            )
            monitor = RuntimeSequenceMonitor(
                process,
                max_region_mib=max(args.max_region_mib, 16),
                chunk_mib=args.chunk_mib,
                full_rescan_interval=8,
            )
            hotkeys = HotkeyEdges()
            control_hotkeys = (
                _ContextualFarmHotkeys(
                    control_edges or FarmControlHotkeyEdges(), lambda: run
                )
                if controlled_run
                else None
            )
            if (
                input_delivery_config.mode
                is InputDeliveryMode.PINNED_FOREGROUND_LEASE_BETA
            ):
                exact_geometry = backend.client_geometry(binding.hwnd)
                if exact_geometry is None:
                    raise RuntimeError(
                        "pinned input delivery requires a valid non-minimized client"
                    )
                exact_binding = ExactWindowBinding(binding, exact_geometry)
                lease_backend = NativeForegroundLeaseBackend(backend)
                pinned_stop_latch = {"emergency": False}

                def pinned_stop_requested() -> bool:
                    return _pinned_input_stop_requested(
                        hotkeys,
                        control_hotkeys,
                        pinned_stop_latch,
                    )

                pinned_input_session = PinnedForegroundMouseSession(
                    config=input_delivery_config,
                    binding=exact_binding,
                    backend=lease_backend,
                    stop_requested=pinned_stop_requested,
                    event_sink=(
                        lambda event, payload: writer.event(event, **payload)
                    ),
                )
                pin_result = pinned_input_session.start()
                writer.event(
                    "pinned_input_session_started",
                    mode=input_delivery_config.mode.value,
                    result=pin_result,
                    exactBinding=exact_binding,
                    scope="FARM_RUN",
                )
                if not pin_result.pinned:
                    raise RuntimeError(pin_result.reason)
                executor = pinned_input_session.bind_executor(executor)
                writer.event(
                    "pinned_input_executor_bound",
                    backend=type(executor.backend).__name__,
                    cursorConfineAware=True,
                    scope="FARM_RUN",
                )
            writer.event(
                "farm_run_started",
                farmRunId=run.farm_run_id,
                continuationOf=run.continuation_of,
                resumed=bool(run.resumed),
                mode=(
                    "PHASE2D6_B1_GRACEFUL"
                    if stage_d6_b1
                    else (
                        "PHASE2D6_B2_RESUME"
                        if stage_d6_b2
                        else (
                                "PHASE2D6_B3_SOAK"
                                if stage_d6_b3
                                else (
                                    "PHASE2E2_UI_CONTROLLED"
                                    if phase2e2
                                    else (
                                        "PHASE2D5_B1_TERMINAL"
                                        if stage_d5_b1
                                        else (
                                            "PHASE2D5_B2_SOAK"
                                            if stage_d5_b2
                                            else (
                                                "STAGE_B1_TEST_ONLY"
                                                if stage_b1
                                                else "STAGE_B2_PRODUCTION"
                                            )
                                        )
                                    )
                                )
                        )
                    )
                ),
                target=target,
                limits=limits,
                boardInputMode=args.board_input_mode,
                inputDeliveryMode=input_delivery_config.mode.value,
                F6=("GRACEFUL_STOP" if controlled_run else "UNUSED"),
                F7="DISABLED",
                F8="ENTRY_CONFIRM",
                F9="EMERGENCY_STOP",
                infiniteFarmingMode=False,
            )
            initial = _wait_boss_lobby(
                process,
                provider,
                target,
                args.lobby_timeout,
                args.interval,
                hotkeys,
                control_hotkeys,
            )
            writer.event("initial_boss_lobby", result=initial)
            if args.stop_if_room_ejected and _outside_current_boss_room(initial):
                run.safe_stop(
                    FarmRunStopReason.ROOM_EJECTED,
                    detail=(
                        f"initial lobby branch={initial.lobby.branch}; "
                        "map target selection disabled"
                    ),
                )
                writer.event(
                    "current_room_only_stop",
                    stage="INITIAL_LOBBY",
                    branch=initial.lobby.branch,
                    mapTargetSelectionAttempted=False,
                )
            elif not initial.ready:
                initial_reason = (
                    FarmRunStopReason.EMERGENCY_STOP
                    if initial.reason == "F9_EMERGENCY_STOP"
                    else FarmRunStopReason.FARM_START_STATE_INVALID
                )
                run.safe_stop(initial_reason, detail=initial.reason)
            else:
                run.observe_initial_lobby(BossLobbyState.BOSS_LOBBY)
            if controlled_run:
                # Create the first durable checkpoint only after a fresh clean
                # boss lobby is proven. It contains history/config, never live
                # executable gameplay state.
                _persist_checkpoint(run, writer, finalized_status=None)
            _notify_run_observer(observer, run, "INITIAL_LOBBY")

            while process.is_running() and not run.stopped:
                _notify_run_observer(observer, run, "FARM_BOUNDARY")
                if control_hotkeys is not None:
                    # take() consumes every edge latched since the last farm
                    # boundary, including presses made during combat, the
                    # postmatch confirmation, or the return-to-lobby wait.
                    # Those inner loops only latch, so the current match always
                    # finishes normally; the stop takes effect at the entry
                    # gate below.
                    f6_count, f9_count = control_hotkeys.take()
                    presses = control_hotkeys.take_presses()
                    if f9_count:
                        emergency_stop_observed = True
                        if control is not None:
                            control.emergency_stop(timestamp=time.time())
                        writer.event("emergency_stop_requested", key="F9")
                        run.safe_stop(
                            FarmRunStopReason.EMERGENCY_STOP, detail="F9 during farm loop"
                        )
                        _persist_checkpoint(
                            run, writer, finalized_status="EMERGENCY_STOPPED"
                        )
                        continue
                    if f6_count:
                        # Attribute the stop to where the *first* press actually
                        # happened, not to where the farm loop got around to
                        # observing it.
                        first = presses[0] if presses else None
                        lifecycle = (
                            first["lifecycle"]
                            if first is not None
                            else ("BOSS_LOBBY" if run.current_session is None else "ACTIVE_COMBAT")
                        )
                        match_id = (
                            first["matchId"]
                            if first is not None
                            else (
                                run.current_session.match_id
                                if run.current_session is not None
                                else None
                            )
                        )
                        already_registered = any(
                            bool(press.get("registeredWithRun"))
                            for press in presses
                        )
                        accepted = already_registered or run.graceful_stop_request(
                            lifecycle=lifecycle,
                            match_id=match_id,
                        )
                        if accepted:
                            graceful_stop_observed = True
                            writer.event(
                                "graceful_stop_requested",
                                key="F6",
                                lifecycle=lifecycle,
                                matchId=match_id,
                                pressCount=f6_count,
                                presses=presses,
                                observedAtFarmState=run.state.value,
                                controlState=(
                                    control.state.value if control is not None else None
                                ),
                            )
                            print(
                                "F6 graceful stop accepted: finishing the current "
                                "match, then stopping at the boss lobby.  "
                                "No new match will be entered.",
                                flush=True,
                            )
                        if run.stopped:
                            _persist_checkpoint(
                                run, writer, finalized_status="STOPPED_GRACEFULLY"
                            )
                            continue

                if run.state is FarmRunState.RESOLVE_TARGET:
                    match_directory = writer.directory / "matches" / f"attempt_{run.match_attempts + 1:03d}"
                    if match_directory.exists():
                        if not entry_preflight_reroute_pending:
                            raise RuntimeError(
                                "match artifact directory already exists outside "
                                "a proven entry navigation reroute"
                            )
                    else:
                        match_directory.mkdir(parents=True, exist_ok=False)
                    entry_preflight_reroute_pending = False
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
                        control_hotkeys=control_hotkeys,
                        test_only_recovery=stage_b1,
                        pinned_input_session=pinned_input_session,
                    )
                    writer.event(
                        "match_entry_result",
                        attemptIndex=run.match_attempts,
                        opening=opening,
                        entry=entry_result,
                    )
                    _notify_run_observer(observer, run, "ENTRY_RETURNED")
                    if opening is None:
                        if _entry_postclick_room_ejection_probe_required(
                            entry_result
                        ):
                            returned = _wait_boss_lobby(
                                process,
                                provider,
                                target,
                                args.return_lobby_timeout,
                                args.interval,
                                hotkeys,
                                control_hotkeys,
                                transient_room_grace_seconds=min(
                                    20.0, args.return_lobby_timeout * 0.5
                                ),
                            )
                            (
                                exact_world_map,
                                detached_room_shell,
                                general_hub,
                            ) = _farm_room_ejection_sources(
                                returned,
                                target_boss_id=str(
                                    target.boss_id or ""
                                ).strip(),
                                current_session=provider.current_session_key,
                            )
                            writer.event(
                                "entry_timeout_room_ejection_probe",
                                attemptIndex=run.match_attempts + 1,
                                entry=entry_result,
                                result=returned,
                                exactWorldMap=exact_world_map,
                                detachedRoomShell=detached_room_shell,
                                generalHub=general_hub,
                                startInputsSent=int(
                                    entry_result.get("entryClicks") or 0
                                ),
                                gameplayInputsSent=int(
                                    entry_result.get("gameplayInputs") or 0
                                ),
                            )
                            if not (
                                exact_world_map
                                or detached_room_shell
                                or general_hub
                            ):
                                if not run.stopped:
                                    reason = (
                                        FarmRunStopReason.EMERGENCY_STOP
                                        if returned.reason == "F9_EMERGENCY_STOP"
                                        else FarmRunStopReason.ENTRY_TIMEOUT
                                    )
                                    run.safe_stop(
                                        reason,
                                        entry=entry_result,
                                        roomEjectionProbe=returned,
                                    )
                                continue
                            if not run.observe_entry_room_ejection(
                                target_boss_id=str(
                                    target.boss_id or ""
                                ).strip(),
                                exact_world_map=exact_world_map,
                                detached_room_shell=detached_room_shell,
                                general_hub=general_hub,
                                no_combat_owner=(
                                    provider.current_session_key is None
                                ),
                            ):
                                if not run.stopped:
                                    run.safe_stop(
                                        FarmRunStopReason.ENTRY_TIMEOUT,
                                        entry=entry_result,
                                        detail=(
                                            "post-Start room ejection state "
                                            "transition rejected"
                                        ),
                                    )
                                continue
                            restored = _restore_ejected_farm_room(
                                run=run,
                                args=args,
                                process=process,
                                provider=provider,
                                target=target,
                                initial=returned,
                                binding=binding,
                                executor=executor,
                                directory=match_directory,
                                hotkeys=hotkeys,
                                control_hotkeys=control_hotkeys,
                                writer=writer,
                                pinned_input_session=pinned_input_session,
                            )
                            if restored:
                                # No match attempt was created, so the next
                                # bounded entry reuses attempt_NNN while
                                # _run_entry preserves the first entry proof
                                # in its existing artifact directory.
                                entry_preflight_reroute_pending = bool(
                                    not run.stopped
                                    and run.state is FarmRunState.RESOLVE_TARGET
                                )
                                memory.sample()
                                _notify_run_observer(
                                    observer,
                                    run,
                                    "ENTRY_TIMEOUT_MAP_REENTRY_COMPLETE",
                                )
                                if controlled_run:
                                    _persist_checkpoint(
                                        run, writer, finalized_status=None
                                    )
                            elif not run.stopped:
                                run.safe_stop(
                                    FarmRunStopReason.RECOVERY_FAILED,
                                    detail=(
                                        "post-Start room ejection did not "
                                        "restore exact pet room"
                                    ),
                                )
                            continue
                        if _entry_preflight_runtime_changed_before_start(
                            entry_result
                        ):
                            pending_attempt = run.match_attempts + 1
                            if entry_preflight_reroute_attempt != pending_attempt:
                                entry_preflight_reroute_attempt = pending_attempt
                                entry_preflight_reroute_count = 0
                            entry_preflight_reroute_count += 1
                            if (
                                entry_preflight_reroute_count > 3
                                or not controlled_run
                                or args.stop_if_room_ejected
                                or not run.observe_entry_preflight_runtime_changed()
                            ):
                                if not run.stopped:
                                    run.safe_stop(
                                        FarmRunStopReason.OPENING_INVARIANT_FAILED,
                                        entry=entry_result,
                                    )
                                continue
                            writer.event(
                                "entry_preflight_navigation_reroute",
                                attemptIndex=run.match_attempts + 1,
                                entryInputSent=False,
                                reason=entry_result.get("stopReason"),
                            )
                            returned = _wait_boss_lobby(
                                process,
                                provider,
                                target,
                                args.return_lobby_timeout,
                                args.interval,
                                hotkeys,
                                control_hotkeys,
                                transient_room_grace_seconds=min(
                                    45.0, args.return_lobby_timeout * 0.75
                                ),
                            )
                            writer.event(
                                "entry_preflight_reroute_observation",
                                attemptIndex=run.match_attempts + 1,
                                result=returned,
                            )
                            if (
                                not returned.ready
                                and returned.reason
                                in {
                                    "TARGET_MISSING",
                                    "CHINH_PHUC_MAP_CANDIDATE",
                                    "DETACHED_ROOM_SHELL_CANDIDATE",
                                }
                            ):
                                map_return = _return_from_chinh_phuc_map(
                                    run=run,
                                    process=process,
                                    provider=provider,
                                    target=target,
                                    initial=returned,
                                    binding=binding,
                                    executor=executor,
                                    directory=match_directory,
                                    interval=args.interval,
                                    timeout=args.return_lobby_timeout,
                                    hotkeys=hotkeys,
                                    control_hotkeys=control_hotkeys,
                                    pinned_input_session=pinned_input_session,
                                    max_region_mib=args.max_region_mib,
                                    chunk_mib=args.chunk_mib,
                                )
                                writer.event(
                                    "entry_preflight_map_return",
                                    attemptIndex=run.match_attempts + 1,
                                    initial=returned,
                                    result=map_return,
                                )
                                if map_return is not None:
                                    returned = map_return
                            if not returned.ready:
                                if not run.stopped:
                                    reason = (
                                        FarmRunStopReason.EMERGENCY_STOP
                                        if returned.reason == "F9_EMERGENCY_STOP"
                                        else FarmRunStopReason.RETURN_LOBBY_TIMEOUT
                                    )
                                    run.safe_stop(reason, detail=returned.reason)
                                continue
                            run.observe_return_lobby(BossLobbyState.BOSS_LOBBY)
                            entry_preflight_reroute_pending = bool(
                                not run.stopped
                                and run.state is FarmRunState.RESOLVE_TARGET
                            )
                            memory.sample()
                            _notify_run_observer(
                                observer,
                                run,
                                "ENTRY_PREFLIGHT_REROUTED_TO_BOSS_LOBBY",
                            )
                            if controlled_run:
                                _persist_checkpoint(
                                    run, writer, finalized_status=None
                                )
                            continue
                        if (
                            run.state is FarmRunState.RECOVERY_PENDING
                            and entry_result is not None
                            and entry_result.get("stopReason")
                            == "ENTRY_OPENING_TIMEOUT_ACTIVE_COMBAT"
                        ):
                            raw = entry_result.get(
                                "activeCombatTimeoutEvidence"
                            ) or {}
                            raw_session = raw.get("session") or {}
                            try:
                                failed_session = CombatSessionKey(
                                    int(raw_session["lifecycle_epoch"]),
                                    int(raw_session["board_instance"]),
                                    str(raw_session["match_id"]),
                                )
                            except (KeyError, TypeError, ValueError):
                                failed_session = None
                            coordinator = TechnicalRecoveryCoordinator(
                                max_technical_recoveries=1
                            )
                            dispatcher = TechnicalRecoveryDispatcher(coordinator)
                            dispatched = bool(
                                failed_session is not None
                                and dispatcher.dispatch_entry_opening_timeout_active_combat(
                                    session_key=failed_session,
                                    match_id=str(raw.get("matchId") or ""),
                                    provider_session=provider.current_session_key,
                                    entry_clicks=int(
                                        entry_result.get("entryClicks") or 0
                                    ),
                                    gameplay_inputs=int(
                                        entry_result.get("gameplayInputs") or 0
                                    ),
                                    published_turn=int(raw.get("turn") or 0),
                                    first_local_turn=(
                                        raw.get("firstLocalTurn") is True
                                    ),
                                    local_move_sequence=raw.get(
                                        "localMoveSequence"
                                    ),
                                    srv_seq=int(raw.get("srvSeq") or 0),
                                    board_hash=str(raw.get("boardHash") or ""),
                                    board_source=str(raw.get("boardSource") or ""),
                                )
                            )
                            writer.event(
                                "entry_opening_timeout_recovery_dispatch",
                                dispatched=dispatched,
                                entry=entry_result,
                                providerSession=provider.current_session_key,
                            )
                            if not dispatched or failed_session is None:
                                run.safe_stop(
                                    FarmRunStopReason.RECOVERY_FAILED,
                                    detail=(
                                        "entry opening-timeout recovery evidence "
                                        "did not revalidate"
                                    ),
                                )
                                continue
                            failure_poll = provider.poll()
                            runtime = basic_auto_bot.SharedCombatRuntime(
                                process,
                                provider,
                                monitor,
                                binding,
                                executor,
                                backend,
                                failed_session,
                                FarmRunGameplayCapability(
                                    run, failed_session, control_hotkeys
                                ),
                                dispatcher,
                                control_hotkeys,
                                require_attack_card=(
                                    requires_attack_card_preparation(
                                        run.snapshot().gameplay_config
                                    )
                                ),
                                input_delivery_config=input_delivery_config,
                                pinned_input_session=pinned_input_session,
                            )
                            _run_recovery(
                                run=run,
                                args=args,
                                runtime=runtime,
                                coordinator=coordinator,
                                failure_state=failure_poll.state,
                                writer=writer,
                                test_only=False,
                            )
                        continue

                if run.state is not FarmRunState.COMBAT_ACTIVE or run.current_session is None:
                    if not run.stopped:
                        run.safe_stop(
                            FarmRunStopReason.INTERNAL_INVARIANT,
                            observedState=run.state.value,
                        )
                    continue

                session = run.current_session
                attempt_index = run.match_attempts
                match_directory = writer.directory / "matches" / f"attempt_{attempt_index:03d}"
                match_directory.mkdir(parents=True, exist_ok=True)
                if controlled_run:
                    _print_farm_status(run, lifecycle="ACTIVE_COMBAT")

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
                    FarmRunGameplayCapability(run, session, control_hotkeys),
                    # Recovery is mandatory for every independently proven
                    # technical incident. The coordinator remains one-shot for
                    # this combat, so always exposing it cannot duplicate an
                    # Exit/Confirm/re-entry sequence.
                    dispatcher,
                    control_hotkeys,
                    turn_progress_observer=(
                        lambda role, observed_session, turn_number,
                        local_turns, boss_turns: _notify_combat_turn_progress(
                            observer,
                            run,
                            role,
                            observed_session,
                            turn_number,
                            local_turns,
                            boss_turns,
                        )
                    ),
                    require_attack_card=requires_attack_card_preparation(
                        run.snapshot().gameplay_config
                    ),
                    input_delivery_config=input_delivery_config,
                    pinned_input_session=pinned_input_session,
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
                        FarmRunGameplayCapability(run, session, control_hotkeys),
                        None,
                        control_hotkeys,
                        turn_progress_observer=(
                            lambda role, observed_session, turn_number,
                            local_turns, boss_turns: _notify_combat_turn_progress(
                                observer,
                                run,
                                role,
                                observed_session,
                                turn_number,
                                local_turns,
                                boss_turns,
                            )
                        ),
                        require_attack_card=requires_attack_card_preparation(
                            run.snapshot().gameplay_config
                        ),
                        input_delivery_config=input_delivery_config,
                        pinned_input_session=pinned_input_session,
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
                _notify_run_observer(observer, run, "COMBAT_RETURNED")

                if coordinator.trigger is not None:
                    reason = _technical_reason(coordinator)
                    if reason is None:
                        run.safe_stop(FarmRunStopReason.RECOVERY_FAILED, detail="production reason missing")
                        continue
                    natural_technical_failure = True
                    failure_state = provider.poll().state
                    if not run.technical_failure(reason):
                        continue
                    if controlled_run:
                        _persist_checkpoint(run, writer, finalized_status=None)

                    def failed_recovery_map_fallback(
                        recovery_snapshot: Any,
                    ) -> bool:
                        if not _failed_recovery_fallback_allowed(
                            recovery_snapshot
                        ):
                            writer.event(
                                "technical_recovery_fallback_blocked",
                                attemptIndex=attempt_index,
                                reason=recovery_snapshot.result_detail,
                                recoveryReentrySent=False,
                                failClosed=True,
                            )
                            return False
                        ejected = _wait_boss_lobby(
                            process,
                            provider,
                            target,
                            args.return_lobby_timeout,
                            args.interval,
                            hotkeys,
                            control_hotkeys,
                            transient_room_grace_seconds=min(
                                20.0, args.return_lobby_timeout * 0.5
                            ),
                        )
                        exact_target_room = _exact_target_room_restored(
                            ejected,
                            current_session=provider.current_session_key,
                        )
                        exact_world_map, detached_room_shell, general_hub = (
                            _farm_room_ejection_sources(
                                ejected,
                                target_boss_id=str(
                                    target.boss_id or ""
                                ).strip(),
                                current_session=provider.current_session_key,
                            )
                        )
                        writer.event(
                            "technical_recovery_room_ejection_probe",
                            attemptIndex=attempt_index,
                            result=ejected,
                            exactTargetRoom=exact_target_room,
                            exactWorldMap=exact_world_map,
                            detachedRoomShell=detached_room_shell,
                            generalHub=general_hub,
                        )
                        if exact_target_room:
                            if not run.prepare_failed_recovery_map_fallback(
                                tuple(recovery_snapshot.input_records)
                            ):
                                return False
                            if not run.complete_failed_recovery_room_fallback(
                                target_boss_id=str(target.boss_id or "").strip(),
                                exact_target_room=True,
                                no_combat_owner=True,
                            ):
                                return False
                            restored = run.observe_return_lobby(
                                BossLobbyState.BOSS_LOBBY
                            )
                            writer.event(
                                "technical_recovery_fell_back_to_exact_room",
                                attemptIndex=attempt_index,
                                targetBossId=str(target.boss_id or "").strip(),
                                restored=restored,
                                oldCombatStateReused=False,
                            )
                            return restored
                        if (
                            not exact_world_map
                            and not detached_room_shell
                            and not general_hub
                        ):
                            return False
                        restored = _restore_ejected_farm_room(
                            run=run,
                            args=args,
                            process=process,
                            provider=provider,
                            target=target,
                            initial=ejected,
                            binding=binding,
                            executor=executor,
                            directory=match_directory,
                            hotkeys=hotkeys,
                            control_hotkeys=control_hotkeys,
                            writer=writer,
                            recovery_records=tuple(
                                recovery_snapshot.input_records
                            ),
                            pinned_input_session=pinned_input_session,
                        )
                        if restored:
                            memory.sample()
                            _notify_run_observer(
                                observer,
                                run,
                                "EJECTED_MAP_REENTRY_COMPLETE",
                            )
                            if controlled_run:
                                _persist_checkpoint(
                                    run,
                                    writer,
                                    finalized_status=(
                                        "STOPPED_GRACEFULLY"
                                        if run.stop_reason
                                        is FarmRunStopReason.STOPPED_GRACEFULLY
                                        else None
                                    ),
                                )
                        return restored

                    _run_recovery(
                        run=run,
                        args=args,
                        runtime=runtime,
                        coordinator=coordinator,
                        failure_state=failure_state,
                        writer=writer,
                        test_only=False,
                        failed_recovery_map_fallback=(
                            failed_recovery_map_fallback
                        ),
                    )
                    continue

                if not combat_ok:
                    if combat_reason == "EMERGENCY_STOP":
                        emergency_stop_observed = True
                        if control is not None:
                            control.emergency_stop(timestamp=time.time())
                        run.safe_stop(
                            FarmRunStopReason.EMERGENCY_STOP,
                            detail="F9 during combat controller",
                        )
                    elif (
                        controlled_run
                        and combat_reason == "COMBAT_TERMINAL_UNPROVEN"
                    ):
                        # An evidence-free terminal is never counted as a
                        # completed match.  It may, however, be an exact room
                        # ejection. Prove the world-boss map with no combat
                        # owner before using the immutable farm-session pet ID.
                        ejected = _wait_boss_lobby(
                            process,
                            provider,
                            target,
                            args.return_lobby_timeout,
                            args.interval,
                            hotkeys,
                            control_hotkeys,
                            transient_room_grace_seconds=min(
                                20.0, args.return_lobby_timeout * 0.5
                            ),
                        )
                        exact_world_map, detached_room_shell, general_hub = (
                            _farm_room_ejection_sources(
                                ejected,
                                target_boss_id=str(
                                    target.boss_id or ""
                                ).strip(),
                                current_session=provider.current_session_key,
                            )
                        )
                        writer.event(
                            "combat_room_ejection_probe",
                            attemptIndex=attempt_index,
                            combatReason=combat_reason,
                            result=ejected,
                            exactWorldMap=exact_world_map,
                            detachedRoomShell=detached_room_shell,
                            generalHub=general_hub,
                            completedMatchCounted=False,
                        )
                        if (
                            not exact_world_map
                            and not detached_room_shell
                            and not general_hub
                        ):
                            run.safe_stop(
                                FarmRunStopReason.COMBAT_SAFE_STOP,
                                detail=combat_reason,
                            )
                            continue
                        restored = _restore_ejected_farm_room(
                            run=run,
                            args=args,
                            process=process,
                            provider=provider,
                            target=target,
                            initial=ejected,
                            binding=binding,
                            executor=executor,
                            directory=match_directory,
                            hotkeys=hotkeys,
                            control_hotkeys=control_hotkeys,
                            writer=writer,
                            pinned_input_session=pinned_input_session,
                        )
                        if not restored:
                            if not run.stopped:
                                run.safe_stop(
                                    FarmRunStopReason.RECOVERY_FAILED,
                                    detail="exact pet room recovery rejected",
                                )
                            continue
                        memory.sample()
                        _notify_run_observer(
                            observer, run, "EJECTED_MAP_REENTRY_COMPLETE"
                        )
                        if controlled_run:
                            _persist_checkpoint(
                                run,
                                writer,
                                finalized_status=(
                                    "STOPPED_GRACEFULLY"
                                    if run.stop_reason
                                    is FarmRunStopReason.STOPPED_GRACEFULLY
                                    else None
                                ),
                            )
                    elif combat_reason in {"REJECTED_SEQUENCE_DESYNC", "DEAD_BOARD_NO_REFRESH"}:
                        reason = (
                            "SEQUENCE_DESYNC"
                            if combat_reason == "REJECTED_SEQUENCE_DESYNC"
                            else combat_reason
                        )
                        run.technical_failure(reason)
                        if controlled_run:
                            _persist_checkpoint(run, writer, finalized_status=None)
                    else:
                        run.safe_stop(FarmRunStopReason.COMBAT_SAFE_STOP, detail=combat_reason)
                    continue

                terminal_snapshot = _terminal_snapshot_from_summary(summary, session)
                writer.event(
                    "terminal_result_captured",
                    attemptIndex=attempt_index,
                    terminalCombatSnapshot=terminal_snapshot,
                    persistedBeforeFarmAccounting=True,
                )
                if (
                    not run.normal_combat_ended(terminal_snapshot)
                    or not run.observe_postmatch()
                ):
                    continue
                if controlled_run:
                    # Persist terminal classification/accounting before
                    # postmatch ownership and UI cleanup.
                    _persist_checkpoint(run, writer, finalized_status=None)
                # Publish the counted result immediately.  Re-entry can take
                # a bounded recovery path (or fail closed), so waiting until
                # RETURNED_BOSS_LOBBY would leave the desktop showing the
                # preceding in-combat 0/N snapshot despite a durable 1/N
                # checkpoint.
                _notify_run_observer(observer, run, "MATCH_ACCOUNTED")
                postmatch_ready = True
                if combat_reason == "POSTMATCH_RESULT_UI_REQUIRED":
                    postmatch_ready, ui_result, ui_text = _confirm_postmatch(
                        run=run,
                        process=process,
                        provider=provider,
                        binding=binding,
                        executor=executor,
                        directory=match_directory,
                        interval=args.interval,
                        ui_timeout=args.postmatch_ui_timeout,
                        hotkeys=hotkeys,
                        control_hotkeys=control_hotkeys,
                        pinned_input_session=pinned_input_session,
                    )
                    writer.event(
                        "postmatch_ui_audit",
                        attemptIndex=attempt_index,
                        memoryResult=terminal_snapshot.result,
                        uiResult=ui_result,
                        uiText=ui_text,
                        consistency=(
                            run.attempts[-1].result_consistency
                            if run.attempts
                            else None
                        ),
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
                    control_hotkeys,
                    transient_room_grace_seconds=(
                        min(45.0, args.return_lobby_timeout * 0.75)
                        if controlled_run
                        else 0.0
                    ),
                )
                writer.event("normal_return_boss_lobby", attemptIndex=attempt_index, result=returned)
                if (
                    args.stop_if_room_ejected
                    and _outside_current_boss_room(returned)
                ):
                    run.safe_stop(
                        FarmRunStopReason.ROOM_EJECTED,
                        detail=(
                            f"return lobby branch={returned.lobby.branch}; "
                            "map target selection disabled"
                        ),
                    )
                    writer.event(
                        "current_room_only_stop",
                        stage="RETURN_LOBBY",
                        attemptIndex=attempt_index,
                        branch=returned.lobby.branch,
                        mapTargetSelectionAttempted=False,
                    )
                    continue
                reentry_reasons = {
                    "TARGET_MISSING",
                    "CHINH_PHUC_MAP_CANDIDATE",
                    "DETACHED_ROOM_SHELL_CANDIDATE",
                }
                # One server failure mode accepts the exact target click but
                # creates an owner-free room shell.  Route that shell once,
                # then reselect the same immutable target.  Two bounded route
                # passes cover map->shell->map without permitting an open
                # retry loop or a third target selection.
                for reentry_pass in range(1, 3):
                    if not (
                        controlled_run
                        and not args.stop_if_room_ejected
                        and not returned.ready
                        and returned.reason in reentry_reasons
                        and not run.stopped
                    ):
                        break
                    map_return = _return_from_chinh_phuc_map(
                        run=run,
                        process=process,
                        provider=provider,
                        target=target,
                        initial=returned,
                        binding=binding,
                        executor=executor,
                        directory=match_directory,
                        interval=args.interval,
                        timeout=args.return_lobby_timeout,
                        hotkeys=hotkeys,
                        control_hotkeys=control_hotkeys,
                        pinned_input_session=pinned_input_session,
                        max_region_mib=args.max_region_mib,
                        chunk_mib=args.chunk_mib,
                    )
                    writer.event(
                        "chinh_phuc_map_return",
                        attemptIndex=attempt_index,
                        reentryPass=reentry_pass,
                        initial=returned,
                        result=map_return,
                    )
                    if map_return is None:
                        break
                    returned = map_return
                if not returned.ready:
                    if run.stopped:
                        continue
                    reason = (
                        FarmRunStopReason.EMERGENCY_STOP
                        if returned.reason == "F9_EMERGENCY_STOP"
                        else FarmRunStopReason.RETURN_LOBBY_TIMEOUT
                    )
                    run.safe_stop(reason, detail=returned.reason)
                    continue
                run.observe_return_lobby(BossLobbyState.BOSS_LOBBY)
                memory.sample()
                _notify_run_observer(observer, run, "RETURNED_BOSS_LOBBY")
                if controlled_run:
                    # Checkpoint at the safest possible boundary: a clean boss
                    # lobby with no combat owner and no pending input.
                    finalized = None
                    if run.stopped:
                        finalized = (
                            "COMPLETED"
                            if run.stop_reason is FarmRunStopReason.FARM_TARGET_COMPLETED
                            else (
                                "STOPPED_GRACEFULLY"
                                if run.stop_reason
                                is FarmRunStopReason.STOPPED_GRACEFULLY
                                else None
                            )
                        )
                    _persist_checkpoint(run, writer, finalized_status=finalized)
                if controlled_run:
                    _print_farm_status(run, lifecycle="BOSS_LOBBY")

            if not process.is_running() and not run.stopped:
                run.safe_stop(FarmRunStopReason.COMBAT_SAFE_STOP, detail="target process exited")
    except KeyboardInterrupt:
        run.safe_stop(FarmRunStopReason.EMERGENCY_STOP, detail="KeyboardInterrupt")
    except ProcessProbeError as exc:
        # Environment precondition, not a controller logic fault.  Reporting
        # this as INTERNAL_INVARIANT misleads the operator into debugging the
        # tool when the real fix is "start the game / attach to it".
        run.safe_stop(
            FarmRunStopReason.FARM_START_STATE_INVALID,
            exceptionType=type(exc).__name__,
            detail=str(exc),
        )
        unexpected = {
            "type": type(exc).__name__,
            "message": str(exc),
            "traceback": traceback.format_exc(),
        }
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
    finally:
        if pinned_input_session is not None:
            try:
                unpin_result = pinned_input_session.close()
                writer.event(
                    "pinned_input_session_closed",
                    result=unpin_result,
                    scope="FARM_RUN",
                )
            except Exception as exc:  # noqa: BLE001 - cleanup must not hide run result
                writer.event(
                    "pinned_input_session_close_failed",
                    error=str(exc),
                    scope="FARM_RUN",
                )

    if run.stop_reason is FarmRunStopReason.EMERGENCY_STOP:
        emergency_stop_observed = True
        if control is not None and control.state is not FarmControlState.EMERGENCY_STOPPED:
            control.emergency_stop(timestamp=time.time())
    if control_hotkeys is not None and control_hotkeys.total_f6_edges > 0:
        graceful_stop_observed = True
    snapshot = run.snapshot()
    _notify_run_observer(observer, run, "FINISHING")
    memory.sample()
    safety_ok = snapshot.safety.nonzero() == {}
    final_lifecycle = (
        "BOSS_LOBBY"
        if snapshot.state is FarmRunState.FARM_RUN_COMPLETE
        and snapshot.stop_reason
        in {
            FarmRunStopReason.FARM_TARGET_COMPLETED,
            FarmRunStopReason.STOPPED_GRACEFULLY,
        }
        else "UNKNOWN"
    )
    entry_inputs_after_stop = 0
    if controlled_run:
        # GRACEFUL_STOP_NO_NEW_ENTRY_PROVEN: count BOSS_ENTRY inputs that were
        # actually sent after the stop request timestamp.  Must be zero.
        requested_at = snapshot.graceful_stop_requested_at
        if requested_at is not None:
            entry_inputs_after_stop = sum(
                1
                for record in snapshot.input_records
                if record.domain is FarmInputDomain.BOSS_ENTRY
                and record.sent
                and getattr(record, "timestamp", "") > requested_at
            )
    emergency_gate_ok = bool(
        control_edges is None
        or control_edges.authorized_operations_after_emergency_ack == 0
    )
    if phase2e2:
        if snapshot.stop_reason is FarmRunStopReason.EMERGENCY_STOP:
            accepted = bool(
                emergency_stop_observed
                and snapshot.state is FarmRunState.SAFE_STOP
                and emergency_gate_ok
                and safety_ok
            )
            invariant = (
                "PHASE2E2_UI_EMERGENCY_STOPPED" if accepted else "NOT_PROVEN"
            )
        elif snapshot.stop_reason is FarmRunStopReason.STOPPED_GRACEFULLY:
            accepted = bool(
                graceful_stop_observed
                and snapshot.state is FarmRunState.FARM_RUN_COMPLETE
                and snapshot.control_state is FarmControlState.STOPPED_AT_LOBBY
                and snapshot.completed_matches < limits.target_completed_matches
                and entry_inputs_after_stop == 0
                and snapshot.result_accounting_consistent
                and snapshot.attempt_accounting_consistent
                and snapshot.result_conflict_count == 0
                and final_lifecycle == "BOSS_LOBBY"
                and safety_ok
            )
            invariant = (
                "PHASE2E2_UI_GRACEFUL_STOPPED" if accepted else "NOT_PROVEN"
            )
        else:
            accepted = bool(
                snapshot.state is FarmRunState.FARM_RUN_COMPLETE
                and snapshot.stop_reason is FarmRunStopReason.FARM_TARGET_COMPLETED
                and snapshot.completed_matches == limits.target_completed_matches
                and snapshot.match_attempts <= limits.max_match_attempts
                and snapshot.unknown_results == 0
                and snapshot.result_conflict_count == 0
                and snapshot.result_accounting_consistent
                and snapshot.attempt_accounting_consistent
                and snapshot.memory_terminal_result_proven
                and final_lifecycle == "BOSS_LOBBY"
                and safety_ok
            )
            invariant = (
                "PHASE2E2_UI_BOUNDED_COMPLETED" if accepted else "NOT_PROVEN"
            )
    elif stage_d6_b1:
        accepted = bool(
            graceful_stop_observed
            and not emergency_stop_observed
            and snapshot.state is FarmRunState.FARM_RUN_COMPLETE
            and snapshot.stop_reason is FarmRunStopReason.STOPPED_GRACEFULLY
            and snapshot.control_state is FarmControlState.STOPPED_AT_LOBBY
            # The in-flight match was drained, not abandoned.
            and snapshot.completed_matches == 1
            # The stop happened strictly before the target would have ended it.
            and snapshot.completed_matches < limits.target_completed_matches
            and entry_inputs_after_stop == 0
            and snapshot.result_accounting_consistent
            and snapshot.attempt_accounting_consistent
            and snapshot.result_conflict_count == 0
            and len(snapshot.unique_match_ids) == snapshot.match_attempts
            and final_lifecycle == "BOSS_LOBBY"
            and safety_ok
        )
        invariant = "PHASE2D6_GRACEFUL_STOP_PROVEN" if accepted else "NOT_PROVEN"
    elif stage_d6_b2:
        if run.resumed:
            # Second invocation: must reach the shared target cumulatively.
            accepted = bool(
                snapshot.state is FarmRunState.FARM_RUN_COMPLETE
                and snapshot.stop_reason is FarmRunStopReason.FARM_TARGET_COMPLETED
                and snapshot.completed_matches == limits.target_completed_matches
                and snapshot.continuation_of is not None
                and snapshot.match_attempts <= limits.max_match_attempts
                and snapshot.unknown_results == 0
                and snapshot.result_conflict_count == 0
                and snapshot.result_accounting_consistent
                and snapshot.attempt_accounting_consistent
                and snapshot.memory_terminal_result_proven
                and len(snapshot.unique_match_ids) == snapshot.match_attempts
                and final_lifecycle == "BOSS_LOBBY"
                and safety_ok
            )
            invariant = (
                "PHASE2D6_CHECKPOINT_RESUME_PROVEN" if accepted else "NOT_PROVEN"
            )
        else:
            # First invocation: stop gracefully short of the target.
            accepted = bool(
                graceful_stop_observed
                and not emergency_stop_observed
                and snapshot.state is FarmRunState.FARM_RUN_COMPLETE
                and snapshot.stop_reason is FarmRunStopReason.STOPPED_GRACEFULLY
                and snapshot.completed_matches == 2
                and snapshot.unknown_results == 0
                and entry_inputs_after_stop == 0
                and snapshot.result_accounting_consistent
                and snapshot.attempt_accounting_consistent
                and snapshot.memory_terminal_result_proven
                and snapshot.result_conflict_count == 0
                and snapshot.control_state is FarmControlState.STOPPED_AT_LOBBY
                and len(snapshot.unique_match_ids) == snapshot.match_attempts
                and final_lifecycle == "BOSS_LOBBY"
                and safety_ok
            )
            invariant = (
                "PHASE2D6_CHECKPOINT_RUN_A_STOPPED" if accepted else "NOT_PROVEN"
            )
    elif stage_d6_b3:
        accepted = bool(
            snapshot.state is FarmRunState.FARM_RUN_COMPLETE
            and snapshot.stop_reason is FarmRunStopReason.FARM_TARGET_COMPLETED
            and snapshot.completed_matches == limits.target_completed_matches
            and snapshot.match_attempts <= limits.max_match_attempts
            and snapshot.unknown_results == 0
            and snapshot.result_conflict_count == 0
            and snapshot.result_accounting_consistent
            and snapshot.attempt_accounting_consistent
            and snapshot.memory_terminal_result_proven
            and len(snapshot.unique_match_ids) == snapshot.match_attempts
            and final_lifecycle == "BOSS_LOBBY"
            and safety_ok
        )
        invariant = "PHASE2D6_LONG_SOAK_PROVEN" if accepted else "NOT_PROVEN"
    elif stage_b1:
        accepted = bool(
            snapshot.state is FarmRunState.FARM_RUN_COMPLETE
            and snapshot.stop_reason is FarmRunStopReason.STAGE_B1_ACTION_ACCEPTED
            and snapshot.technical_recoveries == 1
            and safety_ok
        )
        invariant = "PHASE2D4_RECOVERY_RESUME_PROVEN" if accepted else "NOT_PROVEN"
    elif stage_d5_b1:
        accepted = bool(
            snapshot.state is FarmRunState.FARM_RUN_COMPLETE
            and snapshot.stop_reason is FarmRunStopReason.FARM_TARGET_COMPLETED
            and snapshot.completed_matches == 1
            and snapshot.wins + snapshot.losses == 1
            and snapshot.unknown_results == 0
            and snapshot.memory_terminal_result_proven
            and snapshot.result_consistent_count == 1
            and snapshot.result_conflict_count == 0
            and snapshot.result_accounting_consistent
            and snapshot.attempt_accounting_consistent
            and safety_ok
        )
        invariant = (
            "PHASE2D5_MEMORY_TERMINAL_RESULT_PROVEN"
            if accepted
            else "NOT_PROVEN"
        )
    elif stage_d5_b2:
        accepted = bool(
            snapshot.state is FarmRunState.FARM_RUN_COMPLETE
            and snapshot.stop_reason is FarmRunStopReason.FARM_TARGET_COMPLETED
            and snapshot.completed_matches == limits.target_completed_matches
            and snapshot.match_attempts <= limits.max_match_attempts
            and snapshot.unknown_results == 0
            and snapshot.result_conflict_count == 0
            and snapshot.result_accounting_consistent
            and snapshot.attempt_accounting_consistent
            and snapshot.memory_terminal_result_proven
            and safety_ok
        )
        invariant = (
            "PHASE2D5_EXTENDED_SOAK_PROVEN" if accepted else "NOT_PROVEN"
        )
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
    if controlled_run:
        final_status = (
            "COMPLETED"
            if snapshot.stop_reason is FarmRunStopReason.FARM_TARGET_COMPLETED
            else (
                "STOPPED_GRACEFULLY"
                if snapshot.stop_reason is FarmRunStopReason.STOPPED_GRACEFULLY
                else (
                    "EMERGENCY_STOPPED"
                    if snapshot.stop_reason is FarmRunStopReason.EMERGENCY_STOP
                    else "SAFE_STOP"
                )
            )
        )
        checkpoint_ok = _persist_checkpoint(
            run, writer, finalized_status=final_status
        )
        if not checkpoint_ok:
            accepted = False
            invariant = "NOT_PROVEN"
        snapshot = run.snapshot()
    artifact_size_before_finalization = _artifact_size_bytes(writer.directory)
    writer.finalize(
        run,
        stage=(
            "E2_UI"
            if phase2e2
            else (
                "D6_B1"
                if stage_d6_b1
                else (
                    "D6_B2"
                    if stage_d6_b2
                    else (
                        "D6_B3"
                        if stage_d6_b3
                        else (
                            "D5_B1"
                            if stage_d5_b1
                            else (
                                "D5_B2"
                                if stage_d5_b2
                                else ("B1" if stage_b1 else "B2")
                            )
                        )
                    )
                )
            )
        ),
        stageResult=("PASS" if accepted else "SAFE_STOP"),
        finalInvariant=invariant,
        stageB1Proof=stage_b1_proof,
        naturalTechnicalFailure=("OBSERVED" if natural_technical_failure else "NOT_OBSERVED"),
        gracefulStop={
            "hotkey": "F6",
            "observed": graceful_stop_observed,
            "requestedAt": snapshot.graceful_stop_requested_at,
            "controlState": (
                snapshot.control_state.value
                if snapshot.control_state is not None
                else None
            ),
            "bossEntryInputsAfterRequest": entry_inputs_after_stop,
            "emergencyStopUsed": emergency_stop_observed,
        },
        emergencyControl={
            "acknowledgedMonotonic": (
                control_edges.emergency_ack_monotonic
                if control_edges is not None
                else None
            ),
            "authorizedInputOperationsStarted": (
                control_edges.authorized_operations_started
                if control_edges is not None
                else None
            ),
            "authorizedInputOperationsAfterAcknowledgement": (
                control_edges.authorized_operations_after_emergency_ack
                if control_edges is not None
                else None
            ),
        },
        checkpoint={
            "path": (
                str(_checkpoint_path(writer.directory)) if controlled_run else None
            ),
            "sequence": snapshot.checkpoint_seq,
            "continuationOf": snapshot.continuation_of,
            "resumed": bool(run.resumed),
            "executableGameplayStatePersisted": False,
        },
        controllerMemory=memory.report(),
        artifactTelemetry={
            "bytesBeforeRunJsonFinalization": artifact_size_before_finalization,
            "measurement": "approximate; run.json and final console output not included",
        },
        finalLifecycle=final_lifecycle,
        infiniteFarmingMode=False,
        unexpectedError=unexpected,
    )
    if phase2e2:
        label = "Phase 2E.2"
        stage_label = "UI"
    elif phase2d6:
        label = "Phase 2D.6"
        stage_label = "B1" if stage_d6_b1 else ("B2" if stage_d6_b2 else "B3")
    elif phase2d5:
        label = "Phase 2D.5"
        stage_label = "B1" if stage_d5_b1 else "B2"
    else:
        label = "Phase 2D.4"
        stage_label = "B1" if stage_b1 else "B2"
    print(
        f"{label} {stage_label} "
        f"{'PASS' if accepted else 'STOPPED'} ({invariant}); "
        f"reason={snapshot.stop_reason.value if snapshot.stop_reason else None}; "
        f"completed={snapshot.completed_matches}/{limits.target_completed_matches}; "
        f"artifacts={writer.directory}",
        flush=True,
    )
    final_artifact_size = _artifact_size_bytes(writer.directory)
    completed_energy = tuple(
        (attempt.attempt_index, attempt.local_turns)
        for attempt in snapshot.attempts
        if attempt.end_timestamp is not None
        and attempt.result in {MatchResult.WIN, MatchResult.LOSS, MatchResult.UNKNOWN}
    )
    energy_text = ",".join(
        f"#{attempt_index}:{turns}"
        for attempt_index, turns in completed_energy
    ) or "none"
    print(
        "Summary: "
        f"attempts={snapshot.match_attempts}, completed={snapshot.completed_matches}, "
        f"W/L/U={snapshot.wins}/{snapshot.losses}/{snapshot.unknown_results}, "
        f"technicalAborts/recoveries={snapshot.technical_aborts}/"
        f"{snapshot.technical_recoveries}, SWAP={snapshot.total_swap_sent}/"
        f"{snapshot.total_swap_acknowledged}, CAST={snapshot.total_cast_sent}/"
        f"{snapshot.total_cast_accepted}, EVOLVE={snapshot.total_evolve_attempts}/"
        f"{snapshot.total_evolve_success}, PASS={snapshot.total_pass_count}, "
        f"turns/energy=[{energy_text}] totalEnergy="
        f"{sum(turns for _attempt_index, turns in completed_energy)}, "
        f"finalLifecycle={final_lifecycle}, duration={snapshot.duration_seconds}s, "
        f"artifactBytes~={final_artifact_size}",
        flush=True,
    )
    if (
        snapshot.stop_reason is FarmRunStopReason.FARM_START_STATE_INVALID
        and unexpected is not None
        and unexpected.get("type") == "ProcessProbeError"
    ):
        print(
            f"Hint: {unexpected['message']}.  Start PetPuzzle, bring it to the "
            "foreground at a clean BOSS LOBBY, then re-run.  No Windows input "
            "was sent.",
            flush=True,
        )
    if controlled_run:
        report = memory.report()
        if report.get("available"):
            print(
                "Controller working set: "
                f"start={report['startWorkingSetBytes'] // 1024} KiB, "
                f"peak={report['peakWorkingSetBytes'] // 1024} KiB, "
                f"end={report['endWorkingSetBytes'] // 1024} KiB "
                f"({report['interpretation']}).",
                flush=True,
            )
        if snapshot.stop_reason is FarmRunStopReason.STOPPED_GRACEFULLY:
            print(
                "To continue this run later:\n"
                f"  --resume {_checkpoint_path(writer.directory)}",
                flush=True,
            )
    _notify_run_observer(observer, run, "FINISHED")
    return 0 if accepted else 2


def _stage_d5_a_results() -> int:
    """Run the no-input terminal/accounting acceptance fixtures."""

    import unittest

    loader = unittest.TestLoader()
    suite = unittest.TestSuite()
    for pattern in ("test_terminal_result.py", "test_farm_run.py"):
        suite.addTests(
            loader.discover(str(PROJECT_ROOT / "tests"), pattern=pattern)
        )
    result = unittest.TextTestRunner(verbosity=2).run(suite)
    accepted = result.wasSuccessful()
    print(
        json.dumps(
            {
                "stage": "PHASE_2D5_STAGE_A_RESULT_FIDELITY",
                "accepted": accepted,
                "testsRun": result.testsRun,
                "failures": len(result.failures),
                "errors": len(result.errors),
                "actualWindowsInputs": 0,
            },
            ensure_ascii=False,
            indent=2,
        ),
        flush=True,
    )
    return 0 if accepted else 2


def _stage_d6_a_control() -> int:
    """Run the no-input graceful-stop / checkpoint acceptance fixtures."""

    import unittest

    loader = unittest.TestLoader()
    suite = unittest.TestSuite()
    for pattern in (
        "test_farm_checkpoint.py",
        "test_farm_run.py",
        "test_farm_run_cli_d6.py",
    ):
        suite.addTests(
            loader.discover(str(PROJECT_ROOT / "tests"), pattern=pattern)
        )
    result = unittest.TextTestRunner(verbosity=2).run(suite)
    accepted = result.wasSuccessful()
    print(
        json.dumps(
            {
                "stage": "PHASE_2D6_STAGE_A_CONTROL_AND_CHECKPOINT",
                "accepted": accepted,
                "testsRun": result.testsRun,
                "failures": len(result.failures),
                "errors": len(result.errors),
                "actualWindowsInputs": 0,
                "gracefulStopHotkey": "F6",
                "emergencyStopHotkey": "F9",
                "infiniteFarmingMode": False,
            },
            ensure_ascii=False,
            indent=2,
        ),
        flush=True,
    )
    return 0 if accepted else 2


def run(
    args: Namespace,
    *,
    control_edges: FarmControlHotkeyEdges | None = None,
    observer: Callable[[Any, str], None] | None = None,
) -> int:
    limits = _validate_args(args)
    if args.stage_d5_a_results:
        return _stage_d5_a_results()
    if args.stage_d6_a_control:
        return _stage_d6_a_control()
    return (
        _stage_a(args, limits)
        if args.stage_a_replay
        else _run_live(
            args,
            limits,
            control_edges=control_edges,
            observer=observer,
        )
    )


def main(argv: Sequence[str] | None = None) -> int:
    args = build_parser().parse_args(argv)
    try:
        with AutomationControllerLease(current_app_paths().controller_lock):
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
