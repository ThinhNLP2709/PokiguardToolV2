# 5C.2 — Tab AI/config bất biến và tương thích preferences

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

Mode: **OFFLINE_UI**. 5C.1 PASS STRONG; shadow adapter có fault isolation.

Thêm tab AI/config có default BASIC, immutable run settings và capability gate; chưa bật live reasoning.

## Thực hiện trong phạm vi

1. UI cho BASIC/REASONING, shadow diagnostics, bounded compute budget và trạng thái fallback/unsupported. Ghi thuật ngữ dễ hiểu; không hiển thị score thành win probability.

2. Preferences cũ thiếu AI fields vẫn mở BASIC, migrate chỉ bổ sung defaults; không đổi PlayStyle/input mode/loadout hoặc tactical settings có sẵn.

3. Freeze config per run bằng lifecycle/config boundary hiện có. UI change giữa run áp vào lần chạy sau hoặc semantics accepted hiện có; không thêm pause/resume/checkpoint flow.

4. REASONING live selection chưa wire thì control phải gated/disabled và giải thích; không cho UI tạo cảm giác feature đã accepted. Shadow là lựa chọn explicit, không default.

5. Thể hiện overridden suggestion/fallback reason và diagnostics dropped/degraded status; UI update dùng event path hiện có, không thêm poll hoặc block caller.

6. Focused verification old prefs load/save, invalid/capped budget, immutable run config, disabled no-worker, unsupported profile, UI state after Stop. Không chạy live hoặc build package.

## Gate bắt buộc

- Old prefs và BASIC default giữ hoạt động; Start/Stop/Resume và input mode không đổi.
- Không có live authority từ tab AI trước C4/D gates; không tự ghi đè tactical settings.
- UI thread/diagnostics không chờ worker; faults chỉ degrade reasoning.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- Tab AI/config integration và preference compatibility evidence.
- User-facing setting descriptions + immutable config version mapping.
- Report `docs/phase5/reports/5c2_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu đủ gate, chọn [5C.3](5C3_BASELINE_SHADOW_AND_FAULT_ACCEPTANCE.md) làm
  next prompt rồi **STOP**. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
