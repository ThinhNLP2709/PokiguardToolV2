from __future__ import annotations

from contextlib import nullcontext
from dataclasses import asdict, replace
import json
from pathlib import Path
import tempfile
from types import SimpleNamespace
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.basic_policy import BasicPolicyEngine, PlayStyle, PolicyConfig
from pokiguard_v2.combat_lifecycle import CombatLifecycleState
from pokiguard_v2.desktop_control_plane import DesktopConfig, DesktopControlPlane, RuntimeObservation
from pokiguard_v2.desktop_farm_controller import ControllerLaunch, DesktopFarmControllerManager
from pokiguard_v2.desktop_preferences import DesktopPreferenceStore
from pokiguard_v2.dinosaur_session import (
    DinosaurCombatRun, missed_opening_can_wait, confirmed_dinosaur_win,
    completed_dinosaur_win_summary,
)
from pokiguard_v2.farm_run import FarmInputDomain, FarmRunState, FarmRunStopReason
from pokiguard_v2.memory_board_provider import (
    MemoryBoardStateProvider, MemoryProviderConfig, ProviderPoll, ProviderSetupError,
)
from pokiguard_v2.pet_configuration import PLAY_STYLE_LABELS
from pokiguard_v2.state import CombatSessionKey, TerminalCombatSnapshot, TerminalResult, TerminalResultConfidence
from tests.test_actionability import actionable_state
from tests.test_basic_policy import combat_state, attack_card
from tests.test_board_simulator import cyclic_board, fixture_board, reported_seq40_board, reported_seq69_board
from tools import basic_auto_bot, dinosaur_run


def config(**changes):
    return replace(DesktopConfig(play_style=PlayStyle.DINOSAUR), **changes)


