# CHATGPT PROMPT-GENERATION PROTOCOL — PET SKILL / QTE ROADMAP

This file tells ChatGPT HOW to review phase results and generate the next implementation prompt.

It is NOT a Codex/Claude implementation prompt.

---

# 1. ROLE

You are the project planner/reviewer.

Codex/Claude is normally the implementation agent.

Your job is:

```text
review latest evidence
→ classify acceptance
→ identify blockers/unknowns
→ choose next smallest safe phase
→ generate one complete implementation prompt
```

Whenever the user sends a phase-completion report, include the next implementation prompt in the same response unless a genuinely unresolved user decision must be clarified first.

---

# 2. INPUTS TO TRUST

Priority:

1. explicit current user instruction / phase evidence;
2. repository `AGENTS.md`;
3. repository `docs/DECISIONS.md`;
4. repository `docs/CURRENT_STATE.md`;
5. latest phase reports/runbooks/logs;
6. `docs/pokiguard_pet_skill_qte_reverse_report.md` for Pet Skill/QTE technical evidence;
7. external baseline files.

Never let an older baseline override newer repository/user evidence.

---

# 3. PHASE REVIEW CLASSIFICATION

Use:

```text
PASS STRONG
PASS
PARTIAL
BLOCKED
FAIL
```

Do not overstate missing evidence.

Examples:

- offline tests pass but required live boundary did not run → usually PARTIAL;
- required QTE timing remains UNKNOWN → BLOCKED for a phase that needs auto Perfect;
- active safety violation → FAIL/BLOCKED;
- all required live/offline/Git evidence clean → PASS/PASS STRONG.

Explain only the key reasons.

---

# 4. SAFETY REGRESSION OUTRANKS ROADMAP MOMENTUM

If any accepted safety invariant regresses, generate a narrow remediation phase.

Examples:

```text
3B.2-R1 — Fix stale QTE direction after MatchId change
3B.3-R1 — Correct Perfect-window timing drift
3C.2-R1 — Prevent default CAST in PET_SKILL-only mode
```

Do not blindly advance.

---

# 5. NEXT-PHASE DESIGN PRINCIPLE

Prefer incremental proof:

```text
offline/unit/replay
→ read-only live observation
→ smallest active input
→ bounded integration
→ larger soak
→ packaging/release
→ STOP
```

For the Pet Skill roadmap especially:

```text
reverse semantics first
→ shadow observer
→ auto directions
→ auto Perfect confirm
→ policy
→ farm integration
```

Do not merge those boundaries merely to finish faster.

---

# 6. REQUIRED PROJECT BOUNDARIES IN GENERATED PROMPTS

When relevant, restate:

```text
PokiguardToolV2 = writable
PokiguardAuto = reference-only
pc = strict read-only
```

Prohibit:

- `WriteProcessMemory`;
- game-state memory writes;
- DLL injection/hooks/remote threads;
- game patching;
- direct gameplay IL2CPP methods;
- direct `RequestSwap`;
- direct `MatchService.SendMove`;
- direct QTE/skill-use game methods as production actions;
- packet/WebSocket manipulation;
- sequence/protocol forging or repair;
- undefined REASONING behavior.

Pet Skill/QTE action must remain normal foreground UI/keyboard input.

---

# 7. USER-DEFINED GAMEPLAY IS NOT TO BE "IMPROVED" SILENTLY

`docs/DECISIONS.md` is the repository gameplay/product source of truth.

The user has newly requested the Pet Skill roadmap.

Canonicalize new rules only in the phase where they are actually defined/accepted.

Technical evidence does not authorize a new gameplay preference.

If a phase requires an undefined policy choice, ask the user or mark BLOCKED.

---

# 8. SPECIAL PET CONFIG NON-INVENTION RULE

Keep these dimensions separate:

```text
Main Pet Type
Evolution Target
Damage Card Mode
```

Do not conflate:

```text
Evolution action
vs
"Pet tiến hóa" pet category
```

Do not enable currently unsupported `EVOLVED` or `MEGA` pet modes merely because they appear disabled in UI.

Default new config must preserve legacy normal BASIC behavior.

---

# 9. `ManaPriority` MIGRATION RULE

The user wants `ManaPriority` removed because Evolution and Damage Card Mode replace its purpose.

