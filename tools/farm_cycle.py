#!/usr/bin/env python3
"""Phase 2D.2 bounded two-entry/one-combat farm-cycle controller."""

from __future__ import annotations

import argparse
import json
import sys
import time
import traceback
from argparse import Namespace
from collections import Counter
from dataclasses import asdict, dataclass
from datetime import datetime
from pathlib import Path
from typing import Any, Sequence


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.app_paths import current_app_paths  # noqa: E402
from pokiguard_v2.boss_entry import (  # noqa: E402
    BossLobbyState,
    FarmTarget,
    TargetResolutionStatus,
    resolve_target,
)
from pokiguard_v2.boss_lobby_runtime import read_boss_lobby_runtime  # noqa: E402
from pokiguard_v2.controller_lease import AutomationControllerLease  # noqa: E402
from pokiguard_v2.combat_lifecycle import CombatLifecycleState  # noqa: E402
from pokiguard_v2.farm_cycle import (  # noqa: E402
    FarmCycle,
    FarmCycleState,
    FarmCycleStopReason,
    InputDomain,
    OpeningEvidence,
)
from pokiguard_v2.farm_cycle_runtime import (  # noqa: E402
    FarmEntryCapability,
    FarmGameplayCapability,
)
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
)
from pokiguard_v2.postmatch_ui import (  # noqa: E402
    locate_result_confirm,
    prove_stable_result_confirm,
)
from pokiguard_v2.state import GemType  # noqa: E402
from pokiguard_v2.win32_input import (  # noqa: E402
    ForegroundClickExecutor,
    HotkeyEdges,
    NativeWin32Backend,
    find_window_for_pid,
)
from pokiguard_v2.win32_screenshot import capture_client_rgb, write_png_rgb  # noqa: E402
from tools import basic_auto_bot, boss_entry  # noqa: E402
from tools.runtime_common import attach_target  # noqa: E402
from tools.sequence_desync_runtime import RuntimeSequenceMonitor  # noqa: E402


@dataclass(frozen=True)
class LobbyWaitResult:
    ready: bool
    state: BossLobbyState | None
    resolution_status: TargetResolutionStatus | None
    reason: str
    lobby: Any = None
    stable_frames: int = 0


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    mode = parser.add_mutually_exclusive_group(required=True)
    mode.add_argument("--read-only-smoke", action="store_true", help="stable boss-lobby inspection; inputs=0")
    mode.add_argument("--run-cycle", action="store_true", help="entry #1, B5 combat #1, entry #2, then stop")
    mode.add_argument(
        "--run-single-cycle",
        action="store_true",
        help="entry #1, B5 combat #1, return to boss lobby, then stop",
    )
    target = parser.add_mutually_exclusive_group(required=True)
    target.add_argument("--boss-id", help="exact runtime boss/enemy pet ID")
    target.add_argument("--boss-name", help="exact NFC/casefold boss name")
    parser.add_argument("--reset-evidence", type=Path, help="audited B5 reset evidence; required for --run-cycle")
    parser.add_argument("--artifacts", type=Path)
    parser.add_argument("--interval", type=float, default=0.12)
    parser.add_argument("--lobby-timeout", type=float, default=180.0)
    parser.add_argument("--entry-timeout", type=float, default=45.0)
    parser.add_argument("--opening-timeout", type=float, default=35.0)
    parser.add_argument(
        "--postmatch-ui-timeout",
        type=float,
        default=15.0,
        help="bounded wait for a stable terminal result modal",
    )
    parser.add_argument("--return-lobby-timeout", type=float, default=90.0)
    parser.add_argument("--combat-timeout", type=float, default=1800.0)
    parser.add_argument("--max-total-input-actions", type=int, default=100)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--ack-heap-region-mib", type=int, default=16)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument("--no-beep", action="store_true")
    return parser


def _jsonable(value: Any) -> Any:
    if hasattr(value, "__dataclass_fields__"):
        return _jsonable(asdict(value))
    if hasattr(value, "value"):
        return value.value
    if isinstance(value, Path):
        return str(value)
    if isinstance(value, (bytes, bytearray, memoryview)):
        return {"byteLength": len(value)}
    if isinstance(value, dict):
        return {str(key): _jsonable(item) for key, item in value.items()}
    if isinstance(value, (tuple, list, set)):
        return [_jsonable(item) for item in value]
    return value


def _write(log: Any, event: str, **fields: Any) -> None:
    log.write(
        json.dumps(
            {"timestamp": datetime.now().isoformat(), "event": event, **_jsonable(fields)},
            ensure_ascii=False,
        )
        + "\n"
    )
    log.flush()


