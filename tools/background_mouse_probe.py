#!/usr/bin/env python3
"""User-operated Phase 4A.1 live probe for bounded background mouse input.

Default execution performs B1 only and sends zero input.  ``--live-sequence``
keeps one read-only provider alive from the lobby through B2/B3/B4 and asks
for an exact console arm phrase before each one-shot command.
"""

from __future__ import annotations

import argparse
from contextlib import ExitStack
from dataclasses import asdict, dataclass, is_dataclass
from datetime import datetime, timezone
from enum import Enum
import hashlib
import json
from pathlib import Path
import subprocess
import sys
import threading
import time
from typing import Any, Callable


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.actionability import ActionabilityGate, GateContext, GateReason  # noqa: E402
from pokiguard_v2.app_paths import current_app_paths  # noqa: E402
from pokiguard_v2.board_simulator import MoveEvaluation, evaluate_all_moves  # noqa: E402
from pokiguard_v2.boss_entry import (  # noqa: E402
    BossLobbyState,
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
from pokiguard_v2.controller_lease import AutomationControllerLease  # noqa: E402
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
)
from pokiguard_v2.recovery_ui import locate_confirm_leave  # noqa: E402
from pokiguard_v2.state import GamePhase, GameState  # noqa: E402
from pokiguard_v2.win32_input import (  # noqa: E402
    BoardCalibration,
    HotkeyEdges,
    NativeWin32Backend,
    WindowBinding,
    find_window_for_pid,
    map_swap_to_pixels,
)
from pokiguard_v2.win32_screenshot import (  # noqa: E402
    ClientRgbCapture,
    capture_client_rgb,
    write_png_rgb,
)
from tools.background_mouse_transport import (  # noqa: E402
    BoundedBackgroundMouseTransport,
    ExactWindowBinding,
    NativeBackgroundMouseBackend,
    ProbeCommand,
    ProbeOutcome,
    SwapPreState,
    TransportResult,
    TransportStatus,
    classify_probe_outcome,
    jsonable,
    runtime_proves_swap_accepted,
)
from tools.idle_state_watch import MatchRuntime, read_match_runtime  # noqa: E402
from tools.runtime_common import attach_target  # noqa: E402


@dataclass(frozen=True)
class LobbyProof:
    lobby: BossLobbyRuntimeSnapshot
    target_key: tuple[str | None, str | None, str | None, int | None, str]
    normalized_point: tuple[float, float]
    normalized_rect: tuple[float, float, float, float]
    signature: str
    confidence: float
    entry_control_address: int | None
    capture: ClientRgbCapture


@dataclass(frozen=True)
class BoardProposal:
    state: GameState
    evaluation: MoveEvaluation
    pre: SwapPreState


def _utc_timestamp() -> str:
    return datetime.now(timezone.utc).isoformat(timespec="milliseconds")


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


class ArtifactLog:
    def __init__(self, root: Path) -> None:
        self.root = root
        self.root.mkdir(parents=True, exist_ok=False)
        self.events_path = self.root / "events.jsonl"
        self.summary_path = self.root / "summary.json"
        self._log = self.events_path.open("a", encoding="utf-8", buffering=1)
        self.summary: dict[str, Any] = {
            "phase": "4A.1",
            "status": "RUNNING",
            "startedAt": _utc_timestamp(),
            "stages": {
                "B1": "NOT_RUN",
                "B2": ProbeOutcome.NOT_RUN.value,
                "B3": ProbeOutcome.NOT_RUN.value,
                "B4": ProbeOutcome.NOT_RUN.value,
            },
            "inputCounts": {"singleClick": 0, "twoClick": 0, "drag": 0},
            "retryCount": 0,
        }

    def event(self, event: str, **fields: Any) -> None:
        payload = {"timestamp": _utc_timestamp(), "event": event, **fields}
        self._log.write(
            json.dumps(_jsonable(payload), ensure_ascii=False, separators=(",", ":"))
            + "\n"
        )

    def sink(self, event: str, fields: dict[str, Any]) -> None:
        self.event(event, **fields)

    def save(self) -> None:
        self.summary_path.write_text(
            json.dumps(_jsonable(self.summary), ensure_ascii=False, indent=2),
            encoding="utf-8",
        )

    def close(self) -> None:
        self.summary["finishedAt"] = _utc_timestamp()
        self.save()
        self._log.close()


class StopController:
    def __init__(self) -> None:
        self._event = threading.Event()
        self._hotkeys = HotkeyEdges()
        self._thread = threading.Thread(target=self._watch, daemon=True)

    def start(self) -> None:
        self._thread.start()

    def _watch(self) -> None:
        while not self._event.is_set():
            _f8, f9 = self._hotkeys.poll()
            if f9:
                self._event.set()
                break
            time.sleep(0.05)

    def requested(self) -> bool:
        return self._event.is_set()

    def stop(self) -> None:
        self._event.set()


