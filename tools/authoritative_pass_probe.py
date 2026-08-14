#!/usr/bin/env python3
"""Phase 2C.2C P0 read-only reset-evidence probe.

Start in the game lobby.  The user performs the controlled idle -> accepted
SWAP/CAST -> idle sequence.  This probe sends no input and writes a capability
file only after two distinct ordered 1/N reset confirmations.
"""

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


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.game_owned_idle import (  # noqa: E402
    AcceptedActivityKind,
    GameOwnedIdleCache,
)
from pokiguard_v2.memory_board_provider import utc_timestamp  # noqa: E402
from pokiguard_v2.reset_evidence_store import (  # noqa: E402
    write_reset_capabilities,
)
from tools.idle_state_watch import ServerMessage, read_match_runtime  # noqa: E402
from tools.lifecycle_idle_watch import (  # noqa: E402
    _message_actor,
    _message_rejected,
    _message_sort_key,
)
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.runtime_common import attach_target, hex_pointer  # noqa: E402
from tools.sequence_desync_runtime import RuntimeSequenceMonitor  # noqa: E402


ACTION_RESPONSES = {
    "MATCH_MOVE_RES": AcceptedActivityKind.SWAP,
    "MATCH_CARD_USE_RES": AcceptedActivityKind.CAST,
    "MATCH_SKILL_USE_RES": AcceptedActivityKind.CAST,
    "MATCH_FUSION_RES": AcceptedActivityKind.EVOLVE,
}


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
    payload = {"timestamp": utc_timestamp(), "event": event, **_jsonable(fields)}
    log.write(json.dumps(payload, ensure_ascii=False, separators=(",", ":")) + "\n")
    log.flush()


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--watch", action="store_true", required=True)
    parser.add_argument("--interval", type=float, default=0.10)
    parser.add_argument(
        "--heartbeat-seconds",
        type=float,
        default=2.0,
        help="write a compact MatchService lifecycle heartbeat while waiting",
    )
    parser.add_argument("--timeout", type=float, default=0.0)
    parser.add_argument("--matches", type=int, default=3)
    parser.add_argument("--required-confirmations", type=int, default=2)
    parser.add_argument("--max-region-mib", type=int, default=16)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument("--log", type=Path)
    parser.add_argument("--evidence-out", type=Path)
    parser.add_argument(
        "--require-cast",
        action="store_true",
        help="do not stop until CAST as well as SWAP reset is production-ready",
    )
    return parser


def _validate(args: argparse.Namespace) -> None:
    if not 0.05 <= args.interval <= 1.0:
        raise ValueError("--interval must be between 0.05 and 1.0 seconds")
    if args.timeout < 0 or args.matches < 0:
        raise ValueError("--timeout/--matches cannot be negative")
    if not 0.5 <= args.heartbeat_seconds <= 30.0:
        raise ValueError("--heartbeat-seconds must be between 0.5 and 30 seconds")
    if not 2 <= args.required_confirmations <= 5:
        raise ValueError("--required-confirmations must be between 2 and 5")
    if not 8 <= args.max_region_mib <= 32:
        raise ValueError("--max-region-mib must be between 8 and 32")
    if not 1 <= args.chunk_mib <= 8:
        raise ValueError("--chunk-mib must be between 1 and 8")


def _authoritative_idle(message: ServerMessage, runtime: Any) -> tuple[bool, str | None]:
    if (
        message.event_type not in {"MATCH_AFK_WARN", "MATCH_TURN_END"}
        or not message.username
        or message.idle_count is None
        or message.threshold is None
    ):
        return False, "not_authoritative_idle_payload"
    if (
        not runtime.local_username
        or message.username.casefold() != runtime.local_username.casefold()
    ):
        return False, "authoritative_username_mismatch"
    if (
        message.event_type == "MATCH_TURN_END"
        and message.source_turn != runtime.turn
    ):
        return False, "stale_nested_idle_turn"
    return True, None


