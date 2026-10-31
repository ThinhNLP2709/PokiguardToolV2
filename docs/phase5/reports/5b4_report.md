# 5B.4 report — Isolated runner và bounded diagnostics

Ngày 2026-10-10 (Asia/Saigon).

```text
PROJECT: PokiguardToolV2
STEP / PARENT / MODE: 5B.4 / 5B.3 / OFFLINE ONLY
RESULT: PASS STRONG — OFFLINE ISOLATION/DIAGNOSTICS COMPONENT ONLY
EFFICACY VERDICT: NOT_APPLICABLE / NOT_MEASURED
SOURCE: v1.2.5 existing worktree; historical Phase5 baseline v1.2.4
HEAD: c646acfa5e895732bbdade553f9d7bd61171cd29
BRANCH: codex/phase3a2-board-repair
R2 GAME PROMOTION: DISABLED
PRODUCTION WIRING / GAME ATTACH / INPUT / BUILD: NOT_RUN
COMMIT / PUSH / TAG / VERSION / RELEASE: NONE
NEXT: 5C.1 SHADOW ADAPTER — SELECTED, NOT_EXECUTED
STOP: 5B.4
```

## Entry và deliverables

User yêu cầu quay lại luồng chính Phase5 và tiếp tục sau [B3](5b3_report.md).
Bú win chỉ giữ note nhánh phụ xử lý khi user báo test; không dùng lịch sử lỗi
nhánh phụ để mở rộng scope B4. Đã đọc AGENTS, status/router/contract, A0 research,
A3 spec, capability manifest, B3 implementation và prompt B4.

Thêm7 Python files: `reasoning_runner.py`, `reasoning_diagnostics.py`,
`test_reasoning_runner.py`, `reasoning_worker_fixtures.py`,
`evaluate_reasoning_runner.py`, `evaluate_reasoning_log_cpu.py`,
`verify_reasoning_runner.py`. Không sửa existing Python source/dependencies;
preservation audit235files ghi tại final verification. Spec:
[isolation/logging/SLO](../specs/5b4_isolation_logging_and_slo.md).

Process per job, immutable binding, latest pending, absolute deadline, stale/
late discard, breaker, nonwaiting baseline disposition và Stop. Worker và log
writer đều có cleanup ngoài host action path. Diagnostic events bounded, first
stack/repeat aggregation, quiescent loss accounting và compact candidate attribution.

## Baseline, scope và limitations

Production BASIC/runtime/provider/capture/executor/QTE/ACK/lifecycle **chưa nối
component mới**. Existing source preserved; no new game read/capture/input.
Đây là structural/offline preservation, chưa production parity hoặc live safety.
User worktree v1.2.5 được giữ; không reset vềv1.2.4 và không build release khác.

R1 one-step planner giữ B2 semantics và cài đặt advisory. B3 optional structural
analysis không promote R2; returned completed R1. Invalid state/source/clock,
Stop hoặc after-input trả NONE. Valid current baseline fallback trước dispatch
không chờ worker/log. C4 vẫn phải validate foreground/turn/cost/source/reserve
và qua existing preflight; B4 không có input authority để bypass chúng.

Actual boss choice/refill/damage/survival, same-burst effect order, account
calibration và runtime reserve chưa validated. Process/soak fixture là synthetic
SIMPLE/reference board, không đại diện mọi profile/board/loadout/game build.
Focused planner/refinement regressions rộng hơn nhưng vẫn offline. Chưa claim
fix Shield loop, thắng boss tốt hơn, energy saving hoặc hiệu quả trong game.

## Diagnostics và backend

Chọn **SHARED_NAMESPACE_FILTER** cho hướng integration; emulation không chứng
minh accepted gameplay writer đã hỗ trợ. Separate CPU qualification v2 có run
exceed1pp; không retry để promote separate. Decision summary chỉ baseline/
proposal/top alternatives, không full graph. Controller dispatched action
NOT_PUBLISHED, worker input false; không gán chosen outcome giả.

Queue512/8MiB, priority reserve32/1MiB, event16/32KiB, rotation10MiB×10files/7days,
64error signatures, repeat summary1/30s, health1/5s; bounds gồm writer in-flight.
Failed/drop/discard không được gọi written. First stack có job/source/config
correlation; memory counters giữ được khi sink lỗi. Stop không drain; run summary
best effort ngoài Stop. Default shared integration/retention cần prove C1/C3.

