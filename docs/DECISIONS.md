# PokiguardToolV2 Product and Gameplay Decisions

This is the canonical list of gameplay/product decisions defined or approved
by the user. Agents must not silently rewrite these rules.

Technical implementation and acceptance status are in
[CURRENT_STATE.md](CURRENT_STATE.md). Workspace/safety precedence begins with
[AGENTS.md](../AGENTS.md).

## Product Goal

PokiguardToolV2 automates Pokiguard gameplay through:

- external, read-only game-state acquisition;
- the project's own deterministic simulator/solver/policy;
- normal foreground Windows UI input.

The product is not designed around editing game state or invoking hidden game
actions directly. CV remains available as fallback/audit capability, not the
primary production board source.

## Safety and Technical Boundaries

Allowed scope includes external process reading with the minimum read/query
rights required by the project.

The following are prohibited unless the user explicitly changes scope in a
future task:

- `WriteProcessMemory` or any other process-memory write;
- DLL injection, hooks, or remote-thread execution;
- game binary/data patching or file replacement;
- direct gameplay IL2CPP method calls;
- direct `RequestSwap`;
- direct `MatchService.SendMove`;
- direct use of the game's `enableAutoMove` behavior;
- packet/network manipulation, replay, repair, or sequence forging;
- HP, damage, reward, or other game-state modification;
- anti-cheat bypass.

Gameplay input is normal Windows user input only. `PokiguardAuto` is reference
only, and `pc` is strictly read only, as defined in `AGENTS.md`.

## Gameplay Configuration

The exact user-facing dimensions are:

```text
PlayStyle:
- SIMPLE
- CAREFUL

ManaPriority:
- EVOLUTION
- ATTACK

Intelligence:
- BASIC
- REASONING
```

`BASIC` is defined. `REASONING` is intentionally undefined and not
implemented. An agent must not invent REASONING behavior.

## Gem Definitions

- `SWORD` — damage/offensive gem and highest gameplay objective.
- `MANA` — mana resource used by Evolution and card actions.
- `RAGE` — Rage/Power resource with a tactical breakpoint and hard maximum.
- `SHIELD` — defensive Shield resource.
- `HEALTH` — HP recovery resource; keep the canonical name `HEALTH`, not
  `HEAL`.
- `DRAIN` — opponent-resource drain objective governed by the boss-resource
  rules below.

Each cell also carries its gameplay multiplier: `x1`, `x2`, `x3`, or `x4`.
Multiplier follows the gem through deterministic swaps/gravity and contributes
to effective collected value.

## Evolution

- Current accepted/observed Evolution cost is 160 Mana.
- Production input must still read an actual positive runtime Fusion cost; it
  must not guess 160 when runtime cost is unavailable.
- With `ManaPriority=EVOLUTION`, if Fusion has not succeeded, the live action is
  safely actionable, and Mana is sufficient, keep trying until success under
  the response/lock/fresh-state safety contract.
- A failed attempt may retry only after the current-turn lock clears and fresh
  actionable state permits it; no tight loop.
- With `ManaPriority=ATTACK`, do not evolve during that match.
- While the boss current HP is at or below the enabled configurable low-HP
  threshold (`cast_when_boss_hp_below`, default 30000), do not evolve even when
  `ManaPriority=EVOLUTION`; preserve mana for the Sword/Mana/CAST finisher path.
- EVOLVE is a functional action and does not consume the gameplay turn.
- After successful EVOLVE, reread full `GameState`; a consuming SWAP or CAST
  may still occur in the same turn.
- Do not claim that EVOLVE resets idle/PASS. Its reset semantics remain
  UNKNOWN until authoritative evidence changes that classification.
- `Board.cardsInHand` may select the bounded allocation regions used to
  discover the current `FusionCardUI`: reverse evidence proves that
  `FusionCardUI.Spawn` returns a GameObject which `Board.LoadSelectedCards`
  appends to this current Board-owned list. This anchor does not itself make a
  card actionable. The exact Fusion class, native object, Button pointer and
  `Button.interactable` state must still validate; zero or ambiguous validated
  candidates fail closed and board gameplay continues.

## CAST / Chưởng

- CAST consumes one gameplay turn.
- After an accepted CAST, no board SWAP may occur in the same turn.
- Resolve the current owned/interactable ATTACK card dynamically. Card ID `4`
  is observed data, not a product rule.
