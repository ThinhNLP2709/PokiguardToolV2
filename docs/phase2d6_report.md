# Phase 2D.6 Report — Long-Running Farm Operations + Graceful Control

Date: 2026-08-22 (Asia/Saigon)

## Outcome

**PASS STRONG.** Phase 2D.6 proved all three required live invariants:

```text
PHASE2D6_GRACEFUL_STOP_PROVEN
PHASE2D6_CHECKPOINT_RESUME_PROVEN
PHASE2D6_LONG_SOAK_PROVEN
```

The accepted B3 run completed exactly 25 matches, returned to the exact boss
lobby, and stopped without reserving match 26. All recorded farm safety
counters were zero. Automation is stopped; no future phase was started.

The repository baseline was Phase 2D.5 commit
`774386e17e298817e048936be6747f1062396a08`.

## Architecture and operator controls

The accepted bounded runner remains:

```text
exact boss lobby/Starburst 1289
  -> normal foreground Bắt đầu click
  -> fresh MatchId/session/opening
  -> read-only memory GameState
  -> BASIC policy
  -> normal foreground SWAP/CAST/EVOLVE or zero-input PASS
  -> frozen terminal result
  -> one normal Đồng ý click
  -> exact boss lobby
  -> next bounded attempt or stop gate
```

F6 is an edge-triggered graceful stop. F9 remains the independent emergency
stop. The run-level stop states are `RUNNING`, `STOP_REQUESTED`,
`DRAINING_CURRENT_MATCH`, `DRAINING_POSTMATCH`, `STOPPED_AT_LOBBY`, and
`EMERGENCY_STOPPED`. Once F6 is accepted, a central entry gate forbids a new
boss entry. An entry already sent is allowed to materialize and its combat is
drained normally. Recovery may exit to the lobby while draining, but cannot
re-enter. F9 invalidates future executable work immediately and produces a
non-resumable `EMERGENCY_STOPPED` checkpoint.

## Checkpoint contract

Checkpoint schema is `pokiguard.farm_checkpoint.v1`. `checkpoint.json` is
written to a temporary file in the same directory, flushed, `fsync`ed, and
atomically installed with `os.replace`.

Persisted state is durable history only: run/continuation identity, checkpoint
sequence, target and limits, timestamps, attempt/completion/result counters,
technical abort/recovery/exit counters, last and seen MatchIds, action and PASS
aggregates, result-consistency aggregates, last safe lifecycle, control/stop
state, stop reason, and finalized status.

It explicitly does not restore a Board pointer, lifecycle epoch, pending
action/ACK, `srvSeq`, board hash, idle state, desync state, CardUI/Fusion/
MatchService pointers, or an executable UI locator. Resume is explicit and is
accepted only after a fresh exact `BOSS_LOBBY` classification with matching
target/limits. Corrupt, unsupported, completed, emergency-stopped, unsafe-state,
or config-mismatched checkpoints fail closed with zero input.

## Offline evidence

The final suite covers F6 at every lifecycle boundary, the entry/stop race,
recovery re-entry suppression, F9 invalidation, checkpoint validation and
atomic replacement, config/schema/corruption failures, accounting continuity,
duplicate MatchId rejection, and no restoration of executable runtime state.

Final validation:

```text
python -m unittest discover -s tests
Ran 525 tests in 6.879s
OK

python -m compileall -q src tools tests
PASS
```

`git diff --check` is recorded after the final documentation update in the Git
handoff below.

## Live B1 — graceful stop

Accepted FarmRun: `dded65a91c9d4955b9614a1b61f40904`.

| Field | Evidence |
|---|---|
| MatchId | `M_9e7aa126` |
| Stop request | `2026-08-18T13:49:53.591Z`, `COMBAT_ACTIVE` / `ACTIVE_COMBAT`, about 10.266 s after accepted match start |
| Result | WIN, STRONG terminal memory result |
| Postmatch audit | `Thắng -> WIN`, CONSISTENT |
| Completed | 1 of configured 3 |
| Entry inputs after F6 | 0 |
| Emergency stop used | false |
| Final lifecycle/reason | `BOSS_LOBBY` / `STOPPED_GRACEFULLY` |
| Invariant | `PHASE2D6_GRACEFUL_STOP_PROVEN` |

