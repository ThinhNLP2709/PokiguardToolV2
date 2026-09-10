#!/usr/bin/env python3
"""Capture authoritative opening-board evidence (READ-ONLY, NO INPUT)."""

from __future__ import annotations

import argparse
from dataclasses import asdict, is_dataclass
from datetime import datetime
from enum import Enum
import json
from pathlib import Path
import sys
import time
from typing import Any, Sequence

try:
    import winsound
except ImportError:  # pragma: no cover - Windows-only production probe
    winsound = None


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.il2cpp_external import (  # noqa: E402
    WS_COMBAT_BATCH_TYPE_INFO_RVA,
    ExternalReadError,
    is_canonical_user_pointer,
)
from pokiguard_v2.il2cpp_layout import LayoutValidationError  # noqa: E402
from pokiguard_v2.live_state import board_state_hash  # noqa: E402
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
    batch_identity,
    utc_timestamp,
)
from pokiguard_v2.opening_snapshot import (  # noqa: E402
    JARRAY_TYPE_INFO_RVA,
    JOBJECT_TYPE_INFO_RVA,
    JPROPERTY_TYPE_INFO_RVA,
    JVALUE_TYPE_INFO_RVA,
    NewtonsoftClasses,
    read_match_start_opening_snapshot,
)
from pokiguard_v2.memory_scan import (  # noqa: E402
    bounded_private_writable_regions,
    regions_containing_addresses,
    scan_aligned_qwords,
    validate_combat_batch_hits,
)
from tools.idle_state_watch import (  # noqa: E402
    CHAT_MESSAGE_DTO_TYPE_INFO_RVA,
    read_dictionary_entries,
)
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.runtime_common import attach_target, hex_pointer  # noqa: E402
from tools.sequence_desync_runtime import RuntimeSequenceMonitor  # noqa: E402


def _jsonable(value: Any) -> Any:
    if is_dataclass(value):
        return _jsonable(asdict(value))
    if isinstance(value, Enum):
        return value.value
    if isinstance(value, dict):
        return {str(key): _jsonable(item) for key, item in value.items()}
    if isinstance(value, (tuple, list, set)):
        return [_jsonable(item) for item in value]
    if isinstance(value, Path):
        return str(value)
    return value


def _write(log: Any, event: str, **fields: Any) -> None:
    log.write(
        json.dumps(
            {"timestamp": utc_timestamp(), "event": event, **_jsonable(fields)},
            ensure_ascii=False,
            separators=(",", ":"),
        )
        + "\n"
    )
    log.flush()


def _published_beep() -> None:
    """Two short tones: opening state is stable; still sends no game input."""

    if winsound is None:
        return
    for _index in range(2):
        winsound.Beep(1050, 140)
        time.sleep(0.10)


def describe_payload(memory: Any, payload: int) -> tuple[dict[str, Any], ...]:
    """List exact dictionary keys and runtime value classes without guessing types."""

    entries = read_dictionary_entries(memory, payload, max_entries=256)
    output = []
    for key, address in sorted(entries.items()):
        try:
            class_pointer = int.from_bytes(memory.read(address, 8), "little")
        except (ExternalReadError, OSError):
            class_pointer = 0
        output.append(
            {
                "key": key,
                "valueAddress": hex_pointer(address),
                "classPointer": (
                    hex_pointer(class_pointer)
                    if is_canonical_user_pointer(class_pointer)
                    else None
                ),
            }
        )
    return tuple(output)


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--watch", action="store_true", required=True)
    parser.add_argument("--log", type=Path)
    parser.add_argument("--interval", type=float, default=0.12)
    parser.add_argument("--timeout", type=float, default=180.0)
    parser.add_argument(
        "--beep-on-publish",
        action="store_true",
        help="beep twice after the opening GameState passes both stability confirmations",
    )
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    return parser


