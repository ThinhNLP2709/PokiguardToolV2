"""Offline B4 diagnostics: one producer, bounded buffer, killable disk writer.

Nothing in this module reads game state or owns input. Encoding/error summaries
belong off the action path. enqueue()/stop() never wait for disk or a child.
"""
from __future__ import annotations

from collections import deque
from dataclasses import dataclass
import hashlib
import json
import multiprocessing as mp
from pathlib import Path
import threading
import time
import traceback


EVENT_SCHEMA = "pokiguard.reasoning.runner_event.v1"


@dataclass(frozen=True)
class LogLimits:
    records: int = 512
    bytes: int = 8 * 1024 * 1024
    reserved_records: int = 32
    reserved_bytes: int = 1024 * 1024
    event_bytes: int = 32 * 1024
    file_bytes: int = 10 * 1024 * 1024
    files: int = 10
    days: int = 7

    def __post_init__(self):
        values = vars(self)
        if any(type(v) is not int or v <= 0 for k, v in values.items()
               if not k.startswith("reserved")):
            raise ValueError("positive integer bounds required")
        if not (0 <= self.reserved_records < self.records and
                0 <= self.reserved_bytes < self.bytes and
                self.records <= 512 and self.bytes <= 8 * 1024 * 1024
                and self.event_bytes <= 32768 and self.event_bytes <= self.file_bytes
                and self.file_bytes <= 10 * 1024 * 1024 and self.files <= 10 and self.days <= 7):
            raise ValueError("invalid diagnostic allocation")


def encode_event(event: str, sequence: int, correlation: dict, payload: dict) -> bytes:
    """Bounded JSON record. A large payload becomes an explicit summary, not bad JSON."""
    body = dict(schema=EVENT_SCHEMA, event_type=event, event_seq=sequence,
                producer="offline_runner_5b4", utc_ns=time.time_ns(),
                host_monotonic_ns=time.perf_counter_ns(), correlation=correlation,
                payload=payload, input_authority=False)
    raw = json.dumps(body, ensure_ascii=False, separators=(",", ":"), allow_nan=False).encode()
    cap = 16384 if event == "reasoning.decision" else 32768
    if len(raw) + 1 > cap:
        body["payload"] = dict(truncated=True, original_bytes=len(raw),
                               original_sha256=hashlib.sha256(raw).hexdigest())
        raw = json.dumps(body, ensure_ascii=False, separators=(",", ":"), allow_nan=False).encode()
    if len(raw) + 1 > cap:
        raise ValueError("correlation exceeds event cap")
    return raw + b"\n"


class DiagnosticBuffer:
    """Single supervisor producer / single writer; try-lock and exact byte caps.

    A second producer is unsupported and rejected. Stats are watermark snapshots;
    accounting_valid=False explicitly marks an observation taken mid-enqueue.
    """
    def __init__(self, limits: LogLimits = LogLimits()):
        self.limits = limits
        self.lock = threading.Lock()
        self.items = deque()
        self.queued_bytes = 0
        self.in_writer = 0
        self.producer = None
        self.producing = False
        self.disabled = False
        self.failure = None
        self.eligible = self.enqueued = self.dropped = 0
        self.written = self.failed_write = self.discarded = 0
        self.busy = self.oversize = self.full = self.wrong_producer = 0
        self.high_records = self.high_bytes = 0

    def enqueue(self, raw: bytes, *, critical: bool = False) -> bool:
        owner = threading.get_ident()
        if self.producer is None:
            self.producer = owner
        if self.producer != owner:
            self.wrong_producer += 1
            return False
        self.producing = True
        self.eligible += 1
        if not self.lock.acquire(blocking=False):
            self.busy += 1
            self.dropped += 1
            self.producing = False
            return False
        try:
            if self.disabled:
                self.dropped += 1
                return False
            if type(raw) is not bytes or not raw.endswith(b"\n") or len(raw) > self.limits.event_bytes:
                self.oversize += 1
                self.dropped += 1
                return False
            records = self.limits.records - (0 if critical else self.limits.reserved_records)
            byte_cap = self.limits.bytes - (0 if critical else self.limits.reserved_bytes)
            if len(self.items) + self.in_writer >= records or self.queued_bytes + len(raw) > byte_cap:
                self.full += 1
                self.dropped += 1
                return False
            self.items.append(raw)
            self.queued_bytes += len(raw)
            self.enqueued += 1
            self.high_records = max(self.high_records, len(self.items) + self.in_writer)
            self.high_bytes = max(self.high_bytes, self.queued_bytes)
            return True
        finally:
            self.producing = False
            self.lock.release()

    def take(self):
        with self.lock:
            if not self.items or self.disabled:
                return None
            raw = self.items.popleft()
            self.in_writer += 1
            # Bytes stay charged until ACK/discard, including the in-flight record.
            return raw

    def finish(self, raw: bytes, *, written=False, failed=False):
        with self.lock:
            self.in_writer -= 1
            self.queued_bytes -= len(raw)
            if written:
                self.written += 1
            elif failed:
                self.failed_write += 1
            else:
                self.discarded += 1

    def disable(self, reason: str):
        with self.lock:
            self.disabled, self.failure = True, reason
            self.discarded += len(self.items)
            self.queued_bytes -= sum(map(len, self.items))
            self.items.clear()

    def stats(self):
        with self.lock:
            result = dict(eligible=self.eligible, enqueued=self.enqueued,
                          dropped_before_enqueue=self.dropped, written=self.written,
                          failed_write=self.failed_write, discarded_after_enqueue=self.discarded,
                          queued=len(self.items), in_writer=self.in_writer,
                          charged_bytes=self.queued_bytes, high_records=self.high_records,
                          high_bytes=self.high_bytes, lock_busy=self.busy, oversize=self.oversize,
                          queue_full=self.full, wrong_producer=self.wrong_producer,
                          disabled=self.disabled, failure=self.failure)
            result["accounting_valid"] = bool(not self.producing and
                self.eligible == self.enqueued + self.dropped and
                self.enqueued == self.written + len(self.items) + self.in_writer +
                self.failed_write + self.discarded)
            return result