def _sha256(path: str | Path) -> str:
    digest = hashlib.sha256()
    with Path(path).open("rb") as handle:
        for chunk in iter(lambda: handle.read(1024 * 1024), b""):
            digest.update(chunk)
    return digest.hexdigest().upper()


def _git_head() -> str | None:
    try:
        return subprocess.check_output(
            ["git", "rev-parse", "HEAD"],
            cwd=PROJECT_ROOT,
            text=True,
            stderr=subprocess.DEVNULL,
        ).strip()
    except (OSError, subprocess.CalledProcessError):
        return None


def _exact_binding(
    target: Any,
    geometry_backend: NativeWin32Backend,
    backend: NativeBackgroundMouseBackend,
) -> ExactWindowBinding:
    window = find_window_for_pid(target.pid, geometry_backend)
    geometry = geometry_backend.client_geometry(window.hwnd)
    if geometry is None:
        raise RuntimeError("game window has no valid non-minimized client geometry")
    exact = ExactWindowBinding(window, geometry)
    if backend.window_pid(window.hwnd) != target.pid:
        raise RuntimeError("bound HWND no longer belongs to the attached PID")
    if backend.window_title(window.hwnd) != window.title:
        raise RuntimeError("bound HWND title changed during attach")
    if backend.foreground_window() == window.hwnd:
        raise RuntimeError("game must be background before the probe starts")
    return exact


def _capture_start_proof(
    *,
    target: Any,
    provider: MemoryBoardStateProvider,
    farm_target: FarmTarget,
    exact: ExactWindowBinding,
    backend: NativeBackgroundMouseBackend,
    timeout: float,
    interval: float,
    log: ArtifactLog,
) -> LobbyProof:
    deadline = time.monotonic() + timeout
    last_reason = "no lobby sample"
    while target.is_running() and time.monotonic() < deadline:
        if backend.foreground_window() == exact.window.hwnd:
            last_reason = "game is foreground"
            time.sleep(interval)
            continue
        if backend.client_geometry(exact.window.hwnd) != exact.geometry:
            raise RuntimeError("client geometry changed while waiting for B1")
        poll = provider.poll()
        if poll.combat_lifecycle is None:
            last_reason = poll.reason
            time.sleep(interval)
            continue
        lobby = read_boss_lobby_runtime(target.resolver, poll.combat_lifecycle)
        resolution = resolve_target(farm_target, lobby.candidates)
        candidate = resolution.candidate
        if (
            lobby.state is not BossLobbyState.BOSS_LOBBY
            or lobby.branch != "CHINH_PHUC_ROOM"
            or resolution.status is not TargetResolutionStatus.RESOLVED
            or candidate is None
            or not candidate.available
            or candidate.selection is not TargetSelectionState.SELECTED
            or not lobby.chinh_phuc.clean
            or lobby.chinh_phuc.button_interactable is not True
            or lobby.chinh_phuc.button_groups_allow is not True
            or lobby.chinh_phuc.is_opening_flow
            or provider.current_session_key is not None
        ):
            last_reason = f"runtime target not exact: {lobby.state.value}/{lobby.branch}/{resolution.status.value}"
            time.sleep(interval)
            continue
        provider.set_preentry_card_loadout(
            lobby.chinh_phuc.card_loadout.cards,
            sources_agree=lobby.chinh_phuc.card_loadout.sources_agree,
        )
        captures: list[tuple[ClientRgbCapture, Any, str]] = []
        for _index in range(2):
            if backend.foreground_window() == exact.window.hwnd:
                captures = []
                last_reason = "game became foreground during Start proof"
                break
            capture = capture_client_rgb(target.pid)
            if (capture.width, capture.height) != (
                exact.geometry.width,
                exact.geometry.height,
            ):
                raise RuntimeError("captured client geometry differs from binding")
            modal = locate_confirm_leave(capture.rgb, capture.width, capture.height)
            if modal.found:
                captures = []
                last_reason = "modal-like overlay is visible"
                break
            location = locate_chinh_phuc_start(
                capture.rgb, capture.width, capture.height
            )
            if (
                not location.found
                or location.normalized_point is None
                or location.normalized_rect is None
                or location.confidence < 0.90
            ):
                captures = []
                last_reason = f"Start visual proof failed: {location.reason}"
                break
            signature = entry_button_signature(
                control=location.control.value,
                normalized_rect=location.normalized_rect,
                normalized_point=location.normalized_point,
                client_size=(capture.width, capture.height),
            )
            captures.append((capture, location, signature))
            time.sleep(max(interval, 0.14))
        if len(captures) != 2:
            time.sleep(interval)
            continue
        first, second = captures
        if (
            first[2] != second[2]
            or first[1].normalized_point != second[1].normalized_point
        ):
            last_reason = "Start proof changed between captures"
            time.sleep(interval)
            continue
        log.event(
            "lobby_start_proven",
            lobby=lobby,
            target=resolution,
            normalizedPoint=second[1].normalized_point,
            normalizedRect=second[1].normalized_rect,
            signature=second[2],
            confidence=second[1].confidence,
            foregroundHwnd=backend.foreground_window(),
        )
        return LobbyProof(
            lobby,
            candidate.identity.stable_key(),
            second[1].normalized_point,
            second[1].normalized_rect,
            second[2],
            second[1].confidence,
            candidate.entry_control_address,
            second[0],
        )
    raise TimeoutError(f"B1 exact lobby/Start proof timed out: {last_reason}")


