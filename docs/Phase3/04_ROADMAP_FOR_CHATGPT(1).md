# ROADMAP FOR CHATGPT — POST-BASIC PET SKILL / QTE

This file is a HIGH-LEVEL roadmap for ChatGPT.

It is NOT a Codex/Claude implementation prompt.

Current released checkpoint:

```text
Phase 2F.2 — PASS STRONG
finite BASIC scope COMPLETE
tag v1.0.0+15
```

Current post-release state:

```text
v1.0.1 maintenance changes implemented locally
745/745 offline regression reported
live validation pending
commit/push pending
```

Current next phase:

```text
Phase 3A.0
```

---

## 3A.0 — Freeze `v1.0.1` Maintenance Baseline

### Goal category

Live-validate and commit the already-implemented maintenance changes before Pet Skill work.

Scope:

- raised EVOLVE/CAST click Y;
- faster postmatch confirmation;
- stronger direct + indirect Sword-reply safety;
- unique adverse-Sword defer/Sword-hold behavior;
- documentation;
- final regression;
- commit/push.

### Expected evidence before advancing

- bounded live BASIC farm, preferably 3–5 completed matches;
- at least one current card action path observed without misclick if naturally available;
- faster result confirmation observed without premature click;
- zero gameplay safety regression;
- rare Sword-hold live occurrence may remain `NOT_OBSERVED` if strong deterministic tests cover it;
- full regression PASS;
- compileall PASS;
- diff-check PASS;
- focused commit/push;
- clean worktree;
- controller/UI stopped.

### DO NOT implement

- Pet Skill config;
- QTE reverse/automation;
- `ManaPriority` removal;
- new packaging/release.

### Advance gate

Only after `v1.0.1` becomes a clean accepted source checkpoint.

---

## 3A.1 — Pet Skill / QTE Reverse Closure

### Goal category

Read-only reverse engineering + manual runtime observation.

### Questions to close

- exact main-pet identity/capability path;
- skillCardId / CardData;
- manaCost;
- powerCost/Rage cost;
- cooldown;
- conditionUse;
- needPerfection;
- QTE challenge ownership/lifetime;
- exact sequence source;
- exact direction mapping;
- confirm/Space mapping;
- currentIndex/correctCount semantics;
- timing clock;
- Perfect interval;
- qteElapsedMs correlation;
- server timingResult;
- turn consumption;
- resource deduction;
- exact skill effect;
- targetable vs non-targetable.

### Allowed live action

User performs the skill/QTE manually while the tool observes read-only.

### DO NOT implement

- automated QTE directions;
- automated confirm;
- Pet Skill policy;
- direct game/network skill invocation.

### Advance gate

Automated directions must not begin while sequence ownership or direction mapping is ambiguous.

Automated Perfect must not begin while timing/Perfect semantics remain ambiguous.

If unresolved, insert `3A.1-R*` reverse/remediation rather than guessing.

---

## 3A.2 — Pet Configuration + Capability Model

### Goal category

Product/config/UI model only.

### Required new user-facing fields

```text
Main Pet:
- Normal (default)
- Legendary
- Evolved [disabled initially]
- Mega [disabled initially]

Evolution:
- None
- Normal (default)
- Legendary
- Evolved [disabled initially]
- Mega [disabled initially]

Damage Card:
- Default Attack (default)
- Pet Skill [capability-gated]
```

### Required behavior

- remove/migrate legacy `ManaPriority`;
- keep "Evolution action" separate from "Evolved pet category";
- dynamic capability model;
- Pet Skill availability depends on main/evolution skill capability;
- default combination preserves legacy normal BASIC behavior;
- active run config remains immutable;
- unsupported future options cannot be selected.

### DO NOT implement

- automated Pet Skill input;
- QTE direction execution;
- Perfect timing.

### Advance gate

Config migration/backward compatibility must pass.

---

## 3B.1 — Pet Skill Runtime Discovery + Shadow QTE Observer

### Goal category

Read-only live shadow tracking.

### Goal

Build validated runtime structures for:

- current Pet Skill card;
- session-scoped QTE challenge;
- sequence;
- currentIndex;
- correctCount;
- timing window;
- server/result correlation.

User manually executes the QTE.

Tool sends zero QTE input.

### Expected evidence

Multiple manual QTE uses where the shadow state agrees with:

- current skillCardId;
- visible/manual direction sequence;
- input progress;
- timing window;
- final server/runtime result.

### Critical invariant

```text
tool QTE input = 0
```

### Advance gate

Current-session QTE ownership and sequence/timing correlation must be reliable.

---

## 3B.2 — Automated Direction Sequence

### Goal category

First active QTE keyboard automation.

### Flow

```text
validated Pet Skill card
→ one normal card click
→ current QTE challenge/sequence
→ tool sends directional inputs
→ user performs final timing confirm manually
```

### Safety

- one sequence owner;
- no old-session QTE;
- no duplicate direction;
- no resend after uncertain direction unless current QTE state proves the next expected state;
- no input after Emergency Stop ACK;
- no default SWAP/CAST while QTE owns the action flow.

### Expected evidence

Repeated successful directional sequences.

Critical counters:

```text
wrong direction = 0
duplicate direction = 0
stale direction = 0
old-session direction = 0
post-stop direction = 0
```

### DO NOT implement

Automatic Perfect confirm.

---

## 3B.3 — Perfect Timing + Full Pet Skill Action

### Goal category

Full autonomous QTE completion.

### Flow

```text
skill card
→ QTE sequence
→ exact directions
→ proven Perfect timing
→ one confirm
→ server/result
→ fresh GameState
```

### Timing rule

Do not use a guessed fixed sleep as the primary proof.

Prefer runtime timing evidence.

Visual/CV timing may be evaluated only if runtime timing cannot be proven sufficiently.

