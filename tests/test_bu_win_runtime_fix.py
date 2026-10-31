"""Observed Coop opening regression and bounded postmatch failure evidence."""

from dataclasses import replace
import json
from pathlib import Path
import tempfile
from types import SimpleNamespace
import unittest
from unittest.mock import Mock, patch

from pokiguard_v2.actionability import ActionabilityGate, GateContext, GateReason
from pokiguard_v2.basic_policy import BasicPolicyEngine, PolicyAction
from pokiguard_v2.combat_lifecycle import CombatLifecycleState
from pokiguard_v2.farm_run import FarmRun, FarmRunEntryCapability, FarmRunLimits, FarmRunState, FarmRunStopReason
from pokiguard_v2.boss_entry import BossLobbyState, FarmTarget
from pokiguard_v2.pet_configuration import basic_policy_config
from pokiguard_v2.postmatch_ui import PostmatchControl, PostmatchUiLocation, locate_result_confirm
from pokiguard_v2.state import BattleState, BoardState, CellState, CombatSessionKey, GemType
from pokiguard_v2.win32_screenshot import (
    configure_diagnostic_image_writes, diagnostic_image_writes_enabled,
    read_png_rgb,
)
from pokiguard_v2.win32_input import ClickPointResult, ClickStatus
from pokiguard_v2.foreground_lease_transport import LeaseStatus
from tests.test_basic_policy import combat_state
from tests.test_bu_win import bu_win_config
from tests.test_farm_run import enter, session, start_run, MatchResult
from tests.test_postmatch_ui import current_wide_result_rgb
from tools.boss_entry import _entry_opening_turn_valid
from tools.farm_run import _confirm_postmatch, _run_entry, _save_postmatch_failure_evidence
from pokiguard_v2.farm_cycle import OpeningEvidence


FIXTURE = Path(__file__).parent / "fixtures/bu_win_coop_foreign_opening_20261011.json"


def observed_opening():
    raw = json.loads(FIXTURE.read_text(encoding="utf-8"))
    fields = raw["battle"]
    fields["combat_lifecycle"] = CombatLifecycleState(fields["combat_lifecycle"])
    fields["session_key"] = CombatSessionKey(**fields["session_key"])
    fields["sources"] = tuple(fields["sources"])
    state = replace(combat_state(), battle=BattleState(**fields), board=BoardState(tuple(
        tuple(CellState(row, col, GemType(gem), multiplier)
              for col, (gem, multiplier) in enumerate(values))
        for row, values in enumerate(raw["cells"])
    )))
    battle = state.battle
    evidence = OpeningEvidence(
        session=battle.session_key, match_id=battle.match_id,
        board_hash=battle.board_hash, complete_cells=64, unique_coordinates=64,
        source=battle.sources[0], first_local_turn=battle.is_first_local_turn,
        local_move_sequence=battle.local_move_sequence, stable_confirmations=2,
        is_local_turn=battle.is_local_turn, turn_number=battle.turn_number,
    )
    return state, evidence


def waiting_run(key, *, coop=True):
    run = FarmRun(FarmTarget(boss_id="2534"), gameplay_config=bu_win_config() if coop else None)
    assert run.observe_initial_lobby(BossLobbyState.BOSS_LOBBY)
    assert run.target_resolved()
    capability = FarmRunEntryCapability(run)
    permit = capability.reserve(foreground=True)
    assert capability.complete(permit, sent=True, detail="OFFLINE_READY")
    assert run.accept_session(key)
    return run