## Live B2 — checkpoint and explicit resume

Run A: `dc1d191f369449deb422f1b3c7cc209b`.

- Completed 2/5: 2 WIN, 0 LOSS, 0 UNKNOWN.
- F6 finalized at exact `BOSS_LOBBY` with
  `STOPPED_GRACEFULLY`/`STOPPED_AT_LOBBY`.
- Checkpoint sequence 6, last completed MatchId `M_c34d7da8`, and zero entry
  inputs after the stop request.

Resume: `7afb954b302a4bdab59ff488bb56317f`, explicitly linked through
`continuationOf=dc1d191f369449deb422f1b3c7cc209b`.

- Continued the historical count from 2 and finished cumulatively at 5/5.
- Final results: 5 WIN, 0 LOSS, 0 UNKNOWN, all five normal results consistent.
- Six unique attempts were retained because one natural
  `DEAD_BOARD_NO_REFRESH` technical abort was recovered; it was not counted as
  a completed match.
- Technical aborts/recoveries: 1/1. Duplicate accounting, duplicate MatchIds,
  and all safety counters: 0.
- Final lifecycle/reason: `BOSS_LOBBY` / `FARM_TARGET_COMPLETED`.
- Invariant: `PHASE2D6_CHECKPOINT_RESUME_PROVEN`.

## Live B3 — 25-match bounded soak

Accepted FarmRun: `6f8d890137604098b6ff4a066a20d4ec`.

Configuration:

```text
boss_id=1289
target_completed_matches=25
max_technical_recoveries=3
max_match_attempts=32
```

Run interval: `2026-08-22T08:03:14.041Z` to
`2026-08-22T10:00:53.021Z`, duration 7,058.980 seconds
(1 h 57 min 38.980 s).

| Accounting | Value |
|---|---:|
| Attempts / completed | 25 / 25 |
| WIN / LOSS / UNKNOWN | 24 / 1 / 0 |
| Result consistent / incomplete / conflict | 25 / 0 / 0 |
| Technical aborts / recoveries / exits | 0 / 0 / 0 |
| Gameplay / lobby / postmatch / recovery inputs | 505 / 25 / 25 / 0 |
| SWAP sent / ACK / rejected / state-changed abort | 410 / 397 / 0 / 12 |
| CAST sent / accepted / rejected | 53 / 41 / 0 |
| EVOLVE attempts / success / failure | 42 / 20 / 22 |
| PASS / Windows inputs caused by PASS | 53 / 0 |

Every completed match had a STRONG memory-backed result and consistent UI
audit. The single LOSS is authoritative normal gameplay evidence, not a
technical failure. Exactly 25 attempt directories and 25 unique MatchIds exist;
there is no attempt 26. B3 observed no natural technical failure, so its value
is `NOT_OBSERVED`; B2 supplied natural dead-board recovery coverage.

Provider telemetry was: 0 read errors, 2 DTO rejections, 0 stale skips, 3,412
unstable skips, 1 ambiguous-latest skip, and 0 opening-snapshot rejections.
Unstable/ambiguous observations were withheld and did not authorize input.

All of the following B3 counters are zero:

```text
duplicate gameplay/lobby/recovery/postmatch input
wrong target
wrong turn / opponent-turn input
stale action / stale session confusion
lobby/postmatch gameplay input
input after farm stop
result double count / result conflict
entry beyond target
```

Final lifecycle is `BOSS_LOBBY`; exact stop reason is
`FARM_TARGET_COMPLETED`; invariant is `PHASE2D6_LONG_SOAK_PROVEN`.

## Resource and artifact telemetry

The accepted B3 artifact recorded 258,551,940 bytes before final `run.json`
serialization (246.57 MiB). The final directory is 259,137,424 bytes.

