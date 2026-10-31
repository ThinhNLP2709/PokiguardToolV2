# 5C.1 — Shadow publication adapter

Ngày2026-10-10, Asia/Saigon. **PASS STRONG — OFFLINE SHADOW SEAM ONLY**.

```text
PROJECT: PokiguardToolV2
STEP / PARENT / MODE: 5C.1 / 5B.4 / SHADOW_ADAPTER, OFFLINE VERIFICATION
RESULT: PASS STRONG — NO LIVE OR REASONING SELECTION ACCEPTANCE
EFFICACY: NOT_APPLICABLE / NOT_MEASURED
SOURCE: v1.2.5 existing worktree; historical baseline v1.2.4
HEAD: c646acfa5e895732bbdade553f9d7bd61171cd29
BRANCH: codex/phase3a2-board-repair
SOURCE FINGERPRINT: 774fb7e8cacdfeb529f831c4dd953d055f8b340b1b7b0a36399f3665910a2a93
GAME ATTACH / LIVE INPUT / BUILD: NOT_RUN
COMMIT / PUSH / TAG / VERSION / RELEASE: NONE
NEXT: 5C.2 — SELECTED, NOT_EXECUTED
STOP: 5C.1
```

## Thay đổi và scope

User hỏi có cần live test không, nếu chưa cần thì tiếp tục sau B4. EntryB1–B4
đã PASS. Đã đọc contract/status/router/prompt, research A0, A1/A3 và capability
manifest; thực hiện đúng C1, không UI/pilot/model/game attach. Bú win chỉ giữ
note nhánh phụ khi user báo kết quả test, không mở lại lịch sử side fixes.

Thêm4 source/tool/test files: `reasoning_shadow.py`, `test_reasoning_shadow.py`,
`evaluate_reasoning_shadow.py`, `qualify_reasoning_shadow_logging.py`. Existing
source chỉ sửa `tools/basic_auto_bot.py`: optional argument `shadow_adapter=None`
và4 setup statements. Không truyền adapter thì không import AI, không đổi log
handle, không worker/queue/model. Không thêm CLI/UI tự bật shadow.

[Source audit](../artifacts/5c1_shadow_v2/source_manifest.json):246 Python files trong src/tools/tests,
242 trước bước,241 nguyên byte,1 chỉ hook trên,4 mới. Bỏ đúng hook/signature mới
khôi phục **byte-exact hash** của controller trước C1, kể cả mixed line endings.
[Verifier tái lập audit](../artifacts/5c1_shadow_v2/verify.py) là artifact offline, không production module.
Unrelated dirty work v1.2.5 được giữ; không reset về lịch sửv1.2.4. B4 components
không sửa. [Spec/seam map](../specs/5c1_shadow_adapter.md).

## Baseline và flow

`_write` hiện có vẫn encode/write/flush như cũ. Adapter nhận chuỗi immutable đã
encode, chuyển nguyên payload/return/flush tới handle cũ rồi try-admit observation.
Không chèn reader/capture/policy/executor hook; không nhận provider/window/input
capability. Existing action branches, mandatory PASS/idle/srvSeq, pending, ACK,
QTE, preflight, input lease, recovery và FarmRunner giữ nguyên.

26 C1 tests gồm actual BASIC decision/byte-forwarding parity cho6 profiles ở
seam harness, native writer/fault helpers, stale/fresh source, pending/unattributed
ACK, disabled imports, Stop và queue pressure. Sequence harness là boundary
fixture, **không giả đã chạy toàn controller/game thật**. Structural source audit
cho thấy zero added provider reads/captures/ACK polls; live read/capture counts và
full controller wall-time vẫn NOT_MEASURED, thuộc C3.

Adapter không có selection/input method. BASIC luôn quyết định và dispatch;
worker proposal hoặc lỗi chỉ để diagnostics. Không có replacement sau physical
input. Stop signal-only; worker/logger cleanup ở nền. Factory không tạo owner
mới khi owner cũ còn chạy hoặc cleanup chưa xác nhận; bỏ AI, không chờ BASIC.

## Capability và attribution

