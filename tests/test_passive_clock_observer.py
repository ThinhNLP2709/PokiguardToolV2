from __future__ import annotations

from contextlib import ExitStack, redirect_stderr, redirect_stdout
import ctypes
from ctypes import wintypes
from dataclasses import replace
import io
import json
from pathlib import Path
import struct
import tempfile
import unittest
from types import SimpleNamespace
from unittest.mock import Mock, patch

from pokiguard_v2.il2cpp_external import (MATCH_SERVICE_SINGLETON, IL2CPP_CLASS_STATIC_FIELDS_OFFSET)
from pokiguard_v2.passive_clock_observer import (
    Binding, CLOCK_OFFSET, GuardedMemory, Limits, MAX_OUTPUT_BYTES,
    ObservationAbort, ClockDecodeError, canonical_bytes, decode_clock, digest, export_report, observe,
)
from tools import passive_clock_observer as cli


class FakeClock:
    def __init__(self):
        self.ns = 1_000_000_000
        self.waits = []
        self.on_wait = None

    def now(self):
        return self.ns

    def wait(self, seconds):
        self.waits.append(seconds)
        self.ns += max(1, round(seconds * 1e9))
        if self.on_wait:
            self.on_wait()


def clock_block(*, has=True, paused=False, remain=12.5, anchor=1024.0, fx=0.0, padding=0):
    raw = bytearray([padding] * 48)
    raw[0:2] = bytes((has, paused))
    for p, v in ((0xC, remain), (0x10, anchor), (0x2C, fx)):
        struct.pack_into("<f", raw, p, v)
    return bytes(raw)


class FakeMemory:
    def __init__(self):
        self.data = {}
        self.reads = []
        self.queries = []
        self.on_read = None
        self.on_query = None

    def put(self, address, raw):
        self.data.update({address + i: v for i, v in enumerate(raw)})

    def read(self, address, size):
        self.reads.append((address, size))
        raw = bytes(self.data[address + i] for i in range(size))
        return self.on_read(address, size, raw) if self.on_read else raw

    def is_readable(self, address, size):
        self.queries.append((address, size))
        return self.on_query(address, size) if self.on_query else True


class FakeSource:
    def __init__(self, *, string_size=None):
        self.memory = FakeMemory()
        self.pinned = Binding("a" * 64, "b" * 64, 123, 42, 0x10000000, 0x4000000)
        self.binding_calls = 0
        self.on_binding = None
        self.root = 0x22000000
        cls, statics = 0x20000000, 0x21000000
        self.memory.put(self.pinned.module_base + MATCH_SERVICE_SINGLETON.type_info_rva, struct.pack("<Q", cls))
        self.memory.put(cls + IL2CPP_CLASS_STATIC_FIELDS_OFFSET, struct.pack("<Q", statics))
        self.memory.put(statics, struct.pack("<Q", self.root))
        for off, addr, value in ((0x20, 0x23000000, "M_SYNTHETIC"), (0x48, 0x24000000, "private-account-fixture")):
            if string_size:
                value = "x" * string_size
            self.string(addr, value)
            self.memory.put(self.root + off, struct.pack("<Q", addr))
        self.memory.put(self.root + 0x50, struct.pack("<ii", 3, 14))
        self.memory.put(self.root + 0x1A0, struct.pack("<i", 12))
        self.memory.put(self.root + CLOCK_OFFSET, clock_block(padding=91))

    def string(self, address, value):
        raw = bytearray(20)
        struct.pack_into("<Q", raw, 0, 0x25000000)
        struct.pack_into("<i", raw, 16, len(value))
        self.memory.put(0x25000000, b"\0" * 8)
        self.memory.put(address, bytes(raw) + value.encode("utf-16-le"))

    def binding(self):
        self.binding_calls += 1
        return self.on_binding(self.binding_calls) if self.on_binding else self.pinned


def collect(source=None, clock=None, *, limits=None, stopped=lambda: False):
    source = source or FakeSource()
    clock = clock or FakeClock()
    return observe(source, now_ns=clock.now, wait=clock.wait, stopped=stopped,
        limits=limits or Limits(seconds=1, samples=3))