def _lobby_preflight(
    *,
    target: Any,
    provider: MemoryBoardStateProvider,
    farm_target: FarmTarget,
    proof: LobbyProof,
) -> bool:
    poll = provider.poll()
    if poll.combat_lifecycle is None:
        return False
    lobby = read_boss_lobby_runtime(target.resolver, poll.combat_lifecycle)
    resolution = resolve_target(farm_target, lobby.candidates)
    candidate = resolution.candidate
    return bool(
        provider.current_session_key is None
        and lobby.state is BossLobbyState.BOSS_LOBBY
        and lobby.branch == "CHINH_PHUC_ROOM"
        and resolution.status is TargetResolutionStatus.RESOLVED
        and candidate is not None
        and candidate.identity.stable_key() == proof.target_key
        and candidate.selection is TargetSelectionState.SELECTED
        and candidate.available
        and candidate.entry_control_address == proof.entry_control_address
        and lobby.chinh_phuc.clean
        and lobby.chinh_phuc.button_interactable is True
        and lobby.chinh_phuc.button_groups_allow is True
        and not lobby.chinh_phuc.is_opening_flow
    )


def _wait_opening_ack(
    *,
    target: Any,
    provider: MemoryBoardStateProvider,
    old_session: Any,
    timeout: float,
    interval: float,
    log: ArtifactLog,
    require_match_start_opening: bool = True,
) -> tuple[bool, GameState | None]:
    deadline = time.monotonic() + timeout
    while target.is_running() and time.monotonic() < deadline:
        poll = provider.poll()
        log.event(
            (
                "b2_ack_poll"
                if require_match_start_opening
                else "manual_entry_ack_poll"
            ),
            reason=poll.reason,
            session=poll.session_key,
            lifecycle=poll.combat_lifecycle,
            hasState=poll.state is not None,
        )
        state = poll.state
        if _entry_state_accepted(
            state,
            old_session=old_session,
            require_match_start_opening=require_match_start_opening,
        ):
            return True, state
        time.sleep(interval)
    return False, None


def _entry_state_accepted(
    state: GameState | None,
    *,
    old_session: Any,
    require_match_start_opening: bool,
) -> bool:
    """Separate strict B2 attribution from a user-performed manual entry."""

    fresh_combat = bool(
        state is not None
        and state.phase is GamePhase.COMBAT
        and state.board is not None
        and state.board.production_ready
        and state.battle.session_key is not None
        and state.battle.session_key != old_session
    )
    if not fresh_combat:
        return False
    if not require_match_start_opening:
        return True
    assert state is not None
    return bool(
        state.battle.local_move_sequence == 0
        and state.battle.last_move_sequence in (None, -1, 0)
        and state.battle.turn_number in (0, 1)
        and any("MATCH_START" in source for source in state.battle.sources)
    )


def _choose_probe_move(state: GameState) -> MoveEvaluation | None:
    if state.board is None:
        return None
    values = evaluate_all_moves(state.board)
    if not values:
        return None
    return max(
        values,
        key=lambda value: (
            int(value.sword_risk.safe),
            int(value.calculable),
            value.total.total_effective,
            -value.sword_risk.danger_score,
            -value.move.first[0],
            -value.move.first[1],
            -value.move.second[0],
            -value.move.second[1],
        ),
    )


