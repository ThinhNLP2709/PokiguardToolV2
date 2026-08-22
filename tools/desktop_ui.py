#!/usr/bin/env python3
"""Launch the Phase 2E.1 read-only desktop control UI.

This entry point has no FarmRunner, boss-entry, postmatch, recovery, hotkey,
mouse, or keyboard command path.  It attaches with the existing read-only
runtime helper solely to publish status snapshots.
"""

from __future__ import annotations

import argparse
from dataclasses import asdict
from datetime import datetime
import json
from pathlib import Path
import sys
import threading
from typing import Any, Sequence


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.desktop_control_plane import (  # noqa: E402
    DesktopConfig,
    DesktopControlPlane,
    LatestCheckpointSummaryProvider,
    SnapshotPoller,
    StaticUnavailableRuntimeProvider,
)
from pokiguard_v2.desktop_runtime import ReadOnlyGameStatusProvider  # noqa: E402
from pokiguard_v2.desktop_ui import (  # noqa: E402
    DesktopApplication,
    DesktopEventLog,
    DesktopViewModel,
    create_root,
)
from pokiguard_v2.memory_board_provider import MemoryProviderConfig  # noqa: E402
from tools.runtime_common import attach_target, utc_timestamp  # noqa: E402


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument(
        "--offline",
        action="store_true",
        help="use an explicit unavailable fake; performs no game-process operation",
    )
    parser.add_argument(
        "--poll-interval",
        type=float,
        default=2.0,
        help="seconds between read-only backend polls (default: 2.0)",
    )
    parser.add_argument(
        "--smoke-seconds",
        type=float,
        default=0.0,
        help="auto-close after a bounded smoke duration; zero means manual close",
    )
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument(
        "--artifacts",
        type=Path,
        help="new artifact directory (default: logs/desktop_ui/<timestamp>)",
    )
    return parser


def _validate_args(args: argparse.Namespace) -> None:
    if not 0.25 <= args.poll_interval <= 60.0:
        raise ValueError("--poll-interval must be between 0.25 and 60 seconds")
    if not 0.0 <= args.smoke_seconds <= 86_400.0:
        raise ValueError("--smoke-seconds must be between 0 and 86400")
    if not 1 <= args.max_region_mib <= 32:
        raise ValueError("--max-region-mib must be between 1 and 32")
    if not 1 <= args.chunk_mib <= 16:
        raise ValueError("--chunk-mib must be between 1 and 16")


class _EvidenceSink:
    def __init__(self, event_log: DesktopEventLog) -> None:
        self.event_log = event_log
        self.refreshes = 0
        self.attached_refreshes = 0
        self.detached_refreshes = 0
        self.error_refreshes = 0
        self.lifecycles: list[str] = []
        self.pids: set[int] = set()
        self._lock = threading.Lock()

    def __call__(self, event: str, snapshot: Any | None) -> None:
        self.event_log.poll_event(event, snapshot)
        if event != "snapshot_refreshed" or snapshot is None:
            return
        with self._lock:
            self.refreshes += 1
            if snapshot.runtime.attached:
                self.attached_refreshes += 1
            else:
                self.detached_refreshes += 1
            if snapshot.last_error:
                self.error_refreshes += 1
            lifecycle = snapshot.runtime.lifecycle
            if not self.lifecycles or self.lifecycles[-1] != lifecycle:
                self.lifecycles.append(lifecycle)
            if snapshot.runtime.pid is not None:
                self.pids.add(snapshot.runtime.pid)

    def summary(self) -> dict[str, Any]:
        with self._lock:
            return {
                "refreshes": self.refreshes,
                "attachedRefreshes": self.attached_refreshes,
                "detachedRefreshes": self.detached_refreshes,
                "errorRefreshes": self.error_refreshes,
                "lifecycleTransitions": list(self.lifecycles),
                "observedPids": sorted(self.pids),
            }


