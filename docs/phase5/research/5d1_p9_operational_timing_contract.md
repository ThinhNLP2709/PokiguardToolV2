# 5D.1-P9 — Đề xuất thời gian quyết định cho pilot

2026-10-14 (Asia/Saigon). **PROPOSED / USER DECISION PENDING / NOT IMPLEMENTED.**
Parent [P8](../reports/5d1_p8_report.md),
[prompt P9](../prompts/5D1_P9_OPERATIONAL_TIMING_CONTRACT_PROPOSAL.md).
Đây là đúng một phương án được khuyến nghị: **pilot opt-in dùng thời gian dự
kiến từ snapshot hiện có, có reserve đo theo cohort, chấp nhận phần bất định
về đồng hồ server**. BASIC vẫn là mặc định. Chưa mở game hoặc bật input AI.

## 1. Điều cần người dùng chốt

Cho phép triển khai offline một nhánh pilot có giới hạn, dùng số giây đã đọc
và thời gian đã trôi trên máy để giới hạn suy luận; giữ nguyên đọc dữ liệu,
preflight, thao tác, ACK và lifecycle. Nhánh này **không bảo đảm tuyệt đối nước
đi đến server trước khi hết lượt**: tuổi thông điệp, pause/FX và lịch chạy
Windows/Unity vẫn chưa có bound. Có thể hụt lượt dù các gate local đã đạt.
Fallback BASIC cũng chịu các bất định của đường input hiện tại.

Chấp nhận đề xuất chỉ cho phép bước **triển khai và kiểm chứng offline kế tiếp**.
Chưa cho phép calibration, farm hoặc suy luận phát nước thật; các lượt live sẽ
có cấu hình, giới hạn và hướng dẫn cụ thể sau khi readiness đạt. Nếu không
chấp nhận, giữ strict contract/BASIC hiện tại và dừng nhánh timing này; không
yêu cầu thêm trận để tìm một con số có vẻ đủ an toàn.

## 2. Vì sao cần thay đổi contract

Loader hiện đòi báo cáo finite U gồm đủ anchor age, transport age, host/Unity
alignment, read span và quantization. P8 chỉ quan sát local clock:551 samples
hợp lệ,71 anchor changes,28 raw changes. Không có causal server receipt age.
P8 max read span5.0874ms, RTT, cadence và floor của integer không thay thế U.

P9 phát hiện thêm khoảng thiếu trong reserve hiện tại: collector bắt đầu ở
**final preflight**, còn sau khi kết thúc quyết định, controller vẫn phải qua
fresh evaluation, revalidation, guard/coordinate/permit trước checkpoint đó.
Khoảng này cần được tính và đo; không được coi return margin100ms đã bao hết.
Configured cap hiện lấy read-end+B; đề xuất mới lấy observation-start+B để
thời gian đọc state cũng tiêu vào budget. Cả hai hiện vẫn dùng original
observation cho giới hạn theo raw timer; không có deadline reset ở submit.

| Gate | Source hiện tại: strict native contract | Đề xuất operational opt-in |
|---|---|---|
| Timing authority | Pinned finite5-component U; chưa có evidence để tạo | Type/schema/context riêng; `native_U_ms:null`, `transport_age_ms:null`, `host_unity_alignment_ms:null`; có contract/decision hash |
| Raw integer | Đã đọc, range-valid; không biết tuổi tick | Dùng làm projection local, ghi rõ UNBOUND; không dùng nhãn ACCEPTED_BOUNDED_NATIVE_TIMER |
| Budget | min(read-end+B, observation+raw−U−R−M) | min(observation+B, observation+raw−R_op−M_op); không gán U=0 |
| Reserve | max(1000ms, existing floor, native nearest-rank p99+250ms), chỉ final-preflight→return | Bao decision-exit→preflight và preflight→return, cộng allowance cho selector và toàn bộ commanded wait của BASIC; số native còn PENDING |
| Fresh/final | State/config/owner/source/proposal/input gates | Giữ checkpoint, số read, thứ tự và fail-closed; thêm kiểm thời gian host trên data đã có |
| Errors | BASIC trước input nếu còn hợp lệ; ACK do owner cũ | Giữ; AI lỗi không pause/recover farm, không input thứ hai |
| Activation | BASIC default, shadow OFF, UI REASONING gated | Giữ; factory pilot riêng, request có cap/expiry/source/cohort/contract hash; chưa mở UI đại trà |

