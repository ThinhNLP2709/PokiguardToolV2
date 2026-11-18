"""GUI/CLI migration engine. Staging and failure never change active profiles."""
from __future__ import annotations
from dataclasses import dataclass
from pathlib import Path
import threading
import time
import uuid

from .profile import (CompatibilityError, RuntimeProfile, active_profile, atomic_json,
                      compatibility_root, digest, file_hash, install_identity, load_contract,
                      load_json, require)
from .toolchain import check_cancel


@dataclass(frozen=True)
class MigrationResult:
    status: str
    message: str
    job: Path | None = None
    profile_id: str | None = None


def migrate(location: str | Path, *, root: Path | None = None,
            reverse: Path | None = None, prepare_only: bool = False,
            cancel: threading.Event | None = None, progress=lambda message: None,
            probe=None, audit_builtin: bool = False) -> MigrationResult:
    from ..game_location import resolve_game_executable, SUPPORTED_GAME_ASSEMBLY_SHA256
    from ..controller_lease import AutomationControllerLease
    from ..app_paths import current_app_paths
    from .audit import audit_candidate
    from .probe import live_probe
    from .toolchain import dump

    selection = resolve_game_executable(location)
    executable = selection.executable
    root = (root or compatibility_root()).resolve()
    require(root != selection.location and selection.location not in root.parents,
            "MIGRATION_STORAGE_INSIDE_GAME")
    for name in ("jobs", "tools", "profiles", "candidates"):
        child = (root / name).resolve()
        require(root in child.parents, "MIGRATION_STORAGE_LINK_ESCAPE", name)
    cancel = cancel or threading.Event()
    job = None
    # Same OS lease as existing controllers. CLI races cannot grant any input.
    with AutomationControllerLease(current_app_paths().controller_lock):
        try:
            progress("Đang kiểm tra danh tính bản game đã chọn...")
            identity = install_identity(executable)
            check_cancel(cancel)
            build = identity["files"]["assembly"]["sha256"]
            if build in SUPPORTED_GAME_ASSEMBLY_SHA256 and not audit_builtin:
                return MigrationResult("builtin", "Bản game này đã được tool hỗ trợ sẵn. Không cần migration.")
            contract = load_contract()
            require(identity["metadata_version"] == contract["identity"]["metadata_version"], "METADATA_ABI_CHANGED")
            require(identity["files"]["unity"] == contract["identity"]["files"]["unity"], "UNITY_ABI_CHANGED")
            require(identity["ui_assets"] == contract["identity"]["ui_assets"], "UI_ASSETS_CHANGED",
                    "Dữ liệu giao diện/scene đã đổi; cần bản cập nhật tool được kiểm tra thủ công.")
            job = root / "jobs" / (time.strftime("%Y%m%d_%H%M%S_") + uuid.uuid4().hex[:12])
            job.mkdir(parents=True, exist_ok=False)
            atomic_json(job / "identity.json", identity)
            pending = root / "candidates" / f"{build}.json"
            candidate = None
            if reverse is None and (root / "profiles" / f"{build}.json").is_file():
                try:
                    candidate = active_profile(executable, root=root)
                except (ValueError, KeyError, TypeError, OSError):
                    candidate = None
            if candidate is None and reverse is None and pending.is_file():
                try:
                    saved = load_json(pending)
                    candidate = RuntimeProfile.from_dict(saved["profile"], contract)
                    require(saved.get("profile_id") == candidate.profile_id and candidate.identity == identity,
                            "CANDIDATE_STALE")
                except (ValueError, KeyError, TypeError):
                    candidate = None
            if candidate is None:
                from .catalog import fetch_profile
                try:
                    candidate = fetch_profile(identity, contract, cancel)
                except Exception as exc:
                    check_cancel(cancel)
                    atomic_json(job / "catalog.json", {"status": "local_fallback", "error": str(exc)})
                    progress("Chưa có profile từ máy chủ; chuyển sang kiểm tra cục bộ...")
            if candidate is None:
                directory = reverse.resolve() if reverse is not None else dump(executable, job, root, cancel, progress)
                check_cancel(cancel)
                progress("Đang so layout, enum, ABI, native bridge và mã xác định tọa độ...")
                candidate = audit_candidate(directory, executable, identity, contract)
                require(install_identity(executable) == identity, "INSTALL_CHANGED_DURING_MIGRATION")
            atomic_json(pending, {"profile_id": candidate.profile_id, "profile": candidate.to_dict(),
                                  "status": "pending"})
            check_cancel(cancel)
            if prepare_only:
                atomic_json(job / "result.json", {"status": "pending", "profile_id": candidate.profile_id})
                return MigrationResult("pending", "Đã kiểm tra tĩnh; chưa kích hoạt. Mở game, vào phòng boss rồi chạy lại.", job, candidate.profile_id)
            progress("Đang probe chỉ đọc trên game; chưa gửi thao tác chơi...")
            evidence = (probe or live_probe)(executable, candidate)
            check_cancel(cancel)
            require(evidence.get("status") == "verified" and evidence.get("game_inputs") == 0
                    and evidence.get("profile_id") == candidate.profile_id, "LIVE_PROBE_FAILED")
            require(install_identity(executable) == identity, "INSTALL_CHANGED_DURING_PROBE")
            atomic_json(job / "probe.json", evidence)
            record = {"status": "verified", "profile_id": candidate.profile_id,
                      "profile": candidate.to_dict(), "verified_at": time.time(),
                      "probe": evidence, "job": job.name}
            # The sole activation point. An interrupted/failed migration leaves
            # the previous profile byte-for-byte intact.
            atomic_json(job / "result.json", {"status": "verified_pending_activation", "profile_id": candidate.profile_id})
            check_cancel(cancel)
            atomic_json(root / "profiles" / f"{build}.json", record)
            return MigrationResult("verified", "Đã cập nhật tương thích. Bắt đầu lượt chạy mới; chứng nhận gameplay cũ không được chuyển sang build mới.", job, candidate.profile_id)
        except Exception as exc:
            reason = getattr(exc, "reason", type(exc).__name__)
            if job is not None:
                try:
                    atomic_json(job / "result.json", {"status": "pending" if reason == "SCENE_NOT_READY" else "failed",
                                                       "reason": reason, "error": str(exc)})
                except OSError:
                    pass  # Preserve the original failure if storage itself failed.
            if reason == "SCENE_NOT_READY":
                return MigrationResult("pending", str(exc), job)
            raise