## Evidence và verdict

- **141/141 focused tests PASS**,46.302s: B1/B2/B3/B4 + board simulator/Demon
  primitives, gồm27runner/diagnostic tests. Log `temp/5b4_final_focused_tests.log`.
- Final block: [protocol](../artifacts/5b4_isolation_v4/protocol.json).
- [Performance](../artifacts/5b4_isolation_v4/performance/benchmark.json),
  [boundary](../artifacts/5b4_isolation_v4/boundaries/boundary.json),
  [faults](../artifacts/5b4_isolation_v4/faults/faults.json),
  [CPU](../artifacts/5b4_isolation_v4/log_cpu/cpu.json),
  [resources](../artifacts/5b4_isolation_v4/resources/soak.json),
  [verification](../artifacts/5b4_isolation_v4/verification.json).
- **68/68 required verification gates PASS**, artifact/log integrity PASS.
  Separate qualification FAIL CPU được giữ rõ; shared policy là nhánh hợp lệ A3.
- v1 clock invalid, v2 telemetry source superseded, v3 observer retained-history
  superseded; raw/calibration reasons giữ riêng, không dùng làm final acceptance.

### Timings và fault boundaries đã đo

Milliseconds, mỗi cell là giá trị lớn nhất của cùng quantile qua3runs riêng;
không pool để che run fail. Mỗi mode30,000 measured +3,000 warmup, raw riêng.
Control/mode interleaved, paired per-observation delta trong raw artifacts.

| Stage | p50 | p95 | p99 | max |
|---|---:|---:|---:|---:|
| Disabled factory/branch | 0.0003 | 0.0004 | 0.0004 | 0.0986 |
| Prepared submit | 0.0008 | 0.0027 | 0.0048 | 0.0719 |
| Shared enqueue (stress) | 0.0012 | 0.0023 | 0.0048 | 0.2512 |
| Separate enqueue (stress) | 0.0012 | 0.0023 | 0.0029 | 0.1006 |
| Lock-busy enqueue | 0.0006 | 0.0010 | 0.0022 | 0.0987 |
| Queue-full enqueue | 0.0012 | 0.0026 | 0.0030 | 0.0862 |
| Wire reply validation | 0.5757 | 0.9406 | 1.2427 | 11.6894 |
| Ready advisory selection | 0.0023 | 0.0032 | 0.0051 | 0.2064 |
| Known-fault disposition | 0.0022 | 0.0032 | 0.0036 | 0.3359 |
| Idempotent Stop signal | 0.0015 | 0.0025 | 0.0035 | 5.4379 |

Job preparation riêng N11,000/run: p50≤0.9652ms,p99≤1.8442ms,max12.6438ms;
không nằm trong prepared-submit timing và chưa prove full shadow hot path.
Max này lớn hơn shadow-path10ms target nếu đưa preparation inline. C1 phải giữ
build/hash/serialization khỏi đường action đang chạy và C3 đo full copy/admission
path; không lấy prepared-submit microbenchmark để bỏ qua gate đó.
Preparation raw không instrument riêng; quantiles descriptive, không integration gate.
30real R1 jobs: compute median33.7231ms,max42.7231ms; pipeline median421.6899ms,
max470.5885ms, raw serialization/spawn/startup/compute/IPC/validation giữ riêng.
Arrival-to-validation stage còn gồm supervisor scheduling; không xem như pure
wire-validator cost hoặc actual action preflight. Workload jobs dùng synthetic5s
deadline (hang/cooperative fault350ms), không thay configured default4s/cap6s A3.

490trials:270worker (30positive retain +240fault),100Stop (20kèm logfull/hung
writer),120disk fault. Tất cả applicable before-input giữ valid baseline,
after-input/source-invalid→NONE; children/IPC readers reaped. Fault disposition
N270 p50/p95/p99/max0.0236/0.0378/0.0850/0.1403ms. Stop signal N220 (100runner,
120writer):0.0111/0.0213/0.0250/0.0261ms. Cleanup N390:
14.6614/112.1041/114.1989/114.4066ms; ngoài action/Stop path.
30/30cooperative cases exited trong100ms join grace; max observed cleanup56.0503ms.
Đây không phải cancellation/QTE/ACK timing của game.

