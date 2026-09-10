"""High-cadence read-only capture of dispatcher-owned skill responses."""

from __future__ import annotations

from dataclasses import dataclass
import hashlib
import json
import threading
import time
from typing import Any

from pokiguard_v2.dispatcher_chat_roots import DispatcherChatRootReader
from pokiguard_v2.il2cpp_external import (
    CHAT_MESSAGE_DTO_TYPE_INFO_RVA,
    ExternalReadError,
)
from pokiguard_v2.il2cpp_layout import LayoutValidationError
from pokiguard_v2.il2cpp_layout import read_il2cpp_string
from pokiguard_v2.opening_snapshot import (
    OpeningBoardSnapshot,
    SUPPORTED_TRANSPORT_BOARD_EVENTS,
    parse_transport_board_envelope_json,
)
from pokiguard_v2.pet_qte_observer import QTE_RESULT_TYPES
from tools.idle_state_watch import ServerMessage, read_server_message


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


def parse_skill_result_envelope_json(
    raw_json: str,
    *,
    expected_match_id: str,
    message_address: int,
) -> ServerMessage:
    """Decode an immutable queued skill response without trusting its DTO.

    Unity's callback closure owns the original JSON string before it owns the
    mutable/deserialized ``ChatMessageDTO``.  This decoder intentionally exposes
    only the small field set already consumed by result correlation.  Exact
    event and MatchId remain mandatory, malformed typed values stay absent, and
    the response still needs temporal/current-generation correlation later.
    """

    if not raw_json or len(raw_json) > 262_144:
        raise LayoutValidationError("skill response JSON length is invalid")
    try:
        envelope = json.loads(raw_json)
    except (TypeError, json.JSONDecodeError) as exc:
        raise LayoutValidationError("skill response JSON is malformed") from exc
    if not isinstance(envelope, dict):
        raise LayoutValidationError("skill response JSON envelope is not an object")
    if envelope.get("type") != "MATCH_SKILL_USE_RES":
        raise LayoutValidationError("raw callback is not a skill-use response")
    if envelope.get("matchId") != expected_match_id or not expected_match_id:
        raise LayoutValidationError("skill response JSON MatchId is stale")
    payload_value = envelope.get("matchPayload")
    if payload_value is None:
        payload: dict[str, Any] = {}
    elif isinstance(payload_value, dict):
        payload = payload_value
    else:
        raise LayoutValidationError("skill response JSON matchPayload is invalid")

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
    return ServerMessage(
        address=message_address,
        event_type="MATCH_SKILL_USE_RES",
        match_id=expected_match_id,
        timestamp=_optional_raw_string(envelope.get("timestamp"), maximum=128),
        username=_optional_raw_string(envelope.get("username")),
        # This object is a parsed immutable-string witness, not a Newtonsoft
        # payload address. The independently parsed board snapshot carries its
        # own raw-string provenance when present.
        payload_address=None,
        server_sequence=_optional_raw_int(envelope.get("seqNum")),
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
    raw_board_rejections: int
    last_error: str | None


class DispatcherQteResultTap:
    """Retain exact skill envelopes before Unity drains their callback.

    The tap is dormant until ``arm``.  It then performs only a handful of
    direct ``ReadProcessMemory`` calls every two milliseconds.  It never scans
    the heap and never writes or invokes code in the target process.
    """

    def __init__(self, target: Any, *, interval_seconds: float = 0.002) -> None:
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
        self._seen: set[tuple[str, int, int | None, bytes]] = set()
        self._results: dict[tuple[str, int], Any] = {}
        self._raw_boards: dict[tuple[str, int], OpeningBoardSnapshot] = {}
        self._transport_boards: dict[
            tuple[str, int, int], tuple[str, OpeningBoardSnapshot]
        ] = {}
        self._poll_count = 0
        self._stable_root_reads = 0
        self._torn_reads = 0
        self._candidate_messages = 0
        self._decoded_raw_results = 0
        self._raw_board_rejections = 0
        self._last_error: str | None = None
        self._dto_class: int | None = None

    def arm(self, match_id: str) -> None:
        if not match_id:
            raise ValueError("dispatcher tap requires a current MatchId")
        with self._lock:
            if self._match_id != match_id:
                self._seen.clear()
                self._results.clear()
                self._raw_boards.clear()
                self._transport_boards.clear()
            self._match_id = match_id
            if self._thread is None:
                self._thread = threading.Thread(
                    target=self._run,
                    name="phase3b3-dispatcher-result-tap",
                    daemon=True,
                )
                self._thread.start()
        self._wake.set()

    def disarm(self) -> None:
        with self._lock:
            self._match_id = None
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

    @property
    def diagnostics(self) -> DispatcherTapDiagnostics:
        with self._lock:
            return DispatcherTapDiagnostics(
                armed_match_id=self._match_id,
                poll_count=self._poll_count,
                stable_root_reads=self._stable_root_reads,
                torn_or_unavailable_reads=self._torn_reads,
                candidate_messages=self._candidate_messages,
                decoded_skill_results=len(self._results),
                decoded_raw_results=self._decoded_raw_results,
                decoded_raw_boards=len(self._transport_boards),
                raw_board_rejections=self._raw_board_rejections,
                last_error=self._last_error,
            )

    def _run(self) -> None:
        while not self._stop.is_set():
            if not self._wake.wait(0.1):
                continue
            if self._stop.is_set():
                return
            with self._lock:
                match_id = self._match_id
            if match_id is None:
                self._wake.clear()
                continue
            self._capture_once(match_id)
            # ``threading.Event.wait(0.002)`` is quantized close to one Windows
            # scheduler tick on this host (~15 ms).  Python's high-resolution
            # sleep uses the waitable-timer path and preserves the intended
            # 2–3 ms cadence.  The tap exists for at most the bounded result
            # wait, so the equally short stop latency is acceptable.
            time.sleep(self._interval)

    def _capture_once(self, match_id: str) -> None:
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
            for root in roots:
                result_identity = (match_id, root.message_address)
                raw_json = None
                raw_message = None
                raw_event_type = None
                snapshot = None
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
                        raw_message = parse_skill_result_envelope_json(
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
                    except (
                        TypeError,
                        json.JSONDecodeError,
                        LayoutValidationError,
                        ValueError,
                    ):
                        if raw_event_type is not None:
                            self._raw_board_rejections += 1
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
                    if message.event_type in QTE_RESULT_TYPES:
                        if message is raw_message:
                            self._decoded_raw_results += 1
                        self._seen.add(seen_identity)
                        self._results[result_identity] = message
                        if snapshot is not None:
                            self._raw_boards[result_identity] = snapshot
                    if snapshot is not None and raw_event_type is not None:
                        self._seen.add(seen_identity)
                        self._transport_boards[
                            (match_id, root.message_address, root.json_address)
                        ] = (raw_event_type, snapshot)
        except (ExternalReadError, OSError, LayoutValidationError) as exc:
            with self._lock:
                self._poll_count += 1
                self._torn_reads += 1
                self._last_error = f"{type(exc).__name__}: {exc}"


__all__ = [
    "DispatcherQteResultTap",
    "DispatcherTapDiagnostics",
    "parse_skill_result_envelope_json",
]