def reap_child(process, *, timeout: float = 1.0) -> bool:
    """Only supervisor/cleanup code may call this, never action/Stop handlers."""
    if process is None or process.pid is None:
        return True
    if process.is_alive():
        process.terminate()
    process.join(timeout)
    if process.is_alive():
        process.kill()
        process.join(0)
    return not process.is_alive()


def _next_log_stamp(paths, *, previous, now, stem):
    """Unique ordered filename even with a coarse or regressing wall clock."""
    stamp = max(now, previous + 1)
    for path in paths:
        token = path.name[len(stem) + 1:-6]
        if token.isascii() and token.isdigit():
            stamp = max(stamp, int(token) + 1)
    return stamp


def _disk_writer(connection, directory: str, stem: str, limits: LogLimits):
    root = Path(directory)
    handle = None
    size = 0
    file_stamp = 0
    try:
        root.mkdir(parents=True, exist_ok=True)
        connection.send_bytes(b"READY")
        while True:
            raw = connection.recv_bytes(limits.event_bytes)
            json.loads(raw, parse_constant=lambda value: (_ for _ in ()).throw(ValueError(value)))
            if handle is None or size + len(raw) > limits.file_bytes:
                if handle is not None:
                    handle.close()
                paths = sorted(p for p in root.glob(stem + ".*.jsonl") if not p.is_symlink())
                cutoff = time.time() - limits.days * 86400
                for path in list(paths):
                    if path.stat().st_mtime < cutoff:
                        path.unlink()
                        paths.remove(path)
                file_stamp = _next_log_stamp(paths, previous=file_stamp, now=time.time_ns(), stem=stem)
                while len(paths) >= limits.files:
                    paths.pop(0).unlink()
                path = root / f"{stem}.{file_stamp:020d}.jsonl"
                handle, size = path.open("xb", buffering=0), 0
            offset = 0
            while offset < len(raw):
                wrote = handle.write(raw[offset:])
                if not wrote:
                    raise OSError("short diagnostic write")
                offset += wrote
            size += len(raw)
            connection.send_bytes(b"1")
    except EOFError:
        pass
    except Exception as exc:
        try:
            connection.send_bytes((type(exc).__name__ + ":" + str(exc))[:800].encode())
        except (OSError, EOFError):
            pass
    finally:
        if handle is not None:
            handle.close()
        connection.close()


