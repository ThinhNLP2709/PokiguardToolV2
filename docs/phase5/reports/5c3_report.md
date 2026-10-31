# 5C.3 — Offline acceptance và current live closure

**Cập nhật 2026-10-11:** [live closure](5c3_live_closure_report.md) **PASS STRONG
trong scope Demon SWAP technical smoke** trên source260 hiện tại:3 BASIC +3
SHADOW,6/6 WIN,9 local turns/năng lượng ghi nhận,3 ACK,6/6 jobs giữ BASIC,
zero observed critical safety/flow regression. Skill/QTE/re-entry/live Stop và
live overhead chưa observed/measured; production selection vẫn gated.
C4 offline đã hoàn thành; next **5D.1 selected only**, chưa activated/executed.
[Bản report offline nguyên byte trước cập nhật](../artifacts/5c3_live_closure_preparation_v1/before_closure_docs/reports/5c3_report.md).

Phần bên dưới là acceptance offline lịch sử, giữ đúng source và kết quả tại
thời điểm đó; các dòng live pending/next C4 không phải current pointer.

Ngày: 2026-10-11 (Asia/Saigon).

```text
PROJECT: PokiguardToolV2
STEP / PARENT / MODE: 5C.3 / 5C.2 / BASELINE_LIVE_OPTIONAL — OFFLINE ONLY
RESULT: PASS_OFFLINE_LIVE_PENDING
SOURCE: v1.2.5 existing worktree; historical baseline v1.2.4
HEAD: c646acfa5e895732bbdade553f9d7bd61171cd29
BRANCH: codex/phase3a2-board-repair
RUNTIME CHANGE: AI LOG FILENAME UNIQUENESS ONLY
GAMEPLAY / UI / PROVIDER / EXECUTOR CHANGES IN C3: NONE
LIVE / BUILD / VERSION / COMMIT / PUSH / TAG: NONE
NEXT: 5C.4 OFFLINE ONLY — SELECTED, NOT_EXECUTED
```

Người dùng yêu cầu hoàn thiện C3 sau lần PARTIAL. Đã bổ sung phép đo và
harness offline và sửa lỗi trùng tên khi xoay log AI. **248/250 existing C3
sources giữ nguyên byte**; hai file thay đổi là logger AI riêng và test source
audit. Main controller/BASIC/provider/input/UI giữ nguyên; chỉ thêm sáu file
tool/test offline. BASIC giữ selection/input authority, shadow default OFF, R2 game
promotion DISABLED. Không attach/read game, network/API hoặc native input;
PokiguardAuto/pc giữ read-only.

Kết quả có scope rõ: phần observer SWAP hiện có đạt offline gates theo
[protocol V2 +rotation remediation](../research/5c3_qualification_protocol_v2.md). Live/full-app UI
timing, card/QTE/non-SWAP selection, account/boss/effect models và hiệu quả chơi
vẫn chưa được chấp nhận. Đây không phải toàn bộ Phase 5 đã xong.

## Kết quả và kiểm chứng

| Gate | Kết quả |
|---|---|
| Source/version/unrelated work preserved | 248/250 byte-preserved; AI logger +audit updated; 6 new offline files |
| Actual controller OFF/SHADOW parity | Normal SWAP→direct ACK→Stop, stale source, final wrong turn, pending→Stop |
| Existing C3 fault/Stop matrix | 100 paired Stop +1 native hung-worker Stop; 180 worker trials |
| Additional fault/Stop timing | 100 actual-controller Stop signals; 30 each admission/Stop exception |
| Native publication latency | Reuse V2 3×10k/mode +1k warmup qua explicit source compatibility; 12 groups/all strata đạt |
| Healthy integration resource stream | 30 phút sau 30 giây warmup; 915 jobs; durable log không mất |
| CPU/sink/disabled/memory/growth | Đạt các gates trong bảng dưới |
| Full regression | 1966/1966 PASS; 190,0240 s |
| Raw verifier / integrity | 142/142 required gates; source/artifact/document hashes |
| Live parity | PENDING — 0 attempts |

