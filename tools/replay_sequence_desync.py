#!/usr/bin/env python3
"""Replay captured sequence-desync JSONL evidence without game input."""

from __future__ import annotations

import argparse
import json
from pathlib import Path
import sys
from typing import Any, Iterable, Sequence


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.sequence_desync import (  # noqa: E402
    SequenceDesyncTracker,
    SequenceRootTelemetry,
    classify_sequence_signal,
    sequence_jsonable,
)


def _match_from_session(session: Any) -> str | None:
    if isinstance(session, str) and "|match=" in session:
        return session.rsplit("|match=", 1)[-1] or None
    if isinstance(session, dict):
        return session.get("match_id") or session.get("matchId")
    return None


def replay_records(records: Iterable[dict[str, Any]]) -> SequenceDesyncTracker:
    tracker = SequenceDesyncTracker()
    last_move_sequence: int | None = None
    for record in records:
        event = record.get("event")
        session = record.get("session")
        match_id = _match_from_session(session)
        if event == "combat_session_started" and session and match_id:
            tracker.begin_session(session, match_id, clean=True)
            continue
        if event == "actual_move_detected":
            value = record.get("lastMoveSequence")
            last_move_sequence = value if isinstance(value, int) else last_move_sequence
            continue
        if event == "combat_session_invalidated":
            tracker.end_session(session)
            continue
        if event != "server_match_message" or not session:
            continue
        message = record.get("message") or {}
        match_id = message.get("match_id") or match_id
        if not match_id:
            continue
        if tracker.active_session is None:
            tracker.begin_session(session, match_id, clean=True)
        strings = dict(message.get("payload_strings") or ())
        ints = dict(message.get("payload_ints") or ())
        reject_code = ints.get("errorCode") or ints.get("code") or strings.get("errorCode") or strings.get("code")
        fallback = strings.get("reason") or strings.get("error") or strings.get("message")
        signal = classify_sequence_signal(
            event_type=str(message.get("event_type") or ""),
            reject_code=reject_code,
            reject_reason=message.get("reject_reason"),
            fallback_text=fallback,
        )
        observed = message.get("server_sequence")
        tracker.observe(
            signal,
            timestamp=str(record.get("timestamp") or message.get("timestamp") or "UNKNOWN"),
            session_key=session,
            match_id=match_id,
            turn=record.get("turn"),
            srv_seq=(observed if isinstance(observed, int) else None),
            root_telemetry=SequenceRootTelemetry.observed(
                observed_client_sequence=(observed if isinstance(observed, int) else None),
                last_move_sequence=last_move_sequence,
            ),
        )
    return tracker


def replay(path: Path) -> SequenceDesyncTracker:
    records: list[dict[str, Any]] = []
    with path.open("r", encoding="utf-8") as source:
        for line_number, line in enumerate(source, 1):
            if not line.strip():
                continue
            value = json.loads(line)
            if not isinstance(value, dict):
                raise ValueError(f"line {line_number} is not a JSON object")
            records.append(value)
    return replay_records(records)


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument(
        "log",
        nargs="?",
        type=Path,
        default=PROJECT_ROOT / "reference" / "sequence_desync_m714b231e.jsonl",
    )
    return parser


def main(argv: Sequence[str] | None = None) -> int:
    args = build_parser().parse_args(argv)
    tracker = replay(args.log.resolve())
    print(json.dumps(sequence_jsonable(tracker.state), ensure_ascii=False, indent=2))
    return 0 if tracker.state.terminal_for_session else 2


if __name__ == "__main__":
    raise SystemExit(main())