class PassiveClockTests(unittest.TestCase):
    def test_exact_1749_layout_and_float32_ulp(self):
        v = decode_clock(clock_block(paused=True, remain=9.75, anchor=1024, fx=1026, padding=91))
        self.assertEqual((v["paused"], v["remain_at_anchor_seconds"], v["anchor_unscaled_seconds"],
            v["fx_hold_until_unscaled_seconds"]), (True, 9.75, 1024, 1026))
        self.assertEqual(v["anchor_float32_ulp_seconds"], 2 ** -13)
        self.assertEqual(decode_clock(clock_block(anchor=0))["anchor_float32_ulp_seconds"], 2 ** -149)

    def test_full_cost_inventory_includes_root_string_class_and_identity(self):
        s = FakeSource(string_size=128)
        r = collect(s, limits=Limits(seconds=1, samples=1))
        row = r["samples"][0]
        self.assertEqual(row["status"], "VALID")
        self.assertEqual(len(row["rpm_calls"]), 30)
        self.assertEqual(row["requested_bytes"], 1336)
        self.assertEqual(row["returned_bytes"], 1336)
        self.assertEqual(len(row["readability_checks"]), 12)
        self.assertEqual(len(s.memory.reads), 30)
        for side in ("a", "b"):
            calls = [c for c in row["rpm_calls"] if c["phase"] == "clock_" + side]
            self.assertEqual([(v["address"], v["bytes"]) for v in calls], [(s.root + 0x1CC, 48)])

    def test_equal_blocks_are_only_local_observations_and_never_authority(self):
        r = collect()
        self.assertEqual(r["verdict"], "LOCAL_OBSERVATION_ONLY")
        self.assertIsNone(r["native_U_ms"])
        self.assertIsNone(r["transport_age_ms"])
        self.assertIsNone(r["host_unity_alignment_ms"])
        self.assertFalse(r["input_authority"])
        self.assertFalse(r["atomic_snapshot_proven"])
        self.assertFalse(r["anchor_change_is_tick_receipt"])
        self.assertFalse(r["production_activation"])

    def test_no_account_or_padding_serialized(self):
        raw = canonical_bytes(collect())
        self.assertNotIn(b"private-account-fixture", raw)
        self.assertNotIn(b"M_SYNTHETIC", raw)
        self.assertNotIn(b"5b5b5b5b", raw)
        self.assertNotIn(b"raw_block", raw)

    def test_clock_mismatch_including_undecoded_padding_aborts_without_retry(self):
        for padding_only in (False, True):
            s = FakeSource()
            n = 0
            def read(a, size, raw):
                nonlocal n
                if a == s.root + CLOCK_OFFSET:
                    n += 1
                    if n == 2:
                        if padding_only:
                            raw = raw[:2] + bytes([raw[2] ^ 1]) + raw[3:]
                        else:
                            raw = clock_block(anchor=1025, padding=91)
                return raw
            s.memory.on_read = read
            r = collect(s)
            self.assertEqual((r["verdict"], r["stop_reason"], r["attempted_samples"]),
                ("INCONCLUSIVE", "CLOCK_BLOCK_MISMATCH", 1))
            self.assertEqual(n, 2)

    def test_missing_anchor_and_invalid_types(self):
        variants = [clock_block(has=False), clock_block(remain=float("nan")),
            clock_block(anchor=float("inf")), clock_block(fx=-2), clock_block(remain=301),
            b"\2" + clock_block()[1:], clock_block()[:47]]
        for raw in variants:
            with self.subTest(raw=raw.hex()[:20]):
                s = FakeSource()
                s.memory.on_read = lambda a,n,v: raw if a == s.root + CLOCK_OFFSET else v
                r = collect(s)
                self.assertEqual(r["verdict"], "INCONCLUSIVE")
                self.assertEqual(len(r["samples"]), 1)
                canonical_bytes(r)  # No NaN escapes into diagnostics.

    def test_paused_and_fx_reanchor_remain_ambiguous(self):
        s, clock = FakeSource(), FakeClock()
        def update():
            s.memory.put(s.root + CLOCK_OFFSET, clock_block(paused=True, anchor=1025, fx=1028, padding=91))
        clock.on_wait = update
        r = collect(s, clock)
        self.assertEqual(r["observations"]["anchor_changes"], 1)
        self.assertEqual(r["observations"]["paused_samples"], 2)
        self.assertEqual(r["observations"]["anchor_change_cause"], "UNKNOWN_SERVER_OR_LOCAL_FX")
        self.assertEqual(r["observations"]["fx_active"], "UNKNOWN")
        self.assertIsNone(r["native_U_ms"])

    def test_source_process_lifetime_build_and_module_drift(self):
        fields = dict(source_sha256="c" * 64, game_sha256="c" * 64, pid=456,
            process_created_ticks=43, module_base=0x11000000, module_size=0x4100000)
        for name, value in fields.items():
            with self.subTest(field=name):
                s = FakeSource()
                s.on_binding = lambda n: replace(s.pinned, **{name:value}) if n >= 3 else s.pinned
                r = collect(s)
                self.assertEqual(r["stop_reason"], "PROCESS_SOURCE_BUILD_DRIFT")
                self.assertLess(len(s.memory.reads), 30)

    def test_turn_player_raw_timer_and_match_drift_within_sample(self):
        for off, value in ((0x50, struct.pack("<i",4)), (0x1A0, struct.pack("<i",11)),
                           (0x20, struct.pack("<Q",0x26000000)), (0x48, struct.pack("<Q",0x26000000))):
            s = FakeSource()
            s.string(0x26000000, "other")
            def mutate(a,n,raw):
                if a == s.root + CLOCK_OFFSET:
                    s.memory.put(s.root + off, value)
                return raw
            s.memory.on_read = mutate
            r = collect(s)
            self.assertEqual(r["stop_reason"], "IDENTITY_DRIFT_WITHIN_SAMPLE")
            self.assertEqual(r["verdict"], "INCONCLUSIVE")

    def test_match_change_between_samples_closes_same_window(self):
        s, clock = FakeSource(), FakeClock()
        s.string(0x26000000, "M_NEXT")
        clock.on_wait = lambda:s.memory.put(s.root + 0x20, struct.pack("<Q",0x26000000))
        r = collect(s, clock)
        self.assertEqual(r["stop_reason"], "SESSION_DRIFT_BETWEEN_SAMPLES")
        self.assertEqual(r["attempted_samples"], 2)

    def test_turn_transition_between_samples_is_explicit_and_not_a_new_match(self):
        s, clock = FakeSource(), FakeClock()
        clock.on_wait = lambda:s.memory.put(s.root + 0x50, struct.pack("<i",4))
        r = collect(s, clock)
        self.assertEqual([v["identity_a"]["turn"] for v in r["samples"]], [3,4,4])
        self.assertEqual(r["verdict"], "LOCAL_OBSERVATION_ONLY")

    def test_all_caps_and_no_catch_up_after_slow_reads(self):
        s, clock = FakeSource(string_size=128), FakeClock()
        s.memory.on_read = lambda a,n,v:(setattr(clock,"ns",clock.ns + 100_000) or v)
        r = collect(s, clock, limits=Limits(seconds=60, samples=600))
        starts = [v["start_ns"] for v in r["samples"]]
        self.assertTrue(all(b-a >= 100_000_000 for a,b in zip(starts, starts[1:])))
        self.assertLessEqual(r["attempted_samples"], 600)
        self.assertLessEqual(sum(len(v["rpm_calls"]) for v in r["samples"]), 18000)
        self.assertLessEqual(sum(v["requested_bytes"] for v in r["samples"]), 801600)
        self.assertTrue(all(v["end_ns"] < r["start_ns"] + 60_000_000_000 for v in r["samples"]))
        self.assertLessEqual(max(clock.waits), .02)
        self.assertEqual(r["stop_reason"], "WINDOW_CAP")
        self.assertLess(len(canonical_bytes(r)), MAX_OUTPUT_BYTES)

    def test_zero_latency_600_sample_cap(self):
        r = collect(limits=Limits(seconds=60, samples=600))
        self.assertEqual((r["attempted_samples"], r["stop_reason"]), (600,"SAMPLE_CAP"))

    def test_stop_before_during_identity_and_between_clock_reads(self):
        s = FakeSource()
        self.assertEqual(collect(s, stopped=lambda:True)["attempted_samples"], 0)
        self.assertEqual(s.memory.reads, [])
        for index in (1,14,15,16,29,30):
            s = FakeSource()
            flag = [False]
            def read(a,n,v):
                if len(s.memory.reads) == index:
                    flag[0] = True
                return v
            s.memory.on_read = read
            r = collect(s, stopped=lambda:flag[0])
            self.assertEqual(r["stop_reason"], "USER_STOP")
            self.assertEqual(len(s.memory.reads), index)
            self.assertEqual(r["samples"][0]["rpm_calls"][-1]["status"], "OK")

    def test_read_span_deadline_and_partial_errors_keep_all_attempts(self):
        for mode in ("span","window","partial","error"):
            s, clock = FakeSource(), FakeClock()
            def read(a,n,v):
                if mode == "span": clock.ns += 51_000_000
                if mode == "window": clock.ns += 2_000_000_000
                if mode == "partial": return v[:-1]
                if mode == "error": raise OSError("not exported")
                return v
            s.memory.on_read = read
            r = collect(s, clock)
            self.assertEqual((r["attempted_samples"],len(s.memory.reads)),(1,1))
            self.assertEqual(r["samples"][0]["reason"],
                {"span":"READ_SPAN_CAP","window":"WINDOW_CAP","partial":"PARTIAL_READ","error":"READ_ERROR"}[mode])
            self.assertTrue(r["complete_attempt_ledger"])
            self.assertNotIn(b"not exported", canonical_bytes(r))

    def test_invalid_root_string_and_pointer_fail_closed(self):
        for case in ("root_null","noncanonical","long_string","bad_utf16"):
            s = FakeSource()
            if case == "root_null":
                s.memory.put(0x21000000, b"\0" * 8)
            if case == "noncanonical":
                s.memory.put(s.root + 0x20, struct.pack("<Q", 1))
            if case == "long_string":
                s.string(0x23000000, "x" * 129)
            if case == "bad_utf16":
                s.memory.put(0x23000000 + 20, b"\0\xd8")
                s.memory.put(0x23000000 + 16, struct.pack("<i",1))
            r = collect(s)
            self.assertEqual(r["verdict"], "INCONCLUSIVE")
            self.assertEqual(r["attempted_samples"], 1)

    def test_limits_reject_nonfinite_and_escalation(self):
        for field,value in (("seconds",61),("samples",601),("samples",True),("hz",11),
                            ("hz",0),("seconds",float("nan")),("max_read_span_ms",101)):
            with self.subTest(field=field,value=value), self.assertRaises(ValueError):
                Limits(**{field:value})

    def test_host_clock_regression_between_samples_stops_with_preserved_prefix(self):
        clock=FakeClock()
        clock.on_wait=lambda:setattr(clock,"ns",clock.ns-40_000_000)
        r=collect(clock=clock)
        self.assertEqual(r["stop_reason"],"HOST_CLOCK_REGRESSION")
        self.assertEqual(len(r["samples"]),1)
        self.assertEqual(r["verdict"],"INCONCLUSIVE")

    def test_readability_error_is_visible_without_rpm_or_retry(self):
        s=FakeSource()
        s.memory.on_query=Mock(side_effect=OSError("query failed"))
        r=collect(s)
        self.assertEqual(r["stop_reason"],"READABILITY_ERROR")
        self.assertEqual(r["samples"][0]["readability_checks"][0]["status"],"READABILITY_ERROR")
        self.assertEqual(s.memory.reads,[])

    def test_read_wrapper_enforces_call_byte_query_caps_before_extra_io(self):
        clock=FakeClock();s=FakeSource(string_size=128)
        m=GuardedMemory(s.memory,clock.now,lambda:False,clock.ns+1_000_000_000,clock.ns+50_000_000)
        for _ in range(12):self.assertTrue(m.is_readable(s.root,1))
        with self.assertRaisesRegex(ObservationAbort,"READABILITY_CAP"):m.is_readable(s.root,1)
        for _ in range(30):m.read(s.root+CLOCK_OFFSET,1)
        with self.assertRaisesRegex(ObservationAbort,"RPM_CAP"):m.read(s.root+CLOCK_OFFSET,1)
        self.assertEqual(len(s.memory.reads),30)
        self.assertEqual(len(s.memory.queries),12)

    def test_log_loss_is_visible_and_never_grants_authority(self):
        with patch("pokiguard_v2.passive_clock_observer.MAX_OUTPUT_BYTES",65536):
            r = collect()
        self.assertEqual(r["dropped_records"], 1)
        self.assertFalse(r["complete_attempt_ledger"])
        self.assertEqual(r["verdict"], "INCONCLUSIVE")
        self.assertFalse(r["input_authority"])

    def test_export_exclusive_failure_partial_and_no_durability_claim(self):
        r = collect()
        with tempfile.TemporaryDirectory(dir=cli.ROOT) as d:
            p = Path(d)/"observation.json"
            self.assertEqual(export_report(r,p)["status"], "FILE_WRITTEN")
            self.assertEqual(json.loads(p.read_bytes()),r)
            self.assertEqual(export_report(r,p)["reason"], "FileExistsError")
            self.assertFalse(export_report(r,p)["durable"])
            class Partial(io.BytesIO):
                def write(self, raw):return len(raw)-1
            receipt=export_report(r,p,opener=lambda *_:Partial())
            self.assertEqual(receipt["reason"], "PARTIAL_WRITE")
            receipt=export_report(r,p,opener=Mock(side_effect=OSError("disk")))
            self.assertEqual(receipt["reason"], "OSError")

    def test_native_cli_needs_explicit_activation_and_never_attaches_by_default(self):
        with patch.object(cli,"NativeSession") as session, redirect_stdout(io.StringIO()), redirect_stderr(io.StringIO()):
            for args in (["--native"], ["--native","--activate-passive-window","--pid","123"]):
                with self.assertRaises(SystemExit):cli.main(args+["--out",str(cli.ROOT/"logs/forbidden")])
            session.assert_not_called()

    def test_bounded_module_walk_has_no_discovery_retry_or_unbounded_loop(self):
        next_item=Mock(return_value=object())
        with self.assertRaisesRegex(ObservationAbort,"MODULE_INVENTORY_CAP"):
            cli.bounded_modules(lambda:object(),next_item,stopped=lambda:False)
        self.assertEqual(next_item.call_count,512)
        next_item=Mock()
        with self.assertRaisesRegex(ObservationAbort,"USER_STOP"):
            cli.bounded_modules(lambda:object(),next_item,stopped=lambda:True)
        next_item.assert_not_called()


