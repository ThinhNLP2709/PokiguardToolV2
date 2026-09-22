# Phase 2C.2A BASIC gameplay policy

## 1.7.4-b2 Phase 2 repair — 2026-09-11

The default `NORMAL / NORMAL / DEFAULT_ATTACK` run and ordinary Evolution are
Phase 2 gameplay. The current repair is reopened and awaits a user live retest;
it is not a Phase 3 acceptance or closeout.

Reverse b2 adds a game-owned `TurnAnnouncer.IsBlockingInput` condition to
`Board.IsPlayerAllowedToMove`. The provider now reads the exact static
`TurnAnnouncer._blocking +0x80` through TypeInfo RVA `0x2DDAE68`; while true,
actionability reports `PRESENTATION_BUSY`. It does not guess a fixed sleep.

Two live failure classes are also separated. A policy `PASS` requires a fully
published board and no proven safe move. An ACK whose exact board snapshot was
missed is a transport-capture gap, so the dispatcher path attempts bounded
raw-board, b2 typed `ChatMessageDTO.preBoard`, then legacy DTO-payload recovery
and permits one 64 MiB rotating scan of regions
learned before entry for that exact `(match, turn, ACK)`. Full heap scans are
forbidden after a match becomes active, including PASS wait and opening
preload. Technical deadline expiry is never relabeled as a third policy PASS.

The user's 15:02:48 board is an exact policy regression fixture. Default
Evolution at 135 Mana/current cost 120 proposes `EVOLVE`; after Fusion is used,
the same state proposes screen `(0,1)<->(1,1)` at `STEP_2_SWORD`. The live
failure had no policy decision for that turn, which classifies it as capture
loss rather than a legal Sword move being ranked below PASS.

Board capture does not perform card discovery. The opening action uses the
lobby card expectation/cache; optional CardUI/FusionCardUI discovery begins
only after the opening action and stays on its own validated owner path. The
latest diagnostic run performed zero extended card, card-owner and
fusion-owner scans while the slow board-recovery loop was reproduced.

## Scope

The policy layer is proposal-only. `BasicPolicyEngine` produces `EVOLVE`,
`CAST`, `PET_SKILL`, `SWAP`, `PASS`, `EXIT_MATCH`, or `NONE` plus a
`DecisionTrace`. It contains no
mouse input, card click, exit click, game method call, process write, or
network path.

The current user-facing configuration is:

- `PlayStyle`: `SIMPLE`, `CAREFUL`, optional `SKILL_RUSH` (UI:
  `Chịu đấm ăn xôi`);
- `MainPetType`: `NORMAL`, `LEGENDARY`; `MEGA` is visible but disabled and
  `EVOLVED` is no longer shown because it duplicates the current Legendary
  skill/Audition semantics;
- `EvolutionTarget`: `NONE`, `NORMAL`, `LEGENDARY`; `MEGA` is visible but
  disabled and `EVOLVED` is no longer shown;
- `DamageCardMode`: `DEFAULT_ATTACK`, `PET_SKILL` where a conceptual source
  exists;
- `PetSkillFireCondition`: runtime-cost readiness or current known effective
  board value, including x1/x2/x3/x4, for `SWORD`, `MANA`, `RAGE`, `DRAIN`, or
  `SHIELD`;
- `pet_skill_fire_value`: optional integer `0..256`; unused for runtime-cost
  readiness. The Desktop row is `Điều kiện ra skill`, and count readiness uses
  inclusive `>=`; default is `sword_count / 10`;
- `Intelligence`: `BASIC`, `REASONING`.

Canonical production policy now receives the three Phase 3A.2 profile fields.
`ManaPriority` remains only as a compatibility bridge for old direct fixtures
and checkpoints. All supported single-source profiles map to FarmRunner. A
Legendary main pet may use `NONE` or `NORMAL` evolution. A normal main pet may
use `NONE`, `NORMAL`, or `LEGENDARY`; the latter can select Pet Skill because
Fusion creates the single source. `LEGENDARY/LEGENDARY` is invalid until the
Damage selector can identify one of its two cards.

