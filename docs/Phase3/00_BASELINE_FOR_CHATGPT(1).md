# POKIGUARD TOOL V2 — POST-BASIC PET SKILL / QTE BASELINE FOR CHATGPT

**Purpose:** This file is NOT a Codex/Claude implementation prompt.  
It is the long-term planning/review baseline for ChatGPT after the finite BASIC release was completed.

**Baseline date:** 2026-08-30  
**Last fully released checkpoint:** Phase 2F.2 — PASS STRONG / finite BASIC scope COMPLETE  
**Release tag:** `v1.0.0+15`  
**Release commit/tag target:** `4249f6178f53cc0d4498ae1c755d862491a3a428`  
**Accepted RC SHA-256:** `e077a74827478d78bea99200c247f14ba787179352db59a0148bf58d08594a69`  
**Current post-release source line:** `v1.0.1` maintenance changes exist locally and are not yet accepted as a live/committed checkpoint at this baseline.  
**Current next phase:** Phase 3A.0 — Freeze `v1.0.1` Maintenance Baseline

If repository evidence becomes newer than this file, repository truth wins.

---

# 1. CHATGPT'S ROLE

ChatGPT is the project planner/reviewer.

ChatGPT is NOT normally the implementation agent. Codex/Claude is usually the implementation agent.

Normal workflow:

```text
User gives one complete phase prompt to Codex/Claude
        ↓
Codex/Claude implements only that phase
        ↓
User sends the final phase report/evidence to ChatGPT
        ↓
ChatGPT reviews the evidence
        ↓
PASS STRONG / PASS / PARTIAL / BLOCKED / FAIL
        ↓
ChatGPT chooses the next smallest safe phase
        ↓
ChatGPT returns one complete copy-paste implementation prompt
        ↓
Explicit STOP boundary
```

Whenever the user sends the result of a phase, ChatGPT should normally return in the same response:

1. a concise evidence review;
2. acceptance classification;
3. remaining blockers / `UNKNOWN` / `NOT_OBSERVED`;
4. next phase name;
5. why that phase is the next smallest safe boundary;
6. one complete prompt for Codex/Claude;
7. an explicit STOP boundary.

Do not make the user ask a second time for the next prompt.

---

# 2. SOURCE-OF-TRUTH PRIORITY

Use this priority whenever sources conflict:

1. explicit current user instruction / newly approved product rule;
2. repository `AGENTS.md`;
3. repository `docs/DECISIONS.md`;
4. repository `docs/CURRENT_STATE.md`;
5. latest accepted phase report/runbook/log evidence;
6. this external baseline;
7. old/superseded reports.

Important:

- An older external baseline never overrides newer repository state.
- Technical discoveries do not silently rewrite a user gameplay decision.
- If the user explicitly changes a gameplay/product rule, that new instruction is authoritative and should be canonicalized in the next appropriate phase.
- Preserve `UNKNOWN` and `NOT_OBSERVED` exactly.

---

# 3. PROJECT PURPOSE

`PokiguardToolV2` is a Windows automation tool for the Unity IL2CPP game Pokiguard.

Accepted production architecture:

```text
Pokiguard.exe
    ↓
external READ-ONLY process memory
    ↓
runtime state providers
    ↓
GameState
    ↓
deterministic board simulator
    ↓
BASIC gameplay policy
    ↓
actionability / session / safety gates
    ↓
normal foreground Windows mouse/keyboard input
```

Accepted farm lifecycle:

```text
exact Chinh Phuc boss room
→ Start
→ exact session-pinned target
→ normal Windows entry
→ fresh combat session
→ autonomous BASIC combat
→ terminal result
→ postmatch confirmation
→ exact boss lobby
→ next bounded attempt
```

Accepted technical recovery is normal UI/lifecycle recovery only. It never restores or mutates game internals.

---

# 4. REPOSITORY ROLES

```text
PokiguardToolV2 = PRIMARY / WRITABLE
PokiguardAuto   = REFERENCE ONLY
pc              = STRICTLY READ ONLY
```

Never generate implementation instructions that require modifying `PokiguardAuto` or `pc`.

