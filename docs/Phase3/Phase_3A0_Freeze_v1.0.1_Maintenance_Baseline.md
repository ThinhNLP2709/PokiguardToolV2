# Phase 3A.0 — Freeze `v1.0.1` Maintenance Baseline

Implement **Phase 3A.0 ONLY** for `PokiguardToolV2`.

This is a finalization/live-validation phase for the already implemented `v1.0.1` maintenance changes.

Do NOT implement Pet Skill/QTE features in this phase.

---

# 0. READ FIRST

Read:

1. `AGENTS.md`
2. `docs/CURRENT_STATE.md`
3. `docs/DECISIONS.md`
4. `docs/gameplay_rules.md`
5. `docs/basic_gameplay_policy.md`
6. latest Phase 2F.2 report/runbook
7. current source diff and tests touching:
   - card click coordinates;
   - postmatch/result confirmation;
   - board simulator;
   - BASIC Sword safety;
   - Sword-hold logic.

Before changing anything:

```bash
git status --short
git rev-parse HEAD
git rev-parse origin/main
git diff --stat
git diff
```

The previous released BASIC tag is `v1.0.0+15`.

Current local source has been labelled `v1.0.1`.

Repository truth wins if current evidence is newer.

---

# 1. EXACT GOAL

Freeze the current `v1.0.1` maintenance source as a clean accepted checkpoint.

The implemented maintenance changes to validate are:

1. EVOLVE/CAST physical click moved upward:
   - old normalized click Y: `0.836`
   - new normalized click Y: `0.824`
   - visual/card validation region remains unchanged.

2. postmatch confirmation latency reduced:
   - redundant fixed wait reduced from 5s to 1s;
   - result confirm still requires authoritative POSTMATCH;
   - stable/high-confidence modal evidence;
   - fresh foreground/lifecycle preflight;
   - exactly one normal confirm click.

3. stronger Sword safety:
   - every legal deterministic boss reply on settled known board is audited;
   - direct Sword reply;
   - non-Sword direct reply whose deterministic collapse/cascade collects Sword;
   - ordinary "safe" requires neither known reply path;
   - unique adverse-Sword move may be deferred;
   - safe resource / authoritative PASS / proven Sword-hold fallback as already implemented;
   - Sword-hold remains dangerous;
   - UNKNOWN never counts as favorable proof.

Do not redesign these changes unless final validation exposes a narrow bug.

---

# 2. HARD PROJECT BOUNDARIES

Repository roles:

```text
PokiguardToolV2 = WRITABLE
PokiguardAuto = REFERENCE ONLY
pc = STRICT READ ONLY
```

Allowed:

- external read-only process memory;
- deterministic policy/simulator;
- normal foreground Windows input;
- local tests/logs.

Forbidden:

- WriteProcessMemory;
- injection/hooking/remote thread;
- game patching;
- direct gameplay IL2CPP calls;
- direct RequestSwap/SendMove;
- packet/network manipulation;
- sequence repair/forging.

Do not introduce Pet Skill/QTE code here.

---

# 3. FREEZE CURRENT SCOPE

Do NOT add:

- Main Pet field;
- Evolution Target field;
- Damage Card field;
- ManaPriority migration/removal;
- Pet Skill action;
- QTE reverse;
- direction input;
- Space/Perfect automation;
- new packaging/release tag.

Only narrow fixes necessary to make the current maintenance changes pass are allowed.

---

# 4. OFFLINE VALIDATION

First run the existing targeted tests for:

- gameplay UI/card click;
- postmatch confirmation;
- board simulator;
- direct/indirect opponent Sword replies;
- unique adverse-Sword defer;
- Sword-hold;
- PASS/mandatory-action regression around the new exception.

The latest reported full baseline before this phase is:

```text
745/745 PASS
```

Do not hard-code this expected count in the implementation.

Report the actual current count.

Run the canonical full regression suite.

Then:

```text
compileall
git diff --check
```

All must pass before live validation.

---

# 5. LIVE ACCEPTANCE — BOUNDED BASIC RUN

Use the ordinary Desktop UI/source launcher.

Do NOT rebuild/package first.

Recommended:

```text
3–5 completed matches
```

Use the currently accepted normal/default BASIC configuration so this is a maintenance validation, not a new strategy test.

