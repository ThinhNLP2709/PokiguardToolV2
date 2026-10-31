"""Desktop current-match runner. Same BASIC solver/executor, no boss-lobby flow."""
from __future__ import annotations

from dataclasses import replace
import json
from pathlib import Path
import time

from pokiguard_v2.basic_policy import PlayStyle
from pokiguard_v2.combat_lifecycle import CombatLifecycleState
from pokiguard_v2.dinosaur_session import DinosaurCombatRun, completed_dinosaur_win_summary
from pokiguard_v2.farm_run import (
    FarmRunArtifactWriter, FarmRunGameplayCapability, FarmRunStopReason,
)
from pokiguard_v2.input_delivery import InputDeliveryConfig
from pokiguard_v2.reasoning_settings import AIStatus
from tools import basic_auto_bot
from tools.farm_run import (
    _ContextualFarmHotkeys, _merge_combat_safety, _notify_combat_turn_progress,
    _notify_run_observer, _read_jsonl, _terminal_snapshot_from_summary,
    _validate_combat_summary,
)
from tools.runtime_common import attach_target


def combat_args(config, log_path: Path, reset_evidence: Path):
    argv = [
        "--watch", "--play-style", PlayStyle.DINOSAUR.value,
        "--main-pet", config.main_pet.value,
        "--evolution-target", config.evolution.value,
        "--damage-card", config.damage_card.value,
        "--audition-mode", config.audition_mode.value,
        "--board-input-mode", config.board_input_mode.value,
        "--input-delivery-mode", config.input_delivery_mode.value,
        "--mana-priority", "evolution" if config.evolution.value != "none" else "attack",
        "--cast-when-boss-hp-below", str(config.cast_when_boss_hp_below),
        "--cast-mana-stockpile", str(config.cast_mana_stockpile),
        "--rage-target", str(config.rage_target),
        "--pet-skill-fire-condition", config.pet_skill_fire_condition.value,
        "--pass-acceptance-stage", "B3", "--reset-evidence", str(reset_evidence),
        "--postmatch-observation-timeout", "1", "--max-total-input-actions", "0",
        "--input-randomization", json.dumps(config.input_randomization.to_dict()),
        "--log", str(log_path),
    ]
    if config.pet_skill_fire_value is not None:
        argv += ["--pet-skill-fire-value", str(config.pet_skill_fire_value)]
    if not config.tool_sound_enabled:
        argv.append("--no-beep")
    return basic_auto_bot.build_parser().parse_args(argv)


def wait_current_board(run, process, provider, hotkeys, writer, *, timeout=None,
                       interval=0.1, observer=None):
    """Wait for a current, stable board even if the opening expires meanwhile."""
    deadline = None if timeout is None else time.monotonic() + timeout
    last_reason = None
    while process.is_running() and not run.stopped:
        _graceful, emergency = hotkeys.poll()
        if emergency or hotkeys.emergency_requested:
            run.safe_stop(FarmRunStopReason.EMERGENCY_STOP)
            return None
        if run.graceful_stop_requested():
            run.safe_stop(FarmRunStopReason.STOPPED_GRACEFULLY)
            return None
        poll = provider.poll()
        observation = poll.combat_lifecycle
        if observation is not None:
            match_id = observation.signals.match_id
            if match_id and match_id != run.expected_match_id:
                run.safe_stop(FarmRunStopReason.SESSION_REUSE_AMBIGUOUS,
                              detail="CURRENT_COMBAT_CHANGED_BEFORE_ATTACH")
                return None
            if observation.state in {
                CombatLifecycleState.LOBBY, CombatLifecycleState.STALE_SERVER_MATCH,
                CombatLifecycleState.LEAVING, CombatLifecycleState.POSTMATCH,
            }:
                run.safe_stop(FarmRunStopReason.FARM_START_STATE_INVALID,
                              detail="CURRENT_COMBAT_ENDED_BEFORE_ATTACH")
                return None
        state = poll.state
        if state is not None and state.battle.session_key is not None and state.board is not None:
            if run.adopt(state, confirmations=poll.confirmations):
                _notify_run_observer(observer, run, "DINOSAUR_CURRENT_COMBAT_READY")
                return state.battle.session_key
            return None
        if poll.reason != last_reason:
            writer.event("dinosaur_current_board_wait", reason=poll.reason,
                         confirmations=poll.confirmations)
            last_reason = poll.reason
        if deadline is not None and time.monotonic() >= deadline:
            run.safe_stop(FarmRunStopReason.OPENING_INVARIANT_FAILED,
                          detail="DINOSAUR_CURRENT_BOARD_TIMEOUT")
            return None
        time.sleep(interval)
    if not run.stopped:
        run.safe_stop(FarmRunStopReason.COMBAT_SAFE_STOP, detail="TARGET_PROCESS_EXITED")
    return None


