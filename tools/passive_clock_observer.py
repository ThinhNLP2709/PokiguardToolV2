"""P5 preparation / future explicit-PID passive observation. No game input.

P5 runs --prepare only. Native collection requires a separate user-operated
activation; neither a preparation manifest nor observations activate reasoning.
"""
from __future__ import annotations

import argparse
from collections import Counter
import ctypes
from ctypes import wintypes
import json
import os
from pathlib import Path
import signal
import sys
import threading
import time

ROOT = Path(__file__).resolve().parents[1]
sys.path.insert(0, str(ROOT / "src"))
sys.path.insert(0, str(ROOT))

from pokiguard_v2.passive_clock_observer import (
    Binding, Limits, ObservationAbort, canonical_bytes, digest, export_report, observe,
    MAX_SAMPLE_RPM, MAX_SAMPLE_BYTES, MAX_SAMPLE_READABILITY_CHECKS, MAX_OUTPUT_BYTES,
)

GAME_HASHES = {
    "GameAssembly.dll": "72d10a43fbfdab705e2db7caca1cc2b998b0b8581d56946dc545d87c720ec063",
    "UnityPlayer.dll": "bb93aa060395c4ace3561b4ceafe06cfaebd5dfb883c451058b9ccb74b50b6d2",
    "PetPuzzle-1.7.4.exe": "32ef7bdac0ffecd45d8f50dc4a715cf9585fefa5299ffc9207cd92a84a005929",
    "PetPuzzle-1.7.4_Data/il2cpp_data/Metadata/global-metadata.dat": "ac32633a4856d4bef5efb63028f2a354c63bcc327a8d275013728c5e25c17c47",
}
MODULE_CAP = 512


def file_hash(path):
    import hashlib
    return hashlib.sha256(path.read_bytes()).hexdigest()


def make_review(game_dir: Path) -> dict:
    from pokiguard_v2.il2cpp_external import MATCH_SERVICE_SINGLETON, IL2CPP_CLASS_STATIC_FIELDS_OFFSET
    paths = sorted(p for folder in ("src", "tools", "tests") for p in (ROOT / folder).rglob("*.py"))
    if len(paths) > 512:
        raise ValueError("source inventory exceeds preparation cap")
    sources = {p.relative_to(ROOT).as_posix(): file_hash(p) for p in paths}
    game = {name: file_hash(game_dir / name) for name in GAME_HASHES}
    if game != GAME_HASHES:
        raise ValueError("game build does not match current-b6 evidence")
    return dict(schema="5d1.p5.passive_review.v1", status="PREPARED_NOT_ACTIVATED",
        production_activation=False, input_authority=False, native_U_ms=None,
        source_files=sources, source_sha256=digest(sources), game_dir=str(game_dir.resolve()),
        game_files=game, limits=vars(Limits()), host_clock=dict(name="perf_counter_ns",
            implementation=time.get_clock_info("perf_counter").implementation,
            monotonic=time.get_clock_info("perf_counter").monotonic,
            resolution_seconds=time.get_clock_info("perf_counter").resolution),
        output_contract=dict(root=str(ROOT), filename="observation.json", max_bytes=MAX_OUTPUT_BYTES,
            exclusive=True, samples_buffered_max=600, raw_blocks_exported=False,
            account_strings_exported=False, one_window=True, resume=False),
        read_allowlist=dict(root=[
            dict(base="GameAssembly",offset=MATCH_SERVICE_SINGLETON.type_info_rva,bytes=8),
            dict(base="Il2CppClass",offset=IL2CPP_CLASS_STATIC_FIELDS_OFFSET,bytes=8),
            dict(base="static_fields",offset=MATCH_SERVICE_SINGLETON.static_field_offset,bytes=8)],
            match_service_fields=[dict(offset=p,bytes=n) for p,n in ((0x20,8),(0x38,8),(0x40,4),(0x44,4),(0x190,4))],
            strings=dict(count_per_identity=2,header_offset=0,header_bytes=20,
                class_pointer_validation_bytes=8,payload_offset=0x14,payload_max_bytes=256),
            clock_blocks=dict(count=2,offset=0x1BC,bytes_each=48,
                decoded_fields=[dict(offset=p,type=t) for p,t in (
                    (0x1BC,"bool"),(0x1BD,"bool"),(0x1C8,"float32"),(0x1CC,"float32"),(0x1E8,"float32"))],
                padding_and_pointers="not decoded/dereferenced/exported"),
            disallowed=["ACK tables","ChatService","payload/RTT/SpeedGuard","Unity native candidate",
                "provider/board scan","screenshots","input","network","writes"]),
        cost_contract=dict(per_sample_max_rpm=MAX_SAMPLE_RPM,
            per_sample_max_bytes=MAX_SAMPLE_BYTES, per_sample_max_readability_checks=MAX_SAMPLE_READABILITY_CHECKS,
            incremental_clock_rpm=2, incremental_clock_bytes=96,
            two_identity_max_rpm=28, two_identity_max_bytes=1240,
            session_max_rpm=18000, session_max_bytes=801600, session_max_virtual_queries=7200,
            root_per_identity="3 RPM x8B; six single-region readability checks",
            strings_per_identity="2 pointers x8B; 2 x (header20B + class8B + data<=256B)",
            integers_per_identity="turn/duration/raw timer: 3 x4B",
            setup_and_final="2 bounded module snapshots total; each <=512 entries; no RPM",
            module_snapshot_api_max_per_pass=dict(CreateToolhelp32Snapshot=1, Module32FirstW=1,
                Module32NextW=512, CloseHandle=1),
            process_api="OpenProcess once query|VM_READ, architecture helper <=2 OS calls once; GetProcessTimes+GetExitCodeProcess once setup, once collector pin, twice/sample, once final; CloseHandle once",
            lifetime_api_max_each=1203,
            setup_final_deadline_seconds=5, os_call_latency_bound="UNKNOWN_NOT_PREEMPTIBLE",
            file_hash_io="Source/game hashes before attach and after collection; separate from RPM/window",
            disk="No writes during sample collection; bounded exclusive export afterward; no durability/OS-latency guarantee"),
        evidence="docs/phase5/artifacts/5d1_clock_evidence_v1/clock_evidence_final.json")