The user-authored gameplay rules these steps implement live in
`docs/gameplay_rules.md`, which is the source of truth for behaviour. Every
numeric threshold is a `PolicyConfig` field; see that file's table for the CLI
flags.

Only `BASIC` is implemented. Selecting `REASONING` returns `NONE` with
`REASONING_NOT_IMPLEMENTED`.

## Phase 3C.1 Pet Skill order

For every profile with exactly one Pet Skill source, a present skill first
requires a unique current-session `PetSkillCapability`, a supported
automatic-dot skill family, positive effective Mana/Rage requirements and
known live CardUI actionability. Missing, stale, ambiguous or unsupported
evidence returns `NONE`; it never becomes ordinary CAST or guessed resource
play. For `NORMAL / LEGENDARY / PET_SKILL`, the card does not exist before
Fusion succeeds, so policy temporarily uses only the proven runtime Fusion
Mana cost, never requires or clicks a skill card early, then applies the same
capability rules after the mandatory fresh-state read.

The implemented branch order is:

1. If current Mana/Rage meet the runtime capability cost and the live card is
   actionable, propose turn-consuming `PET_SKILL` with only session and card ID
   identity. The executor rediscovers the live CardUI before input.
2. Otherwise preserve the complete accepted Sword branch and all of its
   deterministic/UNKNOWN/reply safety rules.
3. If Mana or Rage is missing, compare only Sword-safe deterministic moves that
   advance a current deficit. Rank requirements completed after the move,
   normalized closed deficit, existing danger/cascade/UNKNOWN tie-breaks, then
   the stable move identity. A sufficient resource and UNKNOWN refill receive
   zero readiness credit.
4. Preserve Health, Drain and Shield branches in their existing order. Both
   low-HP finisher CAST and stockpile CAST are prohibited in this profile.
5. Preserve authoritative PASS and mandatory consuming-action rules. PET_SKILL
   itself satisfies turn consumption, but it never synthesizes an idle reset.

The accepted HT7 and HT2 costs remain fixtures at 200/200 and 200/150. Policy
reads `effective_mana_cost`/`effective_power_cost`; it contains no Legendary
rarity cost constant. Net post-skill resources never authorize a later action.

## Current `SKILL_RUSH` order (Phase 3D.1-R1)

The optional `SKILL_RUSH` branch is accepted for BASIC configurations with
`PET_SKILL` and exactly one conceptual source. The serialized identity is
`skill_rush` and the Desktop label is `Chịu đấm ăn xôi`. SIMPLE remains the
default.

After the unchanged combat/actionability and Pet Skill capability gates:

1. While Mana or Rage is missing, rank known progress toward only the current
   deficits. A Sword-safe progress move is preferred when one exists. If none
   exists and player HP is known above 30%, take the best Sword-preserving
   Mana/Rage progress even when it may leave Sword for the boss; resource
   completion precedes Drain, Shield and turnover. At or below 30% HP, or when
   HP is unknown, safe protection/survival remains ahead of an unsafe resource
   move. Full resources and UNKNOWN refill receive zero readiness credit.
2. Evaluate the selected normal Pet Skill condition. `skill_cost_ready` uses
   authoritative current skill-resource readiness and no number. Count choices
   use only the current accepted known `SWORD`, `MANA`, `RAGE`, `DRAIN`, or
   `SHIELD` cells and sum their proven multipliers with inclusive
   `known_effective_count >= pet_skill_fire_value`. UNKNOWN adds zero. Range is
   `0..256`; default/migration is `sword_count / 10`. A skill
   fires only when actual current runtime resources, the selected condition and
   all technical/actionability gates pass. Boss HP does not authorize a normal
   first skill.
3. Every pre-first-skill SWAP has `known_sword_consumed == 0`, regardless of
   current Rage. During resource collection, direct, indirect and UNKNOWN boss
   Sword replies rank safe Mana/Rage progress first but do not let Drain or
   Shield displace missing-resource progress while HP is above 30%. During
   setup they remain hard candidate filters whenever a safe preserving action
   exists.
