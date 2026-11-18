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