---

# 5. HARD TECHNICAL BOUNDARIES

Allowed:

- external process memory READS;
- own deterministic simulator/policy;
- read-only reverse engineering of local game files/native metadata;
- normal foreground Windows mouse/keyboard input;
- local tests/replays/logs/artifacts;
- ordinary UI automation already accepted by the project.

Forbidden unless the user explicitly changes project scope:

- `WriteProcessMemory`;
- modifying game memory;
- DLL injection;
- hooks/remote threads;
- patching/replacing game binary/data files;
- direct gameplay IL2CPP method calls;
- direct `RequestSwap`;
- direct `MatchService.SendMove`;
- direct hidden auto-move game methods;
- packet/WebSocket/network manipulation;
- replay/forging/repair of protocol or sequence;
- game-state modification;
- anti-cheat bypass.

Pet Skill/QTE automation must remain within the same boundary:

```text
read-only state
→ own decision/controller
→ normal foreground keyboard/mouse input
```

Do not use direct `RequestQteChallenge`, direct `SendSkillUse`, or direct game-method invocation as the production action path.

---

# 6. ACCEPTED FINITE BASIC RELEASE FOUNDATION

Phase 2F.2 closed the original finite BASIC roadmap as PASS STRONG.

Accepted release:

```text
version: v1.0.0+15
tag: v1.0.0+15
release commit/tag target:
4249f6178f53cc0d4498ae1c755d862491a3a428

full regression:
740/740 PASS

release tests:
14/14 PASS
```

Accepted final release boundaries include:

- standalone Windows x64 packaged app;
- no developer Python CLI required at runtime;
- no source-repository dependency at runtime;
- writable runtime data under application-owned local app-data paths;
- zero application writes to game installation;
- zero runtime writes to source repo or beside packaged EXE;
- read-only game attach;
- responsive desktop UI;
- bounded FarmRunner;
- correct exact boss/session pinning;
- deterministic BASIC gameplay;
- normal postmatch;
- terminal result fidelity;
- technical recovery;
- graceful stop;
- emergency stop;
- durable checkpoint/resume;
- safe UI close;
- no orphan controller/poller;
- clean release manifest/hash/tag.

Do not regress these while building the Pet Skill roadmap.

---

# 7. CURRENT POST-RELEASE `v1.0.1` MAINTENANCE STATE

At this baseline, the user has requested and the implementation agent has locally implemented three post-release maintenance refinements.

They are NOT yet the accepted committed/live baseline.

Current source label:

```text
v1.0.1
```

Current reported offline state:

```text
full regression: 745/745 PASS
compileall: PASS
git diff --check: PASS
live validation: PENDING
commit/push: PENDING
portable rebuild: PENDING
```

Maintenance changes:

## 7.1 Card click Y adjustment

Actual EVOLVE/CAST click moved upward from normalized Y `0.836` to `0.824`.

Purpose:

- avoid clicking too close to the lower card edge;
- keep existing visual/card validation unchanged.

## 7.2 Faster postmatch confirmation

The redundant fixed postmatch wait was reduced from 5 seconds to 1 second.

Result-confirm click still requires:

- authoritative POSTMATCH;
- stable result modal / reward readiness evidence;
- stable visual confirmation;
- foreground/lifecycle preflight immediately before the one click.

Do not trade correctness for speed.

## 7.3 Stronger Sword safety

The simulator/policy now audits every legal deterministic boss reply on the settled known board.

"Leaving Sword for boss" includes:

```text
direct:
boss reply itself matches Sword

indirect:
boss reply matches another resource
→ deterministic known-board collapse/cascade
→ Sword is collected
```

A normal move is safe only if it does not expose either known reply path under the accepted model.

Unique adverse-Sword exception:

- if the only current Sword move gives us less effective Sword than the known deterministic Sword reply it gives the boss;
- policy may defer it;
- try genuinely safe resource moves;
- use authoritative PASS only when legal;
- if PASS cannot be used, a separately proven Sword-hold may be considered;
- Sword-hold remains dangerous, never relabelled safe;
- `UNKNOWN` refill is never favorable evidence.

