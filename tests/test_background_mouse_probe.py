from __future__ import annotations

from pathlib import Path
import sys
from types import SimpleNamespace
import unittest
from unittest.mock import patch


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.state import GamePhase  # noqa: E402
from tools.background_mouse_probe import (  # noqa: E402
    _entry_state_accepted,
    _validate_args,
    _wait_board_proposal,
    _wait_swap_ack,
    build_parser,
)
from tools.background_mouse_transport import SwapPreState  # noqa: E402


def state(
    *,
    session: object = "new-session",
    turn: int = 4,
    local_sequence: int = 0,
    last_sequence: int | None = 0,
    sources: tuple[str, ...] = ("WsCombatBatch._ackedSeqs",),
) -> SimpleNamespace:
    return SimpleNamespace(
        phase=GamePhase.COMBAT,
        board=SimpleNamespace(production_ready=True),
        battle=SimpleNamespace(
            session_key=session,
            turn_number=turn,
            local_move_sequence=local_sequence,
            last_move_sequence=last_sequence,
            sources=sources,
        ),
    )


class EntryAckModeTests(unittest.TestCase):
    def test_manual_entry_accepts_fresh_stable_combat_after_opening_window(self) -> None:
        self.assertTrue(
            _entry_state_accepted(
                state(turn=4),
                old_session=None,
                require_match_start_opening=False,
            )
        )

    def test_b2_does_not_accept_late_combat_as_start_click_ack(self) -> None:
        self.assertFalse(
            _entry_state_accepted(
                state(turn=4),
                old_session=None,
                require_match_start_opening=True,
            )
        )

    def test_b2_accepts_only_exact_fresh_match_start_opening(self) -> None:
        opening = state(
            turn=1,
            local_sequence=0,
            last_sequence=0,
            sources=("ChatMessageDTO.MATCH_START.matchPayload.board",),
        )
        self.assertTrue(
            _entry_state_accepted(
                opening,
                old_session=None,
                require_match_start_opening=True,
            )
        )
        self.assertFalse(
            _entry_state_accepted(
                opening,
                old_session="new-session",
                require_match_start_opening=True,
            )
        )


class ArgumentValidationTests(unittest.TestCase):
    def test_manual_entry_timeout_accepts_five_minutes(self) -> None:
        args = build_parser().parse_args(
            [
                "--boss-id",
                "1289",
                "--board-sequence",
                "--board-primitive",
                "drag",
                "--opening-timeout",
                "300",
            ]
        )
        _validate_args(args)