def run(args: argparse.Namespace) -> int:
    _validate(args)
    log_path = (
        args.log
        or PROJECT_ROOT
        / "logs"
        / f"phase2c2c_p0_reset_{datetime.now():%Y%m%d_%H%M%S}.jsonl"
    ).resolve()
    evidence_path = (
        args.evidence_out
        or PROJECT_ROOT / "logs" / "phase2c2c_reset_capabilities.json"
    ).resolve()
    log_path.parent.mkdir(parents=True, exist_ok=True)

    with attach_target() as target, log_path.open(
        "a", encoding="utf-8", buffering=1
    ) as log:
        _service, startup_runtime = read_match_runtime(target)
        if startup_runtime.match_id is not None:
            raise RuntimeError("P0 reset probe must start from lobby, not mid-combat")
        monitor = RuntimeSequenceMonitor(
            target,
            max_region_mib=args.max_region_mib,
            chunk_mib=args.chunk_mib,
            full_rescan_interval=6,
            minimum_scan_seconds=0.20,
        )
        prime = monitor.prime_regions()
        cache = GameOwnedIdleCache(
            required_reset_confirmations=args.required_confirmations
        )
        active_session: tuple[str, str, int] | None = None
        active_session_id: str | None = None
        active_match_id: str | None = None
        last_local_turn: int | None = None
        completed_matches = 0
        started = time.monotonic()
        last_heartbeat = 0.0
        previous_lifecycle_signature: tuple[Any, ...] | None = None
        evidence_written = False

        _write(
            log,
            "p0_reset_probe_started",
            pid=target.pid,
            gameAssemblyBase=hex_pointer(target.game_assembly.base),
            noInput=True,
            requiredConfirmations=args.required_confirmations,
            evidenceOut=evidence_path,
            transportPrime=prime,
            sources=["MATCH_AFK_WARN", "MATCH_TURN_END.matchPayload.afkWarn"],
        )
        print(f"P0 reset probe READ-ONLY; log: {log_path}", flush=True)
        print(
            "Scenario: idle once -> accepted SWAP -> idle once; repeat twice.",
            flush=True,
        )

        while target.is_running():
            if args.timeout and time.monotonic() - started >= args.timeout:
                break
            service, runtime = read_match_runtime(target)
            now = time.monotonic()
            lifecycle_signature = (
                service,
                runtime.match_id,
                runtime.turn,
                runtime.current_player,
                runtime.local_username,
                runtime.local_move_sequence,
                runtime.highest_acked_sequence,
            )
            lifecycle_changed = (
                previous_lifecycle_signature is None
                or lifecycle_signature[:2] != previous_lifecycle_signature[:2]
            )
            if lifecycle_changed or now - last_heartbeat >= args.heartbeat_seconds:
                _write(
                    log,
                    "p0_lifecycle_heartbeat",
                    matchService=hex_pointer(service),
                    runtime=runtime,
                    lifecycleChanged=lifecycle_changed,
                )
                last_heartbeat = now
            previous_lifecycle_signature = lifecycle_signature
            if runtime.match_id is not None and runtime.match_id != active_match_id:
                if active_session is not None:
                    monitor.end_session(active_session)
                active_match_id = runtime.match_id
                active_session = ("p0", runtime.match_id, target.pid)
                active_session_id = f"pid={target.pid}|match={runtime.match_id}"
                cache.begin_session(active_session_id)
                monitor.begin_session(
                    active_session, runtime.match_id, clean=True
                )
                last_local_turn = None
                _write(
                    log,
                    "p0_combat_started",
                    session=active_session_id,
                    runtime=runtime,
                    source="MatchService.CurrentMatchId",
                )
            elif runtime.match_id is None and active_session is not None:
                ended = active_session
                if active_session_id is not None:
                    cache.end_session(active_session_id)
                monitor.end_session(ended)
                active_session = None
                active_session_id = None
                active_match_id = None
                last_local_turn = None
                completed_matches += 1
                _write(
                    log,
                    "p0_combat_ended",
                    session=ended,
                    completedMatches=completed_matches,
                )
                if args.matches and completed_matches >= args.matches:
                    break

            if active_session is None or active_session_id is None:
                time.sleep(args.interval)
                continue

            observation = monitor.poll(
                session_key=active_session,
                match_id=active_match_id,
                turn=runtime.turn,
                srv_seq=runtime.highest_acked_sequence,
                timestamp=utc_timestamp(),
            )
            runtime = observation.runtime
            local_turn = bool(
                runtime.local_username
                and runtime.current_player
                and runtime.local_username.casefold()
                == runtime.current_player.casefold()
            )
            if local_turn and runtime.turn is not None:
                last_local_turn = runtime.turn

            for message in sorted(observation.messages, key=_message_sort_key):
                idle_ok, idle_rejection = _authoritative_idle(message, runtime)
                idle_before = cache.state
                if idle_ok:
                    idle_after = cache.observe_server_payload(
                        session_id=active_session_id,
                        username=message.username or "",
                        idle_count=int(message.idle_count),
                        threshold=int(message.threshold),
                        source_message_type=message.event_type,
                        source_srv_seq=message.server_sequence,
                        source_turn=message.source_turn,
                        source_timestamp=message.timestamp,
                        observed_timestamp=utc_timestamp(),
                        source_path=(
                            "MATCH_TURN_END.matchPayload.afkWarn"
                            if message.event_type == "MATCH_TURN_END"
                            else "MATCH_AFK_WARN"
                        ),
                    )
                else:
                    idle_after = cache.state

                kind = ACTION_RESPONSES.get(message.event_type)
                actor = _message_actor(message)
                local_activity = bool(
                    kind is not None
                    and actor
                    and runtime.local_username
                    and actor.casefold() == runtime.local_username.casefold()
                )
                accepted = bool(local_activity and not _message_rejected(message))
                if accepted and kind is not None:
                    activity = cache.observe_accepted_activity(
                        session_id=active_session_id,
                        kind=kind,
                        source_message_type=message.event_type,
                        source_srv_seq=message.server_sequence,
                        source_turn=last_local_turn,
                        source_timestamp=message.timestamp,
                        observed_timestamp=utc_timestamp(),
                    )
                else:
                    activity = None
                    if local_activity and kind is not None:
                        cache.observe_rejected_activity(
                            session_id=active_session_id, kind=kind
                        )

                swap_capability = cache.reset_capability(
                    AcceptedActivityKind.SWAP
                )
                cast_capability = cache.reset_capability(
                    AcceptedActivityKind.CAST
                )
                _write(
                    log,
                    "p0_server_message",
                    session=active_session,
                    runtime=runtime,
                    message=message,
                    authoritativeIdle=idle_ok,
                    idleRejection=idle_rejection,
                    idleBefore=idle_before,
                    idleAfter=idle_after,
                    acceptedActivity=activity,
                    swapReset=swap_capability,
                    castReset=cast_capability,
                )

                ready = swap_capability.production_ready and (
                    cast_capability.production_ready or not args.require_cast
                )
                if ready:
                    capabilities = [swap_capability]
                    if cast_capability.production_ready:
                        capabilities.append(cast_capability)
                    write_reset_capabilities(
                        evidence_path,
                        capabilities,
                        generated_at=utc_timestamp(),
                        source_log=str(log_path),
                    )
                    evidence_written = True
                    _write(
                        log,
                        "p0_reset_acceptance_pass",
                        capabilities=capabilities,
                        evidenceOut=evidence_path,
                        noInput=True,
                    )
                    print(
                        f"P0 PASS: reset evidence đã ghi tại {evidence_path}",
                        flush=True,
                    )
                    break
            if evidence_written:
                break
            if monitor.tracker.state.terminal_for_session:
                cache.clear("sequence_desync_terminal")
                _write(
                    log,
                    "p0_sequence_desync",
                    state=monitor.tracker.state,
                    evidenceWritten=False,
                )
                break
            time.sleep(args.interval)

        _write(
            log,
            "p0_reset_probe_summary",
            completedMatches=completed_matches,
            swapReset=cache.reset_capability(AcceptedActivityKind.SWAP),
            castReset=cache.reset_capability(AcceptedActivityKind.CAST),
            evidenceWritten=evidence_written,
            evidenceOut=evidence_path,
            noInput=True,
        )
        return 0 if evidence_written else 2


def main(argv: Sequence[str] | None = None) -> int:
    args = build_parser().parse_args(argv)
    try:
        return run(args)
    except KeyboardInterrupt:
        print("P0 reset probe stopped by user.")
        return 130
    except (
        FileNotFoundError,
        OSError,
        ProcessProbeError,
        RuntimeError,
        ValueError,
    ) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
