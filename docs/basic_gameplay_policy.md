# Phase 2C.2A BASIC gameplay policy

## Scope

This phase is proposal-only. `BasicPolicyEngine` produces `EVOLVE`, `CAST`,
`SWAP`, `PASS`, `EXIT_MATCH`, or `NONE` plus a `DecisionTrace`. It contains no
mouse input, card click, exit click, game method call, process write, or
network path.

The represented configuration is:

- `PlayStyle`: `SIMPLE`, `CAREFUL`;
- `ManaPriority`: `EVOLUTION`, `ATTACK`;
- `Intelligence`: `BASIC`, `REASONING`.

The user-authored gameplay rules these steps implement live in
`docs/gameplay_rules.md`, which is the source of truth for behaviour. Every
numeric threshold is a `PolicyConfig` field; see that file's table for the CLI
flags.

Only `BASIC` is implemented. Selecting `REASONING` returns `NONE` with
`REASONING_NOT_IMPLEMENTED`.

## Runtime gates

A proposal requires a stable combat `GameState`, proven local turn,
`client_move_allowed == True`, and a readable turn timer. The timer fields are:

- `turn_duration_seconds`: `MatchService.TurnDurationSec +0x44`;
- `turn_time_remaining_seconds`: latest server tick at
  `MatchService.TurnTimeRemainingSec +0x118`;
- `turn_timer_source = MatchService.server_tick`.

This is a coarse server-tick value, not the game's smooth UI getter. The latter
also subtracts `UnityEngine.Time.unscaledTime` from a local anchor; that clock
does not yet have a proven external pointer. The configured action floor is
inclusive: at exactly the floor an action may still be proposed; below it the
policy fails closed. Production auto-farm uses a one-second floor because live
gameplay confirms that an input sent while the display shows `1` is accepted.
A missing ACK at one/two ticks is treated as a lag/unconfirmed-action event,
not proof that those timer values are intrinsically invalid. The policy never
turns a low timer into a generic “least-bad” move.

`first_local_turn` is derived only from runtime `is_local_turn` and server
`turn_number in {0,1}`. Board discovery/lifecycle does not mark an opening.

## Deterministic simulator

Every one of the 112 adjacent pairs is tested. A legal move must create a run
through one of the two swapped cells. Resolution is:

```text
swap -> direct match -> remove -> known-cell gravity
     -> deterministic match touching displaced cells -> repeat
```

Surviving `CellState.multiplier` values x1-x4 travel with their gems. Every
vacancy requiring a refill outside the current 64 cells becomes an explicit
`UNKNOWN` with unknown multiplier. UNKNOWN never participates in a credited
cascade.

Each `MoveEvaluation` reports direct, cascade, and total raw/effective
resources; clear rounds; longest match; horizontal/vertical swap; whether the
direct clear is at screen row 3 or lower; known Sword potentials left; Sword
danger regions; collapse/support hazard; UNKNOWN count and concentration; and
hypothetical Sword completions through exposed UNKNOWN cells.

`safe` is conservative: there must be no known Sword swap left, no
hypothetical UNKNOWN Sword completion, and no concentrated collapse through a
known Sword danger/support region. The integer `danger_score` keeps the reasons
visible; it is not a hidden boolean-only rule.

Sword danger regions are generated from aligned Sword pairs at spans 1-3 in
rows and columns. Thus `(r,c)` / `(r,c+2)` is handled as one instance of the
general detector rather than a hard-coded coordinate case.

## Exact BASIC order

1. `EVOLVE` when priority is EVOLUTION, an evolution pet is actually selected,
   Fusion has not succeeded, the runtime Fusion state and exact runtime card
   slot are available, and mana covers the current runtime cost. It
   consumes no turn and requires a fresh state read. ATTACK priority disables
   evolution for the match. Low-boss-HP mode (boss current HP at or below the
   enabled `cast_when_boss_hp_below` threshold) also disables EVOLVE, regardless
   of mana priority, so the bot spends the endgame on Sword/Mana/CAST. EVOLVE
   also has a separate inclusive `minimum_evolve_time_seconds` floor (default
   10): below it, Step 1 is deferred for that turn and normal Sword/resource
   selection continues. This preserves enough time for the server response,
   animation settlement, a fresh read, and the same-turn consuming action.
   If no evolution pet was selected, EVOLVE is skipped and board policy
   continues; this is not an automation stop.
