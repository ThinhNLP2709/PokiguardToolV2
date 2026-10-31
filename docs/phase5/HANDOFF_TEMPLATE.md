# Phase 5 — Handoff / report template

Lưu report thực thi tại `docs/phase5/reports/<step>_report.md` (tên mỗi prompt
đã chỉ định). Không tạo report PASS chỉ vì đã tạo prompt. Xóa field không áp
dụng; giữ UNKNOWN/NOT_OBSERVED/NOT_MEASURED nếu chưa có dữ liệu.

```text
PROJECT: PokiguardToolV2
ROADMAP: Phase 5 — Adaptive PlayStyle REASONING
STEP / PARENT / MODE:
RESULT: PASS STRONG / PASS_OFFLINE_LIVE_PENDING / PARTIAL / BLOCKED / FAIL / CLOSED_BASELINE_ONLY
EFFICACY VERDICT (E1): PROMOTE / INCONCLUSIVE / NO_PROMOTION / NOT_APPLICABLE
SOURCE VERSION / HEAD / BRANCH:
WORKTREE/SOURCE FINGERPRINT / CHANGED-FILE MANIFEST:
UNRELATED WORK PRESERVED:
USER-ACTIVATED SCOPE / LIVE BATCH (if any):
PREVIOUS REPORT / ENTRY GATES:

COMPLETED:
- Concrete deliverables and changed files.
- Out of scope / pending.

BASELINE & FLOW:
- BASIC behavior/action parity:
- Memory read order/count and provider ownership:
- Capture order/count:
- Action executor / QTE / ACK / pending ownership / lease:
- Lifecycle / navigation / Start/Stop / resume / recovery:
- Evidence location, NOT_OBSERVED where absent:

REASONING CAPABILITY:
- Profiles/loadouts/game build tested:
- R1/R2/model scope / unsupported inputs:
- Immutable snapshot/config/schema/version:
- Objective vs advisory settings:
- Tactical override example + evidence + counterexample:
- UNKNOWN/proxy/scenario vs observed separation:
- Proposal validation and baseline incumbent:
- Deadline / job cancellation / stale result:
- Fallback reason / circuit breaker:
- After-dispatch ownership: no replacement input:

DIAGNOSTICS:
- Separate sink vs shared namespace/filter + why:
- Queue/retention/sampling/error rate limits:
- Dropped/written/aggregated event counts:
- Source/job/action/run correlation:
- Log failure and disk/queue exhaustion behavior:
- CPU/memory/latency overhead relative to BASIC:
- p50/p95/p99/max + sample count (NOT_MEASURED if absent):

OFFLINE EVIDENCE:
- Dataset provenance / independent split / fixture limitations:
- Focused tests + relevant regression scope:
- Determinism / baseline comparison / uncertainty sensitivity:
- Fault injection results:

LIVE EVIDENCE (when activated):
- Exact source/config/model/artifact hash:
- Mode/profile/loadout/boss/cohort/order:
- Configured cap / attempts / completed / W-L-UNKNOWN:
- Energy spent / successful wins / energy per win (undefined if zero wins):
- Throughput / turns / skill-QTE quality / overrides:
- Abort/recovery/fallback/unsupported counts:
- Critical counters: wrong-turn, duplicate, stale, input after stop, orphan:
- Stop reason / user abort / NOT_OBSERVED cases:
- Evidence log paths:
- Statistical limitations / selection and session effects:

PACKAGED (F1):
- Artifact path / hash / dependencies / source mapping:
- Clean launch / BASIC + accepted reasoning scope:
- Log path writable + rotation / rollback artifact:
- Offline-only vs live proof:

GATES:
- Each required gate: PASS / FAIL / PENDING + evidence.
- Unsupported/disabled profiles or features.
- No superiority claim beyond evidence.
- PROMOTE is scoped opt-in acceptance; default remains BASIC.
- No unrequested commit/push/tag/version/release.

ROUTER:
- Current result:
- Exactly one next prompt:
- Remediation/targeted evidence parent and return gate:
- STATUS and ROUTER updated:
- STOP at this milestone:
```

Docs-only 5A/F2 ghi “runtime unchanged; no live/test execution” và chỉ điền
evidence spec/research cần thiết. Không chạy game/test harness để làm đầy form.
