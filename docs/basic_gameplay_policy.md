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
hypothetical Sword completions through exposed UNKNOWN cells. It also tests
every legal opponent reply on the settled result and reports direct Sword
replies plus non-Sword direct matches whose known collapse chain collects
Sword indirectly. UNKNOWN exposure is checked in both directions: a spawned
Sword may create a reply, and an adjacent Sword already present in the 64 known
cells may move into a non-Sword refill slot to complete match-3.

`safe` is conservative: the direct clear must be calculable (screen row 3 or
lower), there must be no known direct or indirect deterministic opponent Sword
reply, no disallowed hypothetical UNKNOWN Sword completion, and no concentrated
collapse through a known Sword danger/support region. A top-area clear that
introduces UNKNOWN refill is never promoted to safe merely because one
hypothetical refill test found no Sword. The integer `danger_score` keeps the
reasons visible; it is not a hidden boolean-only rule.

The unique-adverse-Sword exception has a separate `SwordHoldEvaluation`. A
candidate must collect no Sword itself, and replaying every known boss Sword
reply must leave a strictly larger deterministic Sword follow-up for us. Such a
candidate remains `safe == false`; UNKNOWN never supplies favorable evidence.

Sword danger regions are generated from aligned Sword pairs at spans 1-3 in
rows and columns. Thus `(r,c)` / `(r,c+2)` is handled as one instance of the
general detector rather than a hard-coded coordinate case.

## Exact BASIC order

1. From the second local turn onward, `EVOLVE` when priority is EVOLUTION, an
   evolution pet is actually selected,
   Fusion has not succeeded, the direct `MatchService` Fusion state and exact
   `Board.selectedCards/cardsInHand` runtime slot are available, and mana
   covers the current runtime cost. A live `FusionCardUI` is preferred but is
   not required when those direct owners agree; a current visual tile proof is
   still required immediately before input. It
   consumes no turn and requires a fresh state read. ATTACK priority disables
   evolution for the match. Low-boss-HP mode (boss current HP at or below the
   enabled `cast_when_boss_hp_below` threshold) also disables EVOLVE, regardless
   of mana priority, so the bot spends the endgame on Sword/Mana/CAST. EVOLVE
   uses the same inclusive production action floor (currently one displayed
   second) as normal gameplay; it is not silently postponed by the former
   ten-second follow-up floor. At authoritative idle 2/3, EVOLVE is still
   deferred because only a consuming SWAP/CAST can prevent ejection.
   If no evolution pet was selected, EVOLVE is skipped and board policy
   continues; this is not an automation stop.
2. If any deterministic result collects Sword, normally restrict selection to
   that group. Rank no direct/indirect opponent Sword reply, effective Sword,
   known combo, danger, then UNKNOWN exposure. If there is exactly one Sword
   move and it leaves a deterministic opponent Sword reply worth more effective
   Sword than it collects, defer that move. Continue normal safe-resource
   branches first; otherwise use an authoritatively permitted PASS. If PASS is
   unavailable, a proven off-region Sword-hold may be used. On a mandatory turn,
   PASS is prohibited; prefer a proven Sword-hold, else choose minimum Sword
   risk. No ordinary unsafe move is promoted by this exception.
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
5. Above `cast_mana_stockpile_threshold` mana, select a proven Attack card
   with a proven runtime slot (`CAST`), preserving the 320-mana
   reserve after its 160 cost. If no Attack card is equipped, all CAST branches
   are skipped and the same board policy continues.
   The standard zero-cooldown Attack card may be authorized by exact current
   `Board.selectedCards` metadata plus the matching `cardsInHand` cardinality;
   a live `CardUI/Button` remains stronger evidence when available. Non-zero
   cooldown cards without a live wrapper fail closed. Every CAST still needs
   current mana, current-turn capability, exact strip position, and a visual
   proof of that tile just before the normal foreground click.
   Otherwise select safe Drain only when boss Mana >`boss_high_mana` and Rage
   >`boss_high_rage`, or safe Shield only when both are <`boss_low_resource`.

6. `PASS` is possible only when no safe move exists and a durable game-owned
   skip count proves another pass is legal.
7. First runtime local turn or a game-owned count of two passes prohibits
   PASS. Select minimum Sword danger, with Shield as a tie-break.

## Turn / energy accounting

One distinct local `MatchService.TurnNumber` is counted as one turn and one
energy for the match. Polling the same server turn repeatedly never increments
the count. EVOLVE is non-consuming, so EVOLVE followed by SWAP on the same
local turn costs one; CAST, SWAP, or an authoritative PASS ends that local
turn. Each completed attempt records `localTurns`/`energyUsed`. The desktop
Control tab shows completed per-match counts, the current match's live local
turn/energy count, and `Total energy` on separate lines. Live projection uses
the already deduplicated TurnNumber observation; it adds no memory scan,
screen capture, solver pass, or input delay.

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
