# 5B.4 — Offline isolation, diagnostics và SLO manifest

Ngày 2026-10-10. Parent: [5B.3](../reports/5b3_report.md).
Contract: [A3](5a3_telemetry_deadline_acceptance.md).
Đây là component offline; không kích hoạt REASONING trong tool.
Kết quả acceptance và số đo cuối: [B4 report](../reports/5b4_report.md),
[verification](../artifacts/5b4_isolation_v4/verification.json).

## Boundary và ownership

Chọn một disposable **spawn process/job**. Supervisor thread sở hữu serialize,
spawn, IPC và cleanup; worker treo bị terminate/reap ngoài đường action/Stop.
Thread compute thuần Python không có hard cancellation tương đương. Đổi lại,
spawn/import có overhead rõ rệt, được đo riêng; không xem compute median là
end-to-end latency. Đây là isolation lỗi, không phải OS security sandbox.

`create_runner(enabled=False)` không tạo runner/thread/queue/process hoặc import
snapshot/planner/refinement. B4 chưa thêm bất kỳ import nào vào production.
Worker nhận JSON snapshot bất biến, không nhận provider, capture, memory/game
process handle, input/foreground/executor/ACK/QTE owner. Authority luôn false.

| Boundary | Contract |
|---|---|
| Preparation | `make_job` hash/bind snapshot ngoài hot path; cost ghi riêng, không giấu vào enqueue |
| Submit | try-lock; 1 active + 1 latest pending; pending cũ bị thay; không FIFO/unbounded retry |
| Identity | job ID/generation + snapshot/config hash + exact source/profile + clock domain |
| Deadline | Host absolute `perf_counter_ns`; child không có authority gia hạn; host kiểm sau validate |
| Cancel | invalidate/Stop chỉ set Event; supervisor cancel/terminate/reap; stale result không usable |
| Selection | Advisory only; caller vẫn phải qua existing fresh-state/action preflight ở C4 |
| Invalid state/source/clock | NONE; không blind fallback cached BASIC |
| Before-input known fault/timeout | Valid bound BASIC sẵn; caller không chờ cleanup hoặc disk |
| After-input/Stop | NONE; không proposal thay thế, không retry input, không đổi pending/ACK owner |
| Breaker | 3 consecutive faults hoặc 5/rolling20; persistent known log failure disable ngay; không auto re-enable |

Caller phải giữ original decision-slice deadline khi chuẩn bị/thay job. Runner
không tự resubmit/reset deadline. New source/config/turn phải invalidate hoặc
replace job và cung cấp current binding đúng. B4 chưa prove integration ownership.

## Schema và diagnostics

Job `pokiguard.reasoning.job.v1`, reply `pokiguard.reasoning.reply.v2`, event
`pokiguard.reasoning.runner_event.v1`. B1 replay/event codec được giữ nguyên;
runner events không tự nhận là dataset/action-outcome labels của B1.

Compact decision ghi baseline/proposal action và candidate IDs, tối đa baseline
+ proposal + 3 alternatives (dedup, hard limit6), utility bounds/components,
known ledger digest/totals/dedup cells, resource points, scoped certificate,
boss proxy coverage, source/provenance/config/version, job generation và timing.
Verbose graph không được enqueue. Nếu event quá lớn có explicit truncation
digest/count, không cắt JSON thành record hỏng. Unsupported damage/survival và
future setup ghi rõ; summary R1 không giả có actual boss/refill hoặc R2 result.

`worker_input_sent=false`, `controller_input_sent=NOT_PUBLISHED`, dispatched ID
null. B4 không biết action của production controller, không ghi false outcome
hoặc tự gán selected/dispatched candidate. Dispatch/preflight/ACK/QTE timing
NOT_MEASURED; những event đó cần owner instrumentation ở C1–C4.

Health tối đa 1/5s khi có job. First error có stack/correlation; 64 signatures
max, repeats count/first/last và tối đa1 summary/signature/30s, overflow aggregate.
Run summary best-effort trong supervisor sau Stop; caller không drain. Cleanup
offline có thể flush để kiểm accounting, không đưa flush vào action/Stop path.

| Allocation | Hard/default bound |
|---|---|
| Queue | 512 records / 8MiB, tính cả in-flight writer record |
| Reserve | 32 records / 1MiB cho error/health; đầy vẫn drop+counter |
| Record | decision16KiB, other/first error32KiB |
| Cardinality | single supervisor producer, single writer; second producer unsupported/rejected |
| Retention | 10MiB/file, tối đa10files/7days; dedicated own stem/allocation |
| Fault policy | No retry storm; counters trong RAM khi sink hỏng; AI degrade, không block BASIC |

