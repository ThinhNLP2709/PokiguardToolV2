# 5D.1-P20 — Admission coverage review, offline

2026-10-15 (Asia/Saigon). **REVIEW COMPLETE / IMPLEMENTATION PENDING / PARTIAL D1.**
[Prompt](../prompts/5D1_P20_ADMISSION_COVERAGE_REVIEW_OFFLINE.md),
[parent P19](5d1_p19_report.md),
[policy proposal](../research/5d1_p20_root_admission_policy_review.md),
[review decision](../artifacts/5d1_admission_coverage_review_p20_v1/review_decision.json).
Chỉ đọc source và evidence đã lưu; không sửa runtime hoặc chạy live/tests/benchmark.

## Kết luận

Đã xác định đúng nguyên nhân trực tiếp của19 lượt P19 không được suy luận:
**root admission chặn snapshot vì full provider poll vượt policy100ms**.
19 spans thực tế120.2439–157.6481ms; veto xảy ra trước worker submit.
Trận3 có opening cards[] và9 root-span vetoes nên không submit job. Worker và
diagnostics của trận đó vẫn healthy/reaped/flushed; không lặp lỗi successor P15.

Không thấy lỗi đổi đơn vị ns/ms hoặc boundary cộng nhầm BASIC/planner compute
vào root read span. Chưa biết chính xác substage hoặc yếu tố scheduling nào làm
poll dài hơn; raw hiện có không có đủ substage timestamps để kết luận reader,
card/fusion, CPU hay screenshot là nguyên nhân. BASIC vẫn chạy đúng flow.

Chọn **đề xuất policy successor root250ms/final100ms** cho bước implementation
offline.250ms là rejection cap được đề xuất, không future latency/coherence/
server-clock guarantee. Runtime hiện tại vẫn100ms; chưa sửa code hoặc cấp live
authority. Không tăng budget4s và không đổi cách đọc/action/input của tool.

## Evidence đã đối chiếu

[Bảng machine-readable](../artifacts/5d1_admission_coverage_review_p20_v1/p19_turn_evidence.json)
và [CSV](../artifacts/5d1_admission_coverage_review_p20_v1/p19_turn_evidence.csv)
giữ match/turn/sequence/source, root timestamps, budget, worker outcome,
fresh/final markers, pacing và action/ACK references với SHA/line.

| P19 outcome | Combat0 | Combat1 | Combat2 | Tổng |
|---|---:|---:|---:|---:|
| Opening cards[] fallback | 1 | 1 | 1 | 3 |
| Root span >100ms | 1 | 9 | 9 | 19 |
| Completed retention | 7 | 1 | 0 | 8 |
| SWAP timing / sent | 9/9 | 11/11 | 10/10 | 30/30 |

8 completed retentions gồm5 near-tie/assumption-sensitive và3 baseline-top;
compute22.2207–43.6303ms diễn ra sau root t1. Zero overrides bình thường;
không coi retention là failure hoặc suy global optimum/WIN improvement.

3 superseded timings được join bằng critical source hash: sequence13 ứng với
EVOLVE turn7; sequences15/19 ứng với pre-input proposal cancellation turn9/15
của combat1. Hai turn đó sau đó có SWAP/ACK hợp lệ. Giữ2 aborted proposals và
3 SWAP cuối trận terminal-no-ACK; không đổi chúng thành missing logs hoặc ACK.
Tên counter `user_state_changes` không chứng minh user có thao tác.

Collector sequences1–33 và108 durable events đầy đủ; checkpoint/poll counters
không phải số lượt hoặc jobs. Các fresh opportunistic checks ghi label ROOT
nhưng dùng root state cũ; không là observation mới để reset deadline.

## Timestamp boundaries và nguồn100ms

[20 source boundaries đã pin](../artifacts/5d1_admission_coverage_review_p20_v1/source_boundary_map.json):

- Root t0 ở `tools/basic_auto_bot.py:5013`; helper/provider call5016; t1 truyền
  cho admission ở5032. BASIC analysis/decision ở7841/7847 và planner await7918
  đều sau t1. Timing collector là cặp markers khác, start lệch tối đa0.0046ms,
  end lệch tối đa0.0568ms; không đủ giải thích20–58ms vượt ngưỡng.
- Helper có PASS_WAIT, opening handoff và normal provider.poll branches.
  Opening handoff có runtime sample trước wrapper; duration wrapper không
  chứng minh toàn bộ state age. Opening cards[] vẫn không đủ cohort witness.
- Provider poll gồm ownership/lifecycle/cards/fusion/transport/ACK/native board,
  after-read stability/presentation checks, participants/timer/state assembly.
  Native Dot metric chỉ đo subpath4748–4863, không toàn bộ poll. Không lấy
  timer gần cuối poll để redate toàn snapshot hoặc chứng minh atomicity.
- Current `max_read_span_ms` dùng chung root admission ở reasoning_pilot.py:159
  và final direct-runtime preflight ở reasoning_swap_timing.py:223. Đây là lý do
  không được thay100 thành250 trên toàn hệ thống.