4. When no missing-resource move exists and player HP is known above 30%,
   choose the lowest-risk non-Sword action in this order: Drain, Shield, then
   other turnover. At or below 30% HP, or when HP is unknown, prefer a
   non-Sword Shield then Health action. Only after those survival choices may
   the policy use an authoritative PASS. When PASS is prohibited, choose the
   lowest-risk non-Sword mandatory action to reset the idle streak. If every
   legal move consumes Sword, fail closed with `SKILL_RUSH_ONLY_SWORD_MOVES`.
5. `skill_cost_ready` skips board setup. For a count condition, setup preserves
   both known Sword and the selected condition GemType. Within the safe pool,
   direct clears at Manhattan distance at least 2 from every known Sword are
   preferred; distance never substitutes for direct, indirect and UNKNOWN
   Sword-reply checks. An UNKNOWN refill that can immediately complete a known
   Sword pair is a setup-preservation hazard even though that auto-match is not
   an opponent reply. Prefer breaking remaining Sword opportunities, then
   Drain/Shield resource protection among otherwise safe candidates. If no safe
   preserving setup exists, use an authoritative
   `SKILL_RUSH_SETUP_PASS` while allowed. When PASS is prohibited, choose the
   lowest-risk preserving non-Sword action. If every legal move consumes Sword
   or the selected setup GemType, fail closed with
   `SKILL_RUSH_ONLY_SETUP_CONSUMING_MOVES`.
6. After the first current-match `SUCCESS_PERFECT`, the exact source turn stays
   closed. On a later authoritative local turn, fresh boss HP ratio `<= 30%`
   enables `POST_SKILL_FINISHER`: affordable ordinary Attack first, otherwise
   deterministic Sword damage. Any configured Evolution has already been
   resolved by the shared pre-play-style branch and cannot repeat after
   `Fusion.used`.
7. If the surviving boss is above 30%, ordinary Attack and Sword remain blocked
   and resource/setup play resumes. A later second Pet Skill is legal only when
   runtime resources and the same selected generic fire condition become ready.
8. Successful-skill history is held only for the exact `CombatSessionKey`; it
   is neither global nor checkpoint-persisted. PASS remains authoritative and
   unchanged.

Boss HP remains diagnostic before the first skill and authoritative for
terminal/result truth, separately proven hard survival, and the post-skill
finisher only. `CandidateTrace.hard_survival_status` is currently
`UNKNOWN_NO_LETHALITY_MODEL`: the simulator proves board/Sword outcomes but has
no authoritative next-hit damage model. The policy therefore does not invent a
lethality gate. Technical safety gates remain hard. SIMPLE/CAREFUL continue through the Phase
3C.1 Sword-first branch without any ranking or Attack-rule change.

## Runtime gates

A proposal requires a stable combat `GameState`, proven local turn,
`client_move_allowed == True`, and a readable turn timer. The timer fields are:

- `turn_duration_seconds`: `MatchService.TurnDurationSec +0x44`;
- `turn_time_remaining_seconds`: latest server tick at
  `MatchService.TurnTimeRemainingSec +0x138`;
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

`safe` requires no known direct or indirect deterministic opponent Sword reply
and no disallowed hypothetical UNKNOWN Sword completion. `calculable` and
collapse/support overlap remain visible in `danger_score` and candidate
ranking; the broad support-region heuristic does not veto a move whose exact
settled-board and UNKNOWN checks both prove zero effective Sword. A bounded
horizontal refill may be accepted only under its existing one-cell-per-column
rule. This distinction fixes the reported live board where a safe Mana swap
had `collapse_support_hazard=2` but zero direct, indirect and UNKNOWN Sword
reply.

The unique-adverse-Sword exception has a separate `SwordHoldEvaluation`. A
candidate must collect no Sword itself, and replaying every known boss Sword
reply must leave a strictly larger deterministic Sword follow-up for us. Such a
candidate remains `safe == false`; UNKNOWN never supplies favorable evidence.

Sword danger regions are generated from aligned Sword pairs at spans 1-3 in
rows and columns. Thus `(r,c)` / `(r,c+2)` is handled as one instance of the
general detector rather than a hard-coded coordinate case.

## Shared Evolution branch and exact BASIC order

