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

## Phase 3C.1 BASIC Pet Skill policy (approved scope 2026-09-12)

The first runnable backend profile is exactly
`LEGENDARY / NONE / PET_SKILL / BASIC`. It requires one unambiguous current
main-pet skill capability and the supported Huyền Thoại 7 automatic-dot QTE
family. Other skill families, evolution-target skill sources and multiple
skill sources remain fail-closed.

For this profile:

- EVOLVE is prohibited for the whole match;
- the ordinary Attack card is neither prepared before entry nor proposed as a
  fallback, including at low boss HP;
- when current runtime Mana/Rage requirements and CardUI actionability are
  ready, policy proposes the distinct `PET_SKILL` action;
- when requirements are missing, Sword remains the highest board objective;
  otherwise the resource branch considers only safe deterministic gains toward
  current missing Mana/Rage;
- a candidate completing a missing requirement ranks before partial normalized
  readiness progress; resources already sufficient and UNKNOWN refill receive
  no readiness credit;
- existing Health, Drain, Shield, PASS and mandatory-action behavior remains in
  its accepted order after the resource branch.

The Huyền Thoại 7 fixture is 200 Mana / 200 Rage and Huyền Thoại 2 is
200 Mana / 150 Rage. These are card fixtures, not rarity rules. Readiness always
uses the current `PetSkillCapability.effective_*` values. Gross cost is not
inferred from the net post-skill balance because skill destruction/cascades can
refill resources.

The currently proven Huyền Thoại 7 action consumes its source local turn.
After any physical Pet Skill input, FarmRunner closes that source turn and may
not send SWAP, CAST, PASS or another Pet Skill there. It waits for an
authoritative boss turn, terminal state or fresh later local turn. Zero-input
preflight failure may release the input permit but must reread state before a
new decision. After-input uncertainty never falls back or blindly retries.
Server-owned PASS/idle state is reread later and is never reset locally.

Phase 3C.2 exposes this exact profile through normal Desktop Start/Resume using
the same immutable controller, FarmRunner policy and PetSkillAction ownership.
Unsupported and ambiguous Pet Skill profiles remain gated.

## Phase 3C.3 `Chịu đấm ăn xôi` Pet-Skill rush (approved scope 2026-09-16)

`Chịu đấm ăn xôi` is an optional PlayStyle with stable serialized identity
`skill_rush`. It is not the default. Its initial FarmRunner scope is exactly
`LEGENDARY / NONE / PET_SKILL / BASIC` with the already accepted Huyền Thoại 7
automatic-board-effect family. Other loadouts, skill families and ambiguous
multi-skill sources remain blocked.

For this PlayStyle only:

- the policy derives four stages from the current authoritative state:
  `EARLY_BOSS_PREP`, `RESOURCE_AND_BOARD_SETUP`, `PET_SKILL`, and
  `POST_SKILL_FINISHER`;
- one ordinary early 3-Sword clear is normally sufficient boss preparation.
  `boss_hp / boss_max_hp < 0.50` completes HP preparation. About 35% is a lower
  preparation safety margin, not a target, and the approximately 30% evolution
  danger is gameplay knowledge rather than an exact reverse-proven boundary;
- when a resource is missing, current missing Mana/Rage remains primary. Known
  gains are clamped to the current deficits, a completed requirement ranks
  before partial normalized progress, and a resource already sufficient
  receives zero readiness credit. Effective requirements come only from the
  current `PetSkillCapability`;
- UNKNOWN refill receives zero favorable credit;
- count only authoritative known `GemType.SWORD` cells. `known_sword_count >= 8`
  means the revised practical high-Sword-density condition. A ready/actionable
  skill fires when boss HP is below 50% or the board has at least 8 known Sword; if the
  boss is already at or below approximately 30%, fire as soon as resources are
  ready;
- after HP preparation, preserve known Sword for HT7 and prefer deterministic
  turnover of known non-Sword cells in zero/low-Sword rows or columns. Once
  resources are ready, first restrict setup to direct clears whose known
  non-Sword cells are at Manhattan distance at least 2 from every known Sword;
  this avoids clearing directly beside the prepared Sword region. If no such
  legal clear exists and the skill is actionable, fire with
  `SETUP_BLOCKED` instead of clearing beside the prepared Sword region. A
  least-adjacent fallback exists only while current CardUI is not actionable.
  This assigns no predicted Sword-spawn credit;
