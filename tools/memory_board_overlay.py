"""Phase 2B.5 DTO-only shadow watcher with screenshot overlays.

This process opens the game read-only and never imports an input executor.  It
may reuse the V1 Python environment for cv2/mss and the unchanged V1 solver,
but the V1 bot process is not required and no click is issued here.
"""

from __future__ import annotations

import argparse
import ctypes
from ctypes import wintypes
from dataclasses import asdict, is_dataclass
from datetime import datetime
import json
import os
from pathlib import Path
import re
import sys
import time
from typing import Any, Sequence


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)


def _ensure_visual_runtime(v1_root: Path) -> None:
    try:
        import cv2  # noqa: F401
        import mss  # noqa: F401
        import numpy  # noqa: F401
        return
    except ImportError as exc:
        v1_python = (v1_root / ".venv" / "Scripts" / "python.exe").resolve()
        if v1_python.is_file() and Path(sys.executable).resolve() != v1_python:
            os.execv(
                str(v1_python),
                [str(v1_python), str(Path(__file__).resolve()), *sys.argv[1:]],
            )
        raise RuntimeError(
            "visual audit needs cv2, numpy and mss; no V1 bot process is needed"
        ) from exc


from pokiguard_v2.audit_overlay import (  # noqa: E402
    BoardGeometry,
    screen_move_to_runtime,
)
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
    ProviderSetupError,
    utc_timestamp,
)
from pokiguard_v2.state import GamePhase  # noqa: E402
from pokiguard_v2.v1_solver_adapter import (  # noqa: E402
    V1ShadowSession,
    V1SolverAdapter,
)
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.runtime_common import attach_target, hex_pointer  # noqa: E402


user32 = ctypes.WinDLL("user32", use_last_error=True)


class POINT(ctypes.Structure):
    _fields_ = [("x", wintypes.LONG), ("y", wintypes.LONG)]


class RECT(ctypes.Structure):
    _fields_ = [
        ("left", wintypes.LONG),
        ("top", wintypes.LONG),
        ("right", wintypes.LONG),
        ("bottom", wintypes.LONG),
    ]


def _client_region_for_pid(pid: int) -> tuple[int, int, int, int, str]:
    matches: list[tuple[int, str]] = []
    callback_type = ctypes.WINFUNCTYPE(wintypes.BOOL, wintypes.HWND, wintypes.LPARAM)

    @callback_type
    def callback(hwnd: int, _lparam: int) -> bool:
        window_pid = wintypes.DWORD()
        user32.GetWindowThreadProcessId(hwnd, ctypes.byref(window_pid))
        if window_pid.value != pid or not user32.IsWindowVisible(hwnd):
            return True
        length = user32.GetWindowTextLengthW(hwnd)
        title_buffer = ctypes.create_unicode_buffer(length + 1)
        user32.GetWindowTextW(hwnd, title_buffer, length + 1)
        if title_buffer.value:
            matches.append((int(hwnd), title_buffer.value))
        return True

    if not user32.EnumWindows(callback, 0):
        raise ctypes.WinError(ctypes.get_last_error())
    if not matches:
        raise RuntimeError(f"no visible window belongs to Pokiguard PID {pid}")
    hwnd, title = max(matches, key=lambda item: len(item[1]))
    rect = RECT()
    if not user32.GetClientRect(hwnd, ctypes.byref(rect)):
        raise ctypes.WinError(ctypes.get_last_error())
    origin = POINT(0, 0)
    if not user32.ClientToScreen(hwnd, ctypes.byref(origin)):
        raise ctypes.WinError(ctypes.get_last_error())
    width = int(rect.right - rect.left)
    height = int(rect.bottom - rect.top)
    if width <= 0 or height <= 0:
        raise RuntimeError("Pokiguard client area is minimized or empty")
    return origin.x, origin.y, width, height, title


def _jsonable(value: Any) -> Any:
    if is_dataclass(value):
        return {key: _jsonable(item) for key, item in asdict(value).items()}
    if isinstance(value, dict):
        return {str(key): _jsonable(item) for key, item in value.items()}
    if isinstance(value, (tuple, list, set)):
        return [_jsonable(item) for item in value]
    return value


def _write_event(log: Any, event: str, **fields: Any) -> None:
    log.write(
        json.dumps(
            {"timestamp": utc_timestamp(), "event": event, **_jsonable(fields)},
            ensure_ascii=False,
            separators=(",", ":"),
        )
        + "\n"
    )


