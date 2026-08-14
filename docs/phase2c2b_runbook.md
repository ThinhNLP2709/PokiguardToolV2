# Phase 2C.2B Stage B2 runbook

Status: Stage A and Stage B1 live acceptance PASS. Stage B2 is the current
bounded milestone. Unlimited/full-match, Stage B3, PASS, automatic exit,
automatic recovery and automatic re-entry remain disabled.

## Safety scope

Autonomous input remains limited to `EVOLVE`, `SWAP`, and `CAST`, using normal
foreground Windows mouse input. Memory access is read-only. Before every input
the current session, ACTIVE combat lifecycle, local turn, living participants,
stable current Board, modal/cascade state, sequence state, timer, foreground
window and pending-action lock are revalidated.

Stage B2 has three independent hard bounds:

- `turn_consuming_actions_total <= 10` for `SWAP + CAST`;
- `input_actions_total <= 20` for `EVOLVE + SWAP + CAST`;
- at most two EVOLVE attempts on one concrete session/turn.

The tenth consuming action does not stop while pending. The controller waits
for its explicit terminal ACK/accepted result, then stops with
`AUTO_STOP_AFTER_ACK` before preparing action 11. Reaching the total-input
ceiling stops with `MAX_TOTAL_INPUT_ACTIONS_REACHED` after the last input is
terminal.

## Start from lobby

```powershell
$env:PYTHONPATH = "D:\PokiguardToolV2\src"
python D:\PokiguardToolV2\tools\basic_auto_bot.py --watch `
  --play-style simple `
  --mana-priority evolution `
  --intelligence basic `
  --matches 1 `
  --max-turn-actions 10 `
  --max-total-input-actions 20 `
  --max-fusion-attempts-per-turn 2
```

Enter one boss combat manually, keep Pokiguard in the foreground, and do not
make gameplay input. Use F9 only if something visibly wrong happens.

- F7 pauses/resumes. An unsent proposal is discarded; resume always recomputes
  from fresh GameState.
- F9 stops and prevents future gameplay input immediately.
- F10 remains manual-confirmed recovery only. It never starts automatic
  exit/re-entry.

## Expected live behavior

Every fully sent action has:

`action_identity_created -> action_sent -> action_terminal`.

Every SWAP/CAST must be followed by an explicit terminal result. Between
accepted consuming actions the log must prove:

`OPPONENT_TURN -> LOCAL_TURN_RETURNED`.

The controller sends nothing during the boss turn and recomputes from a new
server sequence/board hash for each local turn. The exact current-match opening
DTO emits `OPENING_BOARD_READY` before the first decision.

EVOLVE requires an actual positive runtime cost, a current live interactable
Fusion UI and sufficient mana. It does not consume the ten-action budget but
does consume the total-input budget. It waits for `MATCH_FUSION_RES` plus a
durable Fusion transition, then performs a complete reread before any same-turn
SWAP/CAST. CAST similarly requires actual runtime card cost/identity and waits
for a local card response plus durable used/turn transition.

The following are valid safe stops, not reasons to force ten actions:
`PASS_REQUIRED_BUT_DISABLED`, `POLICY_NO_SAFE_MOVE`, undefined BASIC policy,
`FUSION_RETRY_LIMIT`, `MAX_TOTAL_INPUT_ACTIONS_REACHED`, sequence desync, dead
board and response timeout. Low timer waits for a later state/turn; it never
forces a dangerous move.

## Acceptance

Strong PASS requires exactly ten terminal consuming actions, stop reason
`AUTO_STOP_AFTER_ACK`, distinct/recomputed source states, correct boss/local
turn transitions, and zero duplicate, known misclick/partial, wrong-turn,
stale-board, boss-turn or post-lifecycle input.

A legitimate safe pause before ten actions is `PARTIAL/SAFE-STOP`. EVOLVE
failure/success and CAST coverage are `NOT_OBSERVED` unless the real combat
state naturally selects and executes them.

Stop and review `logs/phase2c2b_stage_b2_*.jsonl`. Do not enable Stage B3 or
unlimited/full-match mode after the run.