- direct and indirect boss Sword replies are recorded as strategic risk rather
  than hard rejections. This relaxation does not apply to other PlayStyles;
- EVOLVE remains prohibited. Ordinary Attack is prohibited before the first
  successful current-match Pet Skill and outside the narrow low-HP finisher;
- after a current-match `SUCCESS_PERFECT`, close the source turn and reread
  fresh authoritative boss HP. On a later local turn, boss HP `< 30,000` or
  ratio `< 20%` enables ordinary Attack or Sword as a finisher. If the boss is
  above both thresholds, normal setup resumes and a second Pet Skill remains
  possible;
- successful-skill history is owned by the exact `CombatSessionKey`, is not
  serialized to checkpoints, and cannot unlock the next match;
- lifecycle, timer, foreground, stale/duplicate-input, source-turn, PASS and
  QTE safety contracts remain unchanged.

The current board simulator has no authoritative damage-to-HP model that can
prove an immediate lethal reply. Candidate telemetry therefore records
`UNKNOWN_NO_LETHALITY_MODEL`; it does not claim that a risky move is non-lethal.
Existing SIMPLE and CAREFUL policies retain their Sword-first and Sword-safe
semantics unchanged.

## Phase 2 b2 compatibility repair (user correction 2026-09-11)

Default settings with a normal pet, normal-pet Evolution and the default Attack
card remain Phase 2 scope. Phase 3 gameplay is not being accepted or closed by
this repair. The work remains uncommitted and awaits the user's live test.

For Pokiguard 1.7.4-b2:

- Evolution eligibility uses the current positive runtime Fusion cost; current
  live evidence is **120 Mana**. The tool must not retain the older 160 value.
- PASS remains a last resort after exhaustive safe-move evaluation. A broad
  collapse/support overlap may rank a move as more dangerous, but it cannot
  veto a candidate after exact direct, indirect and UNKNOWN Sword checks prove
  zero Sword reply.
- Missing the board snapshot for a newer ACK is a technical capture gap, not a
  policy PASS. Recovery may be bounded per exact `(match, turn, ACK)` and may
  not forge, replay or modify network state. Once combat has started it may
  never escalate to a full managed-heap scan: the callback tap is primary and
  the fallback is one rotating, lobby-learned window capped at 64 MiB.
- For b2 callbacks, the primary typed board is the exact
  `ChatMessageDTO.preBoard` prepared by the game before dispatcher enqueue.
  Its event, MatchId and sequence must remain bound to the same immutable raw
  callback and exact game ACK; this does not relax currentness or stability.
- Board capture and card discovery are separate work. A board ACK gap must not
  trigger CardUI/FusionCardUI discovery. Reuse the lobby card expectation and
  cached validated owners; defer optional live card discovery until after the
  opening action (the following boss turn / turn 2 boundary).
- The new game-owned turn announcement delay must come from the verified
  `TurnAnnouncer` runtime blocker. The tool must not guess a sleep duration.
- Three consecutive idle turns remain forbidden. At authoritative idle 2/3,
  the next consuming action must be SWAP or CAST under the existing Phase 2
  policy.

## B3 manual-consumable test exclusion (user correction 2026-09-10)

The tool must not use functional consumables to inject Mana or Rage. B3
attempt 11 overlapped the operator's accidental manual Mana-card use; the user
explicitly excludes this out-of-protocol sample from acceptance scoring. Keep
its raw `CARD_CLICK_SENT_QTE_UNCONFIRMED` log, but label the test
`EXCLUDED_OPERATOR_INTERFERENCE`: neither PASS nor FAIL, and no reset of the
six-Perfect streak from attempts 5-10. This specific exclusion does not excuse
ordinary automation failures or authorize automatic consumable use. No code or
timing changes were requested. Subsequent tests use normally accumulated
resources and the existing one-shot skill authority.

