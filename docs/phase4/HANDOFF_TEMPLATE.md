# Phase 4 Result Handoff Template

Xóa field thật sự không áp dụng; không bịa số liệu. Giữ nguyên các giá trị
`UNKNOWN`, `NOT_OBSERVED`, `NOT_MEASURED`, `UNSUPPORTED` khi đúng sự thật.

```text
PROJECT:
PokiguardToolV2

ROADMAP:
Phase 4 — Background Input Beta

LATEST PHASE:
<Phase 4A.0 / ...>

RESULT:
<PASS STRONG / PASS / PARTIAL / BLOCKED / FAIL>

SOURCE:
- app/source version:
- base commit:
- phase commit:
- branch:
- pushed:
- upstream equality:
- worktree (including unrelated preserved files):

SCOPE ACTUALLY COMPLETED:
- ...

INPUT MODE / CAPABILITY:
- foreground baseline:
- background single click:
- background two-click:
- background drag:
- background card click:
- background arrows:
- background Space:
- covered-window combat:
- navigation/re-entry mode:
- minimized mode:
- selected branch = FULL / HYBRID / BLOCKED:

TRANSPORT EVIDENCE:
- exact HWND/PID:
- game build fingerprint:
- transport API/message sequence:
- client coordinates:
- message queue result:
- authoritative pre-state:
- authoritative post-state/ACK:
- ACK latency:
- foreground before/during/after:
- cursor moved:
- duplicate/unconfirmed input:

QTE EVIDENCE:
- MatchId/session:
- skillCardId/CardUI identity:
- QTE generation:
- expected directions:
- direction inputs:
- per-direction currentIndex/correctCount ACK:
- Space inputs:
- timingResult:
- PERFECT/GOOD/BAD:
- focus takeover:
- stale/duplicate input:

FARMRUN / LIVE:
- FarmRunId:
- configuration:
- target/completed/attempts:
- W/L/U:
- SWAP/CARD/QTE/PASS counts:
- technical abort/recovery:
- foreground handoffs:
- unexpected foreground takeover:
- final lifecycle/controller/UI:
- extra attempt:

VISUAL DEPENDENCY:
- screen-DC captures used:
- game covered during capture:
- capture valid/invalid:
- native/memory alternative:
- stale visual proof:

CRITICAL SAFETY:
- wrong HWND/PID:
- wrong-turn input:
- partial input:
- duplicate input:
- stale input:
- input after stop ACK:
- unconfirmed input retried:
- board/QTE ACK conflict:
- terminal conflict:
- orphan controller/poller:

TESTS:
- focused:
- full regression:
- compileall:
- git diff --check:
- deterministic/replay:

DOCS / ARTIFACTS:
- report:
- runbook:
- logs:
- STATUS.md updated:
- capability matrix updated:

KNOWN UNKNOWN / NOT_OBSERVED / UNSUPPORTED:
- ...

BLOCKERS:
- ...

ROUTER DECISION:
- current phase result:
- next prompt:
- reason:
- return gate for remediation, if any:
```
