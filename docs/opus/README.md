# docs/opus — tài liệu của Opus

Thư mục này chứa tài liệu do **Opus** (Devin) viết, tách riêng khỏi tài liệu của các
model khác. Thứ bậc nguồn của dự án giữ nguyên: [AGENTS.md](../../AGENTS.md) →
[DECISIONS.md](../DECISIONS.md) → [CURRENT_STATE.md](../CURRENT_STATE.md).

| File | Nội dung |
|---|---|
| [opus-reasoning-upgrade-plan.md](opus-reasoning-upgrade-plan.md) | **Plan canonical** nâng cấp AI Suy luận match-3, hợp nhất bản Opus đầu tiên với plan SWE-2 ([swe-3-reasoning-upgrade.md](../swe-2/swe-3-reasoning-upgrade.md)): một lõi suy luận chung, phase U0–U17, tiêu chí đo được, điểm dừng, bảng giữ/bổ sung/loại bỏ |
| [STATUS.md](STATUS.md) | Con trỏ tiến độ: U1 hoàn tất phần offline, chờ D-U1 |
| [reports/U1_report.md](reports/U1_report.md) | U1: corpus cùng bàn đóng băng, bench BASIC/R/G4, tái lập, timing, đề xuất KPI + envelope |
| [artifacts/u1_20261124/](artifacts/u1_20261124/) | Manifest corpus + index case, tóm tắt bench, tóm tắt timing (corpus/log lớn giữ local, chỉ commit SHA) |
| [knowledge_audit.md](knowledge_audit.md) | Bảng KNOWN/UNKNOWN theo năng lực ↔ module ↔ bằng chứng |

**Trạng thái (24/11/2026): U1 hoàn tất phần offline, chờ D-U1.** `src/` không đổi, không
live/build/release. Plan SWE-2 giữ nguyên làm tham khảo.

`reports/` và `artifacts/` bắt đầu từ U1; `runbooks/` thêm khi có phase live. Log và corpus lớn
giữ local, chỉ commit manifest/hash.
