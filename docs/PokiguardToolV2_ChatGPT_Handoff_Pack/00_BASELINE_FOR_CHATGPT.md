# POKIGUARD TOOL V2 — BASELINE FOR CHATGPT

**Purpose:** This file is NOT a task prompt for Codex/Claude.  
It is a long-term project baseline to give to ChatGPT in a fresh conversation so ChatGPT can understand the project state and generate the next implementation prompt for Codex/Claude.

**Baseline date:** 2026-08-19  
**Current completed phase at this baseline:** Phase 2D.5 — PASS STRONG  
**Latest accepted Git commit:** `774386e17e298817e048936be6747f1062396a08`  
**Next expected phase:** Phase 2D.6

If repository evidence later becomes newer than this file, the repository wins.

---

# 1. CHATGPT'S ROLE

ChatGPT is the planning/review layer.

ChatGPT should NOT assume it is directly implementing the game tool.

The normal workflow is:

```text
User runs Codex/Claude on one implementation phase
        ↓
User sends phase result to ChatGPT
        ↓
ChatGPT reviews evidence
        ↓
ChatGPT decides PASS / PASS STRONG / PARTIAL / BLOCKED
        ↓
ChatGPT chooses the next safest phase
        ↓
ChatGPT writes a complete copy-paste implementation prompt
        ↓
User gives that prompt to Codex/Claude
```

When the user sends the end result of a phase, ChatGPT should normally return:

1. short review of the result;
2. whether the phase is accepted;
3. remaining blocker(s), if any;
4. next phase/stage name;
5. a complete copy-paste prompt for Codex/Claude;
6. explicit STOP boundary for that next phase.

Do not make the user ask a second time for the next prompt.

---

# 2. PROJECT PURPOSE

`PokiguardToolV2` is a Windows automation tool for the Unity IL2CPP game Pokiguard.

Production architecture:

```text
Pokiguard.exe
    ↓
external read-only process memory
    ↓
runtime state providers
    ↓
GameState
    ↓
deterministic board simulator
    ↓
BASIC gameplay policy
    ↓
actionability/safety gates
    ↓
normal foreground Windows input
```

Farm lifecycle:

```text
Boss lobby
→ exact configured boss
→ normal Windows entry
→ fresh combat session
→ BASIC combat
→ postmatch
→ boss lobby
→ next bounded match
```

Technical recovery:

```text
SEQUENCE_DESYNC
or DEAD_BOARD_NO_REFRESH
→ gameplay lock
→ normal UI exit
→ confirm
→ boss lobby
→ fresh exact-target re-entry
→ fresh session
→ BASIC resumes
```

---

# 3. REPOSITORY ROLES

```text
PokiguardToolV2 = PRIMARY / WRITABLE
PokiguardAuto   = REFERENCE ONLY
pc              = STRICTLY READ ONLY
```

Never propose implementation that requires modifying `PokiguardAuto` or `pc`.

---

# 4. HARD TECHNICAL BOUNDARIES

Allowed:

- external process memory READS;
- own solver/policy;
- normal foreground Windows mouse/keyboard input;
- read-only reverse engineering of local game files;
- local tests/logs/artifacts.

Forbidden unless the user explicitly changes project scope:

- `WriteProcessMemory`;
- modifying game memory;
- DLL injection;
- remote thread;
- patching game files;
- direct gameplay IL2CPP calls;
- direct `RequestSwap`;
- direct `MatchService.SendMove`;
- packet/network manipulation;
- sequence forging/repair;
- protocol bypass.

Any generated implementation prompt should restate these boundaries when relevant.

---

# 5. GAME / RUNTIME FOUNDATION

Known:

- Unity `6000.0.26f1`
- client `1.7.1`
- Windows x64 IL2CPP
- server-authoritative combat/session behavior
- ASLR: module-relative resolution, no absolute-address hardcoding

Production board source:

```text
WsCombatBatch.board / BoardCellDTO
```

Current board model:

- 8×8
- 64 cells
- unique coordinates
- GemType
- multipliers x1/x2/x3/x4
- current-session/currentness validation
- board hash/stability gating

`Dot` is optional telemetry/validation.  
CV is audit/reference, not production board truth.

Coordinate normalization has already been resolved in production. A new agent should inspect current code before changing row/column transforms.

---

# 6. GAMEPLAY DEFINITIONS