class FakeKernel:
    """Every native call is replaced, including RPM and VirtualQueryEx."""
    def __init__(self):
        from tools import process_probe as p
        from pokiguard_v2 import il2cpp_external as ext
        self.p, self.ext = p, ext
        self.source = FakeSource()
        self.created = 42
        self.exit_code = 259
        self.region_size = 4096
        self.modules = [
            p.ModuleInfo("PetPuzzle-1.7.4.exe","D:/pc/PetPuzzle-1.7.4.exe",0x400000,0x100000),
            p.ModuleInfo("GameAssembly.dll","D:/pc/GameAssembly.dll",0x10000000,0x4000000),
            p.ModuleInfo("UnityPlayer.dll","D:/pc/UnityPlayer.dll",0x18000000,0x1000000),
        ]
        self.cursor = 0
        self.OpenProcess = Mock(return_value=901)
        self.CloseHandle = Mock(return_value=True)
        self.CreateToolhelp32Snapshot = Mock(return_value=900)
        self.Module32FirstW = Mock(side_effect=self.first)
        self.Module32NextW = Mock(side_effect=self.next)
        self.GetProcessTimes = Mock(side_effect=self.times)
        self.GetExitCodeProcess = Mock(side_effect=self.exit)
        self.VirtualQueryEx = Mock(side_effect=self.query)
        self.ReadProcessMemory = Mock(side_effect=self.read)

    def module(self, ptr):
        if self.cursor >= len(self.modules):
            ctypes.set_last_error(self.p.ERROR_NO_MORE_FILES)
            return False
        m = self.modules[self.cursor]
        e = ptr._obj
        e.szModule, e.szExePath = m.name, m.path
        e.modBaseAddr = ctypes.cast(ctypes.c_void_p(m.base), ctypes.POINTER(ctypes.c_ubyte))
        e.modBaseSize = m.size
        return True

    def first(self, snapshot, ptr):
        self.cursor = 0
        return self.module(ptr)

    def next(self, snapshot, ptr):
        self.cursor += 1
        return self.module(ptr)

    def times(self, handle, created, *unused):
        created._obj.dwLowDateTime = self.created
        created._obj.dwHighDateTime = 0
        return True

    def exit(self, handle, code):
        code._obj.value = self.exit_code
        return True

    def query(self, handle, address, info, size):
        value = address.value
        obj = info._obj
        obj.BaseAddress = value & ~4095
        obj.RegionSize = self.region_size
        obj.State, obj.Protect = self.ext.MEM_COMMIT, 4
        return ctypes.sizeof(obj)

    def read(self, handle, address, buffer, size, returned):
        raw = self.source.memory.read(address.value,size)
        for i,v in enumerate(raw):buffer[i]=v
        returned._obj.value = len(raw)
        return True