## Pet Skill QTE Completion Contract (final correction 2026-09-09, v1.0.41)

For the external automation boundary, `MATCH_SKILL_USE_RES` is **not** a
mandatory success acknowledgement. The game still consumes its own server
response internally to apply authoritative combat state/effects, but the tool
must not fail a visibly completed current action merely because that short-lived
callback was not captured from RAM.

The accepted automation chain is:

1. bind the current server-issued QTE challenge and exact action/session;
2. send every direction closed-loop and require runtime progression to `7/7`;
3. send exactly one Space inside the current runtime Perfect interval;
4. require the same current CardUI generation to report runtime `PERFECT`;
5. immediately finish the action as `SUCCESS_PERFECT` with reason
   `CURRENT_GENERATION_RUNTIME_PERFECT`; send no more input for that action.

The tool does not wait for or collect the post-Space callback, resource delta,
board cascade, terminal result, or later settled board to accept this primitive.
The v1.0.40 requirement to wait for a fresh post-skill GameState was an incomplete
implementation of the user's correction and is superseded. A later callback
cannot reopen or revoke an already completed QTE action.

This completion does not declare the board playable. A future gameplay
integration must acquire its normal fresh, stable, ready, non-cascading,
actionable GameState before its next board/card action. GameState failure may
delay or recover that future gameplay operation; it must not relabel the
completed QTE as failed. Phase 3B.3 remains a one-action harness without
BASIC/FarmRunner integration.

Response decoders remain available for read-only diagnostics, but the production
one-shot starts no dispatcher tap or response heap scan. If a caller already
supplies an exactly correlated explicit reject before runtime completion, the
unfinished action still fails closed. Stale responses never reject a new action.

This decision supersedes the Phase 3B.3 prompt/report wording that required
external callback correlation or post-effect GameState for action success. It
does not remove the mandatory server challenge before input and does not
authorize direct server/game calls.

## Gameplay Configuration

The exact user-facing dimensions are:

```text
PlayStyle:
- SIMPLE
- CAREFUL

Pet của tôi / MainPetType:
- NORMAL (Pet thường)
- LEGENDARY (Huyền thoại)
- EVOLVED (Tiến hóa; visible but disabled)
- MEGA (Mega; visible but disabled)

Tiến hóa / EvolutionTarget:
- NONE (Không tiến hóa)
- NORMAL (Tiến hóa pet thường)
- LEGENDARY (Tiến hóa pet huyền thoại)
- EVOLVED (Tiến hóa pet tiến hóa; visible but disabled)
- MEGA (Tiến hóa pet Mega; visible but disabled)

Thẻ sát thương / DamageCardMode:
- DEFAULT_ATTACK (Thẻ chưởng mặc định)
- PET_SKILL (Thẻ skill của pet; current compatibility value for a profile with
  exactly one unambiguous skill source)

Intelligence:
- BASIC
- REASONING
```

The default is `NORMAL / NORMAL / DEFAULT_ATTACK`. The second default-Attack
profile is `NORMAL / NONE / DEFAULT_ATTACK`. These preserve the old
`EVOLUTION` and `ATTACK` BASIC behavior respectively. `ManaPriority` is no
longer a product or Desktop setting. `LEGENDARY / NONE / PET_SKILL` is the
first supported BASIC Pet Skill profile.

`LEGENDARY / NONE / PET_SKILL` reaches the normal Desktop/FarmRunner Pet Skill
policy without translating it to ordinary Attack. `NORMAL / LEGENDARY`
exposes an evolution-target skill source. `LEGENDARY / LEGENDARY` exposes both
main-pet and evolution-target sources; no implementation may choose one
implicitly.

User clarification on 2026-09-14 supersedes the assumption that the final
Damage selector will always contain only two choices. When a future supported
loadout can expose both skill cards, **Thẻ sát thương** must distinguish the
main-pet skill card from the evolution-pet skill card in that same field. Do
not add a separate source field and do not reduce both cards to one ambiguous
`PET_SKILL` option. Exact source-specific modes and labels belong to the phase
that adds the two-source profile. Phase 3C.2 remains limited to the unique
main-pet source `LEGENDARY / NONE`; multi-source gameplay stays blocked.