Phase 3A.0 exists specifically to live-validate and freeze these maintenance changes before new Pet Skill work starts.

---

# 8. EXISTING BASIC GAMEPLAY FOUNDATION TO PRESERVE

The new feature is an extension of BASIC, not REASONING.

Existing important foundations:

- SWORD remains the highest board objective unless a newly approved product rule explicitly changes that.
- Evaluate deterministic cascades and opponent replies, not only direct matches.
- Off-board/new refill remains `UNKNOWN`.
- Do not give favorable credit to unknown refill.
- PASS truth comes only from authoritative game/server-owned state.
- First local turn cannot PASS.
- Third consecutive PASS is prohibited by the accepted authoritative rule.
- Mandatory consuming action remains safety-gated.
- EVOLVE is a function action and does not consume the turn.
- Default Attack CAST consumes a turn.
- Normal production card actionability requires current live card/UI/runtime evidence.
- A stale card object from an earlier session is never actionable.
- No blind resend after an uncertain action.
- Technical recovery never reuses old board/action/ACK/card/QTE state.

`REASONING` remains undefined and unsupported.

Do not rename Pet Skill strategy to REASONING.

---

# 9. CURRENT USER-APPROVED NEW PRODUCT INTENT

The user has now explicitly requested a new Pet Skill/QTE feature roadmap.

This is a new post-BASIC roadmap.

The user wants three distinct configuration dimensions.

## 9.1 `Pet của tôi` / Main Pet Type

User-facing options:

```text
Pet thường       (enabled, default)
Huyền thoại      (enabled)
Tiến hóa         (visible but disabled for now)
Mega             (visible but disabled for now)
```

The disabled entries are future-facing UI/product placeholders only.

Do not implement unsupported runtime behavior for them merely because the option is visible.

## 9.2 `Tiến hóa` / Evolution Target

This describes whether Fusion/Evolution is used and what pet category is selected as the evolution target.

User-facing options:

```text
Không tiến hóa
Tiến hóa pet thường       (enabled, default)
Tiến hóa pet huyền thoại  (enabled when current account/runtime capability supports it)
Tiến hóa pet tiến hóa     (visible but disabled for now)
Tiến hóa pet Mega         (visible but disabled for now)
```

Important terminology:

```text
"Tiến hóa"
= the gameplay action / Fusion process

"Pet tiến hóa"
= a pet category/type
```

Do not conflate those two concepts.

## 9.3 `Thẻ sát thương` / Damage Card Mode

Options:

```text
Thẻ chưởng mặc định
Thẻ skill của pet
```

Default:

```text
Thẻ chưởng mặc định
```

`Thẻ skill của pet` is enabled only when the selected main/evolution capability can actually provide a pet skill card.

Initial product availability rule requested by the user:

```text
Main pet NORMAL + Evolution NORMAL
→ Default Attack only

Main pet NORMAL + Evolution NONE
→ Default Attack only unless runtime capability proves a pet skill exists

Main pet NORMAL + Evolution to a pet with special skill
→ Pet Skill can become available after successful evolution

Main pet with special skill + Evolution NONE
→ Pet Skill selectable

Main pet with special skill + Evolution NORMAL
→ Pet Skill selectable from the main pet

Main pet with special skill + other special evolution
→ potentially multiple skill cards
→ capability must be represented
→ exact choice policy must not be invented if ambiguous
```

The implementation should be capability-driven, not fixed card-position-driven.

---

# 10. `ManaPriority` IS PLANNED TO BE REMOVED

Legacy config:

```text
ManaPriority:
- EVOLUTION
- ATTACK
```

The user has explicitly requested that `ManaPriority` be removed because the new model directly expresses:

- whether to evolve;
- what evolution target is selected;
- what damage card mode is selected.

Do NOT remove it during Phase 3A.0.

The migration belongs to Phase 3A.2 so backward compatibility can be proven.

Expected semantic migration concept:

```text
legacy EVOLUTION
→ main pet NORMAL
→ evolution target NORMAL
→ damage card DEFAULT_ATTACK

legacy ATTACK
→ main pet NORMAL
→ evolution NONE
→ damage card DEFAULT_ATTACK
```

This mapping must be verified against repository behavior before becoming canonical code.

---

# 11. DEFAULT COMPATIBILITY CONTRACT

The new configuration default must preserve the legacy normal BASIC behavior.

Required conceptual default:

```text
Main Pet:
NORMAL

Evolution:
NORMAL

Damage Card:
DEFAULT_ATTACK
```

This combination should behave like the current "normal pet → normal evolution → default attack card" BASIC path.

Backward compatibility must be tested explicitly.

Do not allow the new Pet Skill feature to silently change default farming behavior.

---

# 12. PET SKILL / QTE REVERSE EVIDENCE ALREADY AVAILABLE

The existing reverse report provides strong evidence of a separate pet-skill QTE subsystem.

Known architectural evidence includes:

```text
SkillPetEspect
DotSkillManager
CardUI.IsDotSkillCard()
CardUI.IsSkillCard()
CardUI.HandleDotSkillSequence(...)
MatchService.RequestQteChallenge(...)
MatchService.HandleQteChallenge(...)
MatchService.SendSkillUse(...)
WsMatchClient.OnMatchQteChallenge
PetUserDTO.skillCardId
PetUserDTO.manaSkillCard
PetUserDTO.cardDTO
CardData
qtePresses
qteElapsedMs
timingResult
correctCount
Perfect / Good / Bad concepts
Mega1 / Mega2 infrastructure
Fusion Skill infrastructure
```

Relevant `CardData` fields include:

```text
cardId
skillType
manaCost
powerCost
cooldownTurns
conditionUse
needPerfection
eatPerfect
eatGood
eatBad
damageMultiplier
```

Therefore production Pet Skill resource requirements must be runtime-driven.

Do not hard-code `200 Mana + 150 Rage` as a universal rule.

The user's currently observed Legendary skill cost may be used as a live fixture/evidence point only.

---

# 13. QTE FACTS VS UNKNOWNS

Known:

- directional QTE infrastructure exists;
- QTE stores/uses directional input data;
- correct input count exists;
- timing result exists;
- Perfect/Good/Bad concepts exist;
- QTE result data is part of skill-use flow;
- the user visibly observes directional arrows and a timing/Perfect bar.

User-observed behavior:

```text
click pet skill card
→ directional sequence appears
→ use up/down/left/right-style inputs
→ timing marker moves through a Perfect region
→ Space-style confirm is used by the player
→ skill resolves
```

Important reverse gaps at this baseline:

```text
UNKNOWN exact native key mapping
UNKNOWN exact Space/confirm implementation
UNKNOWN exact sequence source/generation
UNKNOWN whether sequence is server-provided or client-generated
UNKNOWN exact correctCount formula
UNKNOWN exact Perfect/Good/Bad threshold/window semantics
UNKNOWN exact qteElapsedMs server validation
UNKNOWN exact skillType values
UNKNOWN exact effect of each skillCardId
UNKNOWN full pet-skill-card list
UNKNOWN whether a given Legendary skill exposes targetable rows/cells/dots
```

Do not turn user-observed UI behavior into native/code certainty without evidence.

---

# 14. INITIAL TARGET MODE FOR LIVE PET-SKILL WORK

The user's first practical optimization target is:

```text
Main Pet:
Huyền thoại / LEGENDARY

Evolution:
Không tiến hóa / NONE

Damage Card:
Thẻ skill của pet / PET_SKILL
```

Reason:

- avoid the time/resource cost of normal evolution;
- accumulate the resources required by the currently equipped Legendary skill;
- use the skill as soon as the current skill requirements/actionability permit;
- automate the directional QTE;
- hit Perfect reliably;
- reduce match duration;
- potentially reduce energy consumption if authoritative energy evidence supports that claim.

Do NOT assume energy savings merely from shorter time.

If game-owned energy consumption cannot be measured, report:

```text
ENERGY_SAVING = NOT_MEASURED
```

---

# 15. PET SKILL RESOURCE STRATEGY — USER INTENT

