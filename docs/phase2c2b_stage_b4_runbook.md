# Phase 2C.2B Stage B4 runbook

Status: `B4_PASS_STRONG`. Live retry 2 cleanly accepted one autonomous CAST
and stopped with the intended two-tone signal. No further B4 session is
required. Stage B3 remains PASS STRONG.

## Scope

B4 runs BASIC with `play-style=simple` and `mana-priority=attack`. It keeps
production authoritative PASS enabled and permits only normal foreground UI
SWAP/CAST input. EVOLVE, automatic exit, automatic recovery, automatic
re-entry, farming and REASONING are disabled.

The policy threshold remains strictly `playerMana > 480`. The controller does
not lower it, force Mana collection, delay a win or hard-code card ID 4. It
selects a current Board/Active-owned Attack CardUI dynamically and uses its
positive `CardData.manaCost`, otherwise `CardData.conditionUse`, as the actual
cost.

## Hard gates

- ATTACK priority logs `EVOLVE_SKIPPED_MANA_PRIORITY_ATTACK`; any EVOLVE
  proposal is a hard `B4_EVOLVE_FORBIDDEN` stop before input.
- Before CAST, the full proposal source, card identity/state, actual cost,
  current mana, actionability, timer, modal and foreground state are reread.
- CAST holds the consuming-turn lock in `WAIT_CARD_RESPONSE`; no SWAP can be
  proposed while it is pending.
- Strong acceptance requires the exact next boss turn with unchanged board
  move sequences, exact `manaAfter = manaBefore - actualCost`, and either an
  accepted current-match card response or the durable used-card transition.
- On acceptance, the controller immediately disables input and emits two high
  tones. A same-turn SWAP is structurally blocked and counted as a hard failure
  if ever proposed.
- CAST reset confidence is recorded exactly. The current audited capability is
  UNKNOWN, so no numeric idle zero is invented and no subsequent PASS is made
  after B4 stops.

## Live command

Start only from the boss lobby:

```powershell
$env:PYTHONPATH = "D:\PokiguardToolV2\src"
python D:\PokiguardToolV2\tools\basic_auto_bot.py --watch `
  --play-style simple `
  --mana-priority attack `
  --intelligence basic `
  --matches 1 `
  --max-turn-actions 0 `
  --max-total-input-actions 100 `
  --ack-heap-region-mib 16 `
  --max-fusion-attempts-per-turn 2 `
  --pass-acceptance-stage B4 `
  --reset-evidence D:\PokiguardToolV2\logs\phase2c2c_reset_capabilities.json
```

The user enters exactly one combat and sends no gameplay input. Two high tones
mean strong CAST acceptance and controller stop; immediately take over the
still-running combat. The three-tone descending/rising alarm is a safe stop;
take over and report it. If the combat naturally ends without CAST, the result
is `CAST_NOT_OBSERVED`, not a failure.

At most three manually entered sessions may be attempted, each with a fresh
lobby-started controller. Stop early after the first strong accepted CAST. Do
not add automatic re-entry.

## Offline acceptance

- policy/controller focused regression before attempt 1: `74/74 PASS`;
- full regression before live attempt 1: `290/290 PASS`;
- Python compile: PASS.

Lobby smoke PASS against PID 26248. It observed `LOBBY`, advertised
`simple / attack / basic`, allowed only `SWAP/CAST/PASS`, disabled EVOLVE,
stopped on the three-second test timeout, and sent zero gameplay input with
every safety counter at zero. Evidence:
`logs/phase2c2b_stage_b4_lobby_smoke_20260814.jsonl`.

Live attempt 1 evidence:
`logs/phase2c2b_stage_b4_acceptance1_20260814.jsonl`. Match `M_b7235e32`
sent 15 acknowledged SWAPs and one dynamic Attack CAST. The CAST itself has
strong evidence (`882 - 160 = 722`, card used on turn 31, boss turn 32, no
same-turn SWAP, EVOLVE/PASS zero), but a fabricated
`MATCHSERVICE_TURN_TRANSITION` idle source violated the authoritative idle
model and crashed terminal bookkeeping before the success beep. The later
three idle turns were therefore caused by the stopped controller, not three
policy PASS decisions.

The fix records reset candidacy only from a real `MATCH_CARD_USE_RES` or
`MATCH_SKILL_USE_RES`; when that response DTO is absent, CAST acceptance is
kept while reset confidence remains UNKNOWN and B4 stops normally. Any future
unhandled controller exception also emits the three-tone pause alarm. Focused
regression is now `77/77 PASS`; full regression is `293/293 PASS`. A clean
live retry was then completed.

Live retry 2 evidence:
`logs/phase2c2b_stage_b4_acceptance_retry2_20260814.jsonl`, match
`M_4ce90616`. The controller sent 15/15 acknowledged SWAPs, one zero-input
authoritative PASS confirmed at idle 1/3, and one autonomous CAST. The dynamic
Attack card cost came from `CardData.conditionUse = 160`; mana changed exactly
`603 -> 443`, card state changed from interactable/unused/lastTurnUsed -1 to
non-interactable/used/lastTurnUsed 33, and local turn 33 changed to boss turn
34 without a board move-sequence increase. Same-turn SWAP, EVOLVE, duplicate,
misclick, partial, wrong-turn, stale, boss-turn, postmatch and lobby inputs were
all zero. The missing card-response DTO left CAST reset confidence UNKNOWN;
the controller did not invent idle zero, stopped as
`B4_CAST_ACCEPTED_RESET_UNKNOWN`, emitted two high tones, and classified the
run `B4_PASS_STRONG`.