def verify_review(review):
    if (review.get("schema") != "5d1.p5.passive_review.v1"
            or review.get("status") != "PREPARED_NOT_ACTIVATED"
            or review.get("input_authority") is not False
            or review.get("production_activation") is not False
            or review.get("native_U_ms") is not None):
        raise ValueError("invalid diagnostic review")
    sources = review["source_files"]
    if not 1 <= len(sources) <= 512 or digest(sources) != review["source_sha256"]:
        raise ValueError("invalid source manifest")
    for name, expected in sources.items():
        path = (ROOT / name).resolve()
        if not path.is_relative_to(ROOT) or file_hash(path) != expected:
            raise ValueError("source binding changed")
    for required in ("tools/passive_clock_observer.py", "src/pokiguard_v2/passive_clock_observer.py",
                     "src/pokiguard_v2/il2cpp_external.py", "src/pokiguard_v2/il2cpp_layout.py", "tools/process_probe.py"):
        if required not in sources:
            raise ValueError("missing dependency binding")
    if review["game_files"] != GAME_HASHES:
        raise ValueError("invalid game hashes")
    for name, expected in GAME_HASHES.items():
        if file_hash(Path(review["game_dir"]) / name) != expected:
            raise ValueError("game binding changed")
    clock = review["host_clock"]
    actual = time.get_clock_info("perf_counter")
    if (clock.get("name") != "perf_counter_ns" or clock.get("monotonic") is not True
            or clock.get("implementation") != actual.implementation
            or clock.get("resolution_seconds") != actual.resolution):
        raise ValueError("host clock binding changed")
    Limits(**review["limits"])


def bounded_modules(first, next_entry, *, stopped, cap=MODULE_CAP):
    """Testable bounded adapter over the existing Toolhelp module primitive."""
    result = []
    value = first()
    while value is not None:
        if stopped():
            raise ObservationAbort("USER_STOP")
        if len(result) >= cap:
            raise ObservationAbort("MODULE_INVENTORY_CAP")
        result.append(value)
        value = next_entry()
    return result


