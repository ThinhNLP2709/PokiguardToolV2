# 5A.3 — Telemetry, deadline và acceptance kỹ thuật

Ngày: **2026-10-09 (Asia/Saigon)**. Mode: **DOCS ONLY**.

Đặc tả semantic v1 cho triển khai sau; chưa là DTO/API/runtime implementation.
Các giá trị số ở đây là **PROPOSED**, không phải latency/baseline đã đo.
B4 calibrate offline, C3 chứng minh integration/flow trước live, F1 đo artifact
thật. Thay đổi mục tiêu cần version và lý do trước batch mới; không nới sau
kết quả để biến FAIL thành PASS.

Đọc cùng [A1 contract](5a1_baseline_reasoning_contract.md),
[A2 features/utility](5a2_features_utility_and_profiles.md),
[A2 cases](5a2_scenario_matrix.md) và [bounded live protocol](5a3_bounded_live_protocols.md).
BASIC v1.2.4, provider/capture/executor/QTE/ACK/lifecycle/Stop giữ nguyên.
Tài liệu không kích hoạt code, game attach hoặc live.

## 1. Ownership và mode

| Mode / boundary | Quyền và hành vi |
|---|---|
| BASIC / reasoning disabled | Không tạo worker/job/queue AI, không import model nặng; accepted BASIC quyết định và hành động |
| Shadow | Copy state đã published, submit không chờ; BASIC dispatch theo flow cũ, kết quả chỉ diagnostics |
| Experimental selection | Theo amendment contract2026-10-12: BASIC trước, bounded interruptible decision wait trên cùng data/incumbent; proposal đủ evidence/deadline hoặc fallback; không thêm game poll/read/capture |
| Trước physical input | Baseline phải còn hợp lệ tại existing preflight; source đổi thì dùng controller flow cũ, không blind dispatch |
| Sau physical input | Pending action/ACK/QTE/recovery owner hiện có; AI/log lỗi không phát input thay thế |
| Stop / emergency / source change | Existing authority thắng; cancel/ignore job, không await worker hoặc log drain trên input/Stop path |

Chỉ root action được đề xuất; predicted boss/own followup không phải input
script. Existing mandatory action, PASS legality, actual skill cost/source và
continuation ownership thắng ranking. Không tự đổi PlayStyle/settings.

## 2. Common event envelope

Schema dự kiến: `pokiguard.reasoning.event.v1`. Mỗi field thiếu ghi availability
và reason; không dùng 0/empty giả làm observation. Event name dưới đây là tên
semantic, B1 map theo conventions repo và giữ mapping/version.

| Nhóm | Fields / semantics bắt buộc |
|---|---|
| Identity | event_id, event_type, schema_version, producer, event_seq; run_id, session_id, match_id, local_actor_id nếu published |
| Source | source_turn, srv_seq nếu có, board_hash, snapshot_id/hash, controller_generation; không tái dùng across match |
| Job | job_id, job_generation, mode, job_state; null có reason khi BASIC không tạo job |
| Action | baseline_candidate_id, proposal_candidate_id, selected_candidate_id; dispatched_action_id chỉ gắn khi executor cũ tạo thật; action_family, canonical coordinates theo A2 |
| Versions | source HEAD + worktree/source fingerprint, artifact hash nếu có, game-build provenance, PlayStyle/config hash, feature/utility/model/calibration versions |
| Time | UTC để tìm log; monotonic domain_id, ticks/frequency hoặc integer microseconds cho duration, observation/job/decision/input boundaries |
| Evidence | availability/origin/support/scope/source_ref/assumptions/dependencies/bound semantics theo A2; observed và predicted tách field |
| Cohort | batch_id, arm, assignment_block_id, attempt_id, loadout/operator scope label và identity_binding_strength |
| Outcome | disposition, reason_code, input_sent status, existing preflight result; outcome attribution chỉ chosen/dispatched action |

Không trừ UTC hoặc clock worker độc lập để suy duration. Host là authority cho
deadline; worker nhận duration budget + host deadline token. Nếu worker dùng
clock riêng thì log compute duration của nó và host receive time riêng, không
tự coi timestamps hai process đã đồng bộ. Clock reset/generation mismatch làm
job invalid. Source timer cần timestamp/provenance tương ứng, không dùng thời
điểm serialize để làm observation mới hơn.