class PassiveNativeAdapterFakeTests(unittest.TestCase):
    def setUp(self):
        from tools import process_probe as p
        from pokiguard_v2 import il2cpp_external as ext
        self.fake = FakeKernel()
        self.stack = ExitStack()
        self.addCleanup(self.stack.close)
        self.stack.enter_context(patch.object(p,"kernel32",self.fake))
        self.stack.enter_context(patch.object(ext,"_kernel32",self.fake))
        self.stack.enter_context(patch.object(p,"target_architecture",return_value="x64"))
        self.review = dict(game_dir="D:/pc", source_sha256="a"*64)

    def session(self):
        s=cli.NativeSession(123,self.review,lambda:False)
        self.addCleanup(s.close)
        return s

    def test_real_adapter_opens_only_read_query_rights_and_samples_through_faked_native_rpm(self):
        s=self.session()
        self.fake.OpenProcess.assert_called_once_with(0x410,False,123)
        self.assertEqual(self.fake.CloseHandle.argtypes,[wintypes.HANDLE])
        r=collect(s)
        self.assertEqual(r["verdict"],"LOCAL_OBSERVATION_ONLY")
        self.assertEqual(self.fake.ReadProcessMemory.call_count,90)
        self.assertEqual(self.fake.VirtualQueryEx.call_count,36)
        self.assertEqual(self.fake.GetProcessTimes.call_count,8)
        self.assertEqual(self.fake.GetExitCodeProcess.call_count,8)
        with patch.object(cli,"verify_review") as verify:s.verify_end()
        verify.assert_called_once_with(self.review)
        self.assertEqual(self.fake.CreateToolhelp32Snapshot.call_count,2)
        self.assertEqual(self.fake.GetProcessTimes.call_count,9)
        s.close()
        self.assertEqual(self.fake.CloseHandle.call_count,3)

    def test_module_snapshot_failure_does_not_retry_and_closes_handle(self):
        self.fake.CreateToolhelp32Snapshot.return_value=self.fake.p.INVALID_HANDLE_VALUE
        with self.assertRaises(OSError):self.session()
        self.fake.CreateToolhelp32Snapshot.assert_called_once()
        self.fake.CloseHandle.assert_called_once_with(901)
        self.fake.ReadProcessMemory.assert_not_called()

    def test_other_install_and_oversized_inventory_fail_before_any_rpm(self):
        self.fake.modules[0]=replace(self.fake.modules[0],path="D:/other/PetPuzzle-1.7.4.exe")
        with self.assertRaises(ValueError):self.session()
        self.fake.ReadProcessMemory.assert_not_called()
        self.assertEqual(self.fake.CloseHandle.call_count,2)

    def test_oversized_native_inventory_closes_snapshot_and_process(self):
        self.fake.modules *= 172
        with self.assertRaisesRegex(ObservationAbort,"MODULE_INVENTORY_CAP"):self.session()
        self.assertEqual(self.fake.Module32NextW.call_count,512)
        self.assertEqual(self.fake.CloseHandle.call_count,2)
        self.fake.ReadProcessMemory.assert_not_called()

    def test_identity_exit_or_creation_drift_aborts_without_further_rpm(self):
        for field,value in (("exit_code",0),("created",43)):
            with self.subTest(field=field):
                s=self.session()
                setattr(self.fake,field,value)
                with self.assertRaises(ObservationAbort):s.binding()
                setattr(self.fake,field,259 if field=="exit_code" else 42)
                s.close()
        self.fake.ReadProcessMemory.assert_not_called()

    def test_single_region_validation_rejects_cross_region_without_scanning(self):
        s=self.session()
        self.assertFalse(s.memory.is_readable(0x20000FFF,8))
        self.fake.VirtualQueryEx.assert_called_once()
        self.fake.ReadProcessMemory.assert_not_called()

    def test_module_mapping_drift_rejected_at_final_binding(self):
        s=self.session()
        self.fake.modules[1]=replace(self.fake.modules[1],base=0x11000000)
        with self.assertRaisesRegex(ObservationAbort,"MODULE_MAPPING_DRIFT"):
            s.verify_end()

    def test_stop_during_native_setup_closes_open_handle(self):
        stopped=[False]
        def opened(*args):
            stopped[0]=True
            return 901
        self.fake.OpenProcess.side_effect=opened
        with self.assertRaisesRegex(ObservationAbort,"USER_STOP"):
            cli.NativeSession(123,self.review,lambda:stopped[0])
        self.fake.CloseHandle.assert_called_once_with(901)
        self.fake.CreateToolhelp32Snapshot.assert_not_called()

    def cli_review(self):
        info=cli.time.get_clock_info("perf_counter")
        return dict(self.review,limits=vars(Limits(seconds=1,samples=1)),
            host_clock=dict(name="perf_counter_ns",implementation=info.implementation,
                monotonic=True,resolution_seconds=info.resolution))

    def run_cli(self, temp):
        path=Path(temp)/"review.json"
        path.write_bytes(canonical_bytes(self.cli_review())+b"\n")
        out=Path(temp)/"window"
        buf=io.StringIO()
        with patch.object(cli,"verify_review"),redirect_stdout(buf):
            code=cli.main(["--native","--activate-passive-window","--pid","123",
                "--review-manifest",str(path),"--review-sha256",cli.file_hash(path),"--out",str(out)])
        return code,out,json.loads(buf.getvalue())

    def test_full_cli_faked_native_window_exports_bound_ledger_after_cleanup(self):
        with tempfile.TemporaryDirectory(dir=cli.ROOT) as temp:
            code,out,receipt=self.run_cli(temp)
            self.assertEqual(code,0)
            r=json.loads((out/"observation.json").read_bytes())
            self.assertTrue(r["final_binding_checked"])
            self.assertEqual(len(r["samples"]),1)
            self.assertEqual(r["native_api_counts"]["CloseHandle"],3)
            self.assertFalse(r["input_authority"])
            self.assertIsNone(r["native_U_ms"])
            self.assertEqual(receipt["export"]["status"],"FILE_WRITTEN")

    def test_native_setup_failure_is_retained_with_counts_and_zero_samples(self):
        self.fake.CreateToolhelp32Snapshot.return_value=self.fake.p.INVALID_HANDLE_VALUE
        with tempfile.TemporaryDirectory(dir=cli.ROOT) as temp:
            code,out,receipt=self.run_cli(temp)
            self.assertEqual(code,1)
            r=json.loads((out/"failure.json").read_bytes())
            self.assertEqual(r["samples"],[])
            self.assertEqual(r["native_api_counts"]["CloseHandle"],1)
            self.assertEqual(receipt["failure_export"]["status"],"FILE_WRITTEN")

    def test_same_window_directory_cannot_resume_or_attach_twice(self):
        with tempfile.TemporaryDirectory(dir=cli.ROOT) as temp:
            self.assertEqual(self.run_cli(temp)[0],0)
            code,out,receipt=self.run_cli(temp)
            self.assertEqual(code,1)
            self.assertEqual(receipt["error_category"],"FileExistsError")
            self.fake.OpenProcess.assert_called_once()

    def test_modified_review_file_rejected_before_any_process_api(self):
        with tempfile.TemporaryDirectory(dir=cli.ROOT) as temp:
            p=Path(temp)/"review.json"
            p.write_bytes(canonical_bytes(self.cli_review()))
            with redirect_stdout(io.StringIO()):
                code=cli.main(["--native","--activate-passive-window","--pid","123",
                    "--review-manifest",str(p),"--review-sha256","0"*64,"--out",str(Path(temp)/"window")])
            self.assertEqual(code,1)
            self.fake.OpenProcess.assert_not_called()