class NativeSession:
    """Lazy Windows adapter, explicit PID, one handle, no discovery or retries."""
    def __init__(self, pid, review, stopped):
        if os.name != "nt" or type(pid) is not int or not 1 <= pid <= 0xFFFFFFFF:
            raise ValueError("native observation needs Windows and an explicit PID")
        from tools import process_probe as probe
        from pokiguard_v2 import il2cpp_external as ext
        self.probe, self.ext, self.review, self.stopped = probe, ext, review, stopped
        self.api_counts = Counter()
        self.deadline_ns = time.perf_counter_ns() + 5_000_000_000
        self.handle = None
        self.pid = pid
        probe.assert_python_x64()
        k = probe.kernel32
        k.CloseHandle.argtypes = [wintypes.HANDLE]
        k.CloseHandle.restype = wintypes.BOOL
        k.GetProcessTimes.argtypes = [wintypes.HANDLE] + [ctypes.POINTER(wintypes.FILETIME)] * 4
        k.GetProcessTimes.restype = wintypes.BOOL
        k.GetExitCodeProcess.argtypes = [wintypes.HANDLE, ctypes.POINTER(wintypes.DWORD)]
        k.GetExitCodeProcess.restype = wintypes.BOOL
        try:
            self.handle = self._api("OpenProcess", probe.PROCESS_QUERY_INFORMATION | probe.PROCESS_VM_READ, False, pid)
            if not self.handle:
                raise OSError("read-only process open failed")
            # Existing helper has at most two architecture-query OS calls.
            self._checkpoint()
            self.api_counts["architecture_helper_calls"] += 1
            if probe.target_architecture(self.handle) != "x64":
                raise ValueError("target is not x64")
            modules = self._modules()
            self.module = self._verify_modules(modules)
            self.created = self._lifetime()
            outer = self

            class SingleRegionMemory(ext.Win32RemoteMemory):
                def is_readable(self, address, size):
                    if (not ext.is_canonical_user_pointer(address) or size <= 0
                            or address + size > ext.MAX_USER_ADDRESS + 1):
                        return False
                    info = ext.MEMORY_BASIC_INFORMATION()
                    outer.api_counts["VirtualQueryEx"] += 1
                    got = ext._kernel32.VirtualQueryEx(self.process_handle, ctypes.c_void_p(address),
                        ctypes.byref(info), ctypes.sizeof(info))
                    base = ctypes.cast(info.BaseAddress, ctypes.c_void_p).value or 0
                    protection = int(info.Protect)
                    return (got == ctypes.sizeof(info) and info.State == ext.MEM_COMMIT
                        and not protection & (ext.PAGE_NOACCESS | ext.PAGE_GUARD)
                        and protection & 0xFF in ext.READABLE_PAGE_TYPES
                        and base <= address and address + size <= base + int(info.RegionSize))

            self.memory = SingleRegionMemory(self.handle)
        except BaseException as exc:
            try:
                self.close()
            except OSError:
                exc.cleanup_failed = True
            exc.native_api_counts = dict(self.api_counts)
            raise

    def _checkpoint(self):
        if self.stopped():
            raise ObservationAbort("USER_STOP")
        if time.perf_counter_ns() >= self.deadline_ns:
            raise ObservationAbort("NATIVE_STAGE_DEADLINE")

    def _api(self, name, *args):
        self._checkpoint()
        self.api_counts[name] += 1
        return getattr(self.probe.kernel32, name)(*args)

    def _close(self, handle):
        self.api_counts["CloseHandle"] += 1
        if not self.probe.kernel32.CloseHandle(handle):
            raise OSError("handle cleanup failed")

    def _modules(self):
        p = self.probe
        snapshot = self._api("CreateToolhelp32Snapshot", p.TH32CS_SNAPMODULE | p.TH32CS_SNAPMODULE32, self.pid)
        if not snapshot or snapshot == p.INVALID_HANDLE_VALUE:
            raise OSError("module snapshot failed; no retry")
        entry = p.MODULEENTRY32W()
        entry.dwSize = ctypes.sizeof(entry)

        def get(name):
            if not self._api(name, snapshot, ctypes.byref(entry)):
                if ctypes.get_last_error() != p.ERROR_NO_MORE_FILES:
                    raise OSError("module inventory failed")
                return None
            return p.ModuleInfo(entry.szModule, entry.szExePath,
                ctypes.cast(entry.modBaseAddr, ctypes.c_void_p).value or 0, int(entry.modBaseSize))
        try:
            return bounded_modules(lambda: get("Module32FirstW"), lambda: get("Module32NextW"), stopped=self.stopped)
        finally:
            self._close(snapshot)

    def _verify_modules(self, modules):
        directory = Path(self.review["game_dir"]).resolve()
        found = None
        for name in ("PetPuzzle-1.7.4.exe", "GameAssembly.dll", "UnityPlayer.dll"):
            matches = [m for m in modules if m.name.casefold() == name.casefold()]
            if len(matches) != 1 or Path(matches[0].path).resolve() != directory / name:
                raise ValueError("module/install identity mismatch")
            if name == "GameAssembly.dll":
                found = matches[0]
        return found

    def _lifetime(self):
        created, exited, kernel, user = (wintypes.FILETIME() for _ in range(4))
        code = wintypes.DWORD()
        if (not self._api("GetProcessTimes", self.handle, ctypes.byref(created), ctypes.byref(exited), ctypes.byref(kernel), ctypes.byref(user))
                or not self._api("GetExitCodeProcess", self.handle, ctypes.byref(code)) or code.value != 259):
            raise ObservationAbort("PROCESS_EXIT_OR_LIFETIME_UNAVAILABLE")
        return (created.dwHighDateTime << 32) | created.dwLowDateTime

    def binding(self):
        created = self._lifetime()
        if created != self.created:
            raise ObservationAbort("PROCESS_LIFETIME_DRIFT")
        return Binding(self.review["source_sha256"], GAME_HASHES["GameAssembly.dll"],
            self.pid, created, self.module.base, self.module.size, native=True)

    def verify_end(self):
        self.deadline_ns = time.perf_counter_ns() + 5_000_000_000
        self.binding()
        if self._verify_modules(self._modules()) != self.module:
            raise ObservationAbort("MODULE_MAPPING_DRIFT")
        verify_review(self.review)

    def close(self):
        if self.handle:
            handle, self.handle = self.handle, None
            self._close(handle)