2. If any deterministic result collects Sword, restrict selection to that
   group. Rank no Sword potential left, effective Sword, known combo, danger,
   then UNKNOWN exposure.
3. Finisher: with no Sword result on the board, boss **current** HP at or below
   `cast_when_boss_hp_below` (default 30000), and one affordable proven Attack
   card, `CAST` immediately. This branch deliberately ignores the 480 stockpile
   rule — it exists to close out a match instead of hoarding mana.
   `cast_when_boss_hp_below=0` disables the whole low-boss-HP mode.
   While that mode is active but CAST is not yet affordable/proven, select safe
   Mana before safe Rage. Outside that mode, with Rage below `rage_target`,
   select safe Rage; else safe Mana.
4. With boss HP above 50%, select safe Health below `low_hp_ratio_simple` own
   HP for SIMPLE or `low_hp_ratio_careful` for CAREFUL.
5. Above `cast_mana_stockpile_threshold` mana, select a proven interactable
   Attack card with a proven runtime slot (`CAST`), preserving the 320-mana
   reserve after its 160 cost. If no Attack card is equipped, all CAST branches
   are skipped and the same board policy continues.
   Otherwise select safe Drain only when boss Mana >`boss_high_mana` and Rage
   >`boss_high_rage`, or safe Shield only when both are <`boss_low_resource`.
6. `PASS` is possible only when no safe move exists and a durable game-owned
   skip count proves another pass is legal.
7. First runtime local turn or a game-owned count of two passes prohibits
   PASS. Select minimum Sword danger, with Shield as a tie-break.

If exhaustive simulation finds zero legal swaps, the result is `EXIT_MATCH`.
Phase 2C.2A only logs that proposal.

For a failed Fusion attempt, BASIC does not permanently mark evolution as
tried. The same turn is blocked by `LocalFusionLockedThisTurn`. A later proposal
is allowed only after the server response and a fresh state where Fusion is
unused, unlocked and actually actionable, with sufficient mana. Success,
insufficient mana, or failed actionability stops the proposal. Phase 2C.2A.3.1
still does not execute the proposal.

Runtime execution addendum (Stage B5): after a terminal EVOLVE response,
policy is still evaluated in the same turn. If that decision is PASS, the
executor sends no additional input but classifies the remainder as an
`EVOLVE-only turn`, not an intentional PASS. Live evidence covers both Fusion
success and failure: the server may advance either turn without an AFK warning
because the EVOLVE attempt itself is activity. Numeric idle state continues to
come only from server payloads; the next local turn requires a fresh full-state
reread.

If an input was sent but its response/ACK is not captured before the bounded
deadline, the executor does not relabel it as rejected and does not resend the
physical input. It may extend the read-only observation window once when the
exact source turn is still local and has safe time remaining. Otherwise it
records `ACTION_OUTCOME_UNCONFIRMED`, suppresses further input for that source
turn, and waits for authoritative turn/AFK state. No local idle counter is
incremented.

## Explicit fail-closed gaps

- Game-owned consecutive-pass state is currently `UNKNOWN`. The client event
  carries `idleCount/threshold`, but this build does not persist it in a proven
  field. Autonomous PASS is therefore blocked; no local counter replaces it.
- Intermediate boss resource states are not defined by the user. If safe moves
  exist but no exact branch selects one, BASIC returns `NONE` with
  `BASIC_INTERMEDIATE_FALLBACK_UNDEFINED` instead of inventing a preference.
- Exact exit UI/action state is outside this phase; `EXIT_MATCH` is log-only.
- REASONING semantics remain intentionally undefined.

## Decision trace

Every result records selected action/step, candidate count, selection reason,
failed higher branches, all candidate resource/cascade/risk metrics, selected
candidate, skip state/source, first-turn state, timer state/source, and any
blocker.