The immutable B3 `run.json` has `controllerMemory.available=false`. Root cause
was an incorrect ctypes Win32 ABI: `GetCurrentProcess` defaulted to a 32-bit C
`int` result and truncated the x64 pseudo handle before the process-memory
query. The sampler now declares `HANDLE`/argument/result types explicitly and
uses `kernel32.K32GetProcessMemoryInfo`. A post-fix live one-shot returned
27,709,440 bytes and `available=true`, and a regression test covers this path.

Start, peak, and end working set for the already completed B3 are therefore
**UNAVAILABLE**. They cannot be reconstructed, and this report does not claim
that B3 proved absence of a memory leak. Future runs will record all three.
Internally, retained controller events are capped at 4,000, working-set samples
at 512, and attempts by the finite configured limit (32); full event history is
streamed to disk. The FarmRun does not retain an unbounded history of raw
GameState/board snapshots.

## Material hardening completed while reaching B3

- Enforced the user-approved low-boss-HP mode: skip EVOLVE at/below the
  configurable threshold (default 30,000 HP), then Sword, affordable CAST, or
  safe Mana. Outside that mode the accepted 480-Mana stockpile rule remains.
- Made Attack/evolution cards optional: missing equipped cards disable only the
  corresponding card action; board solving continues.
- Added pre-entry selected-card telemetry and strict current-session live
  CardUI ownership; stale lobby/card objects never become executable.
- Replaced fixed card coordinates with ownership-validated dynamic slot layout
  for ordinary cards and Fusion. Pet-specific skill-card clicking remains
  deliberately deferred.
- Prioritized short-lived opening transport state over expensive optional UI
  scans and cleared session-owned learned UI regions at lifecycle boundaries.
- Hardened lag/reconnect turn transitions, uncertain action outcomes, lobby
  rehydration, and the bounded Chinh Phuc map return path without relaxing
  foreground or freshness gates.
- Added a pre-reentry MatchService ACK-epoch check. A contaminated lobby epoch
  now fails closed with zero recovery reentry input; automatic process restart
  remains out of scope.

## Required final handoff checklist

1. Overall status: **Phase 2D.6 PASS STRONG**.
2. Base commit: `774386e17e298817e048936be6747f1062396a08`.
3. Files: listed in the Git section below.
4. Farm architecture: bounded exact-target lifecycle shown above.
5. Graceful control: F6, edge-triggered.
6. Emergency control: F9, immediate and non-resumable.
7. Stop state machine: six explicit states listed above.
8. B1 FarmRunId: `dded65a91c9d4955b9614a1b61f40904`.
9. B1 MatchId: `M_9e7aa126`.
10. B1 request: `ACTIVE_COMBAT` at `2026-08-18T13:49:53.591Z`.
11. B1 result: STRONG WIN.
12. B1 postmatch: consistent WIN/`Thắng`.
13. B1 entry count after request: 0.
14. B1 invariant: `PHASE2D6_GRACEFUL_STOP_PROVEN`.
15. Checkpoint schema: `pokiguard.farm_checkpoint.v1`.
16. Atomic write: same-directory temp, flush, fsync, `os.replace`.
17. Persisted fields: durable historical accounting/control/config only.
18. Non-restored fields: every executable session/board/action/UI pointer and
    sequence field listed in the checkpoint contract.
