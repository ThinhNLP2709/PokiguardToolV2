#!/usr/bin/env python3
"""Phase 2D.1 one-shot boss-lobby entry controller.

Exactly one normal foreground Windows click is permitted, and only after an
exact runtime target plus a two-frame visual Start-button proof.  The tool
stops at a new, stable 64-cell MATCH_START opening and contains no gameplay
policy/action path.
"""

from __future__ import annotations

import argparse
from dataclasses import asdict, dataclass, is_dataclass
from datetime import datetime
from enum import Enum
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

from pokiguard_v2.boss_entry import (  # noqa: E402
    BossEntryState,
    BossLobbyState,
    EntryAttemptIdentity,
    FarmTarget,
    TargetResolutionStatus,
    TargetSelectionState,
    entry_button_signature,
    resolve_target,
)
from pokiguard_v2.boss_entry_ui import locate_chinh_phuc_start  # noqa: E402
from pokiguard_v2.boss_lobby_runtime import (  # noqa: E402
    BossLobbyRuntimeSnapshot,
    read_boss_lobby_runtime,
)
from pokiguard_v2.il2cpp_external import (  # noqa: E402
    MATCH_SERVICE_CURRENT_MATCH_ID_OFFSET,
    MATCH_SERVICE_LOCAL_SEQ_NUM_OFFSET,
    MATCH_SERVICE_SINGLETON,
    WS_COMBAT_BATCH_TYPE_INFO_RVA,
    ExternalReadError,
)
from pokiguard_v2.il2cpp_layout import (  # noqa: E402
    LayoutValidationError,
    read_il2cpp_string,
)
from pokiguard_v2.live_state import board_state_hash  # noqa: E402
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
    utc_timestamp,
)
from pokiguard_v2.opening_snapshot import (  # noqa: E402
    JARRAY_TYPE_INFO_RVA,
    JOBJECT_TYPE_INFO_RVA,
    JPROPERTY_TYPE_INFO_RVA,
    JVALUE_TYPE_INFO_RVA,
    NewtonsoftClasses,
    OpeningBoardSnapshot,
    read_match_start_opening_snapshot,
)
from pokiguard_v2.recovery_ui import locate_confirm_leave  # noqa: E402
from pokiguard_v2.win32_input import (  # noqa: E402
    ForegroundClickExecutor,
    HotkeyEdges,
    NativeWin32Backend,
    find_window_for_pid,
)
from pokiguard_v2.win32_screenshot import (  # noqa: E402
    ClientRgbCapture,
    capture_client_rgb,
    write_png_rgb,
)
from tools.idle_state_watch import CHAT_MESSAGE_DTO_TYPE_INFO_RVA  # noqa: E402
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.runtime_common import attach_target, hex_pointer  # noqa: E402
from tools.sequence_desync_runtime import RuntimeSequenceMonitor  # noqa: E402


@dataclass(frozen=True)
class EntryBaseline:
    old_match_id: str | None
    old_session_key: Any
    old_board_instance: int | None
    old_srv_seq: int | None
    old_local_sequence: int | None
    old_lifecycle_epoch: int


@dataclass(frozen=True)
class ReadyContext:
    lobby: BossLobbyRuntimeSnapshot
    resolution: Any
    capture: ClientRgbCapture
    location: Any
    signature: str
    attempt: EntryAttemptIdentity
    baseline: EntryBaseline


def _jsonable(value: Any) -> Any:
    if is_dataclass(value):
        return _jsonable(asdict(value))
    if isinstance(value, Enum):
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
            {"timestamp": utc_timestamp(), "event": event, **_jsonable(fields)},
            ensure_ascii=False,
            separators=(",", ":"),
        )
        + "\n"
    )
    log.flush()


def _beep(kind: str, enabled: bool) -> None:
    if not enabled or winsound is None:
        return
    if kind == "ready":
        winsound.Beep(920, 180)
    elif kind == "pass":
        winsound.Beep(1080, 150)
        time.sleep(0.08)
        winsound.Beep(1280, 180)
    else:
        for _index in range(3):
            winsound.Beep(420, 130)
            time.sleep(0.06)