State là publication đã có, không reread game. Config clone/freeze một lần.
SWAP source/actor/profile/board/coordinate phải hợp lệ; non-SWAP chưa đủ nguồn
trong legacy log → unsupported, BASIC vẫn chạy family đó. Controller generation,
account/model/effect/calibration/observation age/legality/input reserve thiếu giữ
UNKNOWN. Processing cap4s/hard6s là **shadow cap**, không cấp quyền gửi input ở C4.

R1 enumerate112 pairs nhưng retain vì runtime model/legality chưa bound. R2 và
learned model không promote. Chưa claim3Kiếm+Nộ override, xử lý Shield loop,
survival hoặc hiệu quả farm đã accepted trong game; các gate D vẫn nguyên.

Chỉ ghi dispatched candidate khi actual action_sent khớp root board/actor/profile,
session/turn/srvSeq/hash/target và AutonomousActionIdentity. Root critical-state
hash chưa published được ghi rõ; không gọi nó final-preflight certificate.
Outcome chỉ theo nguyên dispatch identity từ action_result sẵn có, không poll
ACK. Thiếu/khác/evicted → UNKNOWN. ACK không suy ra win; terminal, boss move và
unchosen counterfactual outcome vẫn UNKNOWN. Native tests kiểm candidate/job/run/
snapshot/config correlation, first error stack và loss accounting.

SourceRecord là virtual single-record SHA, không checksum giả của growing log;
không tự export thêm file trên action path. Source trong perf/tests là synthetic
fixture được ghi rõ trong protocol, không observation game hoặc win sample.

## Logging: chọn separate với hard rate caps

Actual common combat/FarmRun writers hiện đồng bộ. Không thay semantics hoặc
cho AI thread dùng chung file/handle với gameplay. Parent B4 separate CPU stress
**vẫn fail và không bị promote** ở tải khoảng500pairs/s.

C1 có **thay đổi thiết kế thật**: tối đa1 prepared job/s và8 diagnostic events/
128KiB trong mỗi1s window. Vượt quota/full/busy → drop+counter, invalidate/stop AI;
không retry hoặc synchronous rescue. Do đó qualify separate trong phạm vi bounded
này, không lấy phép đo mới để chứng nhận stress cũ. Factory explicit
`create_shadow(enabled=True, directory=...)` sở hữu B4 killable disk writer;
disabled hoặc thiếu backend path/sink trảNone. C2 mới expose setting.

Combined buffers512records/8MiB, gồm in-flight: input16/1MiB, relay64/1MiB,
sink432/6MiB. Adapter là sole sink producer. B4 rotation10MiB×10files/7days,
event16/32KiB, error cardinality64/first stack/repeat aggregation giữ nguyên.
Stop không drain trên caller; tail logs best effort, written không phải fsync.

[Qualification](../artifacts/5c1_shadow_v2/logging/qualification.json):3×30s/mode,
8events/s, payload14,000bytes, shared B4 writer **emulation** so common+separate
writer. Separate−shared CPU pp: **−0.034722 / +0.078124 / −0.004339**, tất cả≤1pp.
2,892 eligible fixture records written, zero drop/failure/discard, quiescent
accounting valid và9 owned writer processes được cleanup. Không pool CPU runs.
Đây là CPU/log-throughput qualification; không là gameplay FPS/throughput proof.

Qualification producer/B4 sink source giữ nguyên. Metadata snapshot của adapter/
tests có trước các guard cleanup/identity/factory cuối: CPU driver chỉ import4
constants của adapter, không instantiate adapter hoặc import C1 tests. Constants
và mọi source thực thi CPU workload không đổi; [compatibility audit](../artifacts/5c1_shadow_v2/compatibility.json)
ghi đúng scope. Final seam benchmark/full tests dùng final source fingerprint.

## Offline verification và overhead

**1,925/1,925 full regression PASS**,87.661s, gồm **26 C1 tests**. Xem
[full log](../artifacts/5c1_shadow_v2/full_regression.log) và
[C1 subset](../artifacts/5c1_shadow_v2/focused_final_from_full.log).
Full suite chạy trước final timing; không chạy regression đồng thời CPU/perf.

