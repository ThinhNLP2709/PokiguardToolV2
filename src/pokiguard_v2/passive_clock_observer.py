"""Standalone diagnostic projection. Never grants gameplay/input authority.

No attachment, provider polling, native clock call, input or network lives here.
The caller supplies a read-only memory interface, lifetime binding and clock.
"""
from __future__ import annotations

from dataclasses import asdict, dataclass
import hashlib
import json
import math
from pathlib import Path
import struct
from typing import Callable

from .il2cpp_external import (
    Il2CppExternalResolver, MATCH_SERVICE_SINGLETON, MAX_USER_ADDRESS,
    MATCH_SERVICE_CURRENT_MATCH_ID_OFFSET, MATCH_SERVICE_CURRENT_TURN_PLAYER_OFFSET,
    MATCH_SERVICE_TURN_NUMBER_OFFSET, MATCH_SERVICE_TURN_DURATION_SEC_OFFSET,
    MATCH_SERVICE_TURN_TIME_REMAINING_SEC_OFFSET, checked_address,
    is_canonical_user_pointer,
)
from .il2cpp_layout import read_i32, read_il2cpp_string, read_pointer

SCHEMA = "5d1.p7.passive_clock.v2"
CLOCK_DIAGNOSTICS_SCHEMA = "5d1.p7.clock_fields.v1"
CLOCK_OFFSET = 0x1CC
CLOCK_BYTES = 48
STRING_CAP = 128
MAX_OUTPUT_BYTES = 8 * 1024 * 1024
# Two identities: each 3 root RPM, 2 string pointers, 6 string reads
# (header/class/data), 3 Int32 fields. Plus two 48-byte clock blocks.
MAX_SAMPLE_RPM = 30
MAX_SAMPLE_BYTES = 1336
MAX_SAMPLE_READABILITY_CHECKS = 12


class ObservationAbort(RuntimeError):
    pass


class ClockDecodeError(ObservationAbort):
    def __init__(self, reason, diagnostics):
        super().__init__(reason)
        self.diagnostics = diagnostics


@dataclass(frozen=True)
class Limits:
    seconds: float = 60.0
    samples: int = 600
    hz: float = 10.0
    max_read_span_ms: float = 50.0

    def __post_init__(self):
        for name, cap in (("seconds", 60), ("hz", 10), ("max_read_span_ms", 100)):
            v = getattr(self, name)
            if isinstance(v, bool) or not isinstance(v, (int, float)) or not math.isfinite(v) or not 0 < v <= cap:
                raise ValueError("invalid " + name)
        if type(self.samples) is not int or not 1 <= self.samples <= 600:
            raise ValueError("invalid samples")


@dataclass(frozen=True)
class Binding:
    source_sha256: str
    game_sha256: str
    pid: int
    process_created_ticks: int
    module_base: int
    module_size: int
    native: bool = False

    def __post_init__(self):
        for digest in (self.source_sha256, self.game_sha256):
            if len(digest) != 64 or any(c not in "0123456789abcdef" for c in digest):
                raise ValueError("invalid binding digest")
        if type(self.pid) is not int or self.pid <= 0 or type(self.process_created_ticks) is not int or self.process_created_ticks <= 0:
            raise ValueError("invalid process lifetime")
        if (not is_canonical_user_pointer(self.module_base) or self.module_size <= 0
                or self.module_base + self.module_size > MAX_USER_ADDRESS + 1):
            raise ValueError("invalid module binding")


def canonical_bytes(value) -> bytes:
    return json.dumps(value, sort_keys=True, separators=(",", ":"), allow_nan=False).encode("utf-8")


def digest(value) -> str:
    return hashlib.sha256(canonical_bytes(value)).hexdigest()


