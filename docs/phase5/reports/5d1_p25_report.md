# 5D.1-P25 — Pipeline SLO và qualification disposition, offline

2026-10-15 (Asia/Saigon). **FILE-ONLY REVIEW COMPLETE / KEEP MAX10MS /
P21 QUALIFICATION STILL FAILED / PARTIAL D1.**
[Prompt](../prompts/5D1_P25_PIPELINE_SLO_DISPOSITION_REVIEW_OFFLINE.md),
[parent P24](5d1_p24_report.md),
[decision](../artifacts/5d1_pipeline_slo_review_p25_v1/decision.json).

## Quyết định

**Giữ nguyên gate absolute full collector max10ms.** Nó là gate telemetry
được triển khai từ P3 và được yêu cầu rõ ở P12/P13/P18; khác scope với SLO
shadow không chứng minh nó bị áp sai. Chưa có rationale độc lập để nới SLO.
P21 vẫn31/32FAIL, nguyên sample2789=11.8417ms giữ. Không bỏ outlier, thay max
bằng percentile, lấy diagnostic mới làm PASS hoặc chạy lại qualification.

Chọn đúng một remediation tiếp theo: **artifact-only proof cho việc chuyển
PolicyConfig hiện tại sang JSON mà không dùng generic dataclass deepcopy**.
Chưa sửa runtime. Đây là giả thuyết giảm công việc serialize đã thấy trong
source, không phải kết luận nguyên nhân tail hoặc lời hứa sửa được11.84ms.
Proof không đủ parity/benefit thì không tích hợp.

## Gate10ms bắt nguồn từ đâu

[Provenance ledger](../artifacts/5d1_pipeline_slo_review_p25_v1/contract_provenance_ledger.json)
pin SHA/line/excerpts của từng nguồn; phân biệt proposed, implemented,
historical scoped acceptance và current enforcement.

| Mốc | Nội dung đã xác minh | Ý nghĩa |
|---|---|---|
| 5A.3 | Shadow paired added critical path p50/p95/p99/max≤0.5/1/3/10ms; enqueue riêng≤2ms | Family SLO gốc, không đồng nhất với collector-active telemetry |
| P3 | Qualifier đo absolute full start/preflight/finish +encode/enqueue, sink setup ngoài timer; cùng0.5/1/3/10ms | Gate absolute xuất hiện trước nhánh operational |
| P9/P10 | User acceptance pin exact P9 contract cho offline/readiness; affected latency/CPU/Stop gates; P10 qualifier giữ full pipeline max10ms | P9 acceptance không trực tiếp chốt riêng con số10; implementation/readiness đã có gate này |
| P12/P13 | Yêu cầu nguyên full pipeline≤10ms và giữ failure, không lặp/nới nếu chưa có correction có căn cứ | Requirement rõ của bước thực thi sau đó |
| P17/P18 | Đòi actual operational collector+authority+monitor, tối ưu metadata phải giữ bytes/meaning/flow, không nới gate | BASIC-only collector cũ không đủ cho path mới |
| Current v3/v4 verifier | Recompute raw, kiểm riêng pipeline quantiles/max; v4 delegate unchanged sau root policy check | Current failure là enforce đúng gate đang có |

Không xác minh được numerical derivation ban đầu khiến10ms là lựa chọn duy
nhất tối ưu. Điều đó không tự vô hiệu một gate đã công bố và được giữ qua
các milestone. Số10ms là local efficiency/readiness policy, không future
OS/server bound. Không dùng budget suy luận4–6s để miễn gate telemetry.

[Category ledger](../artifacts/5d1_pipeline_slo_review_p25_v1/boundary_category_ledger.json)
tách disabled/shadow added costs, compact enqueue, ready validation,
fault-known fallback, active compute, checkpoint/admission, full collector,
Stop và native H/I/S/R. Full pipeline max10 và checkpoint max30 là **hai gate
riêng**; tổng C+P dưới40ms không thay việc phải đạt cả hai.

## Production boundary và reserve

[Accounting ledger](../artifacts/5d1_pipeline_slo_review_p25_v1/production_accounting_ledger.json)
map actual call placement, timestamps và ownership. Các finding quan trọng:

- `decision_exit_ns` lấy sau BASIC/await/selection nhưng trước collector hash.
  Fresh policy và controller work tiếp theo thuộc H, không reset budget.
- `start()` tạo witness/source/config trước `preflight_start_ns`; phần này
  nằm trong native H. Existing direct-runtime read và input thuộc I.
- Production caller truyền hash từ `identity.source` đã có; synthetic
  microbench tự gọi thêm `AutonomousSource.from_state` ở caller. Không coi
  ba hash của microbench là ba game reads mới hoặc cùng exact production cost.
- `finish()` lấy `ended` sau executor return rồi mới monitor/encode/enqueue.
  Các bước sau marker không nằm trong reported H/I nhưng nằm trong full
  collector microbench và conservative allowance S. Không thay ended thành
  exact click/ACK hoặc dùng post-input fault để phát BASIC thay thế.
- Combat/session setup metadata nằm ngoài interval. Phép đo này không chứng
  minh setup/background/whole-app/native latency bound.

Current accounting giữ nguyên:

```text
C = max(non-disabled checkpoint/admission maxima)
S = C + full collector pipeline max
R = max(action floor,1000,H_basis+I_basis+S+W_full+250)
D = min(t0+B,t0+raw_remaining−R−M), M≥100ms
```

