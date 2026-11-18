"""Helper-owned directory swap, verified health receipt, retained rollback.

No recursive deletion and no access to game processes/files. All rename targets
are resolved, constrained sibling paths in a dedicated transaction directory.
"""
from __future__ import annotations
import ctypes
from ctypes import wintypes
import json
import os
from pathlib import Path
import secrets
import shutil
import subprocess
import sys
import time

from .package import extract, inspect_package
from .protocol import EXE_NAME, require, verify, newer, installed_build, UpdateError
from ..compatibility.profile import atomic_json, file_hash, load_json
from ..controller_lease import AutomationControllerLease


def outside_game(path: Path):
    for parent in (path.resolve(), *path.resolve().parents):
        require(not (parent / "GameAssembly.dll").exists(), "UPDATE_PATH_INSIDE_GAME")


def validate_install(install: Path):
    require(install.is_absolute() and install.resolve() != Path(install.anchor), "UPDATE_INSTALL_INVALID")
    outside_game(install)
    require(install.is_dir() and not install.is_symlink(), "UPDATE_INSTALL_INVALID")
    require({p.name for p in install.iterdir()} == {EXE_NAME, "_internal"}, "UPDATE_INSTALL_NOT_ISOLATED",
            "Giải nén bộ tool trong một thư mục riêng trước khi cập nhật.")
    require((install / EXE_NAME).is_file() and (install / "_internal").is_dir(), "UPDATE_INSTALL_INVALID")
    installed_build(install)
    # Do not traverse a junction/symlink while copying or replacing the bundle.
    for p in install.rglob("*"):
        require(not p.is_symlink() and install.resolve() in p.resolve().parents, "UPDATE_INSTALL_LINK_ESCAPE")


def prepare_handoff(job: Path, install: Path, data_root: Path):
    install = install.resolve()
    validate_install(install)
    outside_game(job)
    require(install not in job.resolve().parents and job.resolve() not in install.parents,
            "UPDATE_HELPER_NOT_SEPARATE")
    helper = job / "helper"
    shutil.copytree(install, helper)
    atomic_json(job / "handoff.json", {"install": str(install), "data_root": str(data_root.resolve()),
               "old_exe_sha256": file_hash(install / EXE_NAME), "old_build": installed_build(install),
               "parent_pid": os.getpid(), "restart": True})


def launch_helper(job: Path):
    require((job / "handoff.json").is_file(), "UPDATE_HANDOFF_MISSING")
    return subprocess.Popen([str(job / "helper" / EXE_NAME), "--apply-tool-update", str(job)],
        cwd=job, stdin=subprocess.DEVNULL, stdout=subprocess.DEVNULL, stderr=subprocess.DEVNULL,
        creationflags=getattr(subprocess, "CREATE_NO_WINDOW", 0), close_fds=True)


def wait_for_parent(pid: int, expected: Path, *, timeout=60):
    """Wait only for the exact old TOOL image, holding its process handle."""
    require(os.name == "nt" and type(pid) is int and pid > 0 and pid != os.getpid(), "UPDATE_PARENT_INVALID")
    kernel = ctypes.WinDLL("kernel32", use_last_error=True)
    kernel.OpenProcess.argtypes = [wintypes.DWORD, wintypes.BOOL, wintypes.DWORD]
    kernel.OpenProcess.restype = wintypes.HANDLE
    handle = kernel.OpenProcess(0x100000 | 0x1000, False, pid)  # SYNCHRONIZE | QUERY_LIMITED_INFORMATION
    if not handle:
        require(ctypes.get_last_error() == 87, "UPDATE_PARENT_OPEN_FAILED")
        return
    kernel.CloseHandle.argtypes = [wintypes.HANDLE]
    try:
        kernel.QueryFullProcessImageNameW.argtypes = [wintypes.HANDLE, wintypes.DWORD, wintypes.LPWSTR, ctypes.POINTER(wintypes.DWORD)]
        size = wintypes.DWORD(32768); buffer = ctypes.create_unicode_buffer(size.value)
        require(kernel.QueryFullProcessImageNameW(handle, 0, buffer, ctypes.byref(size)), "UPDATE_PARENT_QUERY_FAILED")
        require(str(Path(buffer.value).resolve()).casefold() == str(expected.resolve()).casefold(), "UPDATE_PARENT_IMAGE_MISMATCH")
        kernel.WaitForSingleObject.argtypes = [wintypes.HANDLE, wintypes.DWORD]
        deadline = time.monotonic() + timeout
        while True:
            result = kernel.WaitForSingleObject(handle, 200)
            require(result in (0, 258), "UPDATE_PARENT_WAIT_FAILED")
            if result == 0:
                break
            require(time.monotonic() < deadline, "UPDATE_PARENT_TIMEOUT")
    finally:
        kernel.CloseHandle(handle)


def rename(source: Path, destination: Path):
    outside_game(source); outside_game(destination)
    # Bounded retry for antivirus/read handles. Never kill another process.
    for attempt in range(21):
        try:
            source.rename(destination)
            return
        except OSError:
            if attempt == 20:
                raise
            time.sleep(0.2)


