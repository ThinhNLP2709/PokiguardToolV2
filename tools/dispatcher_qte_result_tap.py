"""High-cadence read-only capture of dispatcher-owned combat envelopes."""

from __future__ import annotations

from dataclasses import dataclass, replace
import hashlib
import json
import struct
import threading
import time
from typing import Any

from pokiguard_v2.dispatcher_chat_roots import DispatcherChatRootReader
from pokiguard_v2.il2cpp_external import (
    BOARD_WS_APPLIER_TYPE_INFO_RVA,
    CHAT_MESSAGE_DTO_TYPE_INFO_RVA,
    ExternalReadError,
    MATCH_SERVICE_CURRENT_MATCH_ID_OFFSET,
    MATCH_SERVICE_PENDING_COMBAT_OFFSET,
    MATCH_SERVICE_SINGLETON,
    WS_COMBAT_BATCH_TYPE_INFO_RVA,
    is_canonical_user_pointer,
)
from pokiguard_v2.il2cpp_layout import (
    CombatBatchSnapshot,
    LayoutValidationError,
    read_combat_batch,
    read_il2cpp_string,
)
from pokiguard_v2.live_state import board_state_hash, dto_rejection_reasons
from pokiguard_v2.memory_board_provider import (
    read_board_ws_candidate,
    read_pending_queue,
)
from pokiguard_v2.opening_snapshot import (
    JARRAY_TYPE_INFO_RVA,
    JOBJECT_TYPE_INFO_RVA,
    JPROPERTY_TYPE_INFO_RVA,
    JVALUE_TYPE_INFO_RVA,
    NewtonsoftClasses,
    OpeningBoardSnapshot,
    SUPPORTED_TRANSPORT_BOARD_EVENTS,
    parse_transport_board_envelope_json,
    read_match_payload_board_snapshot,
    read_preparsed_board_snapshot,
)
from pokiguard_v2.pet_qte_observer import QTE_RESULT_TYPES
from tools.idle_state_watch import (
    SERVER_EVENT_TYPES,
    ServerMessage,
    read_server_message,
)


_RAW_PAYLOAD_INT_KEYS = (
    "idleCount",
    "threshold",
    "turnNumber",
    "turnDurationSec",
    "turnTimeRemainingSec",
    "srvSeq",
    "cardId",
    "skillCardId",
    "mana",
    "manaCur",
    "manaMax",
    "code",
    "errorCode",
)
_RAW_PAYLOAD_BOOL_KEYS = ("rejected", "success", "accepted")
_RAW_PAYLOAD_STRING_KEYS = (
    "username",
    "actorUsername",
    "ownerUsername",
    "currentTurnPlayer",
    "action",
    "kind",
    "reason",
    "message",
    "error",
    "winner",
    "timingResult",
)


def _optional_raw_int(value: Any) -> int | None:
    return value if isinstance(value, int) and not isinstance(value, bool) else None


def _optional_raw_string(value: Any, *, maximum: int = 256) -> str | None:
    if (
        isinstance(value, str)
        and 0 < len(value) <= maximum
        and all(ord(character) >= 0x20 for character in value)
    ):
        return value
    return None


