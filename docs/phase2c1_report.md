# Phase 2C.1 report

Status: **PASS STRONG — PHASE 2C.1 COMPLETE**.

The read-only lobby smoke test attached to PID 6284, resolved the Pokiguard
window and GameAssembly, performed 59 provider polls and one bounded baseline
scan, and exited with zero read errors. Because it intentionally remained in
the lobby and used `--dry-run`, it sent zero input. Evidence:
`logs/phase2c1_lobby_smoke.jsonl`.

## Implementation summary

1. **ActionabilityGate signals:** current combat session, Phase 2B.5
   ACK-attested stable board, Board move state/readiness/cascade/UI flags,
   exact local turn, player/boss alive, match/game-over/deferred/modal flags,
   connection/reconnect/resync/clock, the game's replicated move-permission
   result, global input lock, auto-pause, fixed window and foreground.
2. **Local-turn source:** exact `ChatService.username` versus
   `MatchService.CurrentTurnPlayer` ordinal-ignore-case behavior reconstructed
   from `MatchService.IsLocalTurn`; actor 1 is not hard-coded for turn gating.
3. **Game-over/modal signals:** `Board.isGameOver`,
   `MatchService._matchOver`, `_hasDeferredGameOver`, the two Mega/Fusion panel
   flags, legend-card/Mega-in-progress flags, death stats, resume/resync and
   Board disappearance. Generic unrelated Unity modal traversal remains
   UNKNOWN and is not guessed.
4. **Foreground handling:** binds one Pokiguard HWND/PID/client size and checks
   it before every click. It never steals focus or restores the window.
5. **Coordinate pipeline:** runtime bottom-origin rows are flipped exactly once
   while building provider `BoardState`; provider, V1 solver and screen use
   top-origin `(row,col)`. V1 normalized calibration is converted through the
   current fixed client rectangle and `ClientToScreen`.
6. **Input implementation:** x64-safe ctypes Win32 calls,
   `SetCursorPos`, left-down/up, 25 ms press and V1's 0.25 s cell-to-cell delay.
   Exactly two clicks represent one adjacent swap.
7. **Revalidation:** F8 triggers a fresh provider poll and requires the same
   session, source sequence, board hash and recomputed solver move, then reruns
   the complete gate and coordinate checks.
8. **Acknowledgement:** the global lock waits for increased `srvSeq`, changed
   board hash, turn/state/session transition, or a clear timeout. A consumed
   identity is never retried.
9. **Real single-step actions tested:** 14 with the final ACK implementation
   (5 in the fixed run and 9 in the beep run), plus 2 preliminary swaps used to
   diagnose the original timeout observation.
10. **Accepted/rejected/timeout counts:** final implementation 14 accepted,
    0 rejected/input-failed, 0 timeout. ACK latency was 3,828-5,906 ms, average
    4,137 ms. The two earlier preliminary swaps were visibly accepted but were
    classified as timeout by the superseded seven-second stable-publication
    observer.
11. **Misclick count:** 0 reported across the 14 final actions; all logged
    endpoints were distinct, adjacent cells inside the validated board/client
    rectangles. The two preliminary endpoints were also visually confirmed.
12. **Duplicate input count:** 0. Every executed identity sent exactly two
    clicks once.
13. **Skip behavior:** each unique local-turn source state is counted once;
    two consecutive safe-action failures set `AUTO_PAUSE`. A successful ACK or
    new session resets it. A partial one-click input emergency-pauses
    immediately.
14. **Cards/Fusion:** confirmed READ + LOG ONLY; neither has an input path.
15. **Blockers before full-auto:** the opening board has no ACK witness and
    currently requires one manual move; an authoritative `MOVE_REJECTED` event
    is still unresolved; generic unrelated Unity modal traversal is UNKNOWN;
    current-turn countdown fields are reverse-proven but not yet exposed in
    `GameState`; automatic card/Fusion policy remains intentionally absent.

## Tests

`python -m unittest discover -s tests -v`: **75/75 PASS**.

Coverage added for centralized gate reasons, action identity/ACK/timeout,
two-skip pause, all coordinate boundaries/transforms, exact two-click behavior,
focus loss between clicks, early raw `_ackedSeqs` acknowledgement while a
stable board is withheld, and the exact two-skip ceiling. `single_step_bot.py
--help` and Python bytecode compilation also pass.

## Preliminary runtime correction

Evidence log: `logs/phase2c1_acceptance_retry_20260812_112018.jsonl`.