Gems:

- SWORD — attacks boss
- MANA — gains mana
- RAGE — gains rage
- SHIELD — defensive resource
- HEALTH — heals
- DRAIN — drains opponent mana/rage

Rage:

```text
max = 250
important breakpoint = 100
```

User configs:

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

Current product scope:

```text
BASIC = defined and implemented
REASONING = intentionally undefined
```

ChatGPT must NOT invent REASONING rules.

Health thresholds:

```text
SIMPLE  → own HP low <30%
CAREFUL → own HP low <50%
```

Detailed gameplay truth lives in repository:

- `docs/DECISIONS.md`
- `docs/basic_gameplay_policy.md`

---

# 7. HIGH-LEVEL BASIC POLICY

This is orientation only. Repository policy is canonical.

1. If `ManaPriority=EVOLUTION`, not fused, enough mana, and safe/actionable → EVOLVE.
2. SWORD is highest board objective.
3. Evaluate deterministic cascades, not only direct matches.
4. A non-Sword direct move may be better if its deterministic cascade collects more Sword.
5. Rage below 100 is an important safe objective.
6. `100 <= Rage < 250`: Rage remains a valid safe fallback.
7. At max Rage, do not collect Rage solely for Rage value.
8. Health follows PlayStyle threshold and accepted boss-HP condition.
9. CAST follows current policy and consumes a turn.
10. Drain/Shield/safe-resource fallback follow current accepted policy.
11. Mandatory consuming action with no safe move → least-dangerous legal consuming move; never random.
12. Undefined situation → fail closed; do not invent policy.

---

# 8. BOARD SIMULATOR

Current simulator:

- evaluates all 112 adjacent swap pairs;
- distinguishes legal / safe / dangerous;
- deterministic known-board cascade simulation;
- top/off-board new spawns remain UNKNOWN;
- accounts for Sword opportunity/danger.

Canonical dead board:

```text
ACTIVE/current/stable 64-cell board
AND
legalMatchProducingMoves == 0
```

Do not confuse with:

```text
legal > 0
safe == 0
```

---

# 9. AUTONOMOUS ACTION SEMANTICS

## SWAP

Production accepted.

- normal Windows two-click input;
- fresh proposal;
- immediate revalidation;
- input lock;
- ACK/terminal synchronization;
- no stale/duplicate execution.

## EVOLVE

Production accepted.

- observed accepted cost: 160 mana;
- does NOT consume turn;
- failure may retry only under current bounded safety contract;
- success → reread full state → may still perform consuming action same turn.
- if ManaPriority=ATTACK → do not evolve.

## CAST

Production accepted.

- dynamic ATTACK card resolution;
- no product hard-code of historical card ID 4;
- runtime cost/state is source of truth;
- observed accepted cost: 160;
- consumes turn;
- no same-turn SWAP after accepted CAST.

## PASS

Production accepted using authoritative game/server evidence.

- PASS = zero Windows gameplay input;
- never use a local authoritative idle counter;
- first local turn cannot PASS;
- authoritative 1/3 and 2/3 observed;
- threshold-1 → next action must consume turn;
- SWAP/CAST can satisfy mandatory consuming action;
- EVOLVE alone cannot;
- rejected action does not count as a successful reset;
- UNKNOWN authoritative state → fail closed;
- no third PASS.

---

# 10. SESSION / ACTIONABILITY

Current production state includes:

- MatchId
- CombatSessionKey
- lifecycle epoch
- current turn
- local actor
- timer
- board currentness
- `srvSeq`
- player/boss stats
- card state
- fusion state
- authoritative idle state
- sequence-desync sticky state

Before input, revalidate current lifecycle/session/turn/board/modal/desync/timer/foreground/pending/proposal state.

Unknown/ambiguous → fail closed.

Old server objects may remain after local exit. They must remain non-actionable if local lifecycle is lobby/postmatch.

---

# 11. SEQUENCE DESYNC

Production detection includes:

- `FORCE_RESYNC`
- structured sequence gap
- structured duplicate
- structured reject reason from resolved DTO path

Semantics:

```text
SEQUENCE_DESYNC
→ terminal for failed session
→ block gameplay
→ invalidate pending/proposal
→ no retry
```

Never generate prompts that "fix" sequence by network/memory manipulation.

---

# 12. TECHNICAL RECOVERY