Disk process ACK sau complete JSON-line write; `written` không hứa fsync/power-loss
durability. Eligible/enqueued/dropped/written/failed/discarded là disjoint counters;
quiescent watermark kiểm invariants A3. Stop có thể discard chưa ACK, không claim
written. Writer treo không giữ action; buffer bounded, pressure có drop/degrade,
Stop kill/reap writer. Không tự đoán ACK thành công khi process chưa trả lời.

**Policy chọn shared namespace/filter**. Separate CPU qualification đã fail một
lượt trong calibration v2; không retry để promote separate. Các số đo shared/
separate là emulated off-path backend, chưa accepted gameplay-writer integration.
C1/C3 phải prove bounded AI allocation và overhead trên backend thật. Không sửa
rotation/log gameplay để ép shared support; không đủ thì giữ BASIC và disable AI.

## Deadline và family manifest

Formula A3 giữ nguyên: default4000ms, cap6000ms từ original slice, source-age
đúng một lần, uncertainty150ms và return margin100ms là proposed minima;
minimum available50ms. Pure tests chứng minh arithmetic, không game timer proof.
Clock calibration dùng QueryPerformanceCounter (`perf_counter_ns`, resolution
0.0001ms trên máy đo); Windows `monotonic_ns`/GetTickCount64 có15.625ms resolution
không được dùng để đo micro tails ở environment này.

| Family | Existing source evidence | Chưa map/calibrate | Override activation |
|---|---|---|---|
| SWAP | BasicPolicy default floor3s, reject `<floor` (inclusive); memory timer source `MatchService.server_tick` | observation age/uncertainty bound, preflight/input boundary và p99 reserve | DISABLED |
| CAST / PET_SKILL | Worker schema supports action family; baseline/effect ownership giữ nguyên | source/cost/order/QTE/reserve by family | DISABLED |
| EVOLVE / PASS / continuation / technical | Không mở generic proposal family ở B4 | existing ownership và continuation gates cần C1/C4 mapping | DISABLED |

BasicPolicy còn Evolution-specific floor; floor3s không đại diện mọi action
hoặc executor preflight. Không thay floor, strictness, pacing, read/capture order.
R_family = max(existing gate, proposed floor, measured p99 duration+250ms) chưa
có actual measurement; thiếu essential timing evidence thì không reasoning override.

Spawn cost khiến available50ms thường không đủ cho process planner; đây là
arithmetic lower bound, không latency promise. C1/C3 admission cần bỏ job không
đủ measured budget thay vì thử rồi miss accepted action window. Deadline/fallback
không được nới theo chi phí process. Packaged/frozen spawn chưa được kiểm ở B4.

## Measurement scope và gates

Final protocol [v4](../artifacts/5b4_isolation_v4/protocol.json) giữ numeric gates
A3, 3×10,000 measured +1,000 warmup/run, raw tails và OS stalls giữ nguyên.
Prepared submit, wire validation và ready advisory selection là các stage riêng,
không gọi micro timings là shadow/action parity. Real R1 process timings N30
chỉ descriptive. Faults490 trials gồm100Stop trials; normal stream30min mỗi2s
một synthetic SIMPLE job. Không phải900 trận hoặc900 independent win samples.

Resource observer chỉ query own/known child PIDs. Raw rows stream ra file;
comparison windows bounded để observer không tự tạo retained growth. Main CPU
absolute trên total-host normalization là conservative upper bound added CPU;
không paired production delta. Private bytes là committed private-memory proxy,
total sampled peak có20ms sampling blind spots; queue/count/bytes enforced bằng
code và tests. Không thêm production monitor đọc game.

Disabled/main/total/queue/growth caps giữ8/32/256/8/8MiB.
Disabled memory đối chiếu fresh process đã import accepted BasicPolicy, đúng
control BASIC của A3. Bare Python→AI import đo sơ bộ9.637MiB gồm standard-library
startup không phải paired BASIC delta; giữ observation này, không dùng làm gate.
Không đổi ngưỡng8MiB. Fresh BASIC-control probe khoảng2.832MiB ở preliminary run;
final value nằm trong verification.
Healthy declared workload zero dropped/failed/discarded; overload riêng có accounting. Hang cleanup<=1000ms
ngoài Stop, Stop handler<=25ms; không claim universal OS scheduling guarantee.
Cooperative join grace100ms và actual reaped status được ghi; API Stop không
chờ ACK. Live dispatch timing/superiority/energy/input safety vẫn PENDING C3–E.

Calibration v1 invalid clock, v2 source superseded, v3 observer superseded được
giữ riêng cùng reasons; không trộn số liệu vào final acceptance. Source hashes,
235-file preservation audit và frozen scope ở verification/manifest.