def run(config, *, expected_match_id, expected_pid, reset_evidence, artifacts_root,
        control_edges, observer=None) -> int:
    ledger = DinosaurCombatRun(config, expected_match_id=expected_match_id)
    writer = FarmRunArtifactWriter.create(Path(artifacts_root), ledger.farm_run_id)
    hotkeys = _ContextualFarmHotkeys(control_edges, lambda: ledger)
    _notify_run_observer(observer, ledger, "DINOSAUR_CREATED")
    if config.ai.shadow_enabled and observer is not None:
        try:
            observer(AIStatus("UNSUPPORTED", "DINOSAUR_BASIC_ONLY", observation=1), "AI_STATUS")
        except Exception:
            pass
    writer.event("dinosaur_current_combat_start", expectedMatchId=expected_match_id,
                 expectedPid=expected_pid, gameplayConfig=config.gameplay_config,
                 bossLobbyRequired=False, checkpointSupported=False)
    error = None
    try:
        with attach_target() as target:
            if expected_pid is None or target.pid != expected_pid:
                raise RuntimeError("DINOSAUR_GAME_PROCESS_CHANGED")
            args = combat_args(config, writer.directory / "matches" / "attempt_001" /
                               "combat.jsonl", Path(reset_evidence))
            basic_auto_bot._validate_args(args)
            runtime = basic_auto_bot._create_shared_combat_runtime(
                target, args, basic_auto_bot.production_input_calibration())
            session = wait_current_board(ledger, target, runtime.provider, hotkeys,
                                         writer, observer=observer)
            if session is not None:
                if not runtime.monitor.begin_session(session, session.match_id, clean=False):
                    raise RuntimeError("DINOSAUR_MONITOR_SESSION_REJECTED")
                runtime = replace(
                    runtime, expected_session=session,
                    gameplay_capability=FarmRunGameplayCapability(ledger, session, hotkeys),
                    farm_control_hotkeys=hotkeys,
                    require_attack_card=config.damage_card.value == "default_attack",
                    input_delivery_config=InputDeliveryConfig(config.input_delivery_mode),
                    turn_progress_observer=lambda role, key, turn, local, boss:
                        _notify_combat_turn_progress(observer, ledger, role, key, turn, local, boss),
                )
                basic_auto_bot.run(args, shared_runtime=runtime)
                records = _read_jsonl(args.log)
                normal, reason, summary = _validate_combat_summary(records)
                if summary is not None and summary.get('stopReason') == 'DINOSAUR_WIN_CONFIRMED':
                    terminal = _terminal_snapshot_from_summary(summary, session)
                    normal = completed_dinosaur_win_summary(summary, terminal, session)
                    reason = 'DINOSAUR_WIN_CONFIRMED' if normal else 'DINOSAUR_WIN_SUMMARY_INVALID'
                ledger.apply_combat_summary(summary or {})
                _merge_combat_safety(ledger, summary)
                writer.event("dinosaur_combat_controller_returned", normal=normal,
                             reason=reason, summary=summary)
                if normal:
                    ledger.finish_current_combat(_terminal_snapshot_from_summary(summary, session))
                else:
                    emergency = control_edges.emergency_requested or reason == "EMERGENCY_STOP"
                    ledger.safe_stop(FarmRunStopReason.EMERGENCY_STOP if emergency
                                     else FarmRunStopReason.COMBAT_SAFE_STOP, detail=reason)
    except Exception as exc:
        error = f"{type(exc).__name__}: {exc}"
        ledger.safe_stop(FarmRunStopReason.COMBAT_SAFE_STOP, detail=error)
        writer.event("dinosaur_controller_error", error=error)
    finally:
        writer.finalize(ledger, mode="DINOSAUR_CURRENT_COMBAT", error=error,
                        checkpointSupported=False, automaticReentry=False)
        _notify_run_observer(observer, ledger, "DINOSAUR_STOPPED")
    return 0 if error is None else 1