def _validate_args(args: Namespace) -> None:
    if not 0.08 <= args.interval <= 0.50:
        raise ValueError("--interval must be between 0.08 and 0.50")
    for name in ("lobby_timeout", "entry_timeout", "opening_timeout"):
        if not 5 <= float(getattr(args, name)) <= 600:
            raise ValueError(f"--{name.replace('_', '-')} must be between 5 and 600 seconds")
    if not 3 <= float(args.postmatch_ui_timeout) <= 60:
        raise ValueError("--postmatch-ui-timeout must be between 3 and 60 seconds")
    for name in ("return_lobby_timeout", "combat_timeout"):
        if not 5 <= float(getattr(args, name)) <= 3600:
            raise ValueError(f"--{name.replace('_', '-')} must be between 5 and 3600 seconds")
    if not 50 <= args.max_total_input_actions <= 1000:
        raise ValueError("--max-total-input-actions must be between 50 and 1000")
    if not 1 <= args.max_region_mib <= 32 or not 1 <= args.chunk_mib <= 16:
        raise ValueError("scan size arguments are outside safe bounds")
    if not args.max_region_mib <= args.ack_heap_region_mib <= 32:
        raise ValueError("--ack-heap-region-mib must cover --max-region-mib and be <= 32")


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


def _resolve_pass_stage(args: Namespace) -> str:
    """Pick the combat PASS-acceptance stage for a farm-driven match.

    ``basic_auto_bot`` couples ``--pass-acceptance-stage`` and
    ``--reset-evidence``: DISABLED forbids reset evidence, and every
    P1/P2/P3/B3/B4/B5 stage requires it.  A farm run that was started with
    ``--reset-evidence`` must therefore hand its matches a real stage rather
    than the DISABLED default, or the combat leg raises and the farm run stops
    with FARM_RUN_INTERNAL_INVARIANT.

    An explicit ``pass_acceptance_stage`` on the caller always wins.  Otherwise
    a run carrying reset evidence selects the production acceptance profile
    that is compatible with its immutable gameplay policy:

    * ATTACK mana priority uses B4;
    * SIMPLE + EVOLUTION uses B5;
    * CAREFUL + EVOLUTION uses the unrestricted B3 profile.

    The stage labels select accepted PASS/reset-cycle telemetry; they do not
    replace the configured BASIC policy.  Keeping this mapping here prevents a
    UI-valid CAREFUL/ATTACK draft from entering combat and then failing inside
    ``basic_auto_bot._validate_args`` before its first gameplay action.
    """
    explicit = getattr(args, "pass_acceptance_stage", None)
    if explicit:
        return explicit
    if getattr(args, "reset_evidence", None) is None:
        return "DISABLED"
    if getattr(args, "mana_priority", "evolution") == "attack":
        return "B4"
    if getattr(args, "play_style", "simple") == "simple":
        return "B5"
    return "B3"


def _combat_args(args: Namespace, log_path: Path) -> Namespace:
    return Namespace(
        watch=True,
        play_style=getattr(args, "play_style", "simple"),
        mana_priority=getattr(args, "mana_priority", "evolution"),
        intelligence="basic",
        # Live-confirmed product rule: a displayed 1 second is still sendable.
        minimum_action_time=1,
        cast_when_boss_hp_below=getattr(args, "cast_when_boss_hp_below", 30_000),
        cast_mana_stockpile=getattr(args, "cast_mana_stockpile", 480),
        rage_target=getattr(args, "rage_target", 100),
        interval=args.interval,
        action_timeout=9.0,
        matches=1,
        max_actions=None,
        max_turn_actions=0,
        max_total_input_actions=args.max_total_input_actions,
        max_fusion_attempts_per_turn=2,
        v1_root=None,
        timeout=args.combat_timeout,
        postmatch_observation_timeout=min(args.return_lobby_timeout, 5.0),
        log=log_path,
        no_beep=args.no_beep,
        max_region_mib=args.max_region_mib,
        ack_heap_region_mib=args.ack_heap_region_mib,
        chunk_mib=args.chunk_mib,
        pass_acceptance_stage=_resolve_pass_stage(args),
        reset_evidence=getattr(args, "reset_evidence", None),
        acceptance_force_pass_after_actions=0,
    )


def _is_transient_chinh_phuc_room_rehydration(lobby: Any) -> bool:
    """Identify the post-result gap before ManagerRoom.roomData is rebuilt."""

    return bool(
        lobby.branch == "WORLD_BOSS_LIST"
        and lobby.chinh_phuc.current_room_type == "ChinhPhuc"
        and lobby.chinh_phuc.current_room_id is not None
        and (
            lobby.chinh_phuc.room_data is None
            # Live run 21 proved a second rehydration phase: RoomDTO and the
            # room id already exist, but ButtonStart remains non-interactable
            # for several frames while the exact room shell is loading.
            or (
                getattr(lobby.chinh_phuc, "button_start", None) is not None
                and getattr(
                    lobby.chinh_phuc, "button_interactable", None
                )
                is False
            )
        )
    )


