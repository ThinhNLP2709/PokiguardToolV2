# 5C.4 — Nối proposal REASONING vào preflight cũ

Đây là prompt thực thi **một bước**, chỉ dùng khi người dùng yêu cầu chạy bước
này. Đọc prompt để chuẩn bị không phải lệnh triển khai.

## Đọc trước

- `D:/PokiguardToolV2/AGENTS.md` hoặc chỉ dẫn AGENTS người dùng cung cấp.
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Nghiên cứu gốc](../phase5a0_reasoning_research.md) và [bổ sung](../phase5a0_research_completion_plan.md).
- [5a1_baseline_reasoning_contract.md](../specs/5a1_baseline_reasoning_contract.md).
- [5a2_features_utility_and_profiles.md](../specs/5a2_features_utility_and_profiles.md).
- [capability_manifest.md](../capability_manifest.md).
- Report cha trong `docs/phase5/reports/`; nếu chưa có thì chưa đạt entry gate.

## Entry và mục tiêu

Mode: **OFFLINE_INTEGRATION**. 5C.3 PASS STRONG hoặc PASS_OFFLINE_LIVE_PENDING cho integration offline; 5A–5C.2 gates đã đủ.

Cho opt-in REASONING proposal đi qua existing preflight/action path, chỉ kiểm offline ở bước này.

## Thực hiện trong phạm vi

1. Selector nhận immutable baseline + completed proposal, validate job/source/config/capability/deadline tại checkpoint hiện có. Không thêm reread/poll/screenshot hoặc chờ planner sau checkpoint.

2. Preflight kiểm legality/ownership/freshness của action reasoning; không gọi BASIC heuristic để loại mọi action khác baseline. Actual hard constraints vẫn giữ.

3. Proposal invalid/timeout/unsupported/worker/log failure dùng baseline còn hợp lệ. State đổi theo existing flow thì discard và để controller xử lý như cũ; không long rerun planner tại dispatch.

4. Đã dispatch input thì ACK/recovery cũ giữ ownership, không gửi baseline thay thế hoặc retry AI. Giữ QTE/PASS/EVOLVE/skill continuation semantics.

5. REASONING opt-in riêng per capability/profile; default BASIC, chưa qua D acceptance thì experimental/gated. Không nới unsupported model để bật profile.

6. Focused integration tests cho valid tactical override, near-tie baseline, malformed/stale/late proposal, insufficient reserve, Stop, pending input và source change. Verify disabled BASIC exact decision parity.

7. Full regression phù hợp selector boundary. Không live/build/package/commit trong C4. C3 live pending phải được ghi thành next closure trước D1.

## Gate bắt buộc

- Proposal khác tactical settings được phép khi hợp lệ và có evidence; settings không bị mutate.
- Same executor/preflight/ACK/read/capture flow; fallback không double input.
- Offline acceptance không phải live authorization hoặc profile-wide promotion.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- Guarded opt-in selector và offline integration evidence.
- Capability matrix, source/config freeze và C3 live closure state.
- Report `docs/phase5/reports/5c4_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu C3 live còn pending, next là C3 live closure. Nếu đủ toàn bộ gate, chọn [5D.1](5D1_SIMPLE_CAREFUL_PILOT.md) làm
  next prompt rồi **STOP**. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
