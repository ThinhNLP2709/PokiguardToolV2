# Phase 5 — Remediation <parent>-R<n>

Thay placeholders bằng lỗi/evidence thật trước khi thực thi; không dùng template
này để mở rộng scope hoặc chạy cả roadmap.

## Entry

- Parent: <step/report>.
- Result/lỗi: <FAIL hoặc regression cụ thể>.
- Reproduction/evidence: <log/replay/source/config/hash>.
- Return gate: <gate chính xác của parent phải đạt lại>.
- Mode: <DOCS/OFFLINE/INTEGRATION; live chỉ khi batch được kích hoạt>.
- Allowed files/boundary: <nhỏ nhất có thể>.

Đọc AGENTS, [contract](../EXECUTION_CONTRACT.md), [status](../STATUS.md),
[router](../ROUTER.md), parent prompt/report và evidence liên quan.

## Thực hiện

1. Isolate nguyên nhân của lỗi đã nêu; không broad refactor/code audit.
2. Ưu tiên disable capability/fallback để BASIC giữ hoạt động. Fix trong
   reasoning boundary; không sửa gameplay baseline để che regression.
3. Không reorder memory/capture/executor/QTE/ACK/lifecycle. Nếu fix cần đổi flow
   ngoài contract, ghi scope conflict và STOP để người dùng quyết định riêng.
4. Minimal fix + meaningful focused regression chứng minh lỗi/return gate.
   Full suite chỉ khi boundary/risk thực tế yêu cầu; docs-only không chạy harness.
5. Offline fault injection trước. Live chỉ batch có cap/stop condition được
   kích hoạt, người dùng vận hành game; không dangerous fault inputs.
6. Ghi evidence trước/sau, affected source/model/config/artifact và gate cần
   revalidate; không tái dùng package acceptance của hash cũ nếu binary đổi.
7. Log/worker failure không block baseline; input đã dispatch không fallback
   bằng input khác. State invalid vẫn fail closed theo existing owner.

## Đầu ra / return

- Report `docs/phase5/reports/<parent>_r<n>_report.md`.
- Update STATUS/capability/router; preserve unrelated work.
- Pass return gate → quay parent để đóng gate, chỉ chọn next và STOP.
- Fail/partial → same remediation, không advance hoặc auto-run live/retry.
- Không commit/push/tag/version/release; không build trừ remediation F1 đã được
  yêu cầu build artifact mới trong phạm vi packaging.