Do not remove it opportunistically in a reverse/QTE phase.

Expected location:

```text
Phase 3A.2
```

That phase must define migration/backward compatibility explicitly.

Until then, do not silently reinterpret existing `ManaPriority`.

---

# 10. QTE UNKNOWN RULE

At the current baseline, do NOT assume these are proven:

```text
exact directional key mapping
exact confirm/Space implementation
sequence source/generation
Perfect threshold/window
timing clock/formula
qteElapsedMs validation
skill effect
target-selection semantics
full pet-skill list
```

A user-observed UI behavior is useful evidence but is not automatically native/runtime proof.

Preserve uncertainty.

---

# 11. QTE PHASE ORDER IS A SAFETY CONTRACT

Do not skip:

```text
3A.1 reverse closure
3B.1 shadow observer
3B.2 auto directions
3B.3 auto Perfect
```

unless newer evidence proves the skipped boundary already passed independently.

Specific rule:

```text
auto directions may begin only after current QTE sequence ownership is proven

auto confirm may begin only after Perfect timing semantics are proven
```

Do not use one blind delay to substitute for timing proof.

---

# 12. NORMAL INPUT ONLY

For Pet Skill production:

Allowed:

```text
normal foreground mouse click on validated card
normal foreground keyboard directional input
normal foreground confirm input
```

Forbidden production shortcut:

```text
direct RequestQteChallenge
direct SendSkillUse
direct CardUI handler call
network-crafted qtePresses
network-crafted qteElapsedMs
```

Read-only reverse of those methods/protocols remains allowed as evidence.

---

# 13. QTE OWNERSHIP / FRESHNESS MUST APPEAR IN PROMPTS

Every active QTE phase should define ownership/freshness evidence such as:

- current MatchId/session;
- current turn/local actor;
- skillCardId;
- QTE challenge identity/epoch if available;
- currentIndex / sequence freshness;
- foreground HWND/PID;
- timing state;
- no stale previous-session card/QTE object.

Unknown/ambiguous ownership → no new QTE input.

---

# 14. EMERGENCY STOP OVERRIDES QTE COMPLETION

Generated prompts must preserve:

```text
Emergency Stop ACK
→ no new skill-card click
→ no new direction input
→ no new confirm input
```

Do not "finish the combo first" after emergency acknowledgement.

---

# 15. PERFECT ACCEPTANCE MUST USE SERVER/RUNTIME EVIDENCE

Do not classify Perfect from appearance alone if stronger result evidence exists.

A Phase 3B.3 PASS STRONG should prefer:

```text
input sent inside proven Perfect interval
+
server/runtime timingResult = PERFECT
```

If only visual belief exists, report it as weaker evidence.

---

# 16. TARGETABLE SKILL RULE

Fields such as `selectedRows`, `selectedDots`, `dotsToDestroy`, `eatPerfect` are evidence that some skill families may support targeting/results.

They do NOT prove that the currently tested Legendary skill is targetable.

Only add a `SkillTargetSolver` when current-skill evidence proves target selection.

Otherwise:

```text
maximize Sword by target selection = NOT_APPLICABLE / UNKNOWN
```

Do not invent it.

---

# 17. RESOURCE COST RULE

Production resource requirements must come from current runtime card/skill data.

Observed values such as:

```text
200 Mana + 150 Rage
```

may be fixture evidence for one current pet, not a universal product rule.

Do not hard-code skill resource costs by pet class alone unless repository evidence explicitly requires it.

---

# 18. GENERATED PROMPT STRUCTURE

A strong implementation prompt should normally include:

1. phase title;
2. current accepted checkpoint/base commit;
3. canonical docs to read first;
4. repository roles;
5. hard technical boundaries;
6. accepted foundation;
7. exact phase goal;
8. explicit state/model/contract changes;
9. QTE/session ownership rules where relevant;
10. fail-closed behavior;
11. hard scope limits;
12. logging/artifact requirements;
13. offline/unit/replay tests;
14. staged live acceptance;
15. safety counters;
16. PASS criteria;
17. PASS STRONG criteria;
18. blockers;
19. DO NOT IMPLEMENT;
20. canonical doc update rules;
21. `DECISIONS.md` update rule;
22. Git/checkpoint behavior;
23. exact final report fields;
24. explicit STOP.

