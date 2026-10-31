# P20 — Review ngưỡng admission đầu lượt

2026-10-15. **PROPOSED FOR OFFLINE IMPLEMENTATION / LIVE NOT ACTIVATED.**
Parent [P19](../reports/5d1_p19_report.md),
[bảng 30 lượt](../artifacts/5d1_admission_coverage_review_p20_v1/p19_turn_evidence.json),
[source boundary map](../artifacts/5d1_admission_coverage_review_p20_v1/source_boundary_map.json).
Tài liệu này không phải activation review hoặc request có thể chạy.

## Findings

Nguyên nhân trực tiếp đã chứng minh: current root admission dùng policy100ms;
19 root polls P19 mất120.2439–157.6481ms nên bị loại trước worker submit.
Trận3 có opening cards[] rồi9 root-span vetoes, không phải successor worker
fault hoặc mất diagnostics.8 completed retentions ở hai trận trước hợp lệ.

Controller lấy t0 ở basic_auto_bot.py:5013, gọi provider helper ở5016 rồi lấy
t1 khi truyền kwargs admission ở5032. Khoảng này bao gồm helper/provider poll,
không bao gồm BASIC analysis ở7841/7847 hoặc planner await ở7918. Collector
markers nằm lệch một lượng nhỏ: start tối đa0.0046ms, end tối đa0.0568ms so với
admission markers; khác biệt đó không giải thích19 spans vượt ngưỡng.

Provider poll gồm lifecycle/ownership, current cards/fusion, transport/ACK,
native board khi cần, after-read/stability checks, participants, timer và state
assembly. Metric `native_dot_board_*_seconds` chỉ đo một nhánh con tại4748–4863;
không được coi đó là thời gian toàn poll hoặc trừ nó khỏi mọi root interval.
Provider metrics tích lũy và provider_status chỉ log khi thay đổi; không có
breakdown thời gian cho từng root. Nguyên nhân sâu của poll dài hơn còn UNKNOWN.

P11 BASIC source284:26 returns, rootmax49.7245ms/finalmax4.9305ms.
P15 operational source290:7 returns chỉ combat0, rootmax233.3348ms/finalmax3.5602ms,
5 roots vượt100ms;16 SWAP thiếu timing vẫn giữ UNKNOWN. P19 source294:30 returns,
rootmax157.6481ms/finalmax4.948ms. Không gộp ba nhóm thành một population hoặc
đổi chúng thành calibration của source mới. P15/P19 memory_board_provider.py
giữ cùng SHA d1f812a281e2caf4e82dc8ecab826589d87f17d5bc77ec1380f041bf2033f116.

P12 chọn100ms là **host veto policy**, dựa trên scope P11; tài liệu gốc nói rõ
đây không phải future bound hoặc clock uncertainty. Source không cho thấy nhầm
ns/ms hay đặt sai t1 khiến planner compute bị cộng vào root span. Chưa có bằng
chứng reader regression, screenshot delay, CPU bottleneck hoặc lỗi pet/fusion
gây19 spans. Không sửa reader từ tương quan này.

## Quyết định review

Chọn thay đổi **policy admission riêng cho root**, không tối ưu/reorder reader:

| Gate | Current v2/v3 | Proposed successor |
|---|---:|---:|
| Full root helper/provider poll span | 100ms | 250ms |
| Existing final direct-runtime read span | 100ms | 100ms |
| Deadline origin | original root t0 | original root t0 |
| Budget default/cap | 4000/6000ms | 4000/6000ms |
| Host guard / return margin floors | 250/100ms | 250/100ms |
| UNKNOWN native U/transport/alignment | null | null |

250ms là **proposed policy cap**, không phải latency guarantee. Lựa chọn này
bao phủ observed P19 spans và historical P15 max233.3348ms của cùng provider,
nhưng vẫn từ chối polls dài hơn250ms.200ms chỉ bao phủ P19, vẫn loại5 P15 roots;
không chọn ngưỡng dựa riêng trên một batch thuận lợi. Không nói250ms bảo đảm
coherence/server delivery hoặc là cận trên của những lần đọc tương lai.

Điểm phải tách: current `max_read_span_ms` được dùng ở **cả** root admission
(reasoning_pilot.py:159) và final preflight (reasoning_swap_timing.py:223).
Không đổi hằng100 thành250 trên toàn hệ thống. Đề xuất policy version
`OPERATIONAL_ROOT250_FINAL100_V1`: trường root cap riêng, final vẫn dùng100ms.
Không thêm setting UI cho người dùng tùy ý vượt cap; request/review pin policy.