No OCR dependency for the timing bar.

### Suggested strong acceptance

At least 10 consecutive accepted automated skill uses where:

- all directions correct;
- final server/runtime timing result is `PERFECT`;
- GOOD = 0;
- BAD = 0;
- duplicate confirm = 0;
- stale QTE input = 0;
- input after Emergency Stop ACK = 0.

If the current skill does not require/emit `PERFECT`, adjust only from actual evidence; do not force the label.

### Advance gate

Full skill action must be reliable before policy integration.

---

## 3C.1 — BASIC Pet-Skill Policy

### Goal category

Policy change.

### Initial supported live mode

```text
Main Pet = LEGENDARY
Evolution = NONE
Damage Card = PET_SKILL
```

### Policy intent

Keep accepted BASIC board safety.

High level:

1. no EVOLVE in `Evolution=NONE`;
2. preserve Sword objective/safety;
3. if current Pet Skill is ready/actionable at the approved branch → `PET_SKILL`;
4. if not ready, prefer safe resource progress toward actual runtime skill requirements;
5. preserve health/defense/PASS/mandatory-action safety;
6. unknown skill state fails closed.

### Resource planning

Do not hard-code universal `200 Mana + 150 Rage`.

Use runtime current skill requirements.

When multiple resources are required, candidate ranking should improve readiness toward the actual missing requirements without violating Sword safety.

### Targeting

Only add target-selection/Sword-maximization logic if current skill targetability was proven in 3A.1/3B phases.

### DO NOT implement

- ambiguous multi-skill automatic choice;
- Mega/Evolved pet gameplay;
- REASONING.

### Advance gate

Offline/replay policy tests must show default mode is unchanged and Pet Skill mode behaves deterministically.

---

## 3C.2 — UI ↔ FarmRunner Pet-Skill Integration

### Goal category

Small live farm integration.

### Required live modes

Primary:

```text
Legendary
No Evolution
Pet Skill
```

Backward compatibility smoke:

```text
Normal
Normal Evolution
Default Attack
```

### Suggested acceptance

Primary mode:

- ~5 completed matches;
- no EVOLVE;
- Pet Skill used when requirements/actionability permit;
- no default Attack if policy says Pet Skill-only;
- QTE correctness/Perfect invariant holds;
- no stale QTE across matches;
- no extra attempt after target;
- zero critical safety counters.

Default mode:

- one small normal BASIC smoke;
- no unexpected Pet Skill action.

### Advance gate

FarmRunner/UI integration must be stable before performance claims.

---

## 3D.1 — Performance / Efficiency A-B Comparison

### Goal category

Measure the user's optimization objective.

Suggested A/B:

```text
A:
Normal
Normal Evolution
Default Attack

B:
Legendary
No Evolution
Pet Skill
```

Use same build and same boss conditions as reasonably possible.

Suggested 5–10 completed matches per mode.

Record:

- mean/median combat duration;
- full farm-cycle duration;
- SWAPs/match;
- skill uses/match;
- Perfect rate;
- attempts/completion;
- technical abort/recovery;
- WIN/LOSS/UNKNOWN.

Energy:

- use authoritative energy evidence if available;
- otherwise report `NOT_MEASURED`;
- do not infer from elapsed time.

### Advance gate

Performance data must be recorded before claiming the new mode is faster/more efficient.

---

## 3D.2 — 25-Match Pet-Skill Soak

### Goal category

Long-run reliability.

Mode:

```text
Legendary
No Evolution
Pet Skill
```

Required:

- exactly 25 completed results;
- correct W/L/U accounting;
- bounded attempts;
- no extra attempt after target;
- zero stale QTE across MatchIds;
- zero old skill-card reuse after recovery;
- Perfect invariant maintained for accepted skill uses;
- no duplicate/stale/wrong-turn input;
- technical recovery, if naturally encountered, starts with fresh card/QTE state;
- controller stops safely;
- UI/poller shutdown clean.

Do not fabricate a technical incident.

### Advance gate

Long-run reliability must pass before packaging/release.

---

## 3E.1 — Packaged Pet-Skill Release Acceptance

### Goal category

Final packaged release for the new feature scope.

Required categories:

- clean reproducible Windows package;
- clean staging outside repo;
- safe writable app-data paths;
- default BASIC packaged smoke;
- Legendary/No-Evolution/Pet-Skill packaged smoke;
- Perfect QTE;
- graceful stop;
- Emergency Stop during/around QTE;
- checkpoint/resume;
- zero runtime writes to game install/source/exe directory;
- final regression;
- docs;
- manifest;
- SHA-256;
- release commit/tag;
- clean Git state.

Version:

- not fixed by this roadmap;
- a minor release such as `v1.1.0` is only a planning candidate.

### Completion

Declare the defined Pet Skill roadmap complete only after this phase passes final packaged acceptance.

---

# IF SOMETHING FAILS

Do NOT blindly advance.

Examples:

```text
3A.1-R1 — Resolve QTE sequence source ambiguity
3B.1-R1 — Fix shadow QTE owner correlation
3B.2-R1 — Prevent duplicate direction input
3B.3-R1 — Correct Perfect timing drift
3C.2-R1 — Block stale Pet Skill after recovery
3E.1-R1 — Fix frozen build QTE keyboard input
```

Return to the main roadmap only after the blocker is accepted.

---

# GLOBAL OUT-OF-SCOPE UNLESS USER EXPLICITLY EXPANDS

- REASONING;
- infinite/unbounded farming;
- login automation;
- game process relaunch;
- memory writes;
- direct game-method skill calls;
- packet/network manipulation;
- Mega gameplay;
- Evolved-pet gameplay;
- automatic policy across all skill families;
- ambiguous multi-skill auto-selection.