class PassivePreparationTests(unittest.TestCase):
    def test_prepare_cli_creates_only_review_and_never_opens_process(self):
        review=dict(schema="synthetic",production_activation=False)
        with tempfile.TemporaryDirectory(dir=cli.ROOT) as temp:
            out=Path(temp)/"prepared"
            with patch.object(cli,"make_review",return_value=review),patch.object(cli,"NativeSession") as native,redirect_stdout(io.StringIO()):
                self.assertEqual(cli.main(["--prepare","--out",str(out)]),0)
                native.assert_not_called()
            self.assertEqual(json.loads((out/"review.json").read_bytes()),review)

    def test_review_manifest_binds_every_source_and_exact_cost_limits(self):
        with patch.object(cli,"file_hash",side_effect=lambda p:cli.GAME_HASHES.get(p.name,"a"*64)):
            # Metadata has a relative nested name; preserve its exact expected hash.
            def hashed(p):
                return next((v for k,v in cli.GAME_HASHES.items() if str(p).replace("\\","/").endswith(k)),"a"*64)
            with patch.object(cli,"file_hash",side_effect=hashed):review=cli.make_review(Path("D:/pc"))
        self.assertIn("tools/passive_clock_observer.py",review["source_files"])
        self.assertEqual(review["cost_contract"]["per_sample_max_bytes"],1336)
        self.assertEqual(review["cost_contract"]["per_sample_max_rpm"],30)
        self.assertEqual(review["cost_contract"]["lifetime_api_max_each"],1203)
        self.assertEqual(review["output_contract"]["max_bytes"],8*1024*1024)
        self.assertFalse(review["production_activation"])

    def test_source_build_and_dependency_drift_rejected_before_attachment(self):
        sources={n:"a"*64 for n in ("tools/passive_clock_observer.py","src/pokiguard_v2/passive_clock_observer.py",
            "src/pokiguard_v2/il2cpp_external.py","src/pokiguard_v2/il2cpp_layout.py","tools/process_probe.py")}
        review=dict(schema="5d1.p5.passive_review.v1",status="PREPARED_NOT_ACTIVATED",input_authority=False,
            production_activation=False,native_U_ms=None,source_files=sources,source_sha256=digest(sources),
            game_files=cli.GAME_HASHES,game_dir="D:/pc",limits=vars(Limits()))
        with patch.object(cli,"file_hash",return_value="c"*64),self.assertRaisesRegex(ValueError,"source binding"):
            cli.verify_review(review)
        with patch.object(cli,"file_hash",return_value="a"*64),self.assertRaisesRegex(ValueError,"game binding"):
            cli.verify_review(review)
        del sources["tools/process_probe.py"]
        review["source_sha256"]=digest(sources)
        with patch.object(cli,"file_hash",return_value="a"*64),self.assertRaisesRegex(ValueError,"missing dependency"):
            cli.verify_review(review)


