"""Reusable read-only runtime feed for the production sequence-desync guard."""

from __future__ import annotations

from dataclasses import dataclass
import time
from typing import Any, Iterable

from pokiguard_v2.il2cpp_external import ExternalReadError
from pokiguard_v2.il2cpp_layout import LayoutValidationError
from pokiguard_v2.memory_scan import regions_containing_addresses, scan_aligned_qwords
from pokiguard_v2.sequence_desync import (
    SequenceDesyncTracker,
    SequenceEventRing,
    SequenceRootTelemetry,
    classify_sequence_signal,
)
from tools.idle_state_watch import (
    CHAT_MESSAGE_DTO_TYPE_INFO_RVA,
    MatchRuntime,
    ServerMessage,
    _regions,
    read_match_runtime,
    read_server_message,
)
from tools.lifecycle_idle_watch import _message_identity, _message_sort_key


@dataclass(frozen=True)
class RuntimeSequenceObservation:
    runtime: MatchRuntime
    messages: tuple[ServerMessage, ...]
    first_detected: bool
    current_match_start: ServerMessage | None = None
    board_messages: tuple[ServerMessage, ...] = ()
    scan_performed: bool = False
    full_scan_performed: bool = False
    scan_elapsed_seconds: float = 0.0


@dataclass(frozen=True)
class RuntimeRegionPrime:
    """One read-only lobby baseline for fast current-process DTO scans."""

    class_resolved: bool
    candidate_regions: int
    message_hits: int
    learned_regions: int
    learned_bytes: int
    scanned_bytes: int
    failed_chunks: int
    elapsed_seconds: float


def _current_learned_regions(
    current_regions: Iterable[Any], learned_regions: Iterable[Any]
) -> tuple[Any, ...]:
    """Rebind learned ranges to the current VirtualQueryEx observations.

    Managed-heap regions can grow, split or disappear between the lobby and
    combat.  Never scan a stale region descriptor directly: retain only
    current bounded regions that overlap a previously evidenced range.
    """

    current = tuple(current_regions)
    learned = tuple(learned_regions)
    return tuple(
        region
        for region in current
        if any(region.base < old.end and old.base < region.end for old in learned)
    )