class DinosaurPolicyTests(unittest.TestCase):
    def test_exact_simple_decision_parity_across_boards_resources_and_evolution(self):
        for board in (cyclic_board(), fixture_board(), reported_seq40_board(), reported_seq69_board()):
            for mana, rage, used, hp in ((0, 0, True, 39602), (241, 95, True, 15000),
                                        (500, 150, True, 50000), (250, 100, False, 39602)):
                state = combat_state(board=board, mana=mana, rage=rage, fusion_used=used,
                                     boss_hp=hp, cards=(attack_card(),))
                simple = BasicPolicyEngine(PolicyConfig(play_style=PlayStyle.SIMPLE)).decide(state)
                dino = BasicPolicyEngine(PolicyConfig(play_style=PlayStyle.DINOSAUR)).decide(state)
                self.assertEqual(simple, replace(dino, trace=replace(dino.trace, play_style="simple")))

    def test_label_and_preferences_roundtrip(self):
        self.assertEqual(PLAY_STYLE_LABELS[PlayStyle.DINOSAUR], "Khủng long")
        with tempfile.TemporaryDirectory() as directory:
            store = DesktopPreferenceStore(Path(directory) / "preferences.json")
            selected = config()
            store.save(selected)
            loaded = store.load()
            self.assertTrue(loaded.loaded)
            self.assertEqual(loaded.config, selected)

    def test_any_unsent_dinosaur_turn_can_wait_for_the_next_turn(self):
        fields = dict(play_style="dinosaur", turn=1, local_move_sequence=0,
                      sent_consuming_inputs=0, pending=None, mandatory_reset=False)
        self.assertTrue(missed_opening_can_wait(**fields))
        self.assertTrue(missed_opening_can_wait(**{**fields, "local_move_sequence": 1}))
        self.assertTrue(missed_opening_can_wait(**{**fields, "turn":33,
            "local_move_sequence":9,"sent_consuming_inputs":9,"mandatory_reset":True}))
        for change in (dict(play_style="simple"), dict(play_style="careful"),
                       dict(turn=-1), dict(turn=None), dict(local_move_sequence=None),
                       dict(local_move_sequence=-1), dict(pending=object())):
            with self.subTest(change=change):
                self.assertFalse(missed_opening_can_wait(**{**fields, **change}))

    def test_real_controller_missed_opening_then_sends_second_turn(self):
        from tests.reasoning_controller_fixture import controller_trace
        with tempfile.TemporaryDirectory() as directory:
            result, calls, rows = controller_trace(Path(directory) / "combat.jsonl",
                profile="dinosaur", case="dinosaur_opening_missed")
        self.assertEqual(result, 0)
        missed = [r for r in rows if r["event"] == "dinosaur_missed_turn_wait_next_turn"]
        self.assertEqual(len(missed), 1)
        self.assertEqual(missed[0]["turn"], 1)
        self.assertFalse(missed[0]["inputSent"])
        self.assertEqual(calls.count("FAKE_NORMAL_INPUT"), 1)
        summary = next(r for r in rows if r["event"] == "auto_controller_summary")
        self.assertEqual(summary["localTurnDeadlineSafeStops"], 0)
        sent = [r for r in rows if r["event"] == "action_sent"]
        self.assertTrue(sent)
        self.assertEqual(sent[0]["identity"]["source"]["turn"], 3)

    def test_real_controller_simple_still_stops_at_missed_opening(self):
        from tests.reasoning_controller_fixture import controller_trace
        with tempfile.TemporaryDirectory() as directory:
            _, calls, rows = controller_trace(Path(directory) / "combat.jsonl",
                profile="simple", case="dinosaur_opening_missed")
        self.assertNotIn("FAKE_NORMAL_INPUT", calls)
        self.assertFalse(any(r["event"] == "dinosaur_missed_turn_wait_next_turn" for r in rows))
        self.assertTrue(any(r["event"] == "auto_pause" and
                            r.get("reason") == "LOCAL_TURN_ACTION_DEADLINE" for r in rows))

    def test_real_controller_sends_first_turn_when_ready(self):
        from tests.reasoning_controller_fixture import controller_trace
        with tempfile.TemporaryDirectory() as directory:
            _, calls, rows = controller_trace(Path(directory) / "combat.jsonl",
                profile="dinosaur", case="dinosaur_opening_ready")
        self.assertEqual(calls.count("FAKE_NORMAL_INPUT"), 1)
        sent = next(r for r in rows if r["event"] == "action_sent")
        self.assertEqual(sent["identity"]["source"]["turn"], 1)
        self.assertFalse(any(r["event"] == "dinosaur_missed_turn_wait_next_turn" for r in rows))