Faults: worker crash/corrupt/hang/late, malformed/missing/conflicting source,
unattributed/pending/stale/after-dispatch observation, AI sink exception, native
denied/ENOSPC/hang/crash, queue lock/full/oversize, log quota, Stop, factory overlap
và unconfirmed cleanup. Không đổi BASIC bytes/actions, cleanup xác nhận ở tests.
Đây là focused C1 cases/subcases; **không gọi là30trial/variant của full C3 matrix**.
B4 unchanged worker/log boundary vẫn có490trials và30min component evidence.

[Final benchmark](../artifacts/5c1_shadow_v2/performance/benchmark.json):3×10,000
measured +1,000warmup/run/mode,6modes,180,000 timing observations +18,000warmup.
Interleaved control/mode, nearest-rank p50/p95/p99/max, raw tails giữ nguyên.
Enabled dùng owned separate disk writer; pressure modes dùng declared fakes.
Toàn bộ **phần mới** trên action thread được đo: observed-write/admission/forward
flush; parse/copy/hash/make_job thực sự ở nền, được kiểm bằng thread assertion.
Không dùng prepared-submit timing che preparation inline. Common serializer/
provider/executor wall latency không được chứng nhận bởi seam timing này.

Milliseconds; mỗi cell là worst same-quantile qua3runs, không pool.

| Mode | p50 | p95 | p99 | max |
|---|---:|---:|---:|---:|
| disabled | 0.0000 | 0.0001 | 0.0002 | 0.0258 |
| enabled | 0.0036 | 0.0353 | 0.0466 | 2.2716 |
| busy | 0.0020 | 0.0027 | 0.0044 | 0.0807 |
| full | 0.0022 | 0.0034 | 0.0057 | 0.1134 |
| sink_fault | 0.0029 | 0.0346 | 0.0468 | 1.5296 |
| stopped | 0.0003 | 0.0005 | 0.0007 | 0.0340 |

Final quantiles/gates nằm trong [verification](../artifacts/5c1_shadow_v2/verification.json).
Mỗi run đạt disabled p50/p95/p99/max≤0.1/0.5/1/5ms; enabled/pressure
≤0.5/1/3/10ms. Không drop unfavorable OS tails hoặc pool để che fail.

Environment Python3.11.9/Windows26300,12logical CPUs; perf_counter high-resolution
host clock. System load/power không controlled cho C1, raw stalls giữ nguyên;
qualification chỉ áp host/workload đã khai báo. Không chứng nhận máy ảo/máy khác.

Prototype/calibration trong `5c1_shadow_v1/` và `performance_before_*` được giữ,
không dùng làm final acceptance. Block đầu sai profile freeze/corpus và gồm
unchanged logger serialization đã INVALIDATED, gồm cả các tails vượt target.
Các block khác superseded vì source bounds/guards/rate caps đổi; không mix với final.

## Gates và router

| Gate C1 | Result / evidence |
|---|---|
| BASIC selection/existing sequence parity tại seam | PASS — source reconstruction,6profile harness, full regression |
| Zero added provider reads/captures/polls | PASS structural — string-only adapter, no new provider/capture call |
| No wait planner/log; copy/hash off action thread | PASS — try admission, thread assertion, final timing |
| Disabled default/no AI resource | PASS — optionalNone, fresh subprocess import test |
| Fault/queue/Stop isolation | PASS — focused/native faults, counters, confirmed cleanup |
| Existing fail-closed/preflight/ACK owners | PASS structural/regression — original branches byte-preserved |
| Actual BASIC dispatch/outcome attribution | PASS scoped — exact published identity; missing evidence UNKNOWN |
| Bounded diagnostic backend + overhead | PASS — rate-capped separate qualification and final seam SLO |
| Full controller/live/efficacy/package | NOT_CLAIMED — C3/D/E/F gates còn nguyên |
| No commit/version/build/release | PASS |

**Exactly one next: [5C.2](../prompts/5C2_AI_SETTINGS_AND_IMMUTABLE_RUN_CONFIG.md)**,
selected/not executed. Chưa cần live test ở C1. STOP C1; C2/UI chưa thực hiện,
C3 live parity và C4 input authority chưa mở.