Start from the normal exact boss-room prerequisite.

---

# 6. LIVE CARD-CLICK VALIDATION

The purpose is to prove the new Y `0.824` click remains safe.

Where naturally available during the bounded run, capture:

- EVOLVE attempt/success/failure;
- default Attack CAST;
- exact validated card identity/slot;
- actual click coordinate;
- foreground/client geometry;
- card response/result.

Required critical values:

```text
card misclick = 0
partial click = 0
wrong card = 0
duplicate click = 0
stale card click = 0
```

PASS STRONG should preferably observe at least one EVOLVE and one CAST using the shared new click boundary.

If only one of the two naturally occurs but:
- both share the same validated executor/coordinate path;
- focused tests cover both;
- live click is clean;

record the unobserved branch honestly rather than forcing gameplay just to create evidence.

---

# 7. LIVE POSTMATCH SPEED VALIDATION

For each completed match capture enough timestamps to distinguish:

```text
terminal/result known
reward/modal ready
stable confirm evidence
final preflight
confirm click
BOSS_LOBBY
```

Goal:

- remove the old unnecessary ~5-second delay;
- keep all safety checks;
- no premature click;
- no double click.

Do NOT enforce an unrealistic hard SLA under server lag.

Under normal conditions, the confirm should occur promptly after the button/modal is proven ready, rather than waiting the historical fixed 5 seconds.

Report observed latency distribution if the telemetry exists.

Critical:

```text
confirm before proven POSTMATCH = 0
confirm before stable modal = 0
duplicate confirm = 0
wrong modal click = 0
```

---

# 8. LIVE SWORD-SAFETY VALIDATION

The new direct/indirect reply evaluator is primarily proven by deterministic tests/replays.

During the live bounded run:

- record the selected move's direct opponent Sword reply count;
- indirect opponent Sword reply count;
- max effective known opponent Sword reply where telemetry exists;
- selected action reason;
- safety classification.

Required:

```text
ordinary move labelled safe while known direct Sword reply exists = 0
ordinary move labelled safe while known indirect Sword reply exists = 0
UNKNOWN used as favorable proof = 0
```

A natural unique adverse-Sword/Sword-hold situation is useful but NOT mandatory.

If it does not occur:

```text
LIVE_SWORD_HOLD = NOT_OBSERVED
```

Do not manufacture a board state through game modification.

Offline deterministic fixtures must cover the exception.

---

# 9. GENERAL LIVE SAFETY

Required critical counters remain zero:

```text
wrong-turn input
misclick
partial input
duplicate input
stale input
boss-turn input
postmatch-invalid gameplay input
sequence desync caused by tool behavior
terminal result conflict
duplicate controller
orphan controller
orphan poller
```

Natural technical recovery may occur.

Do not force it.

If none occurs, record `NOT_OBSERVED`.

---

# 10. RESULT / FARM INVARIANTS

For the bounded run:

```text
wins + losses + unknown == completed_matches
```

No extra attempt after the configured target.

Technical aborts are not completed matches.

Expected final normal boundary:

```text
BOSS_LOBBY
controller STOPPED
```

Do not require all WINs.

An unexplained UNKNOWN should block PASS STRONG.

---

# 11. DOCUMENTATION

After live evidence is complete, update accurately:

- `docs/CURRENT_STATE.md`
- `README.md` if current release/source status requires it
- create a focused maintenance report/runbook if repository conventions support it, for example:
  - `docs/phase3a0_report.md`
  - `docs/phase3a0_runbook.md`

`docs/DECISIONS.md` should change only if the maintenance rules implemented are not already canonical there.

Do NOT add the new Pet Skill config/product rules in this phase.

That belongs to the later roadmap.

---

# 12. FINAL REGRESSION

After all narrow fixes/docs:

Run again:

```text
focused tests
full regression
compileall
git diff --check
```

Report exact counts.

Do not reuse an earlier count blindly.

---

# 13. GIT CHECKPOINT

Before commit:

```bash
git status --short
git diff
git diff --check
```

Review all paths.

Commit only the intended `v1.0.1` maintenance changes and their canonical docs/tests.

Do not mix Pet Skill/QTE work.

Push to `origin/main` according to the current repository workflow.