class ForegroundLeaseProbeRegressionTests(unittest.TestCase):
    def test_foreground_game_can_produce_first_turn_proposal_for_lease(self) -> None:
        battle = SimpleNamespace(
            turn_number=1,
            turn_time_remaining_seconds=13,
            local_move_sequence=0,
            session_key=SimpleNamespace(match_id="match-1"),
            local_username="local",
            consecutive_passes=0,
            consecutive_pass_threshold=3,
        )
        game_state = SimpleNamespace(
            phase=GamePhase.COMBAT,
            battle=battle,
            board=SimpleNamespace(production_ready=True),
        )
        provider = SimpleNamespace(
            current_session_key=battle.session_key,
            poll=lambda: SimpleNamespace(state=game_state, reason="stable"),
        )
        backend = SimpleNamespace(foreground_window=lambda: 5)
        exact = SimpleNamespace(window=SimpleNamespace(hwnd=5))
        target = SimpleNamespace(is_running=lambda: True)
        log = SimpleNamespace(event=lambda *_args, **_kwargs: None)
        evaluation = SimpleNamespace(
            move=SimpleNamespace(first=(0, 0), second=(0, 1))
        )

        with (
            patch(
                "tools.background_mouse_probe.ActionabilityGate.evaluate",
                return_value=SimpleNamespace(actionable=True, reason="PASS"),
            ),
            patch(
                "tools.background_mouse_probe._choose_probe_move",
                return_value=evaluation,
            ),
            patch(
                "tools.background_mouse_probe.read_match_runtime",
                return_value=(None, SimpleNamespace()),
            ),
            patch(
                "tools.background_mouse_probe._runtime_preflight",
                return_value=True,
            ),
        ):
            proposal = _wait_board_proposal(
                target=target,
                provider=provider,
                backend=backend,
                exact=exact,
                minimum_turn=1,
                minimum_time=7,
                timeout=1.0,
                interval=0.01,
                log=log,
                require_game_background=False,
            )

        self.assertIsNotNone(proposal)
        self.assertEqual(proposal.pre.turn, 1)

    def test_first_turn_probe_stops_before_input_when_only_late_turn_is_seen(self) -> None:
        battle = SimpleNamespace(
            turn_number=3,
            turn_time_remaining_seconds=13,
            local_move_sequence=0,
            last_move_sequence=None,
            is_local_turn=True,
            is_first_local_turn=False,
            sources=("WsCombatBatch._ackedSeqs",),
            session_key=SimpleNamespace(match_id="match-1"),
            local_username="local",
            consecutive_passes=1,
            consecutive_pass_threshold=3,
        )
        game_state = SimpleNamespace(
            phase=GamePhase.COMBAT,
            battle=battle,
            board=SimpleNamespace(production_ready=True),
        )
        provider = SimpleNamespace(
            current_session_key=battle.session_key,
            poll=lambda: SimpleNamespace(state=game_state, reason="stable"),
        )
        events: list[tuple[str, dict[str, object]]] = []
        log = SimpleNamespace(
            event=lambda event, **fields: events.append((event, fields))
        )

        with patch(
            "tools.background_mouse_probe.ActionabilityGate.evaluate",
            return_value=SimpleNamespace(actionable=True, reason="PASS"),
        ):
            proposal = _wait_board_proposal(
                target=SimpleNamespace(is_running=lambda: True),
                provider=provider,
                backend=SimpleNamespace(foreground_window=lambda: 5),
                exact=SimpleNamespace(window=SimpleNamespace(hwnd=5)),
                minimum_turn=1,
                minimum_time=7,
                timeout=1.0,
                interval=0.01,
                log=log,
                require_game_background=False,
                require_first_local_turn=True,
            )

        self.assertIsNone(proposal)
        self.assertIn("board_probe_first_local_turn_missed", [item[0] for item in events])

    def test_dispatcher_match_start_is_offered_then_repolled_immediately(self) -> None:
        session = SimpleNamespace(match_id="match-1")
        battle = SimpleNamespace(
            turn_number=1,
            turn_time_remaining_seconds=13,
            local_move_sequence=0,
            last_move_sequence=None,
            is_local_turn=True,
            is_first_local_turn=True,
            sources=("ChatMessageDTO.MATCH_START.matchPayload.board",),
            session_key=session,
            local_username="local",
            consecutive_passes=0,
            consecutive_pass_threshold=3,
        )
        game_state = SimpleNamespace(
            phase=GamePhase.COMBAT,
            battle=battle,
            board=SimpleNamespace(production_ready=True),
        )
        polls = iter(
            [
                SimpleNamespace(
                    state=None,
                    reason="awaiting_match_start_opening_dto",
                    session_key=session,
                ),
                SimpleNamespace(state=game_state, reason="stable", session_key=session),
            ]
        )
        offered: list[object] = []
        provider = SimpleNamespace(
            current_session_key=session,
            poll=lambda: next(polls),
            offer_opening_snapshot=lambda snapshot: offered.append(snapshot) or True,
        )
        snapshot = SimpleNamespace(
            match_id="match-1",
            message_address=0x10,
            board_token_address=0x20,
            sequence=3,
        )
        tap = SimpleNamespace(
            arm=lambda _match_id: None,
            transport_board_snapshots=lambda _match_id: (("MATCH_START", snapshot),),
            diagnostics=SimpleNamespace(healthy=True),
        )
        evaluation = SimpleNamespace(
            move=SimpleNamespace(first=(0, 0), second=(0, 1))
        )

        with (
            patch(
                "tools.background_mouse_probe.ActionabilityGate.evaluate",
                return_value=SimpleNamespace(actionable=True, reason="PASS"),
            ),
            patch(
                "tools.background_mouse_probe._choose_probe_move",
                return_value=evaluation,
            ),
            patch(
                "tools.background_mouse_probe.read_match_runtime",
                return_value=(None, SimpleNamespace()),
            ),
            patch(
                "tools.background_mouse_probe._runtime_preflight",
                return_value=True,
            ),
        ):
            proposal = _wait_board_proposal(
                target=SimpleNamespace(is_running=lambda: True),
                provider=provider,
                backend=SimpleNamespace(foreground_window=lambda: 5),
                exact=SimpleNamespace(window=SimpleNamespace(hwnd=5)),
                minimum_turn=1,
                minimum_time=7,
                timeout=1.0,
                interval=0.01,
                log=SimpleNamespace(event=lambda *_args, **_kwargs: None),
                require_game_background=False,
                dispatcher_tap=tap,
                require_first_local_turn=True,
            )

        self.assertIsNotNone(proposal)
        self.assertEqual(offered, [snapshot])
        self.assertEqual(proposal.pre.turn, 1)

    def test_swap_ack_waits_through_exact_sequence_before_turn_transition(self) -> None:
        pre = SwapPreState("match-1", 3, "local", 0, (6, 4), (6, 5))
        pending = SimpleNamespace(
            match_id="match-1",
            turn=3,
            current_player="local",
            local_username="local",
            local_move_sequence=1,
            last_move_sequence=1,
            last_move_from_col=4,
            last_move_from_row=1,
            last_move_to_col=5,
            last_move_to_row=1,
        )
        accepted = SimpleNamespace(**vars(pending))
        accepted.turn = 4
        accepted.current_player = "boss"
        log = SimpleNamespace(event=lambda *_args, **_kwargs: None)

        with (
            patch(
                "tools.background_mouse_probe.read_match_runtime",
                side_effect=[(None, pending), (None, accepted)],
            ) as reader,
            patch("tools.background_mouse_probe.time.sleep", return_value=None),
        ):
            acked, rejected, post = _wait_swap_ack(
                target=SimpleNamespace(is_running=lambda: True),
                pre=pre,
                timeout=1.0,
                interval=0.01,
                log=log,
            )

        self.assertTrue(acked)
        self.assertFalse(rejected)
        self.assertIs(post, accepted)
        self.assertEqual(reader.call_count, 2)


if __name__ == "__main__":
    unittest.main()
