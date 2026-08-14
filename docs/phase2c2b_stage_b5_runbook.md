# Phase 2C.2B Stage B5 runbook

Status: **FULL_MATCH_PASS**, user-confirmed WIN in live retry 5. Offline
regression remains `300/300 PASS`. The exact same-match 1/3 -> 2/3 -> mandatory
action -> later 1/3 sequence was not naturally observed, so optional
`B5_PASS_STRONG` coverage remains `NOT_OBSERVED`.

## Scope

B5 runs exactly one complete BASIC combat with `simple / evolution / basic`.
Normal foreground UI actions are limited to EVOLVE, SWAP and CAST. PASS is a
zero-input wait whose numeric state comes only from `MATCH_AFK_WARN` or
`MATCH_TURN_END.matchPayload.afkWarn`.

A terminal EVOLVE attempt followed by a same-turn BASIC PASS decision is
handled as an `EVOLVE-only turn`, not as intentional PASS. Live evidence now
covers both `success=true` and `success=false`: either turn can advance to the
boss and back without any AFK payload. The controller sends zero additional
input, does not start `PASS_WAIT`, does not increment a PASS counter, and
forces a fresh full-state reread on the next local turn. If an AFK payload does
appear, it is still retained as authoritative evidence; no local idle value is
synthesized.

Automatic exit, recovery, re-entry, farming, REASONING, memory writes, direct
game calls and network manipulation remain disabled. DEAD_BOARD and
SEQUENCE_DESYNC lock gameplay and require manual recovery.

## PASS/reset cycle

- First local turn always requires a consuming action.
- BASIC may select PASS only from an exact current game-owned idle state or a
  production-ready reset baseline.
- PASS sends no click. The controller waits for the server turn end and exact
  AFK payload.
- Exact 1/3 permits at most one further natural BASIC PASS.
- Exact 2/3 sets a mandatory consuming-action lock. A third PASS is blocked.
- EVOLVE remains legal before the mandatory action but does not satisfy it.
- The mandatory action is the normal policy-selected SWAP/CAST. If no safe
  move exists, the existing deterministic minimum-danger fallback evaluates
  every legal move.
- An acknowledged SWAP uses the audited production-ready SWAP reset
  capability. CAST reset is not guessed: an attributed response may support
  ordered confirmation; a strong direct CAST state transition can only become
  `STRONGLY_INFERRED` after a later exact compatible server idle payload.
- B5 counts a full cycle only for 1/3 -> 2/3 -> accepted mandatory action ->
  later intentional PASS -> 1/3 without an intervening consuming action.

If CAST reset remains UNKNOWN, ordinary safe policy may continue. If policy
later requires PASS while the idle state is UNKNOWN, the controller pauses
closed.

## Live command

Start only from the pet/boss lobby for the pet being farmed:

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
  --pass-acceptance-stage B5 `
  --reset-evidence D:\PokiguardToolV2\logs\phase2c2c_reset_capabilities.json
```

The controller waits for the user to enter one combat. The user sends no
gameplay input. F9 is emergency stop. F7 is used only if explicitly needed.
F10 is used only after `RECOVERY_REQUIRED` and manual confirmation.

A three-tone alarm means fail-closed/safety stop; report it and do not assume
the bot is still active. Normal match completion stops the controller without
postmatch/lobby input. No automatic next match is started.

## Acceptance

`FULL_MATCH_PASS` requires one clean lobby -> active combat -> combat end run,
with zero duplicate, misclick, partial, wrong-turn, stale, opponent-turn,
postmatch/lobby input, third PASS and local idle synthesis. PASS-cycle coverage
may be PARTIAL or NOT_OBSERVED when the natural board never produces two
consecutive PASS decisions.

`B5_PASS_STRONG` additionally requires the exact server-owned cycle:

1. intentional zero-input PASS -> 1/3;
2. intentional zero-input PASS -> 2/3;
3. accepted mandatory SWAP/CAST;
4. later intentional zero-input PASS -> 1/3.

No board condition is manufactured to obtain this sequence.

## Offline evidence

- Python compile: PASS.
- Full regression: `300/300 PASS`.
- New coverage includes B5 CLI/profile gates, no small action cap inherited
  from full-combat mode, second-PASS mandatory transition, later idle-1 cycle
  completion, strong/full-match classification, and direct CAST reset
  provenance remaining only `STRONGLY_INFERRED`.

Read-only preflight evidence:
`logs/phase2c2b_stage_b5_preflight_20260814.jsonl` classified PID 14912 as
LOBBY with no active combat ownership. A second independent singleton sample
in `logs/phase2c2b_stage_b5_stale_board_preflight_20260814.jsonl` found a
stale ready 8x8 `Board.Instance`. The controller smoke therefore refused to
initialize as designed and wrote
`logs/phase2c2b_stage_b5_lobby_smoke_20260814.jsonl`; no gameplay input was
sent. Do not weaken the clean-lobby gate. Fully restart the game process and
repeat the read-only preflight before the live command.

