# 5C.1 — Nối shadow tại ranh giới chọn action hiện có

Đây là prompt thực thi **một bước**, chỉ dùng khi người dùng yêu cầu chạy bước
này. Đọc prompt để chuẩn bị không phải lệnh triển khai.

## Đọc trước

- `D:/PokiguardToolV2/AGENTS.md` hoặc chỉ dẫn AGENTS người dùng cung cấp.
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Nghiên cứu gốc](../phase5a0_reasoning_research.md) và [bổ sung](../phase5a0_research_completion_plan.md).
- [5a1_baseline_reasoning_contract.md](../specs/5a1_baseline_reasoning_contract.md).
- [5a3_telemetry_deadline_acceptance.md](../specs/5a3_telemetry_deadline_acceptance.md).
- [capability_manifest.md](../capability_manifest.md).
- Report cha trong `docs/phase5/reports/`; nếu chưa có thì chưa đạt entry gate.

## Entry và mục tiêu

Mode: **SHADOW_ADAPTER**. 5B.1–5B.4 PASS STRONG; production integration chỉ được mở trong bước này.

Nối shadow đúng boundary chọn action đã có; BASIC tiếp tục quyết định và phát input như v1.2.4.

## Thực hiện trong phạm vi

1. Xác định seam nhỏ nhất từ snapshot/decision hiện có; đọc source liên quan ở bước integration này. Không di chuyển memory/screenshot/preflight hay rewrite FarmRunner.

2. Từ state đã có tạo immutable planner job và BASIC incumbent. Shadow enqueue không chờ, queue full bỏ job; caller không chờ worker/log sink để dispatch baseline.

3. Shadow result chỉ để diagnostics/replay, không thay action, timing, PASS accounting, srvSeq, idle reset hoặc pending/ACK owner.

4. Disabled path giữ BASIC behavior và không tạo worker/model/trace nặng. Không thêm read/capture để bổ sung dataset.

5. Correlate baseline action thực sự gửi với job/result/outcome sẵn có; observation không đủ attribution giữ UNKNOWN. Không thêm polling ACK riêng.

6. Focused integration verification cho shadow disabled/enabled/late/fault/log failure, stale source, pending action, Stop và queue exhaustion. Full regression phù hợp boundary integration, chưa live.

7. Đo shadow critical-path overhead offline theo SLO; không dùng replay làm live parity acceptance.

## Gate bắt buộc

- BASIC action selection và existing execution sequence parity; shadow không có selection/input authority.
- Zero extra provider reads/captures/polls và zero wait for planner/log.
- Fault không đổi flow/lifecycle; regression phải sửa trước UI/pilot.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- Minimal shadow adapter opt-in, disabled mặc định.
- Parity/fault/overhead evidence và source seam map trong report.
- Report `docs/phase5/reports/5c1_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu đủ gate, chọn [5C.2](5C2_AI_SETTINGS_AND_IMMUTABLE_RUN_CONFIG.md) làm
  next prompt rồi **STOP**. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
