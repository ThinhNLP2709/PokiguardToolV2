"""Windowed standalone entry point for the packaged PokiguardToolV2 app."""

from __future__ import annotations

from datetime import datetime, timezone
import json
import multiprocessing
from pathlib import Path
import sys
import tempfile
import traceback
from typing import Sequence

from pokiguard_v2.app_paths import AppPaths, current_app_paths
from pokiguard_v2.controller_lease import AutomationControllerLease, ControllerLeaseError
from pokiguard_v2.version import APP_TITLE


PACKAGING_SELF_CHECK_ARG = "--packaging-self-check"


def _timestamp() -> str:
    return datetime.now(timezone.utc).isoformat(timespec="milliseconds").replace(
        "+00:00", "Z"
    )


def _append_startup_event(path: Path, event: str, **fields: object) -> None:
    path.parent.mkdir(parents=True, exist_ok=True)
    with path.open("a", encoding="utf-8", buffering=1) as output:
        output.write(
            json.dumps(
                {"timestamp": _timestamp(), "event": event, **fields},
                ensure_ascii=False,
                separators=(",", ":"),
                default=str,
            )
            + "\n"
        )


def _fallback_startup_log() -> Path:
    return Path(tempfile.gettempdir()).resolve() / "PokiguardToolV2-startup.jsonl"


def _show_error(message: str) -> None:
    try:
        from tkinter import messagebox

        messagebox.showerror(APP_TITLE, message)
    except Exception:
        # The startup log is the bounded fallback if Tk itself is unavailable.
        return


def _run_packaging_self_check(paths: AppPaths) -> int:
    """Import the complete production graph and verify bundled resources.

    This acceptance-only path performs no process attachment and sends no
    Windows input.  Evidence is written to the normal startup log.
    """

    from pokiguard_v2.reset_evidence_store import load_reset_capabilities
    from tools import basic_auto_bot, boss_entry, farm_cycle, farm_run, technical_recovery

    capabilities = load_reset_capabilities(paths.reset_evidence)
    calibrations = sorted(
        path.name
        for path in paths.reference_root.glob("exit_ui_live_calibration*.json")
    )
    if len(calibrations) != 2:
        raise FileNotFoundError(
            f"expected two packaged exit calibrations, found {calibrations}"
        )
    _append_startup_event(
        paths.startup_log,
        "packaged_self_check_passed",
        importedModules=[
            basic_auto_bot.__name__,
            boss_entry.__name__,
            farm_cycle.__name__,
            farm_run.__name__,
            technical_recovery.__name__,
        ],
        productionResetCapabilities=len(capabilities),
        recoveryCalibrations=calibrations,
        processAttachment=False,
        windowsInput=False,
    )
    return 0


def run_packaged(argv: Sequence[str] | None = None, *, paths: AppPaths | None = None) -> int:
    resolved = paths or current_app_paths()
    resolved.ensure_writable_directories()
    _append_startup_event(
        resolved.startup_log,
        "packaged_app_started",
        frozen=resolved.frozen,
        executable=str(Path(sys.executable).resolve()),
        installRoot=str(resolved.install_root),
        dataRoot=str(resolved.data_root),
        currentWorkingDirectoryIgnored=True,
        automaticStart=False,
        automaticResume=False,
    )
    with AutomationControllerLease(resolved.desktop_lock):
        # Import only after the writable boundary and single-instance guard are
        # established.  The production FarmRunner remains an in-process thread;
        # packaging does not add subprocess or worker recursion.
        if tuple(argv or ()) == (PACKAGING_SELF_CHECK_ARG,):
            exit_code = _run_packaging_self_check(resolved)
        else:
            from tools.desktop_ui import main as desktop_main

            exit_code = int(desktop_main(argv))
    _append_startup_event(
        resolved.startup_log,
        "packaged_app_finished",
        exitCode=exit_code,
    )
    if exit_code != 0:
        _show_error(
            "Pokiguard Tool V2 stopped because of a startup/runtime error.\n\n"
            f"Diagnostic log: {resolved.startup_log}"
        )
    return exit_code


def main(argv: Sequence[str] | None = None) -> int:
    multiprocessing.freeze_support()
    startup_log: Path | None = None
    try:
        paths = current_app_paths()
        startup_log = paths.startup_log
        return run_packaged(sys.argv[1:] if argv is None else argv, paths=paths)
    except ControllerLeaseError:
        message = "Pokiguard Tool V2 is already open. Close the existing window first."
        path = startup_log or _fallback_startup_log()
        try:
            _append_startup_event(path, "packaged_app_duplicate_rejected")
        except OSError:
            pass
        _show_error(message)
        return 23
    except Exception as exc:  # noqa: BLE001 - fatal startup boundary
        path = startup_log or _fallback_startup_log()
        detail = f"{type(exc).__name__}: {exc}"
        try:
            _append_startup_event(
                path,
                "packaged_app_fatal_error",
                error=detail,
                traceback="".join(
                    traceback.format_exception(type(exc), exc, exc.__traceback__)
                ),
            )
        except OSError:
            pass
        _show_error(
            "Pokiguard Tool V2 could not start safely.\n\n"
            f"{detail}\n\nDiagnostic log: {path}"
        )
        return 1


if __name__ == "__main__":
    raise SystemExit(main())


__all__ = ["PACKAGING_SELF_CHECK_ARG", "main", "run_packaged"]