def parse_server_envelope_json(
    raw_json: str,
    *,
    expected_match_id: str,
    message_address: int,
) -> ServerMessage:
    """Decode an immutable queued combat envelope without trusting its DTO.

    Unity's callback closure owns the original JSON string before it owns the
    mutable/deserialized ``ChatMessageDTO``.  This decoder intentionally exposes
    only the small field set already consumed by runtime correlation.  Exact
    event and MatchId remain mandatory, malformed typed values stay absent, and
    the response still needs temporal/current-generation correlation later.
    """

    if not raw_json or len(raw_json) > 262_144:
        raise LayoutValidationError("server envelope JSON length is invalid")
    try:
        envelope = json.loads(raw_json)
    except (TypeError, json.JSONDecodeError) as exc:
        raise LayoutValidationError("server envelope JSON is malformed") from exc
    if not isinstance(envelope, dict):
        raise LayoutValidationError("server envelope JSON is not an object")
    event_type = envelope.get("type")
    if event_type not in SERVER_EVENT_TYPES:
        raise LayoutValidationError("raw callback is not a supported combat event")
    if envelope.get("matchId") != expected_match_id or not expected_match_id:
        raise LayoutValidationError("server envelope JSON MatchId is stale")
    payload_value = envelope.get("matchPayload")
    if payload_value is None:
        payload: dict[str, Any] = {}
    elif isinstance(payload_value, dict):
        payload = payload_value
    else:
        raise LayoutValidationError("server envelope JSON matchPayload is invalid")

    payload_ints = tuple(
        (key, value)
        for key in _RAW_PAYLOAD_INT_KEYS
        if (value := _optional_raw_int(payload.get(key))) is not None
    )
    payload_bools = tuple(
        (key, value)
        for key in _RAW_PAYLOAD_BOOL_KEYS
        if isinstance((value := payload.get(key)), bool)
    )
    payload_strings = tuple(
        (key, value)
        for key in _RAW_PAYLOAD_STRING_KEYS
        if (value := _optional_raw_string(payload.get(key))) is not None
    )
    payload_sequence = dict(payload_ints).get("srvSeq")
    return ServerMessage(
        address=message_address,
        event_type=str(event_type),
        match_id=expected_match_id,
        timestamp=_optional_raw_string(envelope.get("timestamp"), maximum=128),
        username=_optional_raw_string(envelope.get("username")),
        # This object is a parsed immutable-string witness, not a Newtonsoft
        # payload address. The independently parsed board snapshot carries its
        # own raw-string provenance when present.
        payload_address=None,
        # Board/action correlation uses matchPayload.srvSeq. In 1.7.4 the
        # outer seqNum can be absent or refer to a different envelope counter.
        server_sequence=(
            payload_sequence
            if payload_sequence is not None
            else _optional_raw_int(envelope.get("seqNum"))
        ),
        from_col=_optional_raw_int(envelope.get("fromCol")),
        from_row=_optional_raw_int(envelope.get("fromRow")),
        to_col=_optional_raw_int(envelope.get("toCol")),
        to_row=_optional_raw_int(envelope.get("toRow")),
        card_id=_optional_raw_int(envelope.get("cardId")),
        skill_card_id=_optional_raw_int(envelope.get("skillCardId")),
        reject_reason=_optional_raw_string(envelope.get("rejectReason")),
        idle_count=dict(payload_ints).get("idleCount"),
        threshold=dict(payload_ints).get("threshold"),
        payload_ints=payload_ints,
        payload_bools=payload_bools,
        payload_strings=payload_strings,
        qte_challenge_id=_optional_raw_int(envelope.get("qteChallengeId")),
    )


def parse_skill_result_envelope_json(
    raw_json: str,
    *,
    expected_match_id: str,
    message_address: int,
) -> ServerMessage:
    """Compatibility wrapper for the existing QTE result observer."""

    message = parse_server_envelope_json(
        raw_json,
        expected_match_id=expected_match_id,
        message_address=message_address,
    )
    if message.event_type != "MATCH_SKILL_USE_RES":
        raise LayoutValidationError("raw callback is not a skill-use response")
    return message


@dataclass(frozen=True)
class DispatcherTapDiagnostics:
    armed_match_id: str | None
    poll_count: int
    stable_root_reads: int
    torn_or_unavailable_reads: int
    candidate_messages: int
    decoded_skill_results: int
    decoded_raw_results: int
    decoded_raw_boards: int
    decoded_preparsed_boards: int
    decoded_dto_boards: int
    retained_board_snapshots: int
    retained_messages: int
    decoded_pending_batches: int
    decoded_owner_queue_batches: int
    retained_runtime_batches: int
    healthy: bool
    raw_board_rejections: int
    board_rejection_reasons: tuple[str, ...]
    last_error: str | None


