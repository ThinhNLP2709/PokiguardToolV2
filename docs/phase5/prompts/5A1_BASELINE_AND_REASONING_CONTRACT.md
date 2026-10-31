# 5A.1 — Chốt baseline v1.2.4 và ranh giới REASONING

Đây là prompt thực thi **một bước**, chỉ dùng khi người dùng yêu cầu chạy bước
này. Đọc prompt để chuẩn bị không phải lệnh triển khai.

## Đọc trước

- `D:/PokiguardToolV2/AGENTS.md` hoặc chỉ dẫn AGENTS người dùng cung cấp.
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Nghiên cứu gốc](../phase5a0_reasoning_research.md) và [bổ sung](../phase5a0_research_completion_plan.md).
- [v1.2.4_release_report.md](../../v1.2.4_release_report.md).
- [DECISIONS.md](../../DECISIONS.md).
- [basic_gameplay_policy.md](../../basic_gameplay_policy.md).
- [gameplay_rules.md](../../gameplay_rules.md).
- 5A.1 lấy nghiên cứu 5A.0 làm đầu vào; chưa cần execution report trước đó.

## Entry và mục tiêu

Mode: **DOCS**. Nghiên cứu 5A.0 và yêu cầu người dùng; chưa cần code.

Chốt contract REASONING bổ sung cho v1.2.4, không thay flow accepted và không khóa cứng chiến thuật theo settings.

## Thực hiện trong phạm vi

1. Đọc nghiên cứu có sẵn, canonical và report release. Ghi version/HEAD thực tế; đây là bước docs, không mở một đợt code audit/test.

2. Viết manifest flow được bảo toàn: provider/memory → snapshot hiện có → decision → preflight → executor/ACK; ghi chủ sở hữu memory/capture/input/lifecycle/stop. Đây là mô tả boundary, không đề xuất thứ tự read mới.

3. Lập bảng hard validity, objective PlayStyle và soft tactics. Actual cost/cooldown/ownership/turn/PASS/skill source là hard; setup/fire threshold, Sword lock và heuristic priority là gợi ý cho REASONING.

4. Chốt BASIC incumbent sẵn có, fallback trước dispatch, loại late/stale proposal tại existing preflight, state invalid fail closed; input đã gửi thuộc ACK/recovery cũ.

5. Chốt error isolation/logging: không pause/recover game chỉ vì AI lỗi; queue/disk lỗi không block; separate diagnostics chỉ nếu overhead đạt gate.

6. Cập nhật canonical chỉ phần định nghĩa REASONING còn thiếu để phản ánh yêu cầu người dùng; giữ mô tả BASIC accepted. Không sửa code/config thực thi.

## Gate bắt buộc

- Có ví dụ Mega cần chọn khác seal/setup threshold, cùng ví dụ giữ objective khi đang an toàn.
- Contract cấm thêm memory read/capture/poll/executor path; zero runtime diff.
- Mọi UNKNOWN có cách xử lý; không hứa global optimum/no-loss guarantee.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- docs/phase5/specs/5a1_baseline_reasoning_contract.md
- Canonical docs cần sửa về định nghĩa REASONING, có ghi phạm vi BASIC giữ nguyên.
- Report `docs/phase5/reports/5a1_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu đủ gate, chọn [5A.2](5A2_ADAPTIVE_PLAYSTYLE_AND_FEATURE_SPEC.md) làm
  next prompt rồi **STOP**. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
