# Phase 2D.3 audit report — PASS STRONG

## Status

**PASS STRONG — LIVE ACCEPTED ON STAGE B ATTEMPT 5
(`20260815_232743_777`).**

The accepted bounded run proved:

```text
ACTIVE_COMBAT
-> explicit TEST_ONLY trigger
-> absolute gameplay lock
-> one automatic << click
-> stable leave modal
-> one automatic Đồng ý click
-> POSTMATCH
-> exact BOSS_LOBBY
-> old-session invalidation
-> exact Starburst 1289
-> one automatic re-entry click
-> different MatchId/session/Board/epoch
-> fresh MATCH_START opening 64/64
-> HARD STOP with zero recovered-combat gameplay input
```

Final invariant: `PHASE2D3_RECOVERY_BOUNDARY_PROVEN`.

The live trigger was explicitly `TEST_ONLY`; no natural live sequence desync or
zero-legal dead board was observed or induced. Production sequence-desync and
dead-board dispatch were proven by captured replay/deterministic offline
evidence through the same coordinator used by the live runner.

## Architecture

`TechnicalRecoveryDispatcher` is the only trigger boundary. It dispatches:

- `SEQUENCE_DESYNC` from the production sequence guard;
- `DEAD_BOARD_NO_REFRESH` only from a current, stable, complete 64-cell board
  whose exhaustive legal-match-producing-move count is exactly zero;
- explicit `TEST_ONLY` live acceptance without inventing a technical reason.

`POLICY_NO_SAFE_MOVE` (`legal > 0`, `safe == 0`) always returns non-dispatch.
Normal win/loss and all other safe stops retain their existing paths.

`TechnicalRecoveryCoordinator` owns the one-attempt budget, trigger identity,
gameplay lock, state transitions, single-use input permits, failure results,
old-session invalidation, new-session freshness, opening validation, safety
counters, and final hard stop. The Win32 runner owns read-only observation and
normal foreground clicks. Production hooks in `tools/basic_auto_bot.py` feed
the same dispatcher; no second recovery implementation exists.

The accepted state progression is:

```text
IDLE -> TECHNICAL_FAILURE_DETECTED -> GAMEPLAY_LOCKED
-> RESOLVE_EXIT_CONTROL -> EXIT_READY -> EXIT_INPUT_SENT
-> WAIT_EXIT_MODAL -> CONFIRM_MODAL_READY -> CONFIRM_INPUT_SENT
-> WAIT_LOCAL_COMBAT_END -> WAIT_BOSS_LOBBY -> CLEAR_OLD_SESSION
-> RESOLVE_REENTRY_TARGET -> VERIFY_REENTRY_TARGET -> REENTRY_READY
-> REENTRY_INPUT_SENT -> WAIT_NEW_SESSION -> WAIT_NEW_OPENING
-> RECOVERY_COMPLETE
```

All input boundaries use `reserve -> executor result -> complete`; a reservation
does not count as sent input. Every recovery click revalidates foreground. F9
clears any pending permit, locks gameplay, records
`RECOVERY_ABORTED_USER_STOP`, and prevents later clicks. F7 and F10 are disabled
in the Phase 2D.3 runner so stale UI proposals cannot resume.

## Stage A — PASS

Command:

```powershell
python tools/technical_recovery.py --stage-a-replay
```

Latest artifacts:

- `logs/technical_recovery/20260815_232043_474/`
- `logs/technical_recovery/20260815_232043_486/`

Results:

- captured `M_714b231e` sequence fixture dispatched `SEQUENCE_DESYNC`;
- gameplay locked immediately;
- deterministic complete board with 112 evaluated adjacent pairs and zero
  legal match-producing moves dispatched `DEAD_BOARD_NO_REFRESH`;
- `legal=2, safe=0` dispatched nothing and left the coordinator `IDLE`;
- recovery budget, duplicate trigger/input rejection, failure results, session
  cleanup, fresh-opening validation, and recovered-opening hard stop pass unit
  coverage;
- Stage A actual UI inputs: 0;
- `DEAD_BOARD_RUNTIME_LIVE = NOT_OBSERVED`.

## Stage B attempts

Attempts before acceptance were safe evidence runs:

1. Mid-combat attach lacked a lobby baseline, so TEST_ONLY could not arm.
   Production evidence requirements were not relaxed; TEST_ONLY now accepts a
   separately hardened two-sample ACTIVE lifecycle identity.
2. The blinking exit control was not visible during the locator window. No
   click was sent. A hover-only probe plus exact live calibration was added.
3. Exit, confirmation, lobby, target, and re-entry succeeded, but opening
   capture reached a later ACK board. It safe-stopped rather than call that an
   opening.
4. The new transport path resolved current boards but missed the first turn.
   Root cause: a MATCH_START pointer first seen while Newtonsoft was still
   populating its payload was marked consumed after a failed decode. The
   pointer is now retryable until successful decode; only successful DTOs are
   consumed.

No failed attempt sent a gameplay input. The exact 1280x710 exit calibration
comes from a sent exit click followed by a stable 3/3 confirmation-modal proof
and a POSTMATCH transition; it is exact-dimension scoped and is not a global
pixel coordinate.

## Accepted Stage B evidence

Artifact: `logs/technical_recovery/20260815_232743_777/`