The user wants BASIC to remain broadly similar while the new damage mode changes resource planning.

For Pet Skill mode:

```text
if skill is already affordable/actionable
→ use PET_SKILL at the approved policy point

if skill is not affordable
→ prefer safe board moves that make the skill requirements ready sooner
```

The exact requirements must come from runtime skill/card data.

For a multi-resource skill, resource planning should be based on what is missing.

Example fixture only:

```text
skill needs ~200 Mana + ~150 Rage

Mana ready, Rage missing
→ safe Rage progress becomes valuable

Rage ready, Mana missing
→ safe Mana progress becomes valuable
```

Do not hard-code those exact thresholds for all skills.

Do not invent resource priority for an undefined skill requirement.

---

# 16. PET SKILL ACTION SHOULD BE A DISTINCT SEMANTIC ACTION

Do not overload existing default Attack `CAST` semantics.

Recommended conceptual action:

```text
PET_SKILL
```

Reason:

Default Attack path:

```text
card click
→ ordinary card resolve
→ consuming action
```

Pet Skill path:

```text
pet-skill card click
→ QTE opening
→ challenge/sequence
→ directional inputs
→ timing/Perfect confirm
→ skill result
→ fresh authoritative state
```

The Pet Skill executor/controller should have its own state/ownership contract.

This name is a design recommendation, not an instruction to ignore better existing repository naming.

---

# 17. QTE CONTROLLER SAFETY MODEL

Conceptual state machine:

```text
IDLE
→ SKILL_CARD_READY
→ SKILL_CLICK_SENT
→ QTE_OPENING
→ QTE_SEQUENCE_READY
→ DIRECTION_INPUT
→ WAIT_PERFECT_WINDOW
→ CONFIRM_INPUT
→ WAIT_SKILL_RESULT
→ TERMINAL
→ fresh GameState
```

During an owned QTE:

```text
normal board SWAP = blocked
default Attack CAST = blocked
EVOLVE = blocked unless repository semantics explicitly prove otherwise
PASS = not independently dispatched
second Pet Skill click = blocked
```

QTE state must be session/turn/card/challenge scoped.

Old QTE state from another MatchId/session must never be actionable.

On lifecycle/session/foreground/turn ambiguity:

```text
fail closed
no blind arrow resend
no Space spam
no skill-card reclick loop
```

Emergency Stop remains higher priority than QTE completion.

After Emergency Stop acknowledgement:

```text
new arrow input = 0
new confirm/Space input = 0
new skill-card click = 0
```

---

# 18. PERFECT AUTOMATION PRINCIPLE

Do not implement Perfect using one guessed fixed `sleep()`.

Preferred order of evidence:

```text
read-only runtime timing state
→ exact Perfect interval semantics
→ current QTE timing position / elapsed state
→ target a stable point inside Perfect interval
→ final foreground/session/QTE preflight
→ one normal confirm input
→ server/result evidence
```

If runtime timing cannot be proven sufficiently, a later phase may evaluate visual/CV timing.

Do not add OCR merely to read the timing bar.

Do not spam confirm.

A successful phase must distinguish:

```text
direction sequence correctness
vs
timing Perfect correctness
```

---

# 19. "MAXIMIZE SWORD" IS CONDITIONAL ON SKILL EFFECT EVIDENCE

The user's outcome goal is:

```text
auto skill
+ Perfect
+ maximize Sword benefit when the skill allows targeting/selection
```

Do not assume every pet skill lets the player choose rows/dots/cells.

Two possible paths:

## Non-targetable skill

If skill outcome is server-defined from QTE quality:

```text
correct directions
+ PERFECT
→ highest proven QTE tier / eatPerfect result
```

Do not claim the tool selected the most Sword.

## Targetable skill

Only if reverse/runtime evidence proves selectable rows/dots/cells:

```text
SkillTargetSolver
→ use current known board
→ maximize effective Sword / accepted skill objective
→ preserve deterministic safety where applicable
```

Do not invent target-selection behavior from fields alone.

---

# 20. CARD DISCOVERY MUST REMAIN DYNAMIC

