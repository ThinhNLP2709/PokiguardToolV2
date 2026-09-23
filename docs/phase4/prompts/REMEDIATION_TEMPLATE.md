# Phase 4 Remediation Prompt Template

Use this only when a Phase 4 prompt is not `PASS STRONG`.

Replace every `<...>` from actual evidence. Do not create a generic cleanup
phase.

```text
# Phase <4X.Y-Rn> — <Narrow evidence-based title>

Implement Phase <4X.Y-Rn> ONLY.

PARENT PHASE:
<4X.Y>

PARENT RESULT:
<PASS / PARTIAL / BLOCKED / FAIL>

RETURN GATE:
After remediation, rerun exactly <parent stage/gate>. Do not advance directly
to a later roadmap phase.

READ FIRST:
- AGENTS.md
- docs/phase4/README.md
- docs/phase4/STATUS.md
- docs/phase4/ROUTER.md
- parent prompt/report/runbook/logs
- canonical docs/source files implicated by evidence

OBSERVED FACTS:
- <exact log/run/action/session>
- <expected behavior>
- <actual behavior>
- <authoritative ACK or absence>

ROOT CAUSE STATUS:
<PROVEN / INFERRED / UNKNOWN>

EXACT GOAL:
<one narrow correction or evidence closure>

OUT OF SCOPE:
- unrelated input domains
- gameplay policy redesign
- other roadmap phases
- package unless parent is 4E.1

SAFETY CONTRACT:
- preserve exact HWND/PID/session/turn/card/QTE ownership
- queue success is not acceptance
- no blind retry
- stop ACK blocks new input
- foreground default unchanged

TEST/REPLAY:
- reproduce failure before fix
- prove correction after fix
- regression around adjacent state boundaries
- focused/full/compileall/diff-check as appropriate

LIVE RETRY:
<smallest stage necessary; user controls game>

PASS STRONG:
- original failure reproduced and closed
- parent gate rerun clean
- zero new critical violation
- report/artifacts/STATUS updated

FINAL REPORT:
Use docs/phase4/HANDOFF_TEMPLATE.md.

EXPLICIT STOP:
Stop after parent return gate. Let ROUTER choose the next prompt.
```