Lý do chọn hướng này: mục tiêu Phase5 là bổ sung quyết định mà giữ flow hiện có.
Đã đủ evidence về cơ chế veto và nguồn gốc policy để review một admission cap;
không cần tìm cách tăng tốc từng memory sub-read mới được viết proposal.
Instrumentation/substage optimization là scope khác, không được mở chỉ để tìm
nguyên nhân sâu khi không có bằng chứng regression. Giữ100ms và công bố coverage
hạn chế vẫn là rollback hợp lệ nếu successor implementation/qualification fail.

## Deadline và freshness vẫn phải giữ

```text
D = min(t0 + configured_budget,
        t0 + raw_remaining - R_current_source - return_margin)
available = D - now
submit/wait only if available >= 50ms
```

Root span được trừ thông qua elapsed từ t0; không đổi t0 thành t1, không cộng
250ms vào deadline hoặc thêm250ms delay. Current P19 R6767.4529ms chỉ dùng để
phân tích lịch sử. Với chính các timestamps cũ,19 roots bị veto còn
3734.7367–3831.1513ms tại historical budget-start. Nếu chỉ đổi span gate thì
27 full-card roots qua được hai phép kiểm span/budget, còn3 openings vẫn thiếu
witness. Đây là **counterfactual arithmetic**, không phải27 submitted/completed
jobs hoặc proof về nước đi/WIN/ACK chưa quan sát. Không chạy lại planner ở P20.

Source/snapshot vẫn giữ nguyên: exact session, sequence, board hash, turn,
current player, critical-state fingerprint, config/cohort và BASIC incumbent.
Các after-read/stability/presentation/ACK checks của provider giữ nguyên.
Sequential reads không trở thành atomic state acquisition vì tăng cap.
Timer đọc gần cuối poll không đủ để redate toàn snapshot hoặc chứng minh U hữu hạn.
Opening helper có thể dùng immutable board với runtime sample lấy trước wrapper;
không gọi thời gian wrapper là toàn bộ state age. Opening cards[] vẫn BASIC.

Existing fresh checkpoint/final direct-runtime check vẫn loại proposal khi
state/config/turn/ownership/deadline thay đổi. ROOT-labelled opportunistic check
ở fresh dùng root state cũ, không là root poll mới hoặc lý do reset budget.
Root veto bất kỳ phải chặn completed offer cũ, kể cả cùng board/source. Sau input
không phát BASIC lần2; pending/ACK/Stop thuộc controller hiện có.

## Compatibility và implementation scope ở bước sau

1. Giữ finite-U path và reviewed-v2/v3100ms semantics. Thiết kế successor review
   riêng (v4 hoặc version tương đương); chỉ successor được pin policy mới.
   Old request sửa thêm field/root cap hoặc mang calibration cũ phải bị reject.
   Không reset/resume P15/P19 claims hoặc relabel native sources.
2. Authority/request/review/export/activation phải pin rõ root250/final100,
   policy version và exact source/host/build/config/cohort. Root policy phải
   immutable, bounded, type-checked; booleans/NaN/missing/conflicting values reject.
   Mặc định/legacy không được vô tình nhận250.
3. Bridge admission chỉ đọc cap đã verify, timestamp/receipt hiện có; không
   thêm provider call, capture, poll, sleep, solver trên hot path hoặc worker.
   Writer/collector reuse bounded logging, phân biệt active policy và span gate.
4. Preserve source identity/accepted execution flow, BASIC/shadow/defaultOFF,
   normal retention, no override quota. Final read100ms và H/I/aggregate monitor
   sau return vẫn giữ; lỗi chỉ disable AI, không stop farm do AI fault đơn thuần.
5. Pin exact changes từ source294, không generic compatibility exemption hoặc
   sửa P18 proof. Recompute affected current-source qualification/raw costs và
   R từ existing scoped native basis với fresh allowance. Không tự dùng lại
   S19.7482/R6767.4529 như authority cho source đã đổi. Floors không được giảm.
6. False draft chỉ sau gates; accepted/live/input_authority=false, không run ID,
   expiry, activation hoặc claim. Future live luôn cần activation mới riêng,
   user chuẩn bị room/manual Start và3TOTAL attempts; P20/P21 không cấp quyền đó.

## Planned acceptance

[Cases](../artifacts/5d1_admission_coverage_review_p20_v1/planned_cases.json)
là kế hoạch cho bước implementation, **chưa chạy tests**:
legacy100 boundary, successor250 boundary, final100 unchanged, original-t0
deadline and50ms floor, stale offer after veto, same-turn source/config/cohort
changes, Stop, timeout/fault/healthy successor retirement, logging failure,
source/review/activation tamper, finite-U isolation, no second-input fallback,
default BASIC parity và bounded affected software qualification.

Next duy nhất [P21 offline implementation](../prompts/5D1_P21_ROOT_ADMISSION_POLICY_IMPLEMENTATION_OFFLINE.md).
Không implement hoặc kích hoạt game trong P20. **STOP P20.**
