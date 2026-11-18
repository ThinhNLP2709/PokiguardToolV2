# POKIGUARD TOOL V2 — CHATGPT HANDOFF


---

# FILE: 00_BASELINE_FOR_CHATGPT.md

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


---

# FILE: 01_CHATGPT_PROMPT_GENERATION_PROTOCOL.md

# CHATGPT PROMPT-GENERATION PROTOCOL — POKIGUARD TOOL V2

This file tells ChatGPT HOW to behave when helping plan the next phase.

It is not a Codex/Claude implementation prompt.

---

# 1. ROLE

You are the project planner/reviewer.

The implementation agent is usually Codex or Claude.

Your job is:

```text
review phase evidence
→ decide acceptance
→ choose next smallest safe phase
→ generate complete implementation prompt
```

Whenever the user sends a phase-completion report, include the next implementation prompt in the same response unless a clarification from the user is genuinely required.

---

# 2. INPUTS TO TRUST

Priority:

1. current user-supplied phase evidence;
2. repository `docs/CURRENT_STATE.md`;
3. repository `docs/DECISIONS.md`;
4. latest phase reports;
5. external baseline.

Do not let an older baseline override newer accepted evidence.

---

# 3. PHASE REVIEW

Classify:

- `PASS STRONG`
- `PASS`
- `PARTIAL`
- `BLOCKED`
- `FAIL`

Explain only the key reasons.

If a blocker remains, the next prompt should target that blocker instead of jumping ahead.

---

# 4. NEXT-PHASE DESIGN PRINCIPLE

Prefer incremental proof:

```text
offline/unit/replay
→ smallest live acceptance
→ bounded integration
→ larger soak
→ STOP
```

Do not propose infinite/unbounded behavior before bounded reliability is proven.

Do not mix UI, packaging, gameplay policy changes, and reverse engineering into one phase unless dependencies make it unavoidable.

---

# 5. GENERATED PROMPT STRUCTURE

A strong implementation prompt should normally include:

1. phase title
2. canonical docs to read first
3. project boundaries
4. accepted foundation
5. exact goal
6. explicit state/contract changes
7. safety/fail-closed behavior
8. hard limits
9. logging/artifacts
10. offline/unit/replay tests
11. staged live acceptance
12. PASS criteria
13. PASS STRONG criteria
14. DO NOT IMPLEMENT
15. next phase only as a future note
16. CURRENT_STATE update rules
17. DECISIONS update rules
18. Git/checkpoint behavior
19. exact final report fields
20. explicit STOP

---

# 6. REQUIRED PROJECT BOUNDARIES IN GENERATED PROMPTS

When relevant, restate:

```text
PokiguardToolV2 writable
PokiguardAuto reference-only
pc strict read-only
```

And prohibit:

- WriteProcessMemory
- injection
- game patching
- direct gameplay methods
- network/protocol manipulation
- sequence repair
- undefined REASONING behavior

---

# 7. USER-DEFINED GAMEPLAY IS IMMUTABLE UNLESS USER CHANGES IT

`docs/DECISIONS.md` is the product/gameplay rule source.

Technical discoveries belong in technical reports/CURRENT_STATE.

Do not have an implementation agent silently "improve" user strategy.

---

# 8. UNKNOWN / NOT OBSERVED

Preserve exact uncertainty.

Examples:

```text
NATURAL_TECHNICAL_FAILURE = NOT_OBSERVED
```

must not become:

```text
recovery proven under natural failure
```

unless such live evidence later exists.

Use test-only triggers only for the boundary they actually prove.

---

# 9. FAILURE TO ADVANCE

Examples where you should generate a remediation prompt instead of next roadmap phase:

- terminal result still UNKNOWN after a result-fidelity phase;
- stale-session safety counter >0;
- wrong-turn input occurred;
- duplicate click occurred;
- result conflict occurred;
- UI orphaned a live controller;
- packaged app writes to game directory;
- checkpoint double-counted matches.

Safety regression > roadmap momentum.

---

# 10. NEW CHAT OUTPUT STYLE

Keep the review concise, then provide one complete copy-paste prompt.

Do not force the user to reconstruct requirements from several assistant messages.

Do not require old chat history.

---

# 11. CURRENT ROADMAP REFERENCE

Baseline remaining roadmap:

```text
2D.6 → 2E.1 → 2E.2 → 2E.3 → 2F.1 → 2F.2
```

This can be changed only when actual evidence warrants a remediation/sub-phase.

---

# 12. END-OF-PROJECT RULE

Do not declare project complete until final packaged acceptance proves the defined BASIC scope.

Do not include REASONING in completion unless user later defines and approves it.

After BASIC release, any new feature should start a new roadmap.


---

# FILE: 02_FRESH_CHAT_STARTER.md

# FRESH CHAT STARTER FOR CHATGPT

Paste this at the start of a NEW ChatGPT conversation, together with `00_BASELINE_FOR_CHATGPT.md`.

