#!/usr/bin/env python3
"""Launch the Phase 2E.3 hardened bounded FarmRunner desktop UI."""

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
from pokiguard_v2.desktop_farm_controller import (  # noqa: E402
    DesktopFarmControllerManager,
)
from pokiguard_v2.desktop_preferences import (  # noqa: E402
    DesktopPreferenceStore,
)
from pokiguard_v2.app_paths import (  # noqa: E402
    create_unique_directory,
    current_app_paths,
)
from pokiguard_v2.desktop_ui import (  # noqa: E402
    DesktopApplication,
    DesktopEventLog,
    DesktopViewModel,
    create_root,
)
from pokiguard_v2.memory_board_provider import MemoryProviderConfig  # noqa: E402
from tools.runtime_common import (  # noqa: E402
    attach_target,
    configure_game_location,
    utc_timestamp,
)


def smoke_result_is_healthy(result: Any) -> bool:
    """A smoke run passes only after at least one error-free Tk render."""

    return bool(
        result is not None
        and result.render_ticks > 0
        and result.handled_ui_errors == 0
        and not result.poller_alive_after_close
    )


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
    parser.add_argument(
        "--reset-evidence",
        type=Path,
        help="accepted reset capability evidence used by FarmRunner",
    )
    parser.add_argument(
        "--preferences",
        type=Path,
        help="versioned operator-preference JSON (never a farm checkpoint)",
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
    paths = current_app_paths()
    paths.ensure_writable_directories()
    artifact_dir = (
        args.artifacts.resolve()
        if args.artifacts is not None
        else create_unique_directory(
            paths.desktop_ui_logs,
            f"{datetime.now():%Y%m%d_%H%M%S}",
        )
    )
    if args.artifacts is not None:
        artifact_dir.mkdir(parents=True, exist_ok=False)
    events_path = artifact_dir / "events.jsonl"
    summary_path = artifact_dir / "summary.json"
    event_log = DesktopEventLog(events_path, max_display_entries=500)
    preference_store = DesktopPreferenceStore(
        args.preferences or paths.preferences_file
    )
    preference_load = preference_store.load()
    configured_selection = None
    game_location_error = None
    if preference_load.game_location:
        try:
            configured_selection = configure_game_location(
                preference_load.game_location
            )
        except (OSError, TypeError, ValueError) as exc:
            game_location_error = f"{type(exc).__name__}: {exc}"
    effective_game_location = (
        str(configured_selection.executable)
        if configured_selection is not None
        else preference_load.game_location
    )
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

    def apply_game_location(location: str) -> Any:
        selection = configure_game_location(location)
        reset = getattr(runtime, "reset_attachment", None)
        if reset is not None:
            reset()
        return selection
    checkpoint = LatestCheckpointSummaryProvider(
        paths.farm_runs
    )
    controller = DesktopFarmControllerManager(
        paths.source_root,
        reset_evidence=args.reset_evidence or paths.reset_evidence,
        artifacts_root=paths.farm_runs,
        data_root=paths.data_root,
    )
    control_plane = DesktopControlPlane(
        runtime,
        checkpoint=checkpoint,
        config=preference_load.config,
        controller=controller,
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
        mode="OFFLINE_FAKE" if args.offline else "LIVE_CONTROLLED",
        processAccess=(
            []
            if args.offline
            else ["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"]
        ),
        autonomousInputAuthority=not args.offline,
        farmRunnerCommandPathAvailable=True,
        checkpointMutationAuthority=False,
        preferencePath=str(preference_store.path),
        preferenceLoaded=preference_load.loaded,
        preferenceWarnings=[asdict(value) for value in preference_load.warnings],
        gameLocation=effective_game_location,
        gameExecutable=(
            str(configured_selection.executable)
            if configured_selection is not None
            else None
        ),
        gameLocationError=game_location_error,
        automaticStart=False,
        automaticResume=False,
        frozen=paths.frozen,
        dataRoot=str(paths.data_root),
        installRoot=str(paths.install_root),
        currentWorkingDirectoryIgnored=True,
    )
    if game_location_error is not None:
        event_log.write(
            "game_location_load_warning",
            reason="GAME_LOCATION_INVALID",
            error=game_location_error,
            operatorMessage=(
                "Saved game location is invalid; choose the current game folder "
                "in Settings."
            ),
        )
    try:
        root = create_root()
        app = DesktopApplication(
            root,
            view_model,
            event_log=event_log,
            preference_store=preference_store,
            preference_warnings=preference_load.warnings,
            game_location=effective_game_location,
            game_executable=(
                str(configured_selection.executable)
                if configured_selection is not None
                else ""
            ),
            game_location_changed=apply_game_location,
            auto_close_seconds=args.smoke_seconds,
        )
        result = app.run()
    except Exception as exc:  # capture launch/event-loop failures as evidence
        unexpected = f"{type(exc).__name__}: {exc}"
        exit_code = 1
        event_log.write("desktop_ui_process_error", error=unexpected)
        controller_snapshot = controller.snapshot()
        if controller_snapshot.active:
            control_plane.emergency_stop(controller_snapshot.generation)
            controller.wait(30.0)
        poller.stop(timeout_seconds=30.0)
        control_plane.close()

    if args.smoke_seconds > 0 and exit_code == 0 and not smoke_result_is_healthy(result):
        exit_code = 1
        event_log.write(
            "desktop_ui_smoke_failed",
            renderTicks=result.render_ticks if result is not None else 0,
            handledUiErrors=result.handled_ui_errors if result is not None else 0,
            pollerAliveAfterClose=(
                result.poller_alive_after_close if result is not None else poller.alive
            ),
        )

    final_snapshot = control_plane.snapshot()
    summary = {
        "schema": "pokiguard.desktop_ui.phase2e3.v1",
        "timestamp": utc_timestamp(),
        "mode": "OFFLINE_FAKE" if args.offline else "LIVE_CONTROLLED",
        "artifactDirectory": str(artifact_dir),
        "frozen": paths.frozen,
        "dataRoot": str(paths.data_root),
        "installRoot": str(paths.install_root),
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
        "finalController": asdict(final_snapshot.controller),
        "safety": asdict(final_snapshot.safety),
        "phase2e3CommandsAvailable": True,
        "farmRunnerStarted": final_snapshot.controller.safety.starts > 0,
        "controllerStopped": not final_snapshot.controller.active,
        "preferences": {
            "schema": "pokiguard.desktop_preferences.v1",
            "path": str(preference_store.path),
            "loaded": preference_load.loaded,
            "warnings": [asdict(value) for value in preference_load.warnings],
            "gameLocation": effective_game_location,
            "resolvedGameExecutable": (
                str(configured_selection.executable)
                if configured_selection is not None
                else None
            ),
            "separateFromCheckpoint": True,
            "automaticStartOnLoad": False,
            "automaticResumeOnLoad": False,
        },
        "operatorLog": (
            {
                "configuredBound": result.operator_log_bound,
                "maxObservedEntries": result.operator_log_max_observed,
                "totalEntries": result.operator_log_total_entries,
                "workerThreadTkWrites": 0,
            }
            if result is not None
            else {**event_log.stats(), "workerThreadTkWrites": 0}
        ),
        "uiCommands": (
            {
                "start": app.start_commands_submitted,
                "resume": app.resume_commands_submitted,
                "gracefulStop": app.graceful_commands_submitted,
                "emergencyStop": app.emergency_commands_submitted,
                "finalCloseIntent": result.close_intent,
            }
            if result is not None
            else {}
        ),
        "unexpectedError": unexpected,
    }
    summary_path.write_text(
        json.dumps(summary, ensure_ascii=False, indent=2, default=str),
        encoding="utf-8",
    )
    event_log.write("desktop_ui_process_finished", summary=str(summary_path))
    event_log.close()
    print(f"Phase 2E.3 desktop UI artifacts: {artifact_dir}", flush=True)
    print(
        "Controller safety: "
        f"FarmRunner starts={final_snapshot.controller.safety.starts}; "
        f"active={final_snapshot.controller.active}; "
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