Phase 2D.3 = PASS STRONG.

Accepted live path:

```text
technical trigger
→ gameplay lock
→ <<
→ stable confirm modal
→ Đồng ý
→ local combat ends
→ BOSS_LOBBY
→ failed session invalidated
→ exact Starburst 1289
→ normal UI re-entry
→ fresh MatchId/session
→ opening 64/64
```

Phase 2D.4 also proved:

```text
fresh recovered opening
→ fresh BASIC decision
→ consuming action
→ ACK
```

Natural technical failure in long runs can remain `NOT_OBSERVED`; never propose deliberately corrupting memory/network/game state to create it.

---

# 13. BOSS ENTRY / POSTMATCH

Current configured target:

```text
Starburst
Boss ID = 1289
```

Architecture remains target-configurable.

Accepted boss entry:

```text
BOSS_LOBBY
→ exact target resolve
→ normal UI entry
→ fresh combat
→ opening 64/64
```

Accepted normal postmatch:

```text
combat terminal
→ result/postmatch
→ validated Đồng ý when required
→ BOSS_LOBBY
```

No gameplay input in lobby/postmatch.

---

# 14. TERMINAL RESULT FIDELITY

Phase 2D.5 fixed/revalidated terminal result capture before ownership/session cleanup.

Result enum:

```text
WIN
LOSS
UNKNOWN
```

Invariant:

```text
wins + losses + unknown_results == completed_matches
```

UI `THẮNG/THUA` is audit/consistency evidence, not sole production truth.

---

# 15. ACCEPTED PHASE HISTORY

Important milestones:

```text
2B.5       Memory board hardening              PASS STRONG
2C.1       Safe single-step input               PASS STRONG
2C.2B/B5   Full BASIC combat                    FULL_MATCH_PASS
2D.1       One-shot boss entry                  PASS STRONG
2D.2       One complete farm cycle              PASS STRONG
2D.3       Automatic technical recovery         PASS STRONG
2D.4       Bounded multi-match + recovery resume PASS STRONG
2D.5       Result fidelity + 10-match soak      PASS STRONG
```

---

# 16. LATEST ACCEPTED PHASE — 2D.5

Live B2:

```text
FarmRunId:
b63cd48b836c4aa6bb8f7092c06776aa

limits:
10 completed matches
max 2 technical recoveries
max 14 attempts

results:
10 WIN
0 LOSS
0 UNKNOWN

memory/UI consistency:
10/10

technical abort/recovery:
0/0

PASS:
25
0 Windows input

final lifecycle:
BOSS_LOBBY

attempt #11:
0

soak:
45m 53.934s
```

Validation:

```text
409/409 tests PASS
compileall PASS
git diff --check PASS
worktree clean
controller stopped
```

Git:

```text
2D.4 base:
f87eb9ec5f2e794de635a1d4dbe63375371a142c

2D.5:
774386e17e298817e048936be6747f1062396a08
pushed to origin/main
```

---

# 17. CURRENT ROADMAP FROM THIS BASELINE

```text
2D.6
Long-running operations
- graceful stop-after-current-match
- durable checkpoint accounting
- explicit safe resume from boss lobby
- 25-match bounded soak

2E.1
Desktop Control UI MVP
- UI shell/control plane
- config/status
- read-only live smoke
- no full UI farm acceptance yet

2E.2
UI ↔ FarmRunner Live Integration
- Start from UI
- graceful stop from UI
- emergency stop from UI
- checkpoint resume from UI
- bounded UI-driven farm

2E.3
UI Hardening + Operator UX
- validation/error states
- lifecycle-aware controls
- safe close
- preferences
- bounded logs
- long UI-driven soak

2F.1
Standalone Windows Packaging
- reproducible packaged app
- writable data paths
- packaged live validation

2F.2
Release Candidate + Final Acceptance
- packaged final run
- graceful stop/resume
- emergency stop
- final docs
- release/tag
- BASIC scope complete
```

This roadmap is a planning baseline, not immutable law. If a future phase exposes a real blocker, ChatGPT should insert a narrowly scoped remediation phase/stage instead of blindly advancing.

---

# 18. CURRENT DEFINITION OF PROJECT COMPLETE

The current BASIC-scope project is complete when:

1. Desktop Windows app launches normally.
2. Game is detected/attached read-only.
3. UI shows connection/lifecycle.
4. User configures supported BASIC settings.
5. User configures target and finite run limits.
6. User starts bounded farming from UI.
7. Correct boss is entered via normal UI.
8. BASIC combat runs autonomously.
9. Normal postmatch is handled.
10. Supported technical recovery works.
11. Multiple fresh matches chain safely.
12. WIN/LOSS/UNKNOWN accounting is accurate.
13. Stop-after-current-match works.
14. Emergency stop works.
15. Durable historical checkpoint works.
16. Explicit safe resume works from BOSS_LOBBY.
17. UI stays responsive and reflects backend state.
18. Standalone Windows build works without developer CLI.
19. Final packaged acceptance has zero critical safety violations.
20. Docs/release artifact are complete.
21. Git release state is clean.

Not required:

- REASONING
- infinite/unbounded farming
- auto game launch/restart
- login automation
- multi-target rotation
- Windows service/daemon
- memory writes
- network manipulation

---

# 19. HOW CHATGPT SHOULD GENERATE THE NEXT IMPLEMENTATION PROMPT

When the user provides a phase result:

## Step A — Review evidence

Determine:

```text
PASS STRONG
PASS
PARTIAL
BLOCKED
FAIL
```

Do not overstate unobserved evidence.

## Step B — Identify the next smallest safe objective

Prefer:

```text
one new boundary
→ offline/unit tests
→ small live acceptance
→ larger bounded acceptance
→ STOP
```

Do not combine several unproven systems into one giant leap.

## Step C — Preserve accepted foundation

The generated prompt should begin with:

```text
Read AGENTS.md
Read docs/CURRENT_STATE.md
Read docs/DECISIONS.md
```

Then read only relevant latest phase reports.

## Step D — Explicitly define:

- exact goal
- project boundaries
- accepted foundation
- new state machine/contract
- failure paths
- hard limits
- offline tests
- live stages
- PASS criteria
- PASS STRONG criteria
- DO NOT IMPLEMENT
- canonical doc update
- Git behavior
- final report
- explicit STOP

## Step E — Never fabricate future evidence

If a thing is `NOT_OBSERVED`, keep it `NOT_OBSERVED`.

Do not turn a test-only trigger into proof of a natural runtime event.

## Step F — Do not invent gameplay

If the next phase would require a gameplay/product rule absent from `DECISIONS.md`, ChatGPT should flag it and ask the user to define it instead of inventing it.

---

# 20. WHEN USER SENDS A PHASE RESULT

ChatGPT should answer in this pattern:

```text
<short review>

Phase X is accepted as PASS/PASS STRONG because:
- ...
- ...

Remaining limitations:
- ...

Next phase:
Phase Y — <name>

Why this is next:
<brief explanation>

Copy this entire prompt to Codex/Claude:

<full detailed prompt>

When that phase finishes, send me the final report and I will review it and generate the next phase prompt.
```

The user has explicitly asked ChatGPT to automatically include the next prompt whenever a phase ends.

---

# 21. NEW CONVERSATION RULE

A fresh ChatGPT conversation should not need the old long chat.

The user should provide:

1. this baseline;
2. the latest phase result or current `CURRENT_STATE.md` summary;
3. optionally the latest phase report.

ChatGPT should then generate the next implementation prompt.

If the user's latest phase is newer than this baseline, trust the newer supplied phase evidence and use this baseline only for stable project rules/history.

---

# 22. CRITICAL NON-INVENTION RULES FOR CHATGPT

Never silently invent:

- REASONING strategy;
- a new PASS reset rule;
- a new dead-board definition;
- new network recovery behavior;
- target IDs not evidenced;
- memory offsets not evidenced;
- result truth not evidenced;
- natural technical failures that were not observed;
- a claim that a phase passed when acceptance evidence is incomplete.

If necessary, generate a remediation/verification prompt instead of advancing.

---

# 23. CURRENT NEXT PHASE AT THIS BASELINE

```text
Phase 2D.6 — Long-Running Farm Operations + Graceful Control
```

Expected major goals:

- stop-after-current-match;
- durable historical checkpoint;
- explicit BOSS_LOBBY resume;
- longer bounded soak;
- no infinite mode yet.

A fresh ChatGPT conversation should generate the detailed 2D.6 Codex/Claude prompt from this baseline plus current repository evidence.