def _wait_board_proposal(
    *,
    target: Any,
    provider: MemoryBoardStateProvider,
    backend: NativeBackgroundMouseBackend,
    exact: ExactWindowBinding,
    minimum_turn: int,
    minimum_time: int,
    timeout: float,
    interval: float,
    log: ArtifactLog,
    require_game_background: bool = True,
    dispatcher_tap: Any | None = None,
    require_first_local_turn: bool = False,
) -> BoardProposal | None:
    deadline = time.monotonic() + timeout
    dispatcher_offered: set[tuple[str, int, int, int]] = set()
    while target.is_running() and time.monotonic() < deadline:
        game_is_foreground = backend.foreground_window() == exact.window.hwnd
        if require_game_background and game_is_foreground:
            time.sleep(interval)
            continue
        poll = provider.poll()
        if dispatcher_tap is not None and poll.session_key is not None:
            match_id = poll.session_key.match_id
            dispatcher_tap.arm(match_id)
            opening_accepted = False
            for event_type, snapshot in dispatcher_tap.transport_board_snapshots(
                match_id
            ):
                identity = (
                    event_type,
                    snapshot.message_address,
                    snapshot.board_token_address,
                    snapshot.sequence,
                )
                if identity in dispatcher_offered:
                    continue
                accepted = bool(
                    event_type == "MATCH_START"
                    and provider.offer_opening_snapshot(snapshot)
                )
                log.event(
                    "board_probe_dispatcher_opening_offered",
                    eventType=event_type,
                    matchId=match_id,
                    messageAddress=snapshot.message_address,
                    sequence=snapshot.sequence,
                    accepted=accepted,
                    diagnostics=dispatcher_tap.diagnostics,
                )
                if accepted:
                    dispatcher_offered.add(identity)
                    opening_accepted = True
            if opening_accepted:
                # The first poll intentionally returned early to reserve the
                # pristine opening for external MATCH_START transport. Publish
                # that same board immediately after the snapshot is bound.
                poll = provider.poll()
        state = poll.state
        if state is None or state.phase is not GamePhase.COMBAT:
            time.sleep(interval)
            continue
        battle = state.battle
        actual_gate = ActionabilityGate.evaluate(
            state,
            GateContext(
                current_session=provider.current_session_key,
                game_foreground=game_is_foreground,
                window_valid=True,
                allow_opening_board_only=True,
                allow_authoritative_board_only_stats=True,
            ),
        )
        background_gate = ActionabilityGate.evaluate(
            state,
            GateContext(
                current_session=provider.current_session_key,
                # Harness-only transport hypothesis. Production gate remains
                # unchanged and the actual gate above must reject foreground.
                game_foreground=True,
                window_valid=True,
                allow_opening_board_only=True,
                allow_authoritative_board_only_stats=True,
            ),
        )
        log.event(
            "board_probe_gate",
            reason=poll.reason,
            actualForegroundGate=actual_gate,
            harnessNonForegroundGate=background_gate,
            turn=battle.turn_number,
            remaining=battle.turn_time_remaining_seconds,
            consecutivePasses=battle.consecutive_passes,
            consecutivePassThreshold=battle.consecutive_pass_threshold,
        )
        if (
            require_first_local_turn
            and battle.is_local_turn is True
            and (
                battle.turn_number not in (0, 1)
                or battle.local_move_sequence != 0
                or battle.last_move_sequence not in (None, -1, 0)
            )
        ):
            log.event(
                "board_probe_first_local_turn_missed",
                turn=battle.turn_number,
                localMoveSequence=battle.local_move_sequence,
                lastMoveSequence=battle.last_move_sequence,
                sources=battle.sources,
            )
            return None
        if (
            battle.consecutive_passes is not None
            and battle.consecutive_passes >= 2
            and not background_gate.actionable
        ):
            log.event(
                "board_probe_idle_limit_stop",
                consecutivePasses=battle.consecutive_passes,
                consecutivePassThreshold=battle.consecutive_pass_threshold,
                gate=background_gate,
                reason="two consecutive passes observed before an actionable proposal",
            )
            return None
        if (
            (
                require_game_background
                and actual_gate.reason is not GateReason.GAME_NOT_FOREGROUND
            )
            or not background_gate.actionable
            or battle.turn_number is None
            or battle.turn_number < minimum_turn
            or battle.turn_time_remaining_seconds is None
            or battle.turn_time_remaining_seconds < minimum_time
            or battle.local_move_sequence is None
            or battle.session_key is None
            or not battle.local_username
            or (
                require_first_local_turn
                and battle.is_first_local_turn is not True
            )
        ):
            time.sleep(interval)
            continue
        evaluation = _choose_probe_move(state)
        if evaluation is None:
            time.sleep(interval)
            continue
        pre = SwapPreState(
            battle.session_key.match_id,
            battle.turn_number,
            battle.local_username,
            battle.local_move_sequence,
            evaluation.move.first,
            evaluation.move.second,
        )
        _service, runtime = read_match_runtime(target)
        if not _runtime_preflight(pre, runtime, minimum_time):
            time.sleep(interval)
            continue
        return BoardProposal(state, evaluation, pre)
    return None


def _runtime_preflight(
    pre: SwapPreState, runtime: MatchRuntime, minimum_time: int
) -> bool:
    return bool(
        runtime.match_id == pre.match_id
        and runtime.turn == pre.turn
        and runtime.current_player
        and runtime.local_username
        and runtime.local_username.casefold() == pre.local_username.casefold()
        and runtime.current_player.casefold() == runtime.local_username.casefold()
        and runtime.local_move_sequence == pre.local_move_sequence
        and runtime.remaining is not None
        and runtime.remaining >= minimum_time
    )


