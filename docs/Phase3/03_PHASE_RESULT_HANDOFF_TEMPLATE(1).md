# PHASE RESULT HANDOFF TEMPLATE — PET SKILL / QTE ROADMAP

Use this when returning a completed phase to ChatGPT or when moving to a fresh conversation.

Delete fields that are genuinely not applicable, but never fabricate values.

```text
PROJECT:
PokiguardToolV2

ROADMAP:
Post-BASIC Pet Skill / QTE

LATEST COMPLETED PHASE:
<Phase 3A.0 / 3A.1 / ...>

RESULT:
<PASS STRONG / PASS / PARTIAL / BLOCKED / FAIL>

SOURCE / VERSION:
- app/source version:
- accepted previous release/tag:
- phase base commit:
- phase commit:
- pushed?:
- main == origin/main?:
- worktree:

PHASE SCOPE ACTUALLY IMPLEMENTED:
- ...
- ...

CANONICAL DOCS UPDATED:
- docs/CURRENT_STATE.md:
- docs/DECISIONS.md:
- docs/gameplay_rules.md:
- docs/basic_gameplay_policy.md:
- phase report:
- phase runbook:
- QTE reverse report updated?:

CONTROLLER / UI FINAL STATE:
- controller:
- poller:
- UI process:
- game process:
- game lifecycle:

CONFIG MODEL:
- Main Pet:
- Evolution:
- Damage Card:
- ManaPriority still present?:
- disabled/future options:
- default backward-compat result:

PET / SKILL CAPABILITY:
- runtime main pet identity:
- pet kind:
- skillCardId:
- skill type/family:
- manaCost:
- powerCost / Rage cost:
- cooldown:
- conditionUse:
- needPerfection:
- source = main pet / evolution pet:
- multiple skill cards?:
- targetable skill proven?:

QTE REVERSE / OBSERVATION:
- QTE challenge identity/source:
- sequence source:
- exact sequence captured?:
- exact direction mapping:
- currentIndex:
- correctCount:
- qtePresses:
- qteElapsedMs:
- confirm/Space mapping:
- timing clock/source:
- perfectStart:
- perfectEnd:
- server timingResult:
- exact skill effect:
- target-selection semantics:

QTE AUTOMATION:
- skill-card clicks:
- direction inputs:
- expected directions:
- accepted/correct directions:
- wrong directions:
- duplicate directions:
- stale directions:
- confirm inputs:
- duplicate confirm:
- PERFECT:
- GOOD:
- BAD:
- input after Emergency Stop ACK:
- old-session QTE input:

LIVE FARM ACCEPTANCE:
- FarmRunId:
- MatchIds:
- configured target:
- Main Pet:
- Evolution:
- Damage Card:
- completed matches:
- wins:
- losses:
- unknown:
- attempts:
- technical aborts:
- technical recoveries:
- Pet Skill uses:
- default Attack uses:
- EVOLVE uses:
- PASS count:
- exact stop reason:
- final lifecycle:
- extra attempt after target:

PERFORMANCE / EFFICIENCY:
- sample count:
- mean combat duration:
- median combat duration:
- mean farm-cycle duration:
- SWAPs/match:
- Pet Skills/match:
- PERFECT rate:
- energy source:
- energy used:
- ENERGY_SAVING:
  <measured value / NOT_MEASURED>

CRITICAL SAFETY COUNTERS:
- wrong-turn input:
- misclick:
- partial input:
- duplicate input:
- stale input:
- boss-turn input:
- postmatch-invalid input:
- sequence desync:
- provider read error:
- terminal result conflict:
- duplicate controller:
- wrong-run command:
- orphan controller:
- orphan poller:
- stale skill card:
- stale QTE:
- QTE input after lifecycle/session change:
- QTE input after Emergency Stop ACK:

TESTS:
- focused:
- full regression:
- compileall:
- git diff --check:
- benchmark/replay:

ARTIFACTS / EVIDENCE:
- ...
- ...

KEY NEW INVARIANTS:
- ...
- ...

KNOWN UNKNOWN / NOT_OBSERVED / NOT_MEASURED:
- ...
- ...

REMAINING BLOCKERS:
- ...

IMPORTANT:
Use the attached baseline as stable project context.
This latest phase evidence is newer and overrides older baseline phase status.
Review this phase first.
Then give me the COMPLETE next Codex/Claude prompt immediately.
If a blocker remains, give me the narrow remediation prompt instead of blindly advancing.
```
