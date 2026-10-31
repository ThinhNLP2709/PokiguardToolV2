# 5D.1-P22 — Review tail của timing pipeline, offline

2026-10-15 (Asia/Saigon). **FILE-ONLY REVIEW COMPLETE / CAUSE UNKNOWN /
PARTIAL D1.** Chọn chuẩn bị phép đo chẩn đoán bằng dữ liệu giả, chưa triển khai
harness hoặc chạy phép đo. [Prompt P22](../prompts/5D1_P22_PIPELINE_TAIL_REVIEW_OFFLINE.md),
[parent P21](5d1_p21_report.md),
[quyết định](../artifacts/5d1_pipeline_tail_review_p22_v1/decision.json).

## Kết luận

P21 vẫn **FAIL qualification**, đúng gate `full_timing_pipeline_latency`:
sample index2789 là **11.8417ms > max10ms**. Đã kiểm lại toàn bộ raw, warmup,
indices và summary; không sửa số liệu, bỏ mẫu, đổi threshold hoặc chạy lại.
Chưa đủ bằng chứng xác định nguyên nhân của mẫu này. Không kết luận nó do
OS noise, GC, root policy hoặc lỗi code.

Điểm mới từ source review: tạo root policy metadata và tính authority identity
nằm **ngoài** timer của microbench; nhưng copy metadata vào payload và encode
JSON vẫn nằm **trong** timer. Vì vậy không thể nói thay đổi P21 hoàn toàn
không ảnh hưởng phép đo. Chi phí tăng thêm chưa được đo riêng. Ngược lại,
P18/P21 là hai run khác thời điểm, không phải paired experiment, nên khác biệt
max không chứng minh regression.

Chọn duy nhất **targeted fake-only diagnostic measurement**. P22 đã soạn
[proposal](../artifacts/5d1_pipeline_tail_review_p22_v1/diagnostic_measurement_proposal.json)
accepted=false. Chưa chọn tối ưu code hoặc sửa SLO. Next P23 sẽ tạo harness
riêng và chạy đúng một invocation đã định trước; kết quả chỉ chẩn đoán, không
thay qualification hoặc cấp quyền live.

## Kiểm lại evidence và lịch sử các lần chạy

P21 final manifest kiểm khớp **2,344 artifact files + 7 documents** trước khi
update tài liệu P22. Source vẫn **297 Python files**:
`bab0145da486101b910fd8195acd189f6e3dc033b900e46b56bc0f858248bd40`;
host `3a0ab45d64462c647ccc713c18bdb7ba64d666ddac4822a1c31789f5378a88a9`.
Đọc lại footer và exit receipt của full regression: **2,316 tests PASS,
398.818s, exit0**. P22 không chạy tests mới.

Initial focused72 có4 lỗi harness, repair10 PASS, rồi final full2316 PASS
trên source hiện tại. Qualification đầu lỗi source binding; hai lần kế tiếp
ngắt khi traversal fixture, trước microbench. Cả ba thư mục chỉ có
`source_manifest.json`, không có raw latency. Chúng không phải failed latency
datasets. Final `qualification_verified` là measured qualification đã hoàn tất;
FAIL được giữ nguyên. [History audit](../artifacts/5d1_pipeline_tail_review_p22_v1/parent_run_history_review.json).

Exporter rejection log vẫn ghi `ValueError: v3 pipeline threshold changed`;
không có blocked draft output. Đây là kiểm chứng từ log cũ, không gọi exporter
hoặc verifier lại. CLI exit0 của qualification không thay `pass_all=false`.

## Raw recomputation

[Current recomputation](../artifacts/5d1_pipeline_tail_review_p22_v1/p21_raw_recomputation.json)
pin raw gốc bằng SHA256, kiểm finite/nonnegative, exact index0..5999 và
`warmup == (index < 1000)` cho từng mode. Quantile dùng nearest rank
`sorted[min(n-1,max(0,ceil(p*n)-1))]`, đúng contract hiện tại.