class CoopForeignOpeningRegressionTests(unittest.TestCase):
    def test_observed_foreign_first_turn_admits_coop_but_never_moves(self):
        state, evidence = observed_opening()
        self.assertFalse(evidence.valid())
        self.assertTrue(_entry_opening_turn_valid(state, coop_mode=True))
        run = waiting_run(evidence.session)
        self.assertTrue(run.accept_opening(evidence))
        self.assertIs(run.state, FarmRunState.COMBAT_ACTIVE)
        self.assertFalse(evidence.first_local_turn)
        engine = BasicPolicyEngine(basic_policy_config(bu_win_config()))
        self.assertIs(engine.decide(state).action, PolicyAction.NONE)
        gate = ActionabilityGate.evaluate(state, GateContext(evidence.session, True, True))
        self.assertFalse(gate.actionable)
        self.assertIs(gate.reason, GateReason.BOARD_NOT_MOVE_STATE)
        move_ready = replace(state, battle=replace(state.battle, board_current_state=1))
        self.assertIs(ActionabilityGate.evaluate(
            move_ready, GateContext(evidence.session, True, True),
        ).reason, GateReason.NOT_LOCAL_TURN)
        self.assertEqual(run.snapshot().total_gameplay_inputs, 0)
        # The next fresh local turn follows the same existing policy/gate path.
        local = replace(state, battle=replace(
            state.battle, turn_number=3, srv_seq=3, acknowledged=True,
            current_turn_player="local", is_local_turn=True, client_move_allowed=True,
            clock_paused=False, clock_pause_reason=None, board_current_state=1,
            sources=("Board.allDots+MatchService._ackedSeqs",),
        ))
        self.assertTrue(ActionabilityGate.evaluate(local, GateContext(evidence.session, True, True)).actionable)
        self.assertIs(engine.decide(local).action, PolicyAction.SWAP)

    def test_solo_does_not_adopt_foreign_opening(self):
        state, evidence = observed_opening()
        self.assertFalse(_entry_opening_turn_valid(state, coop_mode=False))
        run = waiting_run(evidence.session, coop=False)
        self.assertFalse(run.accept_opening(evidence))
        self.assertIs(run.stop_reason, FarmRunStopReason.OPENING_INVARIANT_FAILED)

    def test_ordinary_solo_opening_still_accepted(self):
        state, evidence = observed_opening()
        state = replace(state, battle=replace(state.battle, is_local_turn=True))
        self.assertTrue(_entry_opening_turn_valid(state, coop_mode=False))
        evidence = replace(evidence, first_local_turn=True, is_local_turn=True)
        self.assertTrue(waiting_run(evidence.session, coop=False).accept_opening(evidence))

    def test_coop_wait_does_not_depend_on_someone_elses_timer(self):
        _state, evidence = observed_opening()
        evidence = replace(evidence, timer_safe=False)
        self.assertTrue(waiting_run(evidence.session).accept_opening(evidence))

    def test_coop_wait_keeps_every_board_source_and_session_guard(self):
        _state, evidence = observed_opening()
        for changes in (
            {"is_local_turn": None}, {"first_local_turn": None},
            {"turn_number": None}, {"turn_number": 2},
            {"local_move_sequence": None}, {"local_move_sequence": 1},
            {"source": "unverified"}, {"fresh_dto": False},
            {"complete_cells": 63}, {"unique_coordinates": 63},
            {"stable_confirmations": 1}, {"production_ready": False},
            {"gem_types_valid": False}, {"multipliers_valid": False},
            {"board_hash": "bad"}, {"match_id": "M_other"},
            {"session": session(2), "match_id": session(2).match_id},
        ):
            with self.subTest(changes=changes):
                run = waiting_run(evidence.session)
                self.assertFalse(run.accept_opening(replace(evidence, **changes)))
                self.assertIs(run.stop_reason, FarmRunStopReason.OPENING_INVARIANT_FAILED)

    def test_unknown_or_advanced_turn_cannot_pass_entry_turn_check(self):
        state, _evidence = observed_opening()
        for changes in (
            {"is_local_turn": None}, {"turn_number": None}, {"turn_number": 2},
            {"local_move_sequence": 1}, {"sources": ("unverified",)},
        ):
            with self.subTest(changes=changes):
                self.assertFalse(_entry_opening_turn_valid(
                    replace(state, battle=replace(state.battle, **changes)), coop_mode=True,
                ))

    def test_actual_farm_entry_adapter_preserves_foreign_turn_evidence(self):
        state, evidence = observed_opening()
        run = FarmRun(FarmTarget(boss_id="2534"), gameplay_config=bu_win_config())
        self.assertTrue(run.observe_initial_lobby(BossLobbyState.BOSS_LOBBY))
        result = dict(
            status="PASS", stopReason="NEW_COMBAT_OPENING_READY",
            matchId=evidence.match_id, boardHash=evidence.board_hash,
            openingCells=64, openingUniqueCoordinates=64,
            openingSource=evidence.source, firstLocalTurn=False,
            isLocalTurn=False, turnNumber=1, localMoveSequence=0,
            stableConfirmations=2, openingProductionReady=True,
            openingGemTypesValid=True, openingMultipliersValid=True,
            openingFreshDto=True, turnTimeRemainingSeconds=14,
        )
        def fake_entry(args, *, shared_runtime):
            self.assertTrue(shared_runtime.coop_mode)
            self.assertTrue(_entry_opening_turn_valid(state, coop_mode=shared_runtime.coop_mode))
            capability = shared_runtime.entry_capability
            permit = capability.reserve(foreground=True)
            self.assertTrue(capability.complete(permit, sent=True, detail="OFFLINE_READY"))
            args.directory.mkdir(parents=True)
            (args.directory / "entry.json").write_text(json.dumps(result), encoding="utf-8")
        with tempfile.TemporaryDirectory() as temp, patch(
            "tools.farm_run._entry_args", side_effect=lambda args, directory: SimpleNamespace(directory=directory),
        ), patch("tools.farm_run.boss_entry.run", side_effect=fake_entry):
            accepted, _ = _run_entry(
                run=run, args=SimpleNamespace(), directory=Path(temp),
                process=object(), provider=SimpleNamespace(current_session_key=evidence.session),
                monitor=object(), binding=object(), executor=object(), backend=object(),
            )
        self.assertIsNotNone(accepted)
        self.assertFalse(accepted.first_local_turn)
        self.assertFalse(accepted.is_local_turn)
        self.assertEqual(accepted.turn_number, 1)
        self.assertIs(run.state, FarmRunState.COMBAT_ACTIVE)


