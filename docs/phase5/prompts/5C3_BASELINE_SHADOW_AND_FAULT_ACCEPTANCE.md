# 5C.3 — Chứng minh BASIC/shadow/fallback không đổi flow

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

Mode: **BASELINE_LIVE_OPTIONAL**. 5C.2 PASS STRONG; source/config freeze để kiểm parity.

Kiểm chứng BASIC disabled/shadow và failure fallback giữ flow; chưa cho reasoning thay action.

## Thực hiện trong phạm vi

1. Chạy offline integration parity/fault matrix từ A3: worker/log errors, timeout/late result, source mismatch, pending action, Stop. Kiểm read/capture/order/call counts bằng seam evidence phù hợp, không thêm production observer loop.

2. Đo end-to-end critical-path tails và resource overhead theo SLO B4, so disabled BASIC với shadow. Separate log chỉ dùng nếu đạt; nếu không chuyển common namespace/filter rồi đo lại phần ảnh hưởng.

3. Full regression tại boundary tích hợp; profile-specific behavior giữ accepted khi reasoning off. Không chỉnh BASIC để match shadow.

4. Nếu live được kích hoạt: dùng đúng flow/input mode accepted, một profile solo có baseline rõ; mặc định3 BASIC disabled +3 shadow attempts, tổng cap6. Cả hai chỉ phát baseline action.

5. Live ghi memory/capture sequence, action/ACK/QTE/lease/stop/re-entry parity, fallback và overhead từ evidence sẵn có; không collect bằng extra reads/captures. Cases chưa xảy ra ghi NOT_OBSERVED.

6. Chưa có live: report PASS_OFFLINE_LIVE_PENDING khi offline đủ; chỉ cho phép C4 offline. Trước D1 phải quay lại đóng live parity này, không claim complete acceptance.

7. Nếu live hoặc fault lộ regression chung, stop batch, disable shadow và tạo remediation đúng parent; không chạy tiếp để đủ số.

## Live gate chung

Live chỉ khi người dùng yêu cầu chạy batch của bước này và chuẩn bị game theo
protocol. Nếu đang yêu cầu docs/offline hoặc chưa sẵn game: chuẩn bị runbook,
ghi live PENDING và STOP. Không computer-use tự điều khiển game, không extra
memory reads/captures, không retry vô hạn. Dừng ngay khi Stop/user abort,
wrong-turn/stale/duplicate input, ownership/ACK conflict hoặc flow regression.
Không inject fault có nguy cơ phát input sai trong live.

## Gate bắt buộc

- Offline parity/faults/latency đủ; zero critical safety/flow regression.
- Live parity required trước reasoning input; 6 attempts là technical smoke, không proof win-rate.
- Log sink choice theo overhead evidence; AI lỗi không stop/recover game hoặc alter baseline.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- Parity/fault/latency report, selected diagnostics sink và capability updates.
- Nếu live chưa kích hoạt: bounded runbook + pending matrix, không fabricated PASS.
- Report `docs/phase5/reports/5c3_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu offline đủ nhưng live pending, ghi PASS_OFFLINE_LIVE_PENDING và chỉ chọn C4 offline. Nếu đủ toàn bộ gate, chọn [5C.4](5C4_GUARDED_SELECTION_AND_EXISTING_PREFLIGHT.md) làm
  next prompt rồi **STOP**. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