| Nhóm | Raw wall-time values | Warmup | Measured |
|---|---:|---:|---:|
| 5 checkpoint modes | 30,000 | 5,000 | 25,000 |
| 4 admission modes | 24,000 | 4,000 | 20,000 |
| Full collector pipeline | 6,000 | 1,000 | 5,000 |
| Signal-only Stop | 1,000 | 0 | 1,000 |
| Tổng | **61,000** | **10,000** | **51,000** |

54,000 CPU values đi kèm checkpoint/admission được kiểm riêng; không đếm
chúng như wall-time samples mới và không ghép sang pipeline. Admission v4 có
đủ6,000 rows mỗi mode với exact policy và read span: admitted/busy250,000,000ns,
span-rejected250,000,001ns, clock-rejected−1ns.

| Pipeline measured | P18, source294 | P21, source297 |
|---|---:|---:|
| p50 | 0.2644ms | 0.2725ms |
| p95 | 0.3339ms | 0.4227ms |
| p99 | 0.5884ms | 0.6878ms |
| Max | 9.4690ms | **11.8417ms** |

[P18 recomputation](../artifacts/5d1_pipeline_tail_review_p22_v1/p18_raw_comparison.json)
giữ population/source riêng; không pool, dùng PASS cũ hoặc giảm reserve.
P21 p50/p95/p99 dưới0.5/1/3ms, nhưng max vượt10ms nên gate vẫn FAIL.
Warmup max0.9225ms không che mẫu index2789; đó là measured ordinal1790.

Đúng một measured pipeline sample vượt10ms. Các mẫu lớn tiếp theo:
index5187=9.2042ms, index5185=5.0971ms, index2788=3.9118ms,
index3147=1.7756ms. [Các cửa sổ raw](../artifacts/5d1_pipeline_tail_review_p22_v1/pipeline_tail_windows.json)
giữ nguyên mẫu lân cận. Cụm giá trị lớn chỉ là mô tả phân phối, chưa chỉ ra
CPU/GC/descheduling.

Recompute latency/CPU/Stop, kiểm normalized trace rows và đối chiếu outcome,
AST/history/cleanup/stress receipts vẫn cho **31/32 gates**. Các gate dựa trên
outcome/worker cleanup receipt không được giả thành per-sample trace mới.
Checkpoint added mean CPU0.75ms; admission max mean CPU0.73125ms, dưới1.5ms.
Stop max0.0264ms <25ms. Stress receipt60.0006588s,53,757cycles,
max1 queued record, peak26,032B; không có per-cycle trace.

Stress gọi `decision -> stop` và encode abandoned interval; nó không chạy lại
toàn `start/preflight/finish` pipeline. Receipt này không giải thích mẫu2789
hoặc chứng minh whole-app/native soak.

## Vùng được đo thực tế

[Boundary map](../artifacts/5d1_pipeline_tail_review_p22_v1/pipeline_boundary_map.json)
pin source và line ranges. Timer ngoài nằm ở
`qualify_reasoning_operational.py:195–202`; đo actual collector methods trên
state giả cố định, MemorySink mới mỗi sample, `result=None` và không có input.

| Ngoài interval | Trong interval |
|---|---|
| Source/fixture ancestry verification, warm worker, checkpoint/admission benchmarks, Stop/close | Host observe markers và đọc field của synthetic state |
| Sink/collector allocation, authority identity, reserve setup, root policy `.plain()` | Decision +3 critical-state hashes; fresh/final marker writes |
| Post-timer JSON decode/assertions và raw disk write | Witness/config serialization, pending/preflight dicts |
| Separate stress loop | Payload/root metadata copy, component monitor, event encode, bounded enqueue |

Các marker fresh/final không phải memory reads. Pipeline không gọi provider,
CV, solver/planner, executor/click, actual final direct-runtime read hoặc
`operational_preflight_failure`. Native/session acceptance cần evidence riêng.
MemorySink chỉ gọi DiagnosticBuffer với try-lock và caps; không đo writer
flush, durability hoặc contention của toàn ứng dụng.

`finish()` lấy internal `ended` trước khi hoàn thiện payload/encode/enqueue.
Outer timer vẫn tính các phần sau đó. Không được đồng nhất payload
`executor_return_ns` với outer end hoặc exact click timestamp.

