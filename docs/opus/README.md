# docs/opus — tài liệu của Opus

Thư mục này chứa tài liệu do **Opus** (Devin) viết, tách riêng khỏi tài liệu của các
model khác. Thứ bậc nguồn của dự án giữ nguyên: [AGENTS.md](../../AGENTS.md) →
[DECISIONS.md](../DECISIONS.md) → [CURRENT_STATE.md](../CURRENT_STATE.md).

| File | Nội dung |
|---|---|
| [opus-reasoning-upgrade-plan.md](opus-reasoning-upgrade-plan.md) | **Plan canonical** nâng cấp AI Suy luận match-3, hợp nhất bản Opus đầu tiên với plan SWE-2 ([swe-3-reasoning-upgrade.md](../swe-2/swe-3-reasoning-upgrade.md)): một lõi suy luận chung, phase U0–U17, tiêu chí đo được, điểm dừng, bảng giữ/bổ sung/loại bỏ |

| [STATUS.md](STATUS.md) | Con trỏ tiến độ: U0 hoàn tất, chờ U1 |
| [knowledge_audit.md](knowledge_audit.md) | Bảng KNOWN/UNKNOWN theo năng lực ↔ module ↔ bằng chứng |

**Trạng thái (23/11/2026): U0 hoàn tất (docs-only).** Chưa đổi runtime, chưa chạy
test/live/build. Plan SWE-2 giữ nguyên làm tham khảo.

Các phase sau sẽ thêm `reports/`, `runbooks/` và `artifacts/` (log lớn giữ local, chỉ commit
manifest/hash).
