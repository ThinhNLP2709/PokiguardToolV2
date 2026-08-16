# Phase 2D.3 runbook — bounded technical recovery

## Current status

**PASS STRONG.** Accepted Stage B artifact:
`logs/technical_recovery/20260815_232743_777/`.

This controller allows at most one technical recovery and stops at the fresh
recovered opening. It never hands the recovered match to gameplay:

```text
technical trigger -> gameplay lock -> << -> Đồng ý -> boss lobby
-> exact target -> one re-entry -> fresh opening 64/64 -> STOP
```

Supported production triggers are only `SEQUENCE_DESYNC` and an exact
`DEAD_BOARD_NO_REFRESH`. `POLICY_NO_SAFE_MOVE`, normal win/loss, foreground
loss, user pause, and other safe stops do not dispatch recovery.

## Offline verification

From `D:\PokiguardToolV2`:

```powershell
$env:PYTHONPATH='src;.'
python tools/technical_recovery.py --stage-a-replay
python -m unittest discover -s tests -v
python -m compileall -q src tools tests
git diff --check
```

Accepted baseline: Stage A PASS, 365/365 tests PASS, compileall PASS, diff check
PASS.

## Explicit live UI acceptance mode

This is a destructive-to-the-current-match test: it intentionally abandons a
normal combat but does not fabricate a desync/dead-board claim.

Preconditions:

1. Enter a normal Starburst combat manually.
2. Keep Pokiguard foreground.
3. Stop any other cooperating automation controller.
4. Be willing to abandon the current combat.

Command:

```powershell
$env:PYTHONPATH='src;.'
python tools/technical_recovery.py --recovery-ui-test --boss-id 1289
```

User controls:

- F9: emergency stop at every recovery stage;
- F7: disabled in this runner;
- F10: disabled and unnecessary.

Do not click, move gems, use cards, change focus, or enter the target manually
during the run. After the tool prints `PHASE2D3_RECOVERY_BOUNDARY_PROVEN`, the
controller has exited and the user may play the recovered combat manually.

Expected counts are exit 1, confirm 1, re-entry 1, optional target selection at
most 1, and every gameplay/duplicate/wrong/stale counter 0.

## Natural production watch

The production detector can be exercised without inducing or corrupting a
failure:

```powershell
$env:PYTHONPATH='src;.'
python tools/technical_recovery.py --watch-production --boss-id 1289
```

It waits only for naturally observed accepted sequence-desync or exact
zero-legal dead-board evidence. It must not be used to manipulate packets,
memory, sequence numbers, or game files. If no natural failure occurs, no
recovery input is authorized.

## Fail-closed outcomes

The runner emits an explicit result for foreground loss, missing/ambiguous exit
control, confirmation failure, lobby timeout, target failure, re-entry failure,
new-session/opening failure, recovery limit, and F9. It never retries a click,
starts a second recovery, or accepts a later-turn ACK board as an opening.

Exact opening acceptance requires a different MatchId/session/Board/epoch,
current MATCH_START source, 64 cells, 64 unique coordinates, known gem types,
valid x1-x4 multipliers, first local turn, local sequence zero, stable
confirmations, and timer margin.

## Artifacts

Each attempt writes a unique directory:

```text
logs/technical_recovery/<timestamp>/
```

Core files are `recovery.json`, `events.jsonl`, failure state/board evidence,
and available screenshots for failure, exit, modal, boss lobby, re-entry, and
the new opening. `reentry/entry.json` and `reentry/entry.jsonl` retain the exact
Phase 2D.1 evidence.

## Phase boundary

Do not automatically resume BASIC, loop farming, perform a second recovery, or
start Phase 2D.4 from this runbook. Phase 2D.4 requires separate explicit user
approval.