def _wait_swap_ack(
    *,
    target: Any,
    pre: SwapPreState,
    timeout: float,
    interval: float,
    log: ArtifactLog,
) -> tuple[bool, bool, MatchRuntime | None]:
    deadline = time.monotonic() + timeout
    last: MatchRuntime | None = None
    while target.is_running() and time.monotonic() < deadline:
        _service, runtime = read_match_runtime(target)
        last = runtime
        accepted = runtime_proves_swap_accepted(pre, runtime)
        log.event("swap_ack_poll", pre=pre, runtime=runtime, accepted=accepted)
        if accepted:
            return True, False, runtime
        if (
            runtime.match_id == pre.match_id
            and runtime.local_move_sequence is not None
            and runtime.local_move_sequence > pre.local_move_sequence
        ):
            expected_coordinates = (
                pre.first[1],
                7 - pre.first[0],
                pre.second[1],
                7 - pre.second[0],
            )
            observed_coordinates = (
                runtime.last_move_from_col,
                runtime.last_move_from_row,
                runtime.last_move_to_col,
                runtime.last_move_to_row,
            )
            exact_pending_transition = bool(
                runtime.local_move_sequence == pre.local_move_sequence + 1
                and runtime.last_move_sequence == runtime.local_move_sequence
                and observed_coordinates == expected_coordinates
            )
            if not exact_pending_transition:
                return False, True, runtime
        time.sleep(interval)
    return False, False, last


def _arm_from_console(token: str, stop: StopController) -> bool:
    print(
        f"Nhập chính xác '{token}' rồi Enter để arm đúng một lệnh; "
        "gõ STOP hoặc nhấn F9 để dừng.",
        flush=True,
    )
    try:
        value = input().strip()
    except (EOFError, KeyboardInterrupt):
        return False
    return not stop.requested() and value == token


def _transport_for(
    backend: NativeBackgroundMouseBackend,
    stop: StopController,
    log: ArtifactLog,
) -> BoundedBackgroundMouseTransport:
    return BoundedBackgroundMouseTransport(
        backend,
        stop_requested=stop.requested,
        event_sink=log.sink,
    )


def _run_swap_stage(
    *,
    stage: str,
    command: ProbeCommand,
    arm_token: str,
    target: Any,
    provider: MemoryBoardStateProvider,
    backend: NativeBackgroundMouseBackend,
    exact: ExactWindowBinding,
    stop: StopController,
    log: ArtifactLog,
    minimum_turn: int,
    minimum_time: int,
    board_timeout: float,
    ack_timeout: float,
    interval: float,
    prearmed: bool = False,
) -> tuple[ProbeOutcome, SwapPreState | None, TransportResult | None]:
    # Arm the primitive before waiting for a local turn.  Waiting until after
    # a proposal is selected would consume most of the short turn timer while
    # the user confirms the stage, making the supposedly exact proposal stale.
    # The later preflight still binds the one arm to a fresh session/turn/move.
    if not prearmed and not _arm_from_console(arm_token, stop):
        log.event(f"{stage.lower()}_not_run", reason="arm token not supplied")
        return ProbeOutcome.NOT_RUN, None, None
    proposal = _wait_board_proposal(
        target=target,
        provider=provider,
        backend=backend,
        exact=exact,
        minimum_turn=minimum_turn,
        minimum_time=minimum_time,
        timeout=board_timeout,
        interval=interval,
        log=log,
    )
    if proposal is None or stop.requested():
        log.event(f"{stage.lower()}_not_run", reason="no fresh actionable local turn")
        return ProbeOutcome.NOT_RUN, None, None
    move = proposal.evaluation.move
    plan = map_swap_to_pixels(
        move.first,
        move.second,
        BoardCalibration(),
        exact.geometry,
    )
    log.event(
        f"{stage.lower()}_ready",
        preState=proposal.pre,
        boardHash=proposal.state.battle.board_hash,
        proposal=proposal.evaluation,
        coordinatePlan=plan,
        foregroundHwnd=backend.foreground_window(),
        cursor=backend.cursor_pos(),
    )
    print(
        f"{stage} READY: swap {move.first} -> {move.second}, "
        f"turn {proposal.pre.turn}.",
        flush=True,
    )
    transport = _transport_for(backend, stop, log)
    identity = (
        f"{stage}:{proposal.pre.match_id}:{proposal.pre.turn}:"
        f"{proposal.pre.local_move_sequence}:{move.first}->{move.second}"
    )
    transport.arm(command, exact, identity)
    preflight: Callable[[], bool] = lambda: _runtime_preflight(
        proposal.pre, read_match_runtime(target)[1], minimum_time
    )
    if command is ProbeCommand.BOARD_TWO_CLICK:
        delivery = transport.send_board_two_click(plan, preflight=preflight)
    else:
        delivery = transport.send_board_drag(plan, preflight=preflight)
    accepted = explicit_reject = False
    post: MatchRuntime | None = None
    if delivery.status is TransportStatus.QUEUED:
        accepted, explicit_reject, post = _wait_swap_ack(
            target=target,
            pre=proposal.pre,
            timeout=ack_timeout,
            interval=interval,
            log=log,
        )
    outcome = classify_probe_outcome(
        delivery,
        authoritative_ack=accepted if delivery.fully_queued else None,
        explicit_reject=explicit_reject,
    )
    log.event(
        f"{stage.lower()}_finished",
        delivery=delivery,
        outcome=outcome,
        postState=post,
        accepted=accepted,
        explicitReject=explicit_reject,
        noRetry=True,
    )
    return outcome, proposal.pre, delivery


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    target = parser.add_mutually_exclusive_group(required=True)
    target.add_argument("--boss-id")
    target.add_argument("--boss-name")
    mode = parser.add_mutually_exclusive_group()
    mode.add_argument(
        "--live-sequence",
        action="store_true",
        help="after zero-input B1, request explicit console arms for B2/B3/B4",
    )
    mode.add_argument(
        "--board-sequence",
        action="store_true",
        help=(
            "after zero-input B1, arm B3, wait for a user-performed Start, "
            "then probe B3/B4 without claiming the manual entry as background"
        ),
    )
    parser.add_argument(
        "--board-primitive",
        choices=("two_click", "drag"),
        default="two_click",
        help="board primitive for --board-sequence; each run tests only one armed primitive",
    )
    parser.add_argument("--artifacts", type=Path)
    parser.add_argument("--lobby-timeout", type=float, default=60.0)
    parser.add_argument("--opening-timeout", type=float, default=40.0)
    parser.add_argument("--board-timeout", type=float, default=120.0)
    parser.add_argument("--ack-timeout", type=float, default=12.0)
    parser.add_argument("--interval", type=float, default=0.12)
    parser.add_argument("--minimum-action-time", type=int, default=4)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    return parser