[Verification](../artifacts/5c3_integration_v3/verification.json),
[full regression](../artifacts/5c3_integration_v3/full_regression.log),
[raw controller/fault/Stop](../artifacts/5c3_integration_v3/integration_raw.jsonl),
[manifest](../artifacts/5c3_integration_v3/manifest.json).

Full-controller harness dùng explicit provider/window/capture/input fakes;
policy, actionability, calibration/mapping, final preflight, pending/direct
ACK và Stop là code thật. Clock/RNG jitter cố định cho hai arm, chỉ chuẩn hóa đường dẫn log offline; gameplay rows
và call order khớp, không loại field để ép parity. Exact LastMove/sequence/
opponent turn chứng minh ACK; wrong final owner chặn trước click, stale fresh
source chặn trước capture; pending không phát nước thứ hai. Zero native input.

B4 cancellation/native logger fault evidence reuse với exact source hashes:
30 cooperative trials, max56,0503ms; 30 hung trials terminate/reap max114,5934ms.
Native permission/disk-full/hang/crash có30 mỗi variant. Đây vẫn là component
evidence, kết hợp full-controller integration isolation và final regression;
không đổi tên thành live. V1 raw counters trước cleanup không phải orphan.

Additional Stop signal p95/p99/max = 0,0366 /0,0437 /0,0467 ms; known admission
exception→unchanged BASIC publication p95/p99/max = 0,0067 /0,0106 /0,0106 ms.
Cleanup ở ngoài action/Stop handler; không đợi proposal hoặc worker.

## Lỗi rotation được tìm thấy và sửa trong C3

Full regression đầu tiên của V2: **1963/1964 PASS, 1FAIL**, ở native writer
rotation test. [Log thất bại](../artifacts/5c3_integration_v2/full_regression.log)
giữ nguyên. Một batch chẩn đoán30 trials tái hiện2 failures: `FileExistsError`,
hai rotations nhận cùng wall-clock `time_ns`; writer viết2/10, báo failed1,
discard7 đúng accounting và degrade AI, không phát input thay thế.

[Diagnosis](../artifacts/5c3_integration_v2/rotation_diagnosis.json).
Fix chỉ trong [AI logger](../../../src/pokiguard_v2/reasoning_diagnostics.py):
stamp lớn hơn previous stamp và mọi tên numeric hiện có, ngay cả khi wall
clock cố định hoặc lùi. Dùng lại danh sách paths đã scan, không thêm reader,
poll, thread/process hoặc IO trên action path. Một integer retained, bounded;
file format/order/retention caps và write/ACK/error handling giữ.

30 native trials với frozen clock và preexisting filename:300/300 writes,
zero loss, đúng retention2 files. Thêm pure backwards/existing-name checks.
Source audit cho phép đúng logger naming change và một audit-test method;
AST phần còn lại của logger/controller integration, queue/Stop/cancel giữ.
[Pre-fix source](../artifacts/5c3_rotation_remediation_v1/before.json) archive
byte-for-byte. C3 post-fix resource/CPU/disabled/full regression chạy mới;
không dùng full-suite FAIL như PASS.

V3 full suite đầu sau sửa runtime:1964/1966 PASS,2source-audit FAIL vì new
offline allowlist thiếu builtin `len` dùng để cắt filename. Đây là harness error;
chỉ thêm `len` vào allowlist, không đổi runtime hoặc assertion gameplay. Hai
audit targeted PASS; disabled probe và full suite chạy mới. [Failed suite +raw](../artifacts/5c3_integration_v3/audit_remediation_v1/full_regression.log),
[pre-fix helper/hash](../artifacts/5c3_integration_v3/audit_remediation_v1/before.json).
Runtime soak/sink CPU giữ nguyên vì helper audit không được các phép đó import.

## Latency và giữ nguyên kết quả thất bại