Strict `PilotAuthority` và loader cũ tiếp tục giữ nguyên ý nghĩa finite-U. Không
nới validator đó để mọi native authority bỗng chấp nhận UNKNOWN, không truyền
operational allowance vào tham số `uncertainty_ms`, không relabel fake evidence.

## 3. Clock, units và provenance

Tất cả duration dưới đây tính bằng **ms**; timestamps tính bằng **ns** trong
cùng `host.perf_counter_ns` của một process lifetime. Đổi ms→ns bằng1e6.
Không so epoch host với Unity float hoặc server time. `time.monotonic` dùng
cho pending/ACK hiện tại giữ nguyên, không lấy timestamp đó trừ perf_counter.
Wall-clock Unix chỉ dùng expiry ở setup; không điều khiển deadline một lượt.

| Tên đề xuất | Nguồn/ý nghĩa |
|---|---|
| `observed_ns` / t0 | Host timestamp trước existing provider poll; giữ nguyên cho source/generation này |
| `read_end_ns` / t1 | Host timestamp sau poll; t1−t0 là read-span local, không phải tick age |
| `raw_remaining_ms` | `state.battle.turn_time_remaining_seconds*1000`; range-valid MatchService integer, chưa biết tuổi thông điệp |
| `host_elapsed_ms` | (now−t0)/1e6, bao read/BASIC/queue/IPC/validation/wait đã trôi |
| `projected_remaining_ms` | raw_remaining_ms−host_elapsed_ms; OPERATIONAL_PROJECTION, không là server deadline |
| `budget_ms` / B | Frozen configured budget; default4000, cap6000; tổng từ t0, không chỉ compute child |
| `reserve_after_decision_ms` / R_op | Operational envelope ở mục5, đúng source/host/transport/cohort; native số còn PENDING |
| `return_margin_ms` / M_op | Đề xuất giữ floor hiện có100ms, có thể frozen lớn hơn; allowance policy, không clock bound |
| `host_guard_ms` / G_host | Đề xuất250ms cộng thêm vào reserve; allowance policy kế thừa mức slack của loader, không phải quantile hoặc U |
| `minimum_job_window_ms` | Giữ50ms admission; dưới đó không đợi worker |
| `max_read_span_ms` | Frozen rejection threshold phải được readiness/calibration review; không suy từ P8 maximum; PENDING |
| Native U/transport/alignment | UNKNOWN/null trước, trong và sau pilot nếu không có evidence riêng |

Không trừ cố định1s rồi gọi đó là clock uncertainty. Không dùng timer mới ở
fresh/final để cấp lại toàn bộ budget hoặc kéo dài deadline của cùng job.
Nếu projection đang thấp/âm, không cố “đợi thêm tick” hoặc đọc thêm clock.

## 4. Một deadline cho mỗi quyết định

Sau existing scan, tính BASIC trước. Nếu BASIC không là ordinary SWAP, giữ
đường cũ. Worker nhận cùng immutable state, config, incumbent và provenance.

```text
D_budget = t0 + B * 1e6
D_projected = t0 + raw_remaining_ms * 1e6
D_wait = min(D_budget, D_projected - (R_op + M_op) * 1e6)
admit only if D_wait - now >= 50ms
```

Đây là scheduling policy dưới assumption projection hữu ích; không là phép
chứng minh thời gian đến server. R_op thiếu, cohort/source/clock không khớp,
state invalid hoặc không còn50ms thì không đợi và dùng flow BASIC hiện có.
Không tạo authority từ bộ giá trị pending.

BASIC đã tính, cold start, queue, serialize, worker, validation và chờ đều
tiêu cùng budget. Return ngay khi có kết quả hoặc lỗi; kiểm Stop theo event
lát≤5ms hiện có.5ms là thời gian chờ được yêu cầu, **không** bound scheduler.
Resume/supersede/retry không cấp thêm budget cho cùng source. Job hết hạn
không được tái chọn tại late-root. Kết quả hợp lệ ở root vẫn phải qua fresh và
final gates cũ; giữ yêu cầu `now < min(job deadline, dispatch deadline)`.

