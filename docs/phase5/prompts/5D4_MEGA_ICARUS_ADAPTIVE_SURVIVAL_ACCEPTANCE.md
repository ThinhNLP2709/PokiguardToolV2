# 5D.4 — Acceptance Mega Icarus và chống cứng nhắc

> **Closed2026-10-19:** Scoped technicalPASS;2REASONINGWIN/native skillseal5vs6/continuation,2PASSwireerrors preserved and repaired offline112tests. Tổng8/8đãđóng, không replaybatch này hoặc sinhP. Next5D.5selectedonly. [Gate](../artifacts/5d4_smallblue_reasoning2_live_20261018_234026/gate_decision.json), [report](../artifacts/5d4_smallblue_reasoning2_live_20261018_234026/REPORT.md).


Đây là prompt thực thi **một bước**, chỉ dùng khi người dùng yêu cầu chạy bước
này. Đọc prompt để chuẩn bị không phải lệnh triển khai.

## Đọc trước

- `D:/PokiguardToolV2/AGENTS.md` hoặc chỉ dẫn AGENTS người dùng cung cấp.
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Nghiên cứu gốc](../phase5a0_reasoning_research.md) và [bổ sung](../phase5a0_research_completion_plan.md).
- [README.md](../../mega_icarus_spam_skill/README.md).
- [mi3_survival_hotfix_report.md](../../mega_icarus_spam_skill/mi3_survival_hotfix_report.md).
- [mi3_b2_optimization_report.md](../../mega_icarus_spam_skill/mi3_b2_optimization_report.md).
- [5a2_scenario_matrix.md](../specs/5a2_scenario_matrix.md).
- [5a3_bounded_live_protocols.md](../specs/5a3_bounded_live_protocols.md).
- Report cha trong `docs/phase5/reports/`; nếu chưa có thì chưa đạt entry gate.

## Entry và mục tiêu

Mode: **BOUNDED_LIVE**. Core/common flow sạch; Mega Icarus source/skill/seal capability đủ; C3/C4 gates đã đóng.

Chứng minh Mega Icarus suy luận thích ứng để tránh setup cứng nhắc; giữ nguyên click-only và mọi flow v1.2.4.

## Thực hiện trong phạm vi

1. Freeze BASIC survival hotfix và behavior accepted làm control; không sửa threshold BASIC hoặc executor để giúp reasoning pass.

2. Offline paired cases: cùng seal setting, khỏe thì setup hiệu quả; nguy cơ cao thì cân nhắc bảo vệ/fire sớm khi actual legal; có thể phá giữ Sword/setup nếu evidence hỗ trợ; insufficient cost/cooldown không override.

3. Seal feature đúng scope, không nhầm full board; resource/seal/skill cycle, Evolution và repeated skill sử dụng identity/continuation hiện có. Không lấy favorable refill làm seal đạt target.

4. Override không chỉ là thêm một lowHP if. Viết case trước ngưỡng HP cứng với known threat/resource khác, case lowHP mà mọi đường rủi ro, và case heal/effect UNKNOWN phải baseline/proxy có nhãn.

5. Phân bổ gốc BASIC3+REASONING3/cap6 đã được người dùng thay bằng tổng8 trong các phiên đo được yêu cầu trực tiếp. Hiện6attempts đã tiêu và chỉ còn2REASONING, gồm cả entry failure/abort/invalid. Không tự thêm BASIC hoặc nâng cap. Giữ SmallBlue220/JavanIV→Mega/seal6/loadout/đồ; không cố làm pet gần chết hoặc thay game để tạo case.

6. Trace actual skill source/card click-only/ACK, cycles/setup/resource/protection, baseline-vs-proposal reason, deadlines/fallback. Không đổi click/QTE/lease/poll/capture/entry/recovery.

7. Phân biệt risk proxy với lethal/safe proof; thiếu injury/emergency live ghi NOT_OBSERVED và dùng replay có provenance, không giả live acceptance hoặc chạy tiếp ngoài cap.

8. Safety/flow failure → stop + remediation. Tactical benefit chưa rõ → report limitations, không tuyên bố tránh chết chắc chắn.

## Live gate chung

Live chỉ khi người dùng yêu cầu chạy batch của bước này và chuẩn bị game theo
protocol. Nếu đang yêu cầu docs/offline hoặc chưa sẵn game: chuẩn bị runbook,
ghi live PENDING và STOP. Không computer-use tự điều khiển game, không extra
memory reads/captures, không retry vô hạn. Dừng ngay khi Stop/user abort,
wrong-turn/stale/duplicate input, ownership/ACK conflict hoặc flow regression.
Không inject fault có nguy cơ phát input sai trong live.

## Gate bắt buộc

- Anti-rigidity matrix đạt: settings advisory, objective giữ, actual validity hard.
- Existing Mega action flow nguyên vẹn; BASIC fallback/hotfix vẫn giữ.
- Evidence riêng cho cycle và tactical override; outcome sample nhỏ không proof optimality.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- Mega adaptive-survival acceptance matrix + paired replay explanations.
- Bounded live results, seal/source/cycle evidence và unresolved cases.
- Report `docs/phase5/reports/5d4_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu đủ gate, chọn [5D.5](5D5_CONDITIONAL_COOP_BU_WIN_ACCEPTANCE.md) làm
  next prompt rồi **STOP**. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