class PassiveClockP7DiagnosticsTests(unittest.TestCase):
    def failed_decode(self, raw):
        with self.assertRaises(ClockDecodeError) as caught:
            decode_clock(raw)
        return caught.exception

    def test_verified_b6_counterexample_is_accepted_as_reset_sentinel(self):
        parent=cli.ROOT/"docs/phase5/artifacts/5d1_passive_clock_observation_v1"
        evidence=json.loads((parent/"fx_sentinel_file_evidence.json").read_bytes())
        case=json.loads((parent/"sentinel_counterexample.json").read_bytes())
        self.assertEqual({i["stored_bits"] for i in evidence["verified_instructions"]},{"0xbf800000"})
        f=case["fields"]
        value=decode_clock(clock_block(has=f["has_server_clock"],paused=f["paused"],
            remain=f["remain_at_anchor_seconds"],anchor=f["anchor_unscaled_seconds"],fx=f["fx_hold_until_unscaled_seconds"]))
        self.assertEqual(value["fx_hold_until_unscaled_seconds"],-1.0)
        self.assertEqual(value["fx_hold_state"],"RESET_SENTINEL")
        self.assertEqual(value["fx_hold_active"],"UNKNOWN_NO_CURRENT_UNITY_CLOCK")
        native=json.loads((parent/"observation.json").read_bytes())
        self.assertIsNone(native["samples"][0]["clock_a"])
        self.assertEqual(case["actual_failed_sample_fx_value"],"UNKNOWN")

    def test_only_exact_negative_one_fx_is_allowed(self):
        for bits in (0xBF7FFFFF,0xBF800001,0xC0000000,0x80000001):
            raw=bytearray(clock_block());struct.pack_into("<I",raw,0x2C,bits)
            err=self.failed_decode(bytes(raw))
            field=err.diagnostics["fields"][-1]
            self.assertEqual(field["field"],"fx_hold_until_unscaled_seconds")
            self.assertEqual(field["bits_hex"],f"0x{bits:08x}")
            self.assertEqual(field["reason"],"NEGATIVE_NOT_ALLOWED")
        for fx in (0.0,0.125,1026.0):
            self.assertEqual(decode_clock(clock_block(fx=fx))["fx_hold_state"],"VALUE_ONLY_ACTIVE_UNKNOWN")

    def test_negative_remain_and_anchor_are_not_exempted_by_fx_sentinel(self):
        for field,kwargs,offset in (("remain_at_anchor_seconds",dict(remain=-1),0x1D8),
                                    ("anchor_unscaled_seconds",dict(anchor=-1),0x1DC)):
            err=self.failed_decode(clock_block(fx=-1,**kwargs))
            self.assertEqual(err.diagnostics["failed_fields"],[field])
            bad=next(v for v in err.diagnostics["fields"] if v["field"]==field)
            self.assertEqual((bad["offset"],bad["value"],bad["reason"]),(offset,-1.0,"NEGATIVE_NOT_ALLOWED"))
            self.assertTrue(err.diagnostics["fields"][-1]["valid"])

    def test_all_allowlisted_fields_are_kept_even_when_bool_and_floats_fail(self):
        raw=bytearray(clock_block(remain=float("nan"),anchor=float("inf"),fx=-2))
        raw[0:2]=b"\2\3"
        err=self.failed_decode(bytes(raw))
        self.assertEqual(str(err),"INVALID_CLOCK_BOOL")
        self.assertEqual(len(err.diagnostics["fields"]),5)
        self.assertEqual(len(err.diagnostics["failed_fields"]),5)
        self.assertEqual([f["offset"] for f in err.diagnostics["fields"]],[0x1CC,0x1CD,0x1D8,0x1DC,0x1F8])
        self.assertEqual(err.diagnostics["fields"][0]["value"],2)
        self.assertEqual(err.diagnostics["fields"][0]["reason"],"EXPECTED_0_OR_1")

    def test_nonfinite_float_bits_and_values_are_json_safe(self):
        cases=((0x7FA12345,"NAN"),(0x7FC12345,"NAN"),(0xFFC12345,"NAN"),
               (0x7F800000,"POSITIVE_INFINITY"),(0xFF800000,"NEGATIVE_INFINITY"))
        for relative,index in ((0xC,2),(0x10,3),(0x2C,4)):
            for bits,kind in cases:
                raw=bytearray(clock_block(fx=-1));struct.pack_into("<I",raw,relative,bits)
                err=self.failed_decode(bytes(raw));f=err.diagnostics["fields"][index]
                self.assertEqual(f["bits_hex"],f"0x{bits:08x}")
                self.assertEqual(f["classification"],kind)
                self.assertIsNone(f["value"])
                self.assertEqual(json.loads(canonical_bytes(err.diagnostics)),err.diagnostics)

    def test_remain_operational_cap_keeps_finite_value_and_reason(self):
        err=self.failed_decode(clock_block(remain=301,fx=-1))
        f=err.diagnostics["fields"][2]
        self.assertEqual((f["value"],f["reason"]),(301.0,"EXCEEDS_OBSERVER_REMAIN_CAP"))

    def test_clock_A_failure_exports_field_diagnosis_with_original_read_cost(self):
        s=FakeSource(string_size=128)
        s.memory.put(s.root+CLOCK_OFFSET,clock_block(remain=float("nan"),fx=-1))
        r=collect(s);row=r["samples"][0]
        self.assertEqual(row["failure_phase"],"clock_a")
        self.assertEqual(row["clock_diagnostics_a"]["failed_fields"],["remain_at_anchor_seconds"])
        self.assertEqual(row["clock_diagnostics_a"]["phase"],"clock_a")
        self.assertEqual(row["clock_diagnostics_a"]["fields"][-1]["classification"],"FX_RESET_SENTINEL")
        self.assertIsNone(row["clock_diagnostics_b"])
        self.assertEqual((len(s.memory.reads),row["requested_bytes"],len(s.memory.queries)),(15,668,6))
        self.assertEqual(r["verdict"],"INCONCLUSIVE")

    def test_clock_B_failure_keeps_valid_A_and_full_unchanged_cost(self):
        s=FakeSource(string_size=128);n=0
        def read(a,size,raw):
            nonlocal n
            if a==s.root+CLOCK_OFFSET:
                n+=1
                return clock_block(fx=-1,anchor=float("nan") if n==2 else 1024)
            return raw
        s.memory.on_read=read
        r=collect(s);row=r["samples"][0]
        self.assertEqual(row["failure_phase"],"clock_b")
        self.assertEqual(row["clock_a"]["fx_hold_state"],"RESET_SENTINEL")
        self.assertEqual(row["clock_diagnostics_b"]["failed_fields"],["anchor_unscaled_seconds"])
        self.assertIsNone(row["clock_diagnostics_a"])
        self.assertEqual((n,len(s.memory.reads),row["requested_bytes"],len(s.memory.queries)),(2,30,1336,12))

    def test_partial_clock_A_or_B_reports_phase_without_decoding_prefix(self):
        for side in (1,2):
            for prefix in (2,20,47):
                s=FakeSource();n=0
                def read(a,size,raw):
                    nonlocal n
                    if a==s.root+CLOCK_OFFSET:
                        n+=1
                        if n==side:return raw[:prefix]
                    return raw
                s.memory.on_read=read
                row=collect(s)["samples"][0];phase="clock_"+("a" if side==1 else "b")
                diag=row["clock_diagnostics_"+phase[-1]]
                self.assertEqual((row["failure_phase"],row["reason"]),(phase,"PARTIAL_READ"))
                self.assertEqual((diag["expected_bytes"],diag["returned_bytes"]),(48,prefix))
                self.assertEqual(diag["fields"],[])
                self.assertEqual(n,side)

    def test_direct_partial_block_is_not_decoded(self):
        err=self.failed_decode(clock_block(fx=-1)[:47])
        self.assertEqual(str(err),"PARTIAL_CLOCK_READ")
        self.assertEqual(err.diagnostics["status"],"NOT_DECODED_PARTIAL_BLOCK")
        self.assertEqual(err.diagnostics["fields"],[])

    def test_stop_after_clock_read_retains_abort_phase_and_no_more_io(self):
        s=FakeSource();stop=[False]
        def read(a,n,v):
            if a==s.root+CLOCK_OFFSET:stop[0]=True
            return v
        s.memory.on_read=read
        row=collect(s,stopped=lambda:stop[0])["samples"][0]
        self.assertEqual(row["reason"],"USER_STOP")
        self.assertEqual(row["clock_diagnostics_a"]["status"],"NOT_DECODED_READ_ABORT")
        self.assertEqual(row["clock_diagnostics_a"]["fields"],[])
        self.assertEqual(row["failure_phase"],"clock_a")
        self.assertEqual(len(s.memory.reads),15)

    def test_pair_mismatch_keeps_decoded_sides_without_padding_leak(self):
        s=FakeSource();n=0
        def read(a,size,raw):
            nonlocal n
            if a==s.root+CLOCK_OFFSET:
                n+=1
                return clock_block(fx=-1 if n==1 else 0,padding=91)
            return raw
        s.memory.on_read=read;row=collect(s)["samples"][0]
        self.assertEqual((row["reason"],row["failure_phase"]),("CLOCK_BLOCK_MISMATCH","clock_pair_validation"))
        self.assertEqual((row["clock_a"]["fx_hold_until_unscaled_seconds"],row["clock_b"]["fx_hold_until_unscaled_seconds"]),(-1.0,0.0))
        self.assertFalse(row["blocks_equal"])
        self.assertEqual(n,2)

    def test_error_diagnostics_do_not_export_padding_pointers_or_account_strings(self):
        s=FakeSource();raw=bytearray(clock_block(remain=float("nan"),fx=-1))
        secret=b"PTR_REASON_EVENT_SECRET"
        raw[20:20+len(secret)]=secret
        s.memory.put(s.root+CLOCK_OFFSET,bytes(raw))
        r=collect(s);encoded=canonical_bytes(r)
        self.assertNotIn(secret,encoded)
        self.assertNotIn(b"private-account-fixture",encoded)
        self.assertNotIn(b"M_SYNTHETIC",encoded)
        fields=r["samples"][0]["clock_diagnostics_a"]["fields"]
        self.assertEqual({f["offset"] for f in fields},{0x1CC,0x1CD,0x1D8,0x1DC,0x1F8})
        self.assertTrue(all(set(f)=={"field","offset","type","bits_hex","value","classification","valid","reason"} for f in fields))

    def test_error_report_export_keeps_json_safe_fields_and_loss_status(self):
        s=FakeSource();s.memory.put(s.root+CLOCK_OFFSET,clock_block(fx=float("inf")))
        r=collect(s)
        with tempfile.TemporaryDirectory(dir=cli.ROOT) as d:
            p=Path(d)/"error.json";receipt=export_report(r,p)
            self.assertEqual(receipt["status"],"FILE_WRITTEN")
            self.assertEqual(json.loads(p.read_bytes()),r)
            self.assertEqual(export_report(r,p)["reason"],"FileExistsError")
            failed=export_report(r,p,opener=Mock(side_effect=OSError("disk")))
            self.assertEqual(failed["status"],"FAILED")
            self.assertEqual(r["samples"][0]["clock_diagnostics_a"]["failed_fields"],["fx_hold_until_unscaled_seconds"])

    def test_p5_review_cannot_silently_activate_changed_observer(self):
        review=cli.ROOT/"docs/phase5/artifacts/5d1_passive_clock_preparation_v1/prepared_final/review.json"
        with tempfile.TemporaryDirectory(dir=cli.ROOT) as d:
            out=Path(d)/"window"
            with patch.object(cli,"NativeSession") as native,redirect_stdout(io.StringIO()):
                code=cli.main(["--native","--activate-passive-window","--pid","123",
                    "--review-manifest",str(review),"--review-sha256",cli.file_hash(review),"--out",str(out)])
            self.assertEqual(code,1)
            native.assert_not_called()
            self.assertFalse(out.exists())


if __name__ == "__main__":
    unittest.main()
