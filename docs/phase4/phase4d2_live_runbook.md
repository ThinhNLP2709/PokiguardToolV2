# Phase 4D.2 — Kịch bản live soak 25 trận

Manifest chuẩn: [artifacts/phase4d2_manifest.json](artifacts/phase4d2_manifest.json).
Analyzer chỉ đọc log sau khi run kết thúc; không theo dõi live và không gửi input.

## Cấu hình bắt buộc

- boss: `Starburst LV73 - Đảo rồng`;
- chế độ thao tác: **Ghim game để tự chơi khi dùng máy — Beta**;
- số trận mục tiêu: `25`;
- số lần thử tối đa: `30`;
- lối chơi: `Chịu đấm ăn xôi`;
- pet chính: `Huyền thoại`;
- tiến hóa: `Không tiến hóa`;
- hành động skill: `Thẻ skill của pet`;
- Audition: `V3`;
- board input: `two_click`;
- điều kiện ra skill: `Kiếm >= 7`;
- các field còn lại giữ đúng cấu hình đã lưu của manifest.

Không sửa file Python production hoặc đổi cấu hình sau khi bắt đầu. Nếu có thay
đổi thì manifest phải được chuẩn bị lại và sample cũ không còn là acceptance
của source mới.

## B0 — Smoke cho remediation QTE

Trước soak retry, chạy `1` trận với tối đa `3` attempts. Khi tool bắt đầu Pet
Skill, thử di chuyển/click chuột ra ngoài game trong lúc chuỗi hướng và Audition
đang chạy. Kết quả yêu cầu: chuột vẫn bị guard giữ, game không mất foreground,
QTE gửi đủ hướng + Space và đạt PERFECT. Log phải có
`foreground_qte_full_guard_retained`, không có `PINNED_QTE_LEASE_INVALIDATED`
hoặc `PINNED_QTE_FULL_GUARD_FAILED`. Run B0 chỉ xác nhận fix và không thay thế
B1.

## B1 — Reliability soak

1. Tự mở tool bằng `run_tool.bat` và vào đúng phòng chờ Starburst.
2. Chọn cấu hình trên, đặt `25` / `30`, nhấn **Lưu**.
3. Nhấn **Bắt đầu** một lần.
4. Sau khi run hoạt động, dùng cửa sổ khác bình thường để tạo focus handoff thật.
   Giữ game hiển thị và được ghim; không minimize, resize hay đóng game. Trong
   khoảnh khắc tool lấy mouse/keyboard lease, để tool hoàn tất action rồi tiếp tục
   dùng máy.
5. Không cố tình bấm X, tạo phòng rỗng, ngắt mạng hoặc gây recovery. Nếu server
   tự đưa tool qua map/re-entry thì để route tự xử lý.
6. Chờ tool tự dừng đúng `25/25` ở boss lobby. Không nhấn Start lần nữa.

Nếu tool dừng sớm, treo, sai input hoặc game bị đá vì ba lượt bỏ liên tiếp, giữ
nguyên trạng thái và báo ngay; không resume để che run lỗi.

Khi run hoàn tất, báo **`4D.2 đã xong 25 trận`**. Agent sẽ:

1. tìm FarmRunId mới nhất và đối chiếu exact mode/config/target;
2. bind đúng run vào manifest;
3. tạo `phase4d2_analysis.json` và `phase4d2_analysis.md`;
4. kiểm tra toàn bộ 25 trận, ACK, PERFECT, focus/guard/cursor cleanup, recovery,
   final stop và source/game fingerprint;
5. chỉ chốt Phase 4D.2 khi analyzer trả `PASS_STRONG`.

Natural recovery không xuất hiện sẽ được ghi `NOT_OBSERVED`, không phải failure,
vì route này đã có accepted replay 2/2 ở Phase 4C.2.