These fields describe operator intent. They do not equip a pet, choose an
inventory item, navigate the Pet UI, prove current resources, or replace the
runtime `PetSkillCapability` that validates the current CardUI and QTE.

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

- Current accepted/observed Evolution cost in 1.7.4-b2 is 120 Mana.
- Production input must still read an actual positive runtime Fusion cost; it
  must not guess 120 when runtime cost is unavailable.
- In the runnable `NORMAL / NORMAL / DEFAULT_ATTACK` profile, if Fusion has not
  succeeded, the live action is safely actionable, and Mana is sufficient,
  keep trying from the second local turn until success under the
  response/lock/fresh-state safety contract.
- Production Step 1 uses the same inclusive one-second action floor as normal
  input. The former ten-second EVOLVE follow-up floor is not a gameplay rule
  and must not postpone an otherwise actionable evolution.
- A failed attempt may retry only after the current-turn lock clears and fresh
  actionable state permits it; no tight loop.
- In the runnable `NORMAL / NONE / DEFAULT_ATTACK` profile, do not evolve
  during that match.
- While the boss current HP is at or below the enabled configurable low-HP
  threshold (`cast_when_boss_hp_below`, default 30000), do not evolve even when
  evolution is requested; preserve mana for the Sword/Mana/CAST finisher path.
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
- `FusionCardUI._boundPetId` must match the strongest current MatchService pet
  identity (`selectedPetId`, falling back to `selectedUserPetId`). Cache only a
  unique match; ambiguous or prior-combat wrappers must not suppress later
  bounded discovery retries.

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
- Any exact current-session authoritative 2/3 payload latches this mandatory
  requirement, including when it follows an unconfirmed/missed SWAP rather
  than a tool-coordinated PASS.
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
- "Leaving Sword for the boss" includes both an immediate Sword match and a
  known opponent move whose non-Sword direct clear deterministically cascades
  into Sword. Every legal opponent reply on the settled known-board result is
  audited for direct + cascade Sword before a move can be called safe.
- If exactly one current move collects Sword but its settled result gives the
  boss a deterministic Sword reply worth more effective Sword than we collect,
  defer that unique Sword move. Continue the normal safe-resource policy first,
  or PASS only when authoritative game-owned idle state permits it. If PASS is
  unavailable, an off-region Sword-hold move is a narrow tactical exception:
  every known boss Sword reply must deterministically leave a strictly larger
  effective Sword follow-up for us. A Sword-hold is not labelled safe, UNKNOWN
  earns no favorable credit, and mandatory-action rules still prohibit PASS.

## Sword Danger and Safe Moves

Strategy concepts:

- A Sword-danger region is a known aligned Sword structure that can become a
  boss Sword match through a gap/support change.
- A potential Sword match is a deterministic known-board opportunity left
  after the simulated move.
- A safe resource move is calculable (its direct clear starts at screen row 3
  or lower), has no known Sword swap left, no hypothetical Sword completion
  through exposed UNKNOWN cells, and no known Sword adjacent to an exposed
  UNKNOWN slot that could be swapped into that slot to complete Sword
  match-3. It also has no concentrated collapse through a known Sword
  danger/support region and no opponent non-Sword match whose deterministic
  cascade collects Sword.
- A dangerous move violates one or more of those safety conditions. Danger is
  ranked; it is not one undifferentiated boolean.
- A proven Sword-hold remains dangerous by this definition. It may be selected
  only for the unique-adverse-Sword exception above, never by an ordinary safe
  resource branch.
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

- Under `NORMAL / NORMAL / DEFAULT_ATTACK`, Mana supports repeated safe
  Evolution attempts until success when the runtime action is eligible.
- Under `NORMAL / NONE / DEFAULT_ATTACK`, Evolution is disabled for that match
  and Mana is retained for the dynamic ATTACK-card rule.
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

The exact game-executable path is a separate operator setting, not target or
gameplay authority. The UI persists the operator-selected versioned launcher
(`Pokiguard-<version>.exe`) beside `GameAssembly.dll`. When the filename changes
after an update, the operator selects the new EXE. Attach must
match the configured executable's full path, not merely a process-name prefix.
Changing this setting is allowed only while the controller is idle and never
modifies any game-installation file.

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