def _is_detached_chinh_phuc_room_candidate(
    lobby: Any,
    *,
    target_pet_id: int | None,
    no_combat_owner: bool,
) -> bool:
    """Recognize the read-only half of a detached Chinh Phuc room shell.

    This is deliberately not sufficient to authorize a click.  The farming
    controller still requires an independently resolved exact pet Button and
    two stable visual frames before it may close the shell.  Surfacing this
    state here prevents ``_wait_boss_lobby`` from discarding the runtime
    snapshot as a generic ``LOBBY_OTHER`` timeout.
    """

    chinh = getattr(lobby, "chinh_phuc", None)
    lifecycle = getattr(
        getattr(lobby, "combat_lifecycle", None), "state", None
    )
    return bool(
        target_pet_id is not None
        and target_pet_id > 0
        and no_combat_owner
        and getattr(lobby, "state", None) is BossLobbyState.LOBBY_OTHER
        and getattr(lobby, "branch", None) is None
        and lifecycle
        in {
            CombatLifecycleState.LOBBY,
            CombatLifecycleState.STALE_SERVER_MATCH,
        }
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


def _wait_boss_lobby(
    process: Any,
    provider: MemoryBoardStateProvider,
    target: FarmTarget,
    timeout: float,
    interval: float,
    hotkeys: HotkeyEdges,
    control_hotkeys: Any = None,
    *,
    wait_through_target_missing: bool = False,
    transient_room_grace_seconds: float = 0.0,
) -> LobbyWaitResult:
    deadline = time.monotonic() + timeout
    stable_key = None
    stable_count = 0
    last_state: BossLobbyState | None = None
    transient_room_missing_since: float | None = None
    detached_shell_since: float | None = None
    detached_shell_key: tuple[Any, ...] | None = None
    detached_shell_count = 0
    try:
        target_pet_id = int(target.boss_id or "")
    except (TypeError, ValueError):
        target_pet_id = None
    while process.is_running() and time.monotonic() < deadline:
        external_f9 = False
        if control_hotkeys is not None:
            # Latch only.  A graceful stop must never cut this wait short: the
            # match has to finish returning to the lobby before the farm loop
            # consumes the latch and refuses the *next* entry.
            _graceful, external_f9 = control_hotkeys.poll()
        _f8_edge, f9_edge = hotkeys.poll()
        if f9_edge or external_f9:
            return LobbyWaitResult(False, last_state, None, "F9_EMERGENCY_STOP", stable_frames=stable_count)
        poll = provider.poll()
        if poll.combat_lifecycle is None:
            time.sleep(interval)
            continue
        lobby = read_boss_lobby_runtime(process.resolver, poll.combat_lifecycle)
        last_state = lobby.state
        if lobby.state is not BossLobbyState.BOSS_LOBBY:
            stable_key, stable_count = None, 0
            no_combat_owner = provider.current_session_key is None
            if _is_detached_chinh_phuc_room_candidate(
                lobby,
                target_pet_id=target_pet_id,
                no_combat_owner=no_combat_owner,
            ):
                candidate_key = (
                    lobby.chinh_phuc.room_data,
                    lobby.chinh_phuc.enemy_pet_id,
                    lobby.chinh_phuc.button_start,
                    lobby.chinh_phuc.button_native,
                )
                detached_shell_count = (
                    detached_shell_count + 1
                    if candidate_key == detached_shell_key
                    else 1
                )
                detached_shell_key = candidate_key
                now = time.monotonic()
                if detached_shell_since is None:
                    detached_shell_since = now
                grace_elapsed = (
                    transient_room_grace_seconds <= 0
                    or now - detached_shell_since
                    >= transient_room_grace_seconds
                )
                if detached_shell_count >= 2 and grace_elapsed:
                    return LobbyWaitResult(
                        False,
                        lobby.state,
                        None,
                        "DETACHED_ROOM_SHELL_CANDIDATE",
                        lobby,
                        detached_shell_count,
                    )
            else:
                detached_shell_since = None
                detached_shell_key = None
                detached_shell_count = 0
            time.sleep(interval)
            continue
        detached_shell_since = None
        detached_shell_key = None
        detached_shell_count = 0
        resolution = resolve_target(target, lobby.candidates)
        no_combat_owner = provider.current_session_key is None
        key = (
            lobby.branch,
            resolution.status.value,
            tuple(candidate.identity.stable_key() for candidate in lobby.candidates),
            no_combat_owner,
        )
        stable_count = stable_count + 1 if key == stable_key else 1
        stable_key = key
        if stable_count >= 2:
            if not no_combat_owner:
                time.sleep(interval)
                continue
            if lobby.branch != "CHINH_PHUC_ROOM":
                transient_room_rehydrating = (
                    _is_transient_chinh_phuc_room_rehydration(lobby)
                )
                if transient_room_rehydrating and transient_room_grace_seconds > 0:
                    now = time.monotonic()
                    if transient_room_missing_since is None:
                        transient_room_missing_since = now
                    if now - transient_room_missing_since < transient_room_grace_seconds:
                        time.sleep(interval)
                        continue
                if wait_through_target_missing:
                    time.sleep(interval)
                    continue
                return LobbyWaitResult(
                    False,
                    lobby.state,
                    resolution.status,
                    "TARGET_MISSING",
                    lobby,
                    stable_count,
                )
            if resolution.status is not TargetResolutionStatus.RESOLVED:
                transient_room_rehydrating = (
                    _is_transient_chinh_phuc_room_rehydration(lobby)
                )
                if transient_room_rehydrating and transient_room_grace_seconds > 0:
                    now = time.monotonic()
                    if transient_room_missing_since is None:
                        transient_room_missing_since = now
                    if now - transient_room_missing_since < transient_room_grace_seconds:
                        time.sleep(interval)
                        continue
                else:
                    transient_room_missing_since = None
                if wait_through_target_missing:
                    time.sleep(interval)
                    continue
                return LobbyWaitResult(False, lobby.state, resolution.status, resolution.status.value, lobby, stable_count)
            transient_room_missing_since = None
            if resolution.candidate is None or not resolution.candidate.available:
                return LobbyWaitResult(False, lobby.state, resolution.status, "TARGET_NOT_AVAILABLE", lobby, stable_count)
            return LobbyWaitResult(True, lobby.state, resolution.status, "BOSS_LOBBY_READY", lobby, stable_count)
        time.sleep(interval)
    reason = "TARGET_PROCESS_EXITED" if not process.is_running() else "BOSS_LOBBY_TIMEOUT"
    return LobbyWaitResult(False, last_state, None, reason, stable_frames=stable_count)


def _opening_from_provider(provider: MemoryBoardStateProvider) -> OpeningEvidence | None:
    poll = provider.poll()
    state = poll.state
    key = provider.current_session_key
    if key is None or state is None or state.battle.session_key != key:
        return None
    cells = tuple(cell for row in state.board.cells for cell in row)
    source = "ChatMessageDTO.MATCH_START.matchPayload.board"
    return OpeningEvidence(
        session=key,
        match_id=key.match_id,
        board_hash=state.battle.board_hash or "",
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


def _read_jsonl(path: Path) -> list[dict[str, Any]]:
    try:
        return [
            json.loads(line)
            for line in path.read_text(encoding="utf-8").splitlines()
            if line.strip()
        ]
    except (OSError, ValueError):
        return []


def _last_event(records: Sequence[dict[str, Any]], event: str) -> dict[str, Any] | None:
    return next((record for record in reversed(records) if record.get("event") == event), None)


def _validate_combat_summary(records: Sequence[dict[str, Any]]) -> tuple[bool, str, dict[str, Any] | None]:
    summary = _last_event(records, "auto_controller_summary")
    if summary is None:
        return False, "COMBAT_SUMMARY_MISSING", None
    if summary.get("stopReason") != "COMBAT_LIFECYCLE_ENDED":
        return False, str(summary.get("stopReason") or "COMBAT_STOP_REASON_MISSING"), summary
    if summary.get("attemptClassification") not in {"FULL_MATCH_PASS", "B5_PASS_STRONG"}:
        return False, f"COMBAT_CLASSIFICATION_{summary.get('attemptClassification')}", summary
    if summary.get("fullCombatResult") == "NOT_COMPLETED":
        return False, "COMBAT_RESULT_NOT_COMPLETED", summary
    terminal = summary.get("terminalCombatSnapshot")
    if summary.get("fullCombatResult") == "UNKNOWN":
        terminal = terminal if isinstance(terminal, dict) else {}
        evidence = terminal.get("evidence_sources")
        if not (
            terminal.get("captured_before_cleanup") is True
            and isinstance(evidence, (list, tuple))
            and bool(evidence)
        ):
            # A combat owner disappearing directly into a lobby/map is not a
            # completed UNKNOWN match. It has no terminal HP/event/UI proof
            # and must fail closed without advancing the completed counter.
            return False, "COMBAT_TERMINAL_UNPROVEN", summary
    if summary.get("sessionCleared") is not True or summary.get("activeSession") is not None:
        return False, "COMBAT_SESSION_NOT_CLEARED", summary
    if summary.get("pending") is not None:
        return False, "COMBAT_PENDING_ACTION_NOT_CLEARED", summary
    safety = summary.get("safetyTelemetry")
    if not isinstance(safety, dict) or any(int(value or 0) != 0 for value in safety.values()):
        return False, "COMBAT_SAFETY_COUNTER_NONZERO", summary
    postmatch = _last_event(records, "postmatch_observation_complete")
    if postmatch is not None and postmatch.get("automaticInputDisabled") is True:
        return True, "COMBAT_LIFECYCLE_ENDED", summary
    timeout = _last_event(records, "postmatch_observation_timeout")
    if (
        timeout is not None
        and timeout.get("automaticInputDisabled") is True
        and timeout.get("lifecycle") == CombatLifecycleState.POSTMATCH.value
    ):
        return True, "POSTMATCH_RESULT_UI_REQUIRED", summary
    return False, "POSTMATCH_NOT_AUTHORITATIVELY_OBSERVED", summary


def _confirm_postmatch_result(
    *,
    cycle: FarmCycle,
    process: Any,
    provider: MemoryBoardStateProvider,
    binding: Any,
    executor: ForegroundClickExecutor,
    artifacts: Path,
    interval: float,
    ui_timeout: float,
    hotkeys: HotkeyEdges,
    log: Any,
) -> bool:
    locations = []
    captures = []
    deadline = time.monotonic() + ui_timeout
    proof = prove_stable_result_confirm((), required_frames=3)
    sample_number = 0
    first_wait_frame_written = False
    last_location = None
    last_capture = None
    while process.is_running() and time.monotonic() < deadline:
        sample_number += 1
        _confirm, stop = hotkeys.poll()
        if stop:
            cycle.safe_stop(FarmCycleStopReason.EMERGENCY_STOP, detail="F9 during postmatch proof")
            return False
        poll = provider.poll()
        lifecycle = (
            poll.combat_lifecycle.state
            if poll.combat_lifecycle is not None
            else CombatLifecycleState.UNKNOWN
        )
        if lifecycle is not CombatLifecycleState.POSTMATCH:
            cycle.safe_stop(
                FarmCycleStopReason.POSTMATCH_UI_AMBIGUOUS,
                detail=f"postmatch lifecycle changed to {lifecycle.value}",
            )
            return False
        capture = capture_client_rgb(process.pid)
        last_capture = capture
        if not first_wait_frame_written:
            write_png_rgb(
                artifacts / "postmatch_wait_frame_first.png",
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
        _write(
            log,
            "postmatch_result_sample",
            sampleNumber=sample_number,
            lifecycle=lifecycle,
            location=last_location,
            proof=proof,
        )
        if proof.proven:
            break
        remaining = deadline - time.monotonic()
        if remaining > 0:
            time.sleep(min(max(interval, 0.25), remaining))

    _write(log, "postmatch_result_proof", proof=proof)
    if not proof.proven or proof.normalized_point is None:
        if last_capture is not None:
            write_png_rgb(
                artifacts / "postmatch_wait_frame_last.png",
                last_capture.width,
                last_capture.height,
                last_capture.rgb,
            )
        detail = (
            f"postmatch modal not stable within {ui_timeout:.1f}s; "
            f"samples={sample_number}; "
            f"last={getattr(last_location, 'reason', proof.reason)}"
        )
        cycle.safe_stop(FarmCycleStopReason.POSTMATCH_UI_AMBIGUOUS, detail=detail)
        return False

    for frame_number, capture in enumerate(captures[-3:], start=1):
        frame_path = artifacts / f"postmatch_result_frame_{frame_number}.png"
        write_png_rgb(frame_path, capture.width, capture.height, capture.rgb)

    final_poll = provider.poll()
    final_lifecycle = (
        final_poll.combat_lifecycle.state
        if final_poll.combat_lifecycle is not None
        else CombatLifecycleState.UNKNOWN
    )
    window = executor.window_status(binding)
    if final_lifecycle is not CombatLifecycleState.POSTMATCH:
        cycle.safe_stop(
            FarmCycleStopReason.POSTMATCH_UI_AMBIGUOUS,
            detail=f"postmatch lifecycle changed before click: {final_lifecycle.value}",
        )
        return False
    permit = cycle.reserve_postmatch_input(
        foreground=window.valid and window.foreground is True
    )
    if permit is None:
        return False
    result = executor.send_normalized_point(binding, proof.normalized_point)
    completed = cycle.complete_postmatch_input(
        permit,
        sent=result.sent,
        detail=f"RESULT_CONFIRM:{result.status.value}",
    )
    _write(
        log,
        "postmatch_result_input",
        lifecycle=final_lifecycle,
        proof=proof,
        clickResult=result,
        completed=completed,
    )
    return completed


def _map_stop_reason(reason: str, *, initial: bool = False) -> FarmCycleStopReason:
    mapping = {
        "TARGET_MISSING": FarmCycleStopReason.TARGET_MISSING,
        "TARGET_AMBIGUOUS": FarmCycleStopReason.TARGET_AMBIGUOUS,
        "TARGET_NOT_AVAILABLE": FarmCycleStopReason.TARGET_NOT_AVAILABLE,
        "F9_EMERGENCY_STOP": FarmCycleStopReason.EMERGENCY_STOP,
    }
    if reason in mapping:
        return mapping[reason]
    return FarmCycleStopReason.FARM_START_STATE_INVALID if initial else FarmCycleStopReason.STAGE_TIMEOUT


def _entry_stop_reason(reason: str) -> FarmCycleStopReason:
    if reason in {"TARGET_MISSING", "TARGET_AMBIGUOUS", "TARGET_NOT_AVAILABLE", "F9_EMERGENCY_STOP"}:
        return _map_stop_reason(reason)
    if "FOREGROUND" in reason:
        return FarmCycleStopReason.FOREGROUND_LOST
    if "TIMEOUT" in reason:
        return FarmCycleStopReason.STAGE_TIMEOUT
    return FarmCycleStopReason.OPENING_INVARIANT_FAILED


def _run_entry_once(
    *,
    cycle: FarmCycle,
    entry_number: int,
    args: Namespace,
    artifacts: Path,
    process: Any,
    provider: MemoryBoardStateProvider,
    monitor: RuntimeSequenceMonitor,
    binding: Any,
    executor: ForegroundClickExecutor,
    backend: NativeWin32Backend,
) -> tuple[OpeningEvidence | None, dict[str, Any] | None]:
    if not cycle.target_resolved(entry_number=entry_number):
        return None, None
    entry_dir = artifacts / f"entry{entry_number}"
    runtime = boss_entry.SharedEntryRuntime(
        process,
        provider,
        monitor,
        binding,
        executor,
        backend,
        FarmEntryCapability(cycle, entry_number),
    )
    boss_entry.run(_entry_args(args, entry_dir), shared_runtime=runtime)
    try:
        result = json.loads((entry_dir / "entry.json").read_text(encoding="utf-8"))
    except (OSError, ValueError):
        cycle.safe_stop(FarmCycleStopReason.OPENING_INVARIANT_FAILED, detail="entry summary missing")
        return None, None
    if result.get("status") != "PASS":
        if not cycle.stopped:
            cycle.safe_stop(
                _entry_stop_reason(str(result.get("stopReason") or "ENTRY_FAILED")),
                entryNumber=entry_number,
                entry=result,
            )
        return None, result
    opening = _opening_from_provider(provider)
    if opening is None:
        cycle.safe_stop(FarmCycleStopReason.NEW_SESSION_NOT_PROVEN_NEW, entryNumber=entry_number)
        return None, result
    if not opening.timer_safe:
        cycle.safe_stop(FarmCycleStopReason.OPENING_ACTION_DEADLINE, entryNumber=entry_number, opening=opening)
        return None, result
    if not cycle.accept_session(opening.session) or not cycle.accept_opening(opening):
        return None, result
    return opening, result


def _domain_counts(cycle: FarmCycle) -> dict[str, dict[str, int]]:
    records = cycle.snapshot().input_records
    reserved = Counter(record.domain.value for record in records)
    sent = Counter(record.domain.value for record in records if record.sent)
    return {
        domain: {"actions": reserved.get(domain, 0), "windowsInputs": sent.get(domain, 0)}
        for domain in sorted(item.value for item in InputDomain)
    }


def _final_invariants(
    cycle: FarmCycle,
    *,
    stop_after_return_lobby: bool = False,
) -> tuple[bool, str]:
    snapshot = cycle.snapshot()
    if snapshot.state is not FarmCycleState.FARM_CYCLE_COMPLETE:
        return False, "CYCLE_NOT_COMPLETE"
    if stop_after_return_lobby:
        if snapshot.stop_reason is not FarmCycleStopReason.RETURNED_BOSS_LOBBY_READY:
            return False, "RETURNED_LOBBY_HARD_STOP_NOT_PROVEN"
        if snapshot.entry_inputs_total != 1:
            return False, "SINGLE_CYCLE_ENTRY_INPUT_COUNT_NOT_ONE"
        if snapshot.combat_sessions_seen != 1 or snapshot.combat_sessions_played != 1:
            return False, "SINGLE_CYCLE_SESSION_COUNTS_INVALID"
        if snapshot.session1 is None or snapshot.session2 is not None:
            return False, "SINGLE_CYCLE_SESSION_BOUNDARY_INVALID"
        if any(
            record.domain.gameplay and record.session != snapshot.session1
            for record in snapshot.input_records
        ):
            return False, "OUT_OF_SESSION_GAMEPLAY_INPUT_DETECTED"
        return True, "SINGLE_CYCLE_RETURNED_LOBBY_PROVEN"
    if snapshot.entry_inputs_total != 2:
        return False, "ENTRY_INPUT_COUNT_NOT_TWO"
    if snapshot.combat_sessions_seen != 2 or snapshot.combat_sessions_played != 1:
        return False, "SESSION_COUNTS_INVALID"
    if snapshot.session1 is None or snapshot.session2 is None or snapshot.session1.match_id == snapshot.session2.match_id:
        return False, "SESSION2_NOT_PROVEN_DIFFERENT"
    if any(record.domain.gameplay and record.session != snapshot.session1 for record in snapshot.input_records):
        return False, "COMBAT2_GAMEPLAY_INPUT_DETECTED"
    return True, "PHASE2D2_BOUNDARY_PROVEN"


def _farm_safety_counts(
    cycle: FarmCycle,
    entry1: dict[str, Any] | None,
    entry2: dict[str, Any] | None,
    combat: dict[str, Any] | None,
) -> dict[str, int]:
    entries = tuple(item for item in (entry1, entry2) if isinstance(item, dict))
    combat_counters = combat.get("counters", {}) if isinstance(combat, dict) else {}
    if not isinstance(combat_counters, dict):
        combat_counters = {}
    snapshot = cycle.snapshot()
    return {
        "wrongTargetClicks": sum(int(item.get("wrongBossClicks", 0) or 0) for item in entries),
        "duplicateEntryClicks": sum(int(item.get("duplicateEntryClicks", 0) or 0) for item in entries),
        "thirdEntryClicks": max(0, snapshot.entry_inputs_total - 2),
        "staleSessionConfusions": sum(int(item.get("staleSessionConfusions", 0) or 0) for item in entries),
        "deadBoard": int(combat_counters.get("dead_board", 0) or 0),
        "sequenceDesync": int(combat_counters.get("sequence_desync", 0) or 0),
        "foregroundFailures": int(snapshot.stop_reason is FarmCycleStopReason.FOREGROUND_LOST),
        "combat2GameplayActions": sum(
            1
            for record in snapshot.input_records
            if record.domain.gameplay and record.session == snapshot.session2
        ),
        "combat2WindowsInputs": sum(
            1
            for record in snapshot.input_records
            if record.domain.gameplay and record.session == snapshot.session2 and record.sent
        ),
    }


def _run_cycle(args: Namespace, target: FarmTarget) -> int:
    _validate_args(args)
    stop_after_return_lobby = bool(getattr(args, "run_single_cycle", False))
    if args.reset_evidence is None:
        raise ValueError("automated cycle requires --reset-evidence for B5")
    if not args.reset_evidence.is_file():
        raise FileNotFoundError(args.reset_evidence)
    artifacts = (
        args.artifacts
        or current_app_paths().logs_root
        / "boss_farm_cycle"
        / f"{datetime.now():%Y%m%d_%H%M%S}"
    ).resolve()
    artifacts.mkdir(parents=True, exist_ok=False)
    log_path = artifacts / "cycle.jsonl"
    summary_path = artifacts / "summary.json"
    cycle = FarmCycle(target)
    entry1_result: dict[str, Any] | None = None
    entry2_result: dict[str, Any] | None = None
    combat_summary: dict[str, Any] | None = None
    unexpected: dict[str, str] | None = None

    try:
        with attach_target() as process, log_path.open("a", encoding="utf-8", buffering=1) as log:
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
            _write(
                log,
                "farm_cycle_started",
                cycleId=cycle.cycle_id,
                target=target,
                mode="single-cycle" if stop_after_return_lobby else "phase2d2-boundary",
                entryCapability=True,
                gameplayCapability=True,
                combat2GameplayCapability=False,
            )

            initial = _wait_boss_lobby(
                process, provider, target, args.lobby_timeout, args.interval, hotkeys
            )
            _write(log, "initial_lobby_result", result=initial)
            if not initial.ready:
                cycle.safe_stop(_map_stop_reason(initial.reason, initial=True), detail=initial.reason)
            elif cycle.observe_initial_lobby(BossLobbyState.BOSS_LOBBY):
                opening1, entry1_result = _run_entry_once(
                    cycle=cycle,
                    entry_number=1,
                    args=args,
                    artifacts=artifacts,
                    process=process,
                    provider=provider,
                    monitor=monitor,
                    binding=binding,
                    executor=executor,
                    backend=backend,
                )
                if opening1 is not None and cycle.begin_combat1_play(opening1.session):
                    combat_log = artifacts / "combat1.jsonl"
                    combat_runtime = basic_auto_bot.SharedCombatRuntime(
                        process,
                        provider,
                        monitor,
                        binding,
                        executor,
                        backend,
                        opening1.session,
                        FarmGameplayCapability(cycle, opening1.session),
                    )
                    basic_auto_bot.run(
                        _combat_args(args, combat_log), shared_runtime=combat_runtime
                    )
                    combat_records = _read_jsonl(combat_log)
                    combat_ok, combat_reason, combat_summary = _validate_combat_summary(
                        combat_records
                    )
                    _write(
                        log,
                        "combat1_validation",
                        accepted=combat_ok,
                        reason=combat_reason,
                        summary=combat_summary,
                    )
                    if not combat_ok:
                        cycle.combat1_finished(safe_stop=True, detail=combat_reason)
                    elif cycle.combat1_finished(detail=combat_reason) and cycle.observe_postmatch():
                        postmatch_ready = True
                        if combat_reason == "POSTMATCH_RESULT_UI_REQUIRED":
                            postmatch_ready = _confirm_postmatch_result(
                                cycle=cycle,
                                process=process,
                                provider=provider,
                                binding=binding,
                                executor=executor,
                                artifacts=artifacts,
                                interval=args.interval,
                                ui_timeout=args.postmatch_ui_timeout,
                                hotkeys=hotkeys,
                                log=log,
                            )
                        if not postmatch_ready:
                            returned = None
                        else:
                            returned = _wait_boss_lobby(
                                process,
                                provider,
                                target,
                                args.return_lobby_timeout,
                                args.interval,
                                hotkeys,
                            )
                        _write(log, "return_lobby_result", result=returned)
                        if returned is None:
                            pass
                        elif not returned.ready:
                            return_reason = (
                                FarmCycleStopReason.RETURN_LOBBY_TIMEOUT
                                if returned.reason == "BOSS_LOBBY_TIMEOUT"
                                else _map_stop_reason(returned.reason)
                            )
                            cycle.safe_stop(return_reason, detail=returned.reason)
                        elif stop_after_return_lobby:
                            cycle.complete_after_return_lobby(BossLobbyState.BOSS_LOBBY)
                        elif cycle.observe_return_lobby(BossLobbyState.BOSS_LOBBY):
                            _opening2, entry2_result = _run_entry_once(
                                cycle=cycle,
                                entry_number=2,
                                args=args,
                                artifacts=artifacts,
                                process=process,
                                provider=provider,
                                monitor=monitor,
                                binding=binding,
                                executor=executor,
                                backend=backend,
                            )
            invariants_ok, invariants_reason = _final_invariants(
                cycle,
                stop_after_return_lobby=stop_after_return_lobby,
            )
            _write(
                log,
                "farm_cycle_final_invariants",
                accepted=invariants_ok,
                reason=invariants_reason,
                domainCounts=_domain_counts(cycle),
                safetyCounts=_farm_safety_counts(
                    cycle, entry1_result, entry2_result, combat_summary
                ),
            )
    except KeyboardInterrupt:
        cycle.safe_stop(FarmCycleStopReason.EMERGENCY_STOP, detail="KeyboardInterrupt")
    except Exception as exc:  # noqa: BLE001 - outer controller must fail closed and persist
        cycle.safe_stop(
            FarmCycleStopReason.INTERNAL_INVARIANT,
            exceptionType=type(exc).__name__,
            detail=str(exc),
        )
        unexpected = {
            "type": type(exc).__name__,
            "message": str(exc),
            "traceback": traceback.format_exc(),
        }

    snapshot = cycle.snapshot()
    invariants_ok, invariants_reason = _final_invariants(
        cycle,
        stop_after_return_lobby=stop_after_return_lobby,
    )
    report = {
        "snapshot": snapshot,
        "mode": "single-cycle" if stop_after_return_lobby else "phase2d2-boundary",
        "domainCounts": _domain_counts(cycle),
        "safetyCounts": _farm_safety_counts(
            cycle, entry1_result, entry2_result, combat_summary
        ),
        "finalInvariants": {"accepted": invariants_ok, "reason": invariants_reason},
        "entry1": entry1_result,
        "combat1": combat_summary,
        "entry2": entry2_result,
        "unexpectedError": unexpected,
        "memoryWrites": False,
        "directGameCalls": False,
        "networkManipulation": False,
    }
    summary_path.write_text(
        json.dumps(_jsonable(report), ensure_ascii=False, indent=2), encoding="utf-8"
    )
    print(
        f"Farm cycle stopped ({snapshot.stop_reason}); artifacts: {artifacts}",
        flush=True,
    )
    return 0 if invariants_ok else 2


def _read_only_smoke(args: Namespace, target: FarmTarget) -> int:
    _validate_args(args)
    with attach_target() as process:
        provider = MemoryBoardStateProvider(
            process,
            MemoryProviderConfig(
                max_region_mib=args.max_region_mib,
                chunk_mib=args.chunk_mib,
                required_confirmations=2,
                require_lobby_start=True,
            ),
        )
        result = _wait_boss_lobby(
            process,
            provider,
            target,
            args.lobby_timeout,
            args.interval,
            HotkeyEdges(),
        )
        print(
            "\n".join(
                (
                    f"lobbyState={result.state.value if result.state else 'UNKNOWN'}",
                    f"targetResolution={result.resolution_status.value if result.resolution_status else 'UNKNOWN'}",
                    f"reason={result.reason}",
                    f"stableFrames={result.stable_frames}",
                    "staleCombatOwnership=0" if result.ready else "staleCombatOwnership=UNKNOWN",
                    "otherCooperatingController=0",
                    "inputs=0",
                )
            )
        )
        return 0 if result.ready else 1


def run(args: argparse.Namespace) -> int:
    target = FarmTarget(args.boss_id, args.boss_name)
    return _read_only_smoke(args, target) if args.read_only_smoke else _run_cycle(args, target)


def main(argv: Sequence[str] | None = None) -> int:
    args = build_parser().parse_args(argv)
    try:
        with AutomationControllerLease(current_app_paths().controller_lock):
            return run(args)
    except (FileExistsError, FileNotFoundError, OSError, RuntimeError, ValueError) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