def main(argv=None):
    parser = argparse.ArgumentParser(description=__doc__)
    mode = parser.add_mutually_exclusive_group(required=True)
    mode.add_argument("--prepare", action="store_true")
    mode.add_argument("--native", action="store_true")
    parser.add_argument("--game-dir", type=Path, default=Path("D:/pc"))
    parser.add_argument("--review-manifest", type=Path)
    parser.add_argument("--review-sha256")
    parser.add_argument("--activate-passive-window", action="store_true")
    parser.add_argument("--pid", type=int)
    parser.add_argument("--out", type=Path, required=True)
    args = parser.parse_args(argv)
    if args.native and (not args.activate_passive_window or not args.pid or not args.review_manifest or not args.review_sha256):
        parser.error("native needs explicit passive activation, PID, reviewed manifest and its SHA256")
    if args.prepare and (args.activate_passive_window or args.pid):
        parser.error("prepare does not accept native activation/PID")
    directory = args.out.resolve()
    if not directory.is_relative_to(ROOT):
        parser.error("output must be inside PokiguardToolV2")
    stop = threading.Event()
    previous_signal = signal.signal(signal.SIGINT, lambda *_: stop.set())
    session = None
    output_claimed = False
    try:
        if args.prepare:
            review = make_review(args.game_dir)
            directory.mkdir(parents=True, exist_ok=False)
            (directory / "review.json").write_bytes(canonical_bytes(review) + b"\n")
            print(json.dumps(dict(status="PREPARED_NOT_ACTIVATED", input_authority=False)))
            return 0
        raw = args.review_manifest.read_bytes()
        if len(raw) > 256 * 1024:
            raise ValueError("review manifest exceeds cap")
        import hashlib
        if hashlib.sha256(raw).hexdigest() != args.review_sha256:
            raise ValueError("review file changed")
        review = json.loads(raw)
        verify_review(review)
        directory.mkdir(parents=True, exist_ok=False)  # one window, no resume
        output_claimed = True
        session = NativeSession(args.pid, review, stop.is_set)
        limits = Limits(**review["limits"])
        session.deadline_ns = time.perf_counter_ns() + int(limits.seconds * 1e9)
        report = observe(session, now_ns=time.perf_counter_ns, wait=stop.wait, stopped=stop.is_set, limits=limits)
        report.update(review_manifest_sha256=args.review_sha256, host_clock=review["host_clock"],
            clock_alignment="UNKNOWN_NO_UNITY_NOW", build_binding="FILE_HASH_AND_MODULE_PATH_ONLY",
            module_mapping_aba_excluded=False, execution_boundary="NATIVE_READ_ONLY")
        try:
            session.verify_end()
            report["final_binding_checked"] = True
        except Exception as exc:
            report.update(verdict="INCONCLUSIVE", final_binding_checked=False,
                final_binding_failure=type(exc).__name__)
        report["native_api_counts"] = dict(session.api_counts)
        session.close()
        report["native_api_counts"] = dict(session.api_counts)
        receipt = export_report(report, directory / "observation.json")
        print(json.dumps(dict(verdict=report["verdict"], export=receipt, native_U_ms=None, input_authority=False)))
        return 0 if receipt["status"] == "FILE_WRITTEN" else 1
    except Exception as exc:
        failure = dict(schema="5d1.p5.passive_setup_failure.v1", status="FAILED",
            error_category=type(exc).__name__, native_api_counts=getattr(exc,"native_api_counts",{}),
            samples=[], native_U_ms=None, input_authority=False, production_activation=False,
            cleanup_failed=getattr(exc,"cleanup_failed",False))
        if output_claimed:
            failure["failure_export"] = export_report(failure, directory / "failure.json")
        print(json.dumps(failure))
        return 1
    finally:
        if session is not None:
            session.close()
        signal.signal(signal.SIGINT, previous_signal)


if __name__ == "__main__":
    raise SystemExit(main())
