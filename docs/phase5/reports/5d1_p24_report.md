# 5D.1-P24 — Sửa harness host binding và diagnostic offline

2026-10-15 (Asia/Saigon). **HARNESS REPAIR PASS / DIAGNOSTIC INTEGRITY PASS
SCOPED / ORIGINAL TAIL CAUSE INCONCLUSIVE / PARTIAL D1.**
[Prompt](../prompts/5D1_P24_DIAGNOSTIC_HOST_BINDING_REPAIR_OFFLINE.md),
[parent P23](5d1_p23_report.md),
[raw recomputation](../artifacts/5d1_diagnostic_host_binding_p24_v1/raw_recomputation.json).

## Kết quả

Đã sửa host binding của harness riêng, qua **12 fake validation cases**, rồi
chạy đúng **một diagnostic invocation**, exit0, đủ **19,000 records** trong
**10.9656352s**, dưới cap120s. Không retry, đổi threshold hoặc chạy lại
qualification. Không có game attach/read/capture/input, UI hoặc worker launch.

Mẫu lớn nhất của các nhóm mới là1.4526ms. Không tái hiện tail11.8417ms của
P21; nguyên nhân mẫu cũ vẫn **UNKNOWN**, không được quy thành OS noise,
GC hoặc root-policy regression. P21 qualification vẫn **31/32 FAIL**; kết quả
diagnostic không thay qualification hoặc cấp accepted allowance/reserve/live.

## Sửa đúng phần host/attempt receipt

Harness P24 được copy vào artifact directory mới; toàn P23 frozen bytes/logs
giữ nguyên. Actual `host_record()` dùng nguyên algorithm cũ, lấy trước guard
và project imports, freeze thành canonical JSON text với SHA/timestamps/
provenance. Guarded preflight kiểm text/hash/current source, không gọi lại
`platform.node()` dưới guard. Không hardcode tên máy hoặc mở socket guard.

Sau run, receipt chỉ xác nhận **same-process pre-guard capture**; actual host
được recompute riêng trong final preservation. Không gọi cache là second
observation. Source297 vẫn
`bab0145da486101b910fd8195acd189f6e3dc033b900e46b56bc0f858248bd40`;
host vẫn `3a0ab45d64462c647ccc713c18bdb7ba64d666ddac4822a1c31789f5378a88a9`.

Exclusive durable attempt receipt được ghi trước host capture/preflight;
run claim riêng chỉ có sau valid binding. Attempt sớm lỗi cũng không được
retry. Fake validation kiểm đủ8cases cũ và4case mới cho host provenance/
tamper/wrong source, guards còn đóng, failed-preflight receipt và retry rejection.
[Fake validation](../artifacts/5d1_diagnostic_host_binding_p24_v1/fake_validation.json),
[static review](../artifacts/5d1_diagnostic_host_binding_p24_v1/static_change_review.json),
[frozen manifest](../artifacts/5d1_diagnostic_host_binding_p24_v1/frozen_manifest.json).

Chỉ đổi `fake_validate`, `measure`, `main` và thêm3helpers trong harness.
Guard, sequence, profiled sequence, sampling, Tape/GC/deadline methods giữ
exact AST với P23. Control sequence khớp actual P21 interval sau fixture
alias normalization. Không sửa src/tools/tests, production collector hoặc
qualifier/verifier. Không chạy full tests; existing P21 **2316PASS** chỉ đọc
footer/exit và giữ đúng historical source.

## Coverage và thời gian

Đã kiểm toàn raw indices/warmups/clock arithmetic/outcomes, fixed A/B blocks
và102,000profile spans. Có3,000warmups,15,000measured pipeline samples và
1,000empty instrumentation samples; không pool chúng thành qualification.

| Nhóm | Raw / measured | p50 | p95 | p99 | Max |
|---|---:|---:|---:|---:|---:|
| A — current metadata | 6000 /5000 | 0.3023ms | 0.4596ms | 0.6156ms | 1.1448ms |
| B — bỏ metadata trong harness | 6000 /5000 | 0.3012ms | 0.4783ms | 0.6781ms | 1.4526ms |
| Profile current | 6000 /5000 | 0.3570ms | 0.5321ms | 0.7640ms | 1.4458ms |
| Empty wrapper instrumentation | 1000 /1000 | 0.0014ms | 0.0019ms | 0.0026ms | 0.0093ms |

Nearest-rank quantiles giữ nguyên; toàn warmups/outliers nằm trong raw.
Không mẫu raw hoặc measured pipeline vượt10ms. B là counterfactual giả,
telemetry **không hợp lệ cho authority**, không đưa vào cost qualification.
Empty wrapper chỉ đo một wrapper/clock enclosure; không trừ nó khỏi profile
17spans để tạo số PASS.