def _clock_diagnostics(raw: bytes) -> dict:
    """Only the five allowlisted fields; never padding/pointers/full blocks."""
    fields = []
    for name, relative in (("has_server_clock", 0), ("paused", 1)):
        value = raw[relative]
        valid = value in (0, 1)
        fields.append(dict(field=name, offset=CLOCK_OFFSET + relative, type="bool",
            bits_hex=f"0x{value:02x}", value=bool(value) if valid else value,
            classification="BOOLEAN" if valid else "INVALID_BOOL_BYTE", valid=valid,
            reason=None if valid else "EXPECTED_0_OR_1"))
    for name, relative in (("remain_at_anchor_seconds", 0xC),
                           ("anchor_unscaled_seconds", 0x10),
                           ("fx_hold_until_unscaled_seconds", 0x2C)):
        bits = struct.unpack_from("<I", raw, relative)[0]
        value = struct.unpack_from("<f", raw, relative)[0]
        reason = None
        if math.isnan(value):
            classification, reason = "NAN", "NONFINITE"
        elif math.isinf(value):
            classification, reason = ("POSITIVE_INFINITY" if value > 0 else "NEGATIVE_INFINITY"), "NONFINITE"
        elif name == "fx_hold_until_unscaled_seconds" and bits == 0xBF800000:
            # Current-b6 ClearLocalFxHold/ApplyTimingFields explicitly write
            # this exact reset sentinel. It is not a negative clock reading.
            classification = "FX_RESET_SENTINEL"
        elif value < 0:
            classification, reason = "NEGATIVE_FINITE", "NEGATIVE_NOT_ALLOWED"
        elif name == "remain_at_anchor_seconds" and value > 300:
            classification, reason = "FINITE_NONNEGATIVE", "EXCEEDS_OBSERVER_REMAIN_CAP"
        else:
            classification = "FINITE_NONNEGATIVE"
        fields.append(dict(field=name, offset=CLOCK_OFFSET + relative, type="float32",
            bits_hex=f"0x{bits:08x}", value=value if math.isfinite(value) else None,
            classification=classification, valid=reason is None, reason=reason))
    failures = [v["field"] for v in fields if not v["valid"]]
    return dict(schema=CLOCK_DIAGNOSTICS_SCHEMA, expected_bytes=CLOCK_BYTES,
        returned_bytes=len(raw), status="INVALID" if failures else "VALID",
        failed_fields=failures, fields=fields)


def decode_clock(raw: bytes) -> dict:
    if len(raw) != CLOCK_BYTES:
        raise ClockDecodeError("PARTIAL_CLOCK_READ", dict(schema=CLOCK_DIAGNOSTICS_SCHEMA,
            expected_bytes=CLOCK_BYTES, returned_bytes=len(raw),
            status="NOT_DECODED_PARTIAL_BLOCK", failed_fields=[], fields=[]))
    diagnostics = _clock_diagnostics(raw)
    if diagnostics["failed_fields"]:
        bool_failed = any(not f["valid"] and f["type"] == "bool" for f in diagnostics["fields"])
        raise ClockDecodeError("INVALID_CLOCK_BOOL" if bool_failed else "INVALID_CLOCK_FLOAT", diagnostics)
    values = {v["field"]: v["value"] for v in diagnostics["fields"]}
    remain, anchor, fx = (values[n] for n in (
        "remain_at_anchor_seconds", "anchor_unscaled_seconds", "fx_hold_until_unscaled_seconds"))
    ulp = math.ldexp(1.0, max(-149, math.frexp(anchor)[1] - 24)) if anchor else math.ldexp(1.0, -149)
    return dict(has_server_clock=bool(raw[0]), paused=bool(raw[1]),
        remain_at_anchor_seconds=remain, anchor_unscaled_seconds=anchor,
        fx_hold_until_unscaled_seconds=fx, anchor_float32_ulp_seconds=ulp,
        fx_hold_state="RESET_SENTINEL" if fx == -1.0 else "VALUE_ONLY_ACTIVE_UNKNOWN",
        fx_hold_active="UNKNOWN_NO_CURRENT_UNITY_CLOCK")


class GuardedMemory:
    """Bound and account for every RPM/readability call made by reused decoders."""
    read_validates_range = True

    def __init__(self, memory, now_ns, stopped, deadline_ns, span_deadline_ns):
        self.memory, self.now_ns, self.stopped = memory, now_ns, stopped
        self.deadline_ns, self.span_deadline_ns = deadline_ns, span_deadline_ns
        self.calls, self.queries = [], []
        self.requested_bytes = self.returned_bytes = 0
        self.phase = "identity_a"

    def checkpoint(self):
        if self.stopped():
            raise ObservationAbort("USER_STOP")
        now = self.now_ns()
        if now >= self.deadline_ns:
            raise ObservationAbort("WINDOW_CAP")
        if now > self.span_deadline_ns:
            raise ObservationAbort("READ_SPAN_CAP")

    def is_readable(self, address, size):
        self.checkpoint()
        if len(self.queries) >= MAX_SAMPLE_READABILITY_CHECKS:
            raise ObservationAbort("READABILITY_CAP")
        check = dict(phase=self.phase, address=address, bytes=size, status="STARTED")
        self.queries.append(check)
        try:
            value = self.memory.is_readable(address, size)
        except Exception:
            check["status"] = "READABILITY_ERROR"
            raise ObservationAbort("READABILITY_ERROR") from None
        check["status"] = "OK" if value else "UNREADABLE"
        self.checkpoint()
        return value

    def read(self, address, size):
        self.checkpoint()
        if (type(size) is not int or size <= 0 or not is_canonical_user_pointer(address)
                or address + size > MAX_USER_ADDRESS + 1):
            raise ObservationAbort("INVALID_READ_RANGE")
        if len(self.calls) >= MAX_SAMPLE_RPM or self.requested_bytes + size > MAX_SAMPLE_BYTES:
            raise ObservationAbort("RPM_CAP")
        call = dict(phase=self.phase, address=address, bytes=size, returned=0, status="STARTED")
        self.calls.append(call)
        self.requested_bytes += size
        try:
            raw = self.memory.read(address, size)
        except Exception:
            call["status"] = "READ_ERROR"
            raise ObservationAbort("READ_ERROR") from None
        call["returned"] = len(raw)
        self.returned_bytes += len(raw)
        call["status"] = "OK" if len(raw) == size else "PARTIAL"
        if len(raw) != size:
            raise ObservationAbort("PARTIAL_READ")
        self.checkpoint()
        return raw