The user has observed different card orders depending on main pet/evolution state.

Examples:

```text
special main pet:
Skill, Evolution (if selected), Default Attack

normal pet evolving into special skill pet:
special skill may appear after evolution
```

Production must not rely on left-to-right card index.

Use validated runtime card identity/class/data/actionability.

A card's visual order is telemetry/UI context only.

Stale card UI from old match/recovery is never actionable.

---

# 21. FUTURE CAPABILITY MODEL

Prefer representing skill capability as data rather than one boolean.

Conceptual model:

```text
PetCapability
- main_pet_kind
- runtime_pet_id
- pet_name
- skill_cards[]

PetSkillCapability
- skill_card_id
- card identity
- skill family/type
- mana cost
- rage/power cost
- cooldown
- perfection requirement
- target mode if proven
- runtime card UI/actionability
- source: main pet vs evolution pet
```

Exact field names should follow repository architecture.

Do not create hard-coded Starburst/pet-specific product logic.

---

# 22. REASONING REMAINS OUT OF SCOPE

This roadmap extends BASIC.

```text
BASIC = supported and being extended
REASONING = undefined / unsupported
```

Do not define Pet Skill as REASONING.

Do not use this roadmap as permission to invent a new general AI planner.

---

# 23. NEW ROADMAP

Current post-BASIC roadmap:

```text
3A.0
Freeze v1.0.1 Maintenance Baseline

3A.1
Pet Skill / QTE Reverse Closure

3A.2
Pet Configuration + Capability Model

3B.1
Pet Skill Runtime Discovery + Shadow QTE Observer

3B.2
Automated Direction Sequence

3B.3
Perfect Timing + Full Pet Skill Action

3C.1
BASIC Pet-Skill Policy

3C.2
UI ↔ FarmRunner Pet-Skill Integration

3D.1
Performance / Efficiency A-B Comparison

3D.2
25-Match Pet-Skill Soak

3E.1
Packaged Pet-Skill Release Acceptance
```

This is a planning roadmap, not permission to implement all phases at once.

If a phase exposes a blocker, insert a narrow remediation phase such as:

```text
3B.3-R1 — Correct Perfect-window timing drift
```

then return to the roadmap only after it is accepted.

---

# 24. PHASE 3A.0 — CURRENT NEXT PHASE

Goal:

Freeze the already-implemented `v1.0.1` maintenance changes before Pet Skill work.

Must include:

- inspect current uncommitted changes;
- preserve scope;
- run targeted/offline validation;
- bounded live validation of current BASIC;
- validate raised card click;
- validate faster postmatch confirmation;
- validate no safety regression from stronger Sword logic;
- update canonical docs accurately;
- full regression;
- compileall;
- diff-check;
- focused commit/push;
- clean worktree;
- controller/UI stopped.

Must NOT include:

- Pet Skill config;
- `ManaPriority` removal;
- QTE reverse;
- QTE automation;
- packaging/release rebuild unless separately requested.

---

# 25. PHASE 3A.1 — PET SKILL / QTE REVERSE CLOSURE

Read-only reverse/runtime observation phase.

Goal: close the unknowns required before any automated QTE input.

Priority evidence:

```text
main-pet runtime identity/capability
skillCardId / CardData
manaCost / powerCost / cooldown / conditionUse
needPerfection
QTE challenge ownership/lifetime
exact sequence source
exact direction mapping
confirm/Space mapping
currentIndex / correctCount semantics
timing clock
Perfect interval
server timingResult correlation
turn-consumption semantics
resource deduction semantics
skill exact effect
targetable vs non-targetable skill
```

Manual user QTE input is allowed for observation.

Automated QTE input is NOT allowed.

Do not advance to automated directions if exact sequence/direction ownership remains ambiguous.

---

# 26. PHASE 3A.2 — CONFIG + CAPABILITY MODEL

Goal:

- add the three user-facing dimensions;
- migrate/remove `ManaPriority`;
- build capability gating;
- keep unsupported Pet/Mega options visible but disabled;
- preserve default legacy behavior;
- add tests for config migration/validation;
- no autonomous Pet Skill input.

