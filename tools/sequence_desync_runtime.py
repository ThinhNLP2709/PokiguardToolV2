"""Reusable read-only runtime feed for the production sequence-desync guard."""

from __future__ import annotations

from dataclasses import dataclass
import time
from typing import Any, Iterable

from pokiguard_v2.il2cpp_external import (
    ExternalReadError,
    WS_COMBAT_BATCH_TYPE_INFO_RVA,
)
from pokiguard_v2.il2cpp_layout import CombatBatchSnapshot, LayoutValidationError
from pokiguard_v2.memory_scan import (
    regions_containing_addresses,
    scan_aligned_qwords,
    validate_combat_batch_hits,
)
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
    scan_reason: str | None = None
    scan_region_count: int = 0
    scan_bytes_read: int = 0
    combat_batches: tuple[CombatBatchSnapshot, ...] = ()


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


def _learned_regions_with_allocator_neighbors(
    current_regions: Iterable[Any], learned_regions: Iterable[Any]
) -> tuple[Any, ...]:
    """Add one current region on either side of each evidenced DTO region.

    ``ChatMessageDTO`` allocations move into an adjacent managed-heap region
    during longer combats. Scanning only the exact process-lifetime regions
    can miss a short-lived MATCH_MOVE_RES, after which resolving the same
    board requires a much slower broad WsCombatBatch heap search. Neighbors
    are scan hints only: only regions containing a structurally valid current-
    match DTO are persisted as learned evidence.
    """

    current = tuple(sorted(current_regions, key=lambda region: region.base))
    learned = tuple(learned_regions)
    indexes: set[int] = set()
    for index, region in enumerate(current):
        if any(region.base < old.end and old.base < region.end for old in learned):
            indexes.update(
                range(max(0, index - 1), min(len(current), index + 2))
            )
    return tuple(current[index] for index in sorted(indexes))