class BoundedDiagnostics:
    """Disk process is killable even if a filesystem write stalls indefinitely."""
    def __init__(self, directory: Path, *, stem="reasoning", limits=LogLimits(),
                 writer_target=_disk_writer):
        if stem not in {"reasoning", "shared"}:
            raise ValueError("isolated diagnostic allocation required")
        self.buffer = DiagnosticBuffer(limits)
        self.context = mp.get_context("spawn")
        self.stop_event = threading.Event()
        self.process = None
        self.pid = None
        self.reaped = False
        self.writer_target = writer_target
        self.directory, self.stem, self.limits = str(directory), stem, limits
        self.thread = threading.Thread(target=self._serve, name="reasoning-diagnostics", daemon=True)
        self.thread.start()

    def _serve(self):
        parent, child = self.context.Pipe()
        raw = None
        try:
            self.process = self.context.Process(target=self.writer_target,
                args=(child, self.directory, self.stem, self.limits), daemon=True)
            self.process.start()
            self.pid = self.process.pid
            child.close()
            while not parent.poll(0.005):
                if self.stop_event.is_set():
                    return
                if not self.process.is_alive():
                    raise OSError("diagnostic writer exited before ready")
            ready = parent.recv_bytes(1024)
            if ready != b"READY":
                raise OSError(ready.decode(errors="replace"))
            while not self.stop_event.is_set():
                raw = self.buffer.take()
                if raw is None:
                    if not self.process.is_alive():
                        raise OSError("diagnostic writer exited")
                    self.stop_event.wait(0.002)
                    continue
                parent.send_bytes(raw)
                while not parent.poll(0.005):
                    if self.stop_event.is_set():
                        return
                    if not self.process.is_alive():
                        raise OSError("diagnostic writer exited before ACK")
                ack = parent.recv_bytes(1024)
                if ack != b"1":
                    raise OSError(ack.decode(errors="replace"))
                self.buffer.finish(raw, written=True)
                raw = None
        except Exception as exc:
            if raw is not None:
                self.buffer.finish(raw, failed=True)
                raw = None
            self.buffer.disable(type(exc).__name__ + ":" + str(exc))
        finally:
            if raw is not None:
                self.buffer.finish(raw)  # unconfirmed write, not claimed written
            self.buffer.disable(self.buffer.failure or "CLOSED")
            self.reaped = reap_child(self.process)
            if self.process is not None and self.reaped:
                self.process.close()
            parent.close()
            child.close()
            self.pid = None

    def enqueue(self, raw: bytes, *, critical=False):
        return self.buffer.enqueue(raw, critical=critical)

    def stop(self):
        self.stop_event.set()

    def close(self, timeout=1.2):
        self.stop()
        self.thread.join(timeout)
        return not self.thread.is_alive() and self.reaped

    def flush(self, timeout=5.0):
        """Offline measurement/cleanup only; never called by runner/Stop."""
        deadline = time.perf_counter() + timeout
        while time.perf_counter() < deadline:
            stats = self.buffer.stats()
            if stats["disabled"] or not (stats["queued"] + stats["in_writer"]):
                return not stats["disabled"]
            time.sleep(0.002)
        return False


class ErrorSummaries:
    """Used only by the supervisor: at most 64 signatures plus one overflow."""
    def __init__(self, emit, clock=time.perf_counter):
        self.emit, self.clock = emit, clock
        self.signatures = {}
        self.aggregated = self.overflow = 0

    def record(self, stage: str, exc: BaseException, correlation: dict):
        frames = traceback.extract_tb(exc.__traceback__)
        frame = (frames[-1].name + ":" + str(frames[-1].lineno)) if frames else "NO_FRAME"
        signature = (stage, type(exc).__name__, frame, EVENT_SCHEMA)
        now = self.clock()
        item = self.signatures.get(signature)
        if item is None and len(self.signatures) >= 64:
            self.overflow += 1
            self.aggregated += 1
            return
        if item is None:
            self.signatures[signature] = dict(count=1, first=now, last=now, emitted=now)
            stack = "".join(traceback.format_exception(type(exc), exc, exc.__traceback__, limit=12))[-16000:]
            self.emit("reasoning.error", correlation, dict(signature=signature, count=1,
                first=now, last=now, exception=str(exc)[:2000], stack=stack), True)
            return
        item["count"] += 1
        item["last"] = now
        self.aggregated += 1
        if now - item["emitted"] >= 30:
            self.emit("reasoning.error", correlation,
                      dict(signature=signature, count=item["count"], first=item["first"], last=now), True)
            item["emitted"] = now