CPU probe3×10s/mode (emulated synthetic pairs): separate−shared hostCPU pp
**+1.197217 / −0.715130 / +0.505598**. Run0 fail ngưỡng+1pp, nên separate không
qualified; giữ shared. Các stress stream có accounted drops, không gọi healthy.
Default shared/production backend connection và real shadow parity vẫn pendingC1/C3.

Các stage SLO trên đạt trong phạm vi đo; resource/source verification đã đóng.
Analysis tool sửa control của disabled-memory probe sang accepted
BasicPolicy và đọc preservation map từ artifact; timing producers/core không đổi.
Fresh bare-Python import cost9.637MiB ghi descriptive, không paired BASIC delta;
ngưỡng8MiB giữ nguyên. Source/clock calibration failures không bị xóa hoặc trộn.

Environment: Python3.11.9/Windows26300, Ryzen5 4600HS,12logical CPUs; power plan
High performance được ghi giữa resource run. Background load không controlled;
không có retroactive proof power/load cố định. Raw stalls giữ nguyên, stage
gates là empirical trên declared host/workload; không chứng nhận máy khác.

### Resource closure và fingerprints

30min thực tế **1800.024s**,900synthetic jobs,900completed/900processes reaped;
fault/late/rejected/stale/logdrop đều0. First/last5min windows150rows mỗi cửa sổ.
Main added private memory peak**3.148MiB** (cap32), sampled total added**41.293MiB**
(cap256), retained growth**1.309MiB** (cap8). Queue high**2records/10,422bytes**
(cap512/8MiB). Main absolute hostCPU**0.1453%**, conservative upper bound below5pp;
không paired production overhead. Disabled BASIC-control added private memory
**3.004MiB** (cap8), zero AI worker/queue/planner/model import.

Final accounting: eligible=enqueued=written=**1200**; dropped/failed/discarded/
queued/in-writer=0. Persisted lines đối chiếu đúng900decision+299health+1run_summary,
event_seq1..1200 không gaps/duplicates; no input authority. `disabled/CLOSED`
trong final logger stats là normal shutdown, không write fault.
Runner/logger cleanup và final offline flush đềuPASS. Không drain trong Stop.

[Source manifest](../artifacts/5b4_isolation_v4/source_manifest.json),
[integrity](../artifacts/5b4_isolation_v4/integrity.json),
[artifact manifest](../artifacts/5b4_isolation_v4/manifest.json).
235preexisting Python files preserved;7new deliverable Python files.
New-component fingerprint:
`4985745da760505868a1efcf2ca0fa84b75ca76637de6be5173ab866a9064c40`.
242-file Python worktree fingerprint:
`d33d8bcf16a27f95db2916b8b69097df23490b233c09cff345d7b1fcedd2e49e`.
Full before hashes và current new hashes trong artifact để audit lại, không chỉ HEAD.

## Gate closure

| Gate B4 | Verdict / evidence |
|---|---|
| Isolated immutable/no-authority worker; latest/cancel/stale/late/breaker | PASS —27component tests +490trials, source/job bindings |
| Known fault/Stop không chờ compute/log/cleanup | PASS OFFLINE — raw boundary/fault tails; existing controller chưa integration |
| Bounded logs/loss accounting/retention/first stack | PASS OFFLINE — tests, normal1200/1200 + stress/fault accounting |
| Backend/runner selection và measured SLO | PASS COMPONENT —process isolation/shared policy; separate CPU FAIL qualification |
| Resource30min/memory/growth/disabled | PASS —900jobs, caps và integrity |
| Existing Python source preservation/no production wiring/input | PASS —235file audit, disabled import probe, code boundaries |
| Actual timer/family reserves/preflight/flow parity/efficacy/frozen package | OUT_OF_SCOPE/PENDING —C1–C4/D/E/F gates, không dùng B4 để claim |

Không commit/push/tag/version bump/build/release. Source hiệnv1.2.5 giữ nguyên.

## Router

Current **5B.4 PASS STRONG (OFFLINE COMPONENT)**. Chọn đúng
[5C.1](../prompts/5C1_SHADOW_DECISION_SEAM_ADAPTER.md) làm next prompt rồi **STOP**.
5C.1 chưa thực hiện; chỉ mở khi user yêu cầu tiếp tục. Disabled mặc định, BASIC
vẫn chọn/phát input; không đưa preparation inline hoặc mở R2/actual override.