def _transport_gap_scan_identity(
    runtime: MatchRuntime,
    *,
    published_srv_seq: int | None,
) -> tuple[str, int, int] | None:
    """Identify one local-turn ACK watermark that merits a DTO refresh.

    The direct MatchService ACK watermark can advance to the boss response
    before the learned-region monitor has captured its short-lived
    MATCH_MOVE_RES. Refresh the already evidenced allocation regions and their
    immediate neighbours once per distinct ACK watermark. A CAST response can
    advance the ACK without a board and the following boss move can advance it
    again before the next local action. Keying only by turn permanently hid
    that second, board-bearing response. The identity still bounds retries for
    an unchanged ACK, and downstream code still requires the exact current
    MatchId, decoded board and ACK sequence.
    """

    if (
        getattr(runtime, "match_id", None) is None
        or getattr(runtime, "turn", None) is None
        or getattr(runtime, "highest_acked_sequence", None) is None
        or published_srv_seq is None
        or runtime.highest_acked_sequence <= published_srv_seq
        or not getattr(runtime, "current_player", None)
        or not getattr(runtime, "local_username", None)
    ):
        return None
    return runtime.match_id, runtime.turn, runtime.highest_acked_sequence


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
        self._batch_class = target.resolver.resolve_type_info_class(
            WS_COMBAT_BATCH_TYPE_INFO_RVA
        )
        self._learned_regions: set[Any] = set()
        self._seen: set[tuple[Any, ...]] = set()
        self._scans = 0
        self._last_scan = 0.0
        self._current_match_start: ServerMessage | None = None
        self._last_gap_scan_identity: tuple[str, int, int] | None = None
        self._last_gap_scan_stage = 0
        self._periodic_full_pending = False

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
            self._last_gap_scan_identity = None
            self._last_gap_scan_stage = 0
            self._periodic_full_pending = False
            self.events = SequenceEventRing(50)
        return accepted

    def end_session(self, session_key: Any) -> None:
        self.tracker.end_session(session_key)

    def record(self, event: dict[str, Any]) -> None:
        self.events.append(event)

    def absorb_region_hints(self, regions: Iterable[Any]) -> int:
        """Merge read-only class-hit hints learned by another shared scan.

        Hints are not trusted as messages. ``poll`` rebinds them to current
        regions and performs the same exact class/match/payload validation as
        regions learned by this monitor itself.
        """

        added = 0
        for region in regions:
            # VirtualQueryEx returns fresh descriptors on every scan. Treat an
            # overlapping address range as the same hint even if protection or
            # allocation metadata changed, otherwise old descriptors are
            # repeatedly re-added after poll() rebinds the cache.
            if any(
                region.base < learned.end and learned.base < region.end
                for learned in self._learned_regions
            ):
                continue
            self._learned_regions.add(region)
            added += 1
        return added

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
        if hasattr(self, "_batch_class") and self._batch_class is None:
            self._batch_class = self.target.resolver.resolve_type_info_class(
                WS_COMBAT_BATCH_TYPE_INFO_RVA
            )
        if self._dto_class is None:
            return RuntimeRegionPrime(
                False, 0, 0, 0, 0, 0, 0, time.perf_counter() - started
            )
        all_regions = _regions(self.target, self.max_region_mib)
        needles = {"chat_message": int(self._dto_class)}
        batch_class = getattr(self, "_batch_class", None)
        if batch_class is not None:
            # Pay the broad WsCombatBatch class scan once at the safe lobby
            # boundary too. Long-run evidence showed that batches commonly
            # live in 8-16 MiB regions which contain no ChatMessageDTO. If only
            # DTO regions are retained, every later ACK gap broad-scans
            # hundreds of MiB during the player's 14-second turn.
            needles["batch"] = int(batch_class)
        scan = scan_aligned_qwords(
            self.target.memory,
            all_regions,
            needles,
            chunk_size=self.chunk_mib * 1024 * 1024,
        )
        hits = scan.matches.get("chat_message", ())
        learned = regions_containing_addresses(
            all_regions,
            tuple(hits) + tuple(scan.matches.get("batch", ())),
        )
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

    def ensure_regions_primed(self) -> RuntimeRegionPrime:
        """Reuse live DTO-region evidence or learn it before entry input.

        A cold full ChatMessageDTO scan is deliberately paid while the game is
        still in the boss lobby. Subsequent entries only rebind the learned
        ranges to current VirtualQueryEx observations. If every learned range
        disappeared (for example after a managed-heap reset), this performs a
        fresh lobby scan instead of discovering that only after ``Bat dau``.
        """

        started = time.perf_counter()
        current = _regions(self.target, self.max_region_mib)
        live_learned = _current_learned_regions(current, self._learned_regions)
        self._learned_regions = set(live_learned)
        if live_learned:
            return RuntimeRegionPrime(
                self._dto_class is not None,
                len(current),
                0,
                len(live_learned),
                sum(region.size for region in live_learned),
                0,
                0,
                time.perf_counter() - started,
            )
        return self.prime_regions()

    def poll(
        self,
        *,
        session_key: Any,
        match_id: str,
        turn: int | None,
        srv_seq: int | None,
        timestamp: str,
        force_full_scan: bool = False,
        enable_gap_full_scan: bool = True,
        allow_gap_full_escalation: bool = False,
        resolved_board_sequences: Iterable[int] = (),
        offered_board_message_addresses: Iterable[int] = (),
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
        if hasattr(self, "_batch_class") and self._batch_class is None:
            self._batch_class = self.target.resolver.resolve_type_info_class(
                WS_COMBAT_BATCH_TYPE_INFO_RVA
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
        gap_scan_identity = _transport_gap_scan_identity(
            runtime,
            published_srv_seq=srv_seq,
        )
        gap_refresh = bool(
            enable_gap_full_scan
            and gap_scan_identity is not None
            and gap_scan_identity
            != getattr(self, "_last_gap_scan_identity", None)
        )
        resolved_sequences = frozenset(int(value) for value in resolved_board_sequences)
        gap_full_escalation = bool(
            enable_gap_full_scan
            and allow_gap_full_escalation
            and gap_scan_identity is not None
            and gap_scan_identity
            == getattr(self, "_last_gap_scan_identity", None)
            and getattr(self, "_last_gap_scan_stage", 0) == 1
            and runtime.highest_acked_sequence not in resolved_sequences
            and runtime.remaining is not None
            and runtime.remaining >= 10
        )
        runtime_local_turn = bool(
            getattr(runtime, "current_player", None)
            and getattr(runtime, "local_username", None)
            and runtime.current_player.casefold()
            == runtime.local_username.casefold()
        )
        periodic_due = bool(
            self._scans % self.full_rescan_interval == 0
            or getattr(self, "_periodic_full_pending", False)
        )
        periodic_full = bool(
            periodic_due
            and (not runtime_local_turn or force_full_scan)
        )
        self._periodic_full_pending = bool(periodic_due and not periodic_full)
        full = bool(
            force_full_scan
            or not self._learned_regions
            or periodic_full
            or gap_full_escalation
        )
        if full:
            self._periodic_full_pending = False
        scan_reason = (
            "EXPLICIT_FORCE"
            if force_full_scan
            else "LOCAL_TURN_ACK_GAP_FULL_ESCALATION"
            if gap_full_escalation
            else "LOCAL_TURN_ACK_GAP_BOUNDED"
            if gap_refresh
            else "NO_LIVE_LEARNED_REGIONS"
            if not self._learned_regions
            else "PERIODIC_REFRESH"
            if periodic_full
            else "LEARNED_REGIONS_WITH_NEIGHBORS"
        )
        if gap_refresh:
            # Reserve the identity before the read so a transient unreadable
            # chunk cannot trigger repeated scans inside one local turn.
            self._last_gap_scan_identity = gap_scan_identity
            self._last_gap_scan_stage = 1
        elif gap_full_escalation:
            # This is the only broad local-turn fallback. It is authorized by
            # exact provider evidence that the current ACK still has no board
            # DTO after the fast learned-region pass, and cannot repeat for an
            # unchanged ACK watermark. A later ACK in the same turn gets a
            # fresh bounded/full opportunity because it may carry the board.
            self._last_gap_scan_stage = 2
        if full:
            selected: tuple[Any, ...] = all_regions
        elif gap_refresh:
            # Neighbours are useful only when a new ACK proves that the
            # short-lived response may have moved. Ordinary polling stays on
            # exact learned regions so it cannot tax every gameplay loop.
            selected = (
                _learned_regions_with_allocator_neighbors(
                    all_regions, current_learned
                )
                or current_learned
            )
        else:
            selected = current_learned
        scan_started = time.perf_counter()
        needles = {"chat_message": int(self._dto_class)}
        batch_class = getattr(self, "_batch_class", None)
        if batch_class is not None:
            # Search WsCombatBatch in the same bytes already required for DTO
            # sequence monitoring.  This adds no second memory traversal and
            # retains exact structural + MatchService ACK validation downstream.
            needles["batch"] = int(batch_class)
        scan = scan_aligned_qwords(
            self.target.memory,
            selected,
            needles,
            chunk_size=self.chunk_mib * 1024 * 1024,
        )
        scan_elapsed = time.perf_counter() - scan_started
        scan_region_count = len(selected)
        scan_bytes_read = scan.bytes_read
        self._learned_regions.update(
            regions_containing_addresses(
                all_regions, scan.matches.get("chat_message", ())
            )
        )
        decoded: dict[int, ServerMessage] = {}
        batch_hits = set(scan.matches.get("batch", ()))
        for address in scan.matches.get("chat_message", ()):
            try:
                decoded[address] = read_server_message(
                    self.target.memory,
                    address,
                    expected_class=int(self._dto_class),
                    expected_match_id=match_id,
                )
            except (ExternalReadError, OSError, LayoutValidationError):
                continue

        offered_addresses = frozenset(
            int(value) for value in offered_board_message_addresses
        )
        bounded_found_unoffered_board = any(
            message.event_type == "MATCH_MOVE_RES"
            and message.payload_address is not None
            and message.server_sequence == runtime.highest_acked_sequence
            and message.address not in offered_addresses
            for message in decoded.values()
        )
        immediate_gap_escalation = bool(
            gap_refresh
            and allow_gap_full_escalation
            and not full
            and runtime.highest_acked_sequence not in resolved_sequences
            and runtime.remaining is not None
            and runtime.remaining >= 10
            and not bounded_found_unoffered_board
        )
        if immediate_gap_escalation:
            # The short-lived response was absent from the fast envelope.
            # Escalate now, before a provider fallback can consume several
            # seconds and let the DTO be reclaimed. This is still the single
            # stage-2 scan reserved for this (match, turn, ACK) identity.
            self._last_gap_scan_stage = 2
            full_started = time.perf_counter()
            full_scan = scan_aligned_qwords(
                self.target.memory,
                all_regions,
                needles,
                chunk_size=self.chunk_mib * 1024 * 1024,
            )
            scan_elapsed += time.perf_counter() - full_started
            scan_region_count += len(all_regions)
            scan_bytes_read += full_scan.bytes_read
            batch_hits.update(full_scan.matches.get("batch", ()))
            self._learned_regions.update(
                regions_containing_addresses(
                    all_regions,
                    full_scan.matches.get("chat_message", ()),
                )
            )
            for address in full_scan.matches.get("chat_message", ()):
                if address in decoded:
                    continue
                try:
                    decoded[address] = read_server_message(
                        self.target.memory,
                        address,
                        expected_class=int(self._dto_class),
                        expected_match_id=match_id,
                    )
                except (ExternalReadError, OSError, LayoutValidationError):
                    continue
            full = True
            self._periodic_full_pending = False
            scan_reason = "LOCAL_TURN_ACK_GAP_FULL_ESCALATION"

        # WsCombatBatch regions are process-lifetime scan evidence just like
        # ChatMessageDTO regions. Retaining both makes the next ACK refresh a
        # learned-region scan instead of another 400-600 MiB full heap scan.
        self._learned_regions.update(
            regions_containing_addresses(all_regions, batch_hits)
        )

        combat_batches: tuple[CombatBatchSnapshot, ...] = ()
        if batch_class is not None and batch_hits:
            try:
                combat_batches = validate_combat_batch_hits(
                    self.target.memory,
                    batch_hits,
                    batch_class=int(batch_class),
                )
            except (ExternalReadError, OSError):
                # Batch capture is an optimization for the provider's exact ACK
                # gate. DTO/sequence monitoring must remain available if one
                # transient batch becomes unreadable during validation.
                combat_batches = ()

        messages: list[ServerMessage] = []
        board_messages: list[ServerMessage] = []
        for address, message in sorted(decoded.items()):
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
            scan_reason,
            scan_region_count,
            scan_bytes_read,
            combat_batches,
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
