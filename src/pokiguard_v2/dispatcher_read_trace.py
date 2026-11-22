"""Bounded host metadata from completed root reads; no memory or file I/O.

Tokens express address equality only within one trace generation. They do not
prove object lifetime, DTO pooling, server completeness or authority to act.
"""
from collections import deque
from dataclasses import dataclass
from datetime import datetime, timezone
import hashlib
import secrets
import struct
import threading
import time

MAX_EVENTS = 128
MAX_EVENT_ROOTS = 8
MAX_ALIAS_EVENTS = 16
MAX_PROTECTED_ROOT_EVENTS = 256
MAX_PROTECTED_ERROR_EVENTS = 32
MAX_RECENT_READS = 4
MAX_ROOTS = 512
TIMING_EVENT_THRESHOLD_NS = 20_000_000


@dataclass(frozen=True)
class RootIdentity:
    callback_token: str
    dto_token: str
    json_token: str | None
    source: str
    logical_index: int


@dataclass(frozen=True)
class ReadTicket:
    trace_id: str
    read_id: int
    started_ns: int
    gap_since_previous_end_ns: int | None


@dataclass(frozen=True)
class RootReadEvent:
    trace_id: str
    read_id: int
    started_ns: int
    finished_ns: int
    kind: str
    error_code: str | None
    root_count: int | None
    roots: tuple[RootIdentity, ...]
    omitted_roots: int
    shared_dto_groups: int
    gap_since_previous_end_ns: int | None


@dataclass(frozen=True)
class RootReadBinding:
    trace_id: str
    read_id: int
    read_started_ns: int
    read_finished_ns: int
    decoded_ns: int
    root: RootIdentity


@dataclass(frozen=True)
class RootReadDiagnostics:
    schema: str = 'pokiguard.dispatcher_read_trace.v1'
    trace_id: str | None = None
    match_id: str | None = None
    utc_anchor: str | None = None
    monotonic_anchor_ns: int | None = None
    reads_started: int = 0
    reads_completed: int = 0
    read_failures: int = 0
    empty_reads: int = 0
    nonempty_reads: int = 0
    shared_dto_read_samples: int = 0
    max_read_duration_ns: int = 0
    max_read_started_ns: int | None = None
    max_gap_since_previous_end_ns: int = 0
    max_gap_ended_at_read_started_ns: int | None = None
    last_started_ns: int | None = None
    last_finished_ns: int | None = None
    last_error_code: str | None = None
    last_error_ns: int | None = None
    events: tuple[RootReadEvent, ...] = ()
    alias_events: tuple[RootReadEvent, ...] = ()
    dropped_events: int = 0
    dropped_alias_events: int = 0
    obsolete_completions: int = 0
    event_limit: int = MAX_EVENTS
    event_root_limit: int = MAX_EVENT_ROOTS
    alias_event_limit: int = MAX_ALIAS_EVENTS
    timing_event_threshold_ns: int = TIMING_EVENT_THRESHOLD_NS
    input_authority: bool = False
    effect_completeness: str = 'UNKNOWN'
    token_semantics: str = 'PER_TRACE_ADDRESS_EQUALITY_NOT_OBJECT_LIFETIME'
    match_semantics: str = 'TAP_CONTEXT_NOT_CONTENT_IDENTITY_OF_EVERY_ROOT'
    protected_root_events: tuple[RootReadEvent, ...] = ()
    protected_error_events: tuple[RootReadEvent, ...] = ()
    protected_root_events_observed: int = 0
    protected_error_events_observed: int = 0
    omitted_protected_root_events: int = 0
    omitted_protected_error_events: int = 0
    protected_root_event_limit: int = MAX_PROTECTED_ROOT_EVENTS
    protected_error_event_limit: int = MAX_PROTECTED_ERROR_EVENTS
    protected_history_retention: str = 'FIRST_HALF_AND_RECENT_HALF_PER_KIND'
    protected_history_scope: str = 'OBSERVED_EVENTS_NOT_CONTINUOUS_READ_OR_SERVER_RESPONSE_HISTORY'


class _ProtectedHistory:
    """Keep a fixed prefix and rolling suffix; caller owns the trace lock."""
    def __init__(self, limit):
        self._head_limit = limit // 2
        self._head = []
        self._tail = deque(maxlen=limit - self._head_limit)
        self.observed = self.omitted = 0
        self.events = ()

    def append(self, event):
        self.observed += 1
        if len(self._head) < self._head_limit:
            self._head.append(event)
        else:
            self.omitted += len(self._tail) == self._tail.maxlen
            self._tail.append(event)
        self.events = tuple(self._head) + tuple(self._tail)