class PostmatchFailureEvidenceTests(unittest.TestCase):
    def setUp(self):
        self.image_policy = diagnostic_image_writes_enabled()
        configure_diagnostic_image_writes(enabled=False)

    def tearDown(self):
        configure_diagnostic_image_writes(enabled=self.image_policy)

    def timeout_run(self, directory, *, disk_failure=False):
        run = start_run()
        enter(run, session(1))
        self.assertTrue(run.normal_combat_ended(MatchResult.WIN))
        self.assertTrue(run.observe_postmatch())
        provider = SimpleNamespace(poll=Mock(return_value=SimpleNamespace(
            combat_lifecycle=SimpleNamespace(state=CombatLifecycleState.POSTMATCH), state=None,
        )))
        executor = Mock()
        clock = [0.0]
        count = [0]
        def capture(_pid):
            count[0] += 1
            return SimpleNamespace(width=8, height=4, rgb=bytes((count[0], 0, 0)) * 32)
        def sleep(seconds):
            clock[0] += seconds
        location = PostmatchUiLocation(
            PostmatchControl.RESULT_CONFIRM, False, None, 0.0,
            "expected_exactly_one_large_blue_result_panel",
            {"wideReason": "wide_button_label_not_ready"},
        )
        from contextlib import ExitStack
        with ExitStack() as stack:
            stack.enter_context(patch("tools.farm_run.time.monotonic", side_effect=lambda: clock[0]))
            captures = stack.enter_context(patch("tools.farm_run.capture_client_rgb", side_effect=capture))
            stack.enter_context(patch("tools.farm_run.locate_result_confirm", return_value=location))
            if disk_failure:
                stack.enter_context(patch("tools.farm_run.write_failure_png_rgb", side_effect=OSError("disk full")))
            confirmed, _, _ = _confirm_postmatch(
                run=run, process=SimpleNamespace(pid=123, is_running=lambda: True),
                provider=provider, binding=object(), executor=executor,
                directory=directory, interval=0.125, ui_timeout=0.3,
                hotkeys=SimpleNamespace(poll=lambda: (False, False)), sleeper=sleep,
            )
        self.assertFalse(confirmed)
        self.assertIs(run.stop_reason, FarmRunStopReason.POSTMATCH_UI_AMBIGUOUS)
        self.assertEqual(provider.poll.call_count, 1)
        self.assertEqual(captures.call_count, 3)
        executor.send_normalized_point.assert_not_called()
        self.assertEqual(run.snapshot().total_postmatch_inputs, 0)
        return json.loads((directory / "postmatch_failure.json").read_text(encoding="utf-8"))

    def test_timeout_always_saves_two_original_frames_and_bounded_reasons(self):
        with tempfile.TemporaryDirectory() as temp:
            directory = Path(temp)
            evidence = self.timeout_run(directory)
            self.assertEqual(len(list(directory.glob("*.png"))), 2)
            first = read_png_rgb(directory / "postmatch_wait_frame_first.png")
            last = read_png_rgb(directory / "postmatch_wait_frame_last.png")
            self.assertEqual(first.rgb, bytes((1, 0, 0)) * 32)
            self.assertEqual(last.rgb, bytes((3, 0, 0)) * 32)
            self.assertEqual(evidence["samples"], 3)
            self.assertLessEqual(len(evidence["recentLocations"]), 3)
            self.assertEqual(evidence["recentLocations"][-1]["metrics"]["wideReason"], "wide_button_label_not_ready")

    def test_image_storage_failure_keeps_original_stop_and_metadata(self):
        with tempfile.TemporaryDirectory() as temp:
            evidence = self.timeout_run(Path(temp), disk_failure=True)
        self.assertEqual(len(evidence["errors"]), 2)
        self.assertEqual(evidence["images"], [])

    def test_json_storage_failure_is_reported_without_raising(self):
        with tempfile.TemporaryDirectory() as temp, patch.object(Path, "write_text", side_effect=OSError("read only")):
            evidence = _save_postmatch_failure_evidence(
                Path(temp), reason="test", samples=0, elapsed=0,
                first_capture=None, last_capture=None, locations=[],
            )
        self.assertEqual(len(evidence["errors"]), 1)
        self.assertNotIn("metadataPath", evidence)

    def test_healthy_postmatch_keeps_existing_poll_and_click_counts(self):
        from tests.test_farm_run import PostmatchConfirmationTimingTests
        with patch("tools.farm_run._save_postmatch_failure_evidence") as save:
            original = PostmatchConfirmationTimingTests()
            original.test_three_visual_frames_use_only_initial_and_final_memory_polls()
            save.assert_not_called()

    def test_failed_fresh_preflight_saves_the_rejected_frame_and_sends_nothing(self):
        run = start_run()
        enter(run, session(1))
        self.assertTrue(run.normal_combat_ended(MatchResult.WIN))
        self.assertTrue(run.observe_postmatch())
        provider = SimpleNamespace(poll=Mock(return_value=SimpleNamespace(
            combat_lifecycle=SimpleNamespace(state=CombatLifecycleState.POSTMATCH), state=None,
        )))
        executor = Mock()
        executor.window_status.return_value = SimpleNamespace(valid=True, foreground=True)
        ready = PostmatchUiLocation(PostmatchControl.RESULT_CONFIRM, True, (0.5, 0.9), 0.99, "ready")
        missing = PostmatchUiLocation(PostmatchControl.RESULT_CONFIRM, False, None, 0, "fresh_button_missing")
        count = [0]
        def capture(_pid):
            count[0] += 1
            return SimpleNamespace(width=8, height=4, rgb=bytes((count[0], 0, 0)) * 32)
        def execute_mouse(**kwargs):
            self.assertTrue(kwargs["preflight"]())
            self.assertFalse(kwargs["final_pre_takeover_preflight"]())
            return SimpleNamespace(action_succeeded=False, status=SimpleNamespace(value="PREFLIGHT_REJECTED"))
        pinned = SimpleNamespace(
            execute_mouse=execute_mouse, expected_cursor_for_normalized_point=lambda _point: None,
        )
        with tempfile.TemporaryDirectory() as temp, patch(
            "tools.farm_run.capture_client_rgb", side_effect=capture,
        ), patch("tools.farm_run.locate_result_confirm", side_effect=[ready, ready, ready, missing]):
            confirmed, _, _ = _confirm_postmatch(
                run=run, process=SimpleNamespace(pid=123, is_running=lambda: True),
                provider=provider, binding=object(), executor=executor,
                directory=Path(temp), interval=0.08, ui_timeout=3,
                hotkeys=SimpleNamespace(poll=lambda: (False, False)),
                pinned_input_session=pinned, sleeper=lambda _seconds: None,
            )
            evidence = json.loads((Path(temp) / "postmatch_failure.json").read_text(encoding="utf-8"))
            self.assertEqual(evidence["recentLocations"][-1]["reason"], "fresh_button_missing")
            self.assertEqual(read_png_rgb(Path(temp) / "postmatch_wait_frame_last.png").rgb, bytes((4, 0, 0)) * 32)
            self.assertEqual(len(list(Path(temp).glob("*.png"))), 2)
        self.assertFalse(confirmed)
        self.assertEqual(provider.poll.call_count, 3)
        executor.send_normalized_point.assert_not_called()
        self.assertEqual(run.snapshot().total_postmatch_inputs, 0)

    def test_wide_diagnostics_preserve_distinct_failure_stage(self):
        for kwargs, expected, banner_count, button_count in (
            ({"banner": False}, "expected_unique_wide_banner_and_button", 0, 1),
            ({"button": False}, "expected_unique_wide_banner_and_button", 1, 0),
            ({"button_label": False}, "wide_button_label_not_ready", 1, 1),
        ):
            with self.subTest(kwargs=kwargs):
                rgb, width, height = current_wide_result_rgb(**kwargs)
                location = locate_result_confirm(rgb, width, height)
                self.assertFalse(location.found)
                self.assertEqual(location.metrics["wideReason"], expected)
                self.assertEqual(location.metrics["wideBannerCandidates"], banner_count)
                self.assertEqual(location.metrics["wideButtonCandidates"], button_count)
                self.assertEqual(location.metrics["captureWidth"], width)