| Evidence | Accepted value |
|---|---|
| Trigger | explicit `TEST_ONLY`; no technical failure claimed |
| Failed MatchId | `M_cb29bae5` |
| Failed session | epoch 1, Board `0x000001CD7145EA80` |
| Failed turn | 1 |
| Recovery attempts | 1 |
| Exit locator | exact 1280x710 live calibration, confidence 0.99 |
| Automatic `<<` inputs | 1 |
| Confirm locator | exact symmetric orange leave modal, confidence 0.96 |
| Automatic `Đồng ý` inputs | 1 |
| Lifecycle after confirmation | ACTIVE -> POSTMATCH -> exact BOSS_LOBBY |
| Target | exact selected Starburst, ID 1289 |
| Target-select inputs | 0 |
| Automatic re-entry inputs | 1 |
| New MatchId | `M_db4c0283` |
| New session | epoch 2, Board `0x000001CCEB768A80` |
| Opening source | `ChatMessageDTO.MATCH_START.matchPayload.board` |
| Opening srvSeq/hash | `1` / `85aef4aa78ecdb6125b74034531b719fcbce0e585fa4d0b0b45fae80ed7723f3` |
| Opening validation | 64 cells, 64 unique coordinates, known types, x1-x4 valid |
| Opening turn proof | first local turn, local move sequence 0, stable x3 |
| Final result | `RECOVERY_COMPLETE / RECOVERY_NEW_COMBAT_OPENING_READY` |
| Final boundary | hard stop before gameplay |

Freshness proof is positive for every available identity: MatchId changed,
session key changed, Board instance changed, and lifecycle epoch advanced from
1 to 2. The failed TEST_ONLY attach did not publish a board hash or srvSeq, so
those old values are honestly `UNKNOWN`; their caches were still cleared. The
new opening independently provides a valid current hash and srvSeq.

## Safety counters

| Counter | Value |
|---|---:|
| Recovery attempts | 1 |
| Exit inputs | 1 |
| Confirm inputs | 1 |
| Target-selection inputs | 0 |
| Re-entry inputs | 1 |
| Gameplay inputs after trigger | 0 |
| Gameplay inputs during recovery | 0 |
| Gameplay inputs in recovered combat | 0 |
| Duplicate exit | 0 |
| Duplicate confirm | 0 |
| Duplicate re-entry | 0 |
| Wrong UI click | 0 |
| Wrong target | 0 |
| Stale-session confusion | 0 |

The artifact also records pending gameplay action/proposal as none and old
srvSeq, idle, desync, card, and fusion session state as cleared after local
combat ended—not at exit-click time.

## Required 35-point result

1. Phase result: **PASS STRONG**.
2. Coordinator: separate dispatcher/state machine/capability boundary.
3. Automatic production reasons: sequence desync and exact dead board only.
4. Sequence dispatch: captured real fixture PASS through the shared path.
5. Dead-board dispatch: deterministic zero-legal fixture PASS; natural live
   case not observed.
6. Policy no-safe non-dispatch: `legal=2, safe=0`, coordinator remains IDLE.
7. Budget: exactly one; a second distinct trigger yields limit reached.
8. Gameplay lock: immediate and absolute for SWAP/CAST/EVOLVE/PASS/proposals.
9. Exit locator: PASS, exact-dimension live-proven calibration.
10. Automatic `<<`: 1.
11. Modal detection: PASS, stable exact two-button leave context.
12. Automatic `Đồng ý`: 1.
13. Exit lifecycle: ACTIVE -> POSTMATCH -> boss lobby.
14. Boss lobby reacquisition: exact/stable PASS.
15. Old-session invalidation: PASS after local session end.
16. Starburst target: exact ID 1289 PASS.
17. Re-entry input: 1.
18. Old identity: `M_cb29bae5`, epoch 1, Board `0x1CD7145EA80`.
19. New identity: `M_db4c0283`, epoch 2, Board `0x1CCEB768A80`.
20. New differs from old: MatchId/session/Board/epoch all differ.
21. New opening: PASS, exact current MATCH_START.
22. Board validation: 64/64 cells and 64 unique coordinates.
23. Gameplay input after trigger: 0.
24. Gameplay input in recovered combat: 0.
25. Duplicate/wrong UI counts: all 0.
26. Stale-session confusion: 0.
27. Emergency stop: F9 clears pending authority and prevents future input.
28. Naturally occurring technical failure: `NOT_OBSERVED`.
29. Stage A: PASS.
30. Stage B: PASS.
31. Full regression: 365/365 PASS.
32. `compileall`: PASS.
33. Files are listed below.
34. `CURRENT_STATE.md`: updated to Phase 2D.3 PASS STRONG.
35. Before 2D.4: no technical blocker remains for this bounded recovery
    boundary; continuous resume/loop, multiple recoveries, and natural live
    technical-failure coverage remain deliberately outside or unobserved.

## Verification

Verified on 2026-08-15:

```text
python -m unittest discover -s tests -v
Ran 365 tests
OK

python -m compileall -q src tools tests
PASS

git diff --check
PASS (Git line-ending notices only)
```

## Files

Created:

- `src/pokiguard_v2/technical_recovery.py`
- `tools/technical_recovery.py`
- `tests/test_technical_recovery.py`
- `reference/exit_ui_live_calibration_1280x710.json`
- `docs/phase2d3_report.md`
- `docs/phase2d3_runbook.md`

Modified:

- `src/pokiguard_v2/memory_board_provider.py`
- `tools/basic_auto_bot.py`
- `tools/boss_entry.py`
- `tools/sequence_recovery.py`
- `tests/test_boss_entry.py`
- `tests/test_recovery_ui.py`
- `docs/CURRENT_STATE.md`

`docs/DECISIONS.md` was not changed because Phase 2D.3 introduced no new
user-approved gameplay or product rule.

## Remaining boundary

Phase 2D.3 does not resume BASIC after recovery, perform continuous farming,
rotate targets, retry recovery, or allow more than one recovery. Natural live
sequence-desync and dead-board recovery remain `NOT_OBSERVED`; they were not
induced. Phase 2D.4 has not been implemented or started.