def error_code(error):
    """Fixed labels only; exception text may contain addresses or user content."""
    if isinstance(error, OSError):
        return 'OS_READ_ERROR'
    message = str(error)[:128]
    for text, code in (
        ('dispatcher queue changed during read', 'QUEUE_TORN'),
        ('dispatcher drain list changed during read', 'DRAIN_TORN'),
        ('dispatcher roots changed during read', 'ROOTS_TORN'),
        ('ChatService callback changed during read', 'CLOSURE_TORN'),
        ('dispatcher type-info is unavailable', 'TYPE_INFO_UNAVAILABLE'),
    ):
        if message == text:
            return code
    for prefix, code in (
        ('dispatcher queue ', 'QUEUE_READ_REJECTED'),
        ('dispatcher drain ', 'DRAIN_READ_REJECTED'),
        ('ChatService callback ', 'CLOSURE_READ_REJECTED'),
    ):
        if message.startswith(prefix):
            return code
    return 'ROOT_READ_REJECTED'


def _match_context(value):
    return value if (type(value) is str and 0 < len(value) <= 256
        and all(ord(c) >= 32 for c in value)) else None


class DispatcherReadTrace:
    def __init__(self):
        self._lock = threading.Lock()
        self.reset(None)

    def reset(self, match_id):
        with self._lock:
            self._salt = secrets.token_bytes(16)
            self._trace_id = secrets.token_hex(12)
            self._match_id = _match_context(match_id)
            self._utc_anchor = datetime.now(timezone.utc).isoformat()
            self._anchor = time.monotonic_ns()
            self._started = self._completed = self._failed = 0
            self._empty = self._nonempty = self._aliases = 0
            self._max_duration = self._max_gap = 0
            self._max_duration_start = self._max_gap_end = None
            self._last_start = self._last_end = self._last_error_ns = None
            self._last_error = None
            self._events = deque(maxlen=MAX_EVENTS)
            self._alias_events = deque(maxlen=MAX_ALIAS_EVENTS)
            self._protected_roots = _ProtectedHistory(MAX_PROTECTED_ROOT_EVENTS)
            self._protected_errors = _ProtectedHistory(MAX_PROTECTED_ERROR_EVENTS)
            self._events_view = self._alias_view = ()
            self._dropped = self._dropped_alias = self._obsolete = 0
            self._recent = deque(maxlen=MAX_RECENT_READS)
            self._signature = None

    def begin(self):
        now = time.monotonic_ns()
        with self._lock:
            self._started += 1
            gap = None if self._last_end is None else max(0, now - self._last_end)
            self._last_start = now
            if gap is not None:
                if gap > self._max_gap:
                    self._max_gap_end = now
                self._max_gap = max(self._max_gap, gap)
            return ReadTicket(self._trace_id, self._started, now, gap)

    def bind_match(self, match_id):
        with self._lock:
            match_id = _match_context(match_id)
            if match_id is None:
                return
            if self._match_id not in (None, match_id):
                raise ValueError('TRACE_MATCH_CONTEXT_CHANGED_WITHOUT_RESET')
            self._match_id = match_id

    def _token(self, domain, address):
        if address is None:
            return None
        if type(address) is not int or not 0 < address < 2**64:
            raise ValueError('INVALID_TRACE_ADDRESS')
        return hashlib.blake2b(domain + struct.pack('<Q', address), key=self._salt, digest_size=12).hexdigest()

    def _identity(self, root):
        return RootIdentity(self._token(b'C', root.closure_address), self._token(b'D', root.message_address),
            self._token(b'J', root.json_address),
            root.source if root.source in ('execution_queue', 'drain_buffer') else 'UNKNOWN',
            root.logical_index if type(root.logical_index) is int and 0 <= root.logical_index < 256 else -1)

    def complete(self, ticket, *, roots=(), error=None):
        end = time.monotonic_ns()
        if type(ticket) is not ReadTicket:
            return
        with self._lock:
            if ticket.trace_id != self._trace_id:
                self._obsolete += 1
                return
            self._completed += 1
            self._last_end = end if self._last_end is None else max(end, self._last_end)
            duration = max(0, end - ticket.started_ns)
            if duration > self._max_duration:
                self._max_duration, self._max_duration_start = duration, ticket.started_ns
            if error is not None:
                self._failed += 1
                code = error_code(error)
                self._last_error, self._last_error_ns = code, end
                signature = ('ERROR', code)
                members, aliases, count, kind = (), 0, None, 'READ_ERROR'
            else:
                if type(roots) is not tuple or len(roots) > MAX_ROOTS:
                    raise ValueError('INVALID_COMPLETED_ROOT_SET')
                self._nonempty += bool(roots)
                self._empty += not roots
                signature = tuple((r.closure_address, r.message_address, r.json_address, r.source, r.logical_index)
                    for r in roots)
                groups = {}
                for r in roots:
                    groups.setdefault(r.message_address, set()).add((r.closure_address, r.json_address))
                alias_addresses = {address for address, values in groups.items() if len(values) > 1}
                aliases = len(alias_addresses)
                self._aliases += bool(aliases)
                self._recent.append((roots, ticket, end))
                count, code, kind = len(roots), None, 'ROOT_SET' if roots else 'EMPTY'
                timing_event = ((ticket.gap_since_previous_end_ns or 0) >= TIMING_EVENT_THRESHOLD_NS
                    or duration >= TIMING_EVENT_THRESHOLD_NS)
                if signature == self._signature and not timing_event:
                    return
                if signature == self._signature:
                    kind = 'READ_TIMING_GAP'
                # Prefer a complete alias pair in the bounded event member view.
                ordered = sorted(roots, key=lambda r: r.message_address not in alias_addresses) if aliases else roots
                members = tuple(self._identity(r) for r in ordered[:MAX_EVENT_ROOTS])
            event = RootReadEvent(ticket.trace_id, ticket.read_id, ticket.started_ns, end, kind, code,
                count, members, max(0, (count or 0) - len(members)), aliases, ticket.gap_since_previous_end_ns)
            if error is not None:
                # Keep individual failure timestamps even when the legacy tail
                # compresses a repeated error label. Noise cannot evict them.
                self._protected_errors.append(event)
                if signature == self._signature:
                    return
            elif kind == 'ROOT_SET':
                # Membership witnesses only: EMPTY and timing events remain in
                # the legacy tail and cannot displace this bounded history.
                self._protected_roots.append(event)
            self._signature = signature
            self._dropped += len(self._events) == MAX_EVENTS
            self._events.append(event)
            self._events_view = tuple(self._events)
            if aliases:
                self._dropped_alias += len(self._alias_events) == MAX_ALIAS_EVENTS
                self._alias_events.append(event)
                self._alias_view = tuple(self._alias_events)

    def binding(self, roots, root):
        """Bind only the exact returned tuple/root instance, never a copied tuple."""
        if not roots:
            return None
        with self._lock:
            for returned, ticket, end in reversed(self._recent):
                if returned is roots and any(item is root for item in returned):
                    return RootReadBinding(ticket.trace_id, ticket.read_id, ticket.started_ns, end,
                        time.monotonic_ns(), self._identity(root))
        return None

    @property
    def snapshot(self):
        # Cached event tuples: no list rebuild on hot health polling.
        with self._lock:
            return RootReadDiagnostics(trace_id=self._trace_id, match_id=self._match_id,
                utc_anchor=self._utc_anchor, monotonic_anchor_ns=self._anchor,
                reads_started=self._started, reads_completed=self._completed, read_failures=self._failed,
                empty_reads=self._empty, nonempty_reads=self._nonempty, shared_dto_read_samples=self._aliases,
                max_read_duration_ns=self._max_duration, max_gap_since_previous_end_ns=self._max_gap,
                max_read_started_ns=self._max_duration_start,
                max_gap_ended_at_read_started_ns=self._max_gap_end,
                last_started_ns=self._last_start, last_finished_ns=self._last_end,
                last_error_code=self._last_error, last_error_ns=self._last_error_ns,
                events=self._events_view, alias_events=self._alias_view,
                dropped_events=self._dropped, dropped_alias_events=self._dropped_alias,
                obsolete_completions=self._obsolete,
                protected_root_events=self._protected_roots.events,
                protected_error_events=self._protected_errors.events,
                protected_root_events_observed=self._protected_roots.observed,
                protected_error_events_observed=self._protected_errors.observed,
                omitted_protected_root_events=self._protected_roots.omitted,
                omitted_protected_error_events=self._protected_errors.omitted)
