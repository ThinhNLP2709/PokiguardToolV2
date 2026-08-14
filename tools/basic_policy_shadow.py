#!/usr/bin/env python3
"""Phase 2C.2A memory -> BASIC PolicyEngine -> JSONL, with zero input."""

from __future__ import annotations

import argparse
from dataclasses import asdict, is_dataclass
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

from pokiguard_v2.basic_policy import (  # noqa: E402
    BasicPolicyEngine,
    Intelligence,
    ManaPriority,
    PlayStyle,
    PolicyConfig,
)
from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
    ProviderSetupError,
    utc_timestamp,
)
from pokiguard_v2.state import GamePhase  # noqa: E402
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.runtime_common import attach_target, default_log_path, hex_pointer  # noqa: E402


def _jsonable(value: Any) -> Any:
    if is_dataclass(value):
        return _jsonable(asdict(value))
    if isinstance(value, Enum):
        return value.value
    if isinstance(value, dict):
        return {str(key): _jsonable(item) for key, item in value.items()}
    if isinstance(value, (tuple, list)):
        return [_jsonable(item) for item in value]
    return value


def _write(log: Any, event: str, **fields: Any) -> None:
    payload = {"timestamp": utc_timestamp(), "event": event, **fields}
    log.write(
        json.dumps(_jsonable(payload), ensure_ascii=False, separators=(",", ":"))
        + "\n"
    )


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(
        description="Run the Phase 2C.2A BASIC policy in shadow/no-input mode"
    )
    parser.add_argument("--watch", action="store_true", help="watch lobby -> combat -> lobby")
    parser.add_argument("--log", type=Path, help="JSONL output path")
    parser.add_argument("--play-style", choices=[value.value for value in PlayStyle], default="simple")
    parser.add_argument(
        "--mana-priority",
        choices=[value.value for value in ManaPriority],
        default="evolution",
    )
    parser.add_argument("--scan-interval", type=float, default=0.35)
    parser.add_argument("--minimum-turn-time", type=int, default=3)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument("--timeout", type=float, default=0.0)
    parser.add_argument("--max-decisions", type=int, default=0)
    parser.add_argument("--matches", type=int, default=1)
    return parser


def run(args: argparse.Namespace) -> int:
    if not args.watch:
        raise ValueError("Phase 2C.2A shadow must be started with --watch")
    if not 0.1 <= args.scan_interval <= 5.0:
        raise ValueError("--scan-interval must be between 0.1 and 5 seconds")
    if args.timeout < 0 or args.max_decisions < 0 or args.matches < 0:
        raise ValueError("timeout/decision/match limits cannot be negative")

    config = PolicyConfig(
        play_style=PlayStyle(args.play_style),
        mana_priority=ManaPriority(args.mana_priority),
        intelligence=Intelligence.BASIC,
        minimum_turn_time_seconds=args.minimum_turn_time,
    )
    engine = BasicPolicyEngine(config)
    log_path = (args.log or default_log_path("basic_policy_shadow")).resolve()
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
        _write(
            log,
            "basic_policy_shadow_started",
            pid=target.pid,
            architecture=target.architecture,
            gameassemblyBase=hex_pointer(target.game_assembly.base),
            gameassemblySize=target.game_assembly.size,
            access=["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"],
            mode="SHADOW_NO_INPUT",
            inputCalls=False,
            config=config,
        )
        print(f"BASIC shadow ready (NO INPUT), PID {target.pid}; log: {log_path}")
        print("Start from game lobby. This tool will never click EVOLVE/CAST/SWAP/PASS/EXIT.", flush=True)
        started = time.monotonic()
        decision_count = 0
        completed_matches = 0
        saw_combat = False
        previous_status: tuple[Any, ...] | None = None
        try:
            while target.is_running():
                if args.timeout and time.monotonic() - started >= args.timeout:
                    _write(log, "basic_policy_shadow_timeout")
                    break
                result = provider.poll()
                status = (result.reason, result.confirmations, result.lifecycle_event)
                if status != previous_status:
                    _write(
                        log,
                        "provider_status",
                        reason=result.reason,
                        confirmations=result.confirmations,
                        lifecycle=result.lifecycle_event,
                    )
                    previous_status = status
                if result.lifecycle_event == "board_found":
                    saw_combat = True
                elif result.lifecycle_event == "board_lost" and saw_combat:
                    completed_matches += 1
                    if args.matches and completed_matches >= args.matches:
                        break

                state = result.state
                if (
                    state is None
                    or state.phase is not GamePhase.COMBAT
                    or not result.publish
                ):
                    time.sleep(args.scan_interval)
                    continue
                decision = engine.decide(state)
                decision_count += 1
                _write(
                    log,
                    "basic_policy_decision",
                    boardInstance=hex_pointer(state.battle.board_instance),
                    srvSeq=state.battle.srv_seq,
                    turn=state.battle.turn_number,
                    currentTurnPlayer=state.battle.current_turn_player,
                    timer={
                        "duration": state.battle.turn_duration_seconds,
                        "remaining": state.battle.turn_time_remaining_seconds,
                        "source": state.battle.turn_timer_source,
                    },
                    skip={
                        "count": state.battle.consecutive_passes,
                        "threshold": state.battle.consecutive_pass_threshold,
                        "source": state.battle.consecutive_pass_source,
                    },
                    player=state.player,
                    opponents=state.opponents,
                    cards=state.cards,
                    fusion=state.fusion,
                    # Complete provider-neutral input makes future policy
                    # versions replayable without another live match.  The
                    # duplicated compact fields above remain for humans and
                    # backward-compatible audit scripts.
                    gameState=state,
                    decision=decision,
                    noInput=True,
                )
                move = decision.move
                detail = (
                    f" r{move.first[0]}c{move.first[1]}<->r{move.second[0]}c{move.second[1]}"
                    if move is not None
                    else ""
                )
                print(
                    f"BASIC SHADOW seq={state.battle.srv_seq} turn={state.battle.turn_number} "
                    f"would={decision.action.value}{detail} step={decision.trace.policy_step}",
                    flush=True,
                )
                if args.max_decisions and decision_count >= args.max_decisions:
                    break
                time.sleep(args.scan_interval)
        finally:
            _write(
                log,
                "basic_policy_shadow_summary",
                decisions=decision_count,
                completedMatches=completed_matches,
                sawCombat=saw_combat,
                providerMetrics=provider.metrics,
                noInput=True,
            )
        print(
            f"BASIC shadow stopped: decisions={decision_count}, matches={completed_matches}; log: {log_path}",
            flush=True,
        )
        return 0 if decision_count else 2


def main(argv: Sequence[str] | None = None) -> int:
    try:
        return run(build_parser().parse_args(argv))
    except KeyboardInterrupt:
        print("BASIC shadow stopped by user.")
        return 130
    except (
        FileNotFoundError,
        OSError,
        ProcessProbeError,
        ProviderSetupError,
        RuntimeError,
        ValueError,
    ) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