def _safe_component(value: str) -> str:
    return re.sub(r"[^A-Za-z0-9_.-]+", "_", value).strip("_")[:80] or "unknown"


GEM_COLORS = {
    "sword": (60, 60, 230),
    "mana": (230, 130, 40),
    "rage": (40, 40, 240),
    "shield": (220, 70, 180),
    "health": (60, 210, 60),
    "drain": (235, 235, 235),
}


def _capture_overlay(
    state: Any,
    geometry: BoardGeometry,
    pid: int,
) -> tuple[Any, dict[str, Any]]:
    import cv2
    import mss
    import numpy as np

    left, top, width, height, title = _client_region_for_pid(pid)
    with mss.MSS() as capture:
        shot = capture.grab(
            {"left": left, "top": top, "width": width, "height": height}
        )
    image = np.asarray(shot, dtype=np.uint8)[:, :, :3].copy()
    half_x, half_y = geometry.half_cell(width, height)
    cells: list[dict[str, Any]] = []
    for row in state.board.cells:
        for cell in row:
            center_x, center_y = geometry.center(width, height, cell.row, cell.col)
            color = GEM_COLORS[cell.gem.value]
            cv2.rectangle(
                image,
                (center_x - half_x, center_y - half_y),
                (center_x + half_x, center_y + half_y),
                color,
                2,
            )
            label = f"{cell.gem.value.upper()} x{cell.multiplier}"
            (text_width, text_height), _baseline = cv2.getTextSize(
                label, cv2.FONT_HERSHEY_SIMPLEX, 0.32, 1
            )
            text_x = max(0, min(width - text_width - 2, center_x - half_x + 2))
            text_y = max(text_height + 2, center_y - half_y + text_height + 3)
            cv2.rectangle(
                image,
                (text_x - 1, text_y - text_height - 2),
                (text_x + text_width + 1, text_y + 2),
                (0, 0, 0),
                -1,
            )
            cv2.putText(
                image,
                label,
                (text_x, text_y),
                cv2.FONT_HERSHEY_SIMPLEX,
                0.32,
                color,
                1,
                cv2.LINE_AA,
            )
            cells.append(
                {
                    "screenRow": cell.row,
                    "runtimeRow": 7 - cell.row,
                    "col": cell.col,
                    "gem": cell.gem.value,
                    "multiplier": cell.multiplier,
                    "centerClient": {"x": center_x, "y": center_y},
                    "centerScreen": {"x": left + center_x, "y": top + center_y},
                }
            )
    return image, {
        "windowTitle": title,
        "clientRegion": {
            "left": left,
            "top": top,
            "width": width,
            "height": height,
        },
        "geometry": asdict(geometry),
        "cells": cells,
    }


def _save_audit(
    audit_root: Path,
    state: Any,
    decision: Any,
    move_coordinates: Any,
    dot_audit: Any,
    geometry: BoardGeometry,
    pid: int,
) -> tuple[Path, Path]:
    import cv2

    session = state.battle.session_key
    if session is None:
        raise ValueError("accepted state has no CombatSessionKey")
    session_dir = audit_root / (
        f"session_{session.lifecycle_epoch:03d}_{_safe_component(session.match_id)}"
    )
    session_dir.mkdir(parents=True, exist_ok=True)
    stem = f"seq_{state.battle.srv_seq}_{state.battle.board_hash[:12]}"
    image_path = session_dir / f"{stem}.png"
    json_path = session_dir / f"{stem}.json"
    image, capture_metadata = _capture_overlay(state, geometry, pid)
    ok, encoded = cv2.imencode(".png", image)
    if not ok:
        raise RuntimeError("cv2 failed to encode overlay PNG")
    encoded.tofile(str(image_path))
    payload = {
        "timestamp": state.timestamp,
        "sessionKey": session,
        "matchId": state.battle.match_id,
        "boardInstance": hex_pointer(state.battle.board_instance),
        "srvSeq": state.battle.srv_seq,
        "boardHash": state.battle.board_hash,
        "sources": state.battle.sources,
        "dtoAcceptance": {
            "cellCount": 64,
            "coordinatesCompleteUnique": True,
            "knownTags": True,
            "multipliersInRange": True,
            "stable": state.battle.stable,
        },
        "dotAudit": dot_audit,
        "solverDecision": decision,
        "moveCoordinates": move_coordinates,
        **capture_metadata,
    }
    json_path.write_text(
        json.dumps(_jsonable(payload), ensure_ascii=False, indent=2),
        encoding="utf-8",
    )
    return image_path, json_path


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(
        description="DTO-only memory board watcher + visual overlay (NO INPUT)"
    )
    parser.add_argument("--watch", action="store_true")
    parser.add_argument("--v1-root", type=Path, default=Path(r"D:\PokiguardAuto"))
    parser.add_argument("--log", type=Path)
    parser.add_argument("--audit-root", type=Path, default=PROJECT_ROOT / "logs" / "audit")
    parser.add_argument("--scan-interval", type=float, default=0.15)
    parser.add_argument("--matches", type=int, default=2)
    parser.add_argument("--min-snapshots", type=int, default=20)
    parser.add_argument("--timeout", type=float, default=0.0)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument("--first-center-x", type=float, default=0.360)
    parser.add_argument("--first-center-y", type=float, default=0.150)
    parser.add_argument("--step-x", type=float, default=0.0410)
    parser.add_argument("--step-y", type=float, default=0.0760)
    return parser


