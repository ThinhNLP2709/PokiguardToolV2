#!/usr/bin/env python3
"""Phase 2B memory -> V1 solver -> JSONL observer.  This tool never clicks."""

from __future__ import annotations

import argparse
from dataclasses import asdict, is_dataclass
from enum import Enum
import json
import os
from pathlib import Path
import sys
import time
from typing import Any, Sequence


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.memory_board_provider import (  # noqa: E402
    MemoryBoardStateProvider,
    MemoryProviderConfig,
    ProviderSetupError,
)
from pokiguard_v2.state import GamePhase  # noqa: E402
from pokiguard_v2.v1_cv_validation import V1CvValidator  # noqa: E402
from pokiguard_v2.v1_solver_adapter import (  # noqa: E402
    V1ContextHints,
    V1ShadowSession,
    V1SolverAdapter,
)
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
    from pokiguard_v2.memory_board_provider import utc_timestamp

    payload = {"timestamp": utc_timestamp(), "event": event, **fields}
    log.write(
        json.dumps(_jsonable(payload), ensure_ascii=False, separators=(",", ":"))
        + "\n"
    )


def _cells(state: Any) -> list[dict[str, Any]]:
    if state.board is None:
        return []
    return [
        {
            "row": cell.row,
            "col": cell.col,
            "gem": cell.gem.value,
            "multiplier": cell.multiplier,
        }
        for row in state.board.cells
        for cell in row
    ]


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(
        description="Run Pokiguard V2 memory solver in no-input shadow mode"
    )
    parser.add_argument("--watch", action="store_true", help="watch lobby -> combat -> lobby")
    parser.add_argument("--log", type=Path, help="JSONL output path")
    parser.add_argument(
        "--v1-root", type=Path, default=Path(r"D:\PokiguardAuto")
    )
    parser.add_argument("--scan-interval", type=float, default=0.35)
    parser.add_argument("--max-region-mib", type=int, default=8)
    parser.add_argument("--chunk-mib", type=int, default=2)
    parser.add_argument(
        "--cv-attempts",
        type=int,
        default=3,
        help="independent live CV audit attempts per published memory state",
    )
    parser.add_argument("--timeout", type=float, default=0.0)
    parser.add_argument("--max-decisions", type=int, default=0)
    parser.add_argument(
        "--matches",
        type=int,
        default=1,
        help="complete combat lifecycles required; 0 means no fixed match count",
    )
    parser.add_argument(
        "--min-comparisons",
        type=int,
        default=0,
        help="keep watching across matches until this many full 64-cell audits",
    )
    parser.add_argument(
        "--no-cv-validation",
        action="store_true",
        help="disable independent V1 CV comparison (memory board still works)",
    )
    return parser


