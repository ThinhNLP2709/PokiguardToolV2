# 5D.1-P22 — Timing pipeline tail review OFFLINE

**SELECTED ONLY / NOT EXECUTED.** Một milestone file-only; chưa cần mở game.
Đọc AGENTS, STATUS, ROUTER, EXECUTION_CONTRACT, capability, parent
[P21 report](../reports/5d1_p21_report.md),
[P20 policy review](../research/5d1_p20_root_admission_policy_review.md),
[P21 readiness](../artifacts/5d1_root_policy_p21_v1/readiness.json) và raw qualification.

## Entry và câu hỏi

P21 đã triển khai root250/final100 riêng trong v4, giữ legacy/deadline/flow.
Current source297
`bab0145da486101b910fd8195acd189f6e3dc033b900e46b56bc0f858248bd40`.
Qualification `qualification_verified` đạt31/32 gates: pipeline measured index2789
có11.8417ms > trần max10ms; p50/p95/p99 lần lượt0.2725/0.4227/0.6878ms.
Raw sample giữ nguyên; validator/exporter reject, chưa có draft/allowance/live authority.
P18 source294 có pipeline max9.469ms, giữ như evidence riêng.

Cần review thất bại tail này từ data/source hiện có: đo chính xác phần nào,
phần nào có bằng chứng gây chi phí, và next step nhỏ nhất để xử lý có căn cứ.
Không coi outlier là OS noise hoặc code regression chỉ từ hình dạng phân phối.

## Phạm vi

FILE-ONLY / NO IMPLEMENTATION / NO NEW MEASUREMENT. Không attach/read game,
capture/input, UI/observer launch, source/tests/tool/flow changes hoặc build/
version/Git/preferences/claims/game-file writes. Không chạy lại qualification,
benchmark, tests/soak để tìm PASS; không bỏ outlier hoặc đổi warmup/index.
Chỉ docs/review artifacts. Stop ở P22.

1. Verify P21 final manifest/source/host và full regression result. Giữ initial
   focused-test harness failures/repairs, source-binding failure và hai fixture
   pre-measurement interruptions tách khỏi final measured qualification. Không
   gọi các run chưa có raw latency là failed performance measurements.

2. Recompute đủ61,000 raw values/51,000 measured values với indices/warmups,
   gates/quantiles/CPU/Stop/stress receipts. Giữ duy nhất measured pipeline
   sample vượt10ms ởindex2789, các mẫu lân cận và toàn raw distributions.
   Không dùng counterfactual27roots P20 hoặc legacy measurements làm current PASS.

3. Trace timed region của actual collector pipeline, allocations/setup ngoài
   interval, event encoding/critical-state/witness/monitor/sink trong interval.
   Đối chiếu exact P18→P21 changes và metadata root policy. Phân biệt wall-time
   sample với CPU/per-stage/GC/OS evidence hiện không có. Fixture ancestry cache
   nằm trước microbench; không gán nó là nguyên nhân sample index2789.

4. Chọn một hướng có căn cứ: targeted optimization offline nếu xác định được
   chi phí cần sửa; targeted fake-only measurement preparation nếu evidence
   chưa đủ; hoặc SLO contract proposal có rationale độc lập nếu threshold cần
   review. Không tăng max10ms chỉ để bao11.8417ms, không dùng percentile để bỏ
   max gate đã công bố, không reset budget hoặc hạ reserve/guard/margin.
   Nếu thiếu bằng chứng nguyên nhân thì ghi UNKNOWN, đặt câu hỏi đo cụ thể.

5. Native U/transport/alignment vẫn null. Root250/final100 vẫn opt-in có review,
   chưa live. Descriptive S24.4372/R6772.1419 từ failed qualification không
   phải allowance/reserve accepted. Source/cohort/Stop/pending/ACK/AI-only
   fallback và no-second-input giữ nguyên. Retain BASIC bình thường, không quota override.

## Đầu ra và STOP

Viết `reports/5d1_p22_report.md`, raw recomputation, pipeline boundary map,
UNKNOWN ledger và decision/proposal accepted=false nếu có. Preservation kiểm
source297/host/parent artifacts/6claims/ordinary prefs/game-file hashes/HEAD;
existing idle UI log chỉ prefix/append riêng, không native evidence mới.

Update STATUS/README/ROUTER/capability. Chọn exactly one next prompt từ review,
không tự thực thi. Qualification đang fail nên không trực tiếp mở pilot mới,
không resume P19 hoặc CAREFUL/Demon/Mega/D1cap12/D2. **STOP P22.**