def run(args: argparse.Namespace) -> int:
    _validate_args(args)
    artifact_dir = (
        args.artifacts
        or PROJECT_ROOT
        / "logs"
        / "desktop_ui"
        / f"{datetime.now():%Y%m%d_%H%M%S}"
    ).resolve()
    artifact_dir.mkdir(parents=True, exist_ok=False)
    events_path = artifact_dir / "events.jsonl"
    summary_path = artifact_dir / "summary.json"
    event_log = DesktopEventLog(events_path)
    runtime = (
        StaticUnavailableRuntimeProvider()
        if args.offline
        else ReadOnlyGameStatusProvider(
            attach_target,
            provider_config=MemoryProviderConfig(
                max_region_mib=args.max_region_mib,
                chunk_mib=args.chunk_mib,
                required_confirmations=2,
                require_lobby_start=False,
                allow_ack_heap_scan=False,
            ),
        )
    )
    checkpoint = LatestCheckpointSummaryProvider(
        PROJECT_ROOT / "logs" / "farm_runs"
    )
    control_plane = DesktopControlPlane(
        runtime,
        checkpoint=checkpoint,
        config=DesktopConfig(),
    )
    evidence = _EvidenceSink(event_log)
    poller = SnapshotPoller(
        control_plane,
        interval_seconds=args.poll_interval,
        event_sink=evidence,
    )
    view_model = DesktopViewModel(
        control_plane,
        poller,
        stale_after_seconds=max(3.0, args.poll_interval * 3.0),
    )
    result = None
    unexpected = None
    exit_code = 0
    event_log.write(
        "desktop_ui_process_started",
        mode="OFFLINE_FAKE" if args.offline else "LIVE_READ_ONLY",
        processAccess=(
            []
            if args.offline
            else ["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"]
        ),
        autonomousInputAuthority=False,
        farmRunnerCommandPathAvailable=False,
        checkpointMutationAuthority=False,
    )
    try:
        root = create_root()
        app = DesktopApplication(
            root,
            view_model,
            event_log=event_log,
            auto_close_seconds=args.smoke_seconds,
        )
        result = app.run()
    except Exception as exc:  # capture launch/event-loop failures as evidence
        unexpected = f"{type(exc).__name__}: {exc}"
        exit_code = 1
        event_log.write("desktop_ui_process_error", error=unexpected)
        poller.stop(timeout_seconds=30.0)
        control_plane.close()

    final_snapshot = control_plane.snapshot()
    summary = {
        "schema": "pokiguard.desktop_ui.phase2e1.v1",
        "timestamp": utc_timestamp(),
        "mode": "OFFLINE_FAKE" if args.offline else "LIVE_READ_ONLY",
        "artifactDirectory": str(artifact_dir),
        "uiFramework": "tkinter/ttk",
        "readOnly": True,
        "processAccess": (
            []
            if args.offline
            else ["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"]
        ),
        "polling": evidence.summary(),
        "renderTicks": result.render_ticks if result is not None else 0,
        "handledUiErrors": result.handled_ui_errors if result is not None else 0,
        "unhandledUiThreadExceptions": 0 if unexpected is None else 1,
        "pollerStarts": result.poller_starts if result is not None else poller.starts,
        "pollerAliveAfterClose": (
            result.poller_alive_after_close if result is not None else poller.alive
        ),
        "finalRuntime": asdict(final_snapshot.runtime),
        "finalCheckpoint": asdict(final_snapshot.checkpoint),
        "finalConfig": asdict(final_snapshot.config),
        "safety": asdict(final_snapshot.safety),
        "phase2e2CommandsAvailable": False,
        "farmRunnerStarted": False,
        "controllerStopped": True,
        "unexpectedError": unexpected,
    }
    summary_path.write_text(
        json.dumps(summary, ensure_ascii=False, indent=2, default=str),
        encoding="utf-8",
    )
    event_log.write("desktop_ui_process_finished", summary=str(summary_path))
    event_log.close()
    print(f"Phase 2E.1 desktop UI artifacts: {artifact_dir}", flush=True)
    print(
        "Read-only safety: FarmRunner starts=0; autonomous Windows inputs=0; "
        f"pollerAliveAfterClose={summary['pollerAliveAfterClose']}",
        flush=True,
    )
    return exit_code


def main(argv: Sequence[str] | None = None) -> int:
    parser = build_parser()
    args = parser.parse_args(argv)
    try:
        return run(args)
    except ValueError as exc:
        parser.error(str(exc))
    return 2


if __name__ == "__main__":
    raise SystemExit(main())