def _identity(memory, binding: Binding) -> dict:
    resolver = Il2CppExternalResolver(memory, binding.module_base, binding.module_size)
    root = resolver.resolve_singleton(MATCH_SERVICE_SINGLETON)
    if not root.resolved:
        raise ObservationAbort("ROOT_UNRESOLVED")
    address = root.instance
    strings = []
    for offset in (MATCH_SERVICE_CURRENT_MATCH_ID_OFFSET, MATCH_SERVICE_CURRENT_TURN_PLAYER_OFFSET):
        ptr = read_pointer(memory, checked_address(address, offset))
        value = read_il2cpp_string(memory, ptr, max_length=STRING_CAP)
        if not value:
            raise ObservationAbort("MISSING_IDENTITY_STRING")
        strings.append(hashlib.sha256(value.encode("utf-8")).hexdigest())
    turn, duration, remaining = (read_i32(memory, checked_address(address, p)) for p in (
        MATCH_SERVICE_TURN_NUMBER_OFFSET, MATCH_SERVICE_TURN_DURATION_SEC_OFFSET,
        MATCH_SERVICE_TURN_TIME_REMAINING_SEC_OFFSET))
    if not 0 <= turn <= 1_000_000 or not 1 <= duration <= 300 or not 0 <= remaining <= 300:
        raise ObservationAbort("INVALID_TURN_TIMER")
    return dict(binding=asdict(binding), match_service=address,
        match_id_sha256=strings[0], current_player_sha256=strings[1],
        turn=turn, duration_seconds=duration, raw_remaining_seconds=remaining)


def sample_once(source, pinned: Binding, *, now_ns, stopped, deadline_ns, limits: Limits) -> dict:
    start = now_ns()
    memory = GuardedMemory(source.memory, now_ns, stopped, deadline_ns,
        start + int(limits.max_read_span_ms * 1_000_000))
    row = dict(start_ns=start, end_ns=None, status="INVALID", reason=None,
        identity_a=None, identity_b=None, clock_a=None, clock_b=None, blocks_equal=None,
        clock_diagnostics_a=None, clock_diagnostics_b=None, failure_phase=None)
    try:
        blocks = []
        for side in ("a", "b"):
            memory.phase = "identity_" + side
            memory.checkpoint()
            binding = source.binding()
            memory.checkpoint()
            if binding != pinned:
                raise ObservationAbort("PROCESS_SOURCE_BUILD_DRIFT")
            identity = _identity(memory, binding)
            row["identity_" + side] = identity
            memory.phase = "clock_" + side
            raw = memory.read(checked_address(identity["match_service"], CLOCK_OFFSET), CLOCK_BYTES)
            blocks.append(raw)
            try:
                row["clock_" + side] = decode_clock(raw)
            except ClockDecodeError as exc:
                row["clock_diagnostics_" + side] = dict(exc.diagnostics, phase=memory.phase)
                raise
        row["blocks_equal"] = blocks[0] == blocks[1]
        memory.phase = "identity_pair_validation"
        if row["identity_a"] != row["identity_b"]:
            raise ObservationAbort("IDENTITY_DRIFT_WITHIN_SAMPLE")
        memory.phase = "clock_pair_validation"
        if not row["blocks_equal"]:
            raise ObservationAbort("CLOCK_BLOCK_MISMATCH")
        memory.phase = "anchor_validation"
        if not row["clock_a"]["has_server_clock"]:
            raise ObservationAbort("MISSING_ANCHOR")
        row.update(status="VALID", reason="LOCAL_FIELDS_ONLY")
    except ObservationAbort as exc:
        row["reason"] = str(exc)
        row["failure_phase"] = memory.phase
        if memory.phase in ("clock_a", "clock_b"):
            key = "clock_diagnostics_" + memory.phase[-1]
            if row[key] is None:
                call = memory.calls[-1] if memory.calls and memory.calls[-1]["phase"] == memory.phase else None
                row[key] = dict(schema=CLOCK_DIAGNOSTICS_SCHEMA, phase=memory.phase,
                    status="NOT_DECODED_READ_ABORT", reason=str(exc), expected_bytes=CLOCK_BYTES,
                    returned_bytes=call["returned"] if call else 0, failed_fields=[], fields=[])
    except Exception as exc:
        row["reason"] = "READER_ERROR_" + type(exc).__name__[:64]
        row["failure_phase"] = memory.phase
    row.update(end_ns=now_ns(), rpm_calls=memory.calls, readability_checks=memory.queries,
        requested_bytes=memory.requested_bytes, returned_bytes=memory.returned_bytes)
    if row["end_ns"] < start:
        row.update(status="INVALID", reason="HOST_CLOCK_REGRESSION", failure_phase="host_clock_validation")
    return row


