# PokiguardToolV2 — Pet Skill / QTE ChatGPT Handoff Pack

This pack is for **ChatGPT planning/review**, not a direct Codex/Claude implementation task.

It replaces the old pre-release roadmap context for the new post-BASIC Pet Skill/QTE work.

---

## Contents

1. `00_BASELINE_FOR_CHATGPT.md`  
   Stable project + Pet Skill/QTE baseline.

2. `01_CHATGPT_PROMPT_GENERATION_PROTOCOL.md`  
   Rules ChatGPT should follow when reviewing evidence and generating the next implementation prompt.

3. `02_FRESH_CHAT_STARTER.md`  
   Copy-paste starter for a brand-new ChatGPT conversation.

4. `03_PHASE_RESULT_HANDOFF_TEMPLATE.md`  
   Standard result format after each phase, including QTE-specific evidence.

5. `04_ROADMAP_FOR_CHATGPT.md`  
   High-level Phase 3 roadmap.

---

## Current checkpoint

Released finite BASIC:

```text
Phase 2F.2 — PASS STRONG
BASIC COMPLETE
v1.0.0+15
```

Current local maintenance:

```text
source v1.0.1
745/745 offline regression reported
live validation pending
commit/push pending
```

Current next phase:

```text
Phase 3A.0 — Freeze v1.0.1 Maintenance Baseline
```

Do not start Pet Skill/QTE active automation before 3A.0 is accepted and 3A.1 closes the necessary QTE unknowns.

---

## How to use this pack in the current conversation

You do not need to do anything special with ChatGPT.

When a phase finishes:

1. send ChatGPT the final report;
2. ChatGPT reviews it;
3. ChatGPT should automatically generate the next complete Codex/Claude prompt.

---

## How to use in a fresh ChatGPT conversation

Recommended attachments:

```text
00_BASELINE_FOR_CHATGPT.md
01_CHATGPT_PROMPT_GENERATION_PROTOCOL.md
02_FRESH_CHAT_STARTER.md
03_PHASE_RESULT_HANDOFF_TEMPLATE.md
04_ROADMAP_FOR_CHATGPT.md
```

Also attach current repository truth whenever possible:

```text
docs/CURRENT_STATE.md
docs/DECISIONS.md
```

For Pet Skill/QTE work also attach:

```text
docs/pokiguard_pet_skill_qte_reverse_report.md
```

Then paste the content from `02_FRESH_CHAT_STARTER.md`.

---

## Source-of-truth rule

Newer repository/user evidence wins over this pack.

Priority:

```text
current user instruction
→ AGENTS.md
→ DECISIONS.md
→ CURRENT_STATE.md
→ latest phase report/log
→ external handoff pack
```

Do not use an old baseline to roll back a newer accepted state.

---

## Critical Pet Skill rules

- Pet Skill/QTE remains an extension of BASIC.
- REASONING is still undefined.
- Main Pet, Evolution Target and Damage Card are separate concepts.
- `ManaPriority` removal belongs to the configuration migration phase, not an earlier reverse phase.
- Runtime skill cost is authoritative; do not universal-hard-code one pet's cost.
- Card order is not authoritative.
- QTE ownership must be current-session/current-card.
- Shadow observation comes before automated directions.
- Automated directions come before automated Perfect confirm.
- No blind fixed-delay Perfect implementation.
- Emergency Stop overrides completing a QTE.
- No direct game-method or network shortcut.
- "Maximize Sword" through skill targeting is allowed only if the current skill is proven targetable.

---

## Roadmap summary

```text
3A.0  Freeze v1.0.1 maintenance
3A.1  QTE reverse closure
3A.2  Pet config/capability model
3B.1  Shadow QTE observer
3B.2  Auto directions
3B.3  Auto Perfect/full skill
3C.1  BASIC Pet-Skill policy
3C.2  UI/Farm integration
3D.1  A-B performance comparison
3D.2  25-match soak
3E.1  Packaged feature release
```

If a phase fails, insert a narrow remediation phase.

---

## What to do right now

Run **Phase 3A.0 only**.

Do not let the implementation agent begin Pet Skill/QTE changes yet.

Phase 3A.0 should:

1. inspect the current `v1.0.1` diff;
2. live-test the existing maintenance changes in a bounded BASIC run;
3. run final regression/compile/diff validation;
4. update canonical docs accurately;
5. commit and push the `v1.0.1` maintenance checkpoint;
6. stop.

After it finishes, send the Phase 3A.0 report back to ChatGPT.

ChatGPT should then review it and generate the Phase 3A.1 reverse-only prompt.