class RuntimeSequenceMonitor:
    """Bounded managed-heap observation; never writes or calls game methods."""

    def __init__(
        self,
        target: Any,
        *,
        max_region_mib: int = 8,
        chunk_mib: int = 2,
        full_rescan_interval: int = 8,
        minimum_scan_seconds: float = 0.35,
    ) -> None:
        self.target = target
        self.max_region_mib = max_region_mib
        self.chunk_mib = chunk_mib
        self.full_rescan_interval = max(2, full_rescan_interval)
        self.minimum_scan_seconds = minimum_scan_seconds
        self.tracker = SequenceDesyncTracker()
        self.events = SequenceEventRing(50)
        self._dto_class = target.resolver.resolve_type_info_class(
            CHAT_MESSAGE_DTO_TYPE_INFO_RVA
        )
        self._learned_regions: set[Any] = set()
        self._seen: set[tuple[Any, ...]] = set()
        self._scans = 0
        self._last_scan = 0.0
        self._current_match_start: ServerMessage | None = None

    def begin_session(self, session_key: Any, match_id: str, *, clean: bool) -> bool:
        accepted = self.tracker.begin_session(session_key, match_id, clean=clean)
        if accepted:
            self._seen.clear()
            # ChatMessageDTO allocation regions are process-lifetime scan
            # evidence, not match state.  Retain them across preopening ->
            # ACTIVE session rebinding so short-lived board messages can be
            # sampled without a blocking full heap scan.  poll() rebinds them
            # to fresh VirtualQueryEx regions before every use.
            self._last_scan = 0.0
            self._current_match_start = None
            self.events = SequenceEventRing(50)
        return accepted

    def end_session(self, session_key: Any) -> None:
        self.tracker.end_session(session_key)

    def record(self, event: dict[str, Any]) -> None:
        self.events.append(event)

    def prime_regions(self) -> RuntimeRegionPrime:
        """Learn ChatMessageDTO allocation regions while waiting in lobby.

        This does not decode messages, mark them seen, or establish a combat
        session.  It only performs the same bounded read-only class-pointer
        scan used by poll().
        """

        started = time.perf_counter()
        if self._dto_class is None:
            self._dto_class = self.target.resolver.resolve_type_info_class(
                CHAT_MESSAGE_DTO_TYPE_INFO_RVA
            )
        if self._dto_class is None:
            return RuntimeRegionPrime(
                False, 0, 0, 0, 0, 0, 0, time.perf_counter() - started
            )
        all_regions = _regions(self.target, self.max_region_mib)
        scan = scan_aligned_qwords(
            self.target.memory,
            all_regions,
            {"chat_message": int(self._dto_class)},
            chunk_size=self.chunk_mib * 1024 * 1024,
        )
        hits = scan.matches.get("chat_message", ())
        learned = regions_containing_addresses(all_regions, hits)
        self._learned_regions.update(learned)
        return RuntimeRegionPrime(
            True,
            len(all_regions),
            len(hits),
            len(self._learned_regions),
            sum(region.size for region in self._learned_regions),
            scan.bytes_read,
            scan.failed_chunks,
            time.perf_counter() - started,
        )

    def poll(
        self,
        *,
        session_key: Any,
        match_id: str,
        turn: int | None,
        srv_seq: int | None,
        timestamp: str,
        force_full_scan: bool = False,
    ) -> RuntimeSequenceObservation:
        _service, runtime = read_match_runtime(self.target)
        now = time.monotonic()
        if now - self._last_scan < self.minimum_scan_seconds:
            return RuntimeSequenceObservation(
                runtime, (), False, self._current_match_start, (), False
            )
        self._last_scan = now
        if self._dto_class is None:
            self._dto_class = self.target.resolver.resolve_type_info_class(
                CHAT_MESSAGE_DTO_TYPE_INFO_RVA
            )
        if self._dto_class is None or runtime.match_id != match_id:
            return RuntimeSequenceObservation(
                runtime, (), False, self._current_match_start, (), False
            )

        self._scans += 1
        all_regions = _regions(self.target, self.max_region_mib)
        current_learned = _current_learned_regions(
            all_regions, self._learned_regions
        )
        self._learned_regions = set(current_learned)
        full = bool(
            force_full_scan
            or not self._learned_regions
            or self._scans % self.full_rescan_interval == 0
        )
        selected: Iterable[Any] = (
            all_regions
            if full
            else current_learned
        )
        scan_started = time.perf_counter()
        scan = scan_aligned_qwords(
            self.target.memory,
            selected,
            {"chat_message": int(self._dto_class)},
            chunk_size=self.chunk_mib * 1024 * 1024,
        )
        scan_elapsed = time.perf_counter() - scan_started
        self._learned_regions.update(
            regions_containing_addresses(
                all_regions, scan.matches.get("chat_message", ())
            )
        )
        messages: list[ServerMessage] = []
        board_messages: list[ServerMessage] = []
        for address in scan.matches.get("chat_message", ()):
            try:
                message = read_server_message(
                    self.target.memory,
                    address,
                    expected_class=int(self._dto_class),
                    expected_match_id=match_id,
                )
            except (ExternalReadError, OSError, LayoutValidationError):
                continue
            identity = _message_identity(message)
            if (
                message.event_type in {"MATCH_START", "MATCH_MOVE_RES"}
                and message.payload_address is not None
            ):
                # Unlike the event stream, expose every still-live board DTO on
                # each scan. A scanner can observe the enclosing object before
                # Newtonsoft has finished populating its payload; consumers
                # must be able to retry the same validated pointer.
                board_messages.append(message)
            if message.event_type == "MATCH_START":
                # The opening board is short-lived. Retain only this exact
                # current-match DTO pointer while the surrounding combat
                # session is active; consumers always revalidate its memory.
                self._current_match_start = message
            if identity in self._seen:
                continue
            self._seen.add(identity)
            messages.append(message)

        first = False
        for message in sorted(messages, key=_message_sort_key):
            strings = dict(message.payload_strings)
            ints = dict(message.payload_ints)
            code = (
                ints.get("errorCode")
                or ints.get("code")
                or strings.get("errorCode")
                or strings.get("code")
            )
            signal = classify_sequence_signal(
                event_type=message.event_type,
                reject_code=code,
                reject_reason=message.reject_reason,
                fallback_text=(
                    strings.get("reason")
                    or strings.get("error")
                    or strings.get("message")
                ),
            )
            self.events.append(
                {
                    "timestamp": timestamp,
                    "event": "server_match_message",
                    "session": session_key,
                    "turn": turn,
                    "srvSeq": srv_seq,
                    "localMoveSequence": runtime.local_move_sequence,
                    "lastMoveSequence": runtime.last_move_sequence,
                    "highestAckedSequence": runtime.highest_acked_sequence,
                    "message": message,
                    "sequenceSignal": signal,
                }
            )
            first = self.tracker.observe(
                signal,
                timestamp=timestamp,
                session_key=session_key,
                match_id=match_id,
                turn=turn,
                srv_seq=srv_seq,
                root_telemetry=SequenceRootTelemetry.observed(
                    observed_client_sequence=runtime.local_move_sequence,
                    current_server_sequence=srv_seq,
                    highest_acked_sequence=runtime.highest_acked_sequence,
                    last_move_sequence=runtime.last_move_sequence,
                ),
            ) or first
        return RuntimeSequenceObservation(
            runtime,
            tuple(messages),
            first,
            self._current_match_start,
            tuple(board_messages),
            True,
            full,
            scan_elapsed,
        )

    @property
    def has_scanned(self) -> bool:
        """Whether at least one current-match DTO baseline scan completed."""

        return self._scans > 0


__all__ = [
    "RuntimeRegionPrime",
    "RuntimeSequenceMonitor",
    "RuntimeSequenceObservation",
]