CPU endpoints bao ngoài wall markers nên có thêm clock calls. Clock info
báo100ns resolution, nhưng actual thread/process durations trong mẫu chỉ
nhảy **0 hoặc15.625ms**. Thread CPU zero ở97.8% A,98.04% B,97.68% profile.
Nhiều CPU ticks lớn hơn toàn wall sample; không được coi0 là không dùng CPU,
lấy wall−CPU để xác định descheduling hoặc phân bổ CPU dưới một ms. Per-sample
CPU attribution **INCONCLUSIVE** dù cùng-sample fields đã thu đủ.

## Những gì profile và control cho biết

[Stage recomputation](../artifacts/5d1_diagnostic_host_binding_p24_v1/profile_stage_recomputation.json)
kiểm17spans/sample, gồm3critical hashes và9top-level spans; nested parent
coverage đều đúng. Trong instrumented measured profile, `start()` chiếm
**59.35%** tổng outer wall time, `finish()`17.78%, `decision()`10.33%.
`start` p50/p99/max=0.2113/0.4887/0.9521ms; witness/config digest/critical hash
nằm bên trong, không được cộng trùng để so với outer duration.

Đây là vị trí chi phí thường gặp trên fixed synthetic state có instrumentation;
không xác định nguồn gây historical11.84ms. Wrappers, clock calls và list
allocation tự thêm chi phí. Chưa có căn cứ bỏ/cached fresh state/config/
witness checks hoặc sửa gameplay từ concentration này.

[A/B comparison](../artifacts/5d1_diagnostic_host_binding_p24_v1/metadata_control_comparison.json)
giữ8blocks và4cặp index-matched tuần tự. Metadata thêm thường122bytes;
median A−B theo4cặp là−0.0011,+0.0020,−0.0021,+0.0024ms. Dấu đổi theo
thứ tự AB/BA; block không randomized/simultaneous. Không chứng minh metadata
là nguyên nhân tail hoặc có chi phí bằng0; incremental bound vẫn null.

[GC join](../artifacts/5d1_diagnostic_host_binding_p24_v1/GC_join_review.json)
ghi0callback events trong profile window, overflow0, GC vẫn enabled.
Controls không cài callback; không suy rằng historical P21 hoặc mọi phase
đều không GC. [Tail windows](../artifacts/5d1_diagnostic_host_binding_p24_v1/tail_windows.json)
giữ41windows: toàn pipeline raw≥1ms và top10 mỗi nhóm; không bỏ mẫu.

## Quyết định và bước kế

[Decision](../artifacts/5d1_diagnostic_host_binding_p24_v1/decision.json),
[UNKNOWN ledger](../artifacts/5d1_diagnostic_host_binding_p24_v1/unknown_ledger.json).
Không chọn optimization runtime từ nguyên nhân chưa biết. Không lặp phép đo
đến khi tìm được spike hoặc lấy lần này dưới10ms để thay P21 FAIL.

Next duy nhất là **P25 file-only pipeline SLO/disposition review**: truy
nguồn max10ms và kiểm boundary/category của nó trước khi chọn remediation.
Lý do review độc lập với giá trị11.8417ms: spec5A.3 nói shadow **paired added
critical-path** cost, còn P10/P12/current gate kiểm **absolute full host-only
collector**. Hai scope cần được map bằng evidence/contract, không mặc định
là sai hoặc tự thay thế nhau. P25 phải xác định gate hiện tại có chủ đích
hay cần successor contract có rationale riêng. Chưa đề xuất threshold mới.

Current max10ms vẫn có hiệu lực, nguyên P21 failure giữ. Nếu không đủ rationale
độc lập thì giữ block, không tăng số chỉ để bao11.84ms. S24.4372/R6772.1419
vẫn descriptive, accepted S/R null. Native U/transport/alignment/first exact
click vẫn UNKNOWN. Root250/final100 opt-in chưa live; normal BASIC retention
hợp lệ, không quota đổi nước.

## Preservation và STOP

Entry verified P23 artifacts32/7docs, P22 artifacts19 và P21 artifacts2344,
original/archived document pins, source/host/full tests/footer/failed raw.
Current preferences Mega Icarus từ external change P23 được lấy làm baseline;
không restore Demon. Historical UI stdout kiểm archived exact prefix; closure
append/summary giữ nguyên, không thành native evidence mới.

Source297/host/HEAD,7,663parent artifacts,6claims, ordinary preferences và
4static game hashes được kiểm bảo toàn. [Final preservation](../artifacts/5d1_diagnostic_host_binding_p24_v1/verification_final.json).
Worker/input/game/UI/observer/native/network execution không xảy ra trong
diagnostic; local metadata setup tách khỏi guarded project execution. Import
DPI call vẫn bị Python stub chặn, không gọi native thật. Wrappers/GC/guards
restore, không fault/timeout/missing samples. Không version/build/Git writes.

Next **[P25 pipeline SLO review OFFLINE](../prompts/5D1_P25_PIPELINE_SLO_DISPOSITION_REVIEW_OFFLINE.md)**,
**SELECTED ONLY / NOT EXECUTED**. Chưa cần mở game; không resume P19 hoặc mở
general SIMPLE/CAREFUL/Demon/Mega/D1cap12/D2/Phase5 completion. **STOP P24.**