def observe(source, *, now_ns: Callable[[], int], wait: Callable[[float], None],
            stopped: Callable[[], bool], limits=Limits()) -> dict:
    """One window, no retries/catch-up. Disk export happens after collection."""
    start = now_ns()
    deadline = start + int(limits.seconds * 1_000_000_000)
    pinned = source.binding()
    rows, previous, reason, next_start = [], None, "SAMPLE_CAP", start
    lost, log_bytes = 0, 0
    last_now = start
    period = math.ceil(1_000_000_000 / limits.hz)
    while len(rows) < limits.samples:
        if stopped():
            reason = "USER_STOP"
            break
        now = now_ns()
        if now < last_now:
            reason = "HOST_CLOCK_REGRESSION"
            break
        last_now = now
        if now >= deadline:
            reason = "WINDOW_CAP"
            break
        if now < next_start:
            wait(min(.02, (min(next_start, deadline) - now) / 1_000_000_000))
            continue
        row = sample_once(source, pinned, now_ns=now_ns, stopped=stopped,
            deadline_ns=deadline, limits=limits)
        row["index"] = len(rows)
        identity = row["identity_a"]
        session = None if identity is None else (identity["binding"], identity["match_service"], identity["match_id_sha256"])
        if previous is not None and session is not None and session != previous:
            row.update(status="INVALID", reason="SESSION_DRIFT_BETWEEN_SAMPLES", failure_phase="session_validation")
        size = len(canonical_bytes(row))
        if log_bytes + size > MAX_OUTPUT_BYTES - 65536:
            lost, reason = 1, "LOG_CAP"
            break
        rows.append(row)
        last_now = row["end_ns"]
        log_bytes += size
        if row["status"] != "VALID":
            reason = row["reason"]
            break
        previous = session
        next_start = row["end_ns"] + period
    valid = [r for r in rows if r["status"] == "VALID"]
    clean_end = reason in ("SAMPLE_CAP", "WINDOW_CAP", "USER_STOP")
    return dict(schema=SCHEMA, binding=asdict(pinned), limits=asdict(limits),
        start_ns=start, end_ns=now_ns(), stop_reason=reason, samples=rows,
        attempted_samples=len(rows) + lost, dropped_records=lost,
        complete_attempt_ledger=not lost,
        verdict="LOCAL_OBSERVATION_ONLY" if valid and len(valid) == len(rows) and clean_end and not lost else "INCONCLUSIVE",
        native_U_ms=None, transport_age_ms=None, host_unity_alignment_ms=None,
        input_authority=False, production_activation=False,
        atomic_snapshot_proven=False, anchor_change_is_tick_receipt=False,
        observations=dict(valid_samples=len(valid),
            paused_samples=sum(r["clock_a"]["paused"] for r in valid),
            anchor_changes=sum(a["clock_a"]["anchor_unscaled_seconds"] != b["clock_a"]["anchor_unscaled_seconds"] for a,b in zip(valid, valid[1:])),
            raw_timer_changes=sum(a["identity_a"]["raw_remaining_seconds"] != b["identity_a"]["raw_remaining_seconds"] for a,b in zip(valid, valid[1:])),
            anchor_change_cause="UNKNOWN_SERVER_OR_LOCAL_FX", fx_active="UNKNOWN"))


def export_report(report: dict, path: Path, *, opener=open) -> dict:
    """Exclusive, bounded, post-collection export; retain partial failures."""
    raw = canonical_bytes(report) + b"\n"
    receipt = dict(status="FAILED", expected_bytes=len(raw), written_bytes=0, durable=False)
    if len(raw) > MAX_OUTPUT_BYTES:
        return dict(receipt, reason="OUTPUT_CAP")
    try:
        with opener(path, "xb") as stream:
            receipt["written_bytes"] = stream.write(raw)
            if receipt["written_bytes"] != len(raw):
                return dict(receipt, reason="PARTIAL_WRITE")
        return dict(receipt, status="FILE_WRITTEN", reason=None)
    except OSError as exc:
        return dict(receipt, reason=type(exc).__name__)
