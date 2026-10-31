# 5E.1 — So sánh hiệu quả gameplay có giới hạn


<!-- E1_B10_CLOSED_20261022 -->
> **Current2026-10-22:5E.1 CLOSED — TECHNICAL PASS / EFFICACY INCONCLUSIVE.**
> Lieyun77/DemonShield/effectiveSword4,20/20WIN (10B+10R),0input-safety/read
> error/abort/recovery. BASIC17localturns,REASONING23; actualenergyUNKNOWN,
> one session, no superiority/promotion.10workers healthy/reaped,0diagnosticloss.
> Source351a646469…; raw/exposure/watermarks pinned. [Closeout](../artifacts/5e1_b10_requalification_20261022/CLOSEOUT.md).
> **Nextreasoning5E.2 deferred by user**, not started. User separately requested
> normal BASICfarm400; not E1extra attempts or E2acceptance. Earlier ACTIVE/
> pending20/manualStart/calibration instructions below are historical, not
> authority to reopen or reset the completed batch. Computer-use permission
> applies only to the user's current20+400 prompt.


> **Current 2026-10-21: 5E.1 ACTIVE/PARTIAL — BASIC3 WIN3/3 và offline requalification đã xong; chờ người dùng sẵn sàng live20 (10B+10R).** Draft hiện tại346 file `3a5d5fd…`,0 E1 holdout/request/claim. Recovery legacy setting không tắt flow; recovery/slot mismatch => technical failure và existing operator Stop. Không đo lại/sinhP/mở lạiD3. Xem [runbook hiện tại](../artifacts/5e1_requalification_1749_20261021/RUNBOOK.md).

Đây là prompt thực thi **một bước**, chỉ dùng khi người dùng yêu cầu chạy bước
này. Đọc prompt để chuẩn bị không phải lệnh triển khai.

## Đọc trước

- `D:/PokiguardToolV2/AGENTS.md` hoặc chỉ dẫn AGENTS người dùng cung cấp.
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Nghiên cứu gốc](../phase5a0_reasoning_research.md) và [bổ sung](../phase5a0_research_completion_plan.md).
- [5a3_telemetry_deadline_acceptance.md](../specs/5a3_telemetry_deadline_acceptance.md).
- [5a3_bounded_live_protocols.md](../specs/5a3_bounded_live_protocols.md).
- [capability_manifest.md](../capability_manifest.md).
- Report cha trong `docs/phase5/reports/`; nếu chưa có thì chưa đạt entry gate.

## Entry và mục tiêu

Mode: **BOUNDED_LIVE**. Technical acceptance của profile/cohort định so sánh đã đủ; source/config freeze; scope unsupported bị loại minh bạch.

Đánh giá lợi ích thực tế của policy trên cohort có giới hạn, không dùng replay/shadow làm counterfactual win-rate.

## Thực hiện trong phạm vi

1. Chọn cohort theo boss/loadout/profile/mode/version; mỗi profile/cohort có verdict riêng. Freeze weights/model/config, planned sample/cap/order/stop rule trước khi thấy outcomes.

2. Dùng BASIC control và REASONING ở các trận riêng theo block assignment của A3; không chuyển policy trong trận, không giả cùng seed refill. Ghi session/order/game drift và exclusions trước.

3. Mặc định một cohort,10 attempts/arm tổng20 khi live activated; protocol A3 có thể quy định cap khác đã được kích hoạt, tối đa50/arm/cohort. Không tự mở nhiều cohort/hàng trăm trận; required power vượt cap thì INCONCLUSIVE.

4. Ghi mọi attempts W/L/UNKNOWN/abort, total energy/WIN gồm trận thua/abort, time/WIN, throughput, skill/setup/cycle/protection và technical counters; zero WIN thì ratio undefined.

5. Ước lượng CI95% với đơn vị trận/session/block phù hợp; nhiều turn cùng trận không phải sample độc lập. Non-inferiority margin/product target phải đã freeze, không nới sau khi thấy thua.

6. So utility/refinement ablation chỉ nếu cohort/cap đã định trước; không bắt buộc chạy mọi tổ hợp. Không retune holdout hoặc kéo dài batch để đạt ý nghĩa.

7. Kết luận PROMOTE chỉ phạm vi đủ evidence + reliability; INCONCLUSIVE khi mẫu/power/coverage chưa đủ; NO_PROMOTION khi không có lợi hoặc chi phí không đáng. Safety regression luôn FAIL.

8. BASIC giữ mặc định. PROMOTE chỉ chấp nhận REASONING để người dùng opt-in trong scope đã prove; không tự bật AI. Ghi recommendation experimental/disabled theo profile; model không tự mở khi weighted planner không cải thiện.

## Live gate chung

Chỉ chạy live khi người dùng kích hoạt batch bước này và chuẩn bị game.
Chưa kích hoạt: làm runbook/offline thuộc scope, ghi live PENDING và STOP.
Người dùng vận hành game; không computer-use tự chơi. Không extra reads/captures
và không inject fault gây input sai. Stop/user abort hoặc wrong-turn/stale/
duplicate/ownership/ACK conflict/flow regression phải dừng batch ngay.
Mọi invalid/abort đều tính vào cap; tăng cap cần yêu cầu mới.

## Gate bắt buộc

- Outcome observed của policy thật, không fake counterfactual; all-attempt accounting.
- Pre-registered bounds/cohorts/metrics và uncertainty/limitations rõ.
- Efficacy verdict tách technical PASS; no superiority claim khi INCONCLUSIVE/NO_PROMOTION.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- Frozen comparison manifest và bounded results/CI per cohort.
- Efficacy verdict + recommendation/default/rollback scope; updated capability matrix.
- Report `docs/phase5/reports/5e1_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu technical gate đủ, ghi efficacy verdict và chọn
  [5E.2](5E2_RELIABILITY_AND_FALLBACK_SOAK.md), rồi **STOP**.
  Nhánh model L chỉ khi được yêu cầu riêng. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