def _transition(log: Any, old: BossEntryState, new: BossEntryState, **fields: Any) -> BossEntryState:
    if old is not new:
        _write(log, "entry_state_transition", oldState=old, newState=new, **fields)
        print(f"{old.value} -> {new.value}", flush=True)
    return new


def _read_match_id(target: Any) -> tuple[str | None, int | None]:
    resolution = target.resolver.resolve_singleton(MATCH_SERVICE_SINGLETON)
    if not resolution.resolved or resolution.instance is None:
        return None, None
    match_service = resolution.instance
    pointer = target.resolver.read_pointer(
        match_service + MATCH_SERVICE_CURRENT_MATCH_ID_OFFSET
    )
    match_id = (
        read_il2cpp_string(target.memory, pointer, max_length=256)
        if pointer
        else None
    )
    local_sequence = target.resolver.read_i64(
        match_service + MATCH_SERVICE_LOCAL_SEQ_NUM_OFFSET
    )
    return match_id or None, local_sequence


def _opening_classes(target: Any) -> NewtonsoftClasses | None:
    values = tuple(
        target.resolver.resolve_type_info_class(rva)
        for rva in (
            JARRAY_TYPE_INFO_RVA,
            JOBJECT_TYPE_INFO_RVA,
            JPROPERTY_TYPE_INFO_RVA,
            JVALUE_TYPE_INFO_RVA,
        )
    )
    if not all(value is not None for value in values):
        return None
    return NewtonsoftClasses(*(int(value) for value in values))


def _candidate_records(lobby: BossLobbyRuntimeSnapshot) -> tuple[dict[str, Any], ...]:
    return tuple(
        {
            "index": candidate.index,
            "bossId": candidate.identity.boss_id,
            "bossName": candidate.identity.boss_name,
            "roomId": candidate.identity.room_id,
            "petId": candidate.identity.pet_id,
            "source": candidate.identity.source,
            "selected": candidate.selection,
            "available": candidate.available,
            "active": candidate.active,
            "entryControl": hex_pointer(candidate.entry_control_address),
            "screenRect": candidate.screen_rect,
            "evidence": candidate.evidence,
        }
        for candidate in lobby.candidates
    )


def _capture_proof(
    *,
    target: Any,
    executor: ForegroundClickExecutor,
    binding: Any,
) -> tuple[ClientRgbCapture, Any, str]:
    status = executor.window_status(binding)
    if not status.valid or status.foreground is not True or status.geometry is None:
        raise RuntimeError("game window must be unchanged and foreground")
    capture = capture_client_rgb(target.pid)
    if (capture.width, capture.height) != (
        status.geometry.width,
        status.geometry.height,
    ):
        raise RuntimeError("captured client geometry changed")
    modal = locate_confirm_leave(capture.rgb, capture.width, capture.height)
    if modal.found:
        raise RuntimeError("modal-like two-button overlay is visible")
    location = locate_chinh_phuc_start(capture.rgb, capture.width, capture.height)
    if not location.found or location.normalized_point is None or location.normalized_rect is None:
        raise RuntimeError(location.reason)
    if location.confidence < 0.90:
        raise RuntimeError(f"entry locator confidence {location.confidence:.3f} is below 0.90")
    signature = entry_button_signature(
        control=location.control.value,
        normalized_rect=location.normalized_rect,
        normalized_point=location.normalized_point,
        client_size=(capture.width, capture.height),
    )
    return capture, location, signature


def _save_capture(path: Path, capture: ClientRgbCapture) -> None:
    write_png_rgb(path, capture.width, capture.height, capture.rgb)


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    mode = parser.add_mutually_exclusive_group(required=True)
    mode.add_argument("--inspect-only", action="store_true", help="resolve and log; never click")
    mode.add_argument("--stage-a", action="store_true", help="F8 confirms the one entry click")
    mode.add_argument("--stage-b", action="store_true", help="automatic one-shot entry")
    target = parser.add_mutually_exclusive_group(required=True)
    target.add_argument("--boss-id", help="exact runtime boss/enemy pet ID")
    target.add_argument("--boss-name", help="exact NFC/casefold boss name")
    parser.add_argument("--lobby-timeout", type=float, default=180.0)
    parser.add_argument("--entry-timeout", type=float, default=45.0)
    parser.add_argument("--opening-timeout", type=float, default=35.0)
    parser.add_argument("--interval", type=float, default=0.12)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument("--artifacts", type=Path)
    parser.add_argument("--no-beep", action="store_true")
    return parser