## 3. Event catalog và bounded payload

| Event | Nội dung tối thiểu |
|---|---|
| reasoning.job | created/submitted/started/cancelled/finished/late/discarded, source và deadline; roots/scenarios planned vs completed |
| reasoning.decision | baseline/proposal/selected, semantic USE_CANDIDATE/RETAIN_BASELINE, score breakdown/margin/evidence rank, override reason hoặc retain reason |
| reasoning.fallback | reason, stage, source validity, existing preflight disposition; fallback không phải PASS mới |
| reasoning.error | fault signature, first/last occurrence, bounded first exception/stack, job/source/stage; repeat count |
| reasoning.health | queue/bytes/writer/worker/breaker status, lifecycle/counters, timing summary; định kỳ từ scheduler/writer hiện có |
| reasoning.observation_link | link root đã gửi tới fresh published turn/result sau đó; observed progress/outcome, missing attribution, không gán cho alternative |
| reasoning.run_summary | caps/attempts/status/counters/config/version/sink, dropped data intervals và incomplete shutdown |

Một decision summary chứa tối đa baseline + proposed winner + selected (dedup
ID) + 3 alternatives, tối đa 6 candidate summaries. Mỗi candidate summary:
- physical cells removed, effective units và Rage/Mana point gain riêng; x1
  Rage20/Mana30 có calibration ID/support, caps/actual deficit/required costs;
- known removal ledger digest, dedup count, UNKNOWN exposure; không dump tree;
- utility components/normalization/weight version, nominal score, examined
  stress minimum/fragility, evidence rank, comparator bucket và decision gap;
- nominal boss reply count, max-Sword tie total/examined, completeness và
  unsupported special/PASS/refill branches; ties chưa xét không ghi covered;
- setup before root, forecast pre-boss, predicted post-boss accessible setup
  range, own legal followup, contested loss; observed next-turn setup riêng;
- bait offered Sword/threat/HP evidence/downside, reason chọn hoặc bác bỏ;
- calibration scope/binding/effect-order dependencies; same-burst order
  UNKNOWN không biến thành fact Rage được áp dụng trước passive damage.

Thời gian: snapshot age, baseline duration, copy/enqueue/serialize/IPC,
worker compute, host validation/preflight, dispatch duration và ACK/QTE latency
riêng. Stage chưa instrument được ghi NOT_MEASURED, không gộp ACK thành compute.

Full immutable snapshot chỉ dedup bằng snapshot_id/hash và export theo dataset
manifest từ state đã có; mặc định OFF trong production. Không thêm ảnh, raw
pointer dump, provider read hoặc synchronous snapshot serialization. B1 dùng
offline file; future production capture/export chỉ khi overhead C3 đã prove.

## 4. Accounting, queue và retention

### 4.1 Counters

Bộ đếm monotonic trong run, giữ được trong memory khi sink hỏng:
- eligible: logical events qua sampling policy; sampled_out đếm riêng;
- enqueued / dropped_before_enqueue (full, lock_busy, oversize, sink_disabled);
- written: writer đã write thành công record hoàn chỉnh, không có nghĩa fsync
  bền sau power loss; failed_write và discarded_after_enqueue riêng;
- aggregated_occurrences: lỗi lặp đã gộp, không cộng như record được ghi;
- queued và in_writer; event_seq gaps/dropped_intervals khi có thể.

Invariant tại một watermark: eligible = enqueued + dropped_before_enqueue;
enqueued = written + queued + in_writer + failed_write + discarded_after_enqueue.
Lỗi lặp gộp chưa phát record không được giả là written. Health/run_summary ghi
watermark để tránh so counter ở hai thời điểm. Process chết trước flush thì
UNKNOWN phần chưa có persisted evidence, không claim zero loss.

Các terminal categories written/failed_write/discarded là disjoint; record
failed_write không được cộng lại vào discarded. Writer không log lỗi của chính
health/error write bằng recursive events; cập nhật bounded memory counters.

### 4.2 Proposed bounds và sampling

