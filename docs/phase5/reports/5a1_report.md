# Phase 5A.1 — Baseline và REASONING contract report

Ngày: **2026-10-09 (Asia/Saigon)**.
PROJECT: PokiguardToolV2.
ROADMAP: Phase5 — Adaptive PlayStyle REASONING.
STEP / PARENT / MODE: 5A.1 / nghiên cứu5A.0 / DOCS.
RESULT: **PASS STRONG — phạm vi đặc tả/tài liệu**.
EFFICACY VERDICT: NOT_APPLICABLE / NOT_MEASURED.

## 1. Yêu cầu và entry

Người dùng yêu cầu “Tiến hạnh 5a1 đi”. Thực hiện đúng
[prompt5A.1](../prompts/5A1_BASELINE_AND_REASONING_CONTRACT.md):
đọc nghiên cứu/canonical/release, chốt boundary và cập nhật docs; không triển
khai5A.2, code hoặc live.

Đã đọc AGENTS, STATUS, ROUTER, EXECUTION_CONTRACT, hai nghiên cứu5A.0,
v1.2.4 release, DECISIONS, BASIC/gameplay rules và HANDOFF.
Đọc thêm đúng phần owner/flow của CURRENT_STATE, reports4B.2/4C.1, MI.2 và
Mega survival hotfix để làm manifest; không code audit hoặc đọc reverse mới.

## 2. Source và unrelated work

- Source baseline: v1.2.4 theo release và HEAD.
- HEAD: `c646acfa5e895732bbdade553f9d7bd61171cd29`.
- Baseline HEAD tree: `b74139ea0f22ca4d6e08b06bbeb977bba68a1971`.
- Branch: `codex/phase3a2-board-repair`; không đổi.
- Entry tracked index/worktree: clean.
- Fingerprint runtime: HEAD trên + không runtime/source/test/tool/config changes.
  Đây là metadata/diff-scope evidence, không checksum game process hoặc code audit.
- Untracked trước bước, được bảo toàn:
  - `docs/Phase3/`;
  - `docs/PokiguardToolV2_ChatGPT_Baseline_Combined.md`;
  - `docs/PokiguardToolV2_ChatGPT_Handoff_Pack/`;
  - `docs/phase5/` chứa bộ nghiên cứu/prompt đã chuẩn bị.
- Không commit/push/tag/version bump/build/release; không reset/checkout hoặc
  chỉnh artifact accepted/reference/game files.

Release có xác nhận operator600 +200 ván không dừng, không có run artifacts
tương ứng trong repo; không suy win-rate/coverage. Bú win baseline live vẫn pending.

## 3. Hoàn thành

- Tạo [5A.1 contract](../specs/5a1_baseline_reasoning_contract.md).
- Tạo canonical pointer [REASONING policy](../../reasoning_gameplay_policy.md).
- Cập nhật định nghĩa REASONING trong DECISIONS, gameplay_rules,
  basic_gameplay_policy và CURRENT_STATE; giữ BASIC rules/thresholds/order.
- Cập nhật README, ROADMAP, EXECUTION_CONTRACT, STATUS và ROUTER theo tiến độ thật.
- PROMPT_INDEX chuyển sang pointer 5A.1 closed; hai nghiên cứu giữ nội dung
  lịch sử và thêm note rằng progress mới theo STATUS.
- Không tạo feature schema/weights final, planner/worker/AI tab hoặc fixture/
  expected ranking để giả lập việc5A.2/B/D đã hoàn thành.

## 4. Những điều contract chốt

| Nội dung | Kết luận | Evidence |
|---|---|---|
| Hard/objective/soft | Actual legality/ownership/cost/PASS/transition hard; profile/loadout intent giữ; tactical settings advisory | Contract§3–4 |
| Flow owner | Provider/dispatcher, capture, controller/FarmRunner, preflight/lease, executor/ACK giữ ownership | Contract§5 |
| Seam REASONING | Chỉ proposal từ immutable state đã có; không extra memory/capture/poll/input path | Contract§2,5–6 |
| Baseline | Quyết định BASIC của đúng PlayStyle sẵn có trước proposal | Contract§1–2,6 |
| Fallback | Planner error trước dispatch dùng baseline còn hợp lệ; state invalid fail closed | Contract§7 |
| After-input | Pending/ACK/recovery cũ, không replacement input hoặc AI retry | Contract§7 |
| Error isolation | Không AI-induced PASS/idle reset/technical recovery; bounded cancel/breaker | Contract§7–8 |
| Log | Bounded/nonblocking; separate sink chỉ nếu prove không chậm hơn shared, nếu thiếu evidence dùng shared filtered events | Contract§8 |
| Adaptive Mega | M1incident, M2trước HP threshold, M3healthy, M4cost invalid, M5UNKNOWN | Contract§9 |
| Bú win | Team objective, local death không kéo solo survival; baseline Coop live gate riêng | Contract§4,9–10 |
| Runtime status | Product/spec defined, v1.2.4 REASONING chưa implement; placeholder/fallback chưa được đổi | Contract§1, canonical updates |

Flow/order preservation ở đây là **normative contract và zero runtime diff**,
không phải phép đo parity sau integration. Read/capture counts, pacing/latency,
action/QTE/ACK/lease/lifecycle và Stop không được test/live lại trong5A.1.

## 5. Mega Icarus và giới hạn bằng chứng

