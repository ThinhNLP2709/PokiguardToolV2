# Demon Aegis Farm

## Phạm vi cấu hình

- Lối chơi: `Demon Aegis Farm`.
- Pet của tôi: `Pet thường` (cố định).
- Tiến hóa: `Không tiến hóa` (cố định).
- Thẻ sát thương: `Nội tại pet` (chỉ khả dụng trong lối chơi này).
- Điều kiện: `Kiếm đủ`, so sánh bao hàm `>=`, mặc định `3`.

Tool chưa có một trường tên pet chính ổn định tại biên policy của mọi lượt. Vì
vậy bản đầu chưa khóa tên `Demon Aegis`; cấu hình pet và hành vi nội tại vẫn bị
khóa chặt. Không suy đoán tên pet từ boss hoặc thẻ skill.

## Mô hình nội tại

Tọa độ board trong code là zero-based `(row, col)`:

- match Khiên theo hàng ngang: mỗi Khiên trong chuỗi quét trọn cột của nó;
- match Khiên theo cột dọc: mỗi Khiên trong chuỗi quét trọn hàng của nó;
- match hình chữ thập áp dụng hợp của cả hai vùng và không đếm trùng giao điểm;
- ô `UNKNOWN` không được tính là Kiếm;
- điều kiện dùng số **ô Kiếm vật lý** trong vùng quét;
- multiplier x2..x7 được cộng riêng vào `sword_effective` để xếp hạng sát
  thương, không làm một ô Kiếm biến thành nhiều ô cho điều kiện `>= 3`.

## Thứ tự quyết định

1. Nếu có match Khiên quét ít nhất ngưỡng Kiếm, chọn nước có nhiều ô Kiếm bị
   quét nhất; `sword_effective` là tie-break tiếp theo.
2. Nếu chưa có nước đạt ngưỡng, chọn nước không ăn Kiếm và không kích hoạt Khiên
   sớm để tạo một match Khiên tốt ở lượt kế tiếp. Solver kiểm tra hình học một
   lượt nhìn trước trên kết quả đã mô phỏng.
3. Ưu tiên nước an toàn. Khi không có nước an toàn và HP trên 30%, cho phép nước
   setup để lại cơ hội Kiếm cho boss, theo đúng phạm vi rủi ro của chiến thuật.
4. Khi HP thấp hoặc chưa rõ, ưu tiên Khiên/Máu. PASS chỉ là lựa chọn cuối cùng
   và chỉ dùng khi trạng thái pass do game sở hữu xác nhận chưa chạm giới hạn hai
   lượt liên tiếp.
5. Không bao giờ chọn nước có match Kiếm hoặc cascade Kiếm do swap thông thường.
   Kiếm dùng để gây sát thương phải nằm trong vùng quét của nội tại.

`Nội tại pet` không đi qua luồng click thẻ hoặc QTE. Quyết định cuối cùng luôn là
một swap bàn cờ thông thường và tiếp tục dùng input executor hiện có.

## Xác nhận live

### B1 — một trận

- Run `ed5c55615cb64c1888693d19f93631c3`: **1/1 thắng**.
- Nhánh `DEMON_AEGIS_PASSIVE_FIRE` ăn 3 Khiên, vùng nội tại chứa 6 Kiếm và
  kết thúc boss ngay lượt đầu.
- Tiêu hao 1 năng lượng; không dùng thẻ, QTE, tiến hóa hoặc PASS.

### B2 — năm trận liên tục

- Run `e4b09940aa9a4f40baf8a8db54a119b9`: **5/5 thắng**, 5 kết quả đều có
  bằng chứng `STRONG` và nhất quán với giao diện hậu trận.
- Tổng 8 lượt/năng lượng: `1, 2, 1, 1, 3`; không có technical abort,
  recovery, safe stop hoặc PASS.
- Ba trận kích hoạt nội tại ngay lượt đầu. Hai trận còn lại bao phủ
  `DEMON_AEGIS_SETUP_RISK_ACCEPTED`; trận cuối đồng thời bao phủ
  `DEMON_AEGIS_SETUP` trước khi kích hoạt nội tại.
- Số Kiếm vật lý trong vùng phá tại năm nước kết liễu lần lượt là
  `3, 4, 4, 4, 3`, đều thỏa điều kiện bao hàm `>= 3`.
- Không quyết định nào trực tiếp match/cascade Kiếm. Telemetry an toàn ghi nhận
  0 click trùng, click sai, input thiếu, sai lượt, stale action, input ở lượt
  boss, hậu trận hoặc ngoài chiến đấu.

Kết quả B1 và B2 chấp nhận lối chơi cho phạm vi live ban đầu. Việc xác minh tên
pet vẫn để mở cho tới khi runtime cung cấp danh tính pet chính ổn định.
