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
- EVOLVE is a functional action and does not consume the gameplay turn.
- After successful EVOLVE, reread full `GameState`; a consuming SWAP or CAST
  may still occur in the same turn.
- Do not claim that EVOLVE resets idle/PASS. Its reset semantics remain
  UNKNOWN until authoritative evidence changes that classification.

## CAST / Chưởng

- CAST consumes one gameplay turn.
- After an accepted CAST, no board SWAP may occur in the same turn.
- Resolve the current owned/interactable ATTACK card dynamically. Card ID `4`
  is observed data, not a product rule.
- The cost must come from current runtime card data; observed accepted cost is
  160 Mana.
- Current BASIC CAST branch requires player Mana strictly greater than 480,
  preserving the accepted 320-Mana reserve after the observed 160 cost.
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
- CAST requires the dynamic runtime card cost and the strict `Mana > 480`
  reserve rule described above.
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

Continuous looping is the approved product goal, but it must not be enabled by
silently widening a bounded acceptance phase. First prove the Phase 2D.2
two-entry/one-combat boundary; introduce continuous farming as a separately
reviewed phase with the same lifecycle, session, foreground, and safe-stop
invariants.

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
