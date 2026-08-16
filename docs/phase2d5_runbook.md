# Phase 2D.5 Runbook

Phase 2D.5 is bounded. It does not add infinite farming, process relaunch, or
unlimited recovery. Start live stages only from the exact boss lobby, with
Pokiguard foreground and no other automation controller running. F9 remains
the emergency stop; F7 remains disabled at farm-run level.

Phase 2D.4 checkpoint:

```text
PHASE2D4_BASE_COMMIT=f87eb9ec5f2e794de635a1d4dbe63375371a142c
```

## Stage A — offline result fidelity

```powershell
$env:PYTHONPATH = 'src'
python tools/farm_run.py --stage-d5-a-results
```

Expected: terminal/result-accounting fixtures pass with
`actualWindowsInputs=0`.

## Stage B1 — exactly one normal match

Do not run this command until the operator confirms the exact boss lobby and
foreground state.

```powershell
$env:PYTHONPATH = 'src'
python tools/farm_run.py --stage-d5-b1-terminal --boss-id 1289 `
  --reset-evidence logs/phase2c2c_reset_capabilities.json
```

The mode internally enforces `target_completed_matches=1`,
`max_technical_recoveries=0`, and `max_match_attempts=1`. Expected flow:

```text
entry -> full BASIC combat -> frozen terminal snapshot -> validated result UI
-> exact boss lobby -> stop (no entry #2)
```

Acceptance requires a memory/lifecycle-backed STRONG WIN or LOSS, a consistent
`THẮNG`/`THUA` UI audit, `unknown_results=0`, and all safety counters zero.
Only then may B2 be started.

Accepted live B1 (2026-08-16):

```text
FarmRunId: 4f1608ed395e44e8886244587a5bb9b0
MatchId: M_d8d290a1
terminal local HP: 64900/105228
terminal boss HP: 0/84180
memory result: WIN / STRONG
sources: Active.PlayerStats local+boss, ACTIVE_TO_POSTMATCH_PRE_CLEANUP,
         TERMINAL_HP_PAIR
UI audit: Thắng -> WIN
consistency: CONSISTENT
accounting: completed 1, wins 1, losses 0, unknown 0
safety counters: all zero
stop: FARM_TARGET_COMPLETED at exact boss lobby; entry #2 = 0
invariant: PHASE2D5_MEMORY_TERMINAL_RESULT_PROVEN
```

Artifact:
`logs/farm_runs/4f1608ed395e44e8886244587a5bb9b0/run.json`

## Stage B2 — extended bounded soak

Run only after B1 has been inspected and accepted:

```powershell
$env:PYTHONPATH = 'src'
python tools/farm_run.py --stage-d5-b2-soak --boss-id 1289 `
  --target-matches 10 --max-technical-recoveries 2 `
  --max-match-attempts 14 `
  --reset-evidence logs/phase2c2c_reset_capabilities.json
```

The runner must return to the exact boss lobby after match 10 and must not
reserve entry #11. A third required recovery or attempt 15 is denied.

Accepted live B2 (2026-08-16):

```text
FarmRunId: b63cd48b836c4aa6bb8f7092c06776aa
configuration: completed target 10, recovery max 2, attempt max 14
attempts/completed: 10/10
wins/losses/unknown: 10/0/0
memory/UI: 10 CONSISTENT, 0 MEMORY_INCOMPLETE, 0 RESULT_CONFLICT
technical aborts/recoveries: 0/0
unique MatchIds: 10
SWAP: 166 sent, 157 ACK, 0 rejected, 9 lifecycle-aborted
CAST: 7 sent, 6 accepted, 0 rejected
EVOLVE: 15 attempts, 9 failed, 6 success
PASS: 25, Windows input 0
provider read/DTO/stale/ambiguity/opening errors: all 0
safety counters: all 0
stop: FARM_TARGET_COMPLETED at exact boss lobby; entry #11 = 0
duration: 2753.934 seconds
invariant: PHASE2D5_EXTENDED_SOAK_PROVEN
```

Artifact:
`logs/farm_runs/b63cd48b836c4aa6bb8f7092c06776aa/run.json`

The accepted run did not naturally encounter `SEQUENCE_DESYNC` or exact
`DEAD_BOARD_NO_REFRESH`, so natural technical-failure coverage is
`NOT_OBSERVED`. This is allowed because recovery resume was already live-proven
in Phase 2D.4. The two-recovery boundary remains covered by offline tests.

## Verification

```powershell
$env:PYTHONPATH = 'src'
python -m unittest discover -s tests -v
python -m compileall -q src tools tests
git diff --check
git status --short
```

All state access remains external/read-only. Every gameplay, lobby, postmatch,
and recovery action remains normal foreground Windows input.