Then verify:

```bash
git rev-parse HEAD
git rev-parse origin/main
git status --short
```

Required for PASS STRONG:

```text
main == origin/main
worktree clean
```

Do not create a new packaged release tag in this phase.

---

# 14. PASS CRITERIA

Phase 3A.0 can PASS only if:

1. current maintenance diff is fully understood;
2. focused tests pass;
3. full regression passes;
4. compileall passes;
5. git diff --check passes;
6. bounded live BASIC run completes;
7. new card click causes zero click safety violations;
8. postmatch confirm remains lifecycle/modal safe;
9. the historical fixed delay is demonstrably removed;
10. new Sword evaluator does not introduce a live safety regression;
11. direct/indirect Sword tests pass;
12. unique adverse-Sword/Sword-hold tests pass;
13. result accounting is consistent;
14. no extra attempt after target;
15. docs reflect actual evidence;
16. final controller/UI is stopped.

---

# 15. PASS STRONG CRITERIA

PASS STRONG requires PASS plus:

- clean bounded multi-match live run;
- at least one clean current card-action click using the new coordinate;
- preferably both EVOLVE and CAST live-observed if naturally available;
- every postmatch confirm clean and prompt;
- zero critical safety counters;
- no unexplained UNKNOWN result;
- full regression green after final changes;
- focused commit pushed;
- `main == origin/main`;
- worktree clean.

Rare Sword-hold live observation is NOT required if it remains genuinely absent and deterministic tests/replays prove it.

Do not fabricate it.

---

# 16. BLOCKERS

Block acceptance for:

- card misclick/wrong card;
- premature result confirm;
- duplicate result confirm;
- safe-labelled move with known direct/indirect Sword reply;
- stale input;
- wrong-turn input;
- result conflict;
- unexplained UNKNOWN;
- regression failure;
- extra attempt after target;
- unrelated Pet Skill/QTE changes mixed into the phase.

---

# 17. FINAL REPORT FORMAT

Return:

```text
PHASE:
Phase 3A.0 — Freeze v1.0.1 Maintenance Baseline

RESULT:
PASS STRONG / PASS / PARTIAL / BLOCKED / FAIL

BASE COMMIT:
...

PHASE COMMIT:
...

PUSHED:
yes/no

VERSION:
v1.0.1

MAINTENANCE SCOPE:
- card click Y:
- postmatch wait:
- Sword direct reply:
- Sword indirect reply:
- unique adverse-Sword:
- Sword-hold:

OFFLINE:
- targeted tests:
- full regression:
- compileall:
- git diff --check:

LIVE RUN:
- FarmRunId:
- configured completed target:
- completed:
- wins:
- losses:
- unknown:
- attempts:
- technical aborts:
- recoveries:
- final lifecycle:
- extra attempt:

CARD CLICK:
- EVOLVE observed:
- CAST observed:
- clicks at Y 0.824:
- wrong card:
- misclick:
- duplicate:
- stale:

POSTMATCH:
- confirmations:
- observed ready→click latency:
- premature confirms:
- duplicate confirms:
- final lobby success:

SWORD SAFETY:
- direct reply violations:
- indirect reply violations:
- UNKNOWN favorable violations:
- live unique-adverse-Sword:
- live Sword-hold:
- deterministic exception tests:

SAFETY:
- wrong-turn:
- partial:
- duplicate input:
- stale input:
- boss-turn:
- sequence desync:
- terminal conflict:
- orphan controller:
- orphan poller:

DOCS:
- ...

FINAL PROCESS STATE:
- controller:
- poller:
- UI:
- game:

GIT:
- HEAD:
- origin/main:
- worktree:

NEXT ROADMAP PHASE:
Phase 3A.1 — Pet Skill / QTE Reverse Closure
NOT IMPLEMENTED
```

Preserve `NOT_OBSERVED` exactly.

---

# 18. EXPLICIT STOP

After Phase 3A.0 acceptance/docs/commit/push:

**STOP.**

Do NOT implement:

- Pet Skill config;
- QTE reverse;
- automated arrow keys;
- Space/Perfect;
- Pet Skill policy;
- `ManaPriority` removal;
- new packaged release.

Leave controller/UI stopped.

Return the final report and wait for the next prompt.
