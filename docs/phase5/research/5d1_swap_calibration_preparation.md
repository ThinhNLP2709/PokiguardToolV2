# D1 — Chuẩn bị calibration SWAP; chưa kích hoạt

P3 update2026-10-12: explicit source-only BASIC request, current source/build
hash verification, one-shot run-ID claim, ACK/all-attempt export và off-Stop
writer receipt đã chuẩn bị. Quy trình chi tiết nay ở
[runbook](5d1_basic_calibration_runbook.md). Native clock age chưa bound, nên
vẫn NOT_ACTIVATED/0attempts; không dùng calibration R để thay thế proof U.
Next chỉ [P4 clock evidence](../prompts/5D1_P4_CLOCK_AGE_EVIDENCE.md), chưa live/D1.

Ngày2026-10-12. **DRAFT / NOT_RUNNABLE / 0 attempts.** Parent:
[P1 report](../reports/5d1_p1_report.md), [A3 timing](../specs/5a3_telemetry_deadline_acceptance.md),
[bounded protocol](../specs/5a3_bounded_live_protocols.md).

P1 chưa đủ software timing/activation để mở D1. Đây chỉ là kế hoạch đo BASIC
được chuẩn bị theo P1; chưa cần người dùng mở phòng, chưa attach/chạy game.

P2 update2026-10-12: bounded decision software đã có6cold controller overrides
qua ACK; optional timing hook và file loader/session đã chuẩn bị. Timing end
hiện tại là executor-return **upper bound** sau click2, không exact click2.
Operator activation/affected qualification/ACK join/nativeU-R chưa đủ; draft
vẫn NOT_RUNNABLE,0attempts. Next [P3](../prompts/5D1_P3_ACTIVATION_AND_CALIBRATION_READINESS.md).
Valid reasoned foreground SWAP bỏ optional random theo user, nhưng batch đo
trước mắt vẫn BASIC với pacing/random accepted; không promote sample khác mode.

## Boundary đã xác định từ source

| Mục | Hiện trạng |
|---|---|
| Family / transport | ordinary SWAP, foreground, two_click; không bao gồm skill/QTE/PASS/drag/background |
| Accepted final read | `read_match_runtime` hiện có; không thêm read để đo |
| Accepted inequality | `remaining_seconds >= minimum_action_time`; source `direct_runtime_swap_preflight_failure` và final preflight đều reject bằng `<`, không phải `<=` |
| Production timer | `MatchService.server_tick`, integer seconds; external observation không biết independent Unity clock, U chưa bound |
| Start timing cần thu | monotonic trước accepted final preflight timer read, ghi read-start/read-end/remaining; software validation sau read thuộc interval |
| Required-input end | sau click thứ2 của ordinary SWAP; không bao gồm chờ ACK; giữ sample status nếu input không hoàn tất |
| R | max(accepted floor,1000ms, measured descriptive p99 +250ms); chưa có số native |
| U / M | U phải có bound evidence, minimum150ms chưa tự là calibration; M proposed100ms, còn cần software qualification |

Log C3 chỉ ghi `interClickDelaySeconds`, ví dụ1.071851478389513s tại
`logs/farm_runs/20d06926b7c847b3bd79dcefc77054df/matches/attempt_001/combat.jsonl`.
Không có full preflight-start/required-input-end monotonic interval.9 swaps
không đủ để suy ra native execution-tail bound; không lấy inter-click p99 làm R.
Tên failure `TIMER_AT_OR_BELOW_ACTION_FLOOR` không đổi actual `<` inequality.

## Protocol chuẩn bị, chưa được phép chạy

Sau khi P2 software/telemetry đủ mới freeze một account/boss/build/loadout/
config/input cohort, source hash và cửa sổ chạy. Chạy **BASIC, shadowOFF,
reasoningOFF**. Default3 attempts TOTAL; hard max5 chỉ khi manifest activation
ghi5 trước batch. Không bổ sung để bù invalid/abort; không test đến khi gặp.
D1 quota12 và C3 batch6 đã đóng là batch khác, không cộng thêm quyền chạy.

Thu từ flow accepted: attempt/event IDs, timer source/read interval, action
family/input mode, preflight-start/input-end, action sent/ACK/abort/status,
energy/time/terminal outcome. No extra screen/memory reads hoặc input.
Telemetry enqueue có bound, writer riêng ngoài action; missing event giữ UNKNOWN.

Xuất raw durations + N/p50/p95/p99/max, read-span/age/clock uncertainty provenance,
config/build/cohort fingerprint. Mẫu nhỏ chỉ descriptive empirical tail, không
phải population p99 guarantee. Incomplete/Stop/failed-input samples vẫn trong
all-attempt ledger, không giả completed duration hoặc loại khỏi chi phí.
Nếu U/tail/cohort không đủ support theo scope thì gate giữ đóng, verdict PARTIAL;
không tăng trận hoặc gán U150/R2000 để tự pass. Calibration không chứng minh
planner efficacy hoặc override model; actual selection vẫn cần D1 pilot riêng.

Stop ngay khi wrong-turn/stale/duplicate/after-Stop input, flow/read/capture
regression, cohort drift, essential diagnostic loss hoặc cap/time window đủ.
Lỗi nguy hiểm chỉ inject offline. Không thay BASIC setting/ranking hay pacing.

Draft machine-readable:
[swap_calibration_plan_draft.json](../artifacts/5d1_production_bridge_v1/swap_calibration_plan_draft.json).
