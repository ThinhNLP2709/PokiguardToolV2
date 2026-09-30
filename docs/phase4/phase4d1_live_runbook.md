# Phase 4D.1 — Kịch bản live A/B

Manifest chuẩn: [artifacts/phase4d1_manifest.json](artifacts/phase4d1_manifest.json).
Analyzer chỉ đọc artifact; không gửi input và không đổi gameplay.

## Cấu hình khóa chung

- boss: `Starburst`, pet ID nền `1289`;
- số trận mục tiêu: `5`;
- số lần thử tối đa: `8`;
- lối chơi: `Chịu đấm ăn xôi` / `skill_rush`;
- pet chính: `Huyền thoại`;
- tiến hóa: `Không tiến hóa`;
- hành động skill: `Thẻ skill của pet`;
- Audition V3, board input `two_click`;
- điều kiện skill: `sword_count >= 7`;
- toàn bộ field gameplay còn lại phải đúng manifest.

Hai nhánh phải dùng cùng source fingerprint và game hash trong manifest. Không sửa
file Python production giữa A và B.

Preflight hiện tại phải mang source fingerprint
`8f60fdfa60fc56703d59ea9018cb2942c4bec4291ade621a3d76f6d2e01fbeb3`.
Đây là bản đã chấp nhận multiplier b5 x1..x7; run cũ
`e746727a66bc4f7589e416b1abaacf8e` bị loại khỏi A/B vì board starvation ở
turn 21/23/25.

Manifest đã được làm mới sau remediation QTE focus collision. A cũ
`974763bccc784a9887df25f12f84759c` sạch nhưng thuộc fingerprint trước đó nên
không còn được bind. B mới `ee17b4a58a14430ba1d394620edb7d26` đã chạy trước
và đạt acceptance riêng 5/5 với 35 focus takeovers. A mới
`a32e8eb15136456ca9231cb29934e3da` cũng đã hoàn thành 5/5 trên cùng fingerprint;
cặp đã được analyzer chấp nhận `PASS_STRONG` và runbook này đã hoàn tất.

## B1 — A_FOREGROUND

1. Mở tool bằng `run_tool.bat`, vào đúng boss lobby Starburst LV73.
2. Chọn đúng chế độ thao tác **foreground mặc định**. Không dùng lựa chọn
   `Ghim game để tự chơi khi dùng máy — Beta`; checkpoint phải ghi
   `input_delivery_mode=foreground`.
3. Đặt `5` trận mục tiêu, `8` lần thử tối đa và lưu cấu hình khóa chung.
4. Nhấn **Bắt đầu**.
5. Giữ game foreground suốt run; không chuyển focus, di chuyển, resize hay minimize
   cửa sổ game.
6. Chờ tool tự dừng đúng `5/5` ở boss lobby. Không nhấn dừng giữa run.

Sau khi B1 xong, đóng tool và báo `B1 4D.1 đã xong`. Agent sẽ đọc artifact mới
nhất, kiểm tra gate và bind FarmRunId vào manifest. Chỉ khi B1 sạch mới chạy B2.

## B2 — B_PINNED_FOREGROUND_BETA

1. Mở lại tool, giữ nguyên toàn bộ cấu hình B1; chỉ đổi chế độ thao tác sang
   `Ghim game để tự chơi khi dùng máy — Beta`.
2. Đặt lại `5` trận mục tiêu, `8` lần thử tối đa, lưu và nhấn **Bắt đầu**.
3. Sau khi board của trận 1, 3 và 5 xuất hiện, chuyển focus sang một cửa sổ khác.
   Không di chuyển, resize hay minimize game. Để tool tự lấy focus trong action
   lease kế tiếp.
4. Chờ tool tự dừng đúng `5/5` ở boss lobby.

Sau B2, đóng tool và báo `B2 4D.1 đã xong`. Agent bind run B, chạy analyzer và chỉ
chốt `PASS STRONG` nếu:

- cả hai run đúng 5 completed / 5 attempts và không có UNKNOWN;
- input đã gửi có ACK theo từng domain;
- stale/duplicate/partial/wrong-turn và toàn bộ critical counter bằng 0;
- foreground A không dùng lease Beta;
- B chỉ takeover trong action/QTE lease có identity, khôi phục cursor/focus và
  unpin sạch;
- controller kết thúc `FARM_RUN_COMPLETE` / `BOSS_LOBBY`.