This phase changes product configuration, not QTE execution.

---

# 27. PHASE 3B.1 — SHADOW QTE OBSERVER

Goal:

- discover/track live Pet Skill card dynamically;
- build current-session `QteSnapshot`/equivalent;
- observe manual skill use;
- correlate sequence, index, correct count, timing window, server result;
- zero tool QTE input.

Expected evidence:

multiple manual QTEs where shadow state matches the visible/manual flow and server result.

---

# 28. PHASE 3B.2 — AUTOMATED DIRECTION SEQUENCE

Goal:

```text
tool clicks validated Pet Skill card
→ QTE opens
→ tool sends directional sequence
→ user performs final timing confirm manually
```

Do not automate final Perfect confirm yet.

Critical counters:

```text
wrong direction = 0
duplicate direction = 0
stale direction = 0
direction after Emergency Stop ACK = 0
old-session QTE input = 0
```

---

# 29. PHASE 3B.3 — PERFECT TIMING + FULL PET SKILL

Goal:

fully automate:

```text
validated skill card
→ QTE sequence
→ correct directional inputs
→ proven Perfect timing
→ one confirm
→ server skill result
```

Do not accept GOOD/BAD as "close enough" for PASS STRONG when the tested skill requires Perfect.

Timing implementation must use evidence, not a blind sleep.

---

# 30. PHASE 3C.1 — BASIC PET-SKILL POLICY

Goal:

integrate Pet Skill as a BASIC policy action.

Initial supported mode:

```text
Main Pet = LEGENDARY
Evolution = NONE
Damage Card = PET_SKILL
```

Keep current Sword-safety model.

When Pet Skill requirements are not ready:

- use safe resource moves;
- prefer progress toward current runtime requirements;
- do not collect a full resource solely for its own value;
- preserve health/defense/PASS/mandatory-action safety.

If skill requirements/effect are unknown, fail closed instead of inventing a strategy.

---

# 31. PHASE 3C.2 — UI/FARMRUNNER PET-SKILL INTEGRATION

Goal:

- UI configuration reaches immutable FarmRun config;
- live pet-skill mode works through the normal UI/controller;
- no normal EVOLVE in `Evolution=NONE`;
- default Attack is not used when `DamageCard=PET_SKILL` unless an explicit fallback policy has been approved;
- small bounded live farm, initially about 5 completed matches;
- prove default legacy mode still works in a separate small regression smoke.

---

# 32. PHASE 3D.1 — PERFORMANCE / EFFICIENCY COMPARISON

Compare the accepted default mode with the new Legendary Pet Skill mode.

Suggested same-build A/B:

```text
A:
Normal main pet
Normal evolution
Default Attack

B:
Legendary main pet
No evolution
Pet Skill
```

Measure where authoritative/loggable:

- combat duration;
- full farm-cycle duration;
- SWAP count;
- skill uses;
- Perfect rate;
- attempts/completion;
- technical abort/recovery;
- WIN/LOSS/UNKNOWN.

Energy saving may be claimed only if energy use is actually measurable.

---

# 33. PHASE 3D.2 — 25-MATCH PET-SKILL SOAK

Goal:

prove long-run safety/reliability.

Required categories:

- exact bounded target;
- no extra attempt after target;
- result accounting consistency;
- no stale QTE across MatchIds;
- no old skill-card reuse after recovery;
- Perfect invariant;
- zero critical input safety violations;
- technical recovery uses fresh QTE/card state;
- final controller stopped;
- final lifecycle safe/expected.

---

# 34. PHASE 3E.1 — PACKAGED PET-SKILL RELEASE

Goal:

- build new packaged Windows artifact;
- clean staging;
- packaged default BASIC smoke;
- packaged Legendary/No-Evolution/Pet-Skill smoke;
- Perfect QTE;
- graceful stop;
- emergency stop around QTE;
- checkpoint/resume;
- write audit;
- final docs/manifest/hash/tag.

Release version is not fixed by this baseline.