| Hạng mục | PROPOSED default / hard bound |
|---|---|
| Queue AI | 512 records, tổng 8 MiB (đạt bound nào trước thì đầy); enqueue try/nonblocking, không chờ writer/lock |
| Payload | 16 KiB/decision; 32 KiB/first error; 32 KiB/event hard cap; truncate có flag, không cắt JSON thành record hỏng |
| Priority | Chừa trong bounds 32 records / 1 MiB cho fault/health; đầy thì vẫn drop+counter, không synchronous write cứu record |
| Decision sampling | compact decision/fallback/override 100% cố gắng enqueue; không bảo đảm written khi đầy; verbose trace OFF |
| Repeated fault | signature = stage + exception type + normalized top frame/reason + schema version; first stack 1/signature/run |
| Fault cardinality | Tối đa 64 signatures/run; phần khác vào OVERFLOW aggregate bounded |
| Repeat summary | Tối đa 1/signature/30s; first/last/count. Final flush best-effort ngoài Stop path |
| Health | Tối đa 1/5s khi reasoning active, piggyback scheduler/writer; không timer thread/poll loop quan sát game |
| Rotation | 10 MiB/file, tối đa 10 files và 7 ngày cho AI diagnostic allocation; prune bởi writer trước write, không trên action thread |
| Disk/log failure | Ngừng sink lỗi trong run, status+counter memory; không tạo retry storm hoặc vô hạn folder fallback |

Nếu shared sink có rotation accepted khác, không sửa retention log gameplay:
AI chỉ có allocation/filter/export riêng, drop AI khi vượt quota. Nếu không thể
bound mà không đổi gameplay writer thì AI sink chưa supported, baseline vẫn chạy.
Export do người dùng/offline yêu cầu không nhân đôi full trace mỗi action.

Ưu tiên view/filter riêng. **Default thiết kế là shared namespace** qua bounded
buffer accepted nếu B4 xác nhận đáp ứng; chưa xác nhận thì diagnostic backend
UNSELECTED. Separate sink chỉ chọn khi đạt cả SLO tổng lẫn delta ở mục6. Lỗi
queue/sink biết trước dispatch → retain valid BASIC và degrade/breaker; sau
dispatch → chỉ degrade cho quyết định sau. Không chờ log commit để gửi input.

## 5. Deadline tuyệt đối và reserves

### 5.1 Formula

Dùng host monotonic milliseconds; mọi duration không âm, hữu hạn và đúng unit.
Ký hiệu:
- t_obs: lúc remaining_ms của snapshot được observed; t0: bắt đầu decision
  slice hiện có; t_now: lúc lập job sau khi baseline đã sẵn;
- T: remaining_ms từ source timer accepted; age = t_now - t_obs;
- U: timer/clock/source uncertainty có bound evidence; proposed minimum150ms;
- R_f: remaining execution reserve của action family f;
- M: host return/validation margin, proposed100ms; không gồm R_f.

```text
D_safe = t_obs + T - U
R_f = max(existing accepted reserve for f,
          proposed floor for f,
          measured p99 preflight-to-required-input duration for f + 250ms)
D_job = min(t0 + configured_budget_ms, t0 + 6000ms,
            D_safe - R_for_planned_families - M)
available_ms = max(0, D_job - t_now)
configured_budget_ms default4000, never above6000
```

R_for_planned_families = max R_f của baseline và các family refinement đang cho
phép. Có thể bỏ family đắt/unsupported trước lập job để dùng SWAP planner;
không tự tăng budget và không bỏ baseline incumbent. R_f ở phép tính là thời
gian còn cần trước boundary mà accepted timer gate bảo vệ, không double-count
compute/IPC/ACK. Final host validator vẫn kiểm candidate-specific reserve và
existing preflight. Actual gate chặt hơn thắng, không nới nó theo công thức này.

Budget bao gồm copy/submit/IPC/compute/return/validation kể từ t0, không chỉ worker.
Không reset deadline khi resubmit/restart/config change. Job chỉ bắt đầu nếu
available >= proposed50ms và essential timing evidence đủ; thiếu thì BASIC
ngay. Hoàn thành sớm thì trả sớm, không chờ đủ4s. Đến deadline, không lấy partial
tree hoặc proposal vừa hoàn thành nhưng host nhận muộn.