The controller sent two correct swaps and no duplicate/partial input. Raw ACK
progress was visible during rendering, but `ActionLock` originally observed
only published `GameState`; the next stable boards appeared roughly 0.8 seconds
after its timeout. Two false `MOVE_NO_STATE_CHANGE` results therefore triggered
the designed auto-pause and correctly blocked the next F8.

The lock now also accepts a strictly newer value from the already validated
`MatchService._ackedSeqs.highest` decoder. This releases the input lock while
rendering continues, but does not allow another proposal until the provider
publishes a fully stable board. `SkipTracker` also refuses further increments
after reaching two, so it cannot report a spurious third `AUTO_PAUSED` skip.

The initial room board still has no ACK witness. Until a separate authoritative
bootstrap witness is proven, the acceptance run requires one manual opening
move. This preserves the mandatory acknowledged-snapshot gate instead of
weakening it.

Fixed runtime evidence `logs/phase2c1_acceptance_fixed_20260812_112545.jsonl`
contains 5 actions, 5 early ACKs (3.83-4.45 s), 0 timeout, 0 duplicate, 0
partial input, and 0 auto-pause. A manual Fusion invalidated the pending
proposal and withheld state throughout presentation. The provider later
published sequence 32 and created a fresh proposal, proving modal recovery.
The user's F8 landed in the same scan that created that proposal and was
intentionally classified `F8_PRECEDED_PROPOSAL`; a second F8 would have run it.
A short ready beep is now emitted after each proposal to make that boundary
observable while the controller console is hidden.

## Final acceptance

Primary evidence logs:

- `logs/phase2c1_acceptance_fixed_20260812_112545.jsonl`: 5/5 sent actions ACKed,
  0 timeout, 0 duplicate, 0 partial/input failure. Manual Fusion was read/logged
  only; it expired the old proposal and a fresh proposal appeared after the
  presentation completed.
- `logs/phase2c1_acceptance_beep_20260812_114329.jsonl`: 9 proposals/beeps,
  9 actions, 9 ACKs, 0 timeout, 0 duplicate, 0 partial/input failure. The
  controller then observed two distinct solver safety skips and correctly set
  `AUTO_PAUSE`; no further beep or input was produced.

Aggregate final implementation: **14 actions / 14 ACK / 0 timeout / 0 input
failure / 0 partial input / 0 duplicate**. Cards and Fusion remained strictly
read-and-log-only; the Fusion click in the fixed run was manual user input.

The controller stopped via F9 and no Phase 2C.1 Python process remains.

## Current-turn timer evidence (not integrated in 2C.1)

Turn ownership is already production runtime state: `ChatService.username` is
compared with `MatchService.CurrentTurnPlayer` (`+0x38`) using the exact
ordinal-ignore-case behavior from `MatchService.IsLocalTurn`.

Cpp2IL also proves the countdown source:

- `TurnDurationSec : Int32` at `+0x44`;
- `TurnTimeRemainingSec : Int32` at `+0x118`, updated by server timer ticks;
- `HasServerClock : Boolean` at `+0x128`;
- `ClockPaused : Boolean` at `+0x129`;
- `_clockRemainAtAnchorSec : Single` at `+0x138`;
- `_clockAnchorUnscaled : Single` at `+0x13C`;
- `_localFxHoldUntilUnscaled : Single` at `+0x158`.

`MatchService.get_ServerTurnRemainingSec()` subtracts Unity unscaled elapsed
time from the anchor when not paused/held and clamps the result to
`[0, max(1, TurnDurationSec)]`. Phase 2C.1 reads pause/start-gate signals but
does not yet expose the countdown in `GameState`; doing so belongs to a reviewed
next milestone.

## Files created/modified for Phase 2C.1

Created:

- `src/pokiguard_v2/actionability.py`
- `src/pokiguard_v2/action_control.py`
- `src/pokiguard_v2/win32_input.py`
- `tools/single_step_bot.py`
- `tests/test_actionability.py`
- `tests/test_action_control.py`
- `tests/test_win32_input.py`
- `docs/actionability_signals.md`
- `docs/phase2c1_runbook.md`
- `docs/phase2c1_report.md`

Modified:

- `src/pokiguard_v2/il2cpp_external.py`
- `src/pokiguard_v2/memory_board_provider.py`
- `src/pokiguard_v2/state.py`
- `tests/test_il2cpp_external.py`
- `docs/il2cpp_symbols.md`

Phase 2C.2 has not been started.
