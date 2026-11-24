# Opus — STATUS

Con trỏ tiến độ của [plan canonical](opus-reasoning-upgrade-plan.md).

| Mục | Trạng thái |
|---|---|
| Plan canonical | Đã chốt và push (`5c887b77`, 23/11/2026) |
| Phase hiện tại | **U0 hoàn tất (docs-only)** |
| Phase kế tiếp | U1 — bench cùng bàn và đo ngân sách thực tế (offline), chờ user cho bắt đầu |
| Runtime | Chưa đổi; chưa chạy test/live/build |

## U0 — đã làm

- D-U0 được user duyệt ngày 23/11/2026: mục "Suy luận Opus" trong [DECISIONS.md](../DECISIONS.md)
  và catalog tình huống ở Phụ lục B của plan (S01, S02, S06, S11, S20 theo câu trả lời của user).
- Thêm bảng [knowledge_audit.md](knowledge_audit.md): năng lực ↔ module ↔ bằng chứng ↔ KNOWN/UNKNOWN.
- Ghi giả thuyết chưa xác minh: boss có Khiên thì Hút có thể không lấy được tài nguyên.

## Câu hỏi còn mở

- **S02:** sát thương boss hiện ước lượng từ tri thức offline + chỉ số hiện tại. Dùng sát thương
  quan sát trong chính trận đó là ngoại lệ của luật không nhớ trong trận — cần user chốt.
- D-U1 (KPI + ngân sách), D-U2 (đọc bộ nhớ mới), D-U3 (văn bản đồng ý), D-U6 (hoãn tiến hóa/giữ
  skill) chờ tới phase tương ứng.