Lần PARTIAL V1 giữ nguyên [report lịch sử](5c3_partial_v1_report.md),
[raw/result](../artifacts/5c3_integration_v1/performance/benchmark.json):
4/12 groups NOT_QUALIFIED. Digest sink/mixed-profile burst không qualify healthy
native integration. Calibration native bổ sung cũng NOT_QUALIFIED: disabled
null-control spike254,3307ms và lỗi fixture Mega loadout; không sửa runtime
theo setup error, không xóa mẫu hoặc retry cùng protocol đến khi đạt.

V2 freeze trước đo: từng profile/config/session hợp lệ; actual native common
append/flush, owned native AI writer, actual manager status callback. Đo full
publication wall time lẫn exclusive wrapper/admission trong **cùng native
write/flush**; giữ mọi raw/native common rows. Gate exclusive mode duration
có cả probe overhead, bảo thủ hơn paired exclusive difference, đồng thời gate
full native quantile differences p50/p95/p99. Numeric targets A3 giữ nguyên;
[protocol](../artifacts/5c3_integration_v3/causal_native_timing/protocol.json)
giải thích hiệu chỉnh phương pháp, giới hạn và trường summary.

| Mode | p95 exclusive added lớn nhất giữa runs | Max exclusive added giữa runs | Gate p95/max |
|---|---:|---:|---:|
| Disabled | 0,0032 ms | 0,1047 ms | 0,50 /5 ms |
| Shadow | 0,0399 ms | 0,2428 ms | 1 /10 ms |
| Degraded sink | 0,0418 ms | 0,5288 ms | 1 /10 ms |
| Stopped adapter | 0,0075 ms | 1,6431 ms | 1 /10 ms |

Mọi family stratum cũng đạt, không pool để che fail. Raw full-native maxima
giữ riêng: có mode-stopped write2000,8477ms và control195,5138ms; **không có
bảo đảm disk/scheduler max latency** và không gán các unmatched IO stalls
thành causal AI overhead. PASS ở đây là added software-path qualification,
không tuyên bố mọi action/game wall time dưới10ms hoặc đã tìm ra nguyên nhân
native stalls. Không sửa accepted gameplay writer. V3 mang tiếp raw V2 qua source compatibility:
codec/admission/Stop và toàn benchmark AST giữ, chỉ filename của off-path AI
writer được sửa. New resource/CPU/rotation tests xác minh corrected writer;
đây là reuse, không phải một lượt timing mới. Burst loss có counters;
không dùng nó làm healthy zero-loss proof.

[Summary](../artifacts/5c3_integration_v3/causal_native_timing/benchmark.json),
[raw](../artifacts/5c3_integration_v3/causal_native_timing/raw.jsonl).
Hai profile SIMPLE/CAREFUL có SWAP; bốn fixtures khác NONE. Non-SWAP thiếu
exact identity tiếp tục UNSUPPORTED/retain; Bú win không tạo adapter.
Không mở selection/card/QTE support từ các mẫu NONE.

## Resources và diagnostics sink

Healthy stream dùng real BASIC policy/analysis và source đổi mỗi2s, actual
session/observer/R1/native AI writer/status, native common log. 915
jobs gồm warmup; 900 cadence slots trong measurement30min. Đây là published
event simulation, không phải 915 lượt game hay full-controller
ACK; positive controller ACK đã kiểm riêng ở trên.

| Chỉ số | Đo được | Gate |
|---|---:|---:|
| Main CPU, absolute upper bound added | 0,7129 host pp | ≤5 |
| Whole main + all known children CPU | 3,2631 host pp | Descriptive, includes compute/startup |
| Main added private bytes | 5,5938 MiB | ≤32 |
| Total added private bytes | 65,5156 MiB | ≤256 |
| Queue peak | 0,0793 MiB | ≤8 |
| Last5min−first5min median growth | 2,0703 MiB | ≤8 |
| Disabled own CPU upper bound | 0,7465 host pp | ≤1 |
| Disabled added private bytes | 1,0078 MiB | ≤8 |
| Separate−shared total CPU, 3 runs | -0,1069 /0,0770 /0,5542 host pp | ≤1 mỗi run |

