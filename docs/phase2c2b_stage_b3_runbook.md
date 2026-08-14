# Phase 2C.2B Stage B3 runbook

Status: PASS STRONG. Authoritative-PASS integration, `283/283` offline
regression, no-input lobby smoke and one complete live autonomous combat all
PASS. Final evidence is
`logs/phase2c2b_stage_b3_authoritative_pass_retry6_20260814_192336.jsonl`;
the user-confirmed result was WIN. Stop here for review—do not start automatic
exit, re-entry or farming.

## Scope

Stage B3 permits `EVOLVE`, `SWAP` and `CAST` through normal foreground Windows
mouse input plus authoritative zero-input `PASS`. Memory remains read-only.
Automatic exit, automatic recovery, automatic re-entry, direct game calls and
network manipulation remain disabled.

Production PASS loads the audited P0 reset capability and reuses the P1-P3
coordinator. It does not use the acceptance-only forced-PASS trigger. BASIC is
the only source of PASS decisions; missing/ambiguous server state stops as
`PASS_STATE_UNKNOWN` rather than being conflated with `POLICY_NO_SAFE_MOVE`.

The Stage B2 ten-consuming-action cap is disabled. A configurable emergency
ceiling of 100 total `EVOLVE + SWAP + CAST` inputs remains. It is checked only
after the latest sent action has a terminal result and stops as
`AUTO_PAUSE_SAFETY_LIMIT`; it is not a gameplay target. EVOLVE remains limited
to two attempts per concrete session/turn.

## Start from a proven lobby

Only one controller may be alive. Run:

```powershell
$env:PYTHONPATH = "D:\PokiguardToolV2\src"
python D:\PokiguardToolV2\tools\basic_auto_bot.py --watch `
  --play-style simple `
  --mana-priority evolution `
  --intelligence basic `
  --matches 1 `
  --max-turn-actions 0 `
  --max-total-input-actions 100 `
  --ack-heap-region-mib 16 `
  --max-fusion-attempts-per-turn 2 `
  --pass-acceptance-stage B3 `
  --reset-evidence D:\PokiguardToolV2\logs\phase2c2c_reset_capabilities.json
```

Do not pass `--acceptance-force-pass-after-actions`; B3 rejects that
acceptance-only override.

Enter exactly one boss combat manually, keep Pokiguard foreground, and do not
make gameplay input.

- F7 pauses/resumes and always discards an unsent proposal.
- F9 immediately stops all future gameplay input.
- F10 is accepted only after `RECOVERY_REQUIRED` and remains a manually
  confirmed recovery step.

## Terminal behavior

Normal completion disables input at `COMBAT_LIFECYCLE_ENDED`, invalidates the
old controller session, and continues read-only lifecycle observation for at
most 20 seconds to capture `POSTMATCH -> LOBBY`. It never clicks postmatch or
lobby UI.

The following are valid safe stops: `PASS_STATE_UNKNOWN`,
`PASS_STATE_UNCONFIRMED`, other terminal PASS state changes, undefined BASIC
state, `DEAD_BOARD_NO_REFRESH`, sequence desync and
`AUTO_PAUSE_SAFETY_LIMIT`. They never force a move merely to finish B3.

An exact authoritative `1/3` permits a second BASIC-selected PASS. Exact `2/3`
sets a mandatory-reset lock, making a third PASS impossible. The next
consuming action uses the normal strategic/safe choice, or the deterministic
least-dangerous fallback when required. Only an acknowledged action with an
accepted reset capability starts a new baseline; it never writes a local
idle zero. A reset with UNKNOWN evidence stops closed.

An authoritative local turn that reaches six seconds without a sent consuming
action now safe-stops as `LOCAL_TURN_ACTION_DEADLINE` and beeps once. This is a
deadline witness from `MatchService`, not a locally maintained idle counter.
It exists so a provider/capture delay cannot silently consume multiple turns.