def run_health(install: Path, job: Path, release):
    data = job / "health-data"
    outside_game(data)
    require(job.resolve() in data.resolve().parents, "UPDATE_HEALTH_STORAGE_ESCAPE")
    data.mkdir(exist_ok=True)
    receipt = data / "update-health.json"
    receipt.unlink(missing_ok=True)
    nonce = secrets.token_hex(24)
    env = dict(os.environ, POKIGUARD_V2_DATA_ROOT=str(data), POKIGUARD_UPDATE_HEALTH_NONCE=nonce)
    env.pop("PYTHONPATH", None)
    child = subprocess.Popen([str(install / EXE_NAME), "--update-health-check"], cwd=job, env=env,
                             creationflags=getattr(subprocess, "CREATE_NO_WINDOW", 0))
    try:
        code = child.wait(timeout=60)
    except subprocess.TimeoutExpired:
        child.kill(); child.wait()
        raise UpdateError("UPDATE_HEALTH_TIMEOUT")
    require(code == 0 and receipt.is_file(), "UPDATE_HEALTH_FAILED")
    row = load_json(receipt)
    require(row == {"nonce": nonce, "version": release.version, "build": release.build,
                    "source_sha256": release.source_sha256, "game_inputs": 0}, "UPDATE_HEALTH_RECEIPT_INVALID")


def restart(install: Path):
    subprocess.Popen([str(install / EXE_NAME)], cwd=install,
                     creationflags=getattr(subprocess, "CREATE_NO_WINDOW", 0))


def apply(job: Path, *, wait=wait_for_parent, health=run_health, start=restart):
    """Called from a copied helper after UI shutdown. Keep old bundle on disk."""
    job = job.resolve()
    require(len(job.name) == 32 and all(c in "0123456789abcdef" for c in job.name), "UPDATE_JOB_INVALID")
    outside_game(job)
    info = load_json(job / "handoff.json")
    install = Path(info["install"])
    require(install.is_absolute() and install == install.resolve() and install.parent != install,
            "UPDATE_INSTALL_INVALID")
    outside_game(install)
    require(job not in install.parents and install not in job.parents, "UPDATE_HELPER_NOT_SEPARATE")
    release = verify(load_json(job / "manifest.json"))
    wait(info["parent_pid"], install / EXE_NAME)
    data_root = Path(info["data_root"]).resolve()
    outside_game(data_root)
    area = install.parent / (".Pokiguard-update-" + job.name)
    require(area.resolve().parent == install.parent and not area.is_symlink(), "UPDATE_AREA_INVALID")
    old = area / "previous"
    failed = area / ("failed-" + secrets.token_hex(4))
    journal = job / "transaction.json"
    status = load_json(journal).get("status") if journal.is_file() else "prepared"
    failure = None
    with AutomationControllerLease(data_root / ".desktop_ui.lock"), \
         AutomationControllerLease(data_root / "logs/.automation_controller.lock"), \
         AutomationControllerLease(data_root / "updates/.install.lock"):
        if status == "committed":
            return "committed"
        # A retry after interruption restores the last known installation first.
        if old.is_dir():
            if install.exists():
                rename(install, failed)
            rename(old, install)
            atomic_json(journal, {"status": "rolled_back", "install": str(install)})
            return "rolled_back"
        validate_install(install)
        require(file_hash(install / EXE_NAME) == info["old_exe_sha256"]
                and installed_build(install) == info["old_build"], "UPDATE_OLD_INSTALL_CHANGED")
        require(newer(release, installed_build(install)), "UPDATE_NOT_NEWER")
        area.mkdir(exist_ok=False)
        staged = extract(job / "package.zip", area / "stage", release)
        atomic_json(journal, {"status": "prepared", "install": str(install), "backup": str(old)})
        moved = False
        try:
            rename(install, old)
            moved = True
            atomic_json(journal, {"status": "old_moved", "install": str(install), "backup": str(old)})
            rename(staged, install)
            atomic_json(journal, {"status": "checking", "install": str(install), "backup": str(old)})
            inspect_package(install, release)
            health(install, job, release)
            atomic_json(journal, {"status": "committed", "install": str(install), "backup": str(old)})
        except Exception as exc:
            if moved:
                if install.exists():
                    rename(install, failed)
                rename(old, install)
            atomic_json(journal, {"status": "rolled_back", "error": str(exc), "install": str(install)})
            failure = exc
    if info.get("restart") is True:
        try:
            atomic_json(data_root / "updates/last-result.json", {"status": "rolled_back" if failure else "committed",
                        "version": installed_build(install)["version"], "build": installed_build(install)["build"]})
        except OSError:
            pass  # Diagnostic storage failure must not prevent reopening a valid bundle.
        start(install)  # Normal app startup never auto-starts or resumes a run.
    if failure is not None:
        raise failure
    return "committed"
