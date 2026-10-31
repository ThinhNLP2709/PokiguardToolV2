# Phase 5 — Targeted evidence <parent>-E<n>

Thay placeholders bằng một câu hỏi hẹp. Đây không phải lệnh viết full simulator,
thay reader/executor hoặc chạy gameplay để “tìm hiểu thêm” không giới hạn.

## Entry / câu hỏi

- Parent/report/gate: <...>.
- Unknown cụ thể: <effect/feature/deadline/coverage nào>.
- Vì sao cần để ra quyết định: <...>.
- Existing evidence: <logs/published snapshot/reverse/canonical>.
- Cách phân biệt các giả thuyết: <observation/analysis>.
- Scope/game/source/profile version: <...>.
- Cap/time/stop condition: <...>.
- Đầu ra đóng câu hỏi hoặc giữ UNKNOWN: <...>.

Đọc AGENTS, [contract](../EXECUTION_CONTRACT.md), parent, [router](../ROUTER.md).
Ưu tiên đọc dữ liệu đã có; nếu kiến thức thuật toán cần tra cứu thì primary
papers/docs, link nguồn và phân biệt inference với observation game.

## Phạm vi

1. Phân tích snapshot/log/reverse đã có; không đoán RVA/offset/damage/refill/
   boss policy và không dùng resource tally làm HP evidence.
2. Nếu effect attribution không tách được actor/boss/teammate thì UNKNOWN;
   không tự tạo training label hoặc prediction guarantee.
3. Observation mới chỉ dùng state/log sẵn trong accepted flow, không thêm
   provider reads/captures/poll loop hoặc sửa runtime dưới tên research.
4. Cần instrumentation/schema mới thì đề xuất change tại đúng phase code riêng;
   bước evidence này không tự implement. Cần flow mới thì ngoài Phase5 contract.
5. Live observation chỉ batch activated có cap, người dùng vận hành game,
   no computer-use/no dangerous inputs. Không live → runbook + PENDING rồi STOP.
6. Không đủ evidence tại cap → unsupported/fallback hoặc pending có lý do;
   không tự kéo dài, không đổi hypothesis sau kết quả để gọi PASS.

## Đầu ra / STOP

- Report `docs/phase5/reports/<parent>_e<n>_report.md`, evidence table, sources,
  scope/limits/prediction error nếu applicable, capability manifest updates.
- Ghi ANSWERED_FOR_SCOPE / UNKNOWN / INCONCLUSIVE, không fake PASS.
- Router quay return gate parent, không nhảy phase. Không code/runtime changes,
  commit/push/tag/build/version/release trong bước nghiên cứu này.