Không dùng t_now + T rồi lại bỏ age; cũng không trừ age hai lần. Ví dụ giả lập:
T=12000ms, age=800, U=150, R=1000, M=100, t_now=t0 → budget4000;
T=2200 cùng điều kiện →150ms; T=2050 →0, BASIC. Đây là formula cases,
chưa test/timer calibration. Observed timestamp thiếu/khác clock/remaining stale
hoặc uncertainty không bound được → bỏ job; existing BASIC gate quyết định.

### 5.2 Family reserve manifest trước live

| Family | PROPOSED floor | Evidence / acceptance cần map |
|---|---:|---|
| Ordinary SWAP / Shield passive SWAP | 1000ms | BASIC docs mô tả action floor1s; final DECISIONS SWAP mô tả strictly above. Không chọn lại inequality ở A3; B4/C3 map predicate/source accepted, dùng gate thực tế |
| Card click-only, gồm Mega accepted skill | 1250ms | Cost/actionability/foreground/current card và ACK owner cũ; chưa có measured tail của scope mới |
| Pet Skill QTE initiation | 1500ms tới required initiation input | QTE có clock/window riêng; không lấy full QTE duration trừ turn timer nếu accepted contract không yêu cầu |
| PASS / technical / EVOLVE-followup | Không mở refinement mới | Giữ baseline/continuation owner; chỉ mở thêm family sau manifest explicit và scoped proof |

Các floor là bảo thủ đề xuất cho reasoning, không sửa floor BASIC.
QTE post-click directions/Space dùng accepted pacing và fresh QTE clock/window,
không planner reserve hoặc sequence mới. Historical50–200ms post-ACK gap không
chứng minh tổng reserve. ACK timeout, Evolution same-turn followup floor và
continuation gate giữ nguyên; không đợi ACK để nhận proposal khác.

B4/C3 manifest phải có family, timer source/clock/boundary/strictness,
accepted gate ref, calibration p50/p95/p99/max/N, U/R/M chosen và artifact/scope.
Tại A3 tất cả numeric tails/strictness mapping là NOT_MEASURED/NOT_MAPPED;
family chưa map → không reasoning override family đó, BASIC vẫn theo gate cũ.

### 5.3 Cancellation và breaker

Proposed runner: 1 active job + 1 latest pending, không FIFO backlog.
New source/generation/Stop/config invalidates cũ; pending thay bằng mới có counter.
Không restart worker trong cùng decision. Stale/late kết quả discard; không
merge partial features từ job khác. R1 chưa chứng minh hard cancellation thì
chọn process boundary có thể terminate; thread chỉ được chọn nếu B4 chứng minh
hang không giữ controller và tài nguyên cleanup bounded.

Breaker PROPOSED: 3 consecutive failed eligible jobs hoặc 5 fault failures
trong rolling20 eligible jobs → disable reasoning phần còn lại run.
Eligible completed valid proposal/valid retain reset consecutive count; disabled/
budget-skip/source superseded không tính thành success hoặc fault. Deadline
timeout, crash/hang/malformed/IPC/log failure là fault; essential UNKNOWN/
unsupported là coverage fallback riêng. Known persistent sink failure hoặc
worker crash không restart được → disable ngay; không đợi đủ threshold.
No automatic cooldown/re-enable trong run; Start run mới chỉ theo opt-in config.
Counters/reason hiển thị qua status hiện có, không modal/pause/recovery.
Threshold là degrade gate, không gameplay hard rule.

## 6. PROPOSED SLO và cách đo

Không giá trị nào dưới đây đã PASS runtime. Microbenchmark median22.901ms một
fixture trong nghiên cứu cũ không thay end-to-end measurement.

### 6.1 Workload và statistics

B4: offline runner/log faults, C3: integration với state/provider/executor fakes
tại boundary hiện có; không attach game để lấy mẫu timing này.
Mỗi mode/control **3 lần × 10.000 decisions**, warmup1.000/lần ghi riêng,
cùng corpus/source/config/hardware/power/load và interleaved order freeze.
Report từng lần và theo family, không pool để che một run FAIL.
10.000/N là số timing observations, không số trận hoặc independent win samples.

Duration dùng monotonic high-resolution, resolution/calibration ghi rõ;
target resolution <=0,05ms, không đạt → các delta nhỏ INCONCLUSIVE.
Quantiles empirical nearest-rank p50/p95/p99 và max (max không gọi p100 bound).
Đo baseline control và mode cùng workload; report raw distributions, delta
quantile Q_mode-Q_control và paired per-input difference khi thực sự paired
offline. Max delta dùng max paired positive overhead, kèm raw max cả hai.
OS stalls không bỏ tùy ý; nếu host invalid thì invalidate cả predeclared block,
giữ evidence và không lặp vô hạn để PASS.

