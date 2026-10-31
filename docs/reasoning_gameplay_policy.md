# REASONING gameplay policy — current contract

Chốt31/10/2026. **Phase5 ROADMAP COMPLETE — STOP**, declared scope trong
[FINAL_REPORT](phase5/FINAL_REPORT.md). BASICdefault, efficacyINCONCLUSIVE.
Current package chỉ nghiệm thu experimental lab R1DemonShieldSWAP/Solo/Lieyun77/
normal/4effectiveSword/floor2 với account/loadout/stats/build/host pin riêng.

Ordinary UI REASONING selection vẫn khóa. Guarded source pilots và package lab
activation đã triển khai/kiểm theo reports, không phải chỉ còn placeholder.
Direct BASIC-policy route trả REASONING_NOT_IMPLEMENTED không tự là authority
của đường guarded đó. [User guide](phase5/USER_GUIDE.md).

## Quyền quyết định

- Giữ mục tiêu PlayStyle và pet/loadout intent. Threshold setup/KếtẤn/skill,
  Sword/resource preference và tactical HP là tham khảo khi scope cho phép.
- Actual cost/source/cooldown/actionability, turn/PASS legality, identity,
  freshness, input lease/ownership và deadline vẫn bắt buộc.
- Chuẩn bị BASIC trước; planner nhận cùng immutable state/config. Có thể
  completed retention, không quota override. Không ghi lại preferences chỉ vì
  planner chọn khác threshold.
- Skill/PASS chỉ trong profile đã có evidence/source/counter và authority;
  package F1 passiveDemonSWAP không mở quyền skill/QTE/PASS cho profile khác.
- Không biến mục tiêu Búwin/chừaKiếm thành solo-survival hoặc dùng Solo model
  mở Coop. ShadowCoop/Búwin/DinosaurR chưa được nghiệm thu.

## Flow, thời gian và fallback

Existing reader/provider/poll/capture, lifecycle/navigation/FarmRunner,
action/QTE/executor/ACK/pending/recovery/Stop giữ owner/order. Worker không
process/game/capture/input authority. Không extra read/capture để chờ planner.

Theo quyết định người dùng12/10, được chờ trong decision budget an toàn sau
BASIC, trả sớm khi xong, kiểm Stop bằng cơ chế hiện có. Deadline từ observation
gốc, trừ reserve/margin, không reset hoặc sleep thêm một budget cố định.
Current operational timing là projection; nativeU/transport/alignmentUNKNOWN.
Samplemax không là future hard bound; strict finite-U gate không bị nới.

Receipt R hợp lệ bỏ random reaction/jitter giữa hai click ordinary foreground
SWAP theo contract đã chốt; giữ mandatory pacing/cursor settle/mouse hold và
fresh/final preflight. BASIC/fallback giữ random hiện có.

Planner/worker/log/queue/deadline/unsupported failure giữ BASIC còn hợp lệ trước
dispatch, có thể disable AI cho phần còn lại của phiên. Invalid state vẫn
failclosed. Sau input, existing pending/ACK owner xử lý; không second-input
fallback, fakePASS/reset/seq hoặc game recovery chỉ vì lỗi AI.

## Bằng chứng và diagnostics

R1 dùng utility/interval/proxy và calibration có provenance; UNKNOWN không là0.
R2 game promotion, full boss/refill/damage/survival model và learned models chưa
được mở. Advanced setup/bait/giữKhiên sau boss chưa được hứa chắc chắn; joint
3Sword+5Rage cùng đợt chưa có effect-order proof. Xem
[capability manifest](phase5/capability_manifest.md).

Tactical override examples HT7/Mega/Demon giữ đúng source/game/cohort trong
[final report](phase5/FINAL_REPORT.md); không nâng historical pilots thành
current package coverage. D4 có2PASS-validation faults và offline fix sau live;
BASIC vẫn giữ protection hotfix, không claim avoideddeath.

Diagnostics bounded/background, lỗi không block action/Stop; worker không gửi
input. Original decision/proposal/selection/timing được nối với native actual
dispatch/ACK/terminal riêng. Root/fresh/final checkpoints không bị tính thành
nhiều nước. Writer thiếu/flushedFalse/dropped không được gọi là durabilityPASS.

Current F1:2BASIC+2R/4WIN,2completed retention,2workers reaped,12AIrecords/0loss.
UIshadow statusOFF không tự chứng minh labR không chạy; operational receipts
là evidence. NativeU/actualenergyUNKNOWN, paired addedCPU/memoryNOT_MEASURED.
Không train tự động theo nhãn thắng/thua sau mỗi trận.

## Handoff và giới hạn thay đổi

[USER_GUIDE](phase5/USER_GUIDE.md) phân biệt BASIC/shadow/lab R và đọc log.
[ROLLBACK](phase5/ROLLBACK.md) giữ binary/prefs riêng, không reuse batch claims.
E1/E2/F1 đã đóng, không extra live/cap reset hoặc general public activation từ
việc đóng roadmap. F2 chỉ tài liệu; không runtime/test/build/version/release.

Nguồn yêu cầu: [DECISIONS](DECISIONS.md),
[EXECUTION_CONTRACT](phase5/EXECUTION_CONTRACT.md),
[5A.1](phase5/specs/5a1_baseline_reasoning_contract.md),
[5A.2](phase5/specs/5a2_features_utility_and_profiles.md),
[5A.3](phase5/specs/5a3_telemetry_deadline_acceptance.md).
[Policy trước F2](phase5/artifacts/5f2_closeout_20261031/before/docs/reasoning_gameplay_policy.md)
giữ nguyên spec/C3 status lịch sử; không dùng nó thay acceptance hiện tại.