Normal board input is an immutable per-run operator preference. `two_click`
keeps the established 0.35-second pair and may use evidence-backed adaptive
pacing. `drag` uses the game-supported OnMouseDown/swipe/OnMouseUp path as a
fixed quick flick: 0.10 seconds over three cursor moves, releasing 0.35 cell
beyond the second centre while remaining within the target cell/Board. Drag is
not lengthened by two-click recovery/lag pacing. This is based on live run
`1e9097b2276948a7bdf7c78cc77281fa`, where the old slow 0.35-second/six-step
drag was unconfirmed and left the first gem selected, plus a successful manual
fast-flick comparison. Input mode, duration, steps and overshoot remain logged
per SWAP. Cards and UI controls are never dragged. Failure to read the
unverified visual Ping/FPS overlay is not a reason to guess or add a blind OCR
dependency.

## Pokiguard 1.7.4 Native Viewport Mapping

The prepared 1280x640 game client has two evidenced layout spaces. Card,
lobby, recovery and postmatch controls remain on a height-scaled, left-anchored
16:9 UI canvas. The combat Board `DotsArea` separately preserves full-client
normalized coordinates. Never apply the narrower card/UI canvas transform to
board-cell input. A legacy 1280x720 capture may contain a centered 1280x640
viewport with black bars; capture-based UI locators also apply its proven
vertical offset.

Evidence is FarmRun `d103ea509fb740b188df524283e61224`: a solver-legal
rightmost-column Shield swap was incorrectly emitted at client `x=732`, while
the saved opening frame places column 7 near `x=815`. FarmRun
`2c55da2623874fda9f95b3eea0e6b742` additionally proves that the V1-era vertical
calibration misses lower rows: intended `(row 6,col 5)<->(row 7,col 5)` was
emitted at `(638,371)<->(638,417)`, while the frame places those centres near
`(714,406)<->(714,456)`. The accepted 1.7.4 Board-only calibration is
`first=(.3620,.1625)`, `step=(.0393,.0787)`. This incident is an input-layout
fault, not a board-read, solver, or proven pacing fault.

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

## Standard-card action authority after the opening turn

Do not delay a known standard card strip solely to discover its managed UI
wrapper. After the mandatory opening board action, an exact current
`Board.selectedCards` list, matching `Board.cardsInHand` cardinality/order,
absence of a pet-specific skill layout, immutable `CardData`, and current
MatchService/PlayerStats state are sufficient to propose the known Fusion or
zero-cooldown Attack slot. A live CardUI/FusionCardUI remains preferred and a
negative live Button state wins. Every direct-owner proposal still requires a
fresh foreground capture proving the expected tile immediately before normal
input. Non-zero cooldown cards without live UI state fail closed.

Count energy from distinct game-owned local TurnNumbers, never from polls or
physical actions. This makes EVOLVE+SWAP on one local turn cost one energy and
keeps per-match accounting aligned with the game's turn model. The Control UI
may project this existing counter during combat and must show the current match
separately from completed-match totals; it must not trigger an additional
memory scan or capture.

For the exact standard direct-card authority
`BOARD_SELECTED_CARDDATA_CARD_STRIP`, a nonterminal CAST is accepted when the
current player mana decreases by exactly the runtime `CardData.conditionUse`
cost and the immediately following authoritative turn belongs to the opponent.
Both signals are mandatory. This substitutes only for unavailable dynamic
`CardUI.lastTurnUsed/hasUsedThisTurn` fields on that direct path; one signal
alone, another authority, a cost mismatch, or an ambiguous turn remains
unconfirmed and cannot be fabricated as acceptance.

## Pet Skill strip order and future pet preferences (user clarification 2026-09-04)

The user specifies these expected left-to-right combat layouts:

1. Main pet already has a skill: **main-pet Skill -> Evolution -> user-selected cards**.
2. Main pet has no skill; evolution pet has a skill: **Evolution -> user-selected
   cards -> evolution-pet Skill**, with the last card appearing only AFTER
   successful evolution. It does not replace Evolution's slot.

