# 5D.5 — Acceptance Coop Bú win có điều kiện

> **Closure 2026-10-19: CLOSED_BASELINE_ONLY**, theo mục6 bên dưới. Bú win giữ BASIC/current baseline live pending; reasoning/shadow Coop unsupported.105 focused tests PASS,0 live attempts, source không đổi. [Report](../reports/5d5_report.md), [gate](../artifacts/5d5_coop_scope_review_20261019/gate_decision.json). Next5E.1 selected only/chưa thực thi. Rubric gốc bên dưới giữ nguyên.

Đây là prompt thực thi **một bước**, chỉ dùng khi người dùng yêu cầu chạy bước
này. Đọc prompt để chuẩn bị không phải lệnh triển khai.

## Đọc trước

- `D:/PokiguardToolV2/AGENTS.md` hoặc chỉ dẫn AGENTS người dùng cung cấp.
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Nghiên cứu gốc](../phase5a0_reasoning_research.md) và [bổ sung](../phase5a0_research_completion_plan.md).
- [v1.2.4_release_report.md](../../v1.2.4_release_report.md).
- [basic_gameplay_policy.md](../../basic_gameplay_policy.md).
- [5a2_features_utility_and_profiles.md](../specs/5a2_features_utility_and_profiles.md).
- [5a3_bounded_live_protocols.md](../specs/5a3_bounded_live_protocols.md).
- [capability_manifest.md](../capability_manifest.md).
- Report cha trong `docs/phase5/reports/`; nếu chưa có thì chưa đạt entry gate.

## Entry và mục tiêu

Mode: **CONDITIONAL_LIVE**. Solo technical gates/core sạch; Coop baseline chưa được suy từ offline hoặc solo soak.

Đóng phạm vi Bú win trung thực: baseline Coop live trước, reasoning team-objective sau nếu đủ điều kiện.

## Thực hiện trong phạm vi

1. Xác nhận baseline report: Bú win v1.2.4 mới offline complete/live pending. Kiểm có room/teammates/config để quan sát thật; thiếu thì không tự tìm người/chuyển mode.

2. Khi live activated và Coop sẵn: baseline batch tối đa3 attempts, observe local death/team wait/result/re-entry theo accepted flow. Không tự hồi sinh hoặc generic solo emergency vì mục tiêu profile là team win.

3. Chỉ mở reasoning batch tối đa3 attempts nếu baseline Coop sạch, essential action/effect/ownership evidence đủ và nằm trong batch người dùng đã kích hoạt. Tổng cap6 cả abort/invalid.

4. Utility giữ/tạo Sword opportunities cho boss và xử lý resource theo objective; không chỉ đảo dấu survival. Không đoán teammate policy/damage hoặc gán team win cho một candidate.

5. Trace local action legality/PASS/ownership, local death, team result, fallback/lifecycle và no extra reads/captures. Không sửa baseline Coop flow trong acceptance.

6. Nếu Coop unavailable/baseline fail/effect essential UNKNOWN: đóng CLOSED_BASELINE_ONLY, ghi rõ BASELINE_LIVE_PENDING/UNSUPPORTED_REASONING theo evidence, giữ BASIC. Không claim baseline live accepted nếu chưa chạy.

7. Common core/flow/safety regression vẫn FAIL cần remediation; thiếu Coop evidence đơn thuần không chặn solo đã accepted.

## Live gate chung

Chỉ chạy live khi người dùng kích hoạt batch bước này và chuẩn bị game.
Chưa kích hoạt: làm runbook/offline thuộc scope, ghi live PENDING và STOP.
Người dùng vận hành game; không computer-use tự chơi. Không extra reads/captures
và không inject fault gây input sai. Stop/user abort hoặc wrong-turn/stale/
duplicate/ownership/ACK conflict/flow regression phải dừng batch ngay.
Mọi invalid/abort đều tính vào cap; tăng cap cần yêu cầu mới.

## Gate bắt buộc

- Baseline Coop prove trước reasoning; team objective không bị survival rule solo chi phối.
- Bú win accepted/pending/unsupported riêng, không quảng bá coverage từ solo.
- Zero critical regression; batch bounded và không phát input sau local ownership mất.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- Conditional Coop report + exact baseline/live/effect limitations.
- Capability CLOSED_BASELINE_ONLY hoặc accepted-for-scope có evidence.
- Report `docs/phase5/reports/5d5_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu đủ gate hoặc đóng CLOSED_BASELINE_ONLY đúng rubric, chọn [5E.1](5E1_BOUNDED_GAMEPLAY_COMPARISON.md) làm
  next prompt rồi **STOP**. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