def run(args: argparse.Namespace) -> int:
    if not 0.08 <= args.interval <= 1.0:
        raise ValueError("--interval must be between 0.08 and 1.0 seconds")
    if not 10 <= args.timeout <= 600:
        raise ValueError("--timeout must be between 10 and 600 seconds")
    if not 1 <= args.max_region_mib <= 32 or not 1 <= args.chunk_mib <= 16:
        raise ValueError("scan size arguments are outside their safe bounds")
    log_path = (
        args.log
        or PROJECT_ROOT
        / "logs"
        / f"opening_snapshot_probe_{datetime.now():%Y%m%d_%H%M%S}.jsonl"
    ).resolve()
    log_path.parent.mkdir(parents=True, exist_ok=True)

    with attach_target() as target, log_path.open(
        "a", encoding="utf-8", buffering=1
    ) as log:
        provider = MemoryBoardStateProvider(
            target,
            MemoryProviderConfig(
                max_region_mib=args.max_region_mib,
                chunk_mib=args.chunk_mib,
                required_confirmations=2,
                require_lobby_start=True,
            ),
        )
        monitor = RuntimeSequenceMonitor(
            target,
            max_region_mib=args.max_region_mib,
            chunk_mib=args.chunk_mib,
        )
        batch_class = target.resolver.resolve_type_info_class(
            WS_COMBAT_BATCH_TYPE_INFO_RVA
        )
        message_class = target.resolver.resolve_type_info_class(
            CHAT_MESSAGE_DTO_TYPE_INFO_RVA
        )
        if batch_class is None or message_class is None:
            raise LayoutValidationError("opening probe type-info is not initialized")
        opening_class_values = tuple(
            target.resolver.resolve_type_info_class(rva)
            for rva in (
                JARRAY_TYPE_INFO_RVA,
                JOBJECT_TYPE_INFO_RVA,
                JPROPERTY_TYPE_INFO_RVA,
                JVALUE_TYPE_INFO_RVA,
            )
        )
        if not all(value is not None for value in opening_class_values):
            raise LayoutValidationError("Newtonsoft opening-board type-info is not initialized")
        opening_classes = NewtonsoftClasses(
            *(int(value) for value in opening_class_values)
        )

        def regions() -> tuple[Any, ...]:
            return bounded_private_writable_regions(
                target.memory.iter_readable_regions(),
                max_region_size=args.max_region_mib * 1024 * 1024,
            )

        lobby_regions = regions()
        baseline_scan = scan_aligned_qwords(
            target.memory,
            lobby_regions,
            {"batch": int(batch_class)},
            chunk_size=args.chunk_mib * 1024 * 1024,
        )
        baseline_batches = validate_combat_batch_hits(
            target.memory,
            baseline_scan.matches["batch"],
            batch_class=int(batch_class),
        )
        baseline = {batch_identity(batch) for batch in baseline_batches}
        _write(
            log,
            "opening_probe_started",
            pid=target.pid,
            gameAssemblyBase=hex_pointer(target.game_assembly.base),
            noInput=True,
            baselineReady=provider.scan_diagnostics["lobbyBaselineReady"],
            baselineBatches=len(baseline),
            processAccess=["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"],
        )
        print(f"Opening snapshot probe ready (READ-ONLY): {log_path}", flush=True)

        started = time.monotonic()
        active_session = None
        learned_batch_regions: set[Any] = set()
        scan_count = 0
        logged_batches: set[tuple[int, int, str]] = set()
        logged_messages: set[int] = set()
        saw_opening = False
        saw_opening_published = False
        publish_beep_sent = False
        saw_match_start_board = False
        saw_post_opening_transition = False
        last_status = None

        while target.is_running() and time.monotonic() - started < args.timeout:
            poll = provider.poll()
            status = (
                poll.reason,
                poll.lifecycle_event,
                poll.session_key,
                poll.combat_lifecycle.state if poll.combat_lifecycle else None,
            )
            if status != last_status:
                _write(
                    log,
                    "provider_status",
                    reason=poll.reason,
                    lifecycle=poll.lifecycle_event,
                    session=poll.session_key,
                    combatLifecycle=(
                        poll.combat_lifecycle.state if poll.combat_lifecycle else None
                    ),
                    diagnostics=provider.scan_diagnostics,
                )
                last_status = status
            if (
                poll.publish
                and poll.reason == "stable_match_start_opening_dto"
                and poll.state is not None
            ):
                saw_opening_published = True
                _write(
                    log,
                    "opening_state_published",
                    session=poll.session_key,
                    srvSeq=poll.state.battle.srv_seq,
                    boardHash=poll.state.battle.board_hash,
                    completeCells=64,
                    confirmations=poll.confirmations,
                    noInput=True,
                )
                if args.beep_on_publish and not publish_beep_sent:
                    publish_beep_sent = True
                    _published_beep()

            if (
                poll.lifecycle_event in {"board_found", "session_changed"}
                and poll.session_key is not None
            ):
                active_session = poll.session_key
                monitor.begin_session(
                    active_session, active_session.match_id, clean=True
                )
                learned_batch_regions.clear()
                scan_count = 0
                _write(log, "opening_session_started", session=active_session)

            if active_session is not None:
                observation = monitor.poll(
                    session_key=active_session,
                    match_id=active_session.match_id,
                    turn=(poll.state.battle.turn_number if poll.state else None),
                    srv_seq=(poll.state.battle.srv_seq if poll.state else None),
                    timestamp=utc_timestamp(),
                )
                runtime = observation.runtime
                for message in observation.messages:
                    if message.event_type != "MATCH_START" or message.address in logged_messages:
                        continue
                    logged_messages.add(message.address)
                    description = None
                    error = None
                    if message.payload_address is not None:
                        try:
                            description = describe_payload(
                                target.memory, message.payload_address
                            )
                        except (ExternalReadError, OSError, LayoutValidationError) as exc:
                            error = str(exc)
                    _write(
                        log,
                        "match_start_payload",
                        session=active_session,
                        message=message,
                        payloadEntries=description,
                        payloadError=error,
                    )
                    if message.payload_address is not None:
                        try:
                            opening = read_match_start_opening_snapshot(
                                target.memory,
                                match_id=active_session.match_id,
                                message_address=message.address,
                                payload_address=message.payload_address,
                                classes=opening_classes,
                            )
                            offered = provider.offer_opening_snapshot(opening)
                            saw_match_start_board = saw_match_start_board or offered
                            _write(
                                log,
                                "match_start_board_decoded",
                                session=active_session,
                                messageAddress=hex_pointer(message.address),
                                boardAddress=hex_pointer(
                                    opening.board_token_address
                                ),
                                srvSeq=opening.sequence,
                                boardHash=board_state_hash(opening.cells),
                                completeCells=len(opening.cells),
                                acceptedByProvider=offered,
                                cells=opening.cells,
                            )
                        except (ExternalReadError, OSError, LayoutValidationError, ValueError) as exc:
                            _write(
                                log,
                                "match_start_board_rejected",
                                session=active_session,
                                messageAddress=hex_pointer(message.address),
                                reason=str(exc),
                            )

                # The opening decoder/provider is the subject of this probe.
                # A full diagnostic WsCombatBatch heap scan can take more than
                # a second and previously delayed the next stability poll past
                # the user's manual opening move. Prioritize two quick provider
                # confirmations until the opening state is published.
                if (
                    saw_match_start_board
                    and runtime.local_move_sequence == 0
                    and not saw_opening_published
                ):
                    _write(
                        log,
                        "opening_publication_pending",
                        session=active_session,
                        runtime=runtime,
                        noInput=True,
                    )
                    time.sleep(args.interval)
                    continue

                scan_count += 1
                all_regions = regions()
                full = not learned_batch_regions or scan_count % 8 == 0
                selected_regions = (
                    all_regions
                    if full
                    else tuple(
                        sorted(learned_batch_regions, key=lambda region: region.base)
                    )
                )
                scan = scan_aligned_qwords(
                    target.memory,
                    selected_regions,
                    {"batch": int(batch_class)},
                    chunk_size=args.chunk_mib * 1024 * 1024,
                )
                learned_batch_regions.update(
                    regions_containing_addresses(
                        all_regions, scan.matches.get("batch", ())
                    )
                )
                batches = validate_combat_batch_hits(
                    target.memory,
                    scan.matches["batch"],
                    batch_class=int(batch_class),
                )
                for batch in batches:
                    identity = batch_identity(batch)
                    if identity in baseline or identity in logged_batches:
                        continue
                    logged_batches.add(identity)
                    if batch.sequence == 0:
                        saw_opening = True
                    if batch.sequence > 0:
                        saw_post_opening_transition = True
                    _write(
                        log,
                        "post_lobby_batch_candidate",
                        session=active_session,
                        object=hex_pointer(batch.address),
                        srvSeq=batch.sequence,
                        boardHash=board_state_hash(batch.cells),
                        completeCells=len(batch.cells),
                        source="bounded_post_lobby_heap_scan_diagnostic_only",
                        cells=batch.cells,
                    )

                _write(
                    log,
                    "opening_runtime_sample",
                    session=active_session,
                    runtime=runtime,
                    sawOpeningBatch=saw_opening,
                    sawPostOpeningTransition=saw_post_opening_transition,
                )
                if runtime.local_move_sequence and runtime.local_move_sequence > 0:
                    # Capture one final full scan after the user's manual move.
                    if saw_post_opening_transition or scan_count >= 16:
                        break

            if poll.lifecycle_event == "board_lost" and active_session is not None:
                break
            time.sleep(args.interval)

        _write(
            log,
            "opening_probe_summary",
            session=active_session,
            sawOpeningBatch=saw_opening,
            sawMatchStartBoard=saw_match_start_board,
            sawOpeningPublished=saw_opening_published,
            sawPostOpeningTransition=saw_post_opening_transition,
            loggedBatchCount=len(logged_batches),
            loggedMatchStartCount=len(logged_messages),
            noInput=True,
            providerMetrics=provider.metrics,
        )
        print(f"Opening snapshot probe stopped: {log_path}", flush=True)
        return 0


def main(argv: Sequence[str] | None = None) -> int:
    try:
        return run(build_parser().parse_args(argv))
    except KeyboardInterrupt:
        print("Opening probe stopped by user.")
        return 130
    except (
        ExternalReadError,
        FileNotFoundError,
        LayoutValidationError,
        OSError,
        ProcessProbeError,
        RuntimeError,
        ValueError,
    ) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