def run(args: argparse.Namespace) -> int:
    if not args.watch:
        raise ValueError("start the Phase 2B.5 watcher with --watch")
    if not 0.05 <= args.scan_interval <= 5.0:
        raise ValueError("--scan-interval must be between 0.05 and 5 seconds")
    if args.matches < 1 or args.min_snapshots < 1 or args.timeout < 0:
        raise ValueError("matches/snapshots must be positive and timeout non-negative")
    _ensure_visual_runtime(args.v1_root)
    geometry = BoardGeometry(
        args.first_center_x,
        args.first_center_y,
        args.step_x,
        args.step_y,
    )
    log_path = (
        args.log
        or PROJECT_ROOT
        / "logs"
        / f"phase2b5_acceptance_{datetime.now():%Y%m%d_%H%M%S}.jsonl"
    ).resolve()
    audit_root = args.audit_root.resolve()
    log_path.parent.mkdir(parents=True, exist_ok=True)
    audit_root.mkdir(parents=True, exist_ok=True)
    adapter = V1SolverAdapter(args.v1_root)
    solver_session = V1ShadowSession()

    with attach_target() as target, log_path.open(
        "a", encoding="utf-8", buffering=1
    ) as log:
        provider = MemoryBoardStateProvider(
            target,
            MemoryProviderConfig(
                max_region_mib=args.max_region_mib,
                chunk_mib=args.chunk_mib,
                required_confirmations=2,
                require_lobby_start=True,
            ),
        )
        started = time.monotonic()
        snapshots = 0
        completed_matches = 0
        saw_combat = False
        previous_status: tuple[Any, ...] | None = None
        dot_missing_history: list[list[list[int]]] = []
        _write_event(
            log,
            "audit_started",
            pid=target.pid,
            architecture=target.architecture,
            gameassemblyBase=hex_pointer(target.game_assembly.base),
            gameassemblySize=target.game_assembly.size,
            access=["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"],
            mode="DTO_ONLY_SHADOW_NO_INPUT",
            inputCalls=False,
            requiredMatches=args.matches,
            requiredSnapshots=args.min_snapshots,
            geometry=geometry,
        )
        print(
            f"Phase 2B.5 ready (NO INPUT), PID {target.pid}; log: {log_path}",
            flush=True,
        )
        print(
            "Play manually; watcher auto-detects lobby/combat and never clicks.",
            flush=True,
        )
        try:
            while target.is_running():
                if args.timeout and time.monotonic() - started >= args.timeout:
                    _write_event(log, "audit_timeout")
                    break
                poll_started = time.monotonic()
                result = provider.poll()
                elapsed_ms = round((time.monotonic() - poll_started) * 1000, 3)
                dot = result.render_crosscheck
                status = (
                    result.reason,
                    result.confirmations,
                    result.session_key,
                    dot.matches if dot is not None else None,
                    len(dot.missing) if dot is not None else None,
                    len(dot.ambiguous) if dot is not None else None,
                    len(dot.mismatches) if dot is not None else None,
                    result.dto_rejections,
                )
                if status != previous_status:
                    _write_event(
                        log,
                        "provider_status",
                        reason=result.reason,
                        confirmations=result.confirmations,
                        sessionKey=result.session_key,
                        pollElapsedMs=elapsed_ms,
                        dotAudit=dot,
                        dtoRejections=result.dto_rejections,
                        scan=provider.scan_diagnostics,
                    )
                    previous_status = status
                if dot is not None:
                    missing = [[row, col] for row, col in dot.missing]
                    if not dot_missing_history or missing != dot_missing_history[-1]:
                        dot_missing_history.append(missing)
                        _write_event(
                            log,
                            "dot_coverage_changed",
                            sessionKey=result.session_key,
                            found=dot.matches
                            + len(dot.mismatches)
                            + len(dot.ambiguous),
                            missing=missing,
                            ambiguous=dot.ambiguous,
                            multiplierMismatches=dot.mismatches,
                            dtoStillComplete=True,
                        )
                if result.lifecycle_event is not None:
                    _write_event(
                        log,
                        "lifecycle",
                        transition=result.lifecycle_event,
                        reason=result.reason,
                        sessionKey=result.session_key,
                    )
                    if result.lifecycle_event in {"board_found", "session_changed"}:
                        saw_combat = True
                        solver_session = V1ShadowSession()
                    elif result.lifecycle_event == "board_lost" and saw_combat:
                        completed_matches += 1
                        if (
                            completed_matches >= args.matches
                            and snapshots >= args.min_snapshots
                        ):
                            break

                state = result.state
                if (
                    state is None
                    or state.phase is not GamePhase.COMBAT
                    or not result.publish
                ):
                    time.sleep(args.scan_interval)
                    continue
                decision = adapter.decide(state, session=solver_session)
                move_coordinates = screen_move_to_runtime(
                    decision.first, decision.second
                )
                try:
                    image_path, json_path = _save_audit(
                        audit_root,
                        state,
                        decision,
                        move_coordinates,
                        result.render_crosscheck,
                        geometry,
                        target.pid,
                    )
                except (OSError, RuntimeError, ValueError) as exc:
                    _write_event(
                        log,
                        "overlay_rejected",
                        sessionKey=state.battle.session_key,
                        srvSeq=state.battle.srv_seq,
                        reason=str(exc),
                    )
                    time.sleep(args.scan_interval)
                    continue
                snapshots += 1
                _write_event(
                    log,
                    "accepted_snapshot",
                    ordinal=snapshots,
                    sessionKey=state.battle.session_key,
                    matchId=state.battle.match_id,
                    boardInstance=hex_pointer(state.battle.board_instance),
                    srvSeq=state.battle.srv_seq,
                    boardHash=state.battle.board_hash,
                    sources=state.battle.sources,
                    cells=[
                        {
                            "screenRow": cell.row,
                            "runtimeRow": 7 - cell.row,
                            "col": cell.col,
                            "gem": cell.gem.value,
                            "multiplier": cell.multiplier,
                        }
                        for row in state.board.cells
                        for cell in row
                    ],
                    dotAudit=result.render_crosscheck,
                    solverDecision=decision,
                    moveCoordinates=move_coordinates,
                    overlayPng=str(image_path),
                    auditJson=str(json_path),
                )
                move_text = (
                    f"{decision.first}->{decision.second}"
                    if decision.first is not None
                    else decision.solver_action
                )
                print(
                    f"ACCEPT {snapshots}/{args.min_snapshots} "
                    f"session={state.battle.session_key.lifecycle_epoch} "
                    f"seq={state.battle.srv_seq} move(screen)={move_text} "
                    f"score={decision.score}",
                    flush=True,
                )
                time.sleep(args.scan_interval)
        finally:
            _write_event(
                log,
                "audit_summary",
                acceptedSnapshots=snapshots,
                completedMatches=completed_matches,
                sawCombat=saw_combat,
                providerMetrics=provider.metrics,
                dotMissingTransitions=dot_missing_history,
                noInput=True,
            )
        print(
            f"Watcher stopped: snapshots={snapshots}, matches={completed_matches}; "
            f"log: {log_path}",
            flush=True,
        )
        return 0 if snapshots >= args.min_snapshots and completed_matches >= args.matches else 2


def main(argv: Sequence[str] | None = None) -> int:
    try:
        return run(build_parser().parse_args(argv))
    except KeyboardInterrupt:
        print("Watcher stopped by user.")
        return 130
    except (
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
