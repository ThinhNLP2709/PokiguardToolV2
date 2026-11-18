"""Build/profile tags for new checkpoints; never rebind historical gameplay."""
from __future__ import annotations
from pathlib import Path
from functools import lru_cache
from .profile import compatibility_root, load_json, atomic_json, CompatibilityError


def _scope():
    root = compatibility_root()
    if not (root / "profiles").is_dir():
        return None
    from tools.runtime_common import configured_game_executable
    from .profile import active_profile
    selection = configured_game_executable()
    if selection is None:
        raise CompatibilityError("CHECKPOINT_BUILD_SCOPE_UNKNOWN", "Chọn tệp game trước khi tiếp tục checkpoint.")
    executable = selection.executable
    data = executable.parent / (executable.stem + "_Data")
    inputs = (executable, executable.parent / "GameAssembly.dll", executable.parent / "UnityPlayer.dll",
              data / "il2cpp_data/Metadata/global-metadata.dat", data / "app.info",
              *sorted(p for p in data.iterdir() if p.is_file()),
              *sorted(p for p in (data / "StreamingAssets").rglob("*") if p.is_file()))
    # Do not hash a 100 MB install on every checkpoint. A file/profile change
    # invalidates this identity-only cache; no game pointers are cached here.
    versions = tuple((str(p), p.stat().st_size, p.stat().st_mtime_ns) for p in
                     (*inputs, *sorted((root / "profiles").glob("*.json"))))
    profile = _cached_scope(str(executable), str(root), versions)
    if profile is None:
        return None
    return profile


@lru_cache(maxsize=8)
def _cached_scope(executable: str, root: str, versions: tuple):
    from .profile import active_profile
    return active_profile(Path(executable), root=Path(root))


def record_scope(path: Path, payload) -> None:
    profile = _scope()
    if profile is None:
        return
    record = load_json(compatibility_root() / "profiles" /
                       (profile.identity["files"]["assembly"]["sha256"] + ".json"))
    if payload.created_at < record["verified_at"]:
        raise CompatibilityError("CHECKPOINT_BUILD_SCOPE_UNKNOWN", "Checkpoint có trước migration.")
    tag = path.with_name(path.name + ".compatibility.json")
    if tag.is_file():
        old = load_json(tag)
        if old.get("profile_id") != profile.profile_id or old.get("farm_run_id") != payload.farm_run_id:
            raise CompatibilityError("CHECKPOINT_BUILD_MISMATCH")
    atomic_json(tag, {"profile_id": profile.profile_id, "farm_run_id": payload.farm_run_id,
                      "checkpoint_seq": payload.checkpoint_seq})


def resume_error(path: Path | None, payload) -> str | None:
    try:
        profile = _scope()
        tag = path.with_name(path.name + ".compatibility.json") if path else None
        if profile is None:
            # A checkpoint from an external profile cannot return to the
            # built-in build merely because that older build is supported.
            return "CHECKPOINT_BUILD_MISMATCH" if tag and tag.is_file() else None
        if tag is None or not tag.is_file():
            return "CHECKPOINT_BUILD_SCOPE_UNKNOWN"
        record = load_json(tag)
        if record != {"profile_id": profile.profile_id, "farm_run_id": payload.farm_run_id,
                      "checkpoint_seq": payload.checkpoint_seq}:
            return "CHECKPOINT_BUILD_MISMATCH"
        return None
    except (OSError, ValueError, KeyError, TypeError):
        return "CHECKPOINT_BUILD_SCOPE_UNKNOWN"