| SLO so control BASIC accepted | p50 | p95 | p99 | Max / thêm điều kiện |
|---|---:|---:|---:|---|
| Disabled added decision critical path | <=0,10ms | <=0,50ms | <=1ms | paired added <=5ms; zero AI worker/job/read/capture |
| Shadow added action critical path | <=0,50ms | <=1ms | <=3ms | paired added <=10ms; không chờ proposal |
| Compact diagnostic enqueue cost | <=0,05ms | <=0,10ms | <=0,20ms | <=2ms, kể cả queue full/lock busy |
| Separate minus shared added critical path | <=0,10ms | <=0,50ms | <=1ms | paired added <=5ms; cả hai đạt shadow SLO |
| Ready proposal validation + selection | <=1ms | <=2ms | <=5ms | <=20ms, trong absolute budget |
| Timeout/fault known → baseline disposition | <=1ms | <=5ms | <=10ms | <=25ms, không đợi worker cleanup |

Faultknown→baseline SLO đo boundary có caller sẵn, không đo khoảng ngủ do lịch
controller. Report deadline overrun riêng: **zero proposal accepted at/after D_job**.
Compute full budget4s là planned cost opt-in, không áp shadow overhead SLO cho
nó; vẫn phải ở D_job, không tăng accepted timer/input miss so control.

### 6.2 Stop, resources, diagnostics

| Hạng mục | PROPOSED gate / sample |
|---|---|
| Cancel signal / input authority revoked | Không phụ thuộc worker/log; added Stop-handler p95<=5ms, p99<=10ms, max<=25ms so control |
| Worker cancellation | Cooperative acknowledgement <=100ms; hung process terminate+reap <=1000ms ngoài action/Stop handler |
| Late result / Stop safety | 0 accepted stale/late, 0 input after Stop, 0 replacement after input, 0 orphan worker/controller |
| Fault repetitions | Tối thiểu30 isolated trials/fault variant; Stop/cancel100 trials gồm active/pending/hang/logfull; report max, N và p50/p95/p99 (small-N tails descriptive) |
| Disabled resources | 0 worker/job/AI queue; mean CPU delta<=1 percentage point host CPU, private working set delta<=8MiB |
| Active resources | 1 worker compute concurrency, main CPU delta<=5pp; total added private working set<=256MiB, main<=32MiB, queue<=8MiB |
| Resource growth | Fixed offline workload30min: last5min median vs first5min after warmup <=8MiB retained growth; peak caps vẫn thắng, không bắt mọi RSS trở về0 |
| Healthy diagnostics | dropped/failed/discarded eligible critical records=0 trong declared normal workload; injected overload có counters khớp và không block |
| Separate sink cost | Ngoài timing row: mean total CPU delta separate-shared<=1pp, bounded disk/memory/counters |
| Live overhead | Measure từ timestamps/state sẵn; N thực tế, raw tails; nhỏ hơn workload offline ghi DESCRIPTIVE/NOT_MEASURED, không tự tăng matches |

CPU percentage point dùng cùng total-host normalization và sampling method
freeze; concurrency cap không hứa CPU luôn bằng một logical core. Không thêm
production monitor đọc game. Perf instrumentation overhead đo trong control.
B4 chọn backend/runner và freeze SLO manifest trước C3; nếu target bất khả thi
phải ghi limitation/remediation và thiết kế giảm cost trước, không claim proof.

## 7. Failure matrix

B4 pure boundary faults, C3 integration faults, C4 validator; dangerous fault chỉ
offline. Mỗi row có before-input và after-input variants applicable, normal
positive control, state/identity/counter assertions. Missing essential field
phải có reason, không assign0.