class BuWinTerminalPresentationTests(unittest.TestCase):
    """Terminal memory can precede visible game-over by 30s of client FX."""

    ready = PostmatchUiLocation(
        PostmatchControl.RESULT_CONFIRM, True, (0.4984375, 0.90078125),
        0.99, "single_blue_button_below_orange_result_banner",
    )
    skill = PostmatchUiLocation(
        PostmatchControl.RESULT_CONFIRM, False, None, 0,
        "expected_exactly_one_large_blue_result_panel",
        {"wideBannerCandidates": 0, "wideButtonCandidates": 0, "panelCandidates": 0},
    )
    gift = PostmatchUiLocation(
        PostmatchControl.RESULT_CONFIRM, False, None, 0,
        "expected_exactly_one_large_blue_result_panel",
        {"wideBannerCandidates": 1, "wideButtonCandidates": 1,
         "wideButtonLabelPixels": 0, "wideMinimumButtonLabelPixels": 206,
         "wideReason": "wide_button_label_not_ready", "panelCandidates": 0},
    )

    def exercise(self, locate, *, coop=True, stop_at=None, exit_at=None,
                 grace_lifecycle=None, change_session=False, slow_at=None,
                 ui_timeout=30.0):
        run = FarmRun(
            FarmTarget(boss_id="2534"),
            gameplay_config=bu_win_config() if coop else None,
            limits=FarmRunLimits(target_completed_matches=13, max_match_attempts=15),
        )
        self.assertTrue(run.observe_initial_lobby(BossLobbyState.BOSS_LOBBY))
        enter(run, session(1))
        self.assertTrue(run.normal_combat_ended(MatchResult.UNKNOWN))
        self.assertTrue(run.observe_postmatch())
        clock = [0.0]
        clicks = []
        events = []
        provider = SimpleNamespace(
            lifecycle=CombatLifecycleState.POSTMATCH, current_session_key=session(1),
        )

        def poll():
            if not clicks and clock[0] >= ui_timeout:
                if grace_lifecycle is not None:
                    provider.lifecycle = grace_lifecycle
                if change_session:
                    provider.current_session_key = session(2)
            return SimpleNamespace(
                combat_lifecycle=SimpleNamespace(state=provider.lifecycle), state=None,
            )

        provider.poll = Mock(side_effect=poll)
        executor = Mock()
        executor.window_status.return_value = SimpleNamespace(valid=True, foreground=True)

        def click(_binding, point, *, settle_cursor=False):
            self.assertTrue(settle_cursor)
            clicks.append((clock[0], point))
            provider.lifecycle = CombatLifecycleState.LOBBY
            return ClickPointResult(ClickStatus.SENT)

        executor.send_normalized_point.side_effect = click

        def execute_mouse(**kwargs):
            accepted = kwargs["preflight"]() and kwargs["final_pre_takeover_preflight"]()
            return SimpleNamespace(
                action_succeeded=accepted and kwargs["action"](), status=LeaseStatus.COMPLETE,
            )

        pinned = SimpleNamespace(
            execute_mouse=execute_mouse,
            expected_cursor_for_normalized_point=lambda point: point,
        )

        def sleep(seconds):
            clock[0] += seconds

        def capture(_pid):
            if slow_at is not None and clock[0] >= slow_at:
                clock[0] += 61.0
            return SimpleNamespace(width=8, height=4, rgb=bytes(8 * 4 * 3))

        with tempfile.TemporaryDirectory() as temp, patch(
            "tools.farm_run.time.monotonic", side_effect=lambda: clock[0],
        ), patch("tools.farm_run.capture_client_rgb", side_effect=capture), patch(
            "tools.farm_run.locate_result_confirm", side_effect=lambda *_args: locate(clock[0]),
        ), patch("tools.farm_run.write_png_rgb"):
            confirmed, _, _ = _confirm_postmatch(
                run=run,
                process=SimpleNamespace(pid=123, is_running=lambda: exit_at is None or clock[0] < exit_at),
                provider=provider, binding=object(), executor=executor,
                directory=Path(temp), interval=1.0, ui_timeout=ui_timeout,
                hotkeys=SimpleNamespace(poll=lambda: (False, stop_at is not None and clock[0] >= stop_at)),
                pinned_input_session=pinned, sleeper=sleep,
                event_sink=lambda event, payload: events.append({"event": event, **payload}),
            )
            failure_file = Path(temp) / "postmatch_failure.json"
            failure = json.loads(failure_file.read_text(encoding="utf-8")) if failure_file.exists() else None
        return SimpleNamespace(
            confirmed=confirmed, run=run, elapsed=clock[0], clicks=clicks,
            events=events, provider=provider, failure=failure,
        )

    def test_pending_teammate_skill_then_fast_gift_after_30s_confirms_once_and_continues(self):
        result = self.exercise(lambda t: self.skill if t < 30 else self.gift if t < 32 else self.ready)
        self.assertTrue(result.confirmed)
        self.assertEqual(len(result.clicks), 1)
        self.assertEqual(result.clicks[0][0], 34.0)
        self.assertEqual(result.provider.poll.call_count, 5)  # existing pinned 4 + one grace check
        self.assertEqual([e["phase"] for e in result.events],
                         ["STARTED", "PRESENTATION_GRACE", "CONFIRM_VISIBLE", "CONFIRM_STABLE"])
        self.assertIsNone(result.failure)
        self.assertEqual(result.run.snapshot().total_gameplay_inputs, 0)
        self.assertTrue(result.run.observe_return_lobby(BossLobbyState.BOSS_LOBBY))
        self.assertIs(result.run.state, FarmRunState.RESOLVE_TARGET)
        self.assertTrue(result.run.target_resolved())
        self.assertIs(result.run.state, FarmRunState.ENTRY_READY)
        self.assertEqual(result.run.completed_matches, 1)

    def test_normal_coop_result_keeps_existing_pinned_poll_and_click_counts(self):
        result = self.exercise(lambda _t: self.ready)
        self.assertTrue(result.confirmed)
        self.assertEqual(result.elapsed, 2.0)
        self.assertEqual(result.provider.poll.call_count, 4)
        self.assertEqual(len(result.clicks), 1)
        self.assertNotIn("PRESENTATION_GRACE", [e["phase"] for e in result.events])

    def test_never_ready_gift_has_absolute_60s_cap_and_stage_evidence(self):
        result = self.exercise(lambda _t: self.gift)
        self.assertFalse(result.confirmed)
        self.assertEqual(result.elapsed, 60.0)
        self.assertEqual(result.clicks, [])
        self.assertEqual(result.provider.poll.call_count, 2)
        self.assertEqual(result.failure["waitContext"]["stage"], "RESULT_REVEAL_PENDING")
        self.assertEqual(result.failure["waitContext"]["hardTimeoutSeconds"], 60.0)
        self.assertEqual(len(result.failure["images"]), 2)
        self.assertIs(result.run.stop_reason, FarmRunStopReason.POSTMATCH_UI_AMBIGUOUS)

    def test_solo_keeps_30s_cap(self):
        result = self.exercise(lambda _t: self.skill, coop=False)
        self.assertFalse(result.confirmed)
        self.assertEqual(result.elapsed, 30.0)
        self.assertEqual(result.provider.poll.call_count, 1)
        self.assertEqual(result.failure["waitContext"]["presentationGraceSeconds"], 0)
        self.assertEqual(result.clicks, [])

    def test_flashing_button_cannot_restart_proof_deadline(self):
        result = self.exercise(lambda t: self.ready if t == 1 or t % 4 == 0 else self.gift)
        self.assertFalse(result.confirmed)
        # First visible at 0: its UI budget cannot be reset by later flashes.
        self.assertEqual(result.elapsed, 30.0)
        self.assertEqual(result.clicks, [])

    def test_button_appearing_at_hard_limit_cannot_extend_it(self):
        result = self.exercise(lambda t: self.gift if t < 59 else self.ready)
        self.assertFalse(result.confirmed)
        self.assertEqual(result.elapsed, 60.0)
        self.assertEqual(result.clicks, [])

    def test_expensive_capture_cannot_authorize_proof_after_deadline(self):
        result = self.exercise(lambda _t: self.ready, slow_at=2.0)
        self.assertFalse(result.confirmed)
        self.assertEqual(result.clicks, [])

    def test_emergency_stop_remains_responsive_during_grace(self):
        result = self.exercise(lambda _t: self.skill, stop_at=31.0)
        self.assertFalse(result.confirmed)
        self.assertEqual(result.elapsed, 31.0)
        self.assertIs(result.run.stop_reason, FarmRunStopReason.EMERGENCY_STOP)
        self.assertEqual(result.clicks, [])

    def test_game_exit_during_grace_never_clicks(self):
        result = self.exercise(lambda _t: self.skill, exit_at=31.0)
        self.assertFalse(result.confirmed)
        self.assertEqual(result.elapsed, 31.0)
        self.assertEqual(result.clicks, [])

    def test_lifecycle_or_session_change_before_grace_fails_closed(self):
        for kwargs in ({"grace_lifecycle": CombatLifecycleState.LOBBY}, {"change_session": True}):
            with self.subTest(kwargs=kwargs):
                result = self.exercise(lambda _t: self.skill, **kwargs)
                self.assertFalse(result.confirmed)
                self.assertEqual(result.elapsed, 30.0)
                self.assertEqual(result.clicks, [])
                self.assertIn("OWNERSHIP_CHANGED", [e["phase"] for e in result.events])
                self.assertEqual(len(result.failure["images"]), 2)

    def test_phase5_source_binding_still_rejects_future_farmrun_edits(self):
        from tests.reasoning_controller_fixture import assert_c3_source_compatibility
        target = Path(__file__).resolve().parents[1] / "tools/farm_run.py"
        original_read = Path.read_bytes

        def changed_bytes(path):
            raw = original_read(path)
            return raw + b"\n# unreviewed change\n" if path == target else raw

        with patch.object(Path, "read_bytes", changed_bytes), self.assertRaises(AssertionError):
            assert_c3_source_compatibility(self)


if __name__ == "__main__":
    unittest.main()