Incident lịch sử HP9,46%, seal5 <6 cho thấy setup cứng có thể chọn Mana để lại
reply nguy hiểm, dù có Sword move ít known threat hơn. BASIC survival hotfix
giữ nguyên làm incumbent. REASONING được so Sword/protection/early skill theo
tình thế và scope, không bị target6 hoặc HP<=30% là khóa duy nhất.

Cùng setting khi khỏe, useful setup/threat thấp vẫn có thể là phương án phù
hợp. Không đổi objective Mega chỉ để tạo “override”. Cost/source/actionability
thiếu vẫn cấm skill. M2/M3 là design cases, chưa là live evidence hoặc tested
fixture; ranking chi tiết giao5A.2/B2/D4.

Không có damage/refill/boss model đầy đủ; proxy/conditional prediction phải có
nhãn, không gọi là prove safe/lethal/no-loss hoặc global optimum.

## 6. Diagnostics / measurements / live

- Separate/shared sink implementation: NOT_SELECTED, NOT_IMPLEMENTED.
- Queue/retention/breaker limits, deadline reserve/SLO: giao5A.3/B4.
- CPU/memory/p50/p95/p99/max/Stop overhead: NOT_MEASURED.
- Worker/cancel/fallback fault injection: NOT_EXECUTED.
- Runtime behavior/flow parity under new code: NOT_IMPLEMENTED / NOT_MEASURED.
- Gameplay tests/full suite/compile/build/package: NOT_RUN — docs-only.
- Live attempts/input/attach/process inspection: NONE trong bước này.
- Controller/game trạng thái hiện tại: NOT_INSPECTED; không dùng trạng thái
  “stopped” của historical report như observation mới.
- v1.2.4 artifact hash chỉ là historical release reference; không rebuild/re-hash
  package hoặc claim packaged REASONING accepted.

## 7. Gate review

| Gate5A.1 | Result | Evidence |
|---|---|---|
| Entry: research/canonical/user scope đã đọc | PASS | Mục1 và report source references |
| Baseline/version/HEAD/unrelated work rõ | PASS | Mục2; metadata trước/sau |
| Hard/objective/soft và không threshold lock | PASS | Contract§3–4 |
| Owner manifest + cấm extra read/capture/poll/executor path | PASS | Contract§5–6 |
| Fallback pre-dispatch / invalid-state / after-input tách biệt | PASS | Contract§7 |
| Mega urgent và healthy, actual-cost negative case | PASS | Contract§9 |
| UNKNOWN có disposition, không guarantee sai | PASS | Contract§10 |
| Canonical intent defined / runtime pending phân biệt rõ | PASS | DECISIONS/BASIC/gameplay/CURRENT_STATE/canonical pointer |
| Docs-only, không source/runtime/test/config diff | PASS | Changed-file scope và final status |
| Local docs links/STOP/router consistency | PASS | 22 local references ở3 docs mới và42 closure references không broken; A1closed, nextA2, A2NOT_STARTED |

Các gate runtime/model/performance/live không thuộc exit5A.1 và **chưa PASS**.

Docs QA: `git diff --check -- docs` exit0, không whitespace error; Git chỉ báo
chuyển LF/CRLF trên Windows. Ba docs mới có code fences cân bằng. Đây là kiểm
tra tài liệu, không chạy gameplay/full test suite. Final diff scope chỉ docs;
không files mới hoặc modified ngoài docs.
Final metadata xác nhận HEAD không đổi, staged changes rỗng, tracked changes
chỉ bốn canonical Markdown files; mọi untracked changes vẫn dưới docs.

Changed-file manifest của bước này (15 docs):
- Mới: `docs/phase5/specs/5a1_baseline_reasoning_contract.md`,
  `docs/phase5/reports/5a1_report.md`, `docs/reasoning_gameplay_policy.md`.
- Canonical: `docs/DECISIONS.md`, `docs/basic_gameplay_policy.md`,
  `docs/gameplay_rules.md`, `docs/CURRENT_STATE.md`.
- Điều phối: `docs/phase5/README.md`, `ROADMAP.md`, `EXECUTION_CONTRACT.md`,
  `STATUS.md`, `ROUTER.md`, `PROMPT_INDEX.md` (cùng thư mục phase5).
- Note historical progress: `docs/phase5/phase5a0_reasoning_research.md`,
  `docs/phase5/phase5a0_research_completion_plan.md`.

## 8. UNKNOWN / bước nhận tiếp

A2: feature schema, evidence/missingness, utility/context adaptation, comparator
và scenario matrix cho sáu profile.
A3: timer/action-family reserve/SLO, log measurement protocol và bounded
evaluation. Wording timer floor ở tài liệu cũ inclusive vs strictly above được
ghi rõ; không nới hoặc chọn lại runtime gate ở A1.
B3: scoped models; B4: runner/log fault isolation; C3/C4: flow/fallback parity;
D: profile acceptance; E1: efficacy; F1: packaged proof.

## 9. Router và STOP

- Current phase: **5A.1 PASS STRONG (DOCS)**.
- Next prompt: [5A.2 adaptive PlayStyle/features](../prompts/5A2_ADAPTIVE_PLAYSTYLE_AND_FEATURE_SPEC.md).
- STATUS/ROUTER updated; không remediation cần thiết cho scopeA1.
- **STOP ở5A.1. Không tự chạy5A.2 hoặc code.**
