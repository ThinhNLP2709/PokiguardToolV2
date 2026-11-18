"""Pinned portable tools. Downloads/extraction are confined to tool data."""
from __future__ import annotations
import hashlib
import os
from pathlib import Path
import subprocess
import threading
import urllib.request
import zipfile

from .profile import load_json, atomic_json, require, file_hash, CompatibilityError

DUMPER_URL = "https://github.com/AndnixSH/Il2CppDumper/releases/download/3.2.1/Il2CppDumper-3.2.1-win-x64.zip"
DUMPER_SHA256 = "ff970e9fa3da75aaa37157c7ac669a6c022500a4c3903c966ba17a7b890160ce"
RUNTIME_URL = "https://builds.dotnet.microsoft.com/dotnet/Runtime/10.0.15/dotnet-runtime-10.0.15-win-x64.zip"
RUNTIME_SHA512 = "06f0bedd59ae4ac722ada805a6d6bbf605bcdc790c71f59b7003878072902b5cde5dec8c40c0baa81192660d4748e9d79afdbdcb0c0ea9d6b821d0a044c4c6dd"


def check_cancel(cancel: threading.Event) -> None:
    require(not cancel.is_set(), "MIGRATION_CANCELLED")


def fetch_archive(url: str, expected: str, algorithm: str, destination: Path,
                  cancel: threading.Event) -> None:
    destination.parent.mkdir(parents=True, exist_ok=True)
    if destination.is_file():
        h = hashlib.new(algorithm, destination.read_bytes()).hexdigest()
        if h == expected:
            return
    part = destination.with_suffix(".partial")
    try:
        request = urllib.request.Request(url, headers={"User-Agent": "PokiguardToolV2-compatibility/1"})
        h = hashlib.new(algorithm)
        total = 0
        with urllib.request.urlopen(request, timeout=30) as response, part.open("wb") as output:
            require(response.geturl().startswith("https://"), "DOWNLOAD_REDIRECT_INSECURE")
            while True:
                check_cancel(cancel)
                block = response.read(256 * 1024)
                if not block:
                    break
                total += len(block)
                require(total < 100 * 1024 * 1024, "DOWNLOAD_TOO_LARGE")
                h.update(block)
                output.write(block)
        require(h.hexdigest() == expected, "DOWNLOAD_CHECKSUM_MISMATCH", destination.name)
        os.replace(part, destination)
    finally:
        part.unlink(missing_ok=True)


def extract_verified(archive: Path, destination: Path, cancel: threading.Event) -> None:
    """Re-derive member hashes from the pinned ZIP on every reuse."""
    destination.mkdir(parents=True, exist_ok=True)
    root = destination.resolve()
    require(archive.parent.resolve() in root.parents, "ARCHIVE_DESTINATION_ESCAPE")
    with zipfile.ZipFile(archive) as source:
        require(sum(i.file_size for i in source.infolist()) < 400 * 1024 * 1024, "ARCHIVE_TOO_LARGE")
        for member in source.infolist():
            check_cancel(cancel)
            target = (root / member.filename).resolve()
            require(target != root and root in target.parents and ":" not in member.filename
                    and not member.filename.startswith(("/", "\\")), "ARCHIVE_PATH_INVALID")
            require((member.external_attr >> 16) & 0o170000 != 0o120000, "ARCHIVE_SYMLINK_INVALID")
            if member.is_dir():
                target.mkdir(parents=True, exist_ok=True)
                continue
            content = source.read(member)
            if target.is_file() and file_hash(target) == hashlib.sha256(content).hexdigest():
                continue
            target.parent.mkdir(parents=True, exist_ok=True)
            temporary = target.with_suffix(target.suffix + ".partial")
            temporary.write_bytes(content)
            os.replace(temporary, target)


def acquire(root: Path, cancel: threading.Event, progress) -> tuple[Path, dict]:
    progress("Đang chuẩn bị Il2CppDumper 3.2.1 và .NET 10.0.15 portable...")
    tools = root / "tools"
    dumper_zip = tools / "dumper-3.2.1-x64.zip"
    runtime_zip = tools / "dotnet-10.0.15-x64.zip"
    fetch_archive(DUMPER_URL, DUMPER_SHA256, "sha256", dumper_zip, cancel)
    fetch_archive(RUNTIME_URL, RUNTIME_SHA512, "sha512", runtime_zip, cancel)
    extract_verified(dumper_zip, tools / "dumper-3.2.1", cancel)
    extract_verified(runtime_zip, tools / "dotnet-10.0.15", cancel)
    exe = tools / "dumper-3.2.1/Il2CppDumper-3.2.1-win-x64/Il2CppDumper.exe"
    require(exe.is_file(), "DUMPER_EXECUTABLE_MISSING")
    env = dict(os.environ)
    env.update(DOTNET_ROOT=str((tools / "dotnet-10.0.15").resolve()),
               DOTNET_ROOT_X64=str((tools / "dotnet-10.0.15").resolve()),
               DOTNET_MULTILEVEL_LOOKUP="0", DOTNET_NOLOGO="1")
    return exe, env


def dump(executable: Path, job: Path, root: Path, cancel: threading.Event, progress) -> Path:
    exe, env = acquire(root, cancel, progress)
    output = job / "reverse"
    # A unique output folder is mandatory; never merge with an old dump.
    require(not output.exists(), "DUMPER_OUTPUT_EXISTS")
    output.mkdir()
    metadata = executable.parent / (executable.stem + "_Data") / "il2cpp_data/Metadata/global-metadata.dat"
    command = [str(exe), str(executable.parent / "GameAssembly.dll"), str(metadata), str(output),
               "--no-dummy-dll", "--scripts", "none", "--no-pause", "--threads", "2"]
    progress("Đang đọc bản game mới để tạo symbol (không sửa file game)...")
    with (job / "dumper.log").open("wb") as log:
        child = subprocess.Popen(command, cwd=job, env=env, stdin=subprocess.DEVNULL,
                                 stdout=log, stderr=subprocess.STDOUT,
                                 creationflags=getattr(subprocess, "CREATE_NO_WINDOW", 0))
        import time
        deadline = time.monotonic() + 600
        try:
            while child.poll() is None:
                check_cancel(cancel)
                require(time.monotonic() < deadline, "DUMPER_TIMEOUT")
                cancel.wait(0.2)
            require(child.returncode == 0, "DUMPER_FAILED", f"exit {child.returncode}; xem dumper.log")
        finally:
            if child.poll() is None:
                child.kill()
                child.wait(timeout=10)
    require(all((output / name).is_file() and (output / name).stat().st_size > 0
                for name in ("dump.cs", "script.json", "il2cpp.h")), "DUMPER_OUTPUT_INCOMPLETE")
    return output