Resource sampling chỉ own/known helper PIDs, host normalization12 CPUs, private
bytes proxy như B4; retained query handles lấy final full lifetime child CPU
sau reap. V3 lấy PID writer sau lazy-launch, mọi children CPU được capture. Thiếu sót
metadata None của V2 được giữ trong raw cũ; không dùng bound thiếu writer.
First/last windows đủ5min, không bỏ stalls. 3050 durable
AI records có sequence liên tục, đủ mọi dispatch/outcome và final run summary;
zero eligible critical drop/fail/discard. Tất cả compute/logger processes reaped.

CPU comparison có actual native common path/real planner ở hai arm và **C1
shared B4-writer emulation**, không phải production shared writer đã triển khai.
Tính toàn CPU children gồm compute/startup, không giả paired delta bằng cách
trừ compute khỏi một arm. Original C1 capped-sink proof và B4 saturated failure
vẫn giữ đúng scope. Separate admission còn có conservative all-shadow cost
bound dưới stricter separate-vs-shared thresholds.

Quyết định: giữ native separate diagnostics hiện tại, đúng hard caps1job/s,
8events/128KiB mỗi1s window. Healthy integration đã đo ở cadence0,5job/s;
không mở sustained overload/live qualification. Không đổi common writer,
không thêm monitoring loop vào runtime. Disabled fresh probe không import
reasoning và không tạo AI threads/jobs/queues/files/extra reads/captures.

[Resources](../artifacts/5c3_integration_v3/resource_soak/resources.json),
[disabled](../artifacts/5c3_integration_v3/disabled_resources/result.json),
[paired sink CPU](../artifacts/5c3_integration_v3/paired_sink_cpu/result.json).

## Remaining capability và handoff

Shadow không đợi compute trước input;4s chỉ là processing cap, không phải game
input reserve. SWAP final direct preflight giữ predicate accepted
`remaining < minimum_action_time` → reject; displayed1s hợp lệ với default
floor1s. Actual source age/U/R/M và input tail calibration vẫn UNKNOWN; C4
phải retain BASIC khi thiếu chứng cứ, không lấy offline timing để tự mở input.
Non-SWAP identity/continuation/QTE/lease giữ owner cũ; R2, actual damage/refill/
boss models và efficacy không được promote.

Final source fingerprint256Python files (248existing byte-preserved,2documented changes,6new offline files):
`9b2ee0991820000ddcbc3c670e790f5d54f37f3397ef4d419fe16621aefd17c7`.
[Source manifest](../artifacts/5c3_integration_v3/source_manifest.json).
Historical V1/V2 artifacts và failed regression giữ nguyên; document hashes V1 mô tả lần
PARTIAL cũ, report tương ứng archive byte-for-byte. V2 historical manifest giữ failed run/diagnosis; V3 manifest ghi hashes cuối.
Unrelated preexisting dirty work giữ nguyên; không giả worktree clean.

Live runbook vẫn [PENDING](../research/5c3_measurement_return_plan.md):
cap6 all-attempts,3 BASIC OFF +3 SHADOW, chỉ khi người dùng kích hoạt và game
sẵn. Actual memory/capture/QTE/lease/navigation/re-entry/live Stop/overhead
NOT_OBSERVED; không tự chạy game hoặc inject fault live. C3 live closure
bắt buộc trước D1.

Exactly one next: **[5C.4 — offline only](../prompts/5C4_GUARDED_SELECTION_AND_EXISTING_PREFLIGHT.md)**,
SELECTED/NOT_EXECUTED. **STOP5C.3 PASS_OFFLINE_LIVE_PENDING**.
Bú win giữ nhánh phụ khi người dùng báo test. Không build/version/Git mutation.