def _validate_args(args: argparse.Namespace) -> None:
    if not 0.08 <= args.interval <= 0.50:
        raise ValueError("--interval must be between 0.08 and 0.50 seconds")
    for name in ("lobby_timeout", "entry_timeout", "opening_timeout"):
        if not 5 <= getattr(args, name) <= 600:
            raise ValueError(f"--{name.replace('_', '-')} must be between 5 and 600 seconds")
    if not 1 <= args.max_region_mib <= 32 or not 1 <= args.chunk_mib <= 16:
        raise ValueError("scan size arguments are outside safe bounds")


def run(args: argparse.Namespace) -> int:
    _validate_args(args)
    farm_target = FarmTarget(args.boss_id, args.boss_name)
    artifact_dir = (
        args.artifacts
        or PROJECT_ROOT
        / "logs"
        / "boss_entry"
        / f"{datetime.now():%Y%m%d_%H%M%S}"
    ).resolve()
    artifact_dir.mkdir(parents=True, exist_ok=False)
    log_path = artifact_dir / "entry.jsonl"
    summary_path = artifact_dir / "entry.json"
    beep_enabled = not args.no_beep
    result: dict[str, Any] = {
        "status": "RUNNING",
        "stopReason": None,
        "entryClicks": 0,
        "gameplayInputs": 0,
        "wrongBossClicks": 0,
        "duplicateEntryClicks": 0,
        "staleSessionConfusions": 0,
        "artifacts": str(artifact_dir),
    }

    with attach_target() as target, log_path.open("a", encoding="utf-8", buffering=1) as log:
        provider = MemoryBoardStateProvider(
            target,
            MemoryProviderConfig(
                max_region_mib=args.max_region_mib,
                chunk_mib=args.chunk_mib,
                required_confirmations=2,
                require_lobby_start=True,
            ),
        )
        monitor = RuntimeSequenceMonitor(
            target,
            max_region_mib=max(args.max_region_mib, 16),
            chunk_mib=args.chunk_mib,
        )
        backend = NativeWin32Backend()
        binding = find_window_for_pid(target.pid, backend)
        executor = ForegroundClickExecutor(backend)
        hotkeys = HotkeyEdges()
        state = BossEntryState.WAIT_BOSS_LOBBY
        _write(
            log,
            "boss_entry_started",
            pid=target.pid,
            gameAssemblyBase=hex_pointer(target.game_assembly.base),
            mode="INSPECT" if args.inspect_only else "STAGE_A" if args.stage_a else "STAGE_B",
            farmTarget=farm_target,
            processAccess=["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"],
            normalWindowsInputOnly=True,
            gameplayInputPathsLoaded=False,
        )
        print(f"Phase 2D.1 boss entry: {artifact_dir}", flush=True)
        print("F9 = emergency stop; Stage A uses F8 only after one READY beep.", flush=True)

        ready: ReadyContext | None = None
        stable_lobby_key = None
        stable_lobby_count = 0
        lobby_epoch = 0
        last_lobby_status = None
        deadline = time.monotonic() + args.lobby_timeout

        while target.is_running() and time.monotonic() < deadline and ready is None:
            f8_edge, f9_edge = hotkeys.poll()
            del f8_edge
            if f9_edge:
                result.update(status="STOPPED", stopReason="F9_EMERGENCY_STOP")
                _write(log, "entry_stopped", reason=result["stopReason"])
                _beep("stop", beep_enabled)
                break
            poll = provider.poll()
            if poll.combat_lifecycle is None:
                time.sleep(args.interval)
                continue
            lobby = read_boss_lobby_runtime(target.resolver, poll.combat_lifecycle)
            status = (lobby.state, lobby.branch, tuple(c.identity.stable_key() for c in lobby.candidates))
            if status != last_lobby_status:
                _write(
                    log,
                    "boss_lobby_observation",
                    lobbyState=lobby.state,
                    branch=lobby.branch,
                    lifecycle=poll.combat_lifecycle,
                    chinhPhuc=lobby.chinh_phuc,
                    worldBoss=lobby.world_boss,
                    reasons=lobby.reasons,
                )
                last_lobby_status = status
            if lobby.state is not BossLobbyState.BOSS_LOBBY:
                stable_lobby_key = None
                stable_lobby_count = 0
                time.sleep(args.interval)
                continue

            key = (lobby.branch, tuple(c.identity.stable_key() for c in lobby.candidates))
            stable_lobby_count = stable_lobby_count + 1 if key == stable_lobby_key else 1
            stable_lobby_key = key
            if stable_lobby_count < 2:
                time.sleep(args.interval)
                continue
            lobby_epoch += 1
            _write(log, "boss_lobby_detected", lobbyEpoch=lobby_epoch, branch=lobby.branch)
            _write(log, "target_candidates", candidates=_candidate_records(lobby))
            state = _transition(log, state, BossEntryState.RESOLVE_TARGET)
            resolution = resolve_target(farm_target, lobby.candidates)
            if resolution.status is not TargetResolutionStatus.RESOLVED:
                result.update(status="STOPPED", stopReason=resolution.status.value)
                _write(log, "target_resolution_failed", resolution=resolution)
                _beep("stop", beep_enabled)
                break
            candidate = resolution.candidate
            assert candidate is not None
            _write(log, "target_resolved", resolution=resolution)
            if not candidate.available:
                result.update(status="STOPPED", stopReason="TARGET_NOT_AVAILABLE")
                _write(log, "entry_stopped", reason=result["stopReason"], candidate=candidate)
                _beep("stop", beep_enabled)
                break
            state = _transition(log, state, BossEntryState.SELECT_TARGET_IF_NEEDED)
            if lobby.branch != "CHINH_PHUC_ROOM":
                result.update(status="STOPPED", stopReason="WORLD_BOSS_ENTRY_UI_UNCALIBRATED")
                _write(
                    log,
                    "entry_stopped",
                    reason=result["stopReason"],
                    note="BossItem identity/control association is proven, but no calibrated screen rect exists",
                )
                _beep("stop", beep_enabled)
                break
            state = _transition(log, state, BossEntryState.VERIFY_TARGET_SELECTED)
            if candidate.selection is not TargetSelectionState.SELECTED:
                result.update(status="STOPPED", stopReason="TARGET_SELECTION_UNCONFIRMED")
                _write(log, "entry_stopped", reason=result["stopReason"])
                _beep("stop", beep_enabled)
                break
            _write(log, "target_selected", candidate=candidate, selectionSource="ManagerRoom.roomData")
            state = _transition(log, state, BossEntryState.LOCATE_ENTER_BUTTON)

            try:
                first_capture, first_location, first_signature = _capture_proof(
                    target=target, executor=executor, binding=binding
                )
            except RuntimeError as exc:
                _write(log, "fight_button_waiting", reason=str(exc))
                time.sleep(args.interval)
                continue
            time.sleep(max(args.interval, 0.14))
            try:
                second_capture, second_location, second_signature = _capture_proof(
                    target=target, executor=executor, binding=binding
                )
            except RuntimeError as exc:
                _write(log, "fight_button_unstable", reason=str(exc))
                time.sleep(args.interval)
                continue
            if first_signature != second_signature:
                _write(
                    log,
                    "fight_button_unstable",
                    firstSignature=first_signature,
                    secondSignature=second_signature,
                )
                time.sleep(args.interval)
                continue

            _save_capture(artifact_dir / "lobby_before.png", first_capture)
            _save_capture(artifact_dir / "entry_button.png", second_capture)
            _write(
                log,
                "fight_button_detected",
                location=second_location,
                buttonSignature=second_signature,
                gameWindowRect={
                    "left": second_capture.left,
                    "top": second_capture.top,
                    "width": second_capture.width,
                    "height": second_capture.height,
                },
                entryControlAddress=hex_pointer(candidate.entry_control_address),
                association="ManagerRoom owns both roomData and ButtonStart",
            )
            old_match_id, old_local_sequence = _read_match_id(target)
            baseline = EntryBaseline(
                old_match_id,
                provider.current_session_key,
                poll.state.battle.board_instance if poll.state is not None else None,
                poll.state.battle.srv_seq if poll.state is not None else None,
                old_local_sequence,
                lobby_epoch,
            )
            attempt = EntryAttemptIdentity(
                lobby_epoch,
                candidate.identity.stable_key(),
                candidate.selection,
                utc_timestamp(),
                second_signature,
            )
            ready = ReadyContext(
                lobby,
                resolution,
                second_capture,
                second_location,
                second_signature,
                attempt,
                baseline,
            )
            state = _transition(log, state, BossEntryState.READY_TO_ENTER)
            _write(
                log,
                "session_scoped_cache_invalidated",
                baseline=baseline,
                cleared=[
                    "board cache",
                    "srvSeq tracking",
                    "idle state",
                    "sequence-desync sticky state",
                    "pending gameplay proposal",
                    "card transient state",
                    "fusion transient state",
                    "prior action identity",
                ],
                providerFreshForThisOneShot=True,
            )
            _write(log, "entry_ready", attempt=attempt, attemptDigest=attempt.digest())

        if result["status"] != "RUNNING":
            summary_path.write_text(
                json.dumps(_jsonable(result), ensure_ascii=False, indent=2), encoding="utf-8"
            )
            return 0
        if ready is None:
            result.update(status="STOPPED", stopReason="ENTRY_TIMEOUT_BOSS_LOBBY")
            _write(log, "entry_stopped", reason=result["stopReason"])
            _beep("stop", beep_enabled)
            summary_path.write_text(
                json.dumps(_jsonable(result), ensure_ascii=False, indent=2), encoding="utf-8"
            )
            return 2
        if args.inspect_only:
            result.update(status="INSPECTION_READY", stopReason="INSPECT_ONLY_NO_INPUT")
            _write(
                log,
                "entry_inspection_complete",
                attempt=ready.attempt,
                baseline=ready.baseline,
                target=ready.resolution.candidate,
                location=ready.location,
                buttonSignature=ready.signature,
                noInput=True,
            )
            summary_path.write_text(
                json.dumps(_jsonable(result), ensure_ascii=False, indent=2), encoding="utf-8"
            )
            print("INSPECT READY: exact target + Start button proven; no input sent.", flush=True)
            return 0

        _beep("ready", beep_enabled)
        if args.stage_a:
            print("READY: verify the configured target visually, then press F8 once. F9 stops.", flush=True)
            confirm_deadline = time.monotonic() + args.entry_timeout
            confirmed = False
            while target.is_running() and time.monotonic() < confirm_deadline:
                f8_edge, f9_edge = hotkeys.poll()
                if f9_edge:
                    result.update(status="STOPPED", stopReason="F9_EMERGENCY_STOP")
                    _write(log, "entry_stopped", reason=result["stopReason"])
                    break
                if f8_edge:
                    confirmed = True
                    break
                time.sleep(args.interval)
            if not confirmed and result["status"] == "RUNNING":
                result.update(status="STOPPED", stopReason="ENTRY_TIMEOUT_CONFIRMATION")
                _write(log, "entry_stopped", reason=result["stopReason"])
        if result["status"] != "RUNNING":
            _beep("stop", beep_enabled)
            summary_path.write_text(
                json.dumps(_jsonable(result), ensure_ascii=False, indent=2), encoding="utf-8"
            )
            return 2

        # Atomic preflight immediately before the only allowed entry click.
        poll = provider.poll()
        if poll.combat_lifecycle is None:
            raise RuntimeError("preflight lifecycle unavailable")
        current_lobby = read_boss_lobby_runtime(target.resolver, poll.combat_lifecycle)
        current_resolution = resolve_target(farm_target, current_lobby.candidates)
        if (
            current_lobby.state is not BossLobbyState.BOSS_LOBBY
            or current_lobby.branch != "CHINH_PHUC_ROOM"
            or not current_resolution.resolved
            or current_resolution.candidate is None
            or current_resolution.candidate.identity.stable_key()
            != ready.resolution.candidate.identity.stable_key()
            or current_resolution.candidate.selection is not TargetSelectionState.SELECTED
            or current_resolution.candidate.entry_control_address
            != ready.resolution.candidate.entry_control_address
        ):
            result.update(status="STOPPED", stopReason="ENTRY_PREFLIGHT_RUNTIME_CHANGED")
            _write(log, "entry_stopped", reason=result["stopReason"])
            _beep("stop", beep_enabled)
            summary_path.write_text(
                json.dumps(_jsonable(result), ensure_ascii=False, indent=2), encoding="utf-8"
            )
            return 2
        capture, location, signature = _capture_proof(
            target=target, executor=executor, binding=binding
        )
        if signature != ready.signature:
            result.update(status="STOPPED", stopReason="ENTRY_PREFLIGHT_BUTTON_CHANGED")
            _write(log, "entry_stopped", reason=result["stopReason"])
            _beep("stop", beep_enabled)
            summary_path.write_text(
                json.dumps(_jsonable(result), ensure_ascii=False, indent=2), encoding="utf-8"
            )
            return 2
        window_status = executor.window_status(binding)
        if not window_status.valid or window_status.foreground is not True or window_status.geometry is None:
            raise RuntimeError("game lost foreground before entry click")
        if result["entryClicks"] != 0:
            result["duplicateEntryClicks"] += 1
            raise RuntimeError("entry attempt was already sent")
        click = executor.send_normalized_point(binding, location.normalized_point)
        if not click.sent:
            result.update(status="STOPPED", stopReason=f"ENTRY_INPUT_{click.status.value}")
            _write(log, "entry_stopped", reason=result["stopReason"])
            _beep("stop", beep_enabled)
            summary_path.write_text(
                json.dumps(_jsonable(result), ensure_ascii=False, indent=2), encoding="utf-8"
            )
            return 2
        result["entryClicks"] = 1
        geometry = window_status.geometry
        client_x = int(location.normalized_point[0] * (geometry.width - 1))
        client_y = int(location.normalized_point[1] * (geometry.height - 1))
        state = _transition(log, state, BossEntryState.ENTER_CLICK_SENT)
        _write(
            log,
            "entry_input_sent",
            attempt=ready.attempt,
            attemptDigest=ready.attempt.digest(),
            screenPosition={"x": geometry.left + client_x, "y": geometry.top + client_y},
            clientPosition={"x": client_x, "y": client_y},
            normalizedPoint=location.normalized_point,
            locatorConfidence=location.confidence,
            gameWindowRect=geometry,
            clickCount=1,
        )
        state = _transition(log, state, BossEntryState.WAIT_ENTERING_COMBAT)

        entry_started = time.monotonic()
        entry_deadline = entry_started + args.entry_timeout
        opening_deadline: float | None = None
        entering_seen = False
        new_match_id: str | None = None
        active_session = None
        pre_session = None
        opening_classes: NewtonsoftClasses | None = None
        preloaded_opening: OpeningBoardSnapshot | None = None
        offered_messages: set[int] = set()
        last_provider_status = None

        while target.is_running():
            _f8_edge, f9_edge = hotkeys.poll()
            if f9_edge:
                result.update(status="STOPPED", stopReason="F9_EMERGENCY_STOP")
                _write(log, "entry_stopped", reason=result["stopReason"])
                break
            now = time.monotonic()
            if active_session is None and now >= entry_deadline:
                result.update(status="STOPPED", stopReason="ENTRY_TIMEOUT_NEW_SESSION")
                _write(log, "entry_stopped", reason=result["stopReason"])
                break
            if active_session is not None and opening_deadline is not None and now >= opening_deadline:
                result.update(status="STOPPED", stopReason="ENTRY_TIMEOUT_OPENING_BOARD")
                _write(log, "entry_stopped", reason=result["stopReason"])
                break

            poll = provider.poll()
            provider_status = (
                poll.reason,
                poll.lifecycle_event,
                poll.session_key,
                poll.combat_lifecycle.state if poll.combat_lifecycle else None,
            )
            if provider_status != last_provider_status:
                _write(
                    log,
                    "entry_provider_status",
                    reason=poll.reason,
                    lifecycleEvent=poll.lifecycle_event,
                    session=poll.session_key,
                    combatLifecycle=poll.combat_lifecycle,
                    diagnostics=provider.scan_diagnostics,
                )
                last_provider_status = provider_status
            lifecycle_state = poll.combat_lifecycle.state if poll.combat_lifecycle else None
            if lifecycle_state is not None and lifecycle_state.value == "entering_combat" and not entering_seen:
                entering_seen = True
                _write(log, "entering_combat", lifecycle=poll.combat_lifecycle)
                state = _transition(log, state, BossEntryState.WAIT_NEW_SESSION)

            try:
                observed_match_id, observed_local_sequence = _read_match_id(target)
            except (ExternalReadError, LayoutValidationError, OSError, ValueError):
                observed_match_id, observed_local_sequence = None, None
            if observed_match_id and observed_match_id != ready.baseline.old_match_id:
                if new_match_id is None:
                    new_match_id = observed_match_id
                    _write(
                        log,
                        "new_match_detected",
                        oldMatchId=ready.baseline.old_match_id,
                        newMatchId=new_match_id,
                        localMoveSequence=observed_local_sequence,
                    )
                elif observed_match_id != new_match_id:
                    result.update(status="STOPPED", stopReason="NEW_MATCH_ID_CHANGED_AGAIN")
                    _write(log, "entry_stopped", reason=result["stopReason"])
                    break
                if pre_session is None:
                    pre_session = ("boss-entry-preload", ready.attempt.lobby_epoch, new_match_id)
                    monitor.begin_session(pre_session, new_match_id, clean=True)
                    _write(log, "opening_preload_started", session=pre_session)

            monitor_session = active_session or pre_session
            if monitor_session is not None and new_match_id is not None:
                if opening_classes is None:
                    opening_classes = _opening_classes(target)
                observation = monitor.poll(
                    session_key=monitor_session,
                    match_id=new_match_id,
                    turn=(poll.state.battle.turn_number if poll.state else None),
                    srv_seq=(poll.state.battle.srv_seq if poll.state else None),
                    timestamp=utc_timestamp(),
                )
                for message in observation.messages:
                    if (
                        message.event_type != "MATCH_START"
                        or message.address in offered_messages
                        or message.payload_address is None
                        or opening_classes is None
                    ):
                        continue
                    offered_messages.add(message.address)
                    try:
                        decoded = read_match_start_opening_snapshot(
                            target.memory,
                            match_id=new_match_id,
                            message_address=message.address,
                            payload_address=message.payload_address,
                            classes=opening_classes,
                        )
                        preloaded_opening = decoded
                        _write(
                            log,
                            "opening_snapshot_preloaded",
                            messageAddress=hex_pointer(message.address),
                            matchId=decoded.match_id,
                            srvSeq=decoded.sequence,
                            completeCells=len(decoded.cells),
                            boardHash=board_state_hash(decoded.cells),
                        )
                    except (ExternalReadError, LayoutValidationError, OSError, ValueError) as exc:
                        _write(
                            log,
                            "opening_snapshot_rejected",
                            messageAddress=hex_pointer(message.address),
                            reason=str(exc),
                        )

            if (
                poll.lifecycle_event in {"board_found", "session_changed"}
                and poll.session_key is not None
                and active_session is None
            ):
                candidate_session = poll.session_key
                if (
                    not new_match_id
                    or candidate_session.match_id != new_match_id
                    or candidate_session.match_id == ready.baseline.old_match_id
                    or (
                        ready.baseline.old_board_instance is not None
                        and candidate_session.board_instance
                        == ready.baseline.old_board_instance
                    )
                ):
                    result["staleSessionConfusions"] += 1
                    result.update(status="STOPPED", stopReason="NEW_SESSION_NOT_PROVEN_NEW")
                    _write(
                        log,
                        "entry_stopped",
                        reason=result["stopReason"],
                        candidateSession=candidate_session,
                        baseline=ready.baseline,
                    )
                    break
                active_session = candidate_session
                if pre_session is not None:
                    monitor.end_session(pre_session)
                monitor.begin_session(active_session, active_session.match_id, clean=True)
                state = _transition(log, state, BossEntryState.WAIT_OPENING_BOARD)
                opening_deadline = time.monotonic() + args.opening_timeout
                _write(
                    log,
                    "new_session_confirmed",
                    session=active_session,
                    baseline=ready.baseline,
                    enteringSeen=entering_seen,
                )
                if not entering_seen:
                    entering_seen = True
                    _write(
                        log,
                        "entering_combat",
                        inferredFromNewActiveSession=True,
                        note="poll interval did not sample PREPARING/BUILDING",
                    )
                if (
                    preloaded_opening is not None
                    and preloaded_opening.match_id == active_session.match_id
                ):
                    accepted = provider.offer_opening_snapshot(preloaded_opening)
                    _write(
                        log,
                        "opening_snapshot_offered",
                        accepted=accepted,
                        opening=preloaded_opening,
                    )

            if (
                poll.publish
                and poll.reason == "stable_match_start_opening_dto"
                and poll.state is not None
                and active_session is not None
            ):
                game_state = poll.state
                source_ok = "ChatMessageDTO.MATCH_START.matchPayload.board" in game_state.battle.sources
                cells = tuple(cell for row in game_state.board.cells for cell in row)
                opening_ok = bool(
                    game_state.battle.session_key == active_session
                    and game_state.battle.match_id == new_match_id
                    and game_state.battle.stable
                    and game_state.battle.board_hash
                    and game_state.battle.is_local_turn is True
                    and game_state.battle.local_move_sequence == 0
                    and len(cells) == 64
                    and game_state.board.production_ready
                    and source_ok
                )
                if not opening_ok:
                    result.update(status="STOPPED", stopReason="OPENING_ACCEPTANCE_INVARIANT_FAILED")
                    _write(
                        log,
                        "entry_stopped",
                        reason=result["stopReason"],
                        state=game_state,
                        completeCells=len(cells),
                        sourceOk=source_ok,
                    )
                    break
                _write(
                    log,
                    "opening_board_ready",
                    session=active_session,
                    srvSeq=game_state.battle.srv_seq,
                    boardHash=game_state.battle.board_hash,
                    completeCells=64,
                    confirmations=poll.confirmations,
                    firstLocalTurn=True,
                    localMoveSequence=0,
                    sources=game_state.battle.sources,
                )
                try:
                    final_status = executor.window_status(binding)
                    if final_status.valid and final_status.foreground is True:
                        _save_capture(
                            artifact_dir / "combat_opening.png",
                            capture_client_rgb(target.pid),
                        )
                except (OSError, RuntimeError, ValueError) as exc:
                    _write(log, "combat_opening_screenshot_skipped", reason=str(exc))
                state = _transition(log, state, BossEntryState.ENTRY_CONFIRMED)
                result.update(
                    status="PASS",
                    stopReason="NEW_COMBAT_OPENING_READY",
                    matchId=new_match_id,
                    session=active_session,
                    boardHash=game_state.battle.board_hash,
                    srvSeq=game_state.battle.srv_seq,
                    openingCells=64,
                    firstLocalTurn=True,
                    gameplayInputs=0,
                )
                _write(log, "entry_acceptance_complete", result=result)
                state = _transition(log, state, BossEntryState.STOP)
                _beep("pass", beep_enabled)
                print("PHASE 2D.1 ENTRY PASS — stopped before any gameplay action.", flush=True)
                break
            time.sleep(args.interval)

        if result["status"] == "RUNNING":
            result.update(status="STOPPED", stopReason="TARGET_PROCESS_EXITED")
            _write(log, "entry_stopped", reason=result["stopReason"])
        if result["status"] != "PASS":
            _beep("stop", beep_enabled)
        result["finalState"] = state.value
        summary_path.write_text(
            json.dumps(_jsonable(result), ensure_ascii=False, indent=2), encoding="utf-8"
        )
        return 0 if result["status"] in {"PASS", "INSPECTION_READY", "STOPPED"} else 2


def main(argv: Sequence[str] | None = None) -> int:
    try:
        return run(build_parser().parse_args(argv))
    except KeyboardInterrupt:
        print("Boss entry stopped by user.", file=sys.stderr)
        return 130
    except (
        ExternalReadError,
        FileExistsError,
        FileNotFoundError,
        LayoutValidationError,
        OSError,
        ProcessProbeError,
        RuntimeError,
        ValueError,
    ) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