The number of user-selected cards is variable. Never infer a universal slot
index from the historical four/five-card loadout. Reuse existing card-data,
resource, window mapping, visual sanity and foreground click primitives;
extend the strip resolver instead of duplicating normal card input.

These orders are user-confirmed gameplay/UI expectations. Case 2 also matches
the Phase 3B.3 current native-hand evidence (five active cards, skill last).
Case 1 has not had live acceptance in this test series. Configuration/order
alone does not prove the current CardUI, Button, identity, resources or
actionability; those still come from the current match. Do not silently use
the old standard-card direct-owner shortcut as Pet Skill authorization.

In a LATER phase, Preferences must let the user select the main pet/type and
the evolution pet/type. Those required selections describe the intended
loadout, not static absolute coordinates or authority to use a missing card.
Do not add that UI, BASIC Pet Skill policy or resource planning in Phase 3B.3.
The layout when BOTH pets supply skills after evolution is not fully specified
or live-validated here; do not invent replacement/coexistence semantics.

### Phase 3B.3 QTE timing correction (2026-09-04)

User reported the automatic card click now works but directions are too slow
to complete 7/7 and confirm Perfect. Preserve the accepted fast closed-loop
3B.2 direction primitive. Remove full board/card scans from its critical poll
path, not the per-key authoritative ACK. Confirm with one Space in the current
runtime-derived Perfect window only after all directions are correct. No blind
retry or early/late Space to compensate for game lag. This remains a one-shot
acceptance harness; it does not authorize Pet Skill gameplay policy/farming.
Evidence and pending live revalidation: `phase3b3_qte_timing_evidence.md`.

The one-shot's second Pet Skill card preflight occurs before any input and must
stay on the exact current-session native-hand/control-only read path. It must
not depend on a full playable-board publication that can transiently disappear
during the turn. This does not relax the final card identity, geometry,
foreground, local-turn, resource, lifecycle or inactive-QTE gates and does not
authorize retrying any emitted input.

While a Pet Skill one-shot can still emit input, a synchronous observation or
geometry stage must not be allowed to resume after an unbounded stall and send
late input. A two-second stage watchdog revokes that one-shot's authority and
records the exact stalled stage. It does not classify the game/server result,
retry an input, or apply to the bounded read-only result/post-state wait after
Space.

### Phase 3B.3 B4 bounded same-match authorization (2026-09-10)

Following B3's accepted ten-action streak, the user explicitly requested testing
multiple QTEs in one combat and authorized B4 from the boss lobby. The B4-only
harness may execute at most TWO full Pet Skills in the SAME retained session,
using a fresh per-action executor and current QTE identity for each. It may not
auto-play the board, evolve, use resource consumables, enter another match or
integrate Pet Skill into BASIC/FarmRunner. The operator plays/prepares resources.

Runtime PERFECT completes each action immediately under the existing revised
contract. Readiness for action 2 is independent: current inactive QTE, later
ready local turn, current resources/card/geometry, fresh generation/challenge.
Reaching terminal before action 2 is incomplete same-match evidence, not a
failure of an already accepted Perfect or permission to force a recovery.
Stop after two successes or any post-input failure/session exit/operator abort.

### Phase 3C.0 Legend latch and turn semantics (2026-09-12)

Live retries 4 and 5 prove that Huyền Thoại 7 Pet Skill consumes the source
turn. Policy must not attempt a board swap after its accepted Perfect in that
same turn.

Retry 5 also proves `Board.isUsingLegendCard` is a durable telemetry latch: it
remained true through the boss turn and into the next settled local turn while
`isUsingMega` and both Mega panels were false and all other actionability checks
passed. It must not, by itself, block ordinary board play. The production modal
aggregate keeps Mega execution and both Mega panels as blockers; the exact
Legend flag remains available to the dedicated Pet Skill/QTE path and logs.

Phase 3C.0 does not authorize Pet Skill selection in BASIC or FarmRunner. That
policy/resource integration is a separate Phase 3C.1 change.