S cộng full pipeline dù một phần telemetry đã có trong native H/I là chủ
đích bảo thủ ở P17. I đã chứa actual waits mà vẫn cộng W_full3120ms là chủ
đích P9/P17, không phải lỗi cần trừ. Guard250ms cộng một lần trong aggregate;
margin100ms ngoài R. Không có new omission/unsafe double-count được chứng
minh trong review này; không tự hạ reserve/guard hoặc đổi read order.

Failed P21 arithmetic vẫn C12.5955 +P11.8417 =S24.4372ms;
H405.3797/I2972.325/W3120/G250 cho R6772.1419ms, **descriptive only**.
Native lineage26BASIC/20anchors,7P15supplement/16missing và30P19returns giữ
scope riêng. Gate failure chặn authority trước khi dùng allowance này.

## Kiểm evidence hiện có

[Recomputation](../artifacts/5d1_pipeline_slo_review_p25_v1/evidence_recomputation.json)
đọc lại toàn19,000P24records và102,000spans: indices/warmups, fixed blocks,
clock arithmetic, parent spans, metadata/outcomes/GC đều khớp; không đo mới.
P24 A/B/profile max1.1448/1.4526/1.4458ms, CPU quantized15.625ms,
0profile GC events. Source/host khớp không làm harness/protocol interchangeable.

P18/P21 raw61,000/51,000measured mỗi run cũng được tính lại riêng. P18
pipeline max9.469ms giữ historical source294; P21 max11.8417ms với đúng một
measured sample>10ms, current source297. Không pool populations hoặc đổi warmup.
Full2316tests PASS chỉ xác minh log/footer/exit cũ. P23 host-guard failure
giữ0records; P24 repair và diagnostic PASS chỉ scoped integrity.

Historical tail cause vẫn UNKNOWN. CPU granularity và chưa reproduce không
chứng minh noise/descheduling. P24 profile `start`59.35% chỉ khoanh vùng
chi phí thường gặp có instrumentation; chưa isolate config projection và
không cấp phép bỏ witness/source/config validation.

## Remediation cụ thể đã chuẩn bị

[Proposal](../artifacts/5d1_pipeline_slo_review_p25_v1/remediation_proposal.json)
accepted=false/implemented=false. Source hiện có18fields trong frozen
PolicyConfig, gồm Enum/scalar/None. `jsonable(config)` dùng `asdict` rồi lại
duyệt conversion; `start()` gọi đường đó trước canonical digest. Có thể kiểm
phương án local đọc fields trực tiếp, unwrap Enum và giữ scalar/None,
**vẫn chuyển cấu hình hiện tại và gọi nguyên canonical_json/digest**.

Ranh giới proof bước sau:

- Chỉ candidate artifact, không thay global `jsonable` hoặc src/tools/tests.
  Exact shape/type mới đi candidate; unsupported/new shapes fallback đường
  cũ. Không bỏ field, cache digest hoặc dùng config/snapshot từ lượt trước.
- Chứng minh exact JSON/digest/exception/fallback parity trên toàn18fields,
  Enum/None/legacy mana/boundaries/unsupported cases. Giữ witness, hashes,
  monitor, encode/enqueue, input/preflight/ACK/Stop nguyên vẹn.
- Chỉ sau parity PASS mới đo component một invocation đã freeze:6000legacy
  +6000candidate,1000warmup/mode, fixed A/B blocks, cap60s. Không chạy lại full
  pipeline hoặc qualification. Tiêu chí định trước cho implementation proposal:
  cả4block-pair median savings≥0.010ms và candidate aggregate p95≤legacy p95.
  Không đạt thì NOT_PROVEN, không retry/đổi tiêu chí sau xem data.

Lợi ích hiện còn **NOT_MEASURED**. Có parity/cost proof cũng chưa chứng minh
whole-pipeline cải thiện, chưa chữa historical tail và chưa runtime acceptance;
future integration/source review/fresh qualification sẽ là bước riêng.
[UNKNOWN ledger](../artifacts/5d1_pipeline_slo_review_p25_v1/unknown_ledger.json).

## Preservation và STOP

P24 manifest38artifacts/7docs/freeze7files, P23 faults, P21 failed raw/full
regression đã verified. Source297 bab0145d…/host/HEAD,7,702parent artifacts,
6claims, current preferences Mega Icarus và4static game hashes bảo toàn;
external UI closure P23/current settings giữ nguyên, không thành native evidence.
[Final preservation](../artifacts/5d1_pipeline_slo_review_p25_v1/verification_final.json).

P25 chỉ docs/review artifacts/recompute file; không code/harness changes,
tests/benchmark/qualification/diagnostic/soak, game attach/read/capture/input,
UI/worker/network hoặc preferences/claims/build/version/Git writes.
Accepted S/R và native U/transport/alignment vẫn null; strict/legacy,
root250/final100, one-t0/budget/guard/margin/no-second-input giữ. Suy luận
giữ BASIC là bình thường, không quota đổi nước.

Next duy nhất **[P26 config serialization candidate proof OFFLINE](../prompts/5D1_P26_POLICY_CONFIG_SERIALIZATION_PROOF_OFFLINE.md)**,
**SELECTED ONLY / NOT EXECUTED**. Chưa cần game; không resume P19/general
SIMPLE/CAREFUL/Demon/Mega/D1cap12/D2 hoặc đóng Phase5. **STOP P25.**