19. B2 initial run: `dc1d191f369449deb422f1b3c7cc209b`.
20. B2 before stop: 2 completed.
21. B2 resume: `7afb954b302a4bdab59ff488bb56317f`, PASS.
22. B2 cumulative final count: 5.
23. B2 duplicate accounting: 0.
24. B2 duplicate MatchIds: 0.
25. B2 invariant: `PHASE2D6_CHECKPOINT_RESUME_PROVEN`.
26. B3 FarmRunId: `6f8d890137604098b6ff4a066a20d4ec`.
27. B3 limits: 25 completed, 3 recoveries, 32 attempts.
28. B3 attempts: 25.
29. B3 completed: 25.
30. B3 wins: 24.
31. B3 losses: 1.
32. B3 unknown: 0.
33. B3 result consistency: 25/25, conflicts 0.
34. B3 technical aborts: 0.
35. B3 technical recoveries: 0.
36. Natural failure: B3 not observed; B2 observed/recovered dead board.
37. SWAP: 410 sent, 397 ACK, 0 rejected, 12 state-changed aborts.
38. CAST: 53 sent, 41 accepted, 0 rejected.
39. EVOLVE: 42 attempts, 20 success, 22 failure.
40. PASS: 53 records, 0 Windows inputs.
41. Graceful requests: B1 one, B2 Run A one, B3 zero.
42. Emergency events in accepted runs: 0.
43. Session uniqueness: PASS; 25/25 unique in B3.
44. Provider anomalies: exact counts listed above; no read error.
45. Start working set: unavailable for immutable B3.
46. Peak working set: unavailable for immutable B3.
47. End working set: unavailable for immutable B3; sampler fixed afterward.
48. B3 artifact: 258,551,940 bytes before finalization, 259,137,424 final.
49. Duplicate input counters: all 0.
50. Wrong target: 0.
51. Wrong/opponent-turn input: 0/0.
52. Stale action/session: 0/0.
53. Lobby/postmatch gameplay input: 0/0.
54. Input after stop: 0.
55. Entry beyond target: 0; no attempt 26.
56. Final lifecycle: `BOSS_LOBBY`.
57. Stop reason: `FARM_TARGET_COMPLETED`.
58. B3 duration: 7,058.980 s.
59. B3 invariant: `PHASE2D6_LONG_SOAK_PROVEN`.
60. Regression: 525/525 PASS.
61. Compileall: PASS.
62. `git diff --check`: see final Git handoff.
63. `CURRENT_STATE.md`: updated after acceptance.
64. `DECISIONS.md`: changed only for explicit user gameplay decisions made
    during this phase (low-HP finisher, timeout semantics, card-loadout rules).
65. Commit hash: recorded after the dedicated Phase 2D.6 commit.
66. Push status: recorded after push to `origin/main`.
67. Remaining limitations: no infinite run, no game launch/restart/login
    automation, no mid-combat checkpoint resume, no pet-specific skill-card
    clicking, and no retroactive B3 working-set series.

## Git/file handoff

Phase 2D.6 created or modified only files inside `PokiguardToolV2`:

- Documentation: `docs/CURRENT_STATE.md`, `docs/DECISIONS.md`,
  `docs/basic_gameplay_policy.md`, `docs/card_state_detection.md`,
  `docs/gameplay_rules.md`, `docs/il2cpp_symbols.md`, this report, and
  `docs/phase2d6_runbook.md`.
- Runtime: `src/pokiguard_v2/actionability.py`, `autonomous_control.py`,
  `basic_policy.py`, `boss_lobby_runtime.py`, `chinh_phuc_map.py`,
  `combat_cards.py`, `farm_checkpoint.py`, `farm_control.py`, `farm_run.py`,
  `gameplay_ui.py`, `memory_board_provider.py`, `opening_snapshot.py`,
  `state.py`, `technical_recovery.py`, and `win32_input.py`.
- Tools: `tools/basic_auto_bot.py`, `boss_entry.py`, `farm_cycle.py`,
  `farm_run.py`, `sequence_desync_runtime.py`, and `technical_recovery.py`.
- Tests: `tests/test_actionability.py`, `test_autonomous_control.py`,
  `test_basic_policy.py`, `test_boss_entry.py`, `test_boss_lobby_cards.py`,
  `test_chinh_phuc_map.py`, `test_combat_cards.py`, `test_farm_checkpoint.py`,
  `test_farm_cycle.py`, `test_farm_run.py`, `test_farm_run_cli_d6.py`,
  `test_memory_provider_baseline.py`, `test_postmatch_ui.py`,
  `test_sequence_desync.py`, and `test_technical_recovery.py`.

The dedicated commit and push result are reported in the final operator handoff
after validation. Phase 2D.5 history is not rewritten.

## Safety boundary

The accepted implementation uses `ReadProcessMemory` only for game-state
observation and normal foreground Windows input for gameplay/UI actions. It
does not use `WriteProcessMemory`, injection, remote threads, direct gameplay
IL2CPP calls, direct `RequestSwap`/`SendMove`, sequence forging, or network
manipulation.