Terminal failed EVOLVE attempts are also treated as proven non-board state
transitions when ACK, attempt turn, local move sequence and two unchanged
`Board.allDots` samples agree. This lets the provider republish the same board
and continue policy in the remaining same turn without waiting for a Board DTO
that a failed Fusion does not create.

When a retained `MATCH_CARD_USE_RES` DTO is missed, CAST may be confirmed only
by an exact same-session transition from its source local turn to the next boss
turn while both known board-move sequence fields remain unchanged. Any
conflicting player, turn or sequence stays pending and then stops closed.
Combat teardown preserves an earlier safe terminal pause/recovery reason; a
later lifecycle end cannot relabel that attempt as full-combat completion.

`POLICY_NO_SAFE_MOVE` is evaluated only after non-board policy actions. An
actionable EVOLVE remains Step 1 and may run before the board safety gate;
CAST is independently turn-consuming and also is not rejected merely because
the board has zero safe swaps. A genuine unsafe SWAP/PASS state still pauses
fail-closed. The pause alert is one distinctive three-tone alarm (760 ms total)
so it is not confused with a short status chirp.

When the newest ACKed board is not yet visible through the validated direct
`BoardWsApplier` owner, the provider now waits at most one full provider poll
before starting the exact-sequence heap fallback. This changes only when the
read-only search begins: the selected DTO must still match the current highest
ACK, pass all 64-cell validation and stable-publication gates. The prior
eight-poll grace consumed most of a live 14-second turn because one complete
provider poll is substantially longer than the controller's 100 ms loop sleep.

Autonomous heap fallback is restricted to private writable regions no larger
than 16 MiB. Retry-8 measurements on the active process were 1.06 seconds for
the old 8 MiB envelope (but it missed the newest batch), and 1.94 seconds for
16 MiB (both live batches found). An unrestricted 3.36 GiB process scan took
14.5 seconds and remains disabled. A heap candidate is never accepted by class
scan alone: exact current `_ackedSeqs`, complete DTO validation, current combat
session exclusion and stable render/publication checks are still mandatory.

If a fast scan of previously learned batch regions does not contain the exact
highest ACK, the provider immediately performs the bounded full 16 MiB scan in
the same poll. It no longer waits for another controller iteration. This still
does not permit an unrestricted scan and does not publish the first class hit;
all exact-ACK, 64-cell and two-sample stability gates remain.

Within one controller iteration, the transient transport observation taken
before the provider poll is reused by the sequence/action monitor after that
poll. The same learned ChatMessageDTO regions are not scanned twice in one
iteration. This preserves the early DTO witness while removing duplicate
read-only work from the 14-second opening turn; if combat becomes active during
the provider poll, the normal post-provider observation still runs.

The final `auto_controller_summary` includes local/boss turns, all action
totals and terminal results, PASS idle-1/idle-2 counts, mandatory reset action
and confirmed reset-baseline counts, policy branch coverage, lifecycle
timeline, session-clear status and the required zero-valued input-safety
counters.

## Lobby smoke evidence

Authoritative-PASS B3 smoke
`logs/phase2c2b_stage_b3_authoritative_pass_lobby_smoke_20260814.jsonl`
attached read-only to PID 7232 in proven `LOBBY`. It logged production mode,
allowed `EVOLVE/SWAP/CAST/PASS`, disabled the forced acceptance trigger, sent
zero input and ended on its three-second diagnostic timeout with all safety
counters zero.

Activity DTOs observed during PASS_WAIT are accepted as manual-action evidence
only when both their server timestamp is current and their server sequence is
strictly newer than the PASS source sequence. This rejects partially reused
heap objects such as the live `srvSeq 3` candidate seen after source `srvSeq
19`; direct monotonic `localMoveSequence` remains an independent manual-SWAP
detector.

`logs/phase2c2b_stage_b3_lobby_smoke_20260814.jsonl` attached read-only to PID
3140, proved lifecycle `LOBBY`, established a lobby baseline, sent zero input
and reported every safety counter as zero.