Live attempt 1 evidence:
`logs/phase2c2b_stage_b5_acceptance1_20260814.jsonl`. EVOLVE attempt 1 failed;
attempt 2 later succeeded on local turn 13. The controller correctly reread
`fusion.used=true` and selected a same-turn SWAP, but sent it only 1.47 seconds
after the EVOLVE terminal. The game ignored that click during the remaining
presentation/animation window, no ACK arrived in nine seconds, and the
controller safe-stopped with the three-tone alarm as `ACTION_RESPONSE_TIMEOUT`.
It recorded 6/7 acknowledged SWAPs, one rejected/timed-out SWAP, two EVOLVE
inputs (one fail, one success), zero PASS/CAST and all input-safety counters
zero. The combat later ended while input remained locked.

Historical successful EVOLVE-follow-up evidence across eight earlier logs has
a 3.80–5.20 second terminal-to-next-input delay. B5 now enforces a 3.5-second
post-terminal settlement window; normal capture/control work places the actual
follow-up around four seconds or later. It then rereads lifecycle, session,
turn, timer, board, actionability and policy before any input. Source/turn
change cancels the wait rather than forcing a stale same-turn action. Retry-2
lobby smoke passed with zero input.

Live retry 2 evidence:
`logs/phase2c2b_stage_b5_acceptance_retry2_20260814.jsonl`, match
`M_35b2ee04`. Before the final stop, all 10 SWAP inputs were acknowledged and
one EVOLVE succeeded. The authoritative bounded cycle reached PASS 1/3, PASS
2/3, then a mandatory SWAP on turn 11; that SWAP was acknowledged and no third
PASS was sent. On turn 25, EVOLVE succeeded, the 3.5-second settlement gate
completed, and BASIC selected PASS because no safe move remained. The old
controller incorrectly entered `PASS_WAIT`. Boss turn 26 and local turn 27
arrived with no correlated AFK payload, producing the safe stop
`PASS_STATE_UNCONFIRMED`. This is the same no-AFK-after-EVOLVE pattern captured
historically in `M_1aaa7be0`.

The controller now classifies that exact case as `EVOLVE-only turn`: zero
input, no PASS accounting, no PASS coordinator, and a mandatory fresh reread
after the opponent transition. Any session change, extra gameplay input,
local move-sequence change, or turn regression during this wait fails closed.
The dedicated regression replays turns 25 -> 26 -> 27 and proves the interval
is not accepted as an authoritative PASS.

Live retry 3 evidence:
`logs/phase2c2b_stage_b5_acceptance_retry3_20260814.jsonl`, match
`M_f8cd2d73`. Six of six SWAPs were acknowledged. EVOLVE on turn 13 returned
the exact terminal `MATCH_FUSION_RES success=false`. After the settlement
window, BASIC selected PASS with 11 legal but zero safe moves. The old success-
only activity marker missed this rejected attempt, entered `PASS_WAIT`, and
safe-stopped at local turn 15 because no AFK payload existed. Input-safety
counters and third-PASS violations were all zero. The activity marker now
covers both `EVOLVE_SUCCESS` and `EVOLVE_FAILED`; a separate regression proves
both values touch the turn while unrelated terminal results do not.

Live retry 4 was excluded from controller acceptance because the user tabbed
away during local turn 19. The gate logged `GAME_NOT_FOREGROUND`, sent no
input, and stopped at the six-second deadline as
`LOCAL_TURN_ACTION_DEADLINE`. Before that user-caused interruption it had 7/7
acknowledged SWAPs, two authoritative PASS results at 1/3, and zero safety
violations. The match later reached postmatch/lobby with input still disabled.

Live retry 5 is the accepted full combat. Evidence:
`logs/phase2c2b_stage_b5_acceptance_retry5_20260814.jsonl`, match
`M_217798cd`. The user confirmed WIN. The controller classified the lifecycle
as `FULL_MATCH_PASS` and stopped cleanly after lobby returned:

- 26 local turns and 25 boss turns;
- 27 total inputs, of which 26 were turn-consuming;
- 21 SWAPs sent, 20 acknowledged, zero rejected; the final winning-turn SWAP
  was safely classified `ACTION_ABORTED_STATE_CHANGED` when authoritative
  postmatch arrived before an ACK could be retained;
- one EVOLVE, successful on turn 9; after the 3.5-second settlement gate, the
  same-turn follow-up SWAP was sent 4.77 seconds after the terminal result and
  acknowledged;
- five dynamic Attack-card CASTs, all accepted with exact 160-mana deductions
  and opponent-turn transitions, with zero same-turn SWAP after CAST;
- no natural PASS proposal, so PASS-cycle coverage is `NOT_OBSERVED` rather
  than failed;
- zero duplicate, misclick, partial, wrong-turn, stale, boss-turn, postmatch,
  lobby, after-combat, third-PASS, DEAD_BOARD or SEQUENCE_DESYNC events.

Lifecycle was lobby -> combat session `M_217798cd` -> postmatch -> lobby.
Automatic exit/re-entry/farming remained disabled throughout.