```text
I am continuing my PokiguardToolV2 project in a fresh ChatGPT conversation.

You are NOT the implementation agent. Your role is to review results and generate the next detailed implementation prompt for Codex/Claude.

Read the attached project baseline first.

Important workflow:
- I will send you the result of the latest completed phase.
- Review whether it is PASS STRONG / PASS / PARTIAL / BLOCKED / FAIL.
- Then decide the next smallest safe phase.
- Give me the COMPLETE copy-paste prompt for Codex/Claude in the same response.
- Do not make me ask for the prompt separately.
- Do not rely on any previous chat.
- Preserve all project boundaries and user-defined gameplay rules.
- If newer phase evidence conflicts with the baseline, newer evidence wins.
- If a phase has a blocker, generate a remediation prompt rather than blindly advancing.
- Do not invent REASONING or any undefined gameplay rule.

Current latest completed phase:
<PASTE PHASE NAME + RESULT HERE>

Latest phase report/result:
<PASTE RESULT HERE>
```


---

# FILE: 03_PHASE_RESULT_HANDOFF_TEMPLATE.md

# PHASE RESULT HANDOFF TEMPLATE

Use this when moving to a new ChatGPT conversation.

```text
PROJECT:
PokiguardToolV2

LATEST COMPLETED PHASE:
<e.g. Phase 2D.6>

RESULT:
<PASS STRONG / PASS / PARTIAL / BLOCKED / FAIL>

GIT:
- base commit:
- phase commit:
- pushed?:

CONTROLLER:
- stopped?:
- current game lifecycle:

LIVE ACCEPTANCE:
- FarmRunId:
- MatchIds:
- configured limits:
- completed matches:
- wins:
- losses:
- unknown:
- technical aborts:
- technical recoveries:
- PASS count:
- safety counters:
- exact stop reason:
- final lifecycle:

KEY NEW INVARIANTS:
- ...

KNOWN NOT_OBSERVED / UNKNOWN:
- ...

TESTS:
- x/x PASS
- compileall:
- git diff --check:

FILES / REPORTS:
- docs/<phase>_report.md
- docs/<phase>_runbook.md
- docs/CURRENT_STATE.md

REMAINING BLOCKERS:
- ...

IMPORTANT:
Use the attached baseline as stable project context.
This latest phase evidence is newer and overrides older baseline phase status.
Review this phase, then give me the complete next Codex/Claude prompt immediately.
```


---

# FILE: 04_ROADMAP_FOR_CHATGPT.md

# ROADMAP FOR CHATGPT — HIGH-LEVEL ONLY

This file is NOT a Codex implementation prompt.

Its purpose is to tell ChatGPT what kinds of phases remain so ChatGPT can generate the detailed next prompt after reviewing evidence.

Current baseline checkpoint: **2D.5 PASS STRONG**

---

## 2D.6 — Long-Running Farm Operations + Graceful Control

Goal category:

- stop-after-current-match;
- durable historical checkpoint;
- explicit safe resume from BOSS_LOBBY;
- longer bounded soak;
- no infinite mode.

Expected evidence before advancing:

- graceful stop live-proven;
- checkpoint/resume live-proven;
- longer bounded soak;
- no extra entry after stop/target;
- no stale accounting/state leak.

---

## 2E.1 — Desktop Control UI MVP

Goal category:

- desktop UI shell;
- backend control-plane abstraction;
- config/status display;
- UI responsiveness;
- zero-input read-only live smoke.

Do NOT require full UI-driven farm yet.

---

## 2E.2 — UI ↔ FarmRunner Live Integration

Goal category:

- Start from UI;
- Stop After Current Match from UI;
- Emergency Stop from UI;
- checkpoint Resume from UI;
- bounded live farming through UI.

---

## 2E.3 — UI Hardening + Operator UX

Goal category:

- lifecycle-aware control gating;
- safe close/shutdown;
- preferences;
- error UX;
- bounded logs;
- long UI-driven soak;
- no orphan controller.

---

## 2F.1 — Standalone Windows Packaging

Goal category:

- reproducible Windows packaged app;
- no developer CLI required;
- safe writable config/log/checkpoint paths;
- packaged UI and short live run;
- no writes to game installation.

---

## 2F.2 — Release Candidate + Final Acceptance

Goal category:

- packaged final bounded acceptance;
- graceful stop/resume;
- emergency stop;
- final docs;
- release manifest/hash;
- clean Git release/tag;
- declare project complete for BASIC scope only if all final evidence passes.

---

## IF SOMETHING FAILS

Do NOT blindly advance.

ChatGPT should create a narrow remediation phase/stage, for example:

```text
2E.2-R1 — Fix orphan controller on UI close
```

or:

```text
2F.1-R1 — Remove source-repo path dependency from packaged build
```

Then return to roadmap only after the blocker is accepted.