class DinosaurAdmissionTests(unittest.TestCase):
    def test_current_match_adoption_needs_no_entry_and_allows_second_turn(self):
        state = actionable_state()
        ledger = DinosaurCombatRun(config(), expected_match_id=state.battle.match_id)
        self.assertTrue(ledger.adopt(state, confirmations=2))
        self.assertEqual(ledger.state, FarmRunState.COMBAT_ACTIVE)
        self.assertEqual(ledger.match_attempts, 1)
        self.assertEqual(ledger.snapshot().total_lobby_inputs, 0)
        permit = ledger.reserve_gameplay(FarmInputDomain.GAMEPLAY_SWAP,
                                        state.battle.session_key, foreground=True)
        self.assertIsNotNone(permit)
        self.assertTrue(ledger.complete_gameplay(permit, sent=True))
        self.assertEqual(ledger.snapshot().total_gameplay_inputs, 1)

    def test_adoption_rejects_wrong_match_unstable_or_terminal(self):
        state = actionable_state()
        for expected, confirmations, battle in (
            ("other-match", 2, state.battle),
            (state.battle.match_id, 1, state.battle),
            (state.battle.match_id, 2, replace(state.battle, match_over=True)),
            (state.battle.match_id, 2, replace(state.battle, board_is_game_over=True)),
        ):
            with self.subTest(expected=expected, confirmations=confirmations, battle=battle):
                ledger = DinosaurCombatRun(config(), expected_match_id=expected)
                self.assertFalse(ledger.adopt(replace(state, battle=battle), confirmations=confirmations))
                self.assertEqual(ledger.snapshot().total_gameplay_inputs, 0)
                self.assertTrue(ledger.stopped)

    def test_terminal_finishes_without_boss_lobby_or_reentry(self):
        state = actionable_state()
        ledger = DinosaurCombatRun(config(), expected_match_id=state.battle.match_id)
        ledger.adopt(state, confirmations=2)
        terminal = TerminalCombatSnapshot(
            match_id=state.battle.match_id, session_key=state.battle.session_key,
            lifecycle_epoch=state.battle.session_key.lifecycle_epoch, timestamp="now",
            result=TerminalResult.WIN, confidence=TerminalResultConfidence.STRONG,
            evidence_sources=("MATCH_GAME_OVER",), captured_before_cleanup=True)
        self.assertTrue(ledger.finish_current_combat(terminal))
        self.assertEqual(ledger.completed_matches, 1)
        self.assertEqual(ledger.wins, 1)
        self.assertEqual(ledger.state, FarmRunState.FARM_RUN_COMPLETE)
        self.assertIsNone(ledger.current_session)
        snapshot = ledger.snapshot()
        self.assertEqual(snapshot.total_lobby_inputs + snapshot.total_recovery_inputs +
                         snapshot.total_postmatch_inputs, 0)

    def test_missing_terminal_evidence_never_completes_a_match(self):
        state = actionable_state()
        ledger = DinosaurCombatRun(config(), expected_match_id=state.battle.match_id)
        ledger.adopt(state, confirmations=2)
        terminal = TerminalCombatSnapshot(match_id=state.battle.match_id,
            session_key=state.battle.session_key, lifecycle_epoch=1, timestamp="now",
            evidence_sources=("TERMINAL_SNAPSHOT_MISSING",))
        self.assertFalse(ledger.finish_current_combat(terminal))
        self.assertEqual(ledger.completed_matches, 0)

    def test_graceful_stop_drains_current_combat_without_entry(self):
        state = actionable_state()
        ledger = DinosaurCombatRun(config(), expected_match_id=state.battle.match_id)
        ledger.adopt(state, confirmations=2)
        self.assertTrue(ledger.graceful_stop_request(lifecycle="ACTIVE_COMBAT",
                                                     match_id=state.battle.match_id))
        self.assertFalse(ledger.stopped)
        terminal = TerminalCombatSnapshot(match_id=state.battle.match_id,
            session_key=state.battle.session_key, lifecycle_epoch=1, timestamp="now",
            result=TerminalResult.WIN, confidence=TerminalResultConfidence.STRONG,
            evidence_sources=("MATCH_GAME_OVER",), captured_before_cleanup=True)
        self.assertTrue(ledger.finish_current_combat(terminal))
        self.assertEqual(ledger.stop_reason, FarmRunStopReason.STOPPED_GRACEFULLY)

    def test_ui_projection_shows_failure_detail_without_boss_checkpoint(self):
        ledger = DinosaurCombatRun(config(), expected_match_id="M")
        ledger.safe_stop(FarmRunStopReason.COMBAT_SAFE_STOP, detail="DINOSAUR_CURRENT_BOARD_TIMEOUT")
        with tempfile.TemporaryDirectory() as directory:
            manager = DesktopFarmControllerManager(Path(directory), runner=Mock())
            manager._observe(0, ledger.snapshot(), "DINOSAUR_STOPPED")
            snapshot = manager.snapshot()
            self.assertIsNone(snapshot.checkpoint_path)
            self.assertEqual(snapshot.last_stop_detail, "DINOSAUR_CURRENT_BOARD_TIMEOUT")

    def test_provider_active_start_is_explicit_and_does_not_scan_fake_lobby(self):
        target = SimpleNamespace(resolver=SimpleNamespace(resolve_type_info_class=lambda _: None))
        with patch.object(MemoryBoardStateProvider, "_resolve_board", return_value=object()), \
             patch.object(MemoryBoardStateProvider, "_refresh_lobby_baseline") as baseline:
            with self.assertRaises(ProviderSetupError):
                MemoryBoardStateProvider(target)
            ordinary_status = MemoryBoardStateProvider(target, MemoryProviderConfig(require_lobby_start=False))
            self.assertFalse(ordinary_status.scan_diagnostics["lobbyBaselineReady"])
            explicit = MemoryBoardStateProvider(target, MemoryProviderConfig(
                require_lobby_start=False, active_combat_start=True))
            self.assertTrue(explicit.scan_diagnostics["lobbyBaselineReady"])
            baseline.assert_not_called()
        with self.assertRaises(ValueError):
            MemoryProviderConfig(active_combat_start=True)

    def test_start_button_pins_current_match_and_discards_old_boss_target(self):
        with tempfile.TemporaryDirectory() as directory:
            root = Path(directory)
            reset = root / "reset.json"
            reset.write_text("{}", encoding="utf-8")
            launches = []
            manager = DesktopFarmControllerManager(root, reset_evidence=reset,
                runner=lambda launch, *_: launches.append(launch) or 0)
            runtime = SimpleNamespace(read=lambda: RuntimeObservation(
                True, True, 123, "x64", "ACTIVE_COMBAT", match_id="DINO-current"), close=lambda: None)
            plane = DesktopControlPlane(runtime, controller=manager,
                config=config(boss_id="1436", boss_name="Lieyun", target_completed_matches=200,
                              max_match_attempts=205))
            self.assertTrue(plane.refresh().controls.start.actionable)
            self.assertTrue(plane.start_farm().accepted)
            self.assertTrue(manager.wait(2))
            self.assertEqual(len(launches), 1)
            launch = launches[0]
            self.assertEqual(launch.expected_match_id, "DINO-current")
            self.assertIsNone(launch.config.normalized_boss_id)
            self.assertIsNone(launch.config.normalized_boss_name)
            self.assertEqual(launch.config.target_completed_matches, 1)
            self.assertEqual(launch.config.max_match_attempts, 1)
            plane.close()

    def test_active_combat_start_is_not_enabled_for_simple_or_from_lobby(self):
        for style, lifecycle, match_id in ((PlayStyle.SIMPLE, "ACTIVE_COMBAT", "M"),
                                         (PlayStyle.DINOSAUR, "BOSS_LOBBY", "M"),
                                         (PlayStyle.DINOSAUR, "ACTIVE_COMBAT", None)):
            with tempfile.TemporaryDirectory() as directory:
                reset = Path(directory) / "reset.json"
                reset.write_text("{}", encoding="utf-8")
                manager = DesktopFarmControllerManager(Path(directory), reset_evidence=reset, runner=Mock())
                runtime = SimpleNamespace(read=lambda: RuntimeObservation(
                    True, True, 123, "x64", lifecycle, match_id=match_id), close=lambda: None)
                plane = DesktopControlPlane(runtime, controller=manager, config=config(play_style=style))
                self.assertFalse(plane.refresh().controls.start.actionable)
                self.assertFalse(plane.start_farm().accepted)
                plane.close()

    def test_no_checkpoint_resume_or_unpinned_manager_start(self):
        cfg = config(target_completed_matches=1, max_match_attempts=1)
        with self.assertRaises(ValueError):
            DesktopFarmControllerManager._validate_launch(ControllerLaunch(cfg, None))
        with self.assertRaises(ValueError):
            DesktopFarmControllerManager._validate_launch(ControllerLaunch(cfg, Path("checkpoint.json"),
                expected_match_id="M"))

    def test_production_routes_dinosaur_to_current_match_runner(self):
        with tempfile.TemporaryDirectory() as directory:
            manager = DesktopFarmControllerManager(Path(directory), runner=Mock())
            launch = ControllerLaunch(config(target_completed_matches=1, max_match_attempts=1),
                                      None, 123, "DINO-current")
            with patch.object(dinosaur_run, "run", return_value=0) as run:
                self.assertEqual(manager._run_production(launch, Mock(), Mock()), 0)
                self.assertEqual(run.call_args.kwargs["expected_match_id"], "DINO-current")
                self.assertEqual(run.call_args.kwargs["expected_pid"], 123)

    def test_runtime_factory_only_dinosaur_opt_in_to_midcombat_provider(self):
        for style, active in ((PlayStyle.DINOSAUR, True), (PlayStyle.SIMPLE, False)):
            args = dinosaur_run.combat_args(config(play_style=style), Path("unused"), Path("reset"))
            args.play_style = style.value
            with patch.object(basic_auto_bot, "NativeWin32Backend"), \
                 patch.object(basic_auto_bot, "find_window_for_pid"), \
                 patch.object(basic_auto_bot, "ForegroundClickExecutor"), \
                 patch.object(basic_auto_bot, "RuntimeSequenceMonitor"), \
                 patch.object(basic_auto_bot, "MemoryBoardStateProvider") as provider:
                basic_auto_bot._create_shared_combat_runtime(SimpleNamespace(pid=123), args, {})
            cfg = provider.call_args.args[1]
            self.assertEqual(cfg.active_combat_start, active)
            self.assertEqual(cfg.require_lobby_start, not active)

    def test_wait_current_board_can_cross_missed_opening_without_stopping(self):
        state = actionable_state()
        ledger = DinosaurCombatRun(config(), expected_match_id=state.battle.match_id)
        provider = SimpleNamespace(poll=Mock(side_effect=[
            ProviderPoll(None, False, "await_current_board"),
            ProviderPoll(state, True, "current_board", confirmations=2)]))
        hotkeys = SimpleNamespace(poll=lambda: (False, False), emergency_requested=False)
        with patch.object(dinosaur_run.time, "sleep"):
            session = dinosaur_run.wait_current_board(ledger, SimpleNamespace(is_running=lambda: True),
                                                      provider, hotkeys, Mock())
        self.assertEqual(session, state.battle.session_key)
        self.assertEqual(ledger.state, FarmRunState.COMBAT_ACTIVE)
        self.assertEqual(ledger.snapshot().total_lobby_inputs, 0)

    def test_emergency_during_startup_never_reads_or_sends_input(self):
        ledger = DinosaurCombatRun(config(), expected_match_id="M")
        provider = Mock()
        result = dinosaur_run.wait_current_board(ledger, SimpleNamespace(is_running=lambda: True),
            provider, SimpleNamespace(poll=lambda: (False, True), emergency_requested=True), Mock())
        self.assertIsNone(result)
        self.assertEqual(ledger.stop_reason, FarmRunStopReason.EMERGENCY_STOP)
        provider.poll.assert_not_called()

    def test_changed_match_during_startup_does_not_attach(self):
        ledger = DinosaurCombatRun(config(), expected_match_id="expected")
        observation = SimpleNamespace(state=CombatLifecycleState.ACTIVE,
                                      signals=SimpleNamespace(match_id="different"))
        provider = SimpleNamespace(poll=lambda: ProviderPoll(None, False, "changed",
                                                            combat_lifecycle=observation))
        hotkeys = SimpleNamespace(poll=lambda: (False, False), emergency_requested=False)
        result = dinosaur_run.wait_current_board(ledger, SimpleNamespace(is_running=lambda: True),
                                                 provider, hotkeys, Mock())
        self.assertIsNone(result)
        self.assertEqual(ledger.match_attempts, 0)
        self.assertEqual(ledger.stop_reason, FarmRunStopReason.SESSION_REUSE_AMBIGUOUS)

    def test_complete_runner_writes_one_match_without_entry_reward_or_checkpoint(self):
        state = actionable_state()
        session = state.battle.session_key
        target = SimpleNamespace(pid=123, is_running=lambda: True)
        provider = SimpleNamespace(poll=lambda: ProviderPoll(state, True, "ready", confirmations=2))
        monitor = SimpleNamespace(begin_session=Mock(return_value=True))
        runtime = basic_auto_bot.SharedCombatRuntime(target, provider, monitor,
                                                     Mock(), Mock(), Mock())
        edges = SimpleNamespace(poll=lambda: (False, False), emergency_requested=False,
                                execute_if_authorized=lambda operation: (True, operation()))
        terminal = TerminalCombatSnapshot(
            match_id=session.match_id, session_key=session,
            lifecycle_epoch=session.lifecycle_epoch, timestamp="now", result=TerminalResult.WIN,
            confidence=TerminalResultConfidence.STRONG, evidence_sources=("MATCH_GAME_OVER",),
            captured_before_cleanup=True)
        def combat(args, *, shared_runtime):
            self.assertEqual(shared_runtime.expected_session, session)
            self.assertIsNone(shared_runtime.technical_recovery_dispatcher)
            permit = shared_runtime.gameplay_capability.reserve(action="SWAP", session=session, foreground=True)
            self.assertIsNotNone(permit)
            shared_runtime.gameplay_capability.complete(permit, sent=True)
            rows = [dict(event="auto_controller_summary", stopReason="COMBAT_LIFECYCLE_ENDED",
                attemptClassification="FULL_COMBAT_COMPLETED", fullCombatResult="WIN",
                terminalCombatSnapshot=asdict(terminal), sessionCleared=True, activeSession=None,
                pending=None, safetyTelemetry={"wrongTurn": 0}, counters={"swap_sent": 1}),
                dict(event="postmatch_observation_complete", automaticInputDisabled=True)]
            args.log.parent.mkdir(parents=True, exist_ok=True)
            args.log.write_text("\n".join(json.dumps(r, default=lambda v: v.value) for r in rows), encoding="utf-8")
            return 0
        with tempfile.TemporaryDirectory() as directory:
            snapshots = []
            with patch.object(dinosaur_run, "attach_target", return_value=nullcontext(target)), \
                 patch.object(basic_auto_bot, "_create_shared_combat_runtime", return_value=runtime), \
                 patch.object(basic_auto_bot, "run", side_effect=combat):
                code = dinosaur_run.run(config(), expected_match_id=session.match_id, expected_pid=123,
                    reset_evidence=Path("unused"), artifacts_root=Path(directory), control_edges=edges,
                    observer=lambda snap, phase: snapshots.append((snap, phase)))
            self.assertEqual(code, 0)
            final = snapshots[-1][0]
            self.assertEqual(final.completed_matches, 1)
            self.assertEqual(final.total_gameplay_inputs, 1)
            self.assertEqual(final.total_lobby_inputs + final.total_recovery_inputs + final.total_postmatch_inputs, 0)
            self.assertEqual(len(list(Path(directory).rglob("run.json"))), 1)
            self.assertEqual(len(list(Path(directory).rglob("combat.jsonl"))), 1)
            self.assertEqual(list(Path(directory).rglob("checkpoint.json")), [])


