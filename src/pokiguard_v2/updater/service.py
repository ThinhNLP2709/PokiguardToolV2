"""Network check/download and background lifecycle. No game/input imports."""
from __future__ import annotations
import json
from pathlib import Path
import queue
import threading
import urllib.request
import uuid

from .protocol import config, verify, newer, installed_build, require, Release
from .package import extract
from ..app_paths import current_app_paths
from ..compatibility.profile import atomic_json
from ..controller_lease import AutomationControllerLease


def root() -> Path:
    return current_app_paths().data_root / "updates"


def last_result_message():
    from ..compatibility.profile import load_json
    try:
        row = load_json(root() / "last-result.json")
        if row.get("status") == "rolled_back":
            return "Lần cập nhật trước không đạt kiểm tra; đã khôi phục bản cũ."
        if row.get("status") == "committed":
            return f"Đã cập nhật {row['version']} · build {row['build']}. Chưa khởi chạy lượt chơi."
    except (OSError, ValueError, KeyError, TypeError):
        pass
    return "Chỉ cài khi đã dừng lượt chơi; giữ lại cài đặt và log."


def cancelled(cancel):
    require(not cancel.is_set(), "UPDATE_CANCELLED")


def open_url(url):
    return urllib.request.urlopen(urllib.request.Request(url, headers={"User-Agent": "PokiguardToolV2-Updater/1"}), timeout=20)


def check(cancel: threading.Event, progress=lambda message: None):
    trust = config()
    from .protocol import github_asset_url
    github_asset_url(trust["manifest_url"], trust["repository"], latest=True)
    require(bool(trust["public_keys"]), "UPDATE_NOT_CONFIGURED")
    progress("Đang kiểm tra phiên bản tool...")
    with open_url(trust["manifest_url"]) as response:
        require(response.geturl().startswith("https://"), "UPDATE_REDIRECT_INSECURE")
        raw = response.read(128 * 1024 + 1)
    cancelled(cancel)
    require(len(raw) <= 128 * 1024, "UPDATE_MANIFEST_TOO_LARGE")
    release = verify(json.loads(raw), trust)
    return release if newer(release, installed_build()) else None


def prepare(release: Release, cancel: threading.Event, progress=lambda message: None) -> Path:
    from .protocol import verify
    release = verify(json.loads(release.document_bytes))  # Recheck trust at the install boundary.
    require(newer(release, installed_build()), "UPDATE_NOT_NEWER")
    paths = current_app_paths()
    require(paths.frozen, "UPDATE_SOURCE_MODE", "Bản chạy source chỉ kiểm tra phiên bản; cài update từ bản EXE.")
    from .transaction import outside_game, prepare_handoff
    outside_game(root())
    require(paths.data_root.resolve() in root().resolve().parents, "UPDATE_STORAGE_ESCAPE")
    with AutomationControllerLease(paths.controller_lock):
        cancelled(cancel)
        job = root() / "jobs" / uuid.uuid4().hex
        job.mkdir(parents=True, exist_ok=False)
        atomic_json(job / "manifest.json", json.loads(release.document_bytes))
        archive = job / "package.zip"
        progress(f"Đang tải {release.label}...")
        received = 0
        with open_url(release.url) as response, archive.open("xb") as output:
            require(response.geturl().startswith("https://"), "UPDATE_REDIRECT_INSECURE")
            while True:
                cancelled(cancel)
                block = response.read(256 * 1024)
                if not block:
                    break
                received += len(block)
                require(received <= release.size, "UPDATE_DOWNLOAD_TOO_LARGE")
                output.write(block)
        cancelled(cancel)
        progress("Đang xác minh và giải nén gói cập nhật...")
        extract(archive, job / "stage", release)
        cancelled(cancel)
        progress("Đang chuẩn bị bộ cài riêng...")
        prepare_handoff(job, paths.install_root, paths.data_root)
        cancelled(cancel)
        atomic_json(job / "state.json", {"status": "prepared", "version": release.version, "build": release.build})
        return job


class UpdateWorker:
    def __init__(self):
        self.events = queue.Queue()
        self.cancel = threading.Event()
        self.thread = None

    def start(self, action: str, release: Release | None = None):
        if self.thread is not None and self.thread.is_alive():
            return False
        self.cancel.clear()
        def run():
            try:
                progress = lambda text: self.events.put(("progress", text))
                value = check(self.cancel, progress) if action == "check" else prepare(release, self.cancel, progress)
                self.events.put((action, value))
            except Exception as exc:
                self.events.put(("error", exc))
        self.thread = threading.Thread(target=run, name="PokiguardUpdate", daemon=True)
        self.thread.start()
        return True