Nếu kết quả gần deadline đến mức final gate không còn hợp lệ, bỏ proposal.
Ở root/fresh còn trước input, dùng BASIC còn hợp lệ tại checkpoint hiện có.
Final preflight đã reject thì giữ đường cancel-unsent/next-loop hiện tại,
không thêm một final read hay gửi BASIC ngay để chữa late proposal.

## 5. Reserve bao đủ đường fallback

Future telemetry cần host timestamp ở **decision-exit** của calibration BASIC
và ở final-preflight-start đã có. Không sleep giả để tạo calibration, không
gọi thêm provider/MatchService/capture. Đo:

- H_native: decision-exit→final-preflight-start, bao fresh policy/guard/mapping.
- I_native: final-preflight-start→executor-return; gồm existing read/validation,
  foreground/geometry, cursor settle, mouse hold, pacing và random BASIC.
- H_extra: allowance đo offline cho chi phí selector/operational gate mới so
  với BASIC calibration; đo cả completed/timeout/error/fallback paths. Đây là
  local measured maximum với provenance, chưa là future hard bound.

Đề xuất duy nhất, có chủ đích bảo thủ:

```text
W_command = reaction_max + inter_click_command_max
            + first_cursor_settle + 2 * mouse_button_hold
R_op = max(existing_minimum_action_floor_ms, 1000,
           max(H_native) + max(I_native) + H_extra + W_command + 250)
```

`W_command` lấy từ exact pinned foreground two-click executor và frozen
parameters: reaction max1000ms; inter-click command cap1850ms; settle/hold
lấy từ cấu hình/backend thực tế. Chỉ với defaults0.06/0.075s thì tổng command
3060ms. **3060ms không phải R_op** và không bao OS/API/Unity delay. I_native
đã chứa wait thực tế; cố ý cộng lại full commanded ceiling để không suy luận
nhầm vài mẫu random nhỏ là tail, cũng bao thay đổi pacing trong phạm vi đã pin.
Không tự rút phần cộng này khi pilot thiếu compute budget; giữ BASIC.

H/I maxima có thể từ hai sample khác nhau; phép cộng không nhỏ hơn observed
full tail. Guard250ms và margin100ms là policy choices cần chấp nhận, không
biến số lượng mẫu nhỏ thành một bound. Mọi số measured H/I/H_extra và threshold
read-span hiện **PENDING**, không lấy fake fixture, P8 span hoặc máy khác điền
vào. Windows stall, VM load và transport có thể vượt mọi envelope này.

Valid reasoned SWAP bỏ reaction/jitter như P2, giữ mandatory pacing/settle/hold.
BASIC/fallback giữ cả random. Dùng cùng R_op bảo thủ cho cả hai; không dành hết
random slack cho AI rồi còn phải chạy random fallback. Không cố đi tại7s/5s
hoặc chừa1–2s theo cảm tính. Tốc độ thực tế phụ thuộc envelope đã review.

## 6. Invalidation, fallback và breaker

Giữ exact build/source/config/model/utility/hash/run/generation, session/match/
turn/player/sequence/board/resources/BASIC incumbent binding. Actor/owner,
legal SWAP, foreground/geometry, permits, Stop và consuming-turn/pending lock
đều thuộc existing controller. Full interval UNKNOWN của R/P/E và solver
certificate/gap≥0.05 giữ nguyên; chưa có damage/survival guarantee.

Clock/source backwards, NaN/Inf, read span vượt frozen threshold, expired
request, changed cohort/host/input parameters, job stale, deadline hết hoặc
diagnostics lỗi → không override. Thiếu/broken authority ở setup → BASIC,
không làm farm không Start được chỉ vì AI. State/pointer invalid vẫn fail closed.