- P12 chọn100ms làm host veto policy, dựa trên phạm vi P11; tài liệu gốc nói rõ
  không phải future/clock bound. Current v2/v3 loader pin100ms chính xác.

[Đối chiếu lịch sử từ raw](../artifacts/5d1_admission_coverage_review_p20_v1/historical_comparison.json):

| Nguồn riêng | SWAP returns | Root max | Final read max | Root >100ms |
|---|---:|---:|---:|---:|
| P11 BASIC source284 | 26 | 49.7245ms | 4.9305ms | 0 |
| P15 operational source290, chỉ combat0 | 7 | 233.3348ms | 3.5602ms | 5 |
| P19 operational source294 | 30 | 157.6481ms | 4.948ms | 19 |

P11 giữ20 full-witness ACK anchors,3 opening-deferred,3 terminal-no-ACK và
4 superseded records. P15 giữ16 missing timings và raw `SOURCE_CHANGED`
reasons cũ; không relabel chúng thành P16/P19 reasons. Không gộp các source
khác nhau thành population hoặc native calibration cho source tương lai.
Provider source P15/P19 byte-exact SHA d1f812a…; điều này không chứng minh
chi phí mọi poll bằng nhau. Cumulative metrics/change-triggered diagnostics
không định danh duration của từng root. UNKNOWN ledger giữ5 câu hỏi rõ.

## Quyết định cho bước tiếp

Đề xuất version riêng **OPERATIONAL_ROOT250_FINAL100_V1**:
root cap250ms, final vẫn100ms, legacy v2/v3/finite-U vẫn100ms. Không thêm UI
setting tùy ý tăng cap. Pin policy/version/limits trong successor review,
authority/request/export và future activation. Không dùng old claims hoặc sửa
P18/P19 requests để reset cap.

250ms bao phủ P19 samples và P15 max233.3348ms của cùng provider;200ms vẫn loại
5 P15 roots. Đây là tradeoff policy công khai, không suy từ sample max thành
cận trên tương lai. Chưa có runtime acceptance của policy mới. Nếu implementation/
qualification fail, giữ100ms và BASIC với coverage hạn chế là rollback hợp lệ.

Giữ nguyên deadline `min(t0+B,t0+rawRemaining-R-M)`,50ms floor, guard≥250,
margin≥100. Root elapsed vẫn bị trừ; không bắt đầu lại ở t1 hoặc cộng250ms delay.
Với chính timestamps/R lịch sử P19,19 roots còn3734.7367–3831.1513ms tại
budget-start.27 records có full-card witness và cùng critical source hash qua
được **riêng** hypothetical span/budget checks;3 openings vẫn fallback.
Không gọi đó là27 jobs/completions hoặc dự đoán action/ACK chưa xảy ra.

Không chọn sửa/tối ưu provider hoặc thêm profiler/observer trong nhánh này.
Existing source/config/cohort/BASIC binding, fresh/final checks, Stop, pending/
ACK và AI-only fallback giữ nguyên. Không replay BASIC sau input. Native
U/transport/alignment null; first exact click/override native latency chưa đo.

[False policy proposal](../artifacts/5d1_admission_coverage_review_p20_v1/successor_policy_proposal.json)
accepted/live/input/reasoning authority=false, không run/expiry/activation/claim,
future source/allowance/reserve=null. P19 R6767.4529 chỉ dùng arithmetic lịch sử.
Bước sau phải đo affected software costs và rebind exact source; không tự dùng
lại allowance/R cũ hoặc hạ reserve từ batch P19 có observed tail nhỏ hơn.

[24 planned cases](../artifacts/5d1_admission_coverage_review_p20_v1/planned_cases.json)
gồm root legacy100/successor250 +1ns, final100, one-t0/floor50, rejected-root
cached-offer veto, source/config/cohort changes, empty cards, Stop/fault/
retention/cleanup/durability, no-extra-game-work, proof tamper và default parity.
Đây là kế hoạch, không tests đã chạy.

## Bảo toàn và route

P19 final manifest471 entries đã kiểm tại entry P20. Snapshot P20 pin294 Python
files,5,244 immutable parent artifacts,6claims,4static game files, ordinary prefs,
host/HEAD. Existing idle UI log giữ byte-prefix riêng; append không dùng như
native combat evidence mới. Chỉ docs/review artifacts đổi. Không source/tests/
build/version/Git/game files/preferences thật hoặc live input/attach/capture.
[Final verification](../artifacts/5d1_admission_coverage_review_p20_v1/verification_final.json).

Next duy nhất **[P21 root admission policy implementation OFFLINE](../prompts/5D1_P21_ROOT_ADMISSION_POLICY_IMPLEMENTATION_OFFLINE.md)**,
**SELECTED ONLY / NOT EXECUTED**. Chưa cần mở game hoặc test thêm. Chưa general
SIMPLE/CAREFUL/Demon/Mega/D1cap12/D2 hoặc Phase5 completion. **STOP P20.**