1. Before every play-style branch, `EVOLVE` when canonical Evolution is not
   `NONE`, Fusion has not succeeded, the direct `MatchService` Fusion state and
   exact `Board.selectedCards/cardsInHand` slot are available, and Mana covers
   the current positive runtime cost. A live `FusionCardUI` is preferred but is
   not required when those direct owners agree; a current visual tile proof is
   still required immediately before input. Opening turn, low boss HP and an
   authoritative mandatory-consuming state do not demote EVOLVE. It consumes
   no turn and requires a fresh state read; the selected play style must then
   produce the consuming action for that same local turn. EVOLVE uses the same
   inclusive production action floor as normal gameplay plus its configured
   same-turn response/follow-up floor. If no evolution pet was selected, cost
   or authority is unavailable, or Mana is insufficient, board policy
   continues. For a pending Legendary evolution Pet Skill, only the proven
   Fusion cost supplies the temporary Mana deficit; after success, the new
   CardUI/cost/capability are rediscovered and the configured Pet Skill fire
   rule remains in force.
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
   After a successful evolution, exact current native CardUI/Button rectangles
   resolve the ordinary selected-card slots independently of Pet Skill
   discovery. A missing Pet Skill data pointer disables only Pet Skill; it does
   not hide a separately owned and located Attack CardUI.
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
local turn costs one; CAST, PET_SKILL, SWAP, or an authoritative PASS ends that
local turn. After Pet Skill input the source turn is permanently fenced and
FarmRunner waits for boss turn, terminal, or a fresh later local turn. Each
completed attempt records `localTurns`/`energyUsed`. The desktop
Control tab shows completed per-match counts, the current match's live local
turn/energy count, and `Total energy` on separate lines. Live projection uses
the already deduplicated TurnNumber observation; it adds no memory scan,
screen capture, solver pass, or input delay.

If exhaustive simulation finds zero legal swaps, the result is `EXIT_MATCH`.
Phase 2C.2A only logs that proposal.

For a failed Fusion attempt, BASIC does not permanently mark evolution as
tried. The same turn is blocked by `LocalFusionLockedThisTurn`. A terminal
result is either an exact `MATCH_FUSION_RES` or the equivalent durable
MatchService transition: a newly recorded current `LocalFusionLastAttemptTurn`,
current-turn lock and `LocalFusionUsed=false`. After that terminal failure and
the existing 3.5-second presentation settle, policy reads fresh state and may
still choose a consuming SWAP/CAST in the same turn. A later EVOLVE proposal is
allowed only on a fresh later turn where Fusion is unused, unlocked and actually
actionable, with sufficient mana. Success, insufficient mana, or failed
actionability stops the proposal.

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
physical input. EVOLVE may finish earlier when the exact durable success or
failure transition above is present. Without a response or such a terminal
equivalent, it may extend the read-only observation window once when the exact
source turn is still local and has safe time remaining. Otherwise it records
`ACTION_OUTCOME_UNCONFIRMED`, suppresses further input for that source turn, and
waits for authoritative turn/AFK state. No local idle counter is incremented.

For an intentional PASS, the callback dispatcher and the bounded response scan
are both complete read-only observation paths. If MatchService has advanced
through the opponent turn and returned to the next local turn, two complete
samples without a correlated AFK payload terminate `PASS_WAIT` as
`PASS_STATE_UNCONFIRMED`. Production B5 does not infer an idle count from that
absence. It conservatively prohibits another PASS and EVOLVE, then requires a
consuming SWAP/CAST on the current board; minimum-risk mandatory selection is
used when no safe move exists. This breaks the possible idle chain while
preserving server payloads as the only numeric idle source.

## Explicit fail-closed gaps

- Game-owned consecutive-pass state is currently `UNKNOWN`. The client event
  carries `idleCount/threshold`, but this build does not persist it in a proven
  field. Autonomous PASS is therefore blocked; no local counter replaces it.
- A healthy dispatcher poll is not proof that every callback was captured. If
  the current ACK advances but its exact board is absent, one bounded recovery
  attempt is permitted for that exact gap. Repeated full scans remain blocked,
  and no missing snapshot is interpreted as “no safe move”.
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