Giữ breaker: persistent fault tắt AI ngay;3 lỗi liên tiếp hoặc5/20 jobs tắt AI
phần còn lại run. Reserve overrun/late-final attributable to AI hoặc telemetry
mất/receipt không xác minh được tắt operational pilot ngay, không tự tăng
reserve và retry live. BASIC tiếp tục chỉ theo existing validity/owner gates.
Nếu có duplicate/wrong-turn/illegal input hoặc vi phạm Stop/owner thì đóng
live batch, giữ evidence và sửa đúng lỗi offline trước; không cố hoàn thành cap.

Sau bất kỳ input/partial input, planner không phát BASIC thay thế. ACK uncertain,
timeout, recovery và return-to-room tiếp tục do owner hiện tại xử lý. Timestamp
executor-return chỉ upper-bound thời điểm hoàn tất input trong sample, không
chứng minh game/server đã nhận; ACK là evidence riêng.

## 7. Telemetry và acceptance

Giữ capped queue/sink riêng, enqueue nhẹ và writer ngoài action/Stop thread;
không disk/hash/flush/join trên decision hot path. BASIC/shadowOFF không tạo
worker hoặc probe mới khi không có opt-in calibration/pilot request.

Mỗi admitted/skipped/failed/cancelled job hoặc input attempt phải giữ run/job/
source/cohort/contract hashes; raw timer, t0/t1/BASIC-ready/submit/wait-exit/
result-validated/fresh/final/read-end/first-input-if-available/executor-return;
D_wait, elapsed, R_op components, final raw, selection/fallback/rejection,
input result, pending/ACK outcome và writer watermark. Không có timestamp
click thật thì ghi NOT_MEASURED, không thay bằng executor-return. Native U và
transport vẫn null; proposal/dispatched/ACK là ba kết quả khác nhau.

Offline return gate: byte/AST/trace parity khi disabled; một absolute deadline
ở mọi consumer; zero extra read/capture; error/late/sink/worker/Stop/stale/
partial-input coverage; bounded queues/process cleanup; affected latency/CPU/
Stop qualification trên current source. Không lấy C3/P8 cũ re-certify source mới.

Future live gate: all-attempt ledger đầy đủ,0drop,0wrong-turn/illegal/duplicate/
owner/Stop violation; mọi override phải before host deadline và qua existing
preflight; H/I/tail không vượt declared envelope; ACK/terminal attribution đầy
đủ hoặc ghi explicit unknown và no second input. Bất kỳ critical failure hoặc
overrun đóng nhánh; samples sạch chỉ là bounded technical acceptance, chưa
đánh giá hiệu quả thắng/energy và không chứng minh future clock safety.

## 8. Calibration hữu hạn sau readiness

Tách khỏi P8 và D1: **BASIC-only, default3/max5 TOTAL match attempts**, mọi
invalid/abort/failure cũng tiêu cap. Một frozen request/source/host/account/
boss/loadout/transport/config, durable run claim; không restart/resume/copy
để reset cap. Chọn SIMPLE hoặc CAREFUL cụ thể, SOLO, normal pet/evolution,
default_attack, foreground/two_click, shadow OFF, không suy luận phát nước.

Đo H/I và full tail trên mọi ordinary SWAP thu được; không đòi số turn để
farm thêm. Các attempt không có usable SWAP vẫn nằm ledger.3attempt mặc định;
chỉ dùng thêm tối đa2 nếu đã review/authorize cap5 trước khi chạy, không tự
kéo dài sau khi thấy kết quả xấu. Calibration short/thiếu H/I hoặc mixed cohort
→ INCONCLUSIVE/BASIC, không tìm PASS bằng batch liên tục. Hai profile/config
khác hash không tự dùng chung authority; trước hết đóng một cohort.

Request/receipt mới chỉ chuẩn bị sau offline implementation/readiness; old
source279/P3 calibration draft không tương thích source280 hiện tại. Các đo
này cho operational reserve và overhead, **không** prove tick age/transport/
host-Unity alignment. Không thêm native observer hoặc Unity clock reader.
D1 draft12attempts là batch riêng chưa kích hoạt; không gộp cap với calibration.

## 9. Thay đổi chính xác ở milestone kế tiếp nếu chấp nhận