| Fault / case | Expected disposition |
|---|---|
| Crash/hang/IPC closed/corrupt/oversize/NaN/Inf/unknown schema | Trước input retain valid BASIC; bounded cleanup/breaker; malformed không tới executor |
| Late result / t_now >= D_job / insufficient reserve | Discard/retain valid BASIC; không nhận partial hoặc reset deadline |
| Config/model/calibration/source/turn/generation mismatch | Discard; current controller/preflight xử lý; stale baseline không được blind dùng |
| Invalid state/foreground/turn/actionability/cost/lease | Existing fail closed/NONE; AI không bypass bằng fallback |
| Essential evidence missing/conflicting/unsupported | Scoped feature unavailable; chọn chỉ nếu nonessential và so sánh đủ, nếu không retain |
| Same-burst Rage→passive order UNKNOWN | Conditional example không thành guaranteed kill; không override từ imagined order |
| Unexamined max-Sword ties / nonSword priorities unknown | Coverage incomplete, uncertainty/stress treatment A2; không chọn favorable tie để claim retained setup |
| Baseline effect opaque / cross-family incomparable | Baseline unscored không phải score0; retain trừ scoped comparable evidence đủ |
| Repeated setup loss / boss Shield growth | Log observed lost forecast/progress; exact boss move UNKNOWN nếu thiếu owner evidence; không hard loop cutoff N |
| Bait apparent gain / damaging reply stress | So threat/HP/fragility; counterexample phải reject bait hoặc retain khi essential effect thiếu |
| Queue full/lockbusy/disk full/permission/writer crash | Nonblocking drop+counter; before input retain/degrade, after input không replacement; no retry/log storm |
| Stop/new match/config invalidation with pending result | Ignore job, no input/authority leak; cleanup bounded ngoài Stop |
| Input already sent / ambiguous ACK / QTE active | Planner không có quyết định thay thế hoặc retry; existing pending/ACK/QTE owner xử lý |
| Mandatory/PASS/EVOLVE continuation / BuWin local death | Giữ A1 ownership/profile gates, không generic solo emergency hoặc technical recovery do AI |

## 8. Dataset, provenance và gates

| Tier | Use / giới hạn |
|---|---|
| S — synthetic design | 50 A2 designs + deadline/fault cases trên; chưa executed. Materialize ở B1/B2/B3, positive/negative/determinism/missingness |
| H — historical incidents | [Demon review](../research/demon_shield_setup_incident_review.md), MI3 và accepted logs; chọn root thật, không nhãn outcome cho alternative |
| O — shadow | Published snapshots + proposals theo chosen BASIC root; coverage/latency/calibration, không counterfactual win-rate |
| L — live holdout | Fresh frozen comparison manifest; outcome arm thật; chỉ batch được kích hoạt theo [live protocol](5a3_bounded_live_protocols.md) |

Split theo match/session/time trước tuning, không turn-random. Duplicated
continuation checkpoint/match/snapshot hash thuộc cùng group. Corpus445 Demon
logs đã được inspected → development evidence, **không pristine holdout**.
10 archived snapshots không phải10 independent matches; owner/source/runtime
binary hash missing giữ UNKNOWN. Không transplant refill đã observed sang
alternative root. Replay exact board là mechanical consistency, không prove
full opponent/refill/damage model hoặc planner thắng hơn.

Minimum offline coverage: mọi A2 design row và failure row có expected assertions
hoặc explicit unsupported route/fallback; 0 unlabelled skip. DSI01–DSI07 trong
review phải có repeated-loss và retained positive controls, semantic progress/
turns-to-first-passive, last_move owner missingness. Chưa cần hàng trăm trận mới
để pilot kỹ thuật; scope không phủ thì fallback/disabled capability.

| Gate | Owner / trạng thái tại A3 |
|---|---|
| Unit/schema/provenance/attribution, bounds/counts | B1 — NOT_IMPLEMENTED |
| Utility/comparator/advisory settings + baseline evidence | B2 — NOT_IMPLEMENTED |
| Boss ties/setup/bait/calibration/effect-order | B3 + D3 — NOT_VALIDATED |
| Isolation/logging/reserve/SLO calibration | B4 — NOT_MEASURED |
| Production flow parity / live baseline-shadow closure | C3 — NOT_MEASURED |
| Existing preflight/absolute deadline/after-input ownership | C4 — NOT_IMPLEMENTED |
| Scoped technical pilots / efficacy / soak / package | D/E/F — NOT_RUN |

A3 đóng gate **đặc tả** khi protocol rõ và honest missingness; không đóng bất kỳ
runtime/model/technical live/efficacy gate nào bằng văn bản.