- The cost must come from current runtime card data; observed accepted cost is
  160 Mana.
- The normal BASIC CAST branch requires player Mana strictly greater than 480,
  preserving the accepted 320-Mana reserve after the observed 160 cost.
- Low-boss-HP mode is the explicit exception: after Sword priority, when boss
  current HP is at or below the enabled configurable threshold, CAST as soon as
  a proven current Attack card is affordable. If it is not yet affordable,
  prefer safe Mana before safe Rage. Threshold `0` disables this mode.
- A rejected or unproven CAST is not a successful consuming reset.
- CAST idle-reset semantics remain UNKNOWN for production PASS decisions
  unless a separately audited capability proves them.

## PASS

- The game permits bounded consecutive idle/PASS behavior.
- PASS is a gameplay decision that sends **zero gameplay input**.
- The source of truth must be game/server-owned state. Never use a local
  gameplay counter as authoritative and never synthesize numeric zero.
- The first local turn cannot PASS.
- The authoritative threshold comes from server payload; runtime acceptance
  observed `1/3` and `2/3`.
- At the state equivalent to `2/3`, the next action must consume the turn. A
  third PASS is prohibited.
- SWAP or accepted CAST may satisfy the mandatory consuming action. EVOLVE
  alone does not.
- A rejected/unproven action does not count as a successful reset.
- `ACTION_RESPONSE_TIMEOUT` alone proves neither rejection nor acceptance and
  never authorizes a local idle increment. The controller may retry read-only
  response observation once while the exact source turn still has safe time;
  it must not resend the uncertain physical input. If still unresolved, record
  `ACTION_OUTCOME_UNCONFIRMED`, suppress more input for that source turn, and
  wait for authoritative turn/AFK evidence.
- A sequence-desync rejected action definitely must not be treated as reset.
- UNKNOWN, stale, missing, or uncorrelated authoritative PASS state fails
  closed.
- SWAP reset is production-proven. CAST and EVOLVE reset semantics remain
  UNKNOWN and must not be promoted by inference.

## Sword Strategy

- Sword is the highest gameplay priority.
- Do not evaluate only the immediate/direct match. Evaluate deterministic
  related moves and cascades that collect Sword.