| File/gate | Công việc offline cần làm; chưa thực hiện trong P9 |
|---|---|
| EXECUTION_CONTRACT §3–6, capability/router/status | Ghi rõ operational opt-in và residual risk; giữ strict/fake modes riêng, BASIC default |
| reasoning_pilot_contract.py / reasoning_pilot_activation.py | Type `OperationalPilotAuthority`, schema `pokiguard.reasoning.operational_pilot.v1`, context `BOUNDED_R1_OPERATIONAL_SWAP_PILOT`; loader riêng đòi accepted contract/decision hash, reserve provenance, full source/build/host/config/cohort pins/expiry/cap; native_U null |
| reasoning_runner.py / reasoning_pilot.py | Operational helper riêng, t0-based budget, same-state BASIC-first, one deadline, bounded early/Stop wait; strict helper không đổi ý nghĩa |
| reasoning_selection.py | Typed capability/completion/root/fresh/final dispatch validation chọn đúng timing mode; không weaken source/legality/UNKNOWN intervals; guard cùng deadline, log rõ operational |
| reasoning_swap_timing.py / tools/basic_auto_bot.py | Opt-in host-only decision-exit/phase receipts tại checkpoint đã có, bao H/I/full tail và fault paths; không move/add reads/capture/input, không đổi ACK/lifecycle |
| reasoning_calibration.py / readiness utility | Native BASIC-only request mới pin instrumentation/host/cohort/cap3 hoặc đã review cap5; provenance+all-attempt watermark; pending reserve không tạo authority |
| desktop factory/session và source-fake tests/qualification | Setup optional operational request và cap/expiry/claim/rollback; UI REASONING vẫn gated, preferences không đổi; exact disabled parity và affected performance evidence |

Các check production-model hiện dùng điều kiện origin `NATIVE_INPUT_CALIBRATED`
trong selector phải áp dụng tương đương cho operational native type: version-only
model, R/E UNSUPPORTED, P interval đầy đủ và structural checks. Không thêm origin
mới rồi vô tình rơi qua nhánh fake/offline có numerical effects. Source/host/
cohort pin và expiry/cap của operational request phải được kiểm lại tại Start;
metadata request không phải game-state freshness evidence.

Đây là một implementation/readiness milestone offline, sau đó mới trình một
calibration package cụ thể nếu đủ gate. Không tách tiếp thành các vòng nghiên
cứu clock vô hạn. Current game/build hashes và source freeze phải refresh
theo source thực sự sau implementation; không sửa review/snapshot lịch sử.

Rollback: không cung cấp operational request/factory hoặc disable pilot session;
controller dùng BASIC hiện có. Request hết hạn/không khớp tự vô hiệu. Không đổi
default, không ghi preferences để rollback, không cần patch game hoặc đổi input.

## 10. Evidence và trạng thái quyết định

[Source gate ledger](../artifacts/5d1_operational_timing_proposal_v1/source_gate_ledger.json)
có31 gates/13 files, exact line ranges/SHA/excerpts trên source280 fingerprint
`4260c002196135ca9eebaff9180d428976d83d518746993d812182cff15713c6`.
Các điểm trọng yếu:

- [strict deadline](/D:/PokiguardToolV2/src/pokiguard_v2/reasoning_runner.py:27),
  [finite-U loader](/D:/PokiguardToolV2/src/pokiguard_v2/reasoning_pilot_activation.py:93).
- [decision wait](/D:/PokiguardToolV2/src/pokiguard_v2/reasoning_pilot.py:161),
  [final gate](/D:/PokiguardToolV2/tools/basic_auto_bot.py:9769).
- [current timing start](/D:/PokiguardToolV2/src/pokiguard_v2/reasoning_swap_timing.py:38),
  [input random/pacing](/D:/PokiguardToolV2/src/pokiguard_v2/win32_input.py:553).

**Decision: PENDING.** P2 đã cho phép bounded decision wait và bỏ optional random
cho nước suy luận; không đồng nghĩa chấp nhận UNKNOWN server clock cho input
pilot. Next duy nhất: người dùng chốt đề xuất mục1. **STOP P9.**