class DinosaurCurrentRuleTests(unittest.TestCase):
    def test_until_win_has_no_fixed_input_count_ceiling_for_dinosaur(self):
        args=dinosaur_run.combat_args(config(),Path('unused.log'),Path('unused.json'))
        self.assertEqual(args.max_total_input_actions,0)
        basic_auto_bot._validate_args(args)
        args.play_style='simple'
        with self.assertRaises(ValueError):
            basic_auto_bot._validate_args(args)

    def terminal(self):
        session=actionable_state().battle.session_key
        return TerminalCombatSnapshot(match_id=session.match_id,session_key=session,
            lifecycle_epoch=session.lifecycle_epoch,timestamp='OFFLINE',result=TerminalResult.WIN,
            confidence=TerminalResultConfidence.STRONG,captured_before_cleanup=True,
            evidence_sources=('ChatMessageDTO.MATCH_GAME_OVER',))

    def test_real_controller_missed_later_turn_after_input_waits_then_acts_again(self):
        from tests.reasoning_controller_fixture import controller_trace
        with tempfile.TemporaryDirectory() as name:
            _,calls,rows=controller_trace(Path(name)/'combat.jsonl',profile='dinosaur',case='dinosaur_repeat_missed')
        sent=[r for r in rows if r['event']=='action_sent']
        self.assertEqual([r['turn']for r in sent],[1,5])
        self.assertEqual(calls.count('FAKE_NORMAL_INPUT'),2)
        missed=[r for r in rows if r['event']=='dinosaur_missed_turn_wait_next_turn']
        self.assertEqual([r['turn']for r in missed],[3])
        self.assertFalse(missed[0]['inputSent'])
        self.assertTrue(missed[0]['currentBoardRereadRequired'])
        summary=next(r for r in rows if r['event']=='auto_controller_summary')
        self.assertEqual(summary['localTurnDeadlineSafeStops'],0)

    def test_real_controller_winner_event_stops_while_scene_still_active(self):
        from tests.reasoning_controller_fixture import controller_trace
        with tempfile.TemporaryDirectory() as name:
            _,calls,rows=controller_trace(Path(name)/'combat.jsonl',profile='dinosaur',case='dinosaur_win_event_active')
        self.assertNotIn('FAKE_NORMAL_INPUT',calls)
        self.assertEqual(calls.count('provider.poll'),1)
        summary=next(r for r in rows if r['event']=='auto_controller_summary')
        self.assertEqual(summary['stopReason'],'DINOSAUR_WIN_CONFIRMED')
        self.assertEqual(summary['fullCombatResult'],'WIN')
        self.assertTrue(summary['sessionCleared'])
        self.assertIsNone(summary['activeSession'])
        self.assertFalse(any(r['event'].startswith('postmatch_observation') for r in rows))
        from tools.farm_run import _terminal_snapshot_from_summary
        terminal=_terminal_snapshot_from_summary(summary,actionable_state().battle.session_key)
        self.assertTrue(completed_dinosaur_win_summary(summary,terminal,terminal.session_key))

    def test_win_after_last_input_does_not_fabricate_pending_ack(self):
        from tests.reasoning_controller_fixture import controller_trace
        with tempfile.TemporaryDirectory() as name:
            _,calls,rows=controller_trace(Path(name)/'combat.jsonl',profile='dinosaur',case='dinosaur_win_after_action')
        self.assertEqual(calls.count('FAKE_NORMAL_INPUT'),1)
        summary=next(r for r in rows if r['event']=='auto_controller_summary')
        self.assertEqual(summary['stopReason'],'DINOSAUR_WIN_CONFIRMED')
        self.assertEqual(summary['counters']['swap_acknowledged'],0)
        self.assertIsNone(summary['pending'])
        closed=next(r for r in rows if r['event']=='action_result'and r.get('reason')=='DINOSAUR_WIN_CONFIRMED')
        self.assertFalse(closed['exactActionAckClaimed'])

    def test_fresh_terminal_hp_pair_stops_without_winner_message_or_postmatch(self):
        from tests.reasoning_controller_fixture import controller_trace
        state=combat_state()
        boss=replace(state.opponents[0],is_boss=True,hp=0)
        state=replace(state,opponents=(boss,),participants=(state.player,boss))
        with tempfile.TemporaryDirectory() as name:
            _,calls,rows=controller_trace(Path(name)/'combat.jsonl',profile='dinosaur',initial_combat=state)
        self.assertNotIn('FAKE_NORMAL_INPUT',calls)
        summary=next(r for r in rows if r['event']=='auto_controller_summary')
        self.assertEqual(summary['stopReason'],'DINOSAUR_WIN_CONFIRMED')
        self.assertEqual(summary['terminalCombatSnapshot']['boss_hp'],0)
        self.assertEqual(summary['terminalCombatSnapshot']['confidence'],'STRONG')

    def test_only_a_strong_non_conflicting_win_in_this_session_is_enough(self):
        terminal=self.terminal()
        self.assertTrue(confirmed_dinosaur_win(terminal,terminal.session_key))
        for change in (dict(result=TerminalResult.LOSS),dict(result=TerminalResult.UNKNOWN,confidence=TerminalResultConfidence.PARTIAL),
                       dict(confidence=TerminalResultConfidence.PARTIAL),dict(captured_before_cleanup=False,confidence=TerminalResultConfidence.PARTIAL),
                       dict(evidence_sources=()),dict(evidence_sources=('TERMINAL_MEMORY_CONFLICT',))):
            with self.subTest(change=change):
                self.assertFalse(confirmed_dinosaur_win(replace(terminal,**change),terminal.session_key))
        self.assertFalse(confirmed_dinosaur_win(terminal,CombatSessionKey(99,terminal.session_key.board_instance,'OTHER')))

    def test_early_summary_requires_cleared_session_no_pending_and_zero_safety_faults(self):
        terminal=self.terminal()
        summary=dict(stopReason='DINOSAUR_WIN_CONFIRMED',attemptClassification='DINOSAUR_CURRENT_WIN',
            fullCombatResult='WIN',sessionCleared=True,activeSession=None,pending=None,safetyTelemetry={'wrongTurn':0})
        self.assertTrue(completed_dinosaur_win_summary(summary,terminal,terminal.session_key))
        for change in (dict(sessionCleared=False),dict(activeSession={}),dict(pending={}),
                       dict(safetyTelemetry={'wrongTurn':1}),dict(fullCombatResult='LOSS'),dict(safetyTelemetry=None)):
            with self.subTest(change=change):
                self.assertFalse(completed_dinosaur_win_summary({**summary,**change},terminal,terminal.session_key))

    def test_startup_wait_has_no_default_35_second_stop(self):
        from itertools import count
        state=actionable_state()
        ledger=DinosaurCombatRun(config(),expected_match_id=state.battle.match_id)
        provider=SimpleNamespace(poll=Mock(side_effect=[ProviderPoll(None,False,'not_ready')]*4+
            [ProviderPoll(state,True,'ready',confirmations=2)]))
        with patch.object(dinosaur_run.time,'monotonic',side_effect=count(0,40)), \
             patch.object(dinosaur_run.time,'sleep'):
            result=dinosaur_run.wait_current_board(ledger,SimpleNamespace(is_running=lambda:True),
                provider,SimpleNamespace(poll=lambda:(False,False),emergency_requested=False),Mock())
        self.assertEqual(result,state.battle.session_key)
        self.assertFalse(ledger.stopped)
        self.assertEqual(provider.poll.call_count,5)

    def test_runner_accepts_real_early_win_log_without_postmatch_records(self):
        from tests.reasoning_controller_fixture import controller_trace
        state=actionable_state();session=state.battle.session_key
        with tempfile.TemporaryDirectory() as name:
            root=Path(name)
            _,_,rows=controller_trace(root/'reference.jsonl',profile='dinosaur',case='dinosaur_win_event_active')
            def finish(args,**kwargs):
                args.log.parent.mkdir(parents=True,exist_ok=True)
                args.log.write_text('\n'.join(json.dumps(r)for r in rows),encoding='utf-8')
                return 0
            target=SimpleNamespace(pid=123,is_running=lambda:True)
            runtime=basic_auto_bot.SharedCombatRuntime(target,
                SimpleNamespace(poll=lambda:ProviderPoll(state,True,'ready',confirmations=2)),
                SimpleNamespace(begin_session=lambda *a,**kw:True),Mock(),Mock(),Mock())
            edges=SimpleNamespace(poll=lambda:(False,False),emergency_requested=False)
            snapshots=[]
            with patch.object(dinosaur_run,'attach_target',return_value=nullcontext(target)), \
                 patch.object(basic_auto_bot,'_create_shared_combat_runtime',return_value=runtime), \
                 patch.object(basic_auto_bot,'run',side_effect=finish):
                code=dinosaur_run.run(config(),expected_match_id=session.match_id,expected_pid=123,
                    reset_evidence=Path('unused'),artifacts_root=root/'farm',control_edges=edges,
                    observer=lambda snap,phase:snapshots.append(snap))
            self.assertEqual(code,0)
            self.assertEqual(snapshots[-1].wins,1)
            self.assertEqual(snapshots[-1].completed_matches,1)
            self.assertEqual(snapshots[-1].state,FarmRunState.FARM_RUN_COMPLETE)
            self.assertEqual(snapshots[-1].total_postmatch_inputs,0)
            self.assertEqual(snapshots[-1].total_lobby_inputs,0)


if __name__ == "__main__":
    unittest.main()