- A non-Sword immediate match may be the preferred Sword path when a known
  cascade collects the better Sword outcome. The accepted regression is a
  Mana direct clear followed by a deterministic Sword cascade; see
  [Phase 2C.2A.1 runtime audit](phase2c2a1_runtime_audit.md#sword-audit).
- If several Sword paths exist, prefer the path that avoids leaving known Sword
  match potential for the boss.
- When no clean path exists, collect as much/useful Sword as possible while
  minimizing deterministic danger and UNKNOWN exposure.
- Simulate deterministic consequences available from the known 64-cell board;
  do not award credit for unknown off-board spawns.

## Sword Danger and Safe Moves

Strategy concepts:

- A Sword-danger region is a known aligned Sword structure that can become a
  boss Sword match through a gap/support change.
- A potential Sword match is a deterministic known-board opportunity left
  after the simulated move.
- A safe move has no known Sword swap left, no hypothetical Sword completion
  through exposed UNKNOWN cells, and no concentrated collapse through a known
  Sword danger/support region under the accepted model.
- A dangerous move violates one or more of those safety conditions. Danger is
  ranked; it is not one undifferentiated boolean.
- Horizontal moves are generally more predictable because they do not create
  vertical refill depth merely by orientation.
- Vertical collapse can expose unknown top-board spawn.
- Lower-board moves can have more deterministic known collapse before an
  unknown refill affects the result.

These are strategy/ranking concepts. No rule says every horizontal move is
safe or every vertical move is dangerous.

## Rage

- Maximum Rage is 250.
- The tactical breakpoint is 100.
- Below 100, safe Rage has high priority when the higher Sword/Evolution rules
  do not win.
- For `100 <= Rage < 250`, Rage is not necessarily above Mana, but it remains a
  valid safe-resource fallback.
- At max Rage, do not collect Rage solely for Rage value. A move may still win
  because of Sword, deterministic cascade/combo, another resource, safety, or
  a mandatory consuming-action requirement.

## Mana

- Under `ManaPriority=EVOLUTION`, Mana supports repeated safe Evolution
  attempts until success when the runtime action is eligible.
- Under `ManaPriority=ATTACK`, Evolution is disabled for that match and Mana is
  retained for the dynamic ATTACK-card rule.
- Outside a higher Sword/Rage branch, safe Mana is the normal resource choice
  before the health/card/boss-resource branches.
- In low-boss-HP mode, safe Mana moves ahead of safe Rage after Sword and an
  immediately affordable CAST have both failed.
- CAST requires the dynamic runtime card cost. The strict `Mana > 480` reserve
  rule applies outside the explicitly approved low-boss-HP finisher mode.
- A full resource must not be chosen solely to add more of that same resource;
  another accepted objective must justify the move.

## Health

Health is low at:

```text
SIMPLE:  current HP < 30% max HP
CAREFUL: current HP < 50% max HP
```

The normal Health branch also requires boss HP >50% and a safe Health move.
If all remaining safe resource results are Health-only, select the most
predictable/calculable safe Health move rather than PASS solely because the
normal low-HP branch is false.

## Drain and Shield

- If boss Mana >160 **and** boss Rage >100, prefer a safe Drain move.
- If boss Mana <50 **and** boss Rage <50, prefer a safe Shield move.
- For intermediate known boss-resource states, prefer safe Shield over Drain
  when safe Shield is available.
- Drain may be selected outside its high-resource branch when it is literally
  the only Sword-safe move.
- If required boss resource state is UNKNOWN, do not manufacture threshold
  facts. Continue only through another already-defined branch or fail closed.
- If an intermediate case has no safe Shield, the general safe-resource
  fallback below applies; it does not create a new Drain priority.

## Safe Resource Fallback

After all higher strategic/resource branches fail, safe resource candidates
may still be used so that PASS remains reserved for a board with no Sword-safe
move.

Rules:

- safe candidates only;
- never relabel a dangerous move as safe to force progress;
- do not select a resource at max solely for its own value;
- safe Rage remains a valid fallback while below max 250, including when Rage
  is already >=100;
- select deterministically by the accepted least-risk model: lower Sword
  danger/potential first, then Shield benefit, lower UNKNOWN exposure, useful
  total result, predictability/orientation, and stable coordinate tie-breaks;
- do not randomize.

The current branch order is detailed in
[BASIC gameplay policy](basic_gameplay_policy.md) and the current implementation
[basic_policy.py](../src/pokiguard_v2/basic_policy.py). Older report statements
that all intermediate-resource states return `NONE` are superseded.

## Mandatory Action

PASS is prohibited in these canonical cases:

- first local turn;
- authoritative PASS threshold reached (`2/3` in accepted runtime evidence).

Use a normal safe consuming SWAP/CAST when available. If no normal safe action
exists, select the least-dangerous legal consuming action using the accepted
Sword-risk/Shield/UNKNOWN/determinism ranking. EVOLVE may occur first but does
not satisfy the consuming lock. Do not randomize.

## No-Legal-Move Bug

The current game version may fail to refresh when the board has zero legal
match-producing adjacent swaps. The only technical definition is the
exhaustive simulator result on an ACTIVE/current/stable 64-cell board:

```text
legalMatchProducingMoves == 0
```

Do not confuse `legal=0` with `safe=0 but legal>0`. Policy `NONE`, PASS, or all
moves being dangerous does not prove the no-legal-move bug.

## Sequence Desync

If a server/client sequence desync is detected:

- stop gameplay input for the current session;
- discard pending proposals and do not retry the rejected action;
- do not repair memory, ACKs, packets, or sequence numbers;
- do not treat the rejected action as a PASS reset;
- recover only through the approved normal UI/lifecycle flow.

## Farm Target and Product Loop

The current Phase 2D acceptance fixture is:

```text
Starburst
ID = 1289
```

Starburst 1289 is not the product's fixed farm target. It is the currently
known exact identity used to validate entry and one bounded farm cycle.

The intended product behavior is:

```text
user enters/selects the pet boss to farm in BOSS_LOBBY
-> user presses Start in the tool
-> tool resolves that exact current/configured target
-> entry -> autonomous BASIC combat -> return to BOSS_LOBBY
-> repeat until the user stops or a safety condition safe-stops the controller
```

Target resolution must remain exact and runtime-validated. Do not click the
first boss, fuzzy-match loosely, assume the previous selection, or hard-code a
screen coordinate. CLI/configuration is an acceptable intermediate target
source; the final tool should obtain/confirm the user's current target choice
at Start.

For the Desktop UI, the user is not required to know or enter a pet ID. An
explicit Start/Resume made while the exact `CHINH_PHUC_ROOM` is proven pins
that room's positive numeric runtime `enemyPetId` and name into the immutable
FarmRun config. `WORLD_BOSS_LIST`, a missing/invalid pet ID, or ambiguous room
identity keeps Start/Resume disabled and is revalidated again by the backend.
Preferences never provide target authority and do not persist a pet ID.

Desktop Start/Resume also owns the game-window calibration boundary. Before
FarmRunner binds an HWND or sends any normal UI/gameplay input, it must restore
only the verified game PID's window and normalize the client to canonical
`1280x720`. This is the accepted reference size for the current V1-derived
board click calibration. The result must be reread as exact PID, foreground and
exact client dimensions; otherwise Start fails closed. A user-resized game is
therefore supported by normalization at Start, not by trusting stale normalized
tile coordinates. Any later mid-run size change invalidates the window binding
and blocks input.

A SWAP is accepted only from exact durable runtime evidence: the same combat
session, the expected local move-sequence advance, and MatchService LastMove
from/to coordinates equal to the solver's intended cells. A bare `_ackedSeqs`
or general server-sequence advance is diagnostic only because timeout, AFK and
boss activity can advance it after unregistered clicks. It must not complete a
pending SWAP or locally establish an authoritative idle reset.

The pinned pet ID is valid only for that one farm session. If the session loses
the selected Chinh Phuc room and read-only evidence proves settled
`WORLD_BOSS_LIST` with no combat owner, the controller may use the accepted
bounded exact-ID map resolver to select that same pet. The resolver must again
cross-check Button closure identity, cached Group/Pet DTOs, PlayerPrefs panel
selection and two stable visual frames before one normal target-selection
click. It may never choose the first pet, fuzzy-match, or fall back to a saved
preference. A room ejection is a technical abort, never a completed UNKNOWN,
and consumes one bounded technical-recovery slot before normal farming resumes.

When the target count, graceful stop, emergency stop, safety stop, or error ends
the farm session, the live Desktop config clears the pinned pet ID/name. The
completed artifact/checkpoint may retain it only as immutable audit history.
A later Start/Resume again requires the user to be inside an exact boss room and
pins the ID afresh. Automation still does not navigate from the general game
lobby through Chinh Phuc islands to find a boss.

Technical recovery is distinct from map re-entry. While the farm controller
still owns the exact ACTIVE combat session, a proven technical failure may use
the existing bounded normal-UI recovery path to leave combat, return to that
same Chinh Phuc boss room, and start a fresh session before later idle turns can
eject the player. A local-turn controller deadline qualifies only when the same
current snapshot passes the complete production actionability gate: exact
session and turn, local turn, stable/current board, no pending action, no
authoritative PASS/Fusion wait, no animation/modal/end state, connection ready,
valid foreground window, and no sequence-desync overlap. A normal PASS, boss
turn, short lag/reconnect, presentation/cascade wait, foreground loss, or an
unproven/stale state does not qualify. If recovery itself observes that the
room has already been lost to the world boss map, the same exact session-pinned
ID fallback may run only when no recovery re-entry input was already sent;
otherwise it fails closed to prevent duplicate/ambiguous entry.

If recovery has already sent its single normal `Exit + Confirm` pair and then
fails before sending any re-entry/target-selection input, the outer FarmRunner
may continue from the exact pinned Chinh Phuc room instead of stopping. This
requires independent proof of the same positive numeric pet ID, the exact
`CHINH_PHUC_ROOM` branch, and no live combat owner. The failed recovery's old
session, opening, ACK epoch, proposal, and action state are never reused; the
next combat uses the ordinary fresh-entry path and consumes one bounded
technical-recovery slot.

Production uses the user-confirmed **one-second inclusive** action floor. A
SWAP/CAST may still be sent while the authoritative display shows `1`, but only
after the ordinary fresh reread proves the same ACTIVE session, exact local
turn, current board, valid foreground and complete actionability. At `0` the
controller sends no new gameplay input and may dispatch bounded technical
recovery when the exact farm-owned evidence is available.

Run `0d465c3f5d4b40aa94abf62bb0b00b13` recorded two late SWAP inputs at one/two
ticks without ACK before ownership disappeared. This is lag/unconfirmed-action
evidence, not evidence that a displayed `1` is inherently unclickable: the user
has separately confirmed that the game accepts and animates such moves. The
controller must therefore account for a missing ACK as a possible skipped turn
and rely on authoritative idle/reset state, while retaining the one-second
floor. The same floor applies after authoritative idle `2/3`; this is not a new
PASS counter and does not apply to boss turns or unproven/stale state.

An active-run desktop close chooser is presentation only. Opening that modal
must immediately return foreground to the verified game PID while leaving the
chooser visible, because merely asking the operator for Cancel, graceful close,
or emergency close must not consume a local turn. This focus handoff sends no
gameplay input and does not latch either stop edge. Selecting graceful close
then latches the existing stop-after-current-match edge and repeats the game
focus handoff; selecting emergency close keeps the accepted immediate authority
revocation semantics.

Continuous looping is the approved product goal, but it must not be enabled by
silently widening a bounded acceptance phase. First prove the Phase 2D.2
two-entry/one-combat boundary; introduce continuous farming as a separately
reviewed phase with the same lifecycle, session, foreground, and safe-stop
invariants.

## Pre-entry Card Loadout vs Live Combat Cards

Before each `Bắt đầu` input, read and cross-check both persistent lobby-owned
loadout sources:

- `ManagerRoom.selectedCards` (`List<CardData>` at `+0x108`);
- `RoomDTO.cards` (`List<CardData>` at `+0x50`).

Record their exact identities, total count and Attack-card count as the
expected loadout for the next session. This avoids interpreting a later
`cardCount=0` as "the account owns no cards" when the lobby already proves an
equipped card.

The pre-entry loadout is diagnostic/expectation evidence only. A playable card
still requires a newly created `CardUI` whose class, `Board`, `Active`, live
Unity object and `Button` all validate against the current combat. Stale
`CardUI` objects from an earlier match must never become actionable merely
because their `CardData` matches the lobby loadout.

Lobby card lists may be refreshed asynchronously between READY and the final
entry preflight. Re-read and log the latest value, but do not make loadout
identity an entry gate: exact target, room, ButtonStart, foreground and visual
button proof remain the entry invariants. A loadout change never makes a card
actionable and never bypasses the post-entry live-CardUI validation.

`CardUI` heap regions are also session-scoped. Learned regions from a prior
combat are hints only: reset the UI discovery cadence for every new session and
force one full scan of the normal `<=8 MiB` region envelope on the first
observed opponent turn after the mandatory opening action. Only then use
learned-region and bounded extended-band retries.
Live evidence on 2026-08-18 found the missing current cards in newly allocated
118,784-byte and 86,016-byte regions; increasing the 16 MiB ceiling would not
have addressed that miss.

Optional-card discovery is not gated by current Mana. Preserve the mandatory
opening window for authoritative board publication and its first SWAP, then on
the first observed boss turn (`turn >= 2`) perform one current-session warm-up
for all equipped `CardUI` plus the selected pet's `FusionCardUI`. Cache only
exactly validated live wrappers. Current Mana, low-boss-HP mode, cooldown,
game-owned `FusionEnabled`, per-turn lock and Button interactability remain
action gates for CAST/EVOLVE; they must never postpone initial UI discovery.
If the user did not equip an
Attack card or did not select a valid evolution pet/skill card, that action is
simply unavailable and normal board gameplay continues.

When a new/re-entered Chinh Phuc room has cleared
`ManagerRoom.selectedCards`, but `RoomDTO.cards` exposes exactly one owned
ordinary `ATTACK` card and its runtime-indexed room Toggle is proven in two
stable UI frames, FarmRunner must select that Attack card before `Bắt đầu`.
This is one bounded normal lobby click, separately recorded from entry and
gameplay. `RoomDTO.cards` supplies only the exact identity/order used to locate
the Toggle; selection is not accepted until a fresh read proves the same card
inside authoritative `ManagerRoom.selectedCards`. Zero or multiple available
Attack candidates, a changed room/pet/session, unstable pixels, lost
foreground, or failed memory confirmation sends no Start click and fails
closed. Support/function cards do not need to be restored in this milestone.
If no owned Attack card is available at all, card use remains optional and the
existing board-only gameplay fallback applies.

## Agent Non-Invention Rule

When a gameplay situation is not defined by this file or an accepted policy:

```text
DO NOT INVENT A STRATEGY
```

Instead:

- return `UNDEFINED`/`NONE` as the relevant contract requires;
- fail closed or pause the controller;
- capture the current `GameState` and `DecisionTrace`/diagnostic evidence;
- ask the user to define the intended behavior.

Technical evidence alone does not authorize a new gameplay preference.
Update this file only when the user changes a product/gameplay rule or
explicitly approves new policy behavior.

## Pre-MVP Desktop Version Label

The Desktop title and visible product heading use
`Pokiguard Tool V2 - v1.0.0+N`. The current first tracked build is
`v1.0.0+1`; the current local-actor/late-SWAP revision is `v1.0.0+13`. Before MVP completion,
each shipped tool-code revision increments only the build suffix (`+12`, `+13`,
...). The semantic `v1.0.0` component changes
only after the MVP is declared complete and normal release versioning begins.

Preference layout is cluster-based: two sibling clusters share their row 50/50,
while a row with only one cluster spans the full width. A cluster's label keeps
its natural width directly beside its expanding control.

## Technical Recovery Has No Farm-Lifetime Budget

Technical recovery is mandatory operational plumbing, not a consumable
gameplay resource. Every independently proven technical incident must be
offered the existing recovery path, regardless of how many earlier recoveries
completed during the same farm session. This includes sequence desync, dead
board, controller stall, active-combat actionability loss, late mandatory
reset, entry-opening timeout, room ejection, and a validated local actor in
`Board._leftActorNumbers` while combat ownership is still active.

There is no operator-facing `Max recoveries` setting and no lifetime recovery
cap. The cumulative recovery count remains telemetry only. Safety remains
incident-local: one coordinator may arm only one trigger and authorize only
one bounded Exit/Confirm/exact-target re-entry sequence; failed or ambiguous
identity/lifecycle proof still stops fail-closed. Recovery never restores old
board, action, ACK, pointer, card UI, or gameplay state.

An exact active combat that makes no authoritative progress for 45 seconds is
a technical recovery condition regardless of whether MatchService still names
the local player or boss as current owner. Progress means any change in the
exact session, turn, current owner, displayed server timer, local/last move
sequence, or highest acknowledged server sequence. The proof requires at least
four valid read-only samples, a production-ready ACTIVE board, prior accepted
gameplay, valid foreground/window ownership, and no pending action, PASS,
Fusion or sequence-desync flow. Missing or ambiguous evidence resets the proof;
this watchdog never authorizes a gameplay input.

Normal SWAP input keeps the established 0.25-second two-click gap while
delivery is healthy. A proven technical recovery/exact room re-entry or an
unconfirmed SWAP may raise that gap adaptively, capped at 1.5 seconds. Pacing
must use read-only/action-outcome evidence, remain logged per SWAP, decay only
after sustained clean acknowledgements, and preserve the remaining server
timer margin. Failure to read the unverified visual Ping/FPS overlay is not a
reason to guess or add a blind OCR dependency.

## Local actor ownership and final SWAP preflight

Do not infer the local user by requiring exactly one non-boss PlayerStats.
Fusion can publish an additional non-boss pet actor. Resolve the local actor
read-only through the exact chain implemented by Active itself:
`ChatService.Username -> MatchService.Players[username] ->
MatchPlayerSnapshotDTO.actorNumber`. Missing, changing or ambiguous mapping
remains UNKNOWN; actor `1` is never hard-coded.

The stable provider/policy reread is not the final SWAP authorization. Modal
capture and coordinate preparation can consume a late turn. Immediately before
the ordinary two-click input, reread MatchService and require the same MatchId,
turn, local owner and local move sequence, with timer strictly above the
configured one-second floor. A failure cancels the unsent permit and proposal;
it is not a server rejection and must not pause the whole farm.