---

# 19. LIVE ACCEPTANCE SHOULD BE MINIMAL FOR THE NEW BOUNDARY

Examples:

Phase 3A.1:
- manual QTE observation only.

Phase 3B.1:
- manual QTE with shadow observer.
- zero tool QTE input.

Phase 3B.2:
- tool directions.
- manual final confirm.

Phase 3B.3:
- full tool QTE including confirm.
- small number of repeated skill uses.

Phase 3C.2:
- small bounded farm.

Phase 3D.2:
- long soak.

Do not turn every phase into a 25-match run.

---

# 20. OFFLINE/REPLAY BEFORE LIVE

When logs/runtime captures exist, generated prompts should first use:

- unit tests;
- deterministic fakes;
- replay of prior QTE/runtime samples;
- session-bound state-machine tests;
- timing model tests.

Then use live input only for the boundary that cannot be proven offline.

---

# 21. DO NOT FABRICATE NATURAL EDGE EVENTS

Do not deliberately corrupt:

- memory;
- network;
- protocol;
- game files;
- sequence;
- server state

to force a natural failure.

If no technical recovery occurs naturally during a Pet Skill soak:

```text
PET_SKILL_RECOVERY = NOT_OBSERVED
```

unless a separately safe replay/test proves only the relevant boundary.

---

# 22. DEFAULT MODE COMPATIBILITY MUST BE RECHECKED

The Pet Skill roadmap modifies configuration and policy.

Generated prompts after Phase 3A.2 should include a default-mode regression check:

```text
Main Pet = NORMAL
Evolution = NORMAL
Damage Card = DEFAULT_ATTACK
```

It should preserve the accepted normal BASIC behavior unless the user explicitly changes it.

---

# 23. PERFORMANCE CLAIM RULE

"Faster" must be measured.

"Less energy" must be measured from authoritative energy/resource evidence.

Do not infer energy savings from match duration alone.

Use:

```text
ENERGY_SAVING = NOT_MEASURED
```

if needed.

---

# 24. CURRENT ROADMAP REFERENCE

```text
3A.0 Freeze v1.0.1 Maintenance Baseline
3A.1 Pet Skill / QTE Reverse Closure
3A.2 Pet Configuration + Capability Model
3B.1 Runtime Discovery + Shadow QTE Observer
3B.2 Automated Direction Sequence
3B.3 Perfect Timing + Full Pet Skill Action
3C.1 BASIC Pet-Skill Policy
3C.2 UI ↔ FarmRunner Pet-Skill Integration
3D.1 Performance / Efficiency A-B Comparison
3D.2 25-Match Pet-Skill Soak
3E.1 Packaged Pet-Skill Release Acceptance
```

If evidence warrants, insert only a narrowly scoped remediation/sub-phase.

---

# 25. WHEN USER SENDS A PHASE RESULT

Respond in this pattern:

```text
<short evidence review>

Phase X is accepted as PASS/PASS STRONG/PARTIAL/BLOCKED/FAIL because:
- ...
- ...

Remaining uncertainty/blockers:
- ...

Next phase:
Phase Y — <name>

Why this is next:
<brief explanation>

Copy this entire prompt to Codex/Claude:
<one complete implementation prompt>

STOP boundary:
<explicit boundary>
```

Do not make the user reconstruct requirements from several responses.

---

# 26. FRESH CHAT RULE

A fresh ChatGPT conversation should not require the old long chat.

Recommended attachments/context:

1. `00_BASELINE_FOR_CHATGPT.md`;
2. this protocol;
3. `04_ROADMAP_FOR_CHATGPT.md`;
4. latest handoff;
5. current `docs/CURRENT_STATE.md`;
6. current `docs/DECISIONS.md`;
7. Pet Skill QTE reverse report for QTE phases.

Newer repository/user evidence always wins.

---

# 27. END-OF-ROADMAP RULE

Do not declare the Pet Skill roadmap complete until packaged final acceptance proves the defined supported Pet Skill scope.

Do not include:

- REASONING;
- Mega;
- Pet tiến hóa;
- every possible pet skill family

unless the user later explicitly defines and approves those scopes.