def _validate_args(args: argparse.Namespace) -> None:
    if args.board_primitive != "two_click" and not args.board_sequence:
        raise ValueError("--board-primitive drag requires --board-sequence")
    if not 0.08 <= args.interval <= 0.50:
        raise ValueError("--interval must be between 0.08 and 0.50 seconds")
    if not 5 <= args.lobby_timeout <= 600:
        raise ValueError("--lobby-timeout must be between 5 and 600 seconds")
    if not 5 <= args.opening_timeout <= 300:
        raise ValueError("--opening-timeout must be between 5 and 300 seconds")
    if not 10 <= args.board_timeout <= 600:
        raise ValueError("--board-timeout must be between 10 and 600 seconds")
    if not 2 <= args.ack_timeout <= 60:
        raise ValueError("--ack-timeout must be between 2 and 60 seconds")
    if not 2 <= args.minimum_action_time <= 10:
        raise ValueError("--minimum-action-time must be between 2 and 10 seconds")
    if not 1 <= args.max_region_mib <= 32 or not 1 <= args.chunk_mib <= 16:
        raise ValueError("memory scan bounds are invalid")


def run(args: argparse.Namespace) -> int:
    _validate_args(args)
    artifact_root = (
        args.artifacts
        or PROJECT_ROOT
        / "logs"
        / "phase4a1"
        / f"probe_{datetime.now():%Y%m%d_%H%M%S}"
    ).resolve()
    log = ArtifactLog(artifact_root)
    stop = StopController()
    stop.start()
    exit_code = 2
    try:
        with ExitStack() as stack:
            stack.enter_context(
                AutomationControllerLease(
                    current_app_paths().logs_root / ".automation_controller.lock"
                )
            )
            target = stack.enter_context(attach_target())
            geometry_backend = NativeWin32Backend()
            backend = NativeBackgroundMouseBackend(geometry_backend)
            exact = _exact_binding(target, geometry_backend, backend)
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
                transport="PostMessageW harness only",
                productionIntegration=False,
                artifacts=str(artifact_root),
            )
            log.event(
                "probe_started",
                summary=log.summary,
                foregroundHwnd=backend.foreground_window(),
                cursor=backend.cursor_pos(),
                b1ZeroInput=True,
            )
            print(f"Phase 4A.1 artifacts: {artifact_root}", flush=True)
            print("F9 = Emergency Stop. Game phải visible, không minimized và không foreground.", flush=True)

            cursor_before = backend.cursor_pos()
            proof = _capture_start_proof(
                target=target,
                provider=provider,
                farm_target=farm_target,
                exact=exact,
                backend=backend,
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
            time.sleep(1.0)
            cursor_after = backend.cursor_pos()
            b1_pass = bool(
                not stop.requested()
                and backend.foreground_window() != exact.window.hwnd
                and backend.client_geometry(exact.window.hwnd) == exact.geometry
                and cursor_before == cursor_after
            )
            log.summary["stages"]["B1"] = "ACCEPTED" if b1_pass else "FAILED"
            log.event(
                "b1_finished",
                result=log.summary["stages"]["B1"],
                proof=proof,
                cursorBefore=cursor_before,
                cursorAfter=cursor_after,
                zeroInput=True,
                foregroundHwnd=backend.foreground_window(),
            )
            log.save()
            if not b1_pass:
                raise RuntimeError("B1 exact nonforeground zero-input proof failed")
            print("B1 ACCEPTED: exact binding/target/Start, zero input, cursor unchanged.", flush=True)
            if not args.live_sequence and not args.board_sequence:
                log.summary.update(status="B1_COMPLETE_ZERO_INPUT", stopReason="LIVE_SEQUENCE_NOT_ARMED")
                exit_code = 0
                return exit_code

            opening_state: GameState | None = None
            b3_prearmed = False
            if args.board_sequence:
                manual_stage = "B3" if args.board_primitive == "two_click" else "B4"
                if not _arm_from_console(f"ARM {manual_stage}", stop):
                    log.summary.update(
                        status="STOPPED", stopReason=f"{manual_stage}_NOT_ARMED"
                    )
                    return 0
                b3_prearmed = True
                old_session = provider.current_session_key
                log.event(
                    "manual_entry_requested",
                    target=proof.target_key,
                    startSignature=proof.signature,
                    harnessInput=False,
                    backgroundCapabilityClaim=False,
                    prearmedStage=manual_stage,
                    boardPrimitive=args.board_primitive,
                )
                print(
                    f"{manual_stage} đã arm. Hãy tự click Start trong game, rồi đưa cửa sổ "
                    "Codex/terminal lên foreground ngay; harness không click Start.",
                    flush=True,
                )
                accepted, opening_state = _wait_opening_ack(
                    target=target,
                    provider=provider,
                    old_session=old_session,
                    timeout=args.opening_timeout,
                    interval=args.interval,
                    log=log,
                    require_match_start_opening=False,
                )
                log.event(
                    "manual_entry_finished",
                    accepted=accepted,
                    openingState=opening_state,
                    harnessInput=False,
                    backgroundCapabilityClaim=False,
                )
                if not accepted or opening_state is None:
                    log.summary.update(
                        status="STOPPED", stopReason="MANUAL_ENTRY_OPENING_UNCONFIRMED"
                    )
                    return 2
            else:
                if not _arm_from_console("ARM B2", stop):
                    log.summary.update(status="STOPPED", stopReason="B2_NOT_ARMED")
                    return 0
                # Recapture after the human wait so B2 never reuses stale pixels.
                proof = _capture_start_proof(
                    target=target,
                    provider=provider,
                    farm_target=farm_target,
                    exact=exact,
                    backend=backend,
                    timeout=args.lobby_timeout,
                    interval=args.interval,
                    log=log,
                )
                old_session = provider.current_session_key
                if not _lobby_preflight(
                    target=target,
                    provider=provider,
                    farm_target=farm_target,
                    proof=proof,
                ):
                    log.summary.update(status="STOPPED", stopReason="B2_RUNTIME_PREFLIGHT_CHANGED")
                    log.event("b2_not_run", reason=log.summary["stopReason"])
                    return 2
                b2_transport = _transport_for(backend, stop, log)
                b2_identity = f"B2:{proof.signature}:{proof.target_key}"
                b2_transport.arm(
                    ProbeCommand.START_SINGLE_CLICK, exact, b2_identity
                )
                delivery = b2_transport.send_start_single_click(
                    proof.normalized_point,
                    # The complete target/room/button preflight above is the
                    # action fence. Between the three queued mouse messages keep
                    # the callback cheap so DOWN/UP cannot be separated by a heap
                    # scan; the transport still revalidates PID/title/geometry,
                    # non-minimized and nonforeground before every message.
                    preflight=lambda: (
                        target.is_running()
                        and provider.current_session_key is None
                    ),
                )
                accepted = False
                if delivery.status is TransportStatus.QUEUED:
                    accepted, opening_state = _wait_opening_ack(
                        target=target,
                        provider=provider,
                        old_session=old_session,
                        timeout=args.opening_timeout,
                        interval=args.interval,
                        log=log,
                    )
                b2_outcome = classify_probe_outcome(
                    delivery,
                    authoritative_ack=accepted if delivery.fully_queued else None,
                )
                log.summary["stages"]["B2"] = b2_outcome.value
                log.summary["inputCounts"]["singleClick"] = (
                    1 if delivery.records else 0
                )
                log.event(
                    "b2_finished",
                    delivery=delivery,
                    outcome=b2_outcome,
                    openingState=opening_state,
                    noRetry=True,
                )
                log.save()
                print(f"B2 {b2_outcome.value}", flush=True)
                if b2_outcome is not ProbeOutcome.ACCEPTED or opening_state is None:
                    log.summary.update(status="STOPPED", stopReason="B2_NOT_ACCEPTED")
                    return 2

            if args.board_sequence and args.board_primitive == "drag":
                b4_outcome, _b4_pre, b4_delivery = _run_swap_stage(
                    stage="B4",
                    command=ProbeCommand.BOARD_DRAG,
                    arm_token="ARM B4",
                    target=target,
                    provider=provider,
                    backend=backend,
                    exact=exact,
                    stop=stop,
                    log=log,
                    minimum_turn=opening_state.battle.turn_number or 0,
                    minimum_time=args.minimum_action_time,
                    board_timeout=args.board_timeout,
                    ack_timeout=args.ack_timeout,
                    interval=args.interval,
                    prearmed=True,
                )
                log.summary["stages"]["B4"] = b4_outcome.value
                log.summary["inputCounts"]["drag"] = (
                    1 if b4_delivery is not None and b4_delivery.records else 0
                )
                log.summary.update(
                    status=(
                        "LIVE_COMPLETE"
                        if b4_outcome is ProbeOutcome.ACCEPTED
                        else "STOPPED"
                    ),
                    stopReason=(
                        None
                        if b4_outcome is ProbeOutcome.ACCEPTED
                        else "B4_NOT_ACCEPTED"
                    ),
                    boardCapability=(
                        "DRAG_ONLY"
                        if b4_outcome is ProbeOutcome.ACCEPTED
                        else "UNKNOWN"
                    ),
                    noRetry=True,
                )
                print(f"B4 {b4_outcome.value}", flush=True)
                return 0 if b4_outcome is ProbeOutcome.ACCEPTED else 2

            b3_outcome, b3_pre, b3_delivery = _run_swap_stage(
                stage="B3",
                command=ProbeCommand.BOARD_TWO_CLICK,
                arm_token="ARM B3",
                target=target,
                provider=provider,
                backend=backend,
                exact=exact,
                stop=stop,
                log=log,
                minimum_turn=opening_state.battle.turn_number or 0,
                minimum_time=args.minimum_action_time,
                board_timeout=args.board_timeout,
                ack_timeout=args.ack_timeout,
                interval=args.interval,
                prearmed=b3_prearmed,
            )
            log.summary["stages"]["B3"] = b3_outcome.value
            log.summary["inputCounts"]["twoClick"] = (
                1 if b3_delivery is not None and b3_delivery.records else 0
            )
            log.save()
            print(f"B3 {b3_outcome.value}", flush=True)
            if b3_outcome is not ProbeOutcome.ACCEPTED or b3_pre is None:
                log.summary.update(status="STOPPED", stopReason="B3_NOT_ACCEPTED")
                return 2

            b4_outcome, _b4_pre, b4_delivery = _run_swap_stage(
                stage="B4",
                command=ProbeCommand.BOARD_DRAG,
                arm_token="ARM B4",
                target=target,
                provider=provider,
                backend=backend,
                exact=exact,
                stop=stop,
                log=log,
                minimum_turn=b3_pre.turn + 2,
                minimum_time=args.minimum_action_time,
                board_timeout=args.board_timeout,
                ack_timeout=args.ack_timeout,
                interval=args.interval,
            )
            log.summary["stages"]["B4"] = b4_outcome.value
            log.summary["inputCounts"]["drag"] = (
                1 if b4_delivery is not None and b4_delivery.records else 0
            )
            if b4_outcome is ProbeOutcome.PARTIAL_INPUT:
                log.summary.update(status="FAIL", stopReason="B4_PARTIAL_INPUT")
                return 2
            board_capability = (
                "TWO_CLICK_AND_DRAG"
                if b4_outcome is ProbeOutcome.ACCEPTED
                else "TWO_CLICK_ONLY"
            )
            log.summary.update(
                status="LIVE_COMPLETE",
                stopReason=None,
                boardCapability=board_capability,
                noRetry=True,
            )
            exit_code = 0
            return exit_code
    except (TimeoutError, RuntimeError) as exc:
        log.summary.update(
            status="STOPPED",
            stopReason=f"{type(exc).__name__}: {exc}",
        )
        log.event("probe_stopped", reason=log.summary["stopReason"], noInput=(
            all(value == 0 for value in log.summary["inputCounts"].values())
        ))
        print(f"4A.1 stopped: {log.summary['stopReason']}", flush=True)
        return exit_code
    except Exception as exc:
        log.summary.update(
            status="FAILED",
            stopReason=f"{type(exc).__name__}: {exc}",
        )
        log.event("probe_failed", error=log.summary["stopReason"])
        print(f"4A.1 stopped: {log.summary['stopReason']}", flush=True)
        return exit_code
    finally:
        stop.stop()
        log.close()


def main() -> int:
    for stream in (sys.stdout, sys.stderr):
        reconfigure = getattr(stream, "reconfigure", None)
        if callable(reconfigure):
            reconfigure(encoding="utf-8", errors="replace")
    return run(build_parser().parse_args())


if __name__ == "__main__":
    raise SystemExit(main())