def run(args: argparse.Namespace) -> int:
    if not args.watch:
        raise ValueError("Phase 2B shadow mode must be started with --watch")
    if not 0.1 <= args.scan_interval <= 5.0:
        raise ValueError("--scan-interval must be between 0.1 and 5 seconds")
    if (
        args.timeout < 0
        or args.max_decisions < 0
        or args.matches < 0
        or args.min_comparisons < 0
        or not 1 <= args.cv_attempts <= 5
    ):
        raise ValueError(
            "limits are invalid; --cv-attempts must be between one and five"
        )
    if not args.no_cv_validation:
        try:
            import cv2  # noqa: F401
            import mss  # noqa: F401
        except ImportError as exc:
            v1_python = (args.v1_root / ".venv" / "Scripts" / "python.exe").resolve()
            if v1_python.is_file() and Path(sys.executable).resolve() != v1_python:
                os.execv(
                    str(v1_python),
                    [str(v1_python), str(Path(__file__).resolve()), *sys.argv[1:]],
                )
            raise RuntimeError(
                "live CV validation needs cv2+mss; run with the V1 virtualenv "
                "or pass --no-cv-validation"
            ) from exc
    log_path = (args.log or default_log_path("shadow")).resolve()
    log_path.parent.mkdir(parents=True, exist_ok=True)
    adapter = V1SolverAdapter(args.v1_root)
    session = V1ShadowSession()
    cv: V1CvValidator | None = None
    if not args.no_cv_validation:
        cv = V1CvValidator(args.v1_root)

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
        started = time.monotonic()
        debug_since_ns = time.time_ns()
        decision_count = 0
        saw_combat = False
        completed_matches = 0
        previous_cards: tuple[Any, ...] = ()
        previous_fusion: Any | None = None
        previous_provider_signature: tuple[Any, ...] | None = None
        comparison_totals = {
            "boardsCompared": 0,
            "cellsCompared": 0,
            "gemMatches": 0,
            "gemMismatches": 0,
            "unknowns": 0,
            "multiplierCompared": 0,
            "multiplierMatches": 0,
            "multiplierMismatches": 0,
        }
        _write(
            log,
            "shadow_started",
            pid=target.pid,
            architecture=target.architecture,
            gameassemblyBase=hex_pointer(target.game_assembly.base),
            gameassemblySize=target.game_assembly.size,
            access=["PROCESS_QUERY_INFORMATION", "PROCESS_VM_READ"],
            mode="SHADOW_NO_INPUT",
            inputCalls=False,
            v1Solver=str((args.v1_root / "pokiguard_auto" / "solver.py").resolve()),
            cvValidation=cv is not None,
            pythonRuntime=sys.executable,
        )
        print(f"Shadow ready (NO INPUT), PID {target.pid}; log: {log_path}")
        print("Keep V1 running as the only controller. Shadow is waiting in lobby.", flush=True)
        try:
            while target.is_running():
                if args.timeout and time.monotonic() - started >= args.timeout:
                    _write(log, "shadow_timeout")
                    break
                # Retained only as an independent audit sample. Memory still
                # constructs/publishes its state through every production gate.
                pre_poll_observation = (
                    cv.observe()
                    if cv is not None
                    and provider.current_board_instance is not None
                    else None
                )
                poll_started = time.monotonic()
                result = provider.poll()
                poll_elapsed_ms = round((time.monotonic() - poll_started) * 1000, 3)
                crosscheck = result.render_crosscheck
                provider_signature = (
                    result.reason,
                    result.confirmations,
                    crosscheck.matches if crosscheck is not None else None,
                    len(crosscheck.missing) if crosscheck is not None else None,
                    len(crosscheck.ambiguous) if crosscheck is not None else None,
                    len(crosscheck.mismatches) if crosscheck is not None else None,
                    provider.scan_diagnostics["lastScanWasFull"],
                )
                if provider_signature != previous_provider_signature:
                    _write(
                        log,
                        "provider_status",
                        reason=result.reason,
                        confirmations=result.confirmations,
                        pollElapsedMs=poll_elapsed_ms,
                        renderCrosscheck=crosscheck,
                        scan=provider.scan_diagnostics,
                    )
                    previous_provider_signature = provider_signature
                if result.lifecycle_event is not None:
                    _write(
                        log,
                        "lifecycle",
                        transition=result.lifecycle_event,
                        reason=result.reason,
                    )
                    if result.lifecycle_event == "board_found":
                        saw_combat = True
                        session = V1ShadowSession()
                    elif result.lifecycle_event == "board_lost" and saw_combat:
                        completed_matches += 1
                        previous_cards = ()
                        previous_fusion = None
                        match_target_met = (
                            args.matches == 0 or completed_matches >= args.matches
                        )
                        comparison_target_met = (
                            comparison_totals["boardsCompared"]
                            >= args.min_comparisons
                        )
                        if match_target_met and comparison_target_met:
                            break

                cards = provider.observed_cards
                fusion = provider.observed_fusion
                if result.cards_changed and cards != previous_cards:
                    _write(
                        log,
                        "card_transition",
                        board=hex_pointer(provider.current_board_instance),
                        before=previous_cards,
                        after=cards,
                    )
                    previous_cards = cards
                if result.fusion_changed and fusion != previous_fusion:
                    _write(
                        log,
                        "fusion_transition",
                        board=hex_pointer(provider.current_board_instance),
                        before=previous_fusion,
                        after=fusion,
                    )
                    previous_fusion = fusion

                state = result.state
                if state is None or state.phase is not GamePhase.COMBAT or not result.publish:
                    time.sleep(args.scan_interval)
                    continue
                observation = None
                live_comparison = None
                cv_attempts: list[Any] = []
                cv_attempt_timings: list[str] = []
                if cv is not None:
                    observed_attempts: list[tuple[Any, Any]] = []
                    if pre_poll_observation is not None:
                        pre_comparison = cv.compare(state, pre_poll_observation)
                        observed_attempts.append(
                            (pre_poll_observation, pre_comparison)
                        )
                        cv_attempts.append(pre_comparison)
                        cv_attempt_timings.append("pre_memory_poll")
                    for attempt in range(args.cv_attempts):
                        candidate_observation = cv.observe()
                        candidate_comparison = cv.compare(
                            state, candidate_observation
                        )
                        observed_attempts.append(
                            (candidate_observation, candidate_comparison)
                        )
                        cv_attempts.append(candidate_comparison)
                        cv_attempt_timings.append(
                            f"post_memory_poll_{attempt + 1}"
                        )
                        if candidate_comparison.accepted:
                            break
                        if attempt + 1 < args.cv_attempts:
                            time.sleep(0.05)
                    observation, live_comparison = min(
                        observed_attempts,
                        key=lambda item: (
                            not item[1].accepted,
                            item[1].cells_compared == 0,
                            len(item[1].gem_mismatches)
                            + len(item[1].multiplier_mismatches),
                            item[1].unknowns,
                        ),
                    )
                comparison = live_comparison
                if (
                    cv is not None
                    and comparison is not None
                    and comparison.cells_compared == 0
                ):
                    debug_comparison = cv.compare_debug_snapshot(
                        state, since_ns=debug_since_ns
                    )
                    if debug_comparison is not None:
                        comparison = debug_comparison
                hints = (
                    cv.context_hints(observation)
                    if cv is not None
                    else V1ContextHints()
                )
                if comparison is not None:
                    comparison_totals["unknowns"] += comparison.unknowns
                    if comparison.cells_compared:
                        comparison_totals["boardsCompared"] += 1
                        comparison_totals["cellsCompared"] += comparison.cells_compared
                        comparison_totals["gemMatches"] += comparison.gem_matches
                        comparison_totals["gemMismatches"] += len(
                            comparison.gem_mismatches
                        )
                        comparison_totals["multiplierCompared"] += (
                            comparison.multiplier_compared
                        )
                        comparison_totals["multiplierMatches"] += (
                            comparison.multiplier_matches
                        )
                        comparison_totals["multiplierMismatches"] += len(
                            comparison.multiplier_mismatches
                        )
                decision = adapter.decide(state, hints=hints, session=session)
                decision_count += 1
                _write(
                    log,
                    "shadow_decision",
                    boardInstance=hex_pointer(state.battle.board_instance),
                    srvSeq=state.battle.srv_seq,
                    turn=state.battle.turn_number,
                    currentTurnPlayer=state.battle.current_turn_player,
                    boardHash=state.battle.board_hash,
                    boardSource=list(state.battle.sources),
                    sourceTimestamp=state.timestamp,
                    stable=state.battle.stable,
                    cells=_cells(state),
                    player=state.player,
                    participants=state.participants,
                    cards=state.cards,
                    fusion=state.fusion,
                    solverDecision=decision,
                    cvComparison=comparison,
                    liveCvComparison=(
                        live_comparison
                        if comparison is not live_comparison
                        else None
                    ),
                    cvAttempts=cv_attempts,
                    cvAttemptTimings=cv_attempt_timings,
                )
                first = decision.first
                second = decision.second
                move_label = (
                    f"r{first[0]}c{first[1]}<->r{second[0]}c{second[1]}"
                    if first is not None and second is not None
                    else decision.solver_action
                )
                print(
                    f"SHADOW seq={state.battle.srv_seq} turn={state.battle.turn_number} "
                    f"would={move_label} score={decision.score}",
                    flush=True,
                )
                if args.max_decisions and decision_count >= args.max_decisions:
                    break
                time.sleep(args.scan_interval)
        finally:
            if cv is not None:
                cv.close()
            _write(
                log,
                "shadow_summary",
                decisions=decision_count,
                sawCombat=saw_combat,
                completedMatches=completed_matches,
                providerMetrics=provider.metrics,
                comparisons=comparison_totals,
                noInput=True,
            )
        print(
            f"Shadow stopped: decisions={decision_count}, "
            f"CV boards={comparison_totals['boardsCompared']}; log: {log_path}",
            flush=True,
        )
        return 0 if decision_count else 2


def main(argv: Sequence[str] | None = None) -> int:
    try:
        return run(build_parser().parse_args(argv))
    except KeyboardInterrupt:
        print("Shadow stopped by user.")
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