A minor-feature release such as `v1.1.0` is a reasonable planning candidate, but repository/user decision at release time is authoritative.

---

# 35. DEFINITION OF PET-SKILL ROADMAP COMPLETE

The new roadmap is complete only when all required evidence proves:

1. `v1.0.1` maintenance is frozen and live-accepted.
2. Pet/QTE runtime semantics needed for automation are reverse-proven.
3. New config model is canonical and backward-compatible.
4. `ManaPriority` migration/removal is safe.
5. Pet Skill card discovery is dynamic and session-safe.
6. QTE sequence is owned/correlated to the current skill/session.
7. Automated directional input is exact.
8. Automated confirm reaches proven Perfect.
9. No blind retry/spam/stale QTE input occurs.
10. BASIC Pet Skill resource policy is explicitly defined.
11. Legendary + No Evolution + Pet Skill mode works through UI/FarmRunner.
12. Default normal BASIC behavior still works.
13. Performance comparison is recorded.
14. 25-match Pet Skill soak passes.
15. Final packaged artifact passes live acceptance.
16. Release docs/hash/tag are complete.
17. Git release state is clean.
18. Existing hard safety boundaries remain intact.

Not required unless separately approved:

- REASONING;
- Mega gameplay;
- "Pet tiến hóa" gameplay;
- every pet skill family;
- multi-skill automatic selection when ambiguous;
- auto game login;
- infinite farming;
- memory writes;
- direct game method calls;
- network manipulation.

---

# 36. CRITICAL NON-INVENTION RULES

Never silently invent:

- exact QTE key mapping;
- exact Space implementation;
- sequence origin;
- Perfect threshold;
- timing formula;
- server validation behavior;
- skill effect;
- target-selection semantics;
- resource costs for unknown skills;
- cooldown semantics not evidenced;
- turn-consumption semantics not evidenced;
- multiple-skill selection policy;
- REASONING behavior;
- energy saving without measurement;
- a claim that live Perfect is proven when only offline timing tests passed.

Use `UNKNOWN`, `NOT_OBSERVED`, `NOT_MEASURED`, or a remediation phase.

---

# 37. HOW CHATGPT SHOULD HANDLE PHASE RESULTS

When the user sends a result:

## A. Review evidence

Classify:

```text
PASS STRONG
PASS
PARTIAL
BLOCKED
FAIL
```

## B. Preserve current truth

Newer user/repository evidence overrides this baseline.

## C. Choose the next smallest safe boundary

Prefer:

```text
offline/replay
→ read-only live
→ smallest active input
→ bounded integration
→ soak
→ packaging
```

## D. Generate one complete prompt

A strong prompt should include:

- phase title;
- docs to read;
- accepted base commit/state;
- exact goal;
- hard boundaries;
- state/contract changes;
- unknowns;
- fail-closed behavior;
- test/replay plan;
- live stages;
- PASS;
- PASS STRONG;
- blockers;
- DO NOT IMPLEMENT;
- docs updates;
- Git behavior;
- exact report template;
- explicit STOP.

## E. Do not make the user ask again

Return the next prompt automatically whenever enough evidence exists to choose it.

---

# 38. FRESH-CHAT RULE

A fresh ChatGPT conversation does not need the old conversation.

Provide:

1. this file;
2. `01_CHATGPT_PROMPT_GENERATION_PROTOCOL.md`;
3. `04_ROADMAP_FOR_CHATGPT.md`;
4. the latest phase result using `03_PHASE_RESULT_HANDOFF_TEMPLATE.md`;
5. preferably current repository `docs/CURRENT_STATE.md`;
6. preferably current `docs/DECISIONS.md`;
7. for QTE phases, `docs/pokiguard_pet_skill_qte_reverse_report.md`.

Then ask ChatGPT to review the latest evidence and generate the next complete Codex/Claude prompt.

---

# 39. CURRENT NEXT PHASE AT THIS BASELINE

```text
Phase 3A.0 — Freeze v1.0.1 Maintenance Baseline
```

Do not start automated Pet Skill/QTE implementation before 3A.0 is accepted and 3A.1 closes the required QTE unknowns.
