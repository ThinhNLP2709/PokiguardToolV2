# 5D.1 — Pilot SIMPLE/CAREFUL

Đây là prompt thực thi **một bước**, chỉ dùng khi người dùng yêu cầu chạy bước
này. Đọc prompt để chuẩn bị không phải lệnh triển khai.

## Đọc trước

- `D:/PokiguardToolV2/AGENTS.md` hoặc chỉ dẫn AGENTS người dùng cung cấp.
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Nghiên cứu gốc](../phase5a0_reasoning_research.md) và [bổ sung](../phase5a0_research_completion_plan.md).
- [5a3_bounded_live_protocols.md](../specs/5a3_bounded_live_protocols.md).
- [5a2_scenario_matrix.md](../specs/5a2_scenario_matrix.md).
- [capability_manifest.md](../capability_manifest.md).
- Report cha trong `docs/phase5/reports/`; nếu chưa có thì chưa đạt entry gate.

## Entry và mục tiêu

Mode: **BOUNDED_LIVE**. 5C.4 PASS STRONG + 5C.3 live parity closure; A3 live protocol và source/config freeze đủ.

Pilot kỹ thuật từng SIMPLE và CAREFUL, kiểm adaptive selection/fallback trong flow accepted.

**Điều chỉnh thực thi theo yêu cầu người dùng ngày 2026-10-16:** gom phần còn
thiếu vào chính 5D.1, không tự sinh chuỗi P. Offline chốt chung source, tests,
cost qualification từng profile và runbook trước khi dừng chờ live. Các P cũ
là lịch sử evidence, không còn là next pointer điều khiển tiến độ.

Live dùng control trước: SIMPLE BASIC3 → REASONING3, CAREFUL BASIC3 → REASONING3.
BASIC controls cùng source phục vụ cả baseline và native H/I, không thêm một
batch calibration ngoài cap12. Formula/policy/cost/source/config khóa trước;
native maxima dẫn xuất sau control, không tune theo outcome. Đây là pilot kỹ
thuật tuần tự, không AB/BA/efficacy claim. Chi tiết trong
[runbook hiện tại](../research/5d1_pilot_runbook.md).

## Thực hiện trong phạm vi

1. Kiểm entry từ report, không audit lại toàn repo. Ghi boss/loadout/input mode/source/config và profile capability; giữ cohort comparable, baseline control từ chính accepted path.

2. Khi live bước này được kích hoạt, default3 attempts/arm/profile: SIMPLE BASIC3+REASONING3, CAREFUL BASIC3+REASONING3, tổng cap12 attempts kể cả invalid/abort. Không auto-retry ngoài cap.

3. Giữ settings/loadout cố định trong mỗi cohort; không switch policy giữa trận để gọi A/B độc lập. Block/order theo A3, không đổi tactical settings để ép planner thắng.

4. Trace quyết định khác baseline: contribution/risk/UNKNOWN, tại sao hợp mục tiêu; same-settings context adaptation. CAREFUL nhạy rủi ro hơn nhưng không biến highUNKNOWN thành cấm tuyệt đối.

5. Quan sát fallback/deadline và existing action/ACK/QTE/read/capture/stop path. Fault nguy hiểm chỉ offline; không cố tạo wrong-turn/duplicate input trong game.

6. Ghi mọi attempt/W-L-UNKNOWN/energy/time/fallback/abort và profile-specific limitations. Cases không thấy không tự chạy thêm để đủ.

7. Đóng technical scope từng profile; vài trận chưa chứng minh efficacy. Unsupported profile giữ BASIC; common safety failure phải remediation trước bước tiếp.

## Live gate chung

Live chỉ khi người dùng yêu cầu chạy batch của bước này và chuẩn bị game theo
protocol. Nếu đang yêu cầu docs/offline hoặc chưa sẵn game: chuẩn bị runbook,
ghi live PENDING và STOP. Không computer-use tự điều khiển game, không extra
memory reads/captures, không retry vô hạn. Dừng ngay khi Stop/user abort,
wrong-turn/stale/duplicate input, ownership/ACK conflict hoặc flow regression.
Không inject fault có nguy cơ phát input sai trong live.

## Gate bắt buộc

- Zero new critical flow/safety failure; baseline rollback hoạt động.
- Reasoning override hợp lệ, có rationale/UNKNOWN; proof thuộc profile đã chạy.
- BASIC default chưa đổi; gameplay efficacy chờ E1.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- Bounded pilot results SIMPLE và CAREFUL, run IDs/log paths.
- Per-profile acceptance/limitations matrix và rollback status.
- Report `docs/phase5/reports/5d1_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu đủ gate, chọn [5D.2](5D2_SKILL_RUSH_ACCEPTANCE.md) làm
  next prompt rồi **STOP**. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