class DispatcherTransportTap:
    """Retain exact combat envelopes before Unity drains their callback.

    The tap is dormant until ``arm``.  It then performs only a handful of
    direct ``ReadProcessMemory`` calls every millisecond.  It never scans
    the heap and never writes or invokes code in the target process.
    """

    def __init__(self, target: Any, *, interval_seconds: float = 0.001) -> None:
        if not 0.001 <= interval_seconds <= 0.02:
            raise ValueError("dispatcher tap interval is outside the safe range")
        self._target = target
        self._reader = DispatcherChatRootReader(target.memory, target.resolver)
        self._interval = interval_seconds
        self._lock = threading.Lock()
        self._wake = threading.Event()
        self._stop = threading.Event()
        self._thread: threading.Thread | None = None
        self._match_id: str | None = None
        self._discover_excluding_match_id: str | None = None
        self._discover_new_match = False
        self._seen: set[tuple[str, int, int | None, bytes]] = set()
        self._results: dict[tuple[str, int], Any] = {}
        self._messages: dict[tuple[str, int, int | None, bytes], ServerMessage] = {}
        self._raw_boards: dict[tuple[str, int], OpeningBoardSnapshot] = {}
        self._transport_boards: dict[
            tuple[str, int, int], tuple[str, OpeningBoardSnapshot]
        ] = {}
        self._runtime_batches: dict[
            tuple[str, str, int, int, str], tuple[str, CombatBatchSnapshot]
        ] = {}
        self._poll_count = 0
        self._stable_root_reads = 0
        self._torn_reads = 0
        self._candidate_messages = 0
        self._decoded_raw_results = 0
        self._decoded_raw_boards = 0
        self._decoded_preparsed_boards = 0
        self._decoded_dto_boards = 0
        self._decoded_pending_batches = 0
        self._decoded_owner_queue_batches = 0
        self._raw_board_rejections = 0
        self._board_rejection_reasons: list[str] = []
        self._last_error: str | None = None
        self._last_stable_at: float | None = None
        self._dto_class: int | None = None
        self._newtonsoft_classes: NewtonsoftClasses | None = None
        self._batch_class: int | None = None
        self._board_ws_class: int | None = None
        self._match_service_address: int | None = None
        self._runtime_board_instance: int | None = None
        self._board_ws_owner_addresses: tuple[int, ...] = ()

    def __enter__(self) -> "DispatcherTransportTap":
        return self

    def __exit__(self, *_exc: Any) -> None:
        self.stop()

    def arm(self, match_id: str) -> None:
        if not match_id:
            raise ValueError("dispatcher tap requires a current MatchId")
        with self._lock:
            changed = self._match_id != match_id
            if changed:
                self._seen.clear()
                self._results.clear()
                self._messages.clear()
                self._raw_boards.clear()
                self._transport_boards.clear()
                self._runtime_batches.clear()
                self._board_rejection_reasons.clear()
                self._last_stable_at = None
                self._match_service_address = None
            self._match_id = match_id
            self._discover_excluding_match_id = None
            self._discover_new_match = False
        # Establish one synchronous health sample before BASIC decides whether
        # it can skip the legacy heap scan. The operation is a bounded set of
        # direct RPM reads and catches an envelope that is already queued.
        if changed:
            self._capture_once(match_id)
        with self._lock:
            if self._thread is None:
                self._thread = threading.Thread(
                    target=self._run,
                    name="phase2-dispatcher-transport-tap",
                    daemon=True,
                )
                self._thread.start()
        self._wake.set()

    def arm_for_new_match(self, excluded_match_id: str | None) -> None:
        """Retain the next strict raw MATCH_START before its MatchId is known.

        Entry starts this bounded sampler immediately before its one Start
        click. The accepted candidate must be a complete, schema-valid raw
        MATCH_START board whose nonempty MatchId differs from the lobby
        baseline. Normal provider session binding still proves that the
        retained envelope belongs to the Board that was actually entered.
        """

        excluded = excluded_match_id or None
        with self._lock:
            self._seen.clear()
            self._results.clear()
            self._messages.clear()
            self._raw_boards.clear()
            self._transport_boards.clear()
            self._runtime_batches.clear()
            self._board_rejection_reasons.clear()
            self._last_stable_at = None
            self._match_service_address = None
            self._match_id = None
            self._discover_excluding_match_id = excluded
            self._discover_new_match = True
        self._capture_new_match_once(excluded)
        with self._lock:
            if self._thread is None:
                self._thread = threading.Thread(
                    target=self._run,
                    name="phase2-dispatcher-transport-tap",
                    daemon=True,
                )
                self._thread.start()
        self._wake.set()

    def disarm(self) -> None:
        with self._lock:
            self._match_id = None
            self._discover_excluding_match_id = None
            self._discover_new_match = False
        self._wake.clear()

    def stop(self) -> None:
        self._stop.set()
        self._wake.set()
        thread = self._thread
        if thread is not None and thread is not threading.current_thread():
            thread.join(timeout=1.0)

    def results(self, match_id: str) -> tuple[Any, ...]:
        with self._lock:
            return tuple(
                value
                for (owned_match, _), value in self._results.items()
                if owned_match == match_id
            )

    def messages(self, match_id: str) -> tuple[ServerMessage, ...]:
        """Return exact current-match messages retained from queued callbacks."""

        with self._lock:
            return tuple(
                value
                for (owned_match, _, _, _), value in self._messages.items()
                if owned_match == match_id
            )

    def board_snapshot(
        self, match_id: str, message_address: int
    ) -> OpeningBoardSnapshot | None:
        with self._lock:
            return self._raw_boards.get((match_id, message_address))

    def transport_board_snapshots(
        self, match_id: str
    ) -> tuple[tuple[str, OpeningBoardSnapshot], ...]:
        """Return strict current-match boards retained from queued callbacks."""

        with self._lock:
            return tuple(
                value
                for (owned_match, _, _), value in self._transport_boards.items()
                if owned_match == match_id
            )

    def configure_runtime_owners(
        self,
        *,
        board_instance: int | None,
        board_ws_addresses: tuple[int, ...],
    ) -> None:
        """Supply provider-validated BoardWsApplier roots to the fast sampler.

        The tap never discovers these owners itself. It only revalidates their
        exact class, Board pointer and MatchId before retaining a queued batch.
        MatchService.PendingCombat is resolved independently from its verified
        singleton and therefore remains available before owner discovery.
        """

        valid_board = (
            int(board_instance)
            if isinstance(board_instance, int)
            and is_canonical_user_pointer(board_instance)
            else None
        )
        valid_owners = tuple(
            sorted(
                {
                    int(address)
                    for address in board_ws_addresses
                    if isinstance(address, int)
                    and is_canonical_user_pointer(address)
                }
            )
        )
        with self._lock:
            self._runtime_board_instance = valid_board
            self._board_ws_owner_addresses = valid_owners if valid_board else ()

    def runtime_batches(
        self, match_id: str
    ) -> tuple[tuple[str, CombatBatchSnapshot], ...]:
        """Return exact-match typed batches retained from transient game roots."""

        with self._lock:
            return tuple(
                value
                for (owned_match, _, _, _, _), value in self._runtime_batches.items()
                if owned_match == match_id
            )

    @property
    def diagnostics(self) -> DispatcherTapDiagnostics:
        with self._lock:
            thread_alive = self._thread is not None and self._thread.is_alive()
            healthy = bool(
                (self._match_id or self._discover_new_match)
                and thread_alive
                and self._last_stable_at is not None
                and time.monotonic() - self._last_stable_at <= 0.25
            )
            return DispatcherTapDiagnostics(
                armed_match_id=self._match_id,
                poll_count=self._poll_count,
                stable_root_reads=self._stable_root_reads,
                torn_or_unavailable_reads=self._torn_reads,
                candidate_messages=self._candidate_messages,
                decoded_skill_results=len(self._results),
                decoded_raw_results=self._decoded_raw_results,
                decoded_raw_boards=self._decoded_raw_boards,
                decoded_preparsed_boards=self._decoded_preparsed_boards,
                decoded_dto_boards=self._decoded_dto_boards,
                retained_board_snapshots=len(self._transport_boards),
                retained_messages=len(self._messages),
                decoded_pending_batches=self._decoded_pending_batches,
                decoded_owner_queue_batches=self._decoded_owner_queue_batches,
                retained_runtime_batches=len(self._runtime_batches),
                healthy=healthy,
                raw_board_rejections=self._raw_board_rejections,
                board_rejection_reasons=tuple(self._board_rejection_reasons),
                last_error=self._last_error,
            )

    @property
    def healthy(self) -> bool:
        return self.diagnostics.healthy

    def _run(self) -> None:
        while not self._stop.is_set():
            if not self._wake.wait(0.1):
                continue
            if self._stop.is_set():
                return
            with self._lock:
                match_id = self._match_id
                discover_new_match = self._discover_new_match
                excluded_match_id = self._discover_excluding_match_id
            if discover_new_match:
                self._capture_new_match_once(excluded_match_id)
            elif match_id is None:
                self._wake.clear()
                continue
            else:
                self._capture_once(match_id)
            # ``threading.Event.wait(0.002)`` is quantized close to one Windows
            # scheduler tick on this host (~15 ms).  Python's high-resolution
            # sleep uses the waitable-timer path and preserves the intended
            # 2–3 ms cadence.  The tap exists for at most the bounded result
            # wait, so the equally short stop latency is acceptable.
            time.sleep(self._interval)

    def _capture_new_match_once(self, excluded_match_id: str | None) -> None:
        """Discover one exact raw MATCH_START while its MatchId is unknown."""

        try:
            roots = self._reader.read()
            with self._lock:
                self._poll_count += 1
                self._stable_root_reads += 1
                self._candidate_messages += len(roots)
                self._last_error = None
                self._last_stable_at = time.monotonic()
            for root in roots:
                if root.json_address is None:
                    continue
                try:
                    raw_json = read_il2cpp_string(
                        self._target.memory,
                        root.json_address,
                        max_length=262_144,
                    )
                    envelope = json.loads(raw_json)
                except (
                    ExternalReadError,
                    OSError,
                    TypeError,
                    json.JSONDecodeError,
                    LayoutValidationError,
                    ValueError,
                ):
                    continue
                if not isinstance(envelope, dict) or envelope.get("type") != "MATCH_START":
                    continue
                discovered_match_id = envelope.get("matchId")
                if (
                    not isinstance(discovered_match_id, str)
                    or not discovered_match_id
                    or discovered_match_id == excluded_match_id
                ):
                    continue
                fingerprint = hashlib.sha256(raw_json.encode("utf-8")).digest()
                identity = (
                    discovered_match_id,
                    root.message_address,
                    root.json_address,
                    fingerprint,
                )
                with self._lock:
                    if identity in self._seen:
                        continue
                try:
                    message = parse_server_envelope_json(
                        raw_json,
                        expected_match_id=discovered_match_id,
                        message_address=root.message_address,
                    )
                except (LayoutValidationError, ValueError):
                    continue
                snapshot = None
                rejection: Exception | None = None
                try:
                    snapshot = parse_transport_board_envelope_json(
                        raw_json,
                        expected_match_id=discovered_match_id,
                        expected_event_type="MATCH_START",
                        message_address=root.message_address,
                        json_address=root.json_address,
                    )
                    with self._lock:
                        self._decoded_raw_boards += 1
                except (LayoutValidationError, ValueError) as exc:
                    rejection = exc
                if snapshot is None and message.server_sequence is not None:
                    try:
                        dto_class = self._dto_class
                        if dto_class is None:
                            dto_class = self._target.resolver.resolve_type_info_class(
                                CHAT_MESSAGE_DTO_TYPE_INFO_RVA
                            )
                        if dto_class is None:
                            raise LayoutValidationError(
                                "ChatMessageDTO type-info is unavailable"
                            )
                        self._dto_class = int(dto_class)
                        snapshot = read_preparsed_board_snapshot(
                            self._target.memory,
                            match_id=discovered_match_id,
                            message_address=root.message_address,
                            expected_message_class=int(dto_class),
                            event_type="MATCH_START",
                            sequence=int(message.server_sequence),
                        )
                        with self._lock:
                            self._decoded_preparsed_boards += 1
                    except (
                        ExternalReadError,
                        OSError,
                        LayoutValidationError,
                        RuntimeError,
                        ValueError,
                    ) as exc:
                        rejection = exc
                if snapshot is None:
                    with self._lock:
                        self._raw_board_rejections += 1
                        if len(self._board_rejection_reasons) < 16:
                            self._board_rejection_reasons.append(
                                "event=MATCH_START; raw/preBoard="
                                f"{type(rejection).__name__}: {rejection}"
                            )
                    continue
                with self._lock:
                    self._seen.add(identity)
                    self._messages[identity] = message
                    self._transport_boards[
                        (
                            discovered_match_id,
                            root.message_address,
                            root.json_address,
                        )
                    ] = ("MATCH_START", snapshot)
                    self._match_id = discovered_match_id
                    self._discover_excluding_match_id = None
                    self._discover_new_match = False
                return
        except (ExternalReadError, OSError, LayoutValidationError) as exc:
            with self._lock:
                self._poll_count += 1
                self._torn_reads += 1
                self._last_error = f"{type(exc).__name__}: {exc}"

    def _capture_once(self, match_id: str) -> None:
        # Typed game-owned roots can outlive or precede the dispatcher callback.
        # Sample them independently so a torn/unavailable chat root cannot hide
        # an otherwise valid current-match board.
        self._capture_runtime_batches(match_id)
        try:
            dto_class = self._dto_class
            if dto_class is None:
                dto_class = self._target.resolver.resolve_type_info_class(
                    CHAT_MESSAGE_DTO_TYPE_INFO_RVA
                )
            if dto_class is None:
                raise LayoutValidationError("ChatMessageDTO type-info is unavailable")
            self._dto_class = int(dto_class)
            roots = self._reader.read()
            with self._lock:
                self._poll_count += 1
                self._stable_root_reads += 1
                self._candidate_messages += len(roots)
                self._last_error = None
                self._last_stable_at = time.monotonic()
            for root in roots:
                result_identity = (match_id, root.message_address)
                raw_json = None
                raw_message = None
                raw_event_type = None
                snapshot = None
                raw_board_rejection: str | None = None
                if root.json_address is not None:
                    try:
                        raw_json = read_il2cpp_string(
                            self._target.memory,
                            root.json_address,
                            max_length=262_144,
                        )
                    except (
                        ExternalReadError,
                        OSError,
                        LayoutValidationError,
                        ValueError,
                    ):
                        raw_json = None
                raw_fingerprint = (
                    hashlib.sha256(raw_json.encode("utf-8")).digest()
                    if raw_json is not None
                    else b""
                )
                seen_identity = (
                    match_id,
                    root.message_address,
                    root.json_address,
                    raw_fingerprint,
                )
                with self._lock:
                    if seen_identity in self._seen:
                        continue
                if raw_json is not None and root.json_address is not None:
                    try:
                        raw_message = parse_server_envelope_json(
                            raw_json,
                            expected_match_id=match_id,
                            message_address=root.message_address,
                        )
                    except (LayoutValidationError, ValueError):
                        # Most queued callbacks are unrelated websocket events.
                        # A failed raw decode therefore is not itself an error.
                        raw_message = None
                    try:
                        raw_envelope = json.loads(raw_json)
                        if (
                            isinstance(raw_envelope, dict)
                            and raw_envelope.get("matchId") == match_id
                            and raw_envelope.get("type")
                            in SUPPORTED_TRANSPORT_BOARD_EVENTS
                        ):
                            raw_event_type = str(raw_envelope["type"])
                            snapshot = parse_transport_board_envelope_json(
                                raw_json,
                                expected_match_id=match_id,
                                expected_event_type=raw_event_type,
                                message_address=root.message_address,
                                json_address=root.json_address,
                            )
                            with self._lock:
                                self._decoded_raw_boards += 1
                    except (
                        TypeError,
                        json.JSONDecodeError,
                        LayoutValidationError,
                        ValueError,
                    ) as exc:
                        if raw_event_type is not None:
                            with self._lock:
                                self._raw_board_rejections += 1
                            raw_board_rejection = f"{type(exc).__name__}: {exc}"
                try:
                    dto_message = read_server_message(
                        self._target.memory,
                        root.message_address,
                        expected_class=int(dto_class),
                        expected_match_id=match_id,
                    )
                except (ExternalReadError, OSError, LayoutValidationError):
                    # Other websocket events share the same closure type.  Do
                    # not permanently suppress an address on a failed/torn
                    # decode because IL2CPP can later reuse that allocation.
                    dto_message = None
                if (
                    raw_message is not None
                    and dto_message is not None
                    and raw_message.payload_address is None
                    and getattr(dto_message, "payload_address", None) is not None
                    and raw_message.event_type == dto_message.event_type
                    and raw_message.match_id == dto_message.match_id
                ):
                    # Keep immutable JSON correlation fields while preserving
                    # the same callback's still-live Newtonsoft payload. The
                    # latter is the exact Phase-2 decoder fallback when the
                    # server JSON board shape changes but the game itself has
                    # already deserialized a valid 8x8 payload.
                    raw_message = replace(
                        raw_message,
                        payload_address=dto_message.payload_address,
                    )
                if (
                    snapshot is None
                    and raw_message is not None
                    and raw_message.event_type in SUPPORTED_TRANSPORT_BOARD_EVENTS
                    and raw_message.server_sequence is not None
                ):
                    raw_sequence = int(raw_message.server_sequence)
                    try:
                        snapshot = read_preparsed_board_snapshot(
                            self._target.memory,
                            match_id=match_id,
                            message_address=root.message_address,
                            expected_message_class=int(dto_class),
                            event_type=raw_message.event_type,
                            sequence=raw_sequence,
                        )
                        raw_event_type = raw_message.event_type
                        with self._lock:
                            self._decoded_preparsed_boards += 1
                            if raw_board_rejection is not None:
                                rejection = (
                                    f"event={raw_message.event_type}; "
                                    f"seq={raw_sequence}; "
                                    f"raw={raw_board_rejection}; "
                                    "preBoard=recovered"
                                )
                                if len(self._board_rejection_reasons) < 16:
                                    self._board_rejection_reasons.append(rejection)
                    except (
                        ExternalReadError,
                        OSError,
                        LayoutValidationError,
                        RuntimeError,
                        ValueError,
                    ):
                        # Some supported responses legitimately carry no
                        # board.  Keep the legacy matchPayload fallback for
                        # older/current envelopes that retain one there.
                        snapshot = None
                if (
                    snapshot is None
                    and dto_message is not None
                    and dto_message.event_type in SUPPORTED_TRANSPORT_BOARD_EVENTS
                    and getattr(dto_message, "payload_address", None) is not None
                ):
                    try:
                        classes = self._newtonsoft_classes
                        if classes is None:
                            resolved = tuple(
                                self._target.resolver.resolve_type_info_class(rva)
                                for rva in (
                                    JARRAY_TYPE_INFO_RVA,
                                    JOBJECT_TYPE_INFO_RVA,
                                    JPROPERTY_TYPE_INFO_RVA,
                                    JVALUE_TYPE_INFO_RVA,
                                )
                            )
                            if any(value is None for value in resolved):
                                raise LayoutValidationError(
                                    "Newtonsoft type-info is unavailable"
                                )
                            classes = NewtonsoftClasses(
                                *(int(value) for value in resolved)
                            )
                            self._newtonsoft_classes = classes
                        snapshot = read_match_payload_board_snapshot(
                            self._target.memory,
                            match_id=match_id,
                            message_address=root.message_address,
                            payload_address=int(dto_message.payload_address),
                            classes=classes,
                            event_type=dto_message.event_type,
                        )
                        raw_event_type = dto_message.event_type
                        with self._lock:
                            self._decoded_dto_boards += 1
                            if raw_board_rejection is not None:
                                rejection = (
                                    f"event={dto_message.event_type}; "
                                    f"seq={getattr(dto_message, 'server_sequence', None)}; "
                                    f"raw={raw_board_rejection}; dto=recovered"
                                )
                                if len(self._board_rejection_reasons) < 16:
                                    self._board_rejection_reasons.append(rejection)
                    except (
                        ExternalReadError,
                        OSError,
                        LayoutValidationError,
                        RuntimeError,
                        ValueError,
                    ) as exc:
                        dto_rejection = f"{type(exc).__name__}: {exc}"
                        rejection = (
                            f"event={dto_message.event_type}; "
                            f"seq={getattr(dto_message, 'server_sequence', None)}; "
                            f"raw={raw_board_rejection or 'not-applicable'}; "
                            f"dto={dto_rejection}"
                        )
                        with self._lock:
                            if len(self._board_rejection_reasons) < 16:
                                self._board_rejection_reasons.append(rejection)
                elif raw_board_rejection is not None:
                    sequence = (
                        raw_message.server_sequence
                        if raw_message is not None
                        else None
                    )
                    rejection = (
                        f"event={raw_event_type}; seq={sequence}; "
                        f"raw={raw_board_rejection}; dto=unavailable"
                    )
                    with self._lock:
                        if len(self._board_rejection_reasons) < 16:
                            self._board_rejection_reasons.append(rejection)
                # The immutable envelope belongs to this exact closure. Prefer
                # its skill identity when the DTO has already been cleared or
                # its allocation reused before the external sample.
                message = raw_message or dto_message
                if message is None:
                    if snapshot is not None and raw_event_type is not None:
                        with self._lock:
                            self._seen.add(seen_identity)
                            self._transport_boards[
                                (match_id, root.message_address, root.json_address)
                            ] = (raw_event_type, snapshot)
                    continue
                with self._lock:
                    self._seen.add(seen_identity)
                    self._messages[seen_identity] = message
                    if message.event_type in QTE_RESULT_TYPES:
                        if message is raw_message:
                            self._decoded_raw_results += 1
                        self._results[result_identity] = message
                        if snapshot is not None:
                            self._raw_boards[result_identity] = snapshot
                    if snapshot is not None and raw_event_type is not None:
                        self._transport_boards[
                            (match_id, root.message_address, root.json_address)
                        ] = (raw_event_type, snapshot)
        except (ExternalReadError, OSError, LayoutValidationError) as exc:
            with self._lock:
                self._poll_count += 1
                self._torn_reads += 1
                self._last_error = f"{type(exc).__name__}: {exc}"
        finally:
            # JSON/DTO decoding can take longer than the lifetime of PendingCombat
            # or one queue entry. The second sample closes that decode window.
            self._capture_runtime_batches(match_id)

    def _retain_runtime_batch(
        self,
        match_id: str,
        source: str,
        batch: CombatBatchSnapshot,
    ) -> None:
        if batch.sequence < 0 or dto_rejection_reasons(batch.cells):
            return
        identity = (
            match_id,
            source,
            batch.address,
            batch.sequence,
            board_state_hash(batch.cells),
        )
        with self._lock:
            if identity in self._runtime_batches:
                return
            self._runtime_batches[identity] = (source, batch)
            if source == "MatchService.PendingCombat":
                self._decoded_pending_batches += 1
            else:
                self._decoded_owner_queue_batches += 1

    def _resolve_batch_class(self) -> int | None:
        batch_class = self._batch_class
        if batch_class is None:
            resolved = self._target.resolver.resolve_type_info_class(
                WS_COMBAT_BATCH_TYPE_INFO_RVA
            )
            if isinstance(resolved, int) and is_canonical_user_pointer(resolved):
                batch_class = int(resolved)
                self._batch_class = batch_class
        return batch_class

    def _capture_runtime_batches(self, match_id: str) -> None:
        """Sample short-lived typed board roots without scanning target memory."""

        try:
            self._capture_match_service_pending(match_id)
        except (ExternalReadError, OSError, LayoutValidationError, ValueError):
            pass
        try:
            self._capture_board_ws_queues(match_id)
        except (ExternalReadError, OSError, LayoutValidationError, ValueError):
            pass

    def _capture_match_service_pending(self, match_id: str) -> None:
        service = self._match_service_address
        if service is None:
            resolution = self._target.resolver.resolve_singleton(
                MATCH_SERVICE_SINGLETON
            )
            instance = getattr(resolution, "instance", None)
            if not isinstance(instance, int) or not is_canonical_user_pointer(instance):
                return
            service = int(instance)
            self._match_service_address = service

        memory = self._target.memory
        pending_before = struct.unpack(
            "<Q",
            memory.read(service + MATCH_SERVICE_PENDING_COMBAT_OFFSET, 8),
        )[0]
        if not is_canonical_user_pointer(pending_before):
            return
        match_pointer_before = struct.unpack(
            "<Q",
            memory.read(service + MATCH_SERVICE_CURRENT_MATCH_ID_OFFSET, 8),
        )[0]
        if not is_canonical_user_pointer(match_pointer_before):
            return
        if (
            read_il2cpp_string(memory, match_pointer_before, max_length=256)
            != match_id
        ):
            return
        batch_class = self._resolve_batch_class()
        if batch_class is None:
            return
        batch = read_combat_batch(
            memory,
            pending_before,
            expected_class=batch_class,
        )
        pending_after = struct.unpack(
            "<Q",
            memory.read(service + MATCH_SERVICE_PENDING_COMBAT_OFFSET, 8),
        )[0]
        match_pointer_after = struct.unpack(
            "<Q",
            memory.read(service + MATCH_SERVICE_CURRENT_MATCH_ID_OFFSET, 8),
        )[0]
        if (
            pending_after != pending_before
            or match_pointer_after != match_pointer_before
            or read_il2cpp_string(memory, match_pointer_after, max_length=256)
            != match_id
        ):
            raise LayoutValidationError("PendingCombat changed during capture")
        self._retain_runtime_batch(match_id, "MatchService.PendingCombat", batch)

    def _capture_board_ws_queues(self, match_id: str) -> None:
        with self._lock:
            board_instance = self._runtime_board_instance
            owner_addresses = self._board_ws_owner_addresses
        if board_instance is None or not owner_addresses:
            return
        board_ws_class = self._board_ws_class
        if board_ws_class is None:
            resolved = self._target.resolver.resolve_type_info_class(
                BOARD_WS_APPLIER_TYPE_INFO_RVA
            )
            if not isinstance(resolved, int) or not is_canonical_user_pointer(
                resolved
            ):
                return
            board_ws_class = int(resolved)
            self._board_ws_class = board_ws_class
        batch_class = self._resolve_batch_class()
        if batch_class is None:
            return

        memory = self._target.memory
        for address in owner_addresses:
            try:
                owner_before = read_board_ws_candidate(
                    memory,
                    address,
                    expected_class=board_ws_class,
                    expected_board=board_instance,
                )
                if owner_before.bootstrapped_match_id != match_id:
                    continue
                queue_before = read_pending_queue(memory, owner_before.queue)
                if not queue_before.batch_addresses:
                    continue
                batches = tuple(
                    read_combat_batch(
                        memory,
                        batch_address,
                        expected_class=batch_class,
                    )
                    for batch_address in queue_before.batch_addresses
                )
                owner_after = read_board_ws_candidate(
                    memory,
                    address,
                    expected_class=board_ws_class,
                    expected_board=board_instance,
                )
                queue_after = read_pending_queue(memory, owner_after.queue)
                if (
                    owner_after.bootstrapped_match_id != match_id
                    or owner_after.queue != owner_before.queue
                    or queue_after != queue_before
                ):
                    raise LayoutValidationError(
                        "BoardWsApplier queue changed during capture"
                    )
                for batch in batches:
                    self._retain_runtime_batch(
                        match_id,
                        "BoardWsApplier._pendingBatches",
                        batch,
                    )
            except (ExternalReadError, OSError, LayoutValidationError, ValueError):
                continue


# Existing pet/QTE code imports this name. Keep it as an alias while BASIC uses
# the transport-oriented name that reflects the wider responsibility.
DispatcherQteResultTap = DispatcherTransportTap


__all__ = [
    "DispatcherQteResultTap",
    "DispatcherTransportTap",
    "DispatcherTapDiagnostics",
    "parse_server_envelope_json",
    "parse_skill_result_envelope_json",
]