Source có ba lần tính critical-state hash: decision, caller argument của
start, và start. Đây là công việc tồn tại từ P18, chưa có breakdown chi phí.
Không tự cache hash qua các fresh snapshots hoặc bỏ consistency checks để
tối ưu; production có thể dùng state khác nhau giữa các boundary này.

Exact P18→P21: **6 existing changes /3 new /288 existing byte-exact**.
[Source comparison](../artifacts/5d1_pipeline_tail_review_p22_v1/source_comparison.json)
xác nhận toàn pipeline `with` AST giữ nguyên và collector chỉ đổi `__init__`.
Admission250, rejected-root receipts và v4 verifier nằm ngoài collector
sample; fixture cache cũng nằm trước microbench. Root metadata vẫn tăng dữ
liệu payload trong interval dù code `finish/encode` không đổi. Event payload/
byte size và absolute timestamps mỗi sample không được persist, nên không
thể tính lại riêng chi phí encode từ raw hiện có.

## Bằng chứng còn thiếu và bước kế

[UNKNOWN ledger](../artifacts/5d1_pipeline_tail_review_p22_v1/unknown_ledger.json)
giữ nguyên nguyên nhân historical spike, CPU/per-stage/GC/scheduling,
metadata increment và native U/transport/alignment. Pipeline raw chỉ có
index/warmup/ms. CPU ở benchmark khác và shape của tail không bù được thiếu sót này.

P23 đã được định nghĩa để trả lời câu hỏi nhỏ nhất còn thiếu:

- Harness riêng dưới artifact directory, pin source/host/harness; không đổi
  src/tools/tests, qualifier hoặc verifier.
- Một invocation tối đa120s,19,000 records đã định trước:6,000 current,
  6,000 metadata-only counterfactual,6,000 profiled current và1,000 empty
  instrumentation samples. Fixed A/B blocks; không pool các nhóm.
- Lưu same-sample wall/thread CPU/process CPU, method spans, event bytes,
  profiled GC overlap và instrumentation overhead. Phân biệt nested/inclusive
  spans, không cộng trùng hoặc trừ overhead để lấy PASS.
- Counterfactual bỏ metadata chỉ tồn tại trong harness với state giả; đó là
  telemetry không hợp lệ cho authority và không thể đưa vào calibration.
- Không tái hiện spike thì kết quả là INCONCLUSIVE; không rerun, tăng max,
  tắt GC hoặc kết luận historical failure đã biến mất. Future trace cũng
  không xác định hồi tố nguyên nhân chính xác của index2789.

Đây là **diagnostic preparation**, chưa có measurement, optimization, SLO
proposal accepted hoặc current allowance/reserve. Descriptive S24.4372ms /
R6772.1419ms vẫn không được dùng để kích hoạt. Root250/final100 giữ opt-in;
legacy/finite-U/one-t0/deadline/budget/guard/margin/Stop/ACK/no-second-input
giữ nguyên. Normal BASIC retention hợp lệ, không quota đổi nước.

## Preservation và STOP

Source297/host/HEAD, **7,609 parent artifacts**,6claims, ordinary preferences
và4static game files bảo toàn. Năm docs trước update được copy để giữ P21
manifest history. Existing idle UI stream được giữ prefix; append riêng
không thành native evidence mới. [Final preservation](../artifacts/5d1_pipeline_tail_review_p22_v1/verification_final.json).
P22 chỉ đọc file/tính lại dữ liệu và ghi docs/review artifacts; không code,
tests/benchmark/qualification/soak, game attach/read/capture/input/UI,
network, build/version/Git hoặc preferences/claims changes.

Next duy nhất **[P23 pipeline diagnostic OFFLINE](../prompts/5D1_P23_PIPELINE_DIAGNOSTIC_OFFLINE.md)**,
**SELECTED ONLY / NOT EXECUTED**. Chưa cần mở game. Không resume P19, mở pilot
mới, general SIMPLE/CAREFUL/Demon/Mega/D1cap12/D2 hoặc đóng Phase5.
**STOP P22.**
