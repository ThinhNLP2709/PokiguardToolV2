# 5B.3 — Refinement boss reply và uncertainty có giới hạn

Đây là prompt thực thi **một bước**, chỉ dùng khi người dùng yêu cầu chạy bước
này. Đọc prompt để chuẩn bị không phải lệnh triển khai.

## Đọc trước

- `D:/PokiguardToolV2/AGENTS.md` hoặc chỉ dẫn AGENTS người dùng cung cấp.
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Nghiên cứu gốc](../phase5a0_reasoning_research.md) và [bổ sung](../phase5a0_research_completion_plan.md).
- [5a2_features_utility_and_profiles.md](../specs/5a2_features_utility_and_profiles.md).
- [5a2_scenario_matrix.md](../specs/5a2_scenario_matrix.md), nhất là D/O/C11.
- [5a3_telemetry_deadline_acceptance.md](../specs/5a3_telemetry_deadline_acceptance.md).
- Report cha trong `docs/phase5/reports/`; nếu chưa có thì chưa đạt entry gate.
- [Demon Shield incident review](../research/demon_shield_setup_incident_review.md):
  DSI01–DSI07 multi-turn loss/control, source-owner check và counterfactual limits.

## Entry và mục tiêu

Mode: **OFFLINE**. 5B.2 PASS STRONG; candidate baseline và utility đã replay được.

Thêm bounded reply/uncertainty refinement trên phần simulator đã có bằng chứng, vẫn offline.

## Thực hiện trong phạm vi

1. Refine đa dạng progress/protection/setup candidates và luôn kèm BASIC; top8, 32scenario là proposed starting caps, không phải bảo đảm optimum. Có global node/time budget.

2. Tách known Sword reply coverage khỏi mọi boss action; không đoán boss skill/PASS/damage policy. Viết manifest SUPPORTED/CONDITIONAL/UNKNOWN theo boss/effect/game version.

3. Cho short horizon ta→boss→ta chỉ khi từng transition còn hợp lệ trong scope model; phần forecast phụ thuộc refill/effect chưa biết giữ conditional/bounds, không credit favorable UNKNOWN. Nominal user model Sword-first/max effective giữ mọi tie; secondary priorities UNKNOWN. Đánh giá Khiên/target còn reachable sau boss và Sword bait có threat, không dùng pre-boss setup làm full credit. Unexamined critical ties không thành guaranteed continuation; chỉ thực thi root sau này.

4. Stress scenario/sensitivity đánh giá fragility; favorable refill không được credit resource/fire readiness. Stress minimum không được gọi global worst case, sample count không thành probability.

5. Cancel/deadline dùng completed incumbent, không proposal đang dở. Replay ghi deterministic work budget/refinement coverage để giải thích time-truncated differences.

6. Validate phần model hẹp bằng evidence sẵn có; thiếu data giữ UNKNOWN. Tách user-calibrated Demon3+Rage/joint3+5 khỏi damage formula/effect-order proof, account binding và observed outcomes. R1 được dùng calibration đúng scope; R2 promotion cần narrow evidence. Nếu cần targeted observation, ghi câu hỏi/return gate, không tự chạy game hoặc mở dự án world model.

7. Focused tests: interrupted search, adversarial/multiple UNKNOWN, baseline outside top set, unsupported reply, budget exhaustion, scope mismatch. Ablation utility-only vs refinement offline, nêu chi phí/lợi ích còn đo được.

## Gate bắt buộc

- No invented refill/damage/boss policy; R2 capability chỉ bật phần đã validate.
- Early return/cancel không xuất action chưa kiểm; tail compute bounded.
- Không buộc hoàn thiện full simulator để tiếp tục R1; profile thiếu essential effect giữ baseline.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- Bounded refinement component + focused tests.
- docs/phase5/capability_manifest.md với evidence/limits; offline ablation/latency artifacts.
- Report `docs/phase5/reports/5b3_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu đủ gate, chọn [5B.4](5B4_ISOLATED_RUNNER_AND_FAILURE_LOGGING.md) làm
  next prompt rồi **STOP**. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